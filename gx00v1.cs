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
   public class gx00v1 : GXDataArea, System.Web.SessionState.IRequiresSessionState
   {
      public gx00v1( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public gx00v1( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( long aP0_pSolicitudesID ,
                           out short aP1_pSolicitudesItemsID )
      {
         this.AV12pSolicitudesID = aP0_pSolicitudesID;
         this.AV13pSolicitudesItemsID = 0 ;
         ExecutePrivate();
         aP1_pSolicitudesItemsID=this.AV13pSolicitudesItemsID;
      }

      protected override void ExecutePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         cmbavCsolicituditemssr = new GXCombobox();
         cmbSolicitudItemsSR = new GXCombobox();
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
               AV12pSolicitudesID = (long)(Math.Round(NumberUtil.Val( gxfirstwebparm, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV12pSolicitudesID", StringUtil.LTrimStr( (decimal)(AV12pSolicitudesID), 18, 0));
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
               {
                  AV13pSolicitudesItemsID = (short)(Math.Round(NumberUtil.Val( GetPar( "pSolicitudesItemsID"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV13pSolicitudesItemsID", StringUtil.LTrimStr( (decimal)(AV13pSolicitudesItemsID), 4, 0));
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
         AV6cSolicitudesItemsID = (short)(Math.Round(NumberUtil.Val( GetPar( "cSolicitudesItemsID"), "."), 18, MidpointRounding.ToEven));
         AV10cSolicitudesItemsPrecioFinal = NumberUtil.Val( GetPar( "cSolicitudesItemsPrecioFinal"), ".");
         AV11cSolicitudesItemsCantidad = (short)(Math.Round(NumberUtil.Val( GetPar( "cSolicitudesItemsCantidad"), "."), 18, MidpointRounding.ToEven));
         AV15cSolicitudItemsComision = NumberUtil.Val( GetPar( "cSolicitudItemsComision"), ".");
         cmbavCsolicituditemssr.FromJSonString( GetNextPar( ));
         AV16cSolicitudItemsSR = GetPar( "cSolicitudItemsSR");
         AV17cSolicitudItemsComisionTipo = GetPar( "cSolicitudItemsComisionTipo");
         AV12pSolicitudesID = (long)(Math.Round(NumberUtil.Val( GetPar( "pSolicitudesID"), "."), 18, MidpointRounding.ToEven));
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid1_refresh( subGrid1_Rows, AV6cSolicitudesItemsID, AV10cSolicitudesItemsPrecioFinal, AV11cSolicitudesItemsCantidad, AV15cSolicitudItemsComision, AV16cSolicitudItemsSR, AV17cSolicitudItemsComisionTipo, AV12pSolicitudesID) ;
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
         PAAA2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            STARTAA2( ) ;
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("gx00v1.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(AV12pSolicitudesID,18,0)),UrlEncode(StringUtil.LTrimStr(AV13pSolicitudesItemsID,4,0))}, new string[] {"pSolicitudesID","pSolicitudesItemsID"}) +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "GXH_vCSOLICITUDESITEMSID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV6cSolicitudesItemsID), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GXH_vCSOLICITUDESITEMSPRECIOFINAL", StringUtil.LTrim( StringUtil.NToC( AV10cSolicitudesItemsPrecioFinal, 18, 2, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GXH_vCSOLICITUDESITEMSCANTIDAD", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV11cSolicitudesItemsCantidad), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GXH_vCSOLICITUDITEMSCOMISION", StringUtil.LTrim( StringUtil.NToC( AV15cSolicitudItemsComision, 18, 2, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GXH_vCSOLICITUDITEMSSR", StringUtil.RTrim( AV16cSolicitudItemsSR));
         GxWebStd.gx_hidden_field( context, "GXH_vCSOLICITUDITEMSCOMISIONTIPO", StringUtil.RTrim( AV17cSolicitudItemsComisionTipo));
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_74", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_74), 8, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vPSOLICITUDESID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV12pSolicitudesID), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vPSOLICITUDESITEMSID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV13pSolicitudesItemsID), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nFirstRecordOnPage), 15, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GRID1_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nEOF), 1, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "ADVANCEDCONTAINER_Class", StringUtil.RTrim( divAdvancedcontainer_Class));
         GxWebStd.gx_hidden_field( context, "BTNTOGGLE_Class", StringUtil.RTrim( bttBtntoggle_Class));
         GxWebStd.gx_hidden_field( context, "SOLICITUDESITEMSIDFILTERCONTAINER_Class", StringUtil.RTrim( divSolicitudesitemsidfiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "SOLICITUDESITEMSPRECIOFINALFILTERCONTAINER_Class", StringUtil.RTrim( divSolicitudesitemspreciofinalfiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "SOLICITUDESITEMSCANTIDADFILTERCONTAINER_Class", StringUtil.RTrim( divSolicitudesitemscantidadfiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "SOLICITUDITEMSCOMISIONFILTERCONTAINER_Class", StringUtil.RTrim( divSolicituditemscomisionfiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "SOLICITUDITEMSSRFILTERCONTAINER_Class", StringUtil.RTrim( divSolicituditemssrfiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "SOLICITUDITEMSCOMISIONTIPOFILTERCONTAINER_Class", StringUtil.RTrim( divSolicituditemscomisiontipofiltercontainer_Class));
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
            WEAA2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVTAA2( ) ;
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
         return formatLink("gx00v1.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(AV12pSolicitudesID,18,0)),UrlEncode(StringUtil.LTrimStr(AV13pSolicitudesItemsID,4,0))}, new string[] {"pSolicitudesID","pSolicitudesItemsID"})  ;
      }

      public override string GetPgmname( )
      {
         return "Gx00V1" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "Selection List Items", "") ;
      }

      protected void WBAA0( )
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
            GxWebStd.gx_div_start( context, divSolicitudesitemsidfiltercontainer_Internalname, 1, 0, "px", 0, "px", divSolicitudesitemsidfiltercontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblsolicitudesitemsidfilter_Internalname, context.GetMessage( "No.", ""), "", "", lblLblsolicitudesitemsidfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e11aa1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx00V1.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCsolicitudesitemsid_Internalname, context.GetMessage( "No.", ""), "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 16,'',false,'" + sGXsfl_74_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCsolicitudesitemsid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV6cSolicitudesItemsID), 4, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtavCsolicitudesitemsid_Enabled!=0) ? context.localUtil.Format( (decimal)(AV6cSolicitudesItemsID), "ZZZ9") : context.localUtil.Format( (decimal)(AV6cSolicitudesItemsID), "ZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,16);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCsolicitudesitemsid_Jsonclick, 0, "Attribute", "", "", "", "", edtavCsolicitudesitemsid_Visible, edtavCsolicitudesitemsid_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Gx00V1.htm");
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
            GxWebStd.gx_div_start( context, divSolicitudesitemspreciofinalfiltercontainer_Internalname, 1, 0, "px", 0, "px", divSolicitudesitemspreciofinalfiltercontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblsolicitudesitemspreciofinalfilter_Internalname, context.GetMessage( "Precio", ""), "", "", lblLblsolicitudesitemspreciofinalfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e12aa1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx00V1.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCsolicitudesitemspreciofinal_Internalname, context.GetMessage( "Precio", ""), "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 26,'',false,'" + sGXsfl_74_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCsolicitudesitemspreciofinal_Internalname, StringUtil.LTrim( StringUtil.NToC( AV10cSolicitudesItemsPrecioFinal, 18, 2, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtavCsolicitudesitemspreciofinal_Enabled!=0) ? context.localUtil.Format( AV10cSolicitudesItemsPrecioFinal, "ZZZZZZZZZZZZZZ9.99") : context.localUtil.Format( AV10cSolicitudesItemsPrecioFinal, "ZZZZZZZZZZZZZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onblur(this,26);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCsolicitudesitemspreciofinal_Jsonclick, 0, "Attribute", "", "", "", "", edtavCsolicitudesitemspreciofinal_Visible, edtavCsolicitudesitemspreciofinal_Enabled, 0, "text", "", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Gx00V1.htm");
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
            GxWebStd.gx_div_start( context, divSolicitudesitemscantidadfiltercontainer_Internalname, 1, 0, "px", 0, "px", divSolicitudesitemscantidadfiltercontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblsolicitudesitemscantidadfilter_Internalname, context.GetMessage( "Cantidad", ""), "", "", lblLblsolicitudesitemscantidadfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e13aa1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx00V1.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCsolicitudesitemscantidad_Internalname, context.GetMessage( "Cantidad", ""), "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 36,'',false,'" + sGXsfl_74_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCsolicitudesitemscantidad_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV11cSolicitudesItemsCantidad), 4, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtavCsolicitudesitemscantidad_Enabled!=0) ? context.localUtil.Format( (decimal)(AV11cSolicitudesItemsCantidad), "ZZZ9") : context.localUtil.Format( (decimal)(AV11cSolicitudesItemsCantidad), "ZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,36);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCsolicitudesitemscantidad_Jsonclick, 0, "Attribute", "", "", "", "", edtavCsolicitudesitemscantidad_Visible, edtavCsolicitudesitemscantidad_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Gx00V1.htm");
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
            GxWebStd.gx_div_start( context, divSolicituditemscomisionfiltercontainer_Internalname, 1, 0, "px", 0, "px", divSolicituditemscomisionfiltercontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblsolicituditemscomisionfilter_Internalname, context.GetMessage( "Comision", ""), "", "", lblLblsolicituditemscomisionfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e14aa1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx00V1.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCsolicituditemscomision_Internalname, context.GetMessage( "Comision", ""), "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 46,'',false,'" + sGXsfl_74_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCsolicituditemscomision_Internalname, StringUtil.LTrim( StringUtil.NToC( AV15cSolicitudItemsComision, 18, 2, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtavCsolicituditemscomision_Enabled!=0) ? context.localUtil.Format( AV15cSolicitudItemsComision, "ZZZZZZZZZZZZZZ9.99") : context.localUtil.Format( AV15cSolicitudItemsComision, "ZZZZZZZZZZZZZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onblur(this,46);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCsolicituditemscomision_Jsonclick, 0, "Attribute", "", "", "", "", edtavCsolicituditemscomision_Visible, edtavCsolicituditemscomision_Enabled, 0, "text", "", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Gx00V1.htm");
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
            GxWebStd.gx_div_start( context, divSolicituditemssrfiltercontainer_Internalname, 1, 0, "px", 0, "px", divSolicituditemssrfiltercontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblsolicituditemssrfilter_Internalname, context.GetMessage( "Accion", ""), "", "", lblLblsolicituditemssrfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e15aa1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx00V1.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavCsolicituditemssr_Internalname, context.GetMessage( "Accion", ""), "col-sm-3 AttributeLabel", 0, true, "");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 56,'',false,'" + sGXsfl_74_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavCsolicituditemssr, cmbavCsolicituditemssr_Internalname, StringUtil.RTrim( AV16cSolicitudItemsSR), 1, cmbavCsolicituditemssr_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "char", "", cmbavCsolicituditemssr.Visible, cmbavCsolicituditemssr.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,56);\"", "", true, 0, "HLP_Gx00V1.htm");
            cmbavCsolicituditemssr.CurrentValue = StringUtil.RTrim( AV16cSolicitudItemsSR);
            AssignProp("", false, cmbavCsolicituditemssr_Internalname, "Values", (string)(cmbavCsolicituditemssr.ToJavascriptSource()), true);
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
            GxWebStd.gx_div_start( context, divSolicituditemscomisiontipofiltercontainer_Internalname, 1, 0, "px", 0, "px", divSolicituditemscomisiontipofiltercontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblsolicituditemscomisiontipofilter_Internalname, context.GetMessage( "Comisión Tipo", ""), "", "", lblLblsolicituditemscomisiontipofilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e16aa1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx00V1.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCsolicituditemscomisiontipo_Internalname, context.GetMessage( "Comisión Tipo", ""), "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 66,'',false,'" + sGXsfl_74_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCsolicituditemscomisiontipo_Internalname, StringUtil.RTrim( AV17cSolicitudItemsComisionTipo), StringUtil.RTrim( context.localUtil.Format( AV17cSolicitudItemsComisionTipo, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,66);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCsolicituditemscomisiontipo_Jsonclick, 0, "Attribute", "", "", "", "", edtavCsolicituditemscomisiontipo_Visible, edtavCsolicituditemscomisiontipo_Enabled, 0, "text", "", 1, "chr", 1, "row", 1, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Gx00V1.htm");
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
            GxWebStd.gx_button_ctrl( context, bttBtntoggle_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(74), 2, 0)+","+"null"+");", "|||", bttBtntoggle_Jsonclick, 7, "|||", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"e17aa1_client"+"'", TempTags, "", 2, "HLP_Gx00V1.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 89,'',false,'',0)\"";
            ClassString = "BtnCancel";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(74), 2, 0)+","+"null"+");", context.GetMessage( "GX_BtnCancel", ""), bttBtn_cancel_Jsonclick, 1, context.GetMessage( "GX_BtnCancel", ""), "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Gx00V1.htm");
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

      protected void STARTAA2( )
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
         STRUPAA0( ) ;
      }

      protected void WSAA2( )
      {
         STARTAA2( ) ;
         EVTAA2( ) ;
      }

      protected void EVTAA2( )
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
                              AssignProp("", false, edtavLinkselection_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV5LinkSelection)) ? AV18Linkselection_GXI : context.convertURL( context.PathToRelativeUrl( AV5LinkSelection))), !bGXsfl_74_Refreshing);
                              AssignProp("", false, edtavLinkselection_Internalname, "SrcSet", context.GetImageSrcSet( AV5LinkSelection), true);
                              A134SolicitudesItemsID = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtSolicitudesItemsID_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                              A176SolicitudesItemsPrecioFinal = context.localUtil.CToN( cgiGet( edtSolicitudesItemsPrecioFinal_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
                              n176SolicitudesItemsPrecioFinal = false;
                              A177SolicitudesItemsCantidad = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtSolicitudesItemsCantidad_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                              A180SolicitudItemsComision = context.localUtil.CToN( cgiGet( edtSolicitudItemsComision_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
                              cmbSolicitudItemsSR.Name = cmbSolicitudItemsSR_Internalname;
                              cmbSolicitudItemsSR.CurrentValue = cgiGet( cmbSolicitudItemsSR_Internalname);
                              A178SolicitudItemsSR = cgiGet( cmbSolicitudItemsSR_Internalname);
                              A179SolicitudItemsComisionTipo = cgiGet( edtSolicitudItemsComisionTipo_Internalname);
                              A524SolicitudesItemsComiProvP = context.localUtil.CToN( cgiGet( edtSolicitudesItemsComiProvP_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
                              n524SolicitudesItemsComiProvP = false;
                              A523SolicitudesItemsComiALM = context.localUtil.CToN( cgiGet( edtSolicitudesItemsComiALM_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
                              n523SolicitudesItemsComiALM = false;
                              A526SolicitudesItemsComiALMP = context.localUtil.CToN( cgiGet( edtSolicitudesItemsComiALMP_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
                              n526SolicitudesItemsComiALMP = false;
                              A521SolicitudesItemsComiProv = context.localUtil.CToN( cgiGet( edtSolicitudesItemsComiProv_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
                              n521SolicitudesItemsComiProv = false;
                              A127SolicitudesID = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtSolicitudesID_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E18AA2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Load */
                                    E19AA2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    if ( ! wbErr )
                                    {
                                       Rfr0gs = false;
                                       /* Set Refresh If Csolicitudesitemsid Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vCSOLICITUDESITEMSID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != Convert.ToDecimal( AV6cSolicitudesItemsID )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Csolicitudesitemspreciofinal Changed */
                                       if ( context.localUtil.CToN( cgiGet( "GXH_vCSOLICITUDESITEMSPRECIOFINAL"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != AV10cSolicitudesItemsPrecioFinal )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Csolicitudesitemscantidad Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vCSOLICITUDESITEMSCANTIDAD"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != Convert.ToDecimal( AV11cSolicitudesItemsCantidad )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Csolicituditemscomision Changed */
                                       if ( context.localUtil.CToN( cgiGet( "GXH_vCSOLICITUDITEMSCOMISION"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != AV15cSolicitudItemsComision )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Csolicituditemssr Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCSOLICITUDITEMSSR"), AV16cSolicitudItemsSR) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Csolicituditemscomisiontipo Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCSOLICITUDITEMSCOMISIONTIPO"), AV17cSolicitudItemsComisionTipo) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       if ( ! Rfr0gs )
                                       {
                                          /* Execute user event: Enter */
                                          E20AA2 ();
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

      protected void WEAA2( )
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

      protected void PAAA2( )
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
                                        short AV6cSolicitudesItemsID ,
                                        decimal AV10cSolicitudesItemsPrecioFinal ,
                                        short AV11cSolicitudesItemsCantidad ,
                                        decimal AV15cSolicitudItemsComision ,
                                        string AV16cSolicitudItemsSR ,
                                        string AV17cSolicitudItemsComisionTipo ,
                                        long AV12pSolicitudesID )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID1_nCurrentRecord = 0;
         RFAA2( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGrid1_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_SOLICITUDESITEMSID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(A134SolicitudesItemsID), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "SOLICITUDESITEMSID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A134SolicitudesItemsID), 4, 0, ".", "")));
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
         if ( cmbavCsolicituditemssr.ItemCount > 0 )
         {
            AV16cSolicitudItemsSR = cmbavCsolicituditemssr.getValidValue(AV16cSolicitudItemsSR);
            AssignAttri("", false, "AV16cSolicitudItemsSR", AV16cSolicitudItemsSR);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavCsolicituditemssr.CurrentValue = StringUtil.RTrim( AV16cSolicitudItemsSR);
            AssignProp("", false, cmbavCsolicituditemssr_Internalname, "Values", cmbavCsolicituditemssr.ToJavascriptSource(), true);
         }
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RFAA2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
      }

      protected void RFAA2( )
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
                                                 AV10cSolicitudesItemsPrecioFinal ,
                                                 AV11cSolicitudesItemsCantidad ,
                                                 AV15cSolicitudItemsComision ,
                                                 AV16cSolicitudItemsSR ,
                                                 AV17cSolicitudItemsComisionTipo ,
                                                 A176SolicitudesItemsPrecioFinal ,
                                                 A177SolicitudesItemsCantidad ,
                                                 A180SolicitudItemsComision ,
                                                 A178SolicitudItemsSR ,
                                                 A179SolicitudItemsComisionTipo ,
                                                 AV12pSolicitudesID ,
                                                 AV6cSolicitudesItemsID ,
                                                 A127SolicitudesID } ,
                                                 new int[]{
                                                 TypeConstants.DECIMAL, TypeConstants.SHORT, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.DECIMAL, TypeConstants.LONG, TypeConstants.SHORT, TypeConstants.LONG
                                                 }
            });
            lV16cSolicitudItemsSR = StringUtil.PadR( StringUtil.RTrim( AV16cSolicitudItemsSR), 1, "%");
            lV17cSolicitudItemsComisionTipo = StringUtil.PadR( StringUtil.RTrim( AV17cSolicitudItemsComisionTipo), 1, "%");
            /* Using cursor H00AA2 */
            pr_default.execute(0, new Object[] {AV12pSolicitudesID, AV6cSolicitudesItemsID, AV10cSolicitudesItemsPrecioFinal, AV11cSolicitudesItemsCantidad, AV15cSolicitudItemsComision, lV16cSolicitudItemsSR, lV17cSolicitudItemsComisionTipo, GXPagingFrom2, GXPagingTo2, GXPagingTo2});
            nGXsfl_74_idx = 1;
            sGXsfl_74_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_74_idx), 4, 0), 4, "0");
            SubsflControlProps_742( ) ;
            while ( ( (pr_default.getStatus(0) != 101) ) && ( ( GRID1_nCurrentRecord < subGrid1_fnc_Recordsperpage( ) ) ) )
            {
               A127SolicitudesID = H00AA2_A127SolicitudesID[0];
               A521SolicitudesItemsComiProv = H00AA2_A521SolicitudesItemsComiProv[0];
               n521SolicitudesItemsComiProv = H00AA2_n521SolicitudesItemsComiProv[0];
               A526SolicitudesItemsComiALMP = H00AA2_A526SolicitudesItemsComiALMP[0];
               n526SolicitudesItemsComiALMP = H00AA2_n526SolicitudesItemsComiALMP[0];
               A523SolicitudesItemsComiALM = H00AA2_A523SolicitudesItemsComiALM[0];
               n523SolicitudesItemsComiALM = H00AA2_n523SolicitudesItemsComiALM[0];
               A524SolicitudesItemsComiProvP = H00AA2_A524SolicitudesItemsComiProvP[0];
               n524SolicitudesItemsComiProvP = H00AA2_n524SolicitudesItemsComiProvP[0];
               A179SolicitudItemsComisionTipo = H00AA2_A179SolicitudItemsComisionTipo[0];
               A178SolicitudItemsSR = H00AA2_A178SolicitudItemsSR[0];
               A180SolicitudItemsComision = H00AA2_A180SolicitudItemsComision[0];
               A177SolicitudesItemsCantidad = H00AA2_A177SolicitudesItemsCantidad[0];
               A176SolicitudesItemsPrecioFinal = H00AA2_A176SolicitudesItemsPrecioFinal[0];
               n176SolicitudesItemsPrecioFinal = H00AA2_n176SolicitudesItemsPrecioFinal[0];
               A134SolicitudesItemsID = H00AA2_A134SolicitudesItemsID[0];
               /* Execute user event: Load */
               E19AA2 ();
               pr_default.readNext(0);
            }
            GRID1_nEOF = (short)(((pr_default.getStatus(0) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRID1_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nEOF), 1, 0, ".", "")));
            pr_default.close(0);
            wbEnd = 74;
            WBAA0( ) ;
         }
         bGXsfl_74_Refreshing = true;
      }

      protected void send_integrity_lvl_hashesAA2( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_SOLICITUDESITEMSID"+"_"+sGXsfl_74_idx, GetSecureSignedToken( sGXsfl_74_idx, context.localUtil.Format( (decimal)(A134SolicitudesItemsID), "ZZZ9"), context));
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
                                              AV10cSolicitudesItemsPrecioFinal ,
                                              AV11cSolicitudesItemsCantidad ,
                                              AV15cSolicitudItemsComision ,
                                              AV16cSolicitudItemsSR ,
                                              AV17cSolicitudItemsComisionTipo ,
                                              A176SolicitudesItemsPrecioFinal ,
                                              A177SolicitudesItemsCantidad ,
                                              A180SolicitudItemsComision ,
                                              A178SolicitudItemsSR ,
                                              A179SolicitudItemsComisionTipo ,
                                              AV12pSolicitudesID ,
                                              AV6cSolicitudesItemsID ,
                                              A127SolicitudesID } ,
                                              new int[]{
                                              TypeConstants.DECIMAL, TypeConstants.SHORT, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.DECIMAL, TypeConstants.LONG, TypeConstants.SHORT, TypeConstants.LONG
                                              }
         });
         lV16cSolicitudItemsSR = StringUtil.PadR( StringUtil.RTrim( AV16cSolicitudItemsSR), 1, "%");
         lV17cSolicitudItemsComisionTipo = StringUtil.PadR( StringUtil.RTrim( AV17cSolicitudItemsComisionTipo), 1, "%");
         /* Using cursor H00AA3 */
         pr_default.execute(1, new Object[] {AV12pSolicitudesID, AV6cSolicitudesItemsID, AV10cSolicitudesItemsPrecioFinal, AV11cSolicitudesItemsCantidad, AV15cSolicitudItemsComision, lV16cSolicitudItemsSR, lV17cSolicitudItemsComisionTipo});
         GRID1_nRecordCount = H00AA3_AGRID1_nRecordCount[0];
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cSolicitudesItemsID, AV10cSolicitudesItemsPrecioFinal, AV11cSolicitudesItemsCantidad, AV15cSolicitudItemsComision, AV16cSolicitudItemsSR, AV17cSolicitudItemsComisionTipo, AV12pSolicitudesID) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cSolicitudesItemsID, AV10cSolicitudesItemsPrecioFinal, AV11cSolicitudesItemsCantidad, AV15cSolicitudItemsComision, AV16cSolicitudItemsSR, AV17cSolicitudItemsComisionTipo, AV12pSolicitudesID) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cSolicitudesItemsID, AV10cSolicitudesItemsPrecioFinal, AV11cSolicitudesItemsCantidad, AV15cSolicitudItemsComision, AV16cSolicitudItemsSR, AV17cSolicitudItemsComisionTipo, AV12pSolicitudesID) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cSolicitudesItemsID, AV10cSolicitudesItemsPrecioFinal, AV11cSolicitudesItemsCantidad, AV15cSolicitudItemsComision, AV16cSolicitudItemsSR, AV17cSolicitudItemsComisionTipo, AV12pSolicitudesID) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cSolicitudesItemsID, AV10cSolicitudesItemsPrecioFinal, AV11cSolicitudesItemsCantidad, AV15cSolicitudItemsComision, AV16cSolicitudItemsSR, AV17cSolicitudItemsComisionTipo, AV12pSolicitudesID) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         edtSolicitudesItemsID_Enabled = 0;
         edtSolicitudesItemsPrecioFinal_Enabled = 0;
         edtSolicitudesItemsCantidad_Enabled = 0;
         edtSolicitudItemsComision_Enabled = 0;
         cmbSolicitudItemsSR.Enabled = 0;
         edtSolicitudItemsComisionTipo_Enabled = 0;
         edtSolicitudesItemsComiProvP_Enabled = 0;
         edtSolicitudesItemsComiALM_Enabled = 0;
         edtSolicitudesItemsComiALMP_Enabled = 0;
         edtSolicitudesItemsComiProv_Enabled = 0;
         edtSolicitudesID_Enabled = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUPAA0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E18AA2 ();
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
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCsolicitudesitemsid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCsolicitudesitemsid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCSOLICITUDESITEMSID");
               GX_FocusControl = edtavCsolicitudesitemsid_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV6cSolicitudesItemsID = 0;
               AssignAttri("", false, "AV6cSolicitudesItemsID", StringUtil.LTrimStr( (decimal)(AV6cSolicitudesItemsID), 4, 0));
            }
            else
            {
               AV6cSolicitudesItemsID = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtavCsolicitudesitemsid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV6cSolicitudesItemsID", StringUtil.LTrimStr( (decimal)(AV6cSolicitudesItemsID), 4, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCsolicitudesitemspreciofinal_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCsolicitudesitemspreciofinal_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > 999999999999999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCSOLICITUDESITEMSPRECIOFINAL");
               GX_FocusControl = edtavCsolicitudesitemspreciofinal_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV10cSolicitudesItemsPrecioFinal = 0;
               AssignAttri("", false, "AV10cSolicitudesItemsPrecioFinal", StringUtil.LTrimStr( AV10cSolicitudesItemsPrecioFinal, 18, 2));
            }
            else
            {
               AV10cSolicitudesItemsPrecioFinal = context.localUtil.CToN( cgiGet( edtavCsolicitudesitemspreciofinal_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
               AssignAttri("", false, "AV10cSolicitudesItemsPrecioFinal", StringUtil.LTrimStr( AV10cSolicitudesItemsPrecioFinal, 18, 2));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCsolicitudesitemscantidad_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCsolicitudesitemscantidad_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCSOLICITUDESITEMSCANTIDAD");
               GX_FocusControl = edtavCsolicitudesitemscantidad_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV11cSolicitudesItemsCantidad = 0;
               AssignAttri("", false, "AV11cSolicitudesItemsCantidad", StringUtil.LTrimStr( (decimal)(AV11cSolicitudesItemsCantidad), 4, 0));
            }
            else
            {
               AV11cSolicitudesItemsCantidad = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtavCsolicitudesitemscantidad_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV11cSolicitudesItemsCantidad", StringUtil.LTrimStr( (decimal)(AV11cSolicitudesItemsCantidad), 4, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCsolicituditemscomision_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCsolicituditemscomision_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > 999999999999999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCSOLICITUDITEMSCOMISION");
               GX_FocusControl = edtavCsolicituditemscomision_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV15cSolicitudItemsComision = 0;
               AssignAttri("", false, "AV15cSolicitudItemsComision", StringUtil.LTrimStr( AV15cSolicitudItemsComision, 18, 2));
            }
            else
            {
               AV15cSolicitudItemsComision = context.localUtil.CToN( cgiGet( edtavCsolicituditemscomision_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
               AssignAttri("", false, "AV15cSolicitudItemsComision", StringUtil.LTrimStr( AV15cSolicitudItemsComision, 18, 2));
            }
            cmbavCsolicituditemssr.Name = cmbavCsolicituditemssr_Internalname;
            cmbavCsolicituditemssr.CurrentValue = cgiGet( cmbavCsolicituditemssr_Internalname);
            AV16cSolicitudItemsSR = cgiGet( cmbavCsolicituditemssr_Internalname);
            AssignAttri("", false, "AV16cSolicitudItemsSR", AV16cSolicitudItemsSR);
            AV17cSolicitudItemsComisionTipo = cgiGet( edtavCsolicituditemscomisiontipo_Internalname);
            AssignAttri("", false, "AV17cSolicitudItemsComisionTipo", AV17cSolicitudItemsComisionTipo);
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            /* Check if conditions changed and reset current page numbers */
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vCSOLICITUDESITEMSID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != Convert.ToDecimal( AV6cSolicitudesItemsID )) )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( context.localUtil.CToN( cgiGet( "GXH_vCSOLICITUDESITEMSPRECIOFINAL"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != AV10cSolicitudesItemsPrecioFinal )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vCSOLICITUDESITEMSCANTIDAD"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != Convert.ToDecimal( AV11cSolicitudesItemsCantidad )) )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( context.localUtil.CToN( cgiGet( "GXH_vCSOLICITUDITEMSCOMISION"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != AV15cSolicitudItemsComision )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCSOLICITUDITEMSSR"), AV16cSolicitudItemsSR) != 0 )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCSOLICITUDITEMSCOMISIONTIPO"), AV17cSolicitudItemsComisionTipo) != 0 )
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
         E18AA2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E18AA2( )
      {
         /* Start Routine */
         returnInSub = false;
         Form.Caption = StringUtil.Format( context.GetMessage( "GXSPC_SelectionList", ""), context.GetMessage( "Items", ""), "", "", "", "", "", "", "", "");
         AssignProp("", false, "FORM", "Caption", Form.Caption, true);
         AV14ADVANCED_LABEL_TEMPLATE = context.GetMessage( "%1 <strong>%2</strong>", "");
      }

      private void E19AA2( )
      {
         /* Load Routine */
         returnInSub = false;
         edtavLinkselection_gximage = "SelectRow";
         AV5LinkSelection = context.GetImagePath( "3914535b-0c03-44c5-9538-906a99cdd2bc", "", context.GetTheme( ));
         AssignAttri("", false, edtavLinkselection_Internalname, AV5LinkSelection);
         AV18Linkselection_GXI = GXDbFile.PathToUrl( context.GetImagePath( "3914535b-0c03-44c5-9538-906a99cdd2bc", "", context.GetTheme( )), context);
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
         E20AA2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E20AA2( )
      {
         /* Enter Routine */
         returnInSub = false;
         AV13pSolicitudesItemsID = A134SolicitudesItemsID;
         AssignAttri("", false, "AV13pSolicitudesItemsID", StringUtil.LTrimStr( (decimal)(AV13pSolicitudesItemsID), 4, 0));
         context.setWebReturnParms(new Object[] {(short)AV13pSolicitudesItemsID});
         context.setWebReturnParmsMetadata(new Object[] {"AV13pSolicitudesItemsID"});
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
         AV12pSolicitudesID = Convert.ToInt64(getParm(obj,0));
         AssignAttri("", false, "AV12pSolicitudesID", StringUtil.LTrimStr( (decimal)(AV12pSolicitudesID), 18, 0));
         AV13pSolicitudesItemsID = Convert.ToInt16(getParm(obj,1));
         AssignAttri("", false, "AV13pSolicitudesItemsID", StringUtil.LTrimStr( (decimal)(AV13pSolicitudesItemsID), 4, 0));
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
         PAAA2( ) ;
         WSAA2( ) ;
         WEAA2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20267302126958", true, true, false);
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
         context.AddJavascriptSource("gx00v1.js", "?20267302126959", false, true, false);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_742( )
      {
         edtavLinkselection_Internalname = "vLINKSELECTION_"+sGXsfl_74_idx;
         edtSolicitudesItemsID_Internalname = "SOLICITUDESITEMSID_"+sGXsfl_74_idx;
         edtSolicitudesItemsPrecioFinal_Internalname = "SOLICITUDESITEMSPRECIOFINAL_"+sGXsfl_74_idx;
         edtSolicitudesItemsCantidad_Internalname = "SOLICITUDESITEMSCANTIDAD_"+sGXsfl_74_idx;
         edtSolicitudItemsComision_Internalname = "SOLICITUDITEMSCOMISION_"+sGXsfl_74_idx;
         cmbSolicitudItemsSR_Internalname = "SOLICITUDITEMSSR_"+sGXsfl_74_idx;
         edtSolicitudItemsComisionTipo_Internalname = "SOLICITUDITEMSCOMISIONTIPO_"+sGXsfl_74_idx;
         edtSolicitudesItemsComiProvP_Internalname = "SOLICITUDESITEMSCOMIPROVP_"+sGXsfl_74_idx;
         edtSolicitudesItemsComiALM_Internalname = "SOLICITUDESITEMSCOMIALM_"+sGXsfl_74_idx;
         edtSolicitudesItemsComiALMP_Internalname = "SOLICITUDESITEMSCOMIALMP_"+sGXsfl_74_idx;
         edtSolicitudesItemsComiProv_Internalname = "SOLICITUDESITEMSCOMIPROV_"+sGXsfl_74_idx;
         edtSolicitudesID_Internalname = "SOLICITUDESID_"+sGXsfl_74_idx;
      }

      protected void SubsflControlProps_fel_742( )
      {
         edtavLinkselection_Internalname = "vLINKSELECTION_"+sGXsfl_74_fel_idx;
         edtSolicitudesItemsID_Internalname = "SOLICITUDESITEMSID_"+sGXsfl_74_fel_idx;
         edtSolicitudesItemsPrecioFinal_Internalname = "SOLICITUDESITEMSPRECIOFINAL_"+sGXsfl_74_fel_idx;
         edtSolicitudesItemsCantidad_Internalname = "SOLICITUDESITEMSCANTIDAD_"+sGXsfl_74_fel_idx;
         edtSolicitudItemsComision_Internalname = "SOLICITUDITEMSCOMISION_"+sGXsfl_74_fel_idx;
         cmbSolicitudItemsSR_Internalname = "SOLICITUDITEMSSR_"+sGXsfl_74_fel_idx;
         edtSolicitudItemsComisionTipo_Internalname = "SOLICITUDITEMSCOMISIONTIPO_"+sGXsfl_74_fel_idx;
         edtSolicitudesItemsComiProvP_Internalname = "SOLICITUDESITEMSCOMIPROVP_"+sGXsfl_74_fel_idx;
         edtSolicitudesItemsComiALM_Internalname = "SOLICITUDESITEMSCOMIALM_"+sGXsfl_74_fel_idx;
         edtSolicitudesItemsComiALMP_Internalname = "SOLICITUDESITEMSCOMIALMP_"+sGXsfl_74_fel_idx;
         edtSolicitudesItemsComiProv_Internalname = "SOLICITUDESITEMSCOMIPROV_"+sGXsfl_74_fel_idx;
         edtSolicitudesID_Internalname = "SOLICITUDESID_"+sGXsfl_74_fel_idx;
      }

      protected void sendrow_742( )
      {
         sGXsfl_74_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_74_idx), 4, 0), 4, "0");
         SubsflControlProps_742( ) ;
         WBAA0( ) ;
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
            edtavLinkselection_Link = "javascript:gx.popup.gxReturn(["+"'"+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A134SolicitudesItemsID), 4, 0, context.GetLanguageProperty( "decimal_point"), "")))+"'"+"]);";
            AssignProp("", false, edtavLinkselection_Internalname, "Link", edtavLinkselection_Link, !bGXsfl_74_Refreshing);
            ClassString = "SelectionAttribute" + " " + ((StringUtil.StrCmp(edtavLinkselection_gximage, "")==0) ? "" : "GX_Image_"+edtavLinkselection_gximage+"_Class");
            StyleString = "";
            AV5LinkSelection_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( AV5LinkSelection))&&String.IsNullOrEmpty(StringUtil.RTrim( AV18Linkselection_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( AV5LinkSelection)));
            sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV5LinkSelection)) ? AV18Linkselection_GXI : context.PathToRelativeUrl( AV5LinkSelection));
            Grid1Row.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(string)edtavLinkselection_Internalname,(string)sImgUrl,(string)edtavLinkselection_Link,(string)"",(string)"",context.GetTheme( ),(short)-1,(short)1,(string)"",(string)"",(short)0,(short)-1,(short)0,(string)"px",(short)0,(string)"px",(short)0,(short)0,(short)0,(string)"",(string)"",(string)StyleString,(string)ClassString,(string)"WWActionColumn",(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(short)1,(bool)AV5LinkSelection_IsBlob,(bool)false,context.GetImageSrcSet( sImgUrl),(string)"none"});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            edtSolicitudesItemsID_Link = "javascript:gx.popup.gxReturn(["+"'"+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A134SolicitudesItemsID), 4, 0, context.GetLanguageProperty( "decimal_point"), "")))+"'"+"]);";
            AssignProp("", false, edtSolicitudesItemsID_Internalname, "Link", edtSolicitudesItemsID_Link, !bGXsfl_74_Refreshing);
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSolicitudesItemsID_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A134SolicitudesItemsID), 4, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A134SolicitudesItemsID), "ZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtSolicitudesItemsID_Link,(string)"",(string)"",(string)"",(string)edtSolicitudesItemsID_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)74,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSolicitudesItemsPrecioFinal_Internalname,StringUtil.LTrim( StringUtil.NToC( A176SolicitudesItemsPrecioFinal, 18, 2, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( A176SolicitudesItemsPrecioFinal, "ZZZZZZZZZZZZZZ9.99")),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtSolicitudesItemsPrecioFinal_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn OptionalColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)74,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSolicitudesItemsCantidad_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A177SolicitudesItemsCantidad), 4, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A177SolicitudesItemsCantidad), "ZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtSolicitudesItemsCantidad_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn OptionalColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)74,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSolicitudItemsComision_Internalname,StringUtil.LTrim( StringUtil.NToC( A180SolicitudItemsComision, 18, 2, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( A180SolicitudItemsComision, "ZZZZZZZZZZZZZZ9.99")),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtSolicitudItemsComision_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn OptionalColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)74,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            if ( ( cmbSolicitudItemsSR.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "SOLICITUDITEMSSR_" + sGXsfl_74_idx;
               cmbSolicitudItemsSR.Name = GXCCtl;
               cmbSolicitudItemsSR.WebTags = "";
               cmbSolicitudItemsSR.addItem("S", context.GetMessage( "Suma", ""), 0);
               cmbSolicitudItemsSR.addItem("R", context.GetMessage( "Resta", ""), 0);
               if ( cmbSolicitudItemsSR.ItemCount > 0 )
               {
                  A178SolicitudItemsSR = cmbSolicitudItemsSR.getValidValue(A178SolicitudItemsSR);
               }
            }
            /* ComboBox */
            Grid1Row.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbSolicitudItemsSR,(string)cmbSolicitudItemsSR_Internalname,StringUtil.RTrim( A178SolicitudItemsSR),(short)1,(string)cmbSolicitudItemsSR_Jsonclick,(short)0,(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"char",(string)"",(short)-1,(short)0,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)"WWColumn OptionalColumn",(string)"",(string)"",(string)"",(bool)true,(short)0});
            cmbSolicitudItemsSR.CurrentValue = StringUtil.RTrim( A178SolicitudItemsSR);
            AssignProp("", false, cmbSolicitudItemsSR_Internalname, "Values", (string)(cmbSolicitudItemsSR.ToJavascriptSource()), !bGXsfl_74_Refreshing);
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSolicitudItemsComisionTipo_Internalname,StringUtil.RTrim( A179SolicitudItemsComisionTipo),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtSolicitudItemsComisionTipo_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn OptionalColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)1,(short)0,(short)0,(short)74,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSolicitudesItemsComiProvP_Internalname,StringUtil.LTrim( StringUtil.NToC( A524SolicitudesItemsComiProvP, 6, 2, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( A524SolicitudesItemsComiProvP, "ZZ9.99")),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtSolicitudesItemsComiProvP_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn OptionalColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)6,(short)0,(short)0,(short)74,(short)0,(short)-1,(short)0,(bool)true,(string)"Porcentaje",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSolicitudesItemsComiALM_Internalname,StringUtil.LTrim( StringUtil.NToC( A523SolicitudesItemsComiALM, 18, 2, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( A523SolicitudesItemsComiALM, "ZZZZZZZZZZZZZZ9.99")),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtSolicitudesItemsComiALM_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn OptionalColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)74,(short)0,(short)-1,(short)0,(bool)true,(string)"Comision",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSolicitudesItemsComiALMP_Internalname,StringUtil.LTrim( StringUtil.NToC( A526SolicitudesItemsComiALMP, 6, 2, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( A526SolicitudesItemsComiALMP, "ZZ9.99")),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtSolicitudesItemsComiALMP_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn OptionalColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)6,(short)0,(short)0,(short)74,(short)0,(short)-1,(short)0,(bool)true,(string)"Porcentaje",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSolicitudesItemsComiProv_Internalname,StringUtil.LTrim( StringUtil.NToC( A521SolicitudesItemsComiProv, 18, 2, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( A521SolicitudesItemsComiProv, "ZZZZZZZZZZZZZZ9.99")),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtSolicitudesItemsComiProv_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn OptionalColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)74,(short)0,(short)-1,(short)0,(bool)true,(string)"Comision",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSolicitudesID_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A127SolicitudesID), 18, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A127SolicitudesID), "ZZZZZZZZZZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtSolicitudesID_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)74,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            send_integrity_lvl_hashesAA2( ) ;
            Grid1Container.AddRow(Grid1Row);
            nGXsfl_74_idx = ((subGrid1_Islastpage==1)&&(nGXsfl_74_idx+1>subGrid1_fnc_Recordsperpage( )) ? 1 : nGXsfl_74_idx+1);
            sGXsfl_74_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_74_idx), 4, 0), 4, "0");
            SubsflControlProps_742( ) ;
         }
         /* End function sendrow_742 */
      }

      protected void init_web_controls( )
      {
         cmbavCsolicituditemssr.Name = "vCSOLICITUDITEMSSR";
         cmbavCsolicituditemssr.WebTags = "";
         cmbavCsolicituditemssr.addItem("S", context.GetMessage( "Suma", ""), 0);
         cmbavCsolicituditemssr.addItem("R", context.GetMessage( "Resta", ""), 0);
         if ( cmbavCsolicituditemssr.ItemCount > 0 )
         {
            AV16cSolicitudItemsSR = cmbavCsolicituditemssr.getValidValue(AV16cSolicitudItemsSR);
            AssignAttri("", false, "AV16cSolicitudItemsSR", AV16cSolicitudItemsSR);
         }
         GXCCtl = "SOLICITUDITEMSSR_" + sGXsfl_74_idx;
         cmbSolicitudItemsSR.Name = GXCCtl;
         cmbSolicitudItemsSR.WebTags = "";
         cmbSolicitudItemsSR.addItem("S", context.GetMessage( "Suma", ""), 0);
         cmbSolicitudItemsSR.addItem("R", context.GetMessage( "Resta", ""), 0);
         if ( cmbSolicitudItemsSR.ItemCount > 0 )
         {
            A178SolicitudItemsSR = cmbSolicitudItemsSR.getValidValue(A178SolicitudItemsSR);
         }
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
            context.SendWebValue( context.GetMessage( "No.", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Precio", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Cantidad", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Comision", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Accion", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Tipo", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "%") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Comisión ALM", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "%") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Comisión PRV", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Solicitudes Id", "")) ;
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
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A134SolicitudesItemsID), 4, 0, ".", ""))));
            Grid1Column.AddObjectProperty("Link", StringUtil.RTrim( edtSolicitudesItemsID_Link));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( A176SolicitudesItemsPrecioFinal, 18, 2, ".", ""))));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A177SolicitudesItemsCantidad), 4, 0, ".", ""))));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( A180SolicitudItemsComision, 18, 2, ".", ""))));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A178SolicitudItemsSR)));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A179SolicitudItemsComisionTipo)));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( A524SolicitudesItemsComiProvP, 6, 2, ".", ""))));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( A523SolicitudesItemsComiALM, 18, 2, ".", ""))));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( A526SolicitudesItemsComiALMP, 6, 2, ".", ""))));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( A521SolicitudesItemsComiProv, 18, 2, ".", ""))));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A127SolicitudesID), 18, 0, ".", ""))));
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
         lblLblsolicitudesitemsidfilter_Internalname = "LBLSOLICITUDESITEMSIDFILTER";
         edtavCsolicitudesitemsid_Internalname = "vCSOLICITUDESITEMSID";
         divSolicitudesitemsidfiltercontainer_Internalname = "SOLICITUDESITEMSIDFILTERCONTAINER";
         lblLblsolicitudesitemspreciofinalfilter_Internalname = "LBLSOLICITUDESITEMSPRECIOFINALFILTER";
         edtavCsolicitudesitemspreciofinal_Internalname = "vCSOLICITUDESITEMSPRECIOFINAL";
         divSolicitudesitemspreciofinalfiltercontainer_Internalname = "SOLICITUDESITEMSPRECIOFINALFILTERCONTAINER";
         lblLblsolicitudesitemscantidadfilter_Internalname = "LBLSOLICITUDESITEMSCANTIDADFILTER";
         edtavCsolicitudesitemscantidad_Internalname = "vCSOLICITUDESITEMSCANTIDAD";
         divSolicitudesitemscantidadfiltercontainer_Internalname = "SOLICITUDESITEMSCANTIDADFILTERCONTAINER";
         lblLblsolicituditemscomisionfilter_Internalname = "LBLSOLICITUDITEMSCOMISIONFILTER";
         edtavCsolicituditemscomision_Internalname = "vCSOLICITUDITEMSCOMISION";
         divSolicituditemscomisionfiltercontainer_Internalname = "SOLICITUDITEMSCOMISIONFILTERCONTAINER";
         lblLblsolicituditemssrfilter_Internalname = "LBLSOLICITUDITEMSSRFILTER";
         cmbavCsolicituditemssr_Internalname = "vCSOLICITUDITEMSSR";
         divSolicituditemssrfiltercontainer_Internalname = "SOLICITUDITEMSSRFILTERCONTAINER";
         lblLblsolicituditemscomisiontipofilter_Internalname = "LBLSOLICITUDITEMSCOMISIONTIPOFILTER";
         edtavCsolicituditemscomisiontipo_Internalname = "vCSOLICITUDITEMSCOMISIONTIPO";
         divSolicituditemscomisiontipofiltercontainer_Internalname = "SOLICITUDITEMSCOMISIONTIPOFILTERCONTAINER";
         divAdvancedcontainer_Internalname = "ADVANCEDCONTAINER";
         bttBtntoggle_Internalname = "BTNTOGGLE";
         edtavLinkselection_Internalname = "vLINKSELECTION";
         edtSolicitudesItemsID_Internalname = "SOLICITUDESITEMSID";
         edtSolicitudesItemsPrecioFinal_Internalname = "SOLICITUDESITEMSPRECIOFINAL";
         edtSolicitudesItemsCantidad_Internalname = "SOLICITUDESITEMSCANTIDAD";
         edtSolicitudItemsComision_Internalname = "SOLICITUDITEMSCOMISION";
         cmbSolicitudItemsSR_Internalname = "SOLICITUDITEMSSR";
         edtSolicitudItemsComisionTipo_Internalname = "SOLICITUDITEMSCOMISIONTIPO";
         edtSolicitudesItemsComiProvP_Internalname = "SOLICITUDESITEMSCOMIPROVP";
         edtSolicitudesItemsComiALM_Internalname = "SOLICITUDESITEMSCOMIALM";
         edtSolicitudesItemsComiALMP_Internalname = "SOLICITUDESITEMSCOMIALMP";
         edtSolicitudesItemsComiProv_Internalname = "SOLICITUDESITEMSCOMIPROV";
         edtSolicitudesID_Internalname = "SOLICITUDESID";
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
         edtSolicitudesID_Jsonclick = "";
         edtSolicitudesItemsComiProv_Jsonclick = "";
         edtSolicitudesItemsComiALMP_Jsonclick = "";
         edtSolicitudesItemsComiALM_Jsonclick = "";
         edtSolicitudesItemsComiProvP_Jsonclick = "";
         edtSolicitudItemsComisionTipo_Jsonclick = "";
         cmbSolicitudItemsSR_Jsonclick = "";
         edtSolicitudItemsComision_Jsonclick = "";
         edtSolicitudesItemsCantidad_Jsonclick = "";
         edtSolicitudesItemsPrecioFinal_Jsonclick = "";
         edtSolicitudesItemsID_Jsonclick = "";
         edtSolicitudesItemsID_Link = "";
         edtavLinkselection_gximage = "";
         edtavLinkselection_Link = "";
         subGrid1_Class = "PromptGrid";
         subGrid1_Backcolorstyle = 0;
         edtSolicitudesID_Enabled = 0;
         edtSolicitudesItemsComiProv_Enabled = 0;
         edtSolicitudesItemsComiALMP_Enabled = 0;
         edtSolicitudesItemsComiALM_Enabled = 0;
         edtSolicitudesItemsComiProvP_Enabled = 0;
         edtSolicitudItemsComisionTipo_Enabled = 0;
         cmbSolicitudItemsSR.Enabled = 0;
         edtSolicitudItemsComision_Enabled = 0;
         edtSolicitudesItemsCantidad_Enabled = 0;
         edtSolicitudesItemsPrecioFinal_Enabled = 0;
         edtSolicitudesItemsID_Enabled = 0;
         edtavCsolicituditemscomisiontipo_Jsonclick = "";
         edtavCsolicituditemscomisiontipo_Enabled = 1;
         edtavCsolicituditemscomisiontipo_Visible = 1;
         cmbavCsolicituditemssr_Jsonclick = "";
         cmbavCsolicituditemssr.Visible = 1;
         cmbavCsolicituditemssr.Enabled = 1;
         edtavCsolicituditemscomision_Jsonclick = "";
         edtavCsolicituditemscomision_Enabled = 1;
         edtavCsolicituditemscomision_Visible = 1;
         edtavCsolicitudesitemscantidad_Jsonclick = "";
         edtavCsolicitudesitemscantidad_Enabled = 1;
         edtavCsolicitudesitemscantidad_Visible = 1;
         edtavCsolicitudesitemspreciofinal_Jsonclick = "";
         edtavCsolicitudesitemspreciofinal_Enabled = 1;
         edtavCsolicitudesitemspreciofinal_Visible = 1;
         edtavCsolicitudesitemsid_Jsonclick = "";
         edtavCsolicitudesitemsid_Enabled = 1;
         edtavCsolicitudesitemsid_Visible = 1;
         divSolicituditemscomisiontipofiltercontainer_Class = "AdvancedContainerItem AdvancedContainerItemExpanded";
         divSolicituditemssrfiltercontainer_Class = "AdvancedContainerItem AdvancedContainerItemExpanded";
         divSolicituditemscomisionfiltercontainer_Class = "AdvancedContainerItem AdvancedContainerItemExpanded";
         divSolicitudesitemscantidadfiltercontainer_Class = "AdvancedContainerItem AdvancedContainerItemExpanded";
         divSolicitudesitemspreciofinalfiltercontainer_Class = "AdvancedContainerItem AdvancedContainerItemExpanded";
         divSolicitudesitemsidfiltercontainer_Class = "AdvancedContainerItem AdvancedContainerItemExpanded";
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'GRID1_nFirstRecordOnPage',type:'int'},{av:'GRID1_nEOF',type:'int'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cSolicitudesItemsID',fld:'vCSOLICITUDESITEMSID',pic:'ZZZ9',type:'int'},{av:'AV10cSolicitudesItemsPrecioFinal',fld:'vCSOLICITUDESITEMSPRECIOFINAL',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV11cSolicitudesItemsCantidad',fld:'vCSOLICITUDESITEMSCANTIDAD',pic:'ZZZ9',type:'int'},{av:'AV15cSolicitudItemsComision',fld:'vCSOLICITUDITEMSCOMISION',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'cmbavCsolicituditemssr'},{av:'AV16cSolicitudItemsSR',fld:'vCSOLICITUDITEMSSR',pic:'',type:'char'},{av:'AV17cSolicitudItemsComisionTipo',fld:'vCSOLICITUDITEMSCOMISIONTIPO',pic:'',type:'char'},{av:'AV12pSolicitudesID',fld:'vPSOLICITUDESID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("'TOGGLE'","{handler:'E17AA1',iparms:[{av:'divAdvancedcontainer_Class',ctrl:'ADVANCEDCONTAINER',prop:'Class'},{ctrl:'BTNTOGGLE',prop:'Class'}]");
         setEventMetadata("'TOGGLE'",",oparms:[{av:'divAdvancedcontainer_Class',ctrl:'ADVANCEDCONTAINER',prop:'Class'},{ctrl:'BTNTOGGLE',prop:'Class'}]}");
         setEventMetadata("LBLSOLICITUDESITEMSIDFILTER.CLICK","{handler:'E11AA1',iparms:[{av:'divSolicitudesitemsidfiltercontainer_Class',ctrl:'SOLICITUDESITEMSIDFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLSOLICITUDESITEMSIDFILTER.CLICK",",oparms:[{av:'divSolicitudesitemsidfiltercontainer_Class',ctrl:'SOLICITUDESITEMSIDFILTERCONTAINER',prop:'Class'},{av:'edtavCsolicitudesitemsid_Visible',ctrl:'vCSOLICITUDESITEMSID',prop:'Visible'}]}");
         setEventMetadata("LBLSOLICITUDESITEMSPRECIOFINALFILTER.CLICK","{handler:'E12AA1',iparms:[{av:'divSolicitudesitemspreciofinalfiltercontainer_Class',ctrl:'SOLICITUDESITEMSPRECIOFINALFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLSOLICITUDESITEMSPRECIOFINALFILTER.CLICK",",oparms:[{av:'divSolicitudesitemspreciofinalfiltercontainer_Class',ctrl:'SOLICITUDESITEMSPRECIOFINALFILTERCONTAINER',prop:'Class'},{av:'edtavCsolicitudesitemspreciofinal_Visible',ctrl:'vCSOLICITUDESITEMSPRECIOFINAL',prop:'Visible'}]}");
         setEventMetadata("LBLSOLICITUDESITEMSCANTIDADFILTER.CLICK","{handler:'E13AA1',iparms:[{av:'divSolicitudesitemscantidadfiltercontainer_Class',ctrl:'SOLICITUDESITEMSCANTIDADFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLSOLICITUDESITEMSCANTIDADFILTER.CLICK",",oparms:[{av:'divSolicitudesitemscantidadfiltercontainer_Class',ctrl:'SOLICITUDESITEMSCANTIDADFILTERCONTAINER',prop:'Class'},{av:'edtavCsolicitudesitemscantidad_Visible',ctrl:'vCSOLICITUDESITEMSCANTIDAD',prop:'Visible'}]}");
         setEventMetadata("LBLSOLICITUDITEMSCOMISIONFILTER.CLICK","{handler:'E14AA1',iparms:[{av:'divSolicituditemscomisionfiltercontainer_Class',ctrl:'SOLICITUDITEMSCOMISIONFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLSOLICITUDITEMSCOMISIONFILTER.CLICK",",oparms:[{av:'divSolicituditemscomisionfiltercontainer_Class',ctrl:'SOLICITUDITEMSCOMISIONFILTERCONTAINER',prop:'Class'},{av:'edtavCsolicituditemscomision_Visible',ctrl:'vCSOLICITUDITEMSCOMISION',prop:'Visible'}]}");
         setEventMetadata("LBLSOLICITUDITEMSSRFILTER.CLICK","{handler:'E15AA1',iparms:[{av:'divSolicituditemssrfiltercontainer_Class',ctrl:'SOLICITUDITEMSSRFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLSOLICITUDITEMSSRFILTER.CLICK",",oparms:[{av:'divSolicituditemssrfiltercontainer_Class',ctrl:'SOLICITUDITEMSSRFILTERCONTAINER',prop:'Class'},{av:'cmbavCsolicituditemssr'}]}");
         setEventMetadata("LBLSOLICITUDITEMSCOMISIONTIPOFILTER.CLICK","{handler:'E16AA1',iparms:[{av:'divSolicituditemscomisiontipofiltercontainer_Class',ctrl:'SOLICITUDITEMSCOMISIONTIPOFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLSOLICITUDITEMSCOMISIONTIPOFILTER.CLICK",",oparms:[{av:'divSolicituditemscomisiontipofiltercontainer_Class',ctrl:'SOLICITUDITEMSCOMISIONTIPOFILTERCONTAINER',prop:'Class'},{av:'edtavCsolicituditemscomisiontipo_Visible',ctrl:'vCSOLICITUDITEMSCOMISIONTIPO',prop:'Visible'}]}");
         setEventMetadata("ENTER","{handler:'E20AA2',iparms:[{av:'A134SolicitudesItemsID',fld:'SOLICITUDESITEMSID',pic:'ZZZ9',hsh:true,type:'int'}]");
         setEventMetadata("ENTER",",oparms:[{av:'AV13pSolicitudesItemsID',fld:'vPSOLICITUDESITEMSID',pic:'ZZZ9',type:'int'}]}");
         setEventMetadata("GRID1_FIRSTPAGE","{handler:'subgrid1_firstpage',iparms:[{av:'GRID1_nFirstRecordOnPage',type:'int'},{av:'GRID1_nEOF',type:'int'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cSolicitudesItemsID',fld:'vCSOLICITUDESITEMSID',pic:'ZZZ9',type:'int'},{av:'AV10cSolicitudesItemsPrecioFinal',fld:'vCSOLICITUDESITEMSPRECIOFINAL',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV11cSolicitudesItemsCantidad',fld:'vCSOLICITUDESITEMSCANTIDAD',pic:'ZZZ9',type:'int'},{av:'AV15cSolicitudItemsComision',fld:'vCSOLICITUDITEMSCOMISION',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'cmbavCsolicituditemssr'},{av:'AV16cSolicitudItemsSR',fld:'vCSOLICITUDITEMSSR',pic:'',type:'char'},{av:'AV17cSolicitudItemsComisionTipo',fld:'vCSOLICITUDITEMSCOMISIONTIPO',pic:'',type:'char'},{av:'AV12pSolicitudesID',fld:'vPSOLICITUDESID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'}]");
         setEventMetadata("GRID1_FIRSTPAGE",",oparms:[]}");
         setEventMetadata("GRID1_PREVPAGE","{handler:'subgrid1_previouspage',iparms:[{av:'GRID1_nFirstRecordOnPage',type:'int'},{av:'GRID1_nEOF',type:'int'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cSolicitudesItemsID',fld:'vCSOLICITUDESITEMSID',pic:'ZZZ9',type:'int'},{av:'AV10cSolicitudesItemsPrecioFinal',fld:'vCSOLICITUDESITEMSPRECIOFINAL',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV11cSolicitudesItemsCantidad',fld:'vCSOLICITUDESITEMSCANTIDAD',pic:'ZZZ9',type:'int'},{av:'AV15cSolicitudItemsComision',fld:'vCSOLICITUDITEMSCOMISION',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'cmbavCsolicituditemssr'},{av:'AV16cSolicitudItemsSR',fld:'vCSOLICITUDITEMSSR',pic:'',type:'char'},{av:'AV17cSolicitudItemsComisionTipo',fld:'vCSOLICITUDITEMSCOMISIONTIPO',pic:'',type:'char'},{av:'AV12pSolicitudesID',fld:'vPSOLICITUDESID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'}]");
         setEventMetadata("GRID1_PREVPAGE",",oparms:[]}");
         setEventMetadata("GRID1_NEXTPAGE","{handler:'subgrid1_nextpage',iparms:[{av:'GRID1_nFirstRecordOnPage',type:'int'},{av:'GRID1_nEOF',type:'int'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cSolicitudesItemsID',fld:'vCSOLICITUDESITEMSID',pic:'ZZZ9',type:'int'},{av:'AV10cSolicitudesItemsPrecioFinal',fld:'vCSOLICITUDESITEMSPRECIOFINAL',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV11cSolicitudesItemsCantidad',fld:'vCSOLICITUDESITEMSCANTIDAD',pic:'ZZZ9',type:'int'},{av:'AV15cSolicitudItemsComision',fld:'vCSOLICITUDITEMSCOMISION',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'cmbavCsolicituditemssr'},{av:'AV16cSolicitudItemsSR',fld:'vCSOLICITUDITEMSSR',pic:'',type:'char'},{av:'AV17cSolicitudItemsComisionTipo',fld:'vCSOLICITUDITEMSCOMISIONTIPO',pic:'',type:'char'},{av:'AV12pSolicitudesID',fld:'vPSOLICITUDESID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'}]");
         setEventMetadata("GRID1_NEXTPAGE",",oparms:[]}");
         setEventMetadata("GRID1_LASTPAGE","{handler:'subgrid1_lastpage',iparms:[{av:'GRID1_nFirstRecordOnPage',type:'int'},{av:'GRID1_nEOF',type:'int'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cSolicitudesItemsID',fld:'vCSOLICITUDESITEMSID',pic:'ZZZ9',type:'int'},{av:'AV10cSolicitudesItemsPrecioFinal',fld:'vCSOLICITUDESITEMSPRECIOFINAL',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV11cSolicitudesItemsCantidad',fld:'vCSOLICITUDESITEMSCANTIDAD',pic:'ZZZ9',type:'int'},{av:'AV15cSolicitudItemsComision',fld:'vCSOLICITUDITEMSCOMISION',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'cmbavCsolicituditemssr'},{av:'AV16cSolicitudItemsSR',fld:'vCSOLICITUDITEMSSR',pic:'',type:'char'},{av:'AV17cSolicitudItemsComisionTipo',fld:'vCSOLICITUDITEMSCOMISIONTIPO',pic:'',type:'char'},{av:'AV12pSolicitudesID',fld:'vPSOLICITUDESID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'}]");
         setEventMetadata("GRID1_LASTPAGE",",oparms:[]}");
         setEventMetadata("NULL","{handler:'Valid_Solicitudesid',iparms:[]");
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
         AV16cSolicitudItemsSR = "";
         AV17cSolicitudItemsComisionTipo = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         lblLblsolicitudesitemsidfilter_Jsonclick = "";
         TempTags = "";
         lblLblsolicitudesitemspreciofinalfilter_Jsonclick = "";
         lblLblsolicitudesitemscantidadfilter_Jsonclick = "";
         lblLblsolicituditemscomisionfilter_Jsonclick = "";
         lblLblsolicituditemssrfilter_Jsonclick = "";
         lblLblsolicituditemscomisiontipofilter_Jsonclick = "";
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
         AV18Linkselection_GXI = "";
         A178SolicitudItemsSR = "";
         A179SolicitudItemsComisionTipo = "";
         lV16cSolicitudItemsSR = "";
         lV17cSolicitudItemsComisionTipo = "";
         H00AA2_A127SolicitudesID = new long[1] ;
         H00AA2_A521SolicitudesItemsComiProv = new decimal[1] ;
         H00AA2_n521SolicitudesItemsComiProv = new bool[] {false} ;
         H00AA2_A526SolicitudesItemsComiALMP = new decimal[1] ;
         H00AA2_n526SolicitudesItemsComiALMP = new bool[] {false} ;
         H00AA2_A523SolicitudesItemsComiALM = new decimal[1] ;
         H00AA2_n523SolicitudesItemsComiALM = new bool[] {false} ;
         H00AA2_A524SolicitudesItemsComiProvP = new decimal[1] ;
         H00AA2_n524SolicitudesItemsComiProvP = new bool[] {false} ;
         H00AA2_A179SolicitudItemsComisionTipo = new string[] {""} ;
         H00AA2_A178SolicitudItemsSR = new string[] {""} ;
         H00AA2_A180SolicitudItemsComision = new decimal[1] ;
         H00AA2_A177SolicitudesItemsCantidad = new short[1] ;
         H00AA2_A176SolicitudesItemsPrecioFinal = new decimal[1] ;
         H00AA2_n176SolicitudesItemsPrecioFinal = new bool[] {false} ;
         H00AA2_A134SolicitudesItemsID = new short[1] ;
         H00AA3_AGRID1_nRecordCount = new long[1] ;
         AV14ADVANCED_LABEL_TEMPLATE = "";
         Grid1Row = new GXWebRow();
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         subGrid1_Linesclass = "";
         sImgUrl = "";
         ROClassString = "";
         GXCCtl = "";
         Grid1Column = new GXWebColumn();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.gx00v1__default(),
            new Object[][] {
                new Object[] {
               H00AA2_A127SolicitudesID, H00AA2_A521SolicitudesItemsComiProv, H00AA2_n521SolicitudesItemsComiProv, H00AA2_A526SolicitudesItemsComiALMP, H00AA2_n526SolicitudesItemsComiALMP, H00AA2_A523SolicitudesItemsComiALM, H00AA2_n523SolicitudesItemsComiALM, H00AA2_A524SolicitudesItemsComiProvP, H00AA2_n524SolicitudesItemsComiProvP, H00AA2_A179SolicitudItemsComisionTipo,
               H00AA2_A178SolicitudItemsSR, H00AA2_A180SolicitudItemsComision, H00AA2_A177SolicitudesItemsCantidad, H00AA2_A176SolicitudesItemsPrecioFinal, H00AA2_n176SolicitudesItemsPrecioFinal, H00AA2_A134SolicitudesItemsID
               }
               , new Object[] {
               H00AA3_AGRID1_nRecordCount
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV13pSolicitudesItemsID ;
      private short GRID1_nEOF ;
      private short nGotPars ;
      private short GxWebError ;
      private short AV6cSolicitudesItemsID ;
      private short AV11cSolicitudesItemsCantidad ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short A134SolicitudesItemsID ;
      private short A177SolicitudesItemsCantidad ;
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
      private int edtavCsolicitudesitemsid_Enabled ;
      private int edtavCsolicitudesitemsid_Visible ;
      private int edtavCsolicitudesitemspreciofinal_Enabled ;
      private int edtavCsolicitudesitemspreciofinal_Visible ;
      private int edtavCsolicitudesitemscantidad_Enabled ;
      private int edtavCsolicitudesitemscantidad_Visible ;
      private int edtavCsolicituditemscomision_Enabled ;
      private int edtavCsolicituditemscomision_Visible ;
      private int edtavCsolicituditemscomisiontipo_Visible ;
      private int edtavCsolicituditemscomisiontipo_Enabled ;
      private int subGrid1_Islastpage ;
      private int GXPagingFrom2 ;
      private int GXPagingTo2 ;
      private int edtSolicitudesItemsID_Enabled ;
      private int edtSolicitudesItemsPrecioFinal_Enabled ;
      private int edtSolicitudesItemsCantidad_Enabled ;
      private int edtSolicitudItemsComision_Enabled ;
      private int edtSolicitudItemsComisionTipo_Enabled ;
      private int edtSolicitudesItemsComiProvP_Enabled ;
      private int edtSolicitudesItemsComiALM_Enabled ;
      private int edtSolicitudesItemsComiALMP_Enabled ;
      private int edtSolicitudesItemsComiProv_Enabled ;
      private int edtSolicitudesID_Enabled ;
      private int idxLst ;
      private int subGrid1_Backcolor ;
      private int subGrid1_Allbackcolor ;
      private int subGrid1_Titlebackcolor ;
      private int subGrid1_Selectedindex ;
      private int subGrid1_Selectioncolor ;
      private int subGrid1_Hoveringcolor ;
      private long AV12pSolicitudesID ;
      private long wcpOAV12pSolicitudesID ;
      private long GRID1_nFirstRecordOnPage ;
      private long A127SolicitudesID ;
      private long GRID1_nCurrentRecord ;
      private long GRID1_nRecordCount ;
      private decimal AV10cSolicitudesItemsPrecioFinal ;
      private decimal AV15cSolicitudItemsComision ;
      private decimal A176SolicitudesItemsPrecioFinal ;
      private decimal A180SolicitudItemsComision ;
      private decimal A524SolicitudesItemsComiProvP ;
      private decimal A523SolicitudesItemsComiALM ;
      private decimal A526SolicitudesItemsComiALMP ;
      private decimal A521SolicitudesItemsComiProv ;
      private string divAdvancedcontainer_Class ;
      private string bttBtntoggle_Class ;
      private string divSolicitudesitemsidfiltercontainer_Class ;
      private string divSolicitudesitemspreciofinalfiltercontainer_Class ;
      private string divSolicitudesitemscantidadfiltercontainer_Class ;
      private string divSolicituditemscomisionfiltercontainer_Class ;
      private string divSolicituditemssrfiltercontainer_Class ;
      private string divSolicituditemscomisiontipofiltercontainer_Class ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_74_idx="0001" ;
      private string AV16cSolicitudItemsSR ;
      private string AV17cSolicitudItemsComisionTipo ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divMain_Internalname ;
      private string divAdvancedcontainer_Internalname ;
      private string divSolicitudesitemsidfiltercontainer_Internalname ;
      private string lblLblsolicitudesitemsidfilter_Internalname ;
      private string lblLblsolicitudesitemsidfilter_Jsonclick ;
      private string edtavCsolicitudesitemsid_Internalname ;
      private string TempTags ;
      private string edtavCsolicitudesitemsid_Jsonclick ;
      private string divSolicitudesitemspreciofinalfiltercontainer_Internalname ;
      private string lblLblsolicitudesitemspreciofinalfilter_Internalname ;
      private string lblLblsolicitudesitemspreciofinalfilter_Jsonclick ;
      private string edtavCsolicitudesitemspreciofinal_Internalname ;
      private string edtavCsolicitudesitemspreciofinal_Jsonclick ;
      private string divSolicitudesitemscantidadfiltercontainer_Internalname ;
      private string lblLblsolicitudesitemscantidadfilter_Internalname ;
      private string lblLblsolicitudesitemscantidadfilter_Jsonclick ;
      private string edtavCsolicitudesitemscantidad_Internalname ;
      private string edtavCsolicitudesitemscantidad_Jsonclick ;
      private string divSolicituditemscomisionfiltercontainer_Internalname ;
      private string lblLblsolicituditemscomisionfilter_Internalname ;
      private string lblLblsolicituditemscomisionfilter_Jsonclick ;
      private string edtavCsolicituditemscomision_Internalname ;
      private string edtavCsolicituditemscomision_Jsonclick ;
      private string divSolicituditemssrfiltercontainer_Internalname ;
      private string lblLblsolicituditemssrfilter_Internalname ;
      private string lblLblsolicituditemssrfilter_Jsonclick ;
      private string cmbavCsolicituditemssr_Internalname ;
      private string cmbavCsolicituditemssr_Jsonclick ;
      private string divSolicituditemscomisiontipofiltercontainer_Internalname ;
      private string lblLblsolicituditemscomisiontipofilter_Internalname ;
      private string lblLblsolicituditemscomisiontipofilter_Jsonclick ;
      private string edtavCsolicituditemscomisiontipo_Internalname ;
      private string edtavCsolicituditemscomisiontipo_Jsonclick ;
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
      private string edtSolicitudesItemsID_Internalname ;
      private string edtSolicitudesItemsPrecioFinal_Internalname ;
      private string edtSolicitudesItemsCantidad_Internalname ;
      private string edtSolicitudItemsComision_Internalname ;
      private string cmbSolicitudItemsSR_Internalname ;
      private string A178SolicitudItemsSR ;
      private string A179SolicitudItemsComisionTipo ;
      private string edtSolicitudItemsComisionTipo_Internalname ;
      private string edtSolicitudesItemsComiProvP_Internalname ;
      private string edtSolicitudesItemsComiALM_Internalname ;
      private string edtSolicitudesItemsComiALMP_Internalname ;
      private string edtSolicitudesItemsComiProv_Internalname ;
      private string edtSolicitudesID_Internalname ;
      private string lV16cSolicitudItemsSR ;
      private string lV17cSolicitudItemsComisionTipo ;
      private string AV14ADVANCED_LABEL_TEMPLATE ;
      private string edtavLinkselection_gximage ;
      private string sGXsfl_74_fel_idx="0001" ;
      private string subGrid1_Class ;
      private string subGrid1_Linesclass ;
      private string edtavLinkselection_Link ;
      private string sImgUrl ;
      private string ROClassString ;
      private string edtSolicitudesItemsID_Link ;
      private string edtSolicitudesItemsID_Jsonclick ;
      private string edtSolicitudesItemsPrecioFinal_Jsonclick ;
      private string edtSolicitudesItemsCantidad_Jsonclick ;
      private string edtSolicitudItemsComision_Jsonclick ;
      private string GXCCtl ;
      private string cmbSolicitudItemsSR_Jsonclick ;
      private string edtSolicitudItemsComisionTipo_Jsonclick ;
      private string edtSolicitudesItemsComiProvP_Jsonclick ;
      private string edtSolicitudesItemsComiALM_Jsonclick ;
      private string edtSolicitudesItemsComiALMP_Jsonclick ;
      private string edtSolicitudesItemsComiProv_Jsonclick ;
      private string edtSolicitudesID_Jsonclick ;
      private string subGrid1_Header ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool bGXsfl_74_Refreshing=false ;
      private bool n176SolicitudesItemsPrecioFinal ;
      private bool n524SolicitudesItemsComiProvP ;
      private bool n523SolicitudesItemsComiALM ;
      private bool n526SolicitudesItemsComiALMP ;
      private bool n521SolicitudesItemsComiProv ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool AV5LinkSelection_IsBlob ;
      private string AV18Linkselection_GXI ;
      private string AV5LinkSelection ;
      private GXWebGrid Grid1Container ;
      private GXWebRow Grid1Row ;
      private GXWebColumn Grid1Column ;
      private GXWebForm Form ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbavCsolicituditemssr ;
      private GXCombobox cmbSolicitudItemsSR ;
      private IDataStoreProvider pr_default ;
      private long[] H00AA2_A127SolicitudesID ;
      private decimal[] H00AA2_A521SolicitudesItemsComiProv ;
      private bool[] H00AA2_n521SolicitudesItemsComiProv ;
      private decimal[] H00AA2_A526SolicitudesItemsComiALMP ;
      private bool[] H00AA2_n526SolicitudesItemsComiALMP ;
      private decimal[] H00AA2_A523SolicitudesItemsComiALM ;
      private bool[] H00AA2_n523SolicitudesItemsComiALM ;
      private decimal[] H00AA2_A524SolicitudesItemsComiProvP ;
      private bool[] H00AA2_n524SolicitudesItemsComiProvP ;
      private string[] H00AA2_A179SolicitudItemsComisionTipo ;
      private string[] H00AA2_A178SolicitudItemsSR ;
      private decimal[] H00AA2_A180SolicitudItemsComision ;
      private short[] H00AA2_A177SolicitudesItemsCantidad ;
      private decimal[] H00AA2_A176SolicitudesItemsPrecioFinal ;
      private bool[] H00AA2_n176SolicitudesItemsPrecioFinal ;
      private short[] H00AA2_A134SolicitudesItemsID ;
      private long[] H00AA3_AGRID1_nRecordCount ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private short aP1_pSolicitudesItemsID ;
   }

   public class gx00v1__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H00AA2( IGxContext context ,
                                             decimal AV10cSolicitudesItemsPrecioFinal ,
                                             short AV11cSolicitudesItemsCantidad ,
                                             decimal AV15cSolicitudItemsComision ,
                                             string AV16cSolicitudItemsSR ,
                                             string AV17cSolicitudItemsComisionTipo ,
                                             decimal A176SolicitudesItemsPrecioFinal ,
                                             short A177SolicitudesItemsCantidad ,
                                             decimal A180SolicitudItemsComision ,
                                             string A178SolicitudItemsSR ,
                                             string A179SolicitudItemsComisionTipo ,
                                             long AV12pSolicitudesID ,
                                             short AV6cSolicitudesItemsID ,
                                             long A127SolicitudesID )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[10];
         Object[] GXv_Object2 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " [SolicitudesID], [SolicitudesItemsComiProv], [SolicitudesItemsComiALMP], [SolicitudesItemsComiALM], [SolicitudesItemsComiProvP], [SolicitudItemsComisionTipo], [SolicitudItemsSR], [SolicitudItemsComision], [SolicitudesItemsCantidad], [SolicitudesItemsPrecioFinal], [SolicitudesItemsID]";
         sFromString = " FROM [SolicitudesItems]";
         sOrderString = "";
         AddWhere(sWhereString, "([SolicitudesID] = @AV12pSolicitudesID and [SolicitudesItemsID] >= @AV6cSolicitudesItemsID)");
         if ( ! (Convert.ToDecimal(0)==AV10cSolicitudesItemsPrecioFinal) )
         {
            AddWhere(sWhereString, "([SolicitudesItemsPrecioFinal] >= @AV10cSolicitudesItemsPrecioFinal)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( ! (0==AV11cSolicitudesItemsCantidad) )
         {
            AddWhere(sWhereString, "([SolicitudesItemsCantidad] >= @AV11cSolicitudesItemsCantidad)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV15cSolicitudItemsComision) )
         {
            AddWhere(sWhereString, "([SolicitudItemsComision] >= @AV15cSolicitudItemsComision)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV16cSolicitudItemsSR)) )
         {
            AddWhere(sWhereString, "([SolicitudItemsSR] like @lV16cSolicitudItemsSR)");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV17cSolicitudItemsComisionTipo)) )
         {
            AddWhere(sWhereString, "([SolicitudItemsComisionTipo] like @lV17cSolicitudItemsComisionTipo)");
         }
         else
         {
            GXv_int1[6] = 1;
         }
         sOrderString += " ORDER BY [SolicitudesID], [SolicitudesItemsID]";
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + "@GXPagingFrom2" + " ROWS FETCH NEXT CAST((SELECT CASE WHEN " + "@GXPagingTo2" + " > 0 THEN " + "@GXPagingTo2" + " ELSE 1e9 END) AS INTEGER) ROWS ONLY";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_H00AA3( IGxContext context ,
                                             decimal AV10cSolicitudesItemsPrecioFinal ,
                                             short AV11cSolicitudesItemsCantidad ,
                                             decimal AV15cSolicitudItemsComision ,
                                             string AV16cSolicitudItemsSR ,
                                             string AV17cSolicitudItemsComisionTipo ,
                                             decimal A176SolicitudesItemsPrecioFinal ,
                                             short A177SolicitudesItemsCantidad ,
                                             decimal A180SolicitudItemsComision ,
                                             string A178SolicitudItemsSR ,
                                             string A179SolicitudItemsComisionTipo ,
                                             long AV12pSolicitudesID ,
                                             short AV6cSolicitudesItemsID ,
                                             long A127SolicitudesID )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[7];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT COUNT(*) FROM [SolicitudesItems]";
         AddWhere(sWhereString, "([SolicitudesID] = @AV12pSolicitudesID and [SolicitudesItemsID] >= @AV6cSolicitudesItemsID)");
         if ( ! (Convert.ToDecimal(0)==AV10cSolicitudesItemsPrecioFinal) )
         {
            AddWhere(sWhereString, "([SolicitudesItemsPrecioFinal] >= @AV10cSolicitudesItemsPrecioFinal)");
         }
         else
         {
            GXv_int3[2] = 1;
         }
         if ( ! (0==AV11cSolicitudesItemsCantidad) )
         {
            AddWhere(sWhereString, "([SolicitudesItemsCantidad] >= @AV11cSolicitudesItemsCantidad)");
         }
         else
         {
            GXv_int3[3] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV15cSolicitudItemsComision) )
         {
            AddWhere(sWhereString, "([SolicitudItemsComision] >= @AV15cSolicitudItemsComision)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV16cSolicitudItemsSR)) )
         {
            AddWhere(sWhereString, "([SolicitudItemsSR] like @lV16cSolicitudItemsSR)");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV17cSolicitudItemsComisionTipo)) )
         {
            AddWhere(sWhereString, "([SolicitudItemsComisionTipo] like @lV17cSolicitudItemsComisionTipo)");
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
                     return conditional_H00AA2(context, (decimal)dynConstraints[0] , (short)dynConstraints[1] , (decimal)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (decimal)dynConstraints[5] , (short)dynConstraints[6] , (decimal)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (long)dynConstraints[10] , (short)dynConstraints[11] , (long)dynConstraints[12] );
               case 1 :
                     return conditional_H00AA3(context, (decimal)dynConstraints[0] , (short)dynConstraints[1] , (decimal)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (decimal)dynConstraints[5] , (short)dynConstraints[6] , (decimal)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (long)dynConstraints[10] , (short)dynConstraints[11] , (long)dynConstraints[12] );
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
          Object[] prmH00AA2;
          prmH00AA2 = new Object[] {
          new ParDef("@AV12pSolicitudesID",GXType.Decimal,18,0) ,
          new ParDef("@AV6cSolicitudesItemsID",GXType.Int16,4,0) ,
          new ParDef("@AV10cSolicitudesItemsPrecioFinal",GXType.Decimal,18,2) ,
          new ParDef("@AV11cSolicitudesItemsCantidad",GXType.Int16,4,0) ,
          new ParDef("@AV15cSolicitudItemsComision",GXType.Decimal,18,2) ,
          new ParDef("@lV16cSolicitudItemsSR",GXType.NChar,1,0) ,
          new ParDef("@lV17cSolicitudItemsComisionTipo",GXType.NChar,1,0) ,
          new ParDef("@GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0)
          };
          Object[] prmH00AA3;
          prmH00AA3 = new Object[] {
          new ParDef("@AV12pSolicitudesID",GXType.Decimal,18,0) ,
          new ParDef("@AV6cSolicitudesItemsID",GXType.Int16,4,0) ,
          new ParDef("@AV10cSolicitudesItemsPrecioFinal",GXType.Decimal,18,2) ,
          new ParDef("@AV11cSolicitudesItemsCantidad",GXType.Int16,4,0) ,
          new ParDef("@AV15cSolicitudItemsComision",GXType.Decimal,18,2) ,
          new ParDef("@lV16cSolicitudItemsSR",GXType.NChar,1,0) ,
          new ParDef("@lV17cSolicitudItemsComisionTipo",GXType.NChar,1,0)
          };
          def= new CursorDef[] {
              new CursorDef("H00AA2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00AA2,11, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("H00AA3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00AA3,1, GxCacheFrequency.OFF ,false,false )
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
                ((decimal[]) buf[1])[0] = rslt.getDecimal(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((decimal[]) buf[3])[0] = rslt.getDecimal(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((decimal[]) buf[5])[0] = rslt.getDecimal(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((decimal[]) buf[7])[0] = rslt.getDecimal(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((string[]) buf[9])[0] = rslt.getString(6, 1);
                ((string[]) buf[10])[0] = rslt.getString(7, 1);
                ((decimal[]) buf[11])[0] = rslt.getDecimal(8);
                ((short[]) buf[12])[0] = rslt.getShort(9);
                ((decimal[]) buf[13])[0] = rslt.getDecimal(10);
                ((bool[]) buf[14])[0] = rslt.wasNull(10);
                ((short[]) buf[15])[0] = rslt.getShort(11);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
       }
    }

 }

}

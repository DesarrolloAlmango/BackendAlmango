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
using GeneXus.Http.Server;
using System.Xml.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class zonasgeneral : GXWebComponent, System.Web.SessionState.IRequiresSessionState
   {
      public zonasgeneral( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         if ( StringUtil.Len( (string)(sPrefix)) == 0 )
         {
            context.SetDefaultTheme("WorkWithPlusDS", true);
         }
      }

      public zonasgeneral( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( long aP0_ZonasID ,
                           long aP1_DepartamentoId ,
                           long aP2_DepartamentoMunicipioId )
      {
         this.A110ZonasID = aP0_ZonasID;
         this.A112DepartamentoId = aP1_DepartamentoId;
         this.A114DepartamentoMunicipioId = aP2_DepartamentoMunicipioId;
         ExecutePrivate();
      }

      protected override void ExecutePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      public override void SetPrefix( string sPPrefix )
      {
         sPrefix = sPPrefix;
      }

      protected override void createObjects( )
      {
         dynDepartamentoId = new GXCombobox();
         dynDepartamentoMunicipioId = new GXCombobox();
         cmbZonasEstado = new GXCombobox();
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( StringUtil.Len( (string)(sPrefix)) == 0 )
         {
            if ( nGotPars == 0 )
            {
               entryPointCalled = false;
               gxfirstwebparm = GetFirstPar( "ZonasID");
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
               else if ( StringUtil.StrCmp(gxfirstwebparm, "dyncomponent") == 0 )
               {
                  setAjaxEventMode();
                  if ( ! IsValidAjaxCall( true) )
                  {
                     GxWebError = 1;
                     return  ;
                  }
                  nDynComponent = 1;
                  sCompPrefix = GetPar( "sCompPrefix");
                  sSFPrefix = GetPar( "sSFPrefix");
                  A110ZonasID = (long)(Math.Round(NumberUtil.Val( GetPar( "ZonasID"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri(sPrefix, false, "A110ZonasID", StringUtil.LTrimStr( (decimal)(A110ZonasID), 18, 0));
                  A112DepartamentoId = (long)(Math.Round(NumberUtil.Val( GetPar( "DepartamentoId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri(sPrefix, false, "A112DepartamentoId", StringUtil.LTrimStr( (decimal)(A112DepartamentoId), 18, 0));
                  A114DepartamentoMunicipioId = (long)(Math.Round(NumberUtil.Val( GetPar( "DepartamentoMunicipioId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri(sPrefix, false, "A114DepartamentoMunicipioId", StringUtil.LTrimStr( (decimal)(A114DepartamentoMunicipioId), 18, 0));
                  setjustcreated();
                  componentprepare(new Object[] {(string)sCompPrefix,(string)sSFPrefix,(long)A110ZonasID,(long)A112DepartamentoId,(long)A114DepartamentoMunicipioId});
                  componentstart();
                  context.httpAjaxContext.ajax_rspStartCmp(sPrefix);
                  componentdraw();
                  context.httpAjaxContext.ajax_rspEndCmp();
                  return  ;
               }
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxCallCrl"+"_"+"DEPARTAMENTOMUNICIPIOID") == 0 )
               {
                  A112DepartamentoId = (long)(Math.Round(NumberUtil.Val( GetPar( "DepartamentoId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri(sPrefix, false, "A112DepartamentoId", StringUtil.LTrimStr( (decimal)(A112DepartamentoId), 18, 0));
                  setAjaxCallMode();
                  if ( ! IsValidAjaxCall( true) )
                  {
                     GxWebError = 1;
                     return  ;
                  }
                  GXDLADEPARTAMENTOMUNICIPIOID662( A112DepartamentoId) ;
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
                  gxfirstwebparm = GetFirstPar( "ZonasID");
               }
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
               {
                  if ( ! IsValidAjaxCall( true) )
                  {
                     GxWebError = 1;
                     return  ;
                  }
                  gxfirstwebparm = GetFirstPar( "ZonasID");
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
               if ( toggleJsOutput )
               {
                  if ( context.isSpaRequest( ) )
                  {
                     enableJsOutput();
                  }
               }
            }
         }
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( ! context.IsLocalStorageSupported( ) )
            {
               context.PushCurrentUrl();
            }
         }
      }

      public override void webExecute( )
      {
         createObjects();
         initialize();
         INITWEB( ) ;
         if ( ! isAjaxCallMode( ) )
         {
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               ValidateSpaRequest();
            }
            PA662( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               AV13Pgmname = "ZonasGeneral";
               GXADEPARTAMENTOMUNICIPIOID_html662( A112DepartamentoId) ;
               WS662( ) ;
               if ( ! isAjaxCallMode( ) )
               {
                  if ( nDynComponent == 0 )
                  {
                     throw new System.Net.WebException("WebComponent is not allowed to run") ;
                  }
               }
            }
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

      protected void RenderHtmlHeaders( )
      {
         GxWebStd.gx_html_headers( context, 0, "", "", Form.Meta, Form.Metaequiv, true);
      }

      protected void RenderHtmlOpenForm( )
      {
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( context.isSpaRequest( ) )
            {
               enableOutput();
            }
            context.WriteHtmlText( "<title>") ;
            context.SendWebValue( context.GetMessage( "Zonas General", "")) ;
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
         }
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
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            context.CloseHtmlHeader();
            if ( context.isSpaRequest( ) )
            {
               disableOutput();
            }
            FormProcess = " data-HasEnter=\"false\" data-Skiponenter=\"false\"";
            context.WriteHtmlText( "<body ") ;
            if ( StringUtil.StrCmp(context.GetLanguageProperty( "rtl"), "true") == 0 )
            {
               context.WriteHtmlText( " dir=\"rtl\" ") ;
            }
            bodyStyle = "";
            if ( nGXWrapped == 0 )
            {
               bodyStyle += "-moz-opacity:0;opacity:0;";
            }
            context.WriteHtmlText( " "+"class=\"form-horizontal Form\""+" "+ "style='"+bodyStyle+"'") ;
            context.WriteHtmlText( FormProcess+">") ;
            context.skipLines(1);
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "zonasgeneral.aspx"+UrlEncode(StringUtil.LTrimStr(A110ZonasID,18,0)) + "," + UrlEncode(StringUtil.LTrimStr(A112DepartamentoId,18,0)) + "," + UrlEncode(StringUtil.LTrimStr(A114DepartamentoMunicipioId,18,0));
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("zonasgeneral.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
            GxWebStd.gx_hidden_field( context, "_EventName", "");
            GxWebStd.gx_hidden_field( context, "_EventGridId", "");
            GxWebStd.gx_hidden_field( context, "_EventRowId", "");
            context.WriteHtmlText( "<div style=\"height:0;overflow:hidden\"><input type=\"submit\" title=\"submit\"  disabled></div>") ;
            AssignProp(sPrefix, false, "FORM", "Class", "form-horizontal Form", true);
         }
         else
         {
            bool toggleHtmlOutput = isOutputEnabled( );
            if ( StringUtil.StringSearch( sPrefix, "MP", 1) == 1 )
            {
               if ( context.isSpaRequest( ) )
               {
                  disableOutput();
               }
            }
            context.WriteHtmlText( "<div") ;
            GxWebStd.ClassAttribute( context, "gxwebcomponent-body"+" "+(String.IsNullOrEmpty(StringUtil.RTrim( Form.Class)) ? "form-horizontal Form" : Form.Class)+"-fx");
            context.WriteHtmlText( ">") ;
            if ( toggleHtmlOutput )
            {
               if ( StringUtil.StringSearch( sPrefix, "MP", 1) == 1 )
               {
                  if ( context.isSpaRequest( ) )
                  {
                     enableOutput();
                  }
               }
            }
            toggleJsOutput = isJsOutputEnabled( );
            if ( context.isSpaRequest( ) )
            {
               disableJsOutput();
            }
         }
         if ( StringUtil.StringSearch( sPrefix, "MP", 1) == 1 )
         {
            if ( context.isSpaRequest( ) )
            {
               disableOutput();
            }
         }
      }

      protected void send_integrity_footer_hashes( )
      {
         GXKey = Crypto.GetSiteKey( );
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOA110ZonasID", StringUtil.LTrim( StringUtil.NToC( (decimal)(wcpOA110ZonasID), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOA112DepartamentoId", StringUtil.LTrim( StringUtil.NToC( (decimal)(wcpOA112DepartamentoId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOA114DepartamentoMunicipioId", StringUtil.LTrim( StringUtil.NToC( (decimal)(wcpOA114DepartamentoMunicipioId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
      }

      protected void RenderHtmlCloseForm662( )
      {
         SendCloseFormHiddens( ) ;
         if ( ( StringUtil.Len( sPrefix) != 0 ) && ( context.isAjaxRequest( ) || context.isSpaRequest( ) ) )
         {
            componentjscripts();
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"GX_FocusControl", GX_FocusControl);
         define_styles( ) ;
         SendSecurityToken(sPrefix);
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            SendAjaxEncryptionKey();
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
            context.WriteHtmlTextNl( "</body>") ;
            context.WriteHtmlTextNl( "</html>") ;
            if ( context.isSpaRequest( ) )
            {
               enableOutput();
            }
         }
         else
         {
            SendWebComponentState();
            context.WriteHtmlText( "</div>") ;
            if ( toggleJsOutput )
            {
               if ( context.isSpaRequest( ) )
               {
                  enableJsOutput();
               }
            }
         }
      }

      public override string GetPgmname( )
      {
         return "ZonasGeneral" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "Zonas General", "") ;
      }

      protected void WB660( )
      {
         if ( context.isAjaxRequest( ) )
         {
            disableOutput();
         }
         if ( ! wbLoad )
         {
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               RenderHtmlHeaders( ) ;
            }
            RenderHtmlOpenForm( ) ;
            if ( StringUtil.Len( sPrefix) != 0 )
            {
               GxWebStd.gx_hidden_field( context, sPrefix+"_CMPPGM", "zonasgeneral.aspx");
            }
            GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, "", "", sPrefix, "false");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "start", "top", " "+"data-gx-base-lib=\"bootstrapv3\""+" "+"data-abstract-form"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divLayoutmaintable_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTransactiondetail_tableattributes_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+dynDepartamentoId_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, dynDepartamentoId_Internalname, context.GetMessage( "Departamento", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 14,'" + sPrefix + "',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, dynDepartamentoId, dynDepartamentoId_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(A112DepartamentoId), 18, 0)), 1, dynDepartamentoId_Jsonclick, 0, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "int", "", 1, dynDepartamentoId.Enabled, 0, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,14);\"", "", true, 0, "HLP_ZonasGeneral.htm");
            dynDepartamentoId.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A112DepartamentoId), 18, 0));
            AssignProp(sPrefix, false, dynDepartamentoId_Internalname, "Values", (string)(dynDepartamentoId.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+dynDepartamentoMunicipioId_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, dynDepartamentoMunicipioId_Internalname, context.GetMessage( "Municipio", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 19,'" + sPrefix + "',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, dynDepartamentoMunicipioId, dynDepartamentoMunicipioId_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(A114DepartamentoMunicipioId), 18, 0)), 1, dynDepartamentoMunicipioId_Jsonclick, 0, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "int", "", 1, dynDepartamentoMunicipioId.Enabled, 0, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,19);\"", "", true, 0, "HLP_ZonasGeneral.htm");
            dynDepartamentoMunicipioId.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A114DepartamentoMunicipioId), 18, 0));
            AssignProp(sPrefix, false, dynDepartamentoMunicipioId_Internalname, "Values", (string)(dynDepartamentoMunicipioId.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-2 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtZonasID_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtZonasID_Internalname, context.GetMessage( "Zona", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 24,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtZonasID_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A110ZonasID), 18, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtZonasID_Enabled!=0) ? context.localUtil.Format( (decimal)(A110ZonasID), "ZZZZZZZZZZZZZZZZZ9") : context.localUtil.Format( (decimal)(A110ZonasID), "ZZZZZZZZZZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,24);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", context.GetMessage( "Seleccione su Zona", ""), edtZonasID_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtZonasID_Enabled, 0, "text", "1", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "Id", "end", false, "", "HLP_ZonasGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtZonasNombre_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtZonasNombre_Internalname, context.GetMessage( "Nombre de la Zona", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtZonasNombre_Internalname, StringUtil.RTrim( A111ZonasNombre), StringUtil.RTrim( context.localUtil.Format( A111ZonasNombre, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,29);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtZonasNombre_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtZonasNombre_Enabled, 0, "text", "", 80, "chr", 1, "row", 120, 0, 0, 0, 0, -1, -1, true, "NombreLargo", "start", true, "", "HLP_ZonasGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbZonasEstado_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbZonasEstado_Internalname, context.GetMessage( "Estado", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'" + sPrefix + "',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbZonasEstado, cmbZonasEstado_Internalname, StringUtil.RTrim( A906ZonasEstado), 1, cmbZonasEstado_Jsonclick, 0, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "char", "", 1, cmbZonasEstado.Enabled, 0, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,34);\"", "", true, 0, "HLP_ZonasGeneral.htm");
            cmbZonasEstado.CurrentValue = StringUtil.RTrim( A906ZonasEstado);
            AssignProp(sPrefix, false, cmbZonasEstado_Internalname, "Values", (string)(cmbZonasEstado.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-action-group CellMarginTop10", "start", "top", " "+"data-gx-actiongroup-type=\"toolbar\""+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'" + sPrefix + "',false,'',0)\"";
            ClassString = "ButtonMaterial";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnupdate_Internalname, "", context.GetMessage( "GXM_update", ""), bttBtnupdate_Jsonclick, 5, context.GetMessage( "GXM_update", ""), "", StyleString, ClassString, bttBtnupdate_Visible, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'DOUPDATE\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_ZonasGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 41,'" + sPrefix + "',false,'',0)\"";
            ClassString = "ButtonMaterialDefault";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtndelete_Internalname, "", context.GetMessage( "GX_BtnDelete", ""), bttBtndelete_Jsonclick, 5, context.GetMessage( "GX_BtnDelete", ""), "", StyleString, ClassString, bttBtndelete_Visible, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'DODELETE\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_ZonasGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         wbLoad = true;
      }

      protected void START662( )
      {
         wbLoad = false;
         wbEnd = 0;
         wbStart = 0;
         if ( StringUtil.Len( sPrefix) != 0 )
         {
            GXKey = Crypto.GetSiteKey( );
         }
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( ! context.isSpaRequest( ) )
            {
               if ( context.ExposeMetadata( ) )
               {
                  Form.Meta.addItem("generator", "GeneXus .NET Framework 18_0_15-188745", 0) ;
               }
            }
            Form.Meta.addItem("description", context.GetMessage( "Zonas General", ""), 0) ;
            context.wjLoc = "";
            context.nUserReturn = 0;
            context.wbHandled = 0;
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               sXEvt = cgiGet( "_EventName");
               if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
               {
               }
            }
         }
         wbErr = false;
         if ( ( StringUtil.Len( sPrefix) == 0 ) || ( nDraw == 1 ) )
         {
            if ( nDoneStart == 0 )
            {
               STRUP660( ) ;
            }
         }
      }

      protected void WS662( )
      {
         START662( ) ;
         EVT662( ) ;
      }

      protected void EVT662( )
      {
         sXEvt = cgiGet( "_EventName");
         if ( ( ( ( StringUtil.Len( sPrefix) == 0 ) ) || ( StringUtil.StringSearch( sXEvt, sPrefix, 1) > 0 ) ) && ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) && ! wbErr )
            {
               /* Read Web Panel buttons. */
               if ( context.wbHandled == 0 )
               {
                  if ( StringUtil.Len( sPrefix) == 0 )
                  {
                     sEvt = cgiGet( "_EventName");
                     EvtGridId = cgiGet( "_EventGridId");
                     EvtRowId = cgiGet( "_EventRowId");
                  }
                  if ( StringUtil.Len( sEvt) > 0 )
                  {
                     sEvtType = StringUtil.Left( sEvt, 1);
                     sEvt = StringUtil.Right( sEvt, (short)(StringUtil.Len( sEvt)-1));
                     if ( StringUtil.StrCmp(sEvtType, "E") == 0 )
                     {
                        sEvtType = StringUtil.Right( sEvt, 1);
                        if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                        {
                           sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                           if ( StringUtil.StrCmp(sEvt, "RFR") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP660( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP660( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E11662 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP660( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Load */
                                    E12662 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOUPDATE'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP660( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'DoUpdate' */
                                    E13662 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DODELETE'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP660( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'DoDelete' */
                                    E14662 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP660( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    if ( ! wbErr )
                                    {
                                       Rfr0gs = false;
                                       if ( ! Rfr0gs )
                                       {
                                       }
                                       dynload_actions( ) ;
                                    }
                                 }
                              }
                              /* No code required for Cancel button. It is implemented as the Reset button. */
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP660( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                 }
                              }
                              dynload_actions( ) ;
                           }
                        }
                        else
                        {
                        }
                     }
                     context.wbHandled = 1;
                  }
               }
            }
         }
      }

      protected void WE662( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseForm662( ) ;
            }
         }
      }

      protected void PA662( )
      {
         if ( nDonePA == 0 )
         {
            if ( StringUtil.Len( sPrefix) != 0 )
            {
               initialize_properties( ) ;
            }
            GXKey = Crypto.GetSiteKey( );
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               if ( ( StringUtil.StrCmp(context.GetRequestQueryString( ), "") != 0 ) && ( GxWebError == 0 ) && ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
               {
                  GXDecQS = UriDecrypt64( context.GetRequestQueryString( ), GXKey);
                  if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "zonasgeneral.aspx")), "zonasgeneral.aspx") == 0 ) )
                  {
                     SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "zonasgeneral.aspx")))) ;
                  }
                  else
                  {
                     GxWebError = 1;
                     context.HttpContext.Response.StatusDescription = 403.ToString();
                     context.HttpContext.Response.StatusCode = 403;
                     context.WriteHtmlText( "<title>403 Forbidden</title>") ;
                     context.WriteHtmlText( "<h1>403 Forbidden</h1>") ;
                     context.WriteHtmlText( "<p /><hr />") ;
                     GXUtil.WriteLog("send_http_error_code " + 403.ToString());
                  }
               }
            }
            if ( ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
            {
               if ( StringUtil.Len( sPrefix) == 0 )
               {
                  if ( nGotPars == 0 )
                  {
                     entryPointCalled = false;
                     gxfirstwebparm = GetFirstPar( "ZonasID");
                     toggleJsOutput = isJsOutputEnabled( );
                     if ( context.isSpaRequest( ) )
                     {
                        disableJsOutput();
                     }
                     if ( toggleJsOutput )
                     {
                        if ( context.isSpaRequest( ) )
                        {
                           enableJsOutput();
                        }
                     }
                  }
               }
            }
            toggleJsOutput = isJsOutputEnabled( );
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               if ( context.isSpaRequest( ) )
               {
                  disableJsOutput();
               }
            }
            init_web_controls( ) ;
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               if ( toggleJsOutput )
               {
                  if ( context.isSpaRequest( ) )
                  {
                     enableJsOutput();
                  }
               }
            }
            if ( ! context.isAjaxRequest( ) )
            {
            }
            nDonePA = 1;
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void GXDLADEPARTAMENTOID661( )
      {
         if ( ! context.isAjaxRequest( ) )
         {
            context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
         }
         AddString( "[[") ;
         GXDLADEPARTAMENTOID_data661( ) ;
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

      protected void GXADEPARTAMENTOID_html661( )
      {
         long gxdynajaxvalue;
         GXDLADEPARTAMENTOID_data661( ) ;
         gxdynajaxindex = 1;
         if ( ! ( gxdyncontrolsrefreshing && context.isAjaxRequest( ) ) )
         {
            dynDepartamentoId.removeAllItems();
         }
         while ( gxdynajaxindex <= gxdynajaxctrlcodr.Count )
         {
            gxdynajaxvalue = (long)(Math.Round(NumberUtil.Val( ((string)gxdynajaxctrlcodr.Item(gxdynajaxindex)), "."), 18, MidpointRounding.ToEven));
            dynDepartamentoId.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(gxdynajaxvalue), 18, 0)), ((string)gxdynajaxctrldescr.Item(gxdynajaxindex)), 0);
            gxdynajaxindex = (int)(gxdynajaxindex+1);
         }
         if ( dynDepartamentoId.ItemCount > 0 )
         {
            A112DepartamentoId = (long)(Math.Round(NumberUtil.Val( dynDepartamentoId.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A112DepartamentoId), 18, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "A112DepartamentoId", StringUtil.LTrimStr( (decimal)(A112DepartamentoId), 18, 0));
         }
      }

      protected void GXDLADEPARTAMENTOID_data661( )
      {
         gxdynajaxctrlcodr.Clear();
         gxdynajaxctrldescr.Clear();
         /* Using cursor H00662 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            gxdynajaxctrlcodr.Add(StringUtil.LTrim( StringUtil.NToC( (decimal)(H00662_A112DepartamentoId[0]), 18, 0, ".", "")));
            gxdynajaxctrldescr.Add(StringUtil.RTrim( H00662_A113DepartamentoDepartamento[0]));
            pr_default.readNext(0);
         }
         pr_default.close(0);
      }

      protected void GXDLADEPARTAMENTOMUNICIPIOID662( long A112DepartamentoId )
      {
         if ( ! context.isAjaxRequest( ) )
         {
            context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
         }
         AddString( "[[") ;
         GXDLADEPARTAMENTOMUNICIPIOID_data662( A112DepartamentoId) ;
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

      protected void GXADEPARTAMENTOMUNICIPIOID_html662( long A112DepartamentoId )
      {
         long gxdynajaxvalue;
         GXDLADEPARTAMENTOMUNICIPIOID_data662( A112DepartamentoId) ;
         gxdynajaxindex = 1;
         if ( ! ( gxdyncontrolsrefreshing && context.isAjaxRequest( ) ) )
         {
            dynDepartamentoMunicipioId.removeAllItems();
         }
         while ( gxdynajaxindex <= gxdynajaxctrlcodr.Count )
         {
            gxdynajaxvalue = (long)(Math.Round(NumberUtil.Val( ((string)gxdynajaxctrlcodr.Item(gxdynajaxindex)), "."), 18, MidpointRounding.ToEven));
            dynDepartamentoMunicipioId.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(gxdynajaxvalue), 18, 0)), ((string)gxdynajaxctrldescr.Item(gxdynajaxindex)), 0);
            gxdynajaxindex = (int)(gxdynajaxindex+1);
         }
         if ( dynDepartamentoMunicipioId.ItemCount > 0 )
         {
            A114DepartamentoMunicipioId = (long)(Math.Round(NumberUtil.Val( dynDepartamentoMunicipioId.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A114DepartamentoMunicipioId), 18, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "A114DepartamentoMunicipioId", StringUtil.LTrimStr( (decimal)(A114DepartamentoMunicipioId), 18, 0));
         }
      }

      protected void GXDLADEPARTAMENTOMUNICIPIOID_data662( long A112DepartamentoId )
      {
         gxdynajaxctrlcodr.Clear();
         gxdynajaxctrldescr.Clear();
         /* Using cursor H00663 */
         pr_default.execute(1, new Object[] {A112DepartamentoId});
         while ( (pr_default.getStatus(1) != 101) )
         {
            gxdynajaxctrlcodr.Add(StringUtil.LTrim( StringUtil.NToC( (decimal)(H00663_A114DepartamentoMunicipioId[0]), 18, 0, ".", "")));
            gxdynajaxctrldescr.Add(StringUtil.RTrim( H00663_A115DepartamentoMunicipioNombre[0]));
            pr_default.readNext(1);
         }
         pr_default.close(1);
      }

      protected void send_integrity_hashes( )
      {
      }

      protected void clear_multi_value_controls( )
      {
         if ( context.isAjaxRequest( ) )
         {
            GXADEPARTAMENTOMUNICIPIOID_html662( A112DepartamentoId) ;
            dynDepartamentoId.Name = "DEPARTAMENTOID";
            dynDepartamentoId.WebTags = "";
            dynDepartamentoId.removeAllItems();
            /* Using cursor H00664 */
            pr_default.execute(2);
            while ( (pr_default.getStatus(2) != 101) )
            {
               dynDepartamentoId.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(H00664_A112DepartamentoId[0]), 18, 0)), H00664_A113DepartamentoDepartamento[0], 0);
               pr_default.readNext(2);
            }
            pr_default.close(2);
            if ( dynDepartamentoId.ItemCount > 0 )
            {
               A112DepartamentoId = (long)(Math.Round(NumberUtil.Val( dynDepartamentoId.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A112DepartamentoId), 18, 0))), "."), 18, MidpointRounding.ToEven));
               AssignAttri(sPrefix, false, "A112DepartamentoId", StringUtil.LTrimStr( (decimal)(A112DepartamentoId), 18, 0));
            }
            dynload_actions( ) ;
            before_start_formulas( ) ;
         }
      }

      protected void fix_multi_value_controls( )
      {
         if ( dynDepartamentoId.ItemCount > 0 )
         {
            A112DepartamentoId = (long)(Math.Round(NumberUtil.Val( dynDepartamentoId.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A112DepartamentoId), 18, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "A112DepartamentoId", StringUtil.LTrimStr( (decimal)(A112DepartamentoId), 18, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            dynDepartamentoId.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A112DepartamentoId), 18, 0));
            AssignProp(sPrefix, false, dynDepartamentoId_Internalname, "Values", dynDepartamentoId.ToJavascriptSource(), true);
         }
         if ( dynDepartamentoMunicipioId.ItemCount > 0 )
         {
            A114DepartamentoMunicipioId = (long)(Math.Round(NumberUtil.Val( dynDepartamentoMunicipioId.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A114DepartamentoMunicipioId), 18, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "A114DepartamentoMunicipioId", StringUtil.LTrimStr( (decimal)(A114DepartamentoMunicipioId), 18, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            dynDepartamentoMunicipioId.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A114DepartamentoMunicipioId), 18, 0));
            AssignProp(sPrefix, false, dynDepartamentoMunicipioId_Internalname, "Values", dynDepartamentoMunicipioId.ToJavascriptSource(), true);
         }
         if ( cmbZonasEstado.ItemCount > 0 )
         {
            A906ZonasEstado = cmbZonasEstado.getValidValue(A906ZonasEstado);
            n906ZonasEstado = false;
            AssignAttri(sPrefix, false, "A906ZonasEstado", A906ZonasEstado);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbZonasEstado.CurrentValue = StringUtil.RTrim( A906ZonasEstado);
            AssignProp(sPrefix, false, cmbZonasEstado_Internalname, "Values", cmbZonasEstado.ToJavascriptSource(), true);
         }
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF662( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV13Pgmname = "ZonasGeneral";
      }

      protected void RF662( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Using cursor H00665 */
            pr_default.execute(3, new Object[] {A110ZonasID, A112DepartamentoId, A114DepartamentoMunicipioId});
            while ( (pr_default.getStatus(3) != 101) )
            {
               A906ZonasEstado = H00665_A906ZonasEstado[0];
               n906ZonasEstado = H00665_n906ZonasEstado[0];
               AssignAttri(sPrefix, false, "A906ZonasEstado", A906ZonasEstado);
               A111ZonasNombre = H00665_A111ZonasNombre[0];
               AssignAttri(sPrefix, false, "A111ZonasNombre", A111ZonasNombre);
               GXADEPARTAMENTOMUNICIPIOID_html662( A112DepartamentoId) ;
               /* Execute user event: Load */
               E12662 ();
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(3);
            WB660( ) ;
         }
      }

      protected void send_integrity_lvl_hashes662( )
      {
      }

      protected void before_start_formulas( )
      {
         AV13Pgmname = "ZonasGeneral";
         GXADEPARTAMENTOMUNICIPIOID_html662( A112DepartamentoId) ;
         dynDepartamentoId.Enabled = 0;
         AssignProp(sPrefix, false, dynDepartamentoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynDepartamentoId.Enabled), 5, 0), true);
         dynDepartamentoMunicipioId.Enabled = 0;
         AssignProp(sPrefix, false, dynDepartamentoMunicipioId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynDepartamentoMunicipioId.Enabled), 5, 0), true);
         edtZonasID_Enabled = 0;
         AssignProp(sPrefix, false, edtZonasID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtZonasID_Enabled), 5, 0), true);
         edtZonasNombre_Enabled = 0;
         AssignProp(sPrefix, false, edtZonasNombre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtZonasNombre_Enabled), 5, 0), true);
         cmbZonasEstado.Enabled = 0;
         AssignProp(sPrefix, false, cmbZonasEstado_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbZonasEstado.Enabled), 5, 0), true);
         fix_multi_value_controls( ) ;
      }

      protected void STRUP660( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E11662 ();
         context.wbGlbDoneStart = 1;
         nDoneStart = 1;
         /* After Start, stand alone formulas. */
         sXEvt = cgiGet( "_EventName");
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            wcpOA110ZonasID = (long)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"wcpOA110ZonasID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            wcpOA112DepartamentoId = (long)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"wcpOA112DepartamentoId"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            wcpOA114DepartamentoMunicipioId = (long)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"wcpOA114DepartamentoMunicipioId"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            /* Read variables values. */
            A111ZonasNombre = cgiGet( edtZonasNombre_Internalname);
            AssignAttri(sPrefix, false, "A111ZonasNombre", A111ZonasNombre);
            cmbZonasEstado.CurrentValue = cgiGet( cmbZonasEstado_Internalname);
            A906ZonasEstado = cgiGet( cmbZonasEstado_Internalname);
            n906ZonasEstado = false;
            AssignAttri(sPrefix, false, "A906ZonasEstado", A906ZonasEstado);
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Crypto.GetSiteKey( );
            GXADEPARTAMENTOMUNICIPIOID_html662( A112DepartamentoId) ;
         }
         else
         {
            dynload_actions( ) ;
         }
      }

      protected void GXStart( )
      {
         /* Execute user event: Start */
         E11662 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E11662( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV6WWPContext) ;
         /* Execute user subroutine: 'PREPARETRANSACTION' */
         S112 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void nextLoad( )
      {
      }

      protected void E12662( )
      {
         /* Load Routine */
         returnInSub = false;
         GXt_boolean1 = AV12TempBoolean;
         new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWZonas_Update", out  GXt_boolean1) ;
         AV12TempBoolean = GXt_boolean1;
         if ( ! ( AV12TempBoolean ) )
         {
            bttBtnupdate_Visible = 0;
            AssignProp(sPrefix, false, bttBtnupdate_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtnupdate_Visible), 5, 0), true);
         }
         GXt_boolean1 = AV12TempBoolean;
         new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWZonas_Delete", out  GXt_boolean1) ;
         AV12TempBoolean = GXt_boolean1;
         if ( ! ( AV12TempBoolean ) )
         {
            bttBtndelete_Visible = 0;
            AssignProp(sPrefix, false, bttBtndelete_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtndelete_Visible), 5, 0), true);
         }
      }

      protected void E13662( )
      {
         /* 'DoUpdate' Routine */
         returnInSub = false;
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "zonas.aspx"+UrlEncode(StringUtil.RTrim("UPD")) + "," + UrlEncode(StringUtil.LTrimStr(A112DepartamentoId,18,0)) + "," + UrlEncode(StringUtil.LTrimStr(A114DepartamentoMunicipioId,18,0)) + "," + UrlEncode(StringUtil.LTrimStr(A110ZonasID,18,0));
         CallWebObject(formatLink("zonas.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
         context.wjLocDisableFrm = 1;
      }

      protected void E14662( )
      {
         /* 'DoDelete' Routine */
         returnInSub = false;
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "zonas.aspx"+UrlEncode(StringUtil.RTrim("DLT")) + "," + UrlEncode(StringUtil.LTrimStr(A112DepartamentoId,18,0)) + "," + UrlEncode(StringUtil.LTrimStr(A114DepartamentoMunicipioId,18,0)) + "," + UrlEncode(StringUtil.LTrimStr(A110ZonasID,18,0));
         CallWebObject(formatLink("zonas.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
         context.wjLocDisableFrm = 1;
      }

      protected void S112( )
      {
         /* 'PREPARETRANSACTION' Routine */
         returnInSub = false;
         AV8TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV8TrnContext.gxTpr_Callerobject = AV13Pgmname;
         AV8TrnContext.gxTpr_Callerondelete = false;
         AV8TrnContext.gxTpr_Callerurl = AV11HTTPRequest.ScriptName+"?"+AV11HTTPRequest.QueryString;
         AV8TrnContext.gxTpr_Transactionname = "Zonas";
         AV10Session.Set("TrnContext", AV8TrnContext.ToXml(false, true, "", ""));
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         A110ZonasID = Convert.ToInt64(getParm(obj,0));
         AssignAttri(sPrefix, false, "A110ZonasID", StringUtil.LTrimStr( (decimal)(A110ZonasID), 18, 0));
         A112DepartamentoId = Convert.ToInt64(getParm(obj,1));
         AssignAttri(sPrefix, false, "A112DepartamentoId", StringUtil.LTrimStr( (decimal)(A112DepartamentoId), 18, 0));
         A114DepartamentoMunicipioId = Convert.ToInt64(getParm(obj,2));
         AssignAttri(sPrefix, false, "A114DepartamentoMunicipioId", StringUtil.LTrimStr( (decimal)(A114DepartamentoMunicipioId), 18, 0));
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
         PA662( ) ;
         WS662( ) ;
         WE662( ) ;
         cleanup();
         context.SetWrapped(false);
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
         return "";
      }

      public void responsestatic( string sGXDynURL )
      {
      }

      protected override EncryptionType GetEncryptionType( )
      {
         return EncryptionType.SITE ;
      }

      public override void componentbind( Object[] obj )
      {
         if ( IsUrlCreated( ) )
         {
            return  ;
         }
         sCtrlA110ZonasID = (string)((string)getParm(obj,0));
         sCtrlA112DepartamentoId = (string)((string)getParm(obj,1));
         sCtrlA114DepartamentoMunicipioId = (string)((string)getParm(obj,2));
      }

      public override void componentrestorestate( string sPPrefix ,
                                                  string sPSFPrefix )
      {
         sPrefix = sPPrefix + sPSFPrefix;
         PA662( ) ;
         WCParametersGet( ) ;
      }

      public override void componentprepare( Object[] obj )
      {
         wbLoad = false;
         sCompPrefix = (string)getParm(obj,0);
         sSFPrefix = (string)getParm(obj,1);
         sPrefix = sCompPrefix + sSFPrefix;
         AddComponentObject(sPrefix, "zonasgeneral", GetJustCreated( ));
         if ( ( nDoneStart == 0 ) && ( nDynComponent == 0 ) )
         {
            INITWEB( ) ;
         }
         else
         {
            init_default_properties( ) ;
            init_web_controls( ) ;
         }
         PA662( ) ;
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) && ( context.wbGlbDoneStart == 0 ) )
         {
            WCParametersGet( ) ;
         }
         else
         {
            A110ZonasID = Convert.ToInt64(getParm(obj,2));
            AssignAttri(sPrefix, false, "A110ZonasID", StringUtil.LTrimStr( (decimal)(A110ZonasID), 18, 0));
            A112DepartamentoId = Convert.ToInt64(getParm(obj,3));
            AssignAttri(sPrefix, false, "A112DepartamentoId", StringUtil.LTrimStr( (decimal)(A112DepartamentoId), 18, 0));
            A114DepartamentoMunicipioId = Convert.ToInt64(getParm(obj,4));
            AssignAttri(sPrefix, false, "A114DepartamentoMunicipioId", StringUtil.LTrimStr( (decimal)(A114DepartamentoMunicipioId), 18, 0));
         }
         wcpOA110ZonasID = (long)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"wcpOA110ZonasID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         wcpOA112DepartamentoId = (long)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"wcpOA112DepartamentoId"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         wcpOA114DepartamentoMunicipioId = (long)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"wcpOA114DepartamentoMunicipioId"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         if ( ! GetJustCreated( ) && ( ( A110ZonasID != wcpOA110ZonasID ) || ( A112DepartamentoId != wcpOA112DepartamentoId ) || ( A114DepartamentoMunicipioId != wcpOA114DepartamentoMunicipioId ) ) )
         {
            setjustcreated();
         }
         wcpOA110ZonasID = A110ZonasID;
         wcpOA112DepartamentoId = A112DepartamentoId;
         wcpOA114DepartamentoMunicipioId = A114DepartamentoMunicipioId;
      }

      protected void WCParametersGet( )
      {
         /* Read Component Parameters. */
         sCtrlA110ZonasID = cgiGet( sPrefix+"A110ZonasID_CTRL");
         if ( StringUtil.Len( sCtrlA110ZonasID) > 0 )
         {
            A110ZonasID = (long)(Math.Round(context.localUtil.CToN( cgiGet( sCtrlA110ZonasID), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "A110ZonasID", StringUtil.LTrimStr( (decimal)(A110ZonasID), 18, 0));
         }
         else
         {
            A110ZonasID = (long)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"A110ZonasID_PARM"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         }
         sCtrlA112DepartamentoId = cgiGet( sPrefix+"A112DepartamentoId_CTRL");
         if ( StringUtil.Len( sCtrlA112DepartamentoId) > 0 )
         {
            A112DepartamentoId = (long)(Math.Round(context.localUtil.CToN( cgiGet( sCtrlA112DepartamentoId), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "A112DepartamentoId", StringUtil.LTrimStr( (decimal)(A112DepartamentoId), 18, 0));
         }
         else
         {
            A112DepartamentoId = (long)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"A112DepartamentoId_PARM"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         }
         sCtrlA114DepartamentoMunicipioId = cgiGet( sPrefix+"A114DepartamentoMunicipioId_CTRL");
         if ( StringUtil.Len( sCtrlA114DepartamentoMunicipioId) > 0 )
         {
            A114DepartamentoMunicipioId = (long)(Math.Round(context.localUtil.CToN( cgiGet( sCtrlA114DepartamentoMunicipioId), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "A114DepartamentoMunicipioId", StringUtil.LTrimStr( (decimal)(A114DepartamentoMunicipioId), 18, 0));
         }
         else
         {
            A114DepartamentoMunicipioId = (long)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"A114DepartamentoMunicipioId_PARM"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         }
      }

      public override void componentprocess( string sPPrefix ,
                                             string sPSFPrefix ,
                                             string sCompEvt )
      {
         sCompPrefix = sPPrefix;
         sSFPrefix = sPSFPrefix;
         sPrefix = sCompPrefix + sSFPrefix;
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         INITWEB( ) ;
         nDraw = 0;
         PA662( ) ;
         sEvt = sCompEvt;
         WCParametersGet( ) ;
         WS662( ) ;
         if ( isFullAjaxMode( ) )
         {
            componentdraw();
         }
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      public override void componentstart( )
      {
         if ( nDoneStart == 0 )
         {
            WCStart( ) ;
         }
      }

      protected void WCStart( )
      {
         nDraw = 1;
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         WS662( ) ;
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      protected void WCParametersSet( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"A110ZonasID_PARM", StringUtil.LTrim( StringUtil.NToC( (decimal)(A110ZonasID), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlA110ZonasID)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"A110ZonasID_CTRL", StringUtil.RTrim( sCtrlA110ZonasID));
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"A112DepartamentoId_PARM", StringUtil.LTrim( StringUtil.NToC( (decimal)(A112DepartamentoId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlA112DepartamentoId)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"A112DepartamentoId_CTRL", StringUtil.RTrim( sCtrlA112DepartamentoId));
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"A114DepartamentoMunicipioId_PARM", StringUtil.LTrim( StringUtil.NToC( (decimal)(A114DepartamentoMunicipioId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlA114DepartamentoMunicipioId)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"A114DepartamentoMunicipioId_CTRL", StringUtil.RTrim( sCtrlA114DepartamentoMunicipioId));
         }
      }

      public override void componentdraw( )
      {
         if ( nDoneStart == 0 )
         {
            WCStart( ) ;
         }
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         WCParametersSet( ) ;
         WE662( ) ;
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      public override string getstring( string sGXControl )
      {
         string sCtrlName;
         if ( StringUtil.StrCmp(StringUtil.Substring( sGXControl, 1, 1), "&") == 0 )
         {
            sCtrlName = StringUtil.Substring( sGXControl, 2, StringUtil.Len( sGXControl)-1);
         }
         else
         {
            sCtrlName = sGXControl;
         }
         return cgiGet( sPrefix+"v"+StringUtil.Upper( sCtrlName)) ;
      }

      public override void componentjscripts( )
      {
         include_jscripts( ) ;
      }

      public override void componentthemes( )
      {
         define_styles( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202673021104671", true, true, false);
            idxLst = (int)(idxLst+1);
         }
         if ( ! outputEnabled )
         {
            if ( context.isSpaRequest( ) )
            {
               disableOutput();
            }
         }
         CloseStyles();
         /* End function define_styles */
      }

      protected void include_jscripts( )
      {
         context.AddJavascriptSource("zonasgeneral.js", "?202673021104671", false, true, false);
         /* End function include_jscripts */
      }

      protected void init_web_controls( )
      {
         dynDepartamentoId.Name = "DEPARTAMENTOID";
         dynDepartamentoId.WebTags = "";
         dynDepartamentoId.removeAllItems();
         /* Using cursor H00666 */
         pr_default.execute(4);
         while ( (pr_default.getStatus(4) != 101) )
         {
            dynDepartamentoId.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(H00666_A112DepartamentoId[0]), 18, 0)), H00666_A113DepartamentoDepartamento[0], 0);
            pr_default.readNext(4);
         }
         pr_default.close(4);
         if ( dynDepartamentoId.ItemCount > 0 )
         {
         }
         dynDepartamentoMunicipioId.Name = "DEPARTAMENTOMUNICIPIOID";
         dynDepartamentoMunicipioId.WebTags = "";
         cmbZonasEstado.Name = "ZONASESTADO";
         cmbZonasEstado.WebTags = "";
         cmbZonasEstado.addItem("HAB", context.GetMessage( "Habilitado", ""), 0);
         cmbZonasEstado.addItem("DES", context.GetMessage( "Deshabilitado", ""), 0);
         if ( cmbZonasEstado.ItemCount > 0 )
         {
         }
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         dynDepartamentoId_Internalname = sPrefix+"DEPARTAMENTOID";
         dynDepartamentoMunicipioId_Internalname = sPrefix+"DEPARTAMENTOMUNICIPIOID";
         edtZonasID_Internalname = sPrefix+"ZONASID";
         edtZonasNombre_Internalname = sPrefix+"ZONASNOMBRE";
         cmbZonasEstado_Internalname = sPrefix+"ZONASESTADO";
         divTransactiondetail_tableattributes_Internalname = sPrefix+"TRANSACTIONDETAIL_TABLEATTRIBUTES";
         bttBtnupdate_Internalname = sPrefix+"BTNUPDATE";
         bttBtndelete_Internalname = sPrefix+"BTNDELETE";
         divTable_Internalname = sPrefix+"TABLE";
         divLayoutmaintable_Internalname = sPrefix+"LAYOUTMAINTABLE";
         Form.Internalname = sPrefix+"FORM";
      }

      public override void initialize_properties( )
      {
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            context.SetDefaultTheme("WorkWithPlusDS", true);
         }
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( context.isSpaRequest( ) )
            {
               disableJsOutput();
            }
         }
         init_default_properties( ) ;
         bttBtndelete_Visible = 1;
         bttBtnupdate_Visible = 1;
         cmbZonasEstado_Jsonclick = "";
         cmbZonasEstado.Enabled = 0;
         edtZonasNombre_Jsonclick = "";
         edtZonasNombre_Enabled = 0;
         edtZonasID_Jsonclick = "";
         edtZonasID_Enabled = 0;
         dynDepartamentoMunicipioId_Jsonclick = "";
         dynDepartamentoMunicipioId.Enabled = 0;
         dynDepartamentoId_Jsonclick = "";
         dynDepartamentoId.Enabled = 0;
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( context.isSpaRequest( ) )
            {
               enableJsOutput();
            }
         }
      }

      public void Valid_Departamentoid( )
      {
         A112DepartamentoId = (long)(Math.Round(NumberUtil.Val( dynDepartamentoId.CurrentValue, "."), 18, MidpointRounding.ToEven));
         A114DepartamentoMunicipioId = (long)(Math.Round(NumberUtil.Val( dynDepartamentoMunicipioId.CurrentValue, "."), 18, MidpointRounding.ToEven));
         GXADEPARTAMENTOMUNICIPIOID_html662( A112DepartamentoId) ;
         dynload_actions( ) ;
         if ( dynDepartamentoMunicipioId.ItemCount > 0 )
         {
            A114DepartamentoMunicipioId = (long)(Math.Round(NumberUtil.Val( dynDepartamentoMunicipioId.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A114DepartamentoMunicipioId), 18, 0))), "."), 18, MidpointRounding.ToEven));
         }
         if ( context.isAjaxRequest( ) )
         {
            dynDepartamentoMunicipioId.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A114DepartamentoMunicipioId), 18, 0));
         }
         /*  Sending validation outputs */
         AssignAttri(sPrefix, false, "A114DepartamentoMunicipioId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A114DepartamentoMunicipioId), 18, 0, ".", "")));
         dynDepartamentoMunicipioId.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A114DepartamentoMunicipioId), 18, 0));
         AssignProp(sPrefix, false, dynDepartamentoMunicipioId_Internalname, "Values", dynDepartamentoMunicipioId.ToJavascriptSource(), true);
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'A110ZonasID',fld:'ZONASID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'dynDepartamentoId'},{av:'A112DepartamentoId',fld:'DEPARTAMENTOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'dynDepartamentoMunicipioId'},{av:'A114DepartamentoMunicipioId',fld:'DEPARTAMENTOMUNICIPIOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("'DOUPDATE'","{handler:'E13662',iparms:[{av:'dynDepartamentoId'},{av:'A112DepartamentoId',fld:'DEPARTAMENTOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'dynDepartamentoMunicipioId'},{av:'A114DepartamentoMunicipioId',fld:'DEPARTAMENTOMUNICIPIOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'A110ZonasID',fld:'ZONASID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'}]");
         setEventMetadata("'DOUPDATE'",",oparms:[]}");
         setEventMetadata("'DODELETE'","{handler:'E14662',iparms:[{av:'dynDepartamentoId'},{av:'A112DepartamentoId',fld:'DEPARTAMENTOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'dynDepartamentoMunicipioId'},{av:'A114DepartamentoMunicipioId',fld:'DEPARTAMENTOMUNICIPIOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'A110ZonasID',fld:'ZONASID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'}]");
         setEventMetadata("'DODELETE'",",oparms:[]}");
         setEventMetadata("VALID_DEPARTAMENTOID","{handler:'Valid_Departamentoid',iparms:[{av:'dynDepartamentoId'},{av:'A112DepartamentoId',fld:'DEPARTAMENTOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'dynDepartamentoMunicipioId'},{av:'A114DepartamentoMunicipioId',fld:'DEPARTAMENTOMUNICIPIOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'}]");
         setEventMetadata("VALID_DEPARTAMENTOID",",oparms:[{av:'dynDepartamentoMunicipioId'},{av:'A114DepartamentoMunicipioId',fld:'DEPARTAMENTOMUNICIPIOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'}]}");
         setEventMetadata("VALID_DEPARTAMENTOMUNICIPIOID","{handler:'Valid_Departamentomunicipioid',iparms:[]");
         setEventMetadata("VALID_DEPARTAMENTOMUNICIPIOID",",oparms:[]}");
         setEventMetadata("VALID_ZONASID","{handler:'Valid_Zonasid',iparms:[]");
         setEventMetadata("VALID_ZONASID",",oparms:[]}");
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
         sPrefix = "";
         AV13Pgmname = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GXEncryptionTmp = "";
         GX_FocusControl = "";
         TempTags = "";
         A111ZonasNombre = "";
         A906ZonasEstado = "";
         ClassString = "";
         StyleString = "";
         bttBtnupdate_Jsonclick = "";
         bttBtndelete_Jsonclick = "";
         Form = new GXWebForm();
         sXEvt = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         GXDecQS = "";
         gxdynajaxctrlcodr = new GeneXus.Utils.GxStringCollection();
         gxdynajaxctrldescr = new GeneXus.Utils.GxStringCollection();
         gxwrpcisep = "";
         H00662_A112DepartamentoId = new long[1] ;
         H00662_A113DepartamentoDepartamento = new string[] {""} ;
         H00663_A112DepartamentoId = new long[1] ;
         H00663_A114DepartamentoMunicipioId = new long[1] ;
         H00663_A115DepartamentoMunicipioNombre = new string[] {""} ;
         H00664_A112DepartamentoId = new long[1] ;
         H00664_A113DepartamentoDepartamento = new string[] {""} ;
         H00665_A110ZonasID = new long[1] ;
         H00665_A112DepartamentoId = new long[1] ;
         H00665_A114DepartamentoMunicipioId = new long[1] ;
         H00665_A906ZonasEstado = new string[] {""} ;
         H00665_n906ZonasEstado = new bool[] {false} ;
         H00665_A111ZonasNombre = new string[] {""} ;
         AV6WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV8TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV11HTTPRequest = new GxHttpRequest( context);
         AV10Session = context.GetSession();
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         sCtrlA110ZonasID = "";
         sCtrlA112DepartamentoId = "";
         sCtrlA114DepartamentoMunicipioId = "";
         H00666_A112DepartamentoId = new long[1] ;
         H00666_A113DepartamentoDepartamento = new string[] {""} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.zonasgeneral__default(),
            new Object[][] {
                new Object[] {
               H00662_A112DepartamentoId, H00662_A113DepartamentoDepartamento
               }
               , new Object[] {
               H00663_A112DepartamentoId, H00663_A114DepartamentoMunicipioId, H00663_A115DepartamentoMunicipioNombre
               }
               , new Object[] {
               H00664_A112DepartamentoId, H00664_A113DepartamentoDepartamento
               }
               , new Object[] {
               H00665_A110ZonasID, H00665_A112DepartamentoId, H00665_A114DepartamentoMunicipioId, H00665_A906ZonasEstado, H00665_n906ZonasEstado, H00665_A111ZonasNombre
               }
               , new Object[] {
               H00666_A112DepartamentoId, H00666_A113DepartamentoDepartamento
               }
            }
         );
         AV13Pgmname = "ZonasGeneral";
         /* GeneXus formulas. */
         AV13Pgmname = "ZonasGeneral";
      }

      private short nGotPars ;
      private short GxWebError ;
      private short nDynComponent ;
      private short wbEnd ;
      private short wbStart ;
      private short nDraw ;
      private short nDoneStart ;
      private short nDonePA ;
      private short nGXWrapped ;
      private int edtZonasID_Enabled ;
      private int edtZonasNombre_Enabled ;
      private int bttBtnupdate_Visible ;
      private int bttBtndelete_Visible ;
      private int gxdynajaxindex ;
      private int idxLst ;
      private long A110ZonasID ;
      private long A112DepartamentoId ;
      private long A114DepartamentoMunicipioId ;
      private long wcpOA110ZonasID ;
      private long wcpOA112DepartamentoId ;
      private long wcpOA114DepartamentoMunicipioId ;
      private long Z114DepartamentoMunicipioId ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sPrefix ;
      private string sCompPrefix ;
      private string sSFPrefix ;
      private string AV13Pgmname ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GXEncryptionTmp ;
      private string GX_FocusControl ;
      private string divLayoutmaintable_Internalname ;
      private string divTable_Internalname ;
      private string divTransactiondetail_tableattributes_Internalname ;
      private string dynDepartamentoId_Internalname ;
      private string TempTags ;
      private string dynDepartamentoId_Jsonclick ;
      private string dynDepartamentoMunicipioId_Internalname ;
      private string dynDepartamentoMunicipioId_Jsonclick ;
      private string edtZonasID_Internalname ;
      private string edtZonasID_Jsonclick ;
      private string edtZonasNombre_Internalname ;
      private string A111ZonasNombre ;
      private string edtZonasNombre_Jsonclick ;
      private string cmbZonasEstado_Internalname ;
      private string A906ZonasEstado ;
      private string cmbZonasEstado_Jsonclick ;
      private string ClassString ;
      private string StyleString ;
      private string bttBtnupdate_Internalname ;
      private string bttBtnupdate_Jsonclick ;
      private string bttBtndelete_Internalname ;
      private string bttBtndelete_Jsonclick ;
      private string sXEvt ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string GXDecQS ;
      private string gxwrpcisep ;
      private string sCtrlA110ZonasID ;
      private string sCtrlA112DepartamentoId ;
      private string sCtrlA114DepartamentoMunicipioId ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool n906ZonasEstado ;
      private bool returnInSub ;
      private bool AV12TempBoolean ;
      private bool GXt_boolean1 ;
      private GeneXus.Utils.GxStringCollection gxdynajaxctrlcodr ;
      private GeneXus.Utils.GxStringCollection gxdynajaxctrldescr ;
      private GXWebForm Form ;
      private GxHttpRequest AV11HTTPRequest ;
      private IGxSession AV10Session ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GXCombobox dynDepartamentoId ;
      private GXCombobox dynDepartamentoMunicipioId ;
      private GXCombobox cmbZonasEstado ;
      private IDataStoreProvider pr_default ;
      private long[] H00662_A112DepartamentoId ;
      private string[] H00662_A113DepartamentoDepartamento ;
      private long[] H00663_A112DepartamentoId ;
      private long[] H00663_A114DepartamentoMunicipioId ;
      private string[] H00663_A115DepartamentoMunicipioNombre ;
      private long[] H00664_A112DepartamentoId ;
      private string[] H00664_A113DepartamentoDepartamento ;
      private long[] H00665_A110ZonasID ;
      private long[] H00665_A112DepartamentoId ;
      private long[] H00665_A114DepartamentoMunicipioId ;
      private string[] H00665_A906ZonasEstado ;
      private bool[] H00665_n906ZonasEstado ;
      private string[] H00665_A111ZonasNombre ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV6WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV8TrnContext ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private long[] H00666_A112DepartamentoId ;
      private string[] H00666_A113DepartamentoDepartamento ;
   }

   public class zonasgeneral__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
         ,new ForEachCursor(def[2])
         ,new ForEachCursor(def[3])
         ,new ForEachCursor(def[4])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmH00662;
          prmH00662 = new Object[] {
          };
          Object[] prmH00663;
          prmH00663 = new Object[] {
          new ParDef("@DepartamentoId",GXType.Decimal,18,0)
          };
          Object[] prmH00664;
          prmH00664 = new Object[] {
          };
          Object[] prmH00665;
          prmH00665 = new Object[] {
          new ParDef("@ZonasID",GXType.Decimal,18,0) ,
          new ParDef("@DepartamentoId",GXType.Decimal,18,0) ,
          new ParDef("@DepartamentoMunicipioId",GXType.Decimal,18,0)
          };
          Object[] prmH00666;
          prmH00666 = new Object[] {
          };
          def= new CursorDef[] {
              new CursorDef("H00662", "SELECT [DepartamentoId], [DepartamentoDepartamento] FROM [Departamento] ORDER BY [DepartamentoDepartamento] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00662,0, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H00663", "SELECT [DepartamentoId], [DepartamentoMunicipioId], [DepartamentoMunicipioNombre] FROM [DepartamentoMunicipio] WHERE ([DepartamentoId] = @DepartamentoId) AND ([DepartamentoMunicipioId] < 9999) ORDER BY [DepartamentoMunicipioNombre] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00663,0, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H00664", "SELECT [DepartamentoId], [DepartamentoDepartamento] FROM [Departamento] ORDER BY [DepartamentoDepartamento] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00664,0, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H00665", "SELECT [ZonasID], [DepartamentoId], [DepartamentoMunicipioId], [ZonasEstado], [ZonasNombre] FROM [Zonas] WHERE [ZonasID] = @ZonasID and [DepartamentoId] = @DepartamentoId and [DepartamentoMunicipioId] = @DepartamentoMunicipioId ORDER BY [ZonasID], [DepartamentoId], [DepartamentoMunicipioId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00665,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("H00666", "SELECT [DepartamentoId], [DepartamentoDepartamento] FROM [Departamento] ORDER BY [DepartamentoDepartamento] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00666,0, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[1])[0] = rslt.getString(2, 80);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((long[]) buf[1])[0] = rslt.getLong(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 120);
                return;
             case 2 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 80);
                return;
             case 3 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((long[]) buf[1])[0] = rslt.getLong(2);
                ((long[]) buf[2])[0] = rslt.getLong(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 3);
                ((bool[]) buf[4])[0] = rslt.wasNull(4);
                ((string[]) buf[5])[0] = rslt.getString(5, 120);
                return;
             case 4 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 80);
                return;
       }
    }

 }

}

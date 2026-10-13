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
   public class capacidadproductiva : GXDataArea, System.Web.SessionState.IRequiresSessionState
   {
      protected void INITENV( )
      {
         if ( GxWebError != 0 )
         {
            return  ;
         }
      }

      protected void INITTRN( )
      {
         initialize_properties( ) ;
         entryPointCalled = false;
         gxfirstwebparm = GetNextPar( );
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_2") == 0 )
         {
            A112DepartamentoId = (long)(Math.Round(NumberUtil.Val( GetPar( "DepartamentoId"), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A112DepartamentoId", StringUtil.LTrimStr( (decimal)(A112DepartamentoId), 18, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_2( A112DepartamentoId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_3") == 0 )
         {
            A121RubrosId = (short)(Math.Round(NumberUtil.Val( GetPar( "RubrosId"), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A121RubrosId", StringUtil.LTrimStr( (decimal)(A121RubrosId), 4, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_3( A121RubrosId) ;
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
            gxfirstwebparm = GetNextPar( );
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
         {
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxfirstwebparm = GetNextPar( );
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
         GXKey = Crypto.GetSiteKey( );
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
         if ( ! context.isSpaRequest( ) )
         {
            if ( context.ExposeMetadata( ) )
            {
               Form.Meta.addItem("generator", "GeneXus .NET Framework 18_0_15-188745", 0) ;
            }
         }
         Form.Meta.addItem("description", context.GetMessage( "Capacidad Productiva", ""), 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtCapacidadProdId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public capacidadproductiva( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public capacidadproductiva( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( )
      {
         ExecutePrivate();
      }

      protected override void ExecutePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
      }

      public override void webExecute( )
      {
         createObjects();
         initialize();
         INITENV( ) ;
         INITTRN( ) ;
         if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
         {
            MasterPageObj = (GXMasterPage) ClassLoader.GetInstance("wwpbaseobjects.workwithplusmasterpage", "GeneXus.Programs.wwpbaseobjects.workwithplusmasterpage", new Object[] {context});
            MasterPageObj.setDataArea(this,false);
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

      protected void fix_multi_value_controls( )
      {
      }

      protected void Draw( )
      {
         if ( context.isAjaxRequest( ) )
         {
            disableOutput();
         }
         if ( ! GxWebStd.gx_redirect( context) )
         {
            disable_std_buttons( ) ;
            enableDisable( ) ;
            set_caption( ) ;
            /* Form start */
            DrawControls( ) ;
            fix_multi_value_controls( ) ;
         }
         /* Execute Exit event if defined. */
      }

      protected void DrawControls( )
      {
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "start", "top", " "+"data-gx-base-lib=\"bootstrapv3\""+" "+"data-abstract-form"+" ", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divMaintable_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTitlecontainer_Internalname, 1, 0, "px", 0, "px", "title-container", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, context.GetMessage( "Capacidad Productiva", ""), "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "heading-01", 0, "", 1, 1, 0, 0, "HLP_CapacidadProductiva.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         ClassString = "ErrorViewer";
         StyleString = "";
         GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, StyleString, ClassString, "", "false");
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
         GxWebStd.gx_div_start( context, divFormcontainer_Internalname, 1, 0, "px", 0, "px", "form-container", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divToolbarcell_Internalname, 1, 0, "px", 0, "px", "col-xs-12 col-sm-9 col-sm-offset-3 form__toolbar-cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-action-group ActionGroup", "start", "top", " "+"data-gx-actiongroup-type=\"toolbar\""+" ", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "btn-group", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 21,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-first";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "", bttBtn_first_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_CapacidadProductiva.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-prev";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "", bttBtn_previous_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_CapacidadProductiva.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-next";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", "", bttBtn_next_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_CapacidadProductiva.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-last";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", "", bttBtn_last_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_CapacidadProductiva.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'',0)\"";
         ClassString = "Button button-secondary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", context.GetMessage( "GX_BtnSelect", ""), bttBtn_select_Jsonclick, 4, context.GetMessage( "GX_BtnSelect", ""), "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "gx.popup.openPrompt('"+"gx03e0.aspx"+"',["+"{Ctrl:gx.dom.el('"+"CAPACIDADPRODID"+"'), id:'"+"CAPACIDADPRODID"+"'"+",IOType:'out',isKey:true,isLastKey:true}"+"],"+"null"+","+"'', false"+","+"true"+");"+"return false;", 2, "HLP_CapacidadProductiva.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell-advanced", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtCapacidadProdId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCapacidadProdId_Internalname, context.GetMessage( "Prod Id", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCapacidadProdId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A804CapacidadProdId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtCapacidadProdId_Enabled!=0) ? context.localUtil.Format( (decimal)(A804CapacidadProdId), "ZZZZZZZZZZZZZZZZZ9") : context.localUtil.Format( (decimal)(A804CapacidadProdId), "ZZZZZZZZZZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,34);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCapacidadProdId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCapacidadProdId_Enabled, 0, "text", "1", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "Id", "end", false, "", "HLP_CapacidadProductiva.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtCapacidadProdTotal_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCapacidadProdTotal_Internalname, context.GetMessage( "Prod Total", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCapacidadProdTotal_Internalname, StringUtil.LTrim( StringUtil.NToC( A805CapacidadProdTotal, 22, 2, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtCapacidadProdTotal_Enabled!=0) ? context.localUtil.Format( A805CapacidadProdTotal, "ZZZ,ZZZ,ZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( A805CapacidadProdTotal, "ZZZ,ZZZ,ZZZ,ZZZ,ZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onblur(this,39);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCapacidadProdTotal_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCapacidadProdTotal_Enabled, 0, "text", "", 22, "chr", 1, "row", 22, 0, 0, 0, 0, -1, 0, true, "Total", "end", false, "", "HLP_CapacidadProductiva.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtDepartamentoId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtDepartamentoId_Internalname, context.GetMessage( "Departamento", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtDepartamentoId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A112DepartamentoId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtDepartamentoId_Enabled!=0) ? context.localUtil.Format( (decimal)(A112DepartamentoId), "ZZZZZZZZZZZZZZZZZ9") : context.localUtil.Format( (decimal)(A112DepartamentoId), "ZZZZZZZZZZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,44);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtDepartamentoId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtDepartamentoId_Enabled, 0, "text", "1", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "Id", "end", false, "", "HLP_CapacidadProductiva.htm");
         /* Static images/pictures */
         ClassString = "gx-prompt Image" + " " + ((StringUtil.StrCmp(imgprompt_112_gximage, "")==0) ? "" : "GX_Image_"+imgprompt_112_gximage+"_Class");
         StyleString = "";
         sImgUrl = (string)(context.GetImagePath( "f5b04895-0024-488b-8e3b-b687ca4598ee", "", context.GetTheme( )));
         GxWebStd.gx_bitmap( context, imgprompt_112_Internalname, sImgUrl, imgprompt_112_Link, "", "", context.GetTheme( ), imgprompt_112_Visible, 1, "", "", 0, 0, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "''", "HLP_CapacidadProductiva.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtDepartamentoDepartamento_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtDepartamentoDepartamento_Internalname, context.GetMessage( "Departamento", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 49,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtDepartamentoDepartamento_Internalname, StringUtil.RTrim( A113DepartamentoDepartamento), StringUtil.RTrim( context.localUtil.Format( A113DepartamentoDepartamento, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,49);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtDepartamentoDepartamento_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtDepartamentoDepartamento_Enabled, 0, "text", "", 80, "chr", 1, "row", 80, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_CapacidadProductiva.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtCapacidadProdDeptoPercent_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCapacidadProdDeptoPercent_Internalname, context.GetMessage( "Depto Percent", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 54,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCapacidadProdDeptoPercent_Internalname, StringUtil.LTrim( StringUtil.NToC( A806CapacidadProdDeptoPercent, 6, 2, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtCapacidadProdDeptoPercent_Enabled!=0) ? context.localUtil.Format( A806CapacidadProdDeptoPercent, "ZZ9.99") : context.localUtil.Format( A806CapacidadProdDeptoPercent, "ZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onblur(this,54);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCapacidadProdDeptoPercent_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCapacidadProdDeptoPercent_Enabled, 0, "text", "", 6, "chr", 1, "row", 6, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_CapacidadProductiva.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtCapacidadProdDeptoValor_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCapacidadProdDeptoValor_Internalname, context.GetMessage( "Depto Valor", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 59,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCapacidadProdDeptoValor_Internalname, StringUtil.LTrim( StringUtil.NToC( A807CapacidadProdDeptoValor, 22, 2, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtCapacidadProdDeptoValor_Enabled!=0) ? context.localUtil.Format( A807CapacidadProdDeptoValor, "ZZZ,ZZZ,ZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( A807CapacidadProdDeptoValor, "ZZZ,ZZZ,ZZZ,ZZZ,ZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onblur(this,59);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCapacidadProdDeptoValor_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCapacidadProdDeptoValor_Enabled, 0, "text", "", 22, "chr", 1, "row", 22, 0, 0, 0, 0, -1, 0, true, "Total", "end", false, "", "HLP_CapacidadProductiva.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtCapacidadProdDeptoDisp_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCapacidadProdDeptoDisp_Internalname, context.GetMessage( "Depto Disp", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 64,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCapacidadProdDeptoDisp_Internalname, StringUtil.LTrim( StringUtil.NToC( A827CapacidadProdDeptoDisp, 22, 2, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtCapacidadProdDeptoDisp_Enabled!=0) ? context.localUtil.Format( A827CapacidadProdDeptoDisp, "ZZZ,ZZZ,ZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( A827CapacidadProdDeptoDisp, "ZZZ,ZZZ,ZZZ,ZZZ,ZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onblur(this,64);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCapacidadProdDeptoDisp_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCapacidadProdDeptoDisp_Enabled, 0, "text", "", 22, "chr", 1, "row", 22, 0, 0, 0, 0, -1, 0, true, "Total", "end", false, "", "HLP_CapacidadProductiva.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtRubrosId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtRubrosId_Internalname, context.GetMessage( "Rubros Identificador ", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 69,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtRubrosId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A121RubrosId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtRubrosId_Enabled!=0) ? context.localUtil.Format( (decimal)(A121RubrosId), "ZZZ9") : context.localUtil.Format( (decimal)(A121RubrosId), "ZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,69);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtRubrosId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtRubrosId_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_CapacidadProductiva.htm");
         /* Static images/pictures */
         ClassString = "gx-prompt Image" + " " + ((StringUtil.StrCmp(imgprompt_121_gximage, "")==0) ? "" : "GX_Image_"+imgprompt_121_gximage+"_Class");
         StyleString = "";
         sImgUrl = (string)(context.GetImagePath( "f5b04895-0024-488b-8e3b-b687ca4598ee", "", context.GetTheme( )));
         GxWebStd.gx_bitmap( context, imgprompt_121_Internalname, sImgUrl, imgprompt_121_Link, "", "", context.GetTheme( ), imgprompt_121_Visible, 1, "", "", 0, 0, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "''", "HLP_CapacidadProductiva.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtRubrosNombre_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtRubrosNombre_Internalname, context.GetMessage( "Rubro", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 74,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtRubrosNombre_Internalname, StringUtil.RTrim( A122RubrosNombre), StringUtil.RTrim( context.localUtil.Format( A122RubrosNombre, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,74);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtRubrosNombre_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtRubrosNombre_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_CapacidadProductiva.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtCapacidadProdRubroPercent_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCapacidadProdRubroPercent_Internalname, context.GetMessage( "Rubro Percent", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 79,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCapacidadProdRubroPercent_Internalname, StringUtil.LTrim( StringUtil.NToC( A809CapacidadProdRubroPercent, 6, 2, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtCapacidadProdRubroPercent_Enabled!=0) ? context.localUtil.Format( A809CapacidadProdRubroPercent, "ZZ9.99") : context.localUtil.Format( A809CapacidadProdRubroPercent, "ZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onblur(this,79);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCapacidadProdRubroPercent_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCapacidadProdRubroPercent_Enabled, 0, "text", "", 6, "chr", 1, "row", 6, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_CapacidadProductiva.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtCapacidadProdRubroValor_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCapacidadProdRubroValor_Internalname, context.GetMessage( "Rubro Valor", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 84,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCapacidadProdRubroValor_Internalname, StringUtil.LTrim( StringUtil.NToC( A810CapacidadProdRubroValor, 22, 2, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtCapacidadProdRubroValor_Enabled!=0) ? context.localUtil.Format( A810CapacidadProdRubroValor, "ZZZ,ZZZ,ZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( A810CapacidadProdRubroValor, "ZZZ,ZZZ,ZZZ,ZZZ,ZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onblur(this,84);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCapacidadProdRubroValor_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCapacidadProdRubroValor_Enabled, 0, "text", "", 22, "chr", 1, "row", 22, 0, 0, 0, 0, -1, 0, true, "Total", "end", false, "", "HLP_CapacidadProductiva.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtCapacidadProdRubroDisp_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCapacidadProdRubroDisp_Internalname, context.GetMessage( "Rubro Disp", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 89,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCapacidadProdRubroDisp_Internalname, StringUtil.LTrim( StringUtil.NToC( A811CapacidadProdRubroDisp, 22, 2, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtCapacidadProdRubroDisp_Enabled!=0) ? context.localUtil.Format( A811CapacidadProdRubroDisp, "ZZZ,ZZZ,ZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( A811CapacidadProdRubroDisp, "ZZZ,ZZZ,ZZZ,ZZZ,ZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onblur(this,89);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCapacidadProdRubroDisp_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCapacidadProdRubroDisp_Enabled, 0, "text", "", 22, "chr", 1, "row", 22, 0, 0, 0, 0, -1, 0, true, "Total", "end", false, "", "HLP_CapacidadProductiva.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__actions--fixed", "end", "Middle", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-action-group", "start", "top", " "+"data-gx-actiongroup-type=\"toolbar\""+" ", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 94,'',false,'',0)\"";
         ClassString = "Button button-primary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", context.GetMessage( "GX_BtnEnter", ""), bttBtn_enter_Jsonclick, 5, context.GetMessage( "GX_BtnEnter", ""), "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_CapacidadProductiva.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 96,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", context.GetMessage( "GX_BtnCancel", ""), bttBtn_cancel_Jsonclick, 1, context.GetMessage( "GX_BtnCancel", ""), "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_CapacidadProductiva.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 98,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", context.GetMessage( "GX_BtnDelete", ""), bttBtn_delete_Jsonclick, 5, context.GetMessage( "GX_BtnDelete", ""), "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_CapacidadProductiva.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "end", "Middle", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
      }

      protected void UserMain( )
      {
         standaloneStartup( ) ;
      }

      protected void UserMainFullajax( )
      {
         INITENV( ) ;
         INITTRN( ) ;
         UserMain( ) ;
         Draw( ) ;
         SendCloseFormHiddens( ) ;
      }

      protected void standaloneStartup( )
      {
         standaloneStartupServer( ) ;
         disable_std_buttons( ) ;
         enableDisable( ) ;
         Process( ) ;
      }

      protected void standaloneStartupServer( )
      {
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            Z804CapacidadProdId = (long)(Math.Round(context.localUtil.CToN( cgiGet( "Z804CapacidadProdId"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            Z805CapacidadProdTotal = context.localUtil.CToN( cgiGet( "Z805CapacidadProdTotal"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
            Z806CapacidadProdDeptoPercent = context.localUtil.CToN( cgiGet( "Z806CapacidadProdDeptoPercent"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
            Z807CapacidadProdDeptoValor = context.localUtil.CToN( cgiGet( "Z807CapacidadProdDeptoValor"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
            Z827CapacidadProdDeptoDisp = context.localUtil.CToN( cgiGet( "Z827CapacidadProdDeptoDisp"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
            Z809CapacidadProdRubroPercent = context.localUtil.CToN( cgiGet( "Z809CapacidadProdRubroPercent"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
            Z810CapacidadProdRubroValor = context.localUtil.CToN( cgiGet( "Z810CapacidadProdRubroValor"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
            Z811CapacidadProdRubroDisp = context.localUtil.CToN( cgiGet( "Z811CapacidadProdRubroDisp"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
            Z112DepartamentoId = (long)(Math.Round(context.localUtil.CToN( cgiGet( "Z112DepartamentoId"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            Z121RubrosId = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z121RubrosId"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            Gx_mode = cgiGet( "Mode");
            /* Read variables values. */
            if ( ( ( context.localUtil.CToN( cgiGet( edtCapacidadProdId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtCapacidadProdId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 999999999999999999L )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "CAPACIDADPRODID");
               AnyError = 1;
               GX_FocusControl = edtCapacidadProdId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A804CapacidadProdId = 0;
               AssignAttri("", false, "A804CapacidadProdId", StringUtil.LTrimStr( (decimal)(A804CapacidadProdId), 18, 0));
            }
            else
            {
               A804CapacidadProdId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtCapacidadProdId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A804CapacidadProdId", StringUtil.LTrimStr( (decimal)(A804CapacidadProdId), 18, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtCapacidadProdTotal_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtCapacidadProdTotal_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > 999999999999999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "CAPACIDADPRODTOTAL");
               AnyError = 1;
               GX_FocusControl = edtCapacidadProdTotal_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A805CapacidadProdTotal = 0;
               AssignAttri("", false, "A805CapacidadProdTotal", StringUtil.LTrimStr( A805CapacidadProdTotal, 18, 2));
            }
            else
            {
               A805CapacidadProdTotal = context.localUtil.CToN( cgiGet( edtCapacidadProdTotal_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
               AssignAttri("", false, "A805CapacidadProdTotal", StringUtil.LTrimStr( A805CapacidadProdTotal, 18, 2));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtDepartamentoId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtDepartamentoId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 999999999999999999L )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "DEPARTAMENTOID");
               AnyError = 1;
               GX_FocusControl = edtDepartamentoId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A112DepartamentoId = 0;
               AssignAttri("", false, "A112DepartamentoId", StringUtil.LTrimStr( (decimal)(A112DepartamentoId), 18, 0));
            }
            else
            {
               A112DepartamentoId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtDepartamentoId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A112DepartamentoId", StringUtil.LTrimStr( (decimal)(A112DepartamentoId), 18, 0));
            }
            A113DepartamentoDepartamento = cgiGet( edtDepartamentoDepartamento_Internalname);
            AssignAttri("", false, "A113DepartamentoDepartamento", A113DepartamentoDepartamento);
            if ( ( ( context.localUtil.CToN( cgiGet( edtCapacidadProdDeptoPercent_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtCapacidadProdDeptoPercent_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > 999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "CAPACIDADPRODDEPTOPERCENT");
               AnyError = 1;
               GX_FocusControl = edtCapacidadProdDeptoPercent_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A806CapacidadProdDeptoPercent = 0;
               AssignAttri("", false, "A806CapacidadProdDeptoPercent", StringUtil.LTrimStr( A806CapacidadProdDeptoPercent, 6, 2));
            }
            else
            {
               A806CapacidadProdDeptoPercent = context.localUtil.CToN( cgiGet( edtCapacidadProdDeptoPercent_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
               AssignAttri("", false, "A806CapacidadProdDeptoPercent", StringUtil.LTrimStr( A806CapacidadProdDeptoPercent, 6, 2));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtCapacidadProdDeptoValor_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtCapacidadProdDeptoValor_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > 999999999999999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "CAPACIDADPRODDEPTOVALOR");
               AnyError = 1;
               GX_FocusControl = edtCapacidadProdDeptoValor_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A807CapacidadProdDeptoValor = 0;
               AssignAttri("", false, "A807CapacidadProdDeptoValor", StringUtil.LTrimStr( A807CapacidadProdDeptoValor, 18, 2));
            }
            else
            {
               A807CapacidadProdDeptoValor = context.localUtil.CToN( cgiGet( edtCapacidadProdDeptoValor_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
               AssignAttri("", false, "A807CapacidadProdDeptoValor", StringUtil.LTrimStr( A807CapacidadProdDeptoValor, 18, 2));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtCapacidadProdDeptoDisp_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtCapacidadProdDeptoDisp_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > 999999999999999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "CAPACIDADPRODDEPTODISP");
               AnyError = 1;
               GX_FocusControl = edtCapacidadProdDeptoDisp_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A827CapacidadProdDeptoDisp = 0;
               AssignAttri("", false, "A827CapacidadProdDeptoDisp", StringUtil.LTrimStr( A827CapacidadProdDeptoDisp, 18, 2));
            }
            else
            {
               A827CapacidadProdDeptoDisp = context.localUtil.CToN( cgiGet( edtCapacidadProdDeptoDisp_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
               AssignAttri("", false, "A827CapacidadProdDeptoDisp", StringUtil.LTrimStr( A827CapacidadProdDeptoDisp, 18, 2));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtRubrosId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtRubrosId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "RUBROSID");
               AnyError = 1;
               GX_FocusControl = edtRubrosId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A121RubrosId = 0;
               AssignAttri("", false, "A121RubrosId", StringUtil.LTrimStr( (decimal)(A121RubrosId), 4, 0));
            }
            else
            {
               A121RubrosId = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtRubrosId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A121RubrosId", StringUtil.LTrimStr( (decimal)(A121RubrosId), 4, 0));
            }
            A122RubrosNombre = cgiGet( edtRubrosNombre_Internalname);
            AssignAttri("", false, "A122RubrosNombre", A122RubrosNombre);
            if ( ( ( context.localUtil.CToN( cgiGet( edtCapacidadProdRubroPercent_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtCapacidadProdRubroPercent_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > 999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "CAPACIDADPRODRUBROPERCENT");
               AnyError = 1;
               GX_FocusControl = edtCapacidadProdRubroPercent_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A809CapacidadProdRubroPercent = 0;
               AssignAttri("", false, "A809CapacidadProdRubroPercent", StringUtil.LTrimStr( A809CapacidadProdRubroPercent, 6, 2));
            }
            else
            {
               A809CapacidadProdRubroPercent = context.localUtil.CToN( cgiGet( edtCapacidadProdRubroPercent_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
               AssignAttri("", false, "A809CapacidadProdRubroPercent", StringUtil.LTrimStr( A809CapacidadProdRubroPercent, 6, 2));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtCapacidadProdRubroValor_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtCapacidadProdRubroValor_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > 999999999999999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "CAPACIDADPRODRUBROVALOR");
               AnyError = 1;
               GX_FocusControl = edtCapacidadProdRubroValor_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A810CapacidadProdRubroValor = 0;
               AssignAttri("", false, "A810CapacidadProdRubroValor", StringUtil.LTrimStr( A810CapacidadProdRubroValor, 18, 2));
            }
            else
            {
               A810CapacidadProdRubroValor = context.localUtil.CToN( cgiGet( edtCapacidadProdRubroValor_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
               AssignAttri("", false, "A810CapacidadProdRubroValor", StringUtil.LTrimStr( A810CapacidadProdRubroValor, 18, 2));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtCapacidadProdRubroDisp_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtCapacidadProdRubroDisp_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > 999999999999999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "CAPACIDADPRODRUBRODISP");
               AnyError = 1;
               GX_FocusControl = edtCapacidadProdRubroDisp_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A811CapacidadProdRubroDisp = 0;
               AssignAttri("", false, "A811CapacidadProdRubroDisp", StringUtil.LTrimStr( A811CapacidadProdRubroDisp, 18, 2));
            }
            else
            {
               A811CapacidadProdRubroDisp = context.localUtil.CToN( cgiGet( edtCapacidadProdRubroDisp_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
               AssignAttri("", false, "A811CapacidadProdRubroDisp", StringUtil.LTrimStr( A811CapacidadProdRubroDisp, 18, 2));
            }
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Crypto.GetSiteKey( );
            standaloneNotModal( ) ;
         }
         else
         {
            standaloneNotModal( ) ;
            if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") == 0 )
            {
               Gx_mode = "DSP";
               AssignAttri("", false, "Gx_mode", Gx_mode);
               A804CapacidadProdId = (long)(Math.Round(NumberUtil.Val( GetPar( "CapacidadProdId"), "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A804CapacidadProdId", StringUtil.LTrimStr( (decimal)(A804CapacidadProdId), 18, 0));
               getEqualNoModal( ) ;
               Gx_mode = "DSP";
               AssignAttri("", false, "Gx_mode", Gx_mode);
               disable_std_buttons_dsp( ) ;
               standaloneModal( ) ;
            }
            else
            {
               Gx_mode = "INS";
               AssignAttri("", false, "Gx_mode", Gx_mode);
               standaloneModal( ) ;
            }
         }
      }

      protected void Process( )
      {
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read Transaction buttons. */
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
                        if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                        {
                           context.wbHandled = 1;
                           btn_enter( ) ;
                           /* No code required for Cancel button. It is implemented as the Reset button. */
                        }
                        else if ( StringUtil.StrCmp(sEvt, "FIRST") == 0 )
                        {
                           context.wbHandled = 1;
                           btn_first( ) ;
                        }
                        else if ( StringUtil.StrCmp(sEvt, "PREVIOUS") == 0 )
                        {
                           context.wbHandled = 1;
                           btn_previous( ) ;
                        }
                        else if ( StringUtil.StrCmp(sEvt, "NEXT") == 0 )
                        {
                           context.wbHandled = 1;
                           btn_next( ) ;
                        }
                        else if ( StringUtil.StrCmp(sEvt, "LAST") == 0 )
                        {
                           context.wbHandled = 1;
                           btn_last( ) ;
                        }
                        else if ( StringUtil.StrCmp(sEvt, "SELECT") == 0 )
                        {
                           context.wbHandled = 1;
                           btn_select( ) ;
                        }
                        else if ( StringUtil.StrCmp(sEvt, "DELETE") == 0 )
                        {
                           context.wbHandled = 1;
                           btn_delete( ) ;
                        }
                        else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                        {
                           context.wbHandled = 1;
                           AfterKeyLoadScreen( ) ;
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

      protected void AfterTrn( )
      {
         if ( trnEnded == 1 )
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( endTrnMsgTxt)) )
            {
               GX_msglist.addItem(endTrnMsgTxt, endTrnMsgCod, 0, "", true);
            }
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll2O122( ) ;
               standaloneNotModal( ) ;
               standaloneModal( ) ;
            }
         }
         endTrnMsgTxt = "";
      }

      public override string ToString( )
      {
         return "" ;
      }

      public GxContentInfo GetContentInfo( )
      {
         return (GxContentInfo)(null) ;
      }

      protected void disable_std_buttons( )
      {
         if ( IsIns( ) )
         {
            bttBtn_delete_Enabled = 0;
            AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         }
      }

      protected void disable_std_buttons_dsp( )
      {
         bttBtn_delete_Visible = 0;
         AssignProp("", false, bttBtn_delete_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Visible), 5, 0), true);
         bttBtn_first_Visible = 0;
         AssignProp("", false, bttBtn_first_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_first_Visible), 5, 0), true);
         bttBtn_previous_Visible = 0;
         AssignProp("", false, bttBtn_previous_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_previous_Visible), 5, 0), true);
         bttBtn_next_Visible = 0;
         AssignProp("", false, bttBtn_next_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_next_Visible), 5, 0), true);
         bttBtn_last_Visible = 0;
         AssignProp("", false, bttBtn_last_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_last_Visible), 5, 0), true);
         bttBtn_select_Visible = 0;
         AssignProp("", false, bttBtn_select_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_select_Visible), 5, 0), true);
         bttBtn_delete_Visible = 0;
         AssignProp("", false, bttBtn_delete_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Visible), 5, 0), true);
         if ( IsDsp( ) )
         {
            bttBtn_enter_Visible = 0;
            AssignProp("", false, bttBtn_enter_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Visible), 5, 0), true);
         }
         DisableAttributes2O122( ) ;
      }

      protected void set_caption( )
      {
         if ( ( IsConfirmed == 1 ) && ( AnyError == 0 ) )
         {
            if ( IsDlt( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_confdelete", ""), 0, "", true);
            }
            else
            {
               GX_msglist.addItem(context.GetMessage( "GXM_mustconfirm", ""), 0, "", true);
            }
         }
      }

      protected void ResetCaption2O0( )
      {
      }

      protected void ZM2O122( short GX_JID )
      {
         if ( ( GX_JID == 1 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z805CapacidadProdTotal = T002O3_A805CapacidadProdTotal[0];
               Z806CapacidadProdDeptoPercent = T002O3_A806CapacidadProdDeptoPercent[0];
               Z807CapacidadProdDeptoValor = T002O3_A807CapacidadProdDeptoValor[0];
               Z827CapacidadProdDeptoDisp = T002O3_A827CapacidadProdDeptoDisp[0];
               Z809CapacidadProdRubroPercent = T002O3_A809CapacidadProdRubroPercent[0];
               Z810CapacidadProdRubroValor = T002O3_A810CapacidadProdRubroValor[0];
               Z811CapacidadProdRubroDisp = T002O3_A811CapacidadProdRubroDisp[0];
               Z112DepartamentoId = T002O3_A112DepartamentoId[0];
               Z121RubrosId = T002O3_A121RubrosId[0];
            }
            else
            {
               Z805CapacidadProdTotal = A805CapacidadProdTotal;
               Z806CapacidadProdDeptoPercent = A806CapacidadProdDeptoPercent;
               Z807CapacidadProdDeptoValor = A807CapacidadProdDeptoValor;
               Z827CapacidadProdDeptoDisp = A827CapacidadProdDeptoDisp;
               Z809CapacidadProdRubroPercent = A809CapacidadProdRubroPercent;
               Z810CapacidadProdRubroValor = A810CapacidadProdRubroValor;
               Z811CapacidadProdRubroDisp = A811CapacidadProdRubroDisp;
               Z112DepartamentoId = A112DepartamentoId;
               Z121RubrosId = A121RubrosId;
            }
         }
         if ( GX_JID == -1 )
         {
            Z804CapacidadProdId = A804CapacidadProdId;
            Z805CapacidadProdTotal = A805CapacidadProdTotal;
            Z806CapacidadProdDeptoPercent = A806CapacidadProdDeptoPercent;
            Z807CapacidadProdDeptoValor = A807CapacidadProdDeptoValor;
            Z827CapacidadProdDeptoDisp = A827CapacidadProdDeptoDisp;
            Z809CapacidadProdRubroPercent = A809CapacidadProdRubroPercent;
            Z810CapacidadProdRubroValor = A810CapacidadProdRubroValor;
            Z811CapacidadProdRubroDisp = A811CapacidadProdRubroDisp;
            Z112DepartamentoId = A112DepartamentoId;
            Z121RubrosId = A121RubrosId;
            Z113DepartamentoDepartamento = A113DepartamentoDepartamento;
            Z122RubrosNombre = A122RubrosNombre;
         }
      }

      protected void standaloneNotModal( )
      {
         imgprompt_112_Link = ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? "" : "javascript:"+"gx.popup.openPrompt('"+"gx00l0.aspx"+"',["+"{Ctrl:gx.dom.el('"+"DEPARTAMENTOID"+"'), id:'"+"DEPARTAMENTOID"+"'"+",IOType:'out'}"+"],"+"null"+","+"'', false"+","+"false"+");");
         imgprompt_121_Link = ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? "" : "javascript:"+"gx.popup.openPrompt('"+"gx0110.aspx"+"',["+"{Ctrl:gx.dom.el('"+"RUBROSID"+"'), id:'"+"RUBROSID"+"'"+",IOType:'out'}"+"],"+"null"+","+"'', false"+","+"false"+");");
      }

      protected void standaloneModal( )
      {
         if ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )
         {
            bttBtn_delete_Enabled = 0;
            AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         }
         else
         {
            bttBtn_delete_Enabled = 1;
            AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         }
         if ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 )
         {
            bttBtn_enter_Enabled = 0;
            AssignProp("", false, bttBtn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Enabled), 5, 0), true);
         }
         else
         {
            bttBtn_enter_Enabled = 1;
            AssignProp("", false, bttBtn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Enabled), 5, 0), true);
         }
      }

      protected void Load2O122( )
      {
         /* Using cursor T002O6 */
         pr_default.execute(4, new Object[] {A804CapacidadProdId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            RcdFound122 = 1;
            A805CapacidadProdTotal = T002O6_A805CapacidadProdTotal[0];
            AssignAttri("", false, "A805CapacidadProdTotal", StringUtil.LTrimStr( A805CapacidadProdTotal, 18, 2));
            A113DepartamentoDepartamento = T002O6_A113DepartamentoDepartamento[0];
            AssignAttri("", false, "A113DepartamentoDepartamento", A113DepartamentoDepartamento);
            A806CapacidadProdDeptoPercent = T002O6_A806CapacidadProdDeptoPercent[0];
            AssignAttri("", false, "A806CapacidadProdDeptoPercent", StringUtil.LTrimStr( A806CapacidadProdDeptoPercent, 6, 2));
            A807CapacidadProdDeptoValor = T002O6_A807CapacidadProdDeptoValor[0];
            AssignAttri("", false, "A807CapacidadProdDeptoValor", StringUtil.LTrimStr( A807CapacidadProdDeptoValor, 18, 2));
            A827CapacidadProdDeptoDisp = T002O6_A827CapacidadProdDeptoDisp[0];
            AssignAttri("", false, "A827CapacidadProdDeptoDisp", StringUtil.LTrimStr( A827CapacidadProdDeptoDisp, 18, 2));
            A122RubrosNombre = T002O6_A122RubrosNombre[0];
            AssignAttri("", false, "A122RubrosNombre", A122RubrosNombre);
            A809CapacidadProdRubroPercent = T002O6_A809CapacidadProdRubroPercent[0];
            AssignAttri("", false, "A809CapacidadProdRubroPercent", StringUtil.LTrimStr( A809CapacidadProdRubroPercent, 6, 2));
            A810CapacidadProdRubroValor = T002O6_A810CapacidadProdRubroValor[0];
            AssignAttri("", false, "A810CapacidadProdRubroValor", StringUtil.LTrimStr( A810CapacidadProdRubroValor, 18, 2));
            A811CapacidadProdRubroDisp = T002O6_A811CapacidadProdRubroDisp[0];
            AssignAttri("", false, "A811CapacidadProdRubroDisp", StringUtil.LTrimStr( A811CapacidadProdRubroDisp, 18, 2));
            A112DepartamentoId = T002O6_A112DepartamentoId[0];
            AssignAttri("", false, "A112DepartamentoId", StringUtil.LTrimStr( (decimal)(A112DepartamentoId), 18, 0));
            A121RubrosId = T002O6_A121RubrosId[0];
            AssignAttri("", false, "A121RubrosId", StringUtil.LTrimStr( (decimal)(A121RubrosId), 4, 0));
            ZM2O122( -1) ;
         }
         pr_default.close(4);
         OnLoadActions2O122( ) ;
      }

      protected void OnLoadActions2O122( )
      {
      }

      protected void CheckExtendedTable2O122( )
      {
         Gx_BScreen = 1;
         standaloneModal( ) ;
         /* Using cursor T002O4 */
         pr_default.execute(2, new Object[] {A112DepartamentoId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Departamento", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "DEPARTAMENTOID");
            AnyError = 1;
            GX_FocusControl = edtDepartamentoId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A113DepartamentoDepartamento = T002O4_A113DepartamentoDepartamento[0];
         AssignAttri("", false, "A113DepartamentoDepartamento", A113DepartamentoDepartamento);
         pr_default.close(2);
         /* Using cursor T002O5 */
         pr_default.execute(3, new Object[] {A121RubrosId});
         if ( (pr_default.getStatus(3) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Rubros", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "RUBROSID");
            AnyError = 1;
            GX_FocusControl = edtRubrosId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A122RubrosNombre = T002O5_A122RubrosNombre[0];
         AssignAttri("", false, "A122RubrosNombre", A122RubrosNombre);
         pr_default.close(3);
      }

      protected void CloseExtendedTableCursors2O122( )
      {
         pr_default.close(2);
         pr_default.close(3);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_2( long A112DepartamentoId )
      {
         /* Using cursor T002O7 */
         pr_default.execute(5, new Object[] {A112DepartamentoId});
         if ( (pr_default.getStatus(5) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Departamento", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "DEPARTAMENTOID");
            AnyError = 1;
            GX_FocusControl = edtDepartamentoId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A113DepartamentoDepartamento = T002O7_A113DepartamentoDepartamento[0];
         AssignAttri("", false, "A113DepartamentoDepartamento", A113DepartamentoDepartamento);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A113DepartamentoDepartamento))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(5) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(5);
      }

      protected void gxLoad_3( short A121RubrosId )
      {
         /* Using cursor T002O8 */
         pr_default.execute(6, new Object[] {A121RubrosId});
         if ( (pr_default.getStatus(6) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Rubros", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "RUBROSID");
            AnyError = 1;
            GX_FocusControl = edtRubrosId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A122RubrosNombre = T002O8_A122RubrosNombre[0];
         AssignAttri("", false, "A122RubrosNombre", A122RubrosNombre);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A122RubrosNombre))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(6) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(6);
      }

      protected void GetKey2O122( )
      {
         /* Using cursor T002O9 */
         pr_default.execute(7, new Object[] {A804CapacidadProdId});
         if ( (pr_default.getStatus(7) != 101) )
         {
            RcdFound122 = 1;
         }
         else
         {
            RcdFound122 = 0;
         }
         pr_default.close(7);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T002O3 */
         pr_default.execute(1, new Object[] {A804CapacidadProdId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM2O122( 1) ;
            RcdFound122 = 1;
            A804CapacidadProdId = T002O3_A804CapacidadProdId[0];
            AssignAttri("", false, "A804CapacidadProdId", StringUtil.LTrimStr( (decimal)(A804CapacidadProdId), 18, 0));
            A805CapacidadProdTotal = T002O3_A805CapacidadProdTotal[0];
            AssignAttri("", false, "A805CapacidadProdTotal", StringUtil.LTrimStr( A805CapacidadProdTotal, 18, 2));
            A806CapacidadProdDeptoPercent = T002O3_A806CapacidadProdDeptoPercent[0];
            AssignAttri("", false, "A806CapacidadProdDeptoPercent", StringUtil.LTrimStr( A806CapacidadProdDeptoPercent, 6, 2));
            A807CapacidadProdDeptoValor = T002O3_A807CapacidadProdDeptoValor[0];
            AssignAttri("", false, "A807CapacidadProdDeptoValor", StringUtil.LTrimStr( A807CapacidadProdDeptoValor, 18, 2));
            A827CapacidadProdDeptoDisp = T002O3_A827CapacidadProdDeptoDisp[0];
            AssignAttri("", false, "A827CapacidadProdDeptoDisp", StringUtil.LTrimStr( A827CapacidadProdDeptoDisp, 18, 2));
            A809CapacidadProdRubroPercent = T002O3_A809CapacidadProdRubroPercent[0];
            AssignAttri("", false, "A809CapacidadProdRubroPercent", StringUtil.LTrimStr( A809CapacidadProdRubroPercent, 6, 2));
            A810CapacidadProdRubroValor = T002O3_A810CapacidadProdRubroValor[0];
            AssignAttri("", false, "A810CapacidadProdRubroValor", StringUtil.LTrimStr( A810CapacidadProdRubroValor, 18, 2));
            A811CapacidadProdRubroDisp = T002O3_A811CapacidadProdRubroDisp[0];
            AssignAttri("", false, "A811CapacidadProdRubroDisp", StringUtil.LTrimStr( A811CapacidadProdRubroDisp, 18, 2));
            A112DepartamentoId = T002O3_A112DepartamentoId[0];
            AssignAttri("", false, "A112DepartamentoId", StringUtil.LTrimStr( (decimal)(A112DepartamentoId), 18, 0));
            A121RubrosId = T002O3_A121RubrosId[0];
            AssignAttri("", false, "A121RubrosId", StringUtil.LTrimStr( (decimal)(A121RubrosId), 4, 0));
            Z804CapacidadProdId = A804CapacidadProdId;
            sMode122 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load2O122( ) ;
            if ( AnyError == 1 )
            {
               RcdFound122 = 0;
               InitializeNonKey2O122( ) ;
            }
            Gx_mode = sMode122;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound122 = 0;
            InitializeNonKey2O122( ) ;
            sMode122 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode122;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey2O122( ) ;
         if ( RcdFound122 == 0 )
         {
            Gx_mode = "INS";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound122 = 0;
         /* Using cursor T002O10 */
         pr_default.execute(8, new Object[] {A804CapacidadProdId});
         if ( (pr_default.getStatus(8) != 101) )
         {
            while ( (pr_default.getStatus(8) != 101) && ( ( T002O10_A804CapacidadProdId[0] < A804CapacidadProdId ) ) )
            {
               pr_default.readNext(8);
            }
            if ( (pr_default.getStatus(8) != 101) && ( ( T002O10_A804CapacidadProdId[0] > A804CapacidadProdId ) ) )
            {
               A804CapacidadProdId = T002O10_A804CapacidadProdId[0];
               AssignAttri("", false, "A804CapacidadProdId", StringUtil.LTrimStr( (decimal)(A804CapacidadProdId), 18, 0));
               RcdFound122 = 1;
            }
         }
         pr_default.close(8);
      }

      protected void move_previous( )
      {
         RcdFound122 = 0;
         /* Using cursor T002O11 */
         pr_default.execute(9, new Object[] {A804CapacidadProdId});
         if ( (pr_default.getStatus(9) != 101) )
         {
            while ( (pr_default.getStatus(9) != 101) && ( ( T002O11_A804CapacidadProdId[0] > A804CapacidadProdId ) ) )
            {
               pr_default.readNext(9);
            }
            if ( (pr_default.getStatus(9) != 101) && ( ( T002O11_A804CapacidadProdId[0] < A804CapacidadProdId ) ) )
            {
               A804CapacidadProdId = T002O11_A804CapacidadProdId[0];
               AssignAttri("", false, "A804CapacidadProdId", StringUtil.LTrimStr( (decimal)(A804CapacidadProdId), 18, 0));
               RcdFound122 = 1;
            }
         }
         pr_default.close(9);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey2O122( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtCapacidadProdId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert2O122( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound122 == 1 )
            {
               if ( A804CapacidadProdId != Z804CapacidadProdId )
               {
                  A804CapacidadProdId = Z804CapacidadProdId;
                  AssignAttri("", false, "A804CapacidadProdId", StringUtil.LTrimStr( (decimal)(A804CapacidadProdId), 18, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "CAPACIDADPRODID");
                  AnyError = 1;
                  GX_FocusControl = edtCapacidadProdId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtCapacidadProdId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  Gx_mode = "UPD";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Update record */
                  Update2O122( ) ;
                  GX_FocusControl = edtCapacidadProdId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A804CapacidadProdId != Z804CapacidadProdId )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtCapacidadProdId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert2O122( ) ;
                  if ( AnyError == 1 )
                  {
                     GX_FocusControl = "";
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
               }
               else
               {
                  if ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 )
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "CAPACIDADPRODID");
                     AnyError = 1;
                     GX_FocusControl = edtCapacidadProdId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     GX_FocusControl = edtCapacidadProdId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert2O122( ) ;
                     if ( AnyError == 1 )
                     {
                        GX_FocusControl = "";
                        AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
            }
         }
         AfterTrn( ) ;
      }

      protected void btn_delete( )
      {
         if ( A804CapacidadProdId != Z804CapacidadProdId )
         {
            A804CapacidadProdId = Z804CapacidadProdId;
            AssignAttri("", false, "A804CapacidadProdId", StringUtil.LTrimStr( (decimal)(A804CapacidadProdId), 18, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "CAPACIDADPRODID");
            AnyError = 1;
            GX_FocusControl = edtCapacidadProdId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtCapacidadProdId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            getByPrimaryKey( ) ;
         }
         CloseCursors();
      }

      protected void btn_get( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         getEqualNoModal( ) ;
         if ( RcdFound122 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "CAPACIDADPRODID");
            AnyError = 1;
            GX_FocusControl = edtCapacidadProdId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtCapacidadProdTotal_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart2O122( ) ;
         if ( RcdFound122 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtCapacidadProdTotal_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd2O122( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_previous( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         move_previous( ) ;
         if ( RcdFound122 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtCapacidadProdTotal_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_next( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         move_next( ) ;
         if ( RcdFound122 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtCapacidadProdTotal_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_last( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart2O122( ) ;
         if ( RcdFound122 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound122 != 0 )
            {
               ScanNext2O122( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtCapacidadProdTotal_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd2O122( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency2O122( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T002O2 */
            pr_default.execute(0, new Object[] {A804CapacidadProdId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"CapacidadProductiva"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( Z805CapacidadProdTotal != T002O2_A805CapacidadProdTotal[0] ) || ( Z806CapacidadProdDeptoPercent != T002O2_A806CapacidadProdDeptoPercent[0] ) || ( Z807CapacidadProdDeptoValor != T002O2_A807CapacidadProdDeptoValor[0] ) || ( Z827CapacidadProdDeptoDisp != T002O2_A827CapacidadProdDeptoDisp[0] ) || ( Z809CapacidadProdRubroPercent != T002O2_A809CapacidadProdRubroPercent[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z810CapacidadProdRubroValor != T002O2_A810CapacidadProdRubroValor[0] ) || ( Z811CapacidadProdRubroDisp != T002O2_A811CapacidadProdRubroDisp[0] ) || ( Z112DepartamentoId != T002O2_A112DepartamentoId[0] ) || ( Z121RubrosId != T002O2_A121RubrosId[0] ) )
            {
               if ( Z805CapacidadProdTotal != T002O2_A805CapacidadProdTotal[0] )
               {
                  GXUtil.WriteLog("capacidadproductiva:[seudo value changed for attri]"+"CapacidadProdTotal");
                  GXUtil.WriteLogRaw("Old: ",Z805CapacidadProdTotal);
                  GXUtil.WriteLogRaw("Current: ",T002O2_A805CapacidadProdTotal[0]);
               }
               if ( Z806CapacidadProdDeptoPercent != T002O2_A806CapacidadProdDeptoPercent[0] )
               {
                  GXUtil.WriteLog("capacidadproductiva:[seudo value changed for attri]"+"CapacidadProdDeptoPercent");
                  GXUtil.WriteLogRaw("Old: ",Z806CapacidadProdDeptoPercent);
                  GXUtil.WriteLogRaw("Current: ",T002O2_A806CapacidadProdDeptoPercent[0]);
               }
               if ( Z807CapacidadProdDeptoValor != T002O2_A807CapacidadProdDeptoValor[0] )
               {
                  GXUtil.WriteLog("capacidadproductiva:[seudo value changed for attri]"+"CapacidadProdDeptoValor");
                  GXUtil.WriteLogRaw("Old: ",Z807CapacidadProdDeptoValor);
                  GXUtil.WriteLogRaw("Current: ",T002O2_A807CapacidadProdDeptoValor[0]);
               }
               if ( Z827CapacidadProdDeptoDisp != T002O2_A827CapacidadProdDeptoDisp[0] )
               {
                  GXUtil.WriteLog("capacidadproductiva:[seudo value changed for attri]"+"CapacidadProdDeptoDisp");
                  GXUtil.WriteLogRaw("Old: ",Z827CapacidadProdDeptoDisp);
                  GXUtil.WriteLogRaw("Current: ",T002O2_A827CapacidadProdDeptoDisp[0]);
               }
               if ( Z809CapacidadProdRubroPercent != T002O2_A809CapacidadProdRubroPercent[0] )
               {
                  GXUtil.WriteLog("capacidadproductiva:[seudo value changed for attri]"+"CapacidadProdRubroPercent");
                  GXUtil.WriteLogRaw("Old: ",Z809CapacidadProdRubroPercent);
                  GXUtil.WriteLogRaw("Current: ",T002O2_A809CapacidadProdRubroPercent[0]);
               }
               if ( Z810CapacidadProdRubroValor != T002O2_A810CapacidadProdRubroValor[0] )
               {
                  GXUtil.WriteLog("capacidadproductiva:[seudo value changed for attri]"+"CapacidadProdRubroValor");
                  GXUtil.WriteLogRaw("Old: ",Z810CapacidadProdRubroValor);
                  GXUtil.WriteLogRaw("Current: ",T002O2_A810CapacidadProdRubroValor[0]);
               }
               if ( Z811CapacidadProdRubroDisp != T002O2_A811CapacidadProdRubroDisp[0] )
               {
                  GXUtil.WriteLog("capacidadproductiva:[seudo value changed for attri]"+"CapacidadProdRubroDisp");
                  GXUtil.WriteLogRaw("Old: ",Z811CapacidadProdRubroDisp);
                  GXUtil.WriteLogRaw("Current: ",T002O2_A811CapacidadProdRubroDisp[0]);
               }
               if ( Z112DepartamentoId != T002O2_A112DepartamentoId[0] )
               {
                  GXUtil.WriteLog("capacidadproductiva:[seudo value changed for attri]"+"DepartamentoId");
                  GXUtil.WriteLogRaw("Old: ",Z112DepartamentoId);
                  GXUtil.WriteLogRaw("Current: ",T002O2_A112DepartamentoId[0]);
               }
               if ( Z121RubrosId != T002O2_A121RubrosId[0] )
               {
                  GXUtil.WriteLog("capacidadproductiva:[seudo value changed for attri]"+"RubrosId");
                  GXUtil.WriteLogRaw("Old: ",Z121RubrosId);
                  GXUtil.WriteLogRaw("Current: ",T002O2_A121RubrosId[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"CapacidadProductiva"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert2O122( )
      {
         BeforeValidate2O122( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable2O122( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM2O122( 0) ;
            CheckOptimisticConcurrency2O122( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm2O122( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert2O122( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T002O12 */
                     pr_default.execute(10, new Object[] {A804CapacidadProdId, A805CapacidadProdTotal, A806CapacidadProdDeptoPercent, A807CapacidadProdDeptoValor, A827CapacidadProdDeptoDisp, A809CapacidadProdRubroPercent, A810CapacidadProdRubroValor, A811CapacidadProdRubroDisp, A112DepartamentoId, A121RubrosId});
                     pr_default.close(10);
                     pr_default.SmartCacheProvider.SetUpdated("CapacidadProductiva");
                     if ( (pr_default.getStatus(10) == 1) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
                        AnyError = 1;
                     }
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
                           endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                           endTrnMsgCod = "SuccessfullyAdded";
                           ResetCaption2O0( ) ;
                        }
                     }
                  }
                  else
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                     AnyError = 1;
                  }
               }
            }
            else
            {
               Load2O122( ) ;
            }
            EndLevel2O122( ) ;
         }
         CloseExtendedTableCursors2O122( ) ;
      }

      protected void Update2O122( )
      {
         BeforeValidate2O122( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable2O122( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency2O122( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm2O122( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate2O122( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T002O13 */
                     pr_default.execute(11, new Object[] {A805CapacidadProdTotal, A806CapacidadProdDeptoPercent, A807CapacidadProdDeptoValor, A827CapacidadProdDeptoDisp, A809CapacidadProdRubroPercent, A810CapacidadProdRubroValor, A811CapacidadProdRubroDisp, A112DepartamentoId, A121RubrosId, A804CapacidadProdId});
                     pr_default.close(11);
                     pr_default.SmartCacheProvider.SetUpdated("CapacidadProductiva");
                     if ( (pr_default.getStatus(11) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"CapacidadProductiva"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate2O122( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption2O0( ) ;
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                        AnyError = 1;
                     }
                  }
               }
            }
            EndLevel2O122( ) ;
         }
         CloseExtendedTableCursors2O122( ) ;
      }

      protected void DeferredUpdate2O122( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate2O122( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency2O122( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls2O122( ) ;
            AfterConfirm2O122( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete2O122( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T002O14 */
                  pr_default.execute(12, new Object[] {A804CapacidadProdId});
                  pr_default.close(12);
                  pr_default.SmartCacheProvider.SetUpdated("CapacidadProductiva");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound122 == 0 )
                        {
                           InitAll2O122( ) ;
                           Gx_mode = "INS";
                           AssignAttri("", false, "Gx_mode", Gx_mode);
                        }
                        else
                        {
                           getByPrimaryKey( ) ;
                           Gx_mode = "UPD";
                           AssignAttri("", false, "Gx_mode", Gx_mode);
                        }
                        endTrnMsgTxt = context.GetMessage( "GXM_sucdeleted", "");
                        endTrnMsgCod = "SuccessfullyDeleted";
                        ResetCaption2O0( ) ;
                     }
                  }
                  else
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                     AnyError = 1;
                  }
               }
            }
         }
         sMode122 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel2O122( ) ;
         Gx_mode = sMode122;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls2O122( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor T002O15 */
            pr_default.execute(13, new Object[] {A112DepartamentoId});
            A113DepartamentoDepartamento = T002O15_A113DepartamentoDepartamento[0];
            AssignAttri("", false, "A113DepartamentoDepartamento", A113DepartamentoDepartamento);
            pr_default.close(13);
            /* Using cursor T002O16 */
            pr_default.execute(14, new Object[] {A121RubrosId});
            A122RubrosNombre = T002O16_A122RubrosNombre[0];
            AssignAttri("", false, "A122RubrosNombre", A122RubrosNombre);
            pr_default.close(14);
         }
      }

      protected void EndLevel2O122( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete2O122( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            pr_default.close(13);
            pr_default.close(14);
            context.CommitDataStores("capacidadproductiva",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues2O0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            pr_default.close(13);
            pr_default.close(14);
            context.RollbackDataStores("capacidadproductiva",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart2O122( )
      {
         /* Using cursor T002O17 */
         pr_default.execute(15);
         RcdFound122 = 0;
         if ( (pr_default.getStatus(15) != 101) )
         {
            RcdFound122 = 1;
            A804CapacidadProdId = T002O17_A804CapacidadProdId[0];
            AssignAttri("", false, "A804CapacidadProdId", StringUtil.LTrimStr( (decimal)(A804CapacidadProdId), 18, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext2O122( )
      {
         /* Scan next routine */
         pr_default.readNext(15);
         RcdFound122 = 0;
         if ( (pr_default.getStatus(15) != 101) )
         {
            RcdFound122 = 1;
            A804CapacidadProdId = T002O17_A804CapacidadProdId[0];
            AssignAttri("", false, "A804CapacidadProdId", StringUtil.LTrimStr( (decimal)(A804CapacidadProdId), 18, 0));
         }
      }

      protected void ScanEnd2O122( )
      {
         pr_default.close(15);
      }

      protected void AfterConfirm2O122( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert2O122( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate2O122( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete2O122( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete2O122( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate2O122( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes2O122( )
      {
         edtCapacidadProdId_Enabled = 0;
         AssignProp("", false, edtCapacidadProdId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCapacidadProdId_Enabled), 5, 0), true);
         edtCapacidadProdTotal_Enabled = 0;
         AssignProp("", false, edtCapacidadProdTotal_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCapacidadProdTotal_Enabled), 5, 0), true);
         edtDepartamentoId_Enabled = 0;
         AssignProp("", false, edtDepartamentoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtDepartamentoId_Enabled), 5, 0), true);
         edtDepartamentoDepartamento_Enabled = 0;
         AssignProp("", false, edtDepartamentoDepartamento_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtDepartamentoDepartamento_Enabled), 5, 0), true);
         edtCapacidadProdDeptoPercent_Enabled = 0;
         AssignProp("", false, edtCapacidadProdDeptoPercent_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCapacidadProdDeptoPercent_Enabled), 5, 0), true);
         edtCapacidadProdDeptoValor_Enabled = 0;
         AssignProp("", false, edtCapacidadProdDeptoValor_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCapacidadProdDeptoValor_Enabled), 5, 0), true);
         edtCapacidadProdDeptoDisp_Enabled = 0;
         AssignProp("", false, edtCapacidadProdDeptoDisp_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCapacidadProdDeptoDisp_Enabled), 5, 0), true);
         edtRubrosId_Enabled = 0;
         AssignProp("", false, edtRubrosId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtRubrosId_Enabled), 5, 0), true);
         edtRubrosNombre_Enabled = 0;
         AssignProp("", false, edtRubrosNombre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtRubrosNombre_Enabled), 5, 0), true);
         edtCapacidadProdRubroPercent_Enabled = 0;
         AssignProp("", false, edtCapacidadProdRubroPercent_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCapacidadProdRubroPercent_Enabled), 5, 0), true);
         edtCapacidadProdRubroValor_Enabled = 0;
         AssignProp("", false, edtCapacidadProdRubroValor_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCapacidadProdRubroValor_Enabled), 5, 0), true);
         edtCapacidadProdRubroDisp_Enabled = 0;
         AssignProp("", false, edtCapacidadProdRubroDisp_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCapacidadProdRubroDisp_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes2O122( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues2O0( )
      {
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
         MasterPageObj.master_styles();
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
         bodyStyle += "-moz-opacity:0;opacity:0;";
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( Form.Background)) ) )
         {
            bodyStyle += " background-image:url(" + context.convertURL( Form.Background) + ")";
         }
         context.WriteHtmlText( " "+"class=\"form-horizontal Form\""+" "+ "style='"+bodyStyle+"'") ;
         context.WriteHtmlText( FormProcess+">") ;
         context.skipLines(1);
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("capacidadproductiva.aspx") +"\">") ;
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
         GXKey = Crypto.GetSiteKey( );
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z804CapacidadProdId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z804CapacidadProdId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Z805CapacidadProdTotal", StringUtil.LTrim( StringUtil.NToC( Z805CapacidadProdTotal, 18, 2, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Z806CapacidadProdDeptoPercent", StringUtil.LTrim( StringUtil.NToC( Z806CapacidadProdDeptoPercent, 6, 2, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Z807CapacidadProdDeptoValor", StringUtil.LTrim( StringUtil.NToC( Z807CapacidadProdDeptoValor, 18, 2, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Z827CapacidadProdDeptoDisp", StringUtil.LTrim( StringUtil.NToC( Z827CapacidadProdDeptoDisp, 18, 2, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Z809CapacidadProdRubroPercent", StringUtil.LTrim( StringUtil.NToC( Z809CapacidadProdRubroPercent, 6, 2, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Z810CapacidadProdRubroValor", StringUtil.LTrim( StringUtil.NToC( Z810CapacidadProdRubroValor, 18, 2, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Z811CapacidadProdRubroDisp", StringUtil.LTrim( StringUtil.NToC( Z811CapacidadProdRubroDisp, 18, 2, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Z112DepartamentoId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z112DepartamentoId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Z121RubrosId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z121RubrosId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
      }

      public override void RenderHtmlCloseForm( )
      {
         SendCloseFormHiddens( ) ;
         GxWebStd.gx_hidden_field( context, "GX_FocusControl", GX_FocusControl);
         SendAjaxEncryptionKey();
         SendSecurityToken(sPrefix);
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

      public override short ExecuteStartEvent( )
      {
         standaloneStartup( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         return gxajaxcallmode ;
      }

      public override void RenderHtmlContent( )
      {
         context.WriteHtmlText( "<div") ;
         GxWebStd.ClassAttribute( context, "gx-ct-body"+" "+(String.IsNullOrEmpty(StringUtil.RTrim( Form.Class)) ? "form-horizontal Form" : Form.Class)+"-fx");
         context.WriteHtmlText( ">") ;
         Draw( ) ;
         context.WriteHtmlText( "</div>") ;
      }

      public override void DispatchEvents( )
      {
         Process( ) ;
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
         return formatLink("capacidadproductiva.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "CapacidadProductiva" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "Capacidad Productiva", "") ;
      }

      protected void InitializeNonKey2O122( )
      {
         A805CapacidadProdTotal = 0;
         AssignAttri("", false, "A805CapacidadProdTotal", StringUtil.LTrimStr( A805CapacidadProdTotal, 18, 2));
         A112DepartamentoId = 0;
         AssignAttri("", false, "A112DepartamentoId", StringUtil.LTrimStr( (decimal)(A112DepartamentoId), 18, 0));
         A113DepartamentoDepartamento = "";
         AssignAttri("", false, "A113DepartamentoDepartamento", A113DepartamentoDepartamento);
         A806CapacidadProdDeptoPercent = 0;
         AssignAttri("", false, "A806CapacidadProdDeptoPercent", StringUtil.LTrimStr( A806CapacidadProdDeptoPercent, 6, 2));
         A807CapacidadProdDeptoValor = 0;
         AssignAttri("", false, "A807CapacidadProdDeptoValor", StringUtil.LTrimStr( A807CapacidadProdDeptoValor, 18, 2));
         A827CapacidadProdDeptoDisp = 0;
         AssignAttri("", false, "A827CapacidadProdDeptoDisp", StringUtil.LTrimStr( A827CapacidadProdDeptoDisp, 18, 2));
         A121RubrosId = 0;
         AssignAttri("", false, "A121RubrosId", StringUtil.LTrimStr( (decimal)(A121RubrosId), 4, 0));
         A122RubrosNombre = "";
         AssignAttri("", false, "A122RubrosNombre", A122RubrosNombre);
         A809CapacidadProdRubroPercent = 0;
         AssignAttri("", false, "A809CapacidadProdRubroPercent", StringUtil.LTrimStr( A809CapacidadProdRubroPercent, 6, 2));
         A810CapacidadProdRubroValor = 0;
         AssignAttri("", false, "A810CapacidadProdRubroValor", StringUtil.LTrimStr( A810CapacidadProdRubroValor, 18, 2));
         A811CapacidadProdRubroDisp = 0;
         AssignAttri("", false, "A811CapacidadProdRubroDisp", StringUtil.LTrimStr( A811CapacidadProdRubroDisp, 18, 2));
         Z805CapacidadProdTotal = 0;
         Z806CapacidadProdDeptoPercent = 0;
         Z807CapacidadProdDeptoValor = 0;
         Z827CapacidadProdDeptoDisp = 0;
         Z809CapacidadProdRubroPercent = 0;
         Z810CapacidadProdRubroValor = 0;
         Z811CapacidadProdRubroDisp = 0;
         Z112DepartamentoId = 0;
         Z121RubrosId = 0;
      }

      protected void InitAll2O122( )
      {
         A804CapacidadProdId = 0;
         AssignAttri("", false, "A804CapacidadProdId", StringUtil.LTrimStr( (decimal)(A804CapacidadProdId), 18, 0));
         InitializeNonKey2O122( ) ;
      }

      protected void StandaloneModalInsert( )
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20269321553464", true, true, false);
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
         context.AddJavascriptSource("capacidadproductiva.js", "?20269321553464", false, true, false);
         /* End function include_jscripts */
      }

      protected void init_default_properties( )
      {
         lblTitle_Internalname = "TITLE";
         divTitlecontainer_Internalname = "TITLECONTAINER";
         bttBtn_first_Internalname = "BTN_FIRST";
         bttBtn_previous_Internalname = "BTN_PREVIOUS";
         bttBtn_next_Internalname = "BTN_NEXT";
         bttBtn_last_Internalname = "BTN_LAST";
         bttBtn_select_Internalname = "BTN_SELECT";
         divToolbarcell_Internalname = "TOOLBARCELL";
         edtCapacidadProdId_Internalname = "CAPACIDADPRODID";
         edtCapacidadProdTotal_Internalname = "CAPACIDADPRODTOTAL";
         edtDepartamentoId_Internalname = "DEPARTAMENTOID";
         edtDepartamentoDepartamento_Internalname = "DEPARTAMENTODEPARTAMENTO";
         edtCapacidadProdDeptoPercent_Internalname = "CAPACIDADPRODDEPTOPERCENT";
         edtCapacidadProdDeptoValor_Internalname = "CAPACIDADPRODDEPTOVALOR";
         edtCapacidadProdDeptoDisp_Internalname = "CAPACIDADPRODDEPTODISP";
         edtRubrosId_Internalname = "RUBROSID";
         edtRubrosNombre_Internalname = "RUBROSNOMBRE";
         edtCapacidadProdRubroPercent_Internalname = "CAPACIDADPRODRUBROPERCENT";
         edtCapacidadProdRubroValor_Internalname = "CAPACIDADPRODRUBROVALOR";
         edtCapacidadProdRubroDisp_Internalname = "CAPACIDADPRODRUBRODISP";
         divFormcontainer_Internalname = "FORMCONTAINER";
         bttBtn_enter_Internalname = "BTN_ENTER";
         bttBtn_cancel_Internalname = "BTN_CANCEL";
         bttBtn_delete_Internalname = "BTN_DELETE";
         divMaintable_Internalname = "MAINTABLE";
         Form.Internalname = "FORM";
         imgprompt_112_Internalname = "PROMPT_112";
         imgprompt_121_Internalname = "PROMPT_121";
      }

      public override void initialize_properties( )
      {
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_default_properties( ) ;
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = context.GetMessage( "Capacidad Productiva", "");
         bttBtn_delete_Enabled = 1;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         edtCapacidadProdRubroDisp_Jsonclick = "";
         edtCapacidadProdRubroDisp_Enabled = 1;
         edtCapacidadProdRubroValor_Jsonclick = "";
         edtCapacidadProdRubroValor_Enabled = 1;
         edtCapacidadProdRubroPercent_Jsonclick = "";
         edtCapacidadProdRubroPercent_Enabled = 1;
         edtRubrosNombre_Jsonclick = "";
         edtRubrosNombre_Enabled = 0;
         imgprompt_121_Visible = 1;
         imgprompt_121_Link = "";
         edtRubrosId_Jsonclick = "";
         edtRubrosId_Enabled = 1;
         edtCapacidadProdDeptoDisp_Jsonclick = "";
         edtCapacidadProdDeptoDisp_Enabled = 1;
         edtCapacidadProdDeptoValor_Jsonclick = "";
         edtCapacidadProdDeptoValor_Enabled = 1;
         edtCapacidadProdDeptoPercent_Jsonclick = "";
         edtCapacidadProdDeptoPercent_Enabled = 1;
         edtDepartamentoDepartamento_Jsonclick = "";
         edtDepartamentoDepartamento_Enabled = 0;
         imgprompt_112_Visible = 1;
         imgprompt_112_Link = "";
         edtDepartamentoId_Jsonclick = "";
         edtDepartamentoId_Enabled = 1;
         edtCapacidadProdTotal_Jsonclick = "";
         edtCapacidadProdTotal_Enabled = 1;
         edtCapacidadProdId_Jsonclick = "";
         edtCapacidadProdId_Enabled = 1;
         bttBtn_select_Visible = 1;
         bttBtn_last_Visible = 1;
         bttBtn_next_Visible = 1;
         bttBtn_previous_Visible = 1;
         bttBtn_first_Visible = 1;
         context.GX_msglist.DisplayMode = 1;
         if ( context.isSpaRequest( ) )
         {
            enableJsOutput();
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void init_web_controls( )
      {
         /* End function init_web_controls */
      }

      protected void AfterKeyLoadScreen( )
      {
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         getEqualNoModal( ) ;
         GX_FocusControl = edtCapacidadProdTotal_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
         /* End function AfterKeyLoadScreen */
      }

      protected bool IsIns( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "INS")==0) ? true : false) ;
      }

      protected bool IsDlt( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "DLT")==0) ? true : false) ;
      }

      protected bool IsUpd( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "UPD")==0) ? true : false) ;
      }

      protected bool IsDsp( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? true : false) ;
      }

      public void Valid_Capacidadprodid( )
      {
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A805CapacidadProdTotal", StringUtil.LTrim( StringUtil.NToC( A805CapacidadProdTotal, 18, 2, ".", "")));
         AssignAttri("", false, "A112DepartamentoId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A112DepartamentoId), 18, 0, ".", "")));
         AssignAttri("", false, "A806CapacidadProdDeptoPercent", StringUtil.LTrim( StringUtil.NToC( A806CapacidadProdDeptoPercent, 6, 2, ".", "")));
         AssignAttri("", false, "A807CapacidadProdDeptoValor", StringUtil.LTrim( StringUtil.NToC( A807CapacidadProdDeptoValor, 18, 2, ".", "")));
         AssignAttri("", false, "A827CapacidadProdDeptoDisp", StringUtil.LTrim( StringUtil.NToC( A827CapacidadProdDeptoDisp, 18, 2, ".", "")));
         AssignAttri("", false, "A121RubrosId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A121RubrosId), 4, 0, ".", "")));
         AssignAttri("", false, "A809CapacidadProdRubroPercent", StringUtil.LTrim( StringUtil.NToC( A809CapacidadProdRubroPercent, 6, 2, ".", "")));
         AssignAttri("", false, "A810CapacidadProdRubroValor", StringUtil.LTrim( StringUtil.NToC( A810CapacidadProdRubroValor, 18, 2, ".", "")));
         AssignAttri("", false, "A811CapacidadProdRubroDisp", StringUtil.LTrim( StringUtil.NToC( A811CapacidadProdRubroDisp, 18, 2, ".", "")));
         AssignAttri("", false, "A113DepartamentoDepartamento", StringUtil.RTrim( A113DepartamentoDepartamento));
         AssignAttri("", false, "A122RubrosNombre", StringUtil.RTrim( A122RubrosNombre));
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z804CapacidadProdId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z804CapacidadProdId), 18, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z805CapacidadProdTotal", StringUtil.LTrim( StringUtil.NToC( Z805CapacidadProdTotal, 18, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z112DepartamentoId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z112DepartamentoId), 18, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z806CapacidadProdDeptoPercent", StringUtil.LTrim( StringUtil.NToC( Z806CapacidadProdDeptoPercent, 6, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z807CapacidadProdDeptoValor", StringUtil.LTrim( StringUtil.NToC( Z807CapacidadProdDeptoValor, 18, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z827CapacidadProdDeptoDisp", StringUtil.LTrim( StringUtil.NToC( Z827CapacidadProdDeptoDisp, 18, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z121RubrosId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z121RubrosId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z809CapacidadProdRubroPercent", StringUtil.LTrim( StringUtil.NToC( Z809CapacidadProdRubroPercent, 6, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z810CapacidadProdRubroValor", StringUtil.LTrim( StringUtil.NToC( Z810CapacidadProdRubroValor, 18, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z811CapacidadProdRubroDisp", StringUtil.LTrim( StringUtil.NToC( Z811CapacidadProdRubroDisp, 18, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z113DepartamentoDepartamento", StringUtil.RTrim( Z113DepartamentoDepartamento));
         GxWebStd.gx_hidden_field( context, "Z122RubrosNombre", StringUtil.RTrim( Z122RubrosNombre));
         AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         AssignProp("", false, bttBtn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Enabled), 5, 0), true);
         SendCloseFormHiddens( ) ;
      }

      public void Valid_Departamentoid( )
      {
         /* Using cursor T002O15 */
         pr_default.execute(13, new Object[] {A112DepartamentoId});
         if ( (pr_default.getStatus(13) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Departamento", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "DEPARTAMENTOID");
            AnyError = 1;
            GX_FocusControl = edtDepartamentoId_Internalname;
         }
         A113DepartamentoDepartamento = T002O15_A113DepartamentoDepartamento[0];
         pr_default.close(13);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A113DepartamentoDepartamento", StringUtil.RTrim( A113DepartamentoDepartamento));
      }

      public void Valid_Rubrosid( )
      {
         /* Using cursor T002O16 */
         pr_default.execute(14, new Object[] {A121RubrosId});
         if ( (pr_default.getStatus(14) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Rubros", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "RUBROSID");
            AnyError = 1;
            GX_FocusControl = edtRubrosId_Internalname;
         }
         A122RubrosNombre = T002O16_A122RubrosNombre[0];
         pr_default.close(14);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A122RubrosNombre", StringUtil.RTrim( A122RubrosNombre));
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","{handler:'UserMainFullajax',iparms:[{postForm:true}]");
         setEventMetadata("ENTER",",oparms:[]}");
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("VALID_CAPACIDADPRODID","{handler:'Valid_Capacidadprodid',iparms:[{av:'A804CapacidadProdId',fld:'CAPACIDADPRODID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'Gx_mode',fld:'vMODE',pic:'@!',type:'char'}]");
         setEventMetadata("VALID_CAPACIDADPRODID",",oparms:[{av:'A805CapacidadProdTotal',fld:'CAPACIDADPRODTOTAL',pic:'ZZZ,ZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'A112DepartamentoId',fld:'DEPARTAMENTOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'A806CapacidadProdDeptoPercent',fld:'CAPACIDADPRODDEPTOPERCENT',pic:'ZZ9.99',type:'decimal'},{av:'A807CapacidadProdDeptoValor',fld:'CAPACIDADPRODDEPTOVALOR',pic:'ZZZ,ZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'A827CapacidadProdDeptoDisp',fld:'CAPACIDADPRODDEPTODISP',pic:'ZZZ,ZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'A121RubrosId',fld:'RUBROSID',pic:'ZZZ9',type:'int'},{av:'A809CapacidadProdRubroPercent',fld:'CAPACIDADPRODRUBROPERCENT',pic:'ZZ9.99',type:'decimal'},{av:'A810CapacidadProdRubroValor',fld:'CAPACIDADPRODRUBROVALOR',pic:'ZZZ,ZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'A811CapacidadProdRubroDisp',fld:'CAPACIDADPRODRUBRODISP',pic:'ZZZ,ZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'A113DepartamentoDepartamento',fld:'DEPARTAMENTODEPARTAMENTO',pic:'',type:'char'},{av:'A122RubrosNombre',fld:'RUBROSNOMBRE',pic:'',type:'char'},{av:'Gx_mode',fld:'vMODE',pic:'@!',type:'char'},{av:'Z804CapacidadProdId',type:'int'},{av:'Z805CapacidadProdTotal',type:'decimal'},{av:'Z112DepartamentoId',type:'int'},{av:'Z806CapacidadProdDeptoPercent',type:'decimal'},{av:'Z807CapacidadProdDeptoValor',type:'decimal'},{av:'Z827CapacidadProdDeptoDisp',type:'decimal'},{av:'Z121RubrosId',type:'int'},{av:'Z809CapacidadProdRubroPercent',type:'decimal'},{av:'Z810CapacidadProdRubroValor',type:'decimal'},{av:'Z811CapacidadProdRubroDisp',type:'decimal'},{av:'Z113DepartamentoDepartamento',type:'char'},{av:'Z122RubrosNombre',type:'char'},{ctrl:'BTN_DELETE',prop:'Enabled'},{ctrl:'BTN_ENTER',prop:'Enabled'}]}");
         setEventMetadata("VALID_DEPARTAMENTOID","{handler:'Valid_Departamentoid',iparms:[{av:'A112DepartamentoId',fld:'DEPARTAMENTOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'A113DepartamentoDepartamento',fld:'DEPARTAMENTODEPARTAMENTO',pic:'',type:'char'}]");
         setEventMetadata("VALID_DEPARTAMENTOID",",oparms:[{av:'A113DepartamentoDepartamento',fld:'DEPARTAMENTODEPARTAMENTO',pic:'',type:'char'}]}");
         setEventMetadata("VALID_RUBROSID","{handler:'Valid_Rubrosid',iparms:[{av:'A121RubrosId',fld:'RUBROSID',pic:'ZZZ9',type:'int'},{av:'A122RubrosNombre',fld:'RUBROSNOMBRE',pic:'',type:'char'}]");
         setEventMetadata("VALID_RUBROSID",",oparms:[{av:'A122RubrosNombre',fld:'RUBROSNOMBRE',pic:'',type:'char'}]}");
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

      protected override void CloseCursors( )
      {
         pr_default.close(1);
         pr_default.close(13);
         pr_default.close(14);
      }

      public override void initialize( )
      {
         sPrefix = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         GXKey = "";
         PreviousTooltip = "";
         PreviousCaption = "";
         Form = new GXWebForm();
         GX_FocusControl = "";
         lblTitle_Jsonclick = "";
         ClassString = "";
         StyleString = "";
         TempTags = "";
         bttBtn_first_Jsonclick = "";
         bttBtn_previous_Jsonclick = "";
         bttBtn_next_Jsonclick = "";
         bttBtn_last_Jsonclick = "";
         bttBtn_select_Jsonclick = "";
         imgprompt_112_gximage = "";
         sImgUrl = "";
         A113DepartamentoDepartamento = "";
         imgprompt_121_gximage = "";
         A122RubrosNombre = "";
         bttBtn_enter_Jsonclick = "";
         bttBtn_cancel_Jsonclick = "";
         bttBtn_delete_Jsonclick = "";
         Gx_mode = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         Z113DepartamentoDepartamento = "";
         Z122RubrosNombre = "";
         T002O6_A804CapacidadProdId = new long[1] ;
         T002O6_A805CapacidadProdTotal = new decimal[1] ;
         T002O6_A113DepartamentoDepartamento = new string[] {""} ;
         T002O6_A806CapacidadProdDeptoPercent = new decimal[1] ;
         T002O6_A807CapacidadProdDeptoValor = new decimal[1] ;
         T002O6_A827CapacidadProdDeptoDisp = new decimal[1] ;
         T002O6_A122RubrosNombre = new string[] {""} ;
         T002O6_A809CapacidadProdRubroPercent = new decimal[1] ;
         T002O6_A810CapacidadProdRubroValor = new decimal[1] ;
         T002O6_A811CapacidadProdRubroDisp = new decimal[1] ;
         T002O6_A112DepartamentoId = new long[1] ;
         T002O6_A121RubrosId = new short[1] ;
         T002O4_A113DepartamentoDepartamento = new string[] {""} ;
         T002O5_A122RubrosNombre = new string[] {""} ;
         T002O7_A113DepartamentoDepartamento = new string[] {""} ;
         T002O8_A122RubrosNombre = new string[] {""} ;
         T002O9_A804CapacidadProdId = new long[1] ;
         T002O3_A804CapacidadProdId = new long[1] ;
         T002O3_A805CapacidadProdTotal = new decimal[1] ;
         T002O3_A806CapacidadProdDeptoPercent = new decimal[1] ;
         T002O3_A807CapacidadProdDeptoValor = new decimal[1] ;
         T002O3_A827CapacidadProdDeptoDisp = new decimal[1] ;
         T002O3_A809CapacidadProdRubroPercent = new decimal[1] ;
         T002O3_A810CapacidadProdRubroValor = new decimal[1] ;
         T002O3_A811CapacidadProdRubroDisp = new decimal[1] ;
         T002O3_A112DepartamentoId = new long[1] ;
         T002O3_A121RubrosId = new short[1] ;
         sMode122 = "";
         T002O10_A804CapacidadProdId = new long[1] ;
         T002O11_A804CapacidadProdId = new long[1] ;
         T002O2_A804CapacidadProdId = new long[1] ;
         T002O2_A805CapacidadProdTotal = new decimal[1] ;
         T002O2_A806CapacidadProdDeptoPercent = new decimal[1] ;
         T002O2_A807CapacidadProdDeptoValor = new decimal[1] ;
         T002O2_A827CapacidadProdDeptoDisp = new decimal[1] ;
         T002O2_A809CapacidadProdRubroPercent = new decimal[1] ;
         T002O2_A810CapacidadProdRubroValor = new decimal[1] ;
         T002O2_A811CapacidadProdRubroDisp = new decimal[1] ;
         T002O2_A112DepartamentoId = new long[1] ;
         T002O2_A121RubrosId = new short[1] ;
         T002O15_A113DepartamentoDepartamento = new string[] {""} ;
         T002O16_A122RubrosNombre = new string[] {""} ;
         T002O17_A804CapacidadProdId = new long[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         ZZ113DepartamentoDepartamento = "";
         ZZ122RubrosNombre = "";
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.capacidadproductiva__datastore1(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.capacidadproductiva__default(),
            new Object[][] {
                new Object[] {
               T002O2_A804CapacidadProdId, T002O2_A805CapacidadProdTotal, T002O2_A806CapacidadProdDeptoPercent, T002O2_A807CapacidadProdDeptoValor, T002O2_A827CapacidadProdDeptoDisp, T002O2_A809CapacidadProdRubroPercent, T002O2_A810CapacidadProdRubroValor, T002O2_A811CapacidadProdRubroDisp, T002O2_A112DepartamentoId, T002O2_A121RubrosId
               }
               , new Object[] {
               T002O3_A804CapacidadProdId, T002O3_A805CapacidadProdTotal, T002O3_A806CapacidadProdDeptoPercent, T002O3_A807CapacidadProdDeptoValor, T002O3_A827CapacidadProdDeptoDisp, T002O3_A809CapacidadProdRubroPercent, T002O3_A810CapacidadProdRubroValor, T002O3_A811CapacidadProdRubroDisp, T002O3_A112DepartamentoId, T002O3_A121RubrosId
               }
               , new Object[] {
               T002O4_A113DepartamentoDepartamento
               }
               , new Object[] {
               T002O5_A122RubrosNombre
               }
               , new Object[] {
               T002O6_A804CapacidadProdId, T002O6_A805CapacidadProdTotal, T002O6_A113DepartamentoDepartamento, T002O6_A806CapacidadProdDeptoPercent, T002O6_A807CapacidadProdDeptoValor, T002O6_A827CapacidadProdDeptoDisp, T002O6_A122RubrosNombre, T002O6_A809CapacidadProdRubroPercent, T002O6_A810CapacidadProdRubroValor, T002O6_A811CapacidadProdRubroDisp,
               T002O6_A112DepartamentoId, T002O6_A121RubrosId
               }
               , new Object[] {
               T002O7_A113DepartamentoDepartamento
               }
               , new Object[] {
               T002O8_A122RubrosNombre
               }
               , new Object[] {
               T002O9_A804CapacidadProdId
               }
               , new Object[] {
               T002O10_A804CapacidadProdId
               }
               , new Object[] {
               T002O11_A804CapacidadProdId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T002O15_A113DepartamentoDepartamento
               }
               , new Object[] {
               T002O16_A122RubrosNombre
               }
               , new Object[] {
               T002O17_A804CapacidadProdId
               }
            }
         );
      }

      private short Z121RubrosId ;
      private short GxWebError ;
      private short A121RubrosId ;
      private short AnyError ;
      private short IsModified ;
      private short IsConfirmed ;
      private short nKeyPressed ;
      private short RcdFound122 ;
      private short Gx_BScreen ;
      private short gxajaxcallmode ;
      private short ZZ121RubrosId ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtCapacidadProdId_Enabled ;
      private int edtCapacidadProdTotal_Enabled ;
      private int edtDepartamentoId_Enabled ;
      private int imgprompt_112_Visible ;
      private int edtDepartamentoDepartamento_Enabled ;
      private int edtCapacidadProdDeptoPercent_Enabled ;
      private int edtCapacidadProdDeptoValor_Enabled ;
      private int edtCapacidadProdDeptoDisp_Enabled ;
      private int edtRubrosId_Enabled ;
      private int imgprompt_121_Visible ;
      private int edtRubrosNombre_Enabled ;
      private int edtCapacidadProdRubroPercent_Enabled ;
      private int edtCapacidadProdRubroValor_Enabled ;
      private int edtCapacidadProdRubroDisp_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int idxLst ;
      private long Z804CapacidadProdId ;
      private long Z112DepartamentoId ;
      private long A112DepartamentoId ;
      private long A804CapacidadProdId ;
      private long ZZ804CapacidadProdId ;
      private long ZZ112DepartamentoId ;
      private decimal Z805CapacidadProdTotal ;
      private decimal Z806CapacidadProdDeptoPercent ;
      private decimal Z807CapacidadProdDeptoValor ;
      private decimal Z827CapacidadProdDeptoDisp ;
      private decimal Z809CapacidadProdRubroPercent ;
      private decimal Z810CapacidadProdRubroValor ;
      private decimal Z811CapacidadProdRubroDisp ;
      private decimal A805CapacidadProdTotal ;
      private decimal A806CapacidadProdDeptoPercent ;
      private decimal A807CapacidadProdDeptoValor ;
      private decimal A827CapacidadProdDeptoDisp ;
      private decimal A809CapacidadProdRubroPercent ;
      private decimal A810CapacidadProdRubroValor ;
      private decimal A811CapacidadProdRubroDisp ;
      private decimal ZZ805CapacidadProdTotal ;
      private decimal ZZ806CapacidadProdDeptoPercent ;
      private decimal ZZ807CapacidadProdDeptoValor ;
      private decimal ZZ827CapacidadProdDeptoDisp ;
      private decimal ZZ809CapacidadProdRubroPercent ;
      private decimal ZZ810CapacidadProdRubroValor ;
      private decimal ZZ811CapacidadProdRubroDisp ;
      private string sPrefix ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtCapacidadProdId_Internalname ;
      private string divMaintable_Internalname ;
      private string divTitlecontainer_Internalname ;
      private string lblTitle_Internalname ;
      private string lblTitle_Jsonclick ;
      private string ClassString ;
      private string StyleString ;
      private string divFormcontainer_Internalname ;
      private string divToolbarcell_Internalname ;
      private string TempTags ;
      private string bttBtn_first_Internalname ;
      private string bttBtn_first_Jsonclick ;
      private string bttBtn_previous_Internalname ;
      private string bttBtn_previous_Jsonclick ;
      private string bttBtn_next_Internalname ;
      private string bttBtn_next_Jsonclick ;
      private string bttBtn_last_Internalname ;
      private string bttBtn_last_Jsonclick ;
      private string bttBtn_select_Internalname ;
      private string bttBtn_select_Jsonclick ;
      private string edtCapacidadProdId_Jsonclick ;
      private string edtCapacidadProdTotal_Internalname ;
      private string edtCapacidadProdTotal_Jsonclick ;
      private string edtDepartamentoId_Internalname ;
      private string edtDepartamentoId_Jsonclick ;
      private string imgprompt_112_gximage ;
      private string sImgUrl ;
      private string imgprompt_112_Internalname ;
      private string imgprompt_112_Link ;
      private string edtDepartamentoDepartamento_Internalname ;
      private string A113DepartamentoDepartamento ;
      private string edtDepartamentoDepartamento_Jsonclick ;
      private string edtCapacidadProdDeptoPercent_Internalname ;
      private string edtCapacidadProdDeptoPercent_Jsonclick ;
      private string edtCapacidadProdDeptoValor_Internalname ;
      private string edtCapacidadProdDeptoValor_Jsonclick ;
      private string edtCapacidadProdDeptoDisp_Internalname ;
      private string edtCapacidadProdDeptoDisp_Jsonclick ;
      private string edtRubrosId_Internalname ;
      private string edtRubrosId_Jsonclick ;
      private string imgprompt_121_gximage ;
      private string imgprompt_121_Internalname ;
      private string imgprompt_121_Link ;
      private string edtRubrosNombre_Internalname ;
      private string A122RubrosNombre ;
      private string edtRubrosNombre_Jsonclick ;
      private string edtCapacidadProdRubroPercent_Internalname ;
      private string edtCapacidadProdRubroPercent_Jsonclick ;
      private string edtCapacidadProdRubroValor_Internalname ;
      private string edtCapacidadProdRubroValor_Jsonclick ;
      private string edtCapacidadProdRubroDisp_Internalname ;
      private string edtCapacidadProdRubroDisp_Jsonclick ;
      private string bttBtn_enter_Internalname ;
      private string bttBtn_enter_Jsonclick ;
      private string bttBtn_cancel_Internalname ;
      private string bttBtn_cancel_Jsonclick ;
      private string bttBtn_delete_Internalname ;
      private string bttBtn_delete_Jsonclick ;
      private string Gx_mode ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string Z113DepartamentoDepartamento ;
      private string Z122RubrosNombre ;
      private string sMode122 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string ZZ113DepartamentoDepartamento ;
      private string ZZ122RubrosNombre ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool Gx_longc ;
      private GXWebForm Form ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private long[] T002O6_A804CapacidadProdId ;
      private decimal[] T002O6_A805CapacidadProdTotal ;
      private string[] T002O6_A113DepartamentoDepartamento ;
      private decimal[] T002O6_A806CapacidadProdDeptoPercent ;
      private decimal[] T002O6_A807CapacidadProdDeptoValor ;
      private decimal[] T002O6_A827CapacidadProdDeptoDisp ;
      private string[] T002O6_A122RubrosNombre ;
      private decimal[] T002O6_A809CapacidadProdRubroPercent ;
      private decimal[] T002O6_A810CapacidadProdRubroValor ;
      private decimal[] T002O6_A811CapacidadProdRubroDisp ;
      private long[] T002O6_A112DepartamentoId ;
      private short[] T002O6_A121RubrosId ;
      private string[] T002O4_A113DepartamentoDepartamento ;
      private string[] T002O5_A122RubrosNombre ;
      private string[] T002O7_A113DepartamentoDepartamento ;
      private string[] T002O8_A122RubrosNombre ;
      private long[] T002O9_A804CapacidadProdId ;
      private long[] T002O3_A804CapacidadProdId ;
      private decimal[] T002O3_A805CapacidadProdTotal ;
      private decimal[] T002O3_A806CapacidadProdDeptoPercent ;
      private decimal[] T002O3_A807CapacidadProdDeptoValor ;
      private decimal[] T002O3_A827CapacidadProdDeptoDisp ;
      private decimal[] T002O3_A809CapacidadProdRubroPercent ;
      private decimal[] T002O3_A810CapacidadProdRubroValor ;
      private decimal[] T002O3_A811CapacidadProdRubroDisp ;
      private long[] T002O3_A112DepartamentoId ;
      private short[] T002O3_A121RubrosId ;
      private long[] T002O10_A804CapacidadProdId ;
      private long[] T002O11_A804CapacidadProdId ;
      private long[] T002O2_A804CapacidadProdId ;
      private decimal[] T002O2_A805CapacidadProdTotal ;
      private decimal[] T002O2_A806CapacidadProdDeptoPercent ;
      private decimal[] T002O2_A807CapacidadProdDeptoValor ;
      private decimal[] T002O2_A827CapacidadProdDeptoDisp ;
      private decimal[] T002O2_A809CapacidadProdRubroPercent ;
      private decimal[] T002O2_A810CapacidadProdRubroValor ;
      private decimal[] T002O2_A811CapacidadProdRubroDisp ;
      private long[] T002O2_A112DepartamentoId ;
      private short[] T002O2_A121RubrosId ;
      private string[] T002O15_A113DepartamentoDepartamento ;
      private string[] T002O16_A122RubrosNombre ;
      private long[] T002O17_A804CapacidadProdId ;
      private IDataStoreProvider pr_datastore1 ;
   }

   public class capacidadproductiva__datastore1 : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          def= new CursorDef[] {
          };
       }
    }

    public void getResults( int cursor ,
                            IFieldGetter rslt ,
                            Object[] buf )
    {
    }

    public override string getDataStoreName( )
    {
       return "DATASTORE1";
    }

 }

 public class capacidadproductiva__default : DataStoreHelperBase, IDataStoreHelper
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
       ,new ForEachCursor(def[5])
       ,new ForEachCursor(def[6])
       ,new ForEachCursor(def[7])
       ,new ForEachCursor(def[8])
       ,new ForEachCursor(def[9])
       ,new UpdateCursor(def[10])
       ,new UpdateCursor(def[11])
       ,new UpdateCursor(def[12])
       ,new ForEachCursor(def[13])
       ,new ForEachCursor(def[14])
       ,new ForEachCursor(def[15])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmT002O2;
        prmT002O2 = new Object[] {
        new ParDef("@CapacidadProdId",GXType.Decimal,18,0)
        };
        Object[] prmT002O3;
        prmT002O3 = new Object[] {
        new ParDef("@CapacidadProdId",GXType.Decimal,18,0)
        };
        Object[] prmT002O4;
        prmT002O4 = new Object[] {
        new ParDef("@DepartamentoId",GXType.Decimal,18,0)
        };
        Object[] prmT002O5;
        prmT002O5 = new Object[] {
        new ParDef("@RubrosId",GXType.Int16,4,0)
        };
        Object[] prmT002O6;
        prmT002O6 = new Object[] {
        new ParDef("@CapacidadProdId",GXType.Decimal,18,0)
        };
        Object[] prmT002O7;
        prmT002O7 = new Object[] {
        new ParDef("@DepartamentoId",GXType.Decimal,18,0)
        };
        Object[] prmT002O8;
        prmT002O8 = new Object[] {
        new ParDef("@RubrosId",GXType.Int16,4,0)
        };
        Object[] prmT002O9;
        prmT002O9 = new Object[] {
        new ParDef("@CapacidadProdId",GXType.Decimal,18,0)
        };
        Object[] prmT002O10;
        prmT002O10 = new Object[] {
        new ParDef("@CapacidadProdId",GXType.Decimal,18,0)
        };
        Object[] prmT002O11;
        prmT002O11 = new Object[] {
        new ParDef("@CapacidadProdId",GXType.Decimal,18,0)
        };
        Object[] prmT002O12;
        prmT002O12 = new Object[] {
        new ParDef("@CapacidadProdId",GXType.Decimal,18,0) ,
        new ParDef("@CapacidadProdTotal",GXType.Decimal,18,2) ,
        new ParDef("@CapacidadProdDeptoPercent",GXType.Decimal,6,2) ,
        new ParDef("@CapacidadProdDeptoValor",GXType.Decimal,18,2) ,
        new ParDef("@CapacidadProdDeptoDisp",GXType.Decimal,18,2) ,
        new ParDef("@CapacidadProdRubroPercent",GXType.Decimal,6,2) ,
        new ParDef("@CapacidadProdRubroValor",GXType.Decimal,18,2) ,
        new ParDef("@CapacidadProdRubroDisp",GXType.Decimal,18,2) ,
        new ParDef("@DepartamentoId",GXType.Decimal,18,0) ,
        new ParDef("@RubrosId",GXType.Int16,4,0)
        };
        Object[] prmT002O13;
        prmT002O13 = new Object[] {
        new ParDef("@CapacidadProdTotal",GXType.Decimal,18,2) ,
        new ParDef("@CapacidadProdDeptoPercent",GXType.Decimal,6,2) ,
        new ParDef("@CapacidadProdDeptoValor",GXType.Decimal,18,2) ,
        new ParDef("@CapacidadProdDeptoDisp",GXType.Decimal,18,2) ,
        new ParDef("@CapacidadProdRubroPercent",GXType.Decimal,6,2) ,
        new ParDef("@CapacidadProdRubroValor",GXType.Decimal,18,2) ,
        new ParDef("@CapacidadProdRubroDisp",GXType.Decimal,18,2) ,
        new ParDef("@DepartamentoId",GXType.Decimal,18,0) ,
        new ParDef("@RubrosId",GXType.Int16,4,0) ,
        new ParDef("@CapacidadProdId",GXType.Decimal,18,0)
        };
        Object[] prmT002O14;
        prmT002O14 = new Object[] {
        new ParDef("@CapacidadProdId",GXType.Decimal,18,0)
        };
        Object[] prmT002O15;
        prmT002O15 = new Object[] {
        new ParDef("@DepartamentoId",GXType.Decimal,18,0)
        };
        Object[] prmT002O16;
        prmT002O16 = new Object[] {
        new ParDef("@RubrosId",GXType.Int16,4,0)
        };
        Object[] prmT002O17;
        prmT002O17 = new Object[] {
        };
        def= new CursorDef[] {
            new CursorDef("T002O2", "SELECT [CapacidadProdId], [CapacidadProdTotal], [CapacidadProdDeptoPercent], [CapacidadProdDeptoValor], [CapacidadProdDeptoDisp], [CapacidadProdRubroPercent], [CapacidadProdRubroValor], [CapacidadProdRubroDisp], [DepartamentoId], [RubrosId] FROM [CapacidadProductiva] WITH (UPDLOCK) WHERE [CapacidadProdId] = @CapacidadProdId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002O2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002O3", "SELECT [CapacidadProdId], [CapacidadProdTotal], [CapacidadProdDeptoPercent], [CapacidadProdDeptoValor], [CapacidadProdDeptoDisp], [CapacidadProdRubroPercent], [CapacidadProdRubroValor], [CapacidadProdRubroDisp], [DepartamentoId], [RubrosId] FROM [CapacidadProductiva] WHERE [CapacidadProdId] = @CapacidadProdId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002O3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002O4", "SELECT [DepartamentoDepartamento] FROM [Departamento] WHERE [DepartamentoId] = @DepartamentoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002O4,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002O5", "SELECT [RubrosNombre] FROM [Rubros] WHERE [RubrosId] = @RubrosId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002O5,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002O6", "SELECT TM1.[CapacidadProdId], TM1.[CapacidadProdTotal], T2.[DepartamentoDepartamento], TM1.[CapacidadProdDeptoPercent], TM1.[CapacidadProdDeptoValor], TM1.[CapacidadProdDeptoDisp], T3.[RubrosNombre], TM1.[CapacidadProdRubroPercent], TM1.[CapacidadProdRubroValor], TM1.[CapacidadProdRubroDisp], TM1.[DepartamentoId], TM1.[RubrosId] FROM (([CapacidadProductiva] TM1 INNER JOIN [Departamento] T2 ON T2.[DepartamentoId] = TM1.[DepartamentoId]) INNER JOIN [Rubros] T3 ON T3.[RubrosId] = TM1.[RubrosId]) WHERE TM1.[CapacidadProdId] = @CapacidadProdId ORDER BY TM1.[CapacidadProdId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT002O6,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002O7", "SELECT [DepartamentoDepartamento] FROM [Departamento] WHERE [DepartamentoId] = @DepartamentoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002O7,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002O8", "SELECT [RubrosNombre] FROM [Rubros] WHERE [RubrosId] = @RubrosId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002O8,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002O9", "SELECT [CapacidadProdId] FROM [CapacidadProductiva] WHERE [CapacidadProdId] = @CapacidadProdId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT002O9,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002O10", "SELECT TOP 1 [CapacidadProdId] FROM [CapacidadProductiva] WHERE ( [CapacidadProdId] > @CapacidadProdId) ORDER BY [CapacidadProdId]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT002O10,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T002O11", "SELECT TOP 1 [CapacidadProdId] FROM [CapacidadProductiva] WHERE ( [CapacidadProdId] < @CapacidadProdId) ORDER BY [CapacidadProdId] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT002O11,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T002O12", "INSERT INTO [CapacidadProductiva]([CapacidadProdId], [CapacidadProdTotal], [CapacidadProdDeptoPercent], [CapacidadProdDeptoValor], [CapacidadProdDeptoDisp], [CapacidadProdRubroPercent], [CapacidadProdRubroValor], [CapacidadProdRubroDisp], [DepartamentoId], [RubrosId]) VALUES(@CapacidadProdId, @CapacidadProdTotal, @CapacidadProdDeptoPercent, @CapacidadProdDeptoValor, @CapacidadProdDeptoDisp, @CapacidadProdRubroPercent, @CapacidadProdRubroValor, @CapacidadProdRubroDisp, @DepartamentoId, @RubrosId)", GxErrorMask.GX_NOMASK,prmT002O12)
           ,new CursorDef("T002O13", "UPDATE [CapacidadProductiva] SET [CapacidadProdTotal]=@CapacidadProdTotal, [CapacidadProdDeptoPercent]=@CapacidadProdDeptoPercent, [CapacidadProdDeptoValor]=@CapacidadProdDeptoValor, [CapacidadProdDeptoDisp]=@CapacidadProdDeptoDisp, [CapacidadProdRubroPercent]=@CapacidadProdRubroPercent, [CapacidadProdRubroValor]=@CapacidadProdRubroValor, [CapacidadProdRubroDisp]=@CapacidadProdRubroDisp, [DepartamentoId]=@DepartamentoId, [RubrosId]=@RubrosId  WHERE [CapacidadProdId] = @CapacidadProdId", GxErrorMask.GX_NOMASK,prmT002O13)
           ,new CursorDef("T002O14", "DELETE FROM [CapacidadProductiva]  WHERE [CapacidadProdId] = @CapacidadProdId", GxErrorMask.GX_NOMASK,prmT002O14)
           ,new CursorDef("T002O15", "SELECT [DepartamentoDepartamento] FROM [Departamento] WHERE [DepartamentoId] = @DepartamentoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002O15,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002O16", "SELECT [RubrosNombre] FROM [Rubros] WHERE [RubrosId] = @RubrosId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002O16,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002O17", "SELECT [CapacidadProdId] FROM [CapacidadProductiva] ORDER BY [CapacidadProdId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT002O17,100, GxCacheFrequency.OFF ,true,false )
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
              ((decimal[]) buf[2])[0] = rslt.getDecimal(3);
              ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
              ((decimal[]) buf[4])[0] = rslt.getDecimal(5);
              ((decimal[]) buf[5])[0] = rslt.getDecimal(6);
              ((decimal[]) buf[6])[0] = rslt.getDecimal(7);
              ((decimal[]) buf[7])[0] = rslt.getDecimal(8);
              ((long[]) buf[8])[0] = rslt.getLong(9);
              ((short[]) buf[9])[0] = rslt.getShort(10);
              return;
           case 1 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((decimal[]) buf[1])[0] = rslt.getDecimal(2);
              ((decimal[]) buf[2])[0] = rslt.getDecimal(3);
              ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
              ((decimal[]) buf[4])[0] = rslt.getDecimal(5);
              ((decimal[]) buf[5])[0] = rslt.getDecimal(6);
              ((decimal[]) buf[6])[0] = rslt.getDecimal(7);
              ((decimal[]) buf[7])[0] = rslt.getDecimal(8);
              ((long[]) buf[8])[0] = rslt.getLong(9);
              ((short[]) buf[9])[0] = rslt.getShort(10);
              return;
           case 2 :
              ((string[]) buf[0])[0] = rslt.getString(1, 80);
              return;
           case 3 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 4 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((decimal[]) buf[1])[0] = rslt.getDecimal(2);
              ((string[]) buf[2])[0] = rslt.getString(3, 80);
              ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
              ((decimal[]) buf[4])[0] = rslt.getDecimal(5);
              ((decimal[]) buf[5])[0] = rslt.getDecimal(6);
              ((string[]) buf[6])[0] = rslt.getString(7, 100);
              ((decimal[]) buf[7])[0] = rslt.getDecimal(8);
              ((decimal[]) buf[8])[0] = rslt.getDecimal(9);
              ((decimal[]) buf[9])[0] = rslt.getDecimal(10);
              ((long[]) buf[10])[0] = rslt.getLong(11);
              ((short[]) buf[11])[0] = rslt.getShort(12);
              return;
           case 5 :
              ((string[]) buf[0])[0] = rslt.getString(1, 80);
              return;
           case 6 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 7 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 8 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 9 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 13 :
              ((string[]) buf[0])[0] = rslt.getString(1, 80);
              return;
           case 14 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 15 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
     }
  }

}

}

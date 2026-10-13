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
using GeneXus.Procedure;
using GeneXus.Printer;
using GeneXus.XML;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Threading;
using System.Xml.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class listaagruserwwexportreport : GXWebProcedure, System.Web.SessionState.IRequiresSessionState
   {
      public override void webExecute( )
      {
         context.SetDefaultTheme("WorkWithPlusDS", true);
         initialize();
         GXKey = Crypto.GetSiteKey( );
         if ( nGotPars == 0 )
         {
            entryPointCalled = false;
            gxfirstwebparm = GetNextPar( );
         }
         if ( GxWebError == 0 )
         {
            ExecutePrivate();
         }
         cleanup();
      }

      public listaagruserwwexportreport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public listaagruserwwexportreport( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( )
      {
         initialize();
         ExecutePrivate();
      }

      public void executeSubmit( )
      {
         SubmitImpl();
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         M_top = 0;
         M_bot = 6;
         P_lines = (int)(66-M_bot);
         getPrinter().GxClearAttris() ;
         add_metrics( ) ;
         lineHeight = 15;
         PrtOffset = 0;
         gxXPage = 100;
         gxYPage = 100;
         setOutputFileName("ListaAgrUserWWExportReport");
         setOutputType("PDF");
         try
         {
            Gx_out = "FIL" ;
            if (!initPrinter (Gx_out, gxXPage, gxYPage, "GXPRN.INI", "", "", 2, 1, 1, 15840, 12240, 0, 1, 1, 0, 1, 1) )
            {
               cleanup();
               return;
            }
            getPrinter().setModal(false) ;
            P_lines = (int)(gxYPage-(lineHeight*6));
            Gx_line = (int)(P_lines+1);
            getPrinter().setPageLines(P_lines);
            getPrinter().setLineHeight(lineHeight);
            getPrinter().setM_top(M_top);
            getPrinter().setM_bot(M_bot);
            GXt_boolean1 = AV8IsAuthorized;
            new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWListaAgrUser", out  GXt_boolean1) ;
            AV8IsAuthorized = GXt_boolean1;
            if ( ! AV8IsAuthorized )
            {
               GXKey = Crypto.GetSiteKey( );
               GXEncryptionTmp = "wwpbaseobjects.notauthorized.aspx"+UrlEncode(StringUtil.RTrim(AV64Pgmname));
               CallWebObject(formatLink("wwpbaseobjects.notauthorized.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
               context.wjLocDisableFrm = 1;
            }
            if ( AV8IsAuthorized )
            {
               new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV9WWPContext) ;
               /* Execute user subroutine: 'LOADGRIDSTATE' */
               S151 ();
               if ( returnInSub )
               {
                  cleanup();
                  if (true) return;
               }
               AV58Title = context.GetMessage( "Lista de Agrupar Comercios", "");
               /* Execute user subroutine: 'PRINTFILTERS' */
               S111 ();
               if ( returnInSub )
               {
                  cleanup();
                  if (true) return;
               }
               /* Execute user subroutine: 'PRINTCOLUMNTITLES' */
               S121 ();
               if ( returnInSub )
               {
                  cleanup();
                  if (true) return;
               }
               /* Execute user subroutine: 'PRINTDATA' */
               S131 ();
               if ( returnInSub )
               {
                  cleanup();
                  if (true) return;
               }
               /* Execute user subroutine: 'PRINTFOOTER' */
               S171 ();
               if ( returnInSub )
               {
                  cleanup();
                  if (true) return;
               }
            }
            /* Print footer for last page */
            ToSkip = (int)(P_lines+1);
            H7Q0( true, 0) ;
         }
         catch ( GeneXus.Printer.ProcessInterruptedException  )
         {
         }
         finally
         {
            /* Close printer file */
            try
            {
               getPrinter().GxEndPage() ;
               getPrinter().GxEndDocument() ;
            }
            catch ( GeneXus.Printer.ProcessInterruptedException  )
            {
            }
            endPrinter();
         }
         if ( context.WillRedirect( ) )
         {
            context.Redirect( context.wjLoc );
            context.wjLoc = "";
         }
         cleanup();
      }

      protected void S111( )
      {
         /* 'PRINTFILTERS' Routine */
         returnInSub = false;
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV13FilterFullText)) )
         {
            H7Q0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "WWP_FullTextFilterDescription", ""), 25, Gx_line+0, 99, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV13FilterFullText, "")), 99, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         AV41TFListaAgrUserEstado_Sels.FromJSonString(AV39TFListaAgrUserEstado_SelsJson, null);
         if ( ! ( AV41TFListaAgrUserEstado_Sels.Count == 0 ) )
         {
            AV47i = 1;
            AV67GXV1 = 1;
            while ( AV67GXV1 <= AV41TFListaAgrUserEstado_Sels.Count )
            {
               AV42TFListaAgrUserEstado_Sel = AV41TFListaAgrUserEstado_Sels.GetString(AV67GXV1);
               if ( AV47i == 1 )
               {
                  AV40TFListaAgrUserEstado_SelDscs = "";
               }
               else
               {
                  AV40TFListaAgrUserEstado_SelDscs += ", ";
               }
               AV45FilterTFListaAgrUserEstado_SelValueDescription = context.GetMessage( gxdomainestadoenum.getDescription(context,AV42TFListaAgrUserEstado_Sel), "");
               AV40TFListaAgrUserEstado_SelDscs += AV45FilterTFListaAgrUserEstado_SelValueDescription;
               AV47i = (long)(AV47i+1);
               AV67GXV1 = (int)(AV67GXV1+1);
            }
            H7Q0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Estado", ""), 25, Gx_line+0, 99, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV40TFListaAgrUserEstado_SelDscs, "")), 99, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
      }

      protected void S121( )
      {
         /* 'PRINTCOLUMNTITLES' Routine */
         returnInSub = false;
         H7Q0( false, 22) ;
         getPrinter().GxDrawLine(25, Gx_line+21, 789, Gx_line+21, 2, 8, 160, 134, 0) ;
         Gx_OldLine = Gx_line;
         Gx_line = (int)(Gx_line+22);
         H7Q0( false, 37) ;
         getPrinter().GxAttris("Microsoft Sans Serif", 9, false, false, false, false, 0, 8, 160, 134, 0, 255, 255, 255) ;
         getPrinter().GxDrawText(context.GetMessage( "Listaid", ""), 30, Gx_line+10, 154, Gx_line+27, 2, 0, 0, 0) ;
         getPrinter().GxDrawText(context.GetMessage( "Usuario Nro.", ""), 158, Gx_line+10, 282, Gx_line+27, 2, 0, 0, 0) ;
         getPrinter().GxDrawText(context.GetMessage( "Nombre Completo", ""), 286, Gx_line+10, 534, Gx_line+27, 0, 0, 0, 0) ;
         getPrinter().GxDrawText(context.GetMessage( "Estado", ""), 538, Gx_line+10, 787, Gx_line+27, 0, 0, 0, 0) ;
         Gx_OldLine = Gx_line;
         Gx_line = (int)(Gx_line+37);
      }

      protected void S131( )
      {
         /* 'PRINTDATA' Routine */
         returnInSub = false;
         AV69Listaagruserwwds_1_filterfulltext = AV13FilterFullText;
         AV70Listaagruserwwds_2_tflistaagruserestado_sels = AV41TFListaAgrUserEstado_Sels;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A599ListaAgrUserEstado ,
                                              AV70Listaagruserwwds_2_tflistaagruserestado_sels ,
                                              AV69Listaagruserwwds_1_filterfulltext ,
                                              AV70Listaagruserwwds_2_tflistaagruserestado_sels.Count ,
                                              A590Listaid ,
                                              A587SecUserFullName ,
                                              AV11OrderedBy ,
                                              AV12OrderedDsc } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.LONG, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV69Listaagruserwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV69Listaagruserwwds_1_filterfulltext), "%", "");
         lV69Listaagruserwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV69Listaagruserwwds_1_filterfulltext), "%", "");
         /* Using cursor P007Q2 */
         pr_default.execute(0, new Object[] {lV69Listaagruserwwds_1_filterfulltext, lV69Listaagruserwwds_1_filterfulltext});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A587SecUserFullName = P007Q2_A587SecUserFullName[0];
            A590Listaid = P007Q2_A590Listaid[0];
            A599ListaAgrUserEstado = P007Q2_A599ListaAgrUserEstado[0];
            A18SecUserId = P007Q2_A18SecUserId[0];
            A587SecUserFullName = P007Q2_A587SecUserFullName[0];
            AV28ListaAgrUserEstadoDescription = context.GetMessage( gxdomainestadoenum.getDescription(context,A599ListaAgrUserEstado), "");
            /* Execute user subroutine: 'BEFOREPRINTLINE' */
            S144 ();
            if ( returnInSub )
            {
               pr_default.close(0);
               returnInSub = true;
               if (true) return;
            }
            H7Q0( false, 36) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(A590Listaid), "ZZZZZZZZZZZZZZZZZ9")), 30, Gx_line+10, 154, Gx_line+25, 2+16, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(A18SecUserId), "ZZZZZZZZZ9")), 158, Gx_line+10, 282, Gx_line+25, 2+16, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A587SecUserFullName, "")), 286, Gx_line+10, 534, Gx_line+25, 0+16, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV28ListaAgrUserEstadoDescription, "")), 538, Gx_line+10, 787, Gx_line+25, 0+16, 0, 0, 0) ;
            getPrinter().GxDrawLine(28, Gx_line+35, 789, Gx_line+35, 1, 220, 220, 220, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+36);
            /* Execute user subroutine: 'AFTERPRINTLINE' */
            S161 ();
            if ( returnInSub )
            {
               pr_default.close(0);
               returnInSub = true;
               if (true) return;
            }
            pr_default.readNext(0);
         }
         pr_default.close(0);
      }

      protected void S151( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV29Session.Get("ListaAgrUserWWGridState"), "") == 0 )
         {
            AV31GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "ListaAgrUserWWGridState"), null, "", "");
         }
         else
         {
            AV31GridState.FromXml(AV29Session.Get("ListaAgrUserWWGridState"), null, "", "");
         }
         AV11OrderedBy = AV31GridState.gxTpr_Orderedby;
         AV12OrderedDsc = AV31GridState.gxTpr_Ordereddsc;
         AV71GXV2 = 1;
         while ( AV71GXV2 <= AV31GridState.gxTpr_Filtervalues.Count )
         {
            AV32GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV31GridState.gxTpr_Filtervalues.Item(AV71GXV2));
            if ( StringUtil.StrCmp(AV32GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV13FilterFullText = AV32GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV32GridStateFilterValue.gxTpr_Name, "TFLISTAAGRUSERESTADO_SEL") == 0 )
            {
               AV39TFListaAgrUserEstado_SelsJson = AV32GridStateFilterValue.gxTpr_Value;
               AV41TFListaAgrUserEstado_Sels.FromJSonString(AV39TFListaAgrUserEstado_SelsJson, null);
            }
            AV71GXV2 = (int)(AV71GXV2+1);
         }
      }

      protected void S144( )
      {
         /* 'BEFOREPRINTLINE' Routine */
         returnInSub = false;
      }

      protected void S161( )
      {
         /* 'AFTERPRINTLINE' Routine */
         returnInSub = false;
      }

      protected void S171( )
      {
         /* 'PRINTFOOTER' Routine */
         returnInSub = false;
      }

      protected void H7Q0( bool bFoot ,
                           int Inc )
      {
         /* Skip the required number of lines */
         while ( ( ToSkip > 0 ) || ( Gx_line + Inc > P_lines ) )
         {
            if ( Gx_line + Inc >= P_lines )
            {
               if ( Gx_page > 0 )
               {
                  /* Print footers */
                  Gx_line = P_lines;
                  AV56PageInfo = context.GetMessage( "Page: ", "") + StringUtil.Trim( StringUtil.Str( (decimal)(Gx_page), 6, 0));
                  AV53DateInfo = context.GetMessage( "Date: ", "") + context.localUtil.Format( Gx_date, "99/99/99");
                  getPrinter().GxDrawRect(0, Gx_line+5, 819, Gx_line+40, 1, 0, 0, 0, 1, 8, 160, 134, 1, 1, 1, 1, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV56PageInfo, "")), 30, Gx_line+15, 409, Gx_line+30, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV53DateInfo, "")), 409, Gx_line+15, 789, Gx_line+30, 2, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+40);
                  getPrinter().GxEndPage() ;
                  if ( bFoot )
                  {
                     return  ;
                  }
               }
               ToSkip = 0;
               Gx_line = 0;
               Gx_page = (int)(Gx_page+1);
               /* Skip Margin Top Lines */
               Gx_line = (int)(Gx_line+(M_top*lineHeight));
               /* Print headers */
               getPrinter().GxStartPage() ;
               AV51AppName = context.GetMessage( "DVelop Software Solutions", "");
               AV57Phone = "+1 550 8923";
               AV55Mail = "info@mail.com";
               AV59Website = "http://www.web.com";
               AV48AddressLine1 = "French Boulevard 2859";
               AV49AddressLine2 = "Downtown";
               AV50AddressLine3 = "Paris, France";
               getPrinter().GxDrawRect(0, Gx_line+0, 819, Gx_line+108, 1, 0, 0, 0, 1, 8, 160, 134, 1, 1, 1, 1, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV51AppName, "")), 30, Gx_line+30, 283, Gx_line+45, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 20, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV58Title, "")), 30, Gx_line+45, 283, Gx_line+78, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV57Phone, "")), 283, Gx_line+30, 536, Gx_line+46, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV55Mail, "")), 283, Gx_line+46, 536, Gx_line+62, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV59Website, "")), 283, Gx_line+62, 536, Gx_line+78, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV48AddressLine1, "")), 536, Gx_line+30, 789, Gx_line+46, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV49AddressLine2, "")), 536, Gx_line+46, 789, Gx_line+62, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV50AddressLine3, "")), 536, Gx_line+62, 789, Gx_line+78, 2, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+128);
               if (true) break;
            }
            else
            {
               PrtOffset = 0;
               Gx_line = (int)(Gx_line+1);
            }
            ToSkip = (int)(ToSkip-1);
         }
         getPrinter().setPage(Gx_page);
      }

      protected void add_metrics( )
      {
         add_metrics0( ) ;
      }

      protected void add_metrics0( )
      {
         getPrinter().setMetrics("Microsoft Sans Serif", false, false, 58, 14, 72, 171,  new int[] {48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 18, 20, 23, 36, 36, 57, 43, 12, 21, 21, 25, 37, 18, 21, 18, 18, 36, 36, 36, 36, 36, 36, 36, 36, 36, 36, 18, 18, 37, 37, 37, 36, 65, 43, 43, 46, 46, 43, 39, 50, 46, 18, 32, 43, 36, 53, 46, 50, 43, 50, 46, 43, 40, 46, 43, 64, 41, 42, 39, 18, 18, 18, 27, 36, 21, 36, 36, 32, 36, 36, 18, 36, 36, 14, 15, 33, 14, 55, 36, 36, 36, 36, 21, 32, 18, 36, 33, 47, 31, 31, 31, 21, 17, 21, 37, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 18, 20, 36, 36, 36, 36, 17, 36, 21, 47, 24, 36, 37, 21, 47, 35, 26, 35, 21, 21, 21, 37, 34, 21, 21, 21, 23, 36, 53, 53, 53, 39, 43, 43, 43, 43, 43, 43, 64, 46, 43, 43, 43, 43, 18, 18, 18, 18, 46, 46, 50, 50, 50, 50, 50, 37, 50, 46, 46, 46, 46, 43, 43, 39, 36, 36, 36, 36, 36, 36, 57, 32, 36, 36, 36, 36, 18, 18, 18, 18, 36, 36, 36, 36, 36, 36, 36, 35, 39, 36, 36, 36, 36, 32, 36, 32}) ;
      }

      public override int getOutputType( )
      {
         return GxReportUtils.OUTPUT_PDF ;
      }

      public override void cleanup( )
      {
         CloseCursors();
         base.cleanup();
         if ( IsMain )
         {
            context.CloseConnections();
         }
         ExitApp();
      }

      public override void initialize( )
      {
         GXKey = "";
         gxfirstwebparm = "";
         AV64Pgmname = "";
         GXEncryptionTmp = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV58Title = "";
         AV13FilterFullText = "";
         AV41TFListaAgrUserEstado_Sels = new GxSimpleCollection<string>();
         AV39TFListaAgrUserEstado_SelsJson = "";
         AV42TFListaAgrUserEstado_Sel = "";
         AV40TFListaAgrUserEstado_SelDscs = "";
         AV45FilterTFListaAgrUserEstado_SelValueDescription = "";
         AV69Listaagruserwwds_1_filterfulltext = "";
         AV70Listaagruserwwds_2_tflistaagruserestado_sels = new GxSimpleCollection<string>();
         lV69Listaagruserwwds_1_filterfulltext = "";
         A599ListaAgrUserEstado = "";
         A587SecUserFullName = "";
         P007Q2_A587SecUserFullName = new string[] {""} ;
         P007Q2_A590Listaid = new long[1] ;
         P007Q2_A599ListaAgrUserEstado = new string[] {""} ;
         P007Q2_A18SecUserId = new long[1] ;
         AV28ListaAgrUserEstadoDescription = "";
         AV29Session = context.GetSession();
         AV31GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV32GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV56PageInfo = "";
         AV53DateInfo = "";
         Gx_date = DateTime.MinValue;
         AV51AppName = "";
         AV57Phone = "";
         AV55Mail = "";
         AV59Website = "";
         AV48AddressLine1 = "";
         AV49AddressLine2 = "";
         AV50AddressLine3 = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.listaagruserwwexportreport__default(),
            new Object[][] {
                new Object[] {
               P007Q2_A587SecUserFullName, P007Q2_A590Listaid, P007Q2_A599ListaAgrUserEstado, P007Q2_A18SecUserId
               }
            }
         );
         Gx_date = DateTimeUtil.Today( context);
         AV64Pgmname = "ListaAgrUserWWExportReport";
         /* GeneXus formulas. */
         Gx_line = 0;
         Gx_date = DateTimeUtil.Today( context);
         AV64Pgmname = "ListaAgrUserWWExportReport";
      }

      private short nGotPars ;
      private short GxWebError ;
      private short AV11OrderedBy ;
      private int M_top ;
      private int M_bot ;
      private int Line ;
      private int ToSkip ;
      private int PrtOffset ;
      private int Gx_OldLine ;
      private int AV67GXV1 ;
      private int AV70Listaagruserwwds_2_tflistaagruserestado_sels_Count ;
      private int AV71GXV2 ;
      private long AV47i ;
      private long A590Listaid ;
      private long A18SecUserId ;
      private string GXKey ;
      private string gxfirstwebparm ;
      private string AV64Pgmname ;
      private string GXEncryptionTmp ;
      private string AV42TFListaAgrUserEstado_Sel ;
      private string A599ListaAgrUserEstado ;
      private DateTime Gx_date ;
      private bool entryPointCalled ;
      private bool AV8IsAuthorized ;
      private bool GXt_boolean1 ;
      private bool returnInSub ;
      private bool AV12OrderedDsc ;
      private string AV39TFListaAgrUserEstado_SelsJson ;
      private string AV58Title ;
      private string AV13FilterFullText ;
      private string AV40TFListaAgrUserEstado_SelDscs ;
      private string AV45FilterTFListaAgrUserEstado_SelValueDescription ;
      private string AV69Listaagruserwwds_1_filterfulltext ;
      private string lV69Listaagruserwwds_1_filterfulltext ;
      private string A587SecUserFullName ;
      private string AV28ListaAgrUserEstadoDescription ;
      private string AV56PageInfo ;
      private string AV53DateInfo ;
      private string AV51AppName ;
      private string AV57Phone ;
      private string AV55Mail ;
      private string AV59Website ;
      private string AV48AddressLine1 ;
      private string AV49AddressLine2 ;
      private string AV50AddressLine3 ;
      private IGxSession AV29Session ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GxSimpleCollection<string> AV41TFListaAgrUserEstado_Sels ;
      private GxSimpleCollection<string> AV70Listaagruserwwds_2_tflistaagruserestado_sels ;
      private IDataStoreProvider pr_default ;
      private string[] P007Q2_A587SecUserFullName ;
      private long[] P007Q2_A590Listaid ;
      private string[] P007Q2_A599ListaAgrUserEstado ;
      private long[] P007Q2_A18SecUserId ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV31GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV32GridStateFilterValue ;
   }

   public class listaagruserwwexportreport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P007Q2( IGxContext context ,
                                             string A599ListaAgrUserEstado ,
                                             GxSimpleCollection<string> AV70Listaagruserwwds_2_tflistaagruserestado_sels ,
                                             string AV69Listaagruserwwds_1_filterfulltext ,
                                             int AV70Listaagruserwwds_2_tflistaagruserestado_sels_Count ,
                                             long A590Listaid ,
                                             string A587SecUserFullName ,
                                             short AV11OrderedBy ,
                                             bool AV12OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int2 = new short[2];
         Object[] GXv_Object3 = new Object[2];
         scmdbuf = "SELECT T2.[SecUserFullName], T1.[Listaid], T1.[ListaAgrUserEstado], T1.[SecUserId] FROM ([ListaAgrUser] T1 INNER JOIN [SecUser] T2 ON T2.[SecUserId] = T1.[SecUserId])";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Listaagruserwwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( CONVERT( char(18), CAST(T1.[Listaid] AS decimal(18,0))) like '%' + @lV69Listaagruserwwds_1_filterfulltext) or ( UPPER(T2.[SecUserFullName]) like '%' + UPPER(@lV69Listaagruserwwds_1_filterfulltext)))");
         }
         else
         {
            GXv_int2[0] = 1;
            GXv_int2[1] = 1;
         }
         if ( AV70Listaagruserwwds_2_tflistaagruserestado_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV70Listaagruserwwds_2_tflistaagruserestado_sels, "T1.[ListaAgrUserEstado] IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         if ( ( AV11OrderedBy == 1 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[ListaAgrUserEstado]";
         }
         else if ( ( AV11OrderedBy == 1 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[ListaAgrUserEstado] DESC";
         }
         else if ( ( AV11OrderedBy == 2 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[Listaid]";
         }
         else if ( ( AV11OrderedBy == 2 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[Listaid] DESC";
         }
         else if ( ( AV11OrderedBy == 3 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[SecUserId]";
         }
         else if ( ( AV11OrderedBy == 3 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[SecUserId] DESC";
         }
         else if ( ( AV11OrderedBy == 4 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY T2.[SecUserFullName]";
         }
         else if ( ( AV11OrderedBy == 4 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T2.[SecUserFullName] DESC";
         }
         GXv_Object3[0] = scmdbuf;
         GXv_Object3[1] = GXv_int2;
         return GXv_Object3 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_P007Q2(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (int)dynConstraints[3] , (long)dynConstraints[4] , (string)dynConstraints[5] , (short)dynConstraints[6] , (bool)dynConstraints[7] );
         }
         return base.getDynamicStatement(cursor, context, dynConstraints);
      }

      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP007Q2;
          prmP007Q2 = new Object[] {
          new ParDef("@lV69Listaagruserwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV69Listaagruserwwds_1_filterfulltext",GXType.VarChar,100,0)
          };
          def= new CursorDef[] {
              new CursorDef("P007Q2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP007Q2,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((long[]) buf[1])[0] = rslt.getLong(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 3);
                ((long[]) buf[3])[0] = rslt.getLong(4);
                return;
       }
    }

 }

}

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
   public class estadoswwexportreport : GXWebProcedure, System.Web.SessionState.IRequiresSessionState
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

      public estadoswwexportreport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public estadoswwexportreport( IGxContext context )
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
         setOutputFileName("EstadosWWExportReport");
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
            new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWEstados", out  GXt_boolean1) ;
            AV8IsAuthorized = GXt_boolean1;
            if ( ! AV8IsAuthorized )
            {
               GXKey = Crypto.GetSiteKey( );
               GXEncryptionTmp = "wwpbaseobjects.notauthorized.aspx"+UrlEncode(StringUtil.RTrim(AV35Pgmname));
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
               AV33Title = context.GetMessage( "Lista de Estados", "");
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
            HC60( true, 0) ;
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
            HC60( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "WWP_FullTextFilterDescription", ""), 25, Gx_line+0, 112, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV13FilterFullText, "")), 112, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV19TFEstadosTipo_Sel)) )
         {
            AV22TempBoolean = (bool)(((StringUtil.StrCmp(AV19TFEstadosTipo_Sel, "<#Empty#>")==0)));
            AV19TFEstadosTipo_Sel = (AV22TempBoolean ? context.GetMessage( "WWP_TitleFilter_EmptyOption", "") : AV19TFEstadosTipo_Sel);
            HC60( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Tipo de Estados", ""), 25, Gx_line+0, 112, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV19TFEstadosTipo_Sel, "")), 112, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV19TFEstadosTipo_Sel = (AV22TempBoolean ? "<#Empty#>" : AV19TFEstadosTipo_Sel);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV18TFEstadosTipo)) )
            {
               HC60( false, 20) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(context.GetMessage( "Tipo de Estados", ""), 25, Gx_line+0, 112, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV18TFEstadosTipo, "")), 112, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV21TFEstadosDescrip_Sel)) )
         {
            AV22TempBoolean = (bool)(((StringUtil.StrCmp(AV21TFEstadosDescrip_Sel, "<#Empty#>")==0)));
            AV21TFEstadosDescrip_Sel = (AV22TempBoolean ? context.GetMessage( "WWP_TitleFilter_EmptyOption", "") : AV21TFEstadosDescrip_Sel);
            HC60( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Descripción", ""), 25, Gx_line+0, 112, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV21TFEstadosDescrip_Sel, "")), 112, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV21TFEstadosDescrip_Sel = (AV22TempBoolean ? "<#Empty#>" : AV21TFEstadosDescrip_Sel);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV20TFEstadosDescrip)) )
            {
               HC60( false, 20) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(context.GetMessage( "Descripción", ""), 25, Gx_line+0, 112, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV20TFEstadosDescrip, "")), 112, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
      }

      protected void S121( )
      {
         /* 'PRINTCOLUMNTITLES' Routine */
         returnInSub = false;
         HC60( false, 22) ;
         getPrinter().GxDrawLine(25, Gx_line+21, 789, Gx_line+21, 2, 8, 160, 134, 0) ;
         Gx_OldLine = Gx_line;
         Gx_line = (int)(Gx_line+22);
         HC60( false, 37) ;
         getPrinter().GxAttris("Microsoft Sans Serif", 9, false, false, false, false, 0, 8, 160, 134, 0, 255, 255, 255) ;
         getPrinter().GxDrawText(context.GetMessage( "Tipo de Estados", ""), 30, Gx_line+10, 281, Gx_line+27, 0, 0, 0, 0) ;
         getPrinter().GxDrawText(context.GetMessage( "Descripción", ""), 285, Gx_line+10, 787, Gx_line+27, 0, 0, 0, 0) ;
         Gx_OldLine = Gx_line;
         Gx_line = (int)(Gx_line+37);
      }

      protected void S131( )
      {
         /* 'PRINTDATA' Routine */
         returnInSub = false;
         AV39Estadoswwds_1_filterfulltext = AV13FilterFullText;
         AV40Estadoswwds_2_tfestadostipo = AV18TFEstadosTipo;
         AV41Estadoswwds_3_tfestadostipo_sel = AV19TFEstadosTipo_Sel;
         AV42Estadoswwds_4_tfestadosdescrip = AV20TFEstadosDescrip;
         AV43Estadoswwds_5_tfestadosdescrip_sel = AV21TFEstadosDescrip_Sel;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV39Estadoswwds_1_filterfulltext ,
                                              AV41Estadoswwds_3_tfestadostipo_sel ,
                                              AV40Estadoswwds_2_tfestadostipo ,
                                              AV43Estadoswwds_5_tfestadosdescrip_sel ,
                                              AV42Estadoswwds_4_tfestadosdescrip ,
                                              A107EstadosTipo ,
                                              A158EstadosDescrip ,
                                              AV11OrderedBy ,
                                              AV12OrderedDsc } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV39Estadoswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV39Estadoswwds_1_filterfulltext), "%", "");
         lV39Estadoswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV39Estadoswwds_1_filterfulltext), "%", "");
         lV40Estadoswwds_2_tfestadostipo = StringUtil.PadR( StringUtil.RTrim( AV40Estadoswwds_2_tfestadostipo), 3, "%");
         lV42Estadoswwds_4_tfestadosdescrip = StringUtil.PadR( StringUtil.RTrim( AV42Estadoswwds_4_tfestadosdescrip), 80, "%");
         /* Using cursor P00C62 */
         pr_default.execute(0, new Object[] {lV39Estadoswwds_1_filterfulltext, lV39Estadoswwds_1_filterfulltext, lV40Estadoswwds_2_tfestadostipo, AV41Estadoswwds_3_tfestadostipo_sel, lV42Estadoswwds_4_tfestadosdescrip, AV43Estadoswwds_5_tfestadosdescrip_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A158EstadosDescrip = P00C62_A158EstadosDescrip[0];
            A107EstadosTipo = P00C62_A107EstadosTipo[0];
            /* Execute user subroutine: 'BEFOREPRINTLINE' */
            S144 ();
            if ( returnInSub )
            {
               pr_default.close(0);
               returnInSub = true;
               if (true) return;
            }
            HC60( false, 36) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A107EstadosTipo, "")), 30, Gx_line+10, 281, Gx_line+25, 0+16, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A158EstadosDescrip, "")), 285, Gx_line+10, 787, Gx_line+25, 0+16, 0, 0, 0) ;
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
         if ( StringUtil.StrCmp(AV14Session.Get("EstadosWWGridState"), "") == 0 )
         {
            AV16GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "EstadosWWGridState"), null, "", "");
         }
         else
         {
            AV16GridState.FromXml(AV14Session.Get("EstadosWWGridState"), null, "", "");
         }
         AV11OrderedBy = AV16GridState.gxTpr_Orderedby;
         AV12OrderedDsc = AV16GridState.gxTpr_Ordereddsc;
         AV44GXV1 = 1;
         while ( AV44GXV1 <= AV16GridState.gxTpr_Filtervalues.Count )
         {
            AV17GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV16GridState.gxTpr_Filtervalues.Item(AV44GXV1));
            if ( StringUtil.StrCmp(AV17GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV13FilterFullText = AV17GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV17GridStateFilterValue.gxTpr_Name, "TFESTADOSTIPO") == 0 )
            {
               AV18TFEstadosTipo = AV17GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV17GridStateFilterValue.gxTpr_Name, "TFESTADOSTIPO_SEL") == 0 )
            {
               AV19TFEstadosTipo_Sel = AV17GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV17GridStateFilterValue.gxTpr_Name, "TFESTADOSDESCRIP") == 0 )
            {
               AV20TFEstadosDescrip = AV17GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV17GridStateFilterValue.gxTpr_Name, "TFESTADOSDESCRIP_SEL") == 0 )
            {
               AV21TFEstadosDescrip_Sel = AV17GridStateFilterValue.gxTpr_Value;
            }
            AV44GXV1 = (int)(AV44GXV1+1);
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

      protected void HC60( bool bFoot ,
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
                  AV31PageInfo = context.GetMessage( "Page: ", "") + StringUtil.Trim( StringUtil.Str( (decimal)(Gx_page), 6, 0));
                  AV28DateInfo = context.GetMessage( "Date: ", "") + context.localUtil.Format( Gx_date, "99/99/99");
                  getPrinter().GxDrawRect(0, Gx_line+5, 819, Gx_line+40, 1, 0, 0, 0, 1, 8, 160, 134, 1, 1, 1, 1, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV31PageInfo, "")), 30, Gx_line+15, 409, Gx_line+30, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV28DateInfo, "")), 409, Gx_line+15, 789, Gx_line+30, 2, 0, 0, 0) ;
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
               AV26AppName = context.GetMessage( "DVelop Software Solutions", "");
               AV32Phone = "+1 550 8923";
               AV30Mail = "info@mail.com";
               AV34Website = "http://www.web.com";
               AV23AddressLine1 = "French Boulevard 2859";
               AV24AddressLine2 = "Downtown";
               AV25AddressLine3 = "Paris, France";
               getPrinter().GxDrawRect(0, Gx_line+0, 819, Gx_line+108, 1, 0, 0, 0, 1, 8, 160, 134, 1, 1, 1, 1, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV26AppName, "")), 30, Gx_line+30, 283, Gx_line+45, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 20, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV33Title, "")), 30, Gx_line+45, 283, Gx_line+78, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV32Phone, "")), 283, Gx_line+30, 536, Gx_line+46, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV30Mail, "")), 283, Gx_line+46, 536, Gx_line+62, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV34Website, "")), 283, Gx_line+62, 536, Gx_line+78, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV23AddressLine1, "")), 536, Gx_line+30, 789, Gx_line+46, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV24AddressLine2, "")), 536, Gx_line+46, 789, Gx_line+62, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV25AddressLine3, "")), 536, Gx_line+62, 789, Gx_line+78, 2, 0, 0, 0) ;
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
         AV35Pgmname = "";
         GXEncryptionTmp = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV33Title = "";
         AV13FilterFullText = "";
         AV19TFEstadosTipo_Sel = "";
         AV18TFEstadosTipo = "";
         AV21TFEstadosDescrip_Sel = "";
         AV20TFEstadosDescrip = "";
         AV39Estadoswwds_1_filterfulltext = "";
         AV40Estadoswwds_2_tfestadostipo = "";
         AV41Estadoswwds_3_tfestadostipo_sel = "";
         AV42Estadoswwds_4_tfestadosdescrip = "";
         AV43Estadoswwds_5_tfestadosdescrip_sel = "";
         lV39Estadoswwds_1_filterfulltext = "";
         lV40Estadoswwds_2_tfestadostipo = "";
         lV42Estadoswwds_4_tfestadosdescrip = "";
         A107EstadosTipo = "";
         A158EstadosDescrip = "";
         P00C62_A158EstadosDescrip = new string[] {""} ;
         P00C62_A107EstadosTipo = new string[] {""} ;
         AV14Session = context.GetSession();
         AV16GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV17GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV31PageInfo = "";
         AV28DateInfo = "";
         Gx_date = DateTime.MinValue;
         AV26AppName = "";
         AV32Phone = "";
         AV30Mail = "";
         AV34Website = "";
         AV23AddressLine1 = "";
         AV24AddressLine2 = "";
         AV25AddressLine3 = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.estadoswwexportreport__default(),
            new Object[][] {
                new Object[] {
               P00C62_A158EstadosDescrip, P00C62_A107EstadosTipo
               }
            }
         );
         Gx_date = DateTimeUtil.Today( context);
         AV35Pgmname = "EstadosWWExportReport";
         /* GeneXus formulas. */
         Gx_line = 0;
         Gx_date = DateTimeUtil.Today( context);
         AV35Pgmname = "EstadosWWExportReport";
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
      private int AV44GXV1 ;
      private string GXKey ;
      private string gxfirstwebparm ;
      private string AV35Pgmname ;
      private string GXEncryptionTmp ;
      private string AV19TFEstadosTipo_Sel ;
      private string AV18TFEstadosTipo ;
      private string AV21TFEstadosDescrip_Sel ;
      private string AV20TFEstadosDescrip ;
      private string AV40Estadoswwds_2_tfestadostipo ;
      private string AV41Estadoswwds_3_tfestadostipo_sel ;
      private string AV42Estadoswwds_4_tfestadosdescrip ;
      private string AV43Estadoswwds_5_tfestadosdescrip_sel ;
      private string lV40Estadoswwds_2_tfestadostipo ;
      private string lV42Estadoswwds_4_tfestadosdescrip ;
      private string A107EstadosTipo ;
      private string A158EstadosDescrip ;
      private DateTime Gx_date ;
      private bool entryPointCalled ;
      private bool AV8IsAuthorized ;
      private bool GXt_boolean1 ;
      private bool returnInSub ;
      private bool AV22TempBoolean ;
      private bool AV12OrderedDsc ;
      private string AV33Title ;
      private string AV13FilterFullText ;
      private string AV39Estadoswwds_1_filterfulltext ;
      private string lV39Estadoswwds_1_filterfulltext ;
      private string AV31PageInfo ;
      private string AV28DateInfo ;
      private string AV26AppName ;
      private string AV32Phone ;
      private string AV30Mail ;
      private string AV34Website ;
      private string AV23AddressLine1 ;
      private string AV24AddressLine2 ;
      private string AV25AddressLine3 ;
      private IGxSession AV14Session ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private IDataStoreProvider pr_default ;
      private string[] P00C62_A158EstadosDescrip ;
      private string[] P00C62_A107EstadosTipo ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV16GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV17GridStateFilterValue ;
   }

   public class estadoswwexportreport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00C62( IGxContext context ,
                                             string AV39Estadoswwds_1_filterfulltext ,
                                             string AV41Estadoswwds_3_tfestadostipo_sel ,
                                             string AV40Estadoswwds_2_tfestadostipo ,
                                             string AV43Estadoswwds_5_tfestadosdescrip_sel ,
                                             string AV42Estadoswwds_4_tfestadosdescrip ,
                                             string A107EstadosTipo ,
                                             string A158EstadosDescrip ,
                                             short AV11OrderedBy ,
                                             bool AV12OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int2 = new short[6];
         Object[] GXv_Object3 = new Object[2];
         scmdbuf = "SELECT [EstadosDescrip], [EstadosTipo] FROM [Estados]";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV39Estadoswwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( UPPER([EstadosTipo]) like '%' + UPPER(@lV39Estadoswwds_1_filterfulltext)) or ( UPPER([EstadosDescrip]) like '%' + UPPER(@lV39Estadoswwds_1_filterfulltext)))");
         }
         else
         {
            GXv_int2[0] = 1;
            GXv_int2[1] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV41Estadoswwds_3_tfestadostipo_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV40Estadoswwds_2_tfestadostipo)) ) )
         {
            AddWhere(sWhereString, "(UPPER([EstadosTipo]) like UPPER(@lV40Estadoswwds_2_tfestadostipo))");
         }
         else
         {
            GXv_int2[2] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV41Estadoswwds_3_tfestadostipo_sel)) && ! ( StringUtil.StrCmp(AV41Estadoswwds_3_tfestadostipo_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([EstadosTipo] = @AV41Estadoswwds_3_tfestadostipo_sel)");
         }
         else
         {
            GXv_int2[3] = 1;
         }
         if ( StringUtil.StrCmp(AV41Estadoswwds_3_tfestadostipo_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([EstadosTipo] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV43Estadoswwds_5_tfestadosdescrip_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV42Estadoswwds_4_tfestadosdescrip)) ) )
         {
            AddWhere(sWhereString, "(UPPER([EstadosDescrip]) like UPPER(@lV42Estadoswwds_4_tfestadosdescrip))");
         }
         else
         {
            GXv_int2[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV43Estadoswwds_5_tfestadosdescrip_sel)) && ! ( StringUtil.StrCmp(AV43Estadoswwds_5_tfestadosdescrip_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([EstadosDescrip] = @AV43Estadoswwds_5_tfestadosdescrip_sel)");
         }
         else
         {
            GXv_int2[5] = 1;
         }
         if ( StringUtil.StrCmp(AV43Estadoswwds_5_tfestadosdescrip_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([EstadosDescrip] = ''))");
         }
         scmdbuf += sWhereString;
         if ( ( AV11OrderedBy == 1 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY [EstadosDescrip]";
         }
         else if ( ( AV11OrderedBy == 1 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [EstadosDescrip] DESC";
         }
         else if ( ( AV11OrderedBy == 2 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY [EstadosTipo]";
         }
         else if ( ( AV11OrderedBy == 2 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [EstadosTipo] DESC";
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
                     return conditional_P00C62(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (short)dynConstraints[7] , (bool)dynConstraints[8] );
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
          Object[] prmP00C62;
          prmP00C62 = new Object[] {
          new ParDef("@lV39Estadoswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV39Estadoswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV40Estadoswwds_2_tfestadostipo",GXType.Char,3,0) ,
          new ParDef("@AV41Estadoswwds_3_tfestadostipo_sel",GXType.NChar,3,0) ,
          new ParDef("@lV42Estadoswwds_4_tfestadosdescrip",GXType.Char,80,0) ,
          new ParDef("@AV43Estadoswwds_5_tfestadosdescrip_sel",GXType.NChar,80,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00C62", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00C62,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[0])[0] = rslt.getString(1, 80);
                ((string[]) buf[1])[0] = rslt.getString(2, 3);
                return;
       }
    }

 }

}

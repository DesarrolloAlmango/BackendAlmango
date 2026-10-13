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
   public class tipocuentawwexportreport : GXWebProcedure, System.Web.SessionState.IRequiresSessionState
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

      public tipocuentawwexportreport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public tipocuentawwexportreport( IGxContext context )
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
         setOutputFileName("TipoCuentaWWExportReport");
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
            new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWTipoCuenta", out  GXt_boolean1) ;
            AV8IsAuthorized = GXt_boolean1;
            if ( ! AV8IsAuthorized )
            {
               GXKey = Crypto.GetSiteKey( );
               GXEncryptionTmp = "wwpbaseobjects.notauthorized.aspx"+UrlEncode(StringUtil.RTrim(AV43Pgmname));
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
               AV41Title = context.GetMessage( "Lista de Tipo Cuenta", "");
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
            HDE0( true, 0) ;
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
            HDE0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "WWP_FullTextFilterDescription", ""), 25, Gx_line+0, 147, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV13FilterFullText, "")), 147, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         if ( ! ( (0==AV19TFTipoCuentaId) && (0==AV20TFTipoCuentaId_To) ) )
         {
            HDE0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Tipo de Cuenta", ""), 25, Gx_line+0, 147, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV19TFTipoCuentaId), "ZZZZZZZZZZZZZZZZZ9")), 147, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV27TFTipoCuentaId_To_Description = StringUtil.Format( "%1 (%2)", context.GetMessage( "Tipo de Cuenta", ""), context.GetMessage( "WWP_TSTo", ""), "", "", "", "", "", "", "");
            HDE0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV27TFTipoCuentaId_To_Description, "")), 25, Gx_line+0, 147, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV20TFTipoCuentaId_To), "ZZZZZZZZZZZZZZZZZ9")), 147, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV22TFTipoCuentaNombre_Sel)) )
         {
            AV29TempBoolean = (bool)(((StringUtil.StrCmp(AV22TFTipoCuentaNombre_Sel, "<#Empty#>")==0)));
            AV22TFTipoCuentaNombre_Sel = (AV29TempBoolean ? context.GetMessage( "WWP_TitleFilter_EmptyOption", "") : AV22TFTipoCuentaNombre_Sel);
            HDE0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Tipo de Cuenta", ""), 25, Gx_line+0, 147, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV22TFTipoCuentaNombre_Sel, "")), 147, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV22TFTipoCuentaNombre_Sel = (AV29TempBoolean ? "<#Empty#>" : AV22TFTipoCuentaNombre_Sel);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV21TFTipoCuentaNombre)) )
            {
               HDE0( false, 20) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(context.GetMessage( "Tipo de Cuenta", ""), 25, Gx_line+0, 147, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV21TFTipoCuentaNombre, "")), 147, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
         AV26TFTipoCuentaConcepto_Sels.FromJSonString(AV23TFTipoCuentaConcepto_SelsJson, null);
         if ( ! ( AV26TFTipoCuentaConcepto_Sels.Count == 0 ) )
         {
            AV30i = 1;
            AV46GXV1 = 1;
            while ( AV46GXV1 <= AV26TFTipoCuentaConcepto_Sels.Count )
            {
               AV25TFTipoCuentaConcepto_Sel = AV26TFTipoCuentaConcepto_Sels.GetString(AV46GXV1);
               if ( AV30i == 1 )
               {
                  AV24TFTipoCuentaConcepto_SelDscs = "";
               }
               else
               {
                  AV24TFTipoCuentaConcepto_SelDscs += ", ";
               }
               AV28FilterTFTipoCuentaConcepto_SelValueDescription = context.GetMessage( gxdomaintipocuentaconenum.getDescription(context,AV25TFTipoCuentaConcepto_Sel), "");
               AV24TFTipoCuentaConcepto_SelDscs += AV28FilterTFTipoCuentaConcepto_SelValueDescription;
               AV30i = (long)(AV30i+1);
               AV46GXV1 = (int)(AV46GXV1+1);
            }
            HDE0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Tipo de Concepto", ""), 25, Gx_line+0, 147, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV24TFTipoCuentaConcepto_SelDscs, "")), 147, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
      }

      protected void S121( )
      {
         /* 'PRINTCOLUMNTITLES' Routine */
         returnInSub = false;
         HDE0( false, 22) ;
         getPrinter().GxDrawLine(25, Gx_line+21, 789, Gx_line+21, 2, 8, 160, 134, 0) ;
         Gx_OldLine = Gx_line;
         Gx_line = (int)(Gx_line+22);
         HDE0( false, 37) ;
         getPrinter().GxAttris("Microsoft Sans Serif", 9, false, false, false, false, 0, 8, 160, 134, 0, 255, 255, 255) ;
         getPrinter().GxDrawText(context.GetMessage( "Tipo de Cuenta", ""), 30, Gx_line+10, 179, Gx_line+27, 2, 0, 0, 0) ;
         getPrinter().GxDrawText(context.GetMessage( "Tipo de Cuenta", ""), 183, Gx_line+10, 483, Gx_line+27, 0, 0, 0, 0) ;
         getPrinter().GxDrawText(context.GetMessage( "Tipo de Concepto", ""), 487, Gx_line+10, 787, Gx_line+27, 0, 0, 0, 0) ;
         Gx_OldLine = Gx_line;
         Gx_line = (int)(Gx_line+37);
      }

      protected void S131( )
      {
         /* 'PRINTDATA' Routine */
         returnInSub = false;
         AV48Tipocuentawwds_1_filterfulltext = AV13FilterFullText;
         AV49Tipocuentawwds_2_tftipocuentaid = AV19TFTipoCuentaId;
         AV50Tipocuentawwds_3_tftipocuentaid_to = AV20TFTipoCuentaId_To;
         AV51Tipocuentawwds_4_tftipocuentanombre = AV21TFTipoCuentaNombre;
         AV52Tipocuentawwds_5_tftipocuentanombre_sel = AV22TFTipoCuentaNombre_Sel;
         AV53Tipocuentawwds_6_tftipocuentaconcepto_sels = AV26TFTipoCuentaConcepto_Sels;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A636TipoCuentaConcepto ,
                                              AV53Tipocuentawwds_6_tftipocuentaconcepto_sels ,
                                              AV49Tipocuentawwds_2_tftipocuentaid ,
                                              AV50Tipocuentawwds_3_tftipocuentaid_to ,
                                              AV52Tipocuentawwds_5_tftipocuentanombre_sel ,
                                              AV51Tipocuentawwds_4_tftipocuentanombre ,
                                              AV53Tipocuentawwds_6_tftipocuentaconcepto_sels.Count ,
                                              A483TipoCuentaId ,
                                              A484TipoCuentaNombre ,
                                              AV11OrderedBy ,
                                              AV12OrderedDsc ,
                                              AV48Tipocuentawwds_1_filterfulltext } ,
                                              new int[]{
                                              TypeConstants.LONG, TypeConstants.LONG, TypeConstants.INT, TypeConstants.LONG, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV51Tipocuentawwds_4_tftipocuentanombre = StringUtil.PadR( StringUtil.RTrim( AV51Tipocuentawwds_4_tftipocuentanombre), 120, "%");
         /* Using cursor P00DE2 */
         pr_default.execute(0, new Object[] {AV49Tipocuentawwds_2_tftipocuentaid, AV50Tipocuentawwds_3_tftipocuentaid_to, lV51Tipocuentawwds_4_tftipocuentanombre, AV52Tipocuentawwds_5_tftipocuentanombre_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A484TipoCuentaNombre = P00DE2_A484TipoCuentaNombre[0];
            A483TipoCuentaId = P00DE2_A483TipoCuentaId[0];
            A636TipoCuentaConcepto = P00DE2_A636TipoCuentaConcepto[0];
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV48Tipocuentawwds_1_filterfulltext)) || ( ( StringUtil.Like( StringUtil.Str( (decimal)(A483TipoCuentaId), 18, 0) , StringUtil.PadR( "%" + AV48Tipocuentawwds_1_filterfulltext , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A484TipoCuentaNombre) , StringUtil.PadR( "%" + StringUtil.Upper( AV48Tipocuentawwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( context.GetMessage( "saldo por cuentas", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV48Tipocuentawwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A636TipoCuentaConcepto, "SAL") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "usada en centro costo", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV48Tipocuentawwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A636TipoCuentaConcepto, "COS") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "otros", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV48Tipocuentawwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A636TipoCuentaConcepto, "OTR") == 0 ) ) ) )
            {
               AV14TipoCuentaConceptoDescription = context.GetMessage( gxdomaintipocuentaconenum.getDescription(context,A636TipoCuentaConcepto), "");
               /* Execute user subroutine: 'BEFOREPRINTLINE' */
               S144 ();
               if ( returnInSub )
               {
                  pr_default.close(0);
                  returnInSub = true;
                  if (true) return;
               }
               HDE0( false, 36) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(A483TipoCuentaId), "ZZZZZZZZZZZZZZZZZ9")), 30, Gx_line+10, 179, Gx_line+25, 2+16, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A484TipoCuentaNombre, "")), 183, Gx_line+10, 483, Gx_line+25, 0+16, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV14TipoCuentaConceptoDescription, "")), 487, Gx_line+10, 787, Gx_line+25, 0+16, 0, 0, 0) ;
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
            }
            pr_default.readNext(0);
         }
         pr_default.close(0);
      }

      protected void S151( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV15Session.Get("TipoCuentaWWGridState"), "") == 0 )
         {
            AV17GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "TipoCuentaWWGridState"), null, "", "");
         }
         else
         {
            AV17GridState.FromXml(AV15Session.Get("TipoCuentaWWGridState"), null, "", "");
         }
         AV11OrderedBy = AV17GridState.gxTpr_Orderedby;
         AV12OrderedDsc = AV17GridState.gxTpr_Ordereddsc;
         AV54GXV2 = 1;
         while ( AV54GXV2 <= AV17GridState.gxTpr_Filtervalues.Count )
         {
            AV18GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV17GridState.gxTpr_Filtervalues.Item(AV54GXV2));
            if ( StringUtil.StrCmp(AV18GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV13FilterFullText = AV18GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV18GridStateFilterValue.gxTpr_Name, "TFTIPOCUENTAID") == 0 )
            {
               AV19TFTipoCuentaId = (long)(Math.Round(NumberUtil.Val( AV18GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV20TFTipoCuentaId_To = (long)(Math.Round(NumberUtil.Val( AV18GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV18GridStateFilterValue.gxTpr_Name, "TFTIPOCUENTANOMBRE") == 0 )
            {
               AV21TFTipoCuentaNombre = AV18GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV18GridStateFilterValue.gxTpr_Name, "TFTIPOCUENTANOMBRE_SEL") == 0 )
            {
               AV22TFTipoCuentaNombre_Sel = AV18GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV18GridStateFilterValue.gxTpr_Name, "TFTIPOCUENTACONCEPTO_SEL") == 0 )
            {
               AV23TFTipoCuentaConcepto_SelsJson = AV18GridStateFilterValue.gxTpr_Value;
               AV26TFTipoCuentaConcepto_Sels.FromJSonString(AV23TFTipoCuentaConcepto_SelsJson, null);
            }
            AV54GXV2 = (int)(AV54GXV2+1);
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

      protected void HDE0( bool bFoot ,
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
                  AV39PageInfo = context.GetMessage( "Page: ", "") + StringUtil.Trim( StringUtil.Str( (decimal)(Gx_page), 6, 0));
                  AV36DateInfo = context.GetMessage( "Date: ", "") + context.localUtil.Format( Gx_date, "99/99/99");
                  getPrinter().GxDrawRect(0, Gx_line+5, 819, Gx_line+40, 1, 0, 0, 0, 1, 8, 160, 134, 1, 1, 1, 1, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV39PageInfo, "")), 30, Gx_line+15, 409, Gx_line+30, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV36DateInfo, "")), 409, Gx_line+15, 789, Gx_line+30, 2, 0, 0, 0) ;
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
               AV34AppName = context.GetMessage( "DVelop Software Solutions", "");
               AV40Phone = "+1 550 8923";
               AV38Mail = "info@mail.com";
               AV42Website = "http://www.web.com";
               AV31AddressLine1 = "French Boulevard 2859";
               AV32AddressLine2 = "Downtown";
               AV33AddressLine3 = "Paris, France";
               getPrinter().GxDrawRect(0, Gx_line+0, 819, Gx_line+108, 1, 0, 0, 0, 1, 8, 160, 134, 1, 1, 1, 1, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV34AppName, "")), 30, Gx_line+30, 283, Gx_line+45, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 20, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV41Title, "")), 30, Gx_line+45, 283, Gx_line+78, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV40Phone, "")), 283, Gx_line+30, 536, Gx_line+46, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV38Mail, "")), 283, Gx_line+46, 536, Gx_line+62, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV42Website, "")), 283, Gx_line+62, 536, Gx_line+78, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV31AddressLine1, "")), 536, Gx_line+30, 789, Gx_line+46, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV32AddressLine2, "")), 536, Gx_line+46, 789, Gx_line+62, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV33AddressLine3, "")), 536, Gx_line+62, 789, Gx_line+78, 2, 0, 0, 0) ;
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
         AV43Pgmname = "";
         GXEncryptionTmp = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV41Title = "";
         AV13FilterFullText = "";
         AV27TFTipoCuentaId_To_Description = "";
         AV22TFTipoCuentaNombre_Sel = "";
         AV21TFTipoCuentaNombre = "";
         AV26TFTipoCuentaConcepto_Sels = new GxSimpleCollection<string>();
         AV23TFTipoCuentaConcepto_SelsJson = "";
         AV25TFTipoCuentaConcepto_Sel = "";
         AV24TFTipoCuentaConcepto_SelDscs = "";
         AV28FilterTFTipoCuentaConcepto_SelValueDescription = "";
         AV48Tipocuentawwds_1_filterfulltext = "";
         AV51Tipocuentawwds_4_tftipocuentanombre = "";
         AV52Tipocuentawwds_5_tftipocuentanombre_sel = "";
         AV53Tipocuentawwds_6_tftipocuentaconcepto_sels = new GxSimpleCollection<string>();
         lV51Tipocuentawwds_4_tftipocuentanombre = "";
         A636TipoCuentaConcepto = "";
         A484TipoCuentaNombre = "";
         P00DE2_A484TipoCuentaNombre = new string[] {""} ;
         P00DE2_A483TipoCuentaId = new long[1] ;
         P00DE2_A636TipoCuentaConcepto = new string[] {""} ;
         AV14TipoCuentaConceptoDescription = "";
         AV15Session = context.GetSession();
         AV17GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV18GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV39PageInfo = "";
         AV36DateInfo = "";
         Gx_date = DateTime.MinValue;
         AV34AppName = "";
         AV40Phone = "";
         AV38Mail = "";
         AV42Website = "";
         AV31AddressLine1 = "";
         AV32AddressLine2 = "";
         AV33AddressLine3 = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.tipocuentawwexportreport__default(),
            new Object[][] {
                new Object[] {
               P00DE2_A484TipoCuentaNombre, P00DE2_A483TipoCuentaId, P00DE2_A636TipoCuentaConcepto
               }
            }
         );
         Gx_date = DateTimeUtil.Today( context);
         AV43Pgmname = "TipoCuentaWWExportReport";
         /* GeneXus formulas. */
         Gx_line = 0;
         Gx_date = DateTimeUtil.Today( context);
         AV43Pgmname = "TipoCuentaWWExportReport";
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
      private int AV46GXV1 ;
      private int AV53Tipocuentawwds_6_tftipocuentaconcepto_sels_Count ;
      private int AV54GXV2 ;
      private long AV19TFTipoCuentaId ;
      private long AV20TFTipoCuentaId_To ;
      private long AV30i ;
      private long AV49Tipocuentawwds_2_tftipocuentaid ;
      private long AV50Tipocuentawwds_3_tftipocuentaid_to ;
      private long A483TipoCuentaId ;
      private string GXKey ;
      private string gxfirstwebparm ;
      private string AV43Pgmname ;
      private string GXEncryptionTmp ;
      private string AV22TFTipoCuentaNombre_Sel ;
      private string AV21TFTipoCuentaNombre ;
      private string AV25TFTipoCuentaConcepto_Sel ;
      private string AV51Tipocuentawwds_4_tftipocuentanombre ;
      private string AV52Tipocuentawwds_5_tftipocuentanombre_sel ;
      private string lV51Tipocuentawwds_4_tftipocuentanombre ;
      private string A636TipoCuentaConcepto ;
      private string A484TipoCuentaNombre ;
      private DateTime Gx_date ;
      private bool entryPointCalled ;
      private bool AV8IsAuthorized ;
      private bool GXt_boolean1 ;
      private bool returnInSub ;
      private bool AV29TempBoolean ;
      private bool AV12OrderedDsc ;
      private string AV23TFTipoCuentaConcepto_SelsJson ;
      private string AV41Title ;
      private string AV13FilterFullText ;
      private string AV27TFTipoCuentaId_To_Description ;
      private string AV24TFTipoCuentaConcepto_SelDscs ;
      private string AV28FilterTFTipoCuentaConcepto_SelValueDescription ;
      private string AV48Tipocuentawwds_1_filterfulltext ;
      private string AV14TipoCuentaConceptoDescription ;
      private string AV39PageInfo ;
      private string AV36DateInfo ;
      private string AV34AppName ;
      private string AV40Phone ;
      private string AV38Mail ;
      private string AV42Website ;
      private string AV31AddressLine1 ;
      private string AV32AddressLine2 ;
      private string AV33AddressLine3 ;
      private IGxSession AV15Session ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GxSimpleCollection<string> AV26TFTipoCuentaConcepto_Sels ;
      private GxSimpleCollection<string> AV53Tipocuentawwds_6_tftipocuentaconcepto_sels ;
      private IDataStoreProvider pr_default ;
      private string[] P00DE2_A484TipoCuentaNombre ;
      private long[] P00DE2_A483TipoCuentaId ;
      private string[] P00DE2_A636TipoCuentaConcepto ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV17GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV18GridStateFilterValue ;
   }

   public class tipocuentawwexportreport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00DE2( IGxContext context ,
                                             string A636TipoCuentaConcepto ,
                                             GxSimpleCollection<string> AV53Tipocuentawwds_6_tftipocuentaconcepto_sels ,
                                             long AV49Tipocuentawwds_2_tftipocuentaid ,
                                             long AV50Tipocuentawwds_3_tftipocuentaid_to ,
                                             string AV52Tipocuentawwds_5_tftipocuentanombre_sel ,
                                             string AV51Tipocuentawwds_4_tftipocuentanombre ,
                                             int AV53Tipocuentawwds_6_tftipocuentaconcepto_sels_Count ,
                                             long A483TipoCuentaId ,
                                             string A484TipoCuentaNombre ,
                                             short AV11OrderedBy ,
                                             bool AV12OrderedDsc ,
                                             string AV48Tipocuentawwds_1_filterfulltext )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int2 = new short[4];
         Object[] GXv_Object3 = new Object[2];
         scmdbuf = "SELECT [TipoCuentaNombre], [TipoCuentaId], [TipoCuentaConcepto] FROM [TipoCuenta]";
         if ( ! (0==AV49Tipocuentawwds_2_tftipocuentaid) )
         {
            AddWhere(sWhereString, "([TipoCuentaId] >= @AV49Tipocuentawwds_2_tftipocuentaid)");
         }
         else
         {
            GXv_int2[0] = 1;
         }
         if ( ! (0==AV50Tipocuentawwds_3_tftipocuentaid_to) )
         {
            AddWhere(sWhereString, "([TipoCuentaId] <= @AV50Tipocuentawwds_3_tftipocuentaid_to)");
         }
         else
         {
            GXv_int2[1] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV52Tipocuentawwds_5_tftipocuentanombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV51Tipocuentawwds_4_tftipocuentanombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER([TipoCuentaNombre]) like UPPER(@lV51Tipocuentawwds_4_tftipocuentanombre))");
         }
         else
         {
            GXv_int2[2] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV52Tipocuentawwds_5_tftipocuentanombre_sel)) && ! ( StringUtil.StrCmp(AV52Tipocuentawwds_5_tftipocuentanombre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([TipoCuentaNombre] = @AV52Tipocuentawwds_5_tftipocuentanombre_sel)");
         }
         else
         {
            GXv_int2[3] = 1;
         }
         if ( StringUtil.StrCmp(AV52Tipocuentawwds_5_tftipocuentanombre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([TipoCuentaNombre] = ''))");
         }
         if ( AV53Tipocuentawwds_6_tftipocuentaconcepto_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV53Tipocuentawwds_6_tftipocuentaconcepto_sels, "[TipoCuentaConcepto] IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         if ( ( AV11OrderedBy == 1 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY [TipoCuentaNombre]";
         }
         else if ( ( AV11OrderedBy == 1 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [TipoCuentaNombre] DESC";
         }
         else if ( ( AV11OrderedBy == 2 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY [TipoCuentaId]";
         }
         else if ( ( AV11OrderedBy == 2 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [TipoCuentaId] DESC";
         }
         else if ( ( AV11OrderedBy == 3 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY [TipoCuentaConcepto]";
         }
         else if ( ( AV11OrderedBy == 3 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [TipoCuentaConcepto] DESC";
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
                     return conditional_P00DE2(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (long)dynConstraints[2] , (long)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (int)dynConstraints[6] , (long)dynConstraints[7] , (string)dynConstraints[8] , (short)dynConstraints[9] , (bool)dynConstraints[10] , (string)dynConstraints[11] );
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
          Object[] prmP00DE2;
          prmP00DE2 = new Object[] {
          new ParDef("@AV49Tipocuentawwds_2_tftipocuentaid",GXType.Decimal,18,0) ,
          new ParDef("@AV50Tipocuentawwds_3_tftipocuentaid_to",GXType.Decimal,18,0) ,
          new ParDef("@lV51Tipocuentawwds_4_tftipocuentanombre",GXType.Char,120,0) ,
          new ParDef("@AV52Tipocuentawwds_5_tftipocuentanombre_sel",GXType.NChar,120,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00DE2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00DE2,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[0])[0] = rslt.getString(1, 120);
                ((long[]) buf[1])[0] = rslt.getLong(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 3);
                return;
       }
    }

 }

}

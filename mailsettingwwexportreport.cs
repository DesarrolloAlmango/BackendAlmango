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
   public class mailsettingwwexportreport : GXWebProcedure, System.Web.SessionState.IRequiresSessionState
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

      public mailsettingwwexportreport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public mailsettingwwexportreport( IGxContext context )
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
         setOutputFileName("MailSettingWWExportReport");
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
            new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWMailSetting", out  GXt_boolean1) ;
            AV8IsAuthorized = GXt_boolean1;
            if ( ! AV8IsAuthorized )
            {
               GXKey = Crypto.GetSiteKey( );
               GXEncryptionTmp = "wwpbaseobjects.notauthorized.aspx"+UrlEncode(StringUtil.RTrim(AV59Pgmname));
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
               AV57Title = context.GetMessage( "Lista de Mail Setting", "");
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
            HBZ0( true, 0) ;
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
            HBZ0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "WWP_FullTextFilterDescription", ""), 25, Gx_line+0, 168, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV13FilterFullText, "")), 168, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         if ( AV31GridState.gxTpr_Dynamicfilters.Count >= 1 )
         {
            AV27GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV31GridState.gxTpr_Dynamicfilters.Item(1));
            AV14DynamicFiltersSelector1 = AV27GridStateDynamicFilter.gxTpr_Selected;
            if ( StringUtil.StrCmp(AV14DynamicFiltersSelector1, "MAILHOSTSMTP") == 0 )
            {
               AV15DynamicFiltersOperator1 = AV27GridStateDynamicFilter.gxTpr_Operator;
               AV16MailHostSMTP1 = AV27GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV16MailHostSMTP1)) )
               {
                  if ( AV15DynamicFiltersOperator1 == 0 )
                  {
                     AV17FilterMailHostSMTPDescription = StringUtil.Format( "%1 (%2)", context.GetMessage( "Host SMTP", ""), context.GetMessage( "WWP_FilterLike", ""), "", "", "", "", "", "", "");
                  }
                  else if ( AV15DynamicFiltersOperator1 == 1 )
                  {
                     AV17FilterMailHostSMTPDescription = StringUtil.Format( "%1 (%2)", context.GetMessage( "Host SMTP", ""), context.GetMessage( "WWP_FilterContains", ""), "", "", "", "", "", "", "");
                  }
                  AV18MailHostSMTP = AV16MailHostSMTP1;
                  HBZ0( false, 20) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV17FilterMailHostSMTPDescription, "")), 25, Gx_line+0, 168, Gx_line+15, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV18MailHostSMTP, "")), 168, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+20);
               }
            }
            if ( AV31GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV19DynamicFiltersEnabled2 = true;
               AV27GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV31GridState.gxTpr_Dynamicfilters.Item(2));
               AV20DynamicFiltersSelector2 = AV27GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV20DynamicFiltersSelector2, "MAILHOSTSMTP") == 0 )
               {
                  AV21DynamicFiltersOperator2 = AV27GridStateDynamicFilter.gxTpr_Operator;
                  AV22MailHostSMTP2 = AV27GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV22MailHostSMTP2)) )
                  {
                     if ( AV21DynamicFiltersOperator2 == 0 )
                     {
                        AV17FilterMailHostSMTPDescription = StringUtil.Format( "%1 (%2)", context.GetMessage( "Host SMTP", ""), context.GetMessage( "WWP_FilterLike", ""), "", "", "", "", "", "", "");
                     }
                     else if ( AV21DynamicFiltersOperator2 == 1 )
                     {
                        AV17FilterMailHostSMTPDescription = StringUtil.Format( "%1 (%2)", context.GetMessage( "Host SMTP", ""), context.GetMessage( "WWP_FilterContains", ""), "", "", "", "", "", "", "");
                     }
                     AV18MailHostSMTP = AV22MailHostSMTP2;
                     HBZ0( false, 20) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV17FilterMailHostSMTPDescription, "")), 25, Gx_line+0, 168, Gx_line+15, 0, 0, 0, 0) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV18MailHostSMTP, "")), 168, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                     Gx_OldLine = Gx_line;
                     Gx_line = (int)(Gx_line+20);
                  }
               }
               if ( AV31GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV23DynamicFiltersEnabled3 = true;
                  AV27GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV31GridState.gxTpr_Dynamicfilters.Item(3));
                  AV24DynamicFiltersSelector3 = AV27GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV24DynamicFiltersSelector3, "MAILHOSTSMTP") == 0 )
                  {
                     AV25DynamicFiltersOperator3 = AV27GridStateDynamicFilter.gxTpr_Operator;
                     AV26MailHostSMTP3 = AV27GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV26MailHostSMTP3)) )
                     {
                        if ( AV25DynamicFiltersOperator3 == 0 )
                        {
                           AV17FilterMailHostSMTPDescription = StringUtil.Format( "%1 (%2)", context.GetMessage( "Host SMTP", ""), context.GetMessage( "WWP_FilterLike", ""), "", "", "", "", "", "", "");
                        }
                        else if ( AV25DynamicFiltersOperator3 == 1 )
                        {
                           AV17FilterMailHostSMTPDescription = StringUtil.Format( "%1 (%2)", context.GetMessage( "Host SMTP", ""), context.GetMessage( "WWP_FilterContains", ""), "", "", "", "", "", "", "");
                        }
                        AV18MailHostSMTP = AV26MailHostSMTP3;
                        HBZ0( false, 20) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV17FilterMailHostSMTPDescription, "")), 25, Gx_line+0, 168, Gx_line+15, 0, 0, 0, 0) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV18MailHostSMTP, "")), 168, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                        Gx_OldLine = Gx_line;
                        Gx_line = (int)(Gx_line+20);
                     }
                  }
               }
            }
         }
         if ( ! ( (0==AV33TFMailId) && (0==AV34TFMailId_To) ) )
         {
            HBZ0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Identificador", ""), 25, Gx_line+0, 168, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV33TFMailId), "ZZZZZZZZZZZZZZZZZ9")), 168, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV43TFMailId_To_Description = StringUtil.Format( "%1 (%2)", context.GetMessage( "Identificador", ""), context.GetMessage( "WWP_TSTo", ""), "", "", "", "", "", "", "");
            HBZ0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV43TFMailId_To_Description, "")), 25, Gx_line+0, 168, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV34TFMailId_To), "ZZZZZZZZZZZZZZZZZ9")), 168, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV36TFMailCuentaNombre_Sel)) )
         {
            AV45TempBoolean = (bool)(((StringUtil.StrCmp(AV36TFMailCuentaNombre_Sel, "<#Empty#>")==0)));
            AV36TFMailCuentaNombre_Sel = (AV45TempBoolean ? context.GetMessage( "WWP_TitleFilter_EmptyOption", "") : AV36TFMailCuentaNombre_Sel);
            HBZ0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Nombre de la Cuenta", ""), 25, Gx_line+0, 168, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV36TFMailCuentaNombre_Sel, "")), 168, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV36TFMailCuentaNombre_Sel = (AV45TempBoolean ? "<#Empty#>" : AV36TFMailCuentaNombre_Sel);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV35TFMailCuentaNombre)) )
            {
               HBZ0( false, 20) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(context.GetMessage( "Nombre de la Cuenta", ""), 25, Gx_line+0, 168, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV35TFMailCuentaNombre, "")), 168, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV38TFMailDireccion_Sel)) )
         {
            AV45TempBoolean = (bool)(((StringUtil.StrCmp(AV38TFMailDireccion_Sel, "<#Empty#>")==0)));
            AV38TFMailDireccion_Sel = (AV45TempBoolean ? context.GetMessage( "WWP_TitleFilter_EmptyOption", "") : AV38TFMailDireccion_Sel);
            HBZ0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Direccion", ""), 25, Gx_line+0, 168, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV38TFMailDireccion_Sel, "")), 168, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV38TFMailDireccion_Sel = (AV45TempBoolean ? "<#Empty#>" : AV38TFMailDireccion_Sel);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV37TFMailDireccion)) )
            {
               HBZ0( false, 20) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(context.GetMessage( "Direccion", ""), 25, Gx_line+0, 168, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV37TFMailDireccion, "")), 168, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
         AV41TFMailEstado_Sels.FromJSonString(AV39TFMailEstado_SelsJson, null);
         if ( ! ( AV41TFMailEstado_Sels.Count == 0 ) )
         {
            AV46i = 1;
            AV62GXV1 = 1;
            while ( AV62GXV1 <= AV41TFMailEstado_Sels.Count )
            {
               AV42TFMailEstado_Sel = AV41TFMailEstado_Sels.GetString(AV62GXV1);
               if ( AV46i == 1 )
               {
                  AV40TFMailEstado_SelDscs = "";
               }
               else
               {
                  AV40TFMailEstado_SelDscs += ", ";
               }
               AV44FilterTFMailEstado_SelValueDescription = "";
               if ( StringUtil.StrCmp(StringUtil.Trim( AV42TFMailEstado_Sel), "HAB") == 0 )
               {
                  AV44FilterTFMailEstado_SelValueDescription = context.GetMessage( "Habilitado", "");
               }
               else if ( StringUtil.StrCmp(StringUtil.Trim( AV42TFMailEstado_Sel), "DES") == 0 )
               {
                  AV44FilterTFMailEstado_SelValueDescription = context.GetMessage( "Deshabilitado", "");
               }
               AV40TFMailEstado_SelDscs += AV44FilterTFMailEstado_SelValueDescription;
               AV46i = (long)(AV46i+1);
               AV62GXV1 = (int)(AV62GXV1+1);
            }
            HBZ0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Estado", ""), 25, Gx_line+0, 168, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV40TFMailEstado_SelDscs, "")), 168, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
      }

      protected void S121( )
      {
         /* 'PRINTCOLUMNTITLES' Routine */
         returnInSub = false;
         HBZ0( false, 22) ;
         getPrinter().GxDrawLine(25, Gx_line+21, 789, Gx_line+21, 2, 8, 160, 134, 0) ;
         Gx_OldLine = Gx_line;
         Gx_line = (int)(Gx_line+22);
         HBZ0( false, 37) ;
         getPrinter().GxAttris("Microsoft Sans Serif", 9, false, false, false, false, 0, 8, 160, 134, 0, 255, 255, 255) ;
         getPrinter().GxDrawText(context.GetMessage( "Identificador", ""), 30, Gx_line+10, 136, Gx_line+27, 2, 0, 0, 0) ;
         getPrinter().GxDrawText(context.GetMessage( "Nombre de la Cuenta", ""), 140, Gx_line+10, 352, Gx_line+27, 0, 0, 0, 0) ;
         getPrinter().GxDrawText(context.GetMessage( "Direccion", ""), 356, Gx_line+10, 569, Gx_line+27, 0, 0, 0, 0) ;
         getPrinter().GxDrawText(context.GetMessage( "Estado", ""), 573, Gx_line+10, 787, Gx_line+27, 0, 0, 0, 0) ;
         Gx_OldLine = Gx_line;
         Gx_line = (int)(Gx_line+37);
      }

      protected void S131( )
      {
         /* 'PRINTDATA' Routine */
         returnInSub = false;
         AV64Mailsettingwwds_1_filterfulltext = AV13FilterFullText;
         AV65Mailsettingwwds_2_dynamicfiltersselector1 = AV14DynamicFiltersSelector1;
         AV66Mailsettingwwds_3_dynamicfiltersoperator1 = AV15DynamicFiltersOperator1;
         AV67Mailsettingwwds_4_mailhostsmtp1 = AV16MailHostSMTP1;
         AV68Mailsettingwwds_5_dynamicfiltersenabled2 = AV19DynamicFiltersEnabled2;
         AV69Mailsettingwwds_6_dynamicfiltersselector2 = AV20DynamicFiltersSelector2;
         AV70Mailsettingwwds_7_dynamicfiltersoperator2 = AV21DynamicFiltersOperator2;
         AV71Mailsettingwwds_8_mailhostsmtp2 = AV22MailHostSMTP2;
         AV72Mailsettingwwds_9_dynamicfiltersenabled3 = AV23DynamicFiltersEnabled3;
         AV73Mailsettingwwds_10_dynamicfiltersselector3 = AV24DynamicFiltersSelector3;
         AV74Mailsettingwwds_11_dynamicfiltersoperator3 = AV25DynamicFiltersOperator3;
         AV75Mailsettingwwds_12_mailhostsmtp3 = AV26MailHostSMTP3;
         AV76Mailsettingwwds_13_tfmailid = AV33TFMailId;
         AV77Mailsettingwwds_14_tfmailid_to = AV34TFMailId_To;
         AV78Mailsettingwwds_15_tfmailcuentanombre = AV35TFMailCuentaNombre;
         AV79Mailsettingwwds_16_tfmailcuentanombre_sel = AV36TFMailCuentaNombre_Sel;
         AV80Mailsettingwwds_17_tfmaildireccion = AV37TFMailDireccion;
         AV81Mailsettingwwds_18_tfmaildireccion_sel = AV38TFMailDireccion_Sel;
         AV82Mailsettingwwds_19_tfmailestado_sels = AV41TFMailEstado_Sels;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A243MailEstado ,
                                              AV82Mailsettingwwds_19_tfmailestado_sels ,
                                              AV65Mailsettingwwds_2_dynamicfiltersselector1 ,
                                              AV66Mailsettingwwds_3_dynamicfiltersoperator1 ,
                                              AV67Mailsettingwwds_4_mailhostsmtp1 ,
                                              AV68Mailsettingwwds_5_dynamicfiltersenabled2 ,
                                              AV69Mailsettingwwds_6_dynamicfiltersselector2 ,
                                              AV70Mailsettingwwds_7_dynamicfiltersoperator2 ,
                                              AV71Mailsettingwwds_8_mailhostsmtp2 ,
                                              AV72Mailsettingwwds_9_dynamicfiltersenabled3 ,
                                              AV73Mailsettingwwds_10_dynamicfiltersselector3 ,
                                              AV74Mailsettingwwds_11_dynamicfiltersoperator3 ,
                                              AV75Mailsettingwwds_12_mailhostsmtp3 ,
                                              AV76Mailsettingwwds_13_tfmailid ,
                                              AV77Mailsettingwwds_14_tfmailid_to ,
                                              AV79Mailsettingwwds_16_tfmailcuentanombre_sel ,
                                              AV78Mailsettingwwds_15_tfmailcuentanombre ,
                                              AV81Mailsettingwwds_18_tfmaildireccion_sel ,
                                              AV80Mailsettingwwds_17_tfmaildireccion ,
                                              AV82Mailsettingwwds_19_tfmailestado_sels.Count ,
                                              A249MailHostSMTP ,
                                              A149MailId ,
                                              A241MailCuentaNombre ,
                                              A242MailDireccion ,
                                              AV11OrderedBy ,
                                              AV12OrderedDsc ,
                                              AV64Mailsettingwwds_1_filterfulltext } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.INT, TypeConstants.LONG, TypeConstants.SHORT,
                                              TypeConstants.BOOLEAN
                                              }
         });
         lV67Mailsettingwwds_4_mailhostsmtp1 = StringUtil.PadR( StringUtil.RTrim( AV67Mailsettingwwds_4_mailhostsmtp1), 250, "%");
         lV67Mailsettingwwds_4_mailhostsmtp1 = StringUtil.PadR( StringUtil.RTrim( AV67Mailsettingwwds_4_mailhostsmtp1), 250, "%");
         lV71Mailsettingwwds_8_mailhostsmtp2 = StringUtil.PadR( StringUtil.RTrim( AV71Mailsettingwwds_8_mailhostsmtp2), 250, "%");
         lV71Mailsettingwwds_8_mailhostsmtp2 = StringUtil.PadR( StringUtil.RTrim( AV71Mailsettingwwds_8_mailhostsmtp2), 250, "%");
         lV75Mailsettingwwds_12_mailhostsmtp3 = StringUtil.PadR( StringUtil.RTrim( AV75Mailsettingwwds_12_mailhostsmtp3), 250, "%");
         lV75Mailsettingwwds_12_mailhostsmtp3 = StringUtil.PadR( StringUtil.RTrim( AV75Mailsettingwwds_12_mailhostsmtp3), 250, "%");
         lV78Mailsettingwwds_15_tfmailcuentanombre = StringUtil.PadR( StringUtil.RTrim( AV78Mailsettingwwds_15_tfmailcuentanombre), 80, "%");
         lV80Mailsettingwwds_17_tfmaildireccion = StringUtil.Concat( StringUtil.RTrim( AV80Mailsettingwwds_17_tfmaildireccion), "%", "");
         /* Using cursor P00BZ2 */
         pr_default.execute(0, new Object[] {lV67Mailsettingwwds_4_mailhostsmtp1, lV67Mailsettingwwds_4_mailhostsmtp1, lV71Mailsettingwwds_8_mailhostsmtp2, lV71Mailsettingwwds_8_mailhostsmtp2, lV75Mailsettingwwds_12_mailhostsmtp3, lV75Mailsettingwwds_12_mailhostsmtp3, AV76Mailsettingwwds_13_tfmailid, AV77Mailsettingwwds_14_tfmailid_to, lV78Mailsettingwwds_15_tfmailcuentanombre, AV79Mailsettingwwds_16_tfmailcuentanombre_sel, lV80Mailsettingwwds_17_tfmaildireccion, AV81Mailsettingwwds_18_tfmaildireccion_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A249MailHostSMTP = P00BZ2_A249MailHostSMTP[0];
            A242MailDireccion = P00BZ2_A242MailDireccion[0];
            A241MailCuentaNombre = P00BZ2_A241MailCuentaNombre[0];
            A149MailId = P00BZ2_A149MailId[0];
            A243MailEstado = P00BZ2_A243MailEstado[0];
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV64Mailsettingwwds_1_filterfulltext)) || ( ( StringUtil.Like( StringUtil.Str( (decimal)(A149MailId), 18, 0) , StringUtil.PadR( "%" + AV64Mailsettingwwds_1_filterfulltext , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A241MailCuentaNombre) , StringUtil.PadR( "%" + StringUtil.Upper( AV64Mailsettingwwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A242MailDireccion) , StringUtil.PadR( "%" + StringUtil.Upper( AV64Mailsettingwwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( context.GetMessage( "habilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV64Mailsettingwwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A243MailEstado, "HAB") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "deshabilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV64Mailsettingwwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A243MailEstado, "DES") == 0 ) ) ) )
            {
               AV28MailEstadoDescription = "";
               if ( StringUtil.StrCmp(StringUtil.Trim( A243MailEstado), "HAB") == 0 )
               {
                  AV28MailEstadoDescription = context.GetMessage( "Habilitado", "");
               }
               else if ( StringUtil.StrCmp(StringUtil.Trim( A243MailEstado), "DES") == 0 )
               {
                  AV28MailEstadoDescription = context.GetMessage( "Deshabilitado", "");
               }
               /* Execute user subroutine: 'BEFOREPRINTLINE' */
               S144 ();
               if ( returnInSub )
               {
                  pr_default.close(0);
                  returnInSub = true;
                  if (true) return;
               }
               HBZ0( false, 36) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(A149MailId), "ZZZZZZZZZZZZZZZZZ9")), 30, Gx_line+10, 136, Gx_line+25, 2+16, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A241MailCuentaNombre, "")), 140, Gx_line+10, 352, Gx_line+25, 0+16, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A242MailDireccion, "")), 356, Gx_line+10, 569, Gx_line+25, 0+16, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV28MailEstadoDescription, "")), 573, Gx_line+10, 787, Gx_line+25, 0+16, 0, 0, 0) ;
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
         if ( StringUtil.StrCmp(AV29Session.Get("MailSettingWWGridState"), "") == 0 )
         {
            AV31GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "MailSettingWWGridState"), null, "", "");
         }
         else
         {
            AV31GridState.FromXml(AV29Session.Get("MailSettingWWGridState"), null, "", "");
         }
         AV11OrderedBy = AV31GridState.gxTpr_Orderedby;
         AV12OrderedDsc = AV31GridState.gxTpr_Ordereddsc;
         AV83GXV2 = 1;
         while ( AV83GXV2 <= AV31GridState.gxTpr_Filtervalues.Count )
         {
            AV32GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV31GridState.gxTpr_Filtervalues.Item(AV83GXV2));
            if ( StringUtil.StrCmp(AV32GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV13FilterFullText = AV32GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV32GridStateFilterValue.gxTpr_Name, "TFMAILID") == 0 )
            {
               AV33TFMailId = (long)(Math.Round(NumberUtil.Val( AV32GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV34TFMailId_To = (long)(Math.Round(NumberUtil.Val( AV32GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV32GridStateFilterValue.gxTpr_Name, "TFMAILCUENTANOMBRE") == 0 )
            {
               AV35TFMailCuentaNombre = AV32GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV32GridStateFilterValue.gxTpr_Name, "TFMAILCUENTANOMBRE_SEL") == 0 )
            {
               AV36TFMailCuentaNombre_Sel = AV32GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV32GridStateFilterValue.gxTpr_Name, "TFMAILDIRECCION") == 0 )
            {
               AV37TFMailDireccion = AV32GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV32GridStateFilterValue.gxTpr_Name, "TFMAILDIRECCION_SEL") == 0 )
            {
               AV38TFMailDireccion_Sel = AV32GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV32GridStateFilterValue.gxTpr_Name, "TFMAILESTADO_SEL") == 0 )
            {
               AV39TFMailEstado_SelsJson = AV32GridStateFilterValue.gxTpr_Value;
               AV41TFMailEstado_Sels.FromJSonString(AV39TFMailEstado_SelsJson, null);
            }
            AV83GXV2 = (int)(AV83GXV2+1);
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

      protected void HBZ0( bool bFoot ,
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
                  AV55PageInfo = context.GetMessage( "Page: ", "") + StringUtil.Trim( StringUtil.Str( (decimal)(Gx_page), 6, 0));
                  AV52DateInfo = context.GetMessage( "Date: ", "") + context.localUtil.Format( Gx_date, "99/99/99");
                  getPrinter().GxDrawRect(0, Gx_line+5, 819, Gx_line+40, 1, 0, 0, 0, 1, 8, 160, 134, 1, 1, 1, 1, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV55PageInfo, "")), 30, Gx_line+15, 409, Gx_line+30, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV52DateInfo, "")), 409, Gx_line+15, 789, Gx_line+30, 2, 0, 0, 0) ;
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
               AV50AppName = context.GetMessage( "DVelop Software Solutions", "");
               AV56Phone = "+1 550 8923";
               AV54Mail = "info@mail.com";
               AV58Website = "http://www.web.com";
               AV47AddressLine1 = "French Boulevard 2859";
               AV48AddressLine2 = "Downtown";
               AV49AddressLine3 = "Paris, France";
               getPrinter().GxDrawRect(0, Gx_line+0, 819, Gx_line+108, 1, 0, 0, 0, 1, 8, 160, 134, 1, 1, 1, 1, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV50AppName, "")), 30, Gx_line+30, 283, Gx_line+45, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 20, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV57Title, "")), 30, Gx_line+45, 283, Gx_line+78, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV56Phone, "")), 283, Gx_line+30, 536, Gx_line+46, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV54Mail, "")), 283, Gx_line+46, 536, Gx_line+62, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV58Website, "")), 283, Gx_line+62, 536, Gx_line+78, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV47AddressLine1, "")), 536, Gx_line+30, 789, Gx_line+46, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV48AddressLine2, "")), 536, Gx_line+46, 789, Gx_line+62, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV49AddressLine3, "")), 536, Gx_line+62, 789, Gx_line+78, 2, 0, 0, 0) ;
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
         AV59Pgmname = "";
         GXEncryptionTmp = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV57Title = "";
         AV13FilterFullText = "";
         AV31GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV27GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV14DynamicFiltersSelector1 = "";
         AV16MailHostSMTP1 = "";
         AV17FilterMailHostSMTPDescription = "";
         AV18MailHostSMTP = "";
         AV20DynamicFiltersSelector2 = "";
         AV22MailHostSMTP2 = "";
         AV24DynamicFiltersSelector3 = "";
         AV26MailHostSMTP3 = "";
         AV43TFMailId_To_Description = "";
         AV36TFMailCuentaNombre_Sel = "";
         AV35TFMailCuentaNombre = "";
         AV38TFMailDireccion_Sel = "";
         AV37TFMailDireccion = "";
         AV41TFMailEstado_Sels = new GxSimpleCollection<string>();
         AV39TFMailEstado_SelsJson = "";
         AV42TFMailEstado_Sel = "";
         AV40TFMailEstado_SelDscs = "";
         AV44FilterTFMailEstado_SelValueDescription = "";
         AV64Mailsettingwwds_1_filterfulltext = "";
         AV65Mailsettingwwds_2_dynamicfiltersselector1 = "";
         AV67Mailsettingwwds_4_mailhostsmtp1 = "";
         AV69Mailsettingwwds_6_dynamicfiltersselector2 = "";
         AV71Mailsettingwwds_8_mailhostsmtp2 = "";
         AV73Mailsettingwwds_10_dynamicfiltersselector3 = "";
         AV75Mailsettingwwds_12_mailhostsmtp3 = "";
         AV78Mailsettingwwds_15_tfmailcuentanombre = "";
         AV79Mailsettingwwds_16_tfmailcuentanombre_sel = "";
         AV80Mailsettingwwds_17_tfmaildireccion = "";
         AV81Mailsettingwwds_18_tfmaildireccion_sel = "";
         AV82Mailsettingwwds_19_tfmailestado_sels = new GxSimpleCollection<string>();
         lV67Mailsettingwwds_4_mailhostsmtp1 = "";
         lV71Mailsettingwwds_8_mailhostsmtp2 = "";
         lV75Mailsettingwwds_12_mailhostsmtp3 = "";
         lV78Mailsettingwwds_15_tfmailcuentanombre = "";
         lV80Mailsettingwwds_17_tfmaildireccion = "";
         A243MailEstado = "";
         A249MailHostSMTP = "";
         A241MailCuentaNombre = "";
         A242MailDireccion = "";
         P00BZ2_A249MailHostSMTP = new string[] {""} ;
         P00BZ2_A242MailDireccion = new string[] {""} ;
         P00BZ2_A241MailCuentaNombre = new string[] {""} ;
         P00BZ2_A149MailId = new long[1] ;
         P00BZ2_A243MailEstado = new string[] {""} ;
         AV28MailEstadoDescription = "";
         AV29Session = context.GetSession();
         AV32GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV55PageInfo = "";
         AV52DateInfo = "";
         Gx_date = DateTime.MinValue;
         AV50AppName = "";
         AV56Phone = "";
         AV54Mail = "";
         AV58Website = "";
         AV47AddressLine1 = "";
         AV48AddressLine2 = "";
         AV49AddressLine3 = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.mailsettingwwexportreport__default(),
            new Object[][] {
                new Object[] {
               P00BZ2_A249MailHostSMTP, P00BZ2_A242MailDireccion, P00BZ2_A241MailCuentaNombre, P00BZ2_A149MailId, P00BZ2_A243MailEstado
               }
            }
         );
         Gx_date = DateTimeUtil.Today( context);
         AV59Pgmname = "MailSettingWWExportReport";
         /* GeneXus formulas. */
         Gx_line = 0;
         Gx_date = DateTimeUtil.Today( context);
         AV59Pgmname = "MailSettingWWExportReport";
      }

      private short nGotPars ;
      private short GxWebError ;
      private short AV15DynamicFiltersOperator1 ;
      private short AV21DynamicFiltersOperator2 ;
      private short AV25DynamicFiltersOperator3 ;
      private short AV66Mailsettingwwds_3_dynamicfiltersoperator1 ;
      private short AV70Mailsettingwwds_7_dynamicfiltersoperator2 ;
      private short AV74Mailsettingwwds_11_dynamicfiltersoperator3 ;
      private short AV11OrderedBy ;
      private int M_top ;
      private int M_bot ;
      private int Line ;
      private int ToSkip ;
      private int PrtOffset ;
      private int Gx_OldLine ;
      private int AV62GXV1 ;
      private int AV82Mailsettingwwds_19_tfmailestado_sels_Count ;
      private int AV83GXV2 ;
      private long AV33TFMailId ;
      private long AV34TFMailId_To ;
      private long AV46i ;
      private long AV76Mailsettingwwds_13_tfmailid ;
      private long AV77Mailsettingwwds_14_tfmailid_to ;
      private long A149MailId ;
      private string GXKey ;
      private string gxfirstwebparm ;
      private string AV59Pgmname ;
      private string GXEncryptionTmp ;
      private string AV16MailHostSMTP1 ;
      private string AV18MailHostSMTP ;
      private string AV22MailHostSMTP2 ;
      private string AV26MailHostSMTP3 ;
      private string AV36TFMailCuentaNombre_Sel ;
      private string AV35TFMailCuentaNombre ;
      private string AV42TFMailEstado_Sel ;
      private string AV67Mailsettingwwds_4_mailhostsmtp1 ;
      private string AV71Mailsettingwwds_8_mailhostsmtp2 ;
      private string AV75Mailsettingwwds_12_mailhostsmtp3 ;
      private string AV78Mailsettingwwds_15_tfmailcuentanombre ;
      private string AV79Mailsettingwwds_16_tfmailcuentanombre_sel ;
      private string lV67Mailsettingwwds_4_mailhostsmtp1 ;
      private string lV71Mailsettingwwds_8_mailhostsmtp2 ;
      private string lV75Mailsettingwwds_12_mailhostsmtp3 ;
      private string lV78Mailsettingwwds_15_tfmailcuentanombre ;
      private string A243MailEstado ;
      private string A249MailHostSMTP ;
      private string A241MailCuentaNombre ;
      private DateTime Gx_date ;
      private bool entryPointCalled ;
      private bool AV8IsAuthorized ;
      private bool GXt_boolean1 ;
      private bool returnInSub ;
      private bool AV19DynamicFiltersEnabled2 ;
      private bool AV23DynamicFiltersEnabled3 ;
      private bool AV45TempBoolean ;
      private bool AV68Mailsettingwwds_5_dynamicfiltersenabled2 ;
      private bool AV72Mailsettingwwds_9_dynamicfiltersenabled3 ;
      private bool AV12OrderedDsc ;
      private string AV39TFMailEstado_SelsJson ;
      private string AV57Title ;
      private string AV13FilterFullText ;
      private string AV14DynamicFiltersSelector1 ;
      private string AV17FilterMailHostSMTPDescription ;
      private string AV20DynamicFiltersSelector2 ;
      private string AV24DynamicFiltersSelector3 ;
      private string AV43TFMailId_To_Description ;
      private string AV38TFMailDireccion_Sel ;
      private string AV37TFMailDireccion ;
      private string AV40TFMailEstado_SelDscs ;
      private string AV44FilterTFMailEstado_SelValueDescription ;
      private string AV64Mailsettingwwds_1_filterfulltext ;
      private string AV65Mailsettingwwds_2_dynamicfiltersselector1 ;
      private string AV69Mailsettingwwds_6_dynamicfiltersselector2 ;
      private string AV73Mailsettingwwds_10_dynamicfiltersselector3 ;
      private string AV80Mailsettingwwds_17_tfmaildireccion ;
      private string AV81Mailsettingwwds_18_tfmaildireccion_sel ;
      private string lV80Mailsettingwwds_17_tfmaildireccion ;
      private string A242MailDireccion ;
      private string AV28MailEstadoDescription ;
      private string AV55PageInfo ;
      private string AV52DateInfo ;
      private string AV50AppName ;
      private string AV56Phone ;
      private string AV54Mail ;
      private string AV58Website ;
      private string AV47AddressLine1 ;
      private string AV48AddressLine2 ;
      private string AV49AddressLine3 ;
      private IGxSession AV29Session ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV31GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV27GridStateDynamicFilter ;
      private GxSimpleCollection<string> AV41TFMailEstado_Sels ;
      private GxSimpleCollection<string> AV82Mailsettingwwds_19_tfmailestado_sels ;
      private IDataStoreProvider pr_default ;
      private string[] P00BZ2_A249MailHostSMTP ;
      private string[] P00BZ2_A242MailDireccion ;
      private string[] P00BZ2_A241MailCuentaNombre ;
      private long[] P00BZ2_A149MailId ;
      private string[] P00BZ2_A243MailEstado ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV32GridStateFilterValue ;
   }

   public class mailsettingwwexportreport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00BZ2( IGxContext context ,
                                             string A243MailEstado ,
                                             GxSimpleCollection<string> AV82Mailsettingwwds_19_tfmailestado_sels ,
                                             string AV65Mailsettingwwds_2_dynamicfiltersselector1 ,
                                             short AV66Mailsettingwwds_3_dynamicfiltersoperator1 ,
                                             string AV67Mailsettingwwds_4_mailhostsmtp1 ,
                                             bool AV68Mailsettingwwds_5_dynamicfiltersenabled2 ,
                                             string AV69Mailsettingwwds_6_dynamicfiltersselector2 ,
                                             short AV70Mailsettingwwds_7_dynamicfiltersoperator2 ,
                                             string AV71Mailsettingwwds_8_mailhostsmtp2 ,
                                             bool AV72Mailsettingwwds_9_dynamicfiltersenabled3 ,
                                             string AV73Mailsettingwwds_10_dynamicfiltersselector3 ,
                                             short AV74Mailsettingwwds_11_dynamicfiltersoperator3 ,
                                             string AV75Mailsettingwwds_12_mailhostsmtp3 ,
                                             long AV76Mailsettingwwds_13_tfmailid ,
                                             long AV77Mailsettingwwds_14_tfmailid_to ,
                                             string AV79Mailsettingwwds_16_tfmailcuentanombre_sel ,
                                             string AV78Mailsettingwwds_15_tfmailcuentanombre ,
                                             string AV81Mailsettingwwds_18_tfmaildireccion_sel ,
                                             string AV80Mailsettingwwds_17_tfmaildireccion ,
                                             int AV82Mailsettingwwds_19_tfmailestado_sels_Count ,
                                             string A249MailHostSMTP ,
                                             long A149MailId ,
                                             string A241MailCuentaNombre ,
                                             string A242MailDireccion ,
                                             short AV11OrderedBy ,
                                             bool AV12OrderedDsc ,
                                             string AV64Mailsettingwwds_1_filterfulltext )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int2 = new short[12];
         Object[] GXv_Object3 = new Object[2];
         scmdbuf = "SELECT [MailHostSMTP], [MailDireccion], [MailCuentaNombre], [MailId], [MailEstado] FROM [Mail]";
         if ( ( StringUtil.StrCmp(AV65Mailsettingwwds_2_dynamicfiltersselector1, "MAILHOSTSMTP") == 0 ) && ( AV66Mailsettingwwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Mailsettingwwds_4_mailhostsmtp1)) ) )
         {
            AddWhere(sWhereString, "(UPPER([MailHostSMTP]) like UPPER(@lV67Mailsettingwwds_4_mailhostsmtp1))");
         }
         else
         {
            GXv_int2[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV65Mailsettingwwds_2_dynamicfiltersselector1, "MAILHOSTSMTP") == 0 ) && ( AV66Mailsettingwwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Mailsettingwwds_4_mailhostsmtp1)) ) )
         {
            AddWhere(sWhereString, "(UPPER([MailHostSMTP]) like '%' + UPPER(@lV67Mailsettingwwds_4_mailhostsmtp1))");
         }
         else
         {
            GXv_int2[1] = 1;
         }
         if ( AV68Mailsettingwwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV69Mailsettingwwds_6_dynamicfiltersselector2, "MAILHOSTSMTP") == 0 ) && ( AV70Mailsettingwwds_7_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Mailsettingwwds_8_mailhostsmtp2)) ) )
         {
            AddWhere(sWhereString, "(UPPER([MailHostSMTP]) like UPPER(@lV71Mailsettingwwds_8_mailhostsmtp2))");
         }
         else
         {
            GXv_int2[2] = 1;
         }
         if ( AV68Mailsettingwwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV69Mailsettingwwds_6_dynamicfiltersselector2, "MAILHOSTSMTP") == 0 ) && ( AV70Mailsettingwwds_7_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Mailsettingwwds_8_mailhostsmtp2)) ) )
         {
            AddWhere(sWhereString, "(UPPER([MailHostSMTP]) like '%' + UPPER(@lV71Mailsettingwwds_8_mailhostsmtp2))");
         }
         else
         {
            GXv_int2[3] = 1;
         }
         if ( AV72Mailsettingwwds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV73Mailsettingwwds_10_dynamicfiltersselector3, "MAILHOSTSMTP") == 0 ) && ( AV74Mailsettingwwds_11_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75Mailsettingwwds_12_mailhostsmtp3)) ) )
         {
            AddWhere(sWhereString, "(UPPER([MailHostSMTP]) like UPPER(@lV75Mailsettingwwds_12_mailhostsmtp3))");
         }
         else
         {
            GXv_int2[4] = 1;
         }
         if ( AV72Mailsettingwwds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV73Mailsettingwwds_10_dynamicfiltersselector3, "MAILHOSTSMTP") == 0 ) && ( AV74Mailsettingwwds_11_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75Mailsettingwwds_12_mailhostsmtp3)) ) )
         {
            AddWhere(sWhereString, "(UPPER([MailHostSMTP]) like '%' + UPPER(@lV75Mailsettingwwds_12_mailhostsmtp3))");
         }
         else
         {
            GXv_int2[5] = 1;
         }
         if ( ! (0==AV76Mailsettingwwds_13_tfmailid) )
         {
            AddWhere(sWhereString, "([MailId] >= @AV76Mailsettingwwds_13_tfmailid)");
         }
         else
         {
            GXv_int2[6] = 1;
         }
         if ( ! (0==AV77Mailsettingwwds_14_tfmailid_to) )
         {
            AddWhere(sWhereString, "([MailId] <= @AV77Mailsettingwwds_14_tfmailid_to)");
         }
         else
         {
            GXv_int2[7] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV79Mailsettingwwds_16_tfmailcuentanombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV78Mailsettingwwds_15_tfmailcuentanombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER([MailCuentaNombre]) like UPPER(@lV78Mailsettingwwds_15_tfmailcuentanombre))");
         }
         else
         {
            GXv_int2[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV79Mailsettingwwds_16_tfmailcuentanombre_sel)) && ! ( StringUtil.StrCmp(AV79Mailsettingwwds_16_tfmailcuentanombre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([MailCuentaNombre] = @AV79Mailsettingwwds_16_tfmailcuentanombre_sel)");
         }
         else
         {
            GXv_int2[9] = 1;
         }
         if ( StringUtil.StrCmp(AV79Mailsettingwwds_16_tfmailcuentanombre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([MailCuentaNombre] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV81Mailsettingwwds_18_tfmaildireccion_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV80Mailsettingwwds_17_tfmaildireccion)) ) )
         {
            AddWhere(sWhereString, "(UPPER([MailDireccion]) like UPPER(@lV80Mailsettingwwds_17_tfmaildireccion))");
         }
         else
         {
            GXv_int2[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV81Mailsettingwwds_18_tfmaildireccion_sel)) && ! ( StringUtil.StrCmp(AV81Mailsettingwwds_18_tfmaildireccion_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([MailDireccion] = @AV81Mailsettingwwds_18_tfmaildireccion_sel)");
         }
         else
         {
            GXv_int2[11] = 1;
         }
         if ( StringUtil.StrCmp(AV81Mailsettingwwds_18_tfmaildireccion_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([MailDireccion] = ''))");
         }
         if ( AV82Mailsettingwwds_19_tfmailestado_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV82Mailsettingwwds_19_tfmailestado_sels, "[MailEstado] IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         if ( AV11OrderedBy == 1 )
         {
            scmdbuf += " ORDER BY [MailHostSMTP]";
         }
         else if ( ( AV11OrderedBy == 2 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY [MailId]";
         }
         else if ( ( AV11OrderedBy == 2 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [MailId] DESC";
         }
         else if ( ( AV11OrderedBy == 3 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY [MailCuentaNombre]";
         }
         else if ( ( AV11OrderedBy == 3 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [MailCuentaNombre] DESC";
         }
         else if ( ( AV11OrderedBy == 4 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY [MailDireccion]";
         }
         else if ( ( AV11OrderedBy == 4 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [MailDireccion] DESC";
         }
         else if ( ( AV11OrderedBy == 5 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY [MailEstado]";
         }
         else if ( ( AV11OrderedBy == 5 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [MailEstado] DESC";
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
                     return conditional_P00BZ2(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (bool)dynConstraints[5] , (string)dynConstraints[6] , (short)dynConstraints[7] , (string)dynConstraints[8] , (bool)dynConstraints[9] , (string)dynConstraints[10] , (short)dynConstraints[11] , (string)dynConstraints[12] , (long)dynConstraints[13] , (long)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (int)dynConstraints[19] , (string)dynConstraints[20] , (long)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (short)dynConstraints[24] , (bool)dynConstraints[25] , (string)dynConstraints[26] );
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
          Object[] prmP00BZ2;
          prmP00BZ2 = new Object[] {
          new ParDef("@lV67Mailsettingwwds_4_mailhostsmtp1",GXType.Char,250,0) ,
          new ParDef("@lV67Mailsettingwwds_4_mailhostsmtp1",GXType.Char,250,0) ,
          new ParDef("@lV71Mailsettingwwds_8_mailhostsmtp2",GXType.Char,250,0) ,
          new ParDef("@lV71Mailsettingwwds_8_mailhostsmtp2",GXType.Char,250,0) ,
          new ParDef("@lV75Mailsettingwwds_12_mailhostsmtp3",GXType.Char,250,0) ,
          new ParDef("@lV75Mailsettingwwds_12_mailhostsmtp3",GXType.Char,250,0) ,
          new ParDef("@AV76Mailsettingwwds_13_tfmailid",GXType.Decimal,18,0) ,
          new ParDef("@AV77Mailsettingwwds_14_tfmailid_to",GXType.Decimal,18,0) ,
          new ParDef("@lV78Mailsettingwwds_15_tfmailcuentanombre",GXType.Char,80,0) ,
          new ParDef("@AV79Mailsettingwwds_16_tfmailcuentanombre_sel",GXType.NChar,80,0) ,
          new ParDef("@lV80Mailsettingwwds_17_tfmaildireccion",GXType.VarChar,100,0) ,
          new ParDef("@AV81Mailsettingwwds_18_tfmaildireccion_sel",GXType.NVarChar,100,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00BZ2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00BZ2,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[0])[0] = rslt.getString(1, 250);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 80);
                ((long[]) buf[3])[0] = rslt.getLong(4);
                ((string[]) buf[4])[0] = rslt.getString(5, 3);
                return;
       }
    }

 }

}

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
   public class maildesignwwexportreport : GXWebProcedure, System.Web.SessionState.IRequiresSessionState
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

      public maildesignwwexportreport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public maildesignwwexportreport( IGxContext context )
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
         setOutputFileName("MailDesignWWExportReport");
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
            new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWMailDesign", out  GXt_boolean1) ;
            AV8IsAuthorized = GXt_boolean1;
            if ( ! AV8IsAuthorized )
            {
               GXKey = Crypto.GetSiteKey( );
               GXEncryptionTmp = "wwpbaseobjects.notauthorized.aspx"+UrlEncode(StringUtil.RTrim(AV63Pgmname));
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
               AV61Title = context.GetMessage( "Lista de Mail Design", "");
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
            HBK0( true, 0) ;
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
            HBK0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "WWP_FullTextFilterDescription", ""), 25, Gx_line+0, 131, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV13FilterFullText, "")), 131, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         if ( AV32GridState.gxTpr_Dynamicfilters.Count >= 1 )
         {
            AV27GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV32GridState.gxTpr_Dynamicfilters.Item(1));
            AV14DynamicFiltersSelector1 = AV27GridStateDynamicFilter.gxTpr_Selected;
            if ( StringUtil.StrCmp(AV14DynamicFiltersSelector1, "MAILDESIGNTIPO") == 0 )
            {
               AV15MailDesignTipo1 = AV27GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV15MailDesignTipo1)) )
               {
                  AV18FilterMailDesignTipo1ValueDescription = "";
                  if ( StringUtil.StrCmp(StringUtil.Trim( AV15MailDesignTipo1), "A") == 0 )
                  {
                     AV18FilterMailDesignTipo1ValueDescription = context.GetMessage( "Publicidad", "");
                  }
                  else if ( StringUtil.StrCmp(StringUtil.Trim( AV15MailDesignTipo1), "R") == 0 )
                  {
                     AV18FilterMailDesignTipo1ValueDescription = context.GetMessage( "Recuperar Usuario y Contraseña", "");
                  }
                  else if ( StringUtil.StrCmp(StringUtil.Trim( AV15MailDesignTipo1), "N") == 0 )
                  {
                     AV18FilterMailDesignTipo1ValueDescription = context.GetMessage( "Notificación", "");
                  }
                  else if ( StringUtil.StrCmp(StringUtil.Trim( AV15MailDesignTipo1), "O") == 0 )
                  {
                     AV18FilterMailDesignTipo1ValueDescription = context.GetMessage( "Otros", "");
                  }
                  AV17FilterMailDesignTipoValueDescription = AV18FilterMailDesignTipo1ValueDescription;
                  HBK0( false, 20) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(context.GetMessage( "Tipo", ""), 25, Gx_line+0, 131, Gx_line+15, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV17FilterMailDesignTipoValueDescription, "")), 131, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+20);
               }
            }
            if ( AV32GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV19DynamicFiltersEnabled2 = true;
               AV27GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV32GridState.gxTpr_Dynamicfilters.Item(2));
               AV20DynamicFiltersSelector2 = AV27GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV20DynamicFiltersSelector2, "MAILDESIGNTIPO") == 0 )
               {
                  AV21MailDesignTipo2 = AV27GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV21MailDesignTipo2)) )
                  {
                     AV22FilterMailDesignTipo2ValueDescription = "";
                     if ( StringUtil.StrCmp(StringUtil.Trim( AV21MailDesignTipo2), "A") == 0 )
                     {
                        AV22FilterMailDesignTipo2ValueDescription = context.GetMessage( "Publicidad", "");
                     }
                     else if ( StringUtil.StrCmp(StringUtil.Trim( AV21MailDesignTipo2), "R") == 0 )
                     {
                        AV22FilterMailDesignTipo2ValueDescription = context.GetMessage( "Recuperar Usuario y Contraseña", "");
                     }
                     else if ( StringUtil.StrCmp(StringUtil.Trim( AV21MailDesignTipo2), "N") == 0 )
                     {
                        AV22FilterMailDesignTipo2ValueDescription = context.GetMessage( "Notificación", "");
                     }
                     else if ( StringUtil.StrCmp(StringUtil.Trim( AV21MailDesignTipo2), "O") == 0 )
                     {
                        AV22FilterMailDesignTipo2ValueDescription = context.GetMessage( "Otros", "");
                     }
                     AV17FilterMailDesignTipoValueDescription = AV22FilterMailDesignTipo2ValueDescription;
                     HBK0( false, 20) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(context.GetMessage( "Tipo", ""), 25, Gx_line+0, 131, Gx_line+15, 0, 0, 0, 0) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV17FilterMailDesignTipoValueDescription, "")), 131, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                     Gx_OldLine = Gx_line;
                     Gx_line = (int)(Gx_line+20);
                  }
               }
               if ( AV32GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV23DynamicFiltersEnabled3 = true;
                  AV27GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV32GridState.gxTpr_Dynamicfilters.Item(3));
                  AV24DynamicFiltersSelector3 = AV27GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV24DynamicFiltersSelector3, "MAILDESIGNTIPO") == 0 )
                  {
                     AV25MailDesignTipo3 = AV27GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV25MailDesignTipo3)) )
                     {
                        AV26FilterMailDesignTipo3ValueDescription = "";
                        if ( StringUtil.StrCmp(StringUtil.Trim( AV25MailDesignTipo3), "A") == 0 )
                        {
                           AV26FilterMailDesignTipo3ValueDescription = context.GetMessage( "Publicidad", "");
                        }
                        else if ( StringUtil.StrCmp(StringUtil.Trim( AV25MailDesignTipo3), "R") == 0 )
                        {
                           AV26FilterMailDesignTipo3ValueDescription = context.GetMessage( "Recuperar Usuario y Contraseña", "");
                        }
                        else if ( StringUtil.StrCmp(StringUtil.Trim( AV25MailDesignTipo3), "N") == 0 )
                        {
                           AV26FilterMailDesignTipo3ValueDescription = context.GetMessage( "Notificación", "");
                        }
                        else if ( StringUtil.StrCmp(StringUtil.Trim( AV25MailDesignTipo3), "O") == 0 )
                        {
                           AV26FilterMailDesignTipo3ValueDescription = context.GetMessage( "Otros", "");
                        }
                        AV17FilterMailDesignTipoValueDescription = AV26FilterMailDesignTipo3ValueDescription;
                        HBK0( false, 20) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(context.GetMessage( "Tipo", ""), 25, Gx_line+0, 131, Gx_line+15, 0, 0, 0, 0) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV17FilterMailDesignTipoValueDescription, "")), 131, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                        Gx_OldLine = Gx_line;
                        Gx_line = (int)(Gx_line+20);
                     }
                  }
               }
            }
         }
         if ( ! ( (0==AV34TFMailDesignId) && (0==AV35TFMailDesignId_To) ) )
         {
            HBK0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Identificador", ""), 25, Gx_line+0, 131, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV34TFMailDesignId), "ZZZZZZZZZZZZZZZZZ9")), 131, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV46TFMailDesignId_To_Description = StringUtil.Format( "%1 (%2)", context.GetMessage( "Identificador", ""), context.GetMessage( "WWP_TSTo", ""), "", "", "", "", "", "", "");
            HBK0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV46TFMailDesignId_To_Description, "")), 25, Gx_line+0, 131, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV35TFMailDesignId_To), "ZZZZZZZZZZZZZZZZZ9")), 131, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         AV38TFMailDesignTipo_Sels.FromJSonString(AV36TFMailDesignTipo_SelsJson, null);
         if ( ! ( AV38TFMailDesignTipo_Sels.Count == 0 ) )
         {
            AV50i = 1;
            AV66GXV1 = 1;
            while ( AV66GXV1 <= AV38TFMailDesignTipo_Sels.Count )
            {
               AV39TFMailDesignTipo_Sel = AV38TFMailDesignTipo_Sels.GetString(AV66GXV1);
               if ( AV50i == 1 )
               {
                  AV37TFMailDesignTipo_SelDscs = "";
               }
               else
               {
                  AV37TFMailDesignTipo_SelDscs += ", ";
               }
               AV47FilterTFMailDesignTipo_SelValueDescription = "";
               if ( StringUtil.StrCmp(StringUtil.Trim( AV39TFMailDesignTipo_Sel), "A") == 0 )
               {
                  AV47FilterTFMailDesignTipo_SelValueDescription = context.GetMessage( "Publicidad", "");
               }
               else if ( StringUtil.StrCmp(StringUtil.Trim( AV39TFMailDesignTipo_Sel), "R") == 0 )
               {
                  AV47FilterTFMailDesignTipo_SelValueDescription = context.GetMessage( "Recuperar Usuario y Contraseña", "");
               }
               else if ( StringUtil.StrCmp(StringUtil.Trim( AV39TFMailDesignTipo_Sel), "N") == 0 )
               {
                  AV47FilterTFMailDesignTipo_SelValueDescription = context.GetMessage( "Notificación", "");
               }
               else if ( StringUtil.StrCmp(StringUtil.Trim( AV39TFMailDesignTipo_Sel), "O") == 0 )
               {
                  AV47FilterTFMailDesignTipo_SelValueDescription = context.GetMessage( "Otros", "");
               }
               AV37TFMailDesignTipo_SelDscs += AV47FilterTFMailDesignTipo_SelValueDescription;
               AV50i = (long)(AV50i+1);
               AV66GXV1 = (int)(AV66GXV1+1);
            }
            HBK0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Tipo", ""), 25, Gx_line+0, 131, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV37TFMailDesignTipo_SelDscs, "")), 131, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV41TFMailDesignAsunto_Sel)) )
         {
            AV49TempBoolean = (bool)(((StringUtil.StrCmp(AV41TFMailDesignAsunto_Sel, "<#Empty#>")==0)));
            AV41TFMailDesignAsunto_Sel = (AV49TempBoolean ? context.GetMessage( "WWP_TitleFilter_EmptyOption", "") : AV41TFMailDesignAsunto_Sel);
            HBK0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Asunto", ""), 25, Gx_line+0, 131, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV41TFMailDesignAsunto_Sel, "")), 131, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV41TFMailDesignAsunto_Sel = (AV49TempBoolean ? "<#Empty#>" : AV41TFMailDesignAsunto_Sel);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV40TFMailDesignAsunto)) )
            {
               HBK0( false, 20) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(context.GetMessage( "Asunto", ""), 25, Gx_line+0, 131, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV40TFMailDesignAsunto, "")), 131, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
         AV44TFMailDesignEstado_Sels.FromJSonString(AV42TFMailDesignEstado_SelsJson, null);
         if ( ! ( AV44TFMailDesignEstado_Sels.Count == 0 ) )
         {
            AV50i = 1;
            AV67GXV2 = 1;
            while ( AV67GXV2 <= AV44TFMailDesignEstado_Sels.Count )
            {
               AV45TFMailDesignEstado_Sel = AV44TFMailDesignEstado_Sels.GetString(AV67GXV2);
               if ( AV50i == 1 )
               {
                  AV43TFMailDesignEstado_SelDscs = "";
               }
               else
               {
                  AV43TFMailDesignEstado_SelDscs += ", ";
               }
               AV48FilterTFMailDesignEstado_SelValueDescription = "";
               if ( StringUtil.StrCmp(StringUtil.Trim( AV45TFMailDesignEstado_Sel), "HAB") == 0 )
               {
                  AV48FilterTFMailDesignEstado_SelValueDescription = context.GetMessage( "Habilitado", "");
               }
               else if ( StringUtil.StrCmp(StringUtil.Trim( AV45TFMailDesignEstado_Sel), "DES") == 0 )
               {
                  AV48FilterTFMailDesignEstado_SelValueDescription = context.GetMessage( "Deshabilitado", "");
               }
               AV43TFMailDesignEstado_SelDscs += AV48FilterTFMailDesignEstado_SelValueDescription;
               AV50i = (long)(AV50i+1);
               AV67GXV2 = (int)(AV67GXV2+1);
            }
            HBK0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Estado", ""), 25, Gx_line+0, 131, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV43TFMailDesignEstado_SelDscs, "")), 131, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
      }

      protected void S121( )
      {
         /* 'PRINTCOLUMNTITLES' Routine */
         returnInSub = false;
         HBK0( false, 22) ;
         getPrinter().GxDrawLine(25, Gx_line+21, 789, Gx_line+21, 2, 8, 160, 134, 0) ;
         Gx_OldLine = Gx_line;
         Gx_line = (int)(Gx_line+22);
         HBK0( false, 37) ;
         getPrinter().GxAttris("Microsoft Sans Serif", 9, false, false, false, false, 0, 8, 160, 134, 0, 255, 255, 255) ;
         getPrinter().GxDrawText(context.GetMessage( "Identificador", ""), 30, Gx_line+10, 136, Gx_line+27, 2, 0, 0, 0) ;
         getPrinter().GxDrawText(context.GetMessage( "Tipo", ""), 140, Gx_line+10, 352, Gx_line+27, 0, 0, 0, 0) ;
         getPrinter().GxDrawText(context.GetMessage( "Asunto", ""), 356, Gx_line+10, 569, Gx_line+27, 0, 0, 0, 0) ;
         getPrinter().GxDrawText(context.GetMessage( "Estado", ""), 573, Gx_line+10, 787, Gx_line+27, 0, 0, 0, 0) ;
         Gx_OldLine = Gx_line;
         Gx_line = (int)(Gx_line+37);
      }

      protected void S131( )
      {
         /* 'PRINTDATA' Routine */
         returnInSub = false;
         AV69Maildesignwwds_1_filterfulltext = AV13FilterFullText;
         AV70Maildesignwwds_2_dynamicfiltersselector1 = AV14DynamicFiltersSelector1;
         AV71Maildesignwwds_3_maildesigntipo1 = AV15MailDesignTipo1;
         AV72Maildesignwwds_4_dynamicfiltersenabled2 = AV19DynamicFiltersEnabled2;
         AV73Maildesignwwds_5_dynamicfiltersselector2 = AV20DynamicFiltersSelector2;
         AV74Maildesignwwds_6_maildesigntipo2 = AV21MailDesignTipo2;
         AV75Maildesignwwds_7_dynamicfiltersenabled3 = AV23DynamicFiltersEnabled3;
         AV76Maildesignwwds_8_dynamicfiltersselector3 = AV24DynamicFiltersSelector3;
         AV77Maildesignwwds_9_maildesigntipo3 = AV25MailDesignTipo3;
         AV78Maildesignwwds_10_tfmaildesignid = AV34TFMailDesignId;
         AV79Maildesignwwds_11_tfmaildesignid_to = AV35TFMailDesignId_To;
         AV80Maildesignwwds_12_tfmaildesigntipo_sels = AV38TFMailDesignTipo_Sels;
         AV81Maildesignwwds_13_tfmaildesignasunto = AV40TFMailDesignAsunto;
         AV82Maildesignwwds_14_tfmaildesignasunto_sel = AV41TFMailDesignAsunto_Sel;
         AV83Maildesignwwds_15_tfmaildesignestado_sels = AV44TFMailDesignEstado_Sels;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A244MailDesignTipo ,
                                              AV80Maildesignwwds_12_tfmaildesigntipo_sels ,
                                              A245MailDesignEstado ,
                                              AV83Maildesignwwds_15_tfmaildesignestado_sels ,
                                              AV70Maildesignwwds_2_dynamicfiltersselector1 ,
                                              AV71Maildesignwwds_3_maildesigntipo1 ,
                                              AV72Maildesignwwds_4_dynamicfiltersenabled2 ,
                                              AV73Maildesignwwds_5_dynamicfiltersselector2 ,
                                              AV74Maildesignwwds_6_maildesigntipo2 ,
                                              AV75Maildesignwwds_7_dynamicfiltersenabled3 ,
                                              AV76Maildesignwwds_8_dynamicfiltersselector3 ,
                                              AV77Maildesignwwds_9_maildesigntipo3 ,
                                              AV78Maildesignwwds_10_tfmaildesignid ,
                                              AV79Maildesignwwds_11_tfmaildesignid_to ,
                                              AV80Maildesignwwds_12_tfmaildesigntipo_sels.Count ,
                                              AV82Maildesignwwds_14_tfmaildesignasunto_sel ,
                                              AV81Maildesignwwds_13_tfmaildesignasunto ,
                                              AV83Maildesignwwds_15_tfmaildesignestado_sels.Count ,
                                              A148MailDesignId ,
                                              A246MailDesignAsunto ,
                                              AV11OrderedBy ,
                                              AV12OrderedDsc ,
                                              AV69Maildesignwwds_1_filterfulltext } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.INT, TypeConstants.INT, TypeConstants.LONG, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV81Maildesignwwds_13_tfmaildesignasunto = StringUtil.PadR( StringUtil.RTrim( AV81Maildesignwwds_13_tfmaildesignasunto), 80, "%");
         /* Using cursor P00BK2 */
         pr_default.execute(0, new Object[] {AV71Maildesignwwds_3_maildesigntipo1, AV74Maildesignwwds_6_maildesigntipo2, AV77Maildesignwwds_9_maildesigntipo3, AV78Maildesignwwds_10_tfmaildesignid, AV79Maildesignwwds_11_tfmaildesignid_to, lV81Maildesignwwds_13_tfmaildesignasunto, AV82Maildesignwwds_14_tfmaildesignasunto_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A246MailDesignAsunto = P00BK2_A246MailDesignAsunto[0];
            A148MailDesignId = P00BK2_A148MailDesignId[0];
            A245MailDesignEstado = P00BK2_A245MailDesignEstado[0];
            A244MailDesignTipo = P00BK2_A244MailDesignTipo[0];
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV69Maildesignwwds_1_filterfulltext)) || ( ( StringUtil.Like( StringUtil.Str( (decimal)(A148MailDesignId), 18, 0) , StringUtil.PadR( "%" + AV69Maildesignwwds_1_filterfulltext , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( context.GetMessage( "publicidad", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV69Maildesignwwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A244MailDesignTipo, "A") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "recuperar usuario y contraseña", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV69Maildesignwwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A244MailDesignTipo, "R") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "notificación", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV69Maildesignwwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A244MailDesignTipo, "N") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "otros", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV69Maildesignwwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A244MailDesignTipo, "O") == 0 ) ) || ( StringUtil.Like( StringUtil.Upper( A246MailDesignAsunto) , StringUtil.PadR( "%" + StringUtil.Upper( AV69Maildesignwwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( context.GetMessage( "habilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV69Maildesignwwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A245MailDesignEstado, "HAB") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "deshabilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV69Maildesignwwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A245MailDesignEstado, "DES") == 0 ) ) ) )
            {
               AV28MailDesignTipoDescription = "";
               if ( StringUtil.StrCmp(StringUtil.Trim( A244MailDesignTipo), "A") == 0 )
               {
                  AV28MailDesignTipoDescription = context.GetMessage( "Publicidad", "");
               }
               else if ( StringUtil.StrCmp(StringUtil.Trim( A244MailDesignTipo), "R") == 0 )
               {
                  AV28MailDesignTipoDescription = context.GetMessage( "Recuperar Usuario y Contraseña", "");
               }
               else if ( StringUtil.StrCmp(StringUtil.Trim( A244MailDesignTipo), "N") == 0 )
               {
                  AV28MailDesignTipoDescription = context.GetMessage( "Notificación", "");
               }
               else if ( StringUtil.StrCmp(StringUtil.Trim( A244MailDesignTipo), "O") == 0 )
               {
                  AV28MailDesignTipoDescription = context.GetMessage( "Otros", "");
               }
               AV29MailDesignEstadoDescription = "";
               if ( StringUtil.StrCmp(StringUtil.Trim( A245MailDesignEstado), "HAB") == 0 )
               {
                  AV29MailDesignEstadoDescription = context.GetMessage( "Habilitado", "");
               }
               else if ( StringUtil.StrCmp(StringUtil.Trim( A245MailDesignEstado), "DES") == 0 )
               {
                  AV29MailDesignEstadoDescription = context.GetMessage( "Deshabilitado", "");
               }
               /* Execute user subroutine: 'BEFOREPRINTLINE' */
               S144 ();
               if ( returnInSub )
               {
                  pr_default.close(0);
                  returnInSub = true;
                  if (true) return;
               }
               HBK0( false, 36) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(A148MailDesignId), "ZZZZZZZZZZZZZZZZZ9")), 30, Gx_line+10, 136, Gx_line+25, 2+16, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV28MailDesignTipoDescription, "")), 140, Gx_line+10, 352, Gx_line+25, 0+16, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A246MailDesignAsunto, "")), 356, Gx_line+10, 569, Gx_line+25, 0+16, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV29MailDesignEstadoDescription, "")), 573, Gx_line+10, 787, Gx_line+25, 0+16, 0, 0, 0) ;
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
         if ( StringUtil.StrCmp(AV30Session.Get("MailDesignWWGridState"), "") == 0 )
         {
            AV32GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "MailDesignWWGridState"), null, "", "");
         }
         else
         {
            AV32GridState.FromXml(AV30Session.Get("MailDesignWWGridState"), null, "", "");
         }
         AV11OrderedBy = AV32GridState.gxTpr_Orderedby;
         AV12OrderedDsc = AV32GridState.gxTpr_Ordereddsc;
         AV84GXV3 = 1;
         while ( AV84GXV3 <= AV32GridState.gxTpr_Filtervalues.Count )
         {
            AV33GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV32GridState.gxTpr_Filtervalues.Item(AV84GXV3));
            if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV13FilterFullText = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFMAILDESIGNID") == 0 )
            {
               AV34TFMailDesignId = (long)(Math.Round(NumberUtil.Val( AV33GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV35TFMailDesignId_To = (long)(Math.Round(NumberUtil.Val( AV33GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFMAILDESIGNTIPO_SEL") == 0 )
            {
               AV36TFMailDesignTipo_SelsJson = AV33GridStateFilterValue.gxTpr_Value;
               AV38TFMailDesignTipo_Sels.FromJSonString(AV36TFMailDesignTipo_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFMAILDESIGNASUNTO") == 0 )
            {
               AV40TFMailDesignAsunto = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFMAILDESIGNASUNTO_SEL") == 0 )
            {
               AV41TFMailDesignAsunto_Sel = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFMAILDESIGNESTADO_SEL") == 0 )
            {
               AV42TFMailDesignEstado_SelsJson = AV33GridStateFilterValue.gxTpr_Value;
               AV44TFMailDesignEstado_Sels.FromJSonString(AV42TFMailDesignEstado_SelsJson, null);
            }
            AV84GXV3 = (int)(AV84GXV3+1);
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

      protected void HBK0( bool bFoot ,
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
                  AV59PageInfo = context.GetMessage( "Page: ", "") + StringUtil.Trim( StringUtil.Str( (decimal)(Gx_page), 6, 0));
                  AV56DateInfo = context.GetMessage( "Date: ", "") + context.localUtil.Format( Gx_date, "99/99/99");
                  getPrinter().GxDrawRect(0, Gx_line+5, 819, Gx_line+40, 1, 0, 0, 0, 1, 8, 160, 134, 1, 1, 1, 1, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV59PageInfo, "")), 30, Gx_line+15, 409, Gx_line+30, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV56DateInfo, "")), 409, Gx_line+15, 789, Gx_line+30, 2, 0, 0, 0) ;
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
               AV54AppName = context.GetMessage( "DVelop Software Solutions", "");
               AV60Phone = "+1 550 8923";
               AV58Mail = "info@mail.com";
               AV62Website = "http://www.web.com";
               AV51AddressLine1 = "French Boulevard 2859";
               AV52AddressLine2 = "Downtown";
               AV53AddressLine3 = "Paris, France";
               getPrinter().GxDrawRect(0, Gx_line+0, 819, Gx_line+108, 1, 0, 0, 0, 1, 8, 160, 134, 1, 1, 1, 1, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV54AppName, "")), 30, Gx_line+30, 283, Gx_line+45, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 20, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV61Title, "")), 30, Gx_line+45, 283, Gx_line+78, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV60Phone, "")), 283, Gx_line+30, 536, Gx_line+46, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV58Mail, "")), 283, Gx_line+46, 536, Gx_line+62, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV62Website, "")), 283, Gx_line+62, 536, Gx_line+78, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV51AddressLine1, "")), 536, Gx_line+30, 789, Gx_line+46, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV52AddressLine2, "")), 536, Gx_line+46, 789, Gx_line+62, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV53AddressLine3, "")), 536, Gx_line+62, 789, Gx_line+78, 2, 0, 0, 0) ;
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
         AV63Pgmname = "";
         GXEncryptionTmp = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV61Title = "";
         AV13FilterFullText = "";
         AV32GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV27GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV14DynamicFiltersSelector1 = "";
         AV15MailDesignTipo1 = "";
         AV18FilterMailDesignTipo1ValueDescription = "";
         AV17FilterMailDesignTipoValueDescription = "";
         AV20DynamicFiltersSelector2 = "";
         AV21MailDesignTipo2 = "";
         AV22FilterMailDesignTipo2ValueDescription = "";
         AV24DynamicFiltersSelector3 = "";
         AV25MailDesignTipo3 = "";
         AV26FilterMailDesignTipo3ValueDescription = "";
         AV46TFMailDesignId_To_Description = "";
         AV38TFMailDesignTipo_Sels = new GxSimpleCollection<string>();
         AV36TFMailDesignTipo_SelsJson = "";
         AV39TFMailDesignTipo_Sel = "";
         AV37TFMailDesignTipo_SelDscs = "";
         AV47FilterTFMailDesignTipo_SelValueDescription = "";
         AV41TFMailDesignAsunto_Sel = "";
         AV40TFMailDesignAsunto = "";
         AV44TFMailDesignEstado_Sels = new GxSimpleCollection<string>();
         AV42TFMailDesignEstado_SelsJson = "";
         AV45TFMailDesignEstado_Sel = "";
         AV43TFMailDesignEstado_SelDscs = "";
         AV48FilterTFMailDesignEstado_SelValueDescription = "";
         AV69Maildesignwwds_1_filterfulltext = "";
         AV70Maildesignwwds_2_dynamicfiltersselector1 = "";
         AV71Maildesignwwds_3_maildesigntipo1 = "";
         AV73Maildesignwwds_5_dynamicfiltersselector2 = "";
         AV74Maildesignwwds_6_maildesigntipo2 = "";
         AV76Maildesignwwds_8_dynamicfiltersselector3 = "";
         AV77Maildesignwwds_9_maildesigntipo3 = "";
         AV80Maildesignwwds_12_tfmaildesigntipo_sels = new GxSimpleCollection<string>();
         AV81Maildesignwwds_13_tfmaildesignasunto = "";
         AV82Maildesignwwds_14_tfmaildesignasunto_sel = "";
         AV83Maildesignwwds_15_tfmaildesignestado_sels = new GxSimpleCollection<string>();
         lV81Maildesignwwds_13_tfmaildesignasunto = "";
         A244MailDesignTipo = "";
         A245MailDesignEstado = "";
         A246MailDesignAsunto = "";
         P00BK2_A246MailDesignAsunto = new string[] {""} ;
         P00BK2_A148MailDesignId = new long[1] ;
         P00BK2_A245MailDesignEstado = new string[] {""} ;
         P00BK2_A244MailDesignTipo = new string[] {""} ;
         AV28MailDesignTipoDescription = "";
         AV29MailDesignEstadoDescription = "";
         AV30Session = context.GetSession();
         AV33GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV59PageInfo = "";
         AV56DateInfo = "";
         Gx_date = DateTime.MinValue;
         AV54AppName = "";
         AV60Phone = "";
         AV58Mail = "";
         AV62Website = "";
         AV51AddressLine1 = "";
         AV52AddressLine2 = "";
         AV53AddressLine3 = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.maildesignwwexportreport__default(),
            new Object[][] {
                new Object[] {
               P00BK2_A246MailDesignAsunto, P00BK2_A148MailDesignId, P00BK2_A245MailDesignEstado, P00BK2_A244MailDesignTipo
               }
            }
         );
         Gx_date = DateTimeUtil.Today( context);
         AV63Pgmname = "MailDesignWWExportReport";
         /* GeneXus formulas. */
         Gx_line = 0;
         Gx_date = DateTimeUtil.Today( context);
         AV63Pgmname = "MailDesignWWExportReport";
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
      private int AV66GXV1 ;
      private int AV67GXV2 ;
      private int AV80Maildesignwwds_12_tfmaildesigntipo_sels_Count ;
      private int AV83Maildesignwwds_15_tfmaildesignestado_sels_Count ;
      private int AV84GXV3 ;
      private long AV34TFMailDesignId ;
      private long AV35TFMailDesignId_To ;
      private long AV50i ;
      private long AV78Maildesignwwds_10_tfmaildesignid ;
      private long AV79Maildesignwwds_11_tfmaildesignid_to ;
      private long A148MailDesignId ;
      private string GXKey ;
      private string gxfirstwebparm ;
      private string AV63Pgmname ;
      private string GXEncryptionTmp ;
      private string AV15MailDesignTipo1 ;
      private string AV21MailDesignTipo2 ;
      private string AV25MailDesignTipo3 ;
      private string AV39TFMailDesignTipo_Sel ;
      private string AV41TFMailDesignAsunto_Sel ;
      private string AV40TFMailDesignAsunto ;
      private string AV45TFMailDesignEstado_Sel ;
      private string AV71Maildesignwwds_3_maildesigntipo1 ;
      private string AV74Maildesignwwds_6_maildesigntipo2 ;
      private string AV77Maildesignwwds_9_maildesigntipo3 ;
      private string AV81Maildesignwwds_13_tfmaildesignasunto ;
      private string AV82Maildesignwwds_14_tfmaildesignasunto_sel ;
      private string lV81Maildesignwwds_13_tfmaildesignasunto ;
      private string A244MailDesignTipo ;
      private string A245MailDesignEstado ;
      private string A246MailDesignAsunto ;
      private DateTime Gx_date ;
      private bool entryPointCalled ;
      private bool AV8IsAuthorized ;
      private bool GXt_boolean1 ;
      private bool returnInSub ;
      private bool AV19DynamicFiltersEnabled2 ;
      private bool AV23DynamicFiltersEnabled3 ;
      private bool AV49TempBoolean ;
      private bool AV72Maildesignwwds_4_dynamicfiltersenabled2 ;
      private bool AV75Maildesignwwds_7_dynamicfiltersenabled3 ;
      private bool AV12OrderedDsc ;
      private string AV36TFMailDesignTipo_SelsJson ;
      private string AV42TFMailDesignEstado_SelsJson ;
      private string AV61Title ;
      private string AV13FilterFullText ;
      private string AV14DynamicFiltersSelector1 ;
      private string AV18FilterMailDesignTipo1ValueDescription ;
      private string AV17FilterMailDesignTipoValueDescription ;
      private string AV20DynamicFiltersSelector2 ;
      private string AV22FilterMailDesignTipo2ValueDescription ;
      private string AV24DynamicFiltersSelector3 ;
      private string AV26FilterMailDesignTipo3ValueDescription ;
      private string AV46TFMailDesignId_To_Description ;
      private string AV37TFMailDesignTipo_SelDscs ;
      private string AV47FilterTFMailDesignTipo_SelValueDescription ;
      private string AV43TFMailDesignEstado_SelDscs ;
      private string AV48FilterTFMailDesignEstado_SelValueDescription ;
      private string AV69Maildesignwwds_1_filterfulltext ;
      private string AV70Maildesignwwds_2_dynamicfiltersselector1 ;
      private string AV73Maildesignwwds_5_dynamicfiltersselector2 ;
      private string AV76Maildesignwwds_8_dynamicfiltersselector3 ;
      private string AV28MailDesignTipoDescription ;
      private string AV29MailDesignEstadoDescription ;
      private string AV59PageInfo ;
      private string AV56DateInfo ;
      private string AV54AppName ;
      private string AV60Phone ;
      private string AV58Mail ;
      private string AV62Website ;
      private string AV51AddressLine1 ;
      private string AV52AddressLine2 ;
      private string AV53AddressLine3 ;
      private IGxSession AV30Session ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV32GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV27GridStateDynamicFilter ;
      private GxSimpleCollection<string> AV38TFMailDesignTipo_Sels ;
      private GxSimpleCollection<string> AV44TFMailDesignEstado_Sels ;
      private GxSimpleCollection<string> AV80Maildesignwwds_12_tfmaildesigntipo_sels ;
      private GxSimpleCollection<string> AV83Maildesignwwds_15_tfmaildesignestado_sels ;
      private IDataStoreProvider pr_default ;
      private string[] P00BK2_A246MailDesignAsunto ;
      private long[] P00BK2_A148MailDesignId ;
      private string[] P00BK2_A245MailDesignEstado ;
      private string[] P00BK2_A244MailDesignTipo ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV33GridStateFilterValue ;
   }

   public class maildesignwwexportreport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00BK2( IGxContext context ,
                                             string A244MailDesignTipo ,
                                             GxSimpleCollection<string> AV80Maildesignwwds_12_tfmaildesigntipo_sels ,
                                             string A245MailDesignEstado ,
                                             GxSimpleCollection<string> AV83Maildesignwwds_15_tfmaildesignestado_sels ,
                                             string AV70Maildesignwwds_2_dynamicfiltersselector1 ,
                                             string AV71Maildesignwwds_3_maildesigntipo1 ,
                                             bool AV72Maildesignwwds_4_dynamicfiltersenabled2 ,
                                             string AV73Maildesignwwds_5_dynamicfiltersselector2 ,
                                             string AV74Maildesignwwds_6_maildesigntipo2 ,
                                             bool AV75Maildesignwwds_7_dynamicfiltersenabled3 ,
                                             string AV76Maildesignwwds_8_dynamicfiltersselector3 ,
                                             string AV77Maildesignwwds_9_maildesigntipo3 ,
                                             long AV78Maildesignwwds_10_tfmaildesignid ,
                                             long AV79Maildesignwwds_11_tfmaildesignid_to ,
                                             int AV80Maildesignwwds_12_tfmaildesigntipo_sels_Count ,
                                             string AV82Maildesignwwds_14_tfmaildesignasunto_sel ,
                                             string AV81Maildesignwwds_13_tfmaildesignasunto ,
                                             int AV83Maildesignwwds_15_tfmaildesignestado_sels_Count ,
                                             long A148MailDesignId ,
                                             string A246MailDesignAsunto ,
                                             short AV11OrderedBy ,
                                             bool AV12OrderedDsc ,
                                             string AV69Maildesignwwds_1_filterfulltext )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int2 = new short[7];
         Object[] GXv_Object3 = new Object[2];
         scmdbuf = "SELECT [MailDesignAsunto], [MailDesignId], [MailDesignEstado], [MailDesignTipo] FROM [MailDesign]";
         if ( ( StringUtil.StrCmp(AV70Maildesignwwds_2_dynamicfiltersselector1, "MAILDESIGNTIPO") == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Maildesignwwds_3_maildesigntipo1)) ) )
         {
            AddWhere(sWhereString, "([MailDesignTipo] = @AV71Maildesignwwds_3_maildesigntipo1)");
         }
         else
         {
            GXv_int2[0] = 1;
         }
         if ( AV72Maildesignwwds_4_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV73Maildesignwwds_5_dynamicfiltersselector2, "MAILDESIGNTIPO") == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Maildesignwwds_6_maildesigntipo2)) ) )
         {
            AddWhere(sWhereString, "([MailDesignTipo] = @AV74Maildesignwwds_6_maildesigntipo2)");
         }
         else
         {
            GXv_int2[1] = 1;
         }
         if ( AV75Maildesignwwds_7_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV76Maildesignwwds_8_dynamicfiltersselector3, "MAILDESIGNTIPO") == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV77Maildesignwwds_9_maildesigntipo3)) ) )
         {
            AddWhere(sWhereString, "([MailDesignTipo] = @AV77Maildesignwwds_9_maildesigntipo3)");
         }
         else
         {
            GXv_int2[2] = 1;
         }
         if ( ! (0==AV78Maildesignwwds_10_tfmaildesignid) )
         {
            AddWhere(sWhereString, "([MailDesignId] >= @AV78Maildesignwwds_10_tfmaildesignid)");
         }
         else
         {
            GXv_int2[3] = 1;
         }
         if ( ! (0==AV79Maildesignwwds_11_tfmaildesignid_to) )
         {
            AddWhere(sWhereString, "([MailDesignId] <= @AV79Maildesignwwds_11_tfmaildesignid_to)");
         }
         else
         {
            GXv_int2[4] = 1;
         }
         if ( AV80Maildesignwwds_12_tfmaildesigntipo_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV80Maildesignwwds_12_tfmaildesigntipo_sels, "[MailDesignTipo] IN (", ")")+")");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV82Maildesignwwds_14_tfmaildesignasunto_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV81Maildesignwwds_13_tfmaildesignasunto)) ) )
         {
            AddWhere(sWhereString, "(UPPER([MailDesignAsunto]) like UPPER(@lV81Maildesignwwds_13_tfmaildesignasunto))");
         }
         else
         {
            GXv_int2[5] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV82Maildesignwwds_14_tfmaildesignasunto_sel)) && ! ( StringUtil.StrCmp(AV82Maildesignwwds_14_tfmaildesignasunto_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([MailDesignAsunto] = @AV82Maildesignwwds_14_tfmaildesignasunto_sel)");
         }
         else
         {
            GXv_int2[6] = 1;
         }
         if ( StringUtil.StrCmp(AV82Maildesignwwds_14_tfmaildesignasunto_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([MailDesignAsunto] = ''))");
         }
         if ( AV83Maildesignwwds_15_tfmaildesignestado_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV83Maildesignwwds_15_tfmaildesignestado_sels, "[MailDesignEstado] IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         if ( ( AV11OrderedBy == 1 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY [MailDesignTipo]";
         }
         else if ( ( AV11OrderedBy == 1 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [MailDesignTipo] DESC";
         }
         else if ( ( AV11OrderedBy == 2 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY [MailDesignId]";
         }
         else if ( ( AV11OrderedBy == 2 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [MailDesignId] DESC";
         }
         else if ( ( AV11OrderedBy == 3 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY [MailDesignAsunto]";
         }
         else if ( ( AV11OrderedBy == 3 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [MailDesignAsunto] DESC";
         }
         else if ( ( AV11OrderedBy == 4 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY [MailDesignEstado]";
         }
         else if ( ( AV11OrderedBy == 4 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [MailDesignEstado] DESC";
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
                     return conditional_P00BK2(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (GxSimpleCollection<string>)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (bool)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (bool)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (long)dynConstraints[12] , (long)dynConstraints[13] , (int)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (int)dynConstraints[17] , (long)dynConstraints[18] , (string)dynConstraints[19] , (short)dynConstraints[20] , (bool)dynConstraints[21] , (string)dynConstraints[22] );
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
          Object[] prmP00BK2;
          prmP00BK2 = new Object[] {
          new ParDef("@AV71Maildesignwwds_3_maildesigntipo1",GXType.NChar,1,0) ,
          new ParDef("@AV74Maildesignwwds_6_maildesigntipo2",GXType.NChar,1,0) ,
          new ParDef("@AV77Maildesignwwds_9_maildesigntipo3",GXType.NChar,1,0) ,
          new ParDef("@AV78Maildesignwwds_10_tfmaildesignid",GXType.Decimal,18,0) ,
          new ParDef("@AV79Maildesignwwds_11_tfmaildesignid_to",GXType.Decimal,18,0) ,
          new ParDef("@lV81Maildesignwwds_13_tfmaildesignasunto",GXType.Char,80,0) ,
          new ParDef("@AV82Maildesignwwds_14_tfmaildesignasunto_sel",GXType.NChar,80,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00BK2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00BK2,100, GxCacheFrequency.OFF ,true,false )
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
                ((long[]) buf[1])[0] = rslt.getLong(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 3);
                ((string[]) buf[3])[0] = rslt.getString(4, 1);
                return;
       }
    }

 }

}

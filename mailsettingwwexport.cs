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
using GeneXus.XML;
using GeneXus.Office;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Threading;
using System.Xml.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class mailsettingwwexport : GXProcedure
   {
      public mailsettingwwexport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public mailsettingwwexport( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( out string aP0_Filename ,
                           out string aP1_ErrorMessage )
      {
         this.AV12Filename = "" ;
         this.AV13ErrorMessage = "" ;
         initialize();
         ExecutePrivate();
         aP0_Filename=this.AV12Filename;
         aP1_ErrorMessage=this.AV13ErrorMessage;
      }

      public string executeUdp( out string aP0_Filename )
      {
         execute(out aP0_Filename, out aP1_ErrorMessage);
         return AV13ErrorMessage ;
      }

      public void executeSubmit( out string aP0_Filename ,
                                 out string aP1_ErrorMessage )
      {
         this.AV12Filename = "" ;
         this.AV13ErrorMessage = "" ;
         SubmitImpl();
         aP0_Filename=this.AV12Filename;
         aP1_ErrorMessage=this.AV13ErrorMessage;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         GXt_boolean1 = AV8IsAuthorized;
         new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWMailSetting", out  GXt_boolean1) ;
         AV8IsAuthorized = GXt_boolean1;
         if ( ! AV8IsAuthorized )
         {
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "wwpbaseobjects.notauthorized.aspx"+GXUtil.UrlEncode(StringUtil.RTrim(AV57Pgmname));
            CallWebObject(formatLink("wwpbaseobjects.notauthorized.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
            context.wjLocDisableFrm = 1;
         }
         if ( AV8IsAuthorized )
         {
            new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV9WWPContext) ;
            /* Execute user subroutine: 'OPENDOCUMENT' */
            S111 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
            AV14CellRow = 1;
            AV15FirstColumn = 1;
            /* Execute user subroutine: 'LOADGRIDSTATE' */
            S201 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
            /* Execute user subroutine: 'WRITEFILTERS' */
            S131 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
            /* Execute user subroutine: 'WRITECOLUMNTITLES' */
            S141 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
            /* Execute user subroutine: 'WRITEDATA' */
            S161 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
            /* Execute user subroutine: 'CLOSEDOCUMENT' */
            S191 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         cleanup();
      }

      protected void S111( )
      {
         /* 'OPENDOCUMENT' Routine */
         returnInSub = false;
         AV16Random = (int)(NumberUtil.Random( )*10000);
         GXt_char2 = AV12Filename;
         new GeneXus.Programs.wwpbaseobjects.wwp_getdefaultexportpath(context ).execute( out  GXt_char2) ;
         AV12Filename = GXt_char2 + "MailSettingWWExport-" + StringUtil.Trim( StringUtil.Str( (decimal)(AV16Random), 8, 0)) + ".xlsx";
         AV11ExcelDocument.Open(AV12Filename);
         /* Execute user subroutine: 'CHECKSTATUS' */
         S121 ();
         if (returnInSub) return;
         AV11ExcelDocument.Clear();
      }

      protected void S131( )
      {
         /* 'WRITEFILTERS' Routine */
         returnInSub = false;
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV19FilterFullText)) ) )
         {
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "WWP_FullTextFilterDescription", "")) ;
            AV14CellRow = GXt_int3;
            GXt_char2 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV19FilterFullText, out  GXt_char2) ;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
         }
         if ( AV34GridState.gxTpr_Dynamicfilters.Count >= 1 )
         {
            AV31GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV34GridState.gxTpr_Dynamicfilters.Item(1));
            AV20DynamicFiltersSelector1 = AV31GridStateDynamicFilter.gxTpr_Selected;
            if ( StringUtil.StrCmp(AV20DynamicFiltersSelector1, "MAILHOSTSMTP") == 0 )
            {
               AV21DynamicFiltersOperator1 = AV31GridStateDynamicFilter.gxTpr_Operator;
               AV22MailHostSMTP1 = AV31GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV22MailHostSMTP1)) )
               {
                  AV14CellRow = (int)(AV14CellRow+1);
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Bold = 1;
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Color = 3;
                  if ( AV21DynamicFiltersOperator1 == 0 )
                  {
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", context.GetMessage( "Host SMTP", ""), context.GetMessage( "WWP_FilterLike", ""), "", "", "", "", "", "", "");
                  }
                  else if ( AV21DynamicFiltersOperator1 == 1 )
                  {
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", context.GetMessage( "Host SMTP", ""), context.GetMessage( "WWP_FilterContains", ""), "", "", "", "", "", "", "");
                  }
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Italic = 1;
                  GXt_char2 = "";
                  new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV22MailHostSMTP1, out  GXt_char2) ;
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
               }
            }
            if ( AV34GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV23DynamicFiltersEnabled2 = true;
               AV31GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV34GridState.gxTpr_Dynamicfilters.Item(2));
               AV24DynamicFiltersSelector2 = AV31GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV24DynamicFiltersSelector2, "MAILHOSTSMTP") == 0 )
               {
                  AV25DynamicFiltersOperator2 = AV31GridStateDynamicFilter.gxTpr_Operator;
                  AV26MailHostSMTP2 = AV31GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV26MailHostSMTP2)) )
                  {
                     AV14CellRow = (int)(AV14CellRow+1);
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Bold = 1;
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Color = 3;
                     if ( AV25DynamicFiltersOperator2 == 0 )
                     {
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", context.GetMessage( "Host SMTP", ""), context.GetMessage( "WWP_FilterLike", ""), "", "", "", "", "", "", "");
                     }
                     else if ( AV25DynamicFiltersOperator2 == 1 )
                     {
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", context.GetMessage( "Host SMTP", ""), context.GetMessage( "WWP_FilterContains", ""), "", "", "", "", "", "", "");
                     }
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Italic = 1;
                     GXt_char2 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV26MailHostSMTP2, out  GXt_char2) ;
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
                  }
               }
               if ( AV34GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV27DynamicFiltersEnabled3 = true;
                  AV31GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV34GridState.gxTpr_Dynamicfilters.Item(3));
                  AV28DynamicFiltersSelector3 = AV31GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV28DynamicFiltersSelector3, "MAILHOSTSMTP") == 0 )
                  {
                     AV29DynamicFiltersOperator3 = AV31GridStateDynamicFilter.gxTpr_Operator;
                     AV30MailHostSMTP3 = AV31GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV30MailHostSMTP3)) )
                     {
                        AV14CellRow = (int)(AV14CellRow+1);
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Bold = 1;
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Color = 3;
                        if ( AV29DynamicFiltersOperator3 == 0 )
                        {
                           AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", context.GetMessage( "Host SMTP", ""), context.GetMessage( "WWP_FilterLike", ""), "", "", "", "", "", "", "");
                        }
                        else if ( AV29DynamicFiltersOperator3 == 1 )
                        {
                           AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", context.GetMessage( "Host SMTP", ""), context.GetMessage( "WWP_FilterContains", ""), "", "", "", "", "", "", "");
                        }
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Italic = 1;
                        GXt_char2 = "";
                        new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV30MailHostSMTP3, out  GXt_char2) ;
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
                     }
                  }
               }
            }
         }
         if ( ! ( (0==AV47TFMailId) && (0==AV48TFMailId_To) ) )
         {
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Identificador", "")) ;
            AV14CellRow = GXt_int3;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Number = AV47TFMailId;
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  false, ref  GXt_int3,  (short)(AV15FirstColumn+2),  context.GetMessage( "WWP_TSTo", "")) ;
            AV14CellRow = GXt_int3;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+3, 1, 1).Number = AV48TFMailId_To;
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV50TFMailCuentaNombre_Sel)) ) )
         {
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Nombre de la Cuenta", "")) ;
            AV14CellRow = GXt_int3;
            GXt_char2 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV50TFMailCuentaNombre_Sel)) ? context.GetMessage( "WWP_TitleFilter_EmptyOption", "") : AV50TFMailCuentaNombre_Sel), out  GXt_char2) ;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV49TFMailCuentaNombre)) ) )
            {
               GXt_int3 = (short)(AV14CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Nombre de la Cuenta", "")) ;
               AV14CellRow = GXt_int3;
               GXt_char2 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV49TFMailCuentaNombre, out  GXt_char2) ;
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV52TFMailDireccion_Sel)) ) )
         {
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Direccion", "")) ;
            AV14CellRow = GXt_int3;
            GXt_char2 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV52TFMailDireccion_Sel)) ? context.GetMessage( "WWP_TitleFilter_EmptyOption", "") : AV52TFMailDireccion_Sel), out  GXt_char2) ;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV51TFMailDireccion)) ) )
            {
               GXt_int3 = (short)(AV14CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Direccion", "")) ;
               AV14CellRow = GXt_int3;
               GXt_char2 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV51TFMailDireccion, out  GXt_char2) ;
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
            }
         }
         if ( ! ( ( AV54TFMailEstado_Sels.Count == 0 ) ) )
         {
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Estado", "")) ;
            AV14CellRow = GXt_int3;
            AV56i = 1;
            AV58GXV1 = 1;
            while ( AV58GXV1 <= AV54TFMailEstado_Sels.Count )
            {
               AV55TFMailEstado_Sel = AV54TFMailEstado_Sels.GetString(AV58GXV1);
               if ( AV56i == 1 )
               {
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = "";
               }
               else
               {
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text+", ";
               }
               if ( StringUtil.StrCmp(StringUtil.Trim( AV55TFMailEstado_Sel), context.GetMessage( "HAB", "")) == 0 )
               {
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text+context.GetMessage( "Habilitado", "");
               }
               else if ( StringUtil.StrCmp(StringUtil.Trim( AV55TFMailEstado_Sel), context.GetMessage( "DES", "")) == 0 )
               {
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text+context.GetMessage( "Deshabilitado", "");
               }
               AV56i = (long)(AV56i+1);
               AV58GXV1 = (int)(AV58GXV1+1);
            }
         }
         AV14CellRow = (int)(AV14CellRow+2);
      }

      protected void S141( )
      {
         /* 'WRITECOLUMNTITLES' Routine */
         returnInSub = false;
         AV44VisibleColumnCount = 0;
         if ( StringUtil.StrCmp(AV32Session.Get("MailSettingWWColumnsSelector"), "") != 0 )
         {
            AV39ColumnsSelectorXML = AV32Session.Get("MailSettingWWColumnsSelector");
            AV36ColumnsSelector.FromXml(AV39ColumnsSelectorXML, null, "", "");
         }
         else
         {
            /* Execute user subroutine: 'INITIALIZECOLUMNSSELECTOR' */
            S151 ();
            if (returnInSub) return;
         }
         AV36ColumnsSelector.gxTpr_Columns.Sort("Order");
         AV59GXV2 = 1;
         while ( AV59GXV2 <= AV36ColumnsSelector.gxTpr_Columns.Count )
         {
            AV38ColumnsSelector_Column = ((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV36ColumnsSelector.gxTpr_Columns.Item(AV59GXV2));
            if ( AV38ColumnsSelector_Column.gxTpr_Isvisible )
            {
               AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV44VisibleColumnCount), 1, 1).Text = context.GetMessage( (String.IsNullOrEmpty(StringUtil.RTrim( AV38ColumnsSelector_Column.gxTpr_Displayname)) ? AV38ColumnsSelector_Column.gxTpr_Columnname : AV38ColumnsSelector_Column.gxTpr_Displayname), "");
               AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV44VisibleColumnCount), 1, 1).Bold = 1;
               AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV44VisibleColumnCount), 1, 1).Color = 11;
               AV44VisibleColumnCount = (long)(AV44VisibleColumnCount+1);
            }
            AV59GXV2 = (int)(AV59GXV2+1);
         }
      }

      protected void S161( )
      {
         /* 'WRITEDATA' Routine */
         returnInSub = false;
         AV61Mailsettingwwds_1_filterfulltext = AV19FilterFullText;
         AV62Mailsettingwwds_2_dynamicfiltersselector1 = AV20DynamicFiltersSelector1;
         AV63Mailsettingwwds_3_dynamicfiltersoperator1 = AV21DynamicFiltersOperator1;
         AV64Mailsettingwwds_4_mailhostsmtp1 = AV22MailHostSMTP1;
         AV65Mailsettingwwds_5_dynamicfiltersenabled2 = AV23DynamicFiltersEnabled2;
         AV66Mailsettingwwds_6_dynamicfiltersselector2 = AV24DynamicFiltersSelector2;
         AV67Mailsettingwwds_7_dynamicfiltersoperator2 = AV25DynamicFiltersOperator2;
         AV68Mailsettingwwds_8_mailhostsmtp2 = AV26MailHostSMTP2;
         AV69Mailsettingwwds_9_dynamicfiltersenabled3 = AV27DynamicFiltersEnabled3;
         AV70Mailsettingwwds_10_dynamicfiltersselector3 = AV28DynamicFiltersSelector3;
         AV71Mailsettingwwds_11_dynamicfiltersoperator3 = AV29DynamicFiltersOperator3;
         AV72Mailsettingwwds_12_mailhostsmtp3 = AV30MailHostSMTP3;
         AV73Mailsettingwwds_13_tfmailid = AV47TFMailId;
         AV74Mailsettingwwds_14_tfmailid_to = AV48TFMailId_To;
         AV75Mailsettingwwds_15_tfmailcuentanombre = AV49TFMailCuentaNombre;
         AV76Mailsettingwwds_16_tfmailcuentanombre_sel = AV50TFMailCuentaNombre_Sel;
         AV77Mailsettingwwds_17_tfmaildireccion = AV51TFMailDireccion;
         AV78Mailsettingwwds_18_tfmaildireccion_sel = AV52TFMailDireccion_Sel;
         AV79Mailsettingwwds_19_tfmailestado_sels = AV54TFMailEstado_Sels;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A243MailEstado ,
                                              AV79Mailsettingwwds_19_tfmailestado_sels ,
                                              AV62Mailsettingwwds_2_dynamicfiltersselector1 ,
                                              AV63Mailsettingwwds_3_dynamicfiltersoperator1 ,
                                              AV64Mailsettingwwds_4_mailhostsmtp1 ,
                                              AV65Mailsettingwwds_5_dynamicfiltersenabled2 ,
                                              AV66Mailsettingwwds_6_dynamicfiltersselector2 ,
                                              AV67Mailsettingwwds_7_dynamicfiltersoperator2 ,
                                              AV68Mailsettingwwds_8_mailhostsmtp2 ,
                                              AV69Mailsettingwwds_9_dynamicfiltersenabled3 ,
                                              AV70Mailsettingwwds_10_dynamicfiltersselector3 ,
                                              AV71Mailsettingwwds_11_dynamicfiltersoperator3 ,
                                              AV72Mailsettingwwds_12_mailhostsmtp3 ,
                                              AV73Mailsettingwwds_13_tfmailid ,
                                              AV74Mailsettingwwds_14_tfmailid_to ,
                                              AV76Mailsettingwwds_16_tfmailcuentanombre_sel ,
                                              AV75Mailsettingwwds_15_tfmailcuentanombre ,
                                              AV78Mailsettingwwds_18_tfmaildireccion_sel ,
                                              AV77Mailsettingwwds_17_tfmaildireccion ,
                                              AV79Mailsettingwwds_19_tfmailestado_sels.Count ,
                                              A249MailHostSMTP ,
                                              A149MailId ,
                                              A241MailCuentaNombre ,
                                              A242MailDireccion ,
                                              AV17OrderedBy ,
                                              AV18OrderedDsc ,
                                              AV61Mailsettingwwds_1_filterfulltext } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.INT, TypeConstants.LONG, TypeConstants.SHORT,
                                              TypeConstants.BOOLEAN
                                              }
         });
         lV64Mailsettingwwds_4_mailhostsmtp1 = StringUtil.PadR( StringUtil.RTrim( AV64Mailsettingwwds_4_mailhostsmtp1), 250, "%");
         lV64Mailsettingwwds_4_mailhostsmtp1 = StringUtil.PadR( StringUtil.RTrim( AV64Mailsettingwwds_4_mailhostsmtp1), 250, "%");
         lV68Mailsettingwwds_8_mailhostsmtp2 = StringUtil.PadR( StringUtil.RTrim( AV68Mailsettingwwds_8_mailhostsmtp2), 250, "%");
         lV68Mailsettingwwds_8_mailhostsmtp2 = StringUtil.PadR( StringUtil.RTrim( AV68Mailsettingwwds_8_mailhostsmtp2), 250, "%");
         lV72Mailsettingwwds_12_mailhostsmtp3 = StringUtil.PadR( StringUtil.RTrim( AV72Mailsettingwwds_12_mailhostsmtp3), 250, "%");
         lV72Mailsettingwwds_12_mailhostsmtp3 = StringUtil.PadR( StringUtil.RTrim( AV72Mailsettingwwds_12_mailhostsmtp3), 250, "%");
         lV75Mailsettingwwds_15_tfmailcuentanombre = StringUtil.PadR( StringUtil.RTrim( AV75Mailsettingwwds_15_tfmailcuentanombre), 80, "%");
         lV77Mailsettingwwds_17_tfmaildireccion = StringUtil.Concat( StringUtil.RTrim( AV77Mailsettingwwds_17_tfmaildireccion), "%", "");
         /* Using cursor P00BY2 */
         pr_default.execute(0, new Object[] {lV64Mailsettingwwds_4_mailhostsmtp1, lV64Mailsettingwwds_4_mailhostsmtp1, lV68Mailsettingwwds_8_mailhostsmtp2, lV68Mailsettingwwds_8_mailhostsmtp2, lV72Mailsettingwwds_12_mailhostsmtp3, lV72Mailsettingwwds_12_mailhostsmtp3, AV73Mailsettingwwds_13_tfmailid, AV74Mailsettingwwds_14_tfmailid_to, lV75Mailsettingwwds_15_tfmailcuentanombre, AV76Mailsettingwwds_16_tfmailcuentanombre_sel, lV77Mailsettingwwds_17_tfmaildireccion, AV78Mailsettingwwds_18_tfmaildireccion_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A249MailHostSMTP = P00BY2_A249MailHostSMTP[0];
            A242MailDireccion = P00BY2_A242MailDireccion[0];
            A241MailCuentaNombre = P00BY2_A241MailCuentaNombre[0];
            A149MailId = P00BY2_A149MailId[0];
            A243MailEstado = P00BY2_A243MailEstado[0];
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV61Mailsettingwwds_1_filterfulltext)) || ( ( StringUtil.Like( StringUtil.Str( (decimal)(A149MailId), 18, 0) , StringUtil.PadR( "%" + AV61Mailsettingwwds_1_filterfulltext , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A241MailCuentaNombre) , StringUtil.PadR( "%" + StringUtil.Upper( AV61Mailsettingwwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A242MailDireccion) , StringUtil.PadR( "%" + StringUtil.Upper( AV61Mailsettingwwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( context.GetMessage( "habilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV61Mailsettingwwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A243MailEstado, "HAB") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "deshabilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV61Mailsettingwwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A243MailEstado, "DES") == 0 ) ) ) )
            {
               AV14CellRow = (int)(AV14CellRow+1);
               /* Execute user subroutine: 'BEFOREWRITELINE' */
               S172 ();
               if ( returnInSub )
               {
                  pr_default.close(0);
                  returnInSub = true;
                  if (true) return;
               }
               AV44VisibleColumnCount = 0;
               AV80GXV3 = 1;
               while ( AV80GXV3 <= AV36ColumnsSelector.gxTpr_Columns.Count )
               {
                  AV38ColumnsSelector_Column = ((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV36ColumnsSelector.gxTpr_Columns.Item(AV80GXV3));
                  if ( AV38ColumnsSelector_Column.gxTpr_Isvisible )
                  {
                     if ( StringUtil.StrCmp(AV38ColumnsSelector_Column.gxTpr_Columnname, "MailId") == 0 )
                     {
                        AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV44VisibleColumnCount), 1, 1).Number = A149MailId;
                     }
                     else if ( StringUtil.StrCmp(AV38ColumnsSelector_Column.gxTpr_Columnname, "MailCuentaNombre") == 0 )
                     {
                        GXt_char2 = "";
                        new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A241MailCuentaNombre, out  GXt_char2) ;
                        AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV44VisibleColumnCount), 1, 1).Text = GXt_char2;
                     }
                     else if ( StringUtil.StrCmp(AV38ColumnsSelector_Column.gxTpr_Columnname, "MailDireccion") == 0 )
                     {
                        GXt_char2 = "";
                        new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A242MailDireccion, out  GXt_char2) ;
                        AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV44VisibleColumnCount), 1, 1).Text = GXt_char2;
                     }
                     else if ( StringUtil.StrCmp(AV38ColumnsSelector_Column.gxTpr_Columnname, "MailEstado") == 0 )
                     {
                        AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV44VisibleColumnCount), 1, 1).Text = "";
                        if ( StringUtil.StrCmp(StringUtil.Trim( A243MailEstado), context.GetMessage( "HAB", "")) == 0 )
                        {
                           AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV44VisibleColumnCount), 1, 1).Text = context.GetMessage( "Habilitado", "");
                        }
                        else if ( StringUtil.StrCmp(StringUtil.Trim( A243MailEstado), context.GetMessage( "DES", "")) == 0 )
                        {
                           AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV44VisibleColumnCount), 1, 1).Text = context.GetMessage( "Deshabilitado", "");
                        }
                     }
                     AV44VisibleColumnCount = (long)(AV44VisibleColumnCount+1);
                  }
                  AV80GXV3 = (int)(AV80GXV3+1);
               }
               /* Execute user subroutine: 'AFTERWRITELINE' */
               S182 ();
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

      protected void S191( )
      {
         /* 'CLOSEDOCUMENT' Routine */
         returnInSub = false;
         AV11ExcelDocument.Save();
         /* Execute user subroutine: 'CHECKSTATUS' */
         S121 ();
         if (returnInSub) return;
         AV11ExcelDocument.Close();
         AV32Session.Set("WWPExportFilePath", AV12Filename);
         AV32Session.Set("WWPExportFileName", "MailSettingWWExport.xlsx");
         AV12Filename = formatLink("wwpbaseobjects.wwp_downloadreport.aspx") ;
      }

      protected void S121( )
      {
         /* 'CHECKSTATUS' Routine */
         returnInSub = false;
         if ( AV11ExcelDocument.ErrCode != 0 )
         {
            AV12Filename = "";
            AV13ErrorMessage = AV11ExcelDocument.ErrDescription;
            AV11ExcelDocument.Close();
            returnInSub = true;
            if (true) return;
         }
      }

      protected void S151( )
      {
         /* 'INITIALIZECOLUMNSSELECTOR' Routine */
         returnInSub = false;
         AV36ColumnsSelector = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector(context);
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV36ColumnsSelector,  "MailId",  "",  "Identificador",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV36ColumnsSelector,  "MailCuentaNombre",  "",  "Nombre de la Cuenta",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV36ColumnsSelector,  "MailDireccion",  "",  "Direccion",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV36ColumnsSelector,  "MailEstado",  "",  "Estado",  true,  "") ;
         GXt_char2 = AV40UserCustomValue;
         new GeneXus.Programs.wwpbaseobjects.loadcolumnsselectorstate(context ).execute(  "MailSettingWWColumnsSelector", out  GXt_char2) ;
         AV40UserCustomValue = GXt_char2;
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV40UserCustomValue)) ) )
         {
            AV37ColumnsSelectorAux.FromXml(AV40UserCustomValue, null, "", "");
            new GeneXus.Programs.wwpbaseobjects.wwp_columnselector_updatecolumns(context ).execute( ref  AV37ColumnsSelectorAux, ref  AV36ColumnsSelector) ;
         }
      }

      protected void S201( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV32Session.Get("MailSettingWWGridState"), "") == 0 )
         {
            AV34GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "MailSettingWWGridState"), null, "", "");
         }
         else
         {
            AV34GridState.FromXml(AV32Session.Get("MailSettingWWGridState"), null, "", "");
         }
         AV17OrderedBy = AV34GridState.gxTpr_Orderedby;
         AV18OrderedDsc = AV34GridState.gxTpr_Ordereddsc;
         AV81GXV4 = 1;
         while ( AV81GXV4 <= AV34GridState.gxTpr_Filtervalues.Count )
         {
            AV35GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV34GridState.gxTpr_Filtervalues.Item(AV81GXV4));
            if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV19FilterFullText = AV35GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFMAILID") == 0 )
            {
               AV47TFMailId = (long)(Math.Round(NumberUtil.Val( AV35GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV48TFMailId_To = (long)(Math.Round(NumberUtil.Val( AV35GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFMAILCUENTANOMBRE") == 0 )
            {
               AV49TFMailCuentaNombre = AV35GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFMAILCUENTANOMBRE_SEL") == 0 )
            {
               AV50TFMailCuentaNombre_Sel = AV35GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFMAILDIRECCION") == 0 )
            {
               AV51TFMailDireccion = AV35GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFMAILDIRECCION_SEL") == 0 )
            {
               AV52TFMailDireccion_Sel = AV35GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFMAILESTADO_SEL") == 0 )
            {
               AV53TFMailEstado_SelsJson = AV35GridStateFilterValue.gxTpr_Value;
               AV54TFMailEstado_Sels.FromJSonString(AV53TFMailEstado_SelsJson, null);
            }
            AV81GXV4 = (int)(AV81GXV4+1);
         }
      }

      protected void S172( )
      {
         /* 'BEFOREWRITELINE' Routine */
         returnInSub = false;
      }

      protected void S182( )
      {
         /* 'AFTERWRITELINE' Routine */
         returnInSub = false;
      }

      public override void cleanup( )
      {
         CloseCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
         ExitApp();
      }

      public override void initialize( )
      {
         AV12Filename = "";
         AV13ErrorMessage = "";
         AV57Pgmname = "";
         GXKey = "";
         GXEncryptionTmp = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV11ExcelDocument = new ExcelDocumentI();
         AV19FilterFullText = "";
         AV34GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV31GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV20DynamicFiltersSelector1 = "";
         AV22MailHostSMTP1 = "";
         AV24DynamicFiltersSelector2 = "";
         AV26MailHostSMTP2 = "";
         AV28DynamicFiltersSelector3 = "";
         AV30MailHostSMTP3 = "";
         AV50TFMailCuentaNombre_Sel = "";
         AV49TFMailCuentaNombre = "";
         AV52TFMailDireccion_Sel = "";
         AV51TFMailDireccion = "";
         AV54TFMailEstado_Sels = new GxSimpleCollection<string>();
         AV55TFMailEstado_Sel = "";
         AV32Session = context.GetSession();
         AV39ColumnsSelectorXML = "";
         AV36ColumnsSelector = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector(context);
         AV38ColumnsSelector_Column = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column(context);
         AV61Mailsettingwwds_1_filterfulltext = "";
         AV62Mailsettingwwds_2_dynamicfiltersselector1 = "";
         AV64Mailsettingwwds_4_mailhostsmtp1 = "";
         AV66Mailsettingwwds_6_dynamicfiltersselector2 = "";
         AV68Mailsettingwwds_8_mailhostsmtp2 = "";
         AV70Mailsettingwwds_10_dynamicfiltersselector3 = "";
         AV72Mailsettingwwds_12_mailhostsmtp3 = "";
         AV75Mailsettingwwds_15_tfmailcuentanombre = "";
         AV76Mailsettingwwds_16_tfmailcuentanombre_sel = "";
         AV77Mailsettingwwds_17_tfmaildireccion = "";
         AV78Mailsettingwwds_18_tfmaildireccion_sel = "";
         AV79Mailsettingwwds_19_tfmailestado_sels = new GxSimpleCollection<string>();
         lV64Mailsettingwwds_4_mailhostsmtp1 = "";
         lV68Mailsettingwwds_8_mailhostsmtp2 = "";
         lV72Mailsettingwwds_12_mailhostsmtp3 = "";
         lV75Mailsettingwwds_15_tfmailcuentanombre = "";
         lV77Mailsettingwwds_17_tfmaildireccion = "";
         A243MailEstado = "";
         A249MailHostSMTP = "";
         A241MailCuentaNombre = "";
         A242MailDireccion = "";
         P00BY2_A249MailHostSMTP = new string[] {""} ;
         P00BY2_A242MailDireccion = new string[] {""} ;
         P00BY2_A241MailCuentaNombre = new string[] {""} ;
         P00BY2_A149MailId = new long[1] ;
         P00BY2_A243MailEstado = new string[] {""} ;
         AV40UserCustomValue = "";
         GXt_char2 = "";
         AV37ColumnsSelectorAux = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector(context);
         AV35GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV53TFMailEstado_SelsJson = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.mailsettingwwexport__default(),
            new Object[][] {
                new Object[] {
               P00BY2_A249MailHostSMTP, P00BY2_A242MailDireccion, P00BY2_A241MailCuentaNombre, P00BY2_A149MailId, P00BY2_A243MailEstado
               }
            }
         );
         AV57Pgmname = "MailSettingWWExport";
         /* GeneXus formulas. */
         AV57Pgmname = "MailSettingWWExport";
      }

      private short AV21DynamicFiltersOperator1 ;
      private short AV25DynamicFiltersOperator2 ;
      private short AV29DynamicFiltersOperator3 ;
      private short GXt_int3 ;
      private short AV63Mailsettingwwds_3_dynamicfiltersoperator1 ;
      private short AV67Mailsettingwwds_7_dynamicfiltersoperator2 ;
      private short AV71Mailsettingwwds_11_dynamicfiltersoperator3 ;
      private short AV17OrderedBy ;
      private int AV14CellRow ;
      private int AV15FirstColumn ;
      private int AV16Random ;
      private int AV58GXV1 ;
      private int AV59GXV2 ;
      private int AV79Mailsettingwwds_19_tfmailestado_sels_Count ;
      private int AV80GXV3 ;
      private int AV81GXV4 ;
      private long AV47TFMailId ;
      private long AV48TFMailId_To ;
      private long AV56i ;
      private long AV44VisibleColumnCount ;
      private long AV73Mailsettingwwds_13_tfmailid ;
      private long AV74Mailsettingwwds_14_tfmailid_to ;
      private long A149MailId ;
      private string AV57Pgmname ;
      private string GXKey ;
      private string GXEncryptionTmp ;
      private string AV22MailHostSMTP1 ;
      private string AV26MailHostSMTP2 ;
      private string AV30MailHostSMTP3 ;
      private string AV50TFMailCuentaNombre_Sel ;
      private string AV49TFMailCuentaNombre ;
      private string AV55TFMailEstado_Sel ;
      private string AV64Mailsettingwwds_4_mailhostsmtp1 ;
      private string AV68Mailsettingwwds_8_mailhostsmtp2 ;
      private string AV72Mailsettingwwds_12_mailhostsmtp3 ;
      private string AV75Mailsettingwwds_15_tfmailcuentanombre ;
      private string AV76Mailsettingwwds_16_tfmailcuentanombre_sel ;
      private string lV64Mailsettingwwds_4_mailhostsmtp1 ;
      private string lV68Mailsettingwwds_8_mailhostsmtp2 ;
      private string lV72Mailsettingwwds_12_mailhostsmtp3 ;
      private string lV75Mailsettingwwds_15_tfmailcuentanombre ;
      private string A243MailEstado ;
      private string A249MailHostSMTP ;
      private string A241MailCuentaNombre ;
      private string GXt_char2 ;
      private bool AV8IsAuthorized ;
      private bool GXt_boolean1 ;
      private bool returnInSub ;
      private bool AV23DynamicFiltersEnabled2 ;
      private bool AV27DynamicFiltersEnabled3 ;
      private bool AV65Mailsettingwwds_5_dynamicfiltersenabled2 ;
      private bool AV69Mailsettingwwds_9_dynamicfiltersenabled3 ;
      private bool AV18OrderedDsc ;
      private string AV39ColumnsSelectorXML ;
      private string AV40UserCustomValue ;
      private string AV53TFMailEstado_SelsJson ;
      private string AV12Filename ;
      private string AV13ErrorMessage ;
      private string AV19FilterFullText ;
      private string AV20DynamicFiltersSelector1 ;
      private string AV24DynamicFiltersSelector2 ;
      private string AV28DynamicFiltersSelector3 ;
      private string AV52TFMailDireccion_Sel ;
      private string AV51TFMailDireccion ;
      private string AV61Mailsettingwwds_1_filterfulltext ;
      private string AV62Mailsettingwwds_2_dynamicfiltersselector1 ;
      private string AV66Mailsettingwwds_6_dynamicfiltersselector2 ;
      private string AV70Mailsettingwwds_10_dynamicfiltersselector3 ;
      private string AV77Mailsettingwwds_17_tfmaildireccion ;
      private string AV78Mailsettingwwds_18_tfmaildireccion_sel ;
      private string lV77Mailsettingwwds_17_tfmaildireccion ;
      private string A242MailDireccion ;
      private IGxSession AV32Session ;
      private ExcelDocumentI AV11ExcelDocument ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV34GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV31GridStateDynamicFilter ;
      private GxSimpleCollection<string> AV54TFMailEstado_Sels ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector AV36ColumnsSelector ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column AV38ColumnsSelector_Column ;
      private GxSimpleCollection<string> AV79Mailsettingwwds_19_tfmailestado_sels ;
      private IDataStoreProvider pr_default ;
      private string[] P00BY2_A249MailHostSMTP ;
      private string[] P00BY2_A242MailDireccion ;
      private string[] P00BY2_A241MailCuentaNombre ;
      private long[] P00BY2_A149MailId ;
      private string[] P00BY2_A243MailEstado ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector AV37ColumnsSelectorAux ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV35GridStateFilterValue ;
      private string aP0_Filename ;
      private string aP1_ErrorMessage ;
   }

   public class mailsettingwwexport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00BY2( IGxContext context ,
                                             string A243MailEstado ,
                                             GxSimpleCollection<string> AV79Mailsettingwwds_19_tfmailestado_sels ,
                                             string AV62Mailsettingwwds_2_dynamicfiltersselector1 ,
                                             short AV63Mailsettingwwds_3_dynamicfiltersoperator1 ,
                                             string AV64Mailsettingwwds_4_mailhostsmtp1 ,
                                             bool AV65Mailsettingwwds_5_dynamicfiltersenabled2 ,
                                             string AV66Mailsettingwwds_6_dynamicfiltersselector2 ,
                                             short AV67Mailsettingwwds_7_dynamicfiltersoperator2 ,
                                             string AV68Mailsettingwwds_8_mailhostsmtp2 ,
                                             bool AV69Mailsettingwwds_9_dynamicfiltersenabled3 ,
                                             string AV70Mailsettingwwds_10_dynamicfiltersselector3 ,
                                             short AV71Mailsettingwwds_11_dynamicfiltersoperator3 ,
                                             string AV72Mailsettingwwds_12_mailhostsmtp3 ,
                                             long AV73Mailsettingwwds_13_tfmailid ,
                                             long AV74Mailsettingwwds_14_tfmailid_to ,
                                             string AV76Mailsettingwwds_16_tfmailcuentanombre_sel ,
                                             string AV75Mailsettingwwds_15_tfmailcuentanombre ,
                                             string AV78Mailsettingwwds_18_tfmaildireccion_sel ,
                                             string AV77Mailsettingwwds_17_tfmaildireccion ,
                                             int AV79Mailsettingwwds_19_tfmailestado_sels_Count ,
                                             string A249MailHostSMTP ,
                                             long A149MailId ,
                                             string A241MailCuentaNombre ,
                                             string A242MailDireccion ,
                                             short AV17OrderedBy ,
                                             bool AV18OrderedDsc ,
                                             string AV61Mailsettingwwds_1_filterfulltext )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int4 = new short[12];
         Object[] GXv_Object5 = new Object[2];
         scmdbuf = "SELECT [MailHostSMTP], [MailDireccion], [MailCuentaNombre], [MailId], [MailEstado] FROM [Mail]";
         if ( ( StringUtil.StrCmp(AV62Mailsettingwwds_2_dynamicfiltersselector1, "MAILHOSTSMTP") == 0 ) && ( AV63Mailsettingwwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Mailsettingwwds_4_mailhostsmtp1)) ) )
         {
            AddWhere(sWhereString, "(UPPER([MailHostSMTP]) like UPPER(@lV64Mailsettingwwds_4_mailhostsmtp1))");
         }
         else
         {
            GXv_int4[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV62Mailsettingwwds_2_dynamicfiltersselector1, "MAILHOSTSMTP") == 0 ) && ( AV63Mailsettingwwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Mailsettingwwds_4_mailhostsmtp1)) ) )
         {
            AddWhere(sWhereString, "(UPPER([MailHostSMTP]) like '%' + UPPER(@lV64Mailsettingwwds_4_mailhostsmtp1))");
         }
         else
         {
            GXv_int4[1] = 1;
         }
         if ( AV65Mailsettingwwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV66Mailsettingwwds_6_dynamicfiltersselector2, "MAILHOSTSMTP") == 0 ) && ( AV67Mailsettingwwds_7_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Mailsettingwwds_8_mailhostsmtp2)) ) )
         {
            AddWhere(sWhereString, "(UPPER([MailHostSMTP]) like UPPER(@lV68Mailsettingwwds_8_mailhostsmtp2))");
         }
         else
         {
            GXv_int4[2] = 1;
         }
         if ( AV65Mailsettingwwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV66Mailsettingwwds_6_dynamicfiltersselector2, "MAILHOSTSMTP") == 0 ) && ( AV67Mailsettingwwds_7_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Mailsettingwwds_8_mailhostsmtp2)) ) )
         {
            AddWhere(sWhereString, "(UPPER([MailHostSMTP]) like '%' + UPPER(@lV68Mailsettingwwds_8_mailhostsmtp2))");
         }
         else
         {
            GXv_int4[3] = 1;
         }
         if ( AV69Mailsettingwwds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV70Mailsettingwwds_10_dynamicfiltersselector3, "MAILHOSTSMTP") == 0 ) && ( AV71Mailsettingwwds_11_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Mailsettingwwds_12_mailhostsmtp3)) ) )
         {
            AddWhere(sWhereString, "(UPPER([MailHostSMTP]) like UPPER(@lV72Mailsettingwwds_12_mailhostsmtp3))");
         }
         else
         {
            GXv_int4[4] = 1;
         }
         if ( AV69Mailsettingwwds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV70Mailsettingwwds_10_dynamicfiltersselector3, "MAILHOSTSMTP") == 0 ) && ( AV71Mailsettingwwds_11_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Mailsettingwwds_12_mailhostsmtp3)) ) )
         {
            AddWhere(sWhereString, "(UPPER([MailHostSMTP]) like '%' + UPPER(@lV72Mailsettingwwds_12_mailhostsmtp3))");
         }
         else
         {
            GXv_int4[5] = 1;
         }
         if ( ! (0==AV73Mailsettingwwds_13_tfmailid) )
         {
            AddWhere(sWhereString, "([MailId] >= @AV73Mailsettingwwds_13_tfmailid)");
         }
         else
         {
            GXv_int4[6] = 1;
         }
         if ( ! (0==AV74Mailsettingwwds_14_tfmailid_to) )
         {
            AddWhere(sWhereString, "([MailId] <= @AV74Mailsettingwwds_14_tfmailid_to)");
         }
         else
         {
            GXv_int4[7] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV76Mailsettingwwds_16_tfmailcuentanombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75Mailsettingwwds_15_tfmailcuentanombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER([MailCuentaNombre]) like UPPER(@lV75Mailsettingwwds_15_tfmailcuentanombre))");
         }
         else
         {
            GXv_int4[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV76Mailsettingwwds_16_tfmailcuentanombre_sel)) && ! ( StringUtil.StrCmp(AV76Mailsettingwwds_16_tfmailcuentanombre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([MailCuentaNombre] = @AV76Mailsettingwwds_16_tfmailcuentanombre_sel)");
         }
         else
         {
            GXv_int4[9] = 1;
         }
         if ( StringUtil.StrCmp(AV76Mailsettingwwds_16_tfmailcuentanombre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([MailCuentaNombre] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV78Mailsettingwwds_18_tfmaildireccion_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV77Mailsettingwwds_17_tfmaildireccion)) ) )
         {
            AddWhere(sWhereString, "(UPPER([MailDireccion]) like UPPER(@lV77Mailsettingwwds_17_tfmaildireccion))");
         }
         else
         {
            GXv_int4[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV78Mailsettingwwds_18_tfmaildireccion_sel)) && ! ( StringUtil.StrCmp(AV78Mailsettingwwds_18_tfmaildireccion_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([MailDireccion] = @AV78Mailsettingwwds_18_tfmaildireccion_sel)");
         }
         else
         {
            GXv_int4[11] = 1;
         }
         if ( StringUtil.StrCmp(AV78Mailsettingwwds_18_tfmaildireccion_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([MailDireccion] = ''))");
         }
         if ( AV79Mailsettingwwds_19_tfmailestado_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV79Mailsettingwwds_19_tfmailestado_sels, "[MailEstado] IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         if ( AV17OrderedBy == 1 )
         {
            scmdbuf += " ORDER BY [MailHostSMTP]";
         }
         else if ( ( AV17OrderedBy == 2 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY [MailId]";
         }
         else if ( ( AV17OrderedBy == 2 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [MailId] DESC";
         }
         else if ( ( AV17OrderedBy == 3 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY [MailCuentaNombre]";
         }
         else if ( ( AV17OrderedBy == 3 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [MailCuentaNombre] DESC";
         }
         else if ( ( AV17OrderedBy == 4 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY [MailDireccion]";
         }
         else if ( ( AV17OrderedBy == 4 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [MailDireccion] DESC";
         }
         else if ( ( AV17OrderedBy == 5 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY [MailEstado]";
         }
         else if ( ( AV17OrderedBy == 5 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [MailEstado] DESC";
         }
         GXv_Object5[0] = scmdbuf;
         GXv_Object5[1] = GXv_int4;
         return GXv_Object5 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_P00BY2(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (bool)dynConstraints[5] , (string)dynConstraints[6] , (short)dynConstraints[7] , (string)dynConstraints[8] , (bool)dynConstraints[9] , (string)dynConstraints[10] , (short)dynConstraints[11] , (string)dynConstraints[12] , (long)dynConstraints[13] , (long)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (int)dynConstraints[19] , (string)dynConstraints[20] , (long)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (short)dynConstraints[24] , (bool)dynConstraints[25] , (string)dynConstraints[26] );
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
          Object[] prmP00BY2;
          prmP00BY2 = new Object[] {
          new ParDef("@lV64Mailsettingwwds_4_mailhostsmtp1",GXType.Char,250,0) ,
          new ParDef("@lV64Mailsettingwwds_4_mailhostsmtp1",GXType.Char,250,0) ,
          new ParDef("@lV68Mailsettingwwds_8_mailhostsmtp2",GXType.Char,250,0) ,
          new ParDef("@lV68Mailsettingwwds_8_mailhostsmtp2",GXType.Char,250,0) ,
          new ParDef("@lV72Mailsettingwwds_12_mailhostsmtp3",GXType.Char,250,0) ,
          new ParDef("@lV72Mailsettingwwds_12_mailhostsmtp3",GXType.Char,250,0) ,
          new ParDef("@AV73Mailsettingwwds_13_tfmailid",GXType.Decimal,18,0) ,
          new ParDef("@AV74Mailsettingwwds_14_tfmailid_to",GXType.Decimal,18,0) ,
          new ParDef("@lV75Mailsettingwwds_15_tfmailcuentanombre",GXType.Char,80,0) ,
          new ParDef("@AV76Mailsettingwwds_16_tfmailcuentanombre_sel",GXType.NChar,80,0) ,
          new ParDef("@lV77Mailsettingwwds_17_tfmaildireccion",GXType.VarChar,100,0) ,
          new ParDef("@AV78Mailsettingwwds_18_tfmaildireccion_sel",GXType.NVarChar,100,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00BY2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00BY2,100, GxCacheFrequency.OFF ,true,false )
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

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
   public class maildesignwwexport : GXProcedure
   {
      public maildesignwwexport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public maildesignwwexport( IGxContext context )
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
         new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWMailDesign", out  GXt_boolean1) ;
         AV8IsAuthorized = GXt_boolean1;
         if ( ! AV8IsAuthorized )
         {
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "wwpbaseobjects.notauthorized.aspx"+GXUtil.UrlEncode(StringUtil.RTrim(AV55Pgmname));
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
         AV12Filename = GXt_char2 + "MailDesignWWExport-" + StringUtil.Trim( StringUtil.Str( (decimal)(AV16Random), 8, 0)) + ".xlsx";
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
         if ( AV31GridState.gxTpr_Dynamicfilters.Count >= 1 )
         {
            AV28GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV31GridState.gxTpr_Dynamicfilters.Item(1));
            AV20DynamicFiltersSelector1 = AV28GridStateDynamicFilter.gxTpr_Selected;
            if ( StringUtil.StrCmp(AV20DynamicFiltersSelector1, "MAILDESIGNTIPO") == 0 )
            {
               AV21MailDesignTipo1 = AV28GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV21MailDesignTipo1)) )
               {
                  AV14CellRow = (int)(AV14CellRow+1);
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Bold = 1;
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Color = 3;
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = context.GetMessage( "Tipo", "");
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Italic = 1;
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = "";
                  if ( StringUtil.StrCmp(StringUtil.Trim( AV21MailDesignTipo1), context.GetMessage( "A", "")) == 0 )
                  {
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = context.GetMessage( "Publicidad", "");
                  }
                  else if ( StringUtil.StrCmp(StringUtil.Trim( AV21MailDesignTipo1), context.GetMessage( "R", "")) == 0 )
                  {
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = context.GetMessage( "Recuperar Usuario y Contraseña", "");
                  }
                  else if ( StringUtil.StrCmp(StringUtil.Trim( AV21MailDesignTipo1), context.GetMessage( "N", "")) == 0 )
                  {
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = context.GetMessage( "Notificación", "");
                  }
                  else if ( StringUtil.StrCmp(StringUtil.Trim( AV21MailDesignTipo1), context.GetMessage( "O", "")) == 0 )
                  {
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = context.GetMessage( "Otros", "");
                  }
               }
            }
            if ( AV31GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV22DynamicFiltersEnabled2 = true;
               AV28GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV31GridState.gxTpr_Dynamicfilters.Item(2));
               AV23DynamicFiltersSelector2 = AV28GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV23DynamicFiltersSelector2, "MAILDESIGNTIPO") == 0 )
               {
                  AV24MailDesignTipo2 = AV28GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV24MailDesignTipo2)) )
                  {
                     AV14CellRow = (int)(AV14CellRow+1);
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Bold = 1;
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Color = 3;
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = context.GetMessage( "Tipo", "");
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Italic = 1;
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = "";
                     if ( StringUtil.StrCmp(StringUtil.Trim( AV24MailDesignTipo2), context.GetMessage( "A", "")) == 0 )
                     {
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = context.GetMessage( "Publicidad", "");
                     }
                     else if ( StringUtil.StrCmp(StringUtil.Trim( AV24MailDesignTipo2), context.GetMessage( "R", "")) == 0 )
                     {
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = context.GetMessage( "Recuperar Usuario y Contraseña", "");
                     }
                     else if ( StringUtil.StrCmp(StringUtil.Trim( AV24MailDesignTipo2), context.GetMessage( "N", "")) == 0 )
                     {
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = context.GetMessage( "Notificación", "");
                     }
                     else if ( StringUtil.StrCmp(StringUtil.Trim( AV24MailDesignTipo2), context.GetMessage( "O", "")) == 0 )
                     {
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = context.GetMessage( "Otros", "");
                     }
                  }
               }
               if ( AV31GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV25DynamicFiltersEnabled3 = true;
                  AV28GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV31GridState.gxTpr_Dynamicfilters.Item(3));
                  AV26DynamicFiltersSelector3 = AV28GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV26DynamicFiltersSelector3, "MAILDESIGNTIPO") == 0 )
                  {
                     AV27MailDesignTipo3 = AV28GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV27MailDesignTipo3)) )
                     {
                        AV14CellRow = (int)(AV14CellRow+1);
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Bold = 1;
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Color = 3;
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = context.GetMessage( "Tipo", "");
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Italic = 1;
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = "";
                        if ( StringUtil.StrCmp(StringUtil.Trim( AV27MailDesignTipo3), context.GetMessage( "A", "")) == 0 )
                        {
                           AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = context.GetMessage( "Publicidad", "");
                        }
                        else if ( StringUtil.StrCmp(StringUtil.Trim( AV27MailDesignTipo3), context.GetMessage( "R", "")) == 0 )
                        {
                           AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = context.GetMessage( "Recuperar Usuario y Contraseña", "");
                        }
                        else if ( StringUtil.StrCmp(StringUtil.Trim( AV27MailDesignTipo3), context.GetMessage( "N", "")) == 0 )
                        {
                           AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = context.GetMessage( "Notificación", "");
                        }
                        else if ( StringUtil.StrCmp(StringUtil.Trim( AV27MailDesignTipo3), context.GetMessage( "O", "")) == 0 )
                        {
                           AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = context.GetMessage( "Otros", "");
                        }
                     }
                  }
               }
            }
         }
         if ( ! ( (0==AV44TFMailDesignId) && (0==AV45TFMailDesignId_To) ) )
         {
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Identificador", "")) ;
            AV14CellRow = GXt_int3;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Number = AV44TFMailDesignId;
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  false, ref  GXt_int3,  (short)(AV15FirstColumn+2),  context.GetMessage( "WWP_TSTo", "")) ;
            AV14CellRow = GXt_int3;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+3, 1, 1).Number = AV45TFMailDesignId_To;
         }
         if ( ! ( ( AV47TFMailDesignTipo_Sels.Count == 0 ) ) )
         {
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Tipo", "")) ;
            AV14CellRow = GXt_int3;
            AV54i = 1;
            AV56GXV1 = 1;
            while ( AV56GXV1 <= AV47TFMailDesignTipo_Sels.Count )
            {
               AV48TFMailDesignTipo_Sel = AV47TFMailDesignTipo_Sels.GetString(AV56GXV1);
               if ( AV54i == 1 )
               {
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = "";
               }
               else
               {
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text+", ";
               }
               if ( StringUtil.StrCmp(StringUtil.Trim( AV48TFMailDesignTipo_Sel), context.GetMessage( "A", "")) == 0 )
               {
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text+context.GetMessage( "Publicidad", "");
               }
               else if ( StringUtil.StrCmp(StringUtil.Trim( AV48TFMailDesignTipo_Sel), context.GetMessage( "R", "")) == 0 )
               {
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text+context.GetMessage( "Recuperar Usuario y Contraseña", "");
               }
               else if ( StringUtil.StrCmp(StringUtil.Trim( AV48TFMailDesignTipo_Sel), context.GetMessage( "N", "")) == 0 )
               {
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text+context.GetMessage( "Notificación", "");
               }
               else if ( StringUtil.StrCmp(StringUtil.Trim( AV48TFMailDesignTipo_Sel), context.GetMessage( "O", "")) == 0 )
               {
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text+context.GetMessage( "Otros", "");
               }
               AV54i = (long)(AV54i+1);
               AV56GXV1 = (int)(AV56GXV1+1);
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV50TFMailDesignAsunto_Sel)) ) )
         {
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Asunto", "")) ;
            AV14CellRow = GXt_int3;
            GXt_char2 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV50TFMailDesignAsunto_Sel)) ? context.GetMessage( "WWP_TitleFilter_EmptyOption", "") : AV50TFMailDesignAsunto_Sel), out  GXt_char2) ;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV49TFMailDesignAsunto)) ) )
            {
               GXt_int3 = (short)(AV14CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Asunto", "")) ;
               AV14CellRow = GXt_int3;
               GXt_char2 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV49TFMailDesignAsunto, out  GXt_char2) ;
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
            }
         }
         if ( ! ( ( AV52TFMailDesignEstado_Sels.Count == 0 ) ) )
         {
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Estado", "")) ;
            AV14CellRow = GXt_int3;
            AV54i = 1;
            AV57GXV2 = 1;
            while ( AV57GXV2 <= AV52TFMailDesignEstado_Sels.Count )
            {
               AV53TFMailDesignEstado_Sel = AV52TFMailDesignEstado_Sels.GetString(AV57GXV2);
               if ( AV54i == 1 )
               {
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = "";
               }
               else
               {
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text+", ";
               }
               if ( StringUtil.StrCmp(StringUtil.Trim( AV53TFMailDesignEstado_Sel), context.GetMessage( "HAB", "")) == 0 )
               {
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text+context.GetMessage( "Habilitado", "");
               }
               else if ( StringUtil.StrCmp(StringUtil.Trim( AV53TFMailDesignEstado_Sel), context.GetMessage( "DES", "")) == 0 )
               {
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text+context.GetMessage( "Deshabilitado", "");
               }
               AV54i = (long)(AV54i+1);
               AV57GXV2 = (int)(AV57GXV2+1);
            }
         }
         AV14CellRow = (int)(AV14CellRow+2);
      }

      protected void S141( )
      {
         /* 'WRITECOLUMNTITLES' Routine */
         returnInSub = false;
         AV41VisibleColumnCount = 0;
         if ( StringUtil.StrCmp(AV29Session.Get("MailDesignWWColumnsSelector"), "") != 0 )
         {
            AV36ColumnsSelectorXML = AV29Session.Get("MailDesignWWColumnsSelector");
            AV33ColumnsSelector.FromXml(AV36ColumnsSelectorXML, null, "", "");
         }
         else
         {
            /* Execute user subroutine: 'INITIALIZECOLUMNSSELECTOR' */
            S151 ();
            if (returnInSub) return;
         }
         AV33ColumnsSelector.gxTpr_Columns.Sort("Order");
         AV58GXV3 = 1;
         while ( AV58GXV3 <= AV33ColumnsSelector.gxTpr_Columns.Count )
         {
            AV35ColumnsSelector_Column = ((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV33ColumnsSelector.gxTpr_Columns.Item(AV58GXV3));
            if ( AV35ColumnsSelector_Column.gxTpr_Isvisible )
            {
               AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV41VisibleColumnCount), 1, 1).Text = context.GetMessage( (String.IsNullOrEmpty(StringUtil.RTrim( AV35ColumnsSelector_Column.gxTpr_Displayname)) ? AV35ColumnsSelector_Column.gxTpr_Columnname : AV35ColumnsSelector_Column.gxTpr_Displayname), "");
               AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV41VisibleColumnCount), 1, 1).Bold = 1;
               AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV41VisibleColumnCount), 1, 1).Color = 11;
               AV41VisibleColumnCount = (long)(AV41VisibleColumnCount+1);
            }
            AV58GXV3 = (int)(AV58GXV3+1);
         }
      }

      protected void S161( )
      {
         /* 'WRITEDATA' Routine */
         returnInSub = false;
         AV60Maildesignwwds_1_filterfulltext = AV19FilterFullText;
         AV61Maildesignwwds_2_dynamicfiltersselector1 = AV20DynamicFiltersSelector1;
         AV62Maildesignwwds_3_maildesigntipo1 = AV21MailDesignTipo1;
         AV63Maildesignwwds_4_dynamicfiltersenabled2 = AV22DynamicFiltersEnabled2;
         AV64Maildesignwwds_5_dynamicfiltersselector2 = AV23DynamicFiltersSelector2;
         AV65Maildesignwwds_6_maildesigntipo2 = AV24MailDesignTipo2;
         AV66Maildesignwwds_7_dynamicfiltersenabled3 = AV25DynamicFiltersEnabled3;
         AV67Maildesignwwds_8_dynamicfiltersselector3 = AV26DynamicFiltersSelector3;
         AV68Maildesignwwds_9_maildesigntipo3 = AV27MailDesignTipo3;
         AV69Maildesignwwds_10_tfmaildesignid = AV44TFMailDesignId;
         AV70Maildesignwwds_11_tfmaildesignid_to = AV45TFMailDesignId_To;
         AV71Maildesignwwds_12_tfmaildesigntipo_sels = AV47TFMailDesignTipo_Sels;
         AV72Maildesignwwds_13_tfmaildesignasunto = AV49TFMailDesignAsunto;
         AV73Maildesignwwds_14_tfmaildesignasunto_sel = AV50TFMailDesignAsunto_Sel;
         AV74Maildesignwwds_15_tfmaildesignestado_sels = AV52TFMailDesignEstado_Sels;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A244MailDesignTipo ,
                                              AV71Maildesignwwds_12_tfmaildesigntipo_sels ,
                                              A245MailDesignEstado ,
                                              AV74Maildesignwwds_15_tfmaildesignestado_sels ,
                                              AV61Maildesignwwds_2_dynamicfiltersselector1 ,
                                              AV62Maildesignwwds_3_maildesigntipo1 ,
                                              AV63Maildesignwwds_4_dynamicfiltersenabled2 ,
                                              AV64Maildesignwwds_5_dynamicfiltersselector2 ,
                                              AV65Maildesignwwds_6_maildesigntipo2 ,
                                              AV66Maildesignwwds_7_dynamicfiltersenabled3 ,
                                              AV67Maildesignwwds_8_dynamicfiltersselector3 ,
                                              AV68Maildesignwwds_9_maildesigntipo3 ,
                                              AV69Maildesignwwds_10_tfmaildesignid ,
                                              AV70Maildesignwwds_11_tfmaildesignid_to ,
                                              AV71Maildesignwwds_12_tfmaildesigntipo_sels.Count ,
                                              AV73Maildesignwwds_14_tfmaildesignasunto_sel ,
                                              AV72Maildesignwwds_13_tfmaildesignasunto ,
                                              AV74Maildesignwwds_15_tfmaildesignestado_sels.Count ,
                                              A148MailDesignId ,
                                              A246MailDesignAsunto ,
                                              AV17OrderedBy ,
                                              AV18OrderedDsc ,
                                              AV60Maildesignwwds_1_filterfulltext } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.INT, TypeConstants.INT, TypeConstants.LONG, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV72Maildesignwwds_13_tfmaildesignasunto = StringUtil.PadR( StringUtil.RTrim( AV72Maildesignwwds_13_tfmaildesignasunto), 80, "%");
         /* Using cursor P00BJ2 */
         pr_default.execute(0, new Object[] {AV62Maildesignwwds_3_maildesigntipo1, AV65Maildesignwwds_6_maildesigntipo2, AV68Maildesignwwds_9_maildesigntipo3, AV69Maildesignwwds_10_tfmaildesignid, AV70Maildesignwwds_11_tfmaildesignid_to, lV72Maildesignwwds_13_tfmaildesignasunto, AV73Maildesignwwds_14_tfmaildesignasunto_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A246MailDesignAsunto = P00BJ2_A246MailDesignAsunto[0];
            A148MailDesignId = P00BJ2_A148MailDesignId[0];
            A245MailDesignEstado = P00BJ2_A245MailDesignEstado[0];
            A244MailDesignTipo = P00BJ2_A244MailDesignTipo[0];
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV60Maildesignwwds_1_filterfulltext)) || ( ( StringUtil.Like( StringUtil.Str( (decimal)(A148MailDesignId), 18, 0) , StringUtil.PadR( "%" + AV60Maildesignwwds_1_filterfulltext , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( context.GetMessage( "publicidad", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV60Maildesignwwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A244MailDesignTipo, "A") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "recuperar usuario y contraseña", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV60Maildesignwwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A244MailDesignTipo, "R") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "notificación", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV60Maildesignwwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A244MailDesignTipo, "N") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "otros", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV60Maildesignwwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A244MailDesignTipo, "O") == 0 ) ) || ( StringUtil.Like( StringUtil.Upper( A246MailDesignAsunto) , StringUtil.PadR( "%" + StringUtil.Upper( AV60Maildesignwwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( context.GetMessage( "habilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV60Maildesignwwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A245MailDesignEstado, "HAB") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "deshabilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV60Maildesignwwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A245MailDesignEstado, "DES") == 0 ) ) ) )
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
               AV41VisibleColumnCount = 0;
               AV75GXV4 = 1;
               while ( AV75GXV4 <= AV33ColumnsSelector.gxTpr_Columns.Count )
               {
                  AV35ColumnsSelector_Column = ((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV33ColumnsSelector.gxTpr_Columns.Item(AV75GXV4));
                  if ( AV35ColumnsSelector_Column.gxTpr_Isvisible )
                  {
                     if ( StringUtil.StrCmp(AV35ColumnsSelector_Column.gxTpr_Columnname, "MailDesignId") == 0 )
                     {
                        AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV41VisibleColumnCount), 1, 1).Number = A148MailDesignId;
                     }
                     else if ( StringUtil.StrCmp(AV35ColumnsSelector_Column.gxTpr_Columnname, "MailDesignTipo") == 0 )
                     {
                        AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV41VisibleColumnCount), 1, 1).Text = "";
                        if ( StringUtil.StrCmp(StringUtil.Trim( A244MailDesignTipo), context.GetMessage( "A", "")) == 0 )
                        {
                           AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV41VisibleColumnCount), 1, 1).Text = context.GetMessage( "Publicidad", "");
                        }
                        else if ( StringUtil.StrCmp(StringUtil.Trim( A244MailDesignTipo), context.GetMessage( "R", "")) == 0 )
                        {
                           AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV41VisibleColumnCount), 1, 1).Text = context.GetMessage( "Recuperar Usuario y Contraseña", "");
                        }
                        else if ( StringUtil.StrCmp(StringUtil.Trim( A244MailDesignTipo), context.GetMessage( "N", "")) == 0 )
                        {
                           AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV41VisibleColumnCount), 1, 1).Text = context.GetMessage( "Notificación", "");
                        }
                        else if ( StringUtil.StrCmp(StringUtil.Trim( A244MailDesignTipo), context.GetMessage( "O", "")) == 0 )
                        {
                           AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV41VisibleColumnCount), 1, 1).Text = context.GetMessage( "Otros", "");
                        }
                     }
                     else if ( StringUtil.StrCmp(AV35ColumnsSelector_Column.gxTpr_Columnname, "MailDesignAsunto") == 0 )
                     {
                        GXt_char2 = "";
                        new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A246MailDesignAsunto, out  GXt_char2) ;
                        AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV41VisibleColumnCount), 1, 1).Text = GXt_char2;
                     }
                     else if ( StringUtil.StrCmp(AV35ColumnsSelector_Column.gxTpr_Columnname, "MailDesignEstado") == 0 )
                     {
                        AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV41VisibleColumnCount), 1, 1).Text = "";
                        if ( StringUtil.StrCmp(StringUtil.Trim( A245MailDesignEstado), context.GetMessage( "HAB", "")) == 0 )
                        {
                           AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV41VisibleColumnCount), 1, 1).Text = context.GetMessage( "Habilitado", "");
                        }
                        else if ( StringUtil.StrCmp(StringUtil.Trim( A245MailDesignEstado), context.GetMessage( "DES", "")) == 0 )
                        {
                           AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV41VisibleColumnCount), 1, 1).Text = context.GetMessage( "Deshabilitado", "");
                        }
                     }
                     AV41VisibleColumnCount = (long)(AV41VisibleColumnCount+1);
                  }
                  AV75GXV4 = (int)(AV75GXV4+1);
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
         AV29Session.Set("WWPExportFilePath", AV12Filename);
         AV29Session.Set("WWPExportFileName", "MailDesignWWExport.xlsx");
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
         AV33ColumnsSelector = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector(context);
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV33ColumnsSelector,  "MailDesignId",  "",  "Identificador",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV33ColumnsSelector,  "MailDesignTipo",  "",  "Tipo",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV33ColumnsSelector,  "MailDesignAsunto",  "",  "Asunto",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV33ColumnsSelector,  "MailDesignEstado",  "",  "Estado",  true,  "") ;
         GXt_char2 = AV37UserCustomValue;
         new GeneXus.Programs.wwpbaseobjects.loadcolumnsselectorstate(context ).execute(  "MailDesignWWColumnsSelector", out  GXt_char2) ;
         AV37UserCustomValue = GXt_char2;
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV37UserCustomValue)) ) )
         {
            AV34ColumnsSelectorAux.FromXml(AV37UserCustomValue, null, "", "");
            new GeneXus.Programs.wwpbaseobjects.wwp_columnselector_updatecolumns(context ).execute( ref  AV34ColumnsSelectorAux, ref  AV33ColumnsSelector) ;
         }
      }

      protected void S201( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV29Session.Get("MailDesignWWGridState"), "") == 0 )
         {
            AV31GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "MailDesignWWGridState"), null, "", "");
         }
         else
         {
            AV31GridState.FromXml(AV29Session.Get("MailDesignWWGridState"), null, "", "");
         }
         AV17OrderedBy = AV31GridState.gxTpr_Orderedby;
         AV18OrderedDsc = AV31GridState.gxTpr_Ordereddsc;
         AV76GXV5 = 1;
         while ( AV76GXV5 <= AV31GridState.gxTpr_Filtervalues.Count )
         {
            AV32GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV31GridState.gxTpr_Filtervalues.Item(AV76GXV5));
            if ( StringUtil.StrCmp(AV32GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV19FilterFullText = AV32GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV32GridStateFilterValue.gxTpr_Name, "TFMAILDESIGNID") == 0 )
            {
               AV44TFMailDesignId = (long)(Math.Round(NumberUtil.Val( AV32GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV45TFMailDesignId_To = (long)(Math.Round(NumberUtil.Val( AV32GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV32GridStateFilterValue.gxTpr_Name, "TFMAILDESIGNTIPO_SEL") == 0 )
            {
               AV46TFMailDesignTipo_SelsJson = AV32GridStateFilterValue.gxTpr_Value;
               AV47TFMailDesignTipo_Sels.FromJSonString(AV46TFMailDesignTipo_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV32GridStateFilterValue.gxTpr_Name, "TFMAILDESIGNASUNTO") == 0 )
            {
               AV49TFMailDesignAsunto = AV32GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV32GridStateFilterValue.gxTpr_Name, "TFMAILDESIGNASUNTO_SEL") == 0 )
            {
               AV50TFMailDesignAsunto_Sel = AV32GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV32GridStateFilterValue.gxTpr_Name, "TFMAILDESIGNESTADO_SEL") == 0 )
            {
               AV51TFMailDesignEstado_SelsJson = AV32GridStateFilterValue.gxTpr_Value;
               AV52TFMailDesignEstado_Sels.FromJSonString(AV51TFMailDesignEstado_SelsJson, null);
            }
            AV76GXV5 = (int)(AV76GXV5+1);
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
         AV55Pgmname = "";
         GXKey = "";
         GXEncryptionTmp = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV11ExcelDocument = new ExcelDocumentI();
         AV19FilterFullText = "";
         AV31GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV28GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV20DynamicFiltersSelector1 = "";
         AV21MailDesignTipo1 = "";
         AV23DynamicFiltersSelector2 = "";
         AV24MailDesignTipo2 = "";
         AV26DynamicFiltersSelector3 = "";
         AV27MailDesignTipo3 = "";
         AV47TFMailDesignTipo_Sels = new GxSimpleCollection<string>();
         AV48TFMailDesignTipo_Sel = "";
         AV50TFMailDesignAsunto_Sel = "";
         AV49TFMailDesignAsunto = "";
         AV52TFMailDesignEstado_Sels = new GxSimpleCollection<string>();
         AV53TFMailDesignEstado_Sel = "";
         AV29Session = context.GetSession();
         AV36ColumnsSelectorXML = "";
         AV33ColumnsSelector = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector(context);
         AV35ColumnsSelector_Column = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column(context);
         AV60Maildesignwwds_1_filterfulltext = "";
         AV61Maildesignwwds_2_dynamicfiltersselector1 = "";
         AV62Maildesignwwds_3_maildesigntipo1 = "";
         AV64Maildesignwwds_5_dynamicfiltersselector2 = "";
         AV65Maildesignwwds_6_maildesigntipo2 = "";
         AV67Maildesignwwds_8_dynamicfiltersselector3 = "";
         AV68Maildesignwwds_9_maildesigntipo3 = "";
         AV71Maildesignwwds_12_tfmaildesigntipo_sels = new GxSimpleCollection<string>();
         AV72Maildesignwwds_13_tfmaildesignasunto = "";
         AV73Maildesignwwds_14_tfmaildesignasunto_sel = "";
         AV74Maildesignwwds_15_tfmaildesignestado_sels = new GxSimpleCollection<string>();
         lV72Maildesignwwds_13_tfmaildesignasunto = "";
         A244MailDesignTipo = "";
         A245MailDesignEstado = "";
         A246MailDesignAsunto = "";
         P00BJ2_A246MailDesignAsunto = new string[] {""} ;
         P00BJ2_A148MailDesignId = new long[1] ;
         P00BJ2_A245MailDesignEstado = new string[] {""} ;
         P00BJ2_A244MailDesignTipo = new string[] {""} ;
         AV37UserCustomValue = "";
         GXt_char2 = "";
         AV34ColumnsSelectorAux = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector(context);
         AV32GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV46TFMailDesignTipo_SelsJson = "";
         AV51TFMailDesignEstado_SelsJson = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.maildesignwwexport__default(),
            new Object[][] {
                new Object[] {
               P00BJ2_A246MailDesignAsunto, P00BJ2_A148MailDesignId, P00BJ2_A245MailDesignEstado, P00BJ2_A244MailDesignTipo
               }
            }
         );
         AV55Pgmname = "MailDesignWWExport";
         /* GeneXus formulas. */
         AV55Pgmname = "MailDesignWWExport";
      }

      private short GXt_int3 ;
      private short AV17OrderedBy ;
      private int AV14CellRow ;
      private int AV15FirstColumn ;
      private int AV16Random ;
      private int AV56GXV1 ;
      private int AV57GXV2 ;
      private int AV58GXV3 ;
      private int AV71Maildesignwwds_12_tfmaildesigntipo_sels_Count ;
      private int AV74Maildesignwwds_15_tfmaildesignestado_sels_Count ;
      private int AV75GXV4 ;
      private int AV76GXV5 ;
      private long AV44TFMailDesignId ;
      private long AV45TFMailDesignId_To ;
      private long AV54i ;
      private long AV41VisibleColumnCount ;
      private long AV69Maildesignwwds_10_tfmaildesignid ;
      private long AV70Maildesignwwds_11_tfmaildesignid_to ;
      private long A148MailDesignId ;
      private string AV55Pgmname ;
      private string GXKey ;
      private string GXEncryptionTmp ;
      private string AV21MailDesignTipo1 ;
      private string AV24MailDesignTipo2 ;
      private string AV27MailDesignTipo3 ;
      private string AV48TFMailDesignTipo_Sel ;
      private string AV50TFMailDesignAsunto_Sel ;
      private string AV49TFMailDesignAsunto ;
      private string AV53TFMailDesignEstado_Sel ;
      private string AV62Maildesignwwds_3_maildesigntipo1 ;
      private string AV65Maildesignwwds_6_maildesigntipo2 ;
      private string AV68Maildesignwwds_9_maildesigntipo3 ;
      private string AV72Maildesignwwds_13_tfmaildesignasunto ;
      private string AV73Maildesignwwds_14_tfmaildesignasunto_sel ;
      private string lV72Maildesignwwds_13_tfmaildesignasunto ;
      private string A244MailDesignTipo ;
      private string A245MailDesignEstado ;
      private string A246MailDesignAsunto ;
      private string GXt_char2 ;
      private bool AV8IsAuthorized ;
      private bool GXt_boolean1 ;
      private bool returnInSub ;
      private bool AV22DynamicFiltersEnabled2 ;
      private bool AV25DynamicFiltersEnabled3 ;
      private bool AV63Maildesignwwds_4_dynamicfiltersenabled2 ;
      private bool AV66Maildesignwwds_7_dynamicfiltersenabled3 ;
      private bool AV18OrderedDsc ;
      private string AV36ColumnsSelectorXML ;
      private string AV37UserCustomValue ;
      private string AV46TFMailDesignTipo_SelsJson ;
      private string AV51TFMailDesignEstado_SelsJson ;
      private string AV12Filename ;
      private string AV13ErrorMessage ;
      private string AV19FilterFullText ;
      private string AV20DynamicFiltersSelector1 ;
      private string AV23DynamicFiltersSelector2 ;
      private string AV26DynamicFiltersSelector3 ;
      private string AV60Maildesignwwds_1_filterfulltext ;
      private string AV61Maildesignwwds_2_dynamicfiltersselector1 ;
      private string AV64Maildesignwwds_5_dynamicfiltersselector2 ;
      private string AV67Maildesignwwds_8_dynamicfiltersselector3 ;
      private IGxSession AV29Session ;
      private ExcelDocumentI AV11ExcelDocument ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV31GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV28GridStateDynamicFilter ;
      private GxSimpleCollection<string> AV47TFMailDesignTipo_Sels ;
      private GxSimpleCollection<string> AV52TFMailDesignEstado_Sels ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector AV33ColumnsSelector ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column AV35ColumnsSelector_Column ;
      private GxSimpleCollection<string> AV71Maildesignwwds_12_tfmaildesigntipo_sels ;
      private GxSimpleCollection<string> AV74Maildesignwwds_15_tfmaildesignestado_sels ;
      private IDataStoreProvider pr_default ;
      private string[] P00BJ2_A246MailDesignAsunto ;
      private long[] P00BJ2_A148MailDesignId ;
      private string[] P00BJ2_A245MailDesignEstado ;
      private string[] P00BJ2_A244MailDesignTipo ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector AV34ColumnsSelectorAux ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV32GridStateFilterValue ;
      private string aP0_Filename ;
      private string aP1_ErrorMessage ;
   }

   public class maildesignwwexport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00BJ2( IGxContext context ,
                                             string A244MailDesignTipo ,
                                             GxSimpleCollection<string> AV71Maildesignwwds_12_tfmaildesigntipo_sels ,
                                             string A245MailDesignEstado ,
                                             GxSimpleCollection<string> AV74Maildesignwwds_15_tfmaildesignestado_sels ,
                                             string AV61Maildesignwwds_2_dynamicfiltersselector1 ,
                                             string AV62Maildesignwwds_3_maildesigntipo1 ,
                                             bool AV63Maildesignwwds_4_dynamicfiltersenabled2 ,
                                             string AV64Maildesignwwds_5_dynamicfiltersselector2 ,
                                             string AV65Maildesignwwds_6_maildesigntipo2 ,
                                             bool AV66Maildesignwwds_7_dynamicfiltersenabled3 ,
                                             string AV67Maildesignwwds_8_dynamicfiltersselector3 ,
                                             string AV68Maildesignwwds_9_maildesigntipo3 ,
                                             long AV69Maildesignwwds_10_tfmaildesignid ,
                                             long AV70Maildesignwwds_11_tfmaildesignid_to ,
                                             int AV71Maildesignwwds_12_tfmaildesigntipo_sels_Count ,
                                             string AV73Maildesignwwds_14_tfmaildesignasunto_sel ,
                                             string AV72Maildesignwwds_13_tfmaildesignasunto ,
                                             int AV74Maildesignwwds_15_tfmaildesignestado_sels_Count ,
                                             long A148MailDesignId ,
                                             string A246MailDesignAsunto ,
                                             short AV17OrderedBy ,
                                             bool AV18OrderedDsc ,
                                             string AV60Maildesignwwds_1_filterfulltext )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int4 = new short[7];
         Object[] GXv_Object5 = new Object[2];
         scmdbuf = "SELECT [MailDesignAsunto], [MailDesignId], [MailDesignEstado], [MailDesignTipo] FROM [MailDesign]";
         if ( ( StringUtil.StrCmp(AV61Maildesignwwds_2_dynamicfiltersselector1, "MAILDESIGNTIPO") == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Maildesignwwds_3_maildesigntipo1)) ) )
         {
            AddWhere(sWhereString, "([MailDesignTipo] = @AV62Maildesignwwds_3_maildesigntipo1)");
         }
         else
         {
            GXv_int4[0] = 1;
         }
         if ( AV63Maildesignwwds_4_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV64Maildesignwwds_5_dynamicfiltersselector2, "MAILDESIGNTIPO") == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Maildesignwwds_6_maildesigntipo2)) ) )
         {
            AddWhere(sWhereString, "([MailDesignTipo] = @AV65Maildesignwwds_6_maildesigntipo2)");
         }
         else
         {
            GXv_int4[1] = 1;
         }
         if ( AV66Maildesignwwds_7_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV67Maildesignwwds_8_dynamicfiltersselector3, "MAILDESIGNTIPO") == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Maildesignwwds_9_maildesigntipo3)) ) )
         {
            AddWhere(sWhereString, "([MailDesignTipo] = @AV68Maildesignwwds_9_maildesigntipo3)");
         }
         else
         {
            GXv_int4[2] = 1;
         }
         if ( ! (0==AV69Maildesignwwds_10_tfmaildesignid) )
         {
            AddWhere(sWhereString, "([MailDesignId] >= @AV69Maildesignwwds_10_tfmaildesignid)");
         }
         else
         {
            GXv_int4[3] = 1;
         }
         if ( ! (0==AV70Maildesignwwds_11_tfmaildesignid_to) )
         {
            AddWhere(sWhereString, "([MailDesignId] <= @AV70Maildesignwwds_11_tfmaildesignid_to)");
         }
         else
         {
            GXv_int4[4] = 1;
         }
         if ( AV71Maildesignwwds_12_tfmaildesigntipo_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV71Maildesignwwds_12_tfmaildesigntipo_sels, "[MailDesignTipo] IN (", ")")+")");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV73Maildesignwwds_14_tfmaildesignasunto_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Maildesignwwds_13_tfmaildesignasunto)) ) )
         {
            AddWhere(sWhereString, "(UPPER([MailDesignAsunto]) like UPPER(@lV72Maildesignwwds_13_tfmaildesignasunto))");
         }
         else
         {
            GXv_int4[5] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Maildesignwwds_14_tfmaildesignasunto_sel)) && ! ( StringUtil.StrCmp(AV73Maildesignwwds_14_tfmaildesignasunto_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([MailDesignAsunto] = @AV73Maildesignwwds_14_tfmaildesignasunto_sel)");
         }
         else
         {
            GXv_int4[6] = 1;
         }
         if ( StringUtil.StrCmp(AV73Maildesignwwds_14_tfmaildesignasunto_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([MailDesignAsunto] = ''))");
         }
         if ( AV74Maildesignwwds_15_tfmaildesignestado_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV74Maildesignwwds_15_tfmaildesignestado_sels, "[MailDesignEstado] IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         if ( ( AV17OrderedBy == 1 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY [MailDesignTipo]";
         }
         else if ( ( AV17OrderedBy == 1 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [MailDesignTipo] DESC";
         }
         else if ( ( AV17OrderedBy == 2 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY [MailDesignId]";
         }
         else if ( ( AV17OrderedBy == 2 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [MailDesignId] DESC";
         }
         else if ( ( AV17OrderedBy == 3 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY [MailDesignAsunto]";
         }
         else if ( ( AV17OrderedBy == 3 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [MailDesignAsunto] DESC";
         }
         else if ( ( AV17OrderedBy == 4 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY [MailDesignEstado]";
         }
         else if ( ( AV17OrderedBy == 4 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [MailDesignEstado] DESC";
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
                     return conditional_P00BJ2(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (GxSimpleCollection<string>)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (bool)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (bool)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (long)dynConstraints[12] , (long)dynConstraints[13] , (int)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (int)dynConstraints[17] , (long)dynConstraints[18] , (string)dynConstraints[19] , (short)dynConstraints[20] , (bool)dynConstraints[21] , (string)dynConstraints[22] );
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
          Object[] prmP00BJ2;
          prmP00BJ2 = new Object[] {
          new ParDef("@AV62Maildesignwwds_3_maildesigntipo1",GXType.NChar,1,0) ,
          new ParDef("@AV65Maildesignwwds_6_maildesigntipo2",GXType.NChar,1,0) ,
          new ParDef("@AV68Maildesignwwds_9_maildesigntipo3",GXType.NChar,1,0) ,
          new ParDef("@AV69Maildesignwwds_10_tfmaildesignid",GXType.Decimal,18,0) ,
          new ParDef("@AV70Maildesignwwds_11_tfmaildesignid_to",GXType.Decimal,18,0) ,
          new ParDef("@lV72Maildesignwwds_13_tfmaildesignasunto",GXType.Char,80,0) ,
          new ParDef("@AV73Maildesignwwds_14_tfmaildesignasunto_sel",GXType.NChar,80,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00BJ2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00BJ2,100, GxCacheFrequency.OFF ,true,false )
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

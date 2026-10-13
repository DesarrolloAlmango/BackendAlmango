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
   public class documentacionwwexport : GXProcedure
   {
      public documentacionwwexport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public documentacionwwexport( IGxContext context )
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
         new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWDocumentacion", out  GXt_boolean1) ;
         AV8IsAuthorized = GXt_boolean1;
         if ( ! AV8IsAuthorized )
         {
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "wwpbaseobjects.notauthorized.aspx"+GXUtil.UrlEncode(StringUtil.RTrim(AV49Pgmname));
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
         AV12Filename = GXt_char2 + "DocumentacionWWExport-" + StringUtil.Trim( StringUtil.Str( (decimal)(AV16Random), 8, 0)) + ".xlsx";
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
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV18FilterFullText)) ) )
         {
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "WWP_FullTextFilterDescription", "")) ;
            AV14CellRow = GXt_int3;
            GXt_char2 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV18FilterFullText, out  GXt_char2) ;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
         }
         if ( AV33GridState.gxTpr_Dynamicfilters.Count >= 1 )
         {
            AV30GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV33GridState.gxTpr_Dynamicfilters.Item(1));
            AV19DynamicFiltersSelector1 = AV30GridStateDynamicFilter.gxTpr_Selected;
            if ( StringUtil.StrCmp(AV19DynamicFiltersSelector1, "DOCUMENTACIONNOMBRE") == 0 )
            {
               AV20DynamicFiltersOperator1 = AV30GridStateDynamicFilter.gxTpr_Operator;
               AV21DocumentacionNombre1 = AV30GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV21DocumentacionNombre1)) )
               {
                  AV14CellRow = (int)(AV14CellRow+1);
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Bold = 1;
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Color = 3;
                  if ( AV20DynamicFiltersOperator1 == 0 )
                  {
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", context.GetMessage( "Nombre del Documento", ""), context.GetMessage( "WWP_FilterLike", ""), "", "", "", "", "", "", "");
                  }
                  else if ( AV20DynamicFiltersOperator1 == 1 )
                  {
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", context.GetMessage( "Nombre del Documento", ""), context.GetMessage( "WWP_FilterContains", ""), "", "", "", "", "", "", "");
                  }
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Italic = 1;
                  GXt_char2 = "";
                  new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV21DocumentacionNombre1, out  GXt_char2) ;
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
               }
            }
            if ( AV33GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV22DynamicFiltersEnabled2 = true;
               AV30GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV33GridState.gxTpr_Dynamicfilters.Item(2));
               AV23DynamicFiltersSelector2 = AV30GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV23DynamicFiltersSelector2, "DOCUMENTACIONNOMBRE") == 0 )
               {
                  AV24DynamicFiltersOperator2 = AV30GridStateDynamicFilter.gxTpr_Operator;
                  AV25DocumentacionNombre2 = AV30GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV25DocumentacionNombre2)) )
                  {
                     AV14CellRow = (int)(AV14CellRow+1);
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Bold = 1;
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Color = 3;
                     if ( AV24DynamicFiltersOperator2 == 0 )
                     {
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", context.GetMessage( "Nombre del Documento", ""), context.GetMessage( "WWP_FilterLike", ""), "", "", "", "", "", "", "");
                     }
                     else if ( AV24DynamicFiltersOperator2 == 1 )
                     {
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", context.GetMessage( "Nombre del Documento", ""), context.GetMessage( "WWP_FilterContains", ""), "", "", "", "", "", "", "");
                     }
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Italic = 1;
                     GXt_char2 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV25DocumentacionNombre2, out  GXt_char2) ;
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
                  }
               }
               if ( AV33GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV26DynamicFiltersEnabled3 = true;
                  AV30GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV33GridState.gxTpr_Dynamicfilters.Item(3));
                  AV27DynamicFiltersSelector3 = AV30GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV27DynamicFiltersSelector3, "DOCUMENTACIONNOMBRE") == 0 )
                  {
                     AV28DynamicFiltersOperator3 = AV30GridStateDynamicFilter.gxTpr_Operator;
                     AV29DocumentacionNombre3 = AV30GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV29DocumentacionNombre3)) )
                     {
                        AV14CellRow = (int)(AV14CellRow+1);
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Bold = 1;
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Color = 3;
                        if ( AV28DynamicFiltersOperator3 == 0 )
                        {
                           AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", context.GetMessage( "Nombre del Documento", ""), context.GetMessage( "WWP_FilterLike", ""), "", "", "", "", "", "", "");
                        }
                        else if ( AV28DynamicFiltersOperator3 == 1 )
                        {
                           AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", context.GetMessage( "Nombre del Documento", ""), context.GetMessage( "WWP_FilterContains", ""), "", "", "", "", "", "", "");
                        }
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Italic = 1;
                        GXt_char2 = "";
                        new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV29DocumentacionNombre3, out  GXt_char2) ;
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
                     }
                  }
               }
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV47TFDocumentacionNombre_Sel)) ) )
         {
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Nombre del Documento", "")) ;
            AV14CellRow = GXt_int3;
            GXt_char2 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV47TFDocumentacionNombre_Sel)) ? context.GetMessage( "WWP_TitleFilter_EmptyOption", "") : AV47TFDocumentacionNombre_Sel), out  GXt_char2) ;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV46TFDocumentacionNombre)) ) )
            {
               GXt_int3 = (short)(AV14CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Nombre del Documento", "")) ;
               AV14CellRow = GXt_int3;
               GXt_char2 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV46TFDocumentacionNombre, out  GXt_char2) ;
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
            }
         }
         AV14CellRow = (int)(AV14CellRow+2);
      }

      protected void S141( )
      {
         /* 'WRITECOLUMNTITLES' Routine */
         returnInSub = false;
         AV43VisibleColumnCount = 0;
         if ( StringUtil.StrCmp(AV31Session.Get("DocumentacionWWColumnsSelector"), "") != 0 )
         {
            AV38ColumnsSelectorXML = AV31Session.Get("DocumentacionWWColumnsSelector");
            AV35ColumnsSelector.FromXml(AV38ColumnsSelectorXML, null, "", "");
         }
         else
         {
            /* Execute user subroutine: 'INITIALIZECOLUMNSSELECTOR' */
            S151 ();
            if (returnInSub) return;
         }
         AV35ColumnsSelector.gxTpr_Columns.Sort("Order");
         AV50GXV1 = 1;
         while ( AV50GXV1 <= AV35ColumnsSelector.gxTpr_Columns.Count )
         {
            AV37ColumnsSelector_Column = ((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV35ColumnsSelector.gxTpr_Columns.Item(AV50GXV1));
            if ( AV37ColumnsSelector_Column.gxTpr_Isvisible )
            {
               AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV43VisibleColumnCount), 1, 1).Text = context.GetMessage( (String.IsNullOrEmpty(StringUtil.RTrim( AV37ColumnsSelector_Column.gxTpr_Displayname)) ? AV37ColumnsSelector_Column.gxTpr_Columnname : AV37ColumnsSelector_Column.gxTpr_Displayname), "");
               AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV43VisibleColumnCount), 1, 1).Bold = 1;
               AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV43VisibleColumnCount), 1, 1).Color = 11;
               AV43VisibleColumnCount = (long)(AV43VisibleColumnCount+1);
            }
            AV50GXV1 = (int)(AV50GXV1+1);
         }
      }

      protected void S161( )
      {
         /* 'WRITEDATA' Routine */
         returnInSub = false;
         AV52Documentacionwwds_1_filterfulltext = AV18FilterFullText;
         AV53Documentacionwwds_2_dynamicfiltersselector1 = AV19DynamicFiltersSelector1;
         AV54Documentacionwwds_3_dynamicfiltersoperator1 = AV20DynamicFiltersOperator1;
         AV55Documentacionwwds_4_documentacionnombre1 = AV21DocumentacionNombre1;
         AV56Documentacionwwds_5_dynamicfiltersenabled2 = AV22DynamicFiltersEnabled2;
         AV57Documentacionwwds_6_dynamicfiltersselector2 = AV23DynamicFiltersSelector2;
         AV58Documentacionwwds_7_dynamicfiltersoperator2 = AV24DynamicFiltersOperator2;
         AV59Documentacionwwds_8_documentacionnombre2 = AV25DocumentacionNombre2;
         AV60Documentacionwwds_9_dynamicfiltersenabled3 = AV26DynamicFiltersEnabled3;
         AV61Documentacionwwds_10_dynamicfiltersselector3 = AV27DynamicFiltersSelector3;
         AV62Documentacionwwds_11_dynamicfiltersoperator3 = AV28DynamicFiltersOperator3;
         AV63Documentacionwwds_12_documentacionnombre3 = AV29DocumentacionNombre3;
         AV64Documentacionwwds_13_tfdocumentacionnombre = AV46TFDocumentacionNombre;
         AV65Documentacionwwds_14_tfdocumentacionnombre_sel = AV47TFDocumentacionNombre_Sel;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV52Documentacionwwds_1_filterfulltext ,
                                              AV53Documentacionwwds_2_dynamicfiltersselector1 ,
                                              AV54Documentacionwwds_3_dynamicfiltersoperator1 ,
                                              AV55Documentacionwwds_4_documentacionnombre1 ,
                                              AV56Documentacionwwds_5_dynamicfiltersenabled2 ,
                                              AV57Documentacionwwds_6_dynamicfiltersselector2 ,
                                              AV58Documentacionwwds_7_dynamicfiltersoperator2 ,
                                              AV59Documentacionwwds_8_documentacionnombre2 ,
                                              AV60Documentacionwwds_9_dynamicfiltersenabled3 ,
                                              AV61Documentacionwwds_10_dynamicfiltersselector3 ,
                                              AV62Documentacionwwds_11_dynamicfiltersoperator3 ,
                                              AV63Documentacionwwds_12_documentacionnombre3 ,
                                              AV65Documentacionwwds_14_tfdocumentacionnombre_sel ,
                                              AV64Documentacionwwds_13_tfdocumentacionnombre ,
                                              A489DocumentacionNombre ,
                                              AV17OrderedDsc } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV52Documentacionwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV52Documentacionwwds_1_filterfulltext), "%", "");
         lV55Documentacionwwds_4_documentacionnombre1 = StringUtil.PadR( StringUtil.RTrim( AV55Documentacionwwds_4_documentacionnombre1), 80, "%");
         lV55Documentacionwwds_4_documentacionnombre1 = StringUtil.PadR( StringUtil.RTrim( AV55Documentacionwwds_4_documentacionnombre1), 80, "%");
         lV59Documentacionwwds_8_documentacionnombre2 = StringUtil.PadR( StringUtil.RTrim( AV59Documentacionwwds_8_documentacionnombre2), 80, "%");
         lV59Documentacionwwds_8_documentacionnombre2 = StringUtil.PadR( StringUtil.RTrim( AV59Documentacionwwds_8_documentacionnombre2), 80, "%");
         lV63Documentacionwwds_12_documentacionnombre3 = StringUtil.PadR( StringUtil.RTrim( AV63Documentacionwwds_12_documentacionnombre3), 80, "%");
         lV63Documentacionwwds_12_documentacionnombre3 = StringUtil.PadR( StringUtil.RTrim( AV63Documentacionwwds_12_documentacionnombre3), 80, "%");
         lV64Documentacionwwds_13_tfdocumentacionnombre = StringUtil.PadR( StringUtil.RTrim( AV64Documentacionwwds_13_tfdocumentacionnombre), 80, "%");
         /* Using cursor P00692 */
         pr_default.execute(0, new Object[] {lV52Documentacionwwds_1_filterfulltext, lV55Documentacionwwds_4_documentacionnombre1, lV55Documentacionwwds_4_documentacionnombre1, lV59Documentacionwwds_8_documentacionnombre2, lV59Documentacionwwds_8_documentacionnombre2, lV63Documentacionwwds_12_documentacionnombre3, lV63Documentacionwwds_12_documentacionnombre3, lV64Documentacionwwds_13_tfdocumentacionnombre, AV65Documentacionwwds_14_tfdocumentacionnombre_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A489DocumentacionNombre = P00692_A489DocumentacionNombre[0];
            A488DocumentacionId = P00692_A488DocumentacionId[0];
            AV14CellRow = (int)(AV14CellRow+1);
            /* Execute user subroutine: 'BEFOREWRITELINE' */
            S172 ();
            if ( returnInSub )
            {
               pr_default.close(0);
               returnInSub = true;
               if (true) return;
            }
            AV43VisibleColumnCount = 0;
            AV66GXV2 = 1;
            while ( AV66GXV2 <= AV35ColumnsSelector.gxTpr_Columns.Count )
            {
               AV37ColumnsSelector_Column = ((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV35ColumnsSelector.gxTpr_Columns.Item(AV66GXV2));
               if ( AV37ColumnsSelector_Column.gxTpr_Isvisible )
               {
                  if ( StringUtil.StrCmp(AV37ColumnsSelector_Column.gxTpr_Columnname, "DocumentacionNombre") == 0 )
                  {
                     GXt_char2 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A489DocumentacionNombre, out  GXt_char2) ;
                     AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV43VisibleColumnCount), 1, 1).Text = GXt_char2;
                  }
                  else if ( StringUtil.StrCmp(AV37ColumnsSelector_Column.gxTpr_Columnname, "DocumentacionIcono") == 0 )
                  {
                     AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV43VisibleColumnCount), 1, 1).Text = "";
                  }
                  AV43VisibleColumnCount = (long)(AV43VisibleColumnCount+1);
               }
               AV66GXV2 = (int)(AV66GXV2+1);
            }
            /* Execute user subroutine: 'AFTERWRITELINE' */
            S182 ();
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

      protected void S191( )
      {
         /* 'CLOSEDOCUMENT' Routine */
         returnInSub = false;
         AV11ExcelDocument.Save();
         /* Execute user subroutine: 'CHECKSTATUS' */
         S121 ();
         if (returnInSub) return;
         AV11ExcelDocument.Close();
         AV31Session.Set("WWPExportFilePath", AV12Filename);
         AV31Session.Set("WWPExportFileName", "DocumentacionWWExport.xlsx");
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
         AV35ColumnsSelector = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector(context);
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV35ColumnsSelector,  "DocumentacionNombre",  "",  "Nombre del Documento",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV35ColumnsSelector,  "DocumentacionIcono",  "",  "Icono",  true,  "") ;
         GXt_char2 = AV39UserCustomValue;
         new GeneXus.Programs.wwpbaseobjects.loadcolumnsselectorstate(context ).execute(  "DocumentacionWWColumnsSelector", out  GXt_char2) ;
         AV39UserCustomValue = GXt_char2;
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV39UserCustomValue)) ) )
         {
            AV36ColumnsSelectorAux.FromXml(AV39UserCustomValue, null, "", "");
            new GeneXus.Programs.wwpbaseobjects.wwp_columnselector_updatecolumns(context ).execute( ref  AV36ColumnsSelectorAux, ref  AV35ColumnsSelector) ;
         }
      }

      protected void S201( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV31Session.Get("DocumentacionWWGridState"), "") == 0 )
         {
            AV33GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "DocumentacionWWGridState"), null, "", "");
         }
         else
         {
            AV33GridState.FromXml(AV31Session.Get("DocumentacionWWGridState"), null, "", "");
         }
         AV17OrderedDsc = AV33GridState.gxTpr_Ordereddsc;
         AV67GXV3 = 1;
         while ( AV67GXV3 <= AV33GridState.gxTpr_Filtervalues.Count )
         {
            AV34GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV33GridState.gxTpr_Filtervalues.Item(AV67GXV3));
            if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV18FilterFullText = AV34GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFDOCUMENTACIONNOMBRE") == 0 )
            {
               AV46TFDocumentacionNombre = AV34GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFDOCUMENTACIONNOMBRE_SEL") == 0 )
            {
               AV47TFDocumentacionNombre_Sel = AV34GridStateFilterValue.gxTpr_Value;
            }
            AV67GXV3 = (int)(AV67GXV3+1);
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
         AV49Pgmname = "";
         GXKey = "";
         GXEncryptionTmp = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV11ExcelDocument = new ExcelDocumentI();
         AV18FilterFullText = "";
         AV33GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV30GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV19DynamicFiltersSelector1 = "";
         AV21DocumentacionNombre1 = "";
         AV23DynamicFiltersSelector2 = "";
         AV25DocumentacionNombre2 = "";
         AV27DynamicFiltersSelector3 = "";
         AV29DocumentacionNombre3 = "";
         AV47TFDocumentacionNombre_Sel = "";
         AV46TFDocumentacionNombre = "";
         AV31Session = context.GetSession();
         AV38ColumnsSelectorXML = "";
         AV35ColumnsSelector = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector(context);
         AV37ColumnsSelector_Column = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column(context);
         AV52Documentacionwwds_1_filterfulltext = "";
         AV53Documentacionwwds_2_dynamicfiltersselector1 = "";
         AV55Documentacionwwds_4_documentacionnombre1 = "";
         AV57Documentacionwwds_6_dynamicfiltersselector2 = "";
         AV59Documentacionwwds_8_documentacionnombre2 = "";
         AV61Documentacionwwds_10_dynamicfiltersselector3 = "";
         AV63Documentacionwwds_12_documentacionnombre3 = "";
         AV64Documentacionwwds_13_tfdocumentacionnombre = "";
         AV65Documentacionwwds_14_tfdocumentacionnombre_sel = "";
         lV52Documentacionwwds_1_filterfulltext = "";
         lV55Documentacionwwds_4_documentacionnombre1 = "";
         lV59Documentacionwwds_8_documentacionnombre2 = "";
         lV63Documentacionwwds_12_documentacionnombre3 = "";
         lV64Documentacionwwds_13_tfdocumentacionnombre = "";
         A489DocumentacionNombre = "";
         P00692_A489DocumentacionNombre = new string[] {""} ;
         P00692_A488DocumentacionId = new long[1] ;
         AV39UserCustomValue = "";
         GXt_char2 = "";
         AV36ColumnsSelectorAux = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector(context);
         AV34GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.documentacionwwexport__default(),
            new Object[][] {
                new Object[] {
               P00692_A489DocumentacionNombre, P00692_A488DocumentacionId
               }
            }
         );
         AV49Pgmname = "DocumentacionWWExport";
         /* GeneXus formulas. */
         AV49Pgmname = "DocumentacionWWExport";
      }

      private short AV20DynamicFiltersOperator1 ;
      private short AV24DynamicFiltersOperator2 ;
      private short AV28DynamicFiltersOperator3 ;
      private short GXt_int3 ;
      private short AV54Documentacionwwds_3_dynamicfiltersoperator1 ;
      private short AV58Documentacionwwds_7_dynamicfiltersoperator2 ;
      private short AV62Documentacionwwds_11_dynamicfiltersoperator3 ;
      private int AV14CellRow ;
      private int AV15FirstColumn ;
      private int AV16Random ;
      private int AV50GXV1 ;
      private int AV66GXV2 ;
      private int AV67GXV3 ;
      private long AV43VisibleColumnCount ;
      private long A488DocumentacionId ;
      private string AV49Pgmname ;
      private string GXKey ;
      private string GXEncryptionTmp ;
      private string AV21DocumentacionNombre1 ;
      private string AV25DocumentacionNombre2 ;
      private string AV29DocumentacionNombre3 ;
      private string AV47TFDocumentacionNombre_Sel ;
      private string AV46TFDocumentacionNombre ;
      private string AV55Documentacionwwds_4_documentacionnombre1 ;
      private string AV59Documentacionwwds_8_documentacionnombre2 ;
      private string AV63Documentacionwwds_12_documentacionnombre3 ;
      private string AV64Documentacionwwds_13_tfdocumentacionnombre ;
      private string AV65Documentacionwwds_14_tfdocumentacionnombre_sel ;
      private string lV55Documentacionwwds_4_documentacionnombre1 ;
      private string lV59Documentacionwwds_8_documentacionnombre2 ;
      private string lV63Documentacionwwds_12_documentacionnombre3 ;
      private string lV64Documentacionwwds_13_tfdocumentacionnombre ;
      private string A489DocumentacionNombre ;
      private string GXt_char2 ;
      private bool AV8IsAuthorized ;
      private bool GXt_boolean1 ;
      private bool returnInSub ;
      private bool AV22DynamicFiltersEnabled2 ;
      private bool AV26DynamicFiltersEnabled3 ;
      private bool AV56Documentacionwwds_5_dynamicfiltersenabled2 ;
      private bool AV60Documentacionwwds_9_dynamicfiltersenabled3 ;
      private bool AV17OrderedDsc ;
      private string AV38ColumnsSelectorXML ;
      private string AV39UserCustomValue ;
      private string AV12Filename ;
      private string AV13ErrorMessage ;
      private string AV18FilterFullText ;
      private string AV19DynamicFiltersSelector1 ;
      private string AV23DynamicFiltersSelector2 ;
      private string AV27DynamicFiltersSelector3 ;
      private string AV52Documentacionwwds_1_filterfulltext ;
      private string AV53Documentacionwwds_2_dynamicfiltersselector1 ;
      private string AV57Documentacionwwds_6_dynamicfiltersselector2 ;
      private string AV61Documentacionwwds_10_dynamicfiltersselector3 ;
      private string lV52Documentacionwwds_1_filterfulltext ;
      private IGxSession AV31Session ;
      private ExcelDocumentI AV11ExcelDocument ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV33GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV30GridStateDynamicFilter ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector AV35ColumnsSelector ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column AV37ColumnsSelector_Column ;
      private IDataStoreProvider pr_default ;
      private string[] P00692_A489DocumentacionNombre ;
      private long[] P00692_A488DocumentacionId ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector AV36ColumnsSelectorAux ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV34GridStateFilterValue ;
      private string aP0_Filename ;
      private string aP1_ErrorMessage ;
   }

   public class documentacionwwexport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00692( IGxContext context ,
                                             string AV52Documentacionwwds_1_filterfulltext ,
                                             string AV53Documentacionwwds_2_dynamicfiltersselector1 ,
                                             short AV54Documentacionwwds_3_dynamicfiltersoperator1 ,
                                             string AV55Documentacionwwds_4_documentacionnombre1 ,
                                             bool AV56Documentacionwwds_5_dynamicfiltersenabled2 ,
                                             string AV57Documentacionwwds_6_dynamicfiltersselector2 ,
                                             short AV58Documentacionwwds_7_dynamicfiltersoperator2 ,
                                             string AV59Documentacionwwds_8_documentacionnombre2 ,
                                             bool AV60Documentacionwwds_9_dynamicfiltersenabled3 ,
                                             string AV61Documentacionwwds_10_dynamicfiltersselector3 ,
                                             short AV62Documentacionwwds_11_dynamicfiltersoperator3 ,
                                             string AV63Documentacionwwds_12_documentacionnombre3 ,
                                             string AV65Documentacionwwds_14_tfdocumentacionnombre_sel ,
                                             string AV64Documentacionwwds_13_tfdocumentacionnombre ,
                                             string A489DocumentacionNombre ,
                                             bool AV17OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int4 = new short[9];
         Object[] GXv_Object5 = new Object[2];
         scmdbuf = "SELECT [DocumentacionNombre], [DocumentacionId] FROM [Documentacion]";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV52Documentacionwwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( UPPER([DocumentacionNombre]) like '%' + UPPER(@lV52Documentacionwwds_1_filterfulltext)))");
         }
         else
         {
            GXv_int4[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV53Documentacionwwds_2_dynamicfiltersselector1, "DOCUMENTACIONNOMBRE") == 0 ) && ( AV54Documentacionwwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV55Documentacionwwds_4_documentacionnombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER([DocumentacionNombre]) like UPPER(@lV55Documentacionwwds_4_documentacionnombre1))");
         }
         else
         {
            GXv_int4[1] = 1;
         }
         if ( ( StringUtil.StrCmp(AV53Documentacionwwds_2_dynamicfiltersselector1, "DOCUMENTACIONNOMBRE") == 0 ) && ( AV54Documentacionwwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV55Documentacionwwds_4_documentacionnombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER([DocumentacionNombre]) like '%' + UPPER(@lV55Documentacionwwds_4_documentacionnombre1))");
         }
         else
         {
            GXv_int4[2] = 1;
         }
         if ( AV56Documentacionwwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV57Documentacionwwds_6_dynamicfiltersselector2, "DOCUMENTACIONNOMBRE") == 0 ) && ( AV58Documentacionwwds_7_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59Documentacionwwds_8_documentacionnombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER([DocumentacionNombre]) like UPPER(@lV59Documentacionwwds_8_documentacionnombre2))");
         }
         else
         {
            GXv_int4[3] = 1;
         }
         if ( AV56Documentacionwwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV57Documentacionwwds_6_dynamicfiltersselector2, "DOCUMENTACIONNOMBRE") == 0 ) && ( AV58Documentacionwwds_7_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59Documentacionwwds_8_documentacionnombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER([DocumentacionNombre]) like '%' + UPPER(@lV59Documentacionwwds_8_documentacionnombre2))");
         }
         else
         {
            GXv_int4[4] = 1;
         }
         if ( AV60Documentacionwwds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV61Documentacionwwds_10_dynamicfiltersselector3, "DOCUMENTACIONNOMBRE") == 0 ) && ( AV62Documentacionwwds_11_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Documentacionwwds_12_documentacionnombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER([DocumentacionNombre]) like UPPER(@lV63Documentacionwwds_12_documentacionnombre3))");
         }
         else
         {
            GXv_int4[5] = 1;
         }
         if ( AV60Documentacionwwds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV61Documentacionwwds_10_dynamicfiltersselector3, "DOCUMENTACIONNOMBRE") == 0 ) && ( AV62Documentacionwwds_11_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Documentacionwwds_12_documentacionnombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER([DocumentacionNombre]) like '%' + UPPER(@lV63Documentacionwwds_12_documentacionnombre3))");
         }
         else
         {
            GXv_int4[6] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV65Documentacionwwds_14_tfdocumentacionnombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Documentacionwwds_13_tfdocumentacionnombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER([DocumentacionNombre]) like UPPER(@lV64Documentacionwwds_13_tfdocumentacionnombre))");
         }
         else
         {
            GXv_int4[7] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Documentacionwwds_14_tfdocumentacionnombre_sel)) && ! ( StringUtil.StrCmp(AV65Documentacionwwds_14_tfdocumentacionnombre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([DocumentacionNombre] = @AV65Documentacionwwds_14_tfdocumentacionnombre_sel)");
         }
         else
         {
            GXv_int4[8] = 1;
         }
         if ( StringUtil.StrCmp(AV65Documentacionwwds_14_tfdocumentacionnombre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([DocumentacionNombre] = ''))");
         }
         scmdbuf += sWhereString;
         if ( ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY [DocumentacionNombre]";
         }
         else if ( AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY [DocumentacionNombre] DESC";
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
                     return conditional_P00692(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (short)dynConstraints[2] , (string)dynConstraints[3] , (bool)dynConstraints[4] , (string)dynConstraints[5] , (short)dynConstraints[6] , (string)dynConstraints[7] , (bool)dynConstraints[8] , (string)dynConstraints[9] , (short)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (bool)dynConstraints[15] );
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
          Object[] prmP00692;
          prmP00692 = new Object[] {
          new ParDef("@lV52Documentacionwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV55Documentacionwwds_4_documentacionnombre1",GXType.Char,80,0) ,
          new ParDef("@lV55Documentacionwwds_4_documentacionnombre1",GXType.Char,80,0) ,
          new ParDef("@lV59Documentacionwwds_8_documentacionnombre2",GXType.Char,80,0) ,
          new ParDef("@lV59Documentacionwwds_8_documentacionnombre2",GXType.Char,80,0) ,
          new ParDef("@lV63Documentacionwwds_12_documentacionnombre3",GXType.Char,80,0) ,
          new ParDef("@lV63Documentacionwwds_12_documentacionnombre3",GXType.Char,80,0) ,
          new ParDef("@lV64Documentacionwwds_13_tfdocumentacionnombre",GXType.Char,80,0) ,
          new ParDef("@AV65Documentacionwwds_14_tfdocumentacionnombre_sel",GXType.NChar,80,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00692", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00692,100, GxCacheFrequency.OFF ,true,false )
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
                return;
       }
    }

 }

}

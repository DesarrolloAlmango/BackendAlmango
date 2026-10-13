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
   public class paiswwexport : GXProcedure
   {
      public paiswwexport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public paiswwexport( IGxContext context )
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
         new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWPais", out  GXt_boolean1) ;
         AV8IsAuthorized = GXt_boolean1;
         if ( ! AV8IsAuthorized )
         {
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "wwpbaseobjects.notauthorized.aspx"+GXUtil.UrlEncode(StringUtil.RTrim(AV52Pgmname));
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
         AV12Filename = GXt_char2 + "PaisWWExport-" + StringUtil.Trim( StringUtil.Str( (decimal)(AV16Random), 8, 0)) + ".xlsx";
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
            if ( StringUtil.StrCmp(AV20DynamicFiltersSelector1, "PAISNOMBRE") == 0 )
            {
               AV21DynamicFiltersOperator1 = AV31GridStateDynamicFilter.gxTpr_Operator;
               AV22PaisNombre1 = AV31GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV22PaisNombre1)) )
               {
                  AV14CellRow = (int)(AV14CellRow+1);
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Bold = 1;
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Color = 3;
                  if ( AV21DynamicFiltersOperator1 == 0 )
                  {
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "", context.GetMessage( "WWP_FilterLike", ""), "", "", "", "", "", "", "");
                  }
                  else if ( AV21DynamicFiltersOperator1 == 1 )
                  {
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "", context.GetMessage( "WWP_FilterContains", ""), "", "", "", "", "", "", "");
                  }
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Italic = 1;
                  GXt_char2 = "";
                  new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV22PaisNombre1, out  GXt_char2) ;
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
               }
            }
            if ( AV34GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV23DynamicFiltersEnabled2 = true;
               AV31GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV34GridState.gxTpr_Dynamicfilters.Item(2));
               AV24DynamicFiltersSelector2 = AV31GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV24DynamicFiltersSelector2, "PAISNOMBRE") == 0 )
               {
                  AV25DynamicFiltersOperator2 = AV31GridStateDynamicFilter.gxTpr_Operator;
                  AV26PaisNombre2 = AV31GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV26PaisNombre2)) )
                  {
                     AV14CellRow = (int)(AV14CellRow+1);
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Bold = 1;
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Color = 3;
                     if ( AV25DynamicFiltersOperator2 == 0 )
                     {
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "", context.GetMessage( "WWP_FilterLike", ""), "", "", "", "", "", "", "");
                     }
                     else if ( AV25DynamicFiltersOperator2 == 1 )
                     {
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "", context.GetMessage( "WWP_FilterContains", ""), "", "", "", "", "", "", "");
                     }
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Italic = 1;
                     GXt_char2 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV26PaisNombre2, out  GXt_char2) ;
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
                  }
               }
               if ( AV34GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV27DynamicFiltersEnabled3 = true;
                  AV31GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV34GridState.gxTpr_Dynamicfilters.Item(3));
                  AV28DynamicFiltersSelector3 = AV31GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV28DynamicFiltersSelector3, "PAISNOMBRE") == 0 )
                  {
                     AV29DynamicFiltersOperator3 = AV31GridStateDynamicFilter.gxTpr_Operator;
                     AV30PaisNombre3 = AV31GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV30PaisNombre3)) )
                     {
                        AV14CellRow = (int)(AV14CellRow+1);
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Bold = 1;
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Color = 3;
                        if ( AV29DynamicFiltersOperator3 == 0 )
                        {
                           AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "", context.GetMessage( "WWP_FilterLike", ""), "", "", "", "", "", "", "");
                        }
                        else if ( AV29DynamicFiltersOperator3 == 1 )
                        {
                           AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "", context.GetMessage( "WWP_FilterContains", ""), "", "", "", "", "", "", "");
                        }
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Italic = 1;
                        GXt_char2 = "";
                        new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV30PaisNombre3, out  GXt_char2) ;
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
                     }
                  }
               }
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV48TFPaisID_Sel)) ) )
         {
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Pais", "")) ;
            AV14CellRow = GXt_int3;
            GXt_char2 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV48TFPaisID_Sel)) ? context.GetMessage( "WWP_TitleFilter_EmptyOption", "") : AV48TFPaisID_Sel), out  GXt_char2) ;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV47TFPaisID)) ) )
            {
               GXt_int3 = (short)(AV14CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Pais", "")) ;
               AV14CellRow = GXt_int3;
               GXt_char2 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV47TFPaisID, out  GXt_char2) ;
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV50TFPaisNombre_Sel)) ) )
         {
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  "") ;
            AV14CellRow = GXt_int3;
            GXt_char2 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV50TFPaisNombre_Sel)) ? context.GetMessage( "WWP_TitleFilter_EmptyOption", "") : AV50TFPaisNombre_Sel), out  GXt_char2) ;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV49TFPaisNombre)) ) )
            {
               GXt_int3 = (short)(AV14CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  "") ;
               AV14CellRow = GXt_int3;
               GXt_char2 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV49TFPaisNombre, out  GXt_char2) ;
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
            }
         }
         AV14CellRow = (int)(AV14CellRow+2);
      }

      protected void S141( )
      {
         /* 'WRITECOLUMNTITLES' Routine */
         returnInSub = false;
         AV44VisibleColumnCount = 0;
         if ( StringUtil.StrCmp(AV32Session.Get("PaisWWColumnsSelector"), "") != 0 )
         {
            AV39ColumnsSelectorXML = AV32Session.Get("PaisWWColumnsSelector");
            AV36ColumnsSelector.FromXml(AV39ColumnsSelectorXML, null, "", "");
         }
         else
         {
            /* Execute user subroutine: 'INITIALIZECOLUMNSSELECTOR' */
            S151 ();
            if (returnInSub) return;
         }
         AV36ColumnsSelector.gxTpr_Columns.Sort("Order");
         AV53GXV1 = 1;
         while ( AV53GXV1 <= AV36ColumnsSelector.gxTpr_Columns.Count )
         {
            AV38ColumnsSelector_Column = ((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV36ColumnsSelector.gxTpr_Columns.Item(AV53GXV1));
            if ( AV38ColumnsSelector_Column.gxTpr_Isvisible )
            {
               AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV44VisibleColumnCount), 1, 1).Text = context.GetMessage( (String.IsNullOrEmpty(StringUtil.RTrim( AV38ColumnsSelector_Column.gxTpr_Displayname)) ? AV38ColumnsSelector_Column.gxTpr_Columnname : AV38ColumnsSelector_Column.gxTpr_Displayname), "");
               AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV44VisibleColumnCount), 1, 1).Bold = 1;
               AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV44VisibleColumnCount), 1, 1).Color = 11;
               AV44VisibleColumnCount = (long)(AV44VisibleColumnCount+1);
            }
            AV53GXV1 = (int)(AV53GXV1+1);
         }
      }

      protected void S161( )
      {
         /* 'WRITEDATA' Routine */
         returnInSub = false;
         AV55Paiswwds_1_filterfulltext = AV19FilterFullText;
         AV56Paiswwds_2_dynamicfiltersselector1 = AV20DynamicFiltersSelector1;
         AV57Paiswwds_3_dynamicfiltersoperator1 = AV21DynamicFiltersOperator1;
         AV58Paiswwds_4_paisnombre1 = AV22PaisNombre1;
         AV59Paiswwds_5_dynamicfiltersenabled2 = AV23DynamicFiltersEnabled2;
         AV60Paiswwds_6_dynamicfiltersselector2 = AV24DynamicFiltersSelector2;
         AV61Paiswwds_7_dynamicfiltersoperator2 = AV25DynamicFiltersOperator2;
         AV62Paiswwds_8_paisnombre2 = AV26PaisNombre2;
         AV63Paiswwds_9_dynamicfiltersenabled3 = AV27DynamicFiltersEnabled3;
         AV64Paiswwds_10_dynamicfiltersselector3 = AV28DynamicFiltersSelector3;
         AV65Paiswwds_11_dynamicfiltersoperator3 = AV29DynamicFiltersOperator3;
         AV66Paiswwds_12_paisnombre3 = AV30PaisNombre3;
         AV67Paiswwds_13_tfpaisid = AV47TFPaisID;
         AV68Paiswwds_14_tfpaisid_sel = AV48TFPaisID_Sel;
         AV69Paiswwds_15_tfpaisnombre = AV49TFPaisNombre;
         AV70Paiswwds_16_tfpaisnombre_sel = AV50TFPaisNombre_Sel;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV55Paiswwds_1_filterfulltext ,
                                              AV56Paiswwds_2_dynamicfiltersselector1 ,
                                              AV57Paiswwds_3_dynamicfiltersoperator1 ,
                                              AV58Paiswwds_4_paisnombre1 ,
                                              AV59Paiswwds_5_dynamicfiltersenabled2 ,
                                              AV60Paiswwds_6_dynamicfiltersselector2 ,
                                              AV61Paiswwds_7_dynamicfiltersoperator2 ,
                                              AV62Paiswwds_8_paisnombre2 ,
                                              AV63Paiswwds_9_dynamicfiltersenabled3 ,
                                              AV64Paiswwds_10_dynamicfiltersselector3 ,
                                              AV65Paiswwds_11_dynamicfiltersoperator3 ,
                                              AV66Paiswwds_12_paisnombre3 ,
                                              AV68Paiswwds_14_tfpaisid_sel ,
                                              AV67Paiswwds_13_tfpaisid ,
                                              AV70Paiswwds_16_tfpaisnombre_sel ,
                                              AV69Paiswwds_15_tfpaisnombre ,
                                              A116PaisID ,
                                              A165PaisNombre ,
                                              AV17OrderedBy ,
                                              AV18OrderedDsc } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV55Paiswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV55Paiswwds_1_filterfulltext), "%", "");
         lV55Paiswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV55Paiswwds_1_filterfulltext), "%", "");
         lV58Paiswwds_4_paisnombre1 = StringUtil.PadR( StringUtil.RTrim( AV58Paiswwds_4_paisnombre1), 80, "%");
         lV58Paiswwds_4_paisnombre1 = StringUtil.PadR( StringUtil.RTrim( AV58Paiswwds_4_paisnombre1), 80, "%");
         lV62Paiswwds_8_paisnombre2 = StringUtil.PadR( StringUtil.RTrim( AV62Paiswwds_8_paisnombre2), 80, "%");
         lV62Paiswwds_8_paisnombre2 = StringUtil.PadR( StringUtil.RTrim( AV62Paiswwds_8_paisnombre2), 80, "%");
         lV66Paiswwds_12_paisnombre3 = StringUtil.PadR( StringUtil.RTrim( AV66Paiswwds_12_paisnombre3), 80, "%");
         lV66Paiswwds_12_paisnombre3 = StringUtil.PadR( StringUtil.RTrim( AV66Paiswwds_12_paisnombre3), 80, "%");
         lV67Paiswwds_13_tfpaisid = StringUtil.PadR( StringUtil.RTrim( AV67Paiswwds_13_tfpaisid), 2, "%");
         lV69Paiswwds_15_tfpaisnombre = StringUtil.PadR( StringUtil.RTrim( AV69Paiswwds_15_tfpaisnombre), 80, "%");
         /* Using cursor P003W2 */
         pr_default.execute(0, new Object[] {lV55Paiswwds_1_filterfulltext, lV55Paiswwds_1_filterfulltext, lV58Paiswwds_4_paisnombre1, lV58Paiswwds_4_paisnombre1, lV62Paiswwds_8_paisnombre2, lV62Paiswwds_8_paisnombre2, lV66Paiswwds_12_paisnombre3, lV66Paiswwds_12_paisnombre3, lV67Paiswwds_13_tfpaisid, AV68Paiswwds_14_tfpaisid_sel, lV69Paiswwds_15_tfpaisnombre, AV70Paiswwds_16_tfpaisnombre_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A165PaisNombre = P003W2_A165PaisNombre[0];
            A116PaisID = P003W2_A116PaisID[0];
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
            AV71GXV2 = 1;
            while ( AV71GXV2 <= AV36ColumnsSelector.gxTpr_Columns.Count )
            {
               AV38ColumnsSelector_Column = ((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV36ColumnsSelector.gxTpr_Columns.Item(AV71GXV2));
               if ( AV38ColumnsSelector_Column.gxTpr_Isvisible )
               {
                  if ( StringUtil.StrCmp(AV38ColumnsSelector_Column.gxTpr_Columnname, "PaisID") == 0 )
                  {
                     GXt_char2 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A116PaisID, out  GXt_char2) ;
                     AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV44VisibleColumnCount), 1, 1).Text = GXt_char2;
                  }
                  else if ( StringUtil.StrCmp(AV38ColumnsSelector_Column.gxTpr_Columnname, "PaisNombre") == 0 )
                  {
                     GXt_char2 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A165PaisNombre, out  GXt_char2) ;
                     AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV44VisibleColumnCount), 1, 1).Text = GXt_char2;
                  }
                  else if ( StringUtil.StrCmp(AV38ColumnsSelector_Column.gxTpr_Columnname, "PaisBandera") == 0 )
                  {
                     AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV44VisibleColumnCount), 1, 1).Text = "";
                  }
                  AV44VisibleColumnCount = (long)(AV44VisibleColumnCount+1);
               }
               AV71GXV2 = (int)(AV71GXV2+1);
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
         AV32Session.Set("WWPExportFilePath", AV12Filename);
         AV32Session.Set("WWPExportFileName", "PaisWWExport.xlsx");
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
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV36ColumnsSelector,  "PaisID",  "",  "Pais",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV36ColumnsSelector,  "PaisNombre",  "",  "",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV36ColumnsSelector,  "PaisBandera",  "",  "",  true,  "") ;
         GXt_char2 = AV40UserCustomValue;
         new GeneXus.Programs.wwpbaseobjects.loadcolumnsselectorstate(context ).execute(  "PaisWWColumnsSelector", out  GXt_char2) ;
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
         if ( StringUtil.StrCmp(AV32Session.Get("PaisWWGridState"), "") == 0 )
         {
            AV34GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "PaisWWGridState"), null, "", "");
         }
         else
         {
            AV34GridState.FromXml(AV32Session.Get("PaisWWGridState"), null, "", "");
         }
         AV17OrderedBy = AV34GridState.gxTpr_Orderedby;
         AV18OrderedDsc = AV34GridState.gxTpr_Ordereddsc;
         AV72GXV3 = 1;
         while ( AV72GXV3 <= AV34GridState.gxTpr_Filtervalues.Count )
         {
            AV35GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV34GridState.gxTpr_Filtervalues.Item(AV72GXV3));
            if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV19FilterFullText = AV35GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFPAISID") == 0 )
            {
               AV47TFPaisID = AV35GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFPAISID_SEL") == 0 )
            {
               AV48TFPaisID_Sel = AV35GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFPAISNOMBRE") == 0 )
            {
               AV49TFPaisNombre = AV35GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFPAISNOMBRE_SEL") == 0 )
            {
               AV50TFPaisNombre_Sel = AV35GridStateFilterValue.gxTpr_Value;
            }
            AV72GXV3 = (int)(AV72GXV3+1);
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
         AV52Pgmname = "";
         GXKey = "";
         GXEncryptionTmp = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV11ExcelDocument = new ExcelDocumentI();
         AV19FilterFullText = "";
         AV34GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV31GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV20DynamicFiltersSelector1 = "";
         AV22PaisNombre1 = "";
         AV24DynamicFiltersSelector2 = "";
         AV26PaisNombre2 = "";
         AV28DynamicFiltersSelector3 = "";
         AV30PaisNombre3 = "";
         AV48TFPaisID_Sel = "";
         AV47TFPaisID = "";
         AV50TFPaisNombre_Sel = "";
         AV49TFPaisNombre = "";
         AV32Session = context.GetSession();
         AV39ColumnsSelectorXML = "";
         AV36ColumnsSelector = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector(context);
         AV38ColumnsSelector_Column = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column(context);
         AV55Paiswwds_1_filterfulltext = "";
         AV56Paiswwds_2_dynamicfiltersselector1 = "";
         AV58Paiswwds_4_paisnombre1 = "";
         AV60Paiswwds_6_dynamicfiltersselector2 = "";
         AV62Paiswwds_8_paisnombre2 = "";
         AV64Paiswwds_10_dynamicfiltersselector3 = "";
         AV66Paiswwds_12_paisnombre3 = "";
         AV67Paiswwds_13_tfpaisid = "";
         AV68Paiswwds_14_tfpaisid_sel = "";
         AV69Paiswwds_15_tfpaisnombre = "";
         AV70Paiswwds_16_tfpaisnombre_sel = "";
         lV55Paiswwds_1_filterfulltext = "";
         lV58Paiswwds_4_paisnombre1 = "";
         lV62Paiswwds_8_paisnombre2 = "";
         lV66Paiswwds_12_paisnombre3 = "";
         lV67Paiswwds_13_tfpaisid = "";
         lV69Paiswwds_15_tfpaisnombre = "";
         A116PaisID = "";
         A165PaisNombre = "";
         P003W2_A165PaisNombre = new string[] {""} ;
         P003W2_A116PaisID = new string[] {""} ;
         AV40UserCustomValue = "";
         GXt_char2 = "";
         AV37ColumnsSelectorAux = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector(context);
         AV35GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.paiswwexport__default(),
            new Object[][] {
                new Object[] {
               P003W2_A165PaisNombre, P003W2_A116PaisID
               }
            }
         );
         AV52Pgmname = "PaisWWExport";
         /* GeneXus formulas. */
         AV52Pgmname = "PaisWWExport";
      }

      private short AV21DynamicFiltersOperator1 ;
      private short AV25DynamicFiltersOperator2 ;
      private short AV29DynamicFiltersOperator3 ;
      private short GXt_int3 ;
      private short AV57Paiswwds_3_dynamicfiltersoperator1 ;
      private short AV61Paiswwds_7_dynamicfiltersoperator2 ;
      private short AV65Paiswwds_11_dynamicfiltersoperator3 ;
      private short AV17OrderedBy ;
      private int AV14CellRow ;
      private int AV15FirstColumn ;
      private int AV16Random ;
      private int AV53GXV1 ;
      private int AV71GXV2 ;
      private int AV72GXV3 ;
      private long AV44VisibleColumnCount ;
      private string AV52Pgmname ;
      private string GXKey ;
      private string GXEncryptionTmp ;
      private string AV22PaisNombre1 ;
      private string AV26PaisNombre2 ;
      private string AV30PaisNombre3 ;
      private string AV48TFPaisID_Sel ;
      private string AV47TFPaisID ;
      private string AV50TFPaisNombre_Sel ;
      private string AV49TFPaisNombre ;
      private string AV58Paiswwds_4_paisnombre1 ;
      private string AV62Paiswwds_8_paisnombre2 ;
      private string AV66Paiswwds_12_paisnombre3 ;
      private string AV67Paiswwds_13_tfpaisid ;
      private string AV68Paiswwds_14_tfpaisid_sel ;
      private string AV69Paiswwds_15_tfpaisnombre ;
      private string AV70Paiswwds_16_tfpaisnombre_sel ;
      private string lV58Paiswwds_4_paisnombre1 ;
      private string lV62Paiswwds_8_paisnombre2 ;
      private string lV66Paiswwds_12_paisnombre3 ;
      private string lV67Paiswwds_13_tfpaisid ;
      private string lV69Paiswwds_15_tfpaisnombre ;
      private string A116PaisID ;
      private string A165PaisNombre ;
      private string GXt_char2 ;
      private bool AV8IsAuthorized ;
      private bool GXt_boolean1 ;
      private bool returnInSub ;
      private bool AV23DynamicFiltersEnabled2 ;
      private bool AV27DynamicFiltersEnabled3 ;
      private bool AV59Paiswwds_5_dynamicfiltersenabled2 ;
      private bool AV63Paiswwds_9_dynamicfiltersenabled3 ;
      private bool AV18OrderedDsc ;
      private string AV39ColumnsSelectorXML ;
      private string AV40UserCustomValue ;
      private string AV12Filename ;
      private string AV13ErrorMessage ;
      private string AV19FilterFullText ;
      private string AV20DynamicFiltersSelector1 ;
      private string AV24DynamicFiltersSelector2 ;
      private string AV28DynamicFiltersSelector3 ;
      private string AV55Paiswwds_1_filterfulltext ;
      private string AV56Paiswwds_2_dynamicfiltersselector1 ;
      private string AV60Paiswwds_6_dynamicfiltersselector2 ;
      private string AV64Paiswwds_10_dynamicfiltersselector3 ;
      private string lV55Paiswwds_1_filterfulltext ;
      private IGxSession AV32Session ;
      private ExcelDocumentI AV11ExcelDocument ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV34GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV31GridStateDynamicFilter ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector AV36ColumnsSelector ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column AV38ColumnsSelector_Column ;
      private IDataStoreProvider pr_default ;
      private string[] P003W2_A165PaisNombre ;
      private string[] P003W2_A116PaisID ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector AV37ColumnsSelectorAux ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV35GridStateFilterValue ;
      private string aP0_Filename ;
      private string aP1_ErrorMessage ;
   }

   public class paiswwexport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P003W2( IGxContext context ,
                                             string AV55Paiswwds_1_filterfulltext ,
                                             string AV56Paiswwds_2_dynamicfiltersselector1 ,
                                             short AV57Paiswwds_3_dynamicfiltersoperator1 ,
                                             string AV58Paiswwds_4_paisnombre1 ,
                                             bool AV59Paiswwds_5_dynamicfiltersenabled2 ,
                                             string AV60Paiswwds_6_dynamicfiltersselector2 ,
                                             short AV61Paiswwds_7_dynamicfiltersoperator2 ,
                                             string AV62Paiswwds_8_paisnombre2 ,
                                             bool AV63Paiswwds_9_dynamicfiltersenabled3 ,
                                             string AV64Paiswwds_10_dynamicfiltersselector3 ,
                                             short AV65Paiswwds_11_dynamicfiltersoperator3 ,
                                             string AV66Paiswwds_12_paisnombre3 ,
                                             string AV68Paiswwds_14_tfpaisid_sel ,
                                             string AV67Paiswwds_13_tfpaisid ,
                                             string AV70Paiswwds_16_tfpaisnombre_sel ,
                                             string AV69Paiswwds_15_tfpaisnombre ,
                                             string A116PaisID ,
                                             string A165PaisNombre ,
                                             short AV17OrderedBy ,
                                             bool AV18OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int4 = new short[12];
         Object[] GXv_Object5 = new Object[2];
         scmdbuf = "SELECT [PaisNombre], [PaisID] FROM [Pais]";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV55Paiswwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( UPPER([PaisID]) like '%' + UPPER(@lV55Paiswwds_1_filterfulltext)) or ( UPPER([PaisNombre]) like '%' + UPPER(@lV55Paiswwds_1_filterfulltext)))");
         }
         else
         {
            GXv_int4[0] = 1;
            GXv_int4[1] = 1;
         }
         if ( ( StringUtil.StrCmp(AV56Paiswwds_2_dynamicfiltersselector1, "PAISNOMBRE") == 0 ) && ( AV57Paiswwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV58Paiswwds_4_paisnombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER([PaisNombre]) like UPPER(@lV58Paiswwds_4_paisnombre1))");
         }
         else
         {
            GXv_int4[2] = 1;
         }
         if ( ( StringUtil.StrCmp(AV56Paiswwds_2_dynamicfiltersselector1, "PAISNOMBRE") == 0 ) && ( AV57Paiswwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV58Paiswwds_4_paisnombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER([PaisNombre]) like '%' + UPPER(@lV58Paiswwds_4_paisnombre1))");
         }
         else
         {
            GXv_int4[3] = 1;
         }
         if ( AV59Paiswwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV60Paiswwds_6_dynamicfiltersselector2, "PAISNOMBRE") == 0 ) && ( AV61Paiswwds_7_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Paiswwds_8_paisnombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER([PaisNombre]) like UPPER(@lV62Paiswwds_8_paisnombre2))");
         }
         else
         {
            GXv_int4[4] = 1;
         }
         if ( AV59Paiswwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV60Paiswwds_6_dynamicfiltersselector2, "PAISNOMBRE") == 0 ) && ( AV61Paiswwds_7_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Paiswwds_8_paisnombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER([PaisNombre]) like '%' + UPPER(@lV62Paiswwds_8_paisnombre2))");
         }
         else
         {
            GXv_int4[5] = 1;
         }
         if ( AV63Paiswwds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV64Paiswwds_10_dynamicfiltersselector3, "PAISNOMBRE") == 0 ) && ( AV65Paiswwds_11_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Paiswwds_12_paisnombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER([PaisNombre]) like UPPER(@lV66Paiswwds_12_paisnombre3))");
         }
         else
         {
            GXv_int4[6] = 1;
         }
         if ( AV63Paiswwds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV64Paiswwds_10_dynamicfiltersselector3, "PAISNOMBRE") == 0 ) && ( AV65Paiswwds_11_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Paiswwds_12_paisnombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER([PaisNombre]) like '%' + UPPER(@lV66Paiswwds_12_paisnombre3))");
         }
         else
         {
            GXv_int4[7] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV68Paiswwds_14_tfpaisid_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Paiswwds_13_tfpaisid)) ) )
         {
            AddWhere(sWhereString, "(UPPER([PaisID]) like UPPER(@lV67Paiswwds_13_tfpaisid))");
         }
         else
         {
            GXv_int4[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Paiswwds_14_tfpaisid_sel)) && ! ( StringUtil.StrCmp(AV68Paiswwds_14_tfpaisid_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([PaisID] = @AV68Paiswwds_14_tfpaisid_sel)");
         }
         else
         {
            GXv_int4[9] = 1;
         }
         if ( StringUtil.StrCmp(AV68Paiswwds_14_tfpaisid_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([PaisID] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV70Paiswwds_16_tfpaisnombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Paiswwds_15_tfpaisnombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER([PaisNombre]) like UPPER(@lV69Paiswwds_15_tfpaisnombre))");
         }
         else
         {
            GXv_int4[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Paiswwds_16_tfpaisnombre_sel)) && ! ( StringUtil.StrCmp(AV70Paiswwds_16_tfpaisnombre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([PaisNombre] = @AV70Paiswwds_16_tfpaisnombre_sel)");
         }
         else
         {
            GXv_int4[11] = 1;
         }
         if ( StringUtil.StrCmp(AV70Paiswwds_16_tfpaisnombre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([PaisNombre] = ''))");
         }
         scmdbuf += sWhereString;
         if ( ( AV17OrderedBy == 1 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY [PaisNombre]";
         }
         else if ( ( AV17OrderedBy == 1 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [PaisNombre] DESC";
         }
         else if ( ( AV17OrderedBy == 2 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY [PaisID]";
         }
         else if ( ( AV17OrderedBy == 2 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [PaisID] DESC";
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
                     return conditional_P003W2(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (short)dynConstraints[2] , (string)dynConstraints[3] , (bool)dynConstraints[4] , (string)dynConstraints[5] , (short)dynConstraints[6] , (string)dynConstraints[7] , (bool)dynConstraints[8] , (string)dynConstraints[9] , (short)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (short)dynConstraints[18] , (bool)dynConstraints[19] );
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
          Object[] prmP003W2;
          prmP003W2 = new Object[] {
          new ParDef("@lV55Paiswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV55Paiswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV58Paiswwds_4_paisnombre1",GXType.Char,80,0) ,
          new ParDef("@lV58Paiswwds_4_paisnombre1",GXType.Char,80,0) ,
          new ParDef("@lV62Paiswwds_8_paisnombre2",GXType.Char,80,0) ,
          new ParDef("@lV62Paiswwds_8_paisnombre2",GXType.Char,80,0) ,
          new ParDef("@lV66Paiswwds_12_paisnombre3",GXType.Char,80,0) ,
          new ParDef("@lV66Paiswwds_12_paisnombre3",GXType.Char,80,0) ,
          new ParDef("@lV67Paiswwds_13_tfpaisid",GXType.Char,2,0) ,
          new ParDef("@AV68Paiswwds_14_tfpaisid_sel",GXType.NChar,2,0) ,
          new ParDef("@lV69Paiswwds_15_tfpaisnombre",GXType.Char,80,0) ,
          new ParDef("@AV70Paiswwds_16_tfpaisnombre_sel",GXType.NChar,80,0)
          };
          def= new CursorDef[] {
              new CursorDef("P003W2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP003W2,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[1])[0] = rslt.getString(2, 2);
                return;
       }
    }

 }

}

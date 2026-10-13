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
   public class rubrosmedidaswwexport : GXProcedure
   {
      public rubrosmedidaswwexport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public rubrosmedidaswwexport( IGxContext context )
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
         new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWRubrosMedidas", out  GXt_boolean1) ;
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
         AV12Filename = GXt_char2 + "RubrosMedidasWWExport-" + StringUtil.Trim( StringUtil.Str( (decimal)(AV16Random), 8, 0)) + ".xlsx";
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
            if ( StringUtil.StrCmp(AV20DynamicFiltersSelector1, "RUBROSNOMBRE") == 0 )
            {
               AV21DynamicFiltersOperator1 = AV31GridStateDynamicFilter.gxTpr_Operator;
               AV22RubrosNombre1 = AV31GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV22RubrosNombre1)) )
               {
                  AV14CellRow = (int)(AV14CellRow+1);
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Bold = 1;
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Color = 3;
                  if ( AV21DynamicFiltersOperator1 == 0 )
                  {
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", context.GetMessage( "Rubro", ""), context.GetMessage( "WWP_FilterLike", ""), "", "", "", "", "", "", "");
                  }
                  else if ( AV21DynamicFiltersOperator1 == 1 )
                  {
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", context.GetMessage( "Rubro", ""), context.GetMessage( "WWP_FilterContains", ""), "", "", "", "", "", "", "");
                  }
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Italic = 1;
                  GXt_char2 = "";
                  new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV22RubrosNombre1, out  GXt_char2) ;
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
               }
            }
            if ( AV34GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV23DynamicFiltersEnabled2 = true;
               AV31GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV34GridState.gxTpr_Dynamicfilters.Item(2));
               AV24DynamicFiltersSelector2 = AV31GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV24DynamicFiltersSelector2, "RUBROSNOMBRE") == 0 )
               {
                  AV25DynamicFiltersOperator2 = AV31GridStateDynamicFilter.gxTpr_Operator;
                  AV26RubrosNombre2 = AV31GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV26RubrosNombre2)) )
                  {
                     AV14CellRow = (int)(AV14CellRow+1);
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Bold = 1;
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Color = 3;
                     if ( AV25DynamicFiltersOperator2 == 0 )
                     {
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", context.GetMessage( "Rubro", ""), context.GetMessage( "WWP_FilterLike", ""), "", "", "", "", "", "", "");
                     }
                     else if ( AV25DynamicFiltersOperator2 == 1 )
                     {
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", context.GetMessage( "Rubro", ""), context.GetMessage( "WWP_FilterContains", ""), "", "", "", "", "", "", "");
                     }
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Italic = 1;
                     GXt_char2 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV26RubrosNombre2, out  GXt_char2) ;
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
                  }
               }
               if ( AV34GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV27DynamicFiltersEnabled3 = true;
                  AV31GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV34GridState.gxTpr_Dynamicfilters.Item(3));
                  AV28DynamicFiltersSelector3 = AV31GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV28DynamicFiltersSelector3, "RUBROSNOMBRE") == 0 )
                  {
                     AV29DynamicFiltersOperator3 = AV31GridStateDynamicFilter.gxTpr_Operator;
                     AV30RubrosNombre3 = AV31GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV30RubrosNombre3)) )
                     {
                        AV14CellRow = (int)(AV14CellRow+1);
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Bold = 1;
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Color = 3;
                        if ( AV29DynamicFiltersOperator3 == 0 )
                        {
                           AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", context.GetMessage( "Rubro", ""), context.GetMessage( "WWP_FilterLike", ""), "", "", "", "", "", "", "");
                        }
                        else if ( AV29DynamicFiltersOperator3 == 1 )
                        {
                           AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", context.GetMessage( "Rubro", ""), context.GetMessage( "WWP_FilterContains", ""), "", "", "", "", "", "", "");
                        }
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Italic = 1;
                        GXt_char2 = "";
                        new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV30RubrosNombre3, out  GXt_char2) ;
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
                     }
                  }
               }
            }
         }
         if ( ! ( (0==AV47TFRubrosId) && (0==AV48TFRubrosId_To) ) )
         {
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Rubro", "")) ;
            AV14CellRow = GXt_int3;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Number = AV47TFRubrosId;
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  false, ref  GXt_int3,  (short)(AV15FirstColumn+2),  context.GetMessage( "WWP_TSTo", "")) ;
            AV14CellRow = GXt_int3;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+3, 1, 1).Number = AV48TFRubrosId_To;
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV50TFRubrosNombre_Sel)) ) )
         {
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Rubro", "")) ;
            AV14CellRow = GXt_int3;
            GXt_char2 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV50TFRubrosNombre_Sel)) ? context.GetMessage( "WWP_TitleFilter_EmptyOption", "") : AV50TFRubrosNombre_Sel), out  GXt_char2) ;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV49TFRubrosNombre)) ) )
            {
               GXt_int3 = (short)(AV14CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Rubro", "")) ;
               AV14CellRow = GXt_int3;
               GXt_char2 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV49TFRubrosNombre, out  GXt_char2) ;
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
            }
         }
         if ( ! ( ( AV52TFRubrosEstado_Sels.Count == 0 ) ) )
         {
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Estado", "")) ;
            AV14CellRow = GXt_int3;
            AV54i = 1;
            AV56GXV1 = 1;
            while ( AV56GXV1 <= AV52TFRubrosEstado_Sels.Count )
            {
               AV53TFRubrosEstado_Sel = AV52TFRubrosEstado_Sels.GetString(AV56GXV1);
               if ( AV54i == 1 )
               {
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = "";
               }
               else
               {
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text+", ";
               }
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text+context.GetMessage( gxdomainestadoenum.getDescription(context,AV53TFRubrosEstado_Sel), "");
               AV54i = (long)(AV54i+1);
               AV56GXV1 = (int)(AV56GXV1+1);
            }
         }
         AV14CellRow = (int)(AV14CellRow+2);
      }

      protected void S141( )
      {
         /* 'WRITECOLUMNTITLES' Routine */
         returnInSub = false;
         AV44VisibleColumnCount = 0;
         if ( StringUtil.StrCmp(AV32Session.Get("RubrosMedidasWWColumnsSelector"), "") != 0 )
         {
            AV39ColumnsSelectorXML = AV32Session.Get("RubrosMedidasWWColumnsSelector");
            AV36ColumnsSelector.FromXml(AV39ColumnsSelectorXML, null, "", "");
         }
         else
         {
            /* Execute user subroutine: 'INITIALIZECOLUMNSSELECTOR' */
            S151 ();
            if (returnInSub) return;
         }
         AV36ColumnsSelector.gxTpr_Columns.Sort("Order");
         AV57GXV2 = 1;
         while ( AV57GXV2 <= AV36ColumnsSelector.gxTpr_Columns.Count )
         {
            AV38ColumnsSelector_Column = ((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV36ColumnsSelector.gxTpr_Columns.Item(AV57GXV2));
            if ( AV38ColumnsSelector_Column.gxTpr_Isvisible )
            {
               AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV44VisibleColumnCount), 1, 1).Text = context.GetMessage( (String.IsNullOrEmpty(StringUtil.RTrim( AV38ColumnsSelector_Column.gxTpr_Displayname)) ? AV38ColumnsSelector_Column.gxTpr_Columnname : AV38ColumnsSelector_Column.gxTpr_Displayname), "");
               AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV44VisibleColumnCount), 1, 1).Bold = 1;
               AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV44VisibleColumnCount), 1, 1).Color = 11;
               AV44VisibleColumnCount = (long)(AV44VisibleColumnCount+1);
            }
            AV57GXV2 = (int)(AV57GXV2+1);
         }
      }

      protected void S161( )
      {
         /* 'WRITEDATA' Routine */
         returnInSub = false;
         AV59Rubrosmedidaswwds_1_filterfulltext = AV19FilterFullText;
         AV60Rubrosmedidaswwds_2_dynamicfiltersselector1 = AV20DynamicFiltersSelector1;
         AV61Rubrosmedidaswwds_3_dynamicfiltersoperator1 = AV21DynamicFiltersOperator1;
         AV62Rubrosmedidaswwds_4_rubrosnombre1 = AV22RubrosNombre1;
         AV63Rubrosmedidaswwds_5_dynamicfiltersenabled2 = AV23DynamicFiltersEnabled2;
         AV64Rubrosmedidaswwds_6_dynamicfiltersselector2 = AV24DynamicFiltersSelector2;
         AV65Rubrosmedidaswwds_7_dynamicfiltersoperator2 = AV25DynamicFiltersOperator2;
         AV66Rubrosmedidaswwds_8_rubrosnombre2 = AV26RubrosNombre2;
         AV67Rubrosmedidaswwds_9_dynamicfiltersenabled3 = AV27DynamicFiltersEnabled3;
         AV68Rubrosmedidaswwds_10_dynamicfiltersselector3 = AV28DynamicFiltersSelector3;
         AV69Rubrosmedidaswwds_11_dynamicfiltersoperator3 = AV29DynamicFiltersOperator3;
         AV70Rubrosmedidaswwds_12_rubrosnombre3 = AV30RubrosNombre3;
         AV71Rubrosmedidaswwds_13_tfrubrosid = AV47TFRubrosId;
         AV72Rubrosmedidaswwds_14_tfrubrosid_to = AV48TFRubrosId_To;
         AV73Rubrosmedidaswwds_15_tfrubrosnombre = AV49TFRubrosNombre;
         AV74Rubrosmedidaswwds_16_tfrubrosnombre_sel = AV50TFRubrosNombre_Sel;
         AV75Rubrosmedidaswwds_17_tfrubrosestado_sels = AV52TFRubrosEstado_Sels;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A123RubrosEstado ,
                                              AV75Rubrosmedidaswwds_17_tfrubrosestado_sels ,
                                              AV60Rubrosmedidaswwds_2_dynamicfiltersselector1 ,
                                              AV61Rubrosmedidaswwds_3_dynamicfiltersoperator1 ,
                                              AV62Rubrosmedidaswwds_4_rubrosnombre1 ,
                                              AV63Rubrosmedidaswwds_5_dynamicfiltersenabled2 ,
                                              AV64Rubrosmedidaswwds_6_dynamicfiltersselector2 ,
                                              AV65Rubrosmedidaswwds_7_dynamicfiltersoperator2 ,
                                              AV66Rubrosmedidaswwds_8_rubrosnombre2 ,
                                              AV67Rubrosmedidaswwds_9_dynamicfiltersenabled3 ,
                                              AV68Rubrosmedidaswwds_10_dynamicfiltersselector3 ,
                                              AV69Rubrosmedidaswwds_11_dynamicfiltersoperator3 ,
                                              AV70Rubrosmedidaswwds_12_rubrosnombre3 ,
                                              AV71Rubrosmedidaswwds_13_tfrubrosid ,
                                              AV72Rubrosmedidaswwds_14_tfrubrosid_to ,
                                              AV74Rubrosmedidaswwds_16_tfrubrosnombre_sel ,
                                              AV73Rubrosmedidaswwds_15_tfrubrosnombre ,
                                              AV75Rubrosmedidaswwds_17_tfrubrosestado_sels.Count ,
                                              A122RubrosNombre ,
                                              A121RubrosId ,
                                              AV17OrderedBy ,
                                              AV18OrderedDsc ,
                                              AV59Rubrosmedidaswwds_1_filterfulltext } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.SHORT,
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV62Rubrosmedidaswwds_4_rubrosnombre1 = StringUtil.PadR( StringUtil.RTrim( AV62Rubrosmedidaswwds_4_rubrosnombre1), 100, "%");
         lV62Rubrosmedidaswwds_4_rubrosnombre1 = StringUtil.PadR( StringUtil.RTrim( AV62Rubrosmedidaswwds_4_rubrosnombre1), 100, "%");
         lV66Rubrosmedidaswwds_8_rubrosnombre2 = StringUtil.PadR( StringUtil.RTrim( AV66Rubrosmedidaswwds_8_rubrosnombre2), 100, "%");
         lV66Rubrosmedidaswwds_8_rubrosnombre2 = StringUtil.PadR( StringUtil.RTrim( AV66Rubrosmedidaswwds_8_rubrosnombre2), 100, "%");
         lV70Rubrosmedidaswwds_12_rubrosnombre3 = StringUtil.PadR( StringUtil.RTrim( AV70Rubrosmedidaswwds_12_rubrosnombre3), 100, "%");
         lV70Rubrosmedidaswwds_12_rubrosnombre3 = StringUtil.PadR( StringUtil.RTrim( AV70Rubrosmedidaswwds_12_rubrosnombre3), 100, "%");
         lV73Rubrosmedidaswwds_15_tfrubrosnombre = StringUtil.PadR( StringUtil.RTrim( AV73Rubrosmedidaswwds_15_tfrubrosnombre), 100, "%");
         /* Using cursor P004G2 */
         pr_default.execute(0, new Object[] {lV62Rubrosmedidaswwds_4_rubrosnombre1, lV62Rubrosmedidaswwds_4_rubrosnombre1, lV66Rubrosmedidaswwds_8_rubrosnombre2, lV66Rubrosmedidaswwds_8_rubrosnombre2, lV70Rubrosmedidaswwds_12_rubrosnombre3, lV70Rubrosmedidaswwds_12_rubrosnombre3, AV71Rubrosmedidaswwds_13_tfrubrosid, AV72Rubrosmedidaswwds_14_tfrubrosid_to, lV73Rubrosmedidaswwds_15_tfrubrosnombre, AV74Rubrosmedidaswwds_16_tfrubrosnombre_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A122RubrosNombre = P004G2_A122RubrosNombre[0];
            A121RubrosId = P004G2_A121RubrosId[0];
            A123RubrosEstado = P004G2_A123RubrosEstado[0];
            n123RubrosEstado = P004G2_n123RubrosEstado[0];
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV59Rubrosmedidaswwds_1_filterfulltext)) || ( ( StringUtil.Like( StringUtil.Str( (decimal)(A121RubrosId), 4, 0) , StringUtil.PadR( "%" + AV59Rubrosmedidaswwds_1_filterfulltext , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A122RubrosNombre) , StringUtil.PadR( "%" + StringUtil.Upper( AV59Rubrosmedidaswwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( context.GetMessage( "habilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV59Rubrosmedidaswwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A123RubrosEstado, "HAB") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "deshabilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV59Rubrosmedidaswwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A123RubrosEstado, "DES") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "pendiente", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV59Rubrosmedidaswwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A123RubrosEstado, "PEN") == 0 ) ) ) )
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
               AV76GXV3 = 1;
               while ( AV76GXV3 <= AV36ColumnsSelector.gxTpr_Columns.Count )
               {
                  AV38ColumnsSelector_Column = ((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV36ColumnsSelector.gxTpr_Columns.Item(AV76GXV3));
                  if ( AV38ColumnsSelector_Column.gxTpr_Isvisible )
                  {
                     if ( StringUtil.StrCmp(AV38ColumnsSelector_Column.gxTpr_Columnname, "RubrosId") == 0 )
                     {
                        AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV44VisibleColumnCount), 1, 1).Number = A121RubrosId;
                     }
                     else if ( StringUtil.StrCmp(AV38ColumnsSelector_Column.gxTpr_Columnname, "RubrosNombre") == 0 )
                     {
                        GXt_char2 = "";
                        new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A122RubrosNombre, out  GXt_char2) ;
                        AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV44VisibleColumnCount), 1, 1).Text = GXt_char2;
                     }
                     else if ( StringUtil.StrCmp(AV38ColumnsSelector_Column.gxTpr_Columnname, "RubrosImagen") == 0 )
                     {
                        AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV44VisibleColumnCount), 1, 1).Text = "";
                     }
                     else if ( StringUtil.StrCmp(AV38ColumnsSelector_Column.gxTpr_Columnname, "RubrosEstado") == 0 )
                     {
                        AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV44VisibleColumnCount), 1, 1).Text = context.GetMessage( gxdomainestadoenum.getDescription(context,A123RubrosEstado), "");
                     }
                     AV44VisibleColumnCount = (long)(AV44VisibleColumnCount+1);
                  }
                  AV76GXV3 = (int)(AV76GXV3+1);
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
         AV32Session.Set("WWPExportFileName", "RubrosMedidasWWExport.xlsx");
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
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV36ColumnsSelector,  "RubrosId",  "",  "Rubro",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV36ColumnsSelector,  "RubrosNombre",  "",  "Rubro",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV36ColumnsSelector,  "RubrosImagen",  "",  "Imagen",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV36ColumnsSelector,  "RubrosEstado",  "",  "Estado",  true,  "") ;
         GXt_char2 = AV40UserCustomValue;
         new GeneXus.Programs.wwpbaseobjects.loadcolumnsselectorstate(context ).execute(  "RubrosMedidasWWColumnsSelector", out  GXt_char2) ;
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
         if ( StringUtil.StrCmp(AV32Session.Get("RubrosMedidasWWGridState"), "") == 0 )
         {
            AV34GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "RubrosMedidasWWGridState"), null, "", "");
         }
         else
         {
            AV34GridState.FromXml(AV32Session.Get("RubrosMedidasWWGridState"), null, "", "");
         }
         AV17OrderedBy = AV34GridState.gxTpr_Orderedby;
         AV18OrderedDsc = AV34GridState.gxTpr_Ordereddsc;
         AV77GXV4 = 1;
         while ( AV77GXV4 <= AV34GridState.gxTpr_Filtervalues.Count )
         {
            AV35GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV34GridState.gxTpr_Filtervalues.Item(AV77GXV4));
            if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV19FilterFullText = AV35GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFRUBROSID") == 0 )
            {
               AV47TFRubrosId = (short)(Math.Round(NumberUtil.Val( AV35GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV48TFRubrosId_To = (short)(Math.Round(NumberUtil.Val( AV35GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFRUBROSNOMBRE") == 0 )
            {
               AV49TFRubrosNombre = AV35GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFRUBROSNOMBRE_SEL") == 0 )
            {
               AV50TFRubrosNombre_Sel = AV35GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFRUBROSESTADO_SEL") == 0 )
            {
               AV51TFRubrosEstado_SelsJson = AV35GridStateFilterValue.gxTpr_Value;
               AV52TFRubrosEstado_Sels.FromJSonString(AV51TFRubrosEstado_SelsJson, null);
            }
            AV77GXV4 = (int)(AV77GXV4+1);
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
         AV34GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV31GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV20DynamicFiltersSelector1 = "";
         AV22RubrosNombre1 = "";
         AV24DynamicFiltersSelector2 = "";
         AV26RubrosNombre2 = "";
         AV28DynamicFiltersSelector3 = "";
         AV30RubrosNombre3 = "";
         AV50TFRubrosNombre_Sel = "";
         AV49TFRubrosNombre = "";
         AV52TFRubrosEstado_Sels = new GxSimpleCollection<string>();
         AV53TFRubrosEstado_Sel = "";
         AV32Session = context.GetSession();
         AV39ColumnsSelectorXML = "";
         AV36ColumnsSelector = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector(context);
         AV38ColumnsSelector_Column = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column(context);
         AV59Rubrosmedidaswwds_1_filterfulltext = "";
         AV60Rubrosmedidaswwds_2_dynamicfiltersselector1 = "";
         AV62Rubrosmedidaswwds_4_rubrosnombre1 = "";
         AV64Rubrosmedidaswwds_6_dynamicfiltersselector2 = "";
         AV66Rubrosmedidaswwds_8_rubrosnombre2 = "";
         AV68Rubrosmedidaswwds_10_dynamicfiltersselector3 = "";
         AV70Rubrosmedidaswwds_12_rubrosnombre3 = "";
         AV73Rubrosmedidaswwds_15_tfrubrosnombre = "";
         AV74Rubrosmedidaswwds_16_tfrubrosnombre_sel = "";
         AV75Rubrosmedidaswwds_17_tfrubrosestado_sels = new GxSimpleCollection<string>();
         lV62Rubrosmedidaswwds_4_rubrosnombre1 = "";
         lV66Rubrosmedidaswwds_8_rubrosnombre2 = "";
         lV70Rubrosmedidaswwds_12_rubrosnombre3 = "";
         lV73Rubrosmedidaswwds_15_tfrubrosnombre = "";
         A123RubrosEstado = "";
         A122RubrosNombre = "";
         P004G2_A122RubrosNombre = new string[] {""} ;
         P004G2_A121RubrosId = new short[1] ;
         P004G2_A123RubrosEstado = new string[] {""} ;
         P004G2_n123RubrosEstado = new bool[] {false} ;
         AV40UserCustomValue = "";
         GXt_char2 = "";
         AV37ColumnsSelectorAux = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector(context);
         AV35GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV51TFRubrosEstado_SelsJson = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.rubrosmedidaswwexport__default(),
            new Object[][] {
                new Object[] {
               P004G2_A122RubrosNombre, P004G2_A121RubrosId, P004G2_A123RubrosEstado, P004G2_n123RubrosEstado
               }
            }
         );
         AV55Pgmname = "RubrosMedidasWWExport";
         /* GeneXus formulas. */
         AV55Pgmname = "RubrosMedidasWWExport";
      }

      private short AV21DynamicFiltersOperator1 ;
      private short AV25DynamicFiltersOperator2 ;
      private short AV29DynamicFiltersOperator3 ;
      private short AV47TFRubrosId ;
      private short AV48TFRubrosId_To ;
      private short GXt_int3 ;
      private short AV61Rubrosmedidaswwds_3_dynamicfiltersoperator1 ;
      private short AV65Rubrosmedidaswwds_7_dynamicfiltersoperator2 ;
      private short AV69Rubrosmedidaswwds_11_dynamicfiltersoperator3 ;
      private short AV71Rubrosmedidaswwds_13_tfrubrosid ;
      private short AV72Rubrosmedidaswwds_14_tfrubrosid_to ;
      private short A121RubrosId ;
      private short AV17OrderedBy ;
      private int AV14CellRow ;
      private int AV15FirstColumn ;
      private int AV16Random ;
      private int AV56GXV1 ;
      private int AV57GXV2 ;
      private int AV75Rubrosmedidaswwds_17_tfrubrosestado_sels_Count ;
      private int AV76GXV3 ;
      private int AV77GXV4 ;
      private long AV54i ;
      private long AV44VisibleColumnCount ;
      private string AV55Pgmname ;
      private string GXKey ;
      private string GXEncryptionTmp ;
      private string AV22RubrosNombre1 ;
      private string AV26RubrosNombre2 ;
      private string AV30RubrosNombre3 ;
      private string AV50TFRubrosNombre_Sel ;
      private string AV49TFRubrosNombre ;
      private string AV53TFRubrosEstado_Sel ;
      private string AV62Rubrosmedidaswwds_4_rubrosnombre1 ;
      private string AV66Rubrosmedidaswwds_8_rubrosnombre2 ;
      private string AV70Rubrosmedidaswwds_12_rubrosnombre3 ;
      private string AV73Rubrosmedidaswwds_15_tfrubrosnombre ;
      private string AV74Rubrosmedidaswwds_16_tfrubrosnombre_sel ;
      private string lV62Rubrosmedidaswwds_4_rubrosnombre1 ;
      private string lV66Rubrosmedidaswwds_8_rubrosnombre2 ;
      private string lV70Rubrosmedidaswwds_12_rubrosnombre3 ;
      private string lV73Rubrosmedidaswwds_15_tfrubrosnombre ;
      private string A123RubrosEstado ;
      private string A122RubrosNombre ;
      private string GXt_char2 ;
      private bool AV8IsAuthorized ;
      private bool GXt_boolean1 ;
      private bool returnInSub ;
      private bool AV23DynamicFiltersEnabled2 ;
      private bool AV27DynamicFiltersEnabled3 ;
      private bool AV63Rubrosmedidaswwds_5_dynamicfiltersenabled2 ;
      private bool AV67Rubrosmedidaswwds_9_dynamicfiltersenabled3 ;
      private bool AV18OrderedDsc ;
      private bool n123RubrosEstado ;
      private string AV39ColumnsSelectorXML ;
      private string AV40UserCustomValue ;
      private string AV51TFRubrosEstado_SelsJson ;
      private string AV12Filename ;
      private string AV13ErrorMessage ;
      private string AV19FilterFullText ;
      private string AV20DynamicFiltersSelector1 ;
      private string AV24DynamicFiltersSelector2 ;
      private string AV28DynamicFiltersSelector3 ;
      private string AV59Rubrosmedidaswwds_1_filterfulltext ;
      private string AV60Rubrosmedidaswwds_2_dynamicfiltersselector1 ;
      private string AV64Rubrosmedidaswwds_6_dynamicfiltersselector2 ;
      private string AV68Rubrosmedidaswwds_10_dynamicfiltersselector3 ;
      private IGxSession AV32Session ;
      private ExcelDocumentI AV11ExcelDocument ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV34GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV31GridStateDynamicFilter ;
      private GxSimpleCollection<string> AV52TFRubrosEstado_Sels ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector AV36ColumnsSelector ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column AV38ColumnsSelector_Column ;
      private GxSimpleCollection<string> AV75Rubrosmedidaswwds_17_tfrubrosestado_sels ;
      private IDataStoreProvider pr_default ;
      private string[] P004G2_A122RubrosNombre ;
      private short[] P004G2_A121RubrosId ;
      private string[] P004G2_A123RubrosEstado ;
      private bool[] P004G2_n123RubrosEstado ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector AV37ColumnsSelectorAux ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV35GridStateFilterValue ;
      private string aP0_Filename ;
      private string aP1_ErrorMessage ;
   }

   public class rubrosmedidaswwexport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P004G2( IGxContext context ,
                                             string A123RubrosEstado ,
                                             GxSimpleCollection<string> AV75Rubrosmedidaswwds_17_tfrubrosestado_sels ,
                                             string AV60Rubrosmedidaswwds_2_dynamicfiltersselector1 ,
                                             short AV61Rubrosmedidaswwds_3_dynamicfiltersoperator1 ,
                                             string AV62Rubrosmedidaswwds_4_rubrosnombre1 ,
                                             bool AV63Rubrosmedidaswwds_5_dynamicfiltersenabled2 ,
                                             string AV64Rubrosmedidaswwds_6_dynamicfiltersselector2 ,
                                             short AV65Rubrosmedidaswwds_7_dynamicfiltersoperator2 ,
                                             string AV66Rubrosmedidaswwds_8_rubrosnombre2 ,
                                             bool AV67Rubrosmedidaswwds_9_dynamicfiltersenabled3 ,
                                             string AV68Rubrosmedidaswwds_10_dynamicfiltersselector3 ,
                                             short AV69Rubrosmedidaswwds_11_dynamicfiltersoperator3 ,
                                             string AV70Rubrosmedidaswwds_12_rubrosnombre3 ,
                                             short AV71Rubrosmedidaswwds_13_tfrubrosid ,
                                             short AV72Rubrosmedidaswwds_14_tfrubrosid_to ,
                                             string AV74Rubrosmedidaswwds_16_tfrubrosnombre_sel ,
                                             string AV73Rubrosmedidaswwds_15_tfrubrosnombre ,
                                             int AV75Rubrosmedidaswwds_17_tfrubrosestado_sels_Count ,
                                             string A122RubrosNombre ,
                                             short A121RubrosId ,
                                             short AV17OrderedBy ,
                                             bool AV18OrderedDsc ,
                                             string AV59Rubrosmedidaswwds_1_filterfulltext )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int4 = new short[10];
         Object[] GXv_Object5 = new Object[2];
         scmdbuf = "SELECT [RubrosNombre], [RubrosId], [RubrosEstado] FROM [Rubros]";
         if ( ( StringUtil.StrCmp(AV60Rubrosmedidaswwds_2_dynamicfiltersselector1, "RUBROSNOMBRE") == 0 ) && ( AV61Rubrosmedidaswwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Rubrosmedidaswwds_4_rubrosnombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER([RubrosNombre]) like UPPER(@lV62Rubrosmedidaswwds_4_rubrosnombre1))");
         }
         else
         {
            GXv_int4[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV60Rubrosmedidaswwds_2_dynamicfiltersselector1, "RUBROSNOMBRE") == 0 ) && ( AV61Rubrosmedidaswwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Rubrosmedidaswwds_4_rubrosnombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER([RubrosNombre]) like '%' + UPPER(@lV62Rubrosmedidaswwds_4_rubrosnombre1))");
         }
         else
         {
            GXv_int4[1] = 1;
         }
         if ( AV63Rubrosmedidaswwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV64Rubrosmedidaswwds_6_dynamicfiltersselector2, "RUBROSNOMBRE") == 0 ) && ( AV65Rubrosmedidaswwds_7_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Rubrosmedidaswwds_8_rubrosnombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER([RubrosNombre]) like UPPER(@lV66Rubrosmedidaswwds_8_rubrosnombre2))");
         }
         else
         {
            GXv_int4[2] = 1;
         }
         if ( AV63Rubrosmedidaswwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV64Rubrosmedidaswwds_6_dynamicfiltersselector2, "RUBROSNOMBRE") == 0 ) && ( AV65Rubrosmedidaswwds_7_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Rubrosmedidaswwds_8_rubrosnombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER([RubrosNombre]) like '%' + UPPER(@lV66Rubrosmedidaswwds_8_rubrosnombre2))");
         }
         else
         {
            GXv_int4[3] = 1;
         }
         if ( AV67Rubrosmedidaswwds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV68Rubrosmedidaswwds_10_dynamicfiltersselector3, "RUBROSNOMBRE") == 0 ) && ( AV69Rubrosmedidaswwds_11_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Rubrosmedidaswwds_12_rubrosnombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER([RubrosNombre]) like UPPER(@lV70Rubrosmedidaswwds_12_rubrosnombre3))");
         }
         else
         {
            GXv_int4[4] = 1;
         }
         if ( AV67Rubrosmedidaswwds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV68Rubrosmedidaswwds_10_dynamicfiltersselector3, "RUBROSNOMBRE") == 0 ) && ( AV69Rubrosmedidaswwds_11_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Rubrosmedidaswwds_12_rubrosnombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER([RubrosNombre]) like '%' + UPPER(@lV70Rubrosmedidaswwds_12_rubrosnombre3))");
         }
         else
         {
            GXv_int4[5] = 1;
         }
         if ( ! (0==AV71Rubrosmedidaswwds_13_tfrubrosid) )
         {
            AddWhere(sWhereString, "([RubrosId] >= @AV71Rubrosmedidaswwds_13_tfrubrosid)");
         }
         else
         {
            GXv_int4[6] = 1;
         }
         if ( ! (0==AV72Rubrosmedidaswwds_14_tfrubrosid_to) )
         {
            AddWhere(sWhereString, "([RubrosId] <= @AV72Rubrosmedidaswwds_14_tfrubrosid_to)");
         }
         else
         {
            GXv_int4[7] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV74Rubrosmedidaswwds_16_tfrubrosnombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Rubrosmedidaswwds_15_tfrubrosnombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER([RubrosNombre]) like UPPER(@lV73Rubrosmedidaswwds_15_tfrubrosnombre))");
         }
         else
         {
            GXv_int4[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Rubrosmedidaswwds_16_tfrubrosnombre_sel)) && ! ( StringUtil.StrCmp(AV74Rubrosmedidaswwds_16_tfrubrosnombre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([RubrosNombre] = @AV74Rubrosmedidaswwds_16_tfrubrosnombre_sel)");
         }
         else
         {
            GXv_int4[9] = 1;
         }
         if ( StringUtil.StrCmp(AV74Rubrosmedidaswwds_16_tfrubrosnombre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([RubrosNombre] = ''))");
         }
         if ( AV75Rubrosmedidaswwds_17_tfrubrosestado_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV75Rubrosmedidaswwds_17_tfrubrosestado_sels, "[RubrosEstado] IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         if ( ( AV17OrderedBy == 1 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY [RubrosNombre]";
         }
         else if ( ( AV17OrderedBy == 1 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [RubrosNombre] DESC";
         }
         else if ( ( AV17OrderedBy == 2 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY [RubrosId]";
         }
         else if ( ( AV17OrderedBy == 2 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [RubrosId] DESC";
         }
         else if ( ( AV17OrderedBy == 3 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY [RubrosEstado]";
         }
         else if ( ( AV17OrderedBy == 3 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [RubrosEstado] DESC";
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
                     return conditional_P004G2(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (bool)dynConstraints[5] , (string)dynConstraints[6] , (short)dynConstraints[7] , (string)dynConstraints[8] , (bool)dynConstraints[9] , (string)dynConstraints[10] , (short)dynConstraints[11] , (string)dynConstraints[12] , (short)dynConstraints[13] , (short)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (int)dynConstraints[17] , (string)dynConstraints[18] , (short)dynConstraints[19] , (short)dynConstraints[20] , (bool)dynConstraints[21] , (string)dynConstraints[22] );
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
          Object[] prmP004G2;
          prmP004G2 = new Object[] {
          new ParDef("@lV62Rubrosmedidaswwds_4_rubrosnombre1",GXType.Char,100,0) ,
          new ParDef("@lV62Rubrosmedidaswwds_4_rubrosnombre1",GXType.Char,100,0) ,
          new ParDef("@lV66Rubrosmedidaswwds_8_rubrosnombre2",GXType.Char,100,0) ,
          new ParDef("@lV66Rubrosmedidaswwds_8_rubrosnombre2",GXType.Char,100,0) ,
          new ParDef("@lV70Rubrosmedidaswwds_12_rubrosnombre3",GXType.Char,100,0) ,
          new ParDef("@lV70Rubrosmedidaswwds_12_rubrosnombre3",GXType.Char,100,0) ,
          new ParDef("@AV71Rubrosmedidaswwds_13_tfrubrosid",GXType.Int16,4,0) ,
          new ParDef("@AV72Rubrosmedidaswwds_14_tfrubrosid_to",GXType.Int16,4,0) ,
          new ParDef("@lV73Rubrosmedidaswwds_15_tfrubrosnombre",GXType.Char,100,0) ,
          new ParDef("@AV74Rubrosmedidaswwds_16_tfrubrosnombre_sel",GXType.NChar,100,0)
          };
          def= new CursorDef[] {
              new CursorDef("P004G2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP004G2,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[0])[0] = rslt.getString(1, 100);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 3);
                ((bool[]) buf[3])[0] = rslt.wasNull(3);
                return;
       }
    }

 }

}

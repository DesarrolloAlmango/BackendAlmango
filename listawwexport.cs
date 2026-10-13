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
   public class listawwexport : GXProcedure
   {
      public listawwexport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public listawwexport( IGxContext context )
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
         new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWLista", out  GXt_boolean1) ;
         AV8IsAuthorized = GXt_boolean1;
         if ( ! AV8IsAuthorized )
         {
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "wwpbaseobjects.notauthorized.aspx"+GXUtil.UrlEncode(StringUtil.RTrim(AV58Pgmname));
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
         AV12Filename = GXt_char2 + "ListaWWExport-" + StringUtil.Trim( StringUtil.Str( (decimal)(AV16Random), 8, 0)) + ".xlsx";
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
            if ( StringUtil.StrCmp(AV20DynamicFiltersSelector1, "LISTANOMBRE") == 0 )
            {
               AV21DynamicFiltersOperator1 = AV31GridStateDynamicFilter.gxTpr_Operator;
               AV22ListaNombre1 = AV31GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV22ListaNombre1)) )
               {
                  AV14CellRow = (int)(AV14CellRow+1);
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Bold = 1;
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Color = 3;
                  if ( AV21DynamicFiltersOperator1 == 0 )
                  {
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", context.GetMessage( "Nombre", ""), context.GetMessage( "WWP_FilterLike", ""), "", "", "", "", "", "", "");
                  }
                  else if ( AV21DynamicFiltersOperator1 == 1 )
                  {
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", context.GetMessage( "Nombre", ""), context.GetMessage( "WWP_FilterContains", ""), "", "", "", "", "", "", "");
                  }
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Italic = 1;
                  GXt_char2 = "";
                  new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV22ListaNombre1, out  GXt_char2) ;
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
               }
            }
            if ( AV34GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV23DynamicFiltersEnabled2 = true;
               AV31GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV34GridState.gxTpr_Dynamicfilters.Item(2));
               AV24DynamicFiltersSelector2 = AV31GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV24DynamicFiltersSelector2, "LISTANOMBRE") == 0 )
               {
                  AV25DynamicFiltersOperator2 = AV31GridStateDynamicFilter.gxTpr_Operator;
                  AV26ListaNombre2 = AV31GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV26ListaNombre2)) )
                  {
                     AV14CellRow = (int)(AV14CellRow+1);
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Bold = 1;
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Color = 3;
                     if ( AV25DynamicFiltersOperator2 == 0 )
                     {
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", context.GetMessage( "Nombre", ""), context.GetMessage( "WWP_FilterLike", ""), "", "", "", "", "", "", "");
                     }
                     else if ( AV25DynamicFiltersOperator2 == 1 )
                     {
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", context.GetMessage( "Nombre", ""), context.GetMessage( "WWP_FilterContains", ""), "", "", "", "", "", "", "");
                     }
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Italic = 1;
                     GXt_char2 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV26ListaNombre2, out  GXt_char2) ;
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
                  }
               }
               if ( AV34GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV27DynamicFiltersEnabled3 = true;
                  AV31GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV34GridState.gxTpr_Dynamicfilters.Item(3));
                  AV28DynamicFiltersSelector3 = AV31GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV28DynamicFiltersSelector3, "LISTANOMBRE") == 0 )
                  {
                     AV29DynamicFiltersOperator3 = AV31GridStateDynamicFilter.gxTpr_Operator;
                     AV30ListaNombre3 = AV31GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV30ListaNombre3)) )
                     {
                        AV14CellRow = (int)(AV14CellRow+1);
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Bold = 1;
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Color = 3;
                        if ( AV29DynamicFiltersOperator3 == 0 )
                        {
                           AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", context.GetMessage( "Nombre", ""), context.GetMessage( "WWP_FilterLike", ""), "", "", "", "", "", "", "");
                        }
                        else if ( AV29DynamicFiltersOperator3 == 1 )
                        {
                           AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", context.GetMessage( "Nombre", ""), context.GetMessage( "WWP_FilterContains", ""), "", "", "", "", "", "", "");
                        }
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Italic = 1;
                        GXt_char2 = "";
                        new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV30ListaNombre3, out  GXt_char2) ;
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
                     }
                  }
               }
            }
         }
         if ( ! ( (0==AV47TFListaid) && (0==AV48TFListaid_To) ) )
         {
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Listaid", "")) ;
            AV14CellRow = GXt_int3;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Number = AV47TFListaid;
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  false, ref  GXt_int3,  (short)(AV15FirstColumn+2),  context.GetMessage( "WWP_TSTo", "")) ;
            AV14CellRow = GXt_int3;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+3, 1, 1).Number = AV48TFListaid_To;
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV50TFListaNombre_Sel)) ) )
         {
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Nombre", "")) ;
            AV14CellRow = GXt_int3;
            GXt_char2 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV50TFListaNombre_Sel)) ? context.GetMessage( "WWP_TitleFilter_EmptyOption", "") : AV50TFListaNombre_Sel), out  GXt_char2) ;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV49TFListaNombre)) ) )
            {
               GXt_int3 = (short)(AV14CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Nombre", "")) ;
               AV14CellRow = GXt_int3;
               GXt_char2 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV49TFListaNombre, out  GXt_char2) ;
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
            }
         }
         if ( ! ( ( AV52TFListaTipo_Sels.Count == 0 ) ) )
         {
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Tipo", "")) ;
            AV14CellRow = GXt_int3;
            AV57i = 1;
            AV59GXV1 = 1;
            while ( AV59GXV1 <= AV52TFListaTipo_Sels.Count )
            {
               AV53TFListaTipo_Sel = AV52TFListaTipo_Sels.GetString(AV59GXV1);
               if ( AV57i == 1 )
               {
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = "";
               }
               else
               {
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text+", ";
               }
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text+context.GetMessage( gxdomainlistatipoenum.getDescription(context,AV53TFListaTipo_Sel), "");
               AV57i = (long)(AV57i+1);
               AV59GXV1 = (int)(AV59GXV1+1);
            }
         }
         if ( ! ( ( AV55TFListaEstado_Sels.Count == 0 ) ) )
         {
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Estado", "")) ;
            AV14CellRow = GXt_int3;
            AV57i = 1;
            AV60GXV2 = 1;
            while ( AV60GXV2 <= AV55TFListaEstado_Sels.Count )
            {
               AV56TFListaEstado_Sel = AV55TFListaEstado_Sels.GetString(AV60GXV2);
               if ( AV57i == 1 )
               {
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = "";
               }
               else
               {
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text+", ";
               }
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text+context.GetMessage( gxdomainestadoenum.getDescription(context,AV56TFListaEstado_Sel), "");
               AV57i = (long)(AV57i+1);
               AV60GXV2 = (int)(AV60GXV2+1);
            }
         }
         AV14CellRow = (int)(AV14CellRow+2);
      }

      protected void S141( )
      {
         /* 'WRITECOLUMNTITLES' Routine */
         returnInSub = false;
         AV44VisibleColumnCount = 0;
         if ( StringUtil.StrCmp(AV32Session.Get("ListaWWColumnsSelector"), "") != 0 )
         {
            AV39ColumnsSelectorXML = AV32Session.Get("ListaWWColumnsSelector");
            AV36ColumnsSelector.FromXml(AV39ColumnsSelectorXML, null, "", "");
         }
         else
         {
            /* Execute user subroutine: 'INITIALIZECOLUMNSSELECTOR' */
            S151 ();
            if (returnInSub) return;
         }
         AV36ColumnsSelector.gxTpr_Columns.Sort("Order");
         AV61GXV3 = 1;
         while ( AV61GXV3 <= AV36ColumnsSelector.gxTpr_Columns.Count )
         {
            AV38ColumnsSelector_Column = ((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV36ColumnsSelector.gxTpr_Columns.Item(AV61GXV3));
            if ( AV38ColumnsSelector_Column.gxTpr_Isvisible )
            {
               AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV44VisibleColumnCount), 1, 1).Text = context.GetMessage( (String.IsNullOrEmpty(StringUtil.RTrim( AV38ColumnsSelector_Column.gxTpr_Displayname)) ? AV38ColumnsSelector_Column.gxTpr_Columnname : AV38ColumnsSelector_Column.gxTpr_Displayname), "");
               AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV44VisibleColumnCount), 1, 1).Bold = 1;
               AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV44VisibleColumnCount), 1, 1).Color = 11;
               AV44VisibleColumnCount = (long)(AV44VisibleColumnCount+1);
            }
            AV61GXV3 = (int)(AV61GXV3+1);
         }
      }

      protected void S161( )
      {
         /* 'WRITEDATA' Routine */
         returnInSub = false;
         AV63Listawwds_1_filterfulltext = AV19FilterFullText;
         AV64Listawwds_2_dynamicfiltersselector1 = AV20DynamicFiltersSelector1;
         AV65Listawwds_3_dynamicfiltersoperator1 = AV21DynamicFiltersOperator1;
         AV66Listawwds_4_listanombre1 = AV22ListaNombre1;
         AV67Listawwds_5_dynamicfiltersenabled2 = AV23DynamicFiltersEnabled2;
         AV68Listawwds_6_dynamicfiltersselector2 = AV24DynamicFiltersSelector2;
         AV69Listawwds_7_dynamicfiltersoperator2 = AV25DynamicFiltersOperator2;
         AV70Listawwds_8_listanombre2 = AV26ListaNombre2;
         AV71Listawwds_9_dynamicfiltersenabled3 = AV27DynamicFiltersEnabled3;
         AV72Listawwds_10_dynamicfiltersselector3 = AV28DynamicFiltersSelector3;
         AV73Listawwds_11_dynamicfiltersoperator3 = AV29DynamicFiltersOperator3;
         AV74Listawwds_12_listanombre3 = AV30ListaNombre3;
         AV75Listawwds_13_tflistaid = AV47TFListaid;
         AV76Listawwds_14_tflistaid_to = AV48TFListaid_To;
         AV77Listawwds_15_tflistanombre = AV49TFListaNombre;
         AV78Listawwds_16_tflistanombre_sel = AV50TFListaNombre_Sel;
         AV79Listawwds_17_tflistatipo_sels = AV52TFListaTipo_Sels;
         AV80Listawwds_18_tflistaestado_sels = AV55TFListaEstado_Sels;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A591ListaTipo ,
                                              AV79Listawwds_17_tflistatipo_sels ,
                                              A593ListaEstado ,
                                              AV80Listawwds_18_tflistaestado_sels ,
                                              AV64Listawwds_2_dynamicfiltersselector1 ,
                                              AV65Listawwds_3_dynamicfiltersoperator1 ,
                                              AV66Listawwds_4_listanombre1 ,
                                              AV67Listawwds_5_dynamicfiltersenabled2 ,
                                              AV68Listawwds_6_dynamicfiltersselector2 ,
                                              AV69Listawwds_7_dynamicfiltersoperator2 ,
                                              AV70Listawwds_8_listanombre2 ,
                                              AV71Listawwds_9_dynamicfiltersenabled3 ,
                                              AV72Listawwds_10_dynamicfiltersselector3 ,
                                              AV73Listawwds_11_dynamicfiltersoperator3 ,
                                              AV74Listawwds_12_listanombre3 ,
                                              AV75Listawwds_13_tflistaid ,
                                              AV76Listawwds_14_tflistaid_to ,
                                              AV78Listawwds_16_tflistanombre_sel ,
                                              AV77Listawwds_15_tflistanombre ,
                                              AV79Listawwds_17_tflistatipo_sels.Count ,
                                              AV80Listawwds_18_tflistaestado_sels.Count ,
                                              A592ListaNombre ,
                                              A590Listaid ,
                                              AV17OrderedBy ,
                                              AV18OrderedDsc ,
                                              AV63Listawwds_1_filterfulltext } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.INT, TypeConstants.INT,
                                              TypeConstants.LONG, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV66Listawwds_4_listanombre1 = StringUtil.PadR( StringUtil.RTrim( AV66Listawwds_4_listanombre1), 80, "%");
         lV66Listawwds_4_listanombre1 = StringUtil.PadR( StringUtil.RTrim( AV66Listawwds_4_listanombre1), 80, "%");
         lV70Listawwds_8_listanombre2 = StringUtil.PadR( StringUtil.RTrim( AV70Listawwds_8_listanombre2), 80, "%");
         lV70Listawwds_8_listanombre2 = StringUtil.PadR( StringUtil.RTrim( AV70Listawwds_8_listanombre2), 80, "%");
         lV74Listawwds_12_listanombre3 = StringUtil.PadR( StringUtil.RTrim( AV74Listawwds_12_listanombre3), 80, "%");
         lV74Listawwds_12_listanombre3 = StringUtil.PadR( StringUtil.RTrim( AV74Listawwds_12_listanombre3), 80, "%");
         lV77Listawwds_15_tflistanombre = StringUtil.PadR( StringUtil.RTrim( AV77Listawwds_15_tflistanombre), 80, "%");
         /* Using cursor P007B2 */
         pr_default.execute(0, new Object[] {lV66Listawwds_4_listanombre1, lV66Listawwds_4_listanombre1, lV70Listawwds_8_listanombre2, lV70Listawwds_8_listanombre2, lV74Listawwds_12_listanombre3, lV74Listawwds_12_listanombre3, AV75Listawwds_13_tflistaid, AV76Listawwds_14_tflistaid_to, lV77Listawwds_15_tflistanombre, AV78Listawwds_16_tflistanombre_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A592ListaNombre = P007B2_A592ListaNombre[0];
            A590Listaid = P007B2_A590Listaid[0];
            A593ListaEstado = P007B2_A593ListaEstado[0];
            n593ListaEstado = P007B2_n593ListaEstado[0];
            A591ListaTipo = P007B2_A591ListaTipo[0];
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV63Listawwds_1_filterfulltext)) || ( ( StringUtil.Like( StringUtil.Str( (decimal)(A590Listaid), 18, 0) , StringUtil.PadR( "%" + AV63Listawwds_1_filterfulltext , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A592ListaNombre) , StringUtil.PadR( "%" + StringUtil.Upper( AV63Listawwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( context.GetMessage( "proveedor", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV63Listawwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A591ListaTipo, "PROV") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "profesional", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV63Listawwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A591ListaTipo, "PROF") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "administrativa", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV63Listawwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A591ListaTipo, "ADM") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "habilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV63Listawwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A593ListaEstado, "HAB") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "deshabilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV63Listawwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A593ListaEstado, "DES") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "pendiente", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV63Listawwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A593ListaEstado, "PEN") == 0 ) ) ) )
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
               AV81GXV4 = 1;
               while ( AV81GXV4 <= AV36ColumnsSelector.gxTpr_Columns.Count )
               {
                  AV38ColumnsSelector_Column = ((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV36ColumnsSelector.gxTpr_Columns.Item(AV81GXV4));
                  if ( AV38ColumnsSelector_Column.gxTpr_Isvisible )
                  {
                     if ( StringUtil.StrCmp(AV38ColumnsSelector_Column.gxTpr_Columnname, "Listaid") == 0 )
                     {
                        AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV44VisibleColumnCount), 1, 1).Number = A590Listaid;
                     }
                     else if ( StringUtil.StrCmp(AV38ColumnsSelector_Column.gxTpr_Columnname, "ListaNombre") == 0 )
                     {
                        GXt_char2 = "";
                        new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A592ListaNombre, out  GXt_char2) ;
                        AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV44VisibleColumnCount), 1, 1).Text = GXt_char2;
                     }
                     else if ( StringUtil.StrCmp(AV38ColumnsSelector_Column.gxTpr_Columnname, "ListaTipo") == 0 )
                     {
                        AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV44VisibleColumnCount), 1, 1).Text = context.GetMessage( gxdomainlistatipoenum.getDescription(context,A591ListaTipo), "");
                     }
                     else if ( StringUtil.StrCmp(AV38ColumnsSelector_Column.gxTpr_Columnname, "ListaEstado") == 0 )
                     {
                        AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV44VisibleColumnCount), 1, 1).Text = context.GetMessage( gxdomainestadoenum.getDescription(context,A593ListaEstado), "");
                     }
                     AV44VisibleColumnCount = (long)(AV44VisibleColumnCount+1);
                  }
                  AV81GXV4 = (int)(AV81GXV4+1);
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
         AV32Session.Set("WWPExportFileName", "ListaWWExport.xlsx");
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
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV36ColumnsSelector,  "Listaid",  "",  "Listaid",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV36ColumnsSelector,  "ListaNombre",  "",  "Nombre",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV36ColumnsSelector,  "ListaTipo",  "",  "Tipo",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV36ColumnsSelector,  "ListaEstado",  "",  "Estado",  true,  "") ;
         GXt_char2 = AV40UserCustomValue;
         new GeneXus.Programs.wwpbaseobjects.loadcolumnsselectorstate(context ).execute(  "ListaWWColumnsSelector", out  GXt_char2) ;
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
         if ( StringUtil.StrCmp(AV32Session.Get("ListaWWGridState"), "") == 0 )
         {
            AV34GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "ListaWWGridState"), null, "", "");
         }
         else
         {
            AV34GridState.FromXml(AV32Session.Get("ListaWWGridState"), null, "", "");
         }
         AV17OrderedBy = AV34GridState.gxTpr_Orderedby;
         AV18OrderedDsc = AV34GridState.gxTpr_Ordereddsc;
         AV82GXV5 = 1;
         while ( AV82GXV5 <= AV34GridState.gxTpr_Filtervalues.Count )
         {
            AV35GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV34GridState.gxTpr_Filtervalues.Item(AV82GXV5));
            if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV19FilterFullText = AV35GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFLISTAID") == 0 )
            {
               AV47TFListaid = (long)(Math.Round(NumberUtil.Val( AV35GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV48TFListaid_To = (long)(Math.Round(NumberUtil.Val( AV35GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFLISTANOMBRE") == 0 )
            {
               AV49TFListaNombre = AV35GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFLISTANOMBRE_SEL") == 0 )
            {
               AV50TFListaNombre_Sel = AV35GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFLISTATIPO_SEL") == 0 )
            {
               AV51TFListaTipo_SelsJson = AV35GridStateFilterValue.gxTpr_Value;
               AV52TFListaTipo_Sels.FromJSonString(AV51TFListaTipo_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFLISTAESTADO_SEL") == 0 )
            {
               AV54TFListaEstado_SelsJson = AV35GridStateFilterValue.gxTpr_Value;
               AV55TFListaEstado_Sels.FromJSonString(AV54TFListaEstado_SelsJson, null);
            }
            AV82GXV5 = (int)(AV82GXV5+1);
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
         AV58Pgmname = "";
         GXKey = "";
         GXEncryptionTmp = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV11ExcelDocument = new ExcelDocumentI();
         AV19FilterFullText = "";
         AV34GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV31GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV20DynamicFiltersSelector1 = "";
         AV22ListaNombre1 = "";
         AV24DynamicFiltersSelector2 = "";
         AV26ListaNombre2 = "";
         AV28DynamicFiltersSelector3 = "";
         AV30ListaNombre3 = "";
         AV50TFListaNombre_Sel = "";
         AV49TFListaNombre = "";
         AV52TFListaTipo_Sels = new GxSimpleCollection<string>();
         AV53TFListaTipo_Sel = "";
         AV55TFListaEstado_Sels = new GxSimpleCollection<string>();
         AV56TFListaEstado_Sel = "";
         AV32Session = context.GetSession();
         AV39ColumnsSelectorXML = "";
         AV36ColumnsSelector = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector(context);
         AV38ColumnsSelector_Column = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column(context);
         AV63Listawwds_1_filterfulltext = "";
         AV64Listawwds_2_dynamicfiltersselector1 = "";
         AV66Listawwds_4_listanombre1 = "";
         AV68Listawwds_6_dynamicfiltersselector2 = "";
         AV70Listawwds_8_listanombre2 = "";
         AV72Listawwds_10_dynamicfiltersselector3 = "";
         AV74Listawwds_12_listanombre3 = "";
         AV77Listawwds_15_tflistanombre = "";
         AV78Listawwds_16_tflistanombre_sel = "";
         AV79Listawwds_17_tflistatipo_sels = new GxSimpleCollection<string>();
         AV80Listawwds_18_tflistaestado_sels = new GxSimpleCollection<string>();
         lV66Listawwds_4_listanombre1 = "";
         lV70Listawwds_8_listanombre2 = "";
         lV74Listawwds_12_listanombre3 = "";
         lV77Listawwds_15_tflistanombre = "";
         A591ListaTipo = "";
         A593ListaEstado = "";
         A592ListaNombre = "";
         P007B2_A592ListaNombre = new string[] {""} ;
         P007B2_A590Listaid = new long[1] ;
         P007B2_A593ListaEstado = new string[] {""} ;
         P007B2_n593ListaEstado = new bool[] {false} ;
         P007B2_A591ListaTipo = new string[] {""} ;
         AV40UserCustomValue = "";
         GXt_char2 = "";
         AV37ColumnsSelectorAux = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector(context);
         AV35GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV51TFListaTipo_SelsJson = "";
         AV54TFListaEstado_SelsJson = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.listawwexport__default(),
            new Object[][] {
                new Object[] {
               P007B2_A592ListaNombre, P007B2_A590Listaid, P007B2_A593ListaEstado, P007B2_n593ListaEstado, P007B2_A591ListaTipo
               }
            }
         );
         AV58Pgmname = "ListaWWExport";
         /* GeneXus formulas. */
         AV58Pgmname = "ListaWWExport";
      }

      private short AV21DynamicFiltersOperator1 ;
      private short AV25DynamicFiltersOperator2 ;
      private short AV29DynamicFiltersOperator3 ;
      private short GXt_int3 ;
      private short AV65Listawwds_3_dynamicfiltersoperator1 ;
      private short AV69Listawwds_7_dynamicfiltersoperator2 ;
      private short AV73Listawwds_11_dynamicfiltersoperator3 ;
      private short AV17OrderedBy ;
      private int AV14CellRow ;
      private int AV15FirstColumn ;
      private int AV16Random ;
      private int AV59GXV1 ;
      private int AV60GXV2 ;
      private int AV61GXV3 ;
      private int AV79Listawwds_17_tflistatipo_sels_Count ;
      private int AV80Listawwds_18_tflistaestado_sels_Count ;
      private int AV81GXV4 ;
      private int AV82GXV5 ;
      private long AV47TFListaid ;
      private long AV48TFListaid_To ;
      private long AV57i ;
      private long AV44VisibleColumnCount ;
      private long AV75Listawwds_13_tflistaid ;
      private long AV76Listawwds_14_tflistaid_to ;
      private long A590Listaid ;
      private string AV58Pgmname ;
      private string GXKey ;
      private string GXEncryptionTmp ;
      private string AV22ListaNombre1 ;
      private string AV26ListaNombre2 ;
      private string AV30ListaNombre3 ;
      private string AV50TFListaNombre_Sel ;
      private string AV49TFListaNombre ;
      private string AV53TFListaTipo_Sel ;
      private string AV56TFListaEstado_Sel ;
      private string AV66Listawwds_4_listanombre1 ;
      private string AV70Listawwds_8_listanombre2 ;
      private string AV74Listawwds_12_listanombre3 ;
      private string AV77Listawwds_15_tflistanombre ;
      private string AV78Listawwds_16_tflistanombre_sel ;
      private string lV66Listawwds_4_listanombre1 ;
      private string lV70Listawwds_8_listanombre2 ;
      private string lV74Listawwds_12_listanombre3 ;
      private string lV77Listawwds_15_tflistanombre ;
      private string A591ListaTipo ;
      private string A593ListaEstado ;
      private string A592ListaNombre ;
      private string GXt_char2 ;
      private bool AV8IsAuthorized ;
      private bool GXt_boolean1 ;
      private bool returnInSub ;
      private bool AV23DynamicFiltersEnabled2 ;
      private bool AV27DynamicFiltersEnabled3 ;
      private bool AV67Listawwds_5_dynamicfiltersenabled2 ;
      private bool AV71Listawwds_9_dynamicfiltersenabled3 ;
      private bool AV18OrderedDsc ;
      private bool n593ListaEstado ;
      private string AV39ColumnsSelectorXML ;
      private string AV40UserCustomValue ;
      private string AV51TFListaTipo_SelsJson ;
      private string AV54TFListaEstado_SelsJson ;
      private string AV12Filename ;
      private string AV13ErrorMessage ;
      private string AV19FilterFullText ;
      private string AV20DynamicFiltersSelector1 ;
      private string AV24DynamicFiltersSelector2 ;
      private string AV28DynamicFiltersSelector3 ;
      private string AV63Listawwds_1_filterfulltext ;
      private string AV64Listawwds_2_dynamicfiltersselector1 ;
      private string AV68Listawwds_6_dynamicfiltersselector2 ;
      private string AV72Listawwds_10_dynamicfiltersselector3 ;
      private IGxSession AV32Session ;
      private ExcelDocumentI AV11ExcelDocument ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV34GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV31GridStateDynamicFilter ;
      private GxSimpleCollection<string> AV52TFListaTipo_Sels ;
      private GxSimpleCollection<string> AV55TFListaEstado_Sels ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector AV36ColumnsSelector ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column AV38ColumnsSelector_Column ;
      private GxSimpleCollection<string> AV79Listawwds_17_tflistatipo_sels ;
      private GxSimpleCollection<string> AV80Listawwds_18_tflistaestado_sels ;
      private IDataStoreProvider pr_default ;
      private string[] P007B2_A592ListaNombre ;
      private long[] P007B2_A590Listaid ;
      private string[] P007B2_A593ListaEstado ;
      private bool[] P007B2_n593ListaEstado ;
      private string[] P007B2_A591ListaTipo ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector AV37ColumnsSelectorAux ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV35GridStateFilterValue ;
      private string aP0_Filename ;
      private string aP1_ErrorMessage ;
   }

   public class listawwexport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P007B2( IGxContext context ,
                                             string A591ListaTipo ,
                                             GxSimpleCollection<string> AV79Listawwds_17_tflistatipo_sels ,
                                             string A593ListaEstado ,
                                             GxSimpleCollection<string> AV80Listawwds_18_tflistaestado_sels ,
                                             string AV64Listawwds_2_dynamicfiltersselector1 ,
                                             short AV65Listawwds_3_dynamicfiltersoperator1 ,
                                             string AV66Listawwds_4_listanombre1 ,
                                             bool AV67Listawwds_5_dynamicfiltersenabled2 ,
                                             string AV68Listawwds_6_dynamicfiltersselector2 ,
                                             short AV69Listawwds_7_dynamicfiltersoperator2 ,
                                             string AV70Listawwds_8_listanombre2 ,
                                             bool AV71Listawwds_9_dynamicfiltersenabled3 ,
                                             string AV72Listawwds_10_dynamicfiltersselector3 ,
                                             short AV73Listawwds_11_dynamicfiltersoperator3 ,
                                             string AV74Listawwds_12_listanombre3 ,
                                             long AV75Listawwds_13_tflistaid ,
                                             long AV76Listawwds_14_tflistaid_to ,
                                             string AV78Listawwds_16_tflistanombre_sel ,
                                             string AV77Listawwds_15_tflistanombre ,
                                             int AV79Listawwds_17_tflistatipo_sels_Count ,
                                             int AV80Listawwds_18_tflistaestado_sels_Count ,
                                             string A592ListaNombre ,
                                             long A590Listaid ,
                                             short AV17OrderedBy ,
                                             bool AV18OrderedDsc ,
                                             string AV63Listawwds_1_filterfulltext )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int4 = new short[10];
         Object[] GXv_Object5 = new Object[2];
         scmdbuf = "SELECT [ListaNombre], [Listaid], [ListaEstado], [ListaTipo] FROM [Lista]";
         if ( ( StringUtil.StrCmp(AV64Listawwds_2_dynamicfiltersselector1, "LISTANOMBRE") == 0 ) && ( AV65Listawwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Listawwds_4_listanombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ListaNombre]) like UPPER(@lV66Listawwds_4_listanombre1))");
         }
         else
         {
            GXv_int4[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV64Listawwds_2_dynamicfiltersselector1, "LISTANOMBRE") == 0 ) && ( AV65Listawwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Listawwds_4_listanombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ListaNombre]) like '%' + UPPER(@lV66Listawwds_4_listanombre1))");
         }
         else
         {
            GXv_int4[1] = 1;
         }
         if ( AV67Listawwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV68Listawwds_6_dynamicfiltersselector2, "LISTANOMBRE") == 0 ) && ( AV69Listawwds_7_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Listawwds_8_listanombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ListaNombre]) like UPPER(@lV70Listawwds_8_listanombre2))");
         }
         else
         {
            GXv_int4[2] = 1;
         }
         if ( AV67Listawwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV68Listawwds_6_dynamicfiltersselector2, "LISTANOMBRE") == 0 ) && ( AV69Listawwds_7_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Listawwds_8_listanombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ListaNombre]) like '%' + UPPER(@lV70Listawwds_8_listanombre2))");
         }
         else
         {
            GXv_int4[3] = 1;
         }
         if ( AV71Listawwds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV72Listawwds_10_dynamicfiltersselector3, "LISTANOMBRE") == 0 ) && ( AV73Listawwds_11_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Listawwds_12_listanombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ListaNombre]) like UPPER(@lV74Listawwds_12_listanombre3))");
         }
         else
         {
            GXv_int4[4] = 1;
         }
         if ( AV71Listawwds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV72Listawwds_10_dynamicfiltersselector3, "LISTANOMBRE") == 0 ) && ( AV73Listawwds_11_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Listawwds_12_listanombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ListaNombre]) like '%' + UPPER(@lV74Listawwds_12_listanombre3))");
         }
         else
         {
            GXv_int4[5] = 1;
         }
         if ( ! (0==AV75Listawwds_13_tflistaid) )
         {
            AddWhere(sWhereString, "([Listaid] >= @AV75Listawwds_13_tflistaid)");
         }
         else
         {
            GXv_int4[6] = 1;
         }
         if ( ! (0==AV76Listawwds_14_tflistaid_to) )
         {
            AddWhere(sWhereString, "([Listaid] <= @AV76Listawwds_14_tflistaid_to)");
         }
         else
         {
            GXv_int4[7] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV78Listawwds_16_tflistanombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV77Listawwds_15_tflistanombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ListaNombre]) like UPPER(@lV77Listawwds_15_tflistanombre))");
         }
         else
         {
            GXv_int4[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV78Listawwds_16_tflistanombre_sel)) && ! ( StringUtil.StrCmp(AV78Listawwds_16_tflistanombre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([ListaNombre] = @AV78Listawwds_16_tflistanombre_sel)");
         }
         else
         {
            GXv_int4[9] = 1;
         }
         if ( StringUtil.StrCmp(AV78Listawwds_16_tflistanombre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([ListaNombre] = ''))");
         }
         if ( AV79Listawwds_17_tflistatipo_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV79Listawwds_17_tflistatipo_sels, "[ListaTipo] IN (", ")")+")");
         }
         if ( AV80Listawwds_18_tflistaestado_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV80Listawwds_18_tflistaestado_sels, "[ListaEstado] IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         if ( ( AV17OrderedBy == 1 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY [ListaNombre]";
         }
         else if ( ( AV17OrderedBy == 1 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [ListaNombre] DESC";
         }
         else if ( ( AV17OrderedBy == 2 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY [Listaid]";
         }
         else if ( ( AV17OrderedBy == 2 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [Listaid] DESC";
         }
         else if ( ( AV17OrderedBy == 3 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY [ListaTipo]";
         }
         else if ( ( AV17OrderedBy == 3 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [ListaTipo] DESC";
         }
         else if ( ( AV17OrderedBy == 4 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY [ListaEstado]";
         }
         else if ( ( AV17OrderedBy == 4 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [ListaEstado] DESC";
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
                     return conditional_P007B2(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (GxSimpleCollection<string>)dynConstraints[3] , (string)dynConstraints[4] , (short)dynConstraints[5] , (string)dynConstraints[6] , (bool)dynConstraints[7] , (string)dynConstraints[8] , (short)dynConstraints[9] , (string)dynConstraints[10] , (bool)dynConstraints[11] , (string)dynConstraints[12] , (short)dynConstraints[13] , (string)dynConstraints[14] , (long)dynConstraints[15] , (long)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (int)dynConstraints[19] , (int)dynConstraints[20] , (string)dynConstraints[21] , (long)dynConstraints[22] , (short)dynConstraints[23] , (bool)dynConstraints[24] , (string)dynConstraints[25] );
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
          Object[] prmP007B2;
          prmP007B2 = new Object[] {
          new ParDef("@lV66Listawwds_4_listanombre1",GXType.Char,80,0) ,
          new ParDef("@lV66Listawwds_4_listanombre1",GXType.Char,80,0) ,
          new ParDef("@lV70Listawwds_8_listanombre2",GXType.Char,80,0) ,
          new ParDef("@lV70Listawwds_8_listanombre2",GXType.Char,80,0) ,
          new ParDef("@lV74Listawwds_12_listanombre3",GXType.Char,80,0) ,
          new ParDef("@lV74Listawwds_12_listanombre3",GXType.Char,80,0) ,
          new ParDef("@AV75Listawwds_13_tflistaid",GXType.Decimal,18,0) ,
          new ParDef("@AV76Listawwds_14_tflistaid_to",GXType.Decimal,18,0) ,
          new ParDef("@lV77Listawwds_15_tflistanombre",GXType.Char,80,0) ,
          new ParDef("@AV78Listawwds_16_tflistanombre_sel",GXType.NChar,80,0)
          };
          def= new CursorDef[] {
              new CursorDef("P007B2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP007B2,100, GxCacheFrequency.OFF ,true,false )
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
                ((bool[]) buf[3])[0] = rslt.wasNull(3);
                ((string[]) buf[4])[0] = rslt.getString(4, 4);
                return;
       }
    }

 }

}

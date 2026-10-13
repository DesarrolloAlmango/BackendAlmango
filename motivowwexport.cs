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
   public class motivowwexport : GXProcedure
   {
      public motivowwexport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public motivowwexport( IGxContext context )
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
         new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWMotivo", out  GXt_boolean1) ;
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
         AV12Filename = GXt_char2 + "MotivoWWExport-" + StringUtil.Trim( StringUtil.Str( (decimal)(AV16Random), 8, 0)) + ".xlsx";
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
            if ( StringUtil.StrCmp(AV20DynamicFiltersSelector1, "MOTIVOTIPO") == 0 )
            {
               AV52MotivoTipo1 = AV31GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV52MotivoTipo1)) )
               {
                  AV14CellRow = (int)(AV14CellRow+1);
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Bold = 1;
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Color = 3;
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = context.GetMessage( "Tipo", "");
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Italic = 1;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV52MotivoTipo1)) )
                  {
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = context.GetMessage( gxdomaintipomotivos.getDescription(context,AV52MotivoTipo1), "");
                  }
               }
            }
            if ( AV34GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV23DynamicFiltersEnabled2 = true;
               AV31GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV34GridState.gxTpr_Dynamicfilters.Item(2));
               AV24DynamicFiltersSelector2 = AV31GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV24DynamicFiltersSelector2, "MOTIVOTIPO") == 0 )
               {
                  AV53MotivoTipo2 = AV31GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV53MotivoTipo2)) )
                  {
                     AV14CellRow = (int)(AV14CellRow+1);
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Bold = 1;
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Color = 3;
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = context.GetMessage( "Tipo", "");
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Italic = 1;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV53MotivoTipo2)) )
                     {
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = context.GetMessage( gxdomaintipomotivos.getDescription(context,AV53MotivoTipo2), "");
                     }
                  }
               }
               if ( AV34GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV27DynamicFiltersEnabled3 = true;
                  AV31GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV34GridState.gxTpr_Dynamicfilters.Item(3));
                  AV28DynamicFiltersSelector3 = AV31GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV28DynamicFiltersSelector3, "MOTIVOTIPO") == 0 )
                  {
                     AV54MotivoTipo3 = AV31GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV54MotivoTipo3)) )
                     {
                        AV14CellRow = (int)(AV14CellRow+1);
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Bold = 1;
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Color = 3;
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = context.GetMessage( "Tipo", "");
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Italic = 1;
                        if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV54MotivoTipo3)) )
                        {
                           AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = context.GetMessage( gxdomaintipomotivos.getDescription(context,AV54MotivoTipo3), "");
                        }
                     }
                  }
               }
            }
         }
         if ( ! ( (0==AV47TFMotivoId) && (0==AV48TFMotivoId_To) ) )
         {
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Id", "")) ;
            AV14CellRow = GXt_int3;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Number = AV47TFMotivoId;
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  false, ref  GXt_int3,  (short)(AV15FirstColumn+2),  context.GetMessage( "WWP_TSTo", "")) ;
            AV14CellRow = GXt_int3;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+3, 1, 1).Number = AV48TFMotivoId_To;
         }
         if ( ! ( ( AV56TFMotivoTipo_Sels.Count == 0 ) ) )
         {
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Tipo", "")) ;
            AV14CellRow = GXt_int3;
            AV51i = 1;
            AV59GXV1 = 1;
            while ( AV59GXV1 <= AV56TFMotivoTipo_Sels.Count )
            {
               AV57TFMotivoTipo_Sel = AV56TFMotivoTipo_Sels.GetString(AV59GXV1);
               if ( AV51i == 1 )
               {
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = "";
               }
               else
               {
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text+", ";
               }
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text+context.GetMessage( gxdomaintipomotivos.getDescription(context,AV57TFMotivoTipo_Sel), "");
               AV51i = (long)(AV51i+1);
               AV59GXV1 = (int)(AV59GXV1+1);
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV50TFMotivoNombre_Sel)) ) )
         {
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Nombre", "")) ;
            AV14CellRow = GXt_int3;
            GXt_char2 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV50TFMotivoNombre_Sel)) ? context.GetMessage( "WWP_TitleFilter_EmptyOption", "") : AV50TFMotivoNombre_Sel), out  GXt_char2) ;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV49TFMotivoNombre)) ) )
            {
               GXt_int3 = (short)(AV14CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Nombre", "")) ;
               AV14CellRow = GXt_int3;
               GXt_char2 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV49TFMotivoNombre, out  GXt_char2) ;
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
         if ( StringUtil.StrCmp(AV32Session.Get("MotivoWWColumnsSelector"), "") != 0 )
         {
            AV39ColumnsSelectorXML = AV32Session.Get("MotivoWWColumnsSelector");
            AV36ColumnsSelector.FromXml(AV39ColumnsSelectorXML, null, "", "");
         }
         else
         {
            /* Execute user subroutine: 'INITIALIZECOLUMNSSELECTOR' */
            S151 ();
            if (returnInSub) return;
         }
         AV36ColumnsSelector.gxTpr_Columns.Sort("Order");
         AV60GXV2 = 1;
         while ( AV60GXV2 <= AV36ColumnsSelector.gxTpr_Columns.Count )
         {
            AV38ColumnsSelector_Column = ((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV36ColumnsSelector.gxTpr_Columns.Item(AV60GXV2));
            if ( AV38ColumnsSelector_Column.gxTpr_Isvisible )
            {
               AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV44VisibleColumnCount), 1, 1).Text = context.GetMessage( (String.IsNullOrEmpty(StringUtil.RTrim( AV38ColumnsSelector_Column.gxTpr_Displayname)) ? AV38ColumnsSelector_Column.gxTpr_Columnname : AV38ColumnsSelector_Column.gxTpr_Displayname), "");
               AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV44VisibleColumnCount), 1, 1).Bold = 1;
               AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV44VisibleColumnCount), 1, 1).Color = 11;
               AV44VisibleColumnCount = (long)(AV44VisibleColumnCount+1);
            }
            AV60GXV2 = (int)(AV60GXV2+1);
         }
      }

      protected void S161( )
      {
         /* 'WRITEDATA' Routine */
         returnInSub = false;
         AV62Motivowwds_1_filterfulltext = AV19FilterFullText;
         AV63Motivowwds_2_dynamicfiltersselector1 = AV20DynamicFiltersSelector1;
         AV64Motivowwds_3_motivotipo1 = AV52MotivoTipo1;
         AV65Motivowwds_4_dynamicfiltersenabled2 = AV23DynamicFiltersEnabled2;
         AV66Motivowwds_5_dynamicfiltersselector2 = AV24DynamicFiltersSelector2;
         AV67Motivowwds_6_motivotipo2 = AV53MotivoTipo2;
         AV68Motivowwds_7_dynamicfiltersenabled3 = AV27DynamicFiltersEnabled3;
         AV69Motivowwds_8_dynamicfiltersselector3 = AV28DynamicFiltersSelector3;
         AV70Motivowwds_9_motivotipo3 = AV54MotivoTipo3;
         AV71Motivowwds_10_tfmotivoid = AV47TFMotivoId;
         AV72Motivowwds_11_tfmotivoid_to = AV48TFMotivoId_To;
         AV73Motivowwds_12_tfmotivotipo_sels = AV56TFMotivoTipo_Sels;
         AV74Motivowwds_13_tfmotivonombre = AV49TFMotivoNombre;
         AV75Motivowwds_14_tfmotivonombre_sel = AV50TFMotivoNombre_Sel;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A618MotivoTipo ,
                                              AV73Motivowwds_12_tfmotivotipo_sels ,
                                              AV63Motivowwds_2_dynamicfiltersselector1 ,
                                              AV64Motivowwds_3_motivotipo1 ,
                                              AV65Motivowwds_4_dynamicfiltersenabled2 ,
                                              AV66Motivowwds_5_dynamicfiltersselector2 ,
                                              AV67Motivowwds_6_motivotipo2 ,
                                              AV68Motivowwds_7_dynamicfiltersenabled3 ,
                                              AV69Motivowwds_8_dynamicfiltersselector3 ,
                                              AV70Motivowwds_9_motivotipo3 ,
                                              AV71Motivowwds_10_tfmotivoid ,
                                              AV72Motivowwds_11_tfmotivoid_to ,
                                              AV73Motivowwds_12_tfmotivotipo_sels.Count ,
                                              AV75Motivowwds_14_tfmotivonombre_sel ,
                                              AV74Motivowwds_13_tfmotivonombre ,
                                              A604MotivoId ,
                                              A616MotivoNombre ,
                                              AV17OrderedBy ,
                                              AV18OrderedDsc ,
                                              AV62Motivowwds_1_filterfulltext } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.INT, TypeConstants.LONG, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV74Motivowwds_13_tfmotivonombre = StringUtil.PadR( StringUtil.RTrim( AV74Motivowwds_13_tfmotivonombre), 80, "%");
         /* Using cursor P00AY2 */
         pr_default.execute(0, new Object[] {AV64Motivowwds_3_motivotipo1, AV67Motivowwds_6_motivotipo2, AV70Motivowwds_9_motivotipo3, AV71Motivowwds_10_tfmotivoid, AV72Motivowwds_11_tfmotivoid_to, lV74Motivowwds_13_tfmotivonombre, AV75Motivowwds_14_tfmotivonombre_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A616MotivoNombre = P00AY2_A616MotivoNombre[0];
            A604MotivoId = P00AY2_A604MotivoId[0];
            A618MotivoTipo = P00AY2_A618MotivoTipo[0];
            n618MotivoTipo = P00AY2_n618MotivoTipo[0];
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV62Motivowwds_1_filterfulltext)) || ( ( StringUtil.Like( StringUtil.Str( (decimal)(A604MotivoId), 18, 0) , StringUtil.PadR( "%" + AV62Motivowwds_1_filterfulltext , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( context.GetMessage( "incidencias", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV62Motivowwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A618MotivoTipo, "INC") == 0 ) ) || ( StringUtil.Like( StringUtil.Upper( A616MotivoNombre) , StringUtil.PadR( "%" + StringUtil.Upper( AV62Motivowwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) ) )
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
                     if ( StringUtil.StrCmp(AV38ColumnsSelector_Column.gxTpr_Columnname, "MotivoId") == 0 )
                     {
                        AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV44VisibleColumnCount), 1, 1).Number = A604MotivoId;
                     }
                     else if ( StringUtil.StrCmp(AV38ColumnsSelector_Column.gxTpr_Columnname, "MotivoTipo") == 0 )
                     {
                        AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV44VisibleColumnCount), 1, 1).Text = context.GetMessage( gxdomaintipomotivos.getDescription(context,A618MotivoTipo), "");
                     }
                     else if ( StringUtil.StrCmp(AV38ColumnsSelector_Column.gxTpr_Columnname, "MotivoNombre") == 0 )
                     {
                        GXt_char2 = "";
                        new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A616MotivoNombre, out  GXt_char2) ;
                        AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV44VisibleColumnCount), 1, 1).Text = GXt_char2;
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
         AV32Session.Set("WWPExportFileName", "MotivoWWExport.xlsx");
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
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV36ColumnsSelector,  "MotivoId",  "",  "Id",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV36ColumnsSelector,  "MotivoTipo",  "",  "Tipo",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV36ColumnsSelector,  "MotivoNombre",  "",  "Nombre",  true,  "") ;
         GXt_char2 = AV40UserCustomValue;
         new GeneXus.Programs.wwpbaseobjects.loadcolumnsselectorstate(context ).execute(  "MotivoWWColumnsSelector", out  GXt_char2) ;
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
         if ( StringUtil.StrCmp(AV32Session.Get("MotivoWWGridState"), "") == 0 )
         {
            AV34GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "MotivoWWGridState"), null, "", "");
         }
         else
         {
            AV34GridState.FromXml(AV32Session.Get("MotivoWWGridState"), null, "", "");
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
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFMOTIVOID") == 0 )
            {
               AV47TFMotivoId = (long)(Math.Round(NumberUtil.Val( AV35GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV48TFMotivoId_To = (long)(Math.Round(NumberUtil.Val( AV35GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFMOTIVOTIPO_SEL") == 0 )
            {
               AV55TFMotivoTipo_SelsJson = AV35GridStateFilterValue.gxTpr_Value;
               AV56TFMotivoTipo_Sels.FromJSonString(AV55TFMotivoTipo_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFMOTIVONOMBRE") == 0 )
            {
               AV49TFMotivoNombre = AV35GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFMOTIVONOMBRE_SEL") == 0 )
            {
               AV50TFMotivoNombre_Sel = AV35GridStateFilterValue.gxTpr_Value;
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
         AV58Pgmname = "";
         GXKey = "";
         GXEncryptionTmp = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV11ExcelDocument = new ExcelDocumentI();
         AV19FilterFullText = "";
         AV34GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV31GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV20DynamicFiltersSelector1 = "";
         AV52MotivoTipo1 = "";
         AV24DynamicFiltersSelector2 = "";
         AV53MotivoTipo2 = "";
         AV28DynamicFiltersSelector3 = "";
         AV54MotivoTipo3 = "";
         AV56TFMotivoTipo_Sels = new GxSimpleCollection<string>();
         AV57TFMotivoTipo_Sel = "";
         AV50TFMotivoNombre_Sel = "";
         AV49TFMotivoNombre = "";
         AV32Session = context.GetSession();
         AV39ColumnsSelectorXML = "";
         AV36ColumnsSelector = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector(context);
         AV38ColumnsSelector_Column = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column(context);
         AV62Motivowwds_1_filterfulltext = "";
         AV63Motivowwds_2_dynamicfiltersselector1 = "";
         AV64Motivowwds_3_motivotipo1 = "";
         AV66Motivowwds_5_dynamicfiltersselector2 = "";
         AV67Motivowwds_6_motivotipo2 = "";
         AV69Motivowwds_8_dynamicfiltersselector3 = "";
         AV70Motivowwds_9_motivotipo3 = "";
         AV73Motivowwds_12_tfmotivotipo_sels = new GxSimpleCollection<string>();
         AV74Motivowwds_13_tfmotivonombre = "";
         AV75Motivowwds_14_tfmotivonombre_sel = "";
         lV62Motivowwds_1_filterfulltext = "";
         lV74Motivowwds_13_tfmotivonombre = "";
         A618MotivoTipo = "";
         A616MotivoNombre = "";
         P00AY2_A616MotivoNombre = new string[] {""} ;
         P00AY2_A604MotivoId = new long[1] ;
         P00AY2_A618MotivoTipo = new string[] {""} ;
         P00AY2_n618MotivoTipo = new bool[] {false} ;
         AV40UserCustomValue = "";
         GXt_char2 = "";
         AV37ColumnsSelectorAux = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector(context);
         AV35GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV55TFMotivoTipo_SelsJson = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.motivowwexport__default(),
            new Object[][] {
                new Object[] {
               P00AY2_A616MotivoNombre, P00AY2_A604MotivoId, P00AY2_A618MotivoTipo, P00AY2_n618MotivoTipo
               }
            }
         );
         AV58Pgmname = "MotivoWWExport";
         /* GeneXus formulas. */
         AV58Pgmname = "MotivoWWExport";
      }

      private short GXt_int3 ;
      private short AV17OrderedBy ;
      private int AV14CellRow ;
      private int AV15FirstColumn ;
      private int AV16Random ;
      private int AV59GXV1 ;
      private int AV60GXV2 ;
      private int AV73Motivowwds_12_tfmotivotipo_sels_Count ;
      private int AV76GXV3 ;
      private int AV77GXV4 ;
      private long AV47TFMotivoId ;
      private long AV48TFMotivoId_To ;
      private long AV51i ;
      private long AV44VisibleColumnCount ;
      private long AV71Motivowwds_10_tfmotivoid ;
      private long AV72Motivowwds_11_tfmotivoid_to ;
      private long A604MotivoId ;
      private string AV58Pgmname ;
      private string GXKey ;
      private string GXEncryptionTmp ;
      private string AV52MotivoTipo1 ;
      private string AV53MotivoTipo2 ;
      private string AV54MotivoTipo3 ;
      private string AV57TFMotivoTipo_Sel ;
      private string AV50TFMotivoNombre_Sel ;
      private string AV49TFMotivoNombre ;
      private string AV64Motivowwds_3_motivotipo1 ;
      private string AV67Motivowwds_6_motivotipo2 ;
      private string AV70Motivowwds_9_motivotipo3 ;
      private string AV74Motivowwds_13_tfmotivonombre ;
      private string AV75Motivowwds_14_tfmotivonombre_sel ;
      private string lV74Motivowwds_13_tfmotivonombre ;
      private string A618MotivoTipo ;
      private string A616MotivoNombre ;
      private string GXt_char2 ;
      private bool AV8IsAuthorized ;
      private bool GXt_boolean1 ;
      private bool returnInSub ;
      private bool AV23DynamicFiltersEnabled2 ;
      private bool AV27DynamicFiltersEnabled3 ;
      private bool AV65Motivowwds_4_dynamicfiltersenabled2 ;
      private bool AV68Motivowwds_7_dynamicfiltersenabled3 ;
      private bool AV18OrderedDsc ;
      private bool n618MotivoTipo ;
      private string AV39ColumnsSelectorXML ;
      private string AV40UserCustomValue ;
      private string AV55TFMotivoTipo_SelsJson ;
      private string AV12Filename ;
      private string AV13ErrorMessage ;
      private string AV19FilterFullText ;
      private string AV20DynamicFiltersSelector1 ;
      private string AV24DynamicFiltersSelector2 ;
      private string AV28DynamicFiltersSelector3 ;
      private string AV62Motivowwds_1_filterfulltext ;
      private string AV63Motivowwds_2_dynamicfiltersselector1 ;
      private string AV66Motivowwds_5_dynamicfiltersselector2 ;
      private string AV69Motivowwds_8_dynamicfiltersselector3 ;
      private string lV62Motivowwds_1_filterfulltext ;
      private IGxSession AV32Session ;
      private ExcelDocumentI AV11ExcelDocument ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV34GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV31GridStateDynamicFilter ;
      private GxSimpleCollection<string> AV56TFMotivoTipo_Sels ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector AV36ColumnsSelector ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column AV38ColumnsSelector_Column ;
      private GxSimpleCollection<string> AV73Motivowwds_12_tfmotivotipo_sels ;
      private IDataStoreProvider pr_default ;
      private string[] P00AY2_A616MotivoNombre ;
      private long[] P00AY2_A604MotivoId ;
      private string[] P00AY2_A618MotivoTipo ;
      private bool[] P00AY2_n618MotivoTipo ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector AV37ColumnsSelectorAux ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV35GridStateFilterValue ;
      private string aP0_Filename ;
      private string aP1_ErrorMessage ;
   }

   public class motivowwexport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00AY2( IGxContext context ,
                                             string A618MotivoTipo ,
                                             GxSimpleCollection<string> AV73Motivowwds_12_tfmotivotipo_sels ,
                                             string AV63Motivowwds_2_dynamicfiltersselector1 ,
                                             string AV64Motivowwds_3_motivotipo1 ,
                                             bool AV65Motivowwds_4_dynamicfiltersenabled2 ,
                                             string AV66Motivowwds_5_dynamicfiltersselector2 ,
                                             string AV67Motivowwds_6_motivotipo2 ,
                                             bool AV68Motivowwds_7_dynamicfiltersenabled3 ,
                                             string AV69Motivowwds_8_dynamicfiltersselector3 ,
                                             string AV70Motivowwds_9_motivotipo3 ,
                                             long AV71Motivowwds_10_tfmotivoid ,
                                             long AV72Motivowwds_11_tfmotivoid_to ,
                                             int AV73Motivowwds_12_tfmotivotipo_sels_Count ,
                                             string AV75Motivowwds_14_tfmotivonombre_sel ,
                                             string AV74Motivowwds_13_tfmotivonombre ,
                                             long A604MotivoId ,
                                             string A616MotivoNombre ,
                                             short AV17OrderedBy ,
                                             bool AV18OrderedDsc ,
                                             string AV62Motivowwds_1_filterfulltext )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int4 = new short[7];
         Object[] GXv_Object5 = new Object[2];
         scmdbuf = "SELECT [MotivoNombre], [MotivoId], [MotivoTipo] FROM [Motivo]";
         if ( ( StringUtil.StrCmp(AV63Motivowwds_2_dynamicfiltersselector1, "MOTIVOTIPO") == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Motivowwds_3_motivotipo1)) ) )
         {
            AddWhere(sWhereString, "([MotivoTipo] = @AV64Motivowwds_3_motivotipo1)");
         }
         else
         {
            GXv_int4[0] = 1;
         }
         if ( AV65Motivowwds_4_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV66Motivowwds_5_dynamicfiltersselector2, "MOTIVOTIPO") == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Motivowwds_6_motivotipo2)) ) )
         {
            AddWhere(sWhereString, "([MotivoTipo] = @AV67Motivowwds_6_motivotipo2)");
         }
         else
         {
            GXv_int4[1] = 1;
         }
         if ( AV68Motivowwds_7_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV69Motivowwds_8_dynamicfiltersselector3, "MOTIVOTIPO") == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Motivowwds_9_motivotipo3)) ) )
         {
            AddWhere(sWhereString, "([MotivoTipo] = @AV70Motivowwds_9_motivotipo3)");
         }
         else
         {
            GXv_int4[2] = 1;
         }
         if ( ! (0==AV71Motivowwds_10_tfmotivoid) )
         {
            AddWhere(sWhereString, "([MotivoId] >= @AV71Motivowwds_10_tfmotivoid)");
         }
         else
         {
            GXv_int4[3] = 1;
         }
         if ( ! (0==AV72Motivowwds_11_tfmotivoid_to) )
         {
            AddWhere(sWhereString, "([MotivoId] <= @AV72Motivowwds_11_tfmotivoid_to)");
         }
         else
         {
            GXv_int4[4] = 1;
         }
         if ( AV73Motivowwds_12_tfmotivotipo_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV73Motivowwds_12_tfmotivotipo_sels, "[MotivoTipo] IN (", ")")+")");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV75Motivowwds_14_tfmotivonombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Motivowwds_13_tfmotivonombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER([MotivoNombre]) like UPPER(@lV74Motivowwds_13_tfmotivonombre))");
         }
         else
         {
            GXv_int4[5] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75Motivowwds_14_tfmotivonombre_sel)) && ! ( StringUtil.StrCmp(AV75Motivowwds_14_tfmotivonombre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([MotivoNombre] = @AV75Motivowwds_14_tfmotivonombre_sel)");
         }
         else
         {
            GXv_int4[6] = 1;
         }
         if ( StringUtil.StrCmp(AV75Motivowwds_14_tfmotivonombre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([MotivoNombre] = ''))");
         }
         scmdbuf += sWhereString;
         if ( ( AV17OrderedBy == 1 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY [MotivoTipo]";
         }
         else if ( ( AV17OrderedBy == 1 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [MotivoTipo] DESC";
         }
         else if ( ( AV17OrderedBy == 2 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY [MotivoId]";
         }
         else if ( ( AV17OrderedBy == 2 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [MotivoId] DESC";
         }
         else if ( ( AV17OrderedBy == 3 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY [MotivoNombre]";
         }
         else if ( ( AV17OrderedBy == 3 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [MotivoNombre] DESC";
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
                     return conditional_P00AY2(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (bool)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (bool)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (long)dynConstraints[10] , (long)dynConstraints[11] , (int)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (long)dynConstraints[15] , (string)dynConstraints[16] , (short)dynConstraints[17] , (bool)dynConstraints[18] , (string)dynConstraints[19] );
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
          Object[] prmP00AY2;
          prmP00AY2 = new Object[] {
          new ParDef("@AV64Motivowwds_3_motivotipo1",GXType.NChar,3,0) ,
          new ParDef("@AV67Motivowwds_6_motivotipo2",GXType.NChar,3,0) ,
          new ParDef("@AV70Motivowwds_9_motivotipo3",GXType.NChar,3,0) ,
          new ParDef("@AV71Motivowwds_10_tfmotivoid",GXType.Decimal,18,0) ,
          new ParDef("@AV72Motivowwds_11_tfmotivoid_to",GXType.Decimal,18,0) ,
          new ParDef("@lV74Motivowwds_13_tfmotivonombre",GXType.Char,80,0) ,
          new ParDef("@AV75Motivowwds_14_tfmotivonombre_sel",GXType.NChar,80,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00AY2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00AY2,100, GxCacheFrequency.OFF ,true,false )
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
                return;
       }
    }

 }

}

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
   public class comisionesagruparwwexport : GXProcedure
   {
      public comisionesagruparwwexport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public comisionesagruparwwexport( IGxContext context )
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
         new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWComisionesAgrupar", out  GXt_boolean1) ;
         AV8IsAuthorized = GXt_boolean1;
         if ( ! AV8IsAuthorized )
         {
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "wwpbaseobjects.notauthorized.aspx"+GXUtil.UrlEncode(StringUtil.RTrim(AV54Pgmname));
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
         AV12Filename = GXt_char2 + "ComisionesAgruparWWExport-" + StringUtil.Trim( StringUtil.Str( (decimal)(AV16Random), 8, 0)) + ".xlsx";
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
            if ( StringUtil.StrCmp(AV20DynamicFiltersSelector1, "COMISIONESTIPO") == 0 )
            {
               AV21ComisionesTipo1 = AV28GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV21ComisionesTipo1)) )
               {
                  AV14CellRow = (int)(AV14CellRow+1);
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Bold = 1;
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Color = 3;
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = context.GetMessage( "Tipo", "");
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Italic = 1;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV21ComisionesTipo1)) )
                  {
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = context.GetMessage( gxdomaintipocomision.getDescription(context,AV21ComisionesTipo1), "");
                  }
               }
            }
            if ( AV31GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV22DynamicFiltersEnabled2 = true;
               AV28GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV31GridState.gxTpr_Dynamicfilters.Item(2));
               AV23DynamicFiltersSelector2 = AV28GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV23DynamicFiltersSelector2, "COMISIONESTIPO") == 0 )
               {
                  AV24ComisionesTipo2 = AV28GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV24ComisionesTipo2)) )
                  {
                     AV14CellRow = (int)(AV14CellRow+1);
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Bold = 1;
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Color = 3;
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = context.GetMessage( "Tipo", "");
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Italic = 1;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV24ComisionesTipo2)) )
                     {
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = context.GetMessage( gxdomaintipocomision.getDescription(context,AV24ComisionesTipo2), "");
                     }
                  }
               }
               if ( AV31GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV25DynamicFiltersEnabled3 = true;
                  AV28GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV31GridState.gxTpr_Dynamicfilters.Item(3));
                  AV26DynamicFiltersSelector3 = AV28GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV26DynamicFiltersSelector3, "COMISIONESTIPO") == 0 )
                  {
                     AV27ComisionesTipo3 = AV28GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV27ComisionesTipo3)) )
                     {
                        AV14CellRow = (int)(AV14CellRow+1);
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Bold = 1;
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Color = 3;
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = context.GetMessage( "Tipo", "");
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Italic = 1;
                        if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV27ComisionesTipo3)) )
                        {
                           AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = context.GetMessage( gxdomaintipocomision.getDescription(context,AV27ComisionesTipo3), "");
                        }
                     }
                  }
               }
            }
         }
         if ( ! ( (0==AV44TFComisionesID) && (0==AV45TFComisionesID_To) ) )
         {
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Código de la Comisión", "")) ;
            AV14CellRow = GXt_int3;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Number = AV44TFComisionesID;
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  false, ref  GXt_int3,  (short)(AV15FirstColumn+2),  context.GetMessage( "WWP_TSTo", "")) ;
            AV14CellRow = GXt_int3;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+3, 1, 1).Number = AV45TFComisionesID_To;
         }
         if ( ! ( ( AV47TFComisionesTipo_Sels.Count == 0 ) ) )
         {
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Tipo", "")) ;
            AV14CellRow = GXt_int3;
            AV53i = 1;
            AV55GXV1 = 1;
            while ( AV55GXV1 <= AV47TFComisionesTipo_Sels.Count )
            {
               AV48TFComisionesTipo_Sel = AV47TFComisionesTipo_Sels.GetString(AV55GXV1);
               if ( AV53i == 1 )
               {
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = "";
               }
               else
               {
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text+", ";
               }
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text+context.GetMessage( gxdomaintipocomision.getDescription(context,AV48TFComisionesTipo_Sel), "");
               AV53i = (long)(AV53i+1);
               AV55GXV1 = (int)(AV55GXV1+1);
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV50TFComisionesNombre_Sel)) ) )
         {
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Nombre", "")) ;
            AV14CellRow = GXt_int3;
            GXt_char2 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV50TFComisionesNombre_Sel)) ? context.GetMessage( "WWP_TitleFilter_EmptyOption", "") : AV50TFComisionesNombre_Sel), out  GXt_char2) ;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV49TFComisionesNombre)) ) )
            {
               GXt_int3 = (short)(AV14CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Nombre", "")) ;
               AV14CellRow = GXt_int3;
               GXt_char2 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV49TFComisionesNombre, out  GXt_char2) ;
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
            }
         }
         if ( ! ( (Convert.ToDecimal(0)==AV51TFComisionesDefault) && (Convert.ToDecimal(0)==AV52TFComisionesDefault_To) ) )
         {
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Comisión por Defecto %", "")) ;
            AV14CellRow = GXt_int3;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Number = (double)(AV51TFComisionesDefault);
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  false, ref  GXt_int3,  (short)(AV15FirstColumn+2),  context.GetMessage( "WWP_TSTo", "")) ;
            AV14CellRow = GXt_int3;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+3, 1, 1).Number = (double)(AV52TFComisionesDefault_To);
         }
         AV14CellRow = (int)(AV14CellRow+2);
      }

      protected void S141( )
      {
         /* 'WRITECOLUMNTITLES' Routine */
         returnInSub = false;
         AV41VisibleColumnCount = 0;
         if ( StringUtil.StrCmp(AV29Session.Get("ComisionesAgruparWWColumnsSelector"), "") != 0 )
         {
            AV36ColumnsSelectorXML = AV29Session.Get("ComisionesAgruparWWColumnsSelector");
            AV33ColumnsSelector.FromXml(AV36ColumnsSelectorXML, null, "", "");
         }
         else
         {
            /* Execute user subroutine: 'INITIALIZECOLUMNSSELECTOR' */
            S151 ();
            if (returnInSub) return;
         }
         AV33ColumnsSelector.gxTpr_Columns.Sort("Order");
         AV56GXV2 = 1;
         while ( AV56GXV2 <= AV33ColumnsSelector.gxTpr_Columns.Count )
         {
            AV35ColumnsSelector_Column = ((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV33ColumnsSelector.gxTpr_Columns.Item(AV56GXV2));
            if ( AV35ColumnsSelector_Column.gxTpr_Isvisible )
            {
               AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV41VisibleColumnCount), 1, 1).Text = context.GetMessage( (String.IsNullOrEmpty(StringUtil.RTrim( AV35ColumnsSelector_Column.gxTpr_Displayname)) ? AV35ColumnsSelector_Column.gxTpr_Columnname : AV35ColumnsSelector_Column.gxTpr_Displayname), "");
               AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV41VisibleColumnCount), 1, 1).Bold = 1;
               AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV41VisibleColumnCount), 1, 1).Color = 11;
               AV41VisibleColumnCount = (long)(AV41VisibleColumnCount+1);
            }
            AV56GXV2 = (int)(AV56GXV2+1);
         }
      }

      protected void S161( )
      {
         /* 'WRITEDATA' Routine */
         returnInSub = false;
         AV58Comisionesagruparwwds_1_filterfulltext = AV19FilterFullText;
         AV59Comisionesagruparwwds_2_dynamicfiltersselector1 = AV20DynamicFiltersSelector1;
         AV60Comisionesagruparwwds_3_comisionestipo1 = AV21ComisionesTipo1;
         AV61Comisionesagruparwwds_4_dynamicfiltersenabled2 = AV22DynamicFiltersEnabled2;
         AV62Comisionesagruparwwds_5_dynamicfiltersselector2 = AV23DynamicFiltersSelector2;
         AV63Comisionesagruparwwds_6_comisionestipo2 = AV24ComisionesTipo2;
         AV64Comisionesagruparwwds_7_dynamicfiltersenabled3 = AV25DynamicFiltersEnabled3;
         AV65Comisionesagruparwwds_8_dynamicfiltersselector3 = AV26DynamicFiltersSelector3;
         AV66Comisionesagruparwwds_9_comisionestipo3 = AV27ComisionesTipo3;
         AV67Comisionesagruparwwds_10_tfcomisionesid = AV44TFComisionesID;
         AV68Comisionesagruparwwds_11_tfcomisionesid_to = AV45TFComisionesID_To;
         AV69Comisionesagruparwwds_12_tfcomisionestipo_sels = AV47TFComisionesTipo_Sels;
         AV70Comisionesagruparwwds_13_tfcomisionesnombre = AV49TFComisionesNombre;
         AV71Comisionesagruparwwds_14_tfcomisionesnombre_sel = AV50TFComisionesNombre_Sel;
         AV72Comisionesagruparwwds_15_tfcomisionesdefault = AV51TFComisionesDefault;
         AV73Comisionesagruparwwds_16_tfcomisionesdefault_to = AV52TFComisionesDefault_To;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A505ComisionesTipo ,
                                              AV69Comisionesagruparwwds_12_tfcomisionestipo_sels ,
                                              AV59Comisionesagruparwwds_2_dynamicfiltersselector1 ,
                                              AV60Comisionesagruparwwds_3_comisionestipo1 ,
                                              AV61Comisionesagruparwwds_4_dynamicfiltersenabled2 ,
                                              AV62Comisionesagruparwwds_5_dynamicfiltersselector2 ,
                                              AV63Comisionesagruparwwds_6_comisionestipo2 ,
                                              AV64Comisionesagruparwwds_7_dynamicfiltersenabled3 ,
                                              AV65Comisionesagruparwwds_8_dynamicfiltersselector3 ,
                                              AV66Comisionesagruparwwds_9_comisionestipo3 ,
                                              AV67Comisionesagruparwwds_10_tfcomisionesid ,
                                              AV68Comisionesagruparwwds_11_tfcomisionesid_to ,
                                              AV69Comisionesagruparwwds_12_tfcomisionestipo_sels.Count ,
                                              AV71Comisionesagruparwwds_14_tfcomisionesnombre_sel ,
                                              AV70Comisionesagruparwwds_13_tfcomisionesnombre ,
                                              AV72Comisionesagruparwwds_15_tfcomisionesdefault ,
                                              AV73Comisionesagruparwwds_16_tfcomisionesdefault_to ,
                                              A503ComisionesID ,
                                              A504ComisionesNombre ,
                                              A506ComisionesDefault ,
                                              AV17OrderedBy ,
                                              AV18OrderedDsc ,
                                              AV58Comisionesagruparwwds_1_filterfulltext } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.INT, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.LONG, TypeConstants.DECIMAL, TypeConstants.BOOLEAN,
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV70Comisionesagruparwwds_13_tfcomisionesnombre = StringUtil.PadR( StringUtil.RTrim( AV70Comisionesagruparwwds_13_tfcomisionesnombre), 80, "%");
         /* Using cursor P006N2 */
         pr_default.execute(0, new Object[] {AV60Comisionesagruparwwds_3_comisionestipo1, AV63Comisionesagruparwwds_6_comisionestipo2, AV66Comisionesagruparwwds_9_comisionestipo3, AV67Comisionesagruparwwds_10_tfcomisionesid, AV68Comisionesagruparwwds_11_tfcomisionesid_to, lV70Comisionesagruparwwds_13_tfcomisionesnombre, AV71Comisionesagruparwwds_14_tfcomisionesnombre_sel, AV72Comisionesagruparwwds_15_tfcomisionesdefault, AV73Comisionesagruparwwds_16_tfcomisionesdefault_to});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A506ComisionesDefault = P006N2_A506ComisionesDefault[0];
            n506ComisionesDefault = P006N2_n506ComisionesDefault[0];
            A504ComisionesNombre = P006N2_A504ComisionesNombre[0];
            A503ComisionesID = P006N2_A503ComisionesID[0];
            A505ComisionesTipo = P006N2_A505ComisionesTipo[0];
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV58Comisionesagruparwwds_1_filterfulltext)) || ( ( StringUtil.Like( StringUtil.Str( (decimal)(A503ComisionesID), 18, 0) , StringUtil.PadR( "%" + AV58Comisionesagruparwwds_1_filterfulltext , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( context.GetMessage( "profesional", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV58Comisionesagruparwwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A505ComisionesTipo, "P") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "comercio", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV58Comisionesagruparwwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A505ComisionesTipo, "C") == 0 ) ) || ( StringUtil.Like( StringUtil.Upper( A504ComisionesNombre) , StringUtil.PadR( "%" + StringUtil.Upper( AV58Comisionesagruparwwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Str( A506ComisionesDefault, 6, 2) , StringUtil.PadR( "%" + AV58Comisionesagruparwwds_1_filterfulltext , 254 , "%"),  ' ' ) ) ) )
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
               AV74GXV3 = 1;
               while ( AV74GXV3 <= AV33ColumnsSelector.gxTpr_Columns.Count )
               {
                  AV35ColumnsSelector_Column = ((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV33ColumnsSelector.gxTpr_Columns.Item(AV74GXV3));
                  if ( AV35ColumnsSelector_Column.gxTpr_Isvisible )
                  {
                     if ( StringUtil.StrCmp(AV35ColumnsSelector_Column.gxTpr_Columnname, "ComisionesID") == 0 )
                     {
                        AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV41VisibleColumnCount), 1, 1).Number = A503ComisionesID;
                     }
                     else if ( StringUtil.StrCmp(AV35ColumnsSelector_Column.gxTpr_Columnname, "ComisionesTipo") == 0 )
                     {
                        AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV41VisibleColumnCount), 1, 1).Text = context.GetMessage( gxdomaintipocomision.getDescription(context,A505ComisionesTipo), "");
                     }
                     else if ( StringUtil.StrCmp(AV35ColumnsSelector_Column.gxTpr_Columnname, "ComisionesNombre") == 0 )
                     {
                        GXt_char2 = "";
                        new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A504ComisionesNombre, out  GXt_char2) ;
                        AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV41VisibleColumnCount), 1, 1).Text = GXt_char2;
                     }
                     else if ( StringUtil.StrCmp(AV35ColumnsSelector_Column.gxTpr_Columnname, "ComisionesDefault") == 0 )
                     {
                        AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV41VisibleColumnCount), 1, 1).Number = (double)(A506ComisionesDefault);
                     }
                     AV41VisibleColumnCount = (long)(AV41VisibleColumnCount+1);
                  }
                  AV74GXV3 = (int)(AV74GXV3+1);
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
         AV29Session.Set("WWPExportFileName", "ComisionesAgruparWWExport.xlsx");
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
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV33ColumnsSelector,  "ComisionesID",  "",  "Código de la Comisión",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV33ColumnsSelector,  "ComisionesTipo",  "",  "Tipo",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV33ColumnsSelector,  "ComisionesNombre",  "",  "Nombre",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV33ColumnsSelector,  "ComisionesDefault",  "",  "Comisión por Defecto %",  true,  "") ;
         GXt_char2 = AV37UserCustomValue;
         new GeneXus.Programs.wwpbaseobjects.loadcolumnsselectorstate(context ).execute(  "ComisionesAgruparWWColumnsSelector", out  GXt_char2) ;
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
         if ( StringUtil.StrCmp(AV29Session.Get("ComisionesAgruparWWGridState"), "") == 0 )
         {
            AV31GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "ComisionesAgruparWWGridState"), null, "", "");
         }
         else
         {
            AV31GridState.FromXml(AV29Session.Get("ComisionesAgruparWWGridState"), null, "", "");
         }
         AV17OrderedBy = AV31GridState.gxTpr_Orderedby;
         AV18OrderedDsc = AV31GridState.gxTpr_Ordereddsc;
         AV75GXV4 = 1;
         while ( AV75GXV4 <= AV31GridState.gxTpr_Filtervalues.Count )
         {
            AV32GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV31GridState.gxTpr_Filtervalues.Item(AV75GXV4));
            if ( StringUtil.StrCmp(AV32GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV19FilterFullText = AV32GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV32GridStateFilterValue.gxTpr_Name, "TFCOMISIONESID") == 0 )
            {
               AV44TFComisionesID = (long)(Math.Round(NumberUtil.Val( AV32GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV45TFComisionesID_To = (long)(Math.Round(NumberUtil.Val( AV32GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV32GridStateFilterValue.gxTpr_Name, "TFCOMISIONESTIPO_SEL") == 0 )
            {
               AV46TFComisionesTipo_SelsJson = AV32GridStateFilterValue.gxTpr_Value;
               AV47TFComisionesTipo_Sels.FromJSonString(AV46TFComisionesTipo_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV32GridStateFilterValue.gxTpr_Name, "TFCOMISIONESNOMBRE") == 0 )
            {
               AV49TFComisionesNombre = AV32GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV32GridStateFilterValue.gxTpr_Name, "TFCOMISIONESNOMBRE_SEL") == 0 )
            {
               AV50TFComisionesNombre_Sel = AV32GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV32GridStateFilterValue.gxTpr_Name, "TFCOMISIONESDEFAULT") == 0 )
            {
               AV51TFComisionesDefault = NumberUtil.Val( AV32GridStateFilterValue.gxTpr_Value, ".");
               AV52TFComisionesDefault_To = NumberUtil.Val( AV32GridStateFilterValue.gxTpr_Valueto, ".");
            }
            AV75GXV4 = (int)(AV75GXV4+1);
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
         AV54Pgmname = "";
         GXKey = "";
         GXEncryptionTmp = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV11ExcelDocument = new ExcelDocumentI();
         AV19FilterFullText = "";
         AV31GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV28GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV20DynamicFiltersSelector1 = "";
         AV21ComisionesTipo1 = "";
         AV23DynamicFiltersSelector2 = "";
         AV24ComisionesTipo2 = "";
         AV26DynamicFiltersSelector3 = "";
         AV27ComisionesTipo3 = "";
         AV47TFComisionesTipo_Sels = new GxSimpleCollection<string>();
         AV48TFComisionesTipo_Sel = "";
         AV50TFComisionesNombre_Sel = "";
         AV49TFComisionesNombre = "";
         AV29Session = context.GetSession();
         AV36ColumnsSelectorXML = "";
         AV33ColumnsSelector = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector(context);
         AV35ColumnsSelector_Column = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column(context);
         AV58Comisionesagruparwwds_1_filterfulltext = "";
         AV59Comisionesagruparwwds_2_dynamicfiltersselector1 = "";
         AV60Comisionesagruparwwds_3_comisionestipo1 = "";
         AV62Comisionesagruparwwds_5_dynamicfiltersselector2 = "";
         AV63Comisionesagruparwwds_6_comisionestipo2 = "";
         AV65Comisionesagruparwwds_8_dynamicfiltersselector3 = "";
         AV66Comisionesagruparwwds_9_comisionestipo3 = "";
         AV69Comisionesagruparwwds_12_tfcomisionestipo_sels = new GxSimpleCollection<string>();
         AV70Comisionesagruparwwds_13_tfcomisionesnombre = "";
         AV71Comisionesagruparwwds_14_tfcomisionesnombre_sel = "";
         lV58Comisionesagruparwwds_1_filterfulltext = "";
         lV70Comisionesagruparwwds_13_tfcomisionesnombre = "";
         A505ComisionesTipo = "";
         A504ComisionesNombre = "";
         P006N2_A506ComisionesDefault = new decimal[1] ;
         P006N2_n506ComisionesDefault = new bool[] {false} ;
         P006N2_A504ComisionesNombre = new string[] {""} ;
         P006N2_A503ComisionesID = new long[1] ;
         P006N2_A505ComisionesTipo = new string[] {""} ;
         AV37UserCustomValue = "";
         GXt_char2 = "";
         AV34ColumnsSelectorAux = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector(context);
         AV32GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV46TFComisionesTipo_SelsJson = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.comisionesagruparwwexport__default(),
            new Object[][] {
                new Object[] {
               P006N2_A506ComisionesDefault, P006N2_n506ComisionesDefault, P006N2_A504ComisionesNombre, P006N2_A503ComisionesID, P006N2_A505ComisionesTipo
               }
            }
         );
         AV54Pgmname = "ComisionesAgruparWWExport";
         /* GeneXus formulas. */
         AV54Pgmname = "ComisionesAgruparWWExport";
      }

      private short GXt_int3 ;
      private short AV17OrderedBy ;
      private int AV14CellRow ;
      private int AV15FirstColumn ;
      private int AV16Random ;
      private int AV55GXV1 ;
      private int AV56GXV2 ;
      private int AV69Comisionesagruparwwds_12_tfcomisionestipo_sels_Count ;
      private int AV74GXV3 ;
      private int AV75GXV4 ;
      private long AV44TFComisionesID ;
      private long AV45TFComisionesID_To ;
      private long AV53i ;
      private long AV41VisibleColumnCount ;
      private long AV67Comisionesagruparwwds_10_tfcomisionesid ;
      private long AV68Comisionesagruparwwds_11_tfcomisionesid_to ;
      private long A503ComisionesID ;
      private decimal AV51TFComisionesDefault ;
      private decimal AV52TFComisionesDefault_To ;
      private decimal AV72Comisionesagruparwwds_15_tfcomisionesdefault ;
      private decimal AV73Comisionesagruparwwds_16_tfcomisionesdefault_to ;
      private decimal A506ComisionesDefault ;
      private string AV54Pgmname ;
      private string GXKey ;
      private string GXEncryptionTmp ;
      private string AV21ComisionesTipo1 ;
      private string AV24ComisionesTipo2 ;
      private string AV27ComisionesTipo3 ;
      private string AV48TFComisionesTipo_Sel ;
      private string AV50TFComisionesNombre_Sel ;
      private string AV49TFComisionesNombre ;
      private string AV60Comisionesagruparwwds_3_comisionestipo1 ;
      private string AV63Comisionesagruparwwds_6_comisionestipo2 ;
      private string AV66Comisionesagruparwwds_9_comisionestipo3 ;
      private string AV70Comisionesagruparwwds_13_tfcomisionesnombre ;
      private string AV71Comisionesagruparwwds_14_tfcomisionesnombre_sel ;
      private string lV70Comisionesagruparwwds_13_tfcomisionesnombre ;
      private string A505ComisionesTipo ;
      private string A504ComisionesNombre ;
      private string GXt_char2 ;
      private bool AV8IsAuthorized ;
      private bool GXt_boolean1 ;
      private bool returnInSub ;
      private bool AV22DynamicFiltersEnabled2 ;
      private bool AV25DynamicFiltersEnabled3 ;
      private bool AV61Comisionesagruparwwds_4_dynamicfiltersenabled2 ;
      private bool AV64Comisionesagruparwwds_7_dynamicfiltersenabled3 ;
      private bool AV18OrderedDsc ;
      private bool n506ComisionesDefault ;
      private string AV36ColumnsSelectorXML ;
      private string AV37UserCustomValue ;
      private string AV46TFComisionesTipo_SelsJson ;
      private string AV12Filename ;
      private string AV13ErrorMessage ;
      private string AV19FilterFullText ;
      private string AV20DynamicFiltersSelector1 ;
      private string AV23DynamicFiltersSelector2 ;
      private string AV26DynamicFiltersSelector3 ;
      private string AV58Comisionesagruparwwds_1_filterfulltext ;
      private string AV59Comisionesagruparwwds_2_dynamicfiltersselector1 ;
      private string AV62Comisionesagruparwwds_5_dynamicfiltersselector2 ;
      private string AV65Comisionesagruparwwds_8_dynamicfiltersselector3 ;
      private string lV58Comisionesagruparwwds_1_filterfulltext ;
      private IGxSession AV29Session ;
      private ExcelDocumentI AV11ExcelDocument ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV31GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV28GridStateDynamicFilter ;
      private GxSimpleCollection<string> AV47TFComisionesTipo_Sels ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector AV33ColumnsSelector ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column AV35ColumnsSelector_Column ;
      private GxSimpleCollection<string> AV69Comisionesagruparwwds_12_tfcomisionestipo_sels ;
      private IDataStoreProvider pr_default ;
      private decimal[] P006N2_A506ComisionesDefault ;
      private bool[] P006N2_n506ComisionesDefault ;
      private string[] P006N2_A504ComisionesNombre ;
      private long[] P006N2_A503ComisionesID ;
      private string[] P006N2_A505ComisionesTipo ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector AV34ColumnsSelectorAux ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV32GridStateFilterValue ;
      private string aP0_Filename ;
      private string aP1_ErrorMessage ;
   }

   public class comisionesagruparwwexport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P006N2( IGxContext context ,
                                             string A505ComisionesTipo ,
                                             GxSimpleCollection<string> AV69Comisionesagruparwwds_12_tfcomisionestipo_sels ,
                                             string AV59Comisionesagruparwwds_2_dynamicfiltersselector1 ,
                                             string AV60Comisionesagruparwwds_3_comisionestipo1 ,
                                             bool AV61Comisionesagruparwwds_4_dynamicfiltersenabled2 ,
                                             string AV62Comisionesagruparwwds_5_dynamicfiltersselector2 ,
                                             string AV63Comisionesagruparwwds_6_comisionestipo2 ,
                                             bool AV64Comisionesagruparwwds_7_dynamicfiltersenabled3 ,
                                             string AV65Comisionesagruparwwds_8_dynamicfiltersselector3 ,
                                             string AV66Comisionesagruparwwds_9_comisionestipo3 ,
                                             long AV67Comisionesagruparwwds_10_tfcomisionesid ,
                                             long AV68Comisionesagruparwwds_11_tfcomisionesid_to ,
                                             int AV69Comisionesagruparwwds_12_tfcomisionestipo_sels_Count ,
                                             string AV71Comisionesagruparwwds_14_tfcomisionesnombre_sel ,
                                             string AV70Comisionesagruparwwds_13_tfcomisionesnombre ,
                                             decimal AV72Comisionesagruparwwds_15_tfcomisionesdefault ,
                                             decimal AV73Comisionesagruparwwds_16_tfcomisionesdefault_to ,
                                             long A503ComisionesID ,
                                             string A504ComisionesNombre ,
                                             decimal A506ComisionesDefault ,
                                             short AV17OrderedBy ,
                                             bool AV18OrderedDsc ,
                                             string AV58Comisionesagruparwwds_1_filterfulltext )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int4 = new short[9];
         Object[] GXv_Object5 = new Object[2];
         scmdbuf = "SELECT [ComisionesDefault], [ComisionesNombre], [ComisionesID], [ComisionesTipo] FROM [Comisiones]";
         if ( ( StringUtil.StrCmp(AV59Comisionesagruparwwds_2_dynamicfiltersselector1, "COMISIONESTIPO") == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Comisionesagruparwwds_3_comisionestipo1)) ) )
         {
            AddWhere(sWhereString, "([ComisionesTipo] = @AV60Comisionesagruparwwds_3_comisionestipo1)");
         }
         else
         {
            GXv_int4[0] = 1;
         }
         if ( AV61Comisionesagruparwwds_4_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV62Comisionesagruparwwds_5_dynamicfiltersselector2, "COMISIONESTIPO") == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Comisionesagruparwwds_6_comisionestipo2)) ) )
         {
            AddWhere(sWhereString, "([ComisionesTipo] = @AV63Comisionesagruparwwds_6_comisionestipo2)");
         }
         else
         {
            GXv_int4[1] = 1;
         }
         if ( AV64Comisionesagruparwwds_7_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV65Comisionesagruparwwds_8_dynamicfiltersselector3, "COMISIONESTIPO") == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Comisionesagruparwwds_9_comisionestipo3)) ) )
         {
            AddWhere(sWhereString, "([ComisionesTipo] = @AV66Comisionesagruparwwds_9_comisionestipo3)");
         }
         else
         {
            GXv_int4[2] = 1;
         }
         if ( ! (0==AV67Comisionesagruparwwds_10_tfcomisionesid) )
         {
            AddWhere(sWhereString, "([ComisionesID] >= @AV67Comisionesagruparwwds_10_tfcomisionesid)");
         }
         else
         {
            GXv_int4[3] = 1;
         }
         if ( ! (0==AV68Comisionesagruparwwds_11_tfcomisionesid_to) )
         {
            AddWhere(sWhereString, "([ComisionesID] <= @AV68Comisionesagruparwwds_11_tfcomisionesid_to)");
         }
         else
         {
            GXv_int4[4] = 1;
         }
         if ( AV69Comisionesagruparwwds_12_tfcomisionestipo_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV69Comisionesagruparwwds_12_tfcomisionestipo_sels, "[ComisionesTipo] IN (", ")")+")");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV71Comisionesagruparwwds_14_tfcomisionesnombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Comisionesagruparwwds_13_tfcomisionesnombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ComisionesNombre]) like UPPER(@lV70Comisionesagruparwwds_13_tfcomisionesnombre))");
         }
         else
         {
            GXv_int4[5] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Comisionesagruparwwds_14_tfcomisionesnombre_sel)) && ! ( StringUtil.StrCmp(AV71Comisionesagruparwwds_14_tfcomisionesnombre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([ComisionesNombre] = @AV71Comisionesagruparwwds_14_tfcomisionesnombre_sel)");
         }
         else
         {
            GXv_int4[6] = 1;
         }
         if ( StringUtil.StrCmp(AV71Comisionesagruparwwds_14_tfcomisionesnombre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([ComisionesNombre] = ''))");
         }
         if ( ! (Convert.ToDecimal(0)==AV72Comisionesagruparwwds_15_tfcomisionesdefault) )
         {
            AddWhere(sWhereString, "([ComisionesDefault] >= @AV72Comisionesagruparwwds_15_tfcomisionesdefault)");
         }
         else
         {
            GXv_int4[7] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV73Comisionesagruparwwds_16_tfcomisionesdefault_to) )
         {
            AddWhere(sWhereString, "([ComisionesDefault] <= @AV73Comisionesagruparwwds_16_tfcomisionesdefault_to)");
         }
         else
         {
            GXv_int4[8] = 1;
         }
         scmdbuf += sWhereString;
         if ( ( AV17OrderedBy == 1 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY [ComisionesTipo]";
         }
         else if ( ( AV17OrderedBy == 1 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [ComisionesTipo] DESC";
         }
         else if ( ( AV17OrderedBy == 2 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY [ComisionesID]";
         }
         else if ( ( AV17OrderedBy == 2 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [ComisionesID] DESC";
         }
         else if ( ( AV17OrderedBy == 3 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY [ComisionesNombre]";
         }
         else if ( ( AV17OrderedBy == 3 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [ComisionesNombre] DESC";
         }
         else if ( ( AV17OrderedBy == 4 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY [ComisionesDefault]";
         }
         else if ( ( AV17OrderedBy == 4 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [ComisionesDefault] DESC";
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
                     return conditional_P006N2(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (bool)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (bool)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (long)dynConstraints[10] , (long)dynConstraints[11] , (int)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (decimal)dynConstraints[15] , (decimal)dynConstraints[16] , (long)dynConstraints[17] , (string)dynConstraints[18] , (decimal)dynConstraints[19] , (short)dynConstraints[20] , (bool)dynConstraints[21] , (string)dynConstraints[22] );
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
          Object[] prmP006N2;
          prmP006N2 = new Object[] {
          new ParDef("@AV60Comisionesagruparwwds_3_comisionestipo1",GXType.NChar,1,0) ,
          new ParDef("@AV63Comisionesagruparwwds_6_comisionestipo2",GXType.NChar,1,0) ,
          new ParDef("@AV66Comisionesagruparwwds_9_comisionestipo3",GXType.NChar,1,0) ,
          new ParDef("@AV67Comisionesagruparwwds_10_tfcomisionesid",GXType.Decimal,18,0) ,
          new ParDef("@AV68Comisionesagruparwwds_11_tfcomisionesid_to",GXType.Decimal,18,0) ,
          new ParDef("@lV70Comisionesagruparwwds_13_tfcomisionesnombre",GXType.Char,80,0) ,
          new ParDef("@AV71Comisionesagruparwwds_14_tfcomisionesnombre_sel",GXType.NChar,80,0) ,
          new ParDef("@AV72Comisionesagruparwwds_15_tfcomisionesdefault",GXType.Decimal,6,2) ,
          new ParDef("@AV73Comisionesagruparwwds_16_tfcomisionesdefault_to",GXType.Decimal,6,2)
          };
          def= new CursorDef[] {
              new CursorDef("P006N2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP006N2,100, GxCacheFrequency.OFF ,true,false )
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
                ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getString(2, 80);
                ((long[]) buf[3])[0] = rslt.getLong(3);
                ((string[]) buf[4])[0] = rslt.getString(4, 1);
                return;
       }
    }

 }

}

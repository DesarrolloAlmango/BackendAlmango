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
   public class textoswwexport : GXProcedure
   {
      public textoswwexport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public textoswwexport( IGxContext context )
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
         new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWTextos", out  GXt_boolean1) ;
         AV8IsAuthorized = GXt_boolean1;
         if ( ! AV8IsAuthorized )
         {
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "wwpbaseobjects.notauthorized.aspx"+GXUtil.UrlEncode(StringUtil.RTrim(AV59Pgmname));
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
         AV12Filename = GXt_char2 + "TextosWWExport-" + StringUtil.Trim( StringUtil.Str( (decimal)(AV16Random), 8, 0)) + ".xlsx";
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
            if ( StringUtil.StrCmp(AV20DynamicFiltersSelector1, "TEXTOSTIPO") == 0 )
            {
               AV21DynamicFiltersOperator1 = AV31GridStateDynamicFilter.gxTpr_Operator;
               AV22TextosTipo1 = AV31GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV22TextosTipo1)) )
               {
                  AV14CellRow = (int)(AV14CellRow+1);
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Bold = 1;
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Color = 3;
                  if ( AV21DynamicFiltersOperator1 == 0 )
                  {
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", context.GetMessage( "Tipo", ""), context.GetMessage( "WWP_FilterLike", ""), "", "", "", "", "", "", "");
                  }
                  else if ( AV21DynamicFiltersOperator1 == 1 )
                  {
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", context.GetMessage( "Tipo", ""), context.GetMessage( "WWP_FilterContains", ""), "", "", "", "", "", "", "");
                  }
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Italic = 1;
                  GXt_char2 = "";
                  new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV22TextosTipo1, out  GXt_char2) ;
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
               }
            }
            if ( AV34GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV23DynamicFiltersEnabled2 = true;
               AV31GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV34GridState.gxTpr_Dynamicfilters.Item(2));
               AV24DynamicFiltersSelector2 = AV31GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV24DynamicFiltersSelector2, "TEXTOSTIPO") == 0 )
               {
                  AV25DynamicFiltersOperator2 = AV31GridStateDynamicFilter.gxTpr_Operator;
                  AV26TextosTipo2 = AV31GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV26TextosTipo2)) )
                  {
                     AV14CellRow = (int)(AV14CellRow+1);
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Bold = 1;
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Color = 3;
                     if ( AV25DynamicFiltersOperator2 == 0 )
                     {
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", context.GetMessage( "Tipo", ""), context.GetMessage( "WWP_FilterLike", ""), "", "", "", "", "", "", "");
                     }
                     else if ( AV25DynamicFiltersOperator2 == 1 )
                     {
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", context.GetMessage( "Tipo", ""), context.GetMessage( "WWP_FilterContains", ""), "", "", "", "", "", "", "");
                     }
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Italic = 1;
                     GXt_char2 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV26TextosTipo2, out  GXt_char2) ;
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
                  }
               }
               if ( AV34GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV27DynamicFiltersEnabled3 = true;
                  AV31GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV34GridState.gxTpr_Dynamicfilters.Item(3));
                  AV28DynamicFiltersSelector3 = AV31GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV28DynamicFiltersSelector3, "TEXTOSTIPO") == 0 )
                  {
                     AV29DynamicFiltersOperator3 = AV31GridStateDynamicFilter.gxTpr_Operator;
                     AV30TextosTipo3 = AV31GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV30TextosTipo3)) )
                     {
                        AV14CellRow = (int)(AV14CellRow+1);
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Bold = 1;
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Color = 3;
                        if ( AV29DynamicFiltersOperator3 == 0 )
                        {
                           AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", context.GetMessage( "Tipo", ""), context.GetMessage( "WWP_FilterLike", ""), "", "", "", "", "", "", "");
                        }
                        else if ( AV29DynamicFiltersOperator3 == 1 )
                        {
                           AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", context.GetMessage( "Tipo", ""), context.GetMessage( "WWP_FilterContains", ""), "", "", "", "", "", "", "");
                        }
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Italic = 1;
                        GXt_char2 = "";
                        new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV30TextosTipo3, out  GXt_char2) ;
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
                     }
                  }
               }
            }
         }
         if ( ! ( (0==AV47TFTextosId) && (0==AV48TFTextosId_To) ) )
         {
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Id", "")) ;
            AV14CellRow = GXt_int3;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Number = AV47TFTextosId;
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  false, ref  GXt_int3,  (short)(AV15FirstColumn+2),  context.GetMessage( "WWP_TSTo", "")) ;
            AV14CellRow = GXt_int3;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+3, 1, 1).Number = AV48TFTextosId_To;
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV50TFTextosTipo_Sel)) ) )
         {
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Tipo", "")) ;
            AV14CellRow = GXt_int3;
            GXt_char2 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV50TFTextosTipo_Sel)) ? context.GetMessage( "WWP_TitleFilter_EmptyOption", "") : AV50TFTextosTipo_Sel), out  GXt_char2) ;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV49TFTextosTipo)) ) )
            {
               GXt_int3 = (short)(AV14CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Tipo", "")) ;
               AV14CellRow = GXt_int3;
               GXt_char2 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV49TFTextosTipo, out  GXt_char2) ;
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV52TFTextosTitulo_Sel)) ) )
         {
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Titulo", "")) ;
            AV14CellRow = GXt_int3;
            GXt_char2 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV52TFTextosTitulo_Sel)) ? context.GetMessage( "WWP_TitleFilter_EmptyOption", "") : AV52TFTextosTitulo_Sel), out  GXt_char2) ;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV51TFTextosTitulo)) ) )
            {
               GXt_int3 = (short)(AV14CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Titulo", "")) ;
               AV14CellRow = GXt_int3;
               GXt_char2 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV51TFTextosTitulo, out  GXt_char2) ;
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
            }
         }
         if ( ! ( ( AV54TFTextosEstado_Sels.Count == 0 ) ) )
         {
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Estado", "")) ;
            AV14CellRow = GXt_int3;
            AV56i = 1;
            AV60GXV1 = 1;
            while ( AV60GXV1 <= AV54TFTextosEstado_Sels.Count )
            {
               AV55TFTextosEstado_Sel = AV54TFTextosEstado_Sels.GetString(AV60GXV1);
               if ( AV56i == 1 )
               {
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = "";
               }
               else
               {
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text+", ";
               }
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text+context.GetMessage( gxdomainestadoenum.getDescription(context,AV55TFTextosEstado_Sel), "");
               AV56i = (long)(AV56i+1);
               AV60GXV1 = (int)(AV60GXV1+1);
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV58TFTextosRutaPDF_Sel)) ) )
         {
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Ruta PDF", "")) ;
            AV14CellRow = GXt_int3;
            GXt_char2 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV58TFTextosRutaPDF_Sel)) ? context.GetMessage( "WWP_TitleFilter_EmptyOption", "") : AV58TFTextosRutaPDF_Sel), out  GXt_char2) ;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV57TFTextosRutaPDF)) ) )
            {
               GXt_int3 = (short)(AV14CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Ruta PDF", "")) ;
               AV14CellRow = GXt_int3;
               GXt_char2 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV57TFTextosRutaPDF, out  GXt_char2) ;
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
         if ( StringUtil.StrCmp(AV32Session.Get("TextosWWColumnsSelector"), "") != 0 )
         {
            AV39ColumnsSelectorXML = AV32Session.Get("TextosWWColumnsSelector");
            AV36ColumnsSelector.FromXml(AV39ColumnsSelectorXML, null, "", "");
         }
         else
         {
            /* Execute user subroutine: 'INITIALIZECOLUMNSSELECTOR' */
            S151 ();
            if (returnInSub) return;
         }
         AV36ColumnsSelector.gxTpr_Columns.Sort("Order");
         AV61GXV2 = 1;
         while ( AV61GXV2 <= AV36ColumnsSelector.gxTpr_Columns.Count )
         {
            AV38ColumnsSelector_Column = ((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV36ColumnsSelector.gxTpr_Columns.Item(AV61GXV2));
            if ( AV38ColumnsSelector_Column.gxTpr_Isvisible )
            {
               AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV44VisibleColumnCount), 1, 1).Text = context.GetMessage( (String.IsNullOrEmpty(StringUtil.RTrim( AV38ColumnsSelector_Column.gxTpr_Displayname)) ? AV38ColumnsSelector_Column.gxTpr_Columnname : AV38ColumnsSelector_Column.gxTpr_Displayname), "");
               AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV44VisibleColumnCount), 1, 1).Bold = 1;
               AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV44VisibleColumnCount), 1, 1).Color = 11;
               AV44VisibleColumnCount = (long)(AV44VisibleColumnCount+1);
            }
            AV61GXV2 = (int)(AV61GXV2+1);
         }
      }

      protected void S161( )
      {
         /* 'WRITEDATA' Routine */
         returnInSub = false;
         AV63Textoswwds_1_filterfulltext = AV19FilterFullText;
         AV64Textoswwds_2_dynamicfiltersselector1 = AV20DynamicFiltersSelector1;
         AV65Textoswwds_3_dynamicfiltersoperator1 = AV21DynamicFiltersOperator1;
         AV66Textoswwds_4_textostipo1 = AV22TextosTipo1;
         AV67Textoswwds_5_dynamicfiltersenabled2 = AV23DynamicFiltersEnabled2;
         AV68Textoswwds_6_dynamicfiltersselector2 = AV24DynamicFiltersSelector2;
         AV69Textoswwds_7_dynamicfiltersoperator2 = AV25DynamicFiltersOperator2;
         AV70Textoswwds_8_textostipo2 = AV26TextosTipo2;
         AV71Textoswwds_9_dynamicfiltersenabled3 = AV27DynamicFiltersEnabled3;
         AV72Textoswwds_10_dynamicfiltersselector3 = AV28DynamicFiltersSelector3;
         AV73Textoswwds_11_dynamicfiltersoperator3 = AV29DynamicFiltersOperator3;
         AV74Textoswwds_12_textostipo3 = AV30TextosTipo3;
         AV75Textoswwds_13_tftextosid = AV47TFTextosId;
         AV76Textoswwds_14_tftextosid_to = AV48TFTextosId_To;
         AV77Textoswwds_15_tftextostipo = AV49TFTextosTipo;
         AV78Textoswwds_16_tftextostipo_sel = AV50TFTextosTipo_Sel;
         AV79Textoswwds_17_tftextostitulo = AV51TFTextosTitulo;
         AV80Textoswwds_18_tftextostitulo_sel = AV52TFTextosTitulo_Sel;
         AV81Textoswwds_19_tftextosestado_sels = AV54TFTextosEstado_Sels;
         AV82Textoswwds_20_tftextosrutapdf = AV57TFTextosRutaPDF;
         AV83Textoswwds_21_tftextosrutapdf_sel = AV58TFTextosRutaPDF_Sel;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A534TextosEstado ,
                                              AV81Textoswwds_19_tftextosestado_sels ,
                                              AV64Textoswwds_2_dynamicfiltersselector1 ,
                                              AV65Textoswwds_3_dynamicfiltersoperator1 ,
                                              AV66Textoswwds_4_textostipo1 ,
                                              AV67Textoswwds_5_dynamicfiltersenabled2 ,
                                              AV68Textoswwds_6_dynamicfiltersselector2 ,
                                              AV69Textoswwds_7_dynamicfiltersoperator2 ,
                                              AV70Textoswwds_8_textostipo2 ,
                                              AV71Textoswwds_9_dynamicfiltersenabled3 ,
                                              AV72Textoswwds_10_dynamicfiltersselector3 ,
                                              AV73Textoswwds_11_dynamicfiltersoperator3 ,
                                              AV74Textoswwds_12_textostipo3 ,
                                              AV75Textoswwds_13_tftextosid ,
                                              AV76Textoswwds_14_tftextosid_to ,
                                              AV78Textoswwds_16_tftextostipo_sel ,
                                              AV77Textoswwds_15_tftextostipo ,
                                              AV80Textoswwds_18_tftextostitulo_sel ,
                                              AV79Textoswwds_17_tftextostitulo ,
                                              AV81Textoswwds_19_tftextosestado_sels.Count ,
                                              AV83Textoswwds_21_tftextosrutapdf_sel ,
                                              AV82Textoswwds_20_tftextosrutapdf ,
                                              A258TextosTipo ,
                                              A150TextosId ,
                                              A259TextosTitulo ,
                                              A977TextosRutaPDF ,
                                              AV17OrderedBy ,
                                              AV18OrderedDsc ,
                                              AV63Textoswwds_1_filterfulltext } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.INT, TypeConstants.LONG,
                                              TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV66Textoswwds_4_textostipo1 = StringUtil.PadR( StringUtil.RTrim( AV66Textoswwds_4_textostipo1), 20, "%");
         lV66Textoswwds_4_textostipo1 = StringUtil.PadR( StringUtil.RTrim( AV66Textoswwds_4_textostipo1), 20, "%");
         lV70Textoswwds_8_textostipo2 = StringUtil.PadR( StringUtil.RTrim( AV70Textoswwds_8_textostipo2), 20, "%");
         lV70Textoswwds_8_textostipo2 = StringUtil.PadR( StringUtil.RTrim( AV70Textoswwds_8_textostipo2), 20, "%");
         lV74Textoswwds_12_textostipo3 = StringUtil.PadR( StringUtil.RTrim( AV74Textoswwds_12_textostipo3), 20, "%");
         lV74Textoswwds_12_textostipo3 = StringUtil.PadR( StringUtil.RTrim( AV74Textoswwds_12_textostipo3), 20, "%");
         lV77Textoswwds_15_tftextostipo = StringUtil.PadR( StringUtil.RTrim( AV77Textoswwds_15_tftextostipo), 20, "%");
         lV79Textoswwds_17_tftextostitulo = StringUtil.PadR( StringUtil.RTrim( AV79Textoswwds_17_tftextostitulo), 80, "%");
         lV82Textoswwds_20_tftextosrutapdf = StringUtil.Concat( StringUtil.RTrim( AV82Textoswwds_20_tftextosrutapdf), "%", "");
         /* Using cursor P00512 */
         pr_default.execute(0, new Object[] {lV66Textoswwds_4_textostipo1, lV66Textoswwds_4_textostipo1, lV70Textoswwds_8_textostipo2, lV70Textoswwds_8_textostipo2, lV74Textoswwds_12_textostipo3, lV74Textoswwds_12_textostipo3, AV75Textoswwds_13_tftextosid, AV76Textoswwds_14_tftextosid_to, lV77Textoswwds_15_tftextostipo, AV78Textoswwds_16_tftextostipo_sel, lV79Textoswwds_17_tftextostitulo, AV80Textoswwds_18_tftextostitulo_sel, lV82Textoswwds_20_tftextosrutapdf, AV83Textoswwds_21_tftextosrutapdf_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A977TextosRutaPDF = P00512_A977TextosRutaPDF[0];
            n977TextosRutaPDF = P00512_n977TextosRutaPDF[0];
            A259TextosTitulo = P00512_A259TextosTitulo[0];
            A258TextosTipo = P00512_A258TextosTipo[0];
            A150TextosId = P00512_A150TextosId[0];
            A534TextosEstado = P00512_A534TextosEstado[0];
            n534TextosEstado = P00512_n534TextosEstado[0];
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV63Textoswwds_1_filterfulltext)) || ( ( StringUtil.Like( StringUtil.Str( (decimal)(A150TextosId), 18, 0) , StringUtil.PadR( "%" + AV63Textoswwds_1_filterfulltext , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A258TextosTipo) , StringUtil.PadR( "%" + StringUtil.Upper( AV63Textoswwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A259TextosTitulo) , StringUtil.PadR( "%" + StringUtil.Upper( AV63Textoswwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( context.GetMessage( "habilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV63Textoswwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A534TextosEstado, "HAB") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "deshabilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV63Textoswwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A534TextosEstado, "DES") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "pendiente", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV63Textoswwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A534TextosEstado, "PEN") == 0 ) ) || ( StringUtil.Like( StringUtil.Upper( A977TextosRutaPDF) , StringUtil.PadR( "%" + StringUtil.Upper( AV63Textoswwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) ) )
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
               AV84GXV3 = 1;
               while ( AV84GXV3 <= AV36ColumnsSelector.gxTpr_Columns.Count )
               {
                  AV38ColumnsSelector_Column = ((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV36ColumnsSelector.gxTpr_Columns.Item(AV84GXV3));
                  if ( AV38ColumnsSelector_Column.gxTpr_Isvisible )
                  {
                     if ( StringUtil.StrCmp(AV38ColumnsSelector_Column.gxTpr_Columnname, "TextosId") == 0 )
                     {
                        AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV44VisibleColumnCount), 1, 1).Number = A150TextosId;
                     }
                     else if ( StringUtil.StrCmp(AV38ColumnsSelector_Column.gxTpr_Columnname, "TextosTipo") == 0 )
                     {
                        GXt_char2 = "";
                        new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A258TextosTipo, out  GXt_char2) ;
                        AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV44VisibleColumnCount), 1, 1).Text = GXt_char2;
                     }
                     else if ( StringUtil.StrCmp(AV38ColumnsSelector_Column.gxTpr_Columnname, "TextosTitulo") == 0 )
                     {
                        GXt_char2 = "";
                        new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A259TextosTitulo, out  GXt_char2) ;
                        AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV44VisibleColumnCount), 1, 1).Text = GXt_char2;
                     }
                     else if ( StringUtil.StrCmp(AV38ColumnsSelector_Column.gxTpr_Columnname, "TextosEstado") == 0 )
                     {
                        AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV44VisibleColumnCount), 1, 1).Text = context.GetMessage( gxdomainestadoenum.getDescription(context,A534TextosEstado), "");
                     }
                     else if ( StringUtil.StrCmp(AV38ColumnsSelector_Column.gxTpr_Columnname, "TextosRutaPDF") == 0 )
                     {
                        GXt_char2 = "";
                        new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A977TextosRutaPDF, out  GXt_char2) ;
                        AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV44VisibleColumnCount), 1, 1).Text = GXt_char2;
                     }
                     AV44VisibleColumnCount = (long)(AV44VisibleColumnCount+1);
                  }
                  AV84GXV3 = (int)(AV84GXV3+1);
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
         AV32Session.Set("WWPExportFileName", "TextosWWExport.xlsx");
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
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV36ColumnsSelector,  "TextosId",  "",  "Id",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV36ColumnsSelector,  "TextosTipo",  "",  "Tipo",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV36ColumnsSelector,  "TextosTitulo",  "",  "Titulo",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV36ColumnsSelector,  "TextosEstado",  "",  "Estado",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV36ColumnsSelector,  "TextosRutaPDF",  "",  "Ruta PDF",  true,  "") ;
         GXt_char2 = AV40UserCustomValue;
         new GeneXus.Programs.wwpbaseobjects.loadcolumnsselectorstate(context ).execute(  "TextosWWColumnsSelector", out  GXt_char2) ;
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
         if ( StringUtil.StrCmp(AV32Session.Get("TextosWWGridState"), "") == 0 )
         {
            AV34GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "TextosWWGridState"), null, "", "");
         }
         else
         {
            AV34GridState.FromXml(AV32Session.Get("TextosWWGridState"), null, "", "");
         }
         AV17OrderedBy = AV34GridState.gxTpr_Orderedby;
         AV18OrderedDsc = AV34GridState.gxTpr_Ordereddsc;
         AV85GXV4 = 1;
         while ( AV85GXV4 <= AV34GridState.gxTpr_Filtervalues.Count )
         {
            AV35GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV34GridState.gxTpr_Filtervalues.Item(AV85GXV4));
            if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV19FilterFullText = AV35GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFTEXTOSID") == 0 )
            {
               AV47TFTextosId = (long)(Math.Round(NumberUtil.Val( AV35GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV48TFTextosId_To = (long)(Math.Round(NumberUtil.Val( AV35GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFTEXTOSTIPO") == 0 )
            {
               AV49TFTextosTipo = AV35GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFTEXTOSTIPO_SEL") == 0 )
            {
               AV50TFTextosTipo_Sel = AV35GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFTEXTOSTITULO") == 0 )
            {
               AV51TFTextosTitulo = AV35GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFTEXTOSTITULO_SEL") == 0 )
            {
               AV52TFTextosTitulo_Sel = AV35GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFTEXTOSESTADO_SEL") == 0 )
            {
               AV53TFTextosEstado_SelsJson = AV35GridStateFilterValue.gxTpr_Value;
               AV54TFTextosEstado_Sels.FromJSonString(AV53TFTextosEstado_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFTEXTOSRUTAPDF") == 0 )
            {
               AV57TFTextosRutaPDF = AV35GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFTEXTOSRUTAPDF_SEL") == 0 )
            {
               AV58TFTextosRutaPDF_Sel = AV35GridStateFilterValue.gxTpr_Value;
            }
            AV85GXV4 = (int)(AV85GXV4+1);
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
         AV59Pgmname = "";
         GXKey = "";
         GXEncryptionTmp = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV11ExcelDocument = new ExcelDocumentI();
         AV19FilterFullText = "";
         AV34GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV31GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV20DynamicFiltersSelector1 = "";
         AV22TextosTipo1 = "";
         AV24DynamicFiltersSelector2 = "";
         AV26TextosTipo2 = "";
         AV28DynamicFiltersSelector3 = "";
         AV30TextosTipo3 = "";
         AV50TFTextosTipo_Sel = "";
         AV49TFTextosTipo = "";
         AV52TFTextosTitulo_Sel = "";
         AV51TFTextosTitulo = "";
         AV54TFTextosEstado_Sels = new GxSimpleCollection<string>();
         AV55TFTextosEstado_Sel = "";
         AV58TFTextosRutaPDF_Sel = "";
         AV57TFTextosRutaPDF = "";
         AV32Session = context.GetSession();
         AV39ColumnsSelectorXML = "";
         AV36ColumnsSelector = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector(context);
         AV38ColumnsSelector_Column = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column(context);
         AV63Textoswwds_1_filterfulltext = "";
         AV64Textoswwds_2_dynamicfiltersselector1 = "";
         AV66Textoswwds_4_textostipo1 = "";
         AV68Textoswwds_6_dynamicfiltersselector2 = "";
         AV70Textoswwds_8_textostipo2 = "";
         AV72Textoswwds_10_dynamicfiltersselector3 = "";
         AV74Textoswwds_12_textostipo3 = "";
         AV77Textoswwds_15_tftextostipo = "";
         AV78Textoswwds_16_tftextostipo_sel = "";
         AV79Textoswwds_17_tftextostitulo = "";
         AV80Textoswwds_18_tftextostitulo_sel = "";
         AV81Textoswwds_19_tftextosestado_sels = new GxSimpleCollection<string>();
         AV82Textoswwds_20_tftextosrutapdf = "";
         AV83Textoswwds_21_tftextosrutapdf_sel = "";
         lV63Textoswwds_1_filterfulltext = "";
         lV66Textoswwds_4_textostipo1 = "";
         lV70Textoswwds_8_textostipo2 = "";
         lV74Textoswwds_12_textostipo3 = "";
         lV77Textoswwds_15_tftextostipo = "";
         lV79Textoswwds_17_tftextostitulo = "";
         lV82Textoswwds_20_tftextosrutapdf = "";
         A534TextosEstado = "";
         A258TextosTipo = "";
         A259TextosTitulo = "";
         A977TextosRutaPDF = "";
         P00512_A977TextosRutaPDF = new string[] {""} ;
         P00512_n977TextosRutaPDF = new bool[] {false} ;
         P00512_A259TextosTitulo = new string[] {""} ;
         P00512_A258TextosTipo = new string[] {""} ;
         P00512_A150TextosId = new long[1] ;
         P00512_A534TextosEstado = new string[] {""} ;
         P00512_n534TextosEstado = new bool[] {false} ;
         AV40UserCustomValue = "";
         GXt_char2 = "";
         AV37ColumnsSelectorAux = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector(context);
         AV35GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV53TFTextosEstado_SelsJson = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.textoswwexport__default(),
            new Object[][] {
                new Object[] {
               P00512_A977TextosRutaPDF, P00512_n977TextosRutaPDF, P00512_A259TextosTitulo, P00512_A258TextosTipo, P00512_A150TextosId, P00512_A534TextosEstado, P00512_n534TextosEstado
               }
            }
         );
         AV59Pgmname = "TextosWWExport";
         /* GeneXus formulas. */
         AV59Pgmname = "TextosWWExport";
      }

      private short AV21DynamicFiltersOperator1 ;
      private short AV25DynamicFiltersOperator2 ;
      private short AV29DynamicFiltersOperator3 ;
      private short GXt_int3 ;
      private short AV65Textoswwds_3_dynamicfiltersoperator1 ;
      private short AV69Textoswwds_7_dynamicfiltersoperator2 ;
      private short AV73Textoswwds_11_dynamicfiltersoperator3 ;
      private short AV17OrderedBy ;
      private int AV14CellRow ;
      private int AV15FirstColumn ;
      private int AV16Random ;
      private int AV60GXV1 ;
      private int AV61GXV2 ;
      private int AV81Textoswwds_19_tftextosestado_sels_Count ;
      private int AV84GXV3 ;
      private int AV85GXV4 ;
      private long AV47TFTextosId ;
      private long AV48TFTextosId_To ;
      private long AV56i ;
      private long AV44VisibleColumnCount ;
      private long AV75Textoswwds_13_tftextosid ;
      private long AV76Textoswwds_14_tftextosid_to ;
      private long A150TextosId ;
      private string AV59Pgmname ;
      private string GXKey ;
      private string GXEncryptionTmp ;
      private string AV22TextosTipo1 ;
      private string AV26TextosTipo2 ;
      private string AV30TextosTipo3 ;
      private string AV50TFTextosTipo_Sel ;
      private string AV49TFTextosTipo ;
      private string AV52TFTextosTitulo_Sel ;
      private string AV51TFTextosTitulo ;
      private string AV55TFTextosEstado_Sel ;
      private string AV66Textoswwds_4_textostipo1 ;
      private string AV70Textoswwds_8_textostipo2 ;
      private string AV74Textoswwds_12_textostipo3 ;
      private string AV77Textoswwds_15_tftextostipo ;
      private string AV78Textoswwds_16_tftextostipo_sel ;
      private string AV79Textoswwds_17_tftextostitulo ;
      private string AV80Textoswwds_18_tftextostitulo_sel ;
      private string lV66Textoswwds_4_textostipo1 ;
      private string lV70Textoswwds_8_textostipo2 ;
      private string lV74Textoswwds_12_textostipo3 ;
      private string lV77Textoswwds_15_tftextostipo ;
      private string lV79Textoswwds_17_tftextostitulo ;
      private string A534TextosEstado ;
      private string A258TextosTipo ;
      private string A259TextosTitulo ;
      private string GXt_char2 ;
      private bool AV8IsAuthorized ;
      private bool GXt_boolean1 ;
      private bool returnInSub ;
      private bool AV23DynamicFiltersEnabled2 ;
      private bool AV27DynamicFiltersEnabled3 ;
      private bool AV67Textoswwds_5_dynamicfiltersenabled2 ;
      private bool AV71Textoswwds_9_dynamicfiltersenabled3 ;
      private bool AV18OrderedDsc ;
      private bool n977TextosRutaPDF ;
      private bool n534TextosEstado ;
      private string AV39ColumnsSelectorXML ;
      private string AV40UserCustomValue ;
      private string AV53TFTextosEstado_SelsJson ;
      private string AV12Filename ;
      private string AV13ErrorMessage ;
      private string AV19FilterFullText ;
      private string AV20DynamicFiltersSelector1 ;
      private string AV24DynamicFiltersSelector2 ;
      private string AV28DynamicFiltersSelector3 ;
      private string AV58TFTextosRutaPDF_Sel ;
      private string AV57TFTextosRutaPDF ;
      private string AV63Textoswwds_1_filterfulltext ;
      private string AV64Textoswwds_2_dynamicfiltersselector1 ;
      private string AV68Textoswwds_6_dynamicfiltersselector2 ;
      private string AV72Textoswwds_10_dynamicfiltersselector3 ;
      private string AV82Textoswwds_20_tftextosrutapdf ;
      private string AV83Textoswwds_21_tftextosrutapdf_sel ;
      private string lV63Textoswwds_1_filterfulltext ;
      private string lV82Textoswwds_20_tftextosrutapdf ;
      private string A977TextosRutaPDF ;
      private IGxSession AV32Session ;
      private ExcelDocumentI AV11ExcelDocument ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV34GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV31GridStateDynamicFilter ;
      private GxSimpleCollection<string> AV54TFTextosEstado_Sels ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector AV36ColumnsSelector ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column AV38ColumnsSelector_Column ;
      private GxSimpleCollection<string> AV81Textoswwds_19_tftextosestado_sels ;
      private IDataStoreProvider pr_default ;
      private string[] P00512_A977TextosRutaPDF ;
      private bool[] P00512_n977TextosRutaPDF ;
      private string[] P00512_A259TextosTitulo ;
      private string[] P00512_A258TextosTipo ;
      private long[] P00512_A150TextosId ;
      private string[] P00512_A534TextosEstado ;
      private bool[] P00512_n534TextosEstado ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector AV37ColumnsSelectorAux ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV35GridStateFilterValue ;
      private string aP0_Filename ;
      private string aP1_ErrorMessage ;
   }

   public class textoswwexport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00512( IGxContext context ,
                                             string A534TextosEstado ,
                                             GxSimpleCollection<string> AV81Textoswwds_19_tftextosestado_sels ,
                                             string AV64Textoswwds_2_dynamicfiltersselector1 ,
                                             short AV65Textoswwds_3_dynamicfiltersoperator1 ,
                                             string AV66Textoswwds_4_textostipo1 ,
                                             bool AV67Textoswwds_5_dynamicfiltersenabled2 ,
                                             string AV68Textoswwds_6_dynamicfiltersselector2 ,
                                             short AV69Textoswwds_7_dynamicfiltersoperator2 ,
                                             string AV70Textoswwds_8_textostipo2 ,
                                             bool AV71Textoswwds_9_dynamicfiltersenabled3 ,
                                             string AV72Textoswwds_10_dynamicfiltersselector3 ,
                                             short AV73Textoswwds_11_dynamicfiltersoperator3 ,
                                             string AV74Textoswwds_12_textostipo3 ,
                                             long AV75Textoswwds_13_tftextosid ,
                                             long AV76Textoswwds_14_tftextosid_to ,
                                             string AV78Textoswwds_16_tftextostipo_sel ,
                                             string AV77Textoswwds_15_tftextostipo ,
                                             string AV80Textoswwds_18_tftextostitulo_sel ,
                                             string AV79Textoswwds_17_tftextostitulo ,
                                             int AV81Textoswwds_19_tftextosestado_sels_Count ,
                                             string AV83Textoswwds_21_tftextosrutapdf_sel ,
                                             string AV82Textoswwds_20_tftextosrutapdf ,
                                             string A258TextosTipo ,
                                             long A150TextosId ,
                                             string A259TextosTitulo ,
                                             string A977TextosRutaPDF ,
                                             short AV17OrderedBy ,
                                             bool AV18OrderedDsc ,
                                             string AV63Textoswwds_1_filterfulltext )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int4 = new short[14];
         Object[] GXv_Object5 = new Object[2];
         scmdbuf = "SELECT [TextosRutaPDF], [TextosTitulo], [TextosTipo], [TextosId], [TextosEstado] FROM [Textos]";
         if ( ( StringUtil.StrCmp(AV64Textoswwds_2_dynamicfiltersselector1, "TEXTOSTIPO") == 0 ) && ( AV65Textoswwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Textoswwds_4_textostipo1)) ) )
         {
            AddWhere(sWhereString, "(UPPER([TextosTipo]) like UPPER(@lV66Textoswwds_4_textostipo1))");
         }
         else
         {
            GXv_int4[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV64Textoswwds_2_dynamicfiltersselector1, "TEXTOSTIPO") == 0 ) && ( AV65Textoswwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Textoswwds_4_textostipo1)) ) )
         {
            AddWhere(sWhereString, "(UPPER([TextosTipo]) like '%' + UPPER(@lV66Textoswwds_4_textostipo1))");
         }
         else
         {
            GXv_int4[1] = 1;
         }
         if ( AV67Textoswwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV68Textoswwds_6_dynamicfiltersselector2, "TEXTOSTIPO") == 0 ) && ( AV69Textoswwds_7_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Textoswwds_8_textostipo2)) ) )
         {
            AddWhere(sWhereString, "(UPPER([TextosTipo]) like UPPER(@lV70Textoswwds_8_textostipo2))");
         }
         else
         {
            GXv_int4[2] = 1;
         }
         if ( AV67Textoswwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV68Textoswwds_6_dynamicfiltersselector2, "TEXTOSTIPO") == 0 ) && ( AV69Textoswwds_7_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Textoswwds_8_textostipo2)) ) )
         {
            AddWhere(sWhereString, "(UPPER([TextosTipo]) like '%' + UPPER(@lV70Textoswwds_8_textostipo2))");
         }
         else
         {
            GXv_int4[3] = 1;
         }
         if ( AV71Textoswwds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV72Textoswwds_10_dynamicfiltersselector3, "TEXTOSTIPO") == 0 ) && ( AV73Textoswwds_11_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Textoswwds_12_textostipo3)) ) )
         {
            AddWhere(sWhereString, "(UPPER([TextosTipo]) like UPPER(@lV74Textoswwds_12_textostipo3))");
         }
         else
         {
            GXv_int4[4] = 1;
         }
         if ( AV71Textoswwds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV72Textoswwds_10_dynamicfiltersselector3, "TEXTOSTIPO") == 0 ) && ( AV73Textoswwds_11_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Textoswwds_12_textostipo3)) ) )
         {
            AddWhere(sWhereString, "(UPPER([TextosTipo]) like '%' + UPPER(@lV74Textoswwds_12_textostipo3))");
         }
         else
         {
            GXv_int4[5] = 1;
         }
         if ( ! (0==AV75Textoswwds_13_tftextosid) )
         {
            AddWhere(sWhereString, "([TextosId] >= @AV75Textoswwds_13_tftextosid)");
         }
         else
         {
            GXv_int4[6] = 1;
         }
         if ( ! (0==AV76Textoswwds_14_tftextosid_to) )
         {
            AddWhere(sWhereString, "([TextosId] <= @AV76Textoswwds_14_tftextosid_to)");
         }
         else
         {
            GXv_int4[7] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV78Textoswwds_16_tftextostipo_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV77Textoswwds_15_tftextostipo)) ) )
         {
            AddWhere(sWhereString, "(UPPER([TextosTipo]) like UPPER(@lV77Textoswwds_15_tftextostipo))");
         }
         else
         {
            GXv_int4[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV78Textoswwds_16_tftextostipo_sel)) && ! ( StringUtil.StrCmp(AV78Textoswwds_16_tftextostipo_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([TextosTipo] = @AV78Textoswwds_16_tftextostipo_sel)");
         }
         else
         {
            GXv_int4[9] = 1;
         }
         if ( StringUtil.StrCmp(AV78Textoswwds_16_tftextostipo_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([TextosTipo] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV80Textoswwds_18_tftextostitulo_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV79Textoswwds_17_tftextostitulo)) ) )
         {
            AddWhere(sWhereString, "(UPPER([TextosTitulo]) like UPPER(@lV79Textoswwds_17_tftextostitulo))");
         }
         else
         {
            GXv_int4[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV80Textoswwds_18_tftextostitulo_sel)) && ! ( StringUtil.StrCmp(AV80Textoswwds_18_tftextostitulo_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([TextosTitulo] = @AV80Textoswwds_18_tftextostitulo_sel)");
         }
         else
         {
            GXv_int4[11] = 1;
         }
         if ( StringUtil.StrCmp(AV80Textoswwds_18_tftextostitulo_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([TextosTitulo] = ''))");
         }
         if ( AV81Textoswwds_19_tftextosestado_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV81Textoswwds_19_tftextosestado_sels, "[TextosEstado] IN (", ")")+")");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV83Textoswwds_21_tftextosrutapdf_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV82Textoswwds_20_tftextosrutapdf)) ) )
         {
            AddWhere(sWhereString, "(UPPER([TextosRutaPDF]) like UPPER(@lV82Textoswwds_20_tftextosrutapdf))");
         }
         else
         {
            GXv_int4[12] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV83Textoswwds_21_tftextosrutapdf_sel)) && ! ( StringUtil.StrCmp(AV83Textoswwds_21_tftextosrutapdf_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([TextosRutaPDF] = @AV83Textoswwds_21_tftextosrutapdf_sel)");
         }
         else
         {
            GXv_int4[13] = 1;
         }
         if ( StringUtil.StrCmp(AV83Textoswwds_21_tftextosrutapdf_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "([TextosRutaPDF] IS NULL or ([TextosRutaPDF] = ''))");
         }
         scmdbuf += sWhereString;
         if ( ( AV17OrderedBy == 1 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY [TextosTipo]";
         }
         else if ( ( AV17OrderedBy == 1 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [TextosTipo] DESC";
         }
         else if ( ( AV17OrderedBy == 2 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY [TextosId]";
         }
         else if ( ( AV17OrderedBy == 2 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [TextosId] DESC";
         }
         else if ( ( AV17OrderedBy == 3 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY [TextosTitulo]";
         }
         else if ( ( AV17OrderedBy == 3 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [TextosTitulo] DESC";
         }
         else if ( ( AV17OrderedBy == 4 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY [TextosEstado]";
         }
         else if ( ( AV17OrderedBy == 4 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [TextosEstado] DESC";
         }
         else if ( ( AV17OrderedBy == 5 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY [TextosRutaPDF]";
         }
         else if ( ( AV17OrderedBy == 5 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [TextosRutaPDF] DESC";
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
                     return conditional_P00512(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (bool)dynConstraints[5] , (string)dynConstraints[6] , (short)dynConstraints[7] , (string)dynConstraints[8] , (bool)dynConstraints[9] , (string)dynConstraints[10] , (short)dynConstraints[11] , (string)dynConstraints[12] , (long)dynConstraints[13] , (long)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (int)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (long)dynConstraints[23] , (string)dynConstraints[24] , (string)dynConstraints[25] , (short)dynConstraints[26] , (bool)dynConstraints[27] , (string)dynConstraints[28] );
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
          Object[] prmP00512;
          prmP00512 = new Object[] {
          new ParDef("@lV66Textoswwds_4_textostipo1",GXType.Char,20,0) ,
          new ParDef("@lV66Textoswwds_4_textostipo1",GXType.Char,20,0) ,
          new ParDef("@lV70Textoswwds_8_textostipo2",GXType.Char,20,0) ,
          new ParDef("@lV70Textoswwds_8_textostipo2",GXType.Char,20,0) ,
          new ParDef("@lV74Textoswwds_12_textostipo3",GXType.Char,20,0) ,
          new ParDef("@lV74Textoswwds_12_textostipo3",GXType.Char,20,0) ,
          new ParDef("@AV75Textoswwds_13_tftextosid",GXType.Decimal,18,0) ,
          new ParDef("@AV76Textoswwds_14_tftextosid_to",GXType.Decimal,18,0) ,
          new ParDef("@lV77Textoswwds_15_tftextostipo",GXType.Char,20,0) ,
          new ParDef("@AV78Textoswwds_16_tftextostipo_sel",GXType.NChar,20,0) ,
          new ParDef("@lV79Textoswwds_17_tftextostitulo",GXType.Char,80,0) ,
          new ParDef("@AV80Textoswwds_18_tftextostitulo_sel",GXType.NChar,80,0) ,
          new ParDef("@lV82Textoswwds_20_tftextosrutapdf",GXType.VarChar,100,0) ,
          new ParDef("@AV83Textoswwds_21_tftextosrutapdf_sel",GXType.NVarChar,100,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00512", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00512,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getString(2, 80);
                ((string[]) buf[3])[0] = rslt.getString(3, 20);
                ((long[]) buf[4])[0] = rslt.getLong(4);
                ((string[]) buf[5])[0] = rslt.getString(5, 3);
                ((bool[]) buf[6])[0] = rslt.wasNull(5);
                return;
       }
    }

 }

}

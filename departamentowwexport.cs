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
   public class departamentowwexport : GXProcedure
   {
      public departamentowwexport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public departamentowwexport( IGxContext context )
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
         new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWDepartamento", out  GXt_boolean1) ;
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
         AV12Filename = GXt_char2 + "DepartamentoWWExport-" + StringUtil.Trim( StringUtil.Str( (decimal)(AV16Random), 8, 0)) + ".xlsx";
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
            if ( StringUtil.StrCmp(AV20DynamicFiltersSelector1, "DEPARTAMENTODEPARTAMENTO") == 0 )
            {
               AV21DynamicFiltersOperator1 = AV31GridStateDynamicFilter.gxTpr_Operator;
               AV22DepartamentoDepartamento1 = AV31GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV22DepartamentoDepartamento1)) )
               {
                  AV14CellRow = (int)(AV14CellRow+1);
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Bold = 1;
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Color = 3;
                  if ( AV21DynamicFiltersOperator1 == 0 )
                  {
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", context.GetMessage( "Departamento", ""), context.GetMessage( "WWP_FilterLike", ""), "", "", "", "", "", "", "");
                  }
                  else if ( AV21DynamicFiltersOperator1 == 1 )
                  {
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", context.GetMessage( "Departamento", ""), context.GetMessage( "WWP_FilterContains", ""), "", "", "", "", "", "", "");
                  }
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Italic = 1;
                  GXt_char2 = "";
                  new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV22DepartamentoDepartamento1, out  GXt_char2) ;
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
               }
            }
            if ( AV34GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV23DynamicFiltersEnabled2 = true;
               AV31GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV34GridState.gxTpr_Dynamicfilters.Item(2));
               AV24DynamicFiltersSelector2 = AV31GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV24DynamicFiltersSelector2, "DEPARTAMENTODEPARTAMENTO") == 0 )
               {
                  AV25DynamicFiltersOperator2 = AV31GridStateDynamicFilter.gxTpr_Operator;
                  AV26DepartamentoDepartamento2 = AV31GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV26DepartamentoDepartamento2)) )
                  {
                     AV14CellRow = (int)(AV14CellRow+1);
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Bold = 1;
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Color = 3;
                     if ( AV25DynamicFiltersOperator2 == 0 )
                     {
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", context.GetMessage( "Departamento", ""), context.GetMessage( "WWP_FilterLike", ""), "", "", "", "", "", "", "");
                     }
                     else if ( AV25DynamicFiltersOperator2 == 1 )
                     {
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", context.GetMessage( "Departamento", ""), context.GetMessage( "WWP_FilterContains", ""), "", "", "", "", "", "", "");
                     }
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Italic = 1;
                     GXt_char2 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV26DepartamentoDepartamento2, out  GXt_char2) ;
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
                  }
               }
               if ( AV34GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV27DynamicFiltersEnabled3 = true;
                  AV31GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV34GridState.gxTpr_Dynamicfilters.Item(3));
                  AV28DynamicFiltersSelector3 = AV31GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV28DynamicFiltersSelector3, "DEPARTAMENTODEPARTAMENTO") == 0 )
                  {
                     AV29DynamicFiltersOperator3 = AV31GridStateDynamicFilter.gxTpr_Operator;
                     AV30DepartamentoDepartamento3 = AV31GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV30DepartamentoDepartamento3)) )
                     {
                        AV14CellRow = (int)(AV14CellRow+1);
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Bold = 1;
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Color = 3;
                        if ( AV29DynamicFiltersOperator3 == 0 )
                        {
                           AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", context.GetMessage( "Departamento", ""), context.GetMessage( "WWP_FilterLike", ""), "", "", "", "", "", "", "");
                        }
                        else if ( AV29DynamicFiltersOperator3 == 1 )
                        {
                           AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", context.GetMessage( "Departamento", ""), context.GetMessage( "WWP_FilterContains", ""), "", "", "", "", "", "", "");
                        }
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Italic = 1;
                        GXt_char2 = "";
                        new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV30DepartamentoDepartamento3, out  GXt_char2) ;
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
                     }
                  }
               }
            }
         }
         if ( ! ( (0==AV47TFDepartamentoId) && (0==AV48TFDepartamentoId_To) ) )
         {
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Departamento", "")) ;
            AV14CellRow = GXt_int3;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Number = AV47TFDepartamentoId;
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  false, ref  GXt_int3,  (short)(AV15FirstColumn+2),  context.GetMessage( "WWP_TSTo", "")) ;
            AV14CellRow = GXt_int3;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+3, 1, 1).Number = AV48TFDepartamentoId_To;
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV50TFPaisID_Sel)) ) )
         {
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "PaisId", "")) ;
            AV14CellRow = GXt_int3;
            GXt_char2 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV50TFPaisID_Sel)) ? context.GetMessage( "WWP_TitleFilter_EmptyOption", "") : AV50TFPaisID_Sel), out  GXt_char2) ;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV49TFPaisID)) ) )
            {
               GXt_int3 = (short)(AV14CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "PaisId", "")) ;
               AV14CellRow = GXt_int3;
               GXt_char2 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV49TFPaisID, out  GXt_char2) ;
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV52TFDepartamentoDepartamento_Sel)) ) )
         {
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Departamento", "")) ;
            AV14CellRow = GXt_int3;
            GXt_char2 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV52TFDepartamentoDepartamento_Sel)) ? context.GetMessage( "WWP_TitleFilter_EmptyOption", "") : AV52TFDepartamentoDepartamento_Sel), out  GXt_char2) ;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV51TFDepartamentoDepartamento)) ) )
            {
               GXt_int3 = (short)(AV14CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Departamento", "")) ;
               AV14CellRow = GXt_int3;
               GXt_char2 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV51TFDepartamentoDepartamento, out  GXt_char2) ;
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
            }
         }
         if ( ! ( ( AV58TFDepartamentoEstado_Sels.Count == 0 ) ) )
         {
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Estado", "")) ;
            AV14CellRow = GXt_int3;
            AV55i = 1;
            AV60GXV1 = 1;
            while ( AV60GXV1 <= AV58TFDepartamentoEstado_Sels.Count )
            {
               AV57TFDepartamentoEstado_Sel = AV58TFDepartamentoEstado_Sels.GetString(AV60GXV1);
               if ( AV55i == 1 )
               {
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = "";
               }
               else
               {
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text+", ";
               }
               if ( StringUtil.StrCmp(StringUtil.Trim( AV57TFDepartamentoEstado_Sel), context.GetMessage( "HAB", "")) == 0 )
               {
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text+context.GetMessage( "Habilitado", "");
               }
               else if ( StringUtil.StrCmp(StringUtil.Trim( AV57TFDepartamentoEstado_Sel), context.GetMessage( "DES", "")) == 0 )
               {
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text+context.GetMessage( "Deshabilitado", "");
               }
               AV55i = (long)(AV55i+1);
               AV60GXV1 = (int)(AV60GXV1+1);
            }
         }
         if ( ! ( (0==AV53TFDepartamentoAutEnuMuni) && (0==AV54TFDepartamentoAutEnuMuni_To) ) )
         {
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Enu Muni", "")) ;
            AV14CellRow = GXt_int3;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Number = AV53TFDepartamentoAutEnuMuni;
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  false, ref  GXt_int3,  (short)(AV15FirstColumn+2),  context.GetMessage( "WWP_TSTo", "")) ;
            AV14CellRow = GXt_int3;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+3, 1, 1).Number = AV54TFDepartamentoAutEnuMuni_To;
         }
         AV14CellRow = (int)(AV14CellRow+2);
      }

      protected void S141( )
      {
         /* 'WRITECOLUMNTITLES' Routine */
         returnInSub = false;
         AV44VisibleColumnCount = 0;
         if ( StringUtil.StrCmp(AV32Session.Get("DepartamentoWWColumnsSelector"), "") != 0 )
         {
            AV39ColumnsSelectorXML = AV32Session.Get("DepartamentoWWColumnsSelector");
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
         AV63Departamentowwds_1_filterfulltext = AV19FilterFullText;
         AV64Departamentowwds_2_dynamicfiltersselector1 = AV20DynamicFiltersSelector1;
         AV65Departamentowwds_3_dynamicfiltersoperator1 = AV21DynamicFiltersOperator1;
         AV66Departamentowwds_4_departamentodepartamento1 = AV22DepartamentoDepartamento1;
         AV67Departamentowwds_5_dynamicfiltersenabled2 = AV23DynamicFiltersEnabled2;
         AV68Departamentowwds_6_dynamicfiltersselector2 = AV24DynamicFiltersSelector2;
         AV69Departamentowwds_7_dynamicfiltersoperator2 = AV25DynamicFiltersOperator2;
         AV70Departamentowwds_8_departamentodepartamento2 = AV26DepartamentoDepartamento2;
         AV71Departamentowwds_9_dynamicfiltersenabled3 = AV27DynamicFiltersEnabled3;
         AV72Departamentowwds_10_dynamicfiltersselector3 = AV28DynamicFiltersSelector3;
         AV73Departamentowwds_11_dynamicfiltersoperator3 = AV29DynamicFiltersOperator3;
         AV74Departamentowwds_12_departamentodepartamento3 = AV30DepartamentoDepartamento3;
         AV75Departamentowwds_13_tfdepartamentoid = AV47TFDepartamentoId;
         AV76Departamentowwds_14_tfdepartamentoid_to = AV48TFDepartamentoId_To;
         AV77Departamentowwds_15_tfpaisid = AV49TFPaisID;
         AV78Departamentowwds_16_tfpaisid_sel = AV50TFPaisID_Sel;
         AV79Departamentowwds_17_tfdepartamentodepartamento = AV51TFDepartamentoDepartamento;
         AV80Departamentowwds_18_tfdepartamentodepartamento_sel = AV52TFDepartamentoDepartamento_Sel;
         AV81Departamentowwds_19_tfdepartamentoestado_sels = AV58TFDepartamentoEstado_Sels;
         AV82Departamentowwds_20_tfdepartamentoautenumuni = AV53TFDepartamentoAutEnuMuni;
         AV83Departamentowwds_21_tfdepartamentoautenumuni_to = AV54TFDepartamentoAutEnuMuni_To;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A907DepartamentoEstado ,
                                              AV81Departamentowwds_19_tfdepartamentoestado_sels ,
                                              AV64Departamentowwds_2_dynamicfiltersselector1 ,
                                              AV65Departamentowwds_3_dynamicfiltersoperator1 ,
                                              AV66Departamentowwds_4_departamentodepartamento1 ,
                                              AV67Departamentowwds_5_dynamicfiltersenabled2 ,
                                              AV68Departamentowwds_6_dynamicfiltersselector2 ,
                                              AV69Departamentowwds_7_dynamicfiltersoperator2 ,
                                              AV70Departamentowwds_8_departamentodepartamento2 ,
                                              AV71Departamentowwds_9_dynamicfiltersenabled3 ,
                                              AV72Departamentowwds_10_dynamicfiltersselector3 ,
                                              AV73Departamentowwds_11_dynamicfiltersoperator3 ,
                                              AV74Departamentowwds_12_departamentodepartamento3 ,
                                              AV75Departamentowwds_13_tfdepartamentoid ,
                                              AV76Departamentowwds_14_tfdepartamentoid_to ,
                                              AV78Departamentowwds_16_tfpaisid_sel ,
                                              AV77Departamentowwds_15_tfpaisid ,
                                              AV80Departamentowwds_18_tfdepartamentodepartamento_sel ,
                                              AV79Departamentowwds_17_tfdepartamentodepartamento ,
                                              AV81Departamentowwds_19_tfdepartamentoestado_sels.Count ,
                                              AV82Departamentowwds_20_tfdepartamentoautenumuni ,
                                              AV83Departamentowwds_21_tfdepartamentoautenumuni_to ,
                                              A113DepartamentoDepartamento ,
                                              A112DepartamentoId ,
                                              A116PaisID ,
                                              A185DepartamentoAutEnuMuni ,
                                              AV17OrderedBy ,
                                              AV18OrderedDsc ,
                                              AV63Departamentowwds_1_filterfulltext } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.INT, TypeConstants.SHORT,
                                              TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV66Departamentowwds_4_departamentodepartamento1 = StringUtil.PadR( StringUtil.RTrim( AV66Departamentowwds_4_departamentodepartamento1), 80, "%");
         lV66Departamentowwds_4_departamentodepartamento1 = StringUtil.PadR( StringUtil.RTrim( AV66Departamentowwds_4_departamentodepartamento1), 80, "%");
         lV70Departamentowwds_8_departamentodepartamento2 = StringUtil.PadR( StringUtil.RTrim( AV70Departamentowwds_8_departamentodepartamento2), 80, "%");
         lV70Departamentowwds_8_departamentodepartamento2 = StringUtil.PadR( StringUtil.RTrim( AV70Departamentowwds_8_departamentodepartamento2), 80, "%");
         lV74Departamentowwds_12_departamentodepartamento3 = StringUtil.PadR( StringUtil.RTrim( AV74Departamentowwds_12_departamentodepartamento3), 80, "%");
         lV74Departamentowwds_12_departamentodepartamento3 = StringUtil.PadR( StringUtil.RTrim( AV74Departamentowwds_12_departamentodepartamento3), 80, "%");
         lV77Departamentowwds_15_tfpaisid = StringUtil.PadR( StringUtil.RTrim( AV77Departamentowwds_15_tfpaisid), 2, "%");
         lV79Departamentowwds_17_tfdepartamentodepartamento = StringUtil.PadR( StringUtil.RTrim( AV79Departamentowwds_17_tfdepartamentodepartamento), 80, "%");
         /* Using cursor P00402 */
         pr_default.execute(0, new Object[] {lV66Departamentowwds_4_departamentodepartamento1, lV66Departamentowwds_4_departamentodepartamento1, lV70Departamentowwds_8_departamentodepartamento2, lV70Departamentowwds_8_departamentodepartamento2, lV74Departamentowwds_12_departamentodepartamento3, lV74Departamentowwds_12_departamentodepartamento3, AV75Departamentowwds_13_tfdepartamentoid, AV76Departamentowwds_14_tfdepartamentoid_to, lV77Departamentowwds_15_tfpaisid, AV78Departamentowwds_16_tfpaisid_sel, lV79Departamentowwds_17_tfdepartamentodepartamento, AV80Departamentowwds_18_tfdepartamentodepartamento_sel, AV82Departamentowwds_20_tfdepartamentoautenumuni, AV83Departamentowwds_21_tfdepartamentoautenumuni_to});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A185DepartamentoAutEnuMuni = P00402_A185DepartamentoAutEnuMuni[0];
            A113DepartamentoDepartamento = P00402_A113DepartamentoDepartamento[0];
            A116PaisID = P00402_A116PaisID[0];
            A112DepartamentoId = P00402_A112DepartamentoId[0];
            A907DepartamentoEstado = P00402_A907DepartamentoEstado[0];
            n907DepartamentoEstado = P00402_n907DepartamentoEstado[0];
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV63Departamentowwds_1_filterfulltext)) || ( ( StringUtil.Like( StringUtil.Str( (decimal)(A112DepartamentoId), 18, 0) , StringUtil.PadR( "%" + AV63Departamentowwds_1_filterfulltext , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A116PaisID) , StringUtil.PadR( "%" + StringUtil.Upper( AV63Departamentowwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A113DepartamentoDepartamento) , StringUtil.PadR( "%" + StringUtil.Upper( AV63Departamentowwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( context.GetMessage( "habilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV63Departamentowwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A907DepartamentoEstado, "HAB") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "deshabilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV63Departamentowwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A907DepartamentoEstado, "DES") == 0 ) ) || ( StringUtil.Like( StringUtil.Str( (decimal)(A185DepartamentoAutEnuMuni), 4, 0) , StringUtil.PadR( "%" + AV63Departamentowwds_1_filterfulltext , 254 , "%"),  ' ' ) ) ) )
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
                     if ( StringUtil.StrCmp(AV38ColumnsSelector_Column.gxTpr_Columnname, "DepartamentoId") == 0 )
                     {
                        AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV44VisibleColumnCount), 1, 1).Number = A112DepartamentoId;
                     }
                     else if ( StringUtil.StrCmp(AV38ColumnsSelector_Column.gxTpr_Columnname, "PaisID") == 0 )
                     {
                        GXt_char2 = "";
                        new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A116PaisID, out  GXt_char2) ;
                        AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV44VisibleColumnCount), 1, 1).Text = GXt_char2;
                     }
                     else if ( StringUtil.StrCmp(AV38ColumnsSelector_Column.gxTpr_Columnname, "DepartamentoDepartamento") == 0 )
                     {
                        GXt_char2 = "";
                        new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A113DepartamentoDepartamento, out  GXt_char2) ;
                        AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV44VisibleColumnCount), 1, 1).Text = GXt_char2;
                     }
                     else if ( StringUtil.StrCmp(AV38ColumnsSelector_Column.gxTpr_Columnname, "DepartamentoEstado") == 0 )
                     {
                        AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV44VisibleColumnCount), 1, 1).Text = "";
                        if ( StringUtil.StrCmp(StringUtil.Trim( A907DepartamentoEstado), context.GetMessage( "HAB", "")) == 0 )
                        {
                           AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV44VisibleColumnCount), 1, 1).Text = context.GetMessage( "Habilitado", "");
                        }
                        else if ( StringUtil.StrCmp(StringUtil.Trim( A907DepartamentoEstado), context.GetMessage( "DES", "")) == 0 )
                        {
                           AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV44VisibleColumnCount), 1, 1).Text = context.GetMessage( "Deshabilitado", "");
                        }
                     }
                     else if ( StringUtil.StrCmp(AV38ColumnsSelector_Column.gxTpr_Columnname, "DepartamentoAutEnuMuni") == 0 )
                     {
                        AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV44VisibleColumnCount), 1, 1).Number = A185DepartamentoAutEnuMuni;
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
         AV32Session.Set("WWPExportFileName", "DepartamentoWWExport.xlsx");
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
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV36ColumnsSelector,  "DepartamentoId",  "",  "Departamento",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV36ColumnsSelector,  "PaisID",  "",  "PaisId",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV36ColumnsSelector,  "DepartamentoDepartamento",  "",  "Departamento",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV36ColumnsSelector,  "DepartamentoEstado",  "",  "Estado",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV36ColumnsSelector,  "DepartamentoAutEnuMuni",  "",  "Enu Muni",  true,  "") ;
         GXt_char2 = AV40UserCustomValue;
         new GeneXus.Programs.wwpbaseobjects.loadcolumnsselectorstate(context ).execute(  "DepartamentoWWColumnsSelector", out  GXt_char2) ;
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
         if ( StringUtil.StrCmp(AV32Session.Get("DepartamentoWWGridState"), "") == 0 )
         {
            AV34GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "DepartamentoWWGridState"), null, "", "");
         }
         else
         {
            AV34GridState.FromXml(AV32Session.Get("DepartamentoWWGridState"), null, "", "");
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
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFDEPARTAMENTOID") == 0 )
            {
               AV47TFDepartamentoId = (long)(Math.Round(NumberUtil.Val( AV35GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV48TFDepartamentoId_To = (long)(Math.Round(NumberUtil.Val( AV35GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFPAISID") == 0 )
            {
               AV49TFPaisID = AV35GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFPAISID_SEL") == 0 )
            {
               AV50TFPaisID_Sel = AV35GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFDEPARTAMENTODEPARTAMENTO") == 0 )
            {
               AV51TFDepartamentoDepartamento = AV35GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFDEPARTAMENTODEPARTAMENTO_SEL") == 0 )
            {
               AV52TFDepartamentoDepartamento_Sel = AV35GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFDEPARTAMENTOESTADO_SEL") == 0 )
            {
               AV56TFDepartamentoEstado_SelsJson = AV35GridStateFilterValue.gxTpr_Value;
               AV58TFDepartamentoEstado_Sels.FromJSonString(AV56TFDepartamentoEstado_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFDEPARTAMENTOAUTENUMUNI") == 0 )
            {
               AV53TFDepartamentoAutEnuMuni = (short)(Math.Round(NumberUtil.Val( AV35GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV54TFDepartamentoAutEnuMuni_To = (short)(Math.Round(NumberUtil.Val( AV35GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
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
         AV22DepartamentoDepartamento1 = "";
         AV24DynamicFiltersSelector2 = "";
         AV26DepartamentoDepartamento2 = "";
         AV28DynamicFiltersSelector3 = "";
         AV30DepartamentoDepartamento3 = "";
         AV50TFPaisID_Sel = "";
         AV49TFPaisID = "";
         AV52TFDepartamentoDepartamento_Sel = "";
         AV51TFDepartamentoDepartamento = "";
         AV58TFDepartamentoEstado_Sels = new GxSimpleCollection<string>();
         AV57TFDepartamentoEstado_Sel = "";
         AV32Session = context.GetSession();
         AV39ColumnsSelectorXML = "";
         AV36ColumnsSelector = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector(context);
         AV38ColumnsSelector_Column = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column(context);
         AV63Departamentowwds_1_filterfulltext = "";
         AV64Departamentowwds_2_dynamicfiltersselector1 = "";
         AV66Departamentowwds_4_departamentodepartamento1 = "";
         AV68Departamentowwds_6_dynamicfiltersselector2 = "";
         AV70Departamentowwds_8_departamentodepartamento2 = "";
         AV72Departamentowwds_10_dynamicfiltersselector3 = "";
         AV74Departamentowwds_12_departamentodepartamento3 = "";
         AV77Departamentowwds_15_tfpaisid = "";
         AV78Departamentowwds_16_tfpaisid_sel = "";
         AV79Departamentowwds_17_tfdepartamentodepartamento = "";
         AV80Departamentowwds_18_tfdepartamentodepartamento_sel = "";
         AV81Departamentowwds_19_tfdepartamentoestado_sels = new GxSimpleCollection<string>();
         lV63Departamentowwds_1_filterfulltext = "";
         lV66Departamentowwds_4_departamentodepartamento1 = "";
         lV70Departamentowwds_8_departamentodepartamento2 = "";
         lV74Departamentowwds_12_departamentodepartamento3 = "";
         lV77Departamentowwds_15_tfpaisid = "";
         lV79Departamentowwds_17_tfdepartamentodepartamento = "";
         A907DepartamentoEstado = "";
         A113DepartamentoDepartamento = "";
         A116PaisID = "";
         P00402_A185DepartamentoAutEnuMuni = new short[1] ;
         P00402_A113DepartamentoDepartamento = new string[] {""} ;
         P00402_A116PaisID = new string[] {""} ;
         P00402_A112DepartamentoId = new long[1] ;
         P00402_A907DepartamentoEstado = new string[] {""} ;
         P00402_n907DepartamentoEstado = new bool[] {false} ;
         AV40UserCustomValue = "";
         GXt_char2 = "";
         AV37ColumnsSelectorAux = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector(context);
         AV35GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV56TFDepartamentoEstado_SelsJson = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.departamentowwexport__default(),
            new Object[][] {
                new Object[] {
               P00402_A185DepartamentoAutEnuMuni, P00402_A113DepartamentoDepartamento, P00402_A116PaisID, P00402_A112DepartamentoId, P00402_A907DepartamentoEstado, P00402_n907DepartamentoEstado
               }
            }
         );
         AV59Pgmname = "DepartamentoWWExport";
         /* GeneXus formulas. */
         AV59Pgmname = "DepartamentoWWExport";
      }

      private short AV21DynamicFiltersOperator1 ;
      private short AV25DynamicFiltersOperator2 ;
      private short AV29DynamicFiltersOperator3 ;
      private short AV53TFDepartamentoAutEnuMuni ;
      private short AV54TFDepartamentoAutEnuMuni_To ;
      private short GXt_int3 ;
      private short AV65Departamentowwds_3_dynamicfiltersoperator1 ;
      private short AV69Departamentowwds_7_dynamicfiltersoperator2 ;
      private short AV73Departamentowwds_11_dynamicfiltersoperator3 ;
      private short AV82Departamentowwds_20_tfdepartamentoautenumuni ;
      private short AV83Departamentowwds_21_tfdepartamentoautenumuni_to ;
      private short A185DepartamentoAutEnuMuni ;
      private short AV17OrderedBy ;
      private int AV14CellRow ;
      private int AV15FirstColumn ;
      private int AV16Random ;
      private int AV60GXV1 ;
      private int AV61GXV2 ;
      private int AV81Departamentowwds_19_tfdepartamentoestado_sels_Count ;
      private int AV84GXV3 ;
      private int AV85GXV4 ;
      private long AV47TFDepartamentoId ;
      private long AV48TFDepartamentoId_To ;
      private long AV55i ;
      private long AV44VisibleColumnCount ;
      private long AV75Departamentowwds_13_tfdepartamentoid ;
      private long AV76Departamentowwds_14_tfdepartamentoid_to ;
      private long A112DepartamentoId ;
      private string AV59Pgmname ;
      private string GXKey ;
      private string GXEncryptionTmp ;
      private string AV22DepartamentoDepartamento1 ;
      private string AV26DepartamentoDepartamento2 ;
      private string AV30DepartamentoDepartamento3 ;
      private string AV50TFPaisID_Sel ;
      private string AV49TFPaisID ;
      private string AV52TFDepartamentoDepartamento_Sel ;
      private string AV51TFDepartamentoDepartamento ;
      private string AV57TFDepartamentoEstado_Sel ;
      private string AV66Departamentowwds_4_departamentodepartamento1 ;
      private string AV70Departamentowwds_8_departamentodepartamento2 ;
      private string AV74Departamentowwds_12_departamentodepartamento3 ;
      private string AV77Departamentowwds_15_tfpaisid ;
      private string AV78Departamentowwds_16_tfpaisid_sel ;
      private string AV79Departamentowwds_17_tfdepartamentodepartamento ;
      private string AV80Departamentowwds_18_tfdepartamentodepartamento_sel ;
      private string lV66Departamentowwds_4_departamentodepartamento1 ;
      private string lV70Departamentowwds_8_departamentodepartamento2 ;
      private string lV74Departamentowwds_12_departamentodepartamento3 ;
      private string lV77Departamentowwds_15_tfpaisid ;
      private string lV79Departamentowwds_17_tfdepartamentodepartamento ;
      private string A907DepartamentoEstado ;
      private string A113DepartamentoDepartamento ;
      private string A116PaisID ;
      private string GXt_char2 ;
      private bool AV8IsAuthorized ;
      private bool GXt_boolean1 ;
      private bool returnInSub ;
      private bool AV23DynamicFiltersEnabled2 ;
      private bool AV27DynamicFiltersEnabled3 ;
      private bool AV67Departamentowwds_5_dynamicfiltersenabled2 ;
      private bool AV71Departamentowwds_9_dynamicfiltersenabled3 ;
      private bool AV18OrderedDsc ;
      private bool n907DepartamentoEstado ;
      private string AV39ColumnsSelectorXML ;
      private string AV40UserCustomValue ;
      private string AV56TFDepartamentoEstado_SelsJson ;
      private string AV12Filename ;
      private string AV13ErrorMessage ;
      private string AV19FilterFullText ;
      private string AV20DynamicFiltersSelector1 ;
      private string AV24DynamicFiltersSelector2 ;
      private string AV28DynamicFiltersSelector3 ;
      private string AV63Departamentowwds_1_filterfulltext ;
      private string AV64Departamentowwds_2_dynamicfiltersselector1 ;
      private string AV68Departamentowwds_6_dynamicfiltersselector2 ;
      private string AV72Departamentowwds_10_dynamicfiltersselector3 ;
      private string lV63Departamentowwds_1_filterfulltext ;
      private IGxSession AV32Session ;
      private ExcelDocumentI AV11ExcelDocument ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV34GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV31GridStateDynamicFilter ;
      private GxSimpleCollection<string> AV58TFDepartamentoEstado_Sels ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector AV36ColumnsSelector ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column AV38ColumnsSelector_Column ;
      private GxSimpleCollection<string> AV81Departamentowwds_19_tfdepartamentoestado_sels ;
      private IDataStoreProvider pr_default ;
      private short[] P00402_A185DepartamentoAutEnuMuni ;
      private string[] P00402_A113DepartamentoDepartamento ;
      private string[] P00402_A116PaisID ;
      private long[] P00402_A112DepartamentoId ;
      private string[] P00402_A907DepartamentoEstado ;
      private bool[] P00402_n907DepartamentoEstado ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector AV37ColumnsSelectorAux ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV35GridStateFilterValue ;
      private string aP0_Filename ;
      private string aP1_ErrorMessage ;
   }

   public class departamentowwexport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00402( IGxContext context ,
                                             string A907DepartamentoEstado ,
                                             GxSimpleCollection<string> AV81Departamentowwds_19_tfdepartamentoestado_sels ,
                                             string AV64Departamentowwds_2_dynamicfiltersselector1 ,
                                             short AV65Departamentowwds_3_dynamicfiltersoperator1 ,
                                             string AV66Departamentowwds_4_departamentodepartamento1 ,
                                             bool AV67Departamentowwds_5_dynamicfiltersenabled2 ,
                                             string AV68Departamentowwds_6_dynamicfiltersselector2 ,
                                             short AV69Departamentowwds_7_dynamicfiltersoperator2 ,
                                             string AV70Departamentowwds_8_departamentodepartamento2 ,
                                             bool AV71Departamentowwds_9_dynamicfiltersenabled3 ,
                                             string AV72Departamentowwds_10_dynamicfiltersselector3 ,
                                             short AV73Departamentowwds_11_dynamicfiltersoperator3 ,
                                             string AV74Departamentowwds_12_departamentodepartamento3 ,
                                             long AV75Departamentowwds_13_tfdepartamentoid ,
                                             long AV76Departamentowwds_14_tfdepartamentoid_to ,
                                             string AV78Departamentowwds_16_tfpaisid_sel ,
                                             string AV77Departamentowwds_15_tfpaisid ,
                                             string AV80Departamentowwds_18_tfdepartamentodepartamento_sel ,
                                             string AV79Departamentowwds_17_tfdepartamentodepartamento ,
                                             int AV81Departamentowwds_19_tfdepartamentoestado_sels_Count ,
                                             short AV82Departamentowwds_20_tfdepartamentoautenumuni ,
                                             short AV83Departamentowwds_21_tfdepartamentoautenumuni_to ,
                                             string A113DepartamentoDepartamento ,
                                             long A112DepartamentoId ,
                                             string A116PaisID ,
                                             short A185DepartamentoAutEnuMuni ,
                                             short AV17OrderedBy ,
                                             bool AV18OrderedDsc ,
                                             string AV63Departamentowwds_1_filterfulltext )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int4 = new short[14];
         Object[] GXv_Object5 = new Object[2];
         scmdbuf = "SELECT [DepartamentoAutEnuMuni], [DepartamentoDepartamento], [PaisID], [DepartamentoId], [DepartamentoEstado] FROM [Departamento]";
         if ( ( StringUtil.StrCmp(AV64Departamentowwds_2_dynamicfiltersselector1, "DEPARTAMENTODEPARTAMENTO") == 0 ) && ( AV65Departamentowwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Departamentowwds_4_departamentodepartamento1)) ) )
         {
            AddWhere(sWhereString, "(UPPER([DepartamentoDepartamento]) like UPPER(@lV66Departamentowwds_4_departamentodepartamento1))");
         }
         else
         {
            GXv_int4[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV64Departamentowwds_2_dynamicfiltersselector1, "DEPARTAMENTODEPARTAMENTO") == 0 ) && ( AV65Departamentowwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Departamentowwds_4_departamentodepartamento1)) ) )
         {
            AddWhere(sWhereString, "(UPPER([DepartamentoDepartamento]) like '%' + UPPER(@lV66Departamentowwds_4_departamentodepartamento1))");
         }
         else
         {
            GXv_int4[1] = 1;
         }
         if ( AV67Departamentowwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV68Departamentowwds_6_dynamicfiltersselector2, "DEPARTAMENTODEPARTAMENTO") == 0 ) && ( AV69Departamentowwds_7_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Departamentowwds_8_departamentodepartamento2)) ) )
         {
            AddWhere(sWhereString, "(UPPER([DepartamentoDepartamento]) like UPPER(@lV70Departamentowwds_8_departamentodepartamento2))");
         }
         else
         {
            GXv_int4[2] = 1;
         }
         if ( AV67Departamentowwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV68Departamentowwds_6_dynamicfiltersselector2, "DEPARTAMENTODEPARTAMENTO") == 0 ) && ( AV69Departamentowwds_7_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Departamentowwds_8_departamentodepartamento2)) ) )
         {
            AddWhere(sWhereString, "(UPPER([DepartamentoDepartamento]) like '%' + UPPER(@lV70Departamentowwds_8_departamentodepartamento2))");
         }
         else
         {
            GXv_int4[3] = 1;
         }
         if ( AV71Departamentowwds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV72Departamentowwds_10_dynamicfiltersselector3, "DEPARTAMENTODEPARTAMENTO") == 0 ) && ( AV73Departamentowwds_11_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Departamentowwds_12_departamentodepartamento3)) ) )
         {
            AddWhere(sWhereString, "(UPPER([DepartamentoDepartamento]) like UPPER(@lV74Departamentowwds_12_departamentodepartamento3))");
         }
         else
         {
            GXv_int4[4] = 1;
         }
         if ( AV71Departamentowwds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV72Departamentowwds_10_dynamicfiltersselector3, "DEPARTAMENTODEPARTAMENTO") == 0 ) && ( AV73Departamentowwds_11_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Departamentowwds_12_departamentodepartamento3)) ) )
         {
            AddWhere(sWhereString, "(UPPER([DepartamentoDepartamento]) like '%' + UPPER(@lV74Departamentowwds_12_departamentodepartamento3))");
         }
         else
         {
            GXv_int4[5] = 1;
         }
         if ( ! (0==AV75Departamentowwds_13_tfdepartamentoid) )
         {
            AddWhere(sWhereString, "([DepartamentoId] >= @AV75Departamentowwds_13_tfdepartamentoid)");
         }
         else
         {
            GXv_int4[6] = 1;
         }
         if ( ! (0==AV76Departamentowwds_14_tfdepartamentoid_to) )
         {
            AddWhere(sWhereString, "([DepartamentoId] <= @AV76Departamentowwds_14_tfdepartamentoid_to)");
         }
         else
         {
            GXv_int4[7] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV78Departamentowwds_16_tfpaisid_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV77Departamentowwds_15_tfpaisid)) ) )
         {
            AddWhere(sWhereString, "(UPPER([PaisID]) like UPPER(@lV77Departamentowwds_15_tfpaisid))");
         }
         else
         {
            GXv_int4[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV78Departamentowwds_16_tfpaisid_sel)) && ! ( StringUtil.StrCmp(AV78Departamentowwds_16_tfpaisid_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([PaisID] = @AV78Departamentowwds_16_tfpaisid_sel)");
         }
         else
         {
            GXv_int4[9] = 1;
         }
         if ( StringUtil.StrCmp(AV78Departamentowwds_16_tfpaisid_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([PaisID] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV80Departamentowwds_18_tfdepartamentodepartamento_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV79Departamentowwds_17_tfdepartamentodepartamento)) ) )
         {
            AddWhere(sWhereString, "(UPPER([DepartamentoDepartamento]) like UPPER(@lV79Departamentowwds_17_tfdepartamentodepartamento))");
         }
         else
         {
            GXv_int4[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV80Departamentowwds_18_tfdepartamentodepartamento_sel)) && ! ( StringUtil.StrCmp(AV80Departamentowwds_18_tfdepartamentodepartamento_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([DepartamentoDepartamento] = @AV80Departamentowwds_18_tfdepartamentodepartamento_sel)");
         }
         else
         {
            GXv_int4[11] = 1;
         }
         if ( StringUtil.StrCmp(AV80Departamentowwds_18_tfdepartamentodepartamento_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([DepartamentoDepartamento] = ''))");
         }
         if ( AV81Departamentowwds_19_tfdepartamentoestado_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV81Departamentowwds_19_tfdepartamentoestado_sels, "[DepartamentoEstado] IN (", ")")+")");
         }
         if ( ! (0==AV82Departamentowwds_20_tfdepartamentoautenumuni) )
         {
            AddWhere(sWhereString, "([DepartamentoAutEnuMuni] >= @AV82Departamentowwds_20_tfdepartamentoautenumuni)");
         }
         else
         {
            GXv_int4[12] = 1;
         }
         if ( ! (0==AV83Departamentowwds_21_tfdepartamentoautenumuni_to) )
         {
            AddWhere(sWhereString, "([DepartamentoAutEnuMuni] <= @AV83Departamentowwds_21_tfdepartamentoautenumuni_to)");
         }
         else
         {
            GXv_int4[13] = 1;
         }
         scmdbuf += sWhereString;
         if ( ( AV17OrderedBy == 1 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY [DepartamentoDepartamento]";
         }
         else if ( ( AV17OrderedBy == 1 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [DepartamentoDepartamento] DESC";
         }
         else if ( ( AV17OrderedBy == 2 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY [DepartamentoId]";
         }
         else if ( ( AV17OrderedBy == 2 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [DepartamentoId] DESC";
         }
         else if ( ( AV17OrderedBy == 3 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY [PaisID]";
         }
         else if ( ( AV17OrderedBy == 3 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [PaisID] DESC";
         }
         else if ( ( AV17OrderedBy == 4 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY [DepartamentoEstado]";
         }
         else if ( ( AV17OrderedBy == 4 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [DepartamentoEstado] DESC";
         }
         else if ( ( AV17OrderedBy == 5 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY [DepartamentoAutEnuMuni]";
         }
         else if ( ( AV17OrderedBy == 5 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [DepartamentoAutEnuMuni] DESC";
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
                     return conditional_P00402(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (bool)dynConstraints[5] , (string)dynConstraints[6] , (short)dynConstraints[7] , (string)dynConstraints[8] , (bool)dynConstraints[9] , (string)dynConstraints[10] , (short)dynConstraints[11] , (string)dynConstraints[12] , (long)dynConstraints[13] , (long)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (int)dynConstraints[19] , (short)dynConstraints[20] , (short)dynConstraints[21] , (string)dynConstraints[22] , (long)dynConstraints[23] , (string)dynConstraints[24] , (short)dynConstraints[25] , (short)dynConstraints[26] , (bool)dynConstraints[27] , (string)dynConstraints[28] );
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
          Object[] prmP00402;
          prmP00402 = new Object[] {
          new ParDef("@lV66Departamentowwds_4_departamentodepartamento1",GXType.Char,80,0) ,
          new ParDef("@lV66Departamentowwds_4_departamentodepartamento1",GXType.Char,80,0) ,
          new ParDef("@lV70Departamentowwds_8_departamentodepartamento2",GXType.Char,80,0) ,
          new ParDef("@lV70Departamentowwds_8_departamentodepartamento2",GXType.Char,80,0) ,
          new ParDef("@lV74Departamentowwds_12_departamentodepartamento3",GXType.Char,80,0) ,
          new ParDef("@lV74Departamentowwds_12_departamentodepartamento3",GXType.Char,80,0) ,
          new ParDef("@AV75Departamentowwds_13_tfdepartamentoid",GXType.Decimal,18,0) ,
          new ParDef("@AV76Departamentowwds_14_tfdepartamentoid_to",GXType.Decimal,18,0) ,
          new ParDef("@lV77Departamentowwds_15_tfpaisid",GXType.Char,2,0) ,
          new ParDef("@AV78Departamentowwds_16_tfpaisid_sel",GXType.NChar,2,0) ,
          new ParDef("@lV79Departamentowwds_17_tfdepartamentodepartamento",GXType.Char,80,0) ,
          new ParDef("@AV80Departamentowwds_18_tfdepartamentodepartamento_sel",GXType.NChar,80,0) ,
          new ParDef("@AV82Departamentowwds_20_tfdepartamentoautenumuni",GXType.Int16,4,0) ,
          new ParDef("@AV83Departamentowwds_21_tfdepartamentoautenumuni_to",GXType.Int16,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00402", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00402,100, GxCacheFrequency.OFF ,true,false )
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
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 80);
                ((string[]) buf[2])[0] = rslt.getString(3, 2);
                ((long[]) buf[3])[0] = rslt.getLong(4);
                ((string[]) buf[4])[0] = rslt.getString(5, 3);
                ((bool[]) buf[5])[0] = rslt.wasNull(5);
                return;
       }
    }

 }

}

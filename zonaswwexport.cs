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
   public class zonaswwexport : GXProcedure
   {
      public zonaswwexport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public zonaswwexport( IGxContext context )
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
         new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWZonas", out  GXt_boolean1) ;
         AV8IsAuthorized = GXt_boolean1;
         if ( ! AV8IsAuthorized )
         {
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "wwpbaseobjects.notauthorized.aspx"+GXUtil.UrlEncode(StringUtil.RTrim(AV56Pgmname));
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
         AV12Filename = GXt_char2 + "ZonasWWExport-" + StringUtil.Trim( StringUtil.Str( (decimal)(AV16Random), 8, 0)) + ".xlsx";
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
            if ( StringUtil.StrCmp(AV20DynamicFiltersSelector1, "ZONASNOMBRE") == 0 )
            {
               AV21DynamicFiltersOperator1 = AV31GridStateDynamicFilter.gxTpr_Operator;
               AV22ZonasNombre1 = AV31GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV22ZonasNombre1)) )
               {
                  AV14CellRow = (int)(AV14CellRow+1);
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Bold = 1;
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Color = 3;
                  if ( AV21DynamicFiltersOperator1 == 0 )
                  {
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", context.GetMessage( "Zona", ""), context.GetMessage( "WWP_FilterLike", ""), "", "", "", "", "", "", "");
                  }
                  else if ( AV21DynamicFiltersOperator1 == 1 )
                  {
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", context.GetMessage( "Zona", ""), context.GetMessage( "WWP_FilterContains", ""), "", "", "", "", "", "", "");
                  }
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Italic = 1;
                  GXt_char2 = "";
                  new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV22ZonasNombre1, out  GXt_char2) ;
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
               }
            }
            if ( AV34GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV23DynamicFiltersEnabled2 = true;
               AV31GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV34GridState.gxTpr_Dynamicfilters.Item(2));
               AV24DynamicFiltersSelector2 = AV31GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV24DynamicFiltersSelector2, "ZONASNOMBRE") == 0 )
               {
                  AV25DynamicFiltersOperator2 = AV31GridStateDynamicFilter.gxTpr_Operator;
                  AV26ZonasNombre2 = AV31GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV26ZonasNombre2)) )
                  {
                     AV14CellRow = (int)(AV14CellRow+1);
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Bold = 1;
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Color = 3;
                     if ( AV25DynamicFiltersOperator2 == 0 )
                     {
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", context.GetMessage( "Zona", ""), context.GetMessage( "WWP_FilterLike", ""), "", "", "", "", "", "", "");
                     }
                     else if ( AV25DynamicFiltersOperator2 == 1 )
                     {
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", context.GetMessage( "Zona", ""), context.GetMessage( "WWP_FilterContains", ""), "", "", "", "", "", "", "");
                     }
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Italic = 1;
                     GXt_char2 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV26ZonasNombre2, out  GXt_char2) ;
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
                  }
               }
               if ( AV34GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV27DynamicFiltersEnabled3 = true;
                  AV31GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV34GridState.gxTpr_Dynamicfilters.Item(3));
                  AV28DynamicFiltersSelector3 = AV31GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV28DynamicFiltersSelector3, "ZONASNOMBRE") == 0 )
                  {
                     AV29DynamicFiltersOperator3 = AV31GridStateDynamicFilter.gxTpr_Operator;
                     AV30ZonasNombre3 = AV31GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV30ZonasNombre3)) )
                     {
                        AV14CellRow = (int)(AV14CellRow+1);
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Bold = 1;
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Color = 3;
                        if ( AV29DynamicFiltersOperator3 == 0 )
                        {
                           AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", context.GetMessage( "Zona", ""), context.GetMessage( "WWP_FilterLike", ""), "", "", "", "", "", "", "");
                        }
                        else if ( AV29DynamicFiltersOperator3 == 1 )
                        {
                           AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", context.GetMessage( "Zona", ""), context.GetMessage( "WWP_FilterContains", ""), "", "", "", "", "", "", "");
                        }
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Italic = 1;
                        GXt_char2 = "";
                        new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV30ZonasNombre3, out  GXt_char2) ;
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
                     }
                  }
               }
            }
         }
         if ( ! ( (0==AV47TFZonasID) && (0==AV48TFZonasID_To) ) )
         {
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Nro.", "")) ;
            AV14CellRow = GXt_int3;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Number = AV47TFZonasID;
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  false, ref  GXt_int3,  (short)(AV15FirstColumn+2),  context.GetMessage( "WWP_TSTo", "")) ;
            AV14CellRow = GXt_int3;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+3, 1, 1).Number = AV48TFZonasID_To;
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV50TFZonasNombre_Sel)) ) )
         {
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Zona", "")) ;
            AV14CellRow = GXt_int3;
            GXt_char2 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV50TFZonasNombre_Sel)) ? context.GetMessage( "WWP_TitleFilter_EmptyOption", "") : AV50TFZonasNombre_Sel), out  GXt_char2) ;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV49TFZonasNombre)) ) )
            {
               GXt_int3 = (short)(AV14CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Zona", "")) ;
               AV14CellRow = GXt_int3;
               GXt_char2 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV49TFZonasNombre, out  GXt_char2) ;
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
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV54TFDepartamentoMunicipioNombre_Sel)) ) )
         {
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Municipio", "")) ;
            AV14CellRow = GXt_int3;
            GXt_char2 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV54TFDepartamentoMunicipioNombre_Sel)) ? context.GetMessage( "WWP_TitleFilter_EmptyOption", "") : AV54TFDepartamentoMunicipioNombre_Sel), out  GXt_char2) ;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV53TFDepartamentoMunicipioNombre)) ) )
            {
               GXt_int3 = (short)(AV14CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Municipio", "")) ;
               AV14CellRow = GXt_int3;
               GXt_char2 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV53TFDepartamentoMunicipioNombre, out  GXt_char2) ;
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
         if ( StringUtil.StrCmp(AV32Session.Get("ZonasWWColumnsSelector"), "") != 0 )
         {
            AV39ColumnsSelectorXML = AV32Session.Get("ZonasWWColumnsSelector");
            AV36ColumnsSelector.FromXml(AV39ColumnsSelectorXML, null, "", "");
         }
         else
         {
            /* Execute user subroutine: 'INITIALIZECOLUMNSSELECTOR' */
            S151 ();
            if (returnInSub) return;
         }
         AV36ColumnsSelector.gxTpr_Columns.Sort("Order");
         AV57GXV1 = 1;
         while ( AV57GXV1 <= AV36ColumnsSelector.gxTpr_Columns.Count )
         {
            AV38ColumnsSelector_Column = ((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV36ColumnsSelector.gxTpr_Columns.Item(AV57GXV1));
            if ( AV38ColumnsSelector_Column.gxTpr_Isvisible )
            {
               AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV44VisibleColumnCount), 1, 1).Text = context.GetMessage( (String.IsNullOrEmpty(StringUtil.RTrim( AV38ColumnsSelector_Column.gxTpr_Displayname)) ? AV38ColumnsSelector_Column.gxTpr_Columnname : AV38ColumnsSelector_Column.gxTpr_Displayname), "");
               AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV44VisibleColumnCount), 1, 1).Bold = 1;
               AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV44VisibleColumnCount), 1, 1).Color = 11;
               AV44VisibleColumnCount = (long)(AV44VisibleColumnCount+1);
            }
            AV57GXV1 = (int)(AV57GXV1+1);
         }
      }

      protected void S161( )
      {
         /* 'WRITEDATA' Routine */
         returnInSub = false;
         AV59Zonaswwds_1_filterfulltext = AV19FilterFullText;
         AV60Zonaswwds_2_dynamicfiltersselector1 = AV20DynamicFiltersSelector1;
         AV61Zonaswwds_3_dynamicfiltersoperator1 = AV21DynamicFiltersOperator1;
         AV62Zonaswwds_4_zonasnombre1 = AV22ZonasNombre1;
         AV63Zonaswwds_5_dynamicfiltersenabled2 = AV23DynamicFiltersEnabled2;
         AV64Zonaswwds_6_dynamicfiltersselector2 = AV24DynamicFiltersSelector2;
         AV65Zonaswwds_7_dynamicfiltersoperator2 = AV25DynamicFiltersOperator2;
         AV66Zonaswwds_8_zonasnombre2 = AV26ZonasNombre2;
         AV67Zonaswwds_9_dynamicfiltersenabled3 = AV27DynamicFiltersEnabled3;
         AV68Zonaswwds_10_dynamicfiltersselector3 = AV28DynamicFiltersSelector3;
         AV69Zonaswwds_11_dynamicfiltersoperator3 = AV29DynamicFiltersOperator3;
         AV70Zonaswwds_12_zonasnombre3 = AV30ZonasNombre3;
         AV71Zonaswwds_13_tfzonasid = AV47TFZonasID;
         AV72Zonaswwds_14_tfzonasid_to = AV48TFZonasID_To;
         AV73Zonaswwds_15_tfzonasnombre = AV49TFZonasNombre;
         AV74Zonaswwds_16_tfzonasnombre_sel = AV50TFZonasNombre_Sel;
         AV75Zonaswwds_17_tfdepartamentodepartamento = AV51TFDepartamentoDepartamento;
         AV76Zonaswwds_18_tfdepartamentodepartamento_sel = AV52TFDepartamentoDepartamento_Sel;
         AV77Zonaswwds_19_tfdepartamentomunicipionombre = AV53TFDepartamentoMunicipioNombre;
         AV78Zonaswwds_20_tfdepartamentomunicipionombre_sel = AV54TFDepartamentoMunicipioNombre_Sel;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV59Zonaswwds_1_filterfulltext ,
                                              AV60Zonaswwds_2_dynamicfiltersselector1 ,
                                              AV61Zonaswwds_3_dynamicfiltersoperator1 ,
                                              AV62Zonaswwds_4_zonasnombre1 ,
                                              AV63Zonaswwds_5_dynamicfiltersenabled2 ,
                                              AV64Zonaswwds_6_dynamicfiltersselector2 ,
                                              AV65Zonaswwds_7_dynamicfiltersoperator2 ,
                                              AV66Zonaswwds_8_zonasnombre2 ,
                                              AV67Zonaswwds_9_dynamicfiltersenabled3 ,
                                              AV68Zonaswwds_10_dynamicfiltersselector3 ,
                                              AV69Zonaswwds_11_dynamicfiltersoperator3 ,
                                              AV70Zonaswwds_12_zonasnombre3 ,
                                              AV71Zonaswwds_13_tfzonasid ,
                                              AV72Zonaswwds_14_tfzonasid_to ,
                                              AV74Zonaswwds_16_tfzonasnombre_sel ,
                                              AV73Zonaswwds_15_tfzonasnombre ,
                                              AV76Zonaswwds_18_tfdepartamentodepartamento_sel ,
                                              AV75Zonaswwds_17_tfdepartamentodepartamento ,
                                              AV78Zonaswwds_20_tfdepartamentomunicipionombre_sel ,
                                              AV77Zonaswwds_19_tfdepartamentomunicipionombre ,
                                              A110ZonasID ,
                                              A111ZonasNombre ,
                                              A113DepartamentoDepartamento ,
                                              A115DepartamentoMunicipioNombre ,
                                              AV17OrderedBy ,
                                              AV18OrderedDsc } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV59Zonaswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV59Zonaswwds_1_filterfulltext), "%", "");
         lV59Zonaswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV59Zonaswwds_1_filterfulltext), "%", "");
         lV59Zonaswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV59Zonaswwds_1_filterfulltext), "%", "");
         lV59Zonaswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV59Zonaswwds_1_filterfulltext), "%", "");
         lV62Zonaswwds_4_zonasnombre1 = StringUtil.PadR( StringUtil.RTrim( AV62Zonaswwds_4_zonasnombre1), 120, "%");
         lV62Zonaswwds_4_zonasnombre1 = StringUtil.PadR( StringUtil.RTrim( AV62Zonaswwds_4_zonasnombre1), 120, "%");
         lV66Zonaswwds_8_zonasnombre2 = StringUtil.PadR( StringUtil.RTrim( AV66Zonaswwds_8_zonasnombre2), 120, "%");
         lV66Zonaswwds_8_zonasnombre2 = StringUtil.PadR( StringUtil.RTrim( AV66Zonaswwds_8_zonasnombre2), 120, "%");
         lV70Zonaswwds_12_zonasnombre3 = StringUtil.PadR( StringUtil.RTrim( AV70Zonaswwds_12_zonasnombre3), 120, "%");
         lV70Zonaswwds_12_zonasnombre3 = StringUtil.PadR( StringUtil.RTrim( AV70Zonaswwds_12_zonasnombre3), 120, "%");
         lV73Zonaswwds_15_tfzonasnombre = StringUtil.PadR( StringUtil.RTrim( AV73Zonaswwds_15_tfzonasnombre), 120, "%");
         lV75Zonaswwds_17_tfdepartamentodepartamento = StringUtil.PadR( StringUtil.RTrim( AV75Zonaswwds_17_tfdepartamentodepartamento), 80, "%");
         lV77Zonaswwds_19_tfdepartamentomunicipionombre = StringUtil.PadR( StringUtil.RTrim( AV77Zonaswwds_19_tfdepartamentomunicipionombre), 120, "%");
         /* Using cursor P007J2 */
         pr_default.execute(0, new Object[] {lV59Zonaswwds_1_filterfulltext, lV59Zonaswwds_1_filterfulltext, lV59Zonaswwds_1_filterfulltext, lV59Zonaswwds_1_filterfulltext, lV62Zonaswwds_4_zonasnombre1, lV62Zonaswwds_4_zonasnombre1, lV66Zonaswwds_8_zonasnombre2, lV66Zonaswwds_8_zonasnombre2, lV70Zonaswwds_12_zonasnombre3, lV70Zonaswwds_12_zonasnombre3, AV71Zonaswwds_13_tfzonasid, AV72Zonaswwds_14_tfzonasid_to, lV73Zonaswwds_15_tfzonasnombre, AV74Zonaswwds_16_tfzonasnombre_sel, lV75Zonaswwds_17_tfdepartamentodepartamento, AV76Zonaswwds_18_tfdepartamentodepartamento_sel, lV77Zonaswwds_19_tfdepartamentomunicipionombre, AV78Zonaswwds_20_tfdepartamentomunicipionombre_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A112DepartamentoId = P007J2_A112DepartamentoId[0];
            A114DepartamentoMunicipioId = P007J2_A114DepartamentoMunicipioId[0];
            A115DepartamentoMunicipioNombre = P007J2_A115DepartamentoMunicipioNombre[0];
            A113DepartamentoDepartamento = P007J2_A113DepartamentoDepartamento[0];
            A111ZonasNombre = P007J2_A111ZonasNombre[0];
            A110ZonasID = P007J2_A110ZonasID[0];
            A113DepartamentoDepartamento = P007J2_A113DepartamentoDepartamento[0];
            A115DepartamentoMunicipioNombre = P007J2_A115DepartamentoMunicipioNombre[0];
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
            AV79GXV2 = 1;
            while ( AV79GXV2 <= AV36ColumnsSelector.gxTpr_Columns.Count )
            {
               AV38ColumnsSelector_Column = ((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV36ColumnsSelector.gxTpr_Columns.Item(AV79GXV2));
               if ( AV38ColumnsSelector_Column.gxTpr_Isvisible )
               {
                  if ( StringUtil.StrCmp(AV38ColumnsSelector_Column.gxTpr_Columnname, "ZonasID") == 0 )
                  {
                     AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV44VisibleColumnCount), 1, 1).Number = A110ZonasID;
                  }
                  else if ( StringUtil.StrCmp(AV38ColumnsSelector_Column.gxTpr_Columnname, "ZonasNombre") == 0 )
                  {
                     GXt_char2 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A111ZonasNombre, out  GXt_char2) ;
                     AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV44VisibleColumnCount), 1, 1).Text = GXt_char2;
                  }
                  else if ( StringUtil.StrCmp(AV38ColumnsSelector_Column.gxTpr_Columnname, "DepartamentoDepartamento") == 0 )
                  {
                     GXt_char2 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A113DepartamentoDepartamento, out  GXt_char2) ;
                     AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV44VisibleColumnCount), 1, 1).Text = GXt_char2;
                  }
                  else if ( StringUtil.StrCmp(AV38ColumnsSelector_Column.gxTpr_Columnname, "DepartamentoMunicipioNombre") == 0 )
                  {
                     GXt_char2 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A115DepartamentoMunicipioNombre, out  GXt_char2) ;
                     AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV44VisibleColumnCount), 1, 1).Text = GXt_char2;
                  }
                  AV44VisibleColumnCount = (long)(AV44VisibleColumnCount+1);
               }
               AV79GXV2 = (int)(AV79GXV2+1);
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
         AV32Session.Set("WWPExportFileName", "ZonasWWExport.xlsx");
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
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV36ColumnsSelector,  "ZonasID",  "",  "Nro.",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV36ColumnsSelector,  "ZonasNombre",  "",  "Zona",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV36ColumnsSelector,  "DepartamentoDepartamento",  "",  "Departamento",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV36ColumnsSelector,  "DepartamentoMunicipioNombre",  "",  "Municipio",  true,  "") ;
         GXt_char2 = AV40UserCustomValue;
         new GeneXus.Programs.wwpbaseobjects.loadcolumnsselectorstate(context ).execute(  "ZonasWWColumnsSelector", out  GXt_char2) ;
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
         if ( StringUtil.StrCmp(AV32Session.Get("ZonasWWGridState"), "") == 0 )
         {
            AV34GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "ZonasWWGridState"), null, "", "");
         }
         else
         {
            AV34GridState.FromXml(AV32Session.Get("ZonasWWGridState"), null, "", "");
         }
         AV17OrderedBy = AV34GridState.gxTpr_Orderedby;
         AV18OrderedDsc = AV34GridState.gxTpr_Ordereddsc;
         AV80GXV3 = 1;
         while ( AV80GXV3 <= AV34GridState.gxTpr_Filtervalues.Count )
         {
            AV35GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV34GridState.gxTpr_Filtervalues.Item(AV80GXV3));
            if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV19FilterFullText = AV35GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFZONASID") == 0 )
            {
               AV47TFZonasID = (long)(Math.Round(NumberUtil.Val( AV35GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV48TFZonasID_To = (long)(Math.Round(NumberUtil.Val( AV35GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFZONASNOMBRE") == 0 )
            {
               AV49TFZonasNombre = AV35GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFZONASNOMBRE_SEL") == 0 )
            {
               AV50TFZonasNombre_Sel = AV35GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFDEPARTAMENTODEPARTAMENTO") == 0 )
            {
               AV51TFDepartamentoDepartamento = AV35GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFDEPARTAMENTODEPARTAMENTO_SEL") == 0 )
            {
               AV52TFDepartamentoDepartamento_Sel = AV35GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFDEPARTAMENTOMUNICIPIONOMBRE") == 0 )
            {
               AV53TFDepartamentoMunicipioNombre = AV35GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFDEPARTAMENTOMUNICIPIONOMBRE_SEL") == 0 )
            {
               AV54TFDepartamentoMunicipioNombre_Sel = AV35GridStateFilterValue.gxTpr_Value;
            }
            AV80GXV3 = (int)(AV80GXV3+1);
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
         AV56Pgmname = "";
         GXKey = "";
         GXEncryptionTmp = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV11ExcelDocument = new ExcelDocumentI();
         AV19FilterFullText = "";
         AV34GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV31GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV20DynamicFiltersSelector1 = "";
         AV22ZonasNombre1 = "";
         AV24DynamicFiltersSelector2 = "";
         AV26ZonasNombre2 = "";
         AV28DynamicFiltersSelector3 = "";
         AV30ZonasNombre3 = "";
         AV50TFZonasNombre_Sel = "";
         AV49TFZonasNombre = "";
         AV52TFDepartamentoDepartamento_Sel = "";
         AV51TFDepartamentoDepartamento = "";
         AV54TFDepartamentoMunicipioNombre_Sel = "";
         AV53TFDepartamentoMunicipioNombre = "";
         AV32Session = context.GetSession();
         AV39ColumnsSelectorXML = "";
         AV36ColumnsSelector = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector(context);
         AV38ColumnsSelector_Column = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column(context);
         AV59Zonaswwds_1_filterfulltext = "";
         AV60Zonaswwds_2_dynamicfiltersselector1 = "";
         AV62Zonaswwds_4_zonasnombre1 = "";
         AV64Zonaswwds_6_dynamicfiltersselector2 = "";
         AV66Zonaswwds_8_zonasnombre2 = "";
         AV68Zonaswwds_10_dynamicfiltersselector3 = "";
         AV70Zonaswwds_12_zonasnombre3 = "";
         AV73Zonaswwds_15_tfzonasnombre = "";
         AV74Zonaswwds_16_tfzonasnombre_sel = "";
         AV75Zonaswwds_17_tfdepartamentodepartamento = "";
         AV76Zonaswwds_18_tfdepartamentodepartamento_sel = "";
         AV77Zonaswwds_19_tfdepartamentomunicipionombre = "";
         AV78Zonaswwds_20_tfdepartamentomunicipionombre_sel = "";
         lV59Zonaswwds_1_filterfulltext = "";
         lV62Zonaswwds_4_zonasnombre1 = "";
         lV66Zonaswwds_8_zonasnombre2 = "";
         lV70Zonaswwds_12_zonasnombre3 = "";
         lV73Zonaswwds_15_tfzonasnombre = "";
         lV75Zonaswwds_17_tfdepartamentodepartamento = "";
         lV77Zonaswwds_19_tfdepartamentomunicipionombre = "";
         A111ZonasNombre = "";
         A113DepartamentoDepartamento = "";
         A115DepartamentoMunicipioNombre = "";
         P007J2_A112DepartamentoId = new long[1] ;
         P007J2_A114DepartamentoMunicipioId = new long[1] ;
         P007J2_A115DepartamentoMunicipioNombre = new string[] {""} ;
         P007J2_A113DepartamentoDepartamento = new string[] {""} ;
         P007J2_A111ZonasNombre = new string[] {""} ;
         P007J2_A110ZonasID = new long[1] ;
         AV40UserCustomValue = "";
         GXt_char2 = "";
         AV37ColumnsSelectorAux = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector(context);
         AV35GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.zonaswwexport__default(),
            new Object[][] {
                new Object[] {
               P007J2_A112DepartamentoId, P007J2_A114DepartamentoMunicipioId, P007J2_A115DepartamentoMunicipioNombre, P007J2_A113DepartamentoDepartamento, P007J2_A111ZonasNombre, P007J2_A110ZonasID
               }
            }
         );
         AV56Pgmname = "ZonasWWExport";
         /* GeneXus formulas. */
         AV56Pgmname = "ZonasWWExport";
      }

      private short AV21DynamicFiltersOperator1 ;
      private short AV25DynamicFiltersOperator2 ;
      private short AV29DynamicFiltersOperator3 ;
      private short GXt_int3 ;
      private short AV61Zonaswwds_3_dynamicfiltersoperator1 ;
      private short AV65Zonaswwds_7_dynamicfiltersoperator2 ;
      private short AV69Zonaswwds_11_dynamicfiltersoperator3 ;
      private short AV17OrderedBy ;
      private int AV14CellRow ;
      private int AV15FirstColumn ;
      private int AV16Random ;
      private int AV57GXV1 ;
      private int AV79GXV2 ;
      private int AV80GXV3 ;
      private long AV47TFZonasID ;
      private long AV48TFZonasID_To ;
      private long AV44VisibleColumnCount ;
      private long AV71Zonaswwds_13_tfzonasid ;
      private long AV72Zonaswwds_14_tfzonasid_to ;
      private long A110ZonasID ;
      private long A112DepartamentoId ;
      private long A114DepartamentoMunicipioId ;
      private string AV56Pgmname ;
      private string GXKey ;
      private string GXEncryptionTmp ;
      private string AV22ZonasNombre1 ;
      private string AV26ZonasNombre2 ;
      private string AV30ZonasNombre3 ;
      private string AV50TFZonasNombre_Sel ;
      private string AV49TFZonasNombre ;
      private string AV52TFDepartamentoDepartamento_Sel ;
      private string AV51TFDepartamentoDepartamento ;
      private string AV54TFDepartamentoMunicipioNombre_Sel ;
      private string AV53TFDepartamentoMunicipioNombre ;
      private string AV62Zonaswwds_4_zonasnombre1 ;
      private string AV66Zonaswwds_8_zonasnombre2 ;
      private string AV70Zonaswwds_12_zonasnombre3 ;
      private string AV73Zonaswwds_15_tfzonasnombre ;
      private string AV74Zonaswwds_16_tfzonasnombre_sel ;
      private string AV75Zonaswwds_17_tfdepartamentodepartamento ;
      private string AV76Zonaswwds_18_tfdepartamentodepartamento_sel ;
      private string AV77Zonaswwds_19_tfdepartamentomunicipionombre ;
      private string AV78Zonaswwds_20_tfdepartamentomunicipionombre_sel ;
      private string lV62Zonaswwds_4_zonasnombre1 ;
      private string lV66Zonaswwds_8_zonasnombre2 ;
      private string lV70Zonaswwds_12_zonasnombre3 ;
      private string lV73Zonaswwds_15_tfzonasnombre ;
      private string lV75Zonaswwds_17_tfdepartamentodepartamento ;
      private string lV77Zonaswwds_19_tfdepartamentomunicipionombre ;
      private string A111ZonasNombre ;
      private string A113DepartamentoDepartamento ;
      private string A115DepartamentoMunicipioNombre ;
      private string GXt_char2 ;
      private bool AV8IsAuthorized ;
      private bool GXt_boolean1 ;
      private bool returnInSub ;
      private bool AV23DynamicFiltersEnabled2 ;
      private bool AV27DynamicFiltersEnabled3 ;
      private bool AV63Zonaswwds_5_dynamicfiltersenabled2 ;
      private bool AV67Zonaswwds_9_dynamicfiltersenabled3 ;
      private bool AV18OrderedDsc ;
      private string AV39ColumnsSelectorXML ;
      private string AV40UserCustomValue ;
      private string AV12Filename ;
      private string AV13ErrorMessage ;
      private string AV19FilterFullText ;
      private string AV20DynamicFiltersSelector1 ;
      private string AV24DynamicFiltersSelector2 ;
      private string AV28DynamicFiltersSelector3 ;
      private string AV59Zonaswwds_1_filterfulltext ;
      private string AV60Zonaswwds_2_dynamicfiltersselector1 ;
      private string AV64Zonaswwds_6_dynamicfiltersselector2 ;
      private string AV68Zonaswwds_10_dynamicfiltersselector3 ;
      private string lV59Zonaswwds_1_filterfulltext ;
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
      private long[] P007J2_A112DepartamentoId ;
      private long[] P007J2_A114DepartamentoMunicipioId ;
      private string[] P007J2_A115DepartamentoMunicipioNombre ;
      private string[] P007J2_A113DepartamentoDepartamento ;
      private string[] P007J2_A111ZonasNombre ;
      private long[] P007J2_A110ZonasID ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector AV37ColumnsSelectorAux ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV35GridStateFilterValue ;
      private string aP0_Filename ;
      private string aP1_ErrorMessage ;
   }

   public class zonaswwexport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P007J2( IGxContext context ,
                                             string AV59Zonaswwds_1_filterfulltext ,
                                             string AV60Zonaswwds_2_dynamicfiltersselector1 ,
                                             short AV61Zonaswwds_3_dynamicfiltersoperator1 ,
                                             string AV62Zonaswwds_4_zonasnombre1 ,
                                             bool AV63Zonaswwds_5_dynamicfiltersenabled2 ,
                                             string AV64Zonaswwds_6_dynamicfiltersselector2 ,
                                             short AV65Zonaswwds_7_dynamicfiltersoperator2 ,
                                             string AV66Zonaswwds_8_zonasnombre2 ,
                                             bool AV67Zonaswwds_9_dynamicfiltersenabled3 ,
                                             string AV68Zonaswwds_10_dynamicfiltersselector3 ,
                                             short AV69Zonaswwds_11_dynamicfiltersoperator3 ,
                                             string AV70Zonaswwds_12_zonasnombre3 ,
                                             long AV71Zonaswwds_13_tfzonasid ,
                                             long AV72Zonaswwds_14_tfzonasid_to ,
                                             string AV74Zonaswwds_16_tfzonasnombre_sel ,
                                             string AV73Zonaswwds_15_tfzonasnombre ,
                                             string AV76Zonaswwds_18_tfdepartamentodepartamento_sel ,
                                             string AV75Zonaswwds_17_tfdepartamentodepartamento ,
                                             string AV78Zonaswwds_20_tfdepartamentomunicipionombre_sel ,
                                             string AV77Zonaswwds_19_tfdepartamentomunicipionombre ,
                                             long A110ZonasID ,
                                             string A111ZonasNombre ,
                                             string A113DepartamentoDepartamento ,
                                             string A115DepartamentoMunicipioNombre ,
                                             short AV17OrderedBy ,
                                             bool AV18OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int4 = new short[18];
         Object[] GXv_Object5 = new Object[2];
         scmdbuf = "SELECT T1.[DepartamentoId], T1.[DepartamentoMunicipioId], T3.[DepartamentoMunicipioNombre], T2.[DepartamentoDepartamento], T1.[ZonasNombre], T1.[ZonasID] FROM (([Zonas] T1 INNER JOIN [Departamento] T2 ON T2.[DepartamentoId] = T1.[DepartamentoId]) INNER JOIN [DepartamentoMunicipio] T3 ON T3.[DepartamentoId] = T1.[DepartamentoId] AND T3.[DepartamentoMunicipioId] = T1.[DepartamentoMunicipioId])";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59Zonaswwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( CONVERT( char(18), CAST(T1.[ZonasID] AS decimal(18,0))) like '%' + @lV59Zonaswwds_1_filterfulltext) or ( UPPER(T1.[ZonasNombre]) like '%' + UPPER(@lV59Zonaswwds_1_filterfulltext)) or ( UPPER(T2.[DepartamentoDepartamento]) like '%' + UPPER(@lV59Zonaswwds_1_filterfulltext)) or ( UPPER(T3.[DepartamentoMunicipioNombre]) like '%' + UPPER(@lV59Zonaswwds_1_filterfulltext)))");
         }
         else
         {
            GXv_int4[0] = 1;
            GXv_int4[1] = 1;
            GXv_int4[2] = 1;
            GXv_int4[3] = 1;
         }
         if ( ( StringUtil.StrCmp(AV60Zonaswwds_2_dynamicfiltersselector1, "ZONASNOMBRE") == 0 ) && ( AV61Zonaswwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Zonaswwds_4_zonasnombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[ZonasNombre]) like UPPER(@lV62Zonaswwds_4_zonasnombre1))");
         }
         else
         {
            GXv_int4[4] = 1;
         }
         if ( ( StringUtil.StrCmp(AV60Zonaswwds_2_dynamicfiltersselector1, "ZONASNOMBRE") == 0 ) && ( AV61Zonaswwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Zonaswwds_4_zonasnombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[ZonasNombre]) like '%' + UPPER(@lV62Zonaswwds_4_zonasnombre1))");
         }
         else
         {
            GXv_int4[5] = 1;
         }
         if ( AV63Zonaswwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV64Zonaswwds_6_dynamicfiltersselector2, "ZONASNOMBRE") == 0 ) && ( AV65Zonaswwds_7_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Zonaswwds_8_zonasnombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[ZonasNombre]) like UPPER(@lV66Zonaswwds_8_zonasnombre2))");
         }
         else
         {
            GXv_int4[6] = 1;
         }
         if ( AV63Zonaswwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV64Zonaswwds_6_dynamicfiltersselector2, "ZONASNOMBRE") == 0 ) && ( AV65Zonaswwds_7_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Zonaswwds_8_zonasnombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[ZonasNombre]) like '%' + UPPER(@lV66Zonaswwds_8_zonasnombre2))");
         }
         else
         {
            GXv_int4[7] = 1;
         }
         if ( AV67Zonaswwds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV68Zonaswwds_10_dynamicfiltersselector3, "ZONASNOMBRE") == 0 ) && ( AV69Zonaswwds_11_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Zonaswwds_12_zonasnombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[ZonasNombre]) like UPPER(@lV70Zonaswwds_12_zonasnombre3))");
         }
         else
         {
            GXv_int4[8] = 1;
         }
         if ( AV67Zonaswwds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV68Zonaswwds_10_dynamicfiltersselector3, "ZONASNOMBRE") == 0 ) && ( AV69Zonaswwds_11_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Zonaswwds_12_zonasnombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[ZonasNombre]) like '%' + UPPER(@lV70Zonaswwds_12_zonasnombre3))");
         }
         else
         {
            GXv_int4[9] = 1;
         }
         if ( ! (0==AV71Zonaswwds_13_tfzonasid) )
         {
            AddWhere(sWhereString, "(T1.[ZonasID] >= @AV71Zonaswwds_13_tfzonasid)");
         }
         else
         {
            GXv_int4[10] = 1;
         }
         if ( ! (0==AV72Zonaswwds_14_tfzonasid_to) )
         {
            AddWhere(sWhereString, "(T1.[ZonasID] <= @AV72Zonaswwds_14_tfzonasid_to)");
         }
         else
         {
            GXv_int4[11] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV74Zonaswwds_16_tfzonasnombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Zonaswwds_15_tfzonasnombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[ZonasNombre]) like UPPER(@lV73Zonaswwds_15_tfzonasnombre))");
         }
         else
         {
            GXv_int4[12] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Zonaswwds_16_tfzonasnombre_sel)) && ! ( StringUtil.StrCmp(AV74Zonaswwds_16_tfzonasnombre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[ZonasNombre] = @AV74Zonaswwds_16_tfzonasnombre_sel)");
         }
         else
         {
            GXv_int4[13] = 1;
         }
         if ( StringUtil.StrCmp(AV74Zonaswwds_16_tfzonasnombre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[ZonasNombre] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV76Zonaswwds_18_tfdepartamentodepartamento_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75Zonaswwds_17_tfdepartamentodepartamento)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[DepartamentoDepartamento]) like UPPER(@lV75Zonaswwds_17_tfdepartamentodepartamento))");
         }
         else
         {
            GXv_int4[14] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV76Zonaswwds_18_tfdepartamentodepartamento_sel)) && ! ( StringUtil.StrCmp(AV76Zonaswwds_18_tfdepartamentodepartamento_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.[DepartamentoDepartamento] = @AV76Zonaswwds_18_tfdepartamentodepartamento_sel)");
         }
         else
         {
            GXv_int4[15] = 1;
         }
         if ( StringUtil.StrCmp(AV76Zonaswwds_18_tfdepartamentodepartamento_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T2.[DepartamentoDepartamento] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV78Zonaswwds_20_tfdepartamentomunicipionombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV77Zonaswwds_19_tfdepartamentomunicipionombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T3.[DepartamentoMunicipioNombre]) like UPPER(@lV77Zonaswwds_19_tfdepartamentomunicipionombre))");
         }
         else
         {
            GXv_int4[16] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV78Zonaswwds_20_tfdepartamentomunicipionombre_sel)) && ! ( StringUtil.StrCmp(AV78Zonaswwds_20_tfdepartamentomunicipionombre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T3.[DepartamentoMunicipioNombre] = @AV78Zonaswwds_20_tfdepartamentomunicipionombre_sel)");
         }
         else
         {
            GXv_int4[17] = 1;
         }
         if ( StringUtil.StrCmp(AV78Zonaswwds_20_tfdepartamentomunicipionombre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T3.[DepartamentoMunicipioNombre] = ''))");
         }
         scmdbuf += sWhereString;
         if ( ( AV17OrderedBy == 1 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T2.[DepartamentoDepartamento]";
         }
         else if ( ( AV17OrderedBy == 1 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T2.[DepartamentoDepartamento] DESC";
         }
         else if ( ( AV17OrderedBy == 2 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[ZonasID]";
         }
         else if ( ( AV17OrderedBy == 2 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[ZonasID] DESC";
         }
         else if ( ( AV17OrderedBy == 3 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[ZonasNombre]";
         }
         else if ( ( AV17OrderedBy == 3 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[ZonasNombre] DESC";
         }
         else if ( ( AV17OrderedBy == 4 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T3.[DepartamentoMunicipioNombre]";
         }
         else if ( ( AV17OrderedBy == 4 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T3.[DepartamentoMunicipioNombre] DESC";
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
                     return conditional_P007J2(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (short)dynConstraints[2] , (string)dynConstraints[3] , (bool)dynConstraints[4] , (string)dynConstraints[5] , (short)dynConstraints[6] , (string)dynConstraints[7] , (bool)dynConstraints[8] , (string)dynConstraints[9] , (short)dynConstraints[10] , (string)dynConstraints[11] , (long)dynConstraints[12] , (long)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (long)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (short)dynConstraints[24] , (bool)dynConstraints[25] );
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
          Object[] prmP007J2;
          prmP007J2 = new Object[] {
          new ParDef("@lV59Zonaswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV59Zonaswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV59Zonaswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV59Zonaswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV62Zonaswwds_4_zonasnombre1",GXType.Char,120,0) ,
          new ParDef("@lV62Zonaswwds_4_zonasnombre1",GXType.Char,120,0) ,
          new ParDef("@lV66Zonaswwds_8_zonasnombre2",GXType.Char,120,0) ,
          new ParDef("@lV66Zonaswwds_8_zonasnombre2",GXType.Char,120,0) ,
          new ParDef("@lV70Zonaswwds_12_zonasnombre3",GXType.Char,120,0) ,
          new ParDef("@lV70Zonaswwds_12_zonasnombre3",GXType.Char,120,0) ,
          new ParDef("@AV71Zonaswwds_13_tfzonasid",GXType.Decimal,18,0) ,
          new ParDef("@AV72Zonaswwds_14_tfzonasid_to",GXType.Decimal,18,0) ,
          new ParDef("@lV73Zonaswwds_15_tfzonasnombre",GXType.Char,120,0) ,
          new ParDef("@AV74Zonaswwds_16_tfzonasnombre_sel",GXType.NChar,120,0) ,
          new ParDef("@lV75Zonaswwds_17_tfdepartamentodepartamento",GXType.Char,80,0) ,
          new ParDef("@AV76Zonaswwds_18_tfdepartamentodepartamento_sel",GXType.NChar,80,0) ,
          new ParDef("@lV77Zonaswwds_19_tfdepartamentomunicipionombre",GXType.Char,120,0) ,
          new ParDef("@AV78Zonaswwds_20_tfdepartamentomunicipionombre_sel",GXType.NChar,120,0)
          };
          def= new CursorDef[] {
              new CursorDef("P007J2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP007J2,100, GxCacheFrequency.OFF ,true,false )
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
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((long[]) buf[1])[0] = rslt.getLong(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 120);
                ((string[]) buf[3])[0] = rslt.getString(4, 80);
                ((string[]) buf[4])[0] = rslt.getString(5, 120);
                ((long[]) buf[5])[0] = rslt.getLong(6);
                return;
       }
    }

 }

}

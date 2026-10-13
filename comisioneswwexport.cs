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
   public class comisioneswwexport : GXProcedure
   {
      public comisioneswwexport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public comisioneswwexport( IGxContext context )
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
         new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWComisiones", out  GXt_boolean1) ;
         AV8IsAuthorized = GXt_boolean1;
         if ( ! AV8IsAuthorized )
         {
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "wwpbaseobjects.notauthorized.aspx"+GXUtil.UrlEncode(StringUtil.RTrim(AV61Pgmname));
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
         AV12Filename = GXt_char2 + "ComisionesWWExport-" + StringUtil.Trim( StringUtil.Str( (decimal)(AV16Random), 8, 0)) + ".xlsx";
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
            if ( StringUtil.StrCmp(AV20DynamicFiltersSelector1, "COMISIONESNOMBRE") == 0 )
            {
               AV21DynamicFiltersOperator1 = AV31GridStateDynamicFilter.gxTpr_Operator;
               AV22ComisionesNombre1 = AV31GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV22ComisionesNombre1)) )
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
                  new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV22ComisionesNombre1, out  GXt_char2) ;
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
               }
            }
            if ( AV34GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV23DynamicFiltersEnabled2 = true;
               AV31GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV34GridState.gxTpr_Dynamicfilters.Item(2));
               AV24DynamicFiltersSelector2 = AV31GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV24DynamicFiltersSelector2, "COMISIONESNOMBRE") == 0 )
               {
                  AV25DynamicFiltersOperator2 = AV31GridStateDynamicFilter.gxTpr_Operator;
                  AV26ComisionesNombre2 = AV31GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV26ComisionesNombre2)) )
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
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV26ComisionesNombre2, out  GXt_char2) ;
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
                  }
               }
               if ( AV34GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV27DynamicFiltersEnabled3 = true;
                  AV31GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV34GridState.gxTpr_Dynamicfilters.Item(3));
                  AV28DynamicFiltersSelector3 = AV31GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV28DynamicFiltersSelector3, "COMISIONESNOMBRE") == 0 )
                  {
                     AV29DynamicFiltersOperator3 = AV31GridStateDynamicFilter.gxTpr_Operator;
                     AV30ComisionesNombre3 = AV31GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV30ComisionesNombre3)) )
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
                        new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV30ComisionesNombre3, out  GXt_char2) ;
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
                     }
                  }
               }
            }
         }
         if ( ! ( (0==AV47TFComisionesID) && (0==AV48TFComisionesID_To) ) )
         {
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Código de la Comisión", "")) ;
            AV14CellRow = GXt_int3;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Number = AV47TFComisionesID;
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  false, ref  GXt_int3,  (short)(AV15FirstColumn+2),  context.GetMessage( "WWP_TSTo", "")) ;
            AV14CellRow = GXt_int3;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+3, 1, 1).Number = AV48TFComisionesID_To;
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
         if ( ! ( ( AV52TFComisionesTipo_Sels.Count == 0 ) ) )
         {
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Tipo", "")) ;
            AV14CellRow = GXt_int3;
            AV60i = 1;
            AV62GXV1 = 1;
            while ( AV62GXV1 <= AV52TFComisionesTipo_Sels.Count )
            {
               AV53TFComisionesTipo_Sel = AV52TFComisionesTipo_Sels.GetString(AV62GXV1);
               if ( AV60i == 1 )
               {
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = "";
               }
               else
               {
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text+", ";
               }
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text+context.GetMessage( gxdomaintipocomision.getDescription(context,AV53TFComisionesTipo_Sel), "");
               AV60i = (long)(AV60i+1);
               AV62GXV1 = (int)(AV62GXV1+1);
            }
         }
         if ( ! ( (Convert.ToDecimal(0)==AV54TFComisionesDefault) && (Convert.ToDecimal(0)==AV55TFComisionesDefault_To) ) )
         {
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Comisión por Defecto %", "")) ;
            AV14CellRow = GXt_int3;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Number = (double)(AV54TFComisionesDefault);
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  false, ref  GXt_int3,  (short)(AV15FirstColumn+2),  context.GetMessage( "WWP_TSTo", "")) ;
            AV14CellRow = GXt_int3;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+3, 1, 1).Number = (double)(AV55TFComisionesDefault_To);
         }
         if ( ! ( ( AV57TFComisionesEstado_Sels.Count == 0 ) ) )
         {
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Estado", "")) ;
            AV14CellRow = GXt_int3;
            AV60i = 1;
            AV63GXV2 = 1;
            while ( AV63GXV2 <= AV57TFComisionesEstado_Sels.Count )
            {
               AV58TFComisionesEstado_Sel = AV57TFComisionesEstado_Sels.GetString(AV63GXV2);
               if ( AV60i == 1 )
               {
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = "";
               }
               else
               {
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text+", ";
               }
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text+context.GetMessage( gxdomainestadoenum.getDescription(context,AV58TFComisionesEstado_Sel), "");
               AV60i = (long)(AV60i+1);
               AV63GXV2 = (int)(AV63GXV2+1);
            }
         }
         if ( ! ( (0==AV59TFComisionesGlobal_Sel) ) )
         {
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Comisión Global", "")) ;
            AV14CellRow = GXt_int3;
            if ( AV59TFComisionesGlobal_Sel == 1 )
            {
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = context.GetMessage( "WWP_TSChecked", "");
            }
            else if ( AV59TFComisionesGlobal_Sel == 2 )
            {
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = context.GetMessage( "WWP_TSUnChecked", "");
            }
         }
         AV14CellRow = (int)(AV14CellRow+2);
      }

      protected void S141( )
      {
         /* 'WRITECOLUMNTITLES' Routine */
         returnInSub = false;
         AV44VisibleColumnCount = 0;
         if ( StringUtil.StrCmp(AV32Session.Get("ComisionesWWColumnsSelector"), "") != 0 )
         {
            AV39ColumnsSelectorXML = AV32Session.Get("ComisionesWWColumnsSelector");
            AV36ColumnsSelector.FromXml(AV39ColumnsSelectorXML, null, "", "");
         }
         else
         {
            /* Execute user subroutine: 'INITIALIZECOLUMNSSELECTOR' */
            S151 ();
            if (returnInSub) return;
         }
         AV36ColumnsSelector.gxTpr_Columns.Sort("Order");
         AV64GXV3 = 1;
         while ( AV64GXV3 <= AV36ColumnsSelector.gxTpr_Columns.Count )
         {
            AV38ColumnsSelector_Column = ((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV36ColumnsSelector.gxTpr_Columns.Item(AV64GXV3));
            if ( AV38ColumnsSelector_Column.gxTpr_Isvisible )
            {
               AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV44VisibleColumnCount), 1, 1).Text = context.GetMessage( (String.IsNullOrEmpty(StringUtil.RTrim( AV38ColumnsSelector_Column.gxTpr_Displayname)) ? AV38ColumnsSelector_Column.gxTpr_Columnname : AV38ColumnsSelector_Column.gxTpr_Displayname), "");
               AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV44VisibleColumnCount), 1, 1).Bold = 1;
               AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV44VisibleColumnCount), 1, 1).Color = 11;
               AV44VisibleColumnCount = (long)(AV44VisibleColumnCount+1);
            }
            AV64GXV3 = (int)(AV64GXV3+1);
         }
      }

      protected void S161( )
      {
         /* 'WRITEDATA' Routine */
         returnInSub = false;
         AV66Comisioneswwds_1_filterfulltext = AV19FilterFullText;
         AV67Comisioneswwds_2_dynamicfiltersselector1 = AV20DynamicFiltersSelector1;
         AV68Comisioneswwds_3_dynamicfiltersoperator1 = AV21DynamicFiltersOperator1;
         AV69Comisioneswwds_4_comisionesnombre1 = AV22ComisionesNombre1;
         AV70Comisioneswwds_5_dynamicfiltersenabled2 = AV23DynamicFiltersEnabled2;
         AV71Comisioneswwds_6_dynamicfiltersselector2 = AV24DynamicFiltersSelector2;
         AV72Comisioneswwds_7_dynamicfiltersoperator2 = AV25DynamicFiltersOperator2;
         AV73Comisioneswwds_8_comisionesnombre2 = AV26ComisionesNombre2;
         AV74Comisioneswwds_9_dynamicfiltersenabled3 = AV27DynamicFiltersEnabled3;
         AV75Comisioneswwds_10_dynamicfiltersselector3 = AV28DynamicFiltersSelector3;
         AV76Comisioneswwds_11_dynamicfiltersoperator3 = AV29DynamicFiltersOperator3;
         AV77Comisioneswwds_12_comisionesnombre3 = AV30ComisionesNombre3;
         AV78Comisioneswwds_13_tfcomisionesid = AV47TFComisionesID;
         AV79Comisioneswwds_14_tfcomisionesid_to = AV48TFComisionesID_To;
         AV80Comisioneswwds_15_tfcomisionesnombre = AV49TFComisionesNombre;
         AV81Comisioneswwds_16_tfcomisionesnombre_sel = AV50TFComisionesNombre_Sel;
         AV82Comisioneswwds_17_tfcomisionestipo_sels = AV52TFComisionesTipo_Sels;
         AV83Comisioneswwds_18_tfcomisionesdefault = AV54TFComisionesDefault;
         AV84Comisioneswwds_19_tfcomisionesdefault_to = AV55TFComisionesDefault_To;
         AV85Comisioneswwds_20_tfcomisionesestado_sels = AV57TFComisionesEstado_Sels;
         AV86Comisioneswwds_21_tfcomisionesglobal_sel = AV59TFComisionesGlobal_Sel;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A505ComisionesTipo ,
                                              AV82Comisioneswwds_17_tfcomisionestipo_sels ,
                                              A511ComisionesEstado ,
                                              AV85Comisioneswwds_20_tfcomisionesestado_sels ,
                                              AV67Comisioneswwds_2_dynamicfiltersselector1 ,
                                              AV68Comisioneswwds_3_dynamicfiltersoperator1 ,
                                              AV69Comisioneswwds_4_comisionesnombre1 ,
                                              AV70Comisioneswwds_5_dynamicfiltersenabled2 ,
                                              AV71Comisioneswwds_6_dynamicfiltersselector2 ,
                                              AV72Comisioneswwds_7_dynamicfiltersoperator2 ,
                                              AV73Comisioneswwds_8_comisionesnombre2 ,
                                              AV74Comisioneswwds_9_dynamicfiltersenabled3 ,
                                              AV75Comisioneswwds_10_dynamicfiltersselector3 ,
                                              AV76Comisioneswwds_11_dynamicfiltersoperator3 ,
                                              AV77Comisioneswwds_12_comisionesnombre3 ,
                                              AV78Comisioneswwds_13_tfcomisionesid ,
                                              AV79Comisioneswwds_14_tfcomisionesid_to ,
                                              AV81Comisioneswwds_16_tfcomisionesnombre_sel ,
                                              AV80Comisioneswwds_15_tfcomisionesnombre ,
                                              AV82Comisioneswwds_17_tfcomisionestipo_sels.Count ,
                                              AV83Comisioneswwds_18_tfcomisionesdefault ,
                                              AV84Comisioneswwds_19_tfcomisionesdefault_to ,
                                              AV85Comisioneswwds_20_tfcomisionesestado_sels.Count ,
                                              AV86Comisioneswwds_21_tfcomisionesglobal_sel ,
                                              A504ComisionesNombre ,
                                              A503ComisionesID ,
                                              A506ComisionesDefault ,
                                              A520ComisionesGlobal ,
                                              AV17OrderedBy ,
                                              AV18OrderedDsc ,
                                              AV66Comisioneswwds_1_filterfulltext } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.INT, TypeConstants.DECIMAL,
                                              TypeConstants.DECIMAL, TypeConstants.INT, TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV69Comisioneswwds_4_comisionesnombre1 = StringUtil.PadR( StringUtil.RTrim( AV69Comisioneswwds_4_comisionesnombre1), 80, "%");
         lV69Comisioneswwds_4_comisionesnombre1 = StringUtil.PadR( StringUtil.RTrim( AV69Comisioneswwds_4_comisionesnombre1), 80, "%");
         lV73Comisioneswwds_8_comisionesnombre2 = StringUtil.PadR( StringUtil.RTrim( AV73Comisioneswwds_8_comisionesnombre2), 80, "%");
         lV73Comisioneswwds_8_comisionesnombre2 = StringUtil.PadR( StringUtil.RTrim( AV73Comisioneswwds_8_comisionesnombre2), 80, "%");
         lV77Comisioneswwds_12_comisionesnombre3 = StringUtil.PadR( StringUtil.RTrim( AV77Comisioneswwds_12_comisionesnombre3), 80, "%");
         lV77Comisioneswwds_12_comisionesnombre3 = StringUtil.PadR( StringUtil.RTrim( AV77Comisioneswwds_12_comisionesnombre3), 80, "%");
         lV80Comisioneswwds_15_tfcomisionesnombre = StringUtil.PadR( StringUtil.RTrim( AV80Comisioneswwds_15_tfcomisionesnombre), 80, "%");
         /* Using cursor P006I2 */
         pr_default.execute(0, new Object[] {lV69Comisioneswwds_4_comisionesnombre1, lV69Comisioneswwds_4_comisionesnombre1, lV73Comisioneswwds_8_comisionesnombre2, lV73Comisioneswwds_8_comisionesnombre2, lV77Comisioneswwds_12_comisionesnombre3, lV77Comisioneswwds_12_comisionesnombre3, AV78Comisioneswwds_13_tfcomisionesid, AV79Comisioneswwds_14_tfcomisionesid_to, lV80Comisioneswwds_15_tfcomisionesnombre, AV81Comisioneswwds_16_tfcomisionesnombre_sel, AV83Comisioneswwds_18_tfcomisionesdefault, AV84Comisioneswwds_19_tfcomisionesdefault_to});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A520ComisionesGlobal = P006I2_A520ComisionesGlobal[0];
            n520ComisionesGlobal = P006I2_n520ComisionesGlobal[0];
            A506ComisionesDefault = P006I2_A506ComisionesDefault[0];
            n506ComisionesDefault = P006I2_n506ComisionesDefault[0];
            A504ComisionesNombre = P006I2_A504ComisionesNombre[0];
            A503ComisionesID = P006I2_A503ComisionesID[0];
            A511ComisionesEstado = P006I2_A511ComisionesEstado[0];
            n511ComisionesEstado = P006I2_n511ComisionesEstado[0];
            A505ComisionesTipo = P006I2_A505ComisionesTipo[0];
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV66Comisioneswwds_1_filterfulltext)) || ( ( StringUtil.Like( StringUtil.Str( (decimal)(A503ComisionesID), 18, 0) , StringUtil.PadR( "%" + AV66Comisioneswwds_1_filterfulltext , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A504ComisionesNombre) , StringUtil.PadR( "%" + StringUtil.Upper( AV66Comisioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( context.GetMessage( "profesional", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV66Comisioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A505ComisionesTipo, "P") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "comercio", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV66Comisioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A505ComisionesTipo, "C") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "zona", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV66Comisioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A505ComisionesTipo, "Z") == 0 ) ) || ( StringUtil.Like( StringUtil.Str( A506ComisionesDefault, 6, 2) , StringUtil.PadR( "%" + AV66Comisioneswwds_1_filterfulltext , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( context.GetMessage( "habilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV66Comisioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A511ComisionesEstado, "HAB") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "deshabilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV66Comisioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A511ComisionesEstado, "DES") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "pendiente", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV66Comisioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A511ComisionesEstado, "PEN") == 0 ) ) ) )
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
               AV87GXV4 = 1;
               while ( AV87GXV4 <= AV36ColumnsSelector.gxTpr_Columns.Count )
               {
                  AV38ColumnsSelector_Column = ((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV36ColumnsSelector.gxTpr_Columns.Item(AV87GXV4));
                  if ( AV38ColumnsSelector_Column.gxTpr_Isvisible )
                  {
                     if ( StringUtil.StrCmp(AV38ColumnsSelector_Column.gxTpr_Columnname, "ComisionesID") == 0 )
                     {
                        AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV44VisibleColumnCount), 1, 1).Number = A503ComisionesID;
                     }
                     else if ( StringUtil.StrCmp(AV38ColumnsSelector_Column.gxTpr_Columnname, "ComisionesNombre") == 0 )
                     {
                        GXt_char2 = "";
                        new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A504ComisionesNombre, out  GXt_char2) ;
                        AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV44VisibleColumnCount), 1, 1).Text = GXt_char2;
                     }
                     else if ( StringUtil.StrCmp(AV38ColumnsSelector_Column.gxTpr_Columnname, "ComisionesTipo") == 0 )
                     {
                        AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV44VisibleColumnCount), 1, 1).Text = context.GetMessage( gxdomaintipocomision.getDescription(context,A505ComisionesTipo), "");
                     }
                     else if ( StringUtil.StrCmp(AV38ColumnsSelector_Column.gxTpr_Columnname, "ComisionesImagen") == 0 )
                     {
                        AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV44VisibleColumnCount), 1, 1).Text = "";
                     }
                     else if ( StringUtil.StrCmp(AV38ColumnsSelector_Column.gxTpr_Columnname, "ComisionesDefault") == 0 )
                     {
                        AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV44VisibleColumnCount), 1, 1).Number = (double)(A506ComisionesDefault);
                     }
                     else if ( StringUtil.StrCmp(AV38ColumnsSelector_Column.gxTpr_Columnname, "ComisionesEstado") == 0 )
                     {
                        AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV44VisibleColumnCount), 1, 1).Text = context.GetMessage( gxdomainestadoenum.getDescription(context,A511ComisionesEstado), "");
                     }
                     else if ( StringUtil.StrCmp(AV38ColumnsSelector_Column.gxTpr_Columnname, "ComisionesGlobal") == 0 )
                     {
                        AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV44VisibleColumnCount), 1, 1).Text = StringUtil.BoolToStr( A520ComisionesGlobal);
                     }
                     AV44VisibleColumnCount = (long)(AV44VisibleColumnCount+1);
                  }
                  AV87GXV4 = (int)(AV87GXV4+1);
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
         AV32Session.Set("WWPExportFileName", "ComisionesWWExport.xlsx");
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
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV36ColumnsSelector,  "ComisionesID",  "",  "Código de la Comisión",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV36ColumnsSelector,  "ComisionesNombre",  "",  "Nombre",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV36ColumnsSelector,  "ComisionesTipo",  "",  "Tipo",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV36ColumnsSelector,  "ComisionesImagen",  "",  "Imagen Promisional",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV36ColumnsSelector,  "ComisionesDefault",  "",  "Comisión por Defecto %",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV36ColumnsSelector,  "ComisionesEstado",  "",  "Estado",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV36ColumnsSelector,  "ComisionesGlobal",  "",  "Comisión Global",  true,  "") ;
         GXt_char2 = AV40UserCustomValue;
         new GeneXus.Programs.wwpbaseobjects.loadcolumnsselectorstate(context ).execute(  "ComisionesWWColumnsSelector", out  GXt_char2) ;
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
         if ( StringUtil.StrCmp(AV32Session.Get("ComisionesWWGridState"), "") == 0 )
         {
            AV34GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "ComisionesWWGridState"), null, "", "");
         }
         else
         {
            AV34GridState.FromXml(AV32Session.Get("ComisionesWWGridState"), null, "", "");
         }
         AV17OrderedBy = AV34GridState.gxTpr_Orderedby;
         AV18OrderedDsc = AV34GridState.gxTpr_Ordereddsc;
         AV88GXV5 = 1;
         while ( AV88GXV5 <= AV34GridState.gxTpr_Filtervalues.Count )
         {
            AV35GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV34GridState.gxTpr_Filtervalues.Item(AV88GXV5));
            if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV19FilterFullText = AV35GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFCOMISIONESID") == 0 )
            {
               AV47TFComisionesID = (long)(Math.Round(NumberUtil.Val( AV35GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV48TFComisionesID_To = (long)(Math.Round(NumberUtil.Val( AV35GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFCOMISIONESNOMBRE") == 0 )
            {
               AV49TFComisionesNombre = AV35GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFCOMISIONESNOMBRE_SEL") == 0 )
            {
               AV50TFComisionesNombre_Sel = AV35GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFCOMISIONESTIPO_SEL") == 0 )
            {
               AV51TFComisionesTipo_SelsJson = AV35GridStateFilterValue.gxTpr_Value;
               AV52TFComisionesTipo_Sels.FromJSonString(AV51TFComisionesTipo_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFCOMISIONESDEFAULT") == 0 )
            {
               AV54TFComisionesDefault = NumberUtil.Val( AV35GridStateFilterValue.gxTpr_Value, ".");
               AV55TFComisionesDefault_To = NumberUtil.Val( AV35GridStateFilterValue.gxTpr_Valueto, ".");
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFCOMISIONESESTADO_SEL") == 0 )
            {
               AV56TFComisionesEstado_SelsJson = AV35GridStateFilterValue.gxTpr_Value;
               AV57TFComisionesEstado_Sels.FromJSonString(AV56TFComisionesEstado_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFCOMISIONESGLOBAL_SEL") == 0 )
            {
               AV59TFComisionesGlobal_Sel = (short)(Math.Round(NumberUtil.Val( AV35GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
            }
            AV88GXV5 = (int)(AV88GXV5+1);
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
         AV61Pgmname = "";
         GXKey = "";
         GXEncryptionTmp = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV11ExcelDocument = new ExcelDocumentI();
         AV19FilterFullText = "";
         AV34GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV31GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV20DynamicFiltersSelector1 = "";
         AV22ComisionesNombre1 = "";
         AV24DynamicFiltersSelector2 = "";
         AV26ComisionesNombre2 = "";
         AV28DynamicFiltersSelector3 = "";
         AV30ComisionesNombre3 = "";
         AV50TFComisionesNombre_Sel = "";
         AV49TFComisionesNombre = "";
         AV52TFComisionesTipo_Sels = new GxSimpleCollection<string>();
         AV53TFComisionesTipo_Sel = "";
         AV57TFComisionesEstado_Sels = new GxSimpleCollection<string>();
         AV58TFComisionesEstado_Sel = "";
         AV32Session = context.GetSession();
         AV39ColumnsSelectorXML = "";
         AV36ColumnsSelector = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector(context);
         AV38ColumnsSelector_Column = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column(context);
         AV66Comisioneswwds_1_filterfulltext = "";
         AV67Comisioneswwds_2_dynamicfiltersselector1 = "";
         AV69Comisioneswwds_4_comisionesnombre1 = "";
         AV71Comisioneswwds_6_dynamicfiltersselector2 = "";
         AV73Comisioneswwds_8_comisionesnombre2 = "";
         AV75Comisioneswwds_10_dynamicfiltersselector3 = "";
         AV77Comisioneswwds_12_comisionesnombre3 = "";
         AV80Comisioneswwds_15_tfcomisionesnombre = "";
         AV81Comisioneswwds_16_tfcomisionesnombre_sel = "";
         AV82Comisioneswwds_17_tfcomisionestipo_sels = new GxSimpleCollection<string>();
         AV85Comisioneswwds_20_tfcomisionesestado_sels = new GxSimpleCollection<string>();
         lV69Comisioneswwds_4_comisionesnombre1 = "";
         lV73Comisioneswwds_8_comisionesnombre2 = "";
         lV77Comisioneswwds_12_comisionesnombre3 = "";
         lV80Comisioneswwds_15_tfcomisionesnombre = "";
         A505ComisionesTipo = "";
         A511ComisionesEstado = "";
         A504ComisionesNombre = "";
         P006I2_A520ComisionesGlobal = new bool[] {false} ;
         P006I2_n520ComisionesGlobal = new bool[] {false} ;
         P006I2_A506ComisionesDefault = new decimal[1] ;
         P006I2_n506ComisionesDefault = new bool[] {false} ;
         P006I2_A504ComisionesNombre = new string[] {""} ;
         P006I2_A503ComisionesID = new long[1] ;
         P006I2_A511ComisionesEstado = new string[] {""} ;
         P006I2_n511ComisionesEstado = new bool[] {false} ;
         P006I2_A505ComisionesTipo = new string[] {""} ;
         AV40UserCustomValue = "";
         GXt_char2 = "";
         AV37ColumnsSelectorAux = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector(context);
         AV35GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV51TFComisionesTipo_SelsJson = "";
         AV56TFComisionesEstado_SelsJson = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.comisioneswwexport__default(),
            new Object[][] {
                new Object[] {
               P006I2_A520ComisionesGlobal, P006I2_n520ComisionesGlobal, P006I2_A506ComisionesDefault, P006I2_n506ComisionesDefault, P006I2_A504ComisionesNombre, P006I2_A503ComisionesID, P006I2_A511ComisionesEstado, P006I2_n511ComisionesEstado, P006I2_A505ComisionesTipo
               }
            }
         );
         AV61Pgmname = "ComisionesWWExport";
         /* GeneXus formulas. */
         AV61Pgmname = "ComisionesWWExport";
      }

      private short AV21DynamicFiltersOperator1 ;
      private short AV25DynamicFiltersOperator2 ;
      private short AV29DynamicFiltersOperator3 ;
      private short AV59TFComisionesGlobal_Sel ;
      private short GXt_int3 ;
      private short AV68Comisioneswwds_3_dynamicfiltersoperator1 ;
      private short AV72Comisioneswwds_7_dynamicfiltersoperator2 ;
      private short AV76Comisioneswwds_11_dynamicfiltersoperator3 ;
      private short AV86Comisioneswwds_21_tfcomisionesglobal_sel ;
      private short AV17OrderedBy ;
      private int AV14CellRow ;
      private int AV15FirstColumn ;
      private int AV16Random ;
      private int AV62GXV1 ;
      private int AV63GXV2 ;
      private int AV64GXV3 ;
      private int AV82Comisioneswwds_17_tfcomisionestipo_sels_Count ;
      private int AV85Comisioneswwds_20_tfcomisionesestado_sels_Count ;
      private int AV87GXV4 ;
      private int AV88GXV5 ;
      private long AV47TFComisionesID ;
      private long AV48TFComisionesID_To ;
      private long AV60i ;
      private long AV44VisibleColumnCount ;
      private long AV78Comisioneswwds_13_tfcomisionesid ;
      private long AV79Comisioneswwds_14_tfcomisionesid_to ;
      private long A503ComisionesID ;
      private decimal AV54TFComisionesDefault ;
      private decimal AV55TFComisionesDefault_To ;
      private decimal AV83Comisioneswwds_18_tfcomisionesdefault ;
      private decimal AV84Comisioneswwds_19_tfcomisionesdefault_to ;
      private decimal A506ComisionesDefault ;
      private string AV61Pgmname ;
      private string GXKey ;
      private string GXEncryptionTmp ;
      private string AV22ComisionesNombre1 ;
      private string AV26ComisionesNombre2 ;
      private string AV30ComisionesNombre3 ;
      private string AV50TFComisionesNombre_Sel ;
      private string AV49TFComisionesNombre ;
      private string AV53TFComisionesTipo_Sel ;
      private string AV58TFComisionesEstado_Sel ;
      private string AV69Comisioneswwds_4_comisionesnombre1 ;
      private string AV73Comisioneswwds_8_comisionesnombre2 ;
      private string AV77Comisioneswwds_12_comisionesnombre3 ;
      private string AV80Comisioneswwds_15_tfcomisionesnombre ;
      private string AV81Comisioneswwds_16_tfcomisionesnombre_sel ;
      private string lV69Comisioneswwds_4_comisionesnombre1 ;
      private string lV73Comisioneswwds_8_comisionesnombre2 ;
      private string lV77Comisioneswwds_12_comisionesnombre3 ;
      private string lV80Comisioneswwds_15_tfcomisionesnombre ;
      private string A505ComisionesTipo ;
      private string A511ComisionesEstado ;
      private string A504ComisionesNombre ;
      private string GXt_char2 ;
      private bool AV8IsAuthorized ;
      private bool GXt_boolean1 ;
      private bool returnInSub ;
      private bool AV23DynamicFiltersEnabled2 ;
      private bool AV27DynamicFiltersEnabled3 ;
      private bool AV70Comisioneswwds_5_dynamicfiltersenabled2 ;
      private bool AV74Comisioneswwds_9_dynamicfiltersenabled3 ;
      private bool A520ComisionesGlobal ;
      private bool AV18OrderedDsc ;
      private bool n520ComisionesGlobal ;
      private bool n506ComisionesDefault ;
      private bool n511ComisionesEstado ;
      private string AV39ColumnsSelectorXML ;
      private string AV40UserCustomValue ;
      private string AV51TFComisionesTipo_SelsJson ;
      private string AV56TFComisionesEstado_SelsJson ;
      private string AV12Filename ;
      private string AV13ErrorMessage ;
      private string AV19FilterFullText ;
      private string AV20DynamicFiltersSelector1 ;
      private string AV24DynamicFiltersSelector2 ;
      private string AV28DynamicFiltersSelector3 ;
      private string AV66Comisioneswwds_1_filterfulltext ;
      private string AV67Comisioneswwds_2_dynamicfiltersselector1 ;
      private string AV71Comisioneswwds_6_dynamicfiltersselector2 ;
      private string AV75Comisioneswwds_10_dynamicfiltersselector3 ;
      private IGxSession AV32Session ;
      private ExcelDocumentI AV11ExcelDocument ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV34GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV31GridStateDynamicFilter ;
      private GxSimpleCollection<string> AV52TFComisionesTipo_Sels ;
      private GxSimpleCollection<string> AV57TFComisionesEstado_Sels ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector AV36ColumnsSelector ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column AV38ColumnsSelector_Column ;
      private GxSimpleCollection<string> AV82Comisioneswwds_17_tfcomisionestipo_sels ;
      private GxSimpleCollection<string> AV85Comisioneswwds_20_tfcomisionesestado_sels ;
      private IDataStoreProvider pr_default ;
      private bool[] P006I2_A520ComisionesGlobal ;
      private bool[] P006I2_n520ComisionesGlobal ;
      private decimal[] P006I2_A506ComisionesDefault ;
      private bool[] P006I2_n506ComisionesDefault ;
      private string[] P006I2_A504ComisionesNombre ;
      private long[] P006I2_A503ComisionesID ;
      private string[] P006I2_A511ComisionesEstado ;
      private bool[] P006I2_n511ComisionesEstado ;
      private string[] P006I2_A505ComisionesTipo ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector AV37ColumnsSelectorAux ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV35GridStateFilterValue ;
      private string aP0_Filename ;
      private string aP1_ErrorMessage ;
   }

   public class comisioneswwexport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P006I2( IGxContext context ,
                                             string A505ComisionesTipo ,
                                             GxSimpleCollection<string> AV82Comisioneswwds_17_tfcomisionestipo_sels ,
                                             string A511ComisionesEstado ,
                                             GxSimpleCollection<string> AV85Comisioneswwds_20_tfcomisionesestado_sels ,
                                             string AV67Comisioneswwds_2_dynamicfiltersselector1 ,
                                             short AV68Comisioneswwds_3_dynamicfiltersoperator1 ,
                                             string AV69Comisioneswwds_4_comisionesnombre1 ,
                                             bool AV70Comisioneswwds_5_dynamicfiltersenabled2 ,
                                             string AV71Comisioneswwds_6_dynamicfiltersselector2 ,
                                             short AV72Comisioneswwds_7_dynamicfiltersoperator2 ,
                                             string AV73Comisioneswwds_8_comisionesnombre2 ,
                                             bool AV74Comisioneswwds_9_dynamicfiltersenabled3 ,
                                             string AV75Comisioneswwds_10_dynamicfiltersselector3 ,
                                             short AV76Comisioneswwds_11_dynamicfiltersoperator3 ,
                                             string AV77Comisioneswwds_12_comisionesnombre3 ,
                                             long AV78Comisioneswwds_13_tfcomisionesid ,
                                             long AV79Comisioneswwds_14_tfcomisionesid_to ,
                                             string AV81Comisioneswwds_16_tfcomisionesnombre_sel ,
                                             string AV80Comisioneswwds_15_tfcomisionesnombre ,
                                             int AV82Comisioneswwds_17_tfcomisionestipo_sels_Count ,
                                             decimal AV83Comisioneswwds_18_tfcomisionesdefault ,
                                             decimal AV84Comisioneswwds_19_tfcomisionesdefault_to ,
                                             int AV85Comisioneswwds_20_tfcomisionesestado_sels_Count ,
                                             short AV86Comisioneswwds_21_tfcomisionesglobal_sel ,
                                             string A504ComisionesNombre ,
                                             long A503ComisionesID ,
                                             decimal A506ComisionesDefault ,
                                             bool A520ComisionesGlobal ,
                                             short AV17OrderedBy ,
                                             bool AV18OrderedDsc ,
                                             string AV66Comisioneswwds_1_filterfulltext )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int4 = new short[12];
         Object[] GXv_Object5 = new Object[2];
         scmdbuf = "SELECT [ComisionesGlobal], [ComisionesDefault], [ComisionesNombre], [ComisionesID], [ComisionesEstado], [ComisionesTipo] FROM [Comisiones]";
         if ( ( StringUtil.StrCmp(AV67Comisioneswwds_2_dynamicfiltersselector1, "COMISIONESNOMBRE") == 0 ) && ( AV68Comisioneswwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Comisioneswwds_4_comisionesnombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ComisionesNombre]) like UPPER(@lV69Comisioneswwds_4_comisionesnombre1))");
         }
         else
         {
            GXv_int4[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV67Comisioneswwds_2_dynamicfiltersselector1, "COMISIONESNOMBRE") == 0 ) && ( AV68Comisioneswwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Comisioneswwds_4_comisionesnombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ComisionesNombre]) like '%' + UPPER(@lV69Comisioneswwds_4_comisionesnombre1))");
         }
         else
         {
            GXv_int4[1] = 1;
         }
         if ( AV70Comisioneswwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV71Comisioneswwds_6_dynamicfiltersselector2, "COMISIONESNOMBRE") == 0 ) && ( AV72Comisioneswwds_7_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Comisioneswwds_8_comisionesnombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ComisionesNombre]) like UPPER(@lV73Comisioneswwds_8_comisionesnombre2))");
         }
         else
         {
            GXv_int4[2] = 1;
         }
         if ( AV70Comisioneswwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV71Comisioneswwds_6_dynamicfiltersselector2, "COMISIONESNOMBRE") == 0 ) && ( AV72Comisioneswwds_7_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Comisioneswwds_8_comisionesnombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ComisionesNombre]) like '%' + UPPER(@lV73Comisioneswwds_8_comisionesnombre2))");
         }
         else
         {
            GXv_int4[3] = 1;
         }
         if ( AV74Comisioneswwds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV75Comisioneswwds_10_dynamicfiltersselector3, "COMISIONESNOMBRE") == 0 ) && ( AV76Comisioneswwds_11_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV77Comisioneswwds_12_comisionesnombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ComisionesNombre]) like UPPER(@lV77Comisioneswwds_12_comisionesnombre3))");
         }
         else
         {
            GXv_int4[4] = 1;
         }
         if ( AV74Comisioneswwds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV75Comisioneswwds_10_dynamicfiltersselector3, "COMISIONESNOMBRE") == 0 ) && ( AV76Comisioneswwds_11_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV77Comisioneswwds_12_comisionesnombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ComisionesNombre]) like '%' + UPPER(@lV77Comisioneswwds_12_comisionesnombre3))");
         }
         else
         {
            GXv_int4[5] = 1;
         }
         if ( ! (0==AV78Comisioneswwds_13_tfcomisionesid) )
         {
            AddWhere(sWhereString, "([ComisionesID] >= @AV78Comisioneswwds_13_tfcomisionesid)");
         }
         else
         {
            GXv_int4[6] = 1;
         }
         if ( ! (0==AV79Comisioneswwds_14_tfcomisionesid_to) )
         {
            AddWhere(sWhereString, "([ComisionesID] <= @AV79Comisioneswwds_14_tfcomisionesid_to)");
         }
         else
         {
            GXv_int4[7] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV81Comisioneswwds_16_tfcomisionesnombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV80Comisioneswwds_15_tfcomisionesnombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ComisionesNombre]) like UPPER(@lV80Comisioneswwds_15_tfcomisionesnombre))");
         }
         else
         {
            GXv_int4[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV81Comisioneswwds_16_tfcomisionesnombre_sel)) && ! ( StringUtil.StrCmp(AV81Comisioneswwds_16_tfcomisionesnombre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([ComisionesNombre] = @AV81Comisioneswwds_16_tfcomisionesnombre_sel)");
         }
         else
         {
            GXv_int4[9] = 1;
         }
         if ( StringUtil.StrCmp(AV81Comisioneswwds_16_tfcomisionesnombre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([ComisionesNombre] = ''))");
         }
         if ( AV82Comisioneswwds_17_tfcomisionestipo_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV82Comisioneswwds_17_tfcomisionestipo_sels, "[ComisionesTipo] IN (", ")")+")");
         }
         if ( ! (Convert.ToDecimal(0)==AV83Comisioneswwds_18_tfcomisionesdefault) )
         {
            AddWhere(sWhereString, "([ComisionesDefault] >= @AV83Comisioneswwds_18_tfcomisionesdefault)");
         }
         else
         {
            GXv_int4[10] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV84Comisioneswwds_19_tfcomisionesdefault_to) )
         {
            AddWhere(sWhereString, "([ComisionesDefault] <= @AV84Comisioneswwds_19_tfcomisionesdefault_to)");
         }
         else
         {
            GXv_int4[11] = 1;
         }
         if ( AV85Comisioneswwds_20_tfcomisionesestado_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV85Comisioneswwds_20_tfcomisionesestado_sels, "[ComisionesEstado] IN (", ")")+")");
         }
         if ( AV86Comisioneswwds_21_tfcomisionesglobal_sel == 1 )
         {
            AddWhere(sWhereString, "([ComisionesGlobal] = 1)");
         }
         if ( AV86Comisioneswwds_21_tfcomisionesglobal_sel == 2 )
         {
            AddWhere(sWhereString, "([ComisionesGlobal] = 0)");
         }
         scmdbuf += sWhereString;
         if ( ( AV17OrderedBy == 1 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY [ComisionesNombre]";
         }
         else if ( ( AV17OrderedBy == 1 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [ComisionesNombre] DESC";
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
            scmdbuf += " ORDER BY [ComisionesTipo]";
         }
         else if ( ( AV17OrderedBy == 3 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [ComisionesTipo] DESC";
         }
         else if ( ( AV17OrderedBy == 4 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY [ComisionesDefault]";
         }
         else if ( ( AV17OrderedBy == 4 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [ComisionesDefault] DESC";
         }
         else if ( ( AV17OrderedBy == 5 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY [ComisionesEstado]";
         }
         else if ( ( AV17OrderedBy == 5 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [ComisionesEstado] DESC";
         }
         else if ( ( AV17OrderedBy == 6 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY [ComisionesGlobal]";
         }
         else if ( ( AV17OrderedBy == 6 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [ComisionesGlobal] DESC";
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
                     return conditional_P006I2(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (GxSimpleCollection<string>)dynConstraints[3] , (string)dynConstraints[4] , (short)dynConstraints[5] , (string)dynConstraints[6] , (bool)dynConstraints[7] , (string)dynConstraints[8] , (short)dynConstraints[9] , (string)dynConstraints[10] , (bool)dynConstraints[11] , (string)dynConstraints[12] , (short)dynConstraints[13] , (string)dynConstraints[14] , (long)dynConstraints[15] , (long)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (int)dynConstraints[19] , (decimal)dynConstraints[20] , (decimal)dynConstraints[21] , (int)dynConstraints[22] , (short)dynConstraints[23] , (string)dynConstraints[24] , (long)dynConstraints[25] , (decimal)dynConstraints[26] , (bool)dynConstraints[27] , (short)dynConstraints[28] , (bool)dynConstraints[29] , (string)dynConstraints[30] );
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
          Object[] prmP006I2;
          prmP006I2 = new Object[] {
          new ParDef("@lV69Comisioneswwds_4_comisionesnombre1",GXType.Char,80,0) ,
          new ParDef("@lV69Comisioneswwds_4_comisionesnombre1",GXType.Char,80,0) ,
          new ParDef("@lV73Comisioneswwds_8_comisionesnombre2",GXType.Char,80,0) ,
          new ParDef("@lV73Comisioneswwds_8_comisionesnombre2",GXType.Char,80,0) ,
          new ParDef("@lV77Comisioneswwds_12_comisionesnombre3",GXType.Char,80,0) ,
          new ParDef("@lV77Comisioneswwds_12_comisionesnombre3",GXType.Char,80,0) ,
          new ParDef("@AV78Comisioneswwds_13_tfcomisionesid",GXType.Decimal,18,0) ,
          new ParDef("@AV79Comisioneswwds_14_tfcomisionesid_to",GXType.Decimal,18,0) ,
          new ParDef("@lV80Comisioneswwds_15_tfcomisionesnombre",GXType.Char,80,0) ,
          new ParDef("@AV81Comisioneswwds_16_tfcomisionesnombre_sel",GXType.NChar,80,0) ,
          new ParDef("@AV83Comisioneswwds_18_tfcomisionesdefault",GXType.Decimal,6,2) ,
          new ParDef("@AV84Comisioneswwds_19_tfcomisionesdefault_to",GXType.Decimal,6,2)
          };
          def= new CursorDef[] {
              new CursorDef("P006I2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP006I2,100, GxCacheFrequency.OFF ,true,false )
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
                ((bool[]) buf[0])[0] = rslt.getBool(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((decimal[]) buf[2])[0] = rslt.getDecimal(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((string[]) buf[4])[0] = rslt.getString(3, 80);
                ((long[]) buf[5])[0] = rslt.getLong(4);
                ((string[]) buf[6])[0] = rslt.getString(5, 3);
                ((bool[]) buf[7])[0] = rslt.wasNull(5);
                ((string[]) buf[8])[0] = rslt.getString(6, 1);
                return;
       }
    }

 }

}

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
   public class listacostoswwexport : GXProcedure
   {
      public listacostoswwexport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public listacostoswwexport( IGxContext context )
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
         new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWListaCostos", out  GXt_boolean1) ;
         AV8IsAuthorized = GXt_boolean1;
         if ( ! AV8IsAuthorized )
         {
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "wwpbaseobjects.notauthorized.aspx"+GXUtil.UrlEncode(StringUtil.RTrim(AV63Pgmname));
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
         AV12Filename = GXt_char2 + "ListaCostosWWExport-" + StringUtil.Trim( StringUtil.Str( (decimal)(AV16Random), 8, 0)) + ".xlsx";
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
            if ( StringUtil.StrCmp(AV20DynamicFiltersSelector1, "LISTACOSTOSNOMBRE") == 0 )
            {
               AV21DynamicFiltersOperator1 = AV31GridStateDynamicFilter.gxTpr_Operator;
               AV22ListaCostosNombre1 = AV31GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV22ListaCostosNombre1)) )
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
                  new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV22ListaCostosNombre1, out  GXt_char2) ;
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
               }
            }
            if ( AV34GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV23DynamicFiltersEnabled2 = true;
               AV31GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV34GridState.gxTpr_Dynamicfilters.Item(2));
               AV24DynamicFiltersSelector2 = AV31GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV24DynamicFiltersSelector2, "LISTACOSTOSNOMBRE") == 0 )
               {
                  AV25DynamicFiltersOperator2 = AV31GridStateDynamicFilter.gxTpr_Operator;
                  AV26ListaCostosNombre2 = AV31GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV26ListaCostosNombre2)) )
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
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV26ListaCostosNombre2, out  GXt_char2) ;
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
                  }
               }
               if ( AV34GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV27DynamicFiltersEnabled3 = true;
                  AV31GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV34GridState.gxTpr_Dynamicfilters.Item(3));
                  AV28DynamicFiltersSelector3 = AV31GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV28DynamicFiltersSelector3, "LISTACOSTOSNOMBRE") == 0 )
                  {
                     AV29DynamicFiltersOperator3 = AV31GridStateDynamicFilter.gxTpr_Operator;
                     AV30ListaCostosNombre3 = AV31GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV30ListaCostosNombre3)) )
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
                        new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV30ListaCostosNombre3, out  GXt_char2) ;
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
                     }
                  }
               }
            }
         }
         if ( ! ( (0==AV47TFListaCostosId) && (0==AV48TFListaCostosId_To) ) )
         {
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Idc", "")) ;
            AV14CellRow = GXt_int3;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Number = AV47TFListaCostosId;
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  false, ref  GXt_int3,  (short)(AV15FirstColumn+2),  context.GetMessage( "WWP_TSTo", "")) ;
            AV14CellRow = GXt_int3;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+3, 1, 1).Number = AV48TFListaCostosId_To;
         }
         if ( ! ( (0==AV49TFTipoCuentaId) && (0==AV50TFTipoCuentaId_To) ) )
         {
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Clasificación", "")) ;
            AV14CellRow = GXt_int3;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Number = AV49TFTipoCuentaId;
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  false, ref  GXt_int3,  (short)(AV15FirstColumn+2),  context.GetMessage( "WWP_TSTo", "")) ;
            AV14CellRow = GXt_int3;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+3, 1, 1).Number = AV50TFTipoCuentaId_To;
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV52TFTipoCuentaNombre_Sel)) ) )
         {
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Nombre", "")) ;
            AV14CellRow = GXt_int3;
            GXt_char2 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV52TFTipoCuentaNombre_Sel)) ? context.GetMessage( "WWP_TitleFilter_EmptyOption", "") : AV52TFTipoCuentaNombre_Sel), out  GXt_char2) ;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV51TFTipoCuentaNombre)) ) )
            {
               GXt_int3 = (short)(AV14CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Nombre", "")) ;
               AV14CellRow = GXt_int3;
               GXt_char2 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV51TFTipoCuentaNombre, out  GXt_char2) ;
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV54TFListaCostosNombre_Sel)) ) )
         {
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Nombre", "")) ;
            AV14CellRow = GXt_int3;
            GXt_char2 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV54TFListaCostosNombre_Sel)) ? context.GetMessage( "WWP_TitleFilter_EmptyOption", "") : AV54TFListaCostosNombre_Sel), out  GXt_char2) ;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV53TFListaCostosNombre)) ) )
            {
               GXt_int3 = (short)(AV14CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Nombre", "")) ;
               AV14CellRow = GXt_int3;
               GXt_char2 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV53TFListaCostosNombre, out  GXt_char2) ;
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
            }
         }
         if ( ! ( (Convert.ToDecimal(0)==AV55TFListaCostosValor) && (Convert.ToDecimal(0)==AV56TFListaCostosValor_To) ) )
         {
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Costo", "")) ;
            AV14CellRow = GXt_int3;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Number = (double)(AV55TFListaCostosValor);
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  false, ref  GXt_int3,  (short)(AV15FirstColumn+2),  context.GetMessage( "WWP_TSTo", "")) ;
            AV14CellRow = GXt_int3;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+3, 1, 1).Number = (double)(AV56TFListaCostosValor_To);
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV58TFListaCostosCC_Sel)) ) )
         {
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Código Contable ", "")) ;
            AV14CellRow = GXt_int3;
            GXt_char2 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV58TFListaCostosCC_Sel)) ? context.GetMessage( "WWP_TitleFilter_EmptyOption", "") : AV58TFListaCostosCC_Sel), out  GXt_char2) ;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV57TFListaCostosCC)) ) )
            {
               GXt_int3 = (short)(AV14CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Código Contable ", "")) ;
               AV14CellRow = GXt_int3;
               GXt_char2 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV57TFListaCostosCC, out  GXt_char2) ;
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
            }
         }
         if ( ! ( ( AV60TFListaCostosEstado_Sels.Count == 0 ) ) )
         {
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Estado", "")) ;
            AV14CellRow = GXt_int3;
            AV62i = 1;
            AV64GXV1 = 1;
            while ( AV64GXV1 <= AV60TFListaCostosEstado_Sels.Count )
            {
               AV61TFListaCostosEstado_Sel = AV60TFListaCostosEstado_Sels.GetString(AV64GXV1);
               if ( AV62i == 1 )
               {
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = "";
               }
               else
               {
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text+", ";
               }
               if ( StringUtil.StrCmp(StringUtil.Trim( AV61TFListaCostosEstado_Sel), context.GetMessage( "HAB", "")) == 0 )
               {
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text+context.GetMessage( "Habilitado", "");
               }
               else if ( StringUtil.StrCmp(StringUtil.Trim( AV61TFListaCostosEstado_Sel), context.GetMessage( "DES", "")) == 0 )
               {
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text+context.GetMessage( "Deshabilitado", "");
               }
               AV62i = (long)(AV62i+1);
               AV64GXV1 = (int)(AV64GXV1+1);
            }
         }
         AV14CellRow = (int)(AV14CellRow+2);
      }

      protected void S141( )
      {
         /* 'WRITECOLUMNTITLES' Routine */
         returnInSub = false;
         AV44VisibleColumnCount = 0;
         if ( StringUtil.StrCmp(AV32Session.Get("ListaCostosWWColumnsSelector"), "") != 0 )
         {
            AV39ColumnsSelectorXML = AV32Session.Get("ListaCostosWWColumnsSelector");
            AV36ColumnsSelector.FromXml(AV39ColumnsSelectorXML, null, "", "");
         }
         else
         {
            /* Execute user subroutine: 'INITIALIZECOLUMNSSELECTOR' */
            S151 ();
            if (returnInSub) return;
         }
         AV36ColumnsSelector.gxTpr_Columns.Sort("Order");
         AV65GXV2 = 1;
         while ( AV65GXV2 <= AV36ColumnsSelector.gxTpr_Columns.Count )
         {
            AV38ColumnsSelector_Column = ((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV36ColumnsSelector.gxTpr_Columns.Item(AV65GXV2));
            if ( AV38ColumnsSelector_Column.gxTpr_Isvisible )
            {
               AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV44VisibleColumnCount), 1, 1).Text = context.GetMessage( (String.IsNullOrEmpty(StringUtil.RTrim( AV38ColumnsSelector_Column.gxTpr_Displayname)) ? AV38ColumnsSelector_Column.gxTpr_Columnname : AV38ColumnsSelector_Column.gxTpr_Displayname), "");
               AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV44VisibleColumnCount), 1, 1).Bold = 1;
               AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV44VisibleColumnCount), 1, 1).Color = 11;
               AV44VisibleColumnCount = (long)(AV44VisibleColumnCount+1);
            }
            AV65GXV2 = (int)(AV65GXV2+1);
         }
      }

      protected void S161( )
      {
         /* 'WRITEDATA' Routine */
         returnInSub = false;
         AV67Listacostoswwds_1_filterfulltext = AV19FilterFullText;
         AV68Listacostoswwds_2_dynamicfiltersselector1 = AV20DynamicFiltersSelector1;
         AV69Listacostoswwds_3_dynamicfiltersoperator1 = AV21DynamicFiltersOperator1;
         AV70Listacostoswwds_4_listacostosnombre1 = AV22ListaCostosNombre1;
         AV71Listacostoswwds_5_dynamicfiltersenabled2 = AV23DynamicFiltersEnabled2;
         AV72Listacostoswwds_6_dynamicfiltersselector2 = AV24DynamicFiltersSelector2;
         AV73Listacostoswwds_7_dynamicfiltersoperator2 = AV25DynamicFiltersOperator2;
         AV74Listacostoswwds_8_listacostosnombre2 = AV26ListaCostosNombre2;
         AV75Listacostoswwds_9_dynamicfiltersenabled3 = AV27DynamicFiltersEnabled3;
         AV76Listacostoswwds_10_dynamicfiltersselector3 = AV28DynamicFiltersSelector3;
         AV77Listacostoswwds_11_dynamicfiltersoperator3 = AV29DynamicFiltersOperator3;
         AV78Listacostoswwds_12_listacostosnombre3 = AV30ListaCostosNombre3;
         AV79Listacostoswwds_13_tflistacostosid = AV47TFListaCostosId;
         AV80Listacostoswwds_14_tflistacostosid_to = AV48TFListaCostosId_To;
         AV81Listacostoswwds_15_tftipocuentaid = AV49TFTipoCuentaId;
         AV82Listacostoswwds_16_tftipocuentaid_to = AV50TFTipoCuentaId_To;
         AV83Listacostoswwds_17_tftipocuentanombre = AV51TFTipoCuentaNombre;
         AV84Listacostoswwds_18_tftipocuentanombre_sel = AV52TFTipoCuentaNombre_Sel;
         AV85Listacostoswwds_19_tflistacostosnombre = AV53TFListaCostosNombre;
         AV86Listacostoswwds_20_tflistacostosnombre_sel = AV54TFListaCostosNombre_Sel;
         AV87Listacostoswwds_21_tflistacostosvalor = AV55TFListaCostosValor;
         AV88Listacostoswwds_22_tflistacostosvalor_to = AV56TFListaCostosValor_To;
         AV89Listacostoswwds_23_tflistacostoscc = AV57TFListaCostosCC;
         AV90Listacostoswwds_24_tflistacostoscc_sel = AV58TFListaCostosCC_Sel;
         AV91Listacostoswwds_25_tflistacostosestado_sels = AV60TFListaCostosEstado_Sels;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A486ListaCostosEstado ,
                                              AV91Listacostoswwds_25_tflistacostosestado_sels ,
                                              AV68Listacostoswwds_2_dynamicfiltersselector1 ,
                                              AV69Listacostoswwds_3_dynamicfiltersoperator1 ,
                                              AV70Listacostoswwds_4_listacostosnombre1 ,
                                              AV71Listacostoswwds_5_dynamicfiltersenabled2 ,
                                              AV72Listacostoswwds_6_dynamicfiltersselector2 ,
                                              AV73Listacostoswwds_7_dynamicfiltersoperator2 ,
                                              AV74Listacostoswwds_8_listacostosnombre2 ,
                                              AV75Listacostoswwds_9_dynamicfiltersenabled3 ,
                                              AV76Listacostoswwds_10_dynamicfiltersselector3 ,
                                              AV77Listacostoswwds_11_dynamicfiltersoperator3 ,
                                              AV78Listacostoswwds_12_listacostosnombre3 ,
                                              AV79Listacostoswwds_13_tflistacostosid ,
                                              AV80Listacostoswwds_14_tflistacostosid_to ,
                                              AV81Listacostoswwds_15_tftipocuentaid ,
                                              AV82Listacostoswwds_16_tftipocuentaid_to ,
                                              AV84Listacostoswwds_18_tftipocuentanombre_sel ,
                                              AV83Listacostoswwds_17_tftipocuentanombre ,
                                              AV86Listacostoswwds_20_tflistacostosnombre_sel ,
                                              AV85Listacostoswwds_19_tflistacostosnombre ,
                                              AV87Listacostoswwds_21_tflistacostosvalor ,
                                              AV88Listacostoswwds_22_tflistacostosvalor_to ,
                                              AV90Listacostoswwds_24_tflistacostoscc_sel ,
                                              AV89Listacostoswwds_23_tflistacostoscc ,
                                              AV91Listacostoswwds_25_tflistacostosestado_sels.Count ,
                                              A460ListaCostosNombre ,
                                              A459ListaCostosId ,
                                              A483TipoCuentaId ,
                                              A484TipoCuentaNombre ,
                                              A471ListaCostosValor ,
                                              A485ListaCostosCC ,
                                              AV17OrderedBy ,
                                              AV18OrderedDsc ,
                                              AV67Listacostoswwds_1_filterfulltext } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.DECIMAL,
                                              TypeConstants.DECIMAL, TypeConstants.INT, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV70Listacostoswwds_4_listacostosnombre1 = StringUtil.PadR( StringUtil.RTrim( AV70Listacostoswwds_4_listacostosnombre1), 80, "%");
         lV70Listacostoswwds_4_listacostosnombre1 = StringUtil.PadR( StringUtil.RTrim( AV70Listacostoswwds_4_listacostosnombre1), 80, "%");
         lV74Listacostoswwds_8_listacostosnombre2 = StringUtil.PadR( StringUtil.RTrim( AV74Listacostoswwds_8_listacostosnombre2), 80, "%");
         lV74Listacostoswwds_8_listacostosnombre2 = StringUtil.PadR( StringUtil.RTrim( AV74Listacostoswwds_8_listacostosnombre2), 80, "%");
         lV78Listacostoswwds_12_listacostosnombre3 = StringUtil.PadR( StringUtil.RTrim( AV78Listacostoswwds_12_listacostosnombre3), 80, "%");
         lV78Listacostoswwds_12_listacostosnombre3 = StringUtil.PadR( StringUtil.RTrim( AV78Listacostoswwds_12_listacostosnombre3), 80, "%");
         lV83Listacostoswwds_17_tftipocuentanombre = StringUtil.PadR( StringUtil.RTrim( AV83Listacostoswwds_17_tftipocuentanombre), 120, "%");
         lV85Listacostoswwds_19_tflistacostosnombre = StringUtil.PadR( StringUtil.RTrim( AV85Listacostoswwds_19_tflistacostosnombre), 80, "%");
         lV89Listacostoswwds_23_tflistacostoscc = StringUtil.PadR( StringUtil.RTrim( AV89Listacostoswwds_23_tflistacostoscc), 35, "%");
         /* Using cursor P00632 */
         pr_default.execute(0, new Object[] {lV70Listacostoswwds_4_listacostosnombre1, lV70Listacostoswwds_4_listacostosnombre1, lV74Listacostoswwds_8_listacostosnombre2, lV74Listacostoswwds_8_listacostosnombre2, lV78Listacostoswwds_12_listacostosnombre3, lV78Listacostoswwds_12_listacostosnombre3, AV79Listacostoswwds_13_tflistacostosid, AV80Listacostoswwds_14_tflistacostosid_to, AV81Listacostoswwds_15_tftipocuentaid, AV82Listacostoswwds_16_tftipocuentaid_to, lV83Listacostoswwds_17_tftipocuentanombre, AV84Listacostoswwds_18_tftipocuentanombre_sel, lV85Listacostoswwds_19_tflistacostosnombre, AV86Listacostoswwds_20_tflistacostosnombre_sel, AV87Listacostoswwds_21_tflistacostosvalor, AV88Listacostoswwds_22_tflistacostosvalor_to, lV89Listacostoswwds_23_tflistacostoscc, AV90Listacostoswwds_24_tflistacostoscc_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A485ListaCostosCC = P00632_A485ListaCostosCC[0];
            n485ListaCostosCC = P00632_n485ListaCostosCC[0];
            A471ListaCostosValor = P00632_A471ListaCostosValor[0];
            A460ListaCostosNombre = P00632_A460ListaCostosNombre[0];
            A484TipoCuentaNombre = P00632_A484TipoCuentaNombre[0];
            A483TipoCuentaId = P00632_A483TipoCuentaId[0];
            n483TipoCuentaId = P00632_n483TipoCuentaId[0];
            A459ListaCostosId = P00632_A459ListaCostosId[0];
            A486ListaCostosEstado = P00632_A486ListaCostosEstado[0];
            A484TipoCuentaNombre = P00632_A484TipoCuentaNombre[0];
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV67Listacostoswwds_1_filterfulltext)) || ( ( StringUtil.Like( StringUtil.Str( (decimal)(A459ListaCostosId), 18, 0) , StringUtil.PadR( "%" + AV67Listacostoswwds_1_filterfulltext , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Str( (decimal)(A483TipoCuentaId), 18, 0) , StringUtil.PadR( "%" + AV67Listacostoswwds_1_filterfulltext , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A484TipoCuentaNombre) , StringUtil.PadR( "%" + StringUtil.Upper( AV67Listacostoswwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A460ListaCostosNombre) , StringUtil.PadR( "%" + StringUtil.Upper( AV67Listacostoswwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Str( A471ListaCostosValor, 18, 2) , StringUtil.PadR( "%" + AV67Listacostoswwds_1_filterfulltext , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A485ListaCostosCC) , StringUtil.PadR( "%" + StringUtil.Upper( AV67Listacostoswwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( context.GetMessage( "habilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV67Listacostoswwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A486ListaCostosEstado, "HAB") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "deshabilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV67Listacostoswwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A486ListaCostosEstado, "DES") == 0 ) ) ) )
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
               AV92GXV3 = 1;
               while ( AV92GXV3 <= AV36ColumnsSelector.gxTpr_Columns.Count )
               {
                  AV38ColumnsSelector_Column = ((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV36ColumnsSelector.gxTpr_Columns.Item(AV92GXV3));
                  if ( AV38ColumnsSelector_Column.gxTpr_Isvisible )
                  {
                     if ( StringUtil.StrCmp(AV38ColumnsSelector_Column.gxTpr_Columnname, "ListaCostosId") == 0 )
                     {
                        AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV44VisibleColumnCount), 1, 1).Number = A459ListaCostosId;
                     }
                     else if ( StringUtil.StrCmp(AV38ColumnsSelector_Column.gxTpr_Columnname, "TipoCuentaId") == 0 )
                     {
                        AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV44VisibleColumnCount), 1, 1).Number = A483TipoCuentaId;
                     }
                     else if ( StringUtil.StrCmp(AV38ColumnsSelector_Column.gxTpr_Columnname, "TipoCuentaNombre") == 0 )
                     {
                        GXt_char2 = "";
                        new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A484TipoCuentaNombre, out  GXt_char2) ;
                        AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV44VisibleColumnCount), 1, 1).Text = GXt_char2;
                     }
                     else if ( StringUtil.StrCmp(AV38ColumnsSelector_Column.gxTpr_Columnname, "ListaCostosNombre") == 0 )
                     {
                        GXt_char2 = "";
                        new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A460ListaCostosNombre, out  GXt_char2) ;
                        AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV44VisibleColumnCount), 1, 1).Text = GXt_char2;
                     }
                     else if ( StringUtil.StrCmp(AV38ColumnsSelector_Column.gxTpr_Columnname, "ListaCostosValor") == 0 )
                     {
                        AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV44VisibleColumnCount), 1, 1).Number = (double)(A471ListaCostosValor);
                     }
                     else if ( StringUtil.StrCmp(AV38ColumnsSelector_Column.gxTpr_Columnname, "ListaCostosCC") == 0 )
                     {
                        GXt_char2 = "";
                        new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A485ListaCostosCC, out  GXt_char2) ;
                        AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV44VisibleColumnCount), 1, 1).Text = GXt_char2;
                     }
                     else if ( StringUtil.StrCmp(AV38ColumnsSelector_Column.gxTpr_Columnname, "ListaCostosEstado") == 0 )
                     {
                        AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV44VisibleColumnCount), 1, 1).Text = "";
                        if ( StringUtil.StrCmp(StringUtil.Trim( A486ListaCostosEstado), context.GetMessage( "HAB", "")) == 0 )
                        {
                           AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV44VisibleColumnCount), 1, 1).Text = context.GetMessage( "Habilitado", "");
                        }
                        else if ( StringUtil.StrCmp(StringUtil.Trim( A486ListaCostosEstado), context.GetMessage( "DES", "")) == 0 )
                        {
                           AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV44VisibleColumnCount), 1, 1).Text = context.GetMessage( "Deshabilitado", "");
                        }
                     }
                     AV44VisibleColumnCount = (long)(AV44VisibleColumnCount+1);
                  }
                  AV92GXV3 = (int)(AV92GXV3+1);
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
         AV32Session.Set("WWPExportFileName", "ListaCostosWWExport.xlsx");
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
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV36ColumnsSelector,  "ListaCostosId",  "",  "Idc",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV36ColumnsSelector,  "TipoCuentaId",  "",  "Clasificación",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV36ColumnsSelector,  "TipoCuentaNombre",  "",  "Nombre",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV36ColumnsSelector,  "ListaCostosNombre",  "",  "Nombre",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV36ColumnsSelector,  "ListaCostosValor",  "",  "Costo",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV36ColumnsSelector,  "ListaCostosCC",  "",  "Código Contable ",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV36ColumnsSelector,  "ListaCostosEstado",  "",  "Estado",  true,  "") ;
         GXt_char2 = AV40UserCustomValue;
         new GeneXus.Programs.wwpbaseobjects.loadcolumnsselectorstate(context ).execute(  "ListaCostosWWColumnsSelector", out  GXt_char2) ;
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
         if ( StringUtil.StrCmp(AV32Session.Get("ListaCostosWWGridState"), "") == 0 )
         {
            AV34GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "ListaCostosWWGridState"), null, "", "");
         }
         else
         {
            AV34GridState.FromXml(AV32Session.Get("ListaCostosWWGridState"), null, "", "");
         }
         AV17OrderedBy = AV34GridState.gxTpr_Orderedby;
         AV18OrderedDsc = AV34GridState.gxTpr_Ordereddsc;
         AV93GXV4 = 1;
         while ( AV93GXV4 <= AV34GridState.gxTpr_Filtervalues.Count )
         {
            AV35GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV34GridState.gxTpr_Filtervalues.Item(AV93GXV4));
            if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV19FilterFullText = AV35GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFLISTACOSTOSID") == 0 )
            {
               AV47TFListaCostosId = (long)(Math.Round(NumberUtil.Val( AV35GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV48TFListaCostosId_To = (long)(Math.Round(NumberUtil.Val( AV35GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFTIPOCUENTAID") == 0 )
            {
               AV49TFTipoCuentaId = (long)(Math.Round(NumberUtil.Val( AV35GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV50TFTipoCuentaId_To = (long)(Math.Round(NumberUtil.Val( AV35GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFTIPOCUENTANOMBRE") == 0 )
            {
               AV51TFTipoCuentaNombre = AV35GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFTIPOCUENTANOMBRE_SEL") == 0 )
            {
               AV52TFTipoCuentaNombre_Sel = AV35GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFLISTACOSTOSNOMBRE") == 0 )
            {
               AV53TFListaCostosNombre = AV35GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFLISTACOSTOSNOMBRE_SEL") == 0 )
            {
               AV54TFListaCostosNombre_Sel = AV35GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFLISTACOSTOSVALOR") == 0 )
            {
               AV55TFListaCostosValor = NumberUtil.Val( AV35GridStateFilterValue.gxTpr_Value, ".");
               AV56TFListaCostosValor_To = NumberUtil.Val( AV35GridStateFilterValue.gxTpr_Valueto, ".");
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFLISTACOSTOSCC") == 0 )
            {
               AV57TFListaCostosCC = AV35GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFLISTACOSTOSCC_SEL") == 0 )
            {
               AV58TFListaCostosCC_Sel = AV35GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFLISTACOSTOSESTADO_SEL") == 0 )
            {
               AV59TFListaCostosEstado_SelsJson = AV35GridStateFilterValue.gxTpr_Value;
               AV60TFListaCostosEstado_Sels.FromJSonString(AV59TFListaCostosEstado_SelsJson, null);
            }
            AV93GXV4 = (int)(AV93GXV4+1);
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
         AV63Pgmname = "";
         GXKey = "";
         GXEncryptionTmp = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV11ExcelDocument = new ExcelDocumentI();
         AV19FilterFullText = "";
         AV34GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV31GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV20DynamicFiltersSelector1 = "";
         AV22ListaCostosNombre1 = "";
         AV24DynamicFiltersSelector2 = "";
         AV26ListaCostosNombre2 = "";
         AV28DynamicFiltersSelector3 = "";
         AV30ListaCostosNombre3 = "";
         AV52TFTipoCuentaNombre_Sel = "";
         AV51TFTipoCuentaNombre = "";
         AV54TFListaCostosNombre_Sel = "";
         AV53TFListaCostosNombre = "";
         AV58TFListaCostosCC_Sel = "";
         AV57TFListaCostosCC = "";
         AV60TFListaCostosEstado_Sels = new GxSimpleCollection<string>();
         AV61TFListaCostosEstado_Sel = "";
         AV32Session = context.GetSession();
         AV39ColumnsSelectorXML = "";
         AV36ColumnsSelector = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector(context);
         AV38ColumnsSelector_Column = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column(context);
         AV67Listacostoswwds_1_filterfulltext = "";
         AV68Listacostoswwds_2_dynamicfiltersselector1 = "";
         AV70Listacostoswwds_4_listacostosnombre1 = "";
         AV72Listacostoswwds_6_dynamicfiltersselector2 = "";
         AV74Listacostoswwds_8_listacostosnombre2 = "";
         AV76Listacostoswwds_10_dynamicfiltersselector3 = "";
         AV78Listacostoswwds_12_listacostosnombre3 = "";
         AV83Listacostoswwds_17_tftipocuentanombre = "";
         AV84Listacostoswwds_18_tftipocuentanombre_sel = "";
         AV85Listacostoswwds_19_tflistacostosnombre = "";
         AV86Listacostoswwds_20_tflistacostosnombre_sel = "";
         AV89Listacostoswwds_23_tflistacostoscc = "";
         AV90Listacostoswwds_24_tflistacostoscc_sel = "";
         AV91Listacostoswwds_25_tflistacostosestado_sels = new GxSimpleCollection<string>();
         lV70Listacostoswwds_4_listacostosnombre1 = "";
         lV74Listacostoswwds_8_listacostosnombre2 = "";
         lV78Listacostoswwds_12_listacostosnombre3 = "";
         lV83Listacostoswwds_17_tftipocuentanombre = "";
         lV85Listacostoswwds_19_tflistacostosnombre = "";
         lV89Listacostoswwds_23_tflistacostoscc = "";
         A486ListaCostosEstado = "";
         A460ListaCostosNombre = "";
         A484TipoCuentaNombre = "";
         A485ListaCostosCC = "";
         P00632_A485ListaCostosCC = new string[] {""} ;
         P00632_n485ListaCostosCC = new bool[] {false} ;
         P00632_A471ListaCostosValor = new decimal[1] ;
         P00632_A460ListaCostosNombre = new string[] {""} ;
         P00632_A484TipoCuentaNombre = new string[] {""} ;
         P00632_A483TipoCuentaId = new long[1] ;
         P00632_n483TipoCuentaId = new bool[] {false} ;
         P00632_A459ListaCostosId = new long[1] ;
         P00632_A486ListaCostosEstado = new string[] {""} ;
         AV40UserCustomValue = "";
         GXt_char2 = "";
         AV37ColumnsSelectorAux = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector(context);
         AV35GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV59TFListaCostosEstado_SelsJson = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.listacostoswwexport__default(),
            new Object[][] {
                new Object[] {
               P00632_A485ListaCostosCC, P00632_n485ListaCostosCC, P00632_A471ListaCostosValor, P00632_A460ListaCostosNombre, P00632_A484TipoCuentaNombre, P00632_A483TipoCuentaId, P00632_n483TipoCuentaId, P00632_A459ListaCostosId, P00632_A486ListaCostosEstado
               }
            }
         );
         AV63Pgmname = "ListaCostosWWExport";
         /* GeneXus formulas. */
         AV63Pgmname = "ListaCostosWWExport";
      }

      private short AV21DynamicFiltersOperator1 ;
      private short AV25DynamicFiltersOperator2 ;
      private short AV29DynamicFiltersOperator3 ;
      private short GXt_int3 ;
      private short AV69Listacostoswwds_3_dynamicfiltersoperator1 ;
      private short AV73Listacostoswwds_7_dynamicfiltersoperator2 ;
      private short AV77Listacostoswwds_11_dynamicfiltersoperator3 ;
      private short AV17OrderedBy ;
      private int AV14CellRow ;
      private int AV15FirstColumn ;
      private int AV16Random ;
      private int AV64GXV1 ;
      private int AV65GXV2 ;
      private int AV91Listacostoswwds_25_tflistacostosestado_sels_Count ;
      private int AV92GXV3 ;
      private int AV93GXV4 ;
      private long AV47TFListaCostosId ;
      private long AV48TFListaCostosId_To ;
      private long AV49TFTipoCuentaId ;
      private long AV50TFTipoCuentaId_To ;
      private long AV62i ;
      private long AV44VisibleColumnCount ;
      private long AV79Listacostoswwds_13_tflistacostosid ;
      private long AV80Listacostoswwds_14_tflistacostosid_to ;
      private long AV81Listacostoswwds_15_tftipocuentaid ;
      private long AV82Listacostoswwds_16_tftipocuentaid_to ;
      private long A459ListaCostosId ;
      private long A483TipoCuentaId ;
      private decimal AV55TFListaCostosValor ;
      private decimal AV56TFListaCostosValor_To ;
      private decimal AV87Listacostoswwds_21_tflistacostosvalor ;
      private decimal AV88Listacostoswwds_22_tflistacostosvalor_to ;
      private decimal A471ListaCostosValor ;
      private string AV63Pgmname ;
      private string GXKey ;
      private string GXEncryptionTmp ;
      private string AV22ListaCostosNombre1 ;
      private string AV26ListaCostosNombre2 ;
      private string AV30ListaCostosNombre3 ;
      private string AV52TFTipoCuentaNombre_Sel ;
      private string AV51TFTipoCuentaNombre ;
      private string AV54TFListaCostosNombre_Sel ;
      private string AV53TFListaCostosNombre ;
      private string AV58TFListaCostosCC_Sel ;
      private string AV57TFListaCostosCC ;
      private string AV61TFListaCostosEstado_Sel ;
      private string AV70Listacostoswwds_4_listacostosnombre1 ;
      private string AV74Listacostoswwds_8_listacostosnombre2 ;
      private string AV78Listacostoswwds_12_listacostosnombre3 ;
      private string AV83Listacostoswwds_17_tftipocuentanombre ;
      private string AV84Listacostoswwds_18_tftipocuentanombre_sel ;
      private string AV85Listacostoswwds_19_tflistacostosnombre ;
      private string AV86Listacostoswwds_20_tflistacostosnombre_sel ;
      private string AV89Listacostoswwds_23_tflistacostoscc ;
      private string AV90Listacostoswwds_24_tflistacostoscc_sel ;
      private string lV70Listacostoswwds_4_listacostosnombre1 ;
      private string lV74Listacostoswwds_8_listacostosnombre2 ;
      private string lV78Listacostoswwds_12_listacostosnombre3 ;
      private string lV83Listacostoswwds_17_tftipocuentanombre ;
      private string lV85Listacostoswwds_19_tflistacostosnombre ;
      private string lV89Listacostoswwds_23_tflistacostoscc ;
      private string A486ListaCostosEstado ;
      private string A460ListaCostosNombre ;
      private string A484TipoCuentaNombre ;
      private string A485ListaCostosCC ;
      private string GXt_char2 ;
      private bool AV8IsAuthorized ;
      private bool GXt_boolean1 ;
      private bool returnInSub ;
      private bool AV23DynamicFiltersEnabled2 ;
      private bool AV27DynamicFiltersEnabled3 ;
      private bool AV71Listacostoswwds_5_dynamicfiltersenabled2 ;
      private bool AV75Listacostoswwds_9_dynamicfiltersenabled3 ;
      private bool AV18OrderedDsc ;
      private bool n485ListaCostosCC ;
      private bool n483TipoCuentaId ;
      private string AV39ColumnsSelectorXML ;
      private string AV40UserCustomValue ;
      private string AV59TFListaCostosEstado_SelsJson ;
      private string AV12Filename ;
      private string AV13ErrorMessage ;
      private string AV19FilterFullText ;
      private string AV20DynamicFiltersSelector1 ;
      private string AV24DynamicFiltersSelector2 ;
      private string AV28DynamicFiltersSelector3 ;
      private string AV67Listacostoswwds_1_filterfulltext ;
      private string AV68Listacostoswwds_2_dynamicfiltersselector1 ;
      private string AV72Listacostoswwds_6_dynamicfiltersselector2 ;
      private string AV76Listacostoswwds_10_dynamicfiltersselector3 ;
      private IGxSession AV32Session ;
      private ExcelDocumentI AV11ExcelDocument ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV34GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV31GridStateDynamicFilter ;
      private GxSimpleCollection<string> AV60TFListaCostosEstado_Sels ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector AV36ColumnsSelector ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column AV38ColumnsSelector_Column ;
      private GxSimpleCollection<string> AV91Listacostoswwds_25_tflistacostosestado_sels ;
      private IDataStoreProvider pr_default ;
      private string[] P00632_A485ListaCostosCC ;
      private bool[] P00632_n485ListaCostosCC ;
      private decimal[] P00632_A471ListaCostosValor ;
      private string[] P00632_A460ListaCostosNombre ;
      private string[] P00632_A484TipoCuentaNombre ;
      private long[] P00632_A483TipoCuentaId ;
      private bool[] P00632_n483TipoCuentaId ;
      private long[] P00632_A459ListaCostosId ;
      private string[] P00632_A486ListaCostosEstado ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector AV37ColumnsSelectorAux ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV35GridStateFilterValue ;
      private string aP0_Filename ;
      private string aP1_ErrorMessage ;
   }

   public class listacostoswwexport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00632( IGxContext context ,
                                             string A486ListaCostosEstado ,
                                             GxSimpleCollection<string> AV91Listacostoswwds_25_tflistacostosestado_sels ,
                                             string AV68Listacostoswwds_2_dynamicfiltersselector1 ,
                                             short AV69Listacostoswwds_3_dynamicfiltersoperator1 ,
                                             string AV70Listacostoswwds_4_listacostosnombre1 ,
                                             bool AV71Listacostoswwds_5_dynamicfiltersenabled2 ,
                                             string AV72Listacostoswwds_6_dynamicfiltersselector2 ,
                                             short AV73Listacostoswwds_7_dynamicfiltersoperator2 ,
                                             string AV74Listacostoswwds_8_listacostosnombre2 ,
                                             bool AV75Listacostoswwds_9_dynamicfiltersenabled3 ,
                                             string AV76Listacostoswwds_10_dynamicfiltersselector3 ,
                                             short AV77Listacostoswwds_11_dynamicfiltersoperator3 ,
                                             string AV78Listacostoswwds_12_listacostosnombre3 ,
                                             long AV79Listacostoswwds_13_tflistacostosid ,
                                             long AV80Listacostoswwds_14_tflistacostosid_to ,
                                             long AV81Listacostoswwds_15_tftipocuentaid ,
                                             long AV82Listacostoswwds_16_tftipocuentaid_to ,
                                             string AV84Listacostoswwds_18_tftipocuentanombre_sel ,
                                             string AV83Listacostoswwds_17_tftipocuentanombre ,
                                             string AV86Listacostoswwds_20_tflistacostosnombre_sel ,
                                             string AV85Listacostoswwds_19_tflistacostosnombre ,
                                             decimal AV87Listacostoswwds_21_tflistacostosvalor ,
                                             decimal AV88Listacostoswwds_22_tflistacostosvalor_to ,
                                             string AV90Listacostoswwds_24_tflistacostoscc_sel ,
                                             string AV89Listacostoswwds_23_tflistacostoscc ,
                                             int AV91Listacostoswwds_25_tflistacostosestado_sels_Count ,
                                             string A460ListaCostosNombre ,
                                             long A459ListaCostosId ,
                                             long A483TipoCuentaId ,
                                             string A484TipoCuentaNombre ,
                                             decimal A471ListaCostosValor ,
                                             string A485ListaCostosCC ,
                                             short AV17OrderedBy ,
                                             bool AV18OrderedDsc ,
                                             string AV67Listacostoswwds_1_filterfulltext )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int4 = new short[18];
         Object[] GXv_Object5 = new Object[2];
         scmdbuf = "SELECT T1.[ListaCostosCC], T1.[ListaCostosValor], T1.[ListaCostosNombre], T2.[TipoCuentaNombre], T1.[TipoCuentaId], T1.[ListaCostosId], T1.[ListaCostosEstado] FROM ([ListaCostos] T1 LEFT JOIN [TipoCuenta] T2 ON T2.[TipoCuentaId] = T1.[TipoCuentaId])";
         if ( ( StringUtil.StrCmp(AV68Listacostoswwds_2_dynamicfiltersselector1, "LISTACOSTOSNOMBRE") == 0 ) && ( AV69Listacostoswwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Listacostoswwds_4_listacostosnombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[ListaCostosNombre]) like UPPER(@lV70Listacostoswwds_4_listacostosnombre1))");
         }
         else
         {
            GXv_int4[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV68Listacostoswwds_2_dynamicfiltersselector1, "LISTACOSTOSNOMBRE") == 0 ) && ( AV69Listacostoswwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Listacostoswwds_4_listacostosnombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[ListaCostosNombre]) like '%' + UPPER(@lV70Listacostoswwds_4_listacostosnombre1))");
         }
         else
         {
            GXv_int4[1] = 1;
         }
         if ( AV71Listacostoswwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV72Listacostoswwds_6_dynamicfiltersselector2, "LISTACOSTOSNOMBRE") == 0 ) && ( AV73Listacostoswwds_7_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Listacostoswwds_8_listacostosnombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[ListaCostosNombre]) like UPPER(@lV74Listacostoswwds_8_listacostosnombre2))");
         }
         else
         {
            GXv_int4[2] = 1;
         }
         if ( AV71Listacostoswwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV72Listacostoswwds_6_dynamicfiltersselector2, "LISTACOSTOSNOMBRE") == 0 ) && ( AV73Listacostoswwds_7_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Listacostoswwds_8_listacostosnombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[ListaCostosNombre]) like '%' + UPPER(@lV74Listacostoswwds_8_listacostosnombre2))");
         }
         else
         {
            GXv_int4[3] = 1;
         }
         if ( AV75Listacostoswwds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV76Listacostoswwds_10_dynamicfiltersselector3, "LISTACOSTOSNOMBRE") == 0 ) && ( AV77Listacostoswwds_11_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV78Listacostoswwds_12_listacostosnombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[ListaCostosNombre]) like UPPER(@lV78Listacostoswwds_12_listacostosnombre3))");
         }
         else
         {
            GXv_int4[4] = 1;
         }
         if ( AV75Listacostoswwds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV76Listacostoswwds_10_dynamicfiltersselector3, "LISTACOSTOSNOMBRE") == 0 ) && ( AV77Listacostoswwds_11_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV78Listacostoswwds_12_listacostosnombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[ListaCostosNombre]) like '%' + UPPER(@lV78Listacostoswwds_12_listacostosnombre3))");
         }
         else
         {
            GXv_int4[5] = 1;
         }
         if ( ! (0==AV79Listacostoswwds_13_tflistacostosid) )
         {
            AddWhere(sWhereString, "(T1.[ListaCostosId] >= @AV79Listacostoswwds_13_tflistacostosid)");
         }
         else
         {
            GXv_int4[6] = 1;
         }
         if ( ! (0==AV80Listacostoswwds_14_tflistacostosid_to) )
         {
            AddWhere(sWhereString, "(T1.[ListaCostosId] <= @AV80Listacostoswwds_14_tflistacostosid_to)");
         }
         else
         {
            GXv_int4[7] = 1;
         }
         if ( ! (0==AV81Listacostoswwds_15_tftipocuentaid) )
         {
            AddWhere(sWhereString, "(T1.[TipoCuentaId] >= @AV81Listacostoswwds_15_tftipocuentaid)");
         }
         else
         {
            GXv_int4[8] = 1;
         }
         if ( ! (0==AV82Listacostoswwds_16_tftipocuentaid_to) )
         {
            AddWhere(sWhereString, "(T1.[TipoCuentaId] <= @AV82Listacostoswwds_16_tftipocuentaid_to)");
         }
         else
         {
            GXv_int4[9] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV84Listacostoswwds_18_tftipocuentanombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV83Listacostoswwds_17_tftipocuentanombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[TipoCuentaNombre]) like UPPER(@lV83Listacostoswwds_17_tftipocuentanombre))");
         }
         else
         {
            GXv_int4[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV84Listacostoswwds_18_tftipocuentanombre_sel)) && ! ( StringUtil.StrCmp(AV84Listacostoswwds_18_tftipocuentanombre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.[TipoCuentaNombre] = @AV84Listacostoswwds_18_tftipocuentanombre_sel)");
         }
         else
         {
            GXv_int4[11] = 1;
         }
         if ( StringUtil.StrCmp(AV84Listacostoswwds_18_tftipocuentanombre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T2.[TipoCuentaNombre] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV86Listacostoswwds_20_tflistacostosnombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV85Listacostoswwds_19_tflistacostosnombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[ListaCostosNombre]) like UPPER(@lV85Listacostoswwds_19_tflistacostosnombre))");
         }
         else
         {
            GXv_int4[12] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV86Listacostoswwds_20_tflistacostosnombre_sel)) && ! ( StringUtil.StrCmp(AV86Listacostoswwds_20_tflistacostosnombre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[ListaCostosNombre] = @AV86Listacostoswwds_20_tflistacostosnombre_sel)");
         }
         else
         {
            GXv_int4[13] = 1;
         }
         if ( StringUtil.StrCmp(AV86Listacostoswwds_20_tflistacostosnombre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[ListaCostosNombre] = ''))");
         }
         if ( ! (Convert.ToDecimal(0)==AV87Listacostoswwds_21_tflistacostosvalor) )
         {
            AddWhere(sWhereString, "(T1.[ListaCostosValor] >= @AV87Listacostoswwds_21_tflistacostosvalor)");
         }
         else
         {
            GXv_int4[14] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV88Listacostoswwds_22_tflistacostosvalor_to) )
         {
            AddWhere(sWhereString, "(T1.[ListaCostosValor] <= @AV88Listacostoswwds_22_tflistacostosvalor_to)");
         }
         else
         {
            GXv_int4[15] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV90Listacostoswwds_24_tflistacostoscc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV89Listacostoswwds_23_tflistacostoscc)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[ListaCostosCC]) like UPPER(@lV89Listacostoswwds_23_tflistacostoscc))");
         }
         else
         {
            GXv_int4[16] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV90Listacostoswwds_24_tflistacostoscc_sel)) && ! ( StringUtil.StrCmp(AV90Listacostoswwds_24_tflistacostoscc_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[ListaCostosCC] = @AV90Listacostoswwds_24_tflistacostoscc_sel)");
         }
         else
         {
            GXv_int4[17] = 1;
         }
         if ( StringUtil.StrCmp(AV90Listacostoswwds_24_tflistacostoscc_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.[ListaCostosCC] IS NULL or (T1.[ListaCostosCC] = ''))");
         }
         if ( AV91Listacostoswwds_25_tflistacostosestado_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV91Listacostoswwds_25_tflistacostosestado_sels, "T1.[ListaCostosEstado] IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         if ( ( AV17OrderedBy == 1 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[ListaCostosNombre]";
         }
         else if ( ( AV17OrderedBy == 1 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[ListaCostosNombre] DESC";
         }
         else if ( ( AV17OrderedBy == 2 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[ListaCostosId]";
         }
         else if ( ( AV17OrderedBy == 2 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[ListaCostosId] DESC";
         }
         else if ( ( AV17OrderedBy == 3 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[TipoCuentaId]";
         }
         else if ( ( AV17OrderedBy == 3 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[TipoCuentaId] DESC";
         }
         else if ( ( AV17OrderedBy == 4 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T2.[TipoCuentaNombre]";
         }
         else if ( ( AV17OrderedBy == 4 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T2.[TipoCuentaNombre] DESC";
         }
         else if ( ( AV17OrderedBy == 5 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[ListaCostosValor]";
         }
         else if ( ( AV17OrderedBy == 5 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[ListaCostosValor] DESC";
         }
         else if ( ( AV17OrderedBy == 6 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[ListaCostosCC]";
         }
         else if ( ( AV17OrderedBy == 6 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[ListaCostosCC] DESC";
         }
         else if ( ( AV17OrderedBy == 7 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[ListaCostosEstado]";
         }
         else if ( ( AV17OrderedBy == 7 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[ListaCostosEstado] DESC";
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
                     return conditional_P00632(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (bool)dynConstraints[5] , (string)dynConstraints[6] , (short)dynConstraints[7] , (string)dynConstraints[8] , (bool)dynConstraints[9] , (string)dynConstraints[10] , (short)dynConstraints[11] , (string)dynConstraints[12] , (long)dynConstraints[13] , (long)dynConstraints[14] , (long)dynConstraints[15] , (long)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (decimal)dynConstraints[21] , (decimal)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (int)dynConstraints[25] , (string)dynConstraints[26] , (long)dynConstraints[27] , (long)dynConstraints[28] , (string)dynConstraints[29] , (decimal)dynConstraints[30] , (string)dynConstraints[31] , (short)dynConstraints[32] , (bool)dynConstraints[33] , (string)dynConstraints[34] );
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
          Object[] prmP00632;
          prmP00632 = new Object[] {
          new ParDef("@lV70Listacostoswwds_4_listacostosnombre1",GXType.Char,80,0) ,
          new ParDef("@lV70Listacostoswwds_4_listacostosnombre1",GXType.Char,80,0) ,
          new ParDef("@lV74Listacostoswwds_8_listacostosnombre2",GXType.Char,80,0) ,
          new ParDef("@lV74Listacostoswwds_8_listacostosnombre2",GXType.Char,80,0) ,
          new ParDef("@lV78Listacostoswwds_12_listacostosnombre3",GXType.Char,80,0) ,
          new ParDef("@lV78Listacostoswwds_12_listacostosnombre3",GXType.Char,80,0) ,
          new ParDef("@AV79Listacostoswwds_13_tflistacostosid",GXType.Decimal,18,0) ,
          new ParDef("@AV80Listacostoswwds_14_tflistacostosid_to",GXType.Decimal,18,0) ,
          new ParDef("@AV81Listacostoswwds_15_tftipocuentaid",GXType.Decimal,18,0) ,
          new ParDef("@AV82Listacostoswwds_16_tftipocuentaid_to",GXType.Decimal,18,0) ,
          new ParDef("@lV83Listacostoswwds_17_tftipocuentanombre",GXType.Char,120,0) ,
          new ParDef("@AV84Listacostoswwds_18_tftipocuentanombre_sel",GXType.NChar,120,0) ,
          new ParDef("@lV85Listacostoswwds_19_tflistacostosnombre",GXType.Char,80,0) ,
          new ParDef("@AV86Listacostoswwds_20_tflistacostosnombre_sel",GXType.NChar,80,0) ,
          new ParDef("@AV87Listacostoswwds_21_tflistacostosvalor",GXType.Decimal,18,2) ,
          new ParDef("@AV88Listacostoswwds_22_tflistacostosvalor_to",GXType.Decimal,18,2) ,
          new ParDef("@lV89Listacostoswwds_23_tflistacostoscc",GXType.Char,35,0) ,
          new ParDef("@AV90Listacostoswwds_24_tflistacostoscc_sel",GXType.NChar,35,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00632", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00632,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[0])[0] = rslt.getString(1, 35);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((decimal[]) buf[2])[0] = rslt.getDecimal(2);
                ((string[]) buf[3])[0] = rslt.getString(3, 80);
                ((string[]) buf[4])[0] = rslt.getString(4, 120);
                ((long[]) buf[5])[0] = rslt.getLong(5);
                ((bool[]) buf[6])[0] = rslt.wasNull(5);
                ((long[]) buf[7])[0] = rslt.getLong(6);
                ((string[]) buf[8])[0] = rslt.getString(7, 3);
                return;
       }
    }

 }

}

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
   public class metodopagoswwexport : GXProcedure
   {
      public metodopagoswwexport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public metodopagoswwexport( IGxContext context )
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
         new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWMetodoPagos", out  GXt_boolean1) ;
         AV8IsAuthorized = GXt_boolean1;
         if ( ! AV8IsAuthorized )
         {
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "wwpbaseobjects.notauthorized.aspx"+GXUtil.UrlEncode(StringUtil.RTrim(AV57Pgmname));
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
         AV12Filename = GXt_char2 + "MetodoPagosWWExport-" + StringUtil.Trim( StringUtil.Str( (decimal)(AV16Random), 8, 0)) + ".xlsx";
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
         if ( AV37GridState.gxTpr_Dynamicfilters.Count >= 1 )
         {
            AV34GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV37GridState.gxTpr_Dynamicfilters.Item(1));
            AV20DynamicFiltersSelector1 = AV34GridStateDynamicFilter.gxTpr_Selected;
            if ( StringUtil.StrCmp(AV20DynamicFiltersSelector1, "METODOPAGOSNOMBRE") == 0 )
            {
               AV21DynamicFiltersOperator1 = AV34GridStateDynamicFilter.gxTpr_Operator;
               AV22MetodoPagosNombre1 = AV34GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV22MetodoPagosNombre1)) )
               {
                  AV14CellRow = (int)(AV14CellRow+1);
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Bold = 1;
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Color = 3;
                  if ( AV21DynamicFiltersOperator1 == 0 )
                  {
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", context.GetMessage( "Metodo", ""), context.GetMessage( "WWP_FilterLike", ""), "", "", "", "", "", "", "");
                  }
                  else if ( AV21DynamicFiltersOperator1 == 1 )
                  {
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", context.GetMessage( "Metodo", ""), context.GetMessage( "WWP_FilterContains", ""), "", "", "", "", "", "", "");
                  }
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Italic = 1;
                  GXt_char2 = "";
                  new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV22MetodoPagosNombre1, out  GXt_char2) ;
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
               }
            }
            else if ( StringUtil.StrCmp(AV20DynamicFiltersSelector1, "ESTADOSGENERICOSNOMBRE") == 0 )
            {
               AV21DynamicFiltersOperator1 = AV34GridStateDynamicFilter.gxTpr_Operator;
               AV23EstadosGenericosNombre1 = AV34GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV23EstadosGenericosNombre1)) )
               {
                  AV14CellRow = (int)(AV14CellRow+1);
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Bold = 1;
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Color = 3;
                  if ( AV21DynamicFiltersOperator1 == 0 )
                  {
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", context.GetMessage( "Estado", ""), context.GetMessage( "WWP_FilterLike", ""), "", "", "", "", "", "", "");
                  }
                  else if ( AV21DynamicFiltersOperator1 == 1 )
                  {
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", context.GetMessage( "Estado", ""), context.GetMessage( "WWP_FilterContains", ""), "", "", "", "", "", "", "");
                  }
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Italic = 1;
                  GXt_char2 = "";
                  new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV23EstadosGenericosNombre1, out  GXt_char2) ;
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
               }
            }
            if ( AV37GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV24DynamicFiltersEnabled2 = true;
               AV34GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV37GridState.gxTpr_Dynamicfilters.Item(2));
               AV25DynamicFiltersSelector2 = AV34GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV25DynamicFiltersSelector2, "METODOPAGOSNOMBRE") == 0 )
               {
                  AV26DynamicFiltersOperator2 = AV34GridStateDynamicFilter.gxTpr_Operator;
                  AV27MetodoPagosNombre2 = AV34GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV27MetodoPagosNombre2)) )
                  {
                     AV14CellRow = (int)(AV14CellRow+1);
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Bold = 1;
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Color = 3;
                     if ( AV26DynamicFiltersOperator2 == 0 )
                     {
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", context.GetMessage( "Metodo", ""), context.GetMessage( "WWP_FilterLike", ""), "", "", "", "", "", "", "");
                     }
                     else if ( AV26DynamicFiltersOperator2 == 1 )
                     {
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", context.GetMessage( "Metodo", ""), context.GetMessage( "WWP_FilterContains", ""), "", "", "", "", "", "", "");
                     }
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Italic = 1;
                     GXt_char2 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV27MetodoPagosNombre2, out  GXt_char2) ;
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
                  }
               }
               else if ( StringUtil.StrCmp(AV25DynamicFiltersSelector2, "ESTADOSGENERICOSNOMBRE") == 0 )
               {
                  AV26DynamicFiltersOperator2 = AV34GridStateDynamicFilter.gxTpr_Operator;
                  AV28EstadosGenericosNombre2 = AV34GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV28EstadosGenericosNombre2)) )
                  {
                     AV14CellRow = (int)(AV14CellRow+1);
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Bold = 1;
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Color = 3;
                     if ( AV26DynamicFiltersOperator2 == 0 )
                     {
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", context.GetMessage( "Estado", ""), context.GetMessage( "WWP_FilterLike", ""), "", "", "", "", "", "", "");
                     }
                     else if ( AV26DynamicFiltersOperator2 == 1 )
                     {
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", context.GetMessage( "Estado", ""), context.GetMessage( "WWP_FilterContains", ""), "", "", "", "", "", "", "");
                     }
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Italic = 1;
                     GXt_char2 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV28EstadosGenericosNombre2, out  GXt_char2) ;
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
                  }
               }
               if ( AV37GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV29DynamicFiltersEnabled3 = true;
                  AV34GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV37GridState.gxTpr_Dynamicfilters.Item(3));
                  AV30DynamicFiltersSelector3 = AV34GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV30DynamicFiltersSelector3, "METODOPAGOSNOMBRE") == 0 )
                  {
                     AV31DynamicFiltersOperator3 = AV34GridStateDynamicFilter.gxTpr_Operator;
                     AV32MetodoPagosNombre3 = AV34GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV32MetodoPagosNombre3)) )
                     {
                        AV14CellRow = (int)(AV14CellRow+1);
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Bold = 1;
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Color = 3;
                        if ( AV31DynamicFiltersOperator3 == 0 )
                        {
                           AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", context.GetMessage( "Metodo", ""), context.GetMessage( "WWP_FilterLike", ""), "", "", "", "", "", "", "");
                        }
                        else if ( AV31DynamicFiltersOperator3 == 1 )
                        {
                           AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", context.GetMessage( "Metodo", ""), context.GetMessage( "WWP_FilterContains", ""), "", "", "", "", "", "", "");
                        }
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Italic = 1;
                        GXt_char2 = "";
                        new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV32MetodoPagosNombre3, out  GXt_char2) ;
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
                     }
                  }
                  else if ( StringUtil.StrCmp(AV30DynamicFiltersSelector3, "ESTADOSGENERICOSNOMBRE") == 0 )
                  {
                     AV31DynamicFiltersOperator3 = AV34GridStateDynamicFilter.gxTpr_Operator;
                     AV33EstadosGenericosNombre3 = AV34GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV33EstadosGenericosNombre3)) )
                     {
                        AV14CellRow = (int)(AV14CellRow+1);
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Bold = 1;
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Color = 3;
                        if ( AV31DynamicFiltersOperator3 == 0 )
                        {
                           AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", context.GetMessage( "Estado", ""), context.GetMessage( "WWP_FilterLike", ""), "", "", "", "", "", "", "");
                        }
                        else if ( AV31DynamicFiltersOperator3 == 1 )
                        {
                           AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", context.GetMessage( "Estado", ""), context.GetMessage( "WWP_FilterContains", ""), "", "", "", "", "", "", "");
                        }
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Italic = 1;
                        GXt_char2 = "";
                        new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV33EstadosGenericosNombre3, out  GXt_char2) ;
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
                     }
                  }
               }
            }
         }
         if ( ! ( (0==AV50TFMetodoPagosID) && (0==AV51TFMetodoPagosID_To) ) )
         {
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Id", "")) ;
            AV14CellRow = GXt_int3;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Number = AV50TFMetodoPagosID;
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  false, ref  GXt_int3,  (short)(AV15FirstColumn+2),  context.GetMessage( "WWP_TSTo", "")) ;
            AV14CellRow = GXt_int3;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+3, 1, 1).Number = AV51TFMetodoPagosID_To;
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV53TFMetodoPagosNombre_Sel)) ) )
         {
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Metodo", "")) ;
            AV14CellRow = GXt_int3;
            GXt_char2 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV53TFMetodoPagosNombre_Sel)) ? context.GetMessage( "WWP_TitleFilter_EmptyOption", "") : AV53TFMetodoPagosNombre_Sel), out  GXt_char2) ;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV52TFMetodoPagosNombre)) ) )
            {
               GXt_int3 = (short)(AV14CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Metodo", "")) ;
               AV14CellRow = GXt_int3;
               GXt_char2 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV52TFMetodoPagosNombre, out  GXt_char2) ;
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV55TFMetodoPagosCodigo_Sel)) ) )
         {
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Codigo", "")) ;
            AV14CellRow = GXt_int3;
            GXt_char2 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV55TFMetodoPagosCodigo_Sel)) ? context.GetMessage( "WWP_TitleFilter_EmptyOption", "") : StringUtil.Substring( AV55TFMetodoPagosCodigo_Sel, 1, 1000)), out  GXt_char2) ;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV54TFMetodoPagosCodigo)) ) )
            {
               GXt_int3 = (short)(AV14CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Codigo", "")) ;
               AV14CellRow = GXt_int3;
               GXt_char2 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  StringUtil.Substring( AV54TFMetodoPagosCodigo, 1, 1000), out  GXt_char2) ;
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
            }
         }
         AV14CellRow = (int)(AV14CellRow+2);
      }

      protected void S141( )
      {
         /* 'WRITECOLUMNTITLES' Routine */
         returnInSub = false;
         AV47VisibleColumnCount = 0;
         if ( StringUtil.StrCmp(AV35Session.Get("MetodoPagosWWColumnsSelector"), "") != 0 )
         {
            AV42ColumnsSelectorXML = AV35Session.Get("MetodoPagosWWColumnsSelector");
            AV39ColumnsSelector.FromXml(AV42ColumnsSelectorXML, null, "", "");
         }
         else
         {
            /* Execute user subroutine: 'INITIALIZECOLUMNSSELECTOR' */
            S151 ();
            if (returnInSub) return;
         }
         AV39ColumnsSelector.gxTpr_Columns.Sort("Order");
         AV58GXV1 = 1;
         while ( AV58GXV1 <= AV39ColumnsSelector.gxTpr_Columns.Count )
         {
            AV41ColumnsSelector_Column = ((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV39ColumnsSelector.gxTpr_Columns.Item(AV58GXV1));
            if ( AV41ColumnsSelector_Column.gxTpr_Isvisible )
            {
               AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV47VisibleColumnCount), 1, 1).Text = context.GetMessage( (String.IsNullOrEmpty(StringUtil.RTrim( AV41ColumnsSelector_Column.gxTpr_Displayname)) ? AV41ColumnsSelector_Column.gxTpr_Columnname : AV41ColumnsSelector_Column.gxTpr_Displayname), "");
               AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV47VisibleColumnCount), 1, 1).Bold = 1;
               AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV47VisibleColumnCount), 1, 1).Color = 11;
               AV47VisibleColumnCount = (long)(AV47VisibleColumnCount+1);
            }
            AV58GXV1 = (int)(AV58GXV1+1);
         }
      }

      protected void S161( )
      {
         /* 'WRITEDATA' Routine */
         returnInSub = false;
         AV60Metodopagoswwds_1_filterfulltext = AV19FilterFullText;
         AV61Metodopagoswwds_2_dynamicfiltersselector1 = AV20DynamicFiltersSelector1;
         AV62Metodopagoswwds_3_dynamicfiltersoperator1 = AV21DynamicFiltersOperator1;
         AV63Metodopagoswwds_4_metodopagosnombre1 = AV22MetodoPagosNombre1;
         AV64Metodopagoswwds_5_estadosgenericosnombre1 = AV23EstadosGenericosNombre1;
         AV65Metodopagoswwds_6_dynamicfiltersenabled2 = AV24DynamicFiltersEnabled2;
         AV66Metodopagoswwds_7_dynamicfiltersselector2 = AV25DynamicFiltersSelector2;
         AV67Metodopagoswwds_8_dynamicfiltersoperator2 = AV26DynamicFiltersOperator2;
         AV68Metodopagoswwds_9_metodopagosnombre2 = AV27MetodoPagosNombre2;
         AV69Metodopagoswwds_10_estadosgenericosnombre2 = AV28EstadosGenericosNombre2;
         AV70Metodopagoswwds_11_dynamicfiltersenabled3 = AV29DynamicFiltersEnabled3;
         AV71Metodopagoswwds_12_dynamicfiltersselector3 = AV30DynamicFiltersSelector3;
         AV72Metodopagoswwds_13_dynamicfiltersoperator3 = AV31DynamicFiltersOperator3;
         AV73Metodopagoswwds_14_metodopagosnombre3 = AV32MetodoPagosNombre3;
         AV74Metodopagoswwds_15_estadosgenericosnombre3 = AV33EstadosGenericosNombre3;
         AV75Metodopagoswwds_16_tfmetodopagosid = AV50TFMetodoPagosID;
         AV76Metodopagoswwds_17_tfmetodopagosid_to = AV51TFMetodoPagosID_To;
         AV77Metodopagoswwds_18_tfmetodopagosnombre = AV52TFMetodoPagosNombre;
         AV78Metodopagoswwds_19_tfmetodopagosnombre_sel = AV53TFMetodoPagosNombre_Sel;
         AV79Metodopagoswwds_20_tfmetodopagoscodigo = AV54TFMetodoPagosCodigo;
         AV80Metodopagoswwds_21_tfmetodopagoscodigo_sel = AV55TFMetodoPagosCodigo_Sel;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV60Metodopagoswwds_1_filterfulltext ,
                                              AV61Metodopagoswwds_2_dynamicfiltersselector1 ,
                                              AV62Metodopagoswwds_3_dynamicfiltersoperator1 ,
                                              AV63Metodopagoswwds_4_metodopagosnombre1 ,
                                              AV64Metodopagoswwds_5_estadosgenericosnombre1 ,
                                              AV65Metodopagoswwds_6_dynamicfiltersenabled2 ,
                                              AV66Metodopagoswwds_7_dynamicfiltersselector2 ,
                                              AV67Metodopagoswwds_8_dynamicfiltersoperator2 ,
                                              AV68Metodopagoswwds_9_metodopagosnombre2 ,
                                              AV69Metodopagoswwds_10_estadosgenericosnombre2 ,
                                              AV70Metodopagoswwds_11_dynamicfiltersenabled3 ,
                                              AV71Metodopagoswwds_12_dynamicfiltersselector3 ,
                                              AV72Metodopagoswwds_13_dynamicfiltersoperator3 ,
                                              AV73Metodopagoswwds_14_metodopagosnombre3 ,
                                              AV74Metodopagoswwds_15_estadosgenericosnombre3 ,
                                              AV75Metodopagoswwds_16_tfmetodopagosid ,
                                              AV76Metodopagoswwds_17_tfmetodopagosid_to ,
                                              AV78Metodopagoswwds_19_tfmetodopagosnombre_sel ,
                                              AV77Metodopagoswwds_18_tfmetodopagosnombre ,
                                              AV80Metodopagoswwds_21_tfmetodopagoscodigo_sel ,
                                              AV79Metodopagoswwds_20_tfmetodopagoscodigo ,
                                              A128MetodoPagosID ,
                                              A129MetodoPagosNombre ,
                                              A214MetodoPagosCodigo ,
                                              A109EstadosGenericosNombre ,
                                              AV17OrderedBy ,
                                              AV18OrderedDsc } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV60Metodopagoswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV60Metodopagoswwds_1_filterfulltext), "%", "");
         lV60Metodopagoswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV60Metodopagoswwds_1_filterfulltext), "%", "");
         lV60Metodopagoswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV60Metodopagoswwds_1_filterfulltext), "%", "");
         lV63Metodopagoswwds_4_metodopagosnombre1 = StringUtil.PadR( StringUtil.RTrim( AV63Metodopagoswwds_4_metodopagosnombre1), 80, "%");
         lV63Metodopagoswwds_4_metodopagosnombre1 = StringUtil.PadR( StringUtil.RTrim( AV63Metodopagoswwds_4_metodopagosnombre1), 80, "%");
         lV64Metodopagoswwds_5_estadosgenericosnombre1 = StringUtil.PadR( StringUtil.RTrim( AV64Metodopagoswwds_5_estadosgenericosnombre1), 80, "%");
         lV64Metodopagoswwds_5_estadosgenericosnombre1 = StringUtil.PadR( StringUtil.RTrim( AV64Metodopagoswwds_5_estadosgenericosnombre1), 80, "%");
         lV68Metodopagoswwds_9_metodopagosnombre2 = StringUtil.PadR( StringUtil.RTrim( AV68Metodopagoswwds_9_metodopagosnombre2), 80, "%");
         lV68Metodopagoswwds_9_metodopagosnombre2 = StringUtil.PadR( StringUtil.RTrim( AV68Metodopagoswwds_9_metodopagosnombre2), 80, "%");
         lV69Metodopagoswwds_10_estadosgenericosnombre2 = StringUtil.PadR( StringUtil.RTrim( AV69Metodopagoswwds_10_estadosgenericosnombre2), 80, "%");
         lV69Metodopagoswwds_10_estadosgenericosnombre2 = StringUtil.PadR( StringUtil.RTrim( AV69Metodopagoswwds_10_estadosgenericosnombre2), 80, "%");
         lV73Metodopagoswwds_14_metodopagosnombre3 = StringUtil.PadR( StringUtil.RTrim( AV73Metodopagoswwds_14_metodopagosnombre3), 80, "%");
         lV73Metodopagoswwds_14_metodopagosnombre3 = StringUtil.PadR( StringUtil.RTrim( AV73Metodopagoswwds_14_metodopagosnombre3), 80, "%");
         lV74Metodopagoswwds_15_estadosgenericosnombre3 = StringUtil.PadR( StringUtil.RTrim( AV74Metodopagoswwds_15_estadosgenericosnombre3), 80, "%");
         lV74Metodopagoswwds_15_estadosgenericosnombre3 = StringUtil.PadR( StringUtil.RTrim( AV74Metodopagoswwds_15_estadosgenericosnombre3), 80, "%");
         lV77Metodopagoswwds_18_tfmetodopagosnombre = StringUtil.PadR( StringUtil.RTrim( AV77Metodopagoswwds_18_tfmetodopagosnombre), 80, "%");
         lV79Metodopagoswwds_20_tfmetodopagoscodigo = StringUtil.Concat( StringUtil.RTrim( AV79Metodopagoswwds_20_tfmetodopagoscodigo), "%", "");
         /* Using cursor P004L2 */
         pr_default.execute(0, new Object[] {lV60Metodopagoswwds_1_filterfulltext, lV60Metodopagoswwds_1_filterfulltext, lV60Metodopagoswwds_1_filterfulltext, lV63Metodopagoswwds_4_metodopagosnombre1, lV63Metodopagoswwds_4_metodopagosnombre1, lV64Metodopagoswwds_5_estadosgenericosnombre1, lV64Metodopagoswwds_5_estadosgenericosnombre1, lV68Metodopagoswwds_9_metodopagosnombre2, lV68Metodopagoswwds_9_metodopagosnombre2, lV69Metodopagoswwds_10_estadosgenericosnombre2, lV69Metodopagoswwds_10_estadosgenericosnombre2, lV73Metodopagoswwds_14_metodopagosnombre3, lV73Metodopagoswwds_14_metodopagosnombre3, lV74Metodopagoswwds_15_estadosgenericosnombre3, lV74Metodopagoswwds_15_estadosgenericosnombre3, AV75Metodopagoswwds_16_tfmetodopagosid, AV76Metodopagoswwds_17_tfmetodopagosid_to, lV77Metodopagoswwds_18_tfmetodopagosnombre, AV78Metodopagoswwds_19_tfmetodopagosnombre_sel, lV79Metodopagoswwds_20_tfmetodopagoscodigo, AV80Metodopagoswwds_21_tfmetodopagoscodigo_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A107EstadosTipo = P004L2_A107EstadosTipo[0];
            A108EstadosGenericosId = P004L2_A108EstadosGenericosId[0];
            A109EstadosGenericosNombre = P004L2_A109EstadosGenericosNombre[0];
            A214MetodoPagosCodigo = P004L2_A214MetodoPagosCodigo[0];
            A129MetodoPagosNombre = P004L2_A129MetodoPagosNombre[0];
            A128MetodoPagosID = P004L2_A128MetodoPagosID[0];
            A109EstadosGenericosNombre = P004L2_A109EstadosGenericosNombre[0];
            AV14CellRow = (int)(AV14CellRow+1);
            /* Execute user subroutine: 'BEFOREWRITELINE' */
            S172 ();
            if ( returnInSub )
            {
               pr_default.close(0);
               returnInSub = true;
               if (true) return;
            }
            AV47VisibleColumnCount = 0;
            AV81GXV2 = 1;
            while ( AV81GXV2 <= AV39ColumnsSelector.gxTpr_Columns.Count )
            {
               AV41ColumnsSelector_Column = ((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV39ColumnsSelector.gxTpr_Columns.Item(AV81GXV2));
               if ( AV41ColumnsSelector_Column.gxTpr_Isvisible )
               {
                  if ( StringUtil.StrCmp(AV41ColumnsSelector_Column.gxTpr_Columnname, "MetodoPagosID") == 0 )
                  {
                     AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV47VisibleColumnCount), 1, 1).Number = A128MetodoPagosID;
                  }
                  else if ( StringUtil.StrCmp(AV41ColumnsSelector_Column.gxTpr_Columnname, "MetodoPagosNombre") == 0 )
                  {
                     GXt_char2 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A129MetodoPagosNombre, out  GXt_char2) ;
                     AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV47VisibleColumnCount), 1, 1).Text = GXt_char2;
                  }
                  else if ( StringUtil.StrCmp(AV41ColumnsSelector_Column.gxTpr_Columnname, "MetodoPagosLogo") == 0 )
                  {
                     AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV47VisibleColumnCount), 1, 1).Text = "";
                  }
                  else if ( StringUtil.StrCmp(AV41ColumnsSelector_Column.gxTpr_Columnname, "MetodoPagosCodigo") == 0 )
                  {
                     GXt_char2 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  StringUtil.Substring( A214MetodoPagosCodigo, 1, 1000), out  GXt_char2) ;
                     AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV47VisibleColumnCount), 1, 1).Text = GXt_char2;
                  }
                  AV47VisibleColumnCount = (long)(AV47VisibleColumnCount+1);
               }
               AV81GXV2 = (int)(AV81GXV2+1);
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
         AV35Session.Set("WWPExportFilePath", AV12Filename);
         AV35Session.Set("WWPExportFileName", "MetodoPagosWWExport.xlsx");
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
         AV39ColumnsSelector = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector(context);
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV39ColumnsSelector,  "MetodoPagosID",  "",  "Id",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV39ColumnsSelector,  "MetodoPagosNombre",  "",  "Metodo",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV39ColumnsSelector,  "MetodoPagosLogo",  "",  "Logo",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV39ColumnsSelector,  "MetodoPagosCodigo",  "",  "Codigo",  true,  "") ;
         GXt_char2 = AV43UserCustomValue;
         new GeneXus.Programs.wwpbaseobjects.loadcolumnsselectorstate(context ).execute(  "MetodoPagosWWColumnsSelector", out  GXt_char2) ;
         AV43UserCustomValue = GXt_char2;
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV43UserCustomValue)) ) )
         {
            AV40ColumnsSelectorAux.FromXml(AV43UserCustomValue, null, "", "");
            new GeneXus.Programs.wwpbaseobjects.wwp_columnselector_updatecolumns(context ).execute( ref  AV40ColumnsSelectorAux, ref  AV39ColumnsSelector) ;
         }
      }

      protected void S201( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV35Session.Get("MetodoPagosWWGridState"), "") == 0 )
         {
            AV37GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "MetodoPagosWWGridState"), null, "", "");
         }
         else
         {
            AV37GridState.FromXml(AV35Session.Get("MetodoPagosWWGridState"), null, "", "");
         }
         AV17OrderedBy = AV37GridState.gxTpr_Orderedby;
         AV18OrderedDsc = AV37GridState.gxTpr_Ordereddsc;
         AV82GXV3 = 1;
         while ( AV82GXV3 <= AV37GridState.gxTpr_Filtervalues.Count )
         {
            AV38GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV37GridState.gxTpr_Filtervalues.Item(AV82GXV3));
            if ( StringUtil.StrCmp(AV38GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV19FilterFullText = AV38GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV38GridStateFilterValue.gxTpr_Name, "TFMETODOPAGOSID") == 0 )
            {
               AV50TFMetodoPagosID = (long)(Math.Round(NumberUtil.Val( AV38GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV51TFMetodoPagosID_To = (long)(Math.Round(NumberUtil.Val( AV38GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV38GridStateFilterValue.gxTpr_Name, "TFMETODOPAGOSNOMBRE") == 0 )
            {
               AV52TFMetodoPagosNombre = AV38GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV38GridStateFilterValue.gxTpr_Name, "TFMETODOPAGOSNOMBRE_SEL") == 0 )
            {
               AV53TFMetodoPagosNombre_Sel = AV38GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV38GridStateFilterValue.gxTpr_Name, "TFMETODOPAGOSCODIGO") == 0 )
            {
               AV54TFMetodoPagosCodigo = AV38GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV38GridStateFilterValue.gxTpr_Name, "TFMETODOPAGOSCODIGO_SEL") == 0 )
            {
               AV55TFMetodoPagosCodigo_Sel = AV38GridStateFilterValue.gxTpr_Value;
            }
            AV82GXV3 = (int)(AV82GXV3+1);
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
         AV57Pgmname = "";
         GXKey = "";
         GXEncryptionTmp = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV11ExcelDocument = new ExcelDocumentI();
         AV19FilterFullText = "";
         AV37GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV34GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV20DynamicFiltersSelector1 = "";
         AV22MetodoPagosNombre1 = "";
         AV23EstadosGenericosNombre1 = "";
         AV25DynamicFiltersSelector2 = "";
         AV27MetodoPagosNombre2 = "";
         AV28EstadosGenericosNombre2 = "";
         AV30DynamicFiltersSelector3 = "";
         AV32MetodoPagosNombre3 = "";
         AV33EstadosGenericosNombre3 = "";
         AV53TFMetodoPagosNombre_Sel = "";
         AV52TFMetodoPagosNombre = "";
         AV55TFMetodoPagosCodigo_Sel = "";
         AV54TFMetodoPagosCodigo = "";
         AV35Session = context.GetSession();
         AV42ColumnsSelectorXML = "";
         AV39ColumnsSelector = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector(context);
         AV41ColumnsSelector_Column = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column(context);
         AV60Metodopagoswwds_1_filterfulltext = "";
         AV61Metodopagoswwds_2_dynamicfiltersselector1 = "";
         AV63Metodopagoswwds_4_metodopagosnombre1 = "";
         AV64Metodopagoswwds_5_estadosgenericosnombre1 = "";
         AV66Metodopagoswwds_7_dynamicfiltersselector2 = "";
         AV68Metodopagoswwds_9_metodopagosnombre2 = "";
         AV69Metodopagoswwds_10_estadosgenericosnombre2 = "";
         AV71Metodopagoswwds_12_dynamicfiltersselector3 = "";
         AV73Metodopagoswwds_14_metodopagosnombre3 = "";
         AV74Metodopagoswwds_15_estadosgenericosnombre3 = "";
         AV77Metodopagoswwds_18_tfmetodopagosnombre = "";
         AV78Metodopagoswwds_19_tfmetodopagosnombre_sel = "";
         AV79Metodopagoswwds_20_tfmetodopagoscodigo = "";
         AV80Metodopagoswwds_21_tfmetodopagoscodigo_sel = "";
         lV60Metodopagoswwds_1_filterfulltext = "";
         lV63Metodopagoswwds_4_metodopagosnombre1 = "";
         lV64Metodopagoswwds_5_estadosgenericosnombre1 = "";
         lV68Metodopagoswwds_9_metodopagosnombre2 = "";
         lV69Metodopagoswwds_10_estadosgenericosnombre2 = "";
         lV73Metodopagoswwds_14_metodopagosnombre3 = "";
         lV74Metodopagoswwds_15_estadosgenericosnombre3 = "";
         lV77Metodopagoswwds_18_tfmetodopagosnombre = "";
         lV79Metodopagoswwds_20_tfmetodopagoscodigo = "";
         A129MetodoPagosNombre = "";
         A214MetodoPagosCodigo = "";
         A109EstadosGenericosNombre = "";
         P004L2_A107EstadosTipo = new string[] {""} ;
         P004L2_A108EstadosGenericosId = new int[1] ;
         P004L2_A109EstadosGenericosNombre = new string[] {""} ;
         P004L2_A214MetodoPagosCodigo = new string[] {""} ;
         P004L2_A129MetodoPagosNombre = new string[] {""} ;
         P004L2_A128MetodoPagosID = new long[1] ;
         A107EstadosTipo = "";
         AV43UserCustomValue = "";
         GXt_char2 = "";
         AV40ColumnsSelectorAux = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector(context);
         AV38GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.metodopagoswwexport__default(),
            new Object[][] {
                new Object[] {
               P004L2_A107EstadosTipo, P004L2_A108EstadosGenericosId, P004L2_A109EstadosGenericosNombre, P004L2_A214MetodoPagosCodigo, P004L2_A129MetodoPagosNombre, P004L2_A128MetodoPagosID
               }
            }
         );
         AV57Pgmname = "MetodoPagosWWExport";
         /* GeneXus formulas. */
         AV57Pgmname = "MetodoPagosWWExport";
      }

      private short AV21DynamicFiltersOperator1 ;
      private short AV26DynamicFiltersOperator2 ;
      private short AV31DynamicFiltersOperator3 ;
      private short GXt_int3 ;
      private short AV62Metodopagoswwds_3_dynamicfiltersoperator1 ;
      private short AV67Metodopagoswwds_8_dynamicfiltersoperator2 ;
      private short AV72Metodopagoswwds_13_dynamicfiltersoperator3 ;
      private short AV17OrderedBy ;
      private int AV14CellRow ;
      private int AV15FirstColumn ;
      private int AV16Random ;
      private int AV58GXV1 ;
      private int A108EstadosGenericosId ;
      private int AV81GXV2 ;
      private int AV82GXV3 ;
      private long AV50TFMetodoPagosID ;
      private long AV51TFMetodoPagosID_To ;
      private long AV47VisibleColumnCount ;
      private long AV75Metodopagoswwds_16_tfmetodopagosid ;
      private long AV76Metodopagoswwds_17_tfmetodopagosid_to ;
      private long A128MetodoPagosID ;
      private string AV57Pgmname ;
      private string GXKey ;
      private string GXEncryptionTmp ;
      private string AV22MetodoPagosNombre1 ;
      private string AV23EstadosGenericosNombre1 ;
      private string AV27MetodoPagosNombre2 ;
      private string AV28EstadosGenericosNombre2 ;
      private string AV32MetodoPagosNombre3 ;
      private string AV33EstadosGenericosNombre3 ;
      private string AV53TFMetodoPagosNombre_Sel ;
      private string AV52TFMetodoPagosNombre ;
      private string AV63Metodopagoswwds_4_metodopagosnombre1 ;
      private string AV64Metodopagoswwds_5_estadosgenericosnombre1 ;
      private string AV68Metodopagoswwds_9_metodopagosnombre2 ;
      private string AV69Metodopagoswwds_10_estadosgenericosnombre2 ;
      private string AV73Metodopagoswwds_14_metodopagosnombre3 ;
      private string AV74Metodopagoswwds_15_estadosgenericosnombre3 ;
      private string AV77Metodopagoswwds_18_tfmetodopagosnombre ;
      private string AV78Metodopagoswwds_19_tfmetodopagosnombre_sel ;
      private string lV63Metodopagoswwds_4_metodopagosnombre1 ;
      private string lV64Metodopagoswwds_5_estadosgenericosnombre1 ;
      private string lV68Metodopagoswwds_9_metodopagosnombre2 ;
      private string lV69Metodopagoswwds_10_estadosgenericosnombre2 ;
      private string lV73Metodopagoswwds_14_metodopagosnombre3 ;
      private string lV74Metodopagoswwds_15_estadosgenericosnombre3 ;
      private string lV77Metodopagoswwds_18_tfmetodopagosnombre ;
      private string A129MetodoPagosNombre ;
      private string A109EstadosGenericosNombre ;
      private string A107EstadosTipo ;
      private string GXt_char2 ;
      private bool AV8IsAuthorized ;
      private bool GXt_boolean1 ;
      private bool returnInSub ;
      private bool AV24DynamicFiltersEnabled2 ;
      private bool AV29DynamicFiltersEnabled3 ;
      private bool AV65Metodopagoswwds_6_dynamicfiltersenabled2 ;
      private bool AV70Metodopagoswwds_11_dynamicfiltersenabled3 ;
      private bool AV18OrderedDsc ;
      private string AV42ColumnsSelectorXML ;
      private string A214MetodoPagosCodigo ;
      private string AV43UserCustomValue ;
      private string AV12Filename ;
      private string AV13ErrorMessage ;
      private string AV19FilterFullText ;
      private string AV20DynamicFiltersSelector1 ;
      private string AV25DynamicFiltersSelector2 ;
      private string AV30DynamicFiltersSelector3 ;
      private string AV55TFMetodoPagosCodigo_Sel ;
      private string AV54TFMetodoPagosCodigo ;
      private string AV60Metodopagoswwds_1_filterfulltext ;
      private string AV61Metodopagoswwds_2_dynamicfiltersselector1 ;
      private string AV66Metodopagoswwds_7_dynamicfiltersselector2 ;
      private string AV71Metodopagoswwds_12_dynamicfiltersselector3 ;
      private string AV79Metodopagoswwds_20_tfmetodopagoscodigo ;
      private string AV80Metodopagoswwds_21_tfmetodopagoscodigo_sel ;
      private string lV60Metodopagoswwds_1_filterfulltext ;
      private string lV79Metodopagoswwds_20_tfmetodopagoscodigo ;
      private IGxSession AV35Session ;
      private ExcelDocumentI AV11ExcelDocument ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV37GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV34GridStateDynamicFilter ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector AV39ColumnsSelector ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column AV41ColumnsSelector_Column ;
      private IDataStoreProvider pr_default ;
      private string[] P004L2_A107EstadosTipo ;
      private int[] P004L2_A108EstadosGenericosId ;
      private string[] P004L2_A109EstadosGenericosNombre ;
      private string[] P004L2_A214MetodoPagosCodigo ;
      private string[] P004L2_A129MetodoPagosNombre ;
      private long[] P004L2_A128MetodoPagosID ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector AV40ColumnsSelectorAux ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV38GridStateFilterValue ;
      private string aP0_Filename ;
      private string aP1_ErrorMessage ;
   }

   public class metodopagoswwexport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P004L2( IGxContext context ,
                                             string AV60Metodopagoswwds_1_filterfulltext ,
                                             string AV61Metodopagoswwds_2_dynamicfiltersselector1 ,
                                             short AV62Metodopagoswwds_3_dynamicfiltersoperator1 ,
                                             string AV63Metodopagoswwds_4_metodopagosnombre1 ,
                                             string AV64Metodopagoswwds_5_estadosgenericosnombre1 ,
                                             bool AV65Metodopagoswwds_6_dynamicfiltersenabled2 ,
                                             string AV66Metodopagoswwds_7_dynamicfiltersselector2 ,
                                             short AV67Metodopagoswwds_8_dynamicfiltersoperator2 ,
                                             string AV68Metodopagoswwds_9_metodopagosnombre2 ,
                                             string AV69Metodopagoswwds_10_estadosgenericosnombre2 ,
                                             bool AV70Metodopagoswwds_11_dynamicfiltersenabled3 ,
                                             string AV71Metodopagoswwds_12_dynamicfiltersselector3 ,
                                             short AV72Metodopagoswwds_13_dynamicfiltersoperator3 ,
                                             string AV73Metodopagoswwds_14_metodopagosnombre3 ,
                                             string AV74Metodopagoswwds_15_estadosgenericosnombre3 ,
                                             long AV75Metodopagoswwds_16_tfmetodopagosid ,
                                             long AV76Metodopagoswwds_17_tfmetodopagosid_to ,
                                             string AV78Metodopagoswwds_19_tfmetodopagosnombre_sel ,
                                             string AV77Metodopagoswwds_18_tfmetodopagosnombre ,
                                             string AV80Metodopagoswwds_21_tfmetodopagoscodigo_sel ,
                                             string AV79Metodopagoswwds_20_tfmetodopagoscodigo ,
                                             long A128MetodoPagosID ,
                                             string A129MetodoPagosNombre ,
                                             string A214MetodoPagosCodigo ,
                                             string A109EstadosGenericosNombre ,
                                             short AV17OrderedBy ,
                                             bool AV18OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int4 = new short[21];
         Object[] GXv_Object5 = new Object[2];
         scmdbuf = "SELECT T1.[EstadosTipo], T1.[EstadosGenericosId], T2.[EstadosGenericosNombre], T1.[MetodoPagosCodigo], T1.[MetodoPagosNombre], T1.[MetodoPagosID] FROM ([MetodoPagos] T1 INNER JOIN [EstadosGenericos] T2 ON T2.[EstadosTipo] = T1.[EstadosTipo] AND T2.[EstadosGenericosId] = T1.[EstadosGenericosId])";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Metodopagoswwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( CONVERT( char(18), CAST(T1.[MetodoPagosID] AS decimal(18,0))) like '%' + @lV60Metodopagoswwds_1_filterfulltext) or ( UPPER(T1.[MetodoPagosNombre]) like '%' + UPPER(@lV60Metodopagoswwds_1_filterfulltext)) or ( UPPER(T1.[MetodoPagosCodigo]) like '%' + UPPER(@lV60Metodopagoswwds_1_filterfulltext)))");
         }
         else
         {
            GXv_int4[0] = 1;
            GXv_int4[1] = 1;
            GXv_int4[2] = 1;
         }
         if ( ( StringUtil.StrCmp(AV61Metodopagoswwds_2_dynamicfiltersselector1, "METODOPAGOSNOMBRE") == 0 ) && ( AV62Metodopagoswwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Metodopagoswwds_4_metodopagosnombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[MetodoPagosNombre]) like UPPER(@lV63Metodopagoswwds_4_metodopagosnombre1))");
         }
         else
         {
            GXv_int4[3] = 1;
         }
         if ( ( StringUtil.StrCmp(AV61Metodopagoswwds_2_dynamicfiltersselector1, "METODOPAGOSNOMBRE") == 0 ) && ( AV62Metodopagoswwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Metodopagoswwds_4_metodopagosnombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[MetodoPagosNombre]) like '%' + UPPER(@lV63Metodopagoswwds_4_metodopagosnombre1))");
         }
         else
         {
            GXv_int4[4] = 1;
         }
         if ( ( StringUtil.StrCmp(AV61Metodopagoswwds_2_dynamicfiltersselector1, "ESTADOSGENERICOSNOMBRE") == 0 ) && ( AV62Metodopagoswwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Metodopagoswwds_5_estadosgenericosnombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[EstadosGenericosNombre]) like UPPER(@lV64Metodopagoswwds_5_estadosgenericosnombre1))");
         }
         else
         {
            GXv_int4[5] = 1;
         }
         if ( ( StringUtil.StrCmp(AV61Metodopagoswwds_2_dynamicfiltersselector1, "ESTADOSGENERICOSNOMBRE") == 0 ) && ( AV62Metodopagoswwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Metodopagoswwds_5_estadosgenericosnombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[EstadosGenericosNombre]) like '%' + UPPER(@lV64Metodopagoswwds_5_estadosgenericosnombre1))");
         }
         else
         {
            GXv_int4[6] = 1;
         }
         if ( AV65Metodopagoswwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV66Metodopagoswwds_7_dynamicfiltersselector2, "METODOPAGOSNOMBRE") == 0 ) && ( AV67Metodopagoswwds_8_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Metodopagoswwds_9_metodopagosnombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[MetodoPagosNombre]) like UPPER(@lV68Metodopagoswwds_9_metodopagosnombre2))");
         }
         else
         {
            GXv_int4[7] = 1;
         }
         if ( AV65Metodopagoswwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV66Metodopagoswwds_7_dynamicfiltersselector2, "METODOPAGOSNOMBRE") == 0 ) && ( AV67Metodopagoswwds_8_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Metodopagoswwds_9_metodopagosnombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[MetodoPagosNombre]) like '%' + UPPER(@lV68Metodopagoswwds_9_metodopagosnombre2))");
         }
         else
         {
            GXv_int4[8] = 1;
         }
         if ( AV65Metodopagoswwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV66Metodopagoswwds_7_dynamicfiltersselector2, "ESTADOSGENERICOSNOMBRE") == 0 ) && ( AV67Metodopagoswwds_8_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Metodopagoswwds_10_estadosgenericosnombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[EstadosGenericosNombre]) like UPPER(@lV69Metodopagoswwds_10_estadosgenericosnombre2))");
         }
         else
         {
            GXv_int4[9] = 1;
         }
         if ( AV65Metodopagoswwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV66Metodopagoswwds_7_dynamicfiltersselector2, "ESTADOSGENERICOSNOMBRE") == 0 ) && ( AV67Metodopagoswwds_8_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Metodopagoswwds_10_estadosgenericosnombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[EstadosGenericosNombre]) like '%' + UPPER(@lV69Metodopagoswwds_10_estadosgenericosnombre2))");
         }
         else
         {
            GXv_int4[10] = 1;
         }
         if ( AV70Metodopagoswwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV71Metodopagoswwds_12_dynamicfiltersselector3, "METODOPAGOSNOMBRE") == 0 ) && ( AV72Metodopagoswwds_13_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Metodopagoswwds_14_metodopagosnombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[MetodoPagosNombre]) like UPPER(@lV73Metodopagoswwds_14_metodopagosnombre3))");
         }
         else
         {
            GXv_int4[11] = 1;
         }
         if ( AV70Metodopagoswwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV71Metodopagoswwds_12_dynamicfiltersselector3, "METODOPAGOSNOMBRE") == 0 ) && ( AV72Metodopagoswwds_13_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Metodopagoswwds_14_metodopagosnombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[MetodoPagosNombre]) like '%' + UPPER(@lV73Metodopagoswwds_14_metodopagosnombre3))");
         }
         else
         {
            GXv_int4[12] = 1;
         }
         if ( AV70Metodopagoswwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV71Metodopagoswwds_12_dynamicfiltersselector3, "ESTADOSGENERICOSNOMBRE") == 0 ) && ( AV72Metodopagoswwds_13_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Metodopagoswwds_15_estadosgenericosnombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[EstadosGenericosNombre]) like UPPER(@lV74Metodopagoswwds_15_estadosgenericosnombre3))");
         }
         else
         {
            GXv_int4[13] = 1;
         }
         if ( AV70Metodopagoswwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV71Metodopagoswwds_12_dynamicfiltersselector3, "ESTADOSGENERICOSNOMBRE") == 0 ) && ( AV72Metodopagoswwds_13_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Metodopagoswwds_15_estadosgenericosnombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[EstadosGenericosNombre]) like '%' + UPPER(@lV74Metodopagoswwds_15_estadosgenericosnombre3))");
         }
         else
         {
            GXv_int4[14] = 1;
         }
         if ( ! (0==AV75Metodopagoswwds_16_tfmetodopagosid) )
         {
            AddWhere(sWhereString, "(T1.[MetodoPagosID] >= @AV75Metodopagoswwds_16_tfmetodopagosid)");
         }
         else
         {
            GXv_int4[15] = 1;
         }
         if ( ! (0==AV76Metodopagoswwds_17_tfmetodopagosid_to) )
         {
            AddWhere(sWhereString, "(T1.[MetodoPagosID] <= @AV76Metodopagoswwds_17_tfmetodopagosid_to)");
         }
         else
         {
            GXv_int4[16] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV78Metodopagoswwds_19_tfmetodopagosnombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV77Metodopagoswwds_18_tfmetodopagosnombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[MetodoPagosNombre]) like UPPER(@lV77Metodopagoswwds_18_tfmetodopagosnombre))");
         }
         else
         {
            GXv_int4[17] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV78Metodopagoswwds_19_tfmetodopagosnombre_sel)) && ! ( StringUtil.StrCmp(AV78Metodopagoswwds_19_tfmetodopagosnombre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[MetodoPagosNombre] = @AV78Metodopagoswwds_19_tfmetodopagosnombre_sel)");
         }
         else
         {
            GXv_int4[18] = 1;
         }
         if ( StringUtil.StrCmp(AV78Metodopagoswwds_19_tfmetodopagosnombre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[MetodoPagosNombre] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV80Metodopagoswwds_21_tfmetodopagoscodigo_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV79Metodopagoswwds_20_tfmetodopagoscodigo)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[MetodoPagosCodigo]) like UPPER(@lV79Metodopagoswwds_20_tfmetodopagoscodigo))");
         }
         else
         {
            GXv_int4[19] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV80Metodopagoswwds_21_tfmetodopagoscodigo_sel)) && ! ( StringUtil.StrCmp(AV80Metodopagoswwds_21_tfmetodopagoscodigo_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[MetodoPagosCodigo] = @AV80Metodopagoswwds_21_tfmetodopagoscodigo_sel)");
         }
         else
         {
            GXv_int4[20] = 1;
         }
         if ( StringUtil.StrCmp(AV80Metodopagoswwds_21_tfmetodopagoscodigo_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((DATALENGTH(T1.[MetodoPagosCodigo])=0))");
         }
         scmdbuf += sWhereString;
         if ( ( AV17OrderedBy == 1 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[MetodoPagosNombre]";
         }
         else if ( ( AV17OrderedBy == 1 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[MetodoPagosNombre] DESC";
         }
         else if ( ( AV17OrderedBy == 2 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[MetodoPagosID]";
         }
         else if ( ( AV17OrderedBy == 2 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[MetodoPagosID] DESC";
         }
         else if ( ( AV17OrderedBy == 3 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[MetodoPagosCodigo]";
         }
         else if ( ( AV17OrderedBy == 3 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[MetodoPagosCodigo] DESC";
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
                     return conditional_P004L2(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (short)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (bool)dynConstraints[5] , (string)dynConstraints[6] , (short)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (bool)dynConstraints[10] , (string)dynConstraints[11] , (short)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (long)dynConstraints[15] , (long)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (long)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (short)dynConstraints[25] , (bool)dynConstraints[26] );
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
          Object[] prmP004L2;
          prmP004L2 = new Object[] {
          new ParDef("@lV60Metodopagoswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV60Metodopagoswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV60Metodopagoswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV63Metodopagoswwds_4_metodopagosnombre1",GXType.Char,80,0) ,
          new ParDef("@lV63Metodopagoswwds_4_metodopagosnombre1",GXType.Char,80,0) ,
          new ParDef("@lV64Metodopagoswwds_5_estadosgenericosnombre1",GXType.Char,80,0) ,
          new ParDef("@lV64Metodopagoswwds_5_estadosgenericosnombre1",GXType.Char,80,0) ,
          new ParDef("@lV68Metodopagoswwds_9_metodopagosnombre2",GXType.Char,80,0) ,
          new ParDef("@lV68Metodopagoswwds_9_metodopagosnombre2",GXType.Char,80,0) ,
          new ParDef("@lV69Metodopagoswwds_10_estadosgenericosnombre2",GXType.Char,80,0) ,
          new ParDef("@lV69Metodopagoswwds_10_estadosgenericosnombre2",GXType.Char,80,0) ,
          new ParDef("@lV73Metodopagoswwds_14_metodopagosnombre3",GXType.Char,80,0) ,
          new ParDef("@lV73Metodopagoswwds_14_metodopagosnombre3",GXType.Char,80,0) ,
          new ParDef("@lV74Metodopagoswwds_15_estadosgenericosnombre3",GXType.Char,80,0) ,
          new ParDef("@lV74Metodopagoswwds_15_estadosgenericosnombre3",GXType.Char,80,0) ,
          new ParDef("@AV75Metodopagoswwds_16_tfmetodopagosid",GXType.Decimal,18,0) ,
          new ParDef("@AV76Metodopagoswwds_17_tfmetodopagosid_to",GXType.Decimal,18,0) ,
          new ParDef("@lV77Metodopagoswwds_18_tfmetodopagosnombre",GXType.Char,80,0) ,
          new ParDef("@AV78Metodopagoswwds_19_tfmetodopagosnombre_sel",GXType.NChar,80,0) ,
          new ParDef("@lV79Metodopagoswwds_20_tfmetodopagoscodigo",GXType.VarChar,200,0) ,
          new ParDef("@AV80Metodopagoswwds_21_tfmetodopagoscodigo_sel",GXType.NVarChar,200,0)
          };
          def= new CursorDef[] {
              new CursorDef("P004L2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP004L2,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[0])[0] = rslt.getString(1, 3);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 80);
                ((string[]) buf[3])[0] = rslt.getLongVarchar(4);
                ((string[]) buf[4])[0] = rslt.getString(5, 80);
                ((long[]) buf[5])[0] = rslt.getLong(6);
                return;
       }
    }

 }

}

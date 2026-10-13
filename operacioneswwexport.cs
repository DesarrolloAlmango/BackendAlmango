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
   public class operacioneswwexport : GXProcedure
   {
      public operacioneswwexport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public operacioneswwexport( IGxContext context )
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
         new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWOperaciones", out  GXt_boolean1) ;
         AV8IsAuthorized = GXt_boolean1;
         if ( ! AV8IsAuthorized )
         {
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "wwpbaseobjects.notauthorized.aspx"+GXUtil.UrlEncode(StringUtil.RTrim(AV88Pgmname));
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
         AV12Filename = GXt_char2 + "OperacionesWWExport-" + StringUtil.Trim( StringUtil.Str( (decimal)(AV16Random), 8, 0)) + ".xlsx";
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
         if ( ! ( ( AV84TFOperacionesTipo_Sels.Count == 0 ) ) )
         {
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Concepto", "")) ;
            AV14CellRow = GXt_int3;
            AV76i = 1;
            AV89GXV1 = 1;
            while ( AV89GXV1 <= AV84TFOperacionesTipo_Sels.Count )
            {
               AV85TFOperacionesTipo_Sel = AV84TFOperacionesTipo_Sels.GetString(AV89GXV1);
               if ( AV76i == 1 )
               {
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = "";
               }
               else
               {
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text+", ";
               }
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text+context.GetMessage( gxdomaintipooperacionenum.getDescription(context,AV85TFOperacionesTipo_Sel), "");
               AV76i = (long)(AV76i+1);
               AV89GXV1 = (int)(AV89GXV1+1);
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV87TFOperacionesComprobantePago_Sel)) ) )
         {
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Comprobante", "")) ;
            AV14CellRow = GXt_int3;
            GXt_char2 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV87TFOperacionesComprobantePago_Sel)) ? context.GetMessage( "WWP_TitleFilter_EmptyOption", "") : AV87TFOperacionesComprobantePago_Sel), out  GXt_char2) ;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV86TFOperacionesComprobantePago)) ) )
            {
               GXt_int3 = (short)(AV14CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Comprobante", "")) ;
               AV14CellRow = GXt_int3;
               GXt_char2 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV86TFOperacionesComprobantePago, out  GXt_char2) ;
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
            }
         }
         if ( ! ( (DateTime.MinValue==AV69TFOperacionesFechaAlta) && (DateTime.MinValue==AV70TFOperacionesFechaAlta_To) ) )
         {
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Alta", "")) ;
            AV14CellRow = GXt_int3;
            GXt_dtime4 = DateTimeUtil.ResetTime( AV69TFOperacionesFechaAlta ) ;
            AV11ExcelDocument.SetDateFormat(context, 8, 5, ((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0), DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt")), "/", ":", " ");
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Date = GXt_dtime4;
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  false, ref  GXt_int3,  (short)(AV15FirstColumn+2),  context.GetMessage( "WWP_TSTo", "")) ;
            AV14CellRow = GXt_int3;
            GXt_dtime4 = DateTimeUtil.ResetTime( AV70TFOperacionesFechaAlta_To ) ;
            AV11ExcelDocument.SetDateFormat(context, 8, 5, ((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0), DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt")), "/", ":", " ");
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+3, 1, 1).Date = GXt_dtime4;
         }
         if ( ! ( (DateTime.MinValue==AV79TFOperacionesFechaDesde) && (DateTime.MinValue==AV80TFOperacionesFechaDesde_To) ) )
         {
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Desde", "")) ;
            AV14CellRow = GXt_int3;
            GXt_dtime4 = DateTimeUtil.ResetTime( AV79TFOperacionesFechaDesde ) ;
            AV11ExcelDocument.SetDateFormat(context, 8, 5, ((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0), DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt")), "/", ":", " ");
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Date = GXt_dtime4;
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  false, ref  GXt_int3,  (short)(AV15FirstColumn+2),  context.GetMessage( "WWP_TSTo", "")) ;
            AV14CellRow = GXt_int3;
            GXt_dtime4 = DateTimeUtil.ResetTime( AV80TFOperacionesFechaDesde_To ) ;
            AV11ExcelDocument.SetDateFormat(context, 8, 5, ((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0), DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt")), "/", ":", " ");
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+3, 1, 1).Date = GXt_dtime4;
         }
         if ( ! ( (DateTime.MinValue==AV81TFOperacionesFechaHasta) && (DateTime.MinValue==AV82TFOperacionesFechaHasta_To) ) )
         {
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Hasta", "")) ;
            AV14CellRow = GXt_int3;
            GXt_dtime4 = DateTimeUtil.ResetTime( AV81TFOperacionesFechaHasta ) ;
            AV11ExcelDocument.SetDateFormat(context, 8, 5, ((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0), DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt")), "/", ":", " ");
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Date = GXt_dtime4;
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  false, ref  GXt_int3,  (short)(AV15FirstColumn+2),  context.GetMessage( "WWP_TSTo", "")) ;
            AV14CellRow = GXt_int3;
            GXt_dtime4 = DateTimeUtil.ResetTime( AV82TFOperacionesFechaHasta_To ) ;
            AV11ExcelDocument.SetDateFormat(context, 8, 5, ((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0), DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt")), "/", ":", " ");
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+3, 1, 1).Date = GXt_dtime4;
         }
         if ( ! ( (DateTime.MinValue==AV71TFOperacionesFechaPago) && (DateTime.MinValue==AV72TFOperacionesFechaPago_To) ) )
         {
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Pago", "")) ;
            AV14CellRow = GXt_int3;
            AV11ExcelDocument.SetDateFormat(context, 8, 5, ((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0), DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt")), "/", ":", " ");
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Date = AV71TFOperacionesFechaPago;
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  false, ref  GXt_int3,  (short)(AV15FirstColumn+2),  context.GetMessage( "WWP_TSTo", "")) ;
            AV14CellRow = GXt_int3;
            AV11ExcelDocument.SetDateFormat(context, 8, 5, ((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0), DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt")), "/", ":", " ");
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+3, 1, 1).Date = AV72TFOperacionesFechaPago_To;
         }
         if ( ! ( ( AV74TFOperacionesEstado_Sels.Count == 0 ) ) )
         {
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Estado", "")) ;
            AV14CellRow = GXt_int3;
            AV76i = 1;
            AV90GXV2 = 1;
            while ( AV90GXV2 <= AV74TFOperacionesEstado_Sels.Count )
            {
               AV75TFOperacionesEstado_Sel = AV74TFOperacionesEstado_Sels.GetString(AV90GXV2);
               if ( AV76i == 1 )
               {
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = "";
               }
               else
               {
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text+", ";
               }
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text+context.GetMessage( gxdomainestadoope.getDescription(context,AV75TFOperacionesEstado_Sel), "");
               AV76i = (long)(AV76i+1);
               AV90GXV2 = (int)(AV90GXV2+1);
            }
         }
         AV14CellRow = (int)(AV14CellRow+2);
      }

      protected void S141( )
      {
         /* 'WRITECOLUMNTITLES' Routine */
         returnInSub = false;
         AV44VisibleColumnCount = 0;
         if ( StringUtil.StrCmp(AV32Session.Get("OperacionesWWColumnsSelector"), "") != 0 )
         {
            AV39ColumnsSelectorXML = AV32Session.Get("OperacionesWWColumnsSelector");
            AV36ColumnsSelector.FromXml(AV39ColumnsSelectorXML, null, "", "");
         }
         else
         {
            /* Execute user subroutine: 'INITIALIZECOLUMNSSELECTOR' */
            S151 ();
            if (returnInSub) return;
         }
         AV36ColumnsSelector.gxTpr_Columns.Sort("Order");
         AV91GXV3 = 1;
         while ( AV91GXV3 <= AV36ColumnsSelector.gxTpr_Columns.Count )
         {
            AV38ColumnsSelector_Column = ((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV36ColumnsSelector.gxTpr_Columns.Item(AV91GXV3));
            if ( AV38ColumnsSelector_Column.gxTpr_Isvisible )
            {
               AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV44VisibleColumnCount), 1, 1).Text = context.GetMessage( (String.IsNullOrEmpty(StringUtil.RTrim( AV38ColumnsSelector_Column.gxTpr_Displayname)) ? AV38ColumnsSelector_Column.gxTpr_Columnname : AV38ColumnsSelector_Column.gxTpr_Displayname), "");
               AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV44VisibleColumnCount), 1, 1).Bold = 1;
               AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV44VisibleColumnCount), 1, 1).Color = 11;
               AV44VisibleColumnCount = (long)(AV44VisibleColumnCount+1);
            }
            AV91GXV3 = (int)(AV91GXV3+1);
         }
      }

      protected void S161( )
      {
         /* 'WRITEDATA' Routine */
         returnInSub = false;
         AV93Operacioneswwds_1_filterfulltext = AV19FilterFullText;
         AV94Operacioneswwds_2_tfoperacionestipo_sels = AV84TFOperacionesTipo_Sels;
         AV95Operacioneswwds_3_tfoperacionescomprobantepago = AV86TFOperacionesComprobantePago;
         AV96Operacioneswwds_4_tfoperacionescomprobantepago_sel = AV87TFOperacionesComprobantePago_Sel;
         AV97Operacioneswwds_5_tfoperacionesfechaalta = AV69TFOperacionesFechaAlta;
         AV98Operacioneswwds_6_tfoperacionesfechaalta_to = AV70TFOperacionesFechaAlta_To;
         AV99Operacioneswwds_7_tfoperacionesfechadesde = AV79TFOperacionesFechaDesde;
         AV100Operacioneswwds_8_tfoperacionesfechadesde_to = AV80TFOperacionesFechaDesde_To;
         AV101Operacioneswwds_9_tfoperacionesfechahasta = AV81TFOperacionesFechaHasta;
         AV102Operacioneswwds_10_tfoperacionesfechahasta_to = AV82TFOperacionesFechaHasta_To;
         AV103Operacioneswwds_11_tfoperacionesfechapago = AV71TFOperacionesFechaPago;
         AV104Operacioneswwds_12_tfoperacionesfechapago_to = AV72TFOperacionesFechaPago_To;
         AV105Operacioneswwds_13_tfoperacionesestado_sels = AV74TFOperacionesEstado_Sels;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A649OperacionesTipo ,
                                              AV94Operacioneswwds_2_tfoperacionestipo_sels ,
                                              A577OperacionesEstado ,
                                              AV105Operacioneswwds_13_tfoperacionesestado_sels ,
                                              AV94Operacioneswwds_2_tfoperacionestipo_sels.Count ,
                                              AV96Operacioneswwds_4_tfoperacionescomprobantepago_sel ,
                                              AV95Operacioneswwds_3_tfoperacionescomprobantepago ,
                                              AV99Operacioneswwds_7_tfoperacionesfechadesde ,
                                              AV100Operacioneswwds_8_tfoperacionesfechadesde_to ,
                                              AV101Operacioneswwds_9_tfoperacionesfechahasta ,
                                              AV102Operacioneswwds_10_tfoperacionesfechahasta_to ,
                                              AV105Operacioneswwds_13_tfoperacionesestado_sels.Count ,
                                              A580OperacionesComprobantePago ,
                                              A658OperacionesFechaDesde ,
                                              A659OperacionesFechaHasta ,
                                              AV17OrderedBy ,
                                              AV18OrderedDsc ,
                                              AV93Operacioneswwds_1_filterfulltext ,
                                              A554OperacionesId ,
                                              A555OperacionesRef ,
                                              A657OperacionesNombreRef ,
                                              A569OperacionesTipoES ,
                                              A570OperacionesImporte ,
                                              A572OperacionesFacturaCod } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.DATE,
                                              TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.DECIMAL,
                                              TypeConstants.BOOLEAN, TypeConstants.BOOLEAN
                                              }
         });
         lV95Operacioneswwds_3_tfoperacionescomprobantepago = StringUtil.PadR( StringUtil.RTrim( AV95Operacioneswwds_3_tfoperacionescomprobantepago), 256, "%");
         /* Using cursor P00782 */
         pr_default.execute(0, new Object[] {lV95Operacioneswwds_3_tfoperacionescomprobantepago, AV96Operacioneswwds_4_tfoperacionescomprobantepago_sel, AV99Operacioneswwds_7_tfoperacionesfechadesde, AV100Operacioneswwds_8_tfoperacionesfechadesde_to, AV101Operacioneswwds_9_tfoperacionesfechahasta, AV102Operacioneswwds_10_tfoperacionesfechahasta_to});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A572OperacionesFacturaCod = P00782_A572OperacionesFacturaCod[0];
            n572OperacionesFacturaCod = P00782_n572OperacionesFacturaCod[0];
            A570OperacionesImporte = P00782_A570OperacionesImporte[0];
            n570OperacionesImporte = P00782_n570OperacionesImporte[0];
            A657OperacionesNombreRef = P00782_A657OperacionesNombreRef[0];
            n657OperacionesNombreRef = P00782_n657OperacionesNombreRef[0];
            A555OperacionesRef = P00782_A555OperacionesRef[0];
            n555OperacionesRef = P00782_n555OperacionesRef[0];
            A554OperacionesId = P00782_A554OperacionesId[0];
            A659OperacionesFechaHasta = P00782_A659OperacionesFechaHasta[0];
            n659OperacionesFechaHasta = P00782_n659OperacionesFechaHasta[0];
            A658OperacionesFechaDesde = P00782_A658OperacionesFechaDesde[0];
            n658OperacionesFechaDesde = P00782_n658OperacionesFechaDesde[0];
            A580OperacionesComprobantePago = P00782_A580OperacionesComprobantePago[0];
            n580OperacionesComprobantePago = P00782_n580OperacionesComprobantePago[0];
            A577OperacionesEstado = P00782_A577OperacionesEstado[0];
            n577OperacionesEstado = P00782_n577OperacionesEstado[0];
            A569OperacionesTipoES = P00782_A569OperacionesTipoES[0];
            n569OperacionesTipoES = P00782_n569OperacionesTipoES[0];
            A649OperacionesTipo = P00782_A649OperacionesTipo[0];
            n649OperacionesTipo = P00782_n649OperacionesTipo[0];
            A582OperacionesFechaPago = P00782_A582OperacionesFechaPago[0];
            n582OperacionesFechaPago = P00782_n582OperacionesFechaPago[0];
            A581OperacionesFechaAlta = P00782_A581OperacionesFechaAlta[0];
            n581OperacionesFechaAlta = P00782_n581OperacionesFechaAlta[0];
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV93Operacioneswwds_1_filterfulltext)) || ( ( StringUtil.Like( StringUtil.Str( (decimal)(A554OperacionesId), 18, 0) , StringUtil.PadR( "%" + AV93Operacioneswwds_1_filterfulltext , 254 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Upper( A555OperacionesRef) , StringUtil.PadR( "%" + StringUtil.Upper( AV93Operacioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A657OperacionesNombreRef) , StringUtil.PadR( "%" + StringUtil.Upper( AV93Operacioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( context.GetMessage( "liquidación de solicitudes del profesional", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV93Operacioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A649OperacionesTipo, "LSF") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "liquidación de  solicitudes comercio", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV93Operacioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A649OperacionesTipo, "LSC") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "cobro de saldo pendiente", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV93Operacioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A649OperacionesTipo, "COL") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "pago de saldo", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV93Operacioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) &&
            ( StringUtil.StrCmp(A649OperacionesTipo, "POL") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "cobro de solicitud", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV93Operacioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A649OperacionesTipo, "CSO") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "nota de credito", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV93Operacioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A649OperacionesTipo, "NCR") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "nota de debito", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV93Operacioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) &&
            ( StringUtil.StrCmp(A649OperacionesTipo, "NDE") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "otros", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV93Operacioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A649OperacionesTipo, "OTR") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "solicitudes ingresadas desde fenicio", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV93Operacioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A649OperacionesTipo, "FEN") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "respuesta de api fenicio", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV93Operacioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A649OperacionesTipo, "FGO") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "comercio_externo", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV93Operacioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A649OperacionesTipo, "CEX") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "entrada", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV93Operacioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) &&
            ( StringUtil.StrCmp(A569OperacionesTipoES, "E") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "salida", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV93Operacioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A569OperacionesTipoES, "S") == 0 ) ) ||
            ( StringUtil.Like( StringUtil.Str( A570OperacionesImporte, 18, 2) , StringUtil.PadR( "%" + AV93Operacioneswwds_1_filterfulltext , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A572OperacionesFacturaCod) , StringUtil.PadR( "%" + StringUtil.Upper( AV93Operacioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Upper( A580OperacionesComprobantePago) , StringUtil.PadR( "%" + StringUtil.Upper( AV93Operacioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( context.GetMessage( "procesado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV93Operacioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A577OperacionesEstado, "PRO") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "pendiente", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV93Operacioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A577OperacionesEstado, "PND") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "anulado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV93Operacioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) &&
            ( StringUtil.StrCmp(A577OperacionesEstado, "ANU") == 0 ) ) )
            )
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
               AV106GXV4 = 1;
               while ( AV106GXV4 <= AV36ColumnsSelector.gxTpr_Columns.Count )
               {
                  AV38ColumnsSelector_Column = ((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV36ColumnsSelector.gxTpr_Columns.Item(AV106GXV4));
                  if ( AV38ColumnsSelector_Column.gxTpr_Isvisible )
                  {
                     if ( StringUtil.StrCmp(AV38ColumnsSelector_Column.gxTpr_Columnname, "OperacionesId") == 0 )
                     {
                        AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV44VisibleColumnCount), 1, 1).Number = A554OperacionesId;
                        if ( StringUtil.StrCmp(A577OperacionesEstado, "PRO") == 0 )
                        {
                           AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV44VisibleColumnCount), 1, 1).Color = GXUtil.RGB( 0, 166, 90);
                        }
                     }
                     else if ( StringUtil.StrCmp(AV38ColumnsSelector_Column.gxTpr_Columnname, "OperacionesRef") == 0 )
                     {
                        GXt_char2 = "";
                        new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A555OperacionesRef, out  GXt_char2) ;
                        AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV44VisibleColumnCount), 1, 1).Text = GXt_char2;
                     }
                     else if ( StringUtil.StrCmp(AV38ColumnsSelector_Column.gxTpr_Columnname, "OperacionesNombreRef") == 0 )
                     {
                        GXt_char2 = "";
                        new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A657OperacionesNombreRef, out  GXt_char2) ;
                        AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV44VisibleColumnCount), 1, 1).Text = GXt_char2;
                     }
                     else if ( StringUtil.StrCmp(AV38ColumnsSelector_Column.gxTpr_Columnname, "OperacionesTipo") == 0 )
                     {
                        AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV44VisibleColumnCount), 1, 1).Text = context.GetMessage( gxdomaintipooperacionenum.getDescription(context,A649OperacionesTipo), "");
                     }
                     else if ( StringUtil.StrCmp(AV38ColumnsSelector_Column.gxTpr_Columnname, "OperacionesTipoES") == 0 )
                     {
                        AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV44VisibleColumnCount), 1, 1).Text = context.GetMessage( gxdomaintipoes.getDescription(context,A569OperacionesTipoES), "");
                     }
                     else if ( StringUtil.StrCmp(AV38ColumnsSelector_Column.gxTpr_Columnname, "OperacionesImporte") == 0 )
                     {
                        AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV44VisibleColumnCount), 1, 1).Number = (double)(A570OperacionesImporte);
                     }
                     else if ( StringUtil.StrCmp(AV38ColumnsSelector_Column.gxTpr_Columnname, "OperacionesFacturaCod") == 0 )
                     {
                        GXt_char2 = "";
                        new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A572OperacionesFacturaCod, out  GXt_char2) ;
                        AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV44VisibleColumnCount), 1, 1).Text = GXt_char2;
                     }
                     else if ( StringUtil.StrCmp(AV38ColumnsSelector_Column.gxTpr_Columnname, "OperacionesComprobantePago") == 0 )
                     {
                        GXt_char2 = "";
                        new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A580OperacionesComprobantePago, out  GXt_char2) ;
                        AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV44VisibleColumnCount), 1, 1).Text = GXt_char2;
                     }
                     else if ( StringUtil.StrCmp(AV38ColumnsSelector_Column.gxTpr_Columnname, "OperacionesFechaAlta") == 0 )
                     {
                        GXt_dtime4 = DateTimeUtil.ResetTime( A581OperacionesFechaAlta ) ;
                        AV11ExcelDocument.SetDateFormat(context, 8, 5, ((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0), DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt")), "/", ":", " ");
                        AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV44VisibleColumnCount), 1, 1).Date = GXt_dtime4;
                     }
                     else if ( StringUtil.StrCmp(AV38ColumnsSelector_Column.gxTpr_Columnname, "OperacionesFechaDesde") == 0 )
                     {
                        GXt_dtime4 = DateTimeUtil.ResetTime( A658OperacionesFechaDesde ) ;
                        AV11ExcelDocument.SetDateFormat(context, 8, 5, ((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0), DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt")), "/", ":", " ");
                        AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV44VisibleColumnCount), 1, 1).Date = GXt_dtime4;
                     }
                     else if ( StringUtil.StrCmp(AV38ColumnsSelector_Column.gxTpr_Columnname, "OperacionesFechaHasta") == 0 )
                     {
                        GXt_dtime4 = DateTimeUtil.ResetTime( A659OperacionesFechaHasta ) ;
                        AV11ExcelDocument.SetDateFormat(context, 8, 5, ((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0), DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt")), "/", ":", " ");
                        AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV44VisibleColumnCount), 1, 1).Date = GXt_dtime4;
                     }
                     else if ( StringUtil.StrCmp(AV38ColumnsSelector_Column.gxTpr_Columnname, "OperacionesFechaPago") == 0 )
                     {
                        AV11ExcelDocument.SetDateFormat(context, 8, 5, ((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0), DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt")), "/", ":", " ");
                        AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV44VisibleColumnCount), 1, 1).Date = A582OperacionesFechaPago;
                     }
                     else if ( StringUtil.StrCmp(AV38ColumnsSelector_Column.gxTpr_Columnname, "OperacionesEstado") == 0 )
                     {
                        AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV44VisibleColumnCount), 1, 1).Text = context.GetMessage( gxdomainestadoope.getDescription(context,A577OperacionesEstado), "");
                     }
                     AV44VisibleColumnCount = (long)(AV44VisibleColumnCount+1);
                  }
                  AV106GXV4 = (int)(AV106GXV4+1);
               }
               if ( StringUtil.StrCmp(A577OperacionesEstado, "PND") == 0 )
               {
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, (int)(AV44VisibleColumnCount)).Color = GXUtil.RGB( 60, 141, 188);
               }
               else if ( StringUtil.StrCmp(A577OperacionesEstado, "ANU") == 0 )
               {
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, (int)(AV44VisibleColumnCount)).Color = GXUtil.RGB( 221, 75, 57);
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
         AV32Session.Set("WWPExportFileName", "OperacionesWWExport.xlsx");
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
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV36ColumnsSelector,  "OperacionesId",  "Operación",  "Id",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV36ColumnsSelector,  "OperacionesRef",  "Operación",  "Referencia",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV36ColumnsSelector,  "OperacionesNombreRef",  "Operación",  "Nombre",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV36ColumnsSelector,  "OperacionesTipo",  "Operación",  "Concepto",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV36ColumnsSelector,  "OperacionesTipoES",  "Operación",  "Tipo",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV36ColumnsSelector,  "OperacionesImporte",  "Operación",  "Importe",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV36ColumnsSelector,  "OperacionesFacturaCod",  "Operación",  "Factura",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV36ColumnsSelector,  "OperacionesComprobantePago",  "Operación",  "Comprobante",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV36ColumnsSelector,  "OperacionesFechaAlta",  "Fechas",  "Alta",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV36ColumnsSelector,  "OperacionesFechaDesde",  "Fechas",  "Desde",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV36ColumnsSelector,  "OperacionesFechaHasta",  "Fechas",  "Hasta",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV36ColumnsSelector,  "OperacionesFechaPago",  "Fechas",  "Pago",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV36ColumnsSelector,  "OperacionesEstado",  "",  "Estado",  true,  "") ;
         GXt_char2 = AV40UserCustomValue;
         new GeneXus.Programs.wwpbaseobjects.loadcolumnsselectorstate(context ).execute(  "OperacionesWWColumnsSelector", out  GXt_char2) ;
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
         if ( StringUtil.StrCmp(AV32Session.Get("OperacionesWWGridState"), "") == 0 )
         {
            AV34GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "OperacionesWWGridState"), null, "", "");
         }
         else
         {
            AV34GridState.FromXml(AV32Session.Get("OperacionesWWGridState"), null, "", "");
         }
         AV17OrderedBy = AV34GridState.gxTpr_Orderedby;
         AV18OrderedDsc = AV34GridState.gxTpr_Ordereddsc;
         AV107GXV5 = 1;
         while ( AV107GXV5 <= AV34GridState.gxTpr_Filtervalues.Count )
         {
            AV35GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV34GridState.gxTpr_Filtervalues.Item(AV107GXV5));
            if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV19FilterFullText = AV35GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFOPERACIONESTIPO_SEL") == 0 )
            {
               AV83TFOperacionesTipo_SelsJson = AV35GridStateFilterValue.gxTpr_Value;
               AV84TFOperacionesTipo_Sels.FromJSonString(AV83TFOperacionesTipo_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFOPERACIONESCOMPROBANTEPAGO") == 0 )
            {
               AV86TFOperacionesComprobantePago = AV35GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFOPERACIONESCOMPROBANTEPAGO_SEL") == 0 )
            {
               AV87TFOperacionesComprobantePago_Sel = AV35GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFOPERACIONESFECHAALTA") == 0 )
            {
               AV69TFOperacionesFechaAlta = context.localUtil.CToD( AV35GridStateFilterValue.gxTpr_Value, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               AV70TFOperacionesFechaAlta_To = context.localUtil.CToD( AV35GridStateFilterValue.gxTpr_Valueto, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFOPERACIONESFECHADESDE") == 0 )
            {
               AV79TFOperacionesFechaDesde = context.localUtil.CToD( AV35GridStateFilterValue.gxTpr_Value, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               AV80TFOperacionesFechaDesde_To = context.localUtil.CToD( AV35GridStateFilterValue.gxTpr_Valueto, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFOPERACIONESFECHAHASTA") == 0 )
            {
               AV81TFOperacionesFechaHasta = context.localUtil.CToD( AV35GridStateFilterValue.gxTpr_Value, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               AV82TFOperacionesFechaHasta_To = context.localUtil.CToD( AV35GridStateFilterValue.gxTpr_Valueto, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFOPERACIONESFECHAPAGO") == 0 )
            {
               AV71TFOperacionesFechaPago = context.localUtil.CToT( AV35GridStateFilterValue.gxTpr_Value, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               AV72TFOperacionesFechaPago_To = context.localUtil.CToT( AV35GridStateFilterValue.gxTpr_Valueto, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFOPERACIONESESTADO_SEL") == 0 )
            {
               AV73TFOperacionesEstado_SelsJson = AV35GridStateFilterValue.gxTpr_Value;
               AV74TFOperacionesEstado_Sels.FromJSonString(AV73TFOperacionesEstado_SelsJson, null);
            }
            AV107GXV5 = (int)(AV107GXV5+1);
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
         AV88Pgmname = "";
         GXKey = "";
         GXEncryptionTmp = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV11ExcelDocument = new ExcelDocumentI();
         AV19FilterFullText = "";
         AV84TFOperacionesTipo_Sels = new GxSimpleCollection<string>();
         AV85TFOperacionesTipo_Sel = "";
         AV87TFOperacionesComprobantePago_Sel = "";
         AV86TFOperacionesComprobantePago = "";
         AV69TFOperacionesFechaAlta = DateTime.MinValue;
         AV70TFOperacionesFechaAlta_To = DateTime.MinValue;
         AV79TFOperacionesFechaDesde = DateTime.MinValue;
         AV80TFOperacionesFechaDesde_To = DateTime.MinValue;
         AV81TFOperacionesFechaHasta = DateTime.MinValue;
         AV82TFOperacionesFechaHasta_To = DateTime.MinValue;
         AV71TFOperacionesFechaPago = (DateTime)(DateTime.MinValue);
         AV72TFOperacionesFechaPago_To = (DateTime)(DateTime.MinValue);
         AV74TFOperacionesEstado_Sels = new GxSimpleCollection<string>();
         AV75TFOperacionesEstado_Sel = "";
         AV32Session = context.GetSession();
         AV39ColumnsSelectorXML = "";
         AV36ColumnsSelector = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector(context);
         AV38ColumnsSelector_Column = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column(context);
         AV93Operacioneswwds_1_filterfulltext = "";
         AV94Operacioneswwds_2_tfoperacionestipo_sels = new GxSimpleCollection<string>();
         AV95Operacioneswwds_3_tfoperacionescomprobantepago = "";
         AV96Operacioneswwds_4_tfoperacionescomprobantepago_sel = "";
         AV97Operacioneswwds_5_tfoperacionesfechaalta = DateTime.MinValue;
         AV98Operacioneswwds_6_tfoperacionesfechaalta_to = DateTime.MinValue;
         AV99Operacioneswwds_7_tfoperacionesfechadesde = DateTime.MinValue;
         AV100Operacioneswwds_8_tfoperacionesfechadesde_to = DateTime.MinValue;
         AV101Operacioneswwds_9_tfoperacionesfechahasta = DateTime.MinValue;
         AV102Operacioneswwds_10_tfoperacionesfechahasta_to = DateTime.MinValue;
         AV103Operacioneswwds_11_tfoperacionesfechapago = (DateTime)(DateTime.MinValue);
         AV104Operacioneswwds_12_tfoperacionesfechapago_to = (DateTime)(DateTime.MinValue);
         AV105Operacioneswwds_13_tfoperacionesestado_sels = new GxSimpleCollection<string>();
         lV95Operacioneswwds_3_tfoperacionescomprobantepago = "";
         A649OperacionesTipo = "";
         A577OperacionesEstado = "";
         A580OperacionesComprobantePago = "";
         A658OperacionesFechaDesde = DateTime.MinValue;
         A659OperacionesFechaHasta = DateTime.MinValue;
         A555OperacionesRef = "";
         A657OperacionesNombreRef = "";
         A569OperacionesTipoES = "";
         A572OperacionesFacturaCod = "";
         P00782_A572OperacionesFacturaCod = new string[] {""} ;
         P00782_n572OperacionesFacturaCod = new bool[] {false} ;
         P00782_A570OperacionesImporte = new decimal[1] ;
         P00782_n570OperacionesImporte = new bool[] {false} ;
         P00782_A657OperacionesNombreRef = new string[] {""} ;
         P00782_n657OperacionesNombreRef = new bool[] {false} ;
         P00782_A555OperacionesRef = new string[] {""} ;
         P00782_n555OperacionesRef = new bool[] {false} ;
         P00782_A554OperacionesId = new long[1] ;
         P00782_A659OperacionesFechaHasta = new DateTime[] {DateTime.MinValue} ;
         P00782_n659OperacionesFechaHasta = new bool[] {false} ;
         P00782_A658OperacionesFechaDesde = new DateTime[] {DateTime.MinValue} ;
         P00782_n658OperacionesFechaDesde = new bool[] {false} ;
         P00782_A580OperacionesComprobantePago = new string[] {""} ;
         P00782_n580OperacionesComprobantePago = new bool[] {false} ;
         P00782_A577OperacionesEstado = new string[] {""} ;
         P00782_n577OperacionesEstado = new bool[] {false} ;
         P00782_A569OperacionesTipoES = new string[] {""} ;
         P00782_n569OperacionesTipoES = new bool[] {false} ;
         P00782_A649OperacionesTipo = new string[] {""} ;
         P00782_n649OperacionesTipo = new bool[] {false} ;
         P00782_A582OperacionesFechaPago = new DateTime[] {DateTime.MinValue} ;
         P00782_n582OperacionesFechaPago = new bool[] {false} ;
         P00782_A581OperacionesFechaAlta = new DateTime[] {DateTime.MinValue} ;
         P00782_n581OperacionesFechaAlta = new bool[] {false} ;
         A582OperacionesFechaPago = (DateTime)(DateTime.MinValue);
         A581OperacionesFechaAlta = DateTime.MinValue;
         GXt_dtime4 = (DateTime)(DateTime.MinValue);
         AV40UserCustomValue = "";
         GXt_char2 = "";
         AV37ColumnsSelectorAux = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector(context);
         AV34GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV35GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV83TFOperacionesTipo_SelsJson = "";
         AV73TFOperacionesEstado_SelsJson = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.operacioneswwexport__default(),
            new Object[][] {
                new Object[] {
               P00782_A572OperacionesFacturaCod, P00782_n572OperacionesFacturaCod, P00782_A570OperacionesImporte, P00782_n570OperacionesImporte, P00782_A657OperacionesNombreRef, P00782_n657OperacionesNombreRef, P00782_A555OperacionesRef, P00782_n555OperacionesRef, P00782_A554OperacionesId, P00782_A659OperacionesFechaHasta,
               P00782_n659OperacionesFechaHasta, P00782_A658OperacionesFechaDesde, P00782_n658OperacionesFechaDesde, P00782_A580OperacionesComprobantePago, P00782_n580OperacionesComprobantePago, P00782_A577OperacionesEstado, P00782_n577OperacionesEstado, P00782_A569OperacionesTipoES, P00782_n569OperacionesTipoES, P00782_A649OperacionesTipo,
               P00782_n649OperacionesTipo, P00782_A582OperacionesFechaPago, P00782_n582OperacionesFechaPago, P00782_A581OperacionesFechaAlta, P00782_n581OperacionesFechaAlta
               }
            }
         );
         AV88Pgmname = "OperacionesWWExport";
         /* GeneXus formulas. */
         AV88Pgmname = "OperacionesWWExport";
      }

      private short GXt_int3 ;
      private short AV17OrderedBy ;
      private int AV14CellRow ;
      private int AV15FirstColumn ;
      private int AV16Random ;
      private int AV89GXV1 ;
      private int AV90GXV2 ;
      private int AV91GXV3 ;
      private int AV94Operacioneswwds_2_tfoperacionestipo_sels_Count ;
      private int AV105Operacioneswwds_13_tfoperacionesestado_sels_Count ;
      private int AV106GXV4 ;
      private int AV107GXV5 ;
      private long AV76i ;
      private long AV44VisibleColumnCount ;
      private long A554OperacionesId ;
      private decimal A570OperacionesImporte ;
      private string AV88Pgmname ;
      private string GXKey ;
      private string GXEncryptionTmp ;
      private string AV85TFOperacionesTipo_Sel ;
      private string AV87TFOperacionesComprobantePago_Sel ;
      private string AV86TFOperacionesComprobantePago ;
      private string AV75TFOperacionesEstado_Sel ;
      private string AV95Operacioneswwds_3_tfoperacionescomprobantepago ;
      private string AV96Operacioneswwds_4_tfoperacionescomprobantepago_sel ;
      private string lV95Operacioneswwds_3_tfoperacionescomprobantepago ;
      private string A649OperacionesTipo ;
      private string A577OperacionesEstado ;
      private string A580OperacionesComprobantePago ;
      private string A555OperacionesRef ;
      private string A657OperacionesNombreRef ;
      private string A569OperacionesTipoES ;
      private string A572OperacionesFacturaCod ;
      private string GXt_char2 ;
      private DateTime AV71TFOperacionesFechaPago ;
      private DateTime AV72TFOperacionesFechaPago_To ;
      private DateTime AV103Operacioneswwds_11_tfoperacionesfechapago ;
      private DateTime AV104Operacioneswwds_12_tfoperacionesfechapago_to ;
      private DateTime A582OperacionesFechaPago ;
      private DateTime GXt_dtime4 ;
      private DateTime AV69TFOperacionesFechaAlta ;
      private DateTime AV70TFOperacionesFechaAlta_To ;
      private DateTime AV79TFOperacionesFechaDesde ;
      private DateTime AV80TFOperacionesFechaDesde_To ;
      private DateTime AV81TFOperacionesFechaHasta ;
      private DateTime AV82TFOperacionesFechaHasta_To ;
      private DateTime AV97Operacioneswwds_5_tfoperacionesfechaalta ;
      private DateTime AV98Operacioneswwds_6_tfoperacionesfechaalta_to ;
      private DateTime AV99Operacioneswwds_7_tfoperacionesfechadesde ;
      private DateTime AV100Operacioneswwds_8_tfoperacionesfechadesde_to ;
      private DateTime AV101Operacioneswwds_9_tfoperacionesfechahasta ;
      private DateTime AV102Operacioneswwds_10_tfoperacionesfechahasta_to ;
      private DateTime A658OperacionesFechaDesde ;
      private DateTime A659OperacionesFechaHasta ;
      private DateTime A581OperacionesFechaAlta ;
      private bool AV8IsAuthorized ;
      private bool GXt_boolean1 ;
      private bool returnInSub ;
      private bool AV18OrderedDsc ;
      private bool n572OperacionesFacturaCod ;
      private bool n570OperacionesImporte ;
      private bool n657OperacionesNombreRef ;
      private bool n555OperacionesRef ;
      private bool n659OperacionesFechaHasta ;
      private bool n658OperacionesFechaDesde ;
      private bool n580OperacionesComprobantePago ;
      private bool n577OperacionesEstado ;
      private bool n569OperacionesTipoES ;
      private bool n649OperacionesTipo ;
      private bool n582OperacionesFechaPago ;
      private bool n581OperacionesFechaAlta ;
      private string AV39ColumnsSelectorXML ;
      private string AV40UserCustomValue ;
      private string AV83TFOperacionesTipo_SelsJson ;
      private string AV73TFOperacionesEstado_SelsJson ;
      private string AV12Filename ;
      private string AV13ErrorMessage ;
      private string AV19FilterFullText ;
      private string AV93Operacioneswwds_1_filterfulltext ;
      private IGxSession AV32Session ;
      private ExcelDocumentI AV11ExcelDocument ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GxSimpleCollection<string> AV84TFOperacionesTipo_Sels ;
      private GxSimpleCollection<string> AV74TFOperacionesEstado_Sels ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector AV36ColumnsSelector ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column AV38ColumnsSelector_Column ;
      private GxSimpleCollection<string> AV94Operacioneswwds_2_tfoperacionestipo_sels ;
      private GxSimpleCollection<string> AV105Operacioneswwds_13_tfoperacionesestado_sels ;
      private IDataStoreProvider pr_default ;
      private string[] P00782_A572OperacionesFacturaCod ;
      private bool[] P00782_n572OperacionesFacturaCod ;
      private decimal[] P00782_A570OperacionesImporte ;
      private bool[] P00782_n570OperacionesImporte ;
      private string[] P00782_A657OperacionesNombreRef ;
      private bool[] P00782_n657OperacionesNombreRef ;
      private string[] P00782_A555OperacionesRef ;
      private bool[] P00782_n555OperacionesRef ;
      private long[] P00782_A554OperacionesId ;
      private DateTime[] P00782_A659OperacionesFechaHasta ;
      private bool[] P00782_n659OperacionesFechaHasta ;
      private DateTime[] P00782_A658OperacionesFechaDesde ;
      private bool[] P00782_n658OperacionesFechaDesde ;
      private string[] P00782_A580OperacionesComprobantePago ;
      private bool[] P00782_n580OperacionesComprobantePago ;
      private string[] P00782_A577OperacionesEstado ;
      private bool[] P00782_n577OperacionesEstado ;
      private string[] P00782_A569OperacionesTipoES ;
      private bool[] P00782_n569OperacionesTipoES ;
      private string[] P00782_A649OperacionesTipo ;
      private bool[] P00782_n649OperacionesTipo ;
      private DateTime[] P00782_A582OperacionesFechaPago ;
      private bool[] P00782_n582OperacionesFechaPago ;
      private DateTime[] P00782_A581OperacionesFechaAlta ;
      private bool[] P00782_n581OperacionesFechaAlta ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector AV37ColumnsSelectorAux ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV34GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV35GridStateFilterValue ;
      private string aP0_Filename ;
      private string aP1_ErrorMessage ;
   }

   public class operacioneswwexport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00782( IGxContext context ,
                                             string A649OperacionesTipo ,
                                             GxSimpleCollection<string> AV94Operacioneswwds_2_tfoperacionestipo_sels ,
                                             string A577OperacionesEstado ,
                                             GxSimpleCollection<string> AV105Operacioneswwds_13_tfoperacionesestado_sels ,
                                             int AV94Operacioneswwds_2_tfoperacionestipo_sels_Count ,
                                             string AV96Operacioneswwds_4_tfoperacionescomprobantepago_sel ,
                                             string AV95Operacioneswwds_3_tfoperacionescomprobantepago ,
                                             DateTime AV99Operacioneswwds_7_tfoperacionesfechadesde ,
                                             DateTime AV100Operacioneswwds_8_tfoperacionesfechadesde_to ,
                                             DateTime AV101Operacioneswwds_9_tfoperacionesfechahasta ,
                                             DateTime AV102Operacioneswwds_10_tfoperacionesfechahasta_to ,
                                             int AV105Operacioneswwds_13_tfoperacionesestado_sels_Count ,
                                             string A580OperacionesComprobantePago ,
                                             DateTime A658OperacionesFechaDesde ,
                                             DateTime A659OperacionesFechaHasta ,
                                             short AV17OrderedBy ,
                                             bool AV18OrderedDsc ,
                                             string AV93Operacioneswwds_1_filterfulltext ,
                                             long A554OperacionesId ,
                                             string A555OperacionesRef ,
                                             string A657OperacionesNombreRef ,
                                             string A569OperacionesTipoES ,
                                             decimal A570OperacionesImporte ,
                                             string A572OperacionesFacturaCod )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int5 = new short[6];
         Object[] GXv_Object6 = new Object[2];
         scmdbuf = "SELECT [OperacionesFacturaCod], [OperacionesImporte], [OperacionesNombreRef], [OperacionesRef], [OperacionesId], [OperacionesFechaHasta], [OperacionesFechaDesde], [OperacionesComprobantePago], [OperacionesEstado], [OperacionesTipoES], [OperacionesTipo], [OperacionesFechaPago], [OperacionesFechaAlta] FROM [Operaciones]";
         if ( AV94Operacioneswwds_2_tfoperacionestipo_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV94Operacioneswwds_2_tfoperacionestipo_sels, "[OperacionesTipo] IN (", ")")+")");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV96Operacioneswwds_4_tfoperacionescomprobantepago_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV95Operacioneswwds_3_tfoperacionescomprobantepago)) ) )
         {
            AddWhere(sWhereString, "(UPPER([OperacionesComprobantePago]) like UPPER(@lV95Operacioneswwds_3_tfoperacionescomprobantepago))");
         }
         else
         {
            GXv_int5[0] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV96Operacioneswwds_4_tfoperacionescomprobantepago_sel)) && ! ( StringUtil.StrCmp(AV96Operacioneswwds_4_tfoperacionescomprobantepago_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([OperacionesComprobantePago] = @AV96Operacioneswwds_4_tfoperacionescomprobantepago_sel)");
         }
         else
         {
            GXv_int5[1] = 1;
         }
         if ( StringUtil.StrCmp(AV96Operacioneswwds_4_tfoperacionescomprobantepago_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "([OperacionesComprobantePago] IS NULL or ([OperacionesComprobantePago] = ''))");
         }
         if ( ! (DateTime.MinValue==AV99Operacioneswwds_7_tfoperacionesfechadesde) )
         {
            AddWhere(sWhereString, "([OperacionesFechaDesde] >= @AV99Operacioneswwds_7_tfoperacionesfechadesde)");
         }
         else
         {
            GXv_int5[2] = 1;
         }
         if ( ! (DateTime.MinValue==AV100Operacioneswwds_8_tfoperacionesfechadesde_to) )
         {
            AddWhere(sWhereString, "([OperacionesFechaDesde] <= @AV100Operacioneswwds_8_tfoperacionesfechadesde_to)");
         }
         else
         {
            GXv_int5[3] = 1;
         }
         if ( ! (DateTime.MinValue==AV101Operacioneswwds_9_tfoperacionesfechahasta) )
         {
            AddWhere(sWhereString, "([OperacionesFechaHasta] >= @AV101Operacioneswwds_9_tfoperacionesfechahasta)");
         }
         else
         {
            GXv_int5[4] = 1;
         }
         if ( ! (DateTime.MinValue==AV102Operacioneswwds_10_tfoperacionesfechahasta_to) )
         {
            AddWhere(sWhereString, "([OperacionesFechaHasta] <= @AV102Operacioneswwds_10_tfoperacionesfechahasta_to)");
         }
         else
         {
            GXv_int5[5] = 1;
         }
         if ( AV105Operacioneswwds_13_tfoperacionesestado_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV105Operacioneswwds_13_tfoperacionesestado_sels, "[OperacionesEstado] IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         if ( ( AV17OrderedBy == 1 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY [OperacionesTipo], [OperacionesId]";
         }
         else if ( ( AV17OrderedBy == 1 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [OperacionesTipo] DESC, [OperacionesId] DESC";
         }
         else if ( ( AV17OrderedBy == 2 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY [OperacionesTipo], [OperacionesRef]";
         }
         else if ( ( AV17OrderedBy == 2 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [OperacionesTipo] DESC, [OperacionesRef] DESC";
         }
         else if ( ( AV17OrderedBy == 3 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY [OperacionesTipo], [OperacionesNombreRef]";
         }
         else if ( ( AV17OrderedBy == 3 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [OperacionesTipo] DESC, [OperacionesNombreRef] DESC";
         }
         else if ( ( AV17OrderedBy == 4 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY [OperacionesTipo]";
         }
         else if ( ( AV17OrderedBy == 4 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [OperacionesTipo] DESC";
         }
         else if ( ( AV17OrderedBy == 5 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY [OperacionesTipo], [OperacionesTipoES]";
         }
         else if ( ( AV17OrderedBy == 5 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [OperacionesTipo] DESC, [OperacionesTipoES] DESC";
         }
         else if ( ( AV17OrderedBy == 6 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY [OperacionesTipo], [OperacionesImporte]";
         }
         else if ( ( AV17OrderedBy == 6 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [OperacionesTipo] DESC, [OperacionesImporte] DESC";
         }
         else if ( ( AV17OrderedBy == 7 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY [OperacionesTipo], [OperacionesFacturaCod]";
         }
         else if ( ( AV17OrderedBy == 7 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [OperacionesTipo] DESC, [OperacionesFacturaCod] DESC";
         }
         else if ( ( AV17OrderedBy == 8 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY [OperacionesTipo], [OperacionesComprobantePago]";
         }
         else if ( ( AV17OrderedBy == 8 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [OperacionesTipo] DESC, [OperacionesComprobantePago] DESC";
         }
         else if ( ( AV17OrderedBy == 9 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY [OperacionesTipo], [OperacionesFechaAlta]";
         }
         else if ( ( AV17OrderedBy == 9 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [OperacionesTipo] DESC, [OperacionesFechaAlta] DESC";
         }
         else if ( ( AV17OrderedBy == 10 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY [OperacionesTipo], [OperacionesFechaDesde]";
         }
         else if ( ( AV17OrderedBy == 10 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [OperacionesTipo] DESC, [OperacionesFechaDesde] DESC";
         }
         else if ( ( AV17OrderedBy == 11 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY [OperacionesTipo], [OperacionesFechaHasta]";
         }
         else if ( ( AV17OrderedBy == 11 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [OperacionesTipo] DESC, [OperacionesFechaHasta] DESC";
         }
         else if ( ( AV17OrderedBy == 12 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY [OperacionesTipo], [OperacionesFechaPago]";
         }
         else if ( ( AV17OrderedBy == 12 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [OperacionesTipo] DESC, [OperacionesFechaPago] DESC";
         }
         else if ( ( AV17OrderedBy == 13 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY [OperacionesTipo], [OperacionesEstado]";
         }
         else if ( ( AV17OrderedBy == 13 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [OperacionesTipo] DESC, [OperacionesEstado] DESC";
         }
         GXv_Object6[0] = scmdbuf;
         GXv_Object6[1] = GXv_int5;
         return GXv_Object6 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_P00782(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (GxSimpleCollection<string>)dynConstraints[3] , (int)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (DateTime)dynConstraints[7] , (DateTime)dynConstraints[8] , (DateTime)dynConstraints[9] , (DateTime)dynConstraints[10] , (int)dynConstraints[11] , (string)dynConstraints[12] , (DateTime)dynConstraints[13] , (DateTime)dynConstraints[14] , (short)dynConstraints[15] , (bool)dynConstraints[16] , (string)dynConstraints[17] , (long)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (decimal)dynConstraints[22] , (string)dynConstraints[23] );
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
          Object[] prmP00782;
          prmP00782 = new Object[] {
          new ParDef("@lV95Operacioneswwds_3_tfoperacionescomprobantepago",GXType.Char,256,0) ,
          new ParDef("@AV96Operacioneswwds_4_tfoperacionescomprobantepago_sel",GXType.NChar,256,0) ,
          new ParDef("@AV99Operacioneswwds_7_tfoperacionesfechadesde",GXType.Date,8,0) ,
          new ParDef("@AV100Operacioneswwds_8_tfoperacionesfechadesde_to",GXType.Date,8,0) ,
          new ParDef("@AV101Operacioneswwds_9_tfoperacionesfechahasta",GXType.Date,8,0) ,
          new ParDef("@AV102Operacioneswwds_10_tfoperacionesfechahasta_to",GXType.Date,8,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00782", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00782,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[0])[0] = rslt.getString(1, 25);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((decimal[]) buf[2])[0] = rslt.getDecimal(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((string[]) buf[4])[0] = rslt.getString(3, 120);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((string[]) buf[6])[0] = rslt.getString(4, 25);
                ((bool[]) buf[7])[0] = rslt.wasNull(4);
                ((long[]) buf[8])[0] = rslt.getLong(5);
                ((DateTime[]) buf[9])[0] = rslt.getGXDate(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((DateTime[]) buf[11])[0] = rslt.getGXDate(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((string[]) buf[13])[0] = rslt.getString(8, 256);
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
                ((string[]) buf[15])[0] = rslt.getString(9, 3);
                ((bool[]) buf[16])[0] = rslt.wasNull(9);
                ((string[]) buf[17])[0] = rslt.getString(10, 1);
                ((bool[]) buf[18])[0] = rslt.wasNull(10);
                ((string[]) buf[19])[0] = rslt.getString(11, 3);
                ((bool[]) buf[20])[0] = rslt.wasNull(11);
                ((DateTime[]) buf[21])[0] = rslt.getGXDateTime(12);
                ((bool[]) buf[22])[0] = rslt.wasNull(12);
                ((DateTime[]) buf[23])[0] = rslt.getGXDate(13);
                ((bool[]) buf[24])[0] = rslt.wasNull(13);
                return;
       }
    }

 }

}

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
   public class tipocuentawwexport : GXProcedure
   {
      public tipocuentawwexport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public tipocuentawwexport( IGxContext context )
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
         new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWTipoCuenta", out  GXt_boolean1) ;
         AV8IsAuthorized = GXt_boolean1;
         if ( ! AV8IsAuthorized )
         {
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "wwpbaseobjects.notauthorized.aspx"+GXUtil.UrlEncode(StringUtil.RTrim(AV32Pgmname));
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
            S191 ();
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
            S151 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
            /* Execute user subroutine: 'CLOSEDOCUMENT' */
            S181 ();
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
         AV12Filename = GXt_char2 + "TipoCuentaWWExport-" + StringUtil.Trim( StringUtil.Str( (decimal)(AV16Random), 8, 0)) + ".xlsx";
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
         if ( ! ( (0==AV24TFTipoCuentaId) && (0==AV25TFTipoCuentaId_To) ) )
         {
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Tipo de Cuenta", "")) ;
            AV14CellRow = GXt_int3;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Number = AV24TFTipoCuentaId;
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  false, ref  GXt_int3,  (short)(AV15FirstColumn+2),  context.GetMessage( "WWP_TSTo", "")) ;
            AV14CellRow = GXt_int3;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+3, 1, 1).Number = AV25TFTipoCuentaId_To;
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV27TFTipoCuentaNombre_Sel)) ) )
         {
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Tipo de Cuenta", "")) ;
            AV14CellRow = GXt_int3;
            GXt_char2 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV27TFTipoCuentaNombre_Sel)) ? context.GetMessage( "WWP_TitleFilter_EmptyOption", "") : AV27TFTipoCuentaNombre_Sel), out  GXt_char2) ;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV26TFTipoCuentaNombre)) ) )
            {
               GXt_int3 = (short)(AV14CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Tipo de Cuenta", "")) ;
               AV14CellRow = GXt_int3;
               GXt_char2 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV26TFTipoCuentaNombre, out  GXt_char2) ;
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
            }
         }
         if ( ! ( ( AV30TFTipoCuentaConcepto_Sels.Count == 0 ) ) )
         {
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Tipo de Concepto", "")) ;
            AV14CellRow = GXt_int3;
            AV31i = 1;
            AV33GXV1 = 1;
            while ( AV33GXV1 <= AV30TFTipoCuentaConcepto_Sels.Count )
            {
               AV29TFTipoCuentaConcepto_Sel = AV30TFTipoCuentaConcepto_Sels.GetString(AV33GXV1);
               if ( AV31i == 1 )
               {
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = "";
               }
               else
               {
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text+", ";
               }
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text+context.GetMessage( gxdomaintipocuentaconenum.getDescription(context,AV29TFTipoCuentaConcepto_Sel), "");
               AV31i = (long)(AV31i+1);
               AV33GXV1 = (int)(AV33GXV1+1);
            }
         }
         AV14CellRow = (int)(AV14CellRow+2);
      }

      protected void S141( )
      {
         /* 'WRITECOLUMNTITLES' Routine */
         returnInSub = false;
         AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+0, 1, 1).Bold = 1;
         AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+0, 1, 1).Color = 11;
         AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+0, 1, 1).Text = context.GetMessage( "Tipo de Cuenta", "");
         AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Bold = 1;
         AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Color = 11;
         AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = context.GetMessage( "Tipo de Cuenta", "");
         AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+2, 1, 1).Bold = 1;
         AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+2, 1, 1).Color = 11;
         AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+2, 1, 1).Text = context.GetMessage( "Tipo de Concepto", "");
      }

      protected void S151( )
      {
         /* 'WRITEDATA' Routine */
         returnInSub = false;
         AV35Tipocuentawwds_1_filterfulltext = AV19FilterFullText;
         AV36Tipocuentawwds_2_tftipocuentaid = AV24TFTipoCuentaId;
         AV37Tipocuentawwds_3_tftipocuentaid_to = AV25TFTipoCuentaId_To;
         AV38Tipocuentawwds_4_tftipocuentanombre = AV26TFTipoCuentaNombre;
         AV39Tipocuentawwds_5_tftipocuentanombre_sel = AV27TFTipoCuentaNombre_Sel;
         AV40Tipocuentawwds_6_tftipocuentaconcepto_sels = AV30TFTipoCuentaConcepto_Sels;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A636TipoCuentaConcepto ,
                                              AV40Tipocuentawwds_6_tftipocuentaconcepto_sels ,
                                              AV36Tipocuentawwds_2_tftipocuentaid ,
                                              AV37Tipocuentawwds_3_tftipocuentaid_to ,
                                              AV39Tipocuentawwds_5_tftipocuentanombre_sel ,
                                              AV38Tipocuentawwds_4_tftipocuentanombre ,
                                              AV40Tipocuentawwds_6_tftipocuentaconcepto_sels.Count ,
                                              A483TipoCuentaId ,
                                              A484TipoCuentaNombre ,
                                              AV17OrderedBy ,
                                              AV18OrderedDsc ,
                                              AV35Tipocuentawwds_1_filterfulltext } ,
                                              new int[]{
                                              TypeConstants.LONG, TypeConstants.LONG, TypeConstants.INT, TypeConstants.LONG, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV38Tipocuentawwds_4_tftipocuentanombre = StringUtil.PadR( StringUtil.RTrim( AV38Tipocuentawwds_4_tftipocuentanombre), 120, "%");
         /* Using cursor P00DD2 */
         pr_default.execute(0, new Object[] {AV36Tipocuentawwds_2_tftipocuentaid, AV37Tipocuentawwds_3_tftipocuentaid_to, lV38Tipocuentawwds_4_tftipocuentanombre, AV39Tipocuentawwds_5_tftipocuentanombre_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A484TipoCuentaNombre = P00DD2_A484TipoCuentaNombre[0];
            A483TipoCuentaId = P00DD2_A483TipoCuentaId[0];
            A636TipoCuentaConcepto = P00DD2_A636TipoCuentaConcepto[0];
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV35Tipocuentawwds_1_filterfulltext)) || ( ( StringUtil.Like( StringUtil.Str( (decimal)(A483TipoCuentaId), 18, 0) , StringUtil.PadR( "%" + AV35Tipocuentawwds_1_filterfulltext , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A484TipoCuentaNombre) , StringUtil.PadR( "%" + StringUtil.Upper( AV35Tipocuentawwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( context.GetMessage( "saldo por cuentas", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV35Tipocuentawwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A636TipoCuentaConcepto, "SAL") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "usada en centro costo", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV35Tipocuentawwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A636TipoCuentaConcepto, "COS") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "otros", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV35Tipocuentawwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A636TipoCuentaConcepto, "OTR") == 0 ) ) ) )
            {
               AV14CellRow = (int)(AV14CellRow+1);
               /* Execute user subroutine: 'BEFOREWRITELINE' */
               S162 ();
               if ( returnInSub )
               {
                  pr_default.close(0);
                  returnInSub = true;
                  if (true) return;
               }
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+0, 1, 1).Number = A483TipoCuentaId;
               GXt_char2 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A484TipoCuentaNombre, out  GXt_char2) ;
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+2, 1, 1).Text = context.GetMessage( gxdomaintipocuentaconenum.getDescription(context,A636TipoCuentaConcepto), "");
               /* Execute user subroutine: 'AFTERWRITELINE' */
               S172 ();
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

      protected void S181( )
      {
         /* 'CLOSEDOCUMENT' Routine */
         returnInSub = false;
         AV11ExcelDocument.Save();
         /* Execute user subroutine: 'CHECKSTATUS' */
         S121 ();
         if (returnInSub) return;
         AV11ExcelDocument.Close();
         AV20Session.Set("WWPExportFilePath", AV12Filename);
         AV20Session.Set("WWPExportFileName", "TipoCuentaWWExport.xlsx");
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

      protected void S191( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV20Session.Get("TipoCuentaWWGridState"), "") == 0 )
         {
            AV22GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "TipoCuentaWWGridState"), null, "", "");
         }
         else
         {
            AV22GridState.FromXml(AV20Session.Get("TipoCuentaWWGridState"), null, "", "");
         }
         AV17OrderedBy = AV22GridState.gxTpr_Orderedby;
         AV18OrderedDsc = AV22GridState.gxTpr_Ordereddsc;
         AV41GXV2 = 1;
         while ( AV41GXV2 <= AV22GridState.gxTpr_Filtervalues.Count )
         {
            AV23GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV22GridState.gxTpr_Filtervalues.Item(AV41GXV2));
            if ( StringUtil.StrCmp(AV23GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV19FilterFullText = AV23GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV23GridStateFilterValue.gxTpr_Name, "TFTIPOCUENTAID") == 0 )
            {
               AV24TFTipoCuentaId = (long)(Math.Round(NumberUtil.Val( AV23GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV25TFTipoCuentaId_To = (long)(Math.Round(NumberUtil.Val( AV23GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV23GridStateFilterValue.gxTpr_Name, "TFTIPOCUENTANOMBRE") == 0 )
            {
               AV26TFTipoCuentaNombre = AV23GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV23GridStateFilterValue.gxTpr_Name, "TFTIPOCUENTANOMBRE_SEL") == 0 )
            {
               AV27TFTipoCuentaNombre_Sel = AV23GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV23GridStateFilterValue.gxTpr_Name, "TFTIPOCUENTACONCEPTO_SEL") == 0 )
            {
               AV28TFTipoCuentaConcepto_SelsJson = AV23GridStateFilterValue.gxTpr_Value;
               AV30TFTipoCuentaConcepto_Sels.FromJSonString(AV28TFTipoCuentaConcepto_SelsJson, null);
            }
            AV41GXV2 = (int)(AV41GXV2+1);
         }
      }

      protected void S162( )
      {
         /* 'BEFOREWRITELINE' Routine */
         returnInSub = false;
      }

      protected void S172( )
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
         AV32Pgmname = "";
         GXKey = "";
         GXEncryptionTmp = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV11ExcelDocument = new ExcelDocumentI();
         AV19FilterFullText = "";
         AV27TFTipoCuentaNombre_Sel = "";
         AV26TFTipoCuentaNombre = "";
         AV30TFTipoCuentaConcepto_Sels = new GxSimpleCollection<string>();
         AV29TFTipoCuentaConcepto_Sel = "";
         AV35Tipocuentawwds_1_filterfulltext = "";
         AV38Tipocuentawwds_4_tftipocuentanombre = "";
         AV39Tipocuentawwds_5_tftipocuentanombre_sel = "";
         AV40Tipocuentawwds_6_tftipocuentaconcepto_sels = new GxSimpleCollection<string>();
         lV38Tipocuentawwds_4_tftipocuentanombre = "";
         A636TipoCuentaConcepto = "";
         A484TipoCuentaNombre = "";
         P00DD2_A484TipoCuentaNombre = new string[] {""} ;
         P00DD2_A483TipoCuentaId = new long[1] ;
         P00DD2_A636TipoCuentaConcepto = new string[] {""} ;
         GXt_char2 = "";
         AV20Session = context.GetSession();
         AV22GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV23GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV28TFTipoCuentaConcepto_SelsJson = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.tipocuentawwexport__default(),
            new Object[][] {
                new Object[] {
               P00DD2_A484TipoCuentaNombre, P00DD2_A483TipoCuentaId, P00DD2_A636TipoCuentaConcepto
               }
            }
         );
         AV32Pgmname = "TipoCuentaWWExport";
         /* GeneXus formulas. */
         AV32Pgmname = "TipoCuentaWWExport";
      }

      private short GXt_int3 ;
      private short AV17OrderedBy ;
      private int AV14CellRow ;
      private int AV15FirstColumn ;
      private int AV16Random ;
      private int AV33GXV1 ;
      private int AV40Tipocuentawwds_6_tftipocuentaconcepto_sels_Count ;
      private int AV41GXV2 ;
      private long AV24TFTipoCuentaId ;
      private long AV25TFTipoCuentaId_To ;
      private long AV31i ;
      private long AV36Tipocuentawwds_2_tftipocuentaid ;
      private long AV37Tipocuentawwds_3_tftipocuentaid_to ;
      private long A483TipoCuentaId ;
      private string AV32Pgmname ;
      private string GXKey ;
      private string GXEncryptionTmp ;
      private string AV27TFTipoCuentaNombre_Sel ;
      private string AV26TFTipoCuentaNombre ;
      private string AV29TFTipoCuentaConcepto_Sel ;
      private string AV38Tipocuentawwds_4_tftipocuentanombre ;
      private string AV39Tipocuentawwds_5_tftipocuentanombre_sel ;
      private string lV38Tipocuentawwds_4_tftipocuentanombre ;
      private string A636TipoCuentaConcepto ;
      private string A484TipoCuentaNombre ;
      private string GXt_char2 ;
      private bool AV8IsAuthorized ;
      private bool GXt_boolean1 ;
      private bool returnInSub ;
      private bool AV18OrderedDsc ;
      private string AV28TFTipoCuentaConcepto_SelsJson ;
      private string AV12Filename ;
      private string AV13ErrorMessage ;
      private string AV19FilterFullText ;
      private string AV35Tipocuentawwds_1_filterfulltext ;
      private IGxSession AV20Session ;
      private ExcelDocumentI AV11ExcelDocument ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GxSimpleCollection<string> AV30TFTipoCuentaConcepto_Sels ;
      private GxSimpleCollection<string> AV40Tipocuentawwds_6_tftipocuentaconcepto_sels ;
      private IDataStoreProvider pr_default ;
      private string[] P00DD2_A484TipoCuentaNombre ;
      private long[] P00DD2_A483TipoCuentaId ;
      private string[] P00DD2_A636TipoCuentaConcepto ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV22GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV23GridStateFilterValue ;
      private string aP0_Filename ;
      private string aP1_ErrorMessage ;
   }

   public class tipocuentawwexport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00DD2( IGxContext context ,
                                             string A636TipoCuentaConcepto ,
                                             GxSimpleCollection<string> AV40Tipocuentawwds_6_tftipocuentaconcepto_sels ,
                                             long AV36Tipocuentawwds_2_tftipocuentaid ,
                                             long AV37Tipocuentawwds_3_tftipocuentaid_to ,
                                             string AV39Tipocuentawwds_5_tftipocuentanombre_sel ,
                                             string AV38Tipocuentawwds_4_tftipocuentanombre ,
                                             int AV40Tipocuentawwds_6_tftipocuentaconcepto_sels_Count ,
                                             long A483TipoCuentaId ,
                                             string A484TipoCuentaNombre ,
                                             short AV17OrderedBy ,
                                             bool AV18OrderedDsc ,
                                             string AV35Tipocuentawwds_1_filterfulltext )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int4 = new short[4];
         Object[] GXv_Object5 = new Object[2];
         scmdbuf = "SELECT [TipoCuentaNombre], [TipoCuentaId], [TipoCuentaConcepto] FROM [TipoCuenta]";
         if ( ! (0==AV36Tipocuentawwds_2_tftipocuentaid) )
         {
            AddWhere(sWhereString, "([TipoCuentaId] >= @AV36Tipocuentawwds_2_tftipocuentaid)");
         }
         else
         {
            GXv_int4[0] = 1;
         }
         if ( ! (0==AV37Tipocuentawwds_3_tftipocuentaid_to) )
         {
            AddWhere(sWhereString, "([TipoCuentaId] <= @AV37Tipocuentawwds_3_tftipocuentaid_to)");
         }
         else
         {
            GXv_int4[1] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV39Tipocuentawwds_5_tftipocuentanombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV38Tipocuentawwds_4_tftipocuentanombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER([TipoCuentaNombre]) like UPPER(@lV38Tipocuentawwds_4_tftipocuentanombre))");
         }
         else
         {
            GXv_int4[2] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV39Tipocuentawwds_5_tftipocuentanombre_sel)) && ! ( StringUtil.StrCmp(AV39Tipocuentawwds_5_tftipocuentanombre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([TipoCuentaNombre] = @AV39Tipocuentawwds_5_tftipocuentanombre_sel)");
         }
         else
         {
            GXv_int4[3] = 1;
         }
         if ( StringUtil.StrCmp(AV39Tipocuentawwds_5_tftipocuentanombre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([TipoCuentaNombre] = ''))");
         }
         if ( AV40Tipocuentawwds_6_tftipocuentaconcepto_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV40Tipocuentawwds_6_tftipocuentaconcepto_sels, "[TipoCuentaConcepto] IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         if ( ( AV17OrderedBy == 1 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY [TipoCuentaNombre]";
         }
         else if ( ( AV17OrderedBy == 1 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [TipoCuentaNombre] DESC";
         }
         else if ( ( AV17OrderedBy == 2 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY [TipoCuentaId]";
         }
         else if ( ( AV17OrderedBy == 2 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [TipoCuentaId] DESC";
         }
         else if ( ( AV17OrderedBy == 3 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY [TipoCuentaConcepto]";
         }
         else if ( ( AV17OrderedBy == 3 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [TipoCuentaConcepto] DESC";
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
                     return conditional_P00DD2(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (long)dynConstraints[2] , (long)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (int)dynConstraints[6] , (long)dynConstraints[7] , (string)dynConstraints[8] , (short)dynConstraints[9] , (bool)dynConstraints[10] , (string)dynConstraints[11] );
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
          Object[] prmP00DD2;
          prmP00DD2 = new Object[] {
          new ParDef("@AV36Tipocuentawwds_2_tftipocuentaid",GXType.Decimal,18,0) ,
          new ParDef("@AV37Tipocuentawwds_3_tftipocuentaid_to",GXType.Decimal,18,0) ,
          new ParDef("@lV38Tipocuentawwds_4_tftipocuentanombre",GXType.Char,120,0) ,
          new ParDef("@AV39Tipocuentawwds_5_tftipocuentanombre_sel",GXType.NChar,120,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00DD2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00DD2,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[0])[0] = rslt.getString(1, 120);
                ((long[]) buf[1])[0] = rslt.getLong(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 3);
                return;
       }
    }

 }

}

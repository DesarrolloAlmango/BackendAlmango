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
   public class listaagruserwwexport : GXProcedure
   {
      public listaagruserwwexport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public listaagruserwwexport( IGxContext context )
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
         new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWListaAgrUser", out  GXt_boolean1) ;
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
         AV12Filename = GXt_char2 + "ListaAgrUserWWExport-" + StringUtil.Trim( StringUtil.Str( (decimal)(AV16Random), 8, 0)) + ".xlsx";
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
         if ( ! ( ( AV51TFListaAgrUserEstado_Sels.Count == 0 ) ) )
         {
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Estado", "")) ;
            AV14CellRow = GXt_int3;
            AV53i = 1;
            AV59GXV1 = 1;
            while ( AV59GXV1 <= AV51TFListaAgrUserEstado_Sels.Count )
            {
               AV52TFListaAgrUserEstado_Sel = AV51TFListaAgrUserEstado_Sels.GetString(AV59GXV1);
               if ( AV53i == 1 )
               {
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = "";
               }
               else
               {
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text+", ";
               }
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text+context.GetMessage( gxdomainestadoenum.getDescription(context,AV52TFListaAgrUserEstado_Sel), "");
               AV53i = (long)(AV53i+1);
               AV59GXV1 = (int)(AV59GXV1+1);
            }
         }
         AV14CellRow = (int)(AV14CellRow+2);
      }

      protected void S141( )
      {
         /* 'WRITECOLUMNTITLES' Routine */
         returnInSub = false;
         AV41VisibleColumnCount = 0;
         if ( StringUtil.StrCmp(AV29Session.Get("ListaAgrUserWWColumnsSelector"), "") != 0 )
         {
            AV36ColumnsSelectorXML = AV29Session.Get("ListaAgrUserWWColumnsSelector");
            AV33ColumnsSelector.FromXml(AV36ColumnsSelectorXML, null, "", "");
         }
         else
         {
            /* Execute user subroutine: 'INITIALIZECOLUMNSSELECTOR' */
            S151 ();
            if (returnInSub) return;
         }
         AV33ColumnsSelector.gxTpr_Columns.Sort("Order");
         AV60GXV2 = 1;
         while ( AV60GXV2 <= AV33ColumnsSelector.gxTpr_Columns.Count )
         {
            AV35ColumnsSelector_Column = ((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV33ColumnsSelector.gxTpr_Columns.Item(AV60GXV2));
            if ( AV35ColumnsSelector_Column.gxTpr_Isvisible )
            {
               AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV41VisibleColumnCount), 1, 1).Text = context.GetMessage( (String.IsNullOrEmpty(StringUtil.RTrim( AV35ColumnsSelector_Column.gxTpr_Displayname)) ? AV35ColumnsSelector_Column.gxTpr_Columnname : AV35ColumnsSelector_Column.gxTpr_Displayname), "");
               AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV41VisibleColumnCount), 1, 1).Bold = 1;
               AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV41VisibleColumnCount), 1, 1).Color = 11;
               AV41VisibleColumnCount = (long)(AV41VisibleColumnCount+1);
            }
            AV60GXV2 = (int)(AV60GXV2+1);
         }
      }

      protected void S161( )
      {
         /* 'WRITEDATA' Routine */
         returnInSub = false;
         AV62Listaagruserwwds_1_filterfulltext = AV19FilterFullText;
         AV63Listaagruserwwds_2_tflistaagruserestado_sels = AV51TFListaAgrUserEstado_Sels;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A599ListaAgrUserEstado ,
                                              AV63Listaagruserwwds_2_tflistaagruserestado_sels ,
                                              AV62Listaagruserwwds_1_filterfulltext ,
                                              AV63Listaagruserwwds_2_tflistaagruserestado_sels.Count ,
                                              A590Listaid ,
                                              A587SecUserFullName ,
                                              AV17OrderedBy ,
                                              AV18OrderedDsc } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.LONG, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV62Listaagruserwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV62Listaagruserwwds_1_filterfulltext), "%", "");
         lV62Listaagruserwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV62Listaagruserwwds_1_filterfulltext), "%", "");
         /* Using cursor P007P2 */
         pr_default.execute(0, new Object[] {lV62Listaagruserwwds_1_filterfulltext, lV62Listaagruserwwds_1_filterfulltext});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A587SecUserFullName = P007P2_A587SecUserFullName[0];
            A590Listaid = P007P2_A590Listaid[0];
            A599ListaAgrUserEstado = P007P2_A599ListaAgrUserEstado[0];
            A592ListaNombre = P007P2_A592ListaNombre[0];
            A18SecUserId = P007P2_A18SecUserId[0];
            A592ListaNombre = P007P2_A592ListaNombre[0];
            A587SecUserFullName = P007P2_A587SecUserFullName[0];
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
            AV64GXV3 = 1;
            while ( AV64GXV3 <= AV33ColumnsSelector.gxTpr_Columns.Count )
            {
               AV35ColumnsSelector_Column = ((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV33ColumnsSelector.gxTpr_Columns.Item(AV64GXV3));
               if ( AV35ColumnsSelector_Column.gxTpr_Isvisible )
               {
                  if ( StringUtil.StrCmp(AV35ColumnsSelector_Column.gxTpr_Columnname, "Listaid") == 0 )
                  {
                     GXt_char2 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A592ListaNombre, out  GXt_char2) ;
                     AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV41VisibleColumnCount), 1, 1).Text = GXt_char2;
                  }
                  else if ( StringUtil.StrCmp(AV35ColumnsSelector_Column.gxTpr_Columnname, "SecUserId") == 0 )
                  {
                     GXt_char2 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A592ListaNombre, out  GXt_char2) ;
                     AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV41VisibleColumnCount), 1, 1).Text = GXt_char2;
                  }
                  else if ( StringUtil.StrCmp(AV35ColumnsSelector_Column.gxTpr_Columnname, "SecUserFullName") == 0 )
                  {
                     GXt_char2 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A587SecUserFullName, out  GXt_char2) ;
                     AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV41VisibleColumnCount), 1, 1).Text = GXt_char2;
                  }
                  else if ( StringUtil.StrCmp(AV35ColumnsSelector_Column.gxTpr_Columnname, "ListaAgrUserEstado") == 0 )
                  {
                     AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV41VisibleColumnCount), 1, 1).Text = context.GetMessage( gxdomainestadoenum.getDescription(context,A599ListaAgrUserEstado), "");
                  }
                  AV41VisibleColumnCount = (long)(AV41VisibleColumnCount+1);
               }
               AV64GXV3 = (int)(AV64GXV3+1);
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
         AV29Session.Set("WWPExportFilePath", AV12Filename);
         AV29Session.Set("WWPExportFileName", "ListaAgrUserWWExport.xlsx");
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
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV33ColumnsSelector,  "Listaid",  "",  "Listaid",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV33ColumnsSelector,  "SecUserId",  "",  "Usuario Nro.",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV33ColumnsSelector,  "SecUserFullName",  "",  "Nombre Completo",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV33ColumnsSelector,  "ListaAgrUserEstado",  "",  "Estado",  true,  "") ;
         GXt_char2 = AV37UserCustomValue;
         new GeneXus.Programs.wwpbaseobjects.loadcolumnsselectorstate(context ).execute(  "ListaAgrUserWWColumnsSelector", out  GXt_char2) ;
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
         if ( StringUtil.StrCmp(AV29Session.Get("ListaAgrUserWWGridState"), "") == 0 )
         {
            AV31GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "ListaAgrUserWWGridState"), null, "", "");
         }
         else
         {
            AV31GridState.FromXml(AV29Session.Get("ListaAgrUserWWGridState"), null, "", "");
         }
         AV17OrderedBy = AV31GridState.gxTpr_Orderedby;
         AV18OrderedDsc = AV31GridState.gxTpr_Ordereddsc;
         AV65GXV4 = 1;
         while ( AV65GXV4 <= AV31GridState.gxTpr_Filtervalues.Count )
         {
            AV32GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV31GridState.gxTpr_Filtervalues.Item(AV65GXV4));
            if ( StringUtil.StrCmp(AV32GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV19FilterFullText = AV32GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV32GridStateFilterValue.gxTpr_Name, "TFLISTAAGRUSERESTADO_SEL") == 0 )
            {
               AV50TFListaAgrUserEstado_SelsJson = AV32GridStateFilterValue.gxTpr_Value;
               AV51TFListaAgrUserEstado_Sels.FromJSonString(AV50TFListaAgrUserEstado_SelsJson, null);
            }
            AV65GXV4 = (int)(AV65GXV4+1);
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
         AV51TFListaAgrUserEstado_Sels = new GxSimpleCollection<string>();
         AV52TFListaAgrUserEstado_Sel = "";
         AV29Session = context.GetSession();
         AV36ColumnsSelectorXML = "";
         AV33ColumnsSelector = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector(context);
         AV35ColumnsSelector_Column = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column(context);
         AV62Listaagruserwwds_1_filterfulltext = "";
         AV63Listaagruserwwds_2_tflistaagruserestado_sels = new GxSimpleCollection<string>();
         lV62Listaagruserwwds_1_filterfulltext = "";
         A599ListaAgrUserEstado = "";
         A587SecUserFullName = "";
         P007P2_A587SecUserFullName = new string[] {""} ;
         P007P2_A590Listaid = new long[1] ;
         P007P2_A599ListaAgrUserEstado = new string[] {""} ;
         P007P2_A592ListaNombre = new string[] {""} ;
         P007P2_A18SecUserId = new long[1] ;
         A592ListaNombre = "";
         AV37UserCustomValue = "";
         GXt_char2 = "";
         AV34ColumnsSelectorAux = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector(context);
         AV31GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV32GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV50TFListaAgrUserEstado_SelsJson = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.listaagruserwwexport__default(),
            new Object[][] {
                new Object[] {
               P007P2_A587SecUserFullName, P007P2_A590Listaid, P007P2_A599ListaAgrUserEstado, P007P2_A592ListaNombre, P007P2_A18SecUserId
               }
            }
         );
         AV58Pgmname = "ListaAgrUserWWExport";
         /* GeneXus formulas. */
         AV58Pgmname = "ListaAgrUserWWExport";
      }

      private short GXt_int3 ;
      private short AV17OrderedBy ;
      private int AV14CellRow ;
      private int AV15FirstColumn ;
      private int AV16Random ;
      private int AV59GXV1 ;
      private int AV60GXV2 ;
      private int AV63Listaagruserwwds_2_tflistaagruserestado_sels_Count ;
      private int AV64GXV3 ;
      private int AV65GXV4 ;
      private long AV53i ;
      private long AV41VisibleColumnCount ;
      private long A590Listaid ;
      private long A18SecUserId ;
      private string AV58Pgmname ;
      private string GXKey ;
      private string GXEncryptionTmp ;
      private string AV52TFListaAgrUserEstado_Sel ;
      private string A599ListaAgrUserEstado ;
      private string A592ListaNombre ;
      private string GXt_char2 ;
      private bool AV8IsAuthorized ;
      private bool GXt_boolean1 ;
      private bool returnInSub ;
      private bool AV18OrderedDsc ;
      private string AV36ColumnsSelectorXML ;
      private string AV37UserCustomValue ;
      private string AV50TFListaAgrUserEstado_SelsJson ;
      private string AV12Filename ;
      private string AV13ErrorMessage ;
      private string AV19FilterFullText ;
      private string AV62Listaagruserwwds_1_filterfulltext ;
      private string lV62Listaagruserwwds_1_filterfulltext ;
      private string A587SecUserFullName ;
      private IGxSession AV29Session ;
      private ExcelDocumentI AV11ExcelDocument ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GxSimpleCollection<string> AV51TFListaAgrUserEstado_Sels ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector AV33ColumnsSelector ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column AV35ColumnsSelector_Column ;
      private GxSimpleCollection<string> AV63Listaagruserwwds_2_tflistaagruserestado_sels ;
      private IDataStoreProvider pr_default ;
      private string[] P007P2_A587SecUserFullName ;
      private long[] P007P2_A590Listaid ;
      private string[] P007P2_A599ListaAgrUserEstado ;
      private string[] P007P2_A592ListaNombre ;
      private long[] P007P2_A18SecUserId ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector AV34ColumnsSelectorAux ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV31GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV32GridStateFilterValue ;
      private string aP0_Filename ;
      private string aP1_ErrorMessage ;
   }

   public class listaagruserwwexport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P007P2( IGxContext context ,
                                             string A599ListaAgrUserEstado ,
                                             GxSimpleCollection<string> AV63Listaagruserwwds_2_tflistaagruserestado_sels ,
                                             string AV62Listaagruserwwds_1_filterfulltext ,
                                             int AV63Listaagruserwwds_2_tflistaagruserestado_sels_Count ,
                                             long A590Listaid ,
                                             string A587SecUserFullName ,
                                             short AV17OrderedBy ,
                                             bool AV18OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int4 = new short[2];
         Object[] GXv_Object5 = new Object[2];
         scmdbuf = "SELECT T3.[SecUserFullName], T1.[Listaid], T1.[ListaAgrUserEstado], T2.[ListaNombre], T1.[SecUserId] FROM (([ListaAgrUser] T1 INNER JOIN [Lista] T2 ON T2.[Listaid] = T1.[Listaid]) INNER JOIN [SecUser] T3 ON T3.[SecUserId] = T1.[SecUserId])";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Listaagruserwwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( CONVERT( char(18), CAST(T1.[Listaid] AS decimal(18,0))) like '%' + @lV62Listaagruserwwds_1_filterfulltext) or ( UPPER(T3.[SecUserFullName]) like '%' + UPPER(@lV62Listaagruserwwds_1_filterfulltext)))");
         }
         else
         {
            GXv_int4[0] = 1;
            GXv_int4[1] = 1;
         }
         if ( AV63Listaagruserwwds_2_tflistaagruserestado_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV63Listaagruserwwds_2_tflistaagruserestado_sels, "T1.[ListaAgrUserEstado] IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         if ( ( AV17OrderedBy == 1 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[ListaAgrUserEstado]";
         }
         else if ( ( AV17OrderedBy == 1 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[ListaAgrUserEstado] DESC";
         }
         else if ( ( AV17OrderedBy == 2 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[Listaid]";
         }
         else if ( ( AV17OrderedBy == 2 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[Listaid] DESC";
         }
         else if ( ( AV17OrderedBy == 3 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[SecUserId]";
         }
         else if ( ( AV17OrderedBy == 3 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[SecUserId] DESC";
         }
         else if ( ( AV17OrderedBy == 4 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T3.[SecUserFullName]";
         }
         else if ( ( AV17OrderedBy == 4 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T3.[SecUserFullName] DESC";
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
                     return conditional_P007P2(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (int)dynConstraints[3] , (long)dynConstraints[4] , (string)dynConstraints[5] , (short)dynConstraints[6] , (bool)dynConstraints[7] );
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
          Object[] prmP007P2;
          prmP007P2 = new Object[] {
          new ParDef("@lV62Listaagruserwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV62Listaagruserwwds_1_filterfulltext",GXType.VarChar,100,0)
          };
          def= new CursorDef[] {
              new CursorDef("P007P2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP007P2,100, GxCacheFrequency.OFF ,true,false )
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
                ((long[]) buf[1])[0] = rslt.getLong(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 3);
                ((string[]) buf[3])[0] = rslt.getString(4, 80);
                ((long[]) buf[4])[0] = rslt.getLong(5);
                return;
       }
    }

 }

}

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
   public class estadoswwexport : GXProcedure
   {
      public estadoswwexport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public estadoswwexport( IGxContext context )
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
         new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWEstados", out  GXt_boolean1) ;
         AV8IsAuthorized = GXt_boolean1;
         if ( ! AV8IsAuthorized )
         {
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "wwpbaseobjects.notauthorized.aspx"+GXUtil.UrlEncode(StringUtil.RTrim(AV40Pgmname));
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
         AV12Filename = GXt_char2 + "EstadosWWExport-" + StringUtil.Trim( StringUtil.Str( (decimal)(AV16Random), 8, 0)) + ".xlsx";
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
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV36TFEstadosTipo_Sel)) ) )
         {
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Tipo de Estados", "")) ;
            AV14CellRow = GXt_int3;
            GXt_char2 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV36TFEstadosTipo_Sel)) ? context.GetMessage( "WWP_TitleFilter_EmptyOption", "") : AV36TFEstadosTipo_Sel), out  GXt_char2) ;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV35TFEstadosTipo)) ) )
            {
               GXt_int3 = (short)(AV14CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Tipo de Estados", "")) ;
               AV14CellRow = GXt_int3;
               GXt_char2 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV35TFEstadosTipo, out  GXt_char2) ;
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV38TFEstadosDescrip_Sel)) ) )
         {
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Descripción", "")) ;
            AV14CellRow = GXt_int3;
            GXt_char2 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV38TFEstadosDescrip_Sel)) ? context.GetMessage( "WWP_TitleFilter_EmptyOption", "") : AV38TFEstadosDescrip_Sel), out  GXt_char2) ;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV37TFEstadosDescrip)) ) )
            {
               GXt_int3 = (short)(AV14CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Descripción", "")) ;
               AV14CellRow = GXt_int3;
               GXt_char2 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV37TFEstadosDescrip, out  GXt_char2) ;
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
            }
         }
         AV14CellRow = (int)(AV14CellRow+2);
      }

      protected void S141( )
      {
         /* 'WRITECOLUMNTITLES' Routine */
         returnInSub = false;
         AV32VisibleColumnCount = 0;
         if ( StringUtil.StrCmp(AV20Session.Get("EstadosWWColumnsSelector"), "") != 0 )
         {
            AV27ColumnsSelectorXML = AV20Session.Get("EstadosWWColumnsSelector");
            AV24ColumnsSelector.FromXml(AV27ColumnsSelectorXML, null, "", "");
         }
         else
         {
            /* Execute user subroutine: 'INITIALIZECOLUMNSSELECTOR' */
            S151 ();
            if (returnInSub) return;
         }
         AV24ColumnsSelector.gxTpr_Columns.Sort("Order");
         AV41GXV1 = 1;
         while ( AV41GXV1 <= AV24ColumnsSelector.gxTpr_Columns.Count )
         {
            AV26ColumnsSelector_Column = ((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV24ColumnsSelector.gxTpr_Columns.Item(AV41GXV1));
            if ( AV26ColumnsSelector_Column.gxTpr_Isvisible )
            {
               AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV32VisibleColumnCount), 1, 1).Text = context.GetMessage( (String.IsNullOrEmpty(StringUtil.RTrim( AV26ColumnsSelector_Column.gxTpr_Displayname)) ? AV26ColumnsSelector_Column.gxTpr_Columnname : AV26ColumnsSelector_Column.gxTpr_Displayname), "");
               AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV32VisibleColumnCount), 1, 1).Bold = 1;
               AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV32VisibleColumnCount), 1, 1).Color = 11;
               AV32VisibleColumnCount = (long)(AV32VisibleColumnCount+1);
            }
            AV41GXV1 = (int)(AV41GXV1+1);
         }
      }

      protected void S161( )
      {
         /* 'WRITEDATA' Routine */
         returnInSub = false;
         AV43Estadoswwds_1_filterfulltext = AV19FilterFullText;
         AV44Estadoswwds_2_tfestadostipo = AV35TFEstadosTipo;
         AV45Estadoswwds_3_tfestadostipo_sel = AV36TFEstadosTipo_Sel;
         AV46Estadoswwds_4_tfestadosdescrip = AV37TFEstadosDescrip;
         AV47Estadoswwds_5_tfestadosdescrip_sel = AV38TFEstadosDescrip_Sel;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV43Estadoswwds_1_filterfulltext ,
                                              AV45Estadoswwds_3_tfestadostipo_sel ,
                                              AV44Estadoswwds_2_tfestadostipo ,
                                              AV47Estadoswwds_5_tfestadosdescrip_sel ,
                                              AV46Estadoswwds_4_tfestadosdescrip ,
                                              A107EstadosTipo ,
                                              A158EstadosDescrip ,
                                              AV17OrderedBy ,
                                              AV18OrderedDsc } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV43Estadoswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV43Estadoswwds_1_filterfulltext), "%", "");
         lV43Estadoswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV43Estadoswwds_1_filterfulltext), "%", "");
         lV44Estadoswwds_2_tfestadostipo = StringUtil.PadR( StringUtil.RTrim( AV44Estadoswwds_2_tfestadostipo), 3, "%");
         lV46Estadoswwds_4_tfestadosdescrip = StringUtil.PadR( StringUtil.RTrim( AV46Estadoswwds_4_tfestadosdescrip), 80, "%");
         /* Using cursor P00C52 */
         pr_default.execute(0, new Object[] {lV43Estadoswwds_1_filterfulltext, lV43Estadoswwds_1_filterfulltext, lV44Estadoswwds_2_tfestadostipo, AV45Estadoswwds_3_tfestadostipo_sel, lV46Estadoswwds_4_tfestadosdescrip, AV47Estadoswwds_5_tfestadosdescrip_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A158EstadosDescrip = P00C52_A158EstadosDescrip[0];
            A107EstadosTipo = P00C52_A107EstadosTipo[0];
            AV14CellRow = (int)(AV14CellRow+1);
            /* Execute user subroutine: 'BEFOREWRITELINE' */
            S172 ();
            if ( returnInSub )
            {
               pr_default.close(0);
               returnInSub = true;
               if (true) return;
            }
            AV32VisibleColumnCount = 0;
            AV48GXV2 = 1;
            while ( AV48GXV2 <= AV24ColumnsSelector.gxTpr_Columns.Count )
            {
               AV26ColumnsSelector_Column = ((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV24ColumnsSelector.gxTpr_Columns.Item(AV48GXV2));
               if ( AV26ColumnsSelector_Column.gxTpr_Isvisible )
               {
                  if ( StringUtil.StrCmp(AV26ColumnsSelector_Column.gxTpr_Columnname, "EstadosTipo") == 0 )
                  {
                     GXt_char2 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A107EstadosTipo, out  GXt_char2) ;
                     AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV32VisibleColumnCount), 1, 1).Text = GXt_char2;
                  }
                  else if ( StringUtil.StrCmp(AV26ColumnsSelector_Column.gxTpr_Columnname, "EstadosDescrip") == 0 )
                  {
                     GXt_char2 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A158EstadosDescrip, out  GXt_char2) ;
                     AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV32VisibleColumnCount), 1, 1).Text = GXt_char2;
                  }
                  AV32VisibleColumnCount = (long)(AV32VisibleColumnCount+1);
               }
               AV48GXV2 = (int)(AV48GXV2+1);
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
         AV20Session.Set("WWPExportFilePath", AV12Filename);
         AV20Session.Set("WWPExportFileName", "EstadosWWExport.xlsx");
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
         AV24ColumnsSelector = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector(context);
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV24ColumnsSelector,  "EstadosTipo",  "",  "Tipo de Estados",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV24ColumnsSelector,  "EstadosDescrip",  "",  "Descripción",  true,  "") ;
         GXt_char2 = AV28UserCustomValue;
         new GeneXus.Programs.wwpbaseobjects.loadcolumnsselectorstate(context ).execute(  "EstadosWWColumnsSelector", out  GXt_char2) ;
         AV28UserCustomValue = GXt_char2;
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV28UserCustomValue)) ) )
         {
            AV25ColumnsSelectorAux.FromXml(AV28UserCustomValue, null, "", "");
            new GeneXus.Programs.wwpbaseobjects.wwp_columnselector_updatecolumns(context ).execute( ref  AV25ColumnsSelectorAux, ref  AV24ColumnsSelector) ;
         }
      }

      protected void S201( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV20Session.Get("EstadosWWGridState"), "") == 0 )
         {
            AV22GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "EstadosWWGridState"), null, "", "");
         }
         else
         {
            AV22GridState.FromXml(AV20Session.Get("EstadosWWGridState"), null, "", "");
         }
         AV17OrderedBy = AV22GridState.gxTpr_Orderedby;
         AV18OrderedDsc = AV22GridState.gxTpr_Ordereddsc;
         AV49GXV3 = 1;
         while ( AV49GXV3 <= AV22GridState.gxTpr_Filtervalues.Count )
         {
            AV23GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV22GridState.gxTpr_Filtervalues.Item(AV49GXV3));
            if ( StringUtil.StrCmp(AV23GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV19FilterFullText = AV23GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV23GridStateFilterValue.gxTpr_Name, "TFESTADOSTIPO") == 0 )
            {
               AV35TFEstadosTipo = AV23GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV23GridStateFilterValue.gxTpr_Name, "TFESTADOSTIPO_SEL") == 0 )
            {
               AV36TFEstadosTipo_Sel = AV23GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV23GridStateFilterValue.gxTpr_Name, "TFESTADOSDESCRIP") == 0 )
            {
               AV37TFEstadosDescrip = AV23GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV23GridStateFilterValue.gxTpr_Name, "TFESTADOSDESCRIP_SEL") == 0 )
            {
               AV38TFEstadosDescrip_Sel = AV23GridStateFilterValue.gxTpr_Value;
            }
            AV49GXV3 = (int)(AV49GXV3+1);
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
         AV40Pgmname = "";
         GXKey = "";
         GXEncryptionTmp = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV11ExcelDocument = new ExcelDocumentI();
         AV19FilterFullText = "";
         AV36TFEstadosTipo_Sel = "";
         AV35TFEstadosTipo = "";
         AV38TFEstadosDescrip_Sel = "";
         AV37TFEstadosDescrip = "";
         AV20Session = context.GetSession();
         AV27ColumnsSelectorXML = "";
         AV24ColumnsSelector = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector(context);
         AV26ColumnsSelector_Column = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column(context);
         AV43Estadoswwds_1_filterfulltext = "";
         AV44Estadoswwds_2_tfestadostipo = "";
         AV45Estadoswwds_3_tfestadostipo_sel = "";
         AV46Estadoswwds_4_tfestadosdescrip = "";
         AV47Estadoswwds_5_tfestadosdescrip_sel = "";
         lV43Estadoswwds_1_filterfulltext = "";
         lV44Estadoswwds_2_tfestadostipo = "";
         lV46Estadoswwds_4_tfestadosdescrip = "";
         A107EstadosTipo = "";
         A158EstadosDescrip = "";
         P00C52_A158EstadosDescrip = new string[] {""} ;
         P00C52_A107EstadosTipo = new string[] {""} ;
         AV28UserCustomValue = "";
         GXt_char2 = "";
         AV25ColumnsSelectorAux = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector(context);
         AV22GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV23GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.estadoswwexport__default(),
            new Object[][] {
                new Object[] {
               P00C52_A158EstadosDescrip, P00C52_A107EstadosTipo
               }
            }
         );
         AV40Pgmname = "EstadosWWExport";
         /* GeneXus formulas. */
         AV40Pgmname = "EstadosWWExport";
      }

      private short GXt_int3 ;
      private short AV17OrderedBy ;
      private int AV14CellRow ;
      private int AV15FirstColumn ;
      private int AV16Random ;
      private int AV41GXV1 ;
      private int AV48GXV2 ;
      private int AV49GXV3 ;
      private long AV32VisibleColumnCount ;
      private string AV40Pgmname ;
      private string GXKey ;
      private string GXEncryptionTmp ;
      private string AV36TFEstadosTipo_Sel ;
      private string AV35TFEstadosTipo ;
      private string AV38TFEstadosDescrip_Sel ;
      private string AV37TFEstadosDescrip ;
      private string AV44Estadoswwds_2_tfestadostipo ;
      private string AV45Estadoswwds_3_tfestadostipo_sel ;
      private string AV46Estadoswwds_4_tfestadosdescrip ;
      private string AV47Estadoswwds_5_tfestadosdescrip_sel ;
      private string lV44Estadoswwds_2_tfestadostipo ;
      private string lV46Estadoswwds_4_tfestadosdescrip ;
      private string A107EstadosTipo ;
      private string A158EstadosDescrip ;
      private string GXt_char2 ;
      private bool AV8IsAuthorized ;
      private bool GXt_boolean1 ;
      private bool returnInSub ;
      private bool AV18OrderedDsc ;
      private string AV27ColumnsSelectorXML ;
      private string AV28UserCustomValue ;
      private string AV12Filename ;
      private string AV13ErrorMessage ;
      private string AV19FilterFullText ;
      private string AV43Estadoswwds_1_filterfulltext ;
      private string lV43Estadoswwds_1_filterfulltext ;
      private IGxSession AV20Session ;
      private ExcelDocumentI AV11ExcelDocument ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector AV24ColumnsSelector ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column AV26ColumnsSelector_Column ;
      private IDataStoreProvider pr_default ;
      private string[] P00C52_A158EstadosDescrip ;
      private string[] P00C52_A107EstadosTipo ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector AV25ColumnsSelectorAux ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV22GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV23GridStateFilterValue ;
      private string aP0_Filename ;
      private string aP1_ErrorMessage ;
   }

   public class estadoswwexport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00C52( IGxContext context ,
                                             string AV43Estadoswwds_1_filterfulltext ,
                                             string AV45Estadoswwds_3_tfestadostipo_sel ,
                                             string AV44Estadoswwds_2_tfestadostipo ,
                                             string AV47Estadoswwds_5_tfestadosdescrip_sel ,
                                             string AV46Estadoswwds_4_tfestadosdescrip ,
                                             string A107EstadosTipo ,
                                             string A158EstadosDescrip ,
                                             short AV17OrderedBy ,
                                             bool AV18OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int4 = new short[6];
         Object[] GXv_Object5 = new Object[2];
         scmdbuf = "SELECT [EstadosDescrip], [EstadosTipo] FROM [Estados]";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV43Estadoswwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( UPPER([EstadosTipo]) like '%' + UPPER(@lV43Estadoswwds_1_filterfulltext)) or ( UPPER([EstadosDescrip]) like '%' + UPPER(@lV43Estadoswwds_1_filterfulltext)))");
         }
         else
         {
            GXv_int4[0] = 1;
            GXv_int4[1] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV45Estadoswwds_3_tfestadostipo_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV44Estadoswwds_2_tfestadostipo)) ) )
         {
            AddWhere(sWhereString, "(UPPER([EstadosTipo]) like UPPER(@lV44Estadoswwds_2_tfestadostipo))");
         }
         else
         {
            GXv_int4[2] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV45Estadoswwds_3_tfestadostipo_sel)) && ! ( StringUtil.StrCmp(AV45Estadoswwds_3_tfestadostipo_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([EstadosTipo] = @AV45Estadoswwds_3_tfestadostipo_sel)");
         }
         else
         {
            GXv_int4[3] = 1;
         }
         if ( StringUtil.StrCmp(AV45Estadoswwds_3_tfestadostipo_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([EstadosTipo] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV47Estadoswwds_5_tfestadosdescrip_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV46Estadoswwds_4_tfestadosdescrip)) ) )
         {
            AddWhere(sWhereString, "(UPPER([EstadosDescrip]) like UPPER(@lV46Estadoswwds_4_tfestadosdescrip))");
         }
         else
         {
            GXv_int4[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV47Estadoswwds_5_tfestadosdescrip_sel)) && ! ( StringUtil.StrCmp(AV47Estadoswwds_5_tfestadosdescrip_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([EstadosDescrip] = @AV47Estadoswwds_5_tfestadosdescrip_sel)");
         }
         else
         {
            GXv_int4[5] = 1;
         }
         if ( StringUtil.StrCmp(AV47Estadoswwds_5_tfestadosdescrip_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([EstadosDescrip] = ''))");
         }
         scmdbuf += sWhereString;
         if ( ( AV17OrderedBy == 1 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY [EstadosDescrip]";
         }
         else if ( ( AV17OrderedBy == 1 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [EstadosDescrip] DESC";
         }
         else if ( ( AV17OrderedBy == 2 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY [EstadosTipo]";
         }
         else if ( ( AV17OrderedBy == 2 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [EstadosTipo] DESC";
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
                     return conditional_P00C52(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (short)dynConstraints[7] , (bool)dynConstraints[8] );
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
          Object[] prmP00C52;
          prmP00C52 = new Object[] {
          new ParDef("@lV43Estadoswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV43Estadoswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV44Estadoswwds_2_tfestadostipo",GXType.Char,3,0) ,
          new ParDef("@AV45Estadoswwds_3_tfestadostipo_sel",GXType.NChar,3,0) ,
          new ParDef("@lV46Estadoswwds_4_tfestadosdescrip",GXType.Char,80,0) ,
          new ParDef("@AV47Estadoswwds_5_tfestadosdescrip_sel",GXType.NChar,80,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00C52", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00C52,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[0])[0] = rslt.getString(1, 80);
                ((string[]) buf[1])[0] = rslt.getString(2, 3);
                return;
       }
    }

 }

}

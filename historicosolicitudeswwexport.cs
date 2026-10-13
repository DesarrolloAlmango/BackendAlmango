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
   public class historicosolicitudeswwexport : GXProcedure
   {
      public historicosolicitudeswwexport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public historicosolicitudeswwexport( IGxContext context )
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
         new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWHistoricoSolicitudes", out  GXt_boolean1) ;
         AV8IsAuthorized = GXt_boolean1;
         if ( ! AV8IsAuthorized )
         {
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "wwpbaseobjects.notauthorized.aspx"+GXUtil.UrlEncode(StringUtil.RTrim(AV89Pgmname));
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
         AV12Filename = GXt_char2 + "HistoricoSolicitudesWWExport-" + StringUtil.Trim( StringUtil.Str( (decimal)(AV16Random), 8, 0)) + ".xlsx";
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
         if ( ! ( (0==AV85TFHistoricoSolicitudesProvID) && (0==AV86TFHistoricoSolicitudesProvID_To) ) )
         {
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Proveedor Id", "")) ;
            AV14CellRow = GXt_int3;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Number = AV85TFHistoricoSolicitudesProvID;
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  false, ref  GXt_int3,  (short)(AV15FirstColumn+2),  context.GetMessage( "WWP_TSTo", "")) ;
            AV14CellRow = GXt_int3;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+3, 1, 1).Number = AV86TFHistoricoSolicitudesProvID_To;
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV88TFHistoricoSolicitudesProvNombre_Sel)) ) )
         {
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Nombre del Comercio", "")) ;
            AV14CellRow = GXt_int3;
            GXt_char2 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV88TFHistoricoSolicitudesProvNombre_Sel)) ? context.GetMessage( "WWP_TitleFilter_EmptyOption", "") : AV88TFHistoricoSolicitudesProvNombre_Sel), out  GXt_char2) ;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV87TFHistoricoSolicitudesProvNombre)) ) )
            {
               GXt_int3 = (short)(AV14CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Nombre del Comercio", "")) ;
               AV14CellRow = GXt_int3;
               GXt_char2 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV87TFHistoricoSolicitudesProvNombre, out  GXt_char2) ;
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
            }
         }
         AV14CellRow = (int)(AV14CellRow+2);
      }

      protected void S141( )
      {
         /* 'WRITECOLUMNTITLES' Routine */
         returnInSub = false;
         AV50VisibleColumnCount = 0;
         if ( StringUtil.StrCmp(AV38Session.Get("HistoricoSolicitudesWWColumnsSelector"), "") != 0 )
         {
            AV45ColumnsSelectorXML = AV38Session.Get("HistoricoSolicitudesWWColumnsSelector");
            AV42ColumnsSelector.FromXml(AV45ColumnsSelectorXML, null, "", "");
         }
         else
         {
            /* Execute user subroutine: 'INITIALIZECOLUMNSSELECTOR' */
            S151 ();
            if (returnInSub) return;
         }
         AV42ColumnsSelector.gxTpr_Columns.Sort("Order");
         AV90GXV1 = 1;
         while ( AV90GXV1 <= AV42ColumnsSelector.gxTpr_Columns.Count )
         {
            AV44ColumnsSelector_Column = ((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV42ColumnsSelector.gxTpr_Columns.Item(AV90GXV1));
            if ( AV44ColumnsSelector_Column.gxTpr_Isvisible )
            {
               AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV50VisibleColumnCount), 1, 1).Text = context.GetMessage( (String.IsNullOrEmpty(StringUtil.RTrim( AV44ColumnsSelector_Column.gxTpr_Displayname)) ? AV44ColumnsSelector_Column.gxTpr_Columnname : AV44ColumnsSelector_Column.gxTpr_Displayname), "");
               AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV50VisibleColumnCount), 1, 1).Bold = 1;
               AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV50VisibleColumnCount), 1, 1).Color = 11;
               AV50VisibleColumnCount = (long)(AV50VisibleColumnCount+1);
            }
            AV90GXV1 = (int)(AV90GXV1+1);
         }
      }

      protected void S161( )
      {
         /* 'WRITEDATA' Routine */
         returnInSub = false;
         AV92Historicosolicitudeswwds_1_filterfulltext = AV19FilterFullText;
         AV93Historicosolicitudeswwds_2_tfhistoricosolicitudesprovid = AV85TFHistoricoSolicitudesProvID;
         AV94Historicosolicitudeswwds_3_tfhistoricosolicitudesprovid_to = AV86TFHistoricoSolicitudesProvID_To;
         AV95Historicosolicitudeswwds_4_tfhistoricosolicitudesprovnombre = AV87TFHistoricoSolicitudesProvNombre;
         AV96Historicosolicitudeswwds_5_tfhistoricosolicitudesprovnombre_sel = AV88TFHistoricoSolicitudesProvNombre_Sel;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV93Historicosolicitudeswwds_2_tfhistoricosolicitudesprovid ,
                                              AV94Historicosolicitudeswwds_3_tfhistoricosolicitudesprovid_to ,
                                              AV96Historicosolicitudeswwds_5_tfhistoricosolicitudesprovnombre_sel ,
                                              AV95Historicosolicitudeswwds_4_tfhistoricosolicitudesprovnombre ,
                                              AV77EstadosGenericosID ,
                                              AV80ProveedorID ,
                                              A633HistoricoSolicitudesProvID ,
                                              A634HistoricoSolicitudesProvNombre ,
                                              A131EstadosSolId ,
                                              AV17OrderedBy ,
                                              AV18OrderedDsc ,
                                              AV92Historicosolicitudeswwds_1_filterfulltext ,
                                              A153HistoricoSolicitudesID ,
                                              A288HistoricoSolicitudesNombre ,
                                              A289HistoricoSolicitudesTelefono ,
                                              A290HistoricoSolicitudesMail ,
                                              A291HistoricoSolicitudesDireccion ,
                                              A302HistoricoSolicitudServicioPFin ,
                                              A306HistoricoSolicitudesFechaAlta ,
                                              AV78FechaIni ,
                                              AV79FechaFin } ,
                                              new int[]{
                                              TypeConstants.LONG, TypeConstants.LONG, TypeConstants.INT, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.INT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.LONG, TypeConstants.BOOLEAN,
                                              TypeConstants.DECIMAL, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE
                                              }
         });
         lV95Historicosolicitudeswwds_4_tfhistoricosolicitudesprovnombre = StringUtil.PadR( StringUtil.RTrim( AV95Historicosolicitudeswwds_4_tfhistoricosolicitudesprovnombre), 120, "%");
         /* Using cursor P004Q2 */
         pr_default.execute(0, new Object[] {AV78FechaIni, AV79FechaFin, AV93Historicosolicitudeswwds_2_tfhistoricosolicitudesprovid, AV94Historicosolicitudeswwds_3_tfhistoricosolicitudesprovid_to, lV95Historicosolicitudeswwds_4_tfhistoricosolicitudesprovnombre, AV96Historicosolicitudeswwds_5_tfhistoricosolicitudesprovnombre_sel, AV77EstadosGenericosID, AV80ProveedorID});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A130EstadosSolTipo = P004Q2_A130EstadosSolTipo[0];
            A306HistoricoSolicitudesFechaAlta = P004Q2_A306HistoricoSolicitudesFechaAlta[0];
            A131EstadosSolId = P004Q2_A131EstadosSolId[0];
            A291HistoricoSolicitudesDireccion = P004Q2_A291HistoricoSolicitudesDireccion[0];
            A290HistoricoSolicitudesMail = P004Q2_A290HistoricoSolicitudesMail[0];
            n290HistoricoSolicitudesMail = P004Q2_n290HistoricoSolicitudesMail[0];
            A289HistoricoSolicitudesTelefono = P004Q2_A289HistoricoSolicitudesTelefono[0];
            A288HistoricoSolicitudesNombre = P004Q2_A288HistoricoSolicitudesNombre[0];
            A153HistoricoSolicitudesID = P004Q2_A153HistoricoSolicitudesID[0];
            A634HistoricoSolicitudesProvNombre = P004Q2_A634HistoricoSolicitudesProvNombre[0];
            A633HistoricoSolicitudesProvID = P004Q2_A633HistoricoSolicitudesProvID[0];
            A442HistoricoSolicitudesPagado = P004Q2_A442HistoricoSolicitudesPagado[0];
            A439HistoricoSolicitudesOrigenPago = P004Q2_A439HistoricoSolicitudesOrigenPago[0];
            A132EstadosSolNombre = P004Q2_A132EstadosSolNombre[0];
            A299HistoricoSolicitudesCotizacion = P004Q2_A299HistoricoSolicitudesCotizacion[0];
            A132EstadosSolNombre = P004Q2_A132EstadosSolNombre[0];
            GetHistoricoSolicitudesTotal( A153HistoricoSolicitudesID) ;
            if ( ( A299HistoricoSolicitudesCotizacion == Convert.ToDecimal( 0 )) )
            {
               A302HistoricoSolicitudServicioPFin = A300HistoricoSolicitudesTotal;
            }
            else
            {
               if ( ( A299HistoricoSolicitudesCotizacion > Convert.ToDecimal( 0 )) )
               {
                  A302HistoricoSolicitudServicioPFin = A299HistoricoSolicitudesCotizacion;
               }
               else
               {
                  A302HistoricoSolicitudServicioPFin = 0;
               }
            }
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV92Historicosolicitudeswwds_1_filterfulltext)) || ( ( StringUtil.Like( StringUtil.Str( (decimal)(A153HistoricoSolicitudesID), 18, 0) , StringUtil.PadR( "%" + AV92Historicosolicitudeswwds_1_filterfulltext , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A288HistoricoSolicitudesNombre) , StringUtil.PadR( "%" + StringUtil.Upper( AV92Historicosolicitudeswwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A289HistoricoSolicitudesTelefono) , StringUtil.PadR( "%" + StringUtil.Upper( AV92Historicosolicitudeswwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A290HistoricoSolicitudesMail) , StringUtil.PadR( "%" + StringUtil.Upper( AV92Historicosolicitudeswwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A291HistoricoSolicitudesDireccion) , StringUtil.PadR( "%" + StringUtil.Upper( AV92Historicosolicitudeswwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Str( A302HistoricoSolicitudServicioPFin, 18, 2) , StringUtil.PadR( "%" + AV92Historicosolicitudeswwds_1_filterfulltext , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A634HistoricoSolicitudesProvNombre) , StringUtil.PadR( "%" + StringUtil.Upper( AV92Historicosolicitudeswwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) ) )
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
               AV50VisibleColumnCount = 0;
               AV97GXV2 = 1;
               while ( AV97GXV2 <= AV42ColumnsSelector.gxTpr_Columns.Count )
               {
                  AV44ColumnsSelector_Column = ((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV42ColumnsSelector.gxTpr_Columns.Item(AV97GXV2));
                  if ( AV44ColumnsSelector_Column.gxTpr_Isvisible )
                  {
                     if ( StringUtil.StrCmp(AV44ColumnsSelector_Column.gxTpr_Columnname, "HistoricoSolicitudesID") == 0 )
                     {
                        AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV50VisibleColumnCount), 1, 1).Number = A153HistoricoSolicitudesID;
                     }
                     else if ( StringUtil.StrCmp(AV44ColumnsSelector_Column.gxTpr_Columnname, "EstadosSolNombre") == 0 )
                     {
                        GXt_char2 = "";
                        new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A132EstadosSolNombre, out  GXt_char2) ;
                        AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV50VisibleColumnCount), 1, 1).Text = GXt_char2;
                     }
                     else if ( StringUtil.StrCmp(AV44ColumnsSelector_Column.gxTpr_Columnname, "HistoricoSolicitudesNombre") == 0 )
                     {
                        GXt_char2 = "";
                        new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A288HistoricoSolicitudesNombre, out  GXt_char2) ;
                        AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV50VisibleColumnCount), 1, 1).Text = GXt_char2;
                     }
                     else if ( StringUtil.StrCmp(AV44ColumnsSelector_Column.gxTpr_Columnname, "HistoricoSolicitudesTelefono") == 0 )
                     {
                        GXt_char2 = "";
                        new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A289HistoricoSolicitudesTelefono, out  GXt_char2) ;
                        AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV50VisibleColumnCount), 1, 1).Text = GXt_char2;
                     }
                     else if ( StringUtil.StrCmp(AV44ColumnsSelector_Column.gxTpr_Columnname, "HistoricoSolicitudesMail") == 0 )
                     {
                        GXt_char2 = "";
                        new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A290HistoricoSolicitudesMail, out  GXt_char2) ;
                        AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV50VisibleColumnCount), 1, 1).Text = GXt_char2;
                     }
                     else if ( StringUtil.StrCmp(AV44ColumnsSelector_Column.gxTpr_Columnname, "HistoricoSolicitudesDireccion") == 0 )
                     {
                        GXt_char2 = "";
                        new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A291HistoricoSolicitudesDireccion, out  GXt_char2) ;
                        AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV50VisibleColumnCount), 1, 1).Text = GXt_char2;
                     }
                     else if ( StringUtil.StrCmp(AV44ColumnsSelector_Column.gxTpr_Columnname, "HistoricoSolicitudesCotizacion") == 0 )
                     {
                        AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV50VisibleColumnCount), 1, 1).Number = (double)(A299HistoricoSolicitudesCotizacion);
                     }
                     else if ( StringUtil.StrCmp(AV44ColumnsSelector_Column.gxTpr_Columnname, "HistoricoSolicitudServicioPFinal") == 0 )
                     {
                        AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV50VisibleColumnCount), 1, 1).Number = (double)(A302HistoricoSolicitudServicioPFin);
                     }
                     else if ( StringUtil.StrCmp(AV44ColumnsSelector_Column.gxTpr_Columnname, "HistoricoSolicitudesFechaAlta") == 0 )
                     {
                        GXt_dtime4 = DateTimeUtil.ResetTime( A306HistoricoSolicitudesFechaAlta ) ;
                        AV11ExcelDocument.SetDateFormat(context, 8, 5, ((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0), DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt")), "/", ":", " ");
                        AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV50VisibleColumnCount), 1, 1).Date = GXt_dtime4;
                     }
                     else if ( StringUtil.StrCmp(AV44ColumnsSelector_Column.gxTpr_Columnname, "HistoricoSolicitudesOrigenPago") == 0 )
                     {
                        GXt_char2 = "";
                        new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A439HistoricoSolicitudesOrigenPago, out  GXt_char2) ;
                        AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV50VisibleColumnCount), 1, 1).Text = GXt_char2;
                     }
                     else if ( StringUtil.StrCmp(AV44ColumnsSelector_Column.gxTpr_Columnname, "HistoricoSolicitudesPagado") == 0 )
                     {
                        AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV50VisibleColumnCount), 1, 1).Text = "";
                        if ( StringUtil.StrCmp(StringUtil.Trim( A442HistoricoSolicitudesPagado), context.GetMessage( "S", "")) == 0 )
                        {
                           AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV50VisibleColumnCount), 1, 1).Text = context.GetMessage( "Pagado", "");
                        }
                        else if ( StringUtil.StrCmp(StringUtil.Trim( A442HistoricoSolicitudesPagado), context.GetMessage( "N", "")) == 0 )
                        {
                           AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV50VisibleColumnCount), 1, 1).Text = context.GetMessage( "Pendiente de Pago", "");
                        }
                     }
                     else if ( StringUtil.StrCmp(AV44ColumnsSelector_Column.gxTpr_Columnname, "HistoricoSolicitudesProvID") == 0 )
                     {
                        AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV50VisibleColumnCount), 1, 1).Number = A633HistoricoSolicitudesProvID;
                     }
                     else if ( StringUtil.StrCmp(AV44ColumnsSelector_Column.gxTpr_Columnname, "HistoricoSolicitudesProvNombre") == 0 )
                     {
                        GXt_char2 = "";
                        new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A634HistoricoSolicitudesProvNombre, out  GXt_char2) ;
                        AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV50VisibleColumnCount), 1, 1).Text = GXt_char2;
                     }
                     AV50VisibleColumnCount = (long)(AV50VisibleColumnCount+1);
                  }
                  AV97GXV2 = (int)(AV97GXV2+1);
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
         AV38Session.Set("WWPExportFilePath", AV12Filename);
         AV38Session.Set("WWPExportFileName", "HistoricoSolicitudesWWExport.xlsx");
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
         AV42ColumnsSelector = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector(context);
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV42ColumnsSelector,  "HistoricoSolicitudesID",  "",  "Solicitudes ID",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV42ColumnsSelector,  "EstadosSolNombre",  "",  "Estado",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV42ColumnsSelector,  "HistoricoSolicitudesNombre",  "",  "Nombre | Contacto",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV42ColumnsSelector,  "HistoricoSolicitudesTelefono",  "",  "Telefono",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV42ColumnsSelector,  "HistoricoSolicitudesMail",  "",  "Mail",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV42ColumnsSelector,  "HistoricoSolicitudesDireccion",  "",  "Direccion",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV42ColumnsSelector,  "HistoricoSolicitudesCotizacion",  "",  "Cotizacion",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV42ColumnsSelector,  "HistoricoSolicitudServicioPFinal",  "",  "Servicio PFinal",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV42ColumnsSelector,  "HistoricoSolicitudesFechaAlta",  "",  "Fecha Alta",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV42ColumnsSelector,  "HistoricoSolicitudesOrigenPago",  "",  "Origen Pago",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV42ColumnsSelector,  "HistoricoSolicitudesPagado",  "",  "Pagado",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV42ColumnsSelector,  "HistoricoSolicitudesProvID",  "",  "Proveedor Id",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV42ColumnsSelector,  "HistoricoSolicitudesProvNombre",  "",  "Nombre del Comercio",  true,  "") ;
         GXt_char2 = AV46UserCustomValue;
         new GeneXus.Programs.wwpbaseobjects.loadcolumnsselectorstate(context ).execute(  "HistoricoSolicitudesWWColumnsSelector", out  GXt_char2) ;
         AV46UserCustomValue = GXt_char2;
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV46UserCustomValue)) ) )
         {
            AV43ColumnsSelectorAux.FromXml(AV46UserCustomValue, null, "", "");
            new GeneXus.Programs.wwpbaseobjects.wwp_columnselector_updatecolumns(context ).execute( ref  AV43ColumnsSelectorAux, ref  AV42ColumnsSelector) ;
         }
      }

      protected void S201( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV38Session.Get("HistoricoSolicitudesWWGridState"), "") == 0 )
         {
            AV40GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "HistoricoSolicitudesWWGridState"), null, "", "");
         }
         else
         {
            AV40GridState.FromXml(AV38Session.Get("HistoricoSolicitudesWWGridState"), null, "", "");
         }
         AV17OrderedBy = AV40GridState.gxTpr_Orderedby;
         AV18OrderedDsc = AV40GridState.gxTpr_Ordereddsc;
         AV98GXV3 = 1;
         while ( AV98GXV3 <= AV40GridState.gxTpr_Filtervalues.Count )
         {
            AV41GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV40GridState.gxTpr_Filtervalues.Item(AV98GXV3));
            if ( StringUtil.StrCmp(AV41GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV19FilterFullText = AV41GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV41GridStateFilterValue.gxTpr_Name, "TFHISTORICOSOLICITUDESPROVID") == 0 )
            {
               AV85TFHistoricoSolicitudesProvID = (long)(Math.Round(NumberUtil.Val( AV41GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV86TFHistoricoSolicitudesProvID_To = (long)(Math.Round(NumberUtil.Val( AV41GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV41GridStateFilterValue.gxTpr_Name, "TFHISTORICOSOLICITUDESPROVNOMBRE") == 0 )
            {
               AV87TFHistoricoSolicitudesProvNombre = AV41GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV41GridStateFilterValue.gxTpr_Name, "TFHISTORICOSOLICITUDESPROVNOMBRE_SEL") == 0 )
            {
               AV88TFHistoricoSolicitudesProvNombre_Sel = AV41GridStateFilterValue.gxTpr_Value;
            }
            AV98GXV3 = (int)(AV98GXV3+1);
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

      protected void GetHistoricoSolicitudesTotal( long A153HistoricoSolicitudesID )
      {
         /* Create private dbobjects */
         /* Navigation */
         A300HistoricoSolicitudesTotal = 0;
         /* Using cursor P004Q3 */
         pr_default.execute(1, new Object[] {A153HistoricoSolicitudesID});
         while ( (pr_default.getStatus(1) != 101) && ( P004Q3_A153HistoricoSolicitudesID[0] == A153HistoricoSolicitudesID ) )
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( P004Q3_A296HistoricoSolicitudesItemsSR[0])) || ( StringUtil.StrCmp(P004Q3_A297HistoricoSolicitudesItemsCT[0], "N") == 0 ) )
            {
               A294HItemsSolicitudesItemsPrecioIn = (decimal)(P004Q3_A295HItemsInventarioPrecioFinal[0]*P004Q3_A293HItemsSolicitudesItemsCantidad[0]);
            }
            else
            {
               if ( ( StringUtil.StrCmp(P004Q3_A297HistoricoSolicitudesItemsCT[0], "F") == 0 ) && ( StringUtil.StrCmp(P004Q3_A296HistoricoSolicitudesItemsSR[0], "R") == 0 ) )
               {
                  A294HItemsSolicitudesItemsPrecioIn = (decimal)((P004Q3_A295HItemsInventarioPrecioFinal[0]*P004Q3_A293HItemsSolicitudesItemsCantidad[0])-(P004Q3_A298HistoricoSolicitudesItemsComis[0]*P004Q3_A293HItemsSolicitudesItemsCantidad[0]));
               }
               else
               {
                  if ( ( StringUtil.StrCmp(P004Q3_A297HistoricoSolicitudesItemsCT[0], "F") == 0 ) && ( StringUtil.StrCmp(P004Q3_A296HistoricoSolicitudesItemsSR[0], "S") == 0 ) )
                  {
                     A294HItemsSolicitudesItemsPrecioIn = (decimal)((P004Q3_A295HItemsInventarioPrecioFinal[0]*P004Q3_A293HItemsSolicitudesItemsCantidad[0])+(P004Q3_A298HistoricoSolicitudesItemsComis[0]*P004Q3_A293HItemsSolicitudesItemsCantidad[0]));
                  }
                  else
                  {
                     if ( ( StringUtil.StrCmp(P004Q3_A297HistoricoSolicitudesItemsCT[0], "P") == 0 ) && ( StringUtil.StrCmp(P004Q3_A296HistoricoSolicitudesItemsSR[0], "R") == 0 ) )
                     {
                        A294HItemsSolicitudesItemsPrecioIn = (decimal)((P004Q3_A295HItemsInventarioPrecioFinal[0]*P004Q3_A293HItemsSolicitudesItemsCantidad[0])-((P004Q3_A295HItemsInventarioPrecioFinal[0]*P004Q3_A293HItemsSolicitudesItemsCantidad[0])*(P004Q3_A298HistoricoSolicitudesItemsComis[0]/ (decimal)(100))));
                     }
                     else
                     {
                        if ( ( StringUtil.StrCmp(P004Q3_A297HistoricoSolicitudesItemsCT[0], "P") == 0 ) && ( StringUtil.StrCmp(P004Q3_A296HistoricoSolicitudesItemsSR[0], "S") == 0 ) )
                        {
                           A294HItemsSolicitudesItemsPrecioIn = (decimal)((P004Q3_A295HItemsInventarioPrecioFinal[0]*P004Q3_A293HItemsSolicitudesItemsCantidad[0])+((P004Q3_A295HItemsInventarioPrecioFinal[0]*P004Q3_A293HItemsSolicitudesItemsCantidad[0])*(P004Q3_A298HistoricoSolicitudesItemsComis[0]/ (decimal)(100))));
                        }
                        else
                        {
                           A294HItemsSolicitudesItemsPrecioIn = 0;
                        }
                     }
                  }
               }
            }
            A300HistoricoSolicitudesTotal = (decimal)(A300HistoricoSolicitudesTotal+A294HItemsSolicitudesItemsPrecioIn);
            pr_default.readNext(1);
         }
         pr_default.close(1);
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
         AV89Pgmname = "";
         GXKey = "";
         GXEncryptionTmp = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV11ExcelDocument = new ExcelDocumentI();
         AV19FilterFullText = "";
         AV88TFHistoricoSolicitudesProvNombre_Sel = "";
         AV87TFHistoricoSolicitudesProvNombre = "";
         AV38Session = context.GetSession();
         AV45ColumnsSelectorXML = "";
         AV42ColumnsSelector = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector(context);
         AV44ColumnsSelector_Column = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column(context);
         AV92Historicosolicitudeswwds_1_filterfulltext = "";
         AV95Historicosolicitudeswwds_4_tfhistoricosolicitudesprovnombre = "";
         AV96Historicosolicitudeswwds_5_tfhistoricosolicitudesprovnombre_sel = "";
         lV92Historicosolicitudeswwds_1_filterfulltext = "";
         lV95Historicosolicitudeswwds_4_tfhistoricosolicitudesprovnombre = "";
         A634HistoricoSolicitudesProvNombre = "";
         A288HistoricoSolicitudesNombre = "";
         A289HistoricoSolicitudesTelefono = "";
         A290HistoricoSolicitudesMail = "";
         A291HistoricoSolicitudesDireccion = "";
         A306HistoricoSolicitudesFechaAlta = DateTime.MinValue;
         AV78FechaIni = DateTime.MinValue;
         AV79FechaFin = DateTime.MinValue;
         P004Q2_A130EstadosSolTipo = new string[] {""} ;
         P004Q2_A306HistoricoSolicitudesFechaAlta = new DateTime[] {DateTime.MinValue} ;
         P004Q2_A131EstadosSolId = new int[1] ;
         P004Q2_A291HistoricoSolicitudesDireccion = new string[] {""} ;
         P004Q2_A290HistoricoSolicitudesMail = new string[] {""} ;
         P004Q2_n290HistoricoSolicitudesMail = new bool[] {false} ;
         P004Q2_A289HistoricoSolicitudesTelefono = new string[] {""} ;
         P004Q2_A288HistoricoSolicitudesNombre = new string[] {""} ;
         P004Q2_A153HistoricoSolicitudesID = new long[1] ;
         P004Q2_A634HistoricoSolicitudesProvNombre = new string[] {""} ;
         P004Q2_A633HistoricoSolicitudesProvID = new long[1] ;
         P004Q2_A442HistoricoSolicitudesPagado = new string[] {""} ;
         P004Q2_A439HistoricoSolicitudesOrigenPago = new string[] {""} ;
         P004Q2_A132EstadosSolNombre = new string[] {""} ;
         P004Q2_A299HistoricoSolicitudesCotizacion = new decimal[1] ;
         A130EstadosSolTipo = "";
         A442HistoricoSolicitudesPagado = "";
         A439HistoricoSolicitudesOrigenPago = "";
         A132EstadosSolNombre = "";
         GXt_dtime4 = (DateTime)(DateTime.MinValue);
         AV46UserCustomValue = "";
         GXt_char2 = "";
         AV43ColumnsSelectorAux = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector(context);
         AV40GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV41GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         P004Q3_A153HistoricoSolicitudesID = new long[1] ;
         P004Q3_A154HistoricoSolicitudesItemsID = new short[1] ;
         P004Q3_A298HistoricoSolicitudesItemsComis = new decimal[1] ;
         P004Q3_A297HistoricoSolicitudesItemsCT = new string[] {""} ;
         P004Q3_A296HistoricoSolicitudesItemsSR = new string[] {""} ;
         P004Q3_A293HItemsSolicitudesItemsCantidad = new short[1] ;
         P004Q3_A295HItemsInventarioPrecioFinal = new short[1] ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.historicosolicitudeswwexport__default(),
            new Object[][] {
                new Object[] {
               P004Q2_A130EstadosSolTipo, P004Q2_A306HistoricoSolicitudesFechaAlta, P004Q2_A131EstadosSolId, P004Q2_A291HistoricoSolicitudesDireccion, P004Q2_A290HistoricoSolicitudesMail, P004Q2_n290HistoricoSolicitudesMail, P004Q2_A289HistoricoSolicitudesTelefono, P004Q2_A288HistoricoSolicitudesNombre, P004Q2_A153HistoricoSolicitudesID, P004Q2_A634HistoricoSolicitudesProvNombre,
               P004Q2_A633HistoricoSolicitudesProvID, P004Q2_A442HistoricoSolicitudesPagado, P004Q2_A439HistoricoSolicitudesOrigenPago, P004Q2_A132EstadosSolNombre, P004Q2_A299HistoricoSolicitudesCotizacion
               }
               , new Object[] {
               P004Q3_A153HistoricoSolicitudesID, P004Q3_A154HistoricoSolicitudesItemsID, P004Q3_A298HistoricoSolicitudesItemsComis, P004Q3_A297HistoricoSolicitudesItemsCT, P004Q3_A296HistoricoSolicitudesItemsSR, P004Q3_A293HItemsSolicitudesItemsCantidad, P004Q3_A295HItemsInventarioPrecioFinal
               }
            }
         );
         AV89Pgmname = "HistoricoSolicitudesWWExport";
         /* GeneXus formulas. */
         AV89Pgmname = "HistoricoSolicitudesWWExport";
      }

      private short GXt_int3 ;
      private short AV17OrderedBy ;
      private int AV14CellRow ;
      private int AV15FirstColumn ;
      private int AV16Random ;
      private int AV90GXV1 ;
      private int AV77EstadosGenericosID ;
      private int A131EstadosSolId ;
      private int AV97GXV2 ;
      private int AV98GXV3 ;
      private long AV85TFHistoricoSolicitudesProvID ;
      private long AV86TFHistoricoSolicitudesProvID_To ;
      private long AV50VisibleColumnCount ;
      private long AV93Historicosolicitudeswwds_2_tfhistoricosolicitudesprovid ;
      private long AV94Historicosolicitudeswwds_3_tfhistoricosolicitudesprovid_to ;
      private long AV80ProveedorID ;
      private long A633HistoricoSolicitudesProvID ;
      private long A153HistoricoSolicitudesID ;
      private decimal A302HistoricoSolicitudServicioPFin ;
      private decimal A299HistoricoSolicitudesCotizacion ;
      private decimal A300HistoricoSolicitudesTotal ;
      private decimal A294HItemsSolicitudesItemsPrecioIn ;
      private string AV89Pgmname ;
      private string GXKey ;
      private string GXEncryptionTmp ;
      private string AV88TFHistoricoSolicitudesProvNombre_Sel ;
      private string AV87TFHistoricoSolicitudesProvNombre ;
      private string AV95Historicosolicitudeswwds_4_tfhistoricosolicitudesprovnombre ;
      private string AV96Historicosolicitudeswwds_5_tfhistoricosolicitudesprovnombre_sel ;
      private string lV95Historicosolicitudeswwds_4_tfhistoricosolicitudesprovnombre ;
      private string A634HistoricoSolicitudesProvNombre ;
      private string A288HistoricoSolicitudesNombre ;
      private string A289HistoricoSolicitudesTelefono ;
      private string A130EstadosSolTipo ;
      private string A442HistoricoSolicitudesPagado ;
      private string A439HistoricoSolicitudesOrigenPago ;
      private string A132EstadosSolNombre ;
      private string GXt_char2 ;
      private DateTime GXt_dtime4 ;
      private DateTime A306HistoricoSolicitudesFechaAlta ;
      private DateTime AV78FechaIni ;
      private DateTime AV79FechaFin ;
      private bool AV8IsAuthorized ;
      private bool GXt_boolean1 ;
      private bool returnInSub ;
      private bool AV18OrderedDsc ;
      private bool n290HistoricoSolicitudesMail ;
      private string AV45ColumnsSelectorXML ;
      private string AV46UserCustomValue ;
      private string AV12Filename ;
      private string AV13ErrorMessage ;
      private string AV19FilterFullText ;
      private string AV92Historicosolicitudeswwds_1_filterfulltext ;
      private string lV92Historicosolicitudeswwds_1_filterfulltext ;
      private string A290HistoricoSolicitudesMail ;
      private string A291HistoricoSolicitudesDireccion ;
      private IGxSession AV38Session ;
      private ExcelDocumentI AV11ExcelDocument ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector AV42ColumnsSelector ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column AV44ColumnsSelector_Column ;
      private IDataStoreProvider pr_default ;
      private string[] P004Q2_A130EstadosSolTipo ;
      private DateTime[] P004Q2_A306HistoricoSolicitudesFechaAlta ;
      private int[] P004Q2_A131EstadosSolId ;
      private string[] P004Q2_A291HistoricoSolicitudesDireccion ;
      private string[] P004Q2_A290HistoricoSolicitudesMail ;
      private bool[] P004Q2_n290HistoricoSolicitudesMail ;
      private string[] P004Q2_A289HistoricoSolicitudesTelefono ;
      private string[] P004Q2_A288HistoricoSolicitudesNombre ;
      private long[] P004Q2_A153HistoricoSolicitudesID ;
      private string[] P004Q2_A634HistoricoSolicitudesProvNombre ;
      private long[] P004Q2_A633HistoricoSolicitudesProvID ;
      private string[] P004Q2_A442HistoricoSolicitudesPagado ;
      private string[] P004Q2_A439HistoricoSolicitudesOrigenPago ;
      private string[] P004Q2_A132EstadosSolNombre ;
      private decimal[] P004Q2_A299HistoricoSolicitudesCotizacion ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector AV43ColumnsSelectorAux ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV40GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV41GridStateFilterValue ;
      private long[] P004Q3_A153HistoricoSolicitudesID ;
      private short[] P004Q3_A154HistoricoSolicitudesItemsID ;
      private decimal[] P004Q3_A298HistoricoSolicitudesItemsComis ;
      private string[] P004Q3_A297HistoricoSolicitudesItemsCT ;
      private string[] P004Q3_A296HistoricoSolicitudesItemsSR ;
      private short[] P004Q3_A293HItemsSolicitudesItemsCantidad ;
      private short[] P004Q3_A295HItemsInventarioPrecioFinal ;
      private string aP0_Filename ;
      private string aP1_ErrorMessage ;
   }

   public class historicosolicitudeswwexport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P004Q2( IGxContext context ,
                                             long AV93Historicosolicitudeswwds_2_tfhistoricosolicitudesprovid ,
                                             long AV94Historicosolicitudeswwds_3_tfhistoricosolicitudesprovid_to ,
                                             string AV96Historicosolicitudeswwds_5_tfhistoricosolicitudesprovnombre_sel ,
                                             string AV95Historicosolicitudeswwds_4_tfhistoricosolicitudesprovnombre ,
                                             int AV77EstadosGenericosID ,
                                             long AV80ProveedorID ,
                                             long A633HistoricoSolicitudesProvID ,
                                             string A634HistoricoSolicitudesProvNombre ,
                                             int A131EstadosSolId ,
                                             short AV17OrderedBy ,
                                             bool AV18OrderedDsc ,
                                             string AV92Historicosolicitudeswwds_1_filterfulltext ,
                                             long A153HistoricoSolicitudesID ,
                                             string A288HistoricoSolicitudesNombre ,
                                             string A289HistoricoSolicitudesTelefono ,
                                             string A290HistoricoSolicitudesMail ,
                                             string A291HistoricoSolicitudesDireccion ,
                                             decimal A302HistoricoSolicitudServicioPFin ,
                                             DateTime A306HistoricoSolicitudesFechaAlta ,
                                             DateTime AV78FechaIni ,
                                             DateTime AV79FechaFin )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int5 = new short[8];
         Object[] GXv_Object6 = new Object[2];
         scmdbuf = "SELECT T1.[EstadosSolTipo] AS EstadosSolTipo, T1.[HistoricoSolicitudesFechaAlta], T1.[EstadosSolId] AS EstadosSolId, T1.[HistoricoSolicitudesDireccion], T1.[HistoricoSolicitudesMail], T1.[HistoricoSolicitudesTelefono], T1.[HistoricoSolicitudesNombre], T1.[HistoricoSolicitudesID], T1.[HistoricoSolicitudesProvNombre], T1.[HistoricoSolicitudesProvID], T1.[HistoricoSolicitudesPagado], T1.[HistoricoSolicitudesOrigenPago], T2.[EstadosGenericosNombre] AS EstadosSolNombre, T1.[HistoricoSolicitudesCotizacion] FROM ([HistoricoSolicitudes] T1 INNER JOIN [EstadosGenericos] T2 ON T2.[EstadosTipo] = T1.[EstadosSolTipo] AND T2.[EstadosGenericosId] = T1.[EstadosSolId])";
         AddWhere(sWhereString, "(T1.[HistoricoSolicitudesFechaAlta] >= @AV78FechaIni and T1.[HistoricoSolicitudesFechaAlta] <= @AV79FechaFin)");
         if ( ! (0==AV93Historicosolicitudeswwds_2_tfhistoricosolicitudesprovid) )
         {
            AddWhere(sWhereString, "(T1.[HistoricoSolicitudesProvID] >= @AV93Historicosolicitudeswwds_2_tfhistoricosolicitudesprovid)");
         }
         else
         {
            GXv_int5[2] = 1;
         }
         if ( ! (0==AV94Historicosolicitudeswwds_3_tfhistoricosolicitudesprovid_to) )
         {
            AddWhere(sWhereString, "(T1.[HistoricoSolicitudesProvID] <= @AV94Historicosolicitudeswwds_3_tfhistoricosolicitudesprovid_to)");
         }
         else
         {
            GXv_int5[3] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV96Historicosolicitudeswwds_5_tfhistoricosolicitudesprovnombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV95Historicosolicitudeswwds_4_tfhistoricosolicitudesprovnombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[HistoricoSolicitudesProvNombre]) like UPPER(@lV95Historicosolicitudeswwds_4_tfhistoricosolicitudesprovnombre))");
         }
         else
         {
            GXv_int5[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV96Historicosolicitudeswwds_5_tfhistoricosolicitudesprovnombre_sel)) && ! ( StringUtil.StrCmp(AV96Historicosolicitudeswwds_5_tfhistoricosolicitudesprovnombre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[HistoricoSolicitudesProvNombre] = @AV96Historicosolicitudeswwds_5_tfhistoricosolicitudesprovnombre_sel)");
         }
         else
         {
            GXv_int5[5] = 1;
         }
         if ( StringUtil.StrCmp(AV96Historicosolicitudeswwds_5_tfhistoricosolicitudesprovnombre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[HistoricoSolicitudesProvNombre] = ''))");
         }
         if ( ! ( AV77EstadosGenericosID == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[EstadosSolId] = @AV77EstadosGenericosID)");
         }
         else
         {
            GXv_int5[6] = 1;
         }
         if ( ! (0==AV80ProveedorID) )
         {
            AddWhere(sWhereString, "(T1.[HistoricoSolicitudesProvID] = @AV80ProveedorID)");
         }
         else
         {
            GXv_int5[7] = 1;
         }
         scmdbuf += sWhereString;
         if ( ( AV17OrderedBy == 1 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[HistoricoSolicitudesID]";
         }
         else if ( ( AV17OrderedBy == 1 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[HistoricoSolicitudesID] DESC";
         }
         else if ( ( AV17OrderedBy == 2 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T2.[EstadosGenericosNombre]";
         }
         else if ( ( AV17OrderedBy == 2 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T2.[EstadosGenericosNombre] DESC";
         }
         else if ( ( AV17OrderedBy == 3 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[HistoricoSolicitudesNombre]";
         }
         else if ( ( AV17OrderedBy == 3 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[HistoricoSolicitudesNombre] DESC";
         }
         else if ( ( AV17OrderedBy == 4 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[HistoricoSolicitudesTelefono]";
         }
         else if ( ( AV17OrderedBy == 4 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[HistoricoSolicitudesTelefono] DESC";
         }
         else if ( ( AV17OrderedBy == 5 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[HistoricoSolicitudesMail]";
         }
         else if ( ( AV17OrderedBy == 5 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[HistoricoSolicitudesMail] DESC";
         }
         else if ( ( AV17OrderedBy == 6 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[HistoricoSolicitudesDireccion]";
         }
         else if ( ( AV17OrderedBy == 6 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[HistoricoSolicitudesDireccion] DESC";
         }
         else if ( ( AV17OrderedBy == 7 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[HistoricoSolicitudesCotizacion]";
         }
         else if ( ( AV17OrderedBy == 7 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[HistoricoSolicitudesCotizacion] DESC";
         }
         else if ( ( AV17OrderedBy == 8 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[HistoricoSolicitudesFechaAlta]";
         }
         else if ( ( AV17OrderedBy == 8 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[HistoricoSolicitudesFechaAlta] DESC";
         }
         else if ( ( AV17OrderedBy == 9 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[HistoricoSolicitudesOrigenPago]";
         }
         else if ( ( AV17OrderedBy == 9 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[HistoricoSolicitudesOrigenPago] DESC";
         }
         else if ( ( AV17OrderedBy == 10 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[HistoricoSolicitudesPagado]";
         }
         else if ( ( AV17OrderedBy == 10 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[HistoricoSolicitudesPagado] DESC";
         }
         else if ( ( AV17OrderedBy == 11 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[HistoricoSolicitudesProvID]";
         }
         else if ( ( AV17OrderedBy == 11 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[HistoricoSolicitudesProvID] DESC";
         }
         else if ( ( AV17OrderedBy == 12 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[HistoricoSolicitudesProvNombre]";
         }
         else if ( ( AV17OrderedBy == 12 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[HistoricoSolicitudesProvNombre] DESC";
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
                     return conditional_P004Q2(context, (long)dynConstraints[0] , (long)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (int)dynConstraints[4] , (long)dynConstraints[5] , (long)dynConstraints[6] , (string)dynConstraints[7] , (int)dynConstraints[8] , (short)dynConstraints[9] , (bool)dynConstraints[10] , (string)dynConstraints[11] , (long)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (decimal)dynConstraints[17] , (DateTime)dynConstraints[18] , (DateTime)dynConstraints[19] , (DateTime)dynConstraints[20] );
         }
         return base.getDynamicStatement(cursor, context, dynConstraints);
      }

      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP004Q3;
          prmP004Q3 = new Object[] {
          new ParDef("@HistoricoSolicitudesID",GXType.Decimal,18,0)
          };
          Object[] prmP004Q2;
          prmP004Q2 = new Object[] {
          new ParDef("@AV78FechaIni",GXType.Date,8,0) ,
          new ParDef("@AV79FechaFin",GXType.Date,8,0) ,
          new ParDef("@AV93Historicosolicitudeswwds_2_tfhistoricosolicitudesprovid",GXType.Decimal,18,0) ,
          new ParDef("@AV94Historicosolicitudeswwds_3_tfhistoricosolicitudesprovid_to",GXType.Decimal,18,0) ,
          new ParDef("@lV95Historicosolicitudeswwds_4_tfhistoricosolicitudesprovnombre",GXType.Char,120,0) ,
          new ParDef("@AV96Historicosolicitudeswwds_5_tfhistoricosolicitudesprovnombre_sel",GXType.NChar,120,0) ,
          new ParDef("@AV77EstadosGenericosID",GXType.Int32,5,0) ,
          new ParDef("@AV80ProveedorID",GXType.Decimal,18,0)
          };
          def= new CursorDef[] {
              new CursorDef("P004Q2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP004Q2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P004Q3", "SELECT [HistoricoSolicitudesID], [HistoricoSolicitudesItemsID], [HistoricoSolicitudesItemsComis], [HistoricoSolicitudesItemsCT], [HistoricoSolicitudesItemsSR], [HItemsSolicitudesItemsCantidad], [HItemsInventarioPrecioFinal] FROM [HistoricoSolicitudesItems] WHERE [HistoricoSolicitudesID] = @HistoricoSolicitudesID ORDER BY [HistoricoSolicitudesID] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP004Q3,100, GxCacheFrequency.OFF ,true,false )
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
                ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
                ((int[]) buf[2])[0] = rslt.getInt(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((bool[]) buf[5])[0] = rslt.wasNull(5);
                ((string[]) buf[6])[0] = rslt.getString(6, 20);
                ((string[]) buf[7])[0] = rslt.getString(7, 100);
                ((long[]) buf[8])[0] = rslt.getLong(8);
                ((string[]) buf[9])[0] = rslt.getString(9, 120);
                ((long[]) buf[10])[0] = rslt.getLong(10);
                ((string[]) buf[11])[0] = rslt.getString(11, 1);
                ((string[]) buf[12])[0] = rslt.getString(12, 1);
                ((string[]) buf[13])[0] = rslt.getString(13, 80);
                ((decimal[]) buf[14])[0] = rslt.getDecimal(14);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((decimal[]) buf[2])[0] = rslt.getDecimal(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 1);
                ((string[]) buf[4])[0] = rslt.getString(5, 1);
                ((short[]) buf[5])[0] = rslt.getShort(6);
                ((short[]) buf[6])[0] = rslt.getShort(7);
                return;
       }
    }

 }

}

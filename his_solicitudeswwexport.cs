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
   public class his_solicitudeswwexport : GXProcedure
   {
      public his_solicitudeswwexport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public his_solicitudeswwexport( IGxContext context )
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
         new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWHIS_Solicitudes", out  GXt_boolean1) ;
         AV8IsAuthorized = GXt_boolean1;
         if ( ! AV8IsAuthorized )
         {
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "wwpbaseobjects.notauthorized.aspx"+GXUtil.UrlEncode(StringUtil.RTrim(AV51Pgmname));
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
         AV12Filename = GXt_char2 + "HIS_SolicitudesWWExport-" + StringUtil.Trim( StringUtil.Str( (decimal)(AV16Random), 8, 0)) + ".xlsx";
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
         if ( ! ( (0==AV20SolicitudesID2) ) )
         {
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  "") ;
            AV14CellRow = GXt_int3;
            if ( AV19SolicitudesID2Operator == 0 )
            {
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+0, 1, 1).Text = StringUtil.Format( "%1 (%2)", context.GetMessage( "Solicitud Id", ""), "=", "", "", "", "", "", "", "");
            }
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Number = AV20SolicitudesID2;
         }
         if ( ! ( (0==AV36TFSolicitudesID2) && (0==AV37TFSolicitudesID2_To) ) )
         {
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Solicitud Id", "")) ;
            AV14CellRow = GXt_int3;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Number = AV36TFSolicitudesID2;
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  false, ref  GXt_int3,  (short)(AV15FirstColumn+2),  context.GetMessage( "WWP_TSTo", "")) ;
            AV14CellRow = GXt_int3;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+3, 1, 1).Number = AV37TFSolicitudesID2_To;
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV39TFUsuario_Sel)) ) )
         {
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Usuario", "")) ;
            AV14CellRow = GXt_int3;
            GXt_char2 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV39TFUsuario_Sel)) ? context.GetMessage( "WWP_TitleFilter_EmptyOption", "") : AV39TFUsuario_Sel), out  GXt_char2) ;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV38TFUsuario)) ) )
            {
               GXt_int3 = (short)(AV14CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Usuario", "")) ;
               AV14CellRow = GXt_int3;
               GXt_char2 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV38TFUsuario, out  GXt_char2) ;
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
            }
         }
         if ( ! ( (DateTime.MinValue==AV40TFFechaCambio) && (DateTime.MinValue==AV41TFFechaCambio_To) ) )
         {
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Fecha Cambio", "")) ;
            AV14CellRow = GXt_int3;
            AV11ExcelDocument.SetDateFormat(context, 8, 5, ((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0), DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt")), "/", ":", " ");
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Date = AV40TFFechaCambio;
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  false, ref  GXt_int3,  (short)(AV15FirstColumn+2),  context.GetMessage( "WWP_TSTo", "")) ;
            AV14CellRow = GXt_int3;
            AV11ExcelDocument.SetDateFormat(context, 8, 5, ((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0), DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt")), "/", ":", " ");
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+3, 1, 1).Date = AV41TFFechaCambio_To;
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV45TFCampoModificado_Sel)) ) )
         {
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Campo Modificado", "")) ;
            AV14CellRow = GXt_int3;
            GXt_char2 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV45TFCampoModificado_Sel)) ? context.GetMessage( "WWP_TitleFilter_EmptyOption", "") : AV45TFCampoModificado_Sel), out  GXt_char2) ;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV44TFCampoModificado)) ) )
            {
               GXt_int3 = (short)(AV14CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Campo Modificado", "")) ;
               AV14CellRow = GXt_int3;
               GXt_char2 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV44TFCampoModificado, out  GXt_char2) ;
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV47TFValorAnterior_Sel)) ) )
         {
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Valor Anterior", "")) ;
            AV14CellRow = GXt_int3;
            GXt_char2 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV47TFValorAnterior_Sel)) ? context.GetMessage( "WWP_TitleFilter_EmptyOption", "") : AV47TFValorAnterior_Sel), out  GXt_char2) ;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV46TFValorAnterior)) ) )
            {
               GXt_int3 = (short)(AV14CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Valor Anterior", "")) ;
               AV14CellRow = GXt_int3;
               GXt_char2 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV46TFValorAnterior, out  GXt_char2) ;
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV49TFValorNuevo_Sel)) ) )
         {
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Valor Nuevo", "")) ;
            AV14CellRow = GXt_int3;
            GXt_char2 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV49TFValorNuevo_Sel)) ? context.GetMessage( "WWP_TitleFilter_EmptyOption", "") : AV49TFValorNuevo_Sel), out  GXt_char2) ;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV48TFValorNuevo)) ) )
            {
               GXt_int3 = (short)(AV14CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Valor Nuevo", "")) ;
               AV14CellRow = GXt_int3;
               GXt_char2 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV48TFValorNuevo, out  GXt_char2) ;
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
            }
         }
         AV14CellRow = (int)(AV14CellRow+2);
      }

      protected void S141( )
      {
         /* 'WRITECOLUMNTITLES' Routine */
         returnInSub = false;
         AV33VisibleColumnCount = 0;
         if ( StringUtil.StrCmp(AV21Session.Get("HIS_SolicitudesWWColumnsSelector"), "") != 0 )
         {
            AV28ColumnsSelectorXML = AV21Session.Get("HIS_SolicitudesWWColumnsSelector");
            AV25ColumnsSelector.FromXml(AV28ColumnsSelectorXML, null, "", "");
         }
         else
         {
            /* Execute user subroutine: 'INITIALIZECOLUMNSSELECTOR' */
            S151 ();
            if (returnInSub) return;
         }
         AV25ColumnsSelector.gxTpr_Columns.Sort("Order");
         AV52GXV1 = 1;
         while ( AV52GXV1 <= AV25ColumnsSelector.gxTpr_Columns.Count )
         {
            AV27ColumnsSelector_Column = ((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV25ColumnsSelector.gxTpr_Columns.Item(AV52GXV1));
            if ( AV27ColumnsSelector_Column.gxTpr_Isvisible )
            {
               AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV33VisibleColumnCount), 1, 1).Text = context.GetMessage( (String.IsNullOrEmpty(StringUtil.RTrim( AV27ColumnsSelector_Column.gxTpr_Displayname)) ? AV27ColumnsSelector_Column.gxTpr_Columnname : AV27ColumnsSelector_Column.gxTpr_Displayname), "");
               AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV33VisibleColumnCount), 1, 1).Bold = 1;
               AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV33VisibleColumnCount), 1, 1).Color = 11;
               AV33VisibleColumnCount = (long)(AV33VisibleColumnCount+1);
            }
            AV52GXV1 = (int)(AV52GXV1+1);
         }
      }

      protected void S161( )
      {
         /* 'WRITEDATA' Routine */
         returnInSub = false;
         AV54His_solicitudeswwds_1_solicitudesid2 = AV20SolicitudesID2;
         AV55His_solicitudeswwds_2_tfsolicitudesid2 = AV36TFSolicitudesID2;
         AV56His_solicitudeswwds_3_tfsolicitudesid2_to = AV37TFSolicitudesID2_To;
         AV57His_solicitudeswwds_4_tfusuario = AV38TFUsuario;
         AV58His_solicitudeswwds_5_tfusuario_sel = AV39TFUsuario_Sel;
         AV59His_solicitudeswwds_6_tffechacambio = AV40TFFechaCambio;
         AV60His_solicitudeswwds_7_tffechacambio_to = AV41TFFechaCambio_To;
         AV61His_solicitudeswwds_8_tfcampomodificado = AV44TFCampoModificado;
         AV62His_solicitudeswwds_9_tfcampomodificado_sel = AV45TFCampoModificado_Sel;
         AV63His_solicitudeswwds_10_tfvaloranterior = AV46TFValorAnterior;
         AV64His_solicitudeswwds_11_tfvaloranterior_sel = AV47TFValorAnterior_Sel;
         AV65His_solicitudeswwds_12_tfvalornuevo = AV48TFValorNuevo;
         AV66His_solicitudeswwds_13_tfvalornuevo_sel = AV49TFValorNuevo_Sel;
         pr_datastore1.dynParam(0, new Object[]{ new Object[]{
                                              AV19SolicitudesID2Operator ,
                                              AV54His_solicitudeswwds_1_solicitudesid2 ,
                                              AV55His_solicitudeswwds_2_tfsolicitudesid2 ,
                                              AV56His_solicitudeswwds_3_tfsolicitudesid2_to ,
                                              AV58His_solicitudeswwds_5_tfusuario_sel ,
                                              AV57His_solicitudeswwds_4_tfusuario ,
                                              AV59His_solicitudeswwds_6_tffechacambio ,
                                              AV60His_solicitudeswwds_7_tffechacambio_to ,
                                              AV62His_solicitudeswwds_9_tfcampomodificado_sel ,
                                              AV61His_solicitudeswwds_8_tfcampomodificado ,
                                              AV64His_solicitudeswwds_11_tfvaloranterior_sel ,
                                              AV63His_solicitudeswwds_10_tfvaloranterior ,
                                              AV66His_solicitudeswwds_13_tfvalornuevo_sel ,
                                              AV65His_solicitudeswwds_12_tfvalornuevo ,
                                              A910SolicitudesID2 ,
                                              A912Usuario ,
                                              A911FechaCambio ,
                                              A914CampoModificado ,
                                              A915ValorAnterior ,
                                              A916ValorNuevo ,
                                              AV17OrderedBy ,
                                              AV18OrderedDsc } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.LONG, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN,
                                              TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV57His_solicitudeswwds_4_tfusuario = StringUtil.Concat( StringUtil.RTrim( AV57His_solicitudeswwds_4_tfusuario), "%", "");
         lV61His_solicitudeswwds_8_tfcampomodificado = StringUtil.Concat( StringUtil.RTrim( AV61His_solicitudeswwds_8_tfcampomodificado), "%", "");
         lV63His_solicitudeswwds_10_tfvaloranterior = StringUtil.Concat( StringUtil.RTrim( AV63His_solicitudeswwds_10_tfvaloranterior), "%", "");
         lV65His_solicitudeswwds_12_tfvalornuevo = StringUtil.Concat( StringUtil.RTrim( AV65His_solicitudeswwds_12_tfvalornuevo), "%", "");
         /* Using cursor P00KD2 */
         pr_datastore1.execute(0, new Object[] {AV54His_solicitudeswwds_1_solicitudesid2, AV55His_solicitudeswwds_2_tfsolicitudesid2, AV56His_solicitudeswwds_3_tfsolicitudesid2_to, lV57His_solicitudeswwds_4_tfusuario, AV58His_solicitudeswwds_5_tfusuario_sel, AV59His_solicitudeswwds_6_tffechacambio, AV60His_solicitudeswwds_7_tffechacambio_to, lV61His_solicitudeswwds_8_tfcampomodificado, AV62His_solicitudeswwds_9_tfcampomodificado_sel, lV63His_solicitudeswwds_10_tfvaloranterior, AV64His_solicitudeswwds_11_tfvaloranterior_sel, lV65His_solicitudeswwds_12_tfvalornuevo, AV66His_solicitudeswwds_13_tfvalornuevo_sel});
         while ( (pr_datastore1.getStatus(0) != 101) )
         {
            A916ValorNuevo = P00KD2_A916ValorNuevo[0];
            n916ValorNuevo = P00KD2_n916ValorNuevo[0];
            A915ValorAnterior = P00KD2_A915ValorAnterior[0];
            n915ValorAnterior = P00KD2_n915ValorAnterior[0];
            A914CampoModificado = P00KD2_A914CampoModificado[0];
            n914CampoModificado = P00KD2_n914CampoModificado[0];
            A911FechaCambio = P00KD2_A911FechaCambio[0];
            A912Usuario = P00KD2_A912Usuario[0];
            A910SolicitudesID2 = P00KD2_A910SolicitudesID2[0];
            A909HistorialID = P00KD2_A909HistorialID[0];
            AV14CellRow = (int)(AV14CellRow+1);
            /* Execute user subroutine: 'BEFOREWRITELINE' */
            S172 ();
            if ( returnInSub )
            {
               pr_datastore1.close(0);
               returnInSub = true;
               if (true) return;
            }
            AV33VisibleColumnCount = 0;
            AV67GXV2 = 1;
            while ( AV67GXV2 <= AV25ColumnsSelector.gxTpr_Columns.Count )
            {
               AV27ColumnsSelector_Column = ((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV25ColumnsSelector.gxTpr_Columns.Item(AV67GXV2));
               if ( AV27ColumnsSelector_Column.gxTpr_Isvisible )
               {
                  if ( StringUtil.StrCmp(AV27ColumnsSelector_Column.gxTpr_Columnname, "SolicitudesID2") == 0 )
                  {
                     AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV33VisibleColumnCount), 1, 1).Number = A910SolicitudesID2;
                  }
                  else if ( StringUtil.StrCmp(AV27ColumnsSelector_Column.gxTpr_Columnname, "Usuario") == 0 )
                  {
                     GXt_char2 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A912Usuario, out  GXt_char2) ;
                     AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV33VisibleColumnCount), 1, 1).Text = GXt_char2;
                  }
                  else if ( StringUtil.StrCmp(AV27ColumnsSelector_Column.gxTpr_Columnname, "FechaCambio") == 0 )
                  {
                     AV11ExcelDocument.SetDateFormat(context, 8, 5, ((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0), DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt")), "/", ":", " ");
                     AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV33VisibleColumnCount), 1, 1).Date = A911FechaCambio;
                  }
                  else if ( StringUtil.StrCmp(AV27ColumnsSelector_Column.gxTpr_Columnname, "CampoModificado") == 0 )
                  {
                     GXt_char2 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A914CampoModificado, out  GXt_char2) ;
                     AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV33VisibleColumnCount), 1, 1).Text = GXt_char2;
                  }
                  else if ( StringUtil.StrCmp(AV27ColumnsSelector_Column.gxTpr_Columnname, "ValorAnterior") == 0 )
                  {
                     GXt_char2 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A915ValorAnterior, out  GXt_char2) ;
                     AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV33VisibleColumnCount), 1, 1).Text = GXt_char2;
                  }
                  else if ( StringUtil.StrCmp(AV27ColumnsSelector_Column.gxTpr_Columnname, "ValorNuevo") == 0 )
                  {
                     GXt_char2 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A916ValorNuevo, out  GXt_char2) ;
                     AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV33VisibleColumnCount), 1, 1).Text = GXt_char2;
                  }
                  AV33VisibleColumnCount = (long)(AV33VisibleColumnCount+1);
               }
               AV67GXV2 = (int)(AV67GXV2+1);
            }
            /* Execute user subroutine: 'AFTERWRITELINE' */
            S182 ();
            if ( returnInSub )
            {
               pr_datastore1.close(0);
               returnInSub = true;
               if (true) return;
            }
            pr_datastore1.readNext(0);
         }
         pr_datastore1.close(0);
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
         AV21Session.Set("WWPExportFilePath", AV12Filename);
         AV21Session.Set("WWPExportFileName", "HIS_SolicitudesWWExport.xlsx");
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
         AV25ColumnsSelector = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector(context);
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV25ColumnsSelector,  "SolicitudesID2",  "",  "Solicitud Id",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV25ColumnsSelector,  "Usuario",  "",  "Usuario",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV25ColumnsSelector,  "FechaCambio",  "",  "Fecha Cambio",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV25ColumnsSelector,  "CampoModificado",  "",  "Campo Modificado",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV25ColumnsSelector,  "ValorAnterior",  "",  "Valor Anterior",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV25ColumnsSelector,  "ValorNuevo",  "",  "Valor Nuevo",  true,  "") ;
         GXt_char2 = AV29UserCustomValue;
         new GeneXus.Programs.wwpbaseobjects.loadcolumnsselectorstate(context ).execute(  "HIS_SolicitudesWWColumnsSelector", out  GXt_char2) ;
         AV29UserCustomValue = GXt_char2;
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV29UserCustomValue)) ) )
         {
            AV26ColumnsSelectorAux.FromXml(AV29UserCustomValue, null, "", "");
            new GeneXus.Programs.wwpbaseobjects.wwp_columnselector_updatecolumns(context ).execute( ref  AV26ColumnsSelectorAux, ref  AV25ColumnsSelector) ;
         }
      }

      protected void S201( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV21Session.Get("HIS_SolicitudesWWGridState"), "") == 0 )
         {
            AV23GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "HIS_SolicitudesWWGridState"), null, "", "");
         }
         else
         {
            AV23GridState.FromXml(AV21Session.Get("HIS_SolicitudesWWGridState"), null, "", "");
         }
         AV17OrderedBy = AV23GridState.gxTpr_Orderedby;
         AV18OrderedDsc = AV23GridState.gxTpr_Ordereddsc;
         AV68GXV3 = 1;
         while ( AV68GXV3 <= AV23GridState.gxTpr_Filtervalues.Count )
         {
            AV24GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV23GridState.gxTpr_Filtervalues.Item(AV68GXV3));
            if ( StringUtil.StrCmp(AV24GridStateFilterValue.gxTpr_Name, "SOLICITUDESID2") == 0 )
            {
               AV20SolicitudesID2 = (long)(Math.Round(NumberUtil.Val( AV24GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV19SolicitudesID2Operator = AV24GridStateFilterValue.gxTpr_Operator;
            }
            else if ( StringUtil.StrCmp(AV24GridStateFilterValue.gxTpr_Name, "TFSOLICITUDESID2") == 0 )
            {
               AV36TFSolicitudesID2 = (long)(Math.Round(NumberUtil.Val( AV24GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV37TFSolicitudesID2_To = (long)(Math.Round(NumberUtil.Val( AV24GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV24GridStateFilterValue.gxTpr_Name, "TFUSUARIO") == 0 )
            {
               AV38TFUsuario = AV24GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV24GridStateFilterValue.gxTpr_Name, "TFUSUARIO_SEL") == 0 )
            {
               AV39TFUsuario_Sel = AV24GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV24GridStateFilterValue.gxTpr_Name, "TFFECHACAMBIO") == 0 )
            {
               AV40TFFechaCambio = context.localUtil.CToT( AV24GridStateFilterValue.gxTpr_Value, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               AV41TFFechaCambio_To = context.localUtil.CToT( AV24GridStateFilterValue.gxTpr_Valueto, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
            }
            else if ( StringUtil.StrCmp(AV24GridStateFilterValue.gxTpr_Name, "TFCAMPOMODIFICADO") == 0 )
            {
               AV44TFCampoModificado = AV24GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV24GridStateFilterValue.gxTpr_Name, "TFCAMPOMODIFICADO_SEL") == 0 )
            {
               AV45TFCampoModificado_Sel = AV24GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV24GridStateFilterValue.gxTpr_Name, "TFVALORANTERIOR") == 0 )
            {
               AV46TFValorAnterior = AV24GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV24GridStateFilterValue.gxTpr_Name, "TFVALORANTERIOR_SEL") == 0 )
            {
               AV47TFValorAnterior_Sel = AV24GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV24GridStateFilterValue.gxTpr_Name, "TFVALORNUEVO") == 0 )
            {
               AV48TFValorNuevo = AV24GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV24GridStateFilterValue.gxTpr_Name, "TFVALORNUEVO_SEL") == 0 )
            {
               AV49TFValorNuevo_Sel = AV24GridStateFilterValue.gxTpr_Value;
            }
            AV68GXV3 = (int)(AV68GXV3+1);
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
         AV51Pgmname = "";
         GXKey = "";
         GXEncryptionTmp = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV11ExcelDocument = new ExcelDocumentI();
         AV39TFUsuario_Sel = "";
         AV38TFUsuario = "";
         AV40TFFechaCambio = (DateTime)(DateTime.MinValue);
         AV41TFFechaCambio_To = (DateTime)(DateTime.MinValue);
         AV45TFCampoModificado_Sel = "";
         AV44TFCampoModificado = "";
         AV47TFValorAnterior_Sel = "";
         AV46TFValorAnterior = "";
         AV49TFValorNuevo_Sel = "";
         AV48TFValorNuevo = "";
         AV21Session = context.GetSession();
         AV28ColumnsSelectorXML = "";
         AV25ColumnsSelector = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector(context);
         AV27ColumnsSelector_Column = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column(context);
         AV57His_solicitudeswwds_4_tfusuario = "";
         AV58His_solicitudeswwds_5_tfusuario_sel = "";
         AV59His_solicitudeswwds_6_tffechacambio = (DateTime)(DateTime.MinValue);
         AV60His_solicitudeswwds_7_tffechacambio_to = (DateTime)(DateTime.MinValue);
         AV61His_solicitudeswwds_8_tfcampomodificado = "";
         AV62His_solicitudeswwds_9_tfcampomodificado_sel = "";
         AV63His_solicitudeswwds_10_tfvaloranterior = "";
         AV64His_solicitudeswwds_11_tfvaloranterior_sel = "";
         AV65His_solicitudeswwds_12_tfvalornuevo = "";
         AV66His_solicitudeswwds_13_tfvalornuevo_sel = "";
         lV57His_solicitudeswwds_4_tfusuario = "";
         lV61His_solicitudeswwds_8_tfcampomodificado = "";
         lV63His_solicitudeswwds_10_tfvaloranterior = "";
         lV65His_solicitudeswwds_12_tfvalornuevo = "";
         A912Usuario = "";
         A911FechaCambio = (DateTime)(DateTime.MinValue);
         A914CampoModificado = "";
         A915ValorAnterior = "";
         A916ValorNuevo = "";
         P00KD2_A916ValorNuevo = new string[] {""} ;
         P00KD2_n916ValorNuevo = new bool[] {false} ;
         P00KD2_A915ValorAnterior = new string[] {""} ;
         P00KD2_n915ValorAnterior = new bool[] {false} ;
         P00KD2_A914CampoModificado = new string[] {""} ;
         P00KD2_n914CampoModificado = new bool[] {false} ;
         P00KD2_A911FechaCambio = new DateTime[] {DateTime.MinValue} ;
         P00KD2_A912Usuario = new string[] {""} ;
         P00KD2_A910SolicitudesID2 = new long[1] ;
         P00KD2_A909HistorialID = new int[1] ;
         AV29UserCustomValue = "";
         GXt_char2 = "";
         AV26ColumnsSelectorAux = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector(context);
         AV23GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV24GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.his_solicitudeswwexport__datastore1(),
            new Object[][] {
                new Object[] {
               P00KD2_A916ValorNuevo, P00KD2_n916ValorNuevo, P00KD2_A915ValorAnterior, P00KD2_n915ValorAnterior, P00KD2_A914CampoModificado, P00KD2_n914CampoModificado, P00KD2_A911FechaCambio, P00KD2_A912Usuario, P00KD2_A910SolicitudesID2, P00KD2_A909HistorialID
               }
            }
         );
         AV51Pgmname = "HIS_SolicitudesWWExport";
         /* GeneXus formulas. */
         AV51Pgmname = "HIS_SolicitudesWWExport";
      }

      private short AV19SolicitudesID2Operator ;
      private short GXt_int3 ;
      private short AV17OrderedBy ;
      private int AV14CellRow ;
      private int AV15FirstColumn ;
      private int AV16Random ;
      private int AV52GXV1 ;
      private int A909HistorialID ;
      private int AV67GXV2 ;
      private int AV68GXV3 ;
      private long AV20SolicitudesID2 ;
      private long AV36TFSolicitudesID2 ;
      private long AV37TFSolicitudesID2_To ;
      private long AV33VisibleColumnCount ;
      private long AV54His_solicitudeswwds_1_solicitudesid2 ;
      private long AV55His_solicitudeswwds_2_tfsolicitudesid2 ;
      private long AV56His_solicitudeswwds_3_tfsolicitudesid2_to ;
      private long A910SolicitudesID2 ;
      private string AV51Pgmname ;
      private string GXKey ;
      private string GXEncryptionTmp ;
      private string GXt_char2 ;
      private DateTime AV40TFFechaCambio ;
      private DateTime AV41TFFechaCambio_To ;
      private DateTime AV59His_solicitudeswwds_6_tffechacambio ;
      private DateTime AV60His_solicitudeswwds_7_tffechacambio_to ;
      private DateTime A911FechaCambio ;
      private bool AV8IsAuthorized ;
      private bool GXt_boolean1 ;
      private bool returnInSub ;
      private bool AV18OrderedDsc ;
      private bool n916ValorNuevo ;
      private bool n915ValorAnterior ;
      private bool n914CampoModificado ;
      private string AV28ColumnsSelectorXML ;
      private string AV29UserCustomValue ;
      private string AV12Filename ;
      private string AV13ErrorMessage ;
      private string AV39TFUsuario_Sel ;
      private string AV38TFUsuario ;
      private string AV45TFCampoModificado_Sel ;
      private string AV44TFCampoModificado ;
      private string AV47TFValorAnterior_Sel ;
      private string AV46TFValorAnterior ;
      private string AV49TFValorNuevo_Sel ;
      private string AV48TFValorNuevo ;
      private string AV57His_solicitudeswwds_4_tfusuario ;
      private string AV58His_solicitudeswwds_5_tfusuario_sel ;
      private string AV61His_solicitudeswwds_8_tfcampomodificado ;
      private string AV62His_solicitudeswwds_9_tfcampomodificado_sel ;
      private string AV63His_solicitudeswwds_10_tfvaloranterior ;
      private string AV64His_solicitudeswwds_11_tfvaloranterior_sel ;
      private string AV65His_solicitudeswwds_12_tfvalornuevo ;
      private string AV66His_solicitudeswwds_13_tfvalornuevo_sel ;
      private string lV57His_solicitudeswwds_4_tfusuario ;
      private string lV61His_solicitudeswwds_8_tfcampomodificado ;
      private string lV63His_solicitudeswwds_10_tfvaloranterior ;
      private string lV65His_solicitudeswwds_12_tfvalornuevo ;
      private string A912Usuario ;
      private string A914CampoModificado ;
      private string A915ValorAnterior ;
      private string A916ValorNuevo ;
      private IGxSession AV21Session ;
      private ExcelDocumentI AV11ExcelDocument ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector AV25ColumnsSelector ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column AV27ColumnsSelector_Column ;
      private IDataStoreProvider pr_datastore1 ;
      private string[] P00KD2_A916ValorNuevo ;
      private bool[] P00KD2_n916ValorNuevo ;
      private string[] P00KD2_A915ValorAnterior ;
      private bool[] P00KD2_n915ValorAnterior ;
      private string[] P00KD2_A914CampoModificado ;
      private bool[] P00KD2_n914CampoModificado ;
      private DateTime[] P00KD2_A911FechaCambio ;
      private string[] P00KD2_A912Usuario ;
      private long[] P00KD2_A910SolicitudesID2 ;
      private int[] P00KD2_A909HistorialID ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector AV26ColumnsSelectorAux ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV23GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV24GridStateFilterValue ;
      private string aP0_Filename ;
      private string aP1_ErrorMessage ;
   }

   public class his_solicitudeswwexport__datastore1 : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00KD2( IGxContext context ,
                                             short AV19SolicitudesID2Operator ,
                                             long AV54His_solicitudeswwds_1_solicitudesid2 ,
                                             long AV55His_solicitudeswwds_2_tfsolicitudesid2 ,
                                             long AV56His_solicitudeswwds_3_tfsolicitudesid2_to ,
                                             string AV58His_solicitudeswwds_5_tfusuario_sel ,
                                             string AV57His_solicitudeswwds_4_tfusuario ,
                                             DateTime AV59His_solicitudeswwds_6_tffechacambio ,
                                             DateTime AV60His_solicitudeswwds_7_tffechacambio_to ,
                                             string AV62His_solicitudeswwds_9_tfcampomodificado_sel ,
                                             string AV61His_solicitudeswwds_8_tfcampomodificado ,
                                             string AV64His_solicitudeswwds_11_tfvaloranterior_sel ,
                                             string AV63His_solicitudeswwds_10_tfvaloranterior ,
                                             string AV66His_solicitudeswwds_13_tfvalornuevo_sel ,
                                             string AV65His_solicitudeswwds_12_tfvalornuevo ,
                                             long A910SolicitudesID2 ,
                                             string A912Usuario ,
                                             DateTime A911FechaCambio ,
                                             string A914CampoModificado ,
                                             string A915ValorAnterior ,
                                             string A916ValorNuevo ,
                                             short AV17OrderedBy ,
                                             bool AV18OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int4 = new short[13];
         Object[] GXv_Object5 = new Object[2];
         scmdbuf = "SELECT [ValorNuevo], [ValorAnterior], [CampoModificado], [FechaCambio], [Usuario], [SolicitudesID], [HistorialID] FROM dbo.[HIS_Solicitudes]";
         if ( ( AV19SolicitudesID2Operator == 0 ) && ( ! (0==AV54His_solicitudeswwds_1_solicitudesid2) ) )
         {
            AddWhere(sWhereString, "([SolicitudesID] = @AV54His_solicitudeswwds_1_solicitudesid2)");
         }
         else
         {
            GXv_int4[0] = 1;
         }
         if ( ! (0==AV55His_solicitudeswwds_2_tfsolicitudesid2) )
         {
            AddWhere(sWhereString, "([SolicitudesID] >= @AV55His_solicitudeswwds_2_tfsolicitudesid2)");
         }
         else
         {
            GXv_int4[1] = 1;
         }
         if ( ! (0==AV56His_solicitudeswwds_3_tfsolicitudesid2_to) )
         {
            AddWhere(sWhereString, "([SolicitudesID] <= @AV56His_solicitudeswwds_3_tfsolicitudesid2_to)");
         }
         else
         {
            GXv_int4[2] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV58His_solicitudeswwds_5_tfusuario_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57His_solicitudeswwds_4_tfusuario)) ) )
         {
            AddWhere(sWhereString, "(UPPER([Usuario]) like UPPER(@lV57His_solicitudeswwds_4_tfusuario))");
         }
         else
         {
            GXv_int4[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV58His_solicitudeswwds_5_tfusuario_sel)) && ! ( StringUtil.StrCmp(AV58His_solicitudeswwds_5_tfusuario_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([Usuario] = @AV58His_solicitudeswwds_5_tfusuario_sel)");
         }
         else
         {
            GXv_int4[4] = 1;
         }
         if ( StringUtil.StrCmp(AV58His_solicitudeswwds_5_tfusuario_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([Usuario] = ''))");
         }
         if ( ! (DateTime.MinValue==AV59His_solicitudeswwds_6_tffechacambio) )
         {
            AddWhere(sWhereString, "([FechaCambio] >= @AV59His_solicitudeswwds_6_tffechacambio)");
         }
         else
         {
            GXv_int4[5] = 1;
         }
         if ( ! (DateTime.MinValue==AV60His_solicitudeswwds_7_tffechacambio_to) )
         {
            AddWhere(sWhereString, "([FechaCambio] <= @AV60His_solicitudeswwds_7_tffechacambio_to)");
         }
         else
         {
            GXv_int4[6] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV62His_solicitudeswwds_9_tfcampomodificado_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61His_solicitudeswwds_8_tfcampomodificado)) ) )
         {
            AddWhere(sWhereString, "(UPPER([CampoModificado]) like UPPER(@lV61His_solicitudeswwds_8_tfcampomodificado))");
         }
         else
         {
            GXv_int4[7] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62His_solicitudeswwds_9_tfcampomodificado_sel)) && ! ( StringUtil.StrCmp(AV62His_solicitudeswwds_9_tfcampomodificado_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([CampoModificado] = @AV62His_solicitudeswwds_9_tfcampomodificado_sel)");
         }
         else
         {
            GXv_int4[8] = 1;
         }
         if ( StringUtil.StrCmp(AV62His_solicitudeswwds_9_tfcampomodificado_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "([CampoModificado] IS NULL or ([CampoModificado] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV64His_solicitudeswwds_11_tfvaloranterior_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63His_solicitudeswwds_10_tfvaloranterior)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ValorAnterior]) like UPPER(@lV63His_solicitudeswwds_10_tfvaloranterior))");
         }
         else
         {
            GXv_int4[9] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64His_solicitudeswwds_11_tfvaloranterior_sel)) && ! ( StringUtil.StrCmp(AV64His_solicitudeswwds_11_tfvaloranterior_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([ValorAnterior] = @AV64His_solicitudeswwds_11_tfvaloranterior_sel)");
         }
         else
         {
            GXv_int4[10] = 1;
         }
         if ( StringUtil.StrCmp(AV64His_solicitudeswwds_11_tfvaloranterior_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "([ValorAnterior] IS NULL or ([ValorAnterior] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV66His_solicitudeswwds_13_tfvalornuevo_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65His_solicitudeswwds_12_tfvalornuevo)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ValorNuevo]) like UPPER(@lV65His_solicitudeswwds_12_tfvalornuevo))");
         }
         else
         {
            GXv_int4[11] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66His_solicitudeswwds_13_tfvalornuevo_sel)) && ! ( StringUtil.StrCmp(AV66His_solicitudeswwds_13_tfvalornuevo_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([ValorNuevo] = @AV66His_solicitudeswwds_13_tfvalornuevo_sel)");
         }
         else
         {
            GXv_int4[12] = 1;
         }
         if ( StringUtil.StrCmp(AV66His_solicitudeswwds_13_tfvalornuevo_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "([ValorNuevo] IS NULL or ([ValorNuevo] = ''))");
         }
         scmdbuf += sWhereString;
         if ( ( AV17OrderedBy == 1 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY [SolicitudesID]";
         }
         else if ( ( AV17OrderedBy == 1 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [SolicitudesID] DESC";
         }
         else if ( ( AV17OrderedBy == 2 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY [Usuario]";
         }
         else if ( ( AV17OrderedBy == 2 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [Usuario] DESC";
         }
         else if ( ( AV17OrderedBy == 3 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY [FechaCambio]";
         }
         else if ( ( AV17OrderedBy == 3 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [FechaCambio] DESC";
         }
         else if ( ( AV17OrderedBy == 4 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY [CampoModificado]";
         }
         else if ( ( AV17OrderedBy == 4 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [CampoModificado] DESC";
         }
         else if ( ( AV17OrderedBy == 5 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY [ValorAnterior]";
         }
         else if ( ( AV17OrderedBy == 5 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [ValorAnterior] DESC";
         }
         else if ( ( AV17OrderedBy == 6 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY [ValorNuevo]";
         }
         else if ( ( AV17OrderedBy == 6 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [ValorNuevo] DESC";
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
                     return conditional_P00KD2(context, (short)dynConstraints[0] , (long)dynConstraints[1] , (long)dynConstraints[2] , (long)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (DateTime)dynConstraints[6] , (DateTime)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (long)dynConstraints[14] , (string)dynConstraints[15] , (DateTime)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (short)dynConstraints[20] , (bool)dynConstraints[21] );
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
          Object[] prmP00KD2;
          prmP00KD2 = new Object[] {
          new ParDef("@AV54His_solicitudeswwds_1_solicitudesid2",GXType.Decimal,18,0) ,
          new ParDef("@AV55His_solicitudeswwds_2_tfsolicitudesid2",GXType.Decimal,18,0) ,
          new ParDef("@AV56His_solicitudeswwds_3_tfsolicitudesid2_to",GXType.Decimal,18,0) ,
          new ParDef("@lV57His_solicitudeswwds_4_tfusuario",GXType.VarChar,100,0) ,
          new ParDef("@AV58His_solicitudeswwds_5_tfusuario_sel",GXType.NVarChar,100,0) ,
          new ParDef("@AV59His_solicitudeswwds_6_tffechacambio",GXType.DateTime,10,8) ,
          new ParDef("@AV60His_solicitudeswwds_7_tffechacambio_to",GXType.DateTime,10,8) ,
          new ParDef("@lV61His_solicitudeswwds_8_tfcampomodificado",GXType.VarChar,100,0) ,
          new ParDef("@AV62His_solicitudeswwds_9_tfcampomodificado_sel",GXType.NVarChar,100,0) ,
          new ParDef("@lV63His_solicitudeswwds_10_tfvaloranterior",GXType.VarChar,500,0) ,
          new ParDef("@AV64His_solicitudeswwds_11_tfvaloranterior_sel",GXType.NVarChar,500,0) ,
          new ParDef("@lV65His_solicitudeswwds_12_tfvalornuevo",GXType.VarChar,500,0) ,
          new ParDef("@AV66His_solicitudeswwds_13_tfvalornuevo_sel",GXType.NVarChar,500,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00KD2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00KD2,100, GxCacheFrequency.OFF ,true,false )
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
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getVarchar(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((string[]) buf[4])[0] = rslt.getVarchar(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((DateTime[]) buf[6])[0] = rslt.getGXDateTime(4);
                ((string[]) buf[7])[0] = rslt.getVarchar(5);
                ((long[]) buf[8])[0] = rslt.getLong(6);
                ((int[]) buf[9])[0] = rslt.getInt(7);
                return;
       }
    }

    public override string getDataStoreName( )
    {
       return "DATASTORE1";
    }

 }

}

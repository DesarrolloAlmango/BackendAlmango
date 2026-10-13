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
   public class estadosnotificacionwwexport : GXProcedure
   {
      public estadosnotificacionwwexport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public estadosnotificacionwwexport( IGxContext context )
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
         new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWEstadosNotificacion", out  GXt_boolean1) ;
         AV8IsAuthorized = GXt_boolean1;
         if ( ! AV8IsAuthorized )
         {
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "wwpbaseobjects.notauthorized.aspx"+GXUtil.UrlEncode(StringUtil.RTrim(AV45Pgmname));
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
         AV12Filename = GXt_char2 + "EstadosNotificacionWWExport-" + StringUtil.Trim( StringUtil.Str( (decimal)(AV16Random), 8, 0)) + ".xlsx";
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
         if ( ! ( (0==AV37TFEstadosGenericosId) && (0==AV38TFEstadosGenericosId_To) ) )
         {
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Identificador", "")) ;
            AV14CellRow = GXt_int3;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Number = AV37TFEstadosGenericosId;
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  false, ref  GXt_int3,  (short)(AV15FirstColumn+2),  context.GetMessage( "WWP_TSTo", "")) ;
            AV14CellRow = GXt_int3;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+3, 1, 1).Number = AV38TFEstadosGenericosId_To;
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV40TFEstadosGenericosNombre_Sel)) ) )
         {
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Estado", "")) ;
            AV14CellRow = GXt_int3;
            GXt_char2 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV40TFEstadosGenericosNombre_Sel)) ? context.GetMessage( "WWP_TitleFilter_EmptyOption", "") : AV40TFEstadosGenericosNombre_Sel), out  GXt_char2) ;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV39TFEstadosGenericosNombre)) ) )
            {
               GXt_int3 = (short)(AV14CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Estado", "")) ;
               AV14CellRow = GXt_int3;
               GXt_char2 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV39TFEstadosGenericosNombre, out  GXt_char2) ;
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV41TFEstadosNotificacionCliente_Sel)) ) )
         {
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Notificar al cliente el nuevo estado", "")) ;
            AV14CellRow = GXt_int3;
            if ( StringUtil.StrCmp(AV41TFEstadosNotificacionCliente_Sel, context.GetMessage( "S", "")) == 0 )
            {
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = context.GetMessage( "WWP_TSChecked", "");
            }
            else if ( StringUtil.StrCmp(AV41TFEstadosNotificacionCliente_Sel, context.GetMessage( "N", "")) == 0 )
            {
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = context.GetMessage( "WWP_TSUnChecked", "");
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV42TFEstadosNotificacionProfesional_Sel)) ) )
         {
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Notificar al profesional el nuevo estado", "")) ;
            AV14CellRow = GXt_int3;
            if ( StringUtil.StrCmp(AV42TFEstadosNotificacionProfesional_Sel, context.GetMessage( "S", "")) == 0 )
            {
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = context.GetMessage( "WWP_TSChecked", "");
            }
            else if ( StringUtil.StrCmp(AV42TFEstadosNotificacionProfesional_Sel, context.GetMessage( "N", "")) == 0 )
            {
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = context.GetMessage( "WWP_TSUnChecked", "");
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV43TFEstadosNotificacionOperador_Sel)) ) )
         {
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Notificar al operador el nuevo estado", "")) ;
            AV14CellRow = GXt_int3;
            if ( StringUtil.StrCmp(AV43TFEstadosNotificacionOperador_Sel, context.GetMessage( "S", "")) == 0 )
            {
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = context.GetMessage( "WWP_TSChecked", "");
            }
            else if ( StringUtil.StrCmp(AV43TFEstadosNotificacionOperador_Sel, context.GetMessage( "N", "")) == 0 )
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
         AV32VisibleColumnCount = 0;
         if ( StringUtil.StrCmp(AV20Session.Get("EstadosNotificacionWWColumnsSelector"), "") != 0 )
         {
            AV27ColumnsSelectorXML = AV20Session.Get("EstadosNotificacionWWColumnsSelector");
            AV24ColumnsSelector.FromXml(AV27ColumnsSelectorXML, null, "", "");
         }
         else
         {
            /* Execute user subroutine: 'INITIALIZECOLUMNSSELECTOR' */
            S151 ();
            if (returnInSub) return;
         }
         AV24ColumnsSelector.gxTpr_Columns.Sort("Order");
         AV46GXV1 = 1;
         while ( AV46GXV1 <= AV24ColumnsSelector.gxTpr_Columns.Count )
         {
            AV26ColumnsSelector_Column = ((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV24ColumnsSelector.gxTpr_Columns.Item(AV46GXV1));
            if ( AV26ColumnsSelector_Column.gxTpr_Isvisible )
            {
               AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV32VisibleColumnCount), 1, 1).Text = context.GetMessage( (String.IsNullOrEmpty(StringUtil.RTrim( AV26ColumnsSelector_Column.gxTpr_Displayname)) ? AV26ColumnsSelector_Column.gxTpr_Columnname : AV26ColumnsSelector_Column.gxTpr_Displayname), "");
               AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV32VisibleColumnCount), 1, 1).Bold = 1;
               AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV32VisibleColumnCount), 1, 1).Color = 11;
               AV32VisibleColumnCount = (long)(AV32VisibleColumnCount+1);
            }
            AV46GXV1 = (int)(AV46GXV1+1);
         }
      }

      protected void S161( )
      {
         /* 'WRITEDATA' Routine */
         returnInSub = false;
         AV48Estadosnotificacionwwds_1_filterfulltext = AV19FilterFullText;
         AV49Estadosnotificacionwwds_2_tfestadostipo = AV35TFEstadosTipo;
         AV50Estadosnotificacionwwds_3_tfestadostipo_sel = AV36TFEstadosTipo_Sel;
         AV51Estadosnotificacionwwds_4_tfestadosgenericosid = AV37TFEstadosGenericosId;
         AV52Estadosnotificacionwwds_5_tfestadosgenericosid_to = AV38TFEstadosGenericosId_To;
         AV53Estadosnotificacionwwds_6_tfestadosgenericosnombre = AV39TFEstadosGenericosNombre;
         AV54Estadosnotificacionwwds_7_tfestadosgenericosnombre_sel = AV40TFEstadosGenericosNombre_Sel;
         AV55Estadosnotificacionwwds_8_tfestadosnotificacioncliente_sel = AV41TFEstadosNotificacionCliente_Sel;
         AV56Estadosnotificacionwwds_9_tfestadosnotificacionprofesional_sel = AV42TFEstadosNotificacionProfesional_Sel;
         AV57Estadosnotificacionwwds_10_tfestadosnotificacionoperador_sel = AV43TFEstadosNotificacionOperador_Sel;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV48Estadosnotificacionwwds_1_filterfulltext ,
                                              AV50Estadosnotificacionwwds_3_tfestadostipo_sel ,
                                              AV49Estadosnotificacionwwds_2_tfestadostipo ,
                                              AV51Estadosnotificacionwwds_4_tfestadosgenericosid ,
                                              AV52Estadosnotificacionwwds_5_tfestadosgenericosid_to ,
                                              AV54Estadosnotificacionwwds_7_tfestadosgenericosnombre_sel ,
                                              AV53Estadosnotificacionwwds_6_tfestadosgenericosnombre ,
                                              AV55Estadosnotificacionwwds_8_tfestadosnotificacioncliente_sel ,
                                              AV56Estadosnotificacionwwds_9_tfestadosnotificacionprofesional_sel ,
                                              AV57Estadosnotificacionwwds_10_tfestadosnotificacionoperador_sel ,
                                              A107EstadosTipo ,
                                              A108EstadosGenericosId ,
                                              A109EstadosGenericosNombre ,
                                              A263EstadosNotificacionCliente ,
                                              A264EstadosNotificacionProfesional ,
                                              A265EstadosNotificacionOperador ,
                                              AV17OrderedBy ,
                                              AV18OrderedDsc } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV48Estadosnotificacionwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV48Estadosnotificacionwwds_1_filterfulltext), "%", "");
         lV48Estadosnotificacionwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV48Estadosnotificacionwwds_1_filterfulltext), "%", "");
         lV48Estadosnotificacionwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV48Estadosnotificacionwwds_1_filterfulltext), "%", "");
         lV49Estadosnotificacionwwds_2_tfestadostipo = StringUtil.PadR( StringUtil.RTrim( AV49Estadosnotificacionwwds_2_tfestadostipo), 3, "%");
         lV53Estadosnotificacionwwds_6_tfestadosgenericosnombre = StringUtil.PadR( StringUtil.RTrim( AV53Estadosnotificacionwwds_6_tfestadosgenericosnombre), 80, "%");
         /* Using cursor P00C82 */
         pr_default.execute(0, new Object[] {lV48Estadosnotificacionwwds_1_filterfulltext, lV48Estadosnotificacionwwds_1_filterfulltext, lV48Estadosnotificacionwwds_1_filterfulltext, lV49Estadosnotificacionwwds_2_tfestadostipo, AV50Estadosnotificacionwwds_3_tfestadostipo_sel, AV51Estadosnotificacionwwds_4_tfestadosgenericosid, AV52Estadosnotificacionwwds_5_tfestadosgenericosid_to, lV53Estadosnotificacionwwds_6_tfestadosgenericosnombre, AV54Estadosnotificacionwwds_7_tfestadosgenericosnombre_sel, AV55Estadosnotificacionwwds_8_tfestadosnotificacioncliente_sel, AV56Estadosnotificacionwwds_9_tfestadosnotificacionprofesional_sel, AV57Estadosnotificacionwwds_10_tfestadosnotificacionoperador_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A265EstadosNotificacionOperador = P00C82_A265EstadosNotificacionOperador[0];
            A264EstadosNotificacionProfesional = P00C82_A264EstadosNotificacionProfesional[0];
            A263EstadosNotificacionCliente = P00C82_A263EstadosNotificacionCliente[0];
            A109EstadosGenericosNombre = P00C82_A109EstadosGenericosNombre[0];
            A108EstadosGenericosId = P00C82_A108EstadosGenericosId[0];
            A107EstadosTipo = P00C82_A107EstadosTipo[0];
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
            AV58GXV2 = 1;
            while ( AV58GXV2 <= AV24ColumnsSelector.gxTpr_Columns.Count )
            {
               AV26ColumnsSelector_Column = ((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV24ColumnsSelector.gxTpr_Columns.Item(AV58GXV2));
               if ( AV26ColumnsSelector_Column.gxTpr_Isvisible )
               {
                  if ( StringUtil.StrCmp(AV26ColumnsSelector_Column.gxTpr_Columnname, "EstadosTipo") == 0 )
                  {
                     GXt_char2 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A107EstadosTipo, out  GXt_char2) ;
                     AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV32VisibleColumnCount), 1, 1).Text = GXt_char2;
                  }
                  else if ( StringUtil.StrCmp(AV26ColumnsSelector_Column.gxTpr_Columnname, "EstadosGenericosId") == 0 )
                  {
                     AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV32VisibleColumnCount), 1, 1).Number = A108EstadosGenericosId;
                  }
                  else if ( StringUtil.StrCmp(AV26ColumnsSelector_Column.gxTpr_Columnname, "EstadosGenericosNombre") == 0 )
                  {
                     GXt_char2 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A109EstadosGenericosNombre, out  GXt_char2) ;
                     AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV32VisibleColumnCount), 1, 1).Text = GXt_char2;
                  }
                  else if ( StringUtil.StrCmp(AV26ColumnsSelector_Column.gxTpr_Columnname, "EstadosNotificacionCliente") == 0 )
                  {
                     GXt_char2 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A263EstadosNotificacionCliente, out  GXt_char2) ;
                     AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV32VisibleColumnCount), 1, 1).Text = GXt_char2;
                  }
                  else if ( StringUtil.StrCmp(AV26ColumnsSelector_Column.gxTpr_Columnname, "EstadosNotificacionProfesional") == 0 )
                  {
                     GXt_char2 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A264EstadosNotificacionProfesional, out  GXt_char2) ;
                     AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV32VisibleColumnCount), 1, 1).Text = GXt_char2;
                  }
                  else if ( StringUtil.StrCmp(AV26ColumnsSelector_Column.gxTpr_Columnname, "EstadosNotificacionOperador") == 0 )
                  {
                     GXt_char2 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A265EstadosNotificacionOperador, out  GXt_char2) ;
                     AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV32VisibleColumnCount), 1, 1).Text = GXt_char2;
                  }
                  AV32VisibleColumnCount = (long)(AV32VisibleColumnCount+1);
               }
               AV58GXV2 = (int)(AV58GXV2+1);
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
         AV20Session.Set("WWPExportFileName", "EstadosNotificacionWWExport.xlsx");
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
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV24ColumnsSelector,  "EstadosGenericosId",  "",  "Identificador",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV24ColumnsSelector,  "EstadosGenericosNombre",  "",  "Estado",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV24ColumnsSelector,  "EstadosNotificacionCliente",  "",  "Notificar al cliente el nuevo estado",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV24ColumnsSelector,  "EstadosNotificacionProfesional",  "",  "Notificar al profesional el nuevo estado",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV24ColumnsSelector,  "EstadosNotificacionOperador",  "",  "Notificar al operador el nuevo estado",  true,  "") ;
         GXt_char2 = AV28UserCustomValue;
         new GeneXus.Programs.wwpbaseobjects.loadcolumnsselectorstate(context ).execute(  "EstadosNotificacionWWColumnsSelector", out  GXt_char2) ;
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
         if ( StringUtil.StrCmp(AV20Session.Get("EstadosNotificacionWWGridState"), "") == 0 )
         {
            AV22GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "EstadosNotificacionWWGridState"), null, "", "");
         }
         else
         {
            AV22GridState.FromXml(AV20Session.Get("EstadosNotificacionWWGridState"), null, "", "");
         }
         AV17OrderedBy = AV22GridState.gxTpr_Orderedby;
         AV18OrderedDsc = AV22GridState.gxTpr_Ordereddsc;
         AV59GXV3 = 1;
         while ( AV59GXV3 <= AV22GridState.gxTpr_Filtervalues.Count )
         {
            AV23GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV22GridState.gxTpr_Filtervalues.Item(AV59GXV3));
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
            else if ( StringUtil.StrCmp(AV23GridStateFilterValue.gxTpr_Name, "TFESTADOSGENERICOSID") == 0 )
            {
               AV37TFEstadosGenericosId = (int)(Math.Round(NumberUtil.Val( AV23GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV38TFEstadosGenericosId_To = (int)(Math.Round(NumberUtil.Val( AV23GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV23GridStateFilterValue.gxTpr_Name, "TFESTADOSGENERICOSNOMBRE") == 0 )
            {
               AV39TFEstadosGenericosNombre = AV23GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV23GridStateFilterValue.gxTpr_Name, "TFESTADOSGENERICOSNOMBRE_SEL") == 0 )
            {
               AV40TFEstadosGenericosNombre_Sel = AV23GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV23GridStateFilterValue.gxTpr_Name, "TFESTADOSNOTIFICACIONCLIENTE_SEL") == 0 )
            {
               AV41TFEstadosNotificacionCliente_Sel = AV23GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV23GridStateFilterValue.gxTpr_Name, "TFESTADOSNOTIFICACIONPROFESIONAL_SEL") == 0 )
            {
               AV42TFEstadosNotificacionProfesional_Sel = AV23GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV23GridStateFilterValue.gxTpr_Name, "TFESTADOSNOTIFICACIONOPERADOR_SEL") == 0 )
            {
               AV43TFEstadosNotificacionOperador_Sel = AV23GridStateFilterValue.gxTpr_Value;
            }
            AV59GXV3 = (int)(AV59GXV3+1);
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
         AV45Pgmname = "";
         GXKey = "";
         GXEncryptionTmp = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV11ExcelDocument = new ExcelDocumentI();
         AV19FilterFullText = "";
         AV36TFEstadosTipo_Sel = "";
         AV35TFEstadosTipo = "";
         AV40TFEstadosGenericosNombre_Sel = "";
         AV39TFEstadosGenericosNombre = "";
         AV41TFEstadosNotificacionCliente_Sel = "";
         AV42TFEstadosNotificacionProfesional_Sel = "";
         AV43TFEstadosNotificacionOperador_Sel = "";
         AV20Session = context.GetSession();
         AV27ColumnsSelectorXML = "";
         AV24ColumnsSelector = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector(context);
         AV26ColumnsSelector_Column = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column(context);
         AV48Estadosnotificacionwwds_1_filterfulltext = "";
         AV49Estadosnotificacionwwds_2_tfestadostipo = "";
         AV50Estadosnotificacionwwds_3_tfestadostipo_sel = "";
         AV53Estadosnotificacionwwds_6_tfestadosgenericosnombre = "";
         AV54Estadosnotificacionwwds_7_tfestadosgenericosnombre_sel = "";
         AV55Estadosnotificacionwwds_8_tfestadosnotificacioncliente_sel = "";
         AV56Estadosnotificacionwwds_9_tfestadosnotificacionprofesional_sel = "";
         AV57Estadosnotificacionwwds_10_tfestadosnotificacionoperador_sel = "";
         lV48Estadosnotificacionwwds_1_filterfulltext = "";
         lV49Estadosnotificacionwwds_2_tfestadostipo = "";
         lV53Estadosnotificacionwwds_6_tfestadosgenericosnombre = "";
         A107EstadosTipo = "";
         A109EstadosGenericosNombre = "";
         A263EstadosNotificacionCliente = "";
         A264EstadosNotificacionProfesional = "";
         A265EstadosNotificacionOperador = "";
         P00C82_A265EstadosNotificacionOperador = new string[] {""} ;
         P00C82_A264EstadosNotificacionProfesional = new string[] {""} ;
         P00C82_A263EstadosNotificacionCliente = new string[] {""} ;
         P00C82_A109EstadosGenericosNombre = new string[] {""} ;
         P00C82_A108EstadosGenericosId = new int[1] ;
         P00C82_A107EstadosTipo = new string[] {""} ;
         AV28UserCustomValue = "";
         GXt_char2 = "";
         AV25ColumnsSelectorAux = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector(context);
         AV22GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV23GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.estadosnotificacionwwexport__default(),
            new Object[][] {
                new Object[] {
               P00C82_A265EstadosNotificacionOperador, P00C82_A264EstadosNotificacionProfesional, P00C82_A263EstadosNotificacionCliente, P00C82_A109EstadosGenericosNombre, P00C82_A108EstadosGenericosId, P00C82_A107EstadosTipo
               }
            }
         );
         AV45Pgmname = "EstadosNotificacionWWExport";
         /* GeneXus formulas. */
         AV45Pgmname = "EstadosNotificacionWWExport";
      }

      private short GXt_int3 ;
      private short AV17OrderedBy ;
      private int AV14CellRow ;
      private int AV15FirstColumn ;
      private int AV16Random ;
      private int AV37TFEstadosGenericosId ;
      private int AV38TFEstadosGenericosId_To ;
      private int AV46GXV1 ;
      private int AV51Estadosnotificacionwwds_4_tfestadosgenericosid ;
      private int AV52Estadosnotificacionwwds_5_tfestadosgenericosid_to ;
      private int A108EstadosGenericosId ;
      private int AV58GXV2 ;
      private int AV59GXV3 ;
      private long AV32VisibleColumnCount ;
      private string AV45Pgmname ;
      private string GXKey ;
      private string GXEncryptionTmp ;
      private string AV36TFEstadosTipo_Sel ;
      private string AV35TFEstadosTipo ;
      private string AV40TFEstadosGenericosNombre_Sel ;
      private string AV39TFEstadosGenericosNombre ;
      private string AV41TFEstadosNotificacionCliente_Sel ;
      private string AV42TFEstadosNotificacionProfesional_Sel ;
      private string AV43TFEstadosNotificacionOperador_Sel ;
      private string AV49Estadosnotificacionwwds_2_tfestadostipo ;
      private string AV50Estadosnotificacionwwds_3_tfestadostipo_sel ;
      private string AV53Estadosnotificacionwwds_6_tfestadosgenericosnombre ;
      private string AV54Estadosnotificacionwwds_7_tfestadosgenericosnombre_sel ;
      private string AV55Estadosnotificacionwwds_8_tfestadosnotificacioncliente_sel ;
      private string AV56Estadosnotificacionwwds_9_tfestadosnotificacionprofesional_sel ;
      private string AV57Estadosnotificacionwwds_10_tfestadosnotificacionoperador_sel ;
      private string lV49Estadosnotificacionwwds_2_tfestadostipo ;
      private string lV53Estadosnotificacionwwds_6_tfestadosgenericosnombre ;
      private string A107EstadosTipo ;
      private string A109EstadosGenericosNombre ;
      private string A263EstadosNotificacionCliente ;
      private string A264EstadosNotificacionProfesional ;
      private string A265EstadosNotificacionOperador ;
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
      private string AV48Estadosnotificacionwwds_1_filterfulltext ;
      private string lV48Estadosnotificacionwwds_1_filterfulltext ;
      private IGxSession AV20Session ;
      private ExcelDocumentI AV11ExcelDocument ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector AV24ColumnsSelector ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column AV26ColumnsSelector_Column ;
      private IDataStoreProvider pr_default ;
      private string[] P00C82_A265EstadosNotificacionOperador ;
      private string[] P00C82_A264EstadosNotificacionProfesional ;
      private string[] P00C82_A263EstadosNotificacionCliente ;
      private string[] P00C82_A109EstadosGenericosNombre ;
      private int[] P00C82_A108EstadosGenericosId ;
      private string[] P00C82_A107EstadosTipo ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector AV25ColumnsSelectorAux ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV22GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV23GridStateFilterValue ;
      private string aP0_Filename ;
      private string aP1_ErrorMessage ;
   }

   public class estadosnotificacionwwexport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00C82( IGxContext context ,
                                             string AV48Estadosnotificacionwwds_1_filterfulltext ,
                                             string AV50Estadosnotificacionwwds_3_tfestadostipo_sel ,
                                             string AV49Estadosnotificacionwwds_2_tfestadostipo ,
                                             int AV51Estadosnotificacionwwds_4_tfestadosgenericosid ,
                                             int AV52Estadosnotificacionwwds_5_tfestadosgenericosid_to ,
                                             string AV54Estadosnotificacionwwds_7_tfestadosgenericosnombre_sel ,
                                             string AV53Estadosnotificacionwwds_6_tfestadosgenericosnombre ,
                                             string AV55Estadosnotificacionwwds_8_tfestadosnotificacioncliente_sel ,
                                             string AV56Estadosnotificacionwwds_9_tfestadosnotificacionprofesional_sel ,
                                             string AV57Estadosnotificacionwwds_10_tfestadosnotificacionoperador_sel ,
                                             string A107EstadosTipo ,
                                             int A108EstadosGenericosId ,
                                             string A109EstadosGenericosNombre ,
                                             string A263EstadosNotificacionCliente ,
                                             string A264EstadosNotificacionProfesional ,
                                             string A265EstadosNotificacionOperador ,
                                             short AV17OrderedBy ,
                                             bool AV18OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int4 = new short[12];
         Object[] GXv_Object5 = new Object[2];
         scmdbuf = "SELECT [EstadosNotificacionOperador], [EstadosNotificacionProfesional], [EstadosNotificacionCliente], [EstadosGenericosNombre], [EstadosGenericosId], [EstadosTipo] FROM [EstadosGenericos]";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV48Estadosnotificacionwwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( UPPER([EstadosTipo]) like '%' + UPPER(@lV48Estadosnotificacionwwds_1_filterfulltext)) or ( CONVERT( char(5), CAST([EstadosGenericosId] AS decimal(5,0))) like '%' + @lV48Estadosnotificacionwwds_1_filterfulltext) or ( UPPER([EstadosGenericosNombre]) like '%' + UPPER(@lV48Estadosnotificacionwwds_1_filterfulltext)))");
         }
         else
         {
            GXv_int4[0] = 1;
            GXv_int4[1] = 1;
            GXv_int4[2] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV50Estadosnotificacionwwds_3_tfestadostipo_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV49Estadosnotificacionwwds_2_tfestadostipo)) ) )
         {
            AddWhere(sWhereString, "(UPPER([EstadosTipo]) like UPPER(@lV49Estadosnotificacionwwds_2_tfestadostipo))");
         }
         else
         {
            GXv_int4[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV50Estadosnotificacionwwds_3_tfestadostipo_sel)) && ! ( StringUtil.StrCmp(AV50Estadosnotificacionwwds_3_tfestadostipo_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([EstadosTipo] = @AV50Estadosnotificacionwwds_3_tfestadostipo_sel)");
         }
         else
         {
            GXv_int4[4] = 1;
         }
         if ( StringUtil.StrCmp(AV50Estadosnotificacionwwds_3_tfestadostipo_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([EstadosTipo] = ''))");
         }
         if ( ! (0==AV51Estadosnotificacionwwds_4_tfestadosgenericosid) )
         {
            AddWhere(sWhereString, "([EstadosGenericosId] >= @AV51Estadosnotificacionwwds_4_tfestadosgenericosid)");
         }
         else
         {
            GXv_int4[5] = 1;
         }
         if ( ! (0==AV52Estadosnotificacionwwds_5_tfestadosgenericosid_to) )
         {
            AddWhere(sWhereString, "([EstadosGenericosId] <= @AV52Estadosnotificacionwwds_5_tfestadosgenericosid_to)");
         }
         else
         {
            GXv_int4[6] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV54Estadosnotificacionwwds_7_tfestadosgenericosnombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV53Estadosnotificacionwwds_6_tfestadosgenericosnombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER([EstadosGenericosNombre]) like UPPER(@lV53Estadosnotificacionwwds_6_tfestadosgenericosnombre))");
         }
         else
         {
            GXv_int4[7] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV54Estadosnotificacionwwds_7_tfestadosgenericosnombre_sel)) && ! ( StringUtil.StrCmp(AV54Estadosnotificacionwwds_7_tfestadosgenericosnombre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([EstadosGenericosNombre] = @AV54Estadosnotificacionwwds_7_tfestadosgenericosnombre_sel)");
         }
         else
         {
            GXv_int4[8] = 1;
         }
         if ( StringUtil.StrCmp(AV54Estadosnotificacionwwds_7_tfestadosgenericosnombre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([EstadosGenericosNombre] = ''))");
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV55Estadosnotificacionwwds_8_tfestadosnotificacioncliente_sel)) )
         {
            AddWhere(sWhereString, "([EstadosNotificacionCliente] = @AV55Estadosnotificacionwwds_8_tfestadosnotificacioncliente_sel)");
         }
         else
         {
            GXv_int4[9] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV56Estadosnotificacionwwds_9_tfestadosnotificacionprofesional_sel)) )
         {
            AddWhere(sWhereString, "([EstadosNotificacionProfesional] = @AV56Estadosnotificacionwwds_9_tfestadosnotificacionprofesional_sel)");
         }
         else
         {
            GXv_int4[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57Estadosnotificacionwwds_10_tfestadosnotificacionoperador_sel)) )
         {
            AddWhere(sWhereString, "([EstadosNotificacionOperador] = @AV57Estadosnotificacionwwds_10_tfestadosnotificacionoperador_sel)");
         }
         else
         {
            GXv_int4[11] = 1;
         }
         scmdbuf += sWhereString;
         if ( ( AV17OrderedBy == 1 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY [EstadosGenericosNombre]";
         }
         else if ( ( AV17OrderedBy == 1 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [EstadosGenericosNombre] DESC";
         }
         else if ( ( AV17OrderedBy == 2 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY [EstadosTipo]";
         }
         else if ( ( AV17OrderedBy == 2 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [EstadosTipo] DESC";
         }
         else if ( ( AV17OrderedBy == 3 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY [EstadosGenericosId]";
         }
         else if ( ( AV17OrderedBy == 3 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [EstadosGenericosId] DESC";
         }
         else if ( ( AV17OrderedBy == 4 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY [EstadosNotificacionCliente]";
         }
         else if ( ( AV17OrderedBy == 4 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [EstadosNotificacionCliente] DESC";
         }
         else if ( ( AV17OrderedBy == 5 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY [EstadosNotificacionProfesional]";
         }
         else if ( ( AV17OrderedBy == 5 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [EstadosNotificacionProfesional] DESC";
         }
         else if ( ( AV17OrderedBy == 6 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY [EstadosNotificacionOperador]";
         }
         else if ( ( AV17OrderedBy == 6 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [EstadosNotificacionOperador] DESC";
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
                     return conditional_P00C82(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (int)dynConstraints[3] , (int)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (int)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (short)dynConstraints[16] , (bool)dynConstraints[17] );
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
          Object[] prmP00C82;
          prmP00C82 = new Object[] {
          new ParDef("@lV48Estadosnotificacionwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV48Estadosnotificacionwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV48Estadosnotificacionwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV49Estadosnotificacionwwds_2_tfestadostipo",GXType.Char,3,0) ,
          new ParDef("@AV50Estadosnotificacionwwds_3_tfestadostipo_sel",GXType.NChar,3,0) ,
          new ParDef("@AV51Estadosnotificacionwwds_4_tfestadosgenericosid",GXType.Int32,5,0) ,
          new ParDef("@AV52Estadosnotificacionwwds_5_tfestadosgenericosid_to",GXType.Int32,5,0) ,
          new ParDef("@lV53Estadosnotificacionwwds_6_tfestadosgenericosnombre",GXType.Char,80,0) ,
          new ParDef("@AV54Estadosnotificacionwwds_7_tfestadosgenericosnombre_sel",GXType.NChar,80,0) ,
          new ParDef("@AV55Estadosnotificacionwwds_8_tfestadosnotificacioncliente_sel",GXType.NChar,1,0) ,
          new ParDef("@AV56Estadosnotificacionwwds_9_tfestadosnotificacionprofesional_sel",GXType.NChar,1,0) ,
          new ParDef("@AV57Estadosnotificacionwwds_10_tfestadosnotificacionoperador_sel",GXType.NChar,1,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00C82", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00C82,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[0])[0] = rslt.getString(1, 1);
                ((string[]) buf[1])[0] = rslt.getString(2, 1);
                ((string[]) buf[2])[0] = rslt.getString(3, 1);
                ((string[]) buf[3])[0] = rslt.getString(4, 80);
                ((int[]) buf[4])[0] = rslt.getInt(5);
                ((string[]) buf[5])[0] = rslt.getString(6, 3);
                return;
       }
    }

 }

}

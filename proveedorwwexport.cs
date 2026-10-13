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
   public class proveedorwwexport : GXProcedure
   {
      public proveedorwwexport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public proveedorwwexport( IGxContext context )
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
         new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWProveedor", out  GXt_boolean1) ;
         AV8IsAuthorized = GXt_boolean1;
         if ( ! AV8IsAuthorized )
         {
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "wwpbaseobjects.notauthorized.aspx"+GXUtil.UrlEncode(StringUtil.RTrim(AV71Pgmname));
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
         AV12Filename = GXt_char2 + "ProveedorWWExport-" + StringUtil.Trim( StringUtil.Str( (decimal)(AV16Random), 8, 0)) + ".xlsx";
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
         if ( ! ( (0==AV50TFProveedorID) && (0==AV51TFProveedorID_To) ) )
         {
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Comercio", "")) ;
            AV14CellRow = GXt_int3;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Number = AV50TFProveedorID;
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  false, ref  GXt_int3,  (short)(AV15FirstColumn+2),  context.GetMessage( "WWP_TSTo", "")) ;
            AV14CellRow = GXt_int3;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+3, 1, 1).Number = AV51TFProveedorID_To;
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV53TFProveedorNombre_Sel)) ) )
         {
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Nombre", "")) ;
            AV14CellRow = GXt_int3;
            GXt_char2 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV53TFProveedorNombre_Sel)) ? context.GetMessage( "WWP_TitleFilter_EmptyOption", "") : AV53TFProveedorNombre_Sel), out  GXt_char2) ;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV52TFProveedorNombre)) ) )
            {
               GXt_int3 = (short)(AV14CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Nombre", "")) ;
               AV14CellRow = GXt_int3;
               GXt_char2 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV52TFProveedorNombre, out  GXt_char2) ;
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV55TFProveedorDocIdentidad_Sel)) ) )
         {
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Doc. Identidad", "")) ;
            AV14CellRow = GXt_int3;
            GXt_char2 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV55TFProveedorDocIdentidad_Sel)) ? context.GetMessage( "WWP_TitleFilter_EmptyOption", "") : AV55TFProveedorDocIdentidad_Sel), out  GXt_char2) ;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV54TFProveedorDocIdentidad)) ) )
            {
               GXt_int3 = (short)(AV14CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Doc. Identidad", "")) ;
               AV14CellRow = GXt_int3;
               GXt_char2 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV54TFProveedorDocIdentidad, out  GXt_char2) ;
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV57TFProveedorTelefono_Sel)) ) )
         {
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Teléfono", "")) ;
            AV14CellRow = GXt_int3;
            GXt_char2 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV57TFProveedorTelefono_Sel)) ? context.GetMessage( "WWP_TitleFilter_EmptyOption", "") : AV57TFProveedorTelefono_Sel), out  GXt_char2) ;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV56TFProveedorTelefono)) ) )
            {
               GXt_int3 = (short)(AV14CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Teléfono", "")) ;
               AV14CellRow = GXt_int3;
               GXt_char2 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV56TFProveedorTelefono, out  GXt_char2) ;
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV59TFProveedorDireccion_Sel)) ) )
         {
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Dirección", "")) ;
            AV14CellRow = GXt_int3;
            GXt_char2 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV59TFProveedorDireccion_Sel)) ? context.GetMessage( "WWP_TitleFilter_EmptyOption", "") : AV59TFProveedorDireccion_Sel), out  GXt_char2) ;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV58TFProveedorDireccion)) ) )
            {
               GXt_int3 = (short)(AV14CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Dirección", "")) ;
               AV14CellRow = GXt_int3;
               GXt_char2 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV58TFProveedorDireccion, out  GXt_char2) ;
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV61TFProveedorEmail_Sel)) ) )
         {
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Email", "")) ;
            AV14CellRow = GXt_int3;
            GXt_char2 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV61TFProveedorEmail_Sel)) ? context.GetMessage( "WWP_TitleFilter_EmptyOption", "") : AV61TFProveedorEmail_Sel), out  GXt_char2) ;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV60TFProveedorEmail)) ) )
            {
               GXt_int3 = (short)(AV14CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Email", "")) ;
               AV14CellRow = GXt_int3;
               GXt_char2 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV60TFProveedorEmail, out  GXt_char2) ;
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
            }
         }
         if ( ! ( ( AV68TFProveedorPagoDefault_Sels.Count == 0 ) ) )
         {
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Pago", "")) ;
            AV14CellRow = GXt_int3;
            AV66i = 1;
            AV72GXV1 = 1;
            while ( AV72GXV1 <= AV68TFProveedorPagoDefault_Sels.Count )
            {
               AV69TFProveedorPagoDefault_Sel = AV68TFProveedorPagoDefault_Sels.GetString(AV72GXV1);
               if ( AV66i == 1 )
               {
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = "";
               }
               else
               {
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text+", ";
               }
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text+context.GetMessage( gxdomainorigenpago.getDescription(context,AV69TFProveedorPagoDefault_Sel), "");
               AV66i = (long)(AV66i+1);
               AV72GXV1 = (int)(AV72GXV1+1);
            }
         }
         if ( ! ( ( AV63TFProveedorEstado_Sels.Count == 0 ) ) )
         {
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Estado", "")) ;
            AV14CellRow = GXt_int3;
            AV66i = 1;
            AV73GXV2 = 1;
            while ( AV73GXV2 <= AV63TFProveedorEstado_Sels.Count )
            {
               AV64TFProveedorEstado_Sel = AV63TFProveedorEstado_Sels.GetString(AV73GXV2);
               if ( AV66i == 1 )
               {
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = "";
               }
               else
               {
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text+", ";
               }
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text+context.GetMessage( gxdomainestadoenum.getDescription(context,AV64TFProveedorEstado_Sel), "");
               AV66i = (long)(AV66i+1);
               AV73GXV2 = (int)(AV73GXV2+1);
            }
         }
         if ( ! (0==AV65GridConditionalFormattingFilter) )
         {
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "WWP_FullTextFilterDescription", "")) ;
            AV14CellRow = GXt_int3;
            if ( AV65GridConditionalFormattingFilter == 1 )
            {
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = context.GetMessage( "Permiso Concedido", "");
            }
         }
         AV14CellRow = (int)(AV14CellRow+2);
      }

      protected void S141( )
      {
         /* 'WRITECOLUMNTITLES' Routine */
         returnInSub = false;
         AV47VisibleColumnCount = 0;
         if ( StringUtil.StrCmp(AV35Session.Get("ProveedorWWColumnsSelector"), "") != 0 )
         {
            AV42ColumnsSelectorXML = AV35Session.Get("ProveedorWWColumnsSelector");
            AV39ColumnsSelector.FromXml(AV42ColumnsSelectorXML, null, "", "");
         }
         else
         {
            /* Execute user subroutine: 'INITIALIZECOLUMNSSELECTOR' */
            S151 ();
            if (returnInSub) return;
         }
         ((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV39ColumnsSelector.gxTpr_Columns.Item(10)).gxTpr_Isvisible = false;
         AV39ColumnsSelector.gxTpr_Columns.Sort("Order");
         AV74GXV3 = 1;
         while ( AV74GXV3 <= AV39ColumnsSelector.gxTpr_Columns.Count )
         {
            AV41ColumnsSelector_Column = ((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV39ColumnsSelector.gxTpr_Columns.Item(AV74GXV3));
            if ( AV41ColumnsSelector_Column.gxTpr_Isvisible )
            {
               AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV47VisibleColumnCount), 1, 1).Text = context.GetMessage( (String.IsNullOrEmpty(StringUtil.RTrim( AV41ColumnsSelector_Column.gxTpr_Displayname)) ? AV41ColumnsSelector_Column.gxTpr_Columnname : AV41ColumnsSelector_Column.gxTpr_Displayname), "");
               AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV47VisibleColumnCount), 1, 1).Bold = 1;
               AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV47VisibleColumnCount), 1, 1).Color = 11;
               AV47VisibleColumnCount = (long)(AV47VisibleColumnCount+1);
            }
            AV74GXV3 = (int)(AV74GXV3+1);
         }
      }

      protected void S161( )
      {
         /* 'WRITEDATA' Routine */
         returnInSub = false;
         AV76Proveedorwwds_1_gridconditionalformattingfilter = AV65GridConditionalFormattingFilter;
         AV77Proveedorwwds_2_filterfulltext = AV19FilterFullText;
         AV78Proveedorwwds_3_tfproveedorid = AV50TFProveedorID;
         AV79Proveedorwwds_4_tfproveedorid_to = AV51TFProveedorID_To;
         AV80Proveedorwwds_5_tfproveedornombre = AV52TFProveedorNombre;
         AV81Proveedorwwds_6_tfproveedornombre_sel = AV53TFProveedorNombre_Sel;
         AV82Proveedorwwds_7_tfproveedordocidentidad = AV54TFProveedorDocIdentidad;
         AV83Proveedorwwds_8_tfproveedordocidentidad_sel = AV55TFProveedorDocIdentidad_Sel;
         AV84Proveedorwwds_9_tfproveedortelefono = AV56TFProveedorTelefono;
         AV85Proveedorwwds_10_tfproveedortelefono_sel = AV57TFProveedorTelefono_Sel;
         AV86Proveedorwwds_11_tfproveedordireccion = AV58TFProveedorDireccion;
         AV87Proveedorwwds_12_tfproveedordireccion_sel = AV59TFProveedorDireccion_Sel;
         AV88Proveedorwwds_13_tfproveedoremail = AV60TFProveedorEmail;
         AV89Proveedorwwds_14_tfproveedoremail_sel = AV61TFProveedorEmail_Sel;
         AV90Proveedorwwds_15_tfproveedorpagodefault_sels = AV68TFProveedorPagoDefault_Sels;
         AV91Proveedorwwds_16_tfproveedorestado_sels = AV63TFProveedorEstado_Sels;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A440ProveedorPagoDefault ,
                                              AV90Proveedorwwds_15_tfproveedorpagodefault_sels ,
                                              A344ProveedorEstado ,
                                              AV91Proveedorwwds_16_tfproveedorestado_sels ,
                                              AV76Proveedorwwds_1_gridconditionalformattingfilter ,
                                              AV78Proveedorwwds_3_tfproveedorid ,
                                              AV79Proveedorwwds_4_tfproveedorid_to ,
                                              AV81Proveedorwwds_6_tfproveedornombre_sel ,
                                              AV80Proveedorwwds_5_tfproveedornombre ,
                                              AV83Proveedorwwds_8_tfproveedordocidentidad_sel ,
                                              AV82Proveedorwwds_7_tfproveedordocidentidad ,
                                              AV85Proveedorwwds_10_tfproveedortelefono_sel ,
                                              AV84Proveedorwwds_9_tfproveedortelefono ,
                                              AV87Proveedorwwds_12_tfproveedordireccion_sel ,
                                              AV86Proveedorwwds_11_tfproveedordireccion ,
                                              AV89Proveedorwwds_14_tfproveedoremail_sel ,
                                              AV88Proveedorwwds_13_tfproveedoremail ,
                                              AV90Proveedorwwds_15_tfproveedorpagodefault_sels.Count ,
                                              AV91Proveedorwwds_16_tfproveedorestado_sels.Count ,
                                              AV70VerTodProv ,
                                              AV92Hacerload ,
                                              A133ProveedorID ,
                                              A282ProveedorNombre ,
                                              A338ProveedorDocIdentidad ,
                                              A430ProveedorTelefono ,
                                              A431ProveedorDireccion ,
                                              A433ProveedorEmail ,
                                              AV17OrderedBy ,
                                              AV18OrderedDsc ,
                                              AV77Proveedorwwds_2_filterfulltext } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN,
                                              TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV80Proveedorwwds_5_tfproveedornombre = StringUtil.PadR( StringUtil.RTrim( AV80Proveedorwwds_5_tfproveedornombre), 80, "%");
         lV82Proveedorwwds_7_tfproveedordocidentidad = StringUtil.PadR( StringUtil.RTrim( AV82Proveedorwwds_7_tfproveedordocidentidad), 25, "%");
         lV84Proveedorwwds_9_tfproveedortelefono = StringUtil.PadR( StringUtil.RTrim( AV84Proveedorwwds_9_tfproveedortelefono), 20, "%");
         lV86Proveedorwwds_11_tfproveedordireccion = StringUtil.Concat( StringUtil.RTrim( AV86Proveedorwwds_11_tfproveedordireccion), "%", "");
         lV88Proveedorwwds_13_tfproveedoremail = StringUtil.Concat( StringUtil.RTrim( AV88Proveedorwwds_13_tfproveedoremail), "%", "");
         /* Using cursor P006W2 */
         pr_default.execute(0, new Object[] {AV92Hacerload, AV78Proveedorwwds_3_tfproveedorid, AV79Proveedorwwds_4_tfproveedorid_to, lV80Proveedorwwds_5_tfproveedornombre, AV81Proveedorwwds_6_tfproveedornombre_sel, lV82Proveedorwwds_7_tfproveedordocidentidad, AV83Proveedorwwds_8_tfproveedordocidentidad_sel, lV84Proveedorwwds_9_tfproveedortelefono, AV85Proveedorwwds_10_tfproveedortelefono_sel, lV86Proveedorwwds_11_tfproveedordireccion, AV87Proveedorwwds_12_tfproveedordireccion_sel, lV88Proveedorwwds_13_tfproveedoremail, AV89Proveedorwwds_14_tfproveedoremail_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A433ProveedorEmail = P006W2_A433ProveedorEmail[0];
            n433ProveedorEmail = P006W2_n433ProveedorEmail[0];
            A431ProveedorDireccion = P006W2_A431ProveedorDireccion[0];
            n431ProveedorDireccion = P006W2_n431ProveedorDireccion[0];
            A430ProveedorTelefono = P006W2_A430ProveedorTelefono[0];
            n430ProveedorTelefono = P006W2_n430ProveedorTelefono[0];
            A338ProveedorDocIdentidad = P006W2_A338ProveedorDocIdentidad[0];
            A282ProveedorNombre = P006W2_A282ProveedorNombre[0];
            A133ProveedorID = P006W2_A133ProveedorID[0];
            A344ProveedorEstado = P006W2_A344ProveedorEstado[0];
            A440ProveedorPagoDefault = P006W2_A440ProveedorPagoDefault[0];
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV77Proveedorwwds_2_filterfulltext)) || ( ( StringUtil.Like( StringUtil.Str( (decimal)(A133ProveedorID), 18, 0) , StringUtil.PadR( "%" + AV77Proveedorwwds_2_filterfulltext , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A282ProveedorNombre) , StringUtil.PadR( "%" + StringUtil.Upper( AV77Proveedorwwds_2_filterfulltext) , 255 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Upper( A338ProveedorDocIdentidad) , StringUtil.PadR( "%" + StringUtil.Upper( AV77Proveedorwwds_2_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A430ProveedorTelefono) , StringUtil.PadR( "%" + StringUtil.Upper( AV77Proveedorwwds_2_filterfulltext) , 255 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Upper( A431ProveedorDireccion) , StringUtil.PadR( "%" + StringUtil.Upper( AV77Proveedorwwds_2_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A433ProveedorEmail) , StringUtil.PadR( "%" + StringUtil.Upper( AV77Proveedorwwds_2_filterfulltext) , 255 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( context.GetMessage( "cobro directo", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV77Proveedorwwds_2_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A440ProveedorPagoDefault, "F") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "cobro prepago comercio", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV77Proveedorwwds_2_filterfulltext) , 255 , "%"),  ' ' ) &&
            ( StringUtil.StrCmp(A440ProveedorPagoDefault, "T") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "cobro prepago almango", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV77Proveedorwwds_2_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A440ProveedorPagoDefault, "O") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "habilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV77Proveedorwwds_2_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A344ProveedorEstado, "HAB") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "deshabilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV77Proveedorwwds_2_filterfulltext) , 255 , "%"),  ' ' ) &&
            ( StringUtil.StrCmp(A344ProveedorEstado, "DES") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "pendiente", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV77Proveedorwwds_2_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A344ProveedorEstado, "PEN") == 0 ) ) )
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
               AV47VisibleColumnCount = 0;
               AV93GXV4 = 1;
               while ( AV93GXV4 <= AV39ColumnsSelector.gxTpr_Columns.Count )
               {
                  AV41ColumnsSelector_Column = ((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV39ColumnsSelector.gxTpr_Columns.Item(AV93GXV4));
                  if ( AV41ColumnsSelector_Column.gxTpr_Isvisible )
                  {
                     if ( StringUtil.StrCmp(AV41ColumnsSelector_Column.gxTpr_Columnname, "ProveedorID") == 0 )
                     {
                        AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV47VisibleColumnCount), 1, 1).Number = A133ProveedorID;
                     }
                     else if ( StringUtil.StrCmp(AV41ColumnsSelector_Column.gxTpr_Columnname, "ProveedorNombre") == 0 )
                     {
                        GXt_char2 = "";
                        new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A282ProveedorNombre, out  GXt_char2) ;
                        AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV47VisibleColumnCount), 1, 1).Text = GXt_char2;
                     }
                     else if ( StringUtil.StrCmp(AV41ColumnsSelector_Column.gxTpr_Columnname, "ProveedorImagen") == 0 )
                     {
                        AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV47VisibleColumnCount), 1, 1).Text = "";
                     }
                     else if ( StringUtil.StrCmp(AV41ColumnsSelector_Column.gxTpr_Columnname, "ProveedorDocIdentidad") == 0 )
                     {
                        GXt_char2 = "";
                        new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A338ProveedorDocIdentidad, out  GXt_char2) ;
                        AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV47VisibleColumnCount), 1, 1).Text = GXt_char2;
                     }
                     else if ( StringUtil.StrCmp(AV41ColumnsSelector_Column.gxTpr_Columnname, "ProveedorTelefono") == 0 )
                     {
                        GXt_char2 = "";
                        new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A430ProveedorTelefono, out  GXt_char2) ;
                        AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV47VisibleColumnCount), 1, 1).Text = GXt_char2;
                     }
                     else if ( StringUtil.StrCmp(AV41ColumnsSelector_Column.gxTpr_Columnname, "ProveedorDireccion") == 0 )
                     {
                        GXt_char2 = "";
                        new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A431ProveedorDireccion, out  GXt_char2) ;
                        AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV47VisibleColumnCount), 1, 1).Text = GXt_char2;
                     }
                     else if ( StringUtil.StrCmp(AV41ColumnsSelector_Column.gxTpr_Columnname, "ProveedorEmail") == 0 )
                     {
                        GXt_char2 = "";
                        new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A433ProveedorEmail, out  GXt_char2) ;
                        AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV47VisibleColumnCount), 1, 1).Text = GXt_char2;
                     }
                     else if ( StringUtil.StrCmp(AV41ColumnsSelector_Column.gxTpr_Columnname, "ProveedorPagoDefault") == 0 )
                     {
                        AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV47VisibleColumnCount), 1, 1).Text = context.GetMessage( gxdomainorigenpago.getDescription(context,A440ProveedorPagoDefault), "");
                     }
                     else if ( StringUtil.StrCmp(AV41ColumnsSelector_Column.gxTpr_Columnname, "ProveedorEstado") == 0 )
                     {
                        AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV47VisibleColumnCount), 1, 1).Text = context.GetMessage( gxdomainestadoenum.getDescription(context,A344ProveedorEstado), "");
                        if ( StringUtil.StrCmp(A344ProveedorEstado, "DES") == 0 )
                        {
                           AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV47VisibleColumnCount), 1, 1).Color = GXUtil.RGB( 221, 75, 57);
                        }
                        else if ( StringUtil.StrCmp(A344ProveedorEstado, "PEN") == 0 )
                        {
                           AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV47VisibleColumnCount), 1, 1).Color = GXUtil.RGB( 251, 110, 82);
                        }
                     }
                     AV47VisibleColumnCount = (long)(AV47VisibleColumnCount+1);
                  }
                  AV93GXV4 = (int)(AV93GXV4+1);
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
         AV35Session.Set("WWPExportFilePath", AV12Filename);
         AV35Session.Set("WWPExportFileName", "ProveedorWWExport.xlsx");
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
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV39ColumnsSelector,  "ProveedorID",  "",  "Comercio",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV39ColumnsSelector,  "ProveedorNombre",  "",  "Nombre",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV39ColumnsSelector,  "ProveedorImagen",  "",  "Imagen",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV39ColumnsSelector,  "ProveedorDocIdentidad",  "",  "Doc. Identidad",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV39ColumnsSelector,  "ProveedorTelefono",  "",  "Teléfono",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV39ColumnsSelector,  "ProveedorDireccion",  "",  "Dirección",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV39ColumnsSelector,  "ProveedorEmail",  "",  "Email",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV39ColumnsSelector,  "ProveedorPagoDefault",  "",  "Pago",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV39ColumnsSelector,  "ProveedorEstado",  "",  "Estado",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV39ColumnsSelector,  "&HacerLoad",  "",  "",  false,  "") ;
         GXt_char2 = AV43UserCustomValue;
         new GeneXus.Programs.wwpbaseobjects.loadcolumnsselectorstate(context ).execute(  "ProveedorWWColumnsSelector", out  GXt_char2) ;
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
         if ( StringUtil.StrCmp(AV35Session.Get("ProveedorWWGridState"), "") == 0 )
         {
            AV37GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "ProveedorWWGridState"), null, "", "");
         }
         else
         {
            AV37GridState.FromXml(AV35Session.Get("ProveedorWWGridState"), null, "", "");
         }
         AV17OrderedBy = AV37GridState.gxTpr_Orderedby;
         AV18OrderedDsc = AV37GridState.gxTpr_Ordereddsc;
         AV94GXV5 = 1;
         while ( AV94GXV5 <= AV37GridState.gxTpr_Filtervalues.Count )
         {
            AV38GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV37GridState.gxTpr_Filtervalues.Item(AV94GXV5));
            if ( StringUtil.StrCmp(AV38GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV19FilterFullText = AV38GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV38GridStateFilterValue.gxTpr_Name, "TFPROVEEDORID") == 0 )
            {
               AV50TFProveedorID = (long)(Math.Round(NumberUtil.Val( AV38GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV51TFProveedorID_To = (long)(Math.Round(NumberUtil.Val( AV38GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV38GridStateFilterValue.gxTpr_Name, "TFPROVEEDORNOMBRE") == 0 )
            {
               AV52TFProveedorNombre = AV38GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV38GridStateFilterValue.gxTpr_Name, "TFPROVEEDORNOMBRE_SEL") == 0 )
            {
               AV53TFProveedorNombre_Sel = AV38GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV38GridStateFilterValue.gxTpr_Name, "TFPROVEEDORDOCIDENTIDAD") == 0 )
            {
               AV54TFProveedorDocIdentidad = AV38GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV38GridStateFilterValue.gxTpr_Name, "TFPROVEEDORDOCIDENTIDAD_SEL") == 0 )
            {
               AV55TFProveedorDocIdentidad_Sel = AV38GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV38GridStateFilterValue.gxTpr_Name, "TFPROVEEDORTELEFONO") == 0 )
            {
               AV56TFProveedorTelefono = AV38GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV38GridStateFilterValue.gxTpr_Name, "TFPROVEEDORTELEFONO_SEL") == 0 )
            {
               AV57TFProveedorTelefono_Sel = AV38GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV38GridStateFilterValue.gxTpr_Name, "TFPROVEEDORDIRECCION") == 0 )
            {
               AV58TFProveedorDireccion = AV38GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV38GridStateFilterValue.gxTpr_Name, "TFPROVEEDORDIRECCION_SEL") == 0 )
            {
               AV59TFProveedorDireccion_Sel = AV38GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV38GridStateFilterValue.gxTpr_Name, "TFPROVEEDOREMAIL") == 0 )
            {
               AV60TFProveedorEmail = AV38GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV38GridStateFilterValue.gxTpr_Name, "TFPROVEEDOREMAIL_SEL") == 0 )
            {
               AV61TFProveedorEmail_Sel = AV38GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV38GridStateFilterValue.gxTpr_Name, "TFPROVEEDORPAGODEFAULT_SEL") == 0 )
            {
               AV67TFProveedorPagoDefault_SelsJson = AV38GridStateFilterValue.gxTpr_Value;
               AV68TFProveedorPagoDefault_Sels.FromJSonString(AV67TFProveedorPagoDefault_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV38GridStateFilterValue.gxTpr_Name, "TFPROVEEDORESTADO_SEL") == 0 )
            {
               AV62TFProveedorEstado_SelsJson = AV38GridStateFilterValue.gxTpr_Value;
               AV63TFProveedorEstado_Sels.FromJSonString(AV62TFProveedorEstado_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV38GridStateFilterValue.gxTpr_Name, "GRIDCFFILTER") == 0 )
            {
               AV65GridConditionalFormattingFilter = (short)(Math.Round(NumberUtil.Val( AV38GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
            }
            AV94GXV5 = (int)(AV94GXV5+1);
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
         AV71Pgmname = "";
         GXKey = "";
         GXEncryptionTmp = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV11ExcelDocument = new ExcelDocumentI();
         AV19FilterFullText = "";
         AV53TFProveedorNombre_Sel = "";
         AV52TFProveedorNombre = "";
         AV55TFProveedorDocIdentidad_Sel = "";
         AV54TFProveedorDocIdentidad = "";
         AV57TFProveedorTelefono_Sel = "";
         AV56TFProveedorTelefono = "";
         AV59TFProveedorDireccion_Sel = "";
         AV58TFProveedorDireccion = "";
         AV61TFProveedorEmail_Sel = "";
         AV60TFProveedorEmail = "";
         AV68TFProveedorPagoDefault_Sels = new GxSimpleCollection<string>();
         AV69TFProveedorPagoDefault_Sel = "";
         AV63TFProveedorEstado_Sels = new GxSimpleCollection<string>();
         AV64TFProveedorEstado_Sel = "";
         AV35Session = context.GetSession();
         AV42ColumnsSelectorXML = "";
         AV39ColumnsSelector = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector(context);
         AV41ColumnsSelector_Column = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column(context);
         AV77Proveedorwwds_2_filterfulltext = "";
         AV80Proveedorwwds_5_tfproveedornombre = "";
         AV81Proveedorwwds_6_tfproveedornombre_sel = "";
         AV82Proveedorwwds_7_tfproveedordocidentidad = "";
         AV83Proveedorwwds_8_tfproveedordocidentidad_sel = "";
         AV84Proveedorwwds_9_tfproveedortelefono = "";
         AV85Proveedorwwds_10_tfproveedortelefono_sel = "";
         AV86Proveedorwwds_11_tfproveedordireccion = "";
         AV87Proveedorwwds_12_tfproveedordireccion_sel = "";
         AV88Proveedorwwds_13_tfproveedoremail = "";
         AV89Proveedorwwds_14_tfproveedoremail_sel = "";
         AV90Proveedorwwds_15_tfproveedorpagodefault_sels = new GxSimpleCollection<string>();
         AV91Proveedorwwds_16_tfproveedorestado_sels = new GxSimpleCollection<string>();
         lV80Proveedorwwds_5_tfproveedornombre = "";
         lV82Proveedorwwds_7_tfproveedordocidentidad = "";
         lV84Proveedorwwds_9_tfproveedortelefono = "";
         lV86Proveedorwwds_11_tfproveedordireccion = "";
         lV88Proveedorwwds_13_tfproveedoremail = "";
         A440ProveedorPagoDefault = "";
         A344ProveedorEstado = "";
         A282ProveedorNombre = "";
         A338ProveedorDocIdentidad = "";
         A430ProveedorTelefono = "";
         A431ProveedorDireccion = "";
         A433ProveedorEmail = "";
         P006W2_A433ProveedorEmail = new string[] {""} ;
         P006W2_n433ProveedorEmail = new bool[] {false} ;
         P006W2_A431ProveedorDireccion = new string[] {""} ;
         P006W2_n431ProveedorDireccion = new bool[] {false} ;
         P006W2_A430ProveedorTelefono = new string[] {""} ;
         P006W2_n430ProveedorTelefono = new bool[] {false} ;
         P006W2_A338ProveedorDocIdentidad = new string[] {""} ;
         P006W2_A282ProveedorNombre = new string[] {""} ;
         P006W2_A133ProveedorID = new long[1] ;
         P006W2_A344ProveedorEstado = new string[] {""} ;
         P006W2_A440ProveedorPagoDefault = new string[] {""} ;
         AV43UserCustomValue = "";
         GXt_char2 = "";
         AV40ColumnsSelectorAux = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector(context);
         AV37GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV38GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV67TFProveedorPagoDefault_SelsJson = "";
         AV62TFProveedorEstado_SelsJson = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.proveedorwwexport__default(),
            new Object[][] {
                new Object[] {
               P006W2_A433ProveedorEmail, P006W2_n433ProveedorEmail, P006W2_A431ProveedorDireccion, P006W2_n431ProveedorDireccion, P006W2_A430ProveedorTelefono, P006W2_n430ProveedorTelefono, P006W2_A338ProveedorDocIdentidad, P006W2_A282ProveedorNombre, P006W2_A133ProveedorID, P006W2_A344ProveedorEstado,
               P006W2_A440ProveedorPagoDefault
               }
            }
         );
         AV71Pgmname = "ProveedorWWExport";
         /* GeneXus formulas. */
         AV71Pgmname = "ProveedorWWExport";
      }

      private short AV65GridConditionalFormattingFilter ;
      private short GXt_int3 ;
      private short AV76Proveedorwwds_1_gridconditionalformattingfilter ;
      private short AV17OrderedBy ;
      private int AV14CellRow ;
      private int AV15FirstColumn ;
      private int AV16Random ;
      private int AV72GXV1 ;
      private int AV73GXV2 ;
      private int AV74GXV3 ;
      private int AV90Proveedorwwds_15_tfproveedorpagodefault_sels_Count ;
      private int AV91Proveedorwwds_16_tfproveedorestado_sels_Count ;
      private int AV93GXV4 ;
      private int AV94GXV5 ;
      private long AV50TFProveedorID ;
      private long AV51TFProveedorID_To ;
      private long AV66i ;
      private long AV47VisibleColumnCount ;
      private long AV78Proveedorwwds_3_tfproveedorid ;
      private long AV79Proveedorwwds_4_tfproveedorid_to ;
      private long A133ProveedorID ;
      private decimal AV92Hacerload ;
      private string AV71Pgmname ;
      private string GXKey ;
      private string GXEncryptionTmp ;
      private string AV53TFProveedorNombre_Sel ;
      private string AV52TFProveedorNombre ;
      private string AV55TFProveedorDocIdentidad_Sel ;
      private string AV54TFProveedorDocIdentidad ;
      private string AV57TFProveedorTelefono_Sel ;
      private string AV56TFProveedorTelefono ;
      private string AV69TFProveedorPagoDefault_Sel ;
      private string AV64TFProveedorEstado_Sel ;
      private string AV80Proveedorwwds_5_tfproveedornombre ;
      private string AV81Proveedorwwds_6_tfproveedornombre_sel ;
      private string AV82Proveedorwwds_7_tfproveedordocidentidad ;
      private string AV83Proveedorwwds_8_tfproveedordocidentidad_sel ;
      private string AV84Proveedorwwds_9_tfproveedortelefono ;
      private string AV85Proveedorwwds_10_tfproveedortelefono_sel ;
      private string lV80Proveedorwwds_5_tfproveedornombre ;
      private string lV82Proveedorwwds_7_tfproveedordocidentidad ;
      private string lV84Proveedorwwds_9_tfproveedortelefono ;
      private string A440ProveedorPagoDefault ;
      private string A344ProveedorEstado ;
      private string A282ProveedorNombre ;
      private string A338ProveedorDocIdentidad ;
      private string A430ProveedorTelefono ;
      private string GXt_char2 ;
      private bool AV8IsAuthorized ;
      private bool GXt_boolean1 ;
      private bool returnInSub ;
      private bool AV70VerTodProv ;
      private bool AV18OrderedDsc ;
      private bool n433ProveedorEmail ;
      private bool n431ProveedorDireccion ;
      private bool n430ProveedorTelefono ;
      private string AV42ColumnsSelectorXML ;
      private string AV43UserCustomValue ;
      private string AV67TFProveedorPagoDefault_SelsJson ;
      private string AV62TFProveedorEstado_SelsJson ;
      private string AV12Filename ;
      private string AV13ErrorMessage ;
      private string AV19FilterFullText ;
      private string AV59TFProveedorDireccion_Sel ;
      private string AV58TFProveedorDireccion ;
      private string AV61TFProveedorEmail_Sel ;
      private string AV60TFProveedorEmail ;
      private string AV77Proveedorwwds_2_filterfulltext ;
      private string AV86Proveedorwwds_11_tfproveedordireccion ;
      private string AV87Proveedorwwds_12_tfproveedordireccion_sel ;
      private string AV88Proveedorwwds_13_tfproveedoremail ;
      private string AV89Proveedorwwds_14_tfproveedoremail_sel ;
      private string lV86Proveedorwwds_11_tfproveedordireccion ;
      private string lV88Proveedorwwds_13_tfproveedoremail ;
      private string A431ProveedorDireccion ;
      private string A433ProveedorEmail ;
      private IGxSession AV35Session ;
      private ExcelDocumentI AV11ExcelDocument ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GxSimpleCollection<string> AV68TFProveedorPagoDefault_Sels ;
      private GxSimpleCollection<string> AV63TFProveedorEstado_Sels ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector AV39ColumnsSelector ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column AV41ColumnsSelector_Column ;
      private GxSimpleCollection<string> AV90Proveedorwwds_15_tfproveedorpagodefault_sels ;
      private GxSimpleCollection<string> AV91Proveedorwwds_16_tfproveedorestado_sels ;
      private IDataStoreProvider pr_default ;
      private string[] P006W2_A433ProveedorEmail ;
      private bool[] P006W2_n433ProveedorEmail ;
      private string[] P006W2_A431ProveedorDireccion ;
      private bool[] P006W2_n431ProveedorDireccion ;
      private string[] P006W2_A430ProveedorTelefono ;
      private bool[] P006W2_n430ProveedorTelefono ;
      private string[] P006W2_A338ProveedorDocIdentidad ;
      private string[] P006W2_A282ProveedorNombre ;
      private long[] P006W2_A133ProveedorID ;
      private string[] P006W2_A344ProveedorEstado ;
      private string[] P006W2_A440ProveedorPagoDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector AV40ColumnsSelectorAux ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV37GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV38GridStateFilterValue ;
      private string aP0_Filename ;
      private string aP1_ErrorMessage ;
   }

   public class proveedorwwexport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P006W2( IGxContext context ,
                                             string A440ProveedorPagoDefault ,
                                             GxSimpleCollection<string> AV90Proveedorwwds_15_tfproveedorpagodefault_sels ,
                                             string A344ProveedorEstado ,
                                             GxSimpleCollection<string> AV91Proveedorwwds_16_tfproveedorestado_sels ,
                                             short AV76Proveedorwwds_1_gridconditionalformattingfilter ,
                                             long AV78Proveedorwwds_3_tfproveedorid ,
                                             long AV79Proveedorwwds_4_tfproveedorid_to ,
                                             string AV81Proveedorwwds_6_tfproveedornombre_sel ,
                                             string AV80Proveedorwwds_5_tfproveedornombre ,
                                             string AV83Proveedorwwds_8_tfproveedordocidentidad_sel ,
                                             string AV82Proveedorwwds_7_tfproveedordocidentidad ,
                                             string AV85Proveedorwwds_10_tfproveedortelefono_sel ,
                                             string AV84Proveedorwwds_9_tfproveedortelefono ,
                                             string AV87Proveedorwwds_12_tfproveedordireccion_sel ,
                                             string AV86Proveedorwwds_11_tfproveedordireccion ,
                                             string AV89Proveedorwwds_14_tfproveedoremail_sel ,
                                             string AV88Proveedorwwds_13_tfproveedoremail ,
                                             int AV90Proveedorwwds_15_tfproveedorpagodefault_sels_Count ,
                                             int AV91Proveedorwwds_16_tfproveedorestado_sels_Count ,
                                             bool AV70VerTodProv ,
                                             decimal AV92Hacerload ,
                                             long A133ProveedorID ,
                                             string A282ProveedorNombre ,
                                             string A338ProveedorDocIdentidad ,
                                             string A430ProveedorTelefono ,
                                             string A431ProveedorDireccion ,
                                             string A433ProveedorEmail ,
                                             short AV17OrderedBy ,
                                             bool AV18OrderedDsc ,
                                             string AV77Proveedorwwds_2_filterfulltext )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int4 = new short[13];
         Object[] GXv_Object5 = new Object[2];
         scmdbuf = "SELECT [ProveedorEmail], [ProveedorDireccion], [ProveedorTelefono], [ProveedorDocIdentidad], [ProveedorNombre], [ProveedorID], [ProveedorEstado], [ProveedorPagoDefault] FROM [Proveedor]";
         if ( AV76Proveedorwwds_1_gridconditionalformattingfilter == 1 )
         {
            AddWhere(sWhereString, "(@AV92Hacerload = 1)");
         }
         else
         {
            GXv_int4[0] = 1;
         }
         if ( ! (0==AV78Proveedorwwds_3_tfproveedorid) )
         {
            AddWhere(sWhereString, "([ProveedorID] >= @AV78Proveedorwwds_3_tfproveedorid)");
         }
         else
         {
            GXv_int4[1] = 1;
         }
         if ( ! (0==AV79Proveedorwwds_4_tfproveedorid_to) )
         {
            AddWhere(sWhereString, "([ProveedorID] <= @AV79Proveedorwwds_4_tfproveedorid_to)");
         }
         else
         {
            GXv_int4[2] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV81Proveedorwwds_6_tfproveedornombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV80Proveedorwwds_5_tfproveedornombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ProveedorNombre]) like UPPER(@lV80Proveedorwwds_5_tfproveedornombre))");
         }
         else
         {
            GXv_int4[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV81Proveedorwwds_6_tfproveedornombre_sel)) && ! ( StringUtil.StrCmp(AV81Proveedorwwds_6_tfproveedornombre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([ProveedorNombre] = @AV81Proveedorwwds_6_tfproveedornombre_sel)");
         }
         else
         {
            GXv_int4[4] = 1;
         }
         if ( StringUtil.StrCmp(AV81Proveedorwwds_6_tfproveedornombre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([ProveedorNombre] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV83Proveedorwwds_8_tfproveedordocidentidad_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV82Proveedorwwds_7_tfproveedordocidentidad)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ProveedorDocIdentidad]) like UPPER(@lV82Proveedorwwds_7_tfproveedordocidentidad))");
         }
         else
         {
            GXv_int4[5] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV83Proveedorwwds_8_tfproveedordocidentidad_sel)) && ! ( StringUtil.StrCmp(AV83Proveedorwwds_8_tfproveedordocidentidad_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([ProveedorDocIdentidad] = @AV83Proveedorwwds_8_tfproveedordocidentidad_sel)");
         }
         else
         {
            GXv_int4[6] = 1;
         }
         if ( StringUtil.StrCmp(AV83Proveedorwwds_8_tfproveedordocidentidad_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([ProveedorDocIdentidad] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV85Proveedorwwds_10_tfproveedortelefono_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV84Proveedorwwds_9_tfproveedortelefono)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ProveedorTelefono]) like UPPER(@lV84Proveedorwwds_9_tfproveedortelefono))");
         }
         else
         {
            GXv_int4[7] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV85Proveedorwwds_10_tfproveedortelefono_sel)) && ! ( StringUtil.StrCmp(AV85Proveedorwwds_10_tfproveedortelefono_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([ProveedorTelefono] = @AV85Proveedorwwds_10_tfproveedortelefono_sel)");
         }
         else
         {
            GXv_int4[8] = 1;
         }
         if ( StringUtil.StrCmp(AV85Proveedorwwds_10_tfproveedortelefono_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "([ProveedorTelefono] IS NULL or ([ProveedorTelefono] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV87Proveedorwwds_12_tfproveedordireccion_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV86Proveedorwwds_11_tfproveedordireccion)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ProveedorDireccion]) like UPPER(@lV86Proveedorwwds_11_tfproveedordireccion))");
         }
         else
         {
            GXv_int4[9] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV87Proveedorwwds_12_tfproveedordireccion_sel)) && ! ( StringUtil.StrCmp(AV87Proveedorwwds_12_tfproveedordireccion_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([ProveedorDireccion] = @AV87Proveedorwwds_12_tfproveedordireccion_sel)");
         }
         else
         {
            GXv_int4[10] = 1;
         }
         if ( StringUtil.StrCmp(AV87Proveedorwwds_12_tfproveedordireccion_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "([ProveedorDireccion] IS NULL or ([ProveedorDireccion] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV89Proveedorwwds_14_tfproveedoremail_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV88Proveedorwwds_13_tfproveedoremail)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ProveedorEmail]) like UPPER(@lV88Proveedorwwds_13_tfproveedoremail))");
         }
         else
         {
            GXv_int4[11] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV89Proveedorwwds_14_tfproveedoremail_sel)) && ! ( StringUtil.StrCmp(AV89Proveedorwwds_14_tfproveedoremail_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([ProveedorEmail] = @AV89Proveedorwwds_14_tfproveedoremail_sel)");
         }
         else
         {
            GXv_int4[12] = 1;
         }
         if ( StringUtil.StrCmp(AV89Proveedorwwds_14_tfproveedoremail_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "([ProveedorEmail] IS NULL or ([ProveedorEmail] = ''))");
         }
         if ( AV90Proveedorwwds_15_tfproveedorpagodefault_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV90Proveedorwwds_15_tfproveedorpagodefault_sels, "[ProveedorPagoDefault] IN (", ")")+")");
         }
         if ( AV91Proveedorwwds_16_tfproveedorestado_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV91Proveedorwwds_16_tfproveedorestado_sels, "[ProveedorEstado] IN (", ")")+")");
         }
         if ( ! AV70VerTodProv )
         {
            AddWhere(sWhereString, "([ProveedorEstado] = 'HAB')");
         }
         scmdbuf += sWhereString;
         if ( ( AV17OrderedBy == 1 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY [ProveedorNombre]";
         }
         else if ( ( AV17OrderedBy == 1 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [ProveedorNombre] DESC";
         }
         else if ( ( AV17OrderedBy == 2 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY [ProveedorID]";
         }
         else if ( ( AV17OrderedBy == 2 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [ProveedorID] DESC";
         }
         else if ( ( AV17OrderedBy == 3 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY [ProveedorDocIdentidad]";
         }
         else if ( ( AV17OrderedBy == 3 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [ProveedorDocIdentidad] DESC";
         }
         else if ( ( AV17OrderedBy == 4 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY [ProveedorTelefono]";
         }
         else if ( ( AV17OrderedBy == 4 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [ProveedorTelefono] DESC";
         }
         else if ( ( AV17OrderedBy == 5 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY [ProveedorDireccion]";
         }
         else if ( ( AV17OrderedBy == 5 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [ProveedorDireccion] DESC";
         }
         else if ( ( AV17OrderedBy == 6 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY [ProveedorEmail]";
         }
         else if ( ( AV17OrderedBy == 6 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [ProveedorEmail] DESC";
         }
         else if ( ( AV17OrderedBy == 7 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY [ProveedorPagoDefault]";
         }
         else if ( ( AV17OrderedBy == 7 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [ProveedorPagoDefault] DESC";
         }
         else if ( ( AV17OrderedBy == 8 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY [ProveedorEstado]";
         }
         else if ( ( AV17OrderedBy == 8 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [ProveedorEstado] DESC";
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
                     return conditional_P006W2(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (GxSimpleCollection<string>)dynConstraints[3] , (short)dynConstraints[4] , (long)dynConstraints[5] , (long)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (int)dynConstraints[17] , (int)dynConstraints[18] , (bool)dynConstraints[19] , (decimal)dynConstraints[20] , (long)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (string)dynConstraints[25] , (string)dynConstraints[26] , (short)dynConstraints[27] , (bool)dynConstraints[28] , (string)dynConstraints[29] );
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
          Object[] prmP006W2;
          prmP006W2 = new Object[] {
          new ParDef("@AV92Hacerload",GXType.Decimal,10,2) ,
          new ParDef("@AV78Proveedorwwds_3_tfproveedorid",GXType.Decimal,18,0) ,
          new ParDef("@AV79Proveedorwwds_4_tfproveedorid_to",GXType.Decimal,18,0) ,
          new ParDef("@lV80Proveedorwwds_5_tfproveedornombre",GXType.Char,80,0) ,
          new ParDef("@AV81Proveedorwwds_6_tfproveedornombre_sel",GXType.NChar,80,0) ,
          new ParDef("@lV82Proveedorwwds_7_tfproveedordocidentidad",GXType.Char,25,0) ,
          new ParDef("@AV83Proveedorwwds_8_tfproveedordocidentidad_sel",GXType.NChar,25,0) ,
          new ParDef("@lV84Proveedorwwds_9_tfproveedortelefono",GXType.Char,20,0) ,
          new ParDef("@AV85Proveedorwwds_10_tfproveedortelefono_sel",GXType.NChar,20,0) ,
          new ParDef("@lV86Proveedorwwds_11_tfproveedordireccion",GXType.VarChar,1024,0) ,
          new ParDef("@AV87Proveedorwwds_12_tfproveedordireccion_sel",GXType.NVarChar,1024,0) ,
          new ParDef("@lV88Proveedorwwds_13_tfproveedoremail",GXType.VarChar,100,0) ,
          new ParDef("@AV89Proveedorwwds_14_tfproveedoremail_sel",GXType.NVarChar,100,0)
          };
          def= new CursorDef[] {
              new CursorDef("P006W2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP006W2,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[4])[0] = rslt.getString(3, 20);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((string[]) buf[6])[0] = rslt.getString(4, 25);
                ((string[]) buf[7])[0] = rslt.getString(5, 80);
                ((long[]) buf[8])[0] = rslt.getLong(6);
                ((string[]) buf[9])[0] = rslt.getString(7, 3);
                ((string[]) buf[10])[0] = rslt.getString(8, 1);
                return;
       }
    }

 }

}

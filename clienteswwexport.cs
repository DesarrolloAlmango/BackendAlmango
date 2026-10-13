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
   public class clienteswwexport : GXProcedure
   {
      public clienteswwexport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public clienteswwexport( IGxContext context )
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
         new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWClientes", out  GXt_boolean1) ;
         AV8IsAuthorized = GXt_boolean1;
         if ( ! AV8IsAuthorized )
         {
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "wwpbaseobjects.notauthorized.aspx"+GXUtil.UrlEncode(StringUtil.RTrim(AV59Pgmname));
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
         AV12Filename = GXt_char2 + "ClientesWWExport-" + StringUtil.Trim( StringUtil.Str( (decimal)(AV16Random), 8, 0)) + ".xlsx";
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
            if ( StringUtil.StrCmp(AV20DynamicFiltersSelector1, "CLIENTESNOMBRE") == 0 )
            {
               AV21DynamicFiltersOperator1 = AV31GridStateDynamicFilter.gxTpr_Operator;
               AV22ClientesNombre1 = AV31GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV22ClientesNombre1)) )
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
                  new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV22ClientesNombre1, out  GXt_char2) ;
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
               }
            }
            if ( AV34GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV23DynamicFiltersEnabled2 = true;
               AV31GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV34GridState.gxTpr_Dynamicfilters.Item(2));
               AV24DynamicFiltersSelector2 = AV31GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV24DynamicFiltersSelector2, "CLIENTESNOMBRE") == 0 )
               {
                  AV25DynamicFiltersOperator2 = AV31GridStateDynamicFilter.gxTpr_Operator;
                  AV26ClientesNombre2 = AV31GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV26ClientesNombre2)) )
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
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV26ClientesNombre2, out  GXt_char2) ;
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
                  }
               }
               if ( AV34GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV27DynamicFiltersEnabled3 = true;
                  AV31GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV34GridState.gxTpr_Dynamicfilters.Item(3));
                  AV28DynamicFiltersSelector3 = AV31GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV28DynamicFiltersSelector3, "CLIENTESNOMBRE") == 0 )
                  {
                     AV29DynamicFiltersOperator3 = AV31GridStateDynamicFilter.gxTpr_Operator;
                     AV30ClientesNombre3 = AV31GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV30ClientesNombre3)) )
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
                        new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV30ClientesNombre3, out  GXt_char2) ;
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
                     }
                  }
               }
            }
         }
         if ( ! ( (0==AV47TFClientesId) && (0==AV48TFClientesId_To) ) )
         {
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Identificador", "")) ;
            AV14CellRow = GXt_int3;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Number = AV47TFClientesId;
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  false, ref  GXt_int3,  (short)(AV15FirstColumn+2),  context.GetMessage( "WWP_TSTo", "")) ;
            AV14CellRow = GXt_int3;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+3, 1, 1).Number = AV48TFClientesId_To;
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV50TFClientesNombre_Sel)) ) )
         {
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Nombre", "")) ;
            AV14CellRow = GXt_int3;
            GXt_char2 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV50TFClientesNombre_Sel)) ? context.GetMessage( "WWP_TitleFilter_EmptyOption", "") : AV50TFClientesNombre_Sel), out  GXt_char2) ;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV49TFClientesNombre)) ) )
            {
               GXt_int3 = (short)(AV14CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Nombre", "")) ;
               AV14CellRow = GXt_int3;
               GXt_char2 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV49TFClientesNombre, out  GXt_char2) ;
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV52TFClientesTelefono_Sel)) ) )
         {
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Telefóno", "")) ;
            AV14CellRow = GXt_int3;
            GXt_char2 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV52TFClientesTelefono_Sel)) ? context.GetMessage( "WWP_TitleFilter_EmptyOption", "") : AV52TFClientesTelefono_Sel), out  GXt_char2) ;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV51TFClientesTelefono)) ) )
            {
               GXt_int3 = (short)(AV14CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Telefóno", "")) ;
               AV14CellRow = GXt_int3;
               GXt_char2 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV51TFClientesTelefono, out  GXt_char2) ;
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV54TFClientesEmail_Sel)) ) )
         {
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Email", "")) ;
            AV14CellRow = GXt_int3;
            GXt_char2 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV54TFClientesEmail_Sel)) ? context.GetMessage( "WWP_TitleFilter_EmptyOption", "") : AV54TFClientesEmail_Sel), out  GXt_char2) ;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV53TFClientesEmail)) ) )
            {
               GXt_int3 = (short)(AV14CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Email", "")) ;
               AV14CellRow = GXt_int3;
               GXt_char2 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV53TFClientesEmail, out  GXt_char2) ;
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
            }
         }
         if ( ! ( ( AV56TFClientesEstado_Sels.Count == 0 ) ) )
         {
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Estado", "")) ;
            AV14CellRow = GXt_int3;
            AV58i = 1;
            AV60GXV1 = 1;
            while ( AV60GXV1 <= AV56TFClientesEstado_Sels.Count )
            {
               AV57TFClientesEstado_Sel = AV56TFClientesEstado_Sels.GetString(AV60GXV1);
               if ( AV58i == 1 )
               {
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = "";
               }
               else
               {
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text+", ";
               }
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text+context.GetMessage( gxdomainestadoenum.getDescription(context,AV57TFClientesEstado_Sel), "");
               AV58i = (long)(AV58i+1);
               AV60GXV1 = (int)(AV60GXV1+1);
            }
         }
         AV14CellRow = (int)(AV14CellRow+2);
      }

      protected void S141( )
      {
         /* 'WRITECOLUMNTITLES' Routine */
         returnInSub = false;
         AV44VisibleColumnCount = 0;
         if ( StringUtil.StrCmp(AV32Session.Get("ClientesWWColumnsSelector"), "") != 0 )
         {
            AV39ColumnsSelectorXML = AV32Session.Get("ClientesWWColumnsSelector");
            AV36ColumnsSelector.FromXml(AV39ColumnsSelectorXML, null, "", "");
         }
         else
         {
            /* Execute user subroutine: 'INITIALIZECOLUMNSSELECTOR' */
            S151 ();
            if (returnInSub) return;
         }
         AV36ColumnsSelector.gxTpr_Columns.Sort("Order");
         AV61GXV2 = 1;
         while ( AV61GXV2 <= AV36ColumnsSelector.gxTpr_Columns.Count )
         {
            AV38ColumnsSelector_Column = ((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV36ColumnsSelector.gxTpr_Columns.Item(AV61GXV2));
            if ( AV38ColumnsSelector_Column.gxTpr_Isvisible )
            {
               AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV44VisibleColumnCount), 1, 1).Text = context.GetMessage( (String.IsNullOrEmpty(StringUtil.RTrim( AV38ColumnsSelector_Column.gxTpr_Displayname)) ? AV38ColumnsSelector_Column.gxTpr_Columnname : AV38ColumnsSelector_Column.gxTpr_Displayname), "");
               AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV44VisibleColumnCount), 1, 1).Bold = 1;
               AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV44VisibleColumnCount), 1, 1).Color = 11;
               AV44VisibleColumnCount = (long)(AV44VisibleColumnCount+1);
            }
            AV61GXV2 = (int)(AV61GXV2+1);
         }
      }

      protected void S161( )
      {
         /* 'WRITEDATA' Routine */
         returnInSub = false;
         AV63Clienteswwds_1_filterfulltext = AV19FilterFullText;
         AV64Clienteswwds_2_dynamicfiltersselector1 = AV20DynamicFiltersSelector1;
         AV65Clienteswwds_3_dynamicfiltersoperator1 = AV21DynamicFiltersOperator1;
         AV66Clienteswwds_4_clientesnombre1 = AV22ClientesNombre1;
         AV67Clienteswwds_5_dynamicfiltersenabled2 = AV23DynamicFiltersEnabled2;
         AV68Clienteswwds_6_dynamicfiltersselector2 = AV24DynamicFiltersSelector2;
         AV69Clienteswwds_7_dynamicfiltersoperator2 = AV25DynamicFiltersOperator2;
         AV70Clienteswwds_8_clientesnombre2 = AV26ClientesNombre2;
         AV71Clienteswwds_9_dynamicfiltersenabled3 = AV27DynamicFiltersEnabled3;
         AV72Clienteswwds_10_dynamicfiltersselector3 = AV28DynamicFiltersSelector3;
         AV73Clienteswwds_11_dynamicfiltersoperator3 = AV29DynamicFiltersOperator3;
         AV74Clienteswwds_12_clientesnombre3 = AV30ClientesNombre3;
         AV75Clienteswwds_13_tfclientesid = AV47TFClientesId;
         AV76Clienteswwds_14_tfclientesid_to = AV48TFClientesId_To;
         AV77Clienteswwds_15_tfclientesnombre = AV49TFClientesNombre;
         AV78Clienteswwds_16_tfclientesnombre_sel = AV50TFClientesNombre_Sel;
         AV79Clienteswwds_17_tfclientestelefono = AV51TFClientesTelefono;
         AV80Clienteswwds_18_tfclientestelefono_sel = AV52TFClientesTelefono_Sel;
         AV81Clienteswwds_19_tfclientesemail = AV53TFClientesEmail;
         AV82Clienteswwds_20_tfclientesemail_sel = AV54TFClientesEmail_Sel;
         AV83Clienteswwds_21_tfclientesestado_sels = AV56TFClientesEstado_Sels;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A435ClientesEstado ,
                                              AV83Clienteswwds_21_tfclientesestado_sels ,
                                              AV64Clienteswwds_2_dynamicfiltersselector1 ,
                                              AV65Clienteswwds_3_dynamicfiltersoperator1 ,
                                              AV66Clienteswwds_4_clientesnombre1 ,
                                              AV67Clienteswwds_5_dynamicfiltersenabled2 ,
                                              AV68Clienteswwds_6_dynamicfiltersselector2 ,
                                              AV69Clienteswwds_7_dynamicfiltersoperator2 ,
                                              AV70Clienteswwds_8_clientesnombre2 ,
                                              AV71Clienteswwds_9_dynamicfiltersenabled3 ,
                                              AV72Clienteswwds_10_dynamicfiltersselector3 ,
                                              AV73Clienteswwds_11_dynamicfiltersoperator3 ,
                                              AV74Clienteswwds_12_clientesnombre3 ,
                                              AV75Clienteswwds_13_tfclientesid ,
                                              AV76Clienteswwds_14_tfclientesid_to ,
                                              AV78Clienteswwds_16_tfclientesnombre_sel ,
                                              AV77Clienteswwds_15_tfclientesnombre ,
                                              AV80Clienteswwds_18_tfclientestelefono_sel ,
                                              AV79Clienteswwds_17_tfclientestelefono ,
                                              AV82Clienteswwds_20_tfclientesemail_sel ,
                                              AV81Clienteswwds_19_tfclientesemail ,
                                              AV83Clienteswwds_21_tfclientesestado_sels.Count ,
                                              A160ClientesNombre ,
                                              A106ClientesId ,
                                              A161ClientesTelefono ,
                                              A162ClientesEmail ,
                                              AV17OrderedBy ,
                                              AV18OrderedDsc ,
                                              AV63Clienteswwds_1_filterfulltext } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.INT, TypeConstants.LONG, TypeConstants.SHORT,
                                              TypeConstants.BOOLEAN
                                              }
         });
         lV66Clienteswwds_4_clientesnombre1 = StringUtil.PadR( StringUtil.RTrim( AV66Clienteswwds_4_clientesnombre1), 100, "%");
         lV66Clienteswwds_4_clientesnombre1 = StringUtil.PadR( StringUtil.RTrim( AV66Clienteswwds_4_clientesnombre1), 100, "%");
         lV70Clienteswwds_8_clientesnombre2 = StringUtil.PadR( StringUtil.RTrim( AV70Clienteswwds_8_clientesnombre2), 100, "%");
         lV70Clienteswwds_8_clientesnombre2 = StringUtil.PadR( StringUtil.RTrim( AV70Clienteswwds_8_clientesnombre2), 100, "%");
         lV74Clienteswwds_12_clientesnombre3 = StringUtil.PadR( StringUtil.RTrim( AV74Clienteswwds_12_clientesnombre3), 100, "%");
         lV74Clienteswwds_12_clientesnombre3 = StringUtil.PadR( StringUtil.RTrim( AV74Clienteswwds_12_clientesnombre3), 100, "%");
         lV77Clienteswwds_15_tfclientesnombre = StringUtil.PadR( StringUtil.RTrim( AV77Clienteswwds_15_tfclientesnombre), 100, "%");
         lV79Clienteswwds_17_tfclientestelefono = StringUtil.PadR( StringUtil.RTrim( AV79Clienteswwds_17_tfclientestelefono), 20, "%");
         lV81Clienteswwds_19_tfclientesemail = StringUtil.Concat( StringUtil.RTrim( AV81Clienteswwds_19_tfclientesemail), "%", "");
         /* Using cursor P005L2 */
         pr_default.execute(0, new Object[] {lV66Clienteswwds_4_clientesnombre1, lV66Clienteswwds_4_clientesnombre1, lV70Clienteswwds_8_clientesnombre2, lV70Clienteswwds_8_clientesnombre2, lV74Clienteswwds_12_clientesnombre3, lV74Clienteswwds_12_clientesnombre3, AV75Clienteswwds_13_tfclientesid, AV76Clienteswwds_14_tfclientesid_to, lV77Clienteswwds_15_tfclientesnombre, AV78Clienteswwds_16_tfclientesnombre_sel, lV79Clienteswwds_17_tfclientestelefono, AV80Clienteswwds_18_tfclientestelefono_sel, lV81Clienteswwds_19_tfclientesemail, AV82Clienteswwds_20_tfclientesemail_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A162ClientesEmail = P005L2_A162ClientesEmail[0];
            A161ClientesTelefono = P005L2_A161ClientesTelefono[0];
            A160ClientesNombre = P005L2_A160ClientesNombre[0];
            A106ClientesId = P005L2_A106ClientesId[0];
            A435ClientesEstado = P005L2_A435ClientesEstado[0];
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV63Clienteswwds_1_filterfulltext)) || ( ( StringUtil.Like( StringUtil.Str( (decimal)(A106ClientesId), 18, 0) , StringUtil.PadR( "%" + AV63Clienteswwds_1_filterfulltext , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A160ClientesNombre) , StringUtil.PadR( "%" + StringUtil.Upper( AV63Clienteswwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A161ClientesTelefono) , StringUtil.PadR( "%" + StringUtil.Upper( AV63Clienteswwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A162ClientesEmail) , StringUtil.PadR( "%" + StringUtil.Upper( AV63Clienteswwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( context.GetMessage( "habilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV63Clienteswwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A435ClientesEstado, "HAB") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "deshabilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV63Clienteswwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A435ClientesEstado, "DES") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "pendiente", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV63Clienteswwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A435ClientesEstado, "PEN") == 0 ) ) ) )
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
               AV84GXV3 = 1;
               while ( AV84GXV3 <= AV36ColumnsSelector.gxTpr_Columns.Count )
               {
                  AV38ColumnsSelector_Column = ((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV36ColumnsSelector.gxTpr_Columns.Item(AV84GXV3));
                  if ( AV38ColumnsSelector_Column.gxTpr_Isvisible )
                  {
                     if ( StringUtil.StrCmp(AV38ColumnsSelector_Column.gxTpr_Columnname, "ClientesId") == 0 )
                     {
                        AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV44VisibleColumnCount), 1, 1).Number = A106ClientesId;
                     }
                     else if ( StringUtil.StrCmp(AV38ColumnsSelector_Column.gxTpr_Columnname, "ClientesNombre") == 0 )
                     {
                        GXt_char2 = "";
                        new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A160ClientesNombre, out  GXt_char2) ;
                        AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV44VisibleColumnCount), 1, 1).Text = GXt_char2;
                     }
                     else if ( StringUtil.StrCmp(AV38ColumnsSelector_Column.gxTpr_Columnname, "ClientesTelefono") == 0 )
                     {
                        GXt_char2 = "";
                        new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A161ClientesTelefono, out  GXt_char2) ;
                        AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV44VisibleColumnCount), 1, 1).Text = GXt_char2;
                     }
                     else if ( StringUtil.StrCmp(AV38ColumnsSelector_Column.gxTpr_Columnname, "ClientesEmail") == 0 )
                     {
                        GXt_char2 = "";
                        new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A162ClientesEmail, out  GXt_char2) ;
                        AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV44VisibleColumnCount), 1, 1).Text = GXt_char2;
                     }
                     else if ( StringUtil.StrCmp(AV38ColumnsSelector_Column.gxTpr_Columnname, "ClientesEstado") == 0 )
                     {
                        AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV44VisibleColumnCount), 1, 1).Text = context.GetMessage( gxdomainestadoenum.getDescription(context,A435ClientesEstado), "");
                     }
                     AV44VisibleColumnCount = (long)(AV44VisibleColumnCount+1);
                  }
                  AV84GXV3 = (int)(AV84GXV3+1);
               }
               if ( StringUtil.StrCmp(A435ClientesEstado, context.GetMessage( "HAB", "")) != 0 )
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
         AV32Session.Set("WWPExportFileName", "ClientesWWExport.xlsx");
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
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV36ColumnsSelector,  "ClientesId",  "",  "Identificador",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV36ColumnsSelector,  "ClientesNombre",  "",  "Nombre",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV36ColumnsSelector,  "ClientesTelefono",  "",  "Telefóno",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV36ColumnsSelector,  "ClientesEmail",  "",  "Email",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV36ColumnsSelector,  "ClientesEstado",  "",  "Estado",  true,  "") ;
         GXt_char2 = AV40UserCustomValue;
         new GeneXus.Programs.wwpbaseobjects.loadcolumnsselectorstate(context ).execute(  "ClientesWWColumnsSelector", out  GXt_char2) ;
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
         if ( StringUtil.StrCmp(AV32Session.Get("ClientesWWGridState"), "") == 0 )
         {
            AV34GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "ClientesWWGridState"), null, "", "");
         }
         else
         {
            AV34GridState.FromXml(AV32Session.Get("ClientesWWGridState"), null, "", "");
         }
         AV17OrderedBy = AV34GridState.gxTpr_Orderedby;
         AV18OrderedDsc = AV34GridState.gxTpr_Ordereddsc;
         AV85GXV4 = 1;
         while ( AV85GXV4 <= AV34GridState.gxTpr_Filtervalues.Count )
         {
            AV35GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV34GridState.gxTpr_Filtervalues.Item(AV85GXV4));
            if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV19FilterFullText = AV35GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFCLIENTESID") == 0 )
            {
               AV47TFClientesId = (long)(Math.Round(NumberUtil.Val( AV35GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV48TFClientesId_To = (long)(Math.Round(NumberUtil.Val( AV35GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFCLIENTESNOMBRE") == 0 )
            {
               AV49TFClientesNombre = AV35GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFCLIENTESNOMBRE_SEL") == 0 )
            {
               AV50TFClientesNombre_Sel = AV35GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFCLIENTESTELEFONO") == 0 )
            {
               AV51TFClientesTelefono = AV35GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFCLIENTESTELEFONO_SEL") == 0 )
            {
               AV52TFClientesTelefono_Sel = AV35GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFCLIENTESEMAIL") == 0 )
            {
               AV53TFClientesEmail = AV35GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFCLIENTESEMAIL_SEL") == 0 )
            {
               AV54TFClientesEmail_Sel = AV35GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFCLIENTESESTADO_SEL") == 0 )
            {
               AV55TFClientesEstado_SelsJson = AV35GridStateFilterValue.gxTpr_Value;
               AV56TFClientesEstado_Sels.FromJSonString(AV55TFClientesEstado_SelsJson, null);
            }
            AV85GXV4 = (int)(AV85GXV4+1);
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
         AV59Pgmname = "";
         GXKey = "";
         GXEncryptionTmp = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV11ExcelDocument = new ExcelDocumentI();
         AV19FilterFullText = "";
         AV34GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV31GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV20DynamicFiltersSelector1 = "";
         AV22ClientesNombre1 = "";
         AV24DynamicFiltersSelector2 = "";
         AV26ClientesNombre2 = "";
         AV28DynamicFiltersSelector3 = "";
         AV30ClientesNombre3 = "";
         AV50TFClientesNombre_Sel = "";
         AV49TFClientesNombre = "";
         AV52TFClientesTelefono_Sel = "";
         AV51TFClientesTelefono = "";
         AV54TFClientesEmail_Sel = "";
         AV53TFClientesEmail = "";
         AV56TFClientesEstado_Sels = new GxSimpleCollection<string>();
         AV57TFClientesEstado_Sel = "";
         AV32Session = context.GetSession();
         AV39ColumnsSelectorXML = "";
         AV36ColumnsSelector = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector(context);
         AV38ColumnsSelector_Column = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column(context);
         AV63Clienteswwds_1_filterfulltext = "";
         AV64Clienteswwds_2_dynamicfiltersselector1 = "";
         AV66Clienteswwds_4_clientesnombre1 = "";
         AV68Clienteswwds_6_dynamicfiltersselector2 = "";
         AV70Clienteswwds_8_clientesnombre2 = "";
         AV72Clienteswwds_10_dynamicfiltersselector3 = "";
         AV74Clienteswwds_12_clientesnombre3 = "";
         AV77Clienteswwds_15_tfclientesnombre = "";
         AV78Clienteswwds_16_tfclientesnombre_sel = "";
         AV79Clienteswwds_17_tfclientestelefono = "";
         AV80Clienteswwds_18_tfclientestelefono_sel = "";
         AV81Clienteswwds_19_tfclientesemail = "";
         AV82Clienteswwds_20_tfclientesemail_sel = "";
         AV83Clienteswwds_21_tfclientesestado_sels = new GxSimpleCollection<string>();
         lV66Clienteswwds_4_clientesnombre1 = "";
         lV70Clienteswwds_8_clientesnombre2 = "";
         lV74Clienteswwds_12_clientesnombre3 = "";
         lV77Clienteswwds_15_tfclientesnombre = "";
         lV79Clienteswwds_17_tfclientestelefono = "";
         lV81Clienteswwds_19_tfclientesemail = "";
         A435ClientesEstado = "";
         A160ClientesNombre = "";
         A161ClientesTelefono = "";
         A162ClientesEmail = "";
         P005L2_A162ClientesEmail = new string[] {""} ;
         P005L2_A161ClientesTelefono = new string[] {""} ;
         P005L2_A160ClientesNombre = new string[] {""} ;
         P005L2_A106ClientesId = new long[1] ;
         P005L2_A435ClientesEstado = new string[] {""} ;
         AV40UserCustomValue = "";
         GXt_char2 = "";
         AV37ColumnsSelectorAux = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector(context);
         AV35GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV55TFClientesEstado_SelsJson = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.clienteswwexport__default(),
            new Object[][] {
                new Object[] {
               P005L2_A162ClientesEmail, P005L2_A161ClientesTelefono, P005L2_A160ClientesNombre, P005L2_A106ClientesId, P005L2_A435ClientesEstado
               }
            }
         );
         AV59Pgmname = "ClientesWWExport";
         /* GeneXus formulas. */
         AV59Pgmname = "ClientesWWExport";
      }

      private short AV21DynamicFiltersOperator1 ;
      private short AV25DynamicFiltersOperator2 ;
      private short AV29DynamicFiltersOperator3 ;
      private short GXt_int3 ;
      private short AV65Clienteswwds_3_dynamicfiltersoperator1 ;
      private short AV69Clienteswwds_7_dynamicfiltersoperator2 ;
      private short AV73Clienteswwds_11_dynamicfiltersoperator3 ;
      private short AV17OrderedBy ;
      private int AV14CellRow ;
      private int AV15FirstColumn ;
      private int AV16Random ;
      private int AV60GXV1 ;
      private int AV61GXV2 ;
      private int AV83Clienteswwds_21_tfclientesestado_sels_Count ;
      private int AV84GXV3 ;
      private int AV85GXV4 ;
      private long AV47TFClientesId ;
      private long AV48TFClientesId_To ;
      private long AV58i ;
      private long AV44VisibleColumnCount ;
      private long AV75Clienteswwds_13_tfclientesid ;
      private long AV76Clienteswwds_14_tfclientesid_to ;
      private long A106ClientesId ;
      private string AV59Pgmname ;
      private string GXKey ;
      private string GXEncryptionTmp ;
      private string AV22ClientesNombre1 ;
      private string AV26ClientesNombre2 ;
      private string AV30ClientesNombre3 ;
      private string AV50TFClientesNombre_Sel ;
      private string AV49TFClientesNombre ;
      private string AV52TFClientesTelefono_Sel ;
      private string AV51TFClientesTelefono ;
      private string AV57TFClientesEstado_Sel ;
      private string AV66Clienteswwds_4_clientesnombre1 ;
      private string AV70Clienteswwds_8_clientesnombre2 ;
      private string AV74Clienteswwds_12_clientesnombre3 ;
      private string AV77Clienteswwds_15_tfclientesnombre ;
      private string AV78Clienteswwds_16_tfclientesnombre_sel ;
      private string AV79Clienteswwds_17_tfclientestelefono ;
      private string AV80Clienteswwds_18_tfclientestelefono_sel ;
      private string lV66Clienteswwds_4_clientesnombre1 ;
      private string lV70Clienteswwds_8_clientesnombre2 ;
      private string lV74Clienteswwds_12_clientesnombre3 ;
      private string lV77Clienteswwds_15_tfclientesnombre ;
      private string lV79Clienteswwds_17_tfclientestelefono ;
      private string A435ClientesEstado ;
      private string A160ClientesNombre ;
      private string A161ClientesTelefono ;
      private string GXt_char2 ;
      private bool AV8IsAuthorized ;
      private bool GXt_boolean1 ;
      private bool returnInSub ;
      private bool AV23DynamicFiltersEnabled2 ;
      private bool AV27DynamicFiltersEnabled3 ;
      private bool AV67Clienteswwds_5_dynamicfiltersenabled2 ;
      private bool AV71Clienteswwds_9_dynamicfiltersenabled3 ;
      private bool AV18OrderedDsc ;
      private string AV39ColumnsSelectorXML ;
      private string AV40UserCustomValue ;
      private string AV55TFClientesEstado_SelsJson ;
      private string AV12Filename ;
      private string AV13ErrorMessage ;
      private string AV19FilterFullText ;
      private string AV20DynamicFiltersSelector1 ;
      private string AV24DynamicFiltersSelector2 ;
      private string AV28DynamicFiltersSelector3 ;
      private string AV54TFClientesEmail_Sel ;
      private string AV53TFClientesEmail ;
      private string AV63Clienteswwds_1_filterfulltext ;
      private string AV64Clienteswwds_2_dynamicfiltersselector1 ;
      private string AV68Clienteswwds_6_dynamicfiltersselector2 ;
      private string AV72Clienteswwds_10_dynamicfiltersselector3 ;
      private string AV81Clienteswwds_19_tfclientesemail ;
      private string AV82Clienteswwds_20_tfclientesemail_sel ;
      private string lV81Clienteswwds_19_tfclientesemail ;
      private string A162ClientesEmail ;
      private IGxSession AV32Session ;
      private ExcelDocumentI AV11ExcelDocument ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV34GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV31GridStateDynamicFilter ;
      private GxSimpleCollection<string> AV56TFClientesEstado_Sels ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector AV36ColumnsSelector ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column AV38ColumnsSelector_Column ;
      private GxSimpleCollection<string> AV83Clienteswwds_21_tfclientesestado_sels ;
      private IDataStoreProvider pr_default ;
      private string[] P005L2_A162ClientesEmail ;
      private string[] P005L2_A161ClientesTelefono ;
      private string[] P005L2_A160ClientesNombre ;
      private long[] P005L2_A106ClientesId ;
      private string[] P005L2_A435ClientesEstado ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector AV37ColumnsSelectorAux ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV35GridStateFilterValue ;
      private string aP0_Filename ;
      private string aP1_ErrorMessage ;
   }

   public class clienteswwexport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P005L2( IGxContext context ,
                                             string A435ClientesEstado ,
                                             GxSimpleCollection<string> AV83Clienteswwds_21_tfclientesestado_sels ,
                                             string AV64Clienteswwds_2_dynamicfiltersselector1 ,
                                             short AV65Clienteswwds_3_dynamicfiltersoperator1 ,
                                             string AV66Clienteswwds_4_clientesnombre1 ,
                                             bool AV67Clienteswwds_5_dynamicfiltersenabled2 ,
                                             string AV68Clienteswwds_6_dynamicfiltersselector2 ,
                                             short AV69Clienteswwds_7_dynamicfiltersoperator2 ,
                                             string AV70Clienteswwds_8_clientesnombre2 ,
                                             bool AV71Clienteswwds_9_dynamicfiltersenabled3 ,
                                             string AV72Clienteswwds_10_dynamicfiltersselector3 ,
                                             short AV73Clienteswwds_11_dynamicfiltersoperator3 ,
                                             string AV74Clienteswwds_12_clientesnombre3 ,
                                             long AV75Clienteswwds_13_tfclientesid ,
                                             long AV76Clienteswwds_14_tfclientesid_to ,
                                             string AV78Clienteswwds_16_tfclientesnombre_sel ,
                                             string AV77Clienteswwds_15_tfclientesnombre ,
                                             string AV80Clienteswwds_18_tfclientestelefono_sel ,
                                             string AV79Clienteswwds_17_tfclientestelefono ,
                                             string AV82Clienteswwds_20_tfclientesemail_sel ,
                                             string AV81Clienteswwds_19_tfclientesemail ,
                                             int AV83Clienteswwds_21_tfclientesestado_sels_Count ,
                                             string A160ClientesNombre ,
                                             long A106ClientesId ,
                                             string A161ClientesTelefono ,
                                             string A162ClientesEmail ,
                                             short AV17OrderedBy ,
                                             bool AV18OrderedDsc ,
                                             string AV63Clienteswwds_1_filterfulltext )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int4 = new short[14];
         Object[] GXv_Object5 = new Object[2];
         scmdbuf = "SELECT [ClientesEmail], [ClientesTelefono], [ClientesNombre], [ClientesId], [ClientesEstado] FROM [Clientes]";
         if ( ( StringUtil.StrCmp(AV64Clienteswwds_2_dynamicfiltersselector1, "CLIENTESNOMBRE") == 0 ) && ( AV65Clienteswwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Clienteswwds_4_clientesnombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ClientesNombre]) like UPPER(@lV66Clienteswwds_4_clientesnombre1))");
         }
         else
         {
            GXv_int4[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV64Clienteswwds_2_dynamicfiltersselector1, "CLIENTESNOMBRE") == 0 ) && ( AV65Clienteswwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Clienteswwds_4_clientesnombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ClientesNombre]) like '%' + UPPER(@lV66Clienteswwds_4_clientesnombre1))");
         }
         else
         {
            GXv_int4[1] = 1;
         }
         if ( AV67Clienteswwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV68Clienteswwds_6_dynamicfiltersselector2, "CLIENTESNOMBRE") == 0 ) && ( AV69Clienteswwds_7_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Clienteswwds_8_clientesnombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ClientesNombre]) like UPPER(@lV70Clienteswwds_8_clientesnombre2))");
         }
         else
         {
            GXv_int4[2] = 1;
         }
         if ( AV67Clienteswwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV68Clienteswwds_6_dynamicfiltersselector2, "CLIENTESNOMBRE") == 0 ) && ( AV69Clienteswwds_7_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Clienteswwds_8_clientesnombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ClientesNombre]) like '%' + UPPER(@lV70Clienteswwds_8_clientesnombre2))");
         }
         else
         {
            GXv_int4[3] = 1;
         }
         if ( AV71Clienteswwds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV72Clienteswwds_10_dynamicfiltersselector3, "CLIENTESNOMBRE") == 0 ) && ( AV73Clienteswwds_11_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Clienteswwds_12_clientesnombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ClientesNombre]) like UPPER(@lV74Clienteswwds_12_clientesnombre3))");
         }
         else
         {
            GXv_int4[4] = 1;
         }
         if ( AV71Clienteswwds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV72Clienteswwds_10_dynamicfiltersselector3, "CLIENTESNOMBRE") == 0 ) && ( AV73Clienteswwds_11_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Clienteswwds_12_clientesnombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ClientesNombre]) like '%' + UPPER(@lV74Clienteswwds_12_clientesnombre3))");
         }
         else
         {
            GXv_int4[5] = 1;
         }
         if ( ! (0==AV75Clienteswwds_13_tfclientesid) )
         {
            AddWhere(sWhereString, "([ClientesId] >= @AV75Clienteswwds_13_tfclientesid)");
         }
         else
         {
            GXv_int4[6] = 1;
         }
         if ( ! (0==AV76Clienteswwds_14_tfclientesid_to) )
         {
            AddWhere(sWhereString, "([ClientesId] <= @AV76Clienteswwds_14_tfclientesid_to)");
         }
         else
         {
            GXv_int4[7] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV78Clienteswwds_16_tfclientesnombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV77Clienteswwds_15_tfclientesnombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ClientesNombre]) like UPPER(@lV77Clienteswwds_15_tfclientesnombre))");
         }
         else
         {
            GXv_int4[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV78Clienteswwds_16_tfclientesnombre_sel)) && ! ( StringUtil.StrCmp(AV78Clienteswwds_16_tfclientesnombre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([ClientesNombre] = @AV78Clienteswwds_16_tfclientesnombre_sel)");
         }
         else
         {
            GXv_int4[9] = 1;
         }
         if ( StringUtil.StrCmp(AV78Clienteswwds_16_tfclientesnombre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([ClientesNombre] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV80Clienteswwds_18_tfclientestelefono_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV79Clienteswwds_17_tfclientestelefono)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ClientesTelefono]) like UPPER(@lV79Clienteswwds_17_tfclientestelefono))");
         }
         else
         {
            GXv_int4[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV80Clienteswwds_18_tfclientestelefono_sel)) && ! ( StringUtil.StrCmp(AV80Clienteswwds_18_tfclientestelefono_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([ClientesTelefono] = @AV80Clienteswwds_18_tfclientestelefono_sel)");
         }
         else
         {
            GXv_int4[11] = 1;
         }
         if ( StringUtil.StrCmp(AV80Clienteswwds_18_tfclientestelefono_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([ClientesTelefono] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV82Clienteswwds_20_tfclientesemail_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV81Clienteswwds_19_tfclientesemail)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ClientesEmail]) like UPPER(@lV81Clienteswwds_19_tfclientesemail))");
         }
         else
         {
            GXv_int4[12] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV82Clienteswwds_20_tfclientesemail_sel)) && ! ( StringUtil.StrCmp(AV82Clienteswwds_20_tfclientesemail_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([ClientesEmail] = @AV82Clienteswwds_20_tfclientesemail_sel)");
         }
         else
         {
            GXv_int4[13] = 1;
         }
         if ( StringUtil.StrCmp(AV82Clienteswwds_20_tfclientesemail_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([ClientesEmail] = ''))");
         }
         if ( AV83Clienteswwds_21_tfclientesestado_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV83Clienteswwds_21_tfclientesestado_sels, "[ClientesEstado] IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         if ( ( AV17OrderedBy == 1 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY [ClientesNombre]";
         }
         else if ( ( AV17OrderedBy == 1 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [ClientesNombre] DESC";
         }
         else if ( ( AV17OrderedBy == 2 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY [ClientesId]";
         }
         else if ( ( AV17OrderedBy == 2 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [ClientesId] DESC";
         }
         else if ( ( AV17OrderedBy == 3 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY [ClientesTelefono]";
         }
         else if ( ( AV17OrderedBy == 3 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [ClientesTelefono] DESC";
         }
         else if ( ( AV17OrderedBy == 4 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY [ClientesEmail]";
         }
         else if ( ( AV17OrderedBy == 4 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [ClientesEmail] DESC";
         }
         else if ( ( AV17OrderedBy == 5 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY [ClientesEstado]";
         }
         else if ( ( AV17OrderedBy == 5 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [ClientesEstado] DESC";
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
                     return conditional_P005L2(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (bool)dynConstraints[5] , (string)dynConstraints[6] , (short)dynConstraints[7] , (string)dynConstraints[8] , (bool)dynConstraints[9] , (string)dynConstraints[10] , (short)dynConstraints[11] , (string)dynConstraints[12] , (long)dynConstraints[13] , (long)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (int)dynConstraints[21] , (string)dynConstraints[22] , (long)dynConstraints[23] , (string)dynConstraints[24] , (string)dynConstraints[25] , (short)dynConstraints[26] , (bool)dynConstraints[27] , (string)dynConstraints[28] );
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
          Object[] prmP005L2;
          prmP005L2 = new Object[] {
          new ParDef("@lV66Clienteswwds_4_clientesnombre1",GXType.Char,100,0) ,
          new ParDef("@lV66Clienteswwds_4_clientesnombre1",GXType.Char,100,0) ,
          new ParDef("@lV70Clienteswwds_8_clientesnombre2",GXType.Char,100,0) ,
          new ParDef("@lV70Clienteswwds_8_clientesnombre2",GXType.Char,100,0) ,
          new ParDef("@lV74Clienteswwds_12_clientesnombre3",GXType.Char,100,0) ,
          new ParDef("@lV74Clienteswwds_12_clientesnombre3",GXType.Char,100,0) ,
          new ParDef("@AV75Clienteswwds_13_tfclientesid",GXType.Decimal,18,0) ,
          new ParDef("@AV76Clienteswwds_14_tfclientesid_to",GXType.Decimal,18,0) ,
          new ParDef("@lV77Clienteswwds_15_tfclientesnombre",GXType.Char,100,0) ,
          new ParDef("@AV78Clienteswwds_16_tfclientesnombre_sel",GXType.NChar,100,0) ,
          new ParDef("@lV79Clienteswwds_17_tfclientestelefono",GXType.Char,20,0) ,
          new ParDef("@AV80Clienteswwds_18_tfclientestelefono_sel",GXType.NChar,20,0) ,
          new ParDef("@lV81Clienteswwds_19_tfclientesemail",GXType.VarChar,100,0) ,
          new ParDef("@AV82Clienteswwds_20_tfclientesemail_sel",GXType.NVarChar,100,0)
          };
          def= new CursorDef[] {
              new CursorDef("P005L2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP005L2,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[1])[0] = rslt.getString(2, 20);
                ((string[]) buf[2])[0] = rslt.getString(3, 100);
                ((long[]) buf[3])[0] = rslt.getLong(4);
                ((string[]) buf[4])[0] = rslt.getString(5, 3);
                return;
       }
    }

 }

}

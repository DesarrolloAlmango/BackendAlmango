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
   public class conexioneswwexport : GXProcedure
   {
      public conexioneswwexport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public conexioneswwexport( IGxContext context )
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
         new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWConexiones", out  GXt_boolean1) ;
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
         AV12Filename = GXt_char2 + "ConexionesWWExport-" + StringUtil.Trim( StringUtil.Str( (decimal)(AV16Random), 8, 0)) + ".xlsx";
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
            if ( StringUtil.StrCmp(AV20DynamicFiltersSelector1, "CONEXIONESNOMBRE") == 0 )
            {
               AV21DynamicFiltersOperator1 = AV31GridStateDynamicFilter.gxTpr_Operator;
               AV22ConexionesNombre1 = AV31GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV22ConexionesNombre1)) )
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
                  new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV22ConexionesNombre1, out  GXt_char2) ;
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
               }
            }
            if ( AV34GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV23DynamicFiltersEnabled2 = true;
               AV31GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV34GridState.gxTpr_Dynamicfilters.Item(2));
               AV24DynamicFiltersSelector2 = AV31GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV24DynamicFiltersSelector2, "CONEXIONESNOMBRE") == 0 )
               {
                  AV25DynamicFiltersOperator2 = AV31GridStateDynamicFilter.gxTpr_Operator;
                  AV26ConexionesNombre2 = AV31GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV26ConexionesNombre2)) )
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
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV26ConexionesNombre2, out  GXt_char2) ;
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
                  }
               }
               if ( AV34GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV27DynamicFiltersEnabled3 = true;
                  AV31GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV34GridState.gxTpr_Dynamicfilters.Item(3));
                  AV28DynamicFiltersSelector3 = AV31GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV28DynamicFiltersSelector3, "CONEXIONESNOMBRE") == 0 )
                  {
                     AV29DynamicFiltersOperator3 = AV31GridStateDynamicFilter.gxTpr_Operator;
                     AV30ConexionesNombre3 = AV31GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV30ConexionesNombre3)) )
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
                        new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV30ConexionesNombre3, out  GXt_char2) ;
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
                     }
                  }
               }
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV48TFConexionesID_Sel)) ) )
         {
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Código de Conexión", "")) ;
            AV14CellRow = GXt_int3;
            GXt_char2 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV48TFConexionesID_Sel)) ? context.GetMessage( "WWP_TitleFilter_EmptyOption", "") : AV48TFConexionesID_Sel), out  GXt_char2) ;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV47TFConexionesID)) ) )
            {
               GXt_int3 = (short)(AV14CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Código de Conexión", "")) ;
               AV14CellRow = GXt_int3;
               GXt_char2 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV47TFConexionesID, out  GXt_char2) ;
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV50TFConexionesNombre_Sel)) ) )
         {
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Nombre", "")) ;
            AV14CellRow = GXt_int3;
            GXt_char2 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV50TFConexionesNombre_Sel)) ? context.GetMessage( "WWP_TitleFilter_EmptyOption", "") : AV50TFConexionesNombre_Sel), out  GXt_char2) ;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV49TFConexionesNombre)) ) )
            {
               GXt_int3 = (short)(AV14CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Nombre", "")) ;
               AV14CellRow = GXt_int3;
               GXt_char2 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV49TFConexionesNombre, out  GXt_char2) ;
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV52TFConexionesHost_Sel)) ) )
         {
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Host", "")) ;
            AV14CellRow = GXt_int3;
            GXt_char2 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV52TFConexionesHost_Sel)) ? context.GetMessage( "WWP_TitleFilter_EmptyOption", "") : AV52TFConexionesHost_Sel), out  GXt_char2) ;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV51TFConexionesHost)) ) )
            {
               GXt_int3 = (short)(AV14CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Host", "")) ;
               AV14CellRow = GXt_int3;
               GXt_char2 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV51TFConexionesHost, out  GXt_char2) ;
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV54TFConexionesBaseURL_Sel)) ) )
         {
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "URL", "")) ;
            AV14CellRow = GXt_int3;
            GXt_char2 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV54TFConexionesBaseURL_Sel)) ? context.GetMessage( "WWP_TitleFilter_EmptyOption", "") : AV54TFConexionesBaseURL_Sel), out  GXt_char2) ;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV53TFConexionesBaseURL)) ) )
            {
               GXt_int3 = (short)(AV14CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "URL", "")) ;
               AV14CellRow = GXt_int3;
               GXt_char2 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV53TFConexionesBaseURL, out  GXt_char2) ;
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
            }
         }
         if ( ! ( ( AV56TFConexionesEstado_Sels.Count == 0 ) ) )
         {
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Estado", "")) ;
            AV14CellRow = GXt_int3;
            AV58i = 1;
            AV60GXV1 = 1;
            while ( AV60GXV1 <= AV56TFConexionesEstado_Sels.Count )
            {
               AV57TFConexionesEstado_Sel = AV56TFConexionesEstado_Sels.GetString(AV60GXV1);
               if ( AV58i == 1 )
               {
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = "";
               }
               else
               {
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text+", ";
               }
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text+context.GetMessage( gxdomainestadoenum.getDescription(context,AV57TFConexionesEstado_Sel), "");
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
         if ( StringUtil.StrCmp(AV32Session.Get("ConexionesWWColumnsSelector"), "") != 0 )
         {
            AV39ColumnsSelectorXML = AV32Session.Get("ConexionesWWColumnsSelector");
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
         AV63Conexioneswwds_1_filterfulltext = AV19FilterFullText;
         AV64Conexioneswwds_2_dynamicfiltersselector1 = AV20DynamicFiltersSelector1;
         AV65Conexioneswwds_3_dynamicfiltersoperator1 = AV21DynamicFiltersOperator1;
         AV66Conexioneswwds_4_conexionesnombre1 = AV22ConexionesNombre1;
         AV67Conexioneswwds_5_dynamicfiltersenabled2 = AV23DynamicFiltersEnabled2;
         AV68Conexioneswwds_6_dynamicfiltersselector2 = AV24DynamicFiltersSelector2;
         AV69Conexioneswwds_7_dynamicfiltersoperator2 = AV25DynamicFiltersOperator2;
         AV70Conexioneswwds_8_conexionesnombre2 = AV26ConexionesNombre2;
         AV71Conexioneswwds_9_dynamicfiltersenabled3 = AV27DynamicFiltersEnabled3;
         AV72Conexioneswwds_10_dynamicfiltersselector3 = AV28DynamicFiltersSelector3;
         AV73Conexioneswwds_11_dynamicfiltersoperator3 = AV29DynamicFiltersOperator3;
         AV74Conexioneswwds_12_conexionesnombre3 = AV30ConexionesNombre3;
         AV75Conexioneswwds_13_tfconexionesid = AV47TFConexionesID;
         AV76Conexioneswwds_14_tfconexionesid_sel = AV48TFConexionesID_Sel;
         AV77Conexioneswwds_15_tfconexionesnombre = AV49TFConexionesNombre;
         AV78Conexioneswwds_16_tfconexionesnombre_sel = AV50TFConexionesNombre_Sel;
         AV79Conexioneswwds_17_tfconexioneshost = AV51TFConexionesHost;
         AV80Conexioneswwds_18_tfconexioneshost_sel = AV52TFConexionesHost_Sel;
         AV81Conexioneswwds_19_tfconexionesbaseurl = AV53TFConexionesBaseURL;
         AV82Conexioneswwds_20_tfconexionesbaseurl_sel = AV54TFConexionesBaseURL_Sel;
         AV83Conexioneswwds_21_tfconexionesestado_sels = AV56TFConexionesEstado_Sels;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A562ConexionesEstado ,
                                              AV83Conexioneswwds_21_tfconexionesestado_sels ,
                                              AV64Conexioneswwds_2_dynamicfiltersselector1 ,
                                              AV65Conexioneswwds_3_dynamicfiltersoperator1 ,
                                              AV66Conexioneswwds_4_conexionesnombre1 ,
                                              AV67Conexioneswwds_5_dynamicfiltersenabled2 ,
                                              AV68Conexioneswwds_6_dynamicfiltersselector2 ,
                                              AV69Conexioneswwds_7_dynamicfiltersoperator2 ,
                                              AV70Conexioneswwds_8_conexionesnombre2 ,
                                              AV71Conexioneswwds_9_dynamicfiltersenabled3 ,
                                              AV72Conexioneswwds_10_dynamicfiltersselector3 ,
                                              AV73Conexioneswwds_11_dynamicfiltersoperator3 ,
                                              AV74Conexioneswwds_12_conexionesnombre3 ,
                                              AV76Conexioneswwds_14_tfconexionesid_sel ,
                                              AV75Conexioneswwds_13_tfconexionesid ,
                                              AV78Conexioneswwds_16_tfconexionesnombre_sel ,
                                              AV77Conexioneswwds_15_tfconexionesnombre ,
                                              AV80Conexioneswwds_18_tfconexioneshost_sel ,
                                              AV79Conexioneswwds_17_tfconexioneshost ,
                                              AV82Conexioneswwds_20_tfconexionesbaseurl_sel ,
                                              AV81Conexioneswwds_19_tfconexionesbaseurl ,
                                              AV83Conexioneswwds_21_tfconexionesestado_sels.Count ,
                                              A556ConexionesNombre ,
                                              A552ConexionesID ,
                                              A557ConexionesHost ,
                                              A558ConexionesBaseURL ,
                                              AV17OrderedBy ,
                                              AV18OrderedDsc ,
                                              AV63Conexioneswwds_1_filterfulltext } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN,
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV66Conexioneswwds_4_conexionesnombre1 = StringUtil.PadR( StringUtil.RTrim( AV66Conexioneswwds_4_conexionesnombre1), 80, "%");
         lV66Conexioneswwds_4_conexionesnombre1 = StringUtil.PadR( StringUtil.RTrim( AV66Conexioneswwds_4_conexionesnombre1), 80, "%");
         lV70Conexioneswwds_8_conexionesnombre2 = StringUtil.PadR( StringUtil.RTrim( AV70Conexioneswwds_8_conexionesnombre2), 80, "%");
         lV70Conexioneswwds_8_conexionesnombre2 = StringUtil.PadR( StringUtil.RTrim( AV70Conexioneswwds_8_conexionesnombre2), 80, "%");
         lV74Conexioneswwds_12_conexionesnombre3 = StringUtil.PadR( StringUtil.RTrim( AV74Conexioneswwds_12_conexionesnombre3), 80, "%");
         lV74Conexioneswwds_12_conexionesnombre3 = StringUtil.PadR( StringUtil.RTrim( AV74Conexioneswwds_12_conexionesnombre3), 80, "%");
         lV75Conexioneswwds_13_tfconexionesid = StringUtil.PadR( StringUtil.RTrim( AV75Conexioneswwds_13_tfconexionesid), 9, "%");
         lV77Conexioneswwds_15_tfconexionesnombre = StringUtil.PadR( StringUtil.RTrim( AV77Conexioneswwds_15_tfconexionesnombre), 80, "%");
         lV79Conexioneswwds_17_tfconexioneshost = StringUtil.PadR( StringUtil.RTrim( AV79Conexioneswwds_17_tfconexioneshost), 128, "%");
         lV81Conexioneswwds_19_tfconexionesbaseurl = StringUtil.PadR( StringUtil.RTrim( AV81Conexioneswwds_19_tfconexionesbaseurl), 128, "%");
         /* Using cursor P00752 */
         pr_default.execute(0, new Object[] {lV66Conexioneswwds_4_conexionesnombre1, lV66Conexioneswwds_4_conexionesnombre1, lV70Conexioneswwds_8_conexionesnombre2, lV70Conexioneswwds_8_conexionesnombre2, lV74Conexioneswwds_12_conexionesnombre3, lV74Conexioneswwds_12_conexionesnombre3, lV75Conexioneswwds_13_tfconexionesid, AV76Conexioneswwds_14_tfconexionesid_sel, lV77Conexioneswwds_15_tfconexionesnombre, AV78Conexioneswwds_16_tfconexionesnombre_sel, lV79Conexioneswwds_17_tfconexioneshost, AV80Conexioneswwds_18_tfconexioneshost_sel, lV81Conexioneswwds_19_tfconexionesbaseurl, AV82Conexioneswwds_20_tfconexionesbaseurl_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A558ConexionesBaseURL = P00752_A558ConexionesBaseURL[0];
            n558ConexionesBaseURL = P00752_n558ConexionesBaseURL[0];
            A557ConexionesHost = P00752_A557ConexionesHost[0];
            n557ConexionesHost = P00752_n557ConexionesHost[0];
            A556ConexionesNombre = P00752_A556ConexionesNombre[0];
            n556ConexionesNombre = P00752_n556ConexionesNombre[0];
            A552ConexionesID = P00752_A552ConexionesID[0];
            A562ConexionesEstado = P00752_A562ConexionesEstado[0];
            n562ConexionesEstado = P00752_n562ConexionesEstado[0];
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV63Conexioneswwds_1_filterfulltext)) || ( ( StringUtil.Like( StringUtil.Upper( A552ConexionesID) , StringUtil.PadR( "%" + StringUtil.Upper( AV63Conexioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A556ConexionesNombre) , StringUtil.PadR( "%" + StringUtil.Upper( AV63Conexioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A557ConexionesHost) , StringUtil.PadR( "%" + StringUtil.Upper( AV63Conexioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A558ConexionesBaseURL) , StringUtil.PadR( "%" + StringUtil.Upper( AV63Conexioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( context.GetMessage( "habilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV63Conexioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A562ConexionesEstado, "HAB") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "deshabilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV63Conexioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A562ConexionesEstado, "DES") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "pendiente", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV63Conexioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A562ConexionesEstado, "PEN") == 0 ) ) ) )
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
                     if ( StringUtil.StrCmp(AV38ColumnsSelector_Column.gxTpr_Columnname, "ConexionesID") == 0 )
                     {
                        GXt_char2 = "";
                        new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A552ConexionesID, out  GXt_char2) ;
                        AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV44VisibleColumnCount), 1, 1).Text = GXt_char2;
                     }
                     else if ( StringUtil.StrCmp(AV38ColumnsSelector_Column.gxTpr_Columnname, "ConexionesNombre") == 0 )
                     {
                        GXt_char2 = "";
                        new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A556ConexionesNombre, out  GXt_char2) ;
                        AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV44VisibleColumnCount), 1, 1).Text = GXt_char2;
                     }
                     else if ( StringUtil.StrCmp(AV38ColumnsSelector_Column.gxTpr_Columnname, "ConexionesHost") == 0 )
                     {
                        GXt_char2 = "";
                        new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A557ConexionesHost, out  GXt_char2) ;
                        AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV44VisibleColumnCount), 1, 1).Text = GXt_char2;
                     }
                     else if ( StringUtil.StrCmp(AV38ColumnsSelector_Column.gxTpr_Columnname, "ConexionesBaseURL") == 0 )
                     {
                        GXt_char2 = "";
                        new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A558ConexionesBaseURL, out  GXt_char2) ;
                        AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV44VisibleColumnCount), 1, 1).Text = GXt_char2;
                     }
                     else if ( StringUtil.StrCmp(AV38ColumnsSelector_Column.gxTpr_Columnname, "ConexionesEstado") == 0 )
                     {
                        AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV44VisibleColumnCount), 1, 1).Text = context.GetMessage( gxdomainestadoenum.getDescription(context,A562ConexionesEstado), "");
                     }
                     AV44VisibleColumnCount = (long)(AV44VisibleColumnCount+1);
                  }
                  AV84GXV3 = (int)(AV84GXV3+1);
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
         AV32Session.Set("WWPExportFileName", "ConexionesWWExport.xlsx");
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
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV36ColumnsSelector,  "ConexionesID",  "",  "Código de Conexión",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV36ColumnsSelector,  "ConexionesNombre",  "",  "Nombre",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV36ColumnsSelector,  "ConexionesHost",  "",  "Host",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV36ColumnsSelector,  "ConexionesBaseURL",  "",  "URL",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV36ColumnsSelector,  "ConexionesEstado",  "",  "Estado",  true,  "") ;
         GXt_char2 = AV40UserCustomValue;
         new GeneXus.Programs.wwpbaseobjects.loadcolumnsselectorstate(context ).execute(  "ConexionesWWColumnsSelector", out  GXt_char2) ;
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
         if ( StringUtil.StrCmp(AV32Session.Get("ConexionesWWGridState"), "") == 0 )
         {
            AV34GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "ConexionesWWGridState"), null, "", "");
         }
         else
         {
            AV34GridState.FromXml(AV32Session.Get("ConexionesWWGridState"), null, "", "");
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
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFCONEXIONESID") == 0 )
            {
               AV47TFConexionesID = AV35GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFCONEXIONESID_SEL") == 0 )
            {
               AV48TFConexionesID_Sel = AV35GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFCONEXIONESNOMBRE") == 0 )
            {
               AV49TFConexionesNombre = AV35GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFCONEXIONESNOMBRE_SEL") == 0 )
            {
               AV50TFConexionesNombre_Sel = AV35GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFCONEXIONESHOST") == 0 )
            {
               AV51TFConexionesHost = AV35GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFCONEXIONESHOST_SEL") == 0 )
            {
               AV52TFConexionesHost_Sel = AV35GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFCONEXIONESBASEURL") == 0 )
            {
               AV53TFConexionesBaseURL = AV35GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFCONEXIONESBASEURL_SEL") == 0 )
            {
               AV54TFConexionesBaseURL_Sel = AV35GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFCONEXIONESESTADO_SEL") == 0 )
            {
               AV55TFConexionesEstado_SelsJson = AV35GridStateFilterValue.gxTpr_Value;
               AV56TFConexionesEstado_Sels.FromJSonString(AV55TFConexionesEstado_SelsJson, null);
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
         AV22ConexionesNombre1 = "";
         AV24DynamicFiltersSelector2 = "";
         AV26ConexionesNombre2 = "";
         AV28DynamicFiltersSelector3 = "";
         AV30ConexionesNombre3 = "";
         AV48TFConexionesID_Sel = "";
         AV47TFConexionesID = "";
         AV50TFConexionesNombre_Sel = "";
         AV49TFConexionesNombre = "";
         AV52TFConexionesHost_Sel = "";
         AV51TFConexionesHost = "";
         AV54TFConexionesBaseURL_Sel = "";
         AV53TFConexionesBaseURL = "";
         AV56TFConexionesEstado_Sels = new GxSimpleCollection<string>();
         AV57TFConexionesEstado_Sel = "";
         AV32Session = context.GetSession();
         AV39ColumnsSelectorXML = "";
         AV36ColumnsSelector = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector(context);
         AV38ColumnsSelector_Column = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column(context);
         AV63Conexioneswwds_1_filterfulltext = "";
         AV64Conexioneswwds_2_dynamicfiltersselector1 = "";
         AV66Conexioneswwds_4_conexionesnombre1 = "";
         AV68Conexioneswwds_6_dynamicfiltersselector2 = "";
         AV70Conexioneswwds_8_conexionesnombre2 = "";
         AV72Conexioneswwds_10_dynamicfiltersselector3 = "";
         AV74Conexioneswwds_12_conexionesnombre3 = "";
         AV75Conexioneswwds_13_tfconexionesid = "";
         AV76Conexioneswwds_14_tfconexionesid_sel = "";
         AV77Conexioneswwds_15_tfconexionesnombre = "";
         AV78Conexioneswwds_16_tfconexionesnombre_sel = "";
         AV79Conexioneswwds_17_tfconexioneshost = "";
         AV80Conexioneswwds_18_tfconexioneshost_sel = "";
         AV81Conexioneswwds_19_tfconexionesbaseurl = "";
         AV82Conexioneswwds_20_tfconexionesbaseurl_sel = "";
         AV83Conexioneswwds_21_tfconexionesestado_sels = new GxSimpleCollection<string>();
         lV66Conexioneswwds_4_conexionesnombre1 = "";
         lV70Conexioneswwds_8_conexionesnombre2 = "";
         lV74Conexioneswwds_12_conexionesnombre3 = "";
         lV75Conexioneswwds_13_tfconexionesid = "";
         lV77Conexioneswwds_15_tfconexionesnombre = "";
         lV79Conexioneswwds_17_tfconexioneshost = "";
         lV81Conexioneswwds_19_tfconexionesbaseurl = "";
         A562ConexionesEstado = "";
         A556ConexionesNombre = "";
         A552ConexionesID = "";
         A557ConexionesHost = "";
         A558ConexionesBaseURL = "";
         P00752_A558ConexionesBaseURL = new string[] {""} ;
         P00752_n558ConexionesBaseURL = new bool[] {false} ;
         P00752_A557ConexionesHost = new string[] {""} ;
         P00752_n557ConexionesHost = new bool[] {false} ;
         P00752_A556ConexionesNombre = new string[] {""} ;
         P00752_n556ConexionesNombre = new bool[] {false} ;
         P00752_A552ConexionesID = new string[] {""} ;
         P00752_A562ConexionesEstado = new string[] {""} ;
         P00752_n562ConexionesEstado = new bool[] {false} ;
         AV40UserCustomValue = "";
         GXt_char2 = "";
         AV37ColumnsSelectorAux = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector(context);
         AV35GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV55TFConexionesEstado_SelsJson = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.conexioneswwexport__default(),
            new Object[][] {
                new Object[] {
               P00752_A558ConexionesBaseURL, P00752_n558ConexionesBaseURL, P00752_A557ConexionesHost, P00752_n557ConexionesHost, P00752_A556ConexionesNombre, P00752_n556ConexionesNombre, P00752_A552ConexionesID, P00752_A562ConexionesEstado, P00752_n562ConexionesEstado
               }
            }
         );
         AV59Pgmname = "ConexionesWWExport";
         /* GeneXus formulas. */
         AV59Pgmname = "ConexionesWWExport";
      }

      private short AV21DynamicFiltersOperator1 ;
      private short AV25DynamicFiltersOperator2 ;
      private short AV29DynamicFiltersOperator3 ;
      private short GXt_int3 ;
      private short AV65Conexioneswwds_3_dynamicfiltersoperator1 ;
      private short AV69Conexioneswwds_7_dynamicfiltersoperator2 ;
      private short AV73Conexioneswwds_11_dynamicfiltersoperator3 ;
      private short AV17OrderedBy ;
      private int AV14CellRow ;
      private int AV15FirstColumn ;
      private int AV16Random ;
      private int AV60GXV1 ;
      private int AV61GXV2 ;
      private int AV83Conexioneswwds_21_tfconexionesestado_sels_Count ;
      private int AV84GXV3 ;
      private int AV85GXV4 ;
      private long AV58i ;
      private long AV44VisibleColumnCount ;
      private string AV59Pgmname ;
      private string GXKey ;
      private string GXEncryptionTmp ;
      private string AV22ConexionesNombre1 ;
      private string AV26ConexionesNombre2 ;
      private string AV30ConexionesNombre3 ;
      private string AV48TFConexionesID_Sel ;
      private string AV47TFConexionesID ;
      private string AV50TFConexionesNombre_Sel ;
      private string AV49TFConexionesNombre ;
      private string AV52TFConexionesHost_Sel ;
      private string AV51TFConexionesHost ;
      private string AV54TFConexionesBaseURL_Sel ;
      private string AV53TFConexionesBaseURL ;
      private string AV57TFConexionesEstado_Sel ;
      private string AV66Conexioneswwds_4_conexionesnombre1 ;
      private string AV70Conexioneswwds_8_conexionesnombre2 ;
      private string AV74Conexioneswwds_12_conexionesnombre3 ;
      private string AV75Conexioneswwds_13_tfconexionesid ;
      private string AV76Conexioneswwds_14_tfconexionesid_sel ;
      private string AV77Conexioneswwds_15_tfconexionesnombre ;
      private string AV78Conexioneswwds_16_tfconexionesnombre_sel ;
      private string AV79Conexioneswwds_17_tfconexioneshost ;
      private string AV80Conexioneswwds_18_tfconexioneshost_sel ;
      private string AV81Conexioneswwds_19_tfconexionesbaseurl ;
      private string AV82Conexioneswwds_20_tfconexionesbaseurl_sel ;
      private string lV66Conexioneswwds_4_conexionesnombre1 ;
      private string lV70Conexioneswwds_8_conexionesnombre2 ;
      private string lV74Conexioneswwds_12_conexionesnombre3 ;
      private string lV75Conexioneswwds_13_tfconexionesid ;
      private string lV77Conexioneswwds_15_tfconexionesnombre ;
      private string lV79Conexioneswwds_17_tfconexioneshost ;
      private string lV81Conexioneswwds_19_tfconexionesbaseurl ;
      private string A562ConexionesEstado ;
      private string A556ConexionesNombre ;
      private string A552ConexionesID ;
      private string A557ConexionesHost ;
      private string A558ConexionesBaseURL ;
      private string GXt_char2 ;
      private bool AV8IsAuthorized ;
      private bool GXt_boolean1 ;
      private bool returnInSub ;
      private bool AV23DynamicFiltersEnabled2 ;
      private bool AV27DynamicFiltersEnabled3 ;
      private bool AV67Conexioneswwds_5_dynamicfiltersenabled2 ;
      private bool AV71Conexioneswwds_9_dynamicfiltersenabled3 ;
      private bool AV18OrderedDsc ;
      private bool n558ConexionesBaseURL ;
      private bool n557ConexionesHost ;
      private bool n556ConexionesNombre ;
      private bool n562ConexionesEstado ;
      private string AV39ColumnsSelectorXML ;
      private string AV40UserCustomValue ;
      private string AV55TFConexionesEstado_SelsJson ;
      private string AV12Filename ;
      private string AV13ErrorMessage ;
      private string AV19FilterFullText ;
      private string AV20DynamicFiltersSelector1 ;
      private string AV24DynamicFiltersSelector2 ;
      private string AV28DynamicFiltersSelector3 ;
      private string AV63Conexioneswwds_1_filterfulltext ;
      private string AV64Conexioneswwds_2_dynamicfiltersselector1 ;
      private string AV68Conexioneswwds_6_dynamicfiltersselector2 ;
      private string AV72Conexioneswwds_10_dynamicfiltersselector3 ;
      private IGxSession AV32Session ;
      private ExcelDocumentI AV11ExcelDocument ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV34GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV31GridStateDynamicFilter ;
      private GxSimpleCollection<string> AV56TFConexionesEstado_Sels ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector AV36ColumnsSelector ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column AV38ColumnsSelector_Column ;
      private GxSimpleCollection<string> AV83Conexioneswwds_21_tfconexionesestado_sels ;
      private IDataStoreProvider pr_default ;
      private string[] P00752_A558ConexionesBaseURL ;
      private bool[] P00752_n558ConexionesBaseURL ;
      private string[] P00752_A557ConexionesHost ;
      private bool[] P00752_n557ConexionesHost ;
      private string[] P00752_A556ConexionesNombre ;
      private bool[] P00752_n556ConexionesNombre ;
      private string[] P00752_A552ConexionesID ;
      private string[] P00752_A562ConexionesEstado ;
      private bool[] P00752_n562ConexionesEstado ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector AV37ColumnsSelectorAux ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV35GridStateFilterValue ;
      private string aP0_Filename ;
      private string aP1_ErrorMessage ;
   }

   public class conexioneswwexport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00752( IGxContext context ,
                                             string A562ConexionesEstado ,
                                             GxSimpleCollection<string> AV83Conexioneswwds_21_tfconexionesestado_sels ,
                                             string AV64Conexioneswwds_2_dynamicfiltersselector1 ,
                                             short AV65Conexioneswwds_3_dynamicfiltersoperator1 ,
                                             string AV66Conexioneswwds_4_conexionesnombre1 ,
                                             bool AV67Conexioneswwds_5_dynamicfiltersenabled2 ,
                                             string AV68Conexioneswwds_6_dynamicfiltersselector2 ,
                                             short AV69Conexioneswwds_7_dynamicfiltersoperator2 ,
                                             string AV70Conexioneswwds_8_conexionesnombre2 ,
                                             bool AV71Conexioneswwds_9_dynamicfiltersenabled3 ,
                                             string AV72Conexioneswwds_10_dynamicfiltersselector3 ,
                                             short AV73Conexioneswwds_11_dynamicfiltersoperator3 ,
                                             string AV74Conexioneswwds_12_conexionesnombre3 ,
                                             string AV76Conexioneswwds_14_tfconexionesid_sel ,
                                             string AV75Conexioneswwds_13_tfconexionesid ,
                                             string AV78Conexioneswwds_16_tfconexionesnombre_sel ,
                                             string AV77Conexioneswwds_15_tfconexionesnombre ,
                                             string AV80Conexioneswwds_18_tfconexioneshost_sel ,
                                             string AV79Conexioneswwds_17_tfconexioneshost ,
                                             string AV82Conexioneswwds_20_tfconexionesbaseurl_sel ,
                                             string AV81Conexioneswwds_19_tfconexionesbaseurl ,
                                             int AV83Conexioneswwds_21_tfconexionesestado_sels_Count ,
                                             string A556ConexionesNombre ,
                                             string A552ConexionesID ,
                                             string A557ConexionesHost ,
                                             string A558ConexionesBaseURL ,
                                             short AV17OrderedBy ,
                                             bool AV18OrderedDsc ,
                                             string AV63Conexioneswwds_1_filterfulltext )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int4 = new short[14];
         Object[] GXv_Object5 = new Object[2];
         scmdbuf = "SELECT [ConexionesBaseURL], [ConexionesHost], [ConexionesNombre], [ConexionesID], [ConexionesEstado] FROM [Conexiones]";
         if ( ( StringUtil.StrCmp(AV64Conexioneswwds_2_dynamicfiltersselector1, "CONEXIONESNOMBRE") == 0 ) && ( AV65Conexioneswwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Conexioneswwds_4_conexionesnombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ConexionesNombre]) like UPPER(@lV66Conexioneswwds_4_conexionesnombre1))");
         }
         else
         {
            GXv_int4[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV64Conexioneswwds_2_dynamicfiltersselector1, "CONEXIONESNOMBRE") == 0 ) && ( AV65Conexioneswwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Conexioneswwds_4_conexionesnombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ConexionesNombre]) like '%' + UPPER(@lV66Conexioneswwds_4_conexionesnombre1))");
         }
         else
         {
            GXv_int4[1] = 1;
         }
         if ( AV67Conexioneswwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV68Conexioneswwds_6_dynamicfiltersselector2, "CONEXIONESNOMBRE") == 0 ) && ( AV69Conexioneswwds_7_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Conexioneswwds_8_conexionesnombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ConexionesNombre]) like UPPER(@lV70Conexioneswwds_8_conexionesnombre2))");
         }
         else
         {
            GXv_int4[2] = 1;
         }
         if ( AV67Conexioneswwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV68Conexioneswwds_6_dynamicfiltersselector2, "CONEXIONESNOMBRE") == 0 ) && ( AV69Conexioneswwds_7_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Conexioneswwds_8_conexionesnombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ConexionesNombre]) like '%' + UPPER(@lV70Conexioneswwds_8_conexionesnombre2))");
         }
         else
         {
            GXv_int4[3] = 1;
         }
         if ( AV71Conexioneswwds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV72Conexioneswwds_10_dynamicfiltersselector3, "CONEXIONESNOMBRE") == 0 ) && ( AV73Conexioneswwds_11_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Conexioneswwds_12_conexionesnombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ConexionesNombre]) like UPPER(@lV74Conexioneswwds_12_conexionesnombre3))");
         }
         else
         {
            GXv_int4[4] = 1;
         }
         if ( AV71Conexioneswwds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV72Conexioneswwds_10_dynamicfiltersselector3, "CONEXIONESNOMBRE") == 0 ) && ( AV73Conexioneswwds_11_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Conexioneswwds_12_conexionesnombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ConexionesNombre]) like '%' + UPPER(@lV74Conexioneswwds_12_conexionesnombre3))");
         }
         else
         {
            GXv_int4[5] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV76Conexioneswwds_14_tfconexionesid_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75Conexioneswwds_13_tfconexionesid)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ConexionesID]) like UPPER(@lV75Conexioneswwds_13_tfconexionesid))");
         }
         else
         {
            GXv_int4[6] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV76Conexioneswwds_14_tfconexionesid_sel)) && ! ( StringUtil.StrCmp(AV76Conexioneswwds_14_tfconexionesid_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([ConexionesID] = @AV76Conexioneswwds_14_tfconexionesid_sel)");
         }
         else
         {
            GXv_int4[7] = 1;
         }
         if ( StringUtil.StrCmp(AV76Conexioneswwds_14_tfconexionesid_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([ConexionesID] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV78Conexioneswwds_16_tfconexionesnombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV77Conexioneswwds_15_tfconexionesnombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ConexionesNombre]) like UPPER(@lV77Conexioneswwds_15_tfconexionesnombre))");
         }
         else
         {
            GXv_int4[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV78Conexioneswwds_16_tfconexionesnombre_sel)) && ! ( StringUtil.StrCmp(AV78Conexioneswwds_16_tfconexionesnombre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([ConexionesNombre] = @AV78Conexioneswwds_16_tfconexionesnombre_sel)");
         }
         else
         {
            GXv_int4[9] = 1;
         }
         if ( StringUtil.StrCmp(AV78Conexioneswwds_16_tfconexionesnombre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "([ConexionesNombre] IS NULL or ([ConexionesNombre] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV80Conexioneswwds_18_tfconexioneshost_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV79Conexioneswwds_17_tfconexioneshost)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ConexionesHost]) like UPPER(@lV79Conexioneswwds_17_tfconexioneshost))");
         }
         else
         {
            GXv_int4[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV80Conexioneswwds_18_tfconexioneshost_sel)) && ! ( StringUtil.StrCmp(AV80Conexioneswwds_18_tfconexioneshost_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([ConexionesHost] = @AV80Conexioneswwds_18_tfconexioneshost_sel)");
         }
         else
         {
            GXv_int4[11] = 1;
         }
         if ( StringUtil.StrCmp(AV80Conexioneswwds_18_tfconexioneshost_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "([ConexionesHost] IS NULL or ([ConexionesHost] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV82Conexioneswwds_20_tfconexionesbaseurl_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV81Conexioneswwds_19_tfconexionesbaseurl)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ConexionesBaseURL]) like UPPER(@lV81Conexioneswwds_19_tfconexionesbaseurl))");
         }
         else
         {
            GXv_int4[12] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV82Conexioneswwds_20_tfconexionesbaseurl_sel)) && ! ( StringUtil.StrCmp(AV82Conexioneswwds_20_tfconexionesbaseurl_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([ConexionesBaseURL] = @AV82Conexioneswwds_20_tfconexionesbaseurl_sel)");
         }
         else
         {
            GXv_int4[13] = 1;
         }
         if ( StringUtil.StrCmp(AV82Conexioneswwds_20_tfconexionesbaseurl_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "([ConexionesBaseURL] IS NULL or ([ConexionesBaseURL] = ''))");
         }
         if ( AV83Conexioneswwds_21_tfconexionesestado_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV83Conexioneswwds_21_tfconexionesestado_sels, "[ConexionesEstado] IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         if ( ( AV17OrderedBy == 1 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY [ConexionesNombre]";
         }
         else if ( ( AV17OrderedBy == 1 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [ConexionesNombre] DESC";
         }
         else if ( ( AV17OrderedBy == 2 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY [ConexionesID]";
         }
         else if ( ( AV17OrderedBy == 2 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [ConexionesID] DESC";
         }
         else if ( ( AV17OrderedBy == 3 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY [ConexionesHost]";
         }
         else if ( ( AV17OrderedBy == 3 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [ConexionesHost] DESC";
         }
         else if ( ( AV17OrderedBy == 4 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY [ConexionesBaseURL]";
         }
         else if ( ( AV17OrderedBy == 4 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [ConexionesBaseURL] DESC";
         }
         else if ( ( AV17OrderedBy == 5 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY [ConexionesEstado]";
         }
         else if ( ( AV17OrderedBy == 5 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [ConexionesEstado] DESC";
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
                     return conditional_P00752(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (bool)dynConstraints[5] , (string)dynConstraints[6] , (short)dynConstraints[7] , (string)dynConstraints[8] , (bool)dynConstraints[9] , (string)dynConstraints[10] , (short)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (int)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (string)dynConstraints[25] , (short)dynConstraints[26] , (bool)dynConstraints[27] , (string)dynConstraints[28] );
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
          Object[] prmP00752;
          prmP00752 = new Object[] {
          new ParDef("@lV66Conexioneswwds_4_conexionesnombre1",GXType.Char,80,0) ,
          new ParDef("@lV66Conexioneswwds_4_conexionesnombre1",GXType.Char,80,0) ,
          new ParDef("@lV70Conexioneswwds_8_conexionesnombre2",GXType.Char,80,0) ,
          new ParDef("@lV70Conexioneswwds_8_conexionesnombre2",GXType.Char,80,0) ,
          new ParDef("@lV74Conexioneswwds_12_conexionesnombre3",GXType.Char,80,0) ,
          new ParDef("@lV74Conexioneswwds_12_conexionesnombre3",GXType.Char,80,0) ,
          new ParDef("@lV75Conexioneswwds_13_tfconexionesid",GXType.Char,9,0) ,
          new ParDef("@AV76Conexioneswwds_14_tfconexionesid_sel",GXType.NChar,9,0) ,
          new ParDef("@lV77Conexioneswwds_15_tfconexionesnombre",GXType.Char,80,0) ,
          new ParDef("@AV78Conexioneswwds_16_tfconexionesnombre_sel",GXType.NChar,80,0) ,
          new ParDef("@lV79Conexioneswwds_17_tfconexioneshost",GXType.Char,128,0) ,
          new ParDef("@AV80Conexioneswwds_18_tfconexioneshost_sel",GXType.NChar,128,0) ,
          new ParDef("@lV81Conexioneswwds_19_tfconexionesbaseurl",GXType.Char,128,0) ,
          new ParDef("@AV82Conexioneswwds_20_tfconexionesbaseurl_sel",GXType.NChar,128,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00752", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00752,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[0])[0] = rslt.getString(1, 128);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getString(2, 128);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((string[]) buf[4])[0] = rslt.getString(3, 80);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((string[]) buf[6])[0] = rslt.getString(4, 9);
                ((string[]) buf[7])[0] = rslt.getString(5, 3);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                return;
       }
    }

 }

}

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
   public class parametromudanzawwexport : GXProcedure
   {
      public parametromudanzawwexport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public parametromudanzawwexport( IGxContext context )
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
         new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWParametroMudanza", out  GXt_boolean1) ;
         AV8IsAuthorized = GXt_boolean1;
         if ( ! AV8IsAuthorized )
         {
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "wwpbaseobjects.notauthorized.aspx"+GXUtil.UrlEncode(StringUtil.RTrim(AV64Pgmname));
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
         AV12Filename = GXt_char2 + "ParametroMudanzaWWExport-" + StringUtil.Trim( StringUtil.Str( (decimal)(AV16Random), 8, 0)) + ".xlsx";
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
         if ( AV31GridState.gxTpr_Dynamicfilters.Count >= 1 )
         {
            AV28GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV31GridState.gxTpr_Dynamicfilters.Item(1));
            AV20DynamicFiltersSelector1 = AV28GridStateDynamicFilter.gxTpr_Selected;
            if ( StringUtil.StrCmp(AV20DynamicFiltersSelector1, "PARAMETROMUDANZATIPO") == 0 )
            {
               AV21ParametroMudanzaTipo1 = AV28GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV21ParametroMudanzaTipo1)) )
               {
                  AV14CellRow = (int)(AV14CellRow+1);
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Bold = 1;
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Color = 3;
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = context.GetMessage( "Mudanza Tipo", "");
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Italic = 1;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV21ParametroMudanzaTipo1)) )
                  {
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = context.GetMessage( gxdomaintipomudanza.getDescription(context,AV21ParametroMudanzaTipo1), "");
                  }
               }
            }
            if ( AV31GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV22DynamicFiltersEnabled2 = true;
               AV28GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV31GridState.gxTpr_Dynamicfilters.Item(2));
               AV23DynamicFiltersSelector2 = AV28GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV23DynamicFiltersSelector2, "PARAMETROMUDANZATIPO") == 0 )
               {
                  AV24ParametroMudanzaTipo2 = AV28GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV24ParametroMudanzaTipo2)) )
                  {
                     AV14CellRow = (int)(AV14CellRow+1);
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Bold = 1;
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Color = 3;
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = context.GetMessage( "Mudanza Tipo", "");
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Italic = 1;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV24ParametroMudanzaTipo2)) )
                     {
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = context.GetMessage( gxdomaintipomudanza.getDescription(context,AV24ParametroMudanzaTipo2), "");
                     }
                  }
               }
               if ( AV31GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV25DynamicFiltersEnabled3 = true;
                  AV28GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV31GridState.gxTpr_Dynamicfilters.Item(3));
                  AV26DynamicFiltersSelector3 = AV28GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV26DynamicFiltersSelector3, "PARAMETROMUDANZATIPO") == 0 )
                  {
                     AV27ParametroMudanzaTipo3 = AV28GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV27ParametroMudanzaTipo3)) )
                     {
                        AV14CellRow = (int)(AV14CellRow+1);
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Bold = 1;
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Color = 3;
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = context.GetMessage( "Mudanza Tipo", "");
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Italic = 1;
                        if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV27ParametroMudanzaTipo3)) )
                        {
                           AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = context.GetMessage( gxdomaintipomudanza.getDescription(context,AV27ParametroMudanzaTipo3), "");
                        }
                     }
                  }
               }
            }
         }
         if ( ! ( (0==AV44TFParametroMudanzaId) && (0==AV45TFParametroMudanzaId_To) ) )
         {
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Mudanza Id", "")) ;
            AV14CellRow = GXt_int3;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Number = AV44TFParametroMudanzaId;
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  false, ref  GXt_int3,  (short)(AV15FirstColumn+2),  context.GetMessage( "WWP_TSTo", "")) ;
            AV14CellRow = GXt_int3;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+3, 1, 1).Number = AV45TFParametroMudanzaId_To;
         }
         if ( ! ( ( AV48TFParametroMudanzaTipo_Sels.Count == 0 ) ) )
         {
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Tipo", "")) ;
            AV14CellRow = GXt_int3;
            AV56i = 1;
            AV65GXV1 = 1;
            while ( AV65GXV1 <= AV48TFParametroMudanzaTipo_Sels.Count )
            {
               AV47TFParametroMudanzaTipo_Sel = ((string)AV48TFParametroMudanzaTipo_Sels.Item(AV65GXV1));
               if ( AV56i == 1 )
               {
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = "";
               }
               else
               {
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text+", ";
               }
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text+context.GetMessage( gxdomaintipomudanza.getDescription(context,AV47TFParametroMudanzaTipo_Sel), "");
               AV56i = (long)(AV56i+1);
               AV65GXV1 = (int)(AV65GXV1+1);
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV62TFParametroMudanzaTitulo_Sel)) ) )
         {
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Título", "")) ;
            AV14CellRow = GXt_int3;
            GXt_char2 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV62TFParametroMudanzaTitulo_Sel)) ? context.GetMessage( "WWP_TitleFilter_EmptyOption", "") : AV62TFParametroMudanzaTitulo_Sel), out  GXt_char2) ;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV61TFParametroMudanzaTitulo)) ) )
            {
               GXt_int3 = (short)(AV14CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Título", "")) ;
               AV14CellRow = GXt_int3;
               GXt_char2 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV61TFParametroMudanzaTitulo, out  GXt_char2) ;
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV50TFParametroMudanzaNombre_Sel)) ) )
         {
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Nombre", "")) ;
            AV14CellRow = GXt_int3;
            GXt_char2 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV50TFParametroMudanzaNombre_Sel)) ? context.GetMessage( "WWP_TitleFilter_EmptyOption", "") : AV50TFParametroMudanzaNombre_Sel), out  GXt_char2) ;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV49TFParametroMudanzaNombre)) ) )
            {
               GXt_int3 = (short)(AV14CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Nombre", "")) ;
               AV14CellRow = GXt_int3;
               GXt_char2 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV49TFParametroMudanzaNombre, out  GXt_char2) ;
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV58TFParametroMudanzaDescripcion_Sel)) ) )
         {
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Información", "")) ;
            AV14CellRow = GXt_int3;
            GXt_char2 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV58TFParametroMudanzaDescripcion_Sel)) ? context.GetMessage( "WWP_TitleFilter_EmptyOption", "") : AV58TFParametroMudanzaDescripcion_Sel), out  GXt_char2) ;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV57TFParametroMudanzaDescripcion)) ) )
            {
               GXt_int3 = (short)(AV14CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Información", "")) ;
               AV14CellRow = GXt_int3;
               GXt_char2 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV57TFParametroMudanzaDescripcion, out  GXt_char2) ;
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
            }
         }
         if ( ! ( (Convert.ToDecimal(0)==AV51TFParametroMudanzaValor) && (Convert.ToDecimal(0)==AV52TFParametroMudanzaValor_To) ) )
         {
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Valor", "")) ;
            AV14CellRow = GXt_int3;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Number = (double)(AV51TFParametroMudanzaValor);
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  false, ref  GXt_int3,  (short)(AV15FirstColumn+2),  context.GetMessage( "WWP_TSTo", "")) ;
            AV14CellRow = GXt_int3;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+3, 1, 1).Number = (double)(AV52TFParametroMudanzaValor_To);
         }
         if ( ! ( ( AV55TFParametroMudanzaUnidad_Sels.Count == 0 ) ) )
         {
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Unidad", "")) ;
            AV14CellRow = GXt_int3;
            AV56i = 1;
            AV66GXV2 = 1;
            while ( AV66GXV2 <= AV55TFParametroMudanzaUnidad_Sels.Count )
            {
               AV54TFParametroMudanzaUnidad_Sel = AV55TFParametroMudanzaUnidad_Sels.GetString(AV66GXV2);
               if ( AV56i == 1 )
               {
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = "";
               }
               else
               {
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text+", ";
               }
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text+context.GetMessage( gxdomainunidadmedida.getDescription(context,AV54TFParametroMudanzaUnidad_Sel), "");
               AV56i = (long)(AV56i+1);
               AV66GXV2 = (int)(AV66GXV2+1);
            }
         }
         if ( ! ( (0==AV59TFParametroMudanzaPisoElev) && (0==AV60TFParametroMudanzaPisoElev_To) ) )
         {
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Piso (elevación)", "")) ;
            AV14CellRow = GXt_int3;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Number = AV59TFParametroMudanzaPisoElev;
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  false, ref  GXt_int3,  (short)(AV15FirstColumn+2),  context.GetMessage( "WWP_TSTo", "")) ;
            AV14CellRow = GXt_int3;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+3, 1, 1).Number = AV60TFParametroMudanzaPisoElev_To;
         }
         if ( ! ( (0==AV63TFParametroMudanzaActivo_Sel) ) )
         {
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Mudanza Activo", "")) ;
            AV14CellRow = GXt_int3;
            if ( AV63TFParametroMudanzaActivo_Sel == 1 )
            {
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = context.GetMessage( "WWP_TSChecked", "");
            }
            else if ( AV63TFParametroMudanzaActivo_Sel == 2 )
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
         AV41VisibleColumnCount = 0;
         if ( StringUtil.StrCmp(AV29Session.Get("ParametroMudanzaWWColumnsSelector"), "") != 0 )
         {
            AV36ColumnsSelectorXML = AV29Session.Get("ParametroMudanzaWWColumnsSelector");
            AV33ColumnsSelector.FromXml(AV36ColumnsSelectorXML, null, "", "");
         }
         else
         {
            /* Execute user subroutine: 'INITIALIZECOLUMNSSELECTOR' */
            S151 ();
            if (returnInSub) return;
         }
         AV33ColumnsSelector.gxTpr_Columns.Sort("Order");
         AV67GXV3 = 1;
         while ( AV67GXV3 <= AV33ColumnsSelector.gxTpr_Columns.Count )
         {
            AV35ColumnsSelector_Column = ((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV33ColumnsSelector.gxTpr_Columns.Item(AV67GXV3));
            if ( AV35ColumnsSelector_Column.gxTpr_Isvisible )
            {
               AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV41VisibleColumnCount), 1, 1).Text = context.GetMessage( (String.IsNullOrEmpty(StringUtil.RTrim( AV35ColumnsSelector_Column.gxTpr_Displayname)) ? AV35ColumnsSelector_Column.gxTpr_Columnname : AV35ColumnsSelector_Column.gxTpr_Displayname), "");
               AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV41VisibleColumnCount), 1, 1).Bold = 1;
               AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV41VisibleColumnCount), 1, 1).Color = 11;
               AV41VisibleColumnCount = (long)(AV41VisibleColumnCount+1);
            }
            AV67GXV3 = (int)(AV67GXV3+1);
         }
      }

      protected void S161( )
      {
         /* 'WRITEDATA' Routine */
         returnInSub = false;
         AV69Parametromudanzawwds_1_filterfulltext = AV19FilterFullText;
         AV70Parametromudanzawwds_2_dynamicfiltersselector1 = AV20DynamicFiltersSelector1;
         AV71Parametromudanzawwds_3_parametromudanzatipo1 = AV21ParametroMudanzaTipo1;
         AV72Parametromudanzawwds_4_dynamicfiltersenabled2 = AV22DynamicFiltersEnabled2;
         AV73Parametromudanzawwds_5_dynamicfiltersselector2 = AV23DynamicFiltersSelector2;
         AV74Parametromudanzawwds_6_parametromudanzatipo2 = AV24ParametroMudanzaTipo2;
         AV75Parametromudanzawwds_7_dynamicfiltersenabled3 = AV25DynamicFiltersEnabled3;
         AV76Parametromudanzawwds_8_dynamicfiltersselector3 = AV26DynamicFiltersSelector3;
         AV77Parametromudanzawwds_9_parametromudanzatipo3 = AV27ParametroMudanzaTipo3;
         AV78Parametromudanzawwds_10_tfparametromudanzaid = AV44TFParametroMudanzaId;
         AV79Parametromudanzawwds_11_tfparametromudanzaid_to = AV45TFParametroMudanzaId_To;
         AV80Parametromudanzawwds_12_tfparametromudanzatipo_sels = AV48TFParametroMudanzaTipo_Sels;
         AV81Parametromudanzawwds_13_tfparametromudanzatitulo = AV61TFParametroMudanzaTitulo;
         AV82Parametromudanzawwds_14_tfparametromudanzatitulo_sel = AV62TFParametroMudanzaTitulo_Sel;
         AV83Parametromudanzawwds_15_tfparametromudanzanombre = AV49TFParametroMudanzaNombre;
         AV84Parametromudanzawwds_16_tfparametromudanzanombre_sel = AV50TFParametroMudanzaNombre_Sel;
         AV85Parametromudanzawwds_17_tfparametromudanzadescripcion = AV57TFParametroMudanzaDescripcion;
         AV86Parametromudanzawwds_18_tfparametromudanzadescripcion_sel = AV58TFParametroMudanzaDescripcion_Sel;
         AV87Parametromudanzawwds_19_tfparametromudanzavalor = AV51TFParametroMudanzaValor;
         AV88Parametromudanzawwds_20_tfparametromudanzavalor_to = AV52TFParametroMudanzaValor_To;
         AV89Parametromudanzawwds_21_tfparametromudanzaunidad_sels = AV55TFParametroMudanzaUnidad_Sels;
         AV90Parametromudanzawwds_22_tfparametromudanzapisoelev = AV59TFParametroMudanzaPisoElev;
         AV91Parametromudanzawwds_23_tfparametromudanzapisoelev_to = AV60TFParametroMudanzaPisoElev_To;
         AV92Parametromudanzawwds_24_tfparametromudanzaactivo_sel = AV63TFParametroMudanzaActivo_Sel;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A731ParametroMudanzaTipo ,
                                              AV80Parametromudanzawwds_12_tfparametromudanzatipo_sels ,
                                              A734ParametroMudanzaUnidad ,
                                              AV89Parametromudanzawwds_21_tfparametromudanzaunidad_sels ,
                                              AV70Parametromudanzawwds_2_dynamicfiltersselector1 ,
                                              AV71Parametromudanzawwds_3_parametromudanzatipo1 ,
                                              AV72Parametromudanzawwds_4_dynamicfiltersenabled2 ,
                                              AV73Parametromudanzawwds_5_dynamicfiltersselector2 ,
                                              AV74Parametromudanzawwds_6_parametromudanzatipo2 ,
                                              AV75Parametromudanzawwds_7_dynamicfiltersenabled3 ,
                                              AV76Parametromudanzawwds_8_dynamicfiltersselector3 ,
                                              AV77Parametromudanzawwds_9_parametromudanzatipo3 ,
                                              AV78Parametromudanzawwds_10_tfparametromudanzaid ,
                                              AV79Parametromudanzawwds_11_tfparametromudanzaid_to ,
                                              AV80Parametromudanzawwds_12_tfparametromudanzatipo_sels.Count ,
                                              AV82Parametromudanzawwds_14_tfparametromudanzatitulo_sel ,
                                              AV81Parametromudanzawwds_13_tfparametromudanzatitulo ,
                                              AV84Parametromudanzawwds_16_tfparametromudanzanombre_sel ,
                                              AV83Parametromudanzawwds_15_tfparametromudanzanombre ,
                                              AV86Parametromudanzawwds_18_tfparametromudanzadescripcion_sel ,
                                              AV85Parametromudanzawwds_17_tfparametromudanzadescripcion ,
                                              AV87Parametromudanzawwds_19_tfparametromudanzavalor ,
                                              AV88Parametromudanzawwds_20_tfparametromudanzavalor_to ,
                                              AV89Parametromudanzawwds_21_tfparametromudanzaunidad_sels.Count ,
                                              AV90Parametromudanzawwds_22_tfparametromudanzapisoelev ,
                                              AV91Parametromudanzawwds_23_tfparametromudanzapisoelev_to ,
                                              AV92Parametromudanzawwds_24_tfparametromudanzaactivo_sel ,
                                              A730ParametroMudanzaId ,
                                              A869ParametroMudanzaTitulo ,
                                              A732ParametroMudanzaNombre ,
                                              A812ParametroMudanzaDescripcion ,
                                              A733ParametroMudanzaValor ,
                                              A818ParametroMudanzaPisoElev ,
                                              A877ParametroMudanzaActivo ,
                                              AV17OrderedBy ,
                                              AV18OrderedDsc ,
                                              AV69Parametromudanzawwds_1_filterfulltext } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.INT, TypeConstants.SHORT, TypeConstants.SHORT,
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.DECIMAL, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV81Parametromudanzawwds_13_tfparametromudanzatitulo = StringUtil.Concat( StringUtil.RTrim( AV81Parametromudanzawwds_13_tfparametromudanzatitulo), "%", "");
         lV83Parametromudanzawwds_15_tfparametromudanzanombre = StringUtil.Concat( StringUtil.RTrim( AV83Parametromudanzawwds_15_tfparametromudanzanombre), "%", "");
         lV85Parametromudanzawwds_17_tfparametromudanzadescripcion = StringUtil.Concat( StringUtil.RTrim( AV85Parametromudanzawwds_17_tfparametromudanzadescripcion), "%", "");
         /* Using cursor P00EV2 */
         pr_default.execute(0, new Object[] {AV71Parametromudanzawwds_3_parametromudanzatipo1, AV74Parametromudanzawwds_6_parametromudanzatipo2, AV77Parametromudanzawwds_9_parametromudanzatipo3, AV78Parametromudanzawwds_10_tfparametromudanzaid, AV79Parametromudanzawwds_11_tfparametromudanzaid_to, lV81Parametromudanzawwds_13_tfparametromudanzatitulo, AV82Parametromudanzawwds_14_tfparametromudanzatitulo_sel, lV83Parametromudanzawwds_15_tfparametromudanzanombre, AV84Parametromudanzawwds_16_tfparametromudanzanombre_sel, lV85Parametromudanzawwds_17_tfparametromudanzadescripcion, AV86Parametromudanzawwds_18_tfparametromudanzadescripcion_sel, AV87Parametromudanzawwds_19_tfparametromudanzavalor, AV88Parametromudanzawwds_20_tfparametromudanzavalor_to, AV90Parametromudanzawwds_22_tfparametromudanzapisoelev, AV91Parametromudanzawwds_23_tfparametromudanzapisoelev_to});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A877ParametroMudanzaActivo = P00EV2_A877ParametroMudanzaActivo[0];
            A818ParametroMudanzaPisoElev = P00EV2_A818ParametroMudanzaPisoElev[0];
            A733ParametroMudanzaValor = P00EV2_A733ParametroMudanzaValor[0];
            A812ParametroMudanzaDescripcion = P00EV2_A812ParametroMudanzaDescripcion[0];
            A732ParametroMudanzaNombre = P00EV2_A732ParametroMudanzaNombre[0];
            A869ParametroMudanzaTitulo = P00EV2_A869ParametroMudanzaTitulo[0];
            A730ParametroMudanzaId = P00EV2_A730ParametroMudanzaId[0];
            A734ParametroMudanzaUnidad = P00EV2_A734ParametroMudanzaUnidad[0];
            A731ParametroMudanzaTipo = P00EV2_A731ParametroMudanzaTipo[0];
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV69Parametromudanzawwds_1_filterfulltext)) || ( ( StringUtil.Like( StringUtil.Str( (decimal)(A730ParametroMudanzaId), 4, 0) , StringUtil.PadR( "%" + AV69Parametromudanzawwds_1_filterfulltext , 254 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( context.GetMessage( "tipo inmueble casa", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV69Parametromudanzawwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A731ParametroMudanzaTipo, "TipoInmuebleCasa") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "tipo estacionamiento", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV69Parametromudanzawwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A731ParametroMudanzaTipo, "TipoEstacionamiento") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "tipo vehiculo", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV69Parametromudanzawwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A731ParametroMudanzaTipo, "TipoVehiculo") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "electro hogar", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV69Parametromudanzawwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A731ParametroMudanzaTipo, "ItemCargaHogar") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "item adicional", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV69Parametromudanzawwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A731ParametroMudanzaTipo, "ItemAdicional") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "peaje", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV69Parametromudanzawwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A731ParametroMudanzaTipo, "Peaje") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "tipo inmueble apto", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV69Parametromudanzawwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A731ParametroMudanzaTipo, "TipoInmuebleApto") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "mobiliario", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV69Parametromudanzawwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A731ParametroMudanzaTipo, "ItemCargaMobiliario") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "exterior y jardín", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV69Parametromudanzawwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A731ParametroMudanzaTipo, "ItemCargaExterior") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "decoración", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV69Parametromudanzawwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A731ParametroMudanzaTipo, "ItemCargaDecoracion") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "otros", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV69Parametromudanzawwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A731ParametroMudanzaTipo, "ItemCargaOtros") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "escalera", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV69Parametromudanzawwds_1_filterfulltext) , 255 , "%"),  ' ' ) &&
            ( StringUtil.StrCmp(A731ParametroMudanzaTipo, "Escalera") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "ascensor", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV69Parametromudanzawwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A731ParametroMudanzaTipo, "Ascensor") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "esca+asce", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV69Parametromudanzawwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A731ParametroMudanzaTipo, "EscaAsce") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "precio embalaje", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV69Parametromudanzawwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A731ParametroMudanzaTipo, "PrecioEmbalaje") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "precio elevacion", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV69Parametromudanzawwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A731ParametroMudanzaTipo, "PrecioElevacion") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "precio base", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV69Parametromudanzawwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A731ParametroMudanzaTipo, "PrecioBase") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "tiempox km", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV69Parametromudanzawwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A731ParametroMudanzaTipo, "TiempoxKm") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "tiempox m3", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV69Parametromudanzawwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A731ParametroMudanzaTipo, "TiempoxM3") == 0 ) ) ||
            ( StringUtil.Like( StringUtil.Upper( A869ParametroMudanzaTitulo) , StringUtil.PadR( "%" + StringUtil.Upper( AV69Parametromudanzawwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A732ParametroMudanzaNombre) , StringUtil.PadR( "%" + StringUtil.Upper( AV69Parametromudanzawwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Upper( A812ParametroMudanzaDescripcion) , StringUtil.PadR( "%" + StringUtil.Upper( AV69Parametromudanzawwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Str( A733ParametroMudanzaValor, 18, 2) , StringUtil.PadR( "%" + AV69Parametromudanzawwds_1_filterfulltext , 254 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( context.GetMessage( "m3", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV69Parametromudanzawwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A734ParametroMudanzaUnidad, "m3") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "pesos", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV69Parametromudanzawwds_1_filterfulltext) , 255 , "%"),  ' ' ) &&
            ( StringUtil.StrCmp(A734ParametroMudanzaUnidad, "$") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "unidades", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV69Parametromudanzawwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A734ParametroMudanzaUnidad, "u") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "minutos", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV69Parametromudanzawwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A734ParametroMudanzaUnidad, "mi") == 0 ) ) || ( StringUtil.Like( "%" , StringUtil.PadR( "%" + StringUtil.Lower( AV69Parametromudanzawwds_1_filterfulltext) , 255 , "%"),  ' ' ) &&
            ( StringUtil.StrCmp(A734ParametroMudanzaUnidad, "%") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "min/m3", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV69Parametromudanzawwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A734ParametroMudanzaUnidad, "mm") == 0 ) ) || ( StringUtil.Like( StringUtil.Str( (decimal)(A818ParametroMudanzaPisoElev), 4, 0) , StringUtil.PadR( "%" + AV69Parametromudanzawwds_1_filterfulltext , 254 , "%"),  ' ' ) ) )
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
               AV41VisibleColumnCount = 0;
               AV93GXV4 = 1;
               while ( AV93GXV4 <= AV33ColumnsSelector.gxTpr_Columns.Count )
               {
                  AV35ColumnsSelector_Column = ((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV33ColumnsSelector.gxTpr_Columns.Item(AV93GXV4));
                  if ( AV35ColumnsSelector_Column.gxTpr_Isvisible )
                  {
                     if ( StringUtil.StrCmp(AV35ColumnsSelector_Column.gxTpr_Columnname, "ParametroMudanzaId") == 0 )
                     {
                        AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV41VisibleColumnCount), 1, 1).Number = A730ParametroMudanzaId;
                     }
                     else if ( StringUtil.StrCmp(AV35ColumnsSelector_Column.gxTpr_Columnname, "ParametroMudanzaTipo") == 0 )
                     {
                        AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV41VisibleColumnCount), 1, 1).Text = context.GetMessage( gxdomaintipomudanza.getDescription(context,A731ParametroMudanzaTipo), "");
                     }
                     else if ( StringUtil.StrCmp(AV35ColumnsSelector_Column.gxTpr_Columnname, "ParametroMudanzaTitulo") == 0 )
                     {
                        GXt_char2 = "";
                        new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A869ParametroMudanzaTitulo, out  GXt_char2) ;
                        AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV41VisibleColumnCount), 1, 1).Text = GXt_char2;
                     }
                     else if ( StringUtil.StrCmp(AV35ColumnsSelector_Column.gxTpr_Columnname, "ParametroMudanzaNombre") == 0 )
                     {
                        GXt_char2 = "";
                        new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A732ParametroMudanzaNombre, out  GXt_char2) ;
                        AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV41VisibleColumnCount), 1, 1).Text = GXt_char2;
                     }
                     else if ( StringUtil.StrCmp(AV35ColumnsSelector_Column.gxTpr_Columnname, "ParametroMudanzaDescripcion") == 0 )
                     {
                        GXt_char2 = "";
                        new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A812ParametroMudanzaDescripcion, out  GXt_char2) ;
                        AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV41VisibleColumnCount), 1, 1).Text = GXt_char2;
                     }
                     else if ( StringUtil.StrCmp(AV35ColumnsSelector_Column.gxTpr_Columnname, "ParametroMudanzaValor") == 0 )
                     {
                        AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV41VisibleColumnCount), 1, 1).Number = (double)(A733ParametroMudanzaValor);
                     }
                     else if ( StringUtil.StrCmp(AV35ColumnsSelector_Column.gxTpr_Columnname, "ParametroMudanzaUnidad") == 0 )
                     {
                        AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV41VisibleColumnCount), 1, 1).Text = context.GetMessage( gxdomainunidadmedida.getDescription(context,A734ParametroMudanzaUnidad), "");
                     }
                     else if ( StringUtil.StrCmp(AV35ColumnsSelector_Column.gxTpr_Columnname, "ParametroMudanzaPisoElev") == 0 )
                     {
                        AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV41VisibleColumnCount), 1, 1).Number = A818ParametroMudanzaPisoElev;
                     }
                     else if ( StringUtil.StrCmp(AV35ColumnsSelector_Column.gxTpr_Columnname, "ParametroMudanzaImagen") == 0 )
                     {
                        AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV41VisibleColumnCount), 1, 1).Text = "";
                     }
                     else if ( StringUtil.StrCmp(AV35ColumnsSelector_Column.gxTpr_Columnname, "ParametroMudanzaActivo") == 0 )
                     {
                        AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV41VisibleColumnCount), 1, 1).Text = StringUtil.BoolToStr( A877ParametroMudanzaActivo);
                     }
                     AV41VisibleColumnCount = (long)(AV41VisibleColumnCount+1);
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
         AV29Session.Set("WWPExportFilePath", AV12Filename);
         AV29Session.Set("WWPExportFileName", "ParametroMudanzaWWExport.xlsx");
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
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV33ColumnsSelector,  "ParametroMudanzaId",  "",  "Mudanza Id",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV33ColumnsSelector,  "ParametroMudanzaTipo",  "",  "Tipo",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV33ColumnsSelector,  "ParametroMudanzaTitulo",  "",  "Título",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV33ColumnsSelector,  "ParametroMudanzaNombre",  "",  "Nombre",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV33ColumnsSelector,  "ParametroMudanzaDescripcion",  "",  "Información",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV33ColumnsSelector,  "ParametroMudanzaValor",  "",  "Valor",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV33ColumnsSelector,  "ParametroMudanzaUnidad",  "",  "Unidad",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV33ColumnsSelector,  "ParametroMudanzaPisoElev",  "",  "Piso (elevación)",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV33ColumnsSelector,  "ParametroMudanzaImagen",  "",  "Mudanza Imagen",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV33ColumnsSelector,  "ParametroMudanzaActivo",  "",  "Mudanza Activo",  true,  "") ;
         GXt_char2 = AV37UserCustomValue;
         new GeneXus.Programs.wwpbaseobjects.loadcolumnsselectorstate(context ).execute(  "ParametroMudanzaWWColumnsSelector", out  GXt_char2) ;
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
         if ( StringUtil.StrCmp(AV29Session.Get("ParametroMudanzaWWGridState"), "") == 0 )
         {
            AV31GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "ParametroMudanzaWWGridState"), null, "", "");
         }
         else
         {
            AV31GridState.FromXml(AV29Session.Get("ParametroMudanzaWWGridState"), null, "", "");
         }
         AV17OrderedBy = AV31GridState.gxTpr_Orderedby;
         AV18OrderedDsc = AV31GridState.gxTpr_Ordereddsc;
         AV94GXV5 = 1;
         while ( AV94GXV5 <= AV31GridState.gxTpr_Filtervalues.Count )
         {
            AV32GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV31GridState.gxTpr_Filtervalues.Item(AV94GXV5));
            if ( StringUtil.StrCmp(AV32GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV19FilterFullText = AV32GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV32GridStateFilterValue.gxTpr_Name, "TFPARAMETROMUDANZAID") == 0 )
            {
               AV44TFParametroMudanzaId = (short)(Math.Round(NumberUtil.Val( AV32GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV45TFParametroMudanzaId_To = (short)(Math.Round(NumberUtil.Val( AV32GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV32GridStateFilterValue.gxTpr_Name, "TFPARAMETROMUDANZATIPO_SEL") == 0 )
            {
               AV46TFParametroMudanzaTipo_SelsJson = AV32GridStateFilterValue.gxTpr_Value;
               AV48TFParametroMudanzaTipo_Sels.FromJSonString(AV46TFParametroMudanzaTipo_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV32GridStateFilterValue.gxTpr_Name, "TFPARAMETROMUDANZATITULO") == 0 )
            {
               AV61TFParametroMudanzaTitulo = AV32GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV32GridStateFilterValue.gxTpr_Name, "TFPARAMETROMUDANZATITULO_SEL") == 0 )
            {
               AV62TFParametroMudanzaTitulo_Sel = AV32GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV32GridStateFilterValue.gxTpr_Name, "TFPARAMETROMUDANZANOMBRE") == 0 )
            {
               AV49TFParametroMudanzaNombre = AV32GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV32GridStateFilterValue.gxTpr_Name, "TFPARAMETROMUDANZANOMBRE_SEL") == 0 )
            {
               AV50TFParametroMudanzaNombre_Sel = AV32GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV32GridStateFilterValue.gxTpr_Name, "TFPARAMETROMUDANZADESCRIPCION") == 0 )
            {
               AV57TFParametroMudanzaDescripcion = AV32GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV32GridStateFilterValue.gxTpr_Name, "TFPARAMETROMUDANZADESCRIPCION_SEL") == 0 )
            {
               AV58TFParametroMudanzaDescripcion_Sel = AV32GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV32GridStateFilterValue.gxTpr_Name, "TFPARAMETROMUDANZAVALOR") == 0 )
            {
               AV51TFParametroMudanzaValor = NumberUtil.Val( AV32GridStateFilterValue.gxTpr_Value, ".");
               AV52TFParametroMudanzaValor_To = NumberUtil.Val( AV32GridStateFilterValue.gxTpr_Valueto, ".");
            }
            else if ( StringUtil.StrCmp(AV32GridStateFilterValue.gxTpr_Name, "TFPARAMETROMUDANZAUNIDAD_SEL") == 0 )
            {
               AV53TFParametroMudanzaUnidad_SelsJson = AV32GridStateFilterValue.gxTpr_Value;
               AV55TFParametroMudanzaUnidad_Sels.FromJSonString(AV53TFParametroMudanzaUnidad_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV32GridStateFilterValue.gxTpr_Name, "TFPARAMETROMUDANZAPISOELEV") == 0 )
            {
               AV59TFParametroMudanzaPisoElev = (short)(Math.Round(NumberUtil.Val( AV32GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV60TFParametroMudanzaPisoElev_To = (short)(Math.Round(NumberUtil.Val( AV32GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV32GridStateFilterValue.gxTpr_Name, "TFPARAMETROMUDANZAACTIVO_SEL") == 0 )
            {
               AV63TFParametroMudanzaActivo_Sel = (short)(Math.Round(NumberUtil.Val( AV32GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
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
         AV64Pgmname = "";
         GXKey = "";
         GXEncryptionTmp = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV11ExcelDocument = new ExcelDocumentI();
         AV19FilterFullText = "";
         AV31GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV28GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV20DynamicFiltersSelector1 = "";
         AV21ParametroMudanzaTipo1 = "";
         AV23DynamicFiltersSelector2 = "";
         AV24ParametroMudanzaTipo2 = "";
         AV26DynamicFiltersSelector3 = "";
         AV27ParametroMudanzaTipo3 = "";
         AV48TFParametroMudanzaTipo_Sels = new GxSimpleCollection<string>();
         AV47TFParametroMudanzaTipo_Sel = "";
         AV62TFParametroMudanzaTitulo_Sel = "";
         AV61TFParametroMudanzaTitulo = "";
         AV50TFParametroMudanzaNombre_Sel = "";
         AV49TFParametroMudanzaNombre = "";
         AV58TFParametroMudanzaDescripcion_Sel = "";
         AV57TFParametroMudanzaDescripcion = "";
         AV55TFParametroMudanzaUnidad_Sels = new GxSimpleCollection<string>();
         AV54TFParametroMudanzaUnidad_Sel = "";
         AV29Session = context.GetSession();
         AV36ColumnsSelectorXML = "";
         AV33ColumnsSelector = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector(context);
         AV35ColumnsSelector_Column = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column(context);
         AV69Parametromudanzawwds_1_filterfulltext = "";
         AV70Parametromudanzawwds_2_dynamicfiltersselector1 = "";
         AV71Parametromudanzawwds_3_parametromudanzatipo1 = "";
         AV73Parametromudanzawwds_5_dynamicfiltersselector2 = "";
         AV74Parametromudanzawwds_6_parametromudanzatipo2 = "";
         AV76Parametromudanzawwds_8_dynamicfiltersselector3 = "";
         AV77Parametromudanzawwds_9_parametromudanzatipo3 = "";
         AV80Parametromudanzawwds_12_tfparametromudanzatipo_sels = new GxSimpleCollection<string>();
         AV81Parametromudanzawwds_13_tfparametromudanzatitulo = "";
         AV82Parametromudanzawwds_14_tfparametromudanzatitulo_sel = "";
         AV83Parametromudanzawwds_15_tfparametromudanzanombre = "";
         AV84Parametromudanzawwds_16_tfparametromudanzanombre_sel = "";
         AV85Parametromudanzawwds_17_tfparametromudanzadescripcion = "";
         AV86Parametromudanzawwds_18_tfparametromudanzadescripcion_sel = "";
         AV89Parametromudanzawwds_21_tfparametromudanzaunidad_sels = new GxSimpleCollection<string>();
         lV69Parametromudanzawwds_1_filterfulltext = "";
         lV81Parametromudanzawwds_13_tfparametromudanzatitulo = "";
         lV83Parametromudanzawwds_15_tfparametromudanzanombre = "";
         lV85Parametromudanzawwds_17_tfparametromudanzadescripcion = "";
         A731ParametroMudanzaTipo = "";
         A734ParametroMudanzaUnidad = "";
         A869ParametroMudanzaTitulo = "";
         A732ParametroMudanzaNombre = "";
         A812ParametroMudanzaDescripcion = "";
         P00EV2_A877ParametroMudanzaActivo = new bool[] {false} ;
         P00EV2_A818ParametroMudanzaPisoElev = new short[1] ;
         P00EV2_A733ParametroMudanzaValor = new decimal[1] ;
         P00EV2_A812ParametroMudanzaDescripcion = new string[] {""} ;
         P00EV2_A732ParametroMudanzaNombre = new string[] {""} ;
         P00EV2_A869ParametroMudanzaTitulo = new string[] {""} ;
         P00EV2_A730ParametroMudanzaId = new short[1] ;
         P00EV2_A734ParametroMudanzaUnidad = new string[] {""} ;
         P00EV2_A731ParametroMudanzaTipo = new string[] {""} ;
         AV37UserCustomValue = "";
         GXt_char2 = "";
         AV34ColumnsSelectorAux = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector(context);
         AV32GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV46TFParametroMudanzaTipo_SelsJson = "";
         AV53TFParametroMudanzaUnidad_SelsJson = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.parametromudanzawwexport__default(),
            new Object[][] {
                new Object[] {
               P00EV2_A877ParametroMudanzaActivo, P00EV2_A818ParametroMudanzaPisoElev, P00EV2_A733ParametroMudanzaValor, P00EV2_A812ParametroMudanzaDescripcion, P00EV2_A732ParametroMudanzaNombre, P00EV2_A869ParametroMudanzaTitulo, P00EV2_A730ParametroMudanzaId, P00EV2_A734ParametroMudanzaUnidad, P00EV2_A731ParametroMudanzaTipo
               }
            }
         );
         AV64Pgmname = "ParametroMudanzaWWExport";
         /* GeneXus formulas. */
         AV64Pgmname = "ParametroMudanzaWWExport";
      }

      private short AV44TFParametroMudanzaId ;
      private short AV45TFParametroMudanzaId_To ;
      private short AV59TFParametroMudanzaPisoElev ;
      private short AV60TFParametroMudanzaPisoElev_To ;
      private short AV63TFParametroMudanzaActivo_Sel ;
      private short GXt_int3 ;
      private short AV78Parametromudanzawwds_10_tfparametromudanzaid ;
      private short AV79Parametromudanzawwds_11_tfparametromudanzaid_to ;
      private short AV90Parametromudanzawwds_22_tfparametromudanzapisoelev ;
      private short AV91Parametromudanzawwds_23_tfparametromudanzapisoelev_to ;
      private short AV92Parametromudanzawwds_24_tfparametromudanzaactivo_sel ;
      private short A730ParametroMudanzaId ;
      private short A818ParametroMudanzaPisoElev ;
      private short AV17OrderedBy ;
      private int AV14CellRow ;
      private int AV15FirstColumn ;
      private int AV16Random ;
      private int AV65GXV1 ;
      private int AV66GXV2 ;
      private int AV67GXV3 ;
      private int AV80Parametromudanzawwds_12_tfparametromudanzatipo_sels_Count ;
      private int AV89Parametromudanzawwds_21_tfparametromudanzaunidad_sels_Count ;
      private int AV93GXV4 ;
      private int AV94GXV5 ;
      private long AV56i ;
      private long AV41VisibleColumnCount ;
      private decimal AV51TFParametroMudanzaValor ;
      private decimal AV52TFParametroMudanzaValor_To ;
      private decimal AV87Parametromudanzawwds_19_tfparametromudanzavalor ;
      private decimal AV88Parametromudanzawwds_20_tfparametromudanzavalor_to ;
      private decimal A733ParametroMudanzaValor ;
      private string AV64Pgmname ;
      private string GXKey ;
      private string GXEncryptionTmp ;
      private string AV54TFParametroMudanzaUnidad_Sel ;
      private string A734ParametroMudanzaUnidad ;
      private string GXt_char2 ;
      private bool AV8IsAuthorized ;
      private bool GXt_boolean1 ;
      private bool returnInSub ;
      private bool AV22DynamicFiltersEnabled2 ;
      private bool AV25DynamicFiltersEnabled3 ;
      private bool AV72Parametromudanzawwds_4_dynamicfiltersenabled2 ;
      private bool AV75Parametromudanzawwds_7_dynamicfiltersenabled3 ;
      private bool A877ParametroMudanzaActivo ;
      private bool AV18OrderedDsc ;
      private string AV36ColumnsSelectorXML ;
      private string AV37UserCustomValue ;
      private string AV46TFParametroMudanzaTipo_SelsJson ;
      private string AV53TFParametroMudanzaUnidad_SelsJson ;
      private string AV12Filename ;
      private string AV13ErrorMessage ;
      private string AV19FilterFullText ;
      private string AV20DynamicFiltersSelector1 ;
      private string AV21ParametroMudanzaTipo1 ;
      private string AV23DynamicFiltersSelector2 ;
      private string AV24ParametroMudanzaTipo2 ;
      private string AV26DynamicFiltersSelector3 ;
      private string AV27ParametroMudanzaTipo3 ;
      private string AV47TFParametroMudanzaTipo_Sel ;
      private string AV62TFParametroMudanzaTitulo_Sel ;
      private string AV61TFParametroMudanzaTitulo ;
      private string AV50TFParametroMudanzaNombre_Sel ;
      private string AV49TFParametroMudanzaNombre ;
      private string AV58TFParametroMudanzaDescripcion_Sel ;
      private string AV57TFParametroMudanzaDescripcion ;
      private string AV69Parametromudanzawwds_1_filterfulltext ;
      private string AV70Parametromudanzawwds_2_dynamicfiltersselector1 ;
      private string AV71Parametromudanzawwds_3_parametromudanzatipo1 ;
      private string AV73Parametromudanzawwds_5_dynamicfiltersselector2 ;
      private string AV74Parametromudanzawwds_6_parametromudanzatipo2 ;
      private string AV76Parametromudanzawwds_8_dynamicfiltersselector3 ;
      private string AV77Parametromudanzawwds_9_parametromudanzatipo3 ;
      private string AV81Parametromudanzawwds_13_tfparametromudanzatitulo ;
      private string AV82Parametromudanzawwds_14_tfparametromudanzatitulo_sel ;
      private string AV83Parametromudanzawwds_15_tfparametromudanzanombre ;
      private string AV84Parametromudanzawwds_16_tfparametromudanzanombre_sel ;
      private string AV85Parametromudanzawwds_17_tfparametromudanzadescripcion ;
      private string AV86Parametromudanzawwds_18_tfparametromudanzadescripcion_sel ;
      private string lV69Parametromudanzawwds_1_filterfulltext ;
      private string lV81Parametromudanzawwds_13_tfparametromudanzatitulo ;
      private string lV83Parametromudanzawwds_15_tfparametromudanzanombre ;
      private string lV85Parametromudanzawwds_17_tfparametromudanzadescripcion ;
      private string A731ParametroMudanzaTipo ;
      private string A869ParametroMudanzaTitulo ;
      private string A732ParametroMudanzaNombre ;
      private string A812ParametroMudanzaDescripcion ;
      private IGxSession AV29Session ;
      private ExcelDocumentI AV11ExcelDocument ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV31GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV28GridStateDynamicFilter ;
      private GxSimpleCollection<string> AV48TFParametroMudanzaTipo_Sels ;
      private GxSimpleCollection<string> AV55TFParametroMudanzaUnidad_Sels ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector AV33ColumnsSelector ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column AV35ColumnsSelector_Column ;
      private GxSimpleCollection<string> AV80Parametromudanzawwds_12_tfparametromudanzatipo_sels ;
      private GxSimpleCollection<string> AV89Parametromudanzawwds_21_tfparametromudanzaunidad_sels ;
      private IDataStoreProvider pr_default ;
      private bool[] P00EV2_A877ParametroMudanzaActivo ;
      private short[] P00EV2_A818ParametroMudanzaPisoElev ;
      private decimal[] P00EV2_A733ParametroMudanzaValor ;
      private string[] P00EV2_A812ParametroMudanzaDescripcion ;
      private string[] P00EV2_A732ParametroMudanzaNombre ;
      private string[] P00EV2_A869ParametroMudanzaTitulo ;
      private short[] P00EV2_A730ParametroMudanzaId ;
      private string[] P00EV2_A734ParametroMudanzaUnidad ;
      private string[] P00EV2_A731ParametroMudanzaTipo ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector AV34ColumnsSelectorAux ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV32GridStateFilterValue ;
      private string aP0_Filename ;
      private string aP1_ErrorMessage ;
   }

   public class parametromudanzawwexport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00EV2( IGxContext context ,
                                             string A731ParametroMudanzaTipo ,
                                             GxSimpleCollection<string> AV80Parametromudanzawwds_12_tfparametromudanzatipo_sels ,
                                             string A734ParametroMudanzaUnidad ,
                                             GxSimpleCollection<string> AV89Parametromudanzawwds_21_tfparametromudanzaunidad_sels ,
                                             string AV70Parametromudanzawwds_2_dynamicfiltersselector1 ,
                                             string AV71Parametromudanzawwds_3_parametromudanzatipo1 ,
                                             bool AV72Parametromudanzawwds_4_dynamicfiltersenabled2 ,
                                             string AV73Parametromudanzawwds_5_dynamicfiltersselector2 ,
                                             string AV74Parametromudanzawwds_6_parametromudanzatipo2 ,
                                             bool AV75Parametromudanzawwds_7_dynamicfiltersenabled3 ,
                                             string AV76Parametromudanzawwds_8_dynamicfiltersselector3 ,
                                             string AV77Parametromudanzawwds_9_parametromudanzatipo3 ,
                                             short AV78Parametromudanzawwds_10_tfparametromudanzaid ,
                                             short AV79Parametromudanzawwds_11_tfparametromudanzaid_to ,
                                             int AV80Parametromudanzawwds_12_tfparametromudanzatipo_sels_Count ,
                                             string AV82Parametromudanzawwds_14_tfparametromudanzatitulo_sel ,
                                             string AV81Parametromudanzawwds_13_tfparametromudanzatitulo ,
                                             string AV84Parametromudanzawwds_16_tfparametromudanzanombre_sel ,
                                             string AV83Parametromudanzawwds_15_tfparametromudanzanombre ,
                                             string AV86Parametromudanzawwds_18_tfparametromudanzadescripcion_sel ,
                                             string AV85Parametromudanzawwds_17_tfparametromudanzadescripcion ,
                                             decimal AV87Parametromudanzawwds_19_tfparametromudanzavalor ,
                                             decimal AV88Parametromudanzawwds_20_tfparametromudanzavalor_to ,
                                             int AV89Parametromudanzawwds_21_tfparametromudanzaunidad_sels_Count ,
                                             short AV90Parametromudanzawwds_22_tfparametromudanzapisoelev ,
                                             short AV91Parametromudanzawwds_23_tfparametromudanzapisoelev_to ,
                                             short AV92Parametromudanzawwds_24_tfparametromudanzaactivo_sel ,
                                             short A730ParametroMudanzaId ,
                                             string A869ParametroMudanzaTitulo ,
                                             string A732ParametroMudanzaNombre ,
                                             string A812ParametroMudanzaDescripcion ,
                                             decimal A733ParametroMudanzaValor ,
                                             short A818ParametroMudanzaPisoElev ,
                                             bool A877ParametroMudanzaActivo ,
                                             short AV17OrderedBy ,
                                             bool AV18OrderedDsc ,
                                             string AV69Parametromudanzawwds_1_filterfulltext )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int4 = new short[15];
         Object[] GXv_Object5 = new Object[2];
         scmdbuf = "SELECT [ParametroMudanzaActivo], [ParametroMudanzaPisoElev], [ParametroMudanzaValor], [ParametroMudanzaDescripcion], [ParametroMudanzaNombre], [ParametroMudanzaTitulo], [ParametroMudanzaId], [ParametroMudanzaUnidad], [ParametroMudanzaTipo] FROM [ParametroMudanza]";
         if ( ( StringUtil.StrCmp(AV70Parametromudanzawwds_2_dynamicfiltersselector1, "PARAMETROMUDANZATIPO") == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Parametromudanzawwds_3_parametromudanzatipo1)) ) )
         {
            AddWhere(sWhereString, "([ParametroMudanzaTipo] = @AV71Parametromudanzawwds_3_parametromudanzatipo1)");
         }
         else
         {
            GXv_int4[0] = 1;
         }
         if ( AV72Parametromudanzawwds_4_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV73Parametromudanzawwds_5_dynamicfiltersselector2, "PARAMETROMUDANZATIPO") == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Parametromudanzawwds_6_parametromudanzatipo2)) ) )
         {
            AddWhere(sWhereString, "([ParametroMudanzaTipo] = @AV74Parametromudanzawwds_6_parametromudanzatipo2)");
         }
         else
         {
            GXv_int4[1] = 1;
         }
         if ( AV75Parametromudanzawwds_7_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV76Parametromudanzawwds_8_dynamicfiltersselector3, "PARAMETROMUDANZATIPO") == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV77Parametromudanzawwds_9_parametromudanzatipo3)) ) )
         {
            AddWhere(sWhereString, "([ParametroMudanzaTipo] = @AV77Parametromudanzawwds_9_parametromudanzatipo3)");
         }
         else
         {
            GXv_int4[2] = 1;
         }
         if ( ! (0==AV78Parametromudanzawwds_10_tfparametromudanzaid) )
         {
            AddWhere(sWhereString, "([ParametroMudanzaId] >= @AV78Parametromudanzawwds_10_tfparametromudanzaid)");
         }
         else
         {
            GXv_int4[3] = 1;
         }
         if ( ! (0==AV79Parametromudanzawwds_11_tfparametromudanzaid_to) )
         {
            AddWhere(sWhereString, "([ParametroMudanzaId] <= @AV79Parametromudanzawwds_11_tfparametromudanzaid_to)");
         }
         else
         {
            GXv_int4[4] = 1;
         }
         if ( AV80Parametromudanzawwds_12_tfparametromudanzatipo_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV80Parametromudanzawwds_12_tfparametromudanzatipo_sels, "[ParametroMudanzaTipo] IN (", ")")+")");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV82Parametromudanzawwds_14_tfparametromudanzatitulo_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV81Parametromudanzawwds_13_tfparametromudanzatitulo)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ParametroMudanzaTitulo]) like UPPER(@lV81Parametromudanzawwds_13_tfparametromudanzatitulo))");
         }
         else
         {
            GXv_int4[5] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV82Parametromudanzawwds_14_tfparametromudanzatitulo_sel)) && ! ( StringUtil.StrCmp(AV82Parametromudanzawwds_14_tfparametromudanzatitulo_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([ParametroMudanzaTitulo] = @AV82Parametromudanzawwds_14_tfparametromudanzatitulo_sel)");
         }
         else
         {
            GXv_int4[6] = 1;
         }
         if ( StringUtil.StrCmp(AV82Parametromudanzawwds_14_tfparametromudanzatitulo_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([ParametroMudanzaTitulo] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV84Parametromudanzawwds_16_tfparametromudanzanombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV83Parametromudanzawwds_15_tfparametromudanzanombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ParametroMudanzaNombre]) like UPPER(@lV83Parametromudanzawwds_15_tfparametromudanzanombre))");
         }
         else
         {
            GXv_int4[7] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV84Parametromudanzawwds_16_tfparametromudanzanombre_sel)) && ! ( StringUtil.StrCmp(AV84Parametromudanzawwds_16_tfparametromudanzanombre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([ParametroMudanzaNombre] = @AV84Parametromudanzawwds_16_tfparametromudanzanombre_sel)");
         }
         else
         {
            GXv_int4[8] = 1;
         }
         if ( StringUtil.StrCmp(AV84Parametromudanzawwds_16_tfparametromudanzanombre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([ParametroMudanzaNombre] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV86Parametromudanzawwds_18_tfparametromudanzadescripcion_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV85Parametromudanzawwds_17_tfparametromudanzadescripcion)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ParametroMudanzaDescripcion]) like UPPER(@lV85Parametromudanzawwds_17_tfparametromudanzadescripcion))");
         }
         else
         {
            GXv_int4[9] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV86Parametromudanzawwds_18_tfparametromudanzadescripcion_sel)) && ! ( StringUtil.StrCmp(AV86Parametromudanzawwds_18_tfparametromudanzadescripcion_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([ParametroMudanzaDescripcion] = @AV86Parametromudanzawwds_18_tfparametromudanzadescripcion_sel)");
         }
         else
         {
            GXv_int4[10] = 1;
         }
         if ( StringUtil.StrCmp(AV86Parametromudanzawwds_18_tfparametromudanzadescripcion_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([ParametroMudanzaDescripcion] = ''))");
         }
         if ( ! (Convert.ToDecimal(0)==AV87Parametromudanzawwds_19_tfparametromudanzavalor) )
         {
            AddWhere(sWhereString, "([ParametroMudanzaValor] >= @AV87Parametromudanzawwds_19_tfparametromudanzavalor)");
         }
         else
         {
            GXv_int4[11] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV88Parametromudanzawwds_20_tfparametromudanzavalor_to) )
         {
            AddWhere(sWhereString, "([ParametroMudanzaValor] <= @AV88Parametromudanzawwds_20_tfparametromudanzavalor_to)");
         }
         else
         {
            GXv_int4[12] = 1;
         }
         if ( AV89Parametromudanzawwds_21_tfparametromudanzaunidad_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV89Parametromudanzawwds_21_tfparametromudanzaunidad_sels, "[ParametroMudanzaUnidad] IN (", ")")+")");
         }
         if ( ! (0==AV90Parametromudanzawwds_22_tfparametromudanzapisoelev) )
         {
            AddWhere(sWhereString, "([ParametroMudanzaPisoElev] >= @AV90Parametromudanzawwds_22_tfparametromudanzapisoelev)");
         }
         else
         {
            GXv_int4[13] = 1;
         }
         if ( ! (0==AV91Parametromudanzawwds_23_tfparametromudanzapisoelev_to) )
         {
            AddWhere(sWhereString, "([ParametroMudanzaPisoElev] <= @AV91Parametromudanzawwds_23_tfparametromudanzapisoelev_to)");
         }
         else
         {
            GXv_int4[14] = 1;
         }
         if ( AV92Parametromudanzawwds_24_tfparametromudanzaactivo_sel == 1 )
         {
            AddWhere(sWhereString, "([ParametroMudanzaActivo] = 1)");
         }
         if ( AV92Parametromudanzawwds_24_tfparametromudanzaactivo_sel == 2 )
         {
            AddWhere(sWhereString, "([ParametroMudanzaActivo] = 0)");
         }
         scmdbuf += sWhereString;
         if ( ( AV17OrderedBy == 1 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY [ParametroMudanzaTipo]";
         }
         else if ( ( AV17OrderedBy == 1 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [ParametroMudanzaTipo] DESC";
         }
         else if ( ( AV17OrderedBy == 2 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY [ParametroMudanzaId]";
         }
         else if ( ( AV17OrderedBy == 2 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [ParametroMudanzaId] DESC";
         }
         else if ( ( AV17OrderedBy == 3 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY [ParametroMudanzaTitulo]";
         }
         else if ( ( AV17OrderedBy == 3 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [ParametroMudanzaTitulo] DESC";
         }
         else if ( ( AV17OrderedBy == 4 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY [ParametroMudanzaNombre]";
         }
         else if ( ( AV17OrderedBy == 4 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [ParametroMudanzaNombre] DESC";
         }
         else if ( ( AV17OrderedBy == 5 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY [ParametroMudanzaDescripcion]";
         }
         else if ( ( AV17OrderedBy == 5 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [ParametroMudanzaDescripcion] DESC";
         }
         else if ( ( AV17OrderedBy == 6 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY [ParametroMudanzaValor]";
         }
         else if ( ( AV17OrderedBy == 6 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [ParametroMudanzaValor] DESC";
         }
         else if ( ( AV17OrderedBy == 7 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY [ParametroMudanzaUnidad]";
         }
         else if ( ( AV17OrderedBy == 7 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [ParametroMudanzaUnidad] DESC";
         }
         else if ( ( AV17OrderedBy == 8 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY [ParametroMudanzaPisoElev]";
         }
         else if ( ( AV17OrderedBy == 8 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [ParametroMudanzaPisoElev] DESC";
         }
         else if ( ( AV17OrderedBy == 9 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY [ParametroMudanzaActivo]";
         }
         else if ( ( AV17OrderedBy == 9 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [ParametroMudanzaActivo] DESC";
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
                     return conditional_P00EV2(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (GxSimpleCollection<string>)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (bool)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (bool)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (short)dynConstraints[12] , (short)dynConstraints[13] , (int)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (decimal)dynConstraints[21] , (decimal)dynConstraints[22] , (int)dynConstraints[23] , (short)dynConstraints[24] , (short)dynConstraints[25] , (short)dynConstraints[26] , (short)dynConstraints[27] , (string)dynConstraints[28] , (string)dynConstraints[29] , (string)dynConstraints[30] , (decimal)dynConstraints[31] , (short)dynConstraints[32] , (bool)dynConstraints[33] , (short)dynConstraints[34] , (bool)dynConstraints[35] , (string)dynConstraints[36] );
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
          Object[] prmP00EV2;
          prmP00EV2 = new Object[] {
          new ParDef("@AV71Parametromudanzawwds_3_parametromudanzatipo1",GXType.NVarChar,20,0) ,
          new ParDef("@AV74Parametromudanzawwds_6_parametromudanzatipo2",GXType.NVarChar,20,0) ,
          new ParDef("@AV77Parametromudanzawwds_9_parametromudanzatipo3",GXType.NVarChar,20,0) ,
          new ParDef("@AV78Parametromudanzawwds_10_tfparametromudanzaid",GXType.Int16,4,0) ,
          new ParDef("@AV79Parametromudanzawwds_11_tfparametromudanzaid_to",GXType.Int16,4,0) ,
          new ParDef("@lV81Parametromudanzawwds_13_tfparametromudanzatitulo",GXType.VarChar,80,0) ,
          new ParDef("@AV82Parametromudanzawwds_14_tfparametromudanzatitulo_sel",GXType.NVarChar,80,0) ,
          new ParDef("@lV83Parametromudanzawwds_15_tfparametromudanzanombre",GXType.VarChar,100,0) ,
          new ParDef("@AV84Parametromudanzawwds_16_tfparametromudanzanombre_sel",GXType.NVarChar,100,0) ,
          new ParDef("@lV85Parametromudanzawwds_17_tfparametromudanzadescripcion",GXType.VarChar,100,0) ,
          new ParDef("@AV86Parametromudanzawwds_18_tfparametromudanzadescripcion_sel",GXType.NVarChar,100,0) ,
          new ParDef("@AV87Parametromudanzawwds_19_tfparametromudanzavalor",GXType.Decimal,18,2) ,
          new ParDef("@AV88Parametromudanzawwds_20_tfparametromudanzavalor_to",GXType.Decimal,18,2) ,
          new ParDef("@AV90Parametromudanzawwds_22_tfparametromudanzapisoelev",GXType.Int16,4,0) ,
          new ParDef("@AV91Parametromudanzawwds_23_tfparametromudanzapisoelev_to",GXType.Int16,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00EV2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00EV2,100, GxCacheFrequency.OFF ,true,false )
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
                ((bool[]) buf[0])[0] = rslt.getBool(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((decimal[]) buf[2])[0] = rslt.getDecimal(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((string[]) buf[5])[0] = rslt.getVarchar(6);
                ((short[]) buf[6])[0] = rslt.getShort(7);
                ((string[]) buf[7])[0] = rslt.getString(8, 2);
                ((string[]) buf[8])[0] = rslt.getVarchar(9);
                return;
       }
    }

 }

}

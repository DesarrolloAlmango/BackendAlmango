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
   public class centrocostoswwexport : GXProcedure
   {
      public centrocostoswwexport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public centrocostoswwexport( IGxContext context )
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
         new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWCentroCostos", out  GXt_boolean1) ;
         AV8IsAuthorized = GXt_boolean1;
         if ( ! AV8IsAuthorized )
         {
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "wwpbaseobjects.notauthorized.aspx"+GXUtil.UrlEncode(StringUtil.RTrim(AV66Pgmname));
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
         AV12Filename = GXt_char2 + "CentroCostosWWExport-" + StringUtil.Trim( StringUtil.Str( (decimal)(AV16Random), 8, 0)) + ".xlsx";
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
            if ( StringUtil.StrCmp(AV20DynamicFiltersSelector1, "CENTROCOSTOSNOMBRE") == 0 )
            {
               AV21DynamicFiltersOperator1 = AV31GridStateDynamicFilter.gxTpr_Operator;
               AV22CentroCostosNombre1 = AV31GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV22CentroCostosNombre1)) )
               {
                  AV14CellRow = (int)(AV14CellRow+1);
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Bold = 1;
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Color = 3;
                  if ( AV21DynamicFiltersOperator1 == 0 )
                  {
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", context.GetMessage( "Nombre:", ""), context.GetMessage( "WWP_FilterLike", ""), "", "", "", "", "", "", "");
                  }
                  else if ( AV21DynamicFiltersOperator1 == 1 )
                  {
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", context.GetMessage( "Nombre:", ""), context.GetMessage( "WWP_FilterContains", ""), "", "", "", "", "", "", "");
                  }
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Italic = 1;
                  GXt_char2 = "";
                  new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV22CentroCostosNombre1, out  GXt_char2) ;
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
               }
            }
            if ( AV34GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV23DynamicFiltersEnabled2 = true;
               AV31GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV34GridState.gxTpr_Dynamicfilters.Item(2));
               AV24DynamicFiltersSelector2 = AV31GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV24DynamicFiltersSelector2, "CENTROCOSTOSNOMBRE") == 0 )
               {
                  AV25DynamicFiltersOperator2 = AV31GridStateDynamicFilter.gxTpr_Operator;
                  AV26CentroCostosNombre2 = AV31GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV26CentroCostosNombre2)) )
                  {
                     AV14CellRow = (int)(AV14CellRow+1);
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Bold = 1;
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Color = 3;
                     if ( AV25DynamicFiltersOperator2 == 0 )
                     {
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", context.GetMessage( "Nombre:", ""), context.GetMessage( "WWP_FilterLike", ""), "", "", "", "", "", "", "");
                     }
                     else if ( AV25DynamicFiltersOperator2 == 1 )
                     {
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", context.GetMessage( "Nombre:", ""), context.GetMessage( "WWP_FilterContains", ""), "", "", "", "", "", "", "");
                     }
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Italic = 1;
                     GXt_char2 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV26CentroCostosNombre2, out  GXt_char2) ;
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
                  }
               }
               if ( AV34GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV27DynamicFiltersEnabled3 = true;
                  AV31GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV34GridState.gxTpr_Dynamicfilters.Item(3));
                  AV28DynamicFiltersSelector3 = AV31GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV28DynamicFiltersSelector3, "CENTROCOSTOSNOMBRE") == 0 )
                  {
                     AV29DynamicFiltersOperator3 = AV31GridStateDynamicFilter.gxTpr_Operator;
                     AV30CentroCostosNombre3 = AV31GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV30CentroCostosNombre3)) )
                     {
                        AV14CellRow = (int)(AV14CellRow+1);
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Bold = 1;
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Color = 3;
                        if ( AV29DynamicFiltersOperator3 == 0 )
                        {
                           AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", context.GetMessage( "Nombre:", ""), context.GetMessage( "WWP_FilterLike", ""), "", "", "", "", "", "", "");
                        }
                        else if ( AV29DynamicFiltersOperator3 == 1 )
                        {
                           AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", context.GetMessage( "Nombre:", ""), context.GetMessage( "WWP_FilterContains", ""), "", "", "", "", "", "", "");
                        }
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Italic = 1;
                        GXt_char2 = "";
                        new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV30CentroCostosNombre3, out  GXt_char2) ;
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
                     }
                  }
               }
            }
         }
         if ( ! ( (0==AV47TFCentroCostosId) && (0==AV48TFCentroCostosId_To) ) )
         {
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Código CC:", "")) ;
            AV14CellRow = GXt_int3;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Number = AV47TFCentroCostosId;
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  false, ref  GXt_int3,  (short)(AV15FirstColumn+2),  context.GetMessage( "WWP_TSTo", "")) ;
            AV14CellRow = GXt_int3;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+3, 1, 1).Number = AV48TFCentroCostosId_To;
         }
         if ( ! ( (0==AV49TFCentroCostosRef) && (0==AV50TFCentroCostosRef_To) ) )
         {
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Referencia Nro:", "")) ;
            AV14CellRow = GXt_int3;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Number = AV49TFCentroCostosRef;
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  false, ref  GXt_int3,  (short)(AV15FirstColumn+2),  context.GetMessage( "WWP_TSTo", "")) ;
            AV14CellRow = GXt_int3;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+3, 1, 1).Number = AV50TFCentroCostosRef_To;
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV52TFCentroCostosNombre_Sel)) ) )
         {
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Nombre:", "")) ;
            AV14CellRow = GXt_int3;
            GXt_char2 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV52TFCentroCostosNombre_Sel)) ? context.GetMessage( "WWP_TitleFilter_EmptyOption", "") : AV52TFCentroCostosNombre_Sel), out  GXt_char2) ;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV51TFCentroCostosNombre)) ) )
            {
               GXt_int3 = (short)(AV14CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Nombre:", "")) ;
               AV14CellRow = GXt_int3;
               GXt_char2 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV51TFCentroCostosNombre, out  GXt_char2) ;
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
            }
         }
         if ( ! ( (Convert.ToDecimal(0)==AV53TFCentroCostosPrecioFinal) && (Convert.ToDecimal(0)==AV54TFCentroCostosPrecioFinal_To) ) )
         {
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Precio Final:", "")) ;
            AV14CellRow = GXt_int3;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Number = (double)(AV53TFCentroCostosPrecioFinal);
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  false, ref  GXt_int3,  (short)(AV15FirstColumn+2),  context.GetMessage( "WWP_TSTo", "")) ;
            AV14CellRow = GXt_int3;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+3, 1, 1).Number = (double)(AV54TFCentroCostosPrecioFinal_To);
         }
         if ( ! ( (Convert.ToDecimal(0)==AV55TFCentroCostosCosto) && (Convert.ToDecimal(0)==AV56TFCentroCostosCosto_To) ) )
         {
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Costo", "")) ;
            AV14CellRow = GXt_int3;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Number = (double)(AV55TFCentroCostosCosto);
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  false, ref  GXt_int3,  (short)(AV15FirstColumn+2),  context.GetMessage( "WWP_TSTo", "")) ;
            AV14CellRow = GXt_int3;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+3, 1, 1).Number = (double)(AV56TFCentroCostosCosto_To);
         }
         if ( ! ( (Convert.ToDecimal(0)==AV57TFCentroCostosGam) && (Convert.ToDecimal(0)==AV58TFCentroCostosGam_To) ) )
         {
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Ganancia", "")) ;
            AV14CellRow = GXt_int3;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Number = (double)(AV57TFCentroCostosGam);
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  false, ref  GXt_int3,  (short)(AV15FirstColumn+2),  context.GetMessage( "WWP_TSTo", "")) ;
            AV14CellRow = GXt_int3;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+3, 1, 1).Number = (double)(AV58TFCentroCostosGam_To);
         }
         if ( ! ( ( AV60TFCentroCostosEstado_Sels.Count == 0 ) ) )
         {
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Estado", "")) ;
            AV14CellRow = GXt_int3;
            AV65i = 1;
            AV67GXV1 = 1;
            while ( AV67GXV1 <= AV60TFCentroCostosEstado_Sels.Count )
            {
               AV61TFCentroCostosEstado_Sel = AV60TFCentroCostosEstado_Sels.GetString(AV67GXV1);
               if ( AV65i == 1 )
               {
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = "";
               }
               else
               {
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text+", ";
               }
               if ( StringUtil.StrCmp(StringUtil.Trim( AV61TFCentroCostosEstado_Sel), context.GetMessage( "HAB", "")) == 0 )
               {
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text+context.GetMessage( "Aprobado", "");
               }
               else if ( StringUtil.StrCmp(StringUtil.Trim( AV61TFCentroCostosEstado_Sel), context.GetMessage( "DES", "")) == 0 )
               {
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text+context.GetMessage( "Deshabilitado", "");
               }
               else if ( StringUtil.StrCmp(StringUtil.Trim( AV61TFCentroCostosEstado_Sel), context.GetMessage( "PND", "")) == 0 )
               {
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text+context.GetMessage( "Pendiente de Aprobación", "");
               }
               else if ( StringUtil.StrCmp(StringUtil.Trim( AV61TFCentroCostosEstado_Sel), context.GetMessage( "DES", "")) == 0 )
               {
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text+context.GetMessage( "Desaprobado", "");
               }
               AV65i = (long)(AV65i+1);
               AV67GXV1 = (int)(AV67GXV1+1);
            }
         }
         if ( ! ( ( AV63TFCentroCostosTipoRef_Sels.Count == 0 ) ) )
         {
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Tipo Referencia:", "")) ;
            AV14CellRow = GXt_int3;
            AV65i = 1;
            AV68GXV2 = 1;
            while ( AV68GXV2 <= AV63TFCentroCostosTipoRef_Sels.Count )
            {
               AV64TFCentroCostosTipoRef_Sel = AV63TFCentroCostosTipoRef_Sels.GetString(AV68GXV2);
               if ( AV65i == 1 )
               {
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = "";
               }
               else
               {
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text+", ";
               }
               if ( StringUtil.StrCmp(StringUtil.Trim( AV64TFCentroCostosTipoRef_Sel), context.GetMessage( "S", "")) == 0 )
               {
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text+context.GetMessage( "Servicios", "");
               }
               else if ( StringUtil.StrCmp(StringUtil.Trim( AV64TFCentroCostosTipoRef_Sel), context.GetMessage( "O", "")) == 0 )
               {
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text+context.GetMessage( "Otros", "");
               }
               AV65i = (long)(AV65i+1);
               AV68GXV2 = (int)(AV68GXV2+1);
            }
         }
         AV14CellRow = (int)(AV14CellRow+2);
      }

      protected void S141( )
      {
         /* 'WRITECOLUMNTITLES' Routine */
         returnInSub = false;
         AV44VisibleColumnCount = 0;
         if ( StringUtil.StrCmp(AV32Session.Get("CentroCostosWWColumnsSelector"), "") != 0 )
         {
            AV39ColumnsSelectorXML = AV32Session.Get("CentroCostosWWColumnsSelector");
            AV36ColumnsSelector.FromXml(AV39ColumnsSelectorXML, null, "", "");
         }
         else
         {
            /* Execute user subroutine: 'INITIALIZECOLUMNSSELECTOR' */
            S151 ();
            if (returnInSub) return;
         }
         AV36ColumnsSelector.gxTpr_Columns.Sort("Order");
         AV69GXV3 = 1;
         while ( AV69GXV3 <= AV36ColumnsSelector.gxTpr_Columns.Count )
         {
            AV38ColumnsSelector_Column = ((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV36ColumnsSelector.gxTpr_Columns.Item(AV69GXV3));
            if ( AV38ColumnsSelector_Column.gxTpr_Isvisible )
            {
               AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV44VisibleColumnCount), 1, 1).Text = context.GetMessage( (String.IsNullOrEmpty(StringUtil.RTrim( AV38ColumnsSelector_Column.gxTpr_Displayname)) ? AV38ColumnsSelector_Column.gxTpr_Columnname : AV38ColumnsSelector_Column.gxTpr_Displayname), "");
               AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV44VisibleColumnCount), 1, 1).Bold = 1;
               AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV44VisibleColumnCount), 1, 1).Color = 11;
               AV44VisibleColumnCount = (long)(AV44VisibleColumnCount+1);
            }
            AV69GXV3 = (int)(AV69GXV3+1);
         }
      }

      protected void S161( )
      {
         /* 'WRITEDATA' Routine */
         returnInSub = false;
         AV71Centrocostoswwds_1_filterfulltext = AV19FilterFullText;
         AV72Centrocostoswwds_2_dynamicfiltersselector1 = AV20DynamicFiltersSelector1;
         AV73Centrocostoswwds_3_dynamicfiltersoperator1 = AV21DynamicFiltersOperator1;
         AV74Centrocostoswwds_4_centrocostosnombre1 = AV22CentroCostosNombre1;
         AV75Centrocostoswwds_5_dynamicfiltersenabled2 = AV23DynamicFiltersEnabled2;
         AV76Centrocostoswwds_6_dynamicfiltersselector2 = AV24DynamicFiltersSelector2;
         AV77Centrocostoswwds_7_dynamicfiltersoperator2 = AV25DynamicFiltersOperator2;
         AV78Centrocostoswwds_8_centrocostosnombre2 = AV26CentroCostosNombre2;
         AV79Centrocostoswwds_9_dynamicfiltersenabled3 = AV27DynamicFiltersEnabled3;
         AV80Centrocostoswwds_10_dynamicfiltersselector3 = AV28DynamicFiltersSelector3;
         AV81Centrocostoswwds_11_dynamicfiltersoperator3 = AV29DynamicFiltersOperator3;
         AV82Centrocostoswwds_12_centrocostosnombre3 = AV30CentroCostosNombre3;
         AV83Centrocostoswwds_13_tfcentrocostosid = AV47TFCentroCostosId;
         AV84Centrocostoswwds_14_tfcentrocostosid_to = AV48TFCentroCostosId_To;
         AV85Centrocostoswwds_15_tfcentrocostosref = AV49TFCentroCostosRef;
         AV86Centrocostoswwds_16_tfcentrocostosref_to = AV50TFCentroCostosRef_To;
         AV87Centrocostoswwds_17_tfcentrocostosnombre = AV51TFCentroCostosNombre;
         AV88Centrocostoswwds_18_tfcentrocostosnombre_sel = AV52TFCentroCostosNombre_Sel;
         AV89Centrocostoswwds_19_tfcentrocostospreciofinal = AV53TFCentroCostosPrecioFinal;
         AV90Centrocostoswwds_20_tfcentrocostospreciofinal_to = AV54TFCentroCostosPrecioFinal_To;
         AV91Centrocostoswwds_21_tfcentrocostoscosto = AV55TFCentroCostosCosto;
         AV92Centrocostoswwds_22_tfcentrocostoscosto_to = AV56TFCentroCostosCosto_To;
         AV93Centrocostoswwds_23_tfcentrocostosgam = AV57TFCentroCostosGam;
         AV94Centrocostoswwds_24_tfcentrocostosgam_to = AV58TFCentroCostosGam_To;
         AV95Centrocostoswwds_25_tfcentrocostosestado_sels = AV60TFCentroCostosEstado_Sels;
         AV96Centrocostoswwds_26_tfcentrocostostiporef_sels = AV63TFCentroCostosTipoRef_Sels;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A482CentroCostosEstado ,
                                              AV95Centrocostoswwds_25_tfcentrocostosestado_sels ,
                                              A487CentroCostosTipoRef ,
                                              AV96Centrocostoswwds_26_tfcentrocostostiporef_sels ,
                                              AV72Centrocostoswwds_2_dynamicfiltersselector1 ,
                                              AV73Centrocostoswwds_3_dynamicfiltersoperator1 ,
                                              AV74Centrocostoswwds_4_centrocostosnombre1 ,
                                              AV75Centrocostoswwds_5_dynamicfiltersenabled2 ,
                                              AV76Centrocostoswwds_6_dynamicfiltersselector2 ,
                                              AV77Centrocostoswwds_7_dynamicfiltersoperator2 ,
                                              AV78Centrocostoswwds_8_centrocostosnombre2 ,
                                              AV79Centrocostoswwds_9_dynamicfiltersenabled3 ,
                                              AV80Centrocostoswwds_10_dynamicfiltersselector3 ,
                                              AV81Centrocostoswwds_11_dynamicfiltersoperator3 ,
                                              AV82Centrocostoswwds_12_centrocostosnombre3 ,
                                              AV83Centrocostoswwds_13_tfcentrocostosid ,
                                              AV84Centrocostoswwds_14_tfcentrocostosid_to ,
                                              AV85Centrocostoswwds_15_tfcentrocostosref ,
                                              AV86Centrocostoswwds_16_tfcentrocostosref_to ,
                                              AV88Centrocostoswwds_18_tfcentrocostosnombre_sel ,
                                              AV87Centrocostoswwds_17_tfcentrocostosnombre ,
                                              AV89Centrocostoswwds_19_tfcentrocostospreciofinal ,
                                              AV90Centrocostoswwds_20_tfcentrocostospreciofinal_to ,
                                              AV91Centrocostoswwds_21_tfcentrocostoscosto ,
                                              AV92Centrocostoswwds_22_tfcentrocostoscosto_to ,
                                              AV93Centrocostoswwds_23_tfcentrocostosgam ,
                                              AV94Centrocostoswwds_24_tfcentrocostosgam_to ,
                                              AV95Centrocostoswwds_25_tfcentrocostosestado_sels.Count ,
                                              AV96Centrocostoswwds_26_tfcentrocostostiporef_sels.Count ,
                                              A463CentroCostosNombre ,
                                              A461CentroCostosId ,
                                              A462CentroCostosRef ,
                                              A464CentroCostosPrecioFinal ,
                                              A475CentroCostosCosto ,
                                              AV17OrderedBy ,
                                              AV18OrderedDsc ,
                                              AV71Centrocostoswwds_1_filterfulltext ,
                                              A474CentroCostosGam } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.DECIMAL,
                                              TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.INT, TypeConstants.INT, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.DECIMAL,
                                              TypeConstants.DECIMAL, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.DECIMAL
                                              }
         });
         lV74Centrocostoswwds_4_centrocostosnombre1 = StringUtil.PadR( StringUtil.RTrim( AV74Centrocostoswwds_4_centrocostosnombre1), 80, "%");
         lV74Centrocostoswwds_4_centrocostosnombre1 = StringUtil.PadR( StringUtil.RTrim( AV74Centrocostoswwds_4_centrocostosnombre1), 80, "%");
         lV78Centrocostoswwds_8_centrocostosnombre2 = StringUtil.PadR( StringUtil.RTrim( AV78Centrocostoswwds_8_centrocostosnombre2), 80, "%");
         lV78Centrocostoswwds_8_centrocostosnombre2 = StringUtil.PadR( StringUtil.RTrim( AV78Centrocostoswwds_8_centrocostosnombre2), 80, "%");
         lV82Centrocostoswwds_12_centrocostosnombre3 = StringUtil.PadR( StringUtil.RTrim( AV82Centrocostoswwds_12_centrocostosnombre3), 80, "%");
         lV82Centrocostoswwds_12_centrocostosnombre3 = StringUtil.PadR( StringUtil.RTrim( AV82Centrocostoswwds_12_centrocostosnombre3), 80, "%");
         lV87Centrocostoswwds_17_tfcentrocostosnombre = StringUtil.PadR( StringUtil.RTrim( AV87Centrocostoswwds_17_tfcentrocostosnombre), 80, "%");
         /* Using cursor P005Y2 */
         pr_default.execute(0, new Object[] {lV74Centrocostoswwds_4_centrocostosnombre1, lV74Centrocostoswwds_4_centrocostosnombre1, lV78Centrocostoswwds_8_centrocostosnombre2, lV78Centrocostoswwds_8_centrocostosnombre2, lV82Centrocostoswwds_12_centrocostosnombre3, lV82Centrocostoswwds_12_centrocostosnombre3, AV83Centrocostoswwds_13_tfcentrocostosid, AV84Centrocostoswwds_14_tfcentrocostosid_to, AV85Centrocostoswwds_15_tfcentrocostosref, AV86Centrocostoswwds_16_tfcentrocostosref_to, lV87Centrocostoswwds_17_tfcentrocostosnombre, AV88Centrocostoswwds_18_tfcentrocostosnombre_sel, AV89Centrocostoswwds_19_tfcentrocostospreciofinal, AV90Centrocostoswwds_20_tfcentrocostospreciofinal_to, AV91Centrocostoswwds_21_tfcentrocostoscosto, AV92Centrocostoswwds_22_tfcentrocostoscosto_to, AV93Centrocostoswwds_23_tfcentrocostosgam, AV94Centrocostoswwds_24_tfcentrocostosgam_to});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A474CentroCostosGam = P005Y2_A474CentroCostosGam[0];
            A463CentroCostosNombre = P005Y2_A463CentroCostosNombre[0];
            A462CentroCostosRef = P005Y2_A462CentroCostosRef[0];
            A461CentroCostosId = P005Y2_A461CentroCostosId[0];
            A487CentroCostosTipoRef = P005Y2_A487CentroCostosTipoRef[0];
            A482CentroCostosEstado = P005Y2_A482CentroCostosEstado[0];
            A464CentroCostosPrecioFinal = P005Y2_A464CentroCostosPrecioFinal[0];
            A475CentroCostosCosto = P005Y2_A475CentroCostosCosto[0];
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV71Centrocostoswwds_1_filterfulltext)) || ( ( StringUtil.Like( StringUtil.Str( (decimal)(A461CentroCostosId), 18, 0) , StringUtil.PadR( "%" + AV71Centrocostoswwds_1_filterfulltext , 254 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Str( (decimal)(A462CentroCostosRef), 18, 0) , StringUtil.PadR( "%" + AV71Centrocostoswwds_1_filterfulltext , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A463CentroCostosNombre) , StringUtil.PadR( "%" + StringUtil.Upper( AV71Centrocostoswwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Str( A464CentroCostosPrecioFinal, 18, 2) , StringUtil.PadR( "%" + AV71Centrocostoswwds_1_filterfulltext , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Str( A475CentroCostosCosto, 18, 2) , StringUtil.PadR( "%" + AV71Centrocostoswwds_1_filterfulltext , 254 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Str( A474CentroCostosGam, 18, 2) , StringUtil.PadR( "%" + AV71Centrocostoswwds_1_filterfulltext , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( context.GetMessage( "aprobado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV71Centrocostoswwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A482CentroCostosEstado, "HAB") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "deshabilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV71Centrocostoswwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A482CentroCostosEstado, "DES") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "pendiente de aprobación", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV71Centrocostoswwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A482CentroCostosEstado, "PND") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "desaprobado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV71Centrocostoswwds_1_filterfulltext) , 255 , "%"),  ' ' ) &&
            ( StringUtil.StrCmp(A482CentroCostosEstado, "DES") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "servicios", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV71Centrocostoswwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A487CentroCostosTipoRef, "S") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "otros", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV71Centrocostoswwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A487CentroCostosTipoRef, "O") == 0 ) ) )
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
               AV44VisibleColumnCount = 0;
               AV97GXV4 = 1;
               while ( AV97GXV4 <= AV36ColumnsSelector.gxTpr_Columns.Count )
               {
                  AV38ColumnsSelector_Column = ((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV36ColumnsSelector.gxTpr_Columns.Item(AV97GXV4));
                  if ( AV38ColumnsSelector_Column.gxTpr_Isvisible )
                  {
                     if ( StringUtil.StrCmp(AV38ColumnsSelector_Column.gxTpr_Columnname, "CentroCostosId") == 0 )
                     {
                        AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV44VisibleColumnCount), 1, 1).Number = A461CentroCostosId;
                     }
                     else if ( StringUtil.StrCmp(AV38ColumnsSelector_Column.gxTpr_Columnname, "CentroCostosRef") == 0 )
                     {
                        AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV44VisibleColumnCount), 1, 1).Number = A462CentroCostosRef;
                     }
                     else if ( StringUtil.StrCmp(AV38ColumnsSelector_Column.gxTpr_Columnname, "CentroCostosNombre") == 0 )
                     {
                        GXt_char2 = "";
                        new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A463CentroCostosNombre, out  GXt_char2) ;
                        AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV44VisibleColumnCount), 1, 1).Text = GXt_char2;
                     }
                     else if ( StringUtil.StrCmp(AV38ColumnsSelector_Column.gxTpr_Columnname, "CentroCostosPrecioFinal") == 0 )
                     {
                        AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV44VisibleColumnCount), 1, 1).Number = (double)(A464CentroCostosPrecioFinal);
                     }
                     else if ( StringUtil.StrCmp(AV38ColumnsSelector_Column.gxTpr_Columnname, "CentroCostosCosto") == 0 )
                     {
                        AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV44VisibleColumnCount), 1, 1).Number = (double)(A475CentroCostosCosto);
                     }
                     else if ( StringUtil.StrCmp(AV38ColumnsSelector_Column.gxTpr_Columnname, "CentroCostosGam") == 0 )
                     {
                        AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV44VisibleColumnCount), 1, 1).Number = (double)(A474CentroCostosGam);
                     }
                     else if ( StringUtil.StrCmp(AV38ColumnsSelector_Column.gxTpr_Columnname, "CentroCostosEstado") == 0 )
                     {
                        AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV44VisibleColumnCount), 1, 1).Text = "";
                        if ( StringUtil.StrCmp(StringUtil.Trim( A482CentroCostosEstado), context.GetMessage( "HAB", "")) == 0 )
                        {
                           AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV44VisibleColumnCount), 1, 1).Text = context.GetMessage( "Aprobado", "");
                        }
                        else if ( StringUtil.StrCmp(StringUtil.Trim( A482CentroCostosEstado), context.GetMessage( "DES", "")) == 0 )
                        {
                           AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV44VisibleColumnCount), 1, 1).Text = context.GetMessage( "Deshabilitado", "");
                        }
                        else if ( StringUtil.StrCmp(StringUtil.Trim( A482CentroCostosEstado), context.GetMessage( "PND", "")) == 0 )
                        {
                           AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV44VisibleColumnCount), 1, 1).Text = context.GetMessage( "Pendiente de Aprobación", "");
                        }
                        else if ( StringUtil.StrCmp(StringUtil.Trim( A482CentroCostosEstado), context.GetMessage( "DES", "")) == 0 )
                        {
                           AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV44VisibleColumnCount), 1, 1).Text = context.GetMessage( "Desaprobado", "");
                        }
                     }
                     else if ( StringUtil.StrCmp(AV38ColumnsSelector_Column.gxTpr_Columnname, "CentroCostosTipoRef") == 0 )
                     {
                        AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV44VisibleColumnCount), 1, 1).Text = "";
                        if ( StringUtil.StrCmp(StringUtil.Trim( A487CentroCostosTipoRef), context.GetMessage( "S", "")) == 0 )
                        {
                           AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV44VisibleColumnCount), 1, 1).Text = context.GetMessage( "Servicios", "");
                        }
                        else if ( StringUtil.StrCmp(StringUtil.Trim( A487CentroCostosTipoRef), context.GetMessage( "O", "")) == 0 )
                        {
                           AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV44VisibleColumnCount), 1, 1).Text = context.GetMessage( "Otros", "");
                        }
                     }
                     AV44VisibleColumnCount = (long)(AV44VisibleColumnCount+1);
                  }
                  AV97GXV4 = (int)(AV97GXV4+1);
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
         AV32Session.Set("WWPExportFileName", "CentroCostosWWExport.xlsx");
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
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV36ColumnsSelector,  "CentroCostosId",  "",  "Código CC:",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV36ColumnsSelector,  "CentroCostosRef",  "",  "Referencia Nro:",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV36ColumnsSelector,  "CentroCostosNombre",  "",  "Nombre:",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV36ColumnsSelector,  "CentroCostosPrecioFinal",  "",  "Precio Final:",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV36ColumnsSelector,  "CentroCostosCosto",  "",  "Costo",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV36ColumnsSelector,  "CentroCostosGam",  "",  "Ganancia",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV36ColumnsSelector,  "CentroCostosEstado",  "",  "Estado",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV36ColumnsSelector,  "CentroCostosTipoRef",  "",  "Tipo Referencia:",  true,  "") ;
         GXt_char2 = AV40UserCustomValue;
         new GeneXus.Programs.wwpbaseobjects.loadcolumnsselectorstate(context ).execute(  "CentroCostosWWColumnsSelector", out  GXt_char2) ;
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
         if ( StringUtil.StrCmp(AV32Session.Get("CentroCostosWWGridState"), "") == 0 )
         {
            AV34GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "CentroCostosWWGridState"), null, "", "");
         }
         else
         {
            AV34GridState.FromXml(AV32Session.Get("CentroCostosWWGridState"), null, "", "");
         }
         AV17OrderedBy = AV34GridState.gxTpr_Orderedby;
         AV18OrderedDsc = AV34GridState.gxTpr_Ordereddsc;
         AV98GXV5 = 1;
         while ( AV98GXV5 <= AV34GridState.gxTpr_Filtervalues.Count )
         {
            AV35GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV34GridState.gxTpr_Filtervalues.Item(AV98GXV5));
            if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV19FilterFullText = AV35GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFCENTROCOSTOSID") == 0 )
            {
               AV47TFCentroCostosId = (long)(Math.Round(NumberUtil.Val( AV35GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV48TFCentroCostosId_To = (long)(Math.Round(NumberUtil.Val( AV35GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFCENTROCOSTOSREF") == 0 )
            {
               AV49TFCentroCostosRef = (long)(Math.Round(NumberUtil.Val( AV35GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV50TFCentroCostosRef_To = (long)(Math.Round(NumberUtil.Val( AV35GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFCENTROCOSTOSNOMBRE") == 0 )
            {
               AV51TFCentroCostosNombre = AV35GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFCENTROCOSTOSNOMBRE_SEL") == 0 )
            {
               AV52TFCentroCostosNombre_Sel = AV35GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFCENTROCOSTOSPRECIOFINAL") == 0 )
            {
               AV53TFCentroCostosPrecioFinal = NumberUtil.Val( AV35GridStateFilterValue.gxTpr_Value, ".");
               AV54TFCentroCostosPrecioFinal_To = NumberUtil.Val( AV35GridStateFilterValue.gxTpr_Valueto, ".");
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFCENTROCOSTOSCOSTO") == 0 )
            {
               AV55TFCentroCostosCosto = NumberUtil.Val( AV35GridStateFilterValue.gxTpr_Value, ".");
               AV56TFCentroCostosCosto_To = NumberUtil.Val( AV35GridStateFilterValue.gxTpr_Valueto, ".");
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFCENTROCOSTOSGAM") == 0 )
            {
               AV57TFCentroCostosGam = NumberUtil.Val( AV35GridStateFilterValue.gxTpr_Value, ".");
               AV58TFCentroCostosGam_To = NumberUtil.Val( AV35GridStateFilterValue.gxTpr_Valueto, ".");
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFCENTROCOSTOSESTADO_SEL") == 0 )
            {
               AV59TFCentroCostosEstado_SelsJson = AV35GridStateFilterValue.gxTpr_Value;
               AV60TFCentroCostosEstado_Sels.FromJSonString(AV59TFCentroCostosEstado_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFCENTROCOSTOSTIPOREF_SEL") == 0 )
            {
               AV62TFCentroCostosTipoRef_SelsJson = AV35GridStateFilterValue.gxTpr_Value;
               AV63TFCentroCostosTipoRef_Sels.FromJSonString(AV62TFCentroCostosTipoRef_SelsJson, null);
            }
            AV98GXV5 = (int)(AV98GXV5+1);
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
         AV66Pgmname = "";
         GXKey = "";
         GXEncryptionTmp = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV11ExcelDocument = new ExcelDocumentI();
         AV19FilterFullText = "";
         AV34GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV31GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV20DynamicFiltersSelector1 = "";
         AV22CentroCostosNombre1 = "";
         AV24DynamicFiltersSelector2 = "";
         AV26CentroCostosNombre2 = "";
         AV28DynamicFiltersSelector3 = "";
         AV30CentroCostosNombre3 = "";
         AV52TFCentroCostosNombre_Sel = "";
         AV51TFCentroCostosNombre = "";
         AV60TFCentroCostosEstado_Sels = new GxSimpleCollection<string>();
         AV61TFCentroCostosEstado_Sel = "";
         AV63TFCentroCostosTipoRef_Sels = new GxSimpleCollection<string>();
         AV64TFCentroCostosTipoRef_Sel = "";
         AV32Session = context.GetSession();
         AV39ColumnsSelectorXML = "";
         AV36ColumnsSelector = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector(context);
         AV38ColumnsSelector_Column = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column(context);
         AV71Centrocostoswwds_1_filterfulltext = "";
         AV72Centrocostoswwds_2_dynamicfiltersselector1 = "";
         AV74Centrocostoswwds_4_centrocostosnombre1 = "";
         AV76Centrocostoswwds_6_dynamicfiltersselector2 = "";
         AV78Centrocostoswwds_8_centrocostosnombre2 = "";
         AV80Centrocostoswwds_10_dynamicfiltersselector3 = "";
         AV82Centrocostoswwds_12_centrocostosnombre3 = "";
         AV87Centrocostoswwds_17_tfcentrocostosnombre = "";
         AV88Centrocostoswwds_18_tfcentrocostosnombre_sel = "";
         AV95Centrocostoswwds_25_tfcentrocostosestado_sels = new GxSimpleCollection<string>();
         AV96Centrocostoswwds_26_tfcentrocostostiporef_sels = new GxSimpleCollection<string>();
         lV74Centrocostoswwds_4_centrocostosnombre1 = "";
         lV78Centrocostoswwds_8_centrocostosnombre2 = "";
         lV82Centrocostoswwds_12_centrocostosnombre3 = "";
         lV87Centrocostoswwds_17_tfcentrocostosnombre = "";
         A482CentroCostosEstado = "";
         A487CentroCostosTipoRef = "";
         A463CentroCostosNombre = "";
         P005Y2_A474CentroCostosGam = new decimal[1] ;
         P005Y2_A463CentroCostosNombre = new string[] {""} ;
         P005Y2_A462CentroCostosRef = new long[1] ;
         P005Y2_A461CentroCostosId = new long[1] ;
         P005Y2_A487CentroCostosTipoRef = new string[] {""} ;
         P005Y2_A482CentroCostosEstado = new string[] {""} ;
         P005Y2_A464CentroCostosPrecioFinal = new decimal[1] ;
         P005Y2_A475CentroCostosCosto = new decimal[1] ;
         AV40UserCustomValue = "";
         GXt_char2 = "";
         AV37ColumnsSelectorAux = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector(context);
         AV35GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV59TFCentroCostosEstado_SelsJson = "";
         AV62TFCentroCostosTipoRef_SelsJson = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.centrocostoswwexport__default(),
            new Object[][] {
                new Object[] {
               P005Y2_A474CentroCostosGam, P005Y2_A463CentroCostosNombre, P005Y2_A462CentroCostosRef, P005Y2_A461CentroCostosId, P005Y2_A487CentroCostosTipoRef, P005Y2_A482CentroCostosEstado, P005Y2_A464CentroCostosPrecioFinal, P005Y2_A475CentroCostosCosto
               }
            }
         );
         AV66Pgmname = "CentroCostosWWExport";
         /* GeneXus formulas. */
         AV66Pgmname = "CentroCostosWWExport";
      }

      private short AV21DynamicFiltersOperator1 ;
      private short AV25DynamicFiltersOperator2 ;
      private short AV29DynamicFiltersOperator3 ;
      private short GXt_int3 ;
      private short AV73Centrocostoswwds_3_dynamicfiltersoperator1 ;
      private short AV77Centrocostoswwds_7_dynamicfiltersoperator2 ;
      private short AV81Centrocostoswwds_11_dynamicfiltersoperator3 ;
      private short AV17OrderedBy ;
      private int AV14CellRow ;
      private int AV15FirstColumn ;
      private int AV16Random ;
      private int AV67GXV1 ;
      private int AV68GXV2 ;
      private int AV69GXV3 ;
      private int AV95Centrocostoswwds_25_tfcentrocostosestado_sels_Count ;
      private int AV96Centrocostoswwds_26_tfcentrocostostiporef_sels_Count ;
      private int AV97GXV4 ;
      private int AV98GXV5 ;
      private long AV47TFCentroCostosId ;
      private long AV48TFCentroCostosId_To ;
      private long AV49TFCentroCostosRef ;
      private long AV50TFCentroCostosRef_To ;
      private long AV65i ;
      private long AV44VisibleColumnCount ;
      private long AV83Centrocostoswwds_13_tfcentrocostosid ;
      private long AV84Centrocostoswwds_14_tfcentrocostosid_to ;
      private long AV85Centrocostoswwds_15_tfcentrocostosref ;
      private long AV86Centrocostoswwds_16_tfcentrocostosref_to ;
      private long A461CentroCostosId ;
      private long A462CentroCostosRef ;
      private decimal AV53TFCentroCostosPrecioFinal ;
      private decimal AV54TFCentroCostosPrecioFinal_To ;
      private decimal AV55TFCentroCostosCosto ;
      private decimal AV56TFCentroCostosCosto_To ;
      private decimal AV57TFCentroCostosGam ;
      private decimal AV58TFCentroCostosGam_To ;
      private decimal AV89Centrocostoswwds_19_tfcentrocostospreciofinal ;
      private decimal AV90Centrocostoswwds_20_tfcentrocostospreciofinal_to ;
      private decimal AV91Centrocostoswwds_21_tfcentrocostoscosto ;
      private decimal AV92Centrocostoswwds_22_tfcentrocostoscosto_to ;
      private decimal AV93Centrocostoswwds_23_tfcentrocostosgam ;
      private decimal AV94Centrocostoswwds_24_tfcentrocostosgam_to ;
      private decimal A464CentroCostosPrecioFinal ;
      private decimal A475CentroCostosCosto ;
      private decimal A474CentroCostosGam ;
      private string AV66Pgmname ;
      private string GXKey ;
      private string GXEncryptionTmp ;
      private string AV22CentroCostosNombre1 ;
      private string AV26CentroCostosNombre2 ;
      private string AV30CentroCostosNombre3 ;
      private string AV52TFCentroCostosNombre_Sel ;
      private string AV51TFCentroCostosNombre ;
      private string AV61TFCentroCostosEstado_Sel ;
      private string AV64TFCentroCostosTipoRef_Sel ;
      private string AV74Centrocostoswwds_4_centrocostosnombre1 ;
      private string AV78Centrocostoswwds_8_centrocostosnombre2 ;
      private string AV82Centrocostoswwds_12_centrocostosnombre3 ;
      private string AV87Centrocostoswwds_17_tfcentrocostosnombre ;
      private string AV88Centrocostoswwds_18_tfcentrocostosnombre_sel ;
      private string lV74Centrocostoswwds_4_centrocostosnombre1 ;
      private string lV78Centrocostoswwds_8_centrocostosnombre2 ;
      private string lV82Centrocostoswwds_12_centrocostosnombre3 ;
      private string lV87Centrocostoswwds_17_tfcentrocostosnombre ;
      private string A482CentroCostosEstado ;
      private string A487CentroCostosTipoRef ;
      private string A463CentroCostosNombre ;
      private string GXt_char2 ;
      private bool AV8IsAuthorized ;
      private bool GXt_boolean1 ;
      private bool returnInSub ;
      private bool AV23DynamicFiltersEnabled2 ;
      private bool AV27DynamicFiltersEnabled3 ;
      private bool AV75Centrocostoswwds_5_dynamicfiltersenabled2 ;
      private bool AV79Centrocostoswwds_9_dynamicfiltersenabled3 ;
      private bool AV18OrderedDsc ;
      private string AV39ColumnsSelectorXML ;
      private string AV40UserCustomValue ;
      private string AV59TFCentroCostosEstado_SelsJson ;
      private string AV62TFCentroCostosTipoRef_SelsJson ;
      private string AV12Filename ;
      private string AV13ErrorMessage ;
      private string AV19FilterFullText ;
      private string AV20DynamicFiltersSelector1 ;
      private string AV24DynamicFiltersSelector2 ;
      private string AV28DynamicFiltersSelector3 ;
      private string AV71Centrocostoswwds_1_filterfulltext ;
      private string AV72Centrocostoswwds_2_dynamicfiltersselector1 ;
      private string AV76Centrocostoswwds_6_dynamicfiltersselector2 ;
      private string AV80Centrocostoswwds_10_dynamicfiltersselector3 ;
      private IGxSession AV32Session ;
      private ExcelDocumentI AV11ExcelDocument ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV34GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV31GridStateDynamicFilter ;
      private GxSimpleCollection<string> AV60TFCentroCostosEstado_Sels ;
      private GxSimpleCollection<string> AV63TFCentroCostosTipoRef_Sels ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector AV36ColumnsSelector ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column AV38ColumnsSelector_Column ;
      private GxSimpleCollection<string> AV95Centrocostoswwds_25_tfcentrocostosestado_sels ;
      private GxSimpleCollection<string> AV96Centrocostoswwds_26_tfcentrocostostiporef_sels ;
      private IDataStoreProvider pr_default ;
      private decimal[] P005Y2_A474CentroCostosGam ;
      private string[] P005Y2_A463CentroCostosNombre ;
      private long[] P005Y2_A462CentroCostosRef ;
      private long[] P005Y2_A461CentroCostosId ;
      private string[] P005Y2_A487CentroCostosTipoRef ;
      private string[] P005Y2_A482CentroCostosEstado ;
      private decimal[] P005Y2_A464CentroCostosPrecioFinal ;
      private decimal[] P005Y2_A475CentroCostosCosto ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector AV37ColumnsSelectorAux ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV35GridStateFilterValue ;
      private string aP0_Filename ;
      private string aP1_ErrorMessage ;
   }

   public class centrocostoswwexport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P005Y2( IGxContext context ,
                                             string A482CentroCostosEstado ,
                                             GxSimpleCollection<string> AV95Centrocostoswwds_25_tfcentrocostosestado_sels ,
                                             string A487CentroCostosTipoRef ,
                                             GxSimpleCollection<string> AV96Centrocostoswwds_26_tfcentrocostostiporef_sels ,
                                             string AV72Centrocostoswwds_2_dynamicfiltersselector1 ,
                                             short AV73Centrocostoswwds_3_dynamicfiltersoperator1 ,
                                             string AV74Centrocostoswwds_4_centrocostosnombre1 ,
                                             bool AV75Centrocostoswwds_5_dynamicfiltersenabled2 ,
                                             string AV76Centrocostoswwds_6_dynamicfiltersselector2 ,
                                             short AV77Centrocostoswwds_7_dynamicfiltersoperator2 ,
                                             string AV78Centrocostoswwds_8_centrocostosnombre2 ,
                                             bool AV79Centrocostoswwds_9_dynamicfiltersenabled3 ,
                                             string AV80Centrocostoswwds_10_dynamicfiltersselector3 ,
                                             short AV81Centrocostoswwds_11_dynamicfiltersoperator3 ,
                                             string AV82Centrocostoswwds_12_centrocostosnombre3 ,
                                             long AV83Centrocostoswwds_13_tfcentrocostosid ,
                                             long AV84Centrocostoswwds_14_tfcentrocostosid_to ,
                                             long AV85Centrocostoswwds_15_tfcentrocostosref ,
                                             long AV86Centrocostoswwds_16_tfcentrocostosref_to ,
                                             string AV88Centrocostoswwds_18_tfcentrocostosnombre_sel ,
                                             string AV87Centrocostoswwds_17_tfcentrocostosnombre ,
                                             decimal AV89Centrocostoswwds_19_tfcentrocostospreciofinal ,
                                             decimal AV90Centrocostoswwds_20_tfcentrocostospreciofinal_to ,
                                             decimal AV91Centrocostoswwds_21_tfcentrocostoscosto ,
                                             decimal AV92Centrocostoswwds_22_tfcentrocostoscosto_to ,
                                             decimal AV93Centrocostoswwds_23_tfcentrocostosgam ,
                                             decimal AV94Centrocostoswwds_24_tfcentrocostosgam_to ,
                                             int AV95Centrocostoswwds_25_tfcentrocostosestado_sels_Count ,
                                             int AV96Centrocostoswwds_26_tfcentrocostostiporef_sels_Count ,
                                             string A463CentroCostosNombre ,
                                             long A461CentroCostosId ,
                                             long A462CentroCostosRef ,
                                             decimal A464CentroCostosPrecioFinal ,
                                             decimal A475CentroCostosCosto ,
                                             short AV17OrderedBy ,
                                             bool AV18OrderedDsc ,
                                             string AV71Centrocostoswwds_1_filterfulltext ,
                                             decimal A474CentroCostosGam )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int4 = new short[18];
         Object[] GXv_Object5 = new Object[2];
         scmdbuf = "SELECT [CentroCostosPrecioFinal] - [CentroCostosCosto] AS CentroCostosGam, [CentroCostosNombre], [CentroCostosRef], [CentroCostosId], [CentroCostosTipoRef], [CentroCostosEstado], [CentroCostosPrecioFinal], [CentroCostosCosto] FROM [CentroCostos]";
         if ( ( StringUtil.StrCmp(AV72Centrocostoswwds_2_dynamicfiltersselector1, "CENTROCOSTOSNOMBRE") == 0 ) && ( AV73Centrocostoswwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Centrocostoswwds_4_centrocostosnombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER([CentroCostosNombre]) like UPPER(@lV74Centrocostoswwds_4_centrocostosnombre1))");
         }
         else
         {
            GXv_int4[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV72Centrocostoswwds_2_dynamicfiltersselector1, "CENTROCOSTOSNOMBRE") == 0 ) && ( AV73Centrocostoswwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Centrocostoswwds_4_centrocostosnombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER([CentroCostosNombre]) like '%' + UPPER(@lV74Centrocostoswwds_4_centrocostosnombre1))");
         }
         else
         {
            GXv_int4[1] = 1;
         }
         if ( AV75Centrocostoswwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV76Centrocostoswwds_6_dynamicfiltersselector2, "CENTROCOSTOSNOMBRE") == 0 ) && ( AV77Centrocostoswwds_7_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV78Centrocostoswwds_8_centrocostosnombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER([CentroCostosNombre]) like UPPER(@lV78Centrocostoswwds_8_centrocostosnombre2))");
         }
         else
         {
            GXv_int4[2] = 1;
         }
         if ( AV75Centrocostoswwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV76Centrocostoswwds_6_dynamicfiltersselector2, "CENTROCOSTOSNOMBRE") == 0 ) && ( AV77Centrocostoswwds_7_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV78Centrocostoswwds_8_centrocostosnombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER([CentroCostosNombre]) like '%' + UPPER(@lV78Centrocostoswwds_8_centrocostosnombre2))");
         }
         else
         {
            GXv_int4[3] = 1;
         }
         if ( AV79Centrocostoswwds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV80Centrocostoswwds_10_dynamicfiltersselector3, "CENTROCOSTOSNOMBRE") == 0 ) && ( AV81Centrocostoswwds_11_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV82Centrocostoswwds_12_centrocostosnombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER([CentroCostosNombre]) like UPPER(@lV82Centrocostoswwds_12_centrocostosnombre3))");
         }
         else
         {
            GXv_int4[4] = 1;
         }
         if ( AV79Centrocostoswwds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV80Centrocostoswwds_10_dynamicfiltersselector3, "CENTROCOSTOSNOMBRE") == 0 ) && ( AV81Centrocostoswwds_11_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV82Centrocostoswwds_12_centrocostosnombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER([CentroCostosNombre]) like '%' + UPPER(@lV82Centrocostoswwds_12_centrocostosnombre3))");
         }
         else
         {
            GXv_int4[5] = 1;
         }
         if ( ! (0==AV83Centrocostoswwds_13_tfcentrocostosid) )
         {
            AddWhere(sWhereString, "([CentroCostosId] >= @AV83Centrocostoswwds_13_tfcentrocostosid)");
         }
         else
         {
            GXv_int4[6] = 1;
         }
         if ( ! (0==AV84Centrocostoswwds_14_tfcentrocostosid_to) )
         {
            AddWhere(sWhereString, "([CentroCostosId] <= @AV84Centrocostoswwds_14_tfcentrocostosid_to)");
         }
         else
         {
            GXv_int4[7] = 1;
         }
         if ( ! (0==AV85Centrocostoswwds_15_tfcentrocostosref) )
         {
            AddWhere(sWhereString, "([CentroCostosRef] >= @AV85Centrocostoswwds_15_tfcentrocostosref)");
         }
         else
         {
            GXv_int4[8] = 1;
         }
         if ( ! (0==AV86Centrocostoswwds_16_tfcentrocostosref_to) )
         {
            AddWhere(sWhereString, "([CentroCostosRef] <= @AV86Centrocostoswwds_16_tfcentrocostosref_to)");
         }
         else
         {
            GXv_int4[9] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV88Centrocostoswwds_18_tfcentrocostosnombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV87Centrocostoswwds_17_tfcentrocostosnombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER([CentroCostosNombre]) like UPPER(@lV87Centrocostoswwds_17_tfcentrocostosnombre))");
         }
         else
         {
            GXv_int4[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV88Centrocostoswwds_18_tfcentrocostosnombre_sel)) && ! ( StringUtil.StrCmp(AV88Centrocostoswwds_18_tfcentrocostosnombre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([CentroCostosNombre] = @AV88Centrocostoswwds_18_tfcentrocostosnombre_sel)");
         }
         else
         {
            GXv_int4[11] = 1;
         }
         if ( StringUtil.StrCmp(AV88Centrocostoswwds_18_tfcentrocostosnombre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([CentroCostosNombre] = ''))");
         }
         if ( ! (Convert.ToDecimal(0)==AV89Centrocostoswwds_19_tfcentrocostospreciofinal) )
         {
            AddWhere(sWhereString, "([CentroCostosPrecioFinal] >= @AV89Centrocostoswwds_19_tfcentrocostospreciofinal)");
         }
         else
         {
            GXv_int4[12] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV90Centrocostoswwds_20_tfcentrocostospreciofinal_to) )
         {
            AddWhere(sWhereString, "([CentroCostosPrecioFinal] <= @AV90Centrocostoswwds_20_tfcentrocostospreciofinal_to)");
         }
         else
         {
            GXv_int4[13] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV91Centrocostoswwds_21_tfcentrocostoscosto) )
         {
            AddWhere(sWhereString, "([CentroCostosCosto] >= @AV91Centrocostoswwds_21_tfcentrocostoscosto)");
         }
         else
         {
            GXv_int4[14] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV92Centrocostoswwds_22_tfcentrocostoscosto_to) )
         {
            AddWhere(sWhereString, "([CentroCostosCosto] <= @AV92Centrocostoswwds_22_tfcentrocostoscosto_to)");
         }
         else
         {
            GXv_int4[15] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV93Centrocostoswwds_23_tfcentrocostosgam) )
         {
            AddWhere(sWhereString, "(( [CentroCostosPrecioFinal] - [CentroCostosCosto]) >= @AV93Centrocostoswwds_23_tfcentrocostosgam)");
         }
         else
         {
            GXv_int4[16] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV94Centrocostoswwds_24_tfcentrocostosgam_to) )
         {
            AddWhere(sWhereString, "(( [CentroCostosPrecioFinal] - [CentroCostosCosto]) <= @AV94Centrocostoswwds_24_tfcentrocostosgam_to)");
         }
         else
         {
            GXv_int4[17] = 1;
         }
         if ( AV95Centrocostoswwds_25_tfcentrocostosestado_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV95Centrocostoswwds_25_tfcentrocostosestado_sels, "[CentroCostosEstado] IN (", ")")+")");
         }
         if ( AV96Centrocostoswwds_26_tfcentrocostostiporef_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV96Centrocostoswwds_26_tfcentrocostostiporef_sels, "[CentroCostosTipoRef] IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         if ( ( AV17OrderedBy == 1 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY [CentroCostosNombre]";
         }
         else if ( ( AV17OrderedBy == 1 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [CentroCostosNombre] DESC";
         }
         else if ( ( AV17OrderedBy == 2 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY [CentroCostosId]";
         }
         else if ( ( AV17OrderedBy == 2 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [CentroCostosId] DESC";
         }
         else if ( ( AV17OrderedBy == 3 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY [CentroCostosRef]";
         }
         else if ( ( AV17OrderedBy == 3 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [CentroCostosRef] DESC";
         }
         else if ( ( AV17OrderedBy == 4 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY [CentroCostosPrecioFinal]";
         }
         else if ( ( AV17OrderedBy == 4 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [CentroCostosPrecioFinal] DESC";
         }
         else if ( ( AV17OrderedBy == 5 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY [CentroCostosCosto]";
         }
         else if ( ( AV17OrderedBy == 5 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [CentroCostosCosto] DESC";
         }
         else if ( ( AV17OrderedBy == 6 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY [CentroCostosEstado]";
         }
         else if ( ( AV17OrderedBy == 6 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [CentroCostosEstado] DESC";
         }
         else if ( ( AV17OrderedBy == 7 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY [CentroCostosTipoRef]";
         }
         else if ( ( AV17OrderedBy == 7 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [CentroCostosTipoRef] DESC";
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
                     return conditional_P005Y2(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (GxSimpleCollection<string>)dynConstraints[3] , (string)dynConstraints[4] , (short)dynConstraints[5] , (string)dynConstraints[6] , (bool)dynConstraints[7] , (string)dynConstraints[8] , (short)dynConstraints[9] , (string)dynConstraints[10] , (bool)dynConstraints[11] , (string)dynConstraints[12] , (short)dynConstraints[13] , (string)dynConstraints[14] , (long)dynConstraints[15] , (long)dynConstraints[16] , (long)dynConstraints[17] , (long)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (decimal)dynConstraints[21] , (decimal)dynConstraints[22] , (decimal)dynConstraints[23] , (decimal)dynConstraints[24] , (decimal)dynConstraints[25] , (decimal)dynConstraints[26] , (int)dynConstraints[27] , (int)dynConstraints[28] , (string)dynConstraints[29] , (long)dynConstraints[30] , (long)dynConstraints[31] , (decimal)dynConstraints[32] , (decimal)dynConstraints[33] , (short)dynConstraints[34] , (bool)dynConstraints[35] , (string)dynConstraints[36] , (decimal)dynConstraints[37] );
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
          Object[] prmP005Y2;
          prmP005Y2 = new Object[] {
          new ParDef("@lV74Centrocostoswwds_4_centrocostosnombre1",GXType.Char,80,0) ,
          new ParDef("@lV74Centrocostoswwds_4_centrocostosnombre1",GXType.Char,80,0) ,
          new ParDef("@lV78Centrocostoswwds_8_centrocostosnombre2",GXType.Char,80,0) ,
          new ParDef("@lV78Centrocostoswwds_8_centrocostosnombre2",GXType.Char,80,0) ,
          new ParDef("@lV82Centrocostoswwds_12_centrocostosnombre3",GXType.Char,80,0) ,
          new ParDef("@lV82Centrocostoswwds_12_centrocostosnombre3",GXType.Char,80,0) ,
          new ParDef("@AV83Centrocostoswwds_13_tfcentrocostosid",GXType.Decimal,18,0) ,
          new ParDef("@AV84Centrocostoswwds_14_tfcentrocostosid_to",GXType.Decimal,18,0) ,
          new ParDef("@AV85Centrocostoswwds_15_tfcentrocostosref",GXType.Decimal,18,0) ,
          new ParDef("@AV86Centrocostoswwds_16_tfcentrocostosref_to",GXType.Decimal,18,0) ,
          new ParDef("@lV87Centrocostoswwds_17_tfcentrocostosnombre",GXType.Char,80,0) ,
          new ParDef("@AV88Centrocostoswwds_18_tfcentrocostosnombre_sel",GXType.NChar,80,0) ,
          new ParDef("@AV89Centrocostoswwds_19_tfcentrocostospreciofinal",GXType.Decimal,18,2) ,
          new ParDef("@AV90Centrocostoswwds_20_tfcentrocostospreciofinal_to",GXType.Decimal,18,2) ,
          new ParDef("@AV91Centrocostoswwds_21_tfcentrocostoscosto",GXType.Decimal,18,2) ,
          new ParDef("@AV92Centrocostoswwds_22_tfcentrocostoscosto_to",GXType.Decimal,18,2) ,
          new ParDef("@AV93Centrocostoswwds_23_tfcentrocostosgam",GXType.Decimal,18,2) ,
          new ParDef("@AV94Centrocostoswwds_24_tfcentrocostosgam_to",GXType.Decimal,18,2)
          };
          def= new CursorDef[] {
              new CursorDef("P005Y2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP005Y2,100, GxCacheFrequency.OFF ,true,false )
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
                ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 80);
                ((long[]) buf[2])[0] = rslt.getLong(3);
                ((long[]) buf[3])[0] = rslt.getLong(4);
                ((string[]) buf[4])[0] = rslt.getString(5, 1);
                ((string[]) buf[5])[0] = rslt.getString(6, 3);
                ((decimal[]) buf[6])[0] = rslt.getDecimal(7);
                ((decimal[]) buf[7])[0] = rslt.getDecimal(8);
                return;
       }
    }

 }

}

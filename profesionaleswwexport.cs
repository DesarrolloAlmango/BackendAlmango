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
   public class profesionaleswwexport : GXProcedure
   {
      public profesionaleswwexport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public profesionaleswwexport( IGxContext context )
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
         new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWProfesionales", out  GXt_boolean1) ;
         AV8IsAuthorized = GXt_boolean1;
         if ( ! AV8IsAuthorized )
         {
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "wwpbaseobjects.notauthorized.aspx"+GXUtil.UrlEncode(StringUtil.RTrim(AV76Pgmname));
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
         AV12Filename = GXt_char2 + "ProfesionalesWWExport-" + StringUtil.Trim( StringUtil.Str( (decimal)(AV16Random), 8, 0)) + ".xlsx";
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
            if ( StringUtil.StrCmp(AV20DynamicFiltersSelector1, "PROFESIONALESESRUT") == 0 )
            {
               AV70ProfesionalesEsRUT1 = BooleanUtil.Val( AV31GridStateDynamicFilter.gxTpr_Value);
               if ( ! (false==AV70ProfesionalesEsRUT1) )
               {
                  AV14CellRow = (int)(AV14CellRow+1);
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Bold = 1;
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Color = 3;
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = context.GetMessage( "El Documento es RUT", "");
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Italic = 1;
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = StringUtil.BoolToStr( AV70ProfesionalesEsRUT1);
               }
            }
            else if ( StringUtil.StrCmp(AV20DynamicFiltersSelector1, "BANCONOMBRE") == 0 )
            {
               AV21DynamicFiltersOperator1 = AV31GridStateDynamicFilter.gxTpr_Operator;
               AV71BancoNombre1 = AV31GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71BancoNombre1)) )
               {
                  AV14CellRow = (int)(AV14CellRow+1);
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Bold = 1;
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Color = 3;
                  if ( AV21DynamicFiltersOperator1 == 0 )
                  {
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", context.GetMessage( "Nombre del Banco", ""), context.GetMessage( "WWP_FilterLike", ""), "", "", "", "", "", "", "");
                  }
                  else if ( AV21DynamicFiltersOperator1 == 1 )
                  {
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", context.GetMessage( "Nombre del Banco", ""), context.GetMessage( "WWP_FilterContains", ""), "", "", "", "", "", "", "");
                  }
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Italic = 1;
                  GXt_char2 = "";
                  new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV71BancoNombre1, out  GXt_char2) ;
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
               }
            }
            else if ( StringUtil.StrCmp(AV20DynamicFiltersSelector1, "PROFESIONALESPRIMERNOMBRE") == 0 )
            {
               AV21DynamicFiltersOperator1 = AV31GridStateDynamicFilter.gxTpr_Operator;
               AV22ProfesionalesPrimerNombre1 = AV31GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV22ProfesionalesPrimerNombre1)) )
               {
                  AV14CellRow = (int)(AV14CellRow+1);
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Bold = 1;
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Color = 3;
                  if ( AV21DynamicFiltersOperator1 == 0 )
                  {
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", context.GetMessage( "Primer Nombre", ""), context.GetMessage( "WWP_FilterLike", ""), "", "", "", "", "", "", "");
                  }
                  else if ( AV21DynamicFiltersOperator1 == 1 )
                  {
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", context.GetMessage( "Primer Nombre", ""), context.GetMessage( "WWP_FilterContains", ""), "", "", "", "", "", "", "");
                  }
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Italic = 1;
                  GXt_char2 = "";
                  new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV22ProfesionalesPrimerNombre1, out  GXt_char2) ;
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
               }
            }
            if ( AV34GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV23DynamicFiltersEnabled2 = true;
               AV31GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV34GridState.gxTpr_Dynamicfilters.Item(2));
               AV24DynamicFiltersSelector2 = AV31GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV24DynamicFiltersSelector2, "PROFESIONALESESRUT") == 0 )
               {
                  AV72ProfesionalesEsRUT2 = BooleanUtil.Val( AV31GridStateDynamicFilter.gxTpr_Value);
                  if ( ! (false==AV72ProfesionalesEsRUT2) )
                  {
                     AV14CellRow = (int)(AV14CellRow+1);
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Bold = 1;
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Color = 3;
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = context.GetMessage( "El Documento es RUT", "");
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Italic = 1;
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = StringUtil.BoolToStr( AV72ProfesionalesEsRUT2);
                  }
               }
               else if ( StringUtil.StrCmp(AV24DynamicFiltersSelector2, "BANCONOMBRE") == 0 )
               {
                  AV25DynamicFiltersOperator2 = AV31GridStateDynamicFilter.gxTpr_Operator;
                  AV73BancoNombre2 = AV31GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73BancoNombre2)) )
                  {
                     AV14CellRow = (int)(AV14CellRow+1);
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Bold = 1;
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Color = 3;
                     if ( AV25DynamicFiltersOperator2 == 0 )
                     {
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", context.GetMessage( "Nombre del Banco", ""), context.GetMessage( "WWP_FilterLike", ""), "", "", "", "", "", "", "");
                     }
                     else if ( AV25DynamicFiltersOperator2 == 1 )
                     {
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", context.GetMessage( "Nombre del Banco", ""), context.GetMessage( "WWP_FilterContains", ""), "", "", "", "", "", "", "");
                     }
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Italic = 1;
                     GXt_char2 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV73BancoNombre2, out  GXt_char2) ;
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
                  }
               }
               else if ( StringUtil.StrCmp(AV24DynamicFiltersSelector2, "PROFESIONALESPRIMERNOMBRE") == 0 )
               {
                  AV25DynamicFiltersOperator2 = AV31GridStateDynamicFilter.gxTpr_Operator;
                  AV26ProfesionalesPrimerNombre2 = AV31GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV26ProfesionalesPrimerNombre2)) )
                  {
                     AV14CellRow = (int)(AV14CellRow+1);
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Bold = 1;
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Color = 3;
                     if ( AV25DynamicFiltersOperator2 == 0 )
                     {
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", context.GetMessage( "Primer Nombre", ""), context.GetMessage( "WWP_FilterLike", ""), "", "", "", "", "", "", "");
                     }
                     else if ( AV25DynamicFiltersOperator2 == 1 )
                     {
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", context.GetMessage( "Primer Nombre", ""), context.GetMessage( "WWP_FilterContains", ""), "", "", "", "", "", "", "");
                     }
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Italic = 1;
                     GXt_char2 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV26ProfesionalesPrimerNombre2, out  GXt_char2) ;
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
                  }
               }
               if ( AV34GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV27DynamicFiltersEnabled3 = true;
                  AV31GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV34GridState.gxTpr_Dynamicfilters.Item(3));
                  AV28DynamicFiltersSelector3 = AV31GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV28DynamicFiltersSelector3, "PROFESIONALESESRUT") == 0 )
                  {
                     AV74ProfesionalesEsRUT3 = BooleanUtil.Val( AV31GridStateDynamicFilter.gxTpr_Value);
                     if ( ! (false==AV74ProfesionalesEsRUT3) )
                     {
                        AV14CellRow = (int)(AV14CellRow+1);
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Bold = 1;
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Color = 3;
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = context.GetMessage( "El Documento es RUT", "");
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Italic = 1;
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = StringUtil.BoolToStr( AV74ProfesionalesEsRUT3);
                     }
                  }
                  else if ( StringUtil.StrCmp(AV28DynamicFiltersSelector3, "BANCONOMBRE") == 0 )
                  {
                     AV29DynamicFiltersOperator3 = AV31GridStateDynamicFilter.gxTpr_Operator;
                     AV75BancoNombre3 = AV31GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75BancoNombre3)) )
                     {
                        AV14CellRow = (int)(AV14CellRow+1);
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Bold = 1;
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Color = 3;
                        if ( AV29DynamicFiltersOperator3 == 0 )
                        {
                           AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", context.GetMessage( "Nombre del Banco", ""), context.GetMessage( "WWP_FilterLike", ""), "", "", "", "", "", "", "");
                        }
                        else if ( AV29DynamicFiltersOperator3 == 1 )
                        {
                           AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", context.GetMessage( "Nombre del Banco", ""), context.GetMessage( "WWP_FilterContains", ""), "", "", "", "", "", "", "");
                        }
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Italic = 1;
                        GXt_char2 = "";
                        new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV75BancoNombre3, out  GXt_char2) ;
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
                     }
                  }
                  else if ( StringUtil.StrCmp(AV28DynamicFiltersSelector3, "PROFESIONALESPRIMERNOMBRE") == 0 )
                  {
                     AV29DynamicFiltersOperator3 = AV31GridStateDynamicFilter.gxTpr_Operator;
                     AV30ProfesionalesPrimerNombre3 = AV31GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV30ProfesionalesPrimerNombre3)) )
                     {
                        AV14CellRow = (int)(AV14CellRow+1);
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Bold = 1;
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Color = 3;
                        if ( AV29DynamicFiltersOperator3 == 0 )
                        {
                           AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", context.GetMessage( "Primer Nombre", ""), context.GetMessage( "WWP_FilterLike", ""), "", "", "", "", "", "", "");
                        }
                        else if ( AV29DynamicFiltersOperator3 == 1 )
                        {
                           AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", context.GetMessage( "Primer Nombre", ""), context.GetMessage( "WWP_FilterContains", ""), "", "", "", "", "", "", "");
                        }
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Italic = 1;
                        GXt_char2 = "";
                        new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV30ProfesionalesPrimerNombre3, out  GXt_char2) ;
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
                     }
                  }
               }
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV48TFProfesionalesId_Sel)) ) )
         {
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Identidad", "")) ;
            AV14CellRow = GXt_int3;
            GXt_char2 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV48TFProfesionalesId_Sel)) ? context.GetMessage( "WWP_TitleFilter_EmptyOption", "") : AV48TFProfesionalesId_Sel), out  GXt_char2) ;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV47TFProfesionalesId)) ) )
            {
               GXt_int3 = (short)(AV14CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Identidad", "")) ;
               AV14CellRow = GXt_int3;
               GXt_char2 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV47TFProfesionalesId, out  GXt_char2) ;
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV50TFProfesionalesPrimerNombre_Sel)) ) )
         {
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Primer Nombre", "")) ;
            AV14CellRow = GXt_int3;
            GXt_char2 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV50TFProfesionalesPrimerNombre_Sel)) ? context.GetMessage( "WWP_TitleFilter_EmptyOption", "") : AV50TFProfesionalesPrimerNombre_Sel), out  GXt_char2) ;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV49TFProfesionalesPrimerNombre)) ) )
            {
               GXt_int3 = (short)(AV14CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Primer Nombre", "")) ;
               AV14CellRow = GXt_int3;
               GXt_char2 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV49TFProfesionalesPrimerNombre, out  GXt_char2) ;
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV52TFProfesionalesSegundoNombre_Sel)) ) )
         {
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Segundo Nombre", "")) ;
            AV14CellRow = GXt_int3;
            GXt_char2 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV52TFProfesionalesSegundoNombre_Sel)) ? context.GetMessage( "WWP_TitleFilter_EmptyOption", "") : AV52TFProfesionalesSegundoNombre_Sel), out  GXt_char2) ;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV51TFProfesionalesSegundoNombre)) ) )
            {
               GXt_int3 = (short)(AV14CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Segundo Nombre", "")) ;
               AV14CellRow = GXt_int3;
               GXt_char2 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV51TFProfesionalesSegundoNombre, out  GXt_char2) ;
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV54TFProfesionalesApellidoPrimero_Sel)) ) )
         {
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Primer Apellido ", "")) ;
            AV14CellRow = GXt_int3;
            GXt_char2 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV54TFProfesionalesApellidoPrimero_Sel)) ? context.GetMessage( "WWP_TitleFilter_EmptyOption", "") : AV54TFProfesionalesApellidoPrimero_Sel), out  GXt_char2) ;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV53TFProfesionalesApellidoPrimero)) ) )
            {
               GXt_int3 = (short)(AV14CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Primer Apellido ", "")) ;
               AV14CellRow = GXt_int3;
               GXt_char2 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV53TFProfesionalesApellidoPrimero, out  GXt_char2) ;
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV56TFProfesionalesApellidoSegundo_Sel)) ) )
         {
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Segundo Apellido ", "")) ;
            AV14CellRow = GXt_int3;
            GXt_char2 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV56TFProfesionalesApellidoSegundo_Sel)) ? context.GetMessage( "WWP_TitleFilter_EmptyOption", "") : AV56TFProfesionalesApellidoSegundo_Sel), out  GXt_char2) ;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV55TFProfesionalesApellidoSegundo)) ) )
            {
               GXt_int3 = (short)(AV14CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Segundo Apellido ", "")) ;
               AV14CellRow = GXt_int3;
               GXt_char2 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV55TFProfesionalesApellidoSegundo, out  GXt_char2) ;
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV58TFProfesionalesTelefono_Sel)) ) )
         {
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Teléfono", "")) ;
            AV14CellRow = GXt_int3;
            GXt_char2 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV58TFProfesionalesTelefono_Sel)) ? context.GetMessage( "WWP_TitleFilter_EmptyOption", "") : AV58TFProfesionalesTelefono_Sel), out  GXt_char2) ;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV57TFProfesionalesTelefono)) ) )
            {
               GXt_int3 = (short)(AV14CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Teléfono", "")) ;
               AV14CellRow = GXt_int3;
               GXt_char2 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV57TFProfesionalesTelefono, out  GXt_char2) ;
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV60TFProfesionalesEmail_Sel)) ) )
         {
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Email", "")) ;
            AV14CellRow = GXt_int3;
            GXt_char2 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV60TFProfesionalesEmail_Sel)) ? context.GetMessage( "WWP_TitleFilter_EmptyOption", "") : AV60TFProfesionalesEmail_Sel), out  GXt_char2) ;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV59TFProfesionalesEmail)) ) )
            {
               GXt_int3 = (short)(AV14CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Email", "")) ;
               AV14CellRow = GXt_int3;
               GXt_char2 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV59TFProfesionalesEmail, out  GXt_char2) ;
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV62TFProfesionalesDireccion_Sel)) ) )
         {
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Dirección", "")) ;
            AV14CellRow = GXt_int3;
            GXt_char2 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV62TFProfesionalesDireccion_Sel)) ? context.GetMessage( "WWP_TitleFilter_EmptyOption", "") : AV62TFProfesionalesDireccion_Sel), out  GXt_char2) ;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV61TFProfesionalesDireccion)) ) )
            {
               GXt_int3 = (short)(AV14CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Dirección", "")) ;
               AV14CellRow = GXt_int3;
               GXt_char2 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV61TFProfesionalesDireccion, out  GXt_char2) ;
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV69TFEstadosGenericosNombre_Sel)) ) )
         {
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Estado", "")) ;
            AV14CellRow = GXt_int3;
            GXt_char2 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV69TFEstadosGenericosNombre_Sel)) ? context.GetMessage( "WWP_TitleFilter_EmptyOption", "") : AV69TFEstadosGenericosNombre_Sel), out  GXt_char2) ;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV68TFEstadosGenericosNombre)) ) )
            {
               GXt_int3 = (short)(AV14CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Estado", "")) ;
               AV14CellRow = GXt_int3;
               GXt_char2 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV68TFEstadosGenericosNombre, out  GXt_char2) ;
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
            }
         }
         AV14CellRow = (int)(AV14CellRow+2);
      }

      protected void S141( )
      {
         /* 'WRITECOLUMNTITLES' Routine */
         returnInSub = false;
         AV44VisibleColumnCount = 0;
         if ( StringUtil.StrCmp(AV32Session.Get("ProfesionalesWWColumnsSelector"), "") != 0 )
         {
            AV39ColumnsSelectorXML = AV32Session.Get("ProfesionalesWWColumnsSelector");
            AV36ColumnsSelector.FromXml(AV39ColumnsSelectorXML, null, "", "");
         }
         else
         {
            /* Execute user subroutine: 'INITIALIZECOLUMNSSELECTOR' */
            S151 ();
            if (returnInSub) return;
         }
         AV36ColumnsSelector.gxTpr_Columns.Sort("Order");
         AV77GXV1 = 1;
         while ( AV77GXV1 <= AV36ColumnsSelector.gxTpr_Columns.Count )
         {
            AV38ColumnsSelector_Column = ((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV36ColumnsSelector.gxTpr_Columns.Item(AV77GXV1));
            if ( AV38ColumnsSelector_Column.gxTpr_Isvisible )
            {
               AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV44VisibleColumnCount), 1, 1).Text = context.GetMessage( (String.IsNullOrEmpty(StringUtil.RTrim( AV38ColumnsSelector_Column.gxTpr_Displayname)) ? AV38ColumnsSelector_Column.gxTpr_Columnname : AV38ColumnsSelector_Column.gxTpr_Displayname), "");
               AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV44VisibleColumnCount), 1, 1).Bold = 1;
               AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV44VisibleColumnCount), 1, 1).Color = 11;
               AV44VisibleColumnCount = (long)(AV44VisibleColumnCount+1);
            }
            AV77GXV1 = (int)(AV77GXV1+1);
         }
      }

      protected void S161( )
      {
         /* 'WRITEDATA' Routine */
         returnInSub = false;
         AV79Profesionaleswwds_1_filterfulltext = AV19FilterFullText;
         AV80Profesionaleswwds_2_dynamicfiltersselector1 = AV20DynamicFiltersSelector1;
         AV81Profesionaleswwds_3_dynamicfiltersoperator1 = AV21DynamicFiltersOperator1;
         AV82Profesionaleswwds_4_profesionalesesrut1 = AV70ProfesionalesEsRUT1;
         AV83Profesionaleswwds_5_banconombre1 = AV71BancoNombre1;
         AV84Profesionaleswwds_6_profesionalesprimernombre1 = AV22ProfesionalesPrimerNombre1;
         AV85Profesionaleswwds_7_dynamicfiltersenabled2 = AV23DynamicFiltersEnabled2;
         AV86Profesionaleswwds_8_dynamicfiltersselector2 = AV24DynamicFiltersSelector2;
         AV87Profesionaleswwds_9_dynamicfiltersoperator2 = AV25DynamicFiltersOperator2;
         AV88Profesionaleswwds_10_profesionalesesrut2 = AV72ProfesionalesEsRUT2;
         AV89Profesionaleswwds_11_banconombre2 = AV73BancoNombre2;
         AV90Profesionaleswwds_12_profesionalesprimernombre2 = AV26ProfesionalesPrimerNombre2;
         AV91Profesionaleswwds_13_dynamicfiltersenabled3 = AV27DynamicFiltersEnabled3;
         AV92Profesionaleswwds_14_dynamicfiltersselector3 = AV28DynamicFiltersSelector3;
         AV93Profesionaleswwds_15_dynamicfiltersoperator3 = AV29DynamicFiltersOperator3;
         AV94Profesionaleswwds_16_profesionalesesrut3 = AV74ProfesionalesEsRUT3;
         AV95Profesionaleswwds_17_banconombre3 = AV75BancoNombre3;
         AV96Profesionaleswwds_18_profesionalesprimernombre3 = AV30ProfesionalesPrimerNombre3;
         AV97Profesionaleswwds_19_tfprofesionalesid = AV47TFProfesionalesId;
         AV98Profesionaleswwds_20_tfprofesionalesid_sel = AV48TFProfesionalesId_Sel;
         AV99Profesionaleswwds_21_tfprofesionalesprimernombre = AV49TFProfesionalesPrimerNombre;
         AV100Profesionaleswwds_22_tfprofesionalesprimernombre_sel = AV50TFProfesionalesPrimerNombre_Sel;
         AV101Profesionaleswwds_23_tfprofesionalessegundonombre = AV51TFProfesionalesSegundoNombre;
         AV102Profesionaleswwds_24_tfprofesionalessegundonombre_sel = AV52TFProfesionalesSegundoNombre_Sel;
         AV103Profesionaleswwds_25_tfprofesionalesapellidoprimero = AV53TFProfesionalesApellidoPrimero;
         AV104Profesionaleswwds_26_tfprofesionalesapellidoprimero_sel = AV54TFProfesionalesApellidoPrimero_Sel;
         AV105Profesionaleswwds_27_tfprofesionalesapellidosegundo = AV55TFProfesionalesApellidoSegundo;
         AV106Profesionaleswwds_28_tfprofesionalesapellidosegundo_sel = AV56TFProfesionalesApellidoSegundo_Sel;
         AV107Profesionaleswwds_29_tfprofesionalestelefono = AV57TFProfesionalesTelefono;
         AV108Profesionaleswwds_30_tfprofesionalestelefono_sel = AV58TFProfesionalesTelefono_Sel;
         AV109Profesionaleswwds_31_tfprofesionalesemail = AV59TFProfesionalesEmail;
         AV110Profesionaleswwds_32_tfprofesionalesemail_sel = AV60TFProfesionalesEmail_Sel;
         AV111Profesionaleswwds_33_tfprofesionalesdireccion = AV61TFProfesionalesDireccion;
         AV112Profesionaleswwds_34_tfprofesionalesdireccion_sel = AV62TFProfesionalesDireccion_Sel;
         AV113Profesionaleswwds_35_tfestadosgenericosnombre = AV68TFEstadosGenericosNombre;
         AV114Profesionaleswwds_36_tfestadosgenericosnombre_sel = AV69TFEstadosGenericosNombre_Sel;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV79Profesionaleswwds_1_filterfulltext ,
                                              AV80Profesionaleswwds_2_dynamicfiltersselector1 ,
                                              AV82Profesionaleswwds_4_profesionalesesrut1 ,
                                              AV81Profesionaleswwds_3_dynamicfiltersoperator1 ,
                                              AV83Profesionaleswwds_5_banconombre1 ,
                                              AV84Profesionaleswwds_6_profesionalesprimernombre1 ,
                                              AV85Profesionaleswwds_7_dynamicfiltersenabled2 ,
                                              AV86Profesionaleswwds_8_dynamicfiltersselector2 ,
                                              AV88Profesionaleswwds_10_profesionalesesrut2 ,
                                              AV87Profesionaleswwds_9_dynamicfiltersoperator2 ,
                                              AV89Profesionaleswwds_11_banconombre2 ,
                                              AV90Profesionaleswwds_12_profesionalesprimernombre2 ,
                                              AV91Profesionaleswwds_13_dynamicfiltersenabled3 ,
                                              AV92Profesionaleswwds_14_dynamicfiltersselector3 ,
                                              AV94Profesionaleswwds_16_profesionalesesrut3 ,
                                              AV93Profesionaleswwds_15_dynamicfiltersoperator3 ,
                                              AV95Profesionaleswwds_17_banconombre3 ,
                                              AV96Profesionaleswwds_18_profesionalesprimernombre3 ,
                                              AV98Profesionaleswwds_20_tfprofesionalesid_sel ,
                                              AV97Profesionaleswwds_19_tfprofesionalesid ,
                                              AV100Profesionaleswwds_22_tfprofesionalesprimernombre_sel ,
                                              AV99Profesionaleswwds_21_tfprofesionalesprimernombre ,
                                              AV102Profesionaleswwds_24_tfprofesionalessegundonombre_sel ,
                                              AV101Profesionaleswwds_23_tfprofesionalessegundonombre ,
                                              AV104Profesionaleswwds_26_tfprofesionalesapellidoprimero_sel ,
                                              AV103Profesionaleswwds_25_tfprofesionalesapellidoprimero ,
                                              AV106Profesionaleswwds_28_tfprofesionalesapellidosegundo_sel ,
                                              AV105Profesionaleswwds_27_tfprofesionalesapellidosegundo ,
                                              AV108Profesionaleswwds_30_tfprofesionalestelefono_sel ,
                                              AV107Profesionaleswwds_29_tfprofesionalestelefono ,
                                              AV110Profesionaleswwds_32_tfprofesionalesemail_sel ,
                                              AV109Profesionaleswwds_31_tfprofesionalesemail ,
                                              AV112Profesionaleswwds_34_tfprofesionalesdireccion_sel ,
                                              AV111Profesionaleswwds_33_tfprofesionalesdireccion ,
                                              AV114Profesionaleswwds_36_tfestadosgenericosnombre_sel ,
                                              AV113Profesionaleswwds_35_tfestadosgenericosnombre ,
                                              A120ProfesionalesId ,
                                              A166ProfesionalesPrimerNombre ,
                                              A191ProfesionalesSegundoNombre ,
                                              A167ProfesionalesApellidoPrimero ,
                                              A192ProfesionalesApellidoSegundo ,
                                              A170ProfesionalesTelefono ,
                                              A676ProfesionalesEsRUT ,
                                              A674BancoNombre ,
                                              A193ProfesionalesEmail ,
                                              A198ProfesionalesDireccion ,
                                              A109EstadosGenericosNombre ,
                                              AV17OrderedBy ,
                                              AV18OrderedDsc } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN,
                                              TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV79Profesionaleswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV79Profesionaleswwds_1_filterfulltext), "%", "");
         lV79Profesionaleswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV79Profesionaleswwds_1_filterfulltext), "%", "");
         lV79Profesionaleswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV79Profesionaleswwds_1_filterfulltext), "%", "");
         lV79Profesionaleswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV79Profesionaleswwds_1_filterfulltext), "%", "");
         lV79Profesionaleswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV79Profesionaleswwds_1_filterfulltext), "%", "");
         lV79Profesionaleswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV79Profesionaleswwds_1_filterfulltext), "%", "");
         lV83Profesionaleswwds_5_banconombre1 = StringUtil.PadR( StringUtil.RTrim( AV83Profesionaleswwds_5_banconombre1), 80, "%");
         lV83Profesionaleswwds_5_banconombre1 = StringUtil.PadR( StringUtil.RTrim( AV83Profesionaleswwds_5_banconombre1), 80, "%");
         lV84Profesionaleswwds_6_profesionalesprimernombre1 = StringUtil.PadR( StringUtil.RTrim( AV84Profesionaleswwds_6_profesionalesprimernombre1), 30, "%");
         lV84Profesionaleswwds_6_profesionalesprimernombre1 = StringUtil.PadR( StringUtil.RTrim( AV84Profesionaleswwds_6_profesionalesprimernombre1), 30, "%");
         lV89Profesionaleswwds_11_banconombre2 = StringUtil.PadR( StringUtil.RTrim( AV89Profesionaleswwds_11_banconombre2), 80, "%");
         lV89Profesionaleswwds_11_banconombre2 = StringUtil.PadR( StringUtil.RTrim( AV89Profesionaleswwds_11_banconombre2), 80, "%");
         lV90Profesionaleswwds_12_profesionalesprimernombre2 = StringUtil.PadR( StringUtil.RTrim( AV90Profesionaleswwds_12_profesionalesprimernombre2), 30, "%");
         lV90Profesionaleswwds_12_profesionalesprimernombre2 = StringUtil.PadR( StringUtil.RTrim( AV90Profesionaleswwds_12_profesionalesprimernombre2), 30, "%");
         lV95Profesionaleswwds_17_banconombre3 = StringUtil.PadR( StringUtil.RTrim( AV95Profesionaleswwds_17_banconombre3), 80, "%");
         lV95Profesionaleswwds_17_banconombre3 = StringUtil.PadR( StringUtil.RTrim( AV95Profesionaleswwds_17_banconombre3), 80, "%");
         lV96Profesionaleswwds_18_profesionalesprimernombre3 = StringUtil.PadR( StringUtil.RTrim( AV96Profesionaleswwds_18_profesionalesprimernombre3), 30, "%");
         lV96Profesionaleswwds_18_profesionalesprimernombre3 = StringUtil.PadR( StringUtil.RTrim( AV96Profesionaleswwds_18_profesionalesprimernombre3), 30, "%");
         lV97Profesionaleswwds_19_tfprofesionalesid = StringUtil.PadR( StringUtil.RTrim( AV97Profesionaleswwds_19_tfprofesionalesid), 20, "%");
         lV99Profesionaleswwds_21_tfprofesionalesprimernombre = StringUtil.PadR( StringUtil.RTrim( AV99Profesionaleswwds_21_tfprofesionalesprimernombre), 30, "%");
         lV101Profesionaleswwds_23_tfprofesionalessegundonombre = StringUtil.PadR( StringUtil.RTrim( AV101Profesionaleswwds_23_tfprofesionalessegundonombre), 30, "%");
         lV103Profesionaleswwds_25_tfprofesionalesapellidoprimero = StringUtil.PadR( StringUtil.RTrim( AV103Profesionaleswwds_25_tfprofesionalesapellidoprimero), 30, "%");
         lV105Profesionaleswwds_27_tfprofesionalesapellidosegundo = StringUtil.PadR( StringUtil.RTrim( AV105Profesionaleswwds_27_tfprofesionalesapellidosegundo), 30, "%");
         lV107Profesionaleswwds_29_tfprofesionalestelefono = StringUtil.PadR( StringUtil.RTrim( AV107Profesionaleswwds_29_tfprofesionalestelefono), 20, "%");
         lV109Profesionaleswwds_31_tfprofesionalesemail = StringUtil.Concat( StringUtil.RTrim( AV109Profesionaleswwds_31_tfprofesionalesemail), "%", "");
         lV111Profesionaleswwds_33_tfprofesionalesdireccion = StringUtil.Concat( StringUtil.RTrim( AV111Profesionaleswwds_33_tfprofesionalesdireccion), "%", "");
         lV113Profesionaleswwds_35_tfestadosgenericosnombre = StringUtil.PadR( StringUtil.RTrim( AV113Profesionaleswwds_35_tfestadosgenericosnombre), 80, "%");
         /* Using cursor P00AV2 */
         pr_default.execute(0, new Object[] {lV79Profesionaleswwds_1_filterfulltext, lV79Profesionaleswwds_1_filterfulltext, lV79Profesionaleswwds_1_filterfulltext, lV79Profesionaleswwds_1_filterfulltext, lV79Profesionaleswwds_1_filterfulltext, lV79Profesionaleswwds_1_filterfulltext, AV82Profesionaleswwds_4_profesionalesesrut1, lV83Profesionaleswwds_5_banconombre1, lV83Profesionaleswwds_5_banconombre1, lV84Profesionaleswwds_6_profesionalesprimernombre1, lV84Profesionaleswwds_6_profesionalesprimernombre1, AV88Profesionaleswwds_10_profesionalesesrut2, lV89Profesionaleswwds_11_banconombre2, lV89Profesionaleswwds_11_banconombre2, lV90Profesionaleswwds_12_profesionalesprimernombre2, lV90Profesionaleswwds_12_profesionalesprimernombre2, AV94Profesionaleswwds_16_profesionalesesrut3, lV95Profesionaleswwds_17_banconombre3, lV95Profesionaleswwds_17_banconombre3, lV96Profesionaleswwds_18_profesionalesprimernombre3, lV96Profesionaleswwds_18_profesionalesprimernombre3, lV97Profesionaleswwds_19_tfprofesionalesid, AV98Profesionaleswwds_20_tfprofesionalesid_sel, lV99Profesionaleswwds_21_tfprofesionalesprimernombre, AV100Profesionaleswwds_22_tfprofesionalesprimernombre_sel, lV101Profesionaleswwds_23_tfprofesionalessegundonombre, AV102Profesionaleswwds_24_tfprofesionalessegundonombre_sel, lV103Profesionaleswwds_25_tfprofesionalesapellidoprimero, AV104Profesionaleswwds_26_tfprofesionalesapellidoprimero_sel, lV105Profesionaleswwds_27_tfprofesionalesapellidosegundo, AV106Profesionaleswwds_28_tfprofesionalesapellidosegundo_sel, lV107Profesionaleswwds_29_tfprofesionalestelefono, AV108Profesionaleswwds_30_tfprofesionalestelefono_sel, lV109Profesionaleswwds_31_tfprofesionalesemail, AV110Profesionaleswwds_32_tfprofesionalesemail_sel, lV111Profesionaleswwds_33_tfprofesionalesdireccion, AV112Profesionaleswwds_34_tfprofesionalesdireccion_sel, lV113Profesionaleswwds_35_tfestadosgenericosnombre, AV114Profesionaleswwds_36_tfestadosgenericosnombre_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A107EstadosTipo = P00AV2_A107EstadosTipo[0];
            A673BancoId = P00AV2_A673BancoId[0];
            n673BancoId = P00AV2_n673BancoId[0];
            A674BancoNombre = P00AV2_A674BancoNombre[0];
            A109EstadosGenericosNombre = P00AV2_A109EstadosGenericosNombre[0];
            A198ProfesionalesDireccion = P00AV2_A198ProfesionalesDireccion[0];
            A193ProfesionalesEmail = P00AV2_A193ProfesionalesEmail[0];
            n193ProfesionalesEmail = P00AV2_n193ProfesionalesEmail[0];
            A170ProfesionalesTelefono = P00AV2_A170ProfesionalesTelefono[0];
            A192ProfesionalesApellidoSegundo = P00AV2_A192ProfesionalesApellidoSegundo[0];
            A167ProfesionalesApellidoPrimero = P00AV2_A167ProfesionalesApellidoPrimero[0];
            A191ProfesionalesSegundoNombre = P00AV2_A191ProfesionalesSegundoNombre[0];
            A166ProfesionalesPrimerNombre = P00AV2_A166ProfesionalesPrimerNombre[0];
            A120ProfesionalesId = P00AV2_A120ProfesionalesId[0];
            A676ProfesionalesEsRUT = P00AV2_A676ProfesionalesEsRUT[0];
            n676ProfesionalesEsRUT = P00AV2_n676ProfesionalesEsRUT[0];
            A108EstadosGenericosId = P00AV2_A108EstadosGenericosId[0];
            A674BancoNombre = P00AV2_A674BancoNombre[0];
            A109EstadosGenericosNombre = P00AV2_A109EstadosGenericosNombre[0];
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
            AV115GXV2 = 1;
            while ( AV115GXV2 <= AV36ColumnsSelector.gxTpr_Columns.Count )
            {
               AV38ColumnsSelector_Column = ((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV36ColumnsSelector.gxTpr_Columns.Item(AV115GXV2));
               if ( AV38ColumnsSelector_Column.gxTpr_Isvisible )
               {
                  if ( StringUtil.StrCmp(AV38ColumnsSelector_Column.gxTpr_Columnname, "ProfesionalesId") == 0 )
                  {
                     GXt_char2 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A120ProfesionalesId, out  GXt_char2) ;
                     AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV44VisibleColumnCount), 1, 1).Text = GXt_char2;
                  }
                  else if ( StringUtil.StrCmp(AV38ColumnsSelector_Column.gxTpr_Columnname, "ProfesionalesPrimerNombre") == 0 )
                  {
                     GXt_char2 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A166ProfesionalesPrimerNombre, out  GXt_char2) ;
                     AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV44VisibleColumnCount), 1, 1).Text = GXt_char2;
                  }
                  else if ( StringUtil.StrCmp(AV38ColumnsSelector_Column.gxTpr_Columnname, "ProfesionalesSegundoNombre") == 0 )
                  {
                     GXt_char2 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A191ProfesionalesSegundoNombre, out  GXt_char2) ;
                     AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV44VisibleColumnCount), 1, 1).Text = GXt_char2;
                  }
                  else if ( StringUtil.StrCmp(AV38ColumnsSelector_Column.gxTpr_Columnname, "ProfesionalesApellidoPrimero") == 0 )
                  {
                     GXt_char2 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A167ProfesionalesApellidoPrimero, out  GXt_char2) ;
                     AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV44VisibleColumnCount), 1, 1).Text = GXt_char2;
                  }
                  else if ( StringUtil.StrCmp(AV38ColumnsSelector_Column.gxTpr_Columnname, "ProfesionalesApellidoSegundo") == 0 )
                  {
                     GXt_char2 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A192ProfesionalesApellidoSegundo, out  GXt_char2) ;
                     AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV44VisibleColumnCount), 1, 1).Text = GXt_char2;
                  }
                  else if ( StringUtil.StrCmp(AV38ColumnsSelector_Column.gxTpr_Columnname, "ProfesionalesTelefono") == 0 )
                  {
                     GXt_char2 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A170ProfesionalesTelefono, out  GXt_char2) ;
                     AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV44VisibleColumnCount), 1, 1).Text = GXt_char2;
                  }
                  else if ( StringUtil.StrCmp(AV38ColumnsSelector_Column.gxTpr_Columnname, "ProfesionalesEmail") == 0 )
                  {
                     GXt_char2 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A193ProfesionalesEmail, out  GXt_char2) ;
                     AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV44VisibleColumnCount), 1, 1).Text = GXt_char2;
                  }
                  else if ( StringUtil.StrCmp(AV38ColumnsSelector_Column.gxTpr_Columnname, "ProfesionalesDireccion") == 0 )
                  {
                     GXt_char2 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A198ProfesionalesDireccion, out  GXt_char2) ;
                     AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV44VisibleColumnCount), 1, 1).Text = GXt_char2;
                  }
                  else if ( StringUtil.StrCmp(AV38ColumnsSelector_Column.gxTpr_Columnname, "EstadosGenericosNombre") == 0 )
                  {
                     GXt_char2 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A109EstadosGenericosNombre, out  GXt_char2) ;
                     AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV44VisibleColumnCount), 1, 1).Text = GXt_char2;
                  }
                  AV44VisibleColumnCount = (long)(AV44VisibleColumnCount+1);
               }
               AV115GXV2 = (int)(AV115GXV2+1);
            }
            if ( A108EstadosGenericosId == 2 )
            {
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, (int)(AV44VisibleColumnCount)).Color = GXUtil.RGB( 221, 75, 57);
            }
            else if ( A108EstadosGenericosId == 3 )
            {
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, (int)(AV44VisibleColumnCount)).Color = GXUtil.RGB( 251, 110, 82);
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
         AV32Session.Set("WWPExportFilePath", AV12Filename);
         AV32Session.Set("WWPExportFileName", "ProfesionalesWWExport.xlsx");
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
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV36ColumnsSelector,  "ProfesionalesId",  "",  "Identidad",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV36ColumnsSelector,  "ProfesionalesPrimerNombre",  "",  "Primer Nombre",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV36ColumnsSelector,  "ProfesionalesSegundoNombre",  "",  "Segundo Nombre",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV36ColumnsSelector,  "ProfesionalesApellidoPrimero",  "",  "Primer Apellido ",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV36ColumnsSelector,  "ProfesionalesApellidoSegundo",  "",  "Segundo Apellido ",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV36ColumnsSelector,  "ProfesionalesTelefono",  "",  "Teléfono",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV36ColumnsSelector,  "ProfesionalesEmail",  "",  "Email",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV36ColumnsSelector,  "ProfesionalesDireccion",  "",  "Dirección",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV36ColumnsSelector,  "EstadosGenericosNombre",  "",  "Estado",  true,  "") ;
         GXt_char2 = AV40UserCustomValue;
         new GeneXus.Programs.wwpbaseobjects.loadcolumnsselectorstate(context ).execute(  "ProfesionalesWWColumnsSelector", out  GXt_char2) ;
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
         if ( StringUtil.StrCmp(AV32Session.Get("ProfesionalesWWGridState"), "") == 0 )
         {
            AV34GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "ProfesionalesWWGridState"), null, "", "");
         }
         else
         {
            AV34GridState.FromXml(AV32Session.Get("ProfesionalesWWGridState"), null, "", "");
         }
         AV17OrderedBy = AV34GridState.gxTpr_Orderedby;
         AV18OrderedDsc = AV34GridState.gxTpr_Ordereddsc;
         AV116GXV3 = 1;
         while ( AV116GXV3 <= AV34GridState.gxTpr_Filtervalues.Count )
         {
            AV35GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV34GridState.gxTpr_Filtervalues.Item(AV116GXV3));
            if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV19FilterFullText = AV35GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFPROFESIONALESID") == 0 )
            {
               AV47TFProfesionalesId = AV35GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFPROFESIONALESID_SEL") == 0 )
            {
               AV48TFProfesionalesId_Sel = AV35GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFPROFESIONALESPRIMERNOMBRE") == 0 )
            {
               AV49TFProfesionalesPrimerNombre = AV35GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFPROFESIONALESPRIMERNOMBRE_SEL") == 0 )
            {
               AV50TFProfesionalesPrimerNombre_Sel = AV35GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFPROFESIONALESSEGUNDONOMBRE") == 0 )
            {
               AV51TFProfesionalesSegundoNombre = AV35GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFPROFESIONALESSEGUNDONOMBRE_SEL") == 0 )
            {
               AV52TFProfesionalesSegundoNombre_Sel = AV35GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFPROFESIONALESAPELLIDOPRIMERO") == 0 )
            {
               AV53TFProfesionalesApellidoPrimero = AV35GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFPROFESIONALESAPELLIDOPRIMERO_SEL") == 0 )
            {
               AV54TFProfesionalesApellidoPrimero_Sel = AV35GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFPROFESIONALESAPELLIDOSEGUNDO") == 0 )
            {
               AV55TFProfesionalesApellidoSegundo = AV35GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFPROFESIONALESAPELLIDOSEGUNDO_SEL") == 0 )
            {
               AV56TFProfesionalesApellidoSegundo_Sel = AV35GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFPROFESIONALESTELEFONO") == 0 )
            {
               AV57TFProfesionalesTelefono = AV35GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFPROFESIONALESTELEFONO_SEL") == 0 )
            {
               AV58TFProfesionalesTelefono_Sel = AV35GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFPROFESIONALESEMAIL") == 0 )
            {
               AV59TFProfesionalesEmail = AV35GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFPROFESIONALESEMAIL_SEL") == 0 )
            {
               AV60TFProfesionalesEmail_Sel = AV35GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFPROFESIONALESDIRECCION") == 0 )
            {
               AV61TFProfesionalesDireccion = AV35GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFPROFESIONALESDIRECCION_SEL") == 0 )
            {
               AV62TFProfesionalesDireccion_Sel = AV35GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFESTADOSGENERICOSNOMBRE") == 0 )
            {
               AV68TFEstadosGenericosNombre = AV35GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFESTADOSGENERICOSNOMBRE_SEL") == 0 )
            {
               AV69TFEstadosGenericosNombre_Sel = AV35GridStateFilterValue.gxTpr_Value;
            }
            AV116GXV3 = (int)(AV116GXV3+1);
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
         AV76Pgmname = "";
         GXKey = "";
         GXEncryptionTmp = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV11ExcelDocument = new ExcelDocumentI();
         AV19FilterFullText = "";
         AV34GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV31GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV20DynamicFiltersSelector1 = "";
         AV71BancoNombre1 = "";
         AV22ProfesionalesPrimerNombre1 = "";
         AV24DynamicFiltersSelector2 = "";
         AV73BancoNombre2 = "";
         AV26ProfesionalesPrimerNombre2 = "";
         AV28DynamicFiltersSelector3 = "";
         AV75BancoNombre3 = "";
         AV30ProfesionalesPrimerNombre3 = "";
         AV48TFProfesionalesId_Sel = "";
         AV47TFProfesionalesId = "";
         AV50TFProfesionalesPrimerNombre_Sel = "";
         AV49TFProfesionalesPrimerNombre = "";
         AV52TFProfesionalesSegundoNombre_Sel = "";
         AV51TFProfesionalesSegundoNombre = "";
         AV54TFProfesionalesApellidoPrimero_Sel = "";
         AV53TFProfesionalesApellidoPrimero = "";
         AV56TFProfesionalesApellidoSegundo_Sel = "";
         AV55TFProfesionalesApellidoSegundo = "";
         AV58TFProfesionalesTelefono_Sel = "";
         AV57TFProfesionalesTelefono = "";
         AV60TFProfesionalesEmail_Sel = "";
         AV59TFProfesionalesEmail = "";
         AV62TFProfesionalesDireccion_Sel = "";
         AV61TFProfesionalesDireccion = "";
         AV69TFEstadosGenericosNombre_Sel = "";
         AV68TFEstadosGenericosNombre = "";
         AV32Session = context.GetSession();
         AV39ColumnsSelectorXML = "";
         AV36ColumnsSelector = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector(context);
         AV38ColumnsSelector_Column = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column(context);
         AV79Profesionaleswwds_1_filterfulltext = "";
         AV80Profesionaleswwds_2_dynamicfiltersselector1 = "";
         AV83Profesionaleswwds_5_banconombre1 = "";
         AV84Profesionaleswwds_6_profesionalesprimernombre1 = "";
         AV86Profesionaleswwds_8_dynamicfiltersselector2 = "";
         AV89Profesionaleswwds_11_banconombre2 = "";
         AV90Profesionaleswwds_12_profesionalesprimernombre2 = "";
         AV92Profesionaleswwds_14_dynamicfiltersselector3 = "";
         AV95Profesionaleswwds_17_banconombre3 = "";
         AV96Profesionaleswwds_18_profesionalesprimernombre3 = "";
         AV97Profesionaleswwds_19_tfprofesionalesid = "";
         AV98Profesionaleswwds_20_tfprofesionalesid_sel = "";
         AV99Profesionaleswwds_21_tfprofesionalesprimernombre = "";
         AV100Profesionaleswwds_22_tfprofesionalesprimernombre_sel = "";
         AV101Profesionaleswwds_23_tfprofesionalessegundonombre = "";
         AV102Profesionaleswwds_24_tfprofesionalessegundonombre_sel = "";
         AV103Profesionaleswwds_25_tfprofesionalesapellidoprimero = "";
         AV104Profesionaleswwds_26_tfprofesionalesapellidoprimero_sel = "";
         AV105Profesionaleswwds_27_tfprofesionalesapellidosegundo = "";
         AV106Profesionaleswwds_28_tfprofesionalesapellidosegundo_sel = "";
         AV107Profesionaleswwds_29_tfprofesionalestelefono = "";
         AV108Profesionaleswwds_30_tfprofesionalestelefono_sel = "";
         AV109Profesionaleswwds_31_tfprofesionalesemail = "";
         AV110Profesionaleswwds_32_tfprofesionalesemail_sel = "";
         AV111Profesionaleswwds_33_tfprofesionalesdireccion = "";
         AV112Profesionaleswwds_34_tfprofesionalesdireccion_sel = "";
         AV113Profesionaleswwds_35_tfestadosgenericosnombre = "";
         AV114Profesionaleswwds_36_tfestadosgenericosnombre_sel = "";
         lV79Profesionaleswwds_1_filterfulltext = "";
         lV83Profesionaleswwds_5_banconombre1 = "";
         lV84Profesionaleswwds_6_profesionalesprimernombre1 = "";
         lV89Profesionaleswwds_11_banconombre2 = "";
         lV90Profesionaleswwds_12_profesionalesprimernombre2 = "";
         lV95Profesionaleswwds_17_banconombre3 = "";
         lV96Profesionaleswwds_18_profesionalesprimernombre3 = "";
         lV97Profesionaleswwds_19_tfprofesionalesid = "";
         lV99Profesionaleswwds_21_tfprofesionalesprimernombre = "";
         lV101Profesionaleswwds_23_tfprofesionalessegundonombre = "";
         lV103Profesionaleswwds_25_tfprofesionalesapellidoprimero = "";
         lV105Profesionaleswwds_27_tfprofesionalesapellidosegundo = "";
         lV107Profesionaleswwds_29_tfprofesionalestelefono = "";
         lV109Profesionaleswwds_31_tfprofesionalesemail = "";
         lV111Profesionaleswwds_33_tfprofesionalesdireccion = "";
         lV113Profesionaleswwds_35_tfestadosgenericosnombre = "";
         A120ProfesionalesId = "";
         A166ProfesionalesPrimerNombre = "";
         A191ProfesionalesSegundoNombre = "";
         A167ProfesionalesApellidoPrimero = "";
         A192ProfesionalesApellidoSegundo = "";
         A170ProfesionalesTelefono = "";
         A674BancoNombre = "";
         A193ProfesionalesEmail = "";
         A198ProfesionalesDireccion = "";
         A109EstadosGenericosNombre = "";
         P00AV2_A107EstadosTipo = new string[] {""} ;
         P00AV2_A673BancoId = new long[1] ;
         P00AV2_n673BancoId = new bool[] {false} ;
         P00AV2_A674BancoNombre = new string[] {""} ;
         P00AV2_A109EstadosGenericosNombre = new string[] {""} ;
         P00AV2_A198ProfesionalesDireccion = new string[] {""} ;
         P00AV2_A193ProfesionalesEmail = new string[] {""} ;
         P00AV2_n193ProfesionalesEmail = new bool[] {false} ;
         P00AV2_A170ProfesionalesTelefono = new string[] {""} ;
         P00AV2_A192ProfesionalesApellidoSegundo = new string[] {""} ;
         P00AV2_A167ProfesionalesApellidoPrimero = new string[] {""} ;
         P00AV2_A191ProfesionalesSegundoNombre = new string[] {""} ;
         P00AV2_A166ProfesionalesPrimerNombre = new string[] {""} ;
         P00AV2_A120ProfesionalesId = new string[] {""} ;
         P00AV2_A676ProfesionalesEsRUT = new bool[] {false} ;
         P00AV2_n676ProfesionalesEsRUT = new bool[] {false} ;
         P00AV2_A108EstadosGenericosId = new int[1] ;
         A107EstadosTipo = "";
         AV40UserCustomValue = "";
         GXt_char2 = "";
         AV37ColumnsSelectorAux = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector(context);
         AV35GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.profesionaleswwexport__default(),
            new Object[][] {
                new Object[] {
               P00AV2_A107EstadosTipo, P00AV2_A673BancoId, P00AV2_n673BancoId, P00AV2_A674BancoNombre, P00AV2_A109EstadosGenericosNombre, P00AV2_A198ProfesionalesDireccion, P00AV2_A193ProfesionalesEmail, P00AV2_n193ProfesionalesEmail, P00AV2_A170ProfesionalesTelefono, P00AV2_A192ProfesionalesApellidoSegundo,
               P00AV2_A167ProfesionalesApellidoPrimero, P00AV2_A191ProfesionalesSegundoNombre, P00AV2_A166ProfesionalesPrimerNombre, P00AV2_A120ProfesionalesId, P00AV2_A676ProfesionalesEsRUT, P00AV2_n676ProfesionalesEsRUT, P00AV2_A108EstadosGenericosId
               }
            }
         );
         AV76Pgmname = "ProfesionalesWWExport";
         /* GeneXus formulas. */
         AV76Pgmname = "ProfesionalesWWExport";
      }

      private short AV21DynamicFiltersOperator1 ;
      private short AV25DynamicFiltersOperator2 ;
      private short AV29DynamicFiltersOperator3 ;
      private short GXt_int3 ;
      private short AV81Profesionaleswwds_3_dynamicfiltersoperator1 ;
      private short AV87Profesionaleswwds_9_dynamicfiltersoperator2 ;
      private short AV93Profesionaleswwds_15_dynamicfiltersoperator3 ;
      private short AV17OrderedBy ;
      private int AV14CellRow ;
      private int AV15FirstColumn ;
      private int AV16Random ;
      private int AV77GXV1 ;
      private int A108EstadosGenericosId ;
      private int AV115GXV2 ;
      private int AV116GXV3 ;
      private long AV44VisibleColumnCount ;
      private long A673BancoId ;
      private string AV76Pgmname ;
      private string GXKey ;
      private string GXEncryptionTmp ;
      private string AV71BancoNombre1 ;
      private string AV22ProfesionalesPrimerNombre1 ;
      private string AV73BancoNombre2 ;
      private string AV26ProfesionalesPrimerNombre2 ;
      private string AV75BancoNombre3 ;
      private string AV30ProfesionalesPrimerNombre3 ;
      private string AV48TFProfesionalesId_Sel ;
      private string AV47TFProfesionalesId ;
      private string AV50TFProfesionalesPrimerNombre_Sel ;
      private string AV49TFProfesionalesPrimerNombre ;
      private string AV52TFProfesionalesSegundoNombre_Sel ;
      private string AV51TFProfesionalesSegundoNombre ;
      private string AV54TFProfesionalesApellidoPrimero_Sel ;
      private string AV53TFProfesionalesApellidoPrimero ;
      private string AV56TFProfesionalesApellidoSegundo_Sel ;
      private string AV55TFProfesionalesApellidoSegundo ;
      private string AV58TFProfesionalesTelefono_Sel ;
      private string AV57TFProfesionalesTelefono ;
      private string AV69TFEstadosGenericosNombre_Sel ;
      private string AV68TFEstadosGenericosNombre ;
      private string AV83Profesionaleswwds_5_banconombre1 ;
      private string AV84Profesionaleswwds_6_profesionalesprimernombre1 ;
      private string AV89Profesionaleswwds_11_banconombre2 ;
      private string AV90Profesionaleswwds_12_profesionalesprimernombre2 ;
      private string AV95Profesionaleswwds_17_banconombre3 ;
      private string AV96Profesionaleswwds_18_profesionalesprimernombre3 ;
      private string AV97Profesionaleswwds_19_tfprofesionalesid ;
      private string AV98Profesionaleswwds_20_tfprofesionalesid_sel ;
      private string AV99Profesionaleswwds_21_tfprofesionalesprimernombre ;
      private string AV100Profesionaleswwds_22_tfprofesionalesprimernombre_sel ;
      private string AV101Profesionaleswwds_23_tfprofesionalessegundonombre ;
      private string AV102Profesionaleswwds_24_tfprofesionalessegundonombre_sel ;
      private string AV103Profesionaleswwds_25_tfprofesionalesapellidoprimero ;
      private string AV104Profesionaleswwds_26_tfprofesionalesapellidoprimero_sel ;
      private string AV105Profesionaleswwds_27_tfprofesionalesapellidosegundo ;
      private string AV106Profesionaleswwds_28_tfprofesionalesapellidosegundo_sel ;
      private string AV107Profesionaleswwds_29_tfprofesionalestelefono ;
      private string AV108Profesionaleswwds_30_tfprofesionalestelefono_sel ;
      private string AV113Profesionaleswwds_35_tfestadosgenericosnombre ;
      private string AV114Profesionaleswwds_36_tfestadosgenericosnombre_sel ;
      private string lV83Profesionaleswwds_5_banconombre1 ;
      private string lV84Profesionaleswwds_6_profesionalesprimernombre1 ;
      private string lV89Profesionaleswwds_11_banconombre2 ;
      private string lV90Profesionaleswwds_12_profesionalesprimernombre2 ;
      private string lV95Profesionaleswwds_17_banconombre3 ;
      private string lV96Profesionaleswwds_18_profesionalesprimernombre3 ;
      private string lV97Profesionaleswwds_19_tfprofesionalesid ;
      private string lV99Profesionaleswwds_21_tfprofesionalesprimernombre ;
      private string lV101Profesionaleswwds_23_tfprofesionalessegundonombre ;
      private string lV103Profesionaleswwds_25_tfprofesionalesapellidoprimero ;
      private string lV105Profesionaleswwds_27_tfprofesionalesapellidosegundo ;
      private string lV107Profesionaleswwds_29_tfprofesionalestelefono ;
      private string lV113Profesionaleswwds_35_tfestadosgenericosnombre ;
      private string A120ProfesionalesId ;
      private string A166ProfesionalesPrimerNombre ;
      private string A191ProfesionalesSegundoNombre ;
      private string A167ProfesionalesApellidoPrimero ;
      private string A192ProfesionalesApellidoSegundo ;
      private string A170ProfesionalesTelefono ;
      private string A674BancoNombre ;
      private string A109EstadosGenericosNombre ;
      private string A107EstadosTipo ;
      private string GXt_char2 ;
      private bool AV8IsAuthorized ;
      private bool GXt_boolean1 ;
      private bool returnInSub ;
      private bool AV70ProfesionalesEsRUT1 ;
      private bool AV23DynamicFiltersEnabled2 ;
      private bool AV72ProfesionalesEsRUT2 ;
      private bool AV27DynamicFiltersEnabled3 ;
      private bool AV74ProfesionalesEsRUT3 ;
      private bool AV82Profesionaleswwds_4_profesionalesesrut1 ;
      private bool AV85Profesionaleswwds_7_dynamicfiltersenabled2 ;
      private bool AV88Profesionaleswwds_10_profesionalesesrut2 ;
      private bool AV91Profesionaleswwds_13_dynamicfiltersenabled3 ;
      private bool AV94Profesionaleswwds_16_profesionalesesrut3 ;
      private bool A676ProfesionalesEsRUT ;
      private bool AV18OrderedDsc ;
      private bool n673BancoId ;
      private bool n193ProfesionalesEmail ;
      private bool n676ProfesionalesEsRUT ;
      private string AV39ColumnsSelectorXML ;
      private string AV40UserCustomValue ;
      private string AV12Filename ;
      private string AV13ErrorMessage ;
      private string AV19FilterFullText ;
      private string AV20DynamicFiltersSelector1 ;
      private string AV24DynamicFiltersSelector2 ;
      private string AV28DynamicFiltersSelector3 ;
      private string AV60TFProfesionalesEmail_Sel ;
      private string AV59TFProfesionalesEmail ;
      private string AV62TFProfesionalesDireccion_Sel ;
      private string AV61TFProfesionalesDireccion ;
      private string AV79Profesionaleswwds_1_filterfulltext ;
      private string AV80Profesionaleswwds_2_dynamicfiltersselector1 ;
      private string AV86Profesionaleswwds_8_dynamicfiltersselector2 ;
      private string AV92Profesionaleswwds_14_dynamicfiltersselector3 ;
      private string AV109Profesionaleswwds_31_tfprofesionalesemail ;
      private string AV110Profesionaleswwds_32_tfprofesionalesemail_sel ;
      private string AV111Profesionaleswwds_33_tfprofesionalesdireccion ;
      private string AV112Profesionaleswwds_34_tfprofesionalesdireccion_sel ;
      private string lV79Profesionaleswwds_1_filterfulltext ;
      private string lV109Profesionaleswwds_31_tfprofesionalesemail ;
      private string lV111Profesionaleswwds_33_tfprofesionalesdireccion ;
      private string A193ProfesionalesEmail ;
      private string A198ProfesionalesDireccion ;
      private IGxSession AV32Session ;
      private ExcelDocumentI AV11ExcelDocument ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV34GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV31GridStateDynamicFilter ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector AV36ColumnsSelector ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column AV38ColumnsSelector_Column ;
      private IDataStoreProvider pr_default ;
      private string[] P00AV2_A107EstadosTipo ;
      private long[] P00AV2_A673BancoId ;
      private bool[] P00AV2_n673BancoId ;
      private string[] P00AV2_A674BancoNombre ;
      private string[] P00AV2_A109EstadosGenericosNombre ;
      private string[] P00AV2_A198ProfesionalesDireccion ;
      private string[] P00AV2_A193ProfesionalesEmail ;
      private bool[] P00AV2_n193ProfesionalesEmail ;
      private string[] P00AV2_A170ProfesionalesTelefono ;
      private string[] P00AV2_A192ProfesionalesApellidoSegundo ;
      private string[] P00AV2_A167ProfesionalesApellidoPrimero ;
      private string[] P00AV2_A191ProfesionalesSegundoNombre ;
      private string[] P00AV2_A166ProfesionalesPrimerNombre ;
      private string[] P00AV2_A120ProfesionalesId ;
      private bool[] P00AV2_A676ProfesionalesEsRUT ;
      private bool[] P00AV2_n676ProfesionalesEsRUT ;
      private int[] P00AV2_A108EstadosGenericosId ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector AV37ColumnsSelectorAux ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV35GridStateFilterValue ;
      private string aP0_Filename ;
      private string aP1_ErrorMessage ;
   }

   public class profesionaleswwexport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00AV2( IGxContext context ,
                                             string AV79Profesionaleswwds_1_filterfulltext ,
                                             string AV80Profesionaleswwds_2_dynamicfiltersselector1 ,
                                             bool AV82Profesionaleswwds_4_profesionalesesrut1 ,
                                             short AV81Profesionaleswwds_3_dynamicfiltersoperator1 ,
                                             string AV83Profesionaleswwds_5_banconombre1 ,
                                             string AV84Profesionaleswwds_6_profesionalesprimernombre1 ,
                                             bool AV85Profesionaleswwds_7_dynamicfiltersenabled2 ,
                                             string AV86Profesionaleswwds_8_dynamicfiltersselector2 ,
                                             bool AV88Profesionaleswwds_10_profesionalesesrut2 ,
                                             short AV87Profesionaleswwds_9_dynamicfiltersoperator2 ,
                                             string AV89Profesionaleswwds_11_banconombre2 ,
                                             string AV90Profesionaleswwds_12_profesionalesprimernombre2 ,
                                             bool AV91Profesionaleswwds_13_dynamicfiltersenabled3 ,
                                             string AV92Profesionaleswwds_14_dynamicfiltersselector3 ,
                                             bool AV94Profesionaleswwds_16_profesionalesesrut3 ,
                                             short AV93Profesionaleswwds_15_dynamicfiltersoperator3 ,
                                             string AV95Profesionaleswwds_17_banconombre3 ,
                                             string AV96Profesionaleswwds_18_profesionalesprimernombre3 ,
                                             string AV98Profesionaleswwds_20_tfprofesionalesid_sel ,
                                             string AV97Profesionaleswwds_19_tfprofesionalesid ,
                                             string AV100Profesionaleswwds_22_tfprofesionalesprimernombre_sel ,
                                             string AV99Profesionaleswwds_21_tfprofesionalesprimernombre ,
                                             string AV102Profesionaleswwds_24_tfprofesionalessegundonombre_sel ,
                                             string AV101Profesionaleswwds_23_tfprofesionalessegundonombre ,
                                             string AV104Profesionaleswwds_26_tfprofesionalesapellidoprimero_sel ,
                                             string AV103Profesionaleswwds_25_tfprofesionalesapellidoprimero ,
                                             string AV106Profesionaleswwds_28_tfprofesionalesapellidosegundo_sel ,
                                             string AV105Profesionaleswwds_27_tfprofesionalesapellidosegundo ,
                                             string AV108Profesionaleswwds_30_tfprofesionalestelefono_sel ,
                                             string AV107Profesionaleswwds_29_tfprofesionalestelefono ,
                                             string AV110Profesionaleswwds_32_tfprofesionalesemail_sel ,
                                             string AV109Profesionaleswwds_31_tfprofesionalesemail ,
                                             string AV112Profesionaleswwds_34_tfprofesionalesdireccion_sel ,
                                             string AV111Profesionaleswwds_33_tfprofesionalesdireccion ,
                                             string AV114Profesionaleswwds_36_tfestadosgenericosnombre_sel ,
                                             string AV113Profesionaleswwds_35_tfestadosgenericosnombre ,
                                             string A120ProfesionalesId ,
                                             string A166ProfesionalesPrimerNombre ,
                                             string A191ProfesionalesSegundoNombre ,
                                             string A167ProfesionalesApellidoPrimero ,
                                             string A192ProfesionalesApellidoSegundo ,
                                             string A170ProfesionalesTelefono ,
                                             bool A676ProfesionalesEsRUT ,
                                             string A674BancoNombre ,
                                             string A193ProfesionalesEmail ,
                                             string A198ProfesionalesDireccion ,
                                             string A109EstadosGenericosNombre ,
                                             short AV17OrderedBy ,
                                             bool AV18OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int4 = new short[39];
         Object[] GXv_Object5 = new Object[2];
         scmdbuf = "SELECT T1.[EstadosTipo], T1.[BancoId], T2.[BancoNombre], T3.[EstadosGenericosNombre], T1.[ProfesionalesDireccion], T1.[ProfesionalesEmail], T1.[ProfesionalesTelefono], T1.[ProfesionalesApellidoSegundo], T1.[ProfesionalesApellidoPrimero], T1.[ProfesionalesSegundoNombre], T1.[ProfesionalesPrimerNombre], T1.[ProfesionalesId], T1.[ProfesionalesEsRUT], T1.[EstadosGenericosId] FROM (([Profesionales] T1 LEFT JOIN [Banco] T2 ON T2.[BancoId] = T1.[BancoId]) INNER JOIN [EstadosGenericos] T3 ON T3.[EstadosTipo] = T1.[EstadosTipo] AND T3.[EstadosGenericosId] = T1.[EstadosGenericosId])";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV79Profesionaleswwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( UPPER(T1.[ProfesionalesId]) like '%' + UPPER(@lV79Profesionaleswwds_1_filterfulltext)) or ( UPPER(T1.[ProfesionalesPrimerNombre]) like '%' + UPPER(@lV79Profesionaleswwds_1_filterfulltext)) or ( UPPER(T1.[ProfesionalesSegundoNombre]) like '%' + UPPER(@lV79Profesionaleswwds_1_filterfulltext)) or ( UPPER(T1.[ProfesionalesApellidoPrimero]) like '%' + UPPER(@lV79Profesionaleswwds_1_filterfulltext)) or ( UPPER(T1.[ProfesionalesApellidoSegundo]) like '%' + UPPER(@lV79Profesionaleswwds_1_filterfulltext)) or ( UPPER(T1.[ProfesionalesTelefono]) like '%' + UPPER(@lV79Profesionaleswwds_1_filterfulltext)))");
         }
         else
         {
            GXv_int4[0] = 1;
            GXv_int4[1] = 1;
            GXv_int4[2] = 1;
            GXv_int4[3] = 1;
            GXv_int4[4] = 1;
            GXv_int4[5] = 1;
         }
         if ( ( StringUtil.StrCmp(AV80Profesionaleswwds_2_dynamicfiltersselector1, "PROFESIONALESESRUT") == 0 ) && ( ! (false==AV82Profesionaleswwds_4_profesionalesesrut1) ) )
         {
            AddWhere(sWhereString, "(T1.[ProfesionalesEsRUT] = @AV82Profesionaleswwds_4_profesionalesesrut1)");
         }
         else
         {
            GXv_int4[6] = 1;
         }
         if ( ( StringUtil.StrCmp(AV80Profesionaleswwds_2_dynamicfiltersselector1, "BANCONOMBRE") == 0 ) && ( AV81Profesionaleswwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV83Profesionaleswwds_5_banconombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[BancoNombre]) like UPPER(@lV83Profesionaleswwds_5_banconombre1))");
         }
         else
         {
            GXv_int4[7] = 1;
         }
         if ( ( StringUtil.StrCmp(AV80Profesionaleswwds_2_dynamicfiltersselector1, "BANCONOMBRE") == 0 ) && ( AV81Profesionaleswwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV83Profesionaleswwds_5_banconombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[BancoNombre]) like '%' + UPPER(@lV83Profesionaleswwds_5_banconombre1))");
         }
         else
         {
            GXv_int4[8] = 1;
         }
         if ( ( StringUtil.StrCmp(AV80Profesionaleswwds_2_dynamicfiltersselector1, "PROFESIONALESPRIMERNOMBRE") == 0 ) && ( AV81Profesionaleswwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV84Profesionaleswwds_6_profesionalesprimernombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[ProfesionalesPrimerNombre]) like UPPER(@lV84Profesionaleswwds_6_profesionalesprimernombre1))");
         }
         else
         {
            GXv_int4[9] = 1;
         }
         if ( ( StringUtil.StrCmp(AV80Profesionaleswwds_2_dynamicfiltersselector1, "PROFESIONALESPRIMERNOMBRE") == 0 ) && ( AV81Profesionaleswwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV84Profesionaleswwds_6_profesionalesprimernombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[ProfesionalesPrimerNombre]) like '%' + UPPER(@lV84Profesionaleswwds_6_profesionalesprimernombre1))");
         }
         else
         {
            GXv_int4[10] = 1;
         }
         if ( AV85Profesionaleswwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV86Profesionaleswwds_8_dynamicfiltersselector2, "PROFESIONALESESRUT") == 0 ) && ( ! (false==AV88Profesionaleswwds_10_profesionalesesrut2) ) )
         {
            AddWhere(sWhereString, "(T1.[ProfesionalesEsRUT] = @AV88Profesionaleswwds_10_profesionalesesrut2)");
         }
         else
         {
            GXv_int4[11] = 1;
         }
         if ( AV85Profesionaleswwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV86Profesionaleswwds_8_dynamicfiltersselector2, "BANCONOMBRE") == 0 ) && ( AV87Profesionaleswwds_9_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV89Profesionaleswwds_11_banconombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[BancoNombre]) like UPPER(@lV89Profesionaleswwds_11_banconombre2))");
         }
         else
         {
            GXv_int4[12] = 1;
         }
         if ( AV85Profesionaleswwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV86Profesionaleswwds_8_dynamicfiltersselector2, "BANCONOMBRE") == 0 ) && ( AV87Profesionaleswwds_9_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV89Profesionaleswwds_11_banconombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[BancoNombre]) like '%' + UPPER(@lV89Profesionaleswwds_11_banconombre2))");
         }
         else
         {
            GXv_int4[13] = 1;
         }
         if ( AV85Profesionaleswwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV86Profesionaleswwds_8_dynamicfiltersselector2, "PROFESIONALESPRIMERNOMBRE") == 0 ) && ( AV87Profesionaleswwds_9_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV90Profesionaleswwds_12_profesionalesprimernombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[ProfesionalesPrimerNombre]) like UPPER(@lV90Profesionaleswwds_12_profesionalesprimernombre2))");
         }
         else
         {
            GXv_int4[14] = 1;
         }
         if ( AV85Profesionaleswwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV86Profesionaleswwds_8_dynamicfiltersselector2, "PROFESIONALESPRIMERNOMBRE") == 0 ) && ( AV87Profesionaleswwds_9_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV90Profesionaleswwds_12_profesionalesprimernombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[ProfesionalesPrimerNombre]) like '%' + UPPER(@lV90Profesionaleswwds_12_profesionalesprimernombre2))");
         }
         else
         {
            GXv_int4[15] = 1;
         }
         if ( AV91Profesionaleswwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV92Profesionaleswwds_14_dynamicfiltersselector3, "PROFESIONALESESRUT") == 0 ) && ( ! (false==AV94Profesionaleswwds_16_profesionalesesrut3) ) )
         {
            AddWhere(sWhereString, "(T1.[ProfesionalesEsRUT] = @AV94Profesionaleswwds_16_profesionalesesrut3)");
         }
         else
         {
            GXv_int4[16] = 1;
         }
         if ( AV91Profesionaleswwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV92Profesionaleswwds_14_dynamicfiltersselector3, "BANCONOMBRE") == 0 ) && ( AV93Profesionaleswwds_15_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV95Profesionaleswwds_17_banconombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[BancoNombre]) like UPPER(@lV95Profesionaleswwds_17_banconombre3))");
         }
         else
         {
            GXv_int4[17] = 1;
         }
         if ( AV91Profesionaleswwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV92Profesionaleswwds_14_dynamicfiltersselector3, "BANCONOMBRE") == 0 ) && ( AV93Profesionaleswwds_15_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV95Profesionaleswwds_17_banconombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[BancoNombre]) like '%' + UPPER(@lV95Profesionaleswwds_17_banconombre3))");
         }
         else
         {
            GXv_int4[18] = 1;
         }
         if ( AV91Profesionaleswwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV92Profesionaleswwds_14_dynamicfiltersselector3, "PROFESIONALESPRIMERNOMBRE") == 0 ) && ( AV93Profesionaleswwds_15_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV96Profesionaleswwds_18_profesionalesprimernombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[ProfesionalesPrimerNombre]) like UPPER(@lV96Profesionaleswwds_18_profesionalesprimernombre3))");
         }
         else
         {
            GXv_int4[19] = 1;
         }
         if ( AV91Profesionaleswwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV92Profesionaleswwds_14_dynamicfiltersselector3, "PROFESIONALESPRIMERNOMBRE") == 0 ) && ( AV93Profesionaleswwds_15_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV96Profesionaleswwds_18_profesionalesprimernombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[ProfesionalesPrimerNombre]) like '%' + UPPER(@lV96Profesionaleswwds_18_profesionalesprimernombre3))");
         }
         else
         {
            GXv_int4[20] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV98Profesionaleswwds_20_tfprofesionalesid_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV97Profesionaleswwds_19_tfprofesionalesid)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[ProfesionalesId]) like UPPER(@lV97Profesionaleswwds_19_tfprofesionalesid))");
         }
         else
         {
            GXv_int4[21] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV98Profesionaleswwds_20_tfprofesionalesid_sel)) && ! ( StringUtil.StrCmp(AV98Profesionaleswwds_20_tfprofesionalesid_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[ProfesionalesId] = @AV98Profesionaleswwds_20_tfprofesionalesid_sel)");
         }
         else
         {
            GXv_int4[22] = 1;
         }
         if ( StringUtil.StrCmp(AV98Profesionaleswwds_20_tfprofesionalesid_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[ProfesionalesId] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV100Profesionaleswwds_22_tfprofesionalesprimernombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV99Profesionaleswwds_21_tfprofesionalesprimernombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[ProfesionalesPrimerNombre]) like UPPER(@lV99Profesionaleswwds_21_tfprofesionalesprimernombre))");
         }
         else
         {
            GXv_int4[23] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV100Profesionaleswwds_22_tfprofesionalesprimernombre_sel)) && ! ( StringUtil.StrCmp(AV100Profesionaleswwds_22_tfprofesionalesprimernombre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[ProfesionalesPrimerNombre] = @AV100Profesionaleswwds_22_tfprofesionalesprimernombre_sel)");
         }
         else
         {
            GXv_int4[24] = 1;
         }
         if ( StringUtil.StrCmp(AV100Profesionaleswwds_22_tfprofesionalesprimernombre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[ProfesionalesPrimerNombre] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV102Profesionaleswwds_24_tfprofesionalessegundonombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV101Profesionaleswwds_23_tfprofesionalessegundonombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[ProfesionalesSegundoNombre]) like UPPER(@lV101Profesionaleswwds_23_tfprofesionalessegundonombre))");
         }
         else
         {
            GXv_int4[25] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV102Profesionaleswwds_24_tfprofesionalessegundonombre_sel)) && ! ( StringUtil.StrCmp(AV102Profesionaleswwds_24_tfprofesionalessegundonombre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[ProfesionalesSegundoNombre] = @AV102Profesionaleswwds_24_tfprofesionalessegundonombre_sel)");
         }
         else
         {
            GXv_int4[26] = 1;
         }
         if ( StringUtil.StrCmp(AV102Profesionaleswwds_24_tfprofesionalessegundonombre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[ProfesionalesSegundoNombre] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV104Profesionaleswwds_26_tfprofesionalesapellidoprimero_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV103Profesionaleswwds_25_tfprofesionalesapellidoprimero)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[ProfesionalesApellidoPrimero]) like UPPER(@lV103Profesionaleswwds_25_tfprofesionalesapellidoprimero))");
         }
         else
         {
            GXv_int4[27] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV104Profesionaleswwds_26_tfprofesionalesapellidoprimero_sel)) && ! ( StringUtil.StrCmp(AV104Profesionaleswwds_26_tfprofesionalesapellidoprimero_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[ProfesionalesApellidoPrimero] = @AV104Profesionaleswwds_26_tfprofesionalesapellidoprimero_sel)");
         }
         else
         {
            GXv_int4[28] = 1;
         }
         if ( StringUtil.StrCmp(AV104Profesionaleswwds_26_tfprofesionalesapellidoprimero_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[ProfesionalesApellidoPrimero] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV106Profesionaleswwds_28_tfprofesionalesapellidosegundo_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV105Profesionaleswwds_27_tfprofesionalesapellidosegundo)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[ProfesionalesApellidoSegundo]) like UPPER(@lV105Profesionaleswwds_27_tfprofesionalesapellidosegundo))");
         }
         else
         {
            GXv_int4[29] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV106Profesionaleswwds_28_tfprofesionalesapellidosegundo_sel)) && ! ( StringUtil.StrCmp(AV106Profesionaleswwds_28_tfprofesionalesapellidosegundo_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[ProfesionalesApellidoSegundo] = @AV106Profesionaleswwds_28_tfprofesionalesapellidosegundo_sel)");
         }
         else
         {
            GXv_int4[30] = 1;
         }
         if ( StringUtil.StrCmp(AV106Profesionaleswwds_28_tfprofesionalesapellidosegundo_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[ProfesionalesApellidoSegundo] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV108Profesionaleswwds_30_tfprofesionalestelefono_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV107Profesionaleswwds_29_tfprofesionalestelefono)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[ProfesionalesTelefono]) like UPPER(@lV107Profesionaleswwds_29_tfprofesionalestelefono))");
         }
         else
         {
            GXv_int4[31] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV108Profesionaleswwds_30_tfprofesionalestelefono_sel)) && ! ( StringUtil.StrCmp(AV108Profesionaleswwds_30_tfprofesionalestelefono_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[ProfesionalesTelefono] = @AV108Profesionaleswwds_30_tfprofesionalestelefono_sel)");
         }
         else
         {
            GXv_int4[32] = 1;
         }
         if ( StringUtil.StrCmp(AV108Profesionaleswwds_30_tfprofesionalestelefono_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[ProfesionalesTelefono] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV110Profesionaleswwds_32_tfprofesionalesemail_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV109Profesionaleswwds_31_tfprofesionalesemail)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[ProfesionalesEmail]) like UPPER(@lV109Profesionaleswwds_31_tfprofesionalesemail))");
         }
         else
         {
            GXv_int4[33] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV110Profesionaleswwds_32_tfprofesionalesemail_sel)) && ! ( StringUtil.StrCmp(AV110Profesionaleswwds_32_tfprofesionalesemail_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[ProfesionalesEmail] = @AV110Profesionaleswwds_32_tfprofesionalesemail_sel)");
         }
         else
         {
            GXv_int4[34] = 1;
         }
         if ( StringUtil.StrCmp(AV110Profesionaleswwds_32_tfprofesionalesemail_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.[ProfesionalesEmail] IS NULL or (T1.[ProfesionalesEmail] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV112Profesionaleswwds_34_tfprofesionalesdireccion_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV111Profesionaleswwds_33_tfprofesionalesdireccion)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[ProfesionalesDireccion]) like UPPER(@lV111Profesionaleswwds_33_tfprofesionalesdireccion))");
         }
         else
         {
            GXv_int4[35] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV112Profesionaleswwds_34_tfprofesionalesdireccion_sel)) && ! ( StringUtil.StrCmp(AV112Profesionaleswwds_34_tfprofesionalesdireccion_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[ProfesionalesDireccion] = @AV112Profesionaleswwds_34_tfprofesionalesdireccion_sel)");
         }
         else
         {
            GXv_int4[36] = 1;
         }
         if ( StringUtil.StrCmp(AV112Profesionaleswwds_34_tfprofesionalesdireccion_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[ProfesionalesDireccion] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV114Profesionaleswwds_36_tfestadosgenericosnombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV113Profesionaleswwds_35_tfestadosgenericosnombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T3.[EstadosGenericosNombre]) like UPPER(@lV113Profesionaleswwds_35_tfestadosgenericosnombre))");
         }
         else
         {
            GXv_int4[37] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV114Profesionaleswwds_36_tfestadosgenericosnombre_sel)) && ! ( StringUtil.StrCmp(AV114Profesionaleswwds_36_tfestadosgenericosnombre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T3.[EstadosGenericosNombre] = @AV114Profesionaleswwds_36_tfestadosgenericosnombre_sel)");
         }
         else
         {
            GXv_int4[38] = 1;
         }
         if ( StringUtil.StrCmp(AV114Profesionaleswwds_36_tfestadosgenericosnombre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T3.[EstadosGenericosNombre] = ''))");
         }
         scmdbuf += sWhereString;
         if ( AV17OrderedBy == 1 )
         {
            scmdbuf += " ORDER BY T1.[ProfesionalesEsRUT]";
         }
         else if ( ( AV17OrderedBy == 2 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[ProfesionalesPrimerNombre]";
         }
         else if ( ( AV17OrderedBy == 2 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[ProfesionalesPrimerNombre] DESC";
         }
         else if ( ( AV17OrderedBy == 3 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[ProfesionalesId]";
         }
         else if ( ( AV17OrderedBy == 3 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[ProfesionalesId] DESC";
         }
         else if ( ( AV17OrderedBy == 4 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[ProfesionalesSegundoNombre]";
         }
         else if ( ( AV17OrderedBy == 4 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[ProfesionalesSegundoNombre] DESC";
         }
         else if ( ( AV17OrderedBy == 5 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[ProfesionalesApellidoPrimero]";
         }
         else if ( ( AV17OrderedBy == 5 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[ProfesionalesApellidoPrimero] DESC";
         }
         else if ( ( AV17OrderedBy == 6 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[ProfesionalesApellidoSegundo]";
         }
         else if ( ( AV17OrderedBy == 6 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[ProfesionalesApellidoSegundo] DESC";
         }
         else if ( ( AV17OrderedBy == 7 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[ProfesionalesTelefono]";
         }
         else if ( ( AV17OrderedBy == 7 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[ProfesionalesTelefono] DESC";
         }
         else if ( ( AV17OrderedBy == 8 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[ProfesionalesEmail]";
         }
         else if ( ( AV17OrderedBy == 8 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[ProfesionalesEmail] DESC";
         }
         else if ( ( AV17OrderedBy == 9 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[ProfesionalesDireccion]";
         }
         else if ( ( AV17OrderedBy == 9 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[ProfesionalesDireccion] DESC";
         }
         else if ( ( AV17OrderedBy == 10 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T3.[EstadosGenericosNombre]";
         }
         else if ( ( AV17OrderedBy == 10 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T3.[EstadosGenericosNombre] DESC";
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
                     return conditional_P00AV2(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (bool)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (bool)dynConstraints[6] , (string)dynConstraints[7] , (bool)dynConstraints[8] , (short)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (bool)dynConstraints[12] , (string)dynConstraints[13] , (bool)dynConstraints[14] , (short)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (string)dynConstraints[25] , (string)dynConstraints[26] , (string)dynConstraints[27] , (string)dynConstraints[28] , (string)dynConstraints[29] , (string)dynConstraints[30] , (string)dynConstraints[31] , (string)dynConstraints[32] , (string)dynConstraints[33] , (string)dynConstraints[34] , (string)dynConstraints[35] , (string)dynConstraints[36] , (string)dynConstraints[37] , (string)dynConstraints[38] , (string)dynConstraints[39] , (string)dynConstraints[40] , (string)dynConstraints[41] , (bool)dynConstraints[42] , (string)dynConstraints[43] , (string)dynConstraints[44] , (string)dynConstraints[45] , (string)dynConstraints[46] , (short)dynConstraints[47] , (bool)dynConstraints[48] );
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
          Object[] prmP00AV2;
          prmP00AV2 = new Object[] {
          new ParDef("@lV79Profesionaleswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV79Profesionaleswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV79Profesionaleswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV79Profesionaleswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV79Profesionaleswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV79Profesionaleswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@AV82Profesionaleswwds_4_profesionalesesrut1",GXType.Boolean,4,0) ,
          new ParDef("@lV83Profesionaleswwds_5_banconombre1",GXType.Char,80,0) ,
          new ParDef("@lV83Profesionaleswwds_5_banconombre1",GXType.Char,80,0) ,
          new ParDef("@lV84Profesionaleswwds_6_profesionalesprimernombre1",GXType.Char,30,0) ,
          new ParDef("@lV84Profesionaleswwds_6_profesionalesprimernombre1",GXType.Char,30,0) ,
          new ParDef("@AV88Profesionaleswwds_10_profesionalesesrut2",GXType.Boolean,4,0) ,
          new ParDef("@lV89Profesionaleswwds_11_banconombre2",GXType.Char,80,0) ,
          new ParDef("@lV89Profesionaleswwds_11_banconombre2",GXType.Char,80,0) ,
          new ParDef("@lV90Profesionaleswwds_12_profesionalesprimernombre2",GXType.Char,30,0) ,
          new ParDef("@lV90Profesionaleswwds_12_profesionalesprimernombre2",GXType.Char,30,0) ,
          new ParDef("@AV94Profesionaleswwds_16_profesionalesesrut3",GXType.Boolean,4,0) ,
          new ParDef("@lV95Profesionaleswwds_17_banconombre3",GXType.Char,80,0) ,
          new ParDef("@lV95Profesionaleswwds_17_banconombre3",GXType.Char,80,0) ,
          new ParDef("@lV96Profesionaleswwds_18_profesionalesprimernombre3",GXType.Char,30,0) ,
          new ParDef("@lV96Profesionaleswwds_18_profesionalesprimernombre3",GXType.Char,30,0) ,
          new ParDef("@lV97Profesionaleswwds_19_tfprofesionalesid",GXType.Char,20,0) ,
          new ParDef("@AV98Profesionaleswwds_20_tfprofesionalesid_sel",GXType.Char,20,0) ,
          new ParDef("@lV99Profesionaleswwds_21_tfprofesionalesprimernombre",GXType.Char,30,0) ,
          new ParDef("@AV100Profesionaleswwds_22_tfprofesionalesprimernombre_sel",GXType.NChar,30,0) ,
          new ParDef("@lV101Profesionaleswwds_23_tfprofesionalessegundonombre",GXType.Char,30,0) ,
          new ParDef("@AV102Profesionaleswwds_24_tfprofesionalessegundonombre_sel",GXType.NChar,30,0) ,
          new ParDef("@lV103Profesionaleswwds_25_tfprofesionalesapellidoprimero",GXType.Char,30,0) ,
          new ParDef("@AV104Profesionaleswwds_26_tfprofesionalesapellidoprimero_sel",GXType.NChar,30,0) ,
          new ParDef("@lV105Profesionaleswwds_27_tfprofesionalesapellidosegundo",GXType.Char,30,0) ,
          new ParDef("@AV106Profesionaleswwds_28_tfprofesionalesapellidosegundo_sel",GXType.NChar,30,0) ,
          new ParDef("@lV107Profesionaleswwds_29_tfprofesionalestelefono",GXType.Char,20,0) ,
          new ParDef("@AV108Profesionaleswwds_30_tfprofesionalestelefono_sel",GXType.NChar,20,0) ,
          new ParDef("@lV109Profesionaleswwds_31_tfprofesionalesemail",GXType.VarChar,100,0) ,
          new ParDef("@AV110Profesionaleswwds_32_tfprofesionalesemail_sel",GXType.NVarChar,100,0) ,
          new ParDef("@lV111Profesionaleswwds_33_tfprofesionalesdireccion",GXType.VarChar,1024,0) ,
          new ParDef("@AV112Profesionaleswwds_34_tfprofesionalesdireccion_sel",GXType.NVarChar,1024,0) ,
          new ParDef("@lV113Profesionaleswwds_35_tfestadosgenericosnombre",GXType.Char,80,0) ,
          new ParDef("@AV114Profesionaleswwds_36_tfestadosgenericosnombre_sel",GXType.NChar,80,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00AV2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00AV2,100, GxCacheFrequency.OFF ,true,false )
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
                ((long[]) buf[1])[0] = rslt.getLong(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getString(3, 80);
                ((string[]) buf[4])[0] = rslt.getString(4, 80);
                ((string[]) buf[5])[0] = rslt.getVarchar(5);
                ((string[]) buf[6])[0] = rslt.getVarchar(6);
                ((bool[]) buf[7])[0] = rslt.wasNull(6);
                ((string[]) buf[8])[0] = rslt.getString(7, 20);
                ((string[]) buf[9])[0] = rslt.getString(8, 30);
                ((string[]) buf[10])[0] = rslt.getString(9, 30);
                ((string[]) buf[11])[0] = rslt.getString(10, 30);
                ((string[]) buf[12])[0] = rslt.getString(11, 30);
                ((string[]) buf[13])[0] = rslt.getString(12, 20);
                ((bool[]) buf[14])[0] = rslt.getBool(13);
                ((bool[]) buf[15])[0] = rslt.wasNull(13);
                ((int[]) buf[16])[0] = rslt.getInt(14);
                return;
       }
    }

 }

}

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
   public class incidenciawwexport : GXProcedure
   {
      public incidenciawwexport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public incidenciawwexport( IGxContext context )
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
         new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWIncidencia", out  GXt_boolean1) ;
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
         AV12Filename = GXt_char2 + "IncidenciaWWExport-" + StringUtil.Trim( StringUtil.Str( (decimal)(AV16Random), 8, 0)) + ".xlsx";
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
         if ( AV37GridState.gxTpr_Dynamicfilters.Count >= 1 )
         {
            AV34GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV37GridState.gxTpr_Dynamicfilters.Item(1));
            AV20DynamicFiltersSelector1 = AV34GridStateDynamicFilter.gxTpr_Selected;
            if ( StringUtil.StrCmp(AV20DynamicFiltersSelector1, "INCIDENCIAORIGEN") == 0 )
            {
               AV22IncidenciaOrigen1 = AV34GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV22IncidenciaOrigen1)) )
               {
                  AV14CellRow = (int)(AV14CellRow+1);
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Bold = 1;
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Color = 3;
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = context.GetMessage( "Origen", "");
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Italic = 1;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV22IncidenciaOrigen1)) )
                  {
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = context.GetMessage( gxdomainorigen.getDescription(context,AV22IncidenciaOrigen1), "");
                  }
               }
            }
            else if ( StringUtil.StrCmp(AV20DynamicFiltersSelector1, "MOTIVONOMBRE") == 0 )
            {
               AV21DynamicFiltersOperator1 = AV34GridStateDynamicFilter.gxTpr_Operator;
               AV23MotivoNombre1 = AV34GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV23MotivoNombre1)) )
               {
                  AV14CellRow = (int)(AV14CellRow+1);
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Bold = 1;
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Color = 3;
                  if ( AV21DynamicFiltersOperator1 == 0 )
                  {
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", context.GetMessage( "Motivo Nombre", ""), context.GetMessage( "WWP_FilterLike", ""), "", "", "", "", "", "", "");
                  }
                  else if ( AV21DynamicFiltersOperator1 == 1 )
                  {
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", context.GetMessage( "Motivo Nombre", ""), context.GetMessage( "WWP_FilterContains", ""), "", "", "", "", "", "", "");
                  }
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Italic = 1;
                  GXt_char2 = "";
                  new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV23MotivoNombre1, out  GXt_char2) ;
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
               }
            }
            if ( AV37GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV24DynamicFiltersEnabled2 = true;
               AV34GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV37GridState.gxTpr_Dynamicfilters.Item(2));
               AV25DynamicFiltersSelector2 = AV34GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV25DynamicFiltersSelector2, "INCIDENCIAORIGEN") == 0 )
               {
                  AV27IncidenciaOrigen2 = AV34GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV27IncidenciaOrigen2)) )
                  {
                     AV14CellRow = (int)(AV14CellRow+1);
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Bold = 1;
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Color = 3;
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = context.GetMessage( "Origen", "");
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Italic = 1;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV27IncidenciaOrigen2)) )
                     {
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = context.GetMessage( gxdomainorigen.getDescription(context,AV27IncidenciaOrigen2), "");
                     }
                  }
               }
               else if ( StringUtil.StrCmp(AV25DynamicFiltersSelector2, "MOTIVONOMBRE") == 0 )
               {
                  AV26DynamicFiltersOperator2 = AV34GridStateDynamicFilter.gxTpr_Operator;
                  AV28MotivoNombre2 = AV34GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV28MotivoNombre2)) )
                  {
                     AV14CellRow = (int)(AV14CellRow+1);
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Bold = 1;
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Color = 3;
                     if ( AV26DynamicFiltersOperator2 == 0 )
                     {
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", context.GetMessage( "Motivo Nombre", ""), context.GetMessage( "WWP_FilterLike", ""), "", "", "", "", "", "", "");
                     }
                     else if ( AV26DynamicFiltersOperator2 == 1 )
                     {
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", context.GetMessage( "Motivo Nombre", ""), context.GetMessage( "WWP_FilterContains", ""), "", "", "", "", "", "", "");
                     }
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Italic = 1;
                     GXt_char2 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV28MotivoNombre2, out  GXt_char2) ;
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
                  }
               }
               if ( AV37GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV29DynamicFiltersEnabled3 = true;
                  AV34GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV37GridState.gxTpr_Dynamicfilters.Item(3));
                  AV30DynamicFiltersSelector3 = AV34GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV30DynamicFiltersSelector3, "INCIDENCIAORIGEN") == 0 )
                  {
                     AV32IncidenciaOrigen3 = AV34GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV32IncidenciaOrigen3)) )
                     {
                        AV14CellRow = (int)(AV14CellRow+1);
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Bold = 1;
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Color = 3;
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = context.GetMessage( "Origen", "");
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Italic = 1;
                        if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV32IncidenciaOrigen3)) )
                        {
                           AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = context.GetMessage( gxdomainorigen.getDescription(context,AV32IncidenciaOrigen3), "");
                        }
                     }
                  }
                  else if ( StringUtil.StrCmp(AV30DynamicFiltersSelector3, "MOTIVONOMBRE") == 0 )
                  {
                     AV31DynamicFiltersOperator3 = AV34GridStateDynamicFilter.gxTpr_Operator;
                     AV33MotivoNombre3 = AV34GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV33MotivoNombre3)) )
                     {
                        AV14CellRow = (int)(AV14CellRow+1);
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Bold = 1;
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Color = 3;
                        if ( AV31DynamicFiltersOperator3 == 0 )
                        {
                           AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", context.GetMessage( "Motivo Nombre", ""), context.GetMessage( "WWP_FilterLike", ""), "", "", "", "", "", "", "");
                        }
                        else if ( AV31DynamicFiltersOperator3 == 1 )
                        {
                           AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", context.GetMessage( "Motivo Nombre", ""), context.GetMessage( "WWP_FilterContains", ""), "", "", "", "", "", "", "");
                        }
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Italic = 1;
                        GXt_char2 = "";
                        new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV33MotivoNombre3, out  GXt_char2) ;
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
                     }
                  }
               }
            }
         }
         if ( ! ( (0==AV50TFIncidenciaId) && (0==AV51TFIncidenciaId_To) ) )
         {
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Id", "")) ;
            AV14CellRow = GXt_int3;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Number = AV50TFIncidenciaId;
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  false, ref  GXt_int3,  (short)(AV15FirstColumn+2),  context.GetMessage( "WWP_TSTo", "")) ;
            AV14CellRow = GXt_int3;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+3, 1, 1).Number = AV51TFIncidenciaId_To;
         }
         if ( ! ( ( AV53TFIncidenciaOrigen_Sels.Count == 0 ) ) )
         {
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Origen", "")) ;
            AV14CellRow = GXt_int3;
            AV70i = 1;
            AV72GXV1 = 1;
            while ( AV72GXV1 <= AV53TFIncidenciaOrigen_Sels.Count )
            {
               AV54TFIncidenciaOrigen_Sel = AV53TFIncidenciaOrigen_Sels.GetString(AV72GXV1);
               if ( AV70i == 1 )
               {
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = "";
               }
               else
               {
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text+", ";
               }
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text+context.GetMessage( gxdomainorigen.getDescription(context,AV54TFIncidenciaOrigen_Sel), "");
               AV70i = (long)(AV70i+1);
               AV72GXV1 = (int)(AV72GXV1+1);
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV56TFIncidenciaCodRef_Sel)) ) )
         {
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Referencia", "")) ;
            AV14CellRow = GXt_int3;
            GXt_char2 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV56TFIncidenciaCodRef_Sel)) ? context.GetMessage( "WWP_TitleFilter_EmptyOption", "") : AV56TFIncidenciaCodRef_Sel), out  GXt_char2) ;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV55TFIncidenciaCodRef)) ) )
            {
               GXt_int3 = (short)(AV14CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Referencia", "")) ;
               AV14CellRow = GXt_int3;
               GXt_char2 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV55TFIncidenciaCodRef, out  GXt_char2) ;
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV58TFMotivoNombre_Sel)) ) )
         {
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Nombre", "")) ;
            AV14CellRow = GXt_int3;
            GXt_char2 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV58TFMotivoNombre_Sel)) ? context.GetMessage( "WWP_TitleFilter_EmptyOption", "") : AV58TFMotivoNombre_Sel), out  GXt_char2) ;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV57TFMotivoNombre)) ) )
            {
               GXt_int3 = (short)(AV14CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Nombre", "")) ;
               AV14CellRow = GXt_int3;
               GXt_char2 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV57TFMotivoNombre, out  GXt_char2) ;
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
            }
         }
         if ( ! ( ( AV60TFIncidenciaEstado_Sels.Count == 0 ) ) )
         {
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Estado", "")) ;
            AV14CellRow = GXt_int3;
            AV70i = 1;
            AV73GXV2 = 1;
            while ( AV73GXV2 <= AV60TFIncidenciaEstado_Sels.Count )
            {
               AV61TFIncidenciaEstado_Sel = AV60TFIncidenciaEstado_Sels.GetString(AV73GXV2);
               if ( AV70i == 1 )
               {
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = "";
               }
               else
               {
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text+", ";
               }
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text+context.GetMessage( gxdomainestadoope.getDescription(context,AV61TFIncidenciaEstado_Sel), "");
               AV70i = (long)(AV70i+1);
               AV73GXV2 = (int)(AV73GXV2+1);
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV63TFIncidenciaUsrAlta_Sel)) ) )
         {
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Alta", "")) ;
            AV14CellRow = GXt_int3;
            GXt_char2 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV63TFIncidenciaUsrAlta_Sel)) ? context.GetMessage( "WWP_TitleFilter_EmptyOption", "") : AV63TFIncidenciaUsrAlta_Sel), out  GXt_char2) ;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV62TFIncidenciaUsrAlta)) ) )
            {
               GXt_int3 = (short)(AV14CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Alta", "")) ;
               AV14CellRow = GXt_int3;
               GXt_char2 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV62TFIncidenciaUsrAlta, out  GXt_char2) ;
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
            }
         }
         if ( ! ( (DateTime.MinValue==AV64TFIncidenciaFechaAlta) && (DateTime.MinValue==AV65TFIncidenciaFechaAlta_To) ) )
         {
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Alta", "")) ;
            AV14CellRow = GXt_int3;
            GXt_dtime4 = DateTimeUtil.ResetTime( AV64TFIncidenciaFechaAlta ) ;
            AV11ExcelDocument.SetDateFormat(context, 8, 5, ((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0), DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt")), "/", ":", " ");
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Date = GXt_dtime4;
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  false, ref  GXt_int3,  (short)(AV15FirstColumn+2),  context.GetMessage( "WWP_TSTo", "")) ;
            AV14CellRow = GXt_int3;
            GXt_dtime4 = DateTimeUtil.ResetTime( AV65TFIncidenciaFechaAlta_To ) ;
            AV11ExcelDocument.SetDateFormat(context, 8, 5, ((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0), DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt")), "/", ":", " ");
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+3, 1, 1).Date = GXt_dtime4;
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV67TFIncidenciaUsrActualizacion_Sel)) ) )
         {
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Actualiza", "")) ;
            AV14CellRow = GXt_int3;
            GXt_char2 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV67TFIncidenciaUsrActualizacion_Sel)) ? context.GetMessage( "WWP_TitleFilter_EmptyOption", "") : AV67TFIncidenciaUsrActualizacion_Sel), out  GXt_char2) ;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV66TFIncidenciaUsrActualizacion)) ) )
            {
               GXt_int3 = (short)(AV14CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Actualiza", "")) ;
               AV14CellRow = GXt_int3;
               GXt_char2 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV66TFIncidenciaUsrActualizacion, out  GXt_char2) ;
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
            }
         }
         if ( ! ( (DateTime.MinValue==AV68TFIncidenciaFechaActualizacion) && (DateTime.MinValue==AV69TFIncidenciaFechaActualizacion_To) ) )
         {
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Actualiza", "")) ;
            AV14CellRow = GXt_int3;
            GXt_dtime4 = DateTimeUtil.ResetTime( AV68TFIncidenciaFechaActualizacion ) ;
            AV11ExcelDocument.SetDateFormat(context, 8, 5, ((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0), DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt")), "/", ":", " ");
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Date = GXt_dtime4;
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  false, ref  GXt_int3,  (short)(AV15FirstColumn+2),  context.GetMessage( "WWP_TSTo", "")) ;
            AV14CellRow = GXt_int3;
            GXt_dtime4 = DateTimeUtil.ResetTime( AV69TFIncidenciaFechaActualizacion_To ) ;
            AV11ExcelDocument.SetDateFormat(context, 8, 5, ((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0), DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt")), "/", ":", " ");
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+3, 1, 1).Date = GXt_dtime4;
         }
         AV14CellRow = (int)(AV14CellRow+2);
      }

      protected void S141( )
      {
         /* 'WRITECOLUMNTITLES' Routine */
         returnInSub = false;
         AV47VisibleColumnCount = 0;
         if ( StringUtil.StrCmp(AV35Session.Get("IncidenciaWWColumnsSelector"), "") != 0 )
         {
            AV42ColumnsSelectorXML = AV35Session.Get("IncidenciaWWColumnsSelector");
            AV39ColumnsSelector.FromXml(AV42ColumnsSelectorXML, null, "", "");
         }
         else
         {
            /* Execute user subroutine: 'INITIALIZECOLUMNSSELECTOR' */
            S151 ();
            if (returnInSub) return;
         }
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
         AV76Incidenciawwds_1_filterfulltext = AV19FilterFullText;
         AV77Incidenciawwds_2_dynamicfiltersselector1 = AV20DynamicFiltersSelector1;
         AV78Incidenciawwds_3_dynamicfiltersoperator1 = AV21DynamicFiltersOperator1;
         AV79Incidenciawwds_4_incidenciaorigen1 = AV22IncidenciaOrigen1;
         AV80Incidenciawwds_5_motivonombre1 = AV23MotivoNombre1;
         AV81Incidenciawwds_6_dynamicfiltersenabled2 = AV24DynamicFiltersEnabled2;
         AV82Incidenciawwds_7_dynamicfiltersselector2 = AV25DynamicFiltersSelector2;
         AV83Incidenciawwds_8_dynamicfiltersoperator2 = AV26DynamicFiltersOperator2;
         AV84Incidenciawwds_9_incidenciaorigen2 = AV27IncidenciaOrigen2;
         AV85Incidenciawwds_10_motivonombre2 = AV28MotivoNombre2;
         AV86Incidenciawwds_11_dynamicfiltersenabled3 = AV29DynamicFiltersEnabled3;
         AV87Incidenciawwds_12_dynamicfiltersselector3 = AV30DynamicFiltersSelector3;
         AV88Incidenciawwds_13_dynamicfiltersoperator3 = AV31DynamicFiltersOperator3;
         AV89Incidenciawwds_14_incidenciaorigen3 = AV32IncidenciaOrigen3;
         AV90Incidenciawwds_15_motivonombre3 = AV33MotivoNombre3;
         AV91Incidenciawwds_16_tfincidenciaid = AV50TFIncidenciaId;
         AV92Incidenciawwds_17_tfincidenciaid_to = AV51TFIncidenciaId_To;
         AV93Incidenciawwds_18_tfincidenciaorigen_sels = AV53TFIncidenciaOrigen_Sels;
         AV94Incidenciawwds_19_tfincidenciacodref = AV55TFIncidenciaCodRef;
         AV95Incidenciawwds_20_tfincidenciacodref_sel = AV56TFIncidenciaCodRef_Sel;
         AV96Incidenciawwds_21_tfmotivonombre = AV57TFMotivoNombre;
         AV97Incidenciawwds_22_tfmotivonombre_sel = AV58TFMotivoNombre_Sel;
         AV98Incidenciawwds_23_tfincidenciaestado_sels = AV60TFIncidenciaEstado_Sels;
         AV99Incidenciawwds_24_tfincidenciausralta = AV62TFIncidenciaUsrAlta;
         AV100Incidenciawwds_25_tfincidenciausralta_sel = AV63TFIncidenciaUsrAlta_Sel;
         AV101Incidenciawwds_26_tfincidenciafechaalta = AV64TFIncidenciaFechaAlta;
         AV102Incidenciawwds_27_tfincidenciafechaalta_to = AV65TFIncidenciaFechaAlta_To;
         AV103Incidenciawwds_28_tfincidenciausractualizacion = AV66TFIncidenciaUsrActualizacion;
         AV104Incidenciawwds_29_tfincidenciausractualizacion_sel = AV67TFIncidenciaUsrActualizacion_Sel;
         AV105Incidenciawwds_30_tfincidenciafechaactualizacion = AV68TFIncidenciaFechaActualizacion;
         AV106Incidenciawwds_31_tfincidenciafechaactualizacion_to = AV69TFIncidenciaFechaActualizacion_To;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A611IncidenciaOrigen ,
                                              AV93Incidenciawwds_18_tfincidenciaorigen_sels ,
                                              A608IncidenciaEstado ,
                                              AV98Incidenciawwds_23_tfincidenciaestado_sels ,
                                              AV77Incidenciawwds_2_dynamicfiltersselector1 ,
                                              AV79Incidenciawwds_4_incidenciaorigen1 ,
                                              AV78Incidenciawwds_3_dynamicfiltersoperator1 ,
                                              AV80Incidenciawwds_5_motivonombre1 ,
                                              AV81Incidenciawwds_6_dynamicfiltersenabled2 ,
                                              AV82Incidenciawwds_7_dynamicfiltersselector2 ,
                                              AV84Incidenciawwds_9_incidenciaorigen2 ,
                                              AV83Incidenciawwds_8_dynamicfiltersoperator2 ,
                                              AV85Incidenciawwds_10_motivonombre2 ,
                                              AV86Incidenciawwds_11_dynamicfiltersenabled3 ,
                                              AV87Incidenciawwds_12_dynamicfiltersselector3 ,
                                              AV89Incidenciawwds_14_incidenciaorigen3 ,
                                              AV88Incidenciawwds_13_dynamicfiltersoperator3 ,
                                              AV90Incidenciawwds_15_motivonombre3 ,
                                              AV91Incidenciawwds_16_tfincidenciaid ,
                                              AV92Incidenciawwds_17_tfincidenciaid_to ,
                                              AV93Incidenciawwds_18_tfincidenciaorigen_sels.Count ,
                                              AV95Incidenciawwds_20_tfincidenciacodref_sel ,
                                              AV94Incidenciawwds_19_tfincidenciacodref ,
                                              AV97Incidenciawwds_22_tfmotivonombre_sel ,
                                              AV96Incidenciawwds_21_tfmotivonombre ,
                                              AV98Incidenciawwds_23_tfincidenciaestado_sels.Count ,
                                              AV100Incidenciawwds_25_tfincidenciausralta_sel ,
                                              AV99Incidenciawwds_24_tfincidenciausralta ,
                                              AV101Incidenciawwds_26_tfincidenciafechaalta ,
                                              AV102Incidenciawwds_27_tfincidenciafechaalta_to ,
                                              AV104Incidenciawwds_29_tfincidenciausractualizacion_sel ,
                                              AV103Incidenciawwds_28_tfincidenciausractualizacion ,
                                              AV105Incidenciawwds_30_tfincidenciafechaactualizacion ,
                                              AV106Incidenciawwds_31_tfincidenciafechaactualizacion_to ,
                                              A616MotivoNombre ,
                                              A603IncidenciaId ,
                                              A606IncidenciaCodRef ,
                                              A615IncidenciaUsrAlta ,
                                              A610IncidenciaFechaAlta ,
                                              A614IncidenciaUsrActualizacion ,
                                              A609IncidenciaFechaActualizacion ,
                                              AV17OrderedBy ,
                                              AV18OrderedDsc ,
                                              AV76Incidenciawwds_1_filterfulltext } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.INT, TypeConstants.INT, TypeConstants.DATE,
                                              TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.LONG, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV80Incidenciawwds_5_motivonombre1 = StringUtil.PadR( StringUtil.RTrim( AV80Incidenciawwds_5_motivonombre1), 80, "%");
         lV80Incidenciawwds_5_motivonombre1 = StringUtil.PadR( StringUtil.RTrim( AV80Incidenciawwds_5_motivonombre1), 80, "%");
         lV85Incidenciawwds_10_motivonombre2 = StringUtil.PadR( StringUtil.RTrim( AV85Incidenciawwds_10_motivonombre2), 80, "%");
         lV85Incidenciawwds_10_motivonombre2 = StringUtil.PadR( StringUtil.RTrim( AV85Incidenciawwds_10_motivonombre2), 80, "%");
         lV90Incidenciawwds_15_motivonombre3 = StringUtil.PadR( StringUtil.RTrim( AV90Incidenciawwds_15_motivonombre3), 80, "%");
         lV90Incidenciawwds_15_motivonombre3 = StringUtil.PadR( StringUtil.RTrim( AV90Incidenciawwds_15_motivonombre3), 80, "%");
         lV94Incidenciawwds_19_tfincidenciacodref = StringUtil.Concat( StringUtil.RTrim( AV94Incidenciawwds_19_tfincidenciacodref), "%", "");
         lV96Incidenciawwds_21_tfmotivonombre = StringUtil.PadR( StringUtil.RTrim( AV96Incidenciawwds_21_tfmotivonombre), 80, "%");
         lV99Incidenciawwds_24_tfincidenciausralta = StringUtil.PadR( StringUtil.RTrim( AV99Incidenciawwds_24_tfincidenciausralta), 20, "%");
         lV103Incidenciawwds_28_tfincidenciausractualizacion = StringUtil.PadR( StringUtil.RTrim( AV103Incidenciawwds_28_tfincidenciausractualizacion), 20, "%");
         /* Using cursor P00B22 */
         pr_default.execute(0, new Object[] {AV79Incidenciawwds_4_incidenciaorigen1, lV80Incidenciawwds_5_motivonombre1, lV80Incidenciawwds_5_motivonombre1, AV84Incidenciawwds_9_incidenciaorigen2, lV85Incidenciawwds_10_motivonombre2, lV85Incidenciawwds_10_motivonombre2, AV89Incidenciawwds_14_incidenciaorigen3, lV90Incidenciawwds_15_motivonombre3, lV90Incidenciawwds_15_motivonombre3, AV91Incidenciawwds_16_tfincidenciaid, AV92Incidenciawwds_17_tfincidenciaid_to, lV94Incidenciawwds_19_tfincidenciacodref, AV95Incidenciawwds_20_tfincidenciacodref_sel, lV96Incidenciawwds_21_tfmotivonombre, AV97Incidenciawwds_22_tfmotivonombre_sel, lV99Incidenciawwds_24_tfincidenciausralta, AV100Incidenciawwds_25_tfincidenciausralta_sel, AV101Incidenciawwds_26_tfincidenciafechaalta, AV102Incidenciawwds_27_tfincidenciafechaalta_to, lV103Incidenciawwds_28_tfincidenciausractualizacion, AV104Incidenciawwds_29_tfincidenciausractualizacion_sel, AV105Incidenciawwds_30_tfincidenciafechaactualizacion, AV106Incidenciawwds_31_tfincidenciafechaactualizacion_to});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A604MotivoId = P00B22_A604MotivoId[0];
            A609IncidenciaFechaActualizacion = P00B22_A609IncidenciaFechaActualizacion[0];
            A614IncidenciaUsrActualizacion = P00B22_A614IncidenciaUsrActualizacion[0];
            A610IncidenciaFechaAlta = P00B22_A610IncidenciaFechaAlta[0];
            A615IncidenciaUsrAlta = P00B22_A615IncidenciaUsrAlta[0];
            A616MotivoNombre = P00B22_A616MotivoNombre[0];
            A606IncidenciaCodRef = P00B22_A606IncidenciaCodRef[0];
            A603IncidenciaId = P00B22_A603IncidenciaId[0];
            A608IncidenciaEstado = P00B22_A608IncidenciaEstado[0];
            A611IncidenciaOrigen = P00B22_A611IncidenciaOrigen[0];
            A616MotivoNombre = P00B22_A616MotivoNombre[0];
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV76Incidenciawwds_1_filterfulltext)) || ( ( StringUtil.Like( StringUtil.Str( (decimal)(A603IncidenciaId), 18, 0) , StringUtil.PadR( "%" + AV76Incidenciawwds_1_filterfulltext , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( context.GetMessage( "solicitudes", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV76Incidenciawwds_1_filterfulltext) , 255 , "%"),  ' ' ) &&
            ( StringUtil.StrCmp(A611IncidenciaOrigen, "SOL") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "proveedores", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV76Incidenciawwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A611IncidenciaOrigen, "PRV") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "profesionales", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV76Incidenciawwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A611IncidenciaOrigen, "PRF") == 0 ) ) || ( StringUtil.Like( StringUtil.Upper( A606IncidenciaCodRef) , StringUtil.PadR( "%" + StringUtil.Upper( AV76Incidenciawwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Upper( A616MotivoNombre) , StringUtil.PadR( "%" + StringUtil.Upper( AV76Incidenciawwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( context.GetMessage( "procesado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV76Incidenciawwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A608IncidenciaEstado, "PRO") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "pendiente", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV76Incidenciawwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A608IncidenciaEstado, "PND") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "anulado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV76Incidenciawwds_1_filterfulltext) , 255 , "%"),  ' ' ) &&
            ( StringUtil.StrCmp(A608IncidenciaEstado, "ANU") == 0 ) ) || ( StringUtil.Like( StringUtil.Upper( A615IncidenciaUsrAlta) , StringUtil.PadR( "%" + StringUtil.Upper( AV76Incidenciawwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A614IncidenciaUsrActualizacion) , StringUtil.PadR( "%" + StringUtil.Upper( AV76Incidenciawwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) )
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
               AV107GXV4 = 1;
               while ( AV107GXV4 <= AV39ColumnsSelector.gxTpr_Columns.Count )
               {
                  AV41ColumnsSelector_Column = ((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV39ColumnsSelector.gxTpr_Columns.Item(AV107GXV4));
                  if ( AV41ColumnsSelector_Column.gxTpr_Isvisible )
                  {
                     if ( StringUtil.StrCmp(AV41ColumnsSelector_Column.gxTpr_Columnname, "IncidenciaId") == 0 )
                     {
                        AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV47VisibleColumnCount), 1, 1).Number = A603IncidenciaId;
                     }
                     else if ( StringUtil.StrCmp(AV41ColumnsSelector_Column.gxTpr_Columnname, "IncidenciaOrigen") == 0 )
                     {
                        AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV47VisibleColumnCount), 1, 1).Text = context.GetMessage( gxdomainorigen.getDescription(context,A611IncidenciaOrigen), "");
                     }
                     else if ( StringUtil.StrCmp(AV41ColumnsSelector_Column.gxTpr_Columnname, "IncidenciaCodRef") == 0 )
                     {
                        GXt_char2 = "";
                        new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A606IncidenciaCodRef, out  GXt_char2) ;
                        AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV47VisibleColumnCount), 1, 1).Text = GXt_char2;
                     }
                     else if ( StringUtil.StrCmp(AV41ColumnsSelector_Column.gxTpr_Columnname, "MotivoNombre") == 0 )
                     {
                        GXt_char2 = "";
                        new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A616MotivoNombre, out  GXt_char2) ;
                        AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV47VisibleColumnCount), 1, 1).Text = GXt_char2;
                     }
                     else if ( StringUtil.StrCmp(AV41ColumnsSelector_Column.gxTpr_Columnname, "IncidenciaEstado") == 0 )
                     {
                        AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV47VisibleColumnCount), 1, 1).Text = context.GetMessage( gxdomainestadoope.getDescription(context,A608IncidenciaEstado), "");
                     }
                     else if ( StringUtil.StrCmp(AV41ColumnsSelector_Column.gxTpr_Columnname, "IncidenciaUsrAlta") == 0 )
                     {
                        GXt_char2 = "";
                        new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A615IncidenciaUsrAlta, out  GXt_char2) ;
                        AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV47VisibleColumnCount), 1, 1).Text = GXt_char2;
                     }
                     else if ( StringUtil.StrCmp(AV41ColumnsSelector_Column.gxTpr_Columnname, "IncidenciaFechaAlta") == 0 )
                     {
                        GXt_dtime4 = DateTimeUtil.ResetTime( A610IncidenciaFechaAlta ) ;
                        AV11ExcelDocument.SetDateFormat(context, 8, 5, ((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0), DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt")), "/", ":", " ");
                        AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV47VisibleColumnCount), 1, 1).Date = GXt_dtime4;
                     }
                     else if ( StringUtil.StrCmp(AV41ColumnsSelector_Column.gxTpr_Columnname, "IncidenciaUsrActualizacion") == 0 )
                     {
                        GXt_char2 = "";
                        new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A614IncidenciaUsrActualizacion, out  GXt_char2) ;
                        AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV47VisibleColumnCount), 1, 1).Text = GXt_char2;
                     }
                     else if ( StringUtil.StrCmp(AV41ColumnsSelector_Column.gxTpr_Columnname, "IncidenciaFechaActualizacion") == 0 )
                     {
                        GXt_dtime4 = DateTimeUtil.ResetTime( A609IncidenciaFechaActualizacion ) ;
                        AV11ExcelDocument.SetDateFormat(context, 8, 5, ((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0), DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt")), "/", ":", " ");
                        AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV47VisibleColumnCount), 1, 1).Date = GXt_dtime4;
                     }
                     AV47VisibleColumnCount = (long)(AV47VisibleColumnCount+1);
                  }
                  AV107GXV4 = (int)(AV107GXV4+1);
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
         AV35Session.Set("WWPExportFileName", "IncidenciaWWExport.xlsx");
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
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV39ColumnsSelector,  "IncidenciaId",  "",  "Id",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV39ColumnsSelector,  "IncidenciaOrigen",  "",  "Origen",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV39ColumnsSelector,  "IncidenciaCodRef",  "",  "Referencia",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV39ColumnsSelector,  "MotivoNombre",  "",  "Nombre",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV39ColumnsSelector,  "IncidenciaEstado",  "",  "Estado",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV39ColumnsSelector,  "IncidenciaUsrAlta",  "",  "Alta",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV39ColumnsSelector,  "IncidenciaFechaAlta",  "",  "Alta",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV39ColumnsSelector,  "IncidenciaUsrActualizacion",  "",  "Actualiza",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV39ColumnsSelector,  "IncidenciaFechaActualizacion",  "",  "Actualiza",  true,  "") ;
         GXt_char2 = AV43UserCustomValue;
         new GeneXus.Programs.wwpbaseobjects.loadcolumnsselectorstate(context ).execute(  "IncidenciaWWColumnsSelector", out  GXt_char2) ;
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
         if ( StringUtil.StrCmp(AV35Session.Get("IncidenciaWWGridState"), "") == 0 )
         {
            AV37GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "IncidenciaWWGridState"), null, "", "");
         }
         else
         {
            AV37GridState.FromXml(AV35Session.Get("IncidenciaWWGridState"), null, "", "");
         }
         AV17OrderedBy = AV37GridState.gxTpr_Orderedby;
         AV18OrderedDsc = AV37GridState.gxTpr_Ordereddsc;
         AV108GXV5 = 1;
         while ( AV108GXV5 <= AV37GridState.gxTpr_Filtervalues.Count )
         {
            AV38GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV37GridState.gxTpr_Filtervalues.Item(AV108GXV5));
            if ( StringUtil.StrCmp(AV38GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV19FilterFullText = AV38GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV38GridStateFilterValue.gxTpr_Name, "TFINCIDENCIAID") == 0 )
            {
               AV50TFIncidenciaId = (long)(Math.Round(NumberUtil.Val( AV38GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV51TFIncidenciaId_To = (long)(Math.Round(NumberUtil.Val( AV38GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV38GridStateFilterValue.gxTpr_Name, "TFINCIDENCIAORIGEN_SEL") == 0 )
            {
               AV52TFIncidenciaOrigen_SelsJson = AV38GridStateFilterValue.gxTpr_Value;
               AV53TFIncidenciaOrigen_Sels.FromJSonString(AV52TFIncidenciaOrigen_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV38GridStateFilterValue.gxTpr_Name, "TFINCIDENCIACODREF") == 0 )
            {
               AV55TFIncidenciaCodRef = AV38GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV38GridStateFilterValue.gxTpr_Name, "TFINCIDENCIACODREF_SEL") == 0 )
            {
               AV56TFIncidenciaCodRef_Sel = AV38GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV38GridStateFilterValue.gxTpr_Name, "TFMOTIVONOMBRE") == 0 )
            {
               AV57TFMotivoNombre = AV38GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV38GridStateFilterValue.gxTpr_Name, "TFMOTIVONOMBRE_SEL") == 0 )
            {
               AV58TFMotivoNombre_Sel = AV38GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV38GridStateFilterValue.gxTpr_Name, "TFINCIDENCIAESTADO_SEL") == 0 )
            {
               AV59TFIncidenciaEstado_SelsJson = AV38GridStateFilterValue.gxTpr_Value;
               AV60TFIncidenciaEstado_Sels.FromJSonString(AV59TFIncidenciaEstado_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV38GridStateFilterValue.gxTpr_Name, "TFINCIDENCIAUSRALTA") == 0 )
            {
               AV62TFIncidenciaUsrAlta = AV38GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV38GridStateFilterValue.gxTpr_Name, "TFINCIDENCIAUSRALTA_SEL") == 0 )
            {
               AV63TFIncidenciaUsrAlta_Sel = AV38GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV38GridStateFilterValue.gxTpr_Name, "TFINCIDENCIAFECHAALTA") == 0 )
            {
               AV64TFIncidenciaFechaAlta = context.localUtil.CToD( AV38GridStateFilterValue.gxTpr_Value, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               AV65TFIncidenciaFechaAlta_To = context.localUtil.CToD( AV38GridStateFilterValue.gxTpr_Valueto, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
            }
            else if ( StringUtil.StrCmp(AV38GridStateFilterValue.gxTpr_Name, "TFINCIDENCIAUSRACTUALIZACION") == 0 )
            {
               AV66TFIncidenciaUsrActualizacion = AV38GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV38GridStateFilterValue.gxTpr_Name, "TFINCIDENCIAUSRACTUALIZACION_SEL") == 0 )
            {
               AV67TFIncidenciaUsrActualizacion_Sel = AV38GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV38GridStateFilterValue.gxTpr_Name, "TFINCIDENCIAFECHAACTUALIZACION") == 0 )
            {
               AV68TFIncidenciaFechaActualizacion = context.localUtil.CToD( AV38GridStateFilterValue.gxTpr_Value, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               AV69TFIncidenciaFechaActualizacion_To = context.localUtil.CToD( AV38GridStateFilterValue.gxTpr_Valueto, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
            }
            AV108GXV5 = (int)(AV108GXV5+1);
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
         AV37GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV34GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV20DynamicFiltersSelector1 = "";
         AV22IncidenciaOrigen1 = "";
         AV23MotivoNombre1 = "";
         AV25DynamicFiltersSelector2 = "";
         AV27IncidenciaOrigen2 = "";
         AV28MotivoNombre2 = "";
         AV30DynamicFiltersSelector3 = "";
         AV32IncidenciaOrigen3 = "";
         AV33MotivoNombre3 = "";
         AV53TFIncidenciaOrigen_Sels = new GxSimpleCollection<string>();
         AV54TFIncidenciaOrigen_Sel = "";
         AV56TFIncidenciaCodRef_Sel = "";
         AV55TFIncidenciaCodRef = "";
         AV58TFMotivoNombre_Sel = "";
         AV57TFMotivoNombre = "";
         AV60TFIncidenciaEstado_Sels = new GxSimpleCollection<string>();
         AV61TFIncidenciaEstado_Sel = "";
         AV63TFIncidenciaUsrAlta_Sel = "";
         AV62TFIncidenciaUsrAlta = "";
         AV64TFIncidenciaFechaAlta = DateTime.MinValue;
         AV65TFIncidenciaFechaAlta_To = DateTime.MinValue;
         AV67TFIncidenciaUsrActualizacion_Sel = "";
         AV66TFIncidenciaUsrActualizacion = "";
         AV68TFIncidenciaFechaActualizacion = DateTime.MinValue;
         AV69TFIncidenciaFechaActualizacion_To = DateTime.MinValue;
         AV35Session = context.GetSession();
         AV42ColumnsSelectorXML = "";
         AV39ColumnsSelector = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector(context);
         AV41ColumnsSelector_Column = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column(context);
         AV76Incidenciawwds_1_filterfulltext = "";
         AV77Incidenciawwds_2_dynamicfiltersselector1 = "";
         AV79Incidenciawwds_4_incidenciaorigen1 = "";
         AV80Incidenciawwds_5_motivonombre1 = "";
         AV82Incidenciawwds_7_dynamicfiltersselector2 = "";
         AV84Incidenciawwds_9_incidenciaorigen2 = "";
         AV85Incidenciawwds_10_motivonombre2 = "";
         AV87Incidenciawwds_12_dynamicfiltersselector3 = "";
         AV89Incidenciawwds_14_incidenciaorigen3 = "";
         AV90Incidenciawwds_15_motivonombre3 = "";
         AV93Incidenciawwds_18_tfincidenciaorigen_sels = new GxSimpleCollection<string>();
         AV94Incidenciawwds_19_tfincidenciacodref = "";
         AV95Incidenciawwds_20_tfincidenciacodref_sel = "";
         AV96Incidenciawwds_21_tfmotivonombre = "";
         AV97Incidenciawwds_22_tfmotivonombre_sel = "";
         AV98Incidenciawwds_23_tfincidenciaestado_sels = new GxSimpleCollection<string>();
         AV99Incidenciawwds_24_tfincidenciausralta = "";
         AV100Incidenciawwds_25_tfincidenciausralta_sel = "";
         AV101Incidenciawwds_26_tfincidenciafechaalta = DateTime.MinValue;
         AV102Incidenciawwds_27_tfincidenciafechaalta_to = DateTime.MinValue;
         AV103Incidenciawwds_28_tfincidenciausractualizacion = "";
         AV104Incidenciawwds_29_tfincidenciausractualizacion_sel = "";
         AV105Incidenciawwds_30_tfincidenciafechaactualizacion = DateTime.MinValue;
         AV106Incidenciawwds_31_tfincidenciafechaactualizacion_to = DateTime.MinValue;
         lV76Incidenciawwds_1_filterfulltext = "";
         lV80Incidenciawwds_5_motivonombre1 = "";
         lV85Incidenciawwds_10_motivonombre2 = "";
         lV90Incidenciawwds_15_motivonombre3 = "";
         lV94Incidenciawwds_19_tfincidenciacodref = "";
         lV96Incidenciawwds_21_tfmotivonombre = "";
         lV99Incidenciawwds_24_tfincidenciausralta = "";
         lV103Incidenciawwds_28_tfincidenciausractualizacion = "";
         A611IncidenciaOrigen = "";
         A608IncidenciaEstado = "";
         A616MotivoNombre = "";
         A606IncidenciaCodRef = "";
         A615IncidenciaUsrAlta = "";
         A610IncidenciaFechaAlta = DateTime.MinValue;
         A614IncidenciaUsrActualizacion = "";
         A609IncidenciaFechaActualizacion = DateTime.MinValue;
         P00B22_A604MotivoId = new long[1] ;
         P00B22_A609IncidenciaFechaActualizacion = new DateTime[] {DateTime.MinValue} ;
         P00B22_A614IncidenciaUsrActualizacion = new string[] {""} ;
         P00B22_A610IncidenciaFechaAlta = new DateTime[] {DateTime.MinValue} ;
         P00B22_A615IncidenciaUsrAlta = new string[] {""} ;
         P00B22_A616MotivoNombre = new string[] {""} ;
         P00B22_A606IncidenciaCodRef = new string[] {""} ;
         P00B22_A603IncidenciaId = new long[1] ;
         P00B22_A608IncidenciaEstado = new string[] {""} ;
         P00B22_A611IncidenciaOrigen = new string[] {""} ;
         GXt_dtime4 = (DateTime)(DateTime.MinValue);
         AV43UserCustomValue = "";
         GXt_char2 = "";
         AV40ColumnsSelectorAux = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector(context);
         AV38GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV52TFIncidenciaOrigen_SelsJson = "";
         AV59TFIncidenciaEstado_SelsJson = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.incidenciawwexport__default(),
            new Object[][] {
                new Object[] {
               P00B22_A604MotivoId, P00B22_A609IncidenciaFechaActualizacion, P00B22_A614IncidenciaUsrActualizacion, P00B22_A610IncidenciaFechaAlta, P00B22_A615IncidenciaUsrAlta, P00B22_A616MotivoNombre, P00B22_A606IncidenciaCodRef, P00B22_A603IncidenciaId, P00B22_A608IncidenciaEstado, P00B22_A611IncidenciaOrigen
               }
            }
         );
         AV71Pgmname = "IncidenciaWWExport";
         /* GeneXus formulas. */
         AV71Pgmname = "IncidenciaWWExport";
      }

      private short AV21DynamicFiltersOperator1 ;
      private short AV26DynamicFiltersOperator2 ;
      private short AV31DynamicFiltersOperator3 ;
      private short GXt_int3 ;
      private short AV78Incidenciawwds_3_dynamicfiltersoperator1 ;
      private short AV83Incidenciawwds_8_dynamicfiltersoperator2 ;
      private short AV88Incidenciawwds_13_dynamicfiltersoperator3 ;
      private short AV17OrderedBy ;
      private int AV14CellRow ;
      private int AV15FirstColumn ;
      private int AV16Random ;
      private int AV72GXV1 ;
      private int AV73GXV2 ;
      private int AV74GXV3 ;
      private int AV93Incidenciawwds_18_tfincidenciaorigen_sels_Count ;
      private int AV98Incidenciawwds_23_tfincidenciaestado_sels_Count ;
      private int AV107GXV4 ;
      private int AV108GXV5 ;
      private long AV50TFIncidenciaId ;
      private long AV51TFIncidenciaId_To ;
      private long AV70i ;
      private long AV47VisibleColumnCount ;
      private long AV91Incidenciawwds_16_tfincidenciaid ;
      private long AV92Incidenciawwds_17_tfincidenciaid_to ;
      private long A603IncidenciaId ;
      private long A604MotivoId ;
      private string AV71Pgmname ;
      private string GXKey ;
      private string GXEncryptionTmp ;
      private string AV22IncidenciaOrigen1 ;
      private string AV23MotivoNombre1 ;
      private string AV27IncidenciaOrigen2 ;
      private string AV28MotivoNombre2 ;
      private string AV32IncidenciaOrigen3 ;
      private string AV33MotivoNombre3 ;
      private string AV54TFIncidenciaOrigen_Sel ;
      private string AV58TFMotivoNombre_Sel ;
      private string AV57TFMotivoNombre ;
      private string AV61TFIncidenciaEstado_Sel ;
      private string AV63TFIncidenciaUsrAlta_Sel ;
      private string AV62TFIncidenciaUsrAlta ;
      private string AV67TFIncidenciaUsrActualizacion_Sel ;
      private string AV66TFIncidenciaUsrActualizacion ;
      private string AV79Incidenciawwds_4_incidenciaorigen1 ;
      private string AV80Incidenciawwds_5_motivonombre1 ;
      private string AV84Incidenciawwds_9_incidenciaorigen2 ;
      private string AV85Incidenciawwds_10_motivonombre2 ;
      private string AV89Incidenciawwds_14_incidenciaorigen3 ;
      private string AV90Incidenciawwds_15_motivonombre3 ;
      private string AV96Incidenciawwds_21_tfmotivonombre ;
      private string AV97Incidenciawwds_22_tfmotivonombre_sel ;
      private string AV99Incidenciawwds_24_tfincidenciausralta ;
      private string AV100Incidenciawwds_25_tfincidenciausralta_sel ;
      private string AV103Incidenciawwds_28_tfincidenciausractualizacion ;
      private string AV104Incidenciawwds_29_tfincidenciausractualizacion_sel ;
      private string lV80Incidenciawwds_5_motivonombre1 ;
      private string lV85Incidenciawwds_10_motivonombre2 ;
      private string lV90Incidenciawwds_15_motivonombre3 ;
      private string lV96Incidenciawwds_21_tfmotivonombre ;
      private string lV99Incidenciawwds_24_tfincidenciausralta ;
      private string lV103Incidenciawwds_28_tfincidenciausractualizacion ;
      private string A611IncidenciaOrigen ;
      private string A608IncidenciaEstado ;
      private string A616MotivoNombre ;
      private string A615IncidenciaUsrAlta ;
      private string A614IncidenciaUsrActualizacion ;
      private string GXt_char2 ;
      private DateTime GXt_dtime4 ;
      private DateTime AV64TFIncidenciaFechaAlta ;
      private DateTime AV65TFIncidenciaFechaAlta_To ;
      private DateTime AV68TFIncidenciaFechaActualizacion ;
      private DateTime AV69TFIncidenciaFechaActualizacion_To ;
      private DateTime AV101Incidenciawwds_26_tfincidenciafechaalta ;
      private DateTime AV102Incidenciawwds_27_tfincidenciafechaalta_to ;
      private DateTime AV105Incidenciawwds_30_tfincidenciafechaactualizacion ;
      private DateTime AV106Incidenciawwds_31_tfincidenciafechaactualizacion_to ;
      private DateTime A610IncidenciaFechaAlta ;
      private DateTime A609IncidenciaFechaActualizacion ;
      private bool AV8IsAuthorized ;
      private bool GXt_boolean1 ;
      private bool returnInSub ;
      private bool AV24DynamicFiltersEnabled2 ;
      private bool AV29DynamicFiltersEnabled3 ;
      private bool AV81Incidenciawwds_6_dynamicfiltersenabled2 ;
      private bool AV86Incidenciawwds_11_dynamicfiltersenabled3 ;
      private bool AV18OrderedDsc ;
      private string AV42ColumnsSelectorXML ;
      private string AV43UserCustomValue ;
      private string AV52TFIncidenciaOrigen_SelsJson ;
      private string AV59TFIncidenciaEstado_SelsJson ;
      private string AV12Filename ;
      private string AV13ErrorMessage ;
      private string AV19FilterFullText ;
      private string AV20DynamicFiltersSelector1 ;
      private string AV25DynamicFiltersSelector2 ;
      private string AV30DynamicFiltersSelector3 ;
      private string AV56TFIncidenciaCodRef_Sel ;
      private string AV55TFIncidenciaCodRef ;
      private string AV76Incidenciawwds_1_filterfulltext ;
      private string AV77Incidenciawwds_2_dynamicfiltersselector1 ;
      private string AV82Incidenciawwds_7_dynamicfiltersselector2 ;
      private string AV87Incidenciawwds_12_dynamicfiltersselector3 ;
      private string AV94Incidenciawwds_19_tfincidenciacodref ;
      private string AV95Incidenciawwds_20_tfincidenciacodref_sel ;
      private string lV76Incidenciawwds_1_filterfulltext ;
      private string lV94Incidenciawwds_19_tfincidenciacodref ;
      private string A606IncidenciaCodRef ;
      private IGxSession AV35Session ;
      private ExcelDocumentI AV11ExcelDocument ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV37GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV34GridStateDynamicFilter ;
      private GxSimpleCollection<string> AV53TFIncidenciaOrigen_Sels ;
      private GxSimpleCollection<string> AV60TFIncidenciaEstado_Sels ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector AV39ColumnsSelector ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column AV41ColumnsSelector_Column ;
      private GxSimpleCollection<string> AV93Incidenciawwds_18_tfincidenciaorigen_sels ;
      private GxSimpleCollection<string> AV98Incidenciawwds_23_tfincidenciaestado_sels ;
      private IDataStoreProvider pr_default ;
      private long[] P00B22_A604MotivoId ;
      private DateTime[] P00B22_A609IncidenciaFechaActualizacion ;
      private string[] P00B22_A614IncidenciaUsrActualizacion ;
      private DateTime[] P00B22_A610IncidenciaFechaAlta ;
      private string[] P00B22_A615IncidenciaUsrAlta ;
      private string[] P00B22_A616MotivoNombre ;
      private string[] P00B22_A606IncidenciaCodRef ;
      private long[] P00B22_A603IncidenciaId ;
      private string[] P00B22_A608IncidenciaEstado ;
      private string[] P00B22_A611IncidenciaOrigen ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector AV40ColumnsSelectorAux ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV38GridStateFilterValue ;
      private string aP0_Filename ;
      private string aP1_ErrorMessage ;
   }

   public class incidenciawwexport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00B22( IGxContext context ,
                                             string A611IncidenciaOrigen ,
                                             GxSimpleCollection<string> AV93Incidenciawwds_18_tfincidenciaorigen_sels ,
                                             string A608IncidenciaEstado ,
                                             GxSimpleCollection<string> AV98Incidenciawwds_23_tfincidenciaestado_sels ,
                                             string AV77Incidenciawwds_2_dynamicfiltersselector1 ,
                                             string AV79Incidenciawwds_4_incidenciaorigen1 ,
                                             short AV78Incidenciawwds_3_dynamicfiltersoperator1 ,
                                             string AV80Incidenciawwds_5_motivonombre1 ,
                                             bool AV81Incidenciawwds_6_dynamicfiltersenabled2 ,
                                             string AV82Incidenciawwds_7_dynamicfiltersselector2 ,
                                             string AV84Incidenciawwds_9_incidenciaorigen2 ,
                                             short AV83Incidenciawwds_8_dynamicfiltersoperator2 ,
                                             string AV85Incidenciawwds_10_motivonombre2 ,
                                             bool AV86Incidenciawwds_11_dynamicfiltersenabled3 ,
                                             string AV87Incidenciawwds_12_dynamicfiltersselector3 ,
                                             string AV89Incidenciawwds_14_incidenciaorigen3 ,
                                             short AV88Incidenciawwds_13_dynamicfiltersoperator3 ,
                                             string AV90Incidenciawwds_15_motivonombre3 ,
                                             long AV91Incidenciawwds_16_tfincidenciaid ,
                                             long AV92Incidenciawwds_17_tfincidenciaid_to ,
                                             int AV93Incidenciawwds_18_tfincidenciaorigen_sels_Count ,
                                             string AV95Incidenciawwds_20_tfincidenciacodref_sel ,
                                             string AV94Incidenciawwds_19_tfincidenciacodref ,
                                             string AV97Incidenciawwds_22_tfmotivonombre_sel ,
                                             string AV96Incidenciawwds_21_tfmotivonombre ,
                                             int AV98Incidenciawwds_23_tfincidenciaestado_sels_Count ,
                                             string AV100Incidenciawwds_25_tfincidenciausralta_sel ,
                                             string AV99Incidenciawwds_24_tfincidenciausralta ,
                                             DateTime AV101Incidenciawwds_26_tfincidenciafechaalta ,
                                             DateTime AV102Incidenciawwds_27_tfincidenciafechaalta_to ,
                                             string AV104Incidenciawwds_29_tfincidenciausractualizacion_sel ,
                                             string AV103Incidenciawwds_28_tfincidenciausractualizacion ,
                                             DateTime AV105Incidenciawwds_30_tfincidenciafechaactualizacion ,
                                             DateTime AV106Incidenciawwds_31_tfincidenciafechaactualizacion_to ,
                                             string A616MotivoNombre ,
                                             long A603IncidenciaId ,
                                             string A606IncidenciaCodRef ,
                                             string A615IncidenciaUsrAlta ,
                                             DateTime A610IncidenciaFechaAlta ,
                                             string A614IncidenciaUsrActualizacion ,
                                             DateTime A609IncidenciaFechaActualizacion ,
                                             short AV17OrderedBy ,
                                             bool AV18OrderedDsc ,
                                             string AV76Incidenciawwds_1_filterfulltext )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int5 = new short[23];
         Object[] GXv_Object6 = new Object[2];
         scmdbuf = "SELECT T1.[MotivoId], T1.[IncidenciaFechaActualizacion], T1.[IncidenciaUsrActualizacion], T1.[IncidenciaFechaAlta], T1.[IncidenciaUsrAlta], T2.[MotivoNombre], T1.[IncidenciaCodRef], T1.[IncidenciaId], T1.[IncidenciaEstado], T1.[IncidenciaOrigen] FROM ([Incidencia] T1 INNER JOIN [Motivo] T2 ON T2.[MotivoId] = T1.[MotivoId])";
         if ( ( StringUtil.StrCmp(AV77Incidenciawwds_2_dynamicfiltersselector1, "INCIDENCIAORIGEN") == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV79Incidenciawwds_4_incidenciaorigen1)) ) )
         {
            AddWhere(sWhereString, "(T1.[IncidenciaOrigen] = @AV79Incidenciawwds_4_incidenciaorigen1)");
         }
         else
         {
            GXv_int5[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV77Incidenciawwds_2_dynamicfiltersselector1, "MOTIVONOMBRE") == 0 ) && ( AV78Incidenciawwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV80Incidenciawwds_5_motivonombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[MotivoNombre]) like UPPER(@lV80Incidenciawwds_5_motivonombre1))");
         }
         else
         {
            GXv_int5[1] = 1;
         }
         if ( ( StringUtil.StrCmp(AV77Incidenciawwds_2_dynamicfiltersselector1, "MOTIVONOMBRE") == 0 ) && ( AV78Incidenciawwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV80Incidenciawwds_5_motivonombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[MotivoNombre]) like '%' + UPPER(@lV80Incidenciawwds_5_motivonombre1))");
         }
         else
         {
            GXv_int5[2] = 1;
         }
         if ( AV81Incidenciawwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV82Incidenciawwds_7_dynamicfiltersselector2, "INCIDENCIAORIGEN") == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV84Incidenciawwds_9_incidenciaorigen2)) ) )
         {
            AddWhere(sWhereString, "(T1.[IncidenciaOrigen] = @AV84Incidenciawwds_9_incidenciaorigen2)");
         }
         else
         {
            GXv_int5[3] = 1;
         }
         if ( AV81Incidenciawwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV82Incidenciawwds_7_dynamicfiltersselector2, "MOTIVONOMBRE") == 0 ) && ( AV83Incidenciawwds_8_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV85Incidenciawwds_10_motivonombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[MotivoNombre]) like UPPER(@lV85Incidenciawwds_10_motivonombre2))");
         }
         else
         {
            GXv_int5[4] = 1;
         }
         if ( AV81Incidenciawwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV82Incidenciawwds_7_dynamicfiltersselector2, "MOTIVONOMBRE") == 0 ) && ( AV83Incidenciawwds_8_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV85Incidenciawwds_10_motivonombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[MotivoNombre]) like '%' + UPPER(@lV85Incidenciawwds_10_motivonombre2))");
         }
         else
         {
            GXv_int5[5] = 1;
         }
         if ( AV86Incidenciawwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV87Incidenciawwds_12_dynamicfiltersselector3, "INCIDENCIAORIGEN") == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV89Incidenciawwds_14_incidenciaorigen3)) ) )
         {
            AddWhere(sWhereString, "(T1.[IncidenciaOrigen] = @AV89Incidenciawwds_14_incidenciaorigen3)");
         }
         else
         {
            GXv_int5[6] = 1;
         }
         if ( AV86Incidenciawwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV87Incidenciawwds_12_dynamicfiltersselector3, "MOTIVONOMBRE") == 0 ) && ( AV88Incidenciawwds_13_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV90Incidenciawwds_15_motivonombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[MotivoNombre]) like UPPER(@lV90Incidenciawwds_15_motivonombre3))");
         }
         else
         {
            GXv_int5[7] = 1;
         }
         if ( AV86Incidenciawwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV87Incidenciawwds_12_dynamicfiltersselector3, "MOTIVONOMBRE") == 0 ) && ( AV88Incidenciawwds_13_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV90Incidenciawwds_15_motivonombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[MotivoNombre]) like '%' + UPPER(@lV90Incidenciawwds_15_motivonombre3))");
         }
         else
         {
            GXv_int5[8] = 1;
         }
         if ( ! (0==AV91Incidenciawwds_16_tfincidenciaid) )
         {
            AddWhere(sWhereString, "(T1.[IncidenciaId] >= @AV91Incidenciawwds_16_tfincidenciaid)");
         }
         else
         {
            GXv_int5[9] = 1;
         }
         if ( ! (0==AV92Incidenciawwds_17_tfincidenciaid_to) )
         {
            AddWhere(sWhereString, "(T1.[IncidenciaId] <= @AV92Incidenciawwds_17_tfincidenciaid_to)");
         }
         else
         {
            GXv_int5[10] = 1;
         }
         if ( AV93Incidenciawwds_18_tfincidenciaorigen_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV93Incidenciawwds_18_tfincidenciaorigen_sels, "T1.[IncidenciaOrigen] IN (", ")")+")");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV95Incidenciawwds_20_tfincidenciacodref_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV94Incidenciawwds_19_tfincidenciacodref)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[IncidenciaCodRef]) like UPPER(@lV94Incidenciawwds_19_tfincidenciacodref))");
         }
         else
         {
            GXv_int5[11] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV95Incidenciawwds_20_tfincidenciacodref_sel)) && ! ( StringUtil.StrCmp(AV95Incidenciawwds_20_tfincidenciacodref_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[IncidenciaCodRef] = @AV95Incidenciawwds_20_tfincidenciacodref_sel)");
         }
         else
         {
            GXv_int5[12] = 1;
         }
         if ( StringUtil.StrCmp(AV95Incidenciawwds_20_tfincidenciacodref_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[IncidenciaCodRef] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV97Incidenciawwds_22_tfmotivonombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV96Incidenciawwds_21_tfmotivonombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[MotivoNombre]) like UPPER(@lV96Incidenciawwds_21_tfmotivonombre))");
         }
         else
         {
            GXv_int5[13] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV97Incidenciawwds_22_tfmotivonombre_sel)) && ! ( StringUtil.StrCmp(AV97Incidenciawwds_22_tfmotivonombre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.[MotivoNombre] = @AV97Incidenciawwds_22_tfmotivonombre_sel)");
         }
         else
         {
            GXv_int5[14] = 1;
         }
         if ( StringUtil.StrCmp(AV97Incidenciawwds_22_tfmotivonombre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T2.[MotivoNombre] = ''))");
         }
         if ( AV98Incidenciawwds_23_tfincidenciaestado_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV98Incidenciawwds_23_tfincidenciaestado_sels, "T1.[IncidenciaEstado] IN (", ")")+")");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV100Incidenciawwds_25_tfincidenciausralta_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV99Incidenciawwds_24_tfincidenciausralta)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[IncidenciaUsrAlta]) like UPPER(@lV99Incidenciawwds_24_tfincidenciausralta))");
         }
         else
         {
            GXv_int5[15] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV100Incidenciawwds_25_tfincidenciausralta_sel)) && ! ( StringUtil.StrCmp(AV100Incidenciawwds_25_tfincidenciausralta_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[IncidenciaUsrAlta] = @AV100Incidenciawwds_25_tfincidenciausralta_sel)");
         }
         else
         {
            GXv_int5[16] = 1;
         }
         if ( StringUtil.StrCmp(AV100Incidenciawwds_25_tfincidenciausralta_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[IncidenciaUsrAlta] = ''))");
         }
         if ( ! (DateTime.MinValue==AV101Incidenciawwds_26_tfincidenciafechaalta) )
         {
            AddWhere(sWhereString, "(T1.[IncidenciaFechaAlta] >= @AV101Incidenciawwds_26_tfincidenciafechaalta)");
         }
         else
         {
            GXv_int5[17] = 1;
         }
         if ( ! (DateTime.MinValue==AV102Incidenciawwds_27_tfincidenciafechaalta_to) )
         {
            AddWhere(sWhereString, "(T1.[IncidenciaFechaAlta] <= @AV102Incidenciawwds_27_tfincidenciafechaalta_to)");
         }
         else
         {
            GXv_int5[18] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV104Incidenciawwds_29_tfincidenciausractualizacion_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV103Incidenciawwds_28_tfincidenciausractualizacion)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[IncidenciaUsrActualizacion]) like UPPER(@lV103Incidenciawwds_28_tfincidenciausractualizacion))");
         }
         else
         {
            GXv_int5[19] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV104Incidenciawwds_29_tfincidenciausractualizacion_sel)) && ! ( StringUtil.StrCmp(AV104Incidenciawwds_29_tfincidenciausractualizacion_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[IncidenciaUsrActualizacion] = @AV104Incidenciawwds_29_tfincidenciausractualizacion_sel)");
         }
         else
         {
            GXv_int5[20] = 1;
         }
         if ( StringUtil.StrCmp(AV104Incidenciawwds_29_tfincidenciausractualizacion_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[IncidenciaUsrActualizacion] = ''))");
         }
         if ( ! (DateTime.MinValue==AV105Incidenciawwds_30_tfincidenciafechaactualizacion) )
         {
            AddWhere(sWhereString, "(T1.[IncidenciaFechaActualizacion] >= @AV105Incidenciawwds_30_tfincidenciafechaactualizacion)");
         }
         else
         {
            GXv_int5[21] = 1;
         }
         if ( ! (DateTime.MinValue==AV106Incidenciawwds_31_tfincidenciafechaactualizacion_to) )
         {
            AddWhere(sWhereString, "(T1.[IncidenciaFechaActualizacion] <= @AV106Incidenciawwds_31_tfincidenciafechaactualizacion_to)");
         }
         else
         {
            GXv_int5[22] = 1;
         }
         scmdbuf += sWhereString;
         if ( ( AV17OrderedBy == 1 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[IncidenciaOrigen]";
         }
         else if ( ( AV17OrderedBy == 1 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[IncidenciaOrigen] DESC";
         }
         else if ( ( AV17OrderedBy == 2 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[IncidenciaId]";
         }
         else if ( ( AV17OrderedBy == 2 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[IncidenciaId] DESC";
         }
         else if ( ( AV17OrderedBy == 3 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[IncidenciaCodRef]";
         }
         else if ( ( AV17OrderedBy == 3 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[IncidenciaCodRef] DESC";
         }
         else if ( ( AV17OrderedBy == 4 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T2.[MotivoNombre]";
         }
         else if ( ( AV17OrderedBy == 4 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T2.[MotivoNombre] DESC";
         }
         else if ( ( AV17OrderedBy == 5 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[IncidenciaEstado]";
         }
         else if ( ( AV17OrderedBy == 5 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[IncidenciaEstado] DESC";
         }
         else if ( ( AV17OrderedBy == 6 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[IncidenciaUsrAlta]";
         }
         else if ( ( AV17OrderedBy == 6 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[IncidenciaUsrAlta] DESC";
         }
         else if ( ( AV17OrderedBy == 7 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[IncidenciaFechaAlta]";
         }
         else if ( ( AV17OrderedBy == 7 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[IncidenciaFechaAlta] DESC";
         }
         else if ( ( AV17OrderedBy == 8 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[IncidenciaUsrActualizacion]";
         }
         else if ( ( AV17OrderedBy == 8 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[IncidenciaUsrActualizacion] DESC";
         }
         else if ( ( AV17OrderedBy == 9 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[IncidenciaFechaActualizacion]";
         }
         else if ( ( AV17OrderedBy == 9 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[IncidenciaFechaActualizacion] DESC";
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
                     return conditional_P00B22(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (GxSimpleCollection<string>)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (short)dynConstraints[6] , (string)dynConstraints[7] , (bool)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (short)dynConstraints[11] , (string)dynConstraints[12] , (bool)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (short)dynConstraints[16] , (string)dynConstraints[17] , (long)dynConstraints[18] , (long)dynConstraints[19] , (int)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (int)dynConstraints[25] , (string)dynConstraints[26] , (string)dynConstraints[27] , (DateTime)dynConstraints[28] , (DateTime)dynConstraints[29] , (string)dynConstraints[30] , (string)dynConstraints[31] , (DateTime)dynConstraints[32] , (DateTime)dynConstraints[33] , (string)dynConstraints[34] , (long)dynConstraints[35] , (string)dynConstraints[36] , (string)dynConstraints[37] , (DateTime)dynConstraints[38] , (string)dynConstraints[39] , (DateTime)dynConstraints[40] , (short)dynConstraints[41] , (bool)dynConstraints[42] , (string)dynConstraints[43] );
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
          Object[] prmP00B22;
          prmP00B22 = new Object[] {
          new ParDef("@AV79Incidenciawwds_4_incidenciaorigen1",GXType.NChar,3,0) ,
          new ParDef("@lV80Incidenciawwds_5_motivonombre1",GXType.Char,80,0) ,
          new ParDef("@lV80Incidenciawwds_5_motivonombre1",GXType.Char,80,0) ,
          new ParDef("@AV84Incidenciawwds_9_incidenciaorigen2",GXType.NChar,3,0) ,
          new ParDef("@lV85Incidenciawwds_10_motivonombre2",GXType.Char,80,0) ,
          new ParDef("@lV85Incidenciawwds_10_motivonombre2",GXType.Char,80,0) ,
          new ParDef("@AV89Incidenciawwds_14_incidenciaorigen3",GXType.NChar,3,0) ,
          new ParDef("@lV90Incidenciawwds_15_motivonombre3",GXType.Char,80,0) ,
          new ParDef("@lV90Incidenciawwds_15_motivonombre3",GXType.Char,80,0) ,
          new ParDef("@AV91Incidenciawwds_16_tfincidenciaid",GXType.Decimal,18,0) ,
          new ParDef("@AV92Incidenciawwds_17_tfincidenciaid_to",GXType.Decimal,18,0) ,
          new ParDef("@lV94Incidenciawwds_19_tfincidenciacodref",GXType.VarChar,40,0) ,
          new ParDef("@AV95Incidenciawwds_20_tfincidenciacodref_sel",GXType.NVarChar,40,0) ,
          new ParDef("@lV96Incidenciawwds_21_tfmotivonombre",GXType.Char,80,0) ,
          new ParDef("@AV97Incidenciawwds_22_tfmotivonombre_sel",GXType.NChar,80,0) ,
          new ParDef("@lV99Incidenciawwds_24_tfincidenciausralta",GXType.Char,20,0) ,
          new ParDef("@AV100Incidenciawwds_25_tfincidenciausralta_sel",GXType.NChar,20,0) ,
          new ParDef("@AV101Incidenciawwds_26_tfincidenciafechaalta",GXType.Date,8,0) ,
          new ParDef("@AV102Incidenciawwds_27_tfincidenciafechaalta_to",GXType.Date,8,0) ,
          new ParDef("@lV103Incidenciawwds_28_tfincidenciausractualizacion",GXType.Char,20,0) ,
          new ParDef("@AV104Incidenciawwds_29_tfincidenciausractualizacion_sel",GXType.NChar,20,0) ,
          new ParDef("@AV105Incidenciawwds_30_tfincidenciafechaactualizacion",GXType.Date,8,0) ,
          new ParDef("@AV106Incidenciawwds_31_tfincidenciafechaactualizacion_to",GXType.Date,8,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00B22", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00B22,100, GxCacheFrequency.OFF ,true,false )
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
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 20);
                ((DateTime[]) buf[3])[0] = rslt.getGXDate(4);
                ((string[]) buf[4])[0] = rslt.getString(5, 20);
                ((string[]) buf[5])[0] = rslt.getString(6, 80);
                ((string[]) buf[6])[0] = rslt.getVarchar(7);
                ((long[]) buf[7])[0] = rslt.getLong(8);
                ((string[]) buf[8])[0] = rslt.getString(9, 3);
                ((string[]) buf[9])[0] = rslt.getString(10, 3);
                return;
       }
    }

 }

}

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
   public class mudanzawwexport : GXProcedure
   {
      public mudanzawwexport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public mudanzawwexport( IGxContext context )
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
         new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWMudanza", out  GXt_boolean1) ;
         AV8IsAuthorized = GXt_boolean1;
         if ( ! AV8IsAuthorized )
         {
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "wwpbaseobjects.notauthorized.aspx"+GXUtil.UrlEncode(StringUtil.RTrim(AV124Pgmname));
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
         AV12Filename = GXt_char2 + "MudanzaWWExport-" + StringUtil.Trim( StringUtil.Str( (decimal)(AV16Random), 8, 0)) + ".xlsx";
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
            if ( StringUtil.StrCmp(AV20DynamicFiltersSelector1, "MUDANZAASESOR") == 0 )
            {
               AV21DynamicFiltersOperator1 = AV31GridStateDynamicFilter.gxTpr_Operator;
               AV22MudanzaAsesor1 = AV31GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV22MudanzaAsesor1)) )
               {
                  AV14CellRow = (int)(AV14CellRow+1);
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Bold = 1;
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Color = 3;
                  if ( AV21DynamicFiltersOperator1 == 0 )
                  {
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", context.GetMessage( "Asesor", ""), context.GetMessage( "WWP_FilterLike", ""), "", "", "", "", "", "", "");
                  }
                  else if ( AV21DynamicFiltersOperator1 == 1 )
                  {
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", context.GetMessage( "Asesor", ""), context.GetMessage( "WWP_FilterContains", ""), "", "", "", "", "", "", "");
                  }
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Italic = 1;
                  GXt_char2 = "";
                  new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV22MudanzaAsesor1, out  GXt_char2) ;
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
               }
            }
            if ( AV34GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV23DynamicFiltersEnabled2 = true;
               AV31GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV34GridState.gxTpr_Dynamicfilters.Item(2));
               AV24DynamicFiltersSelector2 = AV31GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV24DynamicFiltersSelector2, "MUDANZAASESOR") == 0 )
               {
                  AV25DynamicFiltersOperator2 = AV31GridStateDynamicFilter.gxTpr_Operator;
                  AV26MudanzaAsesor2 = AV31GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV26MudanzaAsesor2)) )
                  {
                     AV14CellRow = (int)(AV14CellRow+1);
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Bold = 1;
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Color = 3;
                     if ( AV25DynamicFiltersOperator2 == 0 )
                     {
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", context.GetMessage( "Asesor", ""), context.GetMessage( "WWP_FilterLike", ""), "", "", "", "", "", "", "");
                     }
                     else if ( AV25DynamicFiltersOperator2 == 1 )
                     {
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", context.GetMessage( "Asesor", ""), context.GetMessage( "WWP_FilterContains", ""), "", "", "", "", "", "", "");
                     }
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Italic = 1;
                     GXt_char2 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV26MudanzaAsesor2, out  GXt_char2) ;
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
                  }
               }
               if ( AV34GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV27DynamicFiltersEnabled3 = true;
                  AV31GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV34GridState.gxTpr_Dynamicfilters.Item(3));
                  AV28DynamicFiltersSelector3 = AV31GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV28DynamicFiltersSelector3, "MUDANZAASESOR") == 0 )
                  {
                     AV29DynamicFiltersOperator3 = AV31GridStateDynamicFilter.gxTpr_Operator;
                     AV30MudanzaAsesor3 = AV31GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV30MudanzaAsesor3)) )
                     {
                        AV14CellRow = (int)(AV14CellRow+1);
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Bold = 1;
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Color = 3;
                        if ( AV29DynamicFiltersOperator3 == 0 )
                        {
                           AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", context.GetMessage( "Asesor", ""), context.GetMessage( "WWP_FilterLike", ""), "", "", "", "", "", "", "");
                        }
                        else if ( AV29DynamicFiltersOperator3 == 1 )
                        {
                           AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", context.GetMessage( "Asesor", ""), context.GetMessage( "WWP_FilterContains", ""), "", "", "", "", "", "", "");
                        }
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Italic = 1;
                        GXt_char2 = "";
                        new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV30MudanzaAsesor3, out  GXt_char2) ;
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
                     }
                  }
               }
            }
         }
         if ( ! ( (0==AV47TFMudanzaId) && (0==AV48TFMudanzaId_To) ) )
         {
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Id", "")) ;
            AV14CellRow = GXt_int3;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Number = AV47TFMudanzaId;
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  false, ref  GXt_int3,  (short)(AV15FirstColumn+2),  context.GetMessage( "WWP_TSTo", "")) ;
            AV14CellRow = GXt_int3;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+3, 1, 1).Number = AV48TFMudanzaId_To;
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV50TFMudanzaAsesor_Sel)) ) )
         {
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Asesor", "")) ;
            AV14CellRow = GXt_int3;
            GXt_char2 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV50TFMudanzaAsesor_Sel)) ? context.GetMessage( "WWP_TitleFilter_EmptyOption", "") : AV50TFMudanzaAsesor_Sel), out  GXt_char2) ;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV49TFMudanzaAsesor)) ) )
            {
               GXt_int3 = (short)(AV14CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Asesor", "")) ;
               AV14CellRow = GXt_int3;
               GXt_char2 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV49TFMudanzaAsesor, out  GXt_char2) ;
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
            }
         }
         if ( ! ( (DateTime.MinValue==AV51TFMudanzaFechaAlta) && (DateTime.MinValue==AV52TFMudanzaFechaAlta_To) ) )
         {
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Fecha Alta", "")) ;
            AV14CellRow = GXt_int3;
            GXt_dtime4 = DateTimeUtil.ResetTime( AV51TFMudanzaFechaAlta ) ;
            AV11ExcelDocument.SetDateFormat(context, 8, 5, ((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0), DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt")), "/", ":", " ");
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Date = GXt_dtime4;
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  false, ref  GXt_int3,  (short)(AV15FirstColumn+2),  context.GetMessage( "WWP_TSTo", "")) ;
            AV14CellRow = GXt_int3;
            GXt_dtime4 = DateTimeUtil.ResetTime( AV52TFMudanzaFechaAlta_To ) ;
            AV11ExcelDocument.SetDateFormat(context, 8, 5, ((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0), DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt")), "/", ":", " ");
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+3, 1, 1).Date = GXt_dtime4;
         }
         if ( ! ( (DateTime.MinValue==AV53TFMudanzaFechaServicio) && (DateTime.MinValue==AV54TFMudanzaFechaServicio_To) ) )
         {
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Fecha Servicio", "")) ;
            AV14CellRow = GXt_int3;
            GXt_dtime4 = DateTimeUtil.ResetTime( AV53TFMudanzaFechaServicio ) ;
            AV11ExcelDocument.SetDateFormat(context, 8, 5, ((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0), DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt")), "/", ":", " ");
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Date = GXt_dtime4;
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  false, ref  GXt_int3,  (short)(AV15FirstColumn+2),  context.GetMessage( "WWP_TSTo", "")) ;
            AV14CellRow = GXt_int3;
            GXt_dtime4 = DateTimeUtil.ResetTime( AV54TFMudanzaFechaServicio_To ) ;
            AV11ExcelDocument.SetDateFormat(context, 8, 5, ((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0), DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt")), "/", ":", " ");
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+3, 1, 1).Date = GXt_dtime4;
         }
         if ( ! ( ( AV110TFMudanzaHoraServicio_Sels.Count == 0 ) ) )
         {
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Hora Servicio", "")) ;
            AV14CellRow = GXt_int3;
            AV98i = 1;
            AV125GXV1 = 1;
            while ( AV125GXV1 <= AV110TFMudanzaHoraServicio_Sels.Count )
            {
               AV109TFMudanzaHoraServicio_Sel = AV110TFMudanzaHoraServicio_Sels.GetString(AV125GXV1);
               if ( AV98i == 1 )
               {
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = "";
               }
               else
               {
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text+", ";
               }
               if ( StringUtil.StrCmp(StringUtil.Trim( AV109TFMudanzaHoraServicio_Sel), "08") == 0 )
               {
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text+"08:00";
               }
               else if ( StringUtil.StrCmp(StringUtil.Trim( AV109TFMudanzaHoraServicio_Sel), "09") == 0 )
               {
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text+"09:00";
               }
               else if ( StringUtil.StrCmp(StringUtil.Trim( AV109TFMudanzaHoraServicio_Sel), "10") == 0 )
               {
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text+"10:00";
               }
               else if ( StringUtil.StrCmp(StringUtil.Trim( AV109TFMudanzaHoraServicio_Sel), "11") == 0 )
               {
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text+"11:00";
               }
               else if ( StringUtil.StrCmp(StringUtil.Trim( AV109TFMudanzaHoraServicio_Sel), "12") == 0 )
               {
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text+"12:00";
               }
               else if ( StringUtil.StrCmp(StringUtil.Trim( AV109TFMudanzaHoraServicio_Sel), "13") == 0 )
               {
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text+"13:00";
               }
               else if ( StringUtil.StrCmp(StringUtil.Trim( AV109TFMudanzaHoraServicio_Sel), "14") == 0 )
               {
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text+"14:00";
               }
               else if ( StringUtil.StrCmp(StringUtil.Trim( AV109TFMudanzaHoraServicio_Sel), "15") == 0 )
               {
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text+"15:00";
               }
               else if ( StringUtil.StrCmp(StringUtil.Trim( AV109TFMudanzaHoraServicio_Sel), "16") == 0 )
               {
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text+"16:00";
               }
               else if ( StringUtil.StrCmp(StringUtil.Trim( AV109TFMudanzaHoraServicio_Sel), "17") == 0 )
               {
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text+"17:00";
               }
               else if ( StringUtil.StrCmp(StringUtil.Trim( AV109TFMudanzaHoraServicio_Sel), "18") == 0 )
               {
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text+"18:00";
               }
               else if ( StringUtil.StrCmp(StringUtil.Trim( AV109TFMudanzaHoraServicio_Sel), "19") == 0 )
               {
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text+"19:00";
               }
               AV98i = (long)(AV98i+1);
               AV125GXV1 = (int)(AV125GXV1+1);
            }
         }
         if ( ! ( ( AV113TFMudanzaRgoHoraservicio_Sels.Count == 0 ) ) )
         {
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Rgo Horaservicio", "")) ;
            AV14CellRow = GXt_int3;
            AV98i = 1;
            AV126GXV2 = 1;
            while ( AV126GXV2 <= AV113TFMudanzaRgoHoraservicio_Sels.Count )
            {
               AV112TFMudanzaRgoHoraservicio_Sel = AV113TFMudanzaRgoHoraservicio_Sels.GetString(AV126GXV2);
               if ( AV98i == 1 )
               {
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = "";
               }
               else
               {
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text+", ";
               }
               if ( StringUtil.StrCmp(StringUtil.Trim( AV112TFMudanzaRgoHoraservicio_Sel), "08-12") == 0 )
               {
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text+"08:00 - 12:00";
               }
               else if ( StringUtil.StrCmp(StringUtil.Trim( AV112TFMudanzaRgoHoraservicio_Sel), "12-16") == 0 )
               {
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text+"12:00 - 16:00";
               }
               else if ( StringUtil.StrCmp(StringUtil.Trim( AV112TFMudanzaRgoHoraservicio_Sel), "16-20") == 0 )
               {
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text+"16:00 - 20:00";
               }
               AV98i = (long)(AV98i+1);
               AV126GXV2 = (int)(AV126GXV2+1);
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV58TFMudanzaDireccionOrigen_Sel)) ) )
         {
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Direccion Origen", "")) ;
            AV14CellRow = GXt_int3;
            GXt_char2 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV58TFMudanzaDireccionOrigen_Sel)) ? context.GetMessage( "WWP_TitleFilter_EmptyOption", "") : AV58TFMudanzaDireccionOrigen_Sel), out  GXt_char2) ;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV57TFMudanzaDireccionOrigen)) ) )
            {
               GXt_int3 = (short)(AV14CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Direccion Origen", "")) ;
               AV14CellRow = GXt_int3;
               GXt_char2 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV57TFMudanzaDireccionOrigen, out  GXt_char2) ;
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
            }
         }
         if ( ! ( ( AV116TFMudanzaPisoDptoOrigen_Sels.Count == 0 ) ) )
         {
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Dpto Origen", "")) ;
            AV14CellRow = GXt_int3;
            AV98i = 1;
            AV127GXV3 = 1;
            while ( AV127GXV3 <= AV116TFMudanzaPisoDptoOrigen_Sels.Count )
            {
               AV115TFMudanzaPisoDptoOrigen_Sel = AV116TFMudanzaPisoDptoOrigen_Sels.GetString(AV127GXV3);
               if ( AV98i == 1 )
               {
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = "";
               }
               else
               {
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text+", ";
               }
               GXt_char2 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV115TFMudanzaPisoDptoOrigen_Sel)) ? context.GetMessage( "WWP_TitleFilter_EmptyOption", "") : AV115TFMudanzaPisoDptoOrigen_Sel), out  GXt_char2) ;
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text+GXt_char2;
               AV98i = (long)(AV98i+1);
               AV127GXV3 = (int)(AV127GXV3+1);
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV60TFMudanzaDireccionDestino_Sel)) ) )
         {
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Direccion Destino", "")) ;
            AV14CellRow = GXt_int3;
            GXt_char2 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV60TFMudanzaDireccionDestino_Sel)) ? context.GetMessage( "WWP_TitleFilter_EmptyOption", "") : AV60TFMudanzaDireccionDestino_Sel), out  GXt_char2) ;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV59TFMudanzaDireccionDestino)) ) )
            {
               GXt_int3 = (short)(AV14CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Direccion Destino", "")) ;
               AV14CellRow = GXt_int3;
               GXt_char2 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV59TFMudanzaDireccionDestino, out  GXt_char2) ;
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV118TFMudanzaPisoDptoDestino_Sel)) ) )
         {
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Dpto Destino", "")) ;
            AV14CellRow = GXt_int3;
            GXt_char2 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV118TFMudanzaPisoDptoDestino_Sel)) ? context.GetMessage( "WWP_TitleFilter_EmptyOption", "") : AV118TFMudanzaPisoDptoDestino_Sel), out  GXt_char2) ;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV117TFMudanzaPisoDptoDestino)) ) )
            {
               GXt_int3 = (short)(AV14CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Dpto Destino", "")) ;
               AV14CellRow = GXt_int3;
               GXt_char2 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV117TFMudanzaPisoDptoDestino, out  GXt_char2) ;
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
            }
         }
         if ( ! ( (Convert.ToDecimal(0)==AV61TFMudanzaDistancia) && (Convert.ToDecimal(0)==AV62TFMudanzaDistancia_To) ) )
         {
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Distancia", "")) ;
            AV14CellRow = GXt_int3;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Number = (double)(AV61TFMudanzaDistancia);
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  false, ref  GXt_int3,  (short)(AV15FirstColumn+2),  context.GetMessage( "WWP_TSTo", "")) ;
            AV14CellRow = GXt_int3;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+3, 1, 1).Number = (double)(AV62TFMudanzaDistancia_To);
         }
         if ( ! ( ( AV101TFMudanzaVehiculoSugerido_Sels.Count == 0 ) ) )
         {
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Vehiculo Sugerido", "")) ;
            AV14CellRow = GXt_int3;
            AV98i = 1;
            AV128GXV4 = 1;
            while ( AV128GXV4 <= AV101TFMudanzaVehiculoSugerido_Sels.Count )
            {
               AV100TFMudanzaVehiculoSugerido_Sel = ((string)AV101TFMudanzaVehiculoSugerido_Sels.Item(AV128GXV4));
               if ( AV98i == 1 )
               {
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = "";
               }
               else
               {
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text+", ";
               }
               GXt_char2 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV100TFMudanzaVehiculoSugerido_Sel)) ? context.GetMessage( "WWP_TitleFilter_EmptyOption", "") : AV100TFMudanzaVehiculoSugerido_Sel), out  GXt_char2) ;
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text+GXt_char2;
               AV98i = (long)(AV98i+1);
               AV128GXV4 = (int)(AV128GXV4+1);
            }
         }
         if ( ! ( (Convert.ToDecimal(0)==AV122TFMudanzaPrecioBasexHora) && (Convert.ToDecimal(0)==AV123TFMudanzaPrecioBasexHora_To) ) )
         {
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Basex Hora", "")) ;
            AV14CellRow = GXt_int3;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Number = (double)(AV122TFMudanzaPrecioBasexHora);
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  false, ref  GXt_int3,  (short)(AV15FirstColumn+2),  context.GetMessage( "WWP_TSTo", "")) ;
            AV14CellRow = GXt_int3;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+3, 1, 1).Number = (double)(AV123TFMudanzaPrecioBasexHora_To);
         }
         if ( ! ( (0==AV66TFMudanzaPeajeCantidad) && (0==AV67TFMudanzaPeajeCantidad_To) ) )
         {
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Peaje Cantidad", "")) ;
            AV14CellRow = GXt_int3;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Number = AV66TFMudanzaPeajeCantidad;
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  false, ref  GXt_int3,  (short)(AV15FirstColumn+2),  context.GetMessage( "WWP_TSTo", "")) ;
            AV14CellRow = GXt_int3;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+3, 1, 1).Number = AV67TFMudanzaPeajeCantidad_To;
         }
         if ( ! ( (Convert.ToDecimal(0)==AV68TFMudanzaPeajevalor) && (Convert.ToDecimal(0)==AV69TFMudanzaPeajevalor_To) ) )
         {
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Peajevalor", "")) ;
            AV14CellRow = GXt_int3;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Number = (double)(AV68TFMudanzaPeajevalor);
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  false, ref  GXt_int3,  (short)(AV15FirstColumn+2),  context.GetMessage( "WWP_TSTo", "")) ;
            AV14CellRow = GXt_int3;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+3, 1, 1).Number = (double)(AV69TFMudanzaPeajevalor_To);
         }
         if ( ! ( (0==AV70TFTipoInmuebleOrigenId) && (0==AV71TFTipoInmuebleOrigenId_To) ) )
         {
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Origen Id", "")) ;
            AV14CellRow = GXt_int3;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Number = AV70TFTipoInmuebleOrigenId;
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  false, ref  GXt_int3,  (short)(AV15FirstColumn+2),  context.GetMessage( "WWP_TSTo", "")) ;
            AV14CellRow = GXt_int3;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+3, 1, 1).Number = AV71TFTipoInmuebleOrigenId_To;
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV73TFTipoInmuebleOrigenNombre_Sel)) ) )
         {
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Origen Nombre", "")) ;
            AV14CellRow = GXt_int3;
            GXt_char2 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV73TFTipoInmuebleOrigenNombre_Sel)) ? context.GetMessage( "WWP_TitleFilter_EmptyOption", "") : AV73TFTipoInmuebleOrigenNombre_Sel), out  GXt_char2) ;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV119TFTipoInmuebleOrigenNombre)) ) )
            {
               GXt_int3 = (short)(AV14CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Origen Nombre", "")) ;
               AV14CellRow = GXt_int3;
               GXt_char2 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV119TFTipoInmuebleOrigenNombre, out  GXt_char2) ;
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
            }
         }
         if ( ! ( (Convert.ToDecimal(0)==AV75TFTipoInmuebleOrigenValor) && (Convert.ToDecimal(0)==AV76TFTipoInmuebleOrigenValor_To) ) )
         {
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Origen Valor", "")) ;
            AV14CellRow = GXt_int3;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Number = (double)(AV75TFTipoInmuebleOrigenValor);
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  false, ref  GXt_int3,  (short)(AV15FirstColumn+2),  context.GetMessage( "WWP_TSTo", "")) ;
            AV14CellRow = GXt_int3;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+3, 1, 1).Number = (double)(AV76TFTipoInmuebleOrigenValor_To);
         }
         AV14CellRow = (int)(AV14CellRow+2);
      }

      protected void S141( )
      {
         /* 'WRITECOLUMNTITLES' Routine */
         returnInSub = false;
         AV44VisibleColumnCount = 0;
         if ( StringUtil.StrCmp(AV32Session.Get("MudanzaWWColumnsSelector"), "") != 0 )
         {
            AV39ColumnsSelectorXML = AV32Session.Get("MudanzaWWColumnsSelector");
            AV36ColumnsSelector.FromXml(AV39ColumnsSelectorXML, null, "", "");
         }
         else
         {
            /* Execute user subroutine: 'INITIALIZECOLUMNSSELECTOR' */
            S151 ();
            if (returnInSub) return;
         }
         AV36ColumnsSelector.gxTpr_Columns.Sort("Order");
         AV129GXV5 = 1;
         while ( AV129GXV5 <= AV36ColumnsSelector.gxTpr_Columns.Count )
         {
            AV38ColumnsSelector_Column = ((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV36ColumnsSelector.gxTpr_Columns.Item(AV129GXV5));
            if ( AV38ColumnsSelector_Column.gxTpr_Isvisible )
            {
               AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV44VisibleColumnCount), 1, 1).Text = context.GetMessage( (String.IsNullOrEmpty(StringUtil.RTrim( AV38ColumnsSelector_Column.gxTpr_Displayname)) ? AV38ColumnsSelector_Column.gxTpr_Columnname : AV38ColumnsSelector_Column.gxTpr_Displayname), "");
               AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV44VisibleColumnCount), 1, 1).Bold = 1;
               AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV44VisibleColumnCount), 1, 1).Color = 11;
               AV44VisibleColumnCount = (long)(AV44VisibleColumnCount+1);
            }
            AV129GXV5 = (int)(AV129GXV5+1);
         }
      }

      protected void S161( )
      {
         /* 'WRITEDATA' Routine */
         returnInSub = false;
         AV131Mudanzawwds_1_filterfulltext = AV19FilterFullText;
         AV132Mudanzawwds_2_dynamicfiltersselector1 = AV20DynamicFiltersSelector1;
         AV133Mudanzawwds_3_dynamicfiltersoperator1 = AV21DynamicFiltersOperator1;
         AV134Mudanzawwds_4_mudanzaasesor1 = AV22MudanzaAsesor1;
         AV135Mudanzawwds_5_dynamicfiltersenabled2 = AV23DynamicFiltersEnabled2;
         AV136Mudanzawwds_6_dynamicfiltersselector2 = AV24DynamicFiltersSelector2;
         AV137Mudanzawwds_7_dynamicfiltersoperator2 = AV25DynamicFiltersOperator2;
         AV138Mudanzawwds_8_mudanzaasesor2 = AV26MudanzaAsesor2;
         AV139Mudanzawwds_9_dynamicfiltersenabled3 = AV27DynamicFiltersEnabled3;
         AV140Mudanzawwds_10_dynamicfiltersselector3 = AV28DynamicFiltersSelector3;
         AV141Mudanzawwds_11_dynamicfiltersoperator3 = AV29DynamicFiltersOperator3;
         AV142Mudanzawwds_12_mudanzaasesor3 = AV30MudanzaAsesor3;
         AV143Mudanzawwds_13_tfmudanzaid = AV47TFMudanzaId;
         AV144Mudanzawwds_14_tfmudanzaid_to = AV48TFMudanzaId_To;
         AV145Mudanzawwds_15_tfmudanzaasesor = AV49TFMudanzaAsesor;
         AV146Mudanzawwds_16_tfmudanzaasesor_sel = AV50TFMudanzaAsesor_Sel;
         AV147Mudanzawwds_17_tfmudanzafechaalta = AV51TFMudanzaFechaAlta;
         AV148Mudanzawwds_18_tfmudanzafechaalta_to = AV52TFMudanzaFechaAlta_To;
         AV149Mudanzawwds_19_tfmudanzafechaservicio = AV53TFMudanzaFechaServicio;
         AV150Mudanzawwds_20_tfmudanzafechaservicio_to = AV54TFMudanzaFechaServicio_To;
         AV151Mudanzawwds_21_tfmudanzahoraservicio_sels = AV110TFMudanzaHoraServicio_Sels;
         AV152Mudanzawwds_22_tfmudanzargohoraservicio_sels = AV113TFMudanzaRgoHoraservicio_Sels;
         AV153Mudanzawwds_23_tfmudanzadireccionorigen = AV57TFMudanzaDireccionOrigen;
         AV154Mudanzawwds_24_tfmudanzadireccionorigen_sel = AV58TFMudanzaDireccionOrigen_Sel;
         AV155Mudanzawwds_25_tfmudanzapisodptoorigen_sels = AV116TFMudanzaPisoDptoOrigen_Sels;
         AV156Mudanzawwds_26_tfmudanzadirecciondestino = AV59TFMudanzaDireccionDestino;
         AV157Mudanzawwds_27_tfmudanzadirecciondestino_sel = AV60TFMudanzaDireccionDestino_Sel;
         AV158Mudanzawwds_28_tfmudanzapisodptodestino = AV117TFMudanzaPisoDptoDestino;
         AV159Mudanzawwds_29_tfmudanzapisodptodestino_sel = AV118TFMudanzaPisoDptoDestino_Sel;
         AV160Mudanzawwds_30_tfmudanzadistancia = AV61TFMudanzaDistancia;
         AV161Mudanzawwds_31_tfmudanzadistancia_to = AV62TFMudanzaDistancia_To;
         AV162Mudanzawwds_32_tfmudanzavehiculosugerido_sels = AV101TFMudanzaVehiculoSugerido_Sels;
         AV163Mudanzawwds_33_tfmudanzapreciobasexhora = AV122TFMudanzaPrecioBasexHora;
         AV164Mudanzawwds_34_tfmudanzapreciobasexhora_to = AV123TFMudanzaPrecioBasexHora_To;
         AV165Mudanzawwds_35_tfmudanzapeajecantidad = AV66TFMudanzaPeajeCantidad;
         AV166Mudanzawwds_36_tfmudanzapeajecantidad_to = AV67TFMudanzaPeajeCantidad_To;
         AV167Mudanzawwds_37_tfmudanzapeajevalor = AV68TFMudanzaPeajevalor;
         AV168Mudanzawwds_38_tfmudanzapeajevalor_to = AV69TFMudanzaPeajevalor_To;
         AV169Mudanzawwds_39_tftipoinmuebleorigenid = AV70TFTipoInmuebleOrigenId;
         AV170Mudanzawwds_40_tftipoinmuebleorigenid_to = AV71TFTipoInmuebleOrigenId_To;
         AV171Mudanzawwds_41_tftipoinmuebleorigennombre = AV119TFTipoInmuebleOrigenNombre;
         AV172Mudanzawwds_42_tftipoinmuebleorigennombre_sel = AV73TFTipoInmuebleOrigenNombre_Sel;
         AV173Mudanzawwds_43_tftipoinmuebleorigenvalor = AV75TFTipoInmuebleOrigenValor;
         AV174Mudanzawwds_44_tftipoinmuebleorigenvalor_to = AV76TFTipoInmuebleOrigenValor_To;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A739MudanzaHoraServicio ,
                                              AV151Mudanzawwds_21_tfmudanzahoraservicio_sels ,
                                              A776MudanzaRgoHoraservicio ,
                                              AV152Mudanzawwds_22_tfmudanzargohoraservicio_sels ,
                                              A777MudanzaPisoDptoOrigen ,
                                              AV155Mudanzawwds_25_tfmudanzapisodptoorigen_sels ,
                                              A742MudanzaVehiculoSugerido ,
                                              AV162Mudanzawwds_32_tfmudanzavehiculosugerido_sels ,
                                              AV131Mudanzawwds_1_filterfulltext ,
                                              AV132Mudanzawwds_2_dynamicfiltersselector1 ,
                                              AV133Mudanzawwds_3_dynamicfiltersoperator1 ,
                                              AV134Mudanzawwds_4_mudanzaasesor1 ,
                                              AV135Mudanzawwds_5_dynamicfiltersenabled2 ,
                                              AV136Mudanzawwds_6_dynamicfiltersselector2 ,
                                              AV137Mudanzawwds_7_dynamicfiltersoperator2 ,
                                              AV138Mudanzawwds_8_mudanzaasesor2 ,
                                              AV139Mudanzawwds_9_dynamicfiltersenabled3 ,
                                              AV140Mudanzawwds_10_dynamicfiltersselector3 ,
                                              AV141Mudanzawwds_11_dynamicfiltersoperator3 ,
                                              AV142Mudanzawwds_12_mudanzaasesor3 ,
                                              AV143Mudanzawwds_13_tfmudanzaid ,
                                              AV144Mudanzawwds_14_tfmudanzaid_to ,
                                              AV146Mudanzawwds_16_tfmudanzaasesor_sel ,
                                              AV145Mudanzawwds_15_tfmudanzaasesor ,
                                              AV147Mudanzawwds_17_tfmudanzafechaalta ,
                                              AV148Mudanzawwds_18_tfmudanzafechaalta_to ,
                                              AV149Mudanzawwds_19_tfmudanzafechaservicio ,
                                              AV150Mudanzawwds_20_tfmudanzafechaservicio_to ,
                                              AV151Mudanzawwds_21_tfmudanzahoraservicio_sels.Count ,
                                              AV152Mudanzawwds_22_tfmudanzargohoraservicio_sels.Count ,
                                              AV154Mudanzawwds_24_tfmudanzadireccionorigen_sel ,
                                              AV153Mudanzawwds_23_tfmudanzadireccionorigen ,
                                              AV155Mudanzawwds_25_tfmudanzapisodptoorigen_sels.Count ,
                                              AV157Mudanzawwds_27_tfmudanzadirecciondestino_sel ,
                                              AV156Mudanzawwds_26_tfmudanzadirecciondestino ,
                                              AV159Mudanzawwds_29_tfmudanzapisodptodestino_sel ,
                                              AV158Mudanzawwds_28_tfmudanzapisodptodestino ,
                                              AV160Mudanzawwds_30_tfmudanzadistancia ,
                                              AV161Mudanzawwds_31_tfmudanzadistancia_to ,
                                              AV162Mudanzawwds_32_tfmudanzavehiculosugerido_sels.Count ,
                                              AV163Mudanzawwds_33_tfmudanzapreciobasexhora ,
                                              AV164Mudanzawwds_34_tfmudanzapreciobasexhora_to ,
                                              AV165Mudanzawwds_35_tfmudanzapeajecantidad ,
                                              AV166Mudanzawwds_36_tfmudanzapeajecantidad_to ,
                                              AV167Mudanzawwds_37_tfmudanzapeajevalor ,
                                              AV168Mudanzawwds_38_tfmudanzapeajevalor_to ,
                                              AV169Mudanzawwds_39_tftipoinmuebleorigenid ,
                                              AV170Mudanzawwds_40_tftipoinmuebleorigenid_to ,
                                              AV172Mudanzawwds_42_tftipoinmuebleorigennombre_sel ,
                                              AV171Mudanzawwds_41_tftipoinmuebleorigennombre ,
                                              AV173Mudanzawwds_43_tftipoinmuebleorigenvalor ,
                                              AV174Mudanzawwds_44_tftipoinmuebleorigenvalor_to ,
                                              A735MudanzaId ,
                                              A736MudanzaAsesor ,
                                              A740MudanzaDireccionOrigen ,
                                              A741MudanzaDireccionDestino ,
                                              A778MudanzaPisoDptoDestino ,
                                              A762MudanzaDistancia ,
                                              A780MudanzaPrecioBasexHora ,
                                              A761MudanzaPeajeCantidad ,
                                              A760MudanzaPeajevalor ,
                                              A743TipoInmuebleOrigenId ,
                                              A755TipoInmuebleOrigenNombre ,
                                              A756TipoInmuebleOrigenValor ,
                                              A737MudanzaFechaAlta ,
                                              A738MudanzaFechaServicio ,
                                              AV17OrderedBy ,
                                              AV18OrderedDsc } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.DATE,
                                              TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.INT, TypeConstants.DECIMAL,
                                              TypeConstants.DECIMAL, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.LONG,
                                              TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.SHORT, TypeConstants.DECIMAL, TypeConstants.SHORT, TypeConstants.DECIMAL, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV131Mudanzawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV131Mudanzawwds_1_filterfulltext), "%", "");
         lV131Mudanzawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV131Mudanzawwds_1_filterfulltext), "%", "");
         lV131Mudanzawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV131Mudanzawwds_1_filterfulltext), "%", "");
         lV131Mudanzawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV131Mudanzawwds_1_filterfulltext), "%", "");
         lV131Mudanzawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV131Mudanzawwds_1_filterfulltext), "%", "");
         lV131Mudanzawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV131Mudanzawwds_1_filterfulltext), "%", "");
         lV131Mudanzawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV131Mudanzawwds_1_filterfulltext), "%", "");
         lV131Mudanzawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV131Mudanzawwds_1_filterfulltext), "%", "");
         lV131Mudanzawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV131Mudanzawwds_1_filterfulltext), "%", "");
         lV131Mudanzawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV131Mudanzawwds_1_filterfulltext), "%", "");
         lV131Mudanzawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV131Mudanzawwds_1_filterfulltext), "%", "");
         lV131Mudanzawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV131Mudanzawwds_1_filterfulltext), "%", "");
         lV131Mudanzawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV131Mudanzawwds_1_filterfulltext), "%", "");
         lV131Mudanzawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV131Mudanzawwds_1_filterfulltext), "%", "");
         lV131Mudanzawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV131Mudanzawwds_1_filterfulltext), "%", "");
         lV131Mudanzawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV131Mudanzawwds_1_filterfulltext), "%", "");
         lV131Mudanzawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV131Mudanzawwds_1_filterfulltext), "%", "");
         lV131Mudanzawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV131Mudanzawwds_1_filterfulltext), "%", "");
         lV131Mudanzawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV131Mudanzawwds_1_filterfulltext), "%", "");
         lV131Mudanzawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV131Mudanzawwds_1_filterfulltext), "%", "");
         lV131Mudanzawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV131Mudanzawwds_1_filterfulltext), "%", "");
         lV131Mudanzawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV131Mudanzawwds_1_filterfulltext), "%", "");
         lV131Mudanzawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV131Mudanzawwds_1_filterfulltext), "%", "");
         lV131Mudanzawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV131Mudanzawwds_1_filterfulltext), "%", "");
         lV131Mudanzawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV131Mudanzawwds_1_filterfulltext), "%", "");
         lV131Mudanzawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV131Mudanzawwds_1_filterfulltext), "%", "");
         lV131Mudanzawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV131Mudanzawwds_1_filterfulltext), "%", "");
         lV131Mudanzawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV131Mudanzawwds_1_filterfulltext), "%", "");
         lV131Mudanzawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV131Mudanzawwds_1_filterfulltext), "%", "");
         lV134Mudanzawwds_4_mudanzaasesor1 = StringUtil.Concat( StringUtil.RTrim( AV134Mudanzawwds_4_mudanzaasesor1), "%", "");
         lV134Mudanzawwds_4_mudanzaasesor1 = StringUtil.Concat( StringUtil.RTrim( AV134Mudanzawwds_4_mudanzaasesor1), "%", "");
         lV138Mudanzawwds_8_mudanzaasesor2 = StringUtil.Concat( StringUtil.RTrim( AV138Mudanzawwds_8_mudanzaasesor2), "%", "");
         lV138Mudanzawwds_8_mudanzaasesor2 = StringUtil.Concat( StringUtil.RTrim( AV138Mudanzawwds_8_mudanzaasesor2), "%", "");
         lV142Mudanzawwds_12_mudanzaasesor3 = StringUtil.Concat( StringUtil.RTrim( AV142Mudanzawwds_12_mudanzaasesor3), "%", "");
         lV142Mudanzawwds_12_mudanzaasesor3 = StringUtil.Concat( StringUtil.RTrim( AV142Mudanzawwds_12_mudanzaasesor3), "%", "");
         lV145Mudanzawwds_15_tfmudanzaasesor = StringUtil.Concat( StringUtil.RTrim( AV145Mudanzawwds_15_tfmudanzaasesor), "%", "");
         lV153Mudanzawwds_23_tfmudanzadireccionorigen = StringUtil.Concat( StringUtil.RTrim( AV153Mudanzawwds_23_tfmudanzadireccionorigen), "%", "");
         lV156Mudanzawwds_26_tfmudanzadirecciondestino = StringUtil.Concat( StringUtil.RTrim( AV156Mudanzawwds_26_tfmudanzadirecciondestino), "%", "");
         lV158Mudanzawwds_28_tfmudanzapisodptodestino = StringUtil.PadR( StringUtil.RTrim( AV158Mudanzawwds_28_tfmudanzapisodptodestino), 30, "%");
         lV171Mudanzawwds_41_tftipoinmuebleorigennombre = StringUtil.Concat( StringUtil.RTrim( AV171Mudanzawwds_41_tftipoinmuebleorigennombre), "%", "");
         /* Using cursor P00DS2 */
         pr_default.execute(0, new Object[] {lV131Mudanzawwds_1_filterfulltext, lV131Mudanzawwds_1_filterfulltext, lV131Mudanzawwds_1_filterfulltext, lV131Mudanzawwds_1_filterfulltext, lV131Mudanzawwds_1_filterfulltext, lV131Mudanzawwds_1_filterfulltext, lV131Mudanzawwds_1_filterfulltext, lV131Mudanzawwds_1_filterfulltext, lV131Mudanzawwds_1_filterfulltext, lV131Mudanzawwds_1_filterfulltext, lV131Mudanzawwds_1_filterfulltext, lV131Mudanzawwds_1_filterfulltext, lV131Mudanzawwds_1_filterfulltext, lV131Mudanzawwds_1_filterfulltext, lV131Mudanzawwds_1_filterfulltext, lV131Mudanzawwds_1_filterfulltext, lV131Mudanzawwds_1_filterfulltext, lV131Mudanzawwds_1_filterfulltext, lV131Mudanzawwds_1_filterfulltext, lV131Mudanzawwds_1_filterfulltext, lV131Mudanzawwds_1_filterfulltext, lV131Mudanzawwds_1_filterfulltext, lV131Mudanzawwds_1_filterfulltext, lV131Mudanzawwds_1_filterfulltext, lV131Mudanzawwds_1_filterfulltext, lV131Mudanzawwds_1_filterfulltext, lV131Mudanzawwds_1_filterfulltext, lV131Mudanzawwds_1_filterfulltext, lV131Mudanzawwds_1_filterfulltext, lV134Mudanzawwds_4_mudanzaasesor1, lV134Mudanzawwds_4_mudanzaasesor1, lV138Mudanzawwds_8_mudanzaasesor2, lV138Mudanzawwds_8_mudanzaasesor2, lV142Mudanzawwds_12_mudanzaasesor3, lV142Mudanzawwds_12_mudanzaasesor3, AV143Mudanzawwds_13_tfmudanzaid, AV144Mudanzawwds_14_tfmudanzaid_to, lV145Mudanzawwds_15_tfmudanzaasesor, AV146Mudanzawwds_16_tfmudanzaasesor_sel, AV147Mudanzawwds_17_tfmudanzafechaalta, AV148Mudanzawwds_18_tfmudanzafechaalta_to, AV149Mudanzawwds_19_tfmudanzafechaservicio, AV150Mudanzawwds_20_tfmudanzafechaservicio_to, lV153Mudanzawwds_23_tfmudanzadireccionorigen, AV154Mudanzawwds_24_tfmudanzadireccionorigen_sel, lV156Mudanzawwds_26_tfmudanzadirecciondestino, AV157Mudanzawwds_27_tfmudanzadirecciondestino_sel, lV158Mudanzawwds_28_tfmudanzapisodptodestino, AV159Mudanzawwds_29_tfmudanzapisodptodestino_sel, AV160Mudanzawwds_30_tfmudanzadistancia, AV161Mudanzawwds_31_tfmudanzadistancia_to, AV163Mudanzawwds_33_tfmudanzapreciobasexhora, AV164Mudanzawwds_34_tfmudanzapreciobasexhora_to, AV165Mudanzawwds_35_tfmudanzapeajecantidad, AV166Mudanzawwds_36_tfmudanzapeajecantidad_to, AV167Mudanzawwds_37_tfmudanzapeajevalor, AV168Mudanzawwds_38_tfmudanzapeajevalor_to, AV169Mudanzawwds_39_tftipoinmuebleorigenid, AV170Mudanzawwds_40_tftipoinmuebleorigenid_to, lV171Mudanzawwds_41_tftipoinmuebleorigennombre, AV172Mudanzawwds_42_tftipoinmuebleorigennombre_sel, AV173Mudanzawwds_43_tftipoinmuebleorigenvalor, AV174Mudanzawwds_44_tftipoinmuebleorigenvalor_to});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A756TipoInmuebleOrigenValor = P00DS2_A756TipoInmuebleOrigenValor[0];
            A755TipoInmuebleOrigenNombre = P00DS2_A755TipoInmuebleOrigenNombre[0];
            A743TipoInmuebleOrigenId = P00DS2_A743TipoInmuebleOrigenId[0];
            A760MudanzaPeajevalor = P00DS2_A760MudanzaPeajevalor[0];
            A761MudanzaPeajeCantidad = P00DS2_A761MudanzaPeajeCantidad[0];
            A780MudanzaPrecioBasexHora = P00DS2_A780MudanzaPrecioBasexHora[0];
            A742MudanzaVehiculoSugerido = P00DS2_A742MudanzaVehiculoSugerido[0];
            A762MudanzaDistancia = P00DS2_A762MudanzaDistancia[0];
            A778MudanzaPisoDptoDestino = P00DS2_A778MudanzaPisoDptoDestino[0];
            A741MudanzaDireccionDestino = P00DS2_A741MudanzaDireccionDestino[0];
            A777MudanzaPisoDptoOrigen = P00DS2_A777MudanzaPisoDptoOrigen[0];
            A740MudanzaDireccionOrigen = P00DS2_A740MudanzaDireccionOrigen[0];
            A738MudanzaFechaServicio = P00DS2_A738MudanzaFechaServicio[0];
            A737MudanzaFechaAlta = P00DS2_A737MudanzaFechaAlta[0];
            A736MudanzaAsesor = P00DS2_A736MudanzaAsesor[0];
            A735MudanzaId = P00DS2_A735MudanzaId[0];
            A776MudanzaRgoHoraservicio = P00DS2_A776MudanzaRgoHoraservicio[0];
            n776MudanzaRgoHoraservicio = P00DS2_n776MudanzaRgoHoraservicio[0];
            A739MudanzaHoraServicio = P00DS2_A739MudanzaHoraServicio[0];
            n739MudanzaHoraServicio = P00DS2_n739MudanzaHoraServicio[0];
            A756TipoInmuebleOrigenValor = P00DS2_A756TipoInmuebleOrigenValor[0];
            A755TipoInmuebleOrigenNombre = P00DS2_A755TipoInmuebleOrigenNombre[0];
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
            AV175GXV6 = 1;
            while ( AV175GXV6 <= AV36ColumnsSelector.gxTpr_Columns.Count )
            {
               AV38ColumnsSelector_Column = ((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV36ColumnsSelector.gxTpr_Columns.Item(AV175GXV6));
               if ( AV38ColumnsSelector_Column.gxTpr_Isvisible )
               {
                  if ( StringUtil.StrCmp(AV38ColumnsSelector_Column.gxTpr_Columnname, "MudanzaId") == 0 )
                  {
                     AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV44VisibleColumnCount), 1, 1).Number = A735MudanzaId;
                  }
                  else if ( StringUtil.StrCmp(AV38ColumnsSelector_Column.gxTpr_Columnname, "MudanzaAsesor") == 0 )
                  {
                     GXt_char2 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A736MudanzaAsesor, out  GXt_char2) ;
                     AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV44VisibleColumnCount), 1, 1).Text = GXt_char2;
                  }
                  else if ( StringUtil.StrCmp(AV38ColumnsSelector_Column.gxTpr_Columnname, "MudanzaFechaAlta") == 0 )
                  {
                     GXt_dtime4 = DateTimeUtil.ResetTime( A737MudanzaFechaAlta ) ;
                     AV11ExcelDocument.SetDateFormat(context, 8, 5, ((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0), DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt")), "/", ":", " ");
                     AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV44VisibleColumnCount), 1, 1).Date = GXt_dtime4;
                  }
                  else if ( StringUtil.StrCmp(AV38ColumnsSelector_Column.gxTpr_Columnname, "MudanzaFechaServicio") == 0 )
                  {
                     GXt_dtime4 = DateTimeUtil.ResetTime( A738MudanzaFechaServicio ) ;
                     AV11ExcelDocument.SetDateFormat(context, 8, 5, ((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0), DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt")), "/", ":", " ");
                     AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV44VisibleColumnCount), 1, 1).Date = GXt_dtime4;
                  }
                  else if ( StringUtil.StrCmp(AV38ColumnsSelector_Column.gxTpr_Columnname, "MudanzaHoraServicio") == 0 )
                  {
                     AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV44VisibleColumnCount), 1, 1).Text = "";
                     if ( StringUtil.StrCmp(StringUtil.Trim( A739MudanzaHoraServicio), "08") == 0 )
                     {
                        AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV44VisibleColumnCount), 1, 1).Text = "08:00";
                     }
                     else if ( StringUtil.StrCmp(StringUtil.Trim( A739MudanzaHoraServicio), "09") == 0 )
                     {
                        AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV44VisibleColumnCount), 1, 1).Text = "09:00";
                     }
                     else if ( StringUtil.StrCmp(StringUtil.Trim( A739MudanzaHoraServicio), "10") == 0 )
                     {
                        AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV44VisibleColumnCount), 1, 1).Text = "10:00";
                     }
                     else if ( StringUtil.StrCmp(StringUtil.Trim( A739MudanzaHoraServicio), "11") == 0 )
                     {
                        AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV44VisibleColumnCount), 1, 1).Text = "11:00";
                     }
                     else if ( StringUtil.StrCmp(StringUtil.Trim( A739MudanzaHoraServicio), "12") == 0 )
                     {
                        AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV44VisibleColumnCount), 1, 1).Text = "12:00";
                     }
                     else if ( StringUtil.StrCmp(StringUtil.Trim( A739MudanzaHoraServicio), "13") == 0 )
                     {
                        AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV44VisibleColumnCount), 1, 1).Text = "13:00";
                     }
                     else if ( StringUtil.StrCmp(StringUtil.Trim( A739MudanzaHoraServicio), "14") == 0 )
                     {
                        AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV44VisibleColumnCount), 1, 1).Text = "14:00";
                     }
                     else if ( StringUtil.StrCmp(StringUtil.Trim( A739MudanzaHoraServicio), "15") == 0 )
                     {
                        AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV44VisibleColumnCount), 1, 1).Text = "15:00";
                     }
                     else if ( StringUtil.StrCmp(StringUtil.Trim( A739MudanzaHoraServicio), "16") == 0 )
                     {
                        AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV44VisibleColumnCount), 1, 1).Text = "16:00";
                     }
                     else if ( StringUtil.StrCmp(StringUtil.Trim( A739MudanzaHoraServicio), "17") == 0 )
                     {
                        AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV44VisibleColumnCount), 1, 1).Text = "17:00";
                     }
                     else if ( StringUtil.StrCmp(StringUtil.Trim( A739MudanzaHoraServicio), "18") == 0 )
                     {
                        AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV44VisibleColumnCount), 1, 1).Text = "18:00";
                     }
                     else if ( StringUtil.StrCmp(StringUtil.Trim( A739MudanzaHoraServicio), "19") == 0 )
                     {
                        AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV44VisibleColumnCount), 1, 1).Text = "19:00";
                     }
                  }
                  else if ( StringUtil.StrCmp(AV38ColumnsSelector_Column.gxTpr_Columnname, "MudanzaRgoHoraservicio") == 0 )
                  {
                     AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV44VisibleColumnCount), 1, 1).Text = "";
                     if ( StringUtil.StrCmp(StringUtil.Trim( A776MudanzaRgoHoraservicio), "08-12") == 0 )
                     {
                        AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV44VisibleColumnCount), 1, 1).Text = "08:00 - 12:00";
                     }
                     else if ( StringUtil.StrCmp(StringUtil.Trim( A776MudanzaRgoHoraservicio), "12-16") == 0 )
                     {
                        AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV44VisibleColumnCount), 1, 1).Text = "12:00 - 16:00";
                     }
                     else if ( StringUtil.StrCmp(StringUtil.Trim( A776MudanzaRgoHoraservicio), "16-20") == 0 )
                     {
                        AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV44VisibleColumnCount), 1, 1).Text = "16:00 - 20:00";
                     }
                  }
                  else if ( StringUtil.StrCmp(AV38ColumnsSelector_Column.gxTpr_Columnname, "MudanzaDireccionOrigen") == 0 )
                  {
                     GXt_char2 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A740MudanzaDireccionOrigen, out  GXt_char2) ;
                     AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV44VisibleColumnCount), 1, 1).Text = GXt_char2;
                  }
                  else if ( StringUtil.StrCmp(AV38ColumnsSelector_Column.gxTpr_Columnname, "MudanzaPisoDptoOrigen") == 0 )
                  {
                     GXt_char2 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A777MudanzaPisoDptoOrigen, out  GXt_char2) ;
                     AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV44VisibleColumnCount), 1, 1).Text = GXt_char2;
                  }
                  else if ( StringUtil.StrCmp(AV38ColumnsSelector_Column.gxTpr_Columnname, "MudanzaDireccionDestino") == 0 )
                  {
                     GXt_char2 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A741MudanzaDireccionDestino, out  GXt_char2) ;
                     AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV44VisibleColumnCount), 1, 1).Text = GXt_char2;
                  }
                  else if ( StringUtil.StrCmp(AV38ColumnsSelector_Column.gxTpr_Columnname, "MudanzaPisoDptoDestino") == 0 )
                  {
                     GXt_char2 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A778MudanzaPisoDptoDestino, out  GXt_char2) ;
                     AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV44VisibleColumnCount), 1, 1).Text = GXt_char2;
                  }
                  else if ( StringUtil.StrCmp(AV38ColumnsSelector_Column.gxTpr_Columnname, "MudanzaDistancia") == 0 )
                  {
                     AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV44VisibleColumnCount), 1, 1).Number = (double)(A762MudanzaDistancia);
                  }
                  else if ( StringUtil.StrCmp(AV38ColumnsSelector_Column.gxTpr_Columnname, "MudanzaVehiculoSugerido") == 0 )
                  {
                     GXt_char2 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A742MudanzaVehiculoSugerido, out  GXt_char2) ;
                     AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV44VisibleColumnCount), 1, 1).Text = GXt_char2;
                  }
                  else if ( StringUtil.StrCmp(AV38ColumnsSelector_Column.gxTpr_Columnname, "MudanzaPrecioBasexHora") == 0 )
                  {
                     AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV44VisibleColumnCount), 1, 1).Number = (double)(A780MudanzaPrecioBasexHora);
                  }
                  else if ( StringUtil.StrCmp(AV38ColumnsSelector_Column.gxTpr_Columnname, "MudanzaPeajeCantidad") == 0 )
                  {
                     AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV44VisibleColumnCount), 1, 1).Number = A761MudanzaPeajeCantidad;
                  }
                  else if ( StringUtil.StrCmp(AV38ColumnsSelector_Column.gxTpr_Columnname, "MudanzaPeajevalor") == 0 )
                  {
                     AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV44VisibleColumnCount), 1, 1).Number = (double)(A760MudanzaPeajevalor);
                  }
                  else if ( StringUtil.StrCmp(AV38ColumnsSelector_Column.gxTpr_Columnname, "TipoInmuebleOrigenId") == 0 )
                  {
                     AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV44VisibleColumnCount), 1, 1).Number = A743TipoInmuebleOrigenId;
                  }
                  else if ( StringUtil.StrCmp(AV38ColumnsSelector_Column.gxTpr_Columnname, "TipoInmuebleOrigenNombre") == 0 )
                  {
                     GXt_char2 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A755TipoInmuebleOrigenNombre, out  GXt_char2) ;
                     AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV44VisibleColumnCount), 1, 1).Text = GXt_char2;
                  }
                  else if ( StringUtil.StrCmp(AV38ColumnsSelector_Column.gxTpr_Columnname, "TipoInmuebleOrigenValor") == 0 )
                  {
                     AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV44VisibleColumnCount), 1, 1).Number = (double)(A756TipoInmuebleOrigenValor);
                  }
                  AV44VisibleColumnCount = (long)(AV44VisibleColumnCount+1);
               }
               AV175GXV6 = (int)(AV175GXV6+1);
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
         AV32Session.Set("WWPExportFileName", "MudanzaWWExport.xlsx");
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
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV36ColumnsSelector,  "MudanzaId",  "",  "Id",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV36ColumnsSelector,  "MudanzaAsesor",  "",  "Asesor",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV36ColumnsSelector,  "MudanzaFechaAlta",  "",  "Fecha Alta",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV36ColumnsSelector,  "MudanzaFechaServicio",  "",  "Fecha Servicio",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV36ColumnsSelector,  "MudanzaHoraServicio",  "",  "Hora Servicio",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV36ColumnsSelector,  "MudanzaRgoHoraservicio",  "",  "Rgo Horaservicio",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV36ColumnsSelector,  "MudanzaDireccionOrigen",  "",  "Direccion Origen",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV36ColumnsSelector,  "MudanzaPisoDptoOrigen",  "",  "Dpto Origen",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV36ColumnsSelector,  "MudanzaDireccionDestino",  "",  "Direccion Destino",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV36ColumnsSelector,  "MudanzaPisoDptoDestino",  "",  "Dpto Destino",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV36ColumnsSelector,  "MudanzaDistancia",  "",  "Distancia",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV36ColumnsSelector,  "MudanzaVehiculoSugerido",  "",  "Vehiculo Sugerido",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV36ColumnsSelector,  "MudanzaPrecioBasexHora",  "",  "Basex Hora",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV36ColumnsSelector,  "MudanzaPeajeCantidad",  "",  "Peaje Cantidad",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV36ColumnsSelector,  "MudanzaPeajevalor",  "",  "Peajevalor",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV36ColumnsSelector,  "TipoInmuebleOrigenId",  "",  "Origen Id",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV36ColumnsSelector,  "TipoInmuebleOrigenNombre",  "",  "Origen Nombre",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV36ColumnsSelector,  "TipoInmuebleOrigenValor",  "",  "Origen Valor",  true,  "") ;
         GXt_char2 = AV40UserCustomValue;
         new GeneXus.Programs.wwpbaseobjects.loadcolumnsselectorstate(context ).execute(  "MudanzaWWColumnsSelector", out  GXt_char2) ;
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
         if ( StringUtil.StrCmp(AV32Session.Get("MudanzaWWGridState"), "") == 0 )
         {
            AV34GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "MudanzaWWGridState"), null, "", "");
         }
         else
         {
            AV34GridState.FromXml(AV32Session.Get("MudanzaWWGridState"), null, "", "");
         }
         AV17OrderedBy = AV34GridState.gxTpr_Orderedby;
         AV18OrderedDsc = AV34GridState.gxTpr_Ordereddsc;
         AV176GXV7 = 1;
         while ( AV176GXV7 <= AV34GridState.gxTpr_Filtervalues.Count )
         {
            AV35GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV34GridState.gxTpr_Filtervalues.Item(AV176GXV7));
            if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV19FilterFullText = AV35GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFMUDANZAID") == 0 )
            {
               AV47TFMudanzaId = (long)(Math.Round(NumberUtil.Val( AV35GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV48TFMudanzaId_To = (long)(Math.Round(NumberUtil.Val( AV35GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFMUDANZAASESOR") == 0 )
            {
               AV49TFMudanzaAsesor = AV35GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFMUDANZAASESOR_SEL") == 0 )
            {
               AV50TFMudanzaAsesor_Sel = AV35GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFMUDANZAFECHAALTA") == 0 )
            {
               AV51TFMudanzaFechaAlta = context.localUtil.CToD( AV35GridStateFilterValue.gxTpr_Value, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               AV52TFMudanzaFechaAlta_To = context.localUtil.CToD( AV35GridStateFilterValue.gxTpr_Valueto, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFMUDANZAFECHASERVICIO") == 0 )
            {
               AV53TFMudanzaFechaServicio = context.localUtil.CToD( AV35GridStateFilterValue.gxTpr_Value, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               AV54TFMudanzaFechaServicio_To = context.localUtil.CToD( AV35GridStateFilterValue.gxTpr_Valueto, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFMUDANZAHORASERVICIO_SEL") == 0 )
            {
               AV108TFMudanzaHoraServicio_SelsJson = AV35GridStateFilterValue.gxTpr_Value;
               AV110TFMudanzaHoraServicio_Sels.FromJSonString(AV108TFMudanzaHoraServicio_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFMUDANZARGOHORASERVICIO_SEL") == 0 )
            {
               AV111TFMudanzaRgoHoraservicio_SelsJson = AV35GridStateFilterValue.gxTpr_Value;
               AV113TFMudanzaRgoHoraservicio_Sels.FromJSonString(AV111TFMudanzaRgoHoraservicio_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFMUDANZADIRECCIONORIGEN") == 0 )
            {
               AV57TFMudanzaDireccionOrigen = AV35GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFMUDANZADIRECCIONORIGEN_SEL") == 0 )
            {
               AV58TFMudanzaDireccionOrigen_Sel = AV35GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFMUDANZAPISODPTOORIGEN_SEL") == 0 )
            {
               AV114TFMudanzaPisoDptoOrigen_SelsJson = AV35GridStateFilterValue.gxTpr_Value;
               AV116TFMudanzaPisoDptoOrigen_Sels.FromJSonString(AV114TFMudanzaPisoDptoOrigen_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFMUDANZADIRECCIONDESTINO") == 0 )
            {
               AV59TFMudanzaDireccionDestino = AV35GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFMUDANZADIRECCIONDESTINO_SEL") == 0 )
            {
               AV60TFMudanzaDireccionDestino_Sel = AV35GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFMUDANZAPISODPTODESTINO") == 0 )
            {
               AV117TFMudanzaPisoDptoDestino = AV35GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFMUDANZAPISODPTODESTINO_SEL") == 0 )
            {
               AV118TFMudanzaPisoDptoDestino_Sel = AV35GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFMUDANZADISTANCIA") == 0 )
            {
               AV61TFMudanzaDistancia = NumberUtil.Val( AV35GridStateFilterValue.gxTpr_Value, ".");
               AV62TFMudanzaDistancia_To = NumberUtil.Val( AV35GridStateFilterValue.gxTpr_Valueto, ".");
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFMUDANZAVEHICULOSUGERIDO_SEL") == 0 )
            {
               AV99TFMudanzaVehiculoSugerido_SelsJson = AV35GridStateFilterValue.gxTpr_Value;
               AV101TFMudanzaVehiculoSugerido_Sels.FromJSonString(AV99TFMudanzaVehiculoSugerido_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFMUDANZAPRECIOBASEXHORA") == 0 )
            {
               AV122TFMudanzaPrecioBasexHora = NumberUtil.Val( AV35GridStateFilterValue.gxTpr_Value, ".");
               AV123TFMudanzaPrecioBasexHora_To = NumberUtil.Val( AV35GridStateFilterValue.gxTpr_Valueto, ".");
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFMUDANZAPEAJECANTIDAD") == 0 )
            {
               AV66TFMudanzaPeajeCantidad = (short)(Math.Round(NumberUtil.Val( AV35GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV67TFMudanzaPeajeCantidad_To = (short)(Math.Round(NumberUtil.Val( AV35GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFMUDANZAPEAJEVALOR") == 0 )
            {
               AV68TFMudanzaPeajevalor = NumberUtil.Val( AV35GridStateFilterValue.gxTpr_Value, ".");
               AV69TFMudanzaPeajevalor_To = NumberUtil.Val( AV35GridStateFilterValue.gxTpr_Valueto, ".");
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFTIPOINMUEBLEORIGENID") == 0 )
            {
               AV70TFTipoInmuebleOrigenId = (short)(Math.Round(NumberUtil.Val( AV35GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV71TFTipoInmuebleOrigenId_To = (short)(Math.Round(NumberUtil.Val( AV35GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFTIPOINMUEBLEORIGENNOMBRE") == 0 )
            {
               AV119TFTipoInmuebleOrigenNombre = AV35GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFTIPOINMUEBLEORIGENNOMBRE_SEL") == 0 )
            {
               AV73TFTipoInmuebleOrigenNombre_Sel = AV35GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFTIPOINMUEBLEORIGENVALOR") == 0 )
            {
               AV75TFTipoInmuebleOrigenValor = NumberUtil.Val( AV35GridStateFilterValue.gxTpr_Value, ".");
               AV76TFTipoInmuebleOrigenValor_To = NumberUtil.Val( AV35GridStateFilterValue.gxTpr_Valueto, ".");
            }
            AV176GXV7 = (int)(AV176GXV7+1);
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
         AV124Pgmname = "";
         GXKey = "";
         GXEncryptionTmp = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV11ExcelDocument = new ExcelDocumentI();
         AV19FilterFullText = "";
         AV34GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV31GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV20DynamicFiltersSelector1 = "";
         AV22MudanzaAsesor1 = "";
         AV24DynamicFiltersSelector2 = "";
         AV26MudanzaAsesor2 = "";
         AV28DynamicFiltersSelector3 = "";
         AV30MudanzaAsesor3 = "";
         AV50TFMudanzaAsesor_Sel = "";
         AV49TFMudanzaAsesor = "";
         AV51TFMudanzaFechaAlta = DateTime.MinValue;
         AV52TFMudanzaFechaAlta_To = DateTime.MinValue;
         AV53TFMudanzaFechaServicio = DateTime.MinValue;
         AV54TFMudanzaFechaServicio_To = DateTime.MinValue;
         AV110TFMudanzaHoraServicio_Sels = new GxSimpleCollection<string>();
         AV109TFMudanzaHoraServicio_Sel = "";
         AV113TFMudanzaRgoHoraservicio_Sels = new GxSimpleCollection<string>();
         AV112TFMudanzaRgoHoraservicio_Sel = "";
         AV58TFMudanzaDireccionOrigen_Sel = "";
         AV57TFMudanzaDireccionOrigen = "";
         AV116TFMudanzaPisoDptoOrigen_Sels = new GxSimpleCollection<string>();
         AV115TFMudanzaPisoDptoOrigen_Sel = "";
         AV60TFMudanzaDireccionDestino_Sel = "";
         AV59TFMudanzaDireccionDestino = "";
         AV118TFMudanzaPisoDptoDestino_Sel = "";
         AV117TFMudanzaPisoDptoDestino = "";
         AV101TFMudanzaVehiculoSugerido_Sels = new GxSimpleCollection<string>();
         AV100TFMudanzaVehiculoSugerido_Sel = "";
         AV73TFTipoInmuebleOrigenNombre_Sel = "";
         AV119TFTipoInmuebleOrigenNombre = "";
         AV32Session = context.GetSession();
         AV39ColumnsSelectorXML = "";
         AV36ColumnsSelector = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector(context);
         AV38ColumnsSelector_Column = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column(context);
         AV131Mudanzawwds_1_filterfulltext = "";
         AV132Mudanzawwds_2_dynamicfiltersselector1 = "";
         AV134Mudanzawwds_4_mudanzaasesor1 = "";
         AV136Mudanzawwds_6_dynamicfiltersselector2 = "";
         AV138Mudanzawwds_8_mudanzaasesor2 = "";
         AV140Mudanzawwds_10_dynamicfiltersselector3 = "";
         AV142Mudanzawwds_12_mudanzaasesor3 = "";
         AV145Mudanzawwds_15_tfmudanzaasesor = "";
         AV146Mudanzawwds_16_tfmudanzaasesor_sel = "";
         AV147Mudanzawwds_17_tfmudanzafechaalta = DateTime.MinValue;
         AV148Mudanzawwds_18_tfmudanzafechaalta_to = DateTime.MinValue;
         AV149Mudanzawwds_19_tfmudanzafechaservicio = DateTime.MinValue;
         AV150Mudanzawwds_20_tfmudanzafechaservicio_to = DateTime.MinValue;
         AV151Mudanzawwds_21_tfmudanzahoraservicio_sels = new GxSimpleCollection<string>();
         AV152Mudanzawwds_22_tfmudanzargohoraservicio_sels = new GxSimpleCollection<string>();
         AV153Mudanzawwds_23_tfmudanzadireccionorigen = "";
         AV154Mudanzawwds_24_tfmudanzadireccionorigen_sel = "";
         AV155Mudanzawwds_25_tfmudanzapisodptoorigen_sels = new GxSimpleCollection<string>();
         AV156Mudanzawwds_26_tfmudanzadirecciondestino = "";
         AV157Mudanzawwds_27_tfmudanzadirecciondestino_sel = "";
         AV158Mudanzawwds_28_tfmudanzapisodptodestino = "";
         AV159Mudanzawwds_29_tfmudanzapisodptodestino_sel = "";
         AV162Mudanzawwds_32_tfmudanzavehiculosugerido_sels = new GxSimpleCollection<string>();
         AV171Mudanzawwds_41_tftipoinmuebleorigennombre = "";
         AV172Mudanzawwds_42_tftipoinmuebleorigennombre_sel = "";
         lV131Mudanzawwds_1_filterfulltext = "";
         lV134Mudanzawwds_4_mudanzaasesor1 = "";
         lV138Mudanzawwds_8_mudanzaasesor2 = "";
         lV142Mudanzawwds_12_mudanzaasesor3 = "";
         lV145Mudanzawwds_15_tfmudanzaasesor = "";
         lV153Mudanzawwds_23_tfmudanzadireccionorigen = "";
         lV156Mudanzawwds_26_tfmudanzadirecciondestino = "";
         lV158Mudanzawwds_28_tfmudanzapisodptodestino = "";
         lV171Mudanzawwds_41_tftipoinmuebleorigennombre = "";
         A739MudanzaHoraServicio = "";
         A776MudanzaRgoHoraservicio = "";
         A777MudanzaPisoDptoOrigen = "";
         A742MudanzaVehiculoSugerido = "";
         A736MudanzaAsesor = "";
         A740MudanzaDireccionOrigen = "";
         A741MudanzaDireccionDestino = "";
         A778MudanzaPisoDptoDestino = "";
         A755TipoInmuebleOrigenNombre = "";
         A737MudanzaFechaAlta = DateTime.MinValue;
         A738MudanzaFechaServicio = DateTime.MinValue;
         P00DS2_A756TipoInmuebleOrigenValor = new decimal[1] ;
         P00DS2_A755TipoInmuebleOrigenNombre = new string[] {""} ;
         P00DS2_A743TipoInmuebleOrigenId = new short[1] ;
         P00DS2_A760MudanzaPeajevalor = new decimal[1] ;
         P00DS2_A761MudanzaPeajeCantidad = new short[1] ;
         P00DS2_A780MudanzaPrecioBasexHora = new decimal[1] ;
         P00DS2_A742MudanzaVehiculoSugerido = new string[] {""} ;
         P00DS2_A762MudanzaDistancia = new decimal[1] ;
         P00DS2_A778MudanzaPisoDptoDestino = new string[] {""} ;
         P00DS2_A741MudanzaDireccionDestino = new string[] {""} ;
         P00DS2_A777MudanzaPisoDptoOrigen = new string[] {""} ;
         P00DS2_A740MudanzaDireccionOrigen = new string[] {""} ;
         P00DS2_A738MudanzaFechaServicio = new DateTime[] {DateTime.MinValue} ;
         P00DS2_A737MudanzaFechaAlta = new DateTime[] {DateTime.MinValue} ;
         P00DS2_A736MudanzaAsesor = new string[] {""} ;
         P00DS2_A735MudanzaId = new long[1] ;
         P00DS2_A776MudanzaRgoHoraservicio = new string[] {""} ;
         P00DS2_n776MudanzaRgoHoraservicio = new bool[] {false} ;
         P00DS2_A739MudanzaHoraServicio = new string[] {""} ;
         P00DS2_n739MudanzaHoraServicio = new bool[] {false} ;
         GXt_dtime4 = (DateTime)(DateTime.MinValue);
         AV40UserCustomValue = "";
         GXt_char2 = "";
         AV37ColumnsSelectorAux = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector(context);
         AV35GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV108TFMudanzaHoraServicio_SelsJson = "";
         AV111TFMudanzaRgoHoraservicio_SelsJson = "";
         AV114TFMudanzaPisoDptoOrigen_SelsJson = "";
         AV99TFMudanzaVehiculoSugerido_SelsJson = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.mudanzawwexport__default(),
            new Object[][] {
                new Object[] {
               P00DS2_A756TipoInmuebleOrigenValor, P00DS2_A755TipoInmuebleOrigenNombre, P00DS2_A743TipoInmuebleOrigenId, P00DS2_A760MudanzaPeajevalor, P00DS2_A761MudanzaPeajeCantidad, P00DS2_A780MudanzaPrecioBasexHora, P00DS2_A742MudanzaVehiculoSugerido, P00DS2_A762MudanzaDistancia, P00DS2_A778MudanzaPisoDptoDestino, P00DS2_A741MudanzaDireccionDestino,
               P00DS2_A777MudanzaPisoDptoOrigen, P00DS2_A740MudanzaDireccionOrigen, P00DS2_A738MudanzaFechaServicio, P00DS2_A737MudanzaFechaAlta, P00DS2_A736MudanzaAsesor, P00DS2_A735MudanzaId, P00DS2_A776MudanzaRgoHoraservicio, P00DS2_n776MudanzaRgoHoraservicio, P00DS2_A739MudanzaHoraServicio, P00DS2_n739MudanzaHoraServicio
               }
            }
         );
         AV124Pgmname = "MudanzaWWExport";
         /* GeneXus formulas. */
         AV124Pgmname = "MudanzaWWExport";
      }

      private short AV21DynamicFiltersOperator1 ;
      private short AV25DynamicFiltersOperator2 ;
      private short AV29DynamicFiltersOperator3 ;
      private short AV66TFMudanzaPeajeCantidad ;
      private short AV67TFMudanzaPeajeCantidad_To ;
      private short AV70TFTipoInmuebleOrigenId ;
      private short AV71TFTipoInmuebleOrigenId_To ;
      private short GXt_int3 ;
      private short AV133Mudanzawwds_3_dynamicfiltersoperator1 ;
      private short AV137Mudanzawwds_7_dynamicfiltersoperator2 ;
      private short AV141Mudanzawwds_11_dynamicfiltersoperator3 ;
      private short AV165Mudanzawwds_35_tfmudanzapeajecantidad ;
      private short AV166Mudanzawwds_36_tfmudanzapeajecantidad_to ;
      private short AV169Mudanzawwds_39_tftipoinmuebleorigenid ;
      private short AV170Mudanzawwds_40_tftipoinmuebleorigenid_to ;
      private short A761MudanzaPeajeCantidad ;
      private short A743TipoInmuebleOrigenId ;
      private short AV17OrderedBy ;
      private int AV14CellRow ;
      private int AV15FirstColumn ;
      private int AV16Random ;
      private int AV125GXV1 ;
      private int AV126GXV2 ;
      private int AV127GXV3 ;
      private int AV128GXV4 ;
      private int AV129GXV5 ;
      private int AV151Mudanzawwds_21_tfmudanzahoraservicio_sels_Count ;
      private int AV152Mudanzawwds_22_tfmudanzargohoraservicio_sels_Count ;
      private int AV155Mudanzawwds_25_tfmudanzapisodptoorigen_sels_Count ;
      private int AV162Mudanzawwds_32_tfmudanzavehiculosugerido_sels_Count ;
      private int AV175GXV6 ;
      private int AV176GXV7 ;
      private long AV47TFMudanzaId ;
      private long AV48TFMudanzaId_To ;
      private long AV98i ;
      private long AV44VisibleColumnCount ;
      private long AV143Mudanzawwds_13_tfmudanzaid ;
      private long AV144Mudanzawwds_14_tfmudanzaid_to ;
      private long A735MudanzaId ;
      private decimal AV61TFMudanzaDistancia ;
      private decimal AV62TFMudanzaDistancia_To ;
      private decimal AV122TFMudanzaPrecioBasexHora ;
      private decimal AV123TFMudanzaPrecioBasexHora_To ;
      private decimal AV68TFMudanzaPeajevalor ;
      private decimal AV69TFMudanzaPeajevalor_To ;
      private decimal AV75TFTipoInmuebleOrigenValor ;
      private decimal AV76TFTipoInmuebleOrigenValor_To ;
      private decimal AV160Mudanzawwds_30_tfmudanzadistancia ;
      private decimal AV161Mudanzawwds_31_tfmudanzadistancia_to ;
      private decimal AV163Mudanzawwds_33_tfmudanzapreciobasexhora ;
      private decimal AV164Mudanzawwds_34_tfmudanzapreciobasexhora_to ;
      private decimal AV167Mudanzawwds_37_tfmudanzapeajevalor ;
      private decimal AV168Mudanzawwds_38_tfmudanzapeajevalor_to ;
      private decimal AV173Mudanzawwds_43_tftipoinmuebleorigenvalor ;
      private decimal AV174Mudanzawwds_44_tftipoinmuebleorigenvalor_to ;
      private decimal A762MudanzaDistancia ;
      private decimal A780MudanzaPrecioBasexHora ;
      private decimal A760MudanzaPeajevalor ;
      private decimal A756TipoInmuebleOrigenValor ;
      private string AV124Pgmname ;
      private string GXKey ;
      private string GXEncryptionTmp ;
      private string AV109TFMudanzaHoraServicio_Sel ;
      private string AV112TFMudanzaRgoHoraservicio_Sel ;
      private string AV115TFMudanzaPisoDptoOrigen_Sel ;
      private string AV118TFMudanzaPisoDptoDestino_Sel ;
      private string AV117TFMudanzaPisoDptoDestino ;
      private string AV158Mudanzawwds_28_tfmudanzapisodptodestino ;
      private string AV159Mudanzawwds_29_tfmudanzapisodptodestino_sel ;
      private string lV158Mudanzawwds_28_tfmudanzapisodptodestino ;
      private string A739MudanzaHoraServicio ;
      private string A776MudanzaRgoHoraservicio ;
      private string A777MudanzaPisoDptoOrigen ;
      private string A778MudanzaPisoDptoDestino ;
      private string GXt_char2 ;
      private DateTime GXt_dtime4 ;
      private DateTime AV51TFMudanzaFechaAlta ;
      private DateTime AV52TFMudanzaFechaAlta_To ;
      private DateTime AV53TFMudanzaFechaServicio ;
      private DateTime AV54TFMudanzaFechaServicio_To ;
      private DateTime AV147Mudanzawwds_17_tfmudanzafechaalta ;
      private DateTime AV148Mudanzawwds_18_tfmudanzafechaalta_to ;
      private DateTime AV149Mudanzawwds_19_tfmudanzafechaservicio ;
      private DateTime AV150Mudanzawwds_20_tfmudanzafechaservicio_to ;
      private DateTime A737MudanzaFechaAlta ;
      private DateTime A738MudanzaFechaServicio ;
      private bool AV8IsAuthorized ;
      private bool GXt_boolean1 ;
      private bool returnInSub ;
      private bool AV23DynamicFiltersEnabled2 ;
      private bool AV27DynamicFiltersEnabled3 ;
      private bool AV135Mudanzawwds_5_dynamicfiltersenabled2 ;
      private bool AV139Mudanzawwds_9_dynamicfiltersenabled3 ;
      private bool AV18OrderedDsc ;
      private bool n776MudanzaRgoHoraservicio ;
      private bool n739MudanzaHoraServicio ;
      private string AV39ColumnsSelectorXML ;
      private string AV40UserCustomValue ;
      private string AV108TFMudanzaHoraServicio_SelsJson ;
      private string AV111TFMudanzaRgoHoraservicio_SelsJson ;
      private string AV114TFMudanzaPisoDptoOrigen_SelsJson ;
      private string AV99TFMudanzaVehiculoSugerido_SelsJson ;
      private string AV12Filename ;
      private string AV13ErrorMessage ;
      private string AV19FilterFullText ;
      private string AV20DynamicFiltersSelector1 ;
      private string AV22MudanzaAsesor1 ;
      private string AV24DynamicFiltersSelector2 ;
      private string AV26MudanzaAsesor2 ;
      private string AV28DynamicFiltersSelector3 ;
      private string AV30MudanzaAsesor3 ;
      private string AV50TFMudanzaAsesor_Sel ;
      private string AV49TFMudanzaAsesor ;
      private string AV58TFMudanzaDireccionOrigen_Sel ;
      private string AV57TFMudanzaDireccionOrigen ;
      private string AV60TFMudanzaDireccionDestino_Sel ;
      private string AV59TFMudanzaDireccionDestino ;
      private string AV100TFMudanzaVehiculoSugerido_Sel ;
      private string AV73TFTipoInmuebleOrigenNombre_Sel ;
      private string AV119TFTipoInmuebleOrigenNombre ;
      private string AV131Mudanzawwds_1_filterfulltext ;
      private string AV132Mudanzawwds_2_dynamicfiltersselector1 ;
      private string AV134Mudanzawwds_4_mudanzaasesor1 ;
      private string AV136Mudanzawwds_6_dynamicfiltersselector2 ;
      private string AV138Mudanzawwds_8_mudanzaasesor2 ;
      private string AV140Mudanzawwds_10_dynamicfiltersselector3 ;
      private string AV142Mudanzawwds_12_mudanzaasesor3 ;
      private string AV145Mudanzawwds_15_tfmudanzaasesor ;
      private string AV146Mudanzawwds_16_tfmudanzaasesor_sel ;
      private string AV153Mudanzawwds_23_tfmudanzadireccionorigen ;
      private string AV154Mudanzawwds_24_tfmudanzadireccionorigen_sel ;
      private string AV156Mudanzawwds_26_tfmudanzadirecciondestino ;
      private string AV157Mudanzawwds_27_tfmudanzadirecciondestino_sel ;
      private string AV171Mudanzawwds_41_tftipoinmuebleorigennombre ;
      private string AV172Mudanzawwds_42_tftipoinmuebleorigennombre_sel ;
      private string lV131Mudanzawwds_1_filterfulltext ;
      private string lV134Mudanzawwds_4_mudanzaasesor1 ;
      private string lV138Mudanzawwds_8_mudanzaasesor2 ;
      private string lV142Mudanzawwds_12_mudanzaasesor3 ;
      private string lV145Mudanzawwds_15_tfmudanzaasesor ;
      private string lV153Mudanzawwds_23_tfmudanzadireccionorigen ;
      private string lV156Mudanzawwds_26_tfmudanzadirecciondestino ;
      private string lV171Mudanzawwds_41_tftipoinmuebleorigennombre ;
      private string A742MudanzaVehiculoSugerido ;
      private string A736MudanzaAsesor ;
      private string A740MudanzaDireccionOrigen ;
      private string A741MudanzaDireccionDestino ;
      private string A755TipoInmuebleOrigenNombre ;
      private IGxSession AV32Session ;
      private ExcelDocumentI AV11ExcelDocument ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV34GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV31GridStateDynamicFilter ;
      private GxSimpleCollection<string> AV110TFMudanzaHoraServicio_Sels ;
      private GxSimpleCollection<string> AV113TFMudanzaRgoHoraservicio_Sels ;
      private GxSimpleCollection<string> AV116TFMudanzaPisoDptoOrigen_Sels ;
      private GxSimpleCollection<string> AV101TFMudanzaVehiculoSugerido_Sels ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector AV36ColumnsSelector ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column AV38ColumnsSelector_Column ;
      private GxSimpleCollection<string> AV151Mudanzawwds_21_tfmudanzahoraservicio_sels ;
      private GxSimpleCollection<string> AV152Mudanzawwds_22_tfmudanzargohoraservicio_sels ;
      private GxSimpleCollection<string> AV155Mudanzawwds_25_tfmudanzapisodptoorigen_sels ;
      private GxSimpleCollection<string> AV162Mudanzawwds_32_tfmudanzavehiculosugerido_sels ;
      private IDataStoreProvider pr_default ;
      private decimal[] P00DS2_A756TipoInmuebleOrigenValor ;
      private string[] P00DS2_A755TipoInmuebleOrigenNombre ;
      private short[] P00DS2_A743TipoInmuebleOrigenId ;
      private decimal[] P00DS2_A760MudanzaPeajevalor ;
      private short[] P00DS2_A761MudanzaPeajeCantidad ;
      private decimal[] P00DS2_A780MudanzaPrecioBasexHora ;
      private string[] P00DS2_A742MudanzaVehiculoSugerido ;
      private decimal[] P00DS2_A762MudanzaDistancia ;
      private string[] P00DS2_A778MudanzaPisoDptoDestino ;
      private string[] P00DS2_A741MudanzaDireccionDestino ;
      private string[] P00DS2_A777MudanzaPisoDptoOrigen ;
      private string[] P00DS2_A740MudanzaDireccionOrigen ;
      private DateTime[] P00DS2_A738MudanzaFechaServicio ;
      private DateTime[] P00DS2_A737MudanzaFechaAlta ;
      private string[] P00DS2_A736MudanzaAsesor ;
      private long[] P00DS2_A735MudanzaId ;
      private string[] P00DS2_A776MudanzaRgoHoraservicio ;
      private bool[] P00DS2_n776MudanzaRgoHoraservicio ;
      private string[] P00DS2_A739MudanzaHoraServicio ;
      private bool[] P00DS2_n739MudanzaHoraServicio ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector AV37ColumnsSelectorAux ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV35GridStateFilterValue ;
      private string aP0_Filename ;
      private string aP1_ErrorMessage ;
   }

   public class mudanzawwexport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00DS2( IGxContext context ,
                                             string A739MudanzaHoraServicio ,
                                             GxSimpleCollection<string> AV151Mudanzawwds_21_tfmudanzahoraservicio_sels ,
                                             string A776MudanzaRgoHoraservicio ,
                                             GxSimpleCollection<string> AV152Mudanzawwds_22_tfmudanzargohoraservicio_sels ,
                                             string A777MudanzaPisoDptoOrigen ,
                                             GxSimpleCollection<string> AV155Mudanzawwds_25_tfmudanzapisodptoorigen_sels ,
                                             string A742MudanzaVehiculoSugerido ,
                                             GxSimpleCollection<string> AV162Mudanzawwds_32_tfmudanzavehiculosugerido_sels ,
                                             string AV131Mudanzawwds_1_filterfulltext ,
                                             string AV132Mudanzawwds_2_dynamicfiltersselector1 ,
                                             short AV133Mudanzawwds_3_dynamicfiltersoperator1 ,
                                             string AV134Mudanzawwds_4_mudanzaasesor1 ,
                                             bool AV135Mudanzawwds_5_dynamicfiltersenabled2 ,
                                             string AV136Mudanzawwds_6_dynamicfiltersselector2 ,
                                             short AV137Mudanzawwds_7_dynamicfiltersoperator2 ,
                                             string AV138Mudanzawwds_8_mudanzaasesor2 ,
                                             bool AV139Mudanzawwds_9_dynamicfiltersenabled3 ,
                                             string AV140Mudanzawwds_10_dynamicfiltersselector3 ,
                                             short AV141Mudanzawwds_11_dynamicfiltersoperator3 ,
                                             string AV142Mudanzawwds_12_mudanzaasesor3 ,
                                             long AV143Mudanzawwds_13_tfmudanzaid ,
                                             long AV144Mudanzawwds_14_tfmudanzaid_to ,
                                             string AV146Mudanzawwds_16_tfmudanzaasesor_sel ,
                                             string AV145Mudanzawwds_15_tfmudanzaasesor ,
                                             DateTime AV147Mudanzawwds_17_tfmudanzafechaalta ,
                                             DateTime AV148Mudanzawwds_18_tfmudanzafechaalta_to ,
                                             DateTime AV149Mudanzawwds_19_tfmudanzafechaservicio ,
                                             DateTime AV150Mudanzawwds_20_tfmudanzafechaservicio_to ,
                                             int AV151Mudanzawwds_21_tfmudanzahoraservicio_sels_Count ,
                                             int AV152Mudanzawwds_22_tfmudanzargohoraservicio_sels_Count ,
                                             string AV154Mudanzawwds_24_tfmudanzadireccionorigen_sel ,
                                             string AV153Mudanzawwds_23_tfmudanzadireccionorigen ,
                                             int AV155Mudanzawwds_25_tfmudanzapisodptoorigen_sels_Count ,
                                             string AV157Mudanzawwds_27_tfmudanzadirecciondestino_sel ,
                                             string AV156Mudanzawwds_26_tfmudanzadirecciondestino ,
                                             string AV159Mudanzawwds_29_tfmudanzapisodptodestino_sel ,
                                             string AV158Mudanzawwds_28_tfmudanzapisodptodestino ,
                                             decimal AV160Mudanzawwds_30_tfmudanzadistancia ,
                                             decimal AV161Mudanzawwds_31_tfmudanzadistancia_to ,
                                             int AV162Mudanzawwds_32_tfmudanzavehiculosugerido_sels_Count ,
                                             decimal AV163Mudanzawwds_33_tfmudanzapreciobasexhora ,
                                             decimal AV164Mudanzawwds_34_tfmudanzapreciobasexhora_to ,
                                             short AV165Mudanzawwds_35_tfmudanzapeajecantidad ,
                                             short AV166Mudanzawwds_36_tfmudanzapeajecantidad_to ,
                                             decimal AV167Mudanzawwds_37_tfmudanzapeajevalor ,
                                             decimal AV168Mudanzawwds_38_tfmudanzapeajevalor_to ,
                                             short AV169Mudanzawwds_39_tftipoinmuebleorigenid ,
                                             short AV170Mudanzawwds_40_tftipoinmuebleorigenid_to ,
                                             string AV172Mudanzawwds_42_tftipoinmuebleorigennombre_sel ,
                                             string AV171Mudanzawwds_41_tftipoinmuebleorigennombre ,
                                             decimal AV173Mudanzawwds_43_tftipoinmuebleorigenvalor ,
                                             decimal AV174Mudanzawwds_44_tftipoinmuebleorigenvalor_to ,
                                             long A735MudanzaId ,
                                             string A736MudanzaAsesor ,
                                             string A740MudanzaDireccionOrigen ,
                                             string A741MudanzaDireccionDestino ,
                                             string A778MudanzaPisoDptoDestino ,
                                             decimal A762MudanzaDistancia ,
                                             decimal A780MudanzaPrecioBasexHora ,
                                             short A761MudanzaPeajeCantidad ,
                                             decimal A760MudanzaPeajevalor ,
                                             short A743TipoInmuebleOrigenId ,
                                             string A755TipoInmuebleOrigenNombre ,
                                             decimal A756TipoInmuebleOrigenValor ,
                                             DateTime A737MudanzaFechaAlta ,
                                             DateTime A738MudanzaFechaServicio ,
                                             short AV17OrderedBy ,
                                             bool AV18OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int5 = new short[63];
         Object[] GXv_Object6 = new Object[2];
         scmdbuf = "SELECT T2.[ParametroMudanzaValor] AS TipoInmuebleOrigenValor, T2.[ParametroMudanzaNombre] AS TipoInmuebleOrigenNombre, T1.[TipoInmuebleOrigenId] AS TipoInmuebleOrigenId, T1.[MudanzaPeajevalor], T1.[MudanzaPeajeCantidad], T1.[MudanzaPrecioBasexHora], T1.[MudanzaVehiculoSugerido], T1.[MudanzaDistancia], T1.[MudanzaPisoDptoDestino], T1.[MudanzaDireccionDestino], T1.[MudanzaPisoDptoOrigen], T1.[MudanzaDireccionOrigen], T1.[MudanzaFechaServicio], T1.[MudanzaFechaAlta], T1.[MudanzaAsesor], T1.[MudanzaId], T1.[MudanzaRgoHoraservicio], T1.[MudanzaHoraServicio] FROM ([Mudanza] T1 INNER JOIN [ParametroMudanza] T2 ON T2.[ParametroMudanzaId] = T1.[TipoInmuebleOrigenId])";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV131Mudanzawwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( CONVERT( char(18), CAST(T1.[MudanzaId] AS decimal(18,0))) like '%' + @lV131Mudanzawwds_1_filterfulltext) or ( UPPER(T1.[MudanzaAsesor]) like '%' + UPPER(@lV131Mudanzawwds_1_filterfulltext)) or ( '08:00' like '%' + LOWER(@lV131Mudanzawwds_1_filterfulltext) and T1.[MudanzaHoraServicio] = '08') or ( '09:00' like '%' + LOWER(@lV131Mudanzawwds_1_filterfulltext) and T1.[MudanzaHoraServicio] = '09') or ( '10:00' like '%' + LOWER(@lV131Mudanzawwds_1_filterfulltext) and T1.[MudanzaHoraServicio] = '10') or ( '11:00' like '%' + LOWER(@lV131Mudanzawwds_1_filterfulltext) and T1.[MudanzaHoraServicio] = '11') or ( '12:00' like '%' + LOWER(@lV131Mudanzawwds_1_filterfulltext) and T1.[MudanzaHoraServicio] = '12') or ( '13:00' like '%' + LOWER(@lV131Mudanzawwds_1_filterfulltext) and T1.[MudanzaHoraServicio] = '13') or ( '14:00' like '%' + LOWER(@lV131Mudanzawwds_1_filterfulltext) and T1.[MudanzaHoraServicio] = '14') or ( '15:00' like '%' + LOWER(@lV131Mudanzawwds_1_filterfulltext) and T1.[MudanzaHoraServicio] = '15') or ( '16:00' like '%' + LOWER(@lV131Mudanzawwds_1_filterfulltext) and T1.[MudanzaHoraServicio] = '16') or ( '17:00' like '%' + LOWER(@lV131Mudanzawwds_1_filterfulltext) and T1.[MudanzaHoraServicio] = '17') or ( '18:00' like '%' + LOWER(@lV131Mudanzawwds_1_filterfulltext) and T1.[MudanzaHoraServicio] = '18') or ( '19:00' like '%' + LOWER(@lV131Mudanzawwds_1_filterfulltext) and T1.[MudanzaHoraServicio] = '19') or ( '08:00 - 12:00' like '%' + LOWER(@lV131Mudanzawwds_1_filterfulltext) and T1.[MudanzaRgoHoraservicio] = '08-12') or ( '12:00 - 16:00' like '%' + LOWER(@lV131Mudanzawwds_1_filterfulltext) and T1.[MudanzaRgoHoraservicio] = '12-16') or ( '16:00 - 20:00' like '%' + LOWER(@lV131Mudanzawwds_1_filterfulltext) and T1.[MudanzaRgoHoraservicio] = '16-20') or ( UPPER(T1.[MudanzaDireccionOrigen]) like '%' + UPPER(@lV131Mudanzawwds_1_filterfulltext)) or ( UPPER(T1.[MudanzaPisoDptoOrigen]) like '%' + UPPER(@lV131Mudanzawwds_1_filterfulltext)) or ( UPPER(T1.[MudanzaDireccionDestino]) like '%' + UPPER(@lV131Mudanzawwds_1_filterfulltext)) or ( UPPER(T1.[MudanzaPisoDptoDestino]) like '%' + UPPER(@lV131Mudanzawwds_1_filterfulltext)) or ( CONVERT( char(10), CAST(T1.[MudanzaDistancia] AS decimal(10,2))) like '%' + @lV131Mudanzawwds_1_filterfulltext) or ( UPPER(T1.[MudanzaVehiculoSugerido]) like '%' + UPPER(@lV131Mudanzawwds_1_filterfulltext)) or ( CONVERT( char(18), CAST(T1.[MudanzaPrecioBasexHora] AS decimal(18,2))) like '%' + @lV131Mudanzawwds_1_filterfulltext) or ( CONVERT( char(1), CAST(T1.[MudanzaPeajeCantidad] AS decimal(1,0))) like '%' + @lV131Mudanzawwds_1_filterfulltext) or ( CONVERT( char(18), CAST(T1.[MudanzaPeajevalor] AS decimal(18,2))) like '%' + @lV131Mudanzawwds_1_filterfulltext) or ( CONVERT( char(4), CAST(T1.[TipoInmuebleOrigenId] AS decimal(4,0))) like '%' + @lV131Mudanzawwds_1_filterfulltext) or ( UPPER(T2.[ParametroMudanzaNombre]) like '%' + UPPER(@lV131Mudanzawwds_1_filterfulltext)) or ( CONVERT( char(18), CAST(T2.[ParametroMudanzaValor] AS decimal(18,2))) like '%' + @lV131Mudanzawwds_1_filterfulltext))");
         }
         else
         {
            GXv_int5[0] = 1;
            GXv_int5[1] = 1;
            GXv_int5[2] = 1;
            GXv_int5[3] = 1;
            GXv_int5[4] = 1;
            GXv_int5[5] = 1;
            GXv_int5[6] = 1;
            GXv_int5[7] = 1;
            GXv_int5[8] = 1;
            GXv_int5[9] = 1;
            GXv_int5[10] = 1;
            GXv_int5[11] = 1;
            GXv_int5[12] = 1;
            GXv_int5[13] = 1;
            GXv_int5[14] = 1;
            GXv_int5[15] = 1;
            GXv_int5[16] = 1;
            GXv_int5[17] = 1;
            GXv_int5[18] = 1;
            GXv_int5[19] = 1;
            GXv_int5[20] = 1;
            GXv_int5[21] = 1;
            GXv_int5[22] = 1;
            GXv_int5[23] = 1;
            GXv_int5[24] = 1;
            GXv_int5[25] = 1;
            GXv_int5[26] = 1;
            GXv_int5[27] = 1;
            GXv_int5[28] = 1;
         }
         if ( ( StringUtil.StrCmp(AV132Mudanzawwds_2_dynamicfiltersselector1, "MUDANZAASESOR") == 0 ) && ( AV133Mudanzawwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV134Mudanzawwds_4_mudanzaasesor1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[MudanzaAsesor]) like UPPER(@lV134Mudanzawwds_4_mudanzaasesor1))");
         }
         else
         {
            GXv_int5[29] = 1;
         }
         if ( ( StringUtil.StrCmp(AV132Mudanzawwds_2_dynamicfiltersselector1, "MUDANZAASESOR") == 0 ) && ( AV133Mudanzawwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV134Mudanzawwds_4_mudanzaasesor1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[MudanzaAsesor]) like '%' + UPPER(@lV134Mudanzawwds_4_mudanzaasesor1))");
         }
         else
         {
            GXv_int5[30] = 1;
         }
         if ( AV135Mudanzawwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV136Mudanzawwds_6_dynamicfiltersselector2, "MUDANZAASESOR") == 0 ) && ( AV137Mudanzawwds_7_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV138Mudanzawwds_8_mudanzaasesor2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[MudanzaAsesor]) like UPPER(@lV138Mudanzawwds_8_mudanzaasesor2))");
         }
         else
         {
            GXv_int5[31] = 1;
         }
         if ( AV135Mudanzawwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV136Mudanzawwds_6_dynamicfiltersselector2, "MUDANZAASESOR") == 0 ) && ( AV137Mudanzawwds_7_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV138Mudanzawwds_8_mudanzaasesor2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[MudanzaAsesor]) like '%' + UPPER(@lV138Mudanzawwds_8_mudanzaasesor2))");
         }
         else
         {
            GXv_int5[32] = 1;
         }
         if ( AV139Mudanzawwds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV140Mudanzawwds_10_dynamicfiltersselector3, "MUDANZAASESOR") == 0 ) && ( AV141Mudanzawwds_11_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV142Mudanzawwds_12_mudanzaasesor3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[MudanzaAsesor]) like UPPER(@lV142Mudanzawwds_12_mudanzaasesor3))");
         }
         else
         {
            GXv_int5[33] = 1;
         }
         if ( AV139Mudanzawwds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV140Mudanzawwds_10_dynamicfiltersselector3, "MUDANZAASESOR") == 0 ) && ( AV141Mudanzawwds_11_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV142Mudanzawwds_12_mudanzaasesor3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[MudanzaAsesor]) like '%' + UPPER(@lV142Mudanzawwds_12_mudanzaasesor3))");
         }
         else
         {
            GXv_int5[34] = 1;
         }
         if ( ! (0==AV143Mudanzawwds_13_tfmudanzaid) )
         {
            AddWhere(sWhereString, "(T1.[MudanzaId] >= @AV143Mudanzawwds_13_tfmudanzaid)");
         }
         else
         {
            GXv_int5[35] = 1;
         }
         if ( ! (0==AV144Mudanzawwds_14_tfmudanzaid_to) )
         {
            AddWhere(sWhereString, "(T1.[MudanzaId] <= @AV144Mudanzawwds_14_tfmudanzaid_to)");
         }
         else
         {
            GXv_int5[36] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV146Mudanzawwds_16_tfmudanzaasesor_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV145Mudanzawwds_15_tfmudanzaasesor)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[MudanzaAsesor]) like UPPER(@lV145Mudanzawwds_15_tfmudanzaasesor))");
         }
         else
         {
            GXv_int5[37] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV146Mudanzawwds_16_tfmudanzaasesor_sel)) && ! ( StringUtil.StrCmp(AV146Mudanzawwds_16_tfmudanzaasesor_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[MudanzaAsesor] = @AV146Mudanzawwds_16_tfmudanzaasesor_sel)");
         }
         else
         {
            GXv_int5[38] = 1;
         }
         if ( StringUtil.StrCmp(AV146Mudanzawwds_16_tfmudanzaasesor_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[MudanzaAsesor] = ''))");
         }
         if ( ! (DateTime.MinValue==AV147Mudanzawwds_17_tfmudanzafechaalta) )
         {
            AddWhere(sWhereString, "(T1.[MudanzaFechaAlta] >= @AV147Mudanzawwds_17_tfmudanzafechaalta)");
         }
         else
         {
            GXv_int5[39] = 1;
         }
         if ( ! (DateTime.MinValue==AV148Mudanzawwds_18_tfmudanzafechaalta_to) )
         {
            AddWhere(sWhereString, "(T1.[MudanzaFechaAlta] <= @AV148Mudanzawwds_18_tfmudanzafechaalta_to)");
         }
         else
         {
            GXv_int5[40] = 1;
         }
         if ( ! (DateTime.MinValue==AV149Mudanzawwds_19_tfmudanzafechaservicio) )
         {
            AddWhere(sWhereString, "(T1.[MudanzaFechaServicio] >= @AV149Mudanzawwds_19_tfmudanzafechaservicio)");
         }
         else
         {
            GXv_int5[41] = 1;
         }
         if ( ! (DateTime.MinValue==AV150Mudanzawwds_20_tfmudanzafechaservicio_to) )
         {
            AddWhere(sWhereString, "(T1.[MudanzaFechaServicio] <= @AV150Mudanzawwds_20_tfmudanzafechaservicio_to)");
         }
         else
         {
            GXv_int5[42] = 1;
         }
         if ( AV151Mudanzawwds_21_tfmudanzahoraservicio_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV151Mudanzawwds_21_tfmudanzahoraservicio_sels, "T1.[MudanzaHoraServicio] IN (", ")")+")");
         }
         if ( AV152Mudanzawwds_22_tfmudanzargohoraservicio_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV152Mudanzawwds_22_tfmudanzargohoraservicio_sels, "T1.[MudanzaRgoHoraservicio] IN (", ")")+")");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV154Mudanzawwds_24_tfmudanzadireccionorigen_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV153Mudanzawwds_23_tfmudanzadireccionorigen)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[MudanzaDireccionOrigen]) like UPPER(@lV153Mudanzawwds_23_tfmudanzadireccionorigen))");
         }
         else
         {
            GXv_int5[43] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV154Mudanzawwds_24_tfmudanzadireccionorigen_sel)) && ! ( StringUtil.StrCmp(AV154Mudanzawwds_24_tfmudanzadireccionorigen_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[MudanzaDireccionOrigen] = @AV154Mudanzawwds_24_tfmudanzadireccionorigen_sel)");
         }
         else
         {
            GXv_int5[44] = 1;
         }
         if ( StringUtil.StrCmp(AV154Mudanzawwds_24_tfmudanzadireccionorigen_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[MudanzaDireccionOrigen] = ''))");
         }
         if ( AV155Mudanzawwds_25_tfmudanzapisodptoorigen_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV155Mudanzawwds_25_tfmudanzapisodptoorigen_sels, "T1.[MudanzaPisoDptoOrigen] IN (", ")")+")");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV157Mudanzawwds_27_tfmudanzadirecciondestino_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV156Mudanzawwds_26_tfmudanzadirecciondestino)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[MudanzaDireccionDestino]) like UPPER(@lV156Mudanzawwds_26_tfmudanzadirecciondestino))");
         }
         else
         {
            GXv_int5[45] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV157Mudanzawwds_27_tfmudanzadirecciondestino_sel)) && ! ( StringUtil.StrCmp(AV157Mudanzawwds_27_tfmudanzadirecciondestino_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[MudanzaDireccionDestino] = @AV157Mudanzawwds_27_tfmudanzadirecciondestino_sel)");
         }
         else
         {
            GXv_int5[46] = 1;
         }
         if ( StringUtil.StrCmp(AV157Mudanzawwds_27_tfmudanzadirecciondestino_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[MudanzaDireccionDestino] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV159Mudanzawwds_29_tfmudanzapisodptodestino_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV158Mudanzawwds_28_tfmudanzapisodptodestino)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[MudanzaPisoDptoDestino]) like UPPER(@lV158Mudanzawwds_28_tfmudanzapisodptodestino))");
         }
         else
         {
            GXv_int5[47] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV159Mudanzawwds_29_tfmudanzapisodptodestino_sel)) && ! ( StringUtil.StrCmp(AV159Mudanzawwds_29_tfmudanzapisodptodestino_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[MudanzaPisoDptoDestino] = @AV159Mudanzawwds_29_tfmudanzapisodptodestino_sel)");
         }
         else
         {
            GXv_int5[48] = 1;
         }
         if ( StringUtil.StrCmp(AV159Mudanzawwds_29_tfmudanzapisodptodestino_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[MudanzaPisoDptoDestino] = ''))");
         }
         if ( ! (Convert.ToDecimal(0)==AV160Mudanzawwds_30_tfmudanzadistancia) )
         {
            AddWhere(sWhereString, "(T1.[MudanzaDistancia] >= @AV160Mudanzawwds_30_tfmudanzadistancia)");
         }
         else
         {
            GXv_int5[49] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV161Mudanzawwds_31_tfmudanzadistancia_to) )
         {
            AddWhere(sWhereString, "(T1.[MudanzaDistancia] <= @AV161Mudanzawwds_31_tfmudanzadistancia_to)");
         }
         else
         {
            GXv_int5[50] = 1;
         }
         if ( AV162Mudanzawwds_32_tfmudanzavehiculosugerido_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV162Mudanzawwds_32_tfmudanzavehiculosugerido_sels, "T1.[MudanzaVehiculoSugerido] IN (", ")")+")");
         }
         if ( ! (Convert.ToDecimal(0)==AV163Mudanzawwds_33_tfmudanzapreciobasexhora) )
         {
            AddWhere(sWhereString, "(T1.[MudanzaPrecioBasexHora] >= @AV163Mudanzawwds_33_tfmudanzapreciobasexhora)");
         }
         else
         {
            GXv_int5[51] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV164Mudanzawwds_34_tfmudanzapreciobasexhora_to) )
         {
            AddWhere(sWhereString, "(T1.[MudanzaPrecioBasexHora] <= @AV164Mudanzawwds_34_tfmudanzapreciobasexhora_to)");
         }
         else
         {
            GXv_int5[52] = 1;
         }
         if ( ! (0==AV165Mudanzawwds_35_tfmudanzapeajecantidad) )
         {
            AddWhere(sWhereString, "(T1.[MudanzaPeajeCantidad] >= @AV165Mudanzawwds_35_tfmudanzapeajecantidad)");
         }
         else
         {
            GXv_int5[53] = 1;
         }
         if ( ! (0==AV166Mudanzawwds_36_tfmudanzapeajecantidad_to) )
         {
            AddWhere(sWhereString, "(T1.[MudanzaPeajeCantidad] <= @AV166Mudanzawwds_36_tfmudanzapeajecantidad_to)");
         }
         else
         {
            GXv_int5[54] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV167Mudanzawwds_37_tfmudanzapeajevalor) )
         {
            AddWhere(sWhereString, "(T1.[MudanzaPeajevalor] >= @AV167Mudanzawwds_37_tfmudanzapeajevalor)");
         }
         else
         {
            GXv_int5[55] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV168Mudanzawwds_38_tfmudanzapeajevalor_to) )
         {
            AddWhere(sWhereString, "(T1.[MudanzaPeajevalor] <= @AV168Mudanzawwds_38_tfmudanzapeajevalor_to)");
         }
         else
         {
            GXv_int5[56] = 1;
         }
         if ( ! (0==AV169Mudanzawwds_39_tftipoinmuebleorigenid) )
         {
            AddWhere(sWhereString, "(T1.[TipoInmuebleOrigenId] >= @AV169Mudanzawwds_39_tftipoinmuebleorigenid)");
         }
         else
         {
            GXv_int5[57] = 1;
         }
         if ( ! (0==AV170Mudanzawwds_40_tftipoinmuebleorigenid_to) )
         {
            AddWhere(sWhereString, "(T1.[TipoInmuebleOrigenId] <= @AV170Mudanzawwds_40_tftipoinmuebleorigenid_to)");
         }
         else
         {
            GXv_int5[58] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV172Mudanzawwds_42_tftipoinmuebleorigennombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV171Mudanzawwds_41_tftipoinmuebleorigennombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ParametroMudanzaNombre]) like UPPER(@lV171Mudanzawwds_41_tftipoinmuebleorigennombre))");
         }
         else
         {
            GXv_int5[59] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV172Mudanzawwds_42_tftipoinmuebleorigennombre_sel)) && ! ( StringUtil.StrCmp(AV172Mudanzawwds_42_tftipoinmuebleorigennombre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.[ParametroMudanzaNombre] = @AV172Mudanzawwds_42_tftipoinmuebleorigennombre_sel)");
         }
         else
         {
            GXv_int5[60] = 1;
         }
         if ( StringUtil.StrCmp(AV172Mudanzawwds_42_tftipoinmuebleorigennombre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T2.[ParametroMudanzaNombre] = ''))");
         }
         if ( ! (Convert.ToDecimal(0)==AV173Mudanzawwds_43_tftipoinmuebleorigenvalor) )
         {
            AddWhere(sWhereString, "(T2.[ParametroMudanzaValor] >= @AV173Mudanzawwds_43_tftipoinmuebleorigenvalor)");
         }
         else
         {
            GXv_int5[61] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV174Mudanzawwds_44_tftipoinmuebleorigenvalor_to) )
         {
            AddWhere(sWhereString, "(T2.[ParametroMudanzaValor] <= @AV174Mudanzawwds_44_tftipoinmuebleorigenvalor_to)");
         }
         else
         {
            GXv_int5[62] = 1;
         }
         scmdbuf += sWhereString;
         if ( ( AV17OrderedBy == 1 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[MudanzaAsesor]";
         }
         else if ( ( AV17OrderedBy == 1 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[MudanzaAsesor] DESC";
         }
         else if ( ( AV17OrderedBy == 2 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[MudanzaId]";
         }
         else if ( ( AV17OrderedBy == 2 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[MudanzaId] DESC";
         }
         else if ( ( AV17OrderedBy == 3 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[MudanzaFechaAlta]";
         }
         else if ( ( AV17OrderedBy == 3 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[MudanzaFechaAlta] DESC";
         }
         else if ( ( AV17OrderedBy == 4 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[MudanzaFechaServicio]";
         }
         else if ( ( AV17OrderedBy == 4 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[MudanzaFechaServicio] DESC";
         }
         else if ( ( AV17OrderedBy == 5 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[MudanzaHoraServicio]";
         }
         else if ( ( AV17OrderedBy == 5 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[MudanzaHoraServicio] DESC";
         }
         else if ( ( AV17OrderedBy == 6 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[MudanzaRgoHoraservicio]";
         }
         else if ( ( AV17OrderedBy == 6 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[MudanzaRgoHoraservicio] DESC";
         }
         else if ( ( AV17OrderedBy == 7 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[MudanzaDireccionOrigen]";
         }
         else if ( ( AV17OrderedBy == 7 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[MudanzaDireccionOrigen] DESC";
         }
         else if ( ( AV17OrderedBy == 8 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[MudanzaPisoDptoOrigen]";
         }
         else if ( ( AV17OrderedBy == 8 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[MudanzaPisoDptoOrigen] DESC";
         }
         else if ( ( AV17OrderedBy == 9 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[MudanzaDireccionDestino]";
         }
         else if ( ( AV17OrderedBy == 9 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[MudanzaDireccionDestino] DESC";
         }
         else if ( ( AV17OrderedBy == 10 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[MudanzaPisoDptoDestino]";
         }
         else if ( ( AV17OrderedBy == 10 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[MudanzaPisoDptoDestino] DESC";
         }
         else if ( ( AV17OrderedBy == 11 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[MudanzaDistancia]";
         }
         else if ( ( AV17OrderedBy == 11 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[MudanzaDistancia] DESC";
         }
         else if ( ( AV17OrderedBy == 12 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[MudanzaVehiculoSugerido]";
         }
         else if ( ( AV17OrderedBy == 12 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[MudanzaVehiculoSugerido] DESC";
         }
         else if ( ( AV17OrderedBy == 13 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[MudanzaPrecioBasexHora]";
         }
         else if ( ( AV17OrderedBy == 13 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[MudanzaPrecioBasexHora] DESC";
         }
         else if ( ( AV17OrderedBy == 14 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[MudanzaPeajeCantidad]";
         }
         else if ( ( AV17OrderedBy == 14 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[MudanzaPeajeCantidad] DESC";
         }
         else if ( ( AV17OrderedBy == 15 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[MudanzaPeajevalor]";
         }
         else if ( ( AV17OrderedBy == 15 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[MudanzaPeajevalor] DESC";
         }
         else if ( ( AV17OrderedBy == 16 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[TipoInmuebleOrigenId]";
         }
         else if ( ( AV17OrderedBy == 16 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[TipoInmuebleOrigenId] DESC";
         }
         else if ( ( AV17OrderedBy == 17 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T2.[ParametroMudanzaNombre]";
         }
         else if ( ( AV17OrderedBy == 17 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T2.[ParametroMudanzaNombre] DESC";
         }
         else if ( ( AV17OrderedBy == 18 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T2.[ParametroMudanzaValor]";
         }
         else if ( ( AV17OrderedBy == 18 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T2.[ParametroMudanzaValor] DESC";
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
                     return conditional_P00DS2(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (GxSimpleCollection<string>)dynConstraints[3] , (string)dynConstraints[4] , (GxSimpleCollection<string>)dynConstraints[5] , (string)dynConstraints[6] , (GxSimpleCollection<string>)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (short)dynConstraints[10] , (string)dynConstraints[11] , (bool)dynConstraints[12] , (string)dynConstraints[13] , (short)dynConstraints[14] , (string)dynConstraints[15] , (bool)dynConstraints[16] , (string)dynConstraints[17] , (short)dynConstraints[18] , (string)dynConstraints[19] , (long)dynConstraints[20] , (long)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (DateTime)dynConstraints[24] , (DateTime)dynConstraints[25] , (DateTime)dynConstraints[26] , (DateTime)dynConstraints[27] , (int)dynConstraints[28] , (int)dynConstraints[29] , (string)dynConstraints[30] , (string)dynConstraints[31] , (int)dynConstraints[32] , (string)dynConstraints[33] , (string)dynConstraints[34] , (string)dynConstraints[35] , (string)dynConstraints[36] , (decimal)dynConstraints[37] , (decimal)dynConstraints[38] , (int)dynConstraints[39] , (decimal)dynConstraints[40] , (decimal)dynConstraints[41] , (short)dynConstraints[42] , (short)dynConstraints[43] , (decimal)dynConstraints[44] , (decimal)dynConstraints[45] , (short)dynConstraints[46] , (short)dynConstraints[47] , (string)dynConstraints[48] , (string)dynConstraints[49] , (decimal)dynConstraints[50] , (decimal)dynConstraints[51] , (long)dynConstraints[52] , (string)dynConstraints[53] , (string)dynConstraints[54] , (string)dynConstraints[55] , (string)dynConstraints[56] , (decimal)dynConstraints[57] , (decimal)dynConstraints[58] , (short)dynConstraints[59] , (decimal)dynConstraints[60] , (short)dynConstraints[61] , (string)dynConstraints[62] , (decimal)dynConstraints[63] , (DateTime)dynConstraints[64] , (DateTime)dynConstraints[65] , (short)dynConstraints[66] , (bool)dynConstraints[67] );
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
          Object[] prmP00DS2;
          prmP00DS2 = new Object[] {
          new ParDef("@lV131Mudanzawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV131Mudanzawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV131Mudanzawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV131Mudanzawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV131Mudanzawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV131Mudanzawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV131Mudanzawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV131Mudanzawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV131Mudanzawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV131Mudanzawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV131Mudanzawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV131Mudanzawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV131Mudanzawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV131Mudanzawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV131Mudanzawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV131Mudanzawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV131Mudanzawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV131Mudanzawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV131Mudanzawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV131Mudanzawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV131Mudanzawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV131Mudanzawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV131Mudanzawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV131Mudanzawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV131Mudanzawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV131Mudanzawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV131Mudanzawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV131Mudanzawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV131Mudanzawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV134Mudanzawwds_4_mudanzaasesor1",GXType.VarChar,80,0) ,
          new ParDef("@lV134Mudanzawwds_4_mudanzaasesor1",GXType.VarChar,80,0) ,
          new ParDef("@lV138Mudanzawwds_8_mudanzaasesor2",GXType.VarChar,80,0) ,
          new ParDef("@lV138Mudanzawwds_8_mudanzaasesor2",GXType.VarChar,80,0) ,
          new ParDef("@lV142Mudanzawwds_12_mudanzaasesor3",GXType.VarChar,80,0) ,
          new ParDef("@lV142Mudanzawwds_12_mudanzaasesor3",GXType.VarChar,80,0) ,
          new ParDef("@AV143Mudanzawwds_13_tfmudanzaid",GXType.Decimal,18,0) ,
          new ParDef("@AV144Mudanzawwds_14_tfmudanzaid_to",GXType.Decimal,18,0) ,
          new ParDef("@lV145Mudanzawwds_15_tfmudanzaasesor",GXType.VarChar,80,0) ,
          new ParDef("@AV146Mudanzawwds_16_tfmudanzaasesor_sel",GXType.NVarChar,80,0) ,
          new ParDef("@AV147Mudanzawwds_17_tfmudanzafechaalta",GXType.Date,8,0) ,
          new ParDef("@AV148Mudanzawwds_18_tfmudanzafechaalta_to",GXType.Date,8,0) ,
          new ParDef("@AV149Mudanzawwds_19_tfmudanzafechaservicio",GXType.Date,8,0) ,
          new ParDef("@AV150Mudanzawwds_20_tfmudanzafechaservicio_to",GXType.Date,8,0) ,
          new ParDef("@lV153Mudanzawwds_23_tfmudanzadireccionorigen",GXType.VarChar,200,0) ,
          new ParDef("@AV154Mudanzawwds_24_tfmudanzadireccionorigen_sel",GXType.NVarChar,200,0) ,
          new ParDef("@lV156Mudanzawwds_26_tfmudanzadirecciondestino",GXType.VarChar,200,0) ,
          new ParDef("@AV157Mudanzawwds_27_tfmudanzadirecciondestino_sel",GXType.NVarChar,200,0) ,
          new ParDef("@lV158Mudanzawwds_28_tfmudanzapisodptodestino",GXType.Char,30,0) ,
          new ParDef("@AV159Mudanzawwds_29_tfmudanzapisodptodestino_sel",GXType.NChar,30,0) ,
          new ParDef("@AV160Mudanzawwds_30_tfmudanzadistancia",GXType.Decimal,10,2) ,
          new ParDef("@AV161Mudanzawwds_31_tfmudanzadistancia_to",GXType.Decimal,10,2) ,
          new ParDef("@AV163Mudanzawwds_33_tfmudanzapreciobasexhora",GXType.Decimal,18,2) ,
          new ParDef("@AV164Mudanzawwds_34_tfmudanzapreciobasexhora_to",GXType.Decimal,18,2) ,
          new ParDef("@AV165Mudanzawwds_35_tfmudanzapeajecantidad",GXType.Int16,1,0) ,
          new ParDef("@AV166Mudanzawwds_36_tfmudanzapeajecantidad_to",GXType.Int16,1,0) ,
          new ParDef("@AV167Mudanzawwds_37_tfmudanzapeajevalor",GXType.Decimal,18,2) ,
          new ParDef("@AV168Mudanzawwds_38_tfmudanzapeajevalor_to",GXType.Decimal,18,2) ,
          new ParDef("@AV169Mudanzawwds_39_tftipoinmuebleorigenid",GXType.Int16,4,0) ,
          new ParDef("@AV170Mudanzawwds_40_tftipoinmuebleorigenid_to",GXType.Int16,4,0) ,
          new ParDef("@lV171Mudanzawwds_41_tftipoinmuebleorigennombre",GXType.VarChar,100,0) ,
          new ParDef("@AV172Mudanzawwds_42_tftipoinmuebleorigennombre_sel",GXType.NVarChar,100,0) ,
          new ParDef("@AV173Mudanzawwds_43_tftipoinmuebleorigenvalor",GXType.Decimal,18,2) ,
          new ParDef("@AV174Mudanzawwds_44_tftipoinmuebleorigenvalor_to",GXType.Decimal,18,2)
          };
          def= new CursorDef[] {
              new CursorDef("P00DS2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00DS2,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
                ((short[]) buf[4])[0] = rslt.getShort(5);
                ((decimal[]) buf[5])[0] = rslt.getDecimal(6);
                ((string[]) buf[6])[0] = rslt.getVarchar(7);
                ((decimal[]) buf[7])[0] = rslt.getDecimal(8);
                ((string[]) buf[8])[0] = rslt.getString(9, 30);
                ((string[]) buf[9])[0] = rslt.getVarchar(10);
                ((string[]) buf[10])[0] = rslt.getString(11, 30);
                ((string[]) buf[11])[0] = rslt.getVarchar(12);
                ((DateTime[]) buf[12])[0] = rslt.getGXDate(13);
                ((DateTime[]) buf[13])[0] = rslt.getGXDate(14);
                ((string[]) buf[14])[0] = rslt.getVarchar(15);
                ((long[]) buf[15])[0] = rslt.getLong(16);
                ((string[]) buf[16])[0] = rslt.getString(17, 5);
                ((bool[]) buf[17])[0] = rslt.wasNull(17);
                ((string[]) buf[18])[0] = rslt.getString(18, 2);
                ((bool[]) buf[19])[0] = rslt.wasNull(18);
                return;
       }
    }

 }

}

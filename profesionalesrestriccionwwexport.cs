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
   public class profesionalesrestriccionwwexport : GXProcedure
   {
      public profesionalesrestriccionwwexport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public profesionalesrestriccionwwexport( IGxContext context )
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
         new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWProfesionalesRestriccion", out  GXt_boolean1) ;
         AV8IsAuthorized = GXt_boolean1;
         if ( ! AV8IsAuthorized )
         {
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "wwpbaseobjects.notauthorized.aspx"+GXUtil.UrlEncode(StringUtil.RTrim(AV80Pgmname));
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
         AV12Filename = GXt_char2 + "ProfesionalesRestriccionWWExport-" + StringUtil.Trim( StringUtil.Str( (decimal)(AV16Random), 8, 0)) + ".xlsx";
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
         if ( AV41GridState.gxTpr_Dynamicfilters.Count >= 1 )
         {
            AV38GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV41GridState.gxTpr_Dynamicfilters.Item(1));
            AV20DynamicFiltersSelector1 = AV38GridStateDynamicFilter.gxTpr_Selected;
            if ( StringUtil.StrCmp(AV20DynamicFiltersSelector1, "RESTRICCIONESFECHAALTA") == 0 )
            {
               AV21DynamicFiltersOperator1 = AV38GridStateDynamicFilter.gxTpr_Operator;
               AV23RestriccionesFechaAlta1 = context.localUtil.CToT( AV38GridStateDynamicFilter.gxTpr_Value, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               AV24RestriccionesFechaAlta_To1 = context.localUtil.CToT( AV38GridStateDynamicFilter.gxTpr_Valueto, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               AV22PrintFilterValue = false;
               if ( ! (DateTime.MinValue==AV23RestriccionesFechaAlta1) || ! (DateTime.MinValue==AV24RestriccionesFechaAlta_To1) )
               {
                  AV14CellRow = (int)(AV14CellRow+1);
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Bold = 1;
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Color = 3;
                  if ( AV21DynamicFiltersOperator1 == 0 )
                  {
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = context.GetMessage( "Fecha Alta", "");
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Italic = 1;
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = context.GetMessage( "WWP_FilterPast", "");
                  }
                  else if ( AV21DynamicFiltersOperator1 == 1 )
                  {
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = context.GetMessage( "Fecha Alta", "");
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Italic = 1;
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = context.GetMessage( "WWP_FilterToday", "");
                  }
                  else if ( AV21DynamicFiltersOperator1 == 2 )
                  {
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = context.GetMessage( "Fecha Alta", "");
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Italic = 1;
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = context.GetMessage( "WWP_FilterInTheFuture", "");
                  }
                  else if ( AV21DynamicFiltersOperator1 == 3 )
                  {
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", context.GetMessage( "Fecha Alta", ""), context.GetMessage( "WWP_FilterRange", ""), "", "", "", "", "", "", "");
                     AV22PrintFilterValue = true;
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+2, 1, 1).Bold = 1;
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+2, 1, 1).Color = 3;
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+2, 1, 1).Text = context.GetMessage( "WWP_MiddleText", "");
                  }
                  if ( AV22PrintFilterValue )
                  {
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Italic = 1;
                     AV11ExcelDocument.SetDateFormat(context, 8, 5, ((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0), DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt")), "/", ":", " ");
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Date = AV23RestriccionesFechaAlta1;
                     if ( AV22PrintFilterValue )
                     {
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+3, 1, 1).Italic = 1;
                        AV11ExcelDocument.SetDateFormat(context, 8, 5, ((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0), DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt")), "/", ":", " ");
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+3, 1, 1).Date = AV24RestriccionesFechaAlta_To1;
                     }
                  }
               }
            }
            else if ( StringUtil.StrCmp(AV20DynamicFiltersSelector1, "LISTANOMBRE") == 0 )
            {
               AV21DynamicFiltersOperator1 = AV38GridStateDynamicFilter.gxTpr_Operator;
               AV25ListaNombre1 = AV38GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV25ListaNombre1)) )
               {
                  AV14CellRow = (int)(AV14CellRow+1);
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Bold = 1;
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Color = 3;
                  if ( AV21DynamicFiltersOperator1 == 0 )
                  {
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", context.GetMessage( "Lista Nombre", ""), context.GetMessage( "WWP_FilterLike", ""), "", "", "", "", "", "", "");
                  }
                  else if ( AV21DynamicFiltersOperator1 == 1 )
                  {
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", context.GetMessage( "Lista Nombre", ""), context.GetMessage( "WWP_FilterContains", ""), "", "", "", "", "", "", "");
                  }
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Italic = 1;
                  GXt_char2 = "";
                  new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV25ListaNombre1, out  GXt_char2) ;
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
               }
            }
            if ( AV41GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV26DynamicFiltersEnabled2 = true;
               AV38GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV41GridState.gxTpr_Dynamicfilters.Item(2));
               AV27DynamicFiltersSelector2 = AV38GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV27DynamicFiltersSelector2, "RESTRICCIONESFECHAALTA") == 0 )
               {
                  AV28DynamicFiltersOperator2 = AV38GridStateDynamicFilter.gxTpr_Operator;
                  AV29RestriccionesFechaAlta2 = context.localUtil.CToT( AV38GridStateDynamicFilter.gxTpr_Value, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
                  AV30RestriccionesFechaAlta_To2 = context.localUtil.CToT( AV38GridStateDynamicFilter.gxTpr_Valueto, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
                  AV22PrintFilterValue = false;
                  if ( ! (DateTime.MinValue==AV29RestriccionesFechaAlta2) || ! (DateTime.MinValue==AV30RestriccionesFechaAlta_To2) )
                  {
                     AV14CellRow = (int)(AV14CellRow+1);
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Bold = 1;
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Color = 3;
                     if ( AV28DynamicFiltersOperator2 == 0 )
                     {
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = context.GetMessage( "Fecha Alta", "");
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Italic = 1;
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = context.GetMessage( "WWP_FilterPast", "");
                     }
                     else if ( AV28DynamicFiltersOperator2 == 1 )
                     {
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = context.GetMessage( "Fecha Alta", "");
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Italic = 1;
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = context.GetMessage( "WWP_FilterToday", "");
                     }
                     else if ( AV28DynamicFiltersOperator2 == 2 )
                     {
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = context.GetMessage( "Fecha Alta", "");
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Italic = 1;
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = context.GetMessage( "WWP_FilterInTheFuture", "");
                     }
                     else if ( AV28DynamicFiltersOperator2 == 3 )
                     {
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", context.GetMessage( "Fecha Alta", ""), context.GetMessage( "WWP_FilterRange", ""), "", "", "", "", "", "", "");
                        AV22PrintFilterValue = true;
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+2, 1, 1).Bold = 1;
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+2, 1, 1).Color = 3;
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+2, 1, 1).Text = context.GetMessage( "WWP_MiddleText", "");
                     }
                     if ( AV22PrintFilterValue )
                     {
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Italic = 1;
                        AV11ExcelDocument.SetDateFormat(context, 8, 5, ((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0), DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt")), "/", ":", " ");
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Date = AV29RestriccionesFechaAlta2;
                        if ( AV22PrintFilterValue )
                        {
                           AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+3, 1, 1).Italic = 1;
                           AV11ExcelDocument.SetDateFormat(context, 8, 5, ((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0), DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt")), "/", ":", " ");
                           AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+3, 1, 1).Date = AV30RestriccionesFechaAlta_To2;
                        }
                     }
                  }
               }
               else if ( StringUtil.StrCmp(AV27DynamicFiltersSelector2, "LISTANOMBRE") == 0 )
               {
                  AV28DynamicFiltersOperator2 = AV38GridStateDynamicFilter.gxTpr_Operator;
                  AV31ListaNombre2 = AV38GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV31ListaNombre2)) )
                  {
                     AV14CellRow = (int)(AV14CellRow+1);
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Bold = 1;
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Color = 3;
                     if ( AV28DynamicFiltersOperator2 == 0 )
                     {
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", context.GetMessage( "Lista Nombre", ""), context.GetMessage( "WWP_FilterLike", ""), "", "", "", "", "", "", "");
                     }
                     else if ( AV28DynamicFiltersOperator2 == 1 )
                     {
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", context.GetMessage( "Lista Nombre", ""), context.GetMessage( "WWP_FilterContains", ""), "", "", "", "", "", "", "");
                     }
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Italic = 1;
                     GXt_char2 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV31ListaNombre2, out  GXt_char2) ;
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
                  }
               }
               if ( AV41GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV32DynamicFiltersEnabled3 = true;
                  AV38GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV41GridState.gxTpr_Dynamicfilters.Item(3));
                  AV33DynamicFiltersSelector3 = AV38GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV33DynamicFiltersSelector3, "RESTRICCIONESFECHAALTA") == 0 )
                  {
                     AV34DynamicFiltersOperator3 = AV38GridStateDynamicFilter.gxTpr_Operator;
                     AV35RestriccionesFechaAlta3 = context.localUtil.CToT( AV38GridStateDynamicFilter.gxTpr_Value, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
                     AV36RestriccionesFechaAlta_To3 = context.localUtil.CToT( AV38GridStateDynamicFilter.gxTpr_Valueto, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
                     AV22PrintFilterValue = false;
                     if ( ! (DateTime.MinValue==AV35RestriccionesFechaAlta3) || ! (DateTime.MinValue==AV36RestriccionesFechaAlta_To3) )
                     {
                        AV14CellRow = (int)(AV14CellRow+1);
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Bold = 1;
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Color = 3;
                        if ( AV34DynamicFiltersOperator3 == 0 )
                        {
                           AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = context.GetMessage( "Fecha Alta", "");
                           AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Italic = 1;
                           AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = context.GetMessage( "WWP_FilterPast", "");
                        }
                        else if ( AV34DynamicFiltersOperator3 == 1 )
                        {
                           AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = context.GetMessage( "Fecha Alta", "");
                           AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Italic = 1;
                           AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = context.GetMessage( "WWP_FilterToday", "");
                        }
                        else if ( AV34DynamicFiltersOperator3 == 2 )
                        {
                           AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = context.GetMessage( "Fecha Alta", "");
                           AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Italic = 1;
                           AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = context.GetMessage( "WWP_FilterInTheFuture", "");
                        }
                        else if ( AV34DynamicFiltersOperator3 == 3 )
                        {
                           AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", context.GetMessage( "Fecha Alta", ""), context.GetMessage( "WWP_FilterRange", ""), "", "", "", "", "", "", "");
                           AV22PrintFilterValue = true;
                           AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+2, 1, 1).Bold = 1;
                           AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+2, 1, 1).Color = 3;
                           AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+2, 1, 1).Text = context.GetMessage( "WWP_MiddleText", "");
                        }
                        if ( AV22PrintFilterValue )
                        {
                           AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Italic = 1;
                           AV11ExcelDocument.SetDateFormat(context, 8, 5, ((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0), DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt")), "/", ":", " ");
                           AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Date = AV35RestriccionesFechaAlta3;
                           if ( AV22PrintFilterValue )
                           {
                              AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+3, 1, 1).Italic = 1;
                              AV11ExcelDocument.SetDateFormat(context, 8, 5, ((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0), DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt")), "/", ":", " ");
                              AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+3, 1, 1).Date = AV36RestriccionesFechaAlta_To3;
                           }
                        }
                     }
                  }
                  else if ( StringUtil.StrCmp(AV33DynamicFiltersSelector3, "LISTANOMBRE") == 0 )
                  {
                     AV34DynamicFiltersOperator3 = AV38GridStateDynamicFilter.gxTpr_Operator;
                     AV37ListaNombre3 = AV38GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV37ListaNombre3)) )
                     {
                        AV14CellRow = (int)(AV14CellRow+1);
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Bold = 1;
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Color = 3;
                        if ( AV34DynamicFiltersOperator3 == 0 )
                        {
                           AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", context.GetMessage( "Lista Nombre", ""), context.GetMessage( "WWP_FilterLike", ""), "", "", "", "", "", "", "");
                        }
                        else if ( AV34DynamicFiltersOperator3 == 1 )
                        {
                           AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", context.GetMessage( "Lista Nombre", ""), context.GetMessage( "WWP_FilterContains", ""), "", "", "", "", "", "", "");
                        }
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Italic = 1;
                        GXt_char2 = "";
                        new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV37ListaNombre3, out  GXt_char2) ;
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
                     }
                  }
               }
            }
         }
         if ( ! ( (0==AV54TFProfesionalesRestriccionId) && (0==AV55TFProfesionalesRestriccionId_To) ) )
         {
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Restriccion Id", "")) ;
            AV14CellRow = GXt_int3;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Number = AV54TFProfesionalesRestriccionId;
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  false, ref  GXt_int3,  (short)(AV15FirstColumn+2),  context.GetMessage( "WWP_TSTo", "")) ;
            AV14CellRow = GXt_int3;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+3, 1, 1).Number = AV55TFProfesionalesRestriccionId_To;
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV57TFProfesionalesId_Sel)) ) )
         {
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Identidad", "")) ;
            AV14CellRow = GXt_int3;
            GXt_char2 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV57TFProfesionalesId_Sel)) ? context.GetMessage( "WWP_TitleFilter_EmptyOption", "") : AV57TFProfesionalesId_Sel), out  GXt_char2) ;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV56TFProfesionalesId)) ) )
            {
               GXt_int3 = (short)(AV14CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Identidad", "")) ;
               AV14CellRow = GXt_int3;
               GXt_char2 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV56TFProfesionalesId, out  GXt_char2) ;
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV59TFProfesionalesPrimerNombre_Sel)) ) )
         {
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Primer Nombre", "")) ;
            AV14CellRow = GXt_int3;
            GXt_char2 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV59TFProfesionalesPrimerNombre_Sel)) ? context.GetMessage( "WWP_TitleFilter_EmptyOption", "") : AV59TFProfesionalesPrimerNombre_Sel), out  GXt_char2) ;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV58TFProfesionalesPrimerNombre)) ) )
            {
               GXt_int3 = (short)(AV14CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Primer Nombre", "")) ;
               AV14CellRow = GXt_int3;
               GXt_char2 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV58TFProfesionalesPrimerNombre, out  GXt_char2) ;
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV61TFProfesionalesApellidoPrimero_Sel)) ) )
         {
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Primer Apellido ", "")) ;
            AV14CellRow = GXt_int3;
            GXt_char2 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV61TFProfesionalesApellidoPrimero_Sel)) ? context.GetMessage( "WWP_TitleFilter_EmptyOption", "") : AV61TFProfesionalesApellidoPrimero_Sel), out  GXt_char2) ;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV60TFProfesionalesApellidoPrimero)) ) )
            {
               GXt_int3 = (short)(AV14CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Primer Apellido ", "")) ;
               AV14CellRow = GXt_int3;
               GXt_char2 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV60TFProfesionalesApellidoPrimero, out  GXt_char2) ;
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
            }
         }
         if ( ! ( (0==AV62TFListaid) && (0==AV63TFListaid_To) ) )
         {
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Listaid", "")) ;
            AV14CellRow = GXt_int3;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Number = AV62TFListaid;
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  false, ref  GXt_int3,  (short)(AV15FirstColumn+2),  context.GetMessage( "WWP_TSTo", "")) ;
            AV14CellRow = GXt_int3;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+3, 1, 1).Number = AV63TFListaid_To;
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV65TFListaNombre_Sel)) ) )
         {
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Nombre", "")) ;
            AV14CellRow = GXt_int3;
            GXt_char2 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV65TFListaNombre_Sel)) ? context.GetMessage( "WWP_TitleFilter_EmptyOption", "") : AV65TFListaNombre_Sel), out  GXt_char2) ;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV64TFListaNombre)) ) )
            {
               GXt_int3 = (short)(AV14CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Nombre", "")) ;
               AV14CellRow = GXt_int3;
               GXt_char2 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV64TFListaNombre, out  GXt_char2) ;
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
            }
         }
         if ( ! ( ( AV68TFListaEstado_Sels.Count == 0 ) ) )
         {
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Estado", "")) ;
            AV14CellRow = GXt_int3;
            AV79i = 1;
            AV81GXV1 = 1;
            while ( AV81GXV1 <= AV68TFListaEstado_Sels.Count )
            {
               AV67TFListaEstado_Sel = AV68TFListaEstado_Sels.GetString(AV81GXV1);
               if ( AV79i == 1 )
               {
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = "";
               }
               else
               {
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text+", ";
               }
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text+context.GetMessage( gxdomainestadoenum.getDescription(context,AV67TFListaEstado_Sel), "");
               AV79i = (long)(AV79i+1);
               AV81GXV1 = (int)(AV81GXV1+1);
            }
         }
         if ( ! ( ( AV71TFListaTipo_Sels.Count == 0 ) ) )
         {
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Tipo", "")) ;
            AV14CellRow = GXt_int3;
            AV79i = 1;
            AV82GXV2 = 1;
            while ( AV82GXV2 <= AV71TFListaTipo_Sels.Count )
            {
               AV70TFListaTipo_Sel = AV71TFListaTipo_Sels.GetString(AV82GXV2);
               if ( AV79i == 1 )
               {
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = "";
               }
               else
               {
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text+", ";
               }
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text+context.GetMessage( gxdomainlistatipoenum.getDescription(context,AV70TFListaTipo_Sel), "");
               AV79i = (long)(AV79i+1);
               AV82GXV2 = (int)(AV82GXV2+1);
            }
         }
         if ( ! ( (DateTime.MinValue==AV72TFRestriccionesFechaAlta) && (DateTime.MinValue==AV73TFRestriccionesFechaAlta_To) ) )
         {
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Fecha Alta", "")) ;
            AV14CellRow = GXt_int3;
            AV11ExcelDocument.SetDateFormat(context, 8, 5, ((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0), DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt")), "/", ":", " ");
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Date = AV72TFRestriccionesFechaAlta;
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  false, ref  GXt_int3,  (short)(AV15FirstColumn+2),  context.GetMessage( "WWP_TSTo", "")) ;
            AV14CellRow = GXt_int3;
            AV11ExcelDocument.SetDateFormat(context, 8, 5, ((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0), DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt")), "/", ":", " ");
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+3, 1, 1).Date = AV73TFRestriccionesFechaAlta_To;
         }
         if ( ! ( ( AV76TFRestriccionesEstado_Sels.Count == 0 ) ) )
         {
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Estado", "")) ;
            AV14CellRow = GXt_int3;
            AV79i = 1;
            AV83GXV3 = 1;
            while ( AV83GXV3 <= AV76TFRestriccionesEstado_Sels.Count )
            {
               AV75TFRestriccionesEstado_Sel = AV76TFRestriccionesEstado_Sels.GetString(AV83GXV3);
               if ( AV79i == 1 )
               {
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = "";
               }
               else
               {
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text+", ";
               }
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text+context.GetMessage( gxdomainestadoenum.getDescription(context,AV75TFRestriccionesEstado_Sel), "");
               AV79i = (long)(AV79i+1);
               AV83GXV3 = (int)(AV83GXV3+1);
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV78TFRestriccionesObservacion_Sel)) ) )
         {
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Observacion", "")) ;
            AV14CellRow = GXt_int3;
            GXt_char2 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV78TFRestriccionesObservacion_Sel)) ? context.GetMessage( "WWP_TitleFilter_EmptyOption", "") : AV78TFRestriccionesObservacion_Sel), out  GXt_char2) ;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV77TFRestriccionesObservacion)) ) )
            {
               GXt_int3 = (short)(AV14CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Observacion", "")) ;
               AV14CellRow = GXt_int3;
               GXt_char2 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV77TFRestriccionesObservacion, out  GXt_char2) ;
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
            }
         }
         AV14CellRow = (int)(AV14CellRow+2);
      }

      protected void S141( )
      {
         /* 'WRITECOLUMNTITLES' Routine */
         returnInSub = false;
         AV51VisibleColumnCount = 0;
         if ( StringUtil.StrCmp(AV39Session.Get("ProfesionalesRestriccionWWColumnsSelector"), "") != 0 )
         {
            AV46ColumnsSelectorXML = AV39Session.Get("ProfesionalesRestriccionWWColumnsSelector");
            AV43ColumnsSelector.FromXml(AV46ColumnsSelectorXML, null, "", "");
         }
         else
         {
            /* Execute user subroutine: 'INITIALIZECOLUMNSSELECTOR' */
            S151 ();
            if (returnInSub) return;
         }
         AV43ColumnsSelector.gxTpr_Columns.Sort("Order");
         AV84GXV4 = 1;
         while ( AV84GXV4 <= AV43ColumnsSelector.gxTpr_Columns.Count )
         {
            AV45ColumnsSelector_Column = ((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV43ColumnsSelector.gxTpr_Columns.Item(AV84GXV4));
            if ( AV45ColumnsSelector_Column.gxTpr_Isvisible )
            {
               AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV51VisibleColumnCount), 1, 1).Text = context.GetMessage( (String.IsNullOrEmpty(StringUtil.RTrim( AV45ColumnsSelector_Column.gxTpr_Displayname)) ? AV45ColumnsSelector_Column.gxTpr_Columnname : AV45ColumnsSelector_Column.gxTpr_Displayname), "");
               AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV51VisibleColumnCount), 1, 1).Bold = 1;
               AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV51VisibleColumnCount), 1, 1).Color = 11;
               AV51VisibleColumnCount = (long)(AV51VisibleColumnCount+1);
            }
            AV84GXV4 = (int)(AV84GXV4+1);
         }
      }

      protected void S161( )
      {
         /* 'WRITEDATA' Routine */
         returnInSub = false;
         AV86Profesionalesrestriccionwwds_1_filterfulltext = AV19FilterFullText;
         AV87Profesionalesrestriccionwwds_2_dynamicfiltersselector1 = AV20DynamicFiltersSelector1;
         AV88Profesionalesrestriccionwwds_3_dynamicfiltersoperator1 = AV21DynamicFiltersOperator1;
         AV89Profesionalesrestriccionwwds_4_restriccionesfechaalta1 = AV23RestriccionesFechaAlta1;
         AV90Profesionalesrestriccionwwds_5_restriccionesfechaalta_to1 = AV24RestriccionesFechaAlta_To1;
         AV91Profesionalesrestriccionwwds_6_listanombre1 = AV25ListaNombre1;
         AV92Profesionalesrestriccionwwds_7_dynamicfiltersenabled2 = AV26DynamicFiltersEnabled2;
         AV93Profesionalesrestriccionwwds_8_dynamicfiltersselector2 = AV27DynamicFiltersSelector2;
         AV94Profesionalesrestriccionwwds_9_dynamicfiltersoperator2 = AV28DynamicFiltersOperator2;
         AV95Profesionalesrestriccionwwds_10_restriccionesfechaalta2 = AV29RestriccionesFechaAlta2;
         AV96Profesionalesrestriccionwwds_11_restriccionesfechaalta_to2 = AV30RestriccionesFechaAlta_To2;
         AV97Profesionalesrestriccionwwds_12_listanombre2 = AV31ListaNombre2;
         AV98Profesionalesrestriccionwwds_13_dynamicfiltersenabled3 = AV32DynamicFiltersEnabled3;
         AV99Profesionalesrestriccionwwds_14_dynamicfiltersselector3 = AV33DynamicFiltersSelector3;
         AV100Profesionalesrestriccionwwds_15_dynamicfiltersoperator3 = AV34DynamicFiltersOperator3;
         AV101Profesionalesrestriccionwwds_16_restriccionesfechaalta3 = AV35RestriccionesFechaAlta3;
         AV102Profesionalesrestriccionwwds_17_restriccionesfechaalta_to3 = AV36RestriccionesFechaAlta_To3;
         AV103Profesionalesrestriccionwwds_18_listanombre3 = AV37ListaNombre3;
         AV104Profesionalesrestriccionwwds_19_tfprofesionalesrestriccionid = AV54TFProfesionalesRestriccionId;
         AV105Profesionalesrestriccionwwds_20_tfprofesionalesrestriccionid_to = AV55TFProfesionalesRestriccionId_To;
         AV106Profesionalesrestriccionwwds_21_tfprofesionalesid = AV56TFProfesionalesId;
         AV107Profesionalesrestriccionwwds_22_tfprofesionalesid_sel = AV57TFProfesionalesId_Sel;
         AV108Profesionalesrestriccionwwds_23_tfprofesionalesprimernombre = AV58TFProfesionalesPrimerNombre;
         AV109Profesionalesrestriccionwwds_24_tfprofesionalesprimernombre_sel = AV59TFProfesionalesPrimerNombre_Sel;
         AV110Profesionalesrestriccionwwds_25_tfprofesionalesapellidoprimero = AV60TFProfesionalesApellidoPrimero;
         AV111Profesionalesrestriccionwwds_26_tfprofesionalesapellidoprimero_sel = AV61TFProfesionalesApellidoPrimero_Sel;
         AV112Profesionalesrestriccionwwds_27_tflistaid = AV62TFListaid;
         AV113Profesionalesrestriccionwwds_28_tflistaid_to = AV63TFListaid_To;
         AV114Profesionalesrestriccionwwds_29_tflistanombre = AV64TFListaNombre;
         AV115Profesionalesrestriccionwwds_30_tflistanombre_sel = AV65TFListaNombre_Sel;
         AV116Profesionalesrestriccionwwds_31_tflistaestado_sels = AV68TFListaEstado_Sels;
         AV117Profesionalesrestriccionwwds_32_tflistatipo_sels = AV71TFListaTipo_Sels;
         AV118Profesionalesrestriccionwwds_33_tfrestriccionesfechaalta = AV72TFRestriccionesFechaAlta;
         AV119Profesionalesrestriccionwwds_34_tfrestriccionesfechaalta_to = AV73TFRestriccionesFechaAlta_To;
         AV120Profesionalesrestriccionwwds_35_tfrestriccionesestado_sels = AV76TFRestriccionesEstado_Sels;
         AV121Profesionalesrestriccionwwds_36_tfrestriccionesobservacion = AV77TFRestriccionesObservacion;
         AV122Profesionalesrestriccionwwds_37_tfrestriccionesobservacion_sel = AV78TFRestriccionesObservacion_Sel;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A593ListaEstado ,
                                              AV116Profesionalesrestriccionwwds_31_tflistaestado_sels ,
                                              A591ListaTipo ,
                                              AV117Profesionalesrestriccionwwds_32_tflistatipo_sels ,
                                              A974RestriccionesEstado ,
                                              AV120Profesionalesrestriccionwwds_35_tfrestriccionesestado_sels ,
                                              AV87Profesionalesrestriccionwwds_2_dynamicfiltersselector1 ,
                                              AV88Profesionalesrestriccionwwds_3_dynamicfiltersoperator1 ,
                                              AV89Profesionalesrestriccionwwds_4_restriccionesfechaalta1 ,
                                              AV90Profesionalesrestriccionwwds_5_restriccionesfechaalta_to1 ,
                                              AV91Profesionalesrestriccionwwds_6_listanombre1 ,
                                              AV92Profesionalesrestriccionwwds_7_dynamicfiltersenabled2 ,
                                              AV93Profesionalesrestriccionwwds_8_dynamicfiltersselector2 ,
                                              AV94Profesionalesrestriccionwwds_9_dynamicfiltersoperator2 ,
                                              AV95Profesionalesrestriccionwwds_10_restriccionesfechaalta2 ,
                                              AV96Profesionalesrestriccionwwds_11_restriccionesfechaalta_to2 ,
                                              AV97Profesionalesrestriccionwwds_12_listanombre2 ,
                                              AV98Profesionalesrestriccionwwds_13_dynamicfiltersenabled3 ,
                                              AV99Profesionalesrestriccionwwds_14_dynamicfiltersselector3 ,
                                              AV100Profesionalesrestriccionwwds_15_dynamicfiltersoperator3 ,
                                              AV101Profesionalesrestriccionwwds_16_restriccionesfechaalta3 ,
                                              AV102Profesionalesrestriccionwwds_17_restriccionesfechaalta_to3 ,
                                              AV103Profesionalesrestriccionwwds_18_listanombre3 ,
                                              AV104Profesionalesrestriccionwwds_19_tfprofesionalesrestriccionid ,
                                              AV105Profesionalesrestriccionwwds_20_tfprofesionalesrestriccionid_to ,
                                              AV107Profesionalesrestriccionwwds_22_tfprofesionalesid_sel ,
                                              AV106Profesionalesrestriccionwwds_21_tfprofesionalesid ,
                                              AV109Profesionalesrestriccionwwds_24_tfprofesionalesprimernombre_sel ,
                                              AV108Profesionalesrestriccionwwds_23_tfprofesionalesprimernombre ,
                                              AV111Profesionalesrestriccionwwds_26_tfprofesionalesapellidoprimero_sel ,
                                              AV110Profesionalesrestriccionwwds_25_tfprofesionalesapellidoprimero ,
                                              AV112Profesionalesrestriccionwwds_27_tflistaid ,
                                              AV113Profesionalesrestriccionwwds_28_tflistaid_to ,
                                              AV115Profesionalesrestriccionwwds_30_tflistanombre_sel ,
                                              AV114Profesionalesrestriccionwwds_29_tflistanombre ,
                                              AV116Profesionalesrestriccionwwds_31_tflistaestado_sels.Count ,
                                              AV117Profesionalesrestriccionwwds_32_tflistatipo_sels.Count ,
                                              AV118Profesionalesrestriccionwwds_33_tfrestriccionesfechaalta ,
                                              AV119Profesionalesrestriccionwwds_34_tfrestriccionesfechaalta_to ,
                                              AV120Profesionalesrestriccionwwds_35_tfrestriccionesestado_sels.Count ,
                                              AV122Profesionalesrestriccionwwds_37_tfrestriccionesobservacion_sel ,
                                              AV121Profesionalesrestriccionwwds_36_tfrestriccionesobservacion ,
                                              A973RestriccionesFechaAlta ,
                                              A592ListaNombre ,
                                              A976ProfesionalesRestriccionId ,
                                              A120ProfesionalesId ,
                                              A166ProfesionalesPrimerNombre ,
                                              A167ProfesionalesApellidoPrimero ,
                                              A590Listaid ,
                                              A975RestriccionesObservacion ,
                                              AV17OrderedBy ,
                                              AV18OrderedDsc ,
                                              AV86Profesionalesrestriccionwwds_1_filterfulltext } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.BOOLEAN,
                                              TypeConstants.SHORT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.INT, TypeConstants.INT, TypeConstants.DATE,
                                              TypeConstants.DATE, TypeConstants.INT, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV91Profesionalesrestriccionwwds_6_listanombre1 = StringUtil.PadR( StringUtil.RTrim( AV91Profesionalesrestriccionwwds_6_listanombre1), 80, "%");
         lV91Profesionalesrestriccionwwds_6_listanombre1 = StringUtil.PadR( StringUtil.RTrim( AV91Profesionalesrestriccionwwds_6_listanombre1), 80, "%");
         lV97Profesionalesrestriccionwwds_12_listanombre2 = StringUtil.PadR( StringUtil.RTrim( AV97Profesionalesrestriccionwwds_12_listanombre2), 80, "%");
         lV97Profesionalesrestriccionwwds_12_listanombre2 = StringUtil.PadR( StringUtil.RTrim( AV97Profesionalesrestriccionwwds_12_listanombre2), 80, "%");
         lV103Profesionalesrestriccionwwds_18_listanombre3 = StringUtil.PadR( StringUtil.RTrim( AV103Profesionalesrestriccionwwds_18_listanombre3), 80, "%");
         lV103Profesionalesrestriccionwwds_18_listanombre3 = StringUtil.PadR( StringUtil.RTrim( AV103Profesionalesrestriccionwwds_18_listanombre3), 80, "%");
         lV106Profesionalesrestriccionwwds_21_tfprofesionalesid = StringUtil.PadR( StringUtil.RTrim( AV106Profesionalesrestriccionwwds_21_tfprofesionalesid), 20, "%");
         lV108Profesionalesrestriccionwwds_23_tfprofesionalesprimernombre = StringUtil.PadR( StringUtil.RTrim( AV108Profesionalesrestriccionwwds_23_tfprofesionalesprimernombre), 30, "%");
         lV110Profesionalesrestriccionwwds_25_tfprofesionalesapellidoprimero = StringUtil.PadR( StringUtil.RTrim( AV110Profesionalesrestriccionwwds_25_tfprofesionalesapellidoprimero), 30, "%");
         lV114Profesionalesrestriccionwwds_29_tflistanombre = StringUtil.PadR( StringUtil.RTrim( AV114Profesionalesrestriccionwwds_29_tflistanombre), 80, "%");
         lV121Profesionalesrestriccionwwds_36_tfrestriccionesobservacion = StringUtil.Concat( StringUtil.RTrim( AV121Profesionalesrestriccionwwds_36_tfrestriccionesobservacion), "%", "");
         /* Using cursor P00M82 */
         pr_default.execute(0, new Object[] {AV89Profesionalesrestriccionwwds_4_restriccionesfechaalta1, AV89Profesionalesrestriccionwwds_4_restriccionesfechaalta1, AV90Profesionalesrestriccionwwds_5_restriccionesfechaalta_to1, AV90Profesionalesrestriccionwwds_5_restriccionesfechaalta_to1, lV91Profesionalesrestriccionwwds_6_listanombre1, lV91Profesionalesrestriccionwwds_6_listanombre1, AV95Profesionalesrestriccionwwds_10_restriccionesfechaalta2, AV95Profesionalesrestriccionwwds_10_restriccionesfechaalta2, AV96Profesionalesrestriccionwwds_11_restriccionesfechaalta_to2, AV96Profesionalesrestriccionwwds_11_restriccionesfechaalta_to2, lV97Profesionalesrestriccionwwds_12_listanombre2, lV97Profesionalesrestriccionwwds_12_listanombre2, AV101Profesionalesrestriccionwwds_16_restriccionesfechaalta3, AV101Profesionalesrestriccionwwds_16_restriccionesfechaalta3, AV102Profesionalesrestriccionwwds_17_restriccionesfechaalta_to3, AV102Profesionalesrestriccionwwds_17_restriccionesfechaalta_to3, lV103Profesionalesrestriccionwwds_18_listanombre3, lV103Profesionalesrestriccionwwds_18_listanombre3, AV104Profesionalesrestriccionwwds_19_tfprofesionalesrestriccionid, AV105Profesionalesrestriccionwwds_20_tfprofesionalesrestriccionid_to, lV106Profesionalesrestriccionwwds_21_tfprofesionalesid, AV107Profesionalesrestriccionwwds_22_tfprofesionalesid_sel, lV108Profesionalesrestriccionwwds_23_tfprofesionalesprimernombre, AV109Profesionalesrestriccionwwds_24_tfprofesionalesprimernombre_sel, lV110Profesionalesrestriccionwwds_25_tfprofesionalesapellidoprimero, AV111Profesionalesrestriccionwwds_26_tfprofesionalesapellidoprimero_sel, AV112Profesionalesrestriccionwwds_27_tflistaid, AV113Profesionalesrestriccionwwds_28_tflistaid_to, lV114Profesionalesrestriccionwwds_29_tflistanombre, AV115Profesionalesrestriccionwwds_30_tflistanombre_sel, AV118Profesionalesrestriccionwwds_33_tfrestriccionesfechaalta, AV119Profesionalesrestriccionwwds_34_tfrestriccionesfechaalta_to, lV121Profesionalesrestriccionwwds_36_tfrestriccionesobservacion, AV122Profesionalesrestriccionwwds_37_tfrestriccionesobservacion_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A975RestriccionesObservacion = P00M82_A975RestriccionesObservacion[0];
            n975RestriccionesObservacion = P00M82_n975RestriccionesObservacion[0];
            A592ListaNombre = P00M82_A592ListaNombre[0];
            A590Listaid = P00M82_A590Listaid[0];
            A167ProfesionalesApellidoPrimero = P00M82_A167ProfesionalesApellidoPrimero[0];
            A166ProfesionalesPrimerNombre = P00M82_A166ProfesionalesPrimerNombre[0];
            A120ProfesionalesId = P00M82_A120ProfesionalesId[0];
            A976ProfesionalesRestriccionId = P00M82_A976ProfesionalesRestriccionId[0];
            A973RestriccionesFechaAlta = P00M82_A973RestriccionesFechaAlta[0];
            n973RestriccionesFechaAlta = P00M82_n973RestriccionesFechaAlta[0];
            A974RestriccionesEstado = P00M82_A974RestriccionesEstado[0];
            n974RestriccionesEstado = P00M82_n974RestriccionesEstado[0];
            A591ListaTipo = P00M82_A591ListaTipo[0];
            A593ListaEstado = P00M82_A593ListaEstado[0];
            n593ListaEstado = P00M82_n593ListaEstado[0];
            A592ListaNombre = P00M82_A592ListaNombre[0];
            A591ListaTipo = P00M82_A591ListaTipo[0];
            A593ListaEstado = P00M82_A593ListaEstado[0];
            n593ListaEstado = P00M82_n593ListaEstado[0];
            A167ProfesionalesApellidoPrimero = P00M82_A167ProfesionalesApellidoPrimero[0];
            A166ProfesionalesPrimerNombre = P00M82_A166ProfesionalesPrimerNombre[0];
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV86Profesionalesrestriccionwwds_1_filterfulltext)) || ( ( StringUtil.Like( StringUtil.Str( (decimal)(A976ProfesionalesRestriccionId), 18, 0) , StringUtil.PadR( "%" + AV86Profesionalesrestriccionwwds_1_filterfulltext , 254 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Upper( A120ProfesionalesId) , StringUtil.PadR( "%" + StringUtil.Upper( AV86Profesionalesrestriccionwwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A166ProfesionalesPrimerNombre) , StringUtil.PadR( "%" + StringUtil.Upper( AV86Profesionalesrestriccionwwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Upper( A167ProfesionalesApellidoPrimero) , StringUtil.PadR( "%" + StringUtil.Upper( AV86Profesionalesrestriccionwwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Str( (decimal)(A590Listaid), 18, 0) , StringUtil.PadR( "%" + AV86Profesionalesrestriccionwwds_1_filterfulltext , 254 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Upper( A592ListaNombre) , StringUtil.PadR( "%" + StringUtil.Upper( AV86Profesionalesrestriccionwwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( context.GetMessage( "habilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV86Profesionalesrestriccionwwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A593ListaEstado, "HAB") ==
            0 ) ) || ( StringUtil.Like( context.GetMessage( "deshabilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV86Profesionalesrestriccionwwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A593ListaEstado, "DES") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "pendiente", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV86Profesionalesrestriccionwwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A593ListaEstado, "PEN") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "proveedor", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV86Profesionalesrestriccionwwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A591ListaTipo, "PROV") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "profesional", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV86Profesionalesrestriccionwwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A591ListaTipo, "PROF") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "administrativa", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV86Profesionalesrestriccionwwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A591ListaTipo, "ADM") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "restriccion", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV86Profesionalesrestriccionwwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A591ListaTipo, "RST") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "habilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV86Profesionalesrestriccionwwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A974RestriccionesEstado, "HAB") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "deshabilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV86Profesionalesrestriccionwwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A974RestriccionesEstado, "DES") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "pendiente", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV86Profesionalesrestriccionwwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A974RestriccionesEstado, "PEN") == 0 ) ) || ( StringUtil.Like( StringUtil.Upper( A975RestriccionesObservacion) , StringUtil.PadR( "%" + StringUtil.Upper( AV86Profesionalesrestriccionwwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) )
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
               AV51VisibleColumnCount = 0;
               AV123GXV5 = 1;
               while ( AV123GXV5 <= AV43ColumnsSelector.gxTpr_Columns.Count )
               {
                  AV45ColumnsSelector_Column = ((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV43ColumnsSelector.gxTpr_Columns.Item(AV123GXV5));
                  if ( AV45ColumnsSelector_Column.gxTpr_Isvisible )
                  {
                     if ( StringUtil.StrCmp(AV45ColumnsSelector_Column.gxTpr_Columnname, "ProfesionalesRestriccionId") == 0 )
                     {
                        AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV51VisibleColumnCount), 1, 1).Number = A976ProfesionalesRestriccionId;
                     }
                     else if ( StringUtil.StrCmp(AV45ColumnsSelector_Column.gxTpr_Columnname, "ProfesionalesId") == 0 )
                     {
                        GXt_char2 = "";
                        new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A120ProfesionalesId, out  GXt_char2) ;
                        AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV51VisibleColumnCount), 1, 1).Text = GXt_char2;
                     }
                     else if ( StringUtil.StrCmp(AV45ColumnsSelector_Column.gxTpr_Columnname, "ProfesionalesPrimerNombre") == 0 )
                     {
                        GXt_char2 = "";
                        new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A166ProfesionalesPrimerNombre, out  GXt_char2) ;
                        AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV51VisibleColumnCount), 1, 1).Text = GXt_char2;
                     }
                     else if ( StringUtil.StrCmp(AV45ColumnsSelector_Column.gxTpr_Columnname, "ProfesionalesApellidoPrimero") == 0 )
                     {
                        GXt_char2 = "";
                        new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A167ProfesionalesApellidoPrimero, out  GXt_char2) ;
                        AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV51VisibleColumnCount), 1, 1).Text = GXt_char2;
                     }
                     else if ( StringUtil.StrCmp(AV45ColumnsSelector_Column.gxTpr_Columnname, "Listaid") == 0 )
                     {
                        AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV51VisibleColumnCount), 1, 1).Number = A590Listaid;
                     }
                     else if ( StringUtil.StrCmp(AV45ColumnsSelector_Column.gxTpr_Columnname, "ListaNombre") == 0 )
                     {
                        GXt_char2 = "";
                        new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A592ListaNombre, out  GXt_char2) ;
                        AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV51VisibleColumnCount), 1, 1).Text = GXt_char2;
                     }
                     else if ( StringUtil.StrCmp(AV45ColumnsSelector_Column.gxTpr_Columnname, "ListaEstado") == 0 )
                     {
                        AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV51VisibleColumnCount), 1, 1).Text = context.GetMessage( gxdomainestadoenum.getDescription(context,A593ListaEstado), "");
                     }
                     else if ( StringUtil.StrCmp(AV45ColumnsSelector_Column.gxTpr_Columnname, "ListaTipo") == 0 )
                     {
                        AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV51VisibleColumnCount), 1, 1).Text = context.GetMessage( gxdomainlistatipoenum.getDescription(context,A591ListaTipo), "");
                     }
                     else if ( StringUtil.StrCmp(AV45ColumnsSelector_Column.gxTpr_Columnname, "RestriccionesFechaAlta") == 0 )
                     {
                        AV11ExcelDocument.SetDateFormat(context, 8, 5, ((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0), DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt")), "/", ":", " ");
                        AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV51VisibleColumnCount), 1, 1).Date = A973RestriccionesFechaAlta;
                     }
                     else if ( StringUtil.StrCmp(AV45ColumnsSelector_Column.gxTpr_Columnname, "RestriccionesEstado") == 0 )
                     {
                        AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV51VisibleColumnCount), 1, 1).Text = context.GetMessage( gxdomainestadoenum.getDescription(context,A974RestriccionesEstado), "");
                     }
                     else if ( StringUtil.StrCmp(AV45ColumnsSelector_Column.gxTpr_Columnname, "RestriccionesObservacion") == 0 )
                     {
                        GXt_char2 = "";
                        new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A975RestriccionesObservacion, out  GXt_char2) ;
                        AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV51VisibleColumnCount), 1, 1).Text = GXt_char2;
                     }
                     AV51VisibleColumnCount = (long)(AV51VisibleColumnCount+1);
                  }
                  AV123GXV5 = (int)(AV123GXV5+1);
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
         AV39Session.Set("WWPExportFilePath", AV12Filename);
         AV39Session.Set("WWPExportFileName", "ProfesionalesRestriccionWWExport.xlsx");
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
         AV43ColumnsSelector = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector(context);
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV43ColumnsSelector,  "ProfesionalesRestriccionId",  "",  "Restriccion Id",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV43ColumnsSelector,  "ProfesionalesId",  "",  "Identidad",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV43ColumnsSelector,  "ProfesionalesPrimerNombre",  "",  "Primer Nombre",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV43ColumnsSelector,  "ProfesionalesApellidoPrimero",  "",  "Primer Apellido ",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV43ColumnsSelector,  "Listaid",  "",  "Listaid",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV43ColumnsSelector,  "ListaNombre",  "",  "Nombre",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV43ColumnsSelector,  "ListaEstado",  "",  "Estado",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV43ColumnsSelector,  "ListaTipo",  "",  "Tipo",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV43ColumnsSelector,  "RestriccionesFechaAlta",  "",  "Fecha Alta",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV43ColumnsSelector,  "RestriccionesEstado",  "",  "Estado",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV43ColumnsSelector,  "RestriccionesObservacion",  "",  "Observacion",  true,  "") ;
         GXt_char2 = AV47UserCustomValue;
         new GeneXus.Programs.wwpbaseobjects.loadcolumnsselectorstate(context ).execute(  "ProfesionalesRestriccionWWColumnsSelector", out  GXt_char2) ;
         AV47UserCustomValue = GXt_char2;
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV47UserCustomValue)) ) )
         {
            AV44ColumnsSelectorAux.FromXml(AV47UserCustomValue, null, "", "");
            new GeneXus.Programs.wwpbaseobjects.wwp_columnselector_updatecolumns(context ).execute( ref  AV44ColumnsSelectorAux, ref  AV43ColumnsSelector) ;
         }
      }

      protected void S201( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV39Session.Get("ProfesionalesRestriccionWWGridState"), "") == 0 )
         {
            AV41GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "ProfesionalesRestriccionWWGridState"), null, "", "");
         }
         else
         {
            AV41GridState.FromXml(AV39Session.Get("ProfesionalesRestriccionWWGridState"), null, "", "");
         }
         AV17OrderedBy = AV41GridState.gxTpr_Orderedby;
         AV18OrderedDsc = AV41GridState.gxTpr_Ordereddsc;
         AV124GXV6 = 1;
         while ( AV124GXV6 <= AV41GridState.gxTpr_Filtervalues.Count )
         {
            AV42GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV41GridState.gxTpr_Filtervalues.Item(AV124GXV6));
            if ( StringUtil.StrCmp(AV42GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV19FilterFullText = AV42GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV42GridStateFilterValue.gxTpr_Name, "TFPROFESIONALESRESTRICCIONID") == 0 )
            {
               AV54TFProfesionalesRestriccionId = (long)(Math.Round(NumberUtil.Val( AV42GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV55TFProfesionalesRestriccionId_To = (long)(Math.Round(NumberUtil.Val( AV42GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV42GridStateFilterValue.gxTpr_Name, "TFPROFESIONALESID") == 0 )
            {
               AV56TFProfesionalesId = AV42GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV42GridStateFilterValue.gxTpr_Name, "TFPROFESIONALESID_SEL") == 0 )
            {
               AV57TFProfesionalesId_Sel = AV42GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV42GridStateFilterValue.gxTpr_Name, "TFPROFESIONALESPRIMERNOMBRE") == 0 )
            {
               AV58TFProfesionalesPrimerNombre = AV42GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV42GridStateFilterValue.gxTpr_Name, "TFPROFESIONALESPRIMERNOMBRE_SEL") == 0 )
            {
               AV59TFProfesionalesPrimerNombre_Sel = AV42GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV42GridStateFilterValue.gxTpr_Name, "TFPROFESIONALESAPELLIDOPRIMERO") == 0 )
            {
               AV60TFProfesionalesApellidoPrimero = AV42GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV42GridStateFilterValue.gxTpr_Name, "TFPROFESIONALESAPELLIDOPRIMERO_SEL") == 0 )
            {
               AV61TFProfesionalesApellidoPrimero_Sel = AV42GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV42GridStateFilterValue.gxTpr_Name, "TFLISTAID") == 0 )
            {
               AV62TFListaid = (long)(Math.Round(NumberUtil.Val( AV42GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV63TFListaid_To = (long)(Math.Round(NumberUtil.Val( AV42GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV42GridStateFilterValue.gxTpr_Name, "TFLISTANOMBRE") == 0 )
            {
               AV64TFListaNombre = AV42GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV42GridStateFilterValue.gxTpr_Name, "TFLISTANOMBRE_SEL") == 0 )
            {
               AV65TFListaNombre_Sel = AV42GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV42GridStateFilterValue.gxTpr_Name, "TFLISTAESTADO_SEL") == 0 )
            {
               AV66TFListaEstado_SelsJson = AV42GridStateFilterValue.gxTpr_Value;
               AV68TFListaEstado_Sels.FromJSonString(AV66TFListaEstado_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV42GridStateFilterValue.gxTpr_Name, "TFLISTATIPO_SEL") == 0 )
            {
               AV69TFListaTipo_SelsJson = AV42GridStateFilterValue.gxTpr_Value;
               AV71TFListaTipo_Sels.FromJSonString(AV69TFListaTipo_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV42GridStateFilterValue.gxTpr_Name, "TFRESTRICCIONESFECHAALTA") == 0 )
            {
               AV72TFRestriccionesFechaAlta = context.localUtil.CToT( AV42GridStateFilterValue.gxTpr_Value, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               AV73TFRestriccionesFechaAlta_To = context.localUtil.CToT( AV42GridStateFilterValue.gxTpr_Valueto, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
            }
            else if ( StringUtil.StrCmp(AV42GridStateFilterValue.gxTpr_Name, "TFRESTRICCIONESESTADO_SEL") == 0 )
            {
               AV74TFRestriccionesEstado_SelsJson = AV42GridStateFilterValue.gxTpr_Value;
               AV76TFRestriccionesEstado_Sels.FromJSonString(AV74TFRestriccionesEstado_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV42GridStateFilterValue.gxTpr_Name, "TFRESTRICCIONESOBSERVACION") == 0 )
            {
               AV77TFRestriccionesObservacion = AV42GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV42GridStateFilterValue.gxTpr_Name, "TFRESTRICCIONESOBSERVACION_SEL") == 0 )
            {
               AV78TFRestriccionesObservacion_Sel = AV42GridStateFilterValue.gxTpr_Value;
            }
            AV124GXV6 = (int)(AV124GXV6+1);
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
         AV80Pgmname = "";
         GXKey = "";
         GXEncryptionTmp = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV11ExcelDocument = new ExcelDocumentI();
         AV19FilterFullText = "";
         AV41GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV38GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV20DynamicFiltersSelector1 = "";
         AV23RestriccionesFechaAlta1 = (DateTime)(DateTime.MinValue);
         AV24RestriccionesFechaAlta_To1 = (DateTime)(DateTime.MinValue);
         AV25ListaNombre1 = "";
         AV27DynamicFiltersSelector2 = "";
         AV29RestriccionesFechaAlta2 = (DateTime)(DateTime.MinValue);
         AV30RestriccionesFechaAlta_To2 = (DateTime)(DateTime.MinValue);
         AV31ListaNombre2 = "";
         AV33DynamicFiltersSelector3 = "";
         AV35RestriccionesFechaAlta3 = (DateTime)(DateTime.MinValue);
         AV36RestriccionesFechaAlta_To3 = (DateTime)(DateTime.MinValue);
         AV37ListaNombre3 = "";
         AV57TFProfesionalesId_Sel = "";
         AV56TFProfesionalesId = "";
         AV59TFProfesionalesPrimerNombre_Sel = "";
         AV58TFProfesionalesPrimerNombre = "";
         AV61TFProfesionalesApellidoPrimero_Sel = "";
         AV60TFProfesionalesApellidoPrimero = "";
         AV65TFListaNombre_Sel = "";
         AV64TFListaNombre = "";
         AV68TFListaEstado_Sels = new GxSimpleCollection<string>();
         AV67TFListaEstado_Sel = "";
         AV71TFListaTipo_Sels = new GxSimpleCollection<string>();
         AV70TFListaTipo_Sel = "";
         AV72TFRestriccionesFechaAlta = (DateTime)(DateTime.MinValue);
         AV73TFRestriccionesFechaAlta_To = (DateTime)(DateTime.MinValue);
         AV76TFRestriccionesEstado_Sels = new GxSimpleCollection<string>();
         AV75TFRestriccionesEstado_Sel = "";
         AV78TFRestriccionesObservacion_Sel = "";
         AV77TFRestriccionesObservacion = "";
         AV39Session = context.GetSession();
         AV46ColumnsSelectorXML = "";
         AV43ColumnsSelector = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector(context);
         AV45ColumnsSelector_Column = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column(context);
         AV86Profesionalesrestriccionwwds_1_filterfulltext = "";
         AV87Profesionalesrestriccionwwds_2_dynamicfiltersselector1 = "";
         AV89Profesionalesrestriccionwwds_4_restriccionesfechaalta1 = (DateTime)(DateTime.MinValue);
         AV90Profesionalesrestriccionwwds_5_restriccionesfechaalta_to1 = (DateTime)(DateTime.MinValue);
         AV91Profesionalesrestriccionwwds_6_listanombre1 = "";
         AV93Profesionalesrestriccionwwds_8_dynamicfiltersselector2 = "";
         AV95Profesionalesrestriccionwwds_10_restriccionesfechaalta2 = (DateTime)(DateTime.MinValue);
         AV96Profesionalesrestriccionwwds_11_restriccionesfechaalta_to2 = (DateTime)(DateTime.MinValue);
         AV97Profesionalesrestriccionwwds_12_listanombre2 = "";
         AV99Profesionalesrestriccionwwds_14_dynamicfiltersselector3 = "";
         AV101Profesionalesrestriccionwwds_16_restriccionesfechaalta3 = (DateTime)(DateTime.MinValue);
         AV102Profesionalesrestriccionwwds_17_restriccionesfechaalta_to3 = (DateTime)(DateTime.MinValue);
         AV103Profesionalesrestriccionwwds_18_listanombre3 = "";
         AV106Profesionalesrestriccionwwds_21_tfprofesionalesid = "";
         AV107Profesionalesrestriccionwwds_22_tfprofesionalesid_sel = "";
         AV108Profesionalesrestriccionwwds_23_tfprofesionalesprimernombre = "";
         AV109Profesionalesrestriccionwwds_24_tfprofesionalesprimernombre_sel = "";
         AV110Profesionalesrestriccionwwds_25_tfprofesionalesapellidoprimero = "";
         AV111Profesionalesrestriccionwwds_26_tfprofesionalesapellidoprimero_sel = "";
         AV114Profesionalesrestriccionwwds_29_tflistanombre = "";
         AV115Profesionalesrestriccionwwds_30_tflistanombre_sel = "";
         AV116Profesionalesrestriccionwwds_31_tflistaestado_sels = new GxSimpleCollection<string>();
         AV117Profesionalesrestriccionwwds_32_tflistatipo_sels = new GxSimpleCollection<string>();
         AV118Profesionalesrestriccionwwds_33_tfrestriccionesfechaalta = (DateTime)(DateTime.MinValue);
         AV119Profesionalesrestriccionwwds_34_tfrestriccionesfechaalta_to = (DateTime)(DateTime.MinValue);
         AV120Profesionalesrestriccionwwds_35_tfrestriccionesestado_sels = new GxSimpleCollection<string>();
         AV121Profesionalesrestriccionwwds_36_tfrestriccionesobservacion = "";
         AV122Profesionalesrestriccionwwds_37_tfrestriccionesobservacion_sel = "";
         lV86Profesionalesrestriccionwwds_1_filterfulltext = "";
         lV91Profesionalesrestriccionwwds_6_listanombre1 = "";
         lV97Profesionalesrestriccionwwds_12_listanombre2 = "";
         lV103Profesionalesrestriccionwwds_18_listanombre3 = "";
         lV106Profesionalesrestriccionwwds_21_tfprofesionalesid = "";
         lV108Profesionalesrestriccionwwds_23_tfprofesionalesprimernombre = "";
         lV110Profesionalesrestriccionwwds_25_tfprofesionalesapellidoprimero = "";
         lV114Profesionalesrestriccionwwds_29_tflistanombre = "";
         lV121Profesionalesrestriccionwwds_36_tfrestriccionesobservacion = "";
         A593ListaEstado = "";
         A591ListaTipo = "";
         A974RestriccionesEstado = "";
         A973RestriccionesFechaAlta = (DateTime)(DateTime.MinValue);
         A592ListaNombre = "";
         A120ProfesionalesId = "";
         A166ProfesionalesPrimerNombre = "";
         A167ProfesionalesApellidoPrimero = "";
         A975RestriccionesObservacion = "";
         P00M82_A975RestriccionesObservacion = new string[] {""} ;
         P00M82_n975RestriccionesObservacion = new bool[] {false} ;
         P00M82_A592ListaNombre = new string[] {""} ;
         P00M82_A590Listaid = new long[1] ;
         P00M82_A167ProfesionalesApellidoPrimero = new string[] {""} ;
         P00M82_A166ProfesionalesPrimerNombre = new string[] {""} ;
         P00M82_A120ProfesionalesId = new string[] {""} ;
         P00M82_A976ProfesionalesRestriccionId = new long[1] ;
         P00M82_A973RestriccionesFechaAlta = new DateTime[] {DateTime.MinValue} ;
         P00M82_n973RestriccionesFechaAlta = new bool[] {false} ;
         P00M82_A974RestriccionesEstado = new string[] {""} ;
         P00M82_n974RestriccionesEstado = new bool[] {false} ;
         P00M82_A591ListaTipo = new string[] {""} ;
         P00M82_A593ListaEstado = new string[] {""} ;
         P00M82_n593ListaEstado = new bool[] {false} ;
         AV47UserCustomValue = "";
         GXt_char2 = "";
         AV44ColumnsSelectorAux = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector(context);
         AV42GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV66TFListaEstado_SelsJson = "";
         AV69TFListaTipo_SelsJson = "";
         AV74TFRestriccionesEstado_SelsJson = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.profesionalesrestriccionwwexport__default(),
            new Object[][] {
                new Object[] {
               P00M82_A975RestriccionesObservacion, P00M82_n975RestriccionesObservacion, P00M82_A592ListaNombre, P00M82_A590Listaid, P00M82_A167ProfesionalesApellidoPrimero, P00M82_A166ProfesionalesPrimerNombre, P00M82_A120ProfesionalesId, P00M82_A976ProfesionalesRestriccionId, P00M82_A973RestriccionesFechaAlta, P00M82_n973RestriccionesFechaAlta,
               P00M82_A974RestriccionesEstado, P00M82_n974RestriccionesEstado, P00M82_A591ListaTipo, P00M82_A593ListaEstado, P00M82_n593ListaEstado
               }
            }
         );
         AV80Pgmname = "ProfesionalesRestriccionWWExport";
         /* GeneXus formulas. */
         AV80Pgmname = "ProfesionalesRestriccionWWExport";
      }

      private short AV21DynamicFiltersOperator1 ;
      private short AV28DynamicFiltersOperator2 ;
      private short AV34DynamicFiltersOperator3 ;
      private short GXt_int3 ;
      private short AV88Profesionalesrestriccionwwds_3_dynamicfiltersoperator1 ;
      private short AV94Profesionalesrestriccionwwds_9_dynamicfiltersoperator2 ;
      private short AV100Profesionalesrestriccionwwds_15_dynamicfiltersoperator3 ;
      private short AV17OrderedBy ;
      private int AV14CellRow ;
      private int AV15FirstColumn ;
      private int AV16Random ;
      private int AV81GXV1 ;
      private int AV82GXV2 ;
      private int AV83GXV3 ;
      private int AV84GXV4 ;
      private int AV116Profesionalesrestriccionwwds_31_tflistaestado_sels_Count ;
      private int AV117Profesionalesrestriccionwwds_32_tflistatipo_sels_Count ;
      private int AV120Profesionalesrestriccionwwds_35_tfrestriccionesestado_sels_Count ;
      private int AV123GXV5 ;
      private int AV124GXV6 ;
      private long AV54TFProfesionalesRestriccionId ;
      private long AV55TFProfesionalesRestriccionId_To ;
      private long AV62TFListaid ;
      private long AV63TFListaid_To ;
      private long AV79i ;
      private long AV51VisibleColumnCount ;
      private long AV104Profesionalesrestriccionwwds_19_tfprofesionalesrestriccionid ;
      private long AV105Profesionalesrestriccionwwds_20_tfprofesionalesrestriccionid_to ;
      private long AV112Profesionalesrestriccionwwds_27_tflistaid ;
      private long AV113Profesionalesrestriccionwwds_28_tflistaid_to ;
      private long A976ProfesionalesRestriccionId ;
      private long A590Listaid ;
      private string AV80Pgmname ;
      private string GXKey ;
      private string GXEncryptionTmp ;
      private string AV25ListaNombre1 ;
      private string AV31ListaNombre2 ;
      private string AV37ListaNombre3 ;
      private string AV57TFProfesionalesId_Sel ;
      private string AV56TFProfesionalesId ;
      private string AV59TFProfesionalesPrimerNombre_Sel ;
      private string AV58TFProfesionalesPrimerNombre ;
      private string AV61TFProfesionalesApellidoPrimero_Sel ;
      private string AV60TFProfesionalesApellidoPrimero ;
      private string AV65TFListaNombre_Sel ;
      private string AV64TFListaNombre ;
      private string AV67TFListaEstado_Sel ;
      private string AV70TFListaTipo_Sel ;
      private string AV75TFRestriccionesEstado_Sel ;
      private string AV91Profesionalesrestriccionwwds_6_listanombre1 ;
      private string AV97Profesionalesrestriccionwwds_12_listanombre2 ;
      private string AV103Profesionalesrestriccionwwds_18_listanombre3 ;
      private string AV106Profesionalesrestriccionwwds_21_tfprofesionalesid ;
      private string AV107Profesionalesrestriccionwwds_22_tfprofesionalesid_sel ;
      private string AV108Profesionalesrestriccionwwds_23_tfprofesionalesprimernombre ;
      private string AV109Profesionalesrestriccionwwds_24_tfprofesionalesprimernombre_sel ;
      private string AV110Profesionalesrestriccionwwds_25_tfprofesionalesapellidoprimero ;
      private string AV111Profesionalesrestriccionwwds_26_tfprofesionalesapellidoprimero_sel ;
      private string AV114Profesionalesrestriccionwwds_29_tflistanombre ;
      private string AV115Profesionalesrestriccionwwds_30_tflistanombre_sel ;
      private string lV91Profesionalesrestriccionwwds_6_listanombre1 ;
      private string lV97Profesionalesrestriccionwwds_12_listanombre2 ;
      private string lV103Profesionalesrestriccionwwds_18_listanombre3 ;
      private string lV106Profesionalesrestriccionwwds_21_tfprofesionalesid ;
      private string lV108Profesionalesrestriccionwwds_23_tfprofesionalesprimernombre ;
      private string lV110Profesionalesrestriccionwwds_25_tfprofesionalesapellidoprimero ;
      private string lV114Profesionalesrestriccionwwds_29_tflistanombre ;
      private string A593ListaEstado ;
      private string A591ListaTipo ;
      private string A974RestriccionesEstado ;
      private string A592ListaNombre ;
      private string A120ProfesionalesId ;
      private string A166ProfesionalesPrimerNombre ;
      private string A167ProfesionalesApellidoPrimero ;
      private string GXt_char2 ;
      private DateTime AV23RestriccionesFechaAlta1 ;
      private DateTime AV24RestriccionesFechaAlta_To1 ;
      private DateTime AV29RestriccionesFechaAlta2 ;
      private DateTime AV30RestriccionesFechaAlta_To2 ;
      private DateTime AV35RestriccionesFechaAlta3 ;
      private DateTime AV36RestriccionesFechaAlta_To3 ;
      private DateTime AV72TFRestriccionesFechaAlta ;
      private DateTime AV73TFRestriccionesFechaAlta_To ;
      private DateTime AV89Profesionalesrestriccionwwds_4_restriccionesfechaalta1 ;
      private DateTime AV90Profesionalesrestriccionwwds_5_restriccionesfechaalta_to1 ;
      private DateTime AV95Profesionalesrestriccionwwds_10_restriccionesfechaalta2 ;
      private DateTime AV96Profesionalesrestriccionwwds_11_restriccionesfechaalta_to2 ;
      private DateTime AV101Profesionalesrestriccionwwds_16_restriccionesfechaalta3 ;
      private DateTime AV102Profesionalesrestriccionwwds_17_restriccionesfechaalta_to3 ;
      private DateTime AV118Profesionalesrestriccionwwds_33_tfrestriccionesfechaalta ;
      private DateTime AV119Profesionalesrestriccionwwds_34_tfrestriccionesfechaalta_to ;
      private DateTime A973RestriccionesFechaAlta ;
      private bool AV8IsAuthorized ;
      private bool GXt_boolean1 ;
      private bool returnInSub ;
      private bool AV22PrintFilterValue ;
      private bool AV26DynamicFiltersEnabled2 ;
      private bool AV32DynamicFiltersEnabled3 ;
      private bool AV92Profesionalesrestriccionwwds_7_dynamicfiltersenabled2 ;
      private bool AV98Profesionalesrestriccionwwds_13_dynamicfiltersenabled3 ;
      private bool AV18OrderedDsc ;
      private bool n975RestriccionesObservacion ;
      private bool n973RestriccionesFechaAlta ;
      private bool n974RestriccionesEstado ;
      private bool n593ListaEstado ;
      private string AV46ColumnsSelectorXML ;
      private string AV47UserCustomValue ;
      private string AV66TFListaEstado_SelsJson ;
      private string AV69TFListaTipo_SelsJson ;
      private string AV74TFRestriccionesEstado_SelsJson ;
      private string AV12Filename ;
      private string AV13ErrorMessage ;
      private string AV19FilterFullText ;
      private string AV20DynamicFiltersSelector1 ;
      private string AV27DynamicFiltersSelector2 ;
      private string AV33DynamicFiltersSelector3 ;
      private string AV78TFRestriccionesObservacion_Sel ;
      private string AV77TFRestriccionesObservacion ;
      private string AV86Profesionalesrestriccionwwds_1_filterfulltext ;
      private string AV87Profesionalesrestriccionwwds_2_dynamicfiltersselector1 ;
      private string AV93Profesionalesrestriccionwwds_8_dynamicfiltersselector2 ;
      private string AV99Profesionalesrestriccionwwds_14_dynamicfiltersselector3 ;
      private string AV121Profesionalesrestriccionwwds_36_tfrestriccionesobservacion ;
      private string AV122Profesionalesrestriccionwwds_37_tfrestriccionesobservacion_sel ;
      private string lV86Profesionalesrestriccionwwds_1_filterfulltext ;
      private string lV121Profesionalesrestriccionwwds_36_tfrestriccionesobservacion ;
      private string A975RestriccionesObservacion ;
      private IGxSession AV39Session ;
      private ExcelDocumentI AV11ExcelDocument ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV41GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV38GridStateDynamicFilter ;
      private GxSimpleCollection<string> AV68TFListaEstado_Sels ;
      private GxSimpleCollection<string> AV71TFListaTipo_Sels ;
      private GxSimpleCollection<string> AV76TFRestriccionesEstado_Sels ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector AV43ColumnsSelector ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column AV45ColumnsSelector_Column ;
      private GxSimpleCollection<string> AV116Profesionalesrestriccionwwds_31_tflistaestado_sels ;
      private GxSimpleCollection<string> AV117Profesionalesrestriccionwwds_32_tflistatipo_sels ;
      private GxSimpleCollection<string> AV120Profesionalesrestriccionwwds_35_tfrestriccionesestado_sels ;
      private IDataStoreProvider pr_default ;
      private string[] P00M82_A975RestriccionesObservacion ;
      private bool[] P00M82_n975RestriccionesObservacion ;
      private string[] P00M82_A592ListaNombre ;
      private long[] P00M82_A590Listaid ;
      private string[] P00M82_A167ProfesionalesApellidoPrimero ;
      private string[] P00M82_A166ProfesionalesPrimerNombre ;
      private string[] P00M82_A120ProfesionalesId ;
      private long[] P00M82_A976ProfesionalesRestriccionId ;
      private DateTime[] P00M82_A973RestriccionesFechaAlta ;
      private bool[] P00M82_n973RestriccionesFechaAlta ;
      private string[] P00M82_A974RestriccionesEstado ;
      private bool[] P00M82_n974RestriccionesEstado ;
      private string[] P00M82_A591ListaTipo ;
      private string[] P00M82_A593ListaEstado ;
      private bool[] P00M82_n593ListaEstado ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector AV44ColumnsSelectorAux ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV42GridStateFilterValue ;
      private string aP0_Filename ;
      private string aP1_ErrorMessage ;
   }

   public class profesionalesrestriccionwwexport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00M82( IGxContext context ,
                                             string A593ListaEstado ,
                                             GxSimpleCollection<string> AV116Profesionalesrestriccionwwds_31_tflistaestado_sels ,
                                             string A591ListaTipo ,
                                             GxSimpleCollection<string> AV117Profesionalesrestriccionwwds_32_tflistatipo_sels ,
                                             string A974RestriccionesEstado ,
                                             GxSimpleCollection<string> AV120Profesionalesrestriccionwwds_35_tfrestriccionesestado_sels ,
                                             string AV87Profesionalesrestriccionwwds_2_dynamicfiltersselector1 ,
                                             short AV88Profesionalesrestriccionwwds_3_dynamicfiltersoperator1 ,
                                             DateTime AV89Profesionalesrestriccionwwds_4_restriccionesfechaalta1 ,
                                             DateTime AV90Profesionalesrestriccionwwds_5_restriccionesfechaalta_to1 ,
                                             string AV91Profesionalesrestriccionwwds_6_listanombre1 ,
                                             bool AV92Profesionalesrestriccionwwds_7_dynamicfiltersenabled2 ,
                                             string AV93Profesionalesrestriccionwwds_8_dynamicfiltersselector2 ,
                                             short AV94Profesionalesrestriccionwwds_9_dynamicfiltersoperator2 ,
                                             DateTime AV95Profesionalesrestriccionwwds_10_restriccionesfechaalta2 ,
                                             DateTime AV96Profesionalesrestriccionwwds_11_restriccionesfechaalta_to2 ,
                                             string AV97Profesionalesrestriccionwwds_12_listanombre2 ,
                                             bool AV98Profesionalesrestriccionwwds_13_dynamicfiltersenabled3 ,
                                             string AV99Profesionalesrestriccionwwds_14_dynamicfiltersselector3 ,
                                             short AV100Profesionalesrestriccionwwds_15_dynamicfiltersoperator3 ,
                                             DateTime AV101Profesionalesrestriccionwwds_16_restriccionesfechaalta3 ,
                                             DateTime AV102Profesionalesrestriccionwwds_17_restriccionesfechaalta_to3 ,
                                             string AV103Profesionalesrestriccionwwds_18_listanombre3 ,
                                             long AV104Profesionalesrestriccionwwds_19_tfprofesionalesrestriccionid ,
                                             long AV105Profesionalesrestriccionwwds_20_tfprofesionalesrestriccionid_to ,
                                             string AV107Profesionalesrestriccionwwds_22_tfprofesionalesid_sel ,
                                             string AV106Profesionalesrestriccionwwds_21_tfprofesionalesid ,
                                             string AV109Profesionalesrestriccionwwds_24_tfprofesionalesprimernombre_sel ,
                                             string AV108Profesionalesrestriccionwwds_23_tfprofesionalesprimernombre ,
                                             string AV111Profesionalesrestriccionwwds_26_tfprofesionalesapellidoprimero_sel ,
                                             string AV110Profesionalesrestriccionwwds_25_tfprofesionalesapellidoprimero ,
                                             long AV112Profesionalesrestriccionwwds_27_tflistaid ,
                                             long AV113Profesionalesrestriccionwwds_28_tflistaid_to ,
                                             string AV115Profesionalesrestriccionwwds_30_tflistanombre_sel ,
                                             string AV114Profesionalesrestriccionwwds_29_tflistanombre ,
                                             int AV116Profesionalesrestriccionwwds_31_tflistaestado_sels_Count ,
                                             int AV117Profesionalesrestriccionwwds_32_tflistatipo_sels_Count ,
                                             DateTime AV118Profesionalesrestriccionwwds_33_tfrestriccionesfechaalta ,
                                             DateTime AV119Profesionalesrestriccionwwds_34_tfrestriccionesfechaalta_to ,
                                             int AV120Profesionalesrestriccionwwds_35_tfrestriccionesestado_sels_Count ,
                                             string AV122Profesionalesrestriccionwwds_37_tfrestriccionesobservacion_sel ,
                                             string AV121Profesionalesrestriccionwwds_36_tfrestriccionesobservacion ,
                                             DateTime A973RestriccionesFechaAlta ,
                                             string A592ListaNombre ,
                                             long A976ProfesionalesRestriccionId ,
                                             string A120ProfesionalesId ,
                                             string A166ProfesionalesPrimerNombre ,
                                             string A167ProfesionalesApellidoPrimero ,
                                             long A590Listaid ,
                                             string A975RestriccionesObservacion ,
                                             short AV17OrderedBy ,
                                             bool AV18OrderedDsc ,
                                             string AV86Profesionalesrestriccionwwds_1_filterfulltext )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int4 = new short[34];
         Object[] GXv_Object5 = new Object[2];
         scmdbuf = "SELECT T1.[RestriccionesObservacion], T2.[ListaNombre], T1.[Listaid], T3.[ProfesionalesApellidoPrimero], T3.[ProfesionalesPrimerNombre], T1.[ProfesionalesId], T1.[ProfesionalesRestriccionId], T1.[RestriccionesFechaAlta], T1.[RestriccionesEstado], T2.[ListaTipo], T2.[ListaEstado] FROM (([ProfesionalesRestriccion] T1 INNER JOIN [Lista] T2 ON T2.[Listaid] = T1.[Listaid]) INNER JOIN [Profesionales] T3 ON T3.[ProfesionalesId] = T1.[ProfesionalesId])";
         if ( ( StringUtil.StrCmp(AV87Profesionalesrestriccionwwds_2_dynamicfiltersselector1, "RESTRICCIONESFECHAALTA") == 0 ) && ( AV88Profesionalesrestriccionwwds_3_dynamicfiltersoperator1 == 0 ) && ( ! (DateTime.MinValue==AV89Profesionalesrestriccionwwds_4_restriccionesfechaalta1) ) )
         {
            AddWhere(sWhereString, "(T1.[RestriccionesFechaAlta] < @AV89Profesionalesrestriccionwwds_4_restriccionesfechaalta1)");
         }
         else
         {
            GXv_int4[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV87Profesionalesrestriccionwwds_2_dynamicfiltersselector1, "RESTRICCIONESFECHAALTA") == 0 ) && ( ( AV88Profesionalesrestriccionwwds_3_dynamicfiltersoperator1 == 1 ) || ( AV88Profesionalesrestriccionwwds_3_dynamicfiltersoperator1 == 2 ) || ( AV88Profesionalesrestriccionwwds_3_dynamicfiltersoperator1 == 3 ) ) && ( ! (DateTime.MinValue==AV89Profesionalesrestriccionwwds_4_restriccionesfechaalta1) ) )
         {
            AddWhere(sWhereString, "(T1.[RestriccionesFechaAlta] >= @AV89Profesionalesrestriccionwwds_4_restriccionesfechaalta1)");
         }
         else
         {
            GXv_int4[1] = 1;
         }
         if ( ( StringUtil.StrCmp(AV87Profesionalesrestriccionwwds_2_dynamicfiltersselector1, "RESTRICCIONESFECHAALTA") == 0 ) && ( AV88Profesionalesrestriccionwwds_3_dynamicfiltersoperator1 == 1 ) && ( ! (DateTime.MinValue==AV90Profesionalesrestriccionwwds_5_restriccionesfechaalta_to1) ) )
         {
            AddWhere(sWhereString, "(T1.[RestriccionesFechaAlta] < @AV90Profesionalesrestriccionwwds_5_restriccionesfechaalta_to1)");
         }
         else
         {
            GXv_int4[2] = 1;
         }
         if ( ( StringUtil.StrCmp(AV87Profesionalesrestriccionwwds_2_dynamicfiltersselector1, "RESTRICCIONESFECHAALTA") == 0 ) && ( AV88Profesionalesrestriccionwwds_3_dynamicfiltersoperator1 == 3 ) && ( ! (DateTime.MinValue==AV90Profesionalesrestriccionwwds_5_restriccionesfechaalta_to1) ) )
         {
            AddWhere(sWhereString, "(T1.[RestriccionesFechaAlta] <= @AV90Profesionalesrestriccionwwds_5_restriccionesfechaalta_to1)");
         }
         else
         {
            GXv_int4[3] = 1;
         }
         if ( ( StringUtil.StrCmp(AV87Profesionalesrestriccionwwds_2_dynamicfiltersselector1, "LISTANOMBRE") == 0 ) && ( AV88Profesionalesrestriccionwwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV91Profesionalesrestriccionwwds_6_listanombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ListaNombre]) like UPPER(@lV91Profesionalesrestriccionwwds_6_listanombre1))");
         }
         else
         {
            GXv_int4[4] = 1;
         }
         if ( ( StringUtil.StrCmp(AV87Profesionalesrestriccionwwds_2_dynamicfiltersselector1, "LISTANOMBRE") == 0 ) && ( AV88Profesionalesrestriccionwwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV91Profesionalesrestriccionwwds_6_listanombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ListaNombre]) like '%' + UPPER(@lV91Profesionalesrestriccionwwds_6_listanombre1))");
         }
         else
         {
            GXv_int4[5] = 1;
         }
         if ( AV92Profesionalesrestriccionwwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV93Profesionalesrestriccionwwds_8_dynamicfiltersselector2, "RESTRICCIONESFECHAALTA") == 0 ) && ( AV94Profesionalesrestriccionwwds_9_dynamicfiltersoperator2 == 0 ) && ( ! (DateTime.MinValue==AV95Profesionalesrestriccionwwds_10_restriccionesfechaalta2) ) )
         {
            AddWhere(sWhereString, "(T1.[RestriccionesFechaAlta] < @AV95Profesionalesrestriccionwwds_10_restriccionesfechaalta2)");
         }
         else
         {
            GXv_int4[6] = 1;
         }
         if ( AV92Profesionalesrestriccionwwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV93Profesionalesrestriccionwwds_8_dynamicfiltersselector2, "RESTRICCIONESFECHAALTA") == 0 ) && ( ( AV94Profesionalesrestriccionwwds_9_dynamicfiltersoperator2 == 1 ) || ( AV94Profesionalesrestriccionwwds_9_dynamicfiltersoperator2 == 2 ) || ( AV94Profesionalesrestriccionwwds_9_dynamicfiltersoperator2 == 3 ) ) && ( ! (DateTime.MinValue==AV95Profesionalesrestriccionwwds_10_restriccionesfechaalta2) ) )
         {
            AddWhere(sWhereString, "(T1.[RestriccionesFechaAlta] >= @AV95Profesionalesrestriccionwwds_10_restriccionesfechaalta2)");
         }
         else
         {
            GXv_int4[7] = 1;
         }
         if ( AV92Profesionalesrestriccionwwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV93Profesionalesrestriccionwwds_8_dynamicfiltersselector2, "RESTRICCIONESFECHAALTA") == 0 ) && ( AV94Profesionalesrestriccionwwds_9_dynamicfiltersoperator2 == 1 ) && ( ! (DateTime.MinValue==AV96Profesionalesrestriccionwwds_11_restriccionesfechaalta_to2) ) )
         {
            AddWhere(sWhereString, "(T1.[RestriccionesFechaAlta] < @AV96Profesionalesrestriccionwwds_11_restriccionesfechaalta_to2)");
         }
         else
         {
            GXv_int4[8] = 1;
         }
         if ( AV92Profesionalesrestriccionwwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV93Profesionalesrestriccionwwds_8_dynamicfiltersselector2, "RESTRICCIONESFECHAALTA") == 0 ) && ( AV94Profesionalesrestriccionwwds_9_dynamicfiltersoperator2 == 3 ) && ( ! (DateTime.MinValue==AV96Profesionalesrestriccionwwds_11_restriccionesfechaalta_to2) ) )
         {
            AddWhere(sWhereString, "(T1.[RestriccionesFechaAlta] <= @AV96Profesionalesrestriccionwwds_11_restriccionesfechaalta_to2)");
         }
         else
         {
            GXv_int4[9] = 1;
         }
         if ( AV92Profesionalesrestriccionwwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV93Profesionalesrestriccionwwds_8_dynamicfiltersselector2, "LISTANOMBRE") == 0 ) && ( AV94Profesionalesrestriccionwwds_9_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV97Profesionalesrestriccionwwds_12_listanombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ListaNombre]) like UPPER(@lV97Profesionalesrestriccionwwds_12_listanombre2))");
         }
         else
         {
            GXv_int4[10] = 1;
         }
         if ( AV92Profesionalesrestriccionwwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV93Profesionalesrestriccionwwds_8_dynamicfiltersselector2, "LISTANOMBRE") == 0 ) && ( AV94Profesionalesrestriccionwwds_9_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV97Profesionalesrestriccionwwds_12_listanombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ListaNombre]) like '%' + UPPER(@lV97Profesionalesrestriccionwwds_12_listanombre2))");
         }
         else
         {
            GXv_int4[11] = 1;
         }
         if ( AV98Profesionalesrestriccionwwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV99Profesionalesrestriccionwwds_14_dynamicfiltersselector3, "RESTRICCIONESFECHAALTA") == 0 ) && ( AV100Profesionalesrestriccionwwds_15_dynamicfiltersoperator3 == 0 ) && ( ! (DateTime.MinValue==AV101Profesionalesrestriccionwwds_16_restriccionesfechaalta3) ) )
         {
            AddWhere(sWhereString, "(T1.[RestriccionesFechaAlta] < @AV101Profesionalesrestriccionwwds_16_restriccionesfechaalta3)");
         }
         else
         {
            GXv_int4[12] = 1;
         }
         if ( AV98Profesionalesrestriccionwwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV99Profesionalesrestriccionwwds_14_dynamicfiltersselector3, "RESTRICCIONESFECHAALTA") == 0 ) && ( ( AV100Profesionalesrestriccionwwds_15_dynamicfiltersoperator3 == 1 ) || ( AV100Profesionalesrestriccionwwds_15_dynamicfiltersoperator3 == 2 ) || ( AV100Profesionalesrestriccionwwds_15_dynamicfiltersoperator3 == 3 ) ) && ( ! (DateTime.MinValue==AV101Profesionalesrestriccionwwds_16_restriccionesfechaalta3) ) )
         {
            AddWhere(sWhereString, "(T1.[RestriccionesFechaAlta] >= @AV101Profesionalesrestriccionwwds_16_restriccionesfechaalta3)");
         }
         else
         {
            GXv_int4[13] = 1;
         }
         if ( AV98Profesionalesrestriccionwwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV99Profesionalesrestriccionwwds_14_dynamicfiltersselector3, "RESTRICCIONESFECHAALTA") == 0 ) && ( AV100Profesionalesrestriccionwwds_15_dynamicfiltersoperator3 == 1 ) && ( ! (DateTime.MinValue==AV102Profesionalesrestriccionwwds_17_restriccionesfechaalta_to3) ) )
         {
            AddWhere(sWhereString, "(T1.[RestriccionesFechaAlta] < @AV102Profesionalesrestriccionwwds_17_restriccionesfechaalta_to3)");
         }
         else
         {
            GXv_int4[14] = 1;
         }
         if ( AV98Profesionalesrestriccionwwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV99Profesionalesrestriccionwwds_14_dynamicfiltersselector3, "RESTRICCIONESFECHAALTA") == 0 ) && ( AV100Profesionalesrestriccionwwds_15_dynamicfiltersoperator3 == 3 ) && ( ! (DateTime.MinValue==AV102Profesionalesrestriccionwwds_17_restriccionesfechaalta_to3) ) )
         {
            AddWhere(sWhereString, "(T1.[RestriccionesFechaAlta] <= @AV102Profesionalesrestriccionwwds_17_restriccionesfechaalta_to3)");
         }
         else
         {
            GXv_int4[15] = 1;
         }
         if ( AV98Profesionalesrestriccionwwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV99Profesionalesrestriccionwwds_14_dynamicfiltersselector3, "LISTANOMBRE") == 0 ) && ( AV100Profesionalesrestriccionwwds_15_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV103Profesionalesrestriccionwwds_18_listanombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ListaNombre]) like UPPER(@lV103Profesionalesrestriccionwwds_18_listanombre3))");
         }
         else
         {
            GXv_int4[16] = 1;
         }
         if ( AV98Profesionalesrestriccionwwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV99Profesionalesrestriccionwwds_14_dynamicfiltersselector3, "LISTANOMBRE") == 0 ) && ( AV100Profesionalesrestriccionwwds_15_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV103Profesionalesrestriccionwwds_18_listanombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ListaNombre]) like '%' + UPPER(@lV103Profesionalesrestriccionwwds_18_listanombre3))");
         }
         else
         {
            GXv_int4[17] = 1;
         }
         if ( ! (0==AV104Profesionalesrestriccionwwds_19_tfprofesionalesrestriccionid) )
         {
            AddWhere(sWhereString, "(T1.[ProfesionalesRestriccionId] >= @AV104Profesionalesrestriccionwwds_19_tfprofesionalesrestriccionid)");
         }
         else
         {
            GXv_int4[18] = 1;
         }
         if ( ! (0==AV105Profesionalesrestriccionwwds_20_tfprofesionalesrestriccionid_to) )
         {
            AddWhere(sWhereString, "(T1.[ProfesionalesRestriccionId] <= @AV105Profesionalesrestriccionwwds_20_tfprofesionalesrestriccionid_to)");
         }
         else
         {
            GXv_int4[19] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV107Profesionalesrestriccionwwds_22_tfprofesionalesid_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV106Profesionalesrestriccionwwds_21_tfprofesionalesid)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[ProfesionalesId]) like UPPER(@lV106Profesionalesrestriccionwwds_21_tfprofesionalesid))");
         }
         else
         {
            GXv_int4[20] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV107Profesionalesrestriccionwwds_22_tfprofesionalesid_sel)) && ! ( StringUtil.StrCmp(AV107Profesionalesrestriccionwwds_22_tfprofesionalesid_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[ProfesionalesId] = @AV107Profesionalesrestriccionwwds_22_tfprofesionalesid_sel)");
         }
         else
         {
            GXv_int4[21] = 1;
         }
         if ( StringUtil.StrCmp(AV107Profesionalesrestriccionwwds_22_tfprofesionalesid_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[ProfesionalesId] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV109Profesionalesrestriccionwwds_24_tfprofesionalesprimernombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV108Profesionalesrestriccionwwds_23_tfprofesionalesprimernombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T3.[ProfesionalesPrimerNombre]) like UPPER(@lV108Profesionalesrestriccionwwds_23_tfprofesionalesprimernombre))");
         }
         else
         {
            GXv_int4[22] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV109Profesionalesrestriccionwwds_24_tfprofesionalesprimernombre_sel)) && ! ( StringUtil.StrCmp(AV109Profesionalesrestriccionwwds_24_tfprofesionalesprimernombre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T3.[ProfesionalesPrimerNombre] = @AV109Profesionalesrestriccionwwds_24_tfprofesionalesprimernombre_sel)");
         }
         else
         {
            GXv_int4[23] = 1;
         }
         if ( StringUtil.StrCmp(AV109Profesionalesrestriccionwwds_24_tfprofesionalesprimernombre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T3.[ProfesionalesPrimerNombre] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV111Profesionalesrestriccionwwds_26_tfprofesionalesapellidoprimero_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV110Profesionalesrestriccionwwds_25_tfprofesionalesapellidoprimero)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T3.[ProfesionalesApellidoPrimero]) like UPPER(@lV110Profesionalesrestriccionwwds_25_tfprofesionalesapellidoprimero))");
         }
         else
         {
            GXv_int4[24] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV111Profesionalesrestriccionwwds_26_tfprofesionalesapellidoprimero_sel)) && ! ( StringUtil.StrCmp(AV111Profesionalesrestriccionwwds_26_tfprofesionalesapellidoprimero_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T3.[ProfesionalesApellidoPrimero] = @AV111Profesionalesrestriccionwwds_26_tfprofesionalesapellidoprimero_sel)");
         }
         else
         {
            GXv_int4[25] = 1;
         }
         if ( StringUtil.StrCmp(AV111Profesionalesrestriccionwwds_26_tfprofesionalesapellidoprimero_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T3.[ProfesionalesApellidoPrimero] = ''))");
         }
         if ( ! (0==AV112Profesionalesrestriccionwwds_27_tflistaid) )
         {
            AddWhere(sWhereString, "(T1.[Listaid] >= @AV112Profesionalesrestriccionwwds_27_tflistaid)");
         }
         else
         {
            GXv_int4[26] = 1;
         }
         if ( ! (0==AV113Profesionalesrestriccionwwds_28_tflistaid_to) )
         {
            AddWhere(sWhereString, "(T1.[Listaid] <= @AV113Profesionalesrestriccionwwds_28_tflistaid_to)");
         }
         else
         {
            GXv_int4[27] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV115Profesionalesrestriccionwwds_30_tflistanombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV114Profesionalesrestriccionwwds_29_tflistanombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ListaNombre]) like UPPER(@lV114Profesionalesrestriccionwwds_29_tflistanombre))");
         }
         else
         {
            GXv_int4[28] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV115Profesionalesrestriccionwwds_30_tflistanombre_sel)) && ! ( StringUtil.StrCmp(AV115Profesionalesrestriccionwwds_30_tflistanombre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.[ListaNombre] = @AV115Profesionalesrestriccionwwds_30_tflistanombre_sel)");
         }
         else
         {
            GXv_int4[29] = 1;
         }
         if ( StringUtil.StrCmp(AV115Profesionalesrestriccionwwds_30_tflistanombre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T2.[ListaNombre] = ''))");
         }
         if ( AV116Profesionalesrestriccionwwds_31_tflistaestado_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV116Profesionalesrestriccionwwds_31_tflistaestado_sels, "T2.[ListaEstado] IN (", ")")+")");
         }
         if ( AV117Profesionalesrestriccionwwds_32_tflistatipo_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV117Profesionalesrestriccionwwds_32_tflistatipo_sels, "T2.[ListaTipo] IN (", ")")+")");
         }
         if ( ! (DateTime.MinValue==AV118Profesionalesrestriccionwwds_33_tfrestriccionesfechaalta) )
         {
            AddWhere(sWhereString, "(T1.[RestriccionesFechaAlta] >= @AV118Profesionalesrestriccionwwds_33_tfrestriccionesfechaalta)");
         }
         else
         {
            GXv_int4[30] = 1;
         }
         if ( ! (DateTime.MinValue==AV119Profesionalesrestriccionwwds_34_tfrestriccionesfechaalta_to) )
         {
            AddWhere(sWhereString, "(T1.[RestriccionesFechaAlta] <= @AV119Profesionalesrestriccionwwds_34_tfrestriccionesfechaalta_to)");
         }
         else
         {
            GXv_int4[31] = 1;
         }
         if ( AV120Profesionalesrestriccionwwds_35_tfrestriccionesestado_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV120Profesionalesrestriccionwwds_35_tfrestriccionesestado_sels, "T1.[RestriccionesEstado] IN (", ")")+")");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV122Profesionalesrestriccionwwds_37_tfrestriccionesobservacion_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV121Profesionalesrestriccionwwds_36_tfrestriccionesobservacion)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[RestriccionesObservacion]) like UPPER(@lV121Profesionalesrestriccionwwds_36_tfrestriccionesobservacion))");
         }
         else
         {
            GXv_int4[32] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV122Profesionalesrestriccionwwds_37_tfrestriccionesobservacion_sel)) && ! ( StringUtil.StrCmp(AV122Profesionalesrestriccionwwds_37_tfrestriccionesobservacion_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[RestriccionesObservacion] = @AV122Profesionalesrestriccionwwds_37_tfrestriccionesobservacion_sel)");
         }
         else
         {
            GXv_int4[33] = 1;
         }
         if ( StringUtil.StrCmp(AV122Profesionalesrestriccionwwds_37_tfrestriccionesobservacion_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.[RestriccionesObservacion] IS NULL or (T1.[RestriccionesObservacion] = ''))");
         }
         scmdbuf += sWhereString;
         if ( ( AV17OrderedBy == 1 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[RestriccionesFechaAlta]";
         }
         else if ( ( AV17OrderedBy == 1 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[RestriccionesFechaAlta] DESC";
         }
         else if ( ( AV17OrderedBy == 2 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[ProfesionalesRestriccionId]";
         }
         else if ( ( AV17OrderedBy == 2 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[ProfesionalesRestriccionId] DESC";
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
            scmdbuf += " ORDER BY T3.[ProfesionalesPrimerNombre]";
         }
         else if ( ( AV17OrderedBy == 4 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T3.[ProfesionalesPrimerNombre] DESC";
         }
         else if ( ( AV17OrderedBy == 5 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T3.[ProfesionalesApellidoPrimero]";
         }
         else if ( ( AV17OrderedBy == 5 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T3.[ProfesionalesApellidoPrimero] DESC";
         }
         else if ( ( AV17OrderedBy == 6 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[Listaid]";
         }
         else if ( ( AV17OrderedBy == 6 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[Listaid] DESC";
         }
         else if ( ( AV17OrderedBy == 7 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T2.[ListaNombre]";
         }
         else if ( ( AV17OrderedBy == 7 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T2.[ListaNombre] DESC";
         }
         else if ( ( AV17OrderedBy == 8 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T2.[ListaEstado]";
         }
         else if ( ( AV17OrderedBy == 8 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T2.[ListaEstado] DESC";
         }
         else if ( ( AV17OrderedBy == 9 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T2.[ListaTipo]";
         }
         else if ( ( AV17OrderedBy == 9 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T2.[ListaTipo] DESC";
         }
         else if ( ( AV17OrderedBy == 10 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[RestriccionesEstado]";
         }
         else if ( ( AV17OrderedBy == 10 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[RestriccionesEstado] DESC";
         }
         else if ( ( AV17OrderedBy == 11 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[RestriccionesObservacion]";
         }
         else if ( ( AV17OrderedBy == 11 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[RestriccionesObservacion] DESC";
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
                     return conditional_P00M82(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (GxSimpleCollection<string>)dynConstraints[3] , (string)dynConstraints[4] , (GxSimpleCollection<string>)dynConstraints[5] , (string)dynConstraints[6] , (short)dynConstraints[7] , (DateTime)dynConstraints[8] , (DateTime)dynConstraints[9] , (string)dynConstraints[10] , (bool)dynConstraints[11] , (string)dynConstraints[12] , (short)dynConstraints[13] , (DateTime)dynConstraints[14] , (DateTime)dynConstraints[15] , (string)dynConstraints[16] , (bool)dynConstraints[17] , (string)dynConstraints[18] , (short)dynConstraints[19] , (DateTime)dynConstraints[20] , (DateTime)dynConstraints[21] , (string)dynConstraints[22] , (long)dynConstraints[23] , (long)dynConstraints[24] , (string)dynConstraints[25] , (string)dynConstraints[26] , (string)dynConstraints[27] , (string)dynConstraints[28] , (string)dynConstraints[29] , (string)dynConstraints[30] , (long)dynConstraints[31] , (long)dynConstraints[32] , (string)dynConstraints[33] , (string)dynConstraints[34] , (int)dynConstraints[35] , (int)dynConstraints[36] , (DateTime)dynConstraints[37] , (DateTime)dynConstraints[38] , (int)dynConstraints[39] , (string)dynConstraints[40] , (string)dynConstraints[41] , (DateTime)dynConstraints[42] , (string)dynConstraints[43] , (long)dynConstraints[44] , (string)dynConstraints[45] , (string)dynConstraints[46] , (string)dynConstraints[47] , (long)dynConstraints[48] , (string)dynConstraints[49] , (short)dynConstraints[50] , (bool)dynConstraints[51] , (string)dynConstraints[52] );
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
          Object[] prmP00M82;
          prmP00M82 = new Object[] {
          new ParDef("@AV89Profesionalesrestriccionwwds_4_restriccionesfechaalta1",GXType.DateTime,8,5) ,
          new ParDef("@AV89Profesionalesrestriccionwwds_4_restriccionesfechaalta1",GXType.DateTime,8,5) ,
          new ParDef("@AV90Profesionalesrestriccionwwds_5_restriccionesfechaalta_to1",GXType.DateTime,8,5) ,
          new ParDef("@AV90Profesionalesrestriccionwwds_5_restriccionesfechaalta_to1",GXType.DateTime,8,5) ,
          new ParDef("@lV91Profesionalesrestriccionwwds_6_listanombre1",GXType.Char,80,0) ,
          new ParDef("@lV91Profesionalesrestriccionwwds_6_listanombre1",GXType.Char,80,0) ,
          new ParDef("@AV95Profesionalesrestriccionwwds_10_restriccionesfechaalta2",GXType.DateTime,8,5) ,
          new ParDef("@AV95Profesionalesrestriccionwwds_10_restriccionesfechaalta2",GXType.DateTime,8,5) ,
          new ParDef("@AV96Profesionalesrestriccionwwds_11_restriccionesfechaalta_to2",GXType.DateTime,8,5) ,
          new ParDef("@AV96Profesionalesrestriccionwwds_11_restriccionesfechaalta_to2",GXType.DateTime,8,5) ,
          new ParDef("@lV97Profesionalesrestriccionwwds_12_listanombre2",GXType.Char,80,0) ,
          new ParDef("@lV97Profesionalesrestriccionwwds_12_listanombre2",GXType.Char,80,0) ,
          new ParDef("@AV101Profesionalesrestriccionwwds_16_restriccionesfechaalta3",GXType.DateTime,8,5) ,
          new ParDef("@AV101Profesionalesrestriccionwwds_16_restriccionesfechaalta3",GXType.DateTime,8,5) ,
          new ParDef("@AV102Profesionalesrestriccionwwds_17_restriccionesfechaalta_to3",GXType.DateTime,8,5) ,
          new ParDef("@AV102Profesionalesrestriccionwwds_17_restriccionesfechaalta_to3",GXType.DateTime,8,5) ,
          new ParDef("@lV103Profesionalesrestriccionwwds_18_listanombre3",GXType.Char,80,0) ,
          new ParDef("@lV103Profesionalesrestriccionwwds_18_listanombre3",GXType.Char,80,0) ,
          new ParDef("@AV104Profesionalesrestriccionwwds_19_tfprofesionalesrestriccionid",GXType.Decimal,18,0) ,
          new ParDef("@AV105Profesionalesrestriccionwwds_20_tfprofesionalesrestriccionid_to",GXType.Decimal,18,0) ,
          new ParDef("@lV106Profesionalesrestriccionwwds_21_tfprofesionalesid",GXType.Char,20,0) ,
          new ParDef("@AV107Profesionalesrestriccionwwds_22_tfprofesionalesid_sel",GXType.Char,20,0) ,
          new ParDef("@lV108Profesionalesrestriccionwwds_23_tfprofesionalesprimernombre",GXType.Char,30,0) ,
          new ParDef("@AV109Profesionalesrestriccionwwds_24_tfprofesionalesprimernombre_sel",GXType.NChar,30,0) ,
          new ParDef("@lV110Profesionalesrestriccionwwds_25_tfprofesionalesapellidoprimero",GXType.Char,30,0) ,
          new ParDef("@AV111Profesionalesrestriccionwwds_26_tfprofesionalesapellidoprimero_sel",GXType.NChar,30,0) ,
          new ParDef("@AV112Profesionalesrestriccionwwds_27_tflistaid",GXType.Decimal,18,0) ,
          new ParDef("@AV113Profesionalesrestriccionwwds_28_tflistaid_to",GXType.Decimal,18,0) ,
          new ParDef("@lV114Profesionalesrestriccionwwds_29_tflistanombre",GXType.Char,80,0) ,
          new ParDef("@AV115Profesionalesrestriccionwwds_30_tflistanombre_sel",GXType.NChar,80,0) ,
          new ParDef("@AV118Profesionalesrestriccionwwds_33_tfrestriccionesfechaalta",GXType.DateTime,8,5) ,
          new ParDef("@AV119Profesionalesrestriccionwwds_34_tfrestriccionesfechaalta_to",GXType.DateTime,8,5) ,
          new ParDef("@lV121Profesionalesrestriccionwwds_36_tfrestriccionesobservacion",GXType.VarChar,120,0) ,
          new ParDef("@AV122Profesionalesrestriccionwwds_37_tfrestriccionesobservacion_sel",GXType.NVarChar,120,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00M82", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00M82,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[2])[0] = rslt.getString(2, 80);
                ((long[]) buf[3])[0] = rslt.getLong(3);
                ((string[]) buf[4])[0] = rslt.getString(4, 30);
                ((string[]) buf[5])[0] = rslt.getString(5, 30);
                ((string[]) buf[6])[0] = rslt.getString(6, 20);
                ((long[]) buf[7])[0] = rslt.getLong(7);
                ((DateTime[]) buf[8])[0] = rslt.getGXDateTime(8);
                ((bool[]) buf[9])[0] = rslt.wasNull(8);
                ((string[]) buf[10])[0] = rslt.getString(9, 3);
                ((bool[]) buf[11])[0] = rslt.wasNull(9);
                ((string[]) buf[12])[0] = rslt.getString(10, 4);
                ((string[]) buf[13])[0] = rslt.getString(11, 3);
                ((bool[]) buf[14])[0] = rslt.wasNull(11);
                return;
       }
    }

 }

}

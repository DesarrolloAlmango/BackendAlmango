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
   public class cierreswwexport : GXProcedure
   {
      public cierreswwexport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public cierreswwexport( IGxContext context )
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
         new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWCierres", out  GXt_boolean1) ;
         AV8IsAuthorized = GXt_boolean1;
         if ( ! AV8IsAuthorized )
         {
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "wwpbaseobjects.notauthorized.aspx"+GXUtil.UrlEncode(StringUtil.RTrim(AV58Pgmname));
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
         AV12Filename = GXt_char2 + "CierresWWExport-" + StringUtil.Trim( StringUtil.Str( (decimal)(AV16Random), 8, 0)) + ".xlsx";
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
         if ( AV38GridState.gxTpr_Dynamicfilters.Count >= 1 )
         {
            AV35GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV38GridState.gxTpr_Dynamicfilters.Item(1));
            AV20DynamicFiltersSelector1 = AV35GridStateDynamicFilter.gxTpr_Selected;
            if ( StringUtil.StrCmp(AV20DynamicFiltersSelector1, "CIERRESULTIMAFECHA") == 0 )
            {
               AV21DynamicFiltersOperator1 = AV35GridStateDynamicFilter.gxTpr_Operator;
               AV23CierresUltimaFecha1 = context.localUtil.CToD( AV35GridStateDynamicFilter.gxTpr_Value, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               AV24CierresUltimaFecha_To1 = context.localUtil.CToD( AV35GridStateDynamicFilter.gxTpr_Valueto, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               AV22PrintFilterValue = false;
               if ( ! (DateTime.MinValue==AV23CierresUltimaFecha1) || ! (DateTime.MinValue==AV24CierresUltimaFecha_To1) )
               {
                  AV14CellRow = (int)(AV14CellRow+1);
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Bold = 1;
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Color = 3;
                  if ( AV21DynamicFiltersOperator1 == 0 )
                  {
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = context.GetMessage( "del Cierre", "");
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Italic = 1;
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = context.GetMessage( "WWP_FilterPast", "");
                  }
                  else if ( AV21DynamicFiltersOperator1 == 1 )
                  {
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = context.GetMessage( "del Cierre", "");
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Italic = 1;
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = context.GetMessage( "WWP_FilterToday", "");
                  }
                  else if ( AV21DynamicFiltersOperator1 == 2 )
                  {
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = context.GetMessage( "del Cierre", "");
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Italic = 1;
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = context.GetMessage( "WWP_FilterInTheFuture", "");
                  }
                  else if ( AV21DynamicFiltersOperator1 == 3 )
                  {
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", context.GetMessage( "del Cierre", ""), context.GetMessage( "WWP_FilterRange", ""), "", "", "", "", "", "", "");
                     AV22PrintFilterValue = true;
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+2, 1, 1).Bold = 1;
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+2, 1, 1).Color = 3;
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+2, 1, 1).Text = " - ";
                  }
                  if ( AV22PrintFilterValue )
                  {
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Italic = 1;
                     GXt_dtime4 = DateTimeUtil.ResetTime( AV23CierresUltimaFecha1 ) ;
                     AV11ExcelDocument.SetDateFormat(context, 8, 5, ((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0), DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt")), "/", ":", " ");
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Date = GXt_dtime4;
                     if ( AV22PrintFilterValue )
                     {
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+3, 1, 1).Italic = 1;
                        GXt_dtime4 = DateTimeUtil.ResetTime( AV24CierresUltimaFecha_To1 ) ;
                        AV11ExcelDocument.SetDateFormat(context, 8, 5, ((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0), DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt")), "/", ":", " ");
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+3, 1, 1).Date = GXt_dtime4;
                     }
                  }
               }
            }
            if ( AV38GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV25DynamicFiltersEnabled2 = true;
               AV35GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV38GridState.gxTpr_Dynamicfilters.Item(2));
               AV26DynamicFiltersSelector2 = AV35GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV26DynamicFiltersSelector2, "CIERRESULTIMAFECHA") == 0 )
               {
                  AV27DynamicFiltersOperator2 = AV35GridStateDynamicFilter.gxTpr_Operator;
                  AV28CierresUltimaFecha2 = context.localUtil.CToD( AV35GridStateDynamicFilter.gxTpr_Value, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
                  AV29CierresUltimaFecha_To2 = context.localUtil.CToD( AV35GridStateDynamicFilter.gxTpr_Valueto, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
                  AV22PrintFilterValue = false;
                  if ( ! (DateTime.MinValue==AV28CierresUltimaFecha2) || ! (DateTime.MinValue==AV29CierresUltimaFecha_To2) )
                  {
                     AV14CellRow = (int)(AV14CellRow+1);
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Bold = 1;
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Color = 3;
                     if ( AV27DynamicFiltersOperator2 == 0 )
                     {
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = context.GetMessage( "del Cierre", "");
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Italic = 1;
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = context.GetMessage( "WWP_FilterPast", "");
                     }
                     else if ( AV27DynamicFiltersOperator2 == 1 )
                     {
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = context.GetMessage( "del Cierre", "");
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Italic = 1;
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = context.GetMessage( "WWP_FilterToday", "");
                     }
                     else if ( AV27DynamicFiltersOperator2 == 2 )
                     {
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = context.GetMessage( "del Cierre", "");
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Italic = 1;
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = context.GetMessage( "WWP_FilterInTheFuture", "");
                     }
                     else if ( AV27DynamicFiltersOperator2 == 3 )
                     {
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", context.GetMessage( "del Cierre", ""), context.GetMessage( "WWP_FilterRange", ""), "", "", "", "", "", "", "");
                        AV22PrintFilterValue = true;
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+2, 1, 1).Bold = 1;
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+2, 1, 1).Color = 3;
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+2, 1, 1).Text = " - ";
                     }
                     if ( AV22PrintFilterValue )
                     {
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Italic = 1;
                        GXt_dtime4 = DateTimeUtil.ResetTime( AV28CierresUltimaFecha2 ) ;
                        AV11ExcelDocument.SetDateFormat(context, 8, 5, ((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0), DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt")), "/", ":", " ");
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Date = GXt_dtime4;
                        if ( AV22PrintFilterValue )
                        {
                           AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+3, 1, 1).Italic = 1;
                           GXt_dtime4 = DateTimeUtil.ResetTime( AV29CierresUltimaFecha_To2 ) ;
                           AV11ExcelDocument.SetDateFormat(context, 8, 5, ((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0), DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt")), "/", ":", " ");
                           AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+3, 1, 1).Date = GXt_dtime4;
                        }
                     }
                  }
               }
               if ( AV38GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV30DynamicFiltersEnabled3 = true;
                  AV35GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV38GridState.gxTpr_Dynamicfilters.Item(3));
                  AV31DynamicFiltersSelector3 = AV35GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV31DynamicFiltersSelector3, "CIERRESULTIMAFECHA") == 0 )
                  {
                     AV32DynamicFiltersOperator3 = AV35GridStateDynamicFilter.gxTpr_Operator;
                     AV33CierresUltimaFecha3 = context.localUtil.CToD( AV35GridStateDynamicFilter.gxTpr_Value, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
                     AV34CierresUltimaFecha_To3 = context.localUtil.CToD( AV35GridStateDynamicFilter.gxTpr_Valueto, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
                     AV22PrintFilterValue = false;
                     if ( ! (DateTime.MinValue==AV33CierresUltimaFecha3) || ! (DateTime.MinValue==AV34CierresUltimaFecha_To3) )
                     {
                        AV14CellRow = (int)(AV14CellRow+1);
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Bold = 1;
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Color = 3;
                        if ( AV32DynamicFiltersOperator3 == 0 )
                        {
                           AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = context.GetMessage( "del Cierre", "");
                           AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Italic = 1;
                           AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = context.GetMessage( "WWP_FilterPast", "");
                        }
                        else if ( AV32DynamicFiltersOperator3 == 1 )
                        {
                           AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = context.GetMessage( "del Cierre", "");
                           AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Italic = 1;
                           AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = context.GetMessage( "WWP_FilterToday", "");
                        }
                        else if ( AV32DynamicFiltersOperator3 == 2 )
                        {
                           AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = context.GetMessage( "del Cierre", "");
                           AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Italic = 1;
                           AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = context.GetMessage( "WWP_FilterInTheFuture", "");
                        }
                        else if ( AV32DynamicFiltersOperator3 == 3 )
                        {
                           AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", context.GetMessage( "del Cierre", ""), context.GetMessage( "WWP_FilterRange", ""), "", "", "", "", "", "", "");
                           AV22PrintFilterValue = true;
                           AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+2, 1, 1).Bold = 1;
                           AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+2, 1, 1).Color = 3;
                           AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+2, 1, 1).Text = " - ";
                        }
                        if ( AV22PrintFilterValue )
                        {
                           AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Italic = 1;
                           GXt_dtime4 = DateTimeUtil.ResetTime( AV33CierresUltimaFecha3 ) ;
                           AV11ExcelDocument.SetDateFormat(context, 8, 5, ((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0), DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt")), "/", ":", " ");
                           AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Date = GXt_dtime4;
                           if ( AV22PrintFilterValue )
                           {
                              AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+3, 1, 1).Italic = 1;
                              GXt_dtime4 = DateTimeUtil.ResetTime( AV34CierresUltimaFecha_To3 ) ;
                              AV11ExcelDocument.SetDateFormat(context, 8, 5, ((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0), DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt")), "/", ":", " ");
                              AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+3, 1, 1).Date = GXt_dtime4;
                           }
                        }
                     }
                  }
               }
            }
         }
         if ( ! ( (0==AV51TFCierresId) && (0==AV52TFCierresId_To) ) )
         {
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Id", "")) ;
            AV14CellRow = GXt_int3;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Number = AV51TFCierresId;
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  false, ref  GXt_int3,  (short)(AV15FirstColumn+2),  context.GetMessage( "WWP_TSTo", "")) ;
            AV14CellRow = GXt_int3;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+3, 1, 1).Number = AV52TFCierresId_To;
         }
         if ( ! ( (DateTime.MinValue==AV53TFCierresUltimaFecha) && (DateTime.MinValue==AV54TFCierresUltimaFecha_To) ) )
         {
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "del Cierre", "")) ;
            AV14CellRow = GXt_int3;
            GXt_dtime4 = DateTimeUtil.ResetTime( AV53TFCierresUltimaFecha ) ;
            AV11ExcelDocument.SetDateFormat(context, 8, 5, ((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0), DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt")), "/", ":", " ");
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Date = GXt_dtime4;
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  false, ref  GXt_int3,  (short)(AV15FirstColumn+2),  context.GetMessage( "WWP_TSTo", "")) ;
            AV14CellRow = GXt_int3;
            GXt_dtime4 = DateTimeUtil.ResetTime( AV54TFCierresUltimaFecha_To ) ;
            AV11ExcelDocument.SetDateFormat(context, 8, 5, ((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0), DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt")), "/", ":", " ");
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+3, 1, 1).Date = GXt_dtime4;
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV56TFCierresUsuario_Sel)) ) )
         {
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "de Cierre", "")) ;
            AV14CellRow = GXt_int3;
            GXt_char2 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV56TFCierresUsuario_Sel)) ? context.GetMessage( "WWP_TitleFilter_EmptyOption", "") : AV56TFCierresUsuario_Sel), out  GXt_char2) ;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV55TFCierresUsuario)) ) )
            {
               GXt_int3 = (short)(AV14CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "de Cierre", "")) ;
               AV14CellRow = GXt_int3;
               GXt_char2 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV55TFCierresUsuario, out  GXt_char2) ;
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
            }
         }
         AV14CellRow = (int)(AV14CellRow+2);
      }

      protected void S141( )
      {
         /* 'WRITECOLUMNTITLES' Routine */
         returnInSub = false;
         AV48VisibleColumnCount = 0;
         if ( StringUtil.StrCmp(AV36Session.Get("CierresWWColumnsSelector"), "") != 0 )
         {
            AV43ColumnsSelectorXML = AV36Session.Get("CierresWWColumnsSelector");
            AV40ColumnsSelector.FromXml(AV43ColumnsSelectorXML, null, "", "");
         }
         else
         {
            /* Execute user subroutine: 'INITIALIZECOLUMNSSELECTOR' */
            S151 ();
            if (returnInSub) return;
         }
         AV40ColumnsSelector.gxTpr_Columns.Sort("Order");
         AV59GXV1 = 1;
         while ( AV59GXV1 <= AV40ColumnsSelector.gxTpr_Columns.Count )
         {
            AV42ColumnsSelector_Column = ((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV40ColumnsSelector.gxTpr_Columns.Item(AV59GXV1));
            if ( AV42ColumnsSelector_Column.gxTpr_Isvisible )
            {
               AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV48VisibleColumnCount), 1, 1).Text = context.GetMessage( (String.IsNullOrEmpty(StringUtil.RTrim( AV42ColumnsSelector_Column.gxTpr_Displayname)) ? AV42ColumnsSelector_Column.gxTpr_Columnname : AV42ColumnsSelector_Column.gxTpr_Displayname), "");
               AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV48VisibleColumnCount), 1, 1).Bold = 1;
               AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV48VisibleColumnCount), 1, 1).Color = 11;
               AV48VisibleColumnCount = (long)(AV48VisibleColumnCount+1);
            }
            AV59GXV1 = (int)(AV59GXV1+1);
         }
      }

      protected void S161( )
      {
         /* 'WRITEDATA' Routine */
         returnInSub = false;
         AV61Cierreswwds_1_filterfulltext = AV19FilterFullText;
         AV62Cierreswwds_2_dynamicfiltersselector1 = AV20DynamicFiltersSelector1;
         AV63Cierreswwds_3_dynamicfiltersoperator1 = AV21DynamicFiltersOperator1;
         AV64Cierreswwds_4_cierresultimafecha1 = AV23CierresUltimaFecha1;
         AV65Cierreswwds_5_cierresultimafecha_to1 = AV24CierresUltimaFecha_To1;
         AV66Cierreswwds_6_dynamicfiltersenabled2 = AV25DynamicFiltersEnabled2;
         AV67Cierreswwds_7_dynamicfiltersselector2 = AV26DynamicFiltersSelector2;
         AV68Cierreswwds_8_dynamicfiltersoperator2 = AV27DynamicFiltersOperator2;
         AV69Cierreswwds_9_cierresultimafecha2 = AV28CierresUltimaFecha2;
         AV70Cierreswwds_10_cierresultimafecha_to2 = AV29CierresUltimaFecha_To2;
         AV71Cierreswwds_11_dynamicfiltersenabled3 = AV30DynamicFiltersEnabled3;
         AV72Cierreswwds_12_dynamicfiltersselector3 = AV31DynamicFiltersSelector3;
         AV73Cierreswwds_13_dynamicfiltersoperator3 = AV32DynamicFiltersOperator3;
         AV74Cierreswwds_14_cierresultimafecha3 = AV33CierresUltimaFecha3;
         AV75Cierreswwds_15_cierresultimafecha_to3 = AV34CierresUltimaFecha_To3;
         AV76Cierreswwds_16_tfcierresid = AV51TFCierresId;
         AV77Cierreswwds_17_tfcierresid_to = AV52TFCierresId_To;
         AV78Cierreswwds_18_tfcierresultimafecha = AV53TFCierresUltimaFecha;
         AV79Cierreswwds_19_tfcierresultimafecha_to = AV54TFCierresUltimaFecha_To;
         AV80Cierreswwds_20_tfcierresusuario = AV55TFCierresUsuario;
         AV81Cierreswwds_21_tfcierresusuario_sel = AV56TFCierresUsuario_Sel;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV61Cierreswwds_1_filterfulltext ,
                                              AV62Cierreswwds_2_dynamicfiltersselector1 ,
                                              AV63Cierreswwds_3_dynamicfiltersoperator1 ,
                                              AV64Cierreswwds_4_cierresultimafecha1 ,
                                              AV65Cierreswwds_5_cierresultimafecha_to1 ,
                                              AV66Cierreswwds_6_dynamicfiltersenabled2 ,
                                              AV67Cierreswwds_7_dynamicfiltersselector2 ,
                                              AV68Cierreswwds_8_dynamicfiltersoperator2 ,
                                              AV69Cierreswwds_9_cierresultimafecha2 ,
                                              AV70Cierreswwds_10_cierresultimafecha_to2 ,
                                              AV71Cierreswwds_11_dynamicfiltersenabled3 ,
                                              AV72Cierreswwds_12_dynamicfiltersselector3 ,
                                              AV73Cierreswwds_13_dynamicfiltersoperator3 ,
                                              AV74Cierreswwds_14_cierresultimafecha3 ,
                                              AV75Cierreswwds_15_cierresultimafecha_to3 ,
                                              AV76Cierreswwds_16_tfcierresid ,
                                              AV77Cierreswwds_17_tfcierresid_to ,
                                              AV78Cierreswwds_18_tfcierresultimafecha ,
                                              AV79Cierreswwds_19_tfcierresultimafecha_to ,
                                              AV81Cierreswwds_21_tfcierresusuario_sel ,
                                              AV80Cierreswwds_20_tfcierresusuario ,
                                              A155CierresId ,
                                              A314CierresUsuario ,
                                              A313CierresUltimaFecha ,
                                              AV17OrderedBy ,
                                              AV18OrderedDsc } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.DATE,
                                              TypeConstants.DATE, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.LONG, TypeConstants.DATE, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV61Cierreswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV61Cierreswwds_1_filterfulltext), "%", "");
         lV61Cierreswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV61Cierreswwds_1_filterfulltext), "%", "");
         lV80Cierreswwds_20_tfcierresusuario = StringUtil.PadR( StringUtil.RTrim( AV80Cierreswwds_20_tfcierresusuario), 30, "%");
         /* Using cursor P00J02 */
         pr_default.execute(0, new Object[] {lV61Cierreswwds_1_filterfulltext, lV61Cierreswwds_1_filterfulltext, AV64Cierreswwds_4_cierresultimafecha1, AV64Cierreswwds_4_cierresultimafecha1, AV64Cierreswwds_4_cierresultimafecha1, AV64Cierreswwds_4_cierresultimafecha1, AV65Cierreswwds_5_cierresultimafecha_to1, AV69Cierreswwds_9_cierresultimafecha2, AV69Cierreswwds_9_cierresultimafecha2, AV69Cierreswwds_9_cierresultimafecha2, AV69Cierreswwds_9_cierresultimafecha2, AV70Cierreswwds_10_cierresultimafecha_to2, AV74Cierreswwds_14_cierresultimafecha3, AV74Cierreswwds_14_cierresultimafecha3, AV74Cierreswwds_14_cierresultimafecha3, AV74Cierreswwds_14_cierresultimafecha3, AV75Cierreswwds_15_cierresultimafecha_to3, AV76Cierreswwds_16_tfcierresid, AV77Cierreswwds_17_tfcierresid_to, AV78Cierreswwds_18_tfcierresultimafecha, AV79Cierreswwds_19_tfcierresultimafecha_to, lV80Cierreswwds_20_tfcierresusuario, AV81Cierreswwds_21_tfcierresusuario_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A314CierresUsuario = P00J02_A314CierresUsuario[0];
            A155CierresId = P00J02_A155CierresId[0];
            A313CierresUltimaFecha = P00J02_A313CierresUltimaFecha[0];
            AV14CellRow = (int)(AV14CellRow+1);
            /* Execute user subroutine: 'BEFOREWRITELINE' */
            S172 ();
            if ( returnInSub )
            {
               pr_default.close(0);
               returnInSub = true;
               if (true) return;
            }
            AV48VisibleColumnCount = 0;
            AV82GXV2 = 1;
            while ( AV82GXV2 <= AV40ColumnsSelector.gxTpr_Columns.Count )
            {
               AV42ColumnsSelector_Column = ((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV40ColumnsSelector.gxTpr_Columns.Item(AV82GXV2));
               if ( AV42ColumnsSelector_Column.gxTpr_Isvisible )
               {
                  if ( StringUtil.StrCmp(AV42ColumnsSelector_Column.gxTpr_Columnname, "CierresId") == 0 )
                  {
                     AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV48VisibleColumnCount), 1, 1).Number = A155CierresId;
                  }
                  else if ( StringUtil.StrCmp(AV42ColumnsSelector_Column.gxTpr_Columnname, "CierresUltimaFecha") == 0 )
                  {
                     GXt_dtime4 = DateTimeUtil.ResetTime( A313CierresUltimaFecha ) ;
                     AV11ExcelDocument.SetDateFormat(context, 8, 5, ((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0), DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt")), "/", ":", " ");
                     AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV48VisibleColumnCount), 1, 1).Date = GXt_dtime4;
                  }
                  else if ( StringUtil.StrCmp(AV42ColumnsSelector_Column.gxTpr_Columnname, "CierresUsuario") == 0 )
                  {
                     GXt_char2 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A314CierresUsuario, out  GXt_char2) ;
                     AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV48VisibleColumnCount), 1, 1).Text = GXt_char2;
                  }
                  AV48VisibleColumnCount = (long)(AV48VisibleColumnCount+1);
               }
               AV82GXV2 = (int)(AV82GXV2+1);
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
         AV36Session.Set("WWPExportFilePath", AV12Filename);
         AV36Session.Set("WWPExportFileName", "CierresWWExport.xlsx");
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
         AV40ColumnsSelector = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector(context);
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV40ColumnsSelector,  "CierresId",  "",  "Id",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV40ColumnsSelector,  "CierresUltimaFecha",  "",  "del Cierre",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV40ColumnsSelector,  "CierresUsuario",  "",  "de Cierre",  true,  "") ;
         GXt_char2 = AV44UserCustomValue;
         new GeneXus.Programs.wwpbaseobjects.loadcolumnsselectorstate(context ).execute(  "CierresWWColumnsSelector", out  GXt_char2) ;
         AV44UserCustomValue = GXt_char2;
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV44UserCustomValue)) ) )
         {
            AV41ColumnsSelectorAux.FromXml(AV44UserCustomValue, null, "", "");
            new GeneXus.Programs.wwpbaseobjects.wwp_columnselector_updatecolumns(context ).execute( ref  AV41ColumnsSelectorAux, ref  AV40ColumnsSelector) ;
         }
      }

      protected void S201( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV36Session.Get("CierresWWGridState"), "") == 0 )
         {
            AV38GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "CierresWWGridState"), null, "", "");
         }
         else
         {
            AV38GridState.FromXml(AV36Session.Get("CierresWWGridState"), null, "", "");
         }
         AV17OrderedBy = AV38GridState.gxTpr_Orderedby;
         AV18OrderedDsc = AV38GridState.gxTpr_Ordereddsc;
         AV83GXV3 = 1;
         while ( AV83GXV3 <= AV38GridState.gxTpr_Filtervalues.Count )
         {
            AV39GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV38GridState.gxTpr_Filtervalues.Item(AV83GXV3));
            if ( StringUtil.StrCmp(AV39GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV19FilterFullText = AV39GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV39GridStateFilterValue.gxTpr_Name, "TFCIERRESID") == 0 )
            {
               AV51TFCierresId = (long)(Math.Round(NumberUtil.Val( AV39GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV52TFCierresId_To = (long)(Math.Round(NumberUtil.Val( AV39GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV39GridStateFilterValue.gxTpr_Name, "TFCIERRESULTIMAFECHA") == 0 )
            {
               AV53TFCierresUltimaFecha = context.localUtil.CToD( AV39GridStateFilterValue.gxTpr_Value, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               AV54TFCierresUltimaFecha_To = context.localUtil.CToD( AV39GridStateFilterValue.gxTpr_Valueto, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
            }
            else if ( StringUtil.StrCmp(AV39GridStateFilterValue.gxTpr_Name, "TFCIERRESUSUARIO") == 0 )
            {
               AV55TFCierresUsuario = AV39GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV39GridStateFilterValue.gxTpr_Name, "TFCIERRESUSUARIO_SEL") == 0 )
            {
               AV56TFCierresUsuario_Sel = AV39GridStateFilterValue.gxTpr_Value;
            }
            AV83GXV3 = (int)(AV83GXV3+1);
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
         AV58Pgmname = "";
         GXKey = "";
         GXEncryptionTmp = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV11ExcelDocument = new ExcelDocumentI();
         AV19FilterFullText = "";
         AV38GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV35GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV20DynamicFiltersSelector1 = "";
         AV23CierresUltimaFecha1 = DateTime.MinValue;
         AV24CierresUltimaFecha_To1 = DateTime.MinValue;
         AV26DynamicFiltersSelector2 = "";
         AV28CierresUltimaFecha2 = DateTime.MinValue;
         AV29CierresUltimaFecha_To2 = DateTime.MinValue;
         AV31DynamicFiltersSelector3 = "";
         AV33CierresUltimaFecha3 = DateTime.MinValue;
         AV34CierresUltimaFecha_To3 = DateTime.MinValue;
         AV53TFCierresUltimaFecha = DateTime.MinValue;
         AV54TFCierresUltimaFecha_To = DateTime.MinValue;
         AV56TFCierresUsuario_Sel = "";
         AV55TFCierresUsuario = "";
         AV36Session = context.GetSession();
         AV43ColumnsSelectorXML = "";
         AV40ColumnsSelector = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector(context);
         AV42ColumnsSelector_Column = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column(context);
         AV61Cierreswwds_1_filterfulltext = "";
         AV62Cierreswwds_2_dynamicfiltersselector1 = "";
         AV64Cierreswwds_4_cierresultimafecha1 = DateTime.MinValue;
         AV65Cierreswwds_5_cierresultimafecha_to1 = DateTime.MinValue;
         AV67Cierreswwds_7_dynamicfiltersselector2 = "";
         AV69Cierreswwds_9_cierresultimafecha2 = DateTime.MinValue;
         AV70Cierreswwds_10_cierresultimafecha_to2 = DateTime.MinValue;
         AV72Cierreswwds_12_dynamicfiltersselector3 = "";
         AV74Cierreswwds_14_cierresultimafecha3 = DateTime.MinValue;
         AV75Cierreswwds_15_cierresultimafecha_to3 = DateTime.MinValue;
         AV78Cierreswwds_18_tfcierresultimafecha = DateTime.MinValue;
         AV79Cierreswwds_19_tfcierresultimafecha_to = DateTime.MinValue;
         AV80Cierreswwds_20_tfcierresusuario = "";
         AV81Cierreswwds_21_tfcierresusuario_sel = "";
         lV61Cierreswwds_1_filterfulltext = "";
         lV80Cierreswwds_20_tfcierresusuario = "";
         A314CierresUsuario = "";
         A313CierresUltimaFecha = DateTime.MinValue;
         P00J02_A314CierresUsuario = new string[] {""} ;
         P00J02_A155CierresId = new long[1] ;
         P00J02_A313CierresUltimaFecha = new DateTime[] {DateTime.MinValue} ;
         GXt_dtime4 = (DateTime)(DateTime.MinValue);
         AV44UserCustomValue = "";
         GXt_char2 = "";
         AV41ColumnsSelectorAux = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector(context);
         AV39GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.cierreswwexport__default(),
            new Object[][] {
                new Object[] {
               P00J02_A314CierresUsuario, P00J02_A155CierresId, P00J02_A313CierresUltimaFecha
               }
            }
         );
         AV58Pgmname = "CierresWWExport";
         /* GeneXus formulas. */
         AV58Pgmname = "CierresWWExport";
      }

      private short AV21DynamicFiltersOperator1 ;
      private short AV27DynamicFiltersOperator2 ;
      private short AV32DynamicFiltersOperator3 ;
      private short GXt_int3 ;
      private short AV63Cierreswwds_3_dynamicfiltersoperator1 ;
      private short AV68Cierreswwds_8_dynamicfiltersoperator2 ;
      private short AV73Cierreswwds_13_dynamicfiltersoperator3 ;
      private short AV17OrderedBy ;
      private int AV14CellRow ;
      private int AV15FirstColumn ;
      private int AV16Random ;
      private int AV59GXV1 ;
      private int AV82GXV2 ;
      private int AV83GXV3 ;
      private long AV51TFCierresId ;
      private long AV52TFCierresId_To ;
      private long AV48VisibleColumnCount ;
      private long AV76Cierreswwds_16_tfcierresid ;
      private long AV77Cierreswwds_17_tfcierresid_to ;
      private long A155CierresId ;
      private string AV58Pgmname ;
      private string GXKey ;
      private string GXEncryptionTmp ;
      private string AV56TFCierresUsuario_Sel ;
      private string AV55TFCierresUsuario ;
      private string AV80Cierreswwds_20_tfcierresusuario ;
      private string AV81Cierreswwds_21_tfcierresusuario_sel ;
      private string lV80Cierreswwds_20_tfcierresusuario ;
      private string A314CierresUsuario ;
      private string GXt_char2 ;
      private DateTime GXt_dtime4 ;
      private DateTime AV23CierresUltimaFecha1 ;
      private DateTime AV24CierresUltimaFecha_To1 ;
      private DateTime AV28CierresUltimaFecha2 ;
      private DateTime AV29CierresUltimaFecha_To2 ;
      private DateTime AV33CierresUltimaFecha3 ;
      private DateTime AV34CierresUltimaFecha_To3 ;
      private DateTime AV53TFCierresUltimaFecha ;
      private DateTime AV54TFCierresUltimaFecha_To ;
      private DateTime AV64Cierreswwds_4_cierresultimafecha1 ;
      private DateTime AV65Cierreswwds_5_cierresultimafecha_to1 ;
      private DateTime AV69Cierreswwds_9_cierresultimafecha2 ;
      private DateTime AV70Cierreswwds_10_cierresultimafecha_to2 ;
      private DateTime AV74Cierreswwds_14_cierresultimafecha3 ;
      private DateTime AV75Cierreswwds_15_cierresultimafecha_to3 ;
      private DateTime AV78Cierreswwds_18_tfcierresultimafecha ;
      private DateTime AV79Cierreswwds_19_tfcierresultimafecha_to ;
      private DateTime A313CierresUltimaFecha ;
      private bool AV8IsAuthorized ;
      private bool GXt_boolean1 ;
      private bool returnInSub ;
      private bool AV22PrintFilterValue ;
      private bool AV25DynamicFiltersEnabled2 ;
      private bool AV30DynamicFiltersEnabled3 ;
      private bool AV66Cierreswwds_6_dynamicfiltersenabled2 ;
      private bool AV71Cierreswwds_11_dynamicfiltersenabled3 ;
      private bool AV18OrderedDsc ;
      private string AV43ColumnsSelectorXML ;
      private string AV44UserCustomValue ;
      private string AV12Filename ;
      private string AV13ErrorMessage ;
      private string AV19FilterFullText ;
      private string AV20DynamicFiltersSelector1 ;
      private string AV26DynamicFiltersSelector2 ;
      private string AV31DynamicFiltersSelector3 ;
      private string AV61Cierreswwds_1_filterfulltext ;
      private string AV62Cierreswwds_2_dynamicfiltersselector1 ;
      private string AV67Cierreswwds_7_dynamicfiltersselector2 ;
      private string AV72Cierreswwds_12_dynamicfiltersselector3 ;
      private string lV61Cierreswwds_1_filterfulltext ;
      private IGxSession AV36Session ;
      private ExcelDocumentI AV11ExcelDocument ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV38GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV35GridStateDynamicFilter ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector AV40ColumnsSelector ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column AV42ColumnsSelector_Column ;
      private IDataStoreProvider pr_default ;
      private string[] P00J02_A314CierresUsuario ;
      private long[] P00J02_A155CierresId ;
      private DateTime[] P00J02_A313CierresUltimaFecha ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector AV41ColumnsSelectorAux ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV39GridStateFilterValue ;
      private string aP0_Filename ;
      private string aP1_ErrorMessage ;
   }

   public class cierreswwexport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00J02( IGxContext context ,
                                             string AV61Cierreswwds_1_filterfulltext ,
                                             string AV62Cierreswwds_2_dynamicfiltersselector1 ,
                                             short AV63Cierreswwds_3_dynamicfiltersoperator1 ,
                                             DateTime AV64Cierreswwds_4_cierresultimafecha1 ,
                                             DateTime AV65Cierreswwds_5_cierresultimafecha_to1 ,
                                             bool AV66Cierreswwds_6_dynamicfiltersenabled2 ,
                                             string AV67Cierreswwds_7_dynamicfiltersselector2 ,
                                             short AV68Cierreswwds_8_dynamicfiltersoperator2 ,
                                             DateTime AV69Cierreswwds_9_cierresultimafecha2 ,
                                             DateTime AV70Cierreswwds_10_cierresultimafecha_to2 ,
                                             bool AV71Cierreswwds_11_dynamicfiltersenabled3 ,
                                             string AV72Cierreswwds_12_dynamicfiltersselector3 ,
                                             short AV73Cierreswwds_13_dynamicfiltersoperator3 ,
                                             DateTime AV74Cierreswwds_14_cierresultimafecha3 ,
                                             DateTime AV75Cierreswwds_15_cierresultimafecha_to3 ,
                                             long AV76Cierreswwds_16_tfcierresid ,
                                             long AV77Cierreswwds_17_tfcierresid_to ,
                                             DateTime AV78Cierreswwds_18_tfcierresultimafecha ,
                                             DateTime AV79Cierreswwds_19_tfcierresultimafecha_to ,
                                             string AV81Cierreswwds_21_tfcierresusuario_sel ,
                                             string AV80Cierreswwds_20_tfcierresusuario ,
                                             long A155CierresId ,
                                             string A314CierresUsuario ,
                                             DateTime A313CierresUltimaFecha ,
                                             short AV17OrderedBy ,
                                             bool AV18OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int5 = new short[23];
         Object[] GXv_Object6 = new Object[2];
         scmdbuf = "SELECT [CierresUsuario], [CierresId], [CierresUltimaFecha] FROM [Cierres]";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Cierreswwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( CONVERT( char(18), CAST([CierresId] AS decimal(18,0))) like '%' + @lV61Cierreswwds_1_filterfulltext) or ( UPPER([CierresUsuario]) like '%' + UPPER(@lV61Cierreswwds_1_filterfulltext)))");
         }
         else
         {
            GXv_int5[0] = 1;
            GXv_int5[1] = 1;
         }
         if ( ( StringUtil.StrCmp(AV62Cierreswwds_2_dynamicfiltersselector1, "CIERRESULTIMAFECHA") == 0 ) && ( AV63Cierreswwds_3_dynamicfiltersoperator1 == 0 ) && ( ! (DateTime.MinValue==AV64Cierreswwds_4_cierresultimafecha1) ) )
         {
            AddWhere(sWhereString, "([CierresUltimaFecha] < @AV64Cierreswwds_4_cierresultimafecha1)");
         }
         else
         {
            GXv_int5[2] = 1;
         }
         if ( ( StringUtil.StrCmp(AV62Cierreswwds_2_dynamicfiltersselector1, "CIERRESULTIMAFECHA") == 0 ) && ( AV63Cierreswwds_3_dynamicfiltersoperator1 == 1 ) && ( ! (DateTime.MinValue==AV64Cierreswwds_4_cierresultimafecha1) ) )
         {
            AddWhere(sWhereString, "([CierresUltimaFecha] = @AV64Cierreswwds_4_cierresultimafecha1)");
         }
         else
         {
            GXv_int5[3] = 1;
         }
         if ( ( StringUtil.StrCmp(AV62Cierreswwds_2_dynamicfiltersselector1, "CIERRESULTIMAFECHA") == 0 ) && ( AV63Cierreswwds_3_dynamicfiltersoperator1 == 2 ) && ( ! (DateTime.MinValue==AV64Cierreswwds_4_cierresultimafecha1) ) )
         {
            AddWhere(sWhereString, "([CierresUltimaFecha] > @AV64Cierreswwds_4_cierresultimafecha1)");
         }
         else
         {
            GXv_int5[4] = 1;
         }
         if ( ( StringUtil.StrCmp(AV62Cierreswwds_2_dynamicfiltersselector1, "CIERRESULTIMAFECHA") == 0 ) && ( AV63Cierreswwds_3_dynamicfiltersoperator1 == 3 ) && ( ! (DateTime.MinValue==AV64Cierreswwds_4_cierresultimafecha1) ) )
         {
            AddWhere(sWhereString, "([CierresUltimaFecha] >= @AV64Cierreswwds_4_cierresultimafecha1)");
         }
         else
         {
            GXv_int5[5] = 1;
         }
         if ( ( StringUtil.StrCmp(AV62Cierreswwds_2_dynamicfiltersselector1, "CIERRESULTIMAFECHA") == 0 ) && ( AV63Cierreswwds_3_dynamicfiltersoperator1 == 3 ) && ( ! (DateTime.MinValue==AV65Cierreswwds_5_cierresultimafecha_to1) ) )
         {
            AddWhere(sWhereString, "([CierresUltimaFecha] <= @AV65Cierreswwds_5_cierresultimafecha_to1)");
         }
         else
         {
            GXv_int5[6] = 1;
         }
         if ( AV66Cierreswwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV67Cierreswwds_7_dynamicfiltersselector2, "CIERRESULTIMAFECHA") == 0 ) && ( AV68Cierreswwds_8_dynamicfiltersoperator2 == 0 ) && ( ! (DateTime.MinValue==AV69Cierreswwds_9_cierresultimafecha2) ) )
         {
            AddWhere(sWhereString, "([CierresUltimaFecha] < @AV69Cierreswwds_9_cierresultimafecha2)");
         }
         else
         {
            GXv_int5[7] = 1;
         }
         if ( AV66Cierreswwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV67Cierreswwds_7_dynamicfiltersselector2, "CIERRESULTIMAFECHA") == 0 ) && ( AV68Cierreswwds_8_dynamicfiltersoperator2 == 1 ) && ( ! (DateTime.MinValue==AV69Cierreswwds_9_cierresultimafecha2) ) )
         {
            AddWhere(sWhereString, "([CierresUltimaFecha] = @AV69Cierreswwds_9_cierresultimafecha2)");
         }
         else
         {
            GXv_int5[8] = 1;
         }
         if ( AV66Cierreswwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV67Cierreswwds_7_dynamicfiltersselector2, "CIERRESULTIMAFECHA") == 0 ) && ( AV68Cierreswwds_8_dynamicfiltersoperator2 == 2 ) && ( ! (DateTime.MinValue==AV69Cierreswwds_9_cierresultimafecha2) ) )
         {
            AddWhere(sWhereString, "([CierresUltimaFecha] > @AV69Cierreswwds_9_cierresultimafecha2)");
         }
         else
         {
            GXv_int5[9] = 1;
         }
         if ( AV66Cierreswwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV67Cierreswwds_7_dynamicfiltersselector2, "CIERRESULTIMAFECHA") == 0 ) && ( AV68Cierreswwds_8_dynamicfiltersoperator2 == 3 ) && ( ! (DateTime.MinValue==AV69Cierreswwds_9_cierresultimafecha2) ) )
         {
            AddWhere(sWhereString, "([CierresUltimaFecha] >= @AV69Cierreswwds_9_cierresultimafecha2)");
         }
         else
         {
            GXv_int5[10] = 1;
         }
         if ( AV66Cierreswwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV67Cierreswwds_7_dynamicfiltersselector2, "CIERRESULTIMAFECHA") == 0 ) && ( AV68Cierreswwds_8_dynamicfiltersoperator2 == 3 ) && ( ! (DateTime.MinValue==AV70Cierreswwds_10_cierresultimafecha_to2) ) )
         {
            AddWhere(sWhereString, "([CierresUltimaFecha] <= @AV70Cierreswwds_10_cierresultimafecha_to2)");
         }
         else
         {
            GXv_int5[11] = 1;
         }
         if ( AV71Cierreswwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV72Cierreswwds_12_dynamicfiltersselector3, "CIERRESULTIMAFECHA") == 0 ) && ( AV73Cierreswwds_13_dynamicfiltersoperator3 == 0 ) && ( ! (DateTime.MinValue==AV74Cierreswwds_14_cierresultimafecha3) ) )
         {
            AddWhere(sWhereString, "([CierresUltimaFecha] < @AV74Cierreswwds_14_cierresultimafecha3)");
         }
         else
         {
            GXv_int5[12] = 1;
         }
         if ( AV71Cierreswwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV72Cierreswwds_12_dynamicfiltersselector3, "CIERRESULTIMAFECHA") == 0 ) && ( AV73Cierreswwds_13_dynamicfiltersoperator3 == 1 ) && ( ! (DateTime.MinValue==AV74Cierreswwds_14_cierresultimafecha3) ) )
         {
            AddWhere(sWhereString, "([CierresUltimaFecha] = @AV74Cierreswwds_14_cierresultimafecha3)");
         }
         else
         {
            GXv_int5[13] = 1;
         }
         if ( AV71Cierreswwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV72Cierreswwds_12_dynamicfiltersselector3, "CIERRESULTIMAFECHA") == 0 ) && ( AV73Cierreswwds_13_dynamicfiltersoperator3 == 2 ) && ( ! (DateTime.MinValue==AV74Cierreswwds_14_cierresultimafecha3) ) )
         {
            AddWhere(sWhereString, "([CierresUltimaFecha] > @AV74Cierreswwds_14_cierresultimafecha3)");
         }
         else
         {
            GXv_int5[14] = 1;
         }
         if ( AV71Cierreswwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV72Cierreswwds_12_dynamicfiltersselector3, "CIERRESULTIMAFECHA") == 0 ) && ( AV73Cierreswwds_13_dynamicfiltersoperator3 == 3 ) && ( ! (DateTime.MinValue==AV74Cierreswwds_14_cierresultimafecha3) ) )
         {
            AddWhere(sWhereString, "([CierresUltimaFecha] >= @AV74Cierreswwds_14_cierresultimafecha3)");
         }
         else
         {
            GXv_int5[15] = 1;
         }
         if ( AV71Cierreswwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV72Cierreswwds_12_dynamicfiltersselector3, "CIERRESULTIMAFECHA") == 0 ) && ( AV73Cierreswwds_13_dynamicfiltersoperator3 == 3 ) && ( ! (DateTime.MinValue==AV75Cierreswwds_15_cierresultimafecha_to3) ) )
         {
            AddWhere(sWhereString, "([CierresUltimaFecha] <= @AV75Cierreswwds_15_cierresultimafecha_to3)");
         }
         else
         {
            GXv_int5[16] = 1;
         }
         if ( ! (0==AV76Cierreswwds_16_tfcierresid) )
         {
            AddWhere(sWhereString, "([CierresId] >= @AV76Cierreswwds_16_tfcierresid)");
         }
         else
         {
            GXv_int5[17] = 1;
         }
         if ( ! (0==AV77Cierreswwds_17_tfcierresid_to) )
         {
            AddWhere(sWhereString, "([CierresId] <= @AV77Cierreswwds_17_tfcierresid_to)");
         }
         else
         {
            GXv_int5[18] = 1;
         }
         if ( ! (DateTime.MinValue==AV78Cierreswwds_18_tfcierresultimafecha) )
         {
            AddWhere(sWhereString, "([CierresUltimaFecha] >= @AV78Cierreswwds_18_tfcierresultimafecha)");
         }
         else
         {
            GXv_int5[19] = 1;
         }
         if ( ! (DateTime.MinValue==AV79Cierreswwds_19_tfcierresultimafecha_to) )
         {
            AddWhere(sWhereString, "([CierresUltimaFecha] <= @AV79Cierreswwds_19_tfcierresultimafecha_to)");
         }
         else
         {
            GXv_int5[20] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV81Cierreswwds_21_tfcierresusuario_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV80Cierreswwds_20_tfcierresusuario)) ) )
         {
            AddWhere(sWhereString, "(UPPER([CierresUsuario]) like UPPER(@lV80Cierreswwds_20_tfcierresusuario))");
         }
         else
         {
            GXv_int5[21] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV81Cierreswwds_21_tfcierresusuario_sel)) && ! ( StringUtil.StrCmp(AV81Cierreswwds_21_tfcierresusuario_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([CierresUsuario] = @AV81Cierreswwds_21_tfcierresusuario_sel)");
         }
         else
         {
            GXv_int5[22] = 1;
         }
         if ( StringUtil.StrCmp(AV81Cierreswwds_21_tfcierresusuario_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([CierresUsuario] = ''))");
         }
         scmdbuf += sWhereString;
         if ( ( AV17OrderedBy == 1 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY [CierresUltimaFecha]";
         }
         else if ( ( AV17OrderedBy == 1 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [CierresUltimaFecha] DESC";
         }
         else if ( ( AV17OrderedBy == 2 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY [CierresId]";
         }
         else if ( ( AV17OrderedBy == 2 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [CierresId] DESC";
         }
         else if ( ( AV17OrderedBy == 3 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY [CierresUsuario]";
         }
         else if ( ( AV17OrderedBy == 3 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [CierresUsuario] DESC";
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
                     return conditional_P00J02(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (short)dynConstraints[2] , (DateTime)dynConstraints[3] , (DateTime)dynConstraints[4] , (bool)dynConstraints[5] , (string)dynConstraints[6] , (short)dynConstraints[7] , (DateTime)dynConstraints[8] , (DateTime)dynConstraints[9] , (bool)dynConstraints[10] , (string)dynConstraints[11] , (short)dynConstraints[12] , (DateTime)dynConstraints[13] , (DateTime)dynConstraints[14] , (long)dynConstraints[15] , (long)dynConstraints[16] , (DateTime)dynConstraints[17] , (DateTime)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (long)dynConstraints[21] , (string)dynConstraints[22] , (DateTime)dynConstraints[23] , (short)dynConstraints[24] , (bool)dynConstraints[25] );
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
          Object[] prmP00J02;
          prmP00J02 = new Object[] {
          new ParDef("@lV61Cierreswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV61Cierreswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@AV64Cierreswwds_4_cierresultimafecha1",GXType.Date,8,0) ,
          new ParDef("@AV64Cierreswwds_4_cierresultimafecha1",GXType.Date,8,0) ,
          new ParDef("@AV64Cierreswwds_4_cierresultimafecha1",GXType.Date,8,0) ,
          new ParDef("@AV64Cierreswwds_4_cierresultimafecha1",GXType.Date,8,0) ,
          new ParDef("@AV65Cierreswwds_5_cierresultimafecha_to1",GXType.Date,8,0) ,
          new ParDef("@AV69Cierreswwds_9_cierresultimafecha2",GXType.Date,8,0) ,
          new ParDef("@AV69Cierreswwds_9_cierresultimafecha2",GXType.Date,8,0) ,
          new ParDef("@AV69Cierreswwds_9_cierresultimafecha2",GXType.Date,8,0) ,
          new ParDef("@AV69Cierreswwds_9_cierresultimafecha2",GXType.Date,8,0) ,
          new ParDef("@AV70Cierreswwds_10_cierresultimafecha_to2",GXType.Date,8,0) ,
          new ParDef("@AV74Cierreswwds_14_cierresultimafecha3",GXType.Date,8,0) ,
          new ParDef("@AV74Cierreswwds_14_cierresultimafecha3",GXType.Date,8,0) ,
          new ParDef("@AV74Cierreswwds_14_cierresultimafecha3",GXType.Date,8,0) ,
          new ParDef("@AV74Cierreswwds_14_cierresultimafecha3",GXType.Date,8,0) ,
          new ParDef("@AV75Cierreswwds_15_cierresultimafecha_to3",GXType.Date,8,0) ,
          new ParDef("@AV76Cierreswwds_16_tfcierresid",GXType.Decimal,18,0) ,
          new ParDef("@AV77Cierreswwds_17_tfcierresid_to",GXType.Decimal,18,0) ,
          new ParDef("@AV78Cierreswwds_18_tfcierresultimafecha",GXType.Date,8,0) ,
          new ParDef("@AV79Cierreswwds_19_tfcierresultimafecha_to",GXType.Date,8,0) ,
          new ParDef("@lV80Cierreswwds_20_tfcierresusuario",GXType.Char,30,0) ,
          new ParDef("@AV81Cierreswwds_21_tfcierresusuario_sel",GXType.NChar,30,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00J02", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00J02,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[0])[0] = rslt.getString(1, 30);
                ((long[]) buf[1])[0] = rslt.getLong(2);
                ((DateTime[]) buf[2])[0] = rslt.getGXDate(3);
                return;
       }
    }

 }

}

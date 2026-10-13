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
   public class cuponwwexport : GXProcedure
   {
      public cuponwwexport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public cuponwwexport( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( out string aP0_Filename ,
                           out string aP1_ErrorMessage )
      {
         this.AV11Filename = "" ;
         this.AV12ErrorMessage = "" ;
         initialize();
         ExecutePrivate();
         aP0_Filename=this.AV11Filename;
         aP1_ErrorMessage=this.AV12ErrorMessage;
      }

      public string executeUdp( out string aP0_Filename )
      {
         execute(out aP0_Filename, out aP1_ErrorMessage);
         return AV12ErrorMessage ;
      }

      public void executeSubmit( out string aP0_Filename ,
                                 out string aP1_ErrorMessage )
      {
         this.AV11Filename = "" ;
         this.AV12ErrorMessage = "" ;
         SubmitImpl();
         aP0_Filename=this.AV11Filename;
         aP1_ErrorMessage=this.AV12ErrorMessage;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         GXt_boolean1 = AV8IsAuthorized;
         new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWCupon", out  GXt_boolean1) ;
         AV8IsAuthorized = GXt_boolean1;
         if ( ! AV8IsAuthorized )
         {
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "wwpbaseobjects.notauthorized.aspx"+GXUtil.UrlEncode(StringUtil.RTrim(AV56Pgmname));
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
            AV13CellRow = 1;
            AV14FirstColumn = 1;
            /* Execute user subroutine: 'LOADGRIDSTATE' */
            S191 ();
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
            S151 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
            /* Execute user subroutine: 'CLOSEDOCUMENT' */
            S181 ();
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
         AV15Random = (int)(NumberUtil.Random( )*10000);
         GXt_char2 = AV11Filename;
         new GeneXus.Programs.wwpbaseobjects.wwp_getdefaultexportpath(context ).execute( out  GXt_char2) ;
         AV11Filename = GXt_char2 + "CuponWWExport-" + StringUtil.Trim( StringUtil.Str( (decimal)(AV15Random), 8, 0)) + ".xlsx";
         AV10ExcelDocument.Open(AV11Filename);
         /* Execute user subroutine: 'CHECKSTATUS' */
         S121 ();
         if (returnInSub) return;
         AV10ExcelDocument.Clear();
      }

      protected void S131( )
      {
         /* 'WRITEFILTERS' Routine */
         returnInSub = false;
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV18FilterFullText)) ) )
         {
            GXt_int3 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int3,  (short)(AV14FirstColumn),  context.GetMessage( "WWP_FullTextFilterDescription", "")) ;
            AV13CellRow = GXt_int3;
            GXt_char2 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV18FilterFullText, out  GXt_char2) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char2;
         }
         if ( AV33GridState.gxTpr_Dynamicfilters.Count >= 1 )
         {
            AV30GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV33GridState.gxTpr_Dynamicfilters.Item(1));
            AV19DynamicFiltersSelector1 = AV30GridStateDynamicFilter.gxTpr_Selected;
            if ( StringUtil.StrCmp(AV19DynamicFiltersSelector1, "CUPONPERCENT") == 0 )
            {
               AV20DynamicFiltersOperator1 = AV30GridStateDynamicFilter.gxTpr_Operator;
               AV21CuponPercent1 = (short)(Math.Round(NumberUtil.Val( AV30GridStateDynamicFilter.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               if ( ! (0==AV21CuponPercent1) )
               {
                  AV13CellRow = (int)(AV13CellRow+1);
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                  if ( AV20DynamicFiltersOperator1 == 0 )
                  {
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", context.GetMessage( "Percent", ""), "<", "", "", "", "", "", "", "");
                  }
                  else if ( AV20DynamicFiltersOperator1 == 1 )
                  {
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", context.GetMessage( "Percent", ""), "=", "", "", "", "", "", "", "");
                  }
                  else if ( AV20DynamicFiltersOperator1 == 2 )
                  {
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", context.GetMessage( "Percent", ""), ">", "", "", "", "", "", "", "");
                  }
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Number = AV21CuponPercent1;
               }
            }
            if ( AV33GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV22DynamicFiltersEnabled2 = true;
               AV30GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV33GridState.gxTpr_Dynamicfilters.Item(2));
               AV23DynamicFiltersSelector2 = AV30GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV23DynamicFiltersSelector2, "CUPONPERCENT") == 0 )
               {
                  AV24DynamicFiltersOperator2 = AV30GridStateDynamicFilter.gxTpr_Operator;
                  AV25CuponPercent2 = (short)(Math.Round(NumberUtil.Val( AV30GridStateDynamicFilter.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
                  if ( ! (0==AV25CuponPercent2) )
                  {
                     AV13CellRow = (int)(AV13CellRow+1);
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                     if ( AV24DynamicFiltersOperator2 == 0 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", context.GetMessage( "Percent", ""), "<", "", "", "", "", "", "", "");
                     }
                     else if ( AV24DynamicFiltersOperator2 == 1 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", context.GetMessage( "Percent", ""), "=", "", "", "", "", "", "", "");
                     }
                     else if ( AV24DynamicFiltersOperator2 == 2 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", context.GetMessage( "Percent", ""), ">", "", "", "", "", "", "", "");
                     }
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Number = AV25CuponPercent2;
                  }
               }
               if ( AV33GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV26DynamicFiltersEnabled3 = true;
                  AV30GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV33GridState.gxTpr_Dynamicfilters.Item(3));
                  AV27DynamicFiltersSelector3 = AV30GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV27DynamicFiltersSelector3, "CUPONPERCENT") == 0 )
                  {
                     AV28DynamicFiltersOperator3 = AV30GridStateDynamicFilter.gxTpr_Operator;
                     AV29CuponPercent3 = (short)(Math.Round(NumberUtil.Val( AV30GridStateDynamicFilter.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
                     if ( ! (0==AV29CuponPercent3) )
                     {
                        AV13CellRow = (int)(AV13CellRow+1);
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                        if ( AV28DynamicFiltersOperator3 == 0 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", context.GetMessage( "Percent", ""), "<", "", "", "", "", "", "", "");
                        }
                        else if ( AV28DynamicFiltersOperator3 == 1 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", context.GetMessage( "Percent", ""), "=", "", "", "", "", "", "", "");
                        }
                        else if ( AV28DynamicFiltersOperator3 == 2 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", context.GetMessage( "Percent", ""), ">", "", "", "", "", "", "", "");
                        }
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Number = AV29CuponPercent3;
                     }
                  }
               }
            }
         }
         if ( ! ( (0==AV46TFCuponId) && (0==AV47TFCuponId_To) ) )
         {
            GXt_int3 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int3,  (short)(AV14FirstColumn),  context.GetMessage( "Código", "")) ;
            AV13CellRow = GXt_int3;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Number = AV46TFCuponId;
            GXt_int3 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  false, ref  GXt_int3,  (short)(AV14FirstColumn+2),  context.GetMessage( "WWP_TSTo", "")) ;
            AV13CellRow = GXt_int3;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Number = AV47TFCuponId_To;
         }
         if ( ! ( (0==AV48TFCuponPercent) && (0==AV49TFCuponPercent_To) ) )
         {
            GXt_int3 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int3,  (short)(AV14FirstColumn),  context.GetMessage( "Porcentaje", "")) ;
            AV13CellRow = GXt_int3;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Number = AV48TFCuponPercent;
            GXt_int3 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  false, ref  GXt_int3,  (short)(AV14FirstColumn+2),  context.GetMessage( "WWP_TSTo", "")) ;
            AV13CellRow = GXt_int3;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Number = AV49TFCuponPercent_To;
         }
         if ( ! ( (DateTime.MinValue==AV53TFCuponFechaVence) && (DateTime.MinValue==AV54TFCuponFechaVence_To) ) )
         {
            GXt_int3 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int3,  (short)(AV14FirstColumn),  context.GetMessage( "Vencimiento", "")) ;
            AV13CellRow = GXt_int3;
            GXt_dtime4 = DateTimeUtil.ResetTime( AV53TFCuponFechaVence ) ;
            AV10ExcelDocument.SetDateFormat(context, 8, 5, ((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0), DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt")), "/", ":", " ");
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Date = GXt_dtime4;
            GXt_int3 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  false, ref  GXt_int3,  (short)(AV14FirstColumn+2),  context.GetMessage( "WWP_TSTo", "")) ;
            AV13CellRow = GXt_int3;
            GXt_dtime4 = DateTimeUtil.ResetTime( AV54TFCuponFechaVence_To ) ;
            AV10ExcelDocument.SetDateFormat(context, 8, 5, ((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0), DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt")), "/", ":", " ");
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Date = GXt_dtime4;
         }
         if ( ! ( (0==AV55TFCuponUsado_Sel) ) )
         {
            GXt_int3 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int3,  (short)(AV14FirstColumn),  context.GetMessage( "¿Usado?", "")) ;
            AV13CellRow = GXt_int3;
            if ( AV55TFCuponUsado_Sel == 1 )
            {
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = context.GetMessage( "WWP_TSChecked", "");
            }
            else if ( AV55TFCuponUsado_Sel == 2 )
            {
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = context.GetMessage( "WWP_TSUnChecked", "");
            }
         }
         if ( ! ( (0==AV50TFCuponUser) && (0==AV51TFCuponUser_To) ) )
         {
            GXt_int3 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int3,  (short)(AV14FirstColumn),  context.GetMessage( "User", "")) ;
            AV13CellRow = GXt_int3;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Number = AV50TFCuponUser;
            GXt_int3 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  false, ref  GXt_int3,  (short)(AV14FirstColumn+2),  context.GetMessage( "WWP_TSTo", "")) ;
            AV13CellRow = GXt_int3;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Number = AV51TFCuponUser_To;
         }
         AV13CellRow = (int)(AV13CellRow+2);
      }

      protected void S141( )
      {
         /* 'WRITECOLUMNTITLES' Routine */
         returnInSub = false;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+0, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+0, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+0, 1, 1).Text = context.GetMessage( "Código", "");
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = context.GetMessage( "Porcentaje", "");
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Text = context.GetMessage( "Vencimiento", "");
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Text = context.GetMessage( "¿Usado?", "");
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+4, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+4, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+4, 1, 1).Text = context.GetMessage( "User", "");
      }

      protected void S151( )
      {
         /* 'WRITEDATA' Routine */
         returnInSub = false;
         AV58Cuponwwds_1_filterfulltext = AV18FilterFullText;
         AV59Cuponwwds_2_dynamicfiltersselector1 = AV19DynamicFiltersSelector1;
         AV60Cuponwwds_3_dynamicfiltersoperator1 = AV20DynamicFiltersOperator1;
         AV61Cuponwwds_4_cuponpercent1 = AV21CuponPercent1;
         AV62Cuponwwds_5_dynamicfiltersenabled2 = AV22DynamicFiltersEnabled2;
         AV63Cuponwwds_6_dynamicfiltersselector2 = AV23DynamicFiltersSelector2;
         AV64Cuponwwds_7_dynamicfiltersoperator2 = AV24DynamicFiltersOperator2;
         AV65Cuponwwds_8_cuponpercent2 = AV25CuponPercent2;
         AV66Cuponwwds_9_dynamicfiltersenabled3 = AV26DynamicFiltersEnabled3;
         AV67Cuponwwds_10_dynamicfiltersselector3 = AV27DynamicFiltersSelector3;
         AV68Cuponwwds_11_dynamicfiltersoperator3 = AV28DynamicFiltersOperator3;
         AV69Cuponwwds_12_cuponpercent3 = AV29CuponPercent3;
         AV70Cuponwwds_13_tfcuponid = AV46TFCuponId;
         AV71Cuponwwds_14_tfcuponid_to = AV47TFCuponId_To;
         AV72Cuponwwds_15_tfcuponpercent = AV48TFCuponPercent;
         AV73Cuponwwds_16_tfcuponpercent_to = AV49TFCuponPercent_To;
         AV74Cuponwwds_17_tfcuponfechavence = AV53TFCuponFechaVence;
         AV75Cuponwwds_18_tfcuponfechavence_to = AV54TFCuponFechaVence_To;
         AV76Cuponwwds_19_tfcuponusado_sel = AV55TFCuponUsado_Sel;
         AV77Cuponwwds_20_tfcuponuser = AV50TFCuponUser;
         AV78Cuponwwds_21_tfcuponuser_to = AV51TFCuponUser_To;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV58Cuponwwds_1_filterfulltext ,
                                              AV59Cuponwwds_2_dynamicfiltersselector1 ,
                                              AV60Cuponwwds_3_dynamicfiltersoperator1 ,
                                              AV61Cuponwwds_4_cuponpercent1 ,
                                              AV62Cuponwwds_5_dynamicfiltersenabled2 ,
                                              AV63Cuponwwds_6_dynamicfiltersselector2 ,
                                              AV64Cuponwwds_7_dynamicfiltersoperator2 ,
                                              AV65Cuponwwds_8_cuponpercent2 ,
                                              AV66Cuponwwds_9_dynamicfiltersenabled3 ,
                                              AV67Cuponwwds_10_dynamicfiltersselector3 ,
                                              AV68Cuponwwds_11_dynamicfiltersoperator3 ,
                                              AV69Cuponwwds_12_cuponpercent3 ,
                                              AV70Cuponwwds_13_tfcuponid ,
                                              AV71Cuponwwds_14_tfcuponid_to ,
                                              AV72Cuponwwds_15_tfcuponpercent ,
                                              AV73Cuponwwds_16_tfcuponpercent_to ,
                                              AV74Cuponwwds_17_tfcuponfechavence ,
                                              AV75Cuponwwds_18_tfcuponfechavence_to ,
                                              AV76Cuponwwds_19_tfcuponusado_sel ,
                                              AV77Cuponwwds_20_tfcuponuser ,
                                              AV78Cuponwwds_21_tfcuponuser_to ,
                                              A1013CuponId ,
                                              A1014CuponPercent ,
                                              A1015CuponUser ,
                                              A1017CuponFechaVence ,
                                              A1018CuponUsado ,
                                              AV16OrderedBy ,
                                              AV17OrderedDsc } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.LONG,
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.SHORT, TypeConstants.LONG,
                                              TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV58Cuponwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV58Cuponwwds_1_filterfulltext), "%", "");
         lV58Cuponwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV58Cuponwwds_1_filterfulltext), "%", "");
         lV58Cuponwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV58Cuponwwds_1_filterfulltext), "%", "");
         /* Using cursor P00NI2 */
         pr_default.execute(0, new Object[] {lV58Cuponwwds_1_filterfulltext, lV58Cuponwwds_1_filterfulltext, lV58Cuponwwds_1_filterfulltext, AV61Cuponwwds_4_cuponpercent1, AV61Cuponwwds_4_cuponpercent1, AV61Cuponwwds_4_cuponpercent1, AV65Cuponwwds_8_cuponpercent2, AV65Cuponwwds_8_cuponpercent2, AV65Cuponwwds_8_cuponpercent2, AV69Cuponwwds_12_cuponpercent3, AV69Cuponwwds_12_cuponpercent3, AV69Cuponwwds_12_cuponpercent3, AV70Cuponwwds_13_tfcuponid, AV71Cuponwwds_14_tfcuponid_to, AV72Cuponwwds_15_tfcuponpercent, AV73Cuponwwds_16_tfcuponpercent_to, AV74Cuponwwds_17_tfcuponfechavence, AV75Cuponwwds_18_tfcuponfechavence_to, AV77Cuponwwds_20_tfcuponuser, AV78Cuponwwds_21_tfcuponuser_to});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A1015CuponUser = P00NI2_A1015CuponUser[0];
            A1018CuponUsado = P00NI2_A1018CuponUsado[0];
            A1017CuponFechaVence = P00NI2_A1017CuponFechaVence[0];
            A1013CuponId = P00NI2_A1013CuponId[0];
            A1014CuponPercent = P00NI2_A1014CuponPercent[0];
            AV13CellRow = (int)(AV13CellRow+1);
            /* Execute user subroutine: 'BEFOREWRITELINE' */
            S162 ();
            if ( returnInSub )
            {
               pr_default.close(0);
               returnInSub = true;
               if (true) return;
            }
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+0, 1, 1).Number = A1013CuponId;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Number = A1014CuponPercent;
            GXt_dtime4 = DateTimeUtil.ResetTime( A1017CuponFechaVence ) ;
            AV10ExcelDocument.SetDateFormat(context, 8, 5, ((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0), DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt")), "/", ":", " ");
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Date = GXt_dtime4;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Text = StringUtil.BoolToStr( A1018CuponUsado);
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+4, 1, 1).Number = A1015CuponUser;
            /* Execute user subroutine: 'AFTERWRITELINE' */
            S172 ();
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

      protected void S181( )
      {
         /* 'CLOSEDOCUMENT' Routine */
         returnInSub = false;
         AV10ExcelDocument.Save();
         /* Execute user subroutine: 'CHECKSTATUS' */
         S121 ();
         if (returnInSub) return;
         AV10ExcelDocument.Close();
         AV31Session.Set("WWPExportFilePath", AV11Filename);
         AV31Session.Set("WWPExportFileName", "CuponWWExport.xlsx");
         AV11Filename = formatLink("wwpbaseobjects.wwp_downloadreport.aspx") ;
      }

      protected void S121( )
      {
         /* 'CHECKSTATUS' Routine */
         returnInSub = false;
         if ( AV10ExcelDocument.ErrCode != 0 )
         {
            AV11Filename = "";
            AV12ErrorMessage = AV10ExcelDocument.ErrDescription;
            AV10ExcelDocument.Close();
            returnInSub = true;
            if (true) return;
         }
      }

      protected void S191( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV31Session.Get("CuponWWGridState"), "") == 0 )
         {
            AV33GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "CuponWWGridState"), null, "", "");
         }
         else
         {
            AV33GridState.FromXml(AV31Session.Get("CuponWWGridState"), null, "", "");
         }
         AV16OrderedBy = AV33GridState.gxTpr_Orderedby;
         AV17OrderedDsc = AV33GridState.gxTpr_Ordereddsc;
         AV79GXV1 = 1;
         while ( AV79GXV1 <= AV33GridState.gxTpr_Filtervalues.Count )
         {
            AV34GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV33GridState.gxTpr_Filtervalues.Item(AV79GXV1));
            if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV18FilterFullText = AV34GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFCUPONID") == 0 )
            {
               AV46TFCuponId = (long)(Math.Round(NumberUtil.Val( AV34GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV47TFCuponId_To = (long)(Math.Round(NumberUtil.Val( AV34GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFCUPONPERCENT") == 0 )
            {
               AV48TFCuponPercent = (short)(Math.Round(NumberUtil.Val( AV34GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV49TFCuponPercent_To = (short)(Math.Round(NumberUtil.Val( AV34GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFCUPONFECHAVENCE") == 0 )
            {
               AV53TFCuponFechaVence = context.localUtil.CToD( AV34GridStateFilterValue.gxTpr_Value, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               AV54TFCuponFechaVence_To = context.localUtil.CToD( AV34GridStateFilterValue.gxTpr_Valueto, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFCUPONUSADO_SEL") == 0 )
            {
               AV55TFCuponUsado_Sel = (short)(Math.Round(NumberUtil.Val( AV34GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFCUPONUSER") == 0 )
            {
               AV50TFCuponUser = (long)(Math.Round(NumberUtil.Val( AV34GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV51TFCuponUser_To = (long)(Math.Round(NumberUtil.Val( AV34GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            AV79GXV1 = (int)(AV79GXV1+1);
         }
      }

      protected void S162( )
      {
         /* 'BEFOREWRITELINE' Routine */
         returnInSub = false;
      }

      protected void S172( )
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
         AV11Filename = "";
         AV12ErrorMessage = "";
         AV56Pgmname = "";
         GXKey = "";
         GXEncryptionTmp = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV10ExcelDocument = new ExcelDocumentI();
         AV18FilterFullText = "";
         GXt_char2 = "";
         AV33GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV30GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV19DynamicFiltersSelector1 = "";
         AV23DynamicFiltersSelector2 = "";
         AV27DynamicFiltersSelector3 = "";
         AV46TFCuponId = 0;
         AV47TFCuponId_To = 0;
         AV53TFCuponFechaVence = DateTime.MinValue;
         AV54TFCuponFechaVence_To = DateTime.MinValue;
         AV58Cuponwwds_1_filterfulltext = "";
         AV59Cuponwwds_2_dynamicfiltersselector1 = "";
         AV63Cuponwwds_6_dynamicfiltersselector2 = "";
         AV67Cuponwwds_10_dynamicfiltersselector3 = "";
         AV74Cuponwwds_17_tfcuponfechavence = DateTime.MinValue;
         AV75Cuponwwds_18_tfcuponfechavence_to = DateTime.MinValue;
         lV58Cuponwwds_1_filterfulltext = "";
         A1017CuponFechaVence = DateTime.MinValue;
         P00NI2_A1015CuponUser = new long[1] ;
         P00NI2_A1018CuponUsado = new bool[] {false} ;
         P00NI2_A1017CuponFechaVence = new DateTime[] {DateTime.MinValue} ;
         P00NI2_A1013CuponId = new long[1] ;
         P00NI2_A1014CuponPercent = new short[1] ;
         GXt_dtime4 = (DateTime)(DateTime.MinValue);
         AV31Session = context.GetSession();
         AV34GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.cuponwwexport__default(),
            new Object[][] {
                new Object[] {
               P00NI2_A1015CuponUser, P00NI2_A1018CuponUsado, P00NI2_A1017CuponFechaVence, P00NI2_A1013CuponId, P00NI2_A1014CuponPercent
               }
            }
         );
         AV56Pgmname = "CuponWWExport";
         /* GeneXus formulas. */
         AV56Pgmname = "CuponWWExport";
      }

      private short AV20DynamicFiltersOperator1 ;
      private short AV21CuponPercent1 ;
      private short AV24DynamicFiltersOperator2 ;
      private short AV25CuponPercent2 ;
      private short AV28DynamicFiltersOperator3 ;
      private short AV29CuponPercent3 ;
      private short AV48TFCuponPercent ;
      private short AV49TFCuponPercent_To ;
      private short AV55TFCuponUsado_Sel ;
      private short GXt_int3 ;
      private short AV60Cuponwwds_3_dynamicfiltersoperator1 ;
      private short AV61Cuponwwds_4_cuponpercent1 ;
      private short AV64Cuponwwds_7_dynamicfiltersoperator2 ;
      private short AV65Cuponwwds_8_cuponpercent2 ;
      private short AV68Cuponwwds_11_dynamicfiltersoperator3 ;
      private short AV69Cuponwwds_12_cuponpercent3 ;
      private short AV72Cuponwwds_15_tfcuponpercent ;
      private short AV73Cuponwwds_16_tfcuponpercent_to ;
      private short AV76Cuponwwds_19_tfcuponusado_sel ;
      private short A1014CuponPercent ;
      private short AV16OrderedBy ;
      private int AV13CellRow ;
      private int AV14FirstColumn ;
      private int AV15Random ;
      private int AV79GXV1 ;
      private long AV46TFCuponId ;
      private long AV47TFCuponId_To ;
      private long AV50TFCuponUser ;
      private long AV51TFCuponUser_To ;
      private long AV70Cuponwwds_13_tfcuponid ;
      private long AV71Cuponwwds_14_tfcuponid_to ;
      private long AV77Cuponwwds_20_tfcuponuser ;
      private long AV78Cuponwwds_21_tfcuponuser_to ;
      private long A1013CuponId ;
      private long A1015CuponUser ;
      private string AV56Pgmname ;
      private string GXKey ;
      private string GXEncryptionTmp ;
      private string GXt_char2 ;
      private DateTime GXt_dtime4 ;
      private DateTime AV53TFCuponFechaVence ;
      private DateTime AV54TFCuponFechaVence_To ;
      private DateTime AV74Cuponwwds_17_tfcuponfechavence ;
      private DateTime AV75Cuponwwds_18_tfcuponfechavence_to ;
      private DateTime A1017CuponFechaVence ;
      private bool AV8IsAuthorized ;
      private bool GXt_boolean1 ;
      private bool returnInSub ;
      private bool AV22DynamicFiltersEnabled2 ;
      private bool AV26DynamicFiltersEnabled3 ;
      private bool AV62Cuponwwds_5_dynamicfiltersenabled2 ;
      private bool AV66Cuponwwds_9_dynamicfiltersenabled3 ;
      private bool A1018CuponUsado ;
      private bool AV17OrderedDsc ;
      private string AV11Filename ;
      private string AV12ErrorMessage ;
      private string AV18FilterFullText ;
      private string AV19DynamicFiltersSelector1 ;
      private string AV23DynamicFiltersSelector2 ;
      private string AV27DynamicFiltersSelector3 ;
      private string AV58Cuponwwds_1_filterfulltext ;
      private string AV59Cuponwwds_2_dynamicfiltersselector1 ;
      private string AV63Cuponwwds_6_dynamicfiltersselector2 ;
      private string AV67Cuponwwds_10_dynamicfiltersselector3 ;
      private string lV58Cuponwwds_1_filterfulltext ;
      private IGxSession AV31Session ;
      private ExcelDocumentI AV10ExcelDocument ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV33GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV30GridStateDynamicFilter ;
      private IDataStoreProvider pr_default ;
      private long[] P00NI2_A1015CuponUser ;
      private bool[] P00NI2_A1018CuponUsado ;
      private DateTime[] P00NI2_A1017CuponFechaVence ;
      private long[] P00NI2_A1013CuponId ;
      private short[] P00NI2_A1014CuponPercent ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV34GridStateFilterValue ;
      private string aP0_Filename ;
      private string aP1_ErrorMessage ;
   }

   public class cuponwwexport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00NI2( IGxContext context ,
                                             string AV58Cuponwwds_1_filterfulltext ,
                                             string AV59Cuponwwds_2_dynamicfiltersselector1 ,
                                             short AV60Cuponwwds_3_dynamicfiltersoperator1 ,
                                             short AV61Cuponwwds_4_cuponpercent1 ,
                                             bool AV62Cuponwwds_5_dynamicfiltersenabled2 ,
                                             string AV63Cuponwwds_6_dynamicfiltersselector2 ,
                                             short AV64Cuponwwds_7_dynamicfiltersoperator2 ,
                                             short AV65Cuponwwds_8_cuponpercent2 ,
                                             bool AV66Cuponwwds_9_dynamicfiltersenabled3 ,
                                             string AV67Cuponwwds_10_dynamicfiltersselector3 ,
                                             short AV68Cuponwwds_11_dynamicfiltersoperator3 ,
                                             short AV69Cuponwwds_12_cuponpercent3 ,
                                             long AV70Cuponwwds_13_tfcuponid ,
                                             long AV71Cuponwwds_14_tfcuponid_to ,
                                             short AV72Cuponwwds_15_tfcuponpercent ,
                                             short AV73Cuponwwds_16_tfcuponpercent_to ,
                                             DateTime AV74Cuponwwds_17_tfcuponfechavence ,
                                             DateTime AV75Cuponwwds_18_tfcuponfechavence_to ,
                                             short AV76Cuponwwds_19_tfcuponusado_sel ,
                                             long AV77Cuponwwds_20_tfcuponuser ,
                                             long AV78Cuponwwds_21_tfcuponuser_to ,
                                             long A1013CuponId ,
                                             short A1014CuponPercent ,
                                             long A1015CuponUser ,
                                             DateTime A1017CuponFechaVence ,
                                             bool A1018CuponUsado ,
                                             short AV16OrderedBy ,
                                             bool AV17OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int5 = new short[20];
         Object[] GXv_Object6 = new Object[2];
         scmdbuf = "SELECT [CuponUser], [CuponUsado], [CuponFechaVence], [CuponId], [CuponPercent] FROM [Cupon]";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV58Cuponwwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( CONVERT( char(18), CAST([CuponId] AS decimal(18,0))) like '%' + @lV58Cuponwwds_1_filterfulltext) or ( CONVERT( char(2), CAST([CuponPercent] AS decimal(2,0))) like '%' + @lV58Cuponwwds_1_filterfulltext) or ( CONVERT( char(10), CAST([CuponUser] AS decimal(10,0))) like '%' + @lV58Cuponwwds_1_filterfulltext))");
         }
         else
         {
            GXv_int5[0] = 1;
            GXv_int5[1] = 1;
            GXv_int5[2] = 1;
         }
         if ( ( StringUtil.StrCmp(AV59Cuponwwds_2_dynamicfiltersselector1, "CUPONPERCENT") == 0 ) && ( AV60Cuponwwds_3_dynamicfiltersoperator1 == 0 ) && ( ! (0==AV61Cuponwwds_4_cuponpercent1) ) )
         {
            AddWhere(sWhereString, "([CuponPercent] < @AV61Cuponwwds_4_cuponpercent1)");
         }
         else
         {
            GXv_int5[3] = 1;
         }
         if ( ( StringUtil.StrCmp(AV59Cuponwwds_2_dynamicfiltersselector1, "CUPONPERCENT") == 0 ) && ( AV60Cuponwwds_3_dynamicfiltersoperator1 == 1 ) && ( ! (0==AV61Cuponwwds_4_cuponpercent1) ) )
         {
            AddWhere(sWhereString, "([CuponPercent] = @AV61Cuponwwds_4_cuponpercent1)");
         }
         else
         {
            GXv_int5[4] = 1;
         }
         if ( ( StringUtil.StrCmp(AV59Cuponwwds_2_dynamicfiltersselector1, "CUPONPERCENT") == 0 ) && ( AV60Cuponwwds_3_dynamicfiltersoperator1 == 2 ) && ( ! (0==AV61Cuponwwds_4_cuponpercent1) ) )
         {
            AddWhere(sWhereString, "([CuponPercent] > @AV61Cuponwwds_4_cuponpercent1)");
         }
         else
         {
            GXv_int5[5] = 1;
         }
         if ( AV62Cuponwwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV63Cuponwwds_6_dynamicfiltersselector2, "CUPONPERCENT") == 0 ) && ( AV64Cuponwwds_7_dynamicfiltersoperator2 == 0 ) && ( ! (0==AV65Cuponwwds_8_cuponpercent2) ) )
         {
            AddWhere(sWhereString, "([CuponPercent] < @AV65Cuponwwds_8_cuponpercent2)");
         }
         else
         {
            GXv_int5[6] = 1;
         }
         if ( AV62Cuponwwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV63Cuponwwds_6_dynamicfiltersselector2, "CUPONPERCENT") == 0 ) && ( AV64Cuponwwds_7_dynamicfiltersoperator2 == 1 ) && ( ! (0==AV65Cuponwwds_8_cuponpercent2) ) )
         {
            AddWhere(sWhereString, "([CuponPercent] = @AV65Cuponwwds_8_cuponpercent2)");
         }
         else
         {
            GXv_int5[7] = 1;
         }
         if ( AV62Cuponwwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV63Cuponwwds_6_dynamicfiltersselector2, "CUPONPERCENT") == 0 ) && ( AV64Cuponwwds_7_dynamicfiltersoperator2 == 2 ) && ( ! (0==AV65Cuponwwds_8_cuponpercent2) ) )
         {
            AddWhere(sWhereString, "([CuponPercent] > @AV65Cuponwwds_8_cuponpercent2)");
         }
         else
         {
            GXv_int5[8] = 1;
         }
         if ( AV66Cuponwwds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV67Cuponwwds_10_dynamicfiltersselector3, "CUPONPERCENT") == 0 ) && ( AV68Cuponwwds_11_dynamicfiltersoperator3 == 0 ) && ( ! (0==AV69Cuponwwds_12_cuponpercent3) ) )
         {
            AddWhere(sWhereString, "([CuponPercent] < @AV69Cuponwwds_12_cuponpercent3)");
         }
         else
         {
            GXv_int5[9] = 1;
         }
         if ( AV66Cuponwwds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV67Cuponwwds_10_dynamicfiltersselector3, "CUPONPERCENT") == 0 ) && ( AV68Cuponwwds_11_dynamicfiltersoperator3 == 1 ) && ( ! (0==AV69Cuponwwds_12_cuponpercent3) ) )
         {
            AddWhere(sWhereString, "([CuponPercent] = @AV69Cuponwwds_12_cuponpercent3)");
         }
         else
         {
            GXv_int5[10] = 1;
         }
         if ( AV66Cuponwwds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV67Cuponwwds_10_dynamicfiltersselector3, "CUPONPERCENT") == 0 ) && ( AV68Cuponwwds_11_dynamicfiltersoperator3 == 2 ) && ( ! (0==AV69Cuponwwds_12_cuponpercent3) ) )
         {
            AddWhere(sWhereString, "([CuponPercent] > @AV69Cuponwwds_12_cuponpercent3)");
         }
         else
         {
            GXv_int5[11] = 1;
         }
         if ( ! (0==AV70Cuponwwds_13_tfcuponid) )
         {
            AddWhere(sWhereString, "([CuponId] >= @AV70Cuponwwds_13_tfcuponid)");
         }
         else
         {
            GXv_int5[12] = 1;
         }
         if ( ! (0==AV71Cuponwwds_14_tfcuponid_to) )
         {
            AddWhere(sWhereString, "([CuponId] <= @AV71Cuponwwds_14_tfcuponid_to)");
         }
         else
         {
            GXv_int5[13] = 1;
         }
         if ( ! (0==AV72Cuponwwds_15_tfcuponpercent) )
         {
            AddWhere(sWhereString, "([CuponPercent] >= @AV72Cuponwwds_15_tfcuponpercent)");
         }
         else
         {
            GXv_int5[14] = 1;
         }
         if ( ! (0==AV73Cuponwwds_16_tfcuponpercent_to) )
         {
            AddWhere(sWhereString, "([CuponPercent] <= @AV73Cuponwwds_16_tfcuponpercent_to)");
         }
         else
         {
            GXv_int5[15] = 1;
         }
         if ( ! (DateTime.MinValue==AV74Cuponwwds_17_tfcuponfechavence) )
         {
            AddWhere(sWhereString, "([CuponFechaVence] >= @AV74Cuponwwds_17_tfcuponfechavence)");
         }
         else
         {
            GXv_int5[16] = 1;
         }
         if ( ! (DateTime.MinValue==AV75Cuponwwds_18_tfcuponfechavence_to) )
         {
            AddWhere(sWhereString, "([CuponFechaVence] <= @AV75Cuponwwds_18_tfcuponfechavence_to)");
         }
         else
         {
            GXv_int5[17] = 1;
         }
         if ( AV76Cuponwwds_19_tfcuponusado_sel == 1 )
         {
            AddWhere(sWhereString, "([CuponUsado] = 1)");
         }
         if ( AV76Cuponwwds_19_tfcuponusado_sel == 2 )
         {
            AddWhere(sWhereString, "([CuponUsado] = 0)");
         }
         if ( ! (0==AV77Cuponwwds_20_tfcuponuser) )
         {
            AddWhere(sWhereString, "([CuponUser] >= @AV77Cuponwwds_20_tfcuponuser)");
         }
         else
         {
            GXv_int5[18] = 1;
         }
         if ( ! (0==AV78Cuponwwds_21_tfcuponuser_to) )
         {
            AddWhere(sWhereString, "([CuponUser] <= @AV78Cuponwwds_21_tfcuponuser_to)");
         }
         else
         {
            GXv_int5[19] = 1;
         }
         scmdbuf += sWhereString;
         if ( ( AV16OrderedBy == 1 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY [CuponPercent]";
         }
         else if ( ( AV16OrderedBy == 1 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [CuponPercent] DESC";
         }
         else if ( ( AV16OrderedBy == 2 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY [CuponId]";
         }
         else if ( ( AV16OrderedBy == 2 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [CuponId] DESC";
         }
         else if ( ( AV16OrderedBy == 3 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY [CuponFechaVence]";
         }
         else if ( ( AV16OrderedBy == 3 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [CuponFechaVence] DESC";
         }
         else if ( ( AV16OrderedBy == 4 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY [CuponUsado]";
         }
         else if ( ( AV16OrderedBy == 4 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [CuponUsado] DESC";
         }
         else if ( ( AV16OrderedBy == 5 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY [CuponUser]";
         }
         else if ( ( AV16OrderedBy == 5 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [CuponUser] DESC";
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
                     return conditional_P00NI2(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (short)dynConstraints[2] , (short)dynConstraints[3] , (bool)dynConstraints[4] , (string)dynConstraints[5] , (short)dynConstraints[6] , (short)dynConstraints[7] , (bool)dynConstraints[8] , (string)dynConstraints[9] , (short)dynConstraints[10] , (short)dynConstraints[11] , (long)dynConstraints[12] , (long)dynConstraints[13] , (short)dynConstraints[14] , (short)dynConstraints[15] , (DateTime)dynConstraints[16] , (DateTime)dynConstraints[17] , (short)dynConstraints[18] , (long)dynConstraints[19] , (long)dynConstraints[20] , (long)dynConstraints[21] , (short)dynConstraints[22] , (long)dynConstraints[23] , (DateTime)dynConstraints[24] , (bool)dynConstraints[25] , (short)dynConstraints[26] , (bool)dynConstraints[27] );
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
          Object[] prmP00NI2;
          prmP00NI2 = new Object[] {
          new ParDef("@lV58Cuponwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV58Cuponwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV58Cuponwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@AV61Cuponwwds_4_cuponpercent1",GXType.Int16,2,0) ,
          new ParDef("@AV61Cuponwwds_4_cuponpercent1",GXType.Int16,2,0) ,
          new ParDef("@AV61Cuponwwds_4_cuponpercent1",GXType.Int16,2,0) ,
          new ParDef("@AV65Cuponwwds_8_cuponpercent2",GXType.Int16,2,0) ,
          new ParDef("@AV65Cuponwwds_8_cuponpercent2",GXType.Int16,2,0) ,
          new ParDef("@AV65Cuponwwds_8_cuponpercent2",GXType.Int16,2,0) ,
          new ParDef("@AV69Cuponwwds_12_cuponpercent3",GXType.Int16,2,0) ,
          new ParDef("@AV69Cuponwwds_12_cuponpercent3",GXType.Int16,2,0) ,
          new ParDef("@AV69Cuponwwds_12_cuponpercent3",GXType.Int16,2,0) ,
          new ParDef("@AV70Cuponwwds_13_tfcuponid",GXType.Decimal,18,0) ,
          new ParDef("@AV71Cuponwwds_14_tfcuponid_to",GXType.Decimal,18,0) ,
          new ParDef("@AV72Cuponwwds_15_tfcuponpercent",GXType.Int16,2,0) ,
          new ParDef("@AV73Cuponwwds_16_tfcuponpercent_to",GXType.Int16,2,0) ,
          new ParDef("@AV74Cuponwwds_17_tfcuponfechavence",GXType.Date,8,0) ,
          new ParDef("@AV75Cuponwwds_18_tfcuponfechavence_to",GXType.Date,8,0) ,
          new ParDef("@AV77Cuponwwds_20_tfcuponuser",GXType.Decimal,10,0) ,
          new ParDef("@AV78Cuponwwds_21_tfcuponuser_to",GXType.Decimal,10,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00NI2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00NI2,100, GxCacheFrequency.OFF ,true,false )
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
                ((bool[]) buf[1])[0] = rslt.getBool(2);
                ((DateTime[]) buf[2])[0] = rslt.getGXDate(3);
                ((long[]) buf[3])[0] = rslt.getLong(4);
                ((short[]) buf[4])[0] = rslt.getShort(5);
                return;
       }
    }

 }

}

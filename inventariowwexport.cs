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
   public class inventariowwexport : GXProcedure
   {
      public inventariowwexport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public inventariowwexport( IGxContext context )
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
         new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWInventario", out  GXt_boolean1) ;
         AV8IsAuthorized = GXt_boolean1;
         if ( ! AV8IsAuthorized )
         {
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "wwpbaseobjects.notauthorized.aspx"+GXUtil.UrlEncode(StringUtil.RTrim(AV79Pgmname));
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
         AV12Filename = GXt_char2 + "InventarioWWExport-" + StringUtil.Trim( StringUtil.Str( (decimal)(AV16Random), 8, 0)) + ".xlsx";
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
            if ( StringUtil.StrCmp(AV20DynamicFiltersSelector1, "RUBROSCOSTO") == 0 )
            {
               AV21DynamicFiltersOperator1 = AV34GridStateDynamicFilter.gxTpr_Operator;
               AV22RubrosCosto1 = NumberUtil.Val( AV34GridStateDynamicFilter.gxTpr_Value, ".");
               if ( ! (Convert.ToDecimal(0)==AV22RubrosCosto1) )
               {
                  AV14CellRow = (int)(AV14CellRow+1);
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Bold = 1;
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Color = 3;
                  if ( AV21DynamicFiltersOperator1 == 0 )
                  {
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", context.GetMessage( "Costo Base", ""), "<", "", "", "", "", "", "", "");
                  }
                  else if ( AV21DynamicFiltersOperator1 == 1 )
                  {
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", context.GetMessage( "Costo Base", ""), "=", "", "", "", "", "", "", "");
                  }
                  else if ( AV21DynamicFiltersOperator1 == 2 )
                  {
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", context.GetMessage( "Costo Base", ""), ">", "", "", "", "", "", "", "");
                  }
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Italic = 1;
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Number = (double)(AV22RubrosCosto1);
               }
            }
            else if ( StringUtil.StrCmp(AV20DynamicFiltersSelector1, "RUBROSNOMBRE") == 0 )
            {
               AV21DynamicFiltersOperator1 = AV34GridStateDynamicFilter.gxTpr_Operator;
               AV23RubrosNombre1 = AV34GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV23RubrosNombre1)) )
               {
                  AV14CellRow = (int)(AV14CellRow+1);
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Bold = 1;
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Color = 3;
                  if ( AV21DynamicFiltersOperator1 == 0 )
                  {
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", context.GetMessage( "Rubro", ""), context.GetMessage( "WWP_FilterLike", ""), "", "", "", "", "", "", "");
                  }
                  else if ( AV21DynamicFiltersOperator1 == 1 )
                  {
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", context.GetMessage( "Rubro", ""), context.GetMessage( "WWP_FilterContains", ""), "", "", "", "", "", "", "");
                  }
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Italic = 1;
                  GXt_char2 = "";
                  new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV23RubrosNombre1, out  GXt_char2) ;
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
               }
            }
            else if ( StringUtil.StrCmp(AV20DynamicFiltersSelector1, "TEXTOSTIPO") == 0 )
            {
               AV21DynamicFiltersOperator1 = AV34GridStateDynamicFilter.gxTpr_Operator;
               AV66TextosTipo1 = AV34GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66TextosTipo1)) )
               {
                  AV14CellRow = (int)(AV14CellRow+1);
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Bold = 1;
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Color = 3;
                  if ( AV21DynamicFiltersOperator1 == 0 )
                  {
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", context.GetMessage( "Tipo", ""), context.GetMessage( "WWP_FilterLike", ""), "", "", "", "", "", "", "");
                  }
                  else if ( AV21DynamicFiltersOperator1 == 1 )
                  {
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", context.GetMessage( "Tipo", ""), context.GetMessage( "WWP_FilterContains", ""), "", "", "", "", "", "", "");
                  }
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Italic = 1;
                  GXt_char2 = "";
                  new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV66TextosTipo1, out  GXt_char2) ;
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
               }
            }
            if ( AV37GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV24DynamicFiltersEnabled2 = true;
               AV34GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV37GridState.gxTpr_Dynamicfilters.Item(2));
               AV25DynamicFiltersSelector2 = AV34GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV25DynamicFiltersSelector2, "RUBROSCOSTO") == 0 )
               {
                  AV26DynamicFiltersOperator2 = AV34GridStateDynamicFilter.gxTpr_Operator;
                  AV27RubrosCosto2 = NumberUtil.Val( AV34GridStateDynamicFilter.gxTpr_Value, ".");
                  if ( ! (Convert.ToDecimal(0)==AV27RubrosCosto2) )
                  {
                     AV14CellRow = (int)(AV14CellRow+1);
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Bold = 1;
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Color = 3;
                     if ( AV26DynamicFiltersOperator2 == 0 )
                     {
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", context.GetMessage( "Costo Base", ""), "<", "", "", "", "", "", "", "");
                     }
                     else if ( AV26DynamicFiltersOperator2 == 1 )
                     {
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", context.GetMessage( "Costo Base", ""), "=", "", "", "", "", "", "", "");
                     }
                     else if ( AV26DynamicFiltersOperator2 == 2 )
                     {
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", context.GetMessage( "Costo Base", ""), ">", "", "", "", "", "", "", "");
                     }
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Italic = 1;
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Number = (double)(AV27RubrosCosto2);
                  }
               }
               else if ( StringUtil.StrCmp(AV25DynamicFiltersSelector2, "RUBROSNOMBRE") == 0 )
               {
                  AV26DynamicFiltersOperator2 = AV34GridStateDynamicFilter.gxTpr_Operator;
                  AV28RubrosNombre2 = AV34GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV28RubrosNombre2)) )
                  {
                     AV14CellRow = (int)(AV14CellRow+1);
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Bold = 1;
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Color = 3;
                     if ( AV26DynamicFiltersOperator2 == 0 )
                     {
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", context.GetMessage( "Rubro", ""), context.GetMessage( "WWP_FilterLike", ""), "", "", "", "", "", "", "");
                     }
                     else if ( AV26DynamicFiltersOperator2 == 1 )
                     {
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", context.GetMessage( "Rubro", ""), context.GetMessage( "WWP_FilterContains", ""), "", "", "", "", "", "", "");
                     }
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Italic = 1;
                     GXt_char2 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV28RubrosNombre2, out  GXt_char2) ;
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
                  }
               }
               else if ( StringUtil.StrCmp(AV25DynamicFiltersSelector2, "TEXTOSTIPO") == 0 )
               {
                  AV26DynamicFiltersOperator2 = AV34GridStateDynamicFilter.gxTpr_Operator;
                  AV67TextosTipo2 = AV34GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67TextosTipo2)) )
                  {
                     AV14CellRow = (int)(AV14CellRow+1);
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Bold = 1;
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Color = 3;
                     if ( AV26DynamicFiltersOperator2 == 0 )
                     {
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", context.GetMessage( "Tipo", ""), context.GetMessage( "WWP_FilterLike", ""), "", "", "", "", "", "", "");
                     }
                     else if ( AV26DynamicFiltersOperator2 == 1 )
                     {
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", context.GetMessage( "Tipo", ""), context.GetMessage( "WWP_FilterContains", ""), "", "", "", "", "", "", "");
                     }
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Italic = 1;
                     GXt_char2 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV67TextosTipo2, out  GXt_char2) ;
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
                  }
               }
               if ( AV37GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV29DynamicFiltersEnabled3 = true;
                  AV34GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV37GridState.gxTpr_Dynamicfilters.Item(3));
                  AV30DynamicFiltersSelector3 = AV34GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV30DynamicFiltersSelector3, "RUBROSCOSTO") == 0 )
                  {
                     AV31DynamicFiltersOperator3 = AV34GridStateDynamicFilter.gxTpr_Operator;
                     AV32RubrosCosto3 = NumberUtil.Val( AV34GridStateDynamicFilter.gxTpr_Value, ".");
                     if ( ! (Convert.ToDecimal(0)==AV32RubrosCosto3) )
                     {
                        AV14CellRow = (int)(AV14CellRow+1);
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Bold = 1;
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Color = 3;
                        if ( AV31DynamicFiltersOperator3 == 0 )
                        {
                           AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", context.GetMessage( "Costo Base", ""), "<", "", "", "", "", "", "", "");
                        }
                        else if ( AV31DynamicFiltersOperator3 == 1 )
                        {
                           AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", context.GetMessage( "Costo Base", ""), "=", "", "", "", "", "", "", "");
                        }
                        else if ( AV31DynamicFiltersOperator3 == 2 )
                        {
                           AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", context.GetMessage( "Costo Base", ""), ">", "", "", "", "", "", "", "");
                        }
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Italic = 1;
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Number = (double)(AV32RubrosCosto3);
                     }
                  }
                  else if ( StringUtil.StrCmp(AV30DynamicFiltersSelector3, "RUBROSNOMBRE") == 0 )
                  {
                     AV31DynamicFiltersOperator3 = AV34GridStateDynamicFilter.gxTpr_Operator;
                     AV33RubrosNombre3 = AV34GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV33RubrosNombre3)) )
                     {
                        AV14CellRow = (int)(AV14CellRow+1);
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Bold = 1;
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Color = 3;
                        if ( AV31DynamicFiltersOperator3 == 0 )
                        {
                           AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", context.GetMessage( "Rubro", ""), context.GetMessage( "WWP_FilterLike", ""), "", "", "", "", "", "", "");
                        }
                        else if ( AV31DynamicFiltersOperator3 == 1 )
                        {
                           AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", context.GetMessage( "Rubro", ""), context.GetMessage( "WWP_FilterContains", ""), "", "", "", "", "", "", "");
                        }
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Italic = 1;
                        GXt_char2 = "";
                        new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV33RubrosNombre3, out  GXt_char2) ;
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
                     }
                  }
                  else if ( StringUtil.StrCmp(AV30DynamicFiltersSelector3, "TEXTOSTIPO") == 0 )
                  {
                     AV31DynamicFiltersOperator3 = AV34GridStateDynamicFilter.gxTpr_Operator;
                     AV68TextosTipo3 = AV34GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68TextosTipo3)) )
                     {
                        AV14CellRow = (int)(AV14CellRow+1);
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Bold = 1;
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Color = 3;
                        if ( AV31DynamicFiltersOperator3 == 0 )
                        {
                           AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", context.GetMessage( "Tipo", ""), context.GetMessage( "WWP_FilterLike", ""), "", "", "", "", "", "", "");
                        }
                        else if ( AV31DynamicFiltersOperator3 == 1 )
                        {
                           AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", context.GetMessage( "Tipo", ""), context.GetMessage( "WWP_FilterContains", ""), "", "", "", "", "", "", "");
                        }
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Italic = 1;
                        GXt_char2 = "";
                        new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV68TextosTipo3, out  GXt_char2) ;
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
                     }
                  }
               }
            }
         }
         if ( ! ( (0==AV50TFRubrosId) && (0==AV51TFRubrosId_To) ) )
         {
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Rubro", "")) ;
            AV14CellRow = GXt_int3;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Number = AV50TFRubrosId;
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  false, ref  GXt_int3,  (short)(AV15FirstColumn+2),  context.GetMessage( "WWP_TSTo", "")) ;
            AV14CellRow = GXt_int3;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+3, 1, 1).Number = AV51TFRubrosId_To;
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV53TFRubrosNombre_Sel)) ) )
         {
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  "") ;
            AV14CellRow = GXt_int3;
            GXt_char2 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV53TFRubrosNombre_Sel)) ? context.GetMessage( "WWP_TitleFilter_EmptyOption", "") : AV53TFRubrosNombre_Sel), out  GXt_char2) ;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV52TFRubrosNombre)) ) )
            {
               GXt_int3 = (short)(AV14CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  "") ;
               AV14CellRow = GXt_int3;
               GXt_char2 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV52TFRubrosNombre, out  GXt_char2) ;
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV57TFMedidasNombre_Sel)) ) )
         {
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  "") ;
            AV14CellRow = GXt_int3;
            GXt_char2 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV57TFMedidasNombre_Sel)) ? context.GetMessage( "WWP_TitleFilter_EmptyOption", "") : AV57TFMedidasNombre_Sel), out  GXt_char2) ;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV56TFMedidasNombre)) ) )
            {
               GXt_int3 = (short)(AV14CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  "") ;
               AV14CellRow = GXt_int3;
               GXt_char2 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV56TFMedidasNombre, out  GXt_char2) ;
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
            }
         }
         if ( ! ( (0==AV58TFTextosId) && (0==AV59TFTextosId_To) ) )
         {
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  "#") ;
            AV14CellRow = GXt_int3;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Number = AV58TFTextosId;
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  false, ref  GXt_int3,  (short)(AV15FirstColumn+2),  context.GetMessage( "WWP_TSTo", "")) ;
            AV14CellRow = GXt_int3;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+3, 1, 1).Number = AV59TFTextosId_To;
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV61TFTextosTitulo_Sel)) ) )
         {
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Terminos y Condiciones", "")) ;
            AV14CellRow = GXt_int3;
            GXt_char2 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV61TFTextosTitulo_Sel)) ? context.GetMessage( "WWP_TitleFilter_EmptyOption", "") : AV61TFTextosTitulo_Sel), out  GXt_char2) ;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV60TFTextosTitulo)) ) )
            {
               GXt_int3 = (short)(AV14CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Terminos y Condiciones", "")) ;
               AV14CellRow = GXt_int3;
               GXt_char2 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV60TFTextosTitulo, out  GXt_char2) ;
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
            }
         }
         if ( ! ( ( AV63TFMedidasEstado_Sels.Count == 0 ) ) )
         {
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  "") ;
            AV14CellRow = GXt_int3;
            AV65i = 1;
            AV80GXV1 = 1;
            while ( AV80GXV1 <= AV63TFMedidasEstado_Sels.Count )
            {
               AV64TFMedidasEstado_Sel = AV63TFMedidasEstado_Sels.GetString(AV80GXV1);
               if ( AV65i == 1 )
               {
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = "";
               }
               else
               {
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text+", ";
               }
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text+context.GetMessage( gxdomainestadoenum.getDescription(context,AV64TFMedidasEstado_Sel), "");
               AV65i = (long)(AV65i+1);
               AV80GXV1 = (int)(AV80GXV1+1);
            }
         }
         AV14CellRow = (int)(AV14CellRow+2);
      }

      protected void S141( )
      {
         /* 'WRITECOLUMNTITLES' Routine */
         returnInSub = false;
         AV47VisibleColumnCount = 0;
         if ( StringUtil.StrCmp(AV35Session.Get("InventarioWWColumnsSelector"), "") != 0 )
         {
            AV42ColumnsSelectorXML = AV35Session.Get("InventarioWWColumnsSelector");
            AV39ColumnsSelector.FromXml(AV42ColumnsSelectorXML, null, "", "");
         }
         else
         {
            /* Execute user subroutine: 'INITIALIZECOLUMNSSELECTOR' */
            S151 ();
            if (returnInSub) return;
         }
         AV39ColumnsSelector.gxTpr_Columns.Sort("Order");
         AV81GXV2 = 1;
         while ( AV81GXV2 <= AV39ColumnsSelector.gxTpr_Columns.Count )
         {
            AV41ColumnsSelector_Column = ((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV39ColumnsSelector.gxTpr_Columns.Item(AV81GXV2));
            if ( AV41ColumnsSelector_Column.gxTpr_Isvisible )
            {
               AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV47VisibleColumnCount), 1, 1).Text = context.GetMessage( (String.IsNullOrEmpty(StringUtil.RTrim( AV41ColumnsSelector_Column.gxTpr_Displayname)) ? AV41ColumnsSelector_Column.gxTpr_Columnname : AV41ColumnsSelector_Column.gxTpr_Displayname), "");
               AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV47VisibleColumnCount), 1, 1).Bold = 1;
               AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV47VisibleColumnCount), 1, 1).Color = 11;
               AV47VisibleColumnCount = (long)(AV47VisibleColumnCount+1);
            }
            AV81GXV2 = (int)(AV81GXV2+1);
         }
      }

      protected void S161( )
      {
         /* 'WRITEDATA' Routine */
         returnInSub = false;
         AV83Inventariowwds_1_filterfulltext = AV19FilterFullText;
         AV84Inventariowwds_2_dynamicfiltersselector1 = AV20DynamicFiltersSelector1;
         AV85Inventariowwds_3_dynamicfiltersoperator1 = AV21DynamicFiltersOperator1;
         AV86Inventariowwds_4_rubroscosto1 = AV22RubrosCosto1;
         AV87Inventariowwds_5_rubrosnombre1 = AV23RubrosNombre1;
         AV88Inventariowwds_6_textostipo1 = AV66TextosTipo1;
         AV89Inventariowwds_7_dynamicfiltersenabled2 = AV24DynamicFiltersEnabled2;
         AV90Inventariowwds_8_dynamicfiltersselector2 = AV25DynamicFiltersSelector2;
         AV91Inventariowwds_9_dynamicfiltersoperator2 = AV26DynamicFiltersOperator2;
         AV92Inventariowwds_10_rubroscosto2 = AV27RubrosCosto2;
         AV93Inventariowwds_11_rubrosnombre2 = AV28RubrosNombre2;
         AV94Inventariowwds_12_textostipo2 = AV67TextosTipo2;
         AV95Inventariowwds_13_dynamicfiltersenabled3 = AV29DynamicFiltersEnabled3;
         AV96Inventariowwds_14_dynamicfiltersselector3 = AV30DynamicFiltersSelector3;
         AV97Inventariowwds_15_dynamicfiltersoperator3 = AV31DynamicFiltersOperator3;
         AV98Inventariowwds_16_rubroscosto3 = AV32RubrosCosto3;
         AV99Inventariowwds_17_rubrosnombre3 = AV33RubrosNombre3;
         AV100Inventariowwds_18_textostipo3 = AV68TextosTipo3;
         AV101Inventariowwds_19_tfrubrosid = AV50TFRubrosId;
         AV102Inventariowwds_20_tfrubrosid_to = AV51TFRubrosId_To;
         AV103Inventariowwds_21_tfrubrosnombre = AV52TFRubrosNombre;
         AV104Inventariowwds_22_tfrubrosnombre_sel = AV53TFRubrosNombre_Sel;
         AV105Inventariowwds_23_tfmedidasnombre = AV56TFMedidasNombre;
         AV106Inventariowwds_24_tfmedidasnombre_sel = AV57TFMedidasNombre_Sel;
         AV107Inventariowwds_25_tftextosid = AV58TFTextosId;
         AV108Inventariowwds_26_tftextosid_to = AV59TFTextosId_To;
         AV109Inventariowwds_27_tftextostitulo = AV60TFTextosTitulo;
         AV110Inventariowwds_28_tftextostitulo_sel = AV61TFTextosTitulo_Sel;
         AV111Inventariowwds_29_tfmedidasestado_sels = AV63TFMedidasEstado_Sels;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A139MedidasEstado ,
                                              AV111Inventariowwds_29_tfmedidasestado_sels ,
                                              AV84Inventariowwds_2_dynamicfiltersselector1 ,
                                              AV85Inventariowwds_3_dynamicfiltersoperator1 ,
                                              AV86Inventariowwds_4_rubroscosto1 ,
                                              AV87Inventariowwds_5_rubrosnombre1 ,
                                              AV88Inventariowwds_6_textostipo1 ,
                                              AV89Inventariowwds_7_dynamicfiltersenabled2 ,
                                              AV90Inventariowwds_8_dynamicfiltersselector2 ,
                                              AV91Inventariowwds_9_dynamicfiltersoperator2 ,
                                              AV92Inventariowwds_10_rubroscosto2 ,
                                              AV93Inventariowwds_11_rubrosnombre2 ,
                                              AV94Inventariowwds_12_textostipo2 ,
                                              AV95Inventariowwds_13_dynamicfiltersenabled3 ,
                                              AV96Inventariowwds_14_dynamicfiltersselector3 ,
                                              AV97Inventariowwds_15_dynamicfiltersoperator3 ,
                                              AV98Inventariowwds_16_rubroscosto3 ,
                                              AV99Inventariowwds_17_rubrosnombre3 ,
                                              AV100Inventariowwds_18_textostipo3 ,
                                              AV101Inventariowwds_19_tfrubrosid ,
                                              AV102Inventariowwds_20_tfrubrosid_to ,
                                              AV104Inventariowwds_22_tfrubrosnombre_sel ,
                                              AV103Inventariowwds_21_tfrubrosnombre ,
                                              AV106Inventariowwds_24_tfmedidasnombre_sel ,
                                              AV105Inventariowwds_23_tfmedidasnombre ,
                                              AV107Inventariowwds_25_tftextosid ,
                                              AV108Inventariowwds_26_tftextosid_to ,
                                              AV110Inventariowwds_28_tftextostitulo_sel ,
                                              AV109Inventariowwds_27_tftextostitulo ,
                                              AV111Inventariowwds_29_tfmedidasestado_sels.Count ,
                                              A215RubrosCosto ,
                                              A122RubrosNombre ,
                                              A258TextosTipo ,
                                              A121RubrosId ,
                                              A138MedidasNombre ,
                                              A150TextosId ,
                                              A259TextosTitulo ,
                                              AV17OrderedBy ,
                                              AV18OrderedDsc ,
                                              AV83Inventariowwds_1_filterfulltext } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.DECIMAL, TypeConstants.SHORT,
                                              TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.INT, TypeConstants.DECIMAL, TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV87Inventariowwds_5_rubrosnombre1 = StringUtil.PadR( StringUtil.RTrim( AV87Inventariowwds_5_rubrosnombre1), 100, "%");
         lV87Inventariowwds_5_rubrosnombre1 = StringUtil.PadR( StringUtil.RTrim( AV87Inventariowwds_5_rubrosnombre1), 100, "%");
         lV88Inventariowwds_6_textostipo1 = StringUtil.PadR( StringUtil.RTrim( AV88Inventariowwds_6_textostipo1), 20, "%");
         lV88Inventariowwds_6_textostipo1 = StringUtil.PadR( StringUtil.RTrim( AV88Inventariowwds_6_textostipo1), 20, "%");
         lV93Inventariowwds_11_rubrosnombre2 = StringUtil.PadR( StringUtil.RTrim( AV93Inventariowwds_11_rubrosnombre2), 100, "%");
         lV93Inventariowwds_11_rubrosnombre2 = StringUtil.PadR( StringUtil.RTrim( AV93Inventariowwds_11_rubrosnombre2), 100, "%");
         lV94Inventariowwds_12_textostipo2 = StringUtil.PadR( StringUtil.RTrim( AV94Inventariowwds_12_textostipo2), 20, "%");
         lV94Inventariowwds_12_textostipo2 = StringUtil.PadR( StringUtil.RTrim( AV94Inventariowwds_12_textostipo2), 20, "%");
         lV99Inventariowwds_17_rubrosnombre3 = StringUtil.PadR( StringUtil.RTrim( AV99Inventariowwds_17_rubrosnombre3), 100, "%");
         lV99Inventariowwds_17_rubrosnombre3 = StringUtil.PadR( StringUtil.RTrim( AV99Inventariowwds_17_rubrosnombre3), 100, "%");
         lV100Inventariowwds_18_textostipo3 = StringUtil.PadR( StringUtil.RTrim( AV100Inventariowwds_18_textostipo3), 20, "%");
         lV100Inventariowwds_18_textostipo3 = StringUtil.PadR( StringUtil.RTrim( AV100Inventariowwds_18_textostipo3), 20, "%");
         lV103Inventariowwds_21_tfrubrosnombre = StringUtil.PadR( StringUtil.RTrim( AV103Inventariowwds_21_tfrubrosnombre), 100, "%");
         lV105Inventariowwds_23_tfmedidasnombre = StringUtil.PadR( StringUtil.RTrim( AV105Inventariowwds_23_tfmedidasnombre), 50, "%");
         lV109Inventariowwds_27_tftextostitulo = StringUtil.PadR( StringUtil.RTrim( AV109Inventariowwds_27_tftextostitulo), 80, "%");
         /* Using cursor P00432 */
         pr_default.execute(0, new Object[] {AV86Inventariowwds_4_rubroscosto1, AV86Inventariowwds_4_rubroscosto1, AV86Inventariowwds_4_rubroscosto1, lV87Inventariowwds_5_rubrosnombre1, lV87Inventariowwds_5_rubrosnombre1, lV88Inventariowwds_6_textostipo1, lV88Inventariowwds_6_textostipo1, AV92Inventariowwds_10_rubroscosto2, AV92Inventariowwds_10_rubroscosto2, AV92Inventariowwds_10_rubroscosto2, lV93Inventariowwds_11_rubrosnombre2, lV93Inventariowwds_11_rubrosnombre2, lV94Inventariowwds_12_textostipo2, lV94Inventariowwds_12_textostipo2, AV98Inventariowwds_16_rubroscosto3, AV98Inventariowwds_16_rubroscosto3, AV98Inventariowwds_16_rubroscosto3, lV99Inventariowwds_17_rubrosnombre3, lV99Inventariowwds_17_rubrosnombre3, lV100Inventariowwds_18_textostipo3, lV100Inventariowwds_18_textostipo3, AV101Inventariowwds_19_tfrubrosid, AV102Inventariowwds_20_tfrubrosid_to, lV103Inventariowwds_21_tfrubrosnombre, AV104Inventariowwds_22_tfrubrosnombre_sel, lV105Inventariowwds_23_tfmedidasnombre, AV106Inventariowwds_24_tfmedidasnombre_sel, AV107Inventariowwds_25_tftextosid, AV108Inventariowwds_26_tftextosid_to, lV109Inventariowwds_27_tftextostitulo, AV110Inventariowwds_28_tftextostitulo_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A258TextosTipo = P00432_A258TextosTipo[0];
            A259TextosTitulo = P00432_A259TextosTitulo[0];
            A150TextosId = P00432_A150TextosId[0];
            n150TextosId = P00432_n150TextosId[0];
            A138MedidasNombre = P00432_A138MedidasNombre[0];
            A122RubrosNombre = P00432_A122RubrosNombre[0];
            A121RubrosId = P00432_A121RubrosId[0];
            A215RubrosCosto = P00432_A215RubrosCosto[0];
            A139MedidasEstado = P00432_A139MedidasEstado[0];
            n139MedidasEstado = P00432_n139MedidasEstado[0];
            A137MedidasID = P00432_A137MedidasID[0];
            A258TextosTipo = P00432_A258TextosTipo[0];
            A259TextosTitulo = P00432_A259TextosTitulo[0];
            A122RubrosNombre = P00432_A122RubrosNombre[0];
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV83Inventariowwds_1_filterfulltext)) || ( ( StringUtil.Like( StringUtil.Str( (decimal)(A121RubrosId), 4, 0) , StringUtil.PadR( "%" + AV83Inventariowwds_1_filterfulltext , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A122RubrosNombre) , StringUtil.PadR( "%" + StringUtil.Upper( AV83Inventariowwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A138MedidasNombre) , StringUtil.PadR( "%" + StringUtil.Upper( AV83Inventariowwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Str( (decimal)(A150TextosId), 18, 0) , StringUtil.PadR( "%" + AV83Inventariowwds_1_filterfulltext , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A259TextosTitulo) , StringUtil.PadR( "%" + StringUtil.Upper( AV83Inventariowwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( context.GetMessage( "habilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV83Inventariowwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A139MedidasEstado, "HAB") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "deshabilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV83Inventariowwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A139MedidasEstado, "DES") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "pendiente", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV83Inventariowwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A139MedidasEstado, "PEN") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "bloqueado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV83Inventariowwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A139MedidasEstado, "BLO") == 0 ) ) ) )
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
               AV112GXV3 = 1;
               while ( AV112GXV3 <= AV39ColumnsSelector.gxTpr_Columns.Count )
               {
                  AV41ColumnsSelector_Column = ((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV39ColumnsSelector.gxTpr_Columns.Item(AV112GXV3));
                  if ( AV41ColumnsSelector_Column.gxTpr_Isvisible )
                  {
                     if ( StringUtil.StrCmp(AV41ColumnsSelector_Column.gxTpr_Columnname, "RubrosId") == 0 )
                     {
                        AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV47VisibleColumnCount), 1, 1).Number = A121RubrosId;
                     }
                     else if ( StringUtil.StrCmp(AV41ColumnsSelector_Column.gxTpr_Columnname, "RubrosImagen") == 0 )
                     {
                        AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV47VisibleColumnCount), 1, 1).Text = "";
                     }
                     else if ( StringUtil.StrCmp(AV41ColumnsSelector_Column.gxTpr_Columnname, "RubrosNombre") == 0 )
                     {
                        GXt_char2 = "";
                        new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A122RubrosNombre, out  GXt_char2) ;
                        AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV47VisibleColumnCount), 1, 1).Text = GXt_char2;
                     }
                     else if ( StringUtil.StrCmp(AV41ColumnsSelector_Column.gxTpr_Columnname, "MedidasNombre") == 0 )
                     {
                        GXt_char2 = "";
                        new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A138MedidasNombre, out  GXt_char2) ;
                        AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV47VisibleColumnCount), 1, 1).Text = GXt_char2;
                     }
                     else if ( StringUtil.StrCmp(AV41ColumnsSelector_Column.gxTpr_Columnname, "TextosId") == 0 )
                     {
                        AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV47VisibleColumnCount), 1, 1).Number = A150TextosId;
                     }
                     else if ( StringUtil.StrCmp(AV41ColumnsSelector_Column.gxTpr_Columnname, "TextosTitulo") == 0 )
                     {
                        GXt_char2 = "";
                        new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A259TextosTitulo, out  GXt_char2) ;
                        AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV47VisibleColumnCount), 1, 1).Text = GXt_char2;
                     }
                     else if ( StringUtil.StrCmp(AV41ColumnsSelector_Column.gxTpr_Columnname, "MedidasEstado") == 0 )
                     {
                        AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV47VisibleColumnCount), 1, 1).Text = context.GetMessage( gxdomainestadoenum.getDescription(context,A139MedidasEstado), "");
                     }
                     AV47VisibleColumnCount = (long)(AV47VisibleColumnCount+1);
                  }
                  AV112GXV3 = (int)(AV112GXV3+1);
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
         AV35Session.Set("WWPExportFileName", "InventarioWWExport.xlsx");
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
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV39ColumnsSelector,  "RubrosId",  "",  "Rubro",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV39ColumnsSelector,  "RubrosImagen",  "",  "",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV39ColumnsSelector,  "RubrosNombre",  "",  "",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV39ColumnsSelector,  "MedidasNombre",  "",  "",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV39ColumnsSelector,  "TextosId",  "",  "#",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV39ColumnsSelector,  "TextosTitulo",  "",  "Terminos y Condiciones",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV39ColumnsSelector,  "MedidasEstado",  "",  "",  true,  "") ;
         GXt_char2 = AV43UserCustomValue;
         new GeneXus.Programs.wwpbaseobjects.loadcolumnsselectorstate(context ).execute(  "InventarioWWColumnsSelector", out  GXt_char2) ;
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
         if ( StringUtil.StrCmp(AV35Session.Get("InventarioWWGridState"), "") == 0 )
         {
            AV37GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "InventarioWWGridState"), null, "", "");
         }
         else
         {
            AV37GridState.FromXml(AV35Session.Get("InventarioWWGridState"), null, "", "");
         }
         AV17OrderedBy = AV37GridState.gxTpr_Orderedby;
         AV18OrderedDsc = AV37GridState.gxTpr_Ordereddsc;
         AV113GXV4 = 1;
         while ( AV113GXV4 <= AV37GridState.gxTpr_Filtervalues.Count )
         {
            AV38GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV37GridState.gxTpr_Filtervalues.Item(AV113GXV4));
            if ( StringUtil.StrCmp(AV38GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV19FilterFullText = AV38GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV38GridStateFilterValue.gxTpr_Name, "TFRUBROSID") == 0 )
            {
               AV50TFRubrosId = (short)(Math.Round(NumberUtil.Val( AV38GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV51TFRubrosId_To = (short)(Math.Round(NumberUtil.Val( AV38GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV38GridStateFilterValue.gxTpr_Name, "TFRUBROSNOMBRE") == 0 )
            {
               AV52TFRubrosNombre = AV38GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV38GridStateFilterValue.gxTpr_Name, "TFRUBROSNOMBRE_SEL") == 0 )
            {
               AV53TFRubrosNombre_Sel = AV38GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV38GridStateFilterValue.gxTpr_Name, "TFMEDIDASNOMBRE") == 0 )
            {
               AV56TFMedidasNombre = AV38GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV38GridStateFilterValue.gxTpr_Name, "TFMEDIDASNOMBRE_SEL") == 0 )
            {
               AV57TFMedidasNombre_Sel = AV38GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV38GridStateFilterValue.gxTpr_Name, "TFTEXTOSID") == 0 )
            {
               AV58TFTextosId = (long)(Math.Round(NumberUtil.Val( AV38GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV59TFTextosId_To = (long)(Math.Round(NumberUtil.Val( AV38GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV38GridStateFilterValue.gxTpr_Name, "TFTEXTOSTITULO") == 0 )
            {
               AV60TFTextosTitulo = AV38GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV38GridStateFilterValue.gxTpr_Name, "TFTEXTOSTITULO_SEL") == 0 )
            {
               AV61TFTextosTitulo_Sel = AV38GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV38GridStateFilterValue.gxTpr_Name, "TFMEDIDASESTADO_SEL") == 0 )
            {
               AV62TFMedidasEstado_SelsJson = AV38GridStateFilterValue.gxTpr_Value;
               AV63TFMedidasEstado_Sels.FromJSonString(AV62TFMedidasEstado_SelsJson, null);
            }
            AV113GXV4 = (int)(AV113GXV4+1);
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
         AV79Pgmname = "";
         GXKey = "";
         GXEncryptionTmp = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV11ExcelDocument = new ExcelDocumentI();
         AV19FilterFullText = "";
         AV37GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV34GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV20DynamicFiltersSelector1 = "";
         AV23RubrosNombre1 = "";
         AV66TextosTipo1 = "";
         AV25DynamicFiltersSelector2 = "";
         AV28RubrosNombre2 = "";
         AV67TextosTipo2 = "";
         AV30DynamicFiltersSelector3 = "";
         AV33RubrosNombre3 = "";
         AV68TextosTipo3 = "";
         AV53TFRubrosNombre_Sel = "";
         AV52TFRubrosNombre = "";
         AV57TFMedidasNombre_Sel = "";
         AV56TFMedidasNombre = "";
         AV61TFTextosTitulo_Sel = "";
         AV60TFTextosTitulo = "";
         AV63TFMedidasEstado_Sels = new GxSimpleCollection<string>();
         AV64TFMedidasEstado_Sel = "";
         AV35Session = context.GetSession();
         AV42ColumnsSelectorXML = "";
         AV39ColumnsSelector = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector(context);
         AV41ColumnsSelector_Column = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column(context);
         AV83Inventariowwds_1_filterfulltext = "";
         AV84Inventariowwds_2_dynamicfiltersselector1 = "";
         AV87Inventariowwds_5_rubrosnombre1 = "";
         AV88Inventariowwds_6_textostipo1 = "";
         AV90Inventariowwds_8_dynamicfiltersselector2 = "";
         AV93Inventariowwds_11_rubrosnombre2 = "";
         AV94Inventariowwds_12_textostipo2 = "";
         AV96Inventariowwds_14_dynamicfiltersselector3 = "";
         AV99Inventariowwds_17_rubrosnombre3 = "";
         AV100Inventariowwds_18_textostipo3 = "";
         AV103Inventariowwds_21_tfrubrosnombre = "";
         AV104Inventariowwds_22_tfrubrosnombre_sel = "";
         AV105Inventariowwds_23_tfmedidasnombre = "";
         AV106Inventariowwds_24_tfmedidasnombre_sel = "";
         AV109Inventariowwds_27_tftextostitulo = "";
         AV110Inventariowwds_28_tftextostitulo_sel = "";
         AV111Inventariowwds_29_tfmedidasestado_sels = new GxSimpleCollection<string>();
         lV87Inventariowwds_5_rubrosnombre1 = "";
         lV88Inventariowwds_6_textostipo1 = "";
         lV93Inventariowwds_11_rubrosnombre2 = "";
         lV94Inventariowwds_12_textostipo2 = "";
         lV99Inventariowwds_17_rubrosnombre3 = "";
         lV100Inventariowwds_18_textostipo3 = "";
         lV103Inventariowwds_21_tfrubrosnombre = "";
         lV105Inventariowwds_23_tfmedidasnombre = "";
         lV109Inventariowwds_27_tftextostitulo = "";
         A139MedidasEstado = "";
         A122RubrosNombre = "";
         A258TextosTipo = "";
         A138MedidasNombre = "";
         A259TextosTitulo = "";
         P00432_A258TextosTipo = new string[] {""} ;
         P00432_A259TextosTitulo = new string[] {""} ;
         P00432_A150TextosId = new long[1] ;
         P00432_n150TextosId = new bool[] {false} ;
         P00432_A138MedidasNombre = new string[] {""} ;
         P00432_A122RubrosNombre = new string[] {""} ;
         P00432_A121RubrosId = new short[1] ;
         P00432_A215RubrosCosto = new decimal[1] ;
         P00432_A139MedidasEstado = new string[] {""} ;
         P00432_n139MedidasEstado = new bool[] {false} ;
         P00432_A137MedidasID = new long[1] ;
         AV43UserCustomValue = "";
         GXt_char2 = "";
         AV40ColumnsSelectorAux = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector(context);
         AV38GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV62TFMedidasEstado_SelsJson = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.inventariowwexport__default(),
            new Object[][] {
                new Object[] {
               P00432_A258TextosTipo, P00432_A259TextosTitulo, P00432_A150TextosId, P00432_n150TextosId, P00432_A138MedidasNombre, P00432_A122RubrosNombre, P00432_A121RubrosId, P00432_A215RubrosCosto, P00432_A139MedidasEstado, P00432_n139MedidasEstado,
               P00432_A137MedidasID
               }
            }
         );
         AV79Pgmname = "InventarioWWExport";
         /* GeneXus formulas. */
         AV79Pgmname = "InventarioWWExport";
      }

      private short AV21DynamicFiltersOperator1 ;
      private short AV26DynamicFiltersOperator2 ;
      private short AV31DynamicFiltersOperator3 ;
      private short AV50TFRubrosId ;
      private short AV51TFRubrosId_To ;
      private short GXt_int3 ;
      private short AV85Inventariowwds_3_dynamicfiltersoperator1 ;
      private short AV91Inventariowwds_9_dynamicfiltersoperator2 ;
      private short AV97Inventariowwds_15_dynamicfiltersoperator3 ;
      private short AV101Inventariowwds_19_tfrubrosid ;
      private short AV102Inventariowwds_20_tfrubrosid_to ;
      private short A121RubrosId ;
      private short AV17OrderedBy ;
      private int AV14CellRow ;
      private int AV15FirstColumn ;
      private int AV16Random ;
      private int AV80GXV1 ;
      private int AV81GXV2 ;
      private int AV111Inventariowwds_29_tfmedidasestado_sels_Count ;
      private int AV112GXV3 ;
      private int AV113GXV4 ;
      private long AV58TFTextosId ;
      private long AV59TFTextosId_To ;
      private long AV65i ;
      private long AV47VisibleColumnCount ;
      private long AV107Inventariowwds_25_tftextosid ;
      private long AV108Inventariowwds_26_tftextosid_to ;
      private long A150TextosId ;
      private long A137MedidasID ;
      private decimal AV22RubrosCosto1 ;
      private decimal AV27RubrosCosto2 ;
      private decimal AV32RubrosCosto3 ;
      private decimal AV86Inventariowwds_4_rubroscosto1 ;
      private decimal AV92Inventariowwds_10_rubroscosto2 ;
      private decimal AV98Inventariowwds_16_rubroscosto3 ;
      private decimal A215RubrosCosto ;
      private string AV79Pgmname ;
      private string GXKey ;
      private string GXEncryptionTmp ;
      private string AV23RubrosNombre1 ;
      private string AV66TextosTipo1 ;
      private string AV28RubrosNombre2 ;
      private string AV67TextosTipo2 ;
      private string AV33RubrosNombre3 ;
      private string AV68TextosTipo3 ;
      private string AV53TFRubrosNombre_Sel ;
      private string AV52TFRubrosNombre ;
      private string AV57TFMedidasNombre_Sel ;
      private string AV56TFMedidasNombre ;
      private string AV61TFTextosTitulo_Sel ;
      private string AV60TFTextosTitulo ;
      private string AV64TFMedidasEstado_Sel ;
      private string AV87Inventariowwds_5_rubrosnombre1 ;
      private string AV88Inventariowwds_6_textostipo1 ;
      private string AV93Inventariowwds_11_rubrosnombre2 ;
      private string AV94Inventariowwds_12_textostipo2 ;
      private string AV99Inventariowwds_17_rubrosnombre3 ;
      private string AV100Inventariowwds_18_textostipo3 ;
      private string AV103Inventariowwds_21_tfrubrosnombre ;
      private string AV104Inventariowwds_22_tfrubrosnombre_sel ;
      private string AV105Inventariowwds_23_tfmedidasnombre ;
      private string AV106Inventariowwds_24_tfmedidasnombre_sel ;
      private string AV109Inventariowwds_27_tftextostitulo ;
      private string AV110Inventariowwds_28_tftextostitulo_sel ;
      private string lV87Inventariowwds_5_rubrosnombre1 ;
      private string lV88Inventariowwds_6_textostipo1 ;
      private string lV93Inventariowwds_11_rubrosnombre2 ;
      private string lV94Inventariowwds_12_textostipo2 ;
      private string lV99Inventariowwds_17_rubrosnombre3 ;
      private string lV100Inventariowwds_18_textostipo3 ;
      private string lV103Inventariowwds_21_tfrubrosnombre ;
      private string lV105Inventariowwds_23_tfmedidasnombre ;
      private string lV109Inventariowwds_27_tftextostitulo ;
      private string A139MedidasEstado ;
      private string A122RubrosNombre ;
      private string A258TextosTipo ;
      private string A138MedidasNombre ;
      private string A259TextosTitulo ;
      private string GXt_char2 ;
      private bool AV8IsAuthorized ;
      private bool GXt_boolean1 ;
      private bool returnInSub ;
      private bool AV24DynamicFiltersEnabled2 ;
      private bool AV29DynamicFiltersEnabled3 ;
      private bool AV89Inventariowwds_7_dynamicfiltersenabled2 ;
      private bool AV95Inventariowwds_13_dynamicfiltersenabled3 ;
      private bool AV18OrderedDsc ;
      private bool n150TextosId ;
      private bool n139MedidasEstado ;
      private string AV42ColumnsSelectorXML ;
      private string AV43UserCustomValue ;
      private string AV62TFMedidasEstado_SelsJson ;
      private string AV12Filename ;
      private string AV13ErrorMessage ;
      private string AV19FilterFullText ;
      private string AV20DynamicFiltersSelector1 ;
      private string AV25DynamicFiltersSelector2 ;
      private string AV30DynamicFiltersSelector3 ;
      private string AV83Inventariowwds_1_filterfulltext ;
      private string AV84Inventariowwds_2_dynamicfiltersselector1 ;
      private string AV90Inventariowwds_8_dynamicfiltersselector2 ;
      private string AV96Inventariowwds_14_dynamicfiltersselector3 ;
      private IGxSession AV35Session ;
      private ExcelDocumentI AV11ExcelDocument ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV37GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV34GridStateDynamicFilter ;
      private GxSimpleCollection<string> AV63TFMedidasEstado_Sels ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector AV39ColumnsSelector ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column AV41ColumnsSelector_Column ;
      private GxSimpleCollection<string> AV111Inventariowwds_29_tfmedidasestado_sels ;
      private IDataStoreProvider pr_default ;
      private string[] P00432_A258TextosTipo ;
      private string[] P00432_A259TextosTitulo ;
      private long[] P00432_A150TextosId ;
      private bool[] P00432_n150TextosId ;
      private string[] P00432_A138MedidasNombre ;
      private string[] P00432_A122RubrosNombre ;
      private short[] P00432_A121RubrosId ;
      private decimal[] P00432_A215RubrosCosto ;
      private string[] P00432_A139MedidasEstado ;
      private bool[] P00432_n139MedidasEstado ;
      private long[] P00432_A137MedidasID ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector AV40ColumnsSelectorAux ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV38GridStateFilterValue ;
      private string aP0_Filename ;
      private string aP1_ErrorMessage ;
   }

   public class inventariowwexport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00432( IGxContext context ,
                                             string A139MedidasEstado ,
                                             GxSimpleCollection<string> AV111Inventariowwds_29_tfmedidasestado_sels ,
                                             string AV84Inventariowwds_2_dynamicfiltersselector1 ,
                                             short AV85Inventariowwds_3_dynamicfiltersoperator1 ,
                                             decimal AV86Inventariowwds_4_rubroscosto1 ,
                                             string AV87Inventariowwds_5_rubrosnombre1 ,
                                             string AV88Inventariowwds_6_textostipo1 ,
                                             bool AV89Inventariowwds_7_dynamicfiltersenabled2 ,
                                             string AV90Inventariowwds_8_dynamicfiltersselector2 ,
                                             short AV91Inventariowwds_9_dynamicfiltersoperator2 ,
                                             decimal AV92Inventariowwds_10_rubroscosto2 ,
                                             string AV93Inventariowwds_11_rubrosnombre2 ,
                                             string AV94Inventariowwds_12_textostipo2 ,
                                             bool AV95Inventariowwds_13_dynamicfiltersenabled3 ,
                                             string AV96Inventariowwds_14_dynamicfiltersselector3 ,
                                             short AV97Inventariowwds_15_dynamicfiltersoperator3 ,
                                             decimal AV98Inventariowwds_16_rubroscosto3 ,
                                             string AV99Inventariowwds_17_rubrosnombre3 ,
                                             string AV100Inventariowwds_18_textostipo3 ,
                                             short AV101Inventariowwds_19_tfrubrosid ,
                                             short AV102Inventariowwds_20_tfrubrosid_to ,
                                             string AV104Inventariowwds_22_tfrubrosnombre_sel ,
                                             string AV103Inventariowwds_21_tfrubrosnombre ,
                                             string AV106Inventariowwds_24_tfmedidasnombre_sel ,
                                             string AV105Inventariowwds_23_tfmedidasnombre ,
                                             long AV107Inventariowwds_25_tftextosid ,
                                             long AV108Inventariowwds_26_tftextosid_to ,
                                             string AV110Inventariowwds_28_tftextostitulo_sel ,
                                             string AV109Inventariowwds_27_tftextostitulo ,
                                             int AV111Inventariowwds_29_tfmedidasestado_sels_Count ,
                                             decimal A215RubrosCosto ,
                                             string A122RubrosNombre ,
                                             string A258TextosTipo ,
                                             short A121RubrosId ,
                                             string A138MedidasNombre ,
                                             long A150TextosId ,
                                             string A259TextosTitulo ,
                                             short AV17OrderedBy ,
                                             bool AV18OrderedDsc ,
                                             string AV83Inventariowwds_1_filterfulltext )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int4 = new short[31];
         Object[] GXv_Object5 = new Object[2];
         scmdbuf = "SELECT T2.[TextosTipo], T2.[TextosTitulo], T1.[TextosId], T1.[MedidasNombre], T3.[RubrosNombre], T1.[RubrosId], T1.[RubrosCosto], T1.[MedidasEstado], T1.[MedidasID] FROM (([RubrosMedidas] T1 LEFT JOIN [Textos] T2 ON T2.[TextosId] = T1.[TextosId]) INNER JOIN [Rubros] T3 ON T3.[RubrosId] = T1.[RubrosId])";
         if ( ( StringUtil.StrCmp(AV84Inventariowwds_2_dynamicfiltersselector1, "RUBROSCOSTO") == 0 ) && ( AV85Inventariowwds_3_dynamicfiltersoperator1 == 0 ) && ( ! (Convert.ToDecimal(0)==AV86Inventariowwds_4_rubroscosto1) ) )
         {
            AddWhere(sWhereString, "(T1.[RubrosCosto] < @AV86Inventariowwds_4_rubroscosto1)");
         }
         else
         {
            GXv_int4[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV84Inventariowwds_2_dynamicfiltersselector1, "RUBROSCOSTO") == 0 ) && ( AV85Inventariowwds_3_dynamicfiltersoperator1 == 1 ) && ( ! (Convert.ToDecimal(0)==AV86Inventariowwds_4_rubroscosto1) ) )
         {
            AddWhere(sWhereString, "(T1.[RubrosCosto] = @AV86Inventariowwds_4_rubroscosto1)");
         }
         else
         {
            GXv_int4[1] = 1;
         }
         if ( ( StringUtil.StrCmp(AV84Inventariowwds_2_dynamicfiltersselector1, "RUBROSCOSTO") == 0 ) && ( AV85Inventariowwds_3_dynamicfiltersoperator1 == 2 ) && ( ! (Convert.ToDecimal(0)==AV86Inventariowwds_4_rubroscosto1) ) )
         {
            AddWhere(sWhereString, "(T1.[RubrosCosto] > @AV86Inventariowwds_4_rubroscosto1)");
         }
         else
         {
            GXv_int4[2] = 1;
         }
         if ( ( StringUtil.StrCmp(AV84Inventariowwds_2_dynamicfiltersselector1, "RUBROSNOMBRE") == 0 ) && ( AV85Inventariowwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV87Inventariowwds_5_rubrosnombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T3.[RubrosNombre]) like UPPER(@lV87Inventariowwds_5_rubrosnombre1))");
         }
         else
         {
            GXv_int4[3] = 1;
         }
         if ( ( StringUtil.StrCmp(AV84Inventariowwds_2_dynamicfiltersselector1, "RUBROSNOMBRE") == 0 ) && ( AV85Inventariowwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV87Inventariowwds_5_rubrosnombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T3.[RubrosNombre]) like '%' + UPPER(@lV87Inventariowwds_5_rubrosnombre1))");
         }
         else
         {
            GXv_int4[4] = 1;
         }
         if ( ( StringUtil.StrCmp(AV84Inventariowwds_2_dynamicfiltersselector1, "TEXTOSTIPO") == 0 ) && ( AV85Inventariowwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV88Inventariowwds_6_textostipo1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[TextosTipo]) like UPPER(@lV88Inventariowwds_6_textostipo1))");
         }
         else
         {
            GXv_int4[5] = 1;
         }
         if ( ( StringUtil.StrCmp(AV84Inventariowwds_2_dynamicfiltersselector1, "TEXTOSTIPO") == 0 ) && ( AV85Inventariowwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV88Inventariowwds_6_textostipo1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[TextosTipo]) like '%' + UPPER(@lV88Inventariowwds_6_textostipo1))");
         }
         else
         {
            GXv_int4[6] = 1;
         }
         if ( AV89Inventariowwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV90Inventariowwds_8_dynamicfiltersselector2, "RUBROSCOSTO") == 0 ) && ( AV91Inventariowwds_9_dynamicfiltersoperator2 == 0 ) && ( ! (Convert.ToDecimal(0)==AV92Inventariowwds_10_rubroscosto2) ) )
         {
            AddWhere(sWhereString, "(T1.[RubrosCosto] < @AV92Inventariowwds_10_rubroscosto2)");
         }
         else
         {
            GXv_int4[7] = 1;
         }
         if ( AV89Inventariowwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV90Inventariowwds_8_dynamicfiltersselector2, "RUBROSCOSTO") == 0 ) && ( AV91Inventariowwds_9_dynamicfiltersoperator2 == 1 ) && ( ! (Convert.ToDecimal(0)==AV92Inventariowwds_10_rubroscosto2) ) )
         {
            AddWhere(sWhereString, "(T1.[RubrosCosto] = @AV92Inventariowwds_10_rubroscosto2)");
         }
         else
         {
            GXv_int4[8] = 1;
         }
         if ( AV89Inventariowwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV90Inventariowwds_8_dynamicfiltersselector2, "RUBROSCOSTO") == 0 ) && ( AV91Inventariowwds_9_dynamicfiltersoperator2 == 2 ) && ( ! (Convert.ToDecimal(0)==AV92Inventariowwds_10_rubroscosto2) ) )
         {
            AddWhere(sWhereString, "(T1.[RubrosCosto] > @AV92Inventariowwds_10_rubroscosto2)");
         }
         else
         {
            GXv_int4[9] = 1;
         }
         if ( AV89Inventariowwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV90Inventariowwds_8_dynamicfiltersselector2, "RUBROSNOMBRE") == 0 ) && ( AV91Inventariowwds_9_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV93Inventariowwds_11_rubrosnombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T3.[RubrosNombre]) like UPPER(@lV93Inventariowwds_11_rubrosnombre2))");
         }
         else
         {
            GXv_int4[10] = 1;
         }
         if ( AV89Inventariowwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV90Inventariowwds_8_dynamicfiltersselector2, "RUBROSNOMBRE") == 0 ) && ( AV91Inventariowwds_9_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV93Inventariowwds_11_rubrosnombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T3.[RubrosNombre]) like '%' + UPPER(@lV93Inventariowwds_11_rubrosnombre2))");
         }
         else
         {
            GXv_int4[11] = 1;
         }
         if ( AV89Inventariowwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV90Inventariowwds_8_dynamicfiltersselector2, "TEXTOSTIPO") == 0 ) && ( AV91Inventariowwds_9_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV94Inventariowwds_12_textostipo2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[TextosTipo]) like UPPER(@lV94Inventariowwds_12_textostipo2))");
         }
         else
         {
            GXv_int4[12] = 1;
         }
         if ( AV89Inventariowwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV90Inventariowwds_8_dynamicfiltersselector2, "TEXTOSTIPO") == 0 ) && ( AV91Inventariowwds_9_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV94Inventariowwds_12_textostipo2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[TextosTipo]) like '%' + UPPER(@lV94Inventariowwds_12_textostipo2))");
         }
         else
         {
            GXv_int4[13] = 1;
         }
         if ( AV95Inventariowwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV96Inventariowwds_14_dynamicfiltersselector3, "RUBROSCOSTO") == 0 ) && ( AV97Inventariowwds_15_dynamicfiltersoperator3 == 0 ) && ( ! (Convert.ToDecimal(0)==AV98Inventariowwds_16_rubroscosto3) ) )
         {
            AddWhere(sWhereString, "(T1.[RubrosCosto] < @AV98Inventariowwds_16_rubroscosto3)");
         }
         else
         {
            GXv_int4[14] = 1;
         }
         if ( AV95Inventariowwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV96Inventariowwds_14_dynamicfiltersselector3, "RUBROSCOSTO") == 0 ) && ( AV97Inventariowwds_15_dynamicfiltersoperator3 == 1 ) && ( ! (Convert.ToDecimal(0)==AV98Inventariowwds_16_rubroscosto3) ) )
         {
            AddWhere(sWhereString, "(T1.[RubrosCosto] = @AV98Inventariowwds_16_rubroscosto3)");
         }
         else
         {
            GXv_int4[15] = 1;
         }
         if ( AV95Inventariowwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV96Inventariowwds_14_dynamicfiltersselector3, "RUBROSCOSTO") == 0 ) && ( AV97Inventariowwds_15_dynamicfiltersoperator3 == 2 ) && ( ! (Convert.ToDecimal(0)==AV98Inventariowwds_16_rubroscosto3) ) )
         {
            AddWhere(sWhereString, "(T1.[RubrosCosto] > @AV98Inventariowwds_16_rubroscosto3)");
         }
         else
         {
            GXv_int4[16] = 1;
         }
         if ( AV95Inventariowwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV96Inventariowwds_14_dynamicfiltersselector3, "RUBROSNOMBRE") == 0 ) && ( AV97Inventariowwds_15_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV99Inventariowwds_17_rubrosnombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T3.[RubrosNombre]) like UPPER(@lV99Inventariowwds_17_rubrosnombre3))");
         }
         else
         {
            GXv_int4[17] = 1;
         }
         if ( AV95Inventariowwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV96Inventariowwds_14_dynamicfiltersselector3, "RUBROSNOMBRE") == 0 ) && ( AV97Inventariowwds_15_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV99Inventariowwds_17_rubrosnombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T3.[RubrosNombre]) like '%' + UPPER(@lV99Inventariowwds_17_rubrosnombre3))");
         }
         else
         {
            GXv_int4[18] = 1;
         }
         if ( AV95Inventariowwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV96Inventariowwds_14_dynamicfiltersselector3, "TEXTOSTIPO") == 0 ) && ( AV97Inventariowwds_15_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV100Inventariowwds_18_textostipo3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[TextosTipo]) like UPPER(@lV100Inventariowwds_18_textostipo3))");
         }
         else
         {
            GXv_int4[19] = 1;
         }
         if ( AV95Inventariowwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV96Inventariowwds_14_dynamicfiltersselector3, "TEXTOSTIPO") == 0 ) && ( AV97Inventariowwds_15_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV100Inventariowwds_18_textostipo3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[TextosTipo]) like '%' + UPPER(@lV100Inventariowwds_18_textostipo3))");
         }
         else
         {
            GXv_int4[20] = 1;
         }
         if ( ! (0==AV101Inventariowwds_19_tfrubrosid) )
         {
            AddWhere(sWhereString, "(T1.[RubrosId] >= @AV101Inventariowwds_19_tfrubrosid)");
         }
         else
         {
            GXv_int4[21] = 1;
         }
         if ( ! (0==AV102Inventariowwds_20_tfrubrosid_to) )
         {
            AddWhere(sWhereString, "(T1.[RubrosId] <= @AV102Inventariowwds_20_tfrubrosid_to)");
         }
         else
         {
            GXv_int4[22] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV104Inventariowwds_22_tfrubrosnombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV103Inventariowwds_21_tfrubrosnombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T3.[RubrosNombre]) like UPPER(@lV103Inventariowwds_21_tfrubrosnombre))");
         }
         else
         {
            GXv_int4[23] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV104Inventariowwds_22_tfrubrosnombre_sel)) && ! ( StringUtil.StrCmp(AV104Inventariowwds_22_tfrubrosnombre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T3.[RubrosNombre] = @AV104Inventariowwds_22_tfrubrosnombre_sel)");
         }
         else
         {
            GXv_int4[24] = 1;
         }
         if ( StringUtil.StrCmp(AV104Inventariowwds_22_tfrubrosnombre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T3.[RubrosNombre] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV106Inventariowwds_24_tfmedidasnombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV105Inventariowwds_23_tfmedidasnombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[MedidasNombre]) like UPPER(@lV105Inventariowwds_23_tfmedidasnombre))");
         }
         else
         {
            GXv_int4[25] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV106Inventariowwds_24_tfmedidasnombre_sel)) && ! ( StringUtil.StrCmp(AV106Inventariowwds_24_tfmedidasnombre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[MedidasNombre] = @AV106Inventariowwds_24_tfmedidasnombre_sel)");
         }
         else
         {
            GXv_int4[26] = 1;
         }
         if ( StringUtil.StrCmp(AV106Inventariowwds_24_tfmedidasnombre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[MedidasNombre] = ''))");
         }
         if ( ! (0==AV107Inventariowwds_25_tftextosid) )
         {
            AddWhere(sWhereString, "(T1.[TextosId] >= @AV107Inventariowwds_25_tftextosid)");
         }
         else
         {
            GXv_int4[27] = 1;
         }
         if ( ! (0==AV108Inventariowwds_26_tftextosid_to) )
         {
            AddWhere(sWhereString, "(T1.[TextosId] <= @AV108Inventariowwds_26_tftextosid_to)");
         }
         else
         {
            GXv_int4[28] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV110Inventariowwds_28_tftextostitulo_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV109Inventariowwds_27_tftextostitulo)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[TextosTitulo]) like UPPER(@lV109Inventariowwds_27_tftextostitulo))");
         }
         else
         {
            GXv_int4[29] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV110Inventariowwds_28_tftextostitulo_sel)) && ! ( StringUtil.StrCmp(AV110Inventariowwds_28_tftextostitulo_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.[TextosTitulo] = @AV110Inventariowwds_28_tftextostitulo_sel)");
         }
         else
         {
            GXv_int4[30] = 1;
         }
         if ( StringUtil.StrCmp(AV110Inventariowwds_28_tftextostitulo_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T2.[TextosTitulo] IS NULL or (T2.[TextosTitulo] = ''))");
         }
         if ( AV111Inventariowwds_29_tfmedidasestado_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV111Inventariowwds_29_tfmedidasestado_sels, "T1.[MedidasEstado] IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         if ( AV17OrderedBy == 1 )
         {
            scmdbuf += " ORDER BY T1.[RubrosCosto]";
         }
         else if ( ( AV17OrderedBy == 2 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T3.[RubrosNombre], T1.[RubrosId]";
         }
         else if ( ( AV17OrderedBy == 2 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T3.[RubrosNombre] DESC, T1.[RubrosId] DESC";
         }
         else if ( ( AV17OrderedBy == 3 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T3.[RubrosNombre]";
         }
         else if ( ( AV17OrderedBy == 3 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T3.[RubrosNombre] DESC";
         }
         else if ( ( AV17OrderedBy == 4 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T3.[RubrosNombre], T1.[MedidasNombre]";
         }
         else if ( ( AV17OrderedBy == 4 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T3.[RubrosNombre] DESC, T1.[MedidasNombre] DESC";
         }
         else if ( ( AV17OrderedBy == 5 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T3.[RubrosNombre], T1.[TextosId]";
         }
         else if ( ( AV17OrderedBy == 5 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T3.[RubrosNombre] DESC, T1.[TextosId] DESC";
         }
         else if ( ( AV17OrderedBy == 6 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T3.[RubrosNombre], T2.[TextosTitulo]";
         }
         else if ( ( AV17OrderedBy == 6 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T3.[RubrosNombre] DESC, T2.[TextosTitulo] DESC";
         }
         else if ( ( AV17OrderedBy == 7 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T3.[RubrosNombre], T1.[MedidasEstado]";
         }
         else if ( ( AV17OrderedBy == 7 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T3.[RubrosNombre] DESC, T1.[MedidasEstado] DESC";
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
                     return conditional_P00432(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (decimal)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (bool)dynConstraints[7] , (string)dynConstraints[8] , (short)dynConstraints[9] , (decimal)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (bool)dynConstraints[13] , (string)dynConstraints[14] , (short)dynConstraints[15] , (decimal)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (short)dynConstraints[19] , (short)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (long)dynConstraints[25] , (long)dynConstraints[26] , (string)dynConstraints[27] , (string)dynConstraints[28] , (int)dynConstraints[29] , (decimal)dynConstraints[30] , (string)dynConstraints[31] , (string)dynConstraints[32] , (short)dynConstraints[33] , (string)dynConstraints[34] , (long)dynConstraints[35] , (string)dynConstraints[36] , (short)dynConstraints[37] , (bool)dynConstraints[38] , (string)dynConstraints[39] );
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
          Object[] prmP00432;
          prmP00432 = new Object[] {
          new ParDef("@AV86Inventariowwds_4_rubroscosto1",GXType.Decimal,18,2) ,
          new ParDef("@AV86Inventariowwds_4_rubroscosto1",GXType.Decimal,18,2) ,
          new ParDef("@AV86Inventariowwds_4_rubroscosto1",GXType.Decimal,18,2) ,
          new ParDef("@lV87Inventariowwds_5_rubrosnombre1",GXType.Char,100,0) ,
          new ParDef("@lV87Inventariowwds_5_rubrosnombre1",GXType.Char,100,0) ,
          new ParDef("@lV88Inventariowwds_6_textostipo1",GXType.Char,20,0) ,
          new ParDef("@lV88Inventariowwds_6_textostipo1",GXType.Char,20,0) ,
          new ParDef("@AV92Inventariowwds_10_rubroscosto2",GXType.Decimal,18,2) ,
          new ParDef("@AV92Inventariowwds_10_rubroscosto2",GXType.Decimal,18,2) ,
          new ParDef("@AV92Inventariowwds_10_rubroscosto2",GXType.Decimal,18,2) ,
          new ParDef("@lV93Inventariowwds_11_rubrosnombre2",GXType.Char,100,0) ,
          new ParDef("@lV93Inventariowwds_11_rubrosnombre2",GXType.Char,100,0) ,
          new ParDef("@lV94Inventariowwds_12_textostipo2",GXType.Char,20,0) ,
          new ParDef("@lV94Inventariowwds_12_textostipo2",GXType.Char,20,0) ,
          new ParDef("@AV98Inventariowwds_16_rubroscosto3",GXType.Decimal,18,2) ,
          new ParDef("@AV98Inventariowwds_16_rubroscosto3",GXType.Decimal,18,2) ,
          new ParDef("@AV98Inventariowwds_16_rubroscosto3",GXType.Decimal,18,2) ,
          new ParDef("@lV99Inventariowwds_17_rubrosnombre3",GXType.Char,100,0) ,
          new ParDef("@lV99Inventariowwds_17_rubrosnombre3",GXType.Char,100,0) ,
          new ParDef("@lV100Inventariowwds_18_textostipo3",GXType.Char,20,0) ,
          new ParDef("@lV100Inventariowwds_18_textostipo3",GXType.Char,20,0) ,
          new ParDef("@AV101Inventariowwds_19_tfrubrosid",GXType.Int16,4,0) ,
          new ParDef("@AV102Inventariowwds_20_tfrubrosid_to",GXType.Int16,4,0) ,
          new ParDef("@lV103Inventariowwds_21_tfrubrosnombre",GXType.Char,100,0) ,
          new ParDef("@AV104Inventariowwds_22_tfrubrosnombre_sel",GXType.NChar,100,0) ,
          new ParDef("@lV105Inventariowwds_23_tfmedidasnombre",GXType.Char,50,0) ,
          new ParDef("@AV106Inventariowwds_24_tfmedidasnombre_sel",GXType.NChar,50,0) ,
          new ParDef("@AV107Inventariowwds_25_tftextosid",GXType.Decimal,18,0) ,
          new ParDef("@AV108Inventariowwds_26_tftextosid_to",GXType.Decimal,18,0) ,
          new ParDef("@lV109Inventariowwds_27_tftextostitulo",GXType.Char,80,0) ,
          new ParDef("@AV110Inventariowwds_28_tftextostitulo_sel",GXType.NChar,80,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00432", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00432,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[0])[0] = rslt.getString(1, 20);
                ((string[]) buf[1])[0] = rslt.getString(2, 80);
                ((long[]) buf[2])[0] = rslt.getLong(3);
                ((bool[]) buf[3])[0] = rslt.wasNull(3);
                ((string[]) buf[4])[0] = rslt.getString(4, 50);
                ((string[]) buf[5])[0] = rslt.getString(5, 100);
                ((short[]) buf[6])[0] = rslt.getShort(6);
                ((decimal[]) buf[7])[0] = rslt.getDecimal(7);
                ((string[]) buf[8])[0] = rslt.getString(8, 3);
                ((bool[]) buf[9])[0] = rslt.wasNull(8);
                ((long[]) buf[10])[0] = rslt.getLong(9);
                return;
       }
    }

 }

}

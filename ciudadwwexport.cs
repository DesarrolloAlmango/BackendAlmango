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
   public class ciudadwwexport : GXProcedure
   {
      public ciudadwwexport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public ciudadwwexport( IGxContext context )
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
         new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWCiudad", out  GXt_boolean1) ;
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
         AV12Filename = GXt_char2 + "CiudadWWExport-" + StringUtil.Trim( StringUtil.Str( (decimal)(AV16Random), 8, 0)) + ".xlsx";
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
            if ( StringUtil.StrCmp(AV20DynamicFiltersSelector1, "CIUDADNOMBRE") == 0 )
            {
               AV21DynamicFiltersOperator1 = AV34GridStateDynamicFilter.gxTpr_Operator;
               AV22CiudadNombre1 = AV34GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV22CiudadNombre1)) )
               {
                  AV14CellRow = (int)(AV14CellRow+1);
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Bold = 1;
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Color = 3;
                  if ( AV21DynamicFiltersOperator1 == 0 )
                  {
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "", context.GetMessage( "WWP_FilterLike", ""), "", "", "", "", "", "", "");
                  }
                  else if ( AV21DynamicFiltersOperator1 == 1 )
                  {
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "", context.GetMessage( "WWP_FilterContains", ""), "", "", "", "", "", "", "");
                  }
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Italic = 1;
                  GXt_char2 = "";
                  new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV22CiudadNombre1, out  GXt_char2) ;
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
               }
            }
            else if ( StringUtil.StrCmp(AV20DynamicFiltersSelector1, "PAISNOMBRE") == 0 )
            {
               AV21DynamicFiltersOperator1 = AV34GridStateDynamicFilter.gxTpr_Operator;
               AV23PaisNombre1 = AV34GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV23PaisNombre1)) )
               {
                  AV14CellRow = (int)(AV14CellRow+1);
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Bold = 1;
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Color = 3;
                  if ( AV21DynamicFiltersOperator1 == 0 )
                  {
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", context.GetMessage( "Pais", ""), context.GetMessage( "WWP_FilterLike", ""), "", "", "", "", "", "", "");
                  }
                  else if ( AV21DynamicFiltersOperator1 == 1 )
                  {
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", context.GetMessage( "Pais", ""), context.GetMessage( "WWP_FilterContains", ""), "", "", "", "", "", "", "");
                  }
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Italic = 1;
                  GXt_char2 = "";
                  new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV23PaisNombre1, out  GXt_char2) ;
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
               }
            }
            if ( AV37GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV24DynamicFiltersEnabled2 = true;
               AV34GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV37GridState.gxTpr_Dynamicfilters.Item(2));
               AV25DynamicFiltersSelector2 = AV34GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV25DynamicFiltersSelector2, "CIUDADNOMBRE") == 0 )
               {
                  AV26DynamicFiltersOperator2 = AV34GridStateDynamicFilter.gxTpr_Operator;
                  AV27CiudadNombre2 = AV34GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV27CiudadNombre2)) )
                  {
                     AV14CellRow = (int)(AV14CellRow+1);
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Bold = 1;
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Color = 3;
                     if ( AV26DynamicFiltersOperator2 == 0 )
                     {
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "", context.GetMessage( "WWP_FilterLike", ""), "", "", "", "", "", "", "");
                     }
                     else if ( AV26DynamicFiltersOperator2 == 1 )
                     {
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "", context.GetMessage( "WWP_FilterContains", ""), "", "", "", "", "", "", "");
                     }
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Italic = 1;
                     GXt_char2 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV27CiudadNombre2, out  GXt_char2) ;
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
                  }
               }
               else if ( StringUtil.StrCmp(AV25DynamicFiltersSelector2, "PAISNOMBRE") == 0 )
               {
                  AV26DynamicFiltersOperator2 = AV34GridStateDynamicFilter.gxTpr_Operator;
                  AV28PaisNombre2 = AV34GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV28PaisNombre2)) )
                  {
                     AV14CellRow = (int)(AV14CellRow+1);
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Bold = 1;
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Color = 3;
                     if ( AV26DynamicFiltersOperator2 == 0 )
                     {
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", context.GetMessage( "Pais", ""), context.GetMessage( "WWP_FilterLike", ""), "", "", "", "", "", "", "");
                     }
                     else if ( AV26DynamicFiltersOperator2 == 1 )
                     {
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", context.GetMessage( "Pais", ""), context.GetMessage( "WWP_FilterContains", ""), "", "", "", "", "", "", "");
                     }
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Italic = 1;
                     GXt_char2 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV28PaisNombre2, out  GXt_char2) ;
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
                  }
               }
               if ( AV37GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV29DynamicFiltersEnabled3 = true;
                  AV34GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV37GridState.gxTpr_Dynamicfilters.Item(3));
                  AV30DynamicFiltersSelector3 = AV34GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV30DynamicFiltersSelector3, "CIUDADNOMBRE") == 0 )
                  {
                     AV31DynamicFiltersOperator3 = AV34GridStateDynamicFilter.gxTpr_Operator;
                     AV32CiudadNombre3 = AV34GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV32CiudadNombre3)) )
                     {
                        AV14CellRow = (int)(AV14CellRow+1);
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Bold = 1;
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Color = 3;
                        if ( AV31DynamicFiltersOperator3 == 0 )
                        {
                           AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "", context.GetMessage( "WWP_FilterLike", ""), "", "", "", "", "", "", "");
                        }
                        else if ( AV31DynamicFiltersOperator3 == 1 )
                        {
                           AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "", context.GetMessage( "WWP_FilterContains", ""), "", "", "", "", "", "", "");
                        }
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Italic = 1;
                        GXt_char2 = "";
                        new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV32CiudadNombre3, out  GXt_char2) ;
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
                     }
                  }
                  else if ( StringUtil.StrCmp(AV30DynamicFiltersSelector3, "PAISNOMBRE") == 0 )
                  {
                     AV31DynamicFiltersOperator3 = AV34GridStateDynamicFilter.gxTpr_Operator;
                     AV33PaisNombre3 = AV34GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV33PaisNombre3)) )
                     {
                        AV14CellRow = (int)(AV14CellRow+1);
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Bold = 1;
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Color = 3;
                        if ( AV31DynamicFiltersOperator3 == 0 )
                        {
                           AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", context.GetMessage( "Pais", ""), context.GetMessage( "WWP_FilterLike", ""), "", "", "", "", "", "", "");
                        }
                        else if ( AV31DynamicFiltersOperator3 == 1 )
                        {
                           AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", context.GetMessage( "Pais", ""), context.GetMessage( "WWP_FilterContains", ""), "", "", "", "", "", "", "");
                        }
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Italic = 1;
                        GXt_char2 = "";
                        new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV33PaisNombre3, out  GXt_char2) ;
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
                     }
                  }
               }
            }
         }
         if ( ! ( (0==AV50TFCiudadId) && (0==AV51TFCiudadId_To) ) )
         {
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Ciudad", "")) ;
            AV14CellRow = GXt_int3;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Number = AV50TFCiudadId;
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  false, ref  GXt_int3,  (short)(AV15FirstColumn+2),  context.GetMessage( "WWP_TSTo", "")) ;
            AV14CellRow = GXt_int3;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+3, 1, 1).Number = AV51TFCiudadId_To;
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV53TFPaisID_Sel)) ) )
         {
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Pais", "")) ;
            AV14CellRow = GXt_int3;
            GXt_char2 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV53TFPaisID_Sel)) ? context.GetMessage( "WWP_TitleFilter_EmptyOption", "") : AV53TFPaisID_Sel), out  GXt_char2) ;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV52TFPaisID)) ) )
            {
               GXt_int3 = (short)(AV14CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Pais", "")) ;
               AV14CellRow = GXt_int3;
               GXt_char2 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV52TFPaisID, out  GXt_char2) ;
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV55TFPaisNombre_Sel)) ) )
         {
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  "") ;
            AV14CellRow = GXt_int3;
            GXt_char2 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV55TFPaisNombre_Sel)) ? context.GetMessage( "WWP_TitleFilter_EmptyOption", "") : AV55TFPaisNombre_Sel), out  GXt_char2) ;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV54TFPaisNombre)) ) )
            {
               GXt_int3 = (short)(AV14CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  "") ;
               AV14CellRow = GXt_int3;
               GXt_char2 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV54TFPaisNombre, out  GXt_char2) ;
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV57TFCiudadNombre_Sel)) ) )
         {
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  "") ;
            AV14CellRow = GXt_int3;
            GXt_char2 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV57TFCiudadNombre_Sel)) ? context.GetMessage( "WWP_TitleFilter_EmptyOption", "") : AV57TFCiudadNombre_Sel), out  GXt_char2) ;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV56TFCiudadNombre)) ) )
            {
               GXt_int3 = (short)(AV14CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  "") ;
               AV14CellRow = GXt_int3;
               GXt_char2 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV56TFCiudadNombre, out  GXt_char2) ;
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
            }
         }
         AV14CellRow = (int)(AV14CellRow+2);
      }

      protected void S141( )
      {
         /* 'WRITECOLUMNTITLES' Routine */
         returnInSub = false;
         AV47VisibleColumnCount = 0;
         if ( StringUtil.StrCmp(AV35Session.Get("CiudadWWColumnsSelector"), "") != 0 )
         {
            AV42ColumnsSelectorXML = AV35Session.Get("CiudadWWColumnsSelector");
            AV39ColumnsSelector.FromXml(AV42ColumnsSelectorXML, null, "", "");
         }
         else
         {
            /* Execute user subroutine: 'INITIALIZECOLUMNSSELECTOR' */
            S151 ();
            if (returnInSub) return;
         }
         AV39ColumnsSelector.gxTpr_Columns.Sort("Order");
         AV60GXV1 = 1;
         while ( AV60GXV1 <= AV39ColumnsSelector.gxTpr_Columns.Count )
         {
            AV41ColumnsSelector_Column = ((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV39ColumnsSelector.gxTpr_Columns.Item(AV60GXV1));
            if ( AV41ColumnsSelector_Column.gxTpr_Isvisible )
            {
               AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV47VisibleColumnCount), 1, 1).Text = context.GetMessage( (String.IsNullOrEmpty(StringUtil.RTrim( AV41ColumnsSelector_Column.gxTpr_Displayname)) ? AV41ColumnsSelector_Column.gxTpr_Columnname : AV41ColumnsSelector_Column.gxTpr_Displayname), "");
               AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV47VisibleColumnCount), 1, 1).Bold = 1;
               AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV47VisibleColumnCount), 1, 1).Color = 11;
               AV47VisibleColumnCount = (long)(AV47VisibleColumnCount+1);
            }
            AV60GXV1 = (int)(AV60GXV1+1);
         }
      }

      protected void S161( )
      {
         /* 'WRITEDATA' Routine */
         returnInSub = false;
         AV62Ciudadwwds_1_filterfulltext = AV19FilterFullText;
         AV63Ciudadwwds_2_dynamicfiltersselector1 = AV20DynamicFiltersSelector1;
         AV64Ciudadwwds_3_dynamicfiltersoperator1 = AV21DynamicFiltersOperator1;
         AV65Ciudadwwds_4_ciudadnombre1 = AV22CiudadNombre1;
         AV66Ciudadwwds_5_paisnombre1 = AV23PaisNombre1;
         AV67Ciudadwwds_6_dynamicfiltersenabled2 = AV24DynamicFiltersEnabled2;
         AV68Ciudadwwds_7_dynamicfiltersselector2 = AV25DynamicFiltersSelector2;
         AV69Ciudadwwds_8_dynamicfiltersoperator2 = AV26DynamicFiltersOperator2;
         AV70Ciudadwwds_9_ciudadnombre2 = AV27CiudadNombre2;
         AV71Ciudadwwds_10_paisnombre2 = AV28PaisNombre2;
         AV72Ciudadwwds_11_dynamicfiltersenabled3 = AV29DynamicFiltersEnabled3;
         AV73Ciudadwwds_12_dynamicfiltersselector3 = AV30DynamicFiltersSelector3;
         AV74Ciudadwwds_13_dynamicfiltersoperator3 = AV31DynamicFiltersOperator3;
         AV75Ciudadwwds_14_ciudadnombre3 = AV32CiudadNombre3;
         AV76Ciudadwwds_15_paisnombre3 = AV33PaisNombre3;
         AV77Ciudadwwds_16_tfciudadid = AV50TFCiudadId;
         AV78Ciudadwwds_17_tfciudadid_to = AV51TFCiudadId_To;
         AV79Ciudadwwds_18_tfpaisid = AV52TFPaisID;
         AV80Ciudadwwds_19_tfpaisid_sel = AV53TFPaisID_Sel;
         AV81Ciudadwwds_20_tfpaisnombre = AV54TFPaisNombre;
         AV82Ciudadwwds_21_tfpaisnombre_sel = AV55TFPaisNombre_Sel;
         AV83Ciudadwwds_22_tfciudadnombre = AV56TFCiudadNombre;
         AV84Ciudadwwds_23_tfciudadnombre_sel = AV57TFCiudadNombre_Sel;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV62Ciudadwwds_1_filterfulltext ,
                                              AV63Ciudadwwds_2_dynamicfiltersselector1 ,
                                              AV64Ciudadwwds_3_dynamicfiltersoperator1 ,
                                              AV65Ciudadwwds_4_ciudadnombre1 ,
                                              AV66Ciudadwwds_5_paisnombre1 ,
                                              AV67Ciudadwwds_6_dynamicfiltersenabled2 ,
                                              AV68Ciudadwwds_7_dynamicfiltersselector2 ,
                                              AV69Ciudadwwds_8_dynamicfiltersoperator2 ,
                                              AV70Ciudadwwds_9_ciudadnombre2 ,
                                              AV71Ciudadwwds_10_paisnombre2 ,
                                              AV72Ciudadwwds_11_dynamicfiltersenabled3 ,
                                              AV73Ciudadwwds_12_dynamicfiltersselector3 ,
                                              AV74Ciudadwwds_13_dynamicfiltersoperator3 ,
                                              AV75Ciudadwwds_14_ciudadnombre3 ,
                                              AV76Ciudadwwds_15_paisnombre3 ,
                                              AV77Ciudadwwds_16_tfciudadid ,
                                              AV78Ciudadwwds_17_tfciudadid_to ,
                                              AV80Ciudadwwds_19_tfpaisid_sel ,
                                              AV79Ciudadwwds_18_tfpaisid ,
                                              AV82Ciudadwwds_21_tfpaisnombre_sel ,
                                              AV81Ciudadwwds_20_tfpaisnombre ,
                                              AV84Ciudadwwds_23_tfciudadnombre_sel ,
                                              AV83Ciudadwwds_22_tfciudadnombre ,
                                              A144CiudadId ,
                                              A116PaisID ,
                                              A165PaisNombre ,
                                              A208CiudadNombre ,
                                              AV17OrderedBy ,
                                              AV18OrderedDsc } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV62Ciudadwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV62Ciudadwwds_1_filterfulltext), "%", "");
         lV62Ciudadwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV62Ciudadwwds_1_filterfulltext), "%", "");
         lV62Ciudadwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV62Ciudadwwds_1_filterfulltext), "%", "");
         lV62Ciudadwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV62Ciudadwwds_1_filterfulltext), "%", "");
         lV65Ciudadwwds_4_ciudadnombre1 = StringUtil.PadR( StringUtil.RTrim( AV65Ciudadwwds_4_ciudadnombre1), 80, "%");
         lV65Ciudadwwds_4_ciudadnombre1 = StringUtil.PadR( StringUtil.RTrim( AV65Ciudadwwds_4_ciudadnombre1), 80, "%");
         lV66Ciudadwwds_5_paisnombre1 = StringUtil.PadR( StringUtil.RTrim( AV66Ciudadwwds_5_paisnombre1), 80, "%");
         lV66Ciudadwwds_5_paisnombre1 = StringUtil.PadR( StringUtil.RTrim( AV66Ciudadwwds_5_paisnombre1), 80, "%");
         lV70Ciudadwwds_9_ciudadnombre2 = StringUtil.PadR( StringUtil.RTrim( AV70Ciudadwwds_9_ciudadnombre2), 80, "%");
         lV70Ciudadwwds_9_ciudadnombre2 = StringUtil.PadR( StringUtil.RTrim( AV70Ciudadwwds_9_ciudadnombre2), 80, "%");
         lV71Ciudadwwds_10_paisnombre2 = StringUtil.PadR( StringUtil.RTrim( AV71Ciudadwwds_10_paisnombre2), 80, "%");
         lV71Ciudadwwds_10_paisnombre2 = StringUtil.PadR( StringUtil.RTrim( AV71Ciudadwwds_10_paisnombre2), 80, "%");
         lV75Ciudadwwds_14_ciudadnombre3 = StringUtil.PadR( StringUtil.RTrim( AV75Ciudadwwds_14_ciudadnombre3), 80, "%");
         lV75Ciudadwwds_14_ciudadnombre3 = StringUtil.PadR( StringUtil.RTrim( AV75Ciudadwwds_14_ciudadnombre3), 80, "%");
         lV76Ciudadwwds_15_paisnombre3 = StringUtil.PadR( StringUtil.RTrim( AV76Ciudadwwds_15_paisnombre3), 80, "%");
         lV76Ciudadwwds_15_paisnombre3 = StringUtil.PadR( StringUtil.RTrim( AV76Ciudadwwds_15_paisnombre3), 80, "%");
         lV79Ciudadwwds_18_tfpaisid = StringUtil.PadR( StringUtil.RTrim( AV79Ciudadwwds_18_tfpaisid), 2, "%");
         lV81Ciudadwwds_20_tfpaisnombre = StringUtil.PadR( StringUtil.RTrim( AV81Ciudadwwds_20_tfpaisnombre), 80, "%");
         lV83Ciudadwwds_22_tfciudadnombre = StringUtil.PadR( StringUtil.RTrim( AV83Ciudadwwds_22_tfciudadnombre), 80, "%");
         /* Using cursor P00AM2 */
         pr_default.execute(0, new Object[] {lV62Ciudadwwds_1_filterfulltext, lV62Ciudadwwds_1_filterfulltext, lV62Ciudadwwds_1_filterfulltext, lV62Ciudadwwds_1_filterfulltext, lV65Ciudadwwds_4_ciudadnombre1, lV65Ciudadwwds_4_ciudadnombre1, lV66Ciudadwwds_5_paisnombre1, lV66Ciudadwwds_5_paisnombre1, lV70Ciudadwwds_9_ciudadnombre2, lV70Ciudadwwds_9_ciudadnombre2, lV71Ciudadwwds_10_paisnombre2, lV71Ciudadwwds_10_paisnombre2, lV75Ciudadwwds_14_ciudadnombre3, lV75Ciudadwwds_14_ciudadnombre3, lV76Ciudadwwds_15_paisnombre3, lV76Ciudadwwds_15_paisnombre3, AV77Ciudadwwds_16_tfciudadid, AV78Ciudadwwds_17_tfciudadid_to, lV79Ciudadwwds_18_tfpaisid, AV80Ciudadwwds_19_tfpaisid_sel, lV81Ciudadwwds_20_tfpaisnombre, AV82Ciudadwwds_21_tfpaisnombre_sel, lV83Ciudadwwds_22_tfciudadnombre, AV84Ciudadwwds_23_tfciudadnombre_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A208CiudadNombre = P00AM2_A208CiudadNombre[0];
            A165PaisNombre = P00AM2_A165PaisNombre[0];
            A116PaisID = P00AM2_A116PaisID[0];
            A144CiudadId = P00AM2_A144CiudadId[0];
            A165PaisNombre = P00AM2_A165PaisNombre[0];
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
            AV85GXV2 = 1;
            while ( AV85GXV2 <= AV39ColumnsSelector.gxTpr_Columns.Count )
            {
               AV41ColumnsSelector_Column = ((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV39ColumnsSelector.gxTpr_Columns.Item(AV85GXV2));
               if ( AV41ColumnsSelector_Column.gxTpr_Isvisible )
               {
                  if ( StringUtil.StrCmp(AV41ColumnsSelector_Column.gxTpr_Columnname, "CiudadId") == 0 )
                  {
                     AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV47VisibleColumnCount), 1, 1).Number = A144CiudadId;
                  }
                  else if ( StringUtil.StrCmp(AV41ColumnsSelector_Column.gxTpr_Columnname, "PaisID") == 0 )
                  {
                     GXt_char2 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A116PaisID, out  GXt_char2) ;
                     AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV47VisibleColumnCount), 1, 1).Text = GXt_char2;
                  }
                  else if ( StringUtil.StrCmp(AV41ColumnsSelector_Column.gxTpr_Columnname, "PaisNombre") == 0 )
                  {
                     GXt_char2 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A165PaisNombre, out  GXt_char2) ;
                     AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV47VisibleColumnCount), 1, 1).Text = GXt_char2;
                  }
                  else if ( StringUtil.StrCmp(AV41ColumnsSelector_Column.gxTpr_Columnname, "PaisBandera") == 0 )
                  {
                     AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV47VisibleColumnCount), 1, 1).Text = "";
                  }
                  else if ( StringUtil.StrCmp(AV41ColumnsSelector_Column.gxTpr_Columnname, "CiudadNombre") == 0 )
                  {
                     GXt_char2 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A208CiudadNombre, out  GXt_char2) ;
                     AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV47VisibleColumnCount), 1, 1).Text = GXt_char2;
                  }
                  else if ( StringUtil.StrCmp(AV41ColumnsSelector_Column.gxTpr_Columnname, "CiudadImagen1") == 0 )
                  {
                     AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV47VisibleColumnCount), 1, 1).Text = "";
                  }
                  AV47VisibleColumnCount = (long)(AV47VisibleColumnCount+1);
               }
               AV85GXV2 = (int)(AV85GXV2+1);
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
         AV35Session.Set("WWPExportFilePath", AV12Filename);
         AV35Session.Set("WWPExportFileName", "CiudadWWExport.xlsx");
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
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV39ColumnsSelector,  "CiudadId",  "",  "Ciudad",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV39ColumnsSelector,  "PaisID",  "",  "Pais",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV39ColumnsSelector,  "PaisNombre",  "",  "",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV39ColumnsSelector,  "PaisBandera",  "",  "",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV39ColumnsSelector,  "CiudadNombre",  "",  "",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV39ColumnsSelector,  "CiudadImagen1",  "",  "",  true,  "") ;
         GXt_char2 = AV43UserCustomValue;
         new GeneXus.Programs.wwpbaseobjects.loadcolumnsselectorstate(context ).execute(  "CiudadWWColumnsSelector", out  GXt_char2) ;
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
         if ( StringUtil.StrCmp(AV35Session.Get("CiudadWWGridState"), "") == 0 )
         {
            AV37GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "CiudadWWGridState"), null, "", "");
         }
         else
         {
            AV37GridState.FromXml(AV35Session.Get("CiudadWWGridState"), null, "", "");
         }
         AV17OrderedBy = AV37GridState.gxTpr_Orderedby;
         AV18OrderedDsc = AV37GridState.gxTpr_Ordereddsc;
         AV86GXV3 = 1;
         while ( AV86GXV3 <= AV37GridState.gxTpr_Filtervalues.Count )
         {
            AV38GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV37GridState.gxTpr_Filtervalues.Item(AV86GXV3));
            if ( StringUtil.StrCmp(AV38GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV19FilterFullText = AV38GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV38GridStateFilterValue.gxTpr_Name, "TFCIUDADID") == 0 )
            {
               AV50TFCiudadId = (long)(Math.Round(NumberUtil.Val( AV38GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV51TFCiudadId_To = (long)(Math.Round(NumberUtil.Val( AV38GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV38GridStateFilterValue.gxTpr_Name, "TFPAISID") == 0 )
            {
               AV52TFPaisID = AV38GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV38GridStateFilterValue.gxTpr_Name, "TFPAISID_SEL") == 0 )
            {
               AV53TFPaisID_Sel = AV38GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV38GridStateFilterValue.gxTpr_Name, "TFPAISNOMBRE") == 0 )
            {
               AV54TFPaisNombre = AV38GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV38GridStateFilterValue.gxTpr_Name, "TFPAISNOMBRE_SEL") == 0 )
            {
               AV55TFPaisNombre_Sel = AV38GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV38GridStateFilterValue.gxTpr_Name, "TFCIUDADNOMBRE") == 0 )
            {
               AV56TFCiudadNombre = AV38GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV38GridStateFilterValue.gxTpr_Name, "TFCIUDADNOMBRE_SEL") == 0 )
            {
               AV57TFCiudadNombre_Sel = AV38GridStateFilterValue.gxTpr_Value;
            }
            AV86GXV3 = (int)(AV86GXV3+1);
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
         AV37GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV34GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV20DynamicFiltersSelector1 = "";
         AV22CiudadNombre1 = "";
         AV23PaisNombre1 = "";
         AV25DynamicFiltersSelector2 = "";
         AV27CiudadNombre2 = "";
         AV28PaisNombre2 = "";
         AV30DynamicFiltersSelector3 = "";
         AV32CiudadNombre3 = "";
         AV33PaisNombre3 = "";
         AV53TFPaisID_Sel = "";
         AV52TFPaisID = "";
         AV55TFPaisNombre_Sel = "";
         AV54TFPaisNombre = "";
         AV57TFCiudadNombre_Sel = "";
         AV56TFCiudadNombre = "";
         AV35Session = context.GetSession();
         AV42ColumnsSelectorXML = "";
         AV39ColumnsSelector = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector(context);
         AV41ColumnsSelector_Column = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column(context);
         AV62Ciudadwwds_1_filterfulltext = "";
         AV63Ciudadwwds_2_dynamicfiltersselector1 = "";
         AV65Ciudadwwds_4_ciudadnombre1 = "";
         AV66Ciudadwwds_5_paisnombre1 = "";
         AV68Ciudadwwds_7_dynamicfiltersselector2 = "";
         AV70Ciudadwwds_9_ciudadnombre2 = "";
         AV71Ciudadwwds_10_paisnombre2 = "";
         AV73Ciudadwwds_12_dynamicfiltersselector3 = "";
         AV75Ciudadwwds_14_ciudadnombre3 = "";
         AV76Ciudadwwds_15_paisnombre3 = "";
         AV79Ciudadwwds_18_tfpaisid = "";
         AV80Ciudadwwds_19_tfpaisid_sel = "";
         AV81Ciudadwwds_20_tfpaisnombre = "";
         AV82Ciudadwwds_21_tfpaisnombre_sel = "";
         AV83Ciudadwwds_22_tfciudadnombre = "";
         AV84Ciudadwwds_23_tfciudadnombre_sel = "";
         lV62Ciudadwwds_1_filterfulltext = "";
         lV65Ciudadwwds_4_ciudadnombre1 = "";
         lV66Ciudadwwds_5_paisnombre1 = "";
         lV70Ciudadwwds_9_ciudadnombre2 = "";
         lV71Ciudadwwds_10_paisnombre2 = "";
         lV75Ciudadwwds_14_ciudadnombre3 = "";
         lV76Ciudadwwds_15_paisnombre3 = "";
         lV79Ciudadwwds_18_tfpaisid = "";
         lV81Ciudadwwds_20_tfpaisnombre = "";
         lV83Ciudadwwds_22_tfciudadnombre = "";
         A116PaisID = "";
         A165PaisNombre = "";
         A208CiudadNombre = "";
         P00AM2_A208CiudadNombre = new string[] {""} ;
         P00AM2_A165PaisNombre = new string[] {""} ;
         P00AM2_A116PaisID = new string[] {""} ;
         P00AM2_A144CiudadId = new long[1] ;
         AV43UserCustomValue = "";
         GXt_char2 = "";
         AV40ColumnsSelectorAux = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector(context);
         AV38GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.ciudadwwexport__default(),
            new Object[][] {
                new Object[] {
               P00AM2_A208CiudadNombre, P00AM2_A165PaisNombre, P00AM2_A116PaisID, P00AM2_A144CiudadId
               }
            }
         );
         AV59Pgmname = "CiudadWWExport";
         /* GeneXus formulas. */
         AV59Pgmname = "CiudadWWExport";
      }

      private short AV21DynamicFiltersOperator1 ;
      private short AV26DynamicFiltersOperator2 ;
      private short AV31DynamicFiltersOperator3 ;
      private short GXt_int3 ;
      private short AV64Ciudadwwds_3_dynamicfiltersoperator1 ;
      private short AV69Ciudadwwds_8_dynamicfiltersoperator2 ;
      private short AV74Ciudadwwds_13_dynamicfiltersoperator3 ;
      private short AV17OrderedBy ;
      private int AV14CellRow ;
      private int AV15FirstColumn ;
      private int AV16Random ;
      private int AV60GXV1 ;
      private int AV85GXV2 ;
      private int AV86GXV3 ;
      private long AV50TFCiudadId ;
      private long AV51TFCiudadId_To ;
      private long AV47VisibleColumnCount ;
      private long AV77Ciudadwwds_16_tfciudadid ;
      private long AV78Ciudadwwds_17_tfciudadid_to ;
      private long A144CiudadId ;
      private string AV59Pgmname ;
      private string GXKey ;
      private string GXEncryptionTmp ;
      private string AV22CiudadNombre1 ;
      private string AV23PaisNombre1 ;
      private string AV27CiudadNombre2 ;
      private string AV28PaisNombre2 ;
      private string AV32CiudadNombre3 ;
      private string AV33PaisNombre3 ;
      private string AV53TFPaisID_Sel ;
      private string AV52TFPaisID ;
      private string AV55TFPaisNombre_Sel ;
      private string AV54TFPaisNombre ;
      private string AV57TFCiudadNombre_Sel ;
      private string AV56TFCiudadNombre ;
      private string AV65Ciudadwwds_4_ciudadnombre1 ;
      private string AV66Ciudadwwds_5_paisnombre1 ;
      private string AV70Ciudadwwds_9_ciudadnombre2 ;
      private string AV71Ciudadwwds_10_paisnombre2 ;
      private string AV75Ciudadwwds_14_ciudadnombre3 ;
      private string AV76Ciudadwwds_15_paisnombre3 ;
      private string AV79Ciudadwwds_18_tfpaisid ;
      private string AV80Ciudadwwds_19_tfpaisid_sel ;
      private string AV81Ciudadwwds_20_tfpaisnombre ;
      private string AV82Ciudadwwds_21_tfpaisnombre_sel ;
      private string AV83Ciudadwwds_22_tfciudadnombre ;
      private string AV84Ciudadwwds_23_tfciudadnombre_sel ;
      private string lV65Ciudadwwds_4_ciudadnombre1 ;
      private string lV66Ciudadwwds_5_paisnombre1 ;
      private string lV70Ciudadwwds_9_ciudadnombre2 ;
      private string lV71Ciudadwwds_10_paisnombre2 ;
      private string lV75Ciudadwwds_14_ciudadnombre3 ;
      private string lV76Ciudadwwds_15_paisnombre3 ;
      private string lV79Ciudadwwds_18_tfpaisid ;
      private string lV81Ciudadwwds_20_tfpaisnombre ;
      private string lV83Ciudadwwds_22_tfciudadnombre ;
      private string A116PaisID ;
      private string A165PaisNombre ;
      private string A208CiudadNombre ;
      private string GXt_char2 ;
      private bool AV8IsAuthorized ;
      private bool GXt_boolean1 ;
      private bool returnInSub ;
      private bool AV24DynamicFiltersEnabled2 ;
      private bool AV29DynamicFiltersEnabled3 ;
      private bool AV67Ciudadwwds_6_dynamicfiltersenabled2 ;
      private bool AV72Ciudadwwds_11_dynamicfiltersenabled3 ;
      private bool AV18OrderedDsc ;
      private string AV42ColumnsSelectorXML ;
      private string AV43UserCustomValue ;
      private string AV12Filename ;
      private string AV13ErrorMessage ;
      private string AV19FilterFullText ;
      private string AV20DynamicFiltersSelector1 ;
      private string AV25DynamicFiltersSelector2 ;
      private string AV30DynamicFiltersSelector3 ;
      private string AV62Ciudadwwds_1_filterfulltext ;
      private string AV63Ciudadwwds_2_dynamicfiltersselector1 ;
      private string AV68Ciudadwwds_7_dynamicfiltersselector2 ;
      private string AV73Ciudadwwds_12_dynamicfiltersselector3 ;
      private string lV62Ciudadwwds_1_filterfulltext ;
      private IGxSession AV35Session ;
      private ExcelDocumentI AV11ExcelDocument ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV37GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV34GridStateDynamicFilter ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector AV39ColumnsSelector ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column AV41ColumnsSelector_Column ;
      private IDataStoreProvider pr_default ;
      private string[] P00AM2_A208CiudadNombre ;
      private string[] P00AM2_A165PaisNombre ;
      private string[] P00AM2_A116PaisID ;
      private long[] P00AM2_A144CiudadId ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector AV40ColumnsSelectorAux ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV38GridStateFilterValue ;
      private string aP0_Filename ;
      private string aP1_ErrorMessage ;
   }

   public class ciudadwwexport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00AM2( IGxContext context ,
                                             string AV62Ciudadwwds_1_filterfulltext ,
                                             string AV63Ciudadwwds_2_dynamicfiltersselector1 ,
                                             short AV64Ciudadwwds_3_dynamicfiltersoperator1 ,
                                             string AV65Ciudadwwds_4_ciudadnombre1 ,
                                             string AV66Ciudadwwds_5_paisnombre1 ,
                                             bool AV67Ciudadwwds_6_dynamicfiltersenabled2 ,
                                             string AV68Ciudadwwds_7_dynamicfiltersselector2 ,
                                             short AV69Ciudadwwds_8_dynamicfiltersoperator2 ,
                                             string AV70Ciudadwwds_9_ciudadnombre2 ,
                                             string AV71Ciudadwwds_10_paisnombre2 ,
                                             bool AV72Ciudadwwds_11_dynamicfiltersenabled3 ,
                                             string AV73Ciudadwwds_12_dynamicfiltersselector3 ,
                                             short AV74Ciudadwwds_13_dynamicfiltersoperator3 ,
                                             string AV75Ciudadwwds_14_ciudadnombre3 ,
                                             string AV76Ciudadwwds_15_paisnombre3 ,
                                             long AV77Ciudadwwds_16_tfciudadid ,
                                             long AV78Ciudadwwds_17_tfciudadid_to ,
                                             string AV80Ciudadwwds_19_tfpaisid_sel ,
                                             string AV79Ciudadwwds_18_tfpaisid ,
                                             string AV82Ciudadwwds_21_tfpaisnombre_sel ,
                                             string AV81Ciudadwwds_20_tfpaisnombre ,
                                             string AV84Ciudadwwds_23_tfciudadnombre_sel ,
                                             string AV83Ciudadwwds_22_tfciudadnombre ,
                                             long A144CiudadId ,
                                             string A116PaisID ,
                                             string A165PaisNombre ,
                                             string A208CiudadNombre ,
                                             short AV17OrderedBy ,
                                             bool AV18OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int4 = new short[24];
         Object[] GXv_Object5 = new Object[2];
         scmdbuf = "SELECT T1.[CiudadNombre], T2.[PaisNombre], T1.[PaisID], T1.[CiudadId] FROM ([Ciudad] T1 INNER JOIN [Pais] T2 ON T2.[PaisID] = T1.[PaisID])";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Ciudadwwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( CONVERT( char(18), CAST(T1.[CiudadId] AS decimal(18,0))) like '%' + @lV62Ciudadwwds_1_filterfulltext) or ( UPPER(T1.[PaisID]) like '%' + UPPER(@lV62Ciudadwwds_1_filterfulltext)) or ( UPPER(T2.[PaisNombre]) like '%' + UPPER(@lV62Ciudadwwds_1_filterfulltext)) or ( UPPER(T1.[CiudadNombre]) like '%' + UPPER(@lV62Ciudadwwds_1_filterfulltext)))");
         }
         else
         {
            GXv_int4[0] = 1;
            GXv_int4[1] = 1;
            GXv_int4[2] = 1;
            GXv_int4[3] = 1;
         }
         if ( ( StringUtil.StrCmp(AV63Ciudadwwds_2_dynamicfiltersselector1, "CIUDADNOMBRE") == 0 ) && ( AV64Ciudadwwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Ciudadwwds_4_ciudadnombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[CiudadNombre]) like UPPER(@lV65Ciudadwwds_4_ciudadnombre1))");
         }
         else
         {
            GXv_int4[4] = 1;
         }
         if ( ( StringUtil.StrCmp(AV63Ciudadwwds_2_dynamicfiltersselector1, "CIUDADNOMBRE") == 0 ) && ( AV64Ciudadwwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Ciudadwwds_4_ciudadnombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[CiudadNombre]) like '%' + UPPER(@lV65Ciudadwwds_4_ciudadnombre1))");
         }
         else
         {
            GXv_int4[5] = 1;
         }
         if ( ( StringUtil.StrCmp(AV63Ciudadwwds_2_dynamicfiltersselector1, "PAISNOMBRE") == 0 ) && ( AV64Ciudadwwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Ciudadwwds_5_paisnombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[PaisNombre]) like UPPER(@lV66Ciudadwwds_5_paisnombre1))");
         }
         else
         {
            GXv_int4[6] = 1;
         }
         if ( ( StringUtil.StrCmp(AV63Ciudadwwds_2_dynamicfiltersselector1, "PAISNOMBRE") == 0 ) && ( AV64Ciudadwwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Ciudadwwds_5_paisnombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[PaisNombre]) like '%' + UPPER(@lV66Ciudadwwds_5_paisnombre1))");
         }
         else
         {
            GXv_int4[7] = 1;
         }
         if ( AV67Ciudadwwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV68Ciudadwwds_7_dynamicfiltersselector2, "CIUDADNOMBRE") == 0 ) && ( AV69Ciudadwwds_8_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Ciudadwwds_9_ciudadnombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[CiudadNombre]) like UPPER(@lV70Ciudadwwds_9_ciudadnombre2))");
         }
         else
         {
            GXv_int4[8] = 1;
         }
         if ( AV67Ciudadwwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV68Ciudadwwds_7_dynamicfiltersselector2, "CIUDADNOMBRE") == 0 ) && ( AV69Ciudadwwds_8_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Ciudadwwds_9_ciudadnombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[CiudadNombre]) like '%' + UPPER(@lV70Ciudadwwds_9_ciudadnombre2))");
         }
         else
         {
            GXv_int4[9] = 1;
         }
         if ( AV67Ciudadwwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV68Ciudadwwds_7_dynamicfiltersselector2, "PAISNOMBRE") == 0 ) && ( AV69Ciudadwwds_8_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Ciudadwwds_10_paisnombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[PaisNombre]) like UPPER(@lV71Ciudadwwds_10_paisnombre2))");
         }
         else
         {
            GXv_int4[10] = 1;
         }
         if ( AV67Ciudadwwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV68Ciudadwwds_7_dynamicfiltersselector2, "PAISNOMBRE") == 0 ) && ( AV69Ciudadwwds_8_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Ciudadwwds_10_paisnombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[PaisNombre]) like '%' + UPPER(@lV71Ciudadwwds_10_paisnombre2))");
         }
         else
         {
            GXv_int4[11] = 1;
         }
         if ( AV72Ciudadwwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV73Ciudadwwds_12_dynamicfiltersselector3, "CIUDADNOMBRE") == 0 ) && ( AV74Ciudadwwds_13_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75Ciudadwwds_14_ciudadnombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[CiudadNombre]) like UPPER(@lV75Ciudadwwds_14_ciudadnombre3))");
         }
         else
         {
            GXv_int4[12] = 1;
         }
         if ( AV72Ciudadwwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV73Ciudadwwds_12_dynamicfiltersselector3, "CIUDADNOMBRE") == 0 ) && ( AV74Ciudadwwds_13_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75Ciudadwwds_14_ciudadnombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[CiudadNombre]) like '%' + UPPER(@lV75Ciudadwwds_14_ciudadnombre3))");
         }
         else
         {
            GXv_int4[13] = 1;
         }
         if ( AV72Ciudadwwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV73Ciudadwwds_12_dynamicfiltersselector3, "PAISNOMBRE") == 0 ) && ( AV74Ciudadwwds_13_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV76Ciudadwwds_15_paisnombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[PaisNombre]) like UPPER(@lV76Ciudadwwds_15_paisnombre3))");
         }
         else
         {
            GXv_int4[14] = 1;
         }
         if ( AV72Ciudadwwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV73Ciudadwwds_12_dynamicfiltersselector3, "PAISNOMBRE") == 0 ) && ( AV74Ciudadwwds_13_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV76Ciudadwwds_15_paisnombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[PaisNombre]) like '%' + UPPER(@lV76Ciudadwwds_15_paisnombre3))");
         }
         else
         {
            GXv_int4[15] = 1;
         }
         if ( ! (0==AV77Ciudadwwds_16_tfciudadid) )
         {
            AddWhere(sWhereString, "(T1.[CiudadId] >= @AV77Ciudadwwds_16_tfciudadid)");
         }
         else
         {
            GXv_int4[16] = 1;
         }
         if ( ! (0==AV78Ciudadwwds_17_tfciudadid_to) )
         {
            AddWhere(sWhereString, "(T1.[CiudadId] <= @AV78Ciudadwwds_17_tfciudadid_to)");
         }
         else
         {
            GXv_int4[17] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV80Ciudadwwds_19_tfpaisid_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV79Ciudadwwds_18_tfpaisid)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[PaisID]) like UPPER(@lV79Ciudadwwds_18_tfpaisid))");
         }
         else
         {
            GXv_int4[18] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV80Ciudadwwds_19_tfpaisid_sel)) && ! ( StringUtil.StrCmp(AV80Ciudadwwds_19_tfpaisid_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[PaisID] = @AV80Ciudadwwds_19_tfpaisid_sel)");
         }
         else
         {
            GXv_int4[19] = 1;
         }
         if ( StringUtil.StrCmp(AV80Ciudadwwds_19_tfpaisid_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[PaisID] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV82Ciudadwwds_21_tfpaisnombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV81Ciudadwwds_20_tfpaisnombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[PaisNombre]) like UPPER(@lV81Ciudadwwds_20_tfpaisnombre))");
         }
         else
         {
            GXv_int4[20] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV82Ciudadwwds_21_tfpaisnombre_sel)) && ! ( StringUtil.StrCmp(AV82Ciudadwwds_21_tfpaisnombre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.[PaisNombre] = @AV82Ciudadwwds_21_tfpaisnombre_sel)");
         }
         else
         {
            GXv_int4[21] = 1;
         }
         if ( StringUtil.StrCmp(AV82Ciudadwwds_21_tfpaisnombre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T2.[PaisNombre] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV84Ciudadwwds_23_tfciudadnombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV83Ciudadwwds_22_tfciudadnombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[CiudadNombre]) like UPPER(@lV83Ciudadwwds_22_tfciudadnombre))");
         }
         else
         {
            GXv_int4[22] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV84Ciudadwwds_23_tfciudadnombre_sel)) && ! ( StringUtil.StrCmp(AV84Ciudadwwds_23_tfciudadnombre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[CiudadNombre] = @AV84Ciudadwwds_23_tfciudadnombre_sel)");
         }
         else
         {
            GXv_int4[23] = 1;
         }
         if ( StringUtil.StrCmp(AV84Ciudadwwds_23_tfciudadnombre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[CiudadNombre] = ''))");
         }
         scmdbuf += sWhereString;
         if ( ( AV17OrderedBy == 1 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[CiudadNombre]";
         }
         else if ( ( AV17OrderedBy == 1 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[CiudadNombre] DESC";
         }
         else if ( ( AV17OrderedBy == 2 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[CiudadId]";
         }
         else if ( ( AV17OrderedBy == 2 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[CiudadId] DESC";
         }
         else if ( ( AV17OrderedBy == 3 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[PaisID]";
         }
         else if ( ( AV17OrderedBy == 3 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[PaisID] DESC";
         }
         else if ( ( AV17OrderedBy == 4 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T2.[PaisNombre]";
         }
         else if ( ( AV17OrderedBy == 4 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T2.[PaisNombre] DESC";
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
                     return conditional_P00AM2(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (short)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (bool)dynConstraints[5] , (string)dynConstraints[6] , (short)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (bool)dynConstraints[10] , (string)dynConstraints[11] , (short)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (long)dynConstraints[15] , (long)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (long)dynConstraints[23] , (string)dynConstraints[24] , (string)dynConstraints[25] , (string)dynConstraints[26] , (short)dynConstraints[27] , (bool)dynConstraints[28] );
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
          Object[] prmP00AM2;
          prmP00AM2 = new Object[] {
          new ParDef("@lV62Ciudadwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV62Ciudadwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV62Ciudadwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV62Ciudadwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV65Ciudadwwds_4_ciudadnombre1",GXType.Char,80,0) ,
          new ParDef("@lV65Ciudadwwds_4_ciudadnombre1",GXType.Char,80,0) ,
          new ParDef("@lV66Ciudadwwds_5_paisnombre1",GXType.Char,80,0) ,
          new ParDef("@lV66Ciudadwwds_5_paisnombre1",GXType.Char,80,0) ,
          new ParDef("@lV70Ciudadwwds_9_ciudadnombre2",GXType.Char,80,0) ,
          new ParDef("@lV70Ciudadwwds_9_ciudadnombre2",GXType.Char,80,0) ,
          new ParDef("@lV71Ciudadwwds_10_paisnombre2",GXType.Char,80,0) ,
          new ParDef("@lV71Ciudadwwds_10_paisnombre2",GXType.Char,80,0) ,
          new ParDef("@lV75Ciudadwwds_14_ciudadnombre3",GXType.Char,80,0) ,
          new ParDef("@lV75Ciudadwwds_14_ciudadnombre3",GXType.Char,80,0) ,
          new ParDef("@lV76Ciudadwwds_15_paisnombre3",GXType.Char,80,0) ,
          new ParDef("@lV76Ciudadwwds_15_paisnombre3",GXType.Char,80,0) ,
          new ParDef("@AV77Ciudadwwds_16_tfciudadid",GXType.Decimal,18,0) ,
          new ParDef("@AV78Ciudadwwds_17_tfciudadid_to",GXType.Decimal,18,0) ,
          new ParDef("@lV79Ciudadwwds_18_tfpaisid",GXType.Char,2,0) ,
          new ParDef("@AV80Ciudadwwds_19_tfpaisid_sel",GXType.NChar,2,0) ,
          new ParDef("@lV81Ciudadwwds_20_tfpaisnombre",GXType.Char,80,0) ,
          new ParDef("@AV82Ciudadwwds_21_tfpaisnombre_sel",GXType.NChar,80,0) ,
          new ParDef("@lV83Ciudadwwds_22_tfciudadnombre",GXType.Char,80,0) ,
          new ParDef("@AV84Ciudadwwds_23_tfciudadnombre_sel",GXType.NChar,80,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00AM2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00AM2,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[0])[0] = rslt.getString(1, 80);
                ((string[]) buf[1])[0] = rslt.getString(2, 80);
                ((string[]) buf[2])[0] = rslt.getString(3, 2);
                ((long[]) buf[3])[0] = rslt.getLong(4);
                return;
       }
    }

 }

}

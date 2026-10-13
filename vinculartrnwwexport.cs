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
   public class vinculartrnwwexport : GXProcedure
   {
      public vinculartrnwwexport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public vinculartrnwwexport( IGxContext context )
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
         new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWVincularTrn", out  GXt_boolean1) ;
         AV8IsAuthorized = GXt_boolean1;
         if ( ! AV8IsAuthorized )
         {
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "wwpbaseobjects.notauthorized.aspx"+GXUtil.UrlEncode(StringUtil.RTrim(AV69Pgmname));
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
         AV12Filename = GXt_char2 + "VincularTrnWWExport-" + StringUtil.Trim( StringUtil.Str( (decimal)(AV16Random), 8, 0)) + ".xlsx";
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
            if ( StringUtil.StrCmp(AV20DynamicFiltersSelector1, "VINCULARTRNSOLIDICUTD") == 0 )
            {
               AV21DynamicFiltersOperator1 = AV34GridStateDynamicFilter.gxTpr_Operator;
               AV22VincularTrnSolidicutd1 = (long)(Math.Round(NumberUtil.Val( AV34GridStateDynamicFilter.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               if ( ! (0==AV22VincularTrnSolidicutd1) )
               {
                  AV14CellRow = (int)(AV14CellRow+1);
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Bold = 1;
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Color = 3;
                  if ( AV21DynamicFiltersOperator1 == 0 )
                  {
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", context.GetMessage( "Solicitud", ""), "<", "", "", "", "", "", "", "");
                  }
                  else if ( AV21DynamicFiltersOperator1 == 1 )
                  {
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", context.GetMessage( "Solicitud", ""), "=", "", "", "", "", "", "", "");
                  }
                  else if ( AV21DynamicFiltersOperator1 == 2 )
                  {
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", context.GetMessage( "Solicitud", ""), ">", "", "", "", "", "", "", "");
                  }
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Italic = 1;
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Number = AV22VincularTrnSolidicutd1;
               }
            }
            else if ( StringUtil.StrCmp(AV20DynamicFiltersSelector1, "PROVEEDORNOMBRE") == 0 )
            {
               AV21DynamicFiltersOperator1 = AV34GridStateDynamicFilter.gxTpr_Operator;
               AV23ProveedorNombre1 = AV34GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV23ProveedorNombre1)) )
               {
                  AV14CellRow = (int)(AV14CellRow+1);
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Bold = 1;
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Color = 3;
                  if ( AV21DynamicFiltersOperator1 == 0 )
                  {
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", context.GetMessage( "Proveedor Nombre", ""), context.GetMessage( "WWP_FilterLike", ""), "", "", "", "", "", "", "");
                  }
                  else if ( AV21DynamicFiltersOperator1 == 1 )
                  {
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", context.GetMessage( "Proveedor Nombre", ""), context.GetMessage( "WWP_FilterContains", ""), "", "", "", "", "", "", "");
                  }
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Italic = 1;
                  GXt_char2 = "";
                  new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV23ProveedorNombre1, out  GXt_char2) ;
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
               }
            }
            if ( AV37GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV24DynamicFiltersEnabled2 = true;
               AV34GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV37GridState.gxTpr_Dynamicfilters.Item(2));
               AV25DynamicFiltersSelector2 = AV34GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV25DynamicFiltersSelector2, "VINCULARTRNSOLIDICUTD") == 0 )
               {
                  AV26DynamicFiltersOperator2 = AV34GridStateDynamicFilter.gxTpr_Operator;
                  AV27VincularTrnSolidicutd2 = (long)(Math.Round(NumberUtil.Val( AV34GridStateDynamicFilter.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
                  if ( ! (0==AV27VincularTrnSolidicutd2) )
                  {
                     AV14CellRow = (int)(AV14CellRow+1);
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Bold = 1;
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Color = 3;
                     if ( AV26DynamicFiltersOperator2 == 0 )
                     {
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", context.GetMessage( "Solicitud", ""), "<", "", "", "", "", "", "", "");
                     }
                     else if ( AV26DynamicFiltersOperator2 == 1 )
                     {
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", context.GetMessage( "Solicitud", ""), "=", "", "", "", "", "", "", "");
                     }
                     else if ( AV26DynamicFiltersOperator2 == 2 )
                     {
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", context.GetMessage( "Solicitud", ""), ">", "", "", "", "", "", "", "");
                     }
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Italic = 1;
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Number = AV27VincularTrnSolidicutd2;
                  }
               }
               else if ( StringUtil.StrCmp(AV25DynamicFiltersSelector2, "PROVEEDORNOMBRE") == 0 )
               {
                  AV26DynamicFiltersOperator2 = AV34GridStateDynamicFilter.gxTpr_Operator;
                  AV28ProveedorNombre2 = AV34GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV28ProveedorNombre2)) )
                  {
                     AV14CellRow = (int)(AV14CellRow+1);
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Bold = 1;
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Color = 3;
                     if ( AV26DynamicFiltersOperator2 == 0 )
                     {
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", context.GetMessage( "Proveedor Nombre", ""), context.GetMessage( "WWP_FilterLike", ""), "", "", "", "", "", "", "");
                     }
                     else if ( AV26DynamicFiltersOperator2 == 1 )
                     {
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", context.GetMessage( "Proveedor Nombre", ""), context.GetMessage( "WWP_FilterContains", ""), "", "", "", "", "", "", "");
                     }
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Italic = 1;
                     GXt_char2 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV28ProveedorNombre2, out  GXt_char2) ;
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
                  }
               }
               if ( AV37GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV29DynamicFiltersEnabled3 = true;
                  AV34GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV37GridState.gxTpr_Dynamicfilters.Item(3));
                  AV30DynamicFiltersSelector3 = AV34GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV30DynamicFiltersSelector3, "VINCULARTRNSOLIDICUTD") == 0 )
                  {
                     AV31DynamicFiltersOperator3 = AV34GridStateDynamicFilter.gxTpr_Operator;
                     AV32VincularTrnSolidicutd3 = (long)(Math.Round(NumberUtil.Val( AV34GridStateDynamicFilter.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
                     if ( ! (0==AV32VincularTrnSolidicutd3) )
                     {
                        AV14CellRow = (int)(AV14CellRow+1);
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Bold = 1;
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Color = 3;
                        if ( AV31DynamicFiltersOperator3 == 0 )
                        {
                           AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", context.GetMessage( "Solicitud", ""), "<", "", "", "", "", "", "", "");
                        }
                        else if ( AV31DynamicFiltersOperator3 == 1 )
                        {
                           AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", context.GetMessage( "Solicitud", ""), "=", "", "", "", "", "", "", "");
                        }
                        else if ( AV31DynamicFiltersOperator3 == 2 )
                        {
                           AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", context.GetMessage( "Solicitud", ""), ">", "", "", "", "", "", "", "");
                        }
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Italic = 1;
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Number = AV32VincularTrnSolidicutd3;
                     }
                  }
                  else if ( StringUtil.StrCmp(AV30DynamicFiltersSelector3, "PROVEEDORNOMBRE") == 0 )
                  {
                     AV31DynamicFiltersOperator3 = AV34GridStateDynamicFilter.gxTpr_Operator;
                     AV33ProveedorNombre3 = AV34GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV33ProveedorNombre3)) )
                     {
                        AV14CellRow = (int)(AV14CellRow+1);
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Bold = 1;
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Color = 3;
                        if ( AV31DynamicFiltersOperator3 == 0 )
                        {
                           AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", context.GetMessage( "Proveedor Nombre", ""), context.GetMessage( "WWP_FilterLike", ""), "", "", "", "", "", "", "");
                        }
                        else if ( AV31DynamicFiltersOperator3 == 1 )
                        {
                           AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", context.GetMessage( "Proveedor Nombre", ""), context.GetMessage( "WWP_FilterContains", ""), "", "", "", "", "", "", "");
                        }
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Italic = 1;
                        GXt_char2 = "";
                        new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV33ProveedorNombre3, out  GXt_char2) ;
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
                     }
                  }
               }
            }
         }
         if ( ! ( (0==AV50TFVincularTrnId) && (0==AV51TFVincularTrnId_To) ) )
         {
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Nro", "")) ;
            AV14CellRow = GXt_int3;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Number = AV50TFVincularTrnId;
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  false, ref  GXt_int3,  (short)(AV15FirstColumn+2),  context.GetMessage( "WWP_TSTo", "")) ;
            AV14CellRow = GXt_int3;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+3, 1, 1).Number = AV51TFVincularTrnId_To;
         }
         if ( ! ( (0==AV52TFProveedorID) && (0==AV53TFProveedorID_To) ) )
         {
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Código del Proveedor", "")) ;
            AV14CellRow = GXt_int3;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Number = AV52TFProveedorID;
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  false, ref  GXt_int3,  (short)(AV15FirstColumn+2),  context.GetMessage( "WWP_TSTo", "")) ;
            AV14CellRow = GXt_int3;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+3, 1, 1).Number = AV53TFProveedorID_To;
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV55TFProveedorNombre_Sel)) ) )
         {
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Proveedor Nombre", "")) ;
            AV14CellRow = GXt_int3;
            GXt_char2 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV55TFProveedorNombre_Sel)) ? context.GetMessage( "WWP_TitleFilter_EmptyOption", "") : AV55TFProveedorNombre_Sel), out  GXt_char2) ;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV54TFProveedorNombre)) ) )
            {
               GXt_int3 = (short)(AV14CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Proveedor Nombre", "")) ;
               AV14CellRow = GXt_int3;
               GXt_char2 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV54TFProveedorNombre, out  GXt_char2) ;
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
            }
         }
         if ( ! ( (0==AV56TFVincularTrnSolidicutd) && (0==AV57TFVincularTrnSolidicutd_To) ) )
         {
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Solicitud", "")) ;
            AV14CellRow = GXt_int3;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Number = AV56TFVincularTrnSolidicutd;
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  false, ref  GXt_int3,  (short)(AV15FirstColumn+2),  context.GetMessage( "WWP_TSTo", "")) ;
            AV14CellRow = GXt_int3;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+3, 1, 1).Number = AV57TFVincularTrnSolidicutd_To;
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV59TFVincularTrnNombreSol_Sel)) ) )
         {
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Nombre del Cliente", "")) ;
            AV14CellRow = GXt_int3;
            GXt_char2 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV59TFVincularTrnNombreSol_Sel)) ? context.GetMessage( "WWP_TitleFilter_EmptyOption", "") : AV59TFVincularTrnNombreSol_Sel), out  GXt_char2) ;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV58TFVincularTrnNombreSol)) ) )
            {
               GXt_int3 = (short)(AV14CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Nombre del Cliente", "")) ;
               AV14CellRow = GXt_int3;
               GXt_char2 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV58TFVincularTrnNombreSol, out  GXt_char2) ;
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV61TFVincularTrnTelefonoSol_Sel)) ) )
         {
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Teléfono del Cliente", "")) ;
            AV14CellRow = GXt_int3;
            GXt_char2 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV61TFVincularTrnTelefonoSol_Sel)) ? context.GetMessage( "WWP_TitleFilter_EmptyOption", "") : AV61TFVincularTrnTelefonoSol_Sel), out  GXt_char2) ;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV60TFVincularTrnTelefonoSol)) ) )
            {
               GXt_int3 = (short)(AV14CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Teléfono del Cliente", "")) ;
               AV14CellRow = GXt_int3;
               GXt_char2 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV60TFVincularTrnTelefonoSol, out  GXt_char2) ;
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
            }
         }
         if ( ! ( (0==AV62TFDocumentacionId) && (0==AV63TFDocumentacionId_To) ) )
         {
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Documentación", "")) ;
            AV14CellRow = GXt_int3;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Number = AV62TFDocumentacionId;
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  false, ref  GXt_int3,  (short)(AV15FirstColumn+2),  context.GetMessage( "WWP_TSTo", "")) ;
            AV14CellRow = GXt_int3;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+3, 1, 1).Number = AV63TFDocumentacionId_To;
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV65TFVincularTrnComentario_Sel)) ) )
         {
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Comentario", "")) ;
            AV14CellRow = GXt_int3;
            GXt_char2 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV65TFVincularTrnComentario_Sel)) ? context.GetMessage( "WWP_TitleFilter_EmptyOption", "") : StringUtil.Substring( AV65TFVincularTrnComentario_Sel, 1, 1000)), out  GXt_char2) ;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV64TFVincularTrnComentario)) ) )
            {
               GXt_int3 = (short)(AV14CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Comentario", "")) ;
               AV14CellRow = GXt_int3;
               GXt_char2 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  StringUtil.Substring( AV64TFVincularTrnComentario, 1, 1000), out  GXt_char2) ;
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
            }
         }
         if ( ! ( (DateTime.MinValue==AV66TFVincularTrnFecha) && (DateTime.MinValue==AV67TFVincularTrnFecha_To) ) )
         {
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Fecha", "")) ;
            AV14CellRow = GXt_int3;
            GXt_dtime4 = DateTimeUtil.ResetTime( AV66TFVincularTrnFecha ) ;
            AV11ExcelDocument.SetDateFormat(context, 8, 5, ((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0), DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt")), "/", ":", " ");
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Date = GXt_dtime4;
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  false, ref  GXt_int3,  (short)(AV15FirstColumn+2),  context.GetMessage( "WWP_TSTo", "")) ;
            AV14CellRow = GXt_int3;
            GXt_dtime4 = DateTimeUtil.ResetTime( AV67TFVincularTrnFecha_To ) ;
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
         if ( StringUtil.StrCmp(AV35Session.Get("VincularTrnWWColumnsSelector"), "") != 0 )
         {
            AV42ColumnsSelectorXML = AV35Session.Get("VincularTrnWWColumnsSelector");
            AV39ColumnsSelector.FromXml(AV42ColumnsSelectorXML, null, "", "");
         }
         else
         {
            /* Execute user subroutine: 'INITIALIZECOLUMNSSELECTOR' */
            S151 ();
            if (returnInSub) return;
         }
         AV39ColumnsSelector.gxTpr_Columns.Sort("Order");
         AV70GXV1 = 1;
         while ( AV70GXV1 <= AV39ColumnsSelector.gxTpr_Columns.Count )
         {
            AV41ColumnsSelector_Column = ((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV39ColumnsSelector.gxTpr_Columns.Item(AV70GXV1));
            if ( AV41ColumnsSelector_Column.gxTpr_Isvisible )
            {
               AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV47VisibleColumnCount), 1, 1).Text = context.GetMessage( (String.IsNullOrEmpty(StringUtil.RTrim( AV41ColumnsSelector_Column.gxTpr_Displayname)) ? AV41ColumnsSelector_Column.gxTpr_Columnname : AV41ColumnsSelector_Column.gxTpr_Displayname), "");
               AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV47VisibleColumnCount), 1, 1).Bold = 1;
               AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV47VisibleColumnCount), 1, 1).Color = 11;
               AV47VisibleColumnCount = (long)(AV47VisibleColumnCount+1);
            }
            AV70GXV1 = (int)(AV70GXV1+1);
         }
      }

      protected void S161( )
      {
         /* 'WRITEDATA' Routine */
         returnInSub = false;
         AV72Vinculartrnwwds_1_filterfulltext = AV19FilterFullText;
         AV73Vinculartrnwwds_2_dynamicfiltersselector1 = AV20DynamicFiltersSelector1;
         AV74Vinculartrnwwds_3_dynamicfiltersoperator1 = AV21DynamicFiltersOperator1;
         AV75Vinculartrnwwds_4_vinculartrnsolidicutd1 = AV22VincularTrnSolidicutd1;
         AV76Vinculartrnwwds_5_proveedornombre1 = AV23ProveedorNombre1;
         AV77Vinculartrnwwds_6_dynamicfiltersenabled2 = AV24DynamicFiltersEnabled2;
         AV78Vinculartrnwwds_7_dynamicfiltersselector2 = AV25DynamicFiltersSelector2;
         AV79Vinculartrnwwds_8_dynamicfiltersoperator2 = AV26DynamicFiltersOperator2;
         AV80Vinculartrnwwds_9_vinculartrnsolidicutd2 = AV27VincularTrnSolidicutd2;
         AV81Vinculartrnwwds_10_proveedornombre2 = AV28ProveedorNombre2;
         AV82Vinculartrnwwds_11_dynamicfiltersenabled3 = AV29DynamicFiltersEnabled3;
         AV83Vinculartrnwwds_12_dynamicfiltersselector3 = AV30DynamicFiltersSelector3;
         AV84Vinculartrnwwds_13_dynamicfiltersoperator3 = AV31DynamicFiltersOperator3;
         AV85Vinculartrnwwds_14_vinculartrnsolidicutd3 = AV32VincularTrnSolidicutd3;
         AV86Vinculartrnwwds_15_proveedornombre3 = AV33ProveedorNombre3;
         AV87Vinculartrnwwds_16_tfvinculartrnid = AV50TFVincularTrnId;
         AV88Vinculartrnwwds_17_tfvinculartrnid_to = AV51TFVincularTrnId_To;
         AV89Vinculartrnwwds_18_tfproveedorid = AV52TFProveedorID;
         AV90Vinculartrnwwds_19_tfproveedorid_to = AV53TFProveedorID_To;
         AV91Vinculartrnwwds_20_tfproveedornombre = AV54TFProveedorNombre;
         AV92Vinculartrnwwds_21_tfproveedornombre_sel = AV55TFProveedorNombre_Sel;
         AV93Vinculartrnwwds_22_tfvinculartrnsolidicutd = AV56TFVincularTrnSolidicutd;
         AV94Vinculartrnwwds_23_tfvinculartrnsolidicutd_to = AV57TFVincularTrnSolidicutd_To;
         AV95Vinculartrnwwds_24_tfvinculartrnnombresol = AV58TFVincularTrnNombreSol;
         AV96Vinculartrnwwds_25_tfvinculartrnnombresol_sel = AV59TFVincularTrnNombreSol_Sel;
         AV97Vinculartrnwwds_26_tfvinculartrntelefonosol = AV60TFVincularTrnTelefonoSol;
         AV98Vinculartrnwwds_27_tfvinculartrntelefonosol_sel = AV61TFVincularTrnTelefonoSol_Sel;
         AV99Vinculartrnwwds_28_tfdocumentacionid = AV62TFDocumentacionId;
         AV100Vinculartrnwwds_29_tfdocumentacionid_to = AV63TFDocumentacionId_To;
         AV101Vinculartrnwwds_30_tfvinculartrncomentario = AV64TFVincularTrnComentario;
         AV102Vinculartrnwwds_31_tfvinculartrncomentario_sel = AV65TFVincularTrnComentario_Sel;
         AV103Vinculartrnwwds_32_tfvinculartrnfecha = AV66TFVincularTrnFecha;
         AV104Vinculartrnwwds_33_tfvinculartrnfecha_to = AV67TFVincularTrnFecha_To;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV72Vinculartrnwwds_1_filterfulltext ,
                                              AV73Vinculartrnwwds_2_dynamicfiltersselector1 ,
                                              AV74Vinculartrnwwds_3_dynamicfiltersoperator1 ,
                                              AV75Vinculartrnwwds_4_vinculartrnsolidicutd1 ,
                                              AV76Vinculartrnwwds_5_proveedornombre1 ,
                                              AV77Vinculartrnwwds_6_dynamicfiltersenabled2 ,
                                              AV78Vinculartrnwwds_7_dynamicfiltersselector2 ,
                                              AV79Vinculartrnwwds_8_dynamicfiltersoperator2 ,
                                              AV80Vinculartrnwwds_9_vinculartrnsolidicutd2 ,
                                              AV81Vinculartrnwwds_10_proveedornombre2 ,
                                              AV82Vinculartrnwwds_11_dynamicfiltersenabled3 ,
                                              AV83Vinculartrnwwds_12_dynamicfiltersselector3 ,
                                              AV84Vinculartrnwwds_13_dynamicfiltersoperator3 ,
                                              AV85Vinculartrnwwds_14_vinculartrnsolidicutd3 ,
                                              AV86Vinculartrnwwds_15_proveedornombre3 ,
                                              AV87Vinculartrnwwds_16_tfvinculartrnid ,
                                              AV88Vinculartrnwwds_17_tfvinculartrnid_to ,
                                              AV89Vinculartrnwwds_18_tfproveedorid ,
                                              AV90Vinculartrnwwds_19_tfproveedorid_to ,
                                              AV92Vinculartrnwwds_21_tfproveedornombre_sel ,
                                              AV91Vinculartrnwwds_20_tfproveedornombre ,
                                              AV93Vinculartrnwwds_22_tfvinculartrnsolidicutd ,
                                              AV94Vinculartrnwwds_23_tfvinculartrnsolidicutd_to ,
                                              AV96Vinculartrnwwds_25_tfvinculartrnnombresol_sel ,
                                              AV95Vinculartrnwwds_24_tfvinculartrnnombresol ,
                                              AV98Vinculartrnwwds_27_tfvinculartrntelefonosol_sel ,
                                              AV97Vinculartrnwwds_26_tfvinculartrntelefonosol ,
                                              AV99Vinculartrnwwds_28_tfdocumentacionid ,
                                              AV100Vinculartrnwwds_29_tfdocumentacionid_to ,
                                              AV102Vinculartrnwwds_31_tfvinculartrncomentario_sel ,
                                              AV101Vinculartrnwwds_30_tfvinculartrncomentario ,
                                              AV103Vinculartrnwwds_32_tfvinculartrnfecha ,
                                              AV104Vinculartrnwwds_33_tfvinculartrnfecha_to ,
                                              A491VincularTrnId ,
                                              A133ProveedorID ,
                                              A282ProveedorNombre ,
                                              A492VincularTrnSolidicutd ,
                                              A493VincularTrnNombreSol ,
                                              A494VincularTrnTelefonoSol ,
                                              A488DocumentacionId ,
                                              A497VincularTrnComentario ,
                                              A496VincularTrnFecha ,
                                              AV17OrderedBy ,
                                              AV18OrderedDsc } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG,
                                              TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.LONG, TypeConstants.LONG,
                                              TypeConstants.LONG, TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV72Vinculartrnwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV72Vinculartrnwwds_1_filterfulltext), "%", "");
         lV72Vinculartrnwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV72Vinculartrnwwds_1_filterfulltext), "%", "");
         lV72Vinculartrnwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV72Vinculartrnwwds_1_filterfulltext), "%", "");
         lV72Vinculartrnwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV72Vinculartrnwwds_1_filterfulltext), "%", "");
         lV72Vinculartrnwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV72Vinculartrnwwds_1_filterfulltext), "%", "");
         lV72Vinculartrnwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV72Vinculartrnwwds_1_filterfulltext), "%", "");
         lV72Vinculartrnwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV72Vinculartrnwwds_1_filterfulltext), "%", "");
         lV72Vinculartrnwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV72Vinculartrnwwds_1_filterfulltext), "%", "");
         lV76Vinculartrnwwds_5_proveedornombre1 = StringUtil.PadR( StringUtil.RTrim( AV76Vinculartrnwwds_5_proveedornombre1), 80, "%");
         lV76Vinculartrnwwds_5_proveedornombre1 = StringUtil.PadR( StringUtil.RTrim( AV76Vinculartrnwwds_5_proveedornombre1), 80, "%");
         lV81Vinculartrnwwds_10_proveedornombre2 = StringUtil.PadR( StringUtil.RTrim( AV81Vinculartrnwwds_10_proveedornombre2), 80, "%");
         lV81Vinculartrnwwds_10_proveedornombre2 = StringUtil.PadR( StringUtil.RTrim( AV81Vinculartrnwwds_10_proveedornombre2), 80, "%");
         lV86Vinculartrnwwds_15_proveedornombre3 = StringUtil.PadR( StringUtil.RTrim( AV86Vinculartrnwwds_15_proveedornombre3), 80, "%");
         lV86Vinculartrnwwds_15_proveedornombre3 = StringUtil.PadR( StringUtil.RTrim( AV86Vinculartrnwwds_15_proveedornombre3), 80, "%");
         lV91Vinculartrnwwds_20_tfproveedornombre = StringUtil.PadR( StringUtil.RTrim( AV91Vinculartrnwwds_20_tfproveedornombre), 80, "%");
         lV95Vinculartrnwwds_24_tfvinculartrnnombresol = StringUtil.PadR( StringUtil.RTrim( AV95Vinculartrnwwds_24_tfvinculartrnnombresol), 80, "%");
         lV97Vinculartrnwwds_26_tfvinculartrntelefonosol = StringUtil.PadR( StringUtil.RTrim( AV97Vinculartrnwwds_26_tfvinculartrntelefonosol), 20, "%");
         lV101Vinculartrnwwds_30_tfvinculartrncomentario = StringUtil.Concat( StringUtil.RTrim( AV101Vinculartrnwwds_30_tfvinculartrncomentario), "%", "");
         /* Using cursor P006C2 */
         pr_default.execute(0, new Object[] {lV72Vinculartrnwwds_1_filterfulltext, lV72Vinculartrnwwds_1_filterfulltext, lV72Vinculartrnwwds_1_filterfulltext, lV72Vinculartrnwwds_1_filterfulltext, lV72Vinculartrnwwds_1_filterfulltext, lV72Vinculartrnwwds_1_filterfulltext, lV72Vinculartrnwwds_1_filterfulltext, lV72Vinculartrnwwds_1_filterfulltext, AV75Vinculartrnwwds_4_vinculartrnsolidicutd1, AV75Vinculartrnwwds_4_vinculartrnsolidicutd1, AV75Vinculartrnwwds_4_vinculartrnsolidicutd1, lV76Vinculartrnwwds_5_proveedornombre1, lV76Vinculartrnwwds_5_proveedornombre1, AV80Vinculartrnwwds_9_vinculartrnsolidicutd2, AV80Vinculartrnwwds_9_vinculartrnsolidicutd2, AV80Vinculartrnwwds_9_vinculartrnsolidicutd2, lV81Vinculartrnwwds_10_proveedornombre2, lV81Vinculartrnwwds_10_proveedornombre2, AV85Vinculartrnwwds_14_vinculartrnsolidicutd3, AV85Vinculartrnwwds_14_vinculartrnsolidicutd3, AV85Vinculartrnwwds_14_vinculartrnsolidicutd3, lV86Vinculartrnwwds_15_proveedornombre3, lV86Vinculartrnwwds_15_proveedornombre3, AV87Vinculartrnwwds_16_tfvinculartrnid, AV88Vinculartrnwwds_17_tfvinculartrnid_to, AV89Vinculartrnwwds_18_tfproveedorid, AV90Vinculartrnwwds_19_tfproveedorid_to, lV91Vinculartrnwwds_20_tfproveedornombre, AV92Vinculartrnwwds_21_tfproveedornombre_sel, AV93Vinculartrnwwds_22_tfvinculartrnsolidicutd, AV94Vinculartrnwwds_23_tfvinculartrnsolidicutd_to, lV95Vinculartrnwwds_24_tfvinculartrnnombresol, AV96Vinculartrnwwds_25_tfvinculartrnnombresol_sel, lV97Vinculartrnwwds_26_tfvinculartrntelefonosol, AV98Vinculartrnwwds_27_tfvinculartrntelefonosol_sel, AV99Vinculartrnwwds_28_tfdocumentacionid, AV100Vinculartrnwwds_29_tfdocumentacionid_to, lV101Vinculartrnwwds_30_tfvinculartrncomentario, AV102Vinculartrnwwds_31_tfvinculartrncomentario_sel, AV103Vinculartrnwwds_32_tfvinculartrnfecha, AV104Vinculartrnwwds_33_tfvinculartrnfecha_to});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A496VincularTrnFecha = P006C2_A496VincularTrnFecha[0];
            A497VincularTrnComentario = P006C2_A497VincularTrnComentario[0];
            A488DocumentacionId = P006C2_A488DocumentacionId[0];
            n488DocumentacionId = P006C2_n488DocumentacionId[0];
            A494VincularTrnTelefonoSol = P006C2_A494VincularTrnTelefonoSol[0];
            A493VincularTrnNombreSol = P006C2_A493VincularTrnNombreSol[0];
            A282ProveedorNombre = P006C2_A282ProveedorNombre[0];
            A133ProveedorID = P006C2_A133ProveedorID[0];
            A491VincularTrnId = P006C2_A491VincularTrnId[0];
            A492VincularTrnSolidicutd = P006C2_A492VincularTrnSolidicutd[0];
            A488DocumentacionId = P006C2_A488DocumentacionId[0];
            n488DocumentacionId = P006C2_n488DocumentacionId[0];
            A282ProveedorNombre = P006C2_A282ProveedorNombre[0];
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
            AV105GXV2 = 1;
            while ( AV105GXV2 <= AV39ColumnsSelector.gxTpr_Columns.Count )
            {
               AV41ColumnsSelector_Column = ((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV39ColumnsSelector.gxTpr_Columns.Item(AV105GXV2));
               if ( AV41ColumnsSelector_Column.gxTpr_Isvisible )
               {
                  if ( StringUtil.StrCmp(AV41ColumnsSelector_Column.gxTpr_Columnname, "VincularTrnId") == 0 )
                  {
                     AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV47VisibleColumnCount), 1, 1).Number = A491VincularTrnId;
                  }
                  else if ( StringUtil.StrCmp(AV41ColumnsSelector_Column.gxTpr_Columnname, "ProveedorID") == 0 )
                  {
                     AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV47VisibleColumnCount), 1, 1).Number = A133ProveedorID;
                  }
                  else if ( StringUtil.StrCmp(AV41ColumnsSelector_Column.gxTpr_Columnname, "ProveedorNombre") == 0 )
                  {
                     GXt_char2 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A282ProveedorNombre, out  GXt_char2) ;
                     AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV47VisibleColumnCount), 1, 1).Text = GXt_char2;
                  }
                  else if ( StringUtil.StrCmp(AV41ColumnsSelector_Column.gxTpr_Columnname, "VincularTrnSolidicutd") == 0 )
                  {
                     AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV47VisibleColumnCount), 1, 1).Number = A492VincularTrnSolidicutd;
                  }
                  else if ( StringUtil.StrCmp(AV41ColumnsSelector_Column.gxTpr_Columnname, "VincularTrnNombreSol") == 0 )
                  {
                     GXt_char2 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A493VincularTrnNombreSol, out  GXt_char2) ;
                     AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV47VisibleColumnCount), 1, 1).Text = GXt_char2;
                  }
                  else if ( StringUtil.StrCmp(AV41ColumnsSelector_Column.gxTpr_Columnname, "VincularTrnTelefonoSol") == 0 )
                  {
                     GXt_char2 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A494VincularTrnTelefonoSol, out  GXt_char2) ;
                     AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV47VisibleColumnCount), 1, 1).Text = GXt_char2;
                  }
                  else if ( StringUtil.StrCmp(AV41ColumnsSelector_Column.gxTpr_Columnname, "DocumentacionId") == 0 )
                  {
                     AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV47VisibleColumnCount), 1, 1).Number = A488DocumentacionId;
                  }
                  else if ( StringUtil.StrCmp(AV41ColumnsSelector_Column.gxTpr_Columnname, "VincularTrnImagen") == 0 )
                  {
                     AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV47VisibleColumnCount), 1, 1).Text = "";
                  }
                  else if ( StringUtil.StrCmp(AV41ColumnsSelector_Column.gxTpr_Columnname, "VincularTrnComentario") == 0 )
                  {
                     GXt_char2 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  StringUtil.Substring( A497VincularTrnComentario, 1, 1000), out  GXt_char2) ;
                     AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV47VisibleColumnCount), 1, 1).Text = GXt_char2;
                  }
                  else if ( StringUtil.StrCmp(AV41ColumnsSelector_Column.gxTpr_Columnname, "VincularTrnFecha") == 0 )
                  {
                     GXt_dtime4 = DateTimeUtil.ResetTime( A496VincularTrnFecha ) ;
                     AV11ExcelDocument.SetDateFormat(context, 8, 5, ((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0), DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt")), "/", ":", " ");
                     AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV47VisibleColumnCount), 1, 1).Date = GXt_dtime4;
                  }
                  else if ( StringUtil.StrCmp(AV41ColumnsSelector_Column.gxTpr_Columnname, "DocumentacionIcono") == 0 )
                  {
                     AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV47VisibleColumnCount), 1, 1).Text = "";
                  }
                  AV47VisibleColumnCount = (long)(AV47VisibleColumnCount+1);
               }
               AV105GXV2 = (int)(AV105GXV2+1);
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
         AV35Session.Set("WWPExportFileName", "VincularTrnWWExport.xlsx");
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
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV39ColumnsSelector,  "VincularTrnId",  "",  "Nro",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV39ColumnsSelector,  "ProveedorID",  "",  "Código del Proveedor",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV39ColumnsSelector,  "ProveedorNombre",  "",  "Proveedor Nombre",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV39ColumnsSelector,  "VincularTrnSolidicutd",  "",  "Solicitud",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV39ColumnsSelector,  "VincularTrnNombreSol",  "",  "Nombre del Cliente",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV39ColumnsSelector,  "VincularTrnTelefonoSol",  "",  "Teléfono del Cliente",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV39ColumnsSelector,  "DocumentacionId",  "",  "Documentación",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV39ColumnsSelector,  "VincularTrnImagen",  "",  "Fotografia",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV39ColumnsSelector,  "VincularTrnComentario",  "",  "Comentario",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV39ColumnsSelector,  "VincularTrnFecha",  "",  "Fecha",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV39ColumnsSelector,  "DocumentacionIcono",  "",  "Icono",  true,  "") ;
         GXt_char2 = AV43UserCustomValue;
         new GeneXus.Programs.wwpbaseobjects.loadcolumnsselectorstate(context ).execute(  "VincularTrnWWColumnsSelector", out  GXt_char2) ;
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
         if ( StringUtil.StrCmp(AV35Session.Get("VincularTrnWWGridState"), "") == 0 )
         {
            AV37GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "VincularTrnWWGridState"), null, "", "");
         }
         else
         {
            AV37GridState.FromXml(AV35Session.Get("VincularTrnWWGridState"), null, "", "");
         }
         AV17OrderedBy = AV37GridState.gxTpr_Orderedby;
         AV18OrderedDsc = AV37GridState.gxTpr_Ordereddsc;
         AV106GXV3 = 1;
         while ( AV106GXV3 <= AV37GridState.gxTpr_Filtervalues.Count )
         {
            AV38GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV37GridState.gxTpr_Filtervalues.Item(AV106GXV3));
            if ( StringUtil.StrCmp(AV38GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV19FilterFullText = AV38GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV38GridStateFilterValue.gxTpr_Name, "TFVINCULARTRNID") == 0 )
            {
               AV50TFVincularTrnId = (long)(Math.Round(NumberUtil.Val( AV38GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV51TFVincularTrnId_To = (long)(Math.Round(NumberUtil.Val( AV38GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV38GridStateFilterValue.gxTpr_Name, "TFPROVEEDORID") == 0 )
            {
               AV52TFProveedorID = (long)(Math.Round(NumberUtil.Val( AV38GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV53TFProveedorID_To = (long)(Math.Round(NumberUtil.Val( AV38GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV38GridStateFilterValue.gxTpr_Name, "TFPROVEEDORNOMBRE") == 0 )
            {
               AV54TFProveedorNombre = AV38GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV38GridStateFilterValue.gxTpr_Name, "TFPROVEEDORNOMBRE_SEL") == 0 )
            {
               AV55TFProveedorNombre_Sel = AV38GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV38GridStateFilterValue.gxTpr_Name, "TFVINCULARTRNSOLIDICUTD") == 0 )
            {
               AV56TFVincularTrnSolidicutd = (long)(Math.Round(NumberUtil.Val( AV38GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV57TFVincularTrnSolidicutd_To = (long)(Math.Round(NumberUtil.Val( AV38GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV38GridStateFilterValue.gxTpr_Name, "TFVINCULARTRNNOMBRESOL") == 0 )
            {
               AV58TFVincularTrnNombreSol = AV38GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV38GridStateFilterValue.gxTpr_Name, "TFVINCULARTRNNOMBRESOL_SEL") == 0 )
            {
               AV59TFVincularTrnNombreSol_Sel = AV38GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV38GridStateFilterValue.gxTpr_Name, "TFVINCULARTRNTELEFONOSOL") == 0 )
            {
               AV60TFVincularTrnTelefonoSol = AV38GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV38GridStateFilterValue.gxTpr_Name, "TFVINCULARTRNTELEFONOSOL_SEL") == 0 )
            {
               AV61TFVincularTrnTelefonoSol_Sel = AV38GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV38GridStateFilterValue.gxTpr_Name, "TFDOCUMENTACIONID") == 0 )
            {
               AV62TFDocumentacionId = (long)(Math.Round(NumberUtil.Val( AV38GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV63TFDocumentacionId_To = (long)(Math.Round(NumberUtil.Val( AV38GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV38GridStateFilterValue.gxTpr_Name, "TFVINCULARTRNCOMENTARIO") == 0 )
            {
               AV64TFVincularTrnComentario = AV38GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV38GridStateFilterValue.gxTpr_Name, "TFVINCULARTRNCOMENTARIO_SEL") == 0 )
            {
               AV65TFVincularTrnComentario_Sel = AV38GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV38GridStateFilterValue.gxTpr_Name, "TFVINCULARTRNFECHA") == 0 )
            {
               AV66TFVincularTrnFecha = context.localUtil.CToD( AV38GridStateFilterValue.gxTpr_Value, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               AV67TFVincularTrnFecha_To = context.localUtil.CToD( AV38GridStateFilterValue.gxTpr_Valueto, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
            }
            AV106GXV3 = (int)(AV106GXV3+1);
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
         AV69Pgmname = "";
         GXKey = "";
         GXEncryptionTmp = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV11ExcelDocument = new ExcelDocumentI();
         AV19FilterFullText = "";
         AV37GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV34GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV20DynamicFiltersSelector1 = "";
         AV23ProveedorNombre1 = "";
         AV25DynamicFiltersSelector2 = "";
         AV28ProveedorNombre2 = "";
         AV30DynamicFiltersSelector3 = "";
         AV33ProveedorNombre3 = "";
         AV55TFProveedorNombre_Sel = "";
         AV54TFProveedorNombre = "";
         AV59TFVincularTrnNombreSol_Sel = "";
         AV58TFVincularTrnNombreSol = "";
         AV61TFVincularTrnTelefonoSol_Sel = "";
         AV60TFVincularTrnTelefonoSol = "";
         AV65TFVincularTrnComentario_Sel = "";
         AV64TFVincularTrnComentario = "";
         AV66TFVincularTrnFecha = DateTime.MinValue;
         AV67TFVincularTrnFecha_To = DateTime.MinValue;
         AV35Session = context.GetSession();
         AV42ColumnsSelectorXML = "";
         AV39ColumnsSelector = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector(context);
         AV41ColumnsSelector_Column = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column(context);
         AV72Vinculartrnwwds_1_filterfulltext = "";
         AV73Vinculartrnwwds_2_dynamicfiltersselector1 = "";
         AV76Vinculartrnwwds_5_proveedornombre1 = "";
         AV78Vinculartrnwwds_7_dynamicfiltersselector2 = "";
         AV81Vinculartrnwwds_10_proveedornombre2 = "";
         AV83Vinculartrnwwds_12_dynamicfiltersselector3 = "";
         AV86Vinculartrnwwds_15_proveedornombre3 = "";
         AV91Vinculartrnwwds_20_tfproveedornombre = "";
         AV92Vinculartrnwwds_21_tfproveedornombre_sel = "";
         AV95Vinculartrnwwds_24_tfvinculartrnnombresol = "";
         AV96Vinculartrnwwds_25_tfvinculartrnnombresol_sel = "";
         AV97Vinculartrnwwds_26_tfvinculartrntelefonosol = "";
         AV98Vinculartrnwwds_27_tfvinculartrntelefonosol_sel = "";
         AV101Vinculartrnwwds_30_tfvinculartrncomentario = "";
         AV102Vinculartrnwwds_31_tfvinculartrncomentario_sel = "";
         AV103Vinculartrnwwds_32_tfvinculartrnfecha = DateTime.MinValue;
         AV104Vinculartrnwwds_33_tfvinculartrnfecha_to = DateTime.MinValue;
         lV72Vinculartrnwwds_1_filterfulltext = "";
         lV76Vinculartrnwwds_5_proveedornombre1 = "";
         lV81Vinculartrnwwds_10_proveedornombre2 = "";
         lV86Vinculartrnwwds_15_proveedornombre3 = "";
         lV91Vinculartrnwwds_20_tfproveedornombre = "";
         lV95Vinculartrnwwds_24_tfvinculartrnnombresol = "";
         lV97Vinculartrnwwds_26_tfvinculartrntelefonosol = "";
         lV101Vinculartrnwwds_30_tfvinculartrncomentario = "";
         A282ProveedorNombre = "";
         A493VincularTrnNombreSol = "";
         A494VincularTrnTelefonoSol = "";
         A497VincularTrnComentario = "";
         A496VincularTrnFecha = DateTime.MinValue;
         P006C2_A496VincularTrnFecha = new DateTime[] {DateTime.MinValue} ;
         P006C2_A497VincularTrnComentario = new string[] {""} ;
         P006C2_A488DocumentacionId = new long[1] ;
         P006C2_n488DocumentacionId = new bool[] {false} ;
         P006C2_A494VincularTrnTelefonoSol = new string[] {""} ;
         P006C2_A493VincularTrnNombreSol = new string[] {""} ;
         P006C2_A282ProveedorNombre = new string[] {""} ;
         P006C2_A133ProveedorID = new long[1] ;
         P006C2_A491VincularTrnId = new long[1] ;
         P006C2_A492VincularTrnSolidicutd = new long[1] ;
         GXt_dtime4 = (DateTime)(DateTime.MinValue);
         AV43UserCustomValue = "";
         GXt_char2 = "";
         AV40ColumnsSelectorAux = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector(context);
         AV38GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.vinculartrnwwexport__default(),
            new Object[][] {
                new Object[] {
               P006C2_A496VincularTrnFecha, P006C2_A497VincularTrnComentario, P006C2_A488DocumentacionId, P006C2_n488DocumentacionId, P006C2_A494VincularTrnTelefonoSol, P006C2_A493VincularTrnNombreSol, P006C2_A282ProveedorNombre, P006C2_A133ProveedorID, P006C2_A491VincularTrnId, P006C2_A492VincularTrnSolidicutd
               }
            }
         );
         AV69Pgmname = "VincularTrnWWExport";
         /* GeneXus formulas. */
         AV69Pgmname = "VincularTrnWWExport";
      }

      private short AV21DynamicFiltersOperator1 ;
      private short AV26DynamicFiltersOperator2 ;
      private short AV31DynamicFiltersOperator3 ;
      private short GXt_int3 ;
      private short AV74Vinculartrnwwds_3_dynamicfiltersoperator1 ;
      private short AV79Vinculartrnwwds_8_dynamicfiltersoperator2 ;
      private short AV84Vinculartrnwwds_13_dynamicfiltersoperator3 ;
      private short AV17OrderedBy ;
      private int AV14CellRow ;
      private int AV15FirstColumn ;
      private int AV16Random ;
      private int AV70GXV1 ;
      private int AV105GXV2 ;
      private int AV106GXV3 ;
      private long AV22VincularTrnSolidicutd1 ;
      private long AV27VincularTrnSolidicutd2 ;
      private long AV32VincularTrnSolidicutd3 ;
      private long AV50TFVincularTrnId ;
      private long AV51TFVincularTrnId_To ;
      private long AV52TFProveedorID ;
      private long AV53TFProveedorID_To ;
      private long AV56TFVincularTrnSolidicutd ;
      private long AV57TFVincularTrnSolidicutd_To ;
      private long AV62TFDocumentacionId ;
      private long AV63TFDocumentacionId_To ;
      private long AV47VisibleColumnCount ;
      private long AV75Vinculartrnwwds_4_vinculartrnsolidicutd1 ;
      private long AV80Vinculartrnwwds_9_vinculartrnsolidicutd2 ;
      private long AV85Vinculartrnwwds_14_vinculartrnsolidicutd3 ;
      private long AV87Vinculartrnwwds_16_tfvinculartrnid ;
      private long AV88Vinculartrnwwds_17_tfvinculartrnid_to ;
      private long AV89Vinculartrnwwds_18_tfproveedorid ;
      private long AV90Vinculartrnwwds_19_tfproveedorid_to ;
      private long AV93Vinculartrnwwds_22_tfvinculartrnsolidicutd ;
      private long AV94Vinculartrnwwds_23_tfvinculartrnsolidicutd_to ;
      private long AV99Vinculartrnwwds_28_tfdocumentacionid ;
      private long AV100Vinculartrnwwds_29_tfdocumentacionid_to ;
      private long A491VincularTrnId ;
      private long A133ProveedorID ;
      private long A492VincularTrnSolidicutd ;
      private long A488DocumentacionId ;
      private string AV69Pgmname ;
      private string GXKey ;
      private string GXEncryptionTmp ;
      private string AV23ProveedorNombre1 ;
      private string AV28ProveedorNombre2 ;
      private string AV33ProveedorNombre3 ;
      private string AV55TFProveedorNombre_Sel ;
      private string AV54TFProveedorNombre ;
      private string AV59TFVincularTrnNombreSol_Sel ;
      private string AV58TFVincularTrnNombreSol ;
      private string AV61TFVincularTrnTelefonoSol_Sel ;
      private string AV60TFVincularTrnTelefonoSol ;
      private string AV76Vinculartrnwwds_5_proveedornombre1 ;
      private string AV81Vinculartrnwwds_10_proveedornombre2 ;
      private string AV86Vinculartrnwwds_15_proveedornombre3 ;
      private string AV91Vinculartrnwwds_20_tfproveedornombre ;
      private string AV92Vinculartrnwwds_21_tfproveedornombre_sel ;
      private string AV95Vinculartrnwwds_24_tfvinculartrnnombresol ;
      private string AV96Vinculartrnwwds_25_tfvinculartrnnombresol_sel ;
      private string AV97Vinculartrnwwds_26_tfvinculartrntelefonosol ;
      private string AV98Vinculartrnwwds_27_tfvinculartrntelefonosol_sel ;
      private string lV76Vinculartrnwwds_5_proveedornombre1 ;
      private string lV81Vinculartrnwwds_10_proveedornombre2 ;
      private string lV86Vinculartrnwwds_15_proveedornombre3 ;
      private string lV91Vinculartrnwwds_20_tfproveedornombre ;
      private string lV95Vinculartrnwwds_24_tfvinculartrnnombresol ;
      private string lV97Vinculartrnwwds_26_tfvinculartrntelefonosol ;
      private string A282ProveedorNombre ;
      private string A493VincularTrnNombreSol ;
      private string A494VincularTrnTelefonoSol ;
      private string GXt_char2 ;
      private DateTime GXt_dtime4 ;
      private DateTime AV66TFVincularTrnFecha ;
      private DateTime AV67TFVincularTrnFecha_To ;
      private DateTime AV103Vinculartrnwwds_32_tfvinculartrnfecha ;
      private DateTime AV104Vinculartrnwwds_33_tfvinculartrnfecha_to ;
      private DateTime A496VincularTrnFecha ;
      private bool AV8IsAuthorized ;
      private bool GXt_boolean1 ;
      private bool returnInSub ;
      private bool AV24DynamicFiltersEnabled2 ;
      private bool AV29DynamicFiltersEnabled3 ;
      private bool AV77Vinculartrnwwds_6_dynamicfiltersenabled2 ;
      private bool AV82Vinculartrnwwds_11_dynamicfiltersenabled3 ;
      private bool AV18OrderedDsc ;
      private bool n488DocumentacionId ;
      private string AV42ColumnsSelectorXML ;
      private string A497VincularTrnComentario ;
      private string AV43UserCustomValue ;
      private string AV12Filename ;
      private string AV13ErrorMessage ;
      private string AV19FilterFullText ;
      private string AV20DynamicFiltersSelector1 ;
      private string AV25DynamicFiltersSelector2 ;
      private string AV30DynamicFiltersSelector3 ;
      private string AV65TFVincularTrnComentario_Sel ;
      private string AV64TFVincularTrnComentario ;
      private string AV72Vinculartrnwwds_1_filterfulltext ;
      private string AV73Vinculartrnwwds_2_dynamicfiltersselector1 ;
      private string AV78Vinculartrnwwds_7_dynamicfiltersselector2 ;
      private string AV83Vinculartrnwwds_12_dynamicfiltersselector3 ;
      private string AV101Vinculartrnwwds_30_tfvinculartrncomentario ;
      private string AV102Vinculartrnwwds_31_tfvinculartrncomentario_sel ;
      private string lV72Vinculartrnwwds_1_filterfulltext ;
      private string lV101Vinculartrnwwds_30_tfvinculartrncomentario ;
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
      private DateTime[] P006C2_A496VincularTrnFecha ;
      private string[] P006C2_A497VincularTrnComentario ;
      private long[] P006C2_A488DocumentacionId ;
      private bool[] P006C2_n488DocumentacionId ;
      private string[] P006C2_A494VincularTrnTelefonoSol ;
      private string[] P006C2_A493VincularTrnNombreSol ;
      private string[] P006C2_A282ProveedorNombre ;
      private long[] P006C2_A133ProveedorID ;
      private long[] P006C2_A491VincularTrnId ;
      private long[] P006C2_A492VincularTrnSolidicutd ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector AV40ColumnsSelectorAux ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV38GridStateFilterValue ;
      private string aP0_Filename ;
      private string aP1_ErrorMessage ;
   }

   public class vinculartrnwwexport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P006C2( IGxContext context ,
                                             string AV72Vinculartrnwwds_1_filterfulltext ,
                                             string AV73Vinculartrnwwds_2_dynamicfiltersselector1 ,
                                             short AV74Vinculartrnwwds_3_dynamicfiltersoperator1 ,
                                             long AV75Vinculartrnwwds_4_vinculartrnsolidicutd1 ,
                                             string AV76Vinculartrnwwds_5_proveedornombre1 ,
                                             bool AV77Vinculartrnwwds_6_dynamicfiltersenabled2 ,
                                             string AV78Vinculartrnwwds_7_dynamicfiltersselector2 ,
                                             short AV79Vinculartrnwwds_8_dynamicfiltersoperator2 ,
                                             long AV80Vinculartrnwwds_9_vinculartrnsolidicutd2 ,
                                             string AV81Vinculartrnwwds_10_proveedornombre2 ,
                                             bool AV82Vinculartrnwwds_11_dynamicfiltersenabled3 ,
                                             string AV83Vinculartrnwwds_12_dynamicfiltersselector3 ,
                                             short AV84Vinculartrnwwds_13_dynamicfiltersoperator3 ,
                                             long AV85Vinculartrnwwds_14_vinculartrnsolidicutd3 ,
                                             string AV86Vinculartrnwwds_15_proveedornombre3 ,
                                             long AV87Vinculartrnwwds_16_tfvinculartrnid ,
                                             long AV88Vinculartrnwwds_17_tfvinculartrnid_to ,
                                             long AV89Vinculartrnwwds_18_tfproveedorid ,
                                             long AV90Vinculartrnwwds_19_tfproveedorid_to ,
                                             string AV92Vinculartrnwwds_21_tfproveedornombre_sel ,
                                             string AV91Vinculartrnwwds_20_tfproveedornombre ,
                                             long AV93Vinculartrnwwds_22_tfvinculartrnsolidicutd ,
                                             long AV94Vinculartrnwwds_23_tfvinculartrnsolidicutd_to ,
                                             string AV96Vinculartrnwwds_25_tfvinculartrnnombresol_sel ,
                                             string AV95Vinculartrnwwds_24_tfvinculartrnnombresol ,
                                             string AV98Vinculartrnwwds_27_tfvinculartrntelefonosol_sel ,
                                             string AV97Vinculartrnwwds_26_tfvinculartrntelefonosol ,
                                             long AV99Vinculartrnwwds_28_tfdocumentacionid ,
                                             long AV100Vinculartrnwwds_29_tfdocumentacionid_to ,
                                             string AV102Vinculartrnwwds_31_tfvinculartrncomentario_sel ,
                                             string AV101Vinculartrnwwds_30_tfvinculartrncomentario ,
                                             DateTime AV103Vinculartrnwwds_32_tfvinculartrnfecha ,
                                             DateTime AV104Vinculartrnwwds_33_tfvinculartrnfecha_to ,
                                             long A491VincularTrnId ,
                                             long A133ProveedorID ,
                                             string A282ProveedorNombre ,
                                             long A492VincularTrnSolidicutd ,
                                             string A493VincularTrnNombreSol ,
                                             string A494VincularTrnTelefonoSol ,
                                             long A488DocumentacionId ,
                                             string A497VincularTrnComentario ,
                                             DateTime A496VincularTrnFecha ,
                                             short AV17OrderedBy ,
                                             bool AV18OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int5 = new short[41];
         Object[] GXv_Object6 = new Object[2];
         scmdbuf = "SELECT T1.[VincularTrnFecha], T1.[VincularTrnComentario], T2.[DocumentacionId], T1.[VincularTrnTelefonoSol], T1.[VincularTrnNombreSol], T2.[ProveedorNombre], T1.[ProveedorID], T1.[VincularTrnId], T1.[VincularTrnSolidicutd] FROM ([VincularTrn] T1 INNER JOIN [Proveedor] T2 ON T2.[ProveedorID] = T1.[ProveedorID])";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Vinculartrnwwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( CONVERT( char(18), CAST(T1.[VincularTrnId] AS decimal(18,0))) like '%' + @lV72Vinculartrnwwds_1_filterfulltext) or ( CONVERT( char(18), CAST(T1.[ProveedorID] AS decimal(18,0))) like '%' + @lV72Vinculartrnwwds_1_filterfulltext) or ( UPPER(T2.[ProveedorNombre]) like '%' + UPPER(@lV72Vinculartrnwwds_1_filterfulltext)) or ( CONVERT( char(18), CAST(T1.[VincularTrnSolidicutd] AS decimal(18,0))) like '%' + @lV72Vinculartrnwwds_1_filterfulltext) or ( UPPER(T1.[VincularTrnNombreSol]) like '%' + UPPER(@lV72Vinculartrnwwds_1_filterfulltext)) or ( UPPER(T1.[VincularTrnTelefonoSol]) like '%' + UPPER(@lV72Vinculartrnwwds_1_filterfulltext)) or ( CONVERT( char(18), CAST(T2.[DocumentacionId] AS decimal(18,0))) like '%' + @lV72Vinculartrnwwds_1_filterfulltext) or ( UPPER(T1.[VincularTrnComentario]) like '%' + UPPER(@lV72Vinculartrnwwds_1_filterfulltext)))");
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
         }
         if ( ( StringUtil.StrCmp(AV73Vinculartrnwwds_2_dynamicfiltersselector1, "VINCULARTRNSOLIDICUTD") == 0 ) && ( AV74Vinculartrnwwds_3_dynamicfiltersoperator1 == 0 ) && ( ! (0==AV75Vinculartrnwwds_4_vinculartrnsolidicutd1) ) )
         {
            AddWhere(sWhereString, "(T1.[VincularTrnSolidicutd] < @AV75Vinculartrnwwds_4_vinculartrnsolidicutd1)");
         }
         else
         {
            GXv_int5[8] = 1;
         }
         if ( ( StringUtil.StrCmp(AV73Vinculartrnwwds_2_dynamicfiltersselector1, "VINCULARTRNSOLIDICUTD") == 0 ) && ( AV74Vinculartrnwwds_3_dynamicfiltersoperator1 == 1 ) && ( ! (0==AV75Vinculartrnwwds_4_vinculartrnsolidicutd1) ) )
         {
            AddWhere(sWhereString, "(T1.[VincularTrnSolidicutd] = @AV75Vinculartrnwwds_4_vinculartrnsolidicutd1)");
         }
         else
         {
            GXv_int5[9] = 1;
         }
         if ( ( StringUtil.StrCmp(AV73Vinculartrnwwds_2_dynamicfiltersselector1, "VINCULARTRNSOLIDICUTD") == 0 ) && ( AV74Vinculartrnwwds_3_dynamicfiltersoperator1 == 2 ) && ( ! (0==AV75Vinculartrnwwds_4_vinculartrnsolidicutd1) ) )
         {
            AddWhere(sWhereString, "(T1.[VincularTrnSolidicutd] > @AV75Vinculartrnwwds_4_vinculartrnsolidicutd1)");
         }
         else
         {
            GXv_int5[10] = 1;
         }
         if ( ( StringUtil.StrCmp(AV73Vinculartrnwwds_2_dynamicfiltersselector1, "PROVEEDORNOMBRE") == 0 ) && ( AV74Vinculartrnwwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV76Vinculartrnwwds_5_proveedornombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ProveedorNombre]) like UPPER(@lV76Vinculartrnwwds_5_proveedornombre1))");
         }
         else
         {
            GXv_int5[11] = 1;
         }
         if ( ( StringUtil.StrCmp(AV73Vinculartrnwwds_2_dynamicfiltersselector1, "PROVEEDORNOMBRE") == 0 ) && ( AV74Vinculartrnwwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV76Vinculartrnwwds_5_proveedornombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ProveedorNombre]) like '%' + UPPER(@lV76Vinculartrnwwds_5_proveedornombre1))");
         }
         else
         {
            GXv_int5[12] = 1;
         }
         if ( AV77Vinculartrnwwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV78Vinculartrnwwds_7_dynamicfiltersselector2, "VINCULARTRNSOLIDICUTD") == 0 ) && ( AV79Vinculartrnwwds_8_dynamicfiltersoperator2 == 0 ) && ( ! (0==AV80Vinculartrnwwds_9_vinculartrnsolidicutd2) ) )
         {
            AddWhere(sWhereString, "(T1.[VincularTrnSolidicutd] < @AV80Vinculartrnwwds_9_vinculartrnsolidicutd2)");
         }
         else
         {
            GXv_int5[13] = 1;
         }
         if ( AV77Vinculartrnwwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV78Vinculartrnwwds_7_dynamicfiltersselector2, "VINCULARTRNSOLIDICUTD") == 0 ) && ( AV79Vinculartrnwwds_8_dynamicfiltersoperator2 == 1 ) && ( ! (0==AV80Vinculartrnwwds_9_vinculartrnsolidicutd2) ) )
         {
            AddWhere(sWhereString, "(T1.[VincularTrnSolidicutd] = @AV80Vinculartrnwwds_9_vinculartrnsolidicutd2)");
         }
         else
         {
            GXv_int5[14] = 1;
         }
         if ( AV77Vinculartrnwwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV78Vinculartrnwwds_7_dynamicfiltersselector2, "VINCULARTRNSOLIDICUTD") == 0 ) && ( AV79Vinculartrnwwds_8_dynamicfiltersoperator2 == 2 ) && ( ! (0==AV80Vinculartrnwwds_9_vinculartrnsolidicutd2) ) )
         {
            AddWhere(sWhereString, "(T1.[VincularTrnSolidicutd] > @AV80Vinculartrnwwds_9_vinculartrnsolidicutd2)");
         }
         else
         {
            GXv_int5[15] = 1;
         }
         if ( AV77Vinculartrnwwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV78Vinculartrnwwds_7_dynamicfiltersselector2, "PROVEEDORNOMBRE") == 0 ) && ( AV79Vinculartrnwwds_8_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV81Vinculartrnwwds_10_proveedornombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ProveedorNombre]) like UPPER(@lV81Vinculartrnwwds_10_proveedornombre2))");
         }
         else
         {
            GXv_int5[16] = 1;
         }
         if ( AV77Vinculartrnwwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV78Vinculartrnwwds_7_dynamicfiltersselector2, "PROVEEDORNOMBRE") == 0 ) && ( AV79Vinculartrnwwds_8_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV81Vinculartrnwwds_10_proveedornombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ProveedorNombre]) like '%' + UPPER(@lV81Vinculartrnwwds_10_proveedornombre2))");
         }
         else
         {
            GXv_int5[17] = 1;
         }
         if ( AV82Vinculartrnwwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV83Vinculartrnwwds_12_dynamicfiltersselector3, "VINCULARTRNSOLIDICUTD") == 0 ) && ( AV84Vinculartrnwwds_13_dynamicfiltersoperator3 == 0 ) && ( ! (0==AV85Vinculartrnwwds_14_vinculartrnsolidicutd3) ) )
         {
            AddWhere(sWhereString, "(T1.[VincularTrnSolidicutd] < @AV85Vinculartrnwwds_14_vinculartrnsolidicutd3)");
         }
         else
         {
            GXv_int5[18] = 1;
         }
         if ( AV82Vinculartrnwwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV83Vinculartrnwwds_12_dynamicfiltersselector3, "VINCULARTRNSOLIDICUTD") == 0 ) && ( AV84Vinculartrnwwds_13_dynamicfiltersoperator3 == 1 ) && ( ! (0==AV85Vinculartrnwwds_14_vinculartrnsolidicutd3) ) )
         {
            AddWhere(sWhereString, "(T1.[VincularTrnSolidicutd] = @AV85Vinculartrnwwds_14_vinculartrnsolidicutd3)");
         }
         else
         {
            GXv_int5[19] = 1;
         }
         if ( AV82Vinculartrnwwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV83Vinculartrnwwds_12_dynamicfiltersselector3, "VINCULARTRNSOLIDICUTD") == 0 ) && ( AV84Vinculartrnwwds_13_dynamicfiltersoperator3 == 2 ) && ( ! (0==AV85Vinculartrnwwds_14_vinculartrnsolidicutd3) ) )
         {
            AddWhere(sWhereString, "(T1.[VincularTrnSolidicutd] > @AV85Vinculartrnwwds_14_vinculartrnsolidicutd3)");
         }
         else
         {
            GXv_int5[20] = 1;
         }
         if ( AV82Vinculartrnwwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV83Vinculartrnwwds_12_dynamicfiltersselector3, "PROVEEDORNOMBRE") == 0 ) && ( AV84Vinculartrnwwds_13_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV86Vinculartrnwwds_15_proveedornombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ProveedorNombre]) like UPPER(@lV86Vinculartrnwwds_15_proveedornombre3))");
         }
         else
         {
            GXv_int5[21] = 1;
         }
         if ( AV82Vinculartrnwwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV83Vinculartrnwwds_12_dynamicfiltersselector3, "PROVEEDORNOMBRE") == 0 ) && ( AV84Vinculartrnwwds_13_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV86Vinculartrnwwds_15_proveedornombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ProveedorNombre]) like '%' + UPPER(@lV86Vinculartrnwwds_15_proveedornombre3))");
         }
         else
         {
            GXv_int5[22] = 1;
         }
         if ( ! (0==AV87Vinculartrnwwds_16_tfvinculartrnid) )
         {
            AddWhere(sWhereString, "(T1.[VincularTrnId] >= @AV87Vinculartrnwwds_16_tfvinculartrnid)");
         }
         else
         {
            GXv_int5[23] = 1;
         }
         if ( ! (0==AV88Vinculartrnwwds_17_tfvinculartrnid_to) )
         {
            AddWhere(sWhereString, "(T1.[VincularTrnId] <= @AV88Vinculartrnwwds_17_tfvinculartrnid_to)");
         }
         else
         {
            GXv_int5[24] = 1;
         }
         if ( ! (0==AV89Vinculartrnwwds_18_tfproveedorid) )
         {
            AddWhere(sWhereString, "(T1.[ProveedorID] >= @AV89Vinculartrnwwds_18_tfproveedorid)");
         }
         else
         {
            GXv_int5[25] = 1;
         }
         if ( ! (0==AV90Vinculartrnwwds_19_tfproveedorid_to) )
         {
            AddWhere(sWhereString, "(T1.[ProveedorID] <= @AV90Vinculartrnwwds_19_tfproveedorid_to)");
         }
         else
         {
            GXv_int5[26] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV92Vinculartrnwwds_21_tfproveedornombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV91Vinculartrnwwds_20_tfproveedornombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ProveedorNombre]) like UPPER(@lV91Vinculartrnwwds_20_tfproveedornombre))");
         }
         else
         {
            GXv_int5[27] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV92Vinculartrnwwds_21_tfproveedornombre_sel)) && ! ( StringUtil.StrCmp(AV92Vinculartrnwwds_21_tfproveedornombre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.[ProveedorNombre] = @AV92Vinculartrnwwds_21_tfproveedornombre_sel)");
         }
         else
         {
            GXv_int5[28] = 1;
         }
         if ( StringUtil.StrCmp(AV92Vinculartrnwwds_21_tfproveedornombre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T2.[ProveedorNombre] = ''))");
         }
         if ( ! (0==AV93Vinculartrnwwds_22_tfvinculartrnsolidicutd) )
         {
            AddWhere(sWhereString, "(T1.[VincularTrnSolidicutd] >= @AV93Vinculartrnwwds_22_tfvinculartrnsolidicutd)");
         }
         else
         {
            GXv_int5[29] = 1;
         }
         if ( ! (0==AV94Vinculartrnwwds_23_tfvinculartrnsolidicutd_to) )
         {
            AddWhere(sWhereString, "(T1.[VincularTrnSolidicutd] <= @AV94Vinculartrnwwds_23_tfvinculartrnsolidicutd_to)");
         }
         else
         {
            GXv_int5[30] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV96Vinculartrnwwds_25_tfvinculartrnnombresol_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV95Vinculartrnwwds_24_tfvinculartrnnombresol)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[VincularTrnNombreSol]) like UPPER(@lV95Vinculartrnwwds_24_tfvinculartrnnombresol))");
         }
         else
         {
            GXv_int5[31] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV96Vinculartrnwwds_25_tfvinculartrnnombresol_sel)) && ! ( StringUtil.StrCmp(AV96Vinculartrnwwds_25_tfvinculartrnnombresol_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[VincularTrnNombreSol] = @AV96Vinculartrnwwds_25_tfvinculartrnnombresol_sel)");
         }
         else
         {
            GXv_int5[32] = 1;
         }
         if ( StringUtil.StrCmp(AV96Vinculartrnwwds_25_tfvinculartrnnombresol_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[VincularTrnNombreSol] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV98Vinculartrnwwds_27_tfvinculartrntelefonosol_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV97Vinculartrnwwds_26_tfvinculartrntelefonosol)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[VincularTrnTelefonoSol]) like UPPER(@lV97Vinculartrnwwds_26_tfvinculartrntelefonosol))");
         }
         else
         {
            GXv_int5[33] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV98Vinculartrnwwds_27_tfvinculartrntelefonosol_sel)) && ! ( StringUtil.StrCmp(AV98Vinculartrnwwds_27_tfvinculartrntelefonosol_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[VincularTrnTelefonoSol] = @AV98Vinculartrnwwds_27_tfvinculartrntelefonosol_sel)");
         }
         else
         {
            GXv_int5[34] = 1;
         }
         if ( StringUtil.StrCmp(AV98Vinculartrnwwds_27_tfvinculartrntelefonosol_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[VincularTrnTelefonoSol] = ''))");
         }
         if ( ! (0==AV99Vinculartrnwwds_28_tfdocumentacionid) )
         {
            AddWhere(sWhereString, "(T2.[DocumentacionId] >= @AV99Vinculartrnwwds_28_tfdocumentacionid)");
         }
         else
         {
            GXv_int5[35] = 1;
         }
         if ( ! (0==AV100Vinculartrnwwds_29_tfdocumentacionid_to) )
         {
            AddWhere(sWhereString, "(T2.[DocumentacionId] <= @AV100Vinculartrnwwds_29_tfdocumentacionid_to)");
         }
         else
         {
            GXv_int5[36] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV102Vinculartrnwwds_31_tfvinculartrncomentario_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV101Vinculartrnwwds_30_tfvinculartrncomentario)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[VincularTrnComentario]) like UPPER(@lV101Vinculartrnwwds_30_tfvinculartrncomentario))");
         }
         else
         {
            GXv_int5[37] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV102Vinculartrnwwds_31_tfvinculartrncomentario_sel)) && ! ( StringUtil.StrCmp(AV102Vinculartrnwwds_31_tfvinculartrncomentario_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[VincularTrnComentario] = @AV102Vinculartrnwwds_31_tfvinculartrncomentario_sel)");
         }
         else
         {
            GXv_int5[38] = 1;
         }
         if ( StringUtil.StrCmp(AV102Vinculartrnwwds_31_tfvinculartrncomentario_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((DATALENGTH(T1.[VincularTrnComentario])=0))");
         }
         if ( ! (DateTime.MinValue==AV103Vinculartrnwwds_32_tfvinculartrnfecha) )
         {
            AddWhere(sWhereString, "(T1.[VincularTrnFecha] >= @AV103Vinculartrnwwds_32_tfvinculartrnfecha)");
         }
         else
         {
            GXv_int5[39] = 1;
         }
         if ( ! (DateTime.MinValue==AV104Vinculartrnwwds_33_tfvinculartrnfecha_to) )
         {
            AddWhere(sWhereString, "(T1.[VincularTrnFecha] <= @AV104Vinculartrnwwds_33_tfvinculartrnfecha_to)");
         }
         else
         {
            GXv_int5[40] = 1;
         }
         scmdbuf += sWhereString;
         if ( ( AV17OrderedBy == 1 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[VincularTrnSolidicutd]";
         }
         else if ( ( AV17OrderedBy == 1 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[VincularTrnSolidicutd] DESC";
         }
         else if ( ( AV17OrderedBy == 2 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[VincularTrnId]";
         }
         else if ( ( AV17OrderedBy == 2 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[VincularTrnId] DESC";
         }
         else if ( ( AV17OrderedBy == 3 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[ProveedorID]";
         }
         else if ( ( AV17OrderedBy == 3 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[ProveedorID] DESC";
         }
         else if ( ( AV17OrderedBy == 4 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T2.[ProveedorNombre]";
         }
         else if ( ( AV17OrderedBy == 4 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T2.[ProveedorNombre] DESC";
         }
         else if ( ( AV17OrderedBy == 5 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[VincularTrnNombreSol]";
         }
         else if ( ( AV17OrderedBy == 5 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[VincularTrnNombreSol] DESC";
         }
         else if ( ( AV17OrderedBy == 6 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[VincularTrnTelefonoSol]";
         }
         else if ( ( AV17OrderedBy == 6 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[VincularTrnTelefonoSol] DESC";
         }
         else if ( ( AV17OrderedBy == 7 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T2.[DocumentacionId]";
         }
         else if ( ( AV17OrderedBy == 7 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T2.[DocumentacionId] DESC";
         }
         else if ( ( AV17OrderedBy == 8 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[VincularTrnComentario]";
         }
         else if ( ( AV17OrderedBy == 8 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[VincularTrnComentario] DESC";
         }
         else if ( ( AV17OrderedBy == 9 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[VincularTrnFecha]";
         }
         else if ( ( AV17OrderedBy == 9 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[VincularTrnFecha] DESC";
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
                     return conditional_P006C2(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (short)dynConstraints[2] , (long)dynConstraints[3] , (string)dynConstraints[4] , (bool)dynConstraints[5] , (string)dynConstraints[6] , (short)dynConstraints[7] , (long)dynConstraints[8] , (string)dynConstraints[9] , (bool)dynConstraints[10] , (string)dynConstraints[11] , (short)dynConstraints[12] , (long)dynConstraints[13] , (string)dynConstraints[14] , (long)dynConstraints[15] , (long)dynConstraints[16] , (long)dynConstraints[17] , (long)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (long)dynConstraints[21] , (long)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (string)dynConstraints[25] , (string)dynConstraints[26] , (long)dynConstraints[27] , (long)dynConstraints[28] , (string)dynConstraints[29] , (string)dynConstraints[30] , (DateTime)dynConstraints[31] , (DateTime)dynConstraints[32] , (long)dynConstraints[33] , (long)dynConstraints[34] , (string)dynConstraints[35] , (long)dynConstraints[36] , (string)dynConstraints[37] , (string)dynConstraints[38] , (long)dynConstraints[39] , (string)dynConstraints[40] , (DateTime)dynConstraints[41] , (short)dynConstraints[42] , (bool)dynConstraints[43] );
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
          Object[] prmP006C2;
          prmP006C2 = new Object[] {
          new ParDef("@lV72Vinculartrnwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV72Vinculartrnwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV72Vinculartrnwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV72Vinculartrnwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV72Vinculartrnwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV72Vinculartrnwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV72Vinculartrnwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV72Vinculartrnwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@AV75Vinculartrnwwds_4_vinculartrnsolidicutd1",GXType.Decimal,18,0) ,
          new ParDef("@AV75Vinculartrnwwds_4_vinculartrnsolidicutd1",GXType.Decimal,18,0) ,
          new ParDef("@AV75Vinculartrnwwds_4_vinculartrnsolidicutd1",GXType.Decimal,18,0) ,
          new ParDef("@lV76Vinculartrnwwds_5_proveedornombre1",GXType.Char,80,0) ,
          new ParDef("@lV76Vinculartrnwwds_5_proveedornombre1",GXType.Char,80,0) ,
          new ParDef("@AV80Vinculartrnwwds_9_vinculartrnsolidicutd2",GXType.Decimal,18,0) ,
          new ParDef("@AV80Vinculartrnwwds_9_vinculartrnsolidicutd2",GXType.Decimal,18,0) ,
          new ParDef("@AV80Vinculartrnwwds_9_vinculartrnsolidicutd2",GXType.Decimal,18,0) ,
          new ParDef("@lV81Vinculartrnwwds_10_proveedornombre2",GXType.Char,80,0) ,
          new ParDef("@lV81Vinculartrnwwds_10_proveedornombre2",GXType.Char,80,0) ,
          new ParDef("@AV85Vinculartrnwwds_14_vinculartrnsolidicutd3",GXType.Decimal,18,0) ,
          new ParDef("@AV85Vinculartrnwwds_14_vinculartrnsolidicutd3",GXType.Decimal,18,0) ,
          new ParDef("@AV85Vinculartrnwwds_14_vinculartrnsolidicutd3",GXType.Decimal,18,0) ,
          new ParDef("@lV86Vinculartrnwwds_15_proveedornombre3",GXType.Char,80,0) ,
          new ParDef("@lV86Vinculartrnwwds_15_proveedornombre3",GXType.Char,80,0) ,
          new ParDef("@AV87Vinculartrnwwds_16_tfvinculartrnid",GXType.Decimal,18,0) ,
          new ParDef("@AV88Vinculartrnwwds_17_tfvinculartrnid_to",GXType.Decimal,18,0) ,
          new ParDef("@AV89Vinculartrnwwds_18_tfproveedorid",GXType.Decimal,18,0) ,
          new ParDef("@AV90Vinculartrnwwds_19_tfproveedorid_to",GXType.Decimal,18,0) ,
          new ParDef("@lV91Vinculartrnwwds_20_tfproveedornombre",GXType.Char,80,0) ,
          new ParDef("@AV92Vinculartrnwwds_21_tfproveedornombre_sel",GXType.NChar,80,0) ,
          new ParDef("@AV93Vinculartrnwwds_22_tfvinculartrnsolidicutd",GXType.Decimal,18,0) ,
          new ParDef("@AV94Vinculartrnwwds_23_tfvinculartrnsolidicutd_to",GXType.Decimal,18,0) ,
          new ParDef("@lV95Vinculartrnwwds_24_tfvinculartrnnombresol",GXType.Char,80,0) ,
          new ParDef("@AV96Vinculartrnwwds_25_tfvinculartrnnombresol_sel",GXType.NChar,80,0) ,
          new ParDef("@lV97Vinculartrnwwds_26_tfvinculartrntelefonosol",GXType.Char,20,0) ,
          new ParDef("@AV98Vinculartrnwwds_27_tfvinculartrntelefonosol_sel",GXType.NChar,20,0) ,
          new ParDef("@AV99Vinculartrnwwds_28_tfdocumentacionid",GXType.Decimal,18,0) ,
          new ParDef("@AV100Vinculartrnwwds_29_tfdocumentacionid_to",GXType.Decimal,18,0) ,
          new ParDef("@lV101Vinculartrnwwds_30_tfvinculartrncomentario",GXType.VarChar,200,0) ,
          new ParDef("@AV102Vinculartrnwwds_31_tfvinculartrncomentario_sel",GXType.NVarChar,200,0) ,
          new ParDef("@AV103Vinculartrnwwds_32_tfvinculartrnfecha",GXType.Date,8,0) ,
          new ParDef("@AV104Vinculartrnwwds_33_tfvinculartrnfecha_to",GXType.Date,8,0)
          };
          def= new CursorDef[] {
              new CursorDef("P006C2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP006C2,100, GxCacheFrequency.OFF ,true,false )
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
                ((DateTime[]) buf[0])[0] = rslt.getGXDate(1);
                ((string[]) buf[1])[0] = rslt.getLongVarchar(2);
                ((long[]) buf[2])[0] = rslt.getLong(3);
                ((bool[]) buf[3])[0] = rslt.wasNull(3);
                ((string[]) buf[4])[0] = rslt.getString(4, 20);
                ((string[]) buf[5])[0] = rslt.getString(5, 80);
                ((string[]) buf[6])[0] = rslt.getString(6, 80);
                ((long[]) buf[7])[0] = rslt.getLong(7);
                ((long[]) buf[8])[0] = rslt.getLong(8);
                ((long[]) buf[9])[0] = rslt.getLong(9);
                return;
       }
    }

 }

}

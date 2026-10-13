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
   public class mapeowwexport : GXProcedure
   {
      public mapeowwexport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public mapeowwexport( IGxContext context )
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
         new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWMapeo", out  GXt_boolean1) ;
         AV8IsAuthorized = GXt_boolean1;
         if ( ! AV8IsAuthorized )
         {
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "wwpbaseobjects.notauthorized.aspx"+GXUtil.UrlEncode(StringUtil.RTrim(AV77Pgmname));
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
         AV12Filename = GXt_char2 + "MapeoWWExport-" + StringUtil.Trim( StringUtil.Str( (decimal)(AV16Random), 8, 0)) + ".xlsx";
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
         if ( AV22GridState.gxTpr_Dynamicfilters.Count >= 1 )
         {
            AV76GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV22GridState.gxTpr_Dynamicfilters.Item(1));
            AV59DynamicFiltersSelector1 = AV76GridStateDynamicFilter.gxTpr_Selected;
            if ( StringUtil.StrCmp(AV59DynamicFiltersSelector1, "STCOMERCIOSNOMBRE") == 0 )
            {
               AV60DynamicFiltersOperator1 = AV76GridStateDynamicFilter.gxTpr_Operator;
               AV61STComerciosNombre1 = AV76GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61STComerciosNombre1)) )
               {
                  AV14CellRow = (int)(AV14CellRow+1);
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Bold = 1;
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Color = 3;
                  if ( AV60DynamicFiltersOperator1 == 0 )
                  {
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", context.GetMessage( "Nombre", ""), context.GetMessage( "WWP_FilterLike", ""), "", "", "", "", "", "", "");
                  }
                  else if ( AV60DynamicFiltersOperator1 == 1 )
                  {
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", context.GetMessage( "Nombre", ""), context.GetMessage( "WWP_FilterContains", ""), "", "", "", "", "", "", "");
                  }
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Italic = 1;
                  GXt_char2 = "";
                  new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV61STComerciosNombre1, out  GXt_char2) ;
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
               }
            }
            else if ( StringUtil.StrCmp(AV59DynamicFiltersSelector1, "PROVEEDORNOMBRE") == 0 )
            {
               AV60DynamicFiltersOperator1 = AV76GridStateDynamicFilter.gxTpr_Operator;
               AV62ProveedorNombre1 = AV76GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62ProveedorNombre1)) )
               {
                  AV14CellRow = (int)(AV14CellRow+1);
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Bold = 1;
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Color = 3;
                  if ( AV60DynamicFiltersOperator1 == 0 )
                  {
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", context.GetMessage( "Proveedor Nombre", ""), context.GetMessage( "WWP_FilterLike", ""), "", "", "", "", "", "", "");
                  }
                  else if ( AV60DynamicFiltersOperator1 == 1 )
                  {
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", context.GetMessage( "Proveedor Nombre", ""), context.GetMessage( "WWP_FilterContains", ""), "", "", "", "", "", "", "");
                  }
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Italic = 1;
                  GXt_char2 = "";
                  new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV62ProveedorNombre1, out  GXt_char2) ;
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
               }
            }
            else if ( StringUtil.StrCmp(AV59DynamicFiltersSelector1, "CONEXIONESNOMBRE") == 0 )
            {
               AV60DynamicFiltersOperator1 = AV76GridStateDynamicFilter.gxTpr_Operator;
               AV63ConexionesNombre1 = AV76GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63ConexionesNombre1)) )
               {
                  AV14CellRow = (int)(AV14CellRow+1);
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Bold = 1;
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Color = 3;
                  if ( AV60DynamicFiltersOperator1 == 0 )
                  {
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", context.GetMessage( "Conexiones Nombre", ""), context.GetMessage( "WWP_FilterLike", ""), "", "", "", "", "", "", "");
                  }
                  else if ( AV60DynamicFiltersOperator1 == 1 )
                  {
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", context.GetMessage( "Conexiones Nombre", ""), context.GetMessage( "WWP_FilterContains", ""), "", "", "", "", "", "", "");
                  }
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Italic = 1;
                  GXt_char2 = "";
                  new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV63ConexionesNombre1, out  GXt_char2) ;
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
               }
            }
            if ( AV22GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV64DynamicFiltersEnabled2 = true;
               AV76GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV22GridState.gxTpr_Dynamicfilters.Item(2));
               AV65DynamicFiltersSelector2 = AV76GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV65DynamicFiltersSelector2, "STCOMERCIOSNOMBRE") == 0 )
               {
                  AV66DynamicFiltersOperator2 = AV76GridStateDynamicFilter.gxTpr_Operator;
                  AV67STComerciosNombre2 = AV76GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67STComerciosNombre2)) )
                  {
                     AV14CellRow = (int)(AV14CellRow+1);
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Bold = 1;
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Color = 3;
                     if ( AV66DynamicFiltersOperator2 == 0 )
                     {
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", context.GetMessage( "Nombre", ""), context.GetMessage( "WWP_FilterLike", ""), "", "", "", "", "", "", "");
                     }
                     else if ( AV66DynamicFiltersOperator2 == 1 )
                     {
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", context.GetMessage( "Nombre", ""), context.GetMessage( "WWP_FilterContains", ""), "", "", "", "", "", "", "");
                     }
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Italic = 1;
                     GXt_char2 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV67STComerciosNombre2, out  GXt_char2) ;
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
                  }
               }
               else if ( StringUtil.StrCmp(AV65DynamicFiltersSelector2, "PROVEEDORNOMBRE") == 0 )
               {
                  AV66DynamicFiltersOperator2 = AV76GridStateDynamicFilter.gxTpr_Operator;
                  AV68ProveedorNombre2 = AV76GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68ProveedorNombre2)) )
                  {
                     AV14CellRow = (int)(AV14CellRow+1);
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Bold = 1;
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Color = 3;
                     if ( AV66DynamicFiltersOperator2 == 0 )
                     {
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", context.GetMessage( "Proveedor Nombre", ""), context.GetMessage( "WWP_FilterLike", ""), "", "", "", "", "", "", "");
                     }
                     else if ( AV66DynamicFiltersOperator2 == 1 )
                     {
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", context.GetMessage( "Proveedor Nombre", ""), context.GetMessage( "WWP_FilterContains", ""), "", "", "", "", "", "", "");
                     }
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Italic = 1;
                     GXt_char2 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV68ProveedorNombre2, out  GXt_char2) ;
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
                  }
               }
               else if ( StringUtil.StrCmp(AV65DynamicFiltersSelector2, "CONEXIONESNOMBRE") == 0 )
               {
                  AV66DynamicFiltersOperator2 = AV76GridStateDynamicFilter.gxTpr_Operator;
                  AV69ConexionesNombre2 = AV76GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69ConexionesNombre2)) )
                  {
                     AV14CellRow = (int)(AV14CellRow+1);
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Bold = 1;
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Color = 3;
                     if ( AV66DynamicFiltersOperator2 == 0 )
                     {
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", context.GetMessage( "Conexiones Nombre", ""), context.GetMessage( "WWP_FilterLike", ""), "", "", "", "", "", "", "");
                     }
                     else if ( AV66DynamicFiltersOperator2 == 1 )
                     {
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", context.GetMessage( "Conexiones Nombre", ""), context.GetMessage( "WWP_FilterContains", ""), "", "", "", "", "", "", "");
                     }
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Italic = 1;
                     GXt_char2 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV69ConexionesNombre2, out  GXt_char2) ;
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
                  }
               }
               if ( AV22GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV70DynamicFiltersEnabled3 = true;
                  AV76GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV22GridState.gxTpr_Dynamicfilters.Item(3));
                  AV71DynamicFiltersSelector3 = AV76GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV71DynamicFiltersSelector3, "STCOMERCIOSNOMBRE") == 0 )
                  {
                     AV72DynamicFiltersOperator3 = AV76GridStateDynamicFilter.gxTpr_Operator;
                     AV73STComerciosNombre3 = AV76GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73STComerciosNombre3)) )
                     {
                        AV14CellRow = (int)(AV14CellRow+1);
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Bold = 1;
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Color = 3;
                        if ( AV72DynamicFiltersOperator3 == 0 )
                        {
                           AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", context.GetMessage( "Nombre", ""), context.GetMessage( "WWP_FilterLike", ""), "", "", "", "", "", "", "");
                        }
                        else if ( AV72DynamicFiltersOperator3 == 1 )
                        {
                           AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", context.GetMessage( "Nombre", ""), context.GetMessage( "WWP_FilterContains", ""), "", "", "", "", "", "", "");
                        }
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Italic = 1;
                        GXt_char2 = "";
                        new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV73STComerciosNombre3, out  GXt_char2) ;
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
                     }
                  }
                  else if ( StringUtil.StrCmp(AV71DynamicFiltersSelector3, "PROVEEDORNOMBRE") == 0 )
                  {
                     AV72DynamicFiltersOperator3 = AV76GridStateDynamicFilter.gxTpr_Operator;
                     AV74ProveedorNombre3 = AV76GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74ProveedorNombre3)) )
                     {
                        AV14CellRow = (int)(AV14CellRow+1);
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Bold = 1;
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Color = 3;
                        if ( AV72DynamicFiltersOperator3 == 0 )
                        {
                           AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", context.GetMessage( "Proveedor Nombre", ""), context.GetMessage( "WWP_FilterLike", ""), "", "", "", "", "", "", "");
                        }
                        else if ( AV72DynamicFiltersOperator3 == 1 )
                        {
                           AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", context.GetMessage( "Proveedor Nombre", ""), context.GetMessage( "WWP_FilterContains", ""), "", "", "", "", "", "", "");
                        }
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Italic = 1;
                        GXt_char2 = "";
                        new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV74ProveedorNombre3, out  GXt_char2) ;
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
                     }
                  }
                  else if ( StringUtil.StrCmp(AV71DynamicFiltersSelector3, "CONEXIONESNOMBRE") == 0 )
                  {
                     AV72DynamicFiltersOperator3 = AV76GridStateDynamicFilter.gxTpr_Operator;
                     AV75ConexionesNombre3 = AV76GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75ConexionesNombre3)) )
                     {
                        AV14CellRow = (int)(AV14CellRow+1);
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Bold = 1;
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Color = 3;
                        if ( AV72DynamicFiltersOperator3 == 0 )
                        {
                           AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", context.GetMessage( "Conexiones Nombre", ""), context.GetMessage( "WWP_FilterLike", ""), "", "", "", "", "", "", "");
                        }
                        else if ( AV72DynamicFiltersOperator3 == 1 )
                        {
                           AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", context.GetMessage( "Conexiones Nombre", ""), context.GetMessage( "WWP_FilterContains", ""), "", "", "", "", "", "", "");
                        }
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Italic = 1;
                        GXt_char2 = "";
                        new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV75ConexionesNombre3, out  GXt_char2) ;
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
                     }
                  }
               }
            }
         }
         if ( ! ( (0==AV35TFMapeoID) && (0==AV36TFMapeoID_To) ) )
         {
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Mapeo ID", "")) ;
            AV14CellRow = GXt_int3;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Number = AV35TFMapeoID;
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  false, ref  GXt_int3,  (short)(AV15FirstColumn+2),  context.GetMessage( "WWP_TSTo", "")) ;
            AV14CellRow = GXt_int3;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+3, 1, 1).Number = AV36TFMapeoID_To;
         }
         if ( ! ( (0==AV37TFProveedorID) && (0==AV38TFProveedorID_To) ) )
         {
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Código del Proveedor", "")) ;
            AV14CellRow = GXt_int3;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Number = AV37TFProveedorID;
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  false, ref  GXt_int3,  (short)(AV15FirstColumn+2),  context.GetMessage( "WWP_TSTo", "")) ;
            AV14CellRow = GXt_int3;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+3, 1, 1).Number = AV38TFProveedorID_To;
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV40TFProveedorNombre_Sel)) ) )
         {
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Nombre", "")) ;
            AV14CellRow = GXt_int3;
            GXt_char2 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV40TFProveedorNombre_Sel)) ? context.GetMessage( "WWP_TitleFilter_EmptyOption", "") : AV40TFProveedorNombre_Sel), out  GXt_char2) ;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV39TFProveedorNombre)) ) )
            {
               GXt_int3 = (short)(AV14CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Nombre", "")) ;
               AV14CellRow = GXt_int3;
               GXt_char2 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV39TFProveedorNombre, out  GXt_char2) ;
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
            }
         }
         if ( ! ( ( AV43TFProveedorEstado_Sels.Count == 0 ) ) )
         {
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Estado", "")) ;
            AV14CellRow = GXt_int3;
            AV58i = 1;
            AV78GXV1 = 1;
            while ( AV78GXV1 <= AV43TFProveedorEstado_Sels.Count )
            {
               AV42TFProveedorEstado_Sel = AV43TFProveedorEstado_Sels.GetString(AV78GXV1);
               if ( AV58i == 1 )
               {
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = "";
               }
               else
               {
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text+", ";
               }
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text+context.GetMessage( gxdomainestadoenum.getDescription(context,AV42TFProveedorEstado_Sel), "");
               AV58i = (long)(AV58i+1);
               AV78GXV1 = (int)(AV78GXV1+1);
            }
         }
         if ( ! ( (0==AV44TFSTComerciosID) && (0==AV45TFSTComerciosID_To) ) )
         {
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Comercio", "")) ;
            AV14CellRow = GXt_int3;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Number = AV44TFSTComerciosID;
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  false, ref  GXt_int3,  (short)(AV15FirstColumn+2),  context.GetMessage( "WWP_TSTo", "")) ;
            AV14CellRow = GXt_int3;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+3, 1, 1).Number = AV45TFSTComerciosID_To;
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV47TFSTComerciosNombre_Sel)) ) )
         {
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Nombre", "")) ;
            AV14CellRow = GXt_int3;
            GXt_char2 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV47TFSTComerciosNombre_Sel)) ? context.GetMessage( "WWP_TitleFilter_EmptyOption", "") : AV47TFSTComerciosNombre_Sel), out  GXt_char2) ;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV46TFSTComerciosNombre)) ) )
            {
               GXt_int3 = (short)(AV14CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Nombre", "")) ;
               AV14CellRow = GXt_int3;
               GXt_char2 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV46TFSTComerciosNombre, out  GXt_char2) ;
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV52TFConexionesID_Sel)) ) )
         {
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Código de Conexión", "")) ;
            AV14CellRow = GXt_int3;
            GXt_char2 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV52TFConexionesID_Sel)) ? context.GetMessage( "WWP_TitleFilter_EmptyOption", "") : AV52TFConexionesID_Sel), out  GXt_char2) ;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV51TFConexionesID)) ) )
            {
               GXt_int3 = (short)(AV14CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Código de Conexión", "")) ;
               AV14CellRow = GXt_int3;
               GXt_char2 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV51TFConexionesID, out  GXt_char2) ;
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV54TFConexionesNombre_Sel)) ) )
         {
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Nombre", "")) ;
            AV14CellRow = GXt_int3;
            GXt_char2 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV54TFConexionesNombre_Sel)) ? context.GetMessage( "WWP_TitleFilter_EmptyOption", "") : AV54TFConexionesNombre_Sel), out  GXt_char2) ;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV53TFConexionesNombre)) ) )
            {
               GXt_int3 = (short)(AV14CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Nombre", "")) ;
               AV14CellRow = GXt_int3;
               GXt_char2 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV53TFConexionesNombre, out  GXt_char2) ;
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
            }
         }
         AV14CellRow = (int)(AV14CellRow+2);
      }

      protected void S141( )
      {
         /* 'WRITECOLUMNTITLES' Routine */
         returnInSub = false;
         AV32VisibleColumnCount = 0;
         if ( StringUtil.StrCmp(AV20Session.Get("MapeoWWColumnsSelector"), "") != 0 )
         {
            AV27ColumnsSelectorXML = AV20Session.Get("MapeoWWColumnsSelector");
            AV24ColumnsSelector.FromXml(AV27ColumnsSelectorXML, null, "", "");
         }
         else
         {
            /* Execute user subroutine: 'INITIALIZECOLUMNSSELECTOR' */
            S151 ();
            if (returnInSub) return;
         }
         AV24ColumnsSelector.gxTpr_Columns.Sort("Order");
         AV79GXV2 = 1;
         while ( AV79GXV2 <= AV24ColumnsSelector.gxTpr_Columns.Count )
         {
            AV26ColumnsSelector_Column = ((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV24ColumnsSelector.gxTpr_Columns.Item(AV79GXV2));
            if ( AV26ColumnsSelector_Column.gxTpr_Isvisible )
            {
               AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV32VisibleColumnCount), 1, 1).Text = context.GetMessage( (String.IsNullOrEmpty(StringUtil.RTrim( AV26ColumnsSelector_Column.gxTpr_Displayname)) ? AV26ColumnsSelector_Column.gxTpr_Columnname : AV26ColumnsSelector_Column.gxTpr_Displayname), "");
               AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV32VisibleColumnCount), 1, 1).Bold = 1;
               AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV32VisibleColumnCount), 1, 1).Color = 11;
               AV32VisibleColumnCount = (long)(AV32VisibleColumnCount+1);
            }
            AV79GXV2 = (int)(AV79GXV2+1);
         }
      }

      protected void S161( )
      {
         /* 'WRITEDATA' Routine */
         returnInSub = false;
         AV81Mapeowwds_1_filterfulltext = AV19FilterFullText;
         AV82Mapeowwds_2_dynamicfiltersselector1 = AV59DynamicFiltersSelector1;
         AV83Mapeowwds_3_dynamicfiltersoperator1 = AV60DynamicFiltersOperator1;
         AV84Mapeowwds_4_stcomerciosnombre1 = AV61STComerciosNombre1;
         AV85Mapeowwds_5_proveedornombre1 = AV62ProveedorNombre1;
         AV86Mapeowwds_6_conexionesnombre1 = AV63ConexionesNombre1;
         AV87Mapeowwds_7_dynamicfiltersenabled2 = AV64DynamicFiltersEnabled2;
         AV88Mapeowwds_8_dynamicfiltersselector2 = AV65DynamicFiltersSelector2;
         AV89Mapeowwds_9_dynamicfiltersoperator2 = AV66DynamicFiltersOperator2;
         AV90Mapeowwds_10_stcomerciosnombre2 = AV67STComerciosNombre2;
         AV91Mapeowwds_11_proveedornombre2 = AV68ProveedorNombre2;
         AV92Mapeowwds_12_conexionesnombre2 = AV69ConexionesNombre2;
         AV93Mapeowwds_13_dynamicfiltersenabled3 = AV70DynamicFiltersEnabled3;
         AV94Mapeowwds_14_dynamicfiltersselector3 = AV71DynamicFiltersSelector3;
         AV95Mapeowwds_15_dynamicfiltersoperator3 = AV72DynamicFiltersOperator3;
         AV96Mapeowwds_16_stcomerciosnombre3 = AV73STComerciosNombre3;
         AV97Mapeowwds_17_proveedornombre3 = AV74ProveedorNombre3;
         AV98Mapeowwds_18_conexionesnombre3 = AV75ConexionesNombre3;
         AV99Mapeowwds_19_tfmapeoid = AV35TFMapeoID;
         AV100Mapeowwds_20_tfmapeoid_to = AV36TFMapeoID_To;
         AV101Mapeowwds_21_tfproveedorid = AV37TFProveedorID;
         AV102Mapeowwds_22_tfproveedorid_to = AV38TFProveedorID_To;
         AV103Mapeowwds_23_tfproveedornombre = AV39TFProveedorNombre;
         AV104Mapeowwds_24_tfproveedornombre_sel = AV40TFProveedorNombre_Sel;
         AV105Mapeowwds_25_tfproveedorestado_sels = AV43TFProveedorEstado_Sels;
         AV106Mapeowwds_26_tfstcomerciosid = AV44TFSTComerciosID;
         AV107Mapeowwds_27_tfstcomerciosid_to = AV45TFSTComerciosID_To;
         AV108Mapeowwds_28_tfstcomerciosnombre = AV46TFSTComerciosNombre;
         AV109Mapeowwds_29_tfstcomerciosnombre_sel = AV47TFSTComerciosNombre_Sel;
         AV110Mapeowwds_30_tfconexionesid = AV51TFConexionesID;
         AV111Mapeowwds_31_tfconexionesid_sel = AV52TFConexionesID_Sel;
         AV112Mapeowwds_32_tfconexionesnombre = AV53TFConexionesNombre;
         AV113Mapeowwds_33_tfconexionesnombre_sel = AV54TFConexionesNombre_Sel;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A344ProveedorEstado ,
                                              AV105Mapeowwds_25_tfproveedorestado_sels ,
                                              AV82Mapeowwds_2_dynamicfiltersselector1 ,
                                              AV83Mapeowwds_3_dynamicfiltersoperator1 ,
                                              AV84Mapeowwds_4_stcomerciosnombre1 ,
                                              AV85Mapeowwds_5_proveedornombre1 ,
                                              AV86Mapeowwds_6_conexionesnombre1 ,
                                              AV87Mapeowwds_7_dynamicfiltersenabled2 ,
                                              AV88Mapeowwds_8_dynamicfiltersselector2 ,
                                              AV89Mapeowwds_9_dynamicfiltersoperator2 ,
                                              AV90Mapeowwds_10_stcomerciosnombre2 ,
                                              AV91Mapeowwds_11_proveedornombre2 ,
                                              AV92Mapeowwds_12_conexionesnombre2 ,
                                              AV93Mapeowwds_13_dynamicfiltersenabled3 ,
                                              AV94Mapeowwds_14_dynamicfiltersselector3 ,
                                              AV95Mapeowwds_15_dynamicfiltersoperator3 ,
                                              AV96Mapeowwds_16_stcomerciosnombre3 ,
                                              AV97Mapeowwds_17_proveedornombre3 ,
                                              AV98Mapeowwds_18_conexionesnombre3 ,
                                              AV99Mapeowwds_19_tfmapeoid ,
                                              AV100Mapeowwds_20_tfmapeoid_to ,
                                              AV101Mapeowwds_21_tfproveedorid ,
                                              AV102Mapeowwds_22_tfproveedorid_to ,
                                              AV104Mapeowwds_24_tfproveedornombre_sel ,
                                              AV103Mapeowwds_23_tfproveedornombre ,
                                              AV105Mapeowwds_25_tfproveedorestado_sels.Count ,
                                              AV106Mapeowwds_26_tfstcomerciosid ,
                                              AV107Mapeowwds_27_tfstcomerciosid_to ,
                                              AV109Mapeowwds_29_tfstcomerciosnombre_sel ,
                                              AV108Mapeowwds_28_tfstcomerciosnombre ,
                                              AV111Mapeowwds_31_tfconexionesid_sel ,
                                              AV110Mapeowwds_30_tfconexionesid ,
                                              AV113Mapeowwds_33_tfconexionesnombre_sel ,
                                              AV112Mapeowwds_32_tfconexionesnombre ,
                                              A923STComerciosNombre ,
                                              A282ProveedorNombre ,
                                              A556ConexionesNombre ,
                                              A918MapeoID ,
                                              A133ProveedorID ,
                                              A919STComerciosID ,
                                              A552ConexionesID ,
                                              AV17OrderedBy ,
                                              AV18OrderedDsc ,
                                              AV81Mapeowwds_1_filterfulltext } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.INT,
                                              TypeConstants.LONG, TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV84Mapeowwds_4_stcomerciosnombre1 = StringUtil.PadR( StringUtil.RTrim( AV84Mapeowwds_4_stcomerciosnombre1), 80, "%");
         lV84Mapeowwds_4_stcomerciosnombre1 = StringUtil.PadR( StringUtil.RTrim( AV84Mapeowwds_4_stcomerciosnombre1), 80, "%");
         lV85Mapeowwds_5_proveedornombre1 = StringUtil.PadR( StringUtil.RTrim( AV85Mapeowwds_5_proveedornombre1), 80, "%");
         lV85Mapeowwds_5_proveedornombre1 = StringUtil.PadR( StringUtil.RTrim( AV85Mapeowwds_5_proveedornombre1), 80, "%");
         lV86Mapeowwds_6_conexionesnombre1 = StringUtil.PadR( StringUtil.RTrim( AV86Mapeowwds_6_conexionesnombre1), 80, "%");
         lV86Mapeowwds_6_conexionesnombre1 = StringUtil.PadR( StringUtil.RTrim( AV86Mapeowwds_6_conexionesnombre1), 80, "%");
         lV90Mapeowwds_10_stcomerciosnombre2 = StringUtil.PadR( StringUtil.RTrim( AV90Mapeowwds_10_stcomerciosnombre2), 80, "%");
         lV90Mapeowwds_10_stcomerciosnombre2 = StringUtil.PadR( StringUtil.RTrim( AV90Mapeowwds_10_stcomerciosnombre2), 80, "%");
         lV91Mapeowwds_11_proveedornombre2 = StringUtil.PadR( StringUtil.RTrim( AV91Mapeowwds_11_proveedornombre2), 80, "%");
         lV91Mapeowwds_11_proveedornombre2 = StringUtil.PadR( StringUtil.RTrim( AV91Mapeowwds_11_proveedornombre2), 80, "%");
         lV92Mapeowwds_12_conexionesnombre2 = StringUtil.PadR( StringUtil.RTrim( AV92Mapeowwds_12_conexionesnombre2), 80, "%");
         lV92Mapeowwds_12_conexionesnombre2 = StringUtil.PadR( StringUtil.RTrim( AV92Mapeowwds_12_conexionesnombre2), 80, "%");
         lV96Mapeowwds_16_stcomerciosnombre3 = StringUtil.PadR( StringUtil.RTrim( AV96Mapeowwds_16_stcomerciosnombre3), 80, "%");
         lV96Mapeowwds_16_stcomerciosnombre3 = StringUtil.PadR( StringUtil.RTrim( AV96Mapeowwds_16_stcomerciosnombre3), 80, "%");
         lV97Mapeowwds_17_proveedornombre3 = StringUtil.PadR( StringUtil.RTrim( AV97Mapeowwds_17_proveedornombre3), 80, "%");
         lV97Mapeowwds_17_proveedornombre3 = StringUtil.PadR( StringUtil.RTrim( AV97Mapeowwds_17_proveedornombre3), 80, "%");
         lV98Mapeowwds_18_conexionesnombre3 = StringUtil.PadR( StringUtil.RTrim( AV98Mapeowwds_18_conexionesnombre3), 80, "%");
         lV98Mapeowwds_18_conexionesnombre3 = StringUtil.PadR( StringUtil.RTrim( AV98Mapeowwds_18_conexionesnombre3), 80, "%");
         lV103Mapeowwds_23_tfproveedornombre = StringUtil.PadR( StringUtil.RTrim( AV103Mapeowwds_23_tfproveedornombre), 80, "%");
         lV108Mapeowwds_28_tfstcomerciosnombre = StringUtil.PadR( StringUtil.RTrim( AV108Mapeowwds_28_tfstcomerciosnombre), 80, "%");
         lV110Mapeowwds_30_tfconexionesid = StringUtil.PadR( StringUtil.RTrim( AV110Mapeowwds_30_tfconexionesid), 9, "%");
         lV112Mapeowwds_32_tfconexionesnombre = StringUtil.PadR( StringUtil.RTrim( AV112Mapeowwds_32_tfconexionesnombre), 80, "%");
         /* Using cursor P00KL2 */
         pr_default.execute(0, new Object[] {lV84Mapeowwds_4_stcomerciosnombre1, lV84Mapeowwds_4_stcomerciosnombre1, lV85Mapeowwds_5_proveedornombre1, lV85Mapeowwds_5_proveedornombre1, lV86Mapeowwds_6_conexionesnombre1, lV86Mapeowwds_6_conexionesnombre1, lV90Mapeowwds_10_stcomerciosnombre2, lV90Mapeowwds_10_stcomerciosnombre2, lV91Mapeowwds_11_proveedornombre2, lV91Mapeowwds_11_proveedornombre2, lV92Mapeowwds_12_conexionesnombre2, lV92Mapeowwds_12_conexionesnombre2, lV96Mapeowwds_16_stcomerciosnombre3, lV96Mapeowwds_16_stcomerciosnombre3, lV97Mapeowwds_17_proveedornombre3, lV97Mapeowwds_17_proveedornombre3, lV98Mapeowwds_18_conexionesnombre3, lV98Mapeowwds_18_conexionesnombre3, AV99Mapeowwds_19_tfmapeoid, AV100Mapeowwds_20_tfmapeoid_to, AV101Mapeowwds_21_tfproveedorid, AV102Mapeowwds_22_tfproveedorid_to, lV103Mapeowwds_23_tfproveedornombre, AV104Mapeowwds_24_tfproveedornombre_sel, AV106Mapeowwds_26_tfstcomerciosid, AV107Mapeowwds_27_tfstcomerciosid_to, lV108Mapeowwds_28_tfstcomerciosnombre, AV109Mapeowwds_29_tfstcomerciosnombre_sel, lV110Mapeowwds_30_tfconexionesid, AV111Mapeowwds_31_tfconexionesid_sel, lV112Mapeowwds_32_tfconexionesnombre, AV113Mapeowwds_33_tfconexionesnombre_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A556ConexionesNombre = P00KL2_A556ConexionesNombre[0];
            n556ConexionesNombre = P00KL2_n556ConexionesNombre[0];
            A552ConexionesID = P00KL2_A552ConexionesID[0];
            n552ConexionesID = P00KL2_n552ConexionesID[0];
            A923STComerciosNombre = P00KL2_A923STComerciosNombre[0];
            A919STComerciosID = P00KL2_A919STComerciosID[0];
            n919STComerciosID = P00KL2_n919STComerciosID[0];
            A282ProveedorNombre = P00KL2_A282ProveedorNombre[0];
            A133ProveedorID = P00KL2_A133ProveedorID[0];
            A918MapeoID = P00KL2_A918MapeoID[0];
            A344ProveedorEstado = P00KL2_A344ProveedorEstado[0];
            A556ConexionesNombre = P00KL2_A556ConexionesNombre[0];
            n556ConexionesNombre = P00KL2_n556ConexionesNombre[0];
            A923STComerciosNombre = P00KL2_A923STComerciosNombre[0];
            A282ProveedorNombre = P00KL2_A282ProveedorNombre[0];
            A344ProveedorEstado = P00KL2_A344ProveedorEstado[0];
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV81Mapeowwds_1_filterfulltext)) || ( ( StringUtil.Like( StringUtil.Str( (decimal)(A918MapeoID), 18, 0) , StringUtil.PadR( "%" + AV81Mapeowwds_1_filterfulltext , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Str( (decimal)(A133ProveedorID), 18, 0) , StringUtil.PadR( "%" + AV81Mapeowwds_1_filterfulltext , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A282ProveedorNombre) , StringUtil.PadR( "%" + StringUtil.Upper( AV81Mapeowwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( context.GetMessage( "habilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV81Mapeowwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A344ProveedorEstado, "HAB") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "deshabilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV81Mapeowwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A344ProveedorEstado, "DES") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "pendiente", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV81Mapeowwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A344ProveedorEstado, "PEN") == 0 ) ) || ( StringUtil.Like( StringUtil.Str( (decimal)(A919STComerciosID), 18, 0) , StringUtil.PadR( "%" + AV81Mapeowwds_1_filterfulltext , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A923STComerciosNombre) , StringUtil.PadR( "%" + StringUtil.Upper( AV81Mapeowwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A552ConexionesID) , StringUtil.PadR( "%" + StringUtil.Upper( AV81Mapeowwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A556ConexionesNombre) , StringUtil.PadR( "%" + StringUtil.Upper( AV81Mapeowwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) ) )
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
               AV32VisibleColumnCount = 0;
               AV114GXV3 = 1;
               while ( AV114GXV3 <= AV24ColumnsSelector.gxTpr_Columns.Count )
               {
                  AV26ColumnsSelector_Column = ((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV24ColumnsSelector.gxTpr_Columns.Item(AV114GXV3));
                  if ( AV26ColumnsSelector_Column.gxTpr_Isvisible )
                  {
                     if ( StringUtil.StrCmp(AV26ColumnsSelector_Column.gxTpr_Columnname, "MapeoID") == 0 )
                     {
                        AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV32VisibleColumnCount), 1, 1).Number = A918MapeoID;
                     }
                     else if ( StringUtil.StrCmp(AV26ColumnsSelector_Column.gxTpr_Columnname, "ProveedorID") == 0 )
                     {
                        AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV32VisibleColumnCount), 1, 1).Number = A133ProveedorID;
                     }
                     else if ( StringUtil.StrCmp(AV26ColumnsSelector_Column.gxTpr_Columnname, "ProveedorNombre") == 0 )
                     {
                        GXt_char2 = "";
                        new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A282ProveedorNombre, out  GXt_char2) ;
                        AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV32VisibleColumnCount), 1, 1).Text = GXt_char2;
                     }
                     else if ( StringUtil.StrCmp(AV26ColumnsSelector_Column.gxTpr_Columnname, "ProveedorEstado") == 0 )
                     {
                        AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV32VisibleColumnCount), 1, 1).Text = context.GetMessage( gxdomainestadoenum.getDescription(context,A344ProveedorEstado), "");
                     }
                     else if ( StringUtil.StrCmp(AV26ColumnsSelector_Column.gxTpr_Columnname, "STComerciosID") == 0 )
                     {
                        AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV32VisibleColumnCount), 1, 1).Number = A919STComerciosID;
                     }
                     else if ( StringUtil.StrCmp(AV26ColumnsSelector_Column.gxTpr_Columnname, "STComerciosNombre") == 0 )
                     {
                        GXt_char2 = "";
                        new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A923STComerciosNombre, out  GXt_char2) ;
                        AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV32VisibleColumnCount), 1, 1).Text = GXt_char2;
                     }
                     else if ( StringUtil.StrCmp(AV26ColumnsSelector_Column.gxTpr_Columnname, "ConexionesID") == 0 )
                     {
                        GXt_char2 = "";
                        new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A552ConexionesID, out  GXt_char2) ;
                        AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV32VisibleColumnCount), 1, 1).Text = GXt_char2;
                     }
                     else if ( StringUtil.StrCmp(AV26ColumnsSelector_Column.gxTpr_Columnname, "ConexionesNombre") == 0 )
                     {
                        GXt_char2 = "";
                        new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A556ConexionesNombre, out  GXt_char2) ;
                        AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV32VisibleColumnCount), 1, 1).Text = GXt_char2;
                     }
                     AV32VisibleColumnCount = (long)(AV32VisibleColumnCount+1);
                  }
                  AV114GXV3 = (int)(AV114GXV3+1);
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
         AV20Session.Set("WWPExportFilePath", AV12Filename);
         AV20Session.Set("WWPExportFileName", "MapeoWWExport.xlsx");
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
         AV24ColumnsSelector = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector(context);
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV24ColumnsSelector,  "MapeoID",  "",  "Mapeo ID",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV24ColumnsSelector,  "ProveedorID",  "",  "Código del Proveedor",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV24ColumnsSelector,  "ProveedorNombre",  "",  "Nombre",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV24ColumnsSelector,  "ProveedorEstado",  "",  "Estado",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV24ColumnsSelector,  "STComerciosID",  "",  "Comercio",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV24ColumnsSelector,  "STComerciosNombre",  "",  "Nombre",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV24ColumnsSelector,  "ConexionesID",  "",  "Código de Conexión",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV24ColumnsSelector,  "ConexionesNombre",  "",  "Nombre",  true,  "") ;
         GXt_char2 = AV28UserCustomValue;
         new GeneXus.Programs.wwpbaseobjects.loadcolumnsselectorstate(context ).execute(  "MapeoWWColumnsSelector", out  GXt_char2) ;
         AV28UserCustomValue = GXt_char2;
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV28UserCustomValue)) ) )
         {
            AV25ColumnsSelectorAux.FromXml(AV28UserCustomValue, null, "", "");
            new GeneXus.Programs.wwpbaseobjects.wwp_columnselector_updatecolumns(context ).execute( ref  AV25ColumnsSelectorAux, ref  AV24ColumnsSelector) ;
         }
      }

      protected void S201( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV20Session.Get("MapeoWWGridState"), "") == 0 )
         {
            AV22GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "MapeoWWGridState"), null, "", "");
         }
         else
         {
            AV22GridState.FromXml(AV20Session.Get("MapeoWWGridState"), null, "", "");
         }
         AV17OrderedBy = AV22GridState.gxTpr_Orderedby;
         AV18OrderedDsc = AV22GridState.gxTpr_Ordereddsc;
         AV115GXV4 = 1;
         while ( AV115GXV4 <= AV22GridState.gxTpr_Filtervalues.Count )
         {
            AV23GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV22GridState.gxTpr_Filtervalues.Item(AV115GXV4));
            if ( StringUtil.StrCmp(AV23GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV19FilterFullText = AV23GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV23GridStateFilterValue.gxTpr_Name, "TFMAPEOID") == 0 )
            {
               AV35TFMapeoID = (long)(Math.Round(NumberUtil.Val( AV23GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV36TFMapeoID_To = (long)(Math.Round(NumberUtil.Val( AV23GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV23GridStateFilterValue.gxTpr_Name, "TFPROVEEDORID") == 0 )
            {
               AV37TFProveedorID = (long)(Math.Round(NumberUtil.Val( AV23GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV38TFProveedorID_To = (long)(Math.Round(NumberUtil.Val( AV23GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV23GridStateFilterValue.gxTpr_Name, "TFPROVEEDORNOMBRE") == 0 )
            {
               AV39TFProveedorNombre = AV23GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV23GridStateFilterValue.gxTpr_Name, "TFPROVEEDORNOMBRE_SEL") == 0 )
            {
               AV40TFProveedorNombre_Sel = AV23GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV23GridStateFilterValue.gxTpr_Name, "TFPROVEEDORESTADO_SEL") == 0 )
            {
               AV41TFProveedorEstado_SelsJson = AV23GridStateFilterValue.gxTpr_Value;
               AV43TFProveedorEstado_Sels.FromJSonString(AV41TFProveedorEstado_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV23GridStateFilterValue.gxTpr_Name, "TFSTCOMERCIOSID") == 0 )
            {
               AV44TFSTComerciosID = (long)(Math.Round(NumberUtil.Val( AV23GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV45TFSTComerciosID_To = (long)(Math.Round(NumberUtil.Val( AV23GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV23GridStateFilterValue.gxTpr_Name, "TFSTCOMERCIOSNOMBRE") == 0 )
            {
               AV46TFSTComerciosNombre = AV23GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV23GridStateFilterValue.gxTpr_Name, "TFSTCOMERCIOSNOMBRE_SEL") == 0 )
            {
               AV47TFSTComerciosNombre_Sel = AV23GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV23GridStateFilterValue.gxTpr_Name, "TFCONEXIONESID") == 0 )
            {
               AV51TFConexionesID = AV23GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV23GridStateFilterValue.gxTpr_Name, "TFCONEXIONESID_SEL") == 0 )
            {
               AV52TFConexionesID_Sel = AV23GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV23GridStateFilterValue.gxTpr_Name, "TFCONEXIONESNOMBRE") == 0 )
            {
               AV53TFConexionesNombre = AV23GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV23GridStateFilterValue.gxTpr_Name, "TFCONEXIONESNOMBRE_SEL") == 0 )
            {
               AV54TFConexionesNombre_Sel = AV23GridStateFilterValue.gxTpr_Value;
            }
            AV115GXV4 = (int)(AV115GXV4+1);
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
         AV77Pgmname = "";
         GXKey = "";
         GXEncryptionTmp = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV11ExcelDocument = new ExcelDocumentI();
         AV19FilterFullText = "";
         AV22GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV76GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV59DynamicFiltersSelector1 = "";
         AV61STComerciosNombre1 = "";
         AV62ProveedorNombre1 = "";
         AV63ConexionesNombre1 = "";
         AV65DynamicFiltersSelector2 = "";
         AV67STComerciosNombre2 = "";
         AV68ProveedorNombre2 = "";
         AV69ConexionesNombre2 = "";
         AV71DynamicFiltersSelector3 = "";
         AV73STComerciosNombre3 = "";
         AV74ProveedorNombre3 = "";
         AV75ConexionesNombre3 = "";
         AV40TFProveedorNombre_Sel = "";
         AV39TFProveedorNombre = "";
         AV43TFProveedorEstado_Sels = new GxSimpleCollection<string>();
         AV42TFProveedorEstado_Sel = "";
         AV47TFSTComerciosNombre_Sel = "";
         AV46TFSTComerciosNombre = "";
         AV52TFConexionesID_Sel = "";
         AV51TFConexionesID = "";
         AV54TFConexionesNombre_Sel = "";
         AV53TFConexionesNombre = "";
         AV20Session = context.GetSession();
         AV27ColumnsSelectorXML = "";
         AV24ColumnsSelector = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector(context);
         AV26ColumnsSelector_Column = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column(context);
         AV81Mapeowwds_1_filterfulltext = "";
         AV82Mapeowwds_2_dynamicfiltersselector1 = "";
         AV84Mapeowwds_4_stcomerciosnombre1 = "";
         AV85Mapeowwds_5_proveedornombre1 = "";
         AV86Mapeowwds_6_conexionesnombre1 = "";
         AV88Mapeowwds_8_dynamicfiltersselector2 = "";
         AV90Mapeowwds_10_stcomerciosnombre2 = "";
         AV91Mapeowwds_11_proveedornombre2 = "";
         AV92Mapeowwds_12_conexionesnombre2 = "";
         AV94Mapeowwds_14_dynamicfiltersselector3 = "";
         AV96Mapeowwds_16_stcomerciosnombre3 = "";
         AV97Mapeowwds_17_proveedornombre3 = "";
         AV98Mapeowwds_18_conexionesnombre3 = "";
         AV103Mapeowwds_23_tfproveedornombre = "";
         AV104Mapeowwds_24_tfproveedornombre_sel = "";
         AV105Mapeowwds_25_tfproveedorestado_sels = new GxSimpleCollection<string>();
         AV108Mapeowwds_28_tfstcomerciosnombre = "";
         AV109Mapeowwds_29_tfstcomerciosnombre_sel = "";
         AV110Mapeowwds_30_tfconexionesid = "";
         AV111Mapeowwds_31_tfconexionesid_sel = "";
         AV112Mapeowwds_32_tfconexionesnombre = "";
         AV113Mapeowwds_33_tfconexionesnombre_sel = "";
         lV81Mapeowwds_1_filterfulltext = "";
         lV84Mapeowwds_4_stcomerciosnombre1 = "";
         lV85Mapeowwds_5_proveedornombre1 = "";
         lV86Mapeowwds_6_conexionesnombre1 = "";
         lV90Mapeowwds_10_stcomerciosnombre2 = "";
         lV91Mapeowwds_11_proveedornombre2 = "";
         lV92Mapeowwds_12_conexionesnombre2 = "";
         lV96Mapeowwds_16_stcomerciosnombre3 = "";
         lV97Mapeowwds_17_proveedornombre3 = "";
         lV98Mapeowwds_18_conexionesnombre3 = "";
         lV103Mapeowwds_23_tfproveedornombre = "";
         lV108Mapeowwds_28_tfstcomerciosnombre = "";
         lV110Mapeowwds_30_tfconexionesid = "";
         lV112Mapeowwds_32_tfconexionesnombre = "";
         A344ProveedorEstado = "";
         A923STComerciosNombre = "";
         A282ProveedorNombre = "";
         A556ConexionesNombre = "";
         A552ConexionesID = "";
         P00KL2_A556ConexionesNombre = new string[] {""} ;
         P00KL2_n556ConexionesNombre = new bool[] {false} ;
         P00KL2_A552ConexionesID = new string[] {""} ;
         P00KL2_n552ConexionesID = new bool[] {false} ;
         P00KL2_A923STComerciosNombre = new string[] {""} ;
         P00KL2_A919STComerciosID = new long[1] ;
         P00KL2_n919STComerciosID = new bool[] {false} ;
         P00KL2_A282ProveedorNombre = new string[] {""} ;
         P00KL2_A133ProveedorID = new long[1] ;
         P00KL2_A918MapeoID = new long[1] ;
         P00KL2_A344ProveedorEstado = new string[] {""} ;
         AV28UserCustomValue = "";
         GXt_char2 = "";
         AV25ColumnsSelectorAux = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector(context);
         AV23GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV41TFProveedorEstado_SelsJson = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.mapeowwexport__default(),
            new Object[][] {
                new Object[] {
               P00KL2_A556ConexionesNombre, P00KL2_n556ConexionesNombre, P00KL2_A552ConexionesID, P00KL2_n552ConexionesID, P00KL2_A923STComerciosNombre, P00KL2_A919STComerciosID, P00KL2_n919STComerciosID, P00KL2_A282ProveedorNombre, P00KL2_A133ProveedorID, P00KL2_A918MapeoID,
               P00KL2_A344ProveedorEstado
               }
            }
         );
         AV77Pgmname = "MapeoWWExport";
         /* GeneXus formulas. */
         AV77Pgmname = "MapeoWWExport";
      }

      private short AV60DynamicFiltersOperator1 ;
      private short AV66DynamicFiltersOperator2 ;
      private short AV72DynamicFiltersOperator3 ;
      private short GXt_int3 ;
      private short AV83Mapeowwds_3_dynamicfiltersoperator1 ;
      private short AV89Mapeowwds_9_dynamicfiltersoperator2 ;
      private short AV95Mapeowwds_15_dynamicfiltersoperator3 ;
      private short AV17OrderedBy ;
      private int AV14CellRow ;
      private int AV15FirstColumn ;
      private int AV16Random ;
      private int AV78GXV1 ;
      private int AV79GXV2 ;
      private int AV105Mapeowwds_25_tfproveedorestado_sels_Count ;
      private int AV114GXV3 ;
      private int AV115GXV4 ;
      private long AV35TFMapeoID ;
      private long AV36TFMapeoID_To ;
      private long AV37TFProveedorID ;
      private long AV38TFProveedorID_To ;
      private long AV58i ;
      private long AV44TFSTComerciosID ;
      private long AV45TFSTComerciosID_To ;
      private long AV32VisibleColumnCount ;
      private long AV99Mapeowwds_19_tfmapeoid ;
      private long AV100Mapeowwds_20_tfmapeoid_to ;
      private long AV101Mapeowwds_21_tfproveedorid ;
      private long AV102Mapeowwds_22_tfproveedorid_to ;
      private long AV106Mapeowwds_26_tfstcomerciosid ;
      private long AV107Mapeowwds_27_tfstcomerciosid_to ;
      private long A918MapeoID ;
      private long A133ProveedorID ;
      private long A919STComerciosID ;
      private string AV77Pgmname ;
      private string GXKey ;
      private string GXEncryptionTmp ;
      private string AV61STComerciosNombre1 ;
      private string AV62ProveedorNombre1 ;
      private string AV63ConexionesNombre1 ;
      private string AV67STComerciosNombre2 ;
      private string AV68ProveedorNombre2 ;
      private string AV69ConexionesNombre2 ;
      private string AV73STComerciosNombre3 ;
      private string AV74ProveedorNombre3 ;
      private string AV75ConexionesNombre3 ;
      private string AV40TFProveedorNombre_Sel ;
      private string AV39TFProveedorNombre ;
      private string AV42TFProveedorEstado_Sel ;
      private string AV47TFSTComerciosNombre_Sel ;
      private string AV46TFSTComerciosNombre ;
      private string AV52TFConexionesID_Sel ;
      private string AV51TFConexionesID ;
      private string AV54TFConexionesNombre_Sel ;
      private string AV53TFConexionesNombre ;
      private string AV84Mapeowwds_4_stcomerciosnombre1 ;
      private string AV85Mapeowwds_5_proveedornombre1 ;
      private string AV86Mapeowwds_6_conexionesnombre1 ;
      private string AV90Mapeowwds_10_stcomerciosnombre2 ;
      private string AV91Mapeowwds_11_proveedornombre2 ;
      private string AV92Mapeowwds_12_conexionesnombre2 ;
      private string AV96Mapeowwds_16_stcomerciosnombre3 ;
      private string AV97Mapeowwds_17_proveedornombre3 ;
      private string AV98Mapeowwds_18_conexionesnombre3 ;
      private string AV103Mapeowwds_23_tfproveedornombre ;
      private string AV104Mapeowwds_24_tfproveedornombre_sel ;
      private string AV108Mapeowwds_28_tfstcomerciosnombre ;
      private string AV109Mapeowwds_29_tfstcomerciosnombre_sel ;
      private string AV110Mapeowwds_30_tfconexionesid ;
      private string AV111Mapeowwds_31_tfconexionesid_sel ;
      private string AV112Mapeowwds_32_tfconexionesnombre ;
      private string AV113Mapeowwds_33_tfconexionesnombre_sel ;
      private string lV84Mapeowwds_4_stcomerciosnombre1 ;
      private string lV85Mapeowwds_5_proveedornombre1 ;
      private string lV86Mapeowwds_6_conexionesnombre1 ;
      private string lV90Mapeowwds_10_stcomerciosnombre2 ;
      private string lV91Mapeowwds_11_proveedornombre2 ;
      private string lV92Mapeowwds_12_conexionesnombre2 ;
      private string lV96Mapeowwds_16_stcomerciosnombre3 ;
      private string lV97Mapeowwds_17_proveedornombre3 ;
      private string lV98Mapeowwds_18_conexionesnombre3 ;
      private string lV103Mapeowwds_23_tfproveedornombre ;
      private string lV108Mapeowwds_28_tfstcomerciosnombre ;
      private string lV110Mapeowwds_30_tfconexionesid ;
      private string lV112Mapeowwds_32_tfconexionesnombre ;
      private string A344ProveedorEstado ;
      private string A923STComerciosNombre ;
      private string A282ProveedorNombre ;
      private string A556ConexionesNombre ;
      private string A552ConexionesID ;
      private string GXt_char2 ;
      private bool AV8IsAuthorized ;
      private bool GXt_boolean1 ;
      private bool returnInSub ;
      private bool AV64DynamicFiltersEnabled2 ;
      private bool AV70DynamicFiltersEnabled3 ;
      private bool AV87Mapeowwds_7_dynamicfiltersenabled2 ;
      private bool AV93Mapeowwds_13_dynamicfiltersenabled3 ;
      private bool AV18OrderedDsc ;
      private bool n556ConexionesNombre ;
      private bool n552ConexionesID ;
      private bool n919STComerciosID ;
      private string AV27ColumnsSelectorXML ;
      private string AV28UserCustomValue ;
      private string AV41TFProveedorEstado_SelsJson ;
      private string AV12Filename ;
      private string AV13ErrorMessage ;
      private string AV19FilterFullText ;
      private string AV59DynamicFiltersSelector1 ;
      private string AV65DynamicFiltersSelector2 ;
      private string AV71DynamicFiltersSelector3 ;
      private string AV81Mapeowwds_1_filterfulltext ;
      private string AV82Mapeowwds_2_dynamicfiltersselector1 ;
      private string AV88Mapeowwds_8_dynamicfiltersselector2 ;
      private string AV94Mapeowwds_14_dynamicfiltersselector3 ;
      private string lV81Mapeowwds_1_filterfulltext ;
      private IGxSession AV20Session ;
      private ExcelDocumentI AV11ExcelDocument ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV22GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV76GridStateDynamicFilter ;
      private GxSimpleCollection<string> AV43TFProveedorEstado_Sels ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector AV24ColumnsSelector ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column AV26ColumnsSelector_Column ;
      private GxSimpleCollection<string> AV105Mapeowwds_25_tfproveedorestado_sels ;
      private IDataStoreProvider pr_default ;
      private string[] P00KL2_A556ConexionesNombre ;
      private bool[] P00KL2_n556ConexionesNombre ;
      private string[] P00KL2_A552ConexionesID ;
      private bool[] P00KL2_n552ConexionesID ;
      private string[] P00KL2_A923STComerciosNombre ;
      private long[] P00KL2_A919STComerciosID ;
      private bool[] P00KL2_n919STComerciosID ;
      private string[] P00KL2_A282ProveedorNombre ;
      private long[] P00KL2_A133ProveedorID ;
      private long[] P00KL2_A918MapeoID ;
      private string[] P00KL2_A344ProveedorEstado ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector AV25ColumnsSelectorAux ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV23GridStateFilterValue ;
      private string aP0_Filename ;
      private string aP1_ErrorMessage ;
   }

   public class mapeowwexport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00KL2( IGxContext context ,
                                             string A344ProveedorEstado ,
                                             GxSimpleCollection<string> AV105Mapeowwds_25_tfproveedorestado_sels ,
                                             string AV82Mapeowwds_2_dynamicfiltersselector1 ,
                                             short AV83Mapeowwds_3_dynamicfiltersoperator1 ,
                                             string AV84Mapeowwds_4_stcomerciosnombre1 ,
                                             string AV85Mapeowwds_5_proveedornombre1 ,
                                             string AV86Mapeowwds_6_conexionesnombre1 ,
                                             bool AV87Mapeowwds_7_dynamicfiltersenabled2 ,
                                             string AV88Mapeowwds_8_dynamicfiltersselector2 ,
                                             short AV89Mapeowwds_9_dynamicfiltersoperator2 ,
                                             string AV90Mapeowwds_10_stcomerciosnombre2 ,
                                             string AV91Mapeowwds_11_proveedornombre2 ,
                                             string AV92Mapeowwds_12_conexionesnombre2 ,
                                             bool AV93Mapeowwds_13_dynamicfiltersenabled3 ,
                                             string AV94Mapeowwds_14_dynamicfiltersselector3 ,
                                             short AV95Mapeowwds_15_dynamicfiltersoperator3 ,
                                             string AV96Mapeowwds_16_stcomerciosnombre3 ,
                                             string AV97Mapeowwds_17_proveedornombre3 ,
                                             string AV98Mapeowwds_18_conexionesnombre3 ,
                                             long AV99Mapeowwds_19_tfmapeoid ,
                                             long AV100Mapeowwds_20_tfmapeoid_to ,
                                             long AV101Mapeowwds_21_tfproveedorid ,
                                             long AV102Mapeowwds_22_tfproveedorid_to ,
                                             string AV104Mapeowwds_24_tfproveedornombre_sel ,
                                             string AV103Mapeowwds_23_tfproveedornombre ,
                                             int AV105Mapeowwds_25_tfproveedorestado_sels_Count ,
                                             long AV106Mapeowwds_26_tfstcomerciosid ,
                                             long AV107Mapeowwds_27_tfstcomerciosid_to ,
                                             string AV109Mapeowwds_29_tfstcomerciosnombre_sel ,
                                             string AV108Mapeowwds_28_tfstcomerciosnombre ,
                                             string AV111Mapeowwds_31_tfconexionesid_sel ,
                                             string AV110Mapeowwds_30_tfconexionesid ,
                                             string AV113Mapeowwds_33_tfconexionesnombre_sel ,
                                             string AV112Mapeowwds_32_tfconexionesnombre ,
                                             string A923STComerciosNombre ,
                                             string A282ProveedorNombre ,
                                             string A556ConexionesNombre ,
                                             long A918MapeoID ,
                                             long A133ProveedorID ,
                                             long A919STComerciosID ,
                                             string A552ConexionesID ,
                                             short AV17OrderedBy ,
                                             bool AV18OrderedDsc ,
                                             string AV81Mapeowwds_1_filterfulltext )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int4 = new short[32];
         Object[] GXv_Object5 = new Object[2];
         scmdbuf = "SELECT T2.[ConexionesNombre], T1.[ConexionesID], T3.[ProveedorNombre] AS STComerciosNombre, T1.[STComerciosID] AS STComerciosID, T4.[ProveedorNombre], T1.[ProveedorID], T1.[MapeoID], T4.[ProveedorEstado] FROM ((([ListaMapeo] T1 LEFT JOIN [Conexiones] T2 ON T2.[ConexionesID] = T1.[ConexionesID]) LEFT JOIN [Proveedor] T3 ON T3.[ProveedorID] = T1.[STComerciosID]) INNER JOIN [Proveedor] T4 ON T4.[ProveedorID] = T1.[ProveedorID])";
         if ( ( StringUtil.StrCmp(AV82Mapeowwds_2_dynamicfiltersselector1, "STCOMERCIOSNOMBRE") == 0 ) && ( AV83Mapeowwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV84Mapeowwds_4_stcomerciosnombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T3.[ProveedorNombre]) like UPPER(@lV84Mapeowwds_4_stcomerciosnombre1))");
         }
         else
         {
            GXv_int4[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV82Mapeowwds_2_dynamicfiltersselector1, "STCOMERCIOSNOMBRE") == 0 ) && ( AV83Mapeowwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV84Mapeowwds_4_stcomerciosnombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T3.[ProveedorNombre]) like '%' + UPPER(@lV84Mapeowwds_4_stcomerciosnombre1))");
         }
         else
         {
            GXv_int4[1] = 1;
         }
         if ( ( StringUtil.StrCmp(AV82Mapeowwds_2_dynamicfiltersselector1, "PROVEEDORNOMBRE") == 0 ) && ( AV83Mapeowwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV85Mapeowwds_5_proveedornombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T4.[ProveedorNombre]) like UPPER(@lV85Mapeowwds_5_proveedornombre1))");
         }
         else
         {
            GXv_int4[2] = 1;
         }
         if ( ( StringUtil.StrCmp(AV82Mapeowwds_2_dynamicfiltersselector1, "PROVEEDORNOMBRE") == 0 ) && ( AV83Mapeowwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV85Mapeowwds_5_proveedornombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T4.[ProveedorNombre]) like '%' + UPPER(@lV85Mapeowwds_5_proveedornombre1))");
         }
         else
         {
            GXv_int4[3] = 1;
         }
         if ( ( StringUtil.StrCmp(AV82Mapeowwds_2_dynamicfiltersselector1, "CONEXIONESNOMBRE") == 0 ) && ( AV83Mapeowwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV86Mapeowwds_6_conexionesnombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ConexionesNombre]) like UPPER(@lV86Mapeowwds_6_conexionesnombre1))");
         }
         else
         {
            GXv_int4[4] = 1;
         }
         if ( ( StringUtil.StrCmp(AV82Mapeowwds_2_dynamicfiltersselector1, "CONEXIONESNOMBRE") == 0 ) && ( AV83Mapeowwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV86Mapeowwds_6_conexionesnombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ConexionesNombre]) like '%' + UPPER(@lV86Mapeowwds_6_conexionesnombre1))");
         }
         else
         {
            GXv_int4[5] = 1;
         }
         if ( AV87Mapeowwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV88Mapeowwds_8_dynamicfiltersselector2, "STCOMERCIOSNOMBRE") == 0 ) && ( AV89Mapeowwds_9_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV90Mapeowwds_10_stcomerciosnombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T3.[ProveedorNombre]) like UPPER(@lV90Mapeowwds_10_stcomerciosnombre2))");
         }
         else
         {
            GXv_int4[6] = 1;
         }
         if ( AV87Mapeowwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV88Mapeowwds_8_dynamicfiltersselector2, "STCOMERCIOSNOMBRE") == 0 ) && ( AV89Mapeowwds_9_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV90Mapeowwds_10_stcomerciosnombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T3.[ProveedorNombre]) like '%' + UPPER(@lV90Mapeowwds_10_stcomerciosnombre2))");
         }
         else
         {
            GXv_int4[7] = 1;
         }
         if ( AV87Mapeowwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV88Mapeowwds_8_dynamicfiltersselector2, "PROVEEDORNOMBRE") == 0 ) && ( AV89Mapeowwds_9_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV91Mapeowwds_11_proveedornombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T4.[ProveedorNombre]) like UPPER(@lV91Mapeowwds_11_proveedornombre2))");
         }
         else
         {
            GXv_int4[8] = 1;
         }
         if ( AV87Mapeowwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV88Mapeowwds_8_dynamicfiltersselector2, "PROVEEDORNOMBRE") == 0 ) && ( AV89Mapeowwds_9_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV91Mapeowwds_11_proveedornombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T4.[ProveedorNombre]) like '%' + UPPER(@lV91Mapeowwds_11_proveedornombre2))");
         }
         else
         {
            GXv_int4[9] = 1;
         }
         if ( AV87Mapeowwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV88Mapeowwds_8_dynamicfiltersselector2, "CONEXIONESNOMBRE") == 0 ) && ( AV89Mapeowwds_9_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV92Mapeowwds_12_conexionesnombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ConexionesNombre]) like UPPER(@lV92Mapeowwds_12_conexionesnombre2))");
         }
         else
         {
            GXv_int4[10] = 1;
         }
         if ( AV87Mapeowwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV88Mapeowwds_8_dynamicfiltersselector2, "CONEXIONESNOMBRE") == 0 ) && ( AV89Mapeowwds_9_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV92Mapeowwds_12_conexionesnombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ConexionesNombre]) like '%' + UPPER(@lV92Mapeowwds_12_conexionesnombre2))");
         }
         else
         {
            GXv_int4[11] = 1;
         }
         if ( AV93Mapeowwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV94Mapeowwds_14_dynamicfiltersselector3, "STCOMERCIOSNOMBRE") == 0 ) && ( AV95Mapeowwds_15_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV96Mapeowwds_16_stcomerciosnombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T3.[ProveedorNombre]) like UPPER(@lV96Mapeowwds_16_stcomerciosnombre3))");
         }
         else
         {
            GXv_int4[12] = 1;
         }
         if ( AV93Mapeowwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV94Mapeowwds_14_dynamicfiltersselector3, "STCOMERCIOSNOMBRE") == 0 ) && ( AV95Mapeowwds_15_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV96Mapeowwds_16_stcomerciosnombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T3.[ProveedorNombre]) like '%' + UPPER(@lV96Mapeowwds_16_stcomerciosnombre3))");
         }
         else
         {
            GXv_int4[13] = 1;
         }
         if ( AV93Mapeowwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV94Mapeowwds_14_dynamicfiltersselector3, "PROVEEDORNOMBRE") == 0 ) && ( AV95Mapeowwds_15_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV97Mapeowwds_17_proveedornombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T4.[ProveedorNombre]) like UPPER(@lV97Mapeowwds_17_proveedornombre3))");
         }
         else
         {
            GXv_int4[14] = 1;
         }
         if ( AV93Mapeowwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV94Mapeowwds_14_dynamicfiltersselector3, "PROVEEDORNOMBRE") == 0 ) && ( AV95Mapeowwds_15_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV97Mapeowwds_17_proveedornombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T4.[ProveedorNombre]) like '%' + UPPER(@lV97Mapeowwds_17_proveedornombre3))");
         }
         else
         {
            GXv_int4[15] = 1;
         }
         if ( AV93Mapeowwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV94Mapeowwds_14_dynamicfiltersselector3, "CONEXIONESNOMBRE") == 0 ) && ( AV95Mapeowwds_15_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV98Mapeowwds_18_conexionesnombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ConexionesNombre]) like UPPER(@lV98Mapeowwds_18_conexionesnombre3))");
         }
         else
         {
            GXv_int4[16] = 1;
         }
         if ( AV93Mapeowwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV94Mapeowwds_14_dynamicfiltersselector3, "CONEXIONESNOMBRE") == 0 ) && ( AV95Mapeowwds_15_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV98Mapeowwds_18_conexionesnombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ConexionesNombre]) like '%' + UPPER(@lV98Mapeowwds_18_conexionesnombre3))");
         }
         else
         {
            GXv_int4[17] = 1;
         }
         if ( ! (0==AV99Mapeowwds_19_tfmapeoid) )
         {
            AddWhere(sWhereString, "(T1.[MapeoID] >= @AV99Mapeowwds_19_tfmapeoid)");
         }
         else
         {
            GXv_int4[18] = 1;
         }
         if ( ! (0==AV100Mapeowwds_20_tfmapeoid_to) )
         {
            AddWhere(sWhereString, "(T1.[MapeoID] <= @AV100Mapeowwds_20_tfmapeoid_to)");
         }
         else
         {
            GXv_int4[19] = 1;
         }
         if ( ! (0==AV101Mapeowwds_21_tfproveedorid) )
         {
            AddWhere(sWhereString, "(T1.[ProveedorID] >= @AV101Mapeowwds_21_tfproveedorid)");
         }
         else
         {
            GXv_int4[20] = 1;
         }
         if ( ! (0==AV102Mapeowwds_22_tfproveedorid_to) )
         {
            AddWhere(sWhereString, "(T1.[ProveedorID] <= @AV102Mapeowwds_22_tfproveedorid_to)");
         }
         else
         {
            GXv_int4[21] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV104Mapeowwds_24_tfproveedornombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV103Mapeowwds_23_tfproveedornombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T4.[ProveedorNombre]) like UPPER(@lV103Mapeowwds_23_tfproveedornombre))");
         }
         else
         {
            GXv_int4[22] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV104Mapeowwds_24_tfproveedornombre_sel)) && ! ( StringUtil.StrCmp(AV104Mapeowwds_24_tfproveedornombre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T4.[ProveedorNombre] = @AV104Mapeowwds_24_tfproveedornombre_sel)");
         }
         else
         {
            GXv_int4[23] = 1;
         }
         if ( StringUtil.StrCmp(AV104Mapeowwds_24_tfproveedornombre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T4.[ProveedorNombre] = ''))");
         }
         if ( AV105Mapeowwds_25_tfproveedorestado_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV105Mapeowwds_25_tfproveedorestado_sels, "T4.[ProveedorEstado] IN (", ")")+")");
         }
         if ( ! (0==AV106Mapeowwds_26_tfstcomerciosid) )
         {
            AddWhere(sWhereString, "(T1.[STComerciosID] >= @AV106Mapeowwds_26_tfstcomerciosid)");
         }
         else
         {
            GXv_int4[24] = 1;
         }
         if ( ! (0==AV107Mapeowwds_27_tfstcomerciosid_to) )
         {
            AddWhere(sWhereString, "(T1.[STComerciosID] <= @AV107Mapeowwds_27_tfstcomerciosid_to)");
         }
         else
         {
            GXv_int4[25] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV109Mapeowwds_29_tfstcomerciosnombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV108Mapeowwds_28_tfstcomerciosnombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T3.[ProveedorNombre]) like UPPER(@lV108Mapeowwds_28_tfstcomerciosnombre))");
         }
         else
         {
            GXv_int4[26] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV109Mapeowwds_29_tfstcomerciosnombre_sel)) && ! ( StringUtil.StrCmp(AV109Mapeowwds_29_tfstcomerciosnombre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T3.[ProveedorNombre] = @AV109Mapeowwds_29_tfstcomerciosnombre_sel)");
         }
         else
         {
            GXv_int4[27] = 1;
         }
         if ( StringUtil.StrCmp(AV109Mapeowwds_29_tfstcomerciosnombre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T3.[ProveedorNombre] IS NULL or (T3.[ProveedorNombre] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV111Mapeowwds_31_tfconexionesid_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV110Mapeowwds_30_tfconexionesid)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[ConexionesID]) like UPPER(@lV110Mapeowwds_30_tfconexionesid))");
         }
         else
         {
            GXv_int4[28] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV111Mapeowwds_31_tfconexionesid_sel)) && ! ( StringUtil.StrCmp(AV111Mapeowwds_31_tfconexionesid_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[ConexionesID] = @AV111Mapeowwds_31_tfconexionesid_sel)");
         }
         else
         {
            GXv_int4[29] = 1;
         }
         if ( StringUtil.StrCmp(AV111Mapeowwds_31_tfconexionesid_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.[ConexionesID] IS NULL or (T1.[ConexionesID] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV113Mapeowwds_33_tfconexionesnombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV112Mapeowwds_32_tfconexionesnombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ConexionesNombre]) like UPPER(@lV112Mapeowwds_32_tfconexionesnombre))");
         }
         else
         {
            GXv_int4[30] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV113Mapeowwds_33_tfconexionesnombre_sel)) && ! ( StringUtil.StrCmp(AV113Mapeowwds_33_tfconexionesnombre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.[ConexionesNombre] = @AV113Mapeowwds_33_tfconexionesnombre_sel)");
         }
         else
         {
            GXv_int4[31] = 1;
         }
         if ( StringUtil.StrCmp(AV113Mapeowwds_33_tfconexionesnombre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T2.[ConexionesNombre] IS NULL or (T2.[ConexionesNombre] = ''))");
         }
         scmdbuf += sWhereString;
         if ( ( AV17OrderedBy == 1 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[MapeoID]";
         }
         else if ( ( AV17OrderedBy == 1 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[MapeoID] DESC";
         }
         else if ( ( AV17OrderedBy == 2 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[ProveedorID]";
         }
         else if ( ( AV17OrderedBy == 2 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[ProveedorID] DESC";
         }
         else if ( ( AV17OrderedBy == 3 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T4.[ProveedorNombre]";
         }
         else if ( ( AV17OrderedBy == 3 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T4.[ProveedorNombre] DESC";
         }
         else if ( ( AV17OrderedBy == 4 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T4.[ProveedorEstado]";
         }
         else if ( ( AV17OrderedBy == 4 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T4.[ProveedorEstado] DESC";
         }
         else if ( ( AV17OrderedBy == 5 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[STComerciosID]";
         }
         else if ( ( AV17OrderedBy == 5 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[STComerciosID] DESC";
         }
         else if ( ( AV17OrderedBy == 6 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T3.[ProveedorNombre]";
         }
         else if ( ( AV17OrderedBy == 6 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T3.[ProveedorNombre] DESC";
         }
         else if ( ( AV17OrderedBy == 7 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[ConexionesID]";
         }
         else if ( ( AV17OrderedBy == 7 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[ConexionesID] DESC";
         }
         else if ( ( AV17OrderedBy == 8 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T2.[ConexionesNombre]";
         }
         else if ( ( AV17OrderedBy == 8 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T2.[ConexionesNombre] DESC";
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
                     return conditional_P00KL2(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (bool)dynConstraints[7] , (string)dynConstraints[8] , (short)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (bool)dynConstraints[13] , (string)dynConstraints[14] , (short)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (long)dynConstraints[19] , (long)dynConstraints[20] , (long)dynConstraints[21] , (long)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (int)dynConstraints[25] , (long)dynConstraints[26] , (long)dynConstraints[27] , (string)dynConstraints[28] , (string)dynConstraints[29] , (string)dynConstraints[30] , (string)dynConstraints[31] , (string)dynConstraints[32] , (string)dynConstraints[33] , (string)dynConstraints[34] , (string)dynConstraints[35] , (string)dynConstraints[36] , (long)dynConstraints[37] , (long)dynConstraints[38] , (long)dynConstraints[39] , (string)dynConstraints[40] , (short)dynConstraints[41] , (bool)dynConstraints[42] , (string)dynConstraints[43] );
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
          Object[] prmP00KL2;
          prmP00KL2 = new Object[] {
          new ParDef("@lV84Mapeowwds_4_stcomerciosnombre1",GXType.Char,80,0) ,
          new ParDef("@lV84Mapeowwds_4_stcomerciosnombre1",GXType.Char,80,0) ,
          new ParDef("@lV85Mapeowwds_5_proveedornombre1",GXType.Char,80,0) ,
          new ParDef("@lV85Mapeowwds_5_proveedornombre1",GXType.Char,80,0) ,
          new ParDef("@lV86Mapeowwds_6_conexionesnombre1",GXType.Char,80,0) ,
          new ParDef("@lV86Mapeowwds_6_conexionesnombre1",GXType.Char,80,0) ,
          new ParDef("@lV90Mapeowwds_10_stcomerciosnombre2",GXType.Char,80,0) ,
          new ParDef("@lV90Mapeowwds_10_stcomerciosnombre2",GXType.Char,80,0) ,
          new ParDef("@lV91Mapeowwds_11_proveedornombre2",GXType.Char,80,0) ,
          new ParDef("@lV91Mapeowwds_11_proveedornombre2",GXType.Char,80,0) ,
          new ParDef("@lV92Mapeowwds_12_conexionesnombre2",GXType.Char,80,0) ,
          new ParDef("@lV92Mapeowwds_12_conexionesnombre2",GXType.Char,80,0) ,
          new ParDef("@lV96Mapeowwds_16_stcomerciosnombre3",GXType.Char,80,0) ,
          new ParDef("@lV96Mapeowwds_16_stcomerciosnombre3",GXType.Char,80,0) ,
          new ParDef("@lV97Mapeowwds_17_proveedornombre3",GXType.Char,80,0) ,
          new ParDef("@lV97Mapeowwds_17_proveedornombre3",GXType.Char,80,0) ,
          new ParDef("@lV98Mapeowwds_18_conexionesnombre3",GXType.Char,80,0) ,
          new ParDef("@lV98Mapeowwds_18_conexionesnombre3",GXType.Char,80,0) ,
          new ParDef("@AV99Mapeowwds_19_tfmapeoid",GXType.Decimal,18,0) ,
          new ParDef("@AV100Mapeowwds_20_tfmapeoid_to",GXType.Decimal,18,0) ,
          new ParDef("@AV101Mapeowwds_21_tfproveedorid",GXType.Decimal,18,0) ,
          new ParDef("@AV102Mapeowwds_22_tfproveedorid_to",GXType.Decimal,18,0) ,
          new ParDef("@lV103Mapeowwds_23_tfproveedornombre",GXType.Char,80,0) ,
          new ParDef("@AV104Mapeowwds_24_tfproveedornombre_sel",GXType.NChar,80,0) ,
          new ParDef("@AV106Mapeowwds_26_tfstcomerciosid",GXType.Decimal,18,0) ,
          new ParDef("@AV107Mapeowwds_27_tfstcomerciosid_to",GXType.Decimal,18,0) ,
          new ParDef("@lV108Mapeowwds_28_tfstcomerciosnombre",GXType.Char,80,0) ,
          new ParDef("@AV109Mapeowwds_29_tfstcomerciosnombre_sel",GXType.NChar,80,0) ,
          new ParDef("@lV110Mapeowwds_30_tfconexionesid",GXType.Char,9,0) ,
          new ParDef("@AV111Mapeowwds_31_tfconexionesid_sel",GXType.NChar,9,0) ,
          new ParDef("@lV112Mapeowwds_32_tfconexionesnombre",GXType.Char,80,0) ,
          new ParDef("@AV113Mapeowwds_33_tfconexionesnombre_sel",GXType.NChar,80,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00KL2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00KL2,100, GxCacheFrequency.OFF ,true,false )
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
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getString(2, 9);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((string[]) buf[4])[0] = rslt.getString(3, 80);
                ((long[]) buf[5])[0] = rslt.getLong(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((string[]) buf[7])[0] = rslt.getString(5, 80);
                ((long[]) buf[8])[0] = rslt.getLong(6);
                ((long[]) buf[9])[0] = rslt.getLong(7);
                ((string[]) buf[10])[0] = rslt.getString(8, 3);
                return;
       }
    }

 }

}

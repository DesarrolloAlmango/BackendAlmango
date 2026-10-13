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
   public class postulacioneswwexport : GXProcedure
   {
      public postulacioneswwexport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public postulacioneswwexport( IGxContext context )
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
         new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWPostulaciones", out  GXt_boolean1) ;
         AV8IsAuthorized = GXt_boolean1;
         if ( ! AV8IsAuthorized )
         {
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "wwpbaseobjects.notauthorized.aspx"+GXUtil.UrlEncode(StringUtil.RTrim(AV108Pgmname));
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
         AV12Filename = GXt_char2 + "PostulacionesWWExport-" + StringUtil.Trim( StringUtil.Str( (decimal)(AV16Random), 8, 0)) + ".xlsx";
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
            if ( StringUtil.StrCmp(AV20DynamicFiltersSelector1, "POSTULACIONESPROVEEDORNOMBRE") == 0 )
            {
               AV21DynamicFiltersOperator1 = AV34GridStateDynamicFilter.gxTpr_Operator;
               AV93PostulacionesProveedorNombre1 = AV34GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV93PostulacionesProveedorNombre1)) )
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
                  new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV93PostulacionesProveedorNombre1, out  GXt_char2) ;
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
               }
            }
            else if ( StringUtil.StrCmp(AV20DynamicFiltersSelector1, "POSTULACIONESPROVEEDORID") == 0 )
            {
               AV21DynamicFiltersOperator1 = AV34GridStateDynamicFilter.gxTpr_Operator;
               AV22PostulacionesProveedorId1 = (long)(Math.Round(NumberUtil.Val( AV34GridStateDynamicFilter.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               if ( ! (0==AV22PostulacionesProveedorId1) )
               {
                  AV14CellRow = (int)(AV14CellRow+1);
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Bold = 1;
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Color = 3;
                  if ( AV21DynamicFiltersOperator1 == 0 )
                  {
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", context.GetMessage( "Proveedor Id", ""), "<", "", "", "", "", "", "", "");
                  }
                  else if ( AV21DynamicFiltersOperator1 == 1 )
                  {
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", context.GetMessage( "Proveedor Id", ""), "=", "", "", "", "", "", "", "");
                  }
                  else if ( AV21DynamicFiltersOperator1 == 2 )
                  {
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", context.GetMessage( "Proveedor Id", ""), ">", "", "", "", "", "", "", "");
                  }
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Italic = 1;
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Number = AV22PostulacionesProveedorId1;
               }
            }
            else if ( StringUtil.StrCmp(AV20DynamicFiltersSelector1, "SERVICIOSNOMBRE") == 0 )
            {
               AV21DynamicFiltersOperator1 = AV34GridStateDynamicFilter.gxTpr_Operator;
               AV23ServiciosNombre1 = AV34GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV23ServiciosNombre1)) )
               {
                  AV14CellRow = (int)(AV14CellRow+1);
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Bold = 1;
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Color = 3;
                  if ( AV21DynamicFiltersOperator1 == 0 )
                  {
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", context.GetMessage( "Servicios Nombre", ""), context.GetMessage( "WWP_FilterLike", ""), "", "", "", "", "", "", "");
                  }
                  else if ( AV21DynamicFiltersOperator1 == 1 )
                  {
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", context.GetMessage( "Servicios Nombre", ""), context.GetMessage( "WWP_FilterContains", ""), "", "", "", "", "", "", "");
                  }
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Italic = 1;
                  GXt_char2 = "";
                  new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV23ServiciosNombre1, out  GXt_char2) ;
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
               }
            }
            if ( AV37GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV24DynamicFiltersEnabled2 = true;
               AV34GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV37GridState.gxTpr_Dynamicfilters.Item(2));
               AV25DynamicFiltersSelector2 = AV34GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV25DynamicFiltersSelector2, "POSTULACIONESPROVEEDORNOMBRE") == 0 )
               {
                  AV26DynamicFiltersOperator2 = AV34GridStateDynamicFilter.gxTpr_Operator;
                  AV94PostulacionesProveedorNombre2 = AV34GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV94PostulacionesProveedorNombre2)) )
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
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV94PostulacionesProveedorNombre2, out  GXt_char2) ;
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
                  }
               }
               else if ( StringUtil.StrCmp(AV25DynamicFiltersSelector2, "POSTULACIONESPROVEEDORID") == 0 )
               {
                  AV26DynamicFiltersOperator2 = AV34GridStateDynamicFilter.gxTpr_Operator;
                  AV27PostulacionesProveedorId2 = (long)(Math.Round(NumberUtil.Val( AV34GridStateDynamicFilter.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
                  if ( ! (0==AV27PostulacionesProveedorId2) )
                  {
                     AV14CellRow = (int)(AV14CellRow+1);
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Bold = 1;
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Color = 3;
                     if ( AV26DynamicFiltersOperator2 == 0 )
                     {
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", context.GetMessage( "Proveedor Id", ""), "<", "", "", "", "", "", "", "");
                     }
                     else if ( AV26DynamicFiltersOperator2 == 1 )
                     {
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", context.GetMessage( "Proveedor Id", ""), "=", "", "", "", "", "", "", "");
                     }
                     else if ( AV26DynamicFiltersOperator2 == 2 )
                     {
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", context.GetMessage( "Proveedor Id", ""), ">", "", "", "", "", "", "", "");
                     }
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Italic = 1;
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Number = AV27PostulacionesProveedorId2;
                  }
               }
               else if ( StringUtil.StrCmp(AV25DynamicFiltersSelector2, "SERVICIOSNOMBRE") == 0 )
               {
                  AV26DynamicFiltersOperator2 = AV34GridStateDynamicFilter.gxTpr_Operator;
                  AV28ServiciosNombre2 = AV34GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV28ServiciosNombre2)) )
                  {
                     AV14CellRow = (int)(AV14CellRow+1);
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Bold = 1;
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Color = 3;
                     if ( AV26DynamicFiltersOperator2 == 0 )
                     {
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", context.GetMessage( "Servicios Nombre", ""), context.GetMessage( "WWP_FilterLike", ""), "", "", "", "", "", "", "");
                     }
                     else if ( AV26DynamicFiltersOperator2 == 1 )
                     {
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", context.GetMessage( "Servicios Nombre", ""), context.GetMessage( "WWP_FilterContains", ""), "", "", "", "", "", "", "");
                     }
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Italic = 1;
                     GXt_char2 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV28ServiciosNombre2, out  GXt_char2) ;
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
                  }
               }
               if ( AV37GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV29DynamicFiltersEnabled3 = true;
                  AV34GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV37GridState.gxTpr_Dynamicfilters.Item(3));
                  AV30DynamicFiltersSelector3 = AV34GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV30DynamicFiltersSelector3, "POSTULACIONESPROVEEDORNOMBRE") == 0 )
                  {
                     AV31DynamicFiltersOperator3 = AV34GridStateDynamicFilter.gxTpr_Operator;
                     AV95PostulacionesProveedorNombre3 = AV34GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV95PostulacionesProveedorNombre3)) )
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
                        new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV95PostulacionesProveedorNombre3, out  GXt_char2) ;
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
                     }
                  }
                  else if ( StringUtil.StrCmp(AV30DynamicFiltersSelector3, "POSTULACIONESPROVEEDORID") == 0 )
                  {
                     AV31DynamicFiltersOperator3 = AV34GridStateDynamicFilter.gxTpr_Operator;
                     AV32PostulacionesProveedorId3 = (long)(Math.Round(NumberUtil.Val( AV34GridStateDynamicFilter.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
                     if ( ! (0==AV32PostulacionesProveedorId3) )
                     {
                        AV14CellRow = (int)(AV14CellRow+1);
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Bold = 1;
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Color = 3;
                        if ( AV31DynamicFiltersOperator3 == 0 )
                        {
                           AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", context.GetMessage( "Proveedor Id", ""), "<", "", "", "", "", "", "", "");
                        }
                        else if ( AV31DynamicFiltersOperator3 == 1 )
                        {
                           AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", context.GetMessage( "Proveedor Id", ""), "=", "", "", "", "", "", "", "");
                        }
                        else if ( AV31DynamicFiltersOperator3 == 2 )
                        {
                           AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", context.GetMessage( "Proveedor Id", ""), ">", "", "", "", "", "", "", "");
                        }
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Italic = 1;
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Number = AV32PostulacionesProveedorId3;
                     }
                  }
                  else if ( StringUtil.StrCmp(AV30DynamicFiltersSelector3, "SERVICIOSNOMBRE") == 0 )
                  {
                     AV31DynamicFiltersOperator3 = AV34GridStateDynamicFilter.gxTpr_Operator;
                     AV33ServiciosNombre3 = AV34GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV33ServiciosNombre3)) )
                     {
                        AV14CellRow = (int)(AV14CellRow+1);
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Bold = 1;
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Color = 3;
                        if ( AV31DynamicFiltersOperator3 == 0 )
                        {
                           AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", context.GetMessage( "Servicios Nombre", ""), context.GetMessage( "WWP_FilterLike", ""), "", "", "", "", "", "", "");
                        }
                        else if ( AV31DynamicFiltersOperator3 == 1 )
                        {
                           AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", context.GetMessage( "Servicios Nombre", ""), context.GetMessage( "WWP_FilterContains", ""), "", "", "", "", "", "", "");
                        }
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Italic = 1;
                        GXt_char2 = "";
                        new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV33ServiciosNombre3, out  GXt_char2) ;
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
                     }
                  }
               }
            }
         }
         if ( ! ( (0==AV50TFPostulacionesId) && (0==AV51TFPostulacionesId_To) ) )
         {
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Id", "")) ;
            AV14CellRow = GXt_int3;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Number = AV50TFPostulacionesId;
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  false, ref  GXt_int3,  (short)(AV15FirstColumn+2),  context.GetMessage( "WWP_TSTo", "")) ;
            AV14CellRow = GXt_int3;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+3, 1, 1).Number = AV51TFPostulacionesId_To;
         }
         if ( ! ( (0==AV52TFServiciosId) && (0==AV53TFServiciosId_To) ) )
         {
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Id", "")) ;
            AV14CellRow = GXt_int3;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Number = AV52TFServiciosId;
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  false, ref  GXt_int3,  (short)(AV15FirstColumn+2),  context.GetMessage( "WWP_TSTo", "")) ;
            AV14CellRow = GXt_int3;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+3, 1, 1).Number = AV53TFServiciosId_To;
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV55TFServiciosNombre_Sel)) ) )
         {
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Nombre", "")) ;
            AV14CellRow = GXt_int3;
            GXt_char2 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV55TFServiciosNombre_Sel)) ? context.GetMessage( "WWP_TitleFilter_EmptyOption", "") : AV55TFServiciosNombre_Sel), out  GXt_char2) ;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV54TFServiciosNombre)) ) )
            {
               GXt_int3 = (short)(AV14CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Nombre", "")) ;
               AV14CellRow = GXt_int3;
               GXt_char2 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV54TFServiciosNombre, out  GXt_char2) ;
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
            }
         }
         if ( ! ( (0==AV56TFPostulacionesProveedorId) && (0==AV57TFPostulacionesProveedorId_To) ) )
         {
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Proveedor Id", "")) ;
            AV14CellRow = GXt_int3;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Number = AV56TFPostulacionesProveedorId;
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  false, ref  GXt_int3,  (short)(AV15FirstColumn+2),  context.GetMessage( "WWP_TSTo", "")) ;
            AV14CellRow = GXt_int3;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+3, 1, 1).Number = AV57TFPostulacionesProveedorId_To;
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV90TFPostulacionesProveedorNombre_Sel)) ) )
         {
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Proveedor Nombre", "")) ;
            AV14CellRow = GXt_int3;
            GXt_char2 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV90TFPostulacionesProveedorNombre_Sel)) ? context.GetMessage( "WWP_TitleFilter_EmptyOption", "") : AV90TFPostulacionesProveedorNombre_Sel), out  GXt_char2) ;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV89TFPostulacionesProveedorNombre)) ) )
            {
               GXt_int3 = (short)(AV14CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Proveedor Nombre", "")) ;
               AV14CellRow = GXt_int3;
               GXt_char2 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV89TFPostulacionesProveedorNombre, out  GXt_char2) ;
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
            }
         }
         if ( ! ( (Convert.ToDecimal(0)==AV58TFPostulacionesPrecio) && (Convert.ToDecimal(0)==AV59TFPostulacionesPrecio_To) ) )
         {
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Precio", "")) ;
            AV14CellRow = GXt_int3;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Number = (double)(AV58TFPostulacionesPrecio);
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  false, ref  GXt_int3,  (short)(AV15FirstColumn+2),  context.GetMessage( "WWP_TSTo", "")) ;
            AV14CellRow = GXt_int3;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+3, 1, 1).Number = (double)(AV59TFPostulacionesPrecio_To);
         }
         if ( ! ( (0==AV91TFPostulacionesMultimediaSerial) && (0==AV92TFPostulacionesMultimediaSerial_To) ) )
         {
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Multimedia Serial", "")) ;
            AV14CellRow = GXt_int3;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Number = AV91TFPostulacionesMultimediaSerial;
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  false, ref  GXt_int3,  (short)(AV15FirstColumn+2),  context.GetMessage( "WWP_TSTo", "")) ;
            AV14CellRow = GXt_int3;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+3, 1, 1).Number = AV92TFPostulacionesMultimediaSerial_To;
         }
         if ( ! ( (0==AV96TFPostulacionesSolicitudesId) && (0==AV97TFPostulacionesSolicitudesId_To) ) )
         {
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Solicitudes Id", "")) ;
            AV14CellRow = GXt_int3;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Number = AV96TFPostulacionesSolicitudesId;
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  false, ref  GXt_int3,  (short)(AV15FirstColumn+2),  context.GetMessage( "WWP_TSTo", "")) ;
            AV14CellRow = GXt_int3;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+3, 1, 1).Number = AV97TFPostulacionesSolicitudesId_To;
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV61TFPostulacionesDescripcion_Sel)) ) )
         {
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Descripcion", "")) ;
            AV14CellRow = GXt_int3;
            GXt_char2 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV61TFPostulacionesDescripcion_Sel)) ? context.GetMessage( "WWP_TitleFilter_EmptyOption", "") : AV61TFPostulacionesDescripcion_Sel), out  GXt_char2) ;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV60TFPostulacionesDescripcion)) ) )
            {
               GXt_int3 = (short)(AV14CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Descripcion", "")) ;
               AV14CellRow = GXt_int3;
               GXt_char2 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV60TFPostulacionesDescripcion, out  GXt_char2) ;
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
            }
         }
         if ( ! ( (0==AV62TFPostulacionesReqSuministros_Sel) ) )
         {
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Req Suministros", "")) ;
            AV14CellRow = GXt_int3;
            if ( AV62TFPostulacionesReqSuministros_Sel == 1 )
            {
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = context.GetMessage( "WWP_TSChecked", "");
            }
            else if ( AV62TFPostulacionesReqSuministros_Sel == 2 )
            {
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = context.GetMessage( "WWP_TSUnChecked", "");
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV64TFPostulacionesSuministrosDescripcion_Sel)) ) )
         {
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Suministros Descripcion", "")) ;
            AV14CellRow = GXt_int3;
            GXt_char2 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV64TFPostulacionesSuministrosDescripcion_Sel)) ? context.GetMessage( "WWP_TitleFilter_EmptyOption", "") : AV64TFPostulacionesSuministrosDescripcion_Sel), out  GXt_char2) ;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV63TFPostulacionesSuministrosDescripcion)) ) )
            {
               GXt_int3 = (short)(AV14CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Suministros Descripcion", "")) ;
               AV14CellRow = GXt_int3;
               GXt_char2 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV63TFPostulacionesSuministrosDescripcion, out  GXt_char2) ;
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
            }
         }
         if ( ! ( (DateTime.MinValue==AV65TFPostulacionesFechaTrabajo) && (DateTime.MinValue==AV66TFPostulacionesFechaTrabajo_To) ) )
         {
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Fecha Trabajo", "")) ;
            AV14CellRow = GXt_int3;
            GXt_dtime4 = DateTimeUtil.ResetTime( AV65TFPostulacionesFechaTrabajo ) ;
            AV11ExcelDocument.SetDateFormat(context, 8, 5, ((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0), DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt")), "/", ":", " ");
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Date = GXt_dtime4;
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  false, ref  GXt_int3,  (short)(AV15FirstColumn+2),  context.GetMessage( "WWP_TSTo", "")) ;
            AV14CellRow = GXt_int3;
            GXt_dtime4 = DateTimeUtil.ResetTime( AV66TFPostulacionesFechaTrabajo_To ) ;
            AV11ExcelDocument.SetDateFormat(context, 8, 5, ((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0), DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt")), "/", ":", " ");
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+3, 1, 1).Date = GXt_dtime4;
         }
         if ( ! ( (DateTime.MinValue==AV67TFPostulacionesFechaCierre) && (DateTime.MinValue==AV68TFPostulacionesFechaCierre_To) ) )
         {
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Fecha Cierre", "")) ;
            AV14CellRow = GXt_int3;
            GXt_dtime4 = DateTimeUtil.ResetTime( AV67TFPostulacionesFechaCierre ) ;
            AV11ExcelDocument.SetDateFormat(context, 8, 5, ((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0), DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt")), "/", ":", " ");
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Date = GXt_dtime4;
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  false, ref  GXt_int3,  (short)(AV15FirstColumn+2),  context.GetMessage( "WWP_TSTo", "")) ;
            AV14CellRow = GXt_int3;
            GXt_dtime4 = DateTimeUtil.ResetTime( AV68TFPostulacionesFechaCierre_To ) ;
            AV11ExcelDocument.SetDateFormat(context, 8, 5, ((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0), DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt")), "/", ":", " ");
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+3, 1, 1).Date = GXt_dtime4;
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV70TFPostulacionesHoraCierre_Sel)) ) )
         {
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Hora Cierre", "")) ;
            AV14CellRow = GXt_int3;
            GXt_char2 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV70TFPostulacionesHoraCierre_Sel)) ? context.GetMessage( "WWP_TitleFilter_EmptyOption", "") : AV70TFPostulacionesHoraCierre_Sel), out  GXt_char2) ;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV69TFPostulacionesHoraCierre)) ) )
            {
               GXt_int3 = (short)(AV14CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Hora Cierre", "")) ;
               AV14CellRow = GXt_int3;
               GXt_char2 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV69TFPostulacionesHoraCierre, out  GXt_char2) ;
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV107TFPostulacionesTipoFecha_Sel)) ) )
         {
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Tipo Fecha", "")) ;
            AV14CellRow = GXt_int3;
            GXt_char2 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV107TFPostulacionesTipoFecha_Sel)) ? context.GetMessage( "WWP_TitleFilter_EmptyOption", "") : AV107TFPostulacionesTipoFecha_Sel), out  GXt_char2) ;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV71TFPostulacionesTipoFecha)) ) )
            {
               GXt_int3 = (short)(AV14CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Tipo Fecha", "")) ;
               AV14CellRow = GXt_int3;
               GXt_char2 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV71TFPostulacionesTipoFecha, out  GXt_char2) ;
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV74TFPostulacionesRgoHoraservicio_Sel)) ) )
         {
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Rgo Horaservicio", "")) ;
            AV14CellRow = GXt_int3;
            GXt_char2 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV74TFPostulacionesRgoHoraservicio_Sel)) ? context.GetMessage( "WWP_TitleFilter_EmptyOption", "") : AV74TFPostulacionesRgoHoraservicio_Sel), out  GXt_char2) ;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV73TFPostulacionesRgoHoraservicio)) ) )
            {
               GXt_int3 = (short)(AV14CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Rgo Horaservicio", "")) ;
               AV14CellRow = GXt_int3;
               GXt_char2 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV73TFPostulacionesRgoHoraservicio, out  GXt_char2) ;
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV76TFPostulacionesApellidoNombre_Sel)) ) )
         {
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Apellido Nombre", "")) ;
            AV14CellRow = GXt_int3;
            GXt_char2 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV76TFPostulacionesApellidoNombre_Sel)) ? context.GetMessage( "WWP_TitleFilter_EmptyOption", "") : AV76TFPostulacionesApellidoNombre_Sel), out  GXt_char2) ;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV75TFPostulacionesApellidoNombre)) ) )
            {
               GXt_int3 = (short)(AV14CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Apellido Nombre", "")) ;
               AV14CellRow = GXt_int3;
               GXt_char2 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV75TFPostulacionesApellidoNombre, out  GXt_char2) ;
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV78TFPostulacionesMail_Sel)) ) )
         {
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Mail", "")) ;
            AV14CellRow = GXt_int3;
            GXt_char2 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV78TFPostulacionesMail_Sel)) ? context.GetMessage( "WWP_TitleFilter_EmptyOption", "") : AV78TFPostulacionesMail_Sel), out  GXt_char2) ;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV77TFPostulacionesMail)) ) )
            {
               GXt_int3 = (short)(AV14CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Mail", "")) ;
               AV14CellRow = GXt_int3;
               GXt_char2 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV77TFPostulacionesMail, out  GXt_char2) ;
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV80TFPostulacionesTelefono_Sel)) ) )
         {
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Telefono", "")) ;
            AV14CellRow = GXt_int3;
            GXt_char2 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV80TFPostulacionesTelefono_Sel)) ? context.GetMessage( "WWP_TitleFilter_EmptyOption", "") : AV80TFPostulacionesTelefono_Sel), out  GXt_char2) ;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV79TFPostulacionesTelefono)) ) )
            {
               GXt_int3 = (short)(AV14CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Telefono", "")) ;
               AV14CellRow = GXt_int3;
               GXt_char2 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV79TFPostulacionesTelefono, out  GXt_char2) ;
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
            }
         }
         if ( ! ( (DateTime.MinValue==AV81TFPostulacionesFechaAlta) && (DateTime.MinValue==AV82TFPostulacionesFechaAlta_To) ) )
         {
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Fecha", "")) ;
            AV14CellRow = GXt_int3;
            AV11ExcelDocument.SetDateFormat(context, 8, 5, ((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0), DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt")), "/", ":", " ");
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Date = AV81TFPostulacionesFechaAlta;
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  false, ref  GXt_int3,  (short)(AV15FirstColumn+2),  context.GetMessage( "WWP_TSTo", "")) ;
            AV14CellRow = GXt_int3;
            AV11ExcelDocument.SetDateFormat(context, 8, 5, ((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0), DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt")), "/", ":", " ");
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+3, 1, 1).Date = AV82TFPostulacionesFechaAlta_To;
         }
         if ( ! ( ( AV85TFPostulacionesEstado_Sels.Count == 0 ) ) )
         {
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Estado", "")) ;
            AV14CellRow = GXt_int3;
            AV88i = 1;
            AV109GXV1 = 1;
            while ( AV109GXV1 <= AV85TFPostulacionesEstado_Sels.Count )
            {
               AV84TFPostulacionesEstado_Sel = AV85TFPostulacionesEstado_Sels.GetString(AV109GXV1);
               if ( AV88i == 1 )
               {
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = "";
               }
               else
               {
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text+", ";
               }
               if ( StringUtil.StrCmp(StringUtil.Trim( AV84TFPostulacionesEstado_Sel), context.GetMessage( "HAB", "")) == 0 )
               {
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text+context.GetMessage( "Habilitado", "");
               }
               else if ( StringUtil.StrCmp(StringUtil.Trim( AV84TFPostulacionesEstado_Sel), context.GetMessage( "DES", "")) == 0 )
               {
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text+context.GetMessage( "Deshabilitado", "");
               }
               else if ( StringUtil.StrCmp(StringUtil.Trim( AV84TFPostulacionesEstado_Sel), context.GetMessage( "GAN", "")) == 0 )
               {
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text+context.GetMessage( "Ganador", "");
               }
               AV88i = (long)(AV88i+1);
               AV109GXV1 = (int)(AV109GXV1+1);
            }
         }
         if ( ! ( (0==AV86TFPostulacionesSecUserId) && (0==AV87TFPostulacionesSecUserId_To) ) )
         {
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "User Id", "")) ;
            AV14CellRow = GXt_int3;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Number = AV86TFPostulacionesSecUserId;
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  false, ref  GXt_int3,  (short)(AV15FirstColumn+2),  context.GetMessage( "WWP_TSTo", "")) ;
            AV14CellRow = GXt_int3;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+3, 1, 1).Number = AV87TFPostulacionesSecUserId_To;
         }
         AV14CellRow = (int)(AV14CellRow+2);
      }

      protected void S141( )
      {
         /* 'WRITECOLUMNTITLES' Routine */
         returnInSub = false;
         AV47VisibleColumnCount = 0;
         if ( StringUtil.StrCmp(AV35Session.Get("PostulacionesWWColumnsSelector"), "") != 0 )
         {
            AV42ColumnsSelectorXML = AV35Session.Get("PostulacionesWWColumnsSelector");
            AV39ColumnsSelector.FromXml(AV42ColumnsSelectorXML, null, "", "");
         }
         else
         {
            /* Execute user subroutine: 'INITIALIZECOLUMNSSELECTOR' */
            S151 ();
            if (returnInSub) return;
         }
         AV39ColumnsSelector.gxTpr_Columns.Sort("Order");
         AV110GXV2 = 1;
         while ( AV110GXV2 <= AV39ColumnsSelector.gxTpr_Columns.Count )
         {
            AV41ColumnsSelector_Column = ((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV39ColumnsSelector.gxTpr_Columns.Item(AV110GXV2));
            if ( AV41ColumnsSelector_Column.gxTpr_Isvisible )
            {
               AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV47VisibleColumnCount), 1, 1).Text = context.GetMessage( (String.IsNullOrEmpty(StringUtil.RTrim( AV41ColumnsSelector_Column.gxTpr_Displayname)) ? AV41ColumnsSelector_Column.gxTpr_Columnname : AV41ColumnsSelector_Column.gxTpr_Displayname), "");
               AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV47VisibleColumnCount), 1, 1).Bold = 1;
               AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV47VisibleColumnCount), 1, 1).Color = 11;
               AV47VisibleColumnCount = (long)(AV47VisibleColumnCount+1);
            }
            AV110GXV2 = (int)(AV110GXV2+1);
         }
      }

      protected void S161( )
      {
         /* 'WRITEDATA' Routine */
         returnInSub = false;
         AV112Postulacioneswwds_1_filterfulltext = AV19FilterFullText;
         AV113Postulacioneswwds_2_dynamicfiltersselector1 = AV20DynamicFiltersSelector1;
         AV114Postulacioneswwds_3_dynamicfiltersoperator1 = AV21DynamicFiltersOperator1;
         AV115Postulacioneswwds_4_postulacionesproveedornombre1 = AV93PostulacionesProveedorNombre1;
         AV116Postulacioneswwds_5_postulacionesproveedorid1 = AV22PostulacionesProveedorId1;
         AV117Postulacioneswwds_6_serviciosnombre1 = AV23ServiciosNombre1;
         AV118Postulacioneswwds_7_dynamicfiltersenabled2 = AV24DynamicFiltersEnabled2;
         AV119Postulacioneswwds_8_dynamicfiltersselector2 = AV25DynamicFiltersSelector2;
         AV120Postulacioneswwds_9_dynamicfiltersoperator2 = AV26DynamicFiltersOperator2;
         AV121Postulacioneswwds_10_postulacionesproveedornombre2 = AV94PostulacionesProveedorNombre2;
         AV122Postulacioneswwds_11_postulacionesproveedorid2 = AV27PostulacionesProveedorId2;
         AV123Postulacioneswwds_12_serviciosnombre2 = AV28ServiciosNombre2;
         AV124Postulacioneswwds_13_dynamicfiltersenabled3 = AV29DynamicFiltersEnabled3;
         AV125Postulacioneswwds_14_dynamicfiltersselector3 = AV30DynamicFiltersSelector3;
         AV126Postulacioneswwds_15_dynamicfiltersoperator3 = AV31DynamicFiltersOperator3;
         AV127Postulacioneswwds_16_postulacionesproveedornombre3 = AV95PostulacionesProveedorNombre3;
         AV128Postulacioneswwds_17_postulacionesproveedorid3 = AV32PostulacionesProveedorId3;
         AV129Postulacioneswwds_18_serviciosnombre3 = AV33ServiciosNombre3;
         AV130Postulacioneswwds_19_tfpostulacionesid = AV50TFPostulacionesId;
         AV131Postulacioneswwds_20_tfpostulacionesid_to = AV51TFPostulacionesId_To;
         AV132Postulacioneswwds_21_tfserviciosid = AV52TFServiciosId;
         AV133Postulacioneswwds_22_tfserviciosid_to = AV53TFServiciosId_To;
         AV134Postulacioneswwds_23_tfserviciosnombre = AV54TFServiciosNombre;
         AV135Postulacioneswwds_24_tfserviciosnombre_sel = AV55TFServiciosNombre_Sel;
         AV136Postulacioneswwds_25_tfpostulacionesproveedorid = AV56TFPostulacionesProveedorId;
         AV137Postulacioneswwds_26_tfpostulacionesproveedorid_to = AV57TFPostulacionesProveedorId_To;
         AV138Postulacioneswwds_27_tfpostulacionesproveedornombre = AV89TFPostulacionesProveedorNombre;
         AV139Postulacioneswwds_28_tfpostulacionesproveedornombre_sel = AV90TFPostulacionesProveedorNombre_Sel;
         AV140Postulacioneswwds_29_tfpostulacionesprecio = AV58TFPostulacionesPrecio;
         AV141Postulacioneswwds_30_tfpostulacionesprecio_to = AV59TFPostulacionesPrecio_To;
         AV142Postulacioneswwds_31_tfpostulacionesmultimediaserial = AV91TFPostulacionesMultimediaSerial;
         AV143Postulacioneswwds_32_tfpostulacionesmultimediaserial_to = AV92TFPostulacionesMultimediaSerial_To;
         AV144Postulacioneswwds_33_tfpostulacionessolicitudesid = AV96TFPostulacionesSolicitudesId;
         AV145Postulacioneswwds_34_tfpostulacionessolicitudesid_to = AV97TFPostulacionesSolicitudesId_To;
         AV146Postulacioneswwds_35_tfpostulacionesdescripcion = AV60TFPostulacionesDescripcion;
         AV147Postulacioneswwds_36_tfpostulacionesdescripcion_sel = AV61TFPostulacionesDescripcion_Sel;
         AV148Postulacioneswwds_37_tfpostulacionesreqsuministros_sel = AV62TFPostulacionesReqSuministros_Sel;
         AV149Postulacioneswwds_38_tfpostulacionessuministrosdescripcion = AV63TFPostulacionesSuministrosDescripcion;
         AV150Postulacioneswwds_39_tfpostulacionessuministrosdescripcion_sel = AV64TFPostulacionesSuministrosDescripcion_Sel;
         AV151Postulacioneswwds_40_tfpostulacionesfechatrabajo = AV65TFPostulacionesFechaTrabajo;
         AV152Postulacioneswwds_41_tfpostulacionesfechatrabajo_to = AV66TFPostulacionesFechaTrabajo_To;
         AV153Postulacioneswwds_42_tfpostulacionesfechacierre = AV67TFPostulacionesFechaCierre;
         AV154Postulacioneswwds_43_tfpostulacionesfechacierre_to = AV68TFPostulacionesFechaCierre_To;
         AV155Postulacioneswwds_44_tfpostulacioneshoracierre = AV69TFPostulacionesHoraCierre;
         AV156Postulacioneswwds_45_tfpostulacioneshoracierre_sel = AV70TFPostulacionesHoraCierre_Sel;
         AV157Postulacioneswwds_46_tfpostulacionestipofecha = AV71TFPostulacionesTipoFecha;
         AV158Postulacioneswwds_47_tfpostulacionestipofecha_sel = AV107TFPostulacionesTipoFecha_Sel;
         AV159Postulacioneswwds_48_tfpostulacionesrgohoraservicio = AV73TFPostulacionesRgoHoraservicio;
         AV160Postulacioneswwds_49_tfpostulacionesrgohoraservicio_sel = AV74TFPostulacionesRgoHoraservicio_Sel;
         AV161Postulacioneswwds_50_tfpostulacionesapellidonombre = AV75TFPostulacionesApellidoNombre;
         AV162Postulacioneswwds_51_tfpostulacionesapellidonombre_sel = AV76TFPostulacionesApellidoNombre_Sel;
         AV163Postulacioneswwds_52_tfpostulacionesmail = AV77TFPostulacionesMail;
         AV164Postulacioneswwds_53_tfpostulacionesmail_sel = AV78TFPostulacionesMail_Sel;
         AV165Postulacioneswwds_54_tfpostulacionestelefono = AV79TFPostulacionesTelefono;
         AV166Postulacioneswwds_55_tfpostulacionestelefono_sel = AV80TFPostulacionesTelefono_Sel;
         AV167Postulacioneswwds_56_tfpostulacionesfechaalta = AV81TFPostulacionesFechaAlta;
         AV168Postulacioneswwds_57_tfpostulacionesfechaalta_to = AV82TFPostulacionesFechaAlta_To;
         AV169Postulacioneswwds_58_tfpostulacionesestado_sels = AV85TFPostulacionesEstado_Sels;
         AV170Postulacioneswwds_59_tfpostulacionessecuserid = AV86TFPostulacionesSecUserId;
         AV171Postulacioneswwds_60_tfpostulacionessecuserid_to = AV87TFPostulacionesSecUserId_To;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A424PostulacionesEstado ,
                                              AV169Postulacioneswwds_58_tfpostulacionesestado_sels ,
                                              AV113Postulacioneswwds_2_dynamicfiltersselector1 ,
                                              AV114Postulacioneswwds_3_dynamicfiltersoperator1 ,
                                              AV115Postulacioneswwds_4_postulacionesproveedornombre1 ,
                                              AV116Postulacioneswwds_5_postulacionesproveedorid1 ,
                                              AV117Postulacioneswwds_6_serviciosnombre1 ,
                                              AV118Postulacioneswwds_7_dynamicfiltersenabled2 ,
                                              AV119Postulacioneswwds_8_dynamicfiltersselector2 ,
                                              AV120Postulacioneswwds_9_dynamicfiltersoperator2 ,
                                              AV121Postulacioneswwds_10_postulacionesproveedornombre2 ,
                                              AV122Postulacioneswwds_11_postulacionesproveedorid2 ,
                                              AV123Postulacioneswwds_12_serviciosnombre2 ,
                                              AV124Postulacioneswwds_13_dynamicfiltersenabled3 ,
                                              AV125Postulacioneswwds_14_dynamicfiltersselector3 ,
                                              AV126Postulacioneswwds_15_dynamicfiltersoperator3 ,
                                              AV127Postulacioneswwds_16_postulacionesproveedornombre3 ,
                                              AV128Postulacioneswwds_17_postulacionesproveedorid3 ,
                                              AV129Postulacioneswwds_18_serviciosnombre3 ,
                                              AV130Postulacioneswwds_19_tfpostulacionesid ,
                                              AV131Postulacioneswwds_20_tfpostulacionesid_to ,
                                              AV132Postulacioneswwds_21_tfserviciosid ,
                                              AV133Postulacioneswwds_22_tfserviciosid_to ,
                                              AV135Postulacioneswwds_24_tfserviciosnombre_sel ,
                                              AV134Postulacioneswwds_23_tfserviciosnombre ,
                                              AV136Postulacioneswwds_25_tfpostulacionesproveedorid ,
                                              AV137Postulacioneswwds_26_tfpostulacionesproveedorid_to ,
                                              AV139Postulacioneswwds_28_tfpostulacionesproveedornombre_sel ,
                                              AV138Postulacioneswwds_27_tfpostulacionesproveedornombre ,
                                              AV140Postulacioneswwds_29_tfpostulacionesprecio ,
                                              AV141Postulacioneswwds_30_tfpostulacionesprecio_to ,
                                              AV142Postulacioneswwds_31_tfpostulacionesmultimediaserial ,
                                              AV143Postulacioneswwds_32_tfpostulacionesmultimediaserial_to ,
                                              AV147Postulacioneswwds_36_tfpostulacionesdescripcion_sel ,
                                              AV146Postulacioneswwds_35_tfpostulacionesdescripcion ,
                                              AV148Postulacioneswwds_37_tfpostulacionesreqsuministros_sel ,
                                              AV150Postulacioneswwds_39_tfpostulacionessuministrosdescripcion_sel ,
                                              AV149Postulacioneswwds_38_tfpostulacionessuministrosdescripcion ,
                                              AV151Postulacioneswwds_40_tfpostulacionesfechatrabajo ,
                                              AV152Postulacioneswwds_41_tfpostulacionesfechatrabajo_to ,
                                              AV153Postulacioneswwds_42_tfpostulacionesfechacierre ,
                                              AV154Postulacioneswwds_43_tfpostulacionesfechacierre_to ,
                                              AV156Postulacioneswwds_45_tfpostulacioneshoracierre_sel ,
                                              AV155Postulacioneswwds_44_tfpostulacioneshoracierre ,
                                              AV158Postulacioneswwds_47_tfpostulacionestipofecha_sel ,
                                              AV157Postulacioneswwds_46_tfpostulacionestipofecha ,
                                              AV160Postulacioneswwds_49_tfpostulacionesrgohoraservicio_sel ,
                                              AV159Postulacioneswwds_48_tfpostulacionesrgohoraservicio ,
                                              AV162Postulacioneswwds_51_tfpostulacionesapellidonombre_sel ,
                                              AV161Postulacioneswwds_50_tfpostulacionesapellidonombre ,
                                              AV164Postulacioneswwds_53_tfpostulacionesmail_sel ,
                                              AV163Postulacioneswwds_52_tfpostulacionesmail ,
                                              AV166Postulacioneswwds_55_tfpostulacionestelefono_sel ,
                                              AV165Postulacioneswwds_54_tfpostulacionestelefono ,
                                              AV167Postulacioneswwds_56_tfpostulacionesfechaalta ,
                                              AV168Postulacioneswwds_57_tfpostulacionesfechaalta_to ,
                                              AV169Postulacioneswwds_58_tfpostulacionesestado_sels.Count ,
                                              AV170Postulacioneswwds_59_tfpostulacionessecuserid ,
                                              AV171Postulacioneswwds_60_tfpostulacionessecuserid_to ,
                                              A969PostulacionesProveedorNombre ,
                                              A945PostulacionesProveedorId ,
                                              A943ServiciosNombre ,
                                              A422PostulacionesId ,
                                              A942ServiciosId ,
                                              A946PostulacionesPrecio ,
                                              A961PostulacionesMultimediaSerial ,
                                              A936PostulacionesDescripcion ,
                                              A937PostulacionesReqSuministros ,
                                              A938PostulacionesSuministrosDescri ,
                                              A947PostulacionesFechaTrabajo ,
                                              A939PostulacionesFechaCierre ,
                                              A940PostulacionesHoraCierre ,
                                              A941PostulacionesTipoFecha ,
                                              A949PostulacionesRgoHoraservicio ,
                                              A950PostulacionesApellidoNombre ,
                                              A951PostulacionesMail ,
                                              A952PostulacionesTelefono ,
                                              A425PostulacionesFechaAlta ,
                                              A948PostulacionesSecUserId ,
                                              AV17OrderedBy ,
                                              AV18OrderedDsc ,
                                              AV112Postulacioneswwds_1_filterfulltext ,
                                              A970PostulacionesSolicitudesId ,
                                              AV144Postulacioneswwds_33_tfpostulacionessolicitudesid ,
                                              AV145Postulacioneswwds_34_tfpostulacionessolicitudesid_to } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG,
                                              TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.DATE,
                                              TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.INT, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG,
                                              TypeConstants.BOOLEAN, TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.LONG,
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.LONG, TypeConstants.LONG
                                              }
         });
         lV115Postulacioneswwds_4_postulacionesproveedornombre1 = StringUtil.PadR( StringUtil.RTrim( AV115Postulacioneswwds_4_postulacionesproveedornombre1), 80, "%");
         lV115Postulacioneswwds_4_postulacionesproveedornombre1 = StringUtil.PadR( StringUtil.RTrim( AV115Postulacioneswwds_4_postulacionesproveedornombre1), 80, "%");
         lV117Postulacioneswwds_6_serviciosnombre1 = StringUtil.PadR( StringUtil.RTrim( AV117Postulacioneswwds_6_serviciosnombre1), 80, "%");
         lV117Postulacioneswwds_6_serviciosnombre1 = StringUtil.PadR( StringUtil.RTrim( AV117Postulacioneswwds_6_serviciosnombre1), 80, "%");
         lV121Postulacioneswwds_10_postulacionesproveedornombre2 = StringUtil.PadR( StringUtil.RTrim( AV121Postulacioneswwds_10_postulacionesproveedornombre2), 80, "%");
         lV121Postulacioneswwds_10_postulacionesproveedornombre2 = StringUtil.PadR( StringUtil.RTrim( AV121Postulacioneswwds_10_postulacionesproveedornombre2), 80, "%");
         lV123Postulacioneswwds_12_serviciosnombre2 = StringUtil.PadR( StringUtil.RTrim( AV123Postulacioneswwds_12_serviciosnombre2), 80, "%");
         lV123Postulacioneswwds_12_serviciosnombre2 = StringUtil.PadR( StringUtil.RTrim( AV123Postulacioneswwds_12_serviciosnombre2), 80, "%");
         lV127Postulacioneswwds_16_postulacionesproveedornombre3 = StringUtil.PadR( StringUtil.RTrim( AV127Postulacioneswwds_16_postulacionesproveedornombre3), 80, "%");
         lV127Postulacioneswwds_16_postulacionesproveedornombre3 = StringUtil.PadR( StringUtil.RTrim( AV127Postulacioneswwds_16_postulacionesproveedornombre3), 80, "%");
         lV129Postulacioneswwds_18_serviciosnombre3 = StringUtil.PadR( StringUtil.RTrim( AV129Postulacioneswwds_18_serviciosnombre3), 80, "%");
         lV129Postulacioneswwds_18_serviciosnombre3 = StringUtil.PadR( StringUtil.RTrim( AV129Postulacioneswwds_18_serviciosnombre3), 80, "%");
         lV134Postulacioneswwds_23_tfserviciosnombre = StringUtil.PadR( StringUtil.RTrim( AV134Postulacioneswwds_23_tfserviciosnombre), 80, "%");
         lV138Postulacioneswwds_27_tfpostulacionesproveedornombre = StringUtil.PadR( StringUtil.RTrim( AV138Postulacioneswwds_27_tfpostulacionesproveedornombre), 80, "%");
         lV146Postulacioneswwds_35_tfpostulacionesdescripcion = StringUtil.PadR( StringUtil.RTrim( AV146Postulacioneswwds_35_tfpostulacionesdescripcion), 2000, "%");
         lV149Postulacioneswwds_38_tfpostulacionessuministrosdescripcion = StringUtil.PadR( StringUtil.RTrim( AV149Postulacioneswwds_38_tfpostulacionessuministrosdescripcion), 250, "%");
         lV155Postulacioneswwds_44_tfpostulacioneshoracierre = StringUtil.Concat( StringUtil.RTrim( AV155Postulacioneswwds_44_tfpostulacioneshoracierre), "%", "");
         lV157Postulacioneswwds_46_tfpostulacionestipofecha = StringUtil.Concat( StringUtil.RTrim( AV157Postulacioneswwds_46_tfpostulacionestipofecha), "%", "");
         lV159Postulacioneswwds_48_tfpostulacionesrgohoraservicio = StringUtil.PadR( StringUtil.RTrim( AV159Postulacioneswwds_48_tfpostulacionesrgohoraservicio), 5, "%");
         lV161Postulacioneswwds_50_tfpostulacionesapellidonombre = StringUtil.PadR( StringUtil.RTrim( AV161Postulacioneswwds_50_tfpostulacionesapellidonombre), 80, "%");
         lV163Postulacioneswwds_52_tfpostulacionesmail = StringUtil.Concat( StringUtil.RTrim( AV163Postulacioneswwds_52_tfpostulacionesmail), "%", "");
         lV165Postulacioneswwds_54_tfpostulacionestelefono = StringUtil.PadR( StringUtil.RTrim( AV165Postulacioneswwds_54_tfpostulacionestelefono), 20, "%");
         /* Using cursor P00LB3 */
         pr_default.execute(0, new Object[] {n422PostulacionesId, A422PostulacionesId, AV144Postulacioneswwds_33_tfpostulacionessolicitudesid, AV144Postulacioneswwds_33_tfpostulacionessolicitudesid, AV145Postulacioneswwds_34_tfpostulacionessolicitudesid_to, AV145Postulacioneswwds_34_tfpostulacionessolicitudesid_to, lV115Postulacioneswwds_4_postulacionesproveedornombre1, lV115Postulacioneswwds_4_postulacionesproveedornombre1, AV116Postulacioneswwds_5_postulacionesproveedorid1, AV116Postulacioneswwds_5_postulacionesproveedorid1, AV116Postulacioneswwds_5_postulacionesproveedorid1, lV117Postulacioneswwds_6_serviciosnombre1, lV117Postulacioneswwds_6_serviciosnombre1, lV121Postulacioneswwds_10_postulacionesproveedornombre2, lV121Postulacioneswwds_10_postulacionesproveedornombre2, AV122Postulacioneswwds_11_postulacionesproveedorid2, AV122Postulacioneswwds_11_postulacionesproveedorid2, AV122Postulacioneswwds_11_postulacionesproveedorid2, lV123Postulacioneswwds_12_serviciosnombre2, lV123Postulacioneswwds_12_serviciosnombre2, lV127Postulacioneswwds_16_postulacionesproveedornombre3, lV127Postulacioneswwds_16_postulacionesproveedornombre3, AV128Postulacioneswwds_17_postulacionesproveedorid3, AV128Postulacioneswwds_17_postulacionesproveedorid3, AV128Postulacioneswwds_17_postulacionesproveedorid3, lV129Postulacioneswwds_18_serviciosnombre3, lV129Postulacioneswwds_18_serviciosnombre3, AV130Postulacioneswwds_19_tfpostulacionesid, AV131Postulacioneswwds_20_tfpostulacionesid_to, AV132Postulacioneswwds_21_tfserviciosid, AV133Postulacioneswwds_22_tfserviciosid_to, lV134Postulacioneswwds_23_tfserviciosnombre, AV135Postulacioneswwds_24_tfserviciosnombre_sel, AV136Postulacioneswwds_25_tfpostulacionesproveedorid, AV137Postulacioneswwds_26_tfpostulacionesproveedorid_to, lV138Postulacioneswwds_27_tfpostulacionesproveedornombre, AV139Postulacioneswwds_28_tfpostulacionesproveedornombre_sel, AV140Postulacioneswwds_29_tfpostulacionesprecio, AV141Postulacioneswwds_30_tfpostulacionesprecio_to, AV142Postulacioneswwds_31_tfpostulacionesmultimediaserial, AV143Postulacioneswwds_32_tfpostulacionesmultimediaserial_to, lV146Postulacioneswwds_35_tfpostulacionesdescripcion, AV147Postulacioneswwds_36_tfpostulacionesdescripcion_sel, lV149Postulacioneswwds_38_tfpostulacionessuministrosdescripcion, AV150Postulacioneswwds_39_tfpostulacionessuministrosdescripcion_sel, AV151Postulacioneswwds_40_tfpostulacionesfechatrabajo, AV152Postulacioneswwds_41_tfpostulacionesfechatrabajo_to, AV153Postulacioneswwds_42_tfpostulacionesfechacierre, AV154Postulacioneswwds_43_tfpostulacionesfechacierre_to, lV155Postulacioneswwds_44_tfpostulacioneshoracierre, AV156Postulacioneswwds_45_tfpostulacioneshoracierre_sel, lV157Postulacioneswwds_46_tfpostulacionestipofecha, AV158Postulacioneswwds_47_tfpostulacionestipofecha_sel, lV159Postulacioneswwds_48_tfpostulacionesrgohoraservicio, AV160Postulacioneswwds_49_tfpostulacionesrgohoraservicio_sel, lV161Postulacioneswwds_50_tfpostulacionesapellidonombre, AV162Postulacioneswwds_51_tfpostulacionesapellidonombre_sel, lV163Postulacioneswwds_52_tfpostulacionesmail, AV164Postulacioneswwds_53_tfpostulacionesmail_sel, lV165Postulacioneswwds_54_tfpostulacionestelefono, AV166Postulacioneswwds_55_tfpostulacionestelefono_sel, AV167Postulacioneswwds_56_tfpostulacionesfechaalta, AV168Postulacioneswwds_57_tfpostulacionesfechaalta_to, AV170Postulacioneswwds_59_tfpostulacionessecuserid, AV171Postulacioneswwds_60_tfpostulacionessecuserid_to});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A948PostulacionesSecUserId = P00LB3_A948PostulacionesSecUserId[0];
            A425PostulacionesFechaAlta = P00LB3_A425PostulacionesFechaAlta[0];
            A952PostulacionesTelefono = P00LB3_A952PostulacionesTelefono[0];
            A951PostulacionesMail = P00LB3_A951PostulacionesMail[0];
            A950PostulacionesApellidoNombre = P00LB3_A950PostulacionesApellidoNombre[0];
            A949PostulacionesRgoHoraservicio = P00LB3_A949PostulacionesRgoHoraservicio[0];
            A941PostulacionesTipoFecha = P00LB3_A941PostulacionesTipoFecha[0];
            A940PostulacionesHoraCierre = P00LB3_A940PostulacionesHoraCierre[0];
            A939PostulacionesFechaCierre = P00LB3_A939PostulacionesFechaCierre[0];
            A947PostulacionesFechaTrabajo = P00LB3_A947PostulacionesFechaTrabajo[0];
            A938PostulacionesSuministrosDescri = P00LB3_A938PostulacionesSuministrosDescri[0];
            A937PostulacionesReqSuministros = P00LB3_A937PostulacionesReqSuministros[0];
            A936PostulacionesDescripcion = P00LB3_A936PostulacionesDescripcion[0];
            A961PostulacionesMultimediaSerial = P00LB3_A961PostulacionesMultimediaSerial[0];
            A946PostulacionesPrecio = P00LB3_A946PostulacionesPrecio[0];
            A969PostulacionesProveedorNombre = P00LB3_A969PostulacionesProveedorNombre[0];
            A943ServiciosNombre = P00LB3_A943ServiciosNombre[0];
            A942ServiciosId = P00LB3_A942ServiciosId[0];
            n942ServiciosId = P00LB3_n942ServiciosId[0];
            A422PostulacionesId = P00LB3_A422PostulacionesId[0];
            n422PostulacionesId = P00LB3_n422PostulacionesId[0];
            A945PostulacionesProveedorId = P00LB3_A945PostulacionesProveedorId[0];
            A424PostulacionesEstado = P00LB3_A424PostulacionesEstado[0];
            A970PostulacionesSolicitudesId = P00LB3_A970PostulacionesSolicitudesId[0];
            n970PostulacionesSolicitudesId = P00LB3_n970PostulacionesSolicitudesId[0];
            A943ServiciosNombre = P00LB3_A943ServiciosNombre[0];
            A969PostulacionesProveedorNombre = P00LB3_A969PostulacionesProveedorNombre[0];
            A970PostulacionesSolicitudesId = P00LB3_A970PostulacionesSolicitudesId[0];
            n970PostulacionesSolicitudesId = P00LB3_n970PostulacionesSolicitudesId[0];
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV112Postulacioneswwds_1_filterfulltext)) || ( ( StringUtil.Like( StringUtil.Str( (decimal)(A422PostulacionesId), 18, 0) , StringUtil.PadR( "%" + AV112Postulacioneswwds_1_filterfulltext , 254 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Str( (decimal)(A942ServiciosId), 18, 0) , StringUtil.PadR( "%" + AV112Postulacioneswwds_1_filterfulltext , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A943ServiciosNombre) , StringUtil.PadR( "%" + StringUtil.Upper( AV112Postulacioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Str( (decimal)(A945PostulacionesProveedorId), 18, 0) , StringUtil.PadR( "%" + AV112Postulacioneswwds_1_filterfulltext , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A969PostulacionesProveedorNombre) , StringUtil.PadR( "%" + StringUtil.Upper( AV112Postulacioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Str( A946PostulacionesPrecio, 18, 2) , StringUtil.PadR( "%" + AV112Postulacioneswwds_1_filterfulltext , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Str( (decimal)(A961PostulacionesMultimediaSerial), 4, 0) , StringUtil.PadR( "%" + AV112Postulacioneswwds_1_filterfulltext , 254 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Str( (decimal)(A970PostulacionesSolicitudesId), 18, 0) , StringUtil.PadR( "%" + AV112Postulacioneswwds_1_filterfulltext , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A936PostulacionesDescripcion) , StringUtil.PadR( "%" + StringUtil.Upper( AV112Postulacioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Upper( A938PostulacionesSuministrosDescri) , StringUtil.PadR( "%" + StringUtil.Upper( AV112Postulacioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A940PostulacionesHoraCierre) , StringUtil.PadR( "%" + StringUtil.Upper( AV112Postulacioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Upper( A941PostulacionesTipoFecha) , StringUtil.PadR( "%" + StringUtil.Upper( AV112Postulacioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A949PostulacionesRgoHoraservicio) , StringUtil.PadR( "%" + StringUtil.Upper( AV112Postulacioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Upper( A950PostulacionesApellidoNombre) , StringUtil.PadR( "%" + StringUtil.Upper( AV112Postulacioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A951PostulacionesMail) , StringUtil.PadR( "%" + StringUtil.Upper( AV112Postulacioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Upper( A952PostulacionesTelefono) , StringUtil.PadR( "%" + StringUtil.Upper( AV112Postulacioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( context.GetMessage( "habilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV112Postulacioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A424PostulacionesEstado, "HAB") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "deshabilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV112Postulacioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A424PostulacionesEstado, "DES") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "ganador", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV112Postulacioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) &&
            ( StringUtil.StrCmp(A424PostulacionesEstado, "GAN") == 0 ) ) || ( StringUtil.Like( StringUtil.Str( (decimal)(A948PostulacionesSecUserId), 18, 0) , StringUtil.PadR( "%" + AV112Postulacioneswwds_1_filterfulltext , 254 , "%"),  ' ' ) ) )
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
               AV172GXV3 = 1;
               while ( AV172GXV3 <= AV39ColumnsSelector.gxTpr_Columns.Count )
               {
                  AV41ColumnsSelector_Column = ((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV39ColumnsSelector.gxTpr_Columns.Item(AV172GXV3));
                  if ( AV41ColumnsSelector_Column.gxTpr_Isvisible )
                  {
                     if ( StringUtil.StrCmp(AV41ColumnsSelector_Column.gxTpr_Columnname, "PostulacionesId") == 0 )
                     {
                        AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV47VisibleColumnCount), 1, 1).Number = A422PostulacionesId;
                     }
                     else if ( StringUtil.StrCmp(AV41ColumnsSelector_Column.gxTpr_Columnname, "ServiciosId") == 0 )
                     {
                        AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV47VisibleColumnCount), 1, 1).Number = A942ServiciosId;
                     }
                     else if ( StringUtil.StrCmp(AV41ColumnsSelector_Column.gxTpr_Columnname, "ServiciosNombre") == 0 )
                     {
                        GXt_char2 = "";
                        new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A943ServiciosNombre, out  GXt_char2) ;
                        AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV47VisibleColumnCount), 1, 1).Text = GXt_char2;
                     }
                     else if ( StringUtil.StrCmp(AV41ColumnsSelector_Column.gxTpr_Columnname, "PostulacionesProveedorId") == 0 )
                     {
                        AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV47VisibleColumnCount), 1, 1).Number = A945PostulacionesProveedorId;
                     }
                     else if ( StringUtil.StrCmp(AV41ColumnsSelector_Column.gxTpr_Columnname, "PostulacionesProveedorNombre") == 0 )
                     {
                        GXt_char2 = "";
                        new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A969PostulacionesProveedorNombre, out  GXt_char2) ;
                        AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV47VisibleColumnCount), 1, 1).Text = GXt_char2;
                     }
                     else if ( StringUtil.StrCmp(AV41ColumnsSelector_Column.gxTpr_Columnname, "PostulacionesPrecio") == 0 )
                     {
                        AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV47VisibleColumnCount), 1, 1).Number = (double)(A946PostulacionesPrecio);
                     }
                     else if ( StringUtil.StrCmp(AV41ColumnsSelector_Column.gxTpr_Columnname, "PostulacionesMultimediaSerial") == 0 )
                     {
                        AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV47VisibleColumnCount), 1, 1).Number = A961PostulacionesMultimediaSerial;
                     }
                     else if ( StringUtil.StrCmp(AV41ColumnsSelector_Column.gxTpr_Columnname, "PostulacionesSolicitudesId") == 0 )
                     {
                        AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV47VisibleColumnCount), 1, 1).Number = A970PostulacionesSolicitudesId;
                     }
                     else if ( StringUtil.StrCmp(AV41ColumnsSelector_Column.gxTpr_Columnname, "PostulacionesDescripcion") == 0 )
                     {
                        GXt_char2 = "";
                        new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A936PostulacionesDescripcion, out  GXt_char2) ;
                        AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV47VisibleColumnCount), 1, 1).Text = GXt_char2;
                     }
                     else if ( StringUtil.StrCmp(AV41ColumnsSelector_Column.gxTpr_Columnname, "PostulacionesReqSuministros") == 0 )
                     {
                        AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV47VisibleColumnCount), 1, 1).Text = StringUtil.BoolToStr( A937PostulacionesReqSuministros);
                     }
                     else if ( StringUtil.StrCmp(AV41ColumnsSelector_Column.gxTpr_Columnname, "PostulacionesSuministrosDescripcion") == 0 )
                     {
                        GXt_char2 = "";
                        new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A938PostulacionesSuministrosDescri, out  GXt_char2) ;
                        AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV47VisibleColumnCount), 1, 1).Text = GXt_char2;
                     }
                     else if ( StringUtil.StrCmp(AV41ColumnsSelector_Column.gxTpr_Columnname, "PostulacionesFechaTrabajo") == 0 )
                     {
                        GXt_dtime4 = DateTimeUtil.ResetTime( A947PostulacionesFechaTrabajo ) ;
                        AV11ExcelDocument.SetDateFormat(context, 8, 5, ((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0), DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt")), "/", ":", " ");
                        AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV47VisibleColumnCount), 1, 1).Date = GXt_dtime4;
                     }
                     else if ( StringUtil.StrCmp(AV41ColumnsSelector_Column.gxTpr_Columnname, "PostulacionesFechaCierre") == 0 )
                     {
                        GXt_dtime4 = DateTimeUtil.ResetTime( A939PostulacionesFechaCierre ) ;
                        AV11ExcelDocument.SetDateFormat(context, 8, 5, ((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0), DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt")), "/", ":", " ");
                        AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV47VisibleColumnCount), 1, 1).Date = GXt_dtime4;
                     }
                     else if ( StringUtil.StrCmp(AV41ColumnsSelector_Column.gxTpr_Columnname, "PostulacionesHoraCierre") == 0 )
                     {
                        GXt_char2 = "";
                        new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A940PostulacionesHoraCierre, out  GXt_char2) ;
                        AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV47VisibleColumnCount), 1, 1).Text = GXt_char2;
                     }
                     else if ( StringUtil.StrCmp(AV41ColumnsSelector_Column.gxTpr_Columnname, "PostulacionesTipoFecha") == 0 )
                     {
                        GXt_char2 = "";
                        new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A941PostulacionesTipoFecha, out  GXt_char2) ;
                        AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV47VisibleColumnCount), 1, 1).Text = GXt_char2;
                     }
                     else if ( StringUtil.StrCmp(AV41ColumnsSelector_Column.gxTpr_Columnname, "PostulacionesRgoHoraservicio") == 0 )
                     {
                        GXt_char2 = "";
                        new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A949PostulacionesRgoHoraservicio, out  GXt_char2) ;
                        AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV47VisibleColumnCount), 1, 1).Text = GXt_char2;
                     }
                     else if ( StringUtil.StrCmp(AV41ColumnsSelector_Column.gxTpr_Columnname, "PostulacionesApellidoNombre") == 0 )
                     {
                        GXt_char2 = "";
                        new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A950PostulacionesApellidoNombre, out  GXt_char2) ;
                        AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV47VisibleColumnCount), 1, 1).Text = GXt_char2;
                     }
                     else if ( StringUtil.StrCmp(AV41ColumnsSelector_Column.gxTpr_Columnname, "PostulacionesMail") == 0 )
                     {
                        GXt_char2 = "";
                        new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A951PostulacionesMail, out  GXt_char2) ;
                        AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV47VisibleColumnCount), 1, 1).Text = GXt_char2;
                     }
                     else if ( StringUtil.StrCmp(AV41ColumnsSelector_Column.gxTpr_Columnname, "PostulacionesTelefono") == 0 )
                     {
                        GXt_char2 = "";
                        new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A952PostulacionesTelefono, out  GXt_char2) ;
                        AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV47VisibleColumnCount), 1, 1).Text = GXt_char2;
                     }
                     else if ( StringUtil.StrCmp(AV41ColumnsSelector_Column.gxTpr_Columnname, "PostulacionesFechaAlta") == 0 )
                     {
                        AV11ExcelDocument.SetDateFormat(context, 8, 5, ((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0), DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt")), "/", ":", " ");
                        AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV47VisibleColumnCount), 1, 1).Date = A425PostulacionesFechaAlta;
                     }
                     else if ( StringUtil.StrCmp(AV41ColumnsSelector_Column.gxTpr_Columnname, "PostulacionesEstado") == 0 )
                     {
                        AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV47VisibleColumnCount), 1, 1).Text = "";
                        if ( StringUtil.StrCmp(StringUtil.Trim( A424PostulacionesEstado), context.GetMessage( "HAB", "")) == 0 )
                        {
                           AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV47VisibleColumnCount), 1, 1).Text = context.GetMessage( "Habilitado", "");
                        }
                        else if ( StringUtil.StrCmp(StringUtil.Trim( A424PostulacionesEstado), context.GetMessage( "DES", "")) == 0 )
                        {
                           AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV47VisibleColumnCount), 1, 1).Text = context.GetMessage( "Deshabilitado", "");
                        }
                        else if ( StringUtil.StrCmp(StringUtil.Trim( A424PostulacionesEstado), context.GetMessage( "GAN", "")) == 0 )
                        {
                           AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV47VisibleColumnCount), 1, 1).Text = context.GetMessage( "Ganador", "");
                        }
                     }
                     else if ( StringUtil.StrCmp(AV41ColumnsSelector_Column.gxTpr_Columnname, "PostulacionesSecUserId") == 0 )
                     {
                        AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV47VisibleColumnCount), 1, 1).Number = A948PostulacionesSecUserId;
                     }
                     AV47VisibleColumnCount = (long)(AV47VisibleColumnCount+1);
                  }
                  AV172GXV3 = (int)(AV172GXV3+1);
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
         AV35Session.Set("WWPExportFileName", "PostulacionesWWExport.xlsx");
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
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV39ColumnsSelector,  "PostulacionesId",  "",  "Id",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV39ColumnsSelector,  "ServiciosId",  "",  "Id",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV39ColumnsSelector,  "ServiciosNombre",  "",  "Nombre",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV39ColumnsSelector,  "PostulacionesProveedorId",  "",  "Proveedor Id",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV39ColumnsSelector,  "PostulacionesProveedorNombre",  "",  "Proveedor Nombre",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV39ColumnsSelector,  "PostulacionesPrecio",  "",  "Precio",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV39ColumnsSelector,  "PostulacionesMultimediaSerial",  "",  "Multimedia Serial",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV39ColumnsSelector,  "PostulacionesSolicitudesId",  "",  "Solicitudes Id",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV39ColumnsSelector,  "PostulacionesDescripcion",  "",  "Descripcion",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV39ColumnsSelector,  "PostulacionesReqSuministros",  "",  "Req Suministros",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV39ColumnsSelector,  "PostulacionesSuministrosDescripcion",  "",  "Suministros Descripcion",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV39ColumnsSelector,  "PostulacionesFechaTrabajo",  "",  "Fecha Trabajo",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV39ColumnsSelector,  "PostulacionesFechaCierre",  "",  "Fecha Cierre",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV39ColumnsSelector,  "PostulacionesHoraCierre",  "",  "Hora Cierre",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV39ColumnsSelector,  "PostulacionesTipoFecha",  "",  "Tipo Fecha",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV39ColumnsSelector,  "PostulacionesRgoHoraservicio",  "",  "Rgo Horaservicio",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV39ColumnsSelector,  "PostulacionesApellidoNombre",  "",  "Apellido Nombre",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV39ColumnsSelector,  "PostulacionesMail",  "",  "Mail",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV39ColumnsSelector,  "PostulacionesTelefono",  "",  "Telefono",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV39ColumnsSelector,  "PostulacionesFechaAlta",  "",  "Fecha",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV39ColumnsSelector,  "PostulacionesEstado",  "",  "Estado",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV39ColumnsSelector,  "PostulacionesSecUserId",  "",  "User Id",  true,  "") ;
         GXt_char2 = AV43UserCustomValue;
         new GeneXus.Programs.wwpbaseobjects.loadcolumnsselectorstate(context ).execute(  "PostulacionesWWColumnsSelector", out  GXt_char2) ;
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
         if ( StringUtil.StrCmp(AV35Session.Get("PostulacionesWWGridState"), "") == 0 )
         {
            AV37GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "PostulacionesWWGridState"), null, "", "");
         }
         else
         {
            AV37GridState.FromXml(AV35Session.Get("PostulacionesWWGridState"), null, "", "");
         }
         AV17OrderedBy = AV37GridState.gxTpr_Orderedby;
         AV18OrderedDsc = AV37GridState.gxTpr_Ordereddsc;
         AV173GXV4 = 1;
         while ( AV173GXV4 <= AV37GridState.gxTpr_Filtervalues.Count )
         {
            AV38GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV37GridState.gxTpr_Filtervalues.Item(AV173GXV4));
            if ( StringUtil.StrCmp(AV38GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV19FilterFullText = AV38GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV38GridStateFilterValue.gxTpr_Name, "TFPOSTULACIONESID") == 0 )
            {
               AV50TFPostulacionesId = (long)(Math.Round(NumberUtil.Val( AV38GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV51TFPostulacionesId_To = (long)(Math.Round(NumberUtil.Val( AV38GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV38GridStateFilterValue.gxTpr_Name, "TFSERVICIOSID") == 0 )
            {
               AV52TFServiciosId = (long)(Math.Round(NumberUtil.Val( AV38GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV53TFServiciosId_To = (long)(Math.Round(NumberUtil.Val( AV38GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV38GridStateFilterValue.gxTpr_Name, "TFSERVICIOSNOMBRE") == 0 )
            {
               AV54TFServiciosNombre = AV38GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV38GridStateFilterValue.gxTpr_Name, "TFSERVICIOSNOMBRE_SEL") == 0 )
            {
               AV55TFServiciosNombre_Sel = AV38GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV38GridStateFilterValue.gxTpr_Name, "TFPOSTULACIONESPROVEEDORID") == 0 )
            {
               AV56TFPostulacionesProveedorId = (long)(Math.Round(NumberUtil.Val( AV38GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV57TFPostulacionesProveedorId_To = (long)(Math.Round(NumberUtil.Val( AV38GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV38GridStateFilterValue.gxTpr_Name, "TFPOSTULACIONESPROVEEDORNOMBRE") == 0 )
            {
               AV89TFPostulacionesProveedorNombre = AV38GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV38GridStateFilterValue.gxTpr_Name, "TFPOSTULACIONESPROVEEDORNOMBRE_SEL") == 0 )
            {
               AV90TFPostulacionesProveedorNombre_Sel = AV38GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV38GridStateFilterValue.gxTpr_Name, "TFPOSTULACIONESPRECIO") == 0 )
            {
               AV58TFPostulacionesPrecio = NumberUtil.Val( AV38GridStateFilterValue.gxTpr_Value, ".");
               AV59TFPostulacionesPrecio_To = NumberUtil.Val( AV38GridStateFilterValue.gxTpr_Valueto, ".");
            }
            else if ( StringUtil.StrCmp(AV38GridStateFilterValue.gxTpr_Name, "TFPOSTULACIONESMULTIMEDIASERIAL") == 0 )
            {
               AV91TFPostulacionesMultimediaSerial = (short)(Math.Round(NumberUtil.Val( AV38GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV92TFPostulacionesMultimediaSerial_To = (short)(Math.Round(NumberUtil.Val( AV38GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV38GridStateFilterValue.gxTpr_Name, "TFPOSTULACIONESSOLICITUDESID") == 0 )
            {
               AV96TFPostulacionesSolicitudesId = (long)(Math.Round(NumberUtil.Val( AV38GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV97TFPostulacionesSolicitudesId_To = (long)(Math.Round(NumberUtil.Val( AV38GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV38GridStateFilterValue.gxTpr_Name, "TFPOSTULACIONESDESCRIPCION") == 0 )
            {
               AV60TFPostulacionesDescripcion = AV38GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV38GridStateFilterValue.gxTpr_Name, "TFPOSTULACIONESDESCRIPCION_SEL") == 0 )
            {
               AV61TFPostulacionesDescripcion_Sel = AV38GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV38GridStateFilterValue.gxTpr_Name, "TFPOSTULACIONESREQSUMINISTROS_SEL") == 0 )
            {
               AV62TFPostulacionesReqSuministros_Sel = (short)(Math.Round(NumberUtil.Val( AV38GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV38GridStateFilterValue.gxTpr_Name, "TFPOSTULACIONESSUMINISTROSDESCRIPCION") == 0 )
            {
               AV63TFPostulacionesSuministrosDescripcion = AV38GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV38GridStateFilterValue.gxTpr_Name, "TFPOSTULACIONESSUMINISTROSDESCRIPCION_SEL") == 0 )
            {
               AV64TFPostulacionesSuministrosDescripcion_Sel = AV38GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV38GridStateFilterValue.gxTpr_Name, "TFPOSTULACIONESFECHATRABAJO") == 0 )
            {
               AV65TFPostulacionesFechaTrabajo = context.localUtil.CToD( AV38GridStateFilterValue.gxTpr_Value, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               AV66TFPostulacionesFechaTrabajo_To = context.localUtil.CToD( AV38GridStateFilterValue.gxTpr_Valueto, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
            }
            else if ( StringUtil.StrCmp(AV38GridStateFilterValue.gxTpr_Name, "TFPOSTULACIONESFECHACIERRE") == 0 )
            {
               AV67TFPostulacionesFechaCierre = context.localUtil.CToD( AV38GridStateFilterValue.gxTpr_Value, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               AV68TFPostulacionesFechaCierre_To = context.localUtil.CToD( AV38GridStateFilterValue.gxTpr_Valueto, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
            }
            else if ( StringUtil.StrCmp(AV38GridStateFilterValue.gxTpr_Name, "TFPOSTULACIONESHORACIERRE") == 0 )
            {
               AV69TFPostulacionesHoraCierre = AV38GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV38GridStateFilterValue.gxTpr_Name, "TFPOSTULACIONESHORACIERRE_SEL") == 0 )
            {
               AV70TFPostulacionesHoraCierre_Sel = AV38GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV38GridStateFilterValue.gxTpr_Name, "TFPOSTULACIONESTIPOFECHA") == 0 )
            {
               AV71TFPostulacionesTipoFecha = AV38GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV38GridStateFilterValue.gxTpr_Name, "TFPOSTULACIONESTIPOFECHA_SEL") == 0 )
            {
               AV107TFPostulacionesTipoFecha_Sel = AV38GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV38GridStateFilterValue.gxTpr_Name, "TFPOSTULACIONESRGOHORASERVICIO") == 0 )
            {
               AV73TFPostulacionesRgoHoraservicio = AV38GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV38GridStateFilterValue.gxTpr_Name, "TFPOSTULACIONESRGOHORASERVICIO_SEL") == 0 )
            {
               AV74TFPostulacionesRgoHoraservicio_Sel = AV38GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV38GridStateFilterValue.gxTpr_Name, "TFPOSTULACIONESAPELLIDONOMBRE") == 0 )
            {
               AV75TFPostulacionesApellidoNombre = AV38GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV38GridStateFilterValue.gxTpr_Name, "TFPOSTULACIONESAPELLIDONOMBRE_SEL") == 0 )
            {
               AV76TFPostulacionesApellidoNombre_Sel = AV38GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV38GridStateFilterValue.gxTpr_Name, "TFPOSTULACIONESMAIL") == 0 )
            {
               AV77TFPostulacionesMail = AV38GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV38GridStateFilterValue.gxTpr_Name, "TFPOSTULACIONESMAIL_SEL") == 0 )
            {
               AV78TFPostulacionesMail_Sel = AV38GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV38GridStateFilterValue.gxTpr_Name, "TFPOSTULACIONESTELEFONO") == 0 )
            {
               AV79TFPostulacionesTelefono = AV38GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV38GridStateFilterValue.gxTpr_Name, "TFPOSTULACIONESTELEFONO_SEL") == 0 )
            {
               AV80TFPostulacionesTelefono_Sel = AV38GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV38GridStateFilterValue.gxTpr_Name, "TFPOSTULACIONESFECHAALTA") == 0 )
            {
               AV81TFPostulacionesFechaAlta = context.localUtil.CToT( AV38GridStateFilterValue.gxTpr_Value, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               AV82TFPostulacionesFechaAlta_To = context.localUtil.CToT( AV38GridStateFilterValue.gxTpr_Valueto, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
            }
            else if ( StringUtil.StrCmp(AV38GridStateFilterValue.gxTpr_Name, "TFPOSTULACIONESESTADO_SEL") == 0 )
            {
               AV83TFPostulacionesEstado_SelsJson = AV38GridStateFilterValue.gxTpr_Value;
               AV85TFPostulacionesEstado_Sels.FromJSonString(AV83TFPostulacionesEstado_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV38GridStateFilterValue.gxTpr_Name, "TFPOSTULACIONESSECUSERID") == 0 )
            {
               AV86TFPostulacionesSecUserId = (long)(Math.Round(NumberUtil.Val( AV38GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV87TFPostulacionesSecUserId_To = (long)(Math.Round(NumberUtil.Val( AV38GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            AV173GXV4 = (int)(AV173GXV4+1);
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
         AV108Pgmname = "";
         GXKey = "";
         GXEncryptionTmp = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV11ExcelDocument = new ExcelDocumentI();
         AV19FilterFullText = "";
         AV37GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV34GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV20DynamicFiltersSelector1 = "";
         AV93PostulacionesProveedorNombre1 = "";
         AV23ServiciosNombre1 = "";
         AV25DynamicFiltersSelector2 = "";
         AV94PostulacionesProveedorNombre2 = "";
         AV28ServiciosNombre2 = "";
         AV30DynamicFiltersSelector3 = "";
         AV95PostulacionesProveedorNombre3 = "";
         AV33ServiciosNombre3 = "";
         AV55TFServiciosNombre_Sel = "";
         AV54TFServiciosNombre = "";
         AV90TFPostulacionesProveedorNombre_Sel = "";
         AV89TFPostulacionesProveedorNombre = "";
         AV61TFPostulacionesDescripcion_Sel = "";
         AV60TFPostulacionesDescripcion = "";
         AV64TFPostulacionesSuministrosDescripcion_Sel = "";
         AV63TFPostulacionesSuministrosDescripcion = "";
         AV65TFPostulacionesFechaTrabajo = DateTime.MinValue;
         AV66TFPostulacionesFechaTrabajo_To = DateTime.MinValue;
         AV67TFPostulacionesFechaCierre = DateTime.MinValue;
         AV68TFPostulacionesFechaCierre_To = DateTime.MinValue;
         AV70TFPostulacionesHoraCierre_Sel = "";
         AV69TFPostulacionesHoraCierre = "";
         AV107TFPostulacionesTipoFecha_Sel = "";
         AV71TFPostulacionesTipoFecha = "";
         AV74TFPostulacionesRgoHoraservicio_Sel = "";
         AV73TFPostulacionesRgoHoraservicio = "";
         AV76TFPostulacionesApellidoNombre_Sel = "";
         AV75TFPostulacionesApellidoNombre = "";
         AV78TFPostulacionesMail_Sel = "";
         AV77TFPostulacionesMail = "";
         AV80TFPostulacionesTelefono_Sel = "";
         AV79TFPostulacionesTelefono = "";
         AV81TFPostulacionesFechaAlta = (DateTime)(DateTime.MinValue);
         AV82TFPostulacionesFechaAlta_To = (DateTime)(DateTime.MinValue);
         AV85TFPostulacionesEstado_Sels = new GxSimpleCollection<string>();
         AV84TFPostulacionesEstado_Sel = "";
         AV35Session = context.GetSession();
         AV42ColumnsSelectorXML = "";
         AV39ColumnsSelector = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector(context);
         AV41ColumnsSelector_Column = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column(context);
         AV112Postulacioneswwds_1_filterfulltext = "";
         AV113Postulacioneswwds_2_dynamicfiltersselector1 = "";
         AV115Postulacioneswwds_4_postulacionesproveedornombre1 = "";
         AV117Postulacioneswwds_6_serviciosnombre1 = "";
         AV119Postulacioneswwds_8_dynamicfiltersselector2 = "";
         AV121Postulacioneswwds_10_postulacionesproveedornombre2 = "";
         AV123Postulacioneswwds_12_serviciosnombre2 = "";
         AV125Postulacioneswwds_14_dynamicfiltersselector3 = "";
         AV127Postulacioneswwds_16_postulacionesproveedornombre3 = "";
         AV129Postulacioneswwds_18_serviciosnombre3 = "";
         AV134Postulacioneswwds_23_tfserviciosnombre = "";
         AV135Postulacioneswwds_24_tfserviciosnombre_sel = "";
         AV138Postulacioneswwds_27_tfpostulacionesproveedornombre = "";
         AV139Postulacioneswwds_28_tfpostulacionesproveedornombre_sel = "";
         AV146Postulacioneswwds_35_tfpostulacionesdescripcion = "";
         AV147Postulacioneswwds_36_tfpostulacionesdescripcion_sel = "";
         AV149Postulacioneswwds_38_tfpostulacionessuministrosdescripcion = "";
         AV150Postulacioneswwds_39_tfpostulacionessuministrosdescripcion_sel = "";
         AV151Postulacioneswwds_40_tfpostulacionesfechatrabajo = DateTime.MinValue;
         AV152Postulacioneswwds_41_tfpostulacionesfechatrabajo_to = DateTime.MinValue;
         AV153Postulacioneswwds_42_tfpostulacionesfechacierre = DateTime.MinValue;
         AV154Postulacioneswwds_43_tfpostulacionesfechacierre_to = DateTime.MinValue;
         AV155Postulacioneswwds_44_tfpostulacioneshoracierre = "";
         AV156Postulacioneswwds_45_tfpostulacioneshoracierre_sel = "";
         AV157Postulacioneswwds_46_tfpostulacionestipofecha = "";
         AV158Postulacioneswwds_47_tfpostulacionestipofecha_sel = "";
         AV159Postulacioneswwds_48_tfpostulacionesrgohoraservicio = "";
         AV160Postulacioneswwds_49_tfpostulacionesrgohoraservicio_sel = "";
         AV161Postulacioneswwds_50_tfpostulacionesapellidonombre = "";
         AV162Postulacioneswwds_51_tfpostulacionesapellidonombre_sel = "";
         AV163Postulacioneswwds_52_tfpostulacionesmail = "";
         AV164Postulacioneswwds_53_tfpostulacionesmail_sel = "";
         AV165Postulacioneswwds_54_tfpostulacionestelefono = "";
         AV166Postulacioneswwds_55_tfpostulacionestelefono_sel = "";
         AV167Postulacioneswwds_56_tfpostulacionesfechaalta = (DateTime)(DateTime.MinValue);
         AV168Postulacioneswwds_57_tfpostulacionesfechaalta_to = (DateTime)(DateTime.MinValue);
         AV169Postulacioneswwds_58_tfpostulacionesestado_sels = new GxSimpleCollection<string>();
         lV112Postulacioneswwds_1_filterfulltext = "";
         lV115Postulacioneswwds_4_postulacionesproveedornombre1 = "";
         lV117Postulacioneswwds_6_serviciosnombre1 = "";
         lV121Postulacioneswwds_10_postulacionesproveedornombre2 = "";
         lV123Postulacioneswwds_12_serviciosnombre2 = "";
         lV127Postulacioneswwds_16_postulacionesproveedornombre3 = "";
         lV129Postulacioneswwds_18_serviciosnombre3 = "";
         lV134Postulacioneswwds_23_tfserviciosnombre = "";
         lV138Postulacioneswwds_27_tfpostulacionesproveedornombre = "";
         lV146Postulacioneswwds_35_tfpostulacionesdescripcion = "";
         lV149Postulacioneswwds_38_tfpostulacionessuministrosdescripcion = "";
         lV155Postulacioneswwds_44_tfpostulacioneshoracierre = "";
         lV157Postulacioneswwds_46_tfpostulacionestipofecha = "";
         lV159Postulacioneswwds_48_tfpostulacionesrgohoraservicio = "";
         lV161Postulacioneswwds_50_tfpostulacionesapellidonombre = "";
         lV163Postulacioneswwds_52_tfpostulacionesmail = "";
         lV165Postulacioneswwds_54_tfpostulacionestelefono = "";
         A424PostulacionesEstado = "";
         A969PostulacionesProveedorNombre = "";
         A943ServiciosNombre = "";
         A936PostulacionesDescripcion = "";
         A938PostulacionesSuministrosDescri = "";
         A947PostulacionesFechaTrabajo = DateTime.MinValue;
         A939PostulacionesFechaCierre = DateTime.MinValue;
         A940PostulacionesHoraCierre = "";
         A941PostulacionesTipoFecha = "";
         A949PostulacionesRgoHoraservicio = "";
         A950PostulacionesApellidoNombre = "";
         A951PostulacionesMail = "";
         A952PostulacionesTelefono = "";
         A425PostulacionesFechaAlta = (DateTime)(DateTime.MinValue);
         P00LB3_A948PostulacionesSecUserId = new long[1] ;
         P00LB3_A425PostulacionesFechaAlta = new DateTime[] {DateTime.MinValue} ;
         P00LB3_A952PostulacionesTelefono = new string[] {""} ;
         P00LB3_A951PostulacionesMail = new string[] {""} ;
         P00LB3_A950PostulacionesApellidoNombre = new string[] {""} ;
         P00LB3_A949PostulacionesRgoHoraservicio = new string[] {""} ;
         P00LB3_A941PostulacionesTipoFecha = new string[] {""} ;
         P00LB3_A940PostulacionesHoraCierre = new string[] {""} ;
         P00LB3_A939PostulacionesFechaCierre = new DateTime[] {DateTime.MinValue} ;
         P00LB3_A947PostulacionesFechaTrabajo = new DateTime[] {DateTime.MinValue} ;
         P00LB3_A938PostulacionesSuministrosDescri = new string[] {""} ;
         P00LB3_A937PostulacionesReqSuministros = new bool[] {false} ;
         P00LB3_A936PostulacionesDescripcion = new string[] {""} ;
         P00LB3_A961PostulacionesMultimediaSerial = new short[1] ;
         P00LB3_A946PostulacionesPrecio = new decimal[1] ;
         P00LB3_A969PostulacionesProveedorNombre = new string[] {""} ;
         P00LB3_A943ServiciosNombre = new string[] {""} ;
         P00LB3_A942ServiciosId = new long[1] ;
         P00LB3_n942ServiciosId = new bool[] {false} ;
         P00LB3_A422PostulacionesId = new long[1] ;
         P00LB3_n422PostulacionesId = new bool[] {false} ;
         P00LB3_A945PostulacionesProveedorId = new long[1] ;
         P00LB3_A424PostulacionesEstado = new string[] {""} ;
         P00LB3_A970PostulacionesSolicitudesId = new long[1] ;
         P00LB3_n970PostulacionesSolicitudesId = new bool[] {false} ;
         GXt_dtime4 = (DateTime)(DateTime.MinValue);
         AV43UserCustomValue = "";
         GXt_char2 = "";
         AV40ColumnsSelectorAux = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector(context);
         AV38GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV83TFPostulacionesEstado_SelsJson = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.postulacioneswwexport__default(),
            new Object[][] {
                new Object[] {
               P00LB3_A948PostulacionesSecUserId, P00LB3_A425PostulacionesFechaAlta, P00LB3_A952PostulacionesTelefono, P00LB3_A951PostulacionesMail, P00LB3_A950PostulacionesApellidoNombre, P00LB3_A949PostulacionesRgoHoraservicio, P00LB3_A941PostulacionesTipoFecha, P00LB3_A940PostulacionesHoraCierre, P00LB3_A939PostulacionesFechaCierre, P00LB3_A947PostulacionesFechaTrabajo,
               P00LB3_A938PostulacionesSuministrosDescri, P00LB3_A937PostulacionesReqSuministros, P00LB3_A936PostulacionesDescripcion, P00LB3_A961PostulacionesMultimediaSerial, P00LB3_A946PostulacionesPrecio, P00LB3_A969PostulacionesProveedorNombre, P00LB3_A943ServiciosNombre, P00LB3_A942ServiciosId, P00LB3_n942ServiciosId, P00LB3_A422PostulacionesId,
               P00LB3_A945PostulacionesProveedorId, P00LB3_A424PostulacionesEstado, P00LB3_A970PostulacionesSolicitudesId, P00LB3_n970PostulacionesSolicitudesId
               }
            }
         );
         AV108Pgmname = "PostulacionesWWExport";
         /* GeneXus formulas. */
         AV108Pgmname = "PostulacionesWWExport";
      }

      private short AV21DynamicFiltersOperator1 ;
      private short AV26DynamicFiltersOperator2 ;
      private short AV31DynamicFiltersOperator3 ;
      private short AV91TFPostulacionesMultimediaSerial ;
      private short AV92TFPostulacionesMultimediaSerial_To ;
      private short AV62TFPostulacionesReqSuministros_Sel ;
      private short GXt_int3 ;
      private short AV114Postulacioneswwds_3_dynamicfiltersoperator1 ;
      private short AV120Postulacioneswwds_9_dynamicfiltersoperator2 ;
      private short AV126Postulacioneswwds_15_dynamicfiltersoperator3 ;
      private short AV142Postulacioneswwds_31_tfpostulacionesmultimediaserial ;
      private short AV143Postulacioneswwds_32_tfpostulacionesmultimediaserial_to ;
      private short AV148Postulacioneswwds_37_tfpostulacionesreqsuministros_sel ;
      private short A961PostulacionesMultimediaSerial ;
      private short AV17OrderedBy ;
      private int AV14CellRow ;
      private int AV15FirstColumn ;
      private int AV16Random ;
      private int AV109GXV1 ;
      private int AV110GXV2 ;
      private int AV169Postulacioneswwds_58_tfpostulacionesestado_sels_Count ;
      private int AV172GXV3 ;
      private int AV173GXV4 ;
      private long AV22PostulacionesProveedorId1 ;
      private long AV27PostulacionesProveedorId2 ;
      private long AV32PostulacionesProveedorId3 ;
      private long AV50TFPostulacionesId ;
      private long AV51TFPostulacionesId_To ;
      private long AV52TFServiciosId ;
      private long AV53TFServiciosId_To ;
      private long AV56TFPostulacionesProveedorId ;
      private long AV57TFPostulacionesProveedorId_To ;
      private long AV96TFPostulacionesSolicitudesId ;
      private long AV97TFPostulacionesSolicitudesId_To ;
      private long AV88i ;
      private long AV86TFPostulacionesSecUserId ;
      private long AV87TFPostulacionesSecUserId_To ;
      private long AV47VisibleColumnCount ;
      private long AV116Postulacioneswwds_5_postulacionesproveedorid1 ;
      private long AV122Postulacioneswwds_11_postulacionesproveedorid2 ;
      private long AV128Postulacioneswwds_17_postulacionesproveedorid3 ;
      private long AV130Postulacioneswwds_19_tfpostulacionesid ;
      private long AV131Postulacioneswwds_20_tfpostulacionesid_to ;
      private long AV132Postulacioneswwds_21_tfserviciosid ;
      private long AV133Postulacioneswwds_22_tfserviciosid_to ;
      private long AV136Postulacioneswwds_25_tfpostulacionesproveedorid ;
      private long AV137Postulacioneswwds_26_tfpostulacionesproveedorid_to ;
      private long AV144Postulacioneswwds_33_tfpostulacionessolicitudesid ;
      private long AV145Postulacioneswwds_34_tfpostulacionessolicitudesid_to ;
      private long AV170Postulacioneswwds_59_tfpostulacionessecuserid ;
      private long AV171Postulacioneswwds_60_tfpostulacionessecuserid_to ;
      private long A945PostulacionesProveedorId ;
      private long A422PostulacionesId ;
      private long A942ServiciosId ;
      private long A948PostulacionesSecUserId ;
      private long A970PostulacionesSolicitudesId ;
      private decimal AV58TFPostulacionesPrecio ;
      private decimal AV59TFPostulacionesPrecio_To ;
      private decimal AV140Postulacioneswwds_29_tfpostulacionesprecio ;
      private decimal AV141Postulacioneswwds_30_tfpostulacionesprecio_to ;
      private decimal A946PostulacionesPrecio ;
      private string AV108Pgmname ;
      private string GXKey ;
      private string GXEncryptionTmp ;
      private string AV93PostulacionesProveedorNombre1 ;
      private string AV23ServiciosNombre1 ;
      private string AV94PostulacionesProveedorNombre2 ;
      private string AV28ServiciosNombre2 ;
      private string AV95PostulacionesProveedorNombre3 ;
      private string AV33ServiciosNombre3 ;
      private string AV55TFServiciosNombre_Sel ;
      private string AV54TFServiciosNombre ;
      private string AV90TFPostulacionesProveedorNombre_Sel ;
      private string AV89TFPostulacionesProveedorNombre ;
      private string AV61TFPostulacionesDescripcion_Sel ;
      private string AV60TFPostulacionesDescripcion ;
      private string AV64TFPostulacionesSuministrosDescripcion_Sel ;
      private string AV63TFPostulacionesSuministrosDescripcion ;
      private string AV74TFPostulacionesRgoHoraservicio_Sel ;
      private string AV73TFPostulacionesRgoHoraservicio ;
      private string AV76TFPostulacionesApellidoNombre_Sel ;
      private string AV75TFPostulacionesApellidoNombre ;
      private string AV80TFPostulacionesTelefono_Sel ;
      private string AV79TFPostulacionesTelefono ;
      private string AV84TFPostulacionesEstado_Sel ;
      private string AV115Postulacioneswwds_4_postulacionesproveedornombre1 ;
      private string AV117Postulacioneswwds_6_serviciosnombre1 ;
      private string AV121Postulacioneswwds_10_postulacionesproveedornombre2 ;
      private string AV123Postulacioneswwds_12_serviciosnombre2 ;
      private string AV127Postulacioneswwds_16_postulacionesproveedornombre3 ;
      private string AV129Postulacioneswwds_18_serviciosnombre3 ;
      private string AV134Postulacioneswwds_23_tfserviciosnombre ;
      private string AV135Postulacioneswwds_24_tfserviciosnombre_sel ;
      private string AV138Postulacioneswwds_27_tfpostulacionesproveedornombre ;
      private string AV139Postulacioneswwds_28_tfpostulacionesproveedornombre_sel ;
      private string AV146Postulacioneswwds_35_tfpostulacionesdescripcion ;
      private string AV147Postulacioneswwds_36_tfpostulacionesdescripcion_sel ;
      private string AV149Postulacioneswwds_38_tfpostulacionessuministrosdescripcion ;
      private string AV150Postulacioneswwds_39_tfpostulacionessuministrosdescripcion_sel ;
      private string AV159Postulacioneswwds_48_tfpostulacionesrgohoraservicio ;
      private string AV160Postulacioneswwds_49_tfpostulacionesrgohoraservicio_sel ;
      private string AV161Postulacioneswwds_50_tfpostulacionesapellidonombre ;
      private string AV162Postulacioneswwds_51_tfpostulacionesapellidonombre_sel ;
      private string AV165Postulacioneswwds_54_tfpostulacionestelefono ;
      private string AV166Postulacioneswwds_55_tfpostulacionestelefono_sel ;
      private string lV115Postulacioneswwds_4_postulacionesproveedornombre1 ;
      private string lV117Postulacioneswwds_6_serviciosnombre1 ;
      private string lV121Postulacioneswwds_10_postulacionesproveedornombre2 ;
      private string lV123Postulacioneswwds_12_serviciosnombre2 ;
      private string lV127Postulacioneswwds_16_postulacionesproveedornombre3 ;
      private string lV129Postulacioneswwds_18_serviciosnombre3 ;
      private string lV134Postulacioneswwds_23_tfserviciosnombre ;
      private string lV138Postulacioneswwds_27_tfpostulacionesproveedornombre ;
      private string lV146Postulacioneswwds_35_tfpostulacionesdescripcion ;
      private string lV149Postulacioneswwds_38_tfpostulacionessuministrosdescripcion ;
      private string lV159Postulacioneswwds_48_tfpostulacionesrgohoraservicio ;
      private string lV161Postulacioneswwds_50_tfpostulacionesapellidonombre ;
      private string lV165Postulacioneswwds_54_tfpostulacionestelefono ;
      private string A424PostulacionesEstado ;
      private string A969PostulacionesProveedorNombre ;
      private string A943ServiciosNombre ;
      private string A936PostulacionesDescripcion ;
      private string A938PostulacionesSuministrosDescri ;
      private string A949PostulacionesRgoHoraservicio ;
      private string A950PostulacionesApellidoNombre ;
      private string A952PostulacionesTelefono ;
      private string GXt_char2 ;
      private DateTime AV81TFPostulacionesFechaAlta ;
      private DateTime AV82TFPostulacionesFechaAlta_To ;
      private DateTime AV167Postulacioneswwds_56_tfpostulacionesfechaalta ;
      private DateTime AV168Postulacioneswwds_57_tfpostulacionesfechaalta_to ;
      private DateTime A425PostulacionesFechaAlta ;
      private DateTime GXt_dtime4 ;
      private DateTime AV65TFPostulacionesFechaTrabajo ;
      private DateTime AV66TFPostulacionesFechaTrabajo_To ;
      private DateTime AV67TFPostulacionesFechaCierre ;
      private DateTime AV68TFPostulacionesFechaCierre_To ;
      private DateTime AV151Postulacioneswwds_40_tfpostulacionesfechatrabajo ;
      private DateTime AV152Postulacioneswwds_41_tfpostulacionesfechatrabajo_to ;
      private DateTime AV153Postulacioneswwds_42_tfpostulacionesfechacierre ;
      private DateTime AV154Postulacioneswwds_43_tfpostulacionesfechacierre_to ;
      private DateTime A947PostulacionesFechaTrabajo ;
      private DateTime A939PostulacionesFechaCierre ;
      private bool AV8IsAuthorized ;
      private bool GXt_boolean1 ;
      private bool returnInSub ;
      private bool AV24DynamicFiltersEnabled2 ;
      private bool AV29DynamicFiltersEnabled3 ;
      private bool AV118Postulacioneswwds_7_dynamicfiltersenabled2 ;
      private bool AV124Postulacioneswwds_13_dynamicfiltersenabled3 ;
      private bool A937PostulacionesReqSuministros ;
      private bool AV18OrderedDsc ;
      private bool n422PostulacionesId ;
      private bool n942ServiciosId ;
      private bool n970PostulacionesSolicitudesId ;
      private string AV42ColumnsSelectorXML ;
      private string AV43UserCustomValue ;
      private string AV83TFPostulacionesEstado_SelsJson ;
      private string AV12Filename ;
      private string AV13ErrorMessage ;
      private string AV19FilterFullText ;
      private string AV20DynamicFiltersSelector1 ;
      private string AV25DynamicFiltersSelector2 ;
      private string AV30DynamicFiltersSelector3 ;
      private string AV70TFPostulacionesHoraCierre_Sel ;
      private string AV69TFPostulacionesHoraCierre ;
      private string AV107TFPostulacionesTipoFecha_Sel ;
      private string AV71TFPostulacionesTipoFecha ;
      private string AV78TFPostulacionesMail_Sel ;
      private string AV77TFPostulacionesMail ;
      private string AV112Postulacioneswwds_1_filterfulltext ;
      private string AV113Postulacioneswwds_2_dynamicfiltersselector1 ;
      private string AV119Postulacioneswwds_8_dynamicfiltersselector2 ;
      private string AV125Postulacioneswwds_14_dynamicfiltersselector3 ;
      private string AV155Postulacioneswwds_44_tfpostulacioneshoracierre ;
      private string AV156Postulacioneswwds_45_tfpostulacioneshoracierre_sel ;
      private string AV157Postulacioneswwds_46_tfpostulacionestipofecha ;
      private string AV158Postulacioneswwds_47_tfpostulacionestipofecha_sel ;
      private string AV163Postulacioneswwds_52_tfpostulacionesmail ;
      private string AV164Postulacioneswwds_53_tfpostulacionesmail_sel ;
      private string lV112Postulacioneswwds_1_filterfulltext ;
      private string lV155Postulacioneswwds_44_tfpostulacioneshoracierre ;
      private string lV157Postulacioneswwds_46_tfpostulacionestipofecha ;
      private string lV163Postulacioneswwds_52_tfpostulacionesmail ;
      private string A940PostulacionesHoraCierre ;
      private string A941PostulacionesTipoFecha ;
      private string A951PostulacionesMail ;
      private IGxSession AV35Session ;
      private ExcelDocumentI AV11ExcelDocument ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV37GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV34GridStateDynamicFilter ;
      private GxSimpleCollection<string> AV85TFPostulacionesEstado_Sels ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector AV39ColumnsSelector ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column AV41ColumnsSelector_Column ;
      private GxSimpleCollection<string> AV169Postulacioneswwds_58_tfpostulacionesestado_sels ;
      private IDataStoreProvider pr_default ;
      private long[] P00LB3_A948PostulacionesSecUserId ;
      private DateTime[] P00LB3_A425PostulacionesFechaAlta ;
      private string[] P00LB3_A952PostulacionesTelefono ;
      private string[] P00LB3_A951PostulacionesMail ;
      private string[] P00LB3_A950PostulacionesApellidoNombre ;
      private string[] P00LB3_A949PostulacionesRgoHoraservicio ;
      private string[] P00LB3_A941PostulacionesTipoFecha ;
      private string[] P00LB3_A940PostulacionesHoraCierre ;
      private DateTime[] P00LB3_A939PostulacionesFechaCierre ;
      private DateTime[] P00LB3_A947PostulacionesFechaTrabajo ;
      private string[] P00LB3_A938PostulacionesSuministrosDescri ;
      private bool[] P00LB3_A937PostulacionesReqSuministros ;
      private string[] P00LB3_A936PostulacionesDescripcion ;
      private short[] P00LB3_A961PostulacionesMultimediaSerial ;
      private decimal[] P00LB3_A946PostulacionesPrecio ;
      private string[] P00LB3_A969PostulacionesProveedorNombre ;
      private string[] P00LB3_A943ServiciosNombre ;
      private long[] P00LB3_A942ServiciosId ;
      private bool[] P00LB3_n942ServiciosId ;
      private long[] P00LB3_A422PostulacionesId ;
      private bool[] P00LB3_n422PostulacionesId ;
      private long[] P00LB3_A945PostulacionesProveedorId ;
      private string[] P00LB3_A424PostulacionesEstado ;
      private long[] P00LB3_A970PostulacionesSolicitudesId ;
      private bool[] P00LB3_n970PostulacionesSolicitudesId ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector AV40ColumnsSelectorAux ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV38GridStateFilterValue ;
      private string aP0_Filename ;
      private string aP1_ErrorMessage ;
   }

   public class postulacioneswwexport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00LB3( IGxContext context ,
                                             string A424PostulacionesEstado ,
                                             GxSimpleCollection<string> AV169Postulacioneswwds_58_tfpostulacionesestado_sels ,
                                             string AV113Postulacioneswwds_2_dynamicfiltersselector1 ,
                                             short AV114Postulacioneswwds_3_dynamicfiltersoperator1 ,
                                             string AV115Postulacioneswwds_4_postulacionesproveedornombre1 ,
                                             long AV116Postulacioneswwds_5_postulacionesproveedorid1 ,
                                             string AV117Postulacioneswwds_6_serviciosnombre1 ,
                                             bool AV118Postulacioneswwds_7_dynamicfiltersenabled2 ,
                                             string AV119Postulacioneswwds_8_dynamicfiltersselector2 ,
                                             short AV120Postulacioneswwds_9_dynamicfiltersoperator2 ,
                                             string AV121Postulacioneswwds_10_postulacionesproveedornombre2 ,
                                             long AV122Postulacioneswwds_11_postulacionesproveedorid2 ,
                                             string AV123Postulacioneswwds_12_serviciosnombre2 ,
                                             bool AV124Postulacioneswwds_13_dynamicfiltersenabled3 ,
                                             string AV125Postulacioneswwds_14_dynamicfiltersselector3 ,
                                             short AV126Postulacioneswwds_15_dynamicfiltersoperator3 ,
                                             string AV127Postulacioneswwds_16_postulacionesproveedornombre3 ,
                                             long AV128Postulacioneswwds_17_postulacionesproveedorid3 ,
                                             string AV129Postulacioneswwds_18_serviciosnombre3 ,
                                             long AV130Postulacioneswwds_19_tfpostulacionesid ,
                                             long AV131Postulacioneswwds_20_tfpostulacionesid_to ,
                                             long AV132Postulacioneswwds_21_tfserviciosid ,
                                             long AV133Postulacioneswwds_22_tfserviciosid_to ,
                                             string AV135Postulacioneswwds_24_tfserviciosnombre_sel ,
                                             string AV134Postulacioneswwds_23_tfserviciosnombre ,
                                             long AV136Postulacioneswwds_25_tfpostulacionesproveedorid ,
                                             long AV137Postulacioneswwds_26_tfpostulacionesproveedorid_to ,
                                             string AV139Postulacioneswwds_28_tfpostulacionesproveedornombre_sel ,
                                             string AV138Postulacioneswwds_27_tfpostulacionesproveedornombre ,
                                             decimal AV140Postulacioneswwds_29_tfpostulacionesprecio ,
                                             decimal AV141Postulacioneswwds_30_tfpostulacionesprecio_to ,
                                             short AV142Postulacioneswwds_31_tfpostulacionesmultimediaserial ,
                                             short AV143Postulacioneswwds_32_tfpostulacionesmultimediaserial_to ,
                                             string AV147Postulacioneswwds_36_tfpostulacionesdescripcion_sel ,
                                             string AV146Postulacioneswwds_35_tfpostulacionesdescripcion ,
                                             short AV148Postulacioneswwds_37_tfpostulacionesreqsuministros_sel ,
                                             string AV150Postulacioneswwds_39_tfpostulacionessuministrosdescripcion_sel ,
                                             string AV149Postulacioneswwds_38_tfpostulacionessuministrosdescripcion ,
                                             DateTime AV151Postulacioneswwds_40_tfpostulacionesfechatrabajo ,
                                             DateTime AV152Postulacioneswwds_41_tfpostulacionesfechatrabajo_to ,
                                             DateTime AV153Postulacioneswwds_42_tfpostulacionesfechacierre ,
                                             DateTime AV154Postulacioneswwds_43_tfpostulacionesfechacierre_to ,
                                             string AV156Postulacioneswwds_45_tfpostulacioneshoracierre_sel ,
                                             string AV155Postulacioneswwds_44_tfpostulacioneshoracierre ,
                                             string AV158Postulacioneswwds_47_tfpostulacionestipofecha_sel ,
                                             string AV157Postulacioneswwds_46_tfpostulacionestipofecha ,
                                             string AV160Postulacioneswwds_49_tfpostulacionesrgohoraservicio_sel ,
                                             string AV159Postulacioneswwds_48_tfpostulacionesrgohoraservicio ,
                                             string AV162Postulacioneswwds_51_tfpostulacionesapellidonombre_sel ,
                                             string AV161Postulacioneswwds_50_tfpostulacionesapellidonombre ,
                                             string AV164Postulacioneswwds_53_tfpostulacionesmail_sel ,
                                             string AV163Postulacioneswwds_52_tfpostulacionesmail ,
                                             string AV166Postulacioneswwds_55_tfpostulacionestelefono_sel ,
                                             string AV165Postulacioneswwds_54_tfpostulacionestelefono ,
                                             DateTime AV167Postulacioneswwds_56_tfpostulacionesfechaalta ,
                                             DateTime AV168Postulacioneswwds_57_tfpostulacionesfechaalta_to ,
                                             int AV169Postulacioneswwds_58_tfpostulacionesestado_sels_Count ,
                                             long AV170Postulacioneswwds_59_tfpostulacionessecuserid ,
                                             long AV171Postulacioneswwds_60_tfpostulacionessecuserid_to ,
                                             string A969PostulacionesProveedorNombre ,
                                             long A945PostulacionesProveedorId ,
                                             string A943ServiciosNombre ,
                                             long A422PostulacionesId ,
                                             long A942ServiciosId ,
                                             decimal A946PostulacionesPrecio ,
                                             short A961PostulacionesMultimediaSerial ,
                                             string A936PostulacionesDescripcion ,
                                             bool A937PostulacionesReqSuministros ,
                                             string A938PostulacionesSuministrosDescri ,
                                             DateTime A947PostulacionesFechaTrabajo ,
                                             DateTime A939PostulacionesFechaCierre ,
                                             string A940PostulacionesHoraCierre ,
                                             string A941PostulacionesTipoFecha ,
                                             string A949PostulacionesRgoHoraservicio ,
                                             string A950PostulacionesApellidoNombre ,
                                             string A951PostulacionesMail ,
                                             string A952PostulacionesTelefono ,
                                             DateTime A425PostulacionesFechaAlta ,
                                             long A948PostulacionesSecUserId ,
                                             short AV17OrderedBy ,
                                             bool AV18OrderedDsc ,
                                             string AV112Postulacioneswwds_1_filterfulltext ,
                                             long A970PostulacionesSolicitudesId ,
                                             long AV144Postulacioneswwds_33_tfpostulacionessolicitudesid ,
                                             long AV145Postulacioneswwds_34_tfpostulacionessolicitudesid_to )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int5 = new short[64];
         Object[] GXv_Object6 = new Object[2];
         scmdbuf = "SELECT T1.[PostulacionesSecUserId], T1.[PostulacionesFechaAlta], T1.[PostulacionesTelefono], T1.[PostulacionesMail], T1.[PostulacionesApellidoNombre], T1.[PostulacionesRgoHoraservicio], T1.[PostulacionesTipoFecha], T1.[PostulacionesHoraCierre], T1.[PostulacionesFechaCierre], T1.[PostulacionesFechaTrabajo], T1.[PostulacionesSuministrosDescri], T1.[PostulacionesReqSuministros], T1.[PostulacionesDescripcion], T1.[PostulacionesMultimediaSerial], T1.[PostulacionesPrecio], T3.[ProveedorNombre] AS PostulacionesProveedorNombre, T2.[ServiciosNombre], T1.[ServiciosId], T1.[PostulacionesId], T1.[PostulacionesProveedorId] AS PostulacionesProveedorId, T1.[PostulacionesEstado], COALESCE( T4.[PostulacionesSolicitudesId], 0) AS PostulacionesSolicitudesId FROM (([Postulaciones] T1 LEFT JOIN [Servicios] T2 ON T2.[ServiciosId] = T1.[ServiciosId]) INNER JOIN [Proveedor] T3 ON T3.[ProveedorID] = T1.[PostulacionesProveedorId]),  (SELECT MIN([SolicitudesID]) AS PostulacionesSolicitudesId FROM [Solicitudes] WHERE [PostulacionesId] = @PostulacionesId ) T4";
         AddWhere(sWhereString, "((@AV144Postulacioneswwds_33_tfpostulacionessolicitudesid = convert(int, 0)) or ( COALESCE( T4.[PostulacionesSolicitudesId], 0) >= @AV144Postulacioneswwds_33_tfpostulacionessolicitudesid))");
         AddWhere(sWhereString, "((@AV145Postulacioneswwds_34_tfpostulacionessolicitudesid_to = convert(int, 0)) or ( COALESCE( T4.[PostulacionesSolicitudesId], 0) <= @AV145Postulacioneswwds_34_tfpostulacionessolicitudesid_to))");
         if ( ( StringUtil.StrCmp(AV113Postulacioneswwds_2_dynamicfiltersselector1, "POSTULACIONESPROVEEDORNOMBRE") == 0 ) && ( AV114Postulacioneswwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV115Postulacioneswwds_4_postulacionesproveedornombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T3.[ProveedorNombre]) like UPPER(@lV115Postulacioneswwds_4_postulacionesproveedornombre1))");
         }
         else
         {
            GXv_int5[5] = 1;
         }
         if ( ( StringUtil.StrCmp(AV113Postulacioneswwds_2_dynamicfiltersselector1, "POSTULACIONESPROVEEDORNOMBRE") == 0 ) && ( AV114Postulacioneswwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV115Postulacioneswwds_4_postulacionesproveedornombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T3.[ProveedorNombre]) like '%' + UPPER(@lV115Postulacioneswwds_4_postulacionesproveedornombre1))");
         }
         else
         {
            GXv_int5[6] = 1;
         }
         if ( ( StringUtil.StrCmp(AV113Postulacioneswwds_2_dynamicfiltersselector1, "POSTULACIONESPROVEEDORID") == 0 ) && ( AV114Postulacioneswwds_3_dynamicfiltersoperator1 == 0 ) && ( ! (0==AV116Postulacioneswwds_5_postulacionesproveedorid1) ) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesProveedorId] < @AV116Postulacioneswwds_5_postulacionesproveedorid1)");
         }
         else
         {
            GXv_int5[7] = 1;
         }
         if ( ( StringUtil.StrCmp(AV113Postulacioneswwds_2_dynamicfiltersselector1, "POSTULACIONESPROVEEDORID") == 0 ) && ( AV114Postulacioneswwds_3_dynamicfiltersoperator1 == 1 ) && ( ! (0==AV116Postulacioneswwds_5_postulacionesproveedorid1) ) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesProveedorId] = @AV116Postulacioneswwds_5_postulacionesproveedorid1)");
         }
         else
         {
            GXv_int5[8] = 1;
         }
         if ( ( StringUtil.StrCmp(AV113Postulacioneswwds_2_dynamicfiltersselector1, "POSTULACIONESPROVEEDORID") == 0 ) && ( AV114Postulacioneswwds_3_dynamicfiltersoperator1 == 2 ) && ( ! (0==AV116Postulacioneswwds_5_postulacionesproveedorid1) ) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesProveedorId] > @AV116Postulacioneswwds_5_postulacionesproveedorid1)");
         }
         else
         {
            GXv_int5[9] = 1;
         }
         if ( ( StringUtil.StrCmp(AV113Postulacioneswwds_2_dynamicfiltersselector1, "SERVICIOSNOMBRE") == 0 ) && ( AV114Postulacioneswwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV117Postulacioneswwds_6_serviciosnombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ServiciosNombre]) like UPPER(@lV117Postulacioneswwds_6_serviciosnombre1))");
         }
         else
         {
            GXv_int5[10] = 1;
         }
         if ( ( StringUtil.StrCmp(AV113Postulacioneswwds_2_dynamicfiltersselector1, "SERVICIOSNOMBRE") == 0 ) && ( AV114Postulacioneswwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV117Postulacioneswwds_6_serviciosnombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ServiciosNombre]) like '%' + UPPER(@lV117Postulacioneswwds_6_serviciosnombre1))");
         }
         else
         {
            GXv_int5[11] = 1;
         }
         if ( AV118Postulacioneswwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV119Postulacioneswwds_8_dynamicfiltersselector2, "POSTULACIONESPROVEEDORNOMBRE") == 0 ) && ( AV120Postulacioneswwds_9_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV121Postulacioneswwds_10_postulacionesproveedornombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T3.[ProveedorNombre]) like UPPER(@lV121Postulacioneswwds_10_postulacionesproveedornombre2))");
         }
         else
         {
            GXv_int5[12] = 1;
         }
         if ( AV118Postulacioneswwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV119Postulacioneswwds_8_dynamicfiltersselector2, "POSTULACIONESPROVEEDORNOMBRE") == 0 ) && ( AV120Postulacioneswwds_9_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV121Postulacioneswwds_10_postulacionesproveedornombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T3.[ProveedorNombre]) like '%' + UPPER(@lV121Postulacioneswwds_10_postulacionesproveedornombre2))");
         }
         else
         {
            GXv_int5[13] = 1;
         }
         if ( AV118Postulacioneswwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV119Postulacioneswwds_8_dynamicfiltersselector2, "POSTULACIONESPROVEEDORID") == 0 ) && ( AV120Postulacioneswwds_9_dynamicfiltersoperator2 == 0 ) && ( ! (0==AV122Postulacioneswwds_11_postulacionesproveedorid2) ) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesProveedorId] < @AV122Postulacioneswwds_11_postulacionesproveedorid2)");
         }
         else
         {
            GXv_int5[14] = 1;
         }
         if ( AV118Postulacioneswwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV119Postulacioneswwds_8_dynamicfiltersselector2, "POSTULACIONESPROVEEDORID") == 0 ) && ( AV120Postulacioneswwds_9_dynamicfiltersoperator2 == 1 ) && ( ! (0==AV122Postulacioneswwds_11_postulacionesproveedorid2) ) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesProveedorId] = @AV122Postulacioneswwds_11_postulacionesproveedorid2)");
         }
         else
         {
            GXv_int5[15] = 1;
         }
         if ( AV118Postulacioneswwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV119Postulacioneswwds_8_dynamicfiltersselector2, "POSTULACIONESPROVEEDORID") == 0 ) && ( AV120Postulacioneswwds_9_dynamicfiltersoperator2 == 2 ) && ( ! (0==AV122Postulacioneswwds_11_postulacionesproveedorid2) ) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesProveedorId] > @AV122Postulacioneswwds_11_postulacionesproveedorid2)");
         }
         else
         {
            GXv_int5[16] = 1;
         }
         if ( AV118Postulacioneswwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV119Postulacioneswwds_8_dynamicfiltersselector2, "SERVICIOSNOMBRE") == 0 ) && ( AV120Postulacioneswwds_9_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV123Postulacioneswwds_12_serviciosnombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ServiciosNombre]) like UPPER(@lV123Postulacioneswwds_12_serviciosnombre2))");
         }
         else
         {
            GXv_int5[17] = 1;
         }
         if ( AV118Postulacioneswwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV119Postulacioneswwds_8_dynamicfiltersselector2, "SERVICIOSNOMBRE") == 0 ) && ( AV120Postulacioneswwds_9_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV123Postulacioneswwds_12_serviciosnombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ServiciosNombre]) like '%' + UPPER(@lV123Postulacioneswwds_12_serviciosnombre2))");
         }
         else
         {
            GXv_int5[18] = 1;
         }
         if ( AV124Postulacioneswwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV125Postulacioneswwds_14_dynamicfiltersselector3, "POSTULACIONESPROVEEDORNOMBRE") == 0 ) && ( AV126Postulacioneswwds_15_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV127Postulacioneswwds_16_postulacionesproveedornombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T3.[ProveedorNombre]) like UPPER(@lV127Postulacioneswwds_16_postulacionesproveedornombre3))");
         }
         else
         {
            GXv_int5[19] = 1;
         }
         if ( AV124Postulacioneswwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV125Postulacioneswwds_14_dynamicfiltersselector3, "POSTULACIONESPROVEEDORNOMBRE") == 0 ) && ( AV126Postulacioneswwds_15_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV127Postulacioneswwds_16_postulacionesproveedornombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T3.[ProveedorNombre]) like '%' + UPPER(@lV127Postulacioneswwds_16_postulacionesproveedornombre3))");
         }
         else
         {
            GXv_int5[20] = 1;
         }
         if ( AV124Postulacioneswwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV125Postulacioneswwds_14_dynamicfiltersselector3, "POSTULACIONESPROVEEDORID") == 0 ) && ( AV126Postulacioneswwds_15_dynamicfiltersoperator3 == 0 ) && ( ! (0==AV128Postulacioneswwds_17_postulacionesproveedorid3) ) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesProveedorId] < @AV128Postulacioneswwds_17_postulacionesproveedorid3)");
         }
         else
         {
            GXv_int5[21] = 1;
         }
         if ( AV124Postulacioneswwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV125Postulacioneswwds_14_dynamicfiltersselector3, "POSTULACIONESPROVEEDORID") == 0 ) && ( AV126Postulacioneswwds_15_dynamicfiltersoperator3 == 1 ) && ( ! (0==AV128Postulacioneswwds_17_postulacionesproveedorid3) ) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesProveedorId] = @AV128Postulacioneswwds_17_postulacionesproveedorid3)");
         }
         else
         {
            GXv_int5[22] = 1;
         }
         if ( AV124Postulacioneswwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV125Postulacioneswwds_14_dynamicfiltersselector3, "POSTULACIONESPROVEEDORID") == 0 ) && ( AV126Postulacioneswwds_15_dynamicfiltersoperator3 == 2 ) && ( ! (0==AV128Postulacioneswwds_17_postulacionesproveedorid3) ) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesProveedorId] > @AV128Postulacioneswwds_17_postulacionesproveedorid3)");
         }
         else
         {
            GXv_int5[23] = 1;
         }
         if ( AV124Postulacioneswwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV125Postulacioneswwds_14_dynamicfiltersselector3, "SERVICIOSNOMBRE") == 0 ) && ( AV126Postulacioneswwds_15_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV129Postulacioneswwds_18_serviciosnombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ServiciosNombre]) like UPPER(@lV129Postulacioneswwds_18_serviciosnombre3))");
         }
         else
         {
            GXv_int5[24] = 1;
         }
         if ( AV124Postulacioneswwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV125Postulacioneswwds_14_dynamicfiltersselector3, "SERVICIOSNOMBRE") == 0 ) && ( AV126Postulacioneswwds_15_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV129Postulacioneswwds_18_serviciosnombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ServiciosNombre]) like '%' + UPPER(@lV129Postulacioneswwds_18_serviciosnombre3))");
         }
         else
         {
            GXv_int5[25] = 1;
         }
         if ( ! (0==AV130Postulacioneswwds_19_tfpostulacionesid) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesId] >= @AV130Postulacioneswwds_19_tfpostulacionesid)");
         }
         else
         {
            GXv_int5[26] = 1;
         }
         if ( ! (0==AV131Postulacioneswwds_20_tfpostulacionesid_to) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesId] <= @AV131Postulacioneswwds_20_tfpostulacionesid_to)");
         }
         else
         {
            GXv_int5[27] = 1;
         }
         if ( ! (0==AV132Postulacioneswwds_21_tfserviciosid) )
         {
            AddWhere(sWhereString, "(T1.[ServiciosId] >= @AV132Postulacioneswwds_21_tfserviciosid)");
         }
         else
         {
            GXv_int5[28] = 1;
         }
         if ( ! (0==AV133Postulacioneswwds_22_tfserviciosid_to) )
         {
            AddWhere(sWhereString, "(T1.[ServiciosId] <= @AV133Postulacioneswwds_22_tfserviciosid_to)");
         }
         else
         {
            GXv_int5[29] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV135Postulacioneswwds_24_tfserviciosnombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV134Postulacioneswwds_23_tfserviciosnombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ServiciosNombre]) like UPPER(@lV134Postulacioneswwds_23_tfserviciosnombre))");
         }
         else
         {
            GXv_int5[30] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV135Postulacioneswwds_24_tfserviciosnombre_sel)) && ! ( StringUtil.StrCmp(AV135Postulacioneswwds_24_tfserviciosnombre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.[ServiciosNombre] = @AV135Postulacioneswwds_24_tfserviciosnombre_sel)");
         }
         else
         {
            GXv_int5[31] = 1;
         }
         if ( StringUtil.StrCmp(AV135Postulacioneswwds_24_tfserviciosnombre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T2.[ServiciosNombre] IS NULL or (T2.[ServiciosNombre] = ''))");
         }
         if ( ! (0==AV136Postulacioneswwds_25_tfpostulacionesproveedorid) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesProveedorId] >= @AV136Postulacioneswwds_25_tfpostulacionesproveedorid)");
         }
         else
         {
            GXv_int5[32] = 1;
         }
         if ( ! (0==AV137Postulacioneswwds_26_tfpostulacionesproveedorid_to) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesProveedorId] <= @AV137Postulacioneswwds_26_tfpostulacionesproveedorid_to)");
         }
         else
         {
            GXv_int5[33] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV139Postulacioneswwds_28_tfpostulacionesproveedornombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV138Postulacioneswwds_27_tfpostulacionesproveedornombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T3.[ProveedorNombre]) like UPPER(@lV138Postulacioneswwds_27_tfpostulacionesproveedornombre))");
         }
         else
         {
            GXv_int5[34] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV139Postulacioneswwds_28_tfpostulacionesproveedornombre_sel)) && ! ( StringUtil.StrCmp(AV139Postulacioneswwds_28_tfpostulacionesproveedornombre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T3.[ProveedorNombre] = @AV139Postulacioneswwds_28_tfpostulacionesproveedornombre_sel)");
         }
         else
         {
            GXv_int5[35] = 1;
         }
         if ( StringUtil.StrCmp(AV139Postulacioneswwds_28_tfpostulacionesproveedornombre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T3.[ProveedorNombre] = ''))");
         }
         if ( ! (Convert.ToDecimal(0)==AV140Postulacioneswwds_29_tfpostulacionesprecio) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesPrecio] >= @AV140Postulacioneswwds_29_tfpostulacionesprecio)");
         }
         else
         {
            GXv_int5[36] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV141Postulacioneswwds_30_tfpostulacionesprecio_to) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesPrecio] <= @AV141Postulacioneswwds_30_tfpostulacionesprecio_to)");
         }
         else
         {
            GXv_int5[37] = 1;
         }
         if ( ! (0==AV142Postulacioneswwds_31_tfpostulacionesmultimediaserial) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesMultimediaSerial] >= @AV142Postulacioneswwds_31_tfpostulacionesmultimediaserial)");
         }
         else
         {
            GXv_int5[38] = 1;
         }
         if ( ! (0==AV143Postulacioneswwds_32_tfpostulacionesmultimediaserial_to) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesMultimediaSerial] <= @AV143Postulacioneswwds_32_tfpostulacionesmultimediaserial_to)");
         }
         else
         {
            GXv_int5[39] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV147Postulacioneswwds_36_tfpostulacionesdescripcion_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV146Postulacioneswwds_35_tfpostulacionesdescripcion)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[PostulacionesDescripcion]) like UPPER(@lV146Postulacioneswwds_35_tfpostulacionesdescripcion))");
         }
         else
         {
            GXv_int5[40] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV147Postulacioneswwds_36_tfpostulacionesdescripcion_sel)) && ! ( StringUtil.StrCmp(AV147Postulacioneswwds_36_tfpostulacionesdescripcion_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesDescripcion] = @AV147Postulacioneswwds_36_tfpostulacionesdescripcion_sel)");
         }
         else
         {
            GXv_int5[41] = 1;
         }
         if ( StringUtil.StrCmp(AV147Postulacioneswwds_36_tfpostulacionesdescripcion_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[PostulacionesDescripcion] = ''))");
         }
         if ( AV148Postulacioneswwds_37_tfpostulacionesreqsuministros_sel == 1 )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesReqSuministros] = 1)");
         }
         if ( AV148Postulacioneswwds_37_tfpostulacionesreqsuministros_sel == 2 )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesReqSuministros] = 0)");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV150Postulacioneswwds_39_tfpostulacionessuministrosdescripcion_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV149Postulacioneswwds_38_tfpostulacionessuministrosdescripcion)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[PostulacionesSuministrosDescri]) like UPPER(@lV149Postulacioneswwds_38_tfpostulacionessuministrosdescripcion))");
         }
         else
         {
            GXv_int5[42] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV150Postulacioneswwds_39_tfpostulacionessuministrosdescripcion_sel)) && ! ( StringUtil.StrCmp(AV150Postulacioneswwds_39_tfpostulacionessuministrosdescripcion_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesSuministrosDescri] = @AV150Postulacioneswwds_39_tfpostulacionessuministrosdescripcion_sel)");
         }
         else
         {
            GXv_int5[43] = 1;
         }
         if ( StringUtil.StrCmp(AV150Postulacioneswwds_39_tfpostulacionessuministrosdescripcion_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[PostulacionesSuministrosDescri] = ''))");
         }
         if ( ! (DateTime.MinValue==AV151Postulacioneswwds_40_tfpostulacionesfechatrabajo) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesFechaTrabajo] >= @AV151Postulacioneswwds_40_tfpostulacionesfechatrabajo)");
         }
         else
         {
            GXv_int5[44] = 1;
         }
         if ( ! (DateTime.MinValue==AV152Postulacioneswwds_41_tfpostulacionesfechatrabajo_to) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesFechaTrabajo] <= @AV152Postulacioneswwds_41_tfpostulacionesfechatrabajo_to)");
         }
         else
         {
            GXv_int5[45] = 1;
         }
         if ( ! (DateTime.MinValue==AV153Postulacioneswwds_42_tfpostulacionesfechacierre) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesFechaCierre] >= @AV153Postulacioneswwds_42_tfpostulacionesfechacierre)");
         }
         else
         {
            GXv_int5[46] = 1;
         }
         if ( ! (DateTime.MinValue==AV154Postulacioneswwds_43_tfpostulacionesfechacierre_to) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesFechaCierre] <= @AV154Postulacioneswwds_43_tfpostulacionesfechacierre_to)");
         }
         else
         {
            GXv_int5[47] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV156Postulacioneswwds_45_tfpostulacioneshoracierre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV155Postulacioneswwds_44_tfpostulacioneshoracierre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[PostulacionesHoraCierre]) like UPPER(@lV155Postulacioneswwds_44_tfpostulacioneshoracierre))");
         }
         else
         {
            GXv_int5[48] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV156Postulacioneswwds_45_tfpostulacioneshoracierre_sel)) && ! ( StringUtil.StrCmp(AV156Postulacioneswwds_45_tfpostulacioneshoracierre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesHoraCierre] = @AV156Postulacioneswwds_45_tfpostulacioneshoracierre_sel)");
         }
         else
         {
            GXv_int5[49] = 1;
         }
         if ( StringUtil.StrCmp(AV156Postulacioneswwds_45_tfpostulacioneshoracierre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[PostulacionesHoraCierre] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV158Postulacioneswwds_47_tfpostulacionestipofecha_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV157Postulacioneswwds_46_tfpostulacionestipofecha)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[PostulacionesTipoFecha]) like UPPER(@lV157Postulacioneswwds_46_tfpostulacionestipofecha))");
         }
         else
         {
            GXv_int5[50] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV158Postulacioneswwds_47_tfpostulacionestipofecha_sel)) && ! ( StringUtil.StrCmp(AV158Postulacioneswwds_47_tfpostulacionestipofecha_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesTipoFecha] = @AV158Postulacioneswwds_47_tfpostulacionestipofecha_sel)");
         }
         else
         {
            GXv_int5[51] = 1;
         }
         if ( StringUtil.StrCmp(AV158Postulacioneswwds_47_tfpostulacionestipofecha_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[PostulacionesTipoFecha] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV160Postulacioneswwds_49_tfpostulacionesrgohoraservicio_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV159Postulacioneswwds_48_tfpostulacionesrgohoraservicio)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[PostulacionesRgoHoraservicio]) like UPPER(@lV159Postulacioneswwds_48_tfpostulacionesrgohoraservicio))");
         }
         else
         {
            GXv_int5[52] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV160Postulacioneswwds_49_tfpostulacionesrgohoraservicio_sel)) && ! ( StringUtil.StrCmp(AV160Postulacioneswwds_49_tfpostulacionesrgohoraservicio_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesRgoHoraservicio] = @AV160Postulacioneswwds_49_tfpostulacionesrgohoraservicio_sel)");
         }
         else
         {
            GXv_int5[53] = 1;
         }
         if ( StringUtil.StrCmp(AV160Postulacioneswwds_49_tfpostulacionesrgohoraservicio_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[PostulacionesRgoHoraservicio] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV162Postulacioneswwds_51_tfpostulacionesapellidonombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV161Postulacioneswwds_50_tfpostulacionesapellidonombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[PostulacionesApellidoNombre]) like UPPER(@lV161Postulacioneswwds_50_tfpostulacionesapellidonombre))");
         }
         else
         {
            GXv_int5[54] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV162Postulacioneswwds_51_tfpostulacionesapellidonombre_sel)) && ! ( StringUtil.StrCmp(AV162Postulacioneswwds_51_tfpostulacionesapellidonombre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesApellidoNombre] = @AV162Postulacioneswwds_51_tfpostulacionesapellidonombre_sel)");
         }
         else
         {
            GXv_int5[55] = 1;
         }
         if ( StringUtil.StrCmp(AV162Postulacioneswwds_51_tfpostulacionesapellidonombre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[PostulacionesApellidoNombre] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV164Postulacioneswwds_53_tfpostulacionesmail_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV163Postulacioneswwds_52_tfpostulacionesmail)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[PostulacionesMail]) like UPPER(@lV163Postulacioneswwds_52_tfpostulacionesmail))");
         }
         else
         {
            GXv_int5[56] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV164Postulacioneswwds_53_tfpostulacionesmail_sel)) && ! ( StringUtil.StrCmp(AV164Postulacioneswwds_53_tfpostulacionesmail_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesMail] = @AV164Postulacioneswwds_53_tfpostulacionesmail_sel)");
         }
         else
         {
            GXv_int5[57] = 1;
         }
         if ( StringUtil.StrCmp(AV164Postulacioneswwds_53_tfpostulacionesmail_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[PostulacionesMail] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV166Postulacioneswwds_55_tfpostulacionestelefono_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV165Postulacioneswwds_54_tfpostulacionestelefono)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[PostulacionesTelefono]) like UPPER(@lV165Postulacioneswwds_54_tfpostulacionestelefono))");
         }
         else
         {
            GXv_int5[58] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV166Postulacioneswwds_55_tfpostulacionestelefono_sel)) && ! ( StringUtil.StrCmp(AV166Postulacioneswwds_55_tfpostulacionestelefono_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesTelefono] = @AV166Postulacioneswwds_55_tfpostulacionestelefono_sel)");
         }
         else
         {
            GXv_int5[59] = 1;
         }
         if ( StringUtil.StrCmp(AV166Postulacioneswwds_55_tfpostulacionestelefono_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[PostulacionesTelefono] = ''))");
         }
         if ( ! (DateTime.MinValue==AV167Postulacioneswwds_56_tfpostulacionesfechaalta) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesFechaAlta] >= @AV167Postulacioneswwds_56_tfpostulacionesfechaalta)");
         }
         else
         {
            GXv_int5[60] = 1;
         }
         if ( ! (DateTime.MinValue==AV168Postulacioneswwds_57_tfpostulacionesfechaalta_to) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesFechaAlta] <= @AV168Postulacioneswwds_57_tfpostulacionesfechaalta_to)");
         }
         else
         {
            GXv_int5[61] = 1;
         }
         if ( AV169Postulacioneswwds_58_tfpostulacionesestado_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV169Postulacioneswwds_58_tfpostulacionesestado_sels, "T1.[PostulacionesEstado] IN (", ")")+")");
         }
         if ( ! (0==AV170Postulacioneswwds_59_tfpostulacionessecuserid) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesSecUserId] >= @AV170Postulacioneswwds_59_tfpostulacionessecuserid)");
         }
         else
         {
            GXv_int5[62] = 1;
         }
         if ( ! (0==AV171Postulacioneswwds_60_tfpostulacionessecuserid_to) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesSecUserId] <= @AV171Postulacioneswwds_60_tfpostulacionessecuserid_to)");
         }
         else
         {
            GXv_int5[63] = 1;
         }
         scmdbuf += sWhereString;
         if ( ( AV17OrderedBy == 1 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T3.[ProveedorNombre]";
         }
         else if ( ( AV17OrderedBy == 1 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T3.[ProveedorNombre] DESC";
         }
         else if ( ( AV17OrderedBy == 2 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[PostulacionesProveedorId]";
         }
         else if ( ( AV17OrderedBy == 2 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[PostulacionesProveedorId] DESC";
         }
         else if ( ( AV17OrderedBy == 3 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[PostulacionesId]";
         }
         else if ( ( AV17OrderedBy == 3 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[PostulacionesId] DESC";
         }
         else if ( ( AV17OrderedBy == 4 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[ServiciosId]";
         }
         else if ( ( AV17OrderedBy == 4 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[ServiciosId] DESC";
         }
         else if ( ( AV17OrderedBy == 5 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T2.[ServiciosNombre]";
         }
         else if ( ( AV17OrderedBy == 5 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T2.[ServiciosNombre] DESC";
         }
         else if ( ( AV17OrderedBy == 6 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[PostulacionesPrecio]";
         }
         else if ( ( AV17OrderedBy == 6 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[PostulacionesPrecio] DESC";
         }
         else if ( ( AV17OrderedBy == 7 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[PostulacionesMultimediaSerial]";
         }
         else if ( ( AV17OrderedBy == 7 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[PostulacionesMultimediaSerial] DESC";
         }
         else if ( ( AV17OrderedBy == 8 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[PostulacionesDescripcion]";
         }
         else if ( ( AV17OrderedBy == 8 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[PostulacionesDescripcion] DESC";
         }
         else if ( ( AV17OrderedBy == 9 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[PostulacionesReqSuministros]";
         }
         else if ( ( AV17OrderedBy == 9 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[PostulacionesReqSuministros] DESC";
         }
         else if ( ( AV17OrderedBy == 10 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[PostulacionesSuministrosDescri]";
         }
         else if ( ( AV17OrderedBy == 10 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[PostulacionesSuministrosDescri] DESC";
         }
         else if ( ( AV17OrderedBy == 11 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[PostulacionesFechaTrabajo]";
         }
         else if ( ( AV17OrderedBy == 11 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[PostulacionesFechaTrabajo] DESC";
         }
         else if ( ( AV17OrderedBy == 12 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[PostulacionesFechaCierre]";
         }
         else if ( ( AV17OrderedBy == 12 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[PostulacionesFechaCierre] DESC";
         }
         else if ( ( AV17OrderedBy == 13 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[PostulacionesHoraCierre]";
         }
         else if ( ( AV17OrderedBy == 13 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[PostulacionesHoraCierre] DESC";
         }
         else if ( ( AV17OrderedBy == 14 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[PostulacionesTipoFecha]";
         }
         else if ( ( AV17OrderedBy == 14 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[PostulacionesTipoFecha] DESC";
         }
         else if ( ( AV17OrderedBy == 15 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[PostulacionesRgoHoraservicio]";
         }
         else if ( ( AV17OrderedBy == 15 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[PostulacionesRgoHoraservicio] DESC";
         }
         else if ( ( AV17OrderedBy == 16 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[PostulacionesApellidoNombre]";
         }
         else if ( ( AV17OrderedBy == 16 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[PostulacionesApellidoNombre] DESC";
         }
         else if ( ( AV17OrderedBy == 17 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[PostulacionesMail]";
         }
         else if ( ( AV17OrderedBy == 17 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[PostulacionesMail] DESC";
         }
         else if ( ( AV17OrderedBy == 18 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[PostulacionesTelefono]";
         }
         else if ( ( AV17OrderedBy == 18 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[PostulacionesTelefono] DESC";
         }
         else if ( ( AV17OrderedBy == 19 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[PostulacionesFechaAlta]";
         }
         else if ( ( AV17OrderedBy == 19 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[PostulacionesFechaAlta] DESC";
         }
         else if ( ( AV17OrderedBy == 20 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[PostulacionesEstado]";
         }
         else if ( ( AV17OrderedBy == 20 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[PostulacionesEstado] DESC";
         }
         else if ( ( AV17OrderedBy == 21 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[PostulacionesSecUserId]";
         }
         else if ( ( AV17OrderedBy == 21 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[PostulacionesSecUserId] DESC";
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
                     return conditional_P00LB3(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (long)dynConstraints[5] , (string)dynConstraints[6] , (bool)dynConstraints[7] , (string)dynConstraints[8] , (short)dynConstraints[9] , (string)dynConstraints[10] , (long)dynConstraints[11] , (string)dynConstraints[12] , (bool)dynConstraints[13] , (string)dynConstraints[14] , (short)dynConstraints[15] , (string)dynConstraints[16] , (long)dynConstraints[17] , (string)dynConstraints[18] , (long)dynConstraints[19] , (long)dynConstraints[20] , (long)dynConstraints[21] , (long)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (long)dynConstraints[25] , (long)dynConstraints[26] , (string)dynConstraints[27] , (string)dynConstraints[28] , (decimal)dynConstraints[29] , (decimal)dynConstraints[30] , (short)dynConstraints[31] , (short)dynConstraints[32] , (string)dynConstraints[33] , (string)dynConstraints[34] , (short)dynConstraints[35] , (string)dynConstraints[36] , (string)dynConstraints[37] , (DateTime)dynConstraints[38] , (DateTime)dynConstraints[39] , (DateTime)dynConstraints[40] , (DateTime)dynConstraints[41] , (string)dynConstraints[42] , (string)dynConstraints[43] , (string)dynConstraints[44] , (string)dynConstraints[45] , (string)dynConstraints[46] , (string)dynConstraints[47] , (string)dynConstraints[48] , (string)dynConstraints[49] , (string)dynConstraints[50] , (string)dynConstraints[51] , (string)dynConstraints[52] , (string)dynConstraints[53] , (DateTime)dynConstraints[54] , (DateTime)dynConstraints[55] , (int)dynConstraints[56] , (long)dynConstraints[57] , (long)dynConstraints[58] , (string)dynConstraints[59] , (long)dynConstraints[60] , (string)dynConstraints[61] , (long)dynConstraints[62] , (long)dynConstraints[63] , (decimal)dynConstraints[64] , (short)dynConstraints[65] , (string)dynConstraints[66] , (bool)dynConstraints[67] , (string)dynConstraints[68] , (DateTime)dynConstraints[69] , (DateTime)dynConstraints[70] , (string)dynConstraints[71] , (string)dynConstraints[72] , (string)dynConstraints[73] , (string)dynConstraints[74] , (string)dynConstraints[75] , (string)dynConstraints[76] , (DateTime)dynConstraints[77] , (long)dynConstraints[78] , (short)dynConstraints[79] , (bool)dynConstraints[80] , (string)dynConstraints[81] , (long)dynConstraints[82] , (long)dynConstraints[83] , (long)dynConstraints[84] );
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
          Object[] prmP00LB3;
          prmP00LB3 = new Object[] {
          new ParDef("@PostulacionesId",GXType.Decimal,18,0){Nullable=true} ,
          new ParDef("@AV144Postulacioneswwds_33_tfpostulacionessolicitudesid",GXType.Decimal,18,0) ,
          new ParDef("@AV144Postulacioneswwds_33_tfpostulacionessolicitudesid",GXType.Decimal,18,0) ,
          new ParDef("@AV145Postulacioneswwds_34_tfpostulacionessolicitudesid_to",GXType.Decimal,18,0) ,
          new ParDef("@AV145Postulacioneswwds_34_tfpostulacionessolicitudesid_to",GXType.Decimal,18,0) ,
          new ParDef("@lV115Postulacioneswwds_4_postulacionesproveedornombre1",GXType.Char,80,0) ,
          new ParDef("@lV115Postulacioneswwds_4_postulacionesproveedornombre1",GXType.Char,80,0) ,
          new ParDef("@AV116Postulacioneswwds_5_postulacionesproveedorid1",GXType.Decimal,18,0) ,
          new ParDef("@AV116Postulacioneswwds_5_postulacionesproveedorid1",GXType.Decimal,18,0) ,
          new ParDef("@AV116Postulacioneswwds_5_postulacionesproveedorid1",GXType.Decimal,18,0) ,
          new ParDef("@lV117Postulacioneswwds_6_serviciosnombre1",GXType.Char,80,0) ,
          new ParDef("@lV117Postulacioneswwds_6_serviciosnombre1",GXType.Char,80,0) ,
          new ParDef("@lV121Postulacioneswwds_10_postulacionesproveedornombre2",GXType.Char,80,0) ,
          new ParDef("@lV121Postulacioneswwds_10_postulacionesproveedornombre2",GXType.Char,80,0) ,
          new ParDef("@AV122Postulacioneswwds_11_postulacionesproveedorid2",GXType.Decimal,18,0) ,
          new ParDef("@AV122Postulacioneswwds_11_postulacionesproveedorid2",GXType.Decimal,18,0) ,
          new ParDef("@AV122Postulacioneswwds_11_postulacionesproveedorid2",GXType.Decimal,18,0) ,
          new ParDef("@lV123Postulacioneswwds_12_serviciosnombre2",GXType.Char,80,0) ,
          new ParDef("@lV123Postulacioneswwds_12_serviciosnombre2",GXType.Char,80,0) ,
          new ParDef("@lV127Postulacioneswwds_16_postulacionesproveedornombre3",GXType.Char,80,0) ,
          new ParDef("@lV127Postulacioneswwds_16_postulacionesproveedornombre3",GXType.Char,80,0) ,
          new ParDef("@AV128Postulacioneswwds_17_postulacionesproveedorid3",GXType.Decimal,18,0) ,
          new ParDef("@AV128Postulacioneswwds_17_postulacionesproveedorid3",GXType.Decimal,18,0) ,
          new ParDef("@AV128Postulacioneswwds_17_postulacionesproveedorid3",GXType.Decimal,18,0) ,
          new ParDef("@lV129Postulacioneswwds_18_serviciosnombre3",GXType.Char,80,0) ,
          new ParDef("@lV129Postulacioneswwds_18_serviciosnombre3",GXType.Char,80,0) ,
          new ParDef("@AV130Postulacioneswwds_19_tfpostulacionesid",GXType.Decimal,18,0) ,
          new ParDef("@AV131Postulacioneswwds_20_tfpostulacionesid_to",GXType.Decimal,18,0) ,
          new ParDef("@AV132Postulacioneswwds_21_tfserviciosid",GXType.Decimal,18,0) ,
          new ParDef("@AV133Postulacioneswwds_22_tfserviciosid_to",GXType.Decimal,18,0) ,
          new ParDef("@lV134Postulacioneswwds_23_tfserviciosnombre",GXType.Char,80,0) ,
          new ParDef("@AV135Postulacioneswwds_24_tfserviciosnombre_sel",GXType.NChar,80,0) ,
          new ParDef("@AV136Postulacioneswwds_25_tfpostulacionesproveedorid",GXType.Decimal,18,0) ,
          new ParDef("@AV137Postulacioneswwds_26_tfpostulacionesproveedorid_to",GXType.Decimal,18,0) ,
          new ParDef("@lV138Postulacioneswwds_27_tfpostulacionesproveedornombre",GXType.Char,80,0) ,
          new ParDef("@AV139Postulacioneswwds_28_tfpostulacionesproveedornombre_sel",GXType.NChar,80,0) ,
          new ParDef("@AV140Postulacioneswwds_29_tfpostulacionesprecio",GXType.Decimal,18,2) ,
          new ParDef("@AV141Postulacioneswwds_30_tfpostulacionesprecio_to",GXType.Decimal,18,2) ,
          new ParDef("@AV142Postulacioneswwds_31_tfpostulacionesmultimediaserial",GXType.Int16,4,0) ,
          new ParDef("@AV143Postulacioneswwds_32_tfpostulacionesmultimediaserial_to",GXType.Int16,4,0) ,
          new ParDef("@lV146Postulacioneswwds_35_tfpostulacionesdescripcion",GXType.Char,2000,0) ,
          new ParDef("@AV147Postulacioneswwds_36_tfpostulacionesdescripcion_sel",GXType.NChar,2000,0) ,
          new ParDef("@lV149Postulacioneswwds_38_tfpostulacionessuministrosdescripcion",GXType.Char,250,0) ,
          new ParDef("@AV150Postulacioneswwds_39_tfpostulacionessuministrosdescripcion_sel",GXType.NChar,250,0) ,
          new ParDef("@AV151Postulacioneswwds_40_tfpostulacionesfechatrabajo",GXType.Date,8,0) ,
          new ParDef("@AV152Postulacioneswwds_41_tfpostulacionesfechatrabajo_to",GXType.Date,8,0) ,
          new ParDef("@AV153Postulacioneswwds_42_tfpostulacionesfechacierre",GXType.Date,8,0) ,
          new ParDef("@AV154Postulacioneswwds_43_tfpostulacionesfechacierre_to",GXType.Date,8,0) ,
          new ParDef("@lV155Postulacioneswwds_44_tfpostulacioneshoracierre",GXType.VarChar,8,5) ,
          new ParDef("@AV156Postulacioneswwds_45_tfpostulacioneshoracierre_sel",GXType.NVarChar,8,5) ,
          new ParDef("@lV157Postulacioneswwds_46_tfpostulacionestipofecha",GXType.VarChar,10,0) ,
          new ParDef("@AV158Postulacioneswwds_47_tfpostulacionestipofecha_sel",GXType.NVarChar,10,0) ,
          new ParDef("@lV159Postulacioneswwds_48_tfpostulacionesrgohoraservicio",GXType.Char,5,0) ,
          new ParDef("@AV160Postulacioneswwds_49_tfpostulacionesrgohoraservicio_sel",GXType.NChar,5,0) ,
          new ParDef("@lV161Postulacioneswwds_50_tfpostulacionesapellidonombre",GXType.Char,80,0) ,
          new ParDef("@AV162Postulacioneswwds_51_tfpostulacionesapellidonombre_sel",GXType.NChar,80,0) ,
          new ParDef("@lV163Postulacioneswwds_52_tfpostulacionesmail",GXType.VarChar,100,0) ,
          new ParDef("@AV164Postulacioneswwds_53_tfpostulacionesmail_sel",GXType.NVarChar,100,0) ,
          new ParDef("@lV165Postulacioneswwds_54_tfpostulacionestelefono",GXType.Char,20,0) ,
          new ParDef("@AV166Postulacioneswwds_55_tfpostulacionestelefono_sel",GXType.NChar,20,0) ,
          new ParDef("@AV167Postulacioneswwds_56_tfpostulacionesfechaalta",GXType.DateTime,8,5) ,
          new ParDef("@AV168Postulacioneswwds_57_tfpostulacionesfechaalta_to",GXType.DateTime,8,5) ,
          new ParDef("@AV170Postulacioneswwds_59_tfpostulacionessecuserid",GXType.Decimal,18,0) ,
          new ParDef("@AV171Postulacioneswwds_60_tfpostulacionessecuserid_to",GXType.Decimal,18,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00LB3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00LB3,100, GxCacheFrequency.OFF ,true,false )
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
                ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 20);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((string[]) buf[4])[0] = rslt.getString(5, 80);
                ((string[]) buf[5])[0] = rslt.getString(6, 5);
                ((string[]) buf[6])[0] = rslt.getVarchar(7);
                ((string[]) buf[7])[0] = rslt.getVarchar(8);
                ((DateTime[]) buf[8])[0] = rslt.getGXDate(9);
                ((DateTime[]) buf[9])[0] = rslt.getGXDate(10);
                ((string[]) buf[10])[0] = rslt.getString(11, 250);
                ((bool[]) buf[11])[0] = rslt.getBool(12);
                ((string[]) buf[12])[0] = rslt.getString(13, 2000);
                ((short[]) buf[13])[0] = rslt.getShort(14);
                ((decimal[]) buf[14])[0] = rslt.getDecimal(15);
                ((string[]) buf[15])[0] = rslt.getString(16, 80);
                ((string[]) buf[16])[0] = rslt.getString(17, 80);
                ((long[]) buf[17])[0] = rslt.getLong(18);
                ((bool[]) buf[18])[0] = rslt.wasNull(18);
                ((long[]) buf[19])[0] = rslt.getLong(19);
                ((long[]) buf[20])[0] = rslt.getLong(20);
                ((string[]) buf[21])[0] = rslt.getString(21, 3);
                ((long[]) buf[22])[0] = rslt.getLong(22);
                ((bool[]) buf[23])[0] = rslt.wasNull(22);
                return;
       }
    }

 }

}

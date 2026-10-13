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
   public class profcomisioneswwexport : GXProcedure
   {
      public profcomisioneswwexport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public profcomisioneswwexport( IGxContext context )
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
         new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWProfComisiones", out  GXt_boolean1) ;
         AV8IsAuthorized = GXt_boolean1;
         if ( ! AV8IsAuthorized )
         {
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "wwpbaseobjects.notauthorized.aspx"+GXUtil.UrlEncode(StringUtil.RTrim(AV65Pgmname));
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
         AV12Filename = GXt_char2 + "ProfComisionesWWExport-" + StringUtil.Trim( StringUtil.Str( (decimal)(AV16Random), 8, 0)) + ".xlsx";
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
            if ( StringUtil.StrCmp(AV20DynamicFiltersSelector1, "PROFCOMISIONESAUTOENUN") == 0 )
            {
               AV21DynamicFiltersOperator1 = AV34GridStateDynamicFilter.gxTpr_Operator;
               AV22ProfComisionesAutoEnun1 = (short)(Math.Round(NumberUtil.Val( AV34GridStateDynamicFilter.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               if ( ! (0==AV22ProfComisionesAutoEnun1) )
               {
                  AV14CellRow = (int)(AV14CellRow+1);
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Bold = 1;
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Color = 3;
                  if ( AV21DynamicFiltersOperator1 == 0 )
                  {
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", context.GetMessage( "Auto Enun", ""), "<", "", "", "", "", "", "", "");
                  }
                  else if ( AV21DynamicFiltersOperator1 == 1 )
                  {
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", context.GetMessage( "Auto Enun", ""), "=", "", "", "", "", "", "", "");
                  }
                  else if ( AV21DynamicFiltersOperator1 == 2 )
                  {
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", context.GetMessage( "Auto Enun", ""), ">", "", "", "", "", "", "", "");
                  }
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Italic = 1;
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Number = AV22ProfComisionesAutoEnun1;
               }
            }
            else if ( StringUtil.StrCmp(AV20DynamicFiltersSelector1, "PROFESIONALESPRIMERNOMBRE") == 0 )
            {
               AV21DynamicFiltersOperator1 = AV34GridStateDynamicFilter.gxTpr_Operator;
               AV23ProfesionalesPrimerNombre1 = AV34GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV23ProfesionalesPrimerNombre1)) )
               {
                  AV14CellRow = (int)(AV14CellRow+1);
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Bold = 1;
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Color = 3;
                  if ( AV21DynamicFiltersOperator1 == 0 )
                  {
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", context.GetMessage( "Primer Nombre", ""), context.GetMessage( "WWP_FilterLike", ""), "", "", "", "", "", "", "");
                  }
                  else if ( AV21DynamicFiltersOperator1 == 1 )
                  {
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", context.GetMessage( "Primer Nombre", ""), context.GetMessage( "WWP_FilterContains", ""), "", "", "", "", "", "", "");
                  }
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Italic = 1;
                  GXt_char2 = "";
                  new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV23ProfesionalesPrimerNombre1, out  GXt_char2) ;
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
               }
            }
            if ( AV37GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV24DynamicFiltersEnabled2 = true;
               AV34GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV37GridState.gxTpr_Dynamicfilters.Item(2));
               AV25DynamicFiltersSelector2 = AV34GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV25DynamicFiltersSelector2, "PROFCOMISIONESAUTOENUN") == 0 )
               {
                  AV26DynamicFiltersOperator2 = AV34GridStateDynamicFilter.gxTpr_Operator;
                  AV27ProfComisionesAutoEnun2 = (short)(Math.Round(NumberUtil.Val( AV34GridStateDynamicFilter.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
                  if ( ! (0==AV27ProfComisionesAutoEnun2) )
                  {
                     AV14CellRow = (int)(AV14CellRow+1);
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Bold = 1;
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Color = 3;
                     if ( AV26DynamicFiltersOperator2 == 0 )
                     {
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", context.GetMessage( "Auto Enun", ""), "<", "", "", "", "", "", "", "");
                     }
                     else if ( AV26DynamicFiltersOperator2 == 1 )
                     {
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", context.GetMessage( "Auto Enun", ""), "=", "", "", "", "", "", "", "");
                     }
                     else if ( AV26DynamicFiltersOperator2 == 2 )
                     {
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", context.GetMessage( "Auto Enun", ""), ">", "", "", "", "", "", "", "");
                     }
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Italic = 1;
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Number = AV27ProfComisionesAutoEnun2;
                  }
               }
               else if ( StringUtil.StrCmp(AV25DynamicFiltersSelector2, "PROFESIONALESPRIMERNOMBRE") == 0 )
               {
                  AV26DynamicFiltersOperator2 = AV34GridStateDynamicFilter.gxTpr_Operator;
                  AV28ProfesionalesPrimerNombre2 = AV34GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV28ProfesionalesPrimerNombre2)) )
                  {
                     AV14CellRow = (int)(AV14CellRow+1);
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Bold = 1;
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Color = 3;
                     if ( AV26DynamicFiltersOperator2 == 0 )
                     {
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", context.GetMessage( "Primer Nombre", ""), context.GetMessage( "WWP_FilterLike", ""), "", "", "", "", "", "", "");
                     }
                     else if ( AV26DynamicFiltersOperator2 == 1 )
                     {
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", context.GetMessage( "Primer Nombre", ""), context.GetMessage( "WWP_FilterContains", ""), "", "", "", "", "", "", "");
                     }
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Italic = 1;
                     GXt_char2 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV28ProfesionalesPrimerNombre2, out  GXt_char2) ;
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
                  }
               }
               if ( AV37GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV29DynamicFiltersEnabled3 = true;
                  AV34GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV37GridState.gxTpr_Dynamicfilters.Item(3));
                  AV30DynamicFiltersSelector3 = AV34GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV30DynamicFiltersSelector3, "PROFCOMISIONESAUTOENUN") == 0 )
                  {
                     AV31DynamicFiltersOperator3 = AV34GridStateDynamicFilter.gxTpr_Operator;
                     AV32ProfComisionesAutoEnun3 = (short)(Math.Round(NumberUtil.Val( AV34GridStateDynamicFilter.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
                     if ( ! (0==AV32ProfComisionesAutoEnun3) )
                     {
                        AV14CellRow = (int)(AV14CellRow+1);
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Bold = 1;
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Color = 3;
                        if ( AV31DynamicFiltersOperator3 == 0 )
                        {
                           AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", context.GetMessage( "Auto Enun", ""), "<", "", "", "", "", "", "", "");
                        }
                        else if ( AV31DynamicFiltersOperator3 == 1 )
                        {
                           AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", context.GetMessage( "Auto Enun", ""), "=", "", "", "", "", "", "", "");
                        }
                        else if ( AV31DynamicFiltersOperator3 == 2 )
                        {
                           AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", context.GetMessage( "Auto Enun", ""), ">", "", "", "", "", "", "", "");
                        }
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Italic = 1;
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Number = AV32ProfComisionesAutoEnun3;
                     }
                  }
                  else if ( StringUtil.StrCmp(AV30DynamicFiltersSelector3, "PROFESIONALESPRIMERNOMBRE") == 0 )
                  {
                     AV31DynamicFiltersOperator3 = AV34GridStateDynamicFilter.gxTpr_Operator;
                     AV33ProfesionalesPrimerNombre3 = AV34GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV33ProfesionalesPrimerNombre3)) )
                     {
                        AV14CellRow = (int)(AV14CellRow+1);
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Bold = 1;
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Color = 3;
                        if ( AV31DynamicFiltersOperator3 == 0 )
                        {
                           AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", context.GetMessage( "Primer Nombre", ""), context.GetMessage( "WWP_FilterLike", ""), "", "", "", "", "", "", "");
                        }
                        else if ( AV31DynamicFiltersOperator3 == 1 )
                        {
                           AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", context.GetMessage( "Primer Nombre", ""), context.GetMessage( "WWP_FilterContains", ""), "", "", "", "", "", "", "");
                        }
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Italic = 1;
                        GXt_char2 = "";
                        new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV33ProfesionalesPrimerNombre3, out  GXt_char2) ;
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
                     }
                  }
               }
            }
         }
         if ( ! ( (0==AV50TFProfComisionesID) && (0==AV51TFProfComisionesID_To) ) )
         {
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Comisiones ID", "")) ;
            AV14CellRow = GXt_int3;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Number = AV50TFProfComisionesID;
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  false, ref  GXt_int3,  (short)(AV15FirstColumn+2),  context.GetMessage( "WWP_TSTo", "")) ;
            AV14CellRow = GXt_int3;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+3, 1, 1).Number = AV51TFProfComisionesID_To;
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV53TFProfesionalesId_Sel)) ) )
         {
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Identidad", "")) ;
            AV14CellRow = GXt_int3;
            GXt_char2 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV53TFProfesionalesId_Sel)) ? context.GetMessage( "WWP_TitleFilter_EmptyOption", "") : AV53TFProfesionalesId_Sel), out  GXt_char2) ;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV52TFProfesionalesId)) ) )
            {
               GXt_int3 = (short)(AV14CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Identidad", "")) ;
               AV14CellRow = GXt_int3;
               GXt_char2 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV52TFProfesionalesId, out  GXt_char2) ;
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV55TFProfesionalesPrimerNombre_Sel)) ) )
         {
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Primer Nombre", "")) ;
            AV14CellRow = GXt_int3;
            GXt_char2 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV55TFProfesionalesPrimerNombre_Sel)) ? context.GetMessage( "WWP_TitleFilter_EmptyOption", "") : AV55TFProfesionalesPrimerNombre_Sel), out  GXt_char2) ;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV54TFProfesionalesPrimerNombre)) ) )
            {
               GXt_int3 = (short)(AV14CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Primer Nombre", "")) ;
               AV14CellRow = GXt_int3;
               GXt_char2 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV54TFProfesionalesPrimerNombre, out  GXt_char2) ;
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV57TFProfesionalesSegundoNombre_Sel)) ) )
         {
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Segundo Nombre", "")) ;
            AV14CellRow = GXt_int3;
            GXt_char2 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV57TFProfesionalesSegundoNombre_Sel)) ? context.GetMessage( "WWP_TitleFilter_EmptyOption", "") : AV57TFProfesionalesSegundoNombre_Sel), out  GXt_char2) ;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV56TFProfesionalesSegundoNombre)) ) )
            {
               GXt_int3 = (short)(AV14CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Segundo Nombre", "")) ;
               AV14CellRow = GXt_int3;
               GXt_char2 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV56TFProfesionalesSegundoNombre, out  GXt_char2) ;
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV59TFProfesionalesApellidoPrimero_Sel)) ) )
         {
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Primero Apellido ", "")) ;
            AV14CellRow = GXt_int3;
            GXt_char2 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV59TFProfesionalesApellidoPrimero_Sel)) ? context.GetMessage( "WWP_TitleFilter_EmptyOption", "") : AV59TFProfesionalesApellidoPrimero_Sel), out  GXt_char2) ;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV58TFProfesionalesApellidoPrimero)) ) )
            {
               GXt_int3 = (short)(AV14CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Primero Apellido ", "")) ;
               AV14CellRow = GXt_int3;
               GXt_char2 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV58TFProfesionalesApellidoPrimero, out  GXt_char2) ;
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV61TFProfesionalesApellidoSegundo_Sel)) ) )
         {
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Segundo Apellido ", "")) ;
            AV14CellRow = GXt_int3;
            GXt_char2 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV61TFProfesionalesApellidoSegundo_Sel)) ? context.GetMessage( "WWP_TitleFilter_EmptyOption", "") : AV61TFProfesionalesApellidoSegundo_Sel), out  GXt_char2) ;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV60TFProfesionalesApellidoSegundo)) ) )
            {
               GXt_int3 = (short)(AV14CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Segundo Apellido ", "")) ;
               AV14CellRow = GXt_int3;
               GXt_char2 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV60TFProfesionalesApellidoSegundo, out  GXt_char2) ;
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV63TFProfesionalesTelefono_Sel)) ) )
         {
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Teléfono", "")) ;
            AV14CellRow = GXt_int3;
            GXt_char2 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV63TFProfesionalesTelefono_Sel)) ? context.GetMessage( "WWP_TitleFilter_EmptyOption", "") : AV63TFProfesionalesTelefono_Sel), out  GXt_char2) ;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV62TFProfesionalesTelefono)) ) )
            {
               GXt_int3 = (short)(AV14CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Teléfono", "")) ;
               AV14CellRow = GXt_int3;
               GXt_char2 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV62TFProfesionalesTelefono, out  GXt_char2) ;
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
         if ( StringUtil.StrCmp(AV35Session.Get("ProfComisionesWWColumnsSelector"), "") != 0 )
         {
            AV42ColumnsSelectorXML = AV35Session.Get("ProfComisionesWWColumnsSelector");
            AV39ColumnsSelector.FromXml(AV42ColumnsSelectorXML, null, "", "");
         }
         else
         {
            /* Execute user subroutine: 'INITIALIZECOLUMNSSELECTOR' */
            S151 ();
            if (returnInSub) return;
         }
         AV39ColumnsSelector.gxTpr_Columns.Sort("Order");
         AV66GXV1 = 1;
         while ( AV66GXV1 <= AV39ColumnsSelector.gxTpr_Columns.Count )
         {
            AV41ColumnsSelector_Column = ((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV39ColumnsSelector.gxTpr_Columns.Item(AV66GXV1));
            if ( AV41ColumnsSelector_Column.gxTpr_Isvisible )
            {
               AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV47VisibleColumnCount), 1, 1).Text = context.GetMessage( (String.IsNullOrEmpty(StringUtil.RTrim( AV41ColumnsSelector_Column.gxTpr_Displayname)) ? AV41ColumnsSelector_Column.gxTpr_Columnname : AV41ColumnsSelector_Column.gxTpr_Displayname), "");
               AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV47VisibleColumnCount), 1, 1).Bold = 1;
               AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV47VisibleColumnCount), 1, 1).Color = 11;
               AV47VisibleColumnCount = (long)(AV47VisibleColumnCount+1);
            }
            AV66GXV1 = (int)(AV66GXV1+1);
         }
      }

      protected void S161( )
      {
         /* 'WRITEDATA' Routine */
         returnInSub = false;
         AV68Profcomisioneswwds_1_filterfulltext = AV19FilterFullText;
         AV69Profcomisioneswwds_2_dynamicfiltersselector1 = AV20DynamicFiltersSelector1;
         AV70Profcomisioneswwds_3_dynamicfiltersoperator1 = AV21DynamicFiltersOperator1;
         AV71Profcomisioneswwds_4_profcomisionesautoenun1 = AV22ProfComisionesAutoEnun1;
         AV72Profcomisioneswwds_5_profesionalesprimernombre1 = AV23ProfesionalesPrimerNombre1;
         AV73Profcomisioneswwds_6_dynamicfiltersenabled2 = AV24DynamicFiltersEnabled2;
         AV74Profcomisioneswwds_7_dynamicfiltersselector2 = AV25DynamicFiltersSelector2;
         AV75Profcomisioneswwds_8_dynamicfiltersoperator2 = AV26DynamicFiltersOperator2;
         AV76Profcomisioneswwds_9_profcomisionesautoenun2 = AV27ProfComisionesAutoEnun2;
         AV77Profcomisioneswwds_10_profesionalesprimernombre2 = AV28ProfesionalesPrimerNombre2;
         AV78Profcomisioneswwds_11_dynamicfiltersenabled3 = AV29DynamicFiltersEnabled3;
         AV79Profcomisioneswwds_12_dynamicfiltersselector3 = AV30DynamicFiltersSelector3;
         AV80Profcomisioneswwds_13_dynamicfiltersoperator3 = AV31DynamicFiltersOperator3;
         AV81Profcomisioneswwds_14_profcomisionesautoenun3 = AV32ProfComisionesAutoEnun3;
         AV82Profcomisioneswwds_15_profesionalesprimernombre3 = AV33ProfesionalesPrimerNombre3;
         AV83Profcomisioneswwds_16_tfprofcomisionesid = AV50TFProfComisionesID;
         AV84Profcomisioneswwds_17_tfprofcomisionesid_to = AV51TFProfComisionesID_To;
         AV85Profcomisioneswwds_18_tfprofesionalesid = AV52TFProfesionalesId;
         AV86Profcomisioneswwds_19_tfprofesionalesid_sel = AV53TFProfesionalesId_Sel;
         AV87Profcomisioneswwds_20_tfprofesionalesprimernombre = AV54TFProfesionalesPrimerNombre;
         AV88Profcomisioneswwds_21_tfprofesionalesprimernombre_sel = AV55TFProfesionalesPrimerNombre_Sel;
         AV89Profcomisioneswwds_22_tfprofesionalessegundonombre = AV56TFProfesionalesSegundoNombre;
         AV90Profcomisioneswwds_23_tfprofesionalessegundonombre_sel = AV57TFProfesionalesSegundoNombre_Sel;
         AV91Profcomisioneswwds_24_tfprofesionalesapellidoprimero = AV58TFProfesionalesApellidoPrimero;
         AV92Profcomisioneswwds_25_tfprofesionalesapellidoprimero_sel = AV59TFProfesionalesApellidoPrimero_Sel;
         AV93Profcomisioneswwds_26_tfprofesionalesapellidosegundo = AV60TFProfesionalesApellidoSegundo;
         AV94Profcomisioneswwds_27_tfprofesionalesapellidosegundo_sel = AV61TFProfesionalesApellidoSegundo_Sel;
         AV95Profcomisioneswwds_28_tfprofesionalestelefono = AV62TFProfesionalesTelefono;
         AV96Profcomisioneswwds_29_tfprofesionalestelefono_sel = AV63TFProfesionalesTelefono_Sel;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV68Profcomisioneswwds_1_filterfulltext ,
                                              AV69Profcomisioneswwds_2_dynamicfiltersselector1 ,
                                              AV70Profcomisioneswwds_3_dynamicfiltersoperator1 ,
                                              AV71Profcomisioneswwds_4_profcomisionesautoenun1 ,
                                              AV72Profcomisioneswwds_5_profesionalesprimernombre1 ,
                                              AV73Profcomisioneswwds_6_dynamicfiltersenabled2 ,
                                              AV74Profcomisioneswwds_7_dynamicfiltersselector2 ,
                                              AV75Profcomisioneswwds_8_dynamicfiltersoperator2 ,
                                              AV76Profcomisioneswwds_9_profcomisionesautoenun2 ,
                                              AV77Profcomisioneswwds_10_profesionalesprimernombre2 ,
                                              AV78Profcomisioneswwds_11_dynamicfiltersenabled3 ,
                                              AV79Profcomisioneswwds_12_dynamicfiltersselector3 ,
                                              AV80Profcomisioneswwds_13_dynamicfiltersoperator3 ,
                                              AV81Profcomisioneswwds_14_profcomisionesautoenun3 ,
                                              AV82Profcomisioneswwds_15_profesionalesprimernombre3 ,
                                              AV83Profcomisioneswwds_16_tfprofcomisionesid ,
                                              AV84Profcomisioneswwds_17_tfprofcomisionesid_to ,
                                              AV86Profcomisioneswwds_19_tfprofesionalesid_sel ,
                                              AV85Profcomisioneswwds_18_tfprofesionalesid ,
                                              AV88Profcomisioneswwds_21_tfprofesionalesprimernombre_sel ,
                                              AV87Profcomisioneswwds_20_tfprofesionalesprimernombre ,
                                              AV90Profcomisioneswwds_23_tfprofesionalessegundonombre_sel ,
                                              AV89Profcomisioneswwds_22_tfprofesionalessegundonombre ,
                                              AV92Profcomisioneswwds_25_tfprofesionalesapellidoprimero_sel ,
                                              AV91Profcomisioneswwds_24_tfprofesionalesapellidoprimero ,
                                              AV94Profcomisioneswwds_27_tfprofesionalesapellidosegundo_sel ,
                                              AV93Profcomisioneswwds_26_tfprofesionalesapellidosegundo ,
                                              AV96Profcomisioneswwds_29_tfprofesionalestelefono_sel ,
                                              AV95Profcomisioneswwds_28_tfprofesionalestelefono ,
                                              A450ProfComisionesID ,
                                              A120ProfesionalesId ,
                                              A166ProfesionalesPrimerNombre ,
                                              A191ProfesionalesSegundoNombre ,
                                              A167ProfesionalesApellidoPrimero ,
                                              A192ProfesionalesApellidoSegundo ,
                                              A170ProfesionalesTelefono ,
                                              A451ProfComisionesAutoEnun ,
                                              AV17OrderedBy ,
                                              AV18OrderedDsc } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.LONG,
                                              TypeConstants.LONG, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV68Profcomisioneswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV68Profcomisioneswwds_1_filterfulltext), "%", "");
         lV68Profcomisioneswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV68Profcomisioneswwds_1_filterfulltext), "%", "");
         lV68Profcomisioneswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV68Profcomisioneswwds_1_filterfulltext), "%", "");
         lV68Profcomisioneswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV68Profcomisioneswwds_1_filterfulltext), "%", "");
         lV68Profcomisioneswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV68Profcomisioneswwds_1_filterfulltext), "%", "");
         lV68Profcomisioneswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV68Profcomisioneswwds_1_filterfulltext), "%", "");
         lV68Profcomisioneswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV68Profcomisioneswwds_1_filterfulltext), "%", "");
         lV72Profcomisioneswwds_5_profesionalesprimernombre1 = StringUtil.PadR( StringUtil.RTrim( AV72Profcomisioneswwds_5_profesionalesprimernombre1), 30, "%");
         lV72Profcomisioneswwds_5_profesionalesprimernombre1 = StringUtil.PadR( StringUtil.RTrim( AV72Profcomisioneswwds_5_profesionalesprimernombre1), 30, "%");
         lV77Profcomisioneswwds_10_profesionalesprimernombre2 = StringUtil.PadR( StringUtil.RTrim( AV77Profcomisioneswwds_10_profesionalesprimernombre2), 30, "%");
         lV77Profcomisioneswwds_10_profesionalesprimernombre2 = StringUtil.PadR( StringUtil.RTrim( AV77Profcomisioneswwds_10_profesionalesprimernombre2), 30, "%");
         lV82Profcomisioneswwds_15_profesionalesprimernombre3 = StringUtil.PadR( StringUtil.RTrim( AV82Profcomisioneswwds_15_profesionalesprimernombre3), 30, "%");
         lV82Profcomisioneswwds_15_profesionalesprimernombre3 = StringUtil.PadR( StringUtil.RTrim( AV82Profcomisioneswwds_15_profesionalesprimernombre3), 30, "%");
         lV85Profcomisioneswwds_18_tfprofesionalesid = StringUtil.PadR( StringUtil.RTrim( AV85Profcomisioneswwds_18_tfprofesionalesid), 20, "%");
         lV87Profcomisioneswwds_20_tfprofesionalesprimernombre = StringUtil.PadR( StringUtil.RTrim( AV87Profcomisioneswwds_20_tfprofesionalesprimernombre), 30, "%");
         lV89Profcomisioneswwds_22_tfprofesionalessegundonombre = StringUtil.PadR( StringUtil.RTrim( AV89Profcomisioneswwds_22_tfprofesionalessegundonombre), 30, "%");
         lV91Profcomisioneswwds_24_tfprofesionalesapellidoprimero = StringUtil.PadR( StringUtil.RTrim( AV91Profcomisioneswwds_24_tfprofesionalesapellidoprimero), 30, "%");
         lV93Profcomisioneswwds_26_tfprofesionalesapellidosegundo = StringUtil.PadR( StringUtil.RTrim( AV93Profcomisioneswwds_26_tfprofesionalesapellidosegundo), 30, "%");
         lV95Profcomisioneswwds_28_tfprofesionalestelefono = StringUtil.PadR( StringUtil.RTrim( AV95Profcomisioneswwds_28_tfprofesionalestelefono), 20, "%");
         /* Using cursor P005U2 */
         pr_default.execute(0, new Object[] {lV68Profcomisioneswwds_1_filterfulltext, lV68Profcomisioneswwds_1_filterfulltext, lV68Profcomisioneswwds_1_filterfulltext, lV68Profcomisioneswwds_1_filterfulltext, lV68Profcomisioneswwds_1_filterfulltext, lV68Profcomisioneswwds_1_filterfulltext, lV68Profcomisioneswwds_1_filterfulltext, AV71Profcomisioneswwds_4_profcomisionesautoenun1, AV71Profcomisioneswwds_4_profcomisionesautoenun1, AV71Profcomisioneswwds_4_profcomisionesautoenun1, lV72Profcomisioneswwds_5_profesionalesprimernombre1, lV72Profcomisioneswwds_5_profesionalesprimernombre1, AV76Profcomisioneswwds_9_profcomisionesautoenun2, AV76Profcomisioneswwds_9_profcomisionesautoenun2, AV76Profcomisioneswwds_9_profcomisionesautoenun2, lV77Profcomisioneswwds_10_profesionalesprimernombre2, lV77Profcomisioneswwds_10_profesionalesprimernombre2, AV81Profcomisioneswwds_14_profcomisionesautoenun3, AV81Profcomisioneswwds_14_profcomisionesautoenun3, AV81Profcomisioneswwds_14_profcomisionesautoenun3, lV82Profcomisioneswwds_15_profesionalesprimernombre3, lV82Profcomisioneswwds_15_profesionalesprimernombre3, AV83Profcomisioneswwds_16_tfprofcomisionesid, AV84Profcomisioneswwds_17_tfprofcomisionesid_to, lV85Profcomisioneswwds_18_tfprofesionalesid, AV86Profcomisioneswwds_19_tfprofesionalesid_sel, lV87Profcomisioneswwds_20_tfprofesionalesprimernombre, AV88Profcomisioneswwds_21_tfprofesionalesprimernombre_sel, lV89Profcomisioneswwds_22_tfprofesionalessegundonombre, AV90Profcomisioneswwds_23_tfprofesionalessegundonombre_sel, lV91Profcomisioneswwds_24_tfprofesionalesapellidoprimero, AV92Profcomisioneswwds_25_tfprofesionalesapellidoprimero_sel, lV93Profcomisioneswwds_26_tfprofesionalesapellidosegundo, AV94Profcomisioneswwds_27_tfprofesionalesapellidosegundo_sel, lV95Profcomisioneswwds_28_tfprofesionalestelefono, AV96Profcomisioneswwds_29_tfprofesionalestelefono_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A170ProfesionalesTelefono = P005U2_A170ProfesionalesTelefono[0];
            A192ProfesionalesApellidoSegundo = P005U2_A192ProfesionalesApellidoSegundo[0];
            A167ProfesionalesApellidoPrimero = P005U2_A167ProfesionalesApellidoPrimero[0];
            A191ProfesionalesSegundoNombre = P005U2_A191ProfesionalesSegundoNombre[0];
            A166ProfesionalesPrimerNombre = P005U2_A166ProfesionalesPrimerNombre[0];
            A120ProfesionalesId = P005U2_A120ProfesionalesId[0];
            A450ProfComisionesID = P005U2_A450ProfComisionesID[0];
            A451ProfComisionesAutoEnun = P005U2_A451ProfComisionesAutoEnun[0];
            A170ProfesionalesTelefono = P005U2_A170ProfesionalesTelefono[0];
            A192ProfesionalesApellidoSegundo = P005U2_A192ProfesionalesApellidoSegundo[0];
            A167ProfesionalesApellidoPrimero = P005U2_A167ProfesionalesApellidoPrimero[0];
            A191ProfesionalesSegundoNombre = P005U2_A191ProfesionalesSegundoNombre[0];
            A166ProfesionalesPrimerNombre = P005U2_A166ProfesionalesPrimerNombre[0];
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
            AV97GXV2 = 1;
            while ( AV97GXV2 <= AV39ColumnsSelector.gxTpr_Columns.Count )
            {
               AV41ColumnsSelector_Column = ((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV39ColumnsSelector.gxTpr_Columns.Item(AV97GXV2));
               if ( AV41ColumnsSelector_Column.gxTpr_Isvisible )
               {
                  if ( StringUtil.StrCmp(AV41ColumnsSelector_Column.gxTpr_Columnname, "ProfComisionesID") == 0 )
                  {
                     AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV47VisibleColumnCount), 1, 1).Number = A450ProfComisionesID;
                  }
                  else if ( StringUtil.StrCmp(AV41ColumnsSelector_Column.gxTpr_Columnname, "ProfesionalesId") == 0 )
                  {
                     GXt_char2 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A120ProfesionalesId, out  GXt_char2) ;
                     AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV47VisibleColumnCount), 1, 1).Text = GXt_char2;
                  }
                  else if ( StringUtil.StrCmp(AV41ColumnsSelector_Column.gxTpr_Columnname, "ProfesionalesPrimerNombre") == 0 )
                  {
                     GXt_char2 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A166ProfesionalesPrimerNombre, out  GXt_char2) ;
                     AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV47VisibleColumnCount), 1, 1).Text = GXt_char2;
                  }
                  else if ( StringUtil.StrCmp(AV41ColumnsSelector_Column.gxTpr_Columnname, "ProfesionalesSegundoNombre") == 0 )
                  {
                     GXt_char2 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A191ProfesionalesSegundoNombre, out  GXt_char2) ;
                     AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV47VisibleColumnCount), 1, 1).Text = GXt_char2;
                  }
                  else if ( StringUtil.StrCmp(AV41ColumnsSelector_Column.gxTpr_Columnname, "ProfesionalesApellidoPrimero") == 0 )
                  {
                     GXt_char2 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A167ProfesionalesApellidoPrimero, out  GXt_char2) ;
                     AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV47VisibleColumnCount), 1, 1).Text = GXt_char2;
                  }
                  else if ( StringUtil.StrCmp(AV41ColumnsSelector_Column.gxTpr_Columnname, "ProfesionalesApellidoSegundo") == 0 )
                  {
                     GXt_char2 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A192ProfesionalesApellidoSegundo, out  GXt_char2) ;
                     AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV47VisibleColumnCount), 1, 1).Text = GXt_char2;
                  }
                  else if ( StringUtil.StrCmp(AV41ColumnsSelector_Column.gxTpr_Columnname, "ProfesionalesTelefono") == 0 )
                  {
                     GXt_char2 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A170ProfesionalesTelefono, out  GXt_char2) ;
                     AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV47VisibleColumnCount), 1, 1).Text = GXt_char2;
                  }
                  AV47VisibleColumnCount = (long)(AV47VisibleColumnCount+1);
               }
               AV97GXV2 = (int)(AV97GXV2+1);
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
         AV35Session.Set("WWPExportFileName", "ProfComisionesWWExport.xlsx");
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
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV39ColumnsSelector,  "ProfComisionesID",  "",  "Comisiones ID",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV39ColumnsSelector,  "ProfesionalesId",  "",  "Identidad",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV39ColumnsSelector,  "ProfesionalesPrimerNombre",  "",  "Primer Nombre",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV39ColumnsSelector,  "ProfesionalesSegundoNombre",  "",  "Segundo Nombre",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV39ColumnsSelector,  "ProfesionalesApellidoPrimero",  "",  "Primero Apellido ",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV39ColumnsSelector,  "ProfesionalesApellidoSegundo",  "",  "Segundo Apellido ",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV39ColumnsSelector,  "ProfesionalesTelefono",  "",  "Teléfono",  true,  "") ;
         GXt_char2 = AV43UserCustomValue;
         new GeneXus.Programs.wwpbaseobjects.loadcolumnsselectorstate(context ).execute(  "ProfComisionesWWColumnsSelector", out  GXt_char2) ;
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
         if ( StringUtil.StrCmp(AV35Session.Get("ProfComisionesWWGridState"), "") == 0 )
         {
            AV37GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "ProfComisionesWWGridState"), null, "", "");
         }
         else
         {
            AV37GridState.FromXml(AV35Session.Get("ProfComisionesWWGridState"), null, "", "");
         }
         AV17OrderedBy = AV37GridState.gxTpr_Orderedby;
         AV18OrderedDsc = AV37GridState.gxTpr_Ordereddsc;
         AV98GXV3 = 1;
         while ( AV98GXV3 <= AV37GridState.gxTpr_Filtervalues.Count )
         {
            AV38GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV37GridState.gxTpr_Filtervalues.Item(AV98GXV3));
            if ( StringUtil.StrCmp(AV38GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV19FilterFullText = AV38GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV38GridStateFilterValue.gxTpr_Name, "TFPROFCOMISIONESID") == 0 )
            {
               AV50TFProfComisionesID = (long)(Math.Round(NumberUtil.Val( AV38GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV51TFProfComisionesID_To = (long)(Math.Round(NumberUtil.Val( AV38GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV38GridStateFilterValue.gxTpr_Name, "TFPROFESIONALESID") == 0 )
            {
               AV52TFProfesionalesId = AV38GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV38GridStateFilterValue.gxTpr_Name, "TFPROFESIONALESID_SEL") == 0 )
            {
               AV53TFProfesionalesId_Sel = AV38GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV38GridStateFilterValue.gxTpr_Name, "TFPROFESIONALESPRIMERNOMBRE") == 0 )
            {
               AV54TFProfesionalesPrimerNombre = AV38GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV38GridStateFilterValue.gxTpr_Name, "TFPROFESIONALESPRIMERNOMBRE_SEL") == 0 )
            {
               AV55TFProfesionalesPrimerNombre_Sel = AV38GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV38GridStateFilterValue.gxTpr_Name, "TFPROFESIONALESSEGUNDONOMBRE") == 0 )
            {
               AV56TFProfesionalesSegundoNombre = AV38GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV38GridStateFilterValue.gxTpr_Name, "TFPROFESIONALESSEGUNDONOMBRE_SEL") == 0 )
            {
               AV57TFProfesionalesSegundoNombre_Sel = AV38GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV38GridStateFilterValue.gxTpr_Name, "TFPROFESIONALESAPELLIDOPRIMERO") == 0 )
            {
               AV58TFProfesionalesApellidoPrimero = AV38GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV38GridStateFilterValue.gxTpr_Name, "TFPROFESIONALESAPELLIDOPRIMERO_SEL") == 0 )
            {
               AV59TFProfesionalesApellidoPrimero_Sel = AV38GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV38GridStateFilterValue.gxTpr_Name, "TFPROFESIONALESAPELLIDOSEGUNDO") == 0 )
            {
               AV60TFProfesionalesApellidoSegundo = AV38GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV38GridStateFilterValue.gxTpr_Name, "TFPROFESIONALESAPELLIDOSEGUNDO_SEL") == 0 )
            {
               AV61TFProfesionalesApellidoSegundo_Sel = AV38GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV38GridStateFilterValue.gxTpr_Name, "TFPROFESIONALESTELEFONO") == 0 )
            {
               AV62TFProfesionalesTelefono = AV38GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV38GridStateFilterValue.gxTpr_Name, "TFPROFESIONALESTELEFONO_SEL") == 0 )
            {
               AV63TFProfesionalesTelefono_Sel = AV38GridStateFilterValue.gxTpr_Value;
            }
            AV98GXV3 = (int)(AV98GXV3+1);
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
         AV65Pgmname = "";
         GXKey = "";
         GXEncryptionTmp = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV11ExcelDocument = new ExcelDocumentI();
         AV19FilterFullText = "";
         AV37GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV34GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV20DynamicFiltersSelector1 = "";
         AV23ProfesionalesPrimerNombre1 = "";
         AV25DynamicFiltersSelector2 = "";
         AV28ProfesionalesPrimerNombre2 = "";
         AV30DynamicFiltersSelector3 = "";
         AV33ProfesionalesPrimerNombre3 = "";
         AV53TFProfesionalesId_Sel = "";
         AV52TFProfesionalesId = "";
         AV55TFProfesionalesPrimerNombre_Sel = "";
         AV54TFProfesionalesPrimerNombre = "";
         AV57TFProfesionalesSegundoNombre_Sel = "";
         AV56TFProfesionalesSegundoNombre = "";
         AV59TFProfesionalesApellidoPrimero_Sel = "";
         AV58TFProfesionalesApellidoPrimero = "";
         AV61TFProfesionalesApellidoSegundo_Sel = "";
         AV60TFProfesionalesApellidoSegundo = "";
         AV63TFProfesionalesTelefono_Sel = "";
         AV62TFProfesionalesTelefono = "";
         AV35Session = context.GetSession();
         AV42ColumnsSelectorXML = "";
         AV39ColumnsSelector = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector(context);
         AV41ColumnsSelector_Column = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column(context);
         AV68Profcomisioneswwds_1_filterfulltext = "";
         AV69Profcomisioneswwds_2_dynamicfiltersselector1 = "";
         AV72Profcomisioneswwds_5_profesionalesprimernombre1 = "";
         AV74Profcomisioneswwds_7_dynamicfiltersselector2 = "";
         AV77Profcomisioneswwds_10_profesionalesprimernombre2 = "";
         AV79Profcomisioneswwds_12_dynamicfiltersselector3 = "";
         AV82Profcomisioneswwds_15_profesionalesprimernombre3 = "";
         AV85Profcomisioneswwds_18_tfprofesionalesid = "";
         AV86Profcomisioneswwds_19_tfprofesionalesid_sel = "";
         AV87Profcomisioneswwds_20_tfprofesionalesprimernombre = "";
         AV88Profcomisioneswwds_21_tfprofesionalesprimernombre_sel = "";
         AV89Profcomisioneswwds_22_tfprofesionalessegundonombre = "";
         AV90Profcomisioneswwds_23_tfprofesionalessegundonombre_sel = "";
         AV91Profcomisioneswwds_24_tfprofesionalesapellidoprimero = "";
         AV92Profcomisioneswwds_25_tfprofesionalesapellidoprimero_sel = "";
         AV93Profcomisioneswwds_26_tfprofesionalesapellidosegundo = "";
         AV94Profcomisioneswwds_27_tfprofesionalesapellidosegundo_sel = "";
         AV95Profcomisioneswwds_28_tfprofesionalestelefono = "";
         AV96Profcomisioneswwds_29_tfprofesionalestelefono_sel = "";
         lV68Profcomisioneswwds_1_filterfulltext = "";
         lV72Profcomisioneswwds_5_profesionalesprimernombre1 = "";
         lV77Profcomisioneswwds_10_profesionalesprimernombre2 = "";
         lV82Profcomisioneswwds_15_profesionalesprimernombre3 = "";
         lV85Profcomisioneswwds_18_tfprofesionalesid = "";
         lV87Profcomisioneswwds_20_tfprofesionalesprimernombre = "";
         lV89Profcomisioneswwds_22_tfprofesionalessegundonombre = "";
         lV91Profcomisioneswwds_24_tfprofesionalesapellidoprimero = "";
         lV93Profcomisioneswwds_26_tfprofesionalesapellidosegundo = "";
         lV95Profcomisioneswwds_28_tfprofesionalestelefono = "";
         A120ProfesionalesId = "";
         A166ProfesionalesPrimerNombre = "";
         A191ProfesionalesSegundoNombre = "";
         A167ProfesionalesApellidoPrimero = "";
         A192ProfesionalesApellidoSegundo = "";
         A170ProfesionalesTelefono = "";
         P005U2_A170ProfesionalesTelefono = new string[] {""} ;
         P005U2_A192ProfesionalesApellidoSegundo = new string[] {""} ;
         P005U2_A167ProfesionalesApellidoPrimero = new string[] {""} ;
         P005U2_A191ProfesionalesSegundoNombre = new string[] {""} ;
         P005U2_A166ProfesionalesPrimerNombre = new string[] {""} ;
         P005U2_A120ProfesionalesId = new string[] {""} ;
         P005U2_A450ProfComisionesID = new long[1] ;
         P005U2_A451ProfComisionesAutoEnun = new short[1] ;
         AV43UserCustomValue = "";
         GXt_char2 = "";
         AV40ColumnsSelectorAux = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector(context);
         AV38GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.profcomisioneswwexport__default(),
            new Object[][] {
                new Object[] {
               P005U2_A170ProfesionalesTelefono, P005U2_A192ProfesionalesApellidoSegundo, P005U2_A167ProfesionalesApellidoPrimero, P005U2_A191ProfesionalesSegundoNombre, P005U2_A166ProfesionalesPrimerNombre, P005U2_A120ProfesionalesId, P005U2_A450ProfComisionesID, P005U2_A451ProfComisionesAutoEnun
               }
            }
         );
         AV65Pgmname = "ProfComisionesWWExport";
         /* GeneXus formulas. */
         AV65Pgmname = "ProfComisionesWWExport";
      }

      private short AV21DynamicFiltersOperator1 ;
      private short AV22ProfComisionesAutoEnun1 ;
      private short AV26DynamicFiltersOperator2 ;
      private short AV27ProfComisionesAutoEnun2 ;
      private short AV31DynamicFiltersOperator3 ;
      private short AV32ProfComisionesAutoEnun3 ;
      private short GXt_int3 ;
      private short AV70Profcomisioneswwds_3_dynamicfiltersoperator1 ;
      private short AV71Profcomisioneswwds_4_profcomisionesautoenun1 ;
      private short AV75Profcomisioneswwds_8_dynamicfiltersoperator2 ;
      private short AV76Profcomisioneswwds_9_profcomisionesautoenun2 ;
      private short AV80Profcomisioneswwds_13_dynamicfiltersoperator3 ;
      private short AV81Profcomisioneswwds_14_profcomisionesautoenun3 ;
      private short A451ProfComisionesAutoEnun ;
      private short AV17OrderedBy ;
      private int AV14CellRow ;
      private int AV15FirstColumn ;
      private int AV16Random ;
      private int AV66GXV1 ;
      private int AV97GXV2 ;
      private int AV98GXV3 ;
      private long AV50TFProfComisionesID ;
      private long AV51TFProfComisionesID_To ;
      private long AV47VisibleColumnCount ;
      private long AV83Profcomisioneswwds_16_tfprofcomisionesid ;
      private long AV84Profcomisioneswwds_17_tfprofcomisionesid_to ;
      private long A450ProfComisionesID ;
      private string AV65Pgmname ;
      private string GXKey ;
      private string GXEncryptionTmp ;
      private string AV23ProfesionalesPrimerNombre1 ;
      private string AV28ProfesionalesPrimerNombre2 ;
      private string AV33ProfesionalesPrimerNombre3 ;
      private string AV53TFProfesionalesId_Sel ;
      private string AV52TFProfesionalesId ;
      private string AV55TFProfesionalesPrimerNombre_Sel ;
      private string AV54TFProfesionalesPrimerNombre ;
      private string AV57TFProfesionalesSegundoNombre_Sel ;
      private string AV56TFProfesionalesSegundoNombre ;
      private string AV59TFProfesionalesApellidoPrimero_Sel ;
      private string AV58TFProfesionalesApellidoPrimero ;
      private string AV61TFProfesionalesApellidoSegundo_Sel ;
      private string AV60TFProfesionalesApellidoSegundo ;
      private string AV63TFProfesionalesTelefono_Sel ;
      private string AV62TFProfesionalesTelefono ;
      private string AV72Profcomisioneswwds_5_profesionalesprimernombre1 ;
      private string AV77Profcomisioneswwds_10_profesionalesprimernombre2 ;
      private string AV82Profcomisioneswwds_15_profesionalesprimernombre3 ;
      private string AV85Profcomisioneswwds_18_tfprofesionalesid ;
      private string AV86Profcomisioneswwds_19_tfprofesionalesid_sel ;
      private string AV87Profcomisioneswwds_20_tfprofesionalesprimernombre ;
      private string AV88Profcomisioneswwds_21_tfprofesionalesprimernombre_sel ;
      private string AV89Profcomisioneswwds_22_tfprofesionalessegundonombre ;
      private string AV90Profcomisioneswwds_23_tfprofesionalessegundonombre_sel ;
      private string AV91Profcomisioneswwds_24_tfprofesionalesapellidoprimero ;
      private string AV92Profcomisioneswwds_25_tfprofesionalesapellidoprimero_sel ;
      private string AV93Profcomisioneswwds_26_tfprofesionalesapellidosegundo ;
      private string AV94Profcomisioneswwds_27_tfprofesionalesapellidosegundo_sel ;
      private string AV95Profcomisioneswwds_28_tfprofesionalestelefono ;
      private string AV96Profcomisioneswwds_29_tfprofesionalestelefono_sel ;
      private string lV72Profcomisioneswwds_5_profesionalesprimernombre1 ;
      private string lV77Profcomisioneswwds_10_profesionalesprimernombre2 ;
      private string lV82Profcomisioneswwds_15_profesionalesprimernombre3 ;
      private string lV85Profcomisioneswwds_18_tfprofesionalesid ;
      private string lV87Profcomisioneswwds_20_tfprofesionalesprimernombre ;
      private string lV89Profcomisioneswwds_22_tfprofesionalessegundonombre ;
      private string lV91Profcomisioneswwds_24_tfprofesionalesapellidoprimero ;
      private string lV93Profcomisioneswwds_26_tfprofesionalesapellidosegundo ;
      private string lV95Profcomisioneswwds_28_tfprofesionalestelefono ;
      private string A120ProfesionalesId ;
      private string A166ProfesionalesPrimerNombre ;
      private string A191ProfesionalesSegundoNombre ;
      private string A167ProfesionalesApellidoPrimero ;
      private string A192ProfesionalesApellidoSegundo ;
      private string A170ProfesionalesTelefono ;
      private string GXt_char2 ;
      private bool AV8IsAuthorized ;
      private bool GXt_boolean1 ;
      private bool returnInSub ;
      private bool AV24DynamicFiltersEnabled2 ;
      private bool AV29DynamicFiltersEnabled3 ;
      private bool AV73Profcomisioneswwds_6_dynamicfiltersenabled2 ;
      private bool AV78Profcomisioneswwds_11_dynamicfiltersenabled3 ;
      private bool AV18OrderedDsc ;
      private string AV42ColumnsSelectorXML ;
      private string AV43UserCustomValue ;
      private string AV12Filename ;
      private string AV13ErrorMessage ;
      private string AV19FilterFullText ;
      private string AV20DynamicFiltersSelector1 ;
      private string AV25DynamicFiltersSelector2 ;
      private string AV30DynamicFiltersSelector3 ;
      private string AV68Profcomisioneswwds_1_filterfulltext ;
      private string AV69Profcomisioneswwds_2_dynamicfiltersselector1 ;
      private string AV74Profcomisioneswwds_7_dynamicfiltersselector2 ;
      private string AV79Profcomisioneswwds_12_dynamicfiltersselector3 ;
      private string lV68Profcomisioneswwds_1_filterfulltext ;
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
      private string[] P005U2_A170ProfesionalesTelefono ;
      private string[] P005U2_A192ProfesionalesApellidoSegundo ;
      private string[] P005U2_A167ProfesionalesApellidoPrimero ;
      private string[] P005U2_A191ProfesionalesSegundoNombre ;
      private string[] P005U2_A166ProfesionalesPrimerNombre ;
      private string[] P005U2_A120ProfesionalesId ;
      private long[] P005U2_A450ProfComisionesID ;
      private short[] P005U2_A451ProfComisionesAutoEnun ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector AV40ColumnsSelectorAux ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV38GridStateFilterValue ;
      private string aP0_Filename ;
      private string aP1_ErrorMessage ;
   }

   public class profcomisioneswwexport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P005U2( IGxContext context ,
                                             string AV68Profcomisioneswwds_1_filterfulltext ,
                                             string AV69Profcomisioneswwds_2_dynamicfiltersselector1 ,
                                             short AV70Profcomisioneswwds_3_dynamicfiltersoperator1 ,
                                             short AV71Profcomisioneswwds_4_profcomisionesautoenun1 ,
                                             string AV72Profcomisioneswwds_5_profesionalesprimernombre1 ,
                                             bool AV73Profcomisioneswwds_6_dynamicfiltersenabled2 ,
                                             string AV74Profcomisioneswwds_7_dynamicfiltersselector2 ,
                                             short AV75Profcomisioneswwds_8_dynamicfiltersoperator2 ,
                                             short AV76Profcomisioneswwds_9_profcomisionesautoenun2 ,
                                             string AV77Profcomisioneswwds_10_profesionalesprimernombre2 ,
                                             bool AV78Profcomisioneswwds_11_dynamicfiltersenabled3 ,
                                             string AV79Profcomisioneswwds_12_dynamicfiltersselector3 ,
                                             short AV80Profcomisioneswwds_13_dynamicfiltersoperator3 ,
                                             short AV81Profcomisioneswwds_14_profcomisionesautoenun3 ,
                                             string AV82Profcomisioneswwds_15_profesionalesprimernombre3 ,
                                             long AV83Profcomisioneswwds_16_tfprofcomisionesid ,
                                             long AV84Profcomisioneswwds_17_tfprofcomisionesid_to ,
                                             string AV86Profcomisioneswwds_19_tfprofesionalesid_sel ,
                                             string AV85Profcomisioneswwds_18_tfprofesionalesid ,
                                             string AV88Profcomisioneswwds_21_tfprofesionalesprimernombre_sel ,
                                             string AV87Profcomisioneswwds_20_tfprofesionalesprimernombre ,
                                             string AV90Profcomisioneswwds_23_tfprofesionalessegundonombre_sel ,
                                             string AV89Profcomisioneswwds_22_tfprofesionalessegundonombre ,
                                             string AV92Profcomisioneswwds_25_tfprofesionalesapellidoprimero_sel ,
                                             string AV91Profcomisioneswwds_24_tfprofesionalesapellidoprimero ,
                                             string AV94Profcomisioneswwds_27_tfprofesionalesapellidosegundo_sel ,
                                             string AV93Profcomisioneswwds_26_tfprofesionalesapellidosegundo ,
                                             string AV96Profcomisioneswwds_29_tfprofesionalestelefono_sel ,
                                             string AV95Profcomisioneswwds_28_tfprofesionalestelefono ,
                                             long A450ProfComisionesID ,
                                             string A120ProfesionalesId ,
                                             string A166ProfesionalesPrimerNombre ,
                                             string A191ProfesionalesSegundoNombre ,
                                             string A167ProfesionalesApellidoPrimero ,
                                             string A192ProfesionalesApellidoSegundo ,
                                             string A170ProfesionalesTelefono ,
                                             short A451ProfComisionesAutoEnun ,
                                             short AV17OrderedBy ,
                                             bool AV18OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int4 = new short[36];
         Object[] GXv_Object5 = new Object[2];
         scmdbuf = "SELECT T2.[ProfesionalesTelefono], T2.[ProfesionalesApellidoSegundo], T2.[ProfesionalesApellidoPrimero], T2.[ProfesionalesSegundoNombre], T2.[ProfesionalesPrimerNombre], T1.[ProfesionalesId], T1.[ProfComisionesID], T1.[ProfComisionesAutoEnun] FROM ([ProfComisiones] T1 INNER JOIN [Profesionales] T2 ON T2.[ProfesionalesId] = T1.[ProfesionalesId])";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Profcomisioneswwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( CONVERT( char(18), CAST(T1.[ProfComisionesID] AS decimal(18,0))) like '%' + @lV68Profcomisioneswwds_1_filterfulltext) or ( UPPER(T1.[ProfesionalesId]) like '%' + UPPER(@lV68Profcomisioneswwds_1_filterfulltext)) or ( UPPER(T2.[ProfesionalesPrimerNombre]) like '%' + UPPER(@lV68Profcomisioneswwds_1_filterfulltext)) or ( UPPER(T2.[ProfesionalesSegundoNombre]) like '%' + UPPER(@lV68Profcomisioneswwds_1_filterfulltext)) or ( UPPER(T2.[ProfesionalesApellidoPrimero]) like '%' + UPPER(@lV68Profcomisioneswwds_1_filterfulltext)) or ( UPPER(T2.[ProfesionalesApellidoSegundo]) like '%' + UPPER(@lV68Profcomisioneswwds_1_filterfulltext)) or ( UPPER(T2.[ProfesionalesTelefono]) like '%' + UPPER(@lV68Profcomisioneswwds_1_filterfulltext)))");
         }
         else
         {
            GXv_int4[0] = 1;
            GXv_int4[1] = 1;
            GXv_int4[2] = 1;
            GXv_int4[3] = 1;
            GXv_int4[4] = 1;
            GXv_int4[5] = 1;
            GXv_int4[6] = 1;
         }
         if ( ( StringUtil.StrCmp(AV69Profcomisioneswwds_2_dynamicfiltersselector1, "PROFCOMISIONESAUTOENUN") == 0 ) && ( AV70Profcomisioneswwds_3_dynamicfiltersoperator1 == 0 ) && ( ! (0==AV71Profcomisioneswwds_4_profcomisionesautoenun1) ) )
         {
            AddWhere(sWhereString, "(T1.[ProfComisionesAutoEnun] < @AV71Profcomisioneswwds_4_profcomisionesautoenun1)");
         }
         else
         {
            GXv_int4[7] = 1;
         }
         if ( ( StringUtil.StrCmp(AV69Profcomisioneswwds_2_dynamicfiltersselector1, "PROFCOMISIONESAUTOENUN") == 0 ) && ( AV70Profcomisioneswwds_3_dynamicfiltersoperator1 == 1 ) && ( ! (0==AV71Profcomisioneswwds_4_profcomisionesautoenun1) ) )
         {
            AddWhere(sWhereString, "(T1.[ProfComisionesAutoEnun] = @AV71Profcomisioneswwds_4_profcomisionesautoenun1)");
         }
         else
         {
            GXv_int4[8] = 1;
         }
         if ( ( StringUtil.StrCmp(AV69Profcomisioneswwds_2_dynamicfiltersselector1, "PROFCOMISIONESAUTOENUN") == 0 ) && ( AV70Profcomisioneswwds_3_dynamicfiltersoperator1 == 2 ) && ( ! (0==AV71Profcomisioneswwds_4_profcomisionesautoenun1) ) )
         {
            AddWhere(sWhereString, "(T1.[ProfComisionesAutoEnun] > @AV71Profcomisioneswwds_4_profcomisionesautoenun1)");
         }
         else
         {
            GXv_int4[9] = 1;
         }
         if ( ( StringUtil.StrCmp(AV69Profcomisioneswwds_2_dynamicfiltersselector1, "PROFESIONALESPRIMERNOMBRE") == 0 ) && ( AV70Profcomisioneswwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Profcomisioneswwds_5_profesionalesprimernombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ProfesionalesPrimerNombre]) like UPPER(@lV72Profcomisioneswwds_5_profesionalesprimernombre1))");
         }
         else
         {
            GXv_int4[10] = 1;
         }
         if ( ( StringUtil.StrCmp(AV69Profcomisioneswwds_2_dynamicfiltersselector1, "PROFESIONALESPRIMERNOMBRE") == 0 ) && ( AV70Profcomisioneswwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Profcomisioneswwds_5_profesionalesprimernombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ProfesionalesPrimerNombre]) like '%' + UPPER(@lV72Profcomisioneswwds_5_profesionalesprimernombre1))");
         }
         else
         {
            GXv_int4[11] = 1;
         }
         if ( AV73Profcomisioneswwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV74Profcomisioneswwds_7_dynamicfiltersselector2, "PROFCOMISIONESAUTOENUN") == 0 ) && ( AV75Profcomisioneswwds_8_dynamicfiltersoperator2 == 0 ) && ( ! (0==AV76Profcomisioneswwds_9_profcomisionesautoenun2) ) )
         {
            AddWhere(sWhereString, "(T1.[ProfComisionesAutoEnun] < @AV76Profcomisioneswwds_9_profcomisionesautoenun2)");
         }
         else
         {
            GXv_int4[12] = 1;
         }
         if ( AV73Profcomisioneswwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV74Profcomisioneswwds_7_dynamicfiltersselector2, "PROFCOMISIONESAUTOENUN") == 0 ) && ( AV75Profcomisioneswwds_8_dynamicfiltersoperator2 == 1 ) && ( ! (0==AV76Profcomisioneswwds_9_profcomisionesautoenun2) ) )
         {
            AddWhere(sWhereString, "(T1.[ProfComisionesAutoEnun] = @AV76Profcomisioneswwds_9_profcomisionesautoenun2)");
         }
         else
         {
            GXv_int4[13] = 1;
         }
         if ( AV73Profcomisioneswwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV74Profcomisioneswwds_7_dynamicfiltersselector2, "PROFCOMISIONESAUTOENUN") == 0 ) && ( AV75Profcomisioneswwds_8_dynamicfiltersoperator2 == 2 ) && ( ! (0==AV76Profcomisioneswwds_9_profcomisionesautoenun2) ) )
         {
            AddWhere(sWhereString, "(T1.[ProfComisionesAutoEnun] > @AV76Profcomisioneswwds_9_profcomisionesautoenun2)");
         }
         else
         {
            GXv_int4[14] = 1;
         }
         if ( AV73Profcomisioneswwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV74Profcomisioneswwds_7_dynamicfiltersselector2, "PROFESIONALESPRIMERNOMBRE") == 0 ) && ( AV75Profcomisioneswwds_8_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV77Profcomisioneswwds_10_profesionalesprimernombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ProfesionalesPrimerNombre]) like UPPER(@lV77Profcomisioneswwds_10_profesionalesprimernombre2))");
         }
         else
         {
            GXv_int4[15] = 1;
         }
         if ( AV73Profcomisioneswwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV74Profcomisioneswwds_7_dynamicfiltersselector2, "PROFESIONALESPRIMERNOMBRE") == 0 ) && ( AV75Profcomisioneswwds_8_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV77Profcomisioneswwds_10_profesionalesprimernombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ProfesionalesPrimerNombre]) like '%' + UPPER(@lV77Profcomisioneswwds_10_profesionalesprimernombre2))");
         }
         else
         {
            GXv_int4[16] = 1;
         }
         if ( AV78Profcomisioneswwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV79Profcomisioneswwds_12_dynamicfiltersselector3, "PROFCOMISIONESAUTOENUN") == 0 ) && ( AV80Profcomisioneswwds_13_dynamicfiltersoperator3 == 0 ) && ( ! (0==AV81Profcomisioneswwds_14_profcomisionesautoenun3) ) )
         {
            AddWhere(sWhereString, "(T1.[ProfComisionesAutoEnun] < @AV81Profcomisioneswwds_14_profcomisionesautoenun3)");
         }
         else
         {
            GXv_int4[17] = 1;
         }
         if ( AV78Profcomisioneswwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV79Profcomisioneswwds_12_dynamicfiltersselector3, "PROFCOMISIONESAUTOENUN") == 0 ) && ( AV80Profcomisioneswwds_13_dynamicfiltersoperator3 == 1 ) && ( ! (0==AV81Profcomisioneswwds_14_profcomisionesautoenun3) ) )
         {
            AddWhere(sWhereString, "(T1.[ProfComisionesAutoEnun] = @AV81Profcomisioneswwds_14_profcomisionesautoenun3)");
         }
         else
         {
            GXv_int4[18] = 1;
         }
         if ( AV78Profcomisioneswwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV79Profcomisioneswwds_12_dynamicfiltersselector3, "PROFCOMISIONESAUTOENUN") == 0 ) && ( AV80Profcomisioneswwds_13_dynamicfiltersoperator3 == 2 ) && ( ! (0==AV81Profcomisioneswwds_14_profcomisionesautoenun3) ) )
         {
            AddWhere(sWhereString, "(T1.[ProfComisionesAutoEnun] > @AV81Profcomisioneswwds_14_profcomisionesautoenun3)");
         }
         else
         {
            GXv_int4[19] = 1;
         }
         if ( AV78Profcomisioneswwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV79Profcomisioneswwds_12_dynamicfiltersselector3, "PROFESIONALESPRIMERNOMBRE") == 0 ) && ( AV80Profcomisioneswwds_13_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV82Profcomisioneswwds_15_profesionalesprimernombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ProfesionalesPrimerNombre]) like UPPER(@lV82Profcomisioneswwds_15_profesionalesprimernombre3))");
         }
         else
         {
            GXv_int4[20] = 1;
         }
         if ( AV78Profcomisioneswwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV79Profcomisioneswwds_12_dynamicfiltersselector3, "PROFESIONALESPRIMERNOMBRE") == 0 ) && ( AV80Profcomisioneswwds_13_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV82Profcomisioneswwds_15_profesionalesprimernombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ProfesionalesPrimerNombre]) like '%' + UPPER(@lV82Profcomisioneswwds_15_profesionalesprimernombre3))");
         }
         else
         {
            GXv_int4[21] = 1;
         }
         if ( ! (0==AV83Profcomisioneswwds_16_tfprofcomisionesid) )
         {
            AddWhere(sWhereString, "(T1.[ProfComisionesID] >= @AV83Profcomisioneswwds_16_tfprofcomisionesid)");
         }
         else
         {
            GXv_int4[22] = 1;
         }
         if ( ! (0==AV84Profcomisioneswwds_17_tfprofcomisionesid_to) )
         {
            AddWhere(sWhereString, "(T1.[ProfComisionesID] <= @AV84Profcomisioneswwds_17_tfprofcomisionesid_to)");
         }
         else
         {
            GXv_int4[23] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV86Profcomisioneswwds_19_tfprofesionalesid_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV85Profcomisioneswwds_18_tfprofesionalesid)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[ProfesionalesId]) like UPPER(@lV85Profcomisioneswwds_18_tfprofesionalesid))");
         }
         else
         {
            GXv_int4[24] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV86Profcomisioneswwds_19_tfprofesionalesid_sel)) && ! ( StringUtil.StrCmp(AV86Profcomisioneswwds_19_tfprofesionalesid_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[ProfesionalesId] = @AV86Profcomisioneswwds_19_tfprofesionalesid_sel)");
         }
         else
         {
            GXv_int4[25] = 1;
         }
         if ( StringUtil.StrCmp(AV86Profcomisioneswwds_19_tfprofesionalesid_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[ProfesionalesId] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV88Profcomisioneswwds_21_tfprofesionalesprimernombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV87Profcomisioneswwds_20_tfprofesionalesprimernombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ProfesionalesPrimerNombre]) like UPPER(@lV87Profcomisioneswwds_20_tfprofesionalesprimernombre))");
         }
         else
         {
            GXv_int4[26] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV88Profcomisioneswwds_21_tfprofesionalesprimernombre_sel)) && ! ( StringUtil.StrCmp(AV88Profcomisioneswwds_21_tfprofesionalesprimernombre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.[ProfesionalesPrimerNombre] = @AV88Profcomisioneswwds_21_tfprofesionalesprimernombre_sel)");
         }
         else
         {
            GXv_int4[27] = 1;
         }
         if ( StringUtil.StrCmp(AV88Profcomisioneswwds_21_tfprofesionalesprimernombre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T2.[ProfesionalesPrimerNombre] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV90Profcomisioneswwds_23_tfprofesionalessegundonombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV89Profcomisioneswwds_22_tfprofesionalessegundonombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ProfesionalesSegundoNombre]) like UPPER(@lV89Profcomisioneswwds_22_tfprofesionalessegundonombre))");
         }
         else
         {
            GXv_int4[28] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV90Profcomisioneswwds_23_tfprofesionalessegundonombre_sel)) && ! ( StringUtil.StrCmp(AV90Profcomisioneswwds_23_tfprofesionalessegundonombre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.[ProfesionalesSegundoNombre] = @AV90Profcomisioneswwds_23_tfprofesionalessegundonombre_sel)");
         }
         else
         {
            GXv_int4[29] = 1;
         }
         if ( StringUtil.StrCmp(AV90Profcomisioneswwds_23_tfprofesionalessegundonombre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T2.[ProfesionalesSegundoNombre] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV92Profcomisioneswwds_25_tfprofesionalesapellidoprimero_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV91Profcomisioneswwds_24_tfprofesionalesapellidoprimero)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ProfesionalesApellidoPrimero]) like UPPER(@lV91Profcomisioneswwds_24_tfprofesionalesapellidoprimero))");
         }
         else
         {
            GXv_int4[30] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV92Profcomisioneswwds_25_tfprofesionalesapellidoprimero_sel)) && ! ( StringUtil.StrCmp(AV92Profcomisioneswwds_25_tfprofesionalesapellidoprimero_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.[ProfesionalesApellidoPrimero] = @AV92Profcomisioneswwds_25_tfprofesionalesapellidoprimero_sel)");
         }
         else
         {
            GXv_int4[31] = 1;
         }
         if ( StringUtil.StrCmp(AV92Profcomisioneswwds_25_tfprofesionalesapellidoprimero_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T2.[ProfesionalesApellidoPrimero] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV94Profcomisioneswwds_27_tfprofesionalesapellidosegundo_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV93Profcomisioneswwds_26_tfprofesionalesapellidosegundo)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ProfesionalesApellidoSegundo]) like UPPER(@lV93Profcomisioneswwds_26_tfprofesionalesapellidosegundo))");
         }
         else
         {
            GXv_int4[32] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV94Profcomisioneswwds_27_tfprofesionalesapellidosegundo_sel)) && ! ( StringUtil.StrCmp(AV94Profcomisioneswwds_27_tfprofesionalesapellidosegundo_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.[ProfesionalesApellidoSegundo] = @AV94Profcomisioneswwds_27_tfprofesionalesapellidosegundo_sel)");
         }
         else
         {
            GXv_int4[33] = 1;
         }
         if ( StringUtil.StrCmp(AV94Profcomisioneswwds_27_tfprofesionalesapellidosegundo_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T2.[ProfesionalesApellidoSegundo] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV96Profcomisioneswwds_29_tfprofesionalestelefono_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV95Profcomisioneswwds_28_tfprofesionalestelefono)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ProfesionalesTelefono]) like UPPER(@lV95Profcomisioneswwds_28_tfprofesionalestelefono))");
         }
         else
         {
            GXv_int4[34] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV96Profcomisioneswwds_29_tfprofesionalestelefono_sel)) && ! ( StringUtil.StrCmp(AV96Profcomisioneswwds_29_tfprofesionalestelefono_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.[ProfesionalesTelefono] = @AV96Profcomisioneswwds_29_tfprofesionalestelefono_sel)");
         }
         else
         {
            GXv_int4[35] = 1;
         }
         if ( StringUtil.StrCmp(AV96Profcomisioneswwds_29_tfprofesionalestelefono_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T2.[ProfesionalesTelefono] = ''))");
         }
         scmdbuf += sWhereString;
         if ( AV17OrderedBy == 1 )
         {
            scmdbuf += " ORDER BY T1.[ProfComisionesAutoEnun]";
         }
         else if ( ( AV17OrderedBy == 2 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[ProfComisionesID]";
         }
         else if ( ( AV17OrderedBy == 2 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[ProfComisionesID] DESC";
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
            scmdbuf += " ORDER BY T2.[ProfesionalesPrimerNombre]";
         }
         else if ( ( AV17OrderedBy == 4 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T2.[ProfesionalesPrimerNombre] DESC";
         }
         else if ( ( AV17OrderedBy == 5 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T2.[ProfesionalesSegundoNombre]";
         }
         else if ( ( AV17OrderedBy == 5 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T2.[ProfesionalesSegundoNombre] DESC";
         }
         else if ( ( AV17OrderedBy == 6 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T2.[ProfesionalesApellidoPrimero]";
         }
         else if ( ( AV17OrderedBy == 6 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T2.[ProfesionalesApellidoPrimero] DESC";
         }
         else if ( ( AV17OrderedBy == 7 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T2.[ProfesionalesApellidoSegundo]";
         }
         else if ( ( AV17OrderedBy == 7 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T2.[ProfesionalesApellidoSegundo] DESC";
         }
         else if ( ( AV17OrderedBy == 8 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T2.[ProfesionalesTelefono]";
         }
         else if ( ( AV17OrderedBy == 8 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T2.[ProfesionalesTelefono] DESC";
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
                     return conditional_P005U2(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (short)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (bool)dynConstraints[5] , (string)dynConstraints[6] , (short)dynConstraints[7] , (short)dynConstraints[8] , (string)dynConstraints[9] , (bool)dynConstraints[10] , (string)dynConstraints[11] , (short)dynConstraints[12] , (short)dynConstraints[13] , (string)dynConstraints[14] , (long)dynConstraints[15] , (long)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (string)dynConstraints[25] , (string)dynConstraints[26] , (string)dynConstraints[27] , (string)dynConstraints[28] , (long)dynConstraints[29] , (string)dynConstraints[30] , (string)dynConstraints[31] , (string)dynConstraints[32] , (string)dynConstraints[33] , (string)dynConstraints[34] , (string)dynConstraints[35] , (short)dynConstraints[36] , (short)dynConstraints[37] , (bool)dynConstraints[38] );
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
          Object[] prmP005U2;
          prmP005U2 = new Object[] {
          new ParDef("@lV68Profcomisioneswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV68Profcomisioneswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV68Profcomisioneswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV68Profcomisioneswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV68Profcomisioneswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV68Profcomisioneswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV68Profcomisioneswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@AV71Profcomisioneswwds_4_profcomisionesautoenun1",GXType.Int16,4,0) ,
          new ParDef("@AV71Profcomisioneswwds_4_profcomisionesautoenun1",GXType.Int16,4,0) ,
          new ParDef("@AV71Profcomisioneswwds_4_profcomisionesautoenun1",GXType.Int16,4,0) ,
          new ParDef("@lV72Profcomisioneswwds_5_profesionalesprimernombre1",GXType.Char,30,0) ,
          new ParDef("@lV72Profcomisioneswwds_5_profesionalesprimernombre1",GXType.Char,30,0) ,
          new ParDef("@AV76Profcomisioneswwds_9_profcomisionesautoenun2",GXType.Int16,4,0) ,
          new ParDef("@AV76Profcomisioneswwds_9_profcomisionesautoenun2",GXType.Int16,4,0) ,
          new ParDef("@AV76Profcomisioneswwds_9_profcomisionesautoenun2",GXType.Int16,4,0) ,
          new ParDef("@lV77Profcomisioneswwds_10_profesionalesprimernombre2",GXType.Char,30,0) ,
          new ParDef("@lV77Profcomisioneswwds_10_profesionalesprimernombre2",GXType.Char,30,0) ,
          new ParDef("@AV81Profcomisioneswwds_14_profcomisionesautoenun3",GXType.Int16,4,0) ,
          new ParDef("@AV81Profcomisioneswwds_14_profcomisionesautoenun3",GXType.Int16,4,0) ,
          new ParDef("@AV81Profcomisioneswwds_14_profcomisionesautoenun3",GXType.Int16,4,0) ,
          new ParDef("@lV82Profcomisioneswwds_15_profesionalesprimernombre3",GXType.Char,30,0) ,
          new ParDef("@lV82Profcomisioneswwds_15_profesionalesprimernombre3",GXType.Char,30,0) ,
          new ParDef("@AV83Profcomisioneswwds_16_tfprofcomisionesid",GXType.Decimal,18,0) ,
          new ParDef("@AV84Profcomisioneswwds_17_tfprofcomisionesid_to",GXType.Decimal,18,0) ,
          new ParDef("@lV85Profcomisioneswwds_18_tfprofesionalesid",GXType.Char,20,0) ,
          new ParDef("@AV86Profcomisioneswwds_19_tfprofesionalesid_sel",GXType.Char,20,0) ,
          new ParDef("@lV87Profcomisioneswwds_20_tfprofesionalesprimernombre",GXType.Char,30,0) ,
          new ParDef("@AV88Profcomisioneswwds_21_tfprofesionalesprimernombre_sel",GXType.NChar,30,0) ,
          new ParDef("@lV89Profcomisioneswwds_22_tfprofesionalessegundonombre",GXType.Char,30,0) ,
          new ParDef("@AV90Profcomisioneswwds_23_tfprofesionalessegundonombre_sel",GXType.NChar,30,0) ,
          new ParDef("@lV91Profcomisioneswwds_24_tfprofesionalesapellidoprimero",GXType.Char,30,0) ,
          new ParDef("@AV92Profcomisioneswwds_25_tfprofesionalesapellidoprimero_sel",GXType.NChar,30,0) ,
          new ParDef("@lV93Profcomisioneswwds_26_tfprofesionalesapellidosegundo",GXType.Char,30,0) ,
          new ParDef("@AV94Profcomisioneswwds_27_tfprofesionalesapellidosegundo_sel",GXType.NChar,30,0) ,
          new ParDef("@lV95Profcomisioneswwds_28_tfprofesionalestelefono",GXType.Char,20,0) ,
          new ParDef("@AV96Profcomisioneswwds_29_tfprofesionalestelefono_sel",GXType.NChar,20,0)
          };
          def= new CursorDef[] {
              new CursorDef("P005U2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP005U2,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[1])[0] = rslt.getString(2, 30);
                ((string[]) buf[2])[0] = rslt.getString(3, 30);
                ((string[]) buf[3])[0] = rslt.getString(4, 30);
                ((string[]) buf[4])[0] = rslt.getString(5, 30);
                ((string[]) buf[5])[0] = rslt.getString(6, 20);
                ((long[]) buf[6])[0] = rslt.getLong(7);
                ((short[]) buf[7])[0] = rslt.getShort(8);
                return;
       }
    }

 }

}

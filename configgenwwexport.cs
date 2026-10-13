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
   public class configgenwwexport : GXProcedure
   {
      public configgenwwexport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public configgenwwexport( IGxContext context )
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
         new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWConfigGen", out  GXt_boolean1) ;
         AV8IsAuthorized = GXt_boolean1;
         if ( ! AV8IsAuthorized )
         {
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "wwpbaseobjects.notauthorized.aspx"+GXUtil.UrlEncode(StringUtil.RTrim(AV61Pgmname));
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
         AV12Filename = GXt_char2 + "ConfigGenWWExport-" + StringUtil.Trim( StringUtil.Str( (decimal)(AV16Random), 8, 0)) + ".xlsx";
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
            if ( StringUtil.StrCmp(AV20DynamicFiltersSelector1, "CONFIGGENEMPNOM") == 0 )
            {
               AV21DynamicFiltersOperator1 = AV31GridStateDynamicFilter.gxTpr_Operator;
               AV22ConfigGenEmpNom1 = AV31GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV22ConfigGenEmpNom1)) )
               {
                  AV14CellRow = (int)(AV14CellRow+1);
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Bold = 1;
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Color = 3;
                  if ( AV21DynamicFiltersOperator1 == 0 )
                  {
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", context.GetMessage( "Nombre de la Empresa", ""), context.GetMessage( "WWP_FilterLike", ""), "", "", "", "", "", "", "");
                  }
                  else if ( AV21DynamicFiltersOperator1 == 1 )
                  {
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", context.GetMessage( "Nombre de la Empresa", ""), context.GetMessage( "WWP_FilterContains", ""), "", "", "", "", "", "", "");
                  }
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Italic = 1;
                  GXt_char2 = "";
                  new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV22ConfigGenEmpNom1, out  GXt_char2) ;
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
               }
            }
            if ( AV34GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV23DynamicFiltersEnabled2 = true;
               AV31GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV34GridState.gxTpr_Dynamicfilters.Item(2));
               AV24DynamicFiltersSelector2 = AV31GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV24DynamicFiltersSelector2, "CONFIGGENEMPNOM") == 0 )
               {
                  AV25DynamicFiltersOperator2 = AV31GridStateDynamicFilter.gxTpr_Operator;
                  AV26ConfigGenEmpNom2 = AV31GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV26ConfigGenEmpNom2)) )
                  {
                     AV14CellRow = (int)(AV14CellRow+1);
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Bold = 1;
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Color = 3;
                     if ( AV25DynamicFiltersOperator2 == 0 )
                     {
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", context.GetMessage( "Nombre de la Empresa", ""), context.GetMessage( "WWP_FilterLike", ""), "", "", "", "", "", "", "");
                     }
                     else if ( AV25DynamicFiltersOperator2 == 1 )
                     {
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", context.GetMessage( "Nombre de la Empresa", ""), context.GetMessage( "WWP_FilterContains", ""), "", "", "", "", "", "", "");
                     }
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Italic = 1;
                     GXt_char2 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV26ConfigGenEmpNom2, out  GXt_char2) ;
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
                  }
               }
               if ( AV34GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV27DynamicFiltersEnabled3 = true;
                  AV31GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV34GridState.gxTpr_Dynamicfilters.Item(3));
                  AV28DynamicFiltersSelector3 = AV31GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV28DynamicFiltersSelector3, "CONFIGGENEMPNOM") == 0 )
                  {
                     AV29DynamicFiltersOperator3 = AV31GridStateDynamicFilter.gxTpr_Operator;
                     AV30ConfigGenEmpNom3 = AV31GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV30ConfigGenEmpNom3)) )
                     {
                        AV14CellRow = (int)(AV14CellRow+1);
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Bold = 1;
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Color = 3;
                        if ( AV29DynamicFiltersOperator3 == 0 )
                        {
                           AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", context.GetMessage( "Nombre de la Empresa", ""), context.GetMessage( "WWP_FilterLike", ""), "", "", "", "", "", "", "");
                        }
                        else if ( AV29DynamicFiltersOperator3 == 1 )
                        {
                           AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", context.GetMessage( "Nombre de la Empresa", ""), context.GetMessage( "WWP_FilterContains", ""), "", "", "", "", "", "", "");
                        }
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Italic = 1;
                        GXt_char2 = "";
                        new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV30ConfigGenEmpNom3, out  GXt_char2) ;
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
                     }
                  }
               }
            }
         }
         if ( ! ( (0==AV47TFConfigGenID) && (0==AV48TFConfigGenID_To) ) )
         {
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Identificador", "")) ;
            AV14CellRow = GXt_int3;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Number = AV47TFConfigGenID;
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  false, ref  GXt_int3,  (short)(AV15FirstColumn+2),  context.GetMessage( "WWP_TSTo", "")) ;
            AV14CellRow = GXt_int3;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+3, 1, 1).Number = AV48TFConfigGenID_To;
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV50TFConfigGenEmpNom_Sel)) ) )
         {
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Nombre de la Empresa", "")) ;
            AV14CellRow = GXt_int3;
            GXt_char2 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV50TFConfigGenEmpNom_Sel)) ? context.GetMessage( "WWP_TitleFilter_EmptyOption", "") : AV50TFConfigGenEmpNom_Sel), out  GXt_char2) ;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV49TFConfigGenEmpNom)) ) )
            {
               GXt_int3 = (short)(AV14CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Nombre de la Empresa", "")) ;
               AV14CellRow = GXt_int3;
               GXt_char2 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV49TFConfigGenEmpNom, out  GXt_char2) ;
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV52TFConfigGenSiglas_Sel)) ) )
         {
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Siglas", "")) ;
            AV14CellRow = GXt_int3;
            GXt_char2 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV52TFConfigGenSiglas_Sel)) ? context.GetMessage( "WWP_TitleFilter_EmptyOption", "") : AV52TFConfigGenSiglas_Sel), out  GXt_char2) ;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV51TFConfigGenSiglas)) ) )
            {
               GXt_int3 = (short)(AV14CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Siglas", "")) ;
               AV14CellRow = GXt_int3;
               GXt_char2 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV51TFConfigGenSiglas, out  GXt_char2) ;
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV54TFConfigGenSiteWeb_Sel)) ) )
         {
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Sitio Web", "")) ;
            AV14CellRow = GXt_int3;
            GXt_char2 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV54TFConfigGenSiteWeb_Sel)) ? context.GetMessage( "WWP_TitleFilter_EmptyOption", "") : AV54TFConfigGenSiteWeb_Sel), out  GXt_char2) ;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV53TFConfigGenSiteWeb)) ) )
            {
               GXt_int3 = (short)(AV14CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Sitio Web", "")) ;
               AV14CellRow = GXt_int3;
               GXt_char2 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV53TFConfigGenSiteWeb, out  GXt_char2) ;
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV56TFConfigGenCorreo_Sel)) ) )
         {
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Email", "")) ;
            AV14CellRow = GXt_int3;
            GXt_char2 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV56TFConfigGenCorreo_Sel)) ? context.GetMessage( "WWP_TitleFilter_EmptyOption", "") : AV56TFConfigGenCorreo_Sel), out  GXt_char2) ;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV55TFConfigGenCorreo)) ) )
            {
               GXt_int3 = (short)(AV14CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Email", "")) ;
               AV14CellRow = GXt_int3;
               GXt_char2 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV55TFConfigGenCorreo, out  GXt_char2) ;
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
            }
         }
         if ( ! ( ( AV58TFConfigGenEstado_Sels.Count == 0 ) ) )
         {
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Gen Estado", "")) ;
            AV14CellRow = GXt_int3;
            AV60i = 1;
            AV62GXV1 = 1;
            while ( AV62GXV1 <= AV58TFConfigGenEstado_Sels.Count )
            {
               AV59TFConfigGenEstado_Sel = AV58TFConfigGenEstado_Sels.GetString(AV62GXV1);
               if ( AV60i == 1 )
               {
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = "";
               }
               else
               {
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text+", ";
               }
               if ( StringUtil.StrCmp(StringUtil.Trim( AV59TFConfigGenEstado_Sel), context.GetMessage( "HAB", "")) == 0 )
               {
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text+context.GetMessage( "Habilitado", "");
               }
               else if ( StringUtil.StrCmp(StringUtil.Trim( AV59TFConfigGenEstado_Sel), context.GetMessage( "DES", "")) == 0 )
               {
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text+context.GetMessage( "Deshabilitado", "");
               }
               AV60i = (long)(AV60i+1);
               AV62GXV1 = (int)(AV62GXV1+1);
            }
         }
         AV14CellRow = (int)(AV14CellRow+2);
      }

      protected void S141( )
      {
         /* 'WRITECOLUMNTITLES' Routine */
         returnInSub = false;
         AV44VisibleColumnCount = 0;
         if ( StringUtil.StrCmp(AV32Session.Get("ConfigGenWWColumnsSelector"), "") != 0 )
         {
            AV39ColumnsSelectorXML = AV32Session.Get("ConfigGenWWColumnsSelector");
            AV36ColumnsSelector.FromXml(AV39ColumnsSelectorXML, null, "", "");
         }
         else
         {
            /* Execute user subroutine: 'INITIALIZECOLUMNSSELECTOR' */
            S151 ();
            if (returnInSub) return;
         }
         AV36ColumnsSelector.gxTpr_Columns.Sort("Order");
         AV63GXV2 = 1;
         while ( AV63GXV2 <= AV36ColumnsSelector.gxTpr_Columns.Count )
         {
            AV38ColumnsSelector_Column = ((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV36ColumnsSelector.gxTpr_Columns.Item(AV63GXV2));
            if ( AV38ColumnsSelector_Column.gxTpr_Isvisible )
            {
               AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV44VisibleColumnCount), 1, 1).Text = context.GetMessage( (String.IsNullOrEmpty(StringUtil.RTrim( AV38ColumnsSelector_Column.gxTpr_Displayname)) ? AV38ColumnsSelector_Column.gxTpr_Columnname : AV38ColumnsSelector_Column.gxTpr_Displayname), "");
               AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV44VisibleColumnCount), 1, 1).Bold = 1;
               AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV44VisibleColumnCount), 1, 1).Color = 11;
               AV44VisibleColumnCount = (long)(AV44VisibleColumnCount+1);
            }
            AV63GXV2 = (int)(AV63GXV2+1);
         }
      }

      protected void S161( )
      {
         /* 'WRITEDATA' Routine */
         returnInSub = false;
         AV65Configgenwwds_1_filterfulltext = AV19FilterFullText;
         AV66Configgenwwds_2_dynamicfiltersselector1 = AV20DynamicFiltersSelector1;
         AV67Configgenwwds_3_dynamicfiltersoperator1 = AV21DynamicFiltersOperator1;
         AV68Configgenwwds_4_configgenempnom1 = AV22ConfigGenEmpNom1;
         AV69Configgenwwds_5_dynamicfiltersenabled2 = AV23DynamicFiltersEnabled2;
         AV70Configgenwwds_6_dynamicfiltersselector2 = AV24DynamicFiltersSelector2;
         AV71Configgenwwds_7_dynamicfiltersoperator2 = AV25DynamicFiltersOperator2;
         AV72Configgenwwds_8_configgenempnom2 = AV26ConfigGenEmpNom2;
         AV73Configgenwwds_9_dynamicfiltersenabled3 = AV27DynamicFiltersEnabled3;
         AV74Configgenwwds_10_dynamicfiltersselector3 = AV28DynamicFiltersSelector3;
         AV75Configgenwwds_11_dynamicfiltersoperator3 = AV29DynamicFiltersOperator3;
         AV76Configgenwwds_12_configgenempnom3 = AV30ConfigGenEmpNom3;
         AV77Configgenwwds_13_tfconfiggenid = AV47TFConfigGenID;
         AV78Configgenwwds_14_tfconfiggenid_to = AV48TFConfigGenID_To;
         AV79Configgenwwds_15_tfconfiggenempnom = AV49TFConfigGenEmpNom;
         AV80Configgenwwds_16_tfconfiggenempnom_sel = AV50TFConfigGenEmpNom_Sel;
         AV81Configgenwwds_17_tfconfiggensiglas = AV51TFConfigGenSiglas;
         AV82Configgenwwds_18_tfconfiggensiglas_sel = AV52TFConfigGenSiglas_Sel;
         AV83Configgenwwds_19_tfconfiggensiteweb = AV53TFConfigGenSiteWeb;
         AV84Configgenwwds_20_tfconfiggensiteweb_sel = AV54TFConfigGenSiteWeb_Sel;
         AV85Configgenwwds_21_tfconfiggencorreo = AV55TFConfigGenCorreo;
         AV86Configgenwwds_22_tfconfiggencorreo_sel = AV56TFConfigGenCorreo_Sel;
         AV87Configgenwwds_23_tfconfiggenestado_sels = AV58TFConfigGenEstado_Sels;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A358ConfigGenEstado ,
                                              AV87Configgenwwds_23_tfconfiggenestado_sels ,
                                              AV66Configgenwwds_2_dynamicfiltersselector1 ,
                                              AV67Configgenwwds_3_dynamicfiltersoperator1 ,
                                              AV68Configgenwwds_4_configgenempnom1 ,
                                              AV69Configgenwwds_5_dynamicfiltersenabled2 ,
                                              AV70Configgenwwds_6_dynamicfiltersselector2 ,
                                              AV71Configgenwwds_7_dynamicfiltersoperator2 ,
                                              AV72Configgenwwds_8_configgenempnom2 ,
                                              AV73Configgenwwds_9_dynamicfiltersenabled3 ,
                                              AV74Configgenwwds_10_dynamicfiltersselector3 ,
                                              AV75Configgenwwds_11_dynamicfiltersoperator3 ,
                                              AV76Configgenwwds_12_configgenempnom3 ,
                                              AV77Configgenwwds_13_tfconfiggenid ,
                                              AV78Configgenwwds_14_tfconfiggenid_to ,
                                              AV80Configgenwwds_16_tfconfiggenempnom_sel ,
                                              AV79Configgenwwds_15_tfconfiggenempnom ,
                                              AV82Configgenwwds_18_tfconfiggensiglas_sel ,
                                              AV81Configgenwwds_17_tfconfiggensiglas ,
                                              AV84Configgenwwds_20_tfconfiggensiteweb_sel ,
                                              AV83Configgenwwds_19_tfconfiggensiteweb ,
                                              AV86Configgenwwds_22_tfconfiggencorreo_sel ,
                                              AV85Configgenwwds_21_tfconfiggencorreo ,
                                              AV87Configgenwwds_23_tfconfiggenestado_sels.Count ,
                                              A351ConfigGenEmpNom ,
                                              A349ConfigGenID ,
                                              A352ConfigGenSiglas ,
                                              A354ConfigGenSiteWeb ,
                                              A355ConfigGenCorreo ,
                                              AV17OrderedBy ,
                                              AV18OrderedDsc ,
                                              AV65Configgenwwds_1_filterfulltext } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.SHORT, TypeConstants.SHORT,
                                              TypeConstants.BOOLEAN
                                              }
         });
         lV68Configgenwwds_4_configgenempnom1 = StringUtil.PadR( StringUtil.RTrim( AV68Configgenwwds_4_configgenempnom1), 100, "%");
         lV68Configgenwwds_4_configgenempnom1 = StringUtil.PadR( StringUtil.RTrim( AV68Configgenwwds_4_configgenempnom1), 100, "%");
         lV72Configgenwwds_8_configgenempnom2 = StringUtil.PadR( StringUtil.RTrim( AV72Configgenwwds_8_configgenempnom2), 100, "%");
         lV72Configgenwwds_8_configgenempnom2 = StringUtil.PadR( StringUtil.RTrim( AV72Configgenwwds_8_configgenempnom2), 100, "%");
         lV76Configgenwwds_12_configgenempnom3 = StringUtil.PadR( StringUtil.RTrim( AV76Configgenwwds_12_configgenempnom3), 100, "%");
         lV76Configgenwwds_12_configgenempnom3 = StringUtil.PadR( StringUtil.RTrim( AV76Configgenwwds_12_configgenempnom3), 100, "%");
         lV79Configgenwwds_15_tfconfiggenempnom = StringUtil.PadR( StringUtil.RTrim( AV79Configgenwwds_15_tfconfiggenempnom), 100, "%");
         lV81Configgenwwds_17_tfconfiggensiglas = StringUtil.PadR( StringUtil.RTrim( AV81Configgenwwds_17_tfconfiggensiglas), 20, "%");
         lV83Configgenwwds_19_tfconfiggensiteweb = StringUtil.PadR( StringUtil.RTrim( AV83Configgenwwds_19_tfconfiggensiteweb), 80, "%");
         lV85Configgenwwds_21_tfconfiggencorreo = StringUtil.Concat( StringUtil.RTrim( AV85Configgenwwds_21_tfconfiggencorreo), "%", "");
         /* Using cursor P00722 */
         pr_default.execute(0, new Object[] {lV68Configgenwwds_4_configgenempnom1, lV68Configgenwwds_4_configgenempnom1, lV72Configgenwwds_8_configgenempnom2, lV72Configgenwwds_8_configgenempnom2, lV76Configgenwwds_12_configgenempnom3, lV76Configgenwwds_12_configgenempnom3, AV77Configgenwwds_13_tfconfiggenid, AV78Configgenwwds_14_tfconfiggenid_to, lV79Configgenwwds_15_tfconfiggenempnom, AV80Configgenwwds_16_tfconfiggenempnom_sel, lV81Configgenwwds_17_tfconfiggensiglas, AV82Configgenwwds_18_tfconfiggensiglas_sel, lV83Configgenwwds_19_tfconfiggensiteweb, AV84Configgenwwds_20_tfconfiggensiteweb_sel, lV85Configgenwwds_21_tfconfiggencorreo, AV86Configgenwwds_22_tfconfiggencorreo_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A355ConfigGenCorreo = P00722_A355ConfigGenCorreo[0];
            A354ConfigGenSiteWeb = P00722_A354ConfigGenSiteWeb[0];
            A352ConfigGenSiglas = P00722_A352ConfigGenSiglas[0];
            A351ConfigGenEmpNom = P00722_A351ConfigGenEmpNom[0];
            A349ConfigGenID = P00722_A349ConfigGenID[0];
            A358ConfigGenEstado = P00722_A358ConfigGenEstado[0];
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV65Configgenwwds_1_filterfulltext)) || ( ( StringUtil.Like( StringUtil.Str( (decimal)(A349ConfigGenID), 4, 0) , StringUtil.PadR( "%" + AV65Configgenwwds_1_filterfulltext , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A351ConfigGenEmpNom) , StringUtil.PadR( "%" + StringUtil.Upper( AV65Configgenwwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A352ConfigGenSiglas) , StringUtil.PadR( "%" + StringUtil.Upper( AV65Configgenwwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A354ConfigGenSiteWeb) , StringUtil.PadR( "%" + StringUtil.Upper( AV65Configgenwwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A355ConfigGenCorreo) , StringUtil.PadR( "%" + StringUtil.Upper( AV65Configgenwwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( context.GetMessage( "habilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV65Configgenwwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A358ConfigGenEstado, "HAB") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "deshabilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV65Configgenwwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A358ConfigGenEstado, "DES") == 0 ) ) ) )
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
               AV44VisibleColumnCount = 0;
               AV88GXV3 = 1;
               while ( AV88GXV3 <= AV36ColumnsSelector.gxTpr_Columns.Count )
               {
                  AV38ColumnsSelector_Column = ((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV36ColumnsSelector.gxTpr_Columns.Item(AV88GXV3));
                  if ( AV38ColumnsSelector_Column.gxTpr_Isvisible )
                  {
                     if ( StringUtil.StrCmp(AV38ColumnsSelector_Column.gxTpr_Columnname, "ConfigGenID") == 0 )
                     {
                        AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV44VisibleColumnCount), 1, 1).Number = A349ConfigGenID;
                     }
                     else if ( StringUtil.StrCmp(AV38ColumnsSelector_Column.gxTpr_Columnname, "ConfigGenEmpNom") == 0 )
                     {
                        GXt_char2 = "";
                        new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A351ConfigGenEmpNom, out  GXt_char2) ;
                        AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV44VisibleColumnCount), 1, 1).Text = GXt_char2;
                     }
                     else if ( StringUtil.StrCmp(AV38ColumnsSelector_Column.gxTpr_Columnname, "ConfigGenSiglas") == 0 )
                     {
                        GXt_char2 = "";
                        new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A352ConfigGenSiglas, out  GXt_char2) ;
                        AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV44VisibleColumnCount), 1, 1).Text = GXt_char2;
                     }
                     else if ( StringUtil.StrCmp(AV38ColumnsSelector_Column.gxTpr_Columnname, "ConfigGenSiteWeb") == 0 )
                     {
                        GXt_char2 = "";
                        new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A354ConfigGenSiteWeb, out  GXt_char2) ;
                        AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV44VisibleColumnCount), 1, 1).Text = GXt_char2;
                     }
                     else if ( StringUtil.StrCmp(AV38ColumnsSelector_Column.gxTpr_Columnname, "ConfigGenCorreo") == 0 )
                     {
                        GXt_char2 = "";
                        new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A355ConfigGenCorreo, out  GXt_char2) ;
                        AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV44VisibleColumnCount), 1, 1).Text = GXt_char2;
                     }
                     else if ( StringUtil.StrCmp(AV38ColumnsSelector_Column.gxTpr_Columnname, "ConfigGenEstado") == 0 )
                     {
                        AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV44VisibleColumnCount), 1, 1).Text = "";
                        if ( StringUtil.StrCmp(StringUtil.Trim( A358ConfigGenEstado), context.GetMessage( "HAB", "")) == 0 )
                        {
                           AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV44VisibleColumnCount), 1, 1).Text = context.GetMessage( "Habilitado", "");
                        }
                        else if ( StringUtil.StrCmp(StringUtil.Trim( A358ConfigGenEstado), context.GetMessage( "DES", "")) == 0 )
                        {
                           AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV44VisibleColumnCount), 1, 1).Text = context.GetMessage( "Deshabilitado", "");
                        }
                     }
                     AV44VisibleColumnCount = (long)(AV44VisibleColumnCount+1);
                  }
                  AV88GXV3 = (int)(AV88GXV3+1);
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
         AV32Session.Set("WWPExportFilePath", AV12Filename);
         AV32Session.Set("WWPExportFileName", "ConfigGenWWExport.xlsx");
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
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV36ColumnsSelector,  "ConfigGenID",  "",  "Identificador",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV36ColumnsSelector,  "ConfigGenEmpNom",  "",  "Nombre de la Empresa",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV36ColumnsSelector,  "ConfigGenSiglas",  "",  "Siglas",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV36ColumnsSelector,  "ConfigGenSiteWeb",  "",  "Sitio Web",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV36ColumnsSelector,  "ConfigGenCorreo",  "",  "Email",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV36ColumnsSelector,  "ConfigGenEstado",  "",  "Gen Estado",  true,  "") ;
         GXt_char2 = AV40UserCustomValue;
         new GeneXus.Programs.wwpbaseobjects.loadcolumnsselectorstate(context ).execute(  "ConfigGenWWColumnsSelector", out  GXt_char2) ;
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
         if ( StringUtil.StrCmp(AV32Session.Get("ConfigGenWWGridState"), "") == 0 )
         {
            AV34GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "ConfigGenWWGridState"), null, "", "");
         }
         else
         {
            AV34GridState.FromXml(AV32Session.Get("ConfigGenWWGridState"), null, "", "");
         }
         AV17OrderedBy = AV34GridState.gxTpr_Orderedby;
         AV18OrderedDsc = AV34GridState.gxTpr_Ordereddsc;
         AV89GXV4 = 1;
         while ( AV89GXV4 <= AV34GridState.gxTpr_Filtervalues.Count )
         {
            AV35GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV34GridState.gxTpr_Filtervalues.Item(AV89GXV4));
            if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV19FilterFullText = AV35GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFCONFIGGENID") == 0 )
            {
               AV47TFConfigGenID = (short)(Math.Round(NumberUtil.Val( AV35GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV48TFConfigGenID_To = (short)(Math.Round(NumberUtil.Val( AV35GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFCONFIGGENEMPNOM") == 0 )
            {
               AV49TFConfigGenEmpNom = AV35GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFCONFIGGENEMPNOM_SEL") == 0 )
            {
               AV50TFConfigGenEmpNom_Sel = AV35GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFCONFIGGENSIGLAS") == 0 )
            {
               AV51TFConfigGenSiglas = AV35GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFCONFIGGENSIGLAS_SEL") == 0 )
            {
               AV52TFConfigGenSiglas_Sel = AV35GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFCONFIGGENSITEWEB") == 0 )
            {
               AV53TFConfigGenSiteWeb = AV35GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFCONFIGGENSITEWEB_SEL") == 0 )
            {
               AV54TFConfigGenSiteWeb_Sel = AV35GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFCONFIGGENCORREO") == 0 )
            {
               AV55TFConfigGenCorreo = AV35GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFCONFIGGENCORREO_SEL") == 0 )
            {
               AV56TFConfigGenCorreo_Sel = AV35GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFCONFIGGENESTADO_SEL") == 0 )
            {
               AV57TFConfigGenEstado_SelsJson = AV35GridStateFilterValue.gxTpr_Value;
               AV58TFConfigGenEstado_Sels.FromJSonString(AV57TFConfigGenEstado_SelsJson, null);
            }
            AV89GXV4 = (int)(AV89GXV4+1);
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
         AV61Pgmname = "";
         GXKey = "";
         GXEncryptionTmp = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV11ExcelDocument = new ExcelDocumentI();
         AV19FilterFullText = "";
         AV34GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV31GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV20DynamicFiltersSelector1 = "";
         AV22ConfigGenEmpNom1 = "";
         AV24DynamicFiltersSelector2 = "";
         AV26ConfigGenEmpNom2 = "";
         AV28DynamicFiltersSelector3 = "";
         AV30ConfigGenEmpNom3 = "";
         AV50TFConfigGenEmpNom_Sel = "";
         AV49TFConfigGenEmpNom = "";
         AV52TFConfigGenSiglas_Sel = "";
         AV51TFConfigGenSiglas = "";
         AV54TFConfigGenSiteWeb_Sel = "";
         AV53TFConfigGenSiteWeb = "";
         AV56TFConfigGenCorreo_Sel = "";
         AV55TFConfigGenCorreo = "";
         AV58TFConfigGenEstado_Sels = new GxSimpleCollection<string>();
         AV59TFConfigGenEstado_Sel = "";
         AV32Session = context.GetSession();
         AV39ColumnsSelectorXML = "";
         AV36ColumnsSelector = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector(context);
         AV38ColumnsSelector_Column = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column(context);
         AV65Configgenwwds_1_filterfulltext = "";
         AV66Configgenwwds_2_dynamicfiltersselector1 = "";
         AV68Configgenwwds_4_configgenempnom1 = "";
         AV70Configgenwwds_6_dynamicfiltersselector2 = "";
         AV72Configgenwwds_8_configgenempnom2 = "";
         AV74Configgenwwds_10_dynamicfiltersselector3 = "";
         AV76Configgenwwds_12_configgenempnom3 = "";
         AV79Configgenwwds_15_tfconfiggenempnom = "";
         AV80Configgenwwds_16_tfconfiggenempnom_sel = "";
         AV81Configgenwwds_17_tfconfiggensiglas = "";
         AV82Configgenwwds_18_tfconfiggensiglas_sel = "";
         AV83Configgenwwds_19_tfconfiggensiteweb = "";
         AV84Configgenwwds_20_tfconfiggensiteweb_sel = "";
         AV85Configgenwwds_21_tfconfiggencorreo = "";
         AV86Configgenwwds_22_tfconfiggencorreo_sel = "";
         AV87Configgenwwds_23_tfconfiggenestado_sels = new GxSimpleCollection<string>();
         lV68Configgenwwds_4_configgenempnom1 = "";
         lV72Configgenwwds_8_configgenempnom2 = "";
         lV76Configgenwwds_12_configgenempnom3 = "";
         lV79Configgenwwds_15_tfconfiggenempnom = "";
         lV81Configgenwwds_17_tfconfiggensiglas = "";
         lV83Configgenwwds_19_tfconfiggensiteweb = "";
         lV85Configgenwwds_21_tfconfiggencorreo = "";
         A358ConfigGenEstado = "";
         A351ConfigGenEmpNom = "";
         A352ConfigGenSiglas = "";
         A354ConfigGenSiteWeb = "";
         A355ConfigGenCorreo = "";
         P00722_A355ConfigGenCorreo = new string[] {""} ;
         P00722_A354ConfigGenSiteWeb = new string[] {""} ;
         P00722_A352ConfigGenSiglas = new string[] {""} ;
         P00722_A351ConfigGenEmpNom = new string[] {""} ;
         P00722_A349ConfigGenID = new short[1] ;
         P00722_A358ConfigGenEstado = new string[] {""} ;
         AV40UserCustomValue = "";
         GXt_char2 = "";
         AV37ColumnsSelectorAux = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector(context);
         AV35GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV57TFConfigGenEstado_SelsJson = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.configgenwwexport__default(),
            new Object[][] {
                new Object[] {
               P00722_A355ConfigGenCorreo, P00722_A354ConfigGenSiteWeb, P00722_A352ConfigGenSiglas, P00722_A351ConfigGenEmpNom, P00722_A349ConfigGenID, P00722_A358ConfigGenEstado
               }
            }
         );
         AV61Pgmname = "ConfigGenWWExport";
         /* GeneXus formulas. */
         AV61Pgmname = "ConfigGenWWExport";
      }

      private short AV21DynamicFiltersOperator1 ;
      private short AV25DynamicFiltersOperator2 ;
      private short AV29DynamicFiltersOperator3 ;
      private short AV47TFConfigGenID ;
      private short AV48TFConfigGenID_To ;
      private short GXt_int3 ;
      private short AV67Configgenwwds_3_dynamicfiltersoperator1 ;
      private short AV71Configgenwwds_7_dynamicfiltersoperator2 ;
      private short AV75Configgenwwds_11_dynamicfiltersoperator3 ;
      private short AV77Configgenwwds_13_tfconfiggenid ;
      private short AV78Configgenwwds_14_tfconfiggenid_to ;
      private short A349ConfigGenID ;
      private short AV17OrderedBy ;
      private int AV14CellRow ;
      private int AV15FirstColumn ;
      private int AV16Random ;
      private int AV62GXV1 ;
      private int AV63GXV2 ;
      private int AV87Configgenwwds_23_tfconfiggenestado_sels_Count ;
      private int AV88GXV3 ;
      private int AV89GXV4 ;
      private long AV60i ;
      private long AV44VisibleColumnCount ;
      private string AV61Pgmname ;
      private string GXKey ;
      private string GXEncryptionTmp ;
      private string AV22ConfigGenEmpNom1 ;
      private string AV26ConfigGenEmpNom2 ;
      private string AV30ConfigGenEmpNom3 ;
      private string AV50TFConfigGenEmpNom_Sel ;
      private string AV49TFConfigGenEmpNom ;
      private string AV52TFConfigGenSiglas_Sel ;
      private string AV51TFConfigGenSiglas ;
      private string AV54TFConfigGenSiteWeb_Sel ;
      private string AV53TFConfigGenSiteWeb ;
      private string AV59TFConfigGenEstado_Sel ;
      private string AV68Configgenwwds_4_configgenempnom1 ;
      private string AV72Configgenwwds_8_configgenempnom2 ;
      private string AV76Configgenwwds_12_configgenempnom3 ;
      private string AV79Configgenwwds_15_tfconfiggenempnom ;
      private string AV80Configgenwwds_16_tfconfiggenempnom_sel ;
      private string AV81Configgenwwds_17_tfconfiggensiglas ;
      private string AV82Configgenwwds_18_tfconfiggensiglas_sel ;
      private string AV83Configgenwwds_19_tfconfiggensiteweb ;
      private string AV84Configgenwwds_20_tfconfiggensiteweb_sel ;
      private string lV68Configgenwwds_4_configgenempnom1 ;
      private string lV72Configgenwwds_8_configgenempnom2 ;
      private string lV76Configgenwwds_12_configgenempnom3 ;
      private string lV79Configgenwwds_15_tfconfiggenempnom ;
      private string lV81Configgenwwds_17_tfconfiggensiglas ;
      private string lV83Configgenwwds_19_tfconfiggensiteweb ;
      private string A358ConfigGenEstado ;
      private string A351ConfigGenEmpNom ;
      private string A352ConfigGenSiglas ;
      private string A354ConfigGenSiteWeb ;
      private string GXt_char2 ;
      private bool AV8IsAuthorized ;
      private bool GXt_boolean1 ;
      private bool returnInSub ;
      private bool AV23DynamicFiltersEnabled2 ;
      private bool AV27DynamicFiltersEnabled3 ;
      private bool AV69Configgenwwds_5_dynamicfiltersenabled2 ;
      private bool AV73Configgenwwds_9_dynamicfiltersenabled3 ;
      private bool AV18OrderedDsc ;
      private string AV39ColumnsSelectorXML ;
      private string AV40UserCustomValue ;
      private string AV57TFConfigGenEstado_SelsJson ;
      private string AV12Filename ;
      private string AV13ErrorMessage ;
      private string AV19FilterFullText ;
      private string AV20DynamicFiltersSelector1 ;
      private string AV24DynamicFiltersSelector2 ;
      private string AV28DynamicFiltersSelector3 ;
      private string AV56TFConfigGenCorreo_Sel ;
      private string AV55TFConfigGenCorreo ;
      private string AV65Configgenwwds_1_filterfulltext ;
      private string AV66Configgenwwds_2_dynamicfiltersselector1 ;
      private string AV70Configgenwwds_6_dynamicfiltersselector2 ;
      private string AV74Configgenwwds_10_dynamicfiltersselector3 ;
      private string AV85Configgenwwds_21_tfconfiggencorreo ;
      private string AV86Configgenwwds_22_tfconfiggencorreo_sel ;
      private string lV85Configgenwwds_21_tfconfiggencorreo ;
      private string A355ConfigGenCorreo ;
      private IGxSession AV32Session ;
      private ExcelDocumentI AV11ExcelDocument ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV34GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV31GridStateDynamicFilter ;
      private GxSimpleCollection<string> AV58TFConfigGenEstado_Sels ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector AV36ColumnsSelector ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column AV38ColumnsSelector_Column ;
      private GxSimpleCollection<string> AV87Configgenwwds_23_tfconfiggenestado_sels ;
      private IDataStoreProvider pr_default ;
      private string[] P00722_A355ConfigGenCorreo ;
      private string[] P00722_A354ConfigGenSiteWeb ;
      private string[] P00722_A352ConfigGenSiglas ;
      private string[] P00722_A351ConfigGenEmpNom ;
      private short[] P00722_A349ConfigGenID ;
      private string[] P00722_A358ConfigGenEstado ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector AV37ColumnsSelectorAux ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV35GridStateFilterValue ;
      private string aP0_Filename ;
      private string aP1_ErrorMessage ;
   }

   public class configgenwwexport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00722( IGxContext context ,
                                             string A358ConfigGenEstado ,
                                             GxSimpleCollection<string> AV87Configgenwwds_23_tfconfiggenestado_sels ,
                                             string AV66Configgenwwds_2_dynamicfiltersselector1 ,
                                             short AV67Configgenwwds_3_dynamicfiltersoperator1 ,
                                             string AV68Configgenwwds_4_configgenempnom1 ,
                                             bool AV69Configgenwwds_5_dynamicfiltersenabled2 ,
                                             string AV70Configgenwwds_6_dynamicfiltersselector2 ,
                                             short AV71Configgenwwds_7_dynamicfiltersoperator2 ,
                                             string AV72Configgenwwds_8_configgenempnom2 ,
                                             bool AV73Configgenwwds_9_dynamicfiltersenabled3 ,
                                             string AV74Configgenwwds_10_dynamicfiltersselector3 ,
                                             short AV75Configgenwwds_11_dynamicfiltersoperator3 ,
                                             string AV76Configgenwwds_12_configgenempnom3 ,
                                             short AV77Configgenwwds_13_tfconfiggenid ,
                                             short AV78Configgenwwds_14_tfconfiggenid_to ,
                                             string AV80Configgenwwds_16_tfconfiggenempnom_sel ,
                                             string AV79Configgenwwds_15_tfconfiggenempnom ,
                                             string AV82Configgenwwds_18_tfconfiggensiglas_sel ,
                                             string AV81Configgenwwds_17_tfconfiggensiglas ,
                                             string AV84Configgenwwds_20_tfconfiggensiteweb_sel ,
                                             string AV83Configgenwwds_19_tfconfiggensiteweb ,
                                             string AV86Configgenwwds_22_tfconfiggencorreo_sel ,
                                             string AV85Configgenwwds_21_tfconfiggencorreo ,
                                             int AV87Configgenwwds_23_tfconfiggenestado_sels_Count ,
                                             string A351ConfigGenEmpNom ,
                                             short A349ConfigGenID ,
                                             string A352ConfigGenSiglas ,
                                             string A354ConfigGenSiteWeb ,
                                             string A355ConfigGenCorreo ,
                                             short AV17OrderedBy ,
                                             bool AV18OrderedDsc ,
                                             string AV65Configgenwwds_1_filterfulltext )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int4 = new short[16];
         Object[] GXv_Object5 = new Object[2];
         scmdbuf = "SELECT [ConfigGenCorreo], [ConfigGenSiteWeb], [ConfigGenSiglas], [ConfigGenEmpNom], [ConfigGenID], [ConfigGenEstado] FROM [ConfigGen]";
         if ( ( StringUtil.StrCmp(AV66Configgenwwds_2_dynamicfiltersselector1, "CONFIGGENEMPNOM") == 0 ) && ( AV67Configgenwwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Configgenwwds_4_configgenempnom1)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ConfigGenEmpNom]) like UPPER(@lV68Configgenwwds_4_configgenempnom1))");
         }
         else
         {
            GXv_int4[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV66Configgenwwds_2_dynamicfiltersselector1, "CONFIGGENEMPNOM") == 0 ) && ( AV67Configgenwwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Configgenwwds_4_configgenempnom1)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ConfigGenEmpNom]) like '%' + UPPER(@lV68Configgenwwds_4_configgenempnom1))");
         }
         else
         {
            GXv_int4[1] = 1;
         }
         if ( AV69Configgenwwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV70Configgenwwds_6_dynamicfiltersselector2, "CONFIGGENEMPNOM") == 0 ) && ( AV71Configgenwwds_7_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Configgenwwds_8_configgenempnom2)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ConfigGenEmpNom]) like UPPER(@lV72Configgenwwds_8_configgenempnom2))");
         }
         else
         {
            GXv_int4[2] = 1;
         }
         if ( AV69Configgenwwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV70Configgenwwds_6_dynamicfiltersselector2, "CONFIGGENEMPNOM") == 0 ) && ( AV71Configgenwwds_7_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Configgenwwds_8_configgenempnom2)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ConfigGenEmpNom]) like '%' + UPPER(@lV72Configgenwwds_8_configgenempnom2))");
         }
         else
         {
            GXv_int4[3] = 1;
         }
         if ( AV73Configgenwwds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV74Configgenwwds_10_dynamicfiltersselector3, "CONFIGGENEMPNOM") == 0 ) && ( AV75Configgenwwds_11_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV76Configgenwwds_12_configgenempnom3)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ConfigGenEmpNom]) like UPPER(@lV76Configgenwwds_12_configgenempnom3))");
         }
         else
         {
            GXv_int4[4] = 1;
         }
         if ( AV73Configgenwwds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV74Configgenwwds_10_dynamicfiltersselector3, "CONFIGGENEMPNOM") == 0 ) && ( AV75Configgenwwds_11_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV76Configgenwwds_12_configgenempnom3)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ConfigGenEmpNom]) like '%' + UPPER(@lV76Configgenwwds_12_configgenempnom3))");
         }
         else
         {
            GXv_int4[5] = 1;
         }
         if ( ! (0==AV77Configgenwwds_13_tfconfiggenid) )
         {
            AddWhere(sWhereString, "([ConfigGenID] >= @AV77Configgenwwds_13_tfconfiggenid)");
         }
         else
         {
            GXv_int4[6] = 1;
         }
         if ( ! (0==AV78Configgenwwds_14_tfconfiggenid_to) )
         {
            AddWhere(sWhereString, "([ConfigGenID] <= @AV78Configgenwwds_14_tfconfiggenid_to)");
         }
         else
         {
            GXv_int4[7] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV80Configgenwwds_16_tfconfiggenempnom_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV79Configgenwwds_15_tfconfiggenempnom)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ConfigGenEmpNom]) like UPPER(@lV79Configgenwwds_15_tfconfiggenempnom))");
         }
         else
         {
            GXv_int4[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV80Configgenwwds_16_tfconfiggenempnom_sel)) && ! ( StringUtil.StrCmp(AV80Configgenwwds_16_tfconfiggenempnom_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([ConfigGenEmpNom] = @AV80Configgenwwds_16_tfconfiggenempnom_sel)");
         }
         else
         {
            GXv_int4[9] = 1;
         }
         if ( StringUtil.StrCmp(AV80Configgenwwds_16_tfconfiggenempnom_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([ConfigGenEmpNom] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV82Configgenwwds_18_tfconfiggensiglas_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV81Configgenwwds_17_tfconfiggensiglas)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ConfigGenSiglas]) like UPPER(@lV81Configgenwwds_17_tfconfiggensiglas))");
         }
         else
         {
            GXv_int4[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV82Configgenwwds_18_tfconfiggensiglas_sel)) && ! ( StringUtil.StrCmp(AV82Configgenwwds_18_tfconfiggensiglas_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([ConfigGenSiglas] = @AV82Configgenwwds_18_tfconfiggensiglas_sel)");
         }
         else
         {
            GXv_int4[11] = 1;
         }
         if ( StringUtil.StrCmp(AV82Configgenwwds_18_tfconfiggensiglas_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([ConfigGenSiglas] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV84Configgenwwds_20_tfconfiggensiteweb_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV83Configgenwwds_19_tfconfiggensiteweb)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ConfigGenSiteWeb]) like UPPER(@lV83Configgenwwds_19_tfconfiggensiteweb))");
         }
         else
         {
            GXv_int4[12] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV84Configgenwwds_20_tfconfiggensiteweb_sel)) && ! ( StringUtil.StrCmp(AV84Configgenwwds_20_tfconfiggensiteweb_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([ConfigGenSiteWeb] = @AV84Configgenwwds_20_tfconfiggensiteweb_sel)");
         }
         else
         {
            GXv_int4[13] = 1;
         }
         if ( StringUtil.StrCmp(AV84Configgenwwds_20_tfconfiggensiteweb_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([ConfigGenSiteWeb] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV86Configgenwwds_22_tfconfiggencorreo_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV85Configgenwwds_21_tfconfiggencorreo)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ConfigGenCorreo]) like UPPER(@lV85Configgenwwds_21_tfconfiggencorreo))");
         }
         else
         {
            GXv_int4[14] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV86Configgenwwds_22_tfconfiggencorreo_sel)) && ! ( StringUtil.StrCmp(AV86Configgenwwds_22_tfconfiggencorreo_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([ConfigGenCorreo] = @AV86Configgenwwds_22_tfconfiggencorreo_sel)");
         }
         else
         {
            GXv_int4[15] = 1;
         }
         if ( StringUtil.StrCmp(AV86Configgenwwds_22_tfconfiggencorreo_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([ConfigGenCorreo] = ''))");
         }
         if ( AV87Configgenwwds_23_tfconfiggenestado_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV87Configgenwwds_23_tfconfiggenestado_sels, "[ConfigGenEstado] IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         if ( ( AV17OrderedBy == 1 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY [ConfigGenEmpNom]";
         }
         else if ( ( AV17OrderedBy == 1 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [ConfigGenEmpNom] DESC";
         }
         else if ( ( AV17OrderedBy == 2 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY [ConfigGenID]";
         }
         else if ( ( AV17OrderedBy == 2 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [ConfigGenID] DESC";
         }
         else if ( ( AV17OrderedBy == 3 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY [ConfigGenSiglas]";
         }
         else if ( ( AV17OrderedBy == 3 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [ConfigGenSiglas] DESC";
         }
         else if ( ( AV17OrderedBy == 4 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY [ConfigGenSiteWeb]";
         }
         else if ( ( AV17OrderedBy == 4 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [ConfigGenSiteWeb] DESC";
         }
         else if ( ( AV17OrderedBy == 5 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY [ConfigGenCorreo]";
         }
         else if ( ( AV17OrderedBy == 5 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [ConfigGenCorreo] DESC";
         }
         else if ( ( AV17OrderedBy == 6 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY [ConfigGenEstado]";
         }
         else if ( ( AV17OrderedBy == 6 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [ConfigGenEstado] DESC";
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
                     return conditional_P00722(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (bool)dynConstraints[5] , (string)dynConstraints[6] , (short)dynConstraints[7] , (string)dynConstraints[8] , (bool)dynConstraints[9] , (string)dynConstraints[10] , (short)dynConstraints[11] , (string)dynConstraints[12] , (short)dynConstraints[13] , (short)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (int)dynConstraints[23] , (string)dynConstraints[24] , (short)dynConstraints[25] , (string)dynConstraints[26] , (string)dynConstraints[27] , (string)dynConstraints[28] , (short)dynConstraints[29] , (bool)dynConstraints[30] , (string)dynConstraints[31] );
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
          Object[] prmP00722;
          prmP00722 = new Object[] {
          new ParDef("@lV68Configgenwwds_4_configgenempnom1",GXType.Char,100,0) ,
          new ParDef("@lV68Configgenwwds_4_configgenempnom1",GXType.Char,100,0) ,
          new ParDef("@lV72Configgenwwds_8_configgenempnom2",GXType.Char,100,0) ,
          new ParDef("@lV72Configgenwwds_8_configgenempnom2",GXType.Char,100,0) ,
          new ParDef("@lV76Configgenwwds_12_configgenempnom3",GXType.Char,100,0) ,
          new ParDef("@lV76Configgenwwds_12_configgenempnom3",GXType.Char,100,0) ,
          new ParDef("@AV77Configgenwwds_13_tfconfiggenid",GXType.Int16,4,0) ,
          new ParDef("@AV78Configgenwwds_14_tfconfiggenid_to",GXType.Int16,4,0) ,
          new ParDef("@lV79Configgenwwds_15_tfconfiggenempnom",GXType.Char,100,0) ,
          new ParDef("@AV80Configgenwwds_16_tfconfiggenempnom_sel",GXType.NChar,100,0) ,
          new ParDef("@lV81Configgenwwds_17_tfconfiggensiglas",GXType.Char,20,0) ,
          new ParDef("@AV82Configgenwwds_18_tfconfiggensiglas_sel",GXType.NChar,20,0) ,
          new ParDef("@lV83Configgenwwds_19_tfconfiggensiteweb",GXType.Char,80,0) ,
          new ParDef("@AV84Configgenwwds_20_tfconfiggensiteweb_sel",GXType.NChar,80,0) ,
          new ParDef("@lV85Configgenwwds_21_tfconfiggencorreo",GXType.VarChar,100,0) ,
          new ParDef("@AV86Configgenwwds_22_tfconfiggencorreo_sel",GXType.NVarChar,100,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00722", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00722,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[1])[0] = rslt.getString(2, 80);
                ((string[]) buf[2])[0] = rslt.getString(3, 20);
                ((string[]) buf[3])[0] = rslt.getString(4, 100);
                ((short[]) buf[4])[0] = rslt.getShort(5);
                ((string[]) buf[5])[0] = rslt.getString(6, 3);
                return;
       }
    }

 }

}

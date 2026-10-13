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
   public class walletwwexport : GXProcedure
   {
      public walletwwexport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public walletwwexport( IGxContext context )
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
         new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWWallet", out  GXt_boolean1) ;
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
         AV12Filename = GXt_char2 + "WalletWWExport-" + StringUtil.Trim( StringUtil.Str( (decimal)(AV16Random), 8, 0)) + ".xlsx";
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
         if ( ! ( (0==AV50TFWalletId) && (0==AV51TFWalletId_To) ) )
         {
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Id", "")) ;
            AV14CellRow = GXt_int3;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Number = AV50TFWalletId;
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  false, ref  GXt_int3,  (short)(AV15FirstColumn+2),  context.GetMessage( "WWP_TSTo", "")) ;
            AV14CellRow = GXt_int3;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+3, 1, 1).Number = AV51TFWalletId_To;
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV63TFWalletCodRefencia_Sel)) ) )
         {
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Código de Refencia", "")) ;
            AV14CellRow = GXt_int3;
            GXt_char2 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV63TFWalletCodRefencia_Sel)) ? context.GetMessage( "WWP_TitleFilter_EmptyOption", "") : AV63TFWalletCodRefencia_Sel), out  GXt_char2) ;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV62TFWalletCodRefencia)) ) )
            {
               GXt_int3 = (short)(AV14CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Código de Refencia", "")) ;
               AV14CellRow = GXt_int3;
               GXt_char2 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV62TFWalletCodRefencia, out  GXt_char2) ;
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV77TFWalletNombre_Sel)) ) )
         {
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Nombre", "")) ;
            AV14CellRow = GXt_int3;
            GXt_char2 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV77TFWalletNombre_Sel)) ? context.GetMessage( "WWP_TitleFilter_EmptyOption", "") : AV77TFWalletNombre_Sel), out  GXt_char2) ;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV76TFWalletNombre)) ) )
            {
               GXt_int3 = (short)(AV14CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Nombre", "")) ;
               AV14CellRow = GXt_int3;
               GXt_char2 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV76TFWalletNombre, out  GXt_char2) ;
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV79TFMonedaISOSimbolo_Sel)) ) )
         {
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Moneda", "")) ;
            AV14CellRow = GXt_int3;
            GXt_char2 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV79TFMonedaISOSimbolo_Sel)) ? context.GetMessage( "WWP_TitleFilter_EmptyOption", "") : AV79TFMonedaISOSimbolo_Sel), out  GXt_char2) ;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV78TFMonedaISOSimbolo)) ) )
            {
               GXt_int3 = (short)(AV14CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Moneda", "")) ;
               AV14CellRow = GXt_int3;
               GXt_char2 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV78TFMonedaISOSimbolo, out  GXt_char2) ;
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char2;
            }
         }
         if ( ! ( (Convert.ToDecimal(0)==AV70TFWalletSaldo) && (Convert.ToDecimal(0)==AV71TFWalletSaldo_To) ) )
         {
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int3,  (short)(AV15FirstColumn),  context.GetMessage( "Saldo", "")) ;
            AV14CellRow = GXt_int3;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Number = (double)(AV70TFWalletSaldo);
            GXt_int3 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  false, ref  GXt_int3,  (short)(AV15FirstColumn+2),  context.GetMessage( "WWP_TSTo", "")) ;
            AV14CellRow = GXt_int3;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+3, 1, 1).Number = (double)(AV71TFWalletSaldo_To);
         }
         AV14CellRow = (int)(AV14CellRow+2);
      }

      protected void S141( )
      {
         /* 'WRITECOLUMNTITLES' Routine */
         returnInSub = false;
         AV47VisibleColumnCount = 0;
         if ( StringUtil.StrCmp(AV35Session.Get("WalletWWColumnsSelector"), "") != 0 )
         {
            AV42ColumnsSelectorXML = AV35Session.Get("WalletWWColumnsSelector");
            AV39ColumnsSelector.FromXml(AV42ColumnsSelectorXML, null, "", "");
         }
         else
         {
            /* Execute user subroutine: 'INITIALIZECOLUMNSSELECTOR' */
            S151 ();
            if (returnInSub) return;
         }
         ((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV39ColumnsSelector.gxTpr_Columns.Item(6)).gxTpr_Isvisible = false;
         AV39ColumnsSelector.gxTpr_Columns.Sort("Order");
         AV81GXV1 = 1;
         while ( AV81GXV1 <= AV39ColumnsSelector.gxTpr_Columns.Count )
         {
            AV41ColumnsSelector_Column = ((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV39ColumnsSelector.gxTpr_Columns.Item(AV81GXV1));
            if ( AV41ColumnsSelector_Column.gxTpr_Isvisible )
            {
               AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV47VisibleColumnCount), 1, 1).Text = context.GetMessage( (String.IsNullOrEmpty(StringUtil.RTrim( AV41ColumnsSelector_Column.gxTpr_Displayname)) ? AV41ColumnsSelector_Column.gxTpr_Columnname : AV41ColumnsSelector_Column.gxTpr_Displayname), "");
               AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV47VisibleColumnCount), 1, 1).Bold = 1;
               AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV47VisibleColumnCount), 1, 1).Color = 11;
               AV47VisibleColumnCount = (long)(AV47VisibleColumnCount+1);
            }
            AV81GXV1 = (int)(AV81GXV1+1);
         }
      }

      protected void S161( )
      {
         /* 'WRITEDATA' Routine */
         returnInSub = false;
         AV83Walletwwds_1_filterfulltext = AV19FilterFullText;
         AV84Walletwwds_2_tfwalletid = AV50TFWalletId;
         AV85Walletwwds_3_tfwalletid_to = AV51TFWalletId_To;
         AV86Walletwwds_4_tfwalletcodrefencia = AV62TFWalletCodRefencia;
         AV87Walletwwds_5_tfwalletcodrefencia_sel = AV63TFWalletCodRefencia_Sel;
         AV88Walletwwds_6_tfwalletnombre = AV76TFWalletNombre;
         AV89Walletwwds_7_tfwalletnombre_sel = AV77TFWalletNombre_Sel;
         AV90Walletwwds_8_tfmonedaisosimbolo = AV78TFMonedaISOSimbolo;
         AV91Walletwwds_9_tfmonedaisosimbolo_sel = AV79TFMonedaISOSimbolo_Sel;
         AV92Walletwwds_10_tfwalletsaldo = AV70TFWalletSaldo;
         AV93Walletwwds_11_tfwalletsaldo_to = AV71TFWalletSaldo_To;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV84Walletwwds_2_tfwalletid ,
                                              AV85Walletwwds_3_tfwalletid_to ,
                                              AV87Walletwwds_5_tfwalletcodrefencia_sel ,
                                              AV86Walletwwds_4_tfwalletcodrefencia ,
                                              AV91Walletwwds_9_tfmonedaisosimbolo_sel ,
                                              AV90Walletwwds_8_tfmonedaisosimbolo ,
                                              A637WalletId ,
                                              A639WalletCodRefencia ,
                                              A119MonedaISOSimbolo ,
                                              AV17OrderedBy ,
                                              AV18OrderedDsc ,
                                              AV83Walletwwds_1_filterfulltext ,
                                              A715WalletNombre ,
                                              A648WalletSaldo ,
                                              AV89Walletwwds_7_tfwalletnombre_sel ,
                                              AV88Walletwwds_6_tfwalletnombre ,
                                              AV92Walletwwds_10_tfwalletsaldo ,
                                              AV93Walletwwds_11_tfwalletsaldo_to } ,
                                              new int[]{
                                              TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL
                                              }
         });
         lV86Walletwwds_4_tfwalletcodrefencia = StringUtil.PadR( StringUtil.RTrim( AV86Walletwwds_4_tfwalletcodrefencia), 25, "%");
         lV90Walletwwds_8_tfmonedaisosimbolo = StringUtil.PadR( StringUtil.RTrim( AV90Walletwwds_8_tfmonedaisosimbolo), 3, "%");
         /* Using cursor P00BD2 */
         pr_default.execute(0, new Object[] {AV84Walletwwds_2_tfwalletid, AV85Walletwwds_3_tfwalletid_to, lV86Walletwwds_4_tfwalletcodrefencia, AV87Walletwwds_5_tfwalletcodrefencia_sel, lV90Walletwwds_8_tfmonedaisosimbolo, AV91Walletwwds_9_tfmonedaisosimbolo_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A118MonedaId = P00BD2_A118MonedaId[0];
            n118MonedaId = P00BD2_n118MonedaId[0];
            A119MonedaISOSimbolo = P00BD2_A119MonedaISOSimbolo[0];
            A639WalletCodRefencia = P00BD2_A639WalletCodRefencia[0];
            A638WalletTipoEntidad = P00BD2_A638WalletTipoEntidad[0];
            A637WalletId = P00BD2_A637WalletId[0];
            A119MonedaISOSimbolo = P00BD2_A119MonedaISOSimbolo[0];
            GXt_decimal4 = A646WalletTotalDebito;
            new owallettotaldc(context ).execute(  A637WalletId,  "DEB", out  GXt_decimal4) ;
            A646WalletTotalDebito = GXt_decimal4;
            GXt_decimal4 = A647WalletTotalCredito;
            new owallettotaldc(context ).execute(  A637WalletId,  "CRE", out  GXt_decimal4) ;
            A647WalletTotalCredito = GXt_decimal4;
            A648WalletSaldo = (decimal)(A647WalletTotalCredito-A646WalletTotalDebito);
            if ( (Convert.ToDecimal(0)==AV92Walletwwds_10_tfwalletsaldo) || ( ( A648WalletSaldo >= AV92Walletwwds_10_tfwalletsaldo ) ) )
            {
               if ( (Convert.ToDecimal(0)==AV93Walletwwds_11_tfwalletsaldo_to) || ( ( A648WalletSaldo <= AV93Walletwwds_11_tfwalletsaldo_to ) ) )
               {
                  GXt_char2 = A715WalletNombre;
                  new onombrewallet(context ).execute(  A638WalletTipoEntidad,  A639WalletCodRefencia, out  GXt_char2) ;
                  A715WalletNombre = GXt_char2;
                  if ( String.IsNullOrEmpty(StringUtil.RTrim( AV83Walletwwds_1_filterfulltext)) || ( ( StringUtil.Like( StringUtil.Str( (decimal)(A637WalletId), 18, 0) , StringUtil.PadR( "%" + AV83Walletwwds_1_filterfulltext , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A639WalletCodRefencia) , StringUtil.PadR( "%" + StringUtil.Upper( AV83Walletwwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A715WalletNombre) , StringUtil.PadR( "%" + StringUtil.Upper( AV83Walletwwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A119MonedaISOSimbolo) , StringUtil.PadR( "%" + StringUtil.Upper( AV83Walletwwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Str( A648WalletSaldo, 18, 2) , StringUtil.PadR( "%" + AV83Walletwwds_1_filterfulltext , 254 , "%"),  ' ' ) ) ) )
                  {
                     if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV89Walletwwds_7_tfwalletnombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV88Walletwwds_6_tfwalletnombre)) ) ) || ( StringUtil.Like( StringUtil.Upper( A715WalletNombre) , StringUtil.PadR( StringUtil.Upper( AV88Walletwwds_6_tfwalletnombre) , 254 , "%"),  ' ' ) ) )
                     {
                        if ( ! ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV89Walletwwds_7_tfwalletnombre_sel)) && ! ( StringUtil.StrCmp(AV89Walletwwds_7_tfwalletnombre_sel, "<#Empty#>") == 0 ) ) || ( ( StringUtil.StrCmp(A715WalletNombre, AV89Walletwwds_7_tfwalletnombre_sel) == 0 ) ) )
                        {
                           if ( ( StringUtil.StrCmp(AV89Walletwwds_7_tfwalletnombre_sel, "<#Empty#>") != 0 ) || ( String.IsNullOrEmpty(StringUtil.RTrim( A715WalletNombre)) || String.IsNullOrEmpty(StringUtil.RTrim( A715WalletNombre)) ) )
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
                              AV94GXV2 = 1;
                              while ( AV94GXV2 <= AV39ColumnsSelector.gxTpr_Columns.Count )
                              {
                                 AV41ColumnsSelector_Column = ((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV39ColumnsSelector.gxTpr_Columns.Item(AV94GXV2));
                                 if ( AV41ColumnsSelector_Column.gxTpr_Isvisible )
                                 {
                                    if ( StringUtil.StrCmp(AV41ColumnsSelector_Column.gxTpr_Columnname, "WalletId") == 0 )
                                    {
                                       AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV47VisibleColumnCount), 1, 1).Number = A637WalletId;
                                    }
                                    else if ( StringUtil.StrCmp(AV41ColumnsSelector_Column.gxTpr_Columnname, "WalletCodRefencia") == 0 )
                                    {
                                       GXt_char2 = "";
                                       new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A639WalletCodRefencia, out  GXt_char2) ;
                                       AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV47VisibleColumnCount), 1, 1).Text = GXt_char2;
                                    }
                                    else if ( StringUtil.StrCmp(AV41ColumnsSelector_Column.gxTpr_Columnname, "WalletNombre") == 0 )
                                    {
                                       GXt_char2 = "";
                                       new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A715WalletNombre, out  GXt_char2) ;
                                       AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV47VisibleColumnCount), 1, 1).Text = GXt_char2;
                                    }
                                    else if ( StringUtil.StrCmp(AV41ColumnsSelector_Column.gxTpr_Columnname, "MonedaISOSimbolo") == 0 )
                                    {
                                       GXt_char2 = "";
                                       new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A119MonedaISOSimbolo, out  GXt_char2) ;
                                       AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV47VisibleColumnCount), 1, 1).Text = GXt_char2;
                                    }
                                    else if ( StringUtil.StrCmp(AV41ColumnsSelector_Column.gxTpr_Columnname, "WalletSaldo") == 0 )
                                    {
                                       AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV47VisibleColumnCount), 1, 1).Number = (double)(A648WalletSaldo);
                                       if ( ( A648WalletSaldo < Convert.ToDecimal( 0 )) )
                                       {
                                          AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV47VisibleColumnCount), 1, 1).Color = GXUtil.RGB( 221, 75, 57);
                                       }
                                       else if ( ( A648WalletSaldo == Convert.ToDecimal( 0 )) )
                                       {
                                          AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV47VisibleColumnCount), 1, 1).Color = GXUtil.RGB( 255, 166, 90);
                                       }
                                    }
                                    AV47VisibleColumnCount = (long)(AV47VisibleColumnCount+1);
                                 }
                                 AV94GXV2 = (int)(AV94GXV2+1);
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
                        }
                     }
                  }
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
         AV35Session.Set("WWPExportFileName", "WalletWWExport.xlsx");
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
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV39ColumnsSelector,  "WalletId",  "",  "Id",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV39ColumnsSelector,  "WalletCodRefencia",  "",  "Código de Refencia",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV39ColumnsSelector,  "WalletNombre",  "",  "Nombre",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV39ColumnsSelector,  "MonedaISOSimbolo",  "",  "Moneda",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV39ColumnsSelector,  "WalletSaldo",  "",  "Saldo",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV39ColumnsSelector,  "&OperacionId",  "",  "Liquidación",  true,  "") ;
         GXt_char2 = AV43UserCustomValue;
         new GeneXus.Programs.wwpbaseobjects.loadcolumnsselectorstate(context ).execute(  "WalletWWColumnsSelector", out  GXt_char2) ;
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
         if ( StringUtil.StrCmp(AV35Session.Get("WalletWWGridState"), "") == 0 )
         {
            AV37GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "WalletWWGridState"), null, "", "");
         }
         else
         {
            AV37GridState.FromXml(AV35Session.Get("WalletWWGridState"), null, "", "");
         }
         AV17OrderedBy = AV37GridState.gxTpr_Orderedby;
         AV18OrderedDsc = AV37GridState.gxTpr_Ordereddsc;
         AV95GXV3 = 1;
         while ( AV95GXV3 <= AV37GridState.gxTpr_Filtervalues.Count )
         {
            AV38GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV37GridState.gxTpr_Filtervalues.Item(AV95GXV3));
            if ( StringUtil.StrCmp(AV38GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV19FilterFullText = AV38GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV38GridStateFilterValue.gxTpr_Name, "TFWALLETID") == 0 )
            {
               AV50TFWalletId = (long)(Math.Round(NumberUtil.Val( AV38GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV51TFWalletId_To = (long)(Math.Round(NumberUtil.Val( AV38GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV38GridStateFilterValue.gxTpr_Name, "TFWALLETCODREFENCIA") == 0 )
            {
               AV62TFWalletCodRefencia = AV38GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV38GridStateFilterValue.gxTpr_Name, "TFWALLETCODREFENCIA_SEL") == 0 )
            {
               AV63TFWalletCodRefencia_Sel = AV38GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV38GridStateFilterValue.gxTpr_Name, "TFWALLETNOMBRE") == 0 )
            {
               AV76TFWalletNombre = AV38GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV38GridStateFilterValue.gxTpr_Name, "TFWALLETNOMBRE_SEL") == 0 )
            {
               AV77TFWalletNombre_Sel = AV38GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV38GridStateFilterValue.gxTpr_Name, "TFMONEDAISOSIMBOLO") == 0 )
            {
               AV78TFMonedaISOSimbolo = AV38GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV38GridStateFilterValue.gxTpr_Name, "TFMONEDAISOSIMBOLO_SEL") == 0 )
            {
               AV79TFMonedaISOSimbolo_Sel = AV38GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV38GridStateFilterValue.gxTpr_Name, "TFWALLETSALDO") == 0 )
            {
               AV70TFWalletSaldo = NumberUtil.Val( AV38GridStateFilterValue.gxTpr_Value, ".");
               AV71TFWalletSaldo_To = NumberUtil.Val( AV38GridStateFilterValue.gxTpr_Valueto, ".");
            }
            AV95GXV3 = (int)(AV95GXV3+1);
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
         AV50TFWalletId = 0;
         AV51TFWalletId_To = 0;
         AV63TFWalletCodRefencia_Sel = "";
         AV62TFWalletCodRefencia = "";
         AV77TFWalletNombre_Sel = "";
         AV76TFWalletNombre = "";
         AV79TFMonedaISOSimbolo_Sel = "";
         AV78TFMonedaISOSimbolo = "";
         AV35Session = context.GetSession();
         AV42ColumnsSelectorXML = "";
         AV39ColumnsSelector = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector(context);
         AV41ColumnsSelector_Column = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column(context);
         AV83Walletwwds_1_filterfulltext = "";
         AV86Walletwwds_4_tfwalletcodrefencia = "";
         AV87Walletwwds_5_tfwalletcodrefencia_sel = "";
         AV88Walletwwds_6_tfwalletnombre = "";
         AV89Walletwwds_7_tfwalletnombre_sel = "";
         AV90Walletwwds_8_tfmonedaisosimbolo = "";
         AV91Walletwwds_9_tfmonedaisosimbolo_sel = "";
         lV86Walletwwds_4_tfwalletcodrefencia = "";
         lV90Walletwwds_8_tfmonedaisosimbolo = "";
         A639WalletCodRefencia = "";
         A119MonedaISOSimbolo = "";
         A715WalletNombre = "";
         P00BD2_A118MonedaId = new short[1] ;
         P00BD2_n118MonedaId = new bool[] {false} ;
         P00BD2_A119MonedaISOSimbolo = new string[] {""} ;
         P00BD2_A639WalletCodRefencia = new string[] {""} ;
         P00BD2_A638WalletTipoEntidad = new string[] {""} ;
         P00BD2_A637WalletId = new long[1] ;
         A638WalletTipoEntidad = "";
         AV43UserCustomValue = "";
         GXt_char2 = "";
         AV40ColumnsSelectorAux = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector(context);
         AV37GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV38GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.walletwwexport__default(),
            new Object[][] {
                new Object[] {
               P00BD2_A118MonedaId, P00BD2_n118MonedaId, P00BD2_A119MonedaISOSimbolo, P00BD2_A639WalletCodRefencia, P00BD2_A638WalletTipoEntidad, P00BD2_A637WalletId
               }
            }
         );
         AV80Pgmname = "WalletWWExport";
         /* GeneXus formulas. */
         AV80Pgmname = "WalletWWExport";
      }

      private short GXt_int3 ;
      private short AV17OrderedBy ;
      private short A118MonedaId ;
      private int AV14CellRow ;
      private int AV15FirstColumn ;
      private int AV16Random ;
      private int AV81GXV1 ;
      private int AV94GXV2 ;
      private int AV95GXV3 ;
      private long AV50TFWalletId ;
      private long AV51TFWalletId_To ;
      private long AV47VisibleColumnCount ;
      private long AV84Walletwwds_2_tfwalletid ;
      private long AV85Walletwwds_3_tfwalletid_to ;
      private long A637WalletId ;
      private decimal AV70TFWalletSaldo ;
      private decimal AV71TFWalletSaldo_To ;
      private decimal AV92Walletwwds_10_tfwalletsaldo ;
      private decimal AV93Walletwwds_11_tfwalletsaldo_to ;
      private decimal A648WalletSaldo ;
      private decimal A646WalletTotalDebito ;
      private decimal A647WalletTotalCredito ;
      private decimal GXt_decimal4 ;
      private string AV80Pgmname ;
      private string GXKey ;
      private string GXEncryptionTmp ;
      private string AV63TFWalletCodRefencia_Sel ;
      private string AV62TFWalletCodRefencia ;
      private string AV77TFWalletNombre_Sel ;
      private string AV76TFWalletNombre ;
      private string AV79TFMonedaISOSimbolo_Sel ;
      private string AV78TFMonedaISOSimbolo ;
      private string AV86Walletwwds_4_tfwalletcodrefencia ;
      private string AV87Walletwwds_5_tfwalletcodrefencia_sel ;
      private string AV88Walletwwds_6_tfwalletnombre ;
      private string AV89Walletwwds_7_tfwalletnombre_sel ;
      private string AV90Walletwwds_8_tfmonedaisosimbolo ;
      private string AV91Walletwwds_9_tfmonedaisosimbolo_sel ;
      private string lV86Walletwwds_4_tfwalletcodrefencia ;
      private string lV90Walletwwds_8_tfmonedaisosimbolo ;
      private string A639WalletCodRefencia ;
      private string A119MonedaISOSimbolo ;
      private string A715WalletNombre ;
      private string A638WalletTipoEntidad ;
      private string GXt_char2 ;
      private bool AV8IsAuthorized ;
      private bool GXt_boolean1 ;
      private bool returnInSub ;
      private bool AV18OrderedDsc ;
      private bool n118MonedaId ;
      private string AV42ColumnsSelectorXML ;
      private string AV43UserCustomValue ;
      private string AV12Filename ;
      private string AV13ErrorMessage ;
      private string AV19FilterFullText ;
      private string AV83Walletwwds_1_filterfulltext ;
      private IGxSession AV35Session ;
      private ExcelDocumentI AV11ExcelDocument ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector AV39ColumnsSelector ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column AV41ColumnsSelector_Column ;
      private IDataStoreProvider pr_default ;
      private short[] P00BD2_A118MonedaId ;
      private bool[] P00BD2_n118MonedaId ;
      private string[] P00BD2_A119MonedaISOSimbolo ;
      private string[] P00BD2_A639WalletCodRefencia ;
      private string[] P00BD2_A638WalletTipoEntidad ;
      private long[] P00BD2_A637WalletId ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector AV40ColumnsSelectorAux ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV37GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV38GridStateFilterValue ;
      private string aP0_Filename ;
      private string aP1_ErrorMessage ;
   }

   public class walletwwexport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00BD2( IGxContext context ,
                                             long AV84Walletwwds_2_tfwalletid ,
                                             long AV85Walletwwds_3_tfwalletid_to ,
                                             string AV87Walletwwds_5_tfwalletcodrefencia_sel ,
                                             string AV86Walletwwds_4_tfwalletcodrefencia ,
                                             string AV91Walletwwds_9_tfmonedaisosimbolo_sel ,
                                             string AV90Walletwwds_8_tfmonedaisosimbolo ,
                                             long A637WalletId ,
                                             string A639WalletCodRefencia ,
                                             string A119MonedaISOSimbolo ,
                                             short AV17OrderedBy ,
                                             bool AV18OrderedDsc ,
                                             string AV83Walletwwds_1_filterfulltext ,
                                             string A715WalletNombre ,
                                             decimal A648WalletSaldo ,
                                             string AV89Walletwwds_7_tfwalletnombre_sel ,
                                             string AV88Walletwwds_6_tfwalletnombre ,
                                             decimal AV92Walletwwds_10_tfwalletsaldo ,
                                             decimal AV93Walletwwds_11_tfwalletsaldo_to )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int5 = new short[6];
         Object[] GXv_Object6 = new Object[2];
         scmdbuf = "SELECT T1.[MonedaId], T2.[MonedaISOSimbolo], T1.[WalletCodRefencia], T1.[WalletTipoEntidad], T1.[WalletId] FROM ([Wallet] T1 LEFT JOIN [Moneda] T2 ON T2.[MonedaId] = T1.[MonedaId])";
         if ( ! (0==AV84Walletwwds_2_tfwalletid) )
         {
            AddWhere(sWhereString, "(T1.[WalletId] >= @AV84Walletwwds_2_tfwalletid)");
         }
         else
         {
            GXv_int5[0] = 1;
         }
         if ( ! (0==AV85Walletwwds_3_tfwalletid_to) )
         {
            AddWhere(sWhereString, "(T1.[WalletId] <= @AV85Walletwwds_3_tfwalletid_to)");
         }
         else
         {
            GXv_int5[1] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV87Walletwwds_5_tfwalletcodrefencia_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV86Walletwwds_4_tfwalletcodrefencia)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[WalletCodRefencia]) like UPPER(@lV86Walletwwds_4_tfwalletcodrefencia))");
         }
         else
         {
            GXv_int5[2] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV87Walletwwds_5_tfwalletcodrefencia_sel)) && ! ( StringUtil.StrCmp(AV87Walletwwds_5_tfwalletcodrefencia_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[WalletCodRefencia] = @AV87Walletwwds_5_tfwalletcodrefencia_sel)");
         }
         else
         {
            GXv_int5[3] = 1;
         }
         if ( StringUtil.StrCmp(AV87Walletwwds_5_tfwalletcodrefencia_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[WalletCodRefencia] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV91Walletwwds_9_tfmonedaisosimbolo_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV90Walletwwds_8_tfmonedaisosimbolo)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[MonedaISOSimbolo]) like UPPER(@lV90Walletwwds_8_tfmonedaisosimbolo))");
         }
         else
         {
            GXv_int5[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV91Walletwwds_9_tfmonedaisosimbolo_sel)) && ! ( StringUtil.StrCmp(AV91Walletwwds_9_tfmonedaisosimbolo_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.[MonedaISOSimbolo] = @AV91Walletwwds_9_tfmonedaisosimbolo_sel)");
         }
         else
         {
            GXv_int5[5] = 1;
         }
         if ( StringUtil.StrCmp(AV91Walletwwds_9_tfmonedaisosimbolo_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T2.[MonedaISOSimbolo] IS NULL or (T2.[MonedaISOSimbolo] = ''))");
         }
         scmdbuf += sWhereString;
         if ( ( AV17OrderedBy == 1 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[WalletId]";
         }
         else if ( ( AV17OrderedBy == 1 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[WalletId] DESC";
         }
         else if ( ( AV17OrderedBy == 2 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[WalletCodRefencia]";
         }
         else if ( ( AV17OrderedBy == 2 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[WalletCodRefencia] DESC";
         }
         else if ( ( AV17OrderedBy == 3 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T2.[MonedaISOSimbolo]";
         }
         else if ( ( AV17OrderedBy == 3 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T2.[MonedaISOSimbolo] DESC";
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
                     return conditional_P00BD2(context, (long)dynConstraints[0] , (long)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (long)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (short)dynConstraints[9] , (bool)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (decimal)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (decimal)dynConstraints[16] , (decimal)dynConstraints[17] );
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
          Object[] prmP00BD2;
          prmP00BD2 = new Object[] {
          new ParDef("@AV84Walletwwds_2_tfwalletid",GXType.Decimal,18,0) ,
          new ParDef("@AV85Walletwwds_3_tfwalletid_to",GXType.Decimal,18,0) ,
          new ParDef("@lV86Walletwwds_4_tfwalletcodrefencia",GXType.Char,25,0) ,
          new ParDef("@AV87Walletwwds_5_tfwalletcodrefencia_sel",GXType.NChar,25,0) ,
          new ParDef("@lV90Walletwwds_8_tfmonedaisosimbolo",GXType.Char,3,0) ,
          new ParDef("@AV91Walletwwds_9_tfmonedaisosimbolo_sel",GXType.NChar,3,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00BD2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00BD2,100, GxCacheFrequency.OFF ,true,false )
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
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getString(2, 3);
                ((string[]) buf[3])[0] = rslt.getString(3, 25);
                ((string[]) buf[4])[0] = rslt.getString(4, 3);
                ((long[]) buf[5])[0] = rslt.getLong(5);
                return;
       }
    }

 }

}

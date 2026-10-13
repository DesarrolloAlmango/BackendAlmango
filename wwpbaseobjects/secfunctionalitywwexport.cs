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
namespace GeneXus.Programs.wwpbaseobjects {
   public class secfunctionalitywwexport : GXProcedure
   {
      public secfunctionalitywwexport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public secfunctionalitywwexport( IGxContext context )
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
         new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWSecFunctionality", out  GXt_boolean1) ;
         AV8IsAuthorized = GXt_boolean1;
         if ( ! AV8IsAuthorized )
         {
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "wwpbaseobjects.notauthorized.aspx"+GXUtil.UrlEncode(StringUtil.RTrim(AV48Pgmname));
            CallWebObject(formatLink("wwpbaseobjects.notauthorized.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
            context.wjLocDisableFrm = 1;
         }
         if ( AV8IsAuthorized )
         {
            new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV39WWPContext) ;
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
         AV15Random = (int)(NumberUtil.Random( )*10000);
         GXt_char2 = AV11Filename;
         new GeneXus.Programs.wwpbaseobjects.wwp_getdefaultexportpath(context ).execute( out  GXt_char2) ;
         AV11Filename = GXt_char2 + "SecFunctionalityWWExport-" + StringUtil.Trim( StringUtil.Str( (decimal)(AV15Random), 8, 0)) + ".xlsx";
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
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV47FilterFullText)) ) )
         {
            GXt_int3 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int3,  (short)(AV14FirstColumn),  context.GetMessage( "WWP_FullTextFilterDescription", "")) ;
            AV13CellRow = GXt_int3;
            GXt_char2 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV47FilterFullText, out  GXt_char2) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char2;
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV22TFSecFunctionalityKey_Sel)) ) )
         {
            GXt_int3 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int3,  (short)(AV14FirstColumn),  context.GetMessage( "Key", "")) ;
            AV13CellRow = GXt_int3;
            GXt_char2 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV22TFSecFunctionalityKey_Sel)) ? context.GetMessage( "WWP_TitleFilter_EmptyOption", "") : AV22TFSecFunctionalityKey_Sel), out  GXt_char2) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char2;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV21TFSecFunctionalityKey)) ) )
            {
               GXt_int3 = (short)(AV13CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int3,  (short)(AV14FirstColumn),  context.GetMessage( "Key", "")) ;
               AV13CellRow = GXt_int3;
               GXt_char2 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV21TFSecFunctionalityKey, out  GXt_char2) ;
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char2;
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV24TFSecFunctionalityDescription_Sel)) ) )
         {
            GXt_int3 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int3,  (short)(AV14FirstColumn),  context.GetMessage( "Description", "")) ;
            AV13CellRow = GXt_int3;
            GXt_char2 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV24TFSecFunctionalityDescription_Sel)) ? context.GetMessage( "WWP_TitleFilter_EmptyOption", "") : AV24TFSecFunctionalityDescription_Sel), out  GXt_char2) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char2;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV23TFSecFunctionalityDescription)) ) )
            {
               GXt_int3 = (short)(AV13CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int3,  (short)(AV14FirstColumn),  context.GetMessage( "Description", "")) ;
               AV13CellRow = GXt_int3;
               GXt_char2 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV23TFSecFunctionalityDescription, out  GXt_char2) ;
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char2;
            }
         }
         if ( ! ( ( AV44TFSecFunctionalityType_Sels.Count == 0 ) ) )
         {
            GXt_int3 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int3,  (short)(AV14FirstColumn),  context.GetMessage( "Type", "")) ;
            AV13CellRow = GXt_int3;
            AV35i = 1;
            AV49GXV1 = 1;
            while ( AV49GXV1 <= AV44TFSecFunctionalityType_Sels.Count )
            {
               AV25TFSecFunctionalityType_Sel = (short)(AV44TFSecFunctionalityType_Sels.GetNumeric(AV49GXV1));
               if ( AV35i == 1 )
               {
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "";
               }
               else
               {
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text+", ";
               }
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text+context.GetMessage( gxdomainwwpsecfunctionalitytypes.getDescription(context,AV25TFSecFunctionalityType_Sel), "");
               AV35i = (long)(AV35i+1);
               AV49GXV1 = (int)(AV49GXV1+1);
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV27TFSecParentFunctionalityDescription_Sel)) ) )
         {
            GXt_int3 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int3,  (short)(AV14FirstColumn),  context.GetMessage( "Parent Functionality", "")) ;
            AV13CellRow = GXt_int3;
            GXt_char2 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV27TFSecParentFunctionalityDescription_Sel)) ? context.GetMessage( "WWP_TitleFilter_EmptyOption", "") : AV27TFSecParentFunctionalityDescription_Sel), out  GXt_char2) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char2;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV26TFSecParentFunctionalityDescription)) ) )
            {
               GXt_int3 = (short)(AV13CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int3,  (short)(AV14FirstColumn),  context.GetMessage( "Parent Functionality", "")) ;
               AV13CellRow = GXt_int3;
               GXt_char2 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV26TFSecParentFunctionalityDescription, out  GXt_char2) ;
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char2;
            }
         }
         AV13CellRow = (int)(AV13CellRow+2);
      }

      protected void S141( )
      {
         /* 'WRITECOLUMNTITLES' Routine */
         returnInSub = false;
         AV36VisibleColumnCount = 0;
         if ( StringUtil.StrCmp(AV30Session.Get("WWPBaseObjects.SecFunctionalityWWColumnsSelector"), "") != 0 )
         {
            AV29ColumnsSelectorXML = AV30Session.Get("WWPBaseObjects.SecFunctionalityWWColumnsSelector");
            AV28ColumnsSelector.FromXml(AV29ColumnsSelectorXML, null, "", "");
         }
         else
         {
            /* Execute user subroutine: 'INITIALIZECOLUMNSSELECTOR' */
            S151 ();
            if (returnInSub) return;
         }
         AV28ColumnsSelector.gxTpr_Columns.Sort("Order");
         AV50GXV2 = 1;
         while ( AV50GXV2 <= AV28ColumnsSelector.gxTpr_Columns.Count )
         {
            AV46ColumnsSelector_Column = ((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV28ColumnsSelector.gxTpr_Columns.Item(AV50GXV2));
            if ( AV46ColumnsSelector_Column.gxTpr_Isvisible )
            {
               AV10ExcelDocument.get_Cells(AV13CellRow, (int)(AV14FirstColumn+AV36VisibleColumnCount), 1, 1).Text = context.GetMessage( (String.IsNullOrEmpty(StringUtil.RTrim( AV46ColumnsSelector_Column.gxTpr_Displayname)) ? AV46ColumnsSelector_Column.gxTpr_Columnname : AV46ColumnsSelector_Column.gxTpr_Displayname), "");
               AV10ExcelDocument.get_Cells(AV13CellRow, (int)(AV14FirstColumn+AV36VisibleColumnCount), 1, 1).Bold = 1;
               AV10ExcelDocument.get_Cells(AV13CellRow, (int)(AV14FirstColumn+AV36VisibleColumnCount), 1, 1).Color = 11;
               AV36VisibleColumnCount = (long)(AV36VisibleColumnCount+1);
            }
            AV50GXV2 = (int)(AV50GXV2+1);
         }
      }

      protected void S161( )
      {
         /* 'WRITEDATA' Routine */
         returnInSub = false;
         AV52Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext = AV47FilterFullText;
         AV53Wwpbaseobjects_secfunctionalitywwds_2_tfsecfunctionalitykey = AV21TFSecFunctionalityKey;
         AV54Wwpbaseobjects_secfunctionalitywwds_3_tfsecfunctionalitykey_sel = AV22TFSecFunctionalityKey_Sel;
         AV55Wwpbaseobjects_secfunctionalitywwds_4_tfsecfunctionalitydescription = AV23TFSecFunctionalityDescription;
         AV56Wwpbaseobjects_secfunctionalitywwds_5_tfsecfunctionalitydescription_sel = AV24TFSecFunctionalityDescription_Sel;
         AV57Wwpbaseobjects_secfunctionalitywwds_6_tfsecfunctionalitytype_sels = AV44TFSecFunctionalityType_Sels;
         AV58Wwpbaseobjects_secfunctionalitywwds_7_tfsecparentfunctionalitydescription = AV26TFSecParentFunctionalityDescription;
         AV59Wwpbaseobjects_secfunctionalitywwds_8_tfsecparentfunctionalitydescription_sel = AV27TFSecParentFunctionalityDescription_Sel;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A21SecFunctionalityType ,
                                              AV57Wwpbaseobjects_secfunctionalitywwds_6_tfsecfunctionalitytype_sels ,
                                              AV54Wwpbaseobjects_secfunctionalitywwds_3_tfsecfunctionalitykey_sel ,
                                              AV53Wwpbaseobjects_secfunctionalitywwds_2_tfsecfunctionalitykey ,
                                              AV56Wwpbaseobjects_secfunctionalitywwds_5_tfsecfunctionalitydescription_sel ,
                                              AV55Wwpbaseobjects_secfunctionalitywwds_4_tfsecfunctionalitydescription ,
                                              AV57Wwpbaseobjects_secfunctionalitywwds_6_tfsecfunctionalitytype_sels.Count ,
                                              AV59Wwpbaseobjects_secfunctionalitywwds_8_tfsecparentfunctionalitydescription_sel ,
                                              AV58Wwpbaseobjects_secfunctionalitywwds_7_tfsecparentfunctionalitydescription ,
                                              A15SecFunctionalityKey ,
                                              A20SecFunctionalityDescription ,
                                              A23SecParentFunctionalityDescript ,
                                              AV16OrderedBy ,
                                              AV17OrderedDsc ,
                                              AV52Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.INT, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV53Wwpbaseobjects_secfunctionalitywwds_2_tfsecfunctionalitykey = StringUtil.Concat( StringUtil.RTrim( AV53Wwpbaseobjects_secfunctionalitywwds_2_tfsecfunctionalitykey), "%", "");
         lV55Wwpbaseobjects_secfunctionalitywwds_4_tfsecfunctionalitydescription = StringUtil.Concat( StringUtil.RTrim( AV55Wwpbaseobjects_secfunctionalitywwds_4_tfsecfunctionalitydescription), "%", "");
         lV58Wwpbaseobjects_secfunctionalitywwds_7_tfsecparentfunctionalitydescription = StringUtil.Concat( StringUtil.RTrim( AV58Wwpbaseobjects_secfunctionalitywwds_7_tfsecparentfunctionalitydescription), "%", "");
         /* Using cursor P002D2 */
         pr_default.execute(0, new Object[] {lV53Wwpbaseobjects_secfunctionalitywwds_2_tfsecfunctionalitykey, AV54Wwpbaseobjects_secfunctionalitywwds_3_tfsecfunctionalitykey_sel, lV55Wwpbaseobjects_secfunctionalitywwds_4_tfsecfunctionalitydescription, AV56Wwpbaseobjects_secfunctionalitywwds_5_tfsecfunctionalitydescription_sel, lV58Wwpbaseobjects_secfunctionalitywwds_7_tfsecparentfunctionalitydescription, AV59Wwpbaseobjects_secfunctionalitywwds_8_tfsecparentfunctionalitydescription_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A14SecParentFunctionalityId = P002D2_A14SecParentFunctionalityId[0];
            n14SecParentFunctionalityId = P002D2_n14SecParentFunctionalityId[0];
            A23SecParentFunctionalityDescript = P002D2_A23SecParentFunctionalityDescript[0];
            A20SecFunctionalityDescription = P002D2_A20SecFunctionalityDescription[0];
            A15SecFunctionalityKey = P002D2_A15SecFunctionalityKey[0];
            A21SecFunctionalityType = P002D2_A21SecFunctionalityType[0];
            A13SecFunctionalityId = P002D2_A13SecFunctionalityId[0];
            A23SecParentFunctionalityDescript = P002D2_A23SecParentFunctionalityDescript[0];
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV52Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext)) || ( ( StringUtil.Like( StringUtil.Upper( A15SecFunctionalityKey) , StringUtil.PadR( "%" + StringUtil.Upper( AV52Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A20SecFunctionalityDescription) , StringUtil.PadR( "%" + StringUtil.Upper( AV52Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( context.GetMessage( "mode", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV52Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( A21SecFunctionalityType == 1 ) ) || ( StringUtil.Like( context.GetMessage( "action", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV52Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( A21SecFunctionalityType == 2 ) ) || ( StringUtil.Like( context.GetMessage( "tab", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV52Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( A21SecFunctionalityType == 3 ) ) || ( StringUtil.Like( context.GetMessage( "object", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV52Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( A21SecFunctionalityType == 4 ) ) || ( StringUtil.Like( context.GetMessage( "attribute", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV52Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( A21SecFunctionalityType == 5 ) ) || ( StringUtil.Like( StringUtil.Upper( A23SecParentFunctionalityDescript) , StringUtil.PadR( "%" + StringUtil.Upper( AV52Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) ) )
            {
               AV13CellRow = (int)(AV13CellRow+1);
               /* Execute user subroutine: 'BEFOREWRITELINE' */
               S172 ();
               if ( returnInSub )
               {
                  pr_default.close(0);
                  returnInSub = true;
                  if (true) return;
               }
               AV36VisibleColumnCount = 0;
               AV60GXV3 = 1;
               while ( AV60GXV3 <= AV28ColumnsSelector.gxTpr_Columns.Count )
               {
                  AV46ColumnsSelector_Column = ((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV28ColumnsSelector.gxTpr_Columns.Item(AV60GXV3));
                  if ( AV46ColumnsSelector_Column.gxTpr_Isvisible )
                  {
                     if ( StringUtil.StrCmp(AV46ColumnsSelector_Column.gxTpr_Columnname, "SecFunctionalityKey") == 0 )
                     {
                        GXt_char2 = "";
                        new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A15SecFunctionalityKey, out  GXt_char2) ;
                        AV10ExcelDocument.get_Cells(AV13CellRow, (int)(AV14FirstColumn+AV36VisibleColumnCount), 1, 1).Text = GXt_char2;
                     }
                     else if ( StringUtil.StrCmp(AV46ColumnsSelector_Column.gxTpr_Columnname, "SecFunctionalityDescription") == 0 )
                     {
                        GXt_char2 = "";
                        new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A20SecFunctionalityDescription, out  GXt_char2) ;
                        AV10ExcelDocument.get_Cells(AV13CellRow, (int)(AV14FirstColumn+AV36VisibleColumnCount), 1, 1).Text = GXt_char2;
                     }
                     else if ( StringUtil.StrCmp(AV46ColumnsSelector_Column.gxTpr_Columnname, "SecFunctionalityType") == 0 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, (int)(AV14FirstColumn+AV36VisibleColumnCount), 1, 1).Text = context.GetMessage( gxdomainwwpsecfunctionalitytypes.getDescription(context,A21SecFunctionalityType), "");
                     }
                     else if ( StringUtil.StrCmp(AV46ColumnsSelector_Column.gxTpr_Columnname, "SecParentFunctionalityDescription") == 0 )
                     {
                        GXt_char2 = "";
                        new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A23SecParentFunctionalityDescript, out  GXt_char2) ;
                        AV10ExcelDocument.get_Cells(AV13CellRow, (int)(AV14FirstColumn+AV36VisibleColumnCount), 1, 1).Text = GXt_char2;
                     }
                     AV36VisibleColumnCount = (long)(AV36VisibleColumnCount+1);
                  }
                  AV60GXV3 = (int)(AV60GXV3+1);
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
         AV10ExcelDocument.Save();
         /* Execute user subroutine: 'CHECKSTATUS' */
         S121 ();
         if (returnInSub) return;
         AV10ExcelDocument.Close();
         AV30Session.Set("WWPExportFilePath", AV11Filename);
         AV30Session.Set("WWPExportFileName", "SecFunctionalityWWExport.xlsx");
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

      protected void S151( )
      {
         /* 'INITIALIZECOLUMNSSELECTOR' Routine */
         returnInSub = false;
         AV28ColumnsSelector = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector(context);
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV28ColumnsSelector,  "SecFunctionalityKey",  "",  "Key",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV28ColumnsSelector,  "SecFunctionalityDescription",  "",  "Description",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV28ColumnsSelector,  "SecFunctionalityType",  "",  "Type",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV28ColumnsSelector,  "SecParentFunctionalityDescription",  "",  "Parent Functionality",  true,  "") ;
         GXt_char2 = AV31UserCustomValue;
         new GeneXus.Programs.wwpbaseobjects.loadcolumnsselectorstate(context ).execute(  "WWPBaseObjects.SecFunctionalityWWColumnsSelector", out  GXt_char2) ;
         AV31UserCustomValue = GXt_char2;
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV31UserCustomValue)) ) )
         {
            AV45ColumnsSelectorAux.FromXml(AV31UserCustomValue, null, "", "");
            new GeneXus.Programs.wwpbaseobjects.wwp_columnselector_updatecolumns(context ).execute( ref  AV45ColumnsSelectorAux, ref  AV28ColumnsSelector) ;
         }
      }

      protected void S201( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV30Session.Get("WWPBaseObjects.SecFunctionalityWWGridState"), "") == 0 )
         {
            AV41GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "WWPBaseObjects.SecFunctionalityWWGridState"), null, "", "");
         }
         else
         {
            AV41GridState.FromXml(AV30Session.Get("WWPBaseObjects.SecFunctionalityWWGridState"), null, "", "");
         }
         AV16OrderedBy = AV41GridState.gxTpr_Orderedby;
         AV17OrderedDsc = AV41GridState.gxTpr_Ordereddsc;
         AV61GXV4 = 1;
         while ( AV61GXV4 <= AV41GridState.gxTpr_Filtervalues.Count )
         {
            AV42GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV41GridState.gxTpr_Filtervalues.Item(AV61GXV4));
            if ( StringUtil.StrCmp(AV42GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV47FilterFullText = AV42GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV42GridStateFilterValue.gxTpr_Name, "TFSECFUNCTIONALITYKEY") == 0 )
            {
               AV21TFSecFunctionalityKey = AV42GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV42GridStateFilterValue.gxTpr_Name, "TFSECFUNCTIONALITYKEY_SEL") == 0 )
            {
               AV22TFSecFunctionalityKey_Sel = AV42GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV42GridStateFilterValue.gxTpr_Name, "TFSECFUNCTIONALITYDESCRIPTION") == 0 )
            {
               AV23TFSecFunctionalityDescription = AV42GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV42GridStateFilterValue.gxTpr_Name, "TFSECFUNCTIONALITYDESCRIPTION_SEL") == 0 )
            {
               AV24TFSecFunctionalityDescription_Sel = AV42GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV42GridStateFilterValue.gxTpr_Name, "TFSECFUNCTIONALITYTYPE_SEL") == 0 )
            {
               AV43TFSecFunctionalityType_SelsJson = AV42GridStateFilterValue.gxTpr_Value;
               AV44TFSecFunctionalityType_Sels.FromJSonString(AV43TFSecFunctionalityType_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV42GridStateFilterValue.gxTpr_Name, "TFSECPARENTFUNCTIONALITYDESCRIPTION") == 0 )
            {
               AV26TFSecParentFunctionalityDescription = AV42GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV42GridStateFilterValue.gxTpr_Name, "TFSECPARENTFUNCTIONALITYDESCRIPTION_SEL") == 0 )
            {
               AV27TFSecParentFunctionalityDescription_Sel = AV42GridStateFilterValue.gxTpr_Value;
            }
            AV61GXV4 = (int)(AV61GXV4+1);
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
         AV11Filename = "";
         AV12ErrorMessage = "";
         AV48Pgmname = "";
         GXKey = "";
         GXEncryptionTmp = "";
         AV39WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV10ExcelDocument = new ExcelDocumentI();
         AV47FilterFullText = "";
         AV22TFSecFunctionalityKey_Sel = "";
         AV21TFSecFunctionalityKey = "";
         AV24TFSecFunctionalityDescription_Sel = "";
         AV23TFSecFunctionalityDescription = "";
         AV44TFSecFunctionalityType_Sels = new GxSimpleCollection<short>();
         AV27TFSecParentFunctionalityDescription_Sel = "";
         AV26TFSecParentFunctionalityDescription = "";
         AV30Session = context.GetSession();
         AV29ColumnsSelectorXML = "";
         AV28ColumnsSelector = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector(context);
         AV46ColumnsSelector_Column = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column(context);
         AV52Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext = "";
         AV53Wwpbaseobjects_secfunctionalitywwds_2_tfsecfunctionalitykey = "";
         AV54Wwpbaseobjects_secfunctionalitywwds_3_tfsecfunctionalitykey_sel = "";
         AV55Wwpbaseobjects_secfunctionalitywwds_4_tfsecfunctionalitydescription = "";
         AV56Wwpbaseobjects_secfunctionalitywwds_5_tfsecfunctionalitydescription_sel = "";
         AV57Wwpbaseobjects_secfunctionalitywwds_6_tfsecfunctionalitytype_sels = new GxSimpleCollection<short>();
         AV58Wwpbaseobjects_secfunctionalitywwds_7_tfsecparentfunctionalitydescription = "";
         AV59Wwpbaseobjects_secfunctionalitywwds_8_tfsecparentfunctionalitydescription_sel = "";
         lV52Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext = "";
         lV53Wwpbaseobjects_secfunctionalitywwds_2_tfsecfunctionalitykey = "";
         lV55Wwpbaseobjects_secfunctionalitywwds_4_tfsecfunctionalitydescription = "";
         lV58Wwpbaseobjects_secfunctionalitywwds_7_tfsecparentfunctionalitydescription = "";
         A15SecFunctionalityKey = "";
         A20SecFunctionalityDescription = "";
         A23SecParentFunctionalityDescript = "";
         P002D2_A14SecParentFunctionalityId = new long[1] ;
         P002D2_n14SecParentFunctionalityId = new bool[] {false} ;
         P002D2_A23SecParentFunctionalityDescript = new string[] {""} ;
         P002D2_A20SecFunctionalityDescription = new string[] {""} ;
         P002D2_A15SecFunctionalityKey = new string[] {""} ;
         P002D2_A21SecFunctionalityType = new short[1] ;
         P002D2_A13SecFunctionalityId = new long[1] ;
         AV31UserCustomValue = "";
         GXt_char2 = "";
         AV45ColumnsSelectorAux = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector(context);
         AV41GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV42GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV43TFSecFunctionalityType_SelsJson = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.secfunctionalitywwexport__default(),
            new Object[][] {
                new Object[] {
               P002D2_A14SecParentFunctionalityId, P002D2_n14SecParentFunctionalityId, P002D2_A23SecParentFunctionalityDescript, P002D2_A20SecFunctionalityDescription, P002D2_A15SecFunctionalityKey, P002D2_A21SecFunctionalityType, P002D2_A13SecFunctionalityId
               }
            }
         );
         AV48Pgmname = "WWPBaseObjects.SecFunctionalityWWExport";
         /* GeneXus formulas. */
         AV48Pgmname = "WWPBaseObjects.SecFunctionalityWWExport";
      }

      private short AV25TFSecFunctionalityType_Sel ;
      private short GXt_int3 ;
      private short A21SecFunctionalityType ;
      private short AV16OrderedBy ;
      private int AV13CellRow ;
      private int AV14FirstColumn ;
      private int AV15Random ;
      private int AV49GXV1 ;
      private int AV50GXV2 ;
      private int AV57Wwpbaseobjects_secfunctionalitywwds_6_tfsecfunctionalitytype_sels_Count ;
      private int AV60GXV3 ;
      private int AV61GXV4 ;
      private long AV35i ;
      private long AV36VisibleColumnCount ;
      private long A14SecParentFunctionalityId ;
      private long A13SecFunctionalityId ;
      private string AV48Pgmname ;
      private string GXKey ;
      private string GXEncryptionTmp ;
      private string GXt_char2 ;
      private bool AV8IsAuthorized ;
      private bool GXt_boolean1 ;
      private bool returnInSub ;
      private bool AV17OrderedDsc ;
      private bool n14SecParentFunctionalityId ;
      private string AV29ColumnsSelectorXML ;
      private string AV31UserCustomValue ;
      private string AV43TFSecFunctionalityType_SelsJson ;
      private string AV11Filename ;
      private string AV12ErrorMessage ;
      private string AV47FilterFullText ;
      private string AV22TFSecFunctionalityKey_Sel ;
      private string AV21TFSecFunctionalityKey ;
      private string AV24TFSecFunctionalityDescription_Sel ;
      private string AV23TFSecFunctionalityDescription ;
      private string AV27TFSecParentFunctionalityDescription_Sel ;
      private string AV26TFSecParentFunctionalityDescription ;
      private string AV52Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext ;
      private string AV53Wwpbaseobjects_secfunctionalitywwds_2_tfsecfunctionalitykey ;
      private string AV54Wwpbaseobjects_secfunctionalitywwds_3_tfsecfunctionalitykey_sel ;
      private string AV55Wwpbaseobjects_secfunctionalitywwds_4_tfsecfunctionalitydescription ;
      private string AV56Wwpbaseobjects_secfunctionalitywwds_5_tfsecfunctionalitydescription_sel ;
      private string AV58Wwpbaseobjects_secfunctionalitywwds_7_tfsecparentfunctionalitydescription ;
      private string AV59Wwpbaseobjects_secfunctionalitywwds_8_tfsecparentfunctionalitydescription_sel ;
      private string lV52Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext ;
      private string lV53Wwpbaseobjects_secfunctionalitywwds_2_tfsecfunctionalitykey ;
      private string lV55Wwpbaseobjects_secfunctionalitywwds_4_tfsecfunctionalitydescription ;
      private string lV58Wwpbaseobjects_secfunctionalitywwds_7_tfsecparentfunctionalitydescription ;
      private string A15SecFunctionalityKey ;
      private string A20SecFunctionalityDescription ;
      private string A23SecParentFunctionalityDescript ;
      private IGxSession AV30Session ;
      private ExcelDocumentI AV10ExcelDocument ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV39WWPContext ;
      private GxSimpleCollection<short> AV44TFSecFunctionalityType_Sels ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector AV28ColumnsSelector ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column AV46ColumnsSelector_Column ;
      private GxSimpleCollection<short> AV57Wwpbaseobjects_secfunctionalitywwds_6_tfsecfunctionalitytype_sels ;
      private IDataStoreProvider pr_default ;
      private long[] P002D2_A14SecParentFunctionalityId ;
      private bool[] P002D2_n14SecParentFunctionalityId ;
      private string[] P002D2_A23SecParentFunctionalityDescript ;
      private string[] P002D2_A20SecFunctionalityDescription ;
      private string[] P002D2_A15SecFunctionalityKey ;
      private short[] P002D2_A21SecFunctionalityType ;
      private long[] P002D2_A13SecFunctionalityId ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector AV45ColumnsSelectorAux ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV41GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV42GridStateFilterValue ;
      private string aP0_Filename ;
      private string aP1_ErrorMessage ;
   }

   public class secfunctionalitywwexport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P002D2( IGxContext context ,
                                             short A21SecFunctionalityType ,
                                             GxSimpleCollection<short> AV57Wwpbaseobjects_secfunctionalitywwds_6_tfsecfunctionalitytype_sels ,
                                             string AV54Wwpbaseobjects_secfunctionalitywwds_3_tfsecfunctionalitykey_sel ,
                                             string AV53Wwpbaseobjects_secfunctionalitywwds_2_tfsecfunctionalitykey ,
                                             string AV56Wwpbaseobjects_secfunctionalitywwds_5_tfsecfunctionalitydescription_sel ,
                                             string AV55Wwpbaseobjects_secfunctionalitywwds_4_tfsecfunctionalitydescription ,
                                             int AV57Wwpbaseobjects_secfunctionalitywwds_6_tfsecfunctionalitytype_sels_Count ,
                                             string AV59Wwpbaseobjects_secfunctionalitywwds_8_tfsecparentfunctionalitydescription_sel ,
                                             string AV58Wwpbaseobjects_secfunctionalitywwds_7_tfsecparentfunctionalitydescription ,
                                             string A15SecFunctionalityKey ,
                                             string A20SecFunctionalityDescription ,
                                             string A23SecParentFunctionalityDescript ,
                                             short AV16OrderedBy ,
                                             bool AV17OrderedDsc ,
                                             string AV52Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int4 = new short[6];
         Object[] GXv_Object5 = new Object[2];
         scmdbuf = "SELECT T1.[SecParentFunctionalityId] AS SecParentFunctionalityId, T2.[SecFunctionalityDescription] AS SecParentFunctionalityDescript, T1.[SecFunctionalityDescription], T1.[SecFunctionalityKey], T1.[SecFunctionalityType], T1.[SecFunctionalityId] FROM ([SecFunctionality] T1 LEFT JOIN [SecFunctionality] T2 ON T2.[SecFunctionalityId] = T1.[SecParentFunctionalityId])";
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV54Wwpbaseobjects_secfunctionalitywwds_3_tfsecfunctionalitykey_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV53Wwpbaseobjects_secfunctionalitywwds_2_tfsecfunctionalitykey)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[SecFunctionalityKey]) like UPPER(@lV53Wwpbaseobjects_secfunctionalitywwds_2_tfsecfunctionalitykey))");
         }
         else
         {
            GXv_int4[0] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV54Wwpbaseobjects_secfunctionalitywwds_3_tfsecfunctionalitykey_sel)) && ! ( StringUtil.StrCmp(AV54Wwpbaseobjects_secfunctionalitywwds_3_tfsecfunctionalitykey_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[SecFunctionalityKey] = @AV54Wwpbaseobjects_secfunctionalitywwds_3_tfsecfunctionalitykey_sel)");
         }
         else
         {
            GXv_int4[1] = 1;
         }
         if ( StringUtil.StrCmp(AV54Wwpbaseobjects_secfunctionalitywwds_3_tfsecfunctionalitykey_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[SecFunctionalityKey] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV56Wwpbaseobjects_secfunctionalitywwds_5_tfsecfunctionalitydescription_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV55Wwpbaseobjects_secfunctionalitywwds_4_tfsecfunctionalitydescription)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[SecFunctionalityDescription]) like UPPER(@lV55Wwpbaseobjects_secfunctionalitywwds_4_tfsecfunctionalitydescription))");
         }
         else
         {
            GXv_int4[2] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV56Wwpbaseobjects_secfunctionalitywwds_5_tfsecfunctionalitydescription_sel)) && ! ( StringUtil.StrCmp(AV56Wwpbaseobjects_secfunctionalitywwds_5_tfsecfunctionalitydescription_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[SecFunctionalityDescription] = @AV56Wwpbaseobjects_secfunctionalitywwds_5_tfsecfunctionalitydescription_sel)");
         }
         else
         {
            GXv_int4[3] = 1;
         }
         if ( StringUtil.StrCmp(AV56Wwpbaseobjects_secfunctionalitywwds_5_tfsecfunctionalitydescription_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[SecFunctionalityDescription] = ''))");
         }
         if ( AV57Wwpbaseobjects_secfunctionalitywwds_6_tfsecfunctionalitytype_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV57Wwpbaseobjects_secfunctionalitywwds_6_tfsecfunctionalitytype_sels, "T1.[SecFunctionalityType] IN (", ")")+")");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV59Wwpbaseobjects_secfunctionalitywwds_8_tfsecparentfunctionalitydescription_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV58Wwpbaseobjects_secfunctionalitywwds_7_tfsecparentfunctionalitydescription)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[SecFunctionalityDescription]) like UPPER(@lV58Wwpbaseobjects_secfunctionalitywwds_7_tfsecparentfunctionalitydescription))");
         }
         else
         {
            GXv_int4[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59Wwpbaseobjects_secfunctionalitywwds_8_tfsecparentfunctionalitydescription_sel)) && ! ( StringUtil.StrCmp(AV59Wwpbaseobjects_secfunctionalitywwds_8_tfsecparentfunctionalitydescription_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.[SecFunctionalityDescription] = @AV59Wwpbaseobjects_secfunctionalitywwds_8_tfsecparentfunctionalitydescription_sel)");
         }
         else
         {
            GXv_int4[5] = 1;
         }
         if ( StringUtil.StrCmp(AV59Wwpbaseobjects_secfunctionalitywwds_8_tfsecparentfunctionalitydescription_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T2.[SecFunctionalityDescription] IS NULL or (T2.[SecFunctionalityDescription] = ''))");
         }
         scmdbuf += sWhereString;
         if ( ( AV16OrderedBy == 1 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[SecFunctionalityDescription]";
         }
         else if ( ( AV16OrderedBy == 1 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[SecFunctionalityDescription] DESC";
         }
         else if ( ( AV16OrderedBy == 2 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[SecFunctionalityKey]";
         }
         else if ( ( AV16OrderedBy == 2 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[SecFunctionalityKey] DESC";
         }
         else if ( ( AV16OrderedBy == 3 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[SecFunctionalityType]";
         }
         else if ( ( AV16OrderedBy == 3 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[SecFunctionalityType] DESC";
         }
         else if ( ( AV16OrderedBy == 4 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY T2.[SecFunctionalityDescription]";
         }
         else if ( ( AV16OrderedBy == 4 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T2.[SecFunctionalityDescription] DESC";
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
                     return conditional_P002D2(context, (short)dynConstraints[0] , (GxSimpleCollection<short>)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (int)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (short)dynConstraints[12] , (bool)dynConstraints[13] , (string)dynConstraints[14] );
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
          Object[] prmP002D2;
          prmP002D2 = new Object[] {
          new ParDef("@lV53Wwpbaseobjects_secfunctionalitywwds_2_tfsecfunctionalitykey",GXType.VarChar,100,0) ,
          new ParDef("@AV54Wwpbaseobjects_secfunctionalitywwds_3_tfsecfunctionalitykey_sel",GXType.NVarChar,100,0) ,
          new ParDef("@lV55Wwpbaseobjects_secfunctionalitywwds_4_tfsecfunctionalitydescription",GXType.VarChar,100,0) ,
          new ParDef("@AV56Wwpbaseobjects_secfunctionalitywwds_5_tfsecfunctionalitydescription_sel",GXType.NVarChar,100,0) ,
          new ParDef("@lV58Wwpbaseobjects_secfunctionalitywwds_7_tfsecparentfunctionalitydescription",GXType.VarChar,100,0) ,
          new ParDef("@AV59Wwpbaseobjects_secfunctionalitywwds_8_tfsecparentfunctionalitydescription_sel",GXType.NVarChar,100,0)
          };
          def= new CursorDef[] {
              new CursorDef("P002D2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP002D2,100, GxCacheFrequency.OFF ,true,false )
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
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getVarchar(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((string[]) buf[4])[0] = rslt.getVarchar(4);
                ((short[]) buf[5])[0] = rslt.getShort(5);
                ((long[]) buf[6])[0] = rslt.getLong(6);
                return;
       }
    }

 }

}

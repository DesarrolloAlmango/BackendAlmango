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
   public class secfunctionalityfilterparentwwexport : GXProcedure
   {
      public secfunctionalityfilterparentwwexport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public secfunctionalityfilterparentwwexport( IGxContext context )
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
            GXEncryptionTmp = "wwpbaseobjects.notauthorized.aspx"+GXUtil.UrlEncode(StringUtil.RTrim(AV49Pgmname));
            CallWebObject(formatLink("wwpbaseobjects.notauthorized.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
            context.wjLocDisableFrm = 1;
         }
         if ( AV8IsAuthorized )
         {
            new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV40WWPContext) ;
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
         AV11Filename = GXt_char2 + "SecFunctionalityFilterParentWWExport-" + StringUtil.Trim( StringUtil.Str( (decimal)(AV15Random), 8, 0)) + ".xlsx";
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
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV48FilterFullText)) ) )
         {
            GXt_int3 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int3,  (short)(AV14FirstColumn),  context.GetMessage( "WWP_FullTextFilterDescription", "")) ;
            AV13CellRow = GXt_int3;
            GXt_char2 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV48FilterFullText, out  GXt_char2) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char2;
         }
         if ( ! ( (0==AV19SecFunctionalityType) ) )
         {
            GXt_int3 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int3,  (short)(AV14FirstColumn),  context.GetMessage( "Type", "")) ;
            AV13CellRow = GXt_int3;
            if ( ! (0==AV19SecFunctionalityType) )
            {
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = context.GetMessage( gxdomainwwpsecfunctionalitytypes.getDescription(context,AV19SecFunctionalityType), "");
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV21SecFunctionalityDescription)) ) )
         {
            GXt_int3 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int3,  (short)(AV14FirstColumn),  "") ;
            AV13CellRow = GXt_int3;
            if ( AV20SecFunctionalityDescriptionOperator == 0 )
            {
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+0, 1, 1).Text = StringUtil.Format( "%1 (%2)", context.GetMessage( "Description", ""), context.GetMessage( "WWP_FilterLike", ""), "", "", "", "", "", "", "");
            }
            else if ( AV20SecFunctionalityDescriptionOperator == 1 )
            {
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+0, 1, 1).Text = StringUtil.Format( "%1 (%2)", context.GetMessage( "Description", ""), context.GetMessage( "WWP_FilterContains", ""), "", "", "", "", "", "", "");
            }
            GXt_char2 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV21SecFunctionalityDescription, out  GXt_char2) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char2;
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV23TFSecFunctionalityKey_Sel)) ) )
         {
            GXt_int3 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int3,  (short)(AV14FirstColumn),  context.GetMessage( "Key", "")) ;
            AV13CellRow = GXt_int3;
            GXt_char2 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV23TFSecFunctionalityKey_Sel)) ? context.GetMessage( "WWP_TitleFilter_EmptyOption", "") : AV23TFSecFunctionalityKey_Sel), out  GXt_char2) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char2;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV22TFSecFunctionalityKey)) ) )
            {
               GXt_int3 = (short)(AV13CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int3,  (short)(AV14FirstColumn),  context.GetMessage( "Key", "")) ;
               AV13CellRow = GXt_int3;
               GXt_char2 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV22TFSecFunctionalityKey, out  GXt_char2) ;
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char2;
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV25TFSecFunctionalityDescription_Sel)) ) )
         {
            GXt_int3 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int3,  (short)(AV14FirstColumn),  context.GetMessage( "Description", "")) ;
            AV13CellRow = GXt_int3;
            GXt_char2 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV25TFSecFunctionalityDescription_Sel)) ? context.GetMessage( "WWP_TitleFilter_EmptyOption", "") : AV25TFSecFunctionalityDescription_Sel), out  GXt_char2) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char2;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV24TFSecFunctionalityDescription)) ) )
            {
               GXt_int3 = (short)(AV13CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int3,  (short)(AV14FirstColumn),  context.GetMessage( "Description", "")) ;
               AV13CellRow = GXt_int3;
               GXt_char2 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV24TFSecFunctionalityDescription, out  GXt_char2) ;
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char2;
            }
         }
         if ( ! ( ( AV45TFSecFunctionalityType_Sels.Count == 0 ) ) )
         {
            GXt_int3 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int3,  (short)(AV14FirstColumn),  context.GetMessage( "Type", "")) ;
            AV13CellRow = GXt_int3;
            AV36i = 1;
            AV50GXV1 = 1;
            while ( AV50GXV1 <= AV45TFSecFunctionalityType_Sels.Count )
            {
               AV26TFSecFunctionalityType_Sel = (short)(AV45TFSecFunctionalityType_Sels.GetNumeric(AV50GXV1));
               if ( AV36i == 1 )
               {
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "";
               }
               else
               {
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text+", ";
               }
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text+context.GetMessage( gxdomainwwpsecfunctionalitytypes.getDescription(context,AV26TFSecFunctionalityType_Sel), "");
               AV36i = (long)(AV36i+1);
               AV50GXV1 = (int)(AV50GXV1+1);
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV28TFSecParentFunctionalityDescription_Sel)) ) )
         {
            GXt_int3 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int3,  (short)(AV14FirstColumn),  context.GetMessage( "Parent Functionality", "")) ;
            AV13CellRow = GXt_int3;
            GXt_char2 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV28TFSecParentFunctionalityDescription_Sel)) ? context.GetMessage( "WWP_TitleFilter_EmptyOption", "") : AV28TFSecParentFunctionalityDescription_Sel), out  GXt_char2) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char2;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV27TFSecParentFunctionalityDescription)) ) )
            {
               GXt_int3 = (short)(AV13CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int3,  (short)(AV14FirstColumn),  context.GetMessage( "Parent Functionality", "")) ;
               AV13CellRow = GXt_int3;
               GXt_char2 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV27TFSecParentFunctionalityDescription, out  GXt_char2) ;
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char2;
            }
         }
         AV13CellRow = (int)(AV13CellRow+2);
      }

      protected void S141( )
      {
         /* 'WRITECOLUMNTITLES' Routine */
         returnInSub = false;
         AV37VisibleColumnCount = 0;
         if ( StringUtil.StrCmp(AV31Session.Get("WWPBaseObjects.SecFunctionalityFilterParentWWColumnsSelector"), "") != 0 )
         {
            AV30ColumnsSelectorXML = AV31Session.Get("WWPBaseObjects.SecFunctionalityFilterParentWWColumnsSelector");
            AV29ColumnsSelector.FromXml(AV30ColumnsSelectorXML, null, "", "");
         }
         else
         {
            /* Execute user subroutine: 'INITIALIZECOLUMNSSELECTOR' */
            S151 ();
            if (returnInSub) return;
         }
         AV29ColumnsSelector.gxTpr_Columns.Sort("Order");
         AV51GXV2 = 1;
         while ( AV51GXV2 <= AV29ColumnsSelector.gxTpr_Columns.Count )
         {
            AV47ColumnsSelector_Column = ((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV29ColumnsSelector.gxTpr_Columns.Item(AV51GXV2));
            if ( AV47ColumnsSelector_Column.gxTpr_Isvisible )
            {
               AV10ExcelDocument.get_Cells(AV13CellRow, (int)(AV14FirstColumn+AV37VisibleColumnCount), 1, 1).Text = context.GetMessage( (String.IsNullOrEmpty(StringUtil.RTrim( AV47ColumnsSelector_Column.gxTpr_Displayname)) ? AV47ColumnsSelector_Column.gxTpr_Columnname : AV47ColumnsSelector_Column.gxTpr_Displayname), "");
               AV10ExcelDocument.get_Cells(AV13CellRow, (int)(AV14FirstColumn+AV37VisibleColumnCount), 1, 1).Bold = 1;
               AV10ExcelDocument.get_Cells(AV13CellRow, (int)(AV14FirstColumn+AV37VisibleColumnCount), 1, 1).Color = 11;
               AV37VisibleColumnCount = (long)(AV37VisibleColumnCount+1);
            }
            AV51GXV2 = (int)(AV51GXV2+1);
         }
      }

      protected void S161( )
      {
         /* 'WRITEDATA' Routine */
         returnInSub = false;
         AV53Wwpbaseobjects_secfunctionalityfilterparentwwds_1_secparentfunctionalityid = AV16SecParentFunctionalityId;
         AV54Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterfulltext = AV48FilterFullText;
         AV55Wwpbaseobjects_secfunctionalityfilterparentwwds_3_secfunctionalitytype = AV19SecFunctionalityType;
         AV56Wwpbaseobjects_secfunctionalityfilterparentwwds_4_secfunctionalitydescription = AV21SecFunctionalityDescription;
         AV57Wwpbaseobjects_secfunctionalityfilterparentwwds_5_tfsecfunctionalitykey = AV22TFSecFunctionalityKey;
         AV58Wwpbaseobjects_secfunctionalityfilterparentwwds_6_tfsecfunctionalitykey_sel = AV23TFSecFunctionalityKey_Sel;
         AV59Wwpbaseobjects_secfunctionalityfilterparentwwds_7_tfsecfunctionalitydescription = AV24TFSecFunctionalityDescription;
         AV60Wwpbaseobjects_secfunctionalityfilterparentwwds_8_tfsecfunctionalitydescription_sel = AV25TFSecFunctionalityDescription_Sel;
         AV61Wwpbaseobjects_secfunctionalityfilterparentwwds_9_tfsecfunctionalitytype_sels = AV45TFSecFunctionalityType_Sels;
         AV62Wwpbaseobjects_secfunctionalityfilterparentwwds_10_tfsecparentfunctionalitydescription = AV27TFSecParentFunctionalityDescription;
         AV63Wwpbaseobjects_secfunctionalityfilterparentwwds_11_tfsecparentfunctionalitydescription_sel = AV28TFSecParentFunctionalityDescription_Sel;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A21SecFunctionalityType ,
                                              AV61Wwpbaseobjects_secfunctionalityfilterparentwwds_9_tfsecfunctionalitytype_sels ,
                                              AV55Wwpbaseobjects_secfunctionalityfilterparentwwds_3_secfunctionalitytype ,
                                              AV20SecFunctionalityDescriptionOperator ,
                                              AV56Wwpbaseobjects_secfunctionalityfilterparentwwds_4_secfunctionalitydescription ,
                                              AV58Wwpbaseobjects_secfunctionalityfilterparentwwds_6_tfsecfunctionalitykey_sel ,
                                              AV57Wwpbaseobjects_secfunctionalityfilterparentwwds_5_tfsecfunctionalitykey ,
                                              AV60Wwpbaseobjects_secfunctionalityfilterparentwwds_8_tfsecfunctionalitydescription_sel ,
                                              AV59Wwpbaseobjects_secfunctionalityfilterparentwwds_7_tfsecfunctionalitydescription ,
                                              AV61Wwpbaseobjects_secfunctionalityfilterparentwwds_9_tfsecfunctionalitytype_sels.Count ,
                                              AV63Wwpbaseobjects_secfunctionalityfilterparentwwds_11_tfsecparentfunctionalitydescription_sel ,
                                              AV62Wwpbaseobjects_secfunctionalityfilterparentwwds_10_tfsecparentfunctionalitydescription ,
                                              A20SecFunctionalityDescription ,
                                              A15SecFunctionalityKey ,
                                              A23SecParentFunctionalityDescript ,
                                              AV17OrderedBy ,
                                              AV18OrderedDsc ,
                                              AV54Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterfulltext ,
                                              AV53Wwpbaseobjects_secfunctionalityfilterparentwwds_1_secparentfunctionalityid ,
                                              A14SecParentFunctionalityId } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.BOOLEAN
                                              }
         });
         lV56Wwpbaseobjects_secfunctionalityfilterparentwwds_4_secfunctionalitydescription = StringUtil.Concat( StringUtil.RTrim( AV56Wwpbaseobjects_secfunctionalityfilterparentwwds_4_secfunctionalitydescription), "%", "");
         lV56Wwpbaseobjects_secfunctionalityfilterparentwwds_4_secfunctionalitydescription = StringUtil.Concat( StringUtil.RTrim( AV56Wwpbaseobjects_secfunctionalityfilterparentwwds_4_secfunctionalitydescription), "%", "");
         lV57Wwpbaseobjects_secfunctionalityfilterparentwwds_5_tfsecfunctionalitykey = StringUtil.Concat( StringUtil.RTrim( AV57Wwpbaseobjects_secfunctionalityfilterparentwwds_5_tfsecfunctionalitykey), "%", "");
         lV59Wwpbaseobjects_secfunctionalityfilterparentwwds_7_tfsecfunctionalitydescription = StringUtil.Concat( StringUtil.RTrim( AV59Wwpbaseobjects_secfunctionalityfilterparentwwds_7_tfsecfunctionalitydescription), "%", "");
         lV62Wwpbaseobjects_secfunctionalityfilterparentwwds_10_tfsecparentfunctionalitydescription = StringUtil.Concat( StringUtil.RTrim( AV62Wwpbaseobjects_secfunctionalityfilterparentwwds_10_tfsecparentfunctionalitydescription), "%", "");
         /* Using cursor P00282 */
         pr_default.execute(0, new Object[] {AV53Wwpbaseobjects_secfunctionalityfilterparentwwds_1_secparentfunctionalityid, AV55Wwpbaseobjects_secfunctionalityfilterparentwwds_3_secfunctionalitytype, lV56Wwpbaseobjects_secfunctionalityfilterparentwwds_4_secfunctionalitydescription, lV56Wwpbaseobjects_secfunctionalityfilterparentwwds_4_secfunctionalitydescription, lV57Wwpbaseobjects_secfunctionalityfilterparentwwds_5_tfsecfunctionalitykey, AV58Wwpbaseobjects_secfunctionalityfilterparentwwds_6_tfsecfunctionalitykey_sel, lV59Wwpbaseobjects_secfunctionalityfilterparentwwds_7_tfsecfunctionalitydescription, AV60Wwpbaseobjects_secfunctionalityfilterparentwwds_8_tfsecfunctionalitydescription_sel, lV62Wwpbaseobjects_secfunctionalityfilterparentwwds_10_tfsecparentfunctionalitydescription, AV63Wwpbaseobjects_secfunctionalityfilterparentwwds_11_tfsecparentfunctionalitydescription_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A23SecParentFunctionalityDescript = P00282_A23SecParentFunctionalityDescript[0];
            A20SecFunctionalityDescription = P00282_A20SecFunctionalityDescription[0];
            A15SecFunctionalityKey = P00282_A15SecFunctionalityKey[0];
            A21SecFunctionalityType = P00282_A21SecFunctionalityType[0];
            A14SecParentFunctionalityId = P00282_A14SecParentFunctionalityId[0];
            n14SecParentFunctionalityId = P00282_n14SecParentFunctionalityId[0];
            A13SecFunctionalityId = P00282_A13SecFunctionalityId[0];
            A23SecParentFunctionalityDescript = P00282_A23SecParentFunctionalityDescript[0];
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV54Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterfulltext)) || ( ( StringUtil.Like( StringUtil.Upper( A15SecFunctionalityKey) , StringUtil.PadR( "%" + StringUtil.Upper( AV54Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A20SecFunctionalityDescription) , StringUtil.PadR( "%" + StringUtil.Upper( AV54Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( context.GetMessage( "mode", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV54Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterfulltext) , 255 , "%"),  ' ' ) && ( A21SecFunctionalityType == 1 ) ) || ( StringUtil.Like( context.GetMessage( "action", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV54Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterfulltext) , 255 , "%"),  ' ' ) && ( A21SecFunctionalityType == 2 ) ) || ( StringUtil.Like( context.GetMessage( "tab", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV54Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterfulltext) , 255 , "%"),  ' ' ) && ( A21SecFunctionalityType == 3 ) ) || ( StringUtil.Like( context.GetMessage( "object", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV54Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterfulltext) , 255 , "%"),  ' ' ) && ( A21SecFunctionalityType == 4 ) ) || ( StringUtil.Like( context.GetMessage( "attribute", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV54Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterfulltext) , 255 , "%"),  ' ' ) && ( A21SecFunctionalityType == 5 ) ) || ( StringUtil.Like( StringUtil.Upper( A23SecParentFunctionalityDescript) , StringUtil.PadR( "%" + StringUtil.Upper( AV54Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterfulltext) , 255 , "%"),  ' ' ) ) ) )
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
               AV37VisibleColumnCount = 0;
               AV64GXV3 = 1;
               while ( AV64GXV3 <= AV29ColumnsSelector.gxTpr_Columns.Count )
               {
                  AV47ColumnsSelector_Column = ((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV29ColumnsSelector.gxTpr_Columns.Item(AV64GXV3));
                  if ( AV47ColumnsSelector_Column.gxTpr_Isvisible )
                  {
                     if ( StringUtil.StrCmp(AV47ColumnsSelector_Column.gxTpr_Columnname, "SecFunctionalityKey") == 0 )
                     {
                        GXt_char2 = "";
                        new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A15SecFunctionalityKey, out  GXt_char2) ;
                        AV10ExcelDocument.get_Cells(AV13CellRow, (int)(AV14FirstColumn+AV37VisibleColumnCount), 1, 1).Text = GXt_char2;
                     }
                     else if ( StringUtil.StrCmp(AV47ColumnsSelector_Column.gxTpr_Columnname, "SecFunctionalityDescription") == 0 )
                     {
                        GXt_char2 = "";
                        new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A20SecFunctionalityDescription, out  GXt_char2) ;
                        AV10ExcelDocument.get_Cells(AV13CellRow, (int)(AV14FirstColumn+AV37VisibleColumnCount), 1, 1).Text = GXt_char2;
                     }
                     else if ( StringUtil.StrCmp(AV47ColumnsSelector_Column.gxTpr_Columnname, "SecFunctionalityType") == 0 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, (int)(AV14FirstColumn+AV37VisibleColumnCount), 1, 1).Text = context.GetMessage( gxdomainwwpsecfunctionalitytypes.getDescription(context,A21SecFunctionalityType), "");
                     }
                     else if ( StringUtil.StrCmp(AV47ColumnsSelector_Column.gxTpr_Columnname, "SecParentFunctionalityDescription") == 0 )
                     {
                        GXt_char2 = "";
                        new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A23SecParentFunctionalityDescript, out  GXt_char2) ;
                        AV10ExcelDocument.get_Cells(AV13CellRow, (int)(AV14FirstColumn+AV37VisibleColumnCount), 1, 1).Text = GXt_char2;
                     }
                     AV37VisibleColumnCount = (long)(AV37VisibleColumnCount+1);
                  }
                  AV64GXV3 = (int)(AV64GXV3+1);
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
         AV31Session.Set("WWPExportFilePath", AV11Filename);
         AV31Session.Set("WWPExportFileName", "SecFunctionalityFilterParentWWExport.xlsx");
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
         AV29ColumnsSelector = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector(context);
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV29ColumnsSelector,  "SecFunctionalityKey",  "",  "Key",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV29ColumnsSelector,  "SecFunctionalityDescription",  "",  "Description",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV29ColumnsSelector,  "SecFunctionalityType",  "",  "Type",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV29ColumnsSelector,  "SecParentFunctionalityDescription",  "",  "Parent Functionality",  true,  "") ;
         GXt_char2 = AV32UserCustomValue;
         new GeneXus.Programs.wwpbaseobjects.loadcolumnsselectorstate(context ).execute(  "WWPBaseObjects.SecFunctionalityFilterParentWWColumnsSelector", out  GXt_char2) ;
         AV32UserCustomValue = GXt_char2;
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV32UserCustomValue)) ) )
         {
            AV46ColumnsSelectorAux.FromXml(AV32UserCustomValue, null, "", "");
            new GeneXus.Programs.wwpbaseobjects.wwp_columnselector_updatecolumns(context ).execute( ref  AV46ColumnsSelectorAux, ref  AV29ColumnsSelector) ;
         }
      }

      protected void S201( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV31Session.Get("WWPBaseObjects.SecFunctionalityFilterParentWWGridState"), "") == 0 )
         {
            AV42GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "WWPBaseObjects.SecFunctionalityFilterParentWWGridState"), null, "", "");
         }
         else
         {
            AV42GridState.FromXml(AV31Session.Get("WWPBaseObjects.SecFunctionalityFilterParentWWGridState"), null, "", "");
         }
         AV17OrderedBy = AV42GridState.gxTpr_Orderedby;
         AV18OrderedDsc = AV42GridState.gxTpr_Ordereddsc;
         AV65GXV4 = 1;
         while ( AV65GXV4 <= AV42GridState.gxTpr_Filtervalues.Count )
         {
            AV43GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV42GridState.gxTpr_Filtervalues.Item(AV65GXV4));
            if ( StringUtil.StrCmp(AV43GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV48FilterFullText = AV43GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV43GridStateFilterValue.gxTpr_Name, "SECFUNCTIONALITYTYPE") == 0 )
            {
               AV19SecFunctionalityType = (short)(Math.Round(NumberUtil.Val( AV43GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV43GridStateFilterValue.gxTpr_Name, "SECFUNCTIONALITYDESCRIPTION") == 0 )
            {
               AV21SecFunctionalityDescription = AV43GridStateFilterValue.gxTpr_Value;
               AV20SecFunctionalityDescriptionOperator = AV43GridStateFilterValue.gxTpr_Operator;
            }
            else if ( StringUtil.StrCmp(AV43GridStateFilterValue.gxTpr_Name, "TFSECFUNCTIONALITYKEY") == 0 )
            {
               AV22TFSecFunctionalityKey = AV43GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV43GridStateFilterValue.gxTpr_Name, "TFSECFUNCTIONALITYKEY_SEL") == 0 )
            {
               AV23TFSecFunctionalityKey_Sel = AV43GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV43GridStateFilterValue.gxTpr_Name, "TFSECFUNCTIONALITYDESCRIPTION") == 0 )
            {
               AV24TFSecFunctionalityDescription = AV43GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV43GridStateFilterValue.gxTpr_Name, "TFSECFUNCTIONALITYDESCRIPTION_SEL") == 0 )
            {
               AV25TFSecFunctionalityDescription_Sel = AV43GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV43GridStateFilterValue.gxTpr_Name, "TFSECFUNCTIONALITYTYPE_SEL") == 0 )
            {
               AV44TFSecFunctionalityType_SelsJson = AV43GridStateFilterValue.gxTpr_Value;
               AV45TFSecFunctionalityType_Sels.FromJSonString(AV44TFSecFunctionalityType_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV43GridStateFilterValue.gxTpr_Name, "TFSECPARENTFUNCTIONALITYDESCRIPTION") == 0 )
            {
               AV27TFSecParentFunctionalityDescription = AV43GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV43GridStateFilterValue.gxTpr_Name, "TFSECPARENTFUNCTIONALITYDESCRIPTION_SEL") == 0 )
            {
               AV28TFSecParentFunctionalityDescription_Sel = AV43GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV43GridStateFilterValue.gxTpr_Name, "PARM_&SECPARENTFUNCTIONALITYID") == 0 )
            {
               AV16SecParentFunctionalityId = (long)(Math.Round(NumberUtil.Val( AV43GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
            }
            AV65GXV4 = (int)(AV65GXV4+1);
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
         AV49Pgmname = "";
         GXKey = "";
         GXEncryptionTmp = "";
         AV40WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV10ExcelDocument = new ExcelDocumentI();
         AV48FilterFullText = "";
         AV21SecFunctionalityDescription = "";
         AV23TFSecFunctionalityKey_Sel = "";
         AV22TFSecFunctionalityKey = "";
         AV25TFSecFunctionalityDescription_Sel = "";
         AV24TFSecFunctionalityDescription = "";
         AV45TFSecFunctionalityType_Sels = new GxSimpleCollection<short>();
         AV28TFSecParentFunctionalityDescription_Sel = "";
         AV27TFSecParentFunctionalityDescription = "";
         AV31Session = context.GetSession();
         AV30ColumnsSelectorXML = "";
         AV29ColumnsSelector = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector(context);
         AV47ColumnsSelector_Column = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column(context);
         AV54Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterfulltext = "";
         AV56Wwpbaseobjects_secfunctionalityfilterparentwwds_4_secfunctionalitydescription = "";
         AV57Wwpbaseobjects_secfunctionalityfilterparentwwds_5_tfsecfunctionalitykey = "";
         AV58Wwpbaseobjects_secfunctionalityfilterparentwwds_6_tfsecfunctionalitykey_sel = "";
         AV59Wwpbaseobjects_secfunctionalityfilterparentwwds_7_tfsecfunctionalitydescription = "";
         AV60Wwpbaseobjects_secfunctionalityfilterparentwwds_8_tfsecfunctionalitydescription_sel = "";
         AV61Wwpbaseobjects_secfunctionalityfilterparentwwds_9_tfsecfunctionalitytype_sels = new GxSimpleCollection<short>();
         AV62Wwpbaseobjects_secfunctionalityfilterparentwwds_10_tfsecparentfunctionalitydescription = "";
         AV63Wwpbaseobjects_secfunctionalityfilterparentwwds_11_tfsecparentfunctionalitydescription_sel = "";
         lV54Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterfulltext = "";
         lV56Wwpbaseobjects_secfunctionalityfilterparentwwds_4_secfunctionalitydescription = "";
         lV57Wwpbaseobjects_secfunctionalityfilterparentwwds_5_tfsecfunctionalitykey = "";
         lV59Wwpbaseobjects_secfunctionalityfilterparentwwds_7_tfsecfunctionalitydescription = "";
         lV62Wwpbaseobjects_secfunctionalityfilterparentwwds_10_tfsecparentfunctionalitydescription = "";
         A20SecFunctionalityDescription = "";
         A15SecFunctionalityKey = "";
         A23SecParentFunctionalityDescript = "";
         P00282_A23SecParentFunctionalityDescript = new string[] {""} ;
         P00282_A20SecFunctionalityDescription = new string[] {""} ;
         P00282_A15SecFunctionalityKey = new string[] {""} ;
         P00282_A21SecFunctionalityType = new short[1] ;
         P00282_A14SecParentFunctionalityId = new long[1] ;
         P00282_n14SecParentFunctionalityId = new bool[] {false} ;
         P00282_A13SecFunctionalityId = new long[1] ;
         AV32UserCustomValue = "";
         GXt_char2 = "";
         AV46ColumnsSelectorAux = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector(context);
         AV42GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV43GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV44TFSecFunctionalityType_SelsJson = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.secfunctionalityfilterparentwwexport__default(),
            new Object[][] {
                new Object[] {
               P00282_A23SecParentFunctionalityDescript, P00282_A20SecFunctionalityDescription, P00282_A15SecFunctionalityKey, P00282_A21SecFunctionalityType, P00282_A14SecParentFunctionalityId, P00282_n14SecParentFunctionalityId, P00282_A13SecFunctionalityId
               }
            }
         );
         AV49Pgmname = "WWPBaseObjects.SecFunctionalityFilterParentWWExport";
         /* GeneXus formulas. */
         AV49Pgmname = "WWPBaseObjects.SecFunctionalityFilterParentWWExport";
      }

      private short AV19SecFunctionalityType ;
      private short AV20SecFunctionalityDescriptionOperator ;
      private short AV26TFSecFunctionalityType_Sel ;
      private short GXt_int3 ;
      private short AV55Wwpbaseobjects_secfunctionalityfilterparentwwds_3_secfunctionalitytype ;
      private short A21SecFunctionalityType ;
      private short AV17OrderedBy ;
      private int AV13CellRow ;
      private int AV14FirstColumn ;
      private int AV15Random ;
      private int AV50GXV1 ;
      private int AV51GXV2 ;
      private int AV61Wwpbaseobjects_secfunctionalityfilterparentwwds_9_tfsecfunctionalitytype_sels_Count ;
      private int AV64GXV3 ;
      private int AV65GXV4 ;
      private long AV36i ;
      private long AV37VisibleColumnCount ;
      private long AV53Wwpbaseobjects_secfunctionalityfilterparentwwds_1_secparentfunctionalityid ;
      private long AV16SecParentFunctionalityId ;
      private long A14SecParentFunctionalityId ;
      private long A13SecFunctionalityId ;
      private string AV49Pgmname ;
      private string GXKey ;
      private string GXEncryptionTmp ;
      private string GXt_char2 ;
      private bool AV8IsAuthorized ;
      private bool GXt_boolean1 ;
      private bool returnInSub ;
      private bool AV18OrderedDsc ;
      private bool n14SecParentFunctionalityId ;
      private string AV30ColumnsSelectorXML ;
      private string AV32UserCustomValue ;
      private string AV44TFSecFunctionalityType_SelsJson ;
      private string AV11Filename ;
      private string AV12ErrorMessage ;
      private string AV48FilterFullText ;
      private string AV21SecFunctionalityDescription ;
      private string AV23TFSecFunctionalityKey_Sel ;
      private string AV22TFSecFunctionalityKey ;
      private string AV25TFSecFunctionalityDescription_Sel ;
      private string AV24TFSecFunctionalityDescription ;
      private string AV28TFSecParentFunctionalityDescription_Sel ;
      private string AV27TFSecParentFunctionalityDescription ;
      private string AV54Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterfulltext ;
      private string AV56Wwpbaseobjects_secfunctionalityfilterparentwwds_4_secfunctionalitydescription ;
      private string AV57Wwpbaseobjects_secfunctionalityfilterparentwwds_5_tfsecfunctionalitykey ;
      private string AV58Wwpbaseobjects_secfunctionalityfilterparentwwds_6_tfsecfunctionalitykey_sel ;
      private string AV59Wwpbaseobjects_secfunctionalityfilterparentwwds_7_tfsecfunctionalitydescription ;
      private string AV60Wwpbaseobjects_secfunctionalityfilterparentwwds_8_tfsecfunctionalitydescription_sel ;
      private string AV62Wwpbaseobjects_secfunctionalityfilterparentwwds_10_tfsecparentfunctionalitydescription ;
      private string AV63Wwpbaseobjects_secfunctionalityfilterparentwwds_11_tfsecparentfunctionalitydescription_sel ;
      private string lV54Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterfulltext ;
      private string lV56Wwpbaseobjects_secfunctionalityfilterparentwwds_4_secfunctionalitydescription ;
      private string lV57Wwpbaseobjects_secfunctionalityfilterparentwwds_5_tfsecfunctionalitykey ;
      private string lV59Wwpbaseobjects_secfunctionalityfilterparentwwds_7_tfsecfunctionalitydescription ;
      private string lV62Wwpbaseobjects_secfunctionalityfilterparentwwds_10_tfsecparentfunctionalitydescription ;
      private string A20SecFunctionalityDescription ;
      private string A15SecFunctionalityKey ;
      private string A23SecParentFunctionalityDescript ;
      private IGxSession AV31Session ;
      private ExcelDocumentI AV10ExcelDocument ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV40WWPContext ;
      private GxSimpleCollection<short> AV45TFSecFunctionalityType_Sels ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector AV29ColumnsSelector ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column AV47ColumnsSelector_Column ;
      private GxSimpleCollection<short> AV61Wwpbaseobjects_secfunctionalityfilterparentwwds_9_tfsecfunctionalitytype_sels ;
      private IDataStoreProvider pr_default ;
      private string[] P00282_A23SecParentFunctionalityDescript ;
      private string[] P00282_A20SecFunctionalityDescription ;
      private string[] P00282_A15SecFunctionalityKey ;
      private short[] P00282_A21SecFunctionalityType ;
      private long[] P00282_A14SecParentFunctionalityId ;
      private bool[] P00282_n14SecParentFunctionalityId ;
      private long[] P00282_A13SecFunctionalityId ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector AV46ColumnsSelectorAux ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV42GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV43GridStateFilterValue ;
      private string aP0_Filename ;
      private string aP1_ErrorMessage ;
   }

   public class secfunctionalityfilterparentwwexport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00282( IGxContext context ,
                                             short A21SecFunctionalityType ,
                                             GxSimpleCollection<short> AV61Wwpbaseobjects_secfunctionalityfilterparentwwds_9_tfsecfunctionalitytype_sels ,
                                             short AV55Wwpbaseobjects_secfunctionalityfilterparentwwds_3_secfunctionalitytype ,
                                             short AV20SecFunctionalityDescriptionOperator ,
                                             string AV56Wwpbaseobjects_secfunctionalityfilterparentwwds_4_secfunctionalitydescription ,
                                             string AV58Wwpbaseobjects_secfunctionalityfilterparentwwds_6_tfsecfunctionalitykey_sel ,
                                             string AV57Wwpbaseobjects_secfunctionalityfilterparentwwds_5_tfsecfunctionalitykey ,
                                             string AV60Wwpbaseobjects_secfunctionalityfilterparentwwds_8_tfsecfunctionalitydescription_sel ,
                                             string AV59Wwpbaseobjects_secfunctionalityfilterparentwwds_7_tfsecfunctionalitydescription ,
                                             int AV61Wwpbaseobjects_secfunctionalityfilterparentwwds_9_tfsecfunctionalitytype_sels_Count ,
                                             string AV63Wwpbaseobjects_secfunctionalityfilterparentwwds_11_tfsecparentfunctionalitydescription_sel ,
                                             string AV62Wwpbaseobjects_secfunctionalityfilterparentwwds_10_tfsecparentfunctionalitydescription ,
                                             string A20SecFunctionalityDescription ,
                                             string A15SecFunctionalityKey ,
                                             string A23SecParentFunctionalityDescript ,
                                             short AV17OrderedBy ,
                                             bool AV18OrderedDsc ,
                                             string AV54Wwpbaseobjects_secfunctionalityfilterparentwwds_2_filterfulltext ,
                                             long AV53Wwpbaseobjects_secfunctionalityfilterparentwwds_1_secparentfunctionalityid ,
                                             long A14SecParentFunctionalityId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int4 = new short[10];
         Object[] GXv_Object5 = new Object[2];
         scmdbuf = "SELECT T2.[SecFunctionalityDescription] AS SecParentFunctionalityDescript, T1.[SecFunctionalityDescription], T1.[SecFunctionalityKey], T1.[SecFunctionalityType], T1.[SecParentFunctionalityId] AS SecParentFunctionalityId, T1.[SecFunctionalityId] FROM ([SecFunctionality] T1 LEFT JOIN [SecFunctionality] T2 ON T2.[SecFunctionalityId] = T1.[SecParentFunctionalityId])";
         AddWhere(sWhereString, "(T1.[SecParentFunctionalityId] = @AV53Wwpbaseobjects_secfunctionalityfilterparentwwds_1_secparentfunctionalityid)");
         if ( ! (0==AV55Wwpbaseobjects_secfunctionalityfilterparentwwds_3_secfunctionalitytype) )
         {
            AddWhere(sWhereString, "(T1.[SecFunctionalityType] = @AV55Wwpbaseobjects_secfunctionalityfilterparentwwds_3_secfunctionalitytype)");
         }
         else
         {
            GXv_int4[1] = 1;
         }
         if ( ( AV20SecFunctionalityDescriptionOperator == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV56Wwpbaseobjects_secfunctionalityfilterparentwwds_4_secfunctionalitydescription)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[SecFunctionalityDescription]) like UPPER(@lV56Wwpbaseobjects_secfunctionalityfilterparentwwds_4_secfunctionalitydescription))");
         }
         else
         {
            GXv_int4[2] = 1;
         }
         if ( ( AV20SecFunctionalityDescriptionOperator == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV56Wwpbaseobjects_secfunctionalityfilterparentwwds_4_secfunctionalitydescription)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[SecFunctionalityDescription]) like '%' + UPPER(@lV56Wwpbaseobjects_secfunctionalityfilterparentwwds_4_secfunctionalitydescription))");
         }
         else
         {
            GXv_int4[3] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV58Wwpbaseobjects_secfunctionalityfilterparentwwds_6_tfsecfunctionalitykey_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57Wwpbaseobjects_secfunctionalityfilterparentwwds_5_tfsecfunctionalitykey)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[SecFunctionalityKey]) like UPPER(@lV57Wwpbaseobjects_secfunctionalityfilterparentwwds_5_tfsecfunctionalitykey))");
         }
         else
         {
            GXv_int4[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV58Wwpbaseobjects_secfunctionalityfilterparentwwds_6_tfsecfunctionalitykey_sel)) && ! ( StringUtil.StrCmp(AV58Wwpbaseobjects_secfunctionalityfilterparentwwds_6_tfsecfunctionalitykey_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[SecFunctionalityKey] = @AV58Wwpbaseobjects_secfunctionalityfilterparentwwds_6_tfsecfunctionalitykey_sel)");
         }
         else
         {
            GXv_int4[5] = 1;
         }
         if ( StringUtil.StrCmp(AV58Wwpbaseobjects_secfunctionalityfilterparentwwds_6_tfsecfunctionalitykey_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[SecFunctionalityKey] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV60Wwpbaseobjects_secfunctionalityfilterparentwwds_8_tfsecfunctionalitydescription_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59Wwpbaseobjects_secfunctionalityfilterparentwwds_7_tfsecfunctionalitydescription)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[SecFunctionalityDescription]) like UPPER(@lV59Wwpbaseobjects_secfunctionalityfilterparentwwds_7_tfsecfunctionalitydescription))");
         }
         else
         {
            GXv_int4[6] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Wwpbaseobjects_secfunctionalityfilterparentwwds_8_tfsecfunctionalitydescription_sel)) && ! ( StringUtil.StrCmp(AV60Wwpbaseobjects_secfunctionalityfilterparentwwds_8_tfsecfunctionalitydescription_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[SecFunctionalityDescription] = @AV60Wwpbaseobjects_secfunctionalityfilterparentwwds_8_tfsecfunctionalitydescription_sel)");
         }
         else
         {
            GXv_int4[7] = 1;
         }
         if ( StringUtil.StrCmp(AV60Wwpbaseobjects_secfunctionalityfilterparentwwds_8_tfsecfunctionalitydescription_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[SecFunctionalityDescription] = ''))");
         }
         if ( AV61Wwpbaseobjects_secfunctionalityfilterparentwwds_9_tfsecfunctionalitytype_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV61Wwpbaseobjects_secfunctionalityfilterparentwwds_9_tfsecfunctionalitytype_sels, "T1.[SecFunctionalityType] IN (", ")")+")");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV63Wwpbaseobjects_secfunctionalityfilterparentwwds_11_tfsecparentfunctionalitydescription_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Wwpbaseobjects_secfunctionalityfilterparentwwds_10_tfsecparentfunctionalitydescription)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[SecFunctionalityDescription]) like UPPER(@lV62Wwpbaseobjects_secfunctionalityfilterparentwwds_10_tfsecparentfunctionalitydescription))");
         }
         else
         {
            GXv_int4[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Wwpbaseobjects_secfunctionalityfilterparentwwds_11_tfsecparentfunctionalitydescription_sel)) && ! ( StringUtil.StrCmp(AV63Wwpbaseobjects_secfunctionalityfilterparentwwds_11_tfsecparentfunctionalitydescription_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.[SecFunctionalityDescription] = @AV63Wwpbaseobjects_secfunctionalityfilterparentwwds_11_tfsecparentfunctionalitydescription_sel)");
         }
         else
         {
            GXv_int4[9] = 1;
         }
         if ( StringUtil.StrCmp(AV63Wwpbaseobjects_secfunctionalityfilterparentwwds_11_tfsecparentfunctionalitydescription_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T2.[SecFunctionalityDescription] IS NULL or (T2.[SecFunctionalityDescription] = ''))");
         }
         scmdbuf += sWhereString;
         if ( ( AV17OrderedBy == 1 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[SecParentFunctionalityId], T1.[SecFunctionalityDescription]";
         }
         else if ( ( AV17OrderedBy == 1 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[SecParentFunctionalityId] DESC, T1.[SecFunctionalityDescription] DESC";
         }
         else if ( ( AV17OrderedBy == 2 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[SecParentFunctionalityId], T1.[SecFunctionalityKey]";
         }
         else if ( ( AV17OrderedBy == 2 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[SecParentFunctionalityId] DESC, T1.[SecFunctionalityKey] DESC";
         }
         else if ( ( AV17OrderedBy == 3 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[SecParentFunctionalityId], T1.[SecFunctionalityType]";
         }
         else if ( ( AV17OrderedBy == 3 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[SecParentFunctionalityId] DESC, T1.[SecFunctionalityType] DESC";
         }
         else if ( ( AV17OrderedBy == 4 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[SecParentFunctionalityId], T2.[SecFunctionalityDescription]";
         }
         else if ( ( AV17OrderedBy == 4 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[SecParentFunctionalityId] DESC, T2.[SecFunctionalityDescription] DESC";
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
                     return conditional_P00282(context, (short)dynConstraints[0] , (GxSimpleCollection<short>)dynConstraints[1] , (short)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (int)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (short)dynConstraints[15] , (bool)dynConstraints[16] , (string)dynConstraints[17] , (long)dynConstraints[18] , (long)dynConstraints[19] );
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
          Object[] prmP00282;
          prmP00282 = new Object[] {
          new ParDef("@AV53Wwpbaseobjects_secfunctionalityfilterparentwwds_1_secparentfunctionalityid",GXType.Decimal,10,0) ,
          new ParDef("@AV55Wwpbaseobjects_secfunctionalityfilterparentwwds_3_secfunctionalitytype",GXType.Int16,2,0) ,
          new ParDef("@lV56Wwpbaseobjects_secfunctionalityfilterparentwwds_4_secfunctionalitydescription",GXType.VarChar,100,0) ,
          new ParDef("@lV56Wwpbaseobjects_secfunctionalityfilterparentwwds_4_secfunctionalitydescription",GXType.VarChar,100,0) ,
          new ParDef("@lV57Wwpbaseobjects_secfunctionalityfilterparentwwds_5_tfsecfunctionalitykey",GXType.VarChar,100,0) ,
          new ParDef("@AV58Wwpbaseobjects_secfunctionalityfilterparentwwds_6_tfsecfunctionalitykey_sel",GXType.NVarChar,100,0) ,
          new ParDef("@lV59Wwpbaseobjects_secfunctionalityfilterparentwwds_7_tfsecfunctionalitydescription",GXType.VarChar,100,0) ,
          new ParDef("@AV60Wwpbaseobjects_secfunctionalityfilterparentwwds_8_tfsecfunctionalitydescription_sel",GXType.NVarChar,100,0) ,
          new ParDef("@lV62Wwpbaseobjects_secfunctionalityfilterparentwwds_10_tfsecparentfunctionalitydescription",GXType.VarChar,100,0) ,
          new ParDef("@AV63Wwpbaseobjects_secfunctionalityfilterparentwwds_11_tfsecparentfunctionalitydescription_sel",GXType.NVarChar,100,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00282", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00282,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                ((long[]) buf[4])[0] = rslt.getLong(5);
                ((bool[]) buf[5])[0] = rslt.wasNull(5);
                ((long[]) buf[6])[0] = rslt.getLong(6);
                return;
       }
    }

 }

}

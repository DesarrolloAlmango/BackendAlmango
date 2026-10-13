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
   public class secuserwwexport : GXProcedure
   {
      public secuserwwexport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public secuserwwexport( IGxContext context )
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
         new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWSecUser", out  GXt_boolean1) ;
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
            new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV47WWPContext) ;
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
         AV11Filename = GXt_char2 + "SecUserWWExport-" + StringUtil.Trim( StringUtil.Str( (decimal)(AV15Random), 8, 0)) + ".xlsx";
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
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV51FilterFullText)) ) )
         {
            GXt_int3 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int3,  (short)(AV14FirstColumn),  context.GetMessage( "WWP_FullTextFilterDescription", "")) ;
            AV13CellRow = GXt_int3;
            GXt_char2 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV51FilterFullText, out  GXt_char2) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char2;
         }
         if ( AV30GridState.gxTpr_Dynamicfilters.Count >= 1 )
         {
            AV31GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV30GridState.gxTpr_Dynamicfilters.Item(1));
            AV18DynamicFiltersSelector1 = AV31GridStateDynamicFilter.gxTpr_Selected;
            if ( StringUtil.StrCmp(AV18DynamicFiltersSelector1, "SECUSERNAME") == 0 )
            {
               AV19DynamicFiltersOperator1 = AV31GridStateDynamicFilter.gxTpr_Operator;
               AV20SecUserName1 = AV31GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV20SecUserName1)) )
               {
                  AV13CellRow = (int)(AV13CellRow+1);
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                  if ( AV19DynamicFiltersOperator1 == 0 )
                  {
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", context.GetMessage( "NickName", ""), context.GetMessage( "WWP_FilterLike", ""), "", "", "", "", "", "", "");
                  }
                  else if ( AV19DynamicFiltersOperator1 == 1 )
                  {
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", context.GetMessage( "NickName", ""), context.GetMessage( "WWP_FilterContains", ""), "", "", "", "", "", "", "");
                  }
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                  GXt_char2 = "";
                  new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV20SecUserName1, out  GXt_char2) ;
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char2;
               }
            }
            else if ( StringUtil.StrCmp(AV18DynamicFiltersSelector1, "USUARIOSID") == 0 )
            {
               AV19DynamicFiltersOperator1 = AV31GridStateDynamicFilter.gxTpr_Operator;
               AV52usuariosId1 = AV31GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV52usuariosId1)) )
               {
                  AV13CellRow = (int)(AV13CellRow+1);
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                  if ( AV19DynamicFiltersOperator1 == 0 )
                  {
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", context.GetMessage( "NickName", ""), context.GetMessage( "WWP_FilterLike", ""), "", "", "", "", "", "", "");
                  }
                  else if ( AV19DynamicFiltersOperator1 == 1 )
                  {
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", context.GetMessage( "NickName", ""), context.GetMessage( "WWP_FilterContains", ""), "", "", "", "", "", "", "");
                  }
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                  GXt_char2 = "";
                  new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV52usuariosId1, out  GXt_char2) ;
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char2;
               }
            }
            if ( AV30GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV21DynamicFiltersEnabled2 = true;
               AV31GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV30GridState.gxTpr_Dynamicfilters.Item(2));
               AV22DynamicFiltersSelector2 = AV31GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV22DynamicFiltersSelector2, "SECUSERNAME") == 0 )
               {
                  AV23DynamicFiltersOperator2 = AV31GridStateDynamicFilter.gxTpr_Operator;
                  AV24SecUserName2 = AV31GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV24SecUserName2)) )
                  {
                     AV13CellRow = (int)(AV13CellRow+1);
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                     if ( AV23DynamicFiltersOperator2 == 0 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", context.GetMessage( "NickName", ""), context.GetMessage( "WWP_FilterLike", ""), "", "", "", "", "", "", "");
                     }
                     else if ( AV23DynamicFiltersOperator2 == 1 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", context.GetMessage( "NickName", ""), context.GetMessage( "WWP_FilterContains", ""), "", "", "", "", "", "", "");
                     }
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                     GXt_char2 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV24SecUserName2, out  GXt_char2) ;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char2;
                  }
               }
               else if ( StringUtil.StrCmp(AV22DynamicFiltersSelector2, "USUARIOSID") == 0 )
               {
                  AV23DynamicFiltersOperator2 = AV31GridStateDynamicFilter.gxTpr_Operator;
                  AV53usuariosId2 = AV31GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV53usuariosId2)) )
                  {
                     AV13CellRow = (int)(AV13CellRow+1);
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                     if ( AV23DynamicFiltersOperator2 == 0 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", context.GetMessage( "NickName", ""), context.GetMessage( "WWP_FilterLike", ""), "", "", "", "", "", "", "");
                     }
                     else if ( AV23DynamicFiltersOperator2 == 1 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", context.GetMessage( "NickName", ""), context.GetMessage( "WWP_FilterContains", ""), "", "", "", "", "", "", "");
                     }
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                     GXt_char2 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV53usuariosId2, out  GXt_char2) ;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char2;
                  }
               }
               if ( AV30GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV25DynamicFiltersEnabled3 = true;
                  AV31GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV30GridState.gxTpr_Dynamicfilters.Item(3));
                  AV26DynamicFiltersSelector3 = AV31GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV26DynamicFiltersSelector3, "SECUSERNAME") == 0 )
                  {
                     AV27DynamicFiltersOperator3 = AV31GridStateDynamicFilter.gxTpr_Operator;
                     AV28SecUserName3 = AV31GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV28SecUserName3)) )
                     {
                        AV13CellRow = (int)(AV13CellRow+1);
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                        if ( AV27DynamicFiltersOperator3 == 0 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", context.GetMessage( "NickName", ""), context.GetMessage( "WWP_FilterLike", ""), "", "", "", "", "", "", "");
                        }
                        else if ( AV27DynamicFiltersOperator3 == 1 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", context.GetMessage( "NickName", ""), context.GetMessage( "WWP_FilterContains", ""), "", "", "", "", "", "", "");
                        }
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                        GXt_char2 = "";
                        new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV28SecUserName3, out  GXt_char2) ;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char2;
                     }
                  }
                  else if ( StringUtil.StrCmp(AV26DynamicFiltersSelector3, "USUARIOSID") == 0 )
                  {
                     AV27DynamicFiltersOperator3 = AV31GridStateDynamicFilter.gxTpr_Operator;
                     AV54usuariosId3 = AV31GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV54usuariosId3)) )
                     {
                        AV13CellRow = (int)(AV13CellRow+1);
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                        if ( AV27DynamicFiltersOperator3 == 0 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", context.GetMessage( "NickName", ""), context.GetMessage( "WWP_FilterLike", ""), "", "", "", "", "", "", "");
                        }
                        else if ( AV27DynamicFiltersOperator3 == 1 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", context.GetMessage( "NickName", ""), context.GetMessage( "WWP_FilterContains", ""), "", "", "", "", "", "", "");
                        }
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                        GXt_char2 = "";
                        new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV54usuariosId3, out  GXt_char2) ;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char2;
                     }
                  }
               }
            }
         }
         if ( ! ( (0==AV32TFSecUserId) && (0==AV33TFSecUserId_To) ) )
         {
            GXt_int3 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int3,  (short)(AV14FirstColumn),  context.GetMessage( "Usuario Nro.", "")) ;
            AV13CellRow = GXt_int3;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Number = AV32TFSecUserId;
            GXt_int3 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  false, ref  GXt_int3,  (short)(AV14FirstColumn+2),  context.GetMessage( "WWP_TSTo", "")) ;
            AV13CellRow = GXt_int3;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Number = AV33TFSecUserId_To;
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV35TFSecUserName_Sel)) ) )
         {
            GXt_int3 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int3,  (short)(AV14FirstColumn),  context.GetMessage( "NickName", "")) ;
            AV13CellRow = GXt_int3;
            GXt_char2 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV35TFSecUserName_Sel)) ? context.GetMessage( "WWP_TitleFilter_EmptyOption", "") : AV35TFSecUserName_Sel), out  GXt_char2) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char2;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV34TFSecUserName)) ) )
            {
               GXt_int3 = (short)(AV13CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int3,  (short)(AV14FirstColumn),  context.GetMessage( "NickName", "")) ;
               AV13CellRow = GXt_int3;
               GXt_char2 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV34TFSecUserName, out  GXt_char2) ;
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char2;
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV56TFSecUserFullName_Sel)) ) )
         {
            GXt_int3 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int3,  (short)(AV14FirstColumn),  context.GetMessage( "Nombre Completo", "")) ;
            AV13CellRow = GXt_int3;
            GXt_char2 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV56TFSecUserFullName_Sel)) ? context.GetMessage( "WWP_TitleFilter_EmptyOption", "") : AV56TFSecUserFullName_Sel), out  GXt_char2) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char2;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV55TFSecUserFullName)) ) )
            {
               GXt_int3 = (short)(AV13CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int3,  (short)(AV14FirstColumn),  context.GetMessage( "Nombre Completo", "")) ;
               AV13CellRow = GXt_int3;
               GXt_char2 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV55TFSecUserFullName, out  GXt_char2) ;
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char2;
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV58TFusuariosId_Sel)) ) )
         {
            GXt_int3 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int3,  (short)(AV14FirstColumn),  context.GetMessage( "NickName", "")) ;
            AV13CellRow = GXt_int3;
            GXt_char2 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV58TFusuariosId_Sel)) ? context.GetMessage( "WWP_TitleFilter_EmptyOption", "") : AV58TFusuariosId_Sel), out  GXt_char2) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char2;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV57TFusuariosId)) ) )
            {
               GXt_int3 = (short)(AV13CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int3,  (short)(AV14FirstColumn),  context.GetMessage( "NickName", "")) ;
               AV13CellRow = GXt_int3;
               GXt_char2 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV57TFusuariosId, out  GXt_char2) ;
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char2;
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV60TFusuariosNombre_Sel)) ) )
         {
            GXt_int3 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int3,  (short)(AV14FirstColumn),  context.GetMessage( "Nombre", "")) ;
            AV13CellRow = GXt_int3;
            GXt_char2 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV60TFusuariosNombre_Sel)) ? context.GetMessage( "WWP_TitleFilter_EmptyOption", "") : AV60TFusuariosNombre_Sel), out  GXt_char2) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char2;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV59TFusuariosNombre)) ) )
            {
               GXt_int3 = (short)(AV13CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int3,  (short)(AV14FirstColumn),  context.GetMessage( "Nombre", "")) ;
               AV13CellRow = GXt_int3;
               GXt_char2 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV59TFusuariosNombre, out  GXt_char2) ;
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char2;
            }
         }
         if ( ! ( ( AV62TFusuariosEstado_Sels.Count == 0 ) ) )
         {
            GXt_int3 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int3,  (short)(AV14FirstColumn),  context.GetMessage( "usuarios Estado", "")) ;
            AV13CellRow = GXt_int3;
            AV43i = 1;
            AV70GXV1 = 1;
            while ( AV70GXV1 <= AV62TFusuariosEstado_Sels.Count )
            {
               AV63TFusuariosEstado_Sel = AV62TFusuariosEstado_Sels.GetString(AV70GXV1);
               if ( AV43i == 1 )
               {
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "";
               }
               else
               {
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text+", ";
               }
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text+context.GetMessage( gxdomainestadoenum.getDescription(context,AV63TFusuariosEstado_Sel), "");
               AV43i = (long)(AV43i+1);
               AV70GXV1 = (int)(AV70GXV1+1);
            }
         }
         if ( ! ( ( AV65TFSecUserEstado_Sels.Count == 0 ) ) )
         {
            GXt_int3 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int3,  (short)(AV14FirstColumn),  context.GetMessage( "Estado", "")) ;
            AV13CellRow = GXt_int3;
            AV43i = 1;
            AV71GXV2 = 1;
            while ( AV71GXV2 <= AV65TFSecUserEstado_Sels.Count )
            {
               AV66TFSecUserEstado_Sel = AV65TFSecUserEstado_Sels.GetString(AV71GXV2);
               if ( AV43i == 1 )
               {
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "";
               }
               else
               {
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text+", ";
               }
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text+context.GetMessage( gxdomainestadoenum.getDescription(context,AV66TFSecUserEstado_Sel), "");
               AV43i = (long)(AV43i+1);
               AV71GXV2 = (int)(AV71GXV2+1);
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV68TFSecUserPassword_Sel)) ) )
         {
            GXt_int3 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int3,  (short)(AV14FirstColumn),  context.GetMessage( "Password", "")) ;
            AV13CellRow = GXt_int3;
            GXt_char2 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV68TFSecUserPassword_Sel)) ? context.GetMessage( "WWP_TitleFilter_EmptyOption", "") : AV68TFSecUserPassword_Sel), out  GXt_char2) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char2;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV67TFSecUserPassword)) ) )
            {
               GXt_int3 = (short)(AV13CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int3,  (short)(AV14FirstColumn),  context.GetMessage( "Password", "")) ;
               AV13CellRow = GXt_int3;
               GXt_char2 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV67TFSecUserPassword, out  GXt_char2) ;
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char2;
            }
         }
         AV13CellRow = (int)(AV13CellRow+2);
      }

      protected void S141( )
      {
         /* 'WRITECOLUMNTITLES' Routine */
         returnInSub = false;
         AV44VisibleColumnCount = 0;
         if ( StringUtil.StrCmp(AV38Session.Get("WWPBaseObjects.SecUserWWColumnsSelector"), "") != 0 )
         {
            AV37ColumnsSelectorXML = AV38Session.Get("WWPBaseObjects.SecUserWWColumnsSelector");
            AV36ColumnsSelector.FromXml(AV37ColumnsSelectorXML, null, "", "");
         }
         else
         {
            /* Execute user subroutine: 'INITIALIZECOLUMNSSELECTOR' */
            S151 ();
            if (returnInSub) return;
         }
         AV36ColumnsSelector.gxTpr_Columns.Sort("Order");
         AV72GXV3 = 1;
         while ( AV72GXV3 <= AV36ColumnsSelector.gxTpr_Columns.Count )
         {
            AV50ColumnsSelector_Column = ((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV36ColumnsSelector.gxTpr_Columns.Item(AV72GXV3));
            if ( AV50ColumnsSelector_Column.gxTpr_Isvisible )
            {
               AV10ExcelDocument.get_Cells(AV13CellRow, (int)(AV14FirstColumn+AV44VisibleColumnCount), 1, 1).Text = context.GetMessage( (String.IsNullOrEmpty(StringUtil.RTrim( AV50ColumnsSelector_Column.gxTpr_Displayname)) ? AV50ColumnsSelector_Column.gxTpr_Columnname : AV50ColumnsSelector_Column.gxTpr_Displayname), "");
               AV10ExcelDocument.get_Cells(AV13CellRow, (int)(AV14FirstColumn+AV44VisibleColumnCount), 1, 1).Bold = 1;
               AV10ExcelDocument.get_Cells(AV13CellRow, (int)(AV14FirstColumn+AV44VisibleColumnCount), 1, 1).Color = 11;
               AV44VisibleColumnCount = (long)(AV44VisibleColumnCount+1);
            }
            AV72GXV3 = (int)(AV72GXV3+1);
         }
      }

      protected void S161( )
      {
         /* 'WRITEDATA' Routine */
         returnInSub = false;
         AV74Wwpbaseobjects_secuserwwds_1_filterfulltext = AV51FilterFullText;
         AV75Wwpbaseobjects_secuserwwds_2_dynamicfiltersselector1 = AV18DynamicFiltersSelector1;
         AV76Wwpbaseobjects_secuserwwds_3_dynamicfiltersoperator1 = AV19DynamicFiltersOperator1;
         AV77Wwpbaseobjects_secuserwwds_4_secusername1 = AV20SecUserName1;
         AV78Wwpbaseobjects_secuserwwds_5_usuariosid1 = AV52usuariosId1;
         AV79Wwpbaseobjects_secuserwwds_6_dynamicfiltersenabled2 = AV21DynamicFiltersEnabled2;
         AV80Wwpbaseobjects_secuserwwds_7_dynamicfiltersselector2 = AV22DynamicFiltersSelector2;
         AV81Wwpbaseobjects_secuserwwds_8_dynamicfiltersoperator2 = AV23DynamicFiltersOperator2;
         AV82Wwpbaseobjects_secuserwwds_9_secusername2 = AV24SecUserName2;
         AV83Wwpbaseobjects_secuserwwds_10_usuariosid2 = AV53usuariosId2;
         AV84Wwpbaseobjects_secuserwwds_11_dynamicfiltersenabled3 = AV25DynamicFiltersEnabled3;
         AV85Wwpbaseobjects_secuserwwds_12_dynamicfiltersselector3 = AV26DynamicFiltersSelector3;
         AV86Wwpbaseobjects_secuserwwds_13_dynamicfiltersoperator3 = AV27DynamicFiltersOperator3;
         AV87Wwpbaseobjects_secuserwwds_14_secusername3 = AV28SecUserName3;
         AV88Wwpbaseobjects_secuserwwds_15_usuariosid3 = AV54usuariosId3;
         AV89Wwpbaseobjects_secuserwwds_16_tfsecuserid = AV32TFSecUserId;
         AV90Wwpbaseobjects_secuserwwds_17_tfsecuserid_to = AV33TFSecUserId_To;
         AV91Wwpbaseobjects_secuserwwds_18_tfsecusername = AV34TFSecUserName;
         AV92Wwpbaseobjects_secuserwwds_19_tfsecusername_sel = AV35TFSecUserName_Sel;
         AV93Wwpbaseobjects_secuserwwds_20_tfsecuserfullname = AV55TFSecUserFullName;
         AV94Wwpbaseobjects_secuserwwds_21_tfsecuserfullname_sel = AV56TFSecUserFullName_Sel;
         AV95Wwpbaseobjects_secuserwwds_22_tfusuariosid = AV57TFusuariosId;
         AV96Wwpbaseobjects_secuserwwds_23_tfusuariosid_sel = AV58TFusuariosId_Sel;
         AV97Wwpbaseobjects_secuserwwds_24_tfusuariosnombre = AV59TFusuariosNombre;
         AV98Wwpbaseobjects_secuserwwds_25_tfusuariosnombre_sel = AV60TFusuariosNombre_Sel;
         AV99Wwpbaseobjects_secuserwwds_26_tfusuariosestado_sels = AV62TFusuariosEstado_Sels;
         AV100Wwpbaseobjects_secuserwwds_27_tfsecuserestado_sels = AV65TFSecUserEstado_Sels;
         AV101Wwpbaseobjects_secuserwwds_28_tfsecuserpassword = AV67TFSecUserPassword;
         AV102Wwpbaseobjects_secuserwwds_29_tfsecuserpassword_sel = AV68TFSecUserPassword_Sel;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A226usuariosEstado ,
                                              AV99Wwpbaseobjects_secuserwwds_26_tfusuariosestado_sels ,
                                              A550SecUserEstado ,
                                              AV100Wwpbaseobjects_secuserwwds_27_tfsecuserestado_sels ,
                                              AV75Wwpbaseobjects_secuserwwds_2_dynamicfiltersselector1 ,
                                              AV76Wwpbaseobjects_secuserwwds_3_dynamicfiltersoperator1 ,
                                              AV77Wwpbaseobjects_secuserwwds_4_secusername1 ,
                                              AV78Wwpbaseobjects_secuserwwds_5_usuariosid1 ,
                                              AV79Wwpbaseobjects_secuserwwds_6_dynamicfiltersenabled2 ,
                                              AV80Wwpbaseobjects_secuserwwds_7_dynamicfiltersselector2 ,
                                              AV81Wwpbaseobjects_secuserwwds_8_dynamicfiltersoperator2 ,
                                              AV82Wwpbaseobjects_secuserwwds_9_secusername2 ,
                                              AV83Wwpbaseobjects_secuserwwds_10_usuariosid2 ,
                                              AV84Wwpbaseobjects_secuserwwds_11_dynamicfiltersenabled3 ,
                                              AV85Wwpbaseobjects_secuserwwds_12_dynamicfiltersselector3 ,
                                              AV86Wwpbaseobjects_secuserwwds_13_dynamicfiltersoperator3 ,
                                              AV87Wwpbaseobjects_secuserwwds_14_secusername3 ,
                                              AV88Wwpbaseobjects_secuserwwds_15_usuariosid3 ,
                                              AV89Wwpbaseobjects_secuserwwds_16_tfsecuserid ,
                                              AV90Wwpbaseobjects_secuserwwds_17_tfsecuserid_to ,
                                              AV92Wwpbaseobjects_secuserwwds_19_tfsecusername_sel ,
                                              AV91Wwpbaseobjects_secuserwwds_18_tfsecusername ,
                                              AV94Wwpbaseobjects_secuserwwds_21_tfsecuserfullname_sel ,
                                              AV93Wwpbaseobjects_secuserwwds_20_tfsecuserfullname ,
                                              AV96Wwpbaseobjects_secuserwwds_23_tfusuariosid_sel ,
                                              AV95Wwpbaseobjects_secuserwwds_22_tfusuariosid ,
                                              AV98Wwpbaseobjects_secuserwwds_25_tfusuariosnombre_sel ,
                                              AV97Wwpbaseobjects_secuserwwds_24_tfusuariosnombre ,
                                              AV99Wwpbaseobjects_secuserwwds_26_tfusuariosestado_sels.Count ,
                                              AV100Wwpbaseobjects_secuserwwds_27_tfsecuserestado_sels.Count ,
                                              AV102Wwpbaseobjects_secuserwwds_29_tfsecuserpassword_sel ,
                                              AV101Wwpbaseobjects_secuserwwds_28_tfsecuserpassword ,
                                              A26SecUserName ,
                                              A145usuariosId ,
                                              A18SecUserId ,
                                              A587SecUserFullName ,
                                              A222usuariosNombre ,
                                              A27SecUserPassword ,
                                              AV16OrderedBy ,
                                              AV17OrderedDsc ,
                                              AV74Wwpbaseobjects_secuserwwds_1_filterfulltext } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.INT, TypeConstants.INT,
                                              TypeConstants.BOOLEAN, TypeConstants.LONG, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV77Wwpbaseobjects_secuserwwds_4_secusername1 = StringUtil.Concat( StringUtil.RTrim( AV77Wwpbaseobjects_secuserwwds_4_secusername1), "%", "");
         lV77Wwpbaseobjects_secuserwwds_4_secusername1 = StringUtil.Concat( StringUtil.RTrim( AV77Wwpbaseobjects_secuserwwds_4_secusername1), "%", "");
         lV78Wwpbaseobjects_secuserwwds_5_usuariosid1 = StringUtil.PadR( StringUtil.RTrim( AV78Wwpbaseobjects_secuserwwds_5_usuariosid1), 20, "%");
         lV78Wwpbaseobjects_secuserwwds_5_usuariosid1 = StringUtil.PadR( StringUtil.RTrim( AV78Wwpbaseobjects_secuserwwds_5_usuariosid1), 20, "%");
         lV82Wwpbaseobjects_secuserwwds_9_secusername2 = StringUtil.Concat( StringUtil.RTrim( AV82Wwpbaseobjects_secuserwwds_9_secusername2), "%", "");
         lV82Wwpbaseobjects_secuserwwds_9_secusername2 = StringUtil.Concat( StringUtil.RTrim( AV82Wwpbaseobjects_secuserwwds_9_secusername2), "%", "");
         lV83Wwpbaseobjects_secuserwwds_10_usuariosid2 = StringUtil.PadR( StringUtil.RTrim( AV83Wwpbaseobjects_secuserwwds_10_usuariosid2), 20, "%");
         lV83Wwpbaseobjects_secuserwwds_10_usuariosid2 = StringUtil.PadR( StringUtil.RTrim( AV83Wwpbaseobjects_secuserwwds_10_usuariosid2), 20, "%");
         lV87Wwpbaseobjects_secuserwwds_14_secusername3 = StringUtil.Concat( StringUtil.RTrim( AV87Wwpbaseobjects_secuserwwds_14_secusername3), "%", "");
         lV87Wwpbaseobjects_secuserwwds_14_secusername3 = StringUtil.Concat( StringUtil.RTrim( AV87Wwpbaseobjects_secuserwwds_14_secusername3), "%", "");
         lV88Wwpbaseobjects_secuserwwds_15_usuariosid3 = StringUtil.PadR( StringUtil.RTrim( AV88Wwpbaseobjects_secuserwwds_15_usuariosid3), 20, "%");
         lV88Wwpbaseobjects_secuserwwds_15_usuariosid3 = StringUtil.PadR( StringUtil.RTrim( AV88Wwpbaseobjects_secuserwwds_15_usuariosid3), 20, "%");
         lV91Wwpbaseobjects_secuserwwds_18_tfsecusername = StringUtil.Concat( StringUtil.RTrim( AV91Wwpbaseobjects_secuserwwds_18_tfsecusername), "%", "");
         lV93Wwpbaseobjects_secuserwwds_20_tfsecuserfullname = StringUtil.Concat( StringUtil.RTrim( AV93Wwpbaseobjects_secuserwwds_20_tfsecuserfullname), "%", "");
         lV95Wwpbaseobjects_secuserwwds_22_tfusuariosid = StringUtil.PadR( StringUtil.RTrim( AV95Wwpbaseobjects_secuserwwds_22_tfusuariosid), 20, "%");
         lV97Wwpbaseobjects_secuserwwds_24_tfusuariosnombre = StringUtil.PadR( StringUtil.RTrim( AV97Wwpbaseobjects_secuserwwds_24_tfusuariosnombre), 80, "%");
         lV101Wwpbaseobjects_secuserwwds_28_tfsecuserpassword = StringUtil.Concat( StringUtil.RTrim( AV101Wwpbaseobjects_secuserwwds_28_tfsecuserpassword), "%", "");
         /* Using cursor P002O2 */
         pr_default.execute(0, new Object[] {lV77Wwpbaseobjects_secuserwwds_4_secusername1, lV77Wwpbaseobjects_secuserwwds_4_secusername1, lV78Wwpbaseobjects_secuserwwds_5_usuariosid1, lV78Wwpbaseobjects_secuserwwds_5_usuariosid1, lV82Wwpbaseobjects_secuserwwds_9_secusername2, lV82Wwpbaseobjects_secuserwwds_9_secusername2, lV83Wwpbaseobjects_secuserwwds_10_usuariosid2, lV83Wwpbaseobjects_secuserwwds_10_usuariosid2, lV87Wwpbaseobjects_secuserwwds_14_secusername3, lV87Wwpbaseobjects_secuserwwds_14_secusername3, lV88Wwpbaseobjects_secuserwwds_15_usuariosid3, lV88Wwpbaseobjects_secuserwwds_15_usuariosid3, AV89Wwpbaseobjects_secuserwwds_16_tfsecuserid, AV90Wwpbaseobjects_secuserwwds_17_tfsecuserid_to, lV91Wwpbaseobjects_secuserwwds_18_tfsecusername, AV92Wwpbaseobjects_secuserwwds_19_tfsecusername_sel, lV93Wwpbaseobjects_secuserwwds_20_tfsecuserfullname, AV94Wwpbaseobjects_secuserwwds_21_tfsecuserfullname_sel, lV95Wwpbaseobjects_secuserwwds_22_tfusuariosid, AV96Wwpbaseobjects_secuserwwds_23_tfusuariosid_sel, lV97Wwpbaseobjects_secuserwwds_24_tfusuariosnombre, AV98Wwpbaseobjects_secuserwwds_25_tfusuariosnombre_sel, lV101Wwpbaseobjects_secuserwwds_28_tfsecuserpassword, AV102Wwpbaseobjects_secuserwwds_29_tfsecuserpassword_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A27SecUserPassword = P002O2_A27SecUserPassword[0];
            A222usuariosNombre = P002O2_A222usuariosNombre[0];
            A145usuariosId = P002O2_A145usuariosId[0];
            n145usuariosId = P002O2_n145usuariosId[0];
            A587SecUserFullName = P002O2_A587SecUserFullName[0];
            A26SecUserName = P002O2_A26SecUserName[0];
            A18SecUserId = P002O2_A18SecUserId[0];
            A550SecUserEstado = P002O2_A550SecUserEstado[0];
            n550SecUserEstado = P002O2_n550SecUserEstado[0];
            A226usuariosEstado = P002O2_A226usuariosEstado[0];
            A222usuariosNombre = P002O2_A222usuariosNombre[0];
            A226usuariosEstado = P002O2_A226usuariosEstado[0];
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV74Wwpbaseobjects_secuserwwds_1_filterfulltext)) || ( ( StringUtil.Like( StringUtil.Str( (decimal)(A18SecUserId), 10, 0) , StringUtil.PadR( "%" + AV74Wwpbaseobjects_secuserwwds_1_filterfulltext , 254 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Upper( A26SecUserName) , StringUtil.PadR( "%" + StringUtil.Upper( AV74Wwpbaseobjects_secuserwwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A587SecUserFullName) , StringUtil.PadR( "%" + StringUtil.Upper( AV74Wwpbaseobjects_secuserwwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Upper( A145usuariosId) , StringUtil.PadR( "%" + StringUtil.Upper( AV74Wwpbaseobjects_secuserwwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A222usuariosNombre) , StringUtil.PadR( "%" + StringUtil.Upper( AV74Wwpbaseobjects_secuserwwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( context.GetMessage( "habilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV74Wwpbaseobjects_secuserwwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A226usuariosEstado, "HAB") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "deshabilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV74Wwpbaseobjects_secuserwwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A226usuariosEstado, "DES") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "pendiente", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV74Wwpbaseobjects_secuserwwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A226usuariosEstado, "PEN") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "habilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV74Wwpbaseobjects_secuserwwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A550SecUserEstado, "HAB") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "deshabilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV74Wwpbaseobjects_secuserwwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A550SecUserEstado, "DES") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "pendiente", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV74Wwpbaseobjects_secuserwwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A550SecUserEstado, "PEN") == 0 ) ) || ( StringUtil.Like( StringUtil.Upper( A27SecUserPassword) , StringUtil.PadR( "%" + StringUtil.Upper( AV74Wwpbaseobjects_secuserwwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) )
            )
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
               AV44VisibleColumnCount = 0;
               AV103GXV4 = 1;
               while ( AV103GXV4 <= AV36ColumnsSelector.gxTpr_Columns.Count )
               {
                  AV50ColumnsSelector_Column = ((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV36ColumnsSelector.gxTpr_Columns.Item(AV103GXV4));
                  if ( AV50ColumnsSelector_Column.gxTpr_Isvisible )
                  {
                     if ( StringUtil.StrCmp(AV50ColumnsSelector_Column.gxTpr_Columnname, "SecUserId") == 0 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, (int)(AV14FirstColumn+AV44VisibleColumnCount), 1, 1).Number = A18SecUserId;
                     }
                     else if ( StringUtil.StrCmp(AV50ColumnsSelector_Column.gxTpr_Columnname, "SecUserName") == 0 )
                     {
                        GXt_char2 = "";
                        new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A26SecUserName, out  GXt_char2) ;
                        AV10ExcelDocument.get_Cells(AV13CellRow, (int)(AV14FirstColumn+AV44VisibleColumnCount), 1, 1).Text = GXt_char2;
                     }
                     else if ( StringUtil.StrCmp(AV50ColumnsSelector_Column.gxTpr_Columnname, "SecUserFullName") == 0 )
                     {
                        GXt_char2 = "";
                        new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A587SecUserFullName, out  GXt_char2) ;
                        AV10ExcelDocument.get_Cells(AV13CellRow, (int)(AV14FirstColumn+AV44VisibleColumnCount), 1, 1).Text = GXt_char2;
                     }
                     else if ( StringUtil.StrCmp(AV50ColumnsSelector_Column.gxTpr_Columnname, "usuariosId") == 0 )
                     {
                        GXt_char2 = "";
                        new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A145usuariosId, out  GXt_char2) ;
                        AV10ExcelDocument.get_Cells(AV13CellRow, (int)(AV14FirstColumn+AV44VisibleColumnCount), 1, 1).Text = GXt_char2;
                     }
                     else if ( StringUtil.StrCmp(AV50ColumnsSelector_Column.gxTpr_Columnname, "usuariosNombre") == 0 )
                     {
                        GXt_char2 = "";
                        new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A222usuariosNombre, out  GXt_char2) ;
                        AV10ExcelDocument.get_Cells(AV13CellRow, (int)(AV14FirstColumn+AV44VisibleColumnCount), 1, 1).Text = GXt_char2;
                     }
                     else if ( StringUtil.StrCmp(AV50ColumnsSelector_Column.gxTpr_Columnname, "usuariosEstado") == 0 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, (int)(AV14FirstColumn+AV44VisibleColumnCount), 1, 1).Text = context.GetMessage( gxdomainestadoenum.getDescription(context,A226usuariosEstado), "");
                     }
                     else if ( StringUtil.StrCmp(AV50ColumnsSelector_Column.gxTpr_Columnname, "usuariosImagen") == 0 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, (int)(AV14FirstColumn+AV44VisibleColumnCount), 1, 1).Text = "";
                     }
                     else if ( StringUtil.StrCmp(AV50ColumnsSelector_Column.gxTpr_Columnname, "SecUserEstado") == 0 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, (int)(AV14FirstColumn+AV44VisibleColumnCount), 1, 1).Text = context.GetMessage( gxdomainestadoenum.getDescription(context,A550SecUserEstado), "");
                     }
                     else if ( StringUtil.StrCmp(AV50ColumnsSelector_Column.gxTpr_Columnname, "SecUserPassword") == 0 )
                     {
                        GXt_char2 = "";
                        new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A27SecUserPassword, out  GXt_char2) ;
                        AV10ExcelDocument.get_Cells(AV13CellRow, (int)(AV14FirstColumn+AV44VisibleColumnCount), 1, 1).Text = GXt_char2;
                     }
                     AV44VisibleColumnCount = (long)(AV44VisibleColumnCount+1);
                  }
                  AV103GXV4 = (int)(AV103GXV4+1);
               }
               if ( StringUtil.StrCmp(A550SecUserEstado, "PEN") == 0 )
               {
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, (int)(AV44VisibleColumnCount)).Color = GXUtil.RGB( 251, 110, 82);
               }
               else if ( StringUtil.StrCmp(A550SecUserEstado, "DES") == 0 )
               {
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, (int)(AV44VisibleColumnCount)).Color = GXUtil.RGB( 221, 75, 57);
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
         AV38Session.Set("WWPExportFilePath", AV11Filename);
         AV38Session.Set("WWPExportFileName", "SecUserWWExport.xlsx");
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
         AV36ColumnsSelector = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector(context);
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV36ColumnsSelector,  "SecUserId",  "",  "Usuario Nro.",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV36ColumnsSelector,  "SecUserName",  "",  "NickName",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV36ColumnsSelector,  "SecUserFullName",  "",  "Nombre Completo",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV36ColumnsSelector,  "usuariosId",  "",  "NickName",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV36ColumnsSelector,  "usuariosNombre",  "",  "Nombre",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV36ColumnsSelector,  "usuariosEstado",  "",  "usuarios Estado",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV36ColumnsSelector,  "usuariosImagen",  "",  "Imagen",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV36ColumnsSelector,  "SecUserEstado",  "",  "Estado",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV36ColumnsSelector,  "SecUserPassword",  "",  "Password",  true,  "") ;
         GXt_char2 = AV39UserCustomValue;
         new GeneXus.Programs.wwpbaseobjects.loadcolumnsselectorstate(context ).execute(  "WWPBaseObjects.SecUserWWColumnsSelector", out  GXt_char2) ;
         AV39UserCustomValue = GXt_char2;
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV39UserCustomValue)) ) )
         {
            AV49ColumnsSelectorAux.FromXml(AV39UserCustomValue, null, "", "");
            new GeneXus.Programs.wwpbaseobjects.wwp_columnselector_updatecolumns(context ).execute( ref  AV49ColumnsSelectorAux, ref  AV36ColumnsSelector) ;
         }
      }

      protected void S201( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV38Session.Get("WWPBaseObjects.SecUserWWGridState"), "") == 0 )
         {
            AV30GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "WWPBaseObjects.SecUserWWGridState"), null, "", "");
         }
         else
         {
            AV30GridState.FromXml(AV38Session.Get("WWPBaseObjects.SecUserWWGridState"), null, "", "");
         }
         AV16OrderedBy = AV30GridState.gxTpr_Orderedby;
         AV17OrderedDsc = AV30GridState.gxTpr_Ordereddsc;
         AV104GXV5 = 1;
         while ( AV104GXV5 <= AV30GridState.gxTpr_Filtervalues.Count )
         {
            AV48GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV30GridState.gxTpr_Filtervalues.Item(AV104GXV5));
            if ( StringUtil.StrCmp(AV48GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV51FilterFullText = AV48GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV48GridStateFilterValue.gxTpr_Name, "TFSECUSERID") == 0 )
            {
               AV32TFSecUserId = (long)(Math.Round(NumberUtil.Val( AV48GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV33TFSecUserId_To = (long)(Math.Round(NumberUtil.Val( AV48GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV48GridStateFilterValue.gxTpr_Name, "TFSECUSERNAME") == 0 )
            {
               AV34TFSecUserName = AV48GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV48GridStateFilterValue.gxTpr_Name, "TFSECUSERNAME_SEL") == 0 )
            {
               AV35TFSecUserName_Sel = AV48GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV48GridStateFilterValue.gxTpr_Name, "TFSECUSERFULLNAME") == 0 )
            {
               AV55TFSecUserFullName = AV48GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV48GridStateFilterValue.gxTpr_Name, "TFSECUSERFULLNAME_SEL") == 0 )
            {
               AV56TFSecUserFullName_Sel = AV48GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV48GridStateFilterValue.gxTpr_Name, "TFUSUARIOSID") == 0 )
            {
               AV57TFusuariosId = AV48GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV48GridStateFilterValue.gxTpr_Name, "TFUSUARIOSID_SEL") == 0 )
            {
               AV58TFusuariosId_Sel = AV48GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV48GridStateFilterValue.gxTpr_Name, "TFUSUARIOSNOMBRE") == 0 )
            {
               AV59TFusuariosNombre = AV48GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV48GridStateFilterValue.gxTpr_Name, "TFUSUARIOSNOMBRE_SEL") == 0 )
            {
               AV60TFusuariosNombre_Sel = AV48GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV48GridStateFilterValue.gxTpr_Name, "TFUSUARIOSESTADO_SEL") == 0 )
            {
               AV61TFusuariosEstado_SelsJson = AV48GridStateFilterValue.gxTpr_Value;
               AV62TFusuariosEstado_Sels.FromJSonString(AV61TFusuariosEstado_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV48GridStateFilterValue.gxTpr_Name, "TFSECUSERESTADO_SEL") == 0 )
            {
               AV64TFSecUserEstado_SelsJson = AV48GridStateFilterValue.gxTpr_Value;
               AV65TFSecUserEstado_Sels.FromJSonString(AV64TFSecUserEstado_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV48GridStateFilterValue.gxTpr_Name, "TFSECUSERPASSWORD") == 0 )
            {
               AV67TFSecUserPassword = AV48GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV48GridStateFilterValue.gxTpr_Name, "TFSECUSERPASSWORD_SEL") == 0 )
            {
               AV68TFSecUserPassword_Sel = AV48GridStateFilterValue.gxTpr_Value;
            }
            AV104GXV5 = (int)(AV104GXV5+1);
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
         AV69Pgmname = "";
         GXKey = "";
         GXEncryptionTmp = "";
         AV47WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV10ExcelDocument = new ExcelDocumentI();
         AV51FilterFullText = "";
         AV30GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV31GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV18DynamicFiltersSelector1 = "";
         AV20SecUserName1 = "";
         AV52usuariosId1 = "";
         AV22DynamicFiltersSelector2 = "";
         AV24SecUserName2 = "";
         AV53usuariosId2 = "";
         AV26DynamicFiltersSelector3 = "";
         AV28SecUserName3 = "";
         AV54usuariosId3 = "";
         AV35TFSecUserName_Sel = "";
         AV34TFSecUserName = "";
         AV56TFSecUserFullName_Sel = "";
         AV55TFSecUserFullName = "";
         AV58TFusuariosId_Sel = "";
         AV57TFusuariosId = "";
         AV60TFusuariosNombre_Sel = "";
         AV59TFusuariosNombre = "";
         AV62TFusuariosEstado_Sels = new GxSimpleCollection<string>();
         AV63TFusuariosEstado_Sel = "";
         AV65TFSecUserEstado_Sels = new GxSimpleCollection<string>();
         AV66TFSecUserEstado_Sel = "";
         AV68TFSecUserPassword_Sel = "";
         AV67TFSecUserPassword = "";
         AV38Session = context.GetSession();
         AV37ColumnsSelectorXML = "";
         AV36ColumnsSelector = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector(context);
         AV50ColumnsSelector_Column = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column(context);
         AV74Wwpbaseobjects_secuserwwds_1_filterfulltext = "";
         AV75Wwpbaseobjects_secuserwwds_2_dynamicfiltersselector1 = "";
         AV77Wwpbaseobjects_secuserwwds_4_secusername1 = "";
         AV78Wwpbaseobjects_secuserwwds_5_usuariosid1 = "";
         AV80Wwpbaseobjects_secuserwwds_7_dynamicfiltersselector2 = "";
         AV82Wwpbaseobjects_secuserwwds_9_secusername2 = "";
         AV83Wwpbaseobjects_secuserwwds_10_usuariosid2 = "";
         AV85Wwpbaseobjects_secuserwwds_12_dynamicfiltersselector3 = "";
         AV87Wwpbaseobjects_secuserwwds_14_secusername3 = "";
         AV88Wwpbaseobjects_secuserwwds_15_usuariosid3 = "";
         AV91Wwpbaseobjects_secuserwwds_18_tfsecusername = "";
         AV92Wwpbaseobjects_secuserwwds_19_tfsecusername_sel = "";
         AV93Wwpbaseobjects_secuserwwds_20_tfsecuserfullname = "";
         AV94Wwpbaseobjects_secuserwwds_21_tfsecuserfullname_sel = "";
         AV95Wwpbaseobjects_secuserwwds_22_tfusuariosid = "";
         AV96Wwpbaseobjects_secuserwwds_23_tfusuariosid_sel = "";
         AV97Wwpbaseobjects_secuserwwds_24_tfusuariosnombre = "";
         AV98Wwpbaseobjects_secuserwwds_25_tfusuariosnombre_sel = "";
         AV99Wwpbaseobjects_secuserwwds_26_tfusuariosestado_sels = new GxSimpleCollection<string>();
         AV100Wwpbaseobjects_secuserwwds_27_tfsecuserestado_sels = new GxSimpleCollection<string>();
         AV101Wwpbaseobjects_secuserwwds_28_tfsecuserpassword = "";
         AV102Wwpbaseobjects_secuserwwds_29_tfsecuserpassword_sel = "";
         lV74Wwpbaseobjects_secuserwwds_1_filterfulltext = "";
         lV77Wwpbaseobjects_secuserwwds_4_secusername1 = "";
         lV78Wwpbaseobjects_secuserwwds_5_usuariosid1 = "";
         lV82Wwpbaseobjects_secuserwwds_9_secusername2 = "";
         lV83Wwpbaseobjects_secuserwwds_10_usuariosid2 = "";
         lV87Wwpbaseobjects_secuserwwds_14_secusername3 = "";
         lV88Wwpbaseobjects_secuserwwds_15_usuariosid3 = "";
         lV91Wwpbaseobjects_secuserwwds_18_tfsecusername = "";
         lV93Wwpbaseobjects_secuserwwds_20_tfsecuserfullname = "";
         lV95Wwpbaseobjects_secuserwwds_22_tfusuariosid = "";
         lV97Wwpbaseobjects_secuserwwds_24_tfusuariosnombre = "";
         lV101Wwpbaseobjects_secuserwwds_28_tfsecuserpassword = "";
         A226usuariosEstado = "";
         A550SecUserEstado = "";
         A26SecUserName = "";
         A145usuariosId = "";
         A587SecUserFullName = "";
         A222usuariosNombre = "";
         A27SecUserPassword = "";
         P002O2_A27SecUserPassword = new string[] {""} ;
         P002O2_A222usuariosNombre = new string[] {""} ;
         P002O2_A145usuariosId = new string[] {""} ;
         P002O2_n145usuariosId = new bool[] {false} ;
         P002O2_A587SecUserFullName = new string[] {""} ;
         P002O2_A26SecUserName = new string[] {""} ;
         P002O2_A18SecUserId = new long[1] ;
         P002O2_A550SecUserEstado = new string[] {""} ;
         P002O2_n550SecUserEstado = new bool[] {false} ;
         P002O2_A226usuariosEstado = new string[] {""} ;
         AV39UserCustomValue = "";
         GXt_char2 = "";
         AV49ColumnsSelectorAux = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector(context);
         AV48GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV61TFusuariosEstado_SelsJson = "";
         AV64TFSecUserEstado_SelsJson = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.secuserwwexport__default(),
            new Object[][] {
                new Object[] {
               P002O2_A27SecUserPassword, P002O2_A222usuariosNombre, P002O2_A145usuariosId, P002O2_n145usuariosId, P002O2_A587SecUserFullName, P002O2_A26SecUserName, P002O2_A18SecUserId, P002O2_A550SecUserEstado, P002O2_n550SecUserEstado, P002O2_A226usuariosEstado
               }
            }
         );
         AV69Pgmname = "WWPBaseObjects.SecUserWWExport";
         /* GeneXus formulas. */
         AV69Pgmname = "WWPBaseObjects.SecUserWWExport";
      }

      private short AV19DynamicFiltersOperator1 ;
      private short AV23DynamicFiltersOperator2 ;
      private short AV27DynamicFiltersOperator3 ;
      private short GXt_int3 ;
      private short AV76Wwpbaseobjects_secuserwwds_3_dynamicfiltersoperator1 ;
      private short AV81Wwpbaseobjects_secuserwwds_8_dynamicfiltersoperator2 ;
      private short AV86Wwpbaseobjects_secuserwwds_13_dynamicfiltersoperator3 ;
      private short AV16OrderedBy ;
      private int AV13CellRow ;
      private int AV14FirstColumn ;
      private int AV15Random ;
      private int AV70GXV1 ;
      private int AV71GXV2 ;
      private int AV72GXV3 ;
      private int AV99Wwpbaseobjects_secuserwwds_26_tfusuariosestado_sels_Count ;
      private int AV100Wwpbaseobjects_secuserwwds_27_tfsecuserestado_sels_Count ;
      private int AV103GXV4 ;
      private int AV104GXV5 ;
      private long AV32TFSecUserId ;
      private long AV33TFSecUserId_To ;
      private long AV43i ;
      private long AV44VisibleColumnCount ;
      private long AV89Wwpbaseobjects_secuserwwds_16_tfsecuserid ;
      private long AV90Wwpbaseobjects_secuserwwds_17_tfsecuserid_to ;
      private long A18SecUserId ;
      private string AV69Pgmname ;
      private string GXKey ;
      private string GXEncryptionTmp ;
      private string AV52usuariosId1 ;
      private string AV53usuariosId2 ;
      private string AV54usuariosId3 ;
      private string AV58TFusuariosId_Sel ;
      private string AV57TFusuariosId ;
      private string AV60TFusuariosNombre_Sel ;
      private string AV59TFusuariosNombre ;
      private string AV63TFusuariosEstado_Sel ;
      private string AV66TFSecUserEstado_Sel ;
      private string AV78Wwpbaseobjects_secuserwwds_5_usuariosid1 ;
      private string AV83Wwpbaseobjects_secuserwwds_10_usuariosid2 ;
      private string AV88Wwpbaseobjects_secuserwwds_15_usuariosid3 ;
      private string AV95Wwpbaseobjects_secuserwwds_22_tfusuariosid ;
      private string AV96Wwpbaseobjects_secuserwwds_23_tfusuariosid_sel ;
      private string AV97Wwpbaseobjects_secuserwwds_24_tfusuariosnombre ;
      private string AV98Wwpbaseobjects_secuserwwds_25_tfusuariosnombre_sel ;
      private string lV78Wwpbaseobjects_secuserwwds_5_usuariosid1 ;
      private string lV83Wwpbaseobjects_secuserwwds_10_usuariosid2 ;
      private string lV88Wwpbaseobjects_secuserwwds_15_usuariosid3 ;
      private string lV95Wwpbaseobjects_secuserwwds_22_tfusuariosid ;
      private string lV97Wwpbaseobjects_secuserwwds_24_tfusuariosnombre ;
      private string A226usuariosEstado ;
      private string A550SecUserEstado ;
      private string A145usuariosId ;
      private string A222usuariosNombre ;
      private string GXt_char2 ;
      private bool AV8IsAuthorized ;
      private bool GXt_boolean1 ;
      private bool returnInSub ;
      private bool AV21DynamicFiltersEnabled2 ;
      private bool AV25DynamicFiltersEnabled3 ;
      private bool AV79Wwpbaseobjects_secuserwwds_6_dynamicfiltersenabled2 ;
      private bool AV84Wwpbaseobjects_secuserwwds_11_dynamicfiltersenabled3 ;
      private bool AV17OrderedDsc ;
      private bool n145usuariosId ;
      private bool n550SecUserEstado ;
      private string AV37ColumnsSelectorXML ;
      private string AV39UserCustomValue ;
      private string AV61TFusuariosEstado_SelsJson ;
      private string AV64TFSecUserEstado_SelsJson ;
      private string AV11Filename ;
      private string AV12ErrorMessage ;
      private string AV51FilterFullText ;
      private string AV18DynamicFiltersSelector1 ;
      private string AV20SecUserName1 ;
      private string AV22DynamicFiltersSelector2 ;
      private string AV24SecUserName2 ;
      private string AV26DynamicFiltersSelector3 ;
      private string AV28SecUserName3 ;
      private string AV35TFSecUserName_Sel ;
      private string AV34TFSecUserName ;
      private string AV56TFSecUserFullName_Sel ;
      private string AV55TFSecUserFullName ;
      private string AV68TFSecUserPassword_Sel ;
      private string AV67TFSecUserPassword ;
      private string AV74Wwpbaseobjects_secuserwwds_1_filterfulltext ;
      private string AV75Wwpbaseobjects_secuserwwds_2_dynamicfiltersselector1 ;
      private string AV77Wwpbaseobjects_secuserwwds_4_secusername1 ;
      private string AV80Wwpbaseobjects_secuserwwds_7_dynamicfiltersselector2 ;
      private string AV82Wwpbaseobjects_secuserwwds_9_secusername2 ;
      private string AV85Wwpbaseobjects_secuserwwds_12_dynamicfiltersselector3 ;
      private string AV87Wwpbaseobjects_secuserwwds_14_secusername3 ;
      private string AV91Wwpbaseobjects_secuserwwds_18_tfsecusername ;
      private string AV92Wwpbaseobjects_secuserwwds_19_tfsecusername_sel ;
      private string AV93Wwpbaseobjects_secuserwwds_20_tfsecuserfullname ;
      private string AV94Wwpbaseobjects_secuserwwds_21_tfsecuserfullname_sel ;
      private string AV101Wwpbaseobjects_secuserwwds_28_tfsecuserpassword ;
      private string AV102Wwpbaseobjects_secuserwwds_29_tfsecuserpassword_sel ;
      private string lV74Wwpbaseobjects_secuserwwds_1_filterfulltext ;
      private string lV77Wwpbaseobjects_secuserwwds_4_secusername1 ;
      private string lV82Wwpbaseobjects_secuserwwds_9_secusername2 ;
      private string lV87Wwpbaseobjects_secuserwwds_14_secusername3 ;
      private string lV91Wwpbaseobjects_secuserwwds_18_tfsecusername ;
      private string lV93Wwpbaseobjects_secuserwwds_20_tfsecuserfullname ;
      private string lV101Wwpbaseobjects_secuserwwds_28_tfsecuserpassword ;
      private string A26SecUserName ;
      private string A587SecUserFullName ;
      private string A27SecUserPassword ;
      private IGxSession AV38Session ;
      private ExcelDocumentI AV10ExcelDocument ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV47WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV30GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV31GridStateDynamicFilter ;
      private GxSimpleCollection<string> AV62TFusuariosEstado_Sels ;
      private GxSimpleCollection<string> AV65TFSecUserEstado_Sels ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector AV36ColumnsSelector ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column AV50ColumnsSelector_Column ;
      private GxSimpleCollection<string> AV99Wwpbaseobjects_secuserwwds_26_tfusuariosestado_sels ;
      private GxSimpleCollection<string> AV100Wwpbaseobjects_secuserwwds_27_tfsecuserestado_sels ;
      private IDataStoreProvider pr_default ;
      private string[] P002O2_A27SecUserPassword ;
      private string[] P002O2_A222usuariosNombre ;
      private string[] P002O2_A145usuariosId ;
      private bool[] P002O2_n145usuariosId ;
      private string[] P002O2_A587SecUserFullName ;
      private string[] P002O2_A26SecUserName ;
      private long[] P002O2_A18SecUserId ;
      private string[] P002O2_A550SecUserEstado ;
      private bool[] P002O2_n550SecUserEstado ;
      private string[] P002O2_A226usuariosEstado ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector AV49ColumnsSelectorAux ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV48GridStateFilterValue ;
      private string aP0_Filename ;
      private string aP1_ErrorMessage ;
   }

   public class secuserwwexport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P002O2( IGxContext context ,
                                             string A226usuariosEstado ,
                                             GxSimpleCollection<string> AV99Wwpbaseobjects_secuserwwds_26_tfusuariosestado_sels ,
                                             string A550SecUserEstado ,
                                             GxSimpleCollection<string> AV100Wwpbaseobjects_secuserwwds_27_tfsecuserestado_sels ,
                                             string AV75Wwpbaseobjects_secuserwwds_2_dynamicfiltersselector1 ,
                                             short AV76Wwpbaseobjects_secuserwwds_3_dynamicfiltersoperator1 ,
                                             string AV77Wwpbaseobjects_secuserwwds_4_secusername1 ,
                                             string AV78Wwpbaseobjects_secuserwwds_5_usuariosid1 ,
                                             bool AV79Wwpbaseobjects_secuserwwds_6_dynamicfiltersenabled2 ,
                                             string AV80Wwpbaseobjects_secuserwwds_7_dynamicfiltersselector2 ,
                                             short AV81Wwpbaseobjects_secuserwwds_8_dynamicfiltersoperator2 ,
                                             string AV82Wwpbaseobjects_secuserwwds_9_secusername2 ,
                                             string AV83Wwpbaseobjects_secuserwwds_10_usuariosid2 ,
                                             bool AV84Wwpbaseobjects_secuserwwds_11_dynamicfiltersenabled3 ,
                                             string AV85Wwpbaseobjects_secuserwwds_12_dynamicfiltersselector3 ,
                                             short AV86Wwpbaseobjects_secuserwwds_13_dynamicfiltersoperator3 ,
                                             string AV87Wwpbaseobjects_secuserwwds_14_secusername3 ,
                                             string AV88Wwpbaseobjects_secuserwwds_15_usuariosid3 ,
                                             long AV89Wwpbaseobjects_secuserwwds_16_tfsecuserid ,
                                             long AV90Wwpbaseobjects_secuserwwds_17_tfsecuserid_to ,
                                             string AV92Wwpbaseobjects_secuserwwds_19_tfsecusername_sel ,
                                             string AV91Wwpbaseobjects_secuserwwds_18_tfsecusername ,
                                             string AV94Wwpbaseobjects_secuserwwds_21_tfsecuserfullname_sel ,
                                             string AV93Wwpbaseobjects_secuserwwds_20_tfsecuserfullname ,
                                             string AV96Wwpbaseobjects_secuserwwds_23_tfusuariosid_sel ,
                                             string AV95Wwpbaseobjects_secuserwwds_22_tfusuariosid ,
                                             string AV98Wwpbaseobjects_secuserwwds_25_tfusuariosnombre_sel ,
                                             string AV97Wwpbaseobjects_secuserwwds_24_tfusuariosnombre ,
                                             int AV99Wwpbaseobjects_secuserwwds_26_tfusuariosestado_sels_Count ,
                                             int AV100Wwpbaseobjects_secuserwwds_27_tfsecuserestado_sels_Count ,
                                             string AV102Wwpbaseobjects_secuserwwds_29_tfsecuserpassword_sel ,
                                             string AV101Wwpbaseobjects_secuserwwds_28_tfsecuserpassword ,
                                             string A26SecUserName ,
                                             string A145usuariosId ,
                                             long A18SecUserId ,
                                             string A587SecUserFullName ,
                                             string A222usuariosNombre ,
                                             string A27SecUserPassword ,
                                             short AV16OrderedBy ,
                                             bool AV17OrderedDsc ,
                                             string AV74Wwpbaseobjects_secuserwwds_1_filterfulltext )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int4 = new short[24];
         Object[] GXv_Object5 = new Object[2];
         scmdbuf = "SELECT T1.[SecUserPassword], T2.[usuariosNombre], T1.[usuariosId], T1.[SecUserFullName], T1.[SecUserName], T1.[SecUserId], T1.[SecUserEstado], T2.[usuariosEstado] FROM ([SecUser] T1 LEFT JOIN [usuarios] T2 ON T2.[usuariosId] = T1.[usuariosId])";
         if ( ( StringUtil.StrCmp(AV75Wwpbaseobjects_secuserwwds_2_dynamicfiltersselector1, "SECUSERNAME") == 0 ) && ( AV76Wwpbaseobjects_secuserwwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV77Wwpbaseobjects_secuserwwds_4_secusername1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[SecUserName]) like UPPER(@lV77Wwpbaseobjects_secuserwwds_4_secusername1))");
         }
         else
         {
            GXv_int4[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV75Wwpbaseobjects_secuserwwds_2_dynamicfiltersselector1, "SECUSERNAME") == 0 ) && ( AV76Wwpbaseobjects_secuserwwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV77Wwpbaseobjects_secuserwwds_4_secusername1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[SecUserName]) like '%' + UPPER(@lV77Wwpbaseobjects_secuserwwds_4_secusername1))");
         }
         else
         {
            GXv_int4[1] = 1;
         }
         if ( ( StringUtil.StrCmp(AV75Wwpbaseobjects_secuserwwds_2_dynamicfiltersselector1, "USUARIOSID") == 0 ) && ( AV76Wwpbaseobjects_secuserwwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV78Wwpbaseobjects_secuserwwds_5_usuariosid1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[usuariosId]) like UPPER(@lV78Wwpbaseobjects_secuserwwds_5_usuariosid1))");
         }
         else
         {
            GXv_int4[2] = 1;
         }
         if ( ( StringUtil.StrCmp(AV75Wwpbaseobjects_secuserwwds_2_dynamicfiltersselector1, "USUARIOSID") == 0 ) && ( AV76Wwpbaseobjects_secuserwwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV78Wwpbaseobjects_secuserwwds_5_usuariosid1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[usuariosId]) like '%' + UPPER(@lV78Wwpbaseobjects_secuserwwds_5_usuariosid1))");
         }
         else
         {
            GXv_int4[3] = 1;
         }
         if ( AV79Wwpbaseobjects_secuserwwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV80Wwpbaseobjects_secuserwwds_7_dynamicfiltersselector2, "SECUSERNAME") == 0 ) && ( AV81Wwpbaseobjects_secuserwwds_8_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV82Wwpbaseobjects_secuserwwds_9_secusername2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[SecUserName]) like UPPER(@lV82Wwpbaseobjects_secuserwwds_9_secusername2))");
         }
         else
         {
            GXv_int4[4] = 1;
         }
         if ( AV79Wwpbaseobjects_secuserwwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV80Wwpbaseobjects_secuserwwds_7_dynamicfiltersselector2, "SECUSERNAME") == 0 ) && ( AV81Wwpbaseobjects_secuserwwds_8_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV82Wwpbaseobjects_secuserwwds_9_secusername2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[SecUserName]) like '%' + UPPER(@lV82Wwpbaseobjects_secuserwwds_9_secusername2))");
         }
         else
         {
            GXv_int4[5] = 1;
         }
         if ( AV79Wwpbaseobjects_secuserwwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV80Wwpbaseobjects_secuserwwds_7_dynamicfiltersselector2, "USUARIOSID") == 0 ) && ( AV81Wwpbaseobjects_secuserwwds_8_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV83Wwpbaseobjects_secuserwwds_10_usuariosid2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[usuariosId]) like UPPER(@lV83Wwpbaseobjects_secuserwwds_10_usuariosid2))");
         }
         else
         {
            GXv_int4[6] = 1;
         }
         if ( AV79Wwpbaseobjects_secuserwwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV80Wwpbaseobjects_secuserwwds_7_dynamicfiltersselector2, "USUARIOSID") == 0 ) && ( AV81Wwpbaseobjects_secuserwwds_8_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV83Wwpbaseobjects_secuserwwds_10_usuariosid2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[usuariosId]) like '%' + UPPER(@lV83Wwpbaseobjects_secuserwwds_10_usuariosid2))");
         }
         else
         {
            GXv_int4[7] = 1;
         }
         if ( AV84Wwpbaseobjects_secuserwwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV85Wwpbaseobjects_secuserwwds_12_dynamicfiltersselector3, "SECUSERNAME") == 0 ) && ( AV86Wwpbaseobjects_secuserwwds_13_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV87Wwpbaseobjects_secuserwwds_14_secusername3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[SecUserName]) like UPPER(@lV87Wwpbaseobjects_secuserwwds_14_secusername3))");
         }
         else
         {
            GXv_int4[8] = 1;
         }
         if ( AV84Wwpbaseobjects_secuserwwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV85Wwpbaseobjects_secuserwwds_12_dynamicfiltersselector3, "SECUSERNAME") == 0 ) && ( AV86Wwpbaseobjects_secuserwwds_13_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV87Wwpbaseobjects_secuserwwds_14_secusername3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[SecUserName]) like '%' + UPPER(@lV87Wwpbaseobjects_secuserwwds_14_secusername3))");
         }
         else
         {
            GXv_int4[9] = 1;
         }
         if ( AV84Wwpbaseobjects_secuserwwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV85Wwpbaseobjects_secuserwwds_12_dynamicfiltersselector3, "USUARIOSID") == 0 ) && ( AV86Wwpbaseobjects_secuserwwds_13_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV88Wwpbaseobjects_secuserwwds_15_usuariosid3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[usuariosId]) like UPPER(@lV88Wwpbaseobjects_secuserwwds_15_usuariosid3))");
         }
         else
         {
            GXv_int4[10] = 1;
         }
         if ( AV84Wwpbaseobjects_secuserwwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV85Wwpbaseobjects_secuserwwds_12_dynamicfiltersselector3, "USUARIOSID") == 0 ) && ( AV86Wwpbaseobjects_secuserwwds_13_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV88Wwpbaseobjects_secuserwwds_15_usuariosid3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[usuariosId]) like '%' + UPPER(@lV88Wwpbaseobjects_secuserwwds_15_usuariosid3))");
         }
         else
         {
            GXv_int4[11] = 1;
         }
         if ( ! (0==AV89Wwpbaseobjects_secuserwwds_16_tfsecuserid) )
         {
            AddWhere(sWhereString, "(T1.[SecUserId] >= @AV89Wwpbaseobjects_secuserwwds_16_tfsecuserid)");
         }
         else
         {
            GXv_int4[12] = 1;
         }
         if ( ! (0==AV90Wwpbaseobjects_secuserwwds_17_tfsecuserid_to) )
         {
            AddWhere(sWhereString, "(T1.[SecUserId] <= @AV90Wwpbaseobjects_secuserwwds_17_tfsecuserid_to)");
         }
         else
         {
            GXv_int4[13] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV92Wwpbaseobjects_secuserwwds_19_tfsecusername_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV91Wwpbaseobjects_secuserwwds_18_tfsecusername)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[SecUserName]) like UPPER(@lV91Wwpbaseobjects_secuserwwds_18_tfsecusername))");
         }
         else
         {
            GXv_int4[14] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV92Wwpbaseobjects_secuserwwds_19_tfsecusername_sel)) && ! ( StringUtil.StrCmp(AV92Wwpbaseobjects_secuserwwds_19_tfsecusername_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[SecUserName] = @AV92Wwpbaseobjects_secuserwwds_19_tfsecusername_sel)");
         }
         else
         {
            GXv_int4[15] = 1;
         }
         if ( StringUtil.StrCmp(AV92Wwpbaseobjects_secuserwwds_19_tfsecusername_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[SecUserName] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV94Wwpbaseobjects_secuserwwds_21_tfsecuserfullname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV93Wwpbaseobjects_secuserwwds_20_tfsecuserfullname)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[SecUserFullName]) like UPPER(@lV93Wwpbaseobjects_secuserwwds_20_tfsecuserfullname))");
         }
         else
         {
            GXv_int4[16] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV94Wwpbaseobjects_secuserwwds_21_tfsecuserfullname_sel)) && ! ( StringUtil.StrCmp(AV94Wwpbaseobjects_secuserwwds_21_tfsecuserfullname_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[SecUserFullName] = @AV94Wwpbaseobjects_secuserwwds_21_tfsecuserfullname_sel)");
         }
         else
         {
            GXv_int4[17] = 1;
         }
         if ( StringUtil.StrCmp(AV94Wwpbaseobjects_secuserwwds_21_tfsecuserfullname_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[SecUserFullName] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV96Wwpbaseobjects_secuserwwds_23_tfusuariosid_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV95Wwpbaseobjects_secuserwwds_22_tfusuariosid)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[usuariosId]) like UPPER(@lV95Wwpbaseobjects_secuserwwds_22_tfusuariosid))");
         }
         else
         {
            GXv_int4[18] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV96Wwpbaseobjects_secuserwwds_23_tfusuariosid_sel)) && ! ( StringUtil.StrCmp(AV96Wwpbaseobjects_secuserwwds_23_tfusuariosid_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[usuariosId] = @AV96Wwpbaseobjects_secuserwwds_23_tfusuariosid_sel)");
         }
         else
         {
            GXv_int4[19] = 1;
         }
         if ( StringUtil.StrCmp(AV96Wwpbaseobjects_secuserwwds_23_tfusuariosid_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.[usuariosId] IS NULL or (T1.[usuariosId] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV98Wwpbaseobjects_secuserwwds_25_tfusuariosnombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV97Wwpbaseobjects_secuserwwds_24_tfusuariosnombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[usuariosNombre]) like UPPER(@lV97Wwpbaseobjects_secuserwwds_24_tfusuariosnombre))");
         }
         else
         {
            GXv_int4[20] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV98Wwpbaseobjects_secuserwwds_25_tfusuariosnombre_sel)) && ! ( StringUtil.StrCmp(AV98Wwpbaseobjects_secuserwwds_25_tfusuariosnombre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.[usuariosNombre] = @AV98Wwpbaseobjects_secuserwwds_25_tfusuariosnombre_sel)");
         }
         else
         {
            GXv_int4[21] = 1;
         }
         if ( StringUtil.StrCmp(AV98Wwpbaseobjects_secuserwwds_25_tfusuariosnombre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T2.[usuariosNombre] IS NULL or (T2.[usuariosNombre] = ''))");
         }
         if ( AV99Wwpbaseobjects_secuserwwds_26_tfusuariosestado_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV99Wwpbaseobjects_secuserwwds_26_tfusuariosestado_sels, "T2.[usuariosEstado] IN (", ")")+")");
         }
         if ( AV100Wwpbaseobjects_secuserwwds_27_tfsecuserestado_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV100Wwpbaseobjects_secuserwwds_27_tfsecuserestado_sels, "T1.[SecUserEstado] IN (", ")")+")");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV102Wwpbaseobjects_secuserwwds_29_tfsecuserpassword_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV101Wwpbaseobjects_secuserwwds_28_tfsecuserpassword)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[SecUserPassword]) like UPPER(@lV101Wwpbaseobjects_secuserwwds_28_tfsecuserpassword))");
         }
         else
         {
            GXv_int4[22] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV102Wwpbaseobjects_secuserwwds_29_tfsecuserpassword_sel)) && ! ( StringUtil.StrCmp(AV102Wwpbaseobjects_secuserwwds_29_tfsecuserpassword_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[SecUserPassword] = @AV102Wwpbaseobjects_secuserwwds_29_tfsecuserpassword_sel)");
         }
         else
         {
            GXv_int4[23] = 1;
         }
         if ( StringUtil.StrCmp(AV102Wwpbaseobjects_secuserwwds_29_tfsecuserpassword_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[SecUserPassword] = ''))");
         }
         scmdbuf += sWhereString;
         if ( ( AV16OrderedBy == 1 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[SecUserName]";
         }
         else if ( ( AV16OrderedBy == 1 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[SecUserName] DESC";
         }
         else if ( ( AV16OrderedBy == 2 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[SecUserId]";
         }
         else if ( ( AV16OrderedBy == 2 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[SecUserId] DESC";
         }
         else if ( ( AV16OrderedBy == 3 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[SecUserFullName]";
         }
         else if ( ( AV16OrderedBy == 3 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[SecUserFullName] DESC";
         }
         else if ( ( AV16OrderedBy == 4 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[usuariosId]";
         }
         else if ( ( AV16OrderedBy == 4 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[usuariosId] DESC";
         }
         else if ( ( AV16OrderedBy == 5 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY T2.[usuariosNombre]";
         }
         else if ( ( AV16OrderedBy == 5 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T2.[usuariosNombre] DESC";
         }
         else if ( ( AV16OrderedBy == 6 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY T2.[usuariosEstado]";
         }
         else if ( ( AV16OrderedBy == 6 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T2.[usuariosEstado] DESC";
         }
         else if ( ( AV16OrderedBy == 7 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[SecUserEstado]";
         }
         else if ( ( AV16OrderedBy == 7 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[SecUserEstado] DESC";
         }
         else if ( ( AV16OrderedBy == 8 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[SecUserPassword]";
         }
         else if ( ( AV16OrderedBy == 8 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[SecUserPassword] DESC";
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
                     return conditional_P002O2(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (GxSimpleCollection<string>)dynConstraints[3] , (string)dynConstraints[4] , (short)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (bool)dynConstraints[8] , (string)dynConstraints[9] , (short)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (bool)dynConstraints[13] , (string)dynConstraints[14] , (short)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (long)dynConstraints[18] , (long)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (string)dynConstraints[25] , (string)dynConstraints[26] , (string)dynConstraints[27] , (int)dynConstraints[28] , (int)dynConstraints[29] , (string)dynConstraints[30] , (string)dynConstraints[31] , (string)dynConstraints[32] , (string)dynConstraints[33] , (long)dynConstraints[34] , (string)dynConstraints[35] , (string)dynConstraints[36] , (string)dynConstraints[37] , (short)dynConstraints[38] , (bool)dynConstraints[39] , (string)dynConstraints[40] );
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
          Object[] prmP002O2;
          prmP002O2 = new Object[] {
          new ParDef("@lV77Wwpbaseobjects_secuserwwds_4_secusername1",GXType.VarChar,100,0) ,
          new ParDef("@lV77Wwpbaseobjects_secuserwwds_4_secusername1",GXType.VarChar,100,0) ,
          new ParDef("@lV78Wwpbaseobjects_secuserwwds_5_usuariosid1",GXType.Char,20,0) ,
          new ParDef("@lV78Wwpbaseobjects_secuserwwds_5_usuariosid1",GXType.Char,20,0) ,
          new ParDef("@lV82Wwpbaseobjects_secuserwwds_9_secusername2",GXType.VarChar,100,0) ,
          new ParDef("@lV82Wwpbaseobjects_secuserwwds_9_secusername2",GXType.VarChar,100,0) ,
          new ParDef("@lV83Wwpbaseobjects_secuserwwds_10_usuariosid2",GXType.Char,20,0) ,
          new ParDef("@lV83Wwpbaseobjects_secuserwwds_10_usuariosid2",GXType.Char,20,0) ,
          new ParDef("@lV87Wwpbaseobjects_secuserwwds_14_secusername3",GXType.VarChar,100,0) ,
          new ParDef("@lV87Wwpbaseobjects_secuserwwds_14_secusername3",GXType.VarChar,100,0) ,
          new ParDef("@lV88Wwpbaseobjects_secuserwwds_15_usuariosid3",GXType.Char,20,0) ,
          new ParDef("@lV88Wwpbaseobjects_secuserwwds_15_usuariosid3",GXType.Char,20,0) ,
          new ParDef("@AV89Wwpbaseobjects_secuserwwds_16_tfsecuserid",GXType.Decimal,10,0) ,
          new ParDef("@AV90Wwpbaseobjects_secuserwwds_17_tfsecuserid_to",GXType.Decimal,10,0) ,
          new ParDef("@lV91Wwpbaseobjects_secuserwwds_18_tfsecusername",GXType.VarChar,100,0) ,
          new ParDef("@AV92Wwpbaseobjects_secuserwwds_19_tfsecusername_sel",GXType.NVarChar,100,0) ,
          new ParDef("@lV93Wwpbaseobjects_secuserwwds_20_tfsecuserfullname",GXType.VarChar,120,0) ,
          new ParDef("@AV94Wwpbaseobjects_secuserwwds_21_tfsecuserfullname_sel",GXType.NVarChar,120,0) ,
          new ParDef("@lV95Wwpbaseobjects_secuserwwds_22_tfusuariosid",GXType.Char,20,0) ,
          new ParDef("@AV96Wwpbaseobjects_secuserwwds_23_tfusuariosid_sel",GXType.NChar,20,0) ,
          new ParDef("@lV97Wwpbaseobjects_secuserwwds_24_tfusuariosnombre",GXType.Char,80,0) ,
          new ParDef("@AV98Wwpbaseobjects_secuserwwds_25_tfusuariosnombre_sel",GXType.NChar,80,0) ,
          new ParDef("@lV101Wwpbaseobjects_secuserwwds_28_tfsecuserpassword",GXType.VarChar,100,0) ,
          new ParDef("@AV102Wwpbaseobjects_secuserwwds_29_tfsecuserpassword_sel",GXType.NVarChar,100,0)
          };
          def= new CursorDef[] {
              new CursorDef("P002O2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP002O2,100, GxCacheFrequency.OFF ,true,false )
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
                ((bool[]) buf[3])[0] = rslt.wasNull(3);
                ((string[]) buf[4])[0] = rslt.getVarchar(4);
                ((string[]) buf[5])[0] = rslt.getVarchar(5);
                ((long[]) buf[6])[0] = rslt.getLong(6);
                ((string[]) buf[7])[0] = rslt.getString(7, 3);
                ((bool[]) buf[8])[0] = rslt.wasNull(7);
                ((string[]) buf[9])[0] = rslt.getString(8, 3);
                return;
       }
    }

 }

}

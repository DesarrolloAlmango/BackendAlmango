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
using GeneXus.Printer;
using GeneXus.XML;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Threading;
using System.Xml.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Runtime.Serialization;
namespace GeneXus.Programs.wwpbaseobjects {
   public class asecfunctionalitywwexportreport : GXWebProcedure, System.Web.SessionState.IRequiresSessionState
   {
      public override void webExecute( )
      {
         context.SetDefaultTheme("WorkWithPlusDS", true);
         initialize();
         GXKey = Crypto.GetSiteKey( );
         if ( nGotPars == 0 )
         {
            entryPointCalled = false;
            gxfirstwebparm = GetNextPar( );
         }
         if ( GxWebError == 0 )
         {
            ExecutePrivate();
         }
         cleanup();
      }

      public asecfunctionalitywwexportreport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public asecfunctionalitywwexportreport( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( )
      {
         initialize();
         ExecutePrivate();
      }

      public void executeSubmit( )
      {
         SubmitImpl();
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         M_top = 0;
         M_bot = 6;
         P_lines = (int)(66-M_bot);
         getPrinter().GxClearAttris() ;
         add_metrics( ) ;
         lineHeight = 15;
         PrtOffset = 0;
         gxXPage = 100;
         gxYPage = 100;
         setOutputFileName("SecFunctionalityWWExportReport");
         setOutputType("PDF");
         try
         {
            Gx_out = "FIL" ;
            if (!initPrinter (Gx_out, gxXPage, gxYPage, "GXPRN.INI", "", "", 2, 1, 1, 15840, 12240, 0, 1, 1, 0, 1, 1) )
            {
               cleanup();
               return;
            }
            getPrinter().setModal(false) ;
            P_lines = (int)(gxYPage-(lineHeight*6));
            Gx_line = (int)(P_lines+1);
            getPrinter().setPageLines(P_lines);
            getPrinter().setLineHeight(lineHeight);
            getPrinter().setM_top(M_top);
            getPrinter().setM_bot(M_bot);
            GXt_boolean1 = AV8IsAuthorized;
            new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWSecFunctionality", out  GXt_boolean1) ;
            AV8IsAuthorized = GXt_boolean1;
            if ( ! AV8IsAuthorized )
            {
               GXKey = Crypto.GetSiteKey( );
               GXEncryptionTmp = "wwpbaseobjects.notauthorized.aspx"+UrlEncode(StringUtil.RTrim(AV49Pgmname));
               CallWebObject(formatLink("wwpbaseobjects.notauthorized.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
               context.wjLocDisableFrm = 1;
            }
            if ( AV8IsAuthorized )
            {
               new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV26WWPContext) ;
               /* Execute user subroutine: 'LOADGRIDSTATE' */
               S151 ();
               if ( returnInSub )
               {
                  cleanup();
                  if (true) return;
               }
               AV46Title = context.GetMessage( "Lista de Functionality", "");
               /* Execute user subroutine: 'PRINTFILTERS' */
               S111 ();
               if ( returnInSub )
               {
                  cleanup();
                  if (true) return;
               }
               /* Execute user subroutine: 'PRINTCOLUMNTITLES' */
               S121 ();
               if ( returnInSub )
               {
                  cleanup();
                  if (true) return;
               }
               /* Execute user subroutine: 'PRINTDATA' */
               S131 ();
               if ( returnInSub )
               {
                  cleanup();
                  if (true) return;
               }
               /* Execute user subroutine: 'PRINTFOOTER' */
               S171 ();
               if ( returnInSub )
               {
                  cleanup();
                  if (true) return;
               }
            }
            /* Print footer for last page */
            ToSkip = (int)(P_lines+1);
            H2E0( true, 0) ;
         }
         catch ( GeneXus.Printer.ProcessInterruptedException  )
         {
         }
         finally
         {
            /* Close printer file */
            try
            {
               getPrinter().GxEndPage() ;
               getPrinter().GxEndDocument() ;
            }
            catch ( GeneXus.Printer.ProcessInterruptedException  )
            {
            }
            endPrinter();
         }
         if ( context.WillRedirect( ) )
         {
            context.Redirect( context.wjLoc );
            context.wjLoc = "";
         }
         cleanup();
      }

      protected void S111( )
      {
         /* 'PRINTFILTERS' Routine */
         returnInSub = false;
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV48FilterFullText)) )
         {
            H2E0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "WWP_FullTextFilterDescription", ""), 25, Gx_line+0, 129, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV48FilterFullText, "")), 129, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV19TFSecFunctionalityKey_Sel)) )
         {
            AV35TempBoolean = (bool)(((StringUtil.StrCmp(AV19TFSecFunctionalityKey_Sel, "<#Empty#>")==0)));
            AV19TFSecFunctionalityKey_Sel = (AV35TempBoolean ? context.GetMessage( "WWP_TitleFilter_EmptyOption", "") : AV19TFSecFunctionalityKey_Sel);
            H2E0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Key", ""), 25, Gx_line+0, 129, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV19TFSecFunctionalityKey_Sel, "")), 129, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV19TFSecFunctionalityKey_Sel = (AV35TempBoolean ? "<#Empty#>" : AV19TFSecFunctionalityKey_Sel);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV18TFSecFunctionalityKey)) )
            {
               H2E0( false, 20) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(context.GetMessage( "Key", ""), 25, Gx_line+0, 129, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV18TFSecFunctionalityKey, "")), 129, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV21TFSecFunctionalityDescription_Sel)) )
         {
            AV35TempBoolean = (bool)(((StringUtil.StrCmp(AV21TFSecFunctionalityDescription_Sel, "<#Empty#>")==0)));
            AV21TFSecFunctionalityDescription_Sel = (AV35TempBoolean ? context.GetMessage( "WWP_TitleFilter_EmptyOption", "") : AV21TFSecFunctionalityDescription_Sel);
            H2E0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Description", ""), 25, Gx_line+0, 129, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV21TFSecFunctionalityDescription_Sel, "")), 129, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV21TFSecFunctionalityDescription_Sel = (AV35TempBoolean ? "<#Empty#>" : AV21TFSecFunctionalityDescription_Sel);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV20TFSecFunctionalityDescription)) )
            {
               H2E0( false, 20) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(context.GetMessage( "Description", ""), 25, Gx_line+0, 129, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV20TFSecFunctionalityDescription, "")), 129, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
         AV33TFSecFunctionalityType_Sels.FromJSonString(AV31TFSecFunctionalityType_SelsJson, null);
         if ( ! ( AV33TFSecFunctionalityType_Sels.Count == 0 ) )
         {
            AV34i = 1;
            AV52GXV1 = 1;
            while ( AV52GXV1 <= AV33TFSecFunctionalityType_Sels.Count )
            {
               AV22TFSecFunctionalityType_Sel = (short)(AV33TFSecFunctionalityType_Sels.GetNumeric(AV52GXV1));
               if ( AV34i == 1 )
               {
                  AV32TFSecFunctionalityType_SelDscs = "";
               }
               else
               {
                  AV32TFSecFunctionalityType_SelDscs += ", ";
               }
               AV25FilterTFSecFunctionalityType_SelValueDescription = context.GetMessage( gxdomainwwpsecfunctionalitytypes.getDescription(context,AV22TFSecFunctionalityType_Sel), "");
               AV32TFSecFunctionalityType_SelDscs += AV25FilterTFSecFunctionalityType_SelValueDescription;
               AV34i = (long)(AV34i+1);
               AV52GXV1 = (int)(AV52GXV1+1);
            }
            H2E0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Type", ""), 25, Gx_line+0, 129, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV32TFSecFunctionalityType_SelDscs, "")), 129, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV24TFSecParentFunctionalityDescription_Sel)) )
         {
            AV35TempBoolean = (bool)(((StringUtil.StrCmp(AV24TFSecParentFunctionalityDescription_Sel, "<#Empty#>")==0)));
            AV24TFSecParentFunctionalityDescription_Sel = (AV35TempBoolean ? context.GetMessage( "WWP_TitleFilter_EmptyOption", "") : AV24TFSecParentFunctionalityDescription_Sel);
            H2E0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Parent Functionality", ""), 25, Gx_line+0, 129, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV24TFSecParentFunctionalityDescription_Sel, "")), 129, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV24TFSecParentFunctionalityDescription_Sel = (AV35TempBoolean ? "<#Empty#>" : AV24TFSecParentFunctionalityDescription_Sel);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV23TFSecParentFunctionalityDescription)) )
            {
               H2E0( false, 20) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(context.GetMessage( "Parent Functionality", ""), 25, Gx_line+0, 129, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV23TFSecParentFunctionalityDescription, "")), 129, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
      }

      protected void S121( )
      {
         /* 'PRINTCOLUMNTITLES' Routine */
         returnInSub = false;
         H2E0( false, 22) ;
         getPrinter().GxDrawLine(25, Gx_line+21, 789, Gx_line+21, 2, 8, 160, 134, 0) ;
         Gx_OldLine = Gx_line;
         Gx_line = (int)(Gx_line+22);
         H2E0( false, 37) ;
         getPrinter().GxAttris("Microsoft Sans Serif", 9, false, false, false, false, 0, 8, 160, 134, 0, 255, 255, 255) ;
         getPrinter().GxDrawText(context.GetMessage( "Key", ""), 30, Gx_line+10, 216, Gx_line+27, 0, 0, 0, 0) ;
         getPrinter().GxDrawText(context.GetMessage( "Description", ""), 220, Gx_line+10, 406, Gx_line+27, 0, 0, 0, 0) ;
         getPrinter().GxDrawText(context.GetMessage( "Type", ""), 410, Gx_line+10, 596, Gx_line+27, 0, 0, 0, 0) ;
         getPrinter().GxDrawText(context.GetMessage( "Parent Functionality", ""), 600, Gx_line+10, 787, Gx_line+27, 0, 0, 0, 0) ;
         Gx_OldLine = Gx_line;
         Gx_line = (int)(Gx_line+37);
      }

      protected void S131( )
      {
         /* 'PRINTDATA' Routine */
         returnInSub = false;
         AV54Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext = AV48FilterFullText;
         AV55Wwpbaseobjects_secfunctionalitywwds_2_tfsecfunctionalitykey = AV18TFSecFunctionalityKey;
         AV56Wwpbaseobjects_secfunctionalitywwds_3_tfsecfunctionalitykey_sel = AV19TFSecFunctionalityKey_Sel;
         AV57Wwpbaseobjects_secfunctionalitywwds_4_tfsecfunctionalitydescription = AV20TFSecFunctionalityDescription;
         AV58Wwpbaseobjects_secfunctionalitywwds_5_tfsecfunctionalitydescription_sel = AV21TFSecFunctionalityDescription_Sel;
         AV59Wwpbaseobjects_secfunctionalitywwds_6_tfsecfunctionalitytype_sels = AV33TFSecFunctionalityType_Sels;
         AV60Wwpbaseobjects_secfunctionalitywwds_7_tfsecparentfunctionalitydescription = AV23TFSecParentFunctionalityDescription;
         AV61Wwpbaseobjects_secfunctionalitywwds_8_tfsecparentfunctionalitydescription_sel = AV24TFSecParentFunctionalityDescription_Sel;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A21SecFunctionalityType ,
                                              AV59Wwpbaseobjects_secfunctionalitywwds_6_tfsecfunctionalitytype_sels ,
                                              AV56Wwpbaseobjects_secfunctionalitywwds_3_tfsecfunctionalitykey_sel ,
                                              AV55Wwpbaseobjects_secfunctionalitywwds_2_tfsecfunctionalitykey ,
                                              AV58Wwpbaseobjects_secfunctionalitywwds_5_tfsecfunctionalitydescription_sel ,
                                              AV57Wwpbaseobjects_secfunctionalitywwds_4_tfsecfunctionalitydescription ,
                                              AV59Wwpbaseobjects_secfunctionalitywwds_6_tfsecfunctionalitytype_sels.Count ,
                                              AV61Wwpbaseobjects_secfunctionalitywwds_8_tfsecparentfunctionalitydescription_sel ,
                                              AV60Wwpbaseobjects_secfunctionalitywwds_7_tfsecparentfunctionalitydescription ,
                                              A15SecFunctionalityKey ,
                                              A20SecFunctionalityDescription ,
                                              A23SecParentFunctionalityDescript ,
                                              AV10OrderedBy ,
                                              AV11OrderedDsc ,
                                              AV54Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.INT, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV55Wwpbaseobjects_secfunctionalitywwds_2_tfsecfunctionalitykey = StringUtil.Concat( StringUtil.RTrim( AV55Wwpbaseobjects_secfunctionalitywwds_2_tfsecfunctionalitykey), "%", "");
         lV57Wwpbaseobjects_secfunctionalitywwds_4_tfsecfunctionalitydescription = StringUtil.Concat( StringUtil.RTrim( AV57Wwpbaseobjects_secfunctionalitywwds_4_tfsecfunctionalitydescription), "%", "");
         lV60Wwpbaseobjects_secfunctionalitywwds_7_tfsecparentfunctionalitydescription = StringUtil.Concat( StringUtil.RTrim( AV60Wwpbaseobjects_secfunctionalitywwds_7_tfsecparentfunctionalitydescription), "%", "");
         /* Using cursor P002E2 */
         pr_default.execute(0, new Object[] {lV55Wwpbaseobjects_secfunctionalitywwds_2_tfsecfunctionalitykey, AV56Wwpbaseobjects_secfunctionalitywwds_3_tfsecfunctionalitykey_sel, lV57Wwpbaseobjects_secfunctionalitywwds_4_tfsecfunctionalitydescription, AV58Wwpbaseobjects_secfunctionalitywwds_5_tfsecfunctionalitydescription_sel, lV60Wwpbaseobjects_secfunctionalitywwds_7_tfsecparentfunctionalitydescription, AV61Wwpbaseobjects_secfunctionalitywwds_8_tfsecparentfunctionalitydescription_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A14SecParentFunctionalityId = P002E2_A14SecParentFunctionalityId[0];
            n14SecParentFunctionalityId = P002E2_n14SecParentFunctionalityId[0];
            A23SecParentFunctionalityDescript = P002E2_A23SecParentFunctionalityDescript[0];
            A20SecFunctionalityDescription = P002E2_A20SecFunctionalityDescription[0];
            A15SecFunctionalityKey = P002E2_A15SecFunctionalityKey[0];
            A21SecFunctionalityType = P002E2_A21SecFunctionalityType[0];
            A13SecFunctionalityId = P002E2_A13SecFunctionalityId[0];
            A23SecParentFunctionalityDescript = P002E2_A23SecParentFunctionalityDescript[0];
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV54Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext)) || ( ( StringUtil.Like( StringUtil.Upper( A15SecFunctionalityKey) , StringUtil.PadR( "%" + StringUtil.Upper( AV54Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A20SecFunctionalityDescription) , StringUtil.PadR( "%" + StringUtil.Upper( AV54Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( context.GetMessage( "mode", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV54Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( A21SecFunctionalityType == 1 ) ) || ( StringUtil.Like( context.GetMessage( "action", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV54Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( A21SecFunctionalityType == 2 ) ) || ( StringUtil.Like( context.GetMessage( "tab", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV54Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( A21SecFunctionalityType == 3 ) ) || ( StringUtil.Like( context.GetMessage( "object", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV54Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( A21SecFunctionalityType == 4 ) ) || ( StringUtil.Like( context.GetMessage( "attribute", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV54Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( A21SecFunctionalityType == 5 ) ) || ( StringUtil.Like( StringUtil.Upper( A23SecParentFunctionalityDescript) , StringUtil.PadR( "%" + StringUtil.Upper( AV54Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) ) )
            {
               AV17SecFunctionalityTypeDescription = context.GetMessage( gxdomainwwpsecfunctionalitytypes.getDescription(context,A21SecFunctionalityType), "");
               /* Execute user subroutine: 'BEFOREPRINTLINE' */
               S144 ();
               if ( returnInSub )
               {
                  pr_default.close(0);
                  returnInSub = true;
                  if (true) return;
               }
               H2E0( false, 36) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A15SecFunctionalityKey, "")), 30, Gx_line+10, 216, Gx_line+25, 0+16, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A20SecFunctionalityDescription, "")), 220, Gx_line+10, 406, Gx_line+25, 0+16, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV17SecFunctionalityTypeDescription, "")), 410, Gx_line+10, 596, Gx_line+25, 0+16, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A23SecParentFunctionalityDescript, "")), 600, Gx_line+10, 787, Gx_line+25, 0+16, 0, 0, 0) ;
               getPrinter().GxDrawLine(28, Gx_line+35, 789, Gx_line+35, 1, 220, 220, 220, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+36);
               /* Execute user subroutine: 'AFTERPRINTLINE' */
               S161 ();
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

      protected void S151( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV27Session.Get("WWPBaseObjects.SecFunctionalityWWGridState"), "") == 0 )
         {
            AV29GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "WWPBaseObjects.SecFunctionalityWWGridState"), null, "", "");
         }
         else
         {
            AV29GridState.FromXml(AV27Session.Get("WWPBaseObjects.SecFunctionalityWWGridState"), null, "", "");
         }
         AV10OrderedBy = AV29GridState.gxTpr_Orderedby;
         AV11OrderedDsc = AV29GridState.gxTpr_Ordereddsc;
         AV62GXV2 = 1;
         while ( AV62GXV2 <= AV29GridState.gxTpr_Filtervalues.Count )
         {
            AV30GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV29GridState.gxTpr_Filtervalues.Item(AV62GXV2));
            if ( StringUtil.StrCmp(AV30GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV48FilterFullText = AV30GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV30GridStateFilterValue.gxTpr_Name, "TFSECFUNCTIONALITYKEY") == 0 )
            {
               AV18TFSecFunctionalityKey = AV30GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV30GridStateFilterValue.gxTpr_Name, "TFSECFUNCTIONALITYKEY_SEL") == 0 )
            {
               AV19TFSecFunctionalityKey_Sel = AV30GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV30GridStateFilterValue.gxTpr_Name, "TFSECFUNCTIONALITYDESCRIPTION") == 0 )
            {
               AV20TFSecFunctionalityDescription = AV30GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV30GridStateFilterValue.gxTpr_Name, "TFSECFUNCTIONALITYDESCRIPTION_SEL") == 0 )
            {
               AV21TFSecFunctionalityDescription_Sel = AV30GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV30GridStateFilterValue.gxTpr_Name, "TFSECFUNCTIONALITYTYPE_SEL") == 0 )
            {
               AV31TFSecFunctionalityType_SelsJson = AV30GridStateFilterValue.gxTpr_Value;
               AV33TFSecFunctionalityType_Sels.FromJSonString(AV31TFSecFunctionalityType_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV30GridStateFilterValue.gxTpr_Name, "TFSECPARENTFUNCTIONALITYDESCRIPTION") == 0 )
            {
               AV23TFSecParentFunctionalityDescription = AV30GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV30GridStateFilterValue.gxTpr_Name, "TFSECPARENTFUNCTIONALITYDESCRIPTION_SEL") == 0 )
            {
               AV24TFSecParentFunctionalityDescription_Sel = AV30GridStateFilterValue.gxTpr_Value;
            }
            AV62GXV2 = (int)(AV62GXV2+1);
         }
      }

      protected void S144( )
      {
         /* 'BEFOREPRINTLINE' Routine */
         returnInSub = false;
      }

      protected void S161( )
      {
         /* 'AFTERPRINTLINE' Routine */
         returnInSub = false;
      }

      protected void S171( )
      {
         /* 'PRINTFOOTER' Routine */
         returnInSub = false;
      }

      protected void H2E0( bool bFoot ,
                           int Inc )
      {
         /* Skip the required number of lines */
         while ( ( ToSkip > 0 ) || ( Gx_line + Inc > P_lines ) )
         {
            if ( Gx_line + Inc >= P_lines )
            {
               if ( Gx_page > 0 )
               {
                  /* Print footers */
                  Gx_line = P_lines;
                  AV44PageInfo = context.GetMessage( "Page: ", "") + StringUtil.Trim( StringUtil.Str( (decimal)(Gx_page), 6, 0));
                  AV41DateInfo = context.GetMessage( "Date: ", "") + context.localUtil.Format( Gx_date, "99/99/99");
                  getPrinter().GxDrawRect(0, Gx_line+5, 819, Gx_line+40, 1, 0, 0, 0, 1, 8, 160, 134, 1, 1, 1, 1, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV44PageInfo, "")), 30, Gx_line+15, 409, Gx_line+30, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV41DateInfo, "")), 409, Gx_line+15, 789, Gx_line+30, 2, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+40);
                  getPrinter().GxEndPage() ;
                  if ( bFoot )
                  {
                     return  ;
                  }
               }
               ToSkip = 0;
               Gx_line = 0;
               Gx_page = (int)(Gx_page+1);
               /* Skip Margin Top Lines */
               Gx_line = (int)(Gx_line+(M_top*lineHeight));
               /* Print headers */
               getPrinter().GxStartPage() ;
               AV39AppName = context.GetMessage( "DVelop Software Solutions", "");
               AV45Phone = "+1 550 8923";
               AV43Mail = "info@mail.com";
               AV47Website = "http://www.web.com";
               AV36AddressLine1 = "French Boulevard 2859";
               AV37AddressLine2 = "Downtown";
               AV38AddressLine3 = "Paris, France";
               getPrinter().GxDrawRect(0, Gx_line+0, 819, Gx_line+108, 1, 0, 0, 0, 1, 8, 160, 134, 1, 1, 1, 1, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV39AppName, "")), 30, Gx_line+30, 283, Gx_line+45, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 20, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV46Title, "")), 30, Gx_line+45, 283, Gx_line+78, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV45Phone, "")), 283, Gx_line+30, 536, Gx_line+46, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV43Mail, "")), 283, Gx_line+46, 536, Gx_line+62, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV47Website, "")), 283, Gx_line+62, 536, Gx_line+78, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV36AddressLine1, "")), 536, Gx_line+30, 789, Gx_line+46, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV37AddressLine2, "")), 536, Gx_line+46, 789, Gx_line+62, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV38AddressLine3, "")), 536, Gx_line+62, 789, Gx_line+78, 2, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+128);
               if (true) break;
            }
            else
            {
               PrtOffset = 0;
               Gx_line = (int)(Gx_line+1);
            }
            ToSkip = (int)(ToSkip-1);
         }
         getPrinter().setPage(Gx_page);
      }

      protected void add_metrics( )
      {
         add_metrics0( ) ;
      }

      protected void add_metrics0( )
      {
         getPrinter().setMetrics("Microsoft Sans Serif", false, false, 58, 14, 72, 171,  new int[] {48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 18, 20, 23, 36, 36, 57, 43, 12, 21, 21, 25, 37, 18, 21, 18, 18, 36, 36, 36, 36, 36, 36, 36, 36, 36, 36, 18, 18, 37, 37, 37, 36, 65, 43, 43, 46, 46, 43, 39, 50, 46, 18, 32, 43, 36, 53, 46, 50, 43, 50, 46, 43, 40, 46, 43, 64, 41, 42, 39, 18, 18, 18, 27, 36, 21, 36, 36, 32, 36, 36, 18, 36, 36, 14, 15, 33, 14, 55, 36, 36, 36, 36, 21, 32, 18, 36, 33, 47, 31, 31, 31, 21, 17, 21, 37, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 18, 20, 36, 36, 36, 36, 17, 36, 21, 47, 24, 36, 37, 21, 47, 35, 26, 35, 21, 21, 21, 37, 34, 21, 21, 21, 23, 36, 53, 53, 53, 39, 43, 43, 43, 43, 43, 43, 64, 46, 43, 43, 43, 43, 18, 18, 18, 18, 46, 46, 50, 50, 50, 50, 50, 37, 50, 46, 46, 46, 46, 43, 43, 39, 36, 36, 36, 36, 36, 36, 57, 32, 36, 36, 36, 36, 18, 18, 18, 18, 36, 36, 36, 36, 36, 36, 36, 35, 39, 36, 36, 36, 36, 32, 36, 32}) ;
      }

      public override int getOutputType( )
      {
         return GxReportUtils.OUTPUT_PDF ;
      }

      public override void cleanup( )
      {
         CloseCursors();
         if (IsMain)	waitPrinterEnd();
         base.cleanup();
         if ( IsMain )
         {
            context.CloseConnections();
         }
         ExitApp();
      }

      public override void initialize( )
      {
         GXKey = "";
         gxfirstwebparm = "";
         AV49Pgmname = "";
         GXEncryptionTmp = "";
         AV26WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV46Title = "";
         AV48FilterFullText = "";
         AV19TFSecFunctionalityKey_Sel = "";
         AV18TFSecFunctionalityKey = "";
         AV21TFSecFunctionalityDescription_Sel = "";
         AV20TFSecFunctionalityDescription = "";
         AV33TFSecFunctionalityType_Sels = new GxSimpleCollection<short>();
         AV31TFSecFunctionalityType_SelsJson = "";
         AV32TFSecFunctionalityType_SelDscs = "";
         AV25FilterTFSecFunctionalityType_SelValueDescription = "";
         AV24TFSecParentFunctionalityDescription_Sel = "";
         AV23TFSecParentFunctionalityDescription = "";
         AV54Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext = "";
         AV55Wwpbaseobjects_secfunctionalitywwds_2_tfsecfunctionalitykey = "";
         AV56Wwpbaseobjects_secfunctionalitywwds_3_tfsecfunctionalitykey_sel = "";
         AV57Wwpbaseobjects_secfunctionalitywwds_4_tfsecfunctionalitydescription = "";
         AV58Wwpbaseobjects_secfunctionalitywwds_5_tfsecfunctionalitydescription_sel = "";
         AV59Wwpbaseobjects_secfunctionalitywwds_6_tfsecfunctionalitytype_sels = new GxSimpleCollection<short>();
         AV60Wwpbaseobjects_secfunctionalitywwds_7_tfsecparentfunctionalitydescription = "";
         AV61Wwpbaseobjects_secfunctionalitywwds_8_tfsecparentfunctionalitydescription_sel = "";
         lV54Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext = "";
         lV55Wwpbaseobjects_secfunctionalitywwds_2_tfsecfunctionalitykey = "";
         lV57Wwpbaseobjects_secfunctionalitywwds_4_tfsecfunctionalitydescription = "";
         lV60Wwpbaseobjects_secfunctionalitywwds_7_tfsecparentfunctionalitydescription = "";
         A15SecFunctionalityKey = "";
         A20SecFunctionalityDescription = "";
         A23SecParentFunctionalityDescript = "";
         P002E2_A14SecParentFunctionalityId = new long[1] ;
         P002E2_n14SecParentFunctionalityId = new bool[] {false} ;
         P002E2_A23SecParentFunctionalityDescript = new string[] {""} ;
         P002E2_A20SecFunctionalityDescription = new string[] {""} ;
         P002E2_A15SecFunctionalityKey = new string[] {""} ;
         P002E2_A21SecFunctionalityType = new short[1] ;
         P002E2_A13SecFunctionalityId = new long[1] ;
         AV17SecFunctionalityTypeDescription = "";
         AV27Session = context.GetSession();
         AV29GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV30GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV44PageInfo = "";
         AV41DateInfo = "";
         Gx_date = DateTime.MinValue;
         AV39AppName = "";
         AV45Phone = "";
         AV43Mail = "";
         AV47Website = "";
         AV36AddressLine1 = "";
         AV37AddressLine2 = "";
         AV38AddressLine3 = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.asecfunctionalitywwexportreport__default(),
            new Object[][] {
                new Object[] {
               P002E2_A14SecParentFunctionalityId, P002E2_n14SecParentFunctionalityId, P002E2_A23SecParentFunctionalityDescript, P002E2_A20SecFunctionalityDescription, P002E2_A15SecFunctionalityKey, P002E2_A21SecFunctionalityType, P002E2_A13SecFunctionalityId
               }
            }
         );
         Gx_date = DateTimeUtil.Today( context);
         AV49Pgmname = "WWPBaseObjects.ASecFunctionalityWWExportReport";
         /* GeneXus formulas. */
         Gx_line = 0;
         Gx_date = DateTimeUtil.Today( context);
         AV49Pgmname = "WWPBaseObjects.ASecFunctionalityWWExportReport";
      }

      private short nGotPars ;
      private short GxWebError ;
      private short AV22TFSecFunctionalityType_Sel ;
      private short A21SecFunctionalityType ;
      private short AV10OrderedBy ;
      private int M_top ;
      private int M_bot ;
      private int Line ;
      private int ToSkip ;
      private int PrtOffset ;
      private int Gx_OldLine ;
      private int AV52GXV1 ;
      private int AV59Wwpbaseobjects_secfunctionalitywwds_6_tfsecfunctionalitytype_sels_Count ;
      private int AV62GXV2 ;
      private long AV34i ;
      private long A14SecParentFunctionalityId ;
      private long A13SecFunctionalityId ;
      private string GXKey ;
      private string gxfirstwebparm ;
      private string AV49Pgmname ;
      private string GXEncryptionTmp ;
      private DateTime Gx_date ;
      private bool entryPointCalled ;
      private bool AV8IsAuthorized ;
      private bool GXt_boolean1 ;
      private bool returnInSub ;
      private bool AV35TempBoolean ;
      private bool AV11OrderedDsc ;
      private bool n14SecParentFunctionalityId ;
      private string AV31TFSecFunctionalityType_SelsJson ;
      private string AV46Title ;
      private string AV48FilterFullText ;
      private string AV19TFSecFunctionalityKey_Sel ;
      private string AV18TFSecFunctionalityKey ;
      private string AV21TFSecFunctionalityDescription_Sel ;
      private string AV20TFSecFunctionalityDescription ;
      private string AV32TFSecFunctionalityType_SelDscs ;
      private string AV25FilterTFSecFunctionalityType_SelValueDescription ;
      private string AV24TFSecParentFunctionalityDescription_Sel ;
      private string AV23TFSecParentFunctionalityDescription ;
      private string AV54Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext ;
      private string AV55Wwpbaseobjects_secfunctionalitywwds_2_tfsecfunctionalitykey ;
      private string AV56Wwpbaseobjects_secfunctionalitywwds_3_tfsecfunctionalitykey_sel ;
      private string AV57Wwpbaseobjects_secfunctionalitywwds_4_tfsecfunctionalitydescription ;
      private string AV58Wwpbaseobjects_secfunctionalitywwds_5_tfsecfunctionalitydescription_sel ;
      private string AV60Wwpbaseobjects_secfunctionalitywwds_7_tfsecparentfunctionalitydescription ;
      private string AV61Wwpbaseobjects_secfunctionalitywwds_8_tfsecparentfunctionalitydescription_sel ;
      private string lV54Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext ;
      private string lV55Wwpbaseobjects_secfunctionalitywwds_2_tfsecfunctionalitykey ;
      private string lV57Wwpbaseobjects_secfunctionalitywwds_4_tfsecfunctionalitydescription ;
      private string lV60Wwpbaseobjects_secfunctionalitywwds_7_tfsecparentfunctionalitydescription ;
      private string A15SecFunctionalityKey ;
      private string A20SecFunctionalityDescription ;
      private string A23SecParentFunctionalityDescript ;
      private string AV17SecFunctionalityTypeDescription ;
      private string AV44PageInfo ;
      private string AV41DateInfo ;
      private string AV39AppName ;
      private string AV45Phone ;
      private string AV43Mail ;
      private string AV47Website ;
      private string AV36AddressLine1 ;
      private string AV37AddressLine2 ;
      private string AV38AddressLine3 ;
      private IGxSession AV27Session ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV26WWPContext ;
      private GxSimpleCollection<short> AV33TFSecFunctionalityType_Sels ;
      private GxSimpleCollection<short> AV59Wwpbaseobjects_secfunctionalitywwds_6_tfsecfunctionalitytype_sels ;
      private IDataStoreProvider pr_default ;
      private long[] P002E2_A14SecParentFunctionalityId ;
      private bool[] P002E2_n14SecParentFunctionalityId ;
      private string[] P002E2_A23SecParentFunctionalityDescript ;
      private string[] P002E2_A20SecFunctionalityDescription ;
      private string[] P002E2_A15SecFunctionalityKey ;
      private short[] P002E2_A21SecFunctionalityType ;
      private long[] P002E2_A13SecFunctionalityId ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV29GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV30GridStateFilterValue ;
   }

   public class asecfunctionalitywwexportreport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P002E2( IGxContext context ,
                                             short A21SecFunctionalityType ,
                                             GxSimpleCollection<short> AV59Wwpbaseobjects_secfunctionalitywwds_6_tfsecfunctionalitytype_sels ,
                                             string AV56Wwpbaseobjects_secfunctionalitywwds_3_tfsecfunctionalitykey_sel ,
                                             string AV55Wwpbaseobjects_secfunctionalitywwds_2_tfsecfunctionalitykey ,
                                             string AV58Wwpbaseobjects_secfunctionalitywwds_5_tfsecfunctionalitydescription_sel ,
                                             string AV57Wwpbaseobjects_secfunctionalitywwds_4_tfsecfunctionalitydescription ,
                                             int AV59Wwpbaseobjects_secfunctionalitywwds_6_tfsecfunctionalitytype_sels_Count ,
                                             string AV61Wwpbaseobjects_secfunctionalitywwds_8_tfsecparentfunctionalitydescription_sel ,
                                             string AV60Wwpbaseobjects_secfunctionalitywwds_7_tfsecparentfunctionalitydescription ,
                                             string A15SecFunctionalityKey ,
                                             string A20SecFunctionalityDescription ,
                                             string A23SecParentFunctionalityDescript ,
                                             short AV10OrderedBy ,
                                             bool AV11OrderedDsc ,
                                             string AV54Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int2 = new short[6];
         Object[] GXv_Object3 = new Object[2];
         scmdbuf = "SELECT T1.[SecParentFunctionalityId] AS SecParentFunctionalityId, T2.[SecFunctionalityDescription] AS SecParentFunctionalityDescript, T1.[SecFunctionalityDescription], T1.[SecFunctionalityKey], T1.[SecFunctionalityType], T1.[SecFunctionalityId] FROM ([SecFunctionality] T1 LEFT JOIN [SecFunctionality] T2 ON T2.[SecFunctionalityId] = T1.[SecParentFunctionalityId])";
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV56Wwpbaseobjects_secfunctionalitywwds_3_tfsecfunctionalitykey_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV55Wwpbaseobjects_secfunctionalitywwds_2_tfsecfunctionalitykey)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[SecFunctionalityKey]) like UPPER(@lV55Wwpbaseobjects_secfunctionalitywwds_2_tfsecfunctionalitykey))");
         }
         else
         {
            GXv_int2[0] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV56Wwpbaseobjects_secfunctionalitywwds_3_tfsecfunctionalitykey_sel)) && ! ( StringUtil.StrCmp(AV56Wwpbaseobjects_secfunctionalitywwds_3_tfsecfunctionalitykey_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[SecFunctionalityKey] = @AV56Wwpbaseobjects_secfunctionalitywwds_3_tfsecfunctionalitykey_sel)");
         }
         else
         {
            GXv_int2[1] = 1;
         }
         if ( StringUtil.StrCmp(AV56Wwpbaseobjects_secfunctionalitywwds_3_tfsecfunctionalitykey_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[SecFunctionalityKey] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV58Wwpbaseobjects_secfunctionalitywwds_5_tfsecfunctionalitydescription_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57Wwpbaseobjects_secfunctionalitywwds_4_tfsecfunctionalitydescription)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[SecFunctionalityDescription]) like UPPER(@lV57Wwpbaseobjects_secfunctionalitywwds_4_tfsecfunctionalitydescription))");
         }
         else
         {
            GXv_int2[2] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV58Wwpbaseobjects_secfunctionalitywwds_5_tfsecfunctionalitydescription_sel)) && ! ( StringUtil.StrCmp(AV58Wwpbaseobjects_secfunctionalitywwds_5_tfsecfunctionalitydescription_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[SecFunctionalityDescription] = @AV58Wwpbaseobjects_secfunctionalitywwds_5_tfsecfunctionalitydescription_sel)");
         }
         else
         {
            GXv_int2[3] = 1;
         }
         if ( StringUtil.StrCmp(AV58Wwpbaseobjects_secfunctionalitywwds_5_tfsecfunctionalitydescription_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[SecFunctionalityDescription] = ''))");
         }
         if ( AV59Wwpbaseobjects_secfunctionalitywwds_6_tfsecfunctionalitytype_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV59Wwpbaseobjects_secfunctionalitywwds_6_tfsecfunctionalitytype_sels, "T1.[SecFunctionalityType] IN (", ")")+")");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV61Wwpbaseobjects_secfunctionalitywwds_8_tfsecparentfunctionalitydescription_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Wwpbaseobjects_secfunctionalitywwds_7_tfsecparentfunctionalitydescription)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[SecFunctionalityDescription]) like UPPER(@lV60Wwpbaseobjects_secfunctionalitywwds_7_tfsecparentfunctionalitydescription))");
         }
         else
         {
            GXv_int2[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Wwpbaseobjects_secfunctionalitywwds_8_tfsecparentfunctionalitydescription_sel)) && ! ( StringUtil.StrCmp(AV61Wwpbaseobjects_secfunctionalitywwds_8_tfsecparentfunctionalitydescription_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.[SecFunctionalityDescription] = @AV61Wwpbaseobjects_secfunctionalitywwds_8_tfsecparentfunctionalitydescription_sel)");
         }
         else
         {
            GXv_int2[5] = 1;
         }
         if ( StringUtil.StrCmp(AV61Wwpbaseobjects_secfunctionalitywwds_8_tfsecparentfunctionalitydescription_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T2.[SecFunctionalityDescription] IS NULL or (T2.[SecFunctionalityDescription] = ''))");
         }
         scmdbuf += sWhereString;
         if ( ( AV10OrderedBy == 1 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[SecFunctionalityDescription]";
         }
         else if ( ( AV10OrderedBy == 1 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[SecFunctionalityDescription] DESC";
         }
         else if ( ( AV10OrderedBy == 2 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[SecFunctionalityKey]";
         }
         else if ( ( AV10OrderedBy == 2 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[SecFunctionalityKey] DESC";
         }
         else if ( ( AV10OrderedBy == 3 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[SecFunctionalityType]";
         }
         else if ( ( AV10OrderedBy == 3 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[SecFunctionalityType] DESC";
         }
         else if ( ( AV10OrderedBy == 4 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY T2.[SecFunctionalityDescription]";
         }
         else if ( ( AV10OrderedBy == 4 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T2.[SecFunctionalityDescription] DESC";
         }
         GXv_Object3[0] = scmdbuf;
         GXv_Object3[1] = GXv_int2;
         return GXv_Object3 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_P002E2(context, (short)dynConstraints[0] , (GxSimpleCollection<short>)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (int)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (short)dynConstraints[12] , (bool)dynConstraints[13] , (string)dynConstraints[14] );
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
          Object[] prmP002E2;
          prmP002E2 = new Object[] {
          new ParDef("@lV55Wwpbaseobjects_secfunctionalitywwds_2_tfsecfunctionalitykey",GXType.VarChar,100,0) ,
          new ParDef("@AV56Wwpbaseobjects_secfunctionalitywwds_3_tfsecfunctionalitykey_sel",GXType.NVarChar,100,0) ,
          new ParDef("@lV57Wwpbaseobjects_secfunctionalitywwds_4_tfsecfunctionalitydescription",GXType.VarChar,100,0) ,
          new ParDef("@AV58Wwpbaseobjects_secfunctionalitywwds_5_tfsecfunctionalitydescription_sel",GXType.NVarChar,100,0) ,
          new ParDef("@lV60Wwpbaseobjects_secfunctionalitywwds_7_tfsecparentfunctionalitydescription",GXType.VarChar,100,0) ,
          new ParDef("@AV61Wwpbaseobjects_secfunctionalitywwds_8_tfsecparentfunctionalitydescription_sel",GXType.NVarChar,100,0)
          };
          def= new CursorDef[] {
              new CursorDef("P002E2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP002E2,100, GxCacheFrequency.OFF ,true,false )
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

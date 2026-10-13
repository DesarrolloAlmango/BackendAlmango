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
namespace GeneXus.Programs {
   public class motivowwexportreport : GXWebProcedure, System.Web.SessionState.IRequiresSessionState
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

      public motivowwexportreport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public motivowwexportreport( IGxContext context )
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
         setOutputFileName("MotivoWWExportReport");
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
            new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWMotivo", out  GXt_boolean1) ;
            AV8IsAuthorized = GXt_boolean1;
            if ( ! AV8IsAuthorized )
            {
               GXKey = Crypto.GetSiteKey( );
               GXEncryptionTmp = "wwpbaseobjects.notauthorized.aspx"+UrlEncode(StringUtil.RTrim(AV65Pgmname));
               CallWebObject(formatLink("wwpbaseobjects.notauthorized.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
               context.wjLocDisableFrm = 1;
            }
            if ( AV8IsAuthorized )
            {
               new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV9WWPContext) ;
               /* Execute user subroutine: 'LOADGRIDSTATE' */
               S151 ();
               if ( returnInSub )
               {
                  cleanup();
                  if (true) return;
               }
               AV48Title = context.GetMessage( "Lista de Motivo", "");
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
            HAZ0( true, 0) ;
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
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV13FilterFullText)) )
         {
            HAZ0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "WWP_FullTextFilterDescription", ""), 25, Gx_line+0, 99, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV13FilterFullText, "")), 99, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         if ( AV30GridState.gxTpr_Dynamicfilters.Count >= 1 )
         {
            AV27GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV30GridState.gxTpr_Dynamicfilters.Item(1));
            AV14DynamicFiltersSelector1 = AV27GridStateDynamicFilter.gxTpr_Selected;
            if ( StringUtil.StrCmp(AV14DynamicFiltersSelector1, "MOTIVOTIPO") == 0 )
            {
               AV50MotivoTipo1 = AV27GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV50MotivoTipo1)) )
               {
                  AV53FilterMotivoTipo1ValueDescription = context.GetMessage( gxdomaintipomotivos.getDescription(context,AV50MotivoTipo1), "");
                  AV52FilterMotivoTipoValueDescription = AV53FilterMotivoTipo1ValueDescription;
                  HAZ0( false, 20) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(context.GetMessage( "Tipo", ""), 25, Gx_line+0, 99, Gx_line+15, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV52FilterMotivoTipoValueDescription, "")), 99, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+20);
               }
            }
            if ( AV30GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV19DynamicFiltersEnabled2 = true;
               AV27GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV30GridState.gxTpr_Dynamicfilters.Item(2));
               AV20DynamicFiltersSelector2 = AV27GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV20DynamicFiltersSelector2, "MOTIVOTIPO") == 0 )
               {
                  AV54MotivoTipo2 = AV27GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV54MotivoTipo2)) )
                  {
                     AV55FilterMotivoTipo2ValueDescription = context.GetMessage( gxdomaintipomotivos.getDescription(context,AV54MotivoTipo2), "");
                     AV52FilterMotivoTipoValueDescription = AV55FilterMotivoTipo2ValueDescription;
                     HAZ0( false, 20) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(context.GetMessage( "Tipo", ""), 25, Gx_line+0, 99, Gx_line+15, 0, 0, 0, 0) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV52FilterMotivoTipoValueDescription, "")), 99, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                     Gx_OldLine = Gx_line;
                     Gx_line = (int)(Gx_line+20);
                  }
               }
               if ( AV30GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV23DynamicFiltersEnabled3 = true;
                  AV27GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV30GridState.gxTpr_Dynamicfilters.Item(3));
                  AV24DynamicFiltersSelector3 = AV27GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV24DynamicFiltersSelector3, "MOTIVOTIPO") == 0 )
                  {
                     AV56MotivoTipo3 = AV27GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV56MotivoTipo3)) )
                     {
                        AV57FilterMotivoTipo3ValueDescription = context.GetMessage( gxdomaintipomotivos.getDescription(context,AV56MotivoTipo3), "");
                        AV52FilterMotivoTipoValueDescription = AV57FilterMotivoTipo3ValueDescription;
                        HAZ0( false, 20) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(context.GetMessage( "Tipo", ""), 25, Gx_line+0, 99, Gx_line+15, 0, 0, 0, 0) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV52FilterMotivoTipoValueDescription, "")), 99, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                        Gx_OldLine = Gx_line;
                        Gx_line = (int)(Gx_line+20);
                     }
                  }
               }
            }
         }
         if ( ! ( (0==AV32TFMotivoId) && (0==AV33TFMotivoId_To) ) )
         {
            HAZ0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Id", ""), 25, Gx_line+0, 99, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV32TFMotivoId), "ZZZZZZZZZZZZZZZZZ9")), 99, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV36TFMotivoId_To_Description = StringUtil.Format( "%1 (%2)", context.GetMessage( "Id", ""), context.GetMessage( "WWP_TSTo", ""), "", "", "", "", "", "", "");
            HAZ0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV36TFMotivoId_To_Description, "")), 25, Gx_line+0, 99, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV33TFMotivoId_To), "ZZZZZZZZZZZZZZZZZ9")), 99, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         AV61TFMotivoTipo_Sels.FromJSonString(AV59TFMotivoTipo_SelsJson, null);
         if ( ! ( AV61TFMotivoTipo_Sels.Count == 0 ) )
         {
            AV64i = 1;
            AV68GXV1 = 1;
            while ( AV68GXV1 <= AV61TFMotivoTipo_Sels.Count )
            {
               AV62TFMotivoTipo_Sel = AV61TFMotivoTipo_Sels.GetString(AV68GXV1);
               if ( AV64i == 1 )
               {
                  AV60TFMotivoTipo_SelDscs = "";
               }
               else
               {
                  AV60TFMotivoTipo_SelDscs += ", ";
               }
               AV63FilterTFMotivoTipo_SelValueDescription = context.GetMessage( gxdomaintipomotivos.getDescription(context,AV62TFMotivoTipo_Sel), "");
               AV60TFMotivoTipo_SelDscs += AV63FilterTFMotivoTipo_SelValueDescription;
               AV64i = (long)(AV64i+1);
               AV68GXV1 = (int)(AV68GXV1+1);
            }
            HAZ0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Tipo", ""), 25, Gx_line+0, 99, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV60TFMotivoTipo_SelDscs, "")), 99, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV35TFMotivoNombre_Sel)) )
         {
            AV37TempBoolean = (bool)(((StringUtil.StrCmp(AV35TFMotivoNombre_Sel, "<#Empty#>")==0)));
            AV35TFMotivoNombre_Sel = (AV37TempBoolean ? context.GetMessage( "WWP_TitleFilter_EmptyOption", "") : AV35TFMotivoNombre_Sel);
            HAZ0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Nombre", ""), 25, Gx_line+0, 99, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV35TFMotivoNombre_Sel, "")), 99, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV35TFMotivoNombre_Sel = (AV37TempBoolean ? "<#Empty#>" : AV35TFMotivoNombre_Sel);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV34TFMotivoNombre)) )
            {
               HAZ0( false, 20) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(context.GetMessage( "Nombre", ""), 25, Gx_line+0, 99, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV34TFMotivoNombre, "")), 99, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
      }

      protected void S121( )
      {
         /* 'PRINTCOLUMNTITLES' Routine */
         returnInSub = false;
         HAZ0( false, 22) ;
         getPrinter().GxDrawLine(25, Gx_line+21, 789, Gx_line+21, 2, 8, 160, 134, 0) ;
         Gx_OldLine = Gx_line;
         Gx_line = (int)(Gx_line+22);
         HAZ0( false, 37) ;
         getPrinter().GxAttris("Microsoft Sans Serif", 9, false, false, false, false, 0, 8, 160, 134, 0, 255, 255, 255) ;
         getPrinter().GxDrawText(context.GetMessage( "Id", ""), 30, Gx_line+10, 179, Gx_line+27, 2, 0, 0, 0) ;
         getPrinter().GxDrawText(context.GetMessage( "Tipo", ""), 183, Gx_line+10, 483, Gx_line+27, 0, 0, 0, 0) ;
         getPrinter().GxDrawText(context.GetMessage( "Nombre", ""), 487, Gx_line+10, 787, Gx_line+27, 0, 0, 0, 0) ;
         Gx_OldLine = Gx_line;
         Gx_line = (int)(Gx_line+37);
      }

      protected void S131( )
      {
         /* 'PRINTDATA' Routine */
         returnInSub = false;
         AV70Motivowwds_1_filterfulltext = AV13FilterFullText;
         AV71Motivowwds_2_dynamicfiltersselector1 = AV14DynamicFiltersSelector1;
         AV72Motivowwds_3_motivotipo1 = AV50MotivoTipo1;
         AV73Motivowwds_4_dynamicfiltersenabled2 = AV19DynamicFiltersEnabled2;
         AV74Motivowwds_5_dynamicfiltersselector2 = AV20DynamicFiltersSelector2;
         AV75Motivowwds_6_motivotipo2 = AV54MotivoTipo2;
         AV76Motivowwds_7_dynamicfiltersenabled3 = AV23DynamicFiltersEnabled3;
         AV77Motivowwds_8_dynamicfiltersselector3 = AV24DynamicFiltersSelector3;
         AV78Motivowwds_9_motivotipo3 = AV56MotivoTipo3;
         AV79Motivowwds_10_tfmotivoid = AV32TFMotivoId;
         AV80Motivowwds_11_tfmotivoid_to = AV33TFMotivoId_To;
         AV81Motivowwds_12_tfmotivotipo_sels = AV61TFMotivoTipo_Sels;
         AV82Motivowwds_13_tfmotivonombre = AV34TFMotivoNombre;
         AV83Motivowwds_14_tfmotivonombre_sel = AV35TFMotivoNombre_Sel;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A618MotivoTipo ,
                                              AV81Motivowwds_12_tfmotivotipo_sels ,
                                              AV71Motivowwds_2_dynamicfiltersselector1 ,
                                              AV72Motivowwds_3_motivotipo1 ,
                                              AV73Motivowwds_4_dynamicfiltersenabled2 ,
                                              AV74Motivowwds_5_dynamicfiltersselector2 ,
                                              AV75Motivowwds_6_motivotipo2 ,
                                              AV76Motivowwds_7_dynamicfiltersenabled3 ,
                                              AV77Motivowwds_8_dynamicfiltersselector3 ,
                                              AV78Motivowwds_9_motivotipo3 ,
                                              AV79Motivowwds_10_tfmotivoid ,
                                              AV80Motivowwds_11_tfmotivoid_to ,
                                              AV81Motivowwds_12_tfmotivotipo_sels.Count ,
                                              AV83Motivowwds_14_tfmotivonombre_sel ,
                                              AV82Motivowwds_13_tfmotivonombre ,
                                              A604MotivoId ,
                                              A616MotivoNombre ,
                                              AV11OrderedBy ,
                                              AV12OrderedDsc ,
                                              AV70Motivowwds_1_filterfulltext } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.INT, TypeConstants.LONG, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV82Motivowwds_13_tfmotivonombre = StringUtil.PadR( StringUtil.RTrim( AV82Motivowwds_13_tfmotivonombre), 80, "%");
         /* Using cursor P00AZ2 */
         pr_default.execute(0, new Object[] {AV72Motivowwds_3_motivotipo1, AV75Motivowwds_6_motivotipo2, AV78Motivowwds_9_motivotipo3, AV79Motivowwds_10_tfmotivoid, AV80Motivowwds_11_tfmotivoid_to, lV82Motivowwds_13_tfmotivonombre, AV83Motivowwds_14_tfmotivonombre_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A616MotivoNombre = P00AZ2_A616MotivoNombre[0];
            A604MotivoId = P00AZ2_A604MotivoId[0];
            A618MotivoTipo = P00AZ2_A618MotivoTipo[0];
            n618MotivoTipo = P00AZ2_n618MotivoTipo[0];
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV70Motivowwds_1_filterfulltext)) || ( ( StringUtil.Like( StringUtil.Str( (decimal)(A604MotivoId), 18, 0) , StringUtil.PadR( "%" + AV70Motivowwds_1_filterfulltext , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( context.GetMessage( "incidencias", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV70Motivowwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A618MotivoTipo, "INC") == 0 ) ) || ( StringUtil.Like( StringUtil.Upper( A616MotivoNombre) , StringUtil.PadR( "%" + StringUtil.Upper( AV70Motivowwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) ) )
            {
               AV58MotivoTipoDescription = context.GetMessage( gxdomaintipomotivos.getDescription(context,A618MotivoTipo), "");
               /* Execute user subroutine: 'BEFOREPRINTLINE' */
               S144 ();
               if ( returnInSub )
               {
                  pr_default.close(0);
                  returnInSub = true;
                  if (true) return;
               }
               HAZ0( false, 36) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(A604MotivoId), "ZZZZZZZZZZZZZZZZZ9")), 30, Gx_line+10, 179, Gx_line+25, 2+16, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV58MotivoTipoDescription, "")), 183, Gx_line+10, 483, Gx_line+25, 0+16, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A616MotivoNombre, "")), 487, Gx_line+10, 787, Gx_line+25, 0+16, 0, 0, 0) ;
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
         if ( StringUtil.StrCmp(AV28Session.Get("MotivoWWGridState"), "") == 0 )
         {
            AV30GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "MotivoWWGridState"), null, "", "");
         }
         else
         {
            AV30GridState.FromXml(AV28Session.Get("MotivoWWGridState"), null, "", "");
         }
         AV11OrderedBy = AV30GridState.gxTpr_Orderedby;
         AV12OrderedDsc = AV30GridState.gxTpr_Ordereddsc;
         AV84GXV2 = 1;
         while ( AV84GXV2 <= AV30GridState.gxTpr_Filtervalues.Count )
         {
            AV31GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV30GridState.gxTpr_Filtervalues.Item(AV84GXV2));
            if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV13FilterFullText = AV31GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "TFMOTIVOID") == 0 )
            {
               AV32TFMotivoId = (long)(Math.Round(NumberUtil.Val( AV31GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV33TFMotivoId_To = (long)(Math.Round(NumberUtil.Val( AV31GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "TFMOTIVOTIPO_SEL") == 0 )
            {
               AV59TFMotivoTipo_SelsJson = AV31GridStateFilterValue.gxTpr_Value;
               AV61TFMotivoTipo_Sels.FromJSonString(AV59TFMotivoTipo_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "TFMOTIVONOMBRE") == 0 )
            {
               AV34TFMotivoNombre = AV31GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "TFMOTIVONOMBRE_SEL") == 0 )
            {
               AV35TFMotivoNombre_Sel = AV31GridStateFilterValue.gxTpr_Value;
            }
            AV84GXV2 = (int)(AV84GXV2+1);
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

      protected void HAZ0( bool bFoot ,
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
                  AV46PageInfo = context.GetMessage( "Page: ", "") + StringUtil.Trim( StringUtil.Str( (decimal)(Gx_page), 6, 0));
                  AV43DateInfo = context.GetMessage( "Date: ", "") + context.localUtil.Format( Gx_date, "99/99/99");
                  getPrinter().GxDrawRect(0, Gx_line+5, 819, Gx_line+40, 1, 0, 0, 0, 1, 8, 160, 134, 1, 1, 1, 1, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV46PageInfo, "")), 30, Gx_line+15, 409, Gx_line+30, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV43DateInfo, "")), 409, Gx_line+15, 789, Gx_line+30, 2, 0, 0, 0) ;
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
               AV41AppName = context.GetMessage( "DVelop Software Solutions", "");
               AV47Phone = "+1 550 8923";
               AV45Mail = "info@mail.com";
               AV49Website = "http://www.web.com";
               AV38AddressLine1 = "French Boulevard 2859";
               AV39AddressLine2 = "Downtown";
               AV40AddressLine3 = "Paris, France";
               getPrinter().GxDrawRect(0, Gx_line+0, 819, Gx_line+108, 1, 0, 0, 0, 1, 8, 160, 134, 1, 1, 1, 1, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV41AppName, "")), 30, Gx_line+30, 283, Gx_line+45, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 20, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV48Title, "")), 30, Gx_line+45, 283, Gx_line+78, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV47Phone, "")), 283, Gx_line+30, 536, Gx_line+46, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV45Mail, "")), 283, Gx_line+46, 536, Gx_line+62, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV49Website, "")), 283, Gx_line+62, 536, Gx_line+78, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV38AddressLine1, "")), 536, Gx_line+30, 789, Gx_line+46, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV39AddressLine2, "")), 536, Gx_line+46, 789, Gx_line+62, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV40AddressLine3, "")), 536, Gx_line+62, 789, Gx_line+78, 2, 0, 0, 0) ;
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
         AV65Pgmname = "";
         GXEncryptionTmp = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV48Title = "";
         AV13FilterFullText = "";
         AV30GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV27GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV14DynamicFiltersSelector1 = "";
         AV50MotivoTipo1 = "";
         AV53FilterMotivoTipo1ValueDescription = "";
         AV52FilterMotivoTipoValueDescription = "";
         AV20DynamicFiltersSelector2 = "";
         AV54MotivoTipo2 = "";
         AV55FilterMotivoTipo2ValueDescription = "";
         AV24DynamicFiltersSelector3 = "";
         AV56MotivoTipo3 = "";
         AV57FilterMotivoTipo3ValueDescription = "";
         AV36TFMotivoId_To_Description = "";
         AV61TFMotivoTipo_Sels = new GxSimpleCollection<string>();
         AV59TFMotivoTipo_SelsJson = "";
         AV62TFMotivoTipo_Sel = "";
         AV60TFMotivoTipo_SelDscs = "";
         AV63FilterTFMotivoTipo_SelValueDescription = "";
         AV35TFMotivoNombre_Sel = "";
         AV34TFMotivoNombre = "";
         AV70Motivowwds_1_filterfulltext = "";
         AV71Motivowwds_2_dynamicfiltersselector1 = "";
         AV72Motivowwds_3_motivotipo1 = "";
         AV74Motivowwds_5_dynamicfiltersselector2 = "";
         AV75Motivowwds_6_motivotipo2 = "";
         AV77Motivowwds_8_dynamicfiltersselector3 = "";
         AV78Motivowwds_9_motivotipo3 = "";
         AV81Motivowwds_12_tfmotivotipo_sels = new GxSimpleCollection<string>();
         AV82Motivowwds_13_tfmotivonombre = "";
         AV83Motivowwds_14_tfmotivonombre_sel = "";
         lV70Motivowwds_1_filterfulltext = "";
         lV82Motivowwds_13_tfmotivonombre = "";
         A618MotivoTipo = "";
         A616MotivoNombre = "";
         P00AZ2_A616MotivoNombre = new string[] {""} ;
         P00AZ2_A604MotivoId = new long[1] ;
         P00AZ2_A618MotivoTipo = new string[] {""} ;
         P00AZ2_n618MotivoTipo = new bool[] {false} ;
         AV58MotivoTipoDescription = "";
         AV28Session = context.GetSession();
         AV31GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV46PageInfo = "";
         AV43DateInfo = "";
         Gx_date = DateTime.MinValue;
         AV41AppName = "";
         AV47Phone = "";
         AV45Mail = "";
         AV49Website = "";
         AV38AddressLine1 = "";
         AV39AddressLine2 = "";
         AV40AddressLine3 = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.motivowwexportreport__default(),
            new Object[][] {
                new Object[] {
               P00AZ2_A616MotivoNombre, P00AZ2_A604MotivoId, P00AZ2_A618MotivoTipo, P00AZ2_n618MotivoTipo
               }
            }
         );
         Gx_date = DateTimeUtil.Today( context);
         AV65Pgmname = "MotivoWWExportReport";
         /* GeneXus formulas. */
         Gx_line = 0;
         Gx_date = DateTimeUtil.Today( context);
         AV65Pgmname = "MotivoWWExportReport";
      }

      private short nGotPars ;
      private short GxWebError ;
      private short AV11OrderedBy ;
      private int M_top ;
      private int M_bot ;
      private int Line ;
      private int ToSkip ;
      private int PrtOffset ;
      private int Gx_OldLine ;
      private int AV68GXV1 ;
      private int AV81Motivowwds_12_tfmotivotipo_sels_Count ;
      private int AV84GXV2 ;
      private long AV32TFMotivoId ;
      private long AV33TFMotivoId_To ;
      private long AV64i ;
      private long AV79Motivowwds_10_tfmotivoid ;
      private long AV80Motivowwds_11_tfmotivoid_to ;
      private long A604MotivoId ;
      private string GXKey ;
      private string gxfirstwebparm ;
      private string AV65Pgmname ;
      private string GXEncryptionTmp ;
      private string AV50MotivoTipo1 ;
      private string AV54MotivoTipo2 ;
      private string AV56MotivoTipo3 ;
      private string AV62TFMotivoTipo_Sel ;
      private string AV35TFMotivoNombre_Sel ;
      private string AV34TFMotivoNombre ;
      private string AV72Motivowwds_3_motivotipo1 ;
      private string AV75Motivowwds_6_motivotipo2 ;
      private string AV78Motivowwds_9_motivotipo3 ;
      private string AV82Motivowwds_13_tfmotivonombre ;
      private string AV83Motivowwds_14_tfmotivonombre_sel ;
      private string lV82Motivowwds_13_tfmotivonombre ;
      private string A618MotivoTipo ;
      private string A616MotivoNombre ;
      private DateTime Gx_date ;
      private bool entryPointCalled ;
      private bool AV8IsAuthorized ;
      private bool GXt_boolean1 ;
      private bool returnInSub ;
      private bool AV19DynamicFiltersEnabled2 ;
      private bool AV23DynamicFiltersEnabled3 ;
      private bool AV37TempBoolean ;
      private bool AV73Motivowwds_4_dynamicfiltersenabled2 ;
      private bool AV76Motivowwds_7_dynamicfiltersenabled3 ;
      private bool AV12OrderedDsc ;
      private bool n618MotivoTipo ;
      private string AV59TFMotivoTipo_SelsJson ;
      private string AV48Title ;
      private string AV13FilterFullText ;
      private string AV14DynamicFiltersSelector1 ;
      private string AV53FilterMotivoTipo1ValueDescription ;
      private string AV52FilterMotivoTipoValueDescription ;
      private string AV20DynamicFiltersSelector2 ;
      private string AV55FilterMotivoTipo2ValueDescription ;
      private string AV24DynamicFiltersSelector3 ;
      private string AV57FilterMotivoTipo3ValueDescription ;
      private string AV36TFMotivoId_To_Description ;
      private string AV60TFMotivoTipo_SelDscs ;
      private string AV63FilterTFMotivoTipo_SelValueDescription ;
      private string AV70Motivowwds_1_filterfulltext ;
      private string AV71Motivowwds_2_dynamicfiltersselector1 ;
      private string AV74Motivowwds_5_dynamicfiltersselector2 ;
      private string AV77Motivowwds_8_dynamicfiltersselector3 ;
      private string lV70Motivowwds_1_filterfulltext ;
      private string AV58MotivoTipoDescription ;
      private string AV46PageInfo ;
      private string AV43DateInfo ;
      private string AV41AppName ;
      private string AV47Phone ;
      private string AV45Mail ;
      private string AV49Website ;
      private string AV38AddressLine1 ;
      private string AV39AddressLine2 ;
      private string AV40AddressLine3 ;
      private IGxSession AV28Session ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV30GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV27GridStateDynamicFilter ;
      private GxSimpleCollection<string> AV61TFMotivoTipo_Sels ;
      private GxSimpleCollection<string> AV81Motivowwds_12_tfmotivotipo_sels ;
      private IDataStoreProvider pr_default ;
      private string[] P00AZ2_A616MotivoNombre ;
      private long[] P00AZ2_A604MotivoId ;
      private string[] P00AZ2_A618MotivoTipo ;
      private bool[] P00AZ2_n618MotivoTipo ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV31GridStateFilterValue ;
   }

   public class motivowwexportreport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00AZ2( IGxContext context ,
                                             string A618MotivoTipo ,
                                             GxSimpleCollection<string> AV81Motivowwds_12_tfmotivotipo_sels ,
                                             string AV71Motivowwds_2_dynamicfiltersselector1 ,
                                             string AV72Motivowwds_3_motivotipo1 ,
                                             bool AV73Motivowwds_4_dynamicfiltersenabled2 ,
                                             string AV74Motivowwds_5_dynamicfiltersselector2 ,
                                             string AV75Motivowwds_6_motivotipo2 ,
                                             bool AV76Motivowwds_7_dynamicfiltersenabled3 ,
                                             string AV77Motivowwds_8_dynamicfiltersselector3 ,
                                             string AV78Motivowwds_9_motivotipo3 ,
                                             long AV79Motivowwds_10_tfmotivoid ,
                                             long AV80Motivowwds_11_tfmotivoid_to ,
                                             int AV81Motivowwds_12_tfmotivotipo_sels_Count ,
                                             string AV83Motivowwds_14_tfmotivonombre_sel ,
                                             string AV82Motivowwds_13_tfmotivonombre ,
                                             long A604MotivoId ,
                                             string A616MotivoNombre ,
                                             short AV11OrderedBy ,
                                             bool AV12OrderedDsc ,
                                             string AV70Motivowwds_1_filterfulltext )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int2 = new short[7];
         Object[] GXv_Object3 = new Object[2];
         scmdbuf = "SELECT [MotivoNombre], [MotivoId], [MotivoTipo] FROM [Motivo]";
         if ( ( StringUtil.StrCmp(AV71Motivowwds_2_dynamicfiltersselector1, "MOTIVOTIPO") == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Motivowwds_3_motivotipo1)) ) )
         {
            AddWhere(sWhereString, "([MotivoTipo] = @AV72Motivowwds_3_motivotipo1)");
         }
         else
         {
            GXv_int2[0] = 1;
         }
         if ( AV73Motivowwds_4_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV74Motivowwds_5_dynamicfiltersselector2, "MOTIVOTIPO") == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75Motivowwds_6_motivotipo2)) ) )
         {
            AddWhere(sWhereString, "([MotivoTipo] = @AV75Motivowwds_6_motivotipo2)");
         }
         else
         {
            GXv_int2[1] = 1;
         }
         if ( AV76Motivowwds_7_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV77Motivowwds_8_dynamicfiltersselector3, "MOTIVOTIPO") == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV78Motivowwds_9_motivotipo3)) ) )
         {
            AddWhere(sWhereString, "([MotivoTipo] = @AV78Motivowwds_9_motivotipo3)");
         }
         else
         {
            GXv_int2[2] = 1;
         }
         if ( ! (0==AV79Motivowwds_10_tfmotivoid) )
         {
            AddWhere(sWhereString, "([MotivoId] >= @AV79Motivowwds_10_tfmotivoid)");
         }
         else
         {
            GXv_int2[3] = 1;
         }
         if ( ! (0==AV80Motivowwds_11_tfmotivoid_to) )
         {
            AddWhere(sWhereString, "([MotivoId] <= @AV80Motivowwds_11_tfmotivoid_to)");
         }
         else
         {
            GXv_int2[4] = 1;
         }
         if ( AV81Motivowwds_12_tfmotivotipo_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV81Motivowwds_12_tfmotivotipo_sels, "[MotivoTipo] IN (", ")")+")");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV83Motivowwds_14_tfmotivonombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV82Motivowwds_13_tfmotivonombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER([MotivoNombre]) like UPPER(@lV82Motivowwds_13_tfmotivonombre))");
         }
         else
         {
            GXv_int2[5] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV83Motivowwds_14_tfmotivonombre_sel)) && ! ( StringUtil.StrCmp(AV83Motivowwds_14_tfmotivonombre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([MotivoNombre] = @AV83Motivowwds_14_tfmotivonombre_sel)");
         }
         else
         {
            GXv_int2[6] = 1;
         }
         if ( StringUtil.StrCmp(AV83Motivowwds_14_tfmotivonombre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([MotivoNombre] = ''))");
         }
         scmdbuf += sWhereString;
         if ( ( AV11OrderedBy == 1 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY [MotivoTipo]";
         }
         else if ( ( AV11OrderedBy == 1 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [MotivoTipo] DESC";
         }
         else if ( ( AV11OrderedBy == 2 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY [MotivoId]";
         }
         else if ( ( AV11OrderedBy == 2 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [MotivoId] DESC";
         }
         else if ( ( AV11OrderedBy == 3 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY [MotivoNombre]";
         }
         else if ( ( AV11OrderedBy == 3 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [MotivoNombre] DESC";
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
                     return conditional_P00AZ2(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (bool)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (bool)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (long)dynConstraints[10] , (long)dynConstraints[11] , (int)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (long)dynConstraints[15] , (string)dynConstraints[16] , (short)dynConstraints[17] , (bool)dynConstraints[18] , (string)dynConstraints[19] );
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
          Object[] prmP00AZ2;
          prmP00AZ2 = new Object[] {
          new ParDef("@AV72Motivowwds_3_motivotipo1",GXType.NChar,3,0) ,
          new ParDef("@AV75Motivowwds_6_motivotipo2",GXType.NChar,3,0) ,
          new ParDef("@AV78Motivowwds_9_motivotipo3",GXType.NChar,3,0) ,
          new ParDef("@AV79Motivowwds_10_tfmotivoid",GXType.Decimal,18,0) ,
          new ParDef("@AV80Motivowwds_11_tfmotivoid_to",GXType.Decimal,18,0) ,
          new ParDef("@lV82Motivowwds_13_tfmotivonombre",GXType.Char,80,0) ,
          new ParDef("@AV83Motivowwds_14_tfmotivonombre_sel",GXType.NChar,80,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00AZ2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00AZ2,100, GxCacheFrequency.OFF ,true,false )
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
                ((long[]) buf[1])[0] = rslt.getLong(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 3);
                ((bool[]) buf[3])[0] = rslt.wasNull(3);
                return;
       }
    }

 }

}

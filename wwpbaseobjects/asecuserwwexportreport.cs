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
   public class asecuserwwexportreport : GXWebProcedure, System.Web.SessionState.IRequiresSessionState
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

      public asecuserwwexportreport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public asecuserwwexportreport( IGxContext context )
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
         setOutputFileName("SecUserWWExportReport");
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
            new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWSecUser", out  GXt_boolean1) ;
            AV8IsAuthorized = GXt_boolean1;
            if ( ! AV8IsAuthorized )
            {
               GXKey = Crypto.GetSiteKey( );
               GXEncryptionTmp = "wwpbaseobjects.notauthorized.aspx"+UrlEncode(StringUtil.RTrim(AV76Pgmname));
               CallWebObject(formatLink("wwpbaseobjects.notauthorized.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
               context.wjLocDisableFrm = 1;
            }
            if ( AV8IsAuthorized )
            {
               new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV32WWPContext) ;
               /* Execute user subroutine: 'LOADGRIDSTATE' */
               S161 ();
               if ( returnInSub )
               {
                  cleanup();
                  if (true) return;
               }
               AV47Title = context.GetMessage( "Lista de User", "");
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
            H2P0( true, 0) ;
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
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV49FilterFullText)) )
         {
            H2P0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "WWP_FullTextFilterDescription", ""), 25, Gx_line+0, 163, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV49FilterFullText, "")), 163, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         if ( AV24GridState.gxTpr_Dynamicfilters.Count >= 1 )
         {
            AV25GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV24GridState.gxTpr_Dynamicfilters.Item(1));
            AV12DynamicFiltersSelector1 = AV25GridStateDynamicFilter.gxTpr_Selected;
            if ( StringUtil.StrCmp(AV12DynamicFiltersSelector1, "SECUSERNAME") == 0 )
            {
               AV13DynamicFiltersOperator1 = AV25GridStateDynamicFilter.gxTpr_Operator;
               AV14SecUserName1 = AV25GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV14SecUserName1)) )
               {
                  if ( AV13DynamicFiltersOperator1 == 0 )
                  {
                     AV26FilterSecUserNameDescription = StringUtil.Format( "%1 (%2)", context.GetMessage( "NickName", ""), context.GetMessage( "WWP_FilterLike", ""), "", "", "", "", "", "", "");
                  }
                  else if ( AV13DynamicFiltersOperator1 == 1 )
                  {
                     AV26FilterSecUserNameDescription = StringUtil.Format( "%1 (%2)", context.GetMessage( "NickName", ""), context.GetMessage( "WWP_FilterContains", ""), "", "", "", "", "", "", "");
                  }
                  AV27SecUserName = AV14SecUserName1;
                  H2P0( false, 20) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV26FilterSecUserNameDescription, "")), 25, Gx_line+0, 163, Gx_line+15, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV27SecUserName, "")), 163, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+20);
               }
            }
            else if ( StringUtil.StrCmp(AV12DynamicFiltersSelector1, "USUARIOSID") == 0 )
            {
               AV13DynamicFiltersOperator1 = AV25GridStateDynamicFilter.gxTpr_Operator;
               AV50usuariosId1 = AV25GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV50usuariosId1)) )
               {
                  if ( AV13DynamicFiltersOperator1 == 0 )
                  {
                     AV51FilterusuariosIdDescription = StringUtil.Format( "%1 (%2)", context.GetMessage( "NickName", ""), context.GetMessage( "WWP_FilterLike", ""), "", "", "", "", "", "", "");
                  }
                  else if ( AV13DynamicFiltersOperator1 == 1 )
                  {
                     AV51FilterusuariosIdDescription = StringUtil.Format( "%1 (%2)", context.GetMessage( "NickName", ""), context.GetMessage( "WWP_FilterContains", ""), "", "", "", "", "", "", "");
                  }
                  AV52usuariosId = AV50usuariosId1;
                  H2P0( false, 20) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV51FilterusuariosIdDescription, "")), 25, Gx_line+0, 163, Gx_line+15, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV52usuariosId, "")), 163, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+20);
               }
            }
            if ( AV24GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV15DynamicFiltersEnabled2 = true;
               AV25GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV24GridState.gxTpr_Dynamicfilters.Item(2));
               AV16DynamicFiltersSelector2 = AV25GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV16DynamicFiltersSelector2, "SECUSERNAME") == 0 )
               {
                  AV17DynamicFiltersOperator2 = AV25GridStateDynamicFilter.gxTpr_Operator;
                  AV18SecUserName2 = AV25GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV18SecUserName2)) )
                  {
                     if ( AV17DynamicFiltersOperator2 == 0 )
                     {
                        AV26FilterSecUserNameDescription = StringUtil.Format( "%1 (%2)", context.GetMessage( "NickName", ""), context.GetMessage( "WWP_FilterLike", ""), "", "", "", "", "", "", "");
                     }
                     else if ( AV17DynamicFiltersOperator2 == 1 )
                     {
                        AV26FilterSecUserNameDescription = StringUtil.Format( "%1 (%2)", context.GetMessage( "NickName", ""), context.GetMessage( "WWP_FilterContains", ""), "", "", "", "", "", "", "");
                     }
                     AV27SecUserName = AV18SecUserName2;
                     H2P0( false, 20) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV26FilterSecUserNameDescription, "")), 25, Gx_line+0, 163, Gx_line+15, 0, 0, 0, 0) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV27SecUserName, "")), 163, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                     Gx_OldLine = Gx_line;
                     Gx_line = (int)(Gx_line+20);
                  }
               }
               else if ( StringUtil.StrCmp(AV16DynamicFiltersSelector2, "USUARIOSID") == 0 )
               {
                  AV17DynamicFiltersOperator2 = AV25GridStateDynamicFilter.gxTpr_Operator;
                  AV53usuariosId2 = AV25GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV53usuariosId2)) )
                  {
                     if ( AV17DynamicFiltersOperator2 == 0 )
                     {
                        AV51FilterusuariosIdDescription = StringUtil.Format( "%1 (%2)", context.GetMessage( "NickName", ""), context.GetMessage( "WWP_FilterLike", ""), "", "", "", "", "", "", "");
                     }
                     else if ( AV17DynamicFiltersOperator2 == 1 )
                     {
                        AV51FilterusuariosIdDescription = StringUtil.Format( "%1 (%2)", context.GetMessage( "NickName", ""), context.GetMessage( "WWP_FilterContains", ""), "", "", "", "", "", "", "");
                     }
                     AV52usuariosId = AV53usuariosId2;
                     H2P0( false, 20) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV51FilterusuariosIdDescription, "")), 25, Gx_line+0, 163, Gx_line+15, 0, 0, 0, 0) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV52usuariosId, "")), 163, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                     Gx_OldLine = Gx_line;
                     Gx_line = (int)(Gx_line+20);
                  }
               }
               if ( AV24GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV19DynamicFiltersEnabled3 = true;
                  AV25GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV24GridState.gxTpr_Dynamicfilters.Item(3));
                  AV20DynamicFiltersSelector3 = AV25GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV20DynamicFiltersSelector3, "SECUSERNAME") == 0 )
                  {
                     AV21DynamicFiltersOperator3 = AV25GridStateDynamicFilter.gxTpr_Operator;
                     AV22SecUserName3 = AV25GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV22SecUserName3)) )
                     {
                        if ( AV21DynamicFiltersOperator3 == 0 )
                        {
                           AV26FilterSecUserNameDescription = StringUtil.Format( "%1 (%2)", context.GetMessage( "NickName", ""), context.GetMessage( "WWP_FilterLike", ""), "", "", "", "", "", "", "");
                        }
                        else if ( AV21DynamicFiltersOperator3 == 1 )
                        {
                           AV26FilterSecUserNameDescription = StringUtil.Format( "%1 (%2)", context.GetMessage( "NickName", ""), context.GetMessage( "WWP_FilterContains", ""), "", "", "", "", "", "", "");
                        }
                        AV27SecUserName = AV22SecUserName3;
                        H2P0( false, 20) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV26FilterSecUserNameDescription, "")), 25, Gx_line+0, 163, Gx_line+15, 0, 0, 0, 0) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV27SecUserName, "")), 163, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                        Gx_OldLine = Gx_line;
                        Gx_line = (int)(Gx_line+20);
                     }
                  }
                  else if ( StringUtil.StrCmp(AV20DynamicFiltersSelector3, "USUARIOSID") == 0 )
                  {
                     AV21DynamicFiltersOperator3 = AV25GridStateDynamicFilter.gxTpr_Operator;
                     AV54usuariosId3 = AV25GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV54usuariosId3)) )
                     {
                        if ( AV21DynamicFiltersOperator3 == 0 )
                        {
                           AV51FilterusuariosIdDescription = StringUtil.Format( "%1 (%2)", context.GetMessage( "NickName", ""), context.GetMessage( "WWP_FilterLike", ""), "", "", "", "", "", "", "");
                        }
                        else if ( AV21DynamicFiltersOperator3 == 1 )
                        {
                           AV51FilterusuariosIdDescription = StringUtil.Format( "%1 (%2)", context.GetMessage( "NickName", ""), context.GetMessage( "WWP_FilterContains", ""), "", "", "", "", "", "", "");
                        }
                        AV52usuariosId = AV54usuariosId3;
                        H2P0( false, 20) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV51FilterusuariosIdDescription, "")), 25, Gx_line+0, 163, Gx_line+15, 0, 0, 0, 0) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV52usuariosId, "")), 163, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                        Gx_OldLine = Gx_line;
                        Gx_line = (int)(Gx_line+20);
                     }
                  }
               }
            }
         }
         if ( ! ( (0==AV28TFSecUserId) && (0==AV29TFSecUserId_To) ) )
         {
            H2P0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Usuario Nro.", ""), 25, Gx_line+0, 163, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV28TFSecUserId), "ZZZZZZZZZ9")), 163, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV35TFSecUserId_To_Description = StringUtil.Format( "%1 (%2)", context.GetMessage( "Usuario Nro.", ""), context.GetMessage( "WWP_TSTo", ""), "", "", "", "", "", "", "");
            H2P0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV35TFSecUserId_To_Description, "")), 25, Gx_line+0, 163, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV29TFSecUserId_To), "ZZZZZZZZZ9")), 163, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV31TFSecUserName_Sel)) )
         {
            AV36TempBoolean = (bool)(((StringUtil.StrCmp(AV31TFSecUserName_Sel, "<#Empty#>")==0)));
            AV31TFSecUserName_Sel = (AV36TempBoolean ? context.GetMessage( "WWP_TitleFilter_EmptyOption", "") : AV31TFSecUserName_Sel);
            H2P0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "NickName", ""), 25, Gx_line+0, 163, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV31TFSecUserName_Sel, "")), 163, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV31TFSecUserName_Sel = (AV36TempBoolean ? "<#Empty#>" : AV31TFSecUserName_Sel);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV30TFSecUserName)) )
            {
               H2P0( false, 20) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(context.GetMessage( "NickName", ""), 25, Gx_line+0, 163, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV30TFSecUserName, "")), 163, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV58TFSecUserFullName_Sel)) )
         {
            AV36TempBoolean = (bool)(((StringUtil.StrCmp(AV58TFSecUserFullName_Sel, "<#Empty#>")==0)));
            AV58TFSecUserFullName_Sel = (AV36TempBoolean ? context.GetMessage( "WWP_TitleFilter_EmptyOption", "") : AV58TFSecUserFullName_Sel);
            H2P0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Nombre Completo", ""), 25, Gx_line+0, 163, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV58TFSecUserFullName_Sel, "")), 163, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV58TFSecUserFullName_Sel = (AV36TempBoolean ? "<#Empty#>" : AV58TFSecUserFullName_Sel);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57TFSecUserFullName)) )
            {
               H2P0( false, 20) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(context.GetMessage( "Nombre Completo", ""), 25, Gx_line+0, 163, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV57TFSecUserFullName, "")), 163, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60TFusuariosId_Sel)) )
         {
            AV36TempBoolean = (bool)(((StringUtil.StrCmp(AV60TFusuariosId_Sel, "<#Empty#>")==0)));
            AV60TFusuariosId_Sel = (AV36TempBoolean ? context.GetMessage( "WWP_TitleFilter_EmptyOption", "") : AV60TFusuariosId_Sel);
            H2P0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "NickName", ""), 25, Gx_line+0, 163, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV60TFusuariosId_Sel, "")), 163, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV60TFusuariosId_Sel = (AV36TempBoolean ? "<#Empty#>" : AV60TFusuariosId_Sel);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59TFusuariosId)) )
            {
               H2P0( false, 20) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(context.GetMessage( "NickName", ""), 25, Gx_line+0, 163, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV59TFusuariosId, "")), 163, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62TFusuariosNombre_Sel)) )
         {
            AV36TempBoolean = (bool)(((StringUtil.StrCmp(AV62TFusuariosNombre_Sel, "<#Empty#>")==0)));
            AV62TFusuariosNombre_Sel = (AV36TempBoolean ? context.GetMessage( "WWP_TitleFilter_EmptyOption", "") : AV62TFusuariosNombre_Sel);
            H2P0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Nombre", ""), 25, Gx_line+0, 163, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV62TFusuariosNombre_Sel, "")), 163, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV62TFusuariosNombre_Sel = (AV36TempBoolean ? "<#Empty#>" : AV62TFusuariosNombre_Sel);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61TFusuariosNombre)) )
            {
               H2P0( false, 20) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(context.GetMessage( "Nombre", ""), 25, Gx_line+0, 163, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV61TFusuariosNombre, "")), 163, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
         AV65TFusuariosEstado_Sels.FromJSonString(AV63TFusuariosEstado_SelsJson, null);
         if ( ! ( AV65TFusuariosEstado_Sels.Count == 0 ) )
         {
            AV73i = 1;
            AV79GXV1 = 1;
            while ( AV79GXV1 <= AV65TFusuariosEstado_Sels.Count )
            {
               AV66TFusuariosEstado_Sel = AV65TFusuariosEstado_Sels.GetString(AV79GXV1);
               if ( AV73i == 1 )
               {
                  AV64TFusuariosEstado_SelDscs = "";
               }
               else
               {
                  AV64TFusuariosEstado_SelDscs += ", ";
               }
               AV71FilterTFusuariosEstado_SelValueDescription = context.GetMessage( gxdomainestadoenum.getDescription(context,AV66TFusuariosEstado_Sel), "");
               AV64TFusuariosEstado_SelDscs += AV71FilterTFusuariosEstado_SelValueDescription;
               AV73i = (long)(AV73i+1);
               AV79GXV1 = (int)(AV79GXV1+1);
            }
            H2P0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "usuarios Estado", ""), 25, Gx_line+0, 163, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV64TFusuariosEstado_SelDscs, "")), 163, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         AV69TFSecUserEstado_Sels.FromJSonString(AV67TFSecUserEstado_SelsJson, null);
         if ( ! ( AV69TFSecUserEstado_Sels.Count == 0 ) )
         {
            AV73i = 1;
            AV80GXV2 = 1;
            while ( AV80GXV2 <= AV69TFSecUserEstado_Sels.Count )
            {
               AV70TFSecUserEstado_Sel = AV69TFSecUserEstado_Sels.GetString(AV80GXV2);
               if ( AV73i == 1 )
               {
                  AV68TFSecUserEstado_SelDscs = "";
               }
               else
               {
                  AV68TFSecUserEstado_SelDscs += ", ";
               }
               AV72FilterTFSecUserEstado_SelValueDescription = context.GetMessage( gxdomainestadoenum.getDescription(context,AV70TFSecUserEstado_Sel), "");
               AV68TFSecUserEstado_SelDscs += AV72FilterTFSecUserEstado_SelValueDescription;
               AV73i = (long)(AV73i+1);
               AV80GXV2 = (int)(AV80GXV2+1);
            }
            H2P0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Estado", ""), 25, Gx_line+0, 163, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV68TFSecUserEstado_SelDscs, "")), 163, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75TFSecUserPassword_Sel)) )
         {
            AV36TempBoolean = (bool)(((StringUtil.StrCmp(AV75TFSecUserPassword_Sel, "<#Empty#>")==0)));
            AV75TFSecUserPassword_Sel = (AV36TempBoolean ? context.GetMessage( "WWP_TitleFilter_EmptyOption", "") : AV75TFSecUserPassword_Sel);
            H2P0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Password", ""), 25, Gx_line+0, 163, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV75TFSecUserPassword_Sel, "")), 163, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV75TFSecUserPassword_Sel = (AV36TempBoolean ? "<#Empty#>" : AV75TFSecUserPassword_Sel);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74TFSecUserPassword)) )
            {
               H2P0( false, 20) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(context.GetMessage( "Password", ""), 25, Gx_line+0, 163, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV74TFSecUserPassword, "")), 163, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
      }

      protected void S121( )
      {
         /* 'PRINTCOLUMNTITLES' Routine */
         returnInSub = false;
         H2P0( false, 22) ;
         getPrinter().GxDrawLine(25, Gx_line+21, 789, Gx_line+21, 2, 8, 160, 134, 0) ;
         Gx_OldLine = Gx_line;
         Gx_line = (int)(Gx_line+22);
         H2P0( false, 37) ;
         getPrinter().GxAttris("Microsoft Sans Serif", 9, false, false, false, false, 0, 8, 160, 134, 0, 255, 255, 255) ;
         getPrinter().GxDrawText(context.GetMessage( "Usuario Nro.", ""), 30, Gx_line+10, 110, Gx_line+27, 2, 0, 0, 0) ;
         getPrinter().GxDrawText(context.GetMessage( "NickName", ""), 114, Gx_line+10, 194, Gx_line+27, 0, 0, 0, 0) ;
         getPrinter().GxDrawText(context.GetMessage( "Nombre Completo", ""), 198, Gx_line+10, 278, Gx_line+27, 0, 0, 0, 0) ;
         getPrinter().GxDrawText(context.GetMessage( "NickName", ""), 282, Gx_line+10, 362, Gx_line+27, 0, 0, 0, 0) ;
         getPrinter().GxDrawText(context.GetMessage( "Nombre", ""), 366, Gx_line+10, 446, Gx_line+27, 0, 0, 0, 0) ;
         getPrinter().GxDrawText(context.GetMessage( "usuarios Estado", ""), 450, Gx_line+10, 530, Gx_line+27, 0, 0, 0, 0) ;
         getPrinter().GxDrawText(context.GetMessage( "Imagen", ""), 534, Gx_line+10, 615, Gx_line+27, 0, 0, 0, 0) ;
         getPrinter().GxDrawText(context.GetMessage( "Estado", ""), 619, Gx_line+10, 701, Gx_line+27, 0, 0, 0, 0) ;
         getPrinter().GxDrawText(context.GetMessage( "Password", ""), 705, Gx_line+10, 787, Gx_line+27, 0, 0, 0, 0) ;
         Gx_OldLine = Gx_line;
         Gx_line = (int)(Gx_line+37);
      }

      protected void S131( )
      {
         /* 'PRINTDATA' Routine */
         returnInSub = false;
         AV82Wwpbaseobjects_secuserwwds_1_filterfulltext = AV49FilterFullText;
         AV83Wwpbaseobjects_secuserwwds_2_dynamicfiltersselector1 = AV12DynamicFiltersSelector1;
         AV84Wwpbaseobjects_secuserwwds_3_dynamicfiltersoperator1 = AV13DynamicFiltersOperator1;
         AV85Wwpbaseobjects_secuserwwds_4_secusername1 = AV14SecUserName1;
         AV86Wwpbaseobjects_secuserwwds_5_usuariosid1 = AV50usuariosId1;
         AV87Wwpbaseobjects_secuserwwds_6_dynamicfiltersenabled2 = AV15DynamicFiltersEnabled2;
         AV88Wwpbaseobjects_secuserwwds_7_dynamicfiltersselector2 = AV16DynamicFiltersSelector2;
         AV89Wwpbaseobjects_secuserwwds_8_dynamicfiltersoperator2 = AV17DynamicFiltersOperator2;
         AV90Wwpbaseobjects_secuserwwds_9_secusername2 = AV18SecUserName2;
         AV91Wwpbaseobjects_secuserwwds_10_usuariosid2 = AV53usuariosId2;
         AV92Wwpbaseobjects_secuserwwds_11_dynamicfiltersenabled3 = AV19DynamicFiltersEnabled3;
         AV93Wwpbaseobjects_secuserwwds_12_dynamicfiltersselector3 = AV20DynamicFiltersSelector3;
         AV94Wwpbaseobjects_secuserwwds_13_dynamicfiltersoperator3 = AV21DynamicFiltersOperator3;
         AV95Wwpbaseobjects_secuserwwds_14_secusername3 = AV22SecUserName3;
         AV96Wwpbaseobjects_secuserwwds_15_usuariosid3 = AV54usuariosId3;
         AV97Wwpbaseobjects_secuserwwds_16_tfsecuserid = AV28TFSecUserId;
         AV98Wwpbaseobjects_secuserwwds_17_tfsecuserid_to = AV29TFSecUserId_To;
         AV99Wwpbaseobjects_secuserwwds_18_tfsecusername = AV30TFSecUserName;
         AV100Wwpbaseobjects_secuserwwds_19_tfsecusername_sel = AV31TFSecUserName_Sel;
         AV101Wwpbaseobjects_secuserwwds_20_tfsecuserfullname = AV57TFSecUserFullName;
         AV102Wwpbaseobjects_secuserwwds_21_tfsecuserfullname_sel = AV58TFSecUserFullName_Sel;
         AV103Wwpbaseobjects_secuserwwds_22_tfusuariosid = AV59TFusuariosId;
         AV104Wwpbaseobjects_secuserwwds_23_tfusuariosid_sel = AV60TFusuariosId_Sel;
         AV105Wwpbaseobjects_secuserwwds_24_tfusuariosnombre = AV61TFusuariosNombre;
         AV106Wwpbaseobjects_secuserwwds_25_tfusuariosnombre_sel = AV62TFusuariosNombre_Sel;
         AV107Wwpbaseobjects_secuserwwds_26_tfusuariosestado_sels = AV65TFusuariosEstado_Sels;
         AV108Wwpbaseobjects_secuserwwds_27_tfsecuserestado_sels = AV69TFSecUserEstado_Sels;
         AV109Wwpbaseobjects_secuserwwds_28_tfsecuserpassword = AV74TFSecUserPassword;
         AV110Wwpbaseobjects_secuserwwds_29_tfsecuserpassword_sel = AV75TFSecUserPassword_Sel;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A226usuariosEstado ,
                                              AV107Wwpbaseobjects_secuserwwds_26_tfusuariosestado_sels ,
                                              A550SecUserEstado ,
                                              AV108Wwpbaseobjects_secuserwwds_27_tfsecuserestado_sels ,
                                              AV83Wwpbaseobjects_secuserwwds_2_dynamicfiltersselector1 ,
                                              AV84Wwpbaseobjects_secuserwwds_3_dynamicfiltersoperator1 ,
                                              AV85Wwpbaseobjects_secuserwwds_4_secusername1 ,
                                              AV86Wwpbaseobjects_secuserwwds_5_usuariosid1 ,
                                              AV87Wwpbaseobjects_secuserwwds_6_dynamicfiltersenabled2 ,
                                              AV88Wwpbaseobjects_secuserwwds_7_dynamicfiltersselector2 ,
                                              AV89Wwpbaseobjects_secuserwwds_8_dynamicfiltersoperator2 ,
                                              AV90Wwpbaseobjects_secuserwwds_9_secusername2 ,
                                              AV91Wwpbaseobjects_secuserwwds_10_usuariosid2 ,
                                              AV92Wwpbaseobjects_secuserwwds_11_dynamicfiltersenabled3 ,
                                              AV93Wwpbaseobjects_secuserwwds_12_dynamicfiltersselector3 ,
                                              AV94Wwpbaseobjects_secuserwwds_13_dynamicfiltersoperator3 ,
                                              AV95Wwpbaseobjects_secuserwwds_14_secusername3 ,
                                              AV96Wwpbaseobjects_secuserwwds_15_usuariosid3 ,
                                              AV97Wwpbaseobjects_secuserwwds_16_tfsecuserid ,
                                              AV98Wwpbaseobjects_secuserwwds_17_tfsecuserid_to ,
                                              AV100Wwpbaseobjects_secuserwwds_19_tfsecusername_sel ,
                                              AV99Wwpbaseobjects_secuserwwds_18_tfsecusername ,
                                              AV102Wwpbaseobjects_secuserwwds_21_tfsecuserfullname_sel ,
                                              AV101Wwpbaseobjects_secuserwwds_20_tfsecuserfullname ,
                                              AV104Wwpbaseobjects_secuserwwds_23_tfusuariosid_sel ,
                                              AV103Wwpbaseobjects_secuserwwds_22_tfusuariosid ,
                                              AV106Wwpbaseobjects_secuserwwds_25_tfusuariosnombre_sel ,
                                              AV105Wwpbaseobjects_secuserwwds_24_tfusuariosnombre ,
                                              AV107Wwpbaseobjects_secuserwwds_26_tfusuariosestado_sels.Count ,
                                              AV108Wwpbaseobjects_secuserwwds_27_tfsecuserestado_sels.Count ,
                                              AV110Wwpbaseobjects_secuserwwds_29_tfsecuserpassword_sel ,
                                              AV109Wwpbaseobjects_secuserwwds_28_tfsecuserpassword ,
                                              A26SecUserName ,
                                              A145usuariosId ,
                                              A18SecUserId ,
                                              A587SecUserFullName ,
                                              A222usuariosNombre ,
                                              A27SecUserPassword ,
                                              AV10OrderedBy ,
                                              AV11OrderedDsc ,
                                              AV82Wwpbaseobjects_secuserwwds_1_filterfulltext } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.INT, TypeConstants.INT,
                                              TypeConstants.BOOLEAN, TypeConstants.LONG, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV85Wwpbaseobjects_secuserwwds_4_secusername1 = StringUtil.Concat( StringUtil.RTrim( AV85Wwpbaseobjects_secuserwwds_4_secusername1), "%", "");
         lV85Wwpbaseobjects_secuserwwds_4_secusername1 = StringUtil.Concat( StringUtil.RTrim( AV85Wwpbaseobjects_secuserwwds_4_secusername1), "%", "");
         lV86Wwpbaseobjects_secuserwwds_5_usuariosid1 = StringUtil.PadR( StringUtil.RTrim( AV86Wwpbaseobjects_secuserwwds_5_usuariosid1), 20, "%");
         lV86Wwpbaseobjects_secuserwwds_5_usuariosid1 = StringUtil.PadR( StringUtil.RTrim( AV86Wwpbaseobjects_secuserwwds_5_usuariosid1), 20, "%");
         lV90Wwpbaseobjects_secuserwwds_9_secusername2 = StringUtil.Concat( StringUtil.RTrim( AV90Wwpbaseobjects_secuserwwds_9_secusername2), "%", "");
         lV90Wwpbaseobjects_secuserwwds_9_secusername2 = StringUtil.Concat( StringUtil.RTrim( AV90Wwpbaseobjects_secuserwwds_9_secusername2), "%", "");
         lV91Wwpbaseobjects_secuserwwds_10_usuariosid2 = StringUtil.PadR( StringUtil.RTrim( AV91Wwpbaseobjects_secuserwwds_10_usuariosid2), 20, "%");
         lV91Wwpbaseobjects_secuserwwds_10_usuariosid2 = StringUtil.PadR( StringUtil.RTrim( AV91Wwpbaseobjects_secuserwwds_10_usuariosid2), 20, "%");
         lV95Wwpbaseobjects_secuserwwds_14_secusername3 = StringUtil.Concat( StringUtil.RTrim( AV95Wwpbaseobjects_secuserwwds_14_secusername3), "%", "");
         lV95Wwpbaseobjects_secuserwwds_14_secusername3 = StringUtil.Concat( StringUtil.RTrim( AV95Wwpbaseobjects_secuserwwds_14_secusername3), "%", "");
         lV96Wwpbaseobjects_secuserwwds_15_usuariosid3 = StringUtil.PadR( StringUtil.RTrim( AV96Wwpbaseobjects_secuserwwds_15_usuariosid3), 20, "%");
         lV96Wwpbaseobjects_secuserwwds_15_usuariosid3 = StringUtil.PadR( StringUtil.RTrim( AV96Wwpbaseobjects_secuserwwds_15_usuariosid3), 20, "%");
         lV99Wwpbaseobjects_secuserwwds_18_tfsecusername = StringUtil.Concat( StringUtil.RTrim( AV99Wwpbaseobjects_secuserwwds_18_tfsecusername), "%", "");
         lV101Wwpbaseobjects_secuserwwds_20_tfsecuserfullname = StringUtil.Concat( StringUtil.RTrim( AV101Wwpbaseobjects_secuserwwds_20_tfsecuserfullname), "%", "");
         lV103Wwpbaseobjects_secuserwwds_22_tfusuariosid = StringUtil.PadR( StringUtil.RTrim( AV103Wwpbaseobjects_secuserwwds_22_tfusuariosid), 20, "%");
         lV105Wwpbaseobjects_secuserwwds_24_tfusuariosnombre = StringUtil.PadR( StringUtil.RTrim( AV105Wwpbaseobjects_secuserwwds_24_tfusuariosnombre), 80, "%");
         lV109Wwpbaseobjects_secuserwwds_28_tfsecuserpassword = StringUtil.Concat( StringUtil.RTrim( AV109Wwpbaseobjects_secuserwwds_28_tfsecuserpassword), "%", "");
         /* Using cursor P002P2 */
         pr_default.execute(0, new Object[] {lV85Wwpbaseobjects_secuserwwds_4_secusername1, lV85Wwpbaseobjects_secuserwwds_4_secusername1, lV86Wwpbaseobjects_secuserwwds_5_usuariosid1, lV86Wwpbaseobjects_secuserwwds_5_usuariosid1, lV90Wwpbaseobjects_secuserwwds_9_secusername2, lV90Wwpbaseobjects_secuserwwds_9_secusername2, lV91Wwpbaseobjects_secuserwwds_10_usuariosid2, lV91Wwpbaseobjects_secuserwwds_10_usuariosid2, lV95Wwpbaseobjects_secuserwwds_14_secusername3, lV95Wwpbaseobjects_secuserwwds_14_secusername3, lV96Wwpbaseobjects_secuserwwds_15_usuariosid3, lV96Wwpbaseobjects_secuserwwds_15_usuariosid3, AV97Wwpbaseobjects_secuserwwds_16_tfsecuserid, AV98Wwpbaseobjects_secuserwwds_17_tfsecuserid_to, lV99Wwpbaseobjects_secuserwwds_18_tfsecusername, AV100Wwpbaseobjects_secuserwwds_19_tfsecusername_sel, lV101Wwpbaseobjects_secuserwwds_20_tfsecuserfullname, AV102Wwpbaseobjects_secuserwwds_21_tfsecuserfullname_sel, lV103Wwpbaseobjects_secuserwwds_22_tfusuariosid, AV104Wwpbaseobjects_secuserwwds_23_tfusuariosid_sel, lV105Wwpbaseobjects_secuserwwds_24_tfusuariosnombre, AV106Wwpbaseobjects_secuserwwds_25_tfusuariosnombre_sel, lV109Wwpbaseobjects_secuserwwds_28_tfsecuserpassword, AV110Wwpbaseobjects_secuserwwds_29_tfsecuserpassword_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A27SecUserPassword = P002P2_A27SecUserPassword[0];
            A222usuariosNombre = P002P2_A222usuariosNombre[0];
            A145usuariosId = P002P2_A145usuariosId[0];
            n145usuariosId = P002P2_n145usuariosId[0];
            A587SecUserFullName = P002P2_A587SecUserFullName[0];
            A26SecUserName = P002P2_A26SecUserName[0];
            A18SecUserId = P002P2_A18SecUserId[0];
            A550SecUserEstado = P002P2_A550SecUserEstado[0];
            n550SecUserEstado = P002P2_n550SecUserEstado[0];
            A226usuariosEstado = P002P2_A226usuariosEstado[0];
            A40000usuariosImagen_GXI = P002P2_A40000usuariosImagen_GXI[0];
            A266usuariosImagen = P002P2_A266usuariosImagen[0];
            A222usuariosNombre = P002P2_A222usuariosNombre[0];
            A226usuariosEstado = P002P2_A226usuariosEstado[0];
            A40000usuariosImagen_GXI = P002P2_A40000usuariosImagen_GXI[0];
            A266usuariosImagen = P002P2_A266usuariosImagen[0];
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV82Wwpbaseobjects_secuserwwds_1_filterfulltext)) || ( ( StringUtil.Like( StringUtil.Str( (decimal)(A18SecUserId), 10, 0) , StringUtil.PadR( "%" + AV82Wwpbaseobjects_secuserwwds_1_filterfulltext , 254 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Upper( A26SecUserName) , StringUtil.PadR( "%" + StringUtil.Upper( AV82Wwpbaseobjects_secuserwwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A587SecUserFullName) , StringUtil.PadR( "%" + StringUtil.Upper( AV82Wwpbaseobjects_secuserwwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Upper( A145usuariosId) , StringUtil.PadR( "%" + StringUtil.Upper( AV82Wwpbaseobjects_secuserwwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A222usuariosNombre) , StringUtil.PadR( "%" + StringUtil.Upper( AV82Wwpbaseobjects_secuserwwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( context.GetMessage( "habilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV82Wwpbaseobjects_secuserwwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A226usuariosEstado, "HAB") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "deshabilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV82Wwpbaseobjects_secuserwwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A226usuariosEstado, "DES") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "pendiente", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV82Wwpbaseobjects_secuserwwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A226usuariosEstado, "PEN") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "habilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV82Wwpbaseobjects_secuserwwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A550SecUserEstado, "HAB") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "deshabilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV82Wwpbaseobjects_secuserwwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A550SecUserEstado, "DES") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "pendiente", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV82Wwpbaseobjects_secuserwwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A550SecUserEstado, "PEN") == 0 ) ) || ( StringUtil.Like( StringUtil.Upper( A27SecUserPassword) , StringUtil.PadR( "%" + StringUtil.Upper( AV82Wwpbaseobjects_secuserwwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) )
            )
            {
               AV55usuariosEstadoDescription = context.GetMessage( gxdomainestadoenum.getDescription(context,A226usuariosEstado), "");
               AV56SecUserEstadoDescription = context.GetMessage( gxdomainestadoenum.getDescription(context,A550SecUserEstado), "");
               /* Execute user subroutine: 'BEFOREPRINTLINE' */
               S144 ();
               if ( returnInSub )
               {
                  pr_default.close(0);
                  returnInSub = true;
                  if (true) return;
               }
               if ( StringUtil.StrCmp(A550SecUserEstado, "PEN") == 0 )
               {
                  H2P0( false, 36) ;
                  getPrinter().GxDrawRect(28, Gx_line+0, 789, Gx_line+35, 1, 0, 0, 0, 1, 250, 242, 204, 1, 1, 1, 1, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 251, 110, 82, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(A18SecUserId), "ZZZZZZZZZ9")), 30, Gx_line+10, 110, Gx_line+25, 2+16, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A26SecUserName, "")), 114, Gx_line+10, 194, Gx_line+25, 0+16, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A587SecUserFullName, "")), 198, Gx_line+10, 278, Gx_line+25, 0+16, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A145usuariosId, "")), 282, Gx_line+10, 362, Gx_line+25, 0+16, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A222usuariosNombre, "")), 366, Gx_line+10, 446, Gx_line+25, 0+16, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV55usuariosEstadoDescription, "")), 450, Gx_line+10, 530, Gx_line+25, 0+16, 0, 0, 0) ;
                  sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( A266usuariosImagen)) ? A40000usuariosImagen_GXI : A266usuariosImagen);
                  getPrinter().GxDrawBitMap(sImgUrl, 534, Gx_line+10, 615, Gx_line+25) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV56SecUserEstadoDescription, "")), 619, Gx_line+10, 701, Gx_line+25, 0+16, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A27SecUserPassword, "")), 705, Gx_line+10, 787, Gx_line+25, 0+16, 0, 0, 0) ;
                  getPrinter().GxDrawLine(28, Gx_line+35, 789, Gx_line+35, 1, 220, 220, 220, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+36);
               }
               else if ( StringUtil.StrCmp(A550SecUserEstado, "DES") == 0 )
               {
                  H2P0( false, 36) ;
                  getPrinter().GxDrawRect(28, Gx_line+0, 789, Gx_line+35, 1, 0, 0, 0, 1, 242, 222, 222, 1, 1, 1, 1, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 221, 75, 57, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(A18SecUserId), "ZZZZZZZZZ9")), 30, Gx_line+10, 110, Gx_line+25, 2+16, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A26SecUserName, "")), 114, Gx_line+10, 194, Gx_line+25, 0+16, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A587SecUserFullName, "")), 198, Gx_line+10, 278, Gx_line+25, 0+16, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A145usuariosId, "")), 282, Gx_line+10, 362, Gx_line+25, 0+16, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A222usuariosNombre, "")), 366, Gx_line+10, 446, Gx_line+25, 0+16, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV55usuariosEstadoDescription, "")), 450, Gx_line+10, 530, Gx_line+25, 0+16, 0, 0, 0) ;
                  sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( A266usuariosImagen)) ? A40000usuariosImagen_GXI : A266usuariosImagen);
                  getPrinter().GxDrawBitMap(sImgUrl, 534, Gx_line+10, 615, Gx_line+25) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV56SecUserEstadoDescription, "")), 619, Gx_line+10, 701, Gx_line+25, 0+16, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A27SecUserPassword, "")), 705, Gx_line+10, 787, Gx_line+25, 0+16, 0, 0, 0) ;
                  getPrinter().GxDrawLine(28, Gx_line+35, 789, Gx_line+35, 1, 220, 220, 220, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+36);
               }
               else
               {
                  H2P0( false, 36) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(A18SecUserId), "ZZZZZZZZZ9")), 30, Gx_line+10, 110, Gx_line+25, 2+16, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A26SecUserName, "")), 114, Gx_line+10, 194, Gx_line+25, 0+16, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A587SecUserFullName, "")), 198, Gx_line+10, 278, Gx_line+25, 0+16, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A145usuariosId, "")), 282, Gx_line+10, 362, Gx_line+25, 0+16, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A222usuariosNombre, "")), 366, Gx_line+10, 446, Gx_line+25, 0+16, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV55usuariosEstadoDescription, "")), 450, Gx_line+10, 530, Gx_line+25, 0+16, 0, 0, 0) ;
                  sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( A266usuariosImagen)) ? A40000usuariosImagen_GXI : A266usuariosImagen);
                  getPrinter().GxDrawBitMap(sImgUrl, 534, Gx_line+10, 615, Gx_line+25) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV56SecUserEstadoDescription, "")), 619, Gx_line+10, 701, Gx_line+25, 0+16, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A27SecUserPassword, "")), 705, Gx_line+10, 787, Gx_line+25, 0+16, 0, 0, 0) ;
                  getPrinter().GxDrawLine(28, Gx_line+35, 789, Gx_line+35, 1, 220, 220, 220, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+36);
               }
               /* Execute user subroutine: 'AFTERPRINTLINE' */
               S154 ();
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

      protected void S161( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV33Session.Get("WWPBaseObjects.SecUserWWGridState"), "") == 0 )
         {
            AV24GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "WWPBaseObjects.SecUserWWGridState"), null, "", "");
         }
         else
         {
            AV24GridState.FromXml(AV33Session.Get("WWPBaseObjects.SecUserWWGridState"), null, "", "");
         }
         AV10OrderedBy = AV24GridState.gxTpr_Orderedby;
         AV11OrderedDsc = AV24GridState.gxTpr_Ordereddsc;
         AV111GXV3 = 1;
         while ( AV111GXV3 <= AV24GridState.gxTpr_Filtervalues.Count )
         {
            AV34GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV24GridState.gxTpr_Filtervalues.Item(AV111GXV3));
            if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV49FilterFullText = AV34GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFSECUSERID") == 0 )
            {
               AV28TFSecUserId = (long)(Math.Round(NumberUtil.Val( AV34GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV29TFSecUserId_To = (long)(Math.Round(NumberUtil.Val( AV34GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFSECUSERNAME") == 0 )
            {
               AV30TFSecUserName = AV34GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFSECUSERNAME_SEL") == 0 )
            {
               AV31TFSecUserName_Sel = AV34GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFSECUSERFULLNAME") == 0 )
            {
               AV57TFSecUserFullName = AV34GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFSECUSERFULLNAME_SEL") == 0 )
            {
               AV58TFSecUserFullName_Sel = AV34GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFUSUARIOSID") == 0 )
            {
               AV59TFusuariosId = AV34GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFUSUARIOSID_SEL") == 0 )
            {
               AV60TFusuariosId_Sel = AV34GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFUSUARIOSNOMBRE") == 0 )
            {
               AV61TFusuariosNombre = AV34GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFUSUARIOSNOMBRE_SEL") == 0 )
            {
               AV62TFusuariosNombre_Sel = AV34GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFUSUARIOSESTADO_SEL") == 0 )
            {
               AV63TFusuariosEstado_SelsJson = AV34GridStateFilterValue.gxTpr_Value;
               AV65TFusuariosEstado_Sels.FromJSonString(AV63TFusuariosEstado_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFSECUSERESTADO_SEL") == 0 )
            {
               AV67TFSecUserEstado_SelsJson = AV34GridStateFilterValue.gxTpr_Value;
               AV69TFSecUserEstado_Sels.FromJSonString(AV67TFSecUserEstado_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFSECUSERPASSWORD") == 0 )
            {
               AV74TFSecUserPassword = AV34GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFSECUSERPASSWORD_SEL") == 0 )
            {
               AV75TFSecUserPassword_Sel = AV34GridStateFilterValue.gxTpr_Value;
            }
            AV111GXV3 = (int)(AV111GXV3+1);
         }
      }

      protected void S144( )
      {
         /* 'BEFOREPRINTLINE' Routine */
         returnInSub = false;
      }

      protected void S154( )
      {
         /* 'AFTERPRINTLINE' Routine */
         returnInSub = false;
      }

      protected void S171( )
      {
         /* 'PRINTFOOTER' Routine */
         returnInSub = false;
      }

      protected void H2P0( bool bFoot ,
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
                  AV45PageInfo = context.GetMessage( "Page: ", "") + StringUtil.Trim( StringUtil.Str( (decimal)(Gx_page), 6, 0));
                  AV42DateInfo = context.GetMessage( "Date: ", "") + context.localUtil.Format( Gx_date, "99/99/99");
                  getPrinter().GxDrawRect(0, Gx_line+5, 819, Gx_line+40, 1, 0, 0, 0, 1, 8, 160, 134, 1, 1, 1, 1, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV45PageInfo, "")), 30, Gx_line+15, 409, Gx_line+30, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV42DateInfo, "")), 409, Gx_line+15, 789, Gx_line+30, 2, 0, 0, 0) ;
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
               AV40AppName = context.GetMessage( "DVelop Software Solutions", "");
               AV46Phone = "+1 550 8923";
               AV44Mail = "info@mail.com";
               AV48Website = "http://www.web.com";
               AV37AddressLine1 = "French Boulevard 2859";
               AV38AddressLine2 = "Downtown";
               AV39AddressLine3 = "Paris, France";
               getPrinter().GxDrawRect(0, Gx_line+0, 819, Gx_line+108, 1, 0, 0, 0, 1, 8, 160, 134, 1, 1, 1, 1, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV40AppName, "")), 30, Gx_line+30, 283, Gx_line+45, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 20, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV47Title, "")), 30, Gx_line+45, 283, Gx_line+78, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV46Phone, "")), 283, Gx_line+30, 536, Gx_line+46, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV44Mail, "")), 283, Gx_line+46, 536, Gx_line+62, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV48Website, "")), 283, Gx_line+62, 536, Gx_line+78, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV37AddressLine1, "")), 536, Gx_line+30, 789, Gx_line+46, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV38AddressLine2, "")), 536, Gx_line+46, 789, Gx_line+62, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV39AddressLine3, "")), 536, Gx_line+62, 789, Gx_line+78, 2, 0, 0, 0) ;
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
         AV76Pgmname = "";
         GXEncryptionTmp = "";
         AV32WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV47Title = "";
         AV49FilterFullText = "";
         AV24GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV25GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV12DynamicFiltersSelector1 = "";
         AV14SecUserName1 = "";
         AV26FilterSecUserNameDescription = "";
         AV27SecUserName = "";
         AV50usuariosId1 = "";
         AV51FilterusuariosIdDescription = "";
         AV52usuariosId = "";
         AV16DynamicFiltersSelector2 = "";
         AV18SecUserName2 = "";
         AV53usuariosId2 = "";
         AV20DynamicFiltersSelector3 = "";
         AV22SecUserName3 = "";
         AV54usuariosId3 = "";
         AV35TFSecUserId_To_Description = "";
         AV31TFSecUserName_Sel = "";
         AV30TFSecUserName = "";
         AV58TFSecUserFullName_Sel = "";
         AV57TFSecUserFullName = "";
         AV60TFusuariosId_Sel = "";
         AV59TFusuariosId = "";
         AV62TFusuariosNombre_Sel = "";
         AV61TFusuariosNombre = "";
         AV65TFusuariosEstado_Sels = new GxSimpleCollection<string>();
         AV63TFusuariosEstado_SelsJson = "";
         AV66TFusuariosEstado_Sel = "";
         AV64TFusuariosEstado_SelDscs = "";
         AV71FilterTFusuariosEstado_SelValueDescription = "";
         AV69TFSecUserEstado_Sels = new GxSimpleCollection<string>();
         AV67TFSecUserEstado_SelsJson = "";
         AV70TFSecUserEstado_Sel = "";
         AV68TFSecUserEstado_SelDscs = "";
         AV72FilterTFSecUserEstado_SelValueDescription = "";
         AV75TFSecUserPassword_Sel = "";
         AV74TFSecUserPassword = "";
         AV82Wwpbaseobjects_secuserwwds_1_filterfulltext = "";
         AV83Wwpbaseobjects_secuserwwds_2_dynamicfiltersselector1 = "";
         AV85Wwpbaseobjects_secuserwwds_4_secusername1 = "";
         AV86Wwpbaseobjects_secuserwwds_5_usuariosid1 = "";
         AV88Wwpbaseobjects_secuserwwds_7_dynamicfiltersselector2 = "";
         AV90Wwpbaseobjects_secuserwwds_9_secusername2 = "";
         AV91Wwpbaseobjects_secuserwwds_10_usuariosid2 = "";
         AV93Wwpbaseobjects_secuserwwds_12_dynamicfiltersselector3 = "";
         AV95Wwpbaseobjects_secuserwwds_14_secusername3 = "";
         AV96Wwpbaseobjects_secuserwwds_15_usuariosid3 = "";
         AV99Wwpbaseobjects_secuserwwds_18_tfsecusername = "";
         AV100Wwpbaseobjects_secuserwwds_19_tfsecusername_sel = "";
         AV101Wwpbaseobjects_secuserwwds_20_tfsecuserfullname = "";
         AV102Wwpbaseobjects_secuserwwds_21_tfsecuserfullname_sel = "";
         AV103Wwpbaseobjects_secuserwwds_22_tfusuariosid = "";
         AV104Wwpbaseobjects_secuserwwds_23_tfusuariosid_sel = "";
         AV105Wwpbaseobjects_secuserwwds_24_tfusuariosnombre = "";
         AV106Wwpbaseobjects_secuserwwds_25_tfusuariosnombre_sel = "";
         AV107Wwpbaseobjects_secuserwwds_26_tfusuariosestado_sels = new GxSimpleCollection<string>();
         AV108Wwpbaseobjects_secuserwwds_27_tfsecuserestado_sels = new GxSimpleCollection<string>();
         AV109Wwpbaseobjects_secuserwwds_28_tfsecuserpassword = "";
         AV110Wwpbaseobjects_secuserwwds_29_tfsecuserpassword_sel = "";
         lV82Wwpbaseobjects_secuserwwds_1_filterfulltext = "";
         lV85Wwpbaseobjects_secuserwwds_4_secusername1 = "";
         lV86Wwpbaseobjects_secuserwwds_5_usuariosid1 = "";
         lV90Wwpbaseobjects_secuserwwds_9_secusername2 = "";
         lV91Wwpbaseobjects_secuserwwds_10_usuariosid2 = "";
         lV95Wwpbaseobjects_secuserwwds_14_secusername3 = "";
         lV96Wwpbaseobjects_secuserwwds_15_usuariosid3 = "";
         lV99Wwpbaseobjects_secuserwwds_18_tfsecusername = "";
         lV101Wwpbaseobjects_secuserwwds_20_tfsecuserfullname = "";
         lV103Wwpbaseobjects_secuserwwds_22_tfusuariosid = "";
         lV105Wwpbaseobjects_secuserwwds_24_tfusuariosnombre = "";
         lV109Wwpbaseobjects_secuserwwds_28_tfsecuserpassword = "";
         A226usuariosEstado = "";
         A550SecUserEstado = "";
         A26SecUserName = "";
         A145usuariosId = "";
         A587SecUserFullName = "";
         A222usuariosNombre = "";
         A27SecUserPassword = "";
         P002P2_A27SecUserPassword = new string[] {""} ;
         P002P2_A222usuariosNombre = new string[] {""} ;
         P002P2_A145usuariosId = new string[] {""} ;
         P002P2_n145usuariosId = new bool[] {false} ;
         P002P2_A587SecUserFullName = new string[] {""} ;
         P002P2_A26SecUserName = new string[] {""} ;
         P002P2_A18SecUserId = new long[1] ;
         P002P2_A550SecUserEstado = new string[] {""} ;
         P002P2_n550SecUserEstado = new bool[] {false} ;
         P002P2_A226usuariosEstado = new string[] {""} ;
         P002P2_A40000usuariosImagen_GXI = new string[] {""} ;
         P002P2_A266usuariosImagen = new string[] {""} ;
         A40000usuariosImagen_GXI = "";
         A266usuariosImagen = "";
         AV55usuariosEstadoDescription = "";
         AV56SecUserEstadoDescription = "";
         sImgUrl = "";
         AV33Session = context.GetSession();
         AV34GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV45PageInfo = "";
         AV42DateInfo = "";
         Gx_date = DateTime.MinValue;
         AV40AppName = "";
         AV46Phone = "";
         AV44Mail = "";
         AV48Website = "";
         AV37AddressLine1 = "";
         AV38AddressLine2 = "";
         AV39AddressLine3 = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.asecuserwwexportreport__default(),
            new Object[][] {
                new Object[] {
               P002P2_A27SecUserPassword, P002P2_A222usuariosNombre, P002P2_A145usuariosId, P002P2_n145usuariosId, P002P2_A587SecUserFullName, P002P2_A26SecUserName, P002P2_A18SecUserId, P002P2_A550SecUserEstado, P002P2_n550SecUserEstado, P002P2_A226usuariosEstado,
               P002P2_A40000usuariosImagen_GXI, P002P2_A266usuariosImagen
               }
            }
         );
         Gx_date = DateTimeUtil.Today( context);
         AV76Pgmname = "WWPBaseObjects.ASecUserWWExportReport";
         /* GeneXus formulas. */
         Gx_line = 0;
         Gx_date = DateTimeUtil.Today( context);
         AV76Pgmname = "WWPBaseObjects.ASecUserWWExportReport";
      }

      private short nGotPars ;
      private short GxWebError ;
      private short AV13DynamicFiltersOperator1 ;
      private short AV17DynamicFiltersOperator2 ;
      private short AV21DynamicFiltersOperator3 ;
      private short AV84Wwpbaseobjects_secuserwwds_3_dynamicfiltersoperator1 ;
      private short AV89Wwpbaseobjects_secuserwwds_8_dynamicfiltersoperator2 ;
      private short AV94Wwpbaseobjects_secuserwwds_13_dynamicfiltersoperator3 ;
      private short AV10OrderedBy ;
      private int M_top ;
      private int M_bot ;
      private int Line ;
      private int ToSkip ;
      private int PrtOffset ;
      private int Gx_OldLine ;
      private int AV79GXV1 ;
      private int AV80GXV2 ;
      private int AV107Wwpbaseobjects_secuserwwds_26_tfusuariosestado_sels_Count ;
      private int AV108Wwpbaseobjects_secuserwwds_27_tfsecuserestado_sels_Count ;
      private int AV111GXV3 ;
      private long AV28TFSecUserId ;
      private long AV29TFSecUserId_To ;
      private long AV73i ;
      private long AV97Wwpbaseobjects_secuserwwds_16_tfsecuserid ;
      private long AV98Wwpbaseobjects_secuserwwds_17_tfsecuserid_to ;
      private long A18SecUserId ;
      private string GXKey ;
      private string gxfirstwebparm ;
      private string AV76Pgmname ;
      private string GXEncryptionTmp ;
      private string AV50usuariosId1 ;
      private string AV52usuariosId ;
      private string AV53usuariosId2 ;
      private string AV54usuariosId3 ;
      private string AV60TFusuariosId_Sel ;
      private string AV59TFusuariosId ;
      private string AV62TFusuariosNombre_Sel ;
      private string AV61TFusuariosNombre ;
      private string AV66TFusuariosEstado_Sel ;
      private string AV70TFSecUserEstado_Sel ;
      private string AV86Wwpbaseobjects_secuserwwds_5_usuariosid1 ;
      private string AV91Wwpbaseobjects_secuserwwds_10_usuariosid2 ;
      private string AV96Wwpbaseobjects_secuserwwds_15_usuariosid3 ;
      private string AV103Wwpbaseobjects_secuserwwds_22_tfusuariosid ;
      private string AV104Wwpbaseobjects_secuserwwds_23_tfusuariosid_sel ;
      private string AV105Wwpbaseobjects_secuserwwds_24_tfusuariosnombre ;
      private string AV106Wwpbaseobjects_secuserwwds_25_tfusuariosnombre_sel ;
      private string lV86Wwpbaseobjects_secuserwwds_5_usuariosid1 ;
      private string lV91Wwpbaseobjects_secuserwwds_10_usuariosid2 ;
      private string lV96Wwpbaseobjects_secuserwwds_15_usuariosid3 ;
      private string lV103Wwpbaseobjects_secuserwwds_22_tfusuariosid ;
      private string lV105Wwpbaseobjects_secuserwwds_24_tfusuariosnombre ;
      private string A226usuariosEstado ;
      private string A550SecUserEstado ;
      private string A145usuariosId ;
      private string A222usuariosNombre ;
      private string sImgUrl ;
      private DateTime Gx_date ;
      private bool entryPointCalled ;
      private bool AV8IsAuthorized ;
      private bool GXt_boolean1 ;
      private bool returnInSub ;
      private bool AV15DynamicFiltersEnabled2 ;
      private bool AV19DynamicFiltersEnabled3 ;
      private bool AV36TempBoolean ;
      private bool AV87Wwpbaseobjects_secuserwwds_6_dynamicfiltersenabled2 ;
      private bool AV92Wwpbaseobjects_secuserwwds_11_dynamicfiltersenabled3 ;
      private bool AV11OrderedDsc ;
      private bool n145usuariosId ;
      private bool n550SecUserEstado ;
      private string AV63TFusuariosEstado_SelsJson ;
      private string AV67TFSecUserEstado_SelsJson ;
      private string AV47Title ;
      private string AV49FilterFullText ;
      private string AV12DynamicFiltersSelector1 ;
      private string AV14SecUserName1 ;
      private string AV26FilterSecUserNameDescription ;
      private string AV27SecUserName ;
      private string AV51FilterusuariosIdDescription ;
      private string AV16DynamicFiltersSelector2 ;
      private string AV18SecUserName2 ;
      private string AV20DynamicFiltersSelector3 ;
      private string AV22SecUserName3 ;
      private string AV35TFSecUserId_To_Description ;
      private string AV31TFSecUserName_Sel ;
      private string AV30TFSecUserName ;
      private string AV58TFSecUserFullName_Sel ;
      private string AV57TFSecUserFullName ;
      private string AV64TFusuariosEstado_SelDscs ;
      private string AV71FilterTFusuariosEstado_SelValueDescription ;
      private string AV68TFSecUserEstado_SelDscs ;
      private string AV72FilterTFSecUserEstado_SelValueDescription ;
      private string AV75TFSecUserPassword_Sel ;
      private string AV74TFSecUserPassword ;
      private string AV82Wwpbaseobjects_secuserwwds_1_filterfulltext ;
      private string AV83Wwpbaseobjects_secuserwwds_2_dynamicfiltersselector1 ;
      private string AV85Wwpbaseobjects_secuserwwds_4_secusername1 ;
      private string AV88Wwpbaseobjects_secuserwwds_7_dynamicfiltersselector2 ;
      private string AV90Wwpbaseobjects_secuserwwds_9_secusername2 ;
      private string AV93Wwpbaseobjects_secuserwwds_12_dynamicfiltersselector3 ;
      private string AV95Wwpbaseobjects_secuserwwds_14_secusername3 ;
      private string AV99Wwpbaseobjects_secuserwwds_18_tfsecusername ;
      private string AV100Wwpbaseobjects_secuserwwds_19_tfsecusername_sel ;
      private string AV101Wwpbaseobjects_secuserwwds_20_tfsecuserfullname ;
      private string AV102Wwpbaseobjects_secuserwwds_21_tfsecuserfullname_sel ;
      private string AV109Wwpbaseobjects_secuserwwds_28_tfsecuserpassword ;
      private string AV110Wwpbaseobjects_secuserwwds_29_tfsecuserpassword_sel ;
      private string lV82Wwpbaseobjects_secuserwwds_1_filterfulltext ;
      private string lV85Wwpbaseobjects_secuserwwds_4_secusername1 ;
      private string lV90Wwpbaseobjects_secuserwwds_9_secusername2 ;
      private string lV95Wwpbaseobjects_secuserwwds_14_secusername3 ;
      private string lV99Wwpbaseobjects_secuserwwds_18_tfsecusername ;
      private string lV101Wwpbaseobjects_secuserwwds_20_tfsecuserfullname ;
      private string lV109Wwpbaseobjects_secuserwwds_28_tfsecuserpassword ;
      private string A26SecUserName ;
      private string A587SecUserFullName ;
      private string A27SecUserPassword ;
      private string A40000usuariosImagen_GXI ;
      private string AV55usuariosEstadoDescription ;
      private string AV56SecUserEstadoDescription ;
      private string AV45PageInfo ;
      private string AV42DateInfo ;
      private string AV40AppName ;
      private string AV46Phone ;
      private string AV44Mail ;
      private string AV48Website ;
      private string AV37AddressLine1 ;
      private string AV38AddressLine2 ;
      private string AV39AddressLine3 ;
      private string A266usuariosImagen ;
      private IGxSession AV33Session ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV32WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV24GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV25GridStateDynamicFilter ;
      private GxSimpleCollection<string> AV65TFusuariosEstado_Sels ;
      private GxSimpleCollection<string> AV69TFSecUserEstado_Sels ;
      private GxSimpleCollection<string> AV107Wwpbaseobjects_secuserwwds_26_tfusuariosestado_sels ;
      private GxSimpleCollection<string> AV108Wwpbaseobjects_secuserwwds_27_tfsecuserestado_sels ;
      private IDataStoreProvider pr_default ;
      private string[] P002P2_A27SecUserPassword ;
      private string[] P002P2_A222usuariosNombre ;
      private string[] P002P2_A145usuariosId ;
      private bool[] P002P2_n145usuariosId ;
      private string[] P002P2_A587SecUserFullName ;
      private string[] P002P2_A26SecUserName ;
      private long[] P002P2_A18SecUserId ;
      private string[] P002P2_A550SecUserEstado ;
      private bool[] P002P2_n550SecUserEstado ;
      private string[] P002P2_A226usuariosEstado ;
      private string[] P002P2_A40000usuariosImagen_GXI ;
      private string[] P002P2_A266usuariosImagen ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV34GridStateFilterValue ;
   }

   public class asecuserwwexportreport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P002P2( IGxContext context ,
                                             string A226usuariosEstado ,
                                             GxSimpleCollection<string> AV107Wwpbaseobjects_secuserwwds_26_tfusuariosestado_sels ,
                                             string A550SecUserEstado ,
                                             GxSimpleCollection<string> AV108Wwpbaseobjects_secuserwwds_27_tfsecuserestado_sels ,
                                             string AV83Wwpbaseobjects_secuserwwds_2_dynamicfiltersselector1 ,
                                             short AV84Wwpbaseobjects_secuserwwds_3_dynamicfiltersoperator1 ,
                                             string AV85Wwpbaseobjects_secuserwwds_4_secusername1 ,
                                             string AV86Wwpbaseobjects_secuserwwds_5_usuariosid1 ,
                                             bool AV87Wwpbaseobjects_secuserwwds_6_dynamicfiltersenabled2 ,
                                             string AV88Wwpbaseobjects_secuserwwds_7_dynamicfiltersselector2 ,
                                             short AV89Wwpbaseobjects_secuserwwds_8_dynamicfiltersoperator2 ,
                                             string AV90Wwpbaseobjects_secuserwwds_9_secusername2 ,
                                             string AV91Wwpbaseobjects_secuserwwds_10_usuariosid2 ,
                                             bool AV92Wwpbaseobjects_secuserwwds_11_dynamicfiltersenabled3 ,
                                             string AV93Wwpbaseobjects_secuserwwds_12_dynamicfiltersselector3 ,
                                             short AV94Wwpbaseobjects_secuserwwds_13_dynamicfiltersoperator3 ,
                                             string AV95Wwpbaseobjects_secuserwwds_14_secusername3 ,
                                             string AV96Wwpbaseobjects_secuserwwds_15_usuariosid3 ,
                                             long AV97Wwpbaseobjects_secuserwwds_16_tfsecuserid ,
                                             long AV98Wwpbaseobjects_secuserwwds_17_tfsecuserid_to ,
                                             string AV100Wwpbaseobjects_secuserwwds_19_tfsecusername_sel ,
                                             string AV99Wwpbaseobjects_secuserwwds_18_tfsecusername ,
                                             string AV102Wwpbaseobjects_secuserwwds_21_tfsecuserfullname_sel ,
                                             string AV101Wwpbaseobjects_secuserwwds_20_tfsecuserfullname ,
                                             string AV104Wwpbaseobjects_secuserwwds_23_tfusuariosid_sel ,
                                             string AV103Wwpbaseobjects_secuserwwds_22_tfusuariosid ,
                                             string AV106Wwpbaseobjects_secuserwwds_25_tfusuariosnombre_sel ,
                                             string AV105Wwpbaseobjects_secuserwwds_24_tfusuariosnombre ,
                                             int AV107Wwpbaseobjects_secuserwwds_26_tfusuariosestado_sels_Count ,
                                             int AV108Wwpbaseobjects_secuserwwds_27_tfsecuserestado_sels_Count ,
                                             string AV110Wwpbaseobjects_secuserwwds_29_tfsecuserpassword_sel ,
                                             string AV109Wwpbaseobjects_secuserwwds_28_tfsecuserpassword ,
                                             string A26SecUserName ,
                                             string A145usuariosId ,
                                             long A18SecUserId ,
                                             string A587SecUserFullName ,
                                             string A222usuariosNombre ,
                                             string A27SecUserPassword ,
                                             short AV10OrderedBy ,
                                             bool AV11OrderedDsc ,
                                             string AV82Wwpbaseobjects_secuserwwds_1_filterfulltext )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int2 = new short[24];
         Object[] GXv_Object3 = new Object[2];
         scmdbuf = "SELECT T1.[SecUserPassword], T2.[usuariosNombre], T1.[usuariosId], T1.[SecUserFullName], T1.[SecUserName], T1.[SecUserId], T1.[SecUserEstado], T2.[usuariosEstado], T2.[usuariosImagen_GXI], T2.[usuariosImagen] FROM ([SecUser] T1 LEFT JOIN [usuarios] T2 ON T2.[usuariosId] = T1.[usuariosId])";
         if ( ( StringUtil.StrCmp(AV83Wwpbaseobjects_secuserwwds_2_dynamicfiltersselector1, "SECUSERNAME") == 0 ) && ( AV84Wwpbaseobjects_secuserwwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV85Wwpbaseobjects_secuserwwds_4_secusername1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[SecUserName]) like UPPER(@lV85Wwpbaseobjects_secuserwwds_4_secusername1))");
         }
         else
         {
            GXv_int2[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV83Wwpbaseobjects_secuserwwds_2_dynamicfiltersselector1, "SECUSERNAME") == 0 ) && ( AV84Wwpbaseobjects_secuserwwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV85Wwpbaseobjects_secuserwwds_4_secusername1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[SecUserName]) like '%' + UPPER(@lV85Wwpbaseobjects_secuserwwds_4_secusername1))");
         }
         else
         {
            GXv_int2[1] = 1;
         }
         if ( ( StringUtil.StrCmp(AV83Wwpbaseobjects_secuserwwds_2_dynamicfiltersselector1, "USUARIOSID") == 0 ) && ( AV84Wwpbaseobjects_secuserwwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV86Wwpbaseobjects_secuserwwds_5_usuariosid1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[usuariosId]) like UPPER(@lV86Wwpbaseobjects_secuserwwds_5_usuariosid1))");
         }
         else
         {
            GXv_int2[2] = 1;
         }
         if ( ( StringUtil.StrCmp(AV83Wwpbaseobjects_secuserwwds_2_dynamicfiltersselector1, "USUARIOSID") == 0 ) && ( AV84Wwpbaseobjects_secuserwwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV86Wwpbaseobjects_secuserwwds_5_usuariosid1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[usuariosId]) like '%' + UPPER(@lV86Wwpbaseobjects_secuserwwds_5_usuariosid1))");
         }
         else
         {
            GXv_int2[3] = 1;
         }
         if ( AV87Wwpbaseobjects_secuserwwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV88Wwpbaseobjects_secuserwwds_7_dynamicfiltersselector2, "SECUSERNAME") == 0 ) && ( AV89Wwpbaseobjects_secuserwwds_8_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV90Wwpbaseobjects_secuserwwds_9_secusername2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[SecUserName]) like UPPER(@lV90Wwpbaseobjects_secuserwwds_9_secusername2))");
         }
         else
         {
            GXv_int2[4] = 1;
         }
         if ( AV87Wwpbaseobjects_secuserwwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV88Wwpbaseobjects_secuserwwds_7_dynamicfiltersselector2, "SECUSERNAME") == 0 ) && ( AV89Wwpbaseobjects_secuserwwds_8_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV90Wwpbaseobjects_secuserwwds_9_secusername2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[SecUserName]) like '%' + UPPER(@lV90Wwpbaseobjects_secuserwwds_9_secusername2))");
         }
         else
         {
            GXv_int2[5] = 1;
         }
         if ( AV87Wwpbaseobjects_secuserwwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV88Wwpbaseobjects_secuserwwds_7_dynamicfiltersselector2, "USUARIOSID") == 0 ) && ( AV89Wwpbaseobjects_secuserwwds_8_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV91Wwpbaseobjects_secuserwwds_10_usuariosid2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[usuariosId]) like UPPER(@lV91Wwpbaseobjects_secuserwwds_10_usuariosid2))");
         }
         else
         {
            GXv_int2[6] = 1;
         }
         if ( AV87Wwpbaseobjects_secuserwwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV88Wwpbaseobjects_secuserwwds_7_dynamicfiltersselector2, "USUARIOSID") == 0 ) && ( AV89Wwpbaseobjects_secuserwwds_8_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV91Wwpbaseobjects_secuserwwds_10_usuariosid2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[usuariosId]) like '%' + UPPER(@lV91Wwpbaseobjects_secuserwwds_10_usuariosid2))");
         }
         else
         {
            GXv_int2[7] = 1;
         }
         if ( AV92Wwpbaseobjects_secuserwwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV93Wwpbaseobjects_secuserwwds_12_dynamicfiltersselector3, "SECUSERNAME") == 0 ) && ( AV94Wwpbaseobjects_secuserwwds_13_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV95Wwpbaseobjects_secuserwwds_14_secusername3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[SecUserName]) like UPPER(@lV95Wwpbaseobjects_secuserwwds_14_secusername3))");
         }
         else
         {
            GXv_int2[8] = 1;
         }
         if ( AV92Wwpbaseobjects_secuserwwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV93Wwpbaseobjects_secuserwwds_12_dynamicfiltersselector3, "SECUSERNAME") == 0 ) && ( AV94Wwpbaseobjects_secuserwwds_13_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV95Wwpbaseobjects_secuserwwds_14_secusername3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[SecUserName]) like '%' + UPPER(@lV95Wwpbaseobjects_secuserwwds_14_secusername3))");
         }
         else
         {
            GXv_int2[9] = 1;
         }
         if ( AV92Wwpbaseobjects_secuserwwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV93Wwpbaseobjects_secuserwwds_12_dynamicfiltersselector3, "USUARIOSID") == 0 ) && ( AV94Wwpbaseobjects_secuserwwds_13_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV96Wwpbaseobjects_secuserwwds_15_usuariosid3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[usuariosId]) like UPPER(@lV96Wwpbaseobjects_secuserwwds_15_usuariosid3))");
         }
         else
         {
            GXv_int2[10] = 1;
         }
         if ( AV92Wwpbaseobjects_secuserwwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV93Wwpbaseobjects_secuserwwds_12_dynamicfiltersselector3, "USUARIOSID") == 0 ) && ( AV94Wwpbaseobjects_secuserwwds_13_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV96Wwpbaseobjects_secuserwwds_15_usuariosid3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[usuariosId]) like '%' + UPPER(@lV96Wwpbaseobjects_secuserwwds_15_usuariosid3))");
         }
         else
         {
            GXv_int2[11] = 1;
         }
         if ( ! (0==AV97Wwpbaseobjects_secuserwwds_16_tfsecuserid) )
         {
            AddWhere(sWhereString, "(T1.[SecUserId] >= @AV97Wwpbaseobjects_secuserwwds_16_tfsecuserid)");
         }
         else
         {
            GXv_int2[12] = 1;
         }
         if ( ! (0==AV98Wwpbaseobjects_secuserwwds_17_tfsecuserid_to) )
         {
            AddWhere(sWhereString, "(T1.[SecUserId] <= @AV98Wwpbaseobjects_secuserwwds_17_tfsecuserid_to)");
         }
         else
         {
            GXv_int2[13] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV100Wwpbaseobjects_secuserwwds_19_tfsecusername_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV99Wwpbaseobjects_secuserwwds_18_tfsecusername)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[SecUserName]) like UPPER(@lV99Wwpbaseobjects_secuserwwds_18_tfsecusername))");
         }
         else
         {
            GXv_int2[14] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV100Wwpbaseobjects_secuserwwds_19_tfsecusername_sel)) && ! ( StringUtil.StrCmp(AV100Wwpbaseobjects_secuserwwds_19_tfsecusername_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[SecUserName] = @AV100Wwpbaseobjects_secuserwwds_19_tfsecusername_sel)");
         }
         else
         {
            GXv_int2[15] = 1;
         }
         if ( StringUtil.StrCmp(AV100Wwpbaseobjects_secuserwwds_19_tfsecusername_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[SecUserName] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV102Wwpbaseobjects_secuserwwds_21_tfsecuserfullname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV101Wwpbaseobjects_secuserwwds_20_tfsecuserfullname)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[SecUserFullName]) like UPPER(@lV101Wwpbaseobjects_secuserwwds_20_tfsecuserfullname))");
         }
         else
         {
            GXv_int2[16] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV102Wwpbaseobjects_secuserwwds_21_tfsecuserfullname_sel)) && ! ( StringUtil.StrCmp(AV102Wwpbaseobjects_secuserwwds_21_tfsecuserfullname_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[SecUserFullName] = @AV102Wwpbaseobjects_secuserwwds_21_tfsecuserfullname_sel)");
         }
         else
         {
            GXv_int2[17] = 1;
         }
         if ( StringUtil.StrCmp(AV102Wwpbaseobjects_secuserwwds_21_tfsecuserfullname_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[SecUserFullName] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV104Wwpbaseobjects_secuserwwds_23_tfusuariosid_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV103Wwpbaseobjects_secuserwwds_22_tfusuariosid)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[usuariosId]) like UPPER(@lV103Wwpbaseobjects_secuserwwds_22_tfusuariosid))");
         }
         else
         {
            GXv_int2[18] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV104Wwpbaseobjects_secuserwwds_23_tfusuariosid_sel)) && ! ( StringUtil.StrCmp(AV104Wwpbaseobjects_secuserwwds_23_tfusuariosid_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[usuariosId] = @AV104Wwpbaseobjects_secuserwwds_23_tfusuariosid_sel)");
         }
         else
         {
            GXv_int2[19] = 1;
         }
         if ( StringUtil.StrCmp(AV104Wwpbaseobjects_secuserwwds_23_tfusuariosid_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.[usuariosId] IS NULL or (T1.[usuariosId] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV106Wwpbaseobjects_secuserwwds_25_tfusuariosnombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV105Wwpbaseobjects_secuserwwds_24_tfusuariosnombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[usuariosNombre]) like UPPER(@lV105Wwpbaseobjects_secuserwwds_24_tfusuariosnombre))");
         }
         else
         {
            GXv_int2[20] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV106Wwpbaseobjects_secuserwwds_25_tfusuariosnombre_sel)) && ! ( StringUtil.StrCmp(AV106Wwpbaseobjects_secuserwwds_25_tfusuariosnombre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.[usuariosNombre] = @AV106Wwpbaseobjects_secuserwwds_25_tfusuariosnombre_sel)");
         }
         else
         {
            GXv_int2[21] = 1;
         }
         if ( StringUtil.StrCmp(AV106Wwpbaseobjects_secuserwwds_25_tfusuariosnombre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T2.[usuariosNombre] IS NULL or (T2.[usuariosNombre] = ''))");
         }
         if ( AV107Wwpbaseobjects_secuserwwds_26_tfusuariosestado_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV107Wwpbaseobjects_secuserwwds_26_tfusuariosestado_sels, "T2.[usuariosEstado] IN (", ")")+")");
         }
         if ( AV108Wwpbaseobjects_secuserwwds_27_tfsecuserestado_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV108Wwpbaseobjects_secuserwwds_27_tfsecuserestado_sels, "T1.[SecUserEstado] IN (", ")")+")");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV110Wwpbaseobjects_secuserwwds_29_tfsecuserpassword_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV109Wwpbaseobjects_secuserwwds_28_tfsecuserpassword)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[SecUserPassword]) like UPPER(@lV109Wwpbaseobjects_secuserwwds_28_tfsecuserpassword))");
         }
         else
         {
            GXv_int2[22] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV110Wwpbaseobjects_secuserwwds_29_tfsecuserpassword_sel)) && ! ( StringUtil.StrCmp(AV110Wwpbaseobjects_secuserwwds_29_tfsecuserpassword_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[SecUserPassword] = @AV110Wwpbaseobjects_secuserwwds_29_tfsecuserpassword_sel)");
         }
         else
         {
            GXv_int2[23] = 1;
         }
         if ( StringUtil.StrCmp(AV110Wwpbaseobjects_secuserwwds_29_tfsecuserpassword_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[SecUserPassword] = ''))");
         }
         scmdbuf += sWhereString;
         if ( ( AV10OrderedBy == 1 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[SecUserName]";
         }
         else if ( ( AV10OrderedBy == 1 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[SecUserName] DESC";
         }
         else if ( ( AV10OrderedBy == 2 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[SecUserId]";
         }
         else if ( ( AV10OrderedBy == 2 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[SecUserId] DESC";
         }
         else if ( ( AV10OrderedBy == 3 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[SecUserFullName]";
         }
         else if ( ( AV10OrderedBy == 3 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[SecUserFullName] DESC";
         }
         else if ( ( AV10OrderedBy == 4 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[usuariosId]";
         }
         else if ( ( AV10OrderedBy == 4 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[usuariosId] DESC";
         }
         else if ( ( AV10OrderedBy == 5 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY T2.[usuariosNombre]";
         }
         else if ( ( AV10OrderedBy == 5 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T2.[usuariosNombre] DESC";
         }
         else if ( ( AV10OrderedBy == 6 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY T2.[usuariosEstado]";
         }
         else if ( ( AV10OrderedBy == 6 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T2.[usuariosEstado] DESC";
         }
         else if ( ( AV10OrderedBy == 7 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[SecUserEstado]";
         }
         else if ( ( AV10OrderedBy == 7 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[SecUserEstado] DESC";
         }
         else if ( ( AV10OrderedBy == 8 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[SecUserPassword]";
         }
         else if ( ( AV10OrderedBy == 8 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[SecUserPassword] DESC";
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
                     return conditional_P002P2(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (GxSimpleCollection<string>)dynConstraints[3] , (string)dynConstraints[4] , (short)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (bool)dynConstraints[8] , (string)dynConstraints[9] , (short)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (bool)dynConstraints[13] , (string)dynConstraints[14] , (short)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (long)dynConstraints[18] , (long)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (string)dynConstraints[25] , (string)dynConstraints[26] , (string)dynConstraints[27] , (int)dynConstraints[28] , (int)dynConstraints[29] , (string)dynConstraints[30] , (string)dynConstraints[31] , (string)dynConstraints[32] , (string)dynConstraints[33] , (long)dynConstraints[34] , (string)dynConstraints[35] , (string)dynConstraints[36] , (string)dynConstraints[37] , (short)dynConstraints[38] , (bool)dynConstraints[39] , (string)dynConstraints[40] );
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
          Object[] prmP002P2;
          prmP002P2 = new Object[] {
          new ParDef("@lV85Wwpbaseobjects_secuserwwds_4_secusername1",GXType.VarChar,100,0) ,
          new ParDef("@lV85Wwpbaseobjects_secuserwwds_4_secusername1",GXType.VarChar,100,0) ,
          new ParDef("@lV86Wwpbaseobjects_secuserwwds_5_usuariosid1",GXType.Char,20,0) ,
          new ParDef("@lV86Wwpbaseobjects_secuserwwds_5_usuariosid1",GXType.Char,20,0) ,
          new ParDef("@lV90Wwpbaseobjects_secuserwwds_9_secusername2",GXType.VarChar,100,0) ,
          new ParDef("@lV90Wwpbaseobjects_secuserwwds_9_secusername2",GXType.VarChar,100,0) ,
          new ParDef("@lV91Wwpbaseobjects_secuserwwds_10_usuariosid2",GXType.Char,20,0) ,
          new ParDef("@lV91Wwpbaseobjects_secuserwwds_10_usuariosid2",GXType.Char,20,0) ,
          new ParDef("@lV95Wwpbaseobjects_secuserwwds_14_secusername3",GXType.VarChar,100,0) ,
          new ParDef("@lV95Wwpbaseobjects_secuserwwds_14_secusername3",GXType.VarChar,100,0) ,
          new ParDef("@lV96Wwpbaseobjects_secuserwwds_15_usuariosid3",GXType.Char,20,0) ,
          new ParDef("@lV96Wwpbaseobjects_secuserwwds_15_usuariosid3",GXType.Char,20,0) ,
          new ParDef("@AV97Wwpbaseobjects_secuserwwds_16_tfsecuserid",GXType.Decimal,10,0) ,
          new ParDef("@AV98Wwpbaseobjects_secuserwwds_17_tfsecuserid_to",GXType.Decimal,10,0) ,
          new ParDef("@lV99Wwpbaseobjects_secuserwwds_18_tfsecusername",GXType.VarChar,100,0) ,
          new ParDef("@AV100Wwpbaseobjects_secuserwwds_19_tfsecusername_sel",GXType.NVarChar,100,0) ,
          new ParDef("@lV101Wwpbaseobjects_secuserwwds_20_tfsecuserfullname",GXType.VarChar,120,0) ,
          new ParDef("@AV102Wwpbaseobjects_secuserwwds_21_tfsecuserfullname_sel",GXType.NVarChar,120,0) ,
          new ParDef("@lV103Wwpbaseobjects_secuserwwds_22_tfusuariosid",GXType.Char,20,0) ,
          new ParDef("@AV104Wwpbaseobjects_secuserwwds_23_tfusuariosid_sel",GXType.NChar,20,0) ,
          new ParDef("@lV105Wwpbaseobjects_secuserwwds_24_tfusuariosnombre",GXType.Char,80,0) ,
          new ParDef("@AV106Wwpbaseobjects_secuserwwds_25_tfusuariosnombre_sel",GXType.NChar,80,0) ,
          new ParDef("@lV109Wwpbaseobjects_secuserwwds_28_tfsecuserpassword",GXType.VarChar,100,0) ,
          new ParDef("@AV110Wwpbaseobjects_secuserwwds_29_tfsecuserpassword_sel",GXType.NVarChar,100,0)
          };
          def= new CursorDef[] {
              new CursorDef("P002P2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP002P2,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[10])[0] = rslt.getMultimediaUri(9);
                ((string[]) buf[11])[0] = rslt.getMultimediaFile(10, rslt.getVarchar(9));
                return;
       }
    }

 }

}

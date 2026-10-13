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
   public class zonaswwexportreport : GXWebProcedure, System.Web.SessionState.IRequiresSessionState
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

      public zonaswwexportreport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public zonaswwexportreport( IGxContext context )
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
         setOutputFileName("ZonasWWExportReport");
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
            new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWZonas", out  GXt_boolean1) ;
            AV8IsAuthorized = GXt_boolean1;
            if ( ! AV8IsAuthorized )
            {
               GXKey = Crypto.GetSiteKey( );
               GXEncryptionTmp = "wwpbaseobjects.notauthorized.aspx"+UrlEncode(StringUtil.RTrim(AV54Pgmname));
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
               AV52Title = context.GetMessage( "Lista de Zonas", "");
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
            H7K0( true, 0) ;
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
            H7K0( false, 19) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "WWP_FullTextFilterDescription", ""), 25, Gx_line+0, 138, Gx_line+14, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV13FilterFullText, "")), 138, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+19);
         }
         if ( AV30GridState.gxTpr_Dynamicfilters.Count >= 1 )
         {
            AV27GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV30GridState.gxTpr_Dynamicfilters.Item(1));
            AV14DynamicFiltersSelector1 = AV27GridStateDynamicFilter.gxTpr_Selected;
            if ( StringUtil.StrCmp(AV14DynamicFiltersSelector1, "ZONASNOMBRE") == 0 )
            {
               AV15DynamicFiltersOperator1 = AV27GridStateDynamicFilter.gxTpr_Operator;
               AV16ZonasNombre1 = AV27GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV16ZonasNombre1)) )
               {
                  if ( AV15DynamicFiltersOperator1 == 0 )
                  {
                     AV17FilterZonasNombreDescription = StringUtil.Format( "%1 (%2)", context.GetMessage( "Zona", ""), context.GetMessage( "WWP_FilterLike", ""), "", "", "", "", "", "", "");
                  }
                  else if ( AV15DynamicFiltersOperator1 == 1 )
                  {
                     AV17FilterZonasNombreDescription = StringUtil.Format( "%1 (%2)", context.GetMessage( "Zona", ""), context.GetMessage( "WWP_FilterContains", ""), "", "", "", "", "", "", "");
                  }
                  AV18ZonasNombre = AV16ZonasNombre1;
                  H7K0( false, 19) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV17FilterZonasNombreDescription, "")), 25, Gx_line+0, 138, Gx_line+14, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV18ZonasNombre, "")), 138, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+19);
               }
            }
            if ( AV30GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV19DynamicFiltersEnabled2 = true;
               AV27GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV30GridState.gxTpr_Dynamicfilters.Item(2));
               AV20DynamicFiltersSelector2 = AV27GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV20DynamicFiltersSelector2, "ZONASNOMBRE") == 0 )
               {
                  AV21DynamicFiltersOperator2 = AV27GridStateDynamicFilter.gxTpr_Operator;
                  AV22ZonasNombre2 = AV27GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV22ZonasNombre2)) )
                  {
                     if ( AV21DynamicFiltersOperator2 == 0 )
                     {
                        AV17FilterZonasNombreDescription = StringUtil.Format( "%1 (%2)", context.GetMessage( "Zona", ""), context.GetMessage( "WWP_FilterLike", ""), "", "", "", "", "", "", "");
                     }
                     else if ( AV21DynamicFiltersOperator2 == 1 )
                     {
                        AV17FilterZonasNombreDescription = StringUtil.Format( "%1 (%2)", context.GetMessage( "Zona", ""), context.GetMessage( "WWP_FilterContains", ""), "", "", "", "", "", "", "");
                     }
                     AV18ZonasNombre = AV22ZonasNombre2;
                     H7K0( false, 19) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV17FilterZonasNombreDescription, "")), 25, Gx_line+0, 138, Gx_line+14, 0, 0, 0, 0) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV18ZonasNombre, "")), 138, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
                     Gx_OldLine = Gx_line;
                     Gx_line = (int)(Gx_line+19);
                  }
               }
               if ( AV30GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV23DynamicFiltersEnabled3 = true;
                  AV27GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV30GridState.gxTpr_Dynamicfilters.Item(3));
                  AV24DynamicFiltersSelector3 = AV27GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV24DynamicFiltersSelector3, "ZONASNOMBRE") == 0 )
                  {
                     AV25DynamicFiltersOperator3 = AV27GridStateDynamicFilter.gxTpr_Operator;
                     AV26ZonasNombre3 = AV27GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV26ZonasNombre3)) )
                     {
                        if ( AV25DynamicFiltersOperator3 == 0 )
                        {
                           AV17FilterZonasNombreDescription = StringUtil.Format( "%1 (%2)", context.GetMessage( "Zona", ""), context.GetMessage( "WWP_FilterLike", ""), "", "", "", "", "", "", "");
                        }
                        else if ( AV25DynamicFiltersOperator3 == 1 )
                        {
                           AV17FilterZonasNombreDescription = StringUtil.Format( "%1 (%2)", context.GetMessage( "Zona", ""), context.GetMessage( "WWP_FilterContains", ""), "", "", "", "", "", "", "");
                        }
                        AV18ZonasNombre = AV26ZonasNombre3;
                        H7K0( false, 19) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV17FilterZonasNombreDescription, "")), 25, Gx_line+0, 138, Gx_line+14, 0, 0, 0, 0) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV18ZonasNombre, "")), 138, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
                        Gx_OldLine = Gx_line;
                        Gx_line = (int)(Gx_line+19);
                     }
                  }
               }
            }
         }
         if ( ! ( (0==AV32TFZonasID) && (0==AV33TFZonasID_To) ) )
         {
            H7K0( false, 19) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Nro.", ""), 25, Gx_line+0, 138, Gx_line+14, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV32TFZonasID), "ZZZZZZZZZZZZZZZZZ9")), 138, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+19);
            AV40TFZonasID_To_Description = StringUtil.Format( "%1 (%2)", context.GetMessage( "Nro.", ""), context.GetMessage( "WWP_TSTo", ""), "", "", "", "", "", "", "");
            H7K0( false, 19) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV40TFZonasID_To_Description, "")), 25, Gx_line+0, 138, Gx_line+14, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV33TFZonasID_To), "ZZZZZZZZZZZZZZZZZ9")), 138, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+19);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV35TFZonasNombre_Sel)) )
         {
            AV41TempBoolean = (bool)(((StringUtil.StrCmp(AV35TFZonasNombre_Sel, "<#Empty#>")==0)));
            AV35TFZonasNombre_Sel = (AV41TempBoolean ? context.GetMessage( "WWP_TitleFilter_EmptyOption", "") : AV35TFZonasNombre_Sel);
            H7K0( false, 19) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Zona", ""), 25, Gx_line+0, 138, Gx_line+14, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV35TFZonasNombre_Sel, "")), 138, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+19);
            AV35TFZonasNombre_Sel = (AV41TempBoolean ? "<#Empty#>" : AV35TFZonasNombre_Sel);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV34TFZonasNombre)) )
            {
               H7K0( false, 19) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(context.GetMessage( "Zona", ""), 25, Gx_line+0, 138, Gx_line+14, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV34TFZonasNombre, "")), 138, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+19);
            }
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV37TFDepartamentoDepartamento_Sel)) )
         {
            AV41TempBoolean = (bool)(((StringUtil.StrCmp(AV37TFDepartamentoDepartamento_Sel, "<#Empty#>")==0)));
            AV37TFDepartamentoDepartamento_Sel = (AV41TempBoolean ? context.GetMessage( "WWP_TitleFilter_EmptyOption", "") : AV37TFDepartamentoDepartamento_Sel);
            H7K0( false, 19) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Departamento", ""), 25, Gx_line+0, 138, Gx_line+14, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV37TFDepartamentoDepartamento_Sel, "")), 138, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+19);
            AV37TFDepartamentoDepartamento_Sel = (AV41TempBoolean ? "<#Empty#>" : AV37TFDepartamentoDepartamento_Sel);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV36TFDepartamentoDepartamento)) )
            {
               H7K0( false, 19) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(context.GetMessage( "Departamento", ""), 25, Gx_line+0, 138, Gx_line+14, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV36TFDepartamentoDepartamento, "")), 138, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+19);
            }
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV39TFDepartamentoMunicipioNombre_Sel)) )
         {
            AV41TempBoolean = (bool)(((StringUtil.StrCmp(AV39TFDepartamentoMunicipioNombre_Sel, "<#Empty#>")==0)));
            AV39TFDepartamentoMunicipioNombre_Sel = (AV41TempBoolean ? context.GetMessage( "WWP_TitleFilter_EmptyOption", "") : AV39TFDepartamentoMunicipioNombre_Sel);
            H7K0( false, 19) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Municipio", ""), 25, Gx_line+0, 138, Gx_line+14, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV39TFDepartamentoMunicipioNombre_Sel, "")), 138, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+19);
            AV39TFDepartamentoMunicipioNombre_Sel = (AV41TempBoolean ? "<#Empty#>" : AV39TFDepartamentoMunicipioNombre_Sel);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV38TFDepartamentoMunicipioNombre)) )
            {
               H7K0( false, 19) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(context.GetMessage( "Municipio", ""), 25, Gx_line+0, 138, Gx_line+14, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV38TFDepartamentoMunicipioNombre, "")), 138, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+19);
            }
         }
      }

      protected void S121( )
      {
         /* 'PRINTCOLUMNTITLES' Routine */
         returnInSub = false;
         H7K0( false, 22) ;
         getPrinter().GxDrawLine(25, Gx_line+21, 789, Gx_line+21, 2, 8, 160, 134, 0) ;
         Gx_OldLine = Gx_line;
         Gx_line = (int)(Gx_line+22);
         H7K0( false, 36) ;
         getPrinter().GxAttris("Microsoft Sans Serif", 9, false, false, false, false, 0, 8, 160, 134, 0, 255, 255, 255) ;
         getPrinter().GxDrawText(context.GetMessage( "Nro.", ""), 30, Gx_line+10, 136, Gx_line+26, 2, 0, 0, 0) ;
         getPrinter().GxDrawText(context.GetMessage( "Zona", ""), 140, Gx_line+10, 352, Gx_line+26, 0, 0, 0, 0) ;
         getPrinter().GxDrawText(context.GetMessage( "Departamento", ""), 356, Gx_line+10, 569, Gx_line+26, 0, 0, 0, 0) ;
         getPrinter().GxDrawText(context.GetMessage( "Municipio", ""), 573, Gx_line+10, 787, Gx_line+26, 0, 0, 0, 0) ;
         Gx_OldLine = Gx_line;
         Gx_line = (int)(Gx_line+36);
      }

      protected void S131( )
      {
         /* 'PRINTDATA' Routine */
         returnInSub = false;
         AV58Zonaswwds_1_filterfulltext = AV13FilterFullText;
         AV59Zonaswwds_2_dynamicfiltersselector1 = AV14DynamicFiltersSelector1;
         AV60Zonaswwds_3_dynamicfiltersoperator1 = AV15DynamicFiltersOperator1;
         AV61Zonaswwds_4_zonasnombre1 = AV16ZonasNombre1;
         AV62Zonaswwds_5_dynamicfiltersenabled2 = AV19DynamicFiltersEnabled2;
         AV63Zonaswwds_6_dynamicfiltersselector2 = AV20DynamicFiltersSelector2;
         AV64Zonaswwds_7_dynamicfiltersoperator2 = AV21DynamicFiltersOperator2;
         AV65Zonaswwds_8_zonasnombre2 = AV22ZonasNombre2;
         AV66Zonaswwds_9_dynamicfiltersenabled3 = AV23DynamicFiltersEnabled3;
         AV67Zonaswwds_10_dynamicfiltersselector3 = AV24DynamicFiltersSelector3;
         AV68Zonaswwds_11_dynamicfiltersoperator3 = AV25DynamicFiltersOperator3;
         AV69Zonaswwds_12_zonasnombre3 = AV26ZonasNombre3;
         AV70Zonaswwds_13_tfzonasid = AV32TFZonasID;
         AV71Zonaswwds_14_tfzonasid_to = AV33TFZonasID_To;
         AV72Zonaswwds_15_tfzonasnombre = AV34TFZonasNombre;
         AV73Zonaswwds_16_tfzonasnombre_sel = AV35TFZonasNombre_Sel;
         AV74Zonaswwds_17_tfdepartamentodepartamento = AV36TFDepartamentoDepartamento;
         AV75Zonaswwds_18_tfdepartamentodepartamento_sel = AV37TFDepartamentoDepartamento_Sel;
         AV76Zonaswwds_19_tfdepartamentomunicipionombre = AV38TFDepartamentoMunicipioNombre;
         AV77Zonaswwds_20_tfdepartamentomunicipionombre_sel = AV39TFDepartamentoMunicipioNombre_Sel;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV58Zonaswwds_1_filterfulltext ,
                                              AV59Zonaswwds_2_dynamicfiltersselector1 ,
                                              AV60Zonaswwds_3_dynamicfiltersoperator1 ,
                                              AV61Zonaswwds_4_zonasnombre1 ,
                                              AV62Zonaswwds_5_dynamicfiltersenabled2 ,
                                              AV63Zonaswwds_6_dynamicfiltersselector2 ,
                                              AV64Zonaswwds_7_dynamicfiltersoperator2 ,
                                              AV65Zonaswwds_8_zonasnombre2 ,
                                              AV66Zonaswwds_9_dynamicfiltersenabled3 ,
                                              AV67Zonaswwds_10_dynamicfiltersselector3 ,
                                              AV68Zonaswwds_11_dynamicfiltersoperator3 ,
                                              AV69Zonaswwds_12_zonasnombre3 ,
                                              AV70Zonaswwds_13_tfzonasid ,
                                              AV71Zonaswwds_14_tfzonasid_to ,
                                              AV73Zonaswwds_16_tfzonasnombre_sel ,
                                              AV72Zonaswwds_15_tfzonasnombre ,
                                              AV75Zonaswwds_18_tfdepartamentodepartamento_sel ,
                                              AV74Zonaswwds_17_tfdepartamentodepartamento ,
                                              AV77Zonaswwds_20_tfdepartamentomunicipionombre_sel ,
                                              AV76Zonaswwds_19_tfdepartamentomunicipionombre ,
                                              A110ZonasID ,
                                              A111ZonasNombre ,
                                              A113DepartamentoDepartamento ,
                                              A115DepartamentoMunicipioNombre ,
                                              AV11OrderedBy ,
                                              AV12OrderedDsc } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV58Zonaswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV58Zonaswwds_1_filterfulltext), "%", "");
         lV58Zonaswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV58Zonaswwds_1_filterfulltext), "%", "");
         lV58Zonaswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV58Zonaswwds_1_filterfulltext), "%", "");
         lV58Zonaswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV58Zonaswwds_1_filterfulltext), "%", "");
         lV61Zonaswwds_4_zonasnombre1 = StringUtil.PadR( StringUtil.RTrim( AV61Zonaswwds_4_zonasnombre1), 120, "%");
         lV61Zonaswwds_4_zonasnombre1 = StringUtil.PadR( StringUtil.RTrim( AV61Zonaswwds_4_zonasnombre1), 120, "%");
         lV65Zonaswwds_8_zonasnombre2 = StringUtil.PadR( StringUtil.RTrim( AV65Zonaswwds_8_zonasnombre2), 120, "%");
         lV65Zonaswwds_8_zonasnombre2 = StringUtil.PadR( StringUtil.RTrim( AV65Zonaswwds_8_zonasnombre2), 120, "%");
         lV69Zonaswwds_12_zonasnombre3 = StringUtil.PadR( StringUtil.RTrim( AV69Zonaswwds_12_zonasnombre3), 120, "%");
         lV69Zonaswwds_12_zonasnombre3 = StringUtil.PadR( StringUtil.RTrim( AV69Zonaswwds_12_zonasnombre3), 120, "%");
         lV72Zonaswwds_15_tfzonasnombre = StringUtil.PadR( StringUtil.RTrim( AV72Zonaswwds_15_tfzonasnombre), 120, "%");
         lV74Zonaswwds_17_tfdepartamentodepartamento = StringUtil.PadR( StringUtil.RTrim( AV74Zonaswwds_17_tfdepartamentodepartamento), 80, "%");
         lV76Zonaswwds_19_tfdepartamentomunicipionombre = StringUtil.PadR( StringUtil.RTrim( AV76Zonaswwds_19_tfdepartamentomunicipionombre), 120, "%");
         /* Using cursor P007K2 */
         pr_default.execute(0, new Object[] {lV58Zonaswwds_1_filterfulltext, lV58Zonaswwds_1_filterfulltext, lV58Zonaswwds_1_filterfulltext, lV58Zonaswwds_1_filterfulltext, lV61Zonaswwds_4_zonasnombre1, lV61Zonaswwds_4_zonasnombre1, lV65Zonaswwds_8_zonasnombre2, lV65Zonaswwds_8_zonasnombre2, lV69Zonaswwds_12_zonasnombre3, lV69Zonaswwds_12_zonasnombre3, AV70Zonaswwds_13_tfzonasid, AV71Zonaswwds_14_tfzonasid_to, lV72Zonaswwds_15_tfzonasnombre, AV73Zonaswwds_16_tfzonasnombre_sel, lV74Zonaswwds_17_tfdepartamentodepartamento, AV75Zonaswwds_18_tfdepartamentodepartamento_sel, lV76Zonaswwds_19_tfdepartamentomunicipionombre, AV77Zonaswwds_20_tfdepartamentomunicipionombre_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A112DepartamentoId = P007K2_A112DepartamentoId[0];
            A114DepartamentoMunicipioId = P007K2_A114DepartamentoMunicipioId[0];
            A115DepartamentoMunicipioNombre = P007K2_A115DepartamentoMunicipioNombre[0];
            A113DepartamentoDepartamento = P007K2_A113DepartamentoDepartamento[0];
            A111ZonasNombre = P007K2_A111ZonasNombre[0];
            A110ZonasID = P007K2_A110ZonasID[0];
            A113DepartamentoDepartamento = P007K2_A113DepartamentoDepartamento[0];
            A115DepartamentoMunicipioNombre = P007K2_A115DepartamentoMunicipioNombre[0];
            /* Execute user subroutine: 'BEFOREPRINTLINE' */
            S144 ();
            if ( returnInSub )
            {
               pr_default.close(0);
               returnInSub = true;
               if (true) return;
            }
            H7K0( false, 35) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(A110ZonasID), "ZZZZZZZZZZZZZZZZZ9")), 30, Gx_line+10, 136, Gx_line+24, 2+16, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A111ZonasNombre, "")), 140, Gx_line+10, 352, Gx_line+24, 0+16, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A113DepartamentoDepartamento, "")), 356, Gx_line+10, 569, Gx_line+24, 0+16, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A115DepartamentoMunicipioNombre, "")), 573, Gx_line+10, 787, Gx_line+24, 0+16, 0, 0, 0) ;
            getPrinter().GxDrawLine(28, Gx_line+34, 789, Gx_line+34, 1, 220, 220, 220, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+35);
            /* Execute user subroutine: 'AFTERPRINTLINE' */
            S161 ();
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

      protected void S151( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV28Session.Get("ZonasWWGridState"), "") == 0 )
         {
            AV30GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "ZonasWWGridState"), null, "", "");
         }
         else
         {
            AV30GridState.FromXml(AV28Session.Get("ZonasWWGridState"), null, "", "");
         }
         AV11OrderedBy = AV30GridState.gxTpr_Orderedby;
         AV12OrderedDsc = AV30GridState.gxTpr_Ordereddsc;
         AV78GXV1 = 1;
         while ( AV78GXV1 <= AV30GridState.gxTpr_Filtervalues.Count )
         {
            AV31GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV30GridState.gxTpr_Filtervalues.Item(AV78GXV1));
            if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV13FilterFullText = AV31GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "TFZONASID") == 0 )
            {
               AV32TFZonasID = (long)(Math.Round(NumberUtil.Val( AV31GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV33TFZonasID_To = (long)(Math.Round(NumberUtil.Val( AV31GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "TFZONASNOMBRE") == 0 )
            {
               AV34TFZonasNombre = AV31GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "TFZONASNOMBRE_SEL") == 0 )
            {
               AV35TFZonasNombre_Sel = AV31GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "TFDEPARTAMENTODEPARTAMENTO") == 0 )
            {
               AV36TFDepartamentoDepartamento = AV31GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "TFDEPARTAMENTODEPARTAMENTO_SEL") == 0 )
            {
               AV37TFDepartamentoDepartamento_Sel = AV31GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "TFDEPARTAMENTOMUNICIPIONOMBRE") == 0 )
            {
               AV38TFDepartamentoMunicipioNombre = AV31GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "TFDEPARTAMENTOMUNICIPIONOMBRE_SEL") == 0 )
            {
               AV39TFDepartamentoMunicipioNombre_Sel = AV31GridStateFilterValue.gxTpr_Value;
            }
            AV78GXV1 = (int)(AV78GXV1+1);
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

      protected void H7K0( bool bFoot ,
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
                  AV50PageInfo = context.GetMessage( "Page: ", "") + StringUtil.Trim( StringUtil.Str( (decimal)(Gx_page), 6, 0));
                  AV47DateInfo = context.GetMessage( "Date: ", "") + context.localUtil.Format( Gx_date, "99/99/99");
                  getPrinter().GxDrawRect(0, Gx_line+5, 819, Gx_line+39, 1, 0, 0, 0, 1, 8, 160, 134, 1, 1, 1, 1, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV50PageInfo, "")), 30, Gx_line+15, 409, Gx_line+29, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV47DateInfo, "")), 409, Gx_line+15, 789, Gx_line+29, 2, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+39);
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
               AV45AppName = context.GetMessage( "DVelop Software Solutions", "");
               AV51Phone = "+1 550 8923";
               AV49Mail = "info@mail.com";
               AV53Website = "http://www.web.com";
               AV42AddressLine1 = "French Boulevard 2859";
               AV43AddressLine2 = "Downtown";
               AV44AddressLine3 = "Paris, France";
               getPrinter().GxDrawRect(0, Gx_line+0, 819, Gx_line+107, 1, 0, 0, 0, 1, 8, 160, 134, 1, 1, 1, 1, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV45AppName, "")), 30, Gx_line+30, 283, Gx_line+44, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 20, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV52Title, "")), 30, Gx_line+44, 283, Gx_line+77, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV51Phone, "")), 283, Gx_line+30, 536, Gx_line+45, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV49Mail, "")), 283, Gx_line+45, 536, Gx_line+60, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV53Website, "")), 283, Gx_line+60, 536, Gx_line+77, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV42AddressLine1, "")), 536, Gx_line+30, 789, Gx_line+45, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV43AddressLine2, "")), 536, Gx_line+45, 789, Gx_line+60, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV44AddressLine3, "")), 536, Gx_line+60, 789, Gx_line+77, 2, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+127);
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
         AV54Pgmname = "";
         GXEncryptionTmp = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV52Title = "";
         AV13FilterFullText = "";
         AV30GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV27GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV14DynamicFiltersSelector1 = "";
         AV16ZonasNombre1 = "";
         AV17FilterZonasNombreDescription = "";
         AV18ZonasNombre = "";
         AV20DynamicFiltersSelector2 = "";
         AV22ZonasNombre2 = "";
         AV24DynamicFiltersSelector3 = "";
         AV26ZonasNombre3 = "";
         AV40TFZonasID_To_Description = "";
         AV35TFZonasNombre_Sel = "";
         AV34TFZonasNombre = "";
         AV37TFDepartamentoDepartamento_Sel = "";
         AV36TFDepartamentoDepartamento = "";
         AV39TFDepartamentoMunicipioNombre_Sel = "";
         AV38TFDepartamentoMunicipioNombre = "";
         AV58Zonaswwds_1_filterfulltext = "";
         AV59Zonaswwds_2_dynamicfiltersselector1 = "";
         AV61Zonaswwds_4_zonasnombre1 = "";
         AV63Zonaswwds_6_dynamicfiltersselector2 = "";
         AV65Zonaswwds_8_zonasnombre2 = "";
         AV67Zonaswwds_10_dynamicfiltersselector3 = "";
         AV69Zonaswwds_12_zonasnombre3 = "";
         AV72Zonaswwds_15_tfzonasnombre = "";
         AV73Zonaswwds_16_tfzonasnombre_sel = "";
         AV74Zonaswwds_17_tfdepartamentodepartamento = "";
         AV75Zonaswwds_18_tfdepartamentodepartamento_sel = "";
         AV76Zonaswwds_19_tfdepartamentomunicipionombre = "";
         AV77Zonaswwds_20_tfdepartamentomunicipionombre_sel = "";
         lV58Zonaswwds_1_filterfulltext = "";
         lV61Zonaswwds_4_zonasnombre1 = "";
         lV65Zonaswwds_8_zonasnombre2 = "";
         lV69Zonaswwds_12_zonasnombre3 = "";
         lV72Zonaswwds_15_tfzonasnombre = "";
         lV74Zonaswwds_17_tfdepartamentodepartamento = "";
         lV76Zonaswwds_19_tfdepartamentomunicipionombre = "";
         A111ZonasNombre = "";
         A113DepartamentoDepartamento = "";
         A115DepartamentoMunicipioNombre = "";
         P007K2_A112DepartamentoId = new long[1] ;
         P007K2_A114DepartamentoMunicipioId = new long[1] ;
         P007K2_A115DepartamentoMunicipioNombre = new string[] {""} ;
         P007K2_A113DepartamentoDepartamento = new string[] {""} ;
         P007K2_A111ZonasNombre = new string[] {""} ;
         P007K2_A110ZonasID = new long[1] ;
         AV28Session = context.GetSession();
         AV31GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV50PageInfo = "";
         AV47DateInfo = "";
         Gx_date = DateTime.MinValue;
         AV45AppName = "";
         AV51Phone = "";
         AV49Mail = "";
         AV53Website = "";
         AV42AddressLine1 = "";
         AV43AddressLine2 = "";
         AV44AddressLine3 = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.zonaswwexportreport__default(),
            new Object[][] {
                new Object[] {
               P007K2_A112DepartamentoId, P007K2_A114DepartamentoMunicipioId, P007K2_A115DepartamentoMunicipioNombre, P007K2_A113DepartamentoDepartamento, P007K2_A111ZonasNombre, P007K2_A110ZonasID
               }
            }
         );
         Gx_date = DateTimeUtil.Today( context);
         AV54Pgmname = "ZonasWWExportReport";
         /* GeneXus formulas. */
         Gx_line = 0;
         Gx_date = DateTimeUtil.Today( context);
         AV54Pgmname = "ZonasWWExportReport";
      }

      private short nGotPars ;
      private short GxWebError ;
      private short AV15DynamicFiltersOperator1 ;
      private short AV21DynamicFiltersOperator2 ;
      private short AV25DynamicFiltersOperator3 ;
      private short AV60Zonaswwds_3_dynamicfiltersoperator1 ;
      private short AV64Zonaswwds_7_dynamicfiltersoperator2 ;
      private short AV68Zonaswwds_11_dynamicfiltersoperator3 ;
      private short AV11OrderedBy ;
      private int M_top ;
      private int M_bot ;
      private int Line ;
      private int ToSkip ;
      private int PrtOffset ;
      private int Gx_OldLine ;
      private int AV78GXV1 ;
      private long AV32TFZonasID ;
      private long AV33TFZonasID_To ;
      private long AV70Zonaswwds_13_tfzonasid ;
      private long AV71Zonaswwds_14_tfzonasid_to ;
      private long A110ZonasID ;
      private long A112DepartamentoId ;
      private long A114DepartamentoMunicipioId ;
      private string GXKey ;
      private string gxfirstwebparm ;
      private string AV54Pgmname ;
      private string GXEncryptionTmp ;
      private string AV16ZonasNombre1 ;
      private string AV18ZonasNombre ;
      private string AV22ZonasNombre2 ;
      private string AV26ZonasNombre3 ;
      private string AV35TFZonasNombre_Sel ;
      private string AV34TFZonasNombre ;
      private string AV37TFDepartamentoDepartamento_Sel ;
      private string AV36TFDepartamentoDepartamento ;
      private string AV39TFDepartamentoMunicipioNombre_Sel ;
      private string AV38TFDepartamentoMunicipioNombre ;
      private string AV61Zonaswwds_4_zonasnombre1 ;
      private string AV65Zonaswwds_8_zonasnombre2 ;
      private string AV69Zonaswwds_12_zonasnombre3 ;
      private string AV72Zonaswwds_15_tfzonasnombre ;
      private string AV73Zonaswwds_16_tfzonasnombre_sel ;
      private string AV74Zonaswwds_17_tfdepartamentodepartamento ;
      private string AV75Zonaswwds_18_tfdepartamentodepartamento_sel ;
      private string AV76Zonaswwds_19_tfdepartamentomunicipionombre ;
      private string AV77Zonaswwds_20_tfdepartamentomunicipionombre_sel ;
      private string lV61Zonaswwds_4_zonasnombre1 ;
      private string lV65Zonaswwds_8_zonasnombre2 ;
      private string lV69Zonaswwds_12_zonasnombre3 ;
      private string lV72Zonaswwds_15_tfzonasnombre ;
      private string lV74Zonaswwds_17_tfdepartamentodepartamento ;
      private string lV76Zonaswwds_19_tfdepartamentomunicipionombre ;
      private string A111ZonasNombre ;
      private string A113DepartamentoDepartamento ;
      private string A115DepartamentoMunicipioNombre ;
      private DateTime Gx_date ;
      private bool entryPointCalled ;
      private bool AV8IsAuthorized ;
      private bool GXt_boolean1 ;
      private bool returnInSub ;
      private bool AV19DynamicFiltersEnabled2 ;
      private bool AV23DynamicFiltersEnabled3 ;
      private bool AV41TempBoolean ;
      private bool AV62Zonaswwds_5_dynamicfiltersenabled2 ;
      private bool AV66Zonaswwds_9_dynamicfiltersenabled3 ;
      private bool AV12OrderedDsc ;
      private string AV52Title ;
      private string AV13FilterFullText ;
      private string AV14DynamicFiltersSelector1 ;
      private string AV17FilterZonasNombreDescription ;
      private string AV20DynamicFiltersSelector2 ;
      private string AV24DynamicFiltersSelector3 ;
      private string AV40TFZonasID_To_Description ;
      private string AV58Zonaswwds_1_filterfulltext ;
      private string AV59Zonaswwds_2_dynamicfiltersselector1 ;
      private string AV63Zonaswwds_6_dynamicfiltersselector2 ;
      private string AV67Zonaswwds_10_dynamicfiltersselector3 ;
      private string lV58Zonaswwds_1_filterfulltext ;
      private string AV50PageInfo ;
      private string AV47DateInfo ;
      private string AV45AppName ;
      private string AV51Phone ;
      private string AV49Mail ;
      private string AV53Website ;
      private string AV42AddressLine1 ;
      private string AV43AddressLine2 ;
      private string AV44AddressLine3 ;
      private IGxSession AV28Session ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV30GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV27GridStateDynamicFilter ;
      private IDataStoreProvider pr_default ;
      private long[] P007K2_A112DepartamentoId ;
      private long[] P007K2_A114DepartamentoMunicipioId ;
      private string[] P007K2_A115DepartamentoMunicipioNombre ;
      private string[] P007K2_A113DepartamentoDepartamento ;
      private string[] P007K2_A111ZonasNombre ;
      private long[] P007K2_A110ZonasID ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV31GridStateFilterValue ;
   }

   public class zonaswwexportreport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P007K2( IGxContext context ,
                                             string AV58Zonaswwds_1_filterfulltext ,
                                             string AV59Zonaswwds_2_dynamicfiltersselector1 ,
                                             short AV60Zonaswwds_3_dynamicfiltersoperator1 ,
                                             string AV61Zonaswwds_4_zonasnombre1 ,
                                             bool AV62Zonaswwds_5_dynamicfiltersenabled2 ,
                                             string AV63Zonaswwds_6_dynamicfiltersselector2 ,
                                             short AV64Zonaswwds_7_dynamicfiltersoperator2 ,
                                             string AV65Zonaswwds_8_zonasnombre2 ,
                                             bool AV66Zonaswwds_9_dynamicfiltersenabled3 ,
                                             string AV67Zonaswwds_10_dynamicfiltersselector3 ,
                                             short AV68Zonaswwds_11_dynamicfiltersoperator3 ,
                                             string AV69Zonaswwds_12_zonasnombre3 ,
                                             long AV70Zonaswwds_13_tfzonasid ,
                                             long AV71Zonaswwds_14_tfzonasid_to ,
                                             string AV73Zonaswwds_16_tfzonasnombre_sel ,
                                             string AV72Zonaswwds_15_tfzonasnombre ,
                                             string AV75Zonaswwds_18_tfdepartamentodepartamento_sel ,
                                             string AV74Zonaswwds_17_tfdepartamentodepartamento ,
                                             string AV77Zonaswwds_20_tfdepartamentomunicipionombre_sel ,
                                             string AV76Zonaswwds_19_tfdepartamentomunicipionombre ,
                                             long A110ZonasID ,
                                             string A111ZonasNombre ,
                                             string A113DepartamentoDepartamento ,
                                             string A115DepartamentoMunicipioNombre ,
                                             short AV11OrderedBy ,
                                             bool AV12OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int2 = new short[18];
         Object[] GXv_Object3 = new Object[2];
         scmdbuf = "SELECT T1.[DepartamentoId], T1.[DepartamentoMunicipioId], T3.[DepartamentoMunicipioNombre], T2.[DepartamentoDepartamento], T1.[ZonasNombre], T1.[ZonasID] FROM (([Zonas] T1 INNER JOIN [Departamento] T2 ON T2.[DepartamentoId] = T1.[DepartamentoId]) INNER JOIN [DepartamentoMunicipio] T3 ON T3.[DepartamentoId] = T1.[DepartamentoId] AND T3.[DepartamentoMunicipioId] = T1.[DepartamentoMunicipioId])";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV58Zonaswwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( CONVERT( char(18), CAST(T1.[ZonasID] AS decimal(18,0))) like '%' + @lV58Zonaswwds_1_filterfulltext) or ( UPPER(T1.[ZonasNombre]) like '%' + UPPER(@lV58Zonaswwds_1_filterfulltext)) or ( UPPER(T2.[DepartamentoDepartamento]) like '%' + UPPER(@lV58Zonaswwds_1_filterfulltext)) or ( UPPER(T3.[DepartamentoMunicipioNombre]) like '%' + UPPER(@lV58Zonaswwds_1_filterfulltext)))");
         }
         else
         {
            GXv_int2[0] = 1;
            GXv_int2[1] = 1;
            GXv_int2[2] = 1;
            GXv_int2[3] = 1;
         }
         if ( ( StringUtil.StrCmp(AV59Zonaswwds_2_dynamicfiltersselector1, "ZONASNOMBRE") == 0 ) && ( AV60Zonaswwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Zonaswwds_4_zonasnombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[ZonasNombre]) like UPPER(@lV61Zonaswwds_4_zonasnombre1))");
         }
         else
         {
            GXv_int2[4] = 1;
         }
         if ( ( StringUtil.StrCmp(AV59Zonaswwds_2_dynamicfiltersselector1, "ZONASNOMBRE") == 0 ) && ( AV60Zonaswwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Zonaswwds_4_zonasnombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[ZonasNombre]) like '%' + UPPER(@lV61Zonaswwds_4_zonasnombre1))");
         }
         else
         {
            GXv_int2[5] = 1;
         }
         if ( AV62Zonaswwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV63Zonaswwds_6_dynamicfiltersselector2, "ZONASNOMBRE") == 0 ) && ( AV64Zonaswwds_7_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Zonaswwds_8_zonasnombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[ZonasNombre]) like UPPER(@lV65Zonaswwds_8_zonasnombre2))");
         }
         else
         {
            GXv_int2[6] = 1;
         }
         if ( AV62Zonaswwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV63Zonaswwds_6_dynamicfiltersselector2, "ZONASNOMBRE") == 0 ) && ( AV64Zonaswwds_7_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Zonaswwds_8_zonasnombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[ZonasNombre]) like '%' + UPPER(@lV65Zonaswwds_8_zonasnombre2))");
         }
         else
         {
            GXv_int2[7] = 1;
         }
         if ( AV66Zonaswwds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV67Zonaswwds_10_dynamicfiltersselector3, "ZONASNOMBRE") == 0 ) && ( AV68Zonaswwds_11_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Zonaswwds_12_zonasnombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[ZonasNombre]) like UPPER(@lV69Zonaswwds_12_zonasnombre3))");
         }
         else
         {
            GXv_int2[8] = 1;
         }
         if ( AV66Zonaswwds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV67Zonaswwds_10_dynamicfiltersselector3, "ZONASNOMBRE") == 0 ) && ( AV68Zonaswwds_11_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Zonaswwds_12_zonasnombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[ZonasNombre]) like '%' + UPPER(@lV69Zonaswwds_12_zonasnombre3))");
         }
         else
         {
            GXv_int2[9] = 1;
         }
         if ( ! (0==AV70Zonaswwds_13_tfzonasid) )
         {
            AddWhere(sWhereString, "(T1.[ZonasID] >= @AV70Zonaswwds_13_tfzonasid)");
         }
         else
         {
            GXv_int2[10] = 1;
         }
         if ( ! (0==AV71Zonaswwds_14_tfzonasid_to) )
         {
            AddWhere(sWhereString, "(T1.[ZonasID] <= @AV71Zonaswwds_14_tfzonasid_to)");
         }
         else
         {
            GXv_int2[11] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV73Zonaswwds_16_tfzonasnombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Zonaswwds_15_tfzonasnombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[ZonasNombre]) like UPPER(@lV72Zonaswwds_15_tfzonasnombre))");
         }
         else
         {
            GXv_int2[12] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Zonaswwds_16_tfzonasnombre_sel)) && ! ( StringUtil.StrCmp(AV73Zonaswwds_16_tfzonasnombre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[ZonasNombre] = @AV73Zonaswwds_16_tfzonasnombre_sel)");
         }
         else
         {
            GXv_int2[13] = 1;
         }
         if ( StringUtil.StrCmp(AV73Zonaswwds_16_tfzonasnombre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[ZonasNombre] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV75Zonaswwds_18_tfdepartamentodepartamento_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Zonaswwds_17_tfdepartamentodepartamento)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[DepartamentoDepartamento]) like UPPER(@lV74Zonaswwds_17_tfdepartamentodepartamento))");
         }
         else
         {
            GXv_int2[14] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75Zonaswwds_18_tfdepartamentodepartamento_sel)) && ! ( StringUtil.StrCmp(AV75Zonaswwds_18_tfdepartamentodepartamento_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.[DepartamentoDepartamento] = @AV75Zonaswwds_18_tfdepartamentodepartamento_sel)");
         }
         else
         {
            GXv_int2[15] = 1;
         }
         if ( StringUtil.StrCmp(AV75Zonaswwds_18_tfdepartamentodepartamento_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T2.[DepartamentoDepartamento] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV77Zonaswwds_20_tfdepartamentomunicipionombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV76Zonaswwds_19_tfdepartamentomunicipionombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T3.[DepartamentoMunicipioNombre]) like UPPER(@lV76Zonaswwds_19_tfdepartamentomunicipionombre))");
         }
         else
         {
            GXv_int2[16] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV77Zonaswwds_20_tfdepartamentomunicipionombre_sel)) && ! ( StringUtil.StrCmp(AV77Zonaswwds_20_tfdepartamentomunicipionombre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T3.[DepartamentoMunicipioNombre] = @AV77Zonaswwds_20_tfdepartamentomunicipionombre_sel)");
         }
         else
         {
            GXv_int2[17] = 1;
         }
         if ( StringUtil.StrCmp(AV77Zonaswwds_20_tfdepartamentomunicipionombre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T3.[DepartamentoMunicipioNombre] = ''))");
         }
         scmdbuf += sWhereString;
         if ( ( AV11OrderedBy == 1 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY T2.[DepartamentoDepartamento]";
         }
         else if ( ( AV11OrderedBy == 1 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T2.[DepartamentoDepartamento] DESC";
         }
         else if ( ( AV11OrderedBy == 2 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[ZonasID]";
         }
         else if ( ( AV11OrderedBy == 2 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[ZonasID] DESC";
         }
         else if ( ( AV11OrderedBy == 3 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[ZonasNombre]";
         }
         else if ( ( AV11OrderedBy == 3 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[ZonasNombre] DESC";
         }
         else if ( ( AV11OrderedBy == 4 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY T3.[DepartamentoMunicipioNombre]";
         }
         else if ( ( AV11OrderedBy == 4 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T3.[DepartamentoMunicipioNombre] DESC";
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
                     return conditional_P007K2(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (short)dynConstraints[2] , (string)dynConstraints[3] , (bool)dynConstraints[4] , (string)dynConstraints[5] , (short)dynConstraints[6] , (string)dynConstraints[7] , (bool)dynConstraints[8] , (string)dynConstraints[9] , (short)dynConstraints[10] , (string)dynConstraints[11] , (long)dynConstraints[12] , (long)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (long)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (short)dynConstraints[24] , (bool)dynConstraints[25] );
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
          Object[] prmP007K2;
          prmP007K2 = new Object[] {
          new ParDef("@lV58Zonaswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV58Zonaswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV58Zonaswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV58Zonaswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV61Zonaswwds_4_zonasnombre1",GXType.Char,120,0) ,
          new ParDef("@lV61Zonaswwds_4_zonasnombre1",GXType.Char,120,0) ,
          new ParDef("@lV65Zonaswwds_8_zonasnombre2",GXType.Char,120,0) ,
          new ParDef("@lV65Zonaswwds_8_zonasnombre2",GXType.Char,120,0) ,
          new ParDef("@lV69Zonaswwds_12_zonasnombre3",GXType.Char,120,0) ,
          new ParDef("@lV69Zonaswwds_12_zonasnombre3",GXType.Char,120,0) ,
          new ParDef("@AV70Zonaswwds_13_tfzonasid",GXType.Decimal,18,0) ,
          new ParDef("@AV71Zonaswwds_14_tfzonasid_to",GXType.Decimal,18,0) ,
          new ParDef("@lV72Zonaswwds_15_tfzonasnombre",GXType.Char,120,0) ,
          new ParDef("@AV73Zonaswwds_16_tfzonasnombre_sel",GXType.NChar,120,0) ,
          new ParDef("@lV74Zonaswwds_17_tfdepartamentodepartamento",GXType.Char,80,0) ,
          new ParDef("@AV75Zonaswwds_18_tfdepartamentodepartamento_sel",GXType.NChar,80,0) ,
          new ParDef("@lV76Zonaswwds_19_tfdepartamentomunicipionombre",GXType.Char,120,0) ,
          new ParDef("@AV77Zonaswwds_20_tfdepartamentomunicipionombre_sel",GXType.NChar,120,0)
          };
          def= new CursorDef[] {
              new CursorDef("P007K2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP007K2,100, GxCacheFrequency.OFF ,true,false )
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
                ((long[]) buf[1])[0] = rslt.getLong(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 120);
                ((string[]) buf[3])[0] = rslt.getString(4, 80);
                ((string[]) buf[4])[0] = rslt.getString(5, 120);
                ((long[]) buf[5])[0] = rslt.getLong(6);
                return;
       }
    }

 }

}

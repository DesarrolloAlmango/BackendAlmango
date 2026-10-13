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
   public class postulacioneswwexportreport : GXWebProcedure, System.Web.SessionState.IRequiresSessionState
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

      public postulacioneswwexportreport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public postulacioneswwexportreport( IGxContext context )
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
         setOutputFileName("PostulacionesWWExportReport");
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
            new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWPostulaciones", out  GXt_boolean1) ;
            AV8IsAuthorized = GXt_boolean1;
            if ( ! AV8IsAuthorized )
            {
               GXKey = Crypto.GetSiteKey( );
               GXEncryptionTmp = "wwpbaseobjects.notauthorized.aspx"+UrlEncode(StringUtil.RTrim(AV130Pgmname));
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
               AV100Title = context.GetMessage( "Lista de Postulaciones", "");
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
            HLC0( true, 0) ;
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
            HLC0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "WWP_FullTextFilterDescription", ""), 25, Gx_line+0, 204, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV13FilterFullText, "")), 204, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         if ( AV36GridState.gxTpr_Dynamicfilters.Count >= 1 )
         {
            AV32GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV36GridState.gxTpr_Dynamicfilters.Item(1));
            AV14DynamicFiltersSelector1 = AV32GridStateDynamicFilter.gxTpr_Selected;
            if ( StringUtil.StrCmp(AV14DynamicFiltersSelector1, "POSTULACIONESPROVEEDORNOMBRE") == 0 )
            {
               AV15DynamicFiltersOperator1 = AV32GridStateDynamicFilter.gxTpr_Operator;
               AV107PostulacionesProveedorNombre1 = AV32GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV107PostulacionesProveedorNombre1)) )
               {
                  if ( AV15DynamicFiltersOperator1 == 0 )
                  {
                     AV108FilterPostulacionesProveedorNombreDescription = StringUtil.Format( "%1 (%2)", context.GetMessage( "Proveedor Nombre", ""), context.GetMessage( "WWP_FilterLike", ""), "", "", "", "", "", "", "");
                  }
                  else if ( AV15DynamicFiltersOperator1 == 1 )
                  {
                     AV108FilterPostulacionesProveedorNombreDescription = StringUtil.Format( "%1 (%2)", context.GetMessage( "Proveedor Nombre", ""), context.GetMessage( "WWP_FilterContains", ""), "", "", "", "", "", "", "");
                  }
                  AV109PostulacionesProveedorNombre = AV107PostulacionesProveedorNombre1;
                  HLC0( false, 20) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV108FilterPostulacionesProveedorNombreDescription, "")), 25, Gx_line+0, 204, Gx_line+15, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV109PostulacionesProveedorNombre, "")), 204, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+20);
               }
            }
            else if ( StringUtil.StrCmp(AV14DynamicFiltersSelector1, "POSTULACIONESPROVEEDORID") == 0 )
            {
               AV15DynamicFiltersOperator1 = AV32GridStateDynamicFilter.gxTpr_Operator;
               AV16PostulacionesProveedorId1 = (long)(Math.Round(NumberUtil.Val( AV32GridStateDynamicFilter.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               if ( ! (0==AV16PostulacionesProveedorId1) )
               {
                  if ( AV15DynamicFiltersOperator1 == 0 )
                  {
                     AV17FilterPostulacionesProveedorIdDescription = StringUtil.Format( "%1 (%2)", context.GetMessage( "Proveedor Id", ""), "<", "", "", "", "", "", "", "");
                  }
                  else if ( AV15DynamicFiltersOperator1 == 1 )
                  {
                     AV17FilterPostulacionesProveedorIdDescription = StringUtil.Format( "%1 (%2)", context.GetMessage( "Proveedor Id", ""), "=", "", "", "", "", "", "", "");
                  }
                  else if ( AV15DynamicFiltersOperator1 == 2 )
                  {
                     AV17FilterPostulacionesProveedorIdDescription = StringUtil.Format( "%1 (%2)", context.GetMessage( "Proveedor Id", ""), ">", "", "", "", "", "", "", "");
                  }
                  AV18PostulacionesProveedorId = AV16PostulacionesProveedorId1;
                  HLC0( false, 20) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV17FilterPostulacionesProveedorIdDescription, "")), 25, Gx_line+0, 204, Gx_line+15, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV18PostulacionesProveedorId), "ZZZZZZZZZZZZZZZZZ9")), 204, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+20);
               }
            }
            else if ( StringUtil.StrCmp(AV14DynamicFiltersSelector1, "SERVICIOSNOMBRE") == 0 )
            {
               AV15DynamicFiltersOperator1 = AV32GridStateDynamicFilter.gxTpr_Operator;
               AV19ServiciosNombre1 = AV32GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV19ServiciosNombre1)) )
               {
                  if ( AV15DynamicFiltersOperator1 == 0 )
                  {
                     AV20FilterServiciosNombreDescription = StringUtil.Format( "%1 (%2)", context.GetMessage( "Servicios Nombre", ""), context.GetMessage( "WWP_FilterLike", ""), "", "", "", "", "", "", "");
                  }
                  else if ( AV15DynamicFiltersOperator1 == 1 )
                  {
                     AV20FilterServiciosNombreDescription = StringUtil.Format( "%1 (%2)", context.GetMessage( "Servicios Nombre", ""), context.GetMessage( "WWP_FilterContains", ""), "", "", "", "", "", "", "");
                  }
                  AV21ServiciosNombre = AV19ServiciosNombre1;
                  HLC0( false, 20) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV20FilterServiciosNombreDescription, "")), 25, Gx_line+0, 204, Gx_line+15, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV21ServiciosNombre, "")), 204, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+20);
               }
            }
            if ( AV36GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV22DynamicFiltersEnabled2 = true;
               AV32GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV36GridState.gxTpr_Dynamicfilters.Item(2));
               AV23DynamicFiltersSelector2 = AV32GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV23DynamicFiltersSelector2, "POSTULACIONESPROVEEDORNOMBRE") == 0 )
               {
                  AV24DynamicFiltersOperator2 = AV32GridStateDynamicFilter.gxTpr_Operator;
                  AV110PostulacionesProveedorNombre2 = AV32GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV110PostulacionesProveedorNombre2)) )
                  {
                     if ( AV24DynamicFiltersOperator2 == 0 )
                     {
                        AV108FilterPostulacionesProveedorNombreDescription = StringUtil.Format( "%1 (%2)", context.GetMessage( "Proveedor Nombre", ""), context.GetMessage( "WWP_FilterLike", ""), "", "", "", "", "", "", "");
                     }
                     else if ( AV24DynamicFiltersOperator2 == 1 )
                     {
                        AV108FilterPostulacionesProveedorNombreDescription = StringUtil.Format( "%1 (%2)", context.GetMessage( "Proveedor Nombre", ""), context.GetMessage( "WWP_FilterContains", ""), "", "", "", "", "", "", "");
                     }
                     AV109PostulacionesProveedorNombre = AV110PostulacionesProveedorNombre2;
                     HLC0( false, 20) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV108FilterPostulacionesProveedorNombreDescription, "")), 25, Gx_line+0, 204, Gx_line+15, 0, 0, 0, 0) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV109PostulacionesProveedorNombre, "")), 204, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                     Gx_OldLine = Gx_line;
                     Gx_line = (int)(Gx_line+20);
                  }
               }
               else if ( StringUtil.StrCmp(AV23DynamicFiltersSelector2, "POSTULACIONESPROVEEDORID") == 0 )
               {
                  AV24DynamicFiltersOperator2 = AV32GridStateDynamicFilter.gxTpr_Operator;
                  AV25PostulacionesProveedorId2 = (long)(Math.Round(NumberUtil.Val( AV32GridStateDynamicFilter.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
                  if ( ! (0==AV25PostulacionesProveedorId2) )
                  {
                     if ( AV24DynamicFiltersOperator2 == 0 )
                     {
                        AV17FilterPostulacionesProveedorIdDescription = StringUtil.Format( "%1 (%2)", context.GetMessage( "Proveedor Id", ""), "<", "", "", "", "", "", "", "");
                     }
                     else if ( AV24DynamicFiltersOperator2 == 1 )
                     {
                        AV17FilterPostulacionesProveedorIdDescription = StringUtil.Format( "%1 (%2)", context.GetMessage( "Proveedor Id", ""), "=", "", "", "", "", "", "", "");
                     }
                     else if ( AV24DynamicFiltersOperator2 == 2 )
                     {
                        AV17FilterPostulacionesProveedorIdDescription = StringUtil.Format( "%1 (%2)", context.GetMessage( "Proveedor Id", ""), ">", "", "", "", "", "", "", "");
                     }
                     AV18PostulacionesProveedorId = AV25PostulacionesProveedorId2;
                     HLC0( false, 20) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV17FilterPostulacionesProveedorIdDescription, "")), 25, Gx_line+0, 204, Gx_line+15, 0, 0, 0, 0) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV18PostulacionesProveedorId), "ZZZZZZZZZZZZZZZZZ9")), 204, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                     Gx_OldLine = Gx_line;
                     Gx_line = (int)(Gx_line+20);
                  }
               }
               else if ( StringUtil.StrCmp(AV23DynamicFiltersSelector2, "SERVICIOSNOMBRE") == 0 )
               {
                  AV24DynamicFiltersOperator2 = AV32GridStateDynamicFilter.gxTpr_Operator;
                  AV26ServiciosNombre2 = AV32GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV26ServiciosNombre2)) )
                  {
                     if ( AV24DynamicFiltersOperator2 == 0 )
                     {
                        AV20FilterServiciosNombreDescription = StringUtil.Format( "%1 (%2)", context.GetMessage( "Servicios Nombre", ""), context.GetMessage( "WWP_FilterLike", ""), "", "", "", "", "", "", "");
                     }
                     else if ( AV24DynamicFiltersOperator2 == 1 )
                     {
                        AV20FilterServiciosNombreDescription = StringUtil.Format( "%1 (%2)", context.GetMessage( "Servicios Nombre", ""), context.GetMessage( "WWP_FilterContains", ""), "", "", "", "", "", "", "");
                     }
                     AV21ServiciosNombre = AV26ServiciosNombre2;
                     HLC0( false, 20) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV20FilterServiciosNombreDescription, "")), 25, Gx_line+0, 204, Gx_line+15, 0, 0, 0, 0) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV21ServiciosNombre, "")), 204, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                     Gx_OldLine = Gx_line;
                     Gx_line = (int)(Gx_line+20);
                  }
               }
               if ( AV36GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV27DynamicFiltersEnabled3 = true;
                  AV32GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV36GridState.gxTpr_Dynamicfilters.Item(3));
                  AV28DynamicFiltersSelector3 = AV32GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV28DynamicFiltersSelector3, "POSTULACIONESPROVEEDORNOMBRE") == 0 )
                  {
                     AV29DynamicFiltersOperator3 = AV32GridStateDynamicFilter.gxTpr_Operator;
                     AV111PostulacionesProveedorNombre3 = AV32GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV111PostulacionesProveedorNombre3)) )
                     {
                        if ( AV29DynamicFiltersOperator3 == 0 )
                        {
                           AV108FilterPostulacionesProveedorNombreDescription = StringUtil.Format( "%1 (%2)", context.GetMessage( "Proveedor Nombre", ""), context.GetMessage( "WWP_FilterLike", ""), "", "", "", "", "", "", "");
                        }
                        else if ( AV29DynamicFiltersOperator3 == 1 )
                        {
                           AV108FilterPostulacionesProveedorNombreDescription = StringUtil.Format( "%1 (%2)", context.GetMessage( "Proveedor Nombre", ""), context.GetMessage( "WWP_FilterContains", ""), "", "", "", "", "", "", "");
                        }
                        AV109PostulacionesProveedorNombre = AV111PostulacionesProveedorNombre3;
                        HLC0( false, 20) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV108FilterPostulacionesProveedorNombreDescription, "")), 25, Gx_line+0, 204, Gx_line+15, 0, 0, 0, 0) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV109PostulacionesProveedorNombre, "")), 204, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                        Gx_OldLine = Gx_line;
                        Gx_line = (int)(Gx_line+20);
                     }
                  }
                  else if ( StringUtil.StrCmp(AV28DynamicFiltersSelector3, "POSTULACIONESPROVEEDORID") == 0 )
                  {
                     AV29DynamicFiltersOperator3 = AV32GridStateDynamicFilter.gxTpr_Operator;
                     AV30PostulacionesProveedorId3 = (long)(Math.Round(NumberUtil.Val( AV32GridStateDynamicFilter.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
                     if ( ! (0==AV30PostulacionesProveedorId3) )
                     {
                        if ( AV29DynamicFiltersOperator3 == 0 )
                        {
                           AV17FilterPostulacionesProveedorIdDescription = StringUtil.Format( "%1 (%2)", context.GetMessage( "Proveedor Id", ""), "<", "", "", "", "", "", "", "");
                        }
                        else if ( AV29DynamicFiltersOperator3 == 1 )
                        {
                           AV17FilterPostulacionesProveedorIdDescription = StringUtil.Format( "%1 (%2)", context.GetMessage( "Proveedor Id", ""), "=", "", "", "", "", "", "", "");
                        }
                        else if ( AV29DynamicFiltersOperator3 == 2 )
                        {
                           AV17FilterPostulacionesProveedorIdDescription = StringUtil.Format( "%1 (%2)", context.GetMessage( "Proveedor Id", ""), ">", "", "", "", "", "", "", "");
                        }
                        AV18PostulacionesProveedorId = AV30PostulacionesProveedorId3;
                        HLC0( false, 20) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV17FilterPostulacionesProveedorIdDescription, "")), 25, Gx_line+0, 204, Gx_line+15, 0, 0, 0, 0) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV18PostulacionesProveedorId), "ZZZZZZZZZZZZZZZZZ9")), 204, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                        Gx_OldLine = Gx_line;
                        Gx_line = (int)(Gx_line+20);
                     }
                  }
                  else if ( StringUtil.StrCmp(AV28DynamicFiltersSelector3, "SERVICIOSNOMBRE") == 0 )
                  {
                     AV29DynamicFiltersOperator3 = AV32GridStateDynamicFilter.gxTpr_Operator;
                     AV31ServiciosNombre3 = AV32GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV31ServiciosNombre3)) )
                     {
                        if ( AV29DynamicFiltersOperator3 == 0 )
                        {
                           AV20FilterServiciosNombreDescription = StringUtil.Format( "%1 (%2)", context.GetMessage( "Servicios Nombre", ""), context.GetMessage( "WWP_FilterLike", ""), "", "", "", "", "", "", "");
                        }
                        else if ( AV29DynamicFiltersOperator3 == 1 )
                        {
                           AV20FilterServiciosNombreDescription = StringUtil.Format( "%1 (%2)", context.GetMessage( "Servicios Nombre", ""), context.GetMessage( "WWP_FilterContains", ""), "", "", "", "", "", "", "");
                        }
                        AV21ServiciosNombre = AV31ServiciosNombre3;
                        HLC0( false, 20) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV20FilterServiciosNombreDescription, "")), 25, Gx_line+0, 204, Gx_line+15, 0, 0, 0, 0) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV21ServiciosNombre, "")), 204, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                        Gx_OldLine = Gx_line;
                        Gx_line = (int)(Gx_line+20);
                     }
                  }
               }
            }
         }
         if ( ! ( (0==AV38TFPostulacionesId) && (0==AV39TFPostulacionesId_To) ) )
         {
            HLC0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Id", ""), 25, Gx_line+0, 204, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV38TFPostulacionesId), "ZZZZZZZZZZZZZZZZZ9")), 204, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV77TFPostulacionesId_To_Description = StringUtil.Format( "%1 (%2)", context.GetMessage( "Id", ""), context.GetMessage( "WWP_TSTo", ""), "", "", "", "", "", "", "");
            HLC0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV77TFPostulacionesId_To_Description, "")), 25, Gx_line+0, 204, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV39TFPostulacionesId_To), "ZZZZZZZZZZZZZZZZZ9")), 204, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         if ( ! ( (0==AV40TFServiciosId) && (0==AV41TFServiciosId_To) ) )
         {
            HLC0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Id", ""), 25, Gx_line+0, 204, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV40TFServiciosId), "ZZZZZZZZZZZZZZZZZ9")), 204, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV78TFServiciosId_To_Description = StringUtil.Format( "%1 (%2)", context.GetMessage( "Id", ""), context.GetMessage( "WWP_TSTo", ""), "", "", "", "", "", "", "");
            HLC0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV78TFServiciosId_To_Description, "")), 25, Gx_line+0, 204, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV41TFServiciosId_To), "ZZZZZZZZZZZZZZZZZ9")), 204, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV43TFServiciosNombre_Sel)) )
         {
            AV88TempBoolean = (bool)(((StringUtil.StrCmp(AV43TFServiciosNombre_Sel, "<#Empty#>")==0)));
            AV43TFServiciosNombre_Sel = (AV88TempBoolean ? context.GetMessage( "WWP_TitleFilter_EmptyOption", "") : AV43TFServiciosNombre_Sel);
            HLC0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Nombre", ""), 25, Gx_line+0, 204, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV43TFServiciosNombre_Sel, "")), 204, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV43TFServiciosNombre_Sel = (AV88TempBoolean ? "<#Empty#>" : AV43TFServiciosNombre_Sel);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV42TFServiciosNombre)) )
            {
               HLC0( false, 20) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(context.GetMessage( "Nombre", ""), 25, Gx_line+0, 204, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV42TFServiciosNombre, "")), 204, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
         if ( ! ( (0==AV44TFPostulacionesProveedorId) && (0==AV45TFPostulacionesProveedorId_To) ) )
         {
            HLC0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Proveedor Id", ""), 25, Gx_line+0, 204, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV44TFPostulacionesProveedorId), "ZZZZZZZZZZZZZZZZZ9")), 204, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV79TFPostulacionesProveedorId_To_Description = StringUtil.Format( "%1 (%2)", context.GetMessage( "Proveedor Id", ""), context.GetMessage( "WWP_TSTo", ""), "", "", "", "", "", "", "");
            HLC0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV79TFPostulacionesProveedorId_To_Description, "")), 25, Gx_line+0, 204, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV45TFPostulacionesProveedorId_To), "ZZZZZZZZZZZZZZZZZ9")), 204, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV103TFPostulacionesProveedorNombre_Sel)) )
         {
            AV88TempBoolean = (bool)(((StringUtil.StrCmp(AV103TFPostulacionesProveedorNombre_Sel, "<#Empty#>")==0)));
            AV103TFPostulacionesProveedorNombre_Sel = (AV88TempBoolean ? context.GetMessage( "WWP_TitleFilter_EmptyOption", "") : AV103TFPostulacionesProveedorNombre_Sel);
            HLC0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Proveedor Nombre", ""), 25, Gx_line+0, 204, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV103TFPostulacionesProveedorNombre_Sel, "")), 204, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV103TFPostulacionesProveedorNombre_Sel = (AV88TempBoolean ? "<#Empty#>" : AV103TFPostulacionesProveedorNombre_Sel);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV102TFPostulacionesProveedorNombre)) )
            {
               HLC0( false, 20) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(context.GetMessage( "Proveedor Nombre", ""), 25, Gx_line+0, 204, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV102TFPostulacionesProveedorNombre, "")), 204, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
         if ( ! ( (Convert.ToDecimal(0)==AV46TFPostulacionesPrecio) && (Convert.ToDecimal(0)==AV47TFPostulacionesPrecio_To) ) )
         {
            HLC0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Precio", ""), 25, Gx_line+0, 204, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV46TFPostulacionesPrecio, "ZZZZZZ,ZZZ,ZZZ,ZZ9.99")), 204, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV80TFPostulacionesPrecio_To_Description = StringUtil.Format( "%1 (%2)", context.GetMessage( "Precio", ""), context.GetMessage( "WWP_TSTo", ""), "", "", "", "", "", "", "");
            HLC0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV80TFPostulacionesPrecio_To_Description, "")), 25, Gx_line+0, 204, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV47TFPostulacionesPrecio_To, "ZZZZZZ,ZZZ,ZZZ,ZZ9.99")), 204, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         if ( ! ( (0==AV104TFPostulacionesMultimediaSerial) && (0==AV105TFPostulacionesMultimediaSerial_To) ) )
         {
            HLC0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Multimedia Serial", ""), 25, Gx_line+0, 204, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV104TFPostulacionesMultimediaSerial), "ZZZ9")), 204, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV106TFPostulacionesMultimediaSerial_To_Description = StringUtil.Format( "%1 (%2)", context.GetMessage( "Multimedia Serial", ""), context.GetMessage( "WWP_TSTo", ""), "", "", "", "", "", "", "");
            HLC0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV106TFPostulacionesMultimediaSerial_To_Description, "")), 25, Gx_line+0, 204, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV105TFPostulacionesMultimediaSerial_To), "ZZZ9")), 204, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         if ( ! ( (0==AV112TFPostulacionesSolicitudesId) && (0==AV113TFPostulacionesSolicitudesId_To) ) )
         {
            HLC0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Solicitudes Id", ""), 25, Gx_line+0, 204, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV112TFPostulacionesSolicitudesId), "ZZZZZZZZZZZZZZZZZ9")), 204, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV114TFPostulacionesSolicitudesId_To_Description = StringUtil.Format( "%1 (%2)", context.GetMessage( "Solicitudes Id", ""), context.GetMessage( "WWP_TSTo", ""), "", "", "", "", "", "", "");
            HLC0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV114TFPostulacionesSolicitudesId_To_Description, "")), 25, Gx_line+0, 204, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV113TFPostulacionesSolicitudesId_To), "ZZZZZZZZZZZZZZZZZ9")), 204, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV49TFPostulacionesDescripcion_Sel)) )
         {
            AV88TempBoolean = (bool)(((StringUtil.StrCmp(AV49TFPostulacionesDescripcion_Sel, "<#Empty#>")==0)));
            AV49TFPostulacionesDescripcion_Sel = (AV88TempBoolean ? context.GetMessage( "WWP_TitleFilter_EmptyOption", "") : AV49TFPostulacionesDescripcion_Sel);
            HLC0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Descripcion", ""), 25, Gx_line+0, 204, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV49TFPostulacionesDescripcion_Sel, "")), 204, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV49TFPostulacionesDescripcion_Sel = (AV88TempBoolean ? "<#Empty#>" : AV49TFPostulacionesDescripcion_Sel);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV48TFPostulacionesDescripcion)) )
            {
               HLC0( false, 20) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(context.GetMessage( "Descripcion", ""), 25, Gx_line+0, 204, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV48TFPostulacionesDescripcion, "")), 204, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
         if ( ! (0==AV50TFPostulacionesReqSuministros_Sel) )
         {
            if ( AV50TFPostulacionesReqSuministros_Sel == 1 )
            {
               AV81FilterTFPostulacionesReqSuministros_SelValueDescription = context.GetMessage( "WWP_TSChecked", "");
            }
            else if ( AV50TFPostulacionesReqSuministros_Sel == 2 )
            {
               AV81FilterTFPostulacionesReqSuministros_SelValueDescription = context.GetMessage( "WWP_TSUnChecked", "");
            }
            HLC0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Req Suministros", ""), 25, Gx_line+0, 204, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV81FilterTFPostulacionesReqSuministros_SelValueDescription, "")), 204, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV52TFPostulacionesSuministrosDescripcion_Sel)) )
         {
            AV88TempBoolean = (bool)(((StringUtil.StrCmp(AV52TFPostulacionesSuministrosDescripcion_Sel, "<#Empty#>")==0)));
            AV52TFPostulacionesSuministrosDescripcion_Sel = (AV88TempBoolean ? context.GetMessage( "WWP_TitleFilter_EmptyOption", "") : AV52TFPostulacionesSuministrosDescripcion_Sel);
            HLC0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Suministros Descripcion", ""), 25, Gx_line+0, 204, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV52TFPostulacionesSuministrosDescripcion_Sel, "")), 204, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV52TFPostulacionesSuministrosDescripcion_Sel = (AV88TempBoolean ? "<#Empty#>" : AV52TFPostulacionesSuministrosDescripcion_Sel);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV51TFPostulacionesSuministrosDescripcion)) )
            {
               HLC0( false, 20) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(context.GetMessage( "Suministros Descripcion", ""), 25, Gx_line+0, 204, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV51TFPostulacionesSuministrosDescripcion, "")), 204, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
         if ( ! ( (DateTime.MinValue==AV53TFPostulacionesFechaTrabajo) && (DateTime.MinValue==AV54TFPostulacionesFechaTrabajo_To) ) )
         {
            HLC0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Fecha Trabajo", ""), 25, Gx_line+0, 204, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.localUtil.Format( AV53TFPostulacionesFechaTrabajo, "99/99/99"), 204, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV82TFPostulacionesFechaTrabajo_To_Description = StringUtil.Format( "%1 (%2)", context.GetMessage( "Fecha Trabajo", ""), context.GetMessage( "WWP_TSTo", ""), "", "", "", "", "", "", "");
            HLC0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV82TFPostulacionesFechaTrabajo_To_Description, "")), 25, Gx_line+0, 204, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.localUtil.Format( AV54TFPostulacionesFechaTrabajo_To, "99/99/99"), 204, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         if ( ! ( (DateTime.MinValue==AV55TFPostulacionesFechaCierre) && (DateTime.MinValue==AV56TFPostulacionesFechaCierre_To) ) )
         {
            HLC0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Fecha Cierre", ""), 25, Gx_line+0, 204, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.localUtil.Format( AV55TFPostulacionesFechaCierre, "99/99/99"), 204, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV83TFPostulacionesFechaCierre_To_Description = StringUtil.Format( "%1 (%2)", context.GetMessage( "Fecha Cierre", ""), context.GetMessage( "WWP_TSTo", ""), "", "", "", "", "", "", "");
            HLC0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV83TFPostulacionesFechaCierre_To_Description, "")), 25, Gx_line+0, 204, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.localUtil.Format( AV56TFPostulacionesFechaCierre_To, "99/99/99"), 204, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV58TFPostulacionesHoraCierre_Sel)) )
         {
            AV88TempBoolean = (bool)(((StringUtil.StrCmp(AV58TFPostulacionesHoraCierre_Sel, "<#Empty#>")==0)));
            AV58TFPostulacionesHoraCierre_Sel = (AV88TempBoolean ? context.GetMessage( "WWP_TitleFilter_EmptyOption", "") : AV58TFPostulacionesHoraCierre_Sel);
            HLC0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Hora Cierre", ""), 25, Gx_line+0, 204, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV58TFPostulacionesHoraCierre_Sel, "")), 204, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV58TFPostulacionesHoraCierre_Sel = (AV88TempBoolean ? "<#Empty#>" : AV58TFPostulacionesHoraCierre_Sel);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57TFPostulacionesHoraCierre)) )
            {
               HLC0( false, 20) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(context.GetMessage( "Hora Cierre", ""), 25, Gx_line+0, 204, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV57TFPostulacionesHoraCierre, "")), 204, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV129TFPostulacionesTipoFecha_Sel)) )
         {
            AV88TempBoolean = (bool)(((StringUtil.StrCmp(AV129TFPostulacionesTipoFecha_Sel, "<#Empty#>")==0)));
            AV129TFPostulacionesTipoFecha_Sel = (AV88TempBoolean ? context.GetMessage( "WWP_TitleFilter_EmptyOption", "") : AV129TFPostulacionesTipoFecha_Sel);
            HLC0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Tipo Fecha", ""), 25, Gx_line+0, 204, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV129TFPostulacionesTipoFecha_Sel, "")), 204, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV129TFPostulacionesTipoFecha_Sel = (AV88TempBoolean ? "<#Empty#>" : AV129TFPostulacionesTipoFecha_Sel);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59TFPostulacionesTipoFecha)) )
            {
               HLC0( false, 20) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(context.GetMessage( "Tipo Fecha", ""), 25, Gx_line+0, 204, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV59TFPostulacionesTipoFecha, "")), 204, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62TFPostulacionesRgoHoraservicio_Sel)) )
         {
            AV88TempBoolean = (bool)(((StringUtil.StrCmp(AV62TFPostulacionesRgoHoraservicio_Sel, "<#Empty#>")==0)));
            AV62TFPostulacionesRgoHoraservicio_Sel = (AV88TempBoolean ? context.GetMessage( "WWP_TitleFilter_EmptyOption", "") : AV62TFPostulacionesRgoHoraservicio_Sel);
            HLC0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Rgo Horaservicio", ""), 25, Gx_line+0, 204, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV62TFPostulacionesRgoHoraservicio_Sel, "")), 204, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV62TFPostulacionesRgoHoraservicio_Sel = (AV88TempBoolean ? "<#Empty#>" : AV62TFPostulacionesRgoHoraservicio_Sel);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61TFPostulacionesRgoHoraservicio)) )
            {
               HLC0( false, 20) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(context.GetMessage( "Rgo Horaservicio", ""), 25, Gx_line+0, 204, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV61TFPostulacionesRgoHoraservicio, "")), 204, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64TFPostulacionesApellidoNombre_Sel)) )
         {
            AV88TempBoolean = (bool)(((StringUtil.StrCmp(AV64TFPostulacionesApellidoNombre_Sel, "<#Empty#>")==0)));
            AV64TFPostulacionesApellidoNombre_Sel = (AV88TempBoolean ? context.GetMessage( "WWP_TitleFilter_EmptyOption", "") : AV64TFPostulacionesApellidoNombre_Sel);
            HLC0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Apellido Nombre", ""), 25, Gx_line+0, 204, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV64TFPostulacionesApellidoNombre_Sel, "")), 204, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV64TFPostulacionesApellidoNombre_Sel = (AV88TempBoolean ? "<#Empty#>" : AV64TFPostulacionesApellidoNombre_Sel);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63TFPostulacionesApellidoNombre)) )
            {
               HLC0( false, 20) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(context.GetMessage( "Apellido Nombre", ""), 25, Gx_line+0, 204, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV63TFPostulacionesApellidoNombre, "")), 204, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66TFPostulacionesMail_Sel)) )
         {
            AV88TempBoolean = (bool)(((StringUtil.StrCmp(AV66TFPostulacionesMail_Sel, "<#Empty#>")==0)));
            AV66TFPostulacionesMail_Sel = (AV88TempBoolean ? context.GetMessage( "WWP_TitleFilter_EmptyOption", "") : AV66TFPostulacionesMail_Sel);
            HLC0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Mail", ""), 25, Gx_line+0, 204, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV66TFPostulacionesMail_Sel, "")), 204, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV66TFPostulacionesMail_Sel = (AV88TempBoolean ? "<#Empty#>" : AV66TFPostulacionesMail_Sel);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65TFPostulacionesMail)) )
            {
               HLC0( false, 20) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(context.GetMessage( "Mail", ""), 25, Gx_line+0, 204, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV65TFPostulacionesMail, "")), 204, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68TFPostulacionesTelefono_Sel)) )
         {
            AV88TempBoolean = (bool)(((StringUtil.StrCmp(AV68TFPostulacionesTelefono_Sel, "<#Empty#>")==0)));
            AV68TFPostulacionesTelefono_Sel = (AV88TempBoolean ? context.GetMessage( "WWP_TitleFilter_EmptyOption", "") : AV68TFPostulacionesTelefono_Sel);
            HLC0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Telefono", ""), 25, Gx_line+0, 204, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV68TFPostulacionesTelefono_Sel, "")), 204, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV68TFPostulacionesTelefono_Sel = (AV88TempBoolean ? "<#Empty#>" : AV68TFPostulacionesTelefono_Sel);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67TFPostulacionesTelefono)) )
            {
               HLC0( false, 20) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(context.GetMessage( "Telefono", ""), 25, Gx_line+0, 204, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV67TFPostulacionesTelefono, "")), 204, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
         if ( ! ( (DateTime.MinValue==AV69TFPostulacionesFechaAlta) && (DateTime.MinValue==AV70TFPostulacionesFechaAlta_To) ) )
         {
            HLC0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Fecha", ""), 25, Gx_line+0, 204, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.localUtil.Format( AV69TFPostulacionesFechaAlta, "99/99/99 99:99"), 204, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV85TFPostulacionesFechaAlta_To_Description = StringUtil.Format( "%1 (%2)", context.GetMessage( "Fecha", ""), context.GetMessage( "WWP_TSTo", ""), "", "", "", "", "", "", "");
            HLC0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV85TFPostulacionesFechaAlta_To_Description, "")), 25, Gx_line+0, 204, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.localUtil.Format( AV70TFPostulacionesFechaAlta_To, "99/99/99 99:99"), 204, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         AV74TFPostulacionesEstado_Sels.FromJSonString(AV71TFPostulacionesEstado_SelsJson, null);
         if ( ! ( AV74TFPostulacionesEstado_Sels.Count == 0 ) )
         {
            AV89i = 1;
            AV133GXV1 = 1;
            while ( AV133GXV1 <= AV74TFPostulacionesEstado_Sels.Count )
            {
               AV73TFPostulacionesEstado_Sel = AV74TFPostulacionesEstado_Sels.GetString(AV133GXV1);
               if ( AV89i == 1 )
               {
                  AV72TFPostulacionesEstado_SelDscs = "";
               }
               else
               {
                  AV72TFPostulacionesEstado_SelDscs += ", ";
               }
               AV86FilterTFPostulacionesEstado_SelValueDescription = "";
               if ( StringUtil.StrCmp(StringUtil.Trim( AV73TFPostulacionesEstado_Sel), "HAB") == 0 )
               {
                  AV86FilterTFPostulacionesEstado_SelValueDescription = context.GetMessage( "Habilitado", "");
               }
               else if ( StringUtil.StrCmp(StringUtil.Trim( AV73TFPostulacionesEstado_Sel), "DES") == 0 )
               {
                  AV86FilterTFPostulacionesEstado_SelValueDescription = context.GetMessage( "Deshabilitado", "");
               }
               else if ( StringUtil.StrCmp(StringUtil.Trim( AV73TFPostulacionesEstado_Sel), "GAN") == 0 )
               {
                  AV86FilterTFPostulacionesEstado_SelValueDescription = context.GetMessage( "Ganador", "");
               }
               AV72TFPostulacionesEstado_SelDscs += AV86FilterTFPostulacionesEstado_SelValueDescription;
               AV89i = (long)(AV89i+1);
               AV133GXV1 = (int)(AV133GXV1+1);
            }
            HLC0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Estado", ""), 25, Gx_line+0, 204, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV72TFPostulacionesEstado_SelDscs, "")), 204, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         if ( ! ( (0==AV75TFPostulacionesSecUserId) && (0==AV76TFPostulacionesSecUserId_To) ) )
         {
            HLC0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "User Id", ""), 25, Gx_line+0, 204, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV75TFPostulacionesSecUserId), "ZZZZZZZZZZZZZZZZZ9")), 204, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV87TFPostulacionesSecUserId_To_Description = StringUtil.Format( "%1 (%2)", context.GetMessage( "User Id", ""), context.GetMessage( "WWP_TSTo", ""), "", "", "", "", "", "", "");
            HLC0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV87TFPostulacionesSecUserId_To_Description, "")), 25, Gx_line+0, 204, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV76TFPostulacionesSecUserId_To), "ZZZZZZZZZZZZZZZZZ9")), 204, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
      }

      protected void S121( )
      {
         /* 'PRINTCOLUMNTITLES' Routine */
         returnInSub = false;
         HLC0( false, 22) ;
         getPrinter().GxDrawLine(25, Gx_line+21, 789, Gx_line+21, 2, 8, 160, 134, 0) ;
         Gx_OldLine = Gx_line;
         Gx_line = (int)(Gx_line+22);
         HLC0( false, 37) ;
         getPrinter().GxAttris("Microsoft Sans Serif", 9, false, false, false, false, 0, 8, 160, 134, 0, 255, 255, 255) ;
         getPrinter().GxDrawText(context.GetMessage( "Id", ""), 30, Gx_line+10, 60, Gx_line+27, 2, 0, 0, 0) ;
         getPrinter().GxDrawText(context.GetMessage( "Id", ""), 64, Gx_line+10, 94, Gx_line+27, 2, 0, 0, 0) ;
         getPrinter().GxDrawText(context.GetMessage( "Nombre", ""), 98, Gx_line+10, 128, Gx_line+27, 0, 0, 0, 0) ;
         getPrinter().GxDrawText(context.GetMessage( "Proveedor Id", ""), 132, Gx_line+10, 162, Gx_line+27, 2, 0, 0, 0) ;
         getPrinter().GxDrawText(context.GetMessage( "Proveedor Nombre", ""), 166, Gx_line+10, 196, Gx_line+27, 0, 0, 0, 0) ;
         getPrinter().GxDrawText(context.GetMessage( "Precio", ""), 200, Gx_line+10, 230, Gx_line+27, 2, 0, 0, 0) ;
         getPrinter().GxDrawText(context.GetMessage( "Multimedia Serial", ""), 234, Gx_line+10, 264, Gx_line+27, 2, 0, 0, 0) ;
         getPrinter().GxDrawText(context.GetMessage( "Solicitudes Id", ""), 268, Gx_line+10, 298, Gx_line+27, 2, 0, 0, 0) ;
         getPrinter().GxDrawText(context.GetMessage( "Descripcion", ""), 302, Gx_line+10, 332, Gx_line+27, 0, 0, 0, 0) ;
         getPrinter().GxDrawText(context.GetMessage( "Req Suministros", ""), 336, Gx_line+10, 366, Gx_line+27, 0, 0, 0, 0) ;
         getPrinter().GxDrawText(context.GetMessage( "Suministros Descripcion", ""), 370, Gx_line+10, 400, Gx_line+27, 0, 0, 0, 0) ;
         getPrinter().GxDrawText(context.GetMessage( "Fecha Trabajo", ""), 404, Gx_line+10, 434, Gx_line+27, 0, 0, 0, 0) ;
         getPrinter().GxDrawText(context.GetMessage( "Fecha Cierre", ""), 438, Gx_line+10, 468, Gx_line+27, 0, 0, 0, 0) ;
         getPrinter().GxDrawText(context.GetMessage( "Hora Cierre", ""), 472, Gx_line+10, 503, Gx_line+27, 0, 0, 0, 0) ;
         getPrinter().GxDrawText(context.GetMessage( "Tipo Fecha", ""), 507, Gx_line+10, 538, Gx_line+27, 0, 0, 0, 0) ;
         getPrinter().GxDrawText(context.GetMessage( "Rgo Horaservicio", ""), 542, Gx_line+10, 573, Gx_line+27, 0, 0, 0, 0) ;
         getPrinter().GxDrawText(context.GetMessage( "Apellido Nombre", ""), 577, Gx_line+10, 609, Gx_line+27, 0, 0, 0, 0) ;
         getPrinter().GxDrawText(context.GetMessage( "Mail", ""), 613, Gx_line+10, 645, Gx_line+27, 0, 0, 0, 0) ;
         getPrinter().GxDrawText(context.GetMessage( "Telefono", ""), 649, Gx_line+10, 681, Gx_line+27, 0, 0, 0, 0) ;
         getPrinter().GxDrawText(context.GetMessage( "Fecha", ""), 685, Gx_line+10, 716, Gx_line+27, 0, 0, 0, 0) ;
         getPrinter().GxDrawText(context.GetMessage( "Estado", ""), 720, Gx_line+10, 752, Gx_line+27, 0, 0, 0, 0) ;
         getPrinter().GxDrawText(context.GetMessage( "User Id", ""), 756, Gx_line+10, 787, Gx_line+27, 2, 0, 0, 0) ;
         Gx_OldLine = Gx_line;
         Gx_line = (int)(Gx_line+37);
      }

      protected void S131( )
      {
         /* 'PRINTDATA' Routine */
         returnInSub = false;
         AV135Postulacioneswwds_1_filterfulltext = AV13FilterFullText;
         AV136Postulacioneswwds_2_dynamicfiltersselector1 = AV14DynamicFiltersSelector1;
         AV137Postulacioneswwds_3_dynamicfiltersoperator1 = AV15DynamicFiltersOperator1;
         AV138Postulacioneswwds_4_postulacionesproveedornombre1 = AV107PostulacionesProveedorNombre1;
         AV139Postulacioneswwds_5_postulacionesproveedorid1 = AV16PostulacionesProveedorId1;
         AV140Postulacioneswwds_6_serviciosnombre1 = AV19ServiciosNombre1;
         AV141Postulacioneswwds_7_dynamicfiltersenabled2 = AV22DynamicFiltersEnabled2;
         AV142Postulacioneswwds_8_dynamicfiltersselector2 = AV23DynamicFiltersSelector2;
         AV143Postulacioneswwds_9_dynamicfiltersoperator2 = AV24DynamicFiltersOperator2;
         AV144Postulacioneswwds_10_postulacionesproveedornombre2 = AV110PostulacionesProveedorNombre2;
         AV145Postulacioneswwds_11_postulacionesproveedorid2 = AV25PostulacionesProveedorId2;
         AV146Postulacioneswwds_12_serviciosnombre2 = AV26ServiciosNombre2;
         AV147Postulacioneswwds_13_dynamicfiltersenabled3 = AV27DynamicFiltersEnabled3;
         AV148Postulacioneswwds_14_dynamicfiltersselector3 = AV28DynamicFiltersSelector3;
         AV149Postulacioneswwds_15_dynamicfiltersoperator3 = AV29DynamicFiltersOperator3;
         AV150Postulacioneswwds_16_postulacionesproveedornombre3 = AV111PostulacionesProveedorNombre3;
         AV151Postulacioneswwds_17_postulacionesproveedorid3 = AV30PostulacionesProveedorId3;
         AV152Postulacioneswwds_18_serviciosnombre3 = AV31ServiciosNombre3;
         AV153Postulacioneswwds_19_tfpostulacionesid = AV38TFPostulacionesId;
         AV154Postulacioneswwds_20_tfpostulacionesid_to = AV39TFPostulacionesId_To;
         AV155Postulacioneswwds_21_tfserviciosid = AV40TFServiciosId;
         AV156Postulacioneswwds_22_tfserviciosid_to = AV41TFServiciosId_To;
         AV157Postulacioneswwds_23_tfserviciosnombre = AV42TFServiciosNombre;
         AV158Postulacioneswwds_24_tfserviciosnombre_sel = AV43TFServiciosNombre_Sel;
         AV159Postulacioneswwds_25_tfpostulacionesproveedorid = AV44TFPostulacionesProveedorId;
         AV160Postulacioneswwds_26_tfpostulacionesproveedorid_to = AV45TFPostulacionesProveedorId_To;
         AV161Postulacioneswwds_27_tfpostulacionesproveedornombre = AV102TFPostulacionesProveedorNombre;
         AV162Postulacioneswwds_28_tfpostulacionesproveedornombre_sel = AV103TFPostulacionesProveedorNombre_Sel;
         AV163Postulacioneswwds_29_tfpostulacionesprecio = AV46TFPostulacionesPrecio;
         AV164Postulacioneswwds_30_tfpostulacionesprecio_to = AV47TFPostulacionesPrecio_To;
         AV165Postulacioneswwds_31_tfpostulacionesmultimediaserial = AV104TFPostulacionesMultimediaSerial;
         AV166Postulacioneswwds_32_tfpostulacionesmultimediaserial_to = AV105TFPostulacionesMultimediaSerial_To;
         AV167Postulacioneswwds_33_tfpostulacionessolicitudesid = AV112TFPostulacionesSolicitudesId;
         AV168Postulacioneswwds_34_tfpostulacionessolicitudesid_to = AV113TFPostulacionesSolicitudesId_To;
         AV169Postulacioneswwds_35_tfpostulacionesdescripcion = AV48TFPostulacionesDescripcion;
         AV170Postulacioneswwds_36_tfpostulacionesdescripcion_sel = AV49TFPostulacionesDescripcion_Sel;
         AV171Postulacioneswwds_37_tfpostulacionesreqsuministros_sel = AV50TFPostulacionesReqSuministros_Sel;
         AV172Postulacioneswwds_38_tfpostulacionessuministrosdescripcion = AV51TFPostulacionesSuministrosDescripcion;
         AV173Postulacioneswwds_39_tfpostulacionessuministrosdescripcion_sel = AV52TFPostulacionesSuministrosDescripcion_Sel;
         AV174Postulacioneswwds_40_tfpostulacionesfechatrabajo = AV53TFPostulacionesFechaTrabajo;
         AV175Postulacioneswwds_41_tfpostulacionesfechatrabajo_to = AV54TFPostulacionesFechaTrabajo_To;
         AV176Postulacioneswwds_42_tfpostulacionesfechacierre = AV55TFPostulacionesFechaCierre;
         AV177Postulacioneswwds_43_tfpostulacionesfechacierre_to = AV56TFPostulacionesFechaCierre_To;
         AV178Postulacioneswwds_44_tfpostulacioneshoracierre = AV57TFPostulacionesHoraCierre;
         AV179Postulacioneswwds_45_tfpostulacioneshoracierre_sel = AV58TFPostulacionesHoraCierre_Sel;
         AV180Postulacioneswwds_46_tfpostulacionestipofecha = AV59TFPostulacionesTipoFecha;
         AV181Postulacioneswwds_47_tfpostulacionestipofecha_sel = AV129TFPostulacionesTipoFecha_Sel;
         AV182Postulacioneswwds_48_tfpostulacionesrgohoraservicio = AV61TFPostulacionesRgoHoraservicio;
         AV183Postulacioneswwds_49_tfpostulacionesrgohoraservicio_sel = AV62TFPostulacionesRgoHoraservicio_Sel;
         AV184Postulacioneswwds_50_tfpostulacionesapellidonombre = AV63TFPostulacionesApellidoNombre;
         AV185Postulacioneswwds_51_tfpostulacionesapellidonombre_sel = AV64TFPostulacionesApellidoNombre_Sel;
         AV186Postulacioneswwds_52_tfpostulacionesmail = AV65TFPostulacionesMail;
         AV187Postulacioneswwds_53_tfpostulacionesmail_sel = AV66TFPostulacionesMail_Sel;
         AV188Postulacioneswwds_54_tfpostulacionestelefono = AV67TFPostulacionesTelefono;
         AV189Postulacioneswwds_55_tfpostulacionestelefono_sel = AV68TFPostulacionesTelefono_Sel;
         AV190Postulacioneswwds_56_tfpostulacionesfechaalta = AV69TFPostulacionesFechaAlta;
         AV191Postulacioneswwds_57_tfpostulacionesfechaalta_to = AV70TFPostulacionesFechaAlta_To;
         AV192Postulacioneswwds_58_tfpostulacionesestado_sels = AV74TFPostulacionesEstado_Sels;
         AV193Postulacioneswwds_59_tfpostulacionessecuserid = AV75TFPostulacionesSecUserId;
         AV194Postulacioneswwds_60_tfpostulacionessecuserid_to = AV76TFPostulacionesSecUserId_To;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A424PostulacionesEstado ,
                                              AV192Postulacioneswwds_58_tfpostulacionesestado_sels ,
                                              AV136Postulacioneswwds_2_dynamicfiltersselector1 ,
                                              AV137Postulacioneswwds_3_dynamicfiltersoperator1 ,
                                              AV138Postulacioneswwds_4_postulacionesproveedornombre1 ,
                                              AV139Postulacioneswwds_5_postulacionesproveedorid1 ,
                                              AV140Postulacioneswwds_6_serviciosnombre1 ,
                                              AV141Postulacioneswwds_7_dynamicfiltersenabled2 ,
                                              AV142Postulacioneswwds_8_dynamicfiltersselector2 ,
                                              AV143Postulacioneswwds_9_dynamicfiltersoperator2 ,
                                              AV144Postulacioneswwds_10_postulacionesproveedornombre2 ,
                                              AV145Postulacioneswwds_11_postulacionesproveedorid2 ,
                                              AV146Postulacioneswwds_12_serviciosnombre2 ,
                                              AV147Postulacioneswwds_13_dynamicfiltersenabled3 ,
                                              AV148Postulacioneswwds_14_dynamicfiltersselector3 ,
                                              AV149Postulacioneswwds_15_dynamicfiltersoperator3 ,
                                              AV150Postulacioneswwds_16_postulacionesproveedornombre3 ,
                                              AV151Postulacioneswwds_17_postulacionesproveedorid3 ,
                                              AV152Postulacioneswwds_18_serviciosnombre3 ,
                                              AV153Postulacioneswwds_19_tfpostulacionesid ,
                                              AV154Postulacioneswwds_20_tfpostulacionesid_to ,
                                              AV155Postulacioneswwds_21_tfserviciosid ,
                                              AV156Postulacioneswwds_22_tfserviciosid_to ,
                                              AV158Postulacioneswwds_24_tfserviciosnombre_sel ,
                                              AV157Postulacioneswwds_23_tfserviciosnombre ,
                                              AV159Postulacioneswwds_25_tfpostulacionesproveedorid ,
                                              AV160Postulacioneswwds_26_tfpostulacionesproveedorid_to ,
                                              AV162Postulacioneswwds_28_tfpostulacionesproveedornombre_sel ,
                                              AV161Postulacioneswwds_27_tfpostulacionesproveedornombre ,
                                              AV163Postulacioneswwds_29_tfpostulacionesprecio ,
                                              AV164Postulacioneswwds_30_tfpostulacionesprecio_to ,
                                              AV165Postulacioneswwds_31_tfpostulacionesmultimediaserial ,
                                              AV166Postulacioneswwds_32_tfpostulacionesmultimediaserial_to ,
                                              AV170Postulacioneswwds_36_tfpostulacionesdescripcion_sel ,
                                              AV169Postulacioneswwds_35_tfpostulacionesdescripcion ,
                                              AV171Postulacioneswwds_37_tfpostulacionesreqsuministros_sel ,
                                              AV173Postulacioneswwds_39_tfpostulacionessuministrosdescripcion_sel ,
                                              AV172Postulacioneswwds_38_tfpostulacionessuministrosdescripcion ,
                                              AV174Postulacioneswwds_40_tfpostulacionesfechatrabajo ,
                                              AV175Postulacioneswwds_41_tfpostulacionesfechatrabajo_to ,
                                              AV176Postulacioneswwds_42_tfpostulacionesfechacierre ,
                                              AV177Postulacioneswwds_43_tfpostulacionesfechacierre_to ,
                                              AV179Postulacioneswwds_45_tfpostulacioneshoracierre_sel ,
                                              AV178Postulacioneswwds_44_tfpostulacioneshoracierre ,
                                              AV181Postulacioneswwds_47_tfpostulacionestipofecha_sel ,
                                              AV180Postulacioneswwds_46_tfpostulacionestipofecha ,
                                              AV183Postulacioneswwds_49_tfpostulacionesrgohoraservicio_sel ,
                                              AV182Postulacioneswwds_48_tfpostulacionesrgohoraservicio ,
                                              AV185Postulacioneswwds_51_tfpostulacionesapellidonombre_sel ,
                                              AV184Postulacioneswwds_50_tfpostulacionesapellidonombre ,
                                              AV187Postulacioneswwds_53_tfpostulacionesmail_sel ,
                                              AV186Postulacioneswwds_52_tfpostulacionesmail ,
                                              AV189Postulacioneswwds_55_tfpostulacionestelefono_sel ,
                                              AV188Postulacioneswwds_54_tfpostulacionestelefono ,
                                              AV190Postulacioneswwds_56_tfpostulacionesfechaalta ,
                                              AV191Postulacioneswwds_57_tfpostulacionesfechaalta_to ,
                                              AV192Postulacioneswwds_58_tfpostulacionesestado_sels.Count ,
                                              AV193Postulacioneswwds_59_tfpostulacionessecuserid ,
                                              AV194Postulacioneswwds_60_tfpostulacionessecuserid_to ,
                                              A969PostulacionesProveedorNombre ,
                                              A945PostulacionesProveedorId ,
                                              A943ServiciosNombre ,
                                              A422PostulacionesId ,
                                              A942ServiciosId ,
                                              A946PostulacionesPrecio ,
                                              A961PostulacionesMultimediaSerial ,
                                              A936PostulacionesDescripcion ,
                                              A937PostulacionesReqSuministros ,
                                              A938PostulacionesSuministrosDescri ,
                                              A947PostulacionesFechaTrabajo ,
                                              A939PostulacionesFechaCierre ,
                                              A940PostulacionesHoraCierre ,
                                              A941PostulacionesTipoFecha ,
                                              A949PostulacionesRgoHoraservicio ,
                                              A950PostulacionesApellidoNombre ,
                                              A951PostulacionesMail ,
                                              A952PostulacionesTelefono ,
                                              A425PostulacionesFechaAlta ,
                                              A948PostulacionesSecUserId ,
                                              AV11OrderedBy ,
                                              AV12OrderedDsc ,
                                              AV135Postulacioneswwds_1_filterfulltext ,
                                              A970PostulacionesSolicitudesId ,
                                              AV167Postulacioneswwds_33_tfpostulacionessolicitudesid ,
                                              AV168Postulacioneswwds_34_tfpostulacionessolicitudesid_to } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG,
                                              TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.DATE,
                                              TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.INT, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG,
                                              TypeConstants.BOOLEAN, TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.LONG,
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.LONG, TypeConstants.LONG
                                              }
         });
         lV138Postulacioneswwds_4_postulacionesproveedornombre1 = StringUtil.PadR( StringUtil.RTrim( AV138Postulacioneswwds_4_postulacionesproveedornombre1), 80, "%");
         lV138Postulacioneswwds_4_postulacionesproveedornombre1 = StringUtil.PadR( StringUtil.RTrim( AV138Postulacioneswwds_4_postulacionesproveedornombre1), 80, "%");
         lV140Postulacioneswwds_6_serviciosnombre1 = StringUtil.PadR( StringUtil.RTrim( AV140Postulacioneswwds_6_serviciosnombre1), 80, "%");
         lV140Postulacioneswwds_6_serviciosnombre1 = StringUtil.PadR( StringUtil.RTrim( AV140Postulacioneswwds_6_serviciosnombre1), 80, "%");
         lV144Postulacioneswwds_10_postulacionesproveedornombre2 = StringUtil.PadR( StringUtil.RTrim( AV144Postulacioneswwds_10_postulacionesproveedornombre2), 80, "%");
         lV144Postulacioneswwds_10_postulacionesproveedornombre2 = StringUtil.PadR( StringUtil.RTrim( AV144Postulacioneswwds_10_postulacionesproveedornombre2), 80, "%");
         lV146Postulacioneswwds_12_serviciosnombre2 = StringUtil.PadR( StringUtil.RTrim( AV146Postulacioneswwds_12_serviciosnombre2), 80, "%");
         lV146Postulacioneswwds_12_serviciosnombre2 = StringUtil.PadR( StringUtil.RTrim( AV146Postulacioneswwds_12_serviciosnombre2), 80, "%");
         lV150Postulacioneswwds_16_postulacionesproveedornombre3 = StringUtil.PadR( StringUtil.RTrim( AV150Postulacioneswwds_16_postulacionesproveedornombre3), 80, "%");
         lV150Postulacioneswwds_16_postulacionesproveedornombre3 = StringUtil.PadR( StringUtil.RTrim( AV150Postulacioneswwds_16_postulacionesproveedornombre3), 80, "%");
         lV152Postulacioneswwds_18_serviciosnombre3 = StringUtil.PadR( StringUtil.RTrim( AV152Postulacioneswwds_18_serviciosnombre3), 80, "%");
         lV152Postulacioneswwds_18_serviciosnombre3 = StringUtil.PadR( StringUtil.RTrim( AV152Postulacioneswwds_18_serviciosnombre3), 80, "%");
         lV157Postulacioneswwds_23_tfserviciosnombre = StringUtil.PadR( StringUtil.RTrim( AV157Postulacioneswwds_23_tfserviciosnombre), 80, "%");
         lV161Postulacioneswwds_27_tfpostulacionesproveedornombre = StringUtil.PadR( StringUtil.RTrim( AV161Postulacioneswwds_27_tfpostulacionesproveedornombre), 80, "%");
         lV169Postulacioneswwds_35_tfpostulacionesdescripcion = StringUtil.PadR( StringUtil.RTrim( AV169Postulacioneswwds_35_tfpostulacionesdescripcion), 2000, "%");
         lV172Postulacioneswwds_38_tfpostulacionessuministrosdescripcion = StringUtil.PadR( StringUtil.RTrim( AV172Postulacioneswwds_38_tfpostulacionessuministrosdescripcion), 250, "%");
         lV178Postulacioneswwds_44_tfpostulacioneshoracierre = StringUtil.Concat( StringUtil.RTrim( AV178Postulacioneswwds_44_tfpostulacioneshoracierre), "%", "");
         lV180Postulacioneswwds_46_tfpostulacionestipofecha = StringUtil.Concat( StringUtil.RTrim( AV180Postulacioneswwds_46_tfpostulacionestipofecha), "%", "");
         lV182Postulacioneswwds_48_tfpostulacionesrgohoraservicio = StringUtil.PadR( StringUtil.RTrim( AV182Postulacioneswwds_48_tfpostulacionesrgohoraservicio), 5, "%");
         lV184Postulacioneswwds_50_tfpostulacionesapellidonombre = StringUtil.PadR( StringUtil.RTrim( AV184Postulacioneswwds_50_tfpostulacionesapellidonombre), 80, "%");
         lV186Postulacioneswwds_52_tfpostulacionesmail = StringUtil.Concat( StringUtil.RTrim( AV186Postulacioneswwds_52_tfpostulacionesmail), "%", "");
         lV188Postulacioneswwds_54_tfpostulacionestelefono = StringUtil.PadR( StringUtil.RTrim( AV188Postulacioneswwds_54_tfpostulacionestelefono), 20, "%");
         /* Using cursor P00LC3 */
         pr_default.execute(0, new Object[] {n422PostulacionesId, A422PostulacionesId, AV167Postulacioneswwds_33_tfpostulacionessolicitudesid, AV167Postulacioneswwds_33_tfpostulacionessolicitudesid, AV168Postulacioneswwds_34_tfpostulacionessolicitudesid_to, AV168Postulacioneswwds_34_tfpostulacionessolicitudesid_to, lV138Postulacioneswwds_4_postulacionesproveedornombre1, lV138Postulacioneswwds_4_postulacionesproveedornombre1, AV139Postulacioneswwds_5_postulacionesproveedorid1, AV139Postulacioneswwds_5_postulacionesproveedorid1, AV139Postulacioneswwds_5_postulacionesproveedorid1, lV140Postulacioneswwds_6_serviciosnombre1, lV140Postulacioneswwds_6_serviciosnombre1, lV144Postulacioneswwds_10_postulacionesproveedornombre2, lV144Postulacioneswwds_10_postulacionesproveedornombre2, AV145Postulacioneswwds_11_postulacionesproveedorid2, AV145Postulacioneswwds_11_postulacionesproveedorid2, AV145Postulacioneswwds_11_postulacionesproveedorid2, lV146Postulacioneswwds_12_serviciosnombre2, lV146Postulacioneswwds_12_serviciosnombre2, lV150Postulacioneswwds_16_postulacionesproveedornombre3, lV150Postulacioneswwds_16_postulacionesproveedornombre3, AV151Postulacioneswwds_17_postulacionesproveedorid3, AV151Postulacioneswwds_17_postulacionesproveedorid3, AV151Postulacioneswwds_17_postulacionesproveedorid3, lV152Postulacioneswwds_18_serviciosnombre3, lV152Postulacioneswwds_18_serviciosnombre3, AV153Postulacioneswwds_19_tfpostulacionesid, AV154Postulacioneswwds_20_tfpostulacionesid_to, AV155Postulacioneswwds_21_tfserviciosid, AV156Postulacioneswwds_22_tfserviciosid_to, lV157Postulacioneswwds_23_tfserviciosnombre, AV158Postulacioneswwds_24_tfserviciosnombre_sel, AV159Postulacioneswwds_25_tfpostulacionesproveedorid, AV160Postulacioneswwds_26_tfpostulacionesproveedorid_to, lV161Postulacioneswwds_27_tfpostulacionesproveedornombre, AV162Postulacioneswwds_28_tfpostulacionesproveedornombre_sel, AV163Postulacioneswwds_29_tfpostulacionesprecio, AV164Postulacioneswwds_30_tfpostulacionesprecio_to, AV165Postulacioneswwds_31_tfpostulacionesmultimediaserial, AV166Postulacioneswwds_32_tfpostulacionesmultimediaserial_to, lV169Postulacioneswwds_35_tfpostulacionesdescripcion, AV170Postulacioneswwds_36_tfpostulacionesdescripcion_sel, lV172Postulacioneswwds_38_tfpostulacionessuministrosdescripcion, AV173Postulacioneswwds_39_tfpostulacionessuministrosdescripcion_sel, AV174Postulacioneswwds_40_tfpostulacionesfechatrabajo, AV175Postulacioneswwds_41_tfpostulacionesfechatrabajo_to, AV176Postulacioneswwds_42_tfpostulacionesfechacierre, AV177Postulacioneswwds_43_tfpostulacionesfechacierre_to, lV178Postulacioneswwds_44_tfpostulacioneshoracierre, AV179Postulacioneswwds_45_tfpostulacioneshoracierre_sel, lV180Postulacioneswwds_46_tfpostulacionestipofecha, AV181Postulacioneswwds_47_tfpostulacionestipofecha_sel, lV182Postulacioneswwds_48_tfpostulacionesrgohoraservicio, AV183Postulacioneswwds_49_tfpostulacionesrgohoraservicio_sel, lV184Postulacioneswwds_50_tfpostulacionesapellidonombre, AV185Postulacioneswwds_51_tfpostulacionesapellidonombre_sel, lV186Postulacioneswwds_52_tfpostulacionesmail, AV187Postulacioneswwds_53_tfpostulacionesmail_sel, lV188Postulacioneswwds_54_tfpostulacionestelefono, AV189Postulacioneswwds_55_tfpostulacionestelefono_sel, AV190Postulacioneswwds_56_tfpostulacionesfechaalta, AV191Postulacioneswwds_57_tfpostulacionesfechaalta_to, AV193Postulacioneswwds_59_tfpostulacionessecuserid, AV194Postulacioneswwds_60_tfpostulacionessecuserid_to});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A948PostulacionesSecUserId = P00LC3_A948PostulacionesSecUserId[0];
            A425PostulacionesFechaAlta = P00LC3_A425PostulacionesFechaAlta[0];
            A952PostulacionesTelefono = P00LC3_A952PostulacionesTelefono[0];
            A951PostulacionesMail = P00LC3_A951PostulacionesMail[0];
            A950PostulacionesApellidoNombre = P00LC3_A950PostulacionesApellidoNombre[0];
            A949PostulacionesRgoHoraservicio = P00LC3_A949PostulacionesRgoHoraservicio[0];
            A941PostulacionesTipoFecha = P00LC3_A941PostulacionesTipoFecha[0];
            A940PostulacionesHoraCierre = P00LC3_A940PostulacionesHoraCierre[0];
            A939PostulacionesFechaCierre = P00LC3_A939PostulacionesFechaCierre[0];
            A947PostulacionesFechaTrabajo = P00LC3_A947PostulacionesFechaTrabajo[0];
            A938PostulacionesSuministrosDescri = P00LC3_A938PostulacionesSuministrosDescri[0];
            A937PostulacionesReqSuministros = P00LC3_A937PostulacionesReqSuministros[0];
            A936PostulacionesDescripcion = P00LC3_A936PostulacionesDescripcion[0];
            A961PostulacionesMultimediaSerial = P00LC3_A961PostulacionesMultimediaSerial[0];
            A946PostulacionesPrecio = P00LC3_A946PostulacionesPrecio[0];
            A969PostulacionesProveedorNombre = P00LC3_A969PostulacionesProveedorNombre[0];
            A943ServiciosNombre = P00LC3_A943ServiciosNombre[0];
            A942ServiciosId = P00LC3_A942ServiciosId[0];
            n942ServiciosId = P00LC3_n942ServiciosId[0];
            A422PostulacionesId = P00LC3_A422PostulacionesId[0];
            n422PostulacionesId = P00LC3_n422PostulacionesId[0];
            A945PostulacionesProveedorId = P00LC3_A945PostulacionesProveedorId[0];
            A424PostulacionesEstado = P00LC3_A424PostulacionesEstado[0];
            A970PostulacionesSolicitudesId = P00LC3_A970PostulacionesSolicitudesId[0];
            n970PostulacionesSolicitudesId = P00LC3_n970PostulacionesSolicitudesId[0];
            A943ServiciosNombre = P00LC3_A943ServiciosNombre[0];
            A969PostulacionesProveedorNombre = P00LC3_A969PostulacionesProveedorNombre[0];
            A970PostulacionesSolicitudesId = P00LC3_A970PostulacionesSolicitudesId[0];
            n970PostulacionesSolicitudesId = P00LC3_n970PostulacionesSolicitudesId[0];
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV135Postulacioneswwds_1_filterfulltext)) || ( ( StringUtil.Like( StringUtil.Str( (decimal)(A422PostulacionesId), 18, 0) , StringUtil.PadR( "%" + AV135Postulacioneswwds_1_filterfulltext , 254 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Str( (decimal)(A942ServiciosId), 18, 0) , StringUtil.PadR( "%" + AV135Postulacioneswwds_1_filterfulltext , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A943ServiciosNombre) , StringUtil.PadR( "%" + StringUtil.Upper( AV135Postulacioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Str( (decimal)(A945PostulacionesProveedorId), 18, 0) , StringUtil.PadR( "%" + AV135Postulacioneswwds_1_filterfulltext , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A969PostulacionesProveedorNombre) , StringUtil.PadR( "%" + StringUtil.Upper( AV135Postulacioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Str( A946PostulacionesPrecio, 18, 2) , StringUtil.PadR( "%" + AV135Postulacioneswwds_1_filterfulltext , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Str( (decimal)(A961PostulacionesMultimediaSerial), 4, 0) , StringUtil.PadR( "%" + AV135Postulacioneswwds_1_filterfulltext , 254 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Str( (decimal)(A970PostulacionesSolicitudesId), 18, 0) , StringUtil.PadR( "%" + AV135Postulacioneswwds_1_filterfulltext , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A936PostulacionesDescripcion) , StringUtil.PadR( "%" + StringUtil.Upper( AV135Postulacioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Upper( A938PostulacionesSuministrosDescri) , StringUtil.PadR( "%" + StringUtil.Upper( AV135Postulacioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A940PostulacionesHoraCierre) , StringUtil.PadR( "%" + StringUtil.Upper( AV135Postulacioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Upper( A941PostulacionesTipoFecha) , StringUtil.PadR( "%" + StringUtil.Upper( AV135Postulacioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A949PostulacionesRgoHoraservicio) , StringUtil.PadR( "%" + StringUtil.Upper( AV135Postulacioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Upper( A950PostulacionesApellidoNombre) , StringUtil.PadR( "%" + StringUtil.Upper( AV135Postulacioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A951PostulacionesMail) , StringUtil.PadR( "%" + StringUtil.Upper( AV135Postulacioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Upper( A952PostulacionesTelefono) , StringUtil.PadR( "%" + StringUtil.Upper( AV135Postulacioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( context.GetMessage( "habilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV135Postulacioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A424PostulacionesEstado, "HAB") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "deshabilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV135Postulacioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A424PostulacionesEstado, "DES") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "ganador", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV135Postulacioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) &&
            ( StringUtil.StrCmp(A424PostulacionesEstado, "GAN") == 0 ) ) || ( StringUtil.Like( StringUtil.Str( (decimal)(A948PostulacionesSecUserId), 18, 0) , StringUtil.PadR( "%" + AV135Postulacioneswwds_1_filterfulltext , 254 , "%"),  ' ' ) ) )
            )
            {
               AV33PostulacionesEstadoDescription = "";
               if ( StringUtil.StrCmp(StringUtil.Trim( A424PostulacionesEstado), "HAB") == 0 )
               {
                  AV33PostulacionesEstadoDescription = context.GetMessage( "Habilitado", "");
               }
               else if ( StringUtil.StrCmp(StringUtil.Trim( A424PostulacionesEstado), "DES") == 0 )
               {
                  AV33PostulacionesEstadoDescription = context.GetMessage( "Deshabilitado", "");
               }
               else if ( StringUtil.StrCmp(StringUtil.Trim( A424PostulacionesEstado), "GAN") == 0 )
               {
                  AV33PostulacionesEstadoDescription = context.GetMessage( "Ganador", "");
               }
               /* Execute user subroutine: 'BEFOREPRINTLINE' */
               S144 ();
               if ( returnInSub )
               {
                  pr_default.close(0);
                  returnInSub = true;
                  if (true) return;
               }
               HLC0( false, 66) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(A422PostulacionesId), "ZZZZZZZZZZZZZZZZZ9")), 30, Gx_line+10, 60, Gx_line+55, 2+16, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(A942ServiciosId), "ZZZZZZZZZZZZZZZZZ9")), 64, Gx_line+10, 94, Gx_line+55, 2+16, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A943ServiciosNombre, "")), 98, Gx_line+10, 128, Gx_line+55, 0+16, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(A945PostulacionesProveedorId), "ZZZZZZZZZZZZZZZZZ9")), 132, Gx_line+10, 162, Gx_line+55, 2+16, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A969PostulacionesProveedorNombre, "")), 166, Gx_line+10, 196, Gx_line+55, 0+16, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( A946PostulacionesPrecio, "ZZZZZZ,ZZZ,ZZZ,ZZ9.99")), 200, Gx_line+10, 230, Gx_line+55, 2+16, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(A961PostulacionesMultimediaSerial), "ZZZ9")), 234, Gx_line+10, 264, Gx_line+55, 2+16, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(A970PostulacionesSolicitudesId), "ZZZZZZZZZZZZZZZZZ9")), 268, Gx_line+10, 298, Gx_line+55, 2+16, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A936PostulacionesDescripcion, "")), 302, Gx_line+10, 332, Gx_line+55, 0+16, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.BoolToStr( A937PostulacionesReqSuministros), 336, Gx_line+10, 366, Gx_line+55, 0+16, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A938PostulacionesSuministrosDescri, "")), 370, Gx_line+10, 400, Gx_line+55, 0+16, 0, 0, 0) ;
               getPrinter().GxDrawText(context.localUtil.Format( A947PostulacionesFechaTrabajo, "99/99/99"), 404, Gx_line+10, 434, Gx_line+55, 0+16, 0, 0, 0) ;
               getPrinter().GxDrawText(context.localUtil.Format( A939PostulacionesFechaCierre, "99/99/99"), 438, Gx_line+10, 468, Gx_line+55, 0+16, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A940PostulacionesHoraCierre, "")), 472, Gx_line+10, 503, Gx_line+55, 0+16, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A941PostulacionesTipoFecha, "")), 507, Gx_line+10, 538, Gx_line+55, 0+16, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A949PostulacionesRgoHoraservicio, "")), 542, Gx_line+10, 573, Gx_line+55, 0+16, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A950PostulacionesApellidoNombre, "")), 577, Gx_line+10, 609, Gx_line+55, 0+16, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A951PostulacionesMail, "")), 613, Gx_line+10, 645, Gx_line+55, 0+16, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A952PostulacionesTelefono, "")), 649, Gx_line+10, 681, Gx_line+55, 0+16, 0, 0, 0) ;
               getPrinter().GxDrawText(context.localUtil.Format( A425PostulacionesFechaAlta, "99/99/99 99:99"), 685, Gx_line+10, 716, Gx_line+55, 0+16, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV33PostulacionesEstadoDescription, "")), 720, Gx_line+10, 752, Gx_line+55, 0+16, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(A948PostulacionesSecUserId), "ZZZZZZZZZZZZZZZZZ9")), 756, Gx_line+10, 787, Gx_line+55, 2+16, 0, 0, 0) ;
               getPrinter().GxDrawLine(28, Gx_line+65, 789, Gx_line+65, 1, 220, 220, 220, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+66);
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
         if ( StringUtil.StrCmp(AV34Session.Get("PostulacionesWWGridState"), "") == 0 )
         {
            AV36GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "PostulacionesWWGridState"), null, "", "");
         }
         else
         {
            AV36GridState.FromXml(AV34Session.Get("PostulacionesWWGridState"), null, "", "");
         }
         AV11OrderedBy = AV36GridState.gxTpr_Orderedby;
         AV12OrderedDsc = AV36GridState.gxTpr_Ordereddsc;
         AV195GXV2 = 1;
         while ( AV195GXV2 <= AV36GridState.gxTpr_Filtervalues.Count )
         {
            AV37GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV36GridState.gxTpr_Filtervalues.Item(AV195GXV2));
            if ( StringUtil.StrCmp(AV37GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV13FilterFullText = AV37GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV37GridStateFilterValue.gxTpr_Name, "TFPOSTULACIONESID") == 0 )
            {
               AV38TFPostulacionesId = (long)(Math.Round(NumberUtil.Val( AV37GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV39TFPostulacionesId_To = (long)(Math.Round(NumberUtil.Val( AV37GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV37GridStateFilterValue.gxTpr_Name, "TFSERVICIOSID") == 0 )
            {
               AV40TFServiciosId = (long)(Math.Round(NumberUtil.Val( AV37GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV41TFServiciosId_To = (long)(Math.Round(NumberUtil.Val( AV37GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV37GridStateFilterValue.gxTpr_Name, "TFSERVICIOSNOMBRE") == 0 )
            {
               AV42TFServiciosNombre = AV37GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV37GridStateFilterValue.gxTpr_Name, "TFSERVICIOSNOMBRE_SEL") == 0 )
            {
               AV43TFServiciosNombre_Sel = AV37GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV37GridStateFilterValue.gxTpr_Name, "TFPOSTULACIONESPROVEEDORID") == 0 )
            {
               AV44TFPostulacionesProveedorId = (long)(Math.Round(NumberUtil.Val( AV37GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV45TFPostulacionesProveedorId_To = (long)(Math.Round(NumberUtil.Val( AV37GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV37GridStateFilterValue.gxTpr_Name, "TFPOSTULACIONESPROVEEDORNOMBRE") == 0 )
            {
               AV102TFPostulacionesProveedorNombre = AV37GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV37GridStateFilterValue.gxTpr_Name, "TFPOSTULACIONESPROVEEDORNOMBRE_SEL") == 0 )
            {
               AV103TFPostulacionesProveedorNombre_Sel = AV37GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV37GridStateFilterValue.gxTpr_Name, "TFPOSTULACIONESPRECIO") == 0 )
            {
               AV46TFPostulacionesPrecio = NumberUtil.Val( AV37GridStateFilterValue.gxTpr_Value, ".");
               AV47TFPostulacionesPrecio_To = NumberUtil.Val( AV37GridStateFilterValue.gxTpr_Valueto, ".");
            }
            else if ( StringUtil.StrCmp(AV37GridStateFilterValue.gxTpr_Name, "TFPOSTULACIONESMULTIMEDIASERIAL") == 0 )
            {
               AV104TFPostulacionesMultimediaSerial = (short)(Math.Round(NumberUtil.Val( AV37GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV105TFPostulacionesMultimediaSerial_To = (short)(Math.Round(NumberUtil.Val( AV37GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV37GridStateFilterValue.gxTpr_Name, "TFPOSTULACIONESSOLICITUDESID") == 0 )
            {
               AV112TFPostulacionesSolicitudesId = (long)(Math.Round(NumberUtil.Val( AV37GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV113TFPostulacionesSolicitudesId_To = (long)(Math.Round(NumberUtil.Val( AV37GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV37GridStateFilterValue.gxTpr_Name, "TFPOSTULACIONESDESCRIPCION") == 0 )
            {
               AV48TFPostulacionesDescripcion = AV37GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV37GridStateFilterValue.gxTpr_Name, "TFPOSTULACIONESDESCRIPCION_SEL") == 0 )
            {
               AV49TFPostulacionesDescripcion_Sel = AV37GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV37GridStateFilterValue.gxTpr_Name, "TFPOSTULACIONESREQSUMINISTROS_SEL") == 0 )
            {
               AV50TFPostulacionesReqSuministros_Sel = (short)(Math.Round(NumberUtil.Val( AV37GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV37GridStateFilterValue.gxTpr_Name, "TFPOSTULACIONESSUMINISTROSDESCRIPCION") == 0 )
            {
               AV51TFPostulacionesSuministrosDescripcion = AV37GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV37GridStateFilterValue.gxTpr_Name, "TFPOSTULACIONESSUMINISTROSDESCRIPCION_SEL") == 0 )
            {
               AV52TFPostulacionesSuministrosDescripcion_Sel = AV37GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV37GridStateFilterValue.gxTpr_Name, "TFPOSTULACIONESFECHATRABAJO") == 0 )
            {
               AV53TFPostulacionesFechaTrabajo = context.localUtil.CToD( AV37GridStateFilterValue.gxTpr_Value, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               AV54TFPostulacionesFechaTrabajo_To = context.localUtil.CToD( AV37GridStateFilterValue.gxTpr_Valueto, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
            }
            else if ( StringUtil.StrCmp(AV37GridStateFilterValue.gxTpr_Name, "TFPOSTULACIONESFECHACIERRE") == 0 )
            {
               AV55TFPostulacionesFechaCierre = context.localUtil.CToD( AV37GridStateFilterValue.gxTpr_Value, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               AV56TFPostulacionesFechaCierre_To = context.localUtil.CToD( AV37GridStateFilterValue.gxTpr_Valueto, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
            }
            else if ( StringUtil.StrCmp(AV37GridStateFilterValue.gxTpr_Name, "TFPOSTULACIONESHORACIERRE") == 0 )
            {
               AV57TFPostulacionesHoraCierre = AV37GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV37GridStateFilterValue.gxTpr_Name, "TFPOSTULACIONESHORACIERRE_SEL") == 0 )
            {
               AV58TFPostulacionesHoraCierre_Sel = AV37GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV37GridStateFilterValue.gxTpr_Name, "TFPOSTULACIONESTIPOFECHA") == 0 )
            {
               AV59TFPostulacionesTipoFecha = AV37GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV37GridStateFilterValue.gxTpr_Name, "TFPOSTULACIONESTIPOFECHA_SEL") == 0 )
            {
               AV129TFPostulacionesTipoFecha_Sel = AV37GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV37GridStateFilterValue.gxTpr_Name, "TFPOSTULACIONESRGOHORASERVICIO") == 0 )
            {
               AV61TFPostulacionesRgoHoraservicio = AV37GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV37GridStateFilterValue.gxTpr_Name, "TFPOSTULACIONESRGOHORASERVICIO_SEL") == 0 )
            {
               AV62TFPostulacionesRgoHoraservicio_Sel = AV37GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV37GridStateFilterValue.gxTpr_Name, "TFPOSTULACIONESAPELLIDONOMBRE") == 0 )
            {
               AV63TFPostulacionesApellidoNombre = AV37GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV37GridStateFilterValue.gxTpr_Name, "TFPOSTULACIONESAPELLIDONOMBRE_SEL") == 0 )
            {
               AV64TFPostulacionesApellidoNombre_Sel = AV37GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV37GridStateFilterValue.gxTpr_Name, "TFPOSTULACIONESMAIL") == 0 )
            {
               AV65TFPostulacionesMail = AV37GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV37GridStateFilterValue.gxTpr_Name, "TFPOSTULACIONESMAIL_SEL") == 0 )
            {
               AV66TFPostulacionesMail_Sel = AV37GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV37GridStateFilterValue.gxTpr_Name, "TFPOSTULACIONESTELEFONO") == 0 )
            {
               AV67TFPostulacionesTelefono = AV37GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV37GridStateFilterValue.gxTpr_Name, "TFPOSTULACIONESTELEFONO_SEL") == 0 )
            {
               AV68TFPostulacionesTelefono_Sel = AV37GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV37GridStateFilterValue.gxTpr_Name, "TFPOSTULACIONESFECHAALTA") == 0 )
            {
               AV69TFPostulacionesFechaAlta = context.localUtil.CToT( AV37GridStateFilterValue.gxTpr_Value, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               AV70TFPostulacionesFechaAlta_To = context.localUtil.CToT( AV37GridStateFilterValue.gxTpr_Valueto, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
            }
            else if ( StringUtil.StrCmp(AV37GridStateFilterValue.gxTpr_Name, "TFPOSTULACIONESESTADO_SEL") == 0 )
            {
               AV71TFPostulacionesEstado_SelsJson = AV37GridStateFilterValue.gxTpr_Value;
               AV74TFPostulacionesEstado_Sels.FromJSonString(AV71TFPostulacionesEstado_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV37GridStateFilterValue.gxTpr_Name, "TFPOSTULACIONESSECUSERID") == 0 )
            {
               AV75TFPostulacionesSecUserId = (long)(Math.Round(NumberUtil.Val( AV37GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV76TFPostulacionesSecUserId_To = (long)(Math.Round(NumberUtil.Val( AV37GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            AV195GXV2 = (int)(AV195GXV2+1);
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

      protected void HLC0( bool bFoot ,
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
                  AV98PageInfo = context.GetMessage( "Page: ", "") + StringUtil.Trim( StringUtil.Str( (decimal)(Gx_page), 6, 0));
                  AV95DateInfo = context.GetMessage( "Date: ", "") + context.localUtil.Format( Gx_date, "99/99/99");
                  getPrinter().GxDrawRect(0, Gx_line+5, 819, Gx_line+40, 1, 0, 0, 0, 1, 8, 160, 134, 1, 1, 1, 1, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV98PageInfo, "")), 30, Gx_line+15, 409, Gx_line+30, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV95DateInfo, "")), 409, Gx_line+15, 789, Gx_line+30, 2, 0, 0, 0) ;
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
               AV93AppName = context.GetMessage( "DVelop Software Solutions", "");
               AV99Phone = "+1 550 8923";
               AV97Mail = "info@mail.com";
               AV101Website = "http://www.web.com";
               AV90AddressLine1 = "French Boulevard 2859";
               AV91AddressLine2 = "Downtown";
               AV92AddressLine3 = "Paris, France";
               getPrinter().GxDrawRect(0, Gx_line+0, 819, Gx_line+108, 1, 0, 0, 0, 1, 8, 160, 134, 1, 1, 1, 1, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV93AppName, "")), 30, Gx_line+30, 283, Gx_line+45, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 20, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV100Title, "")), 30, Gx_line+45, 283, Gx_line+78, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV99Phone, "")), 283, Gx_line+30, 536, Gx_line+46, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV97Mail, "")), 283, Gx_line+46, 536, Gx_line+62, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV101Website, "")), 283, Gx_line+62, 536, Gx_line+78, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV90AddressLine1, "")), 536, Gx_line+30, 789, Gx_line+46, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV91AddressLine2, "")), 536, Gx_line+46, 789, Gx_line+62, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV92AddressLine3, "")), 536, Gx_line+62, 789, Gx_line+78, 2, 0, 0, 0) ;
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
         AV130Pgmname = "";
         GXEncryptionTmp = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV100Title = "";
         AV13FilterFullText = "";
         AV36GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV32GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV14DynamicFiltersSelector1 = "";
         AV107PostulacionesProveedorNombre1 = "";
         AV108FilterPostulacionesProveedorNombreDescription = "";
         AV109PostulacionesProveedorNombre = "";
         AV17FilterPostulacionesProveedorIdDescription = "";
         AV19ServiciosNombre1 = "";
         AV20FilterServiciosNombreDescription = "";
         AV21ServiciosNombre = "";
         AV23DynamicFiltersSelector2 = "";
         AV110PostulacionesProveedorNombre2 = "";
         AV26ServiciosNombre2 = "";
         AV28DynamicFiltersSelector3 = "";
         AV111PostulacionesProveedorNombre3 = "";
         AV31ServiciosNombre3 = "";
         AV77TFPostulacionesId_To_Description = "";
         AV78TFServiciosId_To_Description = "";
         AV43TFServiciosNombre_Sel = "";
         AV42TFServiciosNombre = "";
         AV79TFPostulacionesProveedorId_To_Description = "";
         AV103TFPostulacionesProveedorNombre_Sel = "";
         AV102TFPostulacionesProveedorNombre = "";
         AV80TFPostulacionesPrecio_To_Description = "";
         AV106TFPostulacionesMultimediaSerial_To_Description = "";
         AV114TFPostulacionesSolicitudesId_To_Description = "";
         AV49TFPostulacionesDescripcion_Sel = "";
         AV48TFPostulacionesDescripcion = "";
         AV81FilterTFPostulacionesReqSuministros_SelValueDescription = "";
         AV52TFPostulacionesSuministrosDescripcion_Sel = "";
         AV51TFPostulacionesSuministrosDescripcion = "";
         AV53TFPostulacionesFechaTrabajo = DateTime.MinValue;
         AV54TFPostulacionesFechaTrabajo_To = DateTime.MinValue;
         AV82TFPostulacionesFechaTrabajo_To_Description = "";
         AV55TFPostulacionesFechaCierre = DateTime.MinValue;
         AV56TFPostulacionesFechaCierre_To = DateTime.MinValue;
         AV83TFPostulacionesFechaCierre_To_Description = "";
         AV58TFPostulacionesHoraCierre_Sel = "";
         AV57TFPostulacionesHoraCierre = "";
         AV129TFPostulacionesTipoFecha_Sel = "";
         AV59TFPostulacionesTipoFecha = "";
         AV62TFPostulacionesRgoHoraservicio_Sel = "";
         AV61TFPostulacionesRgoHoraservicio = "";
         AV64TFPostulacionesApellidoNombre_Sel = "";
         AV63TFPostulacionesApellidoNombre = "";
         AV66TFPostulacionesMail_Sel = "";
         AV65TFPostulacionesMail = "";
         AV68TFPostulacionesTelefono_Sel = "";
         AV67TFPostulacionesTelefono = "";
         AV69TFPostulacionesFechaAlta = (DateTime)(DateTime.MinValue);
         AV70TFPostulacionesFechaAlta_To = (DateTime)(DateTime.MinValue);
         AV85TFPostulacionesFechaAlta_To_Description = "";
         AV74TFPostulacionesEstado_Sels = new GxSimpleCollection<string>();
         AV71TFPostulacionesEstado_SelsJson = "";
         AV73TFPostulacionesEstado_Sel = "";
         AV72TFPostulacionesEstado_SelDscs = "";
         AV86FilterTFPostulacionesEstado_SelValueDescription = "";
         AV87TFPostulacionesSecUserId_To_Description = "";
         AV135Postulacioneswwds_1_filterfulltext = "";
         AV136Postulacioneswwds_2_dynamicfiltersselector1 = "";
         AV138Postulacioneswwds_4_postulacionesproveedornombre1 = "";
         AV140Postulacioneswwds_6_serviciosnombre1 = "";
         AV142Postulacioneswwds_8_dynamicfiltersselector2 = "";
         AV144Postulacioneswwds_10_postulacionesproveedornombre2 = "";
         AV146Postulacioneswwds_12_serviciosnombre2 = "";
         AV148Postulacioneswwds_14_dynamicfiltersselector3 = "";
         AV150Postulacioneswwds_16_postulacionesproveedornombre3 = "";
         AV152Postulacioneswwds_18_serviciosnombre3 = "";
         AV157Postulacioneswwds_23_tfserviciosnombre = "";
         AV158Postulacioneswwds_24_tfserviciosnombre_sel = "";
         AV161Postulacioneswwds_27_tfpostulacionesproveedornombre = "";
         AV162Postulacioneswwds_28_tfpostulacionesproveedornombre_sel = "";
         AV169Postulacioneswwds_35_tfpostulacionesdescripcion = "";
         AV170Postulacioneswwds_36_tfpostulacionesdescripcion_sel = "";
         AV172Postulacioneswwds_38_tfpostulacionessuministrosdescripcion = "";
         AV173Postulacioneswwds_39_tfpostulacionessuministrosdescripcion_sel = "";
         AV174Postulacioneswwds_40_tfpostulacionesfechatrabajo = DateTime.MinValue;
         AV175Postulacioneswwds_41_tfpostulacionesfechatrabajo_to = DateTime.MinValue;
         AV176Postulacioneswwds_42_tfpostulacionesfechacierre = DateTime.MinValue;
         AV177Postulacioneswwds_43_tfpostulacionesfechacierre_to = DateTime.MinValue;
         AV178Postulacioneswwds_44_tfpostulacioneshoracierre = "";
         AV179Postulacioneswwds_45_tfpostulacioneshoracierre_sel = "";
         AV180Postulacioneswwds_46_tfpostulacionestipofecha = "";
         AV181Postulacioneswwds_47_tfpostulacionestipofecha_sel = "";
         AV182Postulacioneswwds_48_tfpostulacionesrgohoraservicio = "";
         AV183Postulacioneswwds_49_tfpostulacionesrgohoraservicio_sel = "";
         AV184Postulacioneswwds_50_tfpostulacionesapellidonombre = "";
         AV185Postulacioneswwds_51_tfpostulacionesapellidonombre_sel = "";
         AV186Postulacioneswwds_52_tfpostulacionesmail = "";
         AV187Postulacioneswwds_53_tfpostulacionesmail_sel = "";
         AV188Postulacioneswwds_54_tfpostulacionestelefono = "";
         AV189Postulacioneswwds_55_tfpostulacionestelefono_sel = "";
         AV190Postulacioneswwds_56_tfpostulacionesfechaalta = (DateTime)(DateTime.MinValue);
         AV191Postulacioneswwds_57_tfpostulacionesfechaalta_to = (DateTime)(DateTime.MinValue);
         AV192Postulacioneswwds_58_tfpostulacionesestado_sels = new GxSimpleCollection<string>();
         lV135Postulacioneswwds_1_filterfulltext = "";
         lV138Postulacioneswwds_4_postulacionesproveedornombre1 = "";
         lV140Postulacioneswwds_6_serviciosnombre1 = "";
         lV144Postulacioneswwds_10_postulacionesproveedornombre2 = "";
         lV146Postulacioneswwds_12_serviciosnombre2 = "";
         lV150Postulacioneswwds_16_postulacionesproveedornombre3 = "";
         lV152Postulacioneswwds_18_serviciosnombre3 = "";
         lV157Postulacioneswwds_23_tfserviciosnombre = "";
         lV161Postulacioneswwds_27_tfpostulacionesproveedornombre = "";
         lV169Postulacioneswwds_35_tfpostulacionesdescripcion = "";
         lV172Postulacioneswwds_38_tfpostulacionessuministrosdescripcion = "";
         lV178Postulacioneswwds_44_tfpostulacioneshoracierre = "";
         lV180Postulacioneswwds_46_tfpostulacionestipofecha = "";
         lV182Postulacioneswwds_48_tfpostulacionesrgohoraservicio = "";
         lV184Postulacioneswwds_50_tfpostulacionesapellidonombre = "";
         lV186Postulacioneswwds_52_tfpostulacionesmail = "";
         lV188Postulacioneswwds_54_tfpostulacionestelefono = "";
         A424PostulacionesEstado = "";
         A969PostulacionesProveedorNombre = "";
         A943ServiciosNombre = "";
         A936PostulacionesDescripcion = "";
         A938PostulacionesSuministrosDescri = "";
         A947PostulacionesFechaTrabajo = DateTime.MinValue;
         A939PostulacionesFechaCierre = DateTime.MinValue;
         A940PostulacionesHoraCierre = "";
         A941PostulacionesTipoFecha = "";
         A949PostulacionesRgoHoraservicio = "";
         A950PostulacionesApellidoNombre = "";
         A951PostulacionesMail = "";
         A952PostulacionesTelefono = "";
         A425PostulacionesFechaAlta = (DateTime)(DateTime.MinValue);
         P00LC3_A948PostulacionesSecUserId = new long[1] ;
         P00LC3_A425PostulacionesFechaAlta = new DateTime[] {DateTime.MinValue} ;
         P00LC3_A952PostulacionesTelefono = new string[] {""} ;
         P00LC3_A951PostulacionesMail = new string[] {""} ;
         P00LC3_A950PostulacionesApellidoNombre = new string[] {""} ;
         P00LC3_A949PostulacionesRgoHoraservicio = new string[] {""} ;
         P00LC3_A941PostulacionesTipoFecha = new string[] {""} ;
         P00LC3_A940PostulacionesHoraCierre = new string[] {""} ;
         P00LC3_A939PostulacionesFechaCierre = new DateTime[] {DateTime.MinValue} ;
         P00LC3_A947PostulacionesFechaTrabajo = new DateTime[] {DateTime.MinValue} ;
         P00LC3_A938PostulacionesSuministrosDescri = new string[] {""} ;
         P00LC3_A937PostulacionesReqSuministros = new bool[] {false} ;
         P00LC3_A936PostulacionesDescripcion = new string[] {""} ;
         P00LC3_A961PostulacionesMultimediaSerial = new short[1] ;
         P00LC3_A946PostulacionesPrecio = new decimal[1] ;
         P00LC3_A969PostulacionesProveedorNombre = new string[] {""} ;
         P00LC3_A943ServiciosNombre = new string[] {""} ;
         P00LC3_A942ServiciosId = new long[1] ;
         P00LC3_n942ServiciosId = new bool[] {false} ;
         P00LC3_A422PostulacionesId = new long[1] ;
         P00LC3_n422PostulacionesId = new bool[] {false} ;
         P00LC3_A945PostulacionesProveedorId = new long[1] ;
         P00LC3_A424PostulacionesEstado = new string[] {""} ;
         P00LC3_A970PostulacionesSolicitudesId = new long[1] ;
         P00LC3_n970PostulacionesSolicitudesId = new bool[] {false} ;
         AV33PostulacionesEstadoDescription = "";
         AV34Session = context.GetSession();
         AV37GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV98PageInfo = "";
         AV95DateInfo = "";
         Gx_date = DateTime.MinValue;
         AV93AppName = "";
         AV99Phone = "";
         AV97Mail = "";
         AV101Website = "";
         AV90AddressLine1 = "";
         AV91AddressLine2 = "";
         AV92AddressLine3 = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.postulacioneswwexportreport__default(),
            new Object[][] {
                new Object[] {
               P00LC3_A948PostulacionesSecUserId, P00LC3_A425PostulacionesFechaAlta, P00LC3_A952PostulacionesTelefono, P00LC3_A951PostulacionesMail, P00LC3_A950PostulacionesApellidoNombre, P00LC3_A949PostulacionesRgoHoraservicio, P00LC3_A941PostulacionesTipoFecha, P00LC3_A940PostulacionesHoraCierre, P00LC3_A939PostulacionesFechaCierre, P00LC3_A947PostulacionesFechaTrabajo,
               P00LC3_A938PostulacionesSuministrosDescri, P00LC3_A937PostulacionesReqSuministros, P00LC3_A936PostulacionesDescripcion, P00LC3_A961PostulacionesMultimediaSerial, P00LC3_A946PostulacionesPrecio, P00LC3_A969PostulacionesProveedorNombre, P00LC3_A943ServiciosNombre, P00LC3_A942ServiciosId, P00LC3_n942ServiciosId, P00LC3_A422PostulacionesId,
               P00LC3_A945PostulacionesProveedorId, P00LC3_A424PostulacionesEstado, P00LC3_A970PostulacionesSolicitudesId, P00LC3_n970PostulacionesSolicitudesId
               }
            }
         );
         Gx_date = DateTimeUtil.Today( context);
         AV130Pgmname = "PostulacionesWWExportReport";
         /* GeneXus formulas. */
         Gx_line = 0;
         Gx_date = DateTimeUtil.Today( context);
         AV130Pgmname = "PostulacionesWWExportReport";
      }

      private short nGotPars ;
      private short GxWebError ;
      private short AV15DynamicFiltersOperator1 ;
      private short AV24DynamicFiltersOperator2 ;
      private short AV29DynamicFiltersOperator3 ;
      private short AV104TFPostulacionesMultimediaSerial ;
      private short AV105TFPostulacionesMultimediaSerial_To ;
      private short AV50TFPostulacionesReqSuministros_Sel ;
      private short AV137Postulacioneswwds_3_dynamicfiltersoperator1 ;
      private short AV143Postulacioneswwds_9_dynamicfiltersoperator2 ;
      private short AV149Postulacioneswwds_15_dynamicfiltersoperator3 ;
      private short AV165Postulacioneswwds_31_tfpostulacionesmultimediaserial ;
      private short AV166Postulacioneswwds_32_tfpostulacionesmultimediaserial_to ;
      private short AV171Postulacioneswwds_37_tfpostulacionesreqsuministros_sel ;
      private short A961PostulacionesMultimediaSerial ;
      private short AV11OrderedBy ;
      private int M_top ;
      private int M_bot ;
      private int Line ;
      private int ToSkip ;
      private int PrtOffset ;
      private int Gx_OldLine ;
      private int AV133GXV1 ;
      private int AV192Postulacioneswwds_58_tfpostulacionesestado_sels_Count ;
      private int AV195GXV2 ;
      private long AV16PostulacionesProveedorId1 ;
      private long AV18PostulacionesProveedorId ;
      private long AV25PostulacionesProveedorId2 ;
      private long AV30PostulacionesProveedorId3 ;
      private long AV38TFPostulacionesId ;
      private long AV39TFPostulacionesId_To ;
      private long AV40TFServiciosId ;
      private long AV41TFServiciosId_To ;
      private long AV44TFPostulacionesProveedorId ;
      private long AV45TFPostulacionesProveedorId_To ;
      private long AV112TFPostulacionesSolicitudesId ;
      private long AV113TFPostulacionesSolicitudesId_To ;
      private long AV89i ;
      private long AV75TFPostulacionesSecUserId ;
      private long AV76TFPostulacionesSecUserId_To ;
      private long AV139Postulacioneswwds_5_postulacionesproveedorid1 ;
      private long AV145Postulacioneswwds_11_postulacionesproveedorid2 ;
      private long AV151Postulacioneswwds_17_postulacionesproveedorid3 ;
      private long AV153Postulacioneswwds_19_tfpostulacionesid ;
      private long AV154Postulacioneswwds_20_tfpostulacionesid_to ;
      private long AV155Postulacioneswwds_21_tfserviciosid ;
      private long AV156Postulacioneswwds_22_tfserviciosid_to ;
      private long AV159Postulacioneswwds_25_tfpostulacionesproveedorid ;
      private long AV160Postulacioneswwds_26_tfpostulacionesproveedorid_to ;
      private long AV167Postulacioneswwds_33_tfpostulacionessolicitudesid ;
      private long AV168Postulacioneswwds_34_tfpostulacionessolicitudesid_to ;
      private long AV193Postulacioneswwds_59_tfpostulacionessecuserid ;
      private long AV194Postulacioneswwds_60_tfpostulacionessecuserid_to ;
      private long A945PostulacionesProveedorId ;
      private long A422PostulacionesId ;
      private long A942ServiciosId ;
      private long A948PostulacionesSecUserId ;
      private long A970PostulacionesSolicitudesId ;
      private decimal AV46TFPostulacionesPrecio ;
      private decimal AV47TFPostulacionesPrecio_To ;
      private decimal AV163Postulacioneswwds_29_tfpostulacionesprecio ;
      private decimal AV164Postulacioneswwds_30_tfpostulacionesprecio_to ;
      private decimal A946PostulacionesPrecio ;
      private string GXKey ;
      private string gxfirstwebparm ;
      private string AV130Pgmname ;
      private string GXEncryptionTmp ;
      private string AV107PostulacionesProveedorNombre1 ;
      private string AV109PostulacionesProveedorNombre ;
      private string AV19ServiciosNombre1 ;
      private string AV21ServiciosNombre ;
      private string AV110PostulacionesProveedorNombre2 ;
      private string AV26ServiciosNombre2 ;
      private string AV111PostulacionesProveedorNombre3 ;
      private string AV31ServiciosNombre3 ;
      private string AV43TFServiciosNombre_Sel ;
      private string AV42TFServiciosNombre ;
      private string AV103TFPostulacionesProveedorNombre_Sel ;
      private string AV102TFPostulacionesProveedorNombre ;
      private string AV49TFPostulacionesDescripcion_Sel ;
      private string AV48TFPostulacionesDescripcion ;
      private string AV52TFPostulacionesSuministrosDescripcion_Sel ;
      private string AV51TFPostulacionesSuministrosDescripcion ;
      private string AV62TFPostulacionesRgoHoraservicio_Sel ;
      private string AV61TFPostulacionesRgoHoraservicio ;
      private string AV64TFPostulacionesApellidoNombre_Sel ;
      private string AV63TFPostulacionesApellidoNombre ;
      private string AV68TFPostulacionesTelefono_Sel ;
      private string AV67TFPostulacionesTelefono ;
      private string AV73TFPostulacionesEstado_Sel ;
      private string AV138Postulacioneswwds_4_postulacionesproveedornombre1 ;
      private string AV140Postulacioneswwds_6_serviciosnombre1 ;
      private string AV144Postulacioneswwds_10_postulacionesproveedornombre2 ;
      private string AV146Postulacioneswwds_12_serviciosnombre2 ;
      private string AV150Postulacioneswwds_16_postulacionesproveedornombre3 ;
      private string AV152Postulacioneswwds_18_serviciosnombre3 ;
      private string AV157Postulacioneswwds_23_tfserviciosnombre ;
      private string AV158Postulacioneswwds_24_tfserviciosnombre_sel ;
      private string AV161Postulacioneswwds_27_tfpostulacionesproveedornombre ;
      private string AV162Postulacioneswwds_28_tfpostulacionesproveedornombre_sel ;
      private string AV169Postulacioneswwds_35_tfpostulacionesdescripcion ;
      private string AV170Postulacioneswwds_36_tfpostulacionesdescripcion_sel ;
      private string AV172Postulacioneswwds_38_tfpostulacionessuministrosdescripcion ;
      private string AV173Postulacioneswwds_39_tfpostulacionessuministrosdescripcion_sel ;
      private string AV182Postulacioneswwds_48_tfpostulacionesrgohoraservicio ;
      private string AV183Postulacioneswwds_49_tfpostulacionesrgohoraservicio_sel ;
      private string AV184Postulacioneswwds_50_tfpostulacionesapellidonombre ;
      private string AV185Postulacioneswwds_51_tfpostulacionesapellidonombre_sel ;
      private string AV188Postulacioneswwds_54_tfpostulacionestelefono ;
      private string AV189Postulacioneswwds_55_tfpostulacionestelefono_sel ;
      private string lV138Postulacioneswwds_4_postulacionesproveedornombre1 ;
      private string lV140Postulacioneswwds_6_serviciosnombre1 ;
      private string lV144Postulacioneswwds_10_postulacionesproveedornombre2 ;
      private string lV146Postulacioneswwds_12_serviciosnombre2 ;
      private string lV150Postulacioneswwds_16_postulacionesproveedornombre3 ;
      private string lV152Postulacioneswwds_18_serviciosnombre3 ;
      private string lV157Postulacioneswwds_23_tfserviciosnombre ;
      private string lV161Postulacioneswwds_27_tfpostulacionesproveedornombre ;
      private string lV169Postulacioneswwds_35_tfpostulacionesdescripcion ;
      private string lV172Postulacioneswwds_38_tfpostulacionessuministrosdescripcion ;
      private string lV182Postulacioneswwds_48_tfpostulacionesrgohoraservicio ;
      private string lV184Postulacioneswwds_50_tfpostulacionesapellidonombre ;
      private string lV188Postulacioneswwds_54_tfpostulacionestelefono ;
      private string A424PostulacionesEstado ;
      private string A969PostulacionesProveedorNombre ;
      private string A943ServiciosNombre ;
      private string A936PostulacionesDescripcion ;
      private string A938PostulacionesSuministrosDescri ;
      private string A949PostulacionesRgoHoraservicio ;
      private string A950PostulacionesApellidoNombre ;
      private string A952PostulacionesTelefono ;
      private DateTime AV69TFPostulacionesFechaAlta ;
      private DateTime AV70TFPostulacionesFechaAlta_To ;
      private DateTime AV190Postulacioneswwds_56_tfpostulacionesfechaalta ;
      private DateTime AV191Postulacioneswwds_57_tfpostulacionesfechaalta_to ;
      private DateTime A425PostulacionesFechaAlta ;
      private DateTime AV53TFPostulacionesFechaTrabajo ;
      private DateTime AV54TFPostulacionesFechaTrabajo_To ;
      private DateTime AV55TFPostulacionesFechaCierre ;
      private DateTime AV56TFPostulacionesFechaCierre_To ;
      private DateTime AV174Postulacioneswwds_40_tfpostulacionesfechatrabajo ;
      private DateTime AV175Postulacioneswwds_41_tfpostulacionesfechatrabajo_to ;
      private DateTime AV176Postulacioneswwds_42_tfpostulacionesfechacierre ;
      private DateTime AV177Postulacioneswwds_43_tfpostulacionesfechacierre_to ;
      private DateTime A947PostulacionesFechaTrabajo ;
      private DateTime A939PostulacionesFechaCierre ;
      private DateTime Gx_date ;
      private bool entryPointCalled ;
      private bool AV8IsAuthorized ;
      private bool GXt_boolean1 ;
      private bool returnInSub ;
      private bool AV22DynamicFiltersEnabled2 ;
      private bool AV27DynamicFiltersEnabled3 ;
      private bool AV88TempBoolean ;
      private bool AV141Postulacioneswwds_7_dynamicfiltersenabled2 ;
      private bool AV147Postulacioneswwds_13_dynamicfiltersenabled3 ;
      private bool A937PostulacionesReqSuministros ;
      private bool AV12OrderedDsc ;
      private bool n422PostulacionesId ;
      private bool n942ServiciosId ;
      private bool n970PostulacionesSolicitudesId ;
      private string AV71TFPostulacionesEstado_SelsJson ;
      private string AV100Title ;
      private string AV13FilterFullText ;
      private string AV14DynamicFiltersSelector1 ;
      private string AV108FilterPostulacionesProveedorNombreDescription ;
      private string AV17FilterPostulacionesProveedorIdDescription ;
      private string AV20FilterServiciosNombreDescription ;
      private string AV23DynamicFiltersSelector2 ;
      private string AV28DynamicFiltersSelector3 ;
      private string AV77TFPostulacionesId_To_Description ;
      private string AV78TFServiciosId_To_Description ;
      private string AV79TFPostulacionesProveedorId_To_Description ;
      private string AV80TFPostulacionesPrecio_To_Description ;
      private string AV106TFPostulacionesMultimediaSerial_To_Description ;
      private string AV114TFPostulacionesSolicitudesId_To_Description ;
      private string AV81FilterTFPostulacionesReqSuministros_SelValueDescription ;
      private string AV82TFPostulacionesFechaTrabajo_To_Description ;
      private string AV83TFPostulacionesFechaCierre_To_Description ;
      private string AV58TFPostulacionesHoraCierre_Sel ;
      private string AV57TFPostulacionesHoraCierre ;
      private string AV129TFPostulacionesTipoFecha_Sel ;
      private string AV59TFPostulacionesTipoFecha ;
      private string AV66TFPostulacionesMail_Sel ;
      private string AV65TFPostulacionesMail ;
      private string AV85TFPostulacionesFechaAlta_To_Description ;
      private string AV72TFPostulacionesEstado_SelDscs ;
      private string AV86FilterTFPostulacionesEstado_SelValueDescription ;
      private string AV87TFPostulacionesSecUserId_To_Description ;
      private string AV135Postulacioneswwds_1_filterfulltext ;
      private string AV136Postulacioneswwds_2_dynamicfiltersselector1 ;
      private string AV142Postulacioneswwds_8_dynamicfiltersselector2 ;
      private string AV148Postulacioneswwds_14_dynamicfiltersselector3 ;
      private string AV178Postulacioneswwds_44_tfpostulacioneshoracierre ;
      private string AV179Postulacioneswwds_45_tfpostulacioneshoracierre_sel ;
      private string AV180Postulacioneswwds_46_tfpostulacionestipofecha ;
      private string AV181Postulacioneswwds_47_tfpostulacionestipofecha_sel ;
      private string AV186Postulacioneswwds_52_tfpostulacionesmail ;
      private string AV187Postulacioneswwds_53_tfpostulacionesmail_sel ;
      private string lV135Postulacioneswwds_1_filterfulltext ;
      private string lV178Postulacioneswwds_44_tfpostulacioneshoracierre ;
      private string lV180Postulacioneswwds_46_tfpostulacionestipofecha ;
      private string lV186Postulacioneswwds_52_tfpostulacionesmail ;
      private string A940PostulacionesHoraCierre ;
      private string A941PostulacionesTipoFecha ;
      private string A951PostulacionesMail ;
      private string AV33PostulacionesEstadoDescription ;
      private string AV98PageInfo ;
      private string AV95DateInfo ;
      private string AV93AppName ;
      private string AV99Phone ;
      private string AV97Mail ;
      private string AV101Website ;
      private string AV90AddressLine1 ;
      private string AV91AddressLine2 ;
      private string AV92AddressLine3 ;
      private IGxSession AV34Session ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV36GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV32GridStateDynamicFilter ;
      private GxSimpleCollection<string> AV74TFPostulacionesEstado_Sels ;
      private GxSimpleCollection<string> AV192Postulacioneswwds_58_tfpostulacionesestado_sels ;
      private IDataStoreProvider pr_default ;
      private long[] P00LC3_A948PostulacionesSecUserId ;
      private DateTime[] P00LC3_A425PostulacionesFechaAlta ;
      private string[] P00LC3_A952PostulacionesTelefono ;
      private string[] P00LC3_A951PostulacionesMail ;
      private string[] P00LC3_A950PostulacionesApellidoNombre ;
      private string[] P00LC3_A949PostulacionesRgoHoraservicio ;
      private string[] P00LC3_A941PostulacionesTipoFecha ;
      private string[] P00LC3_A940PostulacionesHoraCierre ;
      private DateTime[] P00LC3_A939PostulacionesFechaCierre ;
      private DateTime[] P00LC3_A947PostulacionesFechaTrabajo ;
      private string[] P00LC3_A938PostulacionesSuministrosDescri ;
      private bool[] P00LC3_A937PostulacionesReqSuministros ;
      private string[] P00LC3_A936PostulacionesDescripcion ;
      private short[] P00LC3_A961PostulacionesMultimediaSerial ;
      private decimal[] P00LC3_A946PostulacionesPrecio ;
      private string[] P00LC3_A969PostulacionesProveedorNombre ;
      private string[] P00LC3_A943ServiciosNombre ;
      private long[] P00LC3_A942ServiciosId ;
      private bool[] P00LC3_n942ServiciosId ;
      private long[] P00LC3_A422PostulacionesId ;
      private bool[] P00LC3_n422PostulacionesId ;
      private long[] P00LC3_A945PostulacionesProveedorId ;
      private string[] P00LC3_A424PostulacionesEstado ;
      private long[] P00LC3_A970PostulacionesSolicitudesId ;
      private bool[] P00LC3_n970PostulacionesSolicitudesId ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV37GridStateFilterValue ;
   }

   public class postulacioneswwexportreport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00LC3( IGxContext context ,
                                             string A424PostulacionesEstado ,
                                             GxSimpleCollection<string> AV192Postulacioneswwds_58_tfpostulacionesestado_sels ,
                                             string AV136Postulacioneswwds_2_dynamicfiltersselector1 ,
                                             short AV137Postulacioneswwds_3_dynamicfiltersoperator1 ,
                                             string AV138Postulacioneswwds_4_postulacionesproveedornombre1 ,
                                             long AV139Postulacioneswwds_5_postulacionesproveedorid1 ,
                                             string AV140Postulacioneswwds_6_serviciosnombre1 ,
                                             bool AV141Postulacioneswwds_7_dynamicfiltersenabled2 ,
                                             string AV142Postulacioneswwds_8_dynamicfiltersselector2 ,
                                             short AV143Postulacioneswwds_9_dynamicfiltersoperator2 ,
                                             string AV144Postulacioneswwds_10_postulacionesproveedornombre2 ,
                                             long AV145Postulacioneswwds_11_postulacionesproveedorid2 ,
                                             string AV146Postulacioneswwds_12_serviciosnombre2 ,
                                             bool AV147Postulacioneswwds_13_dynamicfiltersenabled3 ,
                                             string AV148Postulacioneswwds_14_dynamicfiltersselector3 ,
                                             short AV149Postulacioneswwds_15_dynamicfiltersoperator3 ,
                                             string AV150Postulacioneswwds_16_postulacionesproveedornombre3 ,
                                             long AV151Postulacioneswwds_17_postulacionesproveedorid3 ,
                                             string AV152Postulacioneswwds_18_serviciosnombre3 ,
                                             long AV153Postulacioneswwds_19_tfpostulacionesid ,
                                             long AV154Postulacioneswwds_20_tfpostulacionesid_to ,
                                             long AV155Postulacioneswwds_21_tfserviciosid ,
                                             long AV156Postulacioneswwds_22_tfserviciosid_to ,
                                             string AV158Postulacioneswwds_24_tfserviciosnombre_sel ,
                                             string AV157Postulacioneswwds_23_tfserviciosnombre ,
                                             long AV159Postulacioneswwds_25_tfpostulacionesproveedorid ,
                                             long AV160Postulacioneswwds_26_tfpostulacionesproveedorid_to ,
                                             string AV162Postulacioneswwds_28_tfpostulacionesproveedornombre_sel ,
                                             string AV161Postulacioneswwds_27_tfpostulacionesproveedornombre ,
                                             decimal AV163Postulacioneswwds_29_tfpostulacionesprecio ,
                                             decimal AV164Postulacioneswwds_30_tfpostulacionesprecio_to ,
                                             short AV165Postulacioneswwds_31_tfpostulacionesmultimediaserial ,
                                             short AV166Postulacioneswwds_32_tfpostulacionesmultimediaserial_to ,
                                             string AV170Postulacioneswwds_36_tfpostulacionesdescripcion_sel ,
                                             string AV169Postulacioneswwds_35_tfpostulacionesdescripcion ,
                                             short AV171Postulacioneswwds_37_tfpostulacionesreqsuministros_sel ,
                                             string AV173Postulacioneswwds_39_tfpostulacionessuministrosdescripcion_sel ,
                                             string AV172Postulacioneswwds_38_tfpostulacionessuministrosdescripcion ,
                                             DateTime AV174Postulacioneswwds_40_tfpostulacionesfechatrabajo ,
                                             DateTime AV175Postulacioneswwds_41_tfpostulacionesfechatrabajo_to ,
                                             DateTime AV176Postulacioneswwds_42_tfpostulacionesfechacierre ,
                                             DateTime AV177Postulacioneswwds_43_tfpostulacionesfechacierre_to ,
                                             string AV179Postulacioneswwds_45_tfpostulacioneshoracierre_sel ,
                                             string AV178Postulacioneswwds_44_tfpostulacioneshoracierre ,
                                             string AV181Postulacioneswwds_47_tfpostulacionestipofecha_sel ,
                                             string AV180Postulacioneswwds_46_tfpostulacionestipofecha ,
                                             string AV183Postulacioneswwds_49_tfpostulacionesrgohoraservicio_sel ,
                                             string AV182Postulacioneswwds_48_tfpostulacionesrgohoraservicio ,
                                             string AV185Postulacioneswwds_51_tfpostulacionesapellidonombre_sel ,
                                             string AV184Postulacioneswwds_50_tfpostulacionesapellidonombre ,
                                             string AV187Postulacioneswwds_53_tfpostulacionesmail_sel ,
                                             string AV186Postulacioneswwds_52_tfpostulacionesmail ,
                                             string AV189Postulacioneswwds_55_tfpostulacionestelefono_sel ,
                                             string AV188Postulacioneswwds_54_tfpostulacionestelefono ,
                                             DateTime AV190Postulacioneswwds_56_tfpostulacionesfechaalta ,
                                             DateTime AV191Postulacioneswwds_57_tfpostulacionesfechaalta_to ,
                                             int AV192Postulacioneswwds_58_tfpostulacionesestado_sels_Count ,
                                             long AV193Postulacioneswwds_59_tfpostulacionessecuserid ,
                                             long AV194Postulacioneswwds_60_tfpostulacionessecuserid_to ,
                                             string A969PostulacionesProveedorNombre ,
                                             long A945PostulacionesProveedorId ,
                                             string A943ServiciosNombre ,
                                             long A422PostulacionesId ,
                                             long A942ServiciosId ,
                                             decimal A946PostulacionesPrecio ,
                                             short A961PostulacionesMultimediaSerial ,
                                             string A936PostulacionesDescripcion ,
                                             bool A937PostulacionesReqSuministros ,
                                             string A938PostulacionesSuministrosDescri ,
                                             DateTime A947PostulacionesFechaTrabajo ,
                                             DateTime A939PostulacionesFechaCierre ,
                                             string A940PostulacionesHoraCierre ,
                                             string A941PostulacionesTipoFecha ,
                                             string A949PostulacionesRgoHoraservicio ,
                                             string A950PostulacionesApellidoNombre ,
                                             string A951PostulacionesMail ,
                                             string A952PostulacionesTelefono ,
                                             DateTime A425PostulacionesFechaAlta ,
                                             long A948PostulacionesSecUserId ,
                                             short AV11OrderedBy ,
                                             bool AV12OrderedDsc ,
                                             string AV135Postulacioneswwds_1_filterfulltext ,
                                             long A970PostulacionesSolicitudesId ,
                                             long AV167Postulacioneswwds_33_tfpostulacionessolicitudesid ,
                                             long AV168Postulacioneswwds_34_tfpostulacionessolicitudesid_to )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int2 = new short[64];
         Object[] GXv_Object3 = new Object[2];
         scmdbuf = "SELECT T1.[PostulacionesSecUserId], T1.[PostulacionesFechaAlta], T1.[PostulacionesTelefono], T1.[PostulacionesMail], T1.[PostulacionesApellidoNombre], T1.[PostulacionesRgoHoraservicio], T1.[PostulacionesTipoFecha], T1.[PostulacionesHoraCierre], T1.[PostulacionesFechaCierre], T1.[PostulacionesFechaTrabajo], T1.[PostulacionesSuministrosDescri], T1.[PostulacionesReqSuministros], T1.[PostulacionesDescripcion], T1.[PostulacionesMultimediaSerial], T1.[PostulacionesPrecio], T3.[ProveedorNombre] AS PostulacionesProveedorNombre, T2.[ServiciosNombre], T1.[ServiciosId], T1.[PostulacionesId], T1.[PostulacionesProveedorId] AS PostulacionesProveedorId, T1.[PostulacionesEstado], COALESCE( T4.[PostulacionesSolicitudesId], 0) AS PostulacionesSolicitudesId FROM (([Postulaciones] T1 LEFT JOIN [Servicios] T2 ON T2.[ServiciosId] = T1.[ServiciosId]) INNER JOIN [Proveedor] T3 ON T3.[ProveedorID] = T1.[PostulacionesProveedorId]),  (SELECT MIN([SolicitudesID]) AS PostulacionesSolicitudesId FROM [Solicitudes] WHERE [PostulacionesId] = @PostulacionesId ) T4";
         AddWhere(sWhereString, "((@AV167Postulacioneswwds_33_tfpostulacionessolicitudesid = convert(int, 0)) or ( COALESCE( T4.[PostulacionesSolicitudesId], 0) >= @AV167Postulacioneswwds_33_tfpostulacionessolicitudesid))");
         AddWhere(sWhereString, "((@AV168Postulacioneswwds_34_tfpostulacionessolicitudesid_to = convert(int, 0)) or ( COALESCE( T4.[PostulacionesSolicitudesId], 0) <= @AV168Postulacioneswwds_34_tfpostulacionessolicitudesid_to))");
         if ( ( StringUtil.StrCmp(AV136Postulacioneswwds_2_dynamicfiltersselector1, "POSTULACIONESPROVEEDORNOMBRE") == 0 ) && ( AV137Postulacioneswwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV138Postulacioneswwds_4_postulacionesproveedornombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T3.[ProveedorNombre]) like UPPER(@lV138Postulacioneswwds_4_postulacionesproveedornombre1))");
         }
         else
         {
            GXv_int2[5] = 1;
         }
         if ( ( StringUtil.StrCmp(AV136Postulacioneswwds_2_dynamicfiltersselector1, "POSTULACIONESPROVEEDORNOMBRE") == 0 ) && ( AV137Postulacioneswwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV138Postulacioneswwds_4_postulacionesproveedornombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T3.[ProveedorNombre]) like '%' + UPPER(@lV138Postulacioneswwds_4_postulacionesproveedornombre1))");
         }
         else
         {
            GXv_int2[6] = 1;
         }
         if ( ( StringUtil.StrCmp(AV136Postulacioneswwds_2_dynamicfiltersselector1, "POSTULACIONESPROVEEDORID") == 0 ) && ( AV137Postulacioneswwds_3_dynamicfiltersoperator1 == 0 ) && ( ! (0==AV139Postulacioneswwds_5_postulacionesproveedorid1) ) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesProveedorId] < @AV139Postulacioneswwds_5_postulacionesproveedorid1)");
         }
         else
         {
            GXv_int2[7] = 1;
         }
         if ( ( StringUtil.StrCmp(AV136Postulacioneswwds_2_dynamicfiltersselector1, "POSTULACIONESPROVEEDORID") == 0 ) && ( AV137Postulacioneswwds_3_dynamicfiltersoperator1 == 1 ) && ( ! (0==AV139Postulacioneswwds_5_postulacionesproveedorid1) ) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesProveedorId] = @AV139Postulacioneswwds_5_postulacionesproveedorid1)");
         }
         else
         {
            GXv_int2[8] = 1;
         }
         if ( ( StringUtil.StrCmp(AV136Postulacioneswwds_2_dynamicfiltersselector1, "POSTULACIONESPROVEEDORID") == 0 ) && ( AV137Postulacioneswwds_3_dynamicfiltersoperator1 == 2 ) && ( ! (0==AV139Postulacioneswwds_5_postulacionesproveedorid1) ) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesProveedorId] > @AV139Postulacioneswwds_5_postulacionesproveedorid1)");
         }
         else
         {
            GXv_int2[9] = 1;
         }
         if ( ( StringUtil.StrCmp(AV136Postulacioneswwds_2_dynamicfiltersselector1, "SERVICIOSNOMBRE") == 0 ) && ( AV137Postulacioneswwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV140Postulacioneswwds_6_serviciosnombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ServiciosNombre]) like UPPER(@lV140Postulacioneswwds_6_serviciosnombre1))");
         }
         else
         {
            GXv_int2[10] = 1;
         }
         if ( ( StringUtil.StrCmp(AV136Postulacioneswwds_2_dynamicfiltersselector1, "SERVICIOSNOMBRE") == 0 ) && ( AV137Postulacioneswwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV140Postulacioneswwds_6_serviciosnombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ServiciosNombre]) like '%' + UPPER(@lV140Postulacioneswwds_6_serviciosnombre1))");
         }
         else
         {
            GXv_int2[11] = 1;
         }
         if ( AV141Postulacioneswwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV142Postulacioneswwds_8_dynamicfiltersselector2, "POSTULACIONESPROVEEDORNOMBRE") == 0 ) && ( AV143Postulacioneswwds_9_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV144Postulacioneswwds_10_postulacionesproveedornombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T3.[ProveedorNombre]) like UPPER(@lV144Postulacioneswwds_10_postulacionesproveedornombre2))");
         }
         else
         {
            GXv_int2[12] = 1;
         }
         if ( AV141Postulacioneswwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV142Postulacioneswwds_8_dynamicfiltersselector2, "POSTULACIONESPROVEEDORNOMBRE") == 0 ) && ( AV143Postulacioneswwds_9_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV144Postulacioneswwds_10_postulacionesproveedornombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T3.[ProveedorNombre]) like '%' + UPPER(@lV144Postulacioneswwds_10_postulacionesproveedornombre2))");
         }
         else
         {
            GXv_int2[13] = 1;
         }
         if ( AV141Postulacioneswwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV142Postulacioneswwds_8_dynamicfiltersselector2, "POSTULACIONESPROVEEDORID") == 0 ) && ( AV143Postulacioneswwds_9_dynamicfiltersoperator2 == 0 ) && ( ! (0==AV145Postulacioneswwds_11_postulacionesproveedorid2) ) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesProveedorId] < @AV145Postulacioneswwds_11_postulacionesproveedorid2)");
         }
         else
         {
            GXv_int2[14] = 1;
         }
         if ( AV141Postulacioneswwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV142Postulacioneswwds_8_dynamicfiltersselector2, "POSTULACIONESPROVEEDORID") == 0 ) && ( AV143Postulacioneswwds_9_dynamicfiltersoperator2 == 1 ) && ( ! (0==AV145Postulacioneswwds_11_postulacionesproveedorid2) ) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesProveedorId] = @AV145Postulacioneswwds_11_postulacionesproveedorid2)");
         }
         else
         {
            GXv_int2[15] = 1;
         }
         if ( AV141Postulacioneswwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV142Postulacioneswwds_8_dynamicfiltersselector2, "POSTULACIONESPROVEEDORID") == 0 ) && ( AV143Postulacioneswwds_9_dynamicfiltersoperator2 == 2 ) && ( ! (0==AV145Postulacioneswwds_11_postulacionesproveedorid2) ) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesProveedorId] > @AV145Postulacioneswwds_11_postulacionesproveedorid2)");
         }
         else
         {
            GXv_int2[16] = 1;
         }
         if ( AV141Postulacioneswwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV142Postulacioneswwds_8_dynamicfiltersselector2, "SERVICIOSNOMBRE") == 0 ) && ( AV143Postulacioneswwds_9_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV146Postulacioneswwds_12_serviciosnombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ServiciosNombre]) like UPPER(@lV146Postulacioneswwds_12_serviciosnombre2))");
         }
         else
         {
            GXv_int2[17] = 1;
         }
         if ( AV141Postulacioneswwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV142Postulacioneswwds_8_dynamicfiltersselector2, "SERVICIOSNOMBRE") == 0 ) && ( AV143Postulacioneswwds_9_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV146Postulacioneswwds_12_serviciosnombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ServiciosNombre]) like '%' + UPPER(@lV146Postulacioneswwds_12_serviciosnombre2))");
         }
         else
         {
            GXv_int2[18] = 1;
         }
         if ( AV147Postulacioneswwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV148Postulacioneswwds_14_dynamicfiltersselector3, "POSTULACIONESPROVEEDORNOMBRE") == 0 ) && ( AV149Postulacioneswwds_15_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV150Postulacioneswwds_16_postulacionesproveedornombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T3.[ProveedorNombre]) like UPPER(@lV150Postulacioneswwds_16_postulacionesproveedornombre3))");
         }
         else
         {
            GXv_int2[19] = 1;
         }
         if ( AV147Postulacioneswwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV148Postulacioneswwds_14_dynamicfiltersselector3, "POSTULACIONESPROVEEDORNOMBRE") == 0 ) && ( AV149Postulacioneswwds_15_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV150Postulacioneswwds_16_postulacionesproveedornombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T3.[ProveedorNombre]) like '%' + UPPER(@lV150Postulacioneswwds_16_postulacionesproveedornombre3))");
         }
         else
         {
            GXv_int2[20] = 1;
         }
         if ( AV147Postulacioneswwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV148Postulacioneswwds_14_dynamicfiltersselector3, "POSTULACIONESPROVEEDORID") == 0 ) && ( AV149Postulacioneswwds_15_dynamicfiltersoperator3 == 0 ) && ( ! (0==AV151Postulacioneswwds_17_postulacionesproveedorid3) ) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesProveedorId] < @AV151Postulacioneswwds_17_postulacionesproveedorid3)");
         }
         else
         {
            GXv_int2[21] = 1;
         }
         if ( AV147Postulacioneswwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV148Postulacioneswwds_14_dynamicfiltersselector3, "POSTULACIONESPROVEEDORID") == 0 ) && ( AV149Postulacioneswwds_15_dynamicfiltersoperator3 == 1 ) && ( ! (0==AV151Postulacioneswwds_17_postulacionesproveedorid3) ) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesProveedorId] = @AV151Postulacioneswwds_17_postulacionesproveedorid3)");
         }
         else
         {
            GXv_int2[22] = 1;
         }
         if ( AV147Postulacioneswwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV148Postulacioneswwds_14_dynamicfiltersselector3, "POSTULACIONESPROVEEDORID") == 0 ) && ( AV149Postulacioneswwds_15_dynamicfiltersoperator3 == 2 ) && ( ! (0==AV151Postulacioneswwds_17_postulacionesproveedorid3) ) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesProveedorId] > @AV151Postulacioneswwds_17_postulacionesproveedorid3)");
         }
         else
         {
            GXv_int2[23] = 1;
         }
         if ( AV147Postulacioneswwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV148Postulacioneswwds_14_dynamicfiltersselector3, "SERVICIOSNOMBRE") == 0 ) && ( AV149Postulacioneswwds_15_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV152Postulacioneswwds_18_serviciosnombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ServiciosNombre]) like UPPER(@lV152Postulacioneswwds_18_serviciosnombre3))");
         }
         else
         {
            GXv_int2[24] = 1;
         }
         if ( AV147Postulacioneswwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV148Postulacioneswwds_14_dynamicfiltersselector3, "SERVICIOSNOMBRE") == 0 ) && ( AV149Postulacioneswwds_15_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV152Postulacioneswwds_18_serviciosnombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ServiciosNombre]) like '%' + UPPER(@lV152Postulacioneswwds_18_serviciosnombre3))");
         }
         else
         {
            GXv_int2[25] = 1;
         }
         if ( ! (0==AV153Postulacioneswwds_19_tfpostulacionesid) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesId] >= @AV153Postulacioneswwds_19_tfpostulacionesid)");
         }
         else
         {
            GXv_int2[26] = 1;
         }
         if ( ! (0==AV154Postulacioneswwds_20_tfpostulacionesid_to) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesId] <= @AV154Postulacioneswwds_20_tfpostulacionesid_to)");
         }
         else
         {
            GXv_int2[27] = 1;
         }
         if ( ! (0==AV155Postulacioneswwds_21_tfserviciosid) )
         {
            AddWhere(sWhereString, "(T1.[ServiciosId] >= @AV155Postulacioneswwds_21_tfserviciosid)");
         }
         else
         {
            GXv_int2[28] = 1;
         }
         if ( ! (0==AV156Postulacioneswwds_22_tfserviciosid_to) )
         {
            AddWhere(sWhereString, "(T1.[ServiciosId] <= @AV156Postulacioneswwds_22_tfserviciosid_to)");
         }
         else
         {
            GXv_int2[29] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV158Postulacioneswwds_24_tfserviciosnombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV157Postulacioneswwds_23_tfserviciosnombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ServiciosNombre]) like UPPER(@lV157Postulacioneswwds_23_tfserviciosnombre))");
         }
         else
         {
            GXv_int2[30] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV158Postulacioneswwds_24_tfserviciosnombre_sel)) && ! ( StringUtil.StrCmp(AV158Postulacioneswwds_24_tfserviciosnombre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.[ServiciosNombre] = @AV158Postulacioneswwds_24_tfserviciosnombre_sel)");
         }
         else
         {
            GXv_int2[31] = 1;
         }
         if ( StringUtil.StrCmp(AV158Postulacioneswwds_24_tfserviciosnombre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T2.[ServiciosNombre] IS NULL or (T2.[ServiciosNombre] = ''))");
         }
         if ( ! (0==AV159Postulacioneswwds_25_tfpostulacionesproveedorid) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesProveedorId] >= @AV159Postulacioneswwds_25_tfpostulacionesproveedorid)");
         }
         else
         {
            GXv_int2[32] = 1;
         }
         if ( ! (0==AV160Postulacioneswwds_26_tfpostulacionesproveedorid_to) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesProveedorId] <= @AV160Postulacioneswwds_26_tfpostulacionesproveedorid_to)");
         }
         else
         {
            GXv_int2[33] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV162Postulacioneswwds_28_tfpostulacionesproveedornombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV161Postulacioneswwds_27_tfpostulacionesproveedornombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T3.[ProveedorNombre]) like UPPER(@lV161Postulacioneswwds_27_tfpostulacionesproveedornombre))");
         }
         else
         {
            GXv_int2[34] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV162Postulacioneswwds_28_tfpostulacionesproveedornombre_sel)) && ! ( StringUtil.StrCmp(AV162Postulacioneswwds_28_tfpostulacionesproveedornombre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T3.[ProveedorNombre] = @AV162Postulacioneswwds_28_tfpostulacionesproveedornombre_sel)");
         }
         else
         {
            GXv_int2[35] = 1;
         }
         if ( StringUtil.StrCmp(AV162Postulacioneswwds_28_tfpostulacionesproveedornombre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T3.[ProveedorNombre] = ''))");
         }
         if ( ! (Convert.ToDecimal(0)==AV163Postulacioneswwds_29_tfpostulacionesprecio) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesPrecio] >= @AV163Postulacioneswwds_29_tfpostulacionesprecio)");
         }
         else
         {
            GXv_int2[36] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV164Postulacioneswwds_30_tfpostulacionesprecio_to) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesPrecio] <= @AV164Postulacioneswwds_30_tfpostulacionesprecio_to)");
         }
         else
         {
            GXv_int2[37] = 1;
         }
         if ( ! (0==AV165Postulacioneswwds_31_tfpostulacionesmultimediaserial) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesMultimediaSerial] >= @AV165Postulacioneswwds_31_tfpostulacionesmultimediaserial)");
         }
         else
         {
            GXv_int2[38] = 1;
         }
         if ( ! (0==AV166Postulacioneswwds_32_tfpostulacionesmultimediaserial_to) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesMultimediaSerial] <= @AV166Postulacioneswwds_32_tfpostulacionesmultimediaserial_to)");
         }
         else
         {
            GXv_int2[39] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV170Postulacioneswwds_36_tfpostulacionesdescripcion_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV169Postulacioneswwds_35_tfpostulacionesdescripcion)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[PostulacionesDescripcion]) like UPPER(@lV169Postulacioneswwds_35_tfpostulacionesdescripcion))");
         }
         else
         {
            GXv_int2[40] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV170Postulacioneswwds_36_tfpostulacionesdescripcion_sel)) && ! ( StringUtil.StrCmp(AV170Postulacioneswwds_36_tfpostulacionesdescripcion_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesDescripcion] = @AV170Postulacioneswwds_36_tfpostulacionesdescripcion_sel)");
         }
         else
         {
            GXv_int2[41] = 1;
         }
         if ( StringUtil.StrCmp(AV170Postulacioneswwds_36_tfpostulacionesdescripcion_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[PostulacionesDescripcion] = ''))");
         }
         if ( AV171Postulacioneswwds_37_tfpostulacionesreqsuministros_sel == 1 )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesReqSuministros] = 1)");
         }
         if ( AV171Postulacioneswwds_37_tfpostulacionesreqsuministros_sel == 2 )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesReqSuministros] = 0)");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV173Postulacioneswwds_39_tfpostulacionessuministrosdescripcion_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV172Postulacioneswwds_38_tfpostulacionessuministrosdescripcion)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[PostulacionesSuministrosDescri]) like UPPER(@lV172Postulacioneswwds_38_tfpostulacionessuministrosdescripcion))");
         }
         else
         {
            GXv_int2[42] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV173Postulacioneswwds_39_tfpostulacionessuministrosdescripcion_sel)) && ! ( StringUtil.StrCmp(AV173Postulacioneswwds_39_tfpostulacionessuministrosdescripcion_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesSuministrosDescri] = @AV173Postulacioneswwds_39_tfpostulacionessuministrosdescripcion_sel)");
         }
         else
         {
            GXv_int2[43] = 1;
         }
         if ( StringUtil.StrCmp(AV173Postulacioneswwds_39_tfpostulacionessuministrosdescripcion_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[PostulacionesSuministrosDescri] = ''))");
         }
         if ( ! (DateTime.MinValue==AV174Postulacioneswwds_40_tfpostulacionesfechatrabajo) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesFechaTrabajo] >= @AV174Postulacioneswwds_40_tfpostulacionesfechatrabajo)");
         }
         else
         {
            GXv_int2[44] = 1;
         }
         if ( ! (DateTime.MinValue==AV175Postulacioneswwds_41_tfpostulacionesfechatrabajo_to) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesFechaTrabajo] <= @AV175Postulacioneswwds_41_tfpostulacionesfechatrabajo_to)");
         }
         else
         {
            GXv_int2[45] = 1;
         }
         if ( ! (DateTime.MinValue==AV176Postulacioneswwds_42_tfpostulacionesfechacierre) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesFechaCierre] >= @AV176Postulacioneswwds_42_tfpostulacionesfechacierre)");
         }
         else
         {
            GXv_int2[46] = 1;
         }
         if ( ! (DateTime.MinValue==AV177Postulacioneswwds_43_tfpostulacionesfechacierre_to) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesFechaCierre] <= @AV177Postulacioneswwds_43_tfpostulacionesfechacierre_to)");
         }
         else
         {
            GXv_int2[47] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV179Postulacioneswwds_45_tfpostulacioneshoracierre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV178Postulacioneswwds_44_tfpostulacioneshoracierre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[PostulacionesHoraCierre]) like UPPER(@lV178Postulacioneswwds_44_tfpostulacioneshoracierre))");
         }
         else
         {
            GXv_int2[48] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV179Postulacioneswwds_45_tfpostulacioneshoracierre_sel)) && ! ( StringUtil.StrCmp(AV179Postulacioneswwds_45_tfpostulacioneshoracierre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesHoraCierre] = @AV179Postulacioneswwds_45_tfpostulacioneshoracierre_sel)");
         }
         else
         {
            GXv_int2[49] = 1;
         }
         if ( StringUtil.StrCmp(AV179Postulacioneswwds_45_tfpostulacioneshoracierre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[PostulacionesHoraCierre] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV181Postulacioneswwds_47_tfpostulacionestipofecha_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV180Postulacioneswwds_46_tfpostulacionestipofecha)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[PostulacionesTipoFecha]) like UPPER(@lV180Postulacioneswwds_46_tfpostulacionestipofecha))");
         }
         else
         {
            GXv_int2[50] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV181Postulacioneswwds_47_tfpostulacionestipofecha_sel)) && ! ( StringUtil.StrCmp(AV181Postulacioneswwds_47_tfpostulacionestipofecha_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesTipoFecha] = @AV181Postulacioneswwds_47_tfpostulacionestipofecha_sel)");
         }
         else
         {
            GXv_int2[51] = 1;
         }
         if ( StringUtil.StrCmp(AV181Postulacioneswwds_47_tfpostulacionestipofecha_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[PostulacionesTipoFecha] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV183Postulacioneswwds_49_tfpostulacionesrgohoraservicio_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV182Postulacioneswwds_48_tfpostulacionesrgohoraservicio)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[PostulacionesRgoHoraservicio]) like UPPER(@lV182Postulacioneswwds_48_tfpostulacionesrgohoraservicio))");
         }
         else
         {
            GXv_int2[52] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV183Postulacioneswwds_49_tfpostulacionesrgohoraservicio_sel)) && ! ( StringUtil.StrCmp(AV183Postulacioneswwds_49_tfpostulacionesrgohoraservicio_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesRgoHoraservicio] = @AV183Postulacioneswwds_49_tfpostulacionesrgohoraservicio_sel)");
         }
         else
         {
            GXv_int2[53] = 1;
         }
         if ( StringUtil.StrCmp(AV183Postulacioneswwds_49_tfpostulacionesrgohoraservicio_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[PostulacionesRgoHoraservicio] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV185Postulacioneswwds_51_tfpostulacionesapellidonombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV184Postulacioneswwds_50_tfpostulacionesapellidonombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[PostulacionesApellidoNombre]) like UPPER(@lV184Postulacioneswwds_50_tfpostulacionesapellidonombre))");
         }
         else
         {
            GXv_int2[54] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV185Postulacioneswwds_51_tfpostulacionesapellidonombre_sel)) && ! ( StringUtil.StrCmp(AV185Postulacioneswwds_51_tfpostulacionesapellidonombre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesApellidoNombre] = @AV185Postulacioneswwds_51_tfpostulacionesapellidonombre_sel)");
         }
         else
         {
            GXv_int2[55] = 1;
         }
         if ( StringUtil.StrCmp(AV185Postulacioneswwds_51_tfpostulacionesapellidonombre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[PostulacionesApellidoNombre] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV187Postulacioneswwds_53_tfpostulacionesmail_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV186Postulacioneswwds_52_tfpostulacionesmail)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[PostulacionesMail]) like UPPER(@lV186Postulacioneswwds_52_tfpostulacionesmail))");
         }
         else
         {
            GXv_int2[56] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV187Postulacioneswwds_53_tfpostulacionesmail_sel)) && ! ( StringUtil.StrCmp(AV187Postulacioneswwds_53_tfpostulacionesmail_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesMail] = @AV187Postulacioneswwds_53_tfpostulacionesmail_sel)");
         }
         else
         {
            GXv_int2[57] = 1;
         }
         if ( StringUtil.StrCmp(AV187Postulacioneswwds_53_tfpostulacionesmail_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[PostulacionesMail] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV189Postulacioneswwds_55_tfpostulacionestelefono_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV188Postulacioneswwds_54_tfpostulacionestelefono)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[PostulacionesTelefono]) like UPPER(@lV188Postulacioneswwds_54_tfpostulacionestelefono))");
         }
         else
         {
            GXv_int2[58] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV189Postulacioneswwds_55_tfpostulacionestelefono_sel)) && ! ( StringUtil.StrCmp(AV189Postulacioneswwds_55_tfpostulacionestelefono_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesTelefono] = @AV189Postulacioneswwds_55_tfpostulacionestelefono_sel)");
         }
         else
         {
            GXv_int2[59] = 1;
         }
         if ( StringUtil.StrCmp(AV189Postulacioneswwds_55_tfpostulacionestelefono_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[PostulacionesTelefono] = ''))");
         }
         if ( ! (DateTime.MinValue==AV190Postulacioneswwds_56_tfpostulacionesfechaalta) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesFechaAlta] >= @AV190Postulacioneswwds_56_tfpostulacionesfechaalta)");
         }
         else
         {
            GXv_int2[60] = 1;
         }
         if ( ! (DateTime.MinValue==AV191Postulacioneswwds_57_tfpostulacionesfechaalta_to) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesFechaAlta] <= @AV191Postulacioneswwds_57_tfpostulacionesfechaalta_to)");
         }
         else
         {
            GXv_int2[61] = 1;
         }
         if ( AV192Postulacioneswwds_58_tfpostulacionesestado_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV192Postulacioneswwds_58_tfpostulacionesestado_sels, "T1.[PostulacionesEstado] IN (", ")")+")");
         }
         if ( ! (0==AV193Postulacioneswwds_59_tfpostulacionessecuserid) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesSecUserId] >= @AV193Postulacioneswwds_59_tfpostulacionessecuserid)");
         }
         else
         {
            GXv_int2[62] = 1;
         }
         if ( ! (0==AV194Postulacioneswwds_60_tfpostulacionessecuserid_to) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesSecUserId] <= @AV194Postulacioneswwds_60_tfpostulacionessecuserid_to)");
         }
         else
         {
            GXv_int2[63] = 1;
         }
         scmdbuf += sWhereString;
         if ( ( AV11OrderedBy == 1 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY T3.[ProveedorNombre]";
         }
         else if ( ( AV11OrderedBy == 1 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T3.[ProveedorNombre] DESC";
         }
         else if ( ( AV11OrderedBy == 2 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[PostulacionesProveedorId]";
         }
         else if ( ( AV11OrderedBy == 2 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[PostulacionesProveedorId] DESC";
         }
         else if ( ( AV11OrderedBy == 3 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[PostulacionesId]";
         }
         else if ( ( AV11OrderedBy == 3 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[PostulacionesId] DESC";
         }
         else if ( ( AV11OrderedBy == 4 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[ServiciosId]";
         }
         else if ( ( AV11OrderedBy == 4 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[ServiciosId] DESC";
         }
         else if ( ( AV11OrderedBy == 5 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY T2.[ServiciosNombre]";
         }
         else if ( ( AV11OrderedBy == 5 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T2.[ServiciosNombre] DESC";
         }
         else if ( ( AV11OrderedBy == 6 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[PostulacionesPrecio]";
         }
         else if ( ( AV11OrderedBy == 6 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[PostulacionesPrecio] DESC";
         }
         else if ( ( AV11OrderedBy == 7 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[PostulacionesMultimediaSerial]";
         }
         else if ( ( AV11OrderedBy == 7 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[PostulacionesMultimediaSerial] DESC";
         }
         else if ( ( AV11OrderedBy == 8 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[PostulacionesDescripcion]";
         }
         else if ( ( AV11OrderedBy == 8 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[PostulacionesDescripcion] DESC";
         }
         else if ( ( AV11OrderedBy == 9 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[PostulacionesReqSuministros]";
         }
         else if ( ( AV11OrderedBy == 9 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[PostulacionesReqSuministros] DESC";
         }
         else if ( ( AV11OrderedBy == 10 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[PostulacionesSuministrosDescri]";
         }
         else if ( ( AV11OrderedBy == 10 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[PostulacionesSuministrosDescri] DESC";
         }
         else if ( ( AV11OrderedBy == 11 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[PostulacionesFechaTrabajo]";
         }
         else if ( ( AV11OrderedBy == 11 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[PostulacionesFechaTrabajo] DESC";
         }
         else if ( ( AV11OrderedBy == 12 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[PostulacionesFechaCierre]";
         }
         else if ( ( AV11OrderedBy == 12 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[PostulacionesFechaCierre] DESC";
         }
         else if ( ( AV11OrderedBy == 13 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[PostulacionesHoraCierre]";
         }
         else if ( ( AV11OrderedBy == 13 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[PostulacionesHoraCierre] DESC";
         }
         else if ( ( AV11OrderedBy == 14 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[PostulacionesTipoFecha]";
         }
         else if ( ( AV11OrderedBy == 14 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[PostulacionesTipoFecha] DESC";
         }
         else if ( ( AV11OrderedBy == 15 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[PostulacionesRgoHoraservicio]";
         }
         else if ( ( AV11OrderedBy == 15 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[PostulacionesRgoHoraservicio] DESC";
         }
         else if ( ( AV11OrderedBy == 16 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[PostulacionesApellidoNombre]";
         }
         else if ( ( AV11OrderedBy == 16 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[PostulacionesApellidoNombre] DESC";
         }
         else if ( ( AV11OrderedBy == 17 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[PostulacionesMail]";
         }
         else if ( ( AV11OrderedBy == 17 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[PostulacionesMail] DESC";
         }
         else if ( ( AV11OrderedBy == 18 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[PostulacionesTelefono]";
         }
         else if ( ( AV11OrderedBy == 18 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[PostulacionesTelefono] DESC";
         }
         else if ( ( AV11OrderedBy == 19 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[PostulacionesFechaAlta]";
         }
         else if ( ( AV11OrderedBy == 19 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[PostulacionesFechaAlta] DESC";
         }
         else if ( ( AV11OrderedBy == 20 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[PostulacionesEstado]";
         }
         else if ( ( AV11OrderedBy == 20 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[PostulacionesEstado] DESC";
         }
         else if ( ( AV11OrderedBy == 21 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[PostulacionesSecUserId]";
         }
         else if ( ( AV11OrderedBy == 21 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[PostulacionesSecUserId] DESC";
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
                     return conditional_P00LC3(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (long)dynConstraints[5] , (string)dynConstraints[6] , (bool)dynConstraints[7] , (string)dynConstraints[8] , (short)dynConstraints[9] , (string)dynConstraints[10] , (long)dynConstraints[11] , (string)dynConstraints[12] , (bool)dynConstraints[13] , (string)dynConstraints[14] , (short)dynConstraints[15] , (string)dynConstraints[16] , (long)dynConstraints[17] , (string)dynConstraints[18] , (long)dynConstraints[19] , (long)dynConstraints[20] , (long)dynConstraints[21] , (long)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (long)dynConstraints[25] , (long)dynConstraints[26] , (string)dynConstraints[27] , (string)dynConstraints[28] , (decimal)dynConstraints[29] , (decimal)dynConstraints[30] , (short)dynConstraints[31] , (short)dynConstraints[32] , (string)dynConstraints[33] , (string)dynConstraints[34] , (short)dynConstraints[35] , (string)dynConstraints[36] , (string)dynConstraints[37] , (DateTime)dynConstraints[38] , (DateTime)dynConstraints[39] , (DateTime)dynConstraints[40] , (DateTime)dynConstraints[41] , (string)dynConstraints[42] , (string)dynConstraints[43] , (string)dynConstraints[44] , (string)dynConstraints[45] , (string)dynConstraints[46] , (string)dynConstraints[47] , (string)dynConstraints[48] , (string)dynConstraints[49] , (string)dynConstraints[50] , (string)dynConstraints[51] , (string)dynConstraints[52] , (string)dynConstraints[53] , (DateTime)dynConstraints[54] , (DateTime)dynConstraints[55] , (int)dynConstraints[56] , (long)dynConstraints[57] , (long)dynConstraints[58] , (string)dynConstraints[59] , (long)dynConstraints[60] , (string)dynConstraints[61] , (long)dynConstraints[62] , (long)dynConstraints[63] , (decimal)dynConstraints[64] , (short)dynConstraints[65] , (string)dynConstraints[66] , (bool)dynConstraints[67] , (string)dynConstraints[68] , (DateTime)dynConstraints[69] , (DateTime)dynConstraints[70] , (string)dynConstraints[71] , (string)dynConstraints[72] , (string)dynConstraints[73] , (string)dynConstraints[74] , (string)dynConstraints[75] , (string)dynConstraints[76] , (DateTime)dynConstraints[77] , (long)dynConstraints[78] , (short)dynConstraints[79] , (bool)dynConstraints[80] , (string)dynConstraints[81] , (long)dynConstraints[82] , (long)dynConstraints[83] , (long)dynConstraints[84] );
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
          Object[] prmP00LC3;
          prmP00LC3 = new Object[] {
          new ParDef("@PostulacionesId",GXType.Decimal,18,0){Nullable=true} ,
          new ParDef("@AV167Postulacioneswwds_33_tfpostulacionessolicitudesid",GXType.Decimal,18,0) ,
          new ParDef("@AV167Postulacioneswwds_33_tfpostulacionessolicitudesid",GXType.Decimal,18,0) ,
          new ParDef("@AV168Postulacioneswwds_34_tfpostulacionessolicitudesid_to",GXType.Decimal,18,0) ,
          new ParDef("@AV168Postulacioneswwds_34_tfpostulacionessolicitudesid_to",GXType.Decimal,18,0) ,
          new ParDef("@lV138Postulacioneswwds_4_postulacionesproveedornombre1",GXType.Char,80,0) ,
          new ParDef("@lV138Postulacioneswwds_4_postulacionesproveedornombre1",GXType.Char,80,0) ,
          new ParDef("@AV139Postulacioneswwds_5_postulacionesproveedorid1",GXType.Decimal,18,0) ,
          new ParDef("@AV139Postulacioneswwds_5_postulacionesproveedorid1",GXType.Decimal,18,0) ,
          new ParDef("@AV139Postulacioneswwds_5_postulacionesproveedorid1",GXType.Decimal,18,0) ,
          new ParDef("@lV140Postulacioneswwds_6_serviciosnombre1",GXType.Char,80,0) ,
          new ParDef("@lV140Postulacioneswwds_6_serviciosnombre1",GXType.Char,80,0) ,
          new ParDef("@lV144Postulacioneswwds_10_postulacionesproveedornombre2",GXType.Char,80,0) ,
          new ParDef("@lV144Postulacioneswwds_10_postulacionesproveedornombre2",GXType.Char,80,0) ,
          new ParDef("@AV145Postulacioneswwds_11_postulacionesproveedorid2",GXType.Decimal,18,0) ,
          new ParDef("@AV145Postulacioneswwds_11_postulacionesproveedorid2",GXType.Decimal,18,0) ,
          new ParDef("@AV145Postulacioneswwds_11_postulacionesproveedorid2",GXType.Decimal,18,0) ,
          new ParDef("@lV146Postulacioneswwds_12_serviciosnombre2",GXType.Char,80,0) ,
          new ParDef("@lV146Postulacioneswwds_12_serviciosnombre2",GXType.Char,80,0) ,
          new ParDef("@lV150Postulacioneswwds_16_postulacionesproveedornombre3",GXType.Char,80,0) ,
          new ParDef("@lV150Postulacioneswwds_16_postulacionesproveedornombre3",GXType.Char,80,0) ,
          new ParDef("@AV151Postulacioneswwds_17_postulacionesproveedorid3",GXType.Decimal,18,0) ,
          new ParDef("@AV151Postulacioneswwds_17_postulacionesproveedorid3",GXType.Decimal,18,0) ,
          new ParDef("@AV151Postulacioneswwds_17_postulacionesproveedorid3",GXType.Decimal,18,0) ,
          new ParDef("@lV152Postulacioneswwds_18_serviciosnombre3",GXType.Char,80,0) ,
          new ParDef("@lV152Postulacioneswwds_18_serviciosnombre3",GXType.Char,80,0) ,
          new ParDef("@AV153Postulacioneswwds_19_tfpostulacionesid",GXType.Decimal,18,0) ,
          new ParDef("@AV154Postulacioneswwds_20_tfpostulacionesid_to",GXType.Decimal,18,0) ,
          new ParDef("@AV155Postulacioneswwds_21_tfserviciosid",GXType.Decimal,18,0) ,
          new ParDef("@AV156Postulacioneswwds_22_tfserviciosid_to",GXType.Decimal,18,0) ,
          new ParDef("@lV157Postulacioneswwds_23_tfserviciosnombre",GXType.Char,80,0) ,
          new ParDef("@AV158Postulacioneswwds_24_tfserviciosnombre_sel",GXType.NChar,80,0) ,
          new ParDef("@AV159Postulacioneswwds_25_tfpostulacionesproveedorid",GXType.Decimal,18,0) ,
          new ParDef("@AV160Postulacioneswwds_26_tfpostulacionesproveedorid_to",GXType.Decimal,18,0) ,
          new ParDef("@lV161Postulacioneswwds_27_tfpostulacionesproveedornombre",GXType.Char,80,0) ,
          new ParDef("@AV162Postulacioneswwds_28_tfpostulacionesproveedornombre_sel",GXType.NChar,80,0) ,
          new ParDef("@AV163Postulacioneswwds_29_tfpostulacionesprecio",GXType.Decimal,18,2) ,
          new ParDef("@AV164Postulacioneswwds_30_tfpostulacionesprecio_to",GXType.Decimal,18,2) ,
          new ParDef("@AV165Postulacioneswwds_31_tfpostulacionesmultimediaserial",GXType.Int16,4,0) ,
          new ParDef("@AV166Postulacioneswwds_32_tfpostulacionesmultimediaserial_to",GXType.Int16,4,0) ,
          new ParDef("@lV169Postulacioneswwds_35_tfpostulacionesdescripcion",GXType.Char,2000,0) ,
          new ParDef("@AV170Postulacioneswwds_36_tfpostulacionesdescripcion_sel",GXType.NChar,2000,0) ,
          new ParDef("@lV172Postulacioneswwds_38_tfpostulacionessuministrosdescripcion",GXType.Char,250,0) ,
          new ParDef("@AV173Postulacioneswwds_39_tfpostulacionessuministrosdescripcion_sel",GXType.NChar,250,0) ,
          new ParDef("@AV174Postulacioneswwds_40_tfpostulacionesfechatrabajo",GXType.Date,8,0) ,
          new ParDef("@AV175Postulacioneswwds_41_tfpostulacionesfechatrabajo_to",GXType.Date,8,0) ,
          new ParDef("@AV176Postulacioneswwds_42_tfpostulacionesfechacierre",GXType.Date,8,0) ,
          new ParDef("@AV177Postulacioneswwds_43_tfpostulacionesfechacierre_to",GXType.Date,8,0) ,
          new ParDef("@lV178Postulacioneswwds_44_tfpostulacioneshoracierre",GXType.VarChar,8,5) ,
          new ParDef("@AV179Postulacioneswwds_45_tfpostulacioneshoracierre_sel",GXType.NVarChar,8,5) ,
          new ParDef("@lV180Postulacioneswwds_46_tfpostulacionestipofecha",GXType.VarChar,10,0) ,
          new ParDef("@AV181Postulacioneswwds_47_tfpostulacionestipofecha_sel",GXType.NVarChar,10,0) ,
          new ParDef("@lV182Postulacioneswwds_48_tfpostulacionesrgohoraservicio",GXType.Char,5,0) ,
          new ParDef("@AV183Postulacioneswwds_49_tfpostulacionesrgohoraservicio_sel",GXType.NChar,5,0) ,
          new ParDef("@lV184Postulacioneswwds_50_tfpostulacionesapellidonombre",GXType.Char,80,0) ,
          new ParDef("@AV185Postulacioneswwds_51_tfpostulacionesapellidonombre_sel",GXType.NChar,80,0) ,
          new ParDef("@lV186Postulacioneswwds_52_tfpostulacionesmail",GXType.VarChar,100,0) ,
          new ParDef("@AV187Postulacioneswwds_53_tfpostulacionesmail_sel",GXType.NVarChar,100,0) ,
          new ParDef("@lV188Postulacioneswwds_54_tfpostulacionestelefono",GXType.Char,20,0) ,
          new ParDef("@AV189Postulacioneswwds_55_tfpostulacionestelefono_sel",GXType.NChar,20,0) ,
          new ParDef("@AV190Postulacioneswwds_56_tfpostulacionesfechaalta",GXType.DateTime,8,5) ,
          new ParDef("@AV191Postulacioneswwds_57_tfpostulacionesfechaalta_to",GXType.DateTime,8,5) ,
          new ParDef("@AV193Postulacioneswwds_59_tfpostulacionessecuserid",GXType.Decimal,18,0) ,
          new ParDef("@AV194Postulacioneswwds_60_tfpostulacionessecuserid_to",GXType.Decimal,18,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00LC3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00LC3,100, GxCacheFrequency.OFF ,true,false )
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
                ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 20);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((string[]) buf[4])[0] = rslt.getString(5, 80);
                ((string[]) buf[5])[0] = rslt.getString(6, 5);
                ((string[]) buf[6])[0] = rslt.getVarchar(7);
                ((string[]) buf[7])[0] = rslt.getVarchar(8);
                ((DateTime[]) buf[8])[0] = rslt.getGXDate(9);
                ((DateTime[]) buf[9])[0] = rslt.getGXDate(10);
                ((string[]) buf[10])[0] = rslt.getString(11, 250);
                ((bool[]) buf[11])[0] = rslt.getBool(12);
                ((string[]) buf[12])[0] = rslt.getString(13, 2000);
                ((short[]) buf[13])[0] = rslt.getShort(14);
                ((decimal[]) buf[14])[0] = rslt.getDecimal(15);
                ((string[]) buf[15])[0] = rslt.getString(16, 80);
                ((string[]) buf[16])[0] = rslt.getString(17, 80);
                ((long[]) buf[17])[0] = rslt.getLong(18);
                ((bool[]) buf[18])[0] = rslt.wasNull(18);
                ((long[]) buf[19])[0] = rslt.getLong(19);
                ((long[]) buf[20])[0] = rslt.getLong(20);
                ((string[]) buf[21])[0] = rslt.getString(21, 3);
                ((long[]) buf[22])[0] = rslt.getLong(22);
                ((bool[]) buf[23])[0] = rslt.wasNull(22);
                return;
       }
    }

 }

}

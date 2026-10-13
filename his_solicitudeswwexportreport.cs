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
   public class his_solicitudeswwexportreport : GXWebProcedure, System.Web.SessionState.IRequiresSessionState
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

      public his_solicitudeswwexportreport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public his_solicitudeswwexportreport( IGxContext context )
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
         setOutputFileName("HIS_SolicitudesWWExportReport");
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
            new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWHIS_Solicitudes", out  GXt_boolean1) ;
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
               new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV9WWPContext) ;
               /* Execute user subroutine: 'LOADGRIDSTATE' */
               S151 ();
               if ( returnInSub )
               {
                  cleanup();
                  if (true) return;
               }
               AV47Title = context.GetMessage( "Lista de HIS_Solicitudes", "");
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
            HKE0( true, 0) ;
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
         if ( ! (0==AV15SolicitudesID2) )
         {
            if ( AV14SolicitudesID2Operator == 0 )
            {
               AV13FilterSolicitudesID2Description = StringUtil.Format( "%1 (%2)", context.GetMessage( "Solicitud Id", ""), "=", "", "", "", "", "", "", "");
            }
            HKE0( false, 19) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV13FilterSolicitudesID2Description, "")), 25, Gx_line+0, 145, Gx_line+14, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV15SolicitudesID2), "ZZZZZZZZZZZZZZZZZ9")), 145, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+19);
         }
         if ( ! ( (0==AV20TFSolicitudesID2) && (0==AV21TFSolicitudesID2_To) ) )
         {
            HKE0( false, 19) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Solicitud Id", ""), 25, Gx_line+0, 145, Gx_line+14, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV20TFSolicitudesID2), "ZZZZZZZZZZZZZZZZZ9")), 145, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+19);
            AV34TFSolicitudesID2_To_Description = StringUtil.Format( "%1 (%2)", context.GetMessage( "Solicitud Id", ""), context.GetMessage( "WWP_TSTo", ""), "", "", "", "", "", "", "");
            HKE0( false, 19) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV34TFSolicitudesID2_To_Description, "")), 25, Gx_line+0, 145, Gx_line+14, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV21TFSolicitudesID2_To), "ZZZZZZZZZZZZZZZZZ9")), 145, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+19);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV23TFUsuario_Sel)) )
         {
            AV36TempBoolean = (bool)(((StringUtil.StrCmp(AV23TFUsuario_Sel, "<#Empty#>")==0)));
            AV23TFUsuario_Sel = (AV36TempBoolean ? context.GetMessage( "WWP_TitleFilter_EmptyOption", "") : AV23TFUsuario_Sel);
            HKE0( false, 19) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Usuario", ""), 25, Gx_line+0, 145, Gx_line+14, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV23TFUsuario_Sel, "")), 145, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+19);
            AV23TFUsuario_Sel = (AV36TempBoolean ? "<#Empty#>" : AV23TFUsuario_Sel);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV22TFUsuario)) )
            {
               HKE0( false, 19) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(context.GetMessage( "Usuario", ""), 25, Gx_line+0, 145, Gx_line+14, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV22TFUsuario, "")), 145, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+19);
            }
         }
         if ( ! ( (DateTime.MinValue==AV24TFFechaCambio) && (DateTime.MinValue==AV25TFFechaCambio_To) ) )
         {
            HKE0( false, 19) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Fecha Cambio", ""), 25, Gx_line+0, 145, Gx_line+14, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.localUtil.Format( AV24TFFechaCambio, "99/99/9999 99:99:99"), 145, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+19);
            AV35TFFechaCambio_To_Description = StringUtil.Format( "%1 (%2)", context.GetMessage( "Fecha Cambio", ""), context.GetMessage( "WWP_TSTo", ""), "", "", "", "", "", "", "");
            HKE0( false, 19) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV35TFFechaCambio_To_Description, "")), 25, Gx_line+0, 145, Gx_line+14, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.localUtil.Format( AV25TFFechaCambio_To, "99/99/9999 99:99:99"), 145, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+19);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV29TFCampoModificado_Sel)) )
         {
            AV36TempBoolean = (bool)(((StringUtil.StrCmp(AV29TFCampoModificado_Sel, "<#Empty#>")==0)));
            AV29TFCampoModificado_Sel = (AV36TempBoolean ? context.GetMessage( "WWP_TitleFilter_EmptyOption", "") : AV29TFCampoModificado_Sel);
            HKE0( false, 19) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Campo Modificado", ""), 25, Gx_line+0, 145, Gx_line+14, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV29TFCampoModificado_Sel, "")), 145, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+19);
            AV29TFCampoModificado_Sel = (AV36TempBoolean ? "<#Empty#>" : AV29TFCampoModificado_Sel);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV28TFCampoModificado)) )
            {
               HKE0( false, 19) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(context.GetMessage( "Campo Modificado", ""), 25, Gx_line+0, 145, Gx_line+14, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV28TFCampoModificado, "")), 145, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+19);
            }
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV31TFValorAnterior_Sel)) )
         {
            AV36TempBoolean = (bool)(((StringUtil.StrCmp(AV31TFValorAnterior_Sel, "<#Empty#>")==0)));
            AV31TFValorAnterior_Sel = (AV36TempBoolean ? context.GetMessage( "WWP_TitleFilter_EmptyOption", "") : AV31TFValorAnterior_Sel);
            HKE0( false, 19) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Valor Anterior", ""), 25, Gx_line+0, 145, Gx_line+14, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV31TFValorAnterior_Sel, "")), 145, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+19);
            AV31TFValorAnterior_Sel = (AV36TempBoolean ? "<#Empty#>" : AV31TFValorAnterior_Sel);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV30TFValorAnterior)) )
            {
               HKE0( false, 19) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(context.GetMessage( "Valor Anterior", ""), 25, Gx_line+0, 145, Gx_line+14, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV30TFValorAnterior, "")), 145, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+19);
            }
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV33TFValorNuevo_Sel)) )
         {
            AV36TempBoolean = (bool)(((StringUtil.StrCmp(AV33TFValorNuevo_Sel, "<#Empty#>")==0)));
            AV33TFValorNuevo_Sel = (AV36TempBoolean ? context.GetMessage( "WWP_TitleFilter_EmptyOption", "") : AV33TFValorNuevo_Sel);
            HKE0( false, 19) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Valor Nuevo", ""), 25, Gx_line+0, 145, Gx_line+14, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV33TFValorNuevo_Sel, "")), 145, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+19);
            AV33TFValorNuevo_Sel = (AV36TempBoolean ? "<#Empty#>" : AV33TFValorNuevo_Sel);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV32TFValorNuevo)) )
            {
               HKE0( false, 19) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(context.GetMessage( "Valor Nuevo", ""), 25, Gx_line+0, 145, Gx_line+14, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV32TFValorNuevo, "")), 145, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+19);
            }
         }
      }

      protected void S121( )
      {
         /* 'PRINTCOLUMNTITLES' Routine */
         returnInSub = false;
         HKE0( false, 22) ;
         getPrinter().GxDrawLine(25, Gx_line+21, 789, Gx_line+21, 2, 8, 160, 134, 0) ;
         Gx_OldLine = Gx_line;
         Gx_line = (int)(Gx_line+22);
         HKE0( false, 36) ;
         getPrinter().GxAttris("Microsoft Sans Serif", 9, false, false, false, false, 0, 8, 160, 134, 0, 255, 255, 255) ;
         getPrinter().GxDrawText(context.GetMessage( "Solicitud Id", ""), 30, Gx_line+10, 103, Gx_line+26, 2, 0, 0, 0) ;
         getPrinter().GxDrawText(context.GetMessage( "Usuario", ""), 107, Gx_line+10, 253, Gx_line+26, 0, 0, 0, 0) ;
         getPrinter().GxDrawText(context.GetMessage( "Fecha Cambio", ""), 257, Gx_line+10, 331, Gx_line+26, 0, 0, 0, 0) ;
         getPrinter().GxDrawText(context.GetMessage( "Campo Modificado", ""), 335, Gx_line+10, 483, Gx_line+26, 0, 0, 0, 0) ;
         getPrinter().GxDrawText(context.GetMessage( "Valor Anterior", ""), 487, Gx_line+10, 635, Gx_line+26, 0, 0, 0, 0) ;
         getPrinter().GxDrawText(context.GetMessage( "Valor Nuevo", ""), 639, Gx_line+10, 787, Gx_line+26, 0, 0, 0, 0) ;
         Gx_OldLine = Gx_line;
         Gx_line = (int)(Gx_line+36);
      }

      protected void S131( )
      {
         /* 'PRINTDATA' Routine */
         returnInSub = false;
         AV53His_solicitudeswwds_1_solicitudesid2 = AV15SolicitudesID2;
         AV54His_solicitudeswwds_2_tfsolicitudesid2 = AV20TFSolicitudesID2;
         AV55His_solicitudeswwds_3_tfsolicitudesid2_to = AV21TFSolicitudesID2_To;
         AV56His_solicitudeswwds_4_tfusuario = AV22TFUsuario;
         AV57His_solicitudeswwds_5_tfusuario_sel = AV23TFUsuario_Sel;
         AV58His_solicitudeswwds_6_tffechacambio = AV24TFFechaCambio;
         AV59His_solicitudeswwds_7_tffechacambio_to = AV25TFFechaCambio_To;
         AV60His_solicitudeswwds_8_tfcampomodificado = AV28TFCampoModificado;
         AV61His_solicitudeswwds_9_tfcampomodificado_sel = AV29TFCampoModificado_Sel;
         AV62His_solicitudeswwds_10_tfvaloranterior = AV30TFValorAnterior;
         AV63His_solicitudeswwds_11_tfvaloranterior_sel = AV31TFValorAnterior_Sel;
         AV64His_solicitudeswwds_12_tfvalornuevo = AV32TFValorNuevo;
         AV65His_solicitudeswwds_13_tfvalornuevo_sel = AV33TFValorNuevo_Sel;
         pr_datastore1.dynParam(0, new Object[]{ new Object[]{
                                              AV14SolicitudesID2Operator ,
                                              AV53His_solicitudeswwds_1_solicitudesid2 ,
                                              AV54His_solicitudeswwds_2_tfsolicitudesid2 ,
                                              AV55His_solicitudeswwds_3_tfsolicitudesid2_to ,
                                              AV57His_solicitudeswwds_5_tfusuario_sel ,
                                              AV56His_solicitudeswwds_4_tfusuario ,
                                              AV58His_solicitudeswwds_6_tffechacambio ,
                                              AV59His_solicitudeswwds_7_tffechacambio_to ,
                                              AV61His_solicitudeswwds_9_tfcampomodificado_sel ,
                                              AV60His_solicitudeswwds_8_tfcampomodificado ,
                                              AV63His_solicitudeswwds_11_tfvaloranterior_sel ,
                                              AV62His_solicitudeswwds_10_tfvaloranterior ,
                                              AV65His_solicitudeswwds_13_tfvalornuevo_sel ,
                                              AV64His_solicitudeswwds_12_tfvalornuevo ,
                                              A910SolicitudesID2 ,
                                              A912Usuario ,
                                              A911FechaCambio ,
                                              A914CampoModificado ,
                                              A915ValorAnterior ,
                                              A916ValorNuevo ,
                                              AV11OrderedBy ,
                                              AV12OrderedDsc } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.LONG, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN,
                                              TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV56His_solicitudeswwds_4_tfusuario = StringUtil.Concat( StringUtil.RTrim( AV56His_solicitudeswwds_4_tfusuario), "%", "");
         lV60His_solicitudeswwds_8_tfcampomodificado = StringUtil.Concat( StringUtil.RTrim( AV60His_solicitudeswwds_8_tfcampomodificado), "%", "");
         lV62His_solicitudeswwds_10_tfvaloranterior = StringUtil.Concat( StringUtil.RTrim( AV62His_solicitudeswwds_10_tfvaloranterior), "%", "");
         lV64His_solicitudeswwds_12_tfvalornuevo = StringUtil.Concat( StringUtil.RTrim( AV64His_solicitudeswwds_12_tfvalornuevo), "%", "");
         /* Using cursor P00KE2 */
         pr_datastore1.execute(0, new Object[] {AV53His_solicitudeswwds_1_solicitudesid2, AV54His_solicitudeswwds_2_tfsolicitudesid2, AV55His_solicitudeswwds_3_tfsolicitudesid2_to, lV56His_solicitudeswwds_4_tfusuario, AV57His_solicitudeswwds_5_tfusuario_sel, AV58His_solicitudeswwds_6_tffechacambio, AV59His_solicitudeswwds_7_tffechacambio_to, lV60His_solicitudeswwds_8_tfcampomodificado, AV61His_solicitudeswwds_9_tfcampomodificado_sel, lV62His_solicitudeswwds_10_tfvaloranterior, AV63His_solicitudeswwds_11_tfvaloranterior_sel, lV64His_solicitudeswwds_12_tfvalornuevo, AV65His_solicitudeswwds_13_tfvalornuevo_sel});
         while ( (pr_datastore1.getStatus(0) != 101) )
         {
            A916ValorNuevo = P00KE2_A916ValorNuevo[0];
            n916ValorNuevo = P00KE2_n916ValorNuevo[0];
            A915ValorAnterior = P00KE2_A915ValorAnterior[0];
            n915ValorAnterior = P00KE2_n915ValorAnterior[0];
            A914CampoModificado = P00KE2_A914CampoModificado[0];
            n914CampoModificado = P00KE2_n914CampoModificado[0];
            A911FechaCambio = P00KE2_A911FechaCambio[0];
            A912Usuario = P00KE2_A912Usuario[0];
            A910SolicitudesID2 = P00KE2_A910SolicitudesID2[0];
            A909HistorialID = P00KE2_A909HistorialID[0];
            /* Execute user subroutine: 'BEFOREPRINTLINE' */
            S144 ();
            if ( returnInSub )
            {
               pr_datastore1.close(0);
               returnInSub = true;
               if (true) return;
            }
            HKE0( false, 63) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(A910SolicitudesID2), "ZZZZZZZZZZZZZZZZZ9")), 30, Gx_line+10, 103, Gx_line+52, 2+16, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A912Usuario, "")), 107, Gx_line+10, 253, Gx_line+52, 0+16, 0, 0, 0) ;
            getPrinter().GxDrawText(context.localUtil.Format( A911FechaCambio, "99/99/9999 99:99:99"), 257, Gx_line+10, 331, Gx_line+52, 0+16, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A914CampoModificado, "")), 335, Gx_line+10, 483, Gx_line+52, 0+16, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A915ValorAnterior, "")), 487, Gx_line+10, 635, Gx_line+52, 0+16, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A916ValorNuevo, "")), 639, Gx_line+10, 787, Gx_line+52, 0+16, 0, 0, 0) ;
            getPrinter().GxDrawLine(28, Gx_line+62, 789, Gx_line+62, 1, 220, 220, 220, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+63);
            /* Execute user subroutine: 'AFTERPRINTLINE' */
            S161 ();
            if ( returnInSub )
            {
               pr_datastore1.close(0);
               returnInSub = true;
               if (true) return;
            }
            pr_datastore1.readNext(0);
         }
         pr_datastore1.close(0);
      }

      protected void S151( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV16Session.Get("HIS_SolicitudesWWGridState"), "") == 0 )
         {
            AV18GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "HIS_SolicitudesWWGridState"), null, "", "");
         }
         else
         {
            AV18GridState.FromXml(AV16Session.Get("HIS_SolicitudesWWGridState"), null, "", "");
         }
         AV11OrderedBy = AV18GridState.gxTpr_Orderedby;
         AV12OrderedDsc = AV18GridState.gxTpr_Ordereddsc;
         AV66GXV1 = 1;
         while ( AV66GXV1 <= AV18GridState.gxTpr_Filtervalues.Count )
         {
            AV19GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV18GridState.gxTpr_Filtervalues.Item(AV66GXV1));
            if ( StringUtil.StrCmp(AV19GridStateFilterValue.gxTpr_Name, "SOLICITUDESID2") == 0 )
            {
               AV15SolicitudesID2 = (long)(Math.Round(NumberUtil.Val( AV19GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV14SolicitudesID2Operator = AV19GridStateFilterValue.gxTpr_Operator;
            }
            else if ( StringUtil.StrCmp(AV19GridStateFilterValue.gxTpr_Name, "TFSOLICITUDESID2") == 0 )
            {
               AV20TFSolicitudesID2 = (long)(Math.Round(NumberUtil.Val( AV19GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV21TFSolicitudesID2_To = (long)(Math.Round(NumberUtil.Val( AV19GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV19GridStateFilterValue.gxTpr_Name, "TFUSUARIO") == 0 )
            {
               AV22TFUsuario = AV19GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV19GridStateFilterValue.gxTpr_Name, "TFUSUARIO_SEL") == 0 )
            {
               AV23TFUsuario_Sel = AV19GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV19GridStateFilterValue.gxTpr_Name, "TFFECHACAMBIO") == 0 )
            {
               AV24TFFechaCambio = context.localUtil.CToT( AV19GridStateFilterValue.gxTpr_Value, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               AV25TFFechaCambio_To = context.localUtil.CToT( AV19GridStateFilterValue.gxTpr_Valueto, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
            }
            else if ( StringUtil.StrCmp(AV19GridStateFilterValue.gxTpr_Name, "TFCAMPOMODIFICADO") == 0 )
            {
               AV28TFCampoModificado = AV19GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV19GridStateFilterValue.gxTpr_Name, "TFCAMPOMODIFICADO_SEL") == 0 )
            {
               AV29TFCampoModificado_Sel = AV19GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV19GridStateFilterValue.gxTpr_Name, "TFVALORANTERIOR") == 0 )
            {
               AV30TFValorAnterior = AV19GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV19GridStateFilterValue.gxTpr_Name, "TFVALORANTERIOR_SEL") == 0 )
            {
               AV31TFValorAnterior_Sel = AV19GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV19GridStateFilterValue.gxTpr_Name, "TFVALORNUEVO") == 0 )
            {
               AV32TFValorNuevo = AV19GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV19GridStateFilterValue.gxTpr_Name, "TFVALORNUEVO_SEL") == 0 )
            {
               AV33TFValorNuevo_Sel = AV19GridStateFilterValue.gxTpr_Value;
            }
            AV66GXV1 = (int)(AV66GXV1+1);
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

      protected void HKE0( bool bFoot ,
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
                  getPrinter().GxDrawRect(0, Gx_line+5, 819, Gx_line+39, 1, 0, 0, 0, 1, 8, 160, 134, 1, 1, 1, 1, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV45PageInfo, "")), 30, Gx_line+15, 409, Gx_line+29, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV42DateInfo, "")), 409, Gx_line+15, 789, Gx_line+29, 2, 0, 0, 0) ;
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
               AV40AppName = context.GetMessage( "DVelop Software Solutions", "");
               AV46Phone = "+1 550 8923";
               AV44Mail = "info@mail.com";
               AV48Website = "http://www.web.com";
               AV37AddressLine1 = "French Boulevard 2859";
               AV38AddressLine2 = "Downtown";
               AV39AddressLine3 = "Paris, France";
               getPrinter().GxDrawRect(0, Gx_line+0, 819, Gx_line+107, 1, 0, 0, 0, 1, 8, 160, 134, 1, 1, 1, 1, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV40AppName, "")), 30, Gx_line+30, 283, Gx_line+44, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 20, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV47Title, "")), 30, Gx_line+44, 283, Gx_line+77, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV46Phone, "")), 283, Gx_line+30, 536, Gx_line+45, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV44Mail, "")), 283, Gx_line+45, 536, Gx_line+60, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV48Website, "")), 283, Gx_line+60, 536, Gx_line+77, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV37AddressLine1, "")), 536, Gx_line+30, 789, Gx_line+45, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV38AddressLine2, "")), 536, Gx_line+45, 789, Gx_line+60, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV39AddressLine3, "")), 536, Gx_line+60, 789, Gx_line+77, 2, 0, 0, 0) ;
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
         AV49Pgmname = "";
         GXEncryptionTmp = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV47Title = "";
         AV13FilterSolicitudesID2Description = "";
         AV34TFSolicitudesID2_To_Description = "";
         AV23TFUsuario_Sel = "";
         AV22TFUsuario = "";
         AV24TFFechaCambio = (DateTime)(DateTime.MinValue);
         AV25TFFechaCambio_To = (DateTime)(DateTime.MinValue);
         AV35TFFechaCambio_To_Description = "";
         AV29TFCampoModificado_Sel = "";
         AV28TFCampoModificado = "";
         AV31TFValorAnterior_Sel = "";
         AV30TFValorAnterior = "";
         AV33TFValorNuevo_Sel = "";
         AV32TFValorNuevo = "";
         AV56His_solicitudeswwds_4_tfusuario = "";
         AV57His_solicitudeswwds_5_tfusuario_sel = "";
         AV58His_solicitudeswwds_6_tffechacambio = (DateTime)(DateTime.MinValue);
         AV59His_solicitudeswwds_7_tffechacambio_to = (DateTime)(DateTime.MinValue);
         AV60His_solicitudeswwds_8_tfcampomodificado = "";
         AV61His_solicitudeswwds_9_tfcampomodificado_sel = "";
         AV62His_solicitudeswwds_10_tfvaloranterior = "";
         AV63His_solicitudeswwds_11_tfvaloranterior_sel = "";
         AV64His_solicitudeswwds_12_tfvalornuevo = "";
         AV65His_solicitudeswwds_13_tfvalornuevo_sel = "";
         lV56His_solicitudeswwds_4_tfusuario = "";
         lV60His_solicitudeswwds_8_tfcampomodificado = "";
         lV62His_solicitudeswwds_10_tfvaloranterior = "";
         lV64His_solicitudeswwds_12_tfvalornuevo = "";
         A912Usuario = "";
         A911FechaCambio = (DateTime)(DateTime.MinValue);
         A914CampoModificado = "";
         A915ValorAnterior = "";
         A916ValorNuevo = "";
         P00KE2_A916ValorNuevo = new string[] {""} ;
         P00KE2_n916ValorNuevo = new bool[] {false} ;
         P00KE2_A915ValorAnterior = new string[] {""} ;
         P00KE2_n915ValorAnterior = new bool[] {false} ;
         P00KE2_A914CampoModificado = new string[] {""} ;
         P00KE2_n914CampoModificado = new bool[] {false} ;
         P00KE2_A911FechaCambio = new DateTime[] {DateTime.MinValue} ;
         P00KE2_A912Usuario = new string[] {""} ;
         P00KE2_A910SolicitudesID2 = new long[1] ;
         P00KE2_A909HistorialID = new int[1] ;
         AV16Session = context.GetSession();
         AV18GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV19GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
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
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.his_solicitudeswwexportreport__datastore1(),
            new Object[][] {
                new Object[] {
               P00KE2_A916ValorNuevo, P00KE2_n916ValorNuevo, P00KE2_A915ValorAnterior, P00KE2_n915ValorAnterior, P00KE2_A914CampoModificado, P00KE2_n914CampoModificado, P00KE2_A911FechaCambio, P00KE2_A912Usuario, P00KE2_A910SolicitudesID2, P00KE2_A909HistorialID
               }
            }
         );
         Gx_date = DateTimeUtil.Today( context);
         AV49Pgmname = "HIS_SolicitudesWWExportReport";
         /* GeneXus formulas. */
         Gx_line = 0;
         Gx_date = DateTimeUtil.Today( context);
         AV49Pgmname = "HIS_SolicitudesWWExportReport";
      }

      private short nGotPars ;
      private short GxWebError ;
      private short AV14SolicitudesID2Operator ;
      private short AV11OrderedBy ;
      private int M_top ;
      private int M_bot ;
      private int Line ;
      private int ToSkip ;
      private int PrtOffset ;
      private int Gx_OldLine ;
      private int A909HistorialID ;
      private int AV66GXV1 ;
      private long AV15SolicitudesID2 ;
      private long AV20TFSolicitudesID2 ;
      private long AV21TFSolicitudesID2_To ;
      private long AV53His_solicitudeswwds_1_solicitudesid2 ;
      private long AV54His_solicitudeswwds_2_tfsolicitudesid2 ;
      private long AV55His_solicitudeswwds_3_tfsolicitudesid2_to ;
      private long A910SolicitudesID2 ;
      private string GXKey ;
      private string gxfirstwebparm ;
      private string AV49Pgmname ;
      private string GXEncryptionTmp ;
      private DateTime AV24TFFechaCambio ;
      private DateTime AV25TFFechaCambio_To ;
      private DateTime AV58His_solicitudeswwds_6_tffechacambio ;
      private DateTime AV59His_solicitudeswwds_7_tffechacambio_to ;
      private DateTime A911FechaCambio ;
      private DateTime Gx_date ;
      private bool entryPointCalled ;
      private bool AV8IsAuthorized ;
      private bool GXt_boolean1 ;
      private bool returnInSub ;
      private bool AV36TempBoolean ;
      private bool AV12OrderedDsc ;
      private bool n916ValorNuevo ;
      private bool n915ValorAnterior ;
      private bool n914CampoModificado ;
      private string AV47Title ;
      private string AV13FilterSolicitudesID2Description ;
      private string AV34TFSolicitudesID2_To_Description ;
      private string AV23TFUsuario_Sel ;
      private string AV22TFUsuario ;
      private string AV35TFFechaCambio_To_Description ;
      private string AV29TFCampoModificado_Sel ;
      private string AV28TFCampoModificado ;
      private string AV31TFValorAnterior_Sel ;
      private string AV30TFValorAnterior ;
      private string AV33TFValorNuevo_Sel ;
      private string AV32TFValorNuevo ;
      private string AV56His_solicitudeswwds_4_tfusuario ;
      private string AV57His_solicitudeswwds_5_tfusuario_sel ;
      private string AV60His_solicitudeswwds_8_tfcampomodificado ;
      private string AV61His_solicitudeswwds_9_tfcampomodificado_sel ;
      private string AV62His_solicitudeswwds_10_tfvaloranterior ;
      private string AV63His_solicitudeswwds_11_tfvaloranterior_sel ;
      private string AV64His_solicitudeswwds_12_tfvalornuevo ;
      private string AV65His_solicitudeswwds_13_tfvalornuevo_sel ;
      private string lV56His_solicitudeswwds_4_tfusuario ;
      private string lV60His_solicitudeswwds_8_tfcampomodificado ;
      private string lV62His_solicitudeswwds_10_tfvaloranterior ;
      private string lV64His_solicitudeswwds_12_tfvalornuevo ;
      private string A912Usuario ;
      private string A914CampoModificado ;
      private string A915ValorAnterior ;
      private string A916ValorNuevo ;
      private string AV45PageInfo ;
      private string AV42DateInfo ;
      private string AV40AppName ;
      private string AV46Phone ;
      private string AV44Mail ;
      private string AV48Website ;
      private string AV37AddressLine1 ;
      private string AV38AddressLine2 ;
      private string AV39AddressLine3 ;
      private IGxSession AV16Session ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private IDataStoreProvider pr_datastore1 ;
      private string[] P00KE2_A916ValorNuevo ;
      private bool[] P00KE2_n916ValorNuevo ;
      private string[] P00KE2_A915ValorAnterior ;
      private bool[] P00KE2_n915ValorAnterior ;
      private string[] P00KE2_A914CampoModificado ;
      private bool[] P00KE2_n914CampoModificado ;
      private DateTime[] P00KE2_A911FechaCambio ;
      private string[] P00KE2_A912Usuario ;
      private long[] P00KE2_A910SolicitudesID2 ;
      private int[] P00KE2_A909HistorialID ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV18GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV19GridStateFilterValue ;
   }

   public class his_solicitudeswwexportreport__datastore1 : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00KE2( IGxContext context ,
                                             short AV14SolicitudesID2Operator ,
                                             long AV53His_solicitudeswwds_1_solicitudesid2 ,
                                             long AV54His_solicitudeswwds_2_tfsolicitudesid2 ,
                                             long AV55His_solicitudeswwds_3_tfsolicitudesid2_to ,
                                             string AV57His_solicitudeswwds_5_tfusuario_sel ,
                                             string AV56His_solicitudeswwds_4_tfusuario ,
                                             DateTime AV58His_solicitudeswwds_6_tffechacambio ,
                                             DateTime AV59His_solicitudeswwds_7_tffechacambio_to ,
                                             string AV61His_solicitudeswwds_9_tfcampomodificado_sel ,
                                             string AV60His_solicitudeswwds_8_tfcampomodificado ,
                                             string AV63His_solicitudeswwds_11_tfvaloranterior_sel ,
                                             string AV62His_solicitudeswwds_10_tfvaloranterior ,
                                             string AV65His_solicitudeswwds_13_tfvalornuevo_sel ,
                                             string AV64His_solicitudeswwds_12_tfvalornuevo ,
                                             long A910SolicitudesID2 ,
                                             string A912Usuario ,
                                             DateTime A911FechaCambio ,
                                             string A914CampoModificado ,
                                             string A915ValorAnterior ,
                                             string A916ValorNuevo ,
                                             short AV11OrderedBy ,
                                             bool AV12OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int2 = new short[13];
         Object[] GXv_Object3 = new Object[2];
         scmdbuf = "SELECT [ValorNuevo], [ValorAnterior], [CampoModificado], [FechaCambio], [Usuario], [SolicitudesID], [HistorialID] FROM dbo.[HIS_Solicitudes]";
         if ( ( AV14SolicitudesID2Operator == 0 ) && ( ! (0==AV53His_solicitudeswwds_1_solicitudesid2) ) )
         {
            AddWhere(sWhereString, "([SolicitudesID] = @AV53His_solicitudeswwds_1_solicitudesid2)");
         }
         else
         {
            GXv_int2[0] = 1;
         }
         if ( ! (0==AV54His_solicitudeswwds_2_tfsolicitudesid2) )
         {
            AddWhere(sWhereString, "([SolicitudesID] >= @AV54His_solicitudeswwds_2_tfsolicitudesid2)");
         }
         else
         {
            GXv_int2[1] = 1;
         }
         if ( ! (0==AV55His_solicitudeswwds_3_tfsolicitudesid2_to) )
         {
            AddWhere(sWhereString, "([SolicitudesID] <= @AV55His_solicitudeswwds_3_tfsolicitudesid2_to)");
         }
         else
         {
            GXv_int2[2] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV57His_solicitudeswwds_5_tfusuario_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV56His_solicitudeswwds_4_tfusuario)) ) )
         {
            AddWhere(sWhereString, "(UPPER([Usuario]) like UPPER(@lV56His_solicitudeswwds_4_tfusuario))");
         }
         else
         {
            GXv_int2[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57His_solicitudeswwds_5_tfusuario_sel)) && ! ( StringUtil.StrCmp(AV57His_solicitudeswwds_5_tfusuario_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([Usuario] = @AV57His_solicitudeswwds_5_tfusuario_sel)");
         }
         else
         {
            GXv_int2[4] = 1;
         }
         if ( StringUtil.StrCmp(AV57His_solicitudeswwds_5_tfusuario_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([Usuario] = ''))");
         }
         if ( ! (DateTime.MinValue==AV58His_solicitudeswwds_6_tffechacambio) )
         {
            AddWhere(sWhereString, "([FechaCambio] >= @AV58His_solicitudeswwds_6_tffechacambio)");
         }
         else
         {
            GXv_int2[5] = 1;
         }
         if ( ! (DateTime.MinValue==AV59His_solicitudeswwds_7_tffechacambio_to) )
         {
            AddWhere(sWhereString, "([FechaCambio] <= @AV59His_solicitudeswwds_7_tffechacambio_to)");
         }
         else
         {
            GXv_int2[6] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV61His_solicitudeswwds_9_tfcampomodificado_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60His_solicitudeswwds_8_tfcampomodificado)) ) )
         {
            AddWhere(sWhereString, "(UPPER([CampoModificado]) like UPPER(@lV60His_solicitudeswwds_8_tfcampomodificado))");
         }
         else
         {
            GXv_int2[7] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61His_solicitudeswwds_9_tfcampomodificado_sel)) && ! ( StringUtil.StrCmp(AV61His_solicitudeswwds_9_tfcampomodificado_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([CampoModificado] = @AV61His_solicitudeswwds_9_tfcampomodificado_sel)");
         }
         else
         {
            GXv_int2[8] = 1;
         }
         if ( StringUtil.StrCmp(AV61His_solicitudeswwds_9_tfcampomodificado_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "([CampoModificado] IS NULL or ([CampoModificado] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV63His_solicitudeswwds_11_tfvaloranterior_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62His_solicitudeswwds_10_tfvaloranterior)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ValorAnterior]) like UPPER(@lV62His_solicitudeswwds_10_tfvaloranterior))");
         }
         else
         {
            GXv_int2[9] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63His_solicitudeswwds_11_tfvaloranterior_sel)) && ! ( StringUtil.StrCmp(AV63His_solicitudeswwds_11_tfvaloranterior_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([ValorAnterior] = @AV63His_solicitudeswwds_11_tfvaloranterior_sel)");
         }
         else
         {
            GXv_int2[10] = 1;
         }
         if ( StringUtil.StrCmp(AV63His_solicitudeswwds_11_tfvaloranterior_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "([ValorAnterior] IS NULL or ([ValorAnterior] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV65His_solicitudeswwds_13_tfvalornuevo_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64His_solicitudeswwds_12_tfvalornuevo)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ValorNuevo]) like UPPER(@lV64His_solicitudeswwds_12_tfvalornuevo))");
         }
         else
         {
            GXv_int2[11] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65His_solicitudeswwds_13_tfvalornuevo_sel)) && ! ( StringUtil.StrCmp(AV65His_solicitudeswwds_13_tfvalornuevo_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([ValorNuevo] = @AV65His_solicitudeswwds_13_tfvalornuevo_sel)");
         }
         else
         {
            GXv_int2[12] = 1;
         }
         if ( StringUtil.StrCmp(AV65His_solicitudeswwds_13_tfvalornuevo_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "([ValorNuevo] IS NULL or ([ValorNuevo] = ''))");
         }
         scmdbuf += sWhereString;
         if ( ( AV11OrderedBy == 1 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY [SolicitudesID]";
         }
         else if ( ( AV11OrderedBy == 1 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [SolicitudesID] DESC";
         }
         else if ( ( AV11OrderedBy == 2 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY [Usuario]";
         }
         else if ( ( AV11OrderedBy == 2 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [Usuario] DESC";
         }
         else if ( ( AV11OrderedBy == 3 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY [FechaCambio]";
         }
         else if ( ( AV11OrderedBy == 3 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [FechaCambio] DESC";
         }
         else if ( ( AV11OrderedBy == 4 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY [CampoModificado]";
         }
         else if ( ( AV11OrderedBy == 4 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [CampoModificado] DESC";
         }
         else if ( ( AV11OrderedBy == 5 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY [ValorAnterior]";
         }
         else if ( ( AV11OrderedBy == 5 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [ValorAnterior] DESC";
         }
         else if ( ( AV11OrderedBy == 6 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY [ValorNuevo]";
         }
         else if ( ( AV11OrderedBy == 6 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [ValorNuevo] DESC";
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
                     return conditional_P00KE2(context, (short)dynConstraints[0] , (long)dynConstraints[1] , (long)dynConstraints[2] , (long)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (DateTime)dynConstraints[6] , (DateTime)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (long)dynConstraints[14] , (string)dynConstraints[15] , (DateTime)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (short)dynConstraints[20] , (bool)dynConstraints[21] );
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
          Object[] prmP00KE2;
          prmP00KE2 = new Object[] {
          new ParDef("@AV53His_solicitudeswwds_1_solicitudesid2",GXType.Decimal,18,0) ,
          new ParDef("@AV54His_solicitudeswwds_2_tfsolicitudesid2",GXType.Decimal,18,0) ,
          new ParDef("@AV55His_solicitudeswwds_3_tfsolicitudesid2_to",GXType.Decimal,18,0) ,
          new ParDef("@lV56His_solicitudeswwds_4_tfusuario",GXType.VarChar,100,0) ,
          new ParDef("@AV57His_solicitudeswwds_5_tfusuario_sel",GXType.NVarChar,100,0) ,
          new ParDef("@AV58His_solicitudeswwds_6_tffechacambio",GXType.DateTime,10,8) ,
          new ParDef("@AV59His_solicitudeswwds_7_tffechacambio_to",GXType.DateTime,10,8) ,
          new ParDef("@lV60His_solicitudeswwds_8_tfcampomodificado",GXType.VarChar,100,0) ,
          new ParDef("@AV61His_solicitudeswwds_9_tfcampomodificado_sel",GXType.NVarChar,100,0) ,
          new ParDef("@lV62His_solicitudeswwds_10_tfvaloranterior",GXType.VarChar,500,0) ,
          new ParDef("@AV63His_solicitudeswwds_11_tfvaloranterior_sel",GXType.NVarChar,500,0) ,
          new ParDef("@lV64His_solicitudeswwds_12_tfvalornuevo",GXType.VarChar,500,0) ,
          new ParDef("@AV65His_solicitudeswwds_13_tfvalornuevo_sel",GXType.NVarChar,500,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00KE2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00KE2,100, GxCacheFrequency.OFF ,true,false )
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
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getVarchar(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((string[]) buf[4])[0] = rslt.getVarchar(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((DateTime[]) buf[6])[0] = rslt.getGXDateTime(4);
                ((string[]) buf[7])[0] = rslt.getVarchar(5);
                ((long[]) buf[8])[0] = rslt.getLong(6);
                ((int[]) buf[9])[0] = rslt.getInt(7);
                return;
       }
    }

    public override string getDataStoreName( )
    {
       return "DATASTORE1";
    }

 }

}

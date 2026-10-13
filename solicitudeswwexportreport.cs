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
   public class solicitudeswwexportreport : GXWebProcedure, System.Web.SessionState.IRequiresSessionState
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

      public solicitudeswwexportreport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public solicitudeswwexportreport( IGxContext context )
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
         setOutputFileName("SolicitudesWWExportReport");
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
            new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWSolicitudes", out  GXt_boolean1) ;
            AV8IsAuthorized = GXt_boolean1;
            if ( ! AV8IsAuthorized )
            {
               GXKey = Crypto.GetSiteKey( );
               GXEncryptionTmp = "wwpbaseobjects.notauthorized.aspx"+UrlEncode(StringUtil.RTrim(AV198Pgmname));
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
               AV120Title = context.GetMessage( "Lista de Solicitudes", "");
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
            HAS0( true, 0) ;
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
            HAS0( false, 19) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("", 25, Gx_line+0, 167, Gx_line+14, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV13FilterFullText, "")), 167, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+19);
         }
         if ( ! ( (0==AV47TFSolicitudesID) && (0==AV48TFSolicitudesID_To) ) )
         {
            HAS0( false, 19) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Solicitud", ""), 25, Gx_line+0, 167, Gx_line+14, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV47TFSolicitudesID), "ZZZZZZZZZZZZZZZZZ9")), 167, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+19);
            AV95TFSolicitudesID_To_Description = StringUtil.Format( "%1 (%2)", context.GetMessage( "Solicitud", ""), context.GetMessage( "WWP_TSTo", ""), "", "", "", "", "", "", "");
            HAS0( false, 19) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV95TFSolicitudesID_To_Description, "")), 25, Gx_line+0, 167, Gx_line+14, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV48TFSolicitudesID_To), "ZZZZZZZZZZZZZZZZZ9")), 167, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+19);
         }
         if ( ! (0==AV141TFProveedorID_Sel) )
         {
            HAS0( false, 19) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Comercio", ""), 25, Gx_line+0, 167, Gx_line+14, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV141TFProveedorID_Sel), "ZZZZZZZZZZZZZZZZZ9")), 167, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+19);
         }
         else
         {
            if ( ! ( (0==AV122TFProveedorID) && (0==AV123TFProveedorID_To) ) )
            {
               HAS0( false, 19) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(context.GetMessage( "Comercio", ""), 25, Gx_line+0, 167, Gx_line+14, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV122TFProveedorID), "ZZZZZZZZZZZZZZZZZ9")), 167, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+19);
               AV128TFProveedorID_To_Description = StringUtil.Format( "%1 (%2)", context.GetMessage( "Comercio", ""), context.GetMessage( "WWP_TSTo", ""), "", "", "", "", "", "", "");
               HAS0( false, 19) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV128TFProveedorID_To_Description, "")), 25, Gx_line+0, 167, Gx_line+14, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV123TFProveedorID_To), "ZZZZZZZZZZZZZZZZZ9")), 167, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+19);
            }
         }
         if ( ! ( (DateTime.MinValue==AV93TFSolicitudesFechaInstalacion) && (DateTime.MinValue==AV94TFSolicitudesFechaInstalacion_To) ) )
         {
            HAS0( false, 19) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Trabajo", ""), 25, Gx_line+0, 167, Gx_line+14, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.localUtil.Format( AV93TFSolicitudesFechaInstalacion, "99/99/99"), 167, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+19);
            AV108TFSolicitudesFechaInstalacion_To_Description = StringUtil.Format( "%1 (%2)", context.GetMessage( "Trabajo", ""), context.GetMessage( "WWP_TSTo", ""), "", "", "", "", "", "", "");
            HAS0( false, 19) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV108TFSolicitudesFechaInstalacion_To_Description, "")), 25, Gx_line+0, 167, Gx_line+14, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.localUtil.Format( AV94TFSolicitudesFechaInstalacion_To, "99/99/99"), 167, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+19);
         }
         if ( ! ( (DateTime.MinValue==AV89TFSolicitudesFechaAlta) && (DateTime.MinValue==AV90TFSolicitudesFechaAlta_To) ) )
         {
            HAS0( false, 19) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Fecha de Alta", ""), 25, Gx_line+0, 167, Gx_line+14, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.localUtil.Format( AV89TFSolicitudesFechaAlta, "99/99/9999"), 167, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+19);
            AV106TFSolicitudesFechaAlta_To_Description = StringUtil.Format( "%1 (%2)", context.GetMessage( "Fecha de Alta", ""), context.GetMessage( "WWP_TSTo", ""), "", "", "", "", "", "", "");
            HAS0( false, 19) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV106TFSolicitudesFechaAlta_To_Description, "")), 25, Gx_line+0, 167, Gx_line+14, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.localUtil.Format( AV90TFSolicitudesFechaAlta_To, "99/99/9999"), 167, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+19);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV181TFDepartamentoMunicipioNombre_Sel)) )
         {
            AV109TempBoolean = (bool)(((StringUtil.StrCmp(AV181TFDepartamentoMunicipioNombre_Sel, "<#Empty#>")==0)));
            AV181TFDepartamentoMunicipioNombre_Sel = (AV109TempBoolean ? context.GetMessage( "WWP_TitleFilter_EmptyOption", "") : AV181TFDepartamentoMunicipioNombre_Sel);
            HAS0( false, 19) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Municipio", ""), 25, Gx_line+0, 167, Gx_line+14, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV181TFDepartamentoMunicipioNombre_Sel, "")), 167, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+19);
            AV181TFDepartamentoMunicipioNombre_Sel = (AV109TempBoolean ? "<#Empty#>" : AV181TFDepartamentoMunicipioNombre_Sel);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV180TFDepartamentoMunicipioNombre)) )
            {
               HAS0( false, 19) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(context.GetMessage( "Municipio", ""), 25, Gx_line+0, 167, Gx_line+14, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV180TFDepartamentoMunicipioNombre, "")), 167, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+19);
            }
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV183TFZonasNombre_Sel)) )
         {
            AV109TempBoolean = (bool)(((StringUtil.StrCmp(AV183TFZonasNombre_Sel, "<#Empty#>")==0)));
            AV183TFZonasNombre_Sel = (AV109TempBoolean ? context.GetMessage( "WWP_TitleFilter_EmptyOption", "") : AV183TFZonasNombre_Sel);
            HAS0( false, 19) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Zona", ""), 25, Gx_line+0, 167, Gx_line+14, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV183TFZonasNombre_Sel, "")), 167, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+19);
            AV183TFZonasNombre_Sel = (AV109TempBoolean ? "<#Empty#>" : AV183TFZonasNombre_Sel);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV182TFZonasNombre)) )
            {
               HAS0( false, 19) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(context.GetMessage( "Zona", ""), 25, Gx_line+0, 167, Gx_line+14, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV182TFZonasNombre, "")), 167, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+19);
            }
         }
         if ( ! ( (Convert.ToDecimal(0)==AV72TFSolicitudServicioPFinal) && (Convert.ToDecimal(0)==AV73TFSolicitudServicioPFinal_To) ) )
         {
            HAS0( false, 19) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Total", ""), 25, Gx_line+0, 167, Gx_line+14, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV72TFSolicitudServicioPFinal, "ZZZZZZ,ZZZ,ZZZ,ZZ9.99")), 167, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+19);
            AV102TFSolicitudServicioPFinal_To_Description = StringUtil.Format( "%1 (%2)", context.GetMessage( "Total", ""), context.GetMessage( "WWP_TSTo", ""), "", "", "", "", "", "", "");
            HAS0( false, 19) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV102TFSolicitudServicioPFinal_To_Description, "")), 25, Gx_line+0, 167, Gx_line+14, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV73TFSolicitudServicioPFinal_To, "ZZZZZZ,ZZZ,ZZZ,ZZ9.99")), 167, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+19);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV151TFSolicitudesComentario_Sel)) )
         {
            AV109TempBoolean = (bool)(((StringUtil.StrCmp(AV151TFSolicitudesComentario_Sel, "<#Empty#>")==0)));
            AV151TFSolicitudesComentario_Sel = (AV109TempBoolean ? context.GetMessage( "WWP_TitleFilter_EmptyOption", "") : AV151TFSolicitudesComentario_Sel);
            HAS0( false, 19) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Comentario", ""), 25, Gx_line+0, 167, Gx_line+14, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV151TFSolicitudesComentario_Sel, "")), 167, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+19);
            AV151TFSolicitudesComentario_Sel = (AV109TempBoolean ? "<#Empty#>" : AV151TFSolicitudesComentario_Sel);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV150TFSolicitudesComentario)) )
            {
               HAS0( false, 19) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(context.GetMessage( "Comentario", ""), 25, Gx_line+0, 167, Gx_line+14, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV150TFSolicitudesComentario, "")), 167, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+19);
            }
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV145TFProveedorNombreAux_Sel)) )
         {
            AV109TempBoolean = (bool)(((StringUtil.StrCmp(AV145TFProveedorNombreAux_Sel, "<#Empty#>")==0)));
            AV145TFProveedorNombreAux_Sel = (AV109TempBoolean ? context.GetMessage( "WWP_TitleFilter_EmptyOption", "") : AV145TFProveedorNombreAux_Sel);
            HAS0( false, 19) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Comercio Auxiliar", ""), 25, Gx_line+0, 167, Gx_line+14, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV145TFProveedorNombreAux_Sel, "")), 167, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+19);
            AV145TFProveedorNombreAux_Sel = (AV109TempBoolean ? "<#Empty#>" : AV145TFProveedorNombreAux_Sel);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV144TFProveedorNombreAux)) )
            {
               HAS0( false, 19) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(context.GetMessage( "Comercio Auxiliar", ""), 25, Gx_line+0, 167, Gx_line+14, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV144TFProveedorNombreAux, "")), 167, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+19);
            }
         }
         AV156TFSolicitudesPagado_Sels.FromJSonString(AV154TFSolicitudesPagado_SelsJson, null);
         if ( ! ( AV156TFSolicitudesPagado_Sels.Count == 0 ) )
         {
            AV159i = 1;
            AV201GXV1 = 1;
            while ( AV201GXV1 <= AV156TFSolicitudesPagado_Sels.Count )
            {
               AV157TFSolicitudesPagado_Sel = AV156TFSolicitudesPagado_Sels.GetString(AV201GXV1);
               if ( AV159i == 1 )
               {
                  AV155TFSolicitudesPagado_SelDscs = "";
               }
               else
               {
                  AV155TFSolicitudesPagado_SelDscs += ", ";
               }
               AV158FilterTFSolicitudesPagado_SelValueDescription = "";
               if ( StringUtil.StrCmp(StringUtil.Trim( AV157TFSolicitudesPagado_Sel), "S") == 0 )
               {
                  AV158FilterTFSolicitudesPagado_SelValueDescription = context.GetMessage( "Pagado", "");
               }
               else if ( StringUtil.StrCmp(StringUtil.Trim( AV157TFSolicitudesPagado_Sel), "N") == 0 )
               {
                  AV158FilterTFSolicitudesPagado_SelValueDescription = context.GetMessage( "Pendiente de Pago", "");
               }
               AV155TFSolicitudesPagado_SelDscs += AV158FilterTFSolicitudesPagado_SelValueDescription;
               AV159i = (long)(AV159i+1);
               AV201GXV1 = (int)(AV201GXV1+1);
            }
            HAS0( false, 19) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Pagado", ""), 25, Gx_line+0, 167, Gx_line+14, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV155TFSolicitudesPagado_SelDscs, "")), 167, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+19);
         }
         AV163TFSolicitudServicioOrigenPago_Sels.FromJSonString(AV161TFSolicitudServicioOrigenPago_SelsJson, null);
         if ( ! ( AV163TFSolicitudServicioOrigenPago_Sels.Count == 0 ) )
         {
            AV159i = 1;
            AV202GXV2 = 1;
            while ( AV202GXV2 <= AV163TFSolicitudServicioOrigenPago_Sels.Count )
            {
               AV164TFSolicitudServicioOrigenPago_Sel = AV163TFSolicitudServicioOrigenPago_Sels.GetString(AV202GXV2);
               if ( AV159i == 1 )
               {
                  AV162TFSolicitudServicioOrigenPago_SelDscs = "";
               }
               else
               {
                  AV162TFSolicitudServicioOrigenPago_SelDscs += ", ";
               }
               AV165FilterTFSolicitudServicioOrigenPago_SelValueDescription = context.GetMessage( gxdomainorigenpago.getDescription(context,AV164TFSolicitudServicioOrigenPago_Sel), "");
               AV162TFSolicitudServicioOrigenPago_SelDscs += AV165FilterTFSolicitudServicioOrigenPago_SelValueDescription;
               AV159i = (long)(AV159i+1);
               AV202GXV2 = (int)(AV202GXV2+1);
            }
            HAS0( false, 19) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Origen", ""), 25, Gx_line+0, 167, Gx_line+14, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV162TFSolicitudServicioOrigenPago_SelDscs, "")), 167, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+19);
         }
         AV171TFSolicitudesSubTipo_Sels.FromJSonString(AV168TFSolicitudesSubTipo_SelsJson, null);
         if ( ! ( AV171TFSolicitudesSubTipo_Sels.Count == 0 ) )
         {
            AV159i = 1;
            AV203GXV3 = 1;
            while ( AV203GXV3 <= AV171TFSolicitudesSubTipo_Sels.Count )
            {
               AV170TFSolicitudesSubTipo_Sel = AV171TFSolicitudesSubTipo_Sels.GetString(AV203GXV3);
               if ( AV159i == 1 )
               {
                  AV169TFSolicitudesSubTipo_SelDscs = "";
               }
               else
               {
                  AV169TFSolicitudesSubTipo_SelDscs += ", ";
               }
               AV172FilterTFSolicitudesSubTipo_SelValueDescription = context.GetMessage( gxdomainsolicitudsubtipo.getDescription(context,AV170TFSolicitudesSubTipo_Sel), "");
               AV169TFSolicitudesSubTipo_SelDscs += AV172FilterTFSolicitudesSubTipo_SelValueDescription;
               AV159i = (long)(AV159i+1);
               AV203GXV3 = (int)(AV203GXV3+1);
            }
            HAS0( false, 19) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Sub Tipo", ""), 25, Gx_line+0, 167, Gx_line+14, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV169TFSolicitudesSubTipo_SelDscs, "")), 167, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+19);
         }
         if ( ! ( (0==AV195TFMudanzaId) && (0==AV196TFMudanzaId_To) ) )
         {
            HAS0( false, 19) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Mudanza Id", ""), 25, Gx_line+0, 167, Gx_line+14, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV195TFMudanzaId), "ZZZZZZZZZZZZZZZZZ9")), 167, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+19);
            AV197TFMudanzaId_To_Description = StringUtil.Format( "%1 (%2)", context.GetMessage( "Mudanza Id", ""), context.GetMessage( "WWP_TSTo", ""), "", "", "", "", "", "", "");
            HAS0( false, 19) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV197TFMudanzaId_To_Description, "")), 25, Gx_line+0, 167, Gx_line+14, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV196TFMudanzaId_To), "ZZZZZZZZZZZZZZZZZ9")), 167, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+19);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV188TFSTComerciosNombre_Sel)) )
         {
            AV109TempBoolean = (bool)(((StringUtil.StrCmp(AV188TFSTComerciosNombre_Sel, "<#Empty#>")==0)));
            AV188TFSTComerciosNombre_Sel = (AV109TempBoolean ? context.GetMessage( "WWP_TitleFilter_EmptyOption", "") : AV188TFSTComerciosNombre_Sel);
            HAS0( false, 19) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Convenio Comercio", ""), 25, Gx_line+0, 167, Gx_line+14, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV188TFSTComerciosNombre_Sel, "")), 167, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+19);
            AV188TFSTComerciosNombre_Sel = (AV109TempBoolean ? "<#Empty#>" : AV188TFSTComerciosNombre_Sel);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV187TFSTComerciosNombre)) )
            {
               HAS0( false, 19) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(context.GetMessage( "Convenio Comercio", ""), 25, Gx_line+0, 167, Gx_line+14, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV187TFSTComerciosNombre, "")), 167, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+19);
            }
         }
         if ( ! ( (0==AV189TFSolicitudesDuplicado) && (0==AV190TFSolicitudesDuplicado_To) ) )
         {
            HAS0( false, 19) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Duplicado (código)", ""), 25, Gx_line+0, 167, Gx_line+14, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV189TFSolicitudesDuplicado), "ZZZZZZZZZZZZZZZZZ9")), 167, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+19);
            AV191TFSolicitudesDuplicado_To_Description = StringUtil.Format( "%1 (%2)", context.GetMessage( "Duplicado (código)", ""), context.GetMessage( "WWP_TSTo", ""), "", "", "", "", "", "", "");
            HAS0( false, 19) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV191TFSolicitudesDuplicado_To_Description, "")), 25, Gx_line+0, 167, Gx_line+14, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV190TFSolicitudesDuplicado_To), "ZZZZZZZZZZZZZZZZZ9")), 167, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+19);
         }
         if ( ! ( (0==AV192TFPostulacionesId) && (0==AV193TFPostulacionesId_To) ) )
         {
            HAS0( false, 19) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Postulaciones Id", ""), 25, Gx_line+0, 167, Gx_line+14, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV192TFPostulacionesId), "ZZZZZZZZZZZZZZZZZ9")), 167, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+19);
            AV194TFPostulacionesId_To_Description = StringUtil.Format( "%1 (%2)", context.GetMessage( "Postulaciones Id", ""), context.GetMessage( "WWP_TSTo", ""), "", "", "", "", "", "", "");
            HAS0( false, 19) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV194TFPostulacionesId_To_Description, "")), 25, Gx_line+0, 167, Gx_line+14, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV193TFPostulacionesId_To), "ZZZZZZZZZZZZZZZZZ9")), 167, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+19);
         }
      }

      protected void S121( )
      {
         /* 'PRINTCOLUMNTITLES' Routine */
         returnInSub = false;
         HAS0( false, 22) ;
         getPrinter().GxDrawLine(25, Gx_line+21, 789, Gx_line+21, 2, 8, 160, 134, 0) ;
         Gx_OldLine = Gx_line;
         Gx_line = (int)(Gx_line+22);
         HAS0( false, 36) ;
         getPrinter().GxAttris("Microsoft Sans Serif", 9, false, false, false, false, 0, 8, 160, 134, 0, 255, 255, 255) ;
         getPrinter().GxDrawText(context.GetMessage( "Solicitud", ""), 30, Gx_line+10, 57, Gx_line+26, 2, 0, 0, 0) ;
         getPrinter().GxDrawText(context.GetMessage( "Comercio", ""), 61, Gx_line+10, 88, Gx_line+26, 2, 0, 0, 0) ;
         getPrinter().GxDrawText(context.GetMessage( "Trabajo", ""), 92, Gx_line+10, 119, Gx_line+26, 0, 0, 0, 0) ;
         getPrinter().GxDrawText(context.GetMessage( "Hora", ""), 123, Gx_line+10, 150, Gx_line+26, 0, 0, 0, 0) ;
         getPrinter().GxDrawText("", 154, Gx_line+10, 181, Gx_line+26, 0, 0, 0, 0) ;
         getPrinter().GxDrawText(context.GetMessage( "Comercio", ""), 185, Gx_line+10, 212, Gx_line+26, 0, 0, 0, 0) ;
         getPrinter().GxDrawText(context.GetMessage( "Contacto", ""), 216, Gx_line+10, 243, Gx_line+26, 0, 0, 0, 0) ;
         getPrinter().GxDrawText(context.GetMessage( "Teléfono", ""), 247, Gx_line+10, 274, Gx_line+26, 0, 0, 0, 0) ;
         getPrinter().GxDrawText(context.GetMessage( "Fecha de Alta", ""), 278, Gx_line+10, 305, Gx_line+26, 0, 0, 0, 0) ;
         getPrinter().GxDrawText(context.GetMessage( "Departamento", ""), 309, Gx_line+10, 336, Gx_line+26, 0, 0, 0, 0) ;
         getPrinter().GxDrawText(context.GetMessage( "Municipio", ""), 340, Gx_line+10, 367, Gx_line+26, 0, 0, 0, 0) ;
         getPrinter().GxDrawText(context.GetMessage( "Zona", ""), 371, Gx_line+10, 398, Gx_line+26, 0, 0, 0, 0) ;
         getPrinter().GxDrawText(context.GetMessage( "Dirección", ""), 402, Gx_line+10, 429, Gx_line+26, 0, 0, 0, 0) ;
         getPrinter().GxDrawText(context.GetMessage( "Total", ""), 433, Gx_line+10, 461, Gx_line+26, 2, 0, 0, 0) ;
         getPrinter().GxDrawText(context.GetMessage( "Comentario", ""), 465, Gx_line+10, 494, Gx_line+26, 0, 0, 0, 0) ;
         getPrinter().GxDrawText(context.GetMessage( "Solicitó Cotización?", ""), 498, Gx_line+10, 526, Gx_line+26, 0, 0, 0, 0) ;
         getPrinter().GxDrawText(context.GetMessage( "Comercio Auxiliar", ""), 530, Gx_line+10, 559, Gx_line+26, 0, 0, 0, 0) ;
         getPrinter().GxDrawText(context.GetMessage( "Pagado", ""), 563, Gx_line+10, 592, Gx_line+26, 0, 0, 0, 0) ;
         getPrinter().GxDrawText(context.GetMessage( "Origen", ""), 596, Gx_line+10, 625, Gx_line+26, 0, 0, 0, 0) ;
         getPrinter().GxDrawText(context.GetMessage( "Sub Tipo", ""), 629, Gx_line+10, 658, Gx_line+26, 0, 0, 0, 0) ;
         getPrinter().GxDrawText(context.GetMessage( "Mudanza Id", ""), 662, Gx_line+10, 690, Gx_line+26, 2, 0, 0, 0) ;
         getPrinter().GxDrawText(context.GetMessage( "Convenio Comercio", ""), 694, Gx_line+10, 723, Gx_line+26, 0, 0, 0, 0) ;
         getPrinter().GxDrawText(context.GetMessage( "Duplicado (código)", ""), 727, Gx_line+10, 755, Gx_line+26, 2, 0, 0, 0) ;
         getPrinter().GxDrawText(context.GetMessage( "Postulaciones Id", ""), 759, Gx_line+10, 787, Gx_line+26, 2, 0, 0, 0) ;
         Gx_OldLine = Gx_line;
         Gx_line = (int)(Gx_line+36);
      }

      protected void S131( )
      {
         /* 'PRINTDATA' Routine */
         returnInSub = false;
         AV205Solicitudeswwds_1_filterfulltext = AV13FilterFullText;
         AV206Solicitudeswwds_2_tfsolicitudesid = AV47TFSolicitudesID;
         AV207Solicitudeswwds_3_tfsolicitudesid_to = AV48TFSolicitudesID_To;
         AV208Solicitudeswwds_4_tfproveedorid = AV122TFProveedorID;
         AV209Solicitudeswwds_5_tfproveedorid_to = AV123TFProveedorID_To;
         AV210Solicitudeswwds_6_tfproveedorid_sel = AV141TFProveedorID_Sel;
         AV211Solicitudeswwds_7_tfsolicitudesfechainstalacion = AV93TFSolicitudesFechaInstalacion;
         AV212Solicitudeswwds_8_tfsolicitudesfechainstalacion_to = AV94TFSolicitudesFechaInstalacion_To;
         AV213Solicitudeswwds_9_tfsolicitudesfechaalta = AV89TFSolicitudesFechaAlta;
         AV214Solicitudeswwds_10_tfsolicitudesfechaalta_to = AV90TFSolicitudesFechaAlta_To;
         AV215Solicitudeswwds_11_tfdepartamentomunicipionombre = AV180TFDepartamentoMunicipioNombre;
         AV216Solicitudeswwds_12_tfdepartamentomunicipionombre_sel = AV181TFDepartamentoMunicipioNombre_Sel;
         AV217Solicitudeswwds_13_tfzonasnombre = AV182TFZonasNombre;
         AV218Solicitudeswwds_14_tfzonasnombre_sel = AV183TFZonasNombre_Sel;
         AV219Solicitudeswwds_15_tfsolicitudserviciopfinal = AV72TFSolicitudServicioPFinal;
         AV220Solicitudeswwds_16_tfsolicitudserviciopfinal_to = AV73TFSolicitudServicioPFinal_To;
         AV221Solicitudeswwds_17_tfsolicitudescomentario = AV150TFSolicitudesComentario;
         AV222Solicitudeswwds_18_tfsolicitudescomentario_sel = AV151TFSolicitudesComentario_Sel;
         AV223Solicitudeswwds_19_tfproveedornombreaux = AV144TFProveedorNombreAux;
         AV224Solicitudeswwds_20_tfproveedornombreaux_sel = AV145TFProveedorNombreAux_Sel;
         AV225Solicitudeswwds_21_tfsolicitudespagado_sels = AV156TFSolicitudesPagado_Sels;
         AV226Solicitudeswwds_22_tfsolicitudservicioorigenpago_sels = AV163TFSolicitudServicioOrigenPago_Sels;
         AV227Solicitudeswwds_23_tfsolicitudessubtipo_sels = AV171TFSolicitudesSubTipo_Sels;
         AV228Solicitudeswwds_24_tfmudanzaid = AV195TFMudanzaId;
         AV229Solicitudeswwds_25_tfmudanzaid_to = AV196TFMudanzaId_To;
         AV230Solicitudeswwds_26_tfstcomerciosnombre = AV187TFSTComerciosNombre;
         AV231Solicitudeswwds_27_tfstcomerciosnombre_sel = AV188TFSTComerciosNombre_Sel;
         AV232Solicitudeswwds_28_tfsolicitudesduplicado = AV189TFSolicitudesDuplicado;
         AV233Solicitudeswwds_29_tfsolicitudesduplicado_to = AV190TFSolicitudesDuplicado_To;
         AV234Solicitudeswwds_30_tfpostulacionesid = AV192TFPostulacionesId;
         AV235Solicitudeswwds_31_tfpostulacionesid_to = AV193TFPostulacionesId_To;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A441SolicitudesPagado ,
                                              AV225Solicitudeswwds_21_tfsolicitudespagado_sels ,
                                              A438SolicitudServicioOrigenPago ,
                                              AV226Solicitudeswwds_22_tfsolicitudservicioorigenpago_sels ,
                                              A600SolicitudesSubTipo ,
                                              AV227Solicitudeswwds_23_tfsolicitudessubtipo_sels ,
                                              A133ProveedorID ,
                                              AV176ProveedorIDCollection ,
                                              A131EstadosSolId ,
                                              AV205Solicitudeswwds_1_filterfulltext ,
                                              AV206Solicitudeswwds_2_tfsolicitudesid ,
                                              AV207Solicitudeswwds_3_tfsolicitudesid_to ,
                                              AV210Solicitudeswwds_6_tfproveedorid_sel ,
                                              AV211Solicitudeswwds_7_tfsolicitudesfechainstalacion ,
                                              AV212Solicitudeswwds_8_tfsolicitudesfechainstalacion_to ,
                                              AV213Solicitudeswwds_9_tfsolicitudesfechaalta ,
                                              AV214Solicitudeswwds_10_tfsolicitudesfechaalta_to ,
                                              AV216Solicitudeswwds_12_tfdepartamentomunicipionombre_sel ,
                                              AV215Solicitudeswwds_11_tfdepartamentomunicipionombre ,
                                              AV218Solicitudeswwds_14_tfzonasnombre_sel ,
                                              AV217Solicitudeswwds_13_tfzonasnombre ,
                                              AV222Solicitudeswwds_18_tfsolicitudescomentario_sel ,
                                              AV221Solicitudeswwds_17_tfsolicitudescomentario ,
                                              AV224Solicitudeswwds_20_tfproveedornombreaux_sel ,
                                              AV223Solicitudeswwds_19_tfproveedornombreaux ,
                                              AV225Solicitudeswwds_21_tfsolicitudespagado_sels.Count ,
                                              AV226Solicitudeswwds_22_tfsolicitudservicioorigenpago_sels.Count ,
                                              AV227Solicitudeswwds_23_tfsolicitudessubtipo_sels.Count ,
                                              AV228Solicitudeswwds_24_tfmudanzaid ,
                                              AV229Solicitudeswwds_25_tfmudanzaid_to ,
                                              AV231Solicitudeswwds_27_tfstcomerciosnombre_sel ,
                                              AV230Solicitudeswwds_26_tfstcomerciosnombre ,
                                              AV232Solicitudeswwds_28_tfsolicitudesduplicado ,
                                              AV233Solicitudeswwds_29_tfsolicitudesduplicado_to ,
                                              AV234Solicitudeswwds_30_tfpostulacionesid ,
                                              AV235Solicitudeswwds_31_tfpostulacionesid_to ,
                                              AV178MudanzaId ,
                                              AV149ProveedorID ,
                                              AV176ProveedorIDCollection.Count ,
                                              AV146EstadosGenericosID ,
                                              A127SolicitudesID ,
                                              A282ProveedorNombre ,
                                              A171SolicitudesNombre ,
                                              A172SolicitudesTelefono ,
                                              A173SolicitudesDireccion ,
                                              A203SolicitudesOtros3 ,
                                              A113DepartamentoDepartamento ,
                                              A533ProveedorNombreAux ,
                                              A205SolicitudesComentario ,
                                              A111ZonasNombre ,
                                              A115DepartamentoMunicipioNombre ,
                                              A184SolicitudesFechaInstalacion ,
                                              A182SolicitudesFechaAlta ,
                                              A735MudanzaId ,
                                              A923STComerciosNombre ,
                                              A972SolicitudesDuplicado ,
                                              A422PostulacionesId ,
                                              AV147FechaIni ,
                                              AV148FechaFin ,
                                              A737MudanzaFechaAlta ,
                                              AV11OrderedBy ,
                                              AV12OrderedDsc ,
                                              AV219Solicitudeswwds_15_tfsolicitudserviciopfinal ,
                                              A211SolicitudServicioPFinal ,
                                              AV220Solicitudeswwds_16_tfsolicitudserviciopfinal_to } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.LONG, TypeConstants.INT, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.DATE, TypeConstants.DATE,
                                              TypeConstants.DATE, TypeConstants.DATE, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG,
                                              TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.INT, TypeConstants.INT, TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.BOOLEAN,
                                              TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.SHORT,
                                              TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL
                                              }
         });
         lV205Solicitudeswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV205Solicitudeswwds_1_filterfulltext), "%", "");
         lV205Solicitudeswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV205Solicitudeswwds_1_filterfulltext), "%", "");
         lV205Solicitudeswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV205Solicitudeswwds_1_filterfulltext), "%", "");
         lV205Solicitudeswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV205Solicitudeswwds_1_filterfulltext), "%", "");
         lV205Solicitudeswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV205Solicitudeswwds_1_filterfulltext), "%", "");
         lV205Solicitudeswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV205Solicitudeswwds_1_filterfulltext), "%", "");
         lV205Solicitudeswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV205Solicitudeswwds_1_filterfulltext), "%", "");
         lV205Solicitudeswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV205Solicitudeswwds_1_filterfulltext), "%", "");
         lV205Solicitudeswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV205Solicitudeswwds_1_filterfulltext), "%", "");
         lV205Solicitudeswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV205Solicitudeswwds_1_filterfulltext), "%", "");
         lV205Solicitudeswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV205Solicitudeswwds_1_filterfulltext), "%", "");
         lV215Solicitudeswwds_11_tfdepartamentomunicipionombre = StringUtil.PadR( StringUtil.RTrim( AV215Solicitudeswwds_11_tfdepartamentomunicipionombre), 120, "%");
         lV217Solicitudeswwds_13_tfzonasnombre = StringUtil.PadR( StringUtil.RTrim( AV217Solicitudeswwds_13_tfzonasnombre), 120, "%");
         lV221Solicitudeswwds_17_tfsolicitudescomentario = StringUtil.Concat( StringUtil.RTrim( AV221Solicitudeswwds_17_tfsolicitudescomentario), "%", "");
         lV223Solicitudeswwds_19_tfproveedornombreaux = StringUtil.PadR( StringUtil.RTrim( AV223Solicitudeswwds_19_tfproveedornombreaux), 80, "%");
         lV230Solicitudeswwds_26_tfstcomerciosnombre = StringUtil.PadR( StringUtil.RTrim( AV230Solicitudeswwds_26_tfstcomerciosnombre), 80, "%");
         /* Using cursor P00AS2 */
         pr_default.execute(0, new Object[] {lV205Solicitudeswwds_1_filterfulltext, lV205Solicitudeswwds_1_filterfulltext, lV205Solicitudeswwds_1_filterfulltext, lV205Solicitudeswwds_1_filterfulltext, lV205Solicitudeswwds_1_filterfulltext, lV205Solicitudeswwds_1_filterfulltext, lV205Solicitudeswwds_1_filterfulltext, lV205Solicitudeswwds_1_filterfulltext, lV205Solicitudeswwds_1_filterfulltext, lV205Solicitudeswwds_1_filterfulltext, lV205Solicitudeswwds_1_filterfulltext, AV206Solicitudeswwds_2_tfsolicitudesid, AV207Solicitudeswwds_3_tfsolicitudesid_to, AV210Solicitudeswwds_6_tfproveedorid_sel, AV211Solicitudeswwds_7_tfsolicitudesfechainstalacion, AV212Solicitudeswwds_8_tfsolicitudesfechainstalacion_to, AV213Solicitudeswwds_9_tfsolicitudesfechaalta, AV214Solicitudeswwds_10_tfsolicitudesfechaalta_to, lV215Solicitudeswwds_11_tfdepartamentomunicipionombre, AV216Solicitudeswwds_12_tfdepartamentomunicipionombre_sel, lV217Solicitudeswwds_13_tfzonasnombre, AV218Solicitudeswwds_14_tfzonasnombre_sel, lV221Solicitudeswwds_17_tfsolicitudescomentario, AV222Solicitudeswwds_18_tfsolicitudescomentario_sel, lV223Solicitudeswwds_19_tfproveedornombreaux, AV224Solicitudeswwds_20_tfproveedornombreaux_sel, AV228Solicitudeswwds_24_tfmudanzaid, AV229Solicitudeswwds_25_tfmudanzaid_to, lV230Solicitudeswwds_26_tfstcomerciosnombre, AV231Solicitudeswwds_27_tfstcomerciosnombre_sel, AV232Solicitudeswwds_28_tfsolicitudesduplicado, AV233Solicitudeswwds_29_tfsolicitudesduplicado_to, AV234Solicitudeswwds_30_tfpostulacionesid, AV235Solicitudeswwds_31_tfpostulacionesid_to, AV147FechaIni, AV148FechaFin, AV147FechaIni, AV148FechaFin, AV149ProveedorID});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A112DepartamentoId = P00AS2_A112DepartamentoId[0];
            n112DepartamentoId = P00AS2_n112DepartamentoId[0];
            A114DepartamentoMunicipioId = P00AS2_A114DepartamentoMunicipioId[0];
            n114DepartamentoMunicipioId = P00AS2_n114DepartamentoMunicipioId[0];
            A110ZonasID = P00AS2_A110ZonasID[0];
            n110ZonasID = P00AS2_n110ZonasID[0];
            A919STComerciosID = P00AS2_A919STComerciosID[0];
            n919STComerciosID = P00AS2_n919STComerciosID[0];
            A131EstadosSolId = P00AS2_A131EstadosSolId[0];
            A737MudanzaFechaAlta = P00AS2_A737MudanzaFechaAlta[0];
            A113DepartamentoDepartamento = P00AS2_A113DepartamentoDepartamento[0];
            A203SolicitudesOtros3 = P00AS2_A203SolicitudesOtros3[0];
            A173SolicitudesDireccion = P00AS2_A173SolicitudesDireccion[0];
            A172SolicitudesTelefono = P00AS2_A172SolicitudesTelefono[0];
            A171SolicitudesNombre = P00AS2_A171SolicitudesNombre[0];
            A282ProveedorNombre = P00AS2_A282ProveedorNombre[0];
            A422PostulacionesId = P00AS2_A422PostulacionesId[0];
            n422PostulacionesId = P00AS2_n422PostulacionesId[0];
            A972SolicitudesDuplicado = P00AS2_A972SolicitudesDuplicado[0];
            n972SolicitudesDuplicado = P00AS2_n972SolicitudesDuplicado[0];
            A923STComerciosNombre = P00AS2_A923STComerciosNombre[0];
            A735MudanzaId = P00AS2_A735MudanzaId[0];
            n735MudanzaId = P00AS2_n735MudanzaId[0];
            A600SolicitudesSubTipo = P00AS2_A600SolicitudesSubTipo[0];
            n600SolicitudesSubTipo = P00AS2_n600SolicitudesSubTipo[0];
            A438SolicitudServicioOrigenPago = P00AS2_A438SolicitudServicioOrigenPago[0];
            n438SolicitudServicioOrigenPago = P00AS2_n438SolicitudServicioOrigenPago[0];
            A441SolicitudesPagado = P00AS2_A441SolicitudesPagado[0];
            n441SolicitudesPagado = P00AS2_n441SolicitudesPagado[0];
            A533ProveedorNombreAux = P00AS2_A533ProveedorNombreAux[0];
            n533ProveedorNombreAux = P00AS2_n533ProveedorNombreAux[0];
            A205SolicitudesComentario = P00AS2_A205SolicitudesComentario[0];
            A111ZonasNombre = P00AS2_A111ZonasNombre[0];
            A115DepartamentoMunicipioNombre = P00AS2_A115DepartamentoMunicipioNombre[0];
            A182SolicitudesFechaAlta = P00AS2_A182SolicitudesFechaAlta[0];
            n182SolicitudesFechaAlta = P00AS2_n182SolicitudesFechaAlta[0];
            A184SolicitudesFechaInstalacion = P00AS2_A184SolicitudesFechaInstalacion[0];
            A133ProveedorID = P00AS2_A133ProveedorID[0];
            A127SolicitudesID = P00AS2_A127SolicitudesID[0];
            A183SolicitudesHoraInstalacion = P00AS2_A183SolicitudesHoraInstalacion[0];
            A210SolicitudServicioSolCoti = P00AS2_A210SolicitudServicioSolCoti[0];
            A796SolicitudesComisionMetodoPago = P00AS2_A796SolicitudesComisionMetodoPago[0];
            A212SolicitudesCotizacion = P00AS2_A212SolicitudesCotizacion[0];
            A1016SolicitudesDescuentoCupon = P00AS2_A1016SolicitudesDescuentoCupon[0];
            A897SolicitudesDescuento = P00AS2_A897SolicitudesDescuento[0];
            n897SolicitudesDescuento = P00AS2_n897SolicitudesDescuento[0];
            A864SolicitudesCostoXZona = P00AS2_A864SolicitudesCostoXZona[0];
            A113DepartamentoDepartamento = P00AS2_A113DepartamentoDepartamento[0];
            A115DepartamentoMunicipioNombre = P00AS2_A115DepartamentoMunicipioNombre[0];
            A111ZonasNombre = P00AS2_A111ZonasNombre[0];
            A923STComerciosNombre = P00AS2_A923STComerciosNombre[0];
            A737MudanzaFechaAlta = P00AS2_A737MudanzaFechaAlta[0];
            A282ProveedorNombre = P00AS2_A282ProveedorNombre[0];
            GetSolicitudesTotal( A127SolicitudesID) ;
            if ( ( A212SolicitudesCotizacion == Convert.ToDecimal( 0 )) && ( A796SolicitudesComisionMetodoPago <= Convert.ToDecimal( 0 )) )
            {
               A211SolicitudServicioPFinal = (decimal)(A174SolicitudesTotal+A864SolicitudesCostoXZona-A897SolicitudesDescuento-A1016SolicitudesDescuentoCupon);
            }
            else
            {
               if ( ( A212SolicitudesCotizacion > Convert.ToDecimal( 0 )) && ( A796SolicitudesComisionMetodoPago <= Convert.ToDecimal( 0 )) )
               {
                  A211SolicitudServicioPFinal = (decimal)(A212SolicitudesCotizacion+A864SolicitudesCostoXZona-A897SolicitudesDescuento-A1016SolicitudesDescuentoCupon);
               }
               else
               {
                  if ( ( A212SolicitudesCotizacion == Convert.ToDecimal( 0 )) && ( A796SolicitudesComisionMetodoPago > Convert.ToDecimal( 0 )) )
                  {
                     A211SolicitudServicioPFinal = (decimal)(A174SolicitudesTotal+A864SolicitudesCostoXZona-A897SolicitudesDescuento-A1016SolicitudesDescuentoCupon-A796SolicitudesComisionMetodoPago);
                  }
                  else
                  {
                     if ( ( A212SolicitudesCotizacion > Convert.ToDecimal( 0 )) && ( A796SolicitudesComisionMetodoPago > Convert.ToDecimal( 0 )) )
                     {
                        A211SolicitudServicioPFinal = (decimal)(A212SolicitudesCotizacion+A864SolicitudesCostoXZona-A796SolicitudesComisionMetodoPago-A897SolicitudesDescuento-A1016SolicitudesDescuentoCupon);
                     }
                     else
                     {
                        A211SolicitudServicioPFinal = 0;
                     }
                  }
               }
            }
            if ( (Convert.ToDecimal(0)==AV219Solicitudeswwds_15_tfsolicitudserviciopfinal) || ( ( A211SolicitudServicioPFinal >= AV219Solicitudeswwds_15_tfsolicitudserviciopfinal ) ) )
            {
               if ( (Convert.ToDecimal(0)==AV220Solicitudeswwds_16_tfsolicitudserviciopfinal_to) || ( ( A211SolicitudServicioPFinal <= AV220Solicitudeswwds_16_tfsolicitudserviciopfinal_to ) ) )
               {
                  if ( StringUtil.StrCmp(DateTimeUtil.CDow( A184SolicitudesFechaInstalacion, context.GetLanguage( )), context.GetMessage( "Sábado", "")) == 0 )
                  {
                     if ( StringUtil.StrCmp(A183SolicitudesHoraInstalacion, "1") == 0 )
                     {
                        AV184HoraInstalacion = "08 - 14";
                     }
                     if ( StringUtil.StrCmp(A183SolicitudesHoraInstalacion, "2") == 0 )
                     {
                        AV184HoraInstalacion = "14 - 20";
                     }
                  }
                  else
                  {
                     if ( StringUtil.StrCmp(A183SolicitudesHoraInstalacion, "1") == 0 )
                     {
                        AV184HoraInstalacion = "08 - 12";
                     }
                     if ( StringUtil.StrCmp(A183SolicitudesHoraInstalacion, "2") == 0 )
                     {
                        AV184HoraInstalacion = "12 - 16";
                     }
                     if ( StringUtil.StrCmp(A183SolicitudesHoraInstalacion, "3") == 0 )
                     {
                        AV184HoraInstalacion = "16 - 20";
                     }
                  }
                  AV185Dia = DateTimeUtil.CDow( A184SolicitudesFechaInstalacion, context.GetLanguage( ));
                  AV153SolicitudesPagadoDescription = "";
                  if ( StringUtil.StrCmp(StringUtil.Trim( A441SolicitudesPagado), "S") == 0 )
                  {
                     AV153SolicitudesPagadoDescription = context.GetMessage( "Pagado", "");
                  }
                  else if ( StringUtil.StrCmp(StringUtil.Trim( A441SolicitudesPagado), "N") == 0 )
                  {
                     AV153SolicitudesPagadoDescription = context.GetMessage( "Pendiente de Pago", "");
                  }
                  AV160SolicitudServicioOrigenPagoDescription = context.GetMessage( gxdomainorigenpago.getDescription(context,A438SolicitudServicioOrigenPago), "");
                  AV167SolicitudesSubTipoDescription = context.GetMessage( gxdomainsolicitudsubtipo.getDescription(context,A600SolicitudesSubTipo), "");
                  /* Execute user subroutine: 'BEFOREPRINTLINE' */
                  S144 ();
                  if ( returnInSub )
                  {
                     pr_default.close(0);
                     returnInSub = true;
                     if (true) return;
                  }
                  HAS0( false, 63) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(A127SolicitudesID), "ZZZZZZZZZZZZZZZZZ9")), 30, Gx_line+10, 57, Gx_line+52, 2+16, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(A133ProveedorID), "ZZZZZZZZZZZZZZZZZ9")), 61, Gx_line+10, 88, Gx_line+52, 2+16, 0, 0, 0) ;
                  getPrinter().GxDrawText(context.localUtil.Format( A184SolicitudesFechaInstalacion, "99/99/99"), 92, Gx_line+10, 119, Gx_line+52, 0+16, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV184HoraInstalacion, "")), 123, Gx_line+10, 150, Gx_line+52, 0+16, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV185Dia, "")), 154, Gx_line+10, 181, Gx_line+52, 0+16, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A282ProveedorNombre, "")), 185, Gx_line+10, 212, Gx_line+52, 0+16, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A171SolicitudesNombre, "")), 216, Gx_line+10, 243, Gx_line+52, 0+16, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A172SolicitudesTelefono, "")), 247, Gx_line+10, 274, Gx_line+52, 0+16, 0, 0, 0) ;
                  getPrinter().GxDrawText(context.localUtil.Format( A182SolicitudesFechaAlta, "99/99/9999"), 278, Gx_line+10, 305, Gx_line+52, 0+16, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A113DepartamentoDepartamento, "")), 309, Gx_line+10, 336, Gx_line+52, 0+16, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A115DepartamentoMunicipioNombre, "")), 340, Gx_line+10, 367, Gx_line+52, 0+16, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A111ZonasNombre, "")), 371, Gx_line+10, 398, Gx_line+52, 0+16, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A173SolicitudesDireccion, "")), 402, Gx_line+10, 429, Gx_line+52, 0+16, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( A211SolicitudServicioPFinal, "ZZZZZZ,ZZZ,ZZZ,ZZ9.99")), 433, Gx_line+10, 461, Gx_line+52, 2+16, 0, 0, 0) ;
                  getPrinter().GxDrawText(A205SolicitudesComentario, 465, Gx_line+10, 494, Gx_line+52, 0+16, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A210SolicitudServicioSolCoti, "")), 498, Gx_line+10, 526, Gx_line+52, 0+16, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A533ProveedorNombreAux, "")), 530, Gx_line+10, 559, Gx_line+52, 0+16, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV153SolicitudesPagadoDescription, "")), 563, Gx_line+10, 592, Gx_line+52, 0+16, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV160SolicitudServicioOrigenPagoDescription, "")), 596, Gx_line+10, 625, Gx_line+52, 0+16, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV167SolicitudesSubTipoDescription, "")), 629, Gx_line+10, 658, Gx_line+52, 0+16, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(A735MudanzaId), "ZZZZZZZZZZZZZZZZZ9")), 662, Gx_line+10, 690, Gx_line+52, 2+16, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A923STComerciosNombre, "")), 694, Gx_line+10, 723, Gx_line+52, 0+16, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(A972SolicitudesDuplicado), "ZZZZZZZZZZZZZZZZZ9")), 727, Gx_line+10, 755, Gx_line+52, 2+16, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(A422PostulacionesId), "ZZZZZZZZZZZZZZZZZ9")), 759, Gx_line+10, 787, Gx_line+52, 2+16, 0, 0, 0) ;
                  getPrinter().GxDrawLine(28, Gx_line+62, 789, Gx_line+62, 1, 220, 220, 220, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+63);
                  /* Execute user subroutine: 'AFTERPRINTLINE' */
                  S161 ();
                  if ( returnInSub )
                  {
                     pr_default.close(0);
                     returnInSub = true;
                     if (true) return;
                  }
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
         if ( StringUtil.StrCmp(AV43Session.Get("SolicitudesWWGridState"), "") == 0 )
         {
            AV45GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "SolicitudesWWGridState"), null, "", "");
         }
         else
         {
            AV45GridState.FromXml(AV43Session.Get("SolicitudesWWGridState"), null, "", "");
         }
         AV11OrderedBy = AV45GridState.gxTpr_Orderedby;
         AV12OrderedDsc = AV45GridState.gxTpr_Ordereddsc;
         AV236GXV4 = 1;
         while ( AV236GXV4 <= AV45GridState.gxTpr_Filtervalues.Count )
         {
            AV46GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV45GridState.gxTpr_Filtervalues.Item(AV236GXV4));
            if ( StringUtil.StrCmp(AV46GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV13FilterFullText = AV46GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV46GridStateFilterValue.gxTpr_Name, "TFSOLICITUDESID") == 0 )
            {
               AV47TFSolicitudesID = (long)(Math.Round(NumberUtil.Val( AV46GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV48TFSolicitudesID_To = (long)(Math.Round(NumberUtil.Val( AV46GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV46GridStateFilterValue.gxTpr_Name, "TFPROVEEDORID") == 0 )
            {
               AV122TFProveedorID = (long)(Math.Round(NumberUtil.Val( AV46GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV123TFProveedorID_To = (long)(Math.Round(NumberUtil.Val( AV46GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV46GridStateFilterValue.gxTpr_Name, "TFPROVEEDORID_SEL") == 0 )
            {
               AV141TFProveedorID_Sel = (long)(Math.Round(NumberUtil.Val( AV46GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV46GridStateFilterValue.gxTpr_Name, "TFSOLICITUDESFECHAINSTALACION") == 0 )
            {
               AV93TFSolicitudesFechaInstalacion = context.localUtil.CToD( AV46GridStateFilterValue.gxTpr_Value, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               AV94TFSolicitudesFechaInstalacion_To = context.localUtil.CToD( AV46GridStateFilterValue.gxTpr_Valueto, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
            }
            else if ( StringUtil.StrCmp(AV46GridStateFilterValue.gxTpr_Name, "TFSOLICITUDESFECHAALTA") == 0 )
            {
               AV89TFSolicitudesFechaAlta = context.localUtil.CToD( AV46GridStateFilterValue.gxTpr_Value, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               AV90TFSolicitudesFechaAlta_To = context.localUtil.CToD( AV46GridStateFilterValue.gxTpr_Valueto, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
            }
            else if ( StringUtil.StrCmp(AV46GridStateFilterValue.gxTpr_Name, "TFDEPARTAMENTOMUNICIPIONOMBRE") == 0 )
            {
               AV180TFDepartamentoMunicipioNombre = AV46GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV46GridStateFilterValue.gxTpr_Name, "TFDEPARTAMENTOMUNICIPIONOMBRE_SEL") == 0 )
            {
               AV181TFDepartamentoMunicipioNombre_Sel = AV46GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV46GridStateFilterValue.gxTpr_Name, "TFZONASNOMBRE") == 0 )
            {
               AV182TFZonasNombre = AV46GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV46GridStateFilterValue.gxTpr_Name, "TFZONASNOMBRE_SEL") == 0 )
            {
               AV183TFZonasNombre_Sel = AV46GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV46GridStateFilterValue.gxTpr_Name, "TFSOLICITUDSERVICIOPFINAL") == 0 )
            {
               AV72TFSolicitudServicioPFinal = NumberUtil.Val( AV46GridStateFilterValue.gxTpr_Value, ".");
               AV73TFSolicitudServicioPFinal_To = NumberUtil.Val( AV46GridStateFilterValue.gxTpr_Valueto, ".");
            }
            else if ( StringUtil.StrCmp(AV46GridStateFilterValue.gxTpr_Name, "TFSOLICITUDESCOMENTARIO") == 0 )
            {
               AV150TFSolicitudesComentario = AV46GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV46GridStateFilterValue.gxTpr_Name, "TFSOLICITUDESCOMENTARIO_SEL") == 0 )
            {
               AV151TFSolicitudesComentario_Sel = AV46GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV46GridStateFilterValue.gxTpr_Name, "TFPROVEEDORNOMBREAUX") == 0 )
            {
               AV144TFProveedorNombreAux = AV46GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV46GridStateFilterValue.gxTpr_Name, "TFPROVEEDORNOMBREAUX_SEL") == 0 )
            {
               AV145TFProveedorNombreAux_Sel = AV46GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV46GridStateFilterValue.gxTpr_Name, "TFSOLICITUDESPAGADO_SEL") == 0 )
            {
               AV154TFSolicitudesPagado_SelsJson = AV46GridStateFilterValue.gxTpr_Value;
               AV156TFSolicitudesPagado_Sels.FromJSonString(AV154TFSolicitudesPagado_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV46GridStateFilterValue.gxTpr_Name, "TFSOLICITUDSERVICIOORIGENPAGO_SEL") == 0 )
            {
               AV161TFSolicitudServicioOrigenPago_SelsJson = AV46GridStateFilterValue.gxTpr_Value;
               AV163TFSolicitudServicioOrigenPago_Sels.FromJSonString(AV161TFSolicitudServicioOrigenPago_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV46GridStateFilterValue.gxTpr_Name, "TFSOLICITUDESSUBTIPO_SEL") == 0 )
            {
               AV168TFSolicitudesSubTipo_SelsJson = AV46GridStateFilterValue.gxTpr_Value;
               AV171TFSolicitudesSubTipo_Sels.FromJSonString(AV168TFSolicitudesSubTipo_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV46GridStateFilterValue.gxTpr_Name, "TFMUDANZAID") == 0 )
            {
               AV195TFMudanzaId = (long)(Math.Round(NumberUtil.Val( AV46GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV196TFMudanzaId_To = (long)(Math.Round(NumberUtil.Val( AV46GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV46GridStateFilterValue.gxTpr_Name, "TFSTCOMERCIOSNOMBRE") == 0 )
            {
               AV187TFSTComerciosNombre = AV46GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV46GridStateFilterValue.gxTpr_Name, "TFSTCOMERCIOSNOMBRE_SEL") == 0 )
            {
               AV188TFSTComerciosNombre_Sel = AV46GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV46GridStateFilterValue.gxTpr_Name, "TFSOLICITUDESDUPLICADO") == 0 )
            {
               AV189TFSolicitudesDuplicado = (long)(Math.Round(NumberUtil.Val( AV46GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV190TFSolicitudesDuplicado_To = (long)(Math.Round(NumberUtil.Val( AV46GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV46GridStateFilterValue.gxTpr_Name, "TFPOSTULACIONESID") == 0 )
            {
               AV192TFPostulacionesId = (long)(Math.Round(NumberUtil.Val( AV46GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV193TFPostulacionesId_To = (long)(Math.Round(NumberUtil.Val( AV46GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV46GridStateFilterValue.gxTpr_Name, "PARM_&INSOLICITUDESID") == 0 )
            {
               AV166inSolicitudesId = (short)(Math.Round(NumberUtil.Val( AV46GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
            }
            AV236GXV4 = (int)(AV236GXV4+1);
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

      protected void HAS0( bool bFoot ,
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
                  AV118PageInfo = context.GetMessage( "Page: ", "") + StringUtil.Trim( StringUtil.Str( (decimal)(Gx_page), 6, 0));
                  AV115DateInfo = context.GetMessage( "Date: ", "") + context.localUtil.Format( Gx_date, "99/99/99");
                  getPrinter().GxDrawRect(0, Gx_line+5, 819, Gx_line+39, 1, 0, 0, 0, 1, 8, 160, 134, 1, 1, 1, 1, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV118PageInfo, "")), 30, Gx_line+15, 409, Gx_line+29, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV115DateInfo, "")), 409, Gx_line+15, 789, Gx_line+29, 2, 0, 0, 0) ;
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
               AV113AppName = context.GetMessage( "DVelop Software Solutions", "");
               AV119Phone = "+1 550 8923";
               AV117Mail = "info@mail.com";
               AV121Website = "http://www.web.com";
               AV110AddressLine1 = "French Boulevard 2859";
               AV111AddressLine2 = "Downtown";
               AV112AddressLine3 = "Paris, France";
               getPrinter().GxDrawRect(0, Gx_line+0, 819, Gx_line+107, 1, 0, 0, 0, 1, 8, 160, 134, 1, 1, 1, 1, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV113AppName, "")), 30, Gx_line+30, 283, Gx_line+44, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 20, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV120Title, "")), 30, Gx_line+44, 283, Gx_line+77, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV119Phone, "")), 283, Gx_line+30, 536, Gx_line+45, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV117Mail, "")), 283, Gx_line+45, 536, Gx_line+60, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV121Website, "")), 283, Gx_line+60, 536, Gx_line+77, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV110AddressLine1, "")), 536, Gx_line+30, 789, Gx_line+45, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV111AddressLine2, "")), 536, Gx_line+45, 789, Gx_line+60, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV112AddressLine3, "")), 536, Gx_line+60, 789, Gx_line+77, 2, 0, 0, 0) ;
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

      protected void GetSolicitudesTotal( long A127SolicitudesID )
      {
         /* Create private dbobjects */
         /* Navigation */
         A174SolicitudesTotal = 0;
         /* Using cursor P00AS3 */
         pr_default.execute(1, new Object[] {A127SolicitudesID});
         while ( (pr_default.getStatus(1) != 101) && ( P00AS3_A127SolicitudesID[0] == A127SolicitudesID ) )
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( P00AS3_A178SolicitudItemsSR[0])) || ( StringUtil.StrCmp(P00AS3_A179SolicitudItemsComisionTipo[0], "N") == 0 ) )
            {
               A175SolicitudesItemsPrecioInstalac = (decimal)((P00AS3_A176SolicitudesItemsPrecioFinal[0]*P00AS3_A177SolicitudesItemsCantidad[0]));
            }
            else
            {
               if ( ( StringUtil.StrCmp(P00AS3_A179SolicitudItemsComisionTipo[0], "F") == 0 ) && ( StringUtil.StrCmp(P00AS3_A178SolicitudItemsSR[0], "R") == 0 ) )
               {
                  A175SolicitudesItemsPrecioInstalac = (decimal)((P00AS3_A176SolicitudesItemsPrecioFinal[0]*P00AS3_A177SolicitudesItemsCantidad[0])-(P00AS3_A180SolicitudItemsComision[0]*P00AS3_A177SolicitudesItemsCantidad[0]));
               }
               else
               {
                  if ( ( StringUtil.StrCmp(P00AS3_A179SolicitudItemsComisionTipo[0], "F") == 0 ) && ( StringUtil.StrCmp(P00AS3_A178SolicitudItemsSR[0], "S") == 0 ) )
                  {
                     A175SolicitudesItemsPrecioInstalac = (decimal)((P00AS3_A176SolicitudesItemsPrecioFinal[0]*P00AS3_A177SolicitudesItemsCantidad[0])+(P00AS3_A180SolicitudItemsComision[0]*P00AS3_A177SolicitudesItemsCantidad[0]));
                  }
                  else
                  {
                     if ( ( StringUtil.StrCmp(P00AS3_A179SolicitudItemsComisionTipo[0], "P") == 0 ) && ( StringUtil.StrCmp(P00AS3_A178SolicitudItemsSR[0], "R") == 0 ) )
                     {
                        A175SolicitudesItemsPrecioInstalac = (decimal)((P00AS3_A176SolicitudesItemsPrecioFinal[0]*P00AS3_A177SolicitudesItemsCantidad[0])-((P00AS3_A176SolicitudesItemsPrecioFinal[0]*P00AS3_A177SolicitudesItemsCantidad[0])*(P00AS3_A180SolicitudItemsComision[0]/ (decimal)(100))));
                     }
                     else
                     {
                        if ( ( StringUtil.StrCmp(P00AS3_A179SolicitudItemsComisionTipo[0], "P") == 0 ) && ( StringUtil.StrCmp(P00AS3_A178SolicitudItemsSR[0], "S") == 0 ) )
                        {
                           A175SolicitudesItemsPrecioInstalac = (decimal)((P00AS3_A176SolicitudesItemsPrecioFinal[0]*P00AS3_A177SolicitudesItemsCantidad[0])+((P00AS3_A176SolicitudesItemsPrecioFinal[0]*P00AS3_A177SolicitudesItemsCantidad[0])*(P00AS3_A180SolicitudItemsComision[0]/ (decimal)(100))));
                        }
                        else
                        {
                           A175SolicitudesItemsPrecioInstalac = 0;
                        }
                     }
                  }
               }
            }
            A174SolicitudesTotal = (decimal)(A174SolicitudesTotal+A175SolicitudesItemsPrecioInstalac);
            pr_default.readNext(1);
         }
         pr_default.close(1);
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
         AV198Pgmname = "";
         GXEncryptionTmp = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV120Title = "";
         AV13FilterFullText = "";
         AV95TFSolicitudesID_To_Description = "";
         AV128TFProveedorID_To_Description = "";
         AV93TFSolicitudesFechaInstalacion = DateTime.MinValue;
         AV94TFSolicitudesFechaInstalacion_To = DateTime.MinValue;
         AV108TFSolicitudesFechaInstalacion_To_Description = "";
         AV89TFSolicitudesFechaAlta = DateTime.MinValue;
         AV90TFSolicitudesFechaAlta_To = DateTime.MinValue;
         AV106TFSolicitudesFechaAlta_To_Description = "";
         AV181TFDepartamentoMunicipioNombre_Sel = "";
         AV180TFDepartamentoMunicipioNombre = "";
         AV183TFZonasNombre_Sel = "";
         AV182TFZonasNombre = "";
         AV102TFSolicitudServicioPFinal_To_Description = "";
         AV151TFSolicitudesComentario_Sel = "";
         AV150TFSolicitudesComentario = "";
         AV145TFProveedorNombreAux_Sel = "";
         AV144TFProveedorNombreAux = "";
         AV156TFSolicitudesPagado_Sels = new GxSimpleCollection<string>();
         AV154TFSolicitudesPagado_SelsJson = "";
         AV157TFSolicitudesPagado_Sel = "";
         AV155TFSolicitudesPagado_SelDscs = "";
         AV158FilterTFSolicitudesPagado_SelValueDescription = "";
         AV163TFSolicitudServicioOrigenPago_Sels = new GxSimpleCollection<string>();
         AV161TFSolicitudServicioOrigenPago_SelsJson = "";
         AV164TFSolicitudServicioOrigenPago_Sel = "";
         AV162TFSolicitudServicioOrigenPago_SelDscs = "";
         AV165FilterTFSolicitudServicioOrigenPago_SelValueDescription = "";
         AV171TFSolicitudesSubTipo_Sels = new GxSimpleCollection<string>();
         AV168TFSolicitudesSubTipo_SelsJson = "";
         AV170TFSolicitudesSubTipo_Sel = "";
         AV169TFSolicitudesSubTipo_SelDscs = "";
         AV172FilterTFSolicitudesSubTipo_SelValueDescription = "";
         AV197TFMudanzaId_To_Description = "";
         AV188TFSTComerciosNombre_Sel = "";
         AV187TFSTComerciosNombre = "";
         AV191TFSolicitudesDuplicado_To_Description = "";
         AV194TFPostulacionesId_To_Description = "";
         AV205Solicitudeswwds_1_filterfulltext = "";
         AV211Solicitudeswwds_7_tfsolicitudesfechainstalacion = DateTime.MinValue;
         AV212Solicitudeswwds_8_tfsolicitudesfechainstalacion_to = DateTime.MinValue;
         AV213Solicitudeswwds_9_tfsolicitudesfechaalta = DateTime.MinValue;
         AV214Solicitudeswwds_10_tfsolicitudesfechaalta_to = DateTime.MinValue;
         AV215Solicitudeswwds_11_tfdepartamentomunicipionombre = "";
         AV216Solicitudeswwds_12_tfdepartamentomunicipionombre_sel = "";
         AV217Solicitudeswwds_13_tfzonasnombre = "";
         AV218Solicitudeswwds_14_tfzonasnombre_sel = "";
         AV221Solicitudeswwds_17_tfsolicitudescomentario = "";
         AV222Solicitudeswwds_18_tfsolicitudescomentario_sel = "";
         AV223Solicitudeswwds_19_tfproveedornombreaux = "";
         AV224Solicitudeswwds_20_tfproveedornombreaux_sel = "";
         AV225Solicitudeswwds_21_tfsolicitudespagado_sels = new GxSimpleCollection<string>();
         AV226Solicitudeswwds_22_tfsolicitudservicioorigenpago_sels = new GxSimpleCollection<string>();
         AV227Solicitudeswwds_23_tfsolicitudessubtipo_sels = new GxSimpleCollection<string>();
         AV230Solicitudeswwds_26_tfstcomerciosnombre = "";
         AV231Solicitudeswwds_27_tfstcomerciosnombre_sel = "";
         AV176ProveedorIDCollection = new GxSimpleCollection<long>();
         lV205Solicitudeswwds_1_filterfulltext = "";
         lV215Solicitudeswwds_11_tfdepartamentomunicipionombre = "";
         lV217Solicitudeswwds_13_tfzonasnombre = "";
         lV221Solicitudeswwds_17_tfsolicitudescomentario = "";
         lV223Solicitudeswwds_19_tfproveedornombreaux = "";
         lV230Solicitudeswwds_26_tfstcomerciosnombre = "";
         A441SolicitudesPagado = "";
         A438SolicitudServicioOrigenPago = "";
         A600SolicitudesSubTipo = "";
         A282ProveedorNombre = "";
         A171SolicitudesNombre = "";
         A172SolicitudesTelefono = "";
         A173SolicitudesDireccion = "";
         A203SolicitudesOtros3 = "";
         A113DepartamentoDepartamento = "";
         A533ProveedorNombreAux = "";
         A205SolicitudesComentario = "";
         A111ZonasNombre = "";
         A115DepartamentoMunicipioNombre = "";
         A184SolicitudesFechaInstalacion = DateTime.MinValue;
         A182SolicitudesFechaAlta = DateTime.MinValue;
         A923STComerciosNombre = "";
         AV147FechaIni = DateTime.MinValue;
         AV148FechaFin = DateTime.MinValue;
         A737MudanzaFechaAlta = DateTime.MinValue;
         P00AS2_A112DepartamentoId = new long[1] ;
         P00AS2_n112DepartamentoId = new bool[] {false} ;
         P00AS2_A114DepartamentoMunicipioId = new long[1] ;
         P00AS2_n114DepartamentoMunicipioId = new bool[] {false} ;
         P00AS2_A110ZonasID = new long[1] ;
         P00AS2_n110ZonasID = new bool[] {false} ;
         P00AS2_A919STComerciosID = new long[1] ;
         P00AS2_n919STComerciosID = new bool[] {false} ;
         P00AS2_A131EstadosSolId = new int[1] ;
         P00AS2_A737MudanzaFechaAlta = new DateTime[] {DateTime.MinValue} ;
         P00AS2_A113DepartamentoDepartamento = new string[] {""} ;
         P00AS2_A203SolicitudesOtros3 = new string[] {""} ;
         P00AS2_A173SolicitudesDireccion = new string[] {""} ;
         P00AS2_A172SolicitudesTelefono = new string[] {""} ;
         P00AS2_A171SolicitudesNombre = new string[] {""} ;
         P00AS2_A282ProveedorNombre = new string[] {""} ;
         P00AS2_A422PostulacionesId = new long[1] ;
         P00AS2_n422PostulacionesId = new bool[] {false} ;
         P00AS2_A972SolicitudesDuplicado = new long[1] ;
         P00AS2_n972SolicitudesDuplicado = new bool[] {false} ;
         P00AS2_A923STComerciosNombre = new string[] {""} ;
         P00AS2_A735MudanzaId = new long[1] ;
         P00AS2_n735MudanzaId = new bool[] {false} ;
         P00AS2_A600SolicitudesSubTipo = new string[] {""} ;
         P00AS2_n600SolicitudesSubTipo = new bool[] {false} ;
         P00AS2_A438SolicitudServicioOrigenPago = new string[] {""} ;
         P00AS2_n438SolicitudServicioOrigenPago = new bool[] {false} ;
         P00AS2_A441SolicitudesPagado = new string[] {""} ;
         P00AS2_n441SolicitudesPagado = new bool[] {false} ;
         P00AS2_A533ProveedorNombreAux = new string[] {""} ;
         P00AS2_n533ProveedorNombreAux = new bool[] {false} ;
         P00AS2_A205SolicitudesComentario = new string[] {""} ;
         P00AS2_A111ZonasNombre = new string[] {""} ;
         P00AS2_A115DepartamentoMunicipioNombre = new string[] {""} ;
         P00AS2_A182SolicitudesFechaAlta = new DateTime[] {DateTime.MinValue} ;
         P00AS2_n182SolicitudesFechaAlta = new bool[] {false} ;
         P00AS2_A184SolicitudesFechaInstalacion = new DateTime[] {DateTime.MinValue} ;
         P00AS2_A133ProveedorID = new long[1] ;
         P00AS2_A127SolicitudesID = new long[1] ;
         P00AS2_A183SolicitudesHoraInstalacion = new string[] {""} ;
         P00AS2_A210SolicitudServicioSolCoti = new string[] {""} ;
         P00AS2_A796SolicitudesComisionMetodoPago = new decimal[1] ;
         P00AS2_A212SolicitudesCotizacion = new decimal[1] ;
         P00AS2_A1016SolicitudesDescuentoCupon = new decimal[1] ;
         P00AS2_A897SolicitudesDescuento = new decimal[1] ;
         P00AS2_n897SolicitudesDescuento = new bool[] {false} ;
         P00AS2_A864SolicitudesCostoXZona = new decimal[1] ;
         A183SolicitudesHoraInstalacion = "";
         A210SolicitudServicioSolCoti = "";
         AV184HoraInstalacion = "";
         AV185Dia = "";
         AV153SolicitudesPagadoDescription = "";
         AV160SolicitudServicioOrigenPagoDescription = "";
         AV167SolicitudesSubTipoDescription = "";
         AV43Session = context.GetSession();
         AV45GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV46GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV118PageInfo = "";
         AV115DateInfo = "";
         Gx_date = DateTime.MinValue;
         AV113AppName = "";
         AV119Phone = "";
         AV117Mail = "";
         AV121Website = "";
         AV110AddressLine1 = "";
         AV111AddressLine2 = "";
         AV112AddressLine3 = "";
         P00AS3_A127SolicitudesID = new long[1] ;
         P00AS3_A134SolicitudesItemsID = new short[1] ;
         P00AS3_A180SolicitudItemsComision = new decimal[1] ;
         P00AS3_A179SolicitudItemsComisionTipo = new string[] {""} ;
         P00AS3_A178SolicitudItemsSR = new string[] {""} ;
         P00AS3_A177SolicitudesItemsCantidad = new short[1] ;
         P00AS3_A176SolicitudesItemsPrecioFinal = new decimal[1] ;
         P00AS3_n176SolicitudesItemsPrecioFinal = new bool[] {false} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.solicitudeswwexportreport__default(),
            new Object[][] {
                new Object[] {
               P00AS2_A112DepartamentoId, P00AS2_n112DepartamentoId, P00AS2_A114DepartamentoMunicipioId, P00AS2_n114DepartamentoMunicipioId, P00AS2_A110ZonasID, P00AS2_n110ZonasID, P00AS2_A919STComerciosID, P00AS2_n919STComerciosID, P00AS2_A131EstadosSolId, P00AS2_A737MudanzaFechaAlta,
               P00AS2_A113DepartamentoDepartamento, P00AS2_A203SolicitudesOtros3, P00AS2_A173SolicitudesDireccion, P00AS2_A172SolicitudesTelefono, P00AS2_A171SolicitudesNombre, P00AS2_A282ProveedorNombre, P00AS2_A422PostulacionesId, P00AS2_n422PostulacionesId, P00AS2_A972SolicitudesDuplicado, P00AS2_n972SolicitudesDuplicado,
               P00AS2_A923STComerciosNombre, P00AS2_A735MudanzaId, P00AS2_n735MudanzaId, P00AS2_A600SolicitudesSubTipo, P00AS2_n600SolicitudesSubTipo, P00AS2_A438SolicitudServicioOrigenPago, P00AS2_n438SolicitudServicioOrigenPago, P00AS2_A441SolicitudesPagado, P00AS2_n441SolicitudesPagado, P00AS2_A533ProveedorNombreAux,
               P00AS2_n533ProveedorNombreAux, P00AS2_A205SolicitudesComentario, P00AS2_A111ZonasNombre, P00AS2_A115DepartamentoMunicipioNombre, P00AS2_A182SolicitudesFechaAlta, P00AS2_n182SolicitudesFechaAlta, P00AS2_A184SolicitudesFechaInstalacion, P00AS2_A133ProveedorID, P00AS2_A127SolicitudesID, P00AS2_A183SolicitudesHoraInstalacion,
               P00AS2_A210SolicitudServicioSolCoti, P00AS2_A796SolicitudesComisionMetodoPago, P00AS2_A212SolicitudesCotizacion, P00AS2_A1016SolicitudesDescuentoCupon, P00AS2_A897SolicitudesDescuento, P00AS2_n897SolicitudesDescuento, P00AS2_A864SolicitudesCostoXZona
               }
               , new Object[] {
               P00AS3_A127SolicitudesID, P00AS3_A134SolicitudesItemsID, P00AS3_A180SolicitudItemsComision, P00AS3_A179SolicitudItemsComisionTipo, P00AS3_A178SolicitudItemsSR, P00AS3_A177SolicitudesItemsCantidad, P00AS3_A176SolicitudesItemsPrecioFinal, P00AS3_n176SolicitudesItemsPrecioFinal
               }
            }
         );
         Gx_date = DateTimeUtil.Today( context);
         AV198Pgmname = "SolicitudesWWExportReport";
         /* GeneXus formulas. */
         Gx_line = 0;
         Gx_date = DateTimeUtil.Today( context);
         AV198Pgmname = "SolicitudesWWExportReport";
      }

      private short nGotPars ;
      private short GxWebError ;
      private short AV11OrderedBy ;
      private short AV166inSolicitudesId ;
      private int M_top ;
      private int M_bot ;
      private int Line ;
      private int ToSkip ;
      private int PrtOffset ;
      private int Gx_OldLine ;
      private int AV201GXV1 ;
      private int AV202GXV2 ;
      private int AV203GXV3 ;
      private int AV225Solicitudeswwds_21_tfsolicitudespagado_sels_Count ;
      private int AV226Solicitudeswwds_22_tfsolicitudservicioorigenpago_sels_Count ;
      private int AV227Solicitudeswwds_23_tfsolicitudessubtipo_sels_Count ;
      private int AV176ProveedorIDCollection_Count ;
      private int A131EstadosSolId ;
      private int AV146EstadosGenericosID ;
      private int AV236GXV4 ;
      private long AV47TFSolicitudesID ;
      private long AV48TFSolicitudesID_To ;
      private long AV141TFProveedorID_Sel ;
      private long AV122TFProveedorID ;
      private long AV123TFProveedorID_To ;
      private long AV159i ;
      private long AV195TFMudanzaId ;
      private long AV196TFMudanzaId_To ;
      private long AV189TFSolicitudesDuplicado ;
      private long AV190TFSolicitudesDuplicado_To ;
      private long AV192TFPostulacionesId ;
      private long AV193TFPostulacionesId_To ;
      private long AV206Solicitudeswwds_2_tfsolicitudesid ;
      private long AV207Solicitudeswwds_3_tfsolicitudesid_to ;
      private long AV208Solicitudeswwds_4_tfproveedorid ;
      private long AV209Solicitudeswwds_5_tfproveedorid_to ;
      private long AV210Solicitudeswwds_6_tfproveedorid_sel ;
      private long AV228Solicitudeswwds_24_tfmudanzaid ;
      private long AV229Solicitudeswwds_25_tfmudanzaid_to ;
      private long AV232Solicitudeswwds_28_tfsolicitudesduplicado ;
      private long AV233Solicitudeswwds_29_tfsolicitudesduplicado_to ;
      private long AV234Solicitudeswwds_30_tfpostulacionesid ;
      private long AV235Solicitudeswwds_31_tfpostulacionesid_to ;
      private long A133ProveedorID ;
      private long AV178MudanzaId ;
      private long AV149ProveedorID ;
      private long A127SolicitudesID ;
      private long A735MudanzaId ;
      private long A972SolicitudesDuplicado ;
      private long A422PostulacionesId ;
      private long A112DepartamentoId ;
      private long A114DepartamentoMunicipioId ;
      private long A110ZonasID ;
      private long A919STComerciosID ;
      private decimal AV72TFSolicitudServicioPFinal ;
      private decimal AV73TFSolicitudServicioPFinal_To ;
      private decimal AV219Solicitudeswwds_15_tfsolicitudserviciopfinal ;
      private decimal AV220Solicitudeswwds_16_tfsolicitudserviciopfinal_to ;
      private decimal A211SolicitudServicioPFinal ;
      private decimal A796SolicitudesComisionMetodoPago ;
      private decimal A212SolicitudesCotizacion ;
      private decimal A1016SolicitudesDescuentoCupon ;
      private decimal A897SolicitudesDescuento ;
      private decimal A864SolicitudesCostoXZona ;
      private decimal A174SolicitudesTotal ;
      private decimal A175SolicitudesItemsPrecioInstalac ;
      private string GXKey ;
      private string gxfirstwebparm ;
      private string AV198Pgmname ;
      private string GXEncryptionTmp ;
      private string AV181TFDepartamentoMunicipioNombre_Sel ;
      private string AV180TFDepartamentoMunicipioNombre ;
      private string AV183TFZonasNombre_Sel ;
      private string AV182TFZonasNombre ;
      private string AV145TFProveedorNombreAux_Sel ;
      private string AV144TFProveedorNombreAux ;
      private string AV157TFSolicitudesPagado_Sel ;
      private string AV164TFSolicitudServicioOrigenPago_Sel ;
      private string AV170TFSolicitudesSubTipo_Sel ;
      private string AV188TFSTComerciosNombre_Sel ;
      private string AV187TFSTComerciosNombre ;
      private string AV215Solicitudeswwds_11_tfdepartamentomunicipionombre ;
      private string AV216Solicitudeswwds_12_tfdepartamentomunicipionombre_sel ;
      private string AV217Solicitudeswwds_13_tfzonasnombre ;
      private string AV218Solicitudeswwds_14_tfzonasnombre_sel ;
      private string AV223Solicitudeswwds_19_tfproveedornombreaux ;
      private string AV224Solicitudeswwds_20_tfproveedornombreaux_sel ;
      private string AV230Solicitudeswwds_26_tfstcomerciosnombre ;
      private string AV231Solicitudeswwds_27_tfstcomerciosnombre_sel ;
      private string lV215Solicitudeswwds_11_tfdepartamentomunicipionombre ;
      private string lV217Solicitudeswwds_13_tfzonasnombre ;
      private string lV223Solicitudeswwds_19_tfproveedornombreaux ;
      private string lV230Solicitudeswwds_26_tfstcomerciosnombre ;
      private string A441SolicitudesPagado ;
      private string A438SolicitudServicioOrigenPago ;
      private string A600SolicitudesSubTipo ;
      private string A282ProveedorNombre ;
      private string A171SolicitudesNombre ;
      private string A172SolicitudesTelefono ;
      private string A203SolicitudesOtros3 ;
      private string A113DepartamentoDepartamento ;
      private string A533ProveedorNombreAux ;
      private string A111ZonasNombre ;
      private string A115DepartamentoMunicipioNombre ;
      private string A923STComerciosNombre ;
      private string A183SolicitudesHoraInstalacion ;
      private string A210SolicitudServicioSolCoti ;
      private DateTime AV93TFSolicitudesFechaInstalacion ;
      private DateTime AV94TFSolicitudesFechaInstalacion_To ;
      private DateTime AV89TFSolicitudesFechaAlta ;
      private DateTime AV90TFSolicitudesFechaAlta_To ;
      private DateTime AV211Solicitudeswwds_7_tfsolicitudesfechainstalacion ;
      private DateTime AV212Solicitudeswwds_8_tfsolicitudesfechainstalacion_to ;
      private DateTime AV213Solicitudeswwds_9_tfsolicitudesfechaalta ;
      private DateTime AV214Solicitudeswwds_10_tfsolicitudesfechaalta_to ;
      private DateTime A184SolicitudesFechaInstalacion ;
      private DateTime A182SolicitudesFechaAlta ;
      private DateTime AV147FechaIni ;
      private DateTime AV148FechaFin ;
      private DateTime A737MudanzaFechaAlta ;
      private DateTime Gx_date ;
      private bool entryPointCalled ;
      private bool AV8IsAuthorized ;
      private bool GXt_boolean1 ;
      private bool returnInSub ;
      private bool AV109TempBoolean ;
      private bool AV12OrderedDsc ;
      private bool n112DepartamentoId ;
      private bool n114DepartamentoMunicipioId ;
      private bool n110ZonasID ;
      private bool n919STComerciosID ;
      private bool n422PostulacionesId ;
      private bool n972SolicitudesDuplicado ;
      private bool n735MudanzaId ;
      private bool n600SolicitudesSubTipo ;
      private bool n438SolicitudServicioOrigenPago ;
      private bool n441SolicitudesPagado ;
      private bool n533ProveedorNombreAux ;
      private bool n182SolicitudesFechaAlta ;
      private bool n897SolicitudesDescuento ;
      private string AV154TFSolicitudesPagado_SelsJson ;
      private string AV161TFSolicitudServicioOrigenPago_SelsJson ;
      private string AV168TFSolicitudesSubTipo_SelsJson ;
      private string A205SolicitudesComentario ;
      private string AV120Title ;
      private string AV13FilterFullText ;
      private string AV95TFSolicitudesID_To_Description ;
      private string AV128TFProveedorID_To_Description ;
      private string AV108TFSolicitudesFechaInstalacion_To_Description ;
      private string AV106TFSolicitudesFechaAlta_To_Description ;
      private string AV102TFSolicitudServicioPFinal_To_Description ;
      private string AV151TFSolicitudesComentario_Sel ;
      private string AV150TFSolicitudesComentario ;
      private string AV155TFSolicitudesPagado_SelDscs ;
      private string AV158FilterTFSolicitudesPagado_SelValueDescription ;
      private string AV162TFSolicitudServicioOrigenPago_SelDscs ;
      private string AV165FilterTFSolicitudServicioOrigenPago_SelValueDescription ;
      private string AV169TFSolicitudesSubTipo_SelDscs ;
      private string AV172FilterTFSolicitudesSubTipo_SelValueDescription ;
      private string AV197TFMudanzaId_To_Description ;
      private string AV191TFSolicitudesDuplicado_To_Description ;
      private string AV194TFPostulacionesId_To_Description ;
      private string AV205Solicitudeswwds_1_filterfulltext ;
      private string AV221Solicitudeswwds_17_tfsolicitudescomentario ;
      private string AV222Solicitudeswwds_18_tfsolicitudescomentario_sel ;
      private string lV205Solicitudeswwds_1_filterfulltext ;
      private string lV221Solicitudeswwds_17_tfsolicitudescomentario ;
      private string A173SolicitudesDireccion ;
      private string AV184HoraInstalacion ;
      private string AV185Dia ;
      private string AV153SolicitudesPagadoDescription ;
      private string AV160SolicitudServicioOrigenPagoDescription ;
      private string AV167SolicitudesSubTipoDescription ;
      private string AV118PageInfo ;
      private string AV115DateInfo ;
      private string AV113AppName ;
      private string AV119Phone ;
      private string AV117Mail ;
      private string AV121Website ;
      private string AV110AddressLine1 ;
      private string AV111AddressLine2 ;
      private string AV112AddressLine3 ;
      private IGxSession AV43Session ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GxSimpleCollection<string> AV156TFSolicitudesPagado_Sels ;
      private GxSimpleCollection<string> AV163TFSolicitudServicioOrigenPago_Sels ;
      private GxSimpleCollection<string> AV171TFSolicitudesSubTipo_Sels ;
      private GxSimpleCollection<string> AV225Solicitudeswwds_21_tfsolicitudespagado_sels ;
      private GxSimpleCollection<string> AV226Solicitudeswwds_22_tfsolicitudservicioorigenpago_sels ;
      private GxSimpleCollection<string> AV227Solicitudeswwds_23_tfsolicitudessubtipo_sels ;
      private GxSimpleCollection<long> AV176ProveedorIDCollection ;
      private IDataStoreProvider pr_default ;
      private long[] P00AS2_A112DepartamentoId ;
      private bool[] P00AS2_n112DepartamentoId ;
      private long[] P00AS2_A114DepartamentoMunicipioId ;
      private bool[] P00AS2_n114DepartamentoMunicipioId ;
      private long[] P00AS2_A110ZonasID ;
      private bool[] P00AS2_n110ZonasID ;
      private long[] P00AS2_A919STComerciosID ;
      private bool[] P00AS2_n919STComerciosID ;
      private int[] P00AS2_A131EstadosSolId ;
      private DateTime[] P00AS2_A737MudanzaFechaAlta ;
      private string[] P00AS2_A113DepartamentoDepartamento ;
      private string[] P00AS2_A203SolicitudesOtros3 ;
      private string[] P00AS2_A173SolicitudesDireccion ;
      private string[] P00AS2_A172SolicitudesTelefono ;
      private string[] P00AS2_A171SolicitudesNombre ;
      private string[] P00AS2_A282ProveedorNombre ;
      private long[] P00AS2_A422PostulacionesId ;
      private bool[] P00AS2_n422PostulacionesId ;
      private long[] P00AS2_A972SolicitudesDuplicado ;
      private bool[] P00AS2_n972SolicitudesDuplicado ;
      private string[] P00AS2_A923STComerciosNombre ;
      private long[] P00AS2_A735MudanzaId ;
      private bool[] P00AS2_n735MudanzaId ;
      private string[] P00AS2_A600SolicitudesSubTipo ;
      private bool[] P00AS2_n600SolicitudesSubTipo ;
      private string[] P00AS2_A438SolicitudServicioOrigenPago ;
      private bool[] P00AS2_n438SolicitudServicioOrigenPago ;
      private string[] P00AS2_A441SolicitudesPagado ;
      private bool[] P00AS2_n441SolicitudesPagado ;
      private string[] P00AS2_A533ProveedorNombreAux ;
      private bool[] P00AS2_n533ProveedorNombreAux ;
      private string[] P00AS2_A205SolicitudesComentario ;
      private string[] P00AS2_A111ZonasNombre ;
      private string[] P00AS2_A115DepartamentoMunicipioNombre ;
      private DateTime[] P00AS2_A182SolicitudesFechaAlta ;
      private bool[] P00AS2_n182SolicitudesFechaAlta ;
      private DateTime[] P00AS2_A184SolicitudesFechaInstalacion ;
      private long[] P00AS2_A133ProveedorID ;
      private long[] P00AS2_A127SolicitudesID ;
      private string[] P00AS2_A183SolicitudesHoraInstalacion ;
      private string[] P00AS2_A210SolicitudServicioSolCoti ;
      private decimal[] P00AS2_A796SolicitudesComisionMetodoPago ;
      private decimal[] P00AS2_A212SolicitudesCotizacion ;
      private decimal[] P00AS2_A1016SolicitudesDescuentoCupon ;
      private decimal[] P00AS2_A897SolicitudesDescuento ;
      private bool[] P00AS2_n897SolicitudesDescuento ;
      private decimal[] P00AS2_A864SolicitudesCostoXZona ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV45GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV46GridStateFilterValue ;
      private long[] P00AS3_A127SolicitudesID ;
      private short[] P00AS3_A134SolicitudesItemsID ;
      private decimal[] P00AS3_A180SolicitudItemsComision ;
      private string[] P00AS3_A179SolicitudItemsComisionTipo ;
      private string[] P00AS3_A178SolicitudItemsSR ;
      private short[] P00AS3_A177SolicitudesItemsCantidad ;
      private decimal[] P00AS3_A176SolicitudesItemsPrecioFinal ;
      private bool[] P00AS3_n176SolicitudesItemsPrecioFinal ;
   }

   public class solicitudeswwexportreport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00AS2( IGxContext context ,
                                             string A441SolicitudesPagado ,
                                             GxSimpleCollection<string> AV225Solicitudeswwds_21_tfsolicitudespagado_sels ,
                                             string A438SolicitudServicioOrigenPago ,
                                             GxSimpleCollection<string> AV226Solicitudeswwds_22_tfsolicitudservicioorigenpago_sels ,
                                             string A600SolicitudesSubTipo ,
                                             GxSimpleCollection<string> AV227Solicitudeswwds_23_tfsolicitudessubtipo_sels ,
                                             long A133ProveedorID ,
                                             GxSimpleCollection<long> AV176ProveedorIDCollection ,
                                             int A131EstadosSolId ,
                                             string AV205Solicitudeswwds_1_filterfulltext ,
                                             long AV206Solicitudeswwds_2_tfsolicitudesid ,
                                             long AV207Solicitudeswwds_3_tfsolicitudesid_to ,
                                             long AV210Solicitudeswwds_6_tfproveedorid_sel ,
                                             DateTime AV211Solicitudeswwds_7_tfsolicitudesfechainstalacion ,
                                             DateTime AV212Solicitudeswwds_8_tfsolicitudesfechainstalacion_to ,
                                             DateTime AV213Solicitudeswwds_9_tfsolicitudesfechaalta ,
                                             DateTime AV214Solicitudeswwds_10_tfsolicitudesfechaalta_to ,
                                             string AV216Solicitudeswwds_12_tfdepartamentomunicipionombre_sel ,
                                             string AV215Solicitudeswwds_11_tfdepartamentomunicipionombre ,
                                             string AV218Solicitudeswwds_14_tfzonasnombre_sel ,
                                             string AV217Solicitudeswwds_13_tfzonasnombre ,
                                             string AV222Solicitudeswwds_18_tfsolicitudescomentario_sel ,
                                             string AV221Solicitudeswwds_17_tfsolicitudescomentario ,
                                             string AV224Solicitudeswwds_20_tfproveedornombreaux_sel ,
                                             string AV223Solicitudeswwds_19_tfproveedornombreaux ,
                                             int AV225Solicitudeswwds_21_tfsolicitudespagado_sels_Count ,
                                             int AV226Solicitudeswwds_22_tfsolicitudservicioorigenpago_sels_Count ,
                                             int AV227Solicitudeswwds_23_tfsolicitudessubtipo_sels_Count ,
                                             long AV228Solicitudeswwds_24_tfmudanzaid ,
                                             long AV229Solicitudeswwds_25_tfmudanzaid_to ,
                                             string AV231Solicitudeswwds_27_tfstcomerciosnombre_sel ,
                                             string AV230Solicitudeswwds_26_tfstcomerciosnombre ,
                                             long AV232Solicitudeswwds_28_tfsolicitudesduplicado ,
                                             long AV233Solicitudeswwds_29_tfsolicitudesduplicado_to ,
                                             long AV234Solicitudeswwds_30_tfpostulacionesid ,
                                             long AV235Solicitudeswwds_31_tfpostulacionesid_to ,
                                             long AV178MudanzaId ,
                                             long AV149ProveedorID ,
                                             int AV176ProveedorIDCollection_Count ,
                                             int AV146EstadosGenericosID ,
                                             long A127SolicitudesID ,
                                             string A282ProveedorNombre ,
                                             string A171SolicitudesNombre ,
                                             string A172SolicitudesTelefono ,
                                             string A173SolicitudesDireccion ,
                                             string A203SolicitudesOtros3 ,
                                             string A113DepartamentoDepartamento ,
                                             string A533ProveedorNombreAux ,
                                             string A205SolicitudesComentario ,
                                             string A111ZonasNombre ,
                                             string A115DepartamentoMunicipioNombre ,
                                             DateTime A184SolicitudesFechaInstalacion ,
                                             DateTime A182SolicitudesFechaAlta ,
                                             long A735MudanzaId ,
                                             string A923STComerciosNombre ,
                                             long A972SolicitudesDuplicado ,
                                             long A422PostulacionesId ,
                                             DateTime AV147FechaIni ,
                                             DateTime AV148FechaFin ,
                                             DateTime A737MudanzaFechaAlta ,
                                             short AV11OrderedBy ,
                                             bool AV12OrderedDsc ,
                                             decimal AV219Solicitudeswwds_15_tfsolicitudserviciopfinal ,
                                             decimal A211SolicitudServicioPFinal ,
                                             decimal AV220Solicitudeswwds_16_tfsolicitudserviciopfinal_to )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int2 = new short[39];
         Object[] GXv_Object3 = new Object[2];
         scmdbuf = "SELECT T1.[DepartamentoId], T1.[DepartamentoMunicipioId], T1.[ZonasID], T1.[STComerciosID] AS STComerciosID, T1.[EstadosSolId], T6.[MudanzaFechaAlta], T2.[DepartamentoDepartamento], T1.[SolicitudesOtros3], T1.[SolicitudesDireccion], T1.[SolicitudesTelefono], T1.[SolicitudesNombre], T7.[ProveedorNombre], T1.[PostulacionesId], T1.[SolicitudesDuplicado], T5.[ProveedorNombre] AS STComerciosNombre, T1.[MudanzaId], T1.[SolicitudesSubTipo], T1.[SolicitudServicioOrigenPago], T1.[SolicitudesPagado], T1.[ProveedorNombreAux], T1.[SolicitudesComentario], T4.[ZonasNombre], T3.[DepartamentoMunicipioNombre], T1.[SolicitudesFechaAlta], T1.[SolicitudesFechaInstalacion], T1.[ProveedorID], T1.[SolicitudesID], T1.[SolicitudesHoraInstalacion], T1.[SolicitudServicioSolCoti], T1.[SolicitudesComisionMetodoPago], T1.[SolicitudesCotizacion], T1.[SolicitudesDescuentoCupon], T1.[SolicitudesDescuento], T1.[SolicitudesCostoXZona] FROM (((((([Solicitudes] T1 LEFT JOIN [Departamento] T2 ON T2.[DepartamentoId] = T1.[DepartamentoId]) LEFT JOIN [DepartamentoMunicipio] T3 ON T3.[DepartamentoId] = T1.[DepartamentoId] AND T3.[DepartamentoMunicipioId] = T1.[DepartamentoMunicipioId]) LEFT JOIN [Zonas] T4 ON T4.[ZonasID] = T1.[ZonasID] AND T4.[DepartamentoId] = T1.[DepartamentoId] AND T4.[DepartamentoMunicipioId] = T1.[DepartamentoMunicipioId]) LEFT JOIN [Proveedor] T5 ON T5.[ProveedorID] = T1.[STComerciosID]) LEFT JOIN [Mudanza] T6 ON T6.[MudanzaId] = T1.[MudanzaId]) INNER JOIN [Proveedor] T7 ON T7.[ProveedorID] = T1.[ProveedorID])";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV205Solicitudeswwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( CONVERT( char(18), CAST(T1.[SolicitudesID] AS decimal(18,0))) like '%' + @lV205Solicitudeswwds_1_filterfulltext) or ( UPPER(T7.[ProveedorNombre]) like '%' + UPPER(@lV205Solicitudeswwds_1_filterfulltext)) or ( UPPER(T1.[SolicitudesNombre]) like '%' + UPPER(@lV205Solicitudeswwds_1_filterfulltext)) or ( UPPER(T1.[SolicitudesTelefono]) like '%' + UPPER(@lV205Solicitudeswwds_1_filterfulltext)) or ( UPPER(T1.[SolicitudesDireccion]) like '%' + UPPER(@lV205Solicitudeswwds_1_filterfulltext)) or ( UPPER(T1.[SolicitudesOtros3]) like '%' + UPPER(@lV205Solicitudeswwds_1_filterfulltext)) or ( UPPER(T2.[DepartamentoDepartamento]) like '%' + UPPER(@lV205Solicitudeswwds_1_filterfulltext)) or ( UPPER(T1.[ProveedorNombreAux]) like '%' + UPPER(@lV205Solicitudeswwds_1_filterfulltext)) or ( UPPER(T1.[SolicitudesComentario]) like '%' + UPPER(@lV205Solicitudeswwds_1_filterfulltext)) or ( UPPER(T4.[ZonasNombre]) like '%' + UPPER(@lV205Solicitudeswwds_1_filterfulltext)) or ( UPPER(T3.[DepartamentoMunicipioNombre]) like '%' + UPPER(@lV205Solicitudeswwds_1_filterfulltext)))");
         }
         else
         {
            GXv_int2[0] = 1;
            GXv_int2[1] = 1;
            GXv_int2[2] = 1;
            GXv_int2[3] = 1;
            GXv_int2[4] = 1;
            GXv_int2[5] = 1;
            GXv_int2[6] = 1;
            GXv_int2[7] = 1;
            GXv_int2[8] = 1;
            GXv_int2[9] = 1;
            GXv_int2[10] = 1;
         }
         if ( ! (0==AV206Solicitudeswwds_2_tfsolicitudesid) )
         {
            AddWhere(sWhereString, "(T1.[SolicitudesID] >= @AV206Solicitudeswwds_2_tfsolicitudesid)");
         }
         else
         {
            GXv_int2[11] = 1;
         }
         if ( ! (0==AV207Solicitudeswwds_3_tfsolicitudesid_to) )
         {
            AddWhere(sWhereString, "(T1.[SolicitudesID] <= @AV207Solicitudeswwds_3_tfsolicitudesid_to)");
         }
         else
         {
            GXv_int2[12] = 1;
         }
         if ( ! (0==AV210Solicitudeswwds_6_tfproveedorid_sel) )
         {
            AddWhere(sWhereString, "(T1.[ProveedorID] = @AV210Solicitudeswwds_6_tfproveedorid_sel)");
         }
         else
         {
            GXv_int2[13] = 1;
         }
         if ( ! (DateTime.MinValue==AV211Solicitudeswwds_7_tfsolicitudesfechainstalacion) )
         {
            AddWhere(sWhereString, "(T1.[SolicitudesFechaInstalacion] >= @AV211Solicitudeswwds_7_tfsolicitudesfechainstalacion)");
         }
         else
         {
            GXv_int2[14] = 1;
         }
         if ( ! (DateTime.MinValue==AV212Solicitudeswwds_8_tfsolicitudesfechainstalacion_to) )
         {
            AddWhere(sWhereString, "(T1.[SolicitudesFechaInstalacion] <= @AV212Solicitudeswwds_8_tfsolicitudesfechainstalacion_to)");
         }
         else
         {
            GXv_int2[15] = 1;
         }
         if ( ! (DateTime.MinValue==AV213Solicitudeswwds_9_tfsolicitudesfechaalta) )
         {
            AddWhere(sWhereString, "(T1.[SolicitudesFechaAlta] >= @AV213Solicitudeswwds_9_tfsolicitudesfechaalta)");
         }
         else
         {
            GXv_int2[16] = 1;
         }
         if ( ! (DateTime.MinValue==AV214Solicitudeswwds_10_tfsolicitudesfechaalta_to) )
         {
            AddWhere(sWhereString, "(T1.[SolicitudesFechaAlta] <= @AV214Solicitudeswwds_10_tfsolicitudesfechaalta_to)");
         }
         else
         {
            GXv_int2[17] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV216Solicitudeswwds_12_tfdepartamentomunicipionombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV215Solicitudeswwds_11_tfdepartamentomunicipionombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T3.[DepartamentoMunicipioNombre]) like UPPER(@lV215Solicitudeswwds_11_tfdepartamentomunicipionombre))");
         }
         else
         {
            GXv_int2[18] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV216Solicitudeswwds_12_tfdepartamentomunicipionombre_sel)) && ! ( StringUtil.StrCmp(AV216Solicitudeswwds_12_tfdepartamentomunicipionombre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T3.[DepartamentoMunicipioNombre] = @AV216Solicitudeswwds_12_tfdepartamentomunicipionombre_sel)");
         }
         else
         {
            GXv_int2[19] = 1;
         }
         if ( StringUtil.StrCmp(AV216Solicitudeswwds_12_tfdepartamentomunicipionombre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T3.[DepartamentoMunicipioNombre] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV218Solicitudeswwds_14_tfzonasnombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV217Solicitudeswwds_13_tfzonasnombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T4.[ZonasNombre]) like UPPER(@lV217Solicitudeswwds_13_tfzonasnombre))");
         }
         else
         {
            GXv_int2[20] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV218Solicitudeswwds_14_tfzonasnombre_sel)) && ! ( StringUtil.StrCmp(AV218Solicitudeswwds_14_tfzonasnombre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T4.[ZonasNombre] = @AV218Solicitudeswwds_14_tfzonasnombre_sel)");
         }
         else
         {
            GXv_int2[21] = 1;
         }
         if ( StringUtil.StrCmp(AV218Solicitudeswwds_14_tfzonasnombre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T4.[ZonasNombre] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV222Solicitudeswwds_18_tfsolicitudescomentario_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV221Solicitudeswwds_17_tfsolicitudescomentario)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[SolicitudesComentario]) like UPPER(@lV221Solicitudeswwds_17_tfsolicitudescomentario))");
         }
         else
         {
            GXv_int2[22] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV222Solicitudeswwds_18_tfsolicitudescomentario_sel)) && ! ( StringUtil.StrCmp(AV222Solicitudeswwds_18_tfsolicitudescomentario_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[SolicitudesComentario] = @AV222Solicitudeswwds_18_tfsolicitudescomentario_sel)");
         }
         else
         {
            GXv_int2[23] = 1;
         }
         if ( StringUtil.StrCmp(AV222Solicitudeswwds_18_tfsolicitudescomentario_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((DATALENGTH(T1.[SolicitudesComentario])=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV224Solicitudeswwds_20_tfproveedornombreaux_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV223Solicitudeswwds_19_tfproveedornombreaux)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[ProveedorNombreAux]) like UPPER(@lV223Solicitudeswwds_19_tfproveedornombreaux))");
         }
         else
         {
            GXv_int2[24] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV224Solicitudeswwds_20_tfproveedornombreaux_sel)) && ! ( StringUtil.StrCmp(AV224Solicitudeswwds_20_tfproveedornombreaux_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[ProveedorNombreAux] = @AV224Solicitudeswwds_20_tfproveedornombreaux_sel)");
         }
         else
         {
            GXv_int2[25] = 1;
         }
         if ( StringUtil.StrCmp(AV224Solicitudeswwds_20_tfproveedornombreaux_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.[ProveedorNombreAux] IS NULL or (T1.[ProveedorNombreAux] = ''))");
         }
         if ( AV225Solicitudeswwds_21_tfsolicitudespagado_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV225Solicitudeswwds_21_tfsolicitudespagado_sels, "T1.[SolicitudesPagado] IN (", ")")+")");
         }
         if ( AV226Solicitudeswwds_22_tfsolicitudservicioorigenpago_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV226Solicitudeswwds_22_tfsolicitudservicioorigenpago_sels, "T1.[SolicitudServicioOrigenPago] IN (", ")")+")");
         }
         if ( AV227Solicitudeswwds_23_tfsolicitudessubtipo_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV227Solicitudeswwds_23_tfsolicitudessubtipo_sels, "T1.[SolicitudesSubTipo] IN (", ")")+")");
         }
         if ( ! (0==AV228Solicitudeswwds_24_tfmudanzaid) )
         {
            AddWhere(sWhereString, "(T1.[MudanzaId] >= @AV228Solicitudeswwds_24_tfmudanzaid)");
         }
         else
         {
            GXv_int2[26] = 1;
         }
         if ( ! (0==AV229Solicitudeswwds_25_tfmudanzaid_to) )
         {
            AddWhere(sWhereString, "(T1.[MudanzaId] <= @AV229Solicitudeswwds_25_tfmudanzaid_to)");
         }
         else
         {
            GXv_int2[27] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV231Solicitudeswwds_27_tfstcomerciosnombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV230Solicitudeswwds_26_tfstcomerciosnombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T5.[ProveedorNombre]) like UPPER(@lV230Solicitudeswwds_26_tfstcomerciosnombre))");
         }
         else
         {
            GXv_int2[28] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV231Solicitudeswwds_27_tfstcomerciosnombre_sel)) && ! ( StringUtil.StrCmp(AV231Solicitudeswwds_27_tfstcomerciosnombre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T5.[ProveedorNombre] = @AV231Solicitudeswwds_27_tfstcomerciosnombre_sel)");
         }
         else
         {
            GXv_int2[29] = 1;
         }
         if ( StringUtil.StrCmp(AV231Solicitudeswwds_27_tfstcomerciosnombre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T5.[ProveedorNombre] IS NULL or (T5.[ProveedorNombre] = ''))");
         }
         if ( ! (0==AV232Solicitudeswwds_28_tfsolicitudesduplicado) )
         {
            AddWhere(sWhereString, "(T1.[SolicitudesDuplicado] >= @AV232Solicitudeswwds_28_tfsolicitudesduplicado)");
         }
         else
         {
            GXv_int2[30] = 1;
         }
         if ( ! (0==AV233Solicitudeswwds_29_tfsolicitudesduplicado_to) )
         {
            AddWhere(sWhereString, "(T1.[SolicitudesDuplicado] <= @AV233Solicitudeswwds_29_tfsolicitudesduplicado_to)");
         }
         else
         {
            GXv_int2[31] = 1;
         }
         if ( ! (0==AV234Solicitudeswwds_30_tfpostulacionesid) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesId] >= @AV234Solicitudeswwds_30_tfpostulacionesid)");
         }
         else
         {
            GXv_int2[32] = 1;
         }
         if ( ! (0==AV235Solicitudeswwds_31_tfpostulacionesid_to) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesId] <= @AV235Solicitudeswwds_31_tfpostulacionesid_to)");
         }
         else
         {
            GXv_int2[33] = 1;
         }
         if ( (0==AV178MudanzaId) )
         {
            AddWhere(sWhereString, "(( T1.[SolicitudesFechaInstalacion] >= @AV147FechaIni and T1.[SolicitudesFechaInstalacion] <= @AV148FechaFin) or ( (T1.[SolicitudesFechaInstalacion] = convert( DATETIME, '17530101', 112 )) and T1.[SolicitudesSubTipo] IN ('Z','P','S')))");
         }
         else
         {
            GXv_int2[34] = 1;
            GXv_int2[35] = 1;
         }
         if ( ! (0==AV178MudanzaId) )
         {
            AddWhere(sWhereString, "(T6.[MudanzaFechaAlta] >= @AV147FechaIni and T6.[MudanzaFechaAlta] <= @AV148FechaFin)");
         }
         else
         {
            GXv_int2[36] = 1;
            GXv_int2[37] = 1;
         }
         if ( ! (0==AV149ProveedorID) )
         {
            AddWhere(sWhereString, "(T1.[ProveedorID] = @AV149ProveedorID)");
         }
         else
         {
            GXv_int2[38] = 1;
         }
         if ( AV176ProveedorIDCollection_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV176ProveedorIDCollection, "T1.[ProveedorID] IN (", ")")+")");
         }
         if ( AV146EstadosGenericosID == 1 )
         {
            AddWhere(sWhereString, "(T1.[EstadosSolId] IN (1,9))");
         }
         if ( AV146EstadosGenericosID == 2 )
         {
            AddWhere(sWhereString, "(T1.[EstadosSolId] IN (2,9))");
         }
         if ( AV146EstadosGenericosID == 3 )
         {
            AddWhere(sWhereString, "(T1.[EstadosSolId] IN (3,9))");
         }
         if ( AV146EstadosGenericosID == 4 )
         {
            AddWhere(sWhereString, "(T1.[EstadosSolId] IN (4,9))");
         }
         if ( AV146EstadosGenericosID == 5 )
         {
            AddWhere(sWhereString, "(T1.[EstadosSolId] IN (5,9))");
         }
         if ( AV146EstadosGenericosID == 6 )
         {
            AddWhere(sWhereString, "(T1.[EstadosSolId] IN (6,9))");
         }
         if ( AV146EstadosGenericosID == 7 )
         {
            AddWhere(sWhereString, "(T1.[EstadosSolId] IN (7,9))");
         }
         if ( AV146EstadosGenericosID == 8 )
         {
            AddWhere(sWhereString, "(T1.[EstadosSolId] IN (8,9))");
         }
         if ( AV146EstadosGenericosID == 9 )
         {
            AddWhere(sWhereString, "(T1.[EstadosSolId] = 9)");
         }
         if ( AV146EstadosGenericosID == 10 )
         {
            AddWhere(sWhereString, "(T1.[EstadosSolId] = 10)");
         }
         if ( AV146EstadosGenericosID == 11 )
         {
            AddWhere(sWhereString, "(T1.[EstadosSolId] = 11)");
         }
         if ( AV146EstadosGenericosID == 12 )
         {
            AddWhere(sWhereString, "(T1.[EstadosSolId] = 12)");
         }
         scmdbuf += sWhereString;
         if ( AV11OrderedBy == 1 )
         {
            scmdbuf += " ORDER BY T1.[SolicitudesID] DESC, T1.[SolicitudesFechaInstalacion] DESC";
         }
         else if ( ( AV11OrderedBy == 2 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[SolicitudesID]";
         }
         else if ( ( AV11OrderedBy == 2 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[SolicitudesID] DESC";
         }
         else if ( ( AV11OrderedBy == 3 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[ProveedorID]";
         }
         else if ( ( AV11OrderedBy == 3 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[ProveedorID] DESC";
         }
         else if ( ( AV11OrderedBy == 4 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[SolicitudesFechaInstalacion]";
         }
         else if ( ( AV11OrderedBy == 4 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[SolicitudesFechaInstalacion] DESC";
         }
         else if ( ( AV11OrderedBy == 5 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY T7.[ProveedorNombre]";
         }
         else if ( ( AV11OrderedBy == 5 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T7.[ProveedorNombre] DESC";
         }
         else if ( ( AV11OrderedBy == 6 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[SolicitudesNombre]";
         }
         else if ( ( AV11OrderedBy == 6 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[SolicitudesNombre] DESC";
         }
         else if ( ( AV11OrderedBy == 7 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[SolicitudesTelefono]";
         }
         else if ( ( AV11OrderedBy == 7 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[SolicitudesTelefono] DESC";
         }
         else if ( ( AV11OrderedBy == 8 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[SolicitudesFechaAlta]";
         }
         else if ( ( AV11OrderedBy == 8 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[SolicitudesFechaAlta] DESC";
         }
         else if ( ( AV11OrderedBy == 9 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY T2.[DepartamentoDepartamento]";
         }
         else if ( ( AV11OrderedBy == 9 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T2.[DepartamentoDepartamento] DESC";
         }
         else if ( ( AV11OrderedBy == 10 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY T3.[DepartamentoMunicipioNombre]";
         }
         else if ( ( AV11OrderedBy == 10 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T3.[DepartamentoMunicipioNombre] DESC";
         }
         else if ( ( AV11OrderedBy == 11 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY T4.[ZonasNombre]";
         }
         else if ( ( AV11OrderedBy == 11 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T4.[ZonasNombre] DESC";
         }
         else if ( ( AV11OrderedBy == 12 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[SolicitudesDireccion]";
         }
         else if ( ( AV11OrderedBy == 12 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[SolicitudesDireccion] DESC";
         }
         else if ( ( AV11OrderedBy == 13 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[SolicitudesComentario]";
         }
         else if ( ( AV11OrderedBy == 13 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[SolicitudesComentario] DESC";
         }
         else if ( ( AV11OrderedBy == 14 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[SolicitudServicioSolCoti]";
         }
         else if ( ( AV11OrderedBy == 14 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[SolicitudServicioSolCoti] DESC";
         }
         else if ( ( AV11OrderedBy == 15 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[ProveedorNombreAux]";
         }
         else if ( ( AV11OrderedBy == 15 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[ProveedorNombreAux] DESC";
         }
         else if ( ( AV11OrderedBy == 16 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[SolicitudesPagado]";
         }
         else if ( ( AV11OrderedBy == 16 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[SolicitudesPagado] DESC";
         }
         else if ( ( AV11OrderedBy == 17 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[SolicitudServicioOrigenPago]";
         }
         else if ( ( AV11OrderedBy == 17 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[SolicitudServicioOrigenPago] DESC";
         }
         else if ( ( AV11OrderedBy == 18 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[SolicitudesSubTipo]";
         }
         else if ( ( AV11OrderedBy == 18 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[SolicitudesSubTipo] DESC";
         }
         else if ( ( AV11OrderedBy == 19 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[MudanzaId]";
         }
         else if ( ( AV11OrderedBy == 19 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[MudanzaId] DESC";
         }
         else if ( ( AV11OrderedBy == 20 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY T5.[ProveedorNombre]";
         }
         else if ( ( AV11OrderedBy == 20 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T5.[ProveedorNombre] DESC";
         }
         else if ( ( AV11OrderedBy == 21 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[SolicitudesDuplicado]";
         }
         else if ( ( AV11OrderedBy == 21 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[SolicitudesDuplicado] DESC";
         }
         else if ( ( AV11OrderedBy == 22 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[PostulacionesId]";
         }
         else if ( ( AV11OrderedBy == 22 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[PostulacionesId] DESC";
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
                     return conditional_P00AS2(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (GxSimpleCollection<string>)dynConstraints[3] , (string)dynConstraints[4] , (GxSimpleCollection<string>)dynConstraints[5] , (long)dynConstraints[6] , (GxSimpleCollection<long>)dynConstraints[7] , (int)dynConstraints[8] , (string)dynConstraints[9] , (long)dynConstraints[10] , (long)dynConstraints[11] , (long)dynConstraints[12] , (DateTime)dynConstraints[13] , (DateTime)dynConstraints[14] , (DateTime)dynConstraints[15] , (DateTime)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (int)dynConstraints[25] , (int)dynConstraints[26] , (int)dynConstraints[27] , (long)dynConstraints[28] , (long)dynConstraints[29] , (string)dynConstraints[30] , (string)dynConstraints[31] , (long)dynConstraints[32] , (long)dynConstraints[33] , (long)dynConstraints[34] , (long)dynConstraints[35] , (long)dynConstraints[36] , (long)dynConstraints[37] , (int)dynConstraints[38] , (int)dynConstraints[39] , (long)dynConstraints[40] , (string)dynConstraints[41] , (string)dynConstraints[42] , (string)dynConstraints[43] , (string)dynConstraints[44] , (string)dynConstraints[45] , (string)dynConstraints[46] , (string)dynConstraints[47] , (string)dynConstraints[48] , (string)dynConstraints[49] , (string)dynConstraints[50] , (DateTime)dynConstraints[51] , (DateTime)dynConstraints[52] , (long)dynConstraints[53] , (string)dynConstraints[54] , (long)dynConstraints[55] , (long)dynConstraints[56] , (DateTime)dynConstraints[57] , (DateTime)dynConstraints[58] , (DateTime)dynConstraints[59] , (short)dynConstraints[60] , (bool)dynConstraints[61] , (decimal)dynConstraints[62] , (decimal)dynConstraints[63] , (decimal)dynConstraints[64] );
         }
         return base.getDynamicStatement(cursor, context, dynConstraints);
      }

      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP00AS3;
          prmP00AS3 = new Object[] {
          new ParDef("@SolicitudesID",GXType.Decimal,18,0)
          };
          Object[] prmP00AS2;
          prmP00AS2 = new Object[] {
          new ParDef("@lV205Solicitudeswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV205Solicitudeswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV205Solicitudeswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV205Solicitudeswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV205Solicitudeswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV205Solicitudeswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV205Solicitudeswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV205Solicitudeswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV205Solicitudeswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV205Solicitudeswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV205Solicitudeswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@AV206Solicitudeswwds_2_tfsolicitudesid",GXType.Decimal,18,0) ,
          new ParDef("@AV207Solicitudeswwds_3_tfsolicitudesid_to",GXType.Decimal,18,0) ,
          new ParDef("@AV210Solicitudeswwds_6_tfproveedorid_sel",GXType.Decimal,18,0) ,
          new ParDef("@AV211Solicitudeswwds_7_tfsolicitudesfechainstalacion",GXType.Date,8,0) ,
          new ParDef("@AV212Solicitudeswwds_8_tfsolicitudesfechainstalacion_to",GXType.Date,8,0) ,
          new ParDef("@AV213Solicitudeswwds_9_tfsolicitudesfechaalta",GXType.Date,8,0) ,
          new ParDef("@AV214Solicitudeswwds_10_tfsolicitudesfechaalta_to",GXType.Date,8,0) ,
          new ParDef("@lV215Solicitudeswwds_11_tfdepartamentomunicipionombre",GXType.Char,120,0) ,
          new ParDef("@AV216Solicitudeswwds_12_tfdepartamentomunicipionombre_sel",GXType.NChar,120,0) ,
          new ParDef("@lV217Solicitudeswwds_13_tfzonasnombre",GXType.Char,120,0) ,
          new ParDef("@AV218Solicitudeswwds_14_tfzonasnombre_sel",GXType.NChar,120,0) ,
          new ParDef("@lV221Solicitudeswwds_17_tfsolicitudescomentario",GXType.VarChar,200,0) ,
          new ParDef("@AV222Solicitudeswwds_18_tfsolicitudescomentario_sel",GXType.NVarChar,200,0) ,
          new ParDef("@lV223Solicitudeswwds_19_tfproveedornombreaux",GXType.Char,80,0) ,
          new ParDef("@AV224Solicitudeswwds_20_tfproveedornombreaux_sel",GXType.NChar,80,0) ,
          new ParDef("@AV228Solicitudeswwds_24_tfmudanzaid",GXType.Decimal,18,0) ,
          new ParDef("@AV229Solicitudeswwds_25_tfmudanzaid_to",GXType.Decimal,18,0) ,
          new ParDef("@lV230Solicitudeswwds_26_tfstcomerciosnombre",GXType.Char,80,0) ,
          new ParDef("@AV231Solicitudeswwds_27_tfstcomerciosnombre_sel",GXType.NChar,80,0) ,
          new ParDef("@AV232Solicitudeswwds_28_tfsolicitudesduplicado",GXType.Decimal,18,0) ,
          new ParDef("@AV233Solicitudeswwds_29_tfsolicitudesduplicado_to",GXType.Decimal,18,0) ,
          new ParDef("@AV234Solicitudeswwds_30_tfpostulacionesid",GXType.Decimal,18,0) ,
          new ParDef("@AV235Solicitudeswwds_31_tfpostulacionesid_to",GXType.Decimal,18,0) ,
          new ParDef("@AV147FechaIni",GXType.Date,8,0) ,
          new ParDef("@AV148FechaFin",GXType.Date,8,0) ,
          new ParDef("@AV147FechaIni",GXType.Date,8,0) ,
          new ParDef("@AV148FechaFin",GXType.Date,8,0) ,
          new ParDef("@AV149ProveedorID",GXType.Decimal,18,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00AS2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00AS2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00AS3", "SELECT [SolicitudesID], [SolicitudesItemsID], [SolicitudItemsComision], [SolicitudItemsComisionTipo], [SolicitudItemsSR], [SolicitudesItemsCantidad], [SolicitudesItemsPrecioFinal] FROM [SolicitudesItems] WHERE [SolicitudesID] = @SolicitudesID ORDER BY [SolicitudesID] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00AS3,100, GxCacheFrequency.OFF ,true,false )
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
                ((long[]) buf[2])[0] = rslt.getLong(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((long[]) buf[4])[0] = rslt.getLong(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((long[]) buf[6])[0] = rslt.getLong(4);
                ((bool[]) buf[7])[0] = rslt.wasNull(4);
                ((int[]) buf[8])[0] = rslt.getInt(5);
                ((DateTime[]) buf[9])[0] = rslt.getGXDate(6);
                ((string[]) buf[10])[0] = rslt.getString(7, 80);
                ((string[]) buf[11])[0] = rslt.getString(8, 500);
                ((string[]) buf[12])[0] = rslt.getVarchar(9);
                ((string[]) buf[13])[0] = rslt.getString(10, 20);
                ((string[]) buf[14])[0] = rslt.getString(11, 100);
                ((string[]) buf[15])[0] = rslt.getString(12, 80);
                ((long[]) buf[16])[0] = rslt.getLong(13);
                ((bool[]) buf[17])[0] = rslt.wasNull(13);
                ((long[]) buf[18])[0] = rslt.getLong(14);
                ((bool[]) buf[19])[0] = rslt.wasNull(14);
                ((string[]) buf[20])[0] = rslt.getString(15, 80);
                ((long[]) buf[21])[0] = rslt.getLong(16);
                ((bool[]) buf[22])[0] = rslt.wasNull(16);
                ((string[]) buf[23])[0] = rslt.getString(17, 1);
                ((bool[]) buf[24])[0] = rslt.wasNull(17);
                ((string[]) buf[25])[0] = rslt.getString(18, 1);
                ((bool[]) buf[26])[0] = rslt.wasNull(18);
                ((string[]) buf[27])[0] = rslt.getString(19, 1);
                ((bool[]) buf[28])[0] = rslt.wasNull(19);
                ((string[]) buf[29])[0] = rslt.getString(20, 80);
                ((bool[]) buf[30])[0] = rslt.wasNull(20);
                ((string[]) buf[31])[0] = rslt.getLongVarchar(21);
                ((string[]) buf[32])[0] = rslt.getString(22, 120);
                ((string[]) buf[33])[0] = rslt.getString(23, 120);
                ((DateTime[]) buf[34])[0] = rslt.getGXDate(24);
                ((bool[]) buf[35])[0] = rslt.wasNull(24);
                ((DateTime[]) buf[36])[0] = rslt.getGXDate(25);
                ((long[]) buf[37])[0] = rslt.getLong(26);
                ((long[]) buf[38])[0] = rslt.getLong(27);
                ((string[]) buf[39])[0] = rslt.getString(28, 1);
                ((string[]) buf[40])[0] = rslt.getString(29, 1);
                ((decimal[]) buf[41])[0] = rslt.getDecimal(30);
                ((decimal[]) buf[42])[0] = rslt.getDecimal(31);
                ((decimal[]) buf[43])[0] = rslt.getDecimal(32);
                ((decimal[]) buf[44])[0] = rslt.getDecimal(33);
                ((bool[]) buf[45])[0] = rslt.wasNull(33);
                ((decimal[]) buf[46])[0] = rslt.getDecimal(34);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((decimal[]) buf[2])[0] = rslt.getDecimal(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 1);
                ((string[]) buf[4])[0] = rslt.getString(5, 1);
                ((short[]) buf[5])[0] = rslt.getShort(6);
                ((decimal[]) buf[6])[0] = rslt.getDecimal(7);
                ((bool[]) buf[7])[0] = rslt.wasNull(7);
                return;
       }
    }

 }

}

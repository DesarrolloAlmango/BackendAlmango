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
   public class historicosolicitudeswwexportreport : GXWebProcedure, System.Web.SessionState.IRequiresSessionState
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

      public historicosolicitudeswwexportreport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public historicosolicitudeswwexportreport( IGxContext context )
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
         setOutputFileName("HistoricoSolicitudesWWExportReport");
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
            new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWHistoricoSolicitudes", out  GXt_boolean1) ;
            AV8IsAuthorized = GXt_boolean1;
            if ( ! AV8IsAuthorized )
            {
               GXKey = Crypto.GetSiteKey( );
               GXEncryptionTmp = "wwpbaseobjects.notauthorized.aspx"+UrlEncode(StringUtil.RTrim(AV100Pgmname));
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
               AV81Title = context.GetMessage( "Lista de Historico Solicitudes", "");
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
            H4R0( true, 0) ;
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
            H4R0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "WWP_FullTextFilterDescription", ""), 25, Gx_line+0, 137, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV13FilterFullText, "")), 137, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         if ( ! ( (0==AV95TFHistoricoSolicitudesProvID) && (0==AV96TFHistoricoSolicitudesProvID_To) ) )
         {
            H4R0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Proveedor Id", ""), 25, Gx_line+0, 137, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV95TFHistoricoSolicitudesProvID), "ZZZZZZZZZZZZZZZZZ9")), 137, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV99TFHistoricoSolicitudesProvID_To_Description = StringUtil.Format( "%1 (%2)", context.GetMessage( "Proveedor Id", ""), context.GetMessage( "WWP_TSTo", ""), "", "", "", "", "", "", "");
            H4R0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV99TFHistoricoSolicitudesProvID_To_Description, "")), 25, Gx_line+0, 137, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV96TFHistoricoSolicitudesProvID_To), "ZZZZZZZZZZZZZZZZZ9")), 137, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV98TFHistoricoSolicitudesProvNombre_Sel)) )
         {
            AV69TempBoolean = (bool)(((StringUtil.StrCmp(AV98TFHistoricoSolicitudesProvNombre_Sel, "<#Empty#>")==0)));
            AV98TFHistoricoSolicitudesProvNombre_Sel = (AV69TempBoolean ? context.GetMessage( "WWP_TitleFilter_EmptyOption", "") : AV98TFHistoricoSolicitudesProvNombre_Sel);
            H4R0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Nombre del Comercio", ""), 25, Gx_line+0, 137, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV98TFHistoricoSolicitudesProvNombre_Sel, "")), 137, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV98TFHistoricoSolicitudesProvNombre_Sel = (AV69TempBoolean ? "<#Empty#>" : AV98TFHistoricoSolicitudesProvNombre_Sel);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV97TFHistoricoSolicitudesProvNombre)) )
            {
               H4R0( false, 20) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(context.GetMessage( "Nombre del Comercio", ""), 25, Gx_line+0, 137, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV97TFHistoricoSolicitudesProvNombre, "")), 137, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
      }

      protected void S121( )
      {
         /* 'PRINTCOLUMNTITLES' Routine */
         returnInSub = false;
         H4R0( false, 22) ;
         getPrinter().GxDrawLine(25, Gx_line+21, 789, Gx_line+21, 2, 8, 160, 134, 0) ;
         Gx_OldLine = Gx_line;
         Gx_line = (int)(Gx_line+22);
         H4R0( false, 37) ;
         getPrinter().GxAttris("Microsoft Sans Serif", 9, false, false, false, false, 0, 8, 160, 134, 0, 255, 255, 255) ;
         getPrinter().GxDrawText(context.GetMessage( "Solicitudes ID", ""), 30, Gx_line+10, 84, Gx_line+27, 2, 0, 0, 0) ;
         getPrinter().GxDrawText(context.GetMessage( "Estado", ""), 88, Gx_line+10, 142, Gx_line+27, 0, 0, 0, 0) ;
         getPrinter().GxDrawText(context.GetMessage( "Nombre | Contacto", ""), 146, Gx_line+10, 200, Gx_line+27, 0, 0, 0, 0) ;
         getPrinter().GxDrawText(context.GetMessage( "Telefono", ""), 204, Gx_line+10, 258, Gx_line+27, 0, 0, 0, 0) ;
         getPrinter().GxDrawText(context.GetMessage( "Mail", ""), 262, Gx_line+10, 316, Gx_line+27, 0, 0, 0, 0) ;
         getPrinter().GxDrawText(context.GetMessage( "Direccion", ""), 320, Gx_line+10, 374, Gx_line+27, 0, 0, 0, 0) ;
         getPrinter().GxDrawText(context.GetMessage( "Cotizacion", ""), 378, Gx_line+10, 432, Gx_line+27, 2, 0, 0, 0) ;
         getPrinter().GxDrawText(context.GetMessage( "Servicio PFinal", ""), 436, Gx_line+10, 490, Gx_line+27, 2, 0, 0, 0) ;
         getPrinter().GxDrawText(context.GetMessage( "Fecha Alta", ""), 494, Gx_line+10, 549, Gx_line+27, 0, 0, 0, 0) ;
         getPrinter().GxDrawText(context.GetMessage( "Origen Pago", ""), 553, Gx_line+10, 608, Gx_line+27, 0, 0, 0, 0) ;
         getPrinter().GxDrawText(context.GetMessage( "Pagado", ""), 612, Gx_line+10, 668, Gx_line+27, 0, 0, 0, 0) ;
         getPrinter().GxDrawText(context.GetMessage( "Proveedor Id", ""), 672, Gx_line+10, 727, Gx_line+27, 2, 0, 0, 0) ;
         getPrinter().GxDrawText(context.GetMessage( "Nombre del Comercio", ""), 731, Gx_line+10, 787, Gx_line+27, 0, 0, 0, 0) ;
         Gx_OldLine = Gx_line;
         Gx_line = (int)(Gx_line+37);
      }

      protected void S131( )
      {
         /* 'PRINTDATA' Routine */
         returnInSub = false;
         AV104Historicosolicitudeswwds_1_filterfulltext = AV13FilterFullText;
         AV105Historicosolicitudeswwds_2_tfhistoricosolicitudesprovid = AV95TFHistoricoSolicitudesProvID;
         AV106Historicosolicitudeswwds_3_tfhistoricosolicitudesprovid_to = AV96TFHistoricoSolicitudesProvID_To;
         AV107Historicosolicitudeswwds_4_tfhistoricosolicitudesprovnombre = AV97TFHistoricoSolicitudesProvNombre;
         AV108Historicosolicitudeswwds_5_tfhistoricosolicitudesprovnombre_sel = AV98TFHistoricoSolicitudesProvNombre_Sel;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV105Historicosolicitudeswwds_2_tfhistoricosolicitudesprovid ,
                                              AV106Historicosolicitudeswwds_3_tfhistoricosolicitudesprovid_to ,
                                              AV108Historicosolicitudeswwds_5_tfhistoricosolicitudesprovnombre_sel ,
                                              AV107Historicosolicitudeswwds_4_tfhistoricosolicitudesprovnombre ,
                                              AV86EstadosGenericosID ,
                                              AV89ProveedorID ,
                                              A633HistoricoSolicitudesProvID ,
                                              A634HistoricoSolicitudesProvNombre ,
                                              A131EstadosSolId ,
                                              AV11OrderedBy ,
                                              AV12OrderedDsc ,
                                              AV104Historicosolicitudeswwds_1_filterfulltext ,
                                              A153HistoricoSolicitudesID ,
                                              A288HistoricoSolicitudesNombre ,
                                              A289HistoricoSolicitudesTelefono ,
                                              A290HistoricoSolicitudesMail ,
                                              A291HistoricoSolicitudesDireccion ,
                                              A302HistoricoSolicitudServicioPFin ,
                                              A306HistoricoSolicitudesFechaAlta ,
                                              AV87FechaIni ,
                                              AV88FechaFin } ,
                                              new int[]{
                                              TypeConstants.LONG, TypeConstants.LONG, TypeConstants.INT, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.INT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.LONG, TypeConstants.BOOLEAN,
                                              TypeConstants.DECIMAL, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE
                                              }
         });
         lV107Historicosolicitudeswwds_4_tfhistoricosolicitudesprovnombre = StringUtil.PadR( StringUtil.RTrim( AV107Historicosolicitudeswwds_4_tfhistoricosolicitudesprovnombre), 120, "%");
         /* Using cursor P004R2 */
         pr_default.execute(0, new Object[] {AV87FechaIni, AV88FechaFin, AV105Historicosolicitudeswwds_2_tfhistoricosolicitudesprovid, AV106Historicosolicitudeswwds_3_tfhistoricosolicitudesprovid_to, lV107Historicosolicitudeswwds_4_tfhistoricosolicitudesprovnombre, AV108Historicosolicitudeswwds_5_tfhistoricosolicitudesprovnombre_sel, AV86EstadosGenericosID, AV89ProveedorID});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A130EstadosSolTipo = P004R2_A130EstadosSolTipo[0];
            A306HistoricoSolicitudesFechaAlta = P004R2_A306HistoricoSolicitudesFechaAlta[0];
            A131EstadosSolId = P004R2_A131EstadosSolId[0];
            A291HistoricoSolicitudesDireccion = P004R2_A291HistoricoSolicitudesDireccion[0];
            A290HistoricoSolicitudesMail = P004R2_A290HistoricoSolicitudesMail[0];
            n290HistoricoSolicitudesMail = P004R2_n290HistoricoSolicitudesMail[0];
            A289HistoricoSolicitudesTelefono = P004R2_A289HistoricoSolicitudesTelefono[0];
            A288HistoricoSolicitudesNombre = P004R2_A288HistoricoSolicitudesNombre[0];
            A153HistoricoSolicitudesID = P004R2_A153HistoricoSolicitudesID[0];
            A634HistoricoSolicitudesProvNombre = P004R2_A634HistoricoSolicitudesProvNombre[0];
            A633HistoricoSolicitudesProvID = P004R2_A633HistoricoSolicitudesProvID[0];
            A442HistoricoSolicitudesPagado = P004R2_A442HistoricoSolicitudesPagado[0];
            A439HistoricoSolicitudesOrigenPago = P004R2_A439HistoricoSolicitudesOrigenPago[0];
            A132EstadosSolNombre = P004R2_A132EstadosSolNombre[0];
            A299HistoricoSolicitudesCotizacion = P004R2_A299HistoricoSolicitudesCotizacion[0];
            A132EstadosSolNombre = P004R2_A132EstadosSolNombre[0];
            GetHistoricoSolicitudesTotal( A153HistoricoSolicitudesID) ;
            if ( ( A299HistoricoSolicitudesCotizacion == Convert.ToDecimal( 0 )) )
            {
               A302HistoricoSolicitudServicioPFin = A300HistoricoSolicitudesTotal;
            }
            else
            {
               if ( ( A299HistoricoSolicitudesCotizacion > Convert.ToDecimal( 0 )) )
               {
                  A302HistoricoSolicitudServicioPFin = A299HistoricoSolicitudesCotizacion;
               }
               else
               {
                  A302HistoricoSolicitudServicioPFin = 0;
               }
            }
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV104Historicosolicitudeswwds_1_filterfulltext)) || ( ( StringUtil.Like( StringUtil.Str( (decimal)(A153HistoricoSolicitudesID), 18, 0) , StringUtil.PadR( "%" + AV104Historicosolicitudeswwds_1_filterfulltext , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A288HistoricoSolicitudesNombre) , StringUtil.PadR( "%" + StringUtil.Upper( AV104Historicosolicitudeswwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A289HistoricoSolicitudesTelefono) , StringUtil.PadR( "%" + StringUtil.Upper( AV104Historicosolicitudeswwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A290HistoricoSolicitudesMail) , StringUtil.PadR( "%" + StringUtil.Upper( AV104Historicosolicitudeswwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A291HistoricoSolicitudesDireccion) , StringUtil.PadR( "%" + StringUtil.Upper( AV104Historicosolicitudeswwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Str( A302HistoricoSolicitudServicioPFin, 18, 2) , StringUtil.PadR( "%" + AV104Historicosolicitudeswwds_1_filterfulltext , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A634HistoricoSolicitudesProvNombre) , StringUtil.PadR( "%" + StringUtil.Upper( AV104Historicosolicitudeswwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) ) )
            {
               AV38HistoricoSolicitudesPagadoDescription = "";
               if ( StringUtil.StrCmp(StringUtil.Trim( A442HistoricoSolicitudesPagado), "S") == 0 )
               {
                  AV38HistoricoSolicitudesPagadoDescription = context.GetMessage( "Pagado", "");
               }
               else if ( StringUtil.StrCmp(StringUtil.Trim( A442HistoricoSolicitudesPagado), "N") == 0 )
               {
                  AV38HistoricoSolicitudesPagadoDescription = context.GetMessage( "Pendiente de Pago", "");
               }
               /* Execute user subroutine: 'BEFOREPRINTLINE' */
               S144 ();
               if ( returnInSub )
               {
                  pr_default.close(0);
                  returnInSub = true;
                  if (true) return;
               }
               H4R0( false, 66) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(A153HistoricoSolicitudesID), "ZZZZZZZZZZZZZZZZZ9")), 30, Gx_line+10, 84, Gx_line+55, 2+16, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A132EstadosSolNombre, "")), 88, Gx_line+10, 142, Gx_line+55, 0+16, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A288HistoricoSolicitudesNombre, "")), 146, Gx_line+10, 200, Gx_line+55, 0+16, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A289HistoricoSolicitudesTelefono, "")), 204, Gx_line+10, 258, Gx_line+55, 0+16, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A290HistoricoSolicitudesMail, "")), 262, Gx_line+10, 316, Gx_line+55, 0+16, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A291HistoricoSolicitudesDireccion, "")), 320, Gx_line+10, 374, Gx_line+55, 0+16, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( A299HistoricoSolicitudesCotizacion, "ZZZZZZ,ZZZ,ZZZ,ZZ9.99")), 378, Gx_line+10, 432, Gx_line+55, 2+16, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( A302HistoricoSolicitudServicioPFin, "ZZZZZZZZZZZZZZ9.99")), 436, Gx_line+10, 490, Gx_line+55, 2+16, 0, 0, 0) ;
               getPrinter().GxDrawText(context.localUtil.Format( A306HistoricoSolicitudesFechaAlta, "99/99/99"), 494, Gx_line+10, 549, Gx_line+55, 0+16, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A439HistoricoSolicitudesOrigenPago, "")), 553, Gx_line+10, 608, Gx_line+55, 0+16, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV38HistoricoSolicitudesPagadoDescription, "")), 612, Gx_line+10, 668, Gx_line+55, 0+16, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(A633HistoricoSolicitudesProvID), "ZZZZZZZZZZZZZZZZZ9")), 672, Gx_line+10, 727, Gx_line+55, 2+16, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A634HistoricoSolicitudesProvNombre, "")), 731, Gx_line+10, 787, Gx_line+55, 0+16, 0, 0, 0) ;
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
         if ( StringUtil.StrCmp(AV39Session.Get("HistoricoSolicitudesWWGridState"), "") == 0 )
         {
            AV41GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "HistoricoSolicitudesWWGridState"), null, "", "");
         }
         else
         {
            AV41GridState.FromXml(AV39Session.Get("HistoricoSolicitudesWWGridState"), null, "", "");
         }
         AV11OrderedBy = AV41GridState.gxTpr_Orderedby;
         AV12OrderedDsc = AV41GridState.gxTpr_Ordereddsc;
         AV109GXV1 = 1;
         while ( AV109GXV1 <= AV41GridState.gxTpr_Filtervalues.Count )
         {
            AV42GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV41GridState.gxTpr_Filtervalues.Item(AV109GXV1));
            if ( StringUtil.StrCmp(AV42GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV13FilterFullText = AV42GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV42GridStateFilterValue.gxTpr_Name, "TFHISTORICOSOLICITUDESPROVID") == 0 )
            {
               AV95TFHistoricoSolicitudesProvID = (long)(Math.Round(NumberUtil.Val( AV42GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV96TFHistoricoSolicitudesProvID_To = (long)(Math.Round(NumberUtil.Val( AV42GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV42GridStateFilterValue.gxTpr_Name, "TFHISTORICOSOLICITUDESPROVNOMBRE") == 0 )
            {
               AV97TFHistoricoSolicitudesProvNombre = AV42GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV42GridStateFilterValue.gxTpr_Name, "TFHISTORICOSOLICITUDESPROVNOMBRE_SEL") == 0 )
            {
               AV98TFHistoricoSolicitudesProvNombre_Sel = AV42GridStateFilterValue.gxTpr_Value;
            }
            AV109GXV1 = (int)(AV109GXV1+1);
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

      protected void H4R0( bool bFoot ,
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
                  AV79PageInfo = context.GetMessage( "Page: ", "") + StringUtil.Trim( StringUtil.Str( (decimal)(Gx_page), 6, 0));
                  AV76DateInfo = context.GetMessage( "Date: ", "") + context.localUtil.Format( Gx_date, "99/99/99");
                  getPrinter().GxDrawRect(0, Gx_line+5, 819, Gx_line+40, 1, 0, 0, 0, 1, 8, 160, 134, 1, 1, 1, 1, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV79PageInfo, "")), 30, Gx_line+15, 409, Gx_line+30, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV76DateInfo, "")), 409, Gx_line+15, 789, Gx_line+30, 2, 0, 0, 0) ;
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
               AV74AppName = context.GetMessage( "DVelop Software Solutions", "");
               AV80Phone = "+1 550 8923";
               AV78Mail = "info@mail.com";
               AV82Website = "http://www.web.com";
               AV71AddressLine1 = "French Boulevard 2859";
               AV72AddressLine2 = "Downtown";
               AV73AddressLine3 = "Paris, France";
               getPrinter().GxDrawRect(0, Gx_line+0, 819, Gx_line+108, 1, 0, 0, 0, 1, 8, 160, 134, 1, 1, 1, 1, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV74AppName, "")), 30, Gx_line+30, 283, Gx_line+45, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 20, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV81Title, "")), 30, Gx_line+45, 283, Gx_line+78, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV80Phone, "")), 283, Gx_line+30, 536, Gx_line+46, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV78Mail, "")), 283, Gx_line+46, 536, Gx_line+62, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV82Website, "")), 283, Gx_line+62, 536, Gx_line+78, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV71AddressLine1, "")), 536, Gx_line+30, 789, Gx_line+46, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV72AddressLine2, "")), 536, Gx_line+46, 789, Gx_line+62, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV73AddressLine3, "")), 536, Gx_line+62, 789, Gx_line+78, 2, 0, 0, 0) ;
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

      protected void GetHistoricoSolicitudesTotal( long A153HistoricoSolicitudesID )
      {
         /* Create private dbobjects */
         /* Navigation */
         A300HistoricoSolicitudesTotal = 0;
         /* Using cursor P004R3 */
         pr_default.execute(1, new Object[] {A153HistoricoSolicitudesID});
         while ( (pr_default.getStatus(1) != 101) && ( P004R3_A153HistoricoSolicitudesID[0] == A153HistoricoSolicitudesID ) )
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( P004R3_A296HistoricoSolicitudesItemsSR[0])) || ( StringUtil.StrCmp(P004R3_A297HistoricoSolicitudesItemsCT[0], "N") == 0 ) )
            {
               A294HItemsSolicitudesItemsPrecioIn = (decimal)(P004R3_A295HItemsInventarioPrecioFinal[0]*P004R3_A293HItemsSolicitudesItemsCantidad[0]);
            }
            else
            {
               if ( ( StringUtil.StrCmp(P004R3_A297HistoricoSolicitudesItemsCT[0], "F") == 0 ) && ( StringUtil.StrCmp(P004R3_A296HistoricoSolicitudesItemsSR[0], "R") == 0 ) )
               {
                  A294HItemsSolicitudesItemsPrecioIn = (decimal)((P004R3_A295HItemsInventarioPrecioFinal[0]*P004R3_A293HItemsSolicitudesItemsCantidad[0])-(P004R3_A298HistoricoSolicitudesItemsComis[0]*P004R3_A293HItemsSolicitudesItemsCantidad[0]));
               }
               else
               {
                  if ( ( StringUtil.StrCmp(P004R3_A297HistoricoSolicitudesItemsCT[0], "F") == 0 ) && ( StringUtil.StrCmp(P004R3_A296HistoricoSolicitudesItemsSR[0], "S") == 0 ) )
                  {
                     A294HItemsSolicitudesItemsPrecioIn = (decimal)((P004R3_A295HItemsInventarioPrecioFinal[0]*P004R3_A293HItemsSolicitudesItemsCantidad[0])+(P004R3_A298HistoricoSolicitudesItemsComis[0]*P004R3_A293HItemsSolicitudesItemsCantidad[0]));
                  }
                  else
                  {
                     if ( ( StringUtil.StrCmp(P004R3_A297HistoricoSolicitudesItemsCT[0], "P") == 0 ) && ( StringUtil.StrCmp(P004R3_A296HistoricoSolicitudesItemsSR[0], "R") == 0 ) )
                     {
                        A294HItemsSolicitudesItemsPrecioIn = (decimal)((P004R3_A295HItemsInventarioPrecioFinal[0]*P004R3_A293HItemsSolicitudesItemsCantidad[0])-((P004R3_A295HItemsInventarioPrecioFinal[0]*P004R3_A293HItemsSolicitudesItemsCantidad[0])*(P004R3_A298HistoricoSolicitudesItemsComis[0]/ (decimal)(100))));
                     }
                     else
                     {
                        if ( ( StringUtil.StrCmp(P004R3_A297HistoricoSolicitudesItemsCT[0], "P") == 0 ) && ( StringUtil.StrCmp(P004R3_A296HistoricoSolicitudesItemsSR[0], "S") == 0 ) )
                        {
                           A294HItemsSolicitudesItemsPrecioIn = (decimal)((P004R3_A295HItemsInventarioPrecioFinal[0]*P004R3_A293HItemsSolicitudesItemsCantidad[0])+((P004R3_A295HItemsInventarioPrecioFinal[0]*P004R3_A293HItemsSolicitudesItemsCantidad[0])*(P004R3_A298HistoricoSolicitudesItemsComis[0]/ (decimal)(100))));
                        }
                        else
                        {
                           A294HItemsSolicitudesItemsPrecioIn = 0;
                        }
                     }
                  }
               }
            }
            A300HistoricoSolicitudesTotal = (decimal)(A300HistoricoSolicitudesTotal+A294HItemsSolicitudesItemsPrecioIn);
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
         AV100Pgmname = "";
         GXEncryptionTmp = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV81Title = "";
         AV13FilterFullText = "";
         AV99TFHistoricoSolicitudesProvID_To_Description = "";
         AV98TFHistoricoSolicitudesProvNombre_Sel = "";
         AV97TFHistoricoSolicitudesProvNombre = "";
         AV104Historicosolicitudeswwds_1_filterfulltext = "";
         AV107Historicosolicitudeswwds_4_tfhistoricosolicitudesprovnombre = "";
         AV108Historicosolicitudeswwds_5_tfhistoricosolicitudesprovnombre_sel = "";
         lV104Historicosolicitudeswwds_1_filterfulltext = "";
         lV107Historicosolicitudeswwds_4_tfhistoricosolicitudesprovnombre = "";
         A634HistoricoSolicitudesProvNombre = "";
         A288HistoricoSolicitudesNombre = "";
         A289HistoricoSolicitudesTelefono = "";
         A290HistoricoSolicitudesMail = "";
         A291HistoricoSolicitudesDireccion = "";
         A306HistoricoSolicitudesFechaAlta = DateTime.MinValue;
         AV87FechaIni = DateTime.MinValue;
         AV88FechaFin = DateTime.MinValue;
         P004R2_A130EstadosSolTipo = new string[] {""} ;
         P004R2_A306HistoricoSolicitudesFechaAlta = new DateTime[] {DateTime.MinValue} ;
         P004R2_A131EstadosSolId = new int[1] ;
         P004R2_A291HistoricoSolicitudesDireccion = new string[] {""} ;
         P004R2_A290HistoricoSolicitudesMail = new string[] {""} ;
         P004R2_n290HistoricoSolicitudesMail = new bool[] {false} ;
         P004R2_A289HistoricoSolicitudesTelefono = new string[] {""} ;
         P004R2_A288HistoricoSolicitudesNombre = new string[] {""} ;
         P004R2_A153HistoricoSolicitudesID = new long[1] ;
         P004R2_A634HistoricoSolicitudesProvNombre = new string[] {""} ;
         P004R2_A633HistoricoSolicitudesProvID = new long[1] ;
         P004R2_A442HistoricoSolicitudesPagado = new string[] {""} ;
         P004R2_A439HistoricoSolicitudesOrigenPago = new string[] {""} ;
         P004R2_A132EstadosSolNombre = new string[] {""} ;
         P004R2_A299HistoricoSolicitudesCotizacion = new decimal[1] ;
         A130EstadosSolTipo = "";
         A442HistoricoSolicitudesPagado = "";
         A439HistoricoSolicitudesOrigenPago = "";
         A132EstadosSolNombre = "";
         AV38HistoricoSolicitudesPagadoDescription = "";
         AV39Session = context.GetSession();
         AV41GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV42GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV79PageInfo = "";
         AV76DateInfo = "";
         Gx_date = DateTime.MinValue;
         AV74AppName = "";
         AV80Phone = "";
         AV78Mail = "";
         AV82Website = "";
         AV71AddressLine1 = "";
         AV72AddressLine2 = "";
         AV73AddressLine3 = "";
         P004R3_A153HistoricoSolicitudesID = new long[1] ;
         P004R3_A154HistoricoSolicitudesItemsID = new short[1] ;
         P004R3_A298HistoricoSolicitudesItemsComis = new decimal[1] ;
         P004R3_A297HistoricoSolicitudesItemsCT = new string[] {""} ;
         P004R3_A296HistoricoSolicitudesItemsSR = new string[] {""} ;
         P004R3_A293HItemsSolicitudesItemsCantidad = new short[1] ;
         P004R3_A295HItemsInventarioPrecioFinal = new short[1] ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.historicosolicitudeswwexportreport__default(),
            new Object[][] {
                new Object[] {
               P004R2_A130EstadosSolTipo, P004R2_A306HistoricoSolicitudesFechaAlta, P004R2_A131EstadosSolId, P004R2_A291HistoricoSolicitudesDireccion, P004R2_A290HistoricoSolicitudesMail, P004R2_n290HistoricoSolicitudesMail, P004R2_A289HistoricoSolicitudesTelefono, P004R2_A288HistoricoSolicitudesNombre, P004R2_A153HistoricoSolicitudesID, P004R2_A634HistoricoSolicitudesProvNombre,
               P004R2_A633HistoricoSolicitudesProvID, P004R2_A442HistoricoSolicitudesPagado, P004R2_A439HistoricoSolicitudesOrigenPago, P004R2_A132EstadosSolNombre, P004R2_A299HistoricoSolicitudesCotizacion
               }
               , new Object[] {
               P004R3_A153HistoricoSolicitudesID, P004R3_A154HistoricoSolicitudesItemsID, P004R3_A298HistoricoSolicitudesItemsComis, P004R3_A297HistoricoSolicitudesItemsCT, P004R3_A296HistoricoSolicitudesItemsSR, P004R3_A293HItemsSolicitudesItemsCantidad, P004R3_A295HItemsInventarioPrecioFinal
               }
            }
         );
         Gx_date = DateTimeUtil.Today( context);
         AV100Pgmname = "HistoricoSolicitudesWWExportReport";
         /* GeneXus formulas. */
         Gx_line = 0;
         Gx_date = DateTimeUtil.Today( context);
         AV100Pgmname = "HistoricoSolicitudesWWExportReport";
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
      private int AV86EstadosGenericosID ;
      private int A131EstadosSolId ;
      private int AV109GXV1 ;
      private long AV95TFHistoricoSolicitudesProvID ;
      private long AV96TFHistoricoSolicitudesProvID_To ;
      private long AV105Historicosolicitudeswwds_2_tfhistoricosolicitudesprovid ;
      private long AV106Historicosolicitudeswwds_3_tfhistoricosolicitudesprovid_to ;
      private long AV89ProveedorID ;
      private long A633HistoricoSolicitudesProvID ;
      private long A153HistoricoSolicitudesID ;
      private decimal A302HistoricoSolicitudServicioPFin ;
      private decimal A299HistoricoSolicitudesCotizacion ;
      private decimal A300HistoricoSolicitudesTotal ;
      private decimal A294HItemsSolicitudesItemsPrecioIn ;
      private string GXKey ;
      private string gxfirstwebparm ;
      private string AV100Pgmname ;
      private string GXEncryptionTmp ;
      private string AV98TFHistoricoSolicitudesProvNombre_Sel ;
      private string AV97TFHistoricoSolicitudesProvNombre ;
      private string AV107Historicosolicitudeswwds_4_tfhistoricosolicitudesprovnombre ;
      private string AV108Historicosolicitudeswwds_5_tfhistoricosolicitudesprovnombre_sel ;
      private string lV107Historicosolicitudeswwds_4_tfhistoricosolicitudesprovnombre ;
      private string A634HistoricoSolicitudesProvNombre ;
      private string A288HistoricoSolicitudesNombre ;
      private string A289HistoricoSolicitudesTelefono ;
      private string A130EstadosSolTipo ;
      private string A442HistoricoSolicitudesPagado ;
      private string A439HistoricoSolicitudesOrigenPago ;
      private string A132EstadosSolNombre ;
      private DateTime A306HistoricoSolicitudesFechaAlta ;
      private DateTime AV87FechaIni ;
      private DateTime AV88FechaFin ;
      private DateTime Gx_date ;
      private bool entryPointCalled ;
      private bool AV8IsAuthorized ;
      private bool GXt_boolean1 ;
      private bool returnInSub ;
      private bool AV69TempBoolean ;
      private bool AV12OrderedDsc ;
      private bool n290HistoricoSolicitudesMail ;
      private string AV81Title ;
      private string AV13FilterFullText ;
      private string AV99TFHistoricoSolicitudesProvID_To_Description ;
      private string AV104Historicosolicitudeswwds_1_filterfulltext ;
      private string lV104Historicosolicitudeswwds_1_filterfulltext ;
      private string A290HistoricoSolicitudesMail ;
      private string A291HistoricoSolicitudesDireccion ;
      private string AV38HistoricoSolicitudesPagadoDescription ;
      private string AV79PageInfo ;
      private string AV76DateInfo ;
      private string AV74AppName ;
      private string AV80Phone ;
      private string AV78Mail ;
      private string AV82Website ;
      private string AV71AddressLine1 ;
      private string AV72AddressLine2 ;
      private string AV73AddressLine3 ;
      private IGxSession AV39Session ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private IDataStoreProvider pr_default ;
      private string[] P004R2_A130EstadosSolTipo ;
      private DateTime[] P004R2_A306HistoricoSolicitudesFechaAlta ;
      private int[] P004R2_A131EstadosSolId ;
      private string[] P004R2_A291HistoricoSolicitudesDireccion ;
      private string[] P004R2_A290HistoricoSolicitudesMail ;
      private bool[] P004R2_n290HistoricoSolicitudesMail ;
      private string[] P004R2_A289HistoricoSolicitudesTelefono ;
      private string[] P004R2_A288HistoricoSolicitudesNombre ;
      private long[] P004R2_A153HistoricoSolicitudesID ;
      private string[] P004R2_A634HistoricoSolicitudesProvNombre ;
      private long[] P004R2_A633HistoricoSolicitudesProvID ;
      private string[] P004R2_A442HistoricoSolicitudesPagado ;
      private string[] P004R2_A439HistoricoSolicitudesOrigenPago ;
      private string[] P004R2_A132EstadosSolNombre ;
      private decimal[] P004R2_A299HistoricoSolicitudesCotizacion ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV41GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV42GridStateFilterValue ;
      private long[] P004R3_A153HistoricoSolicitudesID ;
      private short[] P004R3_A154HistoricoSolicitudesItemsID ;
      private decimal[] P004R3_A298HistoricoSolicitudesItemsComis ;
      private string[] P004R3_A297HistoricoSolicitudesItemsCT ;
      private string[] P004R3_A296HistoricoSolicitudesItemsSR ;
      private short[] P004R3_A293HItemsSolicitudesItemsCantidad ;
      private short[] P004R3_A295HItemsInventarioPrecioFinal ;
   }

   public class historicosolicitudeswwexportreport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P004R2( IGxContext context ,
                                             long AV105Historicosolicitudeswwds_2_tfhistoricosolicitudesprovid ,
                                             long AV106Historicosolicitudeswwds_3_tfhistoricosolicitudesprovid_to ,
                                             string AV108Historicosolicitudeswwds_5_tfhistoricosolicitudesprovnombre_sel ,
                                             string AV107Historicosolicitudeswwds_4_tfhistoricosolicitudesprovnombre ,
                                             int AV86EstadosGenericosID ,
                                             long AV89ProveedorID ,
                                             long A633HistoricoSolicitudesProvID ,
                                             string A634HistoricoSolicitudesProvNombre ,
                                             int A131EstadosSolId ,
                                             short AV11OrderedBy ,
                                             bool AV12OrderedDsc ,
                                             string AV104Historicosolicitudeswwds_1_filterfulltext ,
                                             long A153HistoricoSolicitudesID ,
                                             string A288HistoricoSolicitudesNombre ,
                                             string A289HistoricoSolicitudesTelefono ,
                                             string A290HistoricoSolicitudesMail ,
                                             string A291HistoricoSolicitudesDireccion ,
                                             decimal A302HistoricoSolicitudServicioPFin ,
                                             DateTime A306HistoricoSolicitudesFechaAlta ,
                                             DateTime AV87FechaIni ,
                                             DateTime AV88FechaFin )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int2 = new short[8];
         Object[] GXv_Object3 = new Object[2];
         scmdbuf = "SELECT T1.[EstadosSolTipo] AS EstadosSolTipo, T1.[HistoricoSolicitudesFechaAlta], T1.[EstadosSolId] AS EstadosSolId, T1.[HistoricoSolicitudesDireccion], T1.[HistoricoSolicitudesMail], T1.[HistoricoSolicitudesTelefono], T1.[HistoricoSolicitudesNombre], T1.[HistoricoSolicitudesID], T1.[HistoricoSolicitudesProvNombre], T1.[HistoricoSolicitudesProvID], T1.[HistoricoSolicitudesPagado], T1.[HistoricoSolicitudesOrigenPago], T2.[EstadosGenericosNombre] AS EstadosSolNombre, T1.[HistoricoSolicitudesCotizacion] FROM ([HistoricoSolicitudes] T1 INNER JOIN [EstadosGenericos] T2 ON T2.[EstadosTipo] = T1.[EstadosSolTipo] AND T2.[EstadosGenericosId] = T1.[EstadosSolId])";
         AddWhere(sWhereString, "(T1.[HistoricoSolicitudesFechaAlta] >= @AV87FechaIni and T1.[HistoricoSolicitudesFechaAlta] <= @AV88FechaFin)");
         if ( ! (0==AV105Historicosolicitudeswwds_2_tfhistoricosolicitudesprovid) )
         {
            AddWhere(sWhereString, "(T1.[HistoricoSolicitudesProvID] >= @AV105Historicosolicitudeswwds_2_tfhistoricosolicitudesprovid)");
         }
         else
         {
            GXv_int2[2] = 1;
         }
         if ( ! (0==AV106Historicosolicitudeswwds_3_tfhistoricosolicitudesprovid_to) )
         {
            AddWhere(sWhereString, "(T1.[HistoricoSolicitudesProvID] <= @AV106Historicosolicitudeswwds_3_tfhistoricosolicitudesprovid_to)");
         }
         else
         {
            GXv_int2[3] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV108Historicosolicitudeswwds_5_tfhistoricosolicitudesprovnombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV107Historicosolicitudeswwds_4_tfhistoricosolicitudesprovnombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[HistoricoSolicitudesProvNombre]) like UPPER(@lV107Historicosolicitudeswwds_4_tfhistoricosolicitudesprovnombre))");
         }
         else
         {
            GXv_int2[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV108Historicosolicitudeswwds_5_tfhistoricosolicitudesprovnombre_sel)) && ! ( StringUtil.StrCmp(AV108Historicosolicitudeswwds_5_tfhistoricosolicitudesprovnombre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[HistoricoSolicitudesProvNombre] = @AV108Historicosolicitudeswwds_5_tfhistoricosolicitudesprovnombre_sel)");
         }
         else
         {
            GXv_int2[5] = 1;
         }
         if ( StringUtil.StrCmp(AV108Historicosolicitudeswwds_5_tfhistoricosolicitudesprovnombre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[HistoricoSolicitudesProvNombre] = ''))");
         }
         if ( ! ( AV86EstadosGenericosID == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[EstadosSolId] = @AV86EstadosGenericosID)");
         }
         else
         {
            GXv_int2[6] = 1;
         }
         if ( ! (0==AV89ProveedorID) )
         {
            AddWhere(sWhereString, "(T1.[HistoricoSolicitudesProvID] = @AV89ProveedorID)");
         }
         else
         {
            GXv_int2[7] = 1;
         }
         scmdbuf += sWhereString;
         if ( ( AV11OrderedBy == 1 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[HistoricoSolicitudesID]";
         }
         else if ( ( AV11OrderedBy == 1 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[HistoricoSolicitudesID] DESC";
         }
         else if ( ( AV11OrderedBy == 2 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY T2.[EstadosGenericosNombre]";
         }
         else if ( ( AV11OrderedBy == 2 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T2.[EstadosGenericosNombre] DESC";
         }
         else if ( ( AV11OrderedBy == 3 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[HistoricoSolicitudesNombre]";
         }
         else if ( ( AV11OrderedBy == 3 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[HistoricoSolicitudesNombre] DESC";
         }
         else if ( ( AV11OrderedBy == 4 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[HistoricoSolicitudesTelefono]";
         }
         else if ( ( AV11OrderedBy == 4 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[HistoricoSolicitudesTelefono] DESC";
         }
         else if ( ( AV11OrderedBy == 5 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[HistoricoSolicitudesMail]";
         }
         else if ( ( AV11OrderedBy == 5 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[HistoricoSolicitudesMail] DESC";
         }
         else if ( ( AV11OrderedBy == 6 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[HistoricoSolicitudesDireccion]";
         }
         else if ( ( AV11OrderedBy == 6 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[HistoricoSolicitudesDireccion] DESC";
         }
         else if ( ( AV11OrderedBy == 7 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[HistoricoSolicitudesCotizacion]";
         }
         else if ( ( AV11OrderedBy == 7 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[HistoricoSolicitudesCotizacion] DESC";
         }
         else if ( ( AV11OrderedBy == 8 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[HistoricoSolicitudesFechaAlta]";
         }
         else if ( ( AV11OrderedBy == 8 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[HistoricoSolicitudesFechaAlta] DESC";
         }
         else if ( ( AV11OrderedBy == 9 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[HistoricoSolicitudesOrigenPago]";
         }
         else if ( ( AV11OrderedBy == 9 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[HistoricoSolicitudesOrigenPago] DESC";
         }
         else if ( ( AV11OrderedBy == 10 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[HistoricoSolicitudesPagado]";
         }
         else if ( ( AV11OrderedBy == 10 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[HistoricoSolicitudesPagado] DESC";
         }
         else if ( ( AV11OrderedBy == 11 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[HistoricoSolicitudesProvID]";
         }
         else if ( ( AV11OrderedBy == 11 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[HistoricoSolicitudesProvID] DESC";
         }
         else if ( ( AV11OrderedBy == 12 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[HistoricoSolicitudesProvNombre]";
         }
         else if ( ( AV11OrderedBy == 12 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[HistoricoSolicitudesProvNombre] DESC";
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
                     return conditional_P004R2(context, (long)dynConstraints[0] , (long)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (int)dynConstraints[4] , (long)dynConstraints[5] , (long)dynConstraints[6] , (string)dynConstraints[7] , (int)dynConstraints[8] , (short)dynConstraints[9] , (bool)dynConstraints[10] , (string)dynConstraints[11] , (long)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (decimal)dynConstraints[17] , (DateTime)dynConstraints[18] , (DateTime)dynConstraints[19] , (DateTime)dynConstraints[20] );
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
          Object[] prmP004R3;
          prmP004R3 = new Object[] {
          new ParDef("@HistoricoSolicitudesID",GXType.Decimal,18,0)
          };
          Object[] prmP004R2;
          prmP004R2 = new Object[] {
          new ParDef("@AV87FechaIni",GXType.Date,8,0) ,
          new ParDef("@AV88FechaFin",GXType.Date,8,0) ,
          new ParDef("@AV105Historicosolicitudeswwds_2_tfhistoricosolicitudesprovid",GXType.Decimal,18,0) ,
          new ParDef("@AV106Historicosolicitudeswwds_3_tfhistoricosolicitudesprovid_to",GXType.Decimal,18,0) ,
          new ParDef("@lV107Historicosolicitudeswwds_4_tfhistoricosolicitudesprovnombre",GXType.Char,120,0) ,
          new ParDef("@AV108Historicosolicitudeswwds_5_tfhistoricosolicitudesprovnombre_sel",GXType.NChar,120,0) ,
          new ParDef("@AV86EstadosGenericosID",GXType.Int32,5,0) ,
          new ParDef("@AV89ProveedorID",GXType.Decimal,18,0)
          };
          def= new CursorDef[] {
              new CursorDef("P004R2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP004R2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P004R3", "SELECT [HistoricoSolicitudesID], [HistoricoSolicitudesItemsID], [HistoricoSolicitudesItemsComis], [HistoricoSolicitudesItemsCT], [HistoricoSolicitudesItemsSR], [HItemsSolicitudesItemsCantidad], [HItemsInventarioPrecioFinal] FROM [HistoricoSolicitudesItems] WHERE [HistoricoSolicitudesID] = @HistoricoSolicitudesID ORDER BY [HistoricoSolicitudesID] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP004R3,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[0])[0] = rslt.getString(1, 3);
                ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
                ((int[]) buf[2])[0] = rslt.getInt(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((bool[]) buf[5])[0] = rslt.wasNull(5);
                ((string[]) buf[6])[0] = rslt.getString(6, 20);
                ((string[]) buf[7])[0] = rslt.getString(7, 100);
                ((long[]) buf[8])[0] = rslt.getLong(8);
                ((string[]) buf[9])[0] = rslt.getString(9, 120);
                ((long[]) buf[10])[0] = rslt.getLong(10);
                ((string[]) buf[11])[0] = rslt.getString(11, 1);
                ((string[]) buf[12])[0] = rslt.getString(12, 1);
                ((string[]) buf[13])[0] = rslt.getString(13, 80);
                ((decimal[]) buf[14])[0] = rslt.getDecimal(14);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((decimal[]) buf[2])[0] = rslt.getDecimal(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 1);
                ((string[]) buf[4])[0] = rslt.getString(5, 1);
                ((short[]) buf[5])[0] = rslt.getShort(6);
                ((short[]) buf[6])[0] = rslt.getShort(7);
                return;
       }
    }

 }

}

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
   public class areporteeconomicoprov : GXWebProcedure, System.Web.SessionState.IRequiresSessionState
   {
      public override void webExecute( )
      {
         context.SetDefaultTheme("WorkWithPlusDS", true);
         initialize();
         GXKey = Crypto.GetSiteKey( );
         if ( ( StringUtil.StrCmp(context.GetRequestQueryString( ), "") != 0 ) && ( GxWebError == 0 ) )
         {
            GXDecQS = UriDecrypt64( context.GetRequestQueryString( ), GXKey);
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "areporteeconomicoprov.aspx")), "areporteeconomicoprov.aspx") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "areporteeconomicoprov.aspx")))) ;
            }
            else
            {
               GxWebError = 1;
               context.HttpContext.Response.StatusDescription = 403.ToString();
               context.HttpContext.Response.StatusCode = 403;
               context.WriteHtmlText( "<title>403 Forbidden</title>") ;
               context.WriteHtmlText( "<h1>403 Forbidden</h1>") ;
               context.WriteHtmlText( "<p /><hr />") ;
               GXUtil.WriteLog("send_http_error_code " + 403.ToString());
            }
         }
         if ( nGotPars == 0 )
         {
            entryPointCalled = false;
            gxfirstwebparm = GetFirstPar( "ProveedoresTipoId");
            if ( ! entryPointCalled )
            {
               AV41ProveedoresTipoId = (long)(Math.Round(NumberUtil.Val( gxfirstwebparm, "."), 18, MidpointRounding.ToEven));
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
               {
                  AV42ProveedorID = (long)(Math.Round(NumberUtil.Val( GetPar( "ProveedorID"), "."), 18, MidpointRounding.ToEven));
                  AV8Desde = context.localUtil.ParseDateParm( GetPar( "Desde"));
                  AV9Hasta = context.localUtil.ParseDateParm( GetPar( "Hasta"));
                  AV38Clasificaciones = (int)(Math.Round(NumberUtil.Val( GetPar( "Clasificaciones"), "."), 18, MidpointRounding.ToEven));
                  AV43IncTot = GetPar( "IncTot");
                  AV45SolicitudServicioOrigenPago = GetPar( "SolicitudServicioOrigenPago");
               }
            }
         }
         if ( GxWebError == 0 )
         {
            ExecutePrivate();
         }
         cleanup();
      }

      public areporteeconomicoprov( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public areporteeconomicoprov( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( long aP0_ProveedoresTipoId ,
                           long aP1_ProveedorID ,
                           DateTime aP2_Desde ,
                           DateTime aP3_Hasta ,
                           int aP4_Clasificaciones ,
                           string aP5_IncTot ,
                           string aP6_SolicitudServicioOrigenPago )
      {
         this.AV41ProveedoresTipoId = aP0_ProveedoresTipoId;
         this.AV42ProveedorID = aP1_ProveedorID;
         this.AV8Desde = aP2_Desde;
         this.AV9Hasta = aP3_Hasta;
         this.AV38Clasificaciones = aP4_Clasificaciones;
         this.AV43IncTot = aP5_IncTot;
         this.AV45SolicitudServicioOrigenPago = aP6_SolicitudServicioOrigenPago;
         initialize();
         ExecutePrivate();
      }

      public void executeSubmit( long aP0_ProveedoresTipoId ,
                                 long aP1_ProveedorID ,
                                 DateTime aP2_Desde ,
                                 DateTime aP3_Hasta ,
                                 int aP4_Clasificaciones ,
                                 string aP5_IncTot ,
                                 string aP6_SolicitudServicioOrigenPago )
      {
         this.AV41ProveedoresTipoId = aP0_ProveedoresTipoId;
         this.AV42ProveedorID = aP1_ProveedorID;
         this.AV8Desde = aP2_Desde;
         this.AV9Hasta = aP3_Hasta;
         this.AV38Clasificaciones = aP4_Clasificaciones;
         this.AV43IncTot = aP5_IncTot;
         this.AV45SolicitudServicioOrigenPago = aP6_SolicitudServicioOrigenPago;
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
         setOutputFileName("ReporteEconomico");
         setOutputType("PDF");
         try
         {
            Gx_out = "SCR" ;
            if (!initPrinter (Gx_out, gxXPage, gxYPage, "GXPRN.INI", "", "", 2, 1, 256, 16834, 11909, 0, 1, 1, 0, 1, 1) )
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
            if ( StringUtil.StrCmp(AV45SolicitudServicioOrigenPago, context.GetMessage( "F", "")) == 0 )
            {
               AV46OrigenPago = context.GetMessage( "Cobro Directo", "");
            }
            else if ( StringUtil.StrCmp(AV45SolicitudServicioOrigenPago, context.GetMessage( "T", "")) == 0 )
            {
               AV46OrigenPago = context.GetMessage( "Cobro Prepago Comercio", "");
            }
            else if ( StringUtil.StrCmp(AV45SolicitudServicioOrigenPago, context.GetMessage( "O", "")) == 0 )
            {
               AV46OrigenPago = context.GetMessage( "Cobro Prepago Almango", "");
            }
            else
            {
               AV46OrigenPago = context.GetMessage( "Todos los Cobros", "");
            }
            AV23LabelRango = context.GetMessage( "Rango de fecha: ", "") + StringUtil.Trim( context.localUtil.Format( AV8Desde, "99/99/9999")) + " - " + StringUtil.Trim( context.localUtil.Format( AV9Hasta, "99/99/9999")) + " " + StringUtil.Trim( AV46OrigenPago);
            /* Using cursor P008I2 */
            pr_default.execute(0, new Object[] {AV42ProveedorID});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A133ProveedorID = P008I2_A133ProveedorID[0];
               A282ProveedorNombre = P008I2_A282ProveedorNombre[0];
               AV27ProveedorNombre = context.GetMessage( "Remitente de Solicitud de Servicios: ", "") + StringUtil.Trim( A282ProveedorNombre);
               AV27ProveedorNombre = StringUtil.Upper( AV27ProveedorNombre);
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               if (true) break;
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(0);
            H8I0( false, 100) ;
            getPrinter().GxAttris("Arial Black", 12, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Reporte de Solicitudes de Servicio", ""), 47, Gx_line+17, 727, Gx_line+44, 1, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 7, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( Gx_time, "")), 716, Gx_line+29, 792, Gx_line+43, 0+256, 0, 0, 0) ;
            getPrinter().GxDrawText(context.localUtil.Format( Gx_date, "99/99/99"), 662, Gx_line+29, 701, Gx_line+43, 2+256, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Fecha del Reporte", ""), 663, Gx_line+10, 812, Gx_line+24, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Arial", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV23LabelRango, "")), 73, Gx_line+43, 700, Gx_line+58, 1, 0, 0, 1) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 7, false, false, false, false, 0, 105, 105, 105, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Control de Solicitudes de Servicios a Domicilio", ""), 25, Gx_line+70, 278, Gx_line+84, 0, 0, 0, 0) ;
            getPrinter().GxDrawBitMap(context.GetImagePath( "e6acfd2e-013a-4b78-9d37-37f6dc906ba7", "", context.GetTheme( )), 13, Gx_line+3, 201, Gx_line+66) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+100);
            if ( StringUtil.StrCmp(AV43IncTot, context.GetMessage( "S", "")) == 0 )
            {
               H8I0( false, 67) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(context.GetMessage( "Total", ""), 595, Gx_line+48, 662, Gx_line+61, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(context.GetMessage( "Cliente", ""), 156, Gx_line+48, 263, Gx_line+61, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(context.GetMessage( "Estado", ""), 495, Gx_line+48, 557, Gx_line+61, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(context.GetMessage( "Calificación", ""), 692, Gx_line+48, 799, Gx_line+61, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(context.GetMessage( "Teléfono", ""), 356, Gx_line+48, 424, Gx_line+61, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV27ProveedorNombre, "")), 31, Gx_line+12, 449, Gx_line+27, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawLine(29, Gx_line+39, 769, Gx_line+39, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(29, Gx_line+66, 769, Gx_line+66, 1, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(context.GetMessage( "Solicitud No.", ""), 31, Gx_line+48, 138, Gx_line+61, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+67);
            }
            else
            {
               H8I0( false, 68) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(context.GetMessage( "Solicitud No.", ""), 35, Gx_line+48, 142, Gx_line+61, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(33, Gx_line+67, 773, Gx_line+67, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(33, Gx_line+40, 773, Gx_line+40, 1, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 9, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV27ProveedorNombre, "")), 35, Gx_line+13, 536, Gx_line+30, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(context.GetMessage( "Teléfono", ""), 360, Gx_line+48, 428, Gx_line+61, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(context.GetMessage( "Calificación", ""), 697, Gx_line+48, 804, Gx_line+61, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(context.GetMessage( "Estado", ""), 499, Gx_line+49, 561, Gx_line+62, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(context.GetMessage( "Cliente", ""), 160, Gx_line+48, 267, Gx_line+61, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+68);
            }
            GxHdr3 = true;
            /* Using cursor P008I3 */
            pr_default.execute(1, new Object[] {AV38Clasificaciones, AV42ProveedorID, AV8Desde, AV9Hasta, AV11SolicitudesID, AV45SolicitudServicioOrigenPago});
            while ( (pr_default.getStatus(1) != 101) )
            {
               A438SolicitudServicioOrigenPago = P008I3_A438SolicitudServicioOrigenPago[0];
               n438SolicitudServicioOrigenPago = P008I3_n438SolicitudServicioOrigenPago[0];
               A127SolicitudesID = P008I3_A127SolicitudesID[0];
               A184SolicitudesFechaInstalacion = P008I3_A184SolicitudesFechaInstalacion[0];
               A133ProveedorID = P008I3_A133ProveedorID[0];
               A131EstadosSolId = P008I3_A131EstadosSolId[0];
               A130EstadosSolTipo = P008I3_A130EstadosSolTipo[0];
               A171SolicitudesNombre = P008I3_A171SolicitudesNombre[0];
               A132EstadosSolNombre = P008I3_A132EstadosSolNombre[0];
               A172SolicitudesTelefono = P008I3_A172SolicitudesTelefono[0];
               A112DepartamentoId = P008I3_A112DepartamentoId[0];
               n112DepartamentoId = P008I3_n112DepartamentoId[0];
               A114DepartamentoMunicipioId = P008I3_A114DepartamentoMunicipioId[0];
               n114DepartamentoMunicipioId = P008I3_n114DepartamentoMunicipioId[0];
               A796SolicitudesComisionMetodoPago = P008I3_A796SolicitudesComisionMetodoPago[0];
               A212SolicitudesCotizacion = P008I3_A212SolicitudesCotizacion[0];
               A1016SolicitudesDescuentoCupon = P008I3_A1016SolicitudesDescuentoCupon[0];
               A897SolicitudesDescuento = P008I3_A897SolicitudesDescuento[0];
               n897SolicitudesDescuento = P008I3_n897SolicitudesDescuento[0];
               A864SolicitudesCostoXZona = P008I3_A864SolicitudesCostoXZona[0];
               A132EstadosSolNombre = P008I3_A132EstadosSolNombre[0];
               if ( StringUtil.StrCmp(A130EstadosSolTipo, context.GetMessage( "SOL", "")) == 0 )
               {
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
                  if ( ( ( AV38Clasificaciones == 0 ) && ( A131EstadosSolId != 4 ) && ( A131EstadosSolId != 3 ) ) || ( AV38Clasificaciones > 0 ) )
                  {
                     AV35Direccion = "";
                     AV11SolicitudesID = A127SolicitudesID;
                     AV12NombreCliente = A171SolicitudesNombre;
                     AV14Importe = A211SolicitudServicioPFinal;
                     AV13Estado = A132EstadosSolNombre;
                     AV28SolicitudesTelefono = A172SolicitudesTelefono;
                     AV34DepartamentoId = A112DepartamentoId;
                     /* Execute user subroutine: 'NOMBRE DEPARTAMENTO' */
                     S111 ();
                     if ( returnInSub )
                     {
                        pr_default.close(1);
                        cleanup();
                        if (true) return;
                     }
                     AV36DepartamentoMunicipioId = A114DepartamentoMunicipioId;
                     /* Execute user subroutine: 'NOMBRE MUNICIPIO/ZONA' */
                     S121 ();
                     if ( returnInSub )
                     {
                        pr_default.close(1);
                        cleanup();
                        if (true) return;
                     }
                     AV35Direccion = context.GetMessage( "Dirección: ", "") + StringUtil.Trim( AV35Direccion);
                     AV31Calificar = 0;
                     GXt_int1 = AV31Calificar;
                     new ofeedbackid(context ).execute(  AV16ProfesionalesId,  AV29ClientesId,  A127SolicitudesID, out  AV30FeedBackId, out  GXt_int1, out  AV32Comentario, out  AV33FeedBackFechaAlta) ;
                     AV31Calificar = Convert.ToInt32(GXt_int1);
                     AV32Comentario = context.GetMessage( "Comentario: ", "") + StringUtil.Trim( AV32Comentario);
                     if ( StringUtil.StrCmp(AV43IncTot, context.GetMessage( "S", "")) == 0 )
                     {
                        AV44SolicitudServicioPFinal = A211SolicitudServicioPFinal;
                        if ( A131EstadosSolId == 1 )
                        {
                           AV17TotalProc = (decimal)(AV17TotalProc+A211SolicitudServicioPFinal);
                        }
                        else if ( A131EstadosSolId == 2 )
                        {
                           AV21TotalHab = (decimal)(AV21TotalHab+A211SolicitudServicioPFinal);
                        }
                        else if ( A131EstadosSolId == 8 )
                        {
                           AV21TotalHab = (decimal)(AV21TotalHab+A211SolicitudServicioPFinal);
                        }
                        else if ( A131EstadosSolId == 5 )
                        {
                           AV19TotalAcep = (decimal)(AV19TotalAcep+A211SolicitudServicioPFinal);
                        }
                        else if ( A131EstadosSolId == 6 )
                        {
                           AV20TotalFin = (decimal)(AV20TotalFin+A211SolicitudServicioPFinal);
                        }
                        else if ( A131EstadosSolId == 7 )
                        {
                           AV20TotalFin = (decimal)(AV20TotalFin+A211SolicitudServicioPFinal);
                        }
                     }
                     else
                     {
                        AV44SolicitudServicioPFinal = 0;
                     }
                     if ( StringUtil.StrCmp(AV43IncTot, context.GetMessage( "S", "")) == 0 )
                     {
                        H8I0( false, 43) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV44SolicitudServicioPFinal, "ZZZZZZ,ZZZ,ZZZ,ZZ9.99")), 599, Gx_line+10, 731, Gx_line+25, 0+256, 0, 0, 0) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV13Estado, "")), 499, Gx_line+10, 578, Gx_line+25, 0+256, 0, 0, 0) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV35Direccion, "")), 160, Gx_line+28, 682, Gx_line+43, 0+256, 0, 0, 0) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV28SolicitudesTelefono, "")), 360, Gx_line+10, 465, Gx_line+25, 0+256, 0, 0, 0) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV12NombreCliente, "")), 160, Gx_line+10, 361, Gx_line+25, 0, 0, 0, 0) ;
                        getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV11SolicitudesID), "ZZZZZZZZZZZZZZZZZ9")), 39, Gx_line+10, 153, Gx_line+25, 0+256, 0, 0, 0) ;
                        Gx_OldLine = Gx_line;
                        Gx_line = (int)(Gx_line+43);
                     }
                     else
                     {
                        H8I0( false, 42) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV11SolicitudesID), "ZZZZZZZZZZZZZZZZZ9")), 39, Gx_line+6, 153, Gx_line+21, 0+256, 0, 0, 0) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV12NombreCliente, "")), 160, Gx_line+6, 361, Gx_line+21, 0, 0, 0, 0) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV28SolicitudesTelefono, "")), 360, Gx_line+6, 465, Gx_line+21, 0+256, 0, 0, 0) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV35Direccion, "")), 160, Gx_line+27, 682, Gx_line+42, 0+256, 0, 0, 0) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV13Estado, "")), 499, Gx_line+7, 578, Gx_line+22, 0+256, 0, 0, 0) ;
                        Gx_OldLine = Gx_line;
                        Gx_line = (int)(Gx_line+42);
                     }
                     if ( (Convert.ToDecimal( AV31Calificar ) >= 0.01m ) && ( AV31Calificar <= 1 ) )
                     {
                        H8I0( false, 18) ;
                        getPrinter().GxDrawBitMap(context.GetImagePath( "724c8eda-e27c-4df4-bf92-73e94550b250", "", context.GetTheme( )), 706, Gx_line+0, 786, Gx_line+15) ;
                        Gx_OldLine = Gx_line;
                        Gx_line = (int)(Gx_line+18);
                        /* Noskip command */
                        Gx_line = Gx_OldLine;
                     }
                     else if ( (Convert.ToDecimal( AV31Calificar ) >= 1.01m ) && ( AV31Calificar <= 2 ) )
                     {
                        H8I0( false, 18) ;
                        getPrinter().GxDrawBitMap(context.GetImagePath( "2b8c989d-874b-4b24-aac0-aaebf73175d7", "", context.GetTheme( )), 706, Gx_line+1, 786, Gx_line+16) ;
                        Gx_OldLine = Gx_line;
                        Gx_line = (int)(Gx_line+18);
                        /* Noskip command */
                        Gx_line = Gx_OldLine;
                     }
                     else if ( (Convert.ToDecimal( AV31Calificar ) >= 2.01m ) && ( AV31Calificar <= 3 ) )
                     {
                        H8I0( false, 18) ;
                        getPrinter().GxDrawBitMap(context.GetImagePath( "e2f11de9-4867-4b76-a564-12e2c04b5eb5", "", context.GetTheme( )), 706, Gx_line+1, 786, Gx_line+16) ;
                        Gx_OldLine = Gx_line;
                        Gx_line = (int)(Gx_line+18);
                        /* Noskip command */
                        Gx_line = Gx_OldLine;
                     }
                     else if ( (Convert.ToDecimal( AV31Calificar ) >= 3.01m ) && ( AV31Calificar <= 4 ) )
                     {
                        H8I0( false, 18) ;
                        getPrinter().GxDrawBitMap(context.GetImagePath( "3b04acea-fa64-4ece-996f-3d3ce81e1e07", "", context.GetTheme( )), 706, Gx_line+1, 786, Gx_line+16) ;
                        Gx_OldLine = Gx_line;
                        Gx_line = (int)(Gx_line+18);
                        /* Noskip command */
                        Gx_line = Gx_OldLine;
                     }
                     else if ( (Convert.ToDecimal( AV31Calificar ) >= 4.01m ) && ( AV31Calificar <= 5 ) )
                     {
                        H8I0( false, 17) ;
                        getPrinter().GxDrawBitMap(context.GetImagePath( "c355af3a-c049-4f9e-be27-7849f748afbb", "", context.GetTheme( )), 706, Gx_line+1, 786, Gx_line+16) ;
                        Gx_OldLine = Gx_line;
                        Gx_line = (int)(Gx_line+17);
                        /* Noskip command */
                        Gx_line = Gx_OldLine;
                     }
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV32Comentario)) )
                     {
                        H8I0( false, 38) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(AV32Comentario, 42, Gx_line+0, 792, Gx_line+33, 0, 0, 0, 0) ;
                        Gx_OldLine = Gx_line;
                        Gx_line = (int)(Gx_line+38);
                     }
                     H8I0( false, 5) ;
                     getPrinter().GxDrawLine(45, Gx_line+2, 785, Gx_line+2, 1, 220, 220, 220, 0) ;
                     Gx_OldLine = Gx_line;
                     Gx_line = (int)(Gx_line+5);
                  }
               }
               pr_default.readNext(1);
            }
            pr_default.close(1);
            GxHdr3 = false;
            if ( StringUtil.StrCmp(AV43IncTot, context.GetMessage( "S", "")) == 0 )
            {
               H8I0( false, 195) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(context.GetMessage( "Total Delegadas/Habilitadas", ""), 224, Gx_line+27, 402, Gx_line+40, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 105, 105, 105, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV19TotalAcep, "ZZZ,ZZZ,ZZZ,ZZZ,ZZ9.99")), 501, Gx_line+52, 640, Gx_line+67, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(context.GetMessage( "Total Aceptada", ""), 501, Gx_line+27, 608, Gx_line+40, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(context.GetMessage( "Total Finalizadas", ""), 707, Gx_line+27, 814, Gx_line+40, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 105, 105, 105, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV21TotalHab, "ZZZ,ZZZ,ZZZ,ZZZ,ZZ9.99")), 224, Gx_line+52, 363, Gx_line+67, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawLine(18, Gx_line+13, 815, Gx_line+13, 1, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(context.GetMessage( "Total Procesadas", ""), 18, Gx_line+27, 125, Gx_line+40, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 7, false, false, false, false, 0, 70, 130, 180, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(context.GetMessage( "Dirección: Eduardo Acevedo 1310 Montevideo, Uruguay  ", ""), 27, Gx_line+110, 374, Gx_line+128, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(context.GetMessage( "Teléfono: +598 92612655   ", ""), 27, Gx_line+128, 374, Gx_line+146, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(context.GetMessage( "Email: info@almango.com.uy   ", ""), 27, Gx_line+146, 374, Gx_line+164, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(context.GetMessage( "Website: www.almango.com.uy", ""), 27, Gx_line+164, 374, Gx_line+182, 0, 0, 0, 0) ;
               getPrinter().GxDrawBitMap(context.GetImagePath( "22922f7f-f2d4-4fde-abb1-d4ceefcb60c5", "", context.GetTheme( )), 598, Gx_line+128, 730, Gx_line+158) ;
               getPrinter().GxDrawLine(18, Gx_line+80, 815, Gx_line+80, 1, 192, 192, 192, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 105, 105, 105, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV20TotalFin, "ZZZ,ZZZ,ZZZ,ZZZ,ZZ9.99")), 708, Gx_line+52, 847, Gx_line+67, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV17TotalProc, "ZZZ,ZZZ,ZZZ,ZZZ,ZZ9.99")), 18, Gx_line+52, 157, Gx_line+67, 0+256, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+195);
            }
            else
            {
               H8I0( false, 143) ;
               getPrinter().GxDrawBitMap(context.GetImagePath( "22922f7f-f2d4-4fde-abb1-d4ceefcb60c5", "", context.GetTheme( )), 593, Gx_line+93, 725, Gx_line+123) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 7, false, false, false, false, 0, 70, 130, 180, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(context.GetMessage( "Dirección: Eduardo Acevedo 1310 Montevideo, Uruguay  ", ""), 20, Gx_line+67, 367, Gx_line+85, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(context.GetMessage( "Teléfono: +598 92612655   ", ""), 20, Gx_line+85, 367, Gx_line+103, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(context.GetMessage( "Email: info@almango.com.uy   ", ""), 20, Gx_line+103, 367, Gx_line+121, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(context.GetMessage( "Website: www.almango.com.uy", ""), 20, Gx_line+121, 367, Gx_line+139, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(13, Gx_line+40, 810, Gx_line+40, 1, 192, 192, 192, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+143);
            }
            /* Print footer for last page */
            ToSkip = (int)(P_lines+1);
            H8I0( true, 0) ;
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
         /* 'NOMBRE DEPARTAMENTO' Routine */
         returnInSub = false;
         /* Using cursor P008I4 */
         pr_default.execute(2, new Object[] {AV34DepartamentoId});
         while ( (pr_default.getStatus(2) != 101) )
         {
            A112DepartamentoId = P008I4_A112DepartamentoId[0];
            n112DepartamentoId = P008I4_n112DepartamentoId[0];
            A113DepartamentoDepartamento = P008I4_A113DepartamentoDepartamento[0];
            AV35Direccion = StringUtil.Trim( A113DepartamentoDepartamento);
            /* Exit For each command. Update data (if necessary), close cursors & exit. */
            if (true) break;
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(2);
      }

      protected void S121( )
      {
         /* 'NOMBRE MUNICIPIO/ZONA' Routine */
         returnInSub = false;
         /* Using cursor P008I5 */
         pr_default.execute(3, new Object[] {AV34DepartamentoId, AV36DepartamentoMunicipioId});
         while ( (pr_default.getStatus(3) != 101) )
         {
            A114DepartamentoMunicipioId = P008I5_A114DepartamentoMunicipioId[0];
            n114DepartamentoMunicipioId = P008I5_n114DepartamentoMunicipioId[0];
            A112DepartamentoId = P008I5_A112DepartamentoId[0];
            n112DepartamentoId = P008I5_n112DepartamentoId[0];
            A115DepartamentoMunicipioNombre = P008I5_A115DepartamentoMunicipioNombre[0];
            AV35Direccion = StringUtil.Trim( AV35Direccion) + ", " + StringUtil.Trim( A115DepartamentoMunicipioNombre);
            /* Exit For each command. Update data (if necessary), close cursors & exit. */
            if (true) break;
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(3);
      }

      protected void S131( )
      {
         /* 'ZONAS' Routine */
         returnInSub = false;
         /* Using cursor P008I6 */
         pr_default.execute(4, new Object[] {AV37ZonasID, AV34DepartamentoId, AV36DepartamentoMunicipioId});
         while ( (pr_default.getStatus(4) != 101) )
         {
            A114DepartamentoMunicipioId = P008I6_A114DepartamentoMunicipioId[0];
            n114DepartamentoMunicipioId = P008I6_n114DepartamentoMunicipioId[0];
            A112DepartamentoId = P008I6_A112DepartamentoId[0];
            n112DepartamentoId = P008I6_n112DepartamentoId[0];
            A110ZonasID = P008I6_A110ZonasID[0];
            A111ZonasNombre = P008I6_A111ZonasNombre[0];
            AV35Direccion = StringUtil.Trim( AV35Direccion) + ", " + StringUtil.Trim( A111ZonasNombre);
            /* Exit For each command. Update data (if necessary), close cursors & exit. */
            if (true) break;
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(4);
      }

      protected void H8I0( bool bFoot ,
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
               if ( GxHdr3 )
               {
                  getPrinter().GxAttris("Arial Black", 12, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(context.GetMessage( "Reporte de Solicitudes de Servicio", ""), 47, Gx_line+17, 727, Gx_line+44, 1, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 7, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( Gx_time, "")), 716, Gx_line+29, 792, Gx_line+43, 0+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(context.localUtil.Format( Gx_date, "99/99/99"), 662, Gx_line+29, 701, Gx_line+43, 2+256, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(context.GetMessage( "Fecha del Reporte", ""), 663, Gx_line+10, 812, Gx_line+24, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Arial", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV23LabelRango, "")), 73, Gx_line+43, 700, Gx_line+58, 1, 0, 0, 1) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 7, false, false, false, false, 0, 105, 105, 105, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(context.GetMessage( "Control de Solicitudes de Servicios a Domicilio", ""), 25, Gx_line+70, 278, Gx_line+84, 0, 0, 0, 0) ;
                  getPrinter().GxDrawBitMap(context.GetImagePath( "e6acfd2e-013a-4b78-9d37-37f6dc906ba7", "", context.GetTheme( )), 13, Gx_line+3, 201, Gx_line+66) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+100);
                  if ( StringUtil.StrCmp(AV43IncTot, context.GetMessage( "S", "")) == 0 )
                  {
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(context.GetMessage( "Total", ""), 595, Gx_line+48, 662, Gx_line+61, 0, 0, 0, 0) ;
                     getPrinter().GxDrawText(context.GetMessage( "Cliente", ""), 156, Gx_line+48, 263, Gx_line+61, 0, 0, 0, 0) ;
                     getPrinter().GxDrawText(context.GetMessage( "Estado", ""), 495, Gx_line+48, 557, Gx_line+61, 0, 0, 0, 0) ;
                     getPrinter().GxDrawText(context.GetMessage( "Calificación", ""), 692, Gx_line+48, 799, Gx_line+61, 0, 0, 0, 0) ;
                     getPrinter().GxDrawText(context.GetMessage( "Teléfono", ""), 356, Gx_line+48, 424, Gx_line+61, 0, 0, 0, 0) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV27ProveedorNombre, "")), 31, Gx_line+12, 449, Gx_line+27, 0+256, 0, 0, 0) ;
                     getPrinter().GxDrawLine(29, Gx_line+39, 769, Gx_line+39, 1, 0, 0, 0, 0) ;
                     getPrinter().GxDrawLine(29, Gx_line+66, 769, Gx_line+66, 1, 0, 0, 0, 0) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(context.GetMessage( "Solicitud No.", ""), 31, Gx_line+48, 138, Gx_line+61, 0, 0, 0, 0) ;
                     Gx_OldLine = Gx_line;
                     Gx_line = (int)(Gx_line+67);
                  }
                  else
                  {
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(context.GetMessage( "Solicitud No.", ""), 35, Gx_line+48, 142, Gx_line+61, 0, 0, 0, 0) ;
                     getPrinter().GxDrawLine(33, Gx_line+67, 773, Gx_line+67, 1, 0, 0, 0, 0) ;
                     getPrinter().GxDrawLine(33, Gx_line+40, 773, Gx_line+40, 1, 0, 0, 0, 0) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 9, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV27ProveedorNombre, "")), 35, Gx_line+13, 536, Gx_line+30, 0+256, 0, 0, 0) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(context.GetMessage( "Teléfono", ""), 360, Gx_line+48, 428, Gx_line+61, 0, 0, 0, 0) ;
                     getPrinter().GxDrawText(context.GetMessage( "Calificación", ""), 697, Gx_line+48, 804, Gx_line+61, 0, 0, 0, 0) ;
                     getPrinter().GxDrawText(context.GetMessage( "Estado", ""), 499, Gx_line+49, 561, Gx_line+62, 0, 0, 0, 0) ;
                     getPrinter().GxDrawText(context.GetMessage( "Cliente", ""), 160, Gx_line+48, 267, Gx_line+61, 0, 0, 0, 0) ;
                     Gx_OldLine = Gx_line;
                     Gx_line = (int)(Gx_line+68);
                  }
               }
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
         add_metrics1( ) ;
         add_metrics2( ) ;
         add_metrics3( ) ;
      }

      protected void add_metrics0( )
      {
         getPrinter().setMetrics("Arial Black", true, false, 57, 15, 72, 163,  new int[] {47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 17, 19, 29, 34, 34, 55, 45, 15, 21, 21, 24, 36, 17, 21, 17, 17, 34, 34, 34, 34, 34, 34, 34, 34, 34, 34, 21, 21, 36, 36, 36, 38, 60, 43, 45, 45, 45, 41, 38, 48, 45, 17, 34, 45, 38, 53, 45, 48, 41, 48, 45, 41, 38, 45, 41, 57, 41, 41, 38, 21, 17, 21, 36, 34, 21, 34, 38, 34, 38, 34, 21, 38, 38, 17, 17, 34, 17, 55, 38, 38, 38, 38, 24, 34, 21, 38, 33, 49, 34, 34, 31, 24, 17, 24, 36, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 17, 21, 34, 34, 34, 34, 17, 34, 21, 46, 23, 34, 36, 21, 46, 34, 25, 34, 21, 21, 21, 36, 34, 21, 20, 21, 23, 34, 52, 52, 52, 38, 45, 45, 45, 45, 45, 45, 62, 45, 41, 41, 41, 41, 17, 17, 17, 17, 45, 45, 48, 48, 48, 48, 48, 36, 48, 45, 45, 45, 45, 41, 41, 38, 34, 34, 34, 34, 34, 34, 55, 34, 34, 34, 34, 34, 17, 17, 17, 17, 38, 38, 38, 38, 38, 38, 38, 34, 38, 38, 38, 38, 38, 34, 38, 34}) ;
      }

      protected void add_metrics1( )
      {
         getPrinter().setMetrics("Microsoft Sans Serif", false, false, 58, 14, 72, 171,  new int[] {48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 18, 20, 23, 36, 36, 57, 43, 12, 21, 21, 25, 37, 18, 21, 18, 18, 36, 36, 36, 36, 36, 36, 36, 36, 36, 36, 18, 18, 37, 37, 37, 36, 65, 43, 43, 46, 46, 43, 39, 50, 46, 18, 32, 43, 36, 53, 46, 50, 43, 50, 46, 43, 40, 46, 43, 64, 41, 42, 39, 18, 18, 18, 27, 36, 21, 36, 36, 32, 36, 36, 18, 36, 36, 14, 15, 33, 14, 55, 36, 36, 36, 36, 21, 32, 18, 36, 33, 47, 31, 31, 31, 21, 17, 21, 37, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 18, 20, 36, 36, 36, 36, 17, 36, 21, 47, 24, 36, 37, 21, 47, 35, 26, 35, 21, 21, 21, 37, 34, 21, 21, 21, 23, 36, 53, 53, 53, 39, 43, 43, 43, 43, 43, 43, 64, 46, 43, 43, 43, 43, 18, 18, 18, 18, 46, 46, 50, 50, 50, 50, 50, 37, 50, 46, 46, 46, 46, 43, 43, 39, 36, 36, 36, 36, 36, 36, 57, 32, 36, 36, 36, 36, 18, 18, 18, 18, 36, 36, 36, 36, 36, 36, 36, 35, 39, 36, 36, 36, 36, 32, 36, 32}) ;
      }

      protected void add_metrics2( )
      {
         getPrinter().setMetrics("Arial", false, false, 58, 14, 72, 171,  new int[] {48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 18, 20, 23, 36, 36, 57, 43, 12, 21, 21, 25, 37, 18, 21, 18, 18, 36, 36, 36, 36, 36, 36, 36, 36, 36, 36, 18, 18, 37, 37, 37, 36, 65, 43, 43, 46, 46, 43, 39, 50, 46, 18, 32, 43, 36, 53, 46, 50, 43, 50, 46, 43, 40, 46, 43, 64, 41, 42, 39, 18, 18, 18, 27, 36, 21, 36, 36, 32, 36, 36, 18, 36, 36, 14, 15, 33, 14, 55, 36, 36, 36, 36, 21, 32, 18, 36, 33, 47, 31, 31, 31, 21, 17, 21, 37, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 18, 20, 36, 36, 36, 36, 17, 36, 21, 47, 24, 36, 37, 21, 47, 35, 26, 35, 21, 21, 21, 37, 34, 21, 21, 21, 23, 36, 53, 53, 53, 39, 43, 43, 43, 43, 43, 43, 64, 46, 43, 43, 43, 43, 18, 18, 18, 18, 46, 46, 50, 50, 50, 50, 50, 37, 50, 46, 46, 46, 46, 43, 43, 39, 36, 36, 36, 36, 36, 36, 57, 32, 36, 36, 36, 36, 18, 18, 18, 18, 36, 36, 36, 36, 36, 36, 36, 35, 39, 36, 36, 36, 36, 32, 36, 32}) ;
      }

      protected void add_metrics3( )
      {
         getPrinter().setMetrics("Microsoft Sans Serif", true, false, 57, 15, 72, 163,  new int[] {47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 17, 19, 29, 34, 34, 55, 45, 15, 21, 21, 24, 36, 17, 21, 17, 17, 34, 34, 34, 34, 34, 34, 34, 34, 34, 34, 21, 21, 36, 36, 36, 38, 60, 43, 45, 45, 45, 41, 38, 48, 45, 17, 34, 45, 38, 53, 45, 48, 41, 48, 45, 41, 38, 45, 41, 57, 41, 41, 38, 21, 17, 21, 36, 34, 21, 34, 38, 34, 38, 34, 21, 38, 38, 17, 17, 34, 17, 55, 38, 38, 38, 38, 24, 34, 21, 38, 33, 49, 34, 34, 31, 24, 17, 24, 36, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 17, 21, 34, 34, 34, 34, 17, 34, 21, 46, 23, 34, 36, 21, 46, 34, 25, 34, 21, 21, 21, 36, 34, 21, 20, 21, 23, 34, 52, 52, 52, 38, 45, 45, 45, 45, 45, 45, 62, 45, 41, 41, 41, 41, 17, 17, 17, 17, 45, 45, 48, 48, 48, 48, 48, 36, 48, 45, 45, 45, 45, 41, 41, 38, 34, 34, 34, 34, 34, 34, 55, 34, 34, 34, 34, 34, 17, 17, 17, 17, 38, 38, 38, 38, 38, 38, 38, 34, 38, 38, 38, 38, 38, 34, 38, 34}) ;
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
         /* Using cursor P008I7 */
         pr_default.execute(5, new Object[] {A127SolicitudesID});
         while ( (pr_default.getStatus(5) != 101) && ( P008I7_A127SolicitudesID[0] == A127SolicitudesID ) )
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( P008I7_A178SolicitudItemsSR[0])) || ( StringUtil.StrCmp(P008I7_A179SolicitudItemsComisionTipo[0], "N") == 0 ) )
            {
               A175SolicitudesItemsPrecioInstalac = (decimal)((P008I7_A176SolicitudesItemsPrecioFinal[0]*P008I7_A177SolicitudesItemsCantidad[0]));
            }
            else
            {
               if ( ( StringUtil.StrCmp(P008I7_A179SolicitudItemsComisionTipo[0], "F") == 0 ) && ( StringUtil.StrCmp(P008I7_A178SolicitudItemsSR[0], "R") == 0 ) )
               {
                  A175SolicitudesItemsPrecioInstalac = (decimal)((P008I7_A176SolicitudesItemsPrecioFinal[0]*P008I7_A177SolicitudesItemsCantidad[0])-(P008I7_A180SolicitudItemsComision[0]*P008I7_A177SolicitudesItemsCantidad[0]));
               }
               else
               {
                  if ( ( StringUtil.StrCmp(P008I7_A179SolicitudItemsComisionTipo[0], "F") == 0 ) && ( StringUtil.StrCmp(P008I7_A178SolicitudItemsSR[0], "S") == 0 ) )
                  {
                     A175SolicitudesItemsPrecioInstalac = (decimal)((P008I7_A176SolicitudesItemsPrecioFinal[0]*P008I7_A177SolicitudesItemsCantidad[0])+(P008I7_A180SolicitudItemsComision[0]*P008I7_A177SolicitudesItemsCantidad[0]));
                  }
                  else
                  {
                     if ( ( StringUtil.StrCmp(P008I7_A179SolicitudItemsComisionTipo[0], "P") == 0 ) && ( StringUtil.StrCmp(P008I7_A178SolicitudItemsSR[0], "R") == 0 ) )
                     {
                        A175SolicitudesItemsPrecioInstalac = (decimal)((P008I7_A176SolicitudesItemsPrecioFinal[0]*P008I7_A177SolicitudesItemsCantidad[0])-((P008I7_A176SolicitudesItemsPrecioFinal[0]*P008I7_A177SolicitudesItemsCantidad[0])*(P008I7_A180SolicitudItemsComision[0]/ (decimal)(100))));
                     }
                     else
                     {
                        if ( ( StringUtil.StrCmp(P008I7_A179SolicitudItemsComisionTipo[0], "P") == 0 ) && ( StringUtil.StrCmp(P008I7_A178SolicitudItemsSR[0], "S") == 0 ) )
                        {
                           A175SolicitudesItemsPrecioInstalac = (decimal)((P008I7_A176SolicitudesItemsPrecioFinal[0]*P008I7_A177SolicitudesItemsCantidad[0])+((P008I7_A176SolicitudesItemsPrecioFinal[0]*P008I7_A177SolicitudesItemsCantidad[0])*(P008I7_A180SolicitudItemsComision[0]/ (decimal)(100))));
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
            pr_default.readNext(5);
         }
         pr_default.close(5);
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
         GXDecQS = "";
         gxfirstwebparm = "";
         AV46OrigenPago = "";
         AV23LabelRango = "";
         P008I2_A133ProveedorID = new long[1] ;
         P008I2_A282ProveedorNombre = new string[] {""} ;
         A282ProveedorNombre = "";
         AV27ProveedorNombre = "";
         Gx_time = "";
         Gx_date = DateTime.MinValue;
         P008I3_A438SolicitudServicioOrigenPago = new string[] {""} ;
         P008I3_n438SolicitudServicioOrigenPago = new bool[] {false} ;
         P008I3_A127SolicitudesID = new long[1] ;
         P008I3_A184SolicitudesFechaInstalacion = new DateTime[] {DateTime.MinValue} ;
         P008I3_A133ProveedorID = new long[1] ;
         P008I3_A131EstadosSolId = new int[1] ;
         P008I3_A130EstadosSolTipo = new string[] {""} ;
         P008I3_A171SolicitudesNombre = new string[] {""} ;
         P008I3_A132EstadosSolNombre = new string[] {""} ;
         P008I3_A172SolicitudesTelefono = new string[] {""} ;
         P008I3_A112DepartamentoId = new long[1] ;
         P008I3_n112DepartamentoId = new bool[] {false} ;
         P008I3_A114DepartamentoMunicipioId = new long[1] ;
         P008I3_n114DepartamentoMunicipioId = new bool[] {false} ;
         P008I3_A796SolicitudesComisionMetodoPago = new decimal[1] ;
         P008I3_A212SolicitudesCotizacion = new decimal[1] ;
         P008I3_A1016SolicitudesDescuentoCupon = new decimal[1] ;
         P008I3_A897SolicitudesDescuento = new decimal[1] ;
         P008I3_n897SolicitudesDescuento = new bool[] {false} ;
         P008I3_A864SolicitudesCostoXZona = new decimal[1] ;
         A438SolicitudServicioOrigenPago = "";
         A184SolicitudesFechaInstalacion = DateTime.MinValue;
         A130EstadosSolTipo = "";
         A171SolicitudesNombre = "";
         A132EstadosSolNombre = "";
         A172SolicitudesTelefono = "";
         AV35Direccion = "";
         AV12NombreCliente = "";
         AV13Estado = "";
         AV28SolicitudesTelefono = "";
         AV16ProfesionalesId = "";
         AV32Comentario = "";
         AV33FeedBackFechaAlta = DateTime.MinValue;
         P008I4_A112DepartamentoId = new long[1] ;
         P008I4_n112DepartamentoId = new bool[] {false} ;
         P008I4_A113DepartamentoDepartamento = new string[] {""} ;
         A113DepartamentoDepartamento = "";
         P008I5_A114DepartamentoMunicipioId = new long[1] ;
         P008I5_n114DepartamentoMunicipioId = new bool[] {false} ;
         P008I5_A112DepartamentoId = new long[1] ;
         P008I5_n112DepartamentoId = new bool[] {false} ;
         P008I5_A115DepartamentoMunicipioNombre = new string[] {""} ;
         A115DepartamentoMunicipioNombre = "";
         P008I6_A114DepartamentoMunicipioId = new long[1] ;
         P008I6_n114DepartamentoMunicipioId = new bool[] {false} ;
         P008I6_A112DepartamentoId = new long[1] ;
         P008I6_n112DepartamentoId = new bool[] {false} ;
         P008I6_A110ZonasID = new long[1] ;
         P008I6_A111ZonasNombre = new string[] {""} ;
         A111ZonasNombre = "";
         P008I7_A127SolicitudesID = new long[1] ;
         P008I7_A134SolicitudesItemsID = new short[1] ;
         P008I7_A180SolicitudItemsComision = new decimal[1] ;
         P008I7_A179SolicitudItemsComisionTipo = new string[] {""} ;
         P008I7_A178SolicitudItemsSR = new string[] {""} ;
         P008I7_A177SolicitudesItemsCantidad = new short[1] ;
         P008I7_A176SolicitudesItemsPrecioFinal = new decimal[1] ;
         P008I7_n176SolicitudesItemsPrecioFinal = new bool[] {false} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.areporteeconomicoprov__default(),
            new Object[][] {
                new Object[] {
               P008I2_A133ProveedorID, P008I2_A282ProveedorNombre
               }
               , new Object[] {
               P008I3_A438SolicitudServicioOrigenPago, P008I3_n438SolicitudServicioOrigenPago, P008I3_A127SolicitudesID, P008I3_A184SolicitudesFechaInstalacion, P008I3_A133ProveedorID, P008I3_A131EstadosSolId, P008I3_A130EstadosSolTipo, P008I3_A171SolicitudesNombre, P008I3_A132EstadosSolNombre, P008I3_A172SolicitudesTelefono,
               P008I3_A112DepartamentoId, P008I3_n112DepartamentoId, P008I3_A114DepartamentoMunicipioId, P008I3_n114DepartamentoMunicipioId, P008I3_A796SolicitudesComisionMetodoPago, P008I3_A212SolicitudesCotizacion, P008I3_A1016SolicitudesDescuentoCupon, P008I3_A897SolicitudesDescuento, P008I3_n897SolicitudesDescuento, P008I3_A864SolicitudesCostoXZona
               }
               , new Object[] {
               P008I4_A112DepartamentoId, P008I4_A113DepartamentoDepartamento
               }
               , new Object[] {
               P008I5_A114DepartamentoMunicipioId, P008I5_A112DepartamentoId, P008I5_A115DepartamentoMunicipioNombre
               }
               , new Object[] {
               P008I6_A114DepartamentoMunicipioId, P008I6_A112DepartamentoId, P008I6_A110ZonasID, P008I6_A111ZonasNombre
               }
               , new Object[] {
               P008I7_A127SolicitudesID, P008I7_A134SolicitudesItemsID, P008I7_A180SolicitudItemsComision, P008I7_A179SolicitudItemsComisionTipo, P008I7_A178SolicitudItemsSR, P008I7_A177SolicitudesItemsCantidad, P008I7_A176SolicitudesItemsPrecioFinal, P008I7_n176SolicitudesItemsPrecioFinal
               }
            }
         );
         Gx_date = DateTimeUtil.Today( context);
         Gx_time = context.localUtil.Time( );
         /* GeneXus formulas. */
         Gx_line = 0;
         Gx_date = DateTimeUtil.Today( context);
         Gx_time = context.localUtil.Time( );
      }

      private short GxWebError ;
      private short nGotPars ;
      private int AV38Clasificaciones ;
      private int M_top ;
      private int M_bot ;
      private int Line ;
      private int ToSkip ;
      private int PrtOffset ;
      private int Gx_OldLine ;
      private int A131EstadosSolId ;
      private int AV31Calificar ;
      private long AV41ProveedoresTipoId ;
      private long AV42ProveedorID ;
      private long A133ProveedorID ;
      private long AV11SolicitudesID ;
      private long A127SolicitudesID ;
      private long A112DepartamentoId ;
      private long A114DepartamentoMunicipioId ;
      private long AV34DepartamentoId ;
      private long AV36DepartamentoMunicipioId ;
      private long AV29ClientesId ;
      private long AV30FeedBackId ;
      private long GXt_int1 ;
      private long AV37ZonasID ;
      private long A110ZonasID ;
      private decimal A796SolicitudesComisionMetodoPago ;
      private decimal A212SolicitudesCotizacion ;
      private decimal A1016SolicitudesDescuentoCupon ;
      private decimal A897SolicitudesDescuento ;
      private decimal A864SolicitudesCostoXZona ;
      private decimal A211SolicitudServicioPFinal ;
      private decimal A174SolicitudesTotal ;
      private decimal AV14Importe ;
      private decimal AV44SolicitudServicioPFinal ;
      private decimal AV17TotalProc ;
      private decimal AV21TotalHab ;
      private decimal AV19TotalAcep ;
      private decimal AV20TotalFin ;
      private decimal A175SolicitudesItemsPrecioInstalac ;
      private string GXKey ;
      private string GXDecQS ;
      private string gxfirstwebparm ;
      private string AV43IncTot ;
      private string AV45SolicitudServicioOrigenPago ;
      private string AV46OrigenPago ;
      private string AV23LabelRango ;
      private string A282ProveedorNombre ;
      private string AV27ProveedorNombre ;
      private string Gx_time ;
      private string A438SolicitudServicioOrigenPago ;
      private string A130EstadosSolTipo ;
      private string A171SolicitudesNombre ;
      private string A132EstadosSolNombre ;
      private string A172SolicitudesTelefono ;
      private string AV35Direccion ;
      private string AV12NombreCliente ;
      private string AV13Estado ;
      private string AV28SolicitudesTelefono ;
      private string AV16ProfesionalesId ;
      private string A113DepartamentoDepartamento ;
      private string A115DepartamentoMunicipioNombre ;
      private string A111ZonasNombre ;
      private DateTime AV8Desde ;
      private DateTime AV9Hasta ;
      private DateTime Gx_date ;
      private DateTime A184SolicitudesFechaInstalacion ;
      private DateTime AV33FeedBackFechaAlta ;
      private bool entryPointCalled ;
      private bool GxHdr3 ;
      private bool n438SolicitudServicioOrigenPago ;
      private bool n112DepartamentoId ;
      private bool n114DepartamentoMunicipioId ;
      private bool n897SolicitudesDescuento ;
      private bool returnInSub ;
      private string AV32Comentario ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private long[] P008I2_A133ProveedorID ;
      private string[] P008I2_A282ProveedorNombre ;
      private string[] P008I3_A438SolicitudServicioOrigenPago ;
      private bool[] P008I3_n438SolicitudServicioOrigenPago ;
      private long[] P008I3_A127SolicitudesID ;
      private DateTime[] P008I3_A184SolicitudesFechaInstalacion ;
      private long[] P008I3_A133ProveedorID ;
      private int[] P008I3_A131EstadosSolId ;
      private string[] P008I3_A130EstadosSolTipo ;
      private string[] P008I3_A171SolicitudesNombre ;
      private string[] P008I3_A132EstadosSolNombre ;
      private string[] P008I3_A172SolicitudesTelefono ;
      private long[] P008I3_A112DepartamentoId ;
      private bool[] P008I3_n112DepartamentoId ;
      private long[] P008I3_A114DepartamentoMunicipioId ;
      private bool[] P008I3_n114DepartamentoMunicipioId ;
      private decimal[] P008I3_A796SolicitudesComisionMetodoPago ;
      private decimal[] P008I3_A212SolicitudesCotizacion ;
      private decimal[] P008I3_A1016SolicitudesDescuentoCupon ;
      private decimal[] P008I3_A897SolicitudesDescuento ;
      private bool[] P008I3_n897SolicitudesDescuento ;
      private decimal[] P008I3_A864SolicitudesCostoXZona ;
      private long[] P008I4_A112DepartamentoId ;
      private bool[] P008I4_n112DepartamentoId ;
      private string[] P008I4_A113DepartamentoDepartamento ;
      private long[] P008I5_A114DepartamentoMunicipioId ;
      private bool[] P008I5_n114DepartamentoMunicipioId ;
      private long[] P008I5_A112DepartamentoId ;
      private bool[] P008I5_n112DepartamentoId ;
      private string[] P008I5_A115DepartamentoMunicipioNombre ;
      private long[] P008I6_A114DepartamentoMunicipioId ;
      private bool[] P008I6_n114DepartamentoMunicipioId ;
      private long[] P008I6_A112DepartamentoId ;
      private bool[] P008I6_n112DepartamentoId ;
      private long[] P008I6_A110ZonasID ;
      private string[] P008I6_A111ZonasNombre ;
      private long[] P008I7_A127SolicitudesID ;
      private short[] P008I7_A134SolicitudesItemsID ;
      private decimal[] P008I7_A180SolicitudItemsComision ;
      private string[] P008I7_A179SolicitudItemsComisionTipo ;
      private string[] P008I7_A178SolicitudItemsSR ;
      private short[] P008I7_A177SolicitudesItemsCantidad ;
      private decimal[] P008I7_A176SolicitudesItemsPrecioFinal ;
      private bool[] P008I7_n176SolicitudesItemsPrecioFinal ;
   }

   public class areporteeconomicoprov__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
         ,new ForEachCursor(def[2])
         ,new ForEachCursor(def[3])
         ,new ForEachCursor(def[4])
         ,new ForEachCursor(def[5])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP008I2;
          prmP008I2 = new Object[] {
          new ParDef("@AV42ProveedorID",GXType.Decimal,18,0)
          };
          Object[] prmP008I3;
          prmP008I3 = new Object[] {
          new ParDef("@AV38Clasificaciones",GXType.Int32,5,0) ,
          new ParDef("@AV42ProveedorID",GXType.Decimal,18,0) ,
          new ParDef("@AV8Desde",GXType.Date,8,0) ,
          new ParDef("@AV9Hasta",GXType.Date,8,0) ,
          new ParDef("@AV11SolicitudesID",GXType.Decimal,18,0) ,
          new ParDef("@AV45SolicitudServicioOrigenPago",GXType.NChar,1,0)
          };
          Object[] prmP008I4;
          prmP008I4 = new Object[] {
          new ParDef("@AV34DepartamentoId",GXType.Decimal,18,0)
          };
          Object[] prmP008I5;
          prmP008I5 = new Object[] {
          new ParDef("@AV34DepartamentoId",GXType.Decimal,18,0) ,
          new ParDef("@AV36DepartamentoMunicipioId",GXType.Decimal,18,0)
          };
          Object[] prmP008I6;
          prmP008I6 = new Object[] {
          new ParDef("@AV37ZonasID",GXType.Decimal,18,0) ,
          new ParDef("@AV34DepartamentoId",GXType.Decimal,18,0) ,
          new ParDef("@AV36DepartamentoMunicipioId",GXType.Decimal,18,0)
          };
          Object[] prmP008I7;
          prmP008I7 = new Object[] {
          new ParDef("@SolicitudesID",GXType.Decimal,18,0)
          };
          def= new CursorDef[] {
              new CursorDef("P008I2", "SELECT TOP 1 [ProveedorID], [ProveedorNombre] FROM [Proveedor] WHERE [ProveedorID] = @AV42ProveedorID ORDER BY [ProveedorID] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP008I2,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P008I3", "SELECT T1.[SolicitudServicioOrigenPago], T1.[SolicitudesID], T1.[SolicitudesFechaInstalacion], T1.[ProveedorID], T1.[EstadosSolId] AS EstadosSolId, T1.[EstadosSolTipo] AS EstadosSolTipo, T1.[SolicitudesNombre], T2.[EstadosGenericosNombre] AS EstadosSolNombre, T1.[SolicitudesTelefono], T1.[DepartamentoId], T1.[DepartamentoMunicipioId], T1.[SolicitudesComisionMetodoPago], T1.[SolicitudesCotizacion], T1.[SolicitudesDescuentoCupon], T1.[SolicitudesDescuento], T1.[SolicitudesCostoXZona] FROM ([Solicitudes] T1 INNER JOIN [EstadosGenericos] T2 ON T2.[EstadosTipo] = T1.[EstadosSolTipo] AND T2.[EstadosGenericosId] = T1.[EstadosSolId]) WHERE (T1.[EstadosSolId] = @AV38Clasificaciones or @AV38Clasificaciones = 0) AND (T1.[ProveedorID] = @AV42ProveedorID or @AV42ProveedorID = 0) AND (T1.[SolicitudesFechaInstalacion] >= @AV8Desde and T1.[SolicitudesFechaInstalacion] <= @AV9Hasta) AND (T1.[SolicitudesID] = @AV11SolicitudesID or @AV11SolicitudesID = 0) AND (T1.[SolicitudServicioOrigenPago] = @AV45SolicitudServicioOrigenPago or @AV45SolicitudServicioOrigenPago = '') ORDER BY T1.[SolicitudesID] DESC ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP008I3,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P008I4", "SELECT TOP 1 [DepartamentoId], [DepartamentoDepartamento] FROM [Departamento] WHERE [DepartamentoId] = @AV34DepartamentoId ORDER BY [DepartamentoId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP008I4,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P008I5", "SELECT TOP 1 [DepartamentoMunicipioId], [DepartamentoId], [DepartamentoMunicipioNombre] FROM [DepartamentoMunicipio] WHERE [DepartamentoId] = @AV34DepartamentoId and [DepartamentoMunicipioId] = @AV36DepartamentoMunicipioId ORDER BY [DepartamentoId], [DepartamentoMunicipioId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP008I5,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P008I6", "SELECT TOP 1 [DepartamentoMunicipioId], [DepartamentoId], [ZonasID], [ZonasNombre] FROM [Zonas] WHERE [ZonasID] = @AV37ZonasID and [DepartamentoId] = @AV34DepartamentoId and [DepartamentoMunicipioId] = @AV36DepartamentoMunicipioId ORDER BY [ZonasID], [DepartamentoId], [DepartamentoMunicipioId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP008I6,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P008I7", "SELECT [SolicitudesID], [SolicitudesItemsID], [SolicitudItemsComision], [SolicitudItemsComisionTipo], [SolicitudItemsSR], [SolicitudesItemsCantidad], [SolicitudesItemsPrecioFinal] FROM [SolicitudesItems] WHERE [SolicitudesID] = @SolicitudesID ORDER BY [SolicitudesID] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP008I7,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[1])[0] = rslt.getString(2, 80);
                return;
             case 1 :
                ((string[]) buf[0])[0] = rslt.getString(1, 1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((long[]) buf[2])[0] = rslt.getLong(2);
                ((DateTime[]) buf[3])[0] = rslt.getGXDate(3);
                ((long[]) buf[4])[0] = rslt.getLong(4);
                ((int[]) buf[5])[0] = rslt.getInt(5);
                ((string[]) buf[6])[0] = rslt.getString(6, 3);
                ((string[]) buf[7])[0] = rslt.getString(7, 100);
                ((string[]) buf[8])[0] = rslt.getString(8, 80);
                ((string[]) buf[9])[0] = rslt.getString(9, 20);
                ((long[]) buf[10])[0] = rslt.getLong(10);
                ((bool[]) buf[11])[0] = rslt.wasNull(10);
                ((long[]) buf[12])[0] = rslt.getLong(11);
                ((bool[]) buf[13])[0] = rslt.wasNull(11);
                ((decimal[]) buf[14])[0] = rslt.getDecimal(12);
                ((decimal[]) buf[15])[0] = rslt.getDecimal(13);
                ((decimal[]) buf[16])[0] = rslt.getDecimal(14);
                ((decimal[]) buf[17])[0] = rslt.getDecimal(15);
                ((bool[]) buf[18])[0] = rslt.wasNull(15);
                ((decimal[]) buf[19])[0] = rslt.getDecimal(16);
                return;
             case 2 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 80);
                return;
             case 3 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((long[]) buf[1])[0] = rslt.getLong(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 120);
                return;
             case 4 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((long[]) buf[1])[0] = rslt.getLong(2);
                ((long[]) buf[2])[0] = rslt.getLong(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 120);
                return;
             case 5 :
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

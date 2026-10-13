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
   public class areporteprofcomi : GXWebProcedure, System.Web.SessionState.IRequiresSessionState
   {
      public override void webExecute( )
      {
         context.SetDefaultTheme("WorkWithPlusDS", true);
         initialize();
         GXKey = Crypto.GetSiteKey( );
         if ( ( StringUtil.StrCmp(context.GetRequestQueryString( ), "") != 0 ) && ( GxWebError == 0 ) )
         {
            GXDecQS = UriDecrypt64( context.GetRequestQueryString( ), GXKey);
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "areporteprofcomi.aspx")), "areporteprofcomi.aspx") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "areporteprofcomi.aspx")))) ;
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
            gxfirstwebparm = GetFirstPar( "ProfesionalesId");
            if ( ! entryPointCalled )
            {
               A120ProfesionalesId = gxfirstwebparm;
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
               {
                  AV21InSolicitudesID = (long)(Math.Round(NumberUtil.Val( GetPar( "InSolicitudesID"), "."), 18, MidpointRounding.ToEven));
                  AV15Desde = context.localUtil.ParseDateParm( GetPar( "Desde"));
                  AV19Hasta = context.localUtil.ParseDateParm( GetPar( "Hasta"));
                  AV10Clasificaciones = (int)(Math.Round(NumberUtil.Val( GetPar( "Clasificaciones"), "."), 18, MidpointRounding.ToEven));
                  AV49SolicitudServicioOrigenPago = GetPar( "SolicitudServicioOrigenPago");
                  AV29Opciones = GetPar( "Opciones");
                  AV64Veridicar = GetPar( "Veridicar");
               }
            }
         }
         if ( GxWebError == 0 )
         {
            ExecutePrivate();
         }
         cleanup();
      }

      public areporteprofcomi( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public areporteprofcomi( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( ref string aP0_ProfesionalesId ,
                           ref long aP1_InSolicitudesID ,
                           ref DateTime aP2_Desde ,
                           ref DateTime aP3_Hasta ,
                           ref int aP4_Clasificaciones ,
                           ref string aP5_SolicitudServicioOrigenPago ,
                           ref string aP6_Opciones ,
                           ref string aP7_Veridicar )
      {
         this.A120ProfesionalesId = aP0_ProfesionalesId;
         this.AV21InSolicitudesID = aP1_InSolicitudesID;
         this.AV15Desde = aP2_Desde;
         this.AV19Hasta = aP3_Hasta;
         this.AV10Clasificaciones = aP4_Clasificaciones;
         this.AV49SolicitudServicioOrigenPago = aP5_SolicitudServicioOrigenPago;
         this.AV29Opciones = aP6_Opciones;
         this.AV64Veridicar = aP7_Veridicar;
         initialize();
         ExecutePrivate();
         aP0_ProfesionalesId=this.A120ProfesionalesId;
         aP1_InSolicitudesID=this.AV21InSolicitudesID;
         aP2_Desde=this.AV15Desde;
         aP3_Hasta=this.AV19Hasta;
         aP4_Clasificaciones=this.AV10Clasificaciones;
         aP5_SolicitudServicioOrigenPago=this.AV49SolicitudServicioOrigenPago;
         aP6_Opciones=this.AV29Opciones;
         aP7_Veridicar=this.AV64Veridicar;
      }

      public string executeUdp( ref string aP0_ProfesionalesId ,
                                ref long aP1_InSolicitudesID ,
                                ref DateTime aP2_Desde ,
                                ref DateTime aP3_Hasta ,
                                ref int aP4_Clasificaciones ,
                                ref string aP5_SolicitudServicioOrigenPago ,
                                ref string aP6_Opciones )
      {
         execute(ref aP0_ProfesionalesId, ref aP1_InSolicitudesID, ref aP2_Desde, ref aP3_Hasta, ref aP4_Clasificaciones, ref aP5_SolicitudServicioOrigenPago, ref aP6_Opciones, ref aP7_Veridicar);
         return AV64Veridicar ;
      }

      public void executeSubmit( ref string aP0_ProfesionalesId ,
                                 ref long aP1_InSolicitudesID ,
                                 ref DateTime aP2_Desde ,
                                 ref DateTime aP3_Hasta ,
                                 ref int aP4_Clasificaciones ,
                                 ref string aP5_SolicitudServicioOrigenPago ,
                                 ref string aP6_Opciones ,
                                 ref string aP7_Veridicar )
      {
         this.A120ProfesionalesId = aP0_ProfesionalesId;
         this.AV21InSolicitudesID = aP1_InSolicitudesID;
         this.AV15Desde = aP2_Desde;
         this.AV19Hasta = aP3_Hasta;
         this.AV10Clasificaciones = aP4_Clasificaciones;
         this.AV49SolicitudServicioOrigenPago = aP5_SolicitudServicioOrigenPago;
         this.AV29Opciones = aP6_Opciones;
         this.AV64Veridicar = aP7_Veridicar;
         SubmitImpl();
         aP0_ProfesionalesId=this.A120ProfesionalesId;
         aP1_InSolicitudesID=this.AV21InSolicitudesID;
         aP2_Desde=this.AV15Desde;
         aP3_Hasta=this.AV19Hasta;
         aP4_Clasificaciones=this.AV10Clasificaciones;
         aP5_SolicitudServicioOrigenPago=this.AV49SolicitudServicioOrigenPago;
         aP6_Opciones=this.AV29Opciones;
         aP7_Veridicar=this.AV64Veridicar;
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
            new oprofesionalnombre(context ).execute(  A120ProfesionalesId, out  AV37Profesional, out  AV39ProfesionalesFeedBackCant, out  AV40ProfesionalesFeedBackProm, out  AV38ProfesionalesFeedback) ;
            AV8ProfesionalesId = StringUtil.Trim( A120ProfesionalesId);
            AV25LabelRango = context.GetMessage( "Comisiones segun rango de fecha: ", "") + StringUtil.Trim( context.localUtil.Format( AV15Desde, "99/99/99")) + " - " + StringUtil.Trim( context.localUtil.Format( AV19Hasta, "99/99/99"));
            H8K0( false, 127) ;
            getPrinter().GxDrawBitMap(context.GetImagePath( "22922f7f-f2d4-4fde-abb1-d4ceefcb60c5", "", context.GetTheme( )), 13, Gx_line+13, 186, Gx_line+53) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 12, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Reporte Financiero de Actividades Profesionales", ""), 120, Gx_line+67, 696, Gx_line+94, 1, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 7, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( Gx_time, "")), 714, Gx_line+33, 790, Gx_line+47, 0+256, 0, 0, 0) ;
            getPrinter().GxDrawText(context.localUtil.Format( Gx_date, "99/99/99"), 660, Gx_line+33, 699, Gx_line+47, 2+256, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Fecha del Reporte", ""), 661, Gx_line+13, 810, Gx_line+27, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV25LabelRango, "")), 157, Gx_line+101, 679, Gx_line+116, 1+256, 0, 0, 1) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+127);
            if ( StringUtil.StrCmp(AV29Opciones, context.GetMessage( "S", "")) == 0 )
            {
               H8K0( false, 79) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(context.GetMessage( "Estado", ""), 350, Gx_line+59, 457, Gx_line+72, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(context.GetMessage( "OK", ""), 785, Gx_line+59, 809, Gx_line+71, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(context.GetMessage( "Solicitud No.", ""), 22, Gx_line+57, 129, Gx_line+70, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(context.GetMessage( "ComisiónALM", ""), 579, Gx_line+59, 686, Gx_line+72, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(context.GetMessage( "ComisiónPF", ""), 683, Gx_line+59, 790, Gx_line+72, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(context.GetMessage( "Pagado", ""), 438, Gx_line+59, 491, Gx_line+72, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV37Profesional, "")), 297, Gx_line+22, 715, Gx_line+37, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText(context.GetMessage( "Importe", ""), 458, Gx_line+59, 565, Gx_line+72, 2, 0, 0, 0) ;
               getPrinter().GxDrawLine(10, Gx_line+48, 810, Gx_line+48, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(10, Gx_line+76, 810, Gx_line+76, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(context.GetMessage( "Profesional:", ""), 22, Gx_line+22, 129, Gx_line+35, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV8ProfesionalesId, "")), 175, Gx_line+22, 280, Gx_line+37, 0+256, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+79);
            }
            else
            {
               H8K0( false, 68) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV8ProfesionalesId, "")), 167, Gx_line+13, 272, Gx_line+28, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText(context.GetMessage( "Profesional:", ""), 22, Gx_line+13, 129, Gx_line+26, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(10, Gx_line+67, 810, Gx_line+67, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(10, Gx_line+39, 810, Gx_line+39, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(context.GetMessage( "Estado", ""), 350, Gx_line+50, 457, Gx_line+63, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(context.GetMessage( "Importe", ""), 458, Gx_line+50, 565, Gx_line+63, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV37Profesional, "")), 293, Gx_line+13, 711, Gx_line+28, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText(context.GetMessage( "Pagado", ""), 433, Gx_line+50, 486, Gx_line+63, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(context.GetMessage( "ComisiónPF", ""), 683, Gx_line+50, 790, Gx_line+63, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(context.GetMessage( "Solicitud No.", ""), 22, Gx_line+48, 129, Gx_line+61, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+68);
            }
            GxHdr2 = true;
            /* Using cursor P008K2 */
            pr_default.execute(0, new Object[] {AV21InSolicitudesID, AV10Clasificaciones, AV15Desde, AV19Hasta, AV49SolicitudServicioOrigenPago});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A130EstadosSolTipo = P008K2_A130EstadosSolTipo[0];
               A438SolicitudServicioOrigenPago = P008K2_A438SolicitudServicioOrigenPago[0];
               n438SolicitudServicioOrigenPago = P008K2_n438SolicitudServicioOrigenPago[0];
               A184SolicitudesFechaInstalacion = P008K2_A184SolicitudesFechaInstalacion[0];
               A131EstadosSolId = P008K2_A131EstadosSolId[0];
               A127SolicitudesID = P008K2_A127SolicitudesID[0];
               A171SolicitudesNombre = P008K2_A171SolicitudesNombre[0];
               A132EstadosSolNombre = P008K2_A132EstadosSolNombre[0];
               A796SolicitudesComisionMetodoPago = P008K2_A796SolicitudesComisionMetodoPago[0];
               A212SolicitudesCotizacion = P008K2_A212SolicitudesCotizacion[0];
               A1016SolicitudesDescuentoCupon = P008K2_A1016SolicitudesDescuentoCupon[0];
               A897SolicitudesDescuento = P008K2_A897SolicitudesDescuento[0];
               n897SolicitudesDescuento = P008K2_n897SolicitudesDescuento[0];
               A864SolicitudesCostoXZona = P008K2_A864SolicitudesCostoXZona[0];
               A132EstadosSolNombre = P008K2_A132EstadosSolNombre[0];
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
               if ( ( ( AV10Clasificaciones == 0 ) && ( A131EstadosSolId != 4 ) && ( A131EstadosSolId != 3 ) ) || ( AV10Clasificaciones > 0 ) )
               {
                  AV44SolicitudesID = A127SolicitudesID;
                  AV27NombreCliente = A171SolicitudesNombre;
                  AV20Importe = A211SolicitudServicioPFinal;
                  AV17Estado = A132EstadosSolNombre;
                  AV18Exists = context.GetMessage( "N", "");
                  if ( String.IsNullOrEmpty(StringUtil.RTrim( AV8ProfesionalesId)) )
                  {
                     AV18Exists = context.GetMessage( "S", "");
                  }
                  else
                  {
                     GXt_char1 = AV18Exists;
                     new oexisterelacion(context ).execute(  A127SolicitudesID,  AV8ProfesionalesId, out  GXt_char1) ;
                     AV18Exists = GXt_char1;
                  }
                  AV30OrigenPago = A438SolicitudServicioOrigenPago;
                  if ( StringUtil.StrCmp(AV18Exists, context.GetMessage( "S", "")) == 0 )
                  {
                     AV13Comision = 0;
                     AV14ComisionALM = 0;
                     AV9Calcular = context.GetMessage( "N", "");
                     if ( A131EstadosSolId == 2 )
                     {
                        AV58TotalHab = (decimal)(AV58TotalHab+A211SolicitudServicioPFinal);
                     }
                     else if ( A131EstadosSolId == 8 )
                     {
                        AV58TotalHab = (decimal)(AV58TotalHab+A211SolicitudServicioPFinal);
                     }
                     else if ( A131EstadosSolId == 5 )
                     {
                        AV52TotalAcep = (decimal)(AV52TotalAcep+A211SolicitudServicioPFinal);
                     }
                     else if ( A131EstadosSolId == 6 )
                     {
                        AV57TotalFin = (decimal)(AV57TotalFin+A211SolicitudServicioPFinal);
                     }
                     else if ( A131EstadosSolId == 7 )
                     {
                        AV57TotalFin = (decimal)(AV57TotalFin+A211SolicitudServicioPFinal);
                     }
                     /* Execute user subroutine: 'DETALLES DE SOLICITUDES' */
                     S111 ();
                     if ( returnInSub )
                     {
                        pr_default.close(0);
                        cleanup();
                        if (true) return;
                     }
                     AV54TotalComisionProf = (decimal)(AV54TotalComisionProf+AV13Comision);
                     AV53TotalAlmango = (decimal)(AV53TotalAlmango+AV14ComisionALM);
                     AV55TotalComisionProveedor = (decimal)(AV55TotalComisionProveedor+AV11ComiProv);
                     if ( StringUtil.StrCmp(AV29Opciones, context.GetMessage( "S", "")) == 0 )
                     {
                        H8K0( false, 21) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV20Importe, "ZZZ,ZZZ,ZZZ,ZZZ,ZZ9.99")), 426, Gx_line+3, 565, Gx_line+18, 2+256, 0, 0, 0) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV27NombreCliente, "")), 175, Gx_line+3, 508, Gx_line+18, 0, 0, 0, 0) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV28Ok, "")), 797, Gx_line+3, 809, Gx_line+18, 0+256, 0, 0, 0) ;
                        getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV13Comision, "ZZZ,ZZZ,ZZZ,ZZZ,ZZ9.99")), 651, Gx_line+3, 790, Gx_line+18, 2+256, 0, 0, 0) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV30OrigenPago, "")), 458, Gx_line+3, 470, Gx_line+18, 0+256, 0, 0, 0) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV17Estado, "")), 350, Gx_line+3, 429, Gx_line+18, 0+256, 0, 0, 0) ;
                        getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV44SolicitudesID), "ZZZZZZZZZZZZZZZZZ9")), 22, Gx_line+6, 136, Gx_line+21, 2+256, 0, 0, 0) ;
                        getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV14ComisionALM, "ZZZ,ZZZ,ZZZ,ZZZ,ZZ9.99")), 547, Gx_line+3, 686, Gx_line+18, 2+256, 0, 0, 0) ;
                        Gx_OldLine = Gx_line;
                        Gx_line = (int)(Gx_line+21);
                        H8K0( false, 15) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 33, 101, 150, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV42ProveedorNombre, "")), 175, Gx_line+0, 375, Gx_line+15, 0, 0, 0, 0) ;
                        getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV41ProveedorID), "ZZZZZZZZZZZZZZZZZ9")), 22, Gx_line+0, 136, Gx_line+15, 2+256, 0, 0, 0) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV51TipoComiProv, "")), 669, Gx_line+0, 681, Gx_line+15, 0+256, 0, 0, 0) ;
                        getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV11ComiProv, "ZZZ,ZZZ,ZZZ,ZZZ,ZZ9.99")), 651, Gx_line+0, 790, Gx_line+15, 2+256, 0, 0, 0) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV47SolicitudItemsComisionTipo, "")), 600, Gx_line+0, 612, Gx_line+15, 0+256, 0, 0, 0) ;
                        getPrinter().GxDrawText(context.GetMessage( "Precio Original:", ""), 383, Gx_line+0, 458, Gx_line+14, 0+256, 0, 0, 0) ;
                        getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV23InventarioPrecioFinal, "ZZZ,ZZZ,ZZZ,ZZZ,ZZ9.99")), 426, Gx_line+0, 565, Gx_line+15, 2+256, 0, 0, 0) ;
                        Gx_OldLine = Gx_line;
                        Gx_line = (int)(Gx_line+15);
                     }
                     else
                     {
                        H8K0( false, 19) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV17Estado, "")), 350, Gx_line+0, 429, Gx_line+15, 0+256, 0, 0, 0) ;
                        getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV20Importe, "ZZZ,ZZZ,ZZZ,ZZZ,ZZ9.99")), 426, Gx_line+0, 565, Gx_line+15, 2+256, 0, 0, 0) ;
                        getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV44SolicitudesID), "ZZZZZZZZZZZZZZZZZ9")), 22, Gx_line+3, 136, Gx_line+18, 2+256, 0, 0, 0) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV27NombreCliente, "")), 175, Gx_line+0, 508, Gx_line+15, 0, 0, 0, 0) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV30OrigenPago, "")), 458, Gx_line+0, 470, Gx_line+15, 0+256, 0, 0, 0) ;
                        getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV13Comision, "ZZZ,ZZZ,ZZZ,ZZZ,ZZ9.99")), 651, Gx_line+0, 790, Gx_line+15, 2+256, 0, 0, 0) ;
                        Gx_OldLine = Gx_line;
                        Gx_line = (int)(Gx_line+19);
                     }
                     H8K0( false, 5) ;
                     getPrinter().GxDrawLine(10, Gx_line+0, 810, Gx_line+0, 1, 220, 220, 220, 0) ;
                     Gx_OldLine = Gx_line;
                     Gx_line = (int)(Gx_line+5);
                  }
               }
               pr_default.readNext(0);
            }
            pr_default.close(0);
            GxHdr2 = false;
            H8K0( false, 115) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV57TotalFin, "ZZZ,ZZZ,ZZZ,ZZZ,ZZ9.99")), 675, Gx_line+53, 814, Gx_line+68, 0+256, 0, 0, 1) ;
            getPrinter().GxDrawText(context.GetMessage( "Total Finalizadas", ""), 675, Gx_line+25, 782, Gx_line+38, 0, 0, 0, 0) ;
            getPrinter().GxDrawLine(10, Gx_line+13, 810, Gx_line+13, 1, 0, 0, 0, 0) ;
            getPrinter().GxDrawLine(10, Gx_line+80, 810, Gx_line+80, 1, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(context.GetMessage( "Total Profesional:", ""), 32, Gx_line+25, 210, Gx_line+38, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV54TotalComisionProf, "ZZZZZZ,ZZZ,ZZZ,ZZ9.99")), 35, Gx_line+53, 167, Gx_line+68, 0+256, 0, 0, 0) ;
            getPrinter().GxDrawLine(10, Gx_line+0, 810, Gx_line+0, 1, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(context.GetMessage( "Comisión de Almango", ""), 252, Gx_line+25, 430, Gx_line+38, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV53TotalAlmango, "ZZZZZZ,ZZZ,ZZZ,ZZ9.99")), 252, Gx_line+53, 384, Gx_line+68, 0+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV55TotalComisionProveedor, "ZZZZZZ,ZZZ,ZZZ,ZZ9.99")), 481, Gx_line+53, 613, Gx_line+68, 0+256, 0, 0, 0) ;
            getPrinter().GxDrawText(context.GetMessage( "Comisión Proveedor", ""), 481, Gx_line+25, 659, Gx_line+38, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+115);
            /* Print footer for last page */
            ToSkip = (int)(P_lines+1);
            H8K0( true, 0) ;
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
         /* 'DETALLES DE SOLICITUDES' Routine */
         returnInSub = false;
         AV34ProfComisionesRubrosGanPRF = 0;
         AV24ItemCant = 0;
         AV13Comision = 0;
         AV14ComisionALM = 0;
         AV60TotalPorcentPRF = 0;
         AV61TotalPreFijoPRF = 0;
         AV23InventarioPrecioFinal = 0;
         /* Using cursor P008K3 */
         pr_default.execute(1, new Object[] {AV44SolicitudesID});
         while ( (pr_default.getStatus(1) != 101) )
         {
            A121RubrosId = P008K3_A121RubrosId[0];
            A127SolicitudesID = P008K3_A127SolicitudesID[0];
            A133ProveedorID = P008K3_A133ProveedorID[0];
            A282ProveedorNombre = P008K3_A282ProveedorNombre[0];
            A212SolicitudesCotizacion = P008K3_A212SolicitudesCotizacion[0];
            A137MedidasID = P008K3_A137MedidasID[0];
            A135InventarioId = P008K3_A135InventarioId[0];
            A136InventarioNombre = P008K3_A136InventarioNombre[0];
            A138MedidasNombre = P008K3_A138MedidasNombre[0];
            A122RubrosNombre = P008K3_A122RubrosNombre[0];
            A180SolicitudItemsComision = P008K3_A180SolicitudItemsComision[0];
            A179SolicitudItemsComisionTipo = P008K3_A179SolicitudItemsComisionTipo[0];
            A178SolicitudItemsSR = P008K3_A178SolicitudItemsSR[0];
            A177SolicitudesItemsCantidad = P008K3_A177SolicitudesItemsCantidad[0];
            A176SolicitudesItemsPrecioFinal = P008K3_A176SolicitudesItemsPrecioFinal[0];
            n176SolicitudesItemsPrecioFinal = P008K3_n176SolicitudesItemsPrecioFinal[0];
            A134SolicitudesItemsID = P008K3_A134SolicitudesItemsID[0];
            A122RubrosNombre = P008K3_A122RubrosNombre[0];
            A133ProveedorID = P008K3_A133ProveedorID[0];
            A212SolicitudesCotizacion = P008K3_A212SolicitudesCotizacion[0];
            A282ProveedorNombre = P008K3_A282ProveedorNombre[0];
            A138MedidasNombre = P008K3_A138MedidasNombre[0];
            A136InventarioNombre = P008K3_A136InventarioNombre[0];
            if ( String.IsNullOrEmpty(StringUtil.RTrim( A178SolicitudItemsSR)) || ( StringUtil.StrCmp(A179SolicitudItemsComisionTipo, context.GetMessage( "N", "")) == 0 ) )
            {
               A175SolicitudesItemsPrecioInstalac = (decimal)((A176SolicitudesItemsPrecioFinal*A177SolicitudesItemsCantidad));
            }
            else
            {
               if ( ( StringUtil.StrCmp(A179SolicitudItemsComisionTipo, context.GetMessage( "F", "")) == 0 ) && ( StringUtil.StrCmp(A178SolicitudItemsSR, context.GetMessage( "R", "")) == 0 ) )
               {
                  A175SolicitudesItemsPrecioInstalac = (decimal)((A176SolicitudesItemsPrecioFinal*A177SolicitudesItemsCantidad)-(A180SolicitudItemsComision*A177SolicitudesItemsCantidad));
               }
               else
               {
                  if ( ( StringUtil.StrCmp(A179SolicitudItemsComisionTipo, context.GetMessage( "F", "")) == 0 ) && ( StringUtil.StrCmp(A178SolicitudItemsSR, context.GetMessage( "S", "")) == 0 ) )
                  {
                     A175SolicitudesItemsPrecioInstalac = (decimal)((A176SolicitudesItemsPrecioFinal*A177SolicitudesItemsCantidad)+(A180SolicitudItemsComision*A177SolicitudesItemsCantidad));
                  }
                  else
                  {
                     if ( ( StringUtil.StrCmp(A179SolicitudItemsComisionTipo, context.GetMessage( "P", "")) == 0 ) && ( StringUtil.StrCmp(A178SolicitudItemsSR, context.GetMessage( "R", "")) == 0 ) )
                     {
                        A175SolicitudesItemsPrecioInstalac = (decimal)((A176SolicitudesItemsPrecioFinal*A177SolicitudesItemsCantidad)-((A176SolicitudesItemsPrecioFinal*A177SolicitudesItemsCantidad)*(A180SolicitudItemsComision/ (decimal)(100))));
                     }
                     else
                     {
                        if ( ( StringUtil.StrCmp(A179SolicitudItemsComisionTipo, context.GetMessage( "P", "")) == 0 ) && ( StringUtil.StrCmp(A178SolicitudItemsSR, context.GetMessage( "S", "")) == 0 ) )
                        {
                           A175SolicitudesItemsPrecioInstalac = (decimal)((A176SolicitudesItemsPrecioFinal*A177SolicitudesItemsCantidad)+((A176SolicitudesItemsPrecioFinal*A177SolicitudesItemsCantidad)*(A180SolicitudItemsComision/ (decimal)(100))));
                        }
                        else
                        {
                           A175SolicitudesItemsPrecioInstalac = 0;
                        }
                     }
                  }
               }
            }
            AV41ProveedorID = A133ProveedorID;
            AV42ProveedorNombre = A282ProveedorNombre;
            AV51TipoComiProv = A178SolicitudItemsSR;
            AV47SolicitudItemsComisionTipo = A179SolicitudItemsComisionTipo;
            AV46SolicitudItemsComision = A180SolicitudItemsComision;
            AV48SolicitudItemsSR = A178SolicitudItemsSR;
            AV63Calculo = (decimal)(A176SolicitudesItemsPrecioFinal*A177SolicitudesItemsCantidad);
            AV23InventarioPrecioFinal = (decimal)(AV23InventarioPrecioFinal+AV63Calculo);
            AV11ComiProv = 0;
            AV34ProfComisionesRubrosGanPRF = 0;
            AV33ProfComisionesRubrosGan = 0;
            if ( ( A212SolicitudesCotizacion > Convert.ToDecimal( 0 )) )
            {
               new ocostoservicios(context ).execute(  context.GetMessage( "S", ""),  A127SolicitudesID, out  AV34ProfComisionesRubrosGanPRF, out  AV33ProfComisionesRubrosGan) ;
               AV13Comision = (decimal)(AV13Comision+AV34ProfComisionesRubrosGanPRF);
               AV14ComisionALM = (decimal)(AV14ComisionALM+AV33ProfComisionesRubrosGan);
            }
            if ( ( A212SolicitudesCotizacion == Convert.ToDecimal( 0 )) )
            {
               GXt_int2 = (long)(Math.Round(AV34ProfComisionesRubrosGanPRF, 18, MidpointRounding.ToEven));
               GXt_int3 = (long)(Math.Round(AV33ProfComisionesRubrosGan, 18, MidpointRounding.ToEven));
               new ocomiprof(context ).execute(  AV41ProveedorID,  AV8ProfesionalesId,  A121RubrosId,  A137MedidasID,  A135InventarioId, out  AV35ProfComisionesRubrosTipo, out  AV36ProfComisionesRubrosValor, out  GXt_int2, out  GXt_int3) ;
               AV34ProfComisionesRubrosGanPRF = (decimal)(GXt_int2);
               AV33ProfComisionesRubrosGan = (decimal)(GXt_int3);
               AV12ComiProveedor = (decimal)(A180SolicitudItemsComision*A177SolicitudesItemsCantidad);
               AV16DividirComiProv = (decimal)(AV12ComiProveedor/ (decimal)(2));
               AV11ComiProv = (decimal)(AV11ComiProv+AV12ComiProveedor);
               AV12ComiProveedor = (decimal)(A180SolicitudItemsComision*A177SolicitudesItemsCantidad);
               if ( StringUtil.StrCmp(AV35ProfComisionesRubrosTipo, context.GetMessage( "P", "")) == 0 )
               {
                  AV63Calculo = (decimal)(A175SolicitudesItemsPrecioInstalac*(AV36ProfComisionesRubrosValor/ (decimal)(100)));
                  AV13Comision = (decimal)(AV13Comision+AV63Calculo);
                  AV63Calculo = (decimal)(A175SolicitudesItemsPrecioInstalac-AV63Calculo);
                  AV14ComisionALM = (decimal)(AV14ComisionALM+AV63Calculo);
               }
               else
               {
                  AV63Calculo = AV34ProfComisionesRubrosGanPRF;
                  AV13Comision = (decimal)(AV13Comision+AV63Calculo);
                  AV63Calculo = (decimal)(A175SolicitudesItemsPrecioInstalac-AV63Calculo);
                  AV14ComisionALM = (decimal)(AV14ComisionALM+AV63Calculo);
               }
            }
            if ( StringUtil.StrCmp(AV64Veridicar, context.GetMessage( "S", "")) == 0 )
            {
               H8K0( false, 36) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 205, 92, 92, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV13Comision, "ZZZ,ZZZ,ZZZ,ZZZ,ZZ9.99")), 651, Gx_line+0, 790, Gx_line+15, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV14ComisionALM, "ZZZ,ZZZ,ZZZ,ZZZ,ZZ9.99")), 547, Gx_line+0, 686, Gx_line+15, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV35ProfComisionesRubrosTipo, "")), 283, Gx_line+0, 295, Gx_line+17, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV36ProfComisionesRubrosValor, "ZZZZZZZZZZZZZZ9.99")), 300, Gx_line+0, 414, Gx_line+15, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( A175SolicitudesItemsPrecioInstalac, "ZZZZZZ,ZZZ,ZZZ,ZZ9.99")), 417, Gx_line+0, 549, Gx_line+15, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(A121RubrosId), "ZZZ9")), 0, Gx_line+0, 26, Gx_line+15, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(A137MedidasID), "ZZZZZZZZZZZZZZZZZ9")), 33, Gx_line+0, 147, Gx_line+15, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(A135InventarioId), "ZZZZZZZZZZZZZZZZZ9")), 150, Gx_line+0, 264, Gx_line+15, 2+256, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 105, 105, 105, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A122RubrosNombre, "")), 0, Gx_line+17, 380, Gx_line+32, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(0, Gx_line+33, 925, Gx_line+33, 1, 240, 128, 128, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A138MedidasNombre, "")), 267, Gx_line+17, 450, Gx_line+32, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A136InventarioNombre, "")), 400, Gx_line+17, 814, Gx_line+32, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+36);
            }
            pr_default.readNext(1);
         }
         pr_default.close(1);
         if ( AV14ComisionALM + AV13Comision == AV20Importe )
         {
            AV28Ok = "";
         }
         else
         {
            AV28Ok = context.GetMessage( "N", "");
         }
      }

      protected void H8K0( bool bFoot ,
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
               if ( GxHdr2 )
               {
                  getPrinter().GxDrawBitMap(context.GetImagePath( "22922f7f-f2d4-4fde-abb1-d4ceefcb60c5", "", context.GetTheme( )), 13, Gx_line+13, 186, Gx_line+53) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 12, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(context.GetMessage( "Reporte Financiero de Actividades Profesionales", ""), 120, Gx_line+67, 696, Gx_line+94, 1, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 7, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( Gx_time, "")), 714, Gx_line+33, 790, Gx_line+47, 0+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(context.localUtil.Format( Gx_date, "99/99/99"), 660, Gx_line+33, 699, Gx_line+47, 2+256, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(context.GetMessage( "Fecha del Reporte", ""), 661, Gx_line+13, 810, Gx_line+27, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV25LabelRango, "")), 157, Gx_line+101, 679, Gx_line+116, 1+256, 0, 0, 1) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+127);
                  if ( StringUtil.StrCmp(AV29Opciones, context.GetMessage( "S", "")) == 0 )
                  {
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(context.GetMessage( "Estado", ""), 350, Gx_line+59, 457, Gx_line+72, 0, 0, 0, 0) ;
                     getPrinter().GxDrawText(context.GetMessage( "OK", ""), 785, Gx_line+59, 809, Gx_line+71, 2, 0, 0, 0) ;
                     getPrinter().GxDrawText(context.GetMessage( "Solicitud No.", ""), 22, Gx_line+57, 129, Gx_line+70, 0, 0, 0, 0) ;
                     getPrinter().GxDrawText(context.GetMessage( "ComisiónALM", ""), 579, Gx_line+59, 686, Gx_line+72, 2, 0, 0, 0) ;
                     getPrinter().GxDrawText(context.GetMessage( "ComisiónPF", ""), 683, Gx_line+59, 790, Gx_line+72, 2, 0, 0, 0) ;
                     getPrinter().GxDrawText(context.GetMessage( "Pagado", ""), 438, Gx_line+59, 491, Gx_line+72, 0, 0, 0, 0) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV37Profesional, "")), 297, Gx_line+22, 715, Gx_line+37, 0+256, 0, 0, 0) ;
                     getPrinter().GxDrawText(context.GetMessage( "Importe", ""), 458, Gx_line+59, 565, Gx_line+72, 2, 0, 0, 0) ;
                     getPrinter().GxDrawLine(10, Gx_line+48, 810, Gx_line+48, 1, 0, 0, 0, 0) ;
                     getPrinter().GxDrawLine(10, Gx_line+76, 810, Gx_line+76, 1, 0, 0, 0, 0) ;
                     getPrinter().GxDrawText(context.GetMessage( "Profesional:", ""), 22, Gx_line+22, 129, Gx_line+35, 0, 0, 0, 0) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV8ProfesionalesId, "")), 175, Gx_line+22, 280, Gx_line+37, 0+256, 0, 0, 0) ;
                     Gx_OldLine = Gx_line;
                     Gx_line = (int)(Gx_line+79);
                  }
                  else
                  {
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV8ProfesionalesId, "")), 167, Gx_line+13, 272, Gx_line+28, 0+256, 0, 0, 0) ;
                     getPrinter().GxDrawText(context.GetMessage( "Profesional:", ""), 22, Gx_line+13, 129, Gx_line+26, 0, 0, 0, 0) ;
                     getPrinter().GxDrawLine(10, Gx_line+67, 810, Gx_line+67, 1, 0, 0, 0, 0) ;
                     getPrinter().GxDrawLine(10, Gx_line+39, 810, Gx_line+39, 1, 0, 0, 0, 0) ;
                     getPrinter().GxDrawText(context.GetMessage( "Estado", ""), 350, Gx_line+50, 457, Gx_line+63, 0, 0, 0, 0) ;
                     getPrinter().GxDrawText(context.GetMessage( "Importe", ""), 458, Gx_line+50, 565, Gx_line+63, 2, 0, 0, 0) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV37Profesional, "")), 293, Gx_line+13, 711, Gx_line+28, 0+256, 0, 0, 0) ;
                     getPrinter().GxDrawText(context.GetMessage( "Pagado", ""), 433, Gx_line+50, 486, Gx_line+63, 0, 0, 0, 0) ;
                     getPrinter().GxDrawText(context.GetMessage( "ComisiónPF", ""), 683, Gx_line+50, 790, Gx_line+63, 2, 0, 0, 0) ;
                     getPrinter().GxDrawText(context.GetMessage( "Solicitud No.", ""), 22, Gx_line+48, 129, Gx_line+61, 0, 0, 0, 0) ;
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
         /* Using cursor P008K4 */
         pr_default.execute(2, new Object[] {A127SolicitudesID});
         while ( (pr_default.getStatus(2) != 101) && ( P008K4_A127SolicitudesID[0] == A127SolicitudesID ) )
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( P008K4_A178SolicitudItemsSR[0])) || ( StringUtil.StrCmp(P008K4_A179SolicitudItemsComisionTipo[0], "N") == 0 ) )
            {
               A175SolicitudesItemsPrecioInstalac = (decimal)((P008K4_A176SolicitudesItemsPrecioFinal[0]*P008K4_A177SolicitudesItemsCantidad[0]));
            }
            else
            {
               if ( ( StringUtil.StrCmp(P008K4_A179SolicitudItemsComisionTipo[0], "F") == 0 ) && ( StringUtil.StrCmp(P008K4_A178SolicitudItemsSR[0], "R") == 0 ) )
               {
                  A175SolicitudesItemsPrecioInstalac = (decimal)((P008K4_A176SolicitudesItemsPrecioFinal[0]*P008K4_A177SolicitudesItemsCantidad[0])-(P008K4_A180SolicitudItemsComision[0]*P008K4_A177SolicitudesItemsCantidad[0]));
               }
               else
               {
                  if ( ( StringUtil.StrCmp(P008K4_A179SolicitudItemsComisionTipo[0], "F") == 0 ) && ( StringUtil.StrCmp(P008K4_A178SolicitudItemsSR[0], "S") == 0 ) )
                  {
                     A175SolicitudesItemsPrecioInstalac = (decimal)((P008K4_A176SolicitudesItemsPrecioFinal[0]*P008K4_A177SolicitudesItemsCantidad[0])+(P008K4_A180SolicitudItemsComision[0]*P008K4_A177SolicitudesItemsCantidad[0]));
                  }
                  else
                  {
                     if ( ( StringUtil.StrCmp(P008K4_A179SolicitudItemsComisionTipo[0], "P") == 0 ) && ( StringUtil.StrCmp(P008K4_A178SolicitudItemsSR[0], "R") == 0 ) )
                     {
                        A175SolicitudesItemsPrecioInstalac = (decimal)((P008K4_A176SolicitudesItemsPrecioFinal[0]*P008K4_A177SolicitudesItemsCantidad[0])-((P008K4_A176SolicitudesItemsPrecioFinal[0]*P008K4_A177SolicitudesItemsCantidad[0])*(P008K4_A180SolicitudItemsComision[0]/ (decimal)(100))));
                     }
                     else
                     {
                        if ( ( StringUtil.StrCmp(P008K4_A179SolicitudItemsComisionTipo[0], "P") == 0 ) && ( StringUtil.StrCmp(P008K4_A178SolicitudItemsSR[0], "S") == 0 ) )
                        {
                           A175SolicitudesItemsPrecioInstalac = (decimal)((P008K4_A176SolicitudesItemsPrecioFinal[0]*P008K4_A177SolicitudesItemsCantidad[0])+((P008K4_A176SolicitudesItemsPrecioFinal[0]*P008K4_A177SolicitudesItemsCantidad[0])*(P008K4_A180SolicitudItemsComision[0]/ (decimal)(100))));
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
            pr_default.readNext(2);
         }
         pr_default.close(2);
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
         AV37Profesional = "";
         AV8ProfesionalesId = "";
         AV25LabelRango = "";
         Gx_time = "";
         Gx_date = DateTime.MinValue;
         P008K2_A130EstadosSolTipo = new string[] {""} ;
         P008K2_A438SolicitudServicioOrigenPago = new string[] {""} ;
         P008K2_n438SolicitudServicioOrigenPago = new bool[] {false} ;
         P008K2_A184SolicitudesFechaInstalacion = new DateTime[] {DateTime.MinValue} ;
         P008K2_A131EstadosSolId = new int[1] ;
         P008K2_A127SolicitudesID = new long[1] ;
         P008K2_A171SolicitudesNombre = new string[] {""} ;
         P008K2_A132EstadosSolNombre = new string[] {""} ;
         P008K2_A796SolicitudesComisionMetodoPago = new decimal[1] ;
         P008K2_A212SolicitudesCotizacion = new decimal[1] ;
         P008K2_A1016SolicitudesDescuentoCupon = new decimal[1] ;
         P008K2_A897SolicitudesDescuento = new decimal[1] ;
         P008K2_n897SolicitudesDescuento = new bool[] {false} ;
         P008K2_A864SolicitudesCostoXZona = new decimal[1] ;
         A130EstadosSolTipo = "";
         A438SolicitudServicioOrigenPago = "";
         A184SolicitudesFechaInstalacion = DateTime.MinValue;
         A171SolicitudesNombre = "";
         A132EstadosSolNombre = "";
         AV27NombreCliente = "";
         AV17Estado = "";
         AV18Exists = "";
         GXt_char1 = "";
         AV30OrigenPago = "";
         AV9Calcular = "";
         AV28Ok = "";
         AV42ProveedorNombre = "";
         AV51TipoComiProv = "";
         AV47SolicitudItemsComisionTipo = "";
         P008K3_A121RubrosId = new short[1] ;
         P008K3_A127SolicitudesID = new long[1] ;
         P008K3_A133ProveedorID = new long[1] ;
         P008K3_A282ProveedorNombre = new string[] {""} ;
         P008K3_A212SolicitudesCotizacion = new decimal[1] ;
         P008K3_A137MedidasID = new long[1] ;
         P008K3_A135InventarioId = new long[1] ;
         P008K3_A136InventarioNombre = new string[] {""} ;
         P008K3_A138MedidasNombre = new string[] {""} ;
         P008K3_A122RubrosNombre = new string[] {""} ;
         P008K3_A180SolicitudItemsComision = new decimal[1] ;
         P008K3_A179SolicitudItemsComisionTipo = new string[] {""} ;
         P008K3_A178SolicitudItemsSR = new string[] {""} ;
         P008K3_A177SolicitudesItemsCantidad = new short[1] ;
         P008K3_A176SolicitudesItemsPrecioFinal = new decimal[1] ;
         P008K3_n176SolicitudesItemsPrecioFinal = new bool[] {false} ;
         P008K3_A134SolicitudesItemsID = new short[1] ;
         A282ProveedorNombre = "";
         A136InventarioNombre = "";
         A138MedidasNombre = "";
         A122RubrosNombre = "";
         A179SolicitudItemsComisionTipo = "";
         A178SolicitudItemsSR = "";
         AV48SolicitudItemsSR = "";
         AV35ProfComisionesRubrosTipo = "";
         P008K4_A127SolicitudesID = new long[1] ;
         P008K4_A134SolicitudesItemsID = new short[1] ;
         P008K4_A180SolicitudItemsComision = new decimal[1] ;
         P008K4_A179SolicitudItemsComisionTipo = new string[] {""} ;
         P008K4_A178SolicitudItemsSR = new string[] {""} ;
         P008K4_A177SolicitudesItemsCantidad = new short[1] ;
         P008K4_A176SolicitudesItemsPrecioFinal = new decimal[1] ;
         P008K4_n176SolicitudesItemsPrecioFinal = new bool[] {false} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.areporteprofcomi__default(),
            new Object[][] {
                new Object[] {
               P008K2_A130EstadosSolTipo, P008K2_A438SolicitudServicioOrigenPago, P008K2_n438SolicitudServicioOrigenPago, P008K2_A184SolicitudesFechaInstalacion, P008K2_A131EstadosSolId, P008K2_A127SolicitudesID, P008K2_A171SolicitudesNombre, P008K2_A132EstadosSolNombre, P008K2_A796SolicitudesComisionMetodoPago, P008K2_A212SolicitudesCotizacion,
               P008K2_A1016SolicitudesDescuentoCupon, P008K2_A897SolicitudesDescuento, P008K2_n897SolicitudesDescuento, P008K2_A864SolicitudesCostoXZona
               }
               , new Object[] {
               P008K3_A121RubrosId, P008K3_A127SolicitudesID, P008K3_A133ProveedorID, P008K3_A282ProveedorNombre, P008K3_A212SolicitudesCotizacion, P008K3_A137MedidasID, P008K3_A135InventarioId, P008K3_A136InventarioNombre, P008K3_A138MedidasNombre, P008K3_A122RubrosNombre,
               P008K3_A180SolicitudItemsComision, P008K3_A179SolicitudItemsComisionTipo, P008K3_A178SolicitudItemsSR, P008K3_A177SolicitudesItemsCantidad, P008K3_A176SolicitudesItemsPrecioFinal, P008K3_n176SolicitudesItemsPrecioFinal, P008K3_A134SolicitudesItemsID
               }
               , new Object[] {
               P008K4_A127SolicitudesID, P008K4_A134SolicitudesItemsID, P008K4_A180SolicitudItemsComision, P008K4_A179SolicitudItemsComisionTipo, P008K4_A178SolicitudItemsSR, P008K4_A177SolicitudesItemsCantidad, P008K4_A176SolicitudesItemsPrecioFinal, P008K4_n176SolicitudesItemsPrecioFinal
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
      private short AV24ItemCant ;
      private short A121RubrosId ;
      private short A177SolicitudesItemsCantidad ;
      private short A134SolicitudesItemsID ;
      private int AV10Clasificaciones ;
      private int M_top ;
      private int M_bot ;
      private int Line ;
      private int ToSkip ;
      private int PrtOffset ;
      private int Gx_OldLine ;
      private int A131EstadosSolId ;
      private long AV21InSolicitudesID ;
      private long AV39ProfesionalesFeedBackCant ;
      private long A127SolicitudesID ;
      private long AV44SolicitudesID ;
      private long AV41ProveedorID ;
      private long A133ProveedorID ;
      private long A137MedidasID ;
      private long A135InventarioId ;
      private long GXt_int2 ;
      private long GXt_int3 ;
      private decimal AV40ProfesionalesFeedBackProm ;
      private decimal AV38ProfesionalesFeedback ;
      private decimal A796SolicitudesComisionMetodoPago ;
      private decimal A212SolicitudesCotizacion ;
      private decimal A1016SolicitudesDescuentoCupon ;
      private decimal A897SolicitudesDescuento ;
      private decimal A864SolicitudesCostoXZona ;
      private decimal A211SolicitudServicioPFinal ;
      private decimal A174SolicitudesTotal ;
      private decimal AV20Importe ;
      private decimal AV13Comision ;
      private decimal AV14ComisionALM ;
      private decimal AV58TotalHab ;
      private decimal AV52TotalAcep ;
      private decimal AV57TotalFin ;
      private decimal AV54TotalComisionProf ;
      private decimal AV53TotalAlmango ;
      private decimal AV55TotalComisionProveedor ;
      private decimal AV11ComiProv ;
      private decimal AV23InventarioPrecioFinal ;
      private decimal AV34ProfComisionesRubrosGanPRF ;
      private decimal AV60TotalPorcentPRF ;
      private decimal AV61TotalPreFijoPRF ;
      private decimal A180SolicitudItemsComision ;
      private decimal A176SolicitudesItemsPrecioFinal ;
      private decimal A175SolicitudesItemsPrecioInstalac ;
      private decimal AV46SolicitudItemsComision ;
      private decimal AV63Calculo ;
      private decimal AV33ProfComisionesRubrosGan ;
      private decimal AV36ProfComisionesRubrosValor ;
      private decimal AV12ComiProveedor ;
      private decimal AV16DividirComiProv ;
      private string GXKey ;
      private string GXDecQS ;
      private string gxfirstwebparm ;
      private string A120ProfesionalesId ;
      private string AV49SolicitudServicioOrigenPago ;
      private string AV29Opciones ;
      private string AV64Veridicar ;
      private string AV37Profesional ;
      private string AV8ProfesionalesId ;
      private string AV25LabelRango ;
      private string Gx_time ;
      private string A130EstadosSolTipo ;
      private string A438SolicitudServicioOrigenPago ;
      private string A171SolicitudesNombre ;
      private string A132EstadosSolNombre ;
      private string AV27NombreCliente ;
      private string AV17Estado ;
      private string AV18Exists ;
      private string GXt_char1 ;
      private string AV30OrigenPago ;
      private string AV9Calcular ;
      private string AV28Ok ;
      private string AV42ProveedorNombre ;
      private string AV51TipoComiProv ;
      private string AV47SolicitudItemsComisionTipo ;
      private string A282ProveedorNombre ;
      private string A136InventarioNombre ;
      private string A138MedidasNombre ;
      private string A122RubrosNombre ;
      private string A179SolicitudItemsComisionTipo ;
      private string A178SolicitudItemsSR ;
      private string AV48SolicitudItemsSR ;
      private string AV35ProfComisionesRubrosTipo ;
      private DateTime AV15Desde ;
      private DateTime AV19Hasta ;
      private DateTime Gx_date ;
      private DateTime A184SolicitudesFechaInstalacion ;
      private bool entryPointCalled ;
      private bool GxHdr2 ;
      private bool n438SolicitudServicioOrigenPago ;
      private bool n897SolicitudesDescuento ;
      private bool returnInSub ;
      private bool n176SolicitudesItemsPrecioFinal ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private string aP0_ProfesionalesId ;
      private long aP1_InSolicitudesID ;
      private DateTime aP2_Desde ;
      private DateTime aP3_Hasta ;
      private int aP4_Clasificaciones ;
      private string aP5_SolicitudServicioOrigenPago ;
      private string aP6_Opciones ;
      private string aP7_Veridicar ;
      private IDataStoreProvider pr_default ;
      private string[] P008K2_A130EstadosSolTipo ;
      private string[] P008K2_A438SolicitudServicioOrigenPago ;
      private bool[] P008K2_n438SolicitudServicioOrigenPago ;
      private DateTime[] P008K2_A184SolicitudesFechaInstalacion ;
      private int[] P008K2_A131EstadosSolId ;
      private long[] P008K2_A127SolicitudesID ;
      private string[] P008K2_A171SolicitudesNombre ;
      private string[] P008K2_A132EstadosSolNombre ;
      private decimal[] P008K2_A796SolicitudesComisionMetodoPago ;
      private decimal[] P008K2_A212SolicitudesCotizacion ;
      private decimal[] P008K2_A1016SolicitudesDescuentoCupon ;
      private decimal[] P008K2_A897SolicitudesDescuento ;
      private bool[] P008K2_n897SolicitudesDescuento ;
      private decimal[] P008K2_A864SolicitudesCostoXZona ;
      private short[] P008K3_A121RubrosId ;
      private long[] P008K3_A127SolicitudesID ;
      private long[] P008K3_A133ProveedorID ;
      private string[] P008K3_A282ProveedorNombre ;
      private decimal[] P008K3_A212SolicitudesCotizacion ;
      private long[] P008K3_A137MedidasID ;
      private long[] P008K3_A135InventarioId ;
      private string[] P008K3_A136InventarioNombre ;
      private string[] P008K3_A138MedidasNombre ;
      private string[] P008K3_A122RubrosNombre ;
      private decimal[] P008K3_A180SolicitudItemsComision ;
      private string[] P008K3_A179SolicitudItemsComisionTipo ;
      private string[] P008K3_A178SolicitudItemsSR ;
      private short[] P008K3_A177SolicitudesItemsCantidad ;
      private decimal[] P008K3_A176SolicitudesItemsPrecioFinal ;
      private bool[] P008K3_n176SolicitudesItemsPrecioFinal ;
      private short[] P008K3_A134SolicitudesItemsID ;
      private long[] P008K4_A127SolicitudesID ;
      private short[] P008K4_A134SolicitudesItemsID ;
      private decimal[] P008K4_A180SolicitudItemsComision ;
      private string[] P008K4_A179SolicitudItemsComisionTipo ;
      private string[] P008K4_A178SolicitudItemsSR ;
      private short[] P008K4_A177SolicitudesItemsCantidad ;
      private decimal[] P008K4_A176SolicitudesItemsPrecioFinal ;
      private bool[] P008K4_n176SolicitudesItemsPrecioFinal ;
   }

   public class areporteprofcomi__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
         ,new ForEachCursor(def[2])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP008K2;
          prmP008K2 = new Object[] {
          new ParDef("@AV21InSolicitudesID",GXType.Decimal,18,0) ,
          new ParDef("@AV10Clasificaciones",GXType.Int32,5,0) ,
          new ParDef("@AV15Desde",GXType.Date,8,0) ,
          new ParDef("@AV19Hasta",GXType.Date,8,0) ,
          new ParDef("@AV49SolicitudServicioOrigenPago",GXType.NChar,1,0)
          };
          Object[] prmP008K3;
          prmP008K3 = new Object[] {
          new ParDef("@AV44SolicitudesID",GXType.Decimal,18,0)
          };
          Object[] prmP008K4;
          prmP008K4 = new Object[] {
          new ParDef("@SolicitudesID",GXType.Decimal,18,0)
          };
          def= new CursorDef[] {
              new CursorDef("P008K2", "SELECT T1.[EstadosSolTipo] AS EstadosSolTipo, T1.[SolicitudServicioOrigenPago], T1.[SolicitudesFechaInstalacion], T1.[EstadosSolId] AS EstadosSolId, T1.[SolicitudesID], T1.[SolicitudesNombre], T2.[EstadosGenericosNombre] AS EstadosSolNombre, T1.[SolicitudesComisionMetodoPago], T1.[SolicitudesCotizacion], T1.[SolicitudesDescuentoCupon], T1.[SolicitudesDescuento], T1.[SolicitudesCostoXZona] FROM ([Solicitudes] T1 INNER JOIN [EstadosGenericos] T2 ON T2.[EstadosTipo] = T1.[EstadosSolTipo] AND T2.[EstadosGenericosId] = T1.[EstadosSolId]) WHERE (T1.[SolicitudesID] = @AV21InSolicitudesID or @AV21InSolicitudesID = 0) AND (T1.[EstadosSolId] = @AV10Clasificaciones or @AV10Clasificaciones = 0) AND (T1.[SolicitudesFechaInstalacion] >= @AV15Desde and T1.[SolicitudesFechaInstalacion] <= @AV19Hasta) AND (T1.[SolicitudServicioOrigenPago] = @AV49SolicitudServicioOrigenPago or @AV49SolicitudServicioOrigenPago = '') ORDER BY T1.[SolicitudesID] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP008K2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P008K3", "SELECT T1.[RubrosId], T1.[SolicitudesID], T3.[ProveedorID], T4.[ProveedorNombre], T3.[SolicitudesCotizacion], T1.[MedidasID], T1.[InventarioId], T6.[InventarioNombre], T5.[MedidasNombre], T2.[RubrosNombre], T1.[SolicitudItemsComision], T1.[SolicitudItemsComisionTipo], T1.[SolicitudItemsSR], T1.[SolicitudesItemsCantidad], T1.[SolicitudesItemsPrecioFinal], T1.[SolicitudesItemsID] FROM ((((([SolicitudesItems] T1 INNER JOIN [Rubros] T2 ON T2.[RubrosId] = T1.[RubrosId]) INNER JOIN [Solicitudes] T3 ON T3.[SolicitudesID] = T1.[SolicitudesID]) INNER JOIN [Proveedor] T4 ON T4.[ProveedorID] = T3.[ProveedorID]) INNER JOIN [RubrosMedidas] T5 ON T5.[RubrosId] = T1.[RubrosId] AND T5.[MedidasID] = T1.[MedidasID]) INNER JOIN [Inventario] T6 ON T6.[RubrosId] = T1.[RubrosId] AND T6.[MedidasID] = T1.[MedidasID] AND T6.[InventarioId] = T1.[InventarioId]) WHERE (T1.[SolicitudesID] = @AV44SolicitudesID) AND (T1.[RubrosId] > 0) ORDER BY T1.[SolicitudesID] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP008K3,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P008K4", "SELECT [SolicitudesID], [SolicitudesItemsID], [SolicitudItemsComision], [SolicitudItemsComisionTipo], [SolicitudItemsSR], [SolicitudesItemsCantidad], [SolicitudesItemsPrecioFinal] FROM [SolicitudesItems] WHERE [SolicitudesID] = @SolicitudesID ORDER BY [SolicitudesID] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP008K4,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[1])[0] = rslt.getString(2, 1);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((DateTime[]) buf[3])[0] = rslt.getGXDate(3);
                ((int[]) buf[4])[0] = rslt.getInt(4);
                ((long[]) buf[5])[0] = rslt.getLong(5);
                ((string[]) buf[6])[0] = rslt.getString(6, 100);
                ((string[]) buf[7])[0] = rslt.getString(7, 80);
                ((decimal[]) buf[8])[0] = rslt.getDecimal(8);
                ((decimal[]) buf[9])[0] = rslt.getDecimal(9);
                ((decimal[]) buf[10])[0] = rslt.getDecimal(10);
                ((decimal[]) buf[11])[0] = rslt.getDecimal(11);
                ((bool[]) buf[12])[0] = rslt.wasNull(11);
                ((decimal[]) buf[13])[0] = rslt.getDecimal(12);
                return;
             case 1 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((long[]) buf[1])[0] = rslt.getLong(2);
                ((long[]) buf[2])[0] = rslt.getLong(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 80);
                ((decimal[]) buf[4])[0] = rslt.getDecimal(5);
                ((long[]) buf[5])[0] = rslt.getLong(6);
                ((long[]) buf[6])[0] = rslt.getLong(7);
                ((string[]) buf[7])[0] = rslt.getString(8, 100);
                ((string[]) buf[8])[0] = rslt.getString(9, 50);
                ((string[]) buf[9])[0] = rslt.getString(10, 100);
                ((decimal[]) buf[10])[0] = rslt.getDecimal(11);
                ((string[]) buf[11])[0] = rslt.getString(12, 1);
                ((string[]) buf[12])[0] = rslt.getString(13, 1);
                ((short[]) buf[13])[0] = rslt.getShort(14);
                ((decimal[]) buf[14])[0] = rslt.getDecimal(15);
                ((bool[]) buf[15])[0] = rslt.wasNull(15);
                ((short[]) buf[16])[0] = rslt.getShort(16);
                return;
             case 2 :
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

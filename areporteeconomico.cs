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
   public class areporteeconomico : GXWebProcedure, System.Web.SessionState.IRequiresSessionState
   {
      public override void webExecute( )
      {
         context.SetDefaultTheme("WorkWithPlusDS", true);
         initialize();
         GXKey = Crypto.GetSiteKey( );
         if ( ( StringUtil.StrCmp(context.GetRequestQueryString( ), "") != 0 ) && ( GxWebError == 0 ) )
         {
            GXDecQS = UriDecrypt64( context.GetRequestQueryString( ), GXKey);
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "areporteeconomico.aspx")), "areporteeconomico.aspx") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "areporteeconomico.aspx")))) ;
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
                  AV11SolicitudesID = (long)(Math.Round(NumberUtil.Val( GetPar( "SolicitudesID"), "."), 18, MidpointRounding.ToEven));
                  AV8Desde = context.localUtil.ParseDateParm( GetPar( "Desde"));
                  AV9Hasta = context.localUtil.ParseDateParm( GetPar( "Hasta"));
                  AV29Clasificaciones = (int)(Math.Round(NumberUtil.Val( GetPar( "Clasificaciones"), "."), 18, MidpointRounding.ToEven));
                  AV27SolicitudServicioOrigenPago = GetPar( "SolicitudServicioOrigenPago");
                  AV32IncTotal = StringUtil.StrToBool( GetPar( "IncTotal"));
               }
            }
         }
         if ( GxWebError == 0 )
         {
            ExecutePrivate();
         }
         cleanup();
      }

      public areporteeconomico( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public areporteeconomico( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( ref string aP0_ProfesionalesId ,
                           ref long aP1_SolicitudesID ,
                           ref DateTime aP2_Desde ,
                           ref DateTime aP3_Hasta ,
                           ref int aP4_Clasificaciones ,
                           ref string aP5_SolicitudServicioOrigenPago ,
                           ref bool aP6_IncTotal )
      {
         this.A120ProfesionalesId = aP0_ProfesionalesId;
         this.AV11SolicitudesID = aP1_SolicitudesID;
         this.AV8Desde = aP2_Desde;
         this.AV9Hasta = aP3_Hasta;
         this.AV29Clasificaciones = aP4_Clasificaciones;
         this.AV27SolicitudServicioOrigenPago = aP5_SolicitudServicioOrigenPago;
         this.AV32IncTotal = aP6_IncTotal;
         initialize();
         ExecutePrivate();
         aP0_ProfesionalesId=this.A120ProfesionalesId;
         aP1_SolicitudesID=this.AV11SolicitudesID;
         aP2_Desde=this.AV8Desde;
         aP3_Hasta=this.AV9Hasta;
         aP4_Clasificaciones=this.AV29Clasificaciones;
         aP5_SolicitudServicioOrigenPago=this.AV27SolicitudServicioOrigenPago;
         aP6_IncTotal=this.AV32IncTotal;
      }

      public bool executeUdp( ref string aP0_ProfesionalesId ,
                              ref long aP1_SolicitudesID ,
                              ref DateTime aP2_Desde ,
                              ref DateTime aP3_Hasta ,
                              ref int aP4_Clasificaciones ,
                              ref string aP5_SolicitudServicioOrigenPago )
      {
         execute(ref aP0_ProfesionalesId, ref aP1_SolicitudesID, ref aP2_Desde, ref aP3_Hasta, ref aP4_Clasificaciones, ref aP5_SolicitudServicioOrigenPago, ref aP6_IncTotal);
         return AV32IncTotal ;
      }

      public void executeSubmit( ref string aP0_ProfesionalesId ,
                                 ref long aP1_SolicitudesID ,
                                 ref DateTime aP2_Desde ,
                                 ref DateTime aP3_Hasta ,
                                 ref int aP4_Clasificaciones ,
                                 ref string aP5_SolicitudServicioOrigenPago ,
                                 ref bool aP6_IncTotal )
      {
         this.A120ProfesionalesId = aP0_ProfesionalesId;
         this.AV11SolicitudesID = aP1_SolicitudesID;
         this.AV8Desde = aP2_Desde;
         this.AV9Hasta = aP3_Hasta;
         this.AV29Clasificaciones = aP4_Clasificaciones;
         this.AV27SolicitudServicioOrigenPago = aP5_SolicitudServicioOrigenPago;
         this.AV32IncTotal = aP6_IncTotal;
         SubmitImpl();
         aP0_ProfesionalesId=this.A120ProfesionalesId;
         aP1_SolicitudesID=this.AV11SolicitudesID;
         aP2_Desde=this.AV8Desde;
         aP3_Hasta=this.AV9Hasta;
         aP4_Clasificaciones=this.AV29Clasificaciones;
         aP5_SolicitudServicioOrigenPago=this.AV27SolicitudServicioOrigenPago;
         aP6_IncTotal=this.AV32IncTotal;
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
            new oprofesionalnombre(context ).execute(  A120ProfesionalesId, out  AV10Profesional, out  AV26ProfesionalesFeedBackCant, out  AV25ProfesionalesFeedBackProm, out  AV24ProfesionalesFeedback) ;
            AV16ProfesionalesId = StringUtil.Trim( A120ProfesionalesId);
            AV23LabelRango = context.GetMessage( "Rango de fecha: ", "") + StringUtil.Trim( context.localUtil.Format( AV8Desde, "99/99/99")) + " - " + StringUtil.Trim( context.localUtil.Format( AV9Hasta, "99/99/99"));
            H8H0( false, 127) ;
            getPrinter().GxDrawBitMap(context.GetImagePath( "22922f7f-f2d4-4fde-abb1-d4ceefcb60c5", "", context.GetTheme( )), 13, Gx_line+13, 186, Gx_line+53) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 12, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Reporte Financiero de Actividades Profesionales", ""), 120, Gx_line+67, 696, Gx_line+94, 1, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 7, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( Gx_time, "")), 714, Gx_line+33, 790, Gx_line+47, 0+256, 0, 0, 0) ;
            getPrinter().GxDrawText(context.localUtil.Format( Gx_date, "99/99/99"), 660, Gx_line+33, 699, Gx_line+47, 2+256, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Fecha del Reporte", ""), 661, Gx_line+13, 810, Gx_line+27, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV23LabelRango, "")), 157, Gx_line+101, 679, Gx_line+116, 1+256, 0, 0, 1) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+127);
            if ( ! AV32IncTotal )
            {
               H8H0( false, 68) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(context.GetMessage( "Pagado", ""), 608, Gx_line+50, 661, Gx_line+63, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV10Profesional, "")), 300, Gx_line+17, 718, Gx_line+32, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText(context.GetMessage( "Estado", ""), 492, Gx_line+50, 599, Gx_line+63, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(35, Gx_line+50, 775, Gx_line+50, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(42, Gx_line+67, 782, Gx_line+67, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(context.GetMessage( "Profesional:", ""), 35, Gx_line+17, 142, Gx_line+30, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(context.GetMessage( "Solicitud No.", ""), 35, Gx_line+50, 142, Gx_line+63, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV16ProfesionalesId, "")), 175, Gx_line+17, 280, Gx_line+32, 0+256, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+68);
            }
            else
            {
               H8H0( false, 68) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV16ProfesionalesId, "")), 167, Gx_line+13, 272, Gx_line+28, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText(context.GetMessage( "Solicitud No.", ""), 35, Gx_line+48, 142, Gx_line+61, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(context.GetMessage( "Profesional:", ""), 40, Gx_line+13, 147, Gx_line+26, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(33, Gx_line+67, 773, Gx_line+67, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(33, Gx_line+40, 773, Gx_line+40, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(context.GetMessage( "Estado", ""), 487, Gx_line+53, 594, Gx_line+66, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(context.GetMessage( "Importe", ""), 666, Gx_line+53, 773, Gx_line+66, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV10Profesional, "")), 293, Gx_line+13, 711, Gx_line+28, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText(context.GetMessage( "Pagado", ""), 601, Gx_line+53, 654, Gx_line+66, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+68);
            }
            GxHdr2 = true;
            /* Using cursor P008H2 */
            pr_default.execute(0, new Object[] {AV11SolicitudesID, AV29Clasificaciones, AV8Desde, AV9Hasta, AV27SolicitudServicioOrigenPago});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A130EstadosSolTipo = P008H2_A130EstadosSolTipo[0];
               A438SolicitudServicioOrigenPago = P008H2_A438SolicitudServicioOrigenPago[0];
               n438SolicitudServicioOrigenPago = P008H2_n438SolicitudServicioOrigenPago[0];
               A184SolicitudesFechaInstalacion = P008H2_A184SolicitudesFechaInstalacion[0];
               A131EstadosSolId = P008H2_A131EstadosSolId[0];
               A127SolicitudesID = P008H2_A127SolicitudesID[0];
               A171SolicitudesNombre = P008H2_A171SolicitudesNombre[0];
               A132EstadosSolNombre = P008H2_A132EstadosSolNombre[0];
               A796SolicitudesComisionMetodoPago = P008H2_A796SolicitudesComisionMetodoPago[0];
               A212SolicitudesCotizacion = P008H2_A212SolicitudesCotizacion[0];
               A1016SolicitudesDescuentoCupon = P008H2_A1016SolicitudesDescuentoCupon[0];
               A897SolicitudesDescuento = P008H2_A897SolicitudesDescuento[0];
               n897SolicitudesDescuento = P008H2_n897SolicitudesDescuento[0];
               A864SolicitudesCostoXZona = P008H2_A864SolicitudesCostoXZona[0];
               A132EstadosSolNombre = P008H2_A132EstadosSolNombre[0];
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
               if ( ( ( AV29Clasificaciones == 0 ) && ( A131EstadosSolId != 4 ) && ( A131EstadosSolId != 3 ) ) || ( AV29Clasificaciones > 0 ) )
               {
                  AV11SolicitudesID = A127SolicitudesID;
                  AV12NombreCliente = A171SolicitudesNombre;
                  AV13Estado = A132EstadosSolNombre;
                  AV15Exists = context.GetMessage( "N", "");
                  if ( String.IsNullOrEmpty(StringUtil.RTrim( AV16ProfesionalesId)) )
                  {
                     AV15Exists = context.GetMessage( "S", "");
                  }
                  else
                  {
                     GXt_char1 = AV15Exists;
                     new oexisterelacion(context ).execute(  A127SolicitudesID,  AV16ProfesionalesId, out  GXt_char1) ;
                     AV15Exists = GXt_char1;
                  }
                  AV28OrigenPago = A438SolicitudServicioOrigenPago;
                  if ( StringUtil.StrCmp(AV15Exists, context.GetMessage( "S", "")) == 0 )
                  {
                     if ( ! AV32IncTotal )
                     {
                        H8H0( false, 22) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV28OrigenPago, "")), 625, Gx_line+0, 637, Gx_line+15, 0+256, 0, 0, 0) ;
                        getPrinter().GxDrawLine(35, Gx_line+17, 775, Gx_line+17, 1, 220, 220, 220, 0) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV13Estado, "")), 492, Gx_line+0, 571, Gx_line+15, 0+256, 0, 0, 0) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV12NombreCliente, "")), 175, Gx_line+0, 508, Gx_line+15, 0, 0, 0, 0) ;
                        getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV11SolicitudesID), "ZZZZZZZZZZZZZZZZZ9")), 35, Gx_line+0, 149, Gx_line+15, 2+256, 0, 0, 0) ;
                        Gx_OldLine = Gx_line;
                        Gx_line = (int)(Gx_line+22);
                     }
                     else
                     {
                        AV14Importe = A211SolicitudServicioPFinal;
                        H8H0( false, 22) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV11SolicitudesID), "ZZZZZZZZZZZZZZZZZ9")), 35, Gx_line+3, 149, Gx_line+18, 2+256, 0, 0, 0) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV12NombreCliente, "")), 175, Gx_line+0, 508, Gx_line+15, 0, 0, 0, 0) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV13Estado, "")), 487, Gx_line+0, 566, Gx_line+15, 0+256, 0, 0, 0) ;
                        getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV14Importe, "ZZZ,ZZZ,ZZZ,ZZZ,ZZ9.99")), 633, Gx_line+0, 772, Gx_line+15, 2+256, 0, 0, 0) ;
                        getPrinter().GxDrawLine(35, Gx_line+20, 775, Gx_line+20, 1, 220, 220, 220, 0) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV28OrigenPago, "")), 621, Gx_line+0, 633, Gx_line+15, 0+256, 0, 0, 0) ;
                        Gx_OldLine = Gx_line;
                        Gx_line = (int)(Gx_line+22);
                        if ( A131EstadosSolId == 2 )
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
                  }
               }
               pr_default.readNext(0);
            }
            pr_default.close(0);
            GxHdr2 = false;
            if ( AV32IncTotal )
            {
               H8H0( false, 94) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(context.GetMessage( "Total Delegadas/Habilitadas", ""), 8, Gx_line+27, 186, Gx_line+40, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV19TotalAcep, "ZZZ,ZZZ,ZZZ,ZZZ,ZZ9.99")), 327, Gx_line+53, 466, Gx_line+68, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(context.GetMessage( "Total Aceptada", ""), 359, Gx_line+27, 466, Gx_line+40, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV20TotalFin, "ZZZ,ZZZ,ZZZ,ZZZ,ZZ9.99")), 560, Gx_line+49, 699, Gx_line+64, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(context.GetMessage( "Total Finalizadas", ""), 592, Gx_line+27, 699, Gx_line+40, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV21TotalHab, "ZZZ,ZZZ,ZZZ,ZZZ,ZZ9.99")), 47, Gx_line+53, 186, Gx_line+68, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawLine(33, Gx_line+13, 773, Gx_line+13, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(27, Gx_line+80, 767, Gx_line+80, 1, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+94);
            }
            /* Print footer for last page */
            ToSkip = (int)(P_lines+1);
            H8H0( true, 0) ;
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

      protected void H8H0( bool bFoot ,
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
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV23LabelRango, "")), 157, Gx_line+101, 679, Gx_line+116, 1+256, 0, 0, 1) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+127);
                  if ( ! AV32IncTotal )
                  {
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(context.GetMessage( "Pagado", ""), 608, Gx_line+50, 661, Gx_line+63, 0, 0, 0, 0) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV10Profesional, "")), 300, Gx_line+17, 718, Gx_line+32, 0+256, 0, 0, 0) ;
                     getPrinter().GxDrawText(context.GetMessage( "Estado", ""), 492, Gx_line+50, 599, Gx_line+63, 0, 0, 0, 0) ;
                     getPrinter().GxDrawLine(35, Gx_line+50, 775, Gx_line+50, 1, 0, 0, 0, 0) ;
                     getPrinter().GxDrawLine(42, Gx_line+67, 782, Gx_line+67, 1, 0, 0, 0, 0) ;
                     getPrinter().GxDrawText(context.GetMessage( "Profesional:", ""), 35, Gx_line+17, 142, Gx_line+30, 0, 0, 0, 0) ;
                     getPrinter().GxDrawText(context.GetMessage( "Solicitud No.", ""), 35, Gx_line+50, 142, Gx_line+63, 0, 0, 0, 0) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV16ProfesionalesId, "")), 175, Gx_line+17, 280, Gx_line+32, 0+256, 0, 0, 0) ;
                     Gx_OldLine = Gx_line;
                     Gx_line = (int)(Gx_line+68);
                  }
                  else
                  {
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV16ProfesionalesId, "")), 167, Gx_line+13, 272, Gx_line+28, 0+256, 0, 0, 0) ;
                     getPrinter().GxDrawText(context.GetMessage( "Solicitud No.", ""), 35, Gx_line+48, 142, Gx_line+61, 0, 0, 0, 0) ;
                     getPrinter().GxDrawText(context.GetMessage( "Profesional:", ""), 40, Gx_line+13, 147, Gx_line+26, 0, 0, 0, 0) ;
                     getPrinter().GxDrawLine(33, Gx_line+67, 773, Gx_line+67, 1, 0, 0, 0, 0) ;
                     getPrinter().GxDrawLine(33, Gx_line+40, 773, Gx_line+40, 1, 0, 0, 0, 0) ;
                     getPrinter().GxDrawText(context.GetMessage( "Estado", ""), 487, Gx_line+53, 594, Gx_line+66, 0, 0, 0, 0) ;
                     getPrinter().GxDrawText(context.GetMessage( "Importe", ""), 666, Gx_line+53, 773, Gx_line+66, 2, 0, 0, 0) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV10Profesional, "")), 293, Gx_line+13, 711, Gx_line+28, 0+256, 0, 0, 0) ;
                     getPrinter().GxDrawText(context.GetMessage( "Pagado", ""), 601, Gx_line+53, 654, Gx_line+66, 0, 0, 0, 0) ;
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
         /* Using cursor P008H3 */
         pr_default.execute(1, new Object[] {A127SolicitudesID});
         while ( (pr_default.getStatus(1) != 101) && ( P008H3_A127SolicitudesID[0] == A127SolicitudesID ) )
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( P008H3_A178SolicitudItemsSR[0])) || ( StringUtil.StrCmp(P008H3_A179SolicitudItemsComisionTipo[0], "N") == 0 ) )
            {
               A175SolicitudesItemsPrecioInstalac = (decimal)((P008H3_A176SolicitudesItemsPrecioFinal[0]*P008H3_A177SolicitudesItemsCantidad[0]));
            }
            else
            {
               if ( ( StringUtil.StrCmp(P008H3_A179SolicitudItemsComisionTipo[0], "F") == 0 ) && ( StringUtil.StrCmp(P008H3_A178SolicitudItemsSR[0], "R") == 0 ) )
               {
                  A175SolicitudesItemsPrecioInstalac = (decimal)((P008H3_A176SolicitudesItemsPrecioFinal[0]*P008H3_A177SolicitudesItemsCantidad[0])-(P008H3_A180SolicitudItemsComision[0]*P008H3_A177SolicitudesItemsCantidad[0]));
               }
               else
               {
                  if ( ( StringUtil.StrCmp(P008H3_A179SolicitudItemsComisionTipo[0], "F") == 0 ) && ( StringUtil.StrCmp(P008H3_A178SolicitudItemsSR[0], "S") == 0 ) )
                  {
                     A175SolicitudesItemsPrecioInstalac = (decimal)((P008H3_A176SolicitudesItemsPrecioFinal[0]*P008H3_A177SolicitudesItemsCantidad[0])+(P008H3_A180SolicitudItemsComision[0]*P008H3_A177SolicitudesItemsCantidad[0]));
                  }
                  else
                  {
                     if ( ( StringUtil.StrCmp(P008H3_A179SolicitudItemsComisionTipo[0], "P") == 0 ) && ( StringUtil.StrCmp(P008H3_A178SolicitudItemsSR[0], "R") == 0 ) )
                     {
                        A175SolicitudesItemsPrecioInstalac = (decimal)((P008H3_A176SolicitudesItemsPrecioFinal[0]*P008H3_A177SolicitudesItemsCantidad[0])-((P008H3_A176SolicitudesItemsPrecioFinal[0]*P008H3_A177SolicitudesItemsCantidad[0])*(P008H3_A180SolicitudItemsComision[0]/ (decimal)(100))));
                     }
                     else
                     {
                        if ( ( StringUtil.StrCmp(P008H3_A179SolicitudItemsComisionTipo[0], "P") == 0 ) && ( StringUtil.StrCmp(P008H3_A178SolicitudItemsSR[0], "S") == 0 ) )
                        {
                           A175SolicitudesItemsPrecioInstalac = (decimal)((P008H3_A176SolicitudesItemsPrecioFinal[0]*P008H3_A177SolicitudesItemsCantidad[0])+((P008H3_A176SolicitudesItemsPrecioFinal[0]*P008H3_A177SolicitudesItemsCantidad[0])*(P008H3_A180SolicitudItemsComision[0]/ (decimal)(100))));
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
         AV10Profesional = "";
         AV16ProfesionalesId = "";
         AV23LabelRango = "";
         Gx_time = "";
         Gx_date = DateTime.MinValue;
         P008H2_A130EstadosSolTipo = new string[] {""} ;
         P008H2_A438SolicitudServicioOrigenPago = new string[] {""} ;
         P008H2_n438SolicitudServicioOrigenPago = new bool[] {false} ;
         P008H2_A184SolicitudesFechaInstalacion = new DateTime[] {DateTime.MinValue} ;
         P008H2_A131EstadosSolId = new int[1] ;
         P008H2_A127SolicitudesID = new long[1] ;
         P008H2_A171SolicitudesNombre = new string[] {""} ;
         P008H2_A132EstadosSolNombre = new string[] {""} ;
         P008H2_A796SolicitudesComisionMetodoPago = new decimal[1] ;
         P008H2_A212SolicitudesCotizacion = new decimal[1] ;
         P008H2_A1016SolicitudesDescuentoCupon = new decimal[1] ;
         P008H2_A897SolicitudesDescuento = new decimal[1] ;
         P008H2_n897SolicitudesDescuento = new bool[] {false} ;
         P008H2_A864SolicitudesCostoXZona = new decimal[1] ;
         A130EstadosSolTipo = "";
         A438SolicitudServicioOrigenPago = "";
         A184SolicitudesFechaInstalacion = DateTime.MinValue;
         A171SolicitudesNombre = "";
         A132EstadosSolNombre = "";
         AV12NombreCliente = "";
         AV13Estado = "";
         AV15Exists = "";
         GXt_char1 = "";
         AV28OrigenPago = "";
         P008H3_A127SolicitudesID = new long[1] ;
         P008H3_A134SolicitudesItemsID = new short[1] ;
         P008H3_A180SolicitudItemsComision = new decimal[1] ;
         P008H3_A179SolicitudItemsComisionTipo = new string[] {""} ;
         P008H3_A178SolicitudItemsSR = new string[] {""} ;
         P008H3_A177SolicitudesItemsCantidad = new short[1] ;
         P008H3_A176SolicitudesItemsPrecioFinal = new decimal[1] ;
         P008H3_n176SolicitudesItemsPrecioFinal = new bool[] {false} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.areporteeconomico__default(),
            new Object[][] {
                new Object[] {
               P008H2_A130EstadosSolTipo, P008H2_A438SolicitudServicioOrigenPago, P008H2_n438SolicitudServicioOrigenPago, P008H2_A184SolicitudesFechaInstalacion, P008H2_A131EstadosSolId, P008H2_A127SolicitudesID, P008H2_A171SolicitudesNombre, P008H2_A132EstadosSolNombre, P008H2_A796SolicitudesComisionMetodoPago, P008H2_A212SolicitudesCotizacion,
               P008H2_A1016SolicitudesDescuentoCupon, P008H2_A897SolicitudesDescuento, P008H2_n897SolicitudesDescuento, P008H2_A864SolicitudesCostoXZona
               }
               , new Object[] {
               P008H3_A127SolicitudesID, P008H3_A134SolicitudesItemsID, P008H3_A180SolicitudItemsComision, P008H3_A179SolicitudItemsComisionTipo, P008H3_A178SolicitudItemsSR, P008H3_A177SolicitudesItemsCantidad, P008H3_A176SolicitudesItemsPrecioFinal, P008H3_n176SolicitudesItemsPrecioFinal
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
      private int AV29Clasificaciones ;
      private int M_top ;
      private int M_bot ;
      private int Line ;
      private int ToSkip ;
      private int PrtOffset ;
      private int Gx_OldLine ;
      private int A131EstadosSolId ;
      private long AV11SolicitudesID ;
      private long AV26ProfesionalesFeedBackCant ;
      private long A127SolicitudesID ;
      private decimal AV25ProfesionalesFeedBackProm ;
      private decimal AV24ProfesionalesFeedback ;
      private decimal A796SolicitudesComisionMetodoPago ;
      private decimal A212SolicitudesCotizacion ;
      private decimal A1016SolicitudesDescuentoCupon ;
      private decimal A897SolicitudesDescuento ;
      private decimal A864SolicitudesCostoXZona ;
      private decimal A211SolicitudServicioPFinal ;
      private decimal A174SolicitudesTotal ;
      private decimal AV14Importe ;
      private decimal AV21TotalHab ;
      private decimal AV19TotalAcep ;
      private decimal AV20TotalFin ;
      private decimal A175SolicitudesItemsPrecioInstalac ;
      private string GXKey ;
      private string GXDecQS ;
      private string gxfirstwebparm ;
      private string A120ProfesionalesId ;
      private string AV27SolicitudServicioOrigenPago ;
      private string AV10Profesional ;
      private string AV16ProfesionalesId ;
      private string AV23LabelRango ;
      private string Gx_time ;
      private string A130EstadosSolTipo ;
      private string A438SolicitudServicioOrigenPago ;
      private string A171SolicitudesNombre ;
      private string A132EstadosSolNombre ;
      private string AV12NombreCliente ;
      private string AV13Estado ;
      private string AV15Exists ;
      private string GXt_char1 ;
      private string AV28OrigenPago ;
      private DateTime AV8Desde ;
      private DateTime AV9Hasta ;
      private DateTime Gx_date ;
      private DateTime A184SolicitudesFechaInstalacion ;
      private bool entryPointCalled ;
      private bool AV32IncTotal ;
      private bool GxHdr2 ;
      private bool n438SolicitudServicioOrigenPago ;
      private bool n897SolicitudesDescuento ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private string aP0_ProfesionalesId ;
      private long aP1_SolicitudesID ;
      private DateTime aP2_Desde ;
      private DateTime aP3_Hasta ;
      private int aP4_Clasificaciones ;
      private string aP5_SolicitudServicioOrigenPago ;
      private bool aP6_IncTotal ;
      private IDataStoreProvider pr_default ;
      private string[] P008H2_A130EstadosSolTipo ;
      private string[] P008H2_A438SolicitudServicioOrigenPago ;
      private bool[] P008H2_n438SolicitudServicioOrigenPago ;
      private DateTime[] P008H2_A184SolicitudesFechaInstalacion ;
      private int[] P008H2_A131EstadosSolId ;
      private long[] P008H2_A127SolicitudesID ;
      private string[] P008H2_A171SolicitudesNombre ;
      private string[] P008H2_A132EstadosSolNombre ;
      private decimal[] P008H2_A796SolicitudesComisionMetodoPago ;
      private decimal[] P008H2_A212SolicitudesCotizacion ;
      private decimal[] P008H2_A1016SolicitudesDescuentoCupon ;
      private decimal[] P008H2_A897SolicitudesDescuento ;
      private bool[] P008H2_n897SolicitudesDescuento ;
      private decimal[] P008H2_A864SolicitudesCostoXZona ;
      private long[] P008H3_A127SolicitudesID ;
      private short[] P008H3_A134SolicitudesItemsID ;
      private decimal[] P008H3_A180SolicitudItemsComision ;
      private string[] P008H3_A179SolicitudItemsComisionTipo ;
      private string[] P008H3_A178SolicitudItemsSR ;
      private short[] P008H3_A177SolicitudesItemsCantidad ;
      private decimal[] P008H3_A176SolicitudesItemsPrecioFinal ;
      private bool[] P008H3_n176SolicitudesItemsPrecioFinal ;
   }

   public class areporteeconomico__default : DataStoreHelperBase, IDataStoreHelper
   {
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
          Object[] prmP008H2;
          prmP008H2 = new Object[] {
          new ParDef("@AV11SolicitudesID",GXType.Decimal,18,0) ,
          new ParDef("@AV29Clasificaciones",GXType.Int32,5,0) ,
          new ParDef("@AV8Desde",GXType.Date,8,0) ,
          new ParDef("@AV9Hasta",GXType.Date,8,0) ,
          new ParDef("@AV27SolicitudServicioOrigenPago",GXType.NChar,1,0)
          };
          Object[] prmP008H3;
          prmP008H3 = new Object[] {
          new ParDef("@SolicitudesID",GXType.Decimal,18,0)
          };
          def= new CursorDef[] {
              new CursorDef("P008H2", "SELECT T1.[EstadosSolTipo] AS EstadosSolTipo, T1.[SolicitudServicioOrigenPago], T1.[SolicitudesFechaInstalacion], T1.[EstadosSolId] AS EstadosSolId, T1.[SolicitudesID], T1.[SolicitudesNombre], T2.[EstadosGenericosNombre] AS EstadosSolNombre, T1.[SolicitudesComisionMetodoPago], T1.[SolicitudesCotizacion], T1.[SolicitudesDescuentoCupon], T1.[SolicitudesDescuento], T1.[SolicitudesCostoXZona] FROM ([Solicitudes] T1 INNER JOIN [EstadosGenericos] T2 ON T2.[EstadosTipo] = T1.[EstadosSolTipo] AND T2.[EstadosGenericosId] = T1.[EstadosSolId]) WHERE (T1.[SolicitudesID] = @AV11SolicitudesID or @AV11SolicitudesID = 0) AND (T1.[EstadosSolId] = @AV29Clasificaciones or @AV29Clasificaciones = 0) AND (T1.[SolicitudesFechaInstalacion] >= @AV8Desde and T1.[SolicitudesFechaInstalacion] <= @AV9Hasta) AND (T1.[SolicitudServicioOrigenPago] = @AV27SolicitudServicioOrigenPago or @AV27SolicitudServicioOrigenPago = '') ORDER BY T1.[SolicitudesID] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP008H2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P008H3", "SELECT [SolicitudesID], [SolicitudesItemsID], [SolicitudItemsComision], [SolicitudItemsComisionTipo], [SolicitudItemsSR], [SolicitudesItemsCantidad], [SolicitudesItemsPrecioFinal] FROM [SolicitudesItems] WHERE [SolicitudesID] = @SolicitudesID ORDER BY [SolicitudesID] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP008H3,100, GxCacheFrequency.OFF ,true,false )
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

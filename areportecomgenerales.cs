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
   public class areportecomgenerales : GXWebProcedure, System.Web.SessionState.IRequiresSessionState
   {
      public override void webExecute( )
      {
         context.SetDefaultTheme("WorkWithPlusDS", true);
         initialize();
         GXKey = Crypto.GetSiteKey( );
         if ( ( StringUtil.StrCmp(context.GetRequestQueryString( ), "") != 0 ) && ( GxWebError == 0 ) )
         {
            GXDecQS = UriDecrypt64( context.GetRequestQueryString( ), GXKey);
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "areportecomgenerales.aspx")), "areportecomgenerales.aspx") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "areportecomgenerales.aspx")))) ;
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
                  AV37Clasificaciones = (int)(Math.Round(NumberUtil.Val( GetPar( "Clasificaciones"), "."), 18, MidpointRounding.ToEven));
                  AV27SolicitudServicioOrigenPago = GetPar( "SolicitudServicioOrigenPago");
               }
            }
         }
         if ( GxWebError == 0 )
         {
            ExecutePrivate();
         }
         cleanup();
      }

      public areportecomgenerales( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public areportecomgenerales( IGxContext context )
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
                           ref string aP5_SolicitudServicioOrigenPago )
      {
         this.A120ProfesionalesId = aP0_ProfesionalesId;
         this.AV11SolicitudesID = aP1_SolicitudesID;
         this.AV8Desde = aP2_Desde;
         this.AV9Hasta = aP3_Hasta;
         this.AV37Clasificaciones = aP4_Clasificaciones;
         this.AV27SolicitudServicioOrigenPago = aP5_SolicitudServicioOrigenPago;
         initialize();
         ExecutePrivate();
         aP0_ProfesionalesId=this.A120ProfesionalesId;
         aP1_SolicitudesID=this.AV11SolicitudesID;
         aP2_Desde=this.AV8Desde;
         aP3_Hasta=this.AV9Hasta;
         aP4_Clasificaciones=this.AV37Clasificaciones;
         aP5_SolicitudServicioOrigenPago=this.AV27SolicitudServicioOrigenPago;
      }

      public string executeUdp( ref string aP0_ProfesionalesId ,
                                ref long aP1_SolicitudesID ,
                                ref DateTime aP2_Desde ,
                                ref DateTime aP3_Hasta ,
                                ref int aP4_Clasificaciones )
      {
         execute(ref aP0_ProfesionalesId, ref aP1_SolicitudesID, ref aP2_Desde, ref aP3_Hasta, ref aP4_Clasificaciones, ref aP5_SolicitudServicioOrigenPago);
         return AV27SolicitudServicioOrigenPago ;
      }

      public void executeSubmit( ref string aP0_ProfesionalesId ,
                                 ref long aP1_SolicitudesID ,
                                 ref DateTime aP2_Desde ,
                                 ref DateTime aP3_Hasta ,
                                 ref int aP4_Clasificaciones ,
                                 ref string aP5_SolicitudServicioOrigenPago )
      {
         this.A120ProfesionalesId = aP0_ProfesionalesId;
         this.AV11SolicitudesID = aP1_SolicitudesID;
         this.AV8Desde = aP2_Desde;
         this.AV9Hasta = aP3_Hasta;
         this.AV37Clasificaciones = aP4_Clasificaciones;
         this.AV27SolicitudServicioOrigenPago = aP5_SolicitudServicioOrigenPago;
         SubmitImpl();
         aP0_ProfesionalesId=this.A120ProfesionalesId;
         aP1_SolicitudesID=this.AV11SolicitudesID;
         aP2_Desde=this.AV8Desde;
         aP3_Hasta=this.AV9Hasta;
         aP4_Clasificaciones=this.AV37Clasificaciones;
         aP5_SolicitudServicioOrigenPago=this.AV27SolicitudServicioOrigenPago;
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
            H8B0( false, 97) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 12, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Reporte Financiero de Actividades Profesionales", ""), 135, Gx_line+29, 711, Gx_line+56, 1, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 7, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( Gx_time, "")), 714, Gx_line+33, 790, Gx_line+47, 0+256, 0, 0, 0) ;
            getPrinter().GxDrawText(context.localUtil.Format( Gx_date, "99/99/99"), 660, Gx_line+33, 699, Gx_line+47, 2+256, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Fecha del Reporte", ""), 661, Gx_line+13, 810, Gx_line+27, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV23LabelRango, "")), 193, Gx_line+67, 653, Gx_line+82, 1, 0, 0, 1) ;
            getPrinter().GxDrawBitMap(context.GetImagePath( "e6acfd2e-013a-4b78-9d37-37f6dc906ba7", "", context.GetTheme( )), 11, Gx_line+0, 199, Gx_line+63) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 7, false, false, false, false, 0, 105, 105, 105, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Control de Solicitudes de Servicios a Domicilio", ""), 11, Gx_line+67, 264, Gx_line+81, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+97);
            H8B0( false, 68) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV16ProfesionalesId, "")), 151, Gx_line+21, 256, Gx_line+36, 0+256, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Solicitud No.", ""), 113, Gx_line+48, 220, Gx_line+61, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Profesional:", ""), 31, Gx_line+22, 138, Gx_line+35, 0, 0, 0, 0) ;
            getPrinter().GxDrawLine(33, Gx_line+67, 773, Gx_line+67, 1, 0, 0, 0, 0) ;
            getPrinter().GxDrawLine(32, Gx_line+40, 796, Gx_line+40, 1, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Estado", ""), 748, Gx_line+48, 804, Gx_line+60, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(context.GetMessage( "Importe", ""), 621, Gx_line+48, 728, Gx_line+61, 2, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV10Profesional, "")), 277, Gx_line+21, 695, Gx_line+36, 0+256, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Pagado", ""), 411, Gx_line+48, 464, Gx_line+61, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(context.GetMessage( "Almango", ""), 484, Gx_line+48, 546, Gx_line+61, 2, 0, 0, 0) ;
            getPrinter().GxDrawText(context.GetMessage( "Comercio", ""), 584, Gx_line+48, 646, Gx_line+61, 2, 0, 0, 0) ;
            getPrinter().GxDrawText(context.GetMessage( "Trabajo", ""), 31, Gx_line+48, 93, Gx_line+61, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(context.GetMessage( "COMISIONES", ""), 518, Gx_line+22, 614, Gx_line+34, 1, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+68);
            GxHdr2 = true;
            /* Using cursor P008B2 */
            pr_default.execute(0, new Object[] {AV9Hasta, AV11SolicitudesID, AV37Clasificaciones, AV27SolicitudServicioOrigenPago, AV8Desde});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A130EstadosSolTipo = P008B2_A130EstadosSolTipo[0];
               A438SolicitudServicioOrigenPago = P008B2_A438SolicitudServicioOrigenPago[0];
               n438SolicitudServicioOrigenPago = P008B2_n438SolicitudServicioOrigenPago[0];
               A184SolicitudesFechaInstalacion = P008B2_A184SolicitudesFechaInstalacion[0];
               A131EstadosSolId = P008B2_A131EstadosSolId[0];
               A127SolicitudesID = P008B2_A127SolicitudesID[0];
               A171SolicitudesNombre = P008B2_A171SolicitudesNombre[0];
               A527SolicitudServicioComProv = P008B2_A527SolicitudServicioComProv[0];
               n527SolicitudServicioComProv = P008B2_n527SolicitudServicioComProv[0];
               A865SolicitudesCostoXZComAlm = P008B2_A865SolicitudesCostoXZComAlm[0];
               n865SolicitudesCostoXZComAlm = P008B2_n865SolicitudesCostoXZComAlm[0];
               A530SolicitudServicioComALM = P008B2_A530SolicitudServicioComALM[0];
               n530SolicitudServicioComALM = P008B2_n530SolicitudServicioComALM[0];
               A132EstadosSolNombre = P008B2_A132EstadosSolNombre[0];
               A796SolicitudesComisionMetodoPago = P008B2_A796SolicitudesComisionMetodoPago[0];
               A212SolicitudesCotizacion = P008B2_A212SolicitudesCotizacion[0];
               A1016SolicitudesDescuentoCupon = P008B2_A1016SolicitudesDescuentoCupon[0];
               A897SolicitudesDescuento = P008B2_A897SolicitudesDescuento[0];
               n897SolicitudesDescuento = P008B2_n897SolicitudesDescuento[0];
               A864SolicitudesCostoXZona = P008B2_A864SolicitudesCostoXZona[0];
               A132EstadosSolNombre = P008B2_A132EstadosSolNombre[0];
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
               if ( ( ( AV37Clasificaciones == 0 ) && ( A131EstadosSolId != 4 ) && ( A131EstadosSolId != 3 ) ) || ( AV37Clasificaciones > 0 ) )
               {
                  AV11SolicitudesID = A127SolicitudesID;
                  AV12NombreCliente = A171SolicitudesNombre;
                  AV32ComisionProv = A527SolicitudServicioComProv;
                  AV31ComisionALM = (decimal)(A530SolicitudServicioComALM+A865SolicitudesCostoXZComAlm);
                  AV14Importe = A211SolicitudServicioPFinal;
                  AV13Estado = A132EstadosSolNombre;
                  AV29Fecha = A184SolicitudesFechaInstalacion;
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
                     H8B0( false, 22) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV11SolicitudesID), "ZZZZZZZZZZZZZZZZZ9")), 82, Gx_line+1, 196, Gx_line+16, 2+256, 0, 0, 0) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV12NombreCliente, "")), 206, Gx_line+1, 431, Gx_line+16, 0, 0, 0, 0) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV13Estado, "")), 748, Gx_line+1, 827, Gx_line+16, 0+256, 0, 0, 0) ;
                     getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV14Importe, "ZZZ,ZZZ,ZZZ,ZZZ,ZZ9.99")), 589, Gx_line+1, 728, Gx_line+16, 2+256, 0, 0, 0) ;
                     getPrinter().GxDrawLine(32, Gx_line+20, 796, Gx_line+20, 1, 220, 220, 220, 0) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV28OrigenPago, "")), 435, Gx_line+1, 447, Gx_line+16, 0+256, 0, 0, 0) ;
                     getPrinter().GxDrawText(context.localUtil.Format( AV29Fecha, "99/99/99"), 31, Gx_line+1, 80, Gx_line+16, 2+256, 0, 0, 0) ;
                     getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV32ComisionProv, "ZZZZZZ,ZZZ,ZZZ,ZZ9.99")), 515, Gx_line+1, 647, Gx_line+16, 2+256, 0, 0, 0) ;
                     getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV31ComisionALM, "ZZZZZZ,ZZZ,ZZZ,ZZ9.99")), 415, Gx_line+1, 547, Gx_line+16, 2+256, 0, 0, 0) ;
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
                     AV36TotalOrden = (decimal)(AV36TotalOrden+A211SolicitudServicioPFinal);
                     AV34TotalComisionProveedor = (decimal)(AV34TotalComisionProveedor+AV32ComisionProv);
                     AV35TotalAlmango = (decimal)(AV35TotalAlmango+AV31ComisionALM);
                  }
               }
               pr_default.readNext(0);
            }
            pr_default.close(0);
            GxHdr2 = false;
            AV33TotalComisiones = (decimal)(AV36TotalOrden-AV34TotalComisionProveedor-AV35TotalAlmango);
            H8B0( false, 156) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Profesional", ""), 729, Gx_line+20, 796, Gx_line+33, 2, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV33TotalComisiones, "ZZZZZZ,ZZZ,ZZZ,ZZ9.99")), 664, Gx_line+35, 796, Gx_line+50, 2+256, 0, 0, 0) ;
            getPrinter().GxDrawLine(32, Gx_line+10, 796, Gx_line+10, 1, 0, 0, 0, 0) ;
            getPrinter().GxDrawBitMap(context.GetImagePath( "22922f7f-f2d4-4fde-abb1-d4ceefcb60c5", "", context.GetTheme( )), 579, Gx_line+101, 711, Gx_line+131) ;
            getPrinter().GxDrawLine(32, Gx_line+60, 796, Gx_line+60, 1, 192, 192, 192, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 7, false, false, false, false, 0, 70, 130, 180, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Dirección: Eduardo Acevedo 1310 Montevideo, Uruguay  ", ""), 36, Gx_line+83, 383, Gx_line+101, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(context.GetMessage( "Teléfono: +598 92612655   ", ""), 36, Gx_line+101, 383, Gx_line+119, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(context.GetMessage( "Email: info@almango.com.uy   ", ""), 36, Gx_line+119, 383, Gx_line+137, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(context.GetMessage( "Website: www.almango.com.uy", ""), 36, Gx_line+137, 383, Gx_line+155, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Comisiones Com.", ""), 584, Gx_line+20, 678, Gx_line+33, 2, 0, 0, 0) ;
            getPrinter().GxDrawText(context.GetMessage( "ComisionesALM", ""), 440, Gx_line+20, 547, Gx_line+33, 2, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV35TotalAlmango, "ZZZZZZ,ZZZ,ZZZ,ZZ9.99")), 415, Gx_line+35, 547, Gx_line+50, 2+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV34TotalComisionProveedor, "ZZZZZZ,ZZZ,ZZZ,ZZ9.99")), 546, Gx_line+35, 678, Gx_line+50, 2+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV21TotalHab, "ZZZ,ZZZ,ZZZ,ZZZ,ZZ9.99")), 23, Gx_line+35, 162, Gx_line+50, 2+256, 0, 0, 0) ;
            getPrinter().GxDrawText(context.GetMessage( "Total Delegadas/Habilitadas", ""), 12, Gx_line+20, 163, Gx_line+32, 2, 0, 0, 0) ;
            getPrinter().GxDrawText(context.GetMessage( "Total Aceptada", ""), 166, Gx_line+20, 273, Gx_line+33, 2, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV19TotalAcep, "ZZZ,ZZZ,ZZZ,ZZZ,ZZ9.99")), 172, Gx_line+35, 273, Gx_line+50, 2, 0, 0, 0) ;
            getPrinter().GxDrawText(context.GetMessage( "Total Finalizadas", ""), 297, Gx_line+20, 404, Gx_line+33, 2, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV20TotalFin, "ZZZ,ZZZ,ZZZ,ZZZ,ZZ9.99")), 265, Gx_line+35, 404, Gx_line+50, 2+256, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+156);
            /* Print footer for last page */
            ToSkip = (int)(P_lines+1);
            H8B0( true, 0) ;
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

      protected void H8B0( bool bFoot ,
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
                  getPrinter().GxAttris("Microsoft Sans Serif", 12, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(context.GetMessage( "Reporte Financiero de Actividades Profesionales", ""), 135, Gx_line+29, 711, Gx_line+56, 1, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 7, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( Gx_time, "")), 714, Gx_line+33, 790, Gx_line+47, 0+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(context.localUtil.Format( Gx_date, "99/99/99"), 660, Gx_line+33, 699, Gx_line+47, 2+256, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(context.GetMessage( "Fecha del Reporte", ""), 661, Gx_line+13, 810, Gx_line+27, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV23LabelRango, "")), 193, Gx_line+67, 653, Gx_line+82, 1, 0, 0, 1) ;
                  getPrinter().GxDrawBitMap(context.GetImagePath( "e6acfd2e-013a-4b78-9d37-37f6dc906ba7", "", context.GetTheme( )), 11, Gx_line+0, 199, Gx_line+63) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 7, false, false, false, false, 0, 105, 105, 105, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(context.GetMessage( "Control de Solicitudes de Servicios a Domicilio", ""), 11, Gx_line+67, 264, Gx_line+81, 0, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+97);
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV16ProfesionalesId, "")), 151, Gx_line+21, 256, Gx_line+36, 0+256, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(context.GetMessage( "Solicitud No.", ""), 113, Gx_line+48, 220, Gx_line+61, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(context.GetMessage( "Profesional:", ""), 31, Gx_line+22, 138, Gx_line+35, 0, 0, 0, 0) ;
                  getPrinter().GxDrawLine(33, Gx_line+67, 773, Gx_line+67, 1, 0, 0, 0, 0) ;
                  getPrinter().GxDrawLine(32, Gx_line+40, 796, Gx_line+40, 1, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(context.GetMessage( "Estado", ""), 748, Gx_line+48, 804, Gx_line+60, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(context.GetMessage( "Importe", ""), 621, Gx_line+48, 728, Gx_line+61, 2, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV10Profesional, "")), 277, Gx_line+21, 695, Gx_line+36, 0+256, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(context.GetMessage( "Pagado", ""), 411, Gx_line+48, 464, Gx_line+61, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(context.GetMessage( "Almango", ""), 484, Gx_line+48, 546, Gx_line+61, 2, 0, 0, 0) ;
                  getPrinter().GxDrawText(context.GetMessage( "Comercio", ""), 584, Gx_line+48, 646, Gx_line+61, 2, 0, 0, 0) ;
                  getPrinter().GxDrawText(context.GetMessage( "Trabajo", ""), 31, Gx_line+48, 93, Gx_line+61, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(context.GetMessage( "COMISIONES", ""), 518, Gx_line+22, 614, Gx_line+34, 1, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+68);
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
      }

      protected void add_metrics0( )
      {
         getPrinter().setMetrics("Microsoft Sans Serif", true, false, 57, 15, 72, 163,  new int[] {47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 17, 19, 29, 34, 34, 55, 45, 15, 21, 21, 24, 36, 17, 21, 17, 17, 34, 34, 34, 34, 34, 34, 34, 34, 34, 34, 21, 21, 36, 36, 36, 38, 60, 43, 45, 45, 45, 41, 38, 48, 45, 17, 34, 45, 38, 53, 45, 48, 41, 48, 45, 41, 38, 45, 41, 57, 41, 41, 38, 21, 17, 21, 36, 34, 21, 34, 38, 34, 38, 34, 21, 38, 38, 17, 17, 34, 17, 55, 38, 38, 38, 38, 24, 34, 21, 38, 33, 49, 34, 34, 31, 24, 17, 24, 36, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 17, 21, 34, 34, 34, 34, 17, 34, 21, 46, 23, 34, 36, 21, 46, 34, 25, 34, 21, 21, 21, 36, 34, 21, 20, 21, 23, 34, 52, 52, 52, 38, 45, 45, 45, 45, 45, 45, 62, 45, 41, 41, 41, 41, 17, 17, 17, 17, 45, 45, 48, 48, 48, 48, 48, 36, 48, 45, 45, 45, 45, 41, 41, 38, 34, 34, 34, 34, 34, 34, 55, 34, 34, 34, 34, 34, 17, 17, 17, 17, 38, 38, 38, 38, 38, 38, 38, 34, 38, 38, 38, 38, 38, 34, 38, 34}) ;
      }

      protected void add_metrics1( )
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
         /* Using cursor P008B3 */
         pr_default.execute(1, new Object[] {A127SolicitudesID});
         while ( (pr_default.getStatus(1) != 101) && ( P008B3_A127SolicitudesID[0] == A127SolicitudesID ) )
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( P008B3_A178SolicitudItemsSR[0])) || ( StringUtil.StrCmp(P008B3_A179SolicitudItemsComisionTipo[0], "N") == 0 ) )
            {
               A175SolicitudesItemsPrecioInstalac = (decimal)((P008B3_A176SolicitudesItemsPrecioFinal[0]*P008B3_A177SolicitudesItemsCantidad[0]));
            }
            else
            {
               if ( ( StringUtil.StrCmp(P008B3_A179SolicitudItemsComisionTipo[0], "F") == 0 ) && ( StringUtil.StrCmp(P008B3_A178SolicitudItemsSR[0], "R") == 0 ) )
               {
                  A175SolicitudesItemsPrecioInstalac = (decimal)((P008B3_A176SolicitudesItemsPrecioFinal[0]*P008B3_A177SolicitudesItemsCantidad[0])-(P008B3_A180SolicitudItemsComision[0]*P008B3_A177SolicitudesItemsCantidad[0]));
               }
               else
               {
                  if ( ( StringUtil.StrCmp(P008B3_A179SolicitudItemsComisionTipo[0], "F") == 0 ) && ( StringUtil.StrCmp(P008B3_A178SolicitudItemsSR[0], "S") == 0 ) )
                  {
                     A175SolicitudesItemsPrecioInstalac = (decimal)((P008B3_A176SolicitudesItemsPrecioFinal[0]*P008B3_A177SolicitudesItemsCantidad[0])+(P008B3_A180SolicitudItemsComision[0]*P008B3_A177SolicitudesItemsCantidad[0]));
                  }
                  else
                  {
                     if ( ( StringUtil.StrCmp(P008B3_A179SolicitudItemsComisionTipo[0], "P") == 0 ) && ( StringUtil.StrCmp(P008B3_A178SolicitudItemsSR[0], "R") == 0 ) )
                     {
                        A175SolicitudesItemsPrecioInstalac = (decimal)((P008B3_A176SolicitudesItemsPrecioFinal[0]*P008B3_A177SolicitudesItemsCantidad[0])-((P008B3_A176SolicitudesItemsPrecioFinal[0]*P008B3_A177SolicitudesItemsCantidad[0])*(P008B3_A180SolicitudItemsComision[0]/ (decimal)(100))));
                     }
                     else
                     {
                        if ( ( StringUtil.StrCmp(P008B3_A179SolicitudItemsComisionTipo[0], "P") == 0 ) && ( StringUtil.StrCmp(P008B3_A178SolicitudItemsSR[0], "S") == 0 ) )
                        {
                           A175SolicitudesItemsPrecioInstalac = (decimal)((P008B3_A176SolicitudesItemsPrecioFinal[0]*P008B3_A177SolicitudesItemsCantidad[0])+((P008B3_A176SolicitudesItemsPrecioFinal[0]*P008B3_A177SolicitudesItemsCantidad[0])*(P008B3_A180SolicitudItemsComision[0]/ (decimal)(100))));
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
         P008B2_A130EstadosSolTipo = new string[] {""} ;
         P008B2_A438SolicitudServicioOrigenPago = new string[] {""} ;
         P008B2_n438SolicitudServicioOrigenPago = new bool[] {false} ;
         P008B2_A184SolicitudesFechaInstalacion = new DateTime[] {DateTime.MinValue} ;
         P008B2_A131EstadosSolId = new int[1] ;
         P008B2_A127SolicitudesID = new long[1] ;
         P008B2_A171SolicitudesNombre = new string[] {""} ;
         P008B2_A527SolicitudServicioComProv = new decimal[1] ;
         P008B2_n527SolicitudServicioComProv = new bool[] {false} ;
         P008B2_A865SolicitudesCostoXZComAlm = new decimal[1] ;
         P008B2_n865SolicitudesCostoXZComAlm = new bool[] {false} ;
         P008B2_A530SolicitudServicioComALM = new decimal[1] ;
         P008B2_n530SolicitudServicioComALM = new bool[] {false} ;
         P008B2_A132EstadosSolNombre = new string[] {""} ;
         P008B2_A796SolicitudesComisionMetodoPago = new decimal[1] ;
         P008B2_A212SolicitudesCotizacion = new decimal[1] ;
         P008B2_A1016SolicitudesDescuentoCupon = new decimal[1] ;
         P008B2_A897SolicitudesDescuento = new decimal[1] ;
         P008B2_n897SolicitudesDescuento = new bool[] {false} ;
         P008B2_A864SolicitudesCostoXZona = new decimal[1] ;
         A130EstadosSolTipo = "";
         A438SolicitudServicioOrigenPago = "";
         A184SolicitudesFechaInstalacion = DateTime.MinValue;
         A171SolicitudesNombre = "";
         A132EstadosSolNombre = "";
         AV12NombreCliente = "";
         AV13Estado = "";
         AV29Fecha = DateTime.MinValue;
         AV15Exists = "";
         GXt_char1 = "";
         AV28OrigenPago = "";
         P008B3_A127SolicitudesID = new long[1] ;
         P008B3_A134SolicitudesItemsID = new short[1] ;
         P008B3_A180SolicitudItemsComision = new decimal[1] ;
         P008B3_A179SolicitudItemsComisionTipo = new string[] {""} ;
         P008B3_A178SolicitudItemsSR = new string[] {""} ;
         P008B3_A177SolicitudesItemsCantidad = new short[1] ;
         P008B3_A176SolicitudesItemsPrecioFinal = new decimal[1] ;
         P008B3_n176SolicitudesItemsPrecioFinal = new bool[] {false} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.areportecomgenerales__default(),
            new Object[][] {
                new Object[] {
               P008B2_A130EstadosSolTipo, P008B2_A438SolicitudServicioOrigenPago, P008B2_n438SolicitudServicioOrigenPago, P008B2_A184SolicitudesFechaInstalacion, P008B2_A131EstadosSolId, P008B2_A127SolicitudesID, P008B2_A171SolicitudesNombre, P008B2_A527SolicitudServicioComProv, P008B2_n527SolicitudServicioComProv, P008B2_A865SolicitudesCostoXZComAlm,
               P008B2_n865SolicitudesCostoXZComAlm, P008B2_A530SolicitudServicioComALM, P008B2_n530SolicitudServicioComALM, P008B2_A132EstadosSolNombre, P008B2_A796SolicitudesComisionMetodoPago, P008B2_A212SolicitudesCotizacion, P008B2_A1016SolicitudesDescuentoCupon, P008B2_A897SolicitudesDescuento, P008B2_n897SolicitudesDescuento, P008B2_A864SolicitudesCostoXZona
               }
               , new Object[] {
               P008B3_A127SolicitudesID, P008B3_A134SolicitudesItemsID, P008B3_A180SolicitudItemsComision, P008B3_A179SolicitudItemsComisionTipo, P008B3_A178SolicitudItemsSR, P008B3_A177SolicitudesItemsCantidad, P008B3_A176SolicitudesItemsPrecioFinal, P008B3_n176SolicitudesItemsPrecioFinal
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
      private int AV37Clasificaciones ;
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
      private decimal A527SolicitudServicioComProv ;
      private decimal A865SolicitudesCostoXZComAlm ;
      private decimal A530SolicitudServicioComALM ;
      private decimal A796SolicitudesComisionMetodoPago ;
      private decimal A212SolicitudesCotizacion ;
      private decimal A1016SolicitudesDescuentoCupon ;
      private decimal A897SolicitudesDescuento ;
      private decimal A864SolicitudesCostoXZona ;
      private decimal A211SolicitudServicioPFinal ;
      private decimal A174SolicitudesTotal ;
      private decimal AV32ComisionProv ;
      private decimal AV31ComisionALM ;
      private decimal AV14Importe ;
      private decimal AV21TotalHab ;
      private decimal AV19TotalAcep ;
      private decimal AV20TotalFin ;
      private decimal AV36TotalOrden ;
      private decimal AV34TotalComisionProveedor ;
      private decimal AV35TotalAlmango ;
      private decimal AV33TotalComisiones ;
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
      private DateTime AV29Fecha ;
      private bool entryPointCalled ;
      private bool GxHdr2 ;
      private bool n438SolicitudServicioOrigenPago ;
      private bool n527SolicitudServicioComProv ;
      private bool n865SolicitudesCostoXZComAlm ;
      private bool n530SolicitudServicioComALM ;
      private bool n897SolicitudesDescuento ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private string aP0_ProfesionalesId ;
      private long aP1_SolicitudesID ;
      private DateTime aP2_Desde ;
      private DateTime aP3_Hasta ;
      private int aP4_Clasificaciones ;
      private string aP5_SolicitudServicioOrigenPago ;
      private IDataStoreProvider pr_default ;
      private string[] P008B2_A130EstadosSolTipo ;
      private string[] P008B2_A438SolicitudServicioOrigenPago ;
      private bool[] P008B2_n438SolicitudServicioOrigenPago ;
      private DateTime[] P008B2_A184SolicitudesFechaInstalacion ;
      private int[] P008B2_A131EstadosSolId ;
      private long[] P008B2_A127SolicitudesID ;
      private string[] P008B2_A171SolicitudesNombre ;
      private decimal[] P008B2_A527SolicitudServicioComProv ;
      private bool[] P008B2_n527SolicitudServicioComProv ;
      private decimal[] P008B2_A865SolicitudesCostoXZComAlm ;
      private bool[] P008B2_n865SolicitudesCostoXZComAlm ;
      private decimal[] P008B2_A530SolicitudServicioComALM ;
      private bool[] P008B2_n530SolicitudServicioComALM ;
      private string[] P008B2_A132EstadosSolNombre ;
      private decimal[] P008B2_A796SolicitudesComisionMetodoPago ;
      private decimal[] P008B2_A212SolicitudesCotizacion ;
      private decimal[] P008B2_A1016SolicitudesDescuentoCupon ;
      private decimal[] P008B2_A897SolicitudesDescuento ;
      private bool[] P008B2_n897SolicitudesDescuento ;
      private decimal[] P008B2_A864SolicitudesCostoXZona ;
      private long[] P008B3_A127SolicitudesID ;
      private short[] P008B3_A134SolicitudesItemsID ;
      private decimal[] P008B3_A180SolicitudItemsComision ;
      private string[] P008B3_A179SolicitudItemsComisionTipo ;
      private string[] P008B3_A178SolicitudItemsSR ;
      private short[] P008B3_A177SolicitudesItemsCantidad ;
      private decimal[] P008B3_A176SolicitudesItemsPrecioFinal ;
      private bool[] P008B3_n176SolicitudesItemsPrecioFinal ;
   }

   public class areportecomgenerales__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP008B2;
          prmP008B2 = new Object[] {
          new ParDef("@AV9Hasta",GXType.Date,8,0) ,
          new ParDef("@AV11SolicitudesID",GXType.Decimal,18,0) ,
          new ParDef("@AV37Clasificaciones",GXType.Int32,5,0) ,
          new ParDef("@AV27SolicitudServicioOrigenPago",GXType.NChar,1,0) ,
          new ParDef("@AV8Desde",GXType.Date,8,0)
          };
          Object[] prmP008B3;
          prmP008B3 = new Object[] {
          new ParDef("@SolicitudesID",GXType.Decimal,18,0)
          };
          def= new CursorDef[] {
              new CursorDef("P008B2", "SELECT T1.[EstadosSolTipo] AS EstadosSolTipo, T1.[SolicitudServicioOrigenPago], T1.[SolicitudesFechaInstalacion], T1.[EstadosSolId] AS EstadosSolId, T1.[SolicitudesID], T1.[SolicitudesNombre], T1.[SolicitudServicioComProv], T1.[SolicitudesCostoXZComAlm], T1.[SolicitudServicioComALM], T2.[EstadosGenericosNombre] AS EstadosSolNombre, T1.[SolicitudesComisionMetodoPago], T1.[SolicitudesCotizacion], T1.[SolicitudesDescuentoCupon], T1.[SolicitudesDescuento], T1.[SolicitudesCostoXZona] FROM ([Solicitudes] T1 INNER JOIN [EstadosGenericos] T2 ON T2.[EstadosTipo] = T1.[EstadosSolTipo] AND T2.[EstadosGenericosId] = T1.[EstadosSolId]) WHERE (T1.[SolicitudesFechaInstalacion] <= @AV9Hasta) AND (T1.[SolicitudesID] = @AV11SolicitudesID or @AV11SolicitudesID = 0) AND (T1.[EstadosSolId] = @AV37Clasificaciones or @AV37Clasificaciones = 0) AND (T1.[SolicitudServicioOrigenPago] = @AV27SolicitudServicioOrigenPago or @AV27SolicitudServicioOrigenPago = '') AND (T1.[SolicitudesFechaInstalacion] >= @AV8Desde) ORDER BY T1.[SolicitudesFechaInstalacion] DESC ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP008B2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P008B3", "SELECT [SolicitudesID], [SolicitudesItemsID], [SolicitudItemsComision], [SolicitudItemsComisionTipo], [SolicitudItemsSR], [SolicitudesItemsCantidad], [SolicitudesItemsPrecioFinal] FROM [SolicitudesItems] WHERE [SolicitudesID] = @SolicitudesID ORDER BY [SolicitudesID] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP008B3,100, GxCacheFrequency.OFF ,true,false )
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
                ((decimal[]) buf[7])[0] = rslt.getDecimal(7);
                ((bool[]) buf[8])[0] = rslt.wasNull(7);
                ((decimal[]) buf[9])[0] = rslt.getDecimal(8);
                ((bool[]) buf[10])[0] = rslt.wasNull(8);
                ((decimal[]) buf[11])[0] = rslt.getDecimal(9);
                ((bool[]) buf[12])[0] = rslt.wasNull(9);
                ((string[]) buf[13])[0] = rslt.getString(10, 80);
                ((decimal[]) buf[14])[0] = rslt.getDecimal(11);
                ((decimal[]) buf[15])[0] = rslt.getDecimal(12);
                ((decimal[]) buf[16])[0] = rslt.getDecimal(13);
                ((decimal[]) buf[17])[0] = rslt.getDecimal(14);
                ((bool[]) buf[18])[0] = rslt.wasNull(14);
                ((decimal[]) buf[19])[0] = rslt.getDecimal(15);
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

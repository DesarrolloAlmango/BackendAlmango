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
   public class areporteeconomicodetallado : GXWebProcedure, System.Web.SessionState.IRequiresSessionState
   {
      public override void webExecute( )
      {
         context.SetDefaultTheme("WorkWithPlusDS", true);
         initialize();
         GXKey = Crypto.GetSiteKey( );
         if ( ( StringUtil.StrCmp(context.GetRequestQueryString( ), "") != 0 ) && ( GxWebError == 0 ) )
         {
            GXDecQS = UriDecrypt64( context.GetRequestQueryString( ), GXKey);
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "areporteeconomicodetallado.aspx")), "areporteeconomicodetallado.aspx") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "areporteeconomicodetallado.aspx")))) ;
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
               }
            }
         }
         if ( GxWebError == 0 )
         {
            ExecutePrivate();
         }
         cleanup();
      }

      public areporteeconomicodetallado( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public areporteeconomicodetallado( IGxContext context )
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
         this.AV29Clasificaciones = aP4_Clasificaciones;
         this.AV27SolicitudServicioOrigenPago = aP5_SolicitudServicioOrigenPago;
         initialize();
         ExecutePrivate();
         aP0_ProfesionalesId=this.A120ProfesionalesId;
         aP1_SolicitudesID=this.AV11SolicitudesID;
         aP2_Desde=this.AV8Desde;
         aP3_Hasta=this.AV9Hasta;
         aP4_Clasificaciones=this.AV29Clasificaciones;
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
         this.AV29Clasificaciones = aP4_Clasificaciones;
         this.AV27SolicitudServicioOrigenPago = aP5_SolicitudServicioOrigenPago;
         SubmitImpl();
         aP0_ProfesionalesId=this.A120ProfesionalesId;
         aP1_SolicitudesID=this.AV11SolicitudesID;
         aP2_Desde=this.AV8Desde;
         aP3_Hasta=this.AV9Hasta;
         aP4_Clasificaciones=this.AV29Clasificaciones;
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
         setOutputFileName("ReporteEconomicoDetallado");
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
            HDN0( false, 127) ;
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
            HDN0( false, 68) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV16ProfesionalesId, "")), 147, Gx_line+13, 252, Gx_line+28, 0+256, 0, 0, 0) ;
            getPrinter().GxDrawText(context.GetMessage( "Solicitud No.", ""), 15, Gx_line+48, 122, Gx_line+61, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(context.GetMessage( "Profesional:", ""), 20, Gx_line+13, 127, Gx_line+26, 0, 0, 0, 0) ;
            getPrinter().GxDrawLine(12, Gx_line+66, 792, Gx_line+66, 1, 0, 0, 0, 0) ;
            getPrinter().GxDrawLine(13, Gx_line+40, 793, Gx_line+40, 1, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(context.GetMessage( "Estado", ""), 347, Gx_line+46, 407, Gx_line+59, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(context.GetMessage( "Cobrado", ""), 483, Gx_line+46, 550, Gx_line+59, 2, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV10Profesional, "")), 273, Gx_line+13, 691, Gx_line+28, 0+256, 0, 0, 0) ;
            getPrinter().GxDrawText(context.GetMessage( "Pagado", ""), 411, Gx_line+46, 464, Gx_line+59, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(context.GetMessage( "Almango", ""), 570, Gx_line+46, 637, Gx_line+59, 2, 0, 0, 0) ;
            getPrinter().GxDrawText(context.GetMessage( "Profesional", ""), 653, Gx_line+46, 726, Gx_line+59, 2, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+68);
            GxHdr2 = true;
            /* Using cursor P00DN2 */
            pr_default.execute(0, new Object[] {AV11SolicitudesID, AV29Clasificaciones, AV8Desde, AV9Hasta, AV27SolicitudServicioOrigenPago});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A130EstadosSolTipo = P00DN2_A130EstadosSolTipo[0];
               A438SolicitudServicioOrigenPago = P00DN2_A438SolicitudServicioOrigenPago[0];
               n438SolicitudServicioOrigenPago = P00DN2_n438SolicitudServicioOrigenPago[0];
               A184SolicitudesFechaInstalacion = P00DN2_A184SolicitudesFechaInstalacion[0];
               A131EstadosSolId = P00DN2_A131EstadosSolId[0];
               A127SolicitudesID = P00DN2_A127SolicitudesID[0];
               A171SolicitudesNombre = P00DN2_A171SolicitudesNombre[0];
               A132EstadosSolNombre = P00DN2_A132EstadosSolNombre[0];
               A527SolicitudServicioComProv = P00DN2_A527SolicitudServicioComProv[0];
               n527SolicitudServicioComProv = P00DN2_n527SolicitudServicioComProv[0];
               A530SolicitudServicioComALM = P00DN2_A530SolicitudServicioComALM[0];
               n530SolicitudServicioComALM = P00DN2_n530SolicitudServicioComALM[0];
               A865SolicitudesCostoXZComAlm = P00DN2_A865SolicitudesCostoXZComAlm[0];
               n865SolicitudesCostoXZComAlm = P00DN2_n865SolicitudesCostoXZComAlm[0];
               A796SolicitudesComisionMetodoPago = P00DN2_A796SolicitudesComisionMetodoPago[0];
               A212SolicitudesCotizacion = P00DN2_A212SolicitudesCotizacion[0];
               A1016SolicitudesDescuentoCupon = P00DN2_A1016SolicitudesDescuentoCupon[0];
               A897SolicitudesDescuento = P00DN2_A897SolicitudesDescuento[0];
               n897SolicitudesDescuento = P00DN2_n897SolicitudesDescuento[0];
               A864SolicitudesCostoXZona = P00DN2_A864SolicitudesCostoXZona[0];
               A132EstadosSolNombre = P00DN2_A132EstadosSolNombre[0];
               if ( ( A865SolicitudesCostoXZComAlm < Convert.ToDecimal( 0 )) )
               {
                  A867SolicitudesCostoXZComProf = (decimal)(A864SolicitudesCostoXZona+(A865SolicitudesCostoXZComAlm*-1));
               }
               else
               {
                  A867SolicitudesCostoXZComProf = (decimal)(A864SolicitudesCostoXZona-(A865SolicitudesCostoXZComAlm));
               }
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
               if ( ( A530SolicitudServicioComALM < Convert.ToDecimal( 0 )) && ( A527SolicitudServicioComProv >= Convert.ToDecimal( 0 )) )
               {
                  A529SolicitudServicioComPro = (decimal)(A211SolicitudServicioPFinal-A864SolicitudesCostoXZona+(A530SolicitudServicioComALM*-1)-A527SolicitudServicioComProv);
               }
               else
               {
                  if ( ( A530SolicitudServicioComALM < Convert.ToDecimal( 0 )) && ( A527SolicitudServicioComProv < Convert.ToDecimal( 0 )) )
                  {
                     A529SolicitudServicioComPro = (decimal)(A211SolicitudServicioPFinal-A864SolicitudesCostoXZona+((A530SolicitudServicioComALM+A527SolicitudServicioComProv)*-1));
                  }
                  else
                  {
                     if ( ( A530SolicitudServicioComALM >= Convert.ToDecimal( 0 )) )
                     {
                        A529SolicitudServicioComPro = (decimal)(A211SolicitudServicioPFinal-A864SolicitudesCostoXZona-(A527SolicitudServicioComProv+A530SolicitudServicioComALM));
                     }
                     else
                     {
                        A529SolicitudServicioComPro = (decimal)(A211SolicitudServicioPFinal-A864SolicitudesCostoXZona-(A527SolicitudServicioComProv+A530SolicitudServicioComALM));
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
                     if ( StringUtil.StrCmp(AV28OrigenPago, "F") == 0 )
                     {
                        AV35CobradoTexto = StringUtil.Trim( StringUtil.Str( A211SolicitudServicioPFinal, 18, 2));
                        AV33Almango = (decimal)(A530SolicitudServicioComALM+A865SolicitudesCostoXZComAlm+A527SolicitudServicioComProv);
                        AV36AlmangoTexto = StringUtil.Trim( StringUtil.Str( AV33Almango, 18, 2));
                     }
                     else
                     {
                        AV35CobradoTexto = "-";
                        AV36AlmangoTexto = "-";
                     }
                     AV34Prof = (decimal)(System.Math.Abs( A529SolicitudServicioComPro+A867SolicitudesCostoXZComProf));
                     HDN0( false, 22) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV11SolicitudesID), "ZZZZZZZZZZZZZZZZZ9")), 0, Gx_line+3, 80, Gx_line+18, 2, 0, 0, 0) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV12NombreCliente, "")), 96, Gx_line+2, 314, Gx_line+17, 0, 0, 0, 0) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV13Estado, "")), 332, Gx_line+1, 411, Gx_line+16, 0+256, 0, 0, 0) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV35CobradoTexto, "")), 472, Gx_line+0, 548, Gx_line+15, 2, 0, 0, 1) ;
                     getPrinter().GxDrawLine(15, Gx_line+20, 755, Gx_line+20, 1, 220, 220, 220, 0) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV28OrigenPago, "")), 431, Gx_line+0, 443, Gx_line+15, 0+256, 0, 0, 0) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV36AlmangoTexto, "")), 559, Gx_line+0, 635, Gx_line+15, 2, 0, 0, 1) ;
                     getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV34Prof, "ZZZZZZZZZZZZZZ9.99")), 647, Gx_line+0, 723, Gx_line+15, 2, 0, 0, 0) ;
                     Gx_OldLine = Gx_line;
                     Gx_line = (int)(Gx_line+22);
                     if ( StringUtil.StrCmp(AV28OrigenPago, "F") == 0 )
                     {
                        AV37TotalCobrado = (decimal)(AV37TotalCobrado+A211SolicitudServicioPFinal);
                        AV38TotalAlmango = (decimal)(AV38TotalAlmango+(A530SolicitudServicioComALM+A865SolicitudesCostoXZComAlm+A527SolicitudServicioComProv));
                     }
                     else
                     {
                        AV40TotalProfNoCDirecto = (decimal)(AV40TotalProfNoCDirecto+(decimal)((System.Math.Abs( A529SolicitudServicioComPro+A867SolicitudesCostoXZComProf))));
                     }
                     AV39TotalProfesional = (decimal)(AV39TotalProfesional+(decimal)((System.Math.Abs( A529SolicitudServicioComPro))));
                  }
               }
               pr_default.readNext(0);
            }
            pr_default.close(0);
            GxHdr2 = false;
            AV41Resultado = (decimal)(AV38TotalAlmango-AV40TotalProfNoCDirecto);
            HDN0( false, 80) ;
            getPrinter().GxDrawLine(33, Gx_line+24, 811, Gx_line+24, 1, 0, 0, 0, 0) ;
            getPrinter().GxDrawLine(34, Gx_line+63, 812, Gx_line+63, 1, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV37TotalCobrado, "ZZZ,ZZZ,ZZZ,ZZZ,ZZ9.99")), 459, Gx_line+31, 548, Gx_line+46, 2, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV38TotalAlmango, "ZZZ,ZZZ,ZZZ,ZZZ,ZZ9.99")), 559, Gx_line+31, 635, Gx_line+46, 2, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV39TotalProfesional, "ZZZ,ZZZ,ZZZ,ZZZ,ZZ9.99")), 649, Gx_line+31, 722, Gx_line+46, 2, 0, 0, 0) ;
            getPrinter().GxAttris("Mongolian Baiti", 9, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Total", ""), 501, Gx_line+7, 540, Gx_line+20, 2, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 9, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV41Resultado, "ZZZ,ZZZ,ZZZ,ZZZ,ZZ9.99")), 730, Gx_line+30, 803, Gx_line+47, 2, 0, 0, 0) ;
            getPrinter().GxAttris("Mongolian Baiti", 9, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Total", ""), 586, Gx_line+7, 625, Gx_line+20, 2, 0, 0, 0) ;
            getPrinter().GxDrawText(context.GetMessage( "Total", ""), 674, Gx_line+7, 713, Gx_line+20, 2, 0, 0, 0) ;
            getPrinter().GxDrawText(context.GetMessage( "Resultado", ""), 733, Gx_line+7, 803, Gx_line+20, 2, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+80);
            /* Print footer for last page */
            ToSkip = (int)(P_lines+1);
            HDN0( true, 0) ;
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

      protected void HDN0( bool bFoot ,
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
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV16ProfesionalesId, "")), 147, Gx_line+13, 252, Gx_line+28, 0+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(context.GetMessage( "Solicitud No.", ""), 15, Gx_line+48, 122, Gx_line+61, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(context.GetMessage( "Profesional:", ""), 20, Gx_line+13, 127, Gx_line+26, 0, 0, 0, 0) ;
                  getPrinter().GxDrawLine(12, Gx_line+66, 792, Gx_line+66, 1, 0, 0, 0, 0) ;
                  getPrinter().GxDrawLine(13, Gx_line+40, 793, Gx_line+40, 1, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(context.GetMessage( "Estado", ""), 347, Gx_line+46, 407, Gx_line+59, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(context.GetMessage( "Cobrado", ""), 483, Gx_line+46, 550, Gx_line+59, 2, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV10Profesional, "")), 273, Gx_line+13, 691, Gx_line+28, 0+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(context.GetMessage( "Pagado", ""), 411, Gx_line+46, 464, Gx_line+59, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(context.GetMessage( "Almango", ""), 570, Gx_line+46, 637, Gx_line+59, 2, 0, 0, 0) ;
                  getPrinter().GxDrawText(context.GetMessage( "Profesional", ""), 653, Gx_line+46, 726, Gx_line+59, 2, 0, 0, 0) ;
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
         add_metrics2( ) ;
      }

      protected void add_metrics0( )
      {
         getPrinter().setMetrics("Microsoft Sans Serif", false, false, 58, 14, 72, 171,  new int[] {48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 18, 20, 23, 36, 36, 57, 43, 12, 21, 21, 25, 37, 18, 21, 18, 18, 36, 36, 36, 36, 36, 36, 36, 36, 36, 36, 18, 18, 37, 37, 37, 36, 65, 43, 43, 46, 46, 43, 39, 50, 46, 18, 32, 43, 36, 53, 46, 50, 43, 50, 46, 43, 40, 46, 43, 64, 41, 42, 39, 18, 18, 18, 27, 36, 21, 36, 36, 32, 36, 36, 18, 36, 36, 14, 15, 33, 14, 55, 36, 36, 36, 36, 21, 32, 18, 36, 33, 47, 31, 31, 31, 21, 17, 21, 37, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 18, 20, 36, 36, 36, 36, 17, 36, 21, 47, 24, 36, 37, 21, 47, 35, 26, 35, 21, 21, 21, 37, 34, 21, 21, 21, 23, 36, 53, 53, 53, 39, 43, 43, 43, 43, 43, 43, 64, 46, 43, 43, 43, 43, 18, 18, 18, 18, 46, 46, 50, 50, 50, 50, 50, 37, 50, 46, 46, 46, 46, 43, 43, 39, 36, 36, 36, 36, 36, 36, 57, 32, 36, 36, 36, 36, 18, 18, 18, 18, 36, 36, 36, 36, 36, 36, 36, 35, 39, 36, 36, 36, 36, 32, 36, 32}) ;
      }

      protected void add_metrics1( )
      {
         getPrinter().setMetrics("Mongolian Baiti", true, false, 57, 15, 72, 163,  new int[] {47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 17, 19, 29, 34, 34, 55, 45, 15, 21, 21, 24, 36, 17, 21, 17, 17, 34, 34, 34, 34, 34, 34, 34, 34, 34, 34, 21, 21, 36, 36, 36, 38, 60, 43, 45, 45, 45, 41, 38, 48, 45, 17, 34, 45, 38, 53, 45, 48, 41, 48, 45, 41, 38, 45, 41, 57, 41, 41, 38, 21, 17, 21, 36, 34, 21, 34, 38, 34, 38, 34, 21, 38, 38, 17, 17, 34, 17, 55, 38, 38, 38, 38, 24, 34, 21, 38, 33, 49, 34, 34, 31, 24, 17, 24, 36, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 17, 21, 34, 34, 34, 34, 17, 34, 21, 46, 23, 34, 36, 21, 46, 34, 25, 34, 21, 21, 21, 36, 34, 21, 20, 21, 23, 34, 52, 52, 52, 38, 45, 45, 45, 45, 45, 45, 62, 45, 41, 41, 41, 41, 17, 17, 17, 17, 45, 45, 48, 48, 48, 48, 48, 36, 48, 45, 45, 45, 45, 41, 41, 38, 34, 34, 34, 34, 34, 34, 55, 34, 34, 34, 34, 34, 17, 17, 17, 17, 38, 38, 38, 38, 38, 38, 38, 34, 38, 38, 38, 38, 38, 34, 38, 34}) ;
      }

      protected void add_metrics2( )
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
         /* Using cursor P00DN3 */
         pr_default.execute(1, new Object[] {A127SolicitudesID});
         while ( (pr_default.getStatus(1) != 101) && ( P00DN3_A127SolicitudesID[0] == A127SolicitudesID ) )
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( P00DN3_A178SolicitudItemsSR[0])) || ( StringUtil.StrCmp(P00DN3_A179SolicitudItemsComisionTipo[0], "N") == 0 ) )
            {
               A175SolicitudesItemsPrecioInstalac = (decimal)((P00DN3_A176SolicitudesItemsPrecioFinal[0]*P00DN3_A177SolicitudesItemsCantidad[0]));
            }
            else
            {
               if ( ( StringUtil.StrCmp(P00DN3_A179SolicitudItemsComisionTipo[0], "F") == 0 ) && ( StringUtil.StrCmp(P00DN3_A178SolicitudItemsSR[0], "R") == 0 ) )
               {
                  A175SolicitudesItemsPrecioInstalac = (decimal)((P00DN3_A176SolicitudesItemsPrecioFinal[0]*P00DN3_A177SolicitudesItemsCantidad[0])-(P00DN3_A180SolicitudItemsComision[0]*P00DN3_A177SolicitudesItemsCantidad[0]));
               }
               else
               {
                  if ( ( StringUtil.StrCmp(P00DN3_A179SolicitudItemsComisionTipo[0], "F") == 0 ) && ( StringUtil.StrCmp(P00DN3_A178SolicitudItemsSR[0], "S") == 0 ) )
                  {
                     A175SolicitudesItemsPrecioInstalac = (decimal)((P00DN3_A176SolicitudesItemsPrecioFinal[0]*P00DN3_A177SolicitudesItemsCantidad[0])+(P00DN3_A180SolicitudItemsComision[0]*P00DN3_A177SolicitudesItemsCantidad[0]));
                  }
                  else
                  {
                     if ( ( StringUtil.StrCmp(P00DN3_A179SolicitudItemsComisionTipo[0], "P") == 0 ) && ( StringUtil.StrCmp(P00DN3_A178SolicitudItemsSR[0], "R") == 0 ) )
                     {
                        A175SolicitudesItemsPrecioInstalac = (decimal)((P00DN3_A176SolicitudesItemsPrecioFinal[0]*P00DN3_A177SolicitudesItemsCantidad[0])-((P00DN3_A176SolicitudesItemsPrecioFinal[0]*P00DN3_A177SolicitudesItemsCantidad[0])*(P00DN3_A180SolicitudItemsComision[0]/ (decimal)(100))));
                     }
                     else
                     {
                        if ( ( StringUtil.StrCmp(P00DN3_A179SolicitudItemsComisionTipo[0], "P") == 0 ) && ( StringUtil.StrCmp(P00DN3_A178SolicitudItemsSR[0], "S") == 0 ) )
                        {
                           A175SolicitudesItemsPrecioInstalac = (decimal)((P00DN3_A176SolicitudesItemsPrecioFinal[0]*P00DN3_A177SolicitudesItemsCantidad[0])+((P00DN3_A176SolicitudesItemsPrecioFinal[0]*P00DN3_A177SolicitudesItemsCantidad[0])*(P00DN3_A180SolicitudItemsComision[0]/ (decimal)(100))));
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
         P00DN2_A130EstadosSolTipo = new string[] {""} ;
         P00DN2_A438SolicitudServicioOrigenPago = new string[] {""} ;
         P00DN2_n438SolicitudServicioOrigenPago = new bool[] {false} ;
         P00DN2_A184SolicitudesFechaInstalacion = new DateTime[] {DateTime.MinValue} ;
         P00DN2_A131EstadosSolId = new int[1] ;
         P00DN2_A127SolicitudesID = new long[1] ;
         P00DN2_A171SolicitudesNombre = new string[] {""} ;
         P00DN2_A132EstadosSolNombre = new string[] {""} ;
         P00DN2_A527SolicitudServicioComProv = new decimal[1] ;
         P00DN2_n527SolicitudServicioComProv = new bool[] {false} ;
         P00DN2_A530SolicitudServicioComALM = new decimal[1] ;
         P00DN2_n530SolicitudServicioComALM = new bool[] {false} ;
         P00DN2_A865SolicitudesCostoXZComAlm = new decimal[1] ;
         P00DN2_n865SolicitudesCostoXZComAlm = new bool[] {false} ;
         P00DN2_A796SolicitudesComisionMetodoPago = new decimal[1] ;
         P00DN2_A212SolicitudesCotizacion = new decimal[1] ;
         P00DN2_A1016SolicitudesDescuentoCupon = new decimal[1] ;
         P00DN2_A897SolicitudesDescuento = new decimal[1] ;
         P00DN2_n897SolicitudesDescuento = new bool[] {false} ;
         P00DN2_A864SolicitudesCostoXZona = new decimal[1] ;
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
         AV35CobradoTexto = "";
         AV36AlmangoTexto = "";
         P00DN3_A127SolicitudesID = new long[1] ;
         P00DN3_A134SolicitudesItemsID = new short[1] ;
         P00DN3_A180SolicitudItemsComision = new decimal[1] ;
         P00DN3_A179SolicitudItemsComisionTipo = new string[] {""} ;
         P00DN3_A178SolicitudItemsSR = new string[] {""} ;
         P00DN3_A177SolicitudesItemsCantidad = new short[1] ;
         P00DN3_A176SolicitudesItemsPrecioFinal = new decimal[1] ;
         P00DN3_n176SolicitudesItemsPrecioFinal = new bool[] {false} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.areporteeconomicodetallado__default(),
            new Object[][] {
                new Object[] {
               P00DN2_A130EstadosSolTipo, P00DN2_A438SolicitudServicioOrigenPago, P00DN2_n438SolicitudServicioOrigenPago, P00DN2_A184SolicitudesFechaInstalacion, P00DN2_A131EstadosSolId, P00DN2_A127SolicitudesID, P00DN2_A171SolicitudesNombre, P00DN2_A132EstadosSolNombre, P00DN2_A527SolicitudServicioComProv, P00DN2_n527SolicitudServicioComProv,
               P00DN2_A530SolicitudServicioComALM, P00DN2_n530SolicitudServicioComALM, P00DN2_A865SolicitudesCostoXZComAlm, P00DN2_n865SolicitudesCostoXZComAlm, P00DN2_A796SolicitudesComisionMetodoPago, P00DN2_A212SolicitudesCotizacion, P00DN2_A1016SolicitudesDescuentoCupon, P00DN2_A897SolicitudesDescuento, P00DN2_n897SolicitudesDescuento, P00DN2_A864SolicitudesCostoXZona
               }
               , new Object[] {
               P00DN3_A127SolicitudesID, P00DN3_A134SolicitudesItemsID, P00DN3_A180SolicitudItemsComision, P00DN3_A179SolicitudItemsComisionTipo, P00DN3_A178SolicitudItemsSR, P00DN3_A177SolicitudesItemsCantidad, P00DN3_A176SolicitudesItemsPrecioFinal, P00DN3_n176SolicitudesItemsPrecioFinal
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
      private decimal A527SolicitudServicioComProv ;
      private decimal A530SolicitudServicioComALM ;
      private decimal A865SolicitudesCostoXZComAlm ;
      private decimal A796SolicitudesComisionMetodoPago ;
      private decimal A212SolicitudesCotizacion ;
      private decimal A1016SolicitudesDescuentoCupon ;
      private decimal A897SolicitudesDescuento ;
      private decimal A864SolicitudesCostoXZona ;
      private decimal A867SolicitudesCostoXZComProf ;
      private decimal A211SolicitudServicioPFinal ;
      private decimal A174SolicitudesTotal ;
      private decimal A529SolicitudServicioComPro ;
      private decimal AV33Almango ;
      private decimal AV34Prof ;
      private decimal AV37TotalCobrado ;
      private decimal AV38TotalAlmango ;
      private decimal AV40TotalProfNoCDirecto ;
      private decimal AV39TotalProfesional ;
      private decimal AV41Resultado ;
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
      private bool GxHdr2 ;
      private bool n438SolicitudServicioOrigenPago ;
      private bool n527SolicitudServicioComProv ;
      private bool n530SolicitudServicioComALM ;
      private bool n865SolicitudesCostoXZComAlm ;
      private bool n897SolicitudesDescuento ;
      private string AV35CobradoTexto ;
      private string AV36AlmangoTexto ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private string aP0_ProfesionalesId ;
      private long aP1_SolicitudesID ;
      private DateTime aP2_Desde ;
      private DateTime aP3_Hasta ;
      private int aP4_Clasificaciones ;
      private string aP5_SolicitudServicioOrigenPago ;
      private IDataStoreProvider pr_default ;
      private string[] P00DN2_A130EstadosSolTipo ;
      private string[] P00DN2_A438SolicitudServicioOrigenPago ;
      private bool[] P00DN2_n438SolicitudServicioOrigenPago ;
      private DateTime[] P00DN2_A184SolicitudesFechaInstalacion ;
      private int[] P00DN2_A131EstadosSolId ;
      private long[] P00DN2_A127SolicitudesID ;
      private string[] P00DN2_A171SolicitudesNombre ;
      private string[] P00DN2_A132EstadosSolNombre ;
      private decimal[] P00DN2_A527SolicitudServicioComProv ;
      private bool[] P00DN2_n527SolicitudServicioComProv ;
      private decimal[] P00DN2_A530SolicitudServicioComALM ;
      private bool[] P00DN2_n530SolicitudServicioComALM ;
      private decimal[] P00DN2_A865SolicitudesCostoXZComAlm ;
      private bool[] P00DN2_n865SolicitudesCostoXZComAlm ;
      private decimal[] P00DN2_A796SolicitudesComisionMetodoPago ;
      private decimal[] P00DN2_A212SolicitudesCotizacion ;
      private decimal[] P00DN2_A1016SolicitudesDescuentoCupon ;
      private decimal[] P00DN2_A897SolicitudesDescuento ;
      private bool[] P00DN2_n897SolicitudesDescuento ;
      private decimal[] P00DN2_A864SolicitudesCostoXZona ;
      private long[] P00DN3_A127SolicitudesID ;
      private short[] P00DN3_A134SolicitudesItemsID ;
      private decimal[] P00DN3_A180SolicitudItemsComision ;
      private string[] P00DN3_A179SolicitudItemsComisionTipo ;
      private string[] P00DN3_A178SolicitudItemsSR ;
      private short[] P00DN3_A177SolicitudesItemsCantidad ;
      private decimal[] P00DN3_A176SolicitudesItemsPrecioFinal ;
      private bool[] P00DN3_n176SolicitudesItemsPrecioFinal ;
   }

   public class areporteeconomicodetallado__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP00DN2;
          prmP00DN2 = new Object[] {
          new ParDef("@AV11SolicitudesID",GXType.Decimal,18,0) ,
          new ParDef("@AV29Clasificaciones",GXType.Int32,5,0) ,
          new ParDef("@AV8Desde",GXType.Date,8,0) ,
          new ParDef("@AV9Hasta",GXType.Date,8,0) ,
          new ParDef("@AV27SolicitudServicioOrigenPago",GXType.NChar,1,0)
          };
          Object[] prmP00DN3;
          prmP00DN3 = new Object[] {
          new ParDef("@SolicitudesID",GXType.Decimal,18,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00DN2", "SELECT T1.[EstadosSolTipo] AS EstadosSolTipo, T1.[SolicitudServicioOrigenPago], T1.[SolicitudesFechaInstalacion], T1.[EstadosSolId] AS EstadosSolId, T1.[SolicitudesID], T1.[SolicitudesNombre], T2.[EstadosGenericosNombre] AS EstadosSolNombre, T1.[SolicitudServicioComProv], T1.[SolicitudServicioComALM], T1.[SolicitudesCostoXZComAlm], T1.[SolicitudesComisionMetodoPago], T1.[SolicitudesCotizacion], T1.[SolicitudesDescuentoCupon], T1.[SolicitudesDescuento], T1.[SolicitudesCostoXZona] FROM ([Solicitudes] T1 INNER JOIN [EstadosGenericos] T2 ON T2.[EstadosTipo] = T1.[EstadosSolTipo] AND T2.[EstadosGenericosId] = T1.[EstadosSolId]) WHERE (T1.[SolicitudesID] = @AV11SolicitudesID or @AV11SolicitudesID = 0) AND (T1.[EstadosSolId] = @AV29Clasificaciones or @AV29Clasificaciones = 0) AND (T1.[SolicitudesFechaInstalacion] >= @AV8Desde and T1.[SolicitudesFechaInstalacion] <= @AV9Hasta) AND (T1.[SolicitudServicioOrigenPago] = @AV27SolicitudServicioOrigenPago or @AV27SolicitudServicioOrigenPago = '') ORDER BY T1.[SolicitudesID] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00DN2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00DN3", "SELECT [SolicitudesID], [SolicitudesItemsID], [SolicitudItemsComision], [SolicitudItemsComisionTipo], [SolicitudItemsSR], [SolicitudesItemsCantidad], [SolicitudesItemsPrecioFinal] FROM [SolicitudesItems] WHERE [SolicitudesID] = @SolicitudesID ORDER BY [SolicitudesID] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00DN3,100, GxCacheFrequency.OFF ,true,false )
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
                ((bool[]) buf[9])[0] = rslt.wasNull(8);
                ((decimal[]) buf[10])[0] = rslt.getDecimal(9);
                ((bool[]) buf[11])[0] = rslt.wasNull(9);
                ((decimal[]) buf[12])[0] = rslt.getDecimal(10);
                ((bool[]) buf[13])[0] = rslt.wasNull(10);
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

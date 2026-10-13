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
using GeneXus.XML;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using GeneXus.Http.Server;
using System.Threading;
using System.Xml.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Runtime.Serialization;
namespace GeneXus.Programs.pagos {
   public class generarfilepag : GXProcedure
   {
      public generarfilepag( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public generarfilepag( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( long aP0_SolicitudId ,
                           ref string aP1_URL )
      {
         this.AV25SolicitudId = aP0_SolicitudId;
         this.AV27URL = aP1_URL;
         initialize();
         ExecutePrivate();
         aP1_URL=this.AV27URL;
      }

      public string executeUdp( long aP0_SolicitudId )
      {
         execute(aP0_SolicitudId, ref aP1_URL);
         return AV27URL ;
      }

      public void executeSubmit( long aP0_SolicitudId ,
                                 ref string aP1_URL )
      {
         this.AV25SolicitudId = aP0_SolicitudId;
         this.AV27URL = aP1_URL;
         SubmitImpl();
         aP1_URL=this.AV27URL;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         GXt_SdtSDTConexiones1 = AV11Conexiones;
         new odatconexion(context ).execute(  context.GetMessage( "SISTAR", ""), out  GXt_SdtSDTConexiones1) ;
         AV11Conexiones = GXt_SdtSDTConexiones1;
         AV54GXV1 = 1;
         while ( AV54GXV1 <= AV11Conexiones.gxTpr_Datos.Count )
         {
            AV21Item = ((SdtSDTConexiones_Item)AV11Conexiones.gxTpr_Datos.Item(AV54GXV1));
            if ( StringUtil.StrCmp(AV21Item.gxTpr_Conexionesdatosid, context.GetMessage( "idBanco", "")) == 0 )
            {
               AV16idBanco = AV21Item.gxTpr_Conexionesdatosext;
            }
            else if ( StringUtil.StrCmp(AV21Item.gxTpr_Conexionesdatosid, context.GetMessage( "idOrganismo", "")) == 0 )
            {
               AV18idOrganismo = AV21Item.gxTpr_Conexionesdatosext;
            }
            else if ( StringUtil.StrCmp(AV21Item.gxTpr_Conexionesdatosid, context.GetMessage( "tipoServicio", "")) == 0 )
            {
               AV26tipoServicio = AV21Item.gxTpr_Conexionesdatosext;
            }
            else if ( StringUtil.StrCmp(AV21Item.gxTpr_Conexionesdatosid, context.GetMessage( "idCuenta", "")) == 0 )
            {
               AV17idCuenta = AV21Item.gxTpr_Conexionesdatosext;
            }
            else if ( StringUtil.StrCmp(AV21Item.gxTpr_Conexionesdatosid, context.GetMessage( "urlVuelta", "")) == 0 )
            {
               AV28urlVuelta = AV21Item.gxTpr_Conexionesdatosext;
            }
            else if ( StringUtil.StrCmp(AV21Item.gxTpr_Conexionesdatosid, context.GetMessage( "consumidorFinal", "")) == 0 )
            {
               AV12consumidorFinal = AV21Item.gxTpr_Conexionesdatosext;
            }
            else if ( StringUtil.StrCmp(AV21Item.gxTpr_Conexionesdatosid, context.GetMessage( "PFXDIR", "")) == 0 )
            {
               AV50PFXDIR = AV21Item.gxTpr_Conexionesdatosint;
            }
            else if ( StringUtil.StrCmp(AV21Item.gxTpr_Conexionesdatosid, context.GetMessage( "PFXKEY", "")) == 0 )
            {
               AV51PFXKEY = AV21Item.gxTpr_Conexionesdatosint;
            }
            AV54GXV1 = (int)(AV54GXV1+1);
         }
         /* Using cursor P00A32 */
         pr_default.execute(0, new Object[] {AV25SolicitudId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A127SolicitudesID = P00A32_A127SolicitudesID[0];
            A530SolicitudServicioComALM = P00A32_A530SolicitudServicioComALM[0];
            n530SolicitudServicioComALM = P00A32_n530SolicitudServicioComALM[0];
            A527SolicitudServicioComProv = P00A32_A527SolicitudServicioComProv[0];
            n527SolicitudServicioComProv = P00A32_n527SolicitudServicioComProv[0];
            A171SolicitudesNombre = P00A32_A171SolicitudesNombre[0];
            A796SolicitudesComisionMetodoPago = P00A32_A796SolicitudesComisionMetodoPago[0];
            A212SolicitudesCotizacion = P00A32_A212SolicitudesCotizacion[0];
            A1016SolicitudesDescuentoCupon = P00A32_A1016SolicitudesDescuentoCupon[0];
            A897SolicitudesDescuento = P00A32_A897SolicitudesDescuento[0];
            n897SolicitudesDescuento = P00A32_n897SolicitudesDescuento[0];
            A864SolicitudesCostoXZona = P00A32_A864SolicitudesCostoXZona[0];
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
            AV20Importe = A211SolicitudServicioPFinal;
            AV30ImporteGrabado = (decimal)(A527SolicitudServicioComProv+A530SolicitudServicioComALM);
            new orelnom(context ).execute(  A127SolicitudesID, out  AV40ProfesionalesId, out  AV41nombreProfesional, out  AV42Existe) ;
            if ( StringUtil.StrCmp(AV42Existe, context.GetMessage( "S", "")) == 0 )
            {
               AV39otroDato = context.GetMessage( "Pago de solicitud de servicio nro:.", "") + StringUtil.Trim( StringUtil.Str( (decimal)(A127SolicitudesID), 10, 0)) + context.GetMessage( " a nombre de: ", "") + StringUtil.Trim( AV41nombreProfesional) + context.GetMessage( " dato de contacto: ", "") + StringUtil.Trim( A171SolicitudesNombre);
            }
            else
            {
               AV39otroDato = context.GetMessage( "Pago de solicitud de servicio nro:.", "") + StringUtil.Trim( StringUtil.Str( (decimal)(A127SolicitudesID), 10, 0)) + context.GetMessage( " contratado por: ", "") + StringUtil.Trim( A171SolicitudesNombre);
            }
            /* Exit For each command. Update data (if necessary), close cursors & exit. */
            if (true) break;
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(0);
         AV8OperacionesTipoES = "E";
         AV22MonISo = context.GetMessage( "UYU", "");
         /* Using cursor P00A33 */
         pr_default.execute(1);
         while ( (pr_default.getStatus(1) != 101) )
         {
            A555OperacionesRef = P00A33_A555OperacionesRef[0];
            n555OperacionesRef = P00A33_n555OperacionesRef[0];
            A554OperacionesId = P00A33_A554OperacionesId[0];
            A579OperacionesOrdinal = P00A33_A579OperacionesOrdinal[0];
            n579OperacionesOrdinal = P00A33_n579OperacionesOrdinal[0];
            A570OperacionesImporte = P00A33_A570OperacionesImporte[0];
            n570OperacionesImporte = P00A33_n570OperacionesImporte[0];
            A571OperacionesMoneda = P00A33_A571OperacionesMoneda[0];
            n571OperacionesMoneda = P00A33_n571OperacionesMoneda[0];
            A572OperacionesFacturaCod = P00A33_A572OperacionesFacturaCod[0];
            n572OperacionesFacturaCod = P00A33_n572OperacionesFacturaCod[0];
            A586OperacionesIDORD = P00A33_A586OperacionesIDORD[0];
            n586OperacionesIDORD = P00A33_n586OperacionesIDORD[0];
            A577OperacionesEstado = P00A33_A577OperacionesEstado[0];
            n577OperacionesEstado = P00A33_n577OperacionesEstado[0];
            if ( StringUtil.StrCmp(StringUtil.Trim( A555OperacionesRef), StringUtil.Trim( context.localUtil.Format( (decimal)(AV25SolicitudId), "ZZZZZZZZZZZZZZZZZ9"))) == 0 )
            {
               AV31OperacionesId = A554OperacionesId;
               AV32Ordinal = A579OperacionesOrdinal;
               A579OperacionesOrdinal = (long)(A579OperacionesOrdinal+1);
               n579OperacionesOrdinal = false;
               A570OperacionesImporte = AV20Importe;
               n570OperacionesImporte = false;
               A571OperacionesMoneda = AV22MonISo;
               n571OperacionesMoneda = false;
               A572OperacionesFacturaCod = AV9CodigoFactura;
               n572OperacionesFacturaCod = false;
               AV33CidTransaccion = StringUtil.Trim( StringUtil.Str( (decimal)(A554OperacionesId), 10, 0)) + StringUtil.Trim( StringUtil.Str( (decimal)(A579OperacionesOrdinal), 10, 0));
               A586OperacionesIDORD = AV33CidTransaccion;
               n586OperacionesIDORD = false;
               A577OperacionesEstado = "PND";
               n577OperacionesEstado = false;
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               /* Using cursor P00A34 */
               pr_default.execute(2, new Object[] {n579OperacionesOrdinal, A579OperacionesOrdinal, n570OperacionesImporte, A570OperacionesImporte, n571OperacionesMoneda, A571OperacionesMoneda, n572OperacionesFacturaCod, A572OperacionesFacturaCod, n586OperacionesIDORD, A586OperacionesIDORD, n577OperacionesEstado, A577OperacionesEstado, A554OperacionesId});
               pr_default.close(2);
               pr_default.SmartCacheProvider.SetUpdated("Operaciones");
               if (true) break;
               /* Using cursor P00A35 */
               pr_default.execute(3, new Object[] {n579OperacionesOrdinal, A579OperacionesOrdinal, n570OperacionesImporte, A570OperacionesImporte, n571OperacionesMoneda, A571OperacionesMoneda, n572OperacionesFacturaCod, A572OperacionesFacturaCod, n586OperacionesIDORD, A586OperacionesIDORD, n577OperacionesEstado, A577OperacionesEstado, A554OperacionesId});
               pr_default.close(3);
               pr_default.SmartCacheProvider.SetUpdated("Operaciones");
            }
            pr_default.readNext(1);
         }
         pr_default.close(1);
         AV32Ordinal = (long)(AV32Ordinal+1);
         if ( AV31OperacionesId == 0 )
         {
            /* Using cursor P00A36 */
            pr_default.execute(4);
            while ( (pr_default.getStatus(4) != 101) )
            {
               A554OperacionesId = P00A36_A554OperacionesId[0];
               AV31OperacionesId = A554OperacionesId;
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               if (true) break;
               pr_default.readNext(4);
            }
            pr_default.close(4);
            if ( AV31OperacionesId == 0 )
            {
               AV31OperacionesId = 1000;
            }
            AV31OperacionesId = (long)(AV31OperacionesId+1);
            /*
               INSERT RECORD ON TABLE Operaciones

            */
            A554OperacionesId = AV31OperacionesId;
            A579OperacionesOrdinal = AV32Ordinal;
            n579OperacionesOrdinal = false;
            A555OperacionesRef = StringUtil.Trim( context.localUtil.Format( (decimal)(AV25SolicitudId), "ZZZZZZZZZZZZZZZZZ9"));
            n555OperacionesRef = false;
            A569OperacionesTipoES = AV8OperacionesTipoES;
            n569OperacionesTipoES = false;
            A570OperacionesImporte = AV20Importe;
            n570OperacionesImporte = false;
            A571OperacionesMoneda = AV22MonISo;
            n571OperacionesMoneda = false;
            A578OperacionesImporteGrabado = AV30ImporteGrabado;
            n578OperacionesImporteGrabado = false;
            A572OperacionesFacturaCod = AV9CodigoFactura;
            n572OperacionesFacturaCod = false;
            A581OperacionesFechaAlta = DateTimeUtil.ResetTime(DateTimeUtil.ServerNow( context, pr_default));
            n581OperacionesFechaAlta = false;
            AV33CidTransaccion = StringUtil.Trim( StringUtil.Str( (decimal)(AV31OperacionesId), 10, 0)) + StringUtil.Trim( StringUtil.Str( (decimal)(AV32Ordinal), 10, 0));
            A586OperacionesIDORD = AV33CidTransaccion;
            n586OperacionesIDORD = false;
            A649OperacionesTipo = "CSO";
            n649OperacionesTipo = false;
            A577OperacionesEstado = "PND";
            n577OperacionesEstado = false;
            /* Using cursor P00A37 */
            pr_default.execute(5, new Object[] {A554OperacionesId, n555OperacionesRef, A555OperacionesRef, n579OperacionesOrdinal, A579OperacionesOrdinal, n586OperacionesIDORD, A586OperacionesIDORD, n569OperacionesTipoES, A569OperacionesTipoES, n570OperacionesImporte, A570OperacionesImporte, n571OperacionesMoneda, A571OperacionesMoneda, n572OperacionesFacturaCod, A572OperacionesFacturaCod, n578OperacionesImporteGrabado, A578OperacionesImporteGrabado, n581OperacionesFechaAlta, A581OperacionesFechaAlta, n577OperacionesEstado, A577OperacionesEstado, n649OperacionesTipo, A649OperacionesTipo});
            pr_default.close(5);
            pr_default.SmartCacheProvider.SetUpdated("Operaciones");
            if ( (pr_default.getStatus(5) == 1) )
            {
               context.Gx_err = 1;
               Gx_emsg = (string)(context.GetMessage( "GXM_noupdate", ""));
            }
            else
            {
               context.Gx_err = 0;
               Gx_emsg = "";
            }
            /* End Insert */
         }
         AV13firma = "";
         AV27URL = StringUtil.Format( context.GetMessage( "https://%1%2", ""), StringUtil.Trim( AV11Conexiones.gxTpr_Conexioneshost), StringUtil.Trim( AV11Conexiones.gxTpr_Conexionesbaseurl), "", "", "", "", "", "", "");
         AV9CodigoFactura = context.localUtil.Format( (decimal)(AV25SolicitudId), "ZZZZZZZZZZZZZZZZZ9");
         AV34cImporte = context.localUtil.Format( AV20Importe, "ZZZZZZ,ZZZ,ZZZ,ZZ9.99");
         AV34cImporte = StringUtil.StringReplace( AV34cImporte, ",", "");
         AV34cImporte = StringUtil.StringReplace( AV34cImporte, ".", "");
         AV35cImporteGrabado = context.localUtil.Format( AV30ImporteGrabado, "ZZZZZZ,ZZZ,ZZZ,ZZ9.99");
         AV35cImporteGrabado = StringUtil.StringReplace( AV35cImporteGrabado, ",", "");
         AV35cImporteGrabado = StringUtil.StringReplace( AV35cImporteGrabado, ".", "");
         /* Execute user subroutine: 'GENERAR FIRMA' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         AV29XML = context.GetMessage( "<!DOCTYPE html><html><head>", "") + context.GetMessage( "<script>window.onload = function() {document.getElementById(\"myForm\").submit();};</script>", "") + context.GetMessage( "</head>", "") + context.GetMessage( "<body>", "") + context.GetMessage( "<form id=\"myForm\" method=\"POST\" action=\"", "") + StringUtil.Trim( AV27URL) + "\">" + context.GetMessage( "<input type=\"hidden\" name=\"idBanco\" id=\"idBanco\" value=\"", "") + StringUtil.Trim( AV16idBanco) + "\">" + context.GetMessage( "<input type=\"hidden\" name=\"idTransaccion\" id=\"idTransaccion\" value=\"", "") + StringUtil.Trim( AV33CidTransaccion) + "\">" + context.GetMessage( "<input type=\"hidden\" name=\"idOrganismo\" id=\"idOrganismo\" value=\"", "") + StringUtil.Trim( AV18idOrganismo) + "\">" + context.GetMessage( "<input type=\"hidden\" name=\"tipoServicio\" id=\"tipoServicio\" value=\"", "") + StringUtil.Trim( AV26tipoServicio) + "\">" + context.GetMessage( "<input type=\"hidden\" name=\"idCuenta\" id=\"idCuenta\" value=\"", "") + StringUtil.Trim( AV17idCuenta) + "\">" + context.GetMessage( "<input type=\"hidden\" name=\"idFactura\" id=\"idFactura\" value=\"", "") + StringUtil.Trim( AV9CodigoFactura) + "\">" + context.GetMessage( "<input type=\"hidden\" name=\"importe\" id=\"importe\" value=\"", "") + StringUtil.Trim( AV34cImporte) + "\">" + context.GetMessage( "<input type=\"hidden\" name=\"moneda\" id=\"moneda\" value=\"", "") + StringUtil.Trim( AV22MonISo) + "\">" + context.GetMessage( "<input type=\"hidden\" name=\"importeGravado\" id=\"importeGravado\" value=\"", "") + StringUtil.Trim( StringUtil.RTrim( context.localUtil.Format( AV35cImporteGrabado, ""))) + "\">" + context.GetMessage( "<input type=\"hidden\" name=\"consumidorFinal\" id=\"consumidorFinal\" value=\"", "") + StringUtil.Trim( AV12consumidorFinal) + "\">" + context.GetMessage( "<input type=\"hidden\" name=\"urlVuelta\" id=\"urlVuelta\" value=\"", "") + StringUtil.Trim( AV28urlVuelta) + "\">" + context.GetMessage( "<input type=\"hidden\" name=\"firma\" id=\"firma\" value=\"", "") + StringUtil.Trim( AV13firma) + "\">" + context.GetMessage( "</form></body></html>", "");
         AV23NombreArchivo = StringUtil.Format( context.GetMessage( "datafile/pay%1.htm", ""), AV33CidTransaccion, "", "", "", "", "", "", "", "");
         AV27URL = AV14HttpRequest.BaseURL + StringUtil.Trim( AV23NombreArchivo);
         AV15i = context.FileIOInstance.dfwopen( AV23NombreArchivo, "", "", 1, "");
         AV15i = context.FileIOInstance.dfwptxt( AV29XML, 0);
         AV15i = context.FileIOInstance.dfwnext( );
         AV15i = context.FileIOInstance.dfwclose( );
         cleanup();
      }

      protected void S111( )
      {
         /* 'GENERAR FIRMA' Routine */
         returnInSub = false;
         AV53errorCode = (bool)(Convert.ToBoolean(AV52CryptoCert.Load(context.GetMessage( "C:\\bak\\Almango.pfx", ""), "123456")));
         if ( ! AV53errorCode )
         {
            if ( AV52CryptoCert.HasPrivateKey() )
            {
               AV43String = StringUtil.Trim( AV16idBanco) + StringUtil.Trim( AV33CidTransaccion) + StringUtil.Trim( AV18idOrganismo) + StringUtil.Trim( AV26tipoServicio) + StringUtil.Trim( AV17idCuenta) + StringUtil.Trim( AV9CodigoFactura) + StringUtil.Trim( AV34cImporte) + StringUtil.Trim( AV22MonISo) + StringUtil.Trim( AV35cImporteGrabado) + StringUtil.Trim( AV12consumidorFinal);
               AV49CryptoSign.Algorithm = "SHA256 RSA";
               AV49CryptoSign.Certificate = AV52CryptoCert;
               AV13firma = AV49CryptoSign.Sign(StringUtil.Trim( AV43String), false);
               AV13firma = StringUtil.ToBase64( StringUtil.Trim( AV13firma));
            }
            else
            {
               AV13firma = context.GetMessage( "error en HasPrivateKey ", "") + StringUtil.Str( (decimal)(AV52CryptoCert.ErrCode), 10, 2) + " " + AV52CryptoCert.ErrDescription;
            }
         }
         else
         {
            AV13firma = context.GetMessage( "error en load de certificado ", "") + StringUtil.Str( (decimal)(AV52CryptoCert.ErrCode), 10, 2) + " " + AV52CryptoCert.ErrDescription;
         }
      }

      protected void GetSolicitudesTotal( long A127SolicitudesID )
      {
         /* Create private dbobjects */
         /* Navigation */
         A174SolicitudesTotal = 0;
         /* Using cursor P00A38 */
         pr_default.execute(6, new Object[] {A127SolicitudesID});
         while ( (pr_default.getStatus(6) != 101) && ( P00A38_A127SolicitudesID[0] == A127SolicitudesID ) )
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( P00A38_A178SolicitudItemsSR[0])) || ( StringUtil.StrCmp(P00A38_A179SolicitudItemsComisionTipo[0], "N") == 0 ) )
            {
               A175SolicitudesItemsPrecioInstalac = (decimal)((P00A38_A176SolicitudesItemsPrecioFinal[0]*P00A38_A177SolicitudesItemsCantidad[0]));
            }
            else
            {
               if ( ( StringUtil.StrCmp(P00A38_A179SolicitudItemsComisionTipo[0], "F") == 0 ) && ( StringUtil.StrCmp(P00A38_A178SolicitudItemsSR[0], "R") == 0 ) )
               {
                  A175SolicitudesItemsPrecioInstalac = (decimal)((P00A38_A176SolicitudesItemsPrecioFinal[0]*P00A38_A177SolicitudesItemsCantidad[0])-(P00A38_A180SolicitudItemsComision[0]*P00A38_A177SolicitudesItemsCantidad[0]));
               }
               else
               {
                  if ( ( StringUtil.StrCmp(P00A38_A179SolicitudItemsComisionTipo[0], "F") == 0 ) && ( StringUtil.StrCmp(P00A38_A178SolicitudItemsSR[0], "S") == 0 ) )
                  {
                     A175SolicitudesItemsPrecioInstalac = (decimal)((P00A38_A176SolicitudesItemsPrecioFinal[0]*P00A38_A177SolicitudesItemsCantidad[0])+(P00A38_A180SolicitudItemsComision[0]*P00A38_A177SolicitudesItemsCantidad[0]));
                  }
                  else
                  {
                     if ( ( StringUtil.StrCmp(P00A38_A179SolicitudItemsComisionTipo[0], "P") == 0 ) && ( StringUtil.StrCmp(P00A38_A178SolicitudItemsSR[0], "R") == 0 ) )
                     {
                        A175SolicitudesItemsPrecioInstalac = (decimal)((P00A38_A176SolicitudesItemsPrecioFinal[0]*P00A38_A177SolicitudesItemsCantidad[0])-((P00A38_A176SolicitudesItemsPrecioFinal[0]*P00A38_A177SolicitudesItemsCantidad[0])*(P00A38_A180SolicitudItemsComision[0]/ (decimal)(100))));
                     }
                     else
                     {
                        if ( ( StringUtil.StrCmp(P00A38_A179SolicitudItemsComisionTipo[0], "P") == 0 ) && ( StringUtil.StrCmp(P00A38_A178SolicitudItemsSR[0], "S") == 0 ) )
                        {
                           A175SolicitudesItemsPrecioInstalac = (decimal)((P00A38_A176SolicitudesItemsPrecioFinal[0]*P00A38_A177SolicitudesItemsCantidad[0])+((P00A38_A176SolicitudesItemsPrecioFinal[0]*P00A38_A177SolicitudesItemsCantidad[0])*(P00A38_A180SolicitudItemsComision[0]/ (decimal)(100))));
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
            pr_default.readNext(6);
         }
         pr_default.close(6);
      }

      public override void cleanup( )
      {
         context.CommitDataStores("pagos.generarfilepag",pr_default);
         CloseCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
         ExitApp();
      }

      public override void initialize( )
      {
         AV11Conexiones = new SdtSDTConexiones(context);
         GXt_SdtSDTConexiones1 = new SdtSDTConexiones(context);
         AV21Item = new SdtSDTConexiones_Item(context);
         AV16idBanco = "";
         AV18idOrganismo = "";
         AV26tipoServicio = "";
         AV17idCuenta = "";
         AV28urlVuelta = "";
         AV12consumidorFinal = "";
         AV50PFXDIR = "";
         AV51PFXKEY = "";
         P00A32_A127SolicitudesID = new long[1] ;
         P00A32_A530SolicitudServicioComALM = new decimal[1] ;
         P00A32_n530SolicitudServicioComALM = new bool[] {false} ;
         P00A32_A527SolicitudServicioComProv = new decimal[1] ;
         P00A32_n527SolicitudServicioComProv = new bool[] {false} ;
         P00A32_A171SolicitudesNombre = new string[] {""} ;
         P00A32_A796SolicitudesComisionMetodoPago = new decimal[1] ;
         P00A32_A212SolicitudesCotizacion = new decimal[1] ;
         P00A32_A1016SolicitudesDescuentoCupon = new decimal[1] ;
         P00A32_A897SolicitudesDescuento = new decimal[1] ;
         P00A32_n897SolicitudesDescuento = new bool[] {false} ;
         P00A32_A864SolicitudesCostoXZona = new decimal[1] ;
         A171SolicitudesNombre = "";
         AV40ProfesionalesId = "";
         AV41nombreProfesional = "";
         AV42Existe = "";
         AV39otroDato = "";
         AV8OperacionesTipoES = "";
         AV22MonISo = "";
         P00A33_A555OperacionesRef = new string[] {""} ;
         P00A33_n555OperacionesRef = new bool[] {false} ;
         P00A33_A554OperacionesId = new long[1] ;
         P00A33_A579OperacionesOrdinal = new long[1] ;
         P00A33_n579OperacionesOrdinal = new bool[] {false} ;
         P00A33_A570OperacionesImporte = new decimal[1] ;
         P00A33_n570OperacionesImporte = new bool[] {false} ;
         P00A33_A571OperacionesMoneda = new string[] {""} ;
         P00A33_n571OperacionesMoneda = new bool[] {false} ;
         P00A33_A572OperacionesFacturaCod = new string[] {""} ;
         P00A33_n572OperacionesFacturaCod = new bool[] {false} ;
         P00A33_A586OperacionesIDORD = new string[] {""} ;
         P00A33_n586OperacionesIDORD = new bool[] {false} ;
         P00A33_A577OperacionesEstado = new string[] {""} ;
         P00A33_n577OperacionesEstado = new bool[] {false} ;
         A555OperacionesRef = "";
         A571OperacionesMoneda = "";
         A572OperacionesFacturaCod = "";
         A586OperacionesIDORD = "";
         A577OperacionesEstado = "";
         AV9CodigoFactura = "";
         AV33CidTransaccion = "";
         P00A36_A554OperacionesId = new long[1] ;
         A569OperacionesTipoES = "";
         A581OperacionesFechaAlta = DateTime.MinValue;
         A649OperacionesTipo = "";
         Gx_emsg = "";
         AV13firma = "";
         AV34cImporte = "";
         AV35cImporteGrabado = "";
         AV29XML = "";
         AV23NombreArchivo = "";
         AV14HttpRequest = new GxHttpRequest( context);
         AV52CryptoCert = new GXCertificate();
         AV43String = "";
         AV49CryptoSign = new GXSigning();
         P00A38_A127SolicitudesID = new long[1] ;
         P00A38_A134SolicitudesItemsID = new short[1] ;
         P00A38_A180SolicitudItemsComision = new decimal[1] ;
         P00A38_A179SolicitudItemsComisionTipo = new string[] {""} ;
         P00A38_A178SolicitudItemsSR = new string[] {""} ;
         P00A38_A177SolicitudesItemsCantidad = new short[1] ;
         P00A38_A176SolicitudesItemsPrecioFinal = new decimal[1] ;
         P00A38_n176SolicitudesItemsPrecioFinal = new bool[] {false} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.pagos.generarfilepag__default(),
            new Object[][] {
                new Object[] {
               P00A32_A127SolicitudesID, P00A32_A530SolicitudServicioComALM, P00A32_n530SolicitudServicioComALM, P00A32_A527SolicitudServicioComProv, P00A32_n527SolicitudServicioComProv, P00A32_A171SolicitudesNombre, P00A32_A796SolicitudesComisionMetodoPago, P00A32_A212SolicitudesCotizacion, P00A32_A1016SolicitudesDescuentoCupon, P00A32_A897SolicitudesDescuento,
               P00A32_n897SolicitudesDescuento, P00A32_A864SolicitudesCostoXZona
               }
               , new Object[] {
               P00A33_A555OperacionesRef, P00A33_n555OperacionesRef, P00A33_A554OperacionesId, P00A33_A579OperacionesOrdinal, P00A33_n579OperacionesOrdinal, P00A33_A570OperacionesImporte, P00A33_n570OperacionesImporte, P00A33_A571OperacionesMoneda, P00A33_n571OperacionesMoneda, P00A33_A572OperacionesFacturaCod,
               P00A33_n572OperacionesFacturaCod, P00A33_A586OperacionesIDORD, P00A33_n586OperacionesIDORD, P00A33_A577OperacionesEstado, P00A33_n577OperacionesEstado
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               P00A36_A554OperacionesId
               }
               , new Object[] {
               }
               , new Object[] {
               P00A38_A127SolicitudesID, P00A38_A134SolicitudesItemsID, P00A38_A180SolicitudItemsComision, P00A38_A179SolicitudItemsComisionTipo, P00A38_A178SolicitudItemsSR, P00A38_A177SolicitudesItemsCantidad, P00A38_A176SolicitudesItemsPrecioFinal, P00A38_n176SolicitudesItemsPrecioFinal
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV15i ;
      private int AV54GXV1 ;
      private int GX_INS82 ;
      private long AV25SolicitudId ;
      private long A127SolicitudesID ;
      private long A554OperacionesId ;
      private long A579OperacionesOrdinal ;
      private long AV31OperacionesId ;
      private long AV32Ordinal ;
      private decimal A530SolicitudServicioComALM ;
      private decimal A527SolicitudServicioComProv ;
      private decimal A796SolicitudesComisionMetodoPago ;
      private decimal A212SolicitudesCotizacion ;
      private decimal A1016SolicitudesDescuentoCupon ;
      private decimal A897SolicitudesDescuento ;
      private decimal A864SolicitudesCostoXZona ;
      private decimal A211SolicitudServicioPFinal ;
      private decimal A174SolicitudesTotal ;
      private decimal AV20Importe ;
      private decimal AV30ImporteGrabado ;
      private decimal A570OperacionesImporte ;
      private decimal A578OperacionesImporteGrabado ;
      private decimal A175SolicitudesItemsPrecioInstalac ;
      private string AV16idBanco ;
      private string AV18idOrganismo ;
      private string AV26tipoServicio ;
      private string AV17idCuenta ;
      private string AV28urlVuelta ;
      private string AV12consumidorFinal ;
      private string AV50PFXDIR ;
      private string AV51PFXKEY ;
      private string A171SolicitudesNombre ;
      private string AV40ProfesionalesId ;
      private string AV41nombreProfesional ;
      private string AV42Existe ;
      private string AV39otroDato ;
      private string AV8OperacionesTipoES ;
      private string AV22MonISo ;
      private string A555OperacionesRef ;
      private string A571OperacionesMoneda ;
      private string A572OperacionesFacturaCod ;
      private string A586OperacionesIDORD ;
      private string A577OperacionesEstado ;
      private string AV9CodigoFactura ;
      private string AV33CidTransaccion ;
      private string A569OperacionesTipoES ;
      private string A649OperacionesTipo ;
      private string Gx_emsg ;
      private string AV13firma ;
      private string AV34cImporte ;
      private string AV35cImporteGrabado ;
      private string AV23NombreArchivo ;
      private string AV43String ;
      private DateTime A581OperacionesFechaAlta ;
      private bool n530SolicitudServicioComALM ;
      private bool n527SolicitudServicioComProv ;
      private bool n897SolicitudesDescuento ;
      private bool n555OperacionesRef ;
      private bool n579OperacionesOrdinal ;
      private bool n570OperacionesImporte ;
      private bool n571OperacionesMoneda ;
      private bool n572OperacionesFacturaCod ;
      private bool n586OperacionesIDORD ;
      private bool n577OperacionesEstado ;
      private bool n569OperacionesTipoES ;
      private bool n578OperacionesImporteGrabado ;
      private bool n581OperacionesFechaAlta ;
      private bool n649OperacionesTipo ;
      private bool returnInSub ;
      private bool AV53errorCode ;
      private string AV29XML ;
      private string AV27URL ;
      private GXCertificate AV52CryptoCert ;
      private GxHttpRequest AV14HttpRequest ;
      private GXSigning AV49CryptoSign ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private string aP1_URL ;
      private SdtSDTConexiones AV11Conexiones ;
      private SdtSDTConexiones GXt_SdtSDTConexiones1 ;
      private SdtSDTConexiones_Item AV21Item ;
      private IDataStoreProvider pr_default ;
      private long[] P00A32_A127SolicitudesID ;
      private decimal[] P00A32_A530SolicitudServicioComALM ;
      private bool[] P00A32_n530SolicitudServicioComALM ;
      private decimal[] P00A32_A527SolicitudServicioComProv ;
      private bool[] P00A32_n527SolicitudServicioComProv ;
      private string[] P00A32_A171SolicitudesNombre ;
      private decimal[] P00A32_A796SolicitudesComisionMetodoPago ;
      private decimal[] P00A32_A212SolicitudesCotizacion ;
      private decimal[] P00A32_A1016SolicitudesDescuentoCupon ;
      private decimal[] P00A32_A897SolicitudesDescuento ;
      private bool[] P00A32_n897SolicitudesDescuento ;
      private decimal[] P00A32_A864SolicitudesCostoXZona ;
      private string[] P00A33_A555OperacionesRef ;
      private bool[] P00A33_n555OperacionesRef ;
      private long[] P00A33_A554OperacionesId ;
      private long[] P00A33_A579OperacionesOrdinal ;
      private bool[] P00A33_n579OperacionesOrdinal ;
      private decimal[] P00A33_A570OperacionesImporte ;
      private bool[] P00A33_n570OperacionesImporte ;
      private string[] P00A33_A571OperacionesMoneda ;
      private bool[] P00A33_n571OperacionesMoneda ;
      private string[] P00A33_A572OperacionesFacturaCod ;
      private bool[] P00A33_n572OperacionesFacturaCod ;
      private string[] P00A33_A586OperacionesIDORD ;
      private bool[] P00A33_n586OperacionesIDORD ;
      private string[] P00A33_A577OperacionesEstado ;
      private bool[] P00A33_n577OperacionesEstado ;
      private long[] P00A36_A554OperacionesId ;
      private long[] P00A38_A127SolicitudesID ;
      private short[] P00A38_A134SolicitudesItemsID ;
      private decimal[] P00A38_A180SolicitudItemsComision ;
      private string[] P00A38_A179SolicitudItemsComisionTipo ;
      private string[] P00A38_A178SolicitudItemsSR ;
      private short[] P00A38_A177SolicitudesItemsCantidad ;
      private decimal[] P00A38_A176SolicitudesItemsPrecioFinal ;
      private bool[] P00A38_n176SolicitudesItemsPrecioFinal ;
   }

   public class generarfilepag__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
         ,new UpdateCursor(def[2])
         ,new UpdateCursor(def[3])
         ,new ForEachCursor(def[4])
         ,new UpdateCursor(def[5])
         ,new ForEachCursor(def[6])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP00A32;
          prmP00A32 = new Object[] {
          new ParDef("@AV25SolicitudId",GXType.Decimal,18,0)
          };
          Object[] prmP00A33;
          prmP00A33 = new Object[] {
          };
          Object[] prmP00A34;
          prmP00A34 = new Object[] {
          new ParDef("@OperacionesOrdinal",GXType.Decimal,12,0){Nullable=true} ,
          new ParDef("@OperacionesImporte",GXType.Decimal,18,2){Nullable=true} ,
          new ParDef("@OperacionesMoneda",GXType.NChar,3,0){Nullable=true} ,
          new ParDef("@OperacionesFacturaCod",GXType.NChar,25,0){Nullable=true} ,
          new ParDef("@OperacionesIDORD",GXType.NChar,20,0){Nullable=true} ,
          new ParDef("@OperacionesEstado",GXType.NChar,3,0){Nullable=true} ,
          new ParDef("@OperacionesId",GXType.Decimal,18,0)
          };
          Object[] prmP00A35;
          prmP00A35 = new Object[] {
          new ParDef("@OperacionesOrdinal",GXType.Decimal,12,0){Nullable=true} ,
          new ParDef("@OperacionesImporte",GXType.Decimal,18,2){Nullable=true} ,
          new ParDef("@OperacionesMoneda",GXType.NChar,3,0){Nullable=true} ,
          new ParDef("@OperacionesFacturaCod",GXType.NChar,25,0){Nullable=true} ,
          new ParDef("@OperacionesIDORD",GXType.NChar,20,0){Nullable=true} ,
          new ParDef("@OperacionesEstado",GXType.NChar,3,0){Nullable=true} ,
          new ParDef("@OperacionesId",GXType.Decimal,18,0)
          };
          Object[] prmP00A36;
          prmP00A36 = new Object[] {
          };
          Object[] prmP00A37;
          prmP00A37 = new Object[] {
          new ParDef("@OperacionesId",GXType.Decimal,18,0) ,
          new ParDef("@OperacionesRef",GXType.NChar,25,0){Nullable=true} ,
          new ParDef("@OperacionesOrdinal",GXType.Decimal,12,0){Nullable=true} ,
          new ParDef("@OperacionesIDORD",GXType.NChar,20,0){Nullable=true} ,
          new ParDef("@OperacionesTipoES",GXType.NChar,1,0){Nullable=true} ,
          new ParDef("@OperacionesImporte",GXType.Decimal,18,2){Nullable=true} ,
          new ParDef("@OperacionesMoneda",GXType.NChar,3,0){Nullable=true} ,
          new ParDef("@OperacionesFacturaCod",GXType.NChar,25,0){Nullable=true} ,
          new ParDef("@OperacionesImporteGrabado",GXType.Decimal,18,2){Nullable=true} ,
          new ParDef("@OperacionesFechaAlta",GXType.Date,8,0){Nullable=true} ,
          new ParDef("@OperacionesEstado",GXType.NChar,3,0){Nullable=true} ,
          new ParDef("@OperacionesTipo",GXType.NChar,3,0){Nullable=true}
          };
          Object[] prmP00A38;
          prmP00A38 = new Object[] {
          new ParDef("@SolicitudesID",GXType.Decimal,18,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00A32", "SELECT TOP 1 [SolicitudesID], [SolicitudServicioComALM], [SolicitudServicioComProv], [SolicitudesNombre], [SolicitudesComisionMetodoPago], [SolicitudesCotizacion], [SolicitudesDescuentoCupon], [SolicitudesDescuento], [SolicitudesCostoXZona] FROM [Solicitudes] WHERE [SolicitudesID] = @AV25SolicitudId ORDER BY [SolicitudesID] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00A32,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("P00A33", "SELECT [OperacionesRef], [OperacionesId], [OperacionesOrdinal], [OperacionesImporte], [OperacionesMoneda], [OperacionesFacturaCod], [OperacionesIDORD], [OperacionesEstado] FROM [Operaciones] WITH (UPDLOCK) ORDER BY [OperacionesRef] DESC ",true, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00A33,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00A34", "UPDATE [Operaciones] SET [OperacionesOrdinal]=@OperacionesOrdinal, [OperacionesImporte]=@OperacionesImporte, [OperacionesMoneda]=@OperacionesMoneda, [OperacionesFacturaCod]=@OperacionesFacturaCod, [OperacionesIDORD]=@OperacionesIDORD, [OperacionesEstado]=@OperacionesEstado  WHERE [OperacionesId] = @OperacionesId", GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP00A34)
             ,new CursorDef("P00A35", "UPDATE [Operaciones] SET [OperacionesOrdinal]=@OperacionesOrdinal, [OperacionesImporte]=@OperacionesImporte, [OperacionesMoneda]=@OperacionesMoneda, [OperacionesFacturaCod]=@OperacionesFacturaCod, [OperacionesIDORD]=@OperacionesIDORD, [OperacionesEstado]=@OperacionesEstado  WHERE [OperacionesId] = @OperacionesId", GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP00A35)
             ,new CursorDef("P00A36", "SELECT TOP 1 [OperacionesId] FROM [Operaciones] ORDER BY [OperacionesId] DESC ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00A36,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00A37", "INSERT INTO [Operaciones]([OperacionesId], [OperacionesRef], [OperacionesOrdinal], [OperacionesIDORD], [OperacionesTipoES], [OperacionesImporte], [OperacionesMoneda], [OperacionesFacturaCod], [OperacionesImporteGrabado], [OperacionesFechaAlta], [OperacionesEstado], [OperacionesTipo], [OperacionesIva], [OperacionesComision], [OperacionesRequest], [OperacionesResponse], [OperacionesComprobantePago], [OperacionesFechaPago], [OperacionesAux1], [OperacionesAux2], [OperacionesAux3], [OperacionesNombreRef], [OperacionesFechaDesde], [OperacionesFechaHasta], [OperacionesMonId], [OperacionesBlob1], [OperacionesBlob2], [OperacionesUsrAlta], [OperacionesUsrActualizacion], [OperacionesComercioId1], [OperacionesComercioId2], [OperacionesPeriodoCod]) VALUES(@OperacionesId, @OperacionesRef, @OperacionesOrdinal, @OperacionesIDORD, @OperacionesTipoES, @OperacionesImporte, @OperacionesMoneda, @OperacionesFacturaCod, @OperacionesImporteGrabado, @OperacionesFechaAlta, @OperacionesEstado, @OperacionesTipo, convert(int, 0), convert(int, 0), '', '', '', convert( DATETIME, '17530101', 112 ), '', '', '', '', convert( DATETIME, '17530101', 112 ), convert( DATETIME, '17530101', 112 ), convert(int, 0), CONVERT(varbinary(1), ''), CONVERT(varbinary(1), ''), convert(int, 0), convert(int, 0), convert(int, 0), convert(int, 0), '')", GxErrorMask.GX_NOMASK,prmP00A37)
             ,new CursorDef("P00A38", "SELECT [SolicitudesID], [SolicitudesItemsID], [SolicitudItemsComision], [SolicitudItemsComisionTipo], [SolicitudItemsSR], [SolicitudesItemsCantidad], [SolicitudesItemsPrecioFinal] FROM [SolicitudesItems] WHERE [SolicitudesID] = @SolicitudesID ORDER BY [SolicitudesID] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00A38,100, GxCacheFrequency.OFF ,true,false )
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
                ((decimal[]) buf[1])[0] = rslt.getDecimal(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((decimal[]) buf[3])[0] = rslt.getDecimal(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getString(4, 100);
                ((decimal[]) buf[6])[0] = rslt.getDecimal(5);
                ((decimal[]) buf[7])[0] = rslt.getDecimal(6);
                ((decimal[]) buf[8])[0] = rslt.getDecimal(7);
                ((decimal[]) buf[9])[0] = rslt.getDecimal(8);
                ((bool[]) buf[10])[0] = rslt.wasNull(8);
                ((decimal[]) buf[11])[0] = rslt.getDecimal(9);
                return;
             case 1 :
                ((string[]) buf[0])[0] = rslt.getString(1, 25);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((long[]) buf[2])[0] = rslt.getLong(2);
                ((long[]) buf[3])[0] = rslt.getLong(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((decimal[]) buf[5])[0] = rslt.getDecimal(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((string[]) buf[7])[0] = rslt.getString(5, 3);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((string[]) buf[9])[0] = rslt.getString(6, 25);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((string[]) buf[11])[0] = rslt.getString(7, 20);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((string[]) buf[13])[0] = rslt.getString(8, 3);
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
                return;
             case 4 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
             case 6 :
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

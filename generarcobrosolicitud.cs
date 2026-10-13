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
using System.Threading;
using System.Xml.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class generarcobrosolicitud : GXProcedure
   {
      public generarcobrosolicitud( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public generarcobrosolicitud( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_TipoOpe ,
                           string aP1_Identificador ,
                           string aP2_OperacionesFacturaCod )
      {
         this.AV22TipoOpe = aP0_TipoOpe;
         this.AV23Identificador = aP1_Identificador;
         this.AV24OperacionesFacturaCod = aP2_OperacionesFacturaCod;
         initialize();
         ExecutePrivate();
      }

      public void executeSubmit( string aP0_TipoOpe ,
                                 string aP1_Identificador ,
                                 string aP2_OperacionesFacturaCod )
      {
         this.AV22TipoOpe = aP0_TipoOpe;
         this.AV23Identificador = aP1_Identificador;
         this.AV24OperacionesFacturaCod = aP2_OperacionesFacturaCod;
         SubmitImpl();
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         if ( StringUtil.StrCmp(AV22TipoOpe, context.GetMessage( "S", "")) == 0 )
         {
            AV8SolicitudesID = (long)(Math.Round(NumberUtil.Val( AV23Identificador, "."), 18, MidpointRounding.ToEven));
            /* Using cursor P00DH2 */
            pr_default.execute(0, new Object[] {AV8SolicitudesID});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A112DepartamentoId = P00DH2_A112DepartamentoId[0];
               n112DepartamentoId = P00DH2_n112DepartamentoId[0];
               A669STMonedasId = P00DH2_A669STMonedasId[0];
               n669STMonedasId = P00DH2_n669STMonedasId[0];
               A127SolicitudesID = P00DH2_A127SolicitudesID[0];
               A171SolicitudesNombre = P00DH2_A171SolicitudesNombre[0];
               A116PaisID = P00DH2_A116PaisID[0];
               A671STMonedasISO = P00DH2_A671STMonedasISO[0];
               A796SolicitudesComisionMetodoPago = P00DH2_A796SolicitudesComisionMetodoPago[0];
               A212SolicitudesCotizacion = P00DH2_A212SolicitudesCotizacion[0];
               A1016SolicitudesDescuentoCupon = P00DH2_A1016SolicitudesDescuentoCupon[0];
               A897SolicitudesDescuento = P00DH2_A897SolicitudesDescuento[0];
               n897SolicitudesDescuento = P00DH2_n897SolicitudesDescuento[0];
               A864SolicitudesCostoXZona = P00DH2_A864SolicitudesCostoXZona[0];
               A116PaisID = P00DH2_A116PaisID[0];
               A671STMonedasISO = P00DH2_A671STMonedasISO[0];
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
               AV14SDTSolicitudCobrar.gxTpr_Solicitudid = A127SolicitudesID;
               AV14SDTSolicitudCobrar.gxTpr_Codreferencia = StringUtil.Trim( StringUtil.Str( (decimal)(A127SolicitudesID), 18, 0));
               AV14SDTSolicitudCobrar.gxTpr_Totalcobrar = A211SolicitudServicioPFinal;
               AV14SDTSolicitudCobrar.gxTpr_Anombre = StringUtil.Trim( A171SolicitudesNombre);
               if ( String.IsNullOrEmpty(StringUtil.RTrim( A116PaisID)) )
               {
                  AV14SDTSolicitudCobrar.gxTpr_Pais = context.GetMessage( "UY", "");
               }
               else
               {
                  AV14SDTSolicitudCobrar.gxTpr_Pais = A116PaisID;
               }
               if ( String.IsNullOrEmpty(StringUtil.RTrim( A671STMonedasISO)) )
               {
                  AV14SDTSolicitudCobrar.gxTpr_Moneda = context.GetMessage( "UYU", "");
               }
               else
               {
                  AV14SDTSolicitudCobrar.gxTpr_Moneda = StringUtil.Trim( A671STMonedasISO);
               }
               /* Execute user subroutine: 'OBTENER DESCRIPCION' */
               S121 ();
               if ( returnInSub )
               {
                  pr_default.close(0);
                  cleanup();
                  if (true) return;
               }
               /* Execute user subroutine: 'GENERAR NUMERO DE ORDEN' */
               S131 ();
               if ( returnInSub )
               {
                  pr_default.close(0);
                  cleanup();
                  if (true) return;
               }
               AV14SDTSolicitudCobrar.gxTpr_Fuepago = AV20OperacionesEstado;
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               if (true) break;
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(0);
         }
         else
         {
            AV18OperacionesId = (long)(Math.Round(NumberUtil.Val( AV23Identificador, "."), 18, MidpointRounding.ToEven));
            /* Execute user subroutine: 'OBTENER OPERACION' */
            S111 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         AV17OrdenPago = AV14SDTSolicitudCobrar.ToJSonString(false, true);
         cleanup();
      }

      protected void S111( )
      {
         /* 'OBTENER OPERACION' Routine */
         returnInSub = false;
         /* Using cursor P00DH3 */
         pr_default.execute(1, new Object[] {AV18OperacionesId});
         while ( (pr_default.getStatus(1) != 101) )
         {
            A554OperacionesId = P00DH3_A554OperacionesId[0];
            A555OperacionesRef = P00DH3_A555OperacionesRef[0];
            n555OperacionesRef = P00DH3_n555OperacionesRef[0];
            A572OperacionesFacturaCod = P00DH3_A572OperacionesFacturaCod[0];
            n572OperacionesFacturaCod = P00DH3_n572OperacionesFacturaCod[0];
            A582OperacionesFechaPago = P00DH3_A582OperacionesFechaPago[0];
            n582OperacionesFechaPago = P00DH3_n582OperacionesFechaPago[0];
            A577OperacionesEstado = P00DH3_A577OperacionesEstado[0];
            n577OperacionesEstado = P00DH3_n577OperacionesEstado[0];
            A657OperacionesNombreRef = P00DH3_A657OperacionesNombreRef[0];
            n657OperacionesNombreRef = P00DH3_n657OperacionesNombreRef[0];
            A570OperacionesImporte = P00DH3_A570OperacionesImporte[0];
            n570OperacionesImporte = P00DH3_n570OperacionesImporte[0];
            A571OperacionesMoneda = P00DH3_A571OperacionesMoneda[0];
            n571OperacionesMoneda = P00DH3_n571OperacionesMoneda[0];
            AV14SDTSolicitudCobrar.gxTpr_Ordennro = A554OperacionesId;
            AV14SDTSolicitudCobrar.gxTpr_Codreferencia = StringUtil.Trim( A555OperacionesRef);
            AV14SDTSolicitudCobrar.gxTpr_Facturanro = StringUtil.Trim( A572OperacionesFacturaCod);
            AV14SDTSolicitudCobrar.gxTpr_Fechacobro = A582OperacionesFechaPago;
            AV14SDTSolicitudCobrar.gxTpr_Fuepago = A577OperacionesEstado;
            AV14SDTSolicitudCobrar.gxTpr_Anombre = A657OperacionesNombreRef;
            AV14SDTSolicitudCobrar.gxTpr_Totalcobrar = A570OperacionesImporte;
            AV14SDTSolicitudCobrar.gxTpr_Moneda = A571OperacionesMoneda;
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(1);
      }

      protected void S121( )
      {
         /* 'OBTENER DESCRIPCION' Routine */
         returnInSub = false;
         AV28GXLvl57 = 0;
         /* Using cursor P00DH4 */
         pr_default.execute(2, new Object[] {AV8SolicitudesID});
         while ( (pr_default.getStatus(2) != 101) )
         {
            A121RubrosId = P00DH4_A121RubrosId[0];
            A137MedidasID = P00DH4_A137MedidasID[0];
            A134SolicitudesItemsID = P00DH4_A134SolicitudesItemsID[0];
            A127SolicitudesID = P00DH4_A127SolicitudesID[0];
            A122RubrosNombre = P00DH4_A122RubrosNombre[0];
            A138MedidasNombre = P00DH4_A138MedidasNombre[0];
            A122RubrosNombre = P00DH4_A122RubrosNombre[0];
            A138MedidasNombre = P00DH4_A138MedidasNombre[0];
            AV28GXLvl57 = 1;
            AV14SDTSolicitudCobrar.gxTpr_Descripcion = AV14SDTSolicitudCobrar.gxTpr_Descripcion+StringUtil.Format( " %1 %2,", StringUtil.Trim( A138MedidasNombre), StringUtil.Trim( A122RubrosNombre), "", "", "", "", "", "", "");
            pr_default.readNext(2);
         }
         pr_default.close(2);
         if ( AV28GXLvl57 == 0 )
         {
            AV14SDTSolicitudCobrar.gxTpr_Descripcion = context.GetMessage( "Otros Servicios contratado en www.almango.com.uy", "");
         }
      }

      protected void S131( )
      {
         /* 'GENERAR NUMERO DE ORDEN' Routine */
         returnInSub = false;
         AV18OperacionesId = 0;
         /* Using cursor P00DH5 */
         pr_default.execute(3);
         while ( (pr_default.getStatus(3) != 101) )
         {
            A649OperacionesTipo = P00DH5_A649OperacionesTipo[0];
            n649OperacionesTipo = P00DH5_n649OperacionesTipo[0];
            A555OperacionesRef = P00DH5_A555OperacionesRef[0];
            n555OperacionesRef = P00DH5_n555OperacionesRef[0];
            A572OperacionesFacturaCod = P00DH5_A572OperacionesFacturaCod[0];
            n572OperacionesFacturaCod = P00DH5_n572OperacionesFacturaCod[0];
            A554OperacionesId = P00DH5_A554OperacionesId[0];
            A573OperacionesIva = P00DH5_A573OperacionesIva[0];
            n573OperacionesIva = P00DH5_n573OperacionesIva[0];
            A582OperacionesFechaPago = P00DH5_A582OperacionesFechaPago[0];
            n582OperacionesFechaPago = P00DH5_n582OperacionesFechaPago[0];
            A577OperacionesEstado = P00DH5_A577OperacionesEstado[0];
            n577OperacionesEstado = P00DH5_n577OperacionesEstado[0];
            if ( StringUtil.StrCmp(StringUtil.Trim( A555OperacionesRef), StringUtil.Trim( context.localUtil.Format( (decimal)(AV8SolicitudesID), "ZZZZZZZZZZZZZZZZZ9"))) == 0 )
            {
               A572OperacionesFacturaCod = StringUtil.Trim( AV24OperacionesFacturaCod);
               n572OperacionesFacturaCod = false;
               AV14SDTSolicitudCobrar.gxTpr_Ordennro = A554OperacionesId;
               AV14SDTSolicitudCobrar.gxTpr_Facturanro = StringUtil.Trim( AV24OperacionesFacturaCod);
               AV14SDTSolicitudCobrar.gxTpr_Iva = A573OperacionesIva;
               AV14SDTSolicitudCobrar.gxTpr_Fechacobro = A582OperacionesFechaPago;
               AV20OperacionesEstado = A577OperacionesEstado;
               AV18OperacionesId = A554OperacionesId;
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               /* Using cursor P00DH6 */
               pr_default.execute(4, new Object[] {n572OperacionesFacturaCod, A572OperacionesFacturaCod, A554OperacionesId});
               pr_default.close(4);
               pr_default.SmartCacheProvider.SetUpdated("Operaciones");
               if (true) break;
               /* Using cursor P00DH7 */
               pr_default.execute(5, new Object[] {n572OperacionesFacturaCod, A572OperacionesFacturaCod, A554OperacionesId});
               pr_default.close(5);
               pr_default.SmartCacheProvider.SetUpdated("Operaciones");
            }
            pr_default.readNext(3);
         }
         pr_default.close(3);
         if ( AV18OperacionesId == 0 )
         {
            /* Using cursor P00DH8 */
            pr_default.execute(6);
            while ( (pr_default.getStatus(6) != 101) )
            {
               A554OperacionesId = P00DH8_A554OperacionesId[0];
               AV18OperacionesId = A554OperacionesId;
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               if (true) break;
               pr_default.readNext(6);
            }
            pr_default.close(6);
            if ( AV18OperacionesId == 0 )
            {
               AV18OperacionesId = 1000;
            }
            AV18OperacionesId = (long)(AV18OperacionesId+1);
            /*
               INSERT RECORD ON TABLE Operaciones

            */
            A554OperacionesId = AV18OperacionesId;
            A572OperacionesFacturaCod = StringUtil.Trim( AV24OperacionesFacturaCod);
            n572OperacionesFacturaCod = false;
            A555OperacionesRef = StringUtil.Trim( context.localUtil.Format( (decimal)(AV8SolicitudesID), "ZZZZZZZZZZZZZZZZZ9"));
            n555OperacionesRef = false;
            A657OperacionesNombreRef = AV14SDTSolicitudCobrar.gxTpr_Anombre;
            n657OperacionesNombreRef = false;
            A569OperacionesTipoES = "E";
            n569OperacionesTipoES = false;
            A570OperacionesImporte = AV14SDTSolicitudCobrar.gxTpr_Totalcobrar;
            n570OperacionesImporte = false;
            A571OperacionesMoneda = AV14SDTSolicitudCobrar.gxTpr_Moneda;
            n571OperacionesMoneda = false;
            A578OperacionesImporteGrabado = AV14SDTSolicitudCobrar.gxTpr_Totalcobrar;
            n578OperacionesImporteGrabado = false;
            A573OperacionesIva = AV25OperacionesIva;
            n573OperacionesIva = false;
            A581OperacionesFechaAlta = DateTimeUtil.ResetTime(DateTimeUtil.ServerNow( context, pr_default));
            n581OperacionesFechaAlta = false;
            A649OperacionesTipo = "CSO";
            n649OperacionesTipo = false;
            A577OperacionesEstado = "PND";
            n577OperacionesEstado = false;
            AV14SDTSolicitudCobrar.gxTpr_Ordennro = AV18OperacionesId;
            AV20OperacionesEstado = "PND";
            /* Using cursor P00DH9 */
            pr_default.execute(7, new Object[] {A554OperacionesId, n555OperacionesRef, A555OperacionesRef, n569OperacionesTipoES, A569OperacionesTipoES, n570OperacionesImporte, A570OperacionesImporte, n571OperacionesMoneda, A571OperacionesMoneda, n572OperacionesFacturaCod, A572OperacionesFacturaCod, n573OperacionesIva, A573OperacionesIva, n578OperacionesImporteGrabado, A578OperacionesImporteGrabado, n581OperacionesFechaAlta, A581OperacionesFechaAlta, n577OperacionesEstado, A577OperacionesEstado, n649OperacionesTipo, A649OperacionesTipo, n657OperacionesNombreRef, A657OperacionesNombreRef});
            pr_default.close(7);
            pr_default.SmartCacheProvider.SetUpdated("Operaciones");
            if ( (pr_default.getStatus(7) == 1) )
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
            context.CommitDataStores("generarcobrosolicitud",pr_default);
         }
      }

      protected void GetSolicitudesTotal( long A127SolicitudesID )
      {
         /* Create private dbobjects */
         /* Navigation */
         A174SolicitudesTotal = 0;
         /* Using cursor P00DH10 */
         pr_default.execute(8, new Object[] {A127SolicitudesID});
         while ( (pr_default.getStatus(8) != 101) && ( P00DH10_A127SolicitudesID[0] == A127SolicitudesID ) )
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( P00DH10_A178SolicitudItemsSR[0])) || ( StringUtil.StrCmp(P00DH10_A179SolicitudItemsComisionTipo[0], "N") == 0 ) )
            {
               A175SolicitudesItemsPrecioInstalac = (decimal)((P00DH10_A176SolicitudesItemsPrecioFinal[0]*P00DH10_A177SolicitudesItemsCantidad[0]));
            }
            else
            {
               if ( ( StringUtil.StrCmp(P00DH10_A179SolicitudItemsComisionTipo[0], "F") == 0 ) && ( StringUtil.StrCmp(P00DH10_A178SolicitudItemsSR[0], "R") == 0 ) )
               {
                  A175SolicitudesItemsPrecioInstalac = (decimal)((P00DH10_A176SolicitudesItemsPrecioFinal[0]*P00DH10_A177SolicitudesItemsCantidad[0])-(P00DH10_A180SolicitudItemsComision[0]*P00DH10_A177SolicitudesItemsCantidad[0]));
               }
               else
               {
                  if ( ( StringUtil.StrCmp(P00DH10_A179SolicitudItemsComisionTipo[0], "F") == 0 ) && ( StringUtil.StrCmp(P00DH10_A178SolicitudItemsSR[0], "S") == 0 ) )
                  {
                     A175SolicitudesItemsPrecioInstalac = (decimal)((P00DH10_A176SolicitudesItemsPrecioFinal[0]*P00DH10_A177SolicitudesItemsCantidad[0])+(P00DH10_A180SolicitudItemsComision[0]*P00DH10_A177SolicitudesItemsCantidad[0]));
                  }
                  else
                  {
                     if ( ( StringUtil.StrCmp(P00DH10_A179SolicitudItemsComisionTipo[0], "P") == 0 ) && ( StringUtil.StrCmp(P00DH10_A178SolicitudItemsSR[0], "R") == 0 ) )
                     {
                        A175SolicitudesItemsPrecioInstalac = (decimal)((P00DH10_A176SolicitudesItemsPrecioFinal[0]*P00DH10_A177SolicitudesItemsCantidad[0])-((P00DH10_A176SolicitudesItemsPrecioFinal[0]*P00DH10_A177SolicitudesItemsCantidad[0])*(P00DH10_A180SolicitudItemsComision[0]/ (decimal)(100))));
                     }
                     else
                     {
                        if ( ( StringUtil.StrCmp(P00DH10_A179SolicitudItemsComisionTipo[0], "P") == 0 ) && ( StringUtil.StrCmp(P00DH10_A178SolicitudItemsSR[0], "S") == 0 ) )
                        {
                           A175SolicitudesItemsPrecioInstalac = (decimal)((P00DH10_A176SolicitudesItemsPrecioFinal[0]*P00DH10_A177SolicitudesItemsCantidad[0])+((P00DH10_A176SolicitudesItemsPrecioFinal[0]*P00DH10_A177SolicitudesItemsCantidad[0])*(P00DH10_A180SolicitudItemsComision[0]/ (decimal)(100))));
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
            pr_default.readNext(8);
         }
         pr_default.close(8);
      }

      public override void cleanup( )
      {
         context.CommitDataStores("generarcobrosolicitud",pr_default);
         CloseCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
         ExitApp();
      }

      public override void initialize( )
      {
         P00DH2_A112DepartamentoId = new long[1] ;
         P00DH2_n112DepartamentoId = new bool[] {false} ;
         P00DH2_A669STMonedasId = new short[1] ;
         P00DH2_n669STMonedasId = new bool[] {false} ;
         P00DH2_A127SolicitudesID = new long[1] ;
         P00DH2_A171SolicitudesNombre = new string[] {""} ;
         P00DH2_A116PaisID = new string[] {""} ;
         P00DH2_A671STMonedasISO = new string[] {""} ;
         P00DH2_A796SolicitudesComisionMetodoPago = new decimal[1] ;
         P00DH2_A212SolicitudesCotizacion = new decimal[1] ;
         P00DH2_A1016SolicitudesDescuentoCupon = new decimal[1] ;
         P00DH2_A897SolicitudesDescuento = new decimal[1] ;
         P00DH2_n897SolicitudesDescuento = new bool[] {false} ;
         P00DH2_A864SolicitudesCostoXZona = new decimal[1] ;
         A171SolicitudesNombre = "";
         A116PaisID = "";
         A671STMonedasISO = "";
         AV14SDTSolicitudCobrar = new SdtSDTSolicitudCobrar(context);
         AV20OperacionesEstado = "";
         AV17OrdenPago = "";
         P00DH3_A554OperacionesId = new long[1] ;
         P00DH3_A555OperacionesRef = new string[] {""} ;
         P00DH3_n555OperacionesRef = new bool[] {false} ;
         P00DH3_A572OperacionesFacturaCod = new string[] {""} ;
         P00DH3_n572OperacionesFacturaCod = new bool[] {false} ;
         P00DH3_A582OperacionesFechaPago = new DateTime[] {DateTime.MinValue} ;
         P00DH3_n582OperacionesFechaPago = new bool[] {false} ;
         P00DH3_A577OperacionesEstado = new string[] {""} ;
         P00DH3_n577OperacionesEstado = new bool[] {false} ;
         P00DH3_A657OperacionesNombreRef = new string[] {""} ;
         P00DH3_n657OperacionesNombreRef = new bool[] {false} ;
         P00DH3_A570OperacionesImporte = new decimal[1] ;
         P00DH3_n570OperacionesImporte = new bool[] {false} ;
         P00DH3_A571OperacionesMoneda = new string[] {""} ;
         P00DH3_n571OperacionesMoneda = new bool[] {false} ;
         A555OperacionesRef = "";
         A572OperacionesFacturaCod = "";
         A582OperacionesFechaPago = (DateTime)(DateTime.MinValue);
         A577OperacionesEstado = "";
         A657OperacionesNombreRef = "";
         A571OperacionesMoneda = "";
         P00DH4_A121RubrosId = new short[1] ;
         P00DH4_A137MedidasID = new long[1] ;
         P00DH4_A134SolicitudesItemsID = new short[1] ;
         P00DH4_A127SolicitudesID = new long[1] ;
         P00DH4_A122RubrosNombre = new string[] {""} ;
         P00DH4_A138MedidasNombre = new string[] {""} ;
         A122RubrosNombre = "";
         A138MedidasNombre = "";
         P00DH5_A649OperacionesTipo = new string[] {""} ;
         P00DH5_n649OperacionesTipo = new bool[] {false} ;
         P00DH5_A555OperacionesRef = new string[] {""} ;
         P00DH5_n555OperacionesRef = new bool[] {false} ;
         P00DH5_A572OperacionesFacturaCod = new string[] {""} ;
         P00DH5_n572OperacionesFacturaCod = new bool[] {false} ;
         P00DH5_A554OperacionesId = new long[1] ;
         P00DH5_A573OperacionesIva = new decimal[1] ;
         P00DH5_n573OperacionesIva = new bool[] {false} ;
         P00DH5_A582OperacionesFechaPago = new DateTime[] {DateTime.MinValue} ;
         P00DH5_n582OperacionesFechaPago = new bool[] {false} ;
         P00DH5_A577OperacionesEstado = new string[] {""} ;
         P00DH5_n577OperacionesEstado = new bool[] {false} ;
         A649OperacionesTipo = "";
         P00DH8_A554OperacionesId = new long[1] ;
         A569OperacionesTipoES = "";
         A581OperacionesFechaAlta = DateTime.MinValue;
         Gx_emsg = "";
         P00DH10_A127SolicitudesID = new long[1] ;
         P00DH10_A134SolicitudesItemsID = new short[1] ;
         P00DH10_A180SolicitudItemsComision = new decimal[1] ;
         P00DH10_A179SolicitudItemsComisionTipo = new string[] {""} ;
         P00DH10_A178SolicitudItemsSR = new string[] {""} ;
         P00DH10_A177SolicitudesItemsCantidad = new short[1] ;
         P00DH10_A176SolicitudesItemsPrecioFinal = new decimal[1] ;
         P00DH10_n176SolicitudesItemsPrecioFinal = new bool[] {false} ;
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.generarcobrosolicitud__datastore1(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.generarcobrosolicitud__default(),
            new Object[][] {
                new Object[] {
               P00DH2_A112DepartamentoId, P00DH2_n112DepartamentoId, P00DH2_A669STMonedasId, P00DH2_n669STMonedasId, P00DH2_A127SolicitudesID, P00DH2_A171SolicitudesNombre, P00DH2_A116PaisID, P00DH2_A671STMonedasISO, P00DH2_A796SolicitudesComisionMetodoPago, P00DH2_A212SolicitudesCotizacion,
               P00DH2_A1016SolicitudesDescuentoCupon, P00DH2_A897SolicitudesDescuento, P00DH2_n897SolicitudesDescuento, P00DH2_A864SolicitudesCostoXZona
               }
               , new Object[] {
               P00DH3_A554OperacionesId, P00DH3_A555OperacionesRef, P00DH3_n555OperacionesRef, P00DH3_A572OperacionesFacturaCod, P00DH3_n572OperacionesFacturaCod, P00DH3_A582OperacionesFechaPago, P00DH3_n582OperacionesFechaPago, P00DH3_A577OperacionesEstado, P00DH3_n577OperacionesEstado, P00DH3_A657OperacionesNombreRef,
               P00DH3_n657OperacionesNombreRef, P00DH3_A570OperacionesImporte, P00DH3_n570OperacionesImporte, P00DH3_A571OperacionesMoneda, P00DH3_n571OperacionesMoneda
               }
               , new Object[] {
               P00DH4_A121RubrosId, P00DH4_A137MedidasID, P00DH4_A134SolicitudesItemsID, P00DH4_A127SolicitudesID, P00DH4_A122RubrosNombre, P00DH4_A138MedidasNombre
               }
               , new Object[] {
               P00DH5_A649OperacionesTipo, P00DH5_n649OperacionesTipo, P00DH5_A555OperacionesRef, P00DH5_n555OperacionesRef, P00DH5_A572OperacionesFacturaCod, P00DH5_n572OperacionesFacturaCod, P00DH5_A554OperacionesId, P00DH5_A573OperacionesIva, P00DH5_n573OperacionesIva, P00DH5_A582OperacionesFechaPago,
               P00DH5_n582OperacionesFechaPago, P00DH5_A577OperacionesEstado, P00DH5_n577OperacionesEstado
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               P00DH8_A554OperacionesId
               }
               , new Object[] {
               }
               , new Object[] {
               P00DH10_A127SolicitudesID, P00DH10_A134SolicitudesItemsID, P00DH10_A180SolicitudItemsComision, P00DH10_A179SolicitudItemsComisionTipo, P00DH10_A178SolicitudItemsSR, P00DH10_A177SolicitudesItemsCantidad, P00DH10_A176SolicitudesItemsPrecioFinal, P00DH10_n176SolicitudesItemsPrecioFinal
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short A669STMonedasId ;
      private short AV28GXLvl57 ;
      private short A121RubrosId ;
      private short A134SolicitudesItemsID ;
      private int GX_INS82 ;
      private long AV8SolicitudesID ;
      private long A112DepartamentoId ;
      private long A127SolicitudesID ;
      private long AV18OperacionesId ;
      private long A554OperacionesId ;
      private long A137MedidasID ;
      private decimal A796SolicitudesComisionMetodoPago ;
      private decimal A212SolicitudesCotizacion ;
      private decimal A1016SolicitudesDescuentoCupon ;
      private decimal A897SolicitudesDescuento ;
      private decimal A864SolicitudesCostoXZona ;
      private decimal A211SolicitudServicioPFinal ;
      private decimal A174SolicitudesTotal ;
      private decimal A570OperacionesImporte ;
      private decimal A573OperacionesIva ;
      private decimal A578OperacionesImporteGrabado ;
      private decimal AV25OperacionesIva ;
      private decimal A175SolicitudesItemsPrecioInstalac ;
      private string AV22TipoOpe ;
      private string AV23Identificador ;
      private string AV24OperacionesFacturaCod ;
      private string A171SolicitudesNombre ;
      private string A116PaisID ;
      private string A671STMonedasISO ;
      private string AV20OperacionesEstado ;
      private string A555OperacionesRef ;
      private string A572OperacionesFacturaCod ;
      private string A577OperacionesEstado ;
      private string A657OperacionesNombreRef ;
      private string A571OperacionesMoneda ;
      private string A122RubrosNombre ;
      private string A138MedidasNombre ;
      private string A649OperacionesTipo ;
      private string A569OperacionesTipoES ;
      private string Gx_emsg ;
      private DateTime A582OperacionesFechaPago ;
      private DateTime A581OperacionesFechaAlta ;
      private bool n112DepartamentoId ;
      private bool n669STMonedasId ;
      private bool n897SolicitudesDescuento ;
      private bool returnInSub ;
      private bool n555OperacionesRef ;
      private bool n572OperacionesFacturaCod ;
      private bool n582OperacionesFechaPago ;
      private bool n577OperacionesEstado ;
      private bool n657OperacionesNombreRef ;
      private bool n570OperacionesImporte ;
      private bool n571OperacionesMoneda ;
      private bool n649OperacionesTipo ;
      private bool n573OperacionesIva ;
      private bool n569OperacionesTipoES ;
      private bool n578OperacionesImporteGrabado ;
      private bool n581OperacionesFechaAlta ;
      private string AV17OrdenPago ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private long[] P00DH2_A112DepartamentoId ;
      private bool[] P00DH2_n112DepartamentoId ;
      private short[] P00DH2_A669STMonedasId ;
      private bool[] P00DH2_n669STMonedasId ;
      private long[] P00DH2_A127SolicitudesID ;
      private string[] P00DH2_A171SolicitudesNombre ;
      private string[] P00DH2_A116PaisID ;
      private string[] P00DH2_A671STMonedasISO ;
      private decimal[] P00DH2_A796SolicitudesComisionMetodoPago ;
      private decimal[] P00DH2_A212SolicitudesCotizacion ;
      private decimal[] P00DH2_A1016SolicitudesDescuentoCupon ;
      private decimal[] P00DH2_A897SolicitudesDescuento ;
      private bool[] P00DH2_n897SolicitudesDescuento ;
      private decimal[] P00DH2_A864SolicitudesCostoXZona ;
      private SdtSDTSolicitudCobrar AV14SDTSolicitudCobrar ;
      private long[] P00DH3_A554OperacionesId ;
      private string[] P00DH3_A555OperacionesRef ;
      private bool[] P00DH3_n555OperacionesRef ;
      private string[] P00DH3_A572OperacionesFacturaCod ;
      private bool[] P00DH3_n572OperacionesFacturaCod ;
      private DateTime[] P00DH3_A582OperacionesFechaPago ;
      private bool[] P00DH3_n582OperacionesFechaPago ;
      private string[] P00DH3_A577OperacionesEstado ;
      private bool[] P00DH3_n577OperacionesEstado ;
      private string[] P00DH3_A657OperacionesNombreRef ;
      private bool[] P00DH3_n657OperacionesNombreRef ;
      private decimal[] P00DH3_A570OperacionesImporte ;
      private bool[] P00DH3_n570OperacionesImporte ;
      private string[] P00DH3_A571OperacionesMoneda ;
      private bool[] P00DH3_n571OperacionesMoneda ;
      private short[] P00DH4_A121RubrosId ;
      private long[] P00DH4_A137MedidasID ;
      private short[] P00DH4_A134SolicitudesItemsID ;
      private long[] P00DH4_A127SolicitudesID ;
      private string[] P00DH4_A122RubrosNombre ;
      private string[] P00DH4_A138MedidasNombre ;
      private string[] P00DH5_A649OperacionesTipo ;
      private bool[] P00DH5_n649OperacionesTipo ;
      private string[] P00DH5_A555OperacionesRef ;
      private bool[] P00DH5_n555OperacionesRef ;
      private string[] P00DH5_A572OperacionesFacturaCod ;
      private bool[] P00DH5_n572OperacionesFacturaCod ;
      private long[] P00DH5_A554OperacionesId ;
      private decimal[] P00DH5_A573OperacionesIva ;
      private bool[] P00DH5_n573OperacionesIva ;
      private DateTime[] P00DH5_A582OperacionesFechaPago ;
      private bool[] P00DH5_n582OperacionesFechaPago ;
      private string[] P00DH5_A577OperacionesEstado ;
      private bool[] P00DH5_n577OperacionesEstado ;
      private long[] P00DH8_A554OperacionesId ;
      private long[] P00DH10_A127SolicitudesID ;
      private short[] P00DH10_A134SolicitudesItemsID ;
      private decimal[] P00DH10_A180SolicitudItemsComision ;
      private string[] P00DH10_A179SolicitudItemsComisionTipo ;
      private string[] P00DH10_A178SolicitudItemsSR ;
      private short[] P00DH10_A177SolicitudesItemsCantidad ;
      private decimal[] P00DH10_A176SolicitudesItemsPrecioFinal ;
      private bool[] P00DH10_n176SolicitudesItemsPrecioFinal ;
      private IDataStoreProvider pr_datastore1 ;
   }

   public class generarcobrosolicitud__datastore1 : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          def= new CursorDef[] {
          };
       }
    }

    public void getResults( int cursor ,
                            IFieldGetter rslt ,
                            Object[] buf )
    {
    }

    public override string getDataStoreName( )
    {
       return "DATASTORE1";
    }

 }

 public class generarcobrosolicitud__default : DataStoreHelperBase, IDataStoreHelper
 {
    public ICursor[] getCursors( )
    {
       cursorDefinitions();
       return new Cursor[] {
        new ForEachCursor(def[0])
       ,new ForEachCursor(def[1])
       ,new ForEachCursor(def[2])
       ,new ForEachCursor(def[3])
       ,new UpdateCursor(def[4])
       ,new UpdateCursor(def[5])
       ,new ForEachCursor(def[6])
       ,new UpdateCursor(def[7])
       ,new ForEachCursor(def[8])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmP00DH2;
        prmP00DH2 = new Object[] {
        new ParDef("@AV8SolicitudesID",GXType.Decimal,18,0)
        };
        Object[] prmP00DH3;
        prmP00DH3 = new Object[] {
        new ParDef("@AV18OperacionesId",GXType.Decimal,18,0)
        };
        Object[] prmP00DH4;
        prmP00DH4 = new Object[] {
        new ParDef("@AV8SolicitudesID",GXType.Decimal,18,0)
        };
        Object[] prmP00DH5;
        prmP00DH5 = new Object[] {
        };
        Object[] prmP00DH6;
        prmP00DH6 = new Object[] {
        new ParDef("@OperacionesFacturaCod",GXType.NChar,25,0){Nullable=true} ,
        new ParDef("@OperacionesId",GXType.Decimal,18,0)
        };
        Object[] prmP00DH7;
        prmP00DH7 = new Object[] {
        new ParDef("@OperacionesFacturaCod",GXType.NChar,25,0){Nullable=true} ,
        new ParDef("@OperacionesId",GXType.Decimal,18,0)
        };
        Object[] prmP00DH8;
        prmP00DH8 = new Object[] {
        };
        Object[] prmP00DH9;
        prmP00DH9 = new Object[] {
        new ParDef("@OperacionesId",GXType.Decimal,18,0) ,
        new ParDef("@OperacionesRef",GXType.NChar,25,0){Nullable=true} ,
        new ParDef("@OperacionesTipoES",GXType.NChar,1,0){Nullable=true} ,
        new ParDef("@OperacionesImporte",GXType.Decimal,18,2){Nullable=true} ,
        new ParDef("@OperacionesMoneda",GXType.NChar,3,0){Nullable=true} ,
        new ParDef("@OperacionesFacturaCod",GXType.NChar,25,0){Nullable=true} ,
        new ParDef("@OperacionesIva",GXType.Decimal,4,2){Nullable=true} ,
        new ParDef("@OperacionesImporteGrabado",GXType.Decimal,18,2){Nullable=true} ,
        new ParDef("@OperacionesFechaAlta",GXType.Date,8,0){Nullable=true} ,
        new ParDef("@OperacionesEstado",GXType.NChar,3,0){Nullable=true} ,
        new ParDef("@OperacionesTipo",GXType.NChar,3,0){Nullable=true} ,
        new ParDef("@OperacionesNombreRef",GXType.NChar,120,0){Nullable=true}
        };
        Object[] prmP00DH10;
        prmP00DH10 = new Object[] {
        new ParDef("@SolicitudesID",GXType.Decimal,18,0)
        };
        def= new CursorDef[] {
            new CursorDef("P00DH2", "SELECT TOP 1 T1.[DepartamentoId], T1.[STMonedasId] AS STMonedasId, T1.[SolicitudesID], T1.[SolicitudesNombre], T2.[PaisID], T3.[MonedaISOSimbolo] AS STMonedasISO, T1.[SolicitudesComisionMetodoPago], T1.[SolicitudesCotizacion], T1.[SolicitudesDescuentoCupon], T1.[SolicitudesDescuento], T1.[SolicitudesCostoXZona] FROM (([Solicitudes] T1 LEFT JOIN [Departamento] T2 ON T2.[DepartamentoId] = T1.[DepartamentoId]) LEFT JOIN [Moneda] T3 ON T3.[MonedaId] = T1.[STMonedasId]) WHERE T1.[SolicitudesID] = @AV8SolicitudesID ORDER BY T1.[SolicitudesID] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00DH2,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("P00DH3", "SELECT [OperacionesId], [OperacionesRef], [OperacionesFacturaCod], [OperacionesFechaPago], [OperacionesEstado], [OperacionesNombreRef], [OperacionesImporte], [OperacionesMoneda] FROM [Operaciones] WHERE [OperacionesId] = @AV18OperacionesId ORDER BY [OperacionesId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00DH3,1, GxCacheFrequency.OFF ,false,true )
           ,new CursorDef("P00DH4", "SELECT T1.[RubrosId], T1.[MedidasID], T1.[SolicitudesItemsID], T1.[SolicitudesID], T2.[RubrosNombre], T3.[MedidasNombre] FROM (([SolicitudesItems] T1 INNER JOIN [Rubros] T2 ON T2.[RubrosId] = T1.[RubrosId]) INNER JOIN [RubrosMedidas] T3 ON T3.[RubrosId] = T1.[RubrosId] AND T3.[MedidasID] = T1.[MedidasID]) WHERE T1.[SolicitudesID] = @AV8SolicitudesID and T1.[SolicitudesItemsID] > 0 ORDER BY T1.[SolicitudesID] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00DH4,100, GxCacheFrequency.OFF ,false,false )
           ,new CursorDef("P00DH5", "SELECT [OperacionesTipo], [OperacionesRef], [OperacionesFacturaCod], [OperacionesId], [OperacionesIva], [OperacionesFechaPago], [OperacionesEstado] FROM [Operaciones] WITH (UPDLOCK) WHERE [OperacionesTipo] = 'CSO' ORDER BY [OperacionesRef] DESC ",true, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00DH5,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("P00DH6", "UPDATE [Operaciones] SET [OperacionesFacturaCod]=@OperacionesFacturaCod  WHERE [OperacionesId] = @OperacionesId", GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP00DH6)
           ,new CursorDef("P00DH7", "UPDATE [Operaciones] SET [OperacionesFacturaCod]=@OperacionesFacturaCod  WHERE [OperacionesId] = @OperacionesId", GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP00DH7)
           ,new CursorDef("P00DH8", "SELECT TOP 1 [OperacionesId] FROM [Operaciones] ORDER BY [OperacionesId] DESC ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00DH8,1, GxCacheFrequency.OFF ,false,true )
           ,new CursorDef("P00DH9", "INSERT INTO [Operaciones]([OperacionesId], [OperacionesRef], [OperacionesTipoES], [OperacionesImporte], [OperacionesMoneda], [OperacionesFacturaCod], [OperacionesIva], [OperacionesImporteGrabado], [OperacionesFechaAlta], [OperacionesEstado], [OperacionesTipo], [OperacionesNombreRef], [OperacionesOrdinal], [OperacionesIDORD], [OperacionesComision], [OperacionesRequest], [OperacionesResponse], [OperacionesComprobantePago], [OperacionesFechaPago], [OperacionesAux1], [OperacionesAux2], [OperacionesAux3], [OperacionesFechaDesde], [OperacionesFechaHasta], [OperacionesMonId], [OperacionesBlob1], [OperacionesBlob2], [OperacionesUsrAlta], [OperacionesUsrActualizacion], [OperacionesComercioId1], [OperacionesComercioId2], [OperacionesPeriodoCod]) VALUES(@OperacionesId, @OperacionesRef, @OperacionesTipoES, @OperacionesImporte, @OperacionesMoneda, @OperacionesFacturaCod, @OperacionesIva, @OperacionesImporteGrabado, @OperacionesFechaAlta, @OperacionesEstado, @OperacionesTipo, @OperacionesNombreRef, convert(int, 0), '', convert(int, 0), '', '', '', convert( DATETIME, '17530101', 112 ), '', '', '', convert( DATETIME, '17530101', 112 ), convert( DATETIME, '17530101', 112 ), convert(int, 0), CONVERT(varbinary(1), ''), CONVERT(varbinary(1), ''), convert(int, 0), convert(int, 0), convert(int, 0), convert(int, 0), '')", GxErrorMask.GX_NOMASK,prmP00DH9)
           ,new CursorDef("P00DH10", "SELECT [SolicitudesID], [SolicitudesItemsID], [SolicitudItemsComision], [SolicitudItemsComisionTipo], [SolicitudItemsSR], [SolicitudesItemsCantidad], [SolicitudesItemsPrecioFinal] FROM [SolicitudesItems] WHERE [SolicitudesID] = @SolicitudesID ORDER BY [SolicitudesID] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00DH10,100, GxCacheFrequency.OFF ,true,false )
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
              ((short[]) buf[2])[0] = rslt.getShort(2);
              ((bool[]) buf[3])[0] = rslt.wasNull(2);
              ((long[]) buf[4])[0] = rslt.getLong(3);
              ((string[]) buf[5])[0] = rslt.getString(4, 100);
              ((string[]) buf[6])[0] = rslt.getString(5, 2);
              ((string[]) buf[7])[0] = rslt.getString(6, 3);
              ((decimal[]) buf[8])[0] = rslt.getDecimal(7);
              ((decimal[]) buf[9])[0] = rslt.getDecimal(8);
              ((decimal[]) buf[10])[0] = rslt.getDecimal(9);
              ((decimal[]) buf[11])[0] = rslt.getDecimal(10);
              ((bool[]) buf[12])[0] = rslt.wasNull(10);
              ((decimal[]) buf[13])[0] = rslt.getDecimal(11);
              return;
           case 1 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 25);
              ((bool[]) buf[2])[0] = rslt.wasNull(2);
              ((string[]) buf[3])[0] = rslt.getString(3, 25);
              ((bool[]) buf[4])[0] = rslt.wasNull(3);
              ((DateTime[]) buf[5])[0] = rslt.getGXDateTime(4);
              ((bool[]) buf[6])[0] = rslt.wasNull(4);
              ((string[]) buf[7])[0] = rslt.getString(5, 3);
              ((bool[]) buf[8])[0] = rslt.wasNull(5);
              ((string[]) buf[9])[0] = rslt.getString(6, 120);
              ((bool[]) buf[10])[0] = rslt.wasNull(6);
              ((decimal[]) buf[11])[0] = rslt.getDecimal(7);
              ((bool[]) buf[12])[0] = rslt.wasNull(7);
              ((string[]) buf[13])[0] = rslt.getString(8, 3);
              ((bool[]) buf[14])[0] = rslt.wasNull(8);
              return;
           case 2 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              ((short[]) buf[2])[0] = rslt.getShort(3);
              ((long[]) buf[3])[0] = rslt.getLong(4);
              ((string[]) buf[4])[0] = rslt.getString(5, 100);
              ((string[]) buf[5])[0] = rslt.getString(6, 50);
              return;
           case 3 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              ((bool[]) buf[1])[0] = rslt.wasNull(1);
              ((string[]) buf[2])[0] = rslt.getString(2, 25);
              ((bool[]) buf[3])[0] = rslt.wasNull(2);
              ((string[]) buf[4])[0] = rslt.getString(3, 25);
              ((bool[]) buf[5])[0] = rslt.wasNull(3);
              ((long[]) buf[6])[0] = rslt.getLong(4);
              ((decimal[]) buf[7])[0] = rslt.getDecimal(5);
              ((bool[]) buf[8])[0] = rslt.wasNull(5);
              ((DateTime[]) buf[9])[0] = rslt.getGXDateTime(6);
              ((bool[]) buf[10])[0] = rslt.wasNull(6);
              ((string[]) buf[11])[0] = rslt.getString(7, 3);
              ((bool[]) buf[12])[0] = rslt.wasNull(7);
              return;
           case 6 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 8 :
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

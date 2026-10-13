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
namespace GeneXus.Programs.apis.comerciosapi.v1 {
   public class approcesarsolicitudesexternas : GXProcedure
   {
      public static int Main( string[] args )
      {
         return new apis.comerciosapi.v1.approcesarsolicitudesexternas().MainImpl(args); ;
      }

      public int executeCmdLine( string[] args )
      {
         return ExecuteCmdLine(args); ;
      }

      protected override int ExecuteCmdLine( string[] args )
      {
         execute();
         return GX.GXRuntime.ExitCode ;
      }

      public approcesarsolicitudesexternas( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public approcesarsolicitudesexternas( IGxContext context )
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
         /* Using cursor P00MU2 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            GXTMU2 = 0;
            A649OperacionesTipo = P00MU2_A649OperacionesTipo[0];
            n649OperacionesTipo = P00MU2_n649OperacionesTipo[0];
            A577OperacionesEstado = P00MU2_A577OperacionesEstado[0];
            n577OperacionesEstado = P00MU2_n577OperacionesEstado[0];
            A575OperacionesRequest = P00MU2_A575OperacionesRequest[0];
            n575OperacionesRequest = P00MU2_n575OperacionesRequest[0];
            A963OperacionesComercioId2 = P00MU2_A963OperacionesComercioId2[0];
            n963OperacionesComercioId2 = P00MU2_n963OperacionesComercioId2[0];
            A962OperacionesComercioId1 = P00MU2_A962OperacionesComercioId1[0];
            n962OperacionesComercioId1 = P00MU2_n962OperacionesComercioId1[0];
            A583OperacionesAux1 = P00MU2_A583OperacionesAux1[0];
            n583OperacionesAux1 = P00MU2_n583OperacionesAux1[0];
            A554OperacionesId = P00MU2_A554OperacionesId[0];
            AV8EntradaSDT = new GeneXus.Programs.apis.comerciosapi.v1.SdtSDT_NuevaSolicitudExterna(context);
            AV8EntradaSDT.FromJSonString(A575OperacionesRequest, null);
            AV11OpeConError = false;
            AV14OpeMensajeError = "";
            AV40SolicitudIdPrincipal = 0;
            AV8EntradaSDT.gxTpr_Servicios.Sort("CodigoServicioAlmango");
            AV43GXV1 = 1;
            while ( AV43GXV1 <= AV8EntradaSDT.gxTpr_Servicios.Count )
            {
               AV10Item = ((GeneXus.Programs.apis.comerciosapi.v1.SdtSDT_NuevaSolicitudExterna_Item)AV8EntradaSDT.gxTpr_Servicios.Item(AV43GXV1));
               if ( StringUtil.StartsWith( StringUtil.Lower( StringUtil.Trim( AV10Item.gxTpr_Codigoservicioalmango)), context.GetMessage( "amg", "")) )
               {
                  new resolverproductodesdesku(context ).execute(  A963OperacionesComercioId2,  A962OperacionesComercioId1,  AV10Item.gxTpr_Codigoservicioalmango, out  AV15RubrosId, out  AV16MedidasId, out  AV17InventarioId, out  AV18ErrorLinea, ref  AV19DebugLog) ;
                  if ( AV18ErrorLinea )
                  {
                     AV11OpeConError = true;
                     AV14OpeMensajeError = context.GetMessage( "Error al resolver el SKU: ", "") + AV10Item.gxTpr_Codigoservicioalmango;
                     if (true) break;
                  }
                  AV31InventarioEsPresupuestado = false;
                  AV29InventarioSKURelacionado = "";
                  /* Using cursor P00MU3 */
                  pr_default.execute(1, new Object[] {AV15RubrosId, AV16MedidasId, AV17InventarioId});
                  while ( (pr_default.getStatus(1) != 101) )
                  {
                     A135InventarioId = P00MU3_A135InventarioId[0];
                     A137MedidasID = P00MU3_A137MedidasID[0];
                     A121RubrosId = P00MU3_A121RubrosId[0];
                     A1005InventarioEsPresupuestado = P00MU3_A1005InventarioEsPresupuestado[0];
                     n1005InventarioEsPresupuestado = P00MU3_n1005InventarioEsPresupuestado[0];
                     A1004InventarioSKURelacionado = P00MU3_A1004InventarioSKURelacionado[0];
                     n1004InventarioSKURelacionado = P00MU3_n1004InventarioSKURelacionado[0];
                     AV31InventarioEsPresupuestado = A1005InventarioEsPresupuestado;
                     AV29InventarioSKURelacionado = A1004InventarioSKURelacionado;
                     /* Exiting from a For First loop. */
                     if (true) break;
                  }
                  pr_default.close(1);
                  if ( AV31InventarioEsPresupuestado )
                  {
                     /* Execute user subroutine: 'PROCESARSERVICIOPRESUPUESTADO' */
                     S121 ();
                     if ( returnInSub )
                     {
                        pr_default.close(0);
                        cleanup();
                        if (true) return;
                     }
                  }
                  else
                  {
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( StringUtil.Trim( AV29InventarioSKURelacionado))) )
                     {
                        /* Execute user subroutine: 'PROCESARVISITATECNICA' */
                        S131 ();
                        if ( returnInSub )
                        {
                           pr_default.close(0);
                           cleanup();
                           if (true) return;
                        }
                     }
                     else
                     {
                        /* Execute user subroutine: 'PROCESARSERVICIOESTANDAR' */
                        S141 ();
                        if ( returnInSub )
                        {
                           pr_default.close(0);
                           cleanup();
                           if (true) return;
                        }
                     }
                  }
                  if ( AV11OpeConError )
                  {
                     if (true) break;
                  }
               }
               else
               {
                  AV11OpeConError = true;
                  AV14OpeMensajeError = context.GetMessage( "Código inválido encontrado en Worker: ", "") + AV10Item.gxTpr_Codigoservicioalmango;
                  if (true) break;
               }
               AV43GXV1 = (int)(AV43GXV1+1);
            }
            if ( AV39SolicitudBCEstandarCreada && ! AV11OpeConError )
            {
               AV38SolicitudBCEstandar.Save();
               if ( ! AV38SolicitudBCEstandar.Success() )
               {
                  AV11OpeConError = true;
                  AV14OpeMensajeError = context.GetMessage( "Error: ", "") + AV38SolicitudBCEstandar.GetMessages().ToJSonString(false);
               }
               else
               {
                  new GeneXus.Programs.apis.comerciosapi.v1.penviarcorreogenerico(context ).execute(  AV38SolicitudBCEstandar.gxTpr_Solicitudesid,  StringUtil.Trim( AV8EntradaSDT.gxTpr_Cliente.gxTpr_Nombre),  StringUtil.Trim( AV8EntradaSDT.gxTpr_Cliente.gxTpr_Email),  "", out  AV22CorreoOk, out  AV21ErrorDescription) ;
                  if ( AV40SolicitudIdPrincipal == 0 )
                  {
                     AV40SolicitudIdPrincipal = AV38SolicitudBCEstandar.gxTpr_Solicitudesid;
                  }
               }
            }
            if ( ! AV11OpeConError )
            {
               A577OperacionesEstado = "PRO";
               n577OperacionesEstado = false;
               A583OperacionesAux1 = StringUtil.Str( (decimal)(AV40SolicitudIdPrincipal), 18, 0);
               n583OperacionesAux1 = false;
               GXTMU2 = 1;
            }
            else
            {
               GXTMU2 = 2;
               A577OperacionesEstado = "ANU";
               n577OperacionesEstado = false;
               A583OperacionesAux1 = AV14OpeMensajeError;
               n583OperacionesAux1 = false;
               GXTMU2 = 1;
            }
            /* Using cursor P00MU4 */
            pr_default.execute(2, new Object[] {n577OperacionesEstado, A577OperacionesEstado, n583OperacionesAux1, A583OperacionesAux1, A554OperacionesId});
            pr_default.close(2);
            pr_default.SmartCacheProvider.SetUpdated("Operaciones");
            if ( GXTMU2 == 1 )
            {
               context.CommitDataStores("apis.comerciosapi.v1.pprocesarsolicitudesexternas",pr_default);
            }
            if ( GXTMU2 == 2 )
            {
               context.RollbackDataStores("apis.comerciosapi.v1.pprocesarsolicitudesexternas",pr_default);
            }
            pr_default.readNext(0);
         }
         pr_default.close(0);
         cleanup();
      }

      protected void S111( )
      {
         /* 'CONFIGURARCABECERASOLICITUDBASE' Routine */
         returnInSub = false;
         AV23PostulacionBC = new SdtPostulaciones(context);
         AV23PostulacionBC.gxTpr_Postulacionesestado = "DES";
         AV23PostulacionBC.gxTpr_Postulacionesfechaalta = DateTimeUtil.ServerNow( context, pr_default);
         AV23PostulacionBC.gxTpr_Postulacionesproveedorid = A962OperacionesComercioId1;
         AV23PostulacionBC.gxTv_SdtPostulaciones_Serviciosid_SetNull();
         AV23PostulacionBC.Save();
         AV9SolicitudBC = new SdtSolicitudes(context);
         AV9SolicitudBC.gxTpr_Postulacionesid = AV23PostulacionBC.gxTpr_Postulacionesid;
         AV9SolicitudBC.gxTpr_Estadossolid = 1;
         AV9SolicitudBC.gxTpr_Estadossoltipo = context.GetMessage( "SOL", "");
         AV9SolicitudBC.gxTpr_Solicitudessubtipo = "Z";
         AV9SolicitudBC.gxTpr_Solicitudservicioorigenpago = "T";
         AV9SolicitudBC.gxTpr_Metodopagosid = 2;
         AV9SolicitudBC.gxTpr_Solicitudescalcomi = true;
         AV9SolicitudBC.gxTv_SdtSolicitudes_Zonasid_SetNull();
         AV9SolicitudBC.gxTpr_Solicitudesfechaalta = DateTimeUtil.ServerNow( context, pr_default);
         AV9SolicitudBC.gxTpr_Proveedorid = A962OperacionesComercioId1;
         AV9SolicitudBC.gxTpr_Stcomerciosid = A963OperacionesComercioId2;
         AV9SolicitudBC.gxTpr_Solicitudesotros2 = StringUtil.Trim( AV8EntradaSDT.gxTpr_Comercioticketid);
         AV9SolicitudBC.gxTpr_Solicitudesnombre = StringUtil.Trim( AV8EntradaSDT.gxTpr_Cliente.gxTpr_Nombre);
         AV25RegexEmail = context.GetMessage( "^((\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*)|(\\s*))$", "");
         if ( GxRegex.IsMatch(StringUtil.Trim( AV8EntradaSDT.gxTpr_Cliente.gxTpr_Email),AV25RegexEmail) )
         {
            AV9SolicitudBC.gxTpr_Solicitudesmail = StringUtil.Trim( AV8EntradaSDT.gxTpr_Cliente.gxTpr_Email);
         }
         else
         {
            AV9SolicitudBC.gxTpr_Solicitudesmail = "";
         }
         AV9SolicitudBC.gxTpr_Solicitudestelefono = StringUtil.Trim( AV8EntradaSDT.gxTpr_Cliente.gxTpr_Telefono);
         AV24DireccionFormateada = StringUtil.Trim( AV8EntradaSDT.gxTpr_Cliente.gxTpr_Direccion.gxTpr_Calleynumero);
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV8EntradaSDT.gxTpr_Cliente.gxTpr_Direccion.gxTpr_Departamento)) )
         {
            AV24DireccionFormateada += ", " + StringUtil.Trim( AV8EntradaSDT.gxTpr_Cliente.gxTpr_Direccion.gxTpr_Departamento);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV8EntradaSDT.gxTpr_Cliente.gxTpr_Direccion.gxTpr_Municipio)) )
         {
            AV24DireccionFormateada += ", " + StringUtil.Trim( AV8EntradaSDT.gxTpr_Cliente.gxTpr_Direccion.gxTpr_Municipio);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV8EntradaSDT.gxTpr_Cliente.gxTpr_Direccion.gxTpr_Codigopais)) )
         {
            AV24DireccionFormateada += ", " + StringUtil.Trim( AV8EntradaSDT.gxTpr_Cliente.gxTpr_Direccion.gxTpr_Codigopais);
         }
         AV9SolicitudBC.gxTpr_Solicitudesdireccion = AV24DireccionFormateada;
         AV9SolicitudBC.gxTpr_Solicitudescomentario = StringUtil.Trim( AV8EntradaSDT.gxTpr_Notasadicionales);
         new obtenermonedaidporiso(context ).execute(  AV8EntradaSDT.gxTpr_Moneda, out  AV12MonedaId, out  AV13ExisteMoneda) ;
         if ( AV13ExisteMoneda )
         {
            AV9SolicitudBC.gxTpr_Stmonedasid = AV12MonedaId;
         }
      }

      protected void S121( )
      {
         /* 'PROCESARSERVICIOPRESUPUESTADO' Routine */
         returnInSub = false;
         /* Execute user subroutine: 'CONFIGURARCABECERASOLICITUDBASE' */
         S111 ();
         if (returnInSub) return;
         if ( AV10Item.gxTpr_Solicitudidref > 0 )
         {
            AV37SKUInstalacionRelacionado = "";
            /* Using cursor P00MU5 */
            pr_default.execute(3, new Object[] {AV10Item.gxTpr_Solicitudidref});
            while ( (pr_default.getStatus(3) != 101) )
            {
               A121RubrosId = P00MU5_A121RubrosId[0];
               A137MedidasID = P00MU5_A137MedidasID[0];
               A135InventarioId = P00MU5_A135InventarioId[0];
               A127SolicitudesID = P00MU5_A127SolicitudesID[0];
               A1004InventarioSKURelacionado = P00MU5_A1004InventarioSKURelacionado[0];
               n1004InventarioSKURelacionado = P00MU5_n1004InventarioSKURelacionado[0];
               A134SolicitudesItemsID = P00MU5_A134SolicitudesItemsID[0];
               A1004InventarioSKURelacionado = P00MU5_A1004InventarioSKURelacionado[0];
               n1004InventarioSKURelacionado = P00MU5_n1004InventarioSKURelacionado[0];
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( StringUtil.Trim( A1004InventarioSKURelacionado))) )
               {
                  AV37SKUInstalacionRelacionado = A1004InventarioSKURelacionado;
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
               pr_default.readNext(3);
            }
            pr_default.close(3);
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( StringUtil.Trim( AV37SKUInstalacionRelacionado))) )
            {
               new resolverproductodesdesku(context ).execute(  A963OperacionesComercioId2,  A962OperacionesComercioId1,  AV37SKUInstalacionRelacionado, out  AV35RubrosIdInstalacion, out  AV34MedidasIdInstalacion, out  AV32InventarioIdInstalacion, out  AV30ErrorLineaInst, ref  AV19DebugLog) ;
               if ( ! AV30ErrorLineaInst )
               {
                  AV15RubrosId = AV35RubrosIdInstalacion;
                  AV16MedidasId = AV34MedidasIdInstalacion;
                  AV17InventarioId = AV32InventarioIdInstalacion;
               }
            }
         }
         AV28MontoSinIVA = (decimal)(AV10Item.gxTpr_Montoabonado/ (decimal)(1.22m));
         AV9SolicitudBC.gxTpr_Solicitudescotizacion = (decimal)(AV28MontoSinIVA/ (decimal)(1.15m));
         AV20ItemBC = new SdtSolicitudes_Items(context);
         AV20ItemBC.gxTpr_Rubrosid = AV15RubrosId;
         AV20ItemBC.gxTpr_Medidasid = AV16MedidasId;
         AV20ItemBC.gxTpr_Inventarioid = AV17InventarioId;
         AV20ItemBC.gxTpr_Solicitudesitemscantidad = AV10Item.gxTpr_Cantidad;
         AV9SolicitudBC.gxTpr_Items.Add(AV20ItemBC, 0);
         AV9SolicitudBC.Save();
         if ( ! AV9SolicitudBC.Success() )
         {
            AV11OpeConError = true;
            AV14OpeMensajeError = context.GetMessage( "Error al guardar Solicitud Presupuestada: ", "") + AV9SolicitudBC.GetMessages().ToJSonString(false);
         }
         else
         {
            new GeneXus.Programs.apis.comerciosapi.v1.penviarcorreogenerico(context ).execute(  AV9SolicitudBC.gxTpr_Solicitudesid,  StringUtil.Trim( AV8EntradaSDT.gxTpr_Cliente.gxTpr_Nombre),  StringUtil.Trim( AV8EntradaSDT.gxTpr_Cliente.gxTpr_Email),  "", out  AV22CorreoOk, out  AV21ErrorDescription) ;
            if ( AV40SolicitudIdPrincipal == 0 )
            {
               AV40SolicitudIdPrincipal = AV9SolicitudBC.gxTpr_Solicitudesid;
            }
         }
      }

      protected void S131( )
      {
         /* 'PROCESARVISITATECNICA' Routine */
         returnInSub = false;
         /* Execute user subroutine: 'CONFIGURARCABECERASOLICITUDBASE' */
         S111 ();
         if (returnInSub) return;
         AV20ItemBC = new SdtSolicitudes_Items(context);
         AV20ItemBC.gxTpr_Rubrosid = AV15RubrosId;
         AV20ItemBC.gxTpr_Medidasid = AV16MedidasId;
         AV20ItemBC.gxTpr_Inventarioid = AV17InventarioId;
         AV20ItemBC.gxTpr_Solicitudesitemscantidad = AV10Item.gxTpr_Cantidad;
         AV9SolicitudBC.gxTpr_Items.Add(AV20ItemBC, 0);
         AV9SolicitudBC.Save();
         if ( ! AV9SolicitudBC.Success() )
         {
            AV11OpeConError = true;
            AV14OpeMensajeError = context.GetMessage( "Error al guardar Solicitud de Visita Técnica: ", "") + AV9SolicitudBC.GetMessages().ToJSonString(false);
         }
         else
         {
            new GeneXus.Programs.apis.comerciosapi.v1.penviarcorreogenerico(context ).execute(  AV9SolicitudBC.gxTpr_Solicitudesid,  StringUtil.Trim( AV8EntradaSDT.gxTpr_Cliente.gxTpr_Nombre),  StringUtil.Trim( AV8EntradaSDT.gxTpr_Cliente.gxTpr_Email),  "", out  AV22CorreoOk, out  AV21ErrorDescription) ;
            if ( AV40SolicitudIdPrincipal == 0 )
            {
               AV40SolicitudIdPrincipal = AV9SolicitudBC.gxTpr_Solicitudesid;
            }
         }
      }

      protected void S141( )
      {
         /* 'PROCESARSERVICIOESTANDAR' Routine */
         returnInSub = false;
         if ( ( AV41RubrosIdActualEstandar == AV15RubrosId ) && AV39SolicitudBCEstandarCreada )
         {
            AV20ItemBC = new SdtSolicitudes_Items(context);
            AV20ItemBC.gxTpr_Rubrosid = AV15RubrosId;
            AV20ItemBC.gxTpr_Medidasid = AV16MedidasId;
            AV20ItemBC.gxTpr_Inventarioid = AV17InventarioId;
            AV20ItemBC.gxTpr_Solicitudesitemscantidad = AV10Item.gxTpr_Cantidad;
            AV38SolicitudBCEstandar.gxTpr_Items.Add(AV20ItemBC, 0);
         }
         else
         {
            if ( AV39SolicitudBCEstandarCreada )
            {
               AV38SolicitudBCEstandar.Save();
               if ( ! AV38SolicitudBCEstandar.Success() )
               {
                  AV11OpeConError = true;
                  AV14OpeMensajeError = context.GetMessage( "Error al guardar Solicitud Estándar: ", "") + AV38SolicitudBCEstandar.GetMessages().ToJSonString(false);
                  returnInSub = true;
                  if (true) return;
               }
               else
               {
                  new GeneXus.Programs.apis.comerciosapi.v1.penviarcorreogenerico(context ).execute(  AV38SolicitudBCEstandar.gxTpr_Solicitudesid,  StringUtil.Trim( AV8EntradaSDT.gxTpr_Cliente.gxTpr_Nombre),  StringUtil.Trim( AV8EntradaSDT.gxTpr_Cliente.gxTpr_Email),  "", out  AV22CorreoOk, out  AV21ErrorDescription) ;
               }
            }
            /* Execute user subroutine: 'CONFIGURARCABECERASOLICITUDBASE' */
            S111 ();
            if (returnInSub) return;
            AV38SolicitudBCEstandar = (SdtSolicitudes)(AV9SolicitudBC.Clone());
            AV41RubrosIdActualEstandar = AV15RubrosId;
            AV39SolicitudBCEstandarCreada = true;
            AV20ItemBC = new SdtSolicitudes_Items(context);
            AV20ItemBC.gxTpr_Rubrosid = AV15RubrosId;
            AV20ItemBC.gxTpr_Medidasid = AV16MedidasId;
            AV20ItemBC.gxTpr_Inventarioid = AV17InventarioId;
            AV20ItemBC.gxTpr_Solicitudesitemscantidad = AV10Item.gxTpr_Cantidad;
            AV38SolicitudBCEstandar.gxTpr_Items.Add(AV20ItemBC, 0);
         }
      }

      public override void cleanup( )
      {
         context.CommitDataStores("apis.comerciosapi.v1.pprocesarsolicitudesexternas",pr_default);
         CloseCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
         ExitApp();
      }

      public override void initialize( )
      {
         P00MU2_A649OperacionesTipo = new string[] {""} ;
         P00MU2_n649OperacionesTipo = new bool[] {false} ;
         P00MU2_A577OperacionesEstado = new string[] {""} ;
         P00MU2_n577OperacionesEstado = new bool[] {false} ;
         P00MU2_A575OperacionesRequest = new string[] {""} ;
         P00MU2_n575OperacionesRequest = new bool[] {false} ;
         P00MU2_A963OperacionesComercioId2 = new long[1] ;
         P00MU2_n963OperacionesComercioId2 = new bool[] {false} ;
         P00MU2_A962OperacionesComercioId1 = new long[1] ;
         P00MU2_n962OperacionesComercioId1 = new bool[] {false} ;
         P00MU2_A583OperacionesAux1 = new string[] {""} ;
         P00MU2_n583OperacionesAux1 = new bool[] {false} ;
         P00MU2_A554OperacionesId = new long[1] ;
         A649OperacionesTipo = "";
         A577OperacionesEstado = "";
         A575OperacionesRequest = "";
         A583OperacionesAux1 = "";
         AV8EntradaSDT = new GeneXus.Programs.apis.comerciosapi.v1.SdtSDT_NuevaSolicitudExterna(context);
         AV14OpeMensajeError = "";
         AV10Item = new GeneXus.Programs.apis.comerciosapi.v1.SdtSDT_NuevaSolicitudExterna_Item(context);
         AV19DebugLog = "";
         AV29InventarioSKURelacionado = "";
         P00MU3_A135InventarioId = new long[1] ;
         P00MU3_A137MedidasID = new long[1] ;
         P00MU3_A121RubrosId = new short[1] ;
         P00MU3_A1005InventarioEsPresupuestado = new bool[] {false} ;
         P00MU3_n1005InventarioEsPresupuestado = new bool[] {false} ;
         P00MU3_A1004InventarioSKURelacionado = new string[] {""} ;
         P00MU3_n1004InventarioSKURelacionado = new bool[] {false} ;
         A1004InventarioSKURelacionado = "";
         AV38SolicitudBCEstandar = new SdtSolicitudes(context);
         AV22CorreoOk = "";
         AV21ErrorDescription = "";
         AV23PostulacionBC = new SdtPostulaciones(context);
         AV9SolicitudBC = new SdtSolicitudes(context);
         AV25RegexEmail = "";
         AV24DireccionFormateada = "";
         AV37SKUInstalacionRelacionado = "";
         P00MU5_A121RubrosId = new short[1] ;
         P00MU5_A137MedidasID = new long[1] ;
         P00MU5_A135InventarioId = new long[1] ;
         P00MU5_A127SolicitudesID = new long[1] ;
         P00MU5_A1004InventarioSKURelacionado = new string[] {""} ;
         P00MU5_n1004InventarioSKURelacionado = new bool[] {false} ;
         P00MU5_A134SolicitudesItemsID = new short[1] ;
         AV20ItemBC = new SdtSolicitudes_Items(context);
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.apis.comerciosapi.v1.approcesarsolicitudesexternas__datastore1(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.apis.comerciosapi.v1.approcesarsolicitudesexternas__default(),
            new Object[][] {
                new Object[] {
               P00MU2_A649OperacionesTipo, P00MU2_n649OperacionesTipo, P00MU2_A577OperacionesEstado, P00MU2_n577OperacionesEstado, P00MU2_A575OperacionesRequest, P00MU2_n575OperacionesRequest, P00MU2_A963OperacionesComercioId2, P00MU2_n963OperacionesComercioId2, P00MU2_A962OperacionesComercioId1, P00MU2_n962OperacionesComercioId1,
               P00MU2_A583OperacionesAux1, P00MU2_n583OperacionesAux1, P00MU2_A554OperacionesId
               }
               , new Object[] {
               P00MU3_A135InventarioId, P00MU3_A137MedidasID, P00MU3_A121RubrosId, P00MU3_A1005InventarioEsPresupuestado, P00MU3_n1005InventarioEsPresupuestado, P00MU3_A1004InventarioSKURelacionado, P00MU3_n1004InventarioSKURelacionado
               }
               , new Object[] {
               }
               , new Object[] {
               P00MU5_A121RubrosId, P00MU5_A137MedidasID, P00MU5_A135InventarioId, P00MU5_A127SolicitudesID, P00MU5_A1004InventarioSKURelacionado, P00MU5_n1004InventarioSKURelacionado, P00MU5_A134SolicitudesItemsID
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short GXTMU2 ;
      private short AV15RubrosId ;
      private short A121RubrosId ;
      private short AV12MonedaId ;
      private short A134SolicitudesItemsID ;
      private short AV35RubrosIdInstalacion ;
      private short AV41RubrosIdActualEstandar ;
      private int AV43GXV1 ;
      private long A963OperacionesComercioId2 ;
      private long A962OperacionesComercioId1 ;
      private long A554OperacionesId ;
      private long AV40SolicitudIdPrincipal ;
      private long AV16MedidasId ;
      private long AV17InventarioId ;
      private long A135InventarioId ;
      private long A137MedidasID ;
      private long A127SolicitudesID ;
      private long AV34MedidasIdInstalacion ;
      private long AV32InventarioIdInstalacion ;
      private decimal AV28MontoSinIVA ;
      private string A649OperacionesTipo ;
      private string A577OperacionesEstado ;
      private string AV22CorreoOk ;
      private bool n649OperacionesTipo ;
      private bool n577OperacionesEstado ;
      private bool n575OperacionesRequest ;
      private bool n963OperacionesComercioId2 ;
      private bool n962OperacionesComercioId1 ;
      private bool n583OperacionesAux1 ;
      private bool AV11OpeConError ;
      private bool AV18ErrorLinea ;
      private bool AV31InventarioEsPresupuestado ;
      private bool A1005InventarioEsPresupuestado ;
      private bool n1005InventarioEsPresupuestado ;
      private bool n1004InventarioSKURelacionado ;
      private bool returnInSub ;
      private bool AV39SolicitudBCEstandarCreada ;
      private bool AV13ExisteMoneda ;
      private bool AV30ErrorLineaInst ;
      private string A575OperacionesRequest ;
      private string A583OperacionesAux1 ;
      private string AV14OpeMensajeError ;
      private string AV19DebugLog ;
      private string AV29InventarioSKURelacionado ;
      private string A1004InventarioSKURelacionado ;
      private string AV21ErrorDescription ;
      private string AV25RegexEmail ;
      private string AV24DireccionFormateada ;
      private string AV37SKUInstalacionRelacionado ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] P00MU2_A649OperacionesTipo ;
      private bool[] P00MU2_n649OperacionesTipo ;
      private string[] P00MU2_A577OperacionesEstado ;
      private bool[] P00MU2_n577OperacionesEstado ;
      private string[] P00MU2_A575OperacionesRequest ;
      private bool[] P00MU2_n575OperacionesRequest ;
      private long[] P00MU2_A963OperacionesComercioId2 ;
      private bool[] P00MU2_n963OperacionesComercioId2 ;
      private long[] P00MU2_A962OperacionesComercioId1 ;
      private bool[] P00MU2_n962OperacionesComercioId1 ;
      private string[] P00MU2_A583OperacionesAux1 ;
      private bool[] P00MU2_n583OperacionesAux1 ;
      private long[] P00MU2_A554OperacionesId ;
      private GeneXus.Programs.apis.comerciosapi.v1.SdtSDT_NuevaSolicitudExterna AV8EntradaSDT ;
      private GeneXus.Programs.apis.comerciosapi.v1.SdtSDT_NuevaSolicitudExterna_Item AV10Item ;
      private long[] P00MU3_A135InventarioId ;
      private long[] P00MU3_A137MedidasID ;
      private short[] P00MU3_A121RubrosId ;
      private bool[] P00MU3_A1005InventarioEsPresupuestado ;
      private bool[] P00MU3_n1005InventarioEsPresupuestado ;
      private string[] P00MU3_A1004InventarioSKURelacionado ;
      private bool[] P00MU3_n1004InventarioSKURelacionado ;
      private SdtSolicitudes AV38SolicitudBCEstandar ;
      private SdtPostulaciones AV23PostulacionBC ;
      private SdtSolicitudes AV9SolicitudBC ;
      private short[] P00MU5_A121RubrosId ;
      private long[] P00MU5_A137MedidasID ;
      private long[] P00MU5_A135InventarioId ;
      private long[] P00MU5_A127SolicitudesID ;
      private string[] P00MU5_A1004InventarioSKURelacionado ;
      private bool[] P00MU5_n1004InventarioSKURelacionado ;
      private short[] P00MU5_A134SolicitudesItemsID ;
      private SdtSolicitudes_Items AV20ItemBC ;
      private IDataStoreProvider pr_datastore1 ;
   }

   public class approcesarsolicitudesexternas__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class approcesarsolicitudesexternas__default : DataStoreHelperBase, IDataStoreHelper
 {
    public ICursor[] getCursors( )
    {
       cursorDefinitions();
       return new Cursor[] {
        new ForEachCursor(def[0])
       ,new ForEachCursor(def[1])
       ,new UpdateCursor(def[2])
       ,new ForEachCursor(def[3])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmP00MU2;
        prmP00MU2 = new Object[] {
        };
        Object[] prmP00MU3;
        prmP00MU3 = new Object[] {
        new ParDef("@AV15RubrosId",GXType.Int16,4,0) ,
        new ParDef("@AV16MedidasId",GXType.Decimal,18,0) ,
        new ParDef("@AV17InventarioId",GXType.Decimal,18,0)
        };
        Object[] prmP00MU4;
        prmP00MU4 = new Object[] {
        new ParDef("@OperacionesEstado",GXType.NChar,3,0){Nullable=true} ,
        new ParDef("@OperacionesAux1",GXType.NVarChar,120,0){Nullable=true} ,
        new ParDef("@OperacionesId",GXType.Decimal,18,0)
        };
        Object[] prmP00MU5;
        prmP00MU5 = new Object[] {
        new ParDef("@AV10Item__Solicitudidref",GXType.Decimal,18,0)
        };
        def= new CursorDef[] {
            new CursorDef("P00MU2", "SELECT [OperacionesTipo], [OperacionesEstado], [OperacionesRequest], [OperacionesComercioId2], [OperacionesComercioId1], [OperacionesAux1], [OperacionesId] FROM [Operaciones] WITH (UPDLOCK) WHERE ([OperacionesEstado] = 'PND') AND ([OperacionesTipo] = 'CEX') ORDER BY [OperacionesId] ",true, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00MU2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("P00MU3", "SELECT [InventarioId], [MedidasID], [RubrosId], [InventarioEsPresupuestado], [InventarioSKURelacionado] FROM [Inventario] WHERE [RubrosId] = @AV15RubrosId and [MedidasID] = @AV16MedidasId and [InventarioId] = @AV17InventarioId ORDER BY [RubrosId], [MedidasID], [InventarioId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00MU3,1, GxCacheFrequency.OFF ,false,true )
           ,new CursorDef("P00MU4", "UPDATE [Operaciones] SET [OperacionesEstado]=@OperacionesEstado, [OperacionesAux1]=@OperacionesAux1  WHERE [OperacionesId] = @OperacionesId", GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP00MU4)
           ,new CursorDef("P00MU5", "SELECT T1.[RubrosId], T1.[MedidasID], T1.[InventarioId], T1.[SolicitudesID], T2.[InventarioSKURelacionado], T1.[SolicitudesItemsID] FROM ([SolicitudesItems] T1 INNER JOIN [Inventario] T2 ON T2.[RubrosId] = T1.[RubrosId] AND T2.[MedidasID] = T1.[MedidasID] AND T2.[InventarioId] = T1.[InventarioId]) WHERE T1.[SolicitudesID] = @AV10Item__Solicitudidref ORDER BY T1.[SolicitudesID] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00MU5,100, GxCacheFrequency.OFF ,false,false )
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
              ((bool[]) buf[1])[0] = rslt.wasNull(1);
              ((string[]) buf[2])[0] = rslt.getString(2, 3);
              ((bool[]) buf[3])[0] = rslt.wasNull(2);
              ((string[]) buf[4])[0] = rslt.getLongVarchar(3);
              ((bool[]) buf[5])[0] = rslt.wasNull(3);
              ((long[]) buf[6])[0] = rslt.getLong(4);
              ((bool[]) buf[7])[0] = rslt.wasNull(4);
              ((long[]) buf[8])[0] = rslt.getLong(5);
              ((bool[]) buf[9])[0] = rslt.wasNull(5);
              ((string[]) buf[10])[0] = rslt.getVarchar(6);
              ((bool[]) buf[11])[0] = rslt.wasNull(6);
              ((long[]) buf[12])[0] = rslt.getLong(7);
              return;
           case 1 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              ((short[]) buf[2])[0] = rslt.getShort(3);
              ((bool[]) buf[3])[0] = rslt.getBool(4);
              ((bool[]) buf[4])[0] = rslt.wasNull(4);
              ((string[]) buf[5])[0] = rslt.getVarchar(5);
              ((bool[]) buf[6])[0] = rslt.wasNull(5);
              return;
           case 3 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              ((long[]) buf[2])[0] = rslt.getLong(3);
              ((long[]) buf[3])[0] = rslt.getLong(4);
              ((string[]) buf[4])[0] = rslt.getVarchar(5);
              ((bool[]) buf[5])[0] = rslt.wasNull(5);
              ((short[]) buf[6])[0] = rslt.getShort(6);
              return;
     }
  }

}

}

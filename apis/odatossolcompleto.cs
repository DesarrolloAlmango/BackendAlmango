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
namespace GeneXus.Programs.apis {
   public class odatossolcompleto : GXProcedure
   {
      public odatossolcompleto( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public odatossolcompleto( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( long aP0_SolicitudesID ,
                           string aP1_ProfesionalId ,
                           out SdtSDTSolicitudes aP2_Solicitud ,
                           out bool aP3_Existe )
      {
         this.AV12SolicitudesID = aP0_SolicitudesID;
         this.AV10ProfesionalId = aP1_ProfesionalId;
         this.AV11Solicitud = new SdtSDTSolicitudes(context) ;
         this.AV8Existe = false ;
         initialize();
         ExecutePrivate();
         aP2_Solicitud=this.AV11Solicitud;
         aP3_Existe=this.AV8Existe;
      }

      public bool executeUdp( long aP0_SolicitudesID ,
                              string aP1_ProfesionalId ,
                              out SdtSDTSolicitudes aP2_Solicitud )
      {
         execute(aP0_SolicitudesID, aP1_ProfesionalId, out aP2_Solicitud, out aP3_Existe);
         return AV8Existe ;
      }

      public void executeSubmit( long aP0_SolicitudesID ,
                                 string aP1_ProfesionalId ,
                                 out SdtSDTSolicitudes aP2_Solicitud ,
                                 out bool aP3_Existe )
      {
         this.AV12SolicitudesID = aP0_SolicitudesID;
         this.AV10ProfesionalId = aP1_ProfesionalId;
         this.AV11Solicitud = new SdtSDTSolicitudes(context) ;
         this.AV8Existe = false ;
         SubmitImpl();
         aP2_Solicitud=this.AV11Solicitud;
         aP3_Existe=this.AV8Existe;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV23GXLvl2 = 0;
         /* Using cursor P00LT2 */
         pr_default.execute(0, new Object[] {AV12SolicitudesID});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A133ProveedorID = P00LT2_A133ProveedorID[0];
            A919STComerciosID = P00LT2_A919STComerciosID[0];
            n919STComerciosID = P00LT2_n919STComerciosID[0];
            A127SolicitudesID = P00LT2_A127SolicitudesID[0];
            A131EstadosSolId = P00LT2_A131EstadosSolId[0];
            A110ZonasID = P00LT2_A110ZonasID[0];
            n110ZonasID = P00LT2_n110ZonasID[0];
            A114DepartamentoMunicipioId = P00LT2_A114DepartamentoMunicipioId[0];
            n114DepartamentoMunicipioId = P00LT2_n114DepartamentoMunicipioId[0];
            A112DepartamentoId = P00LT2_A112DepartamentoId[0];
            n112DepartamentoId = P00LT2_n112DepartamentoId[0];
            A116PaisID = P00LT2_A116PaisID[0];
            A171SolicitudesNombre = P00LT2_A171SolicitudesNombre[0];
            A132EstadosSolNombre = P00LT2_A132EstadosSolNombre[0];
            A182SolicitudesFechaAlta = P00LT2_A182SolicitudesFechaAlta[0];
            n182SolicitudesFechaAlta = P00LT2_n182SolicitudesFechaAlta[0];
            A173SolicitudesDireccion = P00LT2_A173SolicitudesDireccion[0];
            A184SolicitudesFechaInstalacion = P00LT2_A184SolicitudesFechaInstalacion[0];
            A183SolicitudesHoraInstalacion = P00LT2_A183SolicitudesHoraInstalacion[0];
            A172SolicitudesTelefono = P00LT2_A172SolicitudesTelefono[0];
            A206SolicitudesMail = P00LT2_A206SolicitudesMail[0];
            n206SolicitudesMail = P00LT2_n206SolicitudesMail[0];
            A113DepartamentoDepartamento = P00LT2_A113DepartamentoDepartamento[0];
            A115DepartamentoMunicipioNombre = P00LT2_A115DepartamentoMunicipioNombre[0];
            A194SolicitudesAutoEnumerar = P00LT2_A194SolicitudesAutoEnumerar[0];
            A210SolicitudServicioSolCoti = P00LT2_A210SolicitudServicioSolCoti[0];
            A212SolicitudesCotizacion = P00LT2_A212SolicitudesCotizacion[0];
            A130EstadosSolTipo = P00LT2_A130EstadosSolTipo[0];
            A204SolicitudesFechaActualizacion = P00LT2_A204SolicitudesFechaActualizacion[0];
            n204SolicitudesFechaActualizacion = P00LT2_n204SolicitudesFechaActualizacion[0];
            A205SolicitudesComentario = P00LT2_A205SolicitudesComentario[0];
            A128MetodoPagosID = P00LT2_A128MetodoPagosID[0];
            A261SolicitudesNota = P00LT2_A261SolicitudesNota[0];
            A262SolicitudesNotificacion = P00LT2_A262SolicitudesNotificacion[0];
            A796SolicitudesComisionMetodoPago = P00LT2_A796SolicitudesComisionMetodoPago[0];
            A735MudanzaId = P00LT2_A735MudanzaId[0];
            n735MudanzaId = P00LT2_n735MudanzaId[0];
            A438SolicitudServicioOrigenPago = P00LT2_A438SolicitudServicioOrigenPago[0];
            n438SolicitudServicioOrigenPago = P00LT2_n438SolicitudServicioOrigenPago[0];
            A282ProveedorNombre = P00LT2_A282ProveedorNombre[0];
            A923STComerciosNombre = P00LT2_A923STComerciosNombre[0];
            A282ProveedorNombre = P00LT2_A282ProveedorNombre[0];
            A923STComerciosNombre = P00LT2_A923STComerciosNombre[0];
            A116PaisID = P00LT2_A116PaisID[0];
            A113DepartamentoDepartamento = P00LT2_A113DepartamentoDepartamento[0];
            A115DepartamentoMunicipioNombre = P00LT2_A115DepartamentoMunicipioNombre[0];
            A132EstadosSolNombre = P00LT2_A132EstadosSolNombre[0];
            GetSolicitudesTotal( A127SolicitudesID) ;
            AV23GXLvl2 = 1;
            AV8Existe = true;
            AV17Exists = context.GetMessage( "N", "");
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV10ProfesionalId)) )
            {
               if ( ( A131EstadosSolId == 2 ) || ( A131EstadosSolId == 5 ) || ( A131EstadosSolId == 6 ) || ( A131EstadosSolId == 7 ) )
               {
                  GXt_char1 = AV17Exists;
                  new orelsolpro(context ).execute(  A127SolicitudesID,  AV10ProfesionalId, out  GXt_char1) ;
                  AV17Exists = GXt_char1;
               }
               if ( A131EstadosSolId == 8 )
               {
                  GXt_boolean2 = AV22OKload;
                  new oprofesionalzonatra(context ).execute(  AV10ProfesionalId,  A116PaisID,  A112DepartamentoId,  A114DepartamentoMunicipioId,  A110ZonasID, out  GXt_boolean2) ;
                  AV22OKload = GXt_boolean2;
               }
            }
            else
            {
               AV22OKload = true;
            }
            if ( ( StringUtil.StrCmp(AV17Exists, context.GetMessage( "S", "")) == 0 ) || ( AV22OKload ) )
            {
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV10ProfesionalId)) )
               {
                  new GeneXus.Programs.apis.odetallecobroprofsol(context ).execute(  A127SolicitudesID,  AV10ProfesionalId, out  AV21ModoPago, out  AV16Deduccion, out  AV20Ganancia) ;
               }
               AV11Solicitud.gxTpr_Solicitudesid = A127SolicitudesID;
               AV11Solicitud.gxTpr_Solicitudesnombre = A171SolicitudesNombre;
               AV11Solicitud.gxTpr_Estadossolid = A131EstadosSolId;
               AV11Solicitud.gxTpr_Estadossolnombre = A132EstadosSolNombre;
               AV11Solicitud.gxTpr_Solicitudesfechaalta = A182SolicitudesFechaAlta;
               AV11Solicitud.gxTpr_Solicitudesdireccion = A173SolicitudesDireccion;
               AV11Solicitud.gxTpr_Solicitudesfechainstalacion = A184SolicitudesFechaInstalacion;
               AV11Solicitud.gxTpr_Solicitudeshorainstalacion = A183SolicitudesHoraInstalacion;
               AV11Solicitud.gxTpr_Solicitudestelefono = A172SolicitudesTelefono;
               AV11Solicitud.gxTpr_Solicitudesmail = A206SolicitudesMail;
               AV11Solicitud.gxTpr_Departamentoid = A112DepartamentoId;
               AV11Solicitud.gxTpr_Departamentonombre = A113DepartamentoDepartamento;
               AV11Solicitud.gxTpr_Departamentomunicipioid = A114DepartamentoMunicipioId;
               AV11Solicitud.gxTpr_Municipionombre = A115DepartamentoMunicipioNombre;
               AV11Solicitud.gxTpr_Zonasid = A110ZonasID;
               AV11Solicitud.gxTpr_Solicitudesautoenumerar = A194SolicitudesAutoEnumerar;
               AV11Solicitud.gxTpr_Solicitudserviciosolcoti = A210SolicitudServicioSolCoti;
               AV11Solicitud.gxTpr_Solicitudescotizacion = A212SolicitudesCotizacion;
               AV11Solicitud.gxTpr_Estadossoltipo = A130EstadosSolTipo;
               AV11Solicitud.gxTpr_Solicitudesfechaactualizacion = A204SolicitudesFechaActualizacion;
               AV11Solicitud.gxTpr_Solicitudescomentario = A205SolicitudesComentario;
               AV11Solicitud.gxTpr_Metodopagosid = A128MetodoPagosID;
               AV11Solicitud.gxTpr_Solicitudesnota = A261SolicitudesNota;
               AV11Solicitud.gxTpr_Solicitudesnotificacion = A262SolicitudesNotificacion;
               AV11Solicitud.gxTpr_Solicitudescomisionmetodopago = A796SolicitudesComisionMetodoPago;
               AV11Solicitud.gxTpr_Solicitudestotal = A174SolicitudesTotal;
               AV11Solicitud.gxTpr_Deduccion = AV16Deduccion;
               AV11Solicitud.gxTpr_Modopago = AV21ModoPago;
               AV11Solicitud.gxTpr_Ganancia = AV20Ganancia;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV10ProfesionalId)) )
               {
                  new ofeedbackid(context ).execute(  AV10ProfesionalId,  AV14clientesId,  A127SolicitudesID, out  AV19FeedBackid, out  AV13Calificacion, out  AV15Comentario, out  AV18FeedBackFechaAlta) ;
               }
               AV11Solicitud.gxTpr_Feedbackid = AV19FeedBackid;
               AV11Solicitud.gxTpr_Feedbacknum = AV13Calificacion;
               AV11Solicitud.gxTpr_Feedbackcomentario = AV15Comentario;
               AV11Solicitud.gxTpr_Feedbackfechaalta = AV18FeedBackFechaAlta;
               AV11Solicitud.gxTpr_Mudanzaid = A735MudanzaId;
               AV11Solicitud.gxTpr_Solicitudservicioorigenpago = A438SolicitudServicioOrigenPago;
               AV11Solicitud.gxTpr_Proveedornombre = A282ProveedorNombre;
               AV11Solicitud.gxTpr_Stcomerciosnombre = A923STComerciosNombre;
               /* Using cursor P00LT3 */
               pr_default.execute(1, new Object[] {AV11Solicitud.gxTpr_Solicitudesid});
               while ( (pr_default.getStatus(1) != 101) )
               {
                  A127SolicitudesID = P00LT3_A127SolicitudesID[0];
                  A134SolicitudesItemsID = P00LT3_A134SolicitudesItemsID[0];
                  A177SolicitudesItemsCantidad = P00LT3_A177SolicitudesItemsCantidad[0];
                  A121RubrosId = P00LT3_A121RubrosId[0];
                  A122RubrosNombre = P00LT3_A122RubrosNombre[0];
                  A122RubrosNombre = P00LT3_A122RubrosNombre[0];
                  AV9Item = new SdtSDTSolicitudes_Items(context);
                  AV9Item.gxTpr_Solicitudesitemsid = A134SolicitudesItemsID;
                  AV9Item.gxTpr_Solicitudesitemscantidad = A177SolicitudesItemsCantidad;
                  AV9Item.gxTpr_Rubrosid = A121RubrosId;
                  AV9Item.gxTpr_Rubrosnombre = A122RubrosNombre;
                  AV11Solicitud.gxTpr_Items.Add(AV9Item, 0);
                  pr_default.readNext(1);
               }
               pr_default.close(1);
            }
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(0);
         if ( AV23GXLvl2 == 0 )
         {
            AV8Existe = false;
         }
         cleanup();
      }

      protected void GetSolicitudesTotal( long A127SolicitudesID )
      {
         /* Create private dbobjects */
         /* Navigation */
         A174SolicitudesTotal = 0;
         /* Using cursor P00LT4 */
         pr_default.execute(2, new Object[] {A127SolicitudesID});
         while ( (pr_default.getStatus(2) != 101) && ( P00LT4_A127SolicitudesID[0] == A127SolicitudesID ) )
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( P00LT4_A178SolicitudItemsSR[0])) || ( StringUtil.StrCmp(P00LT4_A179SolicitudItemsComisionTipo[0], "N") == 0 ) )
            {
               A175SolicitudesItemsPrecioInstalac = (decimal)((P00LT4_A176SolicitudesItemsPrecioFinal[0]*P00LT4_A177SolicitudesItemsCantidad[0]));
            }
            else
            {
               if ( ( StringUtil.StrCmp(P00LT4_A179SolicitudItemsComisionTipo[0], "F") == 0 ) && ( StringUtil.StrCmp(P00LT4_A178SolicitudItemsSR[0], "R") == 0 ) )
               {
                  A175SolicitudesItemsPrecioInstalac = (decimal)((P00LT4_A176SolicitudesItemsPrecioFinal[0]*P00LT4_A177SolicitudesItemsCantidad[0])-(P00LT4_A180SolicitudItemsComision[0]*P00LT4_A177SolicitudesItemsCantidad[0]));
               }
               else
               {
                  if ( ( StringUtil.StrCmp(P00LT4_A179SolicitudItemsComisionTipo[0], "F") == 0 ) && ( StringUtil.StrCmp(P00LT4_A178SolicitudItemsSR[0], "S") == 0 ) )
                  {
                     A175SolicitudesItemsPrecioInstalac = (decimal)((P00LT4_A176SolicitudesItemsPrecioFinal[0]*P00LT4_A177SolicitudesItemsCantidad[0])+(P00LT4_A180SolicitudItemsComision[0]*P00LT4_A177SolicitudesItemsCantidad[0]));
                  }
                  else
                  {
                     if ( ( StringUtil.StrCmp(P00LT4_A179SolicitudItemsComisionTipo[0], "P") == 0 ) && ( StringUtil.StrCmp(P00LT4_A178SolicitudItemsSR[0], "R") == 0 ) )
                     {
                        A175SolicitudesItemsPrecioInstalac = (decimal)((P00LT4_A176SolicitudesItemsPrecioFinal[0]*P00LT4_A177SolicitudesItemsCantidad[0])-((P00LT4_A176SolicitudesItemsPrecioFinal[0]*P00LT4_A177SolicitudesItemsCantidad[0])*(P00LT4_A180SolicitudItemsComision[0]/ (decimal)(100))));
                     }
                     else
                     {
                        if ( ( StringUtil.StrCmp(P00LT4_A179SolicitudItemsComisionTipo[0], "P") == 0 ) && ( StringUtil.StrCmp(P00LT4_A178SolicitudItemsSR[0], "S") == 0 ) )
                        {
                           A175SolicitudesItemsPrecioInstalac = (decimal)((P00LT4_A176SolicitudesItemsPrecioFinal[0]*P00LT4_A177SolicitudesItemsCantidad[0])+((P00LT4_A176SolicitudesItemsPrecioFinal[0]*P00LT4_A177SolicitudesItemsCantidad[0])*(P00LT4_A180SolicitudItemsComision[0]/ (decimal)(100))));
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
         if ( IsMain )
         {
            context.CloseConnections();
         }
         ExitApp();
      }

      public override void initialize( )
      {
         AV11Solicitud = new SdtSDTSolicitudes(context);
         P00LT2_A133ProveedorID = new long[1] ;
         P00LT2_A919STComerciosID = new long[1] ;
         P00LT2_n919STComerciosID = new bool[] {false} ;
         P00LT2_A127SolicitudesID = new long[1] ;
         P00LT2_A131EstadosSolId = new int[1] ;
         P00LT2_A110ZonasID = new long[1] ;
         P00LT2_n110ZonasID = new bool[] {false} ;
         P00LT2_A114DepartamentoMunicipioId = new long[1] ;
         P00LT2_n114DepartamentoMunicipioId = new bool[] {false} ;
         P00LT2_A112DepartamentoId = new long[1] ;
         P00LT2_n112DepartamentoId = new bool[] {false} ;
         P00LT2_A116PaisID = new string[] {""} ;
         P00LT2_A171SolicitudesNombre = new string[] {""} ;
         P00LT2_A132EstadosSolNombre = new string[] {""} ;
         P00LT2_A182SolicitudesFechaAlta = new DateTime[] {DateTime.MinValue} ;
         P00LT2_n182SolicitudesFechaAlta = new bool[] {false} ;
         P00LT2_A173SolicitudesDireccion = new string[] {""} ;
         P00LT2_A184SolicitudesFechaInstalacion = new DateTime[] {DateTime.MinValue} ;
         P00LT2_A183SolicitudesHoraInstalacion = new string[] {""} ;
         P00LT2_A172SolicitudesTelefono = new string[] {""} ;
         P00LT2_A206SolicitudesMail = new string[] {""} ;
         P00LT2_n206SolicitudesMail = new bool[] {false} ;
         P00LT2_A113DepartamentoDepartamento = new string[] {""} ;
         P00LT2_A115DepartamentoMunicipioNombre = new string[] {""} ;
         P00LT2_A194SolicitudesAutoEnumerar = new short[1] ;
         P00LT2_A210SolicitudServicioSolCoti = new string[] {""} ;
         P00LT2_A212SolicitudesCotizacion = new decimal[1] ;
         P00LT2_A130EstadosSolTipo = new string[] {""} ;
         P00LT2_A204SolicitudesFechaActualizacion = new DateTime[] {DateTime.MinValue} ;
         P00LT2_n204SolicitudesFechaActualizacion = new bool[] {false} ;
         P00LT2_A205SolicitudesComentario = new string[] {""} ;
         P00LT2_A128MetodoPagosID = new long[1] ;
         P00LT2_A261SolicitudesNota = new string[] {""} ;
         P00LT2_A262SolicitudesNotificacion = new string[] {""} ;
         P00LT2_A796SolicitudesComisionMetodoPago = new decimal[1] ;
         P00LT2_A735MudanzaId = new long[1] ;
         P00LT2_n735MudanzaId = new bool[] {false} ;
         P00LT2_A438SolicitudServicioOrigenPago = new string[] {""} ;
         P00LT2_n438SolicitudServicioOrigenPago = new bool[] {false} ;
         P00LT2_A282ProveedorNombre = new string[] {""} ;
         P00LT2_A923STComerciosNombre = new string[] {""} ;
         A116PaisID = "";
         A171SolicitudesNombre = "";
         A132EstadosSolNombre = "";
         A182SolicitudesFechaAlta = DateTime.MinValue;
         A173SolicitudesDireccion = "";
         A184SolicitudesFechaInstalacion = DateTime.MinValue;
         A183SolicitudesHoraInstalacion = "";
         A172SolicitudesTelefono = "";
         A206SolicitudesMail = "";
         A113DepartamentoDepartamento = "";
         A115DepartamentoMunicipioNombre = "";
         A210SolicitudServicioSolCoti = "";
         A130EstadosSolTipo = "";
         A204SolicitudesFechaActualizacion = (DateTime)(DateTime.MinValue);
         A205SolicitudesComentario = "";
         A261SolicitudesNota = "";
         A262SolicitudesNotificacion = "";
         A438SolicitudServicioOrigenPago = "";
         A282ProveedorNombre = "";
         A923STComerciosNombre = "";
         AV17Exists = "";
         GXt_char1 = "";
         AV21ModoPago = "";
         AV16Deduccion = "";
         AV20Ganancia = "";
         AV15Comentario = "";
         AV18FeedBackFechaAlta = DateTime.MinValue;
         P00LT3_A127SolicitudesID = new long[1] ;
         P00LT3_A134SolicitudesItemsID = new short[1] ;
         P00LT3_A177SolicitudesItemsCantidad = new short[1] ;
         P00LT3_A121RubrosId = new short[1] ;
         P00LT3_A122RubrosNombre = new string[] {""} ;
         A122RubrosNombre = "";
         AV9Item = new SdtSDTSolicitudes_Items(context);
         P00LT4_A127SolicitudesID = new long[1] ;
         P00LT4_A134SolicitudesItemsID = new short[1] ;
         P00LT4_A180SolicitudItemsComision = new decimal[1] ;
         P00LT4_A179SolicitudItemsComisionTipo = new string[] {""} ;
         P00LT4_A178SolicitudItemsSR = new string[] {""} ;
         P00LT4_A177SolicitudesItemsCantidad = new short[1] ;
         P00LT4_A176SolicitudesItemsPrecioFinal = new decimal[1] ;
         P00LT4_n176SolicitudesItemsPrecioFinal = new bool[] {false} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.apis.odatossolcompleto__default(),
            new Object[][] {
                new Object[] {
               P00LT2_A133ProveedorID, P00LT2_A919STComerciosID, P00LT2_n919STComerciosID, P00LT2_A127SolicitudesID, P00LT2_A131EstadosSolId, P00LT2_A110ZonasID, P00LT2_n110ZonasID, P00LT2_A114DepartamentoMunicipioId, P00LT2_n114DepartamentoMunicipioId, P00LT2_A112DepartamentoId,
               P00LT2_n112DepartamentoId, P00LT2_A116PaisID, P00LT2_A171SolicitudesNombre, P00LT2_A132EstadosSolNombre, P00LT2_A182SolicitudesFechaAlta, P00LT2_n182SolicitudesFechaAlta, P00LT2_A173SolicitudesDireccion, P00LT2_A184SolicitudesFechaInstalacion, P00LT2_A183SolicitudesHoraInstalacion, P00LT2_A172SolicitudesTelefono,
               P00LT2_A206SolicitudesMail, P00LT2_n206SolicitudesMail, P00LT2_A113DepartamentoDepartamento, P00LT2_A115DepartamentoMunicipioNombre, P00LT2_A194SolicitudesAutoEnumerar, P00LT2_A210SolicitudServicioSolCoti, P00LT2_A212SolicitudesCotizacion, P00LT2_A130EstadosSolTipo, P00LT2_A204SolicitudesFechaActualizacion, P00LT2_n204SolicitudesFechaActualizacion,
               P00LT2_A205SolicitudesComentario, P00LT2_A128MetodoPagosID, P00LT2_A261SolicitudesNota, P00LT2_A262SolicitudesNotificacion, P00LT2_A796SolicitudesComisionMetodoPago, P00LT2_A735MudanzaId, P00LT2_n735MudanzaId, P00LT2_A438SolicitudServicioOrigenPago, P00LT2_n438SolicitudServicioOrigenPago, P00LT2_A282ProveedorNombre,
               P00LT2_A923STComerciosNombre
               }
               , new Object[] {
               P00LT3_A127SolicitudesID, P00LT3_A134SolicitudesItemsID, P00LT3_A177SolicitudesItemsCantidad, P00LT3_A121RubrosId, P00LT3_A122RubrosNombre
               }
               , new Object[] {
               P00LT4_A127SolicitudesID, P00LT4_A134SolicitudesItemsID, P00LT4_A180SolicitudItemsComision, P00LT4_A179SolicitudItemsComisionTipo, P00LT4_A178SolicitudItemsSR, P00LT4_A177SolicitudesItemsCantidad, P00LT4_A176SolicitudesItemsPrecioFinal, P00LT4_n176SolicitudesItemsPrecioFinal
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV23GXLvl2 ;
      private short A194SolicitudesAutoEnumerar ;
      private short A134SolicitudesItemsID ;
      private short A177SolicitudesItemsCantidad ;
      private short A121RubrosId ;
      private int A131EstadosSolId ;
      private long AV12SolicitudesID ;
      private long A133ProveedorID ;
      private long A919STComerciosID ;
      private long A127SolicitudesID ;
      private long A110ZonasID ;
      private long A114DepartamentoMunicipioId ;
      private long A112DepartamentoId ;
      private long A128MetodoPagosID ;
      private long A735MudanzaId ;
      private long AV14clientesId ;
      private long AV19FeedBackid ;
      private long AV13Calificacion ;
      private decimal A212SolicitudesCotizacion ;
      private decimal A796SolicitudesComisionMetodoPago ;
      private decimal A174SolicitudesTotal ;
      private decimal A175SolicitudesItemsPrecioInstalac ;
      private string AV10ProfesionalId ;
      private string A116PaisID ;
      private string A171SolicitudesNombre ;
      private string A132EstadosSolNombre ;
      private string A183SolicitudesHoraInstalacion ;
      private string A172SolicitudesTelefono ;
      private string A113DepartamentoDepartamento ;
      private string A115DepartamentoMunicipioNombre ;
      private string A210SolicitudServicioSolCoti ;
      private string A130EstadosSolTipo ;
      private string A261SolicitudesNota ;
      private string A262SolicitudesNotificacion ;
      private string A438SolicitudServicioOrigenPago ;
      private string A282ProveedorNombre ;
      private string A923STComerciosNombre ;
      private string AV17Exists ;
      private string GXt_char1 ;
      private string AV21ModoPago ;
      private string AV16Deduccion ;
      private string AV20Ganancia ;
      private string A122RubrosNombre ;
      private DateTime A204SolicitudesFechaActualizacion ;
      private DateTime A182SolicitudesFechaAlta ;
      private DateTime A184SolicitudesFechaInstalacion ;
      private DateTime AV18FeedBackFechaAlta ;
      private bool AV8Existe ;
      private bool n919STComerciosID ;
      private bool n110ZonasID ;
      private bool n114DepartamentoMunicipioId ;
      private bool n112DepartamentoId ;
      private bool n182SolicitudesFechaAlta ;
      private bool n206SolicitudesMail ;
      private bool n204SolicitudesFechaActualizacion ;
      private bool n735MudanzaId ;
      private bool n438SolicitudServicioOrigenPago ;
      private bool AV22OKload ;
      private bool GXt_boolean2 ;
      private string A205SolicitudesComentario ;
      private string A173SolicitudesDireccion ;
      private string A206SolicitudesMail ;
      private string AV15Comentario ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private SdtSDTSolicitudes AV11Solicitud ;
      private IDataStoreProvider pr_default ;
      private long[] P00LT2_A133ProveedorID ;
      private long[] P00LT2_A919STComerciosID ;
      private bool[] P00LT2_n919STComerciosID ;
      private long[] P00LT2_A127SolicitudesID ;
      private int[] P00LT2_A131EstadosSolId ;
      private long[] P00LT2_A110ZonasID ;
      private bool[] P00LT2_n110ZonasID ;
      private long[] P00LT2_A114DepartamentoMunicipioId ;
      private bool[] P00LT2_n114DepartamentoMunicipioId ;
      private long[] P00LT2_A112DepartamentoId ;
      private bool[] P00LT2_n112DepartamentoId ;
      private string[] P00LT2_A116PaisID ;
      private string[] P00LT2_A171SolicitudesNombre ;
      private string[] P00LT2_A132EstadosSolNombre ;
      private DateTime[] P00LT2_A182SolicitudesFechaAlta ;
      private bool[] P00LT2_n182SolicitudesFechaAlta ;
      private string[] P00LT2_A173SolicitudesDireccion ;
      private DateTime[] P00LT2_A184SolicitudesFechaInstalacion ;
      private string[] P00LT2_A183SolicitudesHoraInstalacion ;
      private string[] P00LT2_A172SolicitudesTelefono ;
      private string[] P00LT2_A206SolicitudesMail ;
      private bool[] P00LT2_n206SolicitudesMail ;
      private string[] P00LT2_A113DepartamentoDepartamento ;
      private string[] P00LT2_A115DepartamentoMunicipioNombre ;
      private short[] P00LT2_A194SolicitudesAutoEnumerar ;
      private string[] P00LT2_A210SolicitudServicioSolCoti ;
      private decimal[] P00LT2_A212SolicitudesCotizacion ;
      private string[] P00LT2_A130EstadosSolTipo ;
      private DateTime[] P00LT2_A204SolicitudesFechaActualizacion ;
      private bool[] P00LT2_n204SolicitudesFechaActualizacion ;
      private string[] P00LT2_A205SolicitudesComentario ;
      private long[] P00LT2_A128MetodoPagosID ;
      private string[] P00LT2_A261SolicitudesNota ;
      private string[] P00LT2_A262SolicitudesNotificacion ;
      private decimal[] P00LT2_A796SolicitudesComisionMetodoPago ;
      private long[] P00LT2_A735MudanzaId ;
      private bool[] P00LT2_n735MudanzaId ;
      private string[] P00LT2_A438SolicitudServicioOrigenPago ;
      private bool[] P00LT2_n438SolicitudServicioOrigenPago ;
      private string[] P00LT2_A282ProveedorNombre ;
      private string[] P00LT2_A923STComerciosNombre ;
      private long[] P00LT3_A127SolicitudesID ;
      private short[] P00LT3_A134SolicitudesItemsID ;
      private short[] P00LT3_A177SolicitudesItemsCantidad ;
      private short[] P00LT3_A121RubrosId ;
      private string[] P00LT3_A122RubrosNombre ;
      private SdtSDTSolicitudes_Items AV9Item ;
      private long[] P00LT4_A127SolicitudesID ;
      private short[] P00LT4_A134SolicitudesItemsID ;
      private decimal[] P00LT4_A180SolicitudItemsComision ;
      private string[] P00LT4_A179SolicitudItemsComisionTipo ;
      private string[] P00LT4_A178SolicitudItemsSR ;
      private short[] P00LT4_A177SolicitudesItemsCantidad ;
      private decimal[] P00LT4_A176SolicitudesItemsPrecioFinal ;
      private bool[] P00LT4_n176SolicitudesItemsPrecioFinal ;
      private SdtSDTSolicitudes aP2_Solicitud ;
      private bool aP3_Existe ;
   }

   public class odatossolcompleto__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP00LT2;
          prmP00LT2 = new Object[] {
          new ParDef("@AV12SolicitudesID",GXType.Decimal,18,0)
          };
          Object[] prmP00LT3;
          prmP00LT3 = new Object[] {
          new ParDef("@AV11Solicitud__Solicitudesid",GXType.Decimal,18,0)
          };
          Object[] prmP00LT4;
          prmP00LT4 = new Object[] {
          new ParDef("@SolicitudesID",GXType.Decimal,18,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00LT2", "SELECT T1.[ProveedorID], T1.[STComerciosID] AS STComerciosID, T1.[SolicitudesID], T1.[EstadosSolId] AS EstadosSolId, T1.[ZonasID], T1.[DepartamentoMunicipioId], T1.[DepartamentoId], T4.[PaisID], T1.[SolicitudesNombre], T6.[EstadosGenericosNombre] AS EstadosSolNombre, T1.[SolicitudesFechaAlta], T1.[SolicitudesDireccion], T1.[SolicitudesFechaInstalacion], T1.[SolicitudesHoraInstalacion], T1.[SolicitudesTelefono], T1.[SolicitudesMail], T4.[DepartamentoDepartamento], T5.[DepartamentoMunicipioNombre], T1.[SolicitudesAutoEnumerar], T1.[SolicitudServicioSolCoti], T1.[SolicitudesCotizacion], T1.[EstadosSolTipo] AS EstadosSolTipo, T1.[SolicitudesFechaActualizacion], T1.[SolicitudesComentario], T1.[MetodoPagosID], T1.[SolicitudesNota], T1.[SolicitudesNotificacion], T1.[SolicitudesComisionMetodoPago], T1.[MudanzaId], T1.[SolicitudServicioOrigenPago], T2.[ProveedorNombre], T3.[ProveedorNombre] AS STComerciosNombre FROM ((((([Solicitudes] T1 INNER JOIN [Proveedor] T2 ON T2.[ProveedorID] = T1.[ProveedorID]) LEFT JOIN [Proveedor] T3 ON T3.[ProveedorID] = T1.[STComerciosID]) LEFT JOIN [Departamento] T4 ON T4.[DepartamentoId] = T1.[DepartamentoId]) LEFT JOIN [DepartamentoMunicipio] T5 ON T5.[DepartamentoId] = T1.[DepartamentoId] AND T5.[DepartamentoMunicipioId] = T1.[DepartamentoMunicipioId]) INNER JOIN [EstadosGenericos] T6 ON T6.[EstadosTipo] = T1.[EstadosSolTipo] AND T6.[EstadosGenericosId] = T1.[EstadosSolId]) WHERE T1.[SolicitudesID] = @AV12SolicitudesID ORDER BY T1.[SolicitudesID] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00LT2,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("P00LT3", "SELECT T1.[SolicitudesID], T1.[SolicitudesItemsID], T1.[SolicitudesItemsCantidad], T1.[RubrosId], T2.[RubrosNombre] FROM ([SolicitudesItems] T1 INNER JOIN [Rubros] T2 ON T2.[RubrosId] = T1.[RubrosId]) WHERE T1.[SolicitudesID] = @AV11Solicitud__Solicitudesid ORDER BY T1.[SolicitudesID] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00LT3,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P00LT4", "SELECT [SolicitudesID], [SolicitudesItemsID], [SolicitudItemsComision], [SolicitudItemsComisionTipo], [SolicitudItemsSR], [SolicitudesItemsCantidad], [SolicitudesItemsPrecioFinal] FROM [SolicitudesItems] WHERE [SolicitudesID] = @SolicitudesID ORDER BY [SolicitudesID] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00LT4,100, GxCacheFrequency.OFF ,true,false )
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
                ((long[]) buf[1])[0] = rslt.getLong(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((long[]) buf[3])[0] = rslt.getLong(3);
                ((int[]) buf[4])[0] = rslt.getInt(4);
                ((long[]) buf[5])[0] = rslt.getLong(5);
                ((bool[]) buf[6])[0] = rslt.wasNull(5);
                ((long[]) buf[7])[0] = rslt.getLong(6);
                ((bool[]) buf[8])[0] = rslt.wasNull(6);
                ((long[]) buf[9])[0] = rslt.getLong(7);
                ((bool[]) buf[10])[0] = rslt.wasNull(7);
                ((string[]) buf[11])[0] = rslt.getString(8, 2);
                ((string[]) buf[12])[0] = rslt.getString(9, 100);
                ((string[]) buf[13])[0] = rslt.getString(10, 80);
                ((DateTime[]) buf[14])[0] = rslt.getGXDate(11);
                ((bool[]) buf[15])[0] = rslt.wasNull(11);
                ((string[]) buf[16])[0] = rslt.getVarchar(12);
                ((DateTime[]) buf[17])[0] = rslt.getGXDate(13);
                ((string[]) buf[18])[0] = rslt.getString(14, 1);
                ((string[]) buf[19])[0] = rslt.getString(15, 20);
                ((string[]) buf[20])[0] = rslt.getVarchar(16);
                ((bool[]) buf[21])[0] = rslt.wasNull(16);
                ((string[]) buf[22])[0] = rslt.getString(17, 80);
                ((string[]) buf[23])[0] = rslt.getString(18, 120);
                ((short[]) buf[24])[0] = rslt.getShort(19);
                ((string[]) buf[25])[0] = rslt.getString(20, 1);
                ((decimal[]) buf[26])[0] = rslt.getDecimal(21);
                ((string[]) buf[27])[0] = rslt.getString(22, 3);
                ((DateTime[]) buf[28])[0] = rslt.getGXDateTime(23);
                ((bool[]) buf[29])[0] = rslt.wasNull(23);
                ((string[]) buf[30])[0] = rslt.getLongVarchar(24);
                ((long[]) buf[31])[0] = rslt.getLong(25);
                ((string[]) buf[32])[0] = rslt.getString(26, 500);
                ((string[]) buf[33])[0] = rslt.getString(27, 1);
                ((decimal[]) buf[34])[0] = rslt.getDecimal(28);
                ((long[]) buf[35])[0] = rslt.getLong(29);
                ((bool[]) buf[36])[0] = rslt.wasNull(29);
                ((string[]) buf[37])[0] = rslt.getString(30, 1);
                ((bool[]) buf[38])[0] = rslt.wasNull(30);
                ((string[]) buf[39])[0] = rslt.getString(31, 80);
                ((string[]) buf[40])[0] = rslt.getString(32, 80);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                ((string[]) buf[4])[0] = rslt.getString(5, 100);
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

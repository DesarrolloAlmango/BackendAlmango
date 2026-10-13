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
   public class altasubsolicitud : GXProcedure
   {
      public altasubsolicitud( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public altasubsolicitud( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( long aP0_CentroCostosId ,
                           long aP1_CentroCostosDetallesId ,
                           DateTime aP2_CentroCostosDetallesFecha ,
                           long aP3_CentroCostosDetallesEstado ,
                           string aP4_SubsolicitudNombre ,
                           decimal aP5_SubsolicitudCosto ,
                           string aP6_ProfesionalesId ,
                           long aP7_SolicitudesID ,
                           out long aP8_NewSolicitudId ,
                           out bool aP9_IsOk ,
                           out string aP10_TxtMsg )
      {
         this.AV20CentroCostosId = aP0_CentroCostosId;
         this.AV18CentroCostosDetallesId = aP1_CentroCostosDetallesId;
         this.AV27CentroCostosDetallesFecha = aP2_CentroCostosDetallesFecha;
         this.AV28CentroCostosDetallesEstado = aP3_CentroCostosDetallesEstado;
         this.AV16SubsolicitudNombre = aP4_SubsolicitudNombre;
         this.AV17SubsolicitudCosto = aP5_SubsolicitudCosto;
         this.AV19ProfesionalesId = aP6_ProfesionalesId;
         this.AV12SolicitudesID = aP7_SolicitudesID;
         this.AV11NewSolicitudId = 0 ;
         this.AV8IsOk = false ;
         this.AV13TxtMsg = "" ;
         initialize();
         ExecutePrivate();
         aP8_NewSolicitudId=this.AV11NewSolicitudId;
         aP9_IsOk=this.AV8IsOk;
         aP10_TxtMsg=this.AV13TxtMsg;
      }

      public string executeUdp( long aP0_CentroCostosId ,
                                long aP1_CentroCostosDetallesId ,
                                DateTime aP2_CentroCostosDetallesFecha ,
                                long aP3_CentroCostosDetallesEstado ,
                                string aP4_SubsolicitudNombre ,
                                decimal aP5_SubsolicitudCosto ,
                                string aP6_ProfesionalesId ,
                                long aP7_SolicitudesID ,
                                out long aP8_NewSolicitudId ,
                                out bool aP9_IsOk )
      {
         execute(aP0_CentroCostosId, aP1_CentroCostosDetallesId, aP2_CentroCostosDetallesFecha, aP3_CentroCostosDetallesEstado, aP4_SubsolicitudNombre, aP5_SubsolicitudCosto, aP6_ProfesionalesId, aP7_SolicitudesID, out aP8_NewSolicitudId, out aP9_IsOk, out aP10_TxtMsg);
         return AV13TxtMsg ;
      }

      public void executeSubmit( long aP0_CentroCostosId ,
                                 long aP1_CentroCostosDetallesId ,
                                 DateTime aP2_CentroCostosDetallesFecha ,
                                 long aP3_CentroCostosDetallesEstado ,
                                 string aP4_SubsolicitudNombre ,
                                 decimal aP5_SubsolicitudCosto ,
                                 string aP6_ProfesionalesId ,
                                 long aP7_SolicitudesID ,
                                 out long aP8_NewSolicitudId ,
                                 out bool aP9_IsOk ,
                                 out string aP10_TxtMsg )
      {
         this.AV20CentroCostosId = aP0_CentroCostosId;
         this.AV18CentroCostosDetallesId = aP1_CentroCostosDetallesId;
         this.AV27CentroCostosDetallesFecha = aP2_CentroCostosDetallesFecha;
         this.AV28CentroCostosDetallesEstado = aP3_CentroCostosDetallesEstado;
         this.AV16SubsolicitudNombre = aP4_SubsolicitudNombre;
         this.AV17SubsolicitudCosto = aP5_SubsolicitudCosto;
         this.AV19ProfesionalesId = aP6_ProfesionalesId;
         this.AV12SolicitudesID = aP7_SolicitudesID;
         this.AV11NewSolicitudId = 0 ;
         this.AV8IsOk = false ;
         this.AV13TxtMsg = "" ;
         SubmitImpl();
         aP8_NewSolicitudId=this.AV11NewSolicitudId;
         aP9_IsOk=this.AV8IsOk;
         aP10_TxtMsg=this.AV13TxtMsg;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV8IsOk = false;
         AV13TxtMsg = "";
         GXt_SdtWWPContext1 = AV15contextww;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  GXt_SdtWWPContext1) ;
         AV15contextww = GXt_SdtWWPContext1;
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV19ProfesionalesId)) )
         {
            /* Using cursor P00IQ2 */
            pr_default.execute(0, new Object[] {AV12SolicitudesID});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A127SolicitudesID = P00IQ2_A127SolicitudesID[0];
               A172SolicitudesTelefono = P00IQ2_A172SolicitudesTelefono[0];
               A206SolicitudesMail = P00IQ2_A206SolicitudesMail[0];
               n206SolicitudesMail = P00IQ2_n206SolicitudesMail[0];
               A128MetodoPagosID = P00IQ2_A128MetodoPagosID[0];
               A110ZonasID = P00IQ2_A110ZonasID[0];
               n110ZonasID = P00IQ2_n110ZonasID[0];
               A112DepartamentoId = P00IQ2_A112DepartamentoId[0];
               n112DepartamentoId = P00IQ2_n112DepartamentoId[0];
               A114DepartamentoMunicipioId = P00IQ2_A114DepartamentoMunicipioId[0];
               n114DepartamentoMunicipioId = P00IQ2_n114DepartamentoMunicipioId[0];
               A173SolicitudesDireccion = P00IQ2_A173SolicitudesDireccion[0];
               A210SolicitudServicioSolCoti = P00IQ2_A210SolicitudServicioSolCoti[0];
               A130EstadosSolTipo = P00IQ2_A130EstadosSolTipo[0];
               A201SolicitudesOtros1 = P00IQ2_A201SolicitudesOtros1[0];
               A202SolicitudesOtros2 = P00IQ2_A202SolicitudesOtros2[0];
               A203SolicitudesOtros3 = P00IQ2_A203SolicitudesOtros3[0];
               A184SolicitudesFechaInstalacion = P00IQ2_A184SolicitudesFechaInstalacion[0];
               A183SolicitudesHoraInstalacion = P00IQ2_A183SolicitudesHoraInstalacion[0];
               A205SolicitudesComentario = P00IQ2_A205SolicitudesComentario[0];
               A261SolicitudesNota = P00IQ2_A261SolicitudesNota[0];
               A262SolicitudesNotificacion = P00IQ2_A262SolicitudesNotificacion[0];
               A133ProveedorID = P00IQ2_A133ProveedorID[0];
               A533ProveedorNombreAux = P00IQ2_A533ProveedorNombreAux[0];
               n533ProveedorNombreAux = P00IQ2_n533ProveedorNombreAux[0];
               A438SolicitudServicioOrigenPago = P00IQ2_A438SolicitudServicioOrigenPago[0];
               n438SolicitudServicioOrigenPago = P00IQ2_n438SolicitudServicioOrigenPago[0];
               A441SolicitudesPagado = P00IQ2_A441SolicitudesPagado[0];
               n441SolicitudesPagado = P00IQ2_n441SolicitudesPagado[0];
               W127SolicitudesID = A127SolicitudesID;
               AV9NewSolicitudes.gxTpr_Solicitudesnombre = StringUtil.Trim( AV16SubsolicitudNombre);
               AV9NewSolicitudes.gxTpr_Solicitudestelefono = A172SolicitudesTelefono;
               AV9NewSolicitudes.gxTpr_Solicitudesmail = A206SolicitudesMail;
               AV9NewSolicitudes.gxTpr_Metodopagosid = A128MetodoPagosID;
               if ( (0==A110ZonasID) )
               {
                  AV9NewSolicitudes.gxTpr_Zonasid = 9999;
               }
               else
               {
                  AV9NewSolicitudes.gxTpr_Zonasid = A110ZonasID;
               }
               AV9NewSolicitudes.gxTpr_Departamentoid = A112DepartamentoId;
               AV9NewSolicitudes.gxTpr_Departamentomunicipioid = A114DepartamentoMunicipioId;
               AV9NewSolicitudes.gxTpr_Solicitudesdireccion = A173SolicitudesDireccion;
               AV9NewSolicitudes.gxTpr_Solicitudescotizacion = (decimal)(0);
               AV9NewSolicitudes.gxTpr_Solicitudserviciosolcoti = A210SolicitudServicioSolCoti;
               AV9NewSolicitudes.gxTpr_Estadossoltipo = A130EstadosSolTipo;
               if ( (0==AV28CentroCostosDetallesEstado) )
               {
                  AV9NewSolicitudes.gxTpr_Estadossolid = 1;
               }
               else
               {
                  AV9NewSolicitudes.gxTpr_Estadossolid = (int)(AV28CentroCostosDetallesEstado);
               }
               AV9NewSolicitudes.gxTpr_Solicitudesotros1 = A201SolicitudesOtros1;
               AV9NewSolicitudes.gxTpr_Solicitudesotros2 = A202SolicitudesOtros2;
               AV9NewSolicitudes.gxTpr_Solicitudesotros3 = A203SolicitudesOtros3;
               AV9NewSolicitudes.gxTpr_Solicitudesfechaalta = DateTimeUtil.ServerNow( context, pr_default);
               AV9NewSolicitudes.gxTpr_Solicitudesfechaactualizacion = DateTimeUtil.ServerNow( context, pr_default);
               if ( (DateTime.MinValue==AV27CentroCostosDetallesFecha) )
               {
                  AV9NewSolicitudes.gxTpr_Solicitudesfechainstalacion = A184SolicitudesFechaInstalacion;
               }
               else
               {
                  AV9NewSolicitudes.gxTpr_Solicitudesfechainstalacion = AV27CentroCostosDetallesFecha;
               }
               AV9NewSolicitudes.gxTpr_Solicitudeshorainstalacion = A183SolicitudesHoraInstalacion;
               AV9NewSolicitudes.gxTpr_Solicitudescomentario = A205SolicitudesComentario;
               AV9NewSolicitudes.gxTpr_Metodopagosid = A128MetodoPagosID;
               AV9NewSolicitudes.gxTpr_Solicitudesnota = A261SolicitudesNota;
               AV9NewSolicitudes.gxTpr_Solicitudesnotificacion = A262SolicitudesNotificacion;
               AV9NewSolicitudes.gxTpr_Proveedorid = A133ProveedorID;
               AV9NewSolicitudes.gxTpr_Proveedornombreaux = A533ProveedorNombreAux;
               AV9NewSolicitudes.gxTpr_Solicitudservicioorigenpago = A438SolicitudServicioOrigenPago;
               AV9NewSolicitudes.gxTpr_Solicitudespagado = A441SolicitudesPagado;
               AV9NewSolicitudes.gxTpr_Solicitudserviciocomalmp = (decimal)(0);
               AV9NewSolicitudes.gxTpr_Solicitudserviciocomalm = (decimal)(AV17SubsolicitudCosto*(-1));
               AV9NewSolicitudes.gxTpr_Solicitudesusralta = AV15contextww.gxTpr_Userid;
               AV9NewSolicitudes.gxTpr_Solicitudesusractualizacion = AV15contextww.gxTpr_Userid;
               AV9NewSolicitudes.gxTpr_Solicitudessubtipo = "T";
               /* Using cursor P00IQ3 */
               pr_default.execute(1, new Object[] {AV12SolicitudesID});
               while ( (pr_default.getStatus(1) != 101) )
               {
                  A127SolicitudesID = P00IQ3_A127SolicitudesID[0];
                  A134SolicitudesItemsID = P00IQ3_A134SolicitudesItemsID[0];
                  A121RubrosId = P00IQ3_A121RubrosId[0];
                  A137MedidasID = P00IQ3_A137MedidasID[0];
                  A135InventarioId = P00IQ3_A135InventarioId[0];
                  A177SolicitudesItemsCantidad = P00IQ3_A177SolicitudesItemsCantidad[0];
                  A180SolicitudItemsComision = P00IQ3_A180SolicitudItemsComision[0];
                  A178SolicitudItemsSR = P00IQ3_A178SolicitudItemsSR[0];
                  A179SolicitudItemsComisionTipo = P00IQ3_A179SolicitudItemsComisionTipo[0];
                  AV10NewSolicitudesItem = new SdtSolicitudes_Items(context);
                  AV10NewSolicitudesItem.gxTpr_Solicitudesitemsid = A134SolicitudesItemsID;
                  AV10NewSolicitudesItem.gxTpr_Rubrosid = A121RubrosId;
                  AV10NewSolicitudesItem.gxTpr_Medidasid = A137MedidasID;
                  AV10NewSolicitudesItem.gxTpr_Inventarioid = A135InventarioId;
                  AV10NewSolicitudesItem.gxTpr_Solicitudesitemscantidad = A177SolicitudesItemsCantidad;
                  AV10NewSolicitudesItem.gxTpr_Solicituditemscomision = A180SolicitudItemsComision;
                  AV10NewSolicitudesItem.gxTpr_Solicituditemssr = A178SolicitudItemsSR;
                  AV10NewSolicitudesItem.gxTpr_Solicituditemscomisiontipo = A179SolicitudItemsComisionTipo;
                  AV9NewSolicitudes.gxTpr_Items.Add(AV10NewSolicitudesItem, 0);
                  pr_default.readNext(1);
               }
               pr_default.close(1);
               AV9NewSolicitudes.Insert();
               AV11NewSolicitudId = AV9NewSolicitudes.gxTpr_Solicitudesid_Z;
               /* Using cursor P00IQ4 */
               pr_default.execute(2, new Object[] {AV20CentroCostosId, AV18CentroCostosDetallesId});
               while ( (pr_default.getStatus(2) != 101) )
               {
                  A466CentroCostosDetallesId = P00IQ4_A466CentroCostosDetallesId[0];
                  A461CentroCostosId = P00IQ4_A461CentroCostosId[0];
                  A888CentroCostosDetallesSolId = P00IQ4_A888CentroCostosDetallesSolId[0];
                  A889CentroCostosJson = P00IQ4_A889CentroCostosJson[0];
                  A889CentroCostosJson = P00IQ4_A889CentroCostosJson[0];
                  A888CentroCostosDetallesSolId = AV11NewSolicitudId;
                  AV26CentroCostosIdJson.FromJSonString(A889CentroCostosJson, null);
                  AV26CentroCostosIdJson.Add(AV11NewSolicitudId, 0);
                  A889CentroCostosJson = AV26CentroCostosIdJson.ToJSonString(false);
                  /* Using cursor P00IQ5 */
                  pr_default.execute(3, new Object[] {A889CentroCostosJson, A461CentroCostosId});
                  pr_default.close(3);
                  pr_default.SmartCacheProvider.SetUpdated("CentroCostos");
                  /* Using cursor P00IQ6 */
                  pr_default.execute(4, new Object[] {A888CentroCostosDetallesSolId, A461CentroCostosId, A466CentroCostosDetallesId});
                  pr_default.close(4);
                  pr_default.SmartCacheProvider.SetUpdated("CentroCostosDetalles");
                  /* Exiting from a For First loop. */
                  if (true) break;
               }
               pr_default.close(2);
               /*
                  INSERT RECORD ON TABLE Relaciones

               */
               W127SolicitudesID = A127SolicitudesID;
               A140RelacionesId = 1;
               A127SolicitudesID = AV11NewSolicitudId;
               A120ProfesionalesId = AV19ProfesionalesId;
               A141EstadoSGTipo = context.GetMessage( "STS", "");
               A142EstadoSGId = 1;
               A219SolicitudesRelacionesFechaAlta = DateTimeUtil.ServerNow( context, pr_default);
               A220SolicitudesRelacionesFechaModi = DateTimeUtil.ServerNow( context, pr_default);
               /* Using cursor P00IQ7 */
               pr_default.execute(5, new Object[] {A127SolicitudesID, A140RelacionesId, A120ProfesionalesId, A141EstadoSGTipo, A142EstadoSGId, A219SolicitudesRelacionesFechaAlta, A220SolicitudesRelacionesFechaModi});
               pr_default.close(5);
               pr_default.SmartCacheProvider.SetUpdated("Relaciones");
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
               A127SolicitudesID = W127SolicitudesID;
               /* End Insert */
               if ( AV9NewSolicitudes.Success() )
               {
                  context.CommitDataStores("altasubsolicitud",pr_default);
                  AV8IsOk = true;
               }
               else
               {
                  AV13TxtMsg = AV9NewSolicitudes.GetMessages().ToJSonString(false);
               }
               A127SolicitudesID = W127SolicitudesID;
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(0);
         }
         cleanup();
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
         AV13TxtMsg = "";
         AV15contextww = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         GXt_SdtWWPContext1 = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         P00IQ2_A127SolicitudesID = new long[1] ;
         P00IQ2_A172SolicitudesTelefono = new string[] {""} ;
         P00IQ2_A206SolicitudesMail = new string[] {""} ;
         P00IQ2_n206SolicitudesMail = new bool[] {false} ;
         P00IQ2_A128MetodoPagosID = new long[1] ;
         P00IQ2_A110ZonasID = new long[1] ;
         P00IQ2_n110ZonasID = new bool[] {false} ;
         P00IQ2_A112DepartamentoId = new long[1] ;
         P00IQ2_n112DepartamentoId = new bool[] {false} ;
         P00IQ2_A114DepartamentoMunicipioId = new long[1] ;
         P00IQ2_n114DepartamentoMunicipioId = new bool[] {false} ;
         P00IQ2_A173SolicitudesDireccion = new string[] {""} ;
         P00IQ2_A210SolicitudServicioSolCoti = new string[] {""} ;
         P00IQ2_A130EstadosSolTipo = new string[] {""} ;
         P00IQ2_A201SolicitudesOtros1 = new string[] {""} ;
         P00IQ2_A202SolicitudesOtros2 = new string[] {""} ;
         P00IQ2_A203SolicitudesOtros3 = new string[] {""} ;
         P00IQ2_A184SolicitudesFechaInstalacion = new DateTime[] {DateTime.MinValue} ;
         P00IQ2_A183SolicitudesHoraInstalacion = new string[] {""} ;
         P00IQ2_A205SolicitudesComentario = new string[] {""} ;
         P00IQ2_A261SolicitudesNota = new string[] {""} ;
         P00IQ2_A262SolicitudesNotificacion = new string[] {""} ;
         P00IQ2_A133ProveedorID = new long[1] ;
         P00IQ2_A533ProveedorNombreAux = new string[] {""} ;
         P00IQ2_n533ProveedorNombreAux = new bool[] {false} ;
         P00IQ2_A438SolicitudServicioOrigenPago = new string[] {""} ;
         P00IQ2_n438SolicitudServicioOrigenPago = new bool[] {false} ;
         P00IQ2_A441SolicitudesPagado = new string[] {""} ;
         P00IQ2_n441SolicitudesPagado = new bool[] {false} ;
         A172SolicitudesTelefono = "";
         A206SolicitudesMail = "";
         A173SolicitudesDireccion = "";
         A210SolicitudServicioSolCoti = "";
         A130EstadosSolTipo = "";
         A201SolicitudesOtros1 = "";
         A202SolicitudesOtros2 = "";
         A203SolicitudesOtros3 = "";
         A184SolicitudesFechaInstalacion = DateTime.MinValue;
         A183SolicitudesHoraInstalacion = "";
         A205SolicitudesComentario = "";
         A261SolicitudesNota = "";
         A262SolicitudesNotificacion = "";
         A533ProveedorNombreAux = "";
         A438SolicitudServicioOrigenPago = "";
         A441SolicitudesPagado = "";
         AV9NewSolicitudes = new SdtSolicitudes(context);
         P00IQ3_A127SolicitudesID = new long[1] ;
         P00IQ3_A134SolicitudesItemsID = new short[1] ;
         P00IQ3_A121RubrosId = new short[1] ;
         P00IQ3_A137MedidasID = new long[1] ;
         P00IQ3_A135InventarioId = new long[1] ;
         P00IQ3_A177SolicitudesItemsCantidad = new short[1] ;
         P00IQ3_A180SolicitudItemsComision = new decimal[1] ;
         P00IQ3_A178SolicitudItemsSR = new string[] {""} ;
         P00IQ3_A179SolicitudItemsComisionTipo = new string[] {""} ;
         A178SolicitudItemsSR = "";
         A179SolicitudItemsComisionTipo = "";
         AV10NewSolicitudesItem = new SdtSolicitudes_Items(context);
         P00IQ4_A466CentroCostosDetallesId = new long[1] ;
         P00IQ4_A461CentroCostosId = new long[1] ;
         P00IQ4_A888CentroCostosDetallesSolId = new long[1] ;
         P00IQ4_A889CentroCostosJson = new string[] {""} ;
         A889CentroCostosJson = "";
         AV26CentroCostosIdJson = new GxSimpleCollection<long>();
         A120ProfesionalesId = "";
         A141EstadoSGTipo = "";
         A219SolicitudesRelacionesFechaAlta = (DateTime)(DateTime.MinValue);
         A220SolicitudesRelacionesFechaModi = (DateTime)(DateTime.MinValue);
         Gx_emsg = "";
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.altasubsolicitud__datastore1(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.altasubsolicitud__default(),
            new Object[][] {
                new Object[] {
               P00IQ2_A127SolicitudesID, P00IQ2_A172SolicitudesTelefono, P00IQ2_A206SolicitudesMail, P00IQ2_n206SolicitudesMail, P00IQ2_A128MetodoPagosID, P00IQ2_A110ZonasID, P00IQ2_n110ZonasID, P00IQ2_A112DepartamentoId, P00IQ2_n112DepartamentoId, P00IQ2_A114DepartamentoMunicipioId,
               P00IQ2_n114DepartamentoMunicipioId, P00IQ2_A173SolicitudesDireccion, P00IQ2_A210SolicitudServicioSolCoti, P00IQ2_A130EstadosSolTipo, P00IQ2_A201SolicitudesOtros1, P00IQ2_A202SolicitudesOtros2, P00IQ2_A203SolicitudesOtros3, P00IQ2_A184SolicitudesFechaInstalacion, P00IQ2_A183SolicitudesHoraInstalacion, P00IQ2_A205SolicitudesComentario,
               P00IQ2_A261SolicitudesNota, P00IQ2_A262SolicitudesNotificacion, P00IQ2_A133ProveedorID, P00IQ2_A533ProveedorNombreAux, P00IQ2_n533ProveedorNombreAux, P00IQ2_A438SolicitudServicioOrigenPago, P00IQ2_n438SolicitudServicioOrigenPago, P00IQ2_A441SolicitudesPagado, P00IQ2_n441SolicitudesPagado
               }
               , new Object[] {
               P00IQ3_A127SolicitudesID, P00IQ3_A134SolicitudesItemsID, P00IQ3_A121RubrosId, P00IQ3_A137MedidasID, P00IQ3_A135InventarioId, P00IQ3_A177SolicitudesItemsCantidad, P00IQ3_A180SolicitudItemsComision, P00IQ3_A178SolicitudItemsSR, P00IQ3_A179SolicitudItemsComisionTipo
               }
               , new Object[] {
               P00IQ4_A466CentroCostosDetallesId, P00IQ4_A461CentroCostosId, P00IQ4_A888CentroCostosDetallesSolId, P00IQ4_A889CentroCostosJson
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short A134SolicitudesItemsID ;
      private short A121RubrosId ;
      private short A177SolicitudesItemsCantidad ;
      private int GX_INS32 ;
      private int A142EstadoSGId ;
      private long AV20CentroCostosId ;
      private long AV18CentroCostosDetallesId ;
      private long AV28CentroCostosDetallesEstado ;
      private long AV12SolicitudesID ;
      private long AV11NewSolicitudId ;
      private long A127SolicitudesID ;
      private long A128MetodoPagosID ;
      private long A110ZonasID ;
      private long A112DepartamentoId ;
      private long A114DepartamentoMunicipioId ;
      private long A133ProveedorID ;
      private long W127SolicitudesID ;
      private long A137MedidasID ;
      private long A135InventarioId ;
      private long A466CentroCostosDetallesId ;
      private long A461CentroCostosId ;
      private long A888CentroCostosDetallesSolId ;
      private long A140RelacionesId ;
      private decimal AV17SubsolicitudCosto ;
      private decimal A180SolicitudItemsComision ;
      private string AV16SubsolicitudNombre ;
      private string AV19ProfesionalesId ;
      private string A172SolicitudesTelefono ;
      private string A210SolicitudServicioSolCoti ;
      private string A130EstadosSolTipo ;
      private string A201SolicitudesOtros1 ;
      private string A202SolicitudesOtros2 ;
      private string A203SolicitudesOtros3 ;
      private string A183SolicitudesHoraInstalacion ;
      private string A261SolicitudesNota ;
      private string A262SolicitudesNotificacion ;
      private string A533ProveedorNombreAux ;
      private string A438SolicitudServicioOrigenPago ;
      private string A441SolicitudesPagado ;
      private string A178SolicitudItemsSR ;
      private string A179SolicitudItemsComisionTipo ;
      private string A120ProfesionalesId ;
      private string A141EstadoSGTipo ;
      private string Gx_emsg ;
      private DateTime A219SolicitudesRelacionesFechaAlta ;
      private DateTime A220SolicitudesRelacionesFechaModi ;
      private DateTime AV27CentroCostosDetallesFecha ;
      private DateTime A184SolicitudesFechaInstalacion ;
      private bool AV8IsOk ;
      private bool n206SolicitudesMail ;
      private bool n110ZonasID ;
      private bool n112DepartamentoId ;
      private bool n114DepartamentoMunicipioId ;
      private bool n533ProveedorNombreAux ;
      private bool n438SolicitudServicioOrigenPago ;
      private bool n441SolicitudesPagado ;
      private string A205SolicitudesComentario ;
      private string A889CentroCostosJson ;
      private string AV13TxtMsg ;
      private string A206SolicitudesMail ;
      private string A173SolicitudesDireccion ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV15contextww ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext GXt_SdtWWPContext1 ;
      private IDataStoreProvider pr_default ;
      private long[] P00IQ2_A127SolicitudesID ;
      private string[] P00IQ2_A172SolicitudesTelefono ;
      private string[] P00IQ2_A206SolicitudesMail ;
      private bool[] P00IQ2_n206SolicitudesMail ;
      private long[] P00IQ2_A128MetodoPagosID ;
      private long[] P00IQ2_A110ZonasID ;
      private bool[] P00IQ2_n110ZonasID ;
      private long[] P00IQ2_A112DepartamentoId ;
      private bool[] P00IQ2_n112DepartamentoId ;
      private long[] P00IQ2_A114DepartamentoMunicipioId ;
      private bool[] P00IQ2_n114DepartamentoMunicipioId ;
      private string[] P00IQ2_A173SolicitudesDireccion ;
      private string[] P00IQ2_A210SolicitudServicioSolCoti ;
      private string[] P00IQ2_A130EstadosSolTipo ;
      private string[] P00IQ2_A201SolicitudesOtros1 ;
      private string[] P00IQ2_A202SolicitudesOtros2 ;
      private string[] P00IQ2_A203SolicitudesOtros3 ;
      private DateTime[] P00IQ2_A184SolicitudesFechaInstalacion ;
      private string[] P00IQ2_A183SolicitudesHoraInstalacion ;
      private string[] P00IQ2_A205SolicitudesComentario ;
      private string[] P00IQ2_A261SolicitudesNota ;
      private string[] P00IQ2_A262SolicitudesNotificacion ;
      private long[] P00IQ2_A133ProveedorID ;
      private string[] P00IQ2_A533ProveedorNombreAux ;
      private bool[] P00IQ2_n533ProveedorNombreAux ;
      private string[] P00IQ2_A438SolicitudServicioOrigenPago ;
      private bool[] P00IQ2_n438SolicitudServicioOrigenPago ;
      private string[] P00IQ2_A441SolicitudesPagado ;
      private bool[] P00IQ2_n441SolicitudesPagado ;
      private SdtSolicitudes AV9NewSolicitudes ;
      private long[] P00IQ3_A127SolicitudesID ;
      private short[] P00IQ3_A134SolicitudesItemsID ;
      private short[] P00IQ3_A121RubrosId ;
      private long[] P00IQ3_A137MedidasID ;
      private long[] P00IQ3_A135InventarioId ;
      private short[] P00IQ3_A177SolicitudesItemsCantidad ;
      private decimal[] P00IQ3_A180SolicitudItemsComision ;
      private string[] P00IQ3_A178SolicitudItemsSR ;
      private string[] P00IQ3_A179SolicitudItemsComisionTipo ;
      private SdtSolicitudes_Items AV10NewSolicitudesItem ;
      private long[] P00IQ4_A466CentroCostosDetallesId ;
      private long[] P00IQ4_A461CentroCostosId ;
      private long[] P00IQ4_A888CentroCostosDetallesSolId ;
      private string[] P00IQ4_A889CentroCostosJson ;
      private GxSimpleCollection<long> AV26CentroCostosIdJson ;
      private long aP8_NewSolicitudId ;
      private bool aP9_IsOk ;
      private string aP10_TxtMsg ;
      private IDataStoreProvider pr_datastore1 ;
   }

   public class altasubsolicitud__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class altasubsolicitud__default : DataStoreHelperBase, IDataStoreHelper
 {
    public ICursor[] getCursors( )
    {
       cursorDefinitions();
       return new Cursor[] {
        new ForEachCursor(def[0])
       ,new ForEachCursor(def[1])
       ,new ForEachCursor(def[2])
       ,new UpdateCursor(def[3])
       ,new UpdateCursor(def[4])
       ,new UpdateCursor(def[5])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmP00IQ2;
        prmP00IQ2 = new Object[] {
        new ParDef("@AV12SolicitudesID",GXType.Decimal,18,0)
        };
        Object[] prmP00IQ3;
        prmP00IQ3 = new Object[] {
        new ParDef("@AV12SolicitudesID",GXType.Decimal,18,0)
        };
        Object[] prmP00IQ4;
        prmP00IQ4 = new Object[] {
        new ParDef("@AV20CentroCostosId",GXType.Decimal,18,0) ,
        new ParDef("@AV18CentroCostosDetallesId",GXType.Decimal,18,0)
        };
        Object[] prmP00IQ5;
        prmP00IQ5 = new Object[] {
        new ParDef("@CentroCostosJson",GXType.NVarChar,2097152,0) ,
        new ParDef("@CentroCostosId",GXType.Decimal,18,0)
        };
        Object[] prmP00IQ6;
        prmP00IQ6 = new Object[] {
        new ParDef("@CentroCostosDetallesSolId",GXType.Decimal,18,0) ,
        new ParDef("@CentroCostosId",GXType.Decimal,18,0) ,
        new ParDef("@CentroCostosDetallesId",GXType.Decimal,18,0)
        };
        Object[] prmP00IQ7;
        prmP00IQ7 = new Object[] {
        new ParDef("@SolicitudesID",GXType.Decimal,18,0) ,
        new ParDef("@RelacionesId",GXType.Decimal,18,0) ,
        new ParDef("@ProfesionalesId",GXType.Char,20,0) ,
        new ParDef("@EstadoSGTipo",GXType.NChar,3,0) ,
        new ParDef("@EstadoSGId",GXType.Int32,5,0) ,
        new ParDef("@SolicitudesRelacionesFechaAlta",GXType.DateTime,8,5) ,
        new ParDef("@SolicitudesRelacionesFechaModi",GXType.DateTime,8,5)
        };
        def= new CursorDef[] {
            new CursorDef("P00IQ2", "SELECT [SolicitudesID], [SolicitudesTelefono], [SolicitudesMail], [MetodoPagosID], [ZonasID], [DepartamentoId], [DepartamentoMunicipioId], [SolicitudesDireccion], [SolicitudServicioSolCoti], [EstadosSolTipo], [SolicitudesOtros1], [SolicitudesOtros2], [SolicitudesOtros3], [SolicitudesFechaInstalacion], [SolicitudesHoraInstalacion], [SolicitudesComentario], [SolicitudesNota], [SolicitudesNotificacion], [ProveedorID], [ProveedorNombreAux], [SolicitudServicioOrigenPago], [SolicitudesPagado] FROM [Solicitudes] WHERE [SolicitudesID] = @AV12SolicitudesID ORDER BY [SolicitudesID] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00IQ2,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("P00IQ3", "SELECT [SolicitudesID], [SolicitudesItemsID], [RubrosId], [MedidasID], [InventarioId], [SolicitudesItemsCantidad], [SolicitudItemsComision], [SolicitudItemsSR], [SolicitudItemsComisionTipo] FROM [SolicitudesItems] WHERE [SolicitudesID] = @AV12SolicitudesID ORDER BY [SolicitudesID] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00IQ3,100, GxCacheFrequency.OFF ,false,false )
           ,new CursorDef("P00IQ4", "SELECT T1.[CentroCostosDetallesId], T1.[CentroCostosId], T1.[CentroCostosDetallesSolId], T2.[CentroCostosJson] FROM ([CentroCostosDetalles] T1 WITH (UPDLOCK) INNER JOIN [CentroCostos] T2 WITH (UPDLOCK) ON T2.[CentroCostosId] = T1.[CentroCostosId]) WHERE T1.[CentroCostosId] = @AV20CentroCostosId and T1.[CentroCostosDetallesId] = @AV18CentroCostosDetallesId ORDER BY T1.[CentroCostosId], T1.[CentroCostosDetallesId] ",true, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00IQ4,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("P00IQ5", "UPDATE [CentroCostos] SET [CentroCostosJson]=@CentroCostosJson  WHERE [CentroCostosId] = @CentroCostosId", GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP00IQ5)
           ,new CursorDef("P00IQ6", "UPDATE [CentroCostosDetalles] SET [CentroCostosDetallesSolId]=@CentroCostosDetallesSolId  WHERE [CentroCostosId] = @CentroCostosId AND [CentroCostosDetallesId] = @CentroCostosDetallesId", GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP00IQ6)
           ,new CursorDef("P00IQ7", "INSERT INTO [Relaciones]([SolicitudesID], [RelacionesId], [ProfesionalesId], [EstadoSGTipo], [EstadoSGId], [SolicitudesRelacionesFechaAlta], [SolicitudesRelacionesFechaModi]) VALUES(@SolicitudesID, @RelacionesId, @ProfesionalesId, @EstadoSGTipo, @EstadoSGId, @SolicitudesRelacionesFechaAlta, @SolicitudesRelacionesFechaModi)", GxErrorMask.GX_NOMASK,prmP00IQ7)
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
              ((string[]) buf[1])[0] = rslt.getString(2, 20);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((bool[]) buf[3])[0] = rslt.wasNull(3);
              ((long[]) buf[4])[0] = rslt.getLong(4);
              ((long[]) buf[5])[0] = rslt.getLong(5);
              ((bool[]) buf[6])[0] = rslt.wasNull(5);
              ((long[]) buf[7])[0] = rslt.getLong(6);
              ((bool[]) buf[8])[0] = rslt.wasNull(6);
              ((long[]) buf[9])[0] = rslt.getLong(7);
              ((bool[]) buf[10])[0] = rslt.wasNull(7);
              ((string[]) buf[11])[0] = rslt.getVarchar(8);
              ((string[]) buf[12])[0] = rslt.getString(9, 1);
              ((string[]) buf[13])[0] = rslt.getString(10, 3);
              ((string[]) buf[14])[0] = rslt.getString(11, 1);
              ((string[]) buf[15])[0] = rslt.getString(12, 1000);
              ((string[]) buf[16])[0] = rslt.getString(13, 500);
              ((DateTime[]) buf[17])[0] = rslt.getGXDate(14);
              ((string[]) buf[18])[0] = rslt.getString(15, 1);
              ((string[]) buf[19])[0] = rslt.getLongVarchar(16);
              ((string[]) buf[20])[0] = rslt.getString(17, 500);
              ((string[]) buf[21])[0] = rslt.getString(18, 1);
              ((long[]) buf[22])[0] = rslt.getLong(19);
              ((string[]) buf[23])[0] = rslt.getString(20, 80);
              ((bool[]) buf[24])[0] = rslt.wasNull(20);
              ((string[]) buf[25])[0] = rslt.getString(21, 1);
              ((bool[]) buf[26])[0] = rslt.wasNull(21);
              ((string[]) buf[27])[0] = rslt.getString(22, 1);
              ((bool[]) buf[28])[0] = rslt.wasNull(22);
              return;
           case 1 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              ((short[]) buf[2])[0] = rslt.getShort(3);
              ((long[]) buf[3])[0] = rslt.getLong(4);
              ((long[]) buf[4])[0] = rslt.getLong(5);
              ((short[]) buf[5])[0] = rslt.getShort(6);
              ((decimal[]) buf[6])[0] = rslt.getDecimal(7);
              ((string[]) buf[7])[0] = rslt.getString(8, 1);
              ((string[]) buf[8])[0] = rslt.getString(9, 1);
              return;
           case 2 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              ((long[]) buf[2])[0] = rslt.getLong(3);
              ((string[]) buf[3])[0] = rslt.getLongVarchar(4);
              return;
     }
  }

}

}

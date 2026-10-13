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
namespace GeneXus.Programs.apis {
   public class oultsolcalificadasprof : GXProcedure
   {
      public oultsolcalificadasprof( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public oultsolcalificadasprof( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_User ,
                           string aP1_ProfesionalId ,
                           out short aP2_Gx_restcode ,
                           out string aP3_RestMessage ,
                           out GXBaseCollection<SdtSDTSolicitudes> aP4_SdtSolicitudes )
      {
         this.AV27User = aP0_User;
         this.AV18ProfesionalId = aP1_ProfesionalId;
         this.Gx_restcode = 0 ;
         this.AV21RestMessage = "" ;
         this.AV22SdtSolicitudes = new GXBaseCollection<SdtSDTSolicitudes>( context, "SDTSolicitudes", "AlmangoX") ;
         initialize();
         ExecutePrivate();
         aP2_Gx_restcode=this.Gx_restcode;
         aP3_RestMessage=this.AV21RestMessage;
         aP4_SdtSolicitudes=this.AV22SdtSolicitudes;
      }

      public GXBaseCollection<SdtSDTSolicitudes> executeUdp( string aP0_User ,
                                                             string aP1_ProfesionalId ,
                                                             out short aP2_Gx_restcode ,
                                                             out string aP3_RestMessage )
      {
         execute(aP0_User, aP1_ProfesionalId, out aP2_Gx_restcode, out aP3_RestMessage, out aP4_SdtSolicitudes);
         return AV22SdtSolicitudes ;
      }

      public void executeSubmit( string aP0_User ,
                                 string aP1_ProfesionalId ,
                                 out short aP2_Gx_restcode ,
                                 out string aP3_RestMessage ,
                                 out GXBaseCollection<SdtSDTSolicitudes> aP4_SdtSolicitudes )
      {
         this.AV27User = aP0_User;
         this.AV18ProfesionalId = aP1_ProfesionalId;
         this.Gx_restcode = 0 ;
         this.AV21RestMessage = "" ;
         this.AV22SdtSolicitudes = new GXBaseCollection<SdtSDTSolicitudes>( context, "SDTSolicitudes", "AlmangoX") ;
         SubmitImpl();
         aP2_Gx_restcode=this.Gx_restcode;
         aP3_RestMessage=this.AV21RestMessage;
         aP4_SdtSolicitudes=this.AV22SdtSolicitudes;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV18ProfesionalId)) || String.IsNullOrEmpty(StringUtil.RTrim( AV27User)) )
         {
            AV21RestMessage = context.GetMessage( "Error de parámetros al procesar la solicitud", "");
            Gx_restcode = 400;
            cleanup();
            if (true) return;
         }
         new GeneXus.Programs.apis.otokenfromcookie(context ).execute(  AV29HttpRequest, out  AV28TokenId) ;
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV28TokenId)) )
         {
            Gx_restcode = 401;
            AV21RestMessage = "Token faltante";
            cleanup();
            if (true) return;
         }
         new GeneXus.Programs.apis.validaracceso(context ).execute(  AV27User,  AV18ProfesionalId,  AV28TokenId, out  AV30EsValido, out  AV31TokenDesencriptado) ;
         if ( ! AV30EsValido )
         {
            Gx_restcode = 401;
            AV21RestMessage = context.GetMessage( "No autorizado o token inválido.", "");
            cleanup();
            if (true) return;
         }
         AV8Counter = 0;
         AV33GXLvl25 = 0;
         /* Using cursor P00JJ2 */
         pr_default.execute(0, new Object[] {AV18ProfesionalId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A120ProfesionalesId = P00JJ2_A120ProfesionalesId[0];
            AV33GXLvl25 = 1;
            GXPagingIdx3 = 0;
            GXPagingTo3 = 6;
            /* Using cursor P00JJ3 */
            pr_default.execute(1, new Object[] {A120ProfesionalesId});
            while ( ( (pr_default.getStatus(1) != 101) ) && ( ( GXPagingTo3 == 0 ) || ( GXPagingIdx3 < GXPagingTo3 ) ) )
            {
               A131EstadosSolId = P00JJ3_A131EstadosSolId[0];
               A130EstadosSolTipo = P00JJ3_A130EstadosSolTipo[0];
               A127SolicitudesID = P00JJ3_A127SolicitudesID[0];
               A171SolicitudesNombre = P00JJ3_A171SolicitudesNombre[0];
               A132EstadosSolNombre = P00JJ3_A132EstadosSolNombre[0];
               A182SolicitudesFechaAlta = P00JJ3_A182SolicitudesFechaAlta[0];
               n182SolicitudesFechaAlta = P00JJ3_n182SolicitudesFechaAlta[0];
               A173SolicitudesDireccion = P00JJ3_A173SolicitudesDireccion[0];
               A184SolicitudesFechaInstalacion = P00JJ3_A184SolicitudesFechaInstalacion[0];
               A183SolicitudesHoraInstalacion = P00JJ3_A183SolicitudesHoraInstalacion[0];
               A172SolicitudesTelefono = P00JJ3_A172SolicitudesTelefono[0];
               A206SolicitudesMail = P00JJ3_A206SolicitudesMail[0];
               n206SolicitudesMail = P00JJ3_n206SolicitudesMail[0];
               A112DepartamentoId = P00JJ3_A112DepartamentoId[0];
               n112DepartamentoId = P00JJ3_n112DepartamentoId[0];
               A113DepartamentoDepartamento = P00JJ3_A113DepartamentoDepartamento[0];
               A114DepartamentoMunicipioId = P00JJ3_A114DepartamentoMunicipioId[0];
               n114DepartamentoMunicipioId = P00JJ3_n114DepartamentoMunicipioId[0];
               A115DepartamentoMunicipioNombre = P00JJ3_A115DepartamentoMunicipioNombre[0];
               A110ZonasID = P00JJ3_A110ZonasID[0];
               n110ZonasID = P00JJ3_n110ZonasID[0];
               A194SolicitudesAutoEnumerar = P00JJ3_A194SolicitudesAutoEnumerar[0];
               A210SolicitudServicioSolCoti = P00JJ3_A210SolicitudServicioSolCoti[0];
               A212SolicitudesCotizacion = P00JJ3_A212SolicitudesCotizacion[0];
               A205SolicitudesComentario = P00JJ3_A205SolicitudesComentario[0];
               A128MetodoPagosID = P00JJ3_A128MetodoPagosID[0];
               A261SolicitudesNota = P00JJ3_A261SolicitudesNota[0];
               A262SolicitudesNotificacion = P00JJ3_A262SolicitudesNotificacion[0];
               A204SolicitudesFechaActualizacion = P00JJ3_A204SolicitudesFechaActualizacion[0];
               n204SolicitudesFechaActualizacion = P00JJ3_n204SolicitudesFechaActualizacion[0];
               A140RelacionesId = P00JJ3_A140RelacionesId[0];
               A131EstadosSolId = P00JJ3_A131EstadosSolId[0];
               A130EstadosSolTipo = P00JJ3_A130EstadosSolTipo[0];
               A171SolicitudesNombre = P00JJ3_A171SolicitudesNombre[0];
               A182SolicitudesFechaAlta = P00JJ3_A182SolicitudesFechaAlta[0];
               n182SolicitudesFechaAlta = P00JJ3_n182SolicitudesFechaAlta[0];
               A173SolicitudesDireccion = P00JJ3_A173SolicitudesDireccion[0];
               A184SolicitudesFechaInstalacion = P00JJ3_A184SolicitudesFechaInstalacion[0];
               A183SolicitudesHoraInstalacion = P00JJ3_A183SolicitudesHoraInstalacion[0];
               A172SolicitudesTelefono = P00JJ3_A172SolicitudesTelefono[0];
               A206SolicitudesMail = P00JJ3_A206SolicitudesMail[0];
               n206SolicitudesMail = P00JJ3_n206SolicitudesMail[0];
               A112DepartamentoId = P00JJ3_A112DepartamentoId[0];
               n112DepartamentoId = P00JJ3_n112DepartamentoId[0];
               A114DepartamentoMunicipioId = P00JJ3_A114DepartamentoMunicipioId[0];
               n114DepartamentoMunicipioId = P00JJ3_n114DepartamentoMunicipioId[0];
               A110ZonasID = P00JJ3_A110ZonasID[0];
               n110ZonasID = P00JJ3_n110ZonasID[0];
               A194SolicitudesAutoEnumerar = P00JJ3_A194SolicitudesAutoEnumerar[0];
               A210SolicitudServicioSolCoti = P00JJ3_A210SolicitudServicioSolCoti[0];
               A212SolicitudesCotizacion = P00JJ3_A212SolicitudesCotizacion[0];
               A205SolicitudesComentario = P00JJ3_A205SolicitudesComentario[0];
               A128MetodoPagosID = P00JJ3_A128MetodoPagosID[0];
               A261SolicitudesNota = P00JJ3_A261SolicitudesNota[0];
               A262SolicitudesNotificacion = P00JJ3_A262SolicitudesNotificacion[0];
               A204SolicitudesFechaActualizacion = P00JJ3_A204SolicitudesFechaActualizacion[0];
               n204SolicitudesFechaActualizacion = P00JJ3_n204SolicitudesFechaActualizacion[0];
               A132EstadosSolNombre = P00JJ3_A132EstadosSolNombre[0];
               A113DepartamentoDepartamento = P00JJ3_A113DepartamentoDepartamento[0];
               A115DepartamentoMunicipioNombre = P00JJ3_A115DepartamentoMunicipioNombre[0];
               if ( StringUtil.StrCmp(A130EstadosSolTipo, context.GetMessage( "SOL", "")) == 0 )
               {
                  GetSolicitudesTotal( A127SolicitudesID) ;
                  GXPagingIdx3 = (int)(GXPagingIdx3+1);
                  new GeneXus.Programs.apis.odetallecobroprofsol(context ).execute(  A127SolicitudesID,  AV18ProfesionalId, out  AV14ModoPago, out  AV9Deduccion, out  AV11Ganancia) ;
                  AV24Solicitud = new SdtSDTSolicitudes(context);
                  AV24Solicitud.gxTpr_Solicitudesid = A127SolicitudesID;
                  AV24Solicitud.gxTpr_Solicitudesnombre = A171SolicitudesNombre;
                  AV24Solicitud.gxTpr_Estadossolid = A131EstadosSolId;
                  AV24Solicitud.gxTpr_Estadossolnombre = A132EstadosSolNombre;
                  AV24Solicitud.gxTpr_Solicitudesfechaalta = A182SolicitudesFechaAlta;
                  AV24Solicitud.gxTpr_Solicitudesdireccion = A173SolicitudesDireccion;
                  AV24Solicitud.gxTpr_Solicitudesfechainstalacion = A184SolicitudesFechaInstalacion;
                  AV24Solicitud.gxTpr_Solicitudeshorainstalacion = A183SolicitudesHoraInstalacion;
                  AV24Solicitud.gxTpr_Solicitudestelefono = A172SolicitudesTelefono;
                  AV24Solicitud.gxTpr_Solicitudesmail = A206SolicitudesMail;
                  AV24Solicitud.gxTpr_Departamentoid = A112DepartamentoId;
                  AV24Solicitud.gxTpr_Departamentonombre = A113DepartamentoDepartamento;
                  AV24Solicitud.gxTpr_Departamentomunicipioid = A114DepartamentoMunicipioId;
                  AV24Solicitud.gxTpr_Municipionombre = A115DepartamentoMunicipioNombre;
                  AV24Solicitud.gxTpr_Zonasid = A110ZonasID;
                  AV24Solicitud.gxTpr_Solicitudesautoenumerar = A194SolicitudesAutoEnumerar;
                  AV24Solicitud.gxTpr_Solicitudserviciosolcoti = A210SolicitudServicioSolCoti;
                  AV24Solicitud.gxTpr_Solicitudescotizacion = A212SolicitudesCotizacion;
                  AV24Solicitud.gxTpr_Estadossoltipo = A130EstadosSolTipo;
                  AV24Solicitud.gxTpr_Solicitudesfechaactualizacion = A204SolicitudesFechaActualizacion;
                  AV24Solicitud.gxTpr_Solicitudescomentario = A205SolicitudesComentario;
                  AV24Solicitud.gxTpr_Metodopagosid = A128MetodoPagosID;
                  AV24Solicitud.gxTpr_Solicitudesnota = A261SolicitudesNota;
                  AV24Solicitud.gxTpr_Solicitudesnotificacion = A262SolicitudesNotificacion;
                  AV24Solicitud.gxTpr_Solicitudestotal = A174SolicitudesTotal;
                  AV24Solicitud.gxTpr_Deduccion = AV9Deduccion;
                  AV24Solicitud.gxTpr_Modopago = AV14ModoPago;
                  AV24Solicitud.gxTpr_Ganancia = AV11Ganancia;
                  /* Using cursor P00JJ4 */
                  pr_default.execute(2, new Object[] {AV24Solicitud.gxTpr_Solicitudesid});
                  while ( (pr_default.getStatus(2) != 101) )
                  {
                     A127SolicitudesID = P00JJ4_A127SolicitudesID[0];
                     A134SolicitudesItemsID = P00JJ4_A134SolicitudesItemsID[0];
                     A177SolicitudesItemsCantidad = P00JJ4_A177SolicitudesItemsCantidad[0];
                     A121RubrosId = P00JJ4_A121RubrosId[0];
                     A122RubrosNombre = P00JJ4_A122RubrosNombre[0];
                     A122RubrosNombre = P00JJ4_A122RubrosNombre[0];
                     AV13Item = new SdtSDTSolicitudes_Items(context);
                     AV13Item.gxTpr_Solicitudesitemsid = A134SolicitudesItemsID;
                     AV13Item.gxTpr_Solicitudesitemscantidad = A177SolicitudesItemsCantidad;
                     AV13Item.gxTpr_Rubrosid = A121RubrosId;
                     AV13Item.gxTpr_Rubrosnombre = A122RubrosNombre;
                     AV24Solicitud.gxTpr_Items.Add(AV13Item, 0);
                     pr_default.readNext(2);
                  }
                  pr_default.close(2);
                  /* Using cursor P00JJ5 */
                  pr_default.execute(3, new Object[] {A127SolicitudesID});
                  while ( (pr_default.getStatus(3) != 101) )
                  {
                     A272FeedBackSolicitudId = P00JJ5_A272FeedBackSolicitudId[0];
                     A117FeedBackId = P00JJ5_A117FeedBackId[0];
                     A275FeedBackNum = P00JJ5_A275FeedBackNum[0];
                     A271FeedBackComentario = P00JJ5_A271FeedBackComentario[0];
                     A276FeedBackFechaAlta = P00JJ5_A276FeedBackFechaAlta[0];
                     AV24Solicitud.gxTpr_Feedbackid = A117FeedBackId;
                     AV24Solicitud.gxTpr_Feedbacknum = A275FeedBackNum;
                     AV24Solicitud.gxTpr_Feedbackcomentario = A271FeedBackComentario;
                     AV24Solicitud.gxTpr_Feedbackfechaalta = A276FeedBackFechaAlta;
                     pr_default.readNext(3);
                  }
                  pr_default.close(3);
                  AV22SdtSolicitudes.Add(AV24Solicitud, 0);
               }
               pr_default.readNext(1);
            }
            pr_default.close(1);
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(0);
         if ( AV33GXLvl25 == 0 )
         {
            AV21RestMessage = context.GetMessage( "No se encontraron solicitudes disponibles", "");
            AV19ResCode = 200;
            cleanup();
            if (true) return;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV21RestMessage)) )
         {
            AV21RestMessage = context.GetMessage( "Respuesta procesada con éxito", "");
            AV19ResCode = 200;
         }
         cleanup();
      }

      protected void GetSolicitudesTotal( long A127SolicitudesID )
      {
         /* Create private dbobjects */
         /* Navigation */
         A174SolicitudesTotal = 0;
         /* Using cursor P00JJ6 */
         pr_default.execute(4, new Object[] {A127SolicitudesID});
         while ( (pr_default.getStatus(4) != 101) && ( P00JJ6_A127SolicitudesID[0] == A127SolicitudesID ) )
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( P00JJ6_A178SolicitudItemsSR[0])) || ( StringUtil.StrCmp(P00JJ6_A179SolicitudItemsComisionTipo[0], "N") == 0 ) )
            {
               A175SolicitudesItemsPrecioInstalac = (decimal)((P00JJ6_A176SolicitudesItemsPrecioFinal[0]*P00JJ6_A177SolicitudesItemsCantidad[0]));
            }
            else
            {
               if ( ( StringUtil.StrCmp(P00JJ6_A179SolicitudItemsComisionTipo[0], "F") == 0 ) && ( StringUtil.StrCmp(P00JJ6_A178SolicitudItemsSR[0], "R") == 0 ) )
               {
                  A175SolicitudesItemsPrecioInstalac = (decimal)((P00JJ6_A176SolicitudesItemsPrecioFinal[0]*P00JJ6_A177SolicitudesItemsCantidad[0])-(P00JJ6_A180SolicitudItemsComision[0]*P00JJ6_A177SolicitudesItemsCantidad[0]));
               }
               else
               {
                  if ( ( StringUtil.StrCmp(P00JJ6_A179SolicitudItemsComisionTipo[0], "F") == 0 ) && ( StringUtil.StrCmp(P00JJ6_A178SolicitudItemsSR[0], "S") == 0 ) )
                  {
                     A175SolicitudesItemsPrecioInstalac = (decimal)((P00JJ6_A176SolicitudesItemsPrecioFinal[0]*P00JJ6_A177SolicitudesItemsCantidad[0])+(P00JJ6_A180SolicitudItemsComision[0]*P00JJ6_A177SolicitudesItemsCantidad[0]));
                  }
                  else
                  {
                     if ( ( StringUtil.StrCmp(P00JJ6_A179SolicitudItemsComisionTipo[0], "P") == 0 ) && ( StringUtil.StrCmp(P00JJ6_A178SolicitudItemsSR[0], "R") == 0 ) )
                     {
                        A175SolicitudesItemsPrecioInstalac = (decimal)((P00JJ6_A176SolicitudesItemsPrecioFinal[0]*P00JJ6_A177SolicitudesItemsCantidad[0])-((P00JJ6_A176SolicitudesItemsPrecioFinal[0]*P00JJ6_A177SolicitudesItemsCantidad[0])*(P00JJ6_A180SolicitudItemsComision[0]/ (decimal)(100))));
                     }
                     else
                     {
                        if ( ( StringUtil.StrCmp(P00JJ6_A179SolicitudItemsComisionTipo[0], "P") == 0 ) && ( StringUtil.StrCmp(P00JJ6_A178SolicitudItemsSR[0], "S") == 0 ) )
                        {
                           A175SolicitudesItemsPrecioInstalac = (decimal)((P00JJ6_A176SolicitudesItemsPrecioFinal[0]*P00JJ6_A177SolicitudesItemsCantidad[0])+((P00JJ6_A176SolicitudesItemsPrecioFinal[0]*P00JJ6_A177SolicitudesItemsCantidad[0])*(P00JJ6_A180SolicitudItemsComision[0]/ (decimal)(100))));
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
            pr_default.readNext(4);
         }
         pr_default.close(4);
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
         AV21RestMessage = "";
         AV22SdtSolicitudes = new GXBaseCollection<SdtSDTSolicitudes>( context, "SDTSolicitudes", "AlmangoX");
         AV29HttpRequest = new GxHttpRequest( context);
         AV28TokenId = "";
         AV31TokenDesencriptado = "";
         P00JJ2_A120ProfesionalesId = new string[] {""} ;
         A120ProfesionalesId = "";
         P00JJ3_A120ProfesionalesId = new string[] {""} ;
         P00JJ3_A131EstadosSolId = new int[1] ;
         P00JJ3_A130EstadosSolTipo = new string[] {""} ;
         P00JJ3_A127SolicitudesID = new long[1] ;
         P00JJ3_A171SolicitudesNombre = new string[] {""} ;
         P00JJ3_A132EstadosSolNombre = new string[] {""} ;
         P00JJ3_A182SolicitudesFechaAlta = new DateTime[] {DateTime.MinValue} ;
         P00JJ3_n182SolicitudesFechaAlta = new bool[] {false} ;
         P00JJ3_A173SolicitudesDireccion = new string[] {""} ;
         P00JJ3_A184SolicitudesFechaInstalacion = new DateTime[] {DateTime.MinValue} ;
         P00JJ3_A183SolicitudesHoraInstalacion = new string[] {""} ;
         P00JJ3_A172SolicitudesTelefono = new string[] {""} ;
         P00JJ3_A206SolicitudesMail = new string[] {""} ;
         P00JJ3_n206SolicitudesMail = new bool[] {false} ;
         P00JJ3_A112DepartamentoId = new long[1] ;
         P00JJ3_n112DepartamentoId = new bool[] {false} ;
         P00JJ3_A113DepartamentoDepartamento = new string[] {""} ;
         P00JJ3_A114DepartamentoMunicipioId = new long[1] ;
         P00JJ3_n114DepartamentoMunicipioId = new bool[] {false} ;
         P00JJ3_A115DepartamentoMunicipioNombre = new string[] {""} ;
         P00JJ3_A110ZonasID = new long[1] ;
         P00JJ3_n110ZonasID = new bool[] {false} ;
         P00JJ3_A194SolicitudesAutoEnumerar = new short[1] ;
         P00JJ3_A210SolicitudServicioSolCoti = new string[] {""} ;
         P00JJ3_A212SolicitudesCotizacion = new decimal[1] ;
         P00JJ3_A205SolicitudesComentario = new string[] {""} ;
         P00JJ3_A128MetodoPagosID = new long[1] ;
         P00JJ3_A261SolicitudesNota = new string[] {""} ;
         P00JJ3_A262SolicitudesNotificacion = new string[] {""} ;
         P00JJ3_A204SolicitudesFechaActualizacion = new DateTime[] {DateTime.MinValue} ;
         P00JJ3_n204SolicitudesFechaActualizacion = new bool[] {false} ;
         P00JJ3_A140RelacionesId = new long[1] ;
         A130EstadosSolTipo = "";
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
         A205SolicitudesComentario = "";
         A261SolicitudesNota = "";
         A262SolicitudesNotificacion = "";
         A204SolicitudesFechaActualizacion = (DateTime)(DateTime.MinValue);
         AV14ModoPago = "";
         AV9Deduccion = "";
         AV11Ganancia = "";
         AV24Solicitud = new SdtSDTSolicitudes(context);
         P00JJ4_A127SolicitudesID = new long[1] ;
         P00JJ4_A134SolicitudesItemsID = new short[1] ;
         P00JJ4_A177SolicitudesItemsCantidad = new short[1] ;
         P00JJ4_A121RubrosId = new short[1] ;
         P00JJ4_A122RubrosNombre = new string[] {""} ;
         A122RubrosNombre = "";
         AV13Item = new SdtSDTSolicitudes_Items(context);
         P00JJ5_A272FeedBackSolicitudId = new long[1] ;
         P00JJ5_A117FeedBackId = new long[1] ;
         P00JJ5_A275FeedBackNum = new long[1] ;
         P00JJ5_A271FeedBackComentario = new string[] {""} ;
         P00JJ5_A276FeedBackFechaAlta = new DateTime[] {DateTime.MinValue} ;
         A271FeedBackComentario = "";
         A276FeedBackFechaAlta = DateTime.MinValue;
         P00JJ6_A127SolicitudesID = new long[1] ;
         P00JJ6_A134SolicitudesItemsID = new short[1] ;
         P00JJ6_A180SolicitudItemsComision = new decimal[1] ;
         P00JJ6_A179SolicitudItemsComisionTipo = new string[] {""} ;
         P00JJ6_A178SolicitudItemsSR = new string[] {""} ;
         P00JJ6_A177SolicitudesItemsCantidad = new short[1] ;
         P00JJ6_A176SolicitudesItemsPrecioFinal = new decimal[1] ;
         P00JJ6_n176SolicitudesItemsPrecioFinal = new bool[] {false} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.apis.oultsolcalificadasprof__default(),
            new Object[][] {
                new Object[] {
               P00JJ2_A120ProfesionalesId
               }
               , new Object[] {
               P00JJ3_A120ProfesionalesId, P00JJ3_A131EstadosSolId, P00JJ3_A130EstadosSolTipo, P00JJ3_A127SolicitudesID, P00JJ3_A171SolicitudesNombre, P00JJ3_A132EstadosSolNombre, P00JJ3_A182SolicitudesFechaAlta, P00JJ3_n182SolicitudesFechaAlta, P00JJ3_A173SolicitudesDireccion, P00JJ3_A184SolicitudesFechaInstalacion,
               P00JJ3_A183SolicitudesHoraInstalacion, P00JJ3_A172SolicitudesTelefono, P00JJ3_A206SolicitudesMail, P00JJ3_n206SolicitudesMail, P00JJ3_A112DepartamentoId, P00JJ3_n112DepartamentoId, P00JJ3_A113DepartamentoDepartamento, P00JJ3_A114DepartamentoMunicipioId, P00JJ3_n114DepartamentoMunicipioId, P00JJ3_A115DepartamentoMunicipioNombre,
               P00JJ3_A110ZonasID, P00JJ3_n110ZonasID, P00JJ3_A194SolicitudesAutoEnumerar, P00JJ3_A210SolicitudServicioSolCoti, P00JJ3_A212SolicitudesCotizacion, P00JJ3_A205SolicitudesComentario, P00JJ3_A128MetodoPagosID, P00JJ3_A261SolicitudesNota, P00JJ3_A262SolicitudesNotificacion, P00JJ3_A204SolicitudesFechaActualizacion,
               P00JJ3_n204SolicitudesFechaActualizacion, P00JJ3_A140RelacionesId
               }
               , new Object[] {
               P00JJ4_A127SolicitudesID, P00JJ4_A134SolicitudesItemsID, P00JJ4_A177SolicitudesItemsCantidad, P00JJ4_A121RubrosId, P00JJ4_A122RubrosNombre
               }
               , new Object[] {
               P00JJ5_A272FeedBackSolicitudId, P00JJ5_A117FeedBackId, P00JJ5_A275FeedBackNum, P00JJ5_A271FeedBackComentario, P00JJ5_A276FeedBackFechaAlta
               }
               , new Object[] {
               P00JJ6_A127SolicitudesID, P00JJ6_A134SolicitudesItemsID, P00JJ6_A180SolicitudItemsComision, P00JJ6_A179SolicitudItemsComisionTipo, P00JJ6_A178SolicitudItemsSR, P00JJ6_A177SolicitudesItemsCantidad, P00JJ6_A176SolicitudesItemsPrecioFinal, P00JJ6_n176SolicitudesItemsPrecioFinal
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short Gx_restcode ;
      private short AV8Counter ;
      private short AV33GXLvl25 ;
      private short A194SolicitudesAutoEnumerar ;
      private short A134SolicitudesItemsID ;
      private short A177SolicitudesItemsCantidad ;
      private short A121RubrosId ;
      private short AV19ResCode ;
      private int GXPagingTo3 ;
      private int GXPagingIdx3 ;
      private int A131EstadosSolId ;
      private long A127SolicitudesID ;
      private long A112DepartamentoId ;
      private long A114DepartamentoMunicipioId ;
      private long A110ZonasID ;
      private long A128MetodoPagosID ;
      private long A140RelacionesId ;
      private long A272FeedBackSolicitudId ;
      private long A117FeedBackId ;
      private long A275FeedBackNum ;
      private decimal A212SolicitudesCotizacion ;
      private decimal A174SolicitudesTotal ;
      private decimal A175SolicitudesItemsPrecioInstalac ;
      private string AV27User ;
      private string AV18ProfesionalId ;
      private string AV28TokenId ;
      private string AV31TokenDesencriptado ;
      private string A120ProfesionalesId ;
      private string A130EstadosSolTipo ;
      private string A171SolicitudesNombre ;
      private string A132EstadosSolNombre ;
      private string A183SolicitudesHoraInstalacion ;
      private string A172SolicitudesTelefono ;
      private string A113DepartamentoDepartamento ;
      private string A115DepartamentoMunicipioNombre ;
      private string A210SolicitudServicioSolCoti ;
      private string A261SolicitudesNota ;
      private string A262SolicitudesNotificacion ;
      private string AV14ModoPago ;
      private string AV9Deduccion ;
      private string AV11Ganancia ;
      private string A122RubrosNombre ;
      private DateTime A204SolicitudesFechaActualizacion ;
      private DateTime A182SolicitudesFechaAlta ;
      private DateTime A184SolicitudesFechaInstalacion ;
      private DateTime A276FeedBackFechaAlta ;
      private bool AV30EsValido ;
      private bool n182SolicitudesFechaAlta ;
      private bool n206SolicitudesMail ;
      private bool n112DepartamentoId ;
      private bool n114DepartamentoMunicipioId ;
      private bool n110ZonasID ;
      private bool n204SolicitudesFechaActualizacion ;
      private string A205SolicitudesComentario ;
      private string A271FeedBackComentario ;
      private string AV21RestMessage ;
      private string A173SolicitudesDireccion ;
      private string A206SolicitudesMail ;
      private GxHttpRequest AV29HttpRequest ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GXBaseCollection<SdtSDTSolicitudes> AV22SdtSolicitudes ;
      private IDataStoreProvider pr_default ;
      private string[] P00JJ2_A120ProfesionalesId ;
      private string[] P00JJ3_A120ProfesionalesId ;
      private int[] P00JJ3_A131EstadosSolId ;
      private string[] P00JJ3_A130EstadosSolTipo ;
      private long[] P00JJ3_A127SolicitudesID ;
      private string[] P00JJ3_A171SolicitudesNombre ;
      private string[] P00JJ3_A132EstadosSolNombre ;
      private DateTime[] P00JJ3_A182SolicitudesFechaAlta ;
      private bool[] P00JJ3_n182SolicitudesFechaAlta ;
      private string[] P00JJ3_A173SolicitudesDireccion ;
      private DateTime[] P00JJ3_A184SolicitudesFechaInstalacion ;
      private string[] P00JJ3_A183SolicitudesHoraInstalacion ;
      private string[] P00JJ3_A172SolicitudesTelefono ;
      private string[] P00JJ3_A206SolicitudesMail ;
      private bool[] P00JJ3_n206SolicitudesMail ;
      private long[] P00JJ3_A112DepartamentoId ;
      private bool[] P00JJ3_n112DepartamentoId ;
      private string[] P00JJ3_A113DepartamentoDepartamento ;
      private long[] P00JJ3_A114DepartamentoMunicipioId ;
      private bool[] P00JJ3_n114DepartamentoMunicipioId ;
      private string[] P00JJ3_A115DepartamentoMunicipioNombre ;
      private long[] P00JJ3_A110ZonasID ;
      private bool[] P00JJ3_n110ZonasID ;
      private short[] P00JJ3_A194SolicitudesAutoEnumerar ;
      private string[] P00JJ3_A210SolicitudServicioSolCoti ;
      private decimal[] P00JJ3_A212SolicitudesCotizacion ;
      private string[] P00JJ3_A205SolicitudesComentario ;
      private long[] P00JJ3_A128MetodoPagosID ;
      private string[] P00JJ3_A261SolicitudesNota ;
      private string[] P00JJ3_A262SolicitudesNotificacion ;
      private DateTime[] P00JJ3_A204SolicitudesFechaActualizacion ;
      private bool[] P00JJ3_n204SolicitudesFechaActualizacion ;
      private long[] P00JJ3_A140RelacionesId ;
      private SdtSDTSolicitudes AV24Solicitud ;
      private long[] P00JJ4_A127SolicitudesID ;
      private short[] P00JJ4_A134SolicitudesItemsID ;
      private short[] P00JJ4_A177SolicitudesItemsCantidad ;
      private short[] P00JJ4_A121RubrosId ;
      private string[] P00JJ4_A122RubrosNombre ;
      private SdtSDTSolicitudes_Items AV13Item ;
      private long[] P00JJ5_A272FeedBackSolicitudId ;
      private long[] P00JJ5_A117FeedBackId ;
      private long[] P00JJ5_A275FeedBackNum ;
      private string[] P00JJ5_A271FeedBackComentario ;
      private DateTime[] P00JJ5_A276FeedBackFechaAlta ;
      private long[] P00JJ6_A127SolicitudesID ;
      private short[] P00JJ6_A134SolicitudesItemsID ;
      private decimal[] P00JJ6_A180SolicitudItemsComision ;
      private string[] P00JJ6_A179SolicitudItemsComisionTipo ;
      private string[] P00JJ6_A178SolicitudItemsSR ;
      private short[] P00JJ6_A177SolicitudesItemsCantidad ;
      private decimal[] P00JJ6_A176SolicitudesItemsPrecioFinal ;
      private bool[] P00JJ6_n176SolicitudesItemsPrecioFinal ;
      private short aP2_Gx_restcode ;
      private string aP3_RestMessage ;
      private GXBaseCollection<SdtSDTSolicitudes> aP4_SdtSolicitudes ;
   }

   public class oultsolcalificadasprof__default : DataStoreHelperBase, IDataStoreHelper
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
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP00JJ2;
          prmP00JJ2 = new Object[] {
          new ParDef("@AV18ProfesionalId",GXType.Char,20,0)
          };
          Object[] prmP00JJ3;
          prmP00JJ3 = new Object[] {
          new ParDef("@ProfesionalesId",GXType.Char,20,0)
          };
          Object[] prmP00JJ4;
          prmP00JJ4 = new Object[] {
          new ParDef("@AV24Solicitud__Solicitudesid",GXType.Decimal,18,0)
          };
          Object[] prmP00JJ5;
          prmP00JJ5 = new Object[] {
          new ParDef("@SolicitudesID",GXType.Decimal,18,0)
          };
          Object[] prmP00JJ6;
          prmP00JJ6 = new Object[] {
          new ParDef("@SolicitudesID",GXType.Decimal,18,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00JJ2", "SELECT [ProfesionalesId] FROM [Profesionales] WHERE [ProfesionalesId] = @AV18ProfesionalId ORDER BY [ProfesionalesId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00JJ2,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("P00JJ3", "SELECT T1.[ProfesionalesId], T2.[EstadosSolId] AS EstadosSolId, T2.[EstadosSolTipo] AS EstadosSolTipo, T1.[SolicitudesID], T2.[SolicitudesNombre], T3.[EstadosGenericosNombre] AS EstadosSolNombre, T2.[SolicitudesFechaAlta], T2.[SolicitudesDireccion], T2.[SolicitudesFechaInstalacion], T2.[SolicitudesHoraInstalacion], T2.[SolicitudesTelefono], T2.[SolicitudesMail], T2.[DepartamentoId], T4.[DepartamentoDepartamento], T2.[DepartamentoMunicipioId], T5.[DepartamentoMunicipioNombre], T2.[ZonasID], T2.[SolicitudesAutoEnumerar], T2.[SolicitudServicioSolCoti], T2.[SolicitudesCotizacion], T2.[SolicitudesComentario], T2.[MetodoPagosID], T2.[SolicitudesNota], T2.[SolicitudesNotificacion], T2.[SolicitudesFechaActualizacion], T1.[RelacionesId] FROM (((([Relaciones] T1 INNER JOIN [Solicitudes] T2 ON T2.[SolicitudesID] = T1.[SolicitudesID]) INNER JOIN [EstadosGenericos] T3 ON T3.[EstadosTipo] = T2.[EstadosSolTipo] AND T3.[EstadosGenericosId] = T2.[EstadosSolId]) LEFT JOIN [Departamento] T4 ON T4.[DepartamentoId] = T2.[DepartamentoId]) LEFT JOIN [DepartamentoMunicipio] T5 ON T5.[DepartamentoId] = T2.[DepartamentoId] AND T5.[DepartamentoMunicipioId] = T2.[DepartamentoMunicipioId]) WHERE (T1.[ProfesionalesId] = @ProfesionalesId) AND (T2.[EstadosSolId] = 7) ORDER BY T2.[SolicitudesFechaActualizacion] DESC ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00JJ3,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00JJ4", "SELECT T1.[SolicitudesID], T1.[SolicitudesItemsID], T1.[SolicitudesItemsCantidad], T1.[RubrosId], T2.[RubrosNombre] FROM ([SolicitudesItems] T1 INNER JOIN [Rubros] T2 ON T2.[RubrosId] = T1.[RubrosId]) WHERE T1.[SolicitudesID] = @AV24Solicitud__Solicitudesid ORDER BY T1.[SolicitudesID] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00JJ4,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P00JJ5", "SELECT [FeedBackSolicitudId], [FeedBackId], [FeedBackNum], [FeedBackComentario], [FeedBackFechaAlta] FROM [FeedBack] WHERE [FeedBackSolicitudId] = @SolicitudesID ORDER BY [FeedBackId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00JJ5,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P00JJ6", "SELECT [SolicitudesID], [SolicitudesItemsID], [SolicitudItemsComision], [SolicitudItemsComisionTipo], [SolicitudItemsSR], [SolicitudesItemsCantidad], [SolicitudesItemsPrecioFinal] FROM [SolicitudesItems] WHERE [SolicitudesID] = @SolicitudesID ORDER BY [SolicitudesID] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00JJ6,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[0])[0] = rslt.getString(1, 20);
                return;
             case 1 :
                ((string[]) buf[0])[0] = rslt.getString(1, 20);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 3);
                ((long[]) buf[3])[0] = rslt.getLong(4);
                ((string[]) buf[4])[0] = rslt.getString(5, 100);
                ((string[]) buf[5])[0] = rslt.getString(6, 80);
                ((DateTime[]) buf[6])[0] = rslt.getGXDate(7);
                ((bool[]) buf[7])[0] = rslt.wasNull(7);
                ((string[]) buf[8])[0] = rslt.getVarchar(8);
                ((DateTime[]) buf[9])[0] = rslt.getGXDate(9);
                ((string[]) buf[10])[0] = rslt.getString(10, 1);
                ((string[]) buf[11])[0] = rslt.getString(11, 20);
                ((string[]) buf[12])[0] = rslt.getVarchar(12);
                ((bool[]) buf[13])[0] = rslt.wasNull(12);
                ((long[]) buf[14])[0] = rslt.getLong(13);
                ((bool[]) buf[15])[0] = rslt.wasNull(13);
                ((string[]) buf[16])[0] = rslt.getString(14, 80);
                ((long[]) buf[17])[0] = rslt.getLong(15);
                ((bool[]) buf[18])[0] = rslt.wasNull(15);
                ((string[]) buf[19])[0] = rslt.getString(16, 120);
                ((long[]) buf[20])[0] = rslt.getLong(17);
                ((bool[]) buf[21])[0] = rslt.wasNull(17);
                ((short[]) buf[22])[0] = rslt.getShort(18);
                ((string[]) buf[23])[0] = rslt.getString(19, 1);
                ((decimal[]) buf[24])[0] = rslt.getDecimal(20);
                ((string[]) buf[25])[0] = rslt.getLongVarchar(21);
                ((long[]) buf[26])[0] = rslt.getLong(22);
                ((string[]) buf[27])[0] = rslt.getString(23, 500);
                ((string[]) buf[28])[0] = rslt.getString(24, 1);
                ((DateTime[]) buf[29])[0] = rslt.getGXDateTime(25);
                ((bool[]) buf[30])[0] = rslt.wasNull(25);
                ((long[]) buf[31])[0] = rslt.getLong(26);
                return;
             case 2 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                ((string[]) buf[4])[0] = rslt.getString(5, 100);
                return;
             case 3 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((long[]) buf[1])[0] = rslt.getLong(2);
                ((long[]) buf[2])[0] = rslt.getLong(3);
                ((string[]) buf[3])[0] = rslt.getLongVarchar(4);
                ((DateTime[]) buf[4])[0] = rslt.getGXDate(5);
                return;
             case 4 :
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

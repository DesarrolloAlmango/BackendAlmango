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
   public class ocomisionsolicitud : GXProcedure
   {
      public ocomisionsolicitud( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public ocomisionsolicitud( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( long aP0_SolicitudesID ,
                           string aP1_InProfesionalesId ,
                           bool aP2_GuardarCalculo ,
                           out decimal aP3_ComisionProv ,
                           out decimal aP4_ComisionProvP ,
                           out decimal aP5_ComisionALM ,
                           out decimal aP6_ComisionALMP ,
                           out decimal aP7_PrecioProfesional ,
                           out decimal aP8_PrecioProfesionalP )
      {
         this.AV8SolicitudesID = aP0_SolicitudesID;
         this.AV47InProfesionalesId = aP1_InProfesionalesId;
         this.AV49GuardarCalculo = aP2_GuardarCalculo;
         this.AV14ComisionProv = 0 ;
         this.AV13ComisionProvP = 0 ;
         this.AV22ComisionALM = 0 ;
         this.AV23ComisionALMP = 0 ;
         this.AV50PrecioProfesional = 0 ;
         this.AV51PrecioProfesionalP = 0 ;
         initialize();
         ExecutePrivate();
         aP3_ComisionProv=this.AV14ComisionProv;
         aP4_ComisionProvP=this.AV13ComisionProvP;
         aP5_ComisionALM=this.AV22ComisionALM;
         aP6_ComisionALMP=this.AV23ComisionALMP;
         aP7_PrecioProfesional=this.AV50PrecioProfesional;
         aP8_PrecioProfesionalP=this.AV51PrecioProfesionalP;
      }

      public decimal executeUdp( long aP0_SolicitudesID ,
                                 string aP1_InProfesionalesId ,
                                 bool aP2_GuardarCalculo ,
                                 out decimal aP3_ComisionProv ,
                                 out decimal aP4_ComisionProvP ,
                                 out decimal aP5_ComisionALM ,
                                 out decimal aP6_ComisionALMP ,
                                 out decimal aP7_PrecioProfesional )
      {
         execute(aP0_SolicitudesID, aP1_InProfesionalesId, aP2_GuardarCalculo, out aP3_ComisionProv, out aP4_ComisionProvP, out aP5_ComisionALM, out aP6_ComisionALMP, out aP7_PrecioProfesional, out aP8_PrecioProfesionalP);
         return AV51PrecioProfesionalP ;
      }

      public void executeSubmit( long aP0_SolicitudesID ,
                                 string aP1_InProfesionalesId ,
                                 bool aP2_GuardarCalculo ,
                                 out decimal aP3_ComisionProv ,
                                 out decimal aP4_ComisionProvP ,
                                 out decimal aP5_ComisionALM ,
                                 out decimal aP6_ComisionALMP ,
                                 out decimal aP7_PrecioProfesional ,
                                 out decimal aP8_PrecioProfesionalP )
      {
         this.AV8SolicitudesID = aP0_SolicitudesID;
         this.AV47InProfesionalesId = aP1_InProfesionalesId;
         this.AV49GuardarCalculo = aP2_GuardarCalculo;
         this.AV14ComisionProv = 0 ;
         this.AV13ComisionProvP = 0 ;
         this.AV22ComisionALM = 0 ;
         this.AV23ComisionALMP = 0 ;
         this.AV50PrecioProfesional = 0 ;
         this.AV51PrecioProfesionalP = 0 ;
         SubmitImpl();
         aP3_ComisionProv=this.AV14ComisionProv;
         aP4_ComisionProvP=this.AV13ComisionProvP;
         aP5_ComisionALM=this.AV22ComisionALM;
         aP6_ComisionALMP=this.AV23ComisionALMP;
         aP7_PrecioProfesional=this.AV50PrecioProfesional;
         aP8_PrecioProfesionalP=this.AV51PrecioProfesionalP;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         /* Using cursor P00BH2 */
         pr_default.execute(0, new Object[] {AV8SolicitudesID});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A127SolicitudesID = P00BH2_A127SolicitudesID[0];
            A133ProveedorID = P00BH2_A133ProveedorID[0];
            A796SolicitudesComisionMetodoPago = P00BH2_A796SolicitudesComisionMetodoPago[0];
            A212SolicitudesCotizacion = P00BH2_A212SolicitudesCotizacion[0];
            A1016SolicitudesDescuentoCupon = P00BH2_A1016SolicitudesDescuentoCupon[0];
            A897SolicitudesDescuento = P00BH2_A897SolicitudesDescuento[0];
            n897SolicitudesDescuento = P00BH2_n897SolicitudesDescuento[0];
            A864SolicitudesCostoXZona = P00BH2_A864SolicitudesCostoXZona[0];
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
            AV9ProveedorID = A133ProveedorID;
            AV10SolicitudesCotizacion = A212SolicitudesCotizacion;
            AV29ProfesionalesId = StringUtil.Trim( AV47InProfesionalesId);
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV29ProfesionalesId)) )
            {
               /* Execute user subroutine: 'EXITE VINCULO PROFESIONAL' */
               S111 ();
               if ( returnInSub )
               {
                  pr_default.close(0);
                  cleanup();
                  if (true) return;
               }
            }
            AV39ComisionesGlobal = false;
            AV40AmbosVinculos = true;
            /* Execute user subroutine: 'OBTENER COMISIONES' */
            S121 ();
            if ( returnInSub )
            {
               pr_default.close(0);
               cleanup();
               if (true) return;
            }
            if ( ( AV20ComisionesDefaultProf == Convert.ToDecimal( 0 )) )
            {
               AV40AmbosVinculos = false;
               AV14ComisionProv = 0;
               AV13ComisionProvP = 0;
               /* Execute user subroutine: 'OBTENER COMISIONES' */
               S121 ();
               if ( returnInSub )
               {
                  pr_default.close(0);
                  cleanup();
                  if (true) return;
               }
               if ( ( AV20ComisionesDefaultProf == Convert.ToDecimal( 0 )) )
               {
                  AV39ComisionesGlobal = true;
                  AV14ComisionProv = 0;
                  AV13ComisionProvP = 0;
                  /* Execute user subroutine: 'OBTENER COMISIONES' */
                  S121 ();
                  if ( returnInSub )
                  {
                     pr_default.close(0);
                     cleanup();
                     if (true) return;
                  }
               }
            }
            AV56SolicitudesComisionMetodoPago = A796SolicitudesComisionMetodoPago;
            if ( ! AV24PorItem )
            {
               AV22ComisionALM = (decimal)((A211SolicitudServicioPFinal-A864SolicitudesCostoXZona)*(AV20ComisionesDefaultProf/ (decimal)(100)));
               AV14ComisionProv = (decimal)((A211SolicitudServicioPFinal-A864SolicitudesCostoXZona)*(AV21ComisionesDefaultComer/ (decimal)(100)));
               AV13ComisionProvP = AV21ComisionesDefaultComer;
               AV23ComisionALMP = (decimal)(AV20ComisionesDefaultProf-AV21ComisionesDefaultComer);
               AV22ComisionALM = (decimal)(AV22ComisionALM-AV14ComisionProv);
            }
            AV50PrecioProfesional = (decimal)(((A211SolicitudServicioPFinal-A864SolicitudesCostoXZona)-(AV14ComisionProv+AV22ComisionALM)));
            AV51PrecioProfesionalP = (decimal)(100-(AV13ComisionProvP+AV23ComisionALMP));
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(0);
         context.CommitDataStores("ocomisionsolicitud",pr_default);
         cleanup();
      }

      protected void S111( )
      {
         /* 'EXITE VINCULO PROFESIONAL' Routine */
         returnInSub = false;
         AV30ExisteVinculo = false;
         /* Using cursor P00BH3 */
         pr_default.execute(1, new Object[] {AV8SolicitudesID});
         while ( (pr_default.getStatus(1) != 101) )
         {
            A142EstadoSGId = P00BH3_A142EstadoSGId[0];
            A141EstadoSGTipo = P00BH3_A141EstadoSGTipo[0];
            A127SolicitudesID = P00BH3_A127SolicitudesID[0];
            A120ProfesionalesId = P00BH3_A120ProfesionalesId[0];
            A140RelacionesId = P00BH3_A140RelacionesId[0];
            if ( StringUtil.StrCmp(A141EstadoSGTipo, context.GetMessage( "STS", "")) == 0 )
            {
               AV29ProfesionalesId = A120ProfesionalesId;
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               if (true) break;
            }
            pr_default.readNext(1);
         }
         pr_default.close(1);
      }

      protected void S121( )
      {
         /* 'OBTENER COMISIONES' Routine */
         returnInSub = false;
         AV21ComisionesDefaultComer = 0;
         /* Using cursor P00BH4 */
         pr_default.execute(2);
         while ( (pr_default.getStatus(2) != 101) )
         {
            A511ComisionesEstado = P00BH4_A511ComisionesEstado[0];
            n511ComisionesEstado = P00BH4_n511ComisionesEstado[0];
            A505ComisionesTipo = P00BH4_A505ComisionesTipo[0];
            A503ComisionesID = P00BH4_A503ComisionesID[0];
            A506ComisionesDefault = P00BH4_A506ComisionesDefault[0];
            n506ComisionesDefault = P00BH4_n506ComisionesDefault[0];
            AV11ComisionesID = A503ComisionesID;
            /* Execute user subroutine: 'BUSCO COMERCIO' */
            S134 ();
            if ( returnInSub )
            {
               pr_default.close(2);
               returnInSub = true;
               if (true) return;
            }
            AV21ComisionesDefaultComer = 0;
            if ( AV12ExisteProveedor )
            {
               AV21ComisionesDefaultComer = A506ComisionesDefault;
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               if (true) break;
            }
            pr_default.readNext(2);
         }
         pr_default.close(2);
         /* Using cursor P00BH5 */
         pr_default.execute(3);
         while ( (pr_default.getStatus(3) != 101) )
         {
            A511ComisionesEstado = P00BH5_A511ComisionesEstado[0];
            n511ComisionesEstado = P00BH5_n511ComisionesEstado[0];
            A505ComisionesTipo = P00BH5_A505ComisionesTipo[0];
            A503ComisionesID = P00BH5_A503ComisionesID[0];
            A506ComisionesDefault = P00BH5_A506ComisionesDefault[0];
            n506ComisionesDefault = P00BH5_n506ComisionesDefault[0];
            A520ComisionesGlobal = P00BH5_A520ComisionesGlobal[0];
            n520ComisionesGlobal = P00BH5_n520ComisionesGlobal[0];
            AV38ComisionesIDProf = A503ComisionesID;
            AV20ComisionesDefaultProf = 0;
            if ( ! AV39ComisionesGlobal )
            {
               /* Execute user subroutine: 'BUSCO PROFESIONAL' */
               S145 ();
               if ( returnInSub )
               {
                  pr_default.close(3);
                  returnInSub = true;
                  if (true) return;
               }
               if ( AV37ExisteProfesional )
               {
                  AV20ComisionesDefaultProf = A506ComisionesDefault;
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            else
            {
               if ( A520ComisionesGlobal )
               {
                  AV20ComisionesDefaultProf = A506ComisionesDefault;
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            pr_default.readNext(3);
         }
         pr_default.close(3);
         if ( ( AV10SolicitudesCotizacion == Convert.ToDecimal( 0 )) )
         {
            AV12ExisteProveedor = true;
            AV24PorItem = false;
            /* Execute user subroutine: 'BUSCO PRODUCTO' */
            S151 ();
            if (returnInSub) return;
         }
      }

      protected void S145( )
      {
         /* 'BUSCO PROFESIONAL' Routine */
         returnInSub = false;
         AV37ExisteProfesional = false;
         AV12ExisteProveedor = false;
         /* Using cursor P00BH6 */
         pr_default.execute(4, new Object[] {AV38ComisionesIDProf, AV29ProfesionalesId});
         while ( (pr_default.getStatus(4) != 101) )
         {
            A120ProfesionalesId = P00BH6_A120ProfesionalesId[0];
            A503ComisionesID = P00BH6_A503ComisionesID[0];
            AV37ExisteProfesional = true;
            /* Execute user subroutine: 'EXISTE PROVEEDOR' */
            S166 ();
            if ( returnInSub )
            {
               pr_default.close(4);
               returnInSub = true;
               if (true) return;
            }
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(4);
         if ( AV40AmbosVinculos )
         {
            if ( ( AV12ExisteProveedor ) && ( AV37ExisteProfesional ) )
            {
               AV37ExisteProfesional = true;
            }
            else
            {
               AV37ExisteProfesional = false;
            }
         }
         else
         {
            if ( ( AV37ExisteProfesional ) && ( AV12ExisteProveedor ) )
            {
               AV37ExisteProfesional = false;
            }
         }
      }

      protected void S166( )
      {
         /* 'EXISTE PROVEEDOR' Routine */
         returnInSub = false;
         /* Using cursor P00BH7 */
         pr_default.execute(5, new Object[] {AV38ComisionesIDProf, AV9ProveedorID, AV40AmbosVinculos});
         while ( (pr_default.getStatus(5) != 101) )
         {
            A133ProveedorID = P00BH7_A133ProveedorID[0];
            A503ComisionesID = P00BH7_A503ComisionesID[0];
            AV12ExisteProveedor = true;
            /* Exit For each command. Update data (if necessary), close cursors & exit. */
            if (true) break;
            pr_default.readNext(5);
         }
         pr_default.close(5);
      }

      protected void S134( )
      {
         /* 'BUSCO COMERCIO' Routine */
         returnInSub = false;
         AV12ExisteProveedor = false;
         /* Using cursor P00BH8 */
         pr_default.execute(6, new Object[] {AV11ComisionesID, AV9ProveedorID});
         while ( (pr_default.getStatus(6) != 101) )
         {
            A133ProveedorID = P00BH8_A133ProveedorID[0];
            A503ComisionesID = P00BH8_A503ComisionesID[0];
            AV12ExisteProveedor = true;
            /* Exit For each command. Update data (if necessary), close cursors & exit. */
            if (true) break;
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(6);
      }

      protected void S151( )
      {
         /* 'BUSCO PRODUCTO' Routine */
         returnInSub = false;
         AV26nItem = 0;
         AV54OldComisionesDefaultComer = AV21ComisionesDefaultComer;
         AV55OldComisionesDefaultProf = AV20ComisionesDefaultProf;
         /* Using cursor P00BH9 */
         pr_default.execute(7, new Object[] {AV8SolicitudesID});
         while ( (pr_default.getStatus(7) != 101) )
         {
            A127SolicitudesID = P00BH9_A127SolicitudesID[0];
            A121RubrosId = P00BH9_A121RubrosId[0];
            A137MedidasID = P00BH9_A137MedidasID[0];
            A135InventarioId = P00BH9_A135InventarioId[0];
            A796SolicitudesComisionMetodoPago = P00BH9_A796SolicitudesComisionMetodoPago[0];
            A1016SolicitudesDescuentoCupon = P00BH9_A1016SolicitudesDescuentoCupon[0];
            A897SolicitudesDescuento = P00BH9_A897SolicitudesDescuento[0];
            n897SolicitudesDescuento = P00BH9_n897SolicitudesDescuento[0];
            A521SolicitudesItemsComiProv = P00BH9_A521SolicitudesItemsComiProv[0];
            n521SolicitudesItemsComiProv = P00BH9_n521SolicitudesItemsComiProv[0];
            A524SolicitudesItemsComiProvP = P00BH9_A524SolicitudesItemsComiProvP[0];
            n524SolicitudesItemsComiProvP = P00BH9_n524SolicitudesItemsComiProvP[0];
            A523SolicitudesItemsComiALM = P00BH9_A523SolicitudesItemsComiALM[0];
            n523SolicitudesItemsComiALM = P00BH9_n523SolicitudesItemsComiALM[0];
            A526SolicitudesItemsComiALMP = P00BH9_A526SolicitudesItemsComiALMP[0];
            n526SolicitudesItemsComiALMP = P00BH9_n526SolicitudesItemsComiALMP[0];
            A134SolicitudesItemsID = P00BH9_A134SolicitudesItemsID[0];
            A180SolicitudItemsComision = P00BH9_A180SolicitudItemsComision[0];
            A179SolicitudItemsComisionTipo = P00BH9_A179SolicitudItemsComisionTipo[0];
            A178SolicitudItemsSR = P00BH9_A178SolicitudItemsSR[0];
            A177SolicitudesItemsCantidad = P00BH9_A177SolicitudesItemsCantidad[0];
            A176SolicitudesItemsPrecioFinal = P00BH9_A176SolicitudesItemsPrecioFinal[0];
            n176SolicitudesItemsPrecioFinal = P00BH9_n176SolicitudesItemsPrecioFinal[0];
            A796SolicitudesComisionMetodoPago = P00BH9_A796SolicitudesComisionMetodoPago[0];
            A1016SolicitudesDescuentoCupon = P00BH9_A1016SolicitudesDescuentoCupon[0];
            A897SolicitudesDescuento = P00BH9_A897SolicitudesDescuento[0];
            n897SolicitudesDescuento = P00BH9_n897SolicitudesDescuento[0];
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
            AV24PorItem = true;
            AV26nItem = (short)(AV26nItem+1);
            if ( ( AV10SolicitudesCotizacion == Convert.ToDecimal( 0 )) )
            {
               new ocomisionesitem(context ).execute(  "C",  AV29ProfesionalesId,  AV9ProveedorID,  A121RubrosId,  A137MedidasID,  A135InventarioId, out  AV53ExisteInventario, out  AV42ComisionesAgruparRubrosValor) ;
               if ( AV53ExisteInventario )
               {
                  AV21ComisionesDefaultComer = AV42ComisionesAgruparRubrosValor;
               }
               else
               {
                  AV21ComisionesDefaultComer = AV54OldComisionesDefaultComer;
               }
            }
            if ( ( AV21ComisionesDefaultComer > Convert.ToDecimal( 0 )) )
            {
               AV27SolicitudesItemsComiProv = (decimal)((A175SolicitudesItemsPrecioInstalac-A897SolicitudesDescuento-A1016SolicitudesDescuentoCupon-A796SolicitudesComisionMetodoPago)*(AV21ComisionesDefaultComer/ (decimal)(100)));
               AV18SolicitudesItemsComiProvP = AV21ComisionesDefaultComer;
            }
            else
            {
               AV27SolicitudesItemsComiProv = 0;
            }
            if ( AV49GuardarCalculo )
            {
               A521SolicitudesItemsComiProv = AV27SolicitudesItemsComiProv;
               n521SolicitudesItemsComiProv = false;
               A524SolicitudesItemsComiProvP = AV18SolicitudesItemsComiProvP;
               n524SolicitudesItemsComiProvP = false;
               AV14ComisionProv = (decimal)(AV14ComisionProv+A521SolicitudesItemsComiProv);
               AV13ComisionProvP = (decimal)(AV13ComisionProvP+A524SolicitudesItemsComiProvP);
            }
            else
            {
               AV14ComisionProv = (decimal)(AV14ComisionProv+AV27SolicitudesItemsComiProv);
               AV13ComisionProvP = (decimal)(AV13ComisionProvP+AV18SolicitudesItemsComiProvP);
            }
            if ( ( AV10SolicitudesCotizacion == Convert.ToDecimal( 0 )) )
            {
               new ocomisionesitem(context ).execute(  "P",  AV29ProfesionalesId,  AV9ProveedorID,  A121RubrosId,  A137MedidasID,  A135InventarioId, out  AV53ExisteInventario, out  AV42ComisionesAgruparRubrosValor) ;
               if ( AV53ExisteInventario )
               {
                  AV20ComisionesDefaultProf = AV42ComisionesAgruparRubrosValor;
               }
               else
               {
                  AV20ComisionesDefaultProf = AV55OldComisionesDefaultProf;
                  AV24PorItem = false;
               }
            }
            if ( AV49GuardarCalculo )
            {
               A523SolicitudesItemsComiALM = (decimal)(((A175SolicitudesItemsPrecioInstalac-A897SolicitudesDescuento-A1016SolicitudesDescuentoCupon-A796SolicitudesComisionMetodoPago)*(AV20ComisionesDefaultProf/ (decimal)(100)))-AV27SolicitudesItemsComiProv);
               n523SolicitudesItemsComiALM = false;
               A526SolicitudesItemsComiALMP = (decimal)(AV20ComisionesDefaultProf-AV18SolicitudesItemsComiProvP);
               n526SolicitudesItemsComiALMP = false;
               AV22ComisionALM = (decimal)(AV22ComisionALM+A523SolicitudesItemsComiALM);
               AV46ComisionALMPAcumulado = (decimal)(AV46ComisionALMPAcumulado+A526SolicitudesItemsComiALMP);
            }
            else
            {
               AV22ComisionALM = (decimal)(AV22ComisionALM+(((A175SolicitudesItemsPrecioInstalac-A897SolicitudesDescuento-A1016SolicitudesDescuentoCupon)*(AV20ComisionesDefaultProf/ (decimal)(100)))-AV27SolicitudesItemsComiProv));
               AV46ComisionALMPAcumulado = (decimal)(AV46ComisionALMPAcumulado+(AV20ComisionesDefaultProf-AV18SolicitudesItemsComiProvP));
            }
            if ( ( AV46ComisionALMPAcumulado > Convert.ToDecimal( 0 )) )
            {
               AV23ComisionALMP = (decimal)((AV46ComisionALMPAcumulado/ (decimal)(AV26nItem)));
            }
            else
            {
               AV22ComisionALM = 0;
               AV23ComisionALMP = 0;
            }
            if ( ( AV13ComisionProvP > Convert.ToDecimal( 0 )) )
            {
               AV21ComisionesDefaultComer = (decimal)((AV13ComisionProvP/ (decimal)(AV26nItem)));
               AV13ComisionProvP = (decimal)((AV13ComisionProvP/ (decimal)(AV26nItem)));
            }
            /* Using cursor P00BH10 */
            pr_default.execute(8, new Object[] {n521SolicitudesItemsComiProv, A521SolicitudesItemsComiProv, n524SolicitudesItemsComiProvP, A524SolicitudesItemsComiProvP, n523SolicitudesItemsComiALM, A523SolicitudesItemsComiALM, n526SolicitudesItemsComiALMP, A526SolicitudesItemsComiALMP, A127SolicitudesID, A134SolicitudesItemsID});
            pr_default.close(8);
            pr_default.SmartCacheProvider.SetUpdated("SolicitudesItems");
            pr_default.readNext(7);
         }
         pr_default.close(7);
      }

      protected void GetSolicitudesTotal( long A127SolicitudesID )
      {
         /* Create private dbobjects */
         /* Navigation */
         A174SolicitudesTotal = 0;
         /* Using cursor P00BH11 */
         pr_default.execute(9, new Object[] {A127SolicitudesID});
         while ( (pr_default.getStatus(9) != 101) && ( P00BH11_A127SolicitudesID[0] == A127SolicitudesID ) )
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( P00BH11_A178SolicitudItemsSR[0])) || ( StringUtil.StrCmp(P00BH11_A179SolicitudItemsComisionTipo[0], "N") == 0 ) )
            {
               A175SolicitudesItemsPrecioInstalac = (decimal)((P00BH11_A176SolicitudesItemsPrecioFinal[0]*P00BH11_A177SolicitudesItemsCantidad[0]));
            }
            else
            {
               if ( ( StringUtil.StrCmp(P00BH11_A179SolicitudItemsComisionTipo[0], "F") == 0 ) && ( StringUtil.StrCmp(P00BH11_A178SolicitudItemsSR[0], "R") == 0 ) )
               {
                  A175SolicitudesItemsPrecioInstalac = (decimal)((P00BH11_A176SolicitudesItemsPrecioFinal[0]*P00BH11_A177SolicitudesItemsCantidad[0])-(P00BH11_A180SolicitudItemsComision[0]*P00BH11_A177SolicitudesItemsCantidad[0]));
               }
               else
               {
                  if ( ( StringUtil.StrCmp(P00BH11_A179SolicitudItemsComisionTipo[0], "F") == 0 ) && ( StringUtil.StrCmp(P00BH11_A178SolicitudItemsSR[0], "S") == 0 ) )
                  {
                     A175SolicitudesItemsPrecioInstalac = (decimal)((P00BH11_A176SolicitudesItemsPrecioFinal[0]*P00BH11_A177SolicitudesItemsCantidad[0])+(P00BH11_A180SolicitudItemsComision[0]*P00BH11_A177SolicitudesItemsCantidad[0]));
                  }
                  else
                  {
                     if ( ( StringUtil.StrCmp(P00BH11_A179SolicitudItemsComisionTipo[0], "P") == 0 ) && ( StringUtil.StrCmp(P00BH11_A178SolicitudItemsSR[0], "R") == 0 ) )
                     {
                        A175SolicitudesItemsPrecioInstalac = (decimal)((P00BH11_A176SolicitudesItemsPrecioFinal[0]*P00BH11_A177SolicitudesItemsCantidad[0])-((P00BH11_A176SolicitudesItemsPrecioFinal[0]*P00BH11_A177SolicitudesItemsCantidad[0])*(P00BH11_A180SolicitudItemsComision[0]/ (decimal)(100))));
                     }
                     else
                     {
                        if ( ( StringUtil.StrCmp(P00BH11_A179SolicitudItemsComisionTipo[0], "P") == 0 ) && ( StringUtil.StrCmp(P00BH11_A178SolicitudItemsSR[0], "S") == 0 ) )
                        {
                           A175SolicitudesItemsPrecioInstalac = (decimal)((P00BH11_A176SolicitudesItemsPrecioFinal[0]*P00BH11_A177SolicitudesItemsCantidad[0])+((P00BH11_A176SolicitudesItemsPrecioFinal[0]*P00BH11_A177SolicitudesItemsCantidad[0])*(P00BH11_A180SolicitudItemsComision[0]/ (decimal)(100))));
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
            pr_default.readNext(9);
         }
         pr_default.close(9);
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
         P00BH2_A127SolicitudesID = new long[1] ;
         P00BH2_A133ProveedorID = new long[1] ;
         P00BH2_A796SolicitudesComisionMetodoPago = new decimal[1] ;
         P00BH2_A212SolicitudesCotizacion = new decimal[1] ;
         P00BH2_A1016SolicitudesDescuentoCupon = new decimal[1] ;
         P00BH2_A897SolicitudesDescuento = new decimal[1] ;
         P00BH2_n897SolicitudesDescuento = new bool[] {false} ;
         P00BH2_A864SolicitudesCostoXZona = new decimal[1] ;
         AV29ProfesionalesId = "";
         P00BH3_A142EstadoSGId = new int[1] ;
         P00BH3_A141EstadoSGTipo = new string[] {""} ;
         P00BH3_A127SolicitudesID = new long[1] ;
         P00BH3_A120ProfesionalesId = new string[] {""} ;
         P00BH3_A140RelacionesId = new long[1] ;
         A141EstadoSGTipo = "";
         A120ProfesionalesId = "";
         P00BH4_A511ComisionesEstado = new string[] {""} ;
         P00BH4_n511ComisionesEstado = new bool[] {false} ;
         P00BH4_A505ComisionesTipo = new string[] {""} ;
         P00BH4_A503ComisionesID = new long[1] ;
         P00BH4_A506ComisionesDefault = new decimal[1] ;
         P00BH4_n506ComisionesDefault = new bool[] {false} ;
         A511ComisionesEstado = "";
         A505ComisionesTipo = "";
         P00BH5_A511ComisionesEstado = new string[] {""} ;
         P00BH5_n511ComisionesEstado = new bool[] {false} ;
         P00BH5_A505ComisionesTipo = new string[] {""} ;
         P00BH5_A503ComisionesID = new long[1] ;
         P00BH5_A506ComisionesDefault = new decimal[1] ;
         P00BH5_n506ComisionesDefault = new bool[] {false} ;
         P00BH5_A520ComisionesGlobal = new bool[] {false} ;
         P00BH5_n520ComisionesGlobal = new bool[] {false} ;
         P00BH6_A120ProfesionalesId = new string[] {""} ;
         P00BH6_A503ComisionesID = new long[1] ;
         P00BH7_A133ProveedorID = new long[1] ;
         P00BH7_A503ComisionesID = new long[1] ;
         P00BH8_A133ProveedorID = new long[1] ;
         P00BH8_A503ComisionesID = new long[1] ;
         P00BH9_A127SolicitudesID = new long[1] ;
         P00BH9_A121RubrosId = new short[1] ;
         P00BH9_A137MedidasID = new long[1] ;
         P00BH9_A135InventarioId = new long[1] ;
         P00BH9_A796SolicitudesComisionMetodoPago = new decimal[1] ;
         P00BH9_A1016SolicitudesDescuentoCupon = new decimal[1] ;
         P00BH9_A897SolicitudesDescuento = new decimal[1] ;
         P00BH9_n897SolicitudesDescuento = new bool[] {false} ;
         P00BH9_A521SolicitudesItemsComiProv = new decimal[1] ;
         P00BH9_n521SolicitudesItemsComiProv = new bool[] {false} ;
         P00BH9_A524SolicitudesItemsComiProvP = new decimal[1] ;
         P00BH9_n524SolicitudesItemsComiProvP = new bool[] {false} ;
         P00BH9_A523SolicitudesItemsComiALM = new decimal[1] ;
         P00BH9_n523SolicitudesItemsComiALM = new bool[] {false} ;
         P00BH9_A526SolicitudesItemsComiALMP = new decimal[1] ;
         P00BH9_n526SolicitudesItemsComiALMP = new bool[] {false} ;
         P00BH9_A134SolicitudesItemsID = new short[1] ;
         P00BH9_A180SolicitudItemsComision = new decimal[1] ;
         P00BH9_A179SolicitudItemsComisionTipo = new string[] {""} ;
         P00BH9_A178SolicitudItemsSR = new string[] {""} ;
         P00BH9_A177SolicitudesItemsCantidad = new short[1] ;
         P00BH9_A176SolicitudesItemsPrecioFinal = new decimal[1] ;
         P00BH9_n176SolicitudesItemsPrecioFinal = new bool[] {false} ;
         A179SolicitudItemsComisionTipo = "";
         A178SolicitudItemsSR = "";
         P00BH11_A127SolicitudesID = new long[1] ;
         P00BH11_A134SolicitudesItemsID = new short[1] ;
         P00BH11_A180SolicitudItemsComision = new decimal[1] ;
         P00BH11_A179SolicitudItemsComisionTipo = new string[] {""} ;
         P00BH11_A178SolicitudItemsSR = new string[] {""} ;
         P00BH11_A177SolicitudesItemsCantidad = new short[1] ;
         P00BH11_A176SolicitudesItemsPrecioFinal = new decimal[1] ;
         P00BH11_n176SolicitudesItemsPrecioFinal = new bool[] {false} ;
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.ocomisionsolicitud__datastore1(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.ocomisionsolicitud__default(),
            new Object[][] {
                new Object[] {
               P00BH2_A127SolicitudesID, P00BH2_A133ProveedorID, P00BH2_A796SolicitudesComisionMetodoPago, P00BH2_A212SolicitudesCotizacion, P00BH2_A1016SolicitudesDescuentoCupon, P00BH2_A897SolicitudesDescuento, P00BH2_n897SolicitudesDescuento, P00BH2_A864SolicitudesCostoXZona
               }
               , new Object[] {
               P00BH3_A142EstadoSGId, P00BH3_A141EstadoSGTipo, P00BH3_A127SolicitudesID, P00BH3_A120ProfesionalesId, P00BH3_A140RelacionesId
               }
               , new Object[] {
               P00BH4_A511ComisionesEstado, P00BH4_n511ComisionesEstado, P00BH4_A505ComisionesTipo, P00BH4_A503ComisionesID, P00BH4_A506ComisionesDefault, P00BH4_n506ComisionesDefault
               }
               , new Object[] {
               P00BH5_A511ComisionesEstado, P00BH5_n511ComisionesEstado, P00BH5_A505ComisionesTipo, P00BH5_A503ComisionesID, P00BH5_A506ComisionesDefault, P00BH5_n506ComisionesDefault, P00BH5_A520ComisionesGlobal, P00BH5_n520ComisionesGlobal
               }
               , new Object[] {
               P00BH6_A120ProfesionalesId, P00BH6_A503ComisionesID
               }
               , new Object[] {
               P00BH7_A133ProveedorID, P00BH7_A503ComisionesID
               }
               , new Object[] {
               P00BH8_A133ProveedorID, P00BH8_A503ComisionesID
               }
               , new Object[] {
               P00BH9_A127SolicitudesID, P00BH9_A121RubrosId, P00BH9_A137MedidasID, P00BH9_A135InventarioId, P00BH9_A796SolicitudesComisionMetodoPago, P00BH9_A1016SolicitudesDescuentoCupon, P00BH9_A897SolicitudesDescuento, P00BH9_n897SolicitudesDescuento, P00BH9_A521SolicitudesItemsComiProv, P00BH9_n521SolicitudesItemsComiProv,
               P00BH9_A524SolicitudesItemsComiProvP, P00BH9_n524SolicitudesItemsComiProvP, P00BH9_A523SolicitudesItemsComiALM, P00BH9_n523SolicitudesItemsComiALM, P00BH9_A526SolicitudesItemsComiALMP, P00BH9_n526SolicitudesItemsComiALMP, P00BH9_A134SolicitudesItemsID, P00BH9_A180SolicitudItemsComision, P00BH9_A179SolicitudItemsComisionTipo, P00BH9_A178SolicitudItemsSR,
               P00BH9_A177SolicitudesItemsCantidad, P00BH9_A176SolicitudesItemsPrecioFinal, P00BH9_n176SolicitudesItemsPrecioFinal
               }
               , new Object[] {
               }
               , new Object[] {
               P00BH11_A127SolicitudesID, P00BH11_A134SolicitudesItemsID, P00BH11_A180SolicitudItemsComision, P00BH11_A179SolicitudItemsComisionTipo, P00BH11_A178SolicitudItemsSR, P00BH11_A177SolicitudesItemsCantidad, P00BH11_A176SolicitudesItemsPrecioFinal, P00BH11_n176SolicitudesItemsPrecioFinal
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV26nItem ;
      private short A121RubrosId ;
      private short A134SolicitudesItemsID ;
      private short A177SolicitudesItemsCantidad ;
      private int A142EstadoSGId ;
      private long AV8SolicitudesID ;
      private long A127SolicitudesID ;
      private long A133ProveedorID ;
      private long AV9ProveedorID ;
      private long A140RelacionesId ;
      private long A503ComisionesID ;
      private long AV11ComisionesID ;
      private long AV38ComisionesIDProf ;
      private long A137MedidasID ;
      private long A135InventarioId ;
      private decimal AV14ComisionProv ;
      private decimal AV13ComisionProvP ;
      private decimal AV22ComisionALM ;
      private decimal AV23ComisionALMP ;
      private decimal AV50PrecioProfesional ;
      private decimal AV51PrecioProfesionalP ;
      private decimal A796SolicitudesComisionMetodoPago ;
      private decimal A212SolicitudesCotizacion ;
      private decimal A1016SolicitudesDescuentoCupon ;
      private decimal A897SolicitudesDescuento ;
      private decimal A864SolicitudesCostoXZona ;
      private decimal A211SolicitudServicioPFinal ;
      private decimal A174SolicitudesTotal ;
      private decimal AV10SolicitudesCotizacion ;
      private decimal AV20ComisionesDefaultProf ;
      private decimal AV56SolicitudesComisionMetodoPago ;
      private decimal AV21ComisionesDefaultComer ;
      private decimal A506ComisionesDefault ;
      private decimal AV54OldComisionesDefaultComer ;
      private decimal AV55OldComisionesDefaultProf ;
      private decimal A521SolicitudesItemsComiProv ;
      private decimal A524SolicitudesItemsComiProvP ;
      private decimal A523SolicitudesItemsComiALM ;
      private decimal A526SolicitudesItemsComiALMP ;
      private decimal A180SolicitudItemsComision ;
      private decimal A176SolicitudesItemsPrecioFinal ;
      private decimal A175SolicitudesItemsPrecioInstalac ;
      private decimal AV42ComisionesAgruparRubrosValor ;
      private decimal AV27SolicitudesItemsComiProv ;
      private decimal AV18SolicitudesItemsComiProvP ;
      private decimal AV46ComisionALMPAcumulado ;
      private string AV47InProfesionalesId ;
      private string AV29ProfesionalesId ;
      private string A141EstadoSGTipo ;
      private string A120ProfesionalesId ;
      private string A511ComisionesEstado ;
      private string A505ComisionesTipo ;
      private string A179SolicitudItemsComisionTipo ;
      private string A178SolicitudItemsSR ;
      private bool AV49GuardarCalculo ;
      private bool n897SolicitudesDescuento ;
      private bool returnInSub ;
      private bool AV39ComisionesGlobal ;
      private bool AV40AmbosVinculos ;
      private bool AV24PorItem ;
      private bool AV30ExisteVinculo ;
      private bool n511ComisionesEstado ;
      private bool n506ComisionesDefault ;
      private bool AV12ExisteProveedor ;
      private bool A520ComisionesGlobal ;
      private bool n520ComisionesGlobal ;
      private bool AV37ExisteProfesional ;
      private bool n521SolicitudesItemsComiProv ;
      private bool n524SolicitudesItemsComiProvP ;
      private bool n523SolicitudesItemsComiALM ;
      private bool n526SolicitudesItemsComiALMP ;
      private bool n176SolicitudesItemsPrecioFinal ;
      private bool AV53ExisteInventario ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private long[] P00BH2_A127SolicitudesID ;
      private long[] P00BH2_A133ProveedorID ;
      private decimal[] P00BH2_A796SolicitudesComisionMetodoPago ;
      private decimal[] P00BH2_A212SolicitudesCotizacion ;
      private decimal[] P00BH2_A1016SolicitudesDescuentoCupon ;
      private decimal[] P00BH2_A897SolicitudesDescuento ;
      private bool[] P00BH2_n897SolicitudesDescuento ;
      private decimal[] P00BH2_A864SolicitudesCostoXZona ;
      private int[] P00BH3_A142EstadoSGId ;
      private string[] P00BH3_A141EstadoSGTipo ;
      private long[] P00BH3_A127SolicitudesID ;
      private string[] P00BH3_A120ProfesionalesId ;
      private long[] P00BH3_A140RelacionesId ;
      private string[] P00BH4_A511ComisionesEstado ;
      private bool[] P00BH4_n511ComisionesEstado ;
      private string[] P00BH4_A505ComisionesTipo ;
      private long[] P00BH4_A503ComisionesID ;
      private decimal[] P00BH4_A506ComisionesDefault ;
      private bool[] P00BH4_n506ComisionesDefault ;
      private string[] P00BH5_A511ComisionesEstado ;
      private bool[] P00BH5_n511ComisionesEstado ;
      private string[] P00BH5_A505ComisionesTipo ;
      private long[] P00BH5_A503ComisionesID ;
      private decimal[] P00BH5_A506ComisionesDefault ;
      private bool[] P00BH5_n506ComisionesDefault ;
      private bool[] P00BH5_A520ComisionesGlobal ;
      private bool[] P00BH5_n520ComisionesGlobal ;
      private string[] P00BH6_A120ProfesionalesId ;
      private long[] P00BH6_A503ComisionesID ;
      private long[] P00BH7_A133ProveedorID ;
      private long[] P00BH7_A503ComisionesID ;
      private long[] P00BH8_A133ProveedorID ;
      private long[] P00BH8_A503ComisionesID ;
      private long[] P00BH9_A127SolicitudesID ;
      private short[] P00BH9_A121RubrosId ;
      private long[] P00BH9_A137MedidasID ;
      private long[] P00BH9_A135InventarioId ;
      private decimal[] P00BH9_A796SolicitudesComisionMetodoPago ;
      private decimal[] P00BH9_A1016SolicitudesDescuentoCupon ;
      private decimal[] P00BH9_A897SolicitudesDescuento ;
      private bool[] P00BH9_n897SolicitudesDescuento ;
      private decimal[] P00BH9_A521SolicitudesItemsComiProv ;
      private bool[] P00BH9_n521SolicitudesItemsComiProv ;
      private decimal[] P00BH9_A524SolicitudesItemsComiProvP ;
      private bool[] P00BH9_n524SolicitudesItemsComiProvP ;
      private decimal[] P00BH9_A523SolicitudesItemsComiALM ;
      private bool[] P00BH9_n523SolicitudesItemsComiALM ;
      private decimal[] P00BH9_A526SolicitudesItemsComiALMP ;
      private bool[] P00BH9_n526SolicitudesItemsComiALMP ;
      private short[] P00BH9_A134SolicitudesItemsID ;
      private decimal[] P00BH9_A180SolicitudItemsComision ;
      private string[] P00BH9_A179SolicitudItemsComisionTipo ;
      private string[] P00BH9_A178SolicitudItemsSR ;
      private short[] P00BH9_A177SolicitudesItemsCantidad ;
      private decimal[] P00BH9_A176SolicitudesItemsPrecioFinal ;
      private bool[] P00BH9_n176SolicitudesItemsPrecioFinal ;
      private long[] P00BH11_A127SolicitudesID ;
      private short[] P00BH11_A134SolicitudesItemsID ;
      private decimal[] P00BH11_A180SolicitudItemsComision ;
      private string[] P00BH11_A179SolicitudItemsComisionTipo ;
      private string[] P00BH11_A178SolicitudItemsSR ;
      private short[] P00BH11_A177SolicitudesItemsCantidad ;
      private decimal[] P00BH11_A176SolicitudesItemsPrecioFinal ;
      private bool[] P00BH11_n176SolicitudesItemsPrecioFinal ;
      private decimal aP3_ComisionProv ;
      private decimal aP4_ComisionProvP ;
      private decimal aP5_ComisionALM ;
      private decimal aP6_ComisionALMP ;
      private decimal aP7_PrecioProfesional ;
      private decimal aP8_PrecioProfesionalP ;
      private IDataStoreProvider pr_datastore1 ;
   }

   public class ocomisionsolicitud__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class ocomisionsolicitud__default : DataStoreHelperBase, IDataStoreHelper
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
       ,new ForEachCursor(def[5])
       ,new ForEachCursor(def[6])
       ,new ForEachCursor(def[7])
       ,new UpdateCursor(def[8])
       ,new ForEachCursor(def[9])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmP00BH2;
        prmP00BH2 = new Object[] {
        new ParDef("@AV8SolicitudesID",GXType.Decimal,18,0)
        };
        Object[] prmP00BH3;
        prmP00BH3 = new Object[] {
        new ParDef("@AV8SolicitudesID",GXType.Decimal,18,0)
        };
        Object[] prmP00BH4;
        prmP00BH4 = new Object[] {
        };
        Object[] prmP00BH5;
        prmP00BH5 = new Object[] {
        };
        Object[] prmP00BH6;
        prmP00BH6 = new Object[] {
        new ParDef("@AV38ComisionesIDProf",GXType.Decimal,18,0) ,
        new ParDef("@AV29ProfesionalesId",GXType.Char,20,0)
        };
        Object[] prmP00BH7;
        prmP00BH7 = new Object[] {
        new ParDef("@AV38ComisionesIDProf",GXType.Decimal,18,0) ,
        new ParDef("@AV9ProveedorID",GXType.Decimal,18,0) ,
        new ParDef("@AV40AmbosVinculos",GXType.Boolean,4,0)
        };
        Object[] prmP00BH8;
        prmP00BH8 = new Object[] {
        new ParDef("@AV11ComisionesID",GXType.Decimal,18,0) ,
        new ParDef("@AV9ProveedorID",GXType.Decimal,18,0)
        };
        Object[] prmP00BH9;
        prmP00BH9 = new Object[] {
        new ParDef("@AV8SolicitudesID",GXType.Decimal,18,0)
        };
        Object[] prmP00BH10;
        prmP00BH10 = new Object[] {
        new ParDef("@SolicitudesItemsComiProv",GXType.Decimal,18,2){Nullable=true} ,
        new ParDef("@SolicitudesItemsComiProvP",GXType.Decimal,6,2){Nullable=true} ,
        new ParDef("@SolicitudesItemsComiALM",GXType.Decimal,18,2){Nullable=true} ,
        new ParDef("@SolicitudesItemsComiALMP",GXType.Decimal,6,2){Nullable=true} ,
        new ParDef("@SolicitudesID",GXType.Decimal,18,0) ,
        new ParDef("@SolicitudesItemsID",GXType.Int16,4,0)
        };
        Object[] prmP00BH11;
        prmP00BH11 = new Object[] {
        new ParDef("@SolicitudesID",GXType.Decimal,18,0)
        };
        def= new CursorDef[] {
            new CursorDef("P00BH2", "SELECT [SolicitudesID], [ProveedorID], [SolicitudesComisionMetodoPago], [SolicitudesCotizacion], [SolicitudesDescuentoCupon], [SolicitudesDescuento], [SolicitudesCostoXZona] FROM [Solicitudes] WHERE [SolicitudesID] = @AV8SolicitudesID ORDER BY [SolicitudesID] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00BH2,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("P00BH3", "SELECT [EstadoSGId], [EstadoSGTipo], [SolicitudesID], [ProfesionalesId], [RelacionesId] FROM [Relaciones] WHERE ([SolicitudesID] = @AV8SolicitudesID) AND ([EstadoSGId] = 1) ORDER BY [SolicitudesID] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00BH3,100, GxCacheFrequency.OFF ,false,false )
           ,new CursorDef("P00BH4", "SELECT [ComisionesEstado], [ComisionesTipo], [ComisionesID], [ComisionesDefault] FROM [Comisiones] WHERE ([ComisionesTipo] = 'C') AND ([ComisionesEstado] = 'HAB') ORDER BY [ComisionesID] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00BH4,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("P00BH5", "SELECT [ComisionesEstado], [ComisionesTipo], [ComisionesID], [ComisionesDefault], [ComisionesGlobal] FROM [Comisiones] WHERE ([ComisionesTipo] = 'P') AND ([ComisionesEstado] = 'HAB') ORDER BY [ComisionesID] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00BH5,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("P00BH6", "SELECT [ProfesionalesId], [ComisionesID] FROM [ComisionesProfesionales] WHERE [ComisionesID] = @AV38ComisionesIDProf and [ProfesionalesId] = @AV29ProfesionalesId ORDER BY [ComisionesID], [ProfesionalesId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00BH6,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("P00BH7", "SELECT TOP 1 [ProveedorID], [ComisionesID] FROM [ComisionesProveedores] WHERE ([ComisionesID] = @AV38ComisionesIDProf) AND ([ProveedorID] = @AV9ProveedorID or @AV40AmbosVinculos = 0) ORDER BY [ComisionesID] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00BH7,1, GxCacheFrequency.OFF ,false,true )
           ,new CursorDef("P00BH8", "SELECT TOP 1 [ProveedorID], [ComisionesID] FROM [ComisionesProveedores] WHERE [ComisionesID] = @AV11ComisionesID and [ProveedorID] = @AV9ProveedorID ORDER BY [ComisionesID], [ProveedorID] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00BH8,1, GxCacheFrequency.OFF ,false,true )
           ,new CursorDef("P00BH9", "SELECT T1.[SolicitudesID], T1.[RubrosId], T1.[MedidasID], T1.[InventarioId], T2.[SolicitudesComisionMetodoPago], T2.[SolicitudesDescuentoCupon], T2.[SolicitudesDescuento], T1.[SolicitudesItemsComiProv], T1.[SolicitudesItemsComiProvP], T1.[SolicitudesItemsComiALM], T1.[SolicitudesItemsComiALMP], T1.[SolicitudesItemsID], T1.[SolicitudItemsComision], T1.[SolicitudItemsComisionTipo], T1.[SolicitudItemsSR], T1.[SolicitudesItemsCantidad], T1.[SolicitudesItemsPrecioFinal] FROM ([SolicitudesItems] T1 WITH (UPDLOCK) INNER JOIN [Solicitudes] T2 ON T2.[SolicitudesID] = T1.[SolicitudesID]) WHERE T1.[SolicitudesID] = @AV8SolicitudesID ORDER BY T1.[SolicitudesID], T1.[SolicitudesItemsID] ",true, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00BH9,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("P00BH10", "UPDATE [SolicitudesItems] SET [SolicitudesItemsComiProv]=@SolicitudesItemsComiProv, [SolicitudesItemsComiProvP]=@SolicitudesItemsComiProvP, [SolicitudesItemsComiALM]=@SolicitudesItemsComiALM, [SolicitudesItemsComiALMP]=@SolicitudesItemsComiALMP  WHERE [SolicitudesID] = @SolicitudesID AND [SolicitudesItemsID] = @SolicitudesItemsID", GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP00BH10)
           ,new CursorDef("P00BH11", "SELECT [SolicitudesID], [SolicitudesItemsID], [SolicitudItemsComision], [SolicitudItemsComisionTipo], [SolicitudItemsSR], [SolicitudesItemsCantidad], [SolicitudesItemsPrecioFinal] FROM [SolicitudesItems] WHERE [SolicitudesID] = @SolicitudesID ORDER BY [SolicitudesID] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00BH11,100, GxCacheFrequency.OFF ,true,false )
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
              ((decimal[]) buf[2])[0] = rslt.getDecimal(3);
              ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
              ((decimal[]) buf[4])[0] = rslt.getDecimal(5);
              ((decimal[]) buf[5])[0] = rslt.getDecimal(6);
              ((bool[]) buf[6])[0] = rslt.wasNull(6);
              ((decimal[]) buf[7])[0] = rslt.getDecimal(7);
              return;
           case 1 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 3);
              ((long[]) buf[2])[0] = rslt.getLong(3);
              ((string[]) buf[3])[0] = rslt.getString(4, 20);
              ((long[]) buf[4])[0] = rslt.getLong(5);
              return;
           case 2 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              ((bool[]) buf[1])[0] = rslt.wasNull(1);
              ((string[]) buf[2])[0] = rslt.getString(2, 1);
              ((long[]) buf[3])[0] = rslt.getLong(3);
              ((decimal[]) buf[4])[0] = rslt.getDecimal(4);
              ((bool[]) buf[5])[0] = rslt.wasNull(4);
              return;
           case 3 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              ((bool[]) buf[1])[0] = rslt.wasNull(1);
              ((string[]) buf[2])[0] = rslt.getString(2, 1);
              ((long[]) buf[3])[0] = rslt.getLong(3);
              ((decimal[]) buf[4])[0] = rslt.getDecimal(4);
              ((bool[]) buf[5])[0] = rslt.wasNull(4);
              ((bool[]) buf[6])[0] = rslt.getBool(5);
              ((bool[]) buf[7])[0] = rslt.wasNull(5);
              return;
           case 4 :
              ((string[]) buf[0])[0] = rslt.getString(1, 20);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              return;
           case 5 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              return;
           case 6 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              return;
           case 7 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              ((long[]) buf[2])[0] = rslt.getLong(3);
              ((long[]) buf[3])[0] = rslt.getLong(4);
              ((decimal[]) buf[4])[0] = rslt.getDecimal(5);
              ((decimal[]) buf[5])[0] = rslt.getDecimal(6);
              ((decimal[]) buf[6])[0] = rslt.getDecimal(7);
              ((bool[]) buf[7])[0] = rslt.wasNull(7);
              ((decimal[]) buf[8])[0] = rslt.getDecimal(8);
              ((bool[]) buf[9])[0] = rslt.wasNull(8);
              ((decimal[]) buf[10])[0] = rslt.getDecimal(9);
              ((bool[]) buf[11])[0] = rslt.wasNull(9);
              ((decimal[]) buf[12])[0] = rslt.getDecimal(10);
              ((bool[]) buf[13])[0] = rslt.wasNull(10);
              ((decimal[]) buf[14])[0] = rslt.getDecimal(11);
              ((bool[]) buf[15])[0] = rslt.wasNull(11);
              ((short[]) buf[16])[0] = rslt.getShort(12);
              ((decimal[]) buf[17])[0] = rslt.getDecimal(13);
              ((string[]) buf[18])[0] = rslt.getString(14, 1);
              ((string[]) buf[19])[0] = rslt.getString(15, 1);
              ((short[]) buf[20])[0] = rslt.getShort(16);
              ((decimal[]) buf[21])[0] = rslt.getDecimal(17);
              ((bool[]) buf[22])[0] = rslt.wasNull(17);
              return;
           case 9 :
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

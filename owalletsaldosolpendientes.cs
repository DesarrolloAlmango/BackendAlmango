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
   public class owalletsaldosolpendientes : GXProcedure
   {
      public owalletsaldosolpendientes( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public owalletsaldosolpendientes( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_WalletCodRefencia ,
                           out decimal aP1_TotalPendiente )
      {
         this.AV9WalletCodRefencia = aP0_WalletCodRefencia;
         this.AV8TotalPendiente = 0 ;
         initialize();
         ExecutePrivate();
         aP1_TotalPendiente=this.AV8TotalPendiente;
      }

      public decimal executeUdp( string aP0_WalletCodRefencia )
      {
         execute(aP0_WalletCodRefencia, out aP1_TotalPendiente);
         return AV8TotalPendiente ;
      }

      public void executeSubmit( string aP0_WalletCodRefencia ,
                                 out decimal aP1_TotalPendiente )
      {
         this.AV9WalletCodRefencia = aP0_WalletCodRefencia;
         this.AV8TotalPendiente = 0 ;
         SubmitImpl();
         aP1_TotalPendiente=this.AV8TotalPendiente;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV8TotalPendiente = 0;
         AV10FechaDesde = DateTimeUtil.DAdd(DateTimeUtil.ServerDate( context, pr_default),-((int)(7)));
         /* Using cursor P00NF2 */
         pr_default.execute(0, new Object[] {AV9WalletCodRefencia, AV10FechaDesde});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A127SolicitudesID = P00NF2_A127SolicitudesID[0];
            A184SolicitudesFechaInstalacion = P00NF2_A184SolicitudesFechaInstalacion[0];
            A131EstadosSolId = P00NF2_A131EstadosSolId[0];
            A130EstadosSolTipo = P00NF2_A130EstadosSolTipo[0];
            A688SolicitudesLiqProf = P00NF2_A688SolicitudesLiqProf[0];
            n688SolicitudesLiqProf = P00NF2_n688SolicitudesLiqProf[0];
            A142EstadoSGId = P00NF2_A142EstadoSGId[0];
            A141EstadoSGTipo = P00NF2_A141EstadoSGTipo[0];
            A120ProfesionalesId = P00NF2_A120ProfesionalesId[0];
            A438SolicitudServicioOrigenPago = P00NF2_A438SolicitudServicioOrigenPago[0];
            n438SolicitudServicioOrigenPago = P00NF2_n438SolicitudServicioOrigenPago[0];
            A796SolicitudesComisionMetodoPago = P00NF2_A796SolicitudesComisionMetodoPago[0];
            A212SolicitudesCotizacion = P00NF2_A212SolicitudesCotizacion[0];
            A1016SolicitudesDescuentoCupon = P00NF2_A1016SolicitudesDescuentoCupon[0];
            A897SolicitudesDescuento = P00NF2_A897SolicitudesDescuento[0];
            n897SolicitudesDescuento = P00NF2_n897SolicitudesDescuento[0];
            A527SolicitudServicioComProv = P00NF2_A527SolicitudServicioComProv[0];
            n527SolicitudServicioComProv = P00NF2_n527SolicitudServicioComProv[0];
            A530SolicitudServicioComALM = P00NF2_A530SolicitudServicioComALM[0];
            n530SolicitudServicioComALM = P00NF2_n530SolicitudServicioComALM[0];
            A865SolicitudesCostoXZComAlm = P00NF2_A865SolicitudesCostoXZComAlm[0];
            n865SolicitudesCostoXZComAlm = P00NF2_n865SolicitudesCostoXZComAlm[0];
            A864SolicitudesCostoXZona = P00NF2_A864SolicitudesCostoXZona[0];
            A140RelacionesId = P00NF2_A140RelacionesId[0];
            A184SolicitudesFechaInstalacion = P00NF2_A184SolicitudesFechaInstalacion[0];
            A131EstadosSolId = P00NF2_A131EstadosSolId[0];
            A130EstadosSolTipo = P00NF2_A130EstadosSolTipo[0];
            A688SolicitudesLiqProf = P00NF2_A688SolicitudesLiqProf[0];
            n688SolicitudesLiqProf = P00NF2_n688SolicitudesLiqProf[0];
            A438SolicitudServicioOrigenPago = P00NF2_A438SolicitudServicioOrigenPago[0];
            n438SolicitudServicioOrigenPago = P00NF2_n438SolicitudServicioOrigenPago[0];
            A796SolicitudesComisionMetodoPago = P00NF2_A796SolicitudesComisionMetodoPago[0];
            A212SolicitudesCotizacion = P00NF2_A212SolicitudesCotizacion[0];
            A1016SolicitudesDescuentoCupon = P00NF2_A1016SolicitudesDescuentoCupon[0];
            A897SolicitudesDescuento = P00NF2_A897SolicitudesDescuento[0];
            n897SolicitudesDescuento = P00NF2_n897SolicitudesDescuento[0];
            A527SolicitudServicioComProv = P00NF2_A527SolicitudServicioComProv[0];
            n527SolicitudServicioComProv = P00NF2_n527SolicitudServicioComProv[0];
            A530SolicitudServicioComALM = P00NF2_A530SolicitudServicioComALM[0];
            n530SolicitudServicioComALM = P00NF2_n530SolicitudServicioComALM[0];
            A865SolicitudesCostoXZComAlm = P00NF2_A865SolicitudesCostoXZComAlm[0];
            n865SolicitudesCostoXZComAlm = P00NF2_n865SolicitudesCostoXZComAlm[0];
            A864SolicitudesCostoXZona = P00NF2_A864SolicitudesCostoXZona[0];
            if ( StringUtil.StrCmp(A141EstadoSGTipo, context.GetMessage( "STS", "")) == 0 )
            {
               if ( StringUtil.StrCmp(A130EstadosSolTipo, context.GetMessage( "SOL", "")) == 0 )
               {
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
                  if ( ( A865SolicitudesCostoXZComAlm < Convert.ToDecimal( 0 )) )
                  {
                     A867SolicitudesCostoXZComProf = (decimal)(A864SolicitudesCostoXZona+(A865SolicitudesCostoXZComAlm*-1));
                  }
                  else
                  {
                     A867SolicitudesCostoXZComProf = (decimal)(A864SolicitudesCostoXZona-(A865SolicitudesCostoXZComAlm));
                  }
                  AV11NetoFila = (decimal)(A529SolicitudServicioComPro+A867SolicitudesCostoXZComProf);
                  if ( StringUtil.StrCmp(A438SolicitudServicioOrigenPago, context.GetMessage( "F", "")) == 0 )
                  {
                     AV11NetoFila = (decimal)(AV11NetoFila-A211SolicitudServicioPFinal);
                  }
                  AV8TotalPendiente = (decimal)(AV8TotalPendiente+AV11NetoFila);
               }
            }
            pr_default.readNext(0);
         }
         pr_default.close(0);
         cleanup();
      }

      protected void GetSolicitudesTotal( long A127SolicitudesID )
      {
         /* Create private dbobjects */
         /* Navigation */
         A174SolicitudesTotal = 0;
         /* Using cursor P00NF3 */
         pr_default.execute(1, new Object[] {A127SolicitudesID});
         while ( (pr_default.getStatus(1) != 101) && ( P00NF3_A127SolicitudesID[0] == A127SolicitudesID ) )
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( P00NF3_A178SolicitudItemsSR[0])) || ( StringUtil.StrCmp(P00NF3_A179SolicitudItemsComisionTipo[0], "N") == 0 ) )
            {
               A175SolicitudesItemsPrecioInstalac = (decimal)((P00NF3_A176SolicitudesItemsPrecioFinal[0]*P00NF3_A177SolicitudesItemsCantidad[0]));
            }
            else
            {
               if ( ( StringUtil.StrCmp(P00NF3_A179SolicitudItemsComisionTipo[0], "F") == 0 ) && ( StringUtil.StrCmp(P00NF3_A178SolicitudItemsSR[0], "R") == 0 ) )
               {
                  A175SolicitudesItemsPrecioInstalac = (decimal)((P00NF3_A176SolicitudesItemsPrecioFinal[0]*P00NF3_A177SolicitudesItemsCantidad[0])-(P00NF3_A180SolicitudItemsComision[0]*P00NF3_A177SolicitudesItemsCantidad[0]));
               }
               else
               {
                  if ( ( StringUtil.StrCmp(P00NF3_A179SolicitudItemsComisionTipo[0], "F") == 0 ) && ( StringUtil.StrCmp(P00NF3_A178SolicitudItemsSR[0], "S") == 0 ) )
                  {
                     A175SolicitudesItemsPrecioInstalac = (decimal)((P00NF3_A176SolicitudesItemsPrecioFinal[0]*P00NF3_A177SolicitudesItemsCantidad[0])+(P00NF3_A180SolicitudItemsComision[0]*P00NF3_A177SolicitudesItemsCantidad[0]));
                  }
                  else
                  {
                     if ( ( StringUtil.StrCmp(P00NF3_A179SolicitudItemsComisionTipo[0], "P") == 0 ) && ( StringUtil.StrCmp(P00NF3_A178SolicitudItemsSR[0], "R") == 0 ) )
                     {
                        A175SolicitudesItemsPrecioInstalac = (decimal)((P00NF3_A176SolicitudesItemsPrecioFinal[0]*P00NF3_A177SolicitudesItemsCantidad[0])-((P00NF3_A176SolicitudesItemsPrecioFinal[0]*P00NF3_A177SolicitudesItemsCantidad[0])*(P00NF3_A180SolicitudItemsComision[0]/ (decimal)(100))));
                     }
                     else
                     {
                        if ( ( StringUtil.StrCmp(P00NF3_A179SolicitudItemsComisionTipo[0], "P") == 0 ) && ( StringUtil.StrCmp(P00NF3_A178SolicitudItemsSR[0], "S") == 0 ) )
                        {
                           A175SolicitudesItemsPrecioInstalac = (decimal)((P00NF3_A176SolicitudesItemsPrecioFinal[0]*P00NF3_A177SolicitudesItemsCantidad[0])+((P00NF3_A176SolicitudesItemsPrecioFinal[0]*P00NF3_A177SolicitudesItemsCantidad[0])*(P00NF3_A180SolicitudItemsComision[0]/ (decimal)(100))));
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
         if ( IsMain )
         {
            context.CloseConnections();
         }
         ExitApp();
      }

      public override void initialize( )
      {
         AV10FechaDesde = DateTime.MinValue;
         P00NF2_A127SolicitudesID = new long[1] ;
         P00NF2_A184SolicitudesFechaInstalacion = new DateTime[] {DateTime.MinValue} ;
         P00NF2_A131EstadosSolId = new int[1] ;
         P00NF2_A130EstadosSolTipo = new string[] {""} ;
         P00NF2_A688SolicitudesLiqProf = new long[1] ;
         P00NF2_n688SolicitudesLiqProf = new bool[] {false} ;
         P00NF2_A142EstadoSGId = new int[1] ;
         P00NF2_A141EstadoSGTipo = new string[] {""} ;
         P00NF2_A120ProfesionalesId = new string[] {""} ;
         P00NF2_A438SolicitudServicioOrigenPago = new string[] {""} ;
         P00NF2_n438SolicitudServicioOrigenPago = new bool[] {false} ;
         P00NF2_A796SolicitudesComisionMetodoPago = new decimal[1] ;
         P00NF2_A212SolicitudesCotizacion = new decimal[1] ;
         P00NF2_A1016SolicitudesDescuentoCupon = new decimal[1] ;
         P00NF2_A897SolicitudesDescuento = new decimal[1] ;
         P00NF2_n897SolicitudesDescuento = new bool[] {false} ;
         P00NF2_A527SolicitudServicioComProv = new decimal[1] ;
         P00NF2_n527SolicitudServicioComProv = new bool[] {false} ;
         P00NF2_A530SolicitudServicioComALM = new decimal[1] ;
         P00NF2_n530SolicitudServicioComALM = new bool[] {false} ;
         P00NF2_A865SolicitudesCostoXZComAlm = new decimal[1] ;
         P00NF2_n865SolicitudesCostoXZComAlm = new bool[] {false} ;
         P00NF2_A864SolicitudesCostoXZona = new decimal[1] ;
         P00NF2_A140RelacionesId = new long[1] ;
         A184SolicitudesFechaInstalacion = DateTime.MinValue;
         A130EstadosSolTipo = "";
         A141EstadoSGTipo = "";
         A120ProfesionalesId = "";
         A438SolicitudServicioOrigenPago = "";
         P00NF3_A127SolicitudesID = new long[1] ;
         P00NF3_A134SolicitudesItemsID = new short[1] ;
         P00NF3_A180SolicitudItemsComision = new decimal[1] ;
         P00NF3_A179SolicitudItemsComisionTipo = new string[] {""} ;
         P00NF3_A178SolicitudItemsSR = new string[] {""} ;
         P00NF3_A177SolicitudesItemsCantidad = new short[1] ;
         P00NF3_A176SolicitudesItemsPrecioFinal = new decimal[1] ;
         P00NF3_n176SolicitudesItemsPrecioFinal = new bool[] {false} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.owalletsaldosolpendientes__default(),
            new Object[][] {
                new Object[] {
               P00NF2_A127SolicitudesID, P00NF2_A184SolicitudesFechaInstalacion, P00NF2_A131EstadosSolId, P00NF2_A130EstadosSolTipo, P00NF2_A688SolicitudesLiqProf, P00NF2_n688SolicitudesLiqProf, P00NF2_A142EstadoSGId, P00NF2_A141EstadoSGTipo, P00NF2_A120ProfesionalesId, P00NF2_A438SolicitudServicioOrigenPago,
               P00NF2_n438SolicitudServicioOrigenPago, P00NF2_A796SolicitudesComisionMetodoPago, P00NF2_A212SolicitudesCotizacion, P00NF2_A1016SolicitudesDescuentoCupon, P00NF2_A897SolicitudesDescuento, P00NF2_n897SolicitudesDescuento, P00NF2_A527SolicitudServicioComProv, P00NF2_n527SolicitudServicioComProv, P00NF2_A530SolicitudServicioComALM, P00NF2_n530SolicitudServicioComALM,
               P00NF2_A865SolicitudesCostoXZComAlm, P00NF2_n865SolicitudesCostoXZComAlm, P00NF2_A864SolicitudesCostoXZona, P00NF2_A140RelacionesId
               }
               , new Object[] {
               P00NF3_A127SolicitudesID, P00NF3_A134SolicitudesItemsID, P00NF3_A180SolicitudItemsComision, P00NF3_A179SolicitudItemsComisionTipo, P00NF3_A178SolicitudItemsSR, P00NF3_A177SolicitudesItemsCantidad, P00NF3_A176SolicitudesItemsPrecioFinal, P00NF3_n176SolicitudesItemsPrecioFinal
               }
            }
         );
         /* GeneXus formulas. */
      }

      private int A131EstadosSolId ;
      private int A142EstadoSGId ;
      private long A127SolicitudesID ;
      private long A688SolicitudesLiqProf ;
      private long A140RelacionesId ;
      private decimal AV8TotalPendiente ;
      private decimal A796SolicitudesComisionMetodoPago ;
      private decimal A212SolicitudesCotizacion ;
      private decimal A1016SolicitudesDescuentoCupon ;
      private decimal A897SolicitudesDescuento ;
      private decimal A527SolicitudServicioComProv ;
      private decimal A530SolicitudServicioComALM ;
      private decimal A865SolicitudesCostoXZComAlm ;
      private decimal A864SolicitudesCostoXZona ;
      private decimal A211SolicitudServicioPFinal ;
      private decimal A174SolicitudesTotal ;
      private decimal A529SolicitudServicioComPro ;
      private decimal A867SolicitudesCostoXZComProf ;
      private decimal AV11NetoFila ;
      private decimal A175SolicitudesItemsPrecioInstalac ;
      private string AV9WalletCodRefencia ;
      private string A130EstadosSolTipo ;
      private string A141EstadoSGTipo ;
      private string A120ProfesionalesId ;
      private string A438SolicitudServicioOrigenPago ;
      private DateTime AV10FechaDesde ;
      private DateTime A184SolicitudesFechaInstalacion ;
      private bool n688SolicitudesLiqProf ;
      private bool n438SolicitudServicioOrigenPago ;
      private bool n897SolicitudesDescuento ;
      private bool n527SolicitudServicioComProv ;
      private bool n530SolicitudServicioComALM ;
      private bool n865SolicitudesCostoXZComAlm ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private long[] P00NF2_A127SolicitudesID ;
      private DateTime[] P00NF2_A184SolicitudesFechaInstalacion ;
      private int[] P00NF2_A131EstadosSolId ;
      private string[] P00NF2_A130EstadosSolTipo ;
      private long[] P00NF2_A688SolicitudesLiqProf ;
      private bool[] P00NF2_n688SolicitudesLiqProf ;
      private int[] P00NF2_A142EstadoSGId ;
      private string[] P00NF2_A141EstadoSGTipo ;
      private string[] P00NF2_A120ProfesionalesId ;
      private string[] P00NF2_A438SolicitudServicioOrigenPago ;
      private bool[] P00NF2_n438SolicitudServicioOrigenPago ;
      private decimal[] P00NF2_A796SolicitudesComisionMetodoPago ;
      private decimal[] P00NF2_A212SolicitudesCotizacion ;
      private decimal[] P00NF2_A1016SolicitudesDescuentoCupon ;
      private decimal[] P00NF2_A897SolicitudesDescuento ;
      private bool[] P00NF2_n897SolicitudesDescuento ;
      private decimal[] P00NF2_A527SolicitudServicioComProv ;
      private bool[] P00NF2_n527SolicitudServicioComProv ;
      private decimal[] P00NF2_A530SolicitudServicioComALM ;
      private bool[] P00NF2_n530SolicitudServicioComALM ;
      private decimal[] P00NF2_A865SolicitudesCostoXZComAlm ;
      private bool[] P00NF2_n865SolicitudesCostoXZComAlm ;
      private decimal[] P00NF2_A864SolicitudesCostoXZona ;
      private long[] P00NF2_A140RelacionesId ;
      private long[] P00NF3_A127SolicitudesID ;
      private short[] P00NF3_A134SolicitudesItemsID ;
      private decimal[] P00NF3_A180SolicitudItemsComision ;
      private string[] P00NF3_A179SolicitudItemsComisionTipo ;
      private string[] P00NF3_A178SolicitudItemsSR ;
      private short[] P00NF3_A177SolicitudesItemsCantidad ;
      private decimal[] P00NF3_A176SolicitudesItemsPrecioFinal ;
      private bool[] P00NF3_n176SolicitudesItemsPrecioFinal ;
      private decimal aP1_TotalPendiente ;
   }

   public class owalletsaldosolpendientes__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP00NF2;
          prmP00NF2 = new Object[] {
          new ParDef("@AV9WalletCodRefencia",GXType.Char,25,0) ,
          new ParDef("@AV10FechaDesde",GXType.Date,8,0)
          };
          Object[] prmP00NF3;
          prmP00NF3 = new Object[] {
          new ParDef("@SolicitudesID",GXType.Decimal,18,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00NF2", "SELECT T1.[SolicitudesID], T2.[SolicitudesFechaInstalacion], T2.[EstadosSolId], T2.[EstadosSolTipo], T2.[SolicitudesLiqProf], T1.[EstadoSGId], T1.[EstadoSGTipo], T1.[ProfesionalesId], T2.[SolicitudServicioOrigenPago], T2.[SolicitudesComisionMetodoPago], T2.[SolicitudesCotizacion], T2.[SolicitudesDescuentoCupon], T2.[SolicitudesDescuento], T2.[SolicitudServicioComProv], T2.[SolicitudServicioComALM], T2.[SolicitudesCostoXZComAlm], T2.[SolicitudesCostoXZona], T1.[RelacionesId] FROM ([Relaciones] T1 INNER JOIN [Solicitudes] T2 ON T2.[SolicitudesID] = T1.[SolicitudesID]) WHERE (T1.[ProfesionalesId] = RTRIM(LTRIM(@AV9WalletCodRefencia))) AND (T2.[SolicitudesLiqProf] IS NULL or (T2.[SolicitudesLiqProf] = convert(int, 0)) or T2.[SolicitudesLiqProf] = 0) AND (T2.[EstadosSolId] IN (2,5,6,7)) AND (T2.[SolicitudesFechaInstalacion] >= @AV10FechaDesde) AND (T1.[EstadoSGId] = 1) ORDER BY T1.[SolicitudesID], T1.[RelacionesId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00NF2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00NF3", "SELECT [SolicitudesID], [SolicitudesItemsID], [SolicitudItemsComision], [SolicitudItemsComisionTipo], [SolicitudItemsSR], [SolicitudesItemsCantidad], [SolicitudesItemsPrecioFinal] FROM [SolicitudesItems] WHERE [SolicitudesID] = @SolicitudesID ORDER BY [SolicitudesID] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00NF3,100, GxCacheFrequency.OFF ,true,false )
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
                ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
                ((int[]) buf[2])[0] = rslt.getInt(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 3);
                ((long[]) buf[4])[0] = rslt.getLong(5);
                ((bool[]) buf[5])[0] = rslt.wasNull(5);
                ((int[]) buf[6])[0] = rslt.getInt(6);
                ((string[]) buf[7])[0] = rslt.getString(7, 3);
                ((string[]) buf[8])[0] = rslt.getString(8, 20);
                ((string[]) buf[9])[0] = rslt.getString(9, 1);
                ((bool[]) buf[10])[0] = rslt.wasNull(9);
                ((decimal[]) buf[11])[0] = rslt.getDecimal(10);
                ((decimal[]) buf[12])[0] = rslt.getDecimal(11);
                ((decimal[]) buf[13])[0] = rslt.getDecimal(12);
                ((decimal[]) buf[14])[0] = rslt.getDecimal(13);
                ((bool[]) buf[15])[0] = rslt.wasNull(13);
                ((decimal[]) buf[16])[0] = rslt.getDecimal(14);
                ((bool[]) buf[17])[0] = rslt.wasNull(14);
                ((decimal[]) buf[18])[0] = rslt.getDecimal(15);
                ((bool[]) buf[19])[0] = rslt.wasNull(15);
                ((decimal[]) buf[20])[0] = rslt.getDecimal(16);
                ((bool[]) buf[21])[0] = rslt.wasNull(16);
                ((decimal[]) buf[22])[0] = rslt.getDecimal(17);
                ((long[]) buf[23])[0] = rslt.getLong(18);
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

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
   public class obtenercomiprodvarios : GXProcedure
   {
      public obtenercomiprodvarios( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public obtenercomiprodvarios( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( long aP0_SolicitudesId ,
                           out decimal aP1_SolicitudServicioComALM ,
                           out decimal aP2_SolicitudServicioComProv ,
                           out decimal aP3_SolicitudServicioComPro )
      {
         this.AV8SolicitudesId = aP0_SolicitudesId;
         this.AV11SolicitudServicioComALM = 0 ;
         this.AV13SolicitudServicioComProv = 0 ;
         this.AV9SolicitudServicioComPro = 0 ;
         initialize();
         ExecutePrivate();
         aP1_SolicitudServicioComALM=this.AV11SolicitudServicioComALM;
         aP2_SolicitudServicioComProv=this.AV13SolicitudServicioComProv;
         aP3_SolicitudServicioComPro=this.AV9SolicitudServicioComPro;
      }

      public decimal executeUdp( long aP0_SolicitudesId ,
                                 out decimal aP1_SolicitudServicioComALM ,
                                 out decimal aP2_SolicitudServicioComProv )
      {
         execute(aP0_SolicitudesId, out aP1_SolicitudServicioComALM, out aP2_SolicitudServicioComProv, out aP3_SolicitudServicioComPro);
         return AV9SolicitudServicioComPro ;
      }

      public void executeSubmit( long aP0_SolicitudesId ,
                                 out decimal aP1_SolicitudServicioComALM ,
                                 out decimal aP2_SolicitudServicioComProv ,
                                 out decimal aP3_SolicitudServicioComPro )
      {
         this.AV8SolicitudesId = aP0_SolicitudesId;
         this.AV11SolicitudServicioComALM = 0 ;
         this.AV13SolicitudServicioComProv = 0 ;
         this.AV9SolicitudServicioComPro = 0 ;
         SubmitImpl();
         aP1_SolicitudServicioComALM=this.AV11SolicitudServicioComALM;
         aP2_SolicitudServicioComProv=this.AV13SolicitudServicioComProv;
         aP3_SolicitudServicioComPro=this.AV9SolicitudServicioComPro;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV11SolicitudServicioComALM = 0;
         AV13SolicitudServicioComProv = 0;
         AV9SolicitudServicioComPro = 0;
         /* Using cursor P00NB2 */
         pr_default.execute(0, new Object[] {AV8SolicitudesId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A127SolicitudesID = P00NB2_A127SolicitudesID[0];
            A177SolicitudesItemsCantidad = P00NB2_A177SolicitudesItemsCantidad[0];
            A176SolicitudesItemsPrecioFinal = P00NB2_A176SolicitudesItemsPrecioFinal[0];
            n176SolicitudesItemsPrecioFinal = P00NB2_n176SolicitudesItemsPrecioFinal[0];
            A526SolicitudesItemsComiALMP = P00NB2_A526SolicitudesItemsComiALMP[0];
            n526SolicitudesItemsComiALMP = P00NB2_n526SolicitudesItemsComiALMP[0];
            A524SolicitudesItemsComiProvP = P00NB2_A524SolicitudesItemsComiProvP[0];
            n524SolicitudesItemsComiProvP = P00NB2_n524SolicitudesItemsComiProvP[0];
            A134SolicitudesItemsID = P00NB2_A134SolicitudesItemsID[0];
            A525SolicitudesItemsComiProfP = (decimal)(100-(A524SolicitudesItemsComiProvP+A526SolicitudesItemsComiALMP));
            AV11SolicitudServicioComALM = (decimal)(AV11SolicitudServicioComALM+(((A526SolicitudesItemsComiALMP/ (decimal)(100))*A176SolicitudesItemsPrecioFinal*A177SolicitudesItemsCantidad)));
            AV13SolicitudServicioComProv = (decimal)(AV13SolicitudServicioComProv+(((A524SolicitudesItemsComiProvP/ (decimal)(100))*A176SolicitudesItemsPrecioFinal*A177SolicitudesItemsCantidad)));
            AV9SolicitudServicioComPro = (decimal)(AV9SolicitudServicioComPro+(((A525SolicitudesItemsComiProfP/ (decimal)(100))*A176SolicitudesItemsPrecioFinal*A177SolicitudesItemsCantidad)));
            pr_default.readNext(0);
         }
         pr_default.close(0);
         /* Using cursor P00NB3 */
         pr_default.execute(1, new Object[] {AV8SolicitudesId});
         while ( (pr_default.getStatus(1) != 101) )
         {
            A127SolicitudesID = P00NB3_A127SolicitudesID[0];
            A796SolicitudesComisionMetodoPago = P00NB3_A796SolicitudesComisionMetodoPago[0];
            A212SolicitudesCotizacion = P00NB3_A212SolicitudesCotizacion[0];
            A1016SolicitudesDescuentoCupon = P00NB3_A1016SolicitudesDescuentoCupon[0];
            A897SolicitudesDescuento = P00NB3_A897SolicitudesDescuento[0];
            n897SolicitudesDescuento = P00NB3_n897SolicitudesDescuento[0];
            A864SolicitudesCostoXZona = P00NB3_A864SolicitudesCostoXZona[0];
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
            if ( ( A897SolicitudesDescuento > Convert.ToDecimal( 0 )) || ( A212SolicitudesCotizacion > Convert.ToDecimal( 0 )) )
            {
               AV11SolicitudServicioComALM = (decimal)(0.2m*A211SolicitudServicioPFinal);
               AV13SolicitudServicioComProv = (decimal)(0.1m*A211SolicitudServicioPFinal);
               AV9SolicitudServicioComPro = (decimal)(0.7m*A211SolicitudServicioPFinal);
            }
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(1);
         cleanup();
      }

      protected void GetSolicitudesTotal( long A127SolicitudesID )
      {
         /* Create private dbobjects */
         /* Navigation */
         A174SolicitudesTotal = 0;
         /* Using cursor P00NB4 */
         pr_default.execute(2, new Object[] {A127SolicitudesID});
         while ( (pr_default.getStatus(2) != 101) && ( P00NB4_A127SolicitudesID[0] == A127SolicitudesID ) )
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( P00NB4_A178SolicitudItemsSR[0])) || ( StringUtil.StrCmp(P00NB4_A179SolicitudItemsComisionTipo[0], "N") == 0 ) )
            {
               A175SolicitudesItemsPrecioInstalac = (decimal)((P00NB4_A176SolicitudesItemsPrecioFinal[0]*P00NB4_A177SolicitudesItemsCantidad[0]));
            }
            else
            {
               if ( ( StringUtil.StrCmp(P00NB4_A179SolicitudItemsComisionTipo[0], "F") == 0 ) && ( StringUtil.StrCmp(P00NB4_A178SolicitudItemsSR[0], "R") == 0 ) )
               {
                  A175SolicitudesItemsPrecioInstalac = (decimal)((P00NB4_A176SolicitudesItemsPrecioFinal[0]*P00NB4_A177SolicitudesItemsCantidad[0])-(P00NB4_A180SolicitudItemsComision[0]*P00NB4_A177SolicitudesItemsCantidad[0]));
               }
               else
               {
                  if ( ( StringUtil.StrCmp(P00NB4_A179SolicitudItemsComisionTipo[0], "F") == 0 ) && ( StringUtil.StrCmp(P00NB4_A178SolicitudItemsSR[0], "S") == 0 ) )
                  {
                     A175SolicitudesItemsPrecioInstalac = (decimal)((P00NB4_A176SolicitudesItemsPrecioFinal[0]*P00NB4_A177SolicitudesItemsCantidad[0])+(P00NB4_A180SolicitudItemsComision[0]*P00NB4_A177SolicitudesItemsCantidad[0]));
                  }
                  else
                  {
                     if ( ( StringUtil.StrCmp(P00NB4_A179SolicitudItemsComisionTipo[0], "P") == 0 ) && ( StringUtil.StrCmp(P00NB4_A178SolicitudItemsSR[0], "R") == 0 ) )
                     {
                        A175SolicitudesItemsPrecioInstalac = (decimal)((P00NB4_A176SolicitudesItemsPrecioFinal[0]*P00NB4_A177SolicitudesItemsCantidad[0])-((P00NB4_A176SolicitudesItemsPrecioFinal[0]*P00NB4_A177SolicitudesItemsCantidad[0])*(P00NB4_A180SolicitudItemsComision[0]/ (decimal)(100))));
                     }
                     else
                     {
                        if ( ( StringUtil.StrCmp(P00NB4_A179SolicitudItemsComisionTipo[0], "P") == 0 ) && ( StringUtil.StrCmp(P00NB4_A178SolicitudItemsSR[0], "S") == 0 ) )
                        {
                           A175SolicitudesItemsPrecioInstalac = (decimal)((P00NB4_A176SolicitudesItemsPrecioFinal[0]*P00NB4_A177SolicitudesItemsCantidad[0])+((P00NB4_A176SolicitudesItemsPrecioFinal[0]*P00NB4_A177SolicitudesItemsCantidad[0])*(P00NB4_A180SolicitudItemsComision[0]/ (decimal)(100))));
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
         P00NB2_A127SolicitudesID = new long[1] ;
         P00NB2_A177SolicitudesItemsCantidad = new short[1] ;
         P00NB2_A176SolicitudesItemsPrecioFinal = new decimal[1] ;
         P00NB2_n176SolicitudesItemsPrecioFinal = new bool[] {false} ;
         P00NB2_A526SolicitudesItemsComiALMP = new decimal[1] ;
         P00NB2_n526SolicitudesItemsComiALMP = new bool[] {false} ;
         P00NB2_A524SolicitudesItemsComiProvP = new decimal[1] ;
         P00NB2_n524SolicitudesItemsComiProvP = new bool[] {false} ;
         P00NB2_A134SolicitudesItemsID = new short[1] ;
         P00NB3_A127SolicitudesID = new long[1] ;
         P00NB3_A796SolicitudesComisionMetodoPago = new decimal[1] ;
         P00NB3_A212SolicitudesCotizacion = new decimal[1] ;
         P00NB3_A1016SolicitudesDescuentoCupon = new decimal[1] ;
         P00NB3_A897SolicitudesDescuento = new decimal[1] ;
         P00NB3_n897SolicitudesDescuento = new bool[] {false} ;
         P00NB3_A864SolicitudesCostoXZona = new decimal[1] ;
         P00NB4_A127SolicitudesID = new long[1] ;
         P00NB4_A134SolicitudesItemsID = new short[1] ;
         P00NB4_A180SolicitudItemsComision = new decimal[1] ;
         P00NB4_A179SolicitudItemsComisionTipo = new string[] {""} ;
         P00NB4_A178SolicitudItemsSR = new string[] {""} ;
         P00NB4_A177SolicitudesItemsCantidad = new short[1] ;
         P00NB4_A176SolicitudesItemsPrecioFinal = new decimal[1] ;
         P00NB4_n176SolicitudesItemsPrecioFinal = new bool[] {false} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.obtenercomiprodvarios__default(),
            new Object[][] {
                new Object[] {
               P00NB2_A127SolicitudesID, P00NB2_A177SolicitudesItemsCantidad, P00NB2_A176SolicitudesItemsPrecioFinal, P00NB2_n176SolicitudesItemsPrecioFinal, P00NB2_A526SolicitudesItemsComiALMP, P00NB2_n526SolicitudesItemsComiALMP, P00NB2_A524SolicitudesItemsComiProvP, P00NB2_n524SolicitudesItemsComiProvP, P00NB2_A134SolicitudesItemsID
               }
               , new Object[] {
               P00NB3_A127SolicitudesID, P00NB3_A796SolicitudesComisionMetodoPago, P00NB3_A212SolicitudesCotizacion, P00NB3_A1016SolicitudesDescuentoCupon, P00NB3_A897SolicitudesDescuento, P00NB3_n897SolicitudesDescuento, P00NB3_A864SolicitudesCostoXZona
               }
               , new Object[] {
               P00NB4_A127SolicitudesID, P00NB4_A134SolicitudesItemsID, P00NB4_A180SolicitudItemsComision, P00NB4_A179SolicitudItemsComisionTipo, P00NB4_A178SolicitudItemsSR, P00NB4_A177SolicitudesItemsCantidad, P00NB4_A176SolicitudesItemsPrecioFinal, P00NB4_n176SolicitudesItemsPrecioFinal
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short A177SolicitudesItemsCantidad ;
      private short A134SolicitudesItemsID ;
      private long AV8SolicitudesId ;
      private long A127SolicitudesID ;
      private decimal AV11SolicitudServicioComALM ;
      private decimal AV13SolicitudServicioComProv ;
      private decimal AV9SolicitudServicioComPro ;
      private decimal A176SolicitudesItemsPrecioFinal ;
      private decimal A526SolicitudesItemsComiALMP ;
      private decimal A524SolicitudesItemsComiProvP ;
      private decimal A525SolicitudesItemsComiProfP ;
      private decimal A796SolicitudesComisionMetodoPago ;
      private decimal A212SolicitudesCotizacion ;
      private decimal A1016SolicitudesDescuentoCupon ;
      private decimal A897SolicitudesDescuento ;
      private decimal A864SolicitudesCostoXZona ;
      private decimal A211SolicitudServicioPFinal ;
      private decimal A174SolicitudesTotal ;
      private decimal A175SolicitudesItemsPrecioInstalac ;
      private bool n176SolicitudesItemsPrecioFinal ;
      private bool n526SolicitudesItemsComiALMP ;
      private bool n524SolicitudesItemsComiProvP ;
      private bool n897SolicitudesDescuento ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private long[] P00NB2_A127SolicitudesID ;
      private short[] P00NB2_A177SolicitudesItemsCantidad ;
      private decimal[] P00NB2_A176SolicitudesItemsPrecioFinal ;
      private bool[] P00NB2_n176SolicitudesItemsPrecioFinal ;
      private decimal[] P00NB2_A526SolicitudesItemsComiALMP ;
      private bool[] P00NB2_n526SolicitudesItemsComiALMP ;
      private decimal[] P00NB2_A524SolicitudesItemsComiProvP ;
      private bool[] P00NB2_n524SolicitudesItemsComiProvP ;
      private short[] P00NB2_A134SolicitudesItemsID ;
      private long[] P00NB3_A127SolicitudesID ;
      private decimal[] P00NB3_A796SolicitudesComisionMetodoPago ;
      private decimal[] P00NB3_A212SolicitudesCotizacion ;
      private decimal[] P00NB3_A1016SolicitudesDescuentoCupon ;
      private decimal[] P00NB3_A897SolicitudesDescuento ;
      private bool[] P00NB3_n897SolicitudesDescuento ;
      private decimal[] P00NB3_A864SolicitudesCostoXZona ;
      private long[] P00NB4_A127SolicitudesID ;
      private short[] P00NB4_A134SolicitudesItemsID ;
      private decimal[] P00NB4_A180SolicitudItemsComision ;
      private string[] P00NB4_A179SolicitudItemsComisionTipo ;
      private string[] P00NB4_A178SolicitudItemsSR ;
      private short[] P00NB4_A177SolicitudesItemsCantidad ;
      private decimal[] P00NB4_A176SolicitudesItemsPrecioFinal ;
      private bool[] P00NB4_n176SolicitudesItemsPrecioFinal ;
      private decimal aP1_SolicitudServicioComALM ;
      private decimal aP2_SolicitudServicioComProv ;
      private decimal aP3_SolicitudServicioComPro ;
   }

   public class obtenercomiprodvarios__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP00NB2;
          prmP00NB2 = new Object[] {
          new ParDef("@AV8SolicitudesId",GXType.Decimal,18,0)
          };
          Object[] prmP00NB3;
          prmP00NB3 = new Object[] {
          new ParDef("@AV8SolicitudesId",GXType.Decimal,18,0)
          };
          Object[] prmP00NB4;
          prmP00NB4 = new Object[] {
          new ParDef("@SolicitudesID",GXType.Decimal,18,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00NB2", "SELECT [SolicitudesID], [SolicitudesItemsCantidad], [SolicitudesItemsPrecioFinal], [SolicitudesItemsComiALMP], [SolicitudesItemsComiProvP], [SolicitudesItemsID] FROM [SolicitudesItems] WHERE [SolicitudesID] = @AV8SolicitudesId ORDER BY [SolicitudesID] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00NB2,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P00NB3", "SELECT [SolicitudesID], [SolicitudesComisionMetodoPago], [SolicitudesCotizacion], [SolicitudesDescuentoCupon], [SolicitudesDescuento], [SolicitudesCostoXZona] FROM [Solicitudes] WHERE [SolicitudesID] = @AV8SolicitudesId ORDER BY [SolicitudesID] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00NB3,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("P00NB4", "SELECT [SolicitudesID], [SolicitudesItemsID], [SolicitudItemsComision], [SolicitudItemsComisionTipo], [SolicitudItemsSR], [SolicitudesItemsCantidad], [SolicitudesItemsPrecioFinal] FROM [SolicitudesItems] WHERE [SolicitudesID] = @SolicitudesID ORDER BY [SolicitudesID] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00NB4,100, GxCacheFrequency.OFF ,true,false )
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
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((decimal[]) buf[2])[0] = rslt.getDecimal(3);
                ((bool[]) buf[3])[0] = rslt.wasNull(3);
                ((decimal[]) buf[4])[0] = rslt.getDecimal(4);
                ((bool[]) buf[5])[0] = rslt.wasNull(4);
                ((decimal[]) buf[6])[0] = rslt.getDecimal(5);
                ((bool[]) buf[7])[0] = rslt.wasNull(5);
                ((short[]) buf[8])[0] = rslt.getShort(6);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((decimal[]) buf[1])[0] = rslt.getDecimal(2);
                ((decimal[]) buf[2])[0] = rslt.getDecimal(3);
                ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
                ((decimal[]) buf[4])[0] = rslt.getDecimal(5);
                ((bool[]) buf[5])[0] = rslt.wasNull(5);
                ((decimal[]) buf[6])[0] = rslt.getDecimal(6);
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

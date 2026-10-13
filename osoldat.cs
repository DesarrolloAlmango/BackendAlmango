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
   public class osoldat : GXProcedure
   {
      public osoldat( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public osoldat( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( long aP0_SolicitudesID ,
                           out string aP1_SolicitudesNombre ,
                           out decimal aP2_SolicitudServicioPFinal )
      {
         this.AV10SolicitudesID = aP0_SolicitudesID;
         this.AV8SolicitudesNombre = "" ;
         this.AV9SolicitudServicioPFinal = 0 ;
         initialize();
         ExecutePrivate();
         aP1_SolicitudesNombre=this.AV8SolicitudesNombre;
         aP2_SolicitudServicioPFinal=this.AV9SolicitudServicioPFinal;
      }

      public decimal executeUdp( long aP0_SolicitudesID ,
                                 out string aP1_SolicitudesNombre )
      {
         execute(aP0_SolicitudesID, out aP1_SolicitudesNombre, out aP2_SolicitudServicioPFinal);
         return AV9SolicitudServicioPFinal ;
      }

      public void executeSubmit( long aP0_SolicitudesID ,
                                 out string aP1_SolicitudesNombre ,
                                 out decimal aP2_SolicitudServicioPFinal )
      {
         this.AV10SolicitudesID = aP0_SolicitudesID;
         this.AV8SolicitudesNombre = "" ;
         this.AV9SolicitudServicioPFinal = 0 ;
         SubmitImpl();
         aP1_SolicitudesNombre=this.AV8SolicitudesNombre;
         aP2_SolicitudServicioPFinal=this.AV9SolicitudServicioPFinal;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         /* Using cursor P00992 */
         pr_default.execute(0, new Object[] {AV10SolicitudesID});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A127SolicitudesID = P00992_A127SolicitudesID[0];
            A171SolicitudesNombre = P00992_A171SolicitudesNombre[0];
            A796SolicitudesComisionMetodoPago = P00992_A796SolicitudesComisionMetodoPago[0];
            A212SolicitudesCotizacion = P00992_A212SolicitudesCotizacion[0];
            A1016SolicitudesDescuentoCupon = P00992_A1016SolicitudesDescuentoCupon[0];
            A897SolicitudesDescuento = P00992_A897SolicitudesDescuento[0];
            n897SolicitudesDescuento = P00992_n897SolicitudesDescuento[0];
            A864SolicitudesCostoXZona = P00992_A864SolicitudesCostoXZona[0];
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
            AV8SolicitudesNombre = A171SolicitudesNombre;
            AV9SolicitudServicioPFinal = A211SolicitudServicioPFinal;
            /* Optimized UPDATE. */
            /* Using cursor P00993 */
            pr_default.execute(1, new Object[] {AV8SolicitudesNombre, AV9SolicitudServicioPFinal});
            pr_default.close(1);
            pr_default.SmartCacheProvider.SetUpdated("Plog");
            /* End optimized UPDATE. */
            /* Exit For each command. Update data (if necessary), close cursors & exit. */
            if (true) break;
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(0);
         cleanup();
      }

      protected void GetSolicitudesTotal( long A127SolicitudesID )
      {
         /* Create private dbobjects */
         /* Navigation */
         A174SolicitudesTotal = 0;
         /* Using cursor P00994 */
         pr_default.execute(2, new Object[] {A127SolicitudesID});
         while ( (pr_default.getStatus(2) != 101) && ( P00994_A127SolicitudesID[0] == A127SolicitudesID ) )
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( P00994_A178SolicitudItemsSR[0])) || ( StringUtil.StrCmp(P00994_A179SolicitudItemsComisionTipo[0], "N") == 0 ) )
            {
               A175SolicitudesItemsPrecioInstalac = (decimal)((P00994_A176SolicitudesItemsPrecioFinal[0]*P00994_A177SolicitudesItemsCantidad[0]));
            }
            else
            {
               if ( ( StringUtil.StrCmp(P00994_A179SolicitudItemsComisionTipo[0], "F") == 0 ) && ( StringUtil.StrCmp(P00994_A178SolicitudItemsSR[0], "R") == 0 ) )
               {
                  A175SolicitudesItemsPrecioInstalac = (decimal)((P00994_A176SolicitudesItemsPrecioFinal[0]*P00994_A177SolicitudesItemsCantidad[0])-(P00994_A180SolicitudItemsComision[0]*P00994_A177SolicitudesItemsCantidad[0]));
               }
               else
               {
                  if ( ( StringUtil.StrCmp(P00994_A179SolicitudItemsComisionTipo[0], "F") == 0 ) && ( StringUtil.StrCmp(P00994_A178SolicitudItemsSR[0], "S") == 0 ) )
                  {
                     A175SolicitudesItemsPrecioInstalac = (decimal)((P00994_A176SolicitudesItemsPrecioFinal[0]*P00994_A177SolicitudesItemsCantidad[0])+(P00994_A180SolicitudItemsComision[0]*P00994_A177SolicitudesItemsCantidad[0]));
                  }
                  else
                  {
                     if ( ( StringUtil.StrCmp(P00994_A179SolicitudItemsComisionTipo[0], "P") == 0 ) && ( StringUtil.StrCmp(P00994_A178SolicitudItemsSR[0], "R") == 0 ) )
                     {
                        A175SolicitudesItemsPrecioInstalac = (decimal)((P00994_A176SolicitudesItemsPrecioFinal[0]*P00994_A177SolicitudesItemsCantidad[0])-((P00994_A176SolicitudesItemsPrecioFinal[0]*P00994_A177SolicitudesItemsCantidad[0])*(P00994_A180SolicitudItemsComision[0]/ (decimal)(100))));
                     }
                     else
                     {
                        if ( ( StringUtil.StrCmp(P00994_A179SolicitudItemsComisionTipo[0], "P") == 0 ) && ( StringUtil.StrCmp(P00994_A178SolicitudItemsSR[0], "S") == 0 ) )
                        {
                           A175SolicitudesItemsPrecioInstalac = (decimal)((P00994_A176SolicitudesItemsPrecioFinal[0]*P00994_A177SolicitudesItemsCantidad[0])+((P00994_A176SolicitudesItemsPrecioFinal[0]*P00994_A177SolicitudesItemsCantidad[0])*(P00994_A180SolicitudItemsComision[0]/ (decimal)(100))));
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
         context.CommitDataStores("osoldat",pr_default);
         CloseCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
         ExitApp();
      }

      public override void initialize( )
      {
         AV8SolicitudesNombre = "";
         P00992_A127SolicitudesID = new long[1] ;
         P00992_A171SolicitudesNombre = new string[] {""} ;
         P00992_A796SolicitudesComisionMetodoPago = new decimal[1] ;
         P00992_A212SolicitudesCotizacion = new decimal[1] ;
         P00992_A1016SolicitudesDescuentoCupon = new decimal[1] ;
         P00992_A897SolicitudesDescuento = new decimal[1] ;
         P00992_n897SolicitudesDescuento = new bool[] {false} ;
         P00992_A864SolicitudesCostoXZona = new decimal[1] ;
         A171SolicitudesNombre = "";
         P00994_A127SolicitudesID = new long[1] ;
         P00994_A134SolicitudesItemsID = new short[1] ;
         P00994_A180SolicitudItemsComision = new decimal[1] ;
         P00994_A179SolicitudItemsComisionTipo = new string[] {""} ;
         P00994_A178SolicitudItemsSR = new string[] {""} ;
         P00994_A177SolicitudesItemsCantidad = new short[1] ;
         P00994_A176SolicitudesItemsPrecioFinal = new decimal[1] ;
         P00994_n176SolicitudesItemsPrecioFinal = new bool[] {false} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.osoldat__default(),
            new Object[][] {
                new Object[] {
               P00992_A127SolicitudesID, P00992_A171SolicitudesNombre, P00992_A796SolicitudesComisionMetodoPago, P00992_A212SolicitudesCotizacion, P00992_A1016SolicitudesDescuentoCupon, P00992_A897SolicitudesDescuento, P00992_n897SolicitudesDescuento, P00992_A864SolicitudesCostoXZona
               }
               , new Object[] {
               }
               , new Object[] {
               P00994_A127SolicitudesID, P00994_A134SolicitudesItemsID, P00994_A180SolicitudItemsComision, P00994_A179SolicitudItemsComisionTipo, P00994_A178SolicitudItemsSR, P00994_A177SolicitudesItemsCantidad, P00994_A176SolicitudesItemsPrecioFinal, P00994_n176SolicitudesItemsPrecioFinal
               }
            }
         );
         /* GeneXus formulas. */
      }

      private long AV10SolicitudesID ;
      private long A127SolicitudesID ;
      private decimal AV9SolicitudServicioPFinal ;
      private decimal A796SolicitudesComisionMetodoPago ;
      private decimal A212SolicitudesCotizacion ;
      private decimal A1016SolicitudesDescuentoCupon ;
      private decimal A897SolicitudesDescuento ;
      private decimal A864SolicitudesCostoXZona ;
      private decimal A211SolicitudServicioPFinal ;
      private decimal A174SolicitudesTotal ;
      private decimal A175SolicitudesItemsPrecioInstalac ;
      private string AV8SolicitudesNombre ;
      private string A171SolicitudesNombre ;
      private bool n897SolicitudesDescuento ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private long[] P00992_A127SolicitudesID ;
      private string[] P00992_A171SolicitudesNombre ;
      private decimal[] P00992_A796SolicitudesComisionMetodoPago ;
      private decimal[] P00992_A212SolicitudesCotizacion ;
      private decimal[] P00992_A1016SolicitudesDescuentoCupon ;
      private decimal[] P00992_A897SolicitudesDescuento ;
      private bool[] P00992_n897SolicitudesDescuento ;
      private decimal[] P00992_A864SolicitudesCostoXZona ;
      private long[] P00994_A127SolicitudesID ;
      private short[] P00994_A134SolicitudesItemsID ;
      private decimal[] P00994_A180SolicitudItemsComision ;
      private string[] P00994_A179SolicitudItemsComisionTipo ;
      private string[] P00994_A178SolicitudItemsSR ;
      private short[] P00994_A177SolicitudesItemsCantidad ;
      private decimal[] P00994_A176SolicitudesItemsPrecioFinal ;
      private bool[] P00994_n176SolicitudesItemsPrecioFinal ;
      private string aP1_SolicitudesNombre ;
      private decimal aP2_SolicitudServicioPFinal ;
   }

   public class osoldat__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new UpdateCursor(def[1])
         ,new ForEachCursor(def[2])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP00992;
          prmP00992 = new Object[] {
          new ParDef("@AV10SolicitudesID",GXType.Decimal,18,0)
          };
          Object[] prmP00993;
          prmP00993 = new Object[] {
          new ParDef("@AV8SolicitudesNombre",GXType.Char,100,0) ,
          new ParDef("@AV9SolicitudServicioPFinal",GXType.Decimal,18,2)
          };
          Object[] prmP00994;
          prmP00994 = new Object[] {
          new ParDef("@SolicitudesID",GXType.Decimal,18,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00992", "SELECT TOP 1 [SolicitudesID], [SolicitudesNombre], [SolicitudesComisionMetodoPago], [SolicitudesCotizacion], [SolicitudesDescuentoCupon], [SolicitudesDescuento], [SolicitudesCostoXZona] FROM [Solicitudes] WHERE [SolicitudesID] = @AV10SolicitudesID ORDER BY [SolicitudesID] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00992,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("P00993", "UPDATE [Plog] SET [PlogMsg]=@AV8SolicitudesNombre + ' ' + CONVERT( char(18), CAST(@AV9SolicitudServicioPFinal AS decimal(18,2))) ", GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP00993)
             ,new CursorDef("P00994", "SELECT [SolicitudesID], [SolicitudesItemsID], [SolicitudItemsComision], [SolicitudItemsComisionTipo], [SolicitudItemsSR], [SolicitudesItemsCantidad], [SolicitudesItemsPrecioFinal] FROM [SolicitudesItems] WHERE [SolicitudesID] = @SolicitudesID ORDER BY [SolicitudesID] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00994,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[1])[0] = rslt.getString(2, 100);
                ((decimal[]) buf[2])[0] = rslt.getDecimal(3);
                ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
                ((decimal[]) buf[4])[0] = rslt.getDecimal(5);
                ((decimal[]) buf[5])[0] = rslt.getDecimal(6);
                ((bool[]) buf[6])[0] = rslt.wasNull(6);
                ((decimal[]) buf[7])[0] = rslt.getDecimal(7);
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

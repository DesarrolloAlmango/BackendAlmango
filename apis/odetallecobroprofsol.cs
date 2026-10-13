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
   public class odetallecobroprofsol : GXProcedure
   {
      public odetallecobroprofsol( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public odetallecobroprofsol( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( long aP0_SolicitudesID ,
                           string aP1_ProfesionalesId ,
                           out string aP2_ModoPago ,
                           out string aP3_Deduccion ,
                           out string aP4_Ganancia )
      {
         this.AV19SolicitudesID = aP0_SolicitudesID;
         this.AV18ProfesionalesId = aP1_ProfesionalesId;
         this.AV14ModoPago = "" ;
         this.AV9Deduccion = "" ;
         this.AV10Ganancia = "" ;
         initialize();
         ExecutePrivate();
         aP2_ModoPago=this.AV14ModoPago;
         aP3_Deduccion=this.AV9Deduccion;
         aP4_Ganancia=this.AV10Ganancia;
      }

      public string executeUdp( long aP0_SolicitudesID ,
                                string aP1_ProfesionalesId ,
                                out string aP2_ModoPago ,
                                out string aP3_Deduccion )
      {
         execute(aP0_SolicitudesID, aP1_ProfesionalesId, out aP2_ModoPago, out aP3_Deduccion, out aP4_Ganancia);
         return AV10Ganancia ;
      }

      public void executeSubmit( long aP0_SolicitudesID ,
                                 string aP1_ProfesionalesId ,
                                 out string aP2_ModoPago ,
                                 out string aP3_Deduccion ,
                                 out string aP4_Ganancia )
      {
         this.AV19SolicitudesID = aP0_SolicitudesID;
         this.AV18ProfesionalesId = aP1_ProfesionalesId;
         this.AV14ModoPago = "" ;
         this.AV9Deduccion = "" ;
         this.AV10Ganancia = "" ;
         SubmitImpl();
         aP2_ModoPago=this.AV14ModoPago;
         aP3_Deduccion=this.AV9Deduccion;
         aP4_Ganancia=this.AV10Ganancia;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         /* Using cursor P00JC2 */
         pr_default.execute(0, new Object[] {AV19SolicitudesID});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A127SolicitudesID = P00JC2_A127SolicitudesID[0];
            A438SolicitudServicioOrigenPago = P00JC2_A438SolicitudServicioOrigenPago[0];
            n438SolicitudServicioOrigenPago = P00JC2_n438SolicitudServicioOrigenPago[0];
            A527SolicitudServicioComProv = P00JC2_A527SolicitudServicioComProv[0];
            n527SolicitudServicioComProv = P00JC2_n527SolicitudServicioComProv[0];
            A530SolicitudServicioComALM = P00JC2_A530SolicitudServicioComALM[0];
            n530SolicitudServicioComALM = P00JC2_n530SolicitudServicioComALM[0];
            A865SolicitudesCostoXZComAlm = P00JC2_A865SolicitudesCostoXZComAlm[0];
            n865SolicitudesCostoXZComAlm = P00JC2_n865SolicitudesCostoXZComAlm[0];
            A796SolicitudesComisionMetodoPago = P00JC2_A796SolicitudesComisionMetodoPago[0];
            A212SolicitudesCotizacion = P00JC2_A212SolicitudesCotizacion[0];
            A1016SolicitudesDescuentoCupon = P00JC2_A1016SolicitudesDescuentoCupon[0];
            A897SolicitudesDescuento = P00JC2_A897SolicitudesDescuento[0];
            n897SolicitudesDescuento = P00JC2_n897SolicitudesDescuento[0];
            A864SolicitudesCostoXZona = P00JC2_A864SolicitudesCostoXZona[0];
            if ( ( A865SolicitudesCostoXZComAlm < Convert.ToDecimal( 0 )) )
            {
               A867SolicitudesCostoXZComProf = (decimal)(A864SolicitudesCostoXZona+(A865SolicitudesCostoXZComAlm*-1));
            }
            else
            {
               A867SolicitudesCostoXZComProf = (decimal)(A864SolicitudesCostoXZona-(A865SolicitudesCostoXZComAlm));
            }
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
            if ( StringUtil.StrCmp(A438SolicitudServicioOrigenPago, context.GetMessage( "F", "")) == 0 )
            {
               AV14ModoPago = StringUtil.Trim( context.localUtil.Format( A211SolicitudServicioPFinal, "ZZZZZZ,ZZZ,ZZZ,ZZ9.99"));
               if ( ( A530SolicitudServicioComALM == Convert.ToDecimal( 0 )) )
               {
                  AV23srtPrecioProfesional = AV17PrecioProfesionalProperty.Get(StringUtil.Trim( StringUtil.Str( (decimal)(A127SolicitudesID), 18, 0)));
                  AV15PrecioProfesional = NumberUtil.Val( AV23srtPrecioProfesional, ".");
                  if ( ( AV15PrecioProfesional == Convert.ToDecimal( 0 )) )
                  {
                     new ocomisionsolicitud(context ).execute(  A127SolicitudesID,  AV18ProfesionalesId,  false, out  AV21SolicitudServicioComProv, out  AV22SolicitudServicioComProvP, out  AV20SolicitudServicioComALM, out  AV8SolicitudServicioComALMP, out  AV15PrecioProfesional, out  AV16PrecioProfesionalP) ;
                     AV17PrecioProfesionalProperty.Set(StringUtil.Trim( StringUtil.Str( (decimal)(A127SolicitudesID), 18, 0)), context.localUtil.Format( AV15PrecioProfesional, "ZZZZZZ,ZZZ,ZZZ,ZZ9.99"));
                  }
                  AV13Gestion = (decimal)(A865SolicitudesCostoXZComAlm+AV20SolicitudServicioComALM+AV21SolicitudServicioComProv);
                  AV9Deduccion = StringUtil.Trim( context.localUtil.Format( AV13Gestion, "ZZZZZZ,ZZZ,ZZZ,ZZ9.99"));
                  AV24TotalGanancia = (decimal)(A211SolicitudServicioPFinal-AV13Gestion);
                  AV10Ganancia = StringUtil.Trim( context.localUtil.Format( AV24TotalGanancia, "ZZZZZZ,ZZZ,ZZZ,ZZ9.99"));
               }
               else
               {
                  AV13Gestion = (decimal)(A530SolicitudServicioComALM+A527SolicitudServicioComProv+A865SolicitudesCostoXZComAlm);
                  AV9Deduccion = StringUtil.Trim( context.localUtil.Format( AV13Gestion, "ZZZZZZ,ZZZ,ZZZ,ZZ9.99"));
                  AV24TotalGanancia = (decimal)(A211SolicitudServicioPFinal-AV13Gestion);
                  AV10Ganancia = StringUtil.Trim( context.localUtil.Format( AV24TotalGanancia, "ZZZZZZ,ZZZ,ZZZ,ZZ9.99"));
               }
            }
            else
            {
               if ( ( A530SolicitudServicioComALM == Convert.ToDecimal( 0 )) )
               {
                  AV23srtPrecioProfesional = AV17PrecioProfesionalProperty.Get(StringUtil.Trim( StringUtil.Str( (decimal)(A127SolicitudesID), 18, 0)));
                  AV15PrecioProfesional = NumberUtil.Val( AV23srtPrecioProfesional, ".");
                  if ( ( AV15PrecioProfesional == Convert.ToDecimal( 0 )) )
                  {
                     new ocomisionsolicitud(context ).execute(  A127SolicitudesID,  AV18ProfesionalesId,  false, out  AV21SolicitudServicioComProv, out  AV22SolicitudServicioComProvP, out  AV20SolicitudServicioComALM, out  AV8SolicitudServicioComALMP, out  AV15PrecioProfesional, out  AV16PrecioProfesionalP) ;
                     AV17PrecioProfesionalProperty.Set(StringUtil.Trim( StringUtil.Str( (decimal)(A127SolicitudesID), 18, 0)), context.localUtil.Format( AV15PrecioProfesional, "ZZZZZZ,ZZZ,ZZZ,ZZ9.99"));
                  }
                  AV25PrecioFinalProf = (decimal)(AV15PrecioProfesional+A867SolicitudesCostoXZComProf);
               }
               else
               {
                  AV25PrecioFinalProf = (decimal)(A529SolicitudServicioComPro+A867SolicitudesCostoXZComProf);
               }
               AV14ModoPago = StringUtil.Trim( context.localUtil.Format( AV25PrecioFinalProf, "ZZZZZZZZZZZZZZ9.99"));
               AV9Deduccion = "0.00";
               AV10Ganancia = StringUtil.Trim( context.localUtil.Format( AV25PrecioFinalProf, "ZZZZZZZZZZZZZZ9.99"));
            }
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
         /* Using cursor P00JC3 */
         pr_default.execute(1, new Object[] {A127SolicitudesID});
         while ( (pr_default.getStatus(1) != 101) && ( P00JC3_A127SolicitudesID[0] == A127SolicitudesID ) )
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( P00JC3_A178SolicitudItemsSR[0])) || ( StringUtil.StrCmp(P00JC3_A179SolicitudItemsComisionTipo[0], "N") == 0 ) )
            {
               A175SolicitudesItemsPrecioInstalac = (decimal)((P00JC3_A176SolicitudesItemsPrecioFinal[0]*P00JC3_A177SolicitudesItemsCantidad[0]));
            }
            else
            {
               if ( ( StringUtil.StrCmp(P00JC3_A179SolicitudItemsComisionTipo[0], "F") == 0 ) && ( StringUtil.StrCmp(P00JC3_A178SolicitudItemsSR[0], "R") == 0 ) )
               {
                  A175SolicitudesItemsPrecioInstalac = (decimal)((P00JC3_A176SolicitudesItemsPrecioFinal[0]*P00JC3_A177SolicitudesItemsCantidad[0])-(P00JC3_A180SolicitudItemsComision[0]*P00JC3_A177SolicitudesItemsCantidad[0]));
               }
               else
               {
                  if ( ( StringUtil.StrCmp(P00JC3_A179SolicitudItemsComisionTipo[0], "F") == 0 ) && ( StringUtil.StrCmp(P00JC3_A178SolicitudItemsSR[0], "S") == 0 ) )
                  {
                     A175SolicitudesItemsPrecioInstalac = (decimal)((P00JC3_A176SolicitudesItemsPrecioFinal[0]*P00JC3_A177SolicitudesItemsCantidad[0])+(P00JC3_A180SolicitudItemsComision[0]*P00JC3_A177SolicitudesItemsCantidad[0]));
                  }
                  else
                  {
                     if ( ( StringUtil.StrCmp(P00JC3_A179SolicitudItemsComisionTipo[0], "P") == 0 ) && ( StringUtil.StrCmp(P00JC3_A178SolicitudItemsSR[0], "R") == 0 ) )
                     {
                        A175SolicitudesItemsPrecioInstalac = (decimal)((P00JC3_A176SolicitudesItemsPrecioFinal[0]*P00JC3_A177SolicitudesItemsCantidad[0])-((P00JC3_A176SolicitudesItemsPrecioFinal[0]*P00JC3_A177SolicitudesItemsCantidad[0])*(P00JC3_A180SolicitudItemsComision[0]/ (decimal)(100))));
                     }
                     else
                     {
                        if ( ( StringUtil.StrCmp(P00JC3_A179SolicitudItemsComisionTipo[0], "P") == 0 ) && ( StringUtil.StrCmp(P00JC3_A178SolicitudItemsSR[0], "S") == 0 ) )
                        {
                           A175SolicitudesItemsPrecioInstalac = (decimal)((P00JC3_A176SolicitudesItemsPrecioFinal[0]*P00JC3_A177SolicitudesItemsCantidad[0])+((P00JC3_A176SolicitudesItemsPrecioFinal[0]*P00JC3_A177SolicitudesItemsCantidad[0])*(P00JC3_A180SolicitudItemsComision[0]/ (decimal)(100))));
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
         AV14ModoPago = "";
         AV9Deduccion = "";
         AV10Ganancia = "";
         P00JC2_A127SolicitudesID = new long[1] ;
         P00JC2_A438SolicitudServicioOrigenPago = new string[] {""} ;
         P00JC2_n438SolicitudServicioOrigenPago = new bool[] {false} ;
         P00JC2_A527SolicitudServicioComProv = new decimal[1] ;
         P00JC2_n527SolicitudServicioComProv = new bool[] {false} ;
         P00JC2_A530SolicitudServicioComALM = new decimal[1] ;
         P00JC2_n530SolicitudServicioComALM = new bool[] {false} ;
         P00JC2_A865SolicitudesCostoXZComAlm = new decimal[1] ;
         P00JC2_n865SolicitudesCostoXZComAlm = new bool[] {false} ;
         P00JC2_A796SolicitudesComisionMetodoPago = new decimal[1] ;
         P00JC2_A212SolicitudesCotizacion = new decimal[1] ;
         P00JC2_A1016SolicitudesDescuentoCupon = new decimal[1] ;
         P00JC2_A897SolicitudesDescuento = new decimal[1] ;
         P00JC2_n897SolicitudesDescuento = new bool[] {false} ;
         P00JC2_A864SolicitudesCostoXZona = new decimal[1] ;
         A438SolicitudServicioOrigenPago = "";
         AV23srtPrecioProfesional = "";
         AV17PrecioProfesionalProperty = new GXProperties();
         P00JC3_A127SolicitudesID = new long[1] ;
         P00JC3_A134SolicitudesItemsID = new short[1] ;
         P00JC3_A180SolicitudItemsComision = new decimal[1] ;
         P00JC3_A179SolicitudItemsComisionTipo = new string[] {""} ;
         P00JC3_A178SolicitudItemsSR = new string[] {""} ;
         P00JC3_A177SolicitudesItemsCantidad = new short[1] ;
         P00JC3_A176SolicitudesItemsPrecioFinal = new decimal[1] ;
         P00JC3_n176SolicitudesItemsPrecioFinal = new bool[] {false} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.apis.odetallecobroprofsol__default(),
            new Object[][] {
                new Object[] {
               P00JC2_A127SolicitudesID, P00JC2_A438SolicitudServicioOrigenPago, P00JC2_n438SolicitudServicioOrigenPago, P00JC2_A527SolicitudServicioComProv, P00JC2_n527SolicitudServicioComProv, P00JC2_A530SolicitudServicioComALM, P00JC2_n530SolicitudServicioComALM, P00JC2_A865SolicitudesCostoXZComAlm, P00JC2_n865SolicitudesCostoXZComAlm, P00JC2_A796SolicitudesComisionMetodoPago,
               P00JC2_A212SolicitudesCotizacion, P00JC2_A1016SolicitudesDescuentoCupon, P00JC2_A897SolicitudesDescuento, P00JC2_n897SolicitudesDescuento, P00JC2_A864SolicitudesCostoXZona
               }
               , new Object[] {
               P00JC3_A127SolicitudesID, P00JC3_A134SolicitudesItemsID, P00JC3_A180SolicitudItemsComision, P00JC3_A179SolicitudItemsComisionTipo, P00JC3_A178SolicitudItemsSR, P00JC3_A177SolicitudesItemsCantidad, P00JC3_A176SolicitudesItemsPrecioFinal, P00JC3_n176SolicitudesItemsPrecioFinal
               }
            }
         );
         /* GeneXus formulas. */
      }

      private long AV19SolicitudesID ;
      private long A127SolicitudesID ;
      private decimal A527SolicitudServicioComProv ;
      private decimal A530SolicitudServicioComALM ;
      private decimal A865SolicitudesCostoXZComAlm ;
      private decimal A796SolicitudesComisionMetodoPago ;
      private decimal A212SolicitudesCotizacion ;
      private decimal A1016SolicitudesDescuentoCupon ;
      private decimal A897SolicitudesDescuento ;
      private decimal A864SolicitudesCostoXZona ;
      private decimal A867SolicitudesCostoXZComProf ;
      private decimal A211SolicitudServicioPFinal ;
      private decimal A174SolicitudesTotal ;
      private decimal A529SolicitudServicioComPro ;
      private decimal AV15PrecioProfesional ;
      private decimal AV21SolicitudServicioComProv ;
      private decimal AV22SolicitudServicioComProvP ;
      private decimal AV20SolicitudServicioComALM ;
      private decimal AV8SolicitudServicioComALMP ;
      private decimal AV16PrecioProfesionalP ;
      private decimal AV13Gestion ;
      private decimal AV24TotalGanancia ;
      private decimal AV25PrecioFinalProf ;
      private decimal A175SolicitudesItemsPrecioInstalac ;
      private string AV18ProfesionalesId ;
      private string AV14ModoPago ;
      private string AV9Deduccion ;
      private string AV10Ganancia ;
      private string A438SolicitudServicioOrigenPago ;
      private string AV23srtPrecioProfesional ;
      private bool n438SolicitudServicioOrigenPago ;
      private bool n527SolicitudServicioComProv ;
      private bool n530SolicitudServicioComALM ;
      private bool n865SolicitudesCostoXZComAlm ;
      private bool n897SolicitudesDescuento ;
      private GXProperties AV17PrecioProfesionalProperty ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private long[] P00JC2_A127SolicitudesID ;
      private string[] P00JC2_A438SolicitudServicioOrigenPago ;
      private bool[] P00JC2_n438SolicitudServicioOrigenPago ;
      private decimal[] P00JC2_A527SolicitudServicioComProv ;
      private bool[] P00JC2_n527SolicitudServicioComProv ;
      private decimal[] P00JC2_A530SolicitudServicioComALM ;
      private bool[] P00JC2_n530SolicitudServicioComALM ;
      private decimal[] P00JC2_A865SolicitudesCostoXZComAlm ;
      private bool[] P00JC2_n865SolicitudesCostoXZComAlm ;
      private decimal[] P00JC2_A796SolicitudesComisionMetodoPago ;
      private decimal[] P00JC2_A212SolicitudesCotizacion ;
      private decimal[] P00JC2_A1016SolicitudesDescuentoCupon ;
      private decimal[] P00JC2_A897SolicitudesDescuento ;
      private bool[] P00JC2_n897SolicitudesDescuento ;
      private decimal[] P00JC2_A864SolicitudesCostoXZona ;
      private long[] P00JC3_A127SolicitudesID ;
      private short[] P00JC3_A134SolicitudesItemsID ;
      private decimal[] P00JC3_A180SolicitudItemsComision ;
      private string[] P00JC3_A179SolicitudItemsComisionTipo ;
      private string[] P00JC3_A178SolicitudItemsSR ;
      private short[] P00JC3_A177SolicitudesItemsCantidad ;
      private decimal[] P00JC3_A176SolicitudesItemsPrecioFinal ;
      private bool[] P00JC3_n176SolicitudesItemsPrecioFinal ;
      private string aP2_ModoPago ;
      private string aP3_Deduccion ;
      private string aP4_Ganancia ;
   }

   public class odetallecobroprofsol__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP00JC2;
          prmP00JC2 = new Object[] {
          new ParDef("@AV19SolicitudesID",GXType.Decimal,18,0)
          };
          Object[] prmP00JC3;
          prmP00JC3 = new Object[] {
          new ParDef("@SolicitudesID",GXType.Decimal,18,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00JC2", "SELECT [SolicitudesID], [SolicitudServicioOrigenPago], [SolicitudServicioComProv], [SolicitudServicioComALM], [SolicitudesCostoXZComAlm], [SolicitudesComisionMetodoPago], [SolicitudesCotizacion], [SolicitudesDescuentoCupon], [SolicitudesDescuento], [SolicitudesCostoXZona] FROM [Solicitudes] WHERE [SolicitudesID] = @AV19SolicitudesID ORDER BY [SolicitudesID] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00JC2,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("P00JC3", "SELECT [SolicitudesID], [SolicitudesItemsID], [SolicitudItemsComision], [SolicitudItemsComisionTipo], [SolicitudItemsSR], [SolicitudesItemsCantidad], [SolicitudesItemsPrecioFinal] FROM [SolicitudesItems] WHERE [SolicitudesID] = @SolicitudesID ORDER BY [SolicitudesID] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00JC3,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[1])[0] = rslt.getString(2, 1);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((decimal[]) buf[3])[0] = rslt.getDecimal(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((decimal[]) buf[5])[0] = rslt.getDecimal(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((decimal[]) buf[7])[0] = rslt.getDecimal(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((decimal[]) buf[9])[0] = rslt.getDecimal(6);
                ((decimal[]) buf[10])[0] = rslt.getDecimal(7);
                ((decimal[]) buf[11])[0] = rslt.getDecimal(8);
                ((decimal[]) buf[12])[0] = rslt.getDecimal(9);
                ((bool[]) buf[13])[0] = rslt.wasNull(9);
                ((decimal[]) buf[14])[0] = rslt.getDecimal(10);
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

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
namespace GeneXus.Programs.comercios {
   public class ocantsolicitudes : GXProcedure
   {
      public ocantsolicitudes( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public ocantsolicitudes( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( long aP0_ProveedorID ,
                           out SdtSDTCantSol aP1_SDTCantSol )
      {
         this.AV9ProveedorID = aP0_ProveedorID;
         this.AV10SDTCantSol = new SdtSDTCantSol(context) ;
         initialize();
         ExecutePrivate();
         aP1_SDTCantSol=this.AV10SDTCantSol;
      }

      public SdtSDTCantSol executeUdp( long aP0_ProveedorID )
      {
         execute(aP0_ProveedorID, out aP1_SDTCantSol);
         return AV10SDTCantSol ;
      }

      public void executeSubmit( long aP0_ProveedorID ,
                                 out SdtSDTCantSol aP1_SDTCantSol )
      {
         this.AV9ProveedorID = aP0_ProveedorID;
         this.AV10SDTCantSol = new SdtSDTCantSol(context) ;
         SubmitImpl();
         aP1_SDTCantSol=this.AV10SDTCantSol;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         /* Using cursor P00BS3 */
         pr_default.execute(0, new Object[] {AV9ProveedorID});
         if ( (pr_default.getStatus(0) != 101) )
         {
            A40000GXC1 = P00BS3_A40000GXC1[0];
            n40000GXC1 = P00BS3_n40000GXC1[0];
         }
         else
         {
            A40000GXC1 = 0;
            n40000GXC1 = false;
         }
         pr_default.close(0);
         /* Using cursor P00BS5 */
         pr_default.execute(1, new Object[] {AV9ProveedorID});
         if ( (pr_default.getStatus(1) != 101) )
         {
            A40001GXC2 = P00BS5_A40001GXC2[0];
            n40001GXC2 = P00BS5_n40001GXC2[0];
         }
         else
         {
            A40001GXC2 = 0;
            n40001GXC2 = false;
         }
         pr_default.close(1);
         /* Using cursor P00BS7 */
         pr_default.execute(2, new Object[] {AV9ProveedorID});
         if ( (pr_default.getStatus(2) != 101) )
         {
            A40002GXC3 = P00BS7_A40002GXC3[0];
            n40002GXC3 = P00BS7_n40002GXC3[0];
         }
         else
         {
            A40002GXC3 = 0;
            n40002GXC3 = false;
         }
         pr_default.close(2);
         /* Using cursor P00BS9 */
         pr_default.execute(3, new Object[] {AV9ProveedorID});
         if ( (pr_default.getStatus(3) != 101) )
         {
            A40003GXC4 = P00BS9_A40003GXC4[0];
            n40003GXC4 = P00BS9_n40003GXC4[0];
         }
         else
         {
            A40003GXC4 = 0;
            n40003GXC4 = false;
         }
         pr_default.close(3);
         /* Using cursor P00BS11 */
         pr_default.execute(4, new Object[] {AV9ProveedorID});
         if ( (pr_default.getStatus(4) != 101) )
         {
            A40004GXC5 = P00BS11_A40004GXC5[0];
            n40004GXC5 = P00BS11_n40004GXC5[0];
         }
         else
         {
            A40004GXC5 = 0;
            n40004GXC5 = false;
         }
         pr_default.close(4);
         /* Using cursor P00BS13 */
         pr_default.execute(5, new Object[] {AV9ProveedorID});
         if ( (pr_default.getStatus(5) != 101) )
         {
            A40005GXC6 = P00BS13_A40005GXC6[0];
            n40005GXC6 = P00BS13_n40005GXC6[0];
         }
         else
         {
            A40005GXC6 = 0;
            n40005GXC6 = false;
         }
         pr_default.close(5);
         /* Using cursor P00BS15 */
         pr_default.execute(6, new Object[] {AV9ProveedorID});
         if ( (pr_default.getStatus(6) != 101) )
         {
            A40006GXC7 = P00BS15_A40006GXC7[0];
            n40006GXC7 = P00BS15_n40006GXC7[0];
         }
         else
         {
            A40006GXC7 = 0;
            n40006GXC7 = false;
         }
         pr_default.close(6);
         /* Using cursor P00BS17 */
         pr_default.execute(7, new Object[] {AV9ProveedorID});
         if ( (pr_default.getStatus(7) != 101) )
         {
            A40007GXC8 = P00BS17_A40007GXC8[0];
            n40007GXC8 = P00BS17_n40007GXC8[0];
         }
         else
         {
            A40007GXC8 = 0;
            n40007GXC8 = false;
         }
         pr_default.close(7);
         /* Using cursor P00BS19 */
         pr_default.execute(8, new Object[] {AV9ProveedorID});
         if ( (pr_default.getStatus(8) != 101) )
         {
            A40008GXC9 = P00BS19_A40008GXC9[0];
            n40008GXC9 = P00BS19_n40008GXC9[0];
         }
         else
         {
            A40008GXC9 = 0;
            n40008GXC9 = false;
         }
         pr_default.close(8);
         /* Using cursor P00BS21 */
         pr_default.execute(9, new Object[] {AV9ProveedorID});
         if ( (pr_default.getStatus(9) != 101) )
         {
            A40009GXC10 = P00BS21_A40009GXC10[0];
            n40009GXC10 = P00BS21_n40009GXC10[0];
         }
         else
         {
            A40009GXC10 = 0;
            n40009GXC10 = false;
         }
         pr_default.close(9);
         /* Using cursor P00BS23 */
         pr_default.execute(10, new Object[] {AV9ProveedorID});
         if ( (pr_default.getStatus(10) != 101) )
         {
            A40010GXC11 = P00BS23_A40010GXC11[0];
            n40010GXC11 = P00BS23_n40010GXC11[0];
         }
         else
         {
            A40010GXC11 = 0;
            n40010GXC11 = false;
         }
         pr_default.close(10);
         /* Using cursor P00BS25 */
         pr_default.execute(11, new Object[] {AV9ProveedorID});
         if ( (pr_default.getStatus(11) != 101) )
         {
            A40011GXC12 = P00BS25_A40011GXC12[0];
            n40011GXC12 = P00BS25_n40011GXC12[0];
         }
         else
         {
            A40011GXC12 = 0;
            n40011GXC12 = false;
         }
         pr_default.close(11);
         /* Using cursor P00BS27 */
         pr_default.execute(12, new Object[] {AV9ProveedorID});
         if ( (pr_default.getStatus(12) != 101) )
         {
            A40012GXC13 = P00BS27_A40012GXC13[0];
            n40012GXC13 = P00BS27_n40012GXC13[0];
         }
         else
         {
            A40012GXC13 = 0;
            n40012GXC13 = false;
         }
         pr_default.close(12);
         /* Using cursor P00BS29 */
         pr_default.execute(13, new Object[] {AV9ProveedorID});
         if ( (pr_default.getStatus(13) != 101) )
         {
            A40013GXC14 = P00BS29_A40013GXC14[0];
            n40013GXC14 = P00BS29_n40013GXC14[0];
         }
         else
         {
            A40013GXC14 = 0;
            n40013GXC14 = false;
         }
         pr_default.close(13);
         /* Using cursor P00BS31 */
         pr_default.execute(14, new Object[] {AV9ProveedorID});
         if ( (pr_default.getStatus(14) != 101) )
         {
            A40014GXC15 = P00BS31_A40014GXC15[0];
            n40014GXC15 = P00BS31_n40014GXC15[0];
         }
         else
         {
            A40014GXC15 = 0;
            n40014GXC15 = false;
         }
         pr_default.close(14);
         /* Using cursor P00BS33 */
         pr_default.execute(15, new Object[] {AV9ProveedorID});
         if ( (pr_default.getStatus(15) != 101) )
         {
            A40015GXC16 = P00BS33_A40015GXC16[0];
            n40015GXC16 = P00BS33_n40015GXC16[0];
         }
         else
         {
            A40015GXC16 = 0;
            n40015GXC16 = false;
         }
         pr_default.close(15);
         /* Using cursor P00BS35 */
         pr_default.execute(16, new Object[] {AV9ProveedorID});
         if ( (pr_default.getStatus(16) != 101) )
         {
            A40016GXC17 = P00BS35_A40016GXC17[0];
            n40016GXC17 = P00BS35_n40016GXC17[0];
         }
         else
         {
            A40016GXC17 = 0;
            n40016GXC17 = false;
         }
         pr_default.close(16);
         /* Using cursor P00BS37 */
         pr_default.execute(17, new Object[] {AV9ProveedorID});
         if ( (pr_default.getStatus(17) != 101) )
         {
            A40017GXC18 = P00BS37_A40017GXC18[0];
            n40017GXC18 = P00BS37_n40017GXC18[0];
         }
         else
         {
            A40017GXC18 = 0;
            n40017GXC18 = false;
         }
         pr_default.close(17);
         /* Using cursor P00BS39 */
         pr_default.execute(18);
         if ( (pr_default.getStatus(18) != 101) )
         {
            A40018GXC19 = P00BS39_A40018GXC19[0];
            n40018GXC19 = P00BS39_n40018GXC19[0];
         }
         else
         {
            A40018GXC19 = 0;
            n40018GXC19 = false;
         }
         pr_default.close(18);
         /* Using cursor P00BS41 */
         pr_default.execute(19);
         if ( (pr_default.getStatus(19) != 101) )
         {
            A40019GXC20 = P00BS41_A40019GXC20[0];
            n40019GXC20 = P00BS41_n40019GXC20[0];
         }
         else
         {
            A40019GXC20 = 0;
            n40019GXC20 = false;
         }
         pr_default.close(19);
         /* Using cursor P00BS43 */
         pr_default.execute(20);
         if ( (pr_default.getStatus(20) != 101) )
         {
            A40020GXC21 = P00BS43_A40020GXC21[0];
            n40020GXC21 = P00BS43_n40020GXC21[0];
         }
         else
         {
            A40020GXC21 = 0;
            n40020GXC21 = false;
         }
         pr_default.close(20);
         /* Using cursor P00BS45 */
         pr_default.execute(21);
         if ( (pr_default.getStatus(21) != 101) )
         {
            A40021GXC22 = P00BS45_A40021GXC22[0];
            n40021GXC22 = P00BS45_n40021GXC22[0];
         }
         else
         {
            A40021GXC22 = 0;
            n40021GXC22 = false;
         }
         pr_default.close(21);
         /* Using cursor P00BS47 */
         pr_default.execute(22);
         if ( (pr_default.getStatus(22) != 101) )
         {
            A40022GXC23 = P00BS47_A40022GXC23[0];
            n40022GXC23 = P00BS47_n40022GXC23[0];
         }
         else
         {
            A40022GXC23 = 0;
            n40022GXC23 = false;
         }
         pr_default.close(22);
         /* Using cursor P00BS49 */
         pr_default.execute(23);
         if ( (pr_default.getStatus(23) != 101) )
         {
            A40023GXC24 = P00BS49_A40023GXC24[0];
            n40023GXC24 = P00BS49_n40023GXC24[0];
         }
         else
         {
            A40023GXC24 = 0;
            n40023GXC24 = false;
         }
         pr_default.close(23);
         /* Using cursor P00BS51 */
         pr_default.execute(24);
         if ( (pr_default.getStatus(24) != 101) )
         {
            A40024GXC25 = P00BS51_A40024GXC25[0];
            n40024GXC25 = P00BS51_n40024GXC25[0];
         }
         else
         {
            A40024GXC25 = 0;
            n40024GXC25 = false;
         }
         pr_default.close(24);
         /* Using cursor P00BS53 */
         pr_default.execute(25);
         if ( (pr_default.getStatus(25) != 101) )
         {
            A40025GXC26 = P00BS53_A40025GXC26[0];
            n40025GXC26 = P00BS53_n40025GXC26[0];
         }
         else
         {
            A40025GXC26 = 0;
            n40025GXC26 = false;
         }
         pr_default.close(25);
         /* Using cursor P00BS55 */
         pr_default.execute(26);
         if ( (pr_default.getStatus(26) != 101) )
         {
            A40026GXC27 = P00BS55_A40026GXC27[0];
            n40026GXC27 = P00BS55_n40026GXC27[0];
         }
         else
         {
            A40026GXC27 = 0;
            n40026GXC27 = false;
         }
         pr_default.close(26);
         /* Using cursor P00BS57 */
         pr_default.execute(27);
         if ( (pr_default.getStatus(27) != 101) )
         {
            A40027GXC28 = P00BS57_A40027GXC28[0];
            n40027GXC28 = P00BS57_n40027GXC28[0];
         }
         else
         {
            A40027GXC28 = 0;
            n40027GXC28 = false;
         }
         pr_default.close(27);
         /* Using cursor P00BS59 */
         pr_default.execute(28);
         if ( (pr_default.getStatus(28) != 101) )
         {
            A40028GXC29 = P00BS59_A40028GXC29[0];
            n40028GXC29 = P00BS59_n40028GXC29[0];
         }
         else
         {
            A40028GXC29 = 0;
            n40028GXC29 = false;
         }
         pr_default.close(28);
         /* Using cursor P00BS61 */
         pr_default.execute(29);
         if ( (pr_default.getStatus(29) != 101) )
         {
            A40029GXC30 = P00BS61_A40029GXC30[0];
            n40029GXC30 = P00BS61_n40029GXC30[0];
         }
         else
         {
            A40029GXC30 = 0;
            n40029GXC30 = false;
         }
         pr_default.close(29);
         /* Using cursor P00BS63 */
         pr_default.execute(30);
         if ( (pr_default.getStatus(30) != 101) )
         {
            A40030GXC31 = P00BS63_A40030GXC31[0];
            n40030GXC31 = P00BS63_n40030GXC31[0];
         }
         else
         {
            A40030GXC31 = 0;
            n40030GXC31 = false;
         }
         pr_default.close(30);
         /* Using cursor P00BS65 */
         pr_default.execute(31);
         if ( (pr_default.getStatus(31) != 101) )
         {
            A40031GXC32 = P00BS65_A40031GXC32[0];
            n40031GXC32 = P00BS65_n40031GXC32[0];
         }
         else
         {
            A40031GXC32 = 0;
            n40031GXC32 = false;
         }
         pr_default.close(31);
         /* Using cursor P00BS67 */
         pr_default.execute(32);
         if ( (pr_default.getStatus(32) != 101) )
         {
            A40032GXC33 = P00BS67_A40032GXC33[0];
            n40032GXC33 = P00BS67_n40032GXC33[0];
         }
         else
         {
            A40032GXC33 = 0;
            n40032GXC33 = false;
         }
         pr_default.close(32);
         /* Using cursor P00BS69 */
         pr_default.execute(33);
         if ( (pr_default.getStatus(33) != 101) )
         {
            A40033GXC34 = P00BS69_A40033GXC34[0];
            n40033GXC34 = P00BS69_n40033GXC34[0];
         }
         else
         {
            A40033GXC34 = 0;
            n40033GXC34 = false;
         }
         pr_default.close(33);
         /* Using cursor P00BS71 */
         pr_default.execute(34);
         if ( (pr_default.getStatus(34) != 101) )
         {
            A40034GXC35 = P00BS71_A40034GXC35[0];
            n40034GXC35 = P00BS71_n40034GXC35[0];
         }
         else
         {
            A40034GXC35 = 0;
            n40034GXC35 = false;
         }
         pr_default.close(34);
         /* Using cursor P00BS73 */
         pr_default.execute(35);
         if ( (pr_default.getStatus(35) != 101) )
         {
            A40035GXC36 = P00BS73_A40035GXC36[0];
            n40035GXC36 = P00BS73_n40035GXC36[0];
         }
         else
         {
            A40035GXC36 = 0;
            n40035GXC36 = false;
         }
         pr_default.close(35);
         AV12Json = AV11Webssesion.Get(context.GetMessage( "SDTCantSol", ""));
         AV10SDTCantSol.FromJSonString(AV12Json, null);
         AV13Day = DateTimeUtil.Today( context);
         AV18Mes = (short)(DateTimeUtil.Month( AV13Day));
         AV17anio = (short)(DateTimeUtil.Year( AV13Day));
         if ( AV18Mes < 10 )
         {
            AV16InicioMes = context.localUtil.CToD( StringUtil.Format( "01/0%1/%2", StringUtil.LTrimStr( (decimal)(AV18Mes), 4, 0), StringUtil.LTrimStr( (decimal)(AV17anio), 4, 0), "", "", "", "", "", "", ""), DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
         }
         else
         {
            AV16InicioMes = context.localUtil.CToD( StringUtil.Format( "01/%1/%2", StringUtil.LTrimStr( (decimal)(AV18Mes), 4, 0), StringUtil.LTrimStr( (decimal)(AV17anio), 4, 0), "", "", "", "", "", "", ""), DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
         }
         AV19MesActual = AV16InicioMes;
         if ( ( AV18Mes - 1 ) == 0 )
         {
            AV18Mes = 12;
            AV17anio = (short)(AV17anio-1);
         }
         else
         {
            AV18Mes = (short)(AV18Mes-1);
         }
         if ( AV18Mes < 10 )
         {
            AV16InicioMes = context.localUtil.CToD( StringUtil.Format( "01/0%1/%2", StringUtil.LTrimStr( (decimal)(AV18Mes), 4, 0), StringUtil.LTrimStr( (decimal)(AV17anio), 4, 0), "", "", "", "", "", "", ""), DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
         }
         else
         {
            AV16InicioMes = context.localUtil.CToD( StringUtil.Format( "01/%1/%2", StringUtil.LTrimStr( (decimal)(AV18Mes), 4, 0), StringUtil.LTrimStr( (decimal)(AV17anio), 4, 0), "", "", "", "", "", "", ""), DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
         }
         AV15MesAnterio = AV16InicioMes;
         if ( AV9ProveedorID > 0 )
         {
            AV10SDTCantSol.gxTpr_Procesadas = A40000GXC1;
            AV10SDTCantSol.gxTpr_Delegadas = A40001GXC2;
            AV10SDTCantSol.gxTpr_Canceladas = A40002GXC3;
            AV10SDTCantSol.gxTpr_Rechazadas = A40003GXC4;
            AV10SDTCantSol.gxTpr_Aceptadas = A40004GXC5;
            AV10SDTCantSol.gxTpr_Finalizadas = A40005GXC6;
            AV10SDTCantSol.gxTpr_Calificadas = A40006GXC7;
            AV10SDTCantSol.gxTpr_Habilitadas = A40007GXC8;
            AV10SDTCantSol.gxTpr_Totalgenerado = A40008GXC9;
            AV10SDTCantSol.gxTpr_Procesadas = (long)(AV10SDTCantSol.gxTpr_Procesadas+(A40009GXC10));
            AV10SDTCantSol.gxTpr_Delegadas = (long)(AV10SDTCantSol.gxTpr_Delegadas+(A40010GXC11));
            AV10SDTCantSol.gxTpr_Canceladas = (long)(AV10SDTCantSol.gxTpr_Canceladas+(A40011GXC12));
            AV10SDTCantSol.gxTpr_Rechazadas = (long)(AV10SDTCantSol.gxTpr_Rechazadas+(A40012GXC13));
            AV10SDTCantSol.gxTpr_Aceptadas = (long)(AV10SDTCantSol.gxTpr_Aceptadas+(A40013GXC14));
            AV10SDTCantSol.gxTpr_Finalizadas = (long)(AV10SDTCantSol.gxTpr_Finalizadas+(A40014GXC15));
            AV10SDTCantSol.gxTpr_Calificadas = (long)(AV10SDTCantSol.gxTpr_Calificadas+(A40015GXC16));
            AV10SDTCantSol.gxTpr_Habilitadas = (long)(AV10SDTCantSol.gxTpr_Habilitadas+(A40016GXC17));
            AV10SDTCantSol.gxTpr_Totalgenerado = (decimal)(AV10SDTCantSol.gxTpr_Totalgenerado+(A40017GXC18));
         }
         else
         {
            AV10SDTCantSol.gxTpr_Procesadas = A40018GXC19;
            AV10SDTCantSol.gxTpr_Delegadas = A40019GXC20;
            AV10SDTCantSol.gxTpr_Canceladas = A40020GXC21;
            AV10SDTCantSol.gxTpr_Rechazadas = A40021GXC22;
            AV10SDTCantSol.gxTpr_Aceptadas = A40022GXC23;
            AV10SDTCantSol.gxTpr_Finalizadas = A40023GXC24;
            AV10SDTCantSol.gxTpr_Calificadas = A40024GXC25;
            AV10SDTCantSol.gxTpr_Habilitadas = A40025GXC26;
            AV10SDTCantSol.gxTpr_Totalgenerado = A40026GXC27;
            AV10SDTCantSol.gxTpr_Procesadas = (long)(AV10SDTCantSol.gxTpr_Procesadas+(A40027GXC28));
            AV10SDTCantSol.gxTpr_Delegadas = (long)(AV10SDTCantSol.gxTpr_Delegadas+(A40028GXC29));
            AV10SDTCantSol.gxTpr_Canceladas = (long)(AV10SDTCantSol.gxTpr_Canceladas+(A40029GXC30));
            AV10SDTCantSol.gxTpr_Rechazadas = (long)(AV10SDTCantSol.gxTpr_Rechazadas+(A40030GXC31));
            AV10SDTCantSol.gxTpr_Aceptadas = (long)(AV10SDTCantSol.gxTpr_Aceptadas+(A40031GXC32));
            AV10SDTCantSol.gxTpr_Finalizadas = (long)(AV10SDTCantSol.gxTpr_Finalizadas+(A40032GXC33));
            AV10SDTCantSol.gxTpr_Calificadas = (long)(AV10SDTCantSol.gxTpr_Calificadas+(A40033GXC34));
            AV10SDTCantSol.gxTpr_Habilitadas = (long)(AV10SDTCantSol.gxTpr_Habilitadas+(A40034GXC35));
            AV10SDTCantSol.gxTpr_Totalgenerado = (decimal)(AV10SDTCantSol.gxTpr_Totalgenerado+(A40035GXC36));
         }
         AV10SDTCantSol.gxTpr_Total = (long)(AV10SDTCantSol.gxTpr_Procesadas+AV10SDTCantSol.gxTpr_Delegadas+AV10SDTCantSol.gxTpr_Canceladas+AV10SDTCantSol.gxTpr_Rechazadas+AV10SDTCantSol.gxTpr_Aceptadas+AV10SDTCantSol.gxTpr_Finalizadas+AV10SDTCantSol.gxTpr_Calificadas+AV10SDTCantSol.gxTpr_Habilitadas);
         GXt_dtime1 = DateTimeUtil.ResetTime( DateTimeUtil.Today( context) ) ;
         AV10SDTCantSol.gxTpr_Fechaactualizacion = GXt_dtime1;
         /* Using cursor P00BS74 */
         pr_default.execute(36, new Object[] {AV9ProveedorID, AV15MesAnterio, AV19MesActual});
         while ( (pr_default.getStatus(36) != 101) )
         {
            A184SolicitudesFechaInstalacion = P00BS74_A184SolicitudesFechaInstalacion[0];
            A131EstadosSolId = P00BS74_A131EstadosSolId[0];
            A133ProveedorID = P00BS74_A133ProveedorID[0];
            A527SolicitudServicioComProv = P00BS74_A527SolicitudServicioComProv[0];
            n527SolicitudServicioComProv = P00BS74_n527SolicitudServicioComProv[0];
            A127SolicitudesID = P00BS74_A127SolicitudesID[0];
            if ( ( DateTimeUtil.ResetTime ( A184SolicitudesFechaInstalacion ) >= DateTimeUtil.ResetTime ( AV19MesActual ) ) && ( DateTimeUtil.ResetTime ( A184SolicitudesFechaInstalacion ) <= DateTimeUtil.ResetTime ( DateTimeUtil.DateEndOfMonth( AV19MesActual) ) ) )
            {
               AV10SDTCantSol.gxTpr_Mesactual = (decimal)(AV10SDTCantSol.gxTpr_Mesactual+A527SolicitudServicioComProv);
            }
            if ( ( DateTimeUtil.ResetTime ( A184SolicitudesFechaInstalacion ) >= DateTimeUtil.ResetTime ( AV15MesAnterio ) ) && ( DateTimeUtil.ResetTime ( A184SolicitudesFechaInstalacion ) <= DateTimeUtil.ResetTime ( DateTimeUtil.DateEndOfMonth( AV15MesAnterio) ) ) )
            {
               AV10SDTCantSol.gxTpr_Mesanterior = (decimal)(AV10SDTCantSol.gxTpr_Mesanterior+A527SolicitudServicioComProv);
            }
            pr_default.readNext(36);
         }
         pr_default.close(36);
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

      protected override void CloseCursors( )
      {
      }

      public override void initialize( )
      {
         AV10SDTCantSol = new SdtSDTCantSol(context);
         P00BS3_A40000GXC1 = new int[1] ;
         P00BS3_n40000GXC1 = new bool[] {false} ;
         P00BS5_A40001GXC2 = new int[1] ;
         P00BS5_n40001GXC2 = new bool[] {false} ;
         P00BS7_A40002GXC3 = new int[1] ;
         P00BS7_n40002GXC3 = new bool[] {false} ;
         P00BS9_A40003GXC4 = new int[1] ;
         P00BS9_n40003GXC4 = new bool[] {false} ;
         P00BS11_A40004GXC5 = new int[1] ;
         P00BS11_n40004GXC5 = new bool[] {false} ;
         P00BS13_A40005GXC6 = new int[1] ;
         P00BS13_n40005GXC6 = new bool[] {false} ;
         P00BS15_A40006GXC7 = new int[1] ;
         P00BS15_n40006GXC7 = new bool[] {false} ;
         P00BS17_A40007GXC8 = new int[1] ;
         P00BS17_n40007GXC8 = new bool[] {false} ;
         P00BS19_A40008GXC9 = new decimal[1] ;
         P00BS19_n40008GXC9 = new bool[] {false} ;
         P00BS21_A40009GXC10 = new int[1] ;
         P00BS21_n40009GXC10 = new bool[] {false} ;
         P00BS23_A40010GXC11 = new int[1] ;
         P00BS23_n40010GXC11 = new bool[] {false} ;
         P00BS25_A40011GXC12 = new int[1] ;
         P00BS25_n40011GXC12 = new bool[] {false} ;
         P00BS27_A40012GXC13 = new int[1] ;
         P00BS27_n40012GXC13 = new bool[] {false} ;
         P00BS29_A40013GXC14 = new int[1] ;
         P00BS29_n40013GXC14 = new bool[] {false} ;
         P00BS31_A40014GXC15 = new int[1] ;
         P00BS31_n40014GXC15 = new bool[] {false} ;
         P00BS33_A40015GXC16 = new int[1] ;
         P00BS33_n40015GXC16 = new bool[] {false} ;
         P00BS35_A40016GXC17 = new int[1] ;
         P00BS35_n40016GXC17 = new bool[] {false} ;
         P00BS37_A40017GXC18 = new decimal[1] ;
         P00BS37_n40017GXC18 = new bool[] {false} ;
         P00BS39_A40018GXC19 = new int[1] ;
         P00BS39_n40018GXC19 = new bool[] {false} ;
         P00BS41_A40019GXC20 = new int[1] ;
         P00BS41_n40019GXC20 = new bool[] {false} ;
         P00BS43_A40020GXC21 = new int[1] ;
         P00BS43_n40020GXC21 = new bool[] {false} ;
         P00BS45_A40021GXC22 = new int[1] ;
         P00BS45_n40021GXC22 = new bool[] {false} ;
         P00BS47_A40022GXC23 = new int[1] ;
         P00BS47_n40022GXC23 = new bool[] {false} ;
         P00BS49_A40023GXC24 = new int[1] ;
         P00BS49_n40023GXC24 = new bool[] {false} ;
         P00BS51_A40024GXC25 = new int[1] ;
         P00BS51_n40024GXC25 = new bool[] {false} ;
         P00BS53_A40025GXC26 = new int[1] ;
         P00BS53_n40025GXC26 = new bool[] {false} ;
         P00BS55_A40026GXC27 = new decimal[1] ;
         P00BS55_n40026GXC27 = new bool[] {false} ;
         P00BS57_A40027GXC28 = new int[1] ;
         P00BS57_n40027GXC28 = new bool[] {false} ;
         P00BS59_A40028GXC29 = new int[1] ;
         P00BS59_n40028GXC29 = new bool[] {false} ;
         P00BS61_A40029GXC30 = new int[1] ;
         P00BS61_n40029GXC30 = new bool[] {false} ;
         P00BS63_A40030GXC31 = new int[1] ;
         P00BS63_n40030GXC31 = new bool[] {false} ;
         P00BS65_A40031GXC32 = new int[1] ;
         P00BS65_n40031GXC32 = new bool[] {false} ;
         P00BS67_A40032GXC33 = new int[1] ;
         P00BS67_n40032GXC33 = new bool[] {false} ;
         P00BS69_A40033GXC34 = new int[1] ;
         P00BS69_n40033GXC34 = new bool[] {false} ;
         P00BS71_A40034GXC35 = new int[1] ;
         P00BS71_n40034GXC35 = new bool[] {false} ;
         P00BS73_A40035GXC36 = new decimal[1] ;
         P00BS73_n40035GXC36 = new bool[] {false} ;
         AV12Json = "";
         AV11Webssesion = context.GetSession();
         AV13Day = DateTime.MinValue;
         AV16InicioMes = DateTime.MinValue;
         AV19MesActual = DateTime.MinValue;
         AV15MesAnterio = DateTime.MinValue;
         GXt_dtime1 = (DateTime)(DateTime.MinValue);
         P00BS74_A184SolicitudesFechaInstalacion = new DateTime[] {DateTime.MinValue} ;
         P00BS74_A131EstadosSolId = new int[1] ;
         P00BS74_A133ProveedorID = new long[1] ;
         P00BS74_A527SolicitudServicioComProv = new decimal[1] ;
         P00BS74_n527SolicitudServicioComProv = new bool[] {false} ;
         P00BS74_A127SolicitudesID = new long[1] ;
         A184SolicitudesFechaInstalacion = DateTime.MinValue;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.comercios.ocantsolicitudes__default(),
            new Object[][] {
                new Object[] {
               P00BS3_A40000GXC1, P00BS3_n40000GXC1
               }
               , new Object[] {
               P00BS5_A40001GXC2, P00BS5_n40001GXC2
               }
               , new Object[] {
               P00BS7_A40002GXC3, P00BS7_n40002GXC3
               }
               , new Object[] {
               P00BS9_A40003GXC4, P00BS9_n40003GXC4
               }
               , new Object[] {
               P00BS11_A40004GXC5, P00BS11_n40004GXC5
               }
               , new Object[] {
               P00BS13_A40005GXC6, P00BS13_n40005GXC6
               }
               , new Object[] {
               P00BS15_A40006GXC7, P00BS15_n40006GXC7
               }
               , new Object[] {
               P00BS17_A40007GXC8, P00BS17_n40007GXC8
               }
               , new Object[] {
               P00BS19_A40008GXC9, P00BS19_n40008GXC9
               }
               , new Object[] {
               P00BS21_A40009GXC10, P00BS21_n40009GXC10
               }
               , new Object[] {
               P00BS23_A40010GXC11, P00BS23_n40010GXC11
               }
               , new Object[] {
               P00BS25_A40011GXC12, P00BS25_n40011GXC12
               }
               , new Object[] {
               P00BS27_A40012GXC13, P00BS27_n40012GXC13
               }
               , new Object[] {
               P00BS29_A40013GXC14, P00BS29_n40013GXC14
               }
               , new Object[] {
               P00BS31_A40014GXC15, P00BS31_n40014GXC15
               }
               , new Object[] {
               P00BS33_A40015GXC16, P00BS33_n40015GXC16
               }
               , new Object[] {
               P00BS35_A40016GXC17, P00BS35_n40016GXC17
               }
               , new Object[] {
               P00BS37_A40017GXC18, P00BS37_n40017GXC18
               }
               , new Object[] {
               P00BS39_A40018GXC19, P00BS39_n40018GXC19
               }
               , new Object[] {
               P00BS41_A40019GXC20, P00BS41_n40019GXC20
               }
               , new Object[] {
               P00BS43_A40020GXC21, P00BS43_n40020GXC21
               }
               , new Object[] {
               P00BS45_A40021GXC22, P00BS45_n40021GXC22
               }
               , new Object[] {
               P00BS47_A40022GXC23, P00BS47_n40022GXC23
               }
               , new Object[] {
               P00BS49_A40023GXC24, P00BS49_n40023GXC24
               }
               , new Object[] {
               P00BS51_A40024GXC25, P00BS51_n40024GXC25
               }
               , new Object[] {
               P00BS53_A40025GXC26, P00BS53_n40025GXC26
               }
               , new Object[] {
               P00BS55_A40026GXC27, P00BS55_n40026GXC27
               }
               , new Object[] {
               P00BS57_A40027GXC28, P00BS57_n40027GXC28
               }
               , new Object[] {
               P00BS59_A40028GXC29, P00BS59_n40028GXC29
               }
               , new Object[] {
               P00BS61_A40029GXC30, P00BS61_n40029GXC30
               }
               , new Object[] {
               P00BS63_A40030GXC31, P00BS63_n40030GXC31
               }
               , new Object[] {
               P00BS65_A40031GXC32, P00BS65_n40031GXC32
               }
               , new Object[] {
               P00BS67_A40032GXC33, P00BS67_n40032GXC33
               }
               , new Object[] {
               P00BS69_A40033GXC34, P00BS69_n40033GXC34
               }
               , new Object[] {
               P00BS71_A40034GXC35, P00BS71_n40034GXC35
               }
               , new Object[] {
               P00BS73_A40035GXC36, P00BS73_n40035GXC36
               }
               , new Object[] {
               P00BS74_A184SolicitudesFechaInstalacion, P00BS74_A131EstadosSolId, P00BS74_A133ProveedorID, P00BS74_A527SolicitudServicioComProv, P00BS74_n527SolicitudServicioComProv, P00BS74_A127SolicitudesID
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV18Mes ;
      private short AV17anio ;
      private int A40000GXC1 ;
      private int A40001GXC2 ;
      private int A40002GXC3 ;
      private int A40003GXC4 ;
      private int A40004GXC5 ;
      private int A40005GXC6 ;
      private int A40006GXC7 ;
      private int A40007GXC8 ;
      private int A40009GXC10 ;
      private int A40010GXC11 ;
      private int A40011GXC12 ;
      private int A40012GXC13 ;
      private int A40013GXC14 ;
      private int A40014GXC15 ;
      private int A40015GXC16 ;
      private int A40016GXC17 ;
      private int A40018GXC19 ;
      private int A40019GXC20 ;
      private int A40020GXC21 ;
      private int A40021GXC22 ;
      private int A40022GXC23 ;
      private int A40023GXC24 ;
      private int A40024GXC25 ;
      private int A40025GXC26 ;
      private int A40027GXC28 ;
      private int A40028GXC29 ;
      private int A40029GXC30 ;
      private int A40030GXC31 ;
      private int A40031GXC32 ;
      private int A40032GXC33 ;
      private int A40033GXC34 ;
      private int A40034GXC35 ;
      private int A131EstadosSolId ;
      private long AV9ProveedorID ;
      private long A133ProveedorID ;
      private long A127SolicitudesID ;
      private decimal A40008GXC9 ;
      private decimal A40017GXC18 ;
      private decimal A40026GXC27 ;
      private decimal A40035GXC36 ;
      private decimal A527SolicitudServicioComProv ;
      private DateTime GXt_dtime1 ;
      private DateTime AV13Day ;
      private DateTime AV16InicioMes ;
      private DateTime AV19MesActual ;
      private DateTime AV15MesAnterio ;
      private DateTime A184SolicitudesFechaInstalacion ;
      private bool n40000GXC1 ;
      private bool n40001GXC2 ;
      private bool n40002GXC3 ;
      private bool n40003GXC4 ;
      private bool n40004GXC5 ;
      private bool n40005GXC6 ;
      private bool n40006GXC7 ;
      private bool n40007GXC8 ;
      private bool n40008GXC9 ;
      private bool n40009GXC10 ;
      private bool n40010GXC11 ;
      private bool n40011GXC12 ;
      private bool n40012GXC13 ;
      private bool n40013GXC14 ;
      private bool n40014GXC15 ;
      private bool n40015GXC16 ;
      private bool n40016GXC17 ;
      private bool n40017GXC18 ;
      private bool n40018GXC19 ;
      private bool n40019GXC20 ;
      private bool n40020GXC21 ;
      private bool n40021GXC22 ;
      private bool n40022GXC23 ;
      private bool n40023GXC24 ;
      private bool n40024GXC25 ;
      private bool n40025GXC26 ;
      private bool n40026GXC27 ;
      private bool n40027GXC28 ;
      private bool n40028GXC29 ;
      private bool n40029GXC30 ;
      private bool n40030GXC31 ;
      private bool n40031GXC32 ;
      private bool n40032GXC33 ;
      private bool n40033GXC34 ;
      private bool n40034GXC35 ;
      private bool n40035GXC36 ;
      private bool n527SolicitudServicioComProv ;
      private string AV12Json ;
      private IGxSession AV11Webssesion ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private SdtSDTCantSol AV10SDTCantSol ;
      private IDataStoreProvider pr_default ;
      private int[] P00BS3_A40000GXC1 ;
      private bool[] P00BS3_n40000GXC1 ;
      private int[] P00BS5_A40001GXC2 ;
      private bool[] P00BS5_n40001GXC2 ;
      private int[] P00BS7_A40002GXC3 ;
      private bool[] P00BS7_n40002GXC3 ;
      private int[] P00BS9_A40003GXC4 ;
      private bool[] P00BS9_n40003GXC4 ;
      private int[] P00BS11_A40004GXC5 ;
      private bool[] P00BS11_n40004GXC5 ;
      private int[] P00BS13_A40005GXC6 ;
      private bool[] P00BS13_n40005GXC6 ;
      private int[] P00BS15_A40006GXC7 ;
      private bool[] P00BS15_n40006GXC7 ;
      private int[] P00BS17_A40007GXC8 ;
      private bool[] P00BS17_n40007GXC8 ;
      private decimal[] P00BS19_A40008GXC9 ;
      private bool[] P00BS19_n40008GXC9 ;
      private int[] P00BS21_A40009GXC10 ;
      private bool[] P00BS21_n40009GXC10 ;
      private int[] P00BS23_A40010GXC11 ;
      private bool[] P00BS23_n40010GXC11 ;
      private int[] P00BS25_A40011GXC12 ;
      private bool[] P00BS25_n40011GXC12 ;
      private int[] P00BS27_A40012GXC13 ;
      private bool[] P00BS27_n40012GXC13 ;
      private int[] P00BS29_A40013GXC14 ;
      private bool[] P00BS29_n40013GXC14 ;
      private int[] P00BS31_A40014GXC15 ;
      private bool[] P00BS31_n40014GXC15 ;
      private int[] P00BS33_A40015GXC16 ;
      private bool[] P00BS33_n40015GXC16 ;
      private int[] P00BS35_A40016GXC17 ;
      private bool[] P00BS35_n40016GXC17 ;
      private decimal[] P00BS37_A40017GXC18 ;
      private bool[] P00BS37_n40017GXC18 ;
      private int[] P00BS39_A40018GXC19 ;
      private bool[] P00BS39_n40018GXC19 ;
      private int[] P00BS41_A40019GXC20 ;
      private bool[] P00BS41_n40019GXC20 ;
      private int[] P00BS43_A40020GXC21 ;
      private bool[] P00BS43_n40020GXC21 ;
      private int[] P00BS45_A40021GXC22 ;
      private bool[] P00BS45_n40021GXC22 ;
      private int[] P00BS47_A40022GXC23 ;
      private bool[] P00BS47_n40022GXC23 ;
      private int[] P00BS49_A40023GXC24 ;
      private bool[] P00BS49_n40023GXC24 ;
      private int[] P00BS51_A40024GXC25 ;
      private bool[] P00BS51_n40024GXC25 ;
      private int[] P00BS53_A40025GXC26 ;
      private bool[] P00BS53_n40025GXC26 ;
      private decimal[] P00BS55_A40026GXC27 ;
      private bool[] P00BS55_n40026GXC27 ;
      private int[] P00BS57_A40027GXC28 ;
      private bool[] P00BS57_n40027GXC28 ;
      private int[] P00BS59_A40028GXC29 ;
      private bool[] P00BS59_n40028GXC29 ;
      private int[] P00BS61_A40029GXC30 ;
      private bool[] P00BS61_n40029GXC30 ;
      private int[] P00BS63_A40030GXC31 ;
      private bool[] P00BS63_n40030GXC31 ;
      private int[] P00BS65_A40031GXC32 ;
      private bool[] P00BS65_n40031GXC32 ;
      private int[] P00BS67_A40032GXC33 ;
      private bool[] P00BS67_n40032GXC33 ;
      private int[] P00BS69_A40033GXC34 ;
      private bool[] P00BS69_n40033GXC34 ;
      private int[] P00BS71_A40034GXC35 ;
      private bool[] P00BS71_n40034GXC35 ;
      private decimal[] P00BS73_A40035GXC36 ;
      private bool[] P00BS73_n40035GXC36 ;
      private DateTime[] P00BS74_A184SolicitudesFechaInstalacion ;
      private int[] P00BS74_A131EstadosSolId ;
      private long[] P00BS74_A133ProveedorID ;
      private decimal[] P00BS74_A527SolicitudServicioComProv ;
      private bool[] P00BS74_n527SolicitudServicioComProv ;
      private long[] P00BS74_A127SolicitudesID ;
      private SdtSDTCantSol aP1_SDTCantSol ;
   }

   public class ocantsolicitudes__default : DataStoreHelperBase, IDataStoreHelper
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
         ,new ForEachCursor(def[8])
         ,new ForEachCursor(def[9])
         ,new ForEachCursor(def[10])
         ,new ForEachCursor(def[11])
         ,new ForEachCursor(def[12])
         ,new ForEachCursor(def[13])
         ,new ForEachCursor(def[14])
         ,new ForEachCursor(def[15])
         ,new ForEachCursor(def[16])
         ,new ForEachCursor(def[17])
         ,new ForEachCursor(def[18])
         ,new ForEachCursor(def[19])
         ,new ForEachCursor(def[20])
         ,new ForEachCursor(def[21])
         ,new ForEachCursor(def[22])
         ,new ForEachCursor(def[23])
         ,new ForEachCursor(def[24])
         ,new ForEachCursor(def[25])
         ,new ForEachCursor(def[26])
         ,new ForEachCursor(def[27])
         ,new ForEachCursor(def[28])
         ,new ForEachCursor(def[29])
         ,new ForEachCursor(def[30])
         ,new ForEachCursor(def[31])
         ,new ForEachCursor(def[32])
         ,new ForEachCursor(def[33])
         ,new ForEachCursor(def[34])
         ,new ForEachCursor(def[35])
         ,new ForEachCursor(def[36])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP00BS3;
          prmP00BS3 = new Object[] {
          new ParDef("@AV9ProveedorID",GXType.Decimal,18,0)
          };
          Object[] prmP00BS5;
          prmP00BS5 = new Object[] {
          new ParDef("@AV9ProveedorID",GXType.Decimal,18,0)
          };
          Object[] prmP00BS7;
          prmP00BS7 = new Object[] {
          new ParDef("@AV9ProveedorID",GXType.Decimal,18,0)
          };
          Object[] prmP00BS9;
          prmP00BS9 = new Object[] {
          new ParDef("@AV9ProveedorID",GXType.Decimal,18,0)
          };
          Object[] prmP00BS11;
          prmP00BS11 = new Object[] {
          new ParDef("@AV9ProveedorID",GXType.Decimal,18,0)
          };
          Object[] prmP00BS13;
          prmP00BS13 = new Object[] {
          new ParDef("@AV9ProveedorID",GXType.Decimal,18,0)
          };
          Object[] prmP00BS15;
          prmP00BS15 = new Object[] {
          new ParDef("@AV9ProveedorID",GXType.Decimal,18,0)
          };
          Object[] prmP00BS17;
          prmP00BS17 = new Object[] {
          new ParDef("@AV9ProveedorID",GXType.Decimal,18,0)
          };
          Object[] prmP00BS19;
          prmP00BS19 = new Object[] {
          new ParDef("@AV9ProveedorID",GXType.Decimal,18,0)
          };
          Object[] prmP00BS21;
          prmP00BS21 = new Object[] {
          new ParDef("@AV9ProveedorID",GXType.Decimal,18,0)
          };
          Object[] prmP00BS23;
          prmP00BS23 = new Object[] {
          new ParDef("@AV9ProveedorID",GXType.Decimal,18,0)
          };
          Object[] prmP00BS25;
          prmP00BS25 = new Object[] {
          new ParDef("@AV9ProveedorID",GXType.Decimal,18,0)
          };
          Object[] prmP00BS27;
          prmP00BS27 = new Object[] {
          new ParDef("@AV9ProveedorID",GXType.Decimal,18,0)
          };
          Object[] prmP00BS29;
          prmP00BS29 = new Object[] {
          new ParDef("@AV9ProveedorID",GXType.Decimal,18,0)
          };
          Object[] prmP00BS31;
          prmP00BS31 = new Object[] {
          new ParDef("@AV9ProveedorID",GXType.Decimal,18,0)
          };
          Object[] prmP00BS33;
          prmP00BS33 = new Object[] {
          new ParDef("@AV9ProveedorID",GXType.Decimal,18,0)
          };
          Object[] prmP00BS35;
          prmP00BS35 = new Object[] {
          new ParDef("@AV9ProveedorID",GXType.Decimal,18,0)
          };
          Object[] prmP00BS37;
          prmP00BS37 = new Object[] {
          new ParDef("@AV9ProveedorID",GXType.Decimal,18,0)
          };
          Object[] prmP00BS39;
          prmP00BS39 = new Object[] {
          };
          Object[] prmP00BS41;
          prmP00BS41 = new Object[] {
          };
          Object[] prmP00BS43;
          prmP00BS43 = new Object[] {
          };
          Object[] prmP00BS45;
          prmP00BS45 = new Object[] {
          };
          Object[] prmP00BS47;
          prmP00BS47 = new Object[] {
          };
          Object[] prmP00BS49;
          prmP00BS49 = new Object[] {
          };
          Object[] prmP00BS51;
          prmP00BS51 = new Object[] {
          };
          Object[] prmP00BS53;
          prmP00BS53 = new Object[] {
          };
          Object[] prmP00BS55;
          prmP00BS55 = new Object[] {
          };
          Object[] prmP00BS57;
          prmP00BS57 = new Object[] {
          };
          Object[] prmP00BS59;
          prmP00BS59 = new Object[] {
          };
          Object[] prmP00BS61;
          prmP00BS61 = new Object[] {
          };
          Object[] prmP00BS63;
          prmP00BS63 = new Object[] {
          };
          Object[] prmP00BS65;
          prmP00BS65 = new Object[] {
          };
          Object[] prmP00BS67;
          prmP00BS67 = new Object[] {
          };
          Object[] prmP00BS69;
          prmP00BS69 = new Object[] {
          };
          Object[] prmP00BS71;
          prmP00BS71 = new Object[] {
          };
          Object[] prmP00BS73;
          prmP00BS73 = new Object[] {
          };
          Object[] prmP00BS74;
          prmP00BS74 = new Object[] {
          new ParDef("@AV9ProveedorID",GXType.Decimal,18,0) ,
          new ParDef("@AV15MesAnterio",GXType.Date,8,0) ,
          new ParDef("@AV19MesActual",GXType.Date,8,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00BS3", "SELECT COALESCE( T1.[GXC1], 0) AS GXC1 FROM (SELECT COUNT(*) AS GXC1 FROM [Solicitudes] WHERE ([ProveedorID] = @AV9ProveedorID) AND ([EstadosSolId] = 1) ) T1 ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00BS3,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00BS5", "SELECT COALESCE( T1.[GXC1], 0) AS GXC2 FROM (SELECT COUNT(*) AS GXC1 FROM [Solicitudes] WHERE ([ProveedorID] = @AV9ProveedorID) AND ([EstadosSolId] = 2) ) T1 ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00BS5,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00BS7", "SELECT COALESCE( T1.[GXC1], 0) AS GXC3 FROM (SELECT COUNT(*) AS GXC1 FROM [Solicitudes] WHERE ([ProveedorID] = @AV9ProveedorID) AND ([EstadosSolId] = 3) ) T1 ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00BS7,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00BS9", "SELECT COALESCE( T1.[GXC1], 0) AS GXC4 FROM (SELECT COUNT(*) AS GXC1 FROM [Solicitudes] WHERE ([ProveedorID] = @AV9ProveedorID) AND ([EstadosSolId] = 4) ) T1 ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00BS9,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00BS11", "SELECT COALESCE( T1.[GXC1], 0) AS GXC5 FROM (SELECT COUNT(*) AS GXC1 FROM [Solicitudes] WHERE ([ProveedorID] = @AV9ProveedorID) AND ([EstadosSolId] = 5) ) T1 ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00BS11,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00BS13", "SELECT COALESCE( T1.[GXC1], 0) AS GXC6 FROM (SELECT COUNT(*) AS GXC1 FROM [Solicitudes] WHERE ([ProveedorID] = @AV9ProveedorID) AND ([EstadosSolId] = 6) ) T1 ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00BS13,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00BS15", "SELECT COALESCE( T1.[GXC1], 0) AS GXC7 FROM (SELECT COUNT(*) AS GXC1 FROM [Solicitudes] WHERE ([ProveedorID] = @AV9ProveedorID) AND ([EstadosSolId] = 7) ) T1 ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00BS15,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00BS17", "SELECT COALESCE( T1.[GXC1], 0) AS GXC8 FROM (SELECT COUNT(*) AS GXC1 FROM [Solicitudes] WHERE ([ProveedorID] = @AV9ProveedorID) AND ([EstadosSolId] = 8) ) T1 ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00BS17,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00BS19", "SELECT COALESCE( T1.[GXC9], 0) AS GXC9 FROM (SELECT SUM([SolicitudServicioComProv]) AS GXC9 FROM [Solicitudes] WHERE (( [EstadosSolId] <> 5)) AND ([ProveedorID] = @AV9ProveedorID) ) T1 ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00BS19,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00BS21", "SELECT COALESCE( T1.[GXC10], 0) AS GXC10 FROM (SELECT COUNT(*) AS GXC10 FROM [HistoricoSolicitudes] WHERE ([HistoricoSolicitudesProvID] = @AV9ProveedorID) AND ([EstadosSolId] = 1) ) T1 ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00BS21,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00BS23", "SELECT COALESCE( T1.[GXC10], 0) AS GXC11 FROM (SELECT COUNT(*) AS GXC10 FROM [HistoricoSolicitudes] WHERE ([HistoricoSolicitudesProvID] = @AV9ProveedorID) AND ([EstadosSolId] = 2) ) T1 ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00BS23,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00BS25", "SELECT COALESCE( T1.[GXC10], 0) AS GXC12 FROM (SELECT COUNT(*) AS GXC10 FROM [HistoricoSolicitudes] WHERE ([HistoricoSolicitudesProvID] = @AV9ProveedorID) AND ([EstadosSolId] = 3) ) T1 ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00BS25,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00BS27", "SELECT COALESCE( T1.[GXC10], 0) AS GXC13 FROM (SELECT COUNT(*) AS GXC10 FROM [HistoricoSolicitudes] WHERE ([HistoricoSolicitudesProvID] = @AV9ProveedorID) AND ([EstadosSolId] = 4) ) T1 ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00BS27,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00BS29", "SELECT COALESCE( T1.[GXC10], 0) AS GXC14 FROM (SELECT COUNT(*) AS GXC10 FROM [HistoricoSolicitudes] WHERE ([HistoricoSolicitudesProvID] = @AV9ProveedorID) AND ([EstadosSolId] = 5) ) T1 ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00BS29,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00BS31", "SELECT COALESCE( T1.[GXC10], 0) AS GXC15 FROM (SELECT COUNT(*) AS GXC10 FROM [HistoricoSolicitudes] WHERE ([HistoricoSolicitudesProvID] = @AV9ProveedorID) AND ([EstadosSolId] = 6) ) T1 ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00BS31,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00BS33", "SELECT COALESCE( T1.[GXC10], 0) AS GXC16 FROM (SELECT COUNT(*) AS GXC10 FROM [HistoricoSolicitudes] WHERE ([HistoricoSolicitudesProvID] = @AV9ProveedorID) AND ([EstadosSolId] = 7) ) T1 ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00BS33,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00BS35", "SELECT COALESCE( T1.[GXC10], 0) AS GXC17 FROM (SELECT COUNT(*) AS GXC10 FROM [HistoricoSolicitudes] WHERE ([HistoricoSolicitudesProvID] = @AV9ProveedorID) AND ([EstadosSolId] = 8) ) T1 ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00BS35,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00BS37", "SELECT COALESCE( T1.[GXC18], 0) AS GXC18 FROM (SELECT SUM([HistoricoSolicitudesComProv]) AS GXC18 FROM [HistoricoSolicitudes] WHERE (( [EstadosSolId] <> 5)) AND ([HistoricoSolicitudesProvID] = @AV9ProveedorID) ) T1 ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00BS37,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00BS39", "SELECT COALESCE( T1.[GXC1], 0) AS GXC19 FROM (SELECT COUNT(*) AS GXC1 FROM [Solicitudes] WHERE [EstadosSolId] = 1 ) T1 ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00BS39,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00BS41", "SELECT COALESCE( T1.[GXC1], 0) AS GXC20 FROM (SELECT COUNT(*) AS GXC1 FROM [Solicitudes] WHERE [EstadosSolId] = 2 ) T1 ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00BS41,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00BS43", "SELECT COALESCE( T1.[GXC1], 0) AS GXC21 FROM (SELECT COUNT(*) AS GXC1 FROM [Solicitudes] WHERE [EstadosSolId] = 3 ) T1 ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00BS43,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00BS45", "SELECT COALESCE( T1.[GXC1], 0) AS GXC22 FROM (SELECT COUNT(*) AS GXC1 FROM [Solicitudes] WHERE [EstadosSolId] = 4 ) T1 ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00BS45,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00BS47", "SELECT COALESCE( T1.[GXC1], 0) AS GXC23 FROM (SELECT COUNT(*) AS GXC1 FROM [Solicitudes] WHERE [EstadosSolId] = 5 ) T1 ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00BS47,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00BS49", "SELECT COALESCE( T1.[GXC1], 0) AS GXC24 FROM (SELECT COUNT(*) AS GXC1 FROM [Solicitudes] WHERE [EstadosSolId] = 6 ) T1 ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00BS49,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00BS51", "SELECT COALESCE( T1.[GXC1], 0) AS GXC25 FROM (SELECT COUNT(*) AS GXC1 FROM [Solicitudes] WHERE [EstadosSolId] = 7 ) T1 ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00BS51,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00BS53", "SELECT COALESCE( T1.[GXC1], 0) AS GXC26 FROM (SELECT COUNT(*) AS GXC1 FROM [Solicitudes] WHERE [EstadosSolId] = 8 ) T1 ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00BS53,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00BS55", "SELECT COALESCE( T1.[GXC9], 0) AS GXC27 FROM (SELECT SUM([SolicitudServicioComProv]) AS GXC9 FROM [Solicitudes] WHERE ( [EstadosSolId] <> 5) ) T1 ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00BS55,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00BS57", "SELECT COALESCE( T1.[GXC10], 0) AS GXC28 FROM (SELECT COUNT(*) AS GXC10 FROM [HistoricoSolicitudes] WHERE [EstadosSolId] = 1 ) T1 ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00BS57,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00BS59", "SELECT COALESCE( T1.[GXC10], 0) AS GXC29 FROM (SELECT COUNT(*) AS GXC10 FROM [HistoricoSolicitudes] WHERE [EstadosSolId] = 2 ) T1 ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00BS59,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00BS61", "SELECT COALESCE( T1.[GXC10], 0) AS GXC30 FROM (SELECT COUNT(*) AS GXC10 FROM [HistoricoSolicitudes] WHERE [EstadosSolId] = 3 ) T1 ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00BS61,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00BS63", "SELECT COALESCE( T1.[GXC10], 0) AS GXC31 FROM (SELECT COUNT(*) AS GXC10 FROM [HistoricoSolicitudes] WHERE [EstadosSolId] = 4 ) T1 ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00BS63,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00BS65", "SELECT COALESCE( T1.[GXC10], 0) AS GXC32 FROM (SELECT COUNT(*) AS GXC10 FROM [HistoricoSolicitudes] WHERE [EstadosSolId] = 5 ) T1 ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00BS65,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00BS67", "SELECT COALESCE( T1.[GXC10], 0) AS GXC33 FROM (SELECT COUNT(*) AS GXC10 FROM [HistoricoSolicitudes] WHERE [EstadosSolId] = 6 ) T1 ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00BS67,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00BS69", "SELECT COALESCE( T1.[GXC10], 0) AS GXC34 FROM (SELECT COUNT(*) AS GXC10 FROM [HistoricoSolicitudes] WHERE [EstadosSolId] = 7 ) T1 ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00BS69,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00BS71", "SELECT COALESCE( T1.[GXC10], 0) AS GXC35 FROM (SELECT COUNT(*) AS GXC10 FROM [HistoricoSolicitudes] WHERE [EstadosSolId] = 8 ) T1 ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00BS71,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00BS73", "SELECT COALESCE( T1.[GXC18], 0) AS GXC36 FROM (SELECT SUM([HistoricoSolicitudesComProv]) AS GXC18 FROM [HistoricoSolicitudes] WHERE ( [EstadosSolId] <> 5) ) T1 ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00BS73,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00BS74", "SELECT [SolicitudesFechaInstalacion], [EstadosSolId], [ProveedorID], [SolicitudServicioComProv], [SolicitudesID] FROM [Solicitudes] WHERE ([ProveedorID] = @AV9ProveedorID or @AV9ProveedorID = 0) AND ([EstadosSolId] <> 5) AND ([SolicitudesFechaInstalacion] >= @AV15MesAnterio) AND ([SolicitudesFechaInstalacion] <= DATEADD(day, -1, DATEADD(month, 1, DATEADD(day, -DAY(@AV19MesActual) + 1, @AV19MesActual)))) ORDER BY [SolicitudesID] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00BS74,100, GxCacheFrequency.OFF ,false,false )
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
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 2 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 3 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 4 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 5 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 6 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 7 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 8 :
                ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 9 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 10 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 11 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 12 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 13 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 14 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 15 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 16 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 17 :
                ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 18 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 19 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 20 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 21 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 22 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 23 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 24 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 25 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 26 :
                ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 27 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 28 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 29 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
       }
       getresults30( cursor, rslt, buf) ;
    }

    public void getresults30( int cursor ,
                              IFieldGetter rslt ,
                              Object[] buf )
    {
       switch ( cursor )
       {
             case 30 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 31 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 32 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 33 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 34 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 35 :
                ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 36 :
                ((DateTime[]) buf[0])[0] = rslt.getGXDate(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((long[]) buf[2])[0] = rslt.getLong(3);
                ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
                ((bool[]) buf[4])[0] = rslt.wasNull(4);
                ((long[]) buf[5])[0] = rslt.getLong(5);
                return;
       }
    }

 }

}

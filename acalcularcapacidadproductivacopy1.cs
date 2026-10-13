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
   public class acalcularcapacidadproductivacopy1 : GXProcedure
   {
      public static int Main( string[] args )
      {
         return new acalcularcapacidadproductivacopy1().MainImpl(args); ;
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

      public acalcularcapacidadproductivacopy1( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public acalcularcapacidadproductivacopy1( IGxContext context )
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
         AV14SolXDepto = 0;
         AV10Count = 0;
         /* Optimized DELETE. */
         /* Using cursor P00GM2 */
         pr_default.execute(0);
         pr_default.close(0);
         pr_default.SmartCacheProvider.SetUpdated("CapacidadProductivaAux");
         /* End optimized DELETE. */
         /* Using cursor P00GM3 */
         pr_default.execute(1);
         while ( (pr_default.getStatus(1) != 101) )
         {
            A127SolicitudesID = P00GM3_A127SolicitudesID[0];
            A120ProfesionalesId = P00GM3_A120ProfesionalesId[0];
            A112DepartamentoId = P00GM3_A112DepartamentoId[0];
            n112DepartamentoId = P00GM3_n112DepartamentoId[0];
            A140RelacionesId = P00GM3_A140RelacionesId[0];
            A112DepartamentoId = P00GM3_A112DepartamentoId[0];
            n112DepartamentoId = P00GM3_n112DepartamentoId[0];
            AV12DepartamentoIdAnt = A112DepartamentoId;
            AV9ProfesionalesIdAnt = A120ProfesionalesId;
            /* Exit For each command. Update data (if necessary), close cursors & exit. */
            if (true) break;
            pr_default.readNext(1);
         }
         pr_default.close(1);
         /* Using cursor P00GM4 */
         pr_default.execute(2);
         while ( (pr_default.getStatus(2) != 101) )
         {
            A127SolicitudesID = P00GM4_A127SolicitudesID[0];
            A120ProfesionalesId = P00GM4_A120ProfesionalesId[0];
            A113DepartamentoDepartamento = P00GM4_A113DepartamentoDepartamento[0];
            A112DepartamentoId = P00GM4_A112DepartamentoId[0];
            n112DepartamentoId = P00GM4_n112DepartamentoId[0];
            A140RelacionesId = P00GM4_A140RelacionesId[0];
            A112DepartamentoId = P00GM4_A112DepartamentoId[0];
            n112DepartamentoId = P00GM4_n112DepartamentoId[0];
            A113DepartamentoDepartamento = P00GM4_A113DepartamentoDepartamento[0];
            AV14SolXDepto = (long)(AV14SolXDepto+1);
            AV11DepartamentoId = A112DepartamentoId;
            AV17DepartamentoNombre = A113DepartamentoDepartamento;
            AV8ProfesionalesID = A120ProfesionalesId;
            if ( ( ( AV11DepartamentoId != AV12DepartamentoIdAnt ) ) || ( ( StringUtil.StrCmp(AV8ProfesionalesID, AV9ProfesionalesIdAnt) != 0 ) ) )
            {
               /* Execute user subroutine: 'REGISTRAR' */
               S111 ();
               if ( returnInSub )
               {
                  pr_default.close(2);
                  cleanup();
                  if (true) return;
               }
               AV12DepartamentoIdAnt = AV11DepartamentoId;
               AV9ProfesionalesIdAnt = AV8ProfesionalesID;
               AV14SolXDepto = 0;
            }
            pr_default.readNext(2);
         }
         pr_default.close(2);
         /* Using cursor P00GM5 */
         pr_default.execute(3);
         while ( (pr_default.getStatus(3) != 101) )
         {
            A824CapacidadProductivaAuxProfId = P00GM5_A824CapacidadProductivaAuxProfId[0];
            A820CapacidadProductivaAuxId = P00GM5_A820CapacidadProductivaAuxId[0];
            AV9ProfesionalesIdAnt = A824CapacidadProductivaAuxProfId;
            /* Exit For each command. Update data (if necessary), close cursors & exit. */
            if (true) break;
            pr_default.readNext(3);
         }
         pr_default.close(3);
         /* Using cursor P00GM6 */
         pr_default.execute(4);
         while ( (pr_default.getStatus(4) != 101) )
         {
            A821CapacidadProductivaAuxCant = P00GM6_A821CapacidadProductivaAuxCant[0];
            A824CapacidadProductivaAuxProfId = P00GM6_A824CapacidadProductivaAuxProfId[0];
            A820CapacidadProductivaAuxId = P00GM6_A820CapacidadProductivaAuxId[0];
            AV8ProfesionalesID = StringUtil.Trim( A824CapacidadProductivaAuxProfId);
            if ( StringUtil.StrCmp(AV8ProfesionalesID, AV9ProfesionalesIdAnt) != 0 )
            {
               /* Execute user subroutine: 'UPDATEPORCENT' */
               S131 ();
               if ( returnInSub )
               {
                  pr_default.close(4);
                  cleanup();
                  if (true) return;
               }
               AV10Count = 0;
               AV9ProfesionalesIdAnt = AV8ProfesionalesID;
            }
            AV10Count = (decimal)(AV10Count+A821CapacidadProductivaAuxCant);
            pr_default.readNext(4);
         }
         pr_default.close(4);
         /* Execute user subroutine: 'UPDATEPORCENT' */
         S131 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         /* Using cursor P00GM8 */
         pr_default.execute(5);
         while ( (pr_default.getStatus(5) != 101) )
         {
            A826CapacidadProductivaAuxPorcent = P00GM8_A826CapacidadProductivaAuxPorcent[0];
            A808CapacidadProductivaAuxHoras = P00GM8_A808CapacidadProductivaAuxHoras[0];
            A824CapacidadProductivaAuxProfId = P00GM8_A824CapacidadProductivaAuxProfId[0];
            A40000ProfesionalesCapacidadProducti = P00GM8_A40000ProfesionalesCapacidadProducti[0];
            n40000ProfesionalesCapacidadProducti = P00GM8_n40000ProfesionalesCapacidadProducti[0];
            A820CapacidadProductivaAuxId = P00GM8_A820CapacidadProductivaAuxId[0];
            A40000ProfesionalesCapacidadProducti = P00GM8_A40000ProfesionalesCapacidadProducti[0];
            n40000ProfesionalesCapacidadProducti = P00GM8_n40000ProfesionalesCapacidadProducti[0];
            AV24ProfesionalesCapacidadProductiva = A40000ProfesionalesCapacidadProducti;
            A808CapacidadProductivaAuxHoras = (decimal)(AV24ProfesionalesCapacidadProductiva*(A826CapacidadProductivaAuxPorcent/ (decimal)(100)));
            /* Using cursor P00GM9 */
            pr_default.execute(6, new Object[] {A808CapacidadProductivaAuxHoras, A820CapacidadProductivaAuxId});
            pr_default.close(6);
            pr_default.SmartCacheProvider.SetUpdated("CapacidadProductivaAux");
            pr_default.readNext(5);
         }
         pr_default.close(5);
         /* Optimized DELETE. */
         /* Using cursor P00GM10 */
         pr_default.execute(7);
         pr_default.close(7);
         pr_default.SmartCacheProvider.SetUpdated("TablaAux");
         /* End optimized DELETE. */
         /* Using cursor P00GM11 */
         pr_default.execute(8);
         while ( (pr_default.getStatus(8) != 101) )
         {
            A824CapacidadProductivaAuxProfId = P00GM11_A824CapacidadProductivaAuxProfId[0];
            A825CapacidadProductivaAuxDepId = P00GM11_A825CapacidadProductivaAuxDepId[0];
            A820CapacidadProductivaAuxId = P00GM11_A820CapacidadProductivaAuxId[0];
            AV19CapacidadProductivaAuxDepIdAnt = A825CapacidadProductivaAuxDepId;
            /* Exit For each command. Update data (if necessary), close cursors & exit. */
            if (true) break;
            pr_default.readNext(8);
         }
         pr_default.close(8);
         AV10Count = 0;
         /* Using cursor P00GM12 */
         pr_default.execute(9);
         while ( (pr_default.getStatus(9) != 101) )
         {
            A821CapacidadProductivaAuxCant = P00GM12_A821CapacidadProductivaAuxCant[0];
            A824CapacidadProductivaAuxProfId = P00GM12_A824CapacidadProductivaAuxProfId[0];
            A825CapacidadProductivaAuxDepId = P00GM12_A825CapacidadProductivaAuxDepId[0];
            A820CapacidadProductivaAuxId = P00GM12_A820CapacidadProductivaAuxId[0];
            AV18CapacidadProductivaAuxDepId = A825CapacidadProductivaAuxDepId;
            if ( AV18CapacidadProductivaAuxDepId != AV19CapacidadProductivaAuxDepIdAnt )
            {
               /* Execute user subroutine: 'REGISTRARTABLAAUX' */
               S121 ();
               if ( returnInSub )
               {
                  pr_default.close(9);
                  cleanup();
                  if (true) return;
               }
            }
            AV10Count = (decimal)(AV10Count+A821CapacidadProductivaAuxCant);
            pr_default.readNext(9);
         }
         pr_default.close(9);
         AV10Count = 0;
         /* Optimized group. */
         /* Using cursor P00GM13 */
         pr_default.execute(10, new Object[] {AV18CapacidadProductivaAuxDepId});
         c821CapacidadProductivaAuxCant = (decimal)(P00GM13_A821CapacidadProductivaAuxCant[0]);
         pr_default.close(10);
         AV10Count = (decimal)(AV10Count+c821CapacidadProductivaAuxCant);
         /* End optimized group. */
         /*
            INSERT RECORD ON TABLE TablaAux

         */
         /* Using cursor P00GM15 */
         pr_default.execute(11, new Object[] {AV18CapacidadProductivaAuxDepId});
         if ( (pr_default.getStatus(11) != 101) )
         {
            A40001DepartamentoDepartamento = P00GM15_A40001DepartamentoDepartamento[0];
            n40001DepartamentoDepartamento = P00GM15_n40001DepartamentoDepartamento[0];
         }
         else
         {
            A40001DepartamentoDepartamento = "";
            n40001DepartamentoDepartamento = false;
         }
         pr_default.close(11);
         A831TablaAuxDepartamentoId = AV18CapacidadProductivaAuxDepId;
         A832TablaAuxDepartamentoNombre = A40001DepartamentoDepartamento;
         A833TablaAuxCapacidadProd = AV10Count;
         /* Using cursor P00GM16 */
         pr_default.execute(12, new Object[] {A831TablaAuxDepartamentoId, A832TablaAuxDepartamentoNombre, A833TablaAuxCapacidadProd});
         A830TablaAuxId = P00GM16_A830TablaAuxId[0];
         pr_default.close(12);
         pr_default.SmartCacheProvider.SetUpdated("TablaAux");
         if ( (pr_default.getStatus(12) == 1) )
         {
            context.Gx_err = 1;
            Gx_emsg = (string)(context.GetMessage( "GXM_noupdate", ""));
         }
         else
         {
            context.Gx_err = 0;
            Gx_emsg = "";
         }
         /* End Insert */
         cleanup();
      }

      protected void S111( )
      {
         /* 'REGISTRAR' Routine */
         returnInSub = false;
         /* Using cursor P00GM17 */
         pr_default.execute(13, new Object[] {AV9ProfesionalesIdAnt});
         while ( (pr_default.getStatus(13) != 101) )
         {
            A108EstadosGenericosId = P00GM17_A108EstadosGenericosId[0];
            A107EstadosTipo = P00GM17_A107EstadosTipo[0];
            A120ProfesionalesId = P00GM17_A120ProfesionalesId[0];
            if ( StringUtil.StrCmp(A107EstadosTipo, context.GetMessage( "STS", "")) == 0 )
            {
               /*
                  INSERT RECORD ON TABLE CapacidadProductivaAux

               */
               A824CapacidadProductivaAuxProfId = AV9ProfesionalesIdAnt;
               A825CapacidadProductivaAuxDepId = AV12DepartamentoIdAnt;
               A821CapacidadProductivaAuxCant = AV14SolXDepto;
               A834CapacidadProductivaAuxDepNombr = AV17DepartamentoNombre;
               /* Using cursor P00GM18 */
               pr_default.execute(14, new Object[] {A821CapacidadProductivaAuxCant, A824CapacidadProductivaAuxProfId, A825CapacidadProductivaAuxDepId, A834CapacidadProductivaAuxDepNombr});
               A820CapacidadProductivaAuxId = P00GM18_A820CapacidadProductivaAuxId[0];
               pr_default.close(14);
               pr_default.SmartCacheProvider.SetUpdated("CapacidadProductivaAux");
               if ( (pr_default.getStatus(14) == 1) )
               {
                  context.Gx_err = 1;
                  Gx_emsg = (string)(context.GetMessage( "GXM_noupdate", ""));
               }
               else
               {
                  context.Gx_err = 0;
                  Gx_emsg = "";
               }
               /* End Insert */
            }
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(13);
      }

      protected void S121( )
      {
         /* 'REGISTRARTABLAAUX' Routine */
         returnInSub = false;
         /*
            INSERT RECORD ON TABLE TablaAux

         */
         /* Using cursor P00GM20 */
         pr_default.execute(15, new Object[] {AV19CapacidadProductivaAuxDepIdAnt});
         if ( (pr_default.getStatus(15) != 101) )
         {
            A40002DepartamentoDepartamento = P00GM20_A40002DepartamentoDepartamento[0];
            n40002DepartamentoDepartamento = P00GM20_n40002DepartamentoDepartamento[0];
         }
         else
         {
            A40002DepartamentoDepartamento = "";
            n40002DepartamentoDepartamento = false;
         }
         pr_default.close(15);
         A831TablaAuxDepartamentoId = AV19CapacidadProductivaAuxDepIdAnt;
         A832TablaAuxDepartamentoNombre = A40002DepartamentoDepartamento;
         A833TablaAuxCapacidadProd = AV10Count;
         AV10Count = 0;
         AV19CapacidadProductivaAuxDepIdAnt = AV18CapacidadProductivaAuxDepId;
         /* Using cursor P00GM21 */
         pr_default.execute(16, new Object[] {A831TablaAuxDepartamentoId, A832TablaAuxDepartamentoNombre, A833TablaAuxCapacidadProd});
         A830TablaAuxId = P00GM21_A830TablaAuxId[0];
         pr_default.close(16);
         pr_default.SmartCacheProvider.SetUpdated("TablaAux");
         if ( (pr_default.getStatus(16) == 1) )
         {
            context.Gx_err = 1;
            Gx_emsg = (string)(context.GetMessage( "GXM_noupdate", ""));
         }
         else
         {
            context.Gx_err = 0;
            Gx_emsg = "";
         }
         /* End Insert */
      }

      protected void S131( )
      {
         /* 'UPDATEPORCENT' Routine */
         returnInSub = false;
         /* Optimized UPDATE. */
         /* Using cursor P00GM22 */
         pr_default.execute(17, new Object[] {AV10Count, AV9ProfesionalesIdAnt});
         pr_default.close(17);
         pr_default.SmartCacheProvider.SetUpdated("CapacidadProductivaAux");
         /* End optimized UPDATE. */
      }

      public override void cleanup( )
      {
         context.CommitDataStores("calcularcapacidadproductivacopy1",pr_default);
         CloseCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
         ExitApp();
      }

      protected override void CloseCursors( )
      {
         pr_default.close(15);
         pr_default.close(11);
      }

      public override void initialize( )
      {
         P00GM3_A127SolicitudesID = new long[1] ;
         P00GM3_A120ProfesionalesId = new string[] {""} ;
         P00GM3_A112DepartamentoId = new long[1] ;
         P00GM3_n112DepartamentoId = new bool[] {false} ;
         P00GM3_A140RelacionesId = new long[1] ;
         A120ProfesionalesId = "";
         AV9ProfesionalesIdAnt = "";
         P00GM4_A127SolicitudesID = new long[1] ;
         P00GM4_A120ProfesionalesId = new string[] {""} ;
         P00GM4_A113DepartamentoDepartamento = new string[] {""} ;
         P00GM4_A112DepartamentoId = new long[1] ;
         P00GM4_n112DepartamentoId = new bool[] {false} ;
         P00GM4_A140RelacionesId = new long[1] ;
         A113DepartamentoDepartamento = "";
         AV17DepartamentoNombre = "";
         AV8ProfesionalesID = "";
         P00GM5_A824CapacidadProductivaAuxProfId = new string[] {""} ;
         P00GM5_A820CapacidadProductivaAuxId = new long[1] ;
         A824CapacidadProductivaAuxProfId = "";
         P00GM6_A821CapacidadProductivaAuxCant = new long[1] ;
         P00GM6_A824CapacidadProductivaAuxProfId = new string[] {""} ;
         P00GM6_A820CapacidadProductivaAuxId = new long[1] ;
         P00GM8_A826CapacidadProductivaAuxPorcent = new decimal[1] ;
         P00GM8_A808CapacidadProductivaAuxHoras = new decimal[1] ;
         P00GM8_A824CapacidadProductivaAuxProfId = new string[] {""} ;
         P00GM8_A40000ProfesionalesCapacidadProducti = new decimal[1] ;
         P00GM8_n40000ProfesionalesCapacidadProducti = new bool[] {false} ;
         P00GM8_A820CapacidadProductivaAuxId = new long[1] ;
         P00GM11_A824CapacidadProductivaAuxProfId = new string[] {""} ;
         P00GM11_A825CapacidadProductivaAuxDepId = new long[1] ;
         P00GM11_A820CapacidadProductivaAuxId = new long[1] ;
         P00GM12_A821CapacidadProductivaAuxCant = new long[1] ;
         P00GM12_A824CapacidadProductivaAuxProfId = new string[] {""} ;
         P00GM12_A825CapacidadProductivaAuxDepId = new long[1] ;
         P00GM12_A820CapacidadProductivaAuxId = new long[1] ;
         P00GM13_A821CapacidadProductivaAuxCant = new long[1] ;
         P00GM15_A40001DepartamentoDepartamento = new string[] {""} ;
         P00GM15_n40001DepartamentoDepartamento = new bool[] {false} ;
         A40001DepartamentoDepartamento = "";
         A832TablaAuxDepartamentoNombre = "";
         P00GM16_A830TablaAuxId = new long[1] ;
         Gx_emsg = "";
         P00GM17_A108EstadosGenericosId = new int[1] ;
         P00GM17_A107EstadosTipo = new string[] {""} ;
         P00GM17_A120ProfesionalesId = new string[] {""} ;
         A107EstadosTipo = "";
         A834CapacidadProductivaAuxDepNombr = "";
         P00GM18_A820CapacidadProductivaAuxId = new long[1] ;
         P00GM20_A40002DepartamentoDepartamento = new string[] {""} ;
         P00GM20_n40002DepartamentoDepartamento = new bool[] {false} ;
         A40002DepartamentoDepartamento = "";
         P00GM21_A830TablaAuxId = new long[1] ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.acalcularcapacidadproductivacopy1__default(),
            new Object[][] {
                new Object[] {
               }
               , new Object[] {
               P00GM3_A127SolicitudesID, P00GM3_A120ProfesionalesId, P00GM3_A112DepartamentoId, P00GM3_n112DepartamentoId, P00GM3_A140RelacionesId
               }
               , new Object[] {
               P00GM4_A127SolicitudesID, P00GM4_A120ProfesionalesId, P00GM4_A113DepartamentoDepartamento, P00GM4_A112DepartamentoId, P00GM4_n112DepartamentoId, P00GM4_A140RelacionesId
               }
               , new Object[] {
               P00GM5_A824CapacidadProductivaAuxProfId, P00GM5_A820CapacidadProductivaAuxId
               }
               , new Object[] {
               P00GM6_A821CapacidadProductivaAuxCant, P00GM6_A824CapacidadProductivaAuxProfId, P00GM6_A820CapacidadProductivaAuxId
               }
               , new Object[] {
               P00GM8_A826CapacidadProductivaAuxPorcent, P00GM8_A808CapacidadProductivaAuxHoras, P00GM8_A824CapacidadProductivaAuxProfId, P00GM8_A40000ProfesionalesCapacidadProducti, P00GM8_n40000ProfesionalesCapacidadProducti, P00GM8_A820CapacidadProductivaAuxId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               P00GM11_A824CapacidadProductivaAuxProfId, P00GM11_A825CapacidadProductivaAuxDepId, P00GM11_A820CapacidadProductivaAuxId
               }
               , new Object[] {
               P00GM12_A821CapacidadProductivaAuxCant, P00GM12_A824CapacidadProductivaAuxProfId, P00GM12_A825CapacidadProductivaAuxDepId, P00GM12_A820CapacidadProductivaAuxId
               }
               , new Object[] {
               P00GM13_A821CapacidadProductivaAuxCant
               }
               , new Object[] {
               P00GM15_A40001DepartamentoDepartamento, P00GM15_n40001DepartamentoDepartamento
               }
               , new Object[] {
               P00GM16_A830TablaAuxId
               }
               , new Object[] {
               P00GM17_A108EstadosGenericosId, P00GM17_A107EstadosTipo, P00GM17_A120ProfesionalesId
               }
               , new Object[] {
               P00GM18_A820CapacidadProductivaAuxId
               }
               , new Object[] {
               P00GM20_A40002DepartamentoDepartamento, P00GM20_n40002DepartamentoDepartamento
               }
               , new Object[] {
               P00GM21_A830TablaAuxId
               }
               , new Object[] {
               }
            }
         );
         /* GeneXus formulas. */
      }

      private int GX_INS124 ;
      private int A108EstadosGenericosId ;
      private int GX_INS123 ;
      private long AV14SolXDepto ;
      private long A127SolicitudesID ;
      private long A112DepartamentoId ;
      private long A140RelacionesId ;
      private long AV12DepartamentoIdAnt ;
      private long AV11DepartamentoId ;
      private long A820CapacidadProductivaAuxId ;
      private long A821CapacidadProductivaAuxCant ;
      private long A825CapacidadProductivaAuxDepId ;
      private long AV19CapacidadProductivaAuxDepIdAnt ;
      private long AV18CapacidadProductivaAuxDepId ;
      private long A831TablaAuxDepartamentoId ;
      private long A830TablaAuxId ;
      private decimal AV10Count ;
      private decimal A826CapacidadProductivaAuxPorcent ;
      private decimal A808CapacidadProductivaAuxHoras ;
      private decimal A40000ProfesionalesCapacidadProducti ;
      private decimal AV24ProfesionalesCapacidadProductiva ;
      private decimal c821CapacidadProductivaAuxCant ;
      private decimal A833TablaAuxCapacidadProd ;
      private string A120ProfesionalesId ;
      private string AV9ProfesionalesIdAnt ;
      private string A113DepartamentoDepartamento ;
      private string AV17DepartamentoNombre ;
      private string AV8ProfesionalesID ;
      private string A824CapacidadProductivaAuxProfId ;
      private string A40001DepartamentoDepartamento ;
      private string A832TablaAuxDepartamentoNombre ;
      private string Gx_emsg ;
      private string A107EstadosTipo ;
      private string A834CapacidadProductivaAuxDepNombr ;
      private string A40002DepartamentoDepartamento ;
      private bool n112DepartamentoId ;
      private bool returnInSub ;
      private bool n40000ProfesionalesCapacidadProducti ;
      private bool n40001DepartamentoDepartamento ;
      private bool n40002DepartamentoDepartamento ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private long[] P00GM3_A127SolicitudesID ;
      private string[] P00GM3_A120ProfesionalesId ;
      private long[] P00GM3_A112DepartamentoId ;
      private bool[] P00GM3_n112DepartamentoId ;
      private long[] P00GM3_A140RelacionesId ;
      private long[] P00GM4_A127SolicitudesID ;
      private string[] P00GM4_A120ProfesionalesId ;
      private string[] P00GM4_A113DepartamentoDepartamento ;
      private long[] P00GM4_A112DepartamentoId ;
      private bool[] P00GM4_n112DepartamentoId ;
      private long[] P00GM4_A140RelacionesId ;
      private string[] P00GM5_A824CapacidadProductivaAuxProfId ;
      private long[] P00GM5_A820CapacidadProductivaAuxId ;
      private long[] P00GM6_A821CapacidadProductivaAuxCant ;
      private string[] P00GM6_A824CapacidadProductivaAuxProfId ;
      private long[] P00GM6_A820CapacidadProductivaAuxId ;
      private decimal[] P00GM8_A826CapacidadProductivaAuxPorcent ;
      private decimal[] P00GM8_A808CapacidadProductivaAuxHoras ;
      private string[] P00GM8_A824CapacidadProductivaAuxProfId ;
      private decimal[] P00GM8_A40000ProfesionalesCapacidadProducti ;
      private bool[] P00GM8_n40000ProfesionalesCapacidadProducti ;
      private long[] P00GM8_A820CapacidadProductivaAuxId ;
      private string[] P00GM11_A824CapacidadProductivaAuxProfId ;
      private long[] P00GM11_A825CapacidadProductivaAuxDepId ;
      private long[] P00GM11_A820CapacidadProductivaAuxId ;
      private long[] P00GM12_A821CapacidadProductivaAuxCant ;
      private string[] P00GM12_A824CapacidadProductivaAuxProfId ;
      private long[] P00GM12_A825CapacidadProductivaAuxDepId ;
      private long[] P00GM12_A820CapacidadProductivaAuxId ;
      private long[] P00GM13_A821CapacidadProductivaAuxCant ;
      private string[] P00GM15_A40001DepartamentoDepartamento ;
      private bool[] P00GM15_n40001DepartamentoDepartamento ;
      private long[] P00GM16_A830TablaAuxId ;
      private int[] P00GM17_A108EstadosGenericosId ;
      private string[] P00GM17_A107EstadosTipo ;
      private string[] P00GM17_A120ProfesionalesId ;
      private long[] P00GM18_A820CapacidadProductivaAuxId ;
      private string[] P00GM20_A40002DepartamentoDepartamento ;
      private bool[] P00GM20_n40002DepartamentoDepartamento ;
      private long[] P00GM21_A830TablaAuxId ;
   }

   public class acalcularcapacidadproductivacopy1__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new UpdateCursor(def[0])
         ,new ForEachCursor(def[1])
         ,new ForEachCursor(def[2])
         ,new ForEachCursor(def[3])
         ,new ForEachCursor(def[4])
         ,new ForEachCursor(def[5])
         ,new UpdateCursor(def[6])
         ,new UpdateCursor(def[7])
         ,new ForEachCursor(def[8])
         ,new ForEachCursor(def[9])
         ,new ForEachCursor(def[10])
         ,new ForEachCursor(def[11])
         ,new ForEachCursor(def[12])
         ,new ForEachCursor(def[13])
         ,new ForEachCursor(def[14])
         ,new ForEachCursor(def[15])
         ,new ForEachCursor(def[16])
         ,new UpdateCursor(def[17])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP00GM2;
          prmP00GM2 = new Object[] {
          };
          Object[] prmP00GM3;
          prmP00GM3 = new Object[] {
          };
          Object[] prmP00GM4;
          prmP00GM4 = new Object[] {
          };
          Object[] prmP00GM5;
          prmP00GM5 = new Object[] {
          };
          Object[] prmP00GM6;
          prmP00GM6 = new Object[] {
          };
          Object[] prmP00GM8;
          prmP00GM8 = new Object[] {
          };
          Object[] prmP00GM9;
          prmP00GM9 = new Object[] {
          new ParDef("@CapacidadProductivaAuxHoras",GXType.Decimal,18,2) ,
          new ParDef("@CapacidadProductivaAuxId",GXType.Decimal,18,0)
          };
          Object[] prmP00GM10;
          prmP00GM10 = new Object[] {
          };
          Object[] prmP00GM11;
          prmP00GM11 = new Object[] {
          };
          Object[] prmP00GM12;
          prmP00GM12 = new Object[] {
          };
          Object[] prmP00GM13;
          prmP00GM13 = new Object[] {
          new ParDef("@AV18CapacidadProductivaAuxDepId",GXType.Decimal,18,0)
          };
          Object[] prmP00GM15;
          prmP00GM15 = new Object[] {
          new ParDef("@AV18CapacidadProductivaAuxDepId",GXType.Decimal,18,0)
          };
          Object[] prmP00GM16;
          prmP00GM16 = new Object[] {
          new ParDef("@TablaAuxDepartamentoId",GXType.Decimal,18,0) ,
          new ParDef("@TablaAuxDepartamentoNombre",GXType.NChar,80,0) ,
          new ParDef("@TablaAuxCapacidadProd",GXType.Decimal,18,2)
          };
          Object[] prmP00GM17;
          prmP00GM17 = new Object[] {
          new ParDef("@AV9ProfesionalesIdAnt",GXType.Char,20,0)
          };
          Object[] prmP00GM18;
          prmP00GM18 = new Object[] {
          new ParDef("@CapacidadProductivaAuxCant",GXType.Decimal,12,0) ,
          new ParDef("@CapacidadProductivaAuxProfId",GXType.NChar,20,0) ,
          new ParDef("@CapacidadProductivaAuxDepId",GXType.Decimal,18,0) ,
          new ParDef("@CapacidadProductivaAuxDepNombr",GXType.NChar,80,0)
          };
          Object[] prmP00GM20;
          prmP00GM20 = new Object[] {
          new ParDef("@AV19CapacidadProductivaAuxDepIdAnt",GXType.Decimal,18,0)
          };
          Object[] prmP00GM21;
          prmP00GM21 = new Object[] {
          new ParDef("@TablaAuxDepartamentoId",GXType.Decimal,18,0) ,
          new ParDef("@TablaAuxDepartamentoNombre",GXType.NChar,80,0) ,
          new ParDef("@TablaAuxCapacidadProd",GXType.Decimal,18,2)
          };
          Object[] prmP00GM22;
          prmP00GM22 = new Object[] {
          new ParDef("@AV10Count",GXType.Decimal,18,2) ,
          new ParDef("@AV9ProfesionalesIdAnt",GXType.NChar,20,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00GM2", "DELETE FROM [CapacidadProductivaAux] ", GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP00GM2)
             ,new CursorDef("P00GM3", "SELECT TOP 1 T1.[SolicitudesID], T1.[ProfesionalesId], T2.[DepartamentoId], T1.[RelacionesId] FROM ([Relaciones] T1 INNER JOIN [Solicitudes] T2 ON T2.[SolicitudesID] = T1.[SolicitudesID]) WHERE Not (T1.[ProfesionalesId] = '') ORDER BY T2.[DepartamentoId], T1.[ProfesionalesId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00GM3,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00GM4", "SELECT T1.[SolicitudesID], T1.[ProfesionalesId], T3.[DepartamentoDepartamento], T2.[DepartamentoId], T1.[RelacionesId] FROM (([Relaciones] T1 INNER JOIN [Solicitudes] T2 ON T2.[SolicitudesID] = T1.[SolicitudesID]) LEFT JOIN [Departamento] T3 ON T3.[DepartamentoId] = T2.[DepartamentoId]) WHERE Not (T1.[ProfesionalesId] = '') ORDER BY T2.[DepartamentoId], T1.[ProfesionalesId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00GM4,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00GM5", "SELECT TOP 1 [CapacidadProductivaAuxProfId], [CapacidadProductivaAuxId] FROM [CapacidadProductivaAux] ORDER BY [CapacidadProductivaAuxProfId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00GM5,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00GM6", "SELECT [CapacidadProductivaAuxCant], [CapacidadProductivaAuxProfId], [CapacidadProductivaAuxId] FROM [CapacidadProductivaAux] ORDER BY [CapacidadProductivaAuxProfId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00GM6,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00GM8", "SELECT T1.[CapacidadProductivaAuxPorcent], T1.[CapacidadProductivaAuxHoras], T1.[CapacidadProductivaAuxProfId], COALESCE( T2.[ProfesionalesCapacidadProducti], 0) AS ProfesionalesCapacidadProducti, T1.[CapacidadProductivaAuxId] FROM ([CapacidadProductivaAux] T1 WITH (UPDLOCK) LEFT JOIN (SELECT [ProfesionalesCapacidadProducti] AS ProfesionalesCapacidadProducti, [ProfesionalesId] FROM [Profesionales] ) T2 ON T2.[ProfesionalesId] = T1.[CapacidadProductivaAuxProfId]) ORDER BY T1.[CapacidadProductivaAuxProfId] ",true, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00GM8,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00GM9", "UPDATE [CapacidadProductivaAux] SET [CapacidadProductivaAuxHoras]=@CapacidadProductivaAuxHoras  WHERE [CapacidadProductivaAuxId] = @CapacidadProductivaAuxId", GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP00GM9)
             ,new CursorDef("P00GM10", "DELETE FROM [TablaAux] ", GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP00GM10)
             ,new CursorDef("P00GM11", "SELECT TOP 1 [CapacidadProductivaAuxProfId], [CapacidadProductivaAuxDepId], [CapacidadProductivaAuxId] FROM [CapacidadProductivaAux] ORDER BY [CapacidadProductivaAuxDepId], [CapacidadProductivaAuxProfId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00GM11,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00GM12", "SELECT [CapacidadProductivaAuxCant], [CapacidadProductivaAuxProfId], [CapacidadProductivaAuxDepId], [CapacidadProductivaAuxId] FROM [CapacidadProductivaAux] ORDER BY [CapacidadProductivaAuxDepId], [CapacidadProductivaAuxProfId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00GM12,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00GM13", "SELECT SUM([CapacidadProductivaAuxCant]) FROM [CapacidadProductivaAux] WHERE [CapacidadProductivaAuxDepId] = @AV18CapacidadProductivaAuxDepId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00GM13,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00GM15", "SELECT COALESCE( T1.[DepartamentoDepartamento], '') AS DepartamentoDepartamento FROM (SELECT [DepartamentoDepartamento] AS DepartamentoDepartamento, [DepartamentoId] FROM [Departamento] WHERE [DepartamentoId] = @AV18CapacidadProductivaAuxDepId ) T1 ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00GM15,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00GM16", "INSERT INTO [TablaAux]([TablaAuxDepartamentoId], [TablaAuxDepartamentoNombre], [TablaAuxCapacidadProd]) VALUES(@TablaAuxDepartamentoId, @TablaAuxDepartamentoNombre, @TablaAuxCapacidadProd); SELECT SCOPE_IDENTITY()",false, GxErrorMask.GX_NOMASK, false, this,prmP00GM16,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("P00GM17", "SELECT [EstadosGenericosId], [EstadosTipo], [ProfesionalesId] FROM [Profesionales] WHERE ([ProfesionalesId] = @AV9ProfesionalesIdAnt) AND ([EstadosGenericosId] = 1) ORDER BY [ProfesionalesId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00GM17,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("P00GM18", "INSERT INTO [CapacidadProductivaAux]([CapacidadProductivaAuxCant], [CapacidadProductivaAuxProfId], [CapacidadProductivaAuxDepId], [CapacidadProductivaAuxDepNombr], [CapacidadProductivaAuxPorcent], [CapacidadProductivaAuxHoras], [CapacidadProductivaAuxRubroId]) VALUES(@CapacidadProductivaAuxCant, @CapacidadProductivaAuxProfId, @CapacidadProductivaAuxDepId, @CapacidadProductivaAuxDepNombr, convert(int, 0), convert(int, 0), convert(int, 0)); SELECT SCOPE_IDENTITY()",false, GxErrorMask.GX_NOMASK, false, this,prmP00GM18,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("P00GM20", "SELECT COALESCE( T1.[DepartamentoDepartamento], '') AS DepartamentoDepartamento FROM (SELECT [DepartamentoDepartamento] AS DepartamentoDepartamento, [DepartamentoId] FROM [Departamento] WHERE [DepartamentoId] = @AV19CapacidadProductivaAuxDepIdAnt ) T1 ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00GM20,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00GM21", "INSERT INTO [TablaAux]([TablaAuxDepartamentoId], [TablaAuxDepartamentoNombre], [TablaAuxCapacidadProd]) VALUES(@TablaAuxDepartamentoId, @TablaAuxDepartamentoNombre, @TablaAuxCapacidadProd); SELECT SCOPE_IDENTITY()",false, GxErrorMask.GX_NOMASK, false, this,prmP00GM21,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("P00GM22", "UPDATE [CapacidadProductivaAux] SET [CapacidadProductivaAuxPorcent]=( CAST([CapacidadProductivaAuxCant] AS decimal( 28, 10)) / @AV10Count) * CAST(100 AS decimal( 22, 10))  WHERE [CapacidadProductivaAuxProfId] = @AV9ProfesionalesIdAnt", GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP00GM22)
          };
       }
    }

    public void getResults( int cursor ,
                            IFieldGetter rslt ,
                            Object[] buf )
    {
       switch ( cursor )
       {
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 20);
                ((long[]) buf[2])[0] = rslt.getLong(3);
                ((bool[]) buf[3])[0] = rslt.wasNull(3);
                ((long[]) buf[4])[0] = rslt.getLong(4);
                return;
             case 2 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 20);
                ((string[]) buf[2])[0] = rslt.getString(3, 80);
                ((long[]) buf[3])[0] = rslt.getLong(4);
                ((bool[]) buf[4])[0] = rslt.wasNull(4);
                ((long[]) buf[5])[0] = rslt.getLong(5);
                return;
             case 3 :
                ((string[]) buf[0])[0] = rslt.getString(1, 20);
                ((long[]) buf[1])[0] = rslt.getLong(2);
                return;
             case 4 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 20);
                ((long[]) buf[2])[0] = rslt.getLong(3);
                return;
             case 5 :
                ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
                ((decimal[]) buf[1])[0] = rslt.getDecimal(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 20);
                ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
                ((bool[]) buf[4])[0] = rslt.wasNull(4);
                ((long[]) buf[5])[0] = rslt.getLong(5);
                return;
             case 8 :
                ((string[]) buf[0])[0] = rslt.getString(1, 20);
                ((long[]) buf[1])[0] = rslt.getLong(2);
                ((long[]) buf[2])[0] = rslt.getLong(3);
                return;
             case 9 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 20);
                ((long[]) buf[2])[0] = rslt.getLong(3);
                ((long[]) buf[3])[0] = rslt.getLong(4);
                return;
             case 10 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
             case 11 :
                ((string[]) buf[0])[0] = rslt.getString(1, 80);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 12 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
             case 13 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 3);
                ((string[]) buf[2])[0] = rslt.getString(3, 20);
                return;
             case 14 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
             case 15 :
                ((string[]) buf[0])[0] = rslt.getString(1, 80);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 16 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
       }
    }

 }

}

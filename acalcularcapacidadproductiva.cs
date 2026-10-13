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
   public class acalcularcapacidadproductiva : GXProcedure
   {
      public static int Main( string[] args )
      {
         return new acalcularcapacidadproductiva().MainImpl(args); ;
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

      public acalcularcapacidadproductiva( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public acalcularcapacidadproductiva( IGxContext context )
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
         AV15SolXDepto = 0;
         AV11Count = 0;
         /* Optimized DELETE. */
         /* Using cursor P00GK2 */
         pr_default.execute(0);
         pr_default.close(0);
         pr_default.SmartCacheProvider.SetUpdated("CapacidadProductivaAux");
         /* End optimized DELETE. */
         /* Using cursor P00GK3 */
         pr_default.execute(1);
         while ( (pr_default.getStatus(1) != 101) )
         {
            A127SolicitudesID = P00GK3_A127SolicitudesID[0];
            A120ProfesionalesId = P00GK3_A120ProfesionalesId[0];
            A112DepartamentoId = P00GK3_A112DepartamentoId[0];
            n112DepartamentoId = P00GK3_n112DepartamentoId[0];
            A140RelacionesId = P00GK3_A140RelacionesId[0];
            A112DepartamentoId = P00GK3_A112DepartamentoId[0];
            n112DepartamentoId = P00GK3_n112DepartamentoId[0];
            AV13DepartamentoIdAnt = A112DepartamentoId;
            AV10ProfesionalesIdAnt = A120ProfesionalesId;
            /* Exit For each command. Update data (if necessary), close cursors & exit. */
            if (true) break;
            pr_default.readNext(1);
         }
         pr_default.close(1);
         /* Using cursor P00GK4 */
         pr_default.execute(2);
         while ( (pr_default.getStatus(2) != 101) )
         {
            A127SolicitudesID = P00GK4_A127SolicitudesID[0];
            A120ProfesionalesId = P00GK4_A120ProfesionalesId[0];
            A113DepartamentoDepartamento = P00GK4_A113DepartamentoDepartamento[0];
            A112DepartamentoId = P00GK4_A112DepartamentoId[0];
            n112DepartamentoId = P00GK4_n112DepartamentoId[0];
            A140RelacionesId = P00GK4_A140RelacionesId[0];
            A112DepartamentoId = P00GK4_A112DepartamentoId[0];
            n112DepartamentoId = P00GK4_n112DepartamentoId[0];
            A113DepartamentoDepartamento = P00GK4_A113DepartamentoDepartamento[0];
            AV15SolXDepto = (long)(AV15SolXDepto+1);
            AV12DepartamentoId = A112DepartamentoId;
            AV19DepartamentoNombre = A113DepartamentoDepartamento;
            AV9ProfesionalesID = A120ProfesionalesId;
            if ( ( ( AV12DepartamentoId != AV13DepartamentoIdAnt ) ) || ( ( StringUtil.StrCmp(AV9ProfesionalesID, AV10ProfesionalesIdAnt) != 0 ) ) )
            {
               /* Execute user subroutine: 'REGISTRAR' */
               S111 ();
               if ( returnInSub )
               {
                  pr_default.close(2);
                  cleanup();
                  if (true) return;
               }
               AV13DepartamentoIdAnt = AV12DepartamentoId;
               AV10ProfesionalesIdAnt = AV9ProfesionalesID;
               AV15SolXDepto = 0;
            }
            pr_default.readNext(2);
         }
         pr_default.close(2);
         /* Using cursor P00GK5 */
         pr_default.execute(3);
         while ( (pr_default.getStatus(3) != 101) )
         {
            A824CapacidadProductivaAuxProfId = P00GK5_A824CapacidadProductivaAuxProfId[0];
            A820CapacidadProductivaAuxId = P00GK5_A820CapacidadProductivaAuxId[0];
            AV10ProfesionalesIdAnt = A824CapacidadProductivaAuxProfId;
            /* Exit For each command. Update data (if necessary), close cursors & exit. */
            if (true) break;
            pr_default.readNext(3);
         }
         pr_default.close(3);
         /* Using cursor P00GK6 */
         pr_default.execute(4);
         while ( (pr_default.getStatus(4) != 101) )
         {
            A821CapacidadProductivaAuxCant = P00GK6_A821CapacidadProductivaAuxCant[0];
            A824CapacidadProductivaAuxProfId = P00GK6_A824CapacidadProductivaAuxProfId[0];
            A820CapacidadProductivaAuxId = P00GK6_A820CapacidadProductivaAuxId[0];
            AV9ProfesionalesID = StringUtil.Trim( A824CapacidadProductivaAuxProfId);
            if ( StringUtil.StrCmp(AV9ProfesionalesID, AV10ProfesionalesIdAnt) != 0 )
            {
               /* Execute user subroutine: 'UPDATEPORCENT' */
               S131 ();
               if ( returnInSub )
               {
                  pr_default.close(4);
                  cleanup();
                  if (true) return;
               }
               AV11Count = 0;
               AV10ProfesionalesIdAnt = AV9ProfesionalesID;
            }
            AV11Count = (decimal)(AV11Count+A821CapacidadProductivaAuxCant);
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
         /* Using cursor P00GK8 */
         pr_default.execute(5);
         while ( (pr_default.getStatus(5) != 101) )
         {
            A826CapacidadProductivaAuxPorcent = P00GK8_A826CapacidadProductivaAuxPorcent[0];
            A808CapacidadProductivaAuxHoras = P00GK8_A808CapacidadProductivaAuxHoras[0];
            A824CapacidadProductivaAuxProfId = P00GK8_A824CapacidadProductivaAuxProfId[0];
            A40000ProfesionalesCapacidadProducti = P00GK8_A40000ProfesionalesCapacidadProducti[0];
            n40000ProfesionalesCapacidadProducti = P00GK8_n40000ProfesionalesCapacidadProducti[0];
            A820CapacidadProductivaAuxId = P00GK8_A820CapacidadProductivaAuxId[0];
            A40000ProfesionalesCapacidadProducti = P00GK8_A40000ProfesionalesCapacidadProducti[0];
            n40000ProfesionalesCapacidadProducti = P00GK8_n40000ProfesionalesCapacidadProducti[0];
            AV18ProfesionalesCapacidadProductiva = A40000ProfesionalesCapacidadProducti;
            A808CapacidadProductivaAuxHoras = (decimal)(AV18ProfesionalesCapacidadProductiva*(A826CapacidadProductivaAuxPorcent/ (decimal)(100)));
            /* Using cursor P00GK9 */
            pr_default.execute(6, new Object[] {A808CapacidadProductivaAuxHoras, A820CapacidadProductivaAuxId});
            pr_default.close(6);
            pr_default.SmartCacheProvider.SetUpdated("CapacidadProductivaAux");
            pr_default.readNext(5);
         }
         pr_default.close(5);
         /* Optimized DELETE. */
         /* Using cursor P00GK10 */
         pr_default.execute(7);
         pr_default.close(7);
         pr_default.SmartCacheProvider.SetUpdated("TablaAux");
         /* End optimized DELETE. */
         /* Using cursor P00GK11 */
         pr_default.execute(8);
         while ( (pr_default.getStatus(8) != 101) )
         {
            A824CapacidadProductivaAuxProfId = P00GK11_A824CapacidadProductivaAuxProfId[0];
            A825CapacidadProductivaAuxDepId = P00GK11_A825CapacidadProductivaAuxDepId[0];
            A820CapacidadProductivaAuxId = P00GK11_A820CapacidadProductivaAuxId[0];
            AV21CapacidadProductivaAuxDepIdAnt = A825CapacidadProductivaAuxDepId;
            /* Exit For each command. Update data (if necessary), close cursors & exit. */
            if (true) break;
            pr_default.readNext(8);
         }
         pr_default.close(8);
         AV11Count = 0;
         /* Using cursor P00GK12 */
         pr_default.execute(9);
         while ( (pr_default.getStatus(9) != 101) )
         {
            A821CapacidadProductivaAuxCant = P00GK12_A821CapacidadProductivaAuxCant[0];
            A824CapacidadProductivaAuxProfId = P00GK12_A824CapacidadProductivaAuxProfId[0];
            A825CapacidadProductivaAuxDepId = P00GK12_A825CapacidadProductivaAuxDepId[0];
            A820CapacidadProductivaAuxId = P00GK12_A820CapacidadProductivaAuxId[0];
            AV20CapacidadProductivaAuxDepId = A825CapacidadProductivaAuxDepId;
            if ( AV20CapacidadProductivaAuxDepId != AV21CapacidadProductivaAuxDepIdAnt )
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
            AV11Count = (decimal)(AV11Count+A821CapacidadProductivaAuxCant);
            pr_default.readNext(9);
         }
         pr_default.close(9);
         AV11Count = 0;
         /* Optimized group. */
         /* Using cursor P00GK13 */
         pr_default.execute(10, new Object[] {AV20CapacidadProductivaAuxDepId});
         c821CapacidadProductivaAuxCant = (decimal)(P00GK13_A821CapacidadProductivaAuxCant[0]);
         pr_default.close(10);
         AV11Count = (decimal)(AV11Count+c821CapacidadProductivaAuxCant);
         /* End optimized group. */
         /*
            INSERT RECORD ON TABLE TablaAux

         */
         /* Using cursor P00GK15 */
         pr_default.execute(11, new Object[] {AV20CapacidadProductivaAuxDepId});
         if ( (pr_default.getStatus(11) != 101) )
         {
            A40001DepartamentoDepartamento = P00GK15_A40001DepartamentoDepartamento[0];
            n40001DepartamentoDepartamento = P00GK15_n40001DepartamentoDepartamento[0];
         }
         else
         {
            A40001DepartamentoDepartamento = "";
            n40001DepartamentoDepartamento = false;
         }
         pr_default.close(11);
         A831TablaAuxDepartamentoId = AV20CapacidadProductivaAuxDepId;
         A832TablaAuxDepartamentoNombre = A40001DepartamentoDepartamento;
         A833TablaAuxCapacidadProd = AV11Count;
         /* Using cursor P00GK16 */
         pr_default.execute(12, new Object[] {A831TablaAuxDepartamentoId, A832TablaAuxDepartamentoNombre, A833TablaAuxCapacidadProd});
         A830TablaAuxId = P00GK16_A830TablaAuxId[0];
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
         /* Using cursor P00GK17 */
         pr_default.execute(13, new Object[] {AV10ProfesionalesIdAnt});
         while ( (pr_default.getStatus(13) != 101) )
         {
            A108EstadosGenericosId = P00GK17_A108EstadosGenericosId[0];
            A107EstadosTipo = P00GK17_A107EstadosTipo[0];
            A120ProfesionalesId = P00GK17_A120ProfesionalesId[0];
            if ( StringUtil.StrCmp(A107EstadosTipo, context.GetMessage( "STS", "")) == 0 )
            {
               /*
                  INSERT RECORD ON TABLE CapacidadProductivaAux

               */
               A824CapacidadProductivaAuxProfId = AV10ProfesionalesIdAnt;
               A825CapacidadProductivaAuxDepId = AV13DepartamentoIdAnt;
               A821CapacidadProductivaAuxCant = AV15SolXDepto;
               A834CapacidadProductivaAuxDepNombr = AV19DepartamentoNombre;
               /* Using cursor P00GK18 */
               pr_default.execute(14, new Object[] {A821CapacidadProductivaAuxCant, A824CapacidadProductivaAuxProfId, A825CapacidadProductivaAuxDepId, A834CapacidadProductivaAuxDepNombr});
               A820CapacidadProductivaAuxId = P00GK18_A820CapacidadProductivaAuxId[0];
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
         /* Using cursor P00GK20 */
         pr_default.execute(15, new Object[] {AV21CapacidadProductivaAuxDepIdAnt});
         if ( (pr_default.getStatus(15) != 101) )
         {
            A40002DepartamentoDepartamento = P00GK20_A40002DepartamentoDepartamento[0];
            n40002DepartamentoDepartamento = P00GK20_n40002DepartamentoDepartamento[0];
         }
         else
         {
            A40002DepartamentoDepartamento = "";
            n40002DepartamentoDepartamento = false;
         }
         pr_default.close(15);
         A831TablaAuxDepartamentoId = AV21CapacidadProductivaAuxDepIdAnt;
         A832TablaAuxDepartamentoNombre = A40002DepartamentoDepartamento;
         A833TablaAuxCapacidadProd = AV11Count;
         AV11Count = 0;
         AV21CapacidadProductivaAuxDepIdAnt = AV20CapacidadProductivaAuxDepId;
         /* Using cursor P00GK21 */
         pr_default.execute(16, new Object[] {A831TablaAuxDepartamentoId, A832TablaAuxDepartamentoNombre, A833TablaAuxCapacidadProd});
         A830TablaAuxId = P00GK21_A830TablaAuxId[0];
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
         /* Using cursor P00GK22 */
         pr_default.execute(17, new Object[] {AV11Count, AV10ProfesionalesIdAnt});
         pr_default.close(17);
         pr_default.SmartCacheProvider.SetUpdated("CapacidadProductivaAux");
         /* End optimized UPDATE. */
      }

      public override void cleanup( )
      {
         context.CommitDataStores("calcularcapacidadproductiva",pr_default);
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
         P00GK3_A127SolicitudesID = new long[1] ;
         P00GK3_A120ProfesionalesId = new string[] {""} ;
         P00GK3_A112DepartamentoId = new long[1] ;
         P00GK3_n112DepartamentoId = new bool[] {false} ;
         P00GK3_A140RelacionesId = new long[1] ;
         A120ProfesionalesId = "";
         AV10ProfesionalesIdAnt = "";
         P00GK4_A127SolicitudesID = new long[1] ;
         P00GK4_A120ProfesionalesId = new string[] {""} ;
         P00GK4_A113DepartamentoDepartamento = new string[] {""} ;
         P00GK4_A112DepartamentoId = new long[1] ;
         P00GK4_n112DepartamentoId = new bool[] {false} ;
         P00GK4_A140RelacionesId = new long[1] ;
         A113DepartamentoDepartamento = "";
         AV19DepartamentoNombre = "";
         AV9ProfesionalesID = "";
         P00GK5_A824CapacidadProductivaAuxProfId = new string[] {""} ;
         P00GK5_A820CapacidadProductivaAuxId = new long[1] ;
         A824CapacidadProductivaAuxProfId = "";
         P00GK6_A821CapacidadProductivaAuxCant = new long[1] ;
         P00GK6_A824CapacidadProductivaAuxProfId = new string[] {""} ;
         P00GK6_A820CapacidadProductivaAuxId = new long[1] ;
         P00GK8_A826CapacidadProductivaAuxPorcent = new decimal[1] ;
         P00GK8_A808CapacidadProductivaAuxHoras = new decimal[1] ;
         P00GK8_A824CapacidadProductivaAuxProfId = new string[] {""} ;
         P00GK8_A40000ProfesionalesCapacidadProducti = new decimal[1] ;
         P00GK8_n40000ProfesionalesCapacidadProducti = new bool[] {false} ;
         P00GK8_A820CapacidadProductivaAuxId = new long[1] ;
         P00GK11_A824CapacidadProductivaAuxProfId = new string[] {""} ;
         P00GK11_A825CapacidadProductivaAuxDepId = new long[1] ;
         P00GK11_A820CapacidadProductivaAuxId = new long[1] ;
         P00GK12_A821CapacidadProductivaAuxCant = new long[1] ;
         P00GK12_A824CapacidadProductivaAuxProfId = new string[] {""} ;
         P00GK12_A825CapacidadProductivaAuxDepId = new long[1] ;
         P00GK12_A820CapacidadProductivaAuxId = new long[1] ;
         P00GK13_A821CapacidadProductivaAuxCant = new long[1] ;
         P00GK15_A40001DepartamentoDepartamento = new string[] {""} ;
         P00GK15_n40001DepartamentoDepartamento = new bool[] {false} ;
         A40001DepartamentoDepartamento = "";
         A832TablaAuxDepartamentoNombre = "";
         P00GK16_A830TablaAuxId = new long[1] ;
         Gx_emsg = "";
         P00GK17_A108EstadosGenericosId = new int[1] ;
         P00GK17_A107EstadosTipo = new string[] {""} ;
         P00GK17_A120ProfesionalesId = new string[] {""} ;
         A107EstadosTipo = "";
         A834CapacidadProductivaAuxDepNombr = "";
         P00GK18_A820CapacidadProductivaAuxId = new long[1] ;
         P00GK20_A40002DepartamentoDepartamento = new string[] {""} ;
         P00GK20_n40002DepartamentoDepartamento = new bool[] {false} ;
         A40002DepartamentoDepartamento = "";
         P00GK21_A830TablaAuxId = new long[1] ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.acalcularcapacidadproductiva__default(),
            new Object[][] {
                new Object[] {
               }
               , new Object[] {
               P00GK3_A127SolicitudesID, P00GK3_A120ProfesionalesId, P00GK3_A112DepartamentoId, P00GK3_n112DepartamentoId, P00GK3_A140RelacionesId
               }
               , new Object[] {
               P00GK4_A127SolicitudesID, P00GK4_A120ProfesionalesId, P00GK4_A113DepartamentoDepartamento, P00GK4_A112DepartamentoId, P00GK4_n112DepartamentoId, P00GK4_A140RelacionesId
               }
               , new Object[] {
               P00GK5_A824CapacidadProductivaAuxProfId, P00GK5_A820CapacidadProductivaAuxId
               }
               , new Object[] {
               P00GK6_A821CapacidadProductivaAuxCant, P00GK6_A824CapacidadProductivaAuxProfId, P00GK6_A820CapacidadProductivaAuxId
               }
               , new Object[] {
               P00GK8_A826CapacidadProductivaAuxPorcent, P00GK8_A808CapacidadProductivaAuxHoras, P00GK8_A824CapacidadProductivaAuxProfId, P00GK8_A40000ProfesionalesCapacidadProducti, P00GK8_n40000ProfesionalesCapacidadProducti, P00GK8_A820CapacidadProductivaAuxId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               P00GK11_A824CapacidadProductivaAuxProfId, P00GK11_A825CapacidadProductivaAuxDepId, P00GK11_A820CapacidadProductivaAuxId
               }
               , new Object[] {
               P00GK12_A821CapacidadProductivaAuxCant, P00GK12_A824CapacidadProductivaAuxProfId, P00GK12_A825CapacidadProductivaAuxDepId, P00GK12_A820CapacidadProductivaAuxId
               }
               , new Object[] {
               P00GK13_A821CapacidadProductivaAuxCant
               }
               , new Object[] {
               P00GK15_A40001DepartamentoDepartamento, P00GK15_n40001DepartamentoDepartamento
               }
               , new Object[] {
               P00GK16_A830TablaAuxId
               }
               , new Object[] {
               P00GK17_A108EstadosGenericosId, P00GK17_A107EstadosTipo, P00GK17_A120ProfesionalesId
               }
               , new Object[] {
               P00GK18_A820CapacidadProductivaAuxId
               }
               , new Object[] {
               P00GK20_A40002DepartamentoDepartamento, P00GK20_n40002DepartamentoDepartamento
               }
               , new Object[] {
               P00GK21_A830TablaAuxId
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
      private long AV15SolXDepto ;
      private long A127SolicitudesID ;
      private long A112DepartamentoId ;
      private long A140RelacionesId ;
      private long AV13DepartamentoIdAnt ;
      private long AV12DepartamentoId ;
      private long A820CapacidadProductivaAuxId ;
      private long A821CapacidadProductivaAuxCant ;
      private long A825CapacidadProductivaAuxDepId ;
      private long AV21CapacidadProductivaAuxDepIdAnt ;
      private long AV20CapacidadProductivaAuxDepId ;
      private long A831TablaAuxDepartamentoId ;
      private long A830TablaAuxId ;
      private decimal AV11Count ;
      private decimal A826CapacidadProductivaAuxPorcent ;
      private decimal A808CapacidadProductivaAuxHoras ;
      private decimal A40000ProfesionalesCapacidadProducti ;
      private decimal AV18ProfesionalesCapacidadProductiva ;
      private decimal c821CapacidadProductivaAuxCant ;
      private decimal A833TablaAuxCapacidadProd ;
      private string A120ProfesionalesId ;
      private string AV10ProfesionalesIdAnt ;
      private string A113DepartamentoDepartamento ;
      private string AV19DepartamentoNombre ;
      private string AV9ProfesionalesID ;
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
      private long[] P00GK3_A127SolicitudesID ;
      private string[] P00GK3_A120ProfesionalesId ;
      private long[] P00GK3_A112DepartamentoId ;
      private bool[] P00GK3_n112DepartamentoId ;
      private long[] P00GK3_A140RelacionesId ;
      private long[] P00GK4_A127SolicitudesID ;
      private string[] P00GK4_A120ProfesionalesId ;
      private string[] P00GK4_A113DepartamentoDepartamento ;
      private long[] P00GK4_A112DepartamentoId ;
      private bool[] P00GK4_n112DepartamentoId ;
      private long[] P00GK4_A140RelacionesId ;
      private string[] P00GK5_A824CapacidadProductivaAuxProfId ;
      private long[] P00GK5_A820CapacidadProductivaAuxId ;
      private long[] P00GK6_A821CapacidadProductivaAuxCant ;
      private string[] P00GK6_A824CapacidadProductivaAuxProfId ;
      private long[] P00GK6_A820CapacidadProductivaAuxId ;
      private decimal[] P00GK8_A826CapacidadProductivaAuxPorcent ;
      private decimal[] P00GK8_A808CapacidadProductivaAuxHoras ;
      private string[] P00GK8_A824CapacidadProductivaAuxProfId ;
      private decimal[] P00GK8_A40000ProfesionalesCapacidadProducti ;
      private bool[] P00GK8_n40000ProfesionalesCapacidadProducti ;
      private long[] P00GK8_A820CapacidadProductivaAuxId ;
      private string[] P00GK11_A824CapacidadProductivaAuxProfId ;
      private long[] P00GK11_A825CapacidadProductivaAuxDepId ;
      private long[] P00GK11_A820CapacidadProductivaAuxId ;
      private long[] P00GK12_A821CapacidadProductivaAuxCant ;
      private string[] P00GK12_A824CapacidadProductivaAuxProfId ;
      private long[] P00GK12_A825CapacidadProductivaAuxDepId ;
      private long[] P00GK12_A820CapacidadProductivaAuxId ;
      private long[] P00GK13_A821CapacidadProductivaAuxCant ;
      private string[] P00GK15_A40001DepartamentoDepartamento ;
      private bool[] P00GK15_n40001DepartamentoDepartamento ;
      private long[] P00GK16_A830TablaAuxId ;
      private int[] P00GK17_A108EstadosGenericosId ;
      private string[] P00GK17_A107EstadosTipo ;
      private string[] P00GK17_A120ProfesionalesId ;
      private long[] P00GK18_A820CapacidadProductivaAuxId ;
      private string[] P00GK20_A40002DepartamentoDepartamento ;
      private bool[] P00GK20_n40002DepartamentoDepartamento ;
      private long[] P00GK21_A830TablaAuxId ;
   }

   public class acalcularcapacidadproductiva__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP00GK2;
          prmP00GK2 = new Object[] {
          };
          Object[] prmP00GK3;
          prmP00GK3 = new Object[] {
          };
          Object[] prmP00GK4;
          prmP00GK4 = new Object[] {
          };
          Object[] prmP00GK5;
          prmP00GK5 = new Object[] {
          };
          Object[] prmP00GK6;
          prmP00GK6 = new Object[] {
          };
          Object[] prmP00GK8;
          prmP00GK8 = new Object[] {
          };
          Object[] prmP00GK9;
          prmP00GK9 = new Object[] {
          new ParDef("@CapacidadProductivaAuxHoras",GXType.Decimal,18,2) ,
          new ParDef("@CapacidadProductivaAuxId",GXType.Decimal,18,0)
          };
          Object[] prmP00GK10;
          prmP00GK10 = new Object[] {
          };
          Object[] prmP00GK11;
          prmP00GK11 = new Object[] {
          };
          Object[] prmP00GK12;
          prmP00GK12 = new Object[] {
          };
          Object[] prmP00GK13;
          prmP00GK13 = new Object[] {
          new ParDef("@AV20CapacidadProductivaAuxDepId",GXType.Decimal,18,0)
          };
          Object[] prmP00GK15;
          prmP00GK15 = new Object[] {
          new ParDef("@AV20CapacidadProductivaAuxDepId",GXType.Decimal,18,0)
          };
          Object[] prmP00GK16;
          prmP00GK16 = new Object[] {
          new ParDef("@TablaAuxDepartamentoId",GXType.Decimal,18,0) ,
          new ParDef("@TablaAuxDepartamentoNombre",GXType.NChar,80,0) ,
          new ParDef("@TablaAuxCapacidadProd",GXType.Decimal,18,2)
          };
          Object[] prmP00GK17;
          prmP00GK17 = new Object[] {
          new ParDef("@AV10ProfesionalesIdAnt",GXType.Char,20,0)
          };
          Object[] prmP00GK18;
          prmP00GK18 = new Object[] {
          new ParDef("@CapacidadProductivaAuxCant",GXType.Decimal,12,0) ,
          new ParDef("@CapacidadProductivaAuxProfId",GXType.NChar,20,0) ,
          new ParDef("@CapacidadProductivaAuxDepId",GXType.Decimal,18,0) ,
          new ParDef("@CapacidadProductivaAuxDepNombr",GXType.NChar,80,0)
          };
          Object[] prmP00GK20;
          prmP00GK20 = new Object[] {
          new ParDef("@AV21CapacidadProductivaAuxDepIdAnt",GXType.Decimal,18,0)
          };
          Object[] prmP00GK21;
          prmP00GK21 = new Object[] {
          new ParDef("@TablaAuxDepartamentoId",GXType.Decimal,18,0) ,
          new ParDef("@TablaAuxDepartamentoNombre",GXType.NChar,80,0) ,
          new ParDef("@TablaAuxCapacidadProd",GXType.Decimal,18,2)
          };
          Object[] prmP00GK22;
          prmP00GK22 = new Object[] {
          new ParDef("@AV11Count",GXType.Decimal,18,2) ,
          new ParDef("@AV10ProfesionalesIdAnt",GXType.NChar,20,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00GK2", "DELETE FROM [CapacidadProductivaAux] ", GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP00GK2)
             ,new CursorDef("P00GK3", "SELECT TOP 1 T1.[SolicitudesID], T1.[ProfesionalesId], T2.[DepartamentoId], T1.[RelacionesId] FROM ([Relaciones] T1 INNER JOIN [Solicitudes] T2 ON T2.[SolicitudesID] = T1.[SolicitudesID]) WHERE Not (T1.[ProfesionalesId] = '') ORDER BY T2.[DepartamentoId], T1.[ProfesionalesId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00GK3,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00GK4", "SELECT T1.[SolicitudesID], T1.[ProfesionalesId], T3.[DepartamentoDepartamento], T2.[DepartamentoId], T1.[RelacionesId] FROM (([Relaciones] T1 INNER JOIN [Solicitudes] T2 ON T2.[SolicitudesID] = T1.[SolicitudesID]) LEFT JOIN [Departamento] T3 ON T3.[DepartamentoId] = T2.[DepartamentoId]) WHERE Not (T1.[ProfesionalesId] = '') ORDER BY T2.[DepartamentoId], T1.[ProfesionalesId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00GK4,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00GK5", "SELECT TOP 1 [CapacidadProductivaAuxProfId], [CapacidadProductivaAuxId] FROM [CapacidadProductivaAux] ORDER BY [CapacidadProductivaAuxProfId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00GK5,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00GK6", "SELECT [CapacidadProductivaAuxCant], [CapacidadProductivaAuxProfId], [CapacidadProductivaAuxId] FROM [CapacidadProductivaAux] ORDER BY [CapacidadProductivaAuxProfId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00GK6,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00GK8", "SELECT T1.[CapacidadProductivaAuxPorcent], T1.[CapacidadProductivaAuxHoras], T1.[CapacidadProductivaAuxProfId], COALESCE( T2.[ProfesionalesCapacidadProducti], 0) AS ProfesionalesCapacidadProducti, T1.[CapacidadProductivaAuxId] FROM ([CapacidadProductivaAux] T1 WITH (UPDLOCK) LEFT JOIN (SELECT [ProfesionalesCapacidadProducti] AS ProfesionalesCapacidadProducti, [ProfesionalesId] FROM [Profesionales] ) T2 ON T2.[ProfesionalesId] = T1.[CapacidadProductivaAuxProfId]) ORDER BY T1.[CapacidadProductivaAuxProfId] ",true, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00GK8,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00GK9", "UPDATE [CapacidadProductivaAux] SET [CapacidadProductivaAuxHoras]=@CapacidadProductivaAuxHoras  WHERE [CapacidadProductivaAuxId] = @CapacidadProductivaAuxId", GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP00GK9)
             ,new CursorDef("P00GK10", "DELETE FROM [TablaAux] ", GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP00GK10)
             ,new CursorDef("P00GK11", "SELECT TOP 1 [CapacidadProductivaAuxProfId], [CapacidadProductivaAuxDepId], [CapacidadProductivaAuxId] FROM [CapacidadProductivaAux] ORDER BY [CapacidadProductivaAuxDepId], [CapacidadProductivaAuxProfId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00GK11,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00GK12", "SELECT [CapacidadProductivaAuxCant], [CapacidadProductivaAuxProfId], [CapacidadProductivaAuxDepId], [CapacidadProductivaAuxId] FROM [CapacidadProductivaAux] ORDER BY [CapacidadProductivaAuxDepId], [CapacidadProductivaAuxProfId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00GK12,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00GK13", "SELECT SUM([CapacidadProductivaAuxCant]) FROM [CapacidadProductivaAux] WHERE [CapacidadProductivaAuxDepId] = @AV20CapacidadProductivaAuxDepId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00GK13,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00GK15", "SELECT COALESCE( T1.[DepartamentoDepartamento], '') AS DepartamentoDepartamento FROM (SELECT [DepartamentoDepartamento] AS DepartamentoDepartamento, [DepartamentoId] FROM [Departamento] WHERE [DepartamentoId] = @AV20CapacidadProductivaAuxDepId ) T1 ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00GK15,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00GK16", "INSERT INTO [TablaAux]([TablaAuxDepartamentoId], [TablaAuxDepartamentoNombre], [TablaAuxCapacidadProd]) VALUES(@TablaAuxDepartamentoId, @TablaAuxDepartamentoNombre, @TablaAuxCapacidadProd); SELECT SCOPE_IDENTITY()",false, GxErrorMask.GX_NOMASK, false, this,prmP00GK16,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("P00GK17", "SELECT [EstadosGenericosId], [EstadosTipo], [ProfesionalesId] FROM [Profesionales] WHERE ([ProfesionalesId] = @AV10ProfesionalesIdAnt) AND ([EstadosGenericosId] = 1) ORDER BY [ProfesionalesId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00GK17,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("P00GK18", "INSERT INTO [CapacidadProductivaAux]([CapacidadProductivaAuxCant], [CapacidadProductivaAuxProfId], [CapacidadProductivaAuxDepId], [CapacidadProductivaAuxDepNombr], [CapacidadProductivaAuxPorcent], [CapacidadProductivaAuxHoras], [CapacidadProductivaAuxRubroId]) VALUES(@CapacidadProductivaAuxCant, @CapacidadProductivaAuxProfId, @CapacidadProductivaAuxDepId, @CapacidadProductivaAuxDepNombr, convert(int, 0), convert(int, 0), convert(int, 0)); SELECT SCOPE_IDENTITY()",false, GxErrorMask.GX_NOMASK, false, this,prmP00GK18,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("P00GK20", "SELECT COALESCE( T1.[DepartamentoDepartamento], '') AS DepartamentoDepartamento FROM (SELECT [DepartamentoDepartamento] AS DepartamentoDepartamento, [DepartamentoId] FROM [Departamento] WHERE [DepartamentoId] = @AV21CapacidadProductivaAuxDepIdAnt ) T1 ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00GK20,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00GK21", "INSERT INTO [TablaAux]([TablaAuxDepartamentoId], [TablaAuxDepartamentoNombre], [TablaAuxCapacidadProd]) VALUES(@TablaAuxDepartamentoId, @TablaAuxDepartamentoNombre, @TablaAuxCapacidadProd); SELECT SCOPE_IDENTITY()",false, GxErrorMask.GX_NOMASK, false, this,prmP00GK21,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("P00GK22", "UPDATE [CapacidadProductivaAux] SET [CapacidadProductivaAuxPorcent]=( CAST([CapacidadProductivaAuxCant] AS decimal( 28, 10)) / @AV11Count) * CAST(100 AS decimal( 22, 10))  WHERE [CapacidadProductivaAuxProfId] = @AV10ProfesionalesIdAnt", GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP00GK22)
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

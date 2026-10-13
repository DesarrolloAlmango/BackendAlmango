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
   public class oestadisticasprof : GXProcedure
   {
      public oestadisticasprof( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public oestadisticasprof( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_User ,
                           string aP1_ProfesionalesId ,
                           out short aP2_SolDisponibles ,
                           out short aP3_SolAceptadas ,
                           out short aP4_SolCalificadas ,
                           out short aP5_SolFinalizadas ,
                           out short aP6_SolCanceladas ,
                           out short aP7_SolDelegadas ,
                           out short aP8_SolGarantias ,
                           out decimal aP9_FeedbackProm ,
                           out GXBaseCollection<GeneXus.Programs.apis.SdtSDTCantSolRubro> aP10_SDTCantSolRubro ,
                           out string aP11_RestMessage ,
                           out short aP12_Gx_restcode )
      {
         this.AV25User = aP0_User;
         this.AV12ProfesionalesId = aP1_ProfesionalesId;
         this.AV20SolDisponibles = 0 ;
         this.AV16SolAceptadas = 0 ;
         this.AV17SolCalificadas = 0 ;
         this.AV21SolFinalizadas = 0 ;
         this.AV18SolCanceladas = 0 ;
         this.AV19SolDelegadas = 0 ;
         this.AV22SolGarantias = 0 ;
         this.AV10FeedbackProm = 0 ;
         this.AV14SDTCantSolRubro = new GXBaseCollection<GeneXus.Programs.apis.SdtSDTCantSolRubro>( context, "SDTCantSolRubro", "AlmangoX") ;
         this.AV13RestMessage = "" ;
         this.Gx_restcode = 0 ;
         initialize();
         ExecutePrivate();
         aP2_SolDisponibles=this.AV20SolDisponibles;
         aP3_SolAceptadas=this.AV16SolAceptadas;
         aP4_SolCalificadas=this.AV17SolCalificadas;
         aP5_SolFinalizadas=this.AV21SolFinalizadas;
         aP6_SolCanceladas=this.AV18SolCanceladas;
         aP7_SolDelegadas=this.AV19SolDelegadas;
         aP8_SolGarantias=this.AV22SolGarantias;
         aP9_FeedbackProm=this.AV10FeedbackProm;
         aP10_SDTCantSolRubro=this.AV14SDTCantSolRubro;
         aP11_RestMessage=this.AV13RestMessage;
         aP12_Gx_restcode=this.Gx_restcode;
      }

      public short executeUdp( string aP0_User ,
                               string aP1_ProfesionalesId ,
                               out short aP2_SolDisponibles ,
                               out short aP3_SolAceptadas ,
                               out short aP4_SolCalificadas ,
                               out short aP5_SolFinalizadas ,
                               out short aP6_SolCanceladas ,
                               out short aP7_SolDelegadas ,
                               out short aP8_SolGarantias ,
                               out decimal aP9_FeedbackProm ,
                               out GXBaseCollection<GeneXus.Programs.apis.SdtSDTCantSolRubro> aP10_SDTCantSolRubro ,
                               out string aP11_RestMessage )
      {
         execute(aP0_User, aP1_ProfesionalesId, out aP2_SolDisponibles, out aP3_SolAceptadas, out aP4_SolCalificadas, out aP5_SolFinalizadas, out aP6_SolCanceladas, out aP7_SolDelegadas, out aP8_SolGarantias, out aP9_FeedbackProm, out aP10_SDTCantSolRubro, out aP11_RestMessage, out aP12_Gx_restcode);
         return Gx_restcode ;
      }

      public void executeSubmit( string aP0_User ,
                                 string aP1_ProfesionalesId ,
                                 out short aP2_SolDisponibles ,
                                 out short aP3_SolAceptadas ,
                                 out short aP4_SolCalificadas ,
                                 out short aP5_SolFinalizadas ,
                                 out short aP6_SolCanceladas ,
                                 out short aP7_SolDelegadas ,
                                 out short aP8_SolGarantias ,
                                 out decimal aP9_FeedbackProm ,
                                 out GXBaseCollection<GeneXus.Programs.apis.SdtSDTCantSolRubro> aP10_SDTCantSolRubro ,
                                 out string aP11_RestMessage ,
                                 out short aP12_Gx_restcode )
      {
         this.AV25User = aP0_User;
         this.AV12ProfesionalesId = aP1_ProfesionalesId;
         this.AV20SolDisponibles = 0 ;
         this.AV16SolAceptadas = 0 ;
         this.AV17SolCalificadas = 0 ;
         this.AV21SolFinalizadas = 0 ;
         this.AV18SolCanceladas = 0 ;
         this.AV19SolDelegadas = 0 ;
         this.AV22SolGarantias = 0 ;
         this.AV10FeedbackProm = 0 ;
         this.AV14SDTCantSolRubro = new GXBaseCollection<GeneXus.Programs.apis.SdtSDTCantSolRubro>( context, "SDTCantSolRubro", "AlmangoX") ;
         this.AV13RestMessage = "" ;
         this.Gx_restcode = 0 ;
         SubmitImpl();
         aP2_SolDisponibles=this.AV20SolDisponibles;
         aP3_SolAceptadas=this.AV16SolAceptadas;
         aP4_SolCalificadas=this.AV17SolCalificadas;
         aP5_SolFinalizadas=this.AV21SolFinalizadas;
         aP6_SolCanceladas=this.AV18SolCanceladas;
         aP7_SolDelegadas=this.AV19SolDelegadas;
         aP8_SolGarantias=this.AV22SolGarantias;
         aP9_FeedbackProm=this.AV10FeedbackProm;
         aP10_SDTCantSolRubro=this.AV14SDTCantSolRubro;
         aP11_RestMessage=this.AV13RestMessage;
         aP12_Gx_restcode=this.Gx_restcode;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         /* Using cursor P00JI3 */
         pr_default.execute(0);
         if ( (pr_default.getStatus(0) != 101) )
         {
            A40000GXC1 = P00JI3_A40000GXC1[0];
            n40000GXC1 = P00JI3_n40000GXC1[0];
         }
         else
         {
            A40000GXC1 = 0;
            n40000GXC1 = false;
         }
         pr_default.close(0);
         /* Using cursor P00JI5 */
         pr_default.execute(1, new Object[] {AV12ProfesionalesId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            A40001GXC2 = P00JI5_A40001GXC2[0];
            n40001GXC2 = P00JI5_n40001GXC2[0];
         }
         else
         {
            A40001GXC2 = 0;
            n40001GXC2 = false;
         }
         pr_default.close(1);
         /* Using cursor P00JI7 */
         pr_default.execute(2, new Object[] {AV12ProfesionalesId});
         if ( (pr_default.getStatus(2) != 101) )
         {
            A40002GXC3 = P00JI7_A40002GXC3[0];
            n40002GXC3 = P00JI7_n40002GXC3[0];
         }
         else
         {
            A40002GXC3 = 0;
            n40002GXC3 = false;
         }
         pr_default.close(2);
         /* Using cursor P00JI9 */
         pr_default.execute(3, new Object[] {AV12ProfesionalesId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            A40003GXC4 = P00JI9_A40003GXC4[0];
            n40003GXC4 = P00JI9_n40003GXC4[0];
         }
         else
         {
            A40003GXC4 = 0;
            n40003GXC4 = false;
         }
         pr_default.close(3);
         /* Using cursor P00JI11 */
         pr_default.execute(4, new Object[] {AV12ProfesionalesId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            A40004GXC5 = P00JI11_A40004GXC5[0];
            n40004GXC5 = P00JI11_n40004GXC5[0];
         }
         else
         {
            A40004GXC5 = 0;
            n40004GXC5 = false;
         }
         pr_default.close(4);
         /* Using cursor P00JI13 */
         pr_default.execute(5, new Object[] {AV12ProfesionalesId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            A40005GXC6 = P00JI13_A40005GXC6[0];
            n40005GXC6 = P00JI13_n40005GXC6[0];
         }
         else
         {
            A40005GXC6 = 0;
            n40005GXC6 = false;
         }
         pr_default.close(5);
         /* Using cursor P00JI15 */
         pr_default.execute(6, new Object[] {AV12ProfesionalesId});
         if ( (pr_default.getStatus(6) != 101) )
         {
            A40006GXC7 = P00JI15_A40006GXC7[0];
            n40006GXC7 = P00JI15_n40006GXC7[0];
         }
         else
         {
            A40006GXC7 = 0;
            n40006GXC7 = false;
         }
         pr_default.close(6);
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV12ProfesionalesId)) || String.IsNullOrEmpty(StringUtil.RTrim( AV25User)) )
         {
            AV13RestMessage = context.GetMessage( "Error al procesar la solicitud", "");
            Gx_restcode = 400;
            cleanup();
            if (true) return;
         }
         new GeneXus.Programs.apis.otokenfromcookie(context ).execute(  AV11HttpRequest, out  AV24TokenId) ;
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV24TokenId)) )
         {
            Gx_restcode = 401;
            AV13RestMessage = "Token faltante";
            cleanup();
            if (true) return;
         }
         new GeneXus.Programs.apis.validaracceso(context ).execute(  AV25User,  AV12ProfesionalesId,  AV24TokenId, out  AV9EsValido, out  AV23TokenDesencriptado) ;
         if ( ! AV9EsValido )
         {
            Gx_restcode = 401;
            AV13RestMessage = context.GetMessage( "No autorizado o token inválido.", "");
            cleanup();
            if (true) return;
         }
         AV20SolDisponibles = (short)(A40000GXC1);
         AV16SolAceptadas = (short)(A40001GXC2);
         AV17SolCalificadas = (short)(A40002GXC3);
         AV21SolFinalizadas = (short)(A40003GXC4);
         AV18SolCanceladas = (short)(A40004GXC5);
         AV19SolDelegadas = (short)(A40005GXC6);
         AV22SolGarantias = (short)(A40006GXC7);
         /* Using cursor P00JI16 */
         pr_default.execute(7, new Object[] {AV12ProfesionalesId});
         while ( (pr_default.getStatus(7) != 101) )
         {
            A120ProfesionalesId = P00JI16_A120ProfesionalesId[0];
            A268ProfesionalesFeedBackCant = P00JI16_A268ProfesionalesFeedBackCant[0];
            A269ProfesionalesFeedBackProm = P00JI16_A269ProfesionalesFeedBackProm[0];
            if ( A268ProfesionalesFeedBackCant > 0 )
            {
               AV10FeedbackProm = NumberUtil.Round( A269ProfesionalesFeedBackProm/ (decimal)(A268ProfesionalesFeedBackCant), 1);
            }
            else
            {
               AV10FeedbackProm = 0;
            }
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(7);
         /* Using cursor P00JI18 */
         pr_default.execute(8);
         if ( (pr_default.getStatus(8) != 101) )
         {
            A40007GXC8 = P00JI18_A40007GXC8[0];
            n40007GXC8 = P00JI18_n40007GXC8[0];
         }
         else
         {
            A40007GXC8 = 0;
            n40007GXC8 = false;
         }
         pr_default.close(8);
         AV8CantidadSolRubro = A40007GXC8;
         AV14SDTCantSolRubro = new GXBaseCollection<GeneXus.Programs.apis.SdtSDTCantSolRubro>( context, "SDTCantSolRubro", "AlmangoX");
         /* Using cursor P00JI20 */
         pr_default.execute(9);
         while ( (pr_default.getStatus(9) != 101) )
         {
            A121RubrosId = P00JI20_A121RubrosId[0];
            A122RubrosNombre = P00JI20_A122RubrosNombre[0];
            A40008GXC9 = P00JI20_A40008GXC9[0];
            n40008GXC9 = P00JI20_n40008GXC9[0];
            A40008GXC9 = P00JI20_A40008GXC9[0];
            n40008GXC9 = P00JI20_n40008GXC9[0];
            AV15SDTCantSolRubroItem = new GeneXus.Programs.apis.SdtSDTCantSolRubro(context);
            AV15SDTCantSolRubroItem.gxTpr_Rubrosid = A121RubrosId;
            AV15SDTCantSolRubroItem.gxTpr_Rubrosnombre = A122RubrosNombre;
            AV15SDTCantSolRubroItem.gxTpr_Cantidad = A40008GXC9;
            AV14SDTCantSolRubro.Add(AV15SDTCantSolRubroItem, 0);
            pr_default.readNext(9);
         }
         pr_default.close(9);
         AV14SDTCantSolRubro.Sort(context.GetMessage( "Cantidad", ""));
         AV13RestMessage = context.GetMessage( "Solicitud procesada con éxito", "");
         Gx_restcode = 200;
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
         AV14SDTCantSolRubro = new GXBaseCollection<GeneXus.Programs.apis.SdtSDTCantSolRubro>( context, "SDTCantSolRubro", "AlmangoX");
         AV13RestMessage = "";
         P00JI3_A40000GXC1 = new int[1] ;
         P00JI3_n40000GXC1 = new bool[] {false} ;
         P00JI5_A40001GXC2 = new int[1] ;
         P00JI5_n40001GXC2 = new bool[] {false} ;
         P00JI7_A40002GXC3 = new int[1] ;
         P00JI7_n40002GXC3 = new bool[] {false} ;
         P00JI9_A40003GXC4 = new int[1] ;
         P00JI9_n40003GXC4 = new bool[] {false} ;
         P00JI11_A40004GXC5 = new int[1] ;
         P00JI11_n40004GXC5 = new bool[] {false} ;
         P00JI13_A40005GXC6 = new int[1] ;
         P00JI13_n40005GXC6 = new bool[] {false} ;
         P00JI15_A40006GXC7 = new int[1] ;
         P00JI15_n40006GXC7 = new bool[] {false} ;
         AV11HttpRequest = new GxHttpRequest( context);
         AV24TokenId = "";
         AV23TokenDesencriptado = "";
         P00JI16_A120ProfesionalesId = new string[] {""} ;
         P00JI16_A268ProfesionalesFeedBackCant = new long[1] ;
         P00JI16_A269ProfesionalesFeedBackProm = new decimal[1] ;
         A120ProfesionalesId = "";
         P00JI18_A40007GXC8 = new int[1] ;
         P00JI18_n40007GXC8 = new bool[] {false} ;
         P00JI20_A121RubrosId = new short[1] ;
         P00JI20_A122RubrosNombre = new string[] {""} ;
         P00JI20_A40008GXC9 = new int[1] ;
         P00JI20_n40008GXC9 = new bool[] {false} ;
         A122RubrosNombre = "";
         AV15SDTCantSolRubroItem = new GeneXus.Programs.apis.SdtSDTCantSolRubro(context);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.apis.oestadisticasprof__default(),
            new Object[][] {
                new Object[] {
               P00JI3_A40000GXC1, P00JI3_n40000GXC1
               }
               , new Object[] {
               P00JI5_A40001GXC2, P00JI5_n40001GXC2
               }
               , new Object[] {
               P00JI7_A40002GXC3, P00JI7_n40002GXC3
               }
               , new Object[] {
               P00JI9_A40003GXC4, P00JI9_n40003GXC4
               }
               , new Object[] {
               P00JI11_A40004GXC5, P00JI11_n40004GXC5
               }
               , new Object[] {
               P00JI13_A40005GXC6, P00JI13_n40005GXC6
               }
               , new Object[] {
               P00JI15_A40006GXC7, P00JI15_n40006GXC7
               }
               , new Object[] {
               P00JI16_A120ProfesionalesId, P00JI16_A268ProfesionalesFeedBackCant, P00JI16_A269ProfesionalesFeedBackProm
               }
               , new Object[] {
               P00JI18_A40007GXC8, P00JI18_n40007GXC8
               }
               , new Object[] {
               P00JI20_A121RubrosId, P00JI20_A122RubrosNombre, P00JI20_A40008GXC9, P00JI20_n40008GXC9
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV20SolDisponibles ;
      private short AV16SolAceptadas ;
      private short AV17SolCalificadas ;
      private short AV21SolFinalizadas ;
      private short AV18SolCanceladas ;
      private short AV19SolDelegadas ;
      private short AV22SolGarantias ;
      private short Gx_restcode ;
      private short A121RubrosId ;
      private int A40000GXC1 ;
      private int A40001GXC2 ;
      private int A40002GXC3 ;
      private int A40003GXC4 ;
      private int A40004GXC5 ;
      private int A40005GXC6 ;
      private int A40006GXC7 ;
      private int A40007GXC8 ;
      private int AV8CantidadSolRubro ;
      private int A40008GXC9 ;
      private long A268ProfesionalesFeedBackCant ;
      private decimal AV10FeedbackProm ;
      private decimal A269ProfesionalesFeedBackProm ;
      private string AV25User ;
      private string AV12ProfesionalesId ;
      private string AV24TokenId ;
      private string AV23TokenDesencriptado ;
      private string A120ProfesionalesId ;
      private string A122RubrosNombre ;
      private bool n40000GXC1 ;
      private bool n40001GXC2 ;
      private bool n40002GXC3 ;
      private bool n40003GXC4 ;
      private bool n40004GXC5 ;
      private bool n40005GXC6 ;
      private bool n40006GXC7 ;
      private bool AV9EsValido ;
      private bool n40007GXC8 ;
      private bool n40008GXC9 ;
      private string AV13RestMessage ;
      private GxHttpRequest AV11HttpRequest ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GXBaseCollection<GeneXus.Programs.apis.SdtSDTCantSolRubro> AV14SDTCantSolRubro ;
      private IDataStoreProvider pr_default ;
      private int[] P00JI3_A40000GXC1 ;
      private bool[] P00JI3_n40000GXC1 ;
      private int[] P00JI5_A40001GXC2 ;
      private bool[] P00JI5_n40001GXC2 ;
      private int[] P00JI7_A40002GXC3 ;
      private bool[] P00JI7_n40002GXC3 ;
      private int[] P00JI9_A40003GXC4 ;
      private bool[] P00JI9_n40003GXC4 ;
      private int[] P00JI11_A40004GXC5 ;
      private bool[] P00JI11_n40004GXC5 ;
      private int[] P00JI13_A40005GXC6 ;
      private bool[] P00JI13_n40005GXC6 ;
      private int[] P00JI15_A40006GXC7 ;
      private bool[] P00JI15_n40006GXC7 ;
      private string[] P00JI16_A120ProfesionalesId ;
      private long[] P00JI16_A268ProfesionalesFeedBackCant ;
      private decimal[] P00JI16_A269ProfesionalesFeedBackProm ;
      private int[] P00JI18_A40007GXC8 ;
      private bool[] P00JI18_n40007GXC8 ;
      private short[] P00JI20_A121RubrosId ;
      private string[] P00JI20_A122RubrosNombre ;
      private int[] P00JI20_A40008GXC9 ;
      private bool[] P00JI20_n40008GXC9 ;
      private GeneXus.Programs.apis.SdtSDTCantSolRubro AV15SDTCantSolRubroItem ;
      private short aP2_SolDisponibles ;
      private short aP3_SolAceptadas ;
      private short aP4_SolCalificadas ;
      private short aP5_SolFinalizadas ;
      private short aP6_SolCanceladas ;
      private short aP7_SolDelegadas ;
      private short aP8_SolGarantias ;
      private decimal aP9_FeedbackProm ;
      private GXBaseCollection<GeneXus.Programs.apis.SdtSDTCantSolRubro> aP10_SDTCantSolRubro ;
      private string aP11_RestMessage ;
      private short aP12_Gx_restcode ;
   }

   public class oestadisticasprof__default : DataStoreHelperBase, IDataStoreHelper
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
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP00JI3;
          prmP00JI3 = new Object[] {
          };
          Object[] prmP00JI5;
          prmP00JI5 = new Object[] {
          new ParDef("@AV12ProfesionalesId",GXType.Char,20,0)
          };
          Object[] prmP00JI7;
          prmP00JI7 = new Object[] {
          new ParDef("@AV12ProfesionalesId",GXType.Char,20,0)
          };
          Object[] prmP00JI9;
          prmP00JI9 = new Object[] {
          new ParDef("@AV12ProfesionalesId",GXType.Char,20,0)
          };
          Object[] prmP00JI11;
          prmP00JI11 = new Object[] {
          new ParDef("@AV12ProfesionalesId",GXType.Char,20,0)
          };
          Object[] prmP00JI13;
          prmP00JI13 = new Object[] {
          new ParDef("@AV12ProfesionalesId",GXType.Char,20,0)
          };
          Object[] prmP00JI15;
          prmP00JI15 = new Object[] {
          new ParDef("@AV12ProfesionalesId",GXType.Char,20,0)
          };
          Object[] prmP00JI16;
          prmP00JI16 = new Object[] {
          new ParDef("@AV12ProfesionalesId",GXType.Char,20,0)
          };
          Object[] prmP00JI18;
          prmP00JI18 = new Object[] {
          };
          Object[] prmP00JI20;
          prmP00JI20 = new Object[] {
          };
          def= new CursorDef[] {
              new CursorDef("P00JI3", "SELECT COALESCE( T1.[GXC9], 0) AS GXC1 FROM (SELECT COUNT(*) AS GXC9 FROM [Solicitudes] WHERE [EstadosSolId] = 8 ) T1 ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00JI3,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("P00JI5", "SELECT COALESCE( T1.[GXC2], 0) AS GXC2 FROM (SELECT COUNT(*) AS GXC2 FROM ([Relaciones] T2 INNER JOIN [Solicitudes] T3 ON T3.[SolicitudesID] = T2.[SolicitudesID]) WHERE (T2.[EstadoSGId] = 1) AND (T3.[EstadosSolId] = 5) AND (T2.[ProfesionalesId] = @AV12ProfesionalesId) ) T1 ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00JI5,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("P00JI7", "SELECT COALESCE( T1.[GXC2], 0) AS GXC3 FROM (SELECT COUNT(*) AS GXC2 FROM ([Relaciones] T2 INNER JOIN [Solicitudes] T3 ON T3.[SolicitudesID] = T2.[SolicitudesID]) WHERE (T2.[EstadoSGId] = 1) AND (T3.[EstadosSolId] = 7) AND (T2.[ProfesionalesId] = @AV12ProfesionalesId) ) T1 ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00JI7,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("P00JI9", "SELECT COALESCE( T1.[GXC2], 0) AS GXC4 FROM (SELECT COUNT(*) AS GXC2 FROM ([Relaciones] T2 INNER JOIN [Solicitudes] T3 ON T3.[SolicitudesID] = T2.[SolicitudesID]) WHERE (T2.[EstadoSGId] = 1) AND (T3.[EstadosSolId] = 6) AND (T2.[ProfesionalesId] = @AV12ProfesionalesId) ) T1 ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00JI9,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("P00JI11", "SELECT COALESCE( T1.[GXC2], 0) AS GXC5 FROM (SELECT COUNT(*) AS GXC2 FROM ([Relaciones] T2 INNER JOIN [Solicitudes] T3 ON T3.[SolicitudesID] = T2.[SolicitudesID]) WHERE (T3.[EstadosSolId] = 3) AND (T2.[ProfesionalesId] = @AV12ProfesionalesId) ) T1 ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00JI11,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("P00JI13", "SELECT COALESCE( T1.[GXC2], 0) AS GXC6 FROM (SELECT COUNT(*) AS GXC2 FROM ([Relaciones] T2 INNER JOIN [Solicitudes] T3 ON T3.[SolicitudesID] = T2.[SolicitudesID]) WHERE (T2.[EstadoSGId] = 1) AND (T3.[EstadosSolId] = 2) AND (T2.[ProfesionalesId] = @AV12ProfesionalesId) ) T1 ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00JI13,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("P00JI15", "SELECT COALESCE( T1.[GXC2], 0) AS GXC7 FROM (SELECT COUNT(*) AS GXC2 FROM ([Relaciones] T2 INNER JOIN [Solicitudes] T3 ON T3.[SolicitudesID] = T2.[SolicitudesID]) WHERE (T2.[EstadoSGId] = 1) AND (T3.[EstadosSolId] = 6) AND (T3.[SolicitudesSubTipo] = 'G') AND (T2.[ProfesionalesId] = @AV12ProfesionalesId) ) T1 ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00JI15,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("P00JI16", "SELECT [ProfesionalesId], [ProfesionalesFeedBackCant], [ProfesionalesFeedBackProm] FROM [Profesionales] WHERE [ProfesionalesId] = @AV12ProfesionalesId ORDER BY [ProfesionalesId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00JI16,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00JI18", "SELECT COALESCE( T1.[GXC9], 0) AS GXC8 FROM (SELECT COUNT(*) AS GXC9 FROM [SolicitudesItems] WHERE [RubrosId] = 1 ) T1 ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00JI18,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("P00JI20", "SELECT T1.[RubrosId], T1.[RubrosNombre], COALESCE( T2.[GXC9], 0) AS GXC9 FROM ([Rubros] T1 LEFT JOIN (SELECT COUNT(*) AS GXC9, [RubrosId] FROM [SolicitudesItems] GROUP BY [RubrosId] ) T2 ON T2.[RubrosId] = T1.[RubrosId]) ORDER BY T1.[RubrosId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00JI20,100, GxCacheFrequency.OFF ,false,false )
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
                ((string[]) buf[0])[0] = rslt.getString(1, 20);
                ((long[]) buf[1])[0] = rslt.getLong(2);
                ((decimal[]) buf[2])[0] = rslt.getDecimal(3);
                return;
             case 8 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 9 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 100);
                ((int[]) buf[2])[0] = rslt.getInt(3);
                ((bool[]) buf[3])[0] = rslt.wasNull(3);
                return;
       }
    }

 }

}

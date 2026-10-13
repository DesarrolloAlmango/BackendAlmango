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
   public class comisionesvincprof : GXProcedure
   {
      public comisionesvincprof( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public comisionesvincprof( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( long aP0_ComisionesID ,
                           bool aP1_AccionVincular ,
                           out short aP2_ok ,
                           out int aP3_Cantidad )
      {
         this.AV9ComisionesID = aP0_ComisionesID;
         this.AV8AccionVincular = aP1_AccionVincular;
         this.AV11ok = 0 ;
         this.AV12Cantidad = 0 ;
         initialize();
         ExecutePrivate();
         aP2_ok=this.AV11ok;
         aP3_Cantidad=this.AV12Cantidad;
      }

      public int executeUdp( long aP0_ComisionesID ,
                             bool aP1_AccionVincular ,
                             out short aP2_ok )
      {
         execute(aP0_ComisionesID, aP1_AccionVincular, out aP2_ok, out aP3_Cantidad);
         return AV12Cantidad ;
      }

      public void executeSubmit( long aP0_ComisionesID ,
                                 bool aP1_AccionVincular ,
                                 out short aP2_ok ,
                                 out int aP3_Cantidad )
      {
         this.AV9ComisionesID = aP0_ComisionesID;
         this.AV8AccionVincular = aP1_AccionVincular;
         this.AV11ok = 0 ;
         this.AV12Cantidad = 0 ;
         SubmitImpl();
         aP2_ok=this.AV11ok;
         aP3_Cantidad=this.AV12Cantidad;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV12Cantidad = 0;
         AV11ok = (short)(Convert.ToInt16(false));
         if ( AV8AccionVincular )
         {
            /* Using cursor P00MQ2 */
            pr_default.execute(0);
            while ( (pr_default.getStatus(0) != 101) )
            {
               A170ProfesionalesTelefono = P00MQ2_A170ProfesionalesTelefono[0];
               A901ProfesionalesRUT = P00MQ2_A901ProfesionalesRUT[0];
               n901ProfesionalesRUT = P00MQ2_n901ProfesionalesRUT[0];
               A108EstadosGenericosId = P00MQ2_A108EstadosGenericosId[0];
               A107EstadosTipo = P00MQ2_A107EstadosTipo[0];
               A120ProfesionalesId = P00MQ2_A120ProfesionalesId[0];
               if ( StringUtil.StrCmp(A107EstadosTipo, context.GetMessage( "STS", "")) == 0 )
               {
                  AV10ProfesionalesId = A120ProfesionalesId;
                  /* Execute user subroutine: 'VINCULAR' */
                  S111 ();
                  if ( returnInSub )
                  {
                     pr_default.close(0);
                     cleanup();
                     if (true) return;
                  }
               }
               pr_default.readNext(0);
            }
            pr_default.close(0);
         }
         else
         {
            /* Using cursor P00MQ3 */
            pr_default.execute(1, new Object[] {AV9ComisionesID});
            while ( (pr_default.getStatus(1) != 101) )
            {
               A120ProfesionalesId = P00MQ3_A120ProfesionalesId[0];
               A503ComisionesID = P00MQ3_A503ComisionesID[0];
               /* Using cursor P00MQ4 */
               pr_default.execute(2, new Object[] {A503ComisionesID, A120ProfesionalesId});
               pr_default.close(2);
               pr_default.SmartCacheProvider.SetUpdated("ComisionesProfesionales");
               AV11ok = (short)(Convert.ToInt16(true));
               AV12Cantidad = (int)(AV12Cantidad+1);
               pr_default.readNext(1);
            }
            pr_default.close(1);
         }
         cleanup();
      }

      protected void S111( )
      {
         /* 'VINCULAR' Routine */
         returnInSub = false;
         /*
            INSERT RECORD ON TABLE ComisionesProfesionales

         */
         A503ComisionesID = AV9ComisionesID;
         A120ProfesionalesId = AV10ProfesionalesId;
         AV11ok = (short)(Convert.ToInt16(true));
         AV12Cantidad = (int)(AV12Cantidad+1);
         /* Using cursor P00MQ5 */
         pr_default.execute(3, new Object[] {A503ComisionesID, A120ProfesionalesId});
         pr_default.close(3);
         pr_default.SmartCacheProvider.SetUpdated("ComisionesProfesionales");
         if ( (pr_default.getStatus(3) == 1) )
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

      public override void cleanup( )
      {
         context.CommitDataStores("comisionesvincprof",pr_default);
         CloseCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
         ExitApp();
      }

      public override void initialize( )
      {
         P00MQ2_A170ProfesionalesTelefono = new string[] {""} ;
         P00MQ2_A901ProfesionalesRUT = new string[] {""} ;
         P00MQ2_n901ProfesionalesRUT = new bool[] {false} ;
         P00MQ2_A108EstadosGenericosId = new int[1] ;
         P00MQ2_A107EstadosTipo = new string[] {""} ;
         P00MQ2_A120ProfesionalesId = new string[] {""} ;
         A170ProfesionalesTelefono = "";
         A901ProfesionalesRUT = "";
         A107EstadosTipo = "";
         A120ProfesionalesId = "";
         AV10ProfesionalesId = "";
         P00MQ3_A120ProfesionalesId = new string[] {""} ;
         P00MQ3_A503ComisionesID = new long[1] ;
         Gx_emsg = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.comisionesvincprof__default(),
            new Object[][] {
                new Object[] {
               P00MQ2_A170ProfesionalesTelefono, P00MQ2_A901ProfesionalesRUT, P00MQ2_n901ProfesionalesRUT, P00MQ2_A108EstadosGenericosId, P00MQ2_A107EstadosTipo, P00MQ2_A120ProfesionalesId
               }
               , new Object[] {
               P00MQ3_A120ProfesionalesId, P00MQ3_A503ComisionesID
               }
               , new Object[] {
               }
               , new Object[] {
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV11ok ;
      private int AV12Cantidad ;
      private int A108EstadosGenericosId ;
      private int GX_INS76 ;
      private long AV9ComisionesID ;
      private long A503ComisionesID ;
      private string A170ProfesionalesTelefono ;
      private string A901ProfesionalesRUT ;
      private string A107EstadosTipo ;
      private string A120ProfesionalesId ;
      private string AV10ProfesionalesId ;
      private string Gx_emsg ;
      private bool AV8AccionVincular ;
      private bool n901ProfesionalesRUT ;
      private bool returnInSub ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] P00MQ2_A170ProfesionalesTelefono ;
      private string[] P00MQ2_A901ProfesionalesRUT ;
      private bool[] P00MQ2_n901ProfesionalesRUT ;
      private int[] P00MQ2_A108EstadosGenericosId ;
      private string[] P00MQ2_A107EstadosTipo ;
      private string[] P00MQ2_A120ProfesionalesId ;
      private string[] P00MQ3_A120ProfesionalesId ;
      private long[] P00MQ3_A503ComisionesID ;
      private short aP2_ok ;
      private int aP3_Cantidad ;
   }

   public class comisionesvincprof__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
         ,new UpdateCursor(def[2])
         ,new UpdateCursor(def[3])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP00MQ2;
          prmP00MQ2 = new Object[] {
          };
          Object[] prmP00MQ3;
          prmP00MQ3 = new Object[] {
          new ParDef("@AV9ComisionesID",GXType.Decimal,18,0)
          };
          Object[] prmP00MQ4;
          prmP00MQ4 = new Object[] {
          new ParDef("@ComisionesID",GXType.Decimal,18,0) ,
          new ParDef("@ProfesionalesId",GXType.Char,20,0)
          };
          Object[] prmP00MQ5;
          prmP00MQ5 = new Object[] {
          new ParDef("@ComisionesID",GXType.Decimal,18,0) ,
          new ParDef("@ProfesionalesId",GXType.Char,20,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00MQ2", "SELECT [ProfesionalesTelefono], [ProfesionalesRUT], [EstadosGenericosId], [EstadosTipo], [ProfesionalesId] FROM [Profesionales] WHERE (Not ([ProfesionalesRUT] = '')) AND (Not ([ProfesionalesTelefono] = '')) AND ([EstadosGenericosId] = 1) ORDER BY [ProfesionalesId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00MQ2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00MQ3", "SELECT [ProfesionalesId], [ComisionesID] FROM [ComisionesProfesionales] WITH (UPDLOCK) WHERE ([ComisionesID] = @AV9ComisionesID) AND (LEN([ProfesionalesId]) > 0) ORDER BY [ComisionesID] ",true, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00MQ3,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00MQ4", "DELETE FROM [ComisionesProfesionales]  WHERE [ComisionesID] = @ComisionesID AND [ProfesionalesId] = @ProfesionalesId", GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP00MQ4)
             ,new CursorDef("P00MQ5", "INSERT INTO [ComisionesProfesionales]([ComisionesID], [ProfesionalesId]) VALUES(@ComisionesID, @ProfesionalesId)", GxErrorMask.GX_NOMASK,prmP00MQ5)
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
                ((string[]) buf[1])[0] = rslt.getString(2, 20);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((int[]) buf[3])[0] = rslt.getInt(3);
                ((string[]) buf[4])[0] = rslt.getString(4, 3);
                ((string[]) buf[5])[0] = rslt.getString(5, 20);
                return;
             case 1 :
                ((string[]) buf[0])[0] = rslt.getString(1, 20);
                ((long[]) buf[1])[0] = rslt.getLong(2);
                return;
       }
    }

 }

}

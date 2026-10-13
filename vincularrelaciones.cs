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
   public class vincularrelaciones : GXProcedure
   {
      public vincularrelaciones( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public vincularrelaciones( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( long aP0_SolicitudesID ,
                           string aP1_ProfesionalesId ,
                           out bool aP2_Vinculo )
      {
         this.AV9SolicitudesID = aP0_SolicitudesID;
         this.AV8ProfesionalesId = aP1_ProfesionalesId;
         this.AV10Vinculo = false ;
         initialize();
         ExecutePrivate();
         aP2_Vinculo=this.AV10Vinculo;
      }

      public bool executeUdp( long aP0_SolicitudesID ,
                              string aP1_ProfesionalesId )
      {
         execute(aP0_SolicitudesID, aP1_ProfesionalesId, out aP2_Vinculo);
         return AV10Vinculo ;
      }

      public void executeSubmit( long aP0_SolicitudesID ,
                                 string aP1_ProfesionalesId ,
                                 out bool aP2_Vinculo )
      {
         this.AV9SolicitudesID = aP0_SolicitudesID;
         this.AV8ProfesionalesId = aP1_ProfesionalesId;
         this.AV10Vinculo = false ;
         SubmitImpl();
         aP2_Vinculo=this.AV10Vinculo;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV10Vinculo = false;
         AV13GXLvl3 = 0;
         /* Using cursor P009H2 */
         pr_default.execute(0, new Object[] {AV9SolicitudesID, AV8ProfesionalesId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A120ProfesionalesId = P009H2_A120ProfesionalesId[0];
            A127SolicitudesID = P009H2_A127SolicitudesID[0];
            A140RelacionesId = P009H2_A140RelacionesId[0];
            AV13GXLvl3 = 1;
            AV10Vinculo = false;
            /* Exit For each command. Update data (if necessary), close cursors & exit. */
            if (true) break;
            pr_default.readNext(0);
         }
         pr_default.close(0);
         if ( AV13GXLvl3 == 0 )
         {
            AV10Vinculo = true;
            /* Using cursor P009H3 */
            pr_default.execute(1, new Object[] {AV9SolicitudesID});
            while ( (pr_default.getStatus(1) != 101) )
            {
               A127SolicitudesID = P009H3_A127SolicitudesID[0];
               A140RelacionesId = P009H3_A140RelacionesId[0];
               AV11RelacionesId = A140RelacionesId;
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               if (true) break;
               pr_default.readNext(1);
            }
            pr_default.close(1);
         }
         if ( AV10Vinculo )
         {
            AV10Vinculo = false;
            AV11RelacionesId = (long)(AV11RelacionesId+1);
            /* Using cursor P009H4 */
            pr_default.execute(2, new Object[] {AV9SolicitudesID});
            while ( (pr_default.getStatus(2) != 101) )
            {
               GXT9H4 = 0;
               A127SolicitudesID = P009H4_A127SolicitudesID[0];
               A130EstadosSolTipo = P009H4_A130EstadosSolTipo[0];
               A131EstadosSolId = P009H4_A131EstadosSolId[0];
               W127SolicitudesID = A127SolicitudesID;
               A130EstadosSolTipo = context.GetMessage( "SOL", "");
               A131EstadosSolId = 2;
               /*
                  INSERT RECORD ON TABLE Relaciones

               */
               W127SolicitudesID = A127SolicitudesID;
               A140RelacionesId = AV11RelacionesId;
               A127SolicitudesID = AV9SolicitudesID;
               A120ProfesionalesId = AV8ProfesionalesId;
               A141EstadoSGTipo = context.GetMessage( "STS", "");
               A142EstadoSGId = 1;
               A219SolicitudesRelacionesFechaAlta = DateTimeUtil.ServerNow( context, pr_default);
               A220SolicitudesRelacionesFechaModi = DateTimeUtil.ServerNow( context, pr_default);
               AV10Vinculo = true;
               /* Using cursor P009H5 */
               pr_default.execute(3, new Object[] {A127SolicitudesID, A140RelacionesId, A120ProfesionalesId, A141EstadoSGTipo, A142EstadoSGId, A219SolicitudesRelacionesFechaAlta, A220SolicitudesRelacionesFechaModi});
               pr_default.close(3);
               pr_default.SmartCacheProvider.SetUpdated("Relaciones");
               if ( (pr_default.getStatus(3) == 1) )
               {
                  context.Gx_err = 1;
                  Gx_emsg = (string)(context.GetMessage( "GXM_noupdate", ""));
                  A141EstadoSGTipo = context.GetMessage( "STS", "");
                  A142EstadoSGId = 1;
                  A220SolicitudesRelacionesFechaModi = DateTimeUtil.ServerNow( context, pr_default);
                  AV10Vinculo = false;
               }
               else
               {
                  context.Gx_err = 0;
                  Gx_emsg = "";
               }
               A127SolicitudesID = W127SolicitudesID;
               /* End Insert */
               GXT9H4 = 1;
               /* Using cursor P009H6 */
               pr_default.execute(4, new Object[] {A130EstadosSolTipo, A131EstadosSolId, A127SolicitudesID});
               pr_default.close(4);
               pr_default.SmartCacheProvider.SetUpdated("Solicitudes");
               A127SolicitudesID = W127SolicitudesID;
               if ( GXT9H4 == 1 )
               {
                  context.CommitDataStores("vincularrelaciones",pr_default);
               }
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(2);
         }
         cleanup();
      }

      public override void cleanup( )
      {
         context.CommitDataStores("vincularrelaciones",pr_default);
         CloseCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
         ExitApp();
      }

      public override void initialize( )
      {
         P009H2_A120ProfesionalesId = new string[] {""} ;
         P009H2_A127SolicitudesID = new long[1] ;
         P009H2_A140RelacionesId = new long[1] ;
         A120ProfesionalesId = "";
         P009H3_A127SolicitudesID = new long[1] ;
         P009H3_A140RelacionesId = new long[1] ;
         P009H4_A127SolicitudesID = new long[1] ;
         P009H4_A130EstadosSolTipo = new string[] {""} ;
         P009H4_A131EstadosSolId = new int[1] ;
         A130EstadosSolTipo = "";
         A141EstadoSGTipo = "";
         A219SolicitudesRelacionesFechaAlta = (DateTime)(DateTime.MinValue);
         A220SolicitudesRelacionesFechaModi = (DateTime)(DateTime.MinValue);
         Gx_emsg = "";
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.vincularrelaciones__datastore1(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.vincularrelaciones__default(),
            new Object[][] {
                new Object[] {
               P009H2_A120ProfesionalesId, P009H2_A127SolicitudesID, P009H2_A140RelacionesId
               }
               , new Object[] {
               P009H3_A127SolicitudesID, P009H3_A140RelacionesId
               }
               , new Object[] {
               P009H4_A127SolicitudesID, P009H4_A130EstadosSolTipo, P009H4_A131EstadosSolId
               }
               , new Object[] {
               }
               , new Object[] {
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV13GXLvl3 ;
      private short GXT9H4 ;
      private int A131EstadosSolId ;
      private int GX_INS32 ;
      private int A142EstadoSGId ;
      private long AV9SolicitudesID ;
      private long A127SolicitudesID ;
      private long A140RelacionesId ;
      private long AV11RelacionesId ;
      private long W127SolicitudesID ;
      private string AV8ProfesionalesId ;
      private string A120ProfesionalesId ;
      private string A130EstadosSolTipo ;
      private string A141EstadoSGTipo ;
      private string Gx_emsg ;
      private DateTime A219SolicitudesRelacionesFechaAlta ;
      private DateTime A220SolicitudesRelacionesFechaModi ;
      private bool AV10Vinculo ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] P009H2_A120ProfesionalesId ;
      private long[] P009H2_A127SolicitudesID ;
      private long[] P009H2_A140RelacionesId ;
      private long[] P009H3_A127SolicitudesID ;
      private long[] P009H3_A140RelacionesId ;
      private long[] P009H4_A127SolicitudesID ;
      private string[] P009H4_A130EstadosSolTipo ;
      private int[] P009H4_A131EstadosSolId ;
      private bool aP2_Vinculo ;
      private IDataStoreProvider pr_datastore1 ;
   }

   public class vincularrelaciones__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class vincularrelaciones__default : DataStoreHelperBase, IDataStoreHelper
 {
    public ICursor[] getCursors( )
    {
       cursorDefinitions();
       return new Cursor[] {
        new ForEachCursor(def[0])
       ,new ForEachCursor(def[1])
       ,new ForEachCursor(def[2])
       ,new UpdateCursor(def[3])
       ,new UpdateCursor(def[4])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmP009H2;
        prmP009H2 = new Object[] {
        new ParDef("@AV9SolicitudesID",GXType.Decimal,18,0) ,
        new ParDef("@AV8ProfesionalesId",GXType.Char,20,0)
        };
        Object[] prmP009H3;
        prmP009H3 = new Object[] {
        new ParDef("@AV9SolicitudesID",GXType.Decimal,18,0)
        };
        Object[] prmP009H4;
        prmP009H4 = new Object[] {
        new ParDef("@AV9SolicitudesID",GXType.Decimal,18,0)
        };
        Object[] prmP009H5;
        prmP009H5 = new Object[] {
        new ParDef("@SolicitudesID",GXType.Decimal,18,0) ,
        new ParDef("@RelacionesId",GXType.Decimal,18,0) ,
        new ParDef("@ProfesionalesId",GXType.Char,20,0) ,
        new ParDef("@EstadoSGTipo",GXType.NChar,3,0) ,
        new ParDef("@EstadoSGId",GXType.Int32,5,0) ,
        new ParDef("@SolicitudesRelacionesFechaAlta",GXType.DateTime,8,5) ,
        new ParDef("@SolicitudesRelacionesFechaModi",GXType.DateTime,8,5)
        };
        Object[] prmP009H6;
        prmP009H6 = new Object[] {
        new ParDef("@EstadosSolTipo",GXType.NChar,3,0) ,
        new ParDef("@EstadosSolId",GXType.Int32,5,0) ,
        new ParDef("@SolicitudesID",GXType.Decimal,18,0)
        };
        def= new CursorDef[] {
            new CursorDef("P009H2", "SELECT TOP 1 [ProfesionalesId], [SolicitudesID], [RelacionesId] FROM [Relaciones] WHERE ([SolicitudesID] = @AV9SolicitudesID) AND ([ProfesionalesId] = @AV8ProfesionalesId) ORDER BY [SolicitudesID] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP009H2,1, GxCacheFrequency.OFF ,false,true )
           ,new CursorDef("P009H3", "SELECT TOP 1 [SolicitudesID], [RelacionesId] FROM [Relaciones] WHERE [SolicitudesID] = @AV9SolicitudesID ORDER BY [SolicitudesID] DESC, [RelacionesId] DESC ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP009H3,1, GxCacheFrequency.OFF ,false,true )
           ,new CursorDef("P009H4", "SELECT [SolicitudesID], [EstadosSolTipo], [EstadosSolId] FROM [Solicitudes] WITH (UPDLOCK) WHERE [SolicitudesID] = @AV9SolicitudesID ORDER BY [SolicitudesID] ",true, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP009H4,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("P009H5", "INSERT INTO [Relaciones]([SolicitudesID], [RelacionesId], [ProfesionalesId], [EstadoSGTipo], [EstadoSGId], [SolicitudesRelacionesFechaAlta], [SolicitudesRelacionesFechaModi]) VALUES(@SolicitudesID, @RelacionesId, @ProfesionalesId, @EstadoSGTipo, @EstadoSGId, @SolicitudesRelacionesFechaAlta, @SolicitudesRelacionesFechaModi)", GxErrorMask.GX_NOMASK,prmP009H5)
           ,new CursorDef("P009H6", "UPDATE [Solicitudes] SET [EstadosSolTipo]=@EstadosSolTipo, [EstadosSolId]=@EstadosSolId  WHERE [SolicitudesID] = @SolicitudesID", GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP009H6)
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
              ((long[]) buf[1])[0] = rslt.getLong(2);
              ((long[]) buf[2])[0] = rslt.getLong(3);
              return;
           case 1 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              return;
           case 2 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 3);
              ((int[]) buf[2])[0] = rslt.getInt(3);
              return;
     }
  }

}

}

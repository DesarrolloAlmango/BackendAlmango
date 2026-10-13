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
   public class activarcuenta : GXProcedure
   {
      public activarcuenta( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public activarcuenta( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Tipo ,
                           string aP1_usuariosId ,
                           long aP2_UserID )
      {
         this.AV9Tipo = aP0_Tipo;
         this.AV11usuariosId = aP1_usuariosId;
         this.AV8UserID = aP2_UserID;
         initialize();
         ExecutePrivate();
      }

      public void executeSubmit( string aP0_Tipo ,
                                 string aP1_usuariosId ,
                                 long aP2_UserID )
      {
         this.AV9Tipo = aP0_Tipo;
         this.AV11usuariosId = aP1_usuariosId;
         this.AV8UserID = aP2_UserID;
         SubmitImpl();
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         if ( StringUtil.StrCmp(AV9Tipo, context.GetMessage( "P", "")) == 0 )
         {
            AV13cUsuariosId = AV11usuariosId;
            /* Execute user subroutine: 'USUARIO' */
            S111 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else
         {
            /* Using cursor P00CB2 */
            pr_default.execute(0, new Object[] {AV8UserID});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A18SecUserId = P00CB2_A18SecUserId[0];
               A550SecUserEstado = P00CB2_A550SecUserEstado[0];
               n550SecUserEstado = P00CB2_n550SecUserEstado[0];
               A145usuariosId = P00CB2_A145usuariosId[0];
               n145usuariosId = P00CB2_n145usuariosId[0];
               A550SecUserEstado = "HAB";
               n550SecUserEstado = false;
               AV13cUsuariosId = StringUtil.Trim( A145usuariosId);
               /* Execute user subroutine: 'USUARIO' */
               S111 ();
               if ( returnInSub )
               {
                  pr_default.close(0);
                  cleanup();
                  if (true) return;
               }
               /* Using cursor P00CB3 */
               pr_default.execute(1, new Object[] {n550SecUserEstado, A550SecUserEstado, A18SecUserId});
               pr_default.close(1);
               pr_default.SmartCacheProvider.SetUpdated("SecUser");
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(0);
         }
         cleanup();
      }

      protected void S111( )
      {
         /* 'USUARIO' Routine */
         returnInSub = false;
         /* Using cursor P00CB4 */
         pr_default.execute(2, new Object[] {AV11usuariosId});
         while ( (pr_default.getStatus(2) != 101) )
         {
            A145usuariosId = P00CB4_A145usuariosId[0];
            n145usuariosId = P00CB4_n145usuariosId[0];
            A226usuariosEstado = P00CB4_A226usuariosEstado[0];
            A240usuariosNumeroIdentidad = P00CB4_A240usuariosNumeroIdentidad[0];
            A225usuariosTipo = P00CB4_A225usuariosTipo[0];
            A226usuariosEstado = "HAB";
            AV10NoIdentidad = A240usuariosNumeroIdentidad;
            if ( StringUtil.StrCmp(A225usuariosTipo, context.GetMessage( "S", "")) == 0 )
            {
               /* Execute user subroutine: 'ACTIVAR PROFESIONAL' */
               S123 ();
               if ( returnInSub )
               {
                  pr_default.close(2);
                  returnInSub = true;
                  if (true) return;
               }
            }
            else if ( StringUtil.StrCmp(A225usuariosTipo, context.GetMessage( "P", "")) == 0 )
            {
               /* Execute user subroutine: 'ACTIVAR PROVEEDOR' */
               S133 ();
               if ( returnInSub )
               {
                  pr_default.close(2);
                  returnInSub = true;
                  if (true) return;
               }
            }
            /* Using cursor P00CB5 */
            pr_default.execute(3, new Object[] {A226usuariosEstado, n145usuariosId, A145usuariosId});
            pr_default.close(3);
            pr_default.SmartCacheProvider.SetUpdated("usuarios");
            pr_default.readNext(2);
         }
         pr_default.close(2);
      }

      protected void S123( )
      {
         /* 'ACTIVAR PROFESIONAL' Routine */
         returnInSub = false;
         /* Using cursor P00CB6 */
         pr_default.execute(4, new Object[] {AV10NoIdentidad});
         while ( (pr_default.getStatus(4) != 101) )
         {
            A120ProfesionalesId = P00CB6_A120ProfesionalesId[0];
            A108EstadosGenericosId = P00CB6_A108EstadosGenericosId[0];
            A200ProfesionalesFechaActualizado = P00CB6_A200ProfesionalesFechaActualizado[0];
            A108EstadosGenericosId = 1;
            A200ProfesionalesFechaActualizado = DateTimeUtil.ServerNow( context, pr_default);
            /* Exit For each command. Update data (if necessary), close cursors & exit. */
            /* Using cursor P00CB7 */
            pr_default.execute(5, new Object[] {A108EstadosGenericosId, A200ProfesionalesFechaActualizado, A120ProfesionalesId});
            pr_default.close(5);
            pr_default.SmartCacheProvider.SetUpdated("Profesionales");
            if (true) break;
            /* Using cursor P00CB8 */
            pr_default.execute(6, new Object[] {A108EstadosGenericosId, A200ProfesionalesFechaActualizado, A120ProfesionalesId});
            pr_default.close(6);
            pr_default.SmartCacheProvider.SetUpdated("Profesionales");
            pr_default.readNext(4);
         }
         pr_default.close(4);
      }

      protected void S133( )
      {
         /* 'ACTIVAR PROVEEDOR' Routine */
         returnInSub = false;
         /* Using cursor P00CB9 */
         pr_default.execute(7, new Object[] {AV10NoIdentidad});
         while ( (pr_default.getStatus(7) != 101) )
         {
            A338ProveedorDocIdentidad = P00CB9_A338ProveedorDocIdentidad[0];
            A344ProveedorEstado = P00CB9_A344ProveedorEstado[0];
            A549ProveedorFechaActualizacion = P00CB9_A549ProveedorFechaActualizacion[0];
            n549ProveedorFechaActualizacion = P00CB9_n549ProveedorFechaActualizacion[0];
            A133ProveedorID = P00CB9_A133ProveedorID[0];
            A344ProveedorEstado = "HAB";
            A549ProveedorFechaActualizacion = DateTimeUtil.ServerNow( context, pr_default);
            n549ProveedorFechaActualizacion = false;
            /* Exit For each command. Update data (if necessary), close cursors & exit. */
            /* Using cursor P00CB10 */
            pr_default.execute(8, new Object[] {A344ProveedorEstado, n549ProveedorFechaActualizacion, A549ProveedorFechaActualizacion, A133ProveedorID});
            pr_default.close(8);
            pr_default.SmartCacheProvider.SetUpdated("Proveedor");
            if (true) break;
            /* Using cursor P00CB11 */
            pr_default.execute(9, new Object[] {A344ProveedorEstado, n549ProveedorFechaActualizacion, A549ProveedorFechaActualizacion, A133ProveedorID});
            pr_default.close(9);
            pr_default.SmartCacheProvider.SetUpdated("Proveedor");
            pr_default.readNext(7);
         }
         pr_default.close(7);
      }

      public override void cleanup( )
      {
         context.CommitDataStores("activarcuenta",pr_default);
         CloseCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
         ExitApp();
      }

      public override void initialize( )
      {
         AV13cUsuariosId = "";
         P00CB2_A18SecUserId = new long[1] ;
         P00CB2_A550SecUserEstado = new string[] {""} ;
         P00CB2_n550SecUserEstado = new bool[] {false} ;
         P00CB2_A145usuariosId = new string[] {""} ;
         P00CB2_n145usuariosId = new bool[] {false} ;
         A550SecUserEstado = "";
         A145usuariosId = "";
         P00CB4_A145usuariosId = new string[] {""} ;
         P00CB4_n145usuariosId = new bool[] {false} ;
         P00CB4_A226usuariosEstado = new string[] {""} ;
         P00CB4_A240usuariosNumeroIdentidad = new string[] {""} ;
         P00CB4_A225usuariosTipo = new string[] {""} ;
         A226usuariosEstado = "";
         A240usuariosNumeroIdentidad = "";
         A225usuariosTipo = "";
         AV10NoIdentidad = "";
         P00CB6_A120ProfesionalesId = new string[] {""} ;
         P00CB6_A108EstadosGenericosId = new int[1] ;
         P00CB6_A200ProfesionalesFechaActualizado = new DateTime[] {DateTime.MinValue} ;
         A120ProfesionalesId = "";
         A200ProfesionalesFechaActualizado = (DateTime)(DateTime.MinValue);
         P00CB9_A338ProveedorDocIdentidad = new string[] {""} ;
         P00CB9_A344ProveedorEstado = new string[] {""} ;
         P00CB9_A549ProveedorFechaActualizacion = new DateTime[] {DateTime.MinValue} ;
         P00CB9_n549ProveedorFechaActualizacion = new bool[] {false} ;
         P00CB9_A133ProveedorID = new long[1] ;
         A338ProveedorDocIdentidad = "";
         A344ProveedorEstado = "";
         A549ProveedorFechaActualizacion = (DateTime)(DateTime.MinValue);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.activarcuenta__default(),
            new Object[][] {
                new Object[] {
               P00CB2_A18SecUserId, P00CB2_A550SecUserEstado, P00CB2_n550SecUserEstado, P00CB2_A145usuariosId, P00CB2_n145usuariosId
               }
               , new Object[] {
               }
               , new Object[] {
               P00CB4_A145usuariosId, P00CB4_A226usuariosEstado, P00CB4_A240usuariosNumeroIdentidad, P00CB4_A225usuariosTipo
               }
               , new Object[] {
               }
               , new Object[] {
               P00CB6_A120ProfesionalesId, P00CB6_A108EstadosGenericosId, P00CB6_A200ProfesionalesFechaActualizado
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               P00CB9_A338ProveedorDocIdentidad, P00CB9_A344ProveedorEstado, P00CB9_A549ProveedorFechaActualizacion, P00CB9_n549ProveedorFechaActualizacion, P00CB9_A133ProveedorID
               }
               , new Object[] {
               }
               , new Object[] {
               }
            }
         );
         /* GeneXus formulas. */
      }

      private int A108EstadosGenericosId ;
      private long AV8UserID ;
      private long A18SecUserId ;
      private long A133ProveedorID ;
      private string AV9Tipo ;
      private string AV11usuariosId ;
      private string AV13cUsuariosId ;
      private string A550SecUserEstado ;
      private string A145usuariosId ;
      private string A226usuariosEstado ;
      private string A240usuariosNumeroIdentidad ;
      private string A225usuariosTipo ;
      private string AV10NoIdentidad ;
      private string A120ProfesionalesId ;
      private string A338ProveedorDocIdentidad ;
      private string A344ProveedorEstado ;
      private DateTime A200ProfesionalesFechaActualizado ;
      private DateTime A549ProveedorFechaActualizacion ;
      private bool returnInSub ;
      private bool n550SecUserEstado ;
      private bool n145usuariosId ;
      private bool n549ProveedorFechaActualizacion ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private long[] P00CB2_A18SecUserId ;
      private string[] P00CB2_A550SecUserEstado ;
      private bool[] P00CB2_n550SecUserEstado ;
      private string[] P00CB2_A145usuariosId ;
      private bool[] P00CB2_n145usuariosId ;
      private string[] P00CB4_A145usuariosId ;
      private bool[] P00CB4_n145usuariosId ;
      private string[] P00CB4_A226usuariosEstado ;
      private string[] P00CB4_A240usuariosNumeroIdentidad ;
      private string[] P00CB4_A225usuariosTipo ;
      private string[] P00CB6_A120ProfesionalesId ;
      private int[] P00CB6_A108EstadosGenericosId ;
      private DateTime[] P00CB6_A200ProfesionalesFechaActualizado ;
      private string[] P00CB9_A338ProveedorDocIdentidad ;
      private string[] P00CB9_A344ProveedorEstado ;
      private DateTime[] P00CB9_A549ProveedorFechaActualizacion ;
      private bool[] P00CB9_n549ProveedorFechaActualizacion ;
      private long[] P00CB9_A133ProveedorID ;
   }

   public class activarcuenta__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new UpdateCursor(def[1])
         ,new ForEachCursor(def[2])
         ,new UpdateCursor(def[3])
         ,new ForEachCursor(def[4])
         ,new UpdateCursor(def[5])
         ,new UpdateCursor(def[6])
         ,new ForEachCursor(def[7])
         ,new UpdateCursor(def[8])
         ,new UpdateCursor(def[9])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP00CB2;
          prmP00CB2 = new Object[] {
          new ParDef("@AV8UserID",GXType.Decimal,10,0)
          };
          Object[] prmP00CB3;
          prmP00CB3 = new Object[] {
          new ParDef("@SecUserEstado",GXType.NChar,3,0){Nullable=true} ,
          new ParDef("@SecUserId",GXType.Decimal,10,0)
          };
          Object[] prmP00CB4;
          prmP00CB4 = new Object[] {
          new ParDef("@AV11usuariosId",GXType.Char,20,0)
          };
          Object[] prmP00CB5;
          prmP00CB5 = new Object[] {
          new ParDef("@usuariosEstado",GXType.NChar,3,0) ,
          new ParDef("@usuariosId",GXType.NChar,20,0){Nullable=true}
          };
          Object[] prmP00CB6;
          prmP00CB6 = new Object[] {
          new ParDef("@AV10NoIdentidad",GXType.Char,20,0)
          };
          Object[] prmP00CB7;
          prmP00CB7 = new Object[] {
          new ParDef("@EstadosGenericosId",GXType.Int32,5,0) ,
          new ParDef("@ProfesionalesFechaActualizado",GXType.DateTime,8,5) ,
          new ParDef("@ProfesionalesId",GXType.Char,20,0)
          };
          Object[] prmP00CB8;
          prmP00CB8 = new Object[] {
          new ParDef("@EstadosGenericosId",GXType.Int32,5,0) ,
          new ParDef("@ProfesionalesFechaActualizado",GXType.DateTime,8,5) ,
          new ParDef("@ProfesionalesId",GXType.Char,20,0)
          };
          Object[] prmP00CB9;
          prmP00CB9 = new Object[] {
          new ParDef("@AV10NoIdentidad",GXType.NChar,20,0)
          };
          Object[] prmP00CB10;
          prmP00CB10 = new Object[] {
          new ParDef("@ProveedorEstado",GXType.NChar,3,0) ,
          new ParDef("@ProveedorFechaActualizacion",GXType.DateTime,8,5){Nullable=true} ,
          new ParDef("@ProveedorID",GXType.Decimal,18,0)
          };
          Object[] prmP00CB11;
          prmP00CB11 = new Object[] {
          new ParDef("@ProveedorEstado",GXType.NChar,3,0) ,
          new ParDef("@ProveedorFechaActualizacion",GXType.DateTime,8,5){Nullable=true} ,
          new ParDef("@ProveedorID",GXType.Decimal,18,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00CB2", "SELECT [SecUserId], [SecUserEstado], [usuariosId] FROM [SecUser] WITH (UPDLOCK) WHERE [SecUserId] = @AV8UserID ORDER BY [SecUserId] ",true, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00CB2,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("P00CB3", "UPDATE [SecUser] SET [SecUserEstado]=@SecUserEstado  WHERE [SecUserId] = @SecUserId", GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP00CB3)
             ,new CursorDef("P00CB4", "SELECT [usuariosId], [usuariosEstado], [usuariosNumeroIdentidad], [usuariosTipo] FROM [usuarios] WITH (UPDLOCK) WHERE UPPER(RTRIM(LTRIM([usuariosId]))) = UPPER(RTRIM(LTRIM(@AV11usuariosId))) ORDER BY [usuariosId] ",true, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00CB4,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00CB5", "UPDATE [usuarios] SET [usuariosEstado]=@usuariosEstado  WHERE [usuariosId] = @usuariosId", GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP00CB5)
             ,new CursorDef("P00CB6", "SELECT TOP 1 [ProfesionalesId], [EstadosGenericosId], [ProfesionalesFechaActualizado] FROM [Profesionales] WITH (UPDLOCK) WHERE RTRIM(LTRIM([ProfesionalesId])) = RTRIM(LTRIM(@AV10NoIdentidad)) ORDER BY [ProfesionalesId] ",true, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00CB6,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("P00CB7", "UPDATE [Profesionales] SET [EstadosGenericosId]=@EstadosGenericosId, [ProfesionalesFechaActualizado]=@ProfesionalesFechaActualizado  WHERE [ProfesionalesId] = @ProfesionalesId", GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP00CB7)
             ,new CursorDef("P00CB8", "UPDATE [Profesionales] SET [EstadosGenericosId]=@EstadosGenericosId, [ProfesionalesFechaActualizado]=@ProfesionalesFechaActualizado  WHERE [ProfesionalesId] = @ProfesionalesId", GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP00CB8)
             ,new CursorDef("P00CB9", "SELECT TOP 1 [ProveedorDocIdentidad], [ProveedorEstado], [ProveedorFechaActualizacion], [ProveedorID] FROM [Proveedor] WITH (UPDLOCK) WHERE RTRIM(LTRIM([ProveedorDocIdentidad])) = RTRIM(LTRIM(@AV10NoIdentidad)) ORDER BY [ProveedorID] ",true, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00CB9,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("P00CB10", "UPDATE [Proveedor] SET [ProveedorEstado]=@ProveedorEstado, [ProveedorFechaActualizacion]=@ProveedorFechaActualizacion  WHERE [ProveedorID] = @ProveedorID", GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP00CB10)
             ,new CursorDef("P00CB11", "UPDATE [Proveedor] SET [ProveedorEstado]=@ProveedorEstado, [ProveedorFechaActualizacion]=@ProveedorFechaActualizacion  WHERE [ProveedorID] = @ProveedorID", GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP00CB11)
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
                ((string[]) buf[1])[0] = rslt.getString(2, 3);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getString(3, 20);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                return;
             case 2 :
                ((string[]) buf[0])[0] = rslt.getString(1, 20);
                ((string[]) buf[1])[0] = rslt.getString(2, 3);
                ((string[]) buf[2])[0] = rslt.getString(3, 20);
                ((string[]) buf[3])[0] = rslt.getString(4, 1);
                return;
             case 4 :
                ((string[]) buf[0])[0] = rslt.getString(1, 20);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((DateTime[]) buf[2])[0] = rslt.getGXDateTime(3);
                return;
             case 7 :
                ((string[]) buf[0])[0] = rslt.getString(1, 25);
                ((string[]) buf[1])[0] = rslt.getString(2, 3);
                ((DateTime[]) buf[2])[0] = rslt.getGXDateTime(3);
                ((bool[]) buf[3])[0] = rslt.wasNull(3);
                ((long[]) buf[4])[0] = rslt.getLong(4);
                return;
       }
    }

 }

}

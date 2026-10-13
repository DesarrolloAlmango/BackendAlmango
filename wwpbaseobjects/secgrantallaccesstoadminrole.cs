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
namespace GeneXus.Programs.wwpbaseobjects {
   public class secgrantallaccesstoadminrole : GXProcedure
   {
      public secgrantallaccesstoadminrole( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public secgrantallaccesstoadminrole( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_SecRoleName ,
                           bool aP1_AssignRoleToUser ,
                           string aP2_SecUserName )
      {
         this.AV12SecRoleName = aP0_SecRoleName;
         this.AV8AssignRoleToUser = aP1_AssignRoleToUser;
         this.AV11SecUserName = aP2_SecUserName;
         initialize();
         ExecutePrivate();
      }

      public void executeSubmit( string aP0_SecRoleName ,
                                 bool aP1_AssignRoleToUser ,
                                 string aP2_SecUserName )
      {
         this.AV12SecRoleName = aP0_SecRoleName;
         this.AV8AssignRoleToUser = aP1_AssignRoleToUser;
         this.AV11SecUserName = aP2_SecUserName;
         SubmitImpl();
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV11SecUserName = StringUtil.Upper( AV11SecUserName);
         AV15GXLvl3 = 0;
         /* Using cursor P002H2 */
         pr_default.execute(0, new Object[] {AV12SecRoleName});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A25SecRoleName = P002H2_A25SecRoleName[0];
            A16SecRoleId = P002H2_A16SecRoleId[0];
            AV15GXLvl3 = 1;
            AV9SecRoleId = A16SecRoleId;
            /* Execute user subroutine: 'GRANTACCESS' */
            S111 ();
            if ( returnInSub )
            {
               pr_default.close(0);
               cleanup();
               if (true) return;
            }
            /* Exit For each command. Update data (if necessary), close cursors & exit. */
            if (true) break;
            pr_default.readNext(0);
         }
         pr_default.close(0);
         if ( AV15GXLvl3 == 0 )
         {
            context.StatusMessage( StringUtil.Format( "Creating role '%1'...", AV12SecRoleName, "", "", "", "", "", "", "", "") );
            /*
               INSERT RECORD ON TABLE SecRole

            */
            A25SecRoleName = AV12SecRoleName;
            A24SecRoleDescription = AV12SecRoleName;
            /* Using cursor P002H3 */
            pr_default.execute(1, new Object[] {A25SecRoleName, A24SecRoleDescription});
            A16SecRoleId = P002H3_A16SecRoleId[0];
            pr_default.close(1);
            pr_default.SmartCacheProvider.SetUpdated("SecRole");
            if ( (pr_default.getStatus(1) == 1) )
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
            /* Using cursor P002H4 */
            pr_default.execute(2, new Object[] {AV12SecRoleName});
            while ( (pr_default.getStatus(2) != 101) )
            {
               A25SecRoleName = P002H4_A25SecRoleName[0];
               A16SecRoleId = P002H4_A16SecRoleId[0];
               AV9SecRoleId = A16SecRoleId;
               /* Execute user subroutine: 'GRANTACCESS' */
               S111 ();
               if ( returnInSub )
               {
                  pr_default.close(2);
                  cleanup();
                  if (true) return;
               }
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               if (true) break;
               pr_default.readNext(2);
            }
            pr_default.close(2);
         }
         if ( AV8AssignRoleToUser )
         {
            AV17GXLvl23 = 0;
            /* Using cursor P002H5 */
            pr_default.execute(3, new Object[] {AV11SecUserName});
            while ( (pr_default.getStatus(3) != 101) )
            {
               A26SecUserName = P002H5_A26SecUserName[0];
               A18SecUserId = P002H5_A18SecUserId[0];
               AV17GXLvl23 = 1;
               AV10SecUserId = A18SecUserId;
               /* Execute user subroutine: 'ASSIGNROLE' */
               S121 ();
               if ( returnInSub )
               {
                  pr_default.close(3);
                  cleanup();
                  if (true) return;
               }
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               if (true) break;
               pr_default.readNext(3);
            }
            pr_default.close(3);
            if ( AV17GXLvl23 == 0 )
            {
               context.StatusMessage( StringUtil.Format( "Creating user '%1'...", AV11SecUserName, "", "", "", "", "", "", "", "") );
               GXt_char1 = AV14Enc;
               new pencripta(context ).execute(  StringUtil.Trim( AV11SecUserName), out  GXt_char1) ;
               AV14Enc = GXt_char1;
               /*
                  INSERT RECORD ON TABLE Pais

               */
               A116PaisID = context.GetMessage( "UY", "");
               A165PaisNombre = context.GetMessage( "Uruguay", "");
               /* Using cursor P002H6 */
               pr_default.execute(4, new Object[] {A116PaisID, A165PaisNombre});
               pr_default.close(4);
               pr_default.SmartCacheProvider.SetUpdated("Pais");
               if ( (pr_default.getStatus(4) == 1) )
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
               context.CommitDataStores("wwpbaseobjects.secgrantallaccesstoadminrole",pr_default);
               /*
                  INSERT RECORD ON TABLE usuarios

               */
               A145usuariosId = AV11SecUserName;
               n145usuariosId = false;
               A225usuariosTipo = context.GetMessage( "A", "");
               A116PaisID = context.GetMessage( "UY", "");
               A223usuariosPasw = AV14Enc;
               A222usuariosNombre = AV11SecUserName;
               A226usuariosEstado = "HAB";
               /* Using cursor P002H7 */
               pr_default.execute(5, new Object[] {n145usuariosId, A145usuariosId, A225usuariosTipo, A222usuariosNombre, A116PaisID, A223usuariosPasw, A226usuariosEstado});
               pr_default.close(5);
               pr_default.SmartCacheProvider.SetUpdated("usuarios");
               if ( (pr_default.getStatus(5) == 1) )
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
               context.CommitDataStores("wwpbaseobjects.secgrantallaccesstoadminrole",pr_default);
               /*
                  INSERT RECORD ON TABLE SecUser

               */
               A26SecUserName = AV11SecUserName;
               A27SecUserPassword = AV14Enc;
               A145usuariosId = AV11SecUserName;
               n145usuariosId = false;
               A550SecUserEstado = "HAB";
               n550SecUserEstado = false;
               /* Using cursor P002H8 */
               pr_default.execute(6, new Object[] {A26SecUserName, A27SecUserPassword, n145usuariosId, A145usuariosId, n550SecUserEstado, A550SecUserEstado});
               A18SecUserId = P002H8_A18SecUserId[0];
               pr_default.close(6);
               pr_default.SmartCacheProvider.SetUpdated("SecUser");
               if ( (pr_default.getStatus(6) == 1) )
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
               context.CommitDataStores("wwpbaseobjects.secgrantallaccesstoadminrole",pr_default);
               /* Using cursor P002H9 */
               pr_default.execute(7, new Object[] {AV11SecUserName});
               while ( (pr_default.getStatus(7) != 101) )
               {
                  A26SecUserName = P002H9_A26SecUserName[0];
                  A18SecUserId = P002H9_A18SecUserId[0];
                  AV10SecUserId = A18SecUserId;
                  /* Execute user subroutine: 'ASSIGNROLE' */
                  S121 ();
                  if ( returnInSub )
                  {
                     pr_default.close(7);
                     cleanup();
                     if (true) return;
                  }
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
                  pr_default.readNext(7);
               }
               pr_default.close(7);
               context.CommitDataStores("wwpbaseobjects.secgrantallaccesstoadminrole",pr_default);
            }
         }
         cleanup();
      }

      protected void S111( )
      {
         /* 'GRANTACCESS' Routine */
         returnInSub = false;
         /* Using cursor P002H10 */
         pr_default.execute(8);
         while ( (pr_default.getStatus(8) != 101) )
         {
            A13SecFunctionalityId = P002H10_A13SecFunctionalityId[0];
            A20SecFunctionalityDescription = P002H10_A20SecFunctionalityDescription[0];
            A15SecFunctionalityKey = P002H10_A15SecFunctionalityKey[0];
            AV20GXLvl67 = 0;
            /* Using cursor P002H11 */
            pr_default.execute(9, new Object[] {A13SecFunctionalityId, AV9SecRoleId});
            while ( (pr_default.getStatus(9) != 101) )
            {
               A16SecRoleId = P002H11_A16SecRoleId[0];
               AV20GXLvl67 = 1;
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(9);
            if ( AV20GXLvl67 == 0 )
            {
               context.StatusMessage( StringUtil.Format( "Adding functionality '%1' to role '%2'...", A15SecFunctionalityKey, AV12SecRoleName, "", "", "", "", "", "", "") );
               /*
                  INSERT RECORD ON TABLE SecFunctionalityRole

               */
               W13SecFunctionalityId = A13SecFunctionalityId;
               A16SecRoleId = AV9SecRoleId;
               /* Using cursor P002H12 */
               pr_default.execute(10, new Object[] {A13SecFunctionalityId, A16SecRoleId});
               pr_default.close(10);
               pr_default.SmartCacheProvider.SetUpdated("SecFunctionalityRole");
               if ( (pr_default.getStatus(10) == 1) )
               {
                  context.Gx_err = 1;
                  Gx_emsg = (string)(context.GetMessage( "GXM_noupdate", ""));
               }
               else
               {
                  context.Gx_err = 0;
                  Gx_emsg = "";
               }
               A13SecFunctionalityId = W13SecFunctionalityId;
               /* End Insert */
            }
            pr_default.readNext(8);
         }
         pr_default.close(8);
         context.CommitDataStores("wwpbaseobjects.secgrantallaccesstoadminrole",pr_default);
      }

      protected void S121( )
      {
         /* 'ASSIGNROLE' Routine */
         returnInSub = false;
         AV21GXLvl83 = 0;
         /* Using cursor P002H13 */
         pr_default.execute(11, new Object[] {AV10SecUserId, AV9SecRoleId});
         while ( (pr_default.getStatus(11) != 101) )
         {
            A18SecUserId = P002H13_A18SecUserId[0];
            A16SecRoleId = P002H13_A16SecRoleId[0];
            AV21GXLvl83 = 1;
            /* Exit For each command. Update data (if necessary), close cursors & exit. */
            if (true) break;
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(11);
         if ( AV21GXLvl83 == 0 )
         {
            context.StatusMessage( StringUtil.Format( "Adding role '%1' to user '%2'...", AV12SecRoleName, AV11SecUserName, "", "", "", "", "", "", "") );
            /*
               INSERT RECORD ON TABLE SecUserRole

            */
            A16SecRoleId = AV9SecRoleId;
            A18SecUserId = AV10SecUserId;
            A551SecUserRoleEstado = "HAB";
            /* Using cursor P002H14 */
            pr_default.execute(12, new Object[] {A18SecUserId, A16SecRoleId, A551SecUserRoleEstado});
            pr_default.close(12);
            pr_default.SmartCacheProvider.SetUpdated("SecUserRole");
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
         }
         context.CommitDataStores("wwpbaseobjects.secgrantallaccesstoadminrole",pr_default);
      }

      public override void cleanup( )
      {
         context.CommitDataStores("wwpbaseobjects.secgrantallaccesstoadminrole",pr_default);
         CloseCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
         ExitApp();
      }

      public override void initialize( )
      {
         P002H2_A25SecRoleName = new string[] {""} ;
         P002H2_A16SecRoleId = new short[1] ;
         A25SecRoleName = "";
         A24SecRoleDescription = "";
         P002H3_A16SecRoleId = new short[1] ;
         Gx_emsg = "";
         P002H4_A25SecRoleName = new string[] {""} ;
         P002H4_A16SecRoleId = new short[1] ;
         P002H5_A26SecUserName = new string[] {""} ;
         P002H5_A18SecUserId = new long[1] ;
         A26SecUserName = "";
         AV14Enc = "";
         GXt_char1 = "";
         A116PaisID = "";
         A165PaisNombre = "";
         A145usuariosId = "";
         A225usuariosTipo = "";
         A223usuariosPasw = "";
         A222usuariosNombre = "";
         A226usuariosEstado = "";
         A27SecUserPassword = "";
         A550SecUserEstado = "";
         P002H8_A18SecUserId = new long[1] ;
         P002H9_A26SecUserName = new string[] {""} ;
         P002H9_A18SecUserId = new long[1] ;
         P002H10_A13SecFunctionalityId = new long[1] ;
         P002H10_A20SecFunctionalityDescription = new string[] {""} ;
         P002H10_A15SecFunctionalityKey = new string[] {""} ;
         A20SecFunctionalityDescription = "";
         A15SecFunctionalityKey = "";
         P002H11_A13SecFunctionalityId = new long[1] ;
         P002H11_A16SecRoleId = new short[1] ;
         P002H13_A18SecUserId = new long[1] ;
         P002H13_A16SecRoleId = new short[1] ;
         A551SecUserRoleEstado = "";
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.secgrantallaccesstoadminrole__datastore1(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.secgrantallaccesstoadminrole__default(),
            new Object[][] {
                new Object[] {
               P002H2_A25SecRoleName, P002H2_A16SecRoleId
               }
               , new Object[] {
               P002H3_A16SecRoleId
               }
               , new Object[] {
               P002H4_A25SecRoleName, P002H4_A16SecRoleId
               }
               , new Object[] {
               P002H5_A26SecUserName, P002H5_A18SecUserId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               P002H8_A18SecUserId
               }
               , new Object[] {
               P002H9_A26SecUserName, P002H9_A18SecUserId
               }
               , new Object[] {
               P002H10_A13SecFunctionalityId, P002H10_A20SecFunctionalityDescription, P002H10_A15SecFunctionalityKey
               }
               , new Object[] {
               P002H11_A13SecFunctionalityId, P002H11_A16SecRoleId
               }
               , new Object[] {
               }
               , new Object[] {
               P002H13_A18SecUserId, P002H13_A16SecRoleId
               }
               , new Object[] {
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV15GXLvl3 ;
      private short A16SecRoleId ;
      private short AV9SecRoleId ;
      private short AV17GXLvl23 ;
      private short AV20GXLvl67 ;
      private short AV21GXLvl83 ;
      private int GX_INS6 ;
      private int GX_INS39 ;
      private int GX_INS45 ;
      private int GX_INS7 ;
      private int GX_INS3 ;
      private int GX_INS8 ;
      private long A18SecUserId ;
      private long AV10SecUserId ;
      private long A13SecFunctionalityId ;
      private long W13SecFunctionalityId ;
      private string Gx_emsg ;
      private string AV14Enc ;
      private string GXt_char1 ;
      private string A116PaisID ;
      private string A165PaisNombre ;
      private string A145usuariosId ;
      private string A225usuariosTipo ;
      private string A223usuariosPasw ;
      private string A222usuariosNombre ;
      private string A226usuariosEstado ;
      private string A550SecUserEstado ;
      private string A551SecUserRoleEstado ;
      private bool AV8AssignRoleToUser ;
      private bool returnInSub ;
      private bool n145usuariosId ;
      private bool n550SecUserEstado ;
      private string AV12SecRoleName ;
      private string AV11SecUserName ;
      private string A25SecRoleName ;
      private string A24SecRoleDescription ;
      private string A26SecUserName ;
      private string A27SecUserPassword ;
      private string A20SecFunctionalityDescription ;
      private string A15SecFunctionalityKey ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] P002H2_A25SecRoleName ;
      private short[] P002H2_A16SecRoleId ;
      private short[] P002H3_A16SecRoleId ;
      private string[] P002H4_A25SecRoleName ;
      private short[] P002H4_A16SecRoleId ;
      private string[] P002H5_A26SecUserName ;
      private long[] P002H5_A18SecUserId ;
      private long[] P002H8_A18SecUserId ;
      private string[] P002H9_A26SecUserName ;
      private long[] P002H9_A18SecUserId ;
      private long[] P002H10_A13SecFunctionalityId ;
      private string[] P002H10_A20SecFunctionalityDescription ;
      private string[] P002H10_A15SecFunctionalityKey ;
      private long[] P002H11_A13SecFunctionalityId ;
      private short[] P002H11_A16SecRoleId ;
      private long[] P002H13_A18SecUserId ;
      private short[] P002H13_A16SecRoleId ;
      private IDataStoreProvider pr_datastore1 ;
   }

   public class secgrantallaccesstoadminrole__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class secgrantallaccesstoadminrole__default : DataStoreHelperBase, IDataStoreHelper
 {
    public ICursor[] getCursors( )
    {
       cursorDefinitions();
       return new Cursor[] {
        new ForEachCursor(def[0])
       ,new ForEachCursor(def[1])
       ,new ForEachCursor(def[2])
       ,new ForEachCursor(def[3])
       ,new UpdateCursor(def[4])
       ,new UpdateCursor(def[5])
       ,new ForEachCursor(def[6])
       ,new ForEachCursor(def[7])
       ,new ForEachCursor(def[8])
       ,new ForEachCursor(def[9])
       ,new UpdateCursor(def[10])
       ,new ForEachCursor(def[11])
       ,new UpdateCursor(def[12])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmP002H2;
        prmP002H2 = new Object[] {
        new ParDef("@AV12SecRoleName",GXType.NVarChar,40,0)
        };
        Object[] prmP002H3;
        prmP002H3 = new Object[] {
        new ParDef("@SecRoleName",GXType.NVarChar,40,0) ,
        new ParDef("@SecRoleDescription",GXType.NVarChar,120,0)
        };
        Object[] prmP002H4;
        prmP002H4 = new Object[] {
        new ParDef("@AV12SecRoleName",GXType.NVarChar,40,0)
        };
        Object[] prmP002H5;
        prmP002H5 = new Object[] {
        new ParDef("@AV11SecUserName",GXType.NVarChar,100,0)
        };
        Object[] prmP002H6;
        prmP002H6 = new Object[] {
        new ParDef("@PaisID",GXType.NChar,2,0) ,
        new ParDef("@PaisNombre",GXType.NChar,80,0)
        };
        Object[] prmP002H7;
        prmP002H7 = new Object[] {
        new ParDef("@usuariosId",GXType.NChar,20,0){Nullable=true} ,
        new ParDef("@usuariosTipo",GXType.NChar,1,0) ,
        new ParDef("@usuariosNombre",GXType.NChar,80,0) ,
        new ParDef("@PaisID",GXType.NChar,2,0) ,
        new ParDef("@usuariosPasw",GXType.NChar,80,0) ,
        new ParDef("@usuariosEstado",GXType.NChar,3,0)
        };
        Object[] prmP002H8;
        prmP002H8 = new Object[] {
        new ParDef("@SecUserName",GXType.NVarChar,100,0) ,
        new ParDef("@SecUserPassword",GXType.NVarChar,100,0) ,
        new ParDef("@usuariosId",GXType.NChar,20,0){Nullable=true} ,
        new ParDef("@SecUserEstado",GXType.NChar,3,0){Nullable=true}
        };
        Object[] prmP002H9;
        prmP002H9 = new Object[] {
        new ParDef("@AV11SecUserName",GXType.NVarChar,100,0)
        };
        Object[] prmP002H10;
        prmP002H10 = new Object[] {
        };
        Object[] prmP002H11;
        prmP002H11 = new Object[] {
        new ParDef("@SecFunctionalityId",GXType.Decimal,10,0) ,
        new ParDef("@AV9SecRoleId",GXType.Int16,4,0)
        };
        Object[] prmP002H12;
        prmP002H12 = new Object[] {
        new ParDef("@SecFunctionalityId",GXType.Decimal,10,0) ,
        new ParDef("@SecRoleId",GXType.Int16,4,0)
        };
        Object[] prmP002H13;
        prmP002H13 = new Object[] {
        new ParDef("@AV10SecUserId",GXType.Decimal,10,0) ,
        new ParDef("@AV9SecRoleId",GXType.Int16,4,0)
        };
        Object[] prmP002H14;
        prmP002H14 = new Object[] {
        new ParDef("@SecUserId",GXType.Decimal,10,0) ,
        new ParDef("@SecRoleId",GXType.Int16,4,0) ,
        new ParDef("@SecUserRoleEstado",GXType.NChar,3,0)
        };
        def= new CursorDef[] {
            new CursorDef("P002H2", "SELECT TOP 1 [SecRoleName], [SecRoleId] FROM [SecRole] WHERE [SecRoleName] = @AV12SecRoleName ORDER BY [SecRoleId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP002H2,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("P002H3", "INSERT INTO [SecRole]([SecRoleName], [SecRoleDescription]) VALUES(@SecRoleName, @SecRoleDescription); SELECT SCOPE_IDENTITY()",false, GxErrorMask.GX_NOMASK, false, this,prmP002H3,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("P002H4", "SELECT TOP 1 [SecRoleName], [SecRoleId] FROM [SecRole] WHERE [SecRoleName] = @AV12SecRoleName ORDER BY [SecRoleId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP002H4,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("P002H5", "SELECT TOP 1 [SecUserName], [SecUserId] FROM [SecUser] WHERE [SecUserName] = @AV11SecUserName ORDER BY [SecUserId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP002H5,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("P002H6", "INSERT INTO [Pais]([PaisID], [PaisNombre], [PaisBandera], [PaisBandera_GXI]) VALUES(@PaisID, @PaisNombre, CONVERT(varbinary(1), ''), '')", GxErrorMask.GX_NOMASK,prmP002H6)
           ,new CursorDef("P002H7", "INSERT INTO [usuarios]([usuariosId], [usuariosTipo], [usuariosNombre], [PaisID], [usuariosPasw], [usuariosEstado], [usuariosCorreo], [usuariosDireccion], [usuariosImagen], [usuariosImagen_GXI], [usuariosCPostal], [usuariosTelefono], [usuariosEstadoOnOffLine], [usuariosFechaEstadoOnOff], [usuariosHoraEstadoOnOff], [usuariosNumeroIdentidad]) VALUES(@usuariosId, @usuariosTipo, @usuariosNombre, @PaisID, @usuariosPasw, @usuariosEstado, '', '', CONVERT(varbinary(1), ''), '', convert(int, 0), '', '', convert( DATETIME, '17530101', 112 ), convert( DATETIME, '17530101', 112 ), '')", GxErrorMask.GX_NOMASK,prmP002H7)
           ,new CursorDef("P002H8", "INSERT INTO [SecUser]([SecUserName], [SecUserPassword], [usuariosId], [SecUserEstado], [SecUserFullName]) VALUES(@SecUserName, @SecUserPassword, @usuariosId, @SecUserEstado, ''); SELECT SCOPE_IDENTITY()",false, GxErrorMask.GX_NOMASK, false, this,prmP002H8,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("P002H9", "SELECT TOP 1 [SecUserName], [SecUserId] FROM [SecUser] WHERE [SecUserName] = @AV11SecUserName ORDER BY [SecUserId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP002H9,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("P002H10", "SELECT [SecFunctionalityId], [SecFunctionalityDescription], [SecFunctionalityKey] FROM [SecFunctionality] ORDER BY [SecFunctionalityId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP002H10,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("P002H11", "SELECT [SecFunctionalityId], [SecRoleId] FROM [SecFunctionalityRole] WHERE [SecFunctionalityId] = @SecFunctionalityId and [SecRoleId] = @AV9SecRoleId ORDER BY [SecFunctionalityId], [SecRoleId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP002H11,1, GxCacheFrequency.OFF ,false,true )
           ,new CursorDef("P002H12", "INSERT INTO [SecFunctionalityRole]([SecFunctionalityId], [SecRoleId]) VALUES(@SecFunctionalityId, @SecRoleId)", GxErrorMask.GX_NOMASK,prmP002H12)
           ,new CursorDef("P002H13", "SELECT TOP 1 [SecUserId], [SecRoleId] FROM [SecUserRole] WHERE [SecUserId] = @AV10SecUserId and [SecRoleId] = @AV9SecRoleId ORDER BY [SecUserId], [SecRoleId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP002H13,1, GxCacheFrequency.OFF ,false,true )
           ,new CursorDef("P002H14", "INSERT INTO [SecUserRole]([SecUserId], [SecRoleId], [SecUserRoleEstado]) VALUES(@SecUserId, @SecRoleId, @SecUserRoleEstado)", GxErrorMask.GX_NOMASK,prmP002H14)
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
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              return;
           case 1 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              return;
           case 2 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              return;
           case 3 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              return;
           case 6 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 7 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              return;
           case 8 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              return;
           case 9 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              return;
           case 11 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              return;
     }
  }

}

}

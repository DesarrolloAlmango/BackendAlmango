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
   public class procautomatico : GXProcedure
   {
      public procautomatico( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public procautomatico( IGxContext context )
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
         AV22GXLvl1 = 0;
         /* Using cursor P009E2 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            A25SecRoleName = P009E2_A25SecRoleName[0];
            A16SecRoleId = P009E2_A16SecRoleId[0];
            if ( StringUtil.StrCmp(A25SecRoleName, context.GetMessage( "ADM GENERAL", "")) == 0 )
            {
               AV22GXLvl1 = 1;
            }
            pr_default.readNext(0);
         }
         pr_default.close(0);
         if ( AV22GXLvl1 == 0 )
         {
            /*
               INSERT RECORD ON TABLE SecRole

            */
            A16SecRoleId = 2;
            A25SecRoleName = context.GetMessage( "ADM GENERAL", "");
            A24SecRoleDescription = context.GetMessage( "Administrador General", "");
            /* Using cursor P009E3 */
            pr_default.execute(1, new Object[] {A25SecRoleName, A24SecRoleDescription});
            A16SecRoleId = P009E3_A16SecRoleId[0];
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
         }
         AV23GXLvl11 = 0;
         /* Using cursor P009E4 */
         pr_default.execute(2);
         while ( (pr_default.getStatus(2) != 101) )
         {
            A25SecRoleName = P009E4_A25SecRoleName[0];
            A16SecRoleId = P009E4_A16SecRoleId[0];
            if ( StringUtil.StrCmp(A25SecRoleName, context.GetMessage( "AGE VENDEDOR", "")) == 0 )
            {
               AV23GXLvl11 = 1;
            }
            pr_default.readNext(2);
         }
         pr_default.close(2);
         if ( AV23GXLvl11 == 0 )
         {
            /*
               INSERT RECORD ON TABLE SecRole

            */
            A16SecRoleId = 3;
            A25SecRoleName = context.GetMessage( "AGE VENDEDOR", "");
            A24SecRoleDescription = context.GetMessage( "Agente Vendedor", "");
            /* Using cursor P009E5 */
            pr_default.execute(3, new Object[] {A25SecRoleName, A24SecRoleDescription});
            A16SecRoleId = P009E5_A16SecRoleId[0];
            pr_default.close(3);
            pr_default.SmartCacheProvider.SetUpdated("SecRole");
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
         AV24GXLvl24 = 0;
         /* Using cursor P009E6 */
         pr_default.execute(4);
         while ( (pr_default.getStatus(4) != 101) )
         {
            A25SecRoleName = P009E6_A25SecRoleName[0];
            A16SecRoleId = P009E6_A16SecRoleId[0];
            if ( StringUtil.StrCmp(A25SecRoleName, context.GetMessage( "ADM EJECUTIVO", "")) == 0 )
            {
               AV24GXLvl24 = 1;
            }
            pr_default.readNext(4);
         }
         pr_default.close(4);
         if ( AV24GXLvl24 == 0 )
         {
            /*
               INSERT RECORD ON TABLE SecRole

            */
            A16SecRoleId = 4;
            A25SecRoleName = context.GetMessage( "ADM EJECUTIVO", "");
            A24SecRoleDescription = context.GetMessage( "Administrador Ejecutivo ", "");
            /* Using cursor P009E7 */
            pr_default.execute(5, new Object[] {A25SecRoleName, A24SecRoleDescription});
            A16SecRoleId = P009E7_A16SecRoleId[0];
            pr_default.close(5);
            pr_default.SmartCacheProvider.SetUpdated("SecRole");
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
         }
         AV25GXLvl36 = 0;
         /* Using cursor P009E8 */
         pr_default.execute(6);
         while ( (pr_default.getStatus(6) != 101) )
         {
            A25SecRoleName = P009E8_A25SecRoleName[0];
            A16SecRoleId = P009E8_A16SecRoleId[0];
            if ( StringUtil.StrCmp(A25SecRoleName, context.GetMessage( "ADM COMERCIO", "")) == 0 )
            {
               AV25GXLvl36 = 1;
            }
            pr_default.readNext(6);
         }
         pr_default.close(6);
         if ( AV25GXLvl36 == 0 )
         {
            /*
               INSERT RECORD ON TABLE SecRole

            */
            A16SecRoleId = 5;
            A25SecRoleName = context.GetMessage( "ADM COMERCIO", "");
            A24SecRoleDescription = context.GetMessage( "Administrador del Comercio", "");
            /* Using cursor P009E9 */
            pr_default.execute(7, new Object[] {A25SecRoleName, A24SecRoleDescription});
            A16SecRoleId = P009E9_A16SecRoleId[0];
            pr_default.close(7);
            pr_default.SmartCacheProvider.SetUpdated("SecRole");
            if ( (pr_default.getStatus(7) == 1) )
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
         AV26GXLvl47 = 0;
         /* Using cursor P009E10 */
         pr_default.execute(8);
         while ( (pr_default.getStatus(8) != 101) )
         {
            A25SecRoleName = P009E10_A25SecRoleName[0];
            A16SecRoleId = P009E10_A16SecRoleId[0];
            if ( StringUtil.StrCmp(A25SecRoleName, context.GetMessage( "AGE COMERCIO", "")) == 0 )
            {
               AV26GXLvl47 = 1;
            }
            pr_default.readNext(8);
         }
         pr_default.close(8);
         if ( AV26GXLvl47 == 0 )
         {
            /*
               INSERT RECORD ON TABLE SecRole

            */
            A16SecRoleId = 6;
            A25SecRoleName = context.GetMessage( "AGE COMERCIO", "");
            A24SecRoleDescription = context.GetMessage( "Agente del Comercio", "");
            /* Using cursor P009E11 */
            pr_default.execute(9, new Object[] {A25SecRoleName, A24SecRoleDescription});
            A16SecRoleId = P009E11_A16SecRoleId[0];
            pr_default.close(9);
            pr_default.SmartCacheProvider.SetUpdated("SecRole");
            if ( (pr_default.getStatus(9) == 1) )
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
         /* Using cursor P009E12 */
         pr_default.execute(10);
         while ( (pr_default.getStatus(10) != 101) )
         {
            A225usuariosTipo = P009E12_A225usuariosTipo[0];
            A226usuariosEstado = P009E12_A226usuariosEstado[0];
            A145usuariosId = P009E12_A145usuariosId[0];
            A222usuariosNombre = P009E12_A222usuariosNombre[0];
            A223usuariosPasw = P009E12_A223usuariosPasw[0];
            if ( StringUtil.StrCmp(A226usuariosEstado, context.GetMessage( "HAB", "")) == 0 )
            {
               if ( StringUtil.StrCmp(A225usuariosTipo, context.GetMessage( "P", "")) == 0 )
               {
                  AV14usuariosId = A145usuariosId;
                  AV15usuariosNombre = A222usuariosNombre;
                  AV16usuariosPasw = A223usuariosPasw;
                  GXt_char1 = AV28Exite;
                  new oexisteuser(context ).execute(  AV14usuariosId,  AV14usuariosId,  "S", out  GXt_char1) ;
                  AV28Exite = GXt_char1;
                  if ( StringUtil.StrCmp(AV28Exite, context.GetMessage( "N", "")) == 0 )
                  {
                     /* Execute user subroutine: 'ALTA SECUSUARIO' */
                     S111 ();
                     if ( returnInSub )
                     {
                        pr_default.close(10);
                        cleanup();
                        if (true) return;
                     }
                  }
               }
            }
            pr_default.readNext(10);
         }
         pr_default.close(10);
         cleanup();
      }

      protected void S111( )
      {
         /* 'ALTA SECUSUARIO' Routine */
         returnInSub = false;
         AV18SecUser = new GeneXus.Programs.wwpbaseobjects.SdtSecUser(context);
         AV18SecUser.gxTpr_Secusername = AV14usuariosId;
         AV18SecUser.gxTpr_Secuserfullname = AV15usuariosNombre;
         AV18SecUser.gxTpr_Secuserpassword = AV16usuariosPasw;
         AV18SecUser.gxTpr_Usuariosid = AV14usuariosId;
         AV18SecUser.gxTpr_Secuserestado = "DES";
         AV18SecUser.Save();
         context.CommitDataStores("procautomatico",pr_default);
         AV21UserId = AV18SecUser.gxTpr_Secuserid;
         if ( AV21UserId > 0 )
         {
            /* Execute user subroutine: 'AGREGARROL' */
            S121 ();
            if (returnInSub) return;
         }
      }

      protected void S121( )
      {
         /* 'AGREGARROL' Routine */
         returnInSub = false;
         AV20SecUserRole = new GeneXus.Programs.wwpbaseobjects.SdtSecUserRole(context);
         AV20SecUserRole.gxTpr_Secuserid = AV21UserId;
         AV20SecUserRole.gxTpr_Secroleid = 5;
         AV20SecUserRole.gxTpr_Secuserroleestado = "HAB";
         AV20SecUserRole.Save();
         context.CommitDataStores("procautomatico",pr_default);
      }

      public override void cleanup( )
      {
         context.CommitDataStores("procautomatico",pr_default);
         CloseCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
         ExitApp();
      }

      public override void initialize( )
      {
         P009E2_A25SecRoleName = new string[] {""} ;
         P009E2_A16SecRoleId = new short[1] ;
         A25SecRoleName = "";
         A24SecRoleDescription = "";
         P009E3_A16SecRoleId = new short[1] ;
         Gx_emsg = "";
         P009E4_A25SecRoleName = new string[] {""} ;
         P009E4_A16SecRoleId = new short[1] ;
         P009E5_A16SecRoleId = new short[1] ;
         P009E6_A25SecRoleName = new string[] {""} ;
         P009E6_A16SecRoleId = new short[1] ;
         P009E7_A16SecRoleId = new short[1] ;
         P009E8_A25SecRoleName = new string[] {""} ;
         P009E8_A16SecRoleId = new short[1] ;
         P009E9_A16SecRoleId = new short[1] ;
         P009E10_A25SecRoleName = new string[] {""} ;
         P009E10_A16SecRoleId = new short[1] ;
         P009E11_A16SecRoleId = new short[1] ;
         P009E12_A225usuariosTipo = new string[] {""} ;
         P009E12_A226usuariosEstado = new string[] {""} ;
         P009E12_A145usuariosId = new string[] {""} ;
         P009E12_A222usuariosNombre = new string[] {""} ;
         P009E12_A223usuariosPasw = new string[] {""} ;
         A225usuariosTipo = "";
         A226usuariosEstado = "";
         A145usuariosId = "";
         A222usuariosNombre = "";
         A223usuariosPasw = "";
         AV14usuariosId = "";
         AV15usuariosNombre = "";
         AV16usuariosPasw = "";
         AV28Exite = "";
         GXt_char1 = "";
         AV18SecUser = new GeneXus.Programs.wwpbaseobjects.SdtSecUser(context);
         AV20SecUserRole = new GeneXus.Programs.wwpbaseobjects.SdtSecUserRole(context);
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.procautomatico__datastore1(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.procautomatico__default(),
            new Object[][] {
                new Object[] {
               P009E2_A25SecRoleName, P009E2_A16SecRoleId
               }
               , new Object[] {
               P009E3_A16SecRoleId
               }
               , new Object[] {
               P009E4_A25SecRoleName, P009E4_A16SecRoleId
               }
               , new Object[] {
               P009E5_A16SecRoleId
               }
               , new Object[] {
               P009E6_A25SecRoleName, P009E6_A16SecRoleId
               }
               , new Object[] {
               P009E7_A16SecRoleId
               }
               , new Object[] {
               P009E8_A25SecRoleName, P009E8_A16SecRoleId
               }
               , new Object[] {
               P009E9_A16SecRoleId
               }
               , new Object[] {
               P009E10_A25SecRoleName, P009E10_A16SecRoleId
               }
               , new Object[] {
               P009E11_A16SecRoleId
               }
               , new Object[] {
               P009E12_A225usuariosTipo, P009E12_A226usuariosEstado, P009E12_A145usuariosId, P009E12_A222usuariosNombre, P009E12_A223usuariosPasw
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV22GXLvl1 ;
      private short A16SecRoleId ;
      private short AV23GXLvl11 ;
      private short AV24GXLvl24 ;
      private short AV25GXLvl36 ;
      private short AV26GXLvl47 ;
      private int GX_INS6 ;
      private long AV21UserId ;
      private string Gx_emsg ;
      private string A225usuariosTipo ;
      private string A226usuariosEstado ;
      private string A145usuariosId ;
      private string A222usuariosNombre ;
      private string A223usuariosPasw ;
      private string AV14usuariosId ;
      private string AV15usuariosNombre ;
      private string AV16usuariosPasw ;
      private string AV28Exite ;
      private string GXt_char1 ;
      private bool returnInSub ;
      private string A25SecRoleName ;
      private string A24SecRoleDescription ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] P009E2_A25SecRoleName ;
      private short[] P009E2_A16SecRoleId ;
      private short[] P009E3_A16SecRoleId ;
      private string[] P009E4_A25SecRoleName ;
      private short[] P009E4_A16SecRoleId ;
      private short[] P009E5_A16SecRoleId ;
      private string[] P009E6_A25SecRoleName ;
      private short[] P009E6_A16SecRoleId ;
      private short[] P009E7_A16SecRoleId ;
      private string[] P009E8_A25SecRoleName ;
      private short[] P009E8_A16SecRoleId ;
      private short[] P009E9_A16SecRoleId ;
      private string[] P009E10_A25SecRoleName ;
      private short[] P009E10_A16SecRoleId ;
      private short[] P009E11_A16SecRoleId ;
      private string[] P009E12_A225usuariosTipo ;
      private string[] P009E12_A226usuariosEstado ;
      private string[] P009E12_A145usuariosId ;
      private string[] P009E12_A222usuariosNombre ;
      private string[] P009E12_A223usuariosPasw ;
      private GeneXus.Programs.wwpbaseobjects.SdtSecUser AV18SecUser ;
      private GeneXus.Programs.wwpbaseobjects.SdtSecUserRole AV20SecUserRole ;
      private IDataStoreProvider pr_datastore1 ;
   }

   public class procautomatico__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class procautomatico__default : DataStoreHelperBase, IDataStoreHelper
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
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmP009E2;
        prmP009E2 = new Object[] {
        };
        Object[] prmP009E3;
        prmP009E3 = new Object[] {
        new ParDef("@SecRoleName",GXType.NVarChar,40,0) ,
        new ParDef("@SecRoleDescription",GXType.NVarChar,120,0)
        };
        Object[] prmP009E4;
        prmP009E4 = new Object[] {
        };
        Object[] prmP009E5;
        prmP009E5 = new Object[] {
        new ParDef("@SecRoleName",GXType.NVarChar,40,0) ,
        new ParDef("@SecRoleDescription",GXType.NVarChar,120,0)
        };
        Object[] prmP009E6;
        prmP009E6 = new Object[] {
        };
        Object[] prmP009E7;
        prmP009E7 = new Object[] {
        new ParDef("@SecRoleName",GXType.NVarChar,40,0) ,
        new ParDef("@SecRoleDescription",GXType.NVarChar,120,0)
        };
        Object[] prmP009E8;
        prmP009E8 = new Object[] {
        };
        Object[] prmP009E9;
        prmP009E9 = new Object[] {
        new ParDef("@SecRoleName",GXType.NVarChar,40,0) ,
        new ParDef("@SecRoleDescription",GXType.NVarChar,120,0)
        };
        Object[] prmP009E10;
        prmP009E10 = new Object[] {
        };
        Object[] prmP009E11;
        prmP009E11 = new Object[] {
        new ParDef("@SecRoleName",GXType.NVarChar,40,0) ,
        new ParDef("@SecRoleDescription",GXType.NVarChar,120,0)
        };
        Object[] prmP009E12;
        prmP009E12 = new Object[] {
        };
        def= new CursorDef[] {
            new CursorDef("P009E2", "SELECT [SecRoleName], [SecRoleId] FROM [SecRole] ORDER BY [SecRoleId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP009E2,100, GxCacheFrequency.OFF ,false,false )
           ,new CursorDef("P009E3", "INSERT INTO [SecRole]([SecRoleName], [SecRoleDescription]) VALUES(@SecRoleName, @SecRoleDescription); SELECT SCOPE_IDENTITY()",false, GxErrorMask.GX_NOMASK, false, this,prmP009E3,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("P009E4", "SELECT [SecRoleName], [SecRoleId] FROM [SecRole] ORDER BY [SecRoleId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP009E4,100, GxCacheFrequency.OFF ,false,false )
           ,new CursorDef("P009E5", "INSERT INTO [SecRole]([SecRoleName], [SecRoleDescription]) VALUES(@SecRoleName, @SecRoleDescription); SELECT SCOPE_IDENTITY()",false, GxErrorMask.GX_NOMASK, false, this,prmP009E5,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("P009E6", "SELECT [SecRoleName], [SecRoleId] FROM [SecRole] ORDER BY [SecRoleId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP009E6,100, GxCacheFrequency.OFF ,false,false )
           ,new CursorDef("P009E7", "INSERT INTO [SecRole]([SecRoleName], [SecRoleDescription]) VALUES(@SecRoleName, @SecRoleDescription); SELECT SCOPE_IDENTITY()",false, GxErrorMask.GX_NOMASK, false, this,prmP009E7,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("P009E8", "SELECT [SecRoleName], [SecRoleId] FROM [SecRole] ORDER BY [SecRoleId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP009E8,100, GxCacheFrequency.OFF ,false,false )
           ,new CursorDef("P009E9", "INSERT INTO [SecRole]([SecRoleName], [SecRoleDescription]) VALUES(@SecRoleName, @SecRoleDescription); SELECT SCOPE_IDENTITY()",false, GxErrorMask.GX_NOMASK, false, this,prmP009E9,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("P009E10", "SELECT [SecRoleName], [SecRoleId] FROM [SecRole] ORDER BY [SecRoleId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP009E10,100, GxCacheFrequency.OFF ,false,false )
           ,new CursorDef("P009E11", "INSERT INTO [SecRole]([SecRoleName], [SecRoleDescription]) VALUES(@SecRoleName, @SecRoleDescription); SELECT SCOPE_IDENTITY()",false, GxErrorMask.GX_NOMASK, false, this,prmP009E11,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("P009E12", "SELECT [usuariosTipo], [usuariosEstado], [usuariosId], [usuariosNombre], [usuariosPasw] FROM [usuarios] ORDER BY [usuariosId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP009E12,100, GxCacheFrequency.OFF ,true,false )
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
              ((short[]) buf[0])[0] = rslt.getShort(1);
              return;
           case 4 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              return;
           case 5 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              return;
           case 6 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              return;
           case 7 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              return;
           case 8 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              return;
           case 9 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              return;
           case 10 :
              ((string[]) buf[0])[0] = rslt.getString(1, 1);
              ((string[]) buf[1])[0] = rslt.getString(2, 3);
              ((string[]) buf[2])[0] = rslt.getString(3, 20);
              ((string[]) buf[3])[0] = rslt.getString(4, 80);
              ((string[]) buf[4])[0] = rslt.getString(5, 80);
              return;
     }
  }

}

}

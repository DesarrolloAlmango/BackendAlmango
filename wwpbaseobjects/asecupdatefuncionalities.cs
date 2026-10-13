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
   public class asecupdatefuncionalities : GXProcedure
   {
      public static int Main( string[] args )
      {
         return new wwpbaseobjects.asecupdatefuncionalities().MainImpl(args); ;
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

      public asecupdatefuncionalities( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public asecupdatefuncionalities( IGxContext context )
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
         AV16RoleName = "Administrator";
         AV17AdminUserName = "Administrator";
         context.StatusMessage( StringUtil.Format( context.GetMessage( "Administrator role: '%1'", ""), AV16RoleName, "", "", "", "", "", "", "", "") );
         /* Optimized DELETE. */
         /* Using cursor P002N2 */
         pr_default.execute(0);
         pr_default.close(0);
         pr_default.SmartCacheProvider.SetUpdated("SecObjectFunctionalities");
         /* End optimized DELETE. */
         /* Optimized DELETE. */
         /* Using cursor P002N3 */
         pr_default.execute(1);
         pr_default.close(1);
         pr_default.SmartCacheProvider.SetUpdated("SecObject");
         /* End optimized DELETE. */
         /* Optimized UPDATE. */
         /* Using cursor P002N4 */
         pr_default.execute(2);
         pr_default.close(2);
         pr_default.SmartCacheProvider.SetUpdated("SecFunctionality");
         /* End optimized UPDATE. */
         context.CommitDataStores("wwpbaseobjects.secupdatefuncionalities",pr_default);
         GXt_objcol_SdtSecFunctionalitiesToLoad1 = AV8SecFunctionalitiesToLoadCollection;
         new GeneXus.Programs.wwpbaseobjects.secgetadvancedsecuritywwpfunctionalities(context ).execute( out  GXt_objcol_SdtSecFunctionalitiesToLoad1) ;
         AV8SecFunctionalitiesToLoadCollection = GXt_objcol_SdtSecFunctionalitiesToLoad1;
         AV22GXV1 = 1;
         while ( AV22GXV1 <= AV8SecFunctionalitiesToLoadCollection.Count )
         {
            AV13SecFunctionalitiesToLoad = ((GeneXus.Programs.wwpbaseobjects.SdtSecFunctionalitiesToLoad)AV8SecFunctionalitiesToLoadCollection.Item(AV22GXV1));
            AV23GXV2 = 1;
            while ( AV23GXV2 <= AV13SecFunctionalitiesToLoad.gxTpr_Secfunctionalitykeys.Count )
            {
               AV11SecFunctionalityKey = ((GeneXus.Programs.wwpbaseobjects.SdtSecFunctionalitiesToLoad_SecFunctionalityKeysItem)AV13SecFunctionalitiesToLoad.gxTpr_Secfunctionalitykeys.Item(AV23GXV2));
               AV24GXLvl36 = 0;
               /* Optimized UPDATE. */
               /* Using cursor P002N5 */
               pr_default.execute(3, new Object[] {AV11SecFunctionalityKey.gxTpr_Secfunctionalitykey});
               if ( (pr_default.getStatus(3) != 101) )
               {
                  AV24GXLvl36 = 1;
               }
               pr_default.close(3);
               pr_default.SmartCacheProvider.SetUpdated("SecFunctionality");
               /* End optimized UPDATE. */
               if ( AV24GXLvl36 == 0 )
               {
                  context.StatusMessage( StringUtil.Format( "Adding functionality '%1'...", AV11SecFunctionalityKey.gxTpr_Secfunctionalitykey, "", "", "", "", "", "", "", "") );
                  /*
                     INSERT RECORD ON TABLE SecFunctionality

                  */
                  A15SecFunctionalityKey = AV11SecFunctionalityKey.gxTpr_Secfunctionalitykey;
                  A20SecFunctionalityDescription = AV11SecFunctionalityKey.gxTpr_Secfunctionalitydsc;
                  A14SecParentFunctionalityId = 0;
                  n14SecParentFunctionalityId = false;
                  n14SecParentFunctionalityId = true;
                  A19SecFunctionalityActive = true;
                  A21SecFunctionalityType = 0;
                  /* Using cursor P002N6 */
                  pr_default.execute(4, new Object[] {A15SecFunctionalityKey, A20SecFunctionalityDescription, A21SecFunctionalityType, n14SecParentFunctionalityId, A14SecParentFunctionalityId, A19SecFunctionalityActive});
                  A13SecFunctionalityId = P002N6_A13SecFunctionalityId[0];
                  pr_default.close(4);
                  pr_default.SmartCacheProvider.SetUpdated("SecFunctionality");
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
               }
               AV23GXV2 = (int)(AV23GXV2+1);
            }
            AV22GXV1 = (int)(AV22GXV1+1);
         }
         /* Using cursor P002N7 */
         pr_default.execute(5);
         while ( (pr_default.getStatus(5) != 101) )
         {
            A13SecFunctionalityId = P002N7_A13SecFunctionalityId[0];
            A15SecFunctionalityKey = P002N7_A15SecFunctionalityKey[0];
            A19SecFunctionalityActive = P002N7_A19SecFunctionalityActive[0];
            /* Using cursor P002N8 */
            pr_default.execute(6, new Object[] {A13SecFunctionalityId});
            while ( (pr_default.getStatus(6) != 101) )
            {
               A16SecRoleId = P002N8_A16SecRoleId[0];
               A25SecRoleName = P002N8_A25SecRoleName[0];
               A25SecRoleName = P002N8_A25SecRoleName[0];
               context.StatusMessage( StringUtil.Format( "Deleting functionality '%1' from role '%2'...", A15SecFunctionalityKey, A25SecRoleName, "", "", "", "", "", "", "") );
               /* Using cursor P002N9 */
               pr_default.execute(7, new Object[] {A13SecFunctionalityId, A16SecRoleId});
               pr_default.close(7);
               pr_default.SmartCacheProvider.SetUpdated("SecFunctionalityRole");
               pr_default.readNext(6);
            }
            pr_default.close(6);
            context.StatusMessage( StringUtil.Format( "Deleting functionality '%1'...", A15SecFunctionalityKey, "", "", "", "", "", "", "", "") );
            /* Using cursor P002N10 */
            pr_default.execute(8, new Object[] {A13SecFunctionalityId});
            pr_default.close(8);
            pr_default.SmartCacheProvider.SetUpdated("SecFunctionality");
            pr_default.readNext(5);
         }
         pr_default.close(5);
         AV27GXV3 = 1;
         while ( AV27GXV3 <= AV8SecFunctionalitiesToLoadCollection.Count )
         {
            AV13SecFunctionalitiesToLoad = ((GeneXus.Programs.wwpbaseobjects.SdtSecFunctionalitiesToLoad)AV8SecFunctionalitiesToLoadCollection.Item(AV27GXV3));
            AV28GXV4 = 1;
            while ( AV28GXV4 <= AV13SecFunctionalitiesToLoad.gxTpr_Secfunctionalitykeys.Count )
            {
               AV11SecFunctionalityKey = ((GeneXus.Programs.wwpbaseobjects.SdtSecFunctionalitiesToLoad_SecFunctionalityKeysItem)AV13SecFunctionalitiesToLoad.gxTpr_Secfunctionalitykeys.Item(AV28GXV4));
               /* Using cursor P002N11 */
               pr_default.execute(9, new Object[] {AV11SecFunctionalityKey.gxTpr_Secfunctionalitykey});
               while ( (pr_default.getStatus(9) != 101) )
               {
                  A15SecFunctionalityKey = P002N11_A15SecFunctionalityKey[0];
                  A20SecFunctionalityDescription = P002N11_A20SecFunctionalityDescription[0];
                  A21SecFunctionalityType = P002N11_A21SecFunctionalityType[0];
                  A14SecParentFunctionalityId = P002N11_A14SecParentFunctionalityId[0];
                  n14SecParentFunctionalityId = P002N11_n14SecParentFunctionalityId[0];
                  A19SecFunctionalityActive = P002N11_A19SecFunctionalityActive[0];
                  A13SecFunctionalityId = P002N11_A13SecFunctionalityId[0];
                  A20SecFunctionalityDescription = AV11SecFunctionalityKey.gxTpr_Secfunctionalitydsc;
                  if ( (0==A21SecFunctionalityType) )
                  {
                     A21SecFunctionalityType = AV13SecFunctionalitiesToLoad.gxTpr_Secfunctionalitytype;
                  }
                  else
                  {
                     if ( A21SecFunctionalityType != AV13SecFunctionalitiesToLoad.gxTpr_Secfunctionalitytype )
                     {
                        A21SecFunctionalityType = 4;
                        A14SecParentFunctionalityId = 0;
                        n14SecParentFunctionalityId = false;
                        n14SecParentFunctionalityId = true;
                     }
                  }
                  if ( ( A21SecFunctionalityType != 4 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV13SecFunctionalitiesToLoad.gxTpr_Secparentfunctionalitykey)) )
                  {
                     AV12SecFunctionalityKeyToFilter = AV13SecFunctionalitiesToLoad.gxTpr_Secparentfunctionalitykey;
                     /* Execute user subroutine: 'GETFUNCTIONALITYIDBYKEY' */
                     S111 ();
                     if ( returnInSub )
                     {
                        pr_default.close(9);
                        cleanup();
                        if (true) return;
                     }
                     if ( A14SecParentFunctionalityId != AV9SecFunctionalityId )
                     {
                        if ( P002N11_n14SecParentFunctionalityId[0] && ( ! (0==AV9SecFunctionalityId) ) && A19SecFunctionalityActive )
                        {
                           A14SecParentFunctionalityId = AV9SecFunctionalityId;
                           n14SecParentFunctionalityId = false;
                        }
                        else
                        {
                           A19SecFunctionalityActive = false;
                           A14SecParentFunctionalityId = 0;
                           n14SecParentFunctionalityId = false;
                           n14SecParentFunctionalityId = true;
                        }
                     }
                  }
                  /* Using cursor P002N12 */
                  pr_default.execute(10, new Object[] {A20SecFunctionalityDescription, A21SecFunctionalityType, n14SecParentFunctionalityId, A14SecParentFunctionalityId, A19SecFunctionalityActive, A13SecFunctionalityId});
                  pr_default.close(10);
                  pr_default.SmartCacheProvider.SetUpdated("SecFunctionality");
                  /* Exiting from a For First loop. */
                  if (true) break;
               }
               pr_default.close(9);
               AV28GXV4 = (int)(AV28GXV4+1);
            }
            AV27GXV3 = (int)(AV27GXV3+1);
         }
         /* Optimized UPDATE. */
         /* Using cursor P002N13 */
         pr_default.execute(11);
         pr_default.close(11);
         pr_default.SmartCacheProvider.SetUpdated("SecFunctionality");
         /* End optimized UPDATE. */
         AV31GXV5 = 1;
         while ( AV31GXV5 <= AV8SecFunctionalitiesToLoadCollection.Count )
         {
            AV13SecFunctionalitiesToLoad = ((GeneXus.Programs.wwpbaseobjects.SdtSecFunctionalitiesToLoad)AV8SecFunctionalitiesToLoadCollection.Item(AV31GXV5));
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV13SecFunctionalitiesToLoad.gxTpr_Secobjectname)) )
            {
               /*
                  INSERT RECORD ON TABLE SecObject

               */
               A17SecObjectName = StringUtil.Trim( StringUtil.Lower( AV13SecFunctionalitiesToLoad.gxTpr_Secobjectname));
               /* Using cursor P002N14 */
               pr_default.execute(12, new Object[] {A17SecObjectName});
               pr_default.close(12);
               pr_default.SmartCacheProvider.SetUpdated("SecObject");
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
               AV32GXV6 = 1;
               while ( AV32GXV6 <= AV13SecFunctionalitiesToLoad.gxTpr_Secfunctionalitykeys.Count )
               {
                  AV11SecFunctionalityKey = ((GeneXus.Programs.wwpbaseobjects.SdtSecFunctionalitiesToLoad_SecFunctionalityKeysItem)AV13SecFunctionalitiesToLoad.gxTpr_Secfunctionalitykeys.Item(AV32GXV6));
                  AV12SecFunctionalityKeyToFilter = AV11SecFunctionalityKey.gxTpr_Secfunctionalitykey;
                  /* Execute user subroutine: 'GETFUNCTIONALITYIDBYKEY' */
                  S111 ();
                  if ( returnInSub )
                  {
                     cleanup();
                     if (true) return;
                  }
                  if ( ! (0==AV9SecFunctionalityId) )
                  {
                     /*
                        INSERT RECORD ON TABLE SecObjectFunctionalities

                     */
                     A17SecObjectName = StringUtil.Trim( StringUtil.Lower( AV13SecFunctionalitiesToLoad.gxTpr_Secobjectname));
                     A13SecFunctionalityId = AV9SecFunctionalityId;
                     /* Using cursor P002N15 */
                     pr_default.execute(13, new Object[] {A17SecObjectName, A13SecFunctionalityId});
                     pr_default.close(13);
                     pr_default.SmartCacheProvider.SetUpdated("SecObjectFunctionalities");
                     if ( (pr_default.getStatus(13) == 1) )
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
                  AV32GXV6 = (int)(AV32GXV6+1);
               }
            }
            AV31GXV5 = (int)(AV31GXV5+1);
         }
         context.CommitDataStores("wwpbaseobjects.secupdatefuncionalities",pr_default);
         if ( StringUtil.StrCmp(AV16RoleName, "") != 0 )
         {
            if ( StringUtil.StrCmp(AV17AdminUserName, "") != 0 )
            {
               AV18AssignRoleToUser = true;
            }
            else
            {
               AV18AssignRoleToUser = false;
            }
            new GeneXus.Programs.wwpbaseobjects.secgrantallaccesstoadminrole(context ).execute(  AV16RoleName,  AV18AssignRoleToUser,  AV17AdminUserName) ;
         }
         cleanup();
      }

      protected void S111( )
      {
         /* 'GETFUNCTIONALITYIDBYKEY' Routine */
         returnInSub = false;
         /* Using cursor P002N17 */
         pr_default.execute(14, new Object[] {AV12SecFunctionalityKeyToFilter});
         if ( (pr_default.getStatus(14) != 101) )
         {
            A40000SecFunctionalityId = P002N17_A40000SecFunctionalityId[0];
            n40000SecFunctionalityId = P002N17_n40000SecFunctionalityId[0];
         }
         else
         {
            A40000SecFunctionalityId = 0;
            n40000SecFunctionalityId = false;
         }
         pr_default.close(14);
         AV9SecFunctionalityId = A40000SecFunctionalityId;
         if ( (0==AV9SecFunctionalityId) )
         {
            context.StatusMessage( StringUtil.Format( "Functionality '%1' not found", AV12SecFunctionalityKeyToFilter, "", "", "", "", "", "", "", "") );
         }
      }

      public override void cleanup( )
      {
         context.CommitDataStores("wwpbaseobjects.secupdatefuncionalities",pr_default);
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
         AV16RoleName = "";
         AV17AdminUserName = "";
         AV8SecFunctionalitiesToLoadCollection = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtSecFunctionalitiesToLoad>( context, "SecFunctionalitiesToLoad", "AlmangoX");
         GXt_objcol_SdtSecFunctionalitiesToLoad1 = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtSecFunctionalitiesToLoad>( context, "SecFunctionalitiesToLoad", "AlmangoX");
         AV13SecFunctionalitiesToLoad = new GeneXus.Programs.wwpbaseobjects.SdtSecFunctionalitiesToLoad(context);
         AV11SecFunctionalityKey = new GeneXus.Programs.wwpbaseobjects.SdtSecFunctionalitiesToLoad_SecFunctionalityKeysItem(context);
         A15SecFunctionalityKey = "";
         A20SecFunctionalityDescription = "";
         P002N6_A13SecFunctionalityId = new long[1] ;
         Gx_emsg = "";
         P002N7_A13SecFunctionalityId = new long[1] ;
         P002N7_A15SecFunctionalityKey = new string[] {""} ;
         P002N7_A19SecFunctionalityActive = new bool[] {false} ;
         P002N8_A13SecFunctionalityId = new long[1] ;
         P002N8_A16SecRoleId = new short[1] ;
         P002N8_A25SecRoleName = new string[] {""} ;
         A25SecRoleName = "";
         P002N11_A15SecFunctionalityKey = new string[] {""} ;
         P002N11_A20SecFunctionalityDescription = new string[] {""} ;
         P002N11_A21SecFunctionalityType = new short[1] ;
         P002N11_A14SecParentFunctionalityId = new long[1] ;
         P002N11_n14SecParentFunctionalityId = new bool[] {false} ;
         P002N11_A19SecFunctionalityActive = new bool[] {false} ;
         P002N11_A13SecFunctionalityId = new long[1] ;
         AV12SecFunctionalityKeyToFilter = "";
         A17SecObjectName = "";
         P002N17_A40000SecFunctionalityId = new long[1] ;
         P002N17_n40000SecFunctionalityId = new bool[] {false} ;
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.asecupdatefuncionalities__datastore1(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.asecupdatefuncionalities__default(),
            new Object[][] {
                new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               P002N6_A13SecFunctionalityId
               }
               , new Object[] {
               P002N7_A13SecFunctionalityId, P002N7_A15SecFunctionalityKey, P002N7_A19SecFunctionalityActive
               }
               , new Object[] {
               P002N8_A13SecFunctionalityId, P002N8_A16SecRoleId, P002N8_A25SecRoleName
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               P002N11_A15SecFunctionalityKey, P002N11_A20SecFunctionalityDescription, P002N11_A21SecFunctionalityType, P002N11_A14SecParentFunctionalityId, P002N11_n14SecParentFunctionalityId, P002N11_A19SecFunctionalityActive, P002N11_A13SecFunctionalityId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               P002N17_A40000SecFunctionalityId, P002N17_n40000SecFunctionalityId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV24GXLvl36 ;
      private short A21SecFunctionalityType ;
      private short A16SecRoleId ;
      private int AV22GXV1 ;
      private int AV23GXV2 ;
      private int GX_INS2 ;
      private int AV27GXV3 ;
      private int AV28GXV4 ;
      private int AV31GXV5 ;
      private int GX_INS4 ;
      private int AV32GXV6 ;
      private int GX_INS5 ;
      private long A14SecParentFunctionalityId ;
      private long A13SecFunctionalityId ;
      private long AV9SecFunctionalityId ;
      private long A40000SecFunctionalityId ;
      private string Gx_emsg ;
      private bool n14SecParentFunctionalityId ;
      private bool A19SecFunctionalityActive ;
      private bool returnInSub ;
      private bool AV18AssignRoleToUser ;
      private bool n40000SecFunctionalityId ;
      private string AV16RoleName ;
      private string AV17AdminUserName ;
      private string A15SecFunctionalityKey ;
      private string A20SecFunctionalityDescription ;
      private string A25SecRoleName ;
      private string AV12SecFunctionalityKeyToFilter ;
      private string A17SecObjectName ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtSecFunctionalitiesToLoad> AV8SecFunctionalitiesToLoadCollection ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtSecFunctionalitiesToLoad> GXt_objcol_SdtSecFunctionalitiesToLoad1 ;
      private GeneXus.Programs.wwpbaseobjects.SdtSecFunctionalitiesToLoad AV13SecFunctionalitiesToLoad ;
      private GeneXus.Programs.wwpbaseobjects.SdtSecFunctionalitiesToLoad_SecFunctionalityKeysItem AV11SecFunctionalityKey ;
      private long[] P002N6_A13SecFunctionalityId ;
      private long[] P002N7_A13SecFunctionalityId ;
      private string[] P002N7_A15SecFunctionalityKey ;
      private bool[] P002N7_A19SecFunctionalityActive ;
      private long[] P002N8_A13SecFunctionalityId ;
      private short[] P002N8_A16SecRoleId ;
      private string[] P002N8_A25SecRoleName ;
      private string[] P002N11_A15SecFunctionalityKey ;
      private string[] P002N11_A20SecFunctionalityDescription ;
      private short[] P002N11_A21SecFunctionalityType ;
      private long[] P002N11_A14SecParentFunctionalityId ;
      private bool[] P002N11_n14SecParentFunctionalityId ;
      private bool[] P002N11_A19SecFunctionalityActive ;
      private long[] P002N11_A13SecFunctionalityId ;
      private long[] P002N17_A40000SecFunctionalityId ;
      private bool[] P002N17_n40000SecFunctionalityId ;
      private IDataStoreProvider pr_datastore1 ;
   }

   public class asecupdatefuncionalities__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class asecupdatefuncionalities__default : DataStoreHelperBase, IDataStoreHelper
 {
    public ICursor[] getCursors( )
    {
       cursorDefinitions();
       return new Cursor[] {
        new UpdateCursor(def[0])
       ,new UpdateCursor(def[1])
       ,new UpdateCursor(def[2])
       ,new UpdateCursor(def[3])
       ,new ForEachCursor(def[4])
       ,new ForEachCursor(def[5])
       ,new ForEachCursor(def[6])
       ,new UpdateCursor(def[7])
       ,new UpdateCursor(def[8])
       ,new ForEachCursor(def[9])
       ,new UpdateCursor(def[10])
       ,new UpdateCursor(def[11])
       ,new UpdateCursor(def[12])
       ,new UpdateCursor(def[13])
       ,new ForEachCursor(def[14])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmP002N2;
        prmP002N2 = new Object[] {
        };
        Object[] prmP002N3;
        prmP002N3 = new Object[] {
        };
        Object[] prmP002N4;
        prmP002N4 = new Object[] {
        };
        Object[] prmP002N5;
        prmP002N5 = new Object[] {
        new ParDef("@AV11SecF_1Secfunctionalitykey",GXType.NVarChar,100,0)
        };
        Object[] prmP002N6;
        prmP002N6 = new Object[] {
        new ParDef("@SecFunctionalityKey",GXType.NVarChar,100,0) ,
        new ParDef("@SecFunctionalityDescription",GXType.NVarChar,100,0) ,
        new ParDef("@SecFunctionalityType",GXType.Int16,2,0) ,
        new ParDef("@SecParentFunctionalityId",GXType.Decimal,10,0){Nullable=true} ,
        new ParDef("@SecFunctionalityActive",GXType.Boolean,4,0)
        };
        Object[] prmP002N7;
        prmP002N7 = new Object[] {
        };
        Object[] prmP002N8;
        prmP002N8 = new Object[] {
        new ParDef("@SecFunctionalityId",GXType.Decimal,10,0)
        };
        Object[] prmP002N9;
        prmP002N9 = new Object[] {
        new ParDef("@SecFunctionalityId",GXType.Decimal,10,0) ,
        new ParDef("@SecRoleId",GXType.Int16,4,0)
        };
        Object[] prmP002N10;
        prmP002N10 = new Object[] {
        new ParDef("@SecFunctionalityId",GXType.Decimal,10,0)
        };
        Object[] prmP002N11;
        prmP002N11 = new Object[] {
        new ParDef("@AV11SecF_1Secfunctionalitykey",GXType.NVarChar,100,0)
        };
        Object[] prmP002N12;
        prmP002N12 = new Object[] {
        new ParDef("@SecFunctionalityDescription",GXType.NVarChar,100,0) ,
        new ParDef("@SecFunctionalityType",GXType.Int16,2,0) ,
        new ParDef("@SecParentFunctionalityId",GXType.Decimal,10,0){Nullable=true} ,
        new ParDef("@SecFunctionalityActive",GXType.Boolean,4,0) ,
        new ParDef("@SecFunctionalityId",GXType.Decimal,10,0)
        };
        Object[] prmP002N13;
        prmP002N13 = new Object[] {
        };
        Object[] prmP002N14;
        prmP002N14 = new Object[] {
        new ParDef("@SecObjectName",GXType.NVarChar,120,0)
        };
        Object[] prmP002N15;
        prmP002N15 = new Object[] {
        new ParDef("@SecObjectName",GXType.NVarChar,120,0) ,
        new ParDef("@SecFunctionalityId",GXType.Decimal,10,0)
        };
        Object[] prmP002N17;
        prmP002N17 = new Object[] {
        new ParDef("@AV12SecFunctionalityKeyToFilter",GXType.NVarChar,100,0)
        };
        def= new CursorDef[] {
            new CursorDef("P002N2", "DELETE FROM [SecObjectFunctionalities] ", GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP002N2)
           ,new CursorDef("P002N3", "DELETE FROM [SecObject] ", GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP002N3)
           ,new CursorDef("P002N4", "UPDATE [SecFunctionality] SET [SecParentFunctionalityId]=NULL, [SecFunctionalityActive]=CONVERT(BIT, 0) ", GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP002N4)
           ,new CursorDef("P002N5", "UPDATE [SecFunctionality] SET [SecFunctionalityType]=convert(int, 0), [SecFunctionalityActive]=CONVERT(BIT, 1), [SecParentFunctionalityId]=NULL  WHERE [SecFunctionalityKey] = @AV11SecF_1Secfunctionalitykey", GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP002N5)
           ,new CursorDef("P002N6", "INSERT INTO [SecFunctionality]([SecFunctionalityKey], [SecFunctionalityDescription], [SecFunctionalityType], [SecParentFunctionalityId], [SecFunctionalityActive]) VALUES(@SecFunctionalityKey, @SecFunctionalityDescription, @SecFunctionalityType, @SecParentFunctionalityId, @SecFunctionalityActive); SELECT SCOPE_IDENTITY()",false, GxErrorMask.GX_NOMASK, false, this,prmP002N6,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("P002N7", "SELECT [SecFunctionalityId], [SecFunctionalityKey], [SecFunctionalityActive] FROM [SecFunctionality] WITH (UPDLOCK) WHERE [SecFunctionalityActive] = 0 ORDER BY [SecFunctionalityId] ",true, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP002N7,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("P002N8", "SELECT T1.[SecFunctionalityId], T1.[SecRoleId], T2.[SecRoleName] FROM ([SecFunctionalityRole] T1 WITH (UPDLOCK) INNER JOIN [SecRole] T2 ON T2.[SecRoleId] = T1.[SecRoleId]) WHERE T1.[SecFunctionalityId] = @SecFunctionalityId ORDER BY T1.[SecFunctionalityId] ",true, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP002N8,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("P002N9", "DELETE FROM [SecFunctionalityRole]  WHERE [SecFunctionalityId] = @SecFunctionalityId AND [SecRoleId] = @SecRoleId", GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP002N9)
           ,new CursorDef("P002N10", "DELETE FROM [SecFunctionality]  WHERE [SecFunctionalityId] = @SecFunctionalityId", GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP002N10)
           ,new CursorDef("P002N11", "SELECT [SecFunctionalityKey], [SecFunctionalityDescription], [SecFunctionalityType], [SecParentFunctionalityId], [SecFunctionalityActive], [SecFunctionalityId] FROM [SecFunctionality] WITH (UPDLOCK) WHERE [SecFunctionalityKey] = @AV11SecF_1Secfunctionalitykey ORDER BY [SecFunctionalityKey] ",true, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP002N11,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("P002N12", "UPDATE [SecFunctionality] SET [SecFunctionalityDescription]=@SecFunctionalityDescription, [SecFunctionalityType]=@SecFunctionalityType, [SecParentFunctionalityId]=@SecParentFunctionalityId, [SecFunctionalityActive]=@SecFunctionalityActive  WHERE [SecFunctionalityId] = @SecFunctionalityId", GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP002N12)
           ,new CursorDef("P002N13", "UPDATE [SecFunctionality] SET [SecFunctionalityActive]=CONVERT(BIT, 1)  WHERE [SecFunctionalityActive] = 0", GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP002N13)
           ,new CursorDef("P002N14", "INSERT INTO [SecObject]([SecObjectName]) VALUES(@SecObjectName)", GxErrorMask.GX_NOMASK,prmP002N14)
           ,new CursorDef("P002N15", "INSERT INTO [SecObjectFunctionalities]([SecObjectName], [SecFunctionalityId]) VALUES(@SecObjectName, @SecFunctionalityId)", GxErrorMask.GX_NOMASK,prmP002N15)
           ,new CursorDef("P002N17", "SELECT COALESCE( T1.[SecFunctionalityId], 0) AS SecFunctionalityId FROM (SELECT [SecFunctionalityId] AS SecFunctionalityId, [SecFunctionalityKey] FROM [SecFunctionality] WHERE [SecFunctionalityKey] = @AV12SecFunctionalityKeyToFilter ) T1 ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP002N17,1, GxCacheFrequency.OFF ,true,true )
        };
     }
  }

  public void getResults( int cursor ,
                          IFieldGetter rslt ,
                          Object[] buf )
  {
     switch ( cursor )
     {
           case 4 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 5 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((bool[]) buf[2])[0] = rslt.getBool(3);
              return;
           case 6 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              return;
           case 9 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((short[]) buf[2])[0] = rslt.getShort(3);
              ((long[]) buf[3])[0] = rslt.getLong(4);
              ((bool[]) buf[4])[0] = rslt.wasNull(4);
              ((bool[]) buf[5])[0] = rslt.getBool(5);
              ((long[]) buf[6])[0] = rslt.getLong(6);
              return;
           case 14 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((bool[]) buf[1])[0] = rslt.wasNull(1);
              return;
     }
  }

}

}

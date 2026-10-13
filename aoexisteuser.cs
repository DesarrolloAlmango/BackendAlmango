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
   public class aoexisteuser : GXProcedure
   {
      public aoexisteuser( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public aoexisteuser( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_usuarioId ,
                           string aP1_SecUserName ,
                           string aP2_TipoUS ,
                           out string aP3_ok )
      {
         this.AV8usuarioId = aP0_usuarioId;
         this.AV11SecUserName = aP1_SecUserName;
         this.AV10TipoUS = aP2_TipoUS;
         this.AV9ok = "" ;
         initialize();
         ExecutePrivate();
         aP3_ok=this.AV9ok;
      }

      public string executeUdp( string aP0_usuarioId ,
                                string aP1_SecUserName ,
                                string aP2_TipoUS )
      {
         execute(aP0_usuarioId, aP1_SecUserName, aP2_TipoUS, out aP3_ok);
         return AV9ok ;
      }

      public void executeSubmit( string aP0_usuarioId ,
                                 string aP1_SecUserName ,
                                 string aP2_TipoUS ,
                                 out string aP3_ok )
      {
         this.AV8usuarioId = aP0_usuarioId;
         this.AV11SecUserName = aP1_SecUserName;
         this.AV10TipoUS = aP2_TipoUS;
         this.AV9ok = "" ;
         SubmitImpl();
         aP3_ok=this.AV9ok;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV9ok = context.GetMessage( "N", "");
         if ( StringUtil.StrCmp(AV10TipoUS, "U") == 0 )
         {
            /* Using cursor P008Y2 */
            pr_default.execute(0, new Object[] {AV8usuarioId});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A145usuariosId = P008Y2_A145usuariosId[0];
               n145usuariosId = P008Y2_n145usuariosId[0];
               AV9ok = context.GetMessage( "S", "");
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               if (true) break;
               pr_default.readNext(0);
            }
            pr_default.close(0);
         }
         else if ( StringUtil.StrCmp(AV10TipoUS, "V") == 0 )
         {
            /* Using cursor P008Y3 */
            pr_default.execute(1, new Object[] {AV8usuarioId});
            while ( (pr_default.getStatus(1) != 101) )
            {
               A145usuariosId = P008Y3_A145usuariosId[0];
               n145usuariosId = P008Y3_n145usuariosId[0];
               A26SecUserName = P008Y3_A26SecUserName[0];
               A18SecUserId = P008Y3_A18SecUserId[0];
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( A26SecUserName)) )
               {
                  if ( StringUtil.StrCmp(StringUtil.Trim( StringUtil.Upper( A26SecUserName)), StringUtil.Trim( StringUtil.Upper( AV11SecUserName))) != 0 )
                  {
                     AV9ok = context.GetMessage( "S", "");
                     /* Exit For each command. Update data (if necessary), close cursors & exit. */
                     if (true) break;
                  }
               }
               pr_default.readNext(1);
            }
            pr_default.close(1);
         }
         else
         {
            /* Using cursor P008Y4 */
            pr_default.execute(2, new Object[] {AV11SecUserName});
            while ( (pr_default.getStatus(2) != 101) )
            {
               A26SecUserName = P008Y4_A26SecUserName[0];
               A18SecUserId = P008Y4_A18SecUserId[0];
               AV9ok = context.GetMessage( "S", "");
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               if (true) break;
               pr_default.readNext(2);
            }
            pr_default.close(2);
         }
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

      public override void initialize( )
      {
         AV9ok = "";
         P008Y2_A145usuariosId = new string[] {""} ;
         P008Y2_n145usuariosId = new bool[] {false} ;
         A145usuariosId = "";
         P008Y3_A145usuariosId = new string[] {""} ;
         P008Y3_n145usuariosId = new bool[] {false} ;
         P008Y3_A26SecUserName = new string[] {""} ;
         P008Y3_A18SecUserId = new long[1] ;
         A26SecUserName = "";
         P008Y4_A26SecUserName = new string[] {""} ;
         P008Y4_A18SecUserId = new long[1] ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.aoexisteuser__default(),
            new Object[][] {
                new Object[] {
               P008Y2_A145usuariosId
               }
               , new Object[] {
               P008Y3_A145usuariosId, P008Y3_n145usuariosId, P008Y3_A26SecUserName, P008Y3_A18SecUserId
               }
               , new Object[] {
               P008Y4_A26SecUserName, P008Y4_A18SecUserId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private long A18SecUserId ;
      private string AV8usuarioId ;
      private string AV10TipoUS ;
      private string AV9ok ;
      private string A145usuariosId ;
      private bool n145usuariosId ;
      private string AV11SecUserName ;
      private string A26SecUserName ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] P008Y2_A145usuariosId ;
      private bool[] P008Y2_n145usuariosId ;
      private string[] P008Y3_A145usuariosId ;
      private bool[] P008Y3_n145usuariosId ;
      private string[] P008Y3_A26SecUserName ;
      private long[] P008Y3_A18SecUserId ;
      private string[] P008Y4_A26SecUserName ;
      private long[] P008Y4_A18SecUserId ;
      private string aP3_ok ;
   }

   public class aoexisteuser__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
         ,new ForEachCursor(def[2])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP008Y2;
          prmP008Y2 = new Object[] {
          new ParDef("@AV8usuarioId",GXType.Char,30,0)
          };
          Object[] prmP008Y3;
          prmP008Y3 = new Object[] {
          new ParDef("@AV8usuarioId",GXType.Char,30,0)
          };
          Object[] prmP008Y4;
          prmP008Y4 = new Object[] {
          new ParDef("@AV11SecUserName",GXType.VarChar,100,0)
          };
          def= new CursorDef[] {
              new CursorDef("P008Y2", "SELECT TOP 1 [usuariosId] FROM [usuarios] WHERE RTRIM(LTRIM(UPPER([usuariosId]))) = RTRIM(LTRIM(UPPER(@AV8usuarioId))) ORDER BY [usuariosId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP008Y2,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P008Y3", "SELECT [usuariosId], [SecUserName], [SecUserId] FROM [SecUser] WHERE RTRIM(LTRIM(UPPER([usuariosId]))) = RTRIM(LTRIM(UPPER(@AV8usuarioId))) ORDER BY [SecUserId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP008Y3,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P008Y4", "SELECT TOP 1 [SecUserName], [SecUserId] FROM [SecUser] WHERE RTRIM(LTRIM(UPPER([SecUserName]))) = RTRIM(LTRIM(UPPER(@AV11SecUserName))) ORDER BY [SecUserId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP008Y4,1, GxCacheFrequency.OFF ,false,true )
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
                return;
             case 1 :
                ((string[]) buf[0])[0] = rslt.getString(1, 20);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getVarchar(2);
                ((long[]) buf[3])[0] = rslt.getLong(3);
                return;
             case 2 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((long[]) buf[1])[0] = rslt.getLong(2);
                return;
       }
    }

 }

}

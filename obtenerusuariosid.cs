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
   public class obtenerusuariosid : GXProcedure
   {
      public obtenerusuariosid( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public obtenerusuariosid( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( long aP0_SecUserId ,
                           out long aP1_SecUserId )
      {
         this.A18SecUserId = aP0_SecUserId;
         this.AV10SecUserId = 0 ;
         initialize();
         ExecutePrivate();
         aP1_SecUserId=this.AV10SecUserId;
      }

      public long executeUdp( long aP0_SecUserId )
      {
         execute(aP0_SecUserId, out aP1_SecUserId);
         return AV10SecUserId ;
      }

      public void executeSubmit( long aP0_SecUserId ,
                                 out long aP1_SecUserId )
      {
         this.A18SecUserId = aP0_SecUserId;
         this.AV10SecUserId = 0 ;
         SubmitImpl();
         aP1_SecUserId=this.AV10SecUserId;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         if ( (0==AV10SecUserId) )
         {
            AV11GXLvl3 = 0;
            /* Using cursor P00GW2 */
            pr_default.execute(0);
            while ( (pr_default.getStatus(0) != 101) )
            {
               A237ParametrosCodigo = P00GW2_A237ParametrosCodigo[0];
               A602ParametrosValor = P00GW2_A602ParametrosValor[0];
               A283ParametrosId = P00GW2_A283ParametrosId[0];
               if ( StringUtil.StrCmp(A237ParametrosCodigo, context.GetMessage( "USERDEFAULT", "")) == 0 )
               {
                  AV11GXLvl3 = 1;
                  AV10SecUserId = (long)(Math.Round(NumberUtil.Val( A602ParametrosValor, "."), 18, MidpointRounding.ToEven));
               }
               pr_default.readNext(0);
            }
            pr_default.close(0);
            if ( AV11GXLvl3 == 0 )
            {
               /*
                  INSERT RECORD ON TABLE Parametros

               */
               A237ParametrosCodigo = context.GetMessage( "USERDEFAULT", "");
               A602ParametrosValor = "1111";
               /* Using cursor P00GW3 */
               pr_default.execute(1, new Object[] {A237ParametrosCodigo, A602ParametrosValor});
               A283ParametrosId = P00GW3_A283ParametrosId[0];
               pr_default.close(1);
               pr_default.SmartCacheProvider.SetUpdated("Parametros");
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
         }
         else
         {
            AV12GXLvl14 = 0;
            /* Using cursor P00GW4 */
            pr_default.execute(2, new Object[] {A18SecUserId});
            while ( (pr_default.getStatus(2) != 101) )
            {
               AV12GXLvl14 = 1;
               AV10SecUserId = A18SecUserId;
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(2);
            if ( AV12GXLvl14 == 0 )
            {
               AV10SecUserId = 1111;
            }
         }
         cleanup();
      }

      public override void cleanup( )
      {
         context.CommitDataStores("obtenerusuariosid",pr_default);
         CloseCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
         ExitApp();
      }

      public override void initialize( )
      {
         P00GW2_A237ParametrosCodigo = new string[] {""} ;
         P00GW2_A602ParametrosValor = new string[] {""} ;
         P00GW2_A283ParametrosId = new long[1] ;
         A237ParametrosCodigo = "";
         A602ParametrosValor = "";
         P00GW3_A283ParametrosId = new long[1] ;
         Gx_emsg = "";
         P00GW4_A18SecUserId = new long[1] ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.obtenerusuariosid__default(),
            new Object[][] {
                new Object[] {
               P00GW2_A237ParametrosCodigo, P00GW2_A602ParametrosValor, P00GW2_A283ParametrosId
               }
               , new Object[] {
               P00GW3_A283ParametrosId
               }
               , new Object[] {
               P00GW4_A18SecUserId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV11GXLvl3 ;
      private short AV12GXLvl14 ;
      private int GX_INS88 ;
      private long A18SecUserId ;
      private long AV10SecUserId ;
      private long A283ParametrosId ;
      private string A237ParametrosCodigo ;
      private string Gx_emsg ;
      private string A602ParametrosValor ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] P00GW2_A237ParametrosCodigo ;
      private string[] P00GW2_A602ParametrosValor ;
      private long[] P00GW2_A283ParametrosId ;
      private long[] P00GW3_A283ParametrosId ;
      private long[] P00GW4_A18SecUserId ;
      private long aP1_SecUserId ;
   }

   public class obtenerusuariosid__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP00GW2;
          prmP00GW2 = new Object[] {
          };
          Object[] prmP00GW3;
          prmP00GW3 = new Object[] {
          new ParDef("@ParametrosCodigo",GXType.NChar,20,0) ,
          new ParDef("@ParametrosValor",GXType.NVarChar,255,0)
          };
          Object[] prmP00GW4;
          prmP00GW4 = new Object[] {
          new ParDef("@SecUserId",GXType.Decimal,10,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00GW2", "SELECT [ParametrosCodigo], [ParametrosValor], [ParametrosId] FROM [Parametros] ORDER BY [ParametrosId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00GW2,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P00GW3", "INSERT INTO [Parametros]([ParametrosCodigo], [ParametrosValor], [ParametrosNombre], [ParametrosEstado], [ParametrosNumerico]) VALUES(@ParametrosCodigo, @ParametrosValor, '', '', convert(int, 0)); SELECT SCOPE_IDENTITY()",false, GxErrorMask.GX_NOMASK, false, this,prmP00GW3,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("P00GW4", "SELECT [SecUserId] FROM [SecUser] WHERE [SecUserId] = @SecUserId ORDER BY [SecUserId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00GW4,1, GxCacheFrequency.OFF ,false,true )
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
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((long[]) buf[2])[0] = rslt.getLong(3);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
             case 2 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
       }
    }

 }

}

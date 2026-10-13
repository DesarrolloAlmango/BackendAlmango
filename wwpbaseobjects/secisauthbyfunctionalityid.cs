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
   public class secisauthbyfunctionalityid : GXProcedure
   {
      public secisauthbyfunctionalityid( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public secisauthbyfunctionalityid( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( long aP0_SecFunctionalityId ,
                           out bool aP1_IsAuthorized )
      {
         this.AV13SecFunctionalityId = aP0_SecFunctionalityId;
         this.AV10IsAuthorized = false ;
         initialize();
         ExecutePrivate();
         aP1_IsAuthorized=this.AV10IsAuthorized;
      }

      public bool executeUdp( long aP0_SecFunctionalityId )
      {
         execute(aP0_SecFunctionalityId, out aP1_IsAuthorized);
         return AV10IsAuthorized ;
      }

      public void executeSubmit( long aP0_SecFunctionalityId ,
                                 out bool aP1_IsAuthorized )
      {
         this.AV13SecFunctionalityId = aP0_SecFunctionalityId;
         this.AV10IsAuthorized = false ;
         SubmitImpl();
         aP1_IsAuthorized=this.AV10IsAuthorized;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV10IsAuthorized = false;
         GXt_objcol_int1 = AV9SecRolIds;
         new GeneXus.Programs.wwpbaseobjects.secgetrolesfromloggeduser(context ).execute( out  GXt_objcol_int1) ;
         AV9SecRolIds = GXt_objcol_int1;
         AV14GXV1 = 1;
         while ( AV14GXV1 <= AV9SecRolIds.Count )
         {
            AV12SecRolId = (short)(AV9SecRolIds.GetNumeric(AV14GXV1));
            /* Using cursor P002I2 */
            pr_default.execute(0, new Object[] {AV13SecFunctionalityId, AV12SecRolId});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A13SecFunctionalityId = P002I2_A13SecFunctionalityId[0];
               A16SecRoleId = P002I2_A16SecRoleId[0];
               AV10IsAuthorized = true;
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               if (true) break;
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(0);
            if ( AV10IsAuthorized )
            {
               if (true) break;
            }
            AV14GXV1 = (int)(AV14GXV1+1);
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
         AV9SecRolIds = new GxSimpleCollection<short>();
         GXt_objcol_int1 = new GxSimpleCollection<short>();
         P002I2_A13SecFunctionalityId = new long[1] ;
         P002I2_A16SecRoleId = new short[1] ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalityid__default(),
            new Object[][] {
                new Object[] {
               P002I2_A13SecFunctionalityId, P002I2_A16SecRoleId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV12SecRolId ;
      private short A16SecRoleId ;
      private int AV14GXV1 ;
      private long AV13SecFunctionalityId ;
      private long A13SecFunctionalityId ;
      private bool AV10IsAuthorized ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GxSimpleCollection<short> AV9SecRolIds ;
      private GxSimpleCollection<short> GXt_objcol_int1 ;
      private IDataStoreProvider pr_default ;
      private long[] P002I2_A13SecFunctionalityId ;
      private short[] P002I2_A16SecRoleId ;
      private bool aP1_IsAuthorized ;
   }

   public class secisauthbyfunctionalityid__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP002I2;
          prmP002I2 = new Object[] {
          new ParDef("@AV13SecFunctionalityId",GXType.Decimal,10,0) ,
          new ParDef("@AV12SecRolId",GXType.Int16,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("P002I2", "SELECT TOP 1 [SecFunctionalityId], [SecRoleId] FROM [SecFunctionalityRole] WHERE [SecFunctionalityId] = @AV13SecFunctionalityId and [SecRoleId] = @AV12SecRolId ORDER BY [SecFunctionalityId], [SecRoleId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP002I2,1, GxCacheFrequency.OFF ,false,true )
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
                ((short[]) buf[1])[0] = rslt.getShort(2);
                return;
       }
    }

 }

}

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
   public class wwp_getusersfromrole : GXProcedure
   {
      public wwp_getusersfromrole( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wwp_getusersfromrole( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_WWPSubscriptionRoleId ,
                           out GxSimpleCollection<string> aP1_WWPUserExtendedIdCollection )
      {
         this.AV10WWPSubscriptionRoleId = aP0_WWPSubscriptionRoleId;
         this.AV9WWPUserExtendedIdCollection = new GxSimpleCollection<string>() ;
         initialize();
         ExecutePrivate();
         aP1_WWPUserExtendedIdCollection=this.AV9WWPUserExtendedIdCollection;
      }

      public GxSimpleCollection<string> executeUdp( string aP0_WWPSubscriptionRoleId )
      {
         execute(aP0_WWPSubscriptionRoleId, out aP1_WWPUserExtendedIdCollection);
         return AV9WWPUserExtendedIdCollection ;
      }

      public void executeSubmit( string aP0_WWPSubscriptionRoleId ,
                                 out GxSimpleCollection<string> aP1_WWPUserExtendedIdCollection )
      {
         this.AV10WWPSubscriptionRoleId = aP0_WWPSubscriptionRoleId;
         this.AV9WWPUserExtendedIdCollection = new GxSimpleCollection<string>() ;
         SubmitImpl();
         aP1_WWPUserExtendedIdCollection=this.AV9WWPUserExtendedIdCollection;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV11SecRoleId = (short)(Math.Round(NumberUtil.Val( AV10WWPSubscriptionRoleId, "."), 18, MidpointRounding.ToEven));
         AV9WWPUserExtendedIdCollection = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         /* Using cursor P002V2 */
         pr_default.execute(0, new Object[] {AV11SecRoleId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A16SecRoleId = P002V2_A16SecRoleId[0];
            A18SecUserId = P002V2_A18SecUserId[0];
            AV9WWPUserExtendedIdCollection.Add(StringUtil.Trim( StringUtil.Str( (decimal)(A18SecUserId), 10, 0)), 0);
            pr_default.readNext(0);
         }
         pr_default.close(0);
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
         AV9WWPUserExtendedIdCollection = new GxSimpleCollection<string>();
         P002V2_A16SecRoleId = new short[1] ;
         P002V2_A18SecUserId = new long[1] ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.wwp_getusersfromrole__default(),
            new Object[][] {
                new Object[] {
               P002V2_A16SecRoleId, P002V2_A18SecUserId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV11SecRoleId ;
      private short A16SecRoleId ;
      private long A18SecUserId ;
      private string AV10WWPSubscriptionRoleId ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GxSimpleCollection<string> AV9WWPUserExtendedIdCollection ;
      private IDataStoreProvider pr_default ;
      private short[] P002V2_A16SecRoleId ;
      private long[] P002V2_A18SecUserId ;
      private GxSimpleCollection<string> aP1_WWPUserExtendedIdCollection ;
   }

   public class wwp_getusersfromrole__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP002V2;
          prmP002V2 = new Object[] {
          new ParDef("@AV11SecRoleId",GXType.Int16,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("P002V2", "SELECT [SecRoleId], [SecUserId] FROM [SecUserRole] WHERE [SecRoleId] = @AV11SecRoleId ORDER BY [SecRoleId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP002V2,100, GxCacheFrequency.OFF ,false,false )
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
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((long[]) buf[1])[0] = rslt.getLong(2);
                return;
       }
    }

 }

}

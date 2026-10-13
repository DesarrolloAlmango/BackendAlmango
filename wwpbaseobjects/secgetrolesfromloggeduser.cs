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
   public class secgetrolesfromloggeduser : GXProcedure
   {
      public secgetrolesfromloggeduser( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public secgetrolesfromloggeduser( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( out GxSimpleCollection<short> aP0_SecRoleIds )
      {
         this.AV9SecRoleIds = new GxSimpleCollection<short>() ;
         initialize();
         ExecutePrivate();
         aP0_SecRoleIds=this.AV9SecRoleIds;
      }

      public GxSimpleCollection<short> executeUdp( )
      {
         execute(out aP0_SecRoleIds);
         return AV9SecRoleIds ;
      }

      public void executeSubmit( out GxSimpleCollection<short> aP0_SecRoleIds )
      {
         this.AV9SecRoleIds = new GxSimpleCollection<short>() ;
         SubmitImpl();
         aP0_SecRoleIds=this.AV9SecRoleIds;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV10SecRoleIdsXML = StringUtil.Trim( AV12WebSession.Get("SecGetRolesFromLoggedUser"));
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV10SecRoleIdsXML)) )
         {
            GXt_SdtWWPContext1 = AV8WWPContext;
            new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  GXt_SdtWWPContext1) ;
            AV8WWPContext = GXt_SdtWWPContext1;
            AV11SecUserId = AV8WWPContext.gxTpr_Userid;
            AV9SecRoleIds = (GxSimpleCollection<short>)(new GxSimpleCollection<short>());
            /* Using cursor P002G2 */
            pr_default.execute(0, new Object[] {AV11SecUserId});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A551SecUserRoleEstado = P002G2_A551SecUserRoleEstado[0];
               A18SecUserId = P002G2_A18SecUserId[0];
               A16SecRoleId = P002G2_A16SecRoleId[0];
               AV9SecRoleIds.Add(A16SecRoleId, 0);
               pr_default.readNext(0);
            }
            pr_default.close(0);
            if ( AV9SecRoleIds.Count > 0 )
            {
               AV10SecRoleIdsXML = AV9SecRoleIds.ToXml(false, true, "Collection", "");
               AV12WebSession.Set("SecGetRolesFromLoggedUser", AV10SecRoleIdsXML);
            }
         }
         else
         {
            AV9SecRoleIds.FromXml(AV10SecRoleIdsXML, null, "Collection", "");
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
         AV9SecRoleIds = new GxSimpleCollection<short>();
         AV10SecRoleIdsXML = "";
         AV12WebSession = context.GetSession();
         AV8WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         GXt_SdtWWPContext1 = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         P002G2_A551SecUserRoleEstado = new string[] {""} ;
         P002G2_A18SecUserId = new long[1] ;
         P002G2_A16SecRoleId = new short[1] ;
         A551SecUserRoleEstado = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.secgetrolesfromloggeduser__default(),
            new Object[][] {
                new Object[] {
               P002G2_A551SecUserRoleEstado, P002G2_A18SecUserId, P002G2_A16SecRoleId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short A16SecRoleId ;
      private long AV11SecUserId ;
      private long A18SecUserId ;
      private string A551SecUserRoleEstado ;
      private string AV10SecRoleIdsXML ;
      private IGxSession AV12WebSession ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GxSimpleCollection<short> AV9SecRoleIds ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext GXt_SdtWWPContext1 ;
      private IDataStoreProvider pr_default ;
      private string[] P002G2_A551SecUserRoleEstado ;
      private long[] P002G2_A18SecUserId ;
      private short[] P002G2_A16SecRoleId ;
      private GxSimpleCollection<short> aP0_SecRoleIds ;
   }

   public class secgetrolesfromloggeduser__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP002G2;
          prmP002G2 = new Object[] {
          new ParDef("@AV11SecUserId",GXType.Decimal,10,0)
          };
          def= new CursorDef[] {
              new CursorDef("P002G2", "SELECT [SecUserRoleEstado], [SecUserId], [SecRoleId] FROM [SecUserRole] WHERE ([SecUserId] = @AV11SecUserId) AND ([SecUserRoleEstado] = 'HAB') ORDER BY [SecUserId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP002G2,100, GxCacheFrequency.OFF ,false,false )
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
                ((string[]) buf[0])[0] = rslt.getString(1, 3);
                ((long[]) buf[1])[0] = rslt.getLong(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                return;
       }
    }

 }

}

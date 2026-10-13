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
namespace GeneXus.Programs.apis {
   public class orubroidsolicitud : GXProcedure
   {
      public orubroidsolicitud( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public orubroidsolicitud( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( long aP0_SolicitudesId ,
                           out bool aP1_Exists ,
                           out GxSimpleCollection<short> aP2_RubrosId )
      {
         this.AV8SolicitudesId = aP0_SolicitudesId;
         this.AV9Exists = false ;
         this.AV11RubrosId = new GxSimpleCollection<short>() ;
         initialize();
         ExecutePrivate();
         aP1_Exists=this.AV9Exists;
         aP2_RubrosId=this.AV11RubrosId;
      }

      public GxSimpleCollection<short> executeUdp( long aP0_SolicitudesId ,
                                                   out bool aP1_Exists )
      {
         execute(aP0_SolicitudesId, out aP1_Exists, out aP2_RubrosId);
         return AV11RubrosId ;
      }

      public void executeSubmit( long aP0_SolicitudesId ,
                                 out bool aP1_Exists ,
                                 out GxSimpleCollection<short> aP2_RubrosId )
      {
         this.AV8SolicitudesId = aP0_SolicitudesId;
         this.AV9Exists = false ;
         this.AV11RubrosId = new GxSimpleCollection<short>() ;
         SubmitImpl();
         aP1_Exists=this.AV9Exists;
         aP2_RubrosId=this.AV11RubrosId;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV9Exists = false;
         AV11RubrosId.Clear();
         AV12GXLvl3 = 0;
         /* Using cursor P00JB2 */
         pr_default.execute(0, new Object[] {AV8SolicitudesId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A127SolicitudesID = P00JB2_A127SolicitudesID[0];
            A121RubrosId = P00JB2_A121RubrosId[0];
            A134SolicitudesItemsID = P00JB2_A134SolicitudesItemsID[0];
            AV12GXLvl3 = 1;
            AV11RubrosId.Add(A121RubrosId, 0);
            pr_default.readNext(0);
         }
         pr_default.close(0);
         if ( AV12GXLvl3 == 0 )
         {
            AV9Exists = false;
         }
         if ( AV11RubrosId.Count >= 1 )
         {
            AV9Exists = true;
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
         AV11RubrosId = new GxSimpleCollection<short>();
         P00JB2_A127SolicitudesID = new long[1] ;
         P00JB2_A121RubrosId = new short[1] ;
         P00JB2_A134SolicitudesItemsID = new short[1] ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.apis.orubroidsolicitud__default(),
            new Object[][] {
                new Object[] {
               P00JB2_A127SolicitudesID, P00JB2_A121RubrosId, P00JB2_A134SolicitudesItemsID
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV12GXLvl3 ;
      private short A121RubrosId ;
      private short A134SolicitudesItemsID ;
      private long AV8SolicitudesId ;
      private long A127SolicitudesID ;
      private bool AV9Exists ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GxSimpleCollection<short> AV11RubrosId ;
      private IDataStoreProvider pr_default ;
      private long[] P00JB2_A127SolicitudesID ;
      private short[] P00JB2_A121RubrosId ;
      private short[] P00JB2_A134SolicitudesItemsID ;
      private bool aP1_Exists ;
      private GxSimpleCollection<short> aP2_RubrosId ;
   }

   public class orubroidsolicitud__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP00JB2;
          prmP00JB2 = new Object[] {
          new ParDef("@AV8SolicitudesId",GXType.Decimal,18,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00JB2", "SELECT [SolicitudesID], [RubrosId], [SolicitudesItemsID] FROM [SolicitudesItems] WHERE [SolicitudesID] = @AV8SolicitudesId ORDER BY [SolicitudesID], [SolicitudesItemsID] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00JB2,100, GxCacheFrequency.OFF ,false,false )
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
                ((short[]) buf[2])[0] = rslt.getShort(3);
                return;
       }
    }

 }

}

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
   public class tarjetasservicios : GXProcedure
   {
      public tarjetasservicios( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public tarjetasservicios( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( out string aP0_SDTTarjetasServiciosJson )
      {
         this.AV10SDTTarjetasServiciosJson = "" ;
         initialize();
         ExecutePrivate();
         aP0_SDTTarjetasServiciosJson=this.AV10SDTTarjetasServiciosJson;
      }

      public string executeUdp( )
      {
         execute(out aP0_SDTTarjetasServiciosJson);
         return AV10SDTTarjetasServiciosJson ;
      }

      public void executeSubmit( out string aP0_SDTTarjetasServiciosJson )
      {
         this.AV10SDTTarjetasServiciosJson = "" ;
         SubmitImpl();
         aP0_SDTTarjetasServiciosJson=this.AV10SDTTarjetasServiciosJson;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         /* Using cursor P00HT2 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            A123RubrosEstado = P00HT2_A123RubrosEstado[0];
            n123RubrosEstado = P00HT2_n123RubrosEstado[0];
            A121RubrosId = P00HT2_A121RubrosId[0];
            A122RubrosNombre = P00HT2_A122RubrosNombre[0];
            A896RubrosImagenURL = P00HT2_A896RubrosImagenURL[0];
            AV9SDTTarjetasServiciosItem = new GeneXus.Programs.apis.SdtSDTTarjetasServicios_SDTTarjetasServiciosItem(context);
            AV9SDTTarjetasServiciosItem.gxTpr_Id = A121RubrosId;
            AV9SDTTarjetasServiciosItem.gxTpr_Name = A122RubrosNombre;
            AV9SDTTarjetasServiciosItem.gxTpr_Icon = A896RubrosImagenURL;
            AV8SDTTarjetasServicios.Add(AV9SDTTarjetasServiciosItem, 0);
            pr_default.readNext(0);
         }
         pr_default.close(0);
         AV10SDTTarjetasServiciosJson = AV8SDTTarjetasServicios.ToJSonString(false);
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
         AV10SDTTarjetasServiciosJson = "";
         P00HT2_A123RubrosEstado = new string[] {""} ;
         P00HT2_n123RubrosEstado = new bool[] {false} ;
         P00HT2_A121RubrosId = new short[1] ;
         P00HT2_A122RubrosNombre = new string[] {""} ;
         P00HT2_A896RubrosImagenURL = new string[] {""} ;
         A123RubrosEstado = "";
         A122RubrosNombre = "";
         A896RubrosImagenURL = "";
         AV9SDTTarjetasServiciosItem = new GeneXus.Programs.apis.SdtSDTTarjetasServicios_SDTTarjetasServiciosItem(context);
         AV8SDTTarjetasServicios = new GXBaseCollection<GeneXus.Programs.apis.SdtSDTTarjetasServicios_SDTTarjetasServiciosItem>( context, "SDTTarjetasServiciosItem", "AlmangoX");
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.apis.tarjetasservicios__default(),
            new Object[][] {
                new Object[] {
               P00HT2_A123RubrosEstado, P00HT2_n123RubrosEstado, P00HT2_A121RubrosId, P00HT2_A122RubrosNombre, P00HT2_A896RubrosImagenURL
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short A121RubrosId ;
      private string A123RubrosEstado ;
      private string A122RubrosNombre ;
      private bool n123RubrosEstado ;
      private string AV10SDTTarjetasServiciosJson ;
      private string A896RubrosImagenURL ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] P00HT2_A123RubrosEstado ;
      private bool[] P00HT2_n123RubrosEstado ;
      private short[] P00HT2_A121RubrosId ;
      private string[] P00HT2_A122RubrosNombre ;
      private string[] P00HT2_A896RubrosImagenURL ;
      private GeneXus.Programs.apis.SdtSDTTarjetasServicios_SDTTarjetasServiciosItem AV9SDTTarjetasServiciosItem ;
      private GXBaseCollection<GeneXus.Programs.apis.SdtSDTTarjetasServicios_SDTTarjetasServiciosItem> AV8SDTTarjetasServicios ;
      private string aP0_SDTTarjetasServiciosJson ;
   }

   public class tarjetasservicios__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP00HT2;
          prmP00HT2 = new Object[] {
          };
          def= new CursorDef[] {
              new CursorDef("P00HT2", "SELECT [RubrosEstado], [RubrosId], [RubrosNombre], [RubrosImagenURL] FROM [Rubros] WHERE [RubrosEstado] = 'HAB' ORDER BY [RubrosId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00HT2,100, GxCacheFrequency.OFF ,false,false )
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
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((short[]) buf[2])[0] = rslt.getShort(2);
                ((string[]) buf[3])[0] = rslt.getString(3, 100);
                ((string[]) buf[4])[0] = rslt.getVarchar(4);
                return;
       }
    }

 }

}

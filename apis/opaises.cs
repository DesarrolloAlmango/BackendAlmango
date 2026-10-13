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
   public class opaises : GXProcedure
   {
      public opaises( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public opaises( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( out GXBaseCollection<GeneXus.Programs.apis.SdtSDTPais> aP0_SdtPais ,
                           out string aP1_restMessage ,
                           out short aP2_Gx_restcode )
      {
         this.AV8SdtPais = new GXBaseCollection<GeneXus.Programs.apis.SdtSDTPais>( context, "SDTPais", "AlmangoX") ;
         this.AV9restMessage = "" ;
         this.Gx_restcode = 0 ;
         initialize();
         ExecutePrivate();
         aP0_SdtPais=this.AV8SdtPais;
         aP1_restMessage=this.AV9restMessage;
         aP2_Gx_restcode=this.Gx_restcode;
      }

      public short executeUdp( out GXBaseCollection<GeneXus.Programs.apis.SdtSDTPais> aP0_SdtPais ,
                               out string aP1_restMessage )
      {
         execute(out aP0_SdtPais, out aP1_restMessage, out aP2_Gx_restcode);
         return Gx_restcode ;
      }

      public void executeSubmit( out GXBaseCollection<GeneXus.Programs.apis.SdtSDTPais> aP0_SdtPais ,
                                 out string aP1_restMessage ,
                                 out short aP2_Gx_restcode )
      {
         this.AV8SdtPais = new GXBaseCollection<GeneXus.Programs.apis.SdtSDTPais>( context, "SDTPais", "AlmangoX") ;
         this.AV9restMessage = "" ;
         this.Gx_restcode = 0 ;
         SubmitImpl();
         aP0_SdtPais=this.AV8SdtPais;
         aP1_restMessage=this.AV9restMessage;
         aP2_Gx_restcode=this.Gx_restcode;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV8SdtPais.Clear();
         AV12GXLvl4 = 0;
         /* Using cursor P00JZ2 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            A116PaisID = P00JZ2_A116PaisID[0];
            A165PaisNombre = P00JZ2_A165PaisNombre[0];
            AV12GXLvl4 = 1;
            AV10Item = new GeneXus.Programs.apis.SdtSDTPais(context);
            AV10Item.gxTpr_Paisid = A116PaisID;
            AV10Item.gxTpr_Paisnombre = A165PaisNombre;
            AV8SdtPais.Add(AV10Item, 0);
            pr_default.readNext(0);
         }
         pr_default.close(0);
         if ( AV12GXLvl4 == 0 )
         {
            Gx_restcode = 404;
            AV9restMessage = context.GetMessage( "No se obtuvieron datos para su solicitud", "");
         }
         if ( ( Gx_restcode != 404 ) && ( AV8SdtPais.Count > 0 ) )
         {
            Gx_restcode = 200;
            AV9restMessage = context.GetMessage( "Solicitud procesada con éxito", "");
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
         AV8SdtPais = new GXBaseCollection<GeneXus.Programs.apis.SdtSDTPais>( context, "SDTPais", "AlmangoX");
         AV9restMessage = "";
         P00JZ2_A116PaisID = new string[] {""} ;
         P00JZ2_A165PaisNombre = new string[] {""} ;
         A116PaisID = "";
         A165PaisNombre = "";
         AV10Item = new GeneXus.Programs.apis.SdtSDTPais(context);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.apis.opaises__default(),
            new Object[][] {
                new Object[] {
               P00JZ2_A116PaisID, P00JZ2_A165PaisNombre
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short Gx_restcode ;
      private short AV12GXLvl4 ;
      private string A116PaisID ;
      private string A165PaisNombre ;
      private string AV9restMessage ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GXBaseCollection<GeneXus.Programs.apis.SdtSDTPais> AV8SdtPais ;
      private IDataStoreProvider pr_default ;
      private string[] P00JZ2_A116PaisID ;
      private string[] P00JZ2_A165PaisNombre ;
      private GeneXus.Programs.apis.SdtSDTPais AV10Item ;
      private GXBaseCollection<GeneXus.Programs.apis.SdtSDTPais> aP0_SdtPais ;
      private string aP1_restMessage ;
      private short aP2_Gx_restcode ;
   }

   public class opaises__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP00JZ2;
          prmP00JZ2 = new Object[] {
          };
          def= new CursorDef[] {
              new CursorDef("P00JZ2", "SELECT [PaisID], [PaisNombre] FROM [Pais] ORDER BY [PaisID] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00JZ2,100, GxCacheFrequency.OFF ,false,false )
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
                ((string[]) buf[0])[0] = rslt.getString(1, 2);
                ((string[]) buf[1])[0] = rslt.getString(2, 80);
                return;
       }
    }

 }

}

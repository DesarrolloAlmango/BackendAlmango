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
   public class ometodopagos : GXProcedure
   {
      public ometodopagos( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public ometodopagos( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_UserId ,
                           string aP1_Password ,
                           out string aP2_RestMessage ,
                           out GXBaseCollection<GeneXus.Programs.apis.SdtSDTMetodoPagos> aP3_SDTMetodoPagos )
      {
         this.AV8UserId = aP0_UserId;
         this.AV12Password = aP1_Password;
         this.AV11RestMessage = "" ;
         this.AV9SDTMetodoPagos = new GXBaseCollection<GeneXus.Programs.apis.SdtSDTMetodoPagos>( context, "SDTMetodoPagos", "AlmangoX") ;
         initialize();
         ExecutePrivate();
         aP2_RestMessage=this.AV11RestMessage;
         aP3_SDTMetodoPagos=this.AV9SDTMetodoPagos;
      }

      public GXBaseCollection<GeneXus.Programs.apis.SdtSDTMetodoPagos> executeUdp( string aP0_UserId ,
                                                                                   string aP1_Password ,
                                                                                   out string aP2_RestMessage )
      {
         execute(aP0_UserId, aP1_Password, out aP2_RestMessage, out aP3_SDTMetodoPagos);
         return AV9SDTMetodoPagos ;
      }

      public void executeSubmit( string aP0_UserId ,
                                 string aP1_Password ,
                                 out string aP2_RestMessage ,
                                 out GXBaseCollection<GeneXus.Programs.apis.SdtSDTMetodoPagos> aP3_SDTMetodoPagos )
      {
         this.AV8UserId = aP0_UserId;
         this.AV12Password = aP1_Password;
         this.AV11RestMessage = "" ;
         this.AV9SDTMetodoPagos = new GXBaseCollection<GeneXus.Programs.apis.SdtSDTMetodoPagos>( context, "SDTMetodoPagos", "AlmangoX") ;
         SubmitImpl();
         aP2_RestMessage=this.AV11RestMessage;
         aP3_SDTMetodoPagos=this.AV9SDTMetodoPagos;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV9SDTMetodoPagos = new GXBaseCollection<GeneXus.Programs.apis.SdtSDTMetodoPagos>( context, "SDTMetodoPagos", "AlmangoX");
         AV13GXLvl3 = 0;
         /* Using cursor P00JP2 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            A108EstadosGenericosId = P00JP2_A108EstadosGenericosId[0];
            A128MetodoPagosID = P00JP2_A128MetodoPagosID[0];
            A129MetodoPagosNombre = P00JP2_A129MetodoPagosNombre[0];
            AV13GXLvl3 = 1;
            AV10SDTMetodoPagosItem = new GeneXus.Programs.apis.SdtSDTMetodoPagos(context);
            AV10SDTMetodoPagosItem.gxTpr_Metodopagosid = A128MetodoPagosID;
            AV10SDTMetodoPagosItem.gxTpr_Metodopagosnombre = A129MetodoPagosNombre;
            AV9SDTMetodoPagos.Add(AV10SDTMetodoPagosItem, 0);
            pr_default.readNext(0);
         }
         pr_default.close(0);
         if ( AV13GXLvl3 == 0 )
         {
            AV11RestMessage = context.GetMessage( "No se encontraron métodos de pago", "");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV11RestMessage)) )
         {
            AV11RestMessage = context.GetMessage( "Solicitud procesada con éxito", "");
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
         AV11RestMessage = "";
         AV9SDTMetodoPagos = new GXBaseCollection<GeneXus.Programs.apis.SdtSDTMetodoPagos>( context, "SDTMetodoPagos", "AlmangoX");
         P00JP2_A108EstadosGenericosId = new int[1] ;
         P00JP2_A128MetodoPagosID = new long[1] ;
         P00JP2_A129MetodoPagosNombre = new string[] {""} ;
         A129MetodoPagosNombre = "";
         AV10SDTMetodoPagosItem = new GeneXus.Programs.apis.SdtSDTMetodoPagos(context);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.apis.ometodopagos__default(),
            new Object[][] {
                new Object[] {
               P00JP2_A108EstadosGenericosId, P00JP2_A128MetodoPagosID, P00JP2_A129MetodoPagosNombre
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV13GXLvl3 ;
      private int A108EstadosGenericosId ;
      private long A128MetodoPagosID ;
      private string AV8UserId ;
      private string A129MetodoPagosNombre ;
      private string AV12Password ;
      private string AV11RestMessage ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GXBaseCollection<GeneXus.Programs.apis.SdtSDTMetodoPagos> AV9SDTMetodoPagos ;
      private IDataStoreProvider pr_default ;
      private int[] P00JP2_A108EstadosGenericosId ;
      private long[] P00JP2_A128MetodoPagosID ;
      private string[] P00JP2_A129MetodoPagosNombre ;
      private GeneXus.Programs.apis.SdtSDTMetodoPagos AV10SDTMetodoPagosItem ;
      private string aP2_RestMessage ;
      private GXBaseCollection<GeneXus.Programs.apis.SdtSDTMetodoPagos> aP3_SDTMetodoPagos ;
   }

   public class ometodopagos__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP00JP2;
          prmP00JP2 = new Object[] {
          };
          def= new CursorDef[] {
              new CursorDef("P00JP2", "SELECT [EstadosGenericosId], [MetodoPagosID], [MetodoPagosNombre] FROM [MetodoPagos] WHERE ([MetodoPagosID] <> 4) AND ([EstadosGenericosId] = 1) ORDER BY [MetodoPagosID] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00JP2,100, GxCacheFrequency.OFF ,false,false )
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
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((long[]) buf[1])[0] = rslt.getLong(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 80);
                return;
       }
    }

 }

}

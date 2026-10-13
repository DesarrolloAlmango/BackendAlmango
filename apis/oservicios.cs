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
using GeneXus.Http.Server;
using System.Threading;
using System.Xml.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Runtime.Serialization;
namespace GeneXus.Programs.apis {
   public class oservicios : GXProcedure
   {
      public oservicios( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public oservicios( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_User ,
                           string aP1_ProfesionalesId ,
                           out GXBaseCollection<SdtSDTServicios_Item> aP2_SdtServicios ,
                           out short aP3_Gx_restcode ,
                           out string aP4_RestMessage )
      {
         this.AV8User = aP0_User;
         this.AV9ProfesionalesId = aP1_ProfesionalesId;
         this.AV10SdtServicios = new GXBaseCollection<SdtSDTServicios_Item>( context, "Item", "AlmangoX") ;
         this.Gx_restcode = 0 ;
         this.AV11RestMessage = "" ;
         initialize();
         ExecutePrivate();
         aP2_SdtServicios=this.AV10SdtServicios;
         aP3_Gx_restcode=this.Gx_restcode;
         aP4_RestMessage=this.AV11RestMessage;
      }

      public string executeUdp( string aP0_User ,
                                string aP1_ProfesionalesId ,
                                out GXBaseCollection<SdtSDTServicios_Item> aP2_SdtServicios ,
                                out short aP3_Gx_restcode )
      {
         execute(aP0_User, aP1_ProfesionalesId, out aP2_SdtServicios, out aP3_Gx_restcode, out aP4_RestMessage);
         return AV11RestMessage ;
      }

      public void executeSubmit( string aP0_User ,
                                 string aP1_ProfesionalesId ,
                                 out GXBaseCollection<SdtSDTServicios_Item> aP2_SdtServicios ,
                                 out short aP3_Gx_restcode ,
                                 out string aP4_RestMessage )
      {
         this.AV8User = aP0_User;
         this.AV9ProfesionalesId = aP1_ProfesionalesId;
         this.AV10SdtServicios = new GXBaseCollection<SdtSDTServicios_Item>( context, "Item", "AlmangoX") ;
         this.Gx_restcode = 0 ;
         this.AV11RestMessage = "" ;
         SubmitImpl();
         aP2_SdtServicios=this.AV10SdtServicios;
         aP3_Gx_restcode=this.Gx_restcode;
         aP4_RestMessage=this.AV11RestMessage;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV8User)) )
         {
            Gx_restcode = 400;
            AV11RestMessage = context.GetMessage( "Error al procesar la solicitud", "");
            cleanup();
            if (true) return;
         }
         new GeneXus.Programs.apis.otokenfromcookie(context ).execute(  AV13HttpRequest, out  AV12TokenId) ;
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV12TokenId)) )
         {
            Gx_restcode = 401;
            AV11RestMessage = "Token faltante";
            cleanup();
            if (true) return;
         }
         new GeneXus.Programs.apis.validaracceso(context ).execute(  AV8User,  AV9ProfesionalesId,  AV12TokenId, out  AV14EsValido, out  AV15TokenDesencriptado) ;
         if ( ! AV14EsValido )
         {
            Gx_restcode = 401;
            AV11RestMessage = context.GetMessage( "No autorizado o token inválido.", "");
            cleanup();
            if (true) return;
         }
         AV10SdtServicios.Clear();
         /* Using cursor P00MK2 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            A954ServiciosActivo = P00MK2_A954ServiciosActivo[0];
            A942ServiciosId = P00MK2_A942ServiciosId[0];
            A943ServiciosNombre = P00MK2_A943ServiciosNombre[0];
            AV16Item = new SdtSDTServicios_Item(context);
            AV16Item.gxTpr_Serviciosid = A942ServiciosId;
            AV16Item.gxTpr_Serviciosnombre = A943ServiciosNombre;
            AV10SdtServicios.Add(AV16Item, 0);
            pr_default.readNext(0);
         }
         pr_default.close(0);
         AV11RestMessage = context.GetMessage( "Solicitud procesada con éxito", "");
         Gx_restcode = 200;
         if ( Gx_restcode != 200 )
         {
            AV11RestMessage = context.GetMessage( "Hubo un problema, intente nuevamente más tarde", "");
            Gx_restcode = 500;
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
         AV10SdtServicios = new GXBaseCollection<SdtSDTServicios_Item>( context, "Item", "AlmangoX");
         AV11RestMessage = "";
         AV13HttpRequest = new GxHttpRequest( context);
         AV12TokenId = "";
         AV15TokenDesencriptado = "";
         P00MK2_A954ServiciosActivo = new bool[] {false} ;
         P00MK2_A942ServiciosId = new long[1] ;
         P00MK2_A943ServiciosNombre = new string[] {""} ;
         A943ServiciosNombre = "";
         AV16Item = new SdtSDTServicios_Item(context);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.apis.oservicios__default(),
            new Object[][] {
                new Object[] {
               P00MK2_A954ServiciosActivo, P00MK2_A942ServiciosId, P00MK2_A943ServiciosNombre
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short Gx_restcode ;
      private long A942ServiciosId ;
      private string AV8User ;
      private string AV9ProfesionalesId ;
      private string AV12TokenId ;
      private string AV15TokenDesencriptado ;
      private string A943ServiciosNombre ;
      private bool AV14EsValido ;
      private bool A954ServiciosActivo ;
      private string AV11RestMessage ;
      private GxHttpRequest AV13HttpRequest ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GXBaseCollection<SdtSDTServicios_Item> AV10SdtServicios ;
      private IDataStoreProvider pr_default ;
      private bool[] P00MK2_A954ServiciosActivo ;
      private long[] P00MK2_A942ServiciosId ;
      private string[] P00MK2_A943ServiciosNombre ;
      private SdtSDTServicios_Item AV16Item ;
      private GXBaseCollection<SdtSDTServicios_Item> aP2_SdtServicios ;
      private short aP3_Gx_restcode ;
      private string aP4_RestMessage ;
   }

   public class oservicios__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP00MK2;
          prmP00MK2 = new Object[] {
          };
          def= new CursorDef[] {
              new CursorDef("P00MK2", "SELECT [ServiciosActivo], [ServiciosId], [ServiciosNombre] FROM [Servicios] WHERE [ServiciosActivo] = 1 ORDER BY [ServiciosId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00MK2,100, GxCacheFrequency.OFF ,false,false )
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
                ((bool[]) buf[0])[0] = rslt.getBool(1);
                ((long[]) buf[1])[0] = rslt.getLong(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 80);
                return;
       }
    }

 }

}

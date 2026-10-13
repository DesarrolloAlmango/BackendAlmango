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
   public class obtenercomercioforanea : GXProcedure
   {
      public obtenercomercioforanea( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public obtenercomercioforanea( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( out string aP0_ComercioForanea )
      {
         this.AV13ComercioForanea = "" ;
         initialize();
         ExecutePrivate();
         aP0_ComercioForanea=this.AV13ComercioForanea;
      }

      public string executeUdp( )
      {
         execute(out aP0_ComercioForanea);
         return AV13ComercioForanea ;
      }

      public void executeSubmit( out string aP0_ComercioForanea )
      {
         this.AV13ComercioForanea = "" ;
         SubmitImpl();
         aP0_ComercioForanea=this.AV13ComercioForanea;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         /* Using cursor P00HR2 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            A151ProveedoresTipoId = P00HR2_A151ProveedoresTipoId[0];
            A278ProveedoresTipoNombre = P00HR2_A278ProveedoresTipoNombre[0];
            AV10ProveedoresTipoItem = new GeneXus.Programs.apis.SdtSDTComercioForanea_ProveedoresTipoItem(context);
            AV10ProveedoresTipoItem.gxTpr_Proveedorestipoid = A151ProveedoresTipoId;
            AV10ProveedoresTipoItem.gxTpr_Proveedorestiponombre = A278ProveedoresTipoNombre;
            AV9SDTComercioForanea.gxTpr_Proveedorestipo.Add(AV10ProveedoresTipoItem, 0);
            pr_default.readNext(0);
         }
         pr_default.close(0);
         /* Using cursor P00HR3 */
         pr_default.execute(1);
         while ( (pr_default.getStatus(1) != 101) )
         {
            A673BancoId = P00HR3_A673BancoId[0];
            A674BancoNombre = P00HR3_A674BancoNombre[0];
            AV11Banco = new GeneXus.Programs.apis.SdtSDTComercioForanea_BancoItem(context);
            AV11Banco.gxTpr_Bancoid = A673BancoId;
            AV11Banco.gxTpr_Banconombre = A674BancoNombre;
            AV9SDTComercioForanea.gxTpr_Banco.Add(AV11Banco, 0);
            pr_default.readNext(1);
         }
         pr_default.close(1);
         /* Using cursor P00HR4 */
         pr_default.execute(2);
         while ( (pr_default.getStatus(2) != 101) )
         {
            A40000DocumentacionIcono_GXI = P00HR4_A40000DocumentacionIcono_GXI[0];
            A488DocumentacionId = P00HR4_A488DocumentacionId[0];
            A498DocumentacionIcono = P00HR4_A498DocumentacionIcono[0];
            AV12DocumentacionItem = new GeneXus.Programs.apis.SdtSDTComercioForanea_DocumentacionItem(context);
            AV12DocumentacionItem.gxTpr_Documentacionid = A488DocumentacionId;
            AV12DocumentacionItem.gxTpr_Documentacionicono = A498DocumentacionIcono;
            AV12DocumentacionItem.gxTpr_Documentacionicono_gxi = A40000DocumentacionIcono_GXI;
            AV9SDTComercioForanea.gxTpr_Documentacion.Add(AV12DocumentacionItem, 0);
            pr_default.readNext(2);
         }
         pr_default.close(2);
         AV15ProveedorEstadoCollection.Add("HAB", 0);
         AV15ProveedorEstadoCollection.Add("DES", 0);
         AV15ProveedorEstadoCollection.Add("PEN", 0);
         AV9SDTComercioForanea.gxTpr_Proveedorestado = AV15ProveedorEstadoCollection;
         AV16ProveedorPagoDefaultCollection.Add("O", 0);
         AV16ProveedorPagoDefaultCollection.Add("F", 0);
         AV16ProveedorPagoDefaultCollection.Add("T", 0);
         AV9SDTComercioForanea.gxTpr_Proveedorpagodefault = AV16ProveedorPagoDefaultCollection;
         AV13ComercioForanea = AV9SDTComercioForanea.ToJSonString(false, true);
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
         AV13ComercioForanea = "";
         P00HR2_A151ProveedoresTipoId = new long[1] ;
         P00HR2_A278ProveedoresTipoNombre = new string[] {""} ;
         A278ProveedoresTipoNombre = "";
         AV10ProveedoresTipoItem = new GeneXus.Programs.apis.SdtSDTComercioForanea_ProveedoresTipoItem(context);
         AV9SDTComercioForanea = new GeneXus.Programs.apis.SdtSDTComercioForanea(context);
         P00HR3_A673BancoId = new long[1] ;
         P00HR3_A674BancoNombre = new string[] {""} ;
         A674BancoNombre = "";
         AV11Banco = new GeneXus.Programs.apis.SdtSDTComercioForanea_BancoItem(context);
         P00HR4_A40000DocumentacionIcono_GXI = new string[] {""} ;
         P00HR4_A488DocumentacionId = new long[1] ;
         P00HR4_A498DocumentacionIcono = new string[] {""} ;
         A40000DocumentacionIcono_GXI = "";
         A498DocumentacionIcono = "";
         AV12DocumentacionItem = new GeneXus.Programs.apis.SdtSDTComercioForanea_DocumentacionItem(context);
         AV15ProveedorEstadoCollection = new GxSimpleCollection<string>();
         AV16ProveedorPagoDefaultCollection = new GxSimpleCollection<string>();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.apis.obtenercomercioforanea__default(),
            new Object[][] {
                new Object[] {
               P00HR2_A151ProveedoresTipoId, P00HR2_A278ProveedoresTipoNombre
               }
               , new Object[] {
               P00HR3_A673BancoId, P00HR3_A674BancoNombre
               }
               , new Object[] {
               P00HR4_A40000DocumentacionIcono_GXI, P00HR4_A488DocumentacionId, P00HR4_A498DocumentacionIcono
               }
            }
         );
         /* GeneXus formulas. */
      }

      private long A151ProveedoresTipoId ;
      private long A673BancoId ;
      private long A488DocumentacionId ;
      private string A278ProveedoresTipoNombre ;
      private string A674BancoNombre ;
      private string AV13ComercioForanea ;
      private string A40000DocumentacionIcono_GXI ;
      private string A498DocumentacionIcono ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private long[] P00HR2_A151ProveedoresTipoId ;
      private string[] P00HR2_A278ProveedoresTipoNombre ;
      private GeneXus.Programs.apis.SdtSDTComercioForanea_ProveedoresTipoItem AV10ProveedoresTipoItem ;
      private GeneXus.Programs.apis.SdtSDTComercioForanea AV9SDTComercioForanea ;
      private long[] P00HR3_A673BancoId ;
      private string[] P00HR3_A674BancoNombre ;
      private GeneXus.Programs.apis.SdtSDTComercioForanea_BancoItem AV11Banco ;
      private string[] P00HR4_A40000DocumentacionIcono_GXI ;
      private long[] P00HR4_A488DocumentacionId ;
      private string[] P00HR4_A498DocumentacionIcono ;
      private GeneXus.Programs.apis.SdtSDTComercioForanea_DocumentacionItem AV12DocumentacionItem ;
      private GxSimpleCollection<string> AV15ProveedorEstadoCollection ;
      private GxSimpleCollection<string> AV16ProveedorPagoDefaultCollection ;
      private string aP0_ComercioForanea ;
   }

   public class obtenercomercioforanea__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP00HR2;
          prmP00HR2 = new Object[] {
          };
          Object[] prmP00HR3;
          prmP00HR3 = new Object[] {
          };
          Object[] prmP00HR4;
          prmP00HR4 = new Object[] {
          };
          def= new CursorDef[] {
              new CursorDef("P00HR2", "SELECT [ProveedoresTipoId], [ProveedoresTipoNombre] FROM [ProveedoresTipo] ORDER BY [ProveedoresTipoId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00HR2,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P00HR3", "SELECT [BancoId], [BancoNombre] FROM [Banco] ORDER BY [BancoId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00HR3,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P00HR4", "SELECT [DocumentacionIcono_GXI], [DocumentacionId], [DocumentacionIcono] FROM [Documentacion] ORDER BY [DocumentacionId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00HR4,100, GxCacheFrequency.OFF ,false,false )
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
                ((string[]) buf[1])[0] = rslt.getString(2, 120);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 80);
                return;
             case 2 :
                ((string[]) buf[0])[0] = rslt.getMultimediaUri(1);
                ((long[]) buf[1])[0] = rslt.getLong(2);
                ((string[]) buf[2])[0] = rslt.getMultimediaFile(3, rslt.getVarchar(1));
                return;
       }
    }

 }

}

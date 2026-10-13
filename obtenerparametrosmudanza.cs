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
   public class obtenerparametrosmudanza : GXProcedure
   {
      public obtenerparametrosmudanza( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public obtenerparametrosmudanza( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( out GXBaseCollection<SdtSDTCarga_SDTCargaItem> aP0_SDTCarga )
      {
         this.AV8SDTCarga = new GXBaseCollection<SdtSDTCarga_SDTCargaItem>( context, "SDTCargaItem", "AlmangoX") ;
         initialize();
         ExecutePrivate();
         aP0_SDTCarga=this.AV8SDTCarga;
      }

      public GXBaseCollection<SdtSDTCarga_SDTCargaItem> executeUdp( )
      {
         execute(out aP0_SDTCarga);
         return AV8SDTCarga ;
      }

      public void executeSubmit( out GXBaseCollection<SdtSDTCarga_SDTCargaItem> aP0_SDTCarga )
      {
         this.AV8SDTCarga = new GXBaseCollection<SdtSDTCarga_SDTCargaItem>( context, "SDTCargaItem", "AlmangoX") ;
         SubmitImpl();
         aP0_SDTCarga=this.AV8SDTCarga;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV8SDTCarga.Clear();
         /* Using cursor P00I92 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            A877ParametroMudanzaActivo = P00I92_A877ParametroMudanzaActivo[0];
            A730ParametroMudanzaId = P00I92_A730ParametroMudanzaId[0];
            A731ParametroMudanzaTipo = P00I92_A731ParametroMudanzaTipo[0];
            A869ParametroMudanzaTitulo = P00I92_A869ParametroMudanzaTitulo[0];
            A40000ParametroMudanzaImagen_GXI = P00I92_A40000ParametroMudanzaImagen_GXI[0];
            A732ParametroMudanzaNombre = P00I92_A732ParametroMudanzaNombre[0];
            A733ParametroMudanzaValor = P00I92_A733ParametroMudanzaValor[0];
            A734ParametroMudanzaUnidad = P00I92_A734ParametroMudanzaUnidad[0];
            A812ParametroMudanzaDescripcion = P00I92_A812ParametroMudanzaDescripcion[0];
            A818ParametroMudanzaPisoElev = P00I92_A818ParametroMudanzaPisoElev[0];
            A870ParametroMudanzaImagen = P00I92_A870ParametroMudanzaImagen[0];
            AV9SDTCargaItem = new SdtSDTCarga_SDTCargaItem(context);
            AV9SDTCargaItem.gxTpr_Id = A730ParametroMudanzaId;
            AV9SDTCargaItem.gxTpr_Tipo = A731ParametroMudanzaTipo;
            AV9SDTCargaItem.gxTpr_Titulo = A869ParametroMudanzaTitulo;
            AV10Imagen = A870ParametroMudanzaImagen;
            AV9SDTCargaItem.gxTpr_Imagen = context.FileToBase64( AV10Imagen);
            AV9SDTCargaItem.gxTpr_Nombre = A732ParametroMudanzaNombre;
            AV9SDTCargaItem.gxTpr_Valor = A733ParametroMudanzaValor;
            AV9SDTCargaItem.gxTpr_Unidad = A734ParametroMudanzaUnidad;
            AV9SDTCargaItem.gxTpr_Descripcion = A812ParametroMudanzaDescripcion;
            AV9SDTCargaItem.gxTpr_Elevacioncant = A818ParametroMudanzaPisoElev;
            AV9SDTCargaItem.gxTpr_Activo = A877ParametroMudanzaActivo;
            AV8SDTCarga.Add(AV9SDTCargaItem, 0);
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
         AV8SDTCarga = new GXBaseCollection<SdtSDTCarga_SDTCargaItem>( context, "SDTCargaItem", "AlmangoX");
         P00I92_A877ParametroMudanzaActivo = new bool[] {false} ;
         P00I92_A730ParametroMudanzaId = new short[1] ;
         P00I92_A731ParametroMudanzaTipo = new string[] {""} ;
         P00I92_A869ParametroMudanzaTitulo = new string[] {""} ;
         P00I92_A40000ParametroMudanzaImagen_GXI = new string[] {""} ;
         P00I92_A732ParametroMudanzaNombre = new string[] {""} ;
         P00I92_A733ParametroMudanzaValor = new decimal[1] ;
         P00I92_A734ParametroMudanzaUnidad = new string[] {""} ;
         P00I92_A812ParametroMudanzaDescripcion = new string[] {""} ;
         P00I92_A818ParametroMudanzaPisoElev = new short[1] ;
         P00I92_A870ParametroMudanzaImagen = new string[] {""} ;
         A731ParametroMudanzaTipo = "";
         A869ParametroMudanzaTitulo = "";
         A40000ParametroMudanzaImagen_GXI = "";
         A732ParametroMudanzaNombre = "";
         A734ParametroMudanzaUnidad = "";
         A812ParametroMudanzaDescripcion = "";
         A870ParametroMudanzaImagen = "";
         AV9SDTCargaItem = new SdtSDTCarga_SDTCargaItem(context);
         AV10Imagen = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.obtenerparametrosmudanza__default(),
            new Object[][] {
                new Object[] {
               P00I92_A877ParametroMudanzaActivo, P00I92_A730ParametroMudanzaId, P00I92_A731ParametroMudanzaTipo, P00I92_A869ParametroMudanzaTitulo, P00I92_A40000ParametroMudanzaImagen_GXI, P00I92_A732ParametroMudanzaNombre, P00I92_A733ParametroMudanzaValor, P00I92_A734ParametroMudanzaUnidad, P00I92_A812ParametroMudanzaDescripcion, P00I92_A818ParametroMudanzaPisoElev,
               P00I92_A870ParametroMudanzaImagen
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short A730ParametroMudanzaId ;
      private short A818ParametroMudanzaPisoElev ;
      private decimal A733ParametroMudanzaValor ;
      private string A734ParametroMudanzaUnidad ;
      private bool A877ParametroMudanzaActivo ;
      private string A731ParametroMudanzaTipo ;
      private string A869ParametroMudanzaTitulo ;
      private string A40000ParametroMudanzaImagen_GXI ;
      private string A732ParametroMudanzaNombre ;
      private string A812ParametroMudanzaDescripcion ;
      private string A870ParametroMudanzaImagen ;
      private string AV10Imagen ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GXBaseCollection<SdtSDTCarga_SDTCargaItem> AV8SDTCarga ;
      private IDataStoreProvider pr_default ;
      private bool[] P00I92_A877ParametroMudanzaActivo ;
      private short[] P00I92_A730ParametroMudanzaId ;
      private string[] P00I92_A731ParametroMudanzaTipo ;
      private string[] P00I92_A869ParametroMudanzaTitulo ;
      private string[] P00I92_A40000ParametroMudanzaImagen_GXI ;
      private string[] P00I92_A732ParametroMudanzaNombre ;
      private decimal[] P00I92_A733ParametroMudanzaValor ;
      private string[] P00I92_A734ParametroMudanzaUnidad ;
      private string[] P00I92_A812ParametroMudanzaDescripcion ;
      private short[] P00I92_A818ParametroMudanzaPisoElev ;
      private string[] P00I92_A870ParametroMudanzaImagen ;
      private SdtSDTCarga_SDTCargaItem AV9SDTCargaItem ;
      private GXBaseCollection<SdtSDTCarga_SDTCargaItem> aP0_SDTCarga ;
   }

   public class obtenerparametrosmudanza__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP00I92;
          prmP00I92 = new Object[] {
          };
          def= new CursorDef[] {
              new CursorDef("P00I92", "SELECT [ParametroMudanzaActivo], [ParametroMudanzaId], [ParametroMudanzaTipo], [ParametroMudanzaTitulo], [ParametroMudanzaImagen_GXI], [ParametroMudanzaNombre], [ParametroMudanzaValor], [ParametroMudanzaUnidad], [ParametroMudanzaDescripcion], [ParametroMudanzaPisoElev], [ParametroMudanzaImagen] FROM [ParametroMudanza] WHERE [ParametroMudanzaActivo] = 1 ORDER BY [ParametroMudanzaId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00I92,100, GxCacheFrequency.OFF ,false,false )
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
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((string[]) buf[4])[0] = rslt.getMultimediaUri(5);
                ((string[]) buf[5])[0] = rslt.getVarchar(6);
                ((decimal[]) buf[6])[0] = rslt.getDecimal(7);
                ((string[]) buf[7])[0] = rslt.getString(8, 2);
                ((string[]) buf[8])[0] = rslt.getVarchar(9);
                ((short[]) buf[9])[0] = rslt.getShort(10);
                ((string[]) buf[10])[0] = rslt.getMultimediaFile(11, rslt.getVarchar(5));
                return;
       }
    }

 }

}

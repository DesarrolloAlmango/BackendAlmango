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
   public class aupdatemudanzaweb : GXProcedure
   {
      public aupdatemudanzaweb( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public aupdatemudanzaweb( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( long aP0_MudanzaId ,
                           string aP1_SDTMudanzaJson ,
                           string aP2_SDTCargaJson ,
                           out string aP3_Mensaje )
      {
         this.AV17MudanzaId = aP0_MudanzaId;
         this.AV10SDTMudanzaJson = aP1_SDTMudanzaJson;
         this.AV15SDTCargaJson = aP2_SDTCargaJson;
         this.AV13Mensaje = "" ;
         initialize();
         ExecutePrivate();
         aP3_Mensaje=this.AV13Mensaje;
      }

      public string executeUdp( long aP0_MudanzaId ,
                                string aP1_SDTMudanzaJson ,
                                string aP2_SDTCargaJson )
      {
         execute(aP0_MudanzaId, aP1_SDTMudanzaJson, aP2_SDTCargaJson, out aP3_Mensaje);
         return AV13Mensaje ;
      }

      public void executeSubmit( long aP0_MudanzaId ,
                                 string aP1_SDTMudanzaJson ,
                                 string aP2_SDTCargaJson ,
                                 out string aP3_Mensaje )
      {
         this.AV17MudanzaId = aP0_MudanzaId;
         this.AV10SDTMudanzaJson = aP1_SDTMudanzaJson;
         this.AV15SDTCargaJson = aP2_SDTCargaJson;
         this.AV13Mensaje = "" ;
         SubmitImpl();
         aP3_Mensaje=this.AV13Mensaje;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV9SDTMudanza.FromJSonString(AV10SDTMudanzaJson, null);
         AV14SDTCarga.FromJSonString(AV15SDTCargaJson, null);
         /* Optimized DELETE. */
         /* Using cursor P00IG2 */
         pr_default.execute(0, new Object[] {AV17MudanzaId});
         pr_default.close(0);
         pr_default.SmartCacheProvider.SetUpdated("MudanzaCarga");
         /* End optimized DELETE. */
         AV8Mudanza.Load(AV17MudanzaId);
         AV8Mudanza.gxTpr_Tipoinmuebleorigenid = AV9SDTMudanza.gxTpr_Tipoinmuebleorigenid;
         AV8Mudanza.gxTpr_Tipoinmuebledestinoid = AV9SDTMudanza.gxTpr_Tipoinmuebledestinoid;
         AV8Mudanza.gxTpr_Tipoestacionamorigenid = AV9SDTMudanza.gxTpr_Tipoestacionamorigenid;
         AV8Mudanza.gxTpr_Tipoestacionamdestinoid = AV9SDTMudanza.gxTpr_Tipoestacionamdestinoid;
         AV8Mudanza.gxTpr_Mudanzadireccionorigen = AV9SDTMudanza.gxTpr_Mudanzadireccionorigen;
         AV8Mudanza.gxTpr_Mudanzadirecciondestino = AV9SDTMudanza.gxTpr_Mudanzadirecciondestino;
         AV8Mudanza.gxTpr_Mudanzacoordenadadestino = AV9SDTMudanza.gxTpr_Mudanzacoordenadasdestino;
         AV8Mudanza.gxTpr_Mudanzacoordenadaorigen = AV9SDTMudanza.gxTpr_Mudanzacoordenadasorigen;
         AV8Mudanza.gxTpr_Mudanzasecuserid = AV9SDTMudanza.gxTpr_Mudanzasecuserid;
         AV8Mudanza.gxTpr_Mudanzaformapago = AV9SDTMudanza.gxTpr_Mudanzaformapago;
         AV8Mudanza.gxTpr_Mudanzacomentario = AV9SDTMudanza.gxTpr_Mudanzacomentario;
         AV8Mudanza.gxTpr_Mudanzavehiculosugerido = AV9SDTMudanza.gxTpr_Mudanzavehiculosugerido;
         AV8Mudanza.gxTpr_Mudanzahoraservicio = AV9SDTMudanza.gxTpr_Mudanzahoraservicio;
         AV8Mudanza.gxTpr_Mudanzargohoraservicio = AV9SDTMudanza.gxTpr_Mudanzargohoraservicio;
         AV8Mudanza.gxTpr_Mudanzafechaupdate = Gx_date;
         AV8Mudanza.gxTpr_Mudanzafechaservicio = AV9SDTMudanza.gxTpr_Mudanzafechaservicio;
         AV8Mudanza.gxTpr_Mudanzaorigenmetodo = AV9SDTMudanza.gxTpr_Mudanzaorigenmetodo;
         AV8Mudanza.gxTpr_Mudanzadestinometodo = AV9SDTMudanza.gxTpr_Mudanzadestinometodo;
         AV8Mudanza.gxTpr_Mudanzapisodptoorigen = AV9SDTMudanza.gxTpr_Mudanzapisodptoorigen;
         AV8Mudanza.gxTpr_Mudanzapisodptodestino = AV9SDTMudanza.gxTpr_Mudanzapisodptodestino;
         AV8Mudanza.gxTpr_Mudanzapreciobasexhora = AV9SDTMudanza.gxTpr_Mudanzapreciobasexhora;
         AV8Mudanza.gxTpr_Mudanzadistancia = AV9SDTMudanza.gxTpr_Mudanzadistancia;
         AV8Mudanza.gxTpr_Mudanzalocalidadorigen = AV9SDTMudanza.gxTpr_Mudanzalocalidadorigen;
         AV8Mudanza.gxTpr_Mudanzalocalidaddestino = AV9SDTMudanza.gxTpr_Mudanzalocalidaddestino;
         AV8Mudanza.gxTpr_Mudanzatiempomaximo = AV9SDTMudanza.gxTpr_Mudanzatiempomaximo;
         AV8Mudanza.gxTpr_Mudanzapreciofinal = AV9SDTMudanza.gxTpr_Mudanzapreciofinal;
         AV8Mudanza.gxTpr_Mudanzaapellidonombre = AV9SDTMudanza.gxTpr_Mudanzaapellidonombre;
         AV8Mudanza.gxTpr_Mudanzamail = AV9SDTMudanza.gxTpr_Mudanzamail;
         AV8Mudanza.gxTpr_Mudanzaphone = AV9SDTMudanza.gxTpr_Mudanzaphone;
         AV8Mudanza.gxTpr_Mudanzacargavolumenestimado = AV9SDTMudanza.gxTpr_Mudanzacargavolumenestimado;
         AV8Mudanza.gxTpr_Mudanzacantidadpeones = AV9SDTMudanza.gxTpr_Mudanzacantidadpeones;
         AV8Mudanza.gxTpr_Mudanzaadicionalprecio = AV9SDTMudanza.gxTpr_Mudanzaadicionalprecio;
         AV8Mudanza.gxTpr_Mudanzaelevacion = AV9SDTMudanza.gxTpr_Mudanzaelevacion;
         AV8Mudanza.gxTpr_Mudanzadescenso = AV9SDTMudanza.gxTpr_Mudanzadescenso;
         AV8Mudanza.gxTpr_Mudanzaembalaje = AV9SDTMudanza.gxTpr_Mudanzaembalaje;
         AV24GXV1 = 1;
         while ( AV24GXV1 <= AV14SDTCarga.Count )
         {
            AV16SDTCargaItem = ((SdtSDTCarga_SDTCargaItem)AV14SDTCarga.Item(AV24GXV1));
            AV20MudanzaCargaItem = new SdtMudanza_Carga(context);
            AV20MudanzaCargaItem.gxTpr_Itemcargaid = AV16SDTCargaItem.gxTpr_Id;
            AV20MudanzaCargaItem.gxTpr_Itemcargacantidad = AV16SDTCargaItem.gxTpr_Cantidad;
            AV20MudanzaCargaItem.gxTpr_Itemcargaembcant = AV16SDTCargaItem.gxTpr_Embalajecant;
            AV8Mudanza.gxTpr_Carga.Add(AV20MudanzaCargaItem, 0);
            AV24GXV1 = (int)(AV24GXV1+1);
         }
         AV8Mudanza.Update();
         if ( AV8Mudanza.Success() )
         {
            AV13Mensaje = context.GetMessage( "Ok", "");
            /* Using cursor P00IG3 */
            pr_default.execute(1, new Object[] {AV17MudanzaId});
            while ( (pr_default.getStatus(1) != 101) )
            {
               A735MudanzaId = P00IG3_A735MudanzaId[0];
               n735MudanzaId = P00IG3_n735MudanzaId[0];
               A212SolicitudesCotizacion = P00IG3_A212SolicitudesCotizacion[0];
               A598SolicitudesUsrActualizacion = P00IG3_A598SolicitudesUsrActualizacion[0];
               n598SolicitudesUsrActualizacion = P00IG3_n598SolicitudesUsrActualizacion[0];
               A127SolicitudesID = P00IG3_A127SolicitudesID[0];
               A212SolicitudesCotizacion = AV9SDTMudanza.gxTpr_Mudanzapreciofinal;
               new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV21WWPContext) ;
               A598SolicitudesUsrActualizacion = AV21WWPContext.gxTpr_Userid;
               n598SolicitudesUsrActualizacion = false;
               /* Using cursor P00IG4 */
               pr_default.execute(2, new Object[] {A212SolicitudesCotizacion, n598SolicitudesUsrActualizacion, A598SolicitudesUsrActualizacion, A127SolicitudesID});
               pr_default.close(2);
               pr_default.SmartCacheProvider.SetUpdated("Solicitudes");
               pr_default.readNext(1);
            }
            pr_default.close(1);
            context.CommitDataStores("updatemudanzaweb",pr_default);
         }
         else
         {
            AV11Messages = AV8Mudanza.GetMessages();
            AV26GXV2 = 1;
            while ( AV26GXV2 <= AV11Messages.Count )
            {
               AV12Message = ((GeneXus.Utils.SdtMessages_Message)AV11Messages.Item(AV26GXV2));
               AV13Mensaje = AV12Message.gxTpr_Description;
               AV26GXV2 = (int)(AV26GXV2+1);
            }
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
         AV13Mensaje = "";
         AV9SDTMudanza = new SdtSDTMudanza(context);
         AV14SDTCarga = new GXBaseCollection<SdtSDTCarga_SDTCargaItem>( context, "SDTCargaItem", "AlmangoX");
         AV8Mudanza = new SdtMudanza(context);
         Gx_date = DateTime.MinValue;
         AV16SDTCargaItem = new SdtSDTCarga_SDTCargaItem(context);
         AV20MudanzaCargaItem = new SdtMudanza_Carga(context);
         P00IG3_A735MudanzaId = new long[1] ;
         P00IG3_n735MudanzaId = new bool[] {false} ;
         P00IG3_A212SolicitudesCotizacion = new decimal[1] ;
         P00IG3_A598SolicitudesUsrActualizacion = new long[1] ;
         P00IG3_n598SolicitudesUsrActualizacion = new bool[] {false} ;
         P00IG3_A127SolicitudesID = new long[1] ;
         AV21WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV11Messages = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         AV12Message = new GeneXus.Utils.SdtMessages_Message(context);
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.aupdatemudanzaweb__datastore1(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.aupdatemudanzaweb__default(),
            new Object[][] {
                new Object[] {
               }
               , new Object[] {
               P00IG3_A735MudanzaId, P00IG3_n735MudanzaId, P00IG3_A212SolicitudesCotizacion, P00IG3_A598SolicitudesUsrActualizacion, P00IG3_n598SolicitudesUsrActualizacion, P00IG3_A127SolicitudesID
               }
               , new Object[] {
               }
            }
         );
         Gx_date = DateTimeUtil.Today( context);
         /* GeneXus formulas. */
         Gx_date = DateTimeUtil.Today( context);
      }

      private int AV24GXV1 ;
      private int AV26GXV2 ;
      private long AV17MudanzaId ;
      private long A735MudanzaId ;
      private long A598SolicitudesUsrActualizacion ;
      private long A127SolicitudesID ;
      private decimal A212SolicitudesCotizacion ;
      private DateTime Gx_date ;
      private bool n735MudanzaId ;
      private bool n598SolicitudesUsrActualizacion ;
      private string AV10SDTMudanzaJson ;
      private string AV15SDTCargaJson ;
      private string AV13Mensaje ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private SdtSDTMudanza AV9SDTMudanza ;
      private GXBaseCollection<SdtSDTCarga_SDTCargaItem> AV14SDTCarga ;
      private IDataStoreProvider pr_default ;
      private SdtMudanza AV8Mudanza ;
      private SdtSDTCarga_SDTCargaItem AV16SDTCargaItem ;
      private SdtMudanza_Carga AV20MudanzaCargaItem ;
      private long[] P00IG3_A735MudanzaId ;
      private bool[] P00IG3_n735MudanzaId ;
      private decimal[] P00IG3_A212SolicitudesCotizacion ;
      private long[] P00IG3_A598SolicitudesUsrActualizacion ;
      private bool[] P00IG3_n598SolicitudesUsrActualizacion ;
      private long[] P00IG3_A127SolicitudesID ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV21WWPContext ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV11Messages ;
      private GeneXus.Utils.SdtMessages_Message AV12Message ;
      private string aP3_Mensaje ;
      private IDataStoreProvider pr_datastore1 ;
   }

   public class aupdatemudanzaweb__datastore1 : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          def= new CursorDef[] {
          };
       }
    }

    public void getResults( int cursor ,
                            IFieldGetter rslt ,
                            Object[] buf )
    {
    }

    public override string getDataStoreName( )
    {
       return "DATASTORE1";
    }

 }

 public class aupdatemudanzaweb__default : DataStoreHelperBase, IDataStoreHelper
 {
    public ICursor[] getCursors( )
    {
       cursorDefinitions();
       return new Cursor[] {
        new UpdateCursor(def[0])
       ,new ForEachCursor(def[1])
       ,new UpdateCursor(def[2])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmP00IG2;
        prmP00IG2 = new Object[] {
        new ParDef("@AV17MudanzaId",GXType.Decimal,18,0)
        };
        Object[] prmP00IG3;
        prmP00IG3 = new Object[] {
        new ParDef("@AV17MudanzaId",GXType.Decimal,18,0)
        };
        Object[] prmP00IG4;
        prmP00IG4 = new Object[] {
        new ParDef("@SolicitudesCotizacion",GXType.Decimal,18,2) ,
        new ParDef("@SolicitudesUsrActualizacion",GXType.Decimal,10,0){Nullable=true} ,
        new ParDef("@SolicitudesID",GXType.Decimal,18,0)
        };
        def= new CursorDef[] {
            new CursorDef("P00IG2", "DELETE FROM [MudanzaCarga]  WHERE [MudanzaId] = @AV17MudanzaId", GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP00IG2)
           ,new CursorDef("P00IG3", "SELECT [MudanzaId], [SolicitudesCotizacion], [SolicitudesUsrActualizacion], [SolicitudesID] FROM [Solicitudes] WITH (UPDLOCK) WHERE [MudanzaId] = @AV17MudanzaId ORDER BY [SolicitudesID] DESC ",true, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00IG3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("P00IG4", "UPDATE [Solicitudes] SET [SolicitudesCotizacion]=@SolicitudesCotizacion, [SolicitudesUsrActualizacion]=@SolicitudesUsrActualizacion  WHERE [SolicitudesID] = @SolicitudesID", GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP00IG4)
        };
     }
  }

  public void getResults( int cursor ,
                          IFieldGetter rslt ,
                          Object[] buf )
  {
     switch ( cursor )
     {
           case 1 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((bool[]) buf[1])[0] = rslt.wasNull(1);
              ((decimal[]) buf[2])[0] = rslt.getDecimal(2);
              ((long[]) buf[3])[0] = rslt.getLong(3);
              ((bool[]) buf[4])[0] = rslt.wasNull(3);
              ((long[]) buf[5])[0] = rslt.getLong(4);
              return;
     }
  }

}

}

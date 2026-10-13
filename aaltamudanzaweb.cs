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
   public class aaltamudanzaweb : GXProcedure
   {
      public aaltamudanzaweb( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public aaltamudanzaweb( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_SDTMudanzaJson ,
                           string aP1_SDTCargaJson ,
                           out long aP2_MudanzaId ,
                           out long aP3_SolicitudId ,
                           out string aP4_Mensaje )
      {
         this.AV10SDTMudanzaJson = aP0_SDTMudanzaJson;
         this.AV15SDTCargaJson = aP1_SDTCargaJson;
         this.AV17MudanzaId = 0 ;
         this.AV20SolicitudId = 0 ;
         this.AV13Mensaje = "" ;
         initialize();
         ExecutePrivate();
         aP2_MudanzaId=this.AV17MudanzaId;
         aP3_SolicitudId=this.AV20SolicitudId;
         aP4_Mensaje=this.AV13Mensaje;
      }

      public string executeUdp( string aP0_SDTMudanzaJson ,
                                string aP1_SDTCargaJson ,
                                out long aP2_MudanzaId ,
                                out long aP3_SolicitudId )
      {
         execute(aP0_SDTMudanzaJson, aP1_SDTCargaJson, out aP2_MudanzaId, out aP3_SolicitudId, out aP4_Mensaje);
         return AV13Mensaje ;
      }

      public void executeSubmit( string aP0_SDTMudanzaJson ,
                                 string aP1_SDTCargaJson ,
                                 out long aP2_MudanzaId ,
                                 out long aP3_SolicitudId ,
                                 out string aP4_Mensaje )
      {
         this.AV10SDTMudanzaJson = aP0_SDTMudanzaJson;
         this.AV15SDTCargaJson = aP1_SDTCargaJson;
         this.AV17MudanzaId = 0 ;
         this.AV20SolicitudId = 0 ;
         this.AV13Mensaje = "" ;
         SubmitImpl();
         aP2_MudanzaId=this.AV17MudanzaId;
         aP3_SolicitudId=this.AV20SolicitudId;
         aP4_Mensaje=this.AV13Mensaje;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV9SDTMudanza.FromJSonString(AV10SDTMudanzaJson, null);
         AV14SDTCarga.FromJSonString(AV15SDTCargaJson, null);
         AV8Mudanza = new SdtMudanza(context);
         AV8Mudanza.gxTpr_Tipoinmuebleorigenid = AV9SDTMudanza.gxTpr_Tipoinmuebleorigenid;
         AV8Mudanza.gxTpr_Tipoinmuebledestinoid = AV9SDTMudanza.gxTpr_Tipoinmuebledestinoid;
         AV8Mudanza.gxTpr_Tipoestacionamorigenid = AV9SDTMudanza.gxTpr_Tipoestacionamorigenid;
         AV8Mudanza.gxTpr_Tipoestacionamdestinoid = AV9SDTMudanza.gxTpr_Tipoestacionamdestinoid;
         AV8Mudanza.gxTpr_Mudanzadireccionorigen = AV9SDTMudanza.gxTpr_Mudanzadireccionorigen;
         AV8Mudanza.gxTpr_Mudanzadirecciondestino = AV9SDTMudanza.gxTpr_Mudanzadirecciondestino;
         AV8Mudanza.gxTpr_Mudanzacoordenadadestino = AV9SDTMudanza.gxTpr_Mudanzacoordenadasdestino;
         AV8Mudanza.gxTpr_Mudanzacoordenadaorigen = AV9SDTMudanza.gxTpr_Mudanzacoordenadasorigen;
         if ( (0==AV9SDTMudanza.gxTpr_Mudanzaproveedorid) )
         {
            AV8Mudanza.gxTpr_Mudanzaproveedorid = 21101;
         }
         else
         {
            AV8Mudanza.gxTpr_Mudanzaproveedorid = AV9SDTMudanza.gxTpr_Mudanzaproveedorid;
         }
         AV8Mudanza.gxTpr_Mudanzasecuserid = AV9SDTMudanza.gxTpr_Mudanzasecuserid;
         AV8Mudanza.gxTpr_Mudanzaformapago = AV9SDTMudanza.gxTpr_Mudanzaformapago;
         AV8Mudanza.gxTpr_Mudanzacomentario = AV9SDTMudanza.gxTpr_Mudanzacomentario;
         AV8Mudanza.gxTpr_Mudanzavehiculosugerido = AV9SDTMudanza.gxTpr_Mudanzavehiculosugerido;
         AV8Mudanza.gxTpr_Mudanzahoraservicio = AV9SDTMudanza.gxTpr_Mudanzahoraservicio;
         AV8Mudanza.gxTpr_Mudanzargohoraservicio = AV9SDTMudanza.gxTpr_Mudanzargohoraservicio;
         AV8Mudanza.gxTpr_Mudanzafechaalta = Gx_date;
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
         AV8Mudanza.gxTpr_Mudanzaelevacion = AV9SDTMudanza.gxTpr_Mudanzaelevacion;
         AV8Mudanza.gxTpr_Mudanzadescenso = AV9SDTMudanza.gxTpr_Mudanzadescenso;
         AV8Mudanza.gxTpr_Mudanzacantidadpeones = AV9SDTMudanza.gxTpr_Mudanzacantidadpeones;
         AV8Mudanza.gxTpr_Mudanzaadicionalprecio = AV9SDTMudanza.gxTpr_Mudanzaadicionalprecio;
         AV8Mudanza.gxTpr_Mudanzaembalaje = AV9SDTMudanza.gxTpr_Mudanzaembalaje;
         AV8Mudanza.Insert();
         if ( AV8Mudanza.Success() )
         {
            AV13Mensaje = context.GetMessage( "Ok", "");
            AV17MudanzaId = AV8Mudanza.gxTpr_Mudanzaid;
            context.CommitDataStores("altamudanzaweb",pr_default);
            AV23GXV1 = 1;
            while ( AV23GXV1 <= AV14SDTCarga.Count )
            {
               AV16SDTCargaItem = ((SdtSDTCarga_SDTCargaItem)AV14SDTCarga.Item(AV23GXV1));
               /*
                  INSERT RECORD ON TABLE MudanzaCarga

               */
               A735MudanzaId = AV8Mudanza.gxTpr_Mudanzaid;
               A751ItemCargaId = AV16SDTCargaItem.gxTpr_Id;
               A753ItemCargaCantidad = AV16SDTCargaItem.gxTpr_Cantidad;
               A813ItemCargaEmbCant = AV16SDTCargaItem.gxTpr_Embalajecant;
               n813ItemCargaEmbCant = false;
               /* Using cursor P00IB2 */
               pr_default.execute(0, new Object[] {A735MudanzaId, A751ItemCargaId, A753ItemCargaCantidad, n813ItemCargaEmbCant, A813ItemCargaEmbCant});
               pr_default.close(0);
               pr_default.SmartCacheProvider.SetUpdated("MudanzaCarga");
               if ( (pr_default.getStatus(0) == 1) )
               {
                  context.Gx_err = 1;
                  Gx_emsg = (string)(context.GetMessage( "GXM_noupdate", ""));
               }
               else
               {
                  context.Gx_err = 0;
                  Gx_emsg = "";
               }
               /* End Insert */
               AV23GXV1 = (int)(AV23GXV1+1);
            }
            if ( StringUtil.StrCmp(AV9SDTMudanza.gxTpr_Mudanzaformapago, "Efectivo") == 0 )
            {
               new altamudanzasolefectivo(context ).execute(  AV8Mudanza, out  AV20SolicitudId, out  AV21MsgSolicitud) ;
            }
            else
            {
               new altamudanzasolmpago(context ).execute(  AV8Mudanza, out  AV20SolicitudId, out  AV21MsgSolicitud) ;
            }
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV21MsgSolicitud)) )
            {
               AV13Mensaje = AV21MsgSolicitud;
            }
         }
         else
         {
            AV11Messages = AV8Mudanza.GetMessages();
            AV24GXV2 = 1;
            while ( AV24GXV2 <= AV11Messages.Count )
            {
               AV12Message = ((GeneXus.Utils.SdtMessages_Message)AV11Messages.Item(AV24GXV2));
               AV13Mensaje = AV12Message.gxTpr_Description;
               AV24GXV2 = (int)(AV24GXV2+1);
            }
         }
         cleanup();
      }

      public override void cleanup( )
      {
         context.CommitDataStores("altamudanzaweb",pr_default);
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
         Gx_emsg = "";
         AV21MsgSolicitud = "";
         AV11Messages = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         AV12Message = new GeneXus.Utils.SdtMessages_Message(context);
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.aaltamudanzaweb__datastore1(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.aaltamudanzaweb__default(),
            new Object[][] {
                new Object[] {
               }
            }
         );
         Gx_date = DateTimeUtil.Today( context);
         /* GeneXus formulas. */
         Gx_date = DateTimeUtil.Today( context);
      }

      private short A751ItemCargaId ;
      private short A753ItemCargaCantidad ;
      private short A813ItemCargaEmbCant ;
      private int AV23GXV1 ;
      private int GX_INS120 ;
      private int AV24GXV2 ;
      private long AV17MudanzaId ;
      private long AV20SolicitudId ;
      private long A735MudanzaId ;
      private string Gx_emsg ;
      private DateTime Gx_date ;
      private bool n813ItemCargaEmbCant ;
      private string AV10SDTMudanzaJson ;
      private string AV15SDTCargaJson ;
      private string AV13Mensaje ;
      private string AV21MsgSolicitud ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private SdtSDTMudanza AV9SDTMudanza ;
      private GXBaseCollection<SdtSDTCarga_SDTCargaItem> AV14SDTCarga ;
      private SdtMudanza AV8Mudanza ;
      private IDataStoreProvider pr_default ;
      private SdtSDTCarga_SDTCargaItem AV16SDTCargaItem ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV11Messages ;
      private GeneXus.Utils.SdtMessages_Message AV12Message ;
      private long aP2_MudanzaId ;
      private long aP3_SolicitudId ;
      private string aP4_Mensaje ;
      private IDataStoreProvider pr_datastore1 ;
   }

   public class aaltamudanzaweb__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class aaltamudanzaweb__default : DataStoreHelperBase, IDataStoreHelper
 {
    public ICursor[] getCursors( )
    {
       cursorDefinitions();
       return new Cursor[] {
        new UpdateCursor(def[0])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmP00IB2;
        prmP00IB2 = new Object[] {
        new ParDef("@MudanzaId",GXType.Decimal,18,0) ,
        new ParDef("@ItemCargaId",GXType.Int16,4,0) ,
        new ParDef("@ItemCargaCantidad",GXType.Int16,4,0) ,
        new ParDef("@ItemCargaEmbCant",GXType.Int16,4,0){Nullable=true}
        };
        def= new CursorDef[] {
            new CursorDef("P00IB2", "INSERT INTO [MudanzaCarga]([MudanzaId], [ItemCargaId], [ItemCargaCantidad], [ItemCargaEmbCant], [ItemCargaElevCant], [ItemCargaEmbalaje], [ItemCargaElevacion]) VALUES(@MudanzaId, @ItemCargaId, @ItemCargaCantidad, @ItemCargaEmbCant, convert(int, 0), convert(bit, 0), convert(bit, 0))", GxErrorMask.GX_NOMASK,prmP00IB2)
        };
     }
  }

  public void getResults( int cursor ,
                          IFieldGetter rslt ,
                          Object[] buf )
  {
  }

}

}

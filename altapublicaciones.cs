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
   public class altapublicaciones : GXProcedure
   {
      public altapublicaciones( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public altapublicaciones( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_JsonPublicaciones ,
                           out string aP1_JsonMessages )
      {
         this.AV9JsonPublicaciones = aP0_JsonPublicaciones;
         this.AV14JsonMessages = "" ;
         initialize();
         ExecutePrivate();
         aP1_JsonMessages=this.AV14JsonMessages;
      }

      public string executeUdp( string aP0_JsonPublicaciones )
      {
         execute(aP0_JsonPublicaciones, out aP1_JsonMessages);
         return AV14JsonMessages ;
      }

      public void executeSubmit( string aP0_JsonPublicaciones ,
                                 out string aP1_JsonMessages )
      {
         this.AV9JsonPublicaciones = aP0_JsonPublicaciones;
         this.AV14JsonMessages = "" ;
         SubmitImpl();
         aP1_JsonMessages=this.AV14JsonMessages;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV8SDTPublicaciones.FromJSonString(AV9JsonPublicaciones, null);
         AV10Publicaciones = new SdtPublicaciones(context);
         AV10Publicaciones.gxTpr_Publicacionestitulo = AV8SDTPublicaciones.gxTpr_Publicacionestitulo;
         AV10Publicaciones.gxTpr_Publicacionesdescripcion = AV8SDTPublicaciones.gxTpr_Publicacionesdescripcion;
         AV10Publicaciones.gxTpr_Departamentoid = AV8SDTPublicaciones.gxTpr_Departamentoid;
         AV10Publicaciones.gxTpr_Departamentomunicipioid = AV8SDTPublicaciones.gxTpr_Departamentomunicipioid;
         AV10Publicaciones.gxTpr_Publicacionesfectentinicio = AV8SDTPublicaciones.gxTpr_Publicacionesfectentinicio;
         AV10Publicaciones.gxTpr_Publicacionesfecrealinicio = AV8SDTPublicaciones.gxTpr_Publicacionesfecrealinicio;
         AV10Publicaciones.gxTpr_Publicacionesfecfinpostulacion = AV8SDTPublicaciones.gxTpr_Publicacionesfecfinpostulacion;
         AV10Publicaciones.gxTpr_Publicacionesdetallemateriales = AV8SDTPublicaciones.gxTpr_Publicacionesdetallemateriales;
         AV10Publicaciones.gxTpr_Publicacionesfecvisita = AV8SDTPublicaciones.gxTpr_Publicacionesfecvisita;
         AV10Publicaciones.gxTpr_Publicacioneshoravisita = AV8SDTPublicaciones.gxTpr_Publicacioneshoravisita;
         AV10Publicaciones.gxTpr_Publicacionesdirvisita = AV8SDTPublicaciones.gxTpr_Publicacionesdirvisita;
         AV10Publicaciones.gxTpr_Publicacionescondiciones = AV8SDTPublicaciones.gxTpr_Publicacionescondiciones;
         AV10Publicaciones.gxTpr_Publicacionestipodesembolso = AV8SDTPublicaciones.gxTpr_Publicacionestipodesembolso;
         AV10Publicaciones.gxTpr_Publicacionesotrotipodes = AV8SDTPublicaciones.gxTpr_Publicacionesotrotipodes;
         AV10Publicaciones.gxTpr_Publicacionesmodalidad = AV8SDTPublicaciones.gxTpr_Publicacionesmodalidad;
         AV10Publicaciones.gxTpr_Publicacionesprecio = AV8SDTPublicaciones.gxTpr_Publicacionesprecio;
         AV10Publicaciones.gxTpr_Monedaid = AV8SDTPublicaciones.gxTpr_Monedaid;
         AV10Publicaciones.gxTpr_Publicacionesfeccierre = AV8SDTPublicaciones.gxTpr_Publicacionesfeccierre;
         AV10Publicaciones.gxTpr_Publicacionesdocreq = AV8SDTPublicaciones.gxTpr_Publicacionesdocreq;
         AV10Publicaciones.gxTpr_Publicacionesdocdescripcion = AV8SDTPublicaciones.gxTpr_Publicacionesdocdescripcion;
         AV10Publicaciones.gxTpr_Publicacionestipoempresa = AV8SDTPublicaciones.gxTpr_Publicacionestipoempresa;
         AV10Publicaciones.gxTpr_Publicacionescontratoid = AV8SDTPublicaciones.gxTpr_Publicacionescontratoid;
         AV10Publicaciones.gxTpr_Publicacionesterminoobra = AV8SDTPublicaciones.gxTpr_Publicacionesterminoobra;
         AV10Publicaciones.gxTpr_Publicacionesestado = AV8SDTPublicaciones.gxTpr_Publicacionesestado;
         AV10Publicaciones.Insert();
         if ( AV10Publicaciones.Success() )
         {
            AV14JsonMessages = context.GetMessage( "Ok", "");
            context.CommitDataStores("altapublicaciones",pr_default);
         }
         else
         {
            AV11messages = AV10Publicaciones.GetMessages();
            AV14JsonMessages = AV11messages.ToJSonString(false);
            AV15GXV1 = 1;
            while ( AV15GXV1 <= AV11messages.Count )
            {
               AV12message = ((GeneXus.Utils.SdtMessages_Message)AV11messages.Item(AV15GXV1));
               AV13Plog = new SdtPlog(context);
               AV13Plog.gxTpr_Plogmsg = AV12message.ToJSonString(false, true);
               AV13Plog.gxTpr_Plogpgm = AV9JsonPublicaciones;
               AV13Plog.Insert();
               context.CommitDataStores("altapublicaciones",pr_default);
               AV15GXV1 = (int)(AV15GXV1+1);
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
         AV14JsonMessages = "";
         AV8SDTPublicaciones = new SdtSDTPublicaciones(context);
         AV10Publicaciones = new SdtPublicaciones(context);
         AV11messages = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         AV12message = new GeneXus.Utils.SdtMessages_Message(context);
         AV13Plog = new SdtPlog(context);
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.altapublicaciones__datastore1(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.altapublicaciones__default(),
            new Object[][] {
            }
         );
         /* GeneXus formulas. */
      }

      private int AV15GXV1 ;
      private string AV9JsonPublicaciones ;
      private string AV14JsonMessages ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private SdtSDTPublicaciones AV8SDTPublicaciones ;
      private SdtPublicaciones AV10Publicaciones ;
      private IDataStoreProvider pr_default ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV11messages ;
      private GeneXus.Utils.SdtMessages_Message AV12message ;
      private SdtPlog AV13Plog ;
      private string aP1_JsonMessages ;
      private IDataStoreProvider pr_datastore1 ;
   }

   public class altapublicaciones__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class altapublicaciones__default : DataStoreHelperBase, IDataStoreHelper
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

}

}

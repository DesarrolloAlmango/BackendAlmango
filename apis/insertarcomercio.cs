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
   public class insertarcomercio : GXProcedure
   {
      public insertarcomercio( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public insertarcomercio( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_ComercioDatos ,
                           out string aP1_Mensaje )
      {
         this.AV8ComercioDatos = aP0_ComercioDatos;
         this.AV12Mensaje = "" ;
         initialize();
         ExecutePrivate();
         aP1_Mensaje=this.AV12Mensaje;
      }

      public string executeUdp( string aP0_ComercioDatos )
      {
         execute(aP0_ComercioDatos, out aP1_Mensaje);
         return AV12Mensaje ;
      }

      public void executeSubmit( string aP0_ComercioDatos ,
                                 out string aP1_Mensaje )
      {
         this.AV8ComercioDatos = aP0_ComercioDatos;
         this.AV12Mensaje = "" ;
         SubmitImpl();
         aP1_Mensaje=this.AV12Mensaje;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV13SDTComercioDatos.FromJSonString(AV8ComercioDatos, null);
         if ( StringUtil.StrCmp(AV13SDTComercioDatos.gxTpr_Proveedorpagodefault, context.GetMessage( "F", "")) == 0 )
         {
            AV14OrigenPago = "F";
         }
         if ( StringUtil.StrCmp(AV13SDTComercioDatos.gxTpr_Proveedorpagodefault, context.GetMessage( "T", "")) == 0 )
         {
            AV14OrigenPago = "T";
         }
         if ( StringUtil.StrCmp(AV13SDTComercioDatos.gxTpr_Proveedorpagodefault, context.GetMessage( "O", "")) == 0 )
         {
            AV14OrigenPago = "O";
         }
         AV14OrigenPago = "F";
         AV10Proveedor.FromJSonString(AV8ComercioDatos, null);
         AV10Proveedor.gxTpr_Proveedorestipoid = 1;
         AV10Proveedor.gxTpr_Proveedorestado = "HAB";
         AV10Proveedor.gxTpr_Proveedorpagodefault = AV14OrigenPago;
         AV10Proveedor.Insert();
         if ( AV10Proveedor.Success() )
         {
            AV12Mensaje = context.GetMessage( "Comercio creado.", "");
            context.CommitDataStores("apis.insertarcomercio",pr_default);
         }
         else
         {
            AV11Messages = AV10Proveedor.GetMessages();
            AV15GXV1 = 1;
            while ( AV15GXV1 <= AV11Messages.Count )
            {
               AV9Message = ((GeneXus.Utils.SdtMessages_Message)AV11Messages.Item(AV15GXV1));
               AV12Mensaje += AV9Message.gxTpr_Description;
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
         AV12Mensaje = "";
         AV13SDTComercioDatos = new GeneXus.Programs.apis.SdtSDTComercioDatos(context);
         AV14OrigenPago = "";
         AV10Proveedor = new SdtProveedor(context);
         AV11Messages = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         AV9Message = new GeneXus.Utils.SdtMessages_Message(context);
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.apis.insertarcomercio__datastore1(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.apis.insertarcomercio__default(),
            new Object[][] {
            }
         );
         /* GeneXus formulas. */
      }

      private int AV15GXV1 ;
      private string AV14OrigenPago ;
      private string AV8ComercioDatos ;
      private string AV12Mensaje ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.apis.SdtSDTComercioDatos AV13SDTComercioDatos ;
      private SdtProveedor AV10Proveedor ;
      private IDataStoreProvider pr_default ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV11Messages ;
      private GeneXus.Utils.SdtMessages_Message AV9Message ;
      private string aP1_Mensaje ;
      private IDataStoreProvider pr_datastore1 ;
   }

   public class insertarcomercio__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class insertarcomercio__default : DataStoreHelperBase, IDataStoreHelper
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

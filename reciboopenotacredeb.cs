using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using System.Web.Services.Protocols;
using System.Web.Services;
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
   public class reciboopenotacredeb : GXProcedure
   {
      public reciboopenotacredeb( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
      }

      public reciboopenotacredeb( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( long aP0_OperacionesId ,
                           long aP1_WalletId ,
                           string aP2_TipoOperacion ,
                           string aP3_NombreRef )
      {
         this.AV2OperacionesId = aP0_OperacionesId;
         this.AV3WalletId = aP1_WalletId;
         this.AV4TipoOperacion = aP2_TipoOperacion;
         this.AV5NombreRef = aP3_NombreRef;
         initialize();
         ExecutePrivate();
      }

      public void executeSubmit( long aP0_OperacionesId ,
                                 long aP1_WalletId ,
                                 string aP2_TipoOperacion ,
                                 string aP3_NombreRef )
      {
         this.AV2OperacionesId = aP0_OperacionesId;
         this.AV3WalletId = aP1_WalletId;
         this.AV4TipoOperacion = aP2_TipoOperacion;
         this.AV5NombreRef = aP3_NombreRef;
         SubmitImpl();
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         args = new Object[] {(long)AV2OperacionesId,(long)AV3WalletId,(string)AV4TipoOperacion,(string)AV5NombreRef} ;
         ClassLoader.Execute("areciboopenotacredeb","GeneXus.Programs","areciboopenotacredeb", new Object[] {context }, "execute", args);
         if ( ( args != null ) && ( args.Length == 4 ) )
         {
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
      }

      public override void initialize( )
      {
         /* GeneXus formulas. */
      }

      private long AV2OperacionesId ;
      private long AV3WalletId ;
      private string AV4TipoOperacion ;
      private string AV5NombreRef ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private Object[] args ;
   }

}

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
   public class remitomudanza2 : GXProcedure
   {
      public remitomudanza2( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
      }

      public remitomudanza2( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( ref long aP0_SolicitudesID )
      {
         this.AV2SolicitudesID = aP0_SolicitudesID;
         initialize();
         ExecutePrivate();
         aP0_SolicitudesID=this.AV2SolicitudesID;
      }

      public long executeUdp( )
      {
         execute(ref aP0_SolicitudesID);
         return AV2SolicitudesID ;
      }

      public void executeSubmit( ref long aP0_SolicitudesID )
      {
         this.AV2SolicitudesID = aP0_SolicitudesID;
         SubmitImpl();
         aP0_SolicitudesID=this.AV2SolicitudesID;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         args = new Object[] {(long)AV2SolicitudesID} ;
         ClassLoader.Execute("aremitomudanza2","GeneXus.Programs","aremitomudanza2", new Object[] {context }, "execute", args);
         if ( ( args != null ) && ( args.Length == 1 ) )
         {
            AV2SolicitudesID = (long)(args[0]) ;
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

      private long AV2SolicitudesID ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private long aP0_SolicitudesID ;
      private Object[] args ;
   }

}

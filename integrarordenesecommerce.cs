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
   public class integrarordenesecommerce : GXProcedure
   {
      public integrarordenesecommerce( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
      }

      public integrarordenesecommerce( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( out string aP0_DebugLog )
      {
         this.AV2DebugLog = "" ;
         initialize();
         ExecutePrivate();
         aP0_DebugLog=this.AV2DebugLog;
      }

      public string executeUdp( )
      {
         execute(out aP0_DebugLog);
         return AV2DebugLog ;
      }

      public void executeSubmit( out string aP0_DebugLog )
      {
         this.AV2DebugLog = "" ;
         SubmitImpl();
         aP0_DebugLog=this.AV2DebugLog;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         args = new Object[] {(string)AV2DebugLog} ;
         ClassLoader.Execute("aintegrarordenesecommerce","GeneXus.Programs","aintegrarordenesecommerce", new Object[] {context }, "execute", args);
         if ( ( args != null ) && ( args.Length == 1 ) )
         {
            AV2DebugLog = (string)(args[0]) ;
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
         AV2DebugLog = "";
         /* GeneXus formulas. */
      }

      private string AV2DebugLog ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private Object[] args ;
      private string aP0_DebugLog ;
   }

}

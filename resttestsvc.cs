using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
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
using System.ServiceModel.Web;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class resttestsvc : GXProcedure
   {
      public resttestsvc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public resttestsvc( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( out string aP0_response )
      {
         this.AV8response = "" ;
         initialize();
         ExecutePrivate();
         aP0_response=this.AV8response;
      }

      public string executeUdp( )
      {
         execute(out aP0_response);
         return AV8response ;
      }

      public void executeSubmit( out string aP0_response )
      {
         this.AV8response = "" ;
         SubmitImpl();
         aP0_response=this.AV8response;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV8response = context.GetMessage( "SUCCESS - URL Rewrite and REST services up and running ok!", "");
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
         AV8response = "";
         /* GeneXus formulas. */
      }

      private string AV8response ;
      private string aP0_response ;
   }

   [ServiceContract(Namespace = "GeneXus.Programs.resttestsvc_services")]
   [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple)]
   [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
   public class resttestsvc_services : GxRestService
   {
      [OperationContract(Name = "RESTTestSVC" )]
      [WebInvoke(Method =  "POST" ,
      	BodyStyle =  WebMessageBodyStyle.Wrapped  ,
      	ResponseFormat = WebMessageFormat.Json,
      	UriTemplate = "/")]
      public void execute( out string response )
      {
         response = "" ;
         try
         {
            if ( ! ProcessHeaders("resttestsvc") )
            {
               return  ;
            }
            resttestsvc worker = new resttestsvc(context);
            worker.IsMain = RunAsMain ;
            worker.execute(out response );
            worker.cleanup( );
         }
         catch ( Exception e )
         {
            WebException(e);
         }
         finally
         {
            Cleanup();
         }
      }

   }

}

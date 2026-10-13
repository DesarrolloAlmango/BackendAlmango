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
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class obtenerurlpagomudanza : GXProcedure
   {
      public obtenerurlpagomudanza( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public obtenerurlpagomudanza( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( long aP0_MudanzaId ,
                           out string aP1_url )
      {
         this.AV12MudanzaId = aP0_MudanzaId;
         this.AV8url = "" ;
         initialize();
         ExecutePrivate();
         aP1_url=this.AV8url;
      }

      public string executeUdp( long aP0_MudanzaId )
      {
         execute(aP0_MudanzaId, out aP1_url);
         return AV8url ;
      }

      public void executeSubmit( long aP0_MudanzaId ,
                                 out string aP1_url )
      {
         this.AV12MudanzaId = aP0_MudanzaId;
         this.AV8url = "" ;
         SubmitImpl();
         aP1_url=this.AV8url;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         new oparametros(context ).execute(  context.GetMessage( "URLPASPAG", ""), out  AV9URLPAGO, out  AV10ParametrosNumerico, out  AV11ParametrosEstado) ;
         AV8url = StringUtil.Trim( AV9URLPAGO) + context.GetMessage( "M", "") + StringUtil.Trim( StringUtil.Str( (decimal)(AV12MudanzaId), 18, 0));
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
         AV8url = "";
         AV9URLPAGO = "";
         AV11ParametrosEstado = "";
         /* GeneXus formulas. */
      }

      private int AV10ParametrosNumerico ;
      private long AV12MudanzaId ;
      private string AV11ParametrosEstado ;
      private string AV8url ;
      private string AV9URLPAGO ;
      private string aP1_url ;
   }

}

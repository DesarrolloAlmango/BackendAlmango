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
   public class pencripta : GXProcedure
   {
      public pencripta( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public pencripta( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( string aP0_SinEncriptar ,
                           out string aP1_Encriptada )
      {
         this.AV10SinEncriptar = aP0_SinEncriptar;
         this.AV9Encriptada = "" ;
         initialize();
         ExecutePrivate();
         aP1_Encriptada=this.AV9Encriptada;
      }

      public string executeUdp( string aP0_SinEncriptar )
      {
         execute(aP0_SinEncriptar, out aP1_Encriptada);
         return AV9Encriptada ;
      }

      public void executeSubmit( string aP0_SinEncriptar ,
                                 out string aP1_Encriptada )
      {
         this.AV10SinEncriptar = aP0_SinEncriptar;
         this.AV9Encriptada = "" ;
         SubmitImpl();
         aP1_Encriptada=this.AV9Encriptada;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV10SinEncriptar = StringUtil.Trim( AV10SinEncriptar);
         AV8EncKey = context.GetMessage( "30cb108475d62195594b22ff439b5523", "");
         AV9Encriptada = Encrypt64( AV10SinEncriptar, AV8EncKey);
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
         AV9Encriptada = "";
         AV8EncKey = "";
         /* GeneXus formulas. */
      }

      private string AV10SinEncriptar ;
      private string AV9Encriptada ;
      private string AV8EncKey ;
      private string aP1_Encriptada ;
   }

}

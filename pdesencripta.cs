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
   public class pdesencripta : GXProcedure
   {
      public pdesencripta( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public pdesencripta( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( ref string aP0_Encriptada ,
                           ref string aP1_Desencriptada )
      {
         this.AV10Encriptada = aP0_Encriptada;
         this.AV9Desencriptada = aP1_Desencriptada;
         initialize();
         ExecutePrivate();
         aP0_Encriptada=this.AV10Encriptada;
         aP1_Desencriptada=this.AV9Desencriptada;
      }

      public string executeUdp( ref string aP0_Encriptada )
      {
         execute(ref aP0_Encriptada, ref aP1_Desencriptada);
         return AV9Desencriptada ;
      }

      public void executeSubmit( ref string aP0_Encriptada ,
                                 ref string aP1_Desencriptada )
      {
         this.AV10Encriptada = aP0_Encriptada;
         this.AV9Desencriptada = aP1_Desencriptada;
         SubmitImpl();
         aP0_Encriptada=this.AV10Encriptada;
         aP1_Desencriptada=this.AV9Desencriptada;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV8EncKey = context.GetMessage( "30cb108475d62195594b22ff439b5523", "");
         AV9Desencriptada = Decrypt64( AV10Encriptada, AV8EncKey);
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
         AV8EncKey = "";
         /* GeneXus formulas. */
      }

      private string AV10Encriptada ;
      private string AV9Desencriptada ;
      private string AV8EncKey ;
      private string aP0_Encriptada ;
      private string aP1_Desencriptada ;
   }

}

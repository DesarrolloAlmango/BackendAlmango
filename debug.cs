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
   public class debug : GXProcedure
   {
      public debug( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public debug( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( string aP0_parametro )
      {
         this.AV8parametro = aP0_parametro;
         initialize();
         ExecutePrivate();
      }

      public void executeSubmit( string aP0_parametro )
      {
         this.AV8parametro = aP0_parametro;
         SubmitImpl();
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV9i = context.FileIOInstance.dfwopen( context.GetMessage( "../logFile.txt", ""), "", "", 1, "");
         AV9i = context.FileIOInstance.dfwptxt( AV8parametro, 0);
         AV9i = context.FileIOInstance.dfwnext( );
         AV9i = context.FileIOInstance.dfwclose( );
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
         /* GeneXus formulas. */
      }

      private int AV9i ;
      private string AV8parametro ;
   }

}

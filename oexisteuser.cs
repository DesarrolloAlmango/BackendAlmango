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
   public class oexisteuser : GXProcedure
   {
      public oexisteuser( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
      }

      public oexisteuser( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_usuarioId ,
                           string aP1_SecUserName ,
                           string aP2_TipoUS ,
                           out string aP3_ok )
      {
         this.AV2usuarioId = aP0_usuarioId;
         this.AV3SecUserName = aP1_SecUserName;
         this.AV4TipoUS = aP2_TipoUS;
         this.AV5ok = "" ;
         initialize();
         ExecutePrivate();
         aP3_ok=this.AV5ok;
      }

      public string executeUdp( string aP0_usuarioId ,
                                string aP1_SecUserName ,
                                string aP2_TipoUS )
      {
         execute(aP0_usuarioId, aP1_SecUserName, aP2_TipoUS, out aP3_ok);
         return AV5ok ;
      }

      public void executeSubmit( string aP0_usuarioId ,
                                 string aP1_SecUserName ,
                                 string aP2_TipoUS ,
                                 out string aP3_ok )
      {
         this.AV2usuarioId = aP0_usuarioId;
         this.AV3SecUserName = aP1_SecUserName;
         this.AV4TipoUS = aP2_TipoUS;
         this.AV5ok = "" ;
         SubmitImpl();
         aP3_ok=this.AV5ok;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         args = new Object[] {(string)AV2usuarioId,(string)AV3SecUserName,(string)AV4TipoUS,(string)AV5ok} ;
         ClassLoader.Execute("aoexisteuser","GeneXus.Programs","aoexisteuser", new Object[] {context }, "execute", args);
         if ( ( args != null ) && ( args.Length == 4 ) )
         {
            AV5ok = (string)(args[3]) ;
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
         AV5ok = "";
         /* GeneXus formulas. */
      }

      private string AV2usuarioId ;
      private string AV4TipoUS ;
      private string AV5ok ;
      private string AV3SecUserName ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private Object[] args ;
      private string aP3_ok ;
   }

}

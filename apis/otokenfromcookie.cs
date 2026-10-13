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
using GeneXus.Http.Server;
using System.Threading;
using System.Xml.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Runtime.Serialization;
namespace GeneXus.Programs.apis {
   public class otokenfromcookie : GXProcedure
   {
      public otokenfromcookie( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public otokenfromcookie( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( GxHttpRequest aP0_HttpRequest ,
                           out string aP1_TokenId )
      {
         this.AV9HttpRequest = aP0_HttpRequest;
         this.AV8TokenId = "" ;
         initialize();
         ExecutePrivate();
         aP1_TokenId=this.AV8TokenId;
      }

      public string executeUdp( GxHttpRequest aP0_HttpRequest )
      {
         execute(aP0_HttpRequest, out aP1_TokenId);
         return AV8TokenId ;
      }

      public void executeSubmit( GxHttpRequest aP0_HttpRequest ,
                                 out string aP1_TokenId )
      {
         this.AV9HttpRequest = aP0_HttpRequest;
         this.AV8TokenId = "" ;
         SubmitImpl();
         aP1_TokenId=this.AV8TokenId;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV10CookieHeader = AV9HttpRequest.GetHeader(context.GetMessage( "Cookie", ""));
         AV8TokenId = "";
         AV12Search = context.GetMessage( "TokenId=", "");
         AV11Pos = (short)(StringUtil.StringSearch( AV10CookieHeader, AV12Search, 1));
         if ( AV11Pos > 0 )
         {
            AV14Start = (short)(AV11Pos+StringUtil.Len( AV12Search));
            AV13End = (short)(StringUtil.StringSearch( StringUtil.Substring( AV10CookieHeader, AV14Start, StringUtil.Len( AV10CookieHeader)), ";", 1));
            if ( AV13End > 0 )
            {
               AV8TokenId = StringUtil.Substring( AV10CookieHeader, AV14Start, AV13End-1);
            }
            else
            {
               AV8TokenId = StringUtil.Substring( AV10CookieHeader, AV14Start, StringUtil.Len( AV10CookieHeader));
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
         AV8TokenId = "";
         AV10CookieHeader = "";
         AV12Search = "";
         /* GeneXus formulas. */
      }

      private short AV11Pos ;
      private short AV14Start ;
      private short AV13End ;
      private string AV8TokenId ;
      private string AV10CookieHeader ;
      private string AV12Search ;
      private GxHttpRequest AV9HttpRequest ;
      private string aP1_TokenId ;
   }

}

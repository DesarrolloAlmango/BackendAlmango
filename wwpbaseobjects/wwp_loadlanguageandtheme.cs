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
namespace GeneXus.Programs.wwpbaseobjects {
   public class wwp_loadlanguageandtheme : GXProcedure
   {
      public wwp_loadlanguageandtheme( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wwp_loadlanguageandtheme( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( out string aP0_Language ,
                           out bool aP1_RefreshNeeded )
      {
         this.AV11Language = "" ;
         this.AV8RefreshNeeded = false ;
         initialize();
         ExecutePrivate();
         aP0_Language=this.AV11Language;
         aP1_RefreshNeeded=this.AV8RefreshNeeded;
      }

      public bool executeUdp( out string aP0_Language )
      {
         execute(out aP0_Language, out aP1_RefreshNeeded);
         return AV8RefreshNeeded ;
      }

      public void executeSubmit( out string aP0_Language ,
                                 out bool aP1_RefreshNeeded )
      {
         this.AV11Language = "" ;
         this.AV8RefreshNeeded = false ;
         SubmitImpl();
         aP0_Language=this.AV11Language;
         aP1_RefreshNeeded=this.AV8RefreshNeeded;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV8RefreshNeeded = false;
         if ( StringUtil.StrCmp(AV12WebSession.Get("isLangLoaded"), "true") != 0 )
         {
            AV9BrowserLanguage = AV10Httprequest.GetHeader("Accept-Language");
            if ( StringUtil.Like( AV9BrowserLanguage , StringUtil.PadR( "EN" , 40 , "%"),  ' ' ) )
            {
               AV11Language = "English";
            }
            else if ( StringUtil.Like( AV9BrowserLanguage , StringUtil.PadR( "ES" , 40 , "%"),  ' ' ) )
            {
               AV11Language = "Spanish";
            }
            else if ( StringUtil.Like( AV9BrowserLanguage , StringUtil.PadR( "PT" , 40 , "%"),  ' ' ) )
            {
               AV11Language = "Portuguese";
            }
            else
            {
               AV11Language = "Spanish";
            }
            if ( context.SetLanguage( AV11Language) != 0 )
            {
               GX_msglist.addItem(context.GetMessage( "The language is not available", ""));
            }
            else
            {
               AV12WebSession.Set("isLangLoaded", "true");
            }
         }
         else
         {
            AV11Language = context.GetLanguage( );
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
         AV11Language = "";
         AV12WebSession = context.GetSession();
         AV9BrowserLanguage = "";
         AV10Httprequest = new GxHttpRequest( context);
         /* GeneXus formulas. */
      }

      private bool AV8RefreshNeeded ;
      private string AV11Language ;
      private string AV9BrowserLanguage ;
      private GxHttpRequest AV10Httprequest ;
      private IGxSession AV12WebSession ;
      private string aP0_Language ;
      private bool aP1_RefreshNeeded ;
   }

}

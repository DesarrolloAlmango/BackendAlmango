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
   public class organizarmail : GXProcedure
   {
      public organizarmail( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
      }

      public organizarmail( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( short aP0_MailDesignId ,
                           string aP1_MailDesignTipo ,
                           string aP2_Email ,
                           ref string aP3_Nombre ,
                           string aP4_UrlAdjunto ,
                           ref string aP5_HTMLText ,
                           out string aP6_Ok ,
                           out string aP7_ErrorDescription )
      {
         this.AV2MailDesignId = aP0_MailDesignId;
         this.AV3MailDesignTipo = aP1_MailDesignTipo;
         this.AV4Email = aP2_Email;
         this.AV5Nombre = aP3_Nombre;
         this.AV6UrlAdjunto = aP4_UrlAdjunto;
         this.AV7HTMLText = aP5_HTMLText;
         this.AV8Ok = "" ;
         this.AV9ErrorDescription = "" ;
         initialize();
         ExecutePrivate();
         aP3_Nombre=this.AV5Nombre;
         aP5_HTMLText=this.AV7HTMLText;
         aP6_Ok=this.AV8Ok;
         aP7_ErrorDescription=this.AV9ErrorDescription;
      }

      public string executeUdp( short aP0_MailDesignId ,
                                string aP1_MailDesignTipo ,
                                string aP2_Email ,
                                ref string aP3_Nombre ,
                                string aP4_UrlAdjunto ,
                                ref string aP5_HTMLText ,
                                out string aP6_Ok )
      {
         execute(aP0_MailDesignId, aP1_MailDesignTipo, aP2_Email, ref aP3_Nombre, aP4_UrlAdjunto, ref aP5_HTMLText, out aP6_Ok, out aP7_ErrorDescription);
         return AV9ErrorDescription ;
      }

      public void executeSubmit( short aP0_MailDesignId ,
                                 string aP1_MailDesignTipo ,
                                 string aP2_Email ,
                                 ref string aP3_Nombre ,
                                 string aP4_UrlAdjunto ,
                                 ref string aP5_HTMLText ,
                                 out string aP6_Ok ,
                                 out string aP7_ErrorDescription )
      {
         this.AV2MailDesignId = aP0_MailDesignId;
         this.AV3MailDesignTipo = aP1_MailDesignTipo;
         this.AV4Email = aP2_Email;
         this.AV5Nombre = aP3_Nombre;
         this.AV6UrlAdjunto = aP4_UrlAdjunto;
         this.AV7HTMLText = aP5_HTMLText;
         this.AV8Ok = "" ;
         this.AV9ErrorDescription = "" ;
         SubmitImpl();
         aP3_Nombre=this.AV5Nombre;
         aP5_HTMLText=this.AV7HTMLText;
         aP6_Ok=this.AV8Ok;
         aP7_ErrorDescription=this.AV9ErrorDescription;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         args = new Object[] {(short)AV2MailDesignId,(string)AV3MailDesignTipo,(string)AV4Email,(string)AV5Nombre,(string)AV6UrlAdjunto,(string)AV7HTMLText,(string)AV8Ok,(string)AV9ErrorDescription} ;
         ClassLoader.Execute("aorganizarmail","GeneXus.Programs","aorganizarmail", new Object[] {context }, "execute", args);
         if ( ( args != null ) && ( args.Length == 8 ) )
         {
            AV5Nombre = (string)(args[3]) ;
            AV7HTMLText = (string)(args[5]) ;
            AV8Ok = (string)(args[6]) ;
            AV9ErrorDescription = (string)(args[7]) ;
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
         AV8Ok = "";
         AV9ErrorDescription = "";
         /* GeneXus formulas. */
      }

      private short AV2MailDesignId ;
      private string AV3MailDesignTipo ;
      private string AV5Nombre ;
      private string AV6UrlAdjunto ;
      private string AV7HTMLText ;
      private string AV8Ok ;
      private string AV9ErrorDescription ;
      private string AV4Email ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private string aP3_Nombre ;
      private string aP5_HTMLText ;
      private Object[] args ;
      private string aP6_Ok ;
      private string aP7_ErrorDescription ;
   }

}

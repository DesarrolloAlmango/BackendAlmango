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
namespace GeneXus.Programs.wwpbaseobjects {
   public class loaduserkeyvalue : GXProcedure
   {
      public loaduserkeyvalue( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public loaduserkeyvalue( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( string aP0_UserCustomizationsKey ,
                           out string aP1_UserCustomizationsValue )
      {
         this.AV19UserCustomizationsKey = aP0_UserCustomizationsKey;
         this.AV20UserCustomizationsValue = "" ;
         initialize();
         ExecutePrivate();
         aP1_UserCustomizationsValue=this.AV20UserCustomizationsValue;
      }

      public string executeUdp( string aP0_UserCustomizationsKey )
      {
         execute(aP0_UserCustomizationsKey, out aP1_UserCustomizationsValue);
         return AV20UserCustomizationsValue ;
      }

      public void executeSubmit( string aP0_UserCustomizationsKey ,
                                 out string aP1_UserCustomizationsValue )
      {
         this.AV19UserCustomizationsKey = aP0_UserCustomizationsKey;
         this.AV20UserCustomizationsValue = "" ;
         SubmitImpl();
         aP1_UserCustomizationsValue=this.AV20UserCustomizationsValue;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV20UserCustomizationsValue = AV18Session.Get(AV19UserCustomizationsKey);
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV20UserCustomizationsValue)) )
         {
            new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV23WWPContext) ;
            AV22UserCustomizations.Load((int)(AV23WWPContext.gxTpr_Userid), AV19UserCustomizationsKey);
            if ( AV22UserCustomizations.Success() )
            {
               AV20UserCustomizationsValue = AV22UserCustomizations.gxTpr_Usercustomizationsvalue;
            }
            else
            {
               AV20UserCustomizationsValue = "";
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
         AV20UserCustomizationsValue = "";
         AV18Session = context.GetSession();
         AV23WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV22UserCustomizations = new GeneXus.Programs.wwpbaseobjects.SdtUserCustomizations(context);
         /* GeneXus formulas. */
      }

      private string AV20UserCustomizationsValue ;
      private string AV19UserCustomizationsKey ;
      private IGxSession AV18Session ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV23WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtUserCustomizations AV22UserCustomizations ;
      private string aP1_UserCustomizationsValue ;
   }

}

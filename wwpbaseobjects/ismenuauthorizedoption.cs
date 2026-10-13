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
   public class ismenuauthorizedoption : GXProcedure
   {
      public ismenuauthorizedoption( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public ismenuauthorizedoption( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( GeneXus.Programs.wwpbaseobjects.SdtDVelop_Menu_Item aP0_DVelop_Menu_Item ,
                           out bool aP1_IsAuthorized )
      {
         this.AV9DVelop_Menu_Item = aP0_DVelop_Menu_Item;
         this.AV11IsAuthorized = false ;
         initialize();
         ExecutePrivate();
         aP1_IsAuthorized=this.AV11IsAuthorized;
      }

      public bool executeUdp( GeneXus.Programs.wwpbaseobjects.SdtDVelop_Menu_Item aP0_DVelop_Menu_Item )
      {
         execute(aP0_DVelop_Menu_Item, out aP1_IsAuthorized);
         return AV11IsAuthorized ;
      }

      public void executeSubmit( GeneXus.Programs.wwpbaseobjects.SdtDVelop_Menu_Item aP0_DVelop_Menu_Item ,
                                 out bool aP1_IsAuthorized )
      {
         this.AV9DVelop_Menu_Item = aP0_DVelop_Menu_Item;
         this.AV11IsAuthorized = false ;
         SubmitImpl();
         aP1_IsAuthorized=this.AV11IsAuthorized;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         if ( StringUtil.StrCmp(StringUtil.Lower( AV9DVelop_Menu_Item.gxTpr_Authorizationkey), "public") == 0 )
         {
            AV11IsAuthorized = true;
         }
         else if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV9DVelop_Menu_Item.gxTpr_Authorizationkey)) )
         {
            GXt_boolean1 = AV11IsAuthorized;
            new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  AV9DVelop_Menu_Item.gxTpr_Authorizationkey, out  GXt_boolean1) ;
            AV11IsAuthorized = GXt_boolean1;
         }
         else
         {
            AV13Url = AV9DVelop_Menu_Item.gxTpr_Link;
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV13Url)) )
            {
               /* Execute user subroutine: 'GET AUTHORIZATION KEY FROM URL' */
               S111 ();
               if ( returnInSub )
               {
                  cleanup();
                  if (true) return;
               }
               GXt_boolean1 = AV11IsAuthorized;
               new GeneXus.Programs.wwpbaseobjects.secisauthbyobjectname(context ).execute(  AV8AuthorizationKey, out  GXt_boolean1) ;
               AV11IsAuthorized = GXt_boolean1;
            }
            else
            {
               AV11IsAuthorized = true;
            }
         }
         cleanup();
      }

      protected void S111( )
      {
         /* 'GET AUTHORIZATION KEY FROM URL' Routine */
         returnInSub = false;
         AV8AuthorizationKey = "";
         AV16UrlResourceNameWithExtension = "";
         AV15UrlResourceName = "";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV13Url)) )
         {
            AV10i = (short)(StringUtil.StringSearchRev( AV13Url, "/", -1));
            if ( AV10i > 0 )
            {
               AV13Url = StringUtil.Substring( AV13Url, AV10i+1, StringUtil.Len( StringUtil.Trim( AV13Url))-AV10i);
            }
            else
            {
               AV13Url = StringUtil.Trim( AV13Url);
            }
            if ( StringUtil.StringSearchRev( AV13Url, "?", -1) > 0 )
            {
               AV13Url = StringUtil.Substring( AV13Url, 1, StringUtil.StringSearchRev( AV13Url, "?", -1)-1);
            }
            if ( GxRegex.IsMatch(AV13Url,context.GetMessage( ".aspx", "")) )
            {
               AV15UrlResourceName = StringUtil.StringReplace( AV13Url, context.GetMessage( ".aspx", ""), "");
            }
            else
            {
               AV10i = (short)(StringUtil.StringSearch( AV16UrlResourceNameWithExtension, ".", 1));
               AV12j = (short)(StringUtil.StringSearchRev( AV16UrlResourceNameWithExtension, ".", -1));
               if ( ( AV10i == 0 ) && ( AV12j == 0 ) )
               {
                  AV15UrlResourceName = AV16UrlResourceNameWithExtension;
               }
               else
               {
                  if ( AV10i != AV12j )
                  {
                     AV14UrlObjectName = StringUtil.Substring( AV16UrlResourceNameWithExtension, AV12j+1, StringUtil.Len( AV16UrlResourceNameWithExtension)-AV12j);
                     AV15UrlResourceName = StringUtil.Substring( AV16UrlResourceNameWithExtension, AV10i+1, AV12j-AV10i-1);
                     AV10i = (short)(StringUtil.StringSearch( AV15UrlResourceName, ".", 1));
                     if ( AV10i > 0 )
                     {
                        AV15UrlResourceName = StringUtil.Substring( AV15UrlResourceName, AV10i+1, StringUtil.Len( AV15UrlResourceName)+AV10i) + ".";
                     }
                     AV15UrlResourceName += AV14UrlObjectName;
                  }
                  else
                  {
                     AV15UrlResourceName = StringUtil.Substring( AV16UrlResourceNameWithExtension, AV10i+1, StringUtil.Len( StringUtil.Trim( AV16UrlResourceNameWithExtension))-AV10i);
                  }
               }
            }
            AV8AuthorizationKey = StringUtil.Lower( StringUtil.Trim( AV15UrlResourceName));
         }
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
         AV13Url = "";
         AV8AuthorizationKey = "";
         AV16UrlResourceNameWithExtension = "";
         AV15UrlResourceName = "";
         AV14UrlObjectName = "";
         /* GeneXus formulas. */
      }

      private short AV10i ;
      private short AV12j ;
      private string AV16UrlResourceNameWithExtension ;
      private string AV15UrlResourceName ;
      private bool AV11IsAuthorized ;
      private bool returnInSub ;
      private bool GXt_boolean1 ;
      private string AV13Url ;
      private string AV8AuthorizationKey ;
      private string AV14UrlObjectName ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVelop_Menu_Item AV9DVelop_Menu_Item ;
      private bool aP1_IsAuthorized ;
   }

}

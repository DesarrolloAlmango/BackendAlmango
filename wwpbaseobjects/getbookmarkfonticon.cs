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
   public class getbookmarkfonticon : GXProcedure
   {
      public getbookmarkfonticon( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public getbookmarkfonticon( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( string aP0_LinkToFind ,
                           GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVelop_Menu_Item> aP1_DVelop_Menu ,
                           out string aP2_FontIcon )
      {
         this.AV11LinkToFind = aP0_LinkToFind;
         this.AV9DVelop_Menu = aP1_DVelop_Menu;
         this.AV10FontIcon = "" ;
         initialize();
         ExecutePrivate();
         aP2_FontIcon=this.AV10FontIcon;
      }

      public string executeUdp( string aP0_LinkToFind ,
                                GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVelop_Menu_Item> aP1_DVelop_Menu )
      {
         execute(aP0_LinkToFind, aP1_DVelop_Menu, out aP2_FontIcon);
         return AV10FontIcon ;
      }

      public void executeSubmit( string aP0_LinkToFind ,
                                 GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVelop_Menu_Item> aP1_DVelop_Menu ,
                                 out string aP2_FontIcon )
      {
         this.AV11LinkToFind = aP0_LinkToFind;
         this.AV9DVelop_Menu = aP1_DVelop_Menu;
         this.AV10FontIcon = "" ;
         SubmitImpl();
         aP2_FontIcon=this.AV10FontIcon;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV14GXV1 = 1;
         while ( AV14GXV1 <= AV9DVelop_Menu.Count )
         {
            AV8DVelop_MenuItem = ((GeneXus.Programs.wwpbaseobjects.SdtDVelop_Menu_Item)AV9DVelop_Menu.Item(AV14GXV1));
            if ( StringUtil.StrCmp(AV8DVelop_MenuItem.gxTpr_Link, AV11LinkToFind) == 0 )
            {
               AV10FontIcon = AV8DVelop_MenuItem.gxTpr_Iconclass;
               if (true) break;
            }
            else
            {
               GXt_char1 = AV10FontIcon;
               new GeneXus.Programs.wwpbaseobjects.getbookmarkfonticon(context ).execute(  AV11LinkToFind,  AV8DVelop_MenuItem.gxTpr_Subitems, out  GXt_char1) ;
               AV10FontIcon = GXt_char1;
               if ( StringUtil.StrCmp(AV10FontIcon, "") != 0 )
               {
                  if (true) break;
               }
            }
            AV14GXV1 = (int)(AV14GXV1+1);
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
         AV10FontIcon = "";
         AV8DVelop_MenuItem = new GeneXus.Programs.wwpbaseobjects.SdtDVelop_Menu_Item(context);
         GXt_char1 = "";
         /* GeneXus formulas. */
      }

      private int AV14GXV1 ;
      private string GXt_char1 ;
      private string AV11LinkToFind ;
      private string AV10FontIcon ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVelop_Menu_Item> AV9DVelop_Menu ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVelop_Menu_Item AV8DVelop_MenuItem ;
      private string aP2_FontIcon ;
   }

}

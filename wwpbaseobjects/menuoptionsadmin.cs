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
   public class menuoptionsadmin : GXProcedure
   {
      public menuoptionsadmin( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public menuoptionsadmin( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( out GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVelop_Menu_Item> aP0_Gxm2rootcol )
      {
         this.Gxm2rootcol = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVelop_Menu_Item>( context, "Item", "AlmangoX") ;
         initialize();
         ExecutePrivate();
         aP0_Gxm2rootcol=this.Gxm2rootcol;
      }

      public GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVelop_Menu_Item> executeUdp( )
      {
         execute(out aP0_Gxm2rootcol);
         return Gxm2rootcol ;
      }

      public void executeSubmit( out GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVelop_Menu_Item> aP0_Gxm2rootcol )
      {
         this.Gxm2rootcol = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVelop_Menu_Item>( context, "Item", "AlmangoX") ;
         SubmitImpl();
         aP0_Gxm2rootcol=this.Gxm2rootcol;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV5id = 0;
         Gxm1dvelop_menu = new GeneXus.Programs.wwpbaseobjects.SdtDVelop_Menu_Item(context);
         Gxm2rootcol.Add(Gxm1dvelop_menu, 0);
         AV5id = (short)(AV5id+1);
         Gxm1dvelop_menu.gxTpr_Id = StringUtil.Str( (decimal)(AV5id), 4, 0);
         Gxm1dvelop_menu.gxTpr_Tooltip = "";
         Gxm1dvelop_menu.gxTpr_Link = formatLink("home.aspx") ;
         Gxm1dvelop_menu.gxTpr_Linktarget = "";
         Gxm1dvelop_menu.gxTpr_Iconclass = "menu-icon fa fa-home";
         Gxm1dvelop_menu.gxTpr_Caption = context.GetMessage( "WWP_HomeTitle", "");
         Gxm1dvelop_menu = new GeneXus.Programs.wwpbaseobjects.SdtDVelop_Menu_Item(context);
         Gxm2rootcol.Add(Gxm1dvelop_menu, 0);
         AV5id = (short)(AV5id+1);
         Gxm1dvelop_menu.gxTpr_Id = StringUtil.Str( (decimal)(AV5id), 4, 0);
         Gxm1dvelop_menu.gxTpr_Tooltip = "";
         Gxm1dvelop_menu.gxTpr_Link = "";
         Gxm1dvelop_menu.gxTpr_Linktarget = "";
         Gxm1dvelop_menu.gxTpr_Iconclass = "menu-icon fa fa-tasks";
         Gxm1dvelop_menu.gxTpr_Caption = "Menú General";
         Gxv3skipcount = 0;
         AV12GXV2 = 1;
         GXt_objcol_SdtProgramNames_ProgramName1 = AV11GXV1;
         new GeneXus.Programs.wwpbaseobjects.listwwpprograms(context ).execute( out  GXt_objcol_SdtProgramNames_ProgramName1) ;
         AV11GXV1 = GXt_objcol_SdtProgramNames_ProgramName1;
         while ( AV12GXV2 <= AV11GXV1.Count )
         {
            AV6ProgramName = ((GeneXus.Programs.wwpbaseobjects.SdtProgramNames_ProgramName)AV11GXV1.Item(AV12GXV2));
            Gxv3skipcount = (int)(Gxv3skipcount+1);
            Gxm4dvelop_menu_subitems = new GeneXus.Programs.wwpbaseobjects.SdtDVelop_Menu_Item(context);
            Gxm1dvelop_menu.gxTpr_Subitems.Add(Gxm4dvelop_menu_subitems, 0);
            AV5id = (short)(AV5id+1);
            Gxm4dvelop_menu_subitems.gxTpr_Id = StringUtil.Str( (decimal)(AV5id), 4, 0);
            Gxm4dvelop_menu_subitems.gxTpr_Tooltip = "";
            Gxm4dvelop_menu_subitems.gxTpr_Link = AV6ProgramName.gxTpr_Link;
            Gxm4dvelop_menu_subitems.gxTpr_Linktarget = "";
            Gxm4dvelop_menu_subitems.gxTpr_Iconclass = "";
            Gxm4dvelop_menu_subitems.gxTpr_Caption = AV6ProgramName.gxTpr_Description;
            if ( ( 10000 != 0 ) && ( Gxv3skipcount >= 10000 ) )
            {
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               if (true) break;
            }
            AV12GXV2 = (int)(AV12GXV2+1);
         }
         Gxm1dvelop_menu = new GeneXus.Programs.wwpbaseobjects.SdtDVelop_Menu_Item(context);
         Gxm2rootcol.Add(Gxm1dvelop_menu, 0);
         AV5id = (short)(AV5id+1);
         Gxm1dvelop_menu.gxTpr_Id = StringUtil.Str( (decimal)(AV5id), 4, 0);
         Gxm1dvelop_menu.gxTpr_Tooltip = "";
         Gxm1dvelop_menu.gxTpr_Link = "";
         Gxm1dvelop_menu.gxTpr_Linktarget = "";
         Gxm1dvelop_menu.gxTpr_Iconclass = "menu-icon fa fa-folder";
         Gxm1dvelop_menu.gxTpr_Caption = "Más Opciones";
         Gxm4dvelop_menu_subitems = new GeneXus.Programs.wwpbaseobjects.SdtDVelop_Menu_Item(context);
         Gxm1dvelop_menu.gxTpr_Subitems.Add(Gxm4dvelop_menu_subitems, 0);
         AV5id = (short)(AV5id+1);
         Gxm4dvelop_menu_subitems.gxTpr_Id = StringUtil.Str( (decimal)(AV5id), 4, 0);
         Gxm4dvelop_menu_subitems.gxTpr_Tooltip = context.GetMessage( "Reportes", "");
         Gxm4dvelop_menu_subitems.gxTpr_Link = formatLink("wwpbaseobjects.reportes.aspx") ;
         Gxm4dvelop_menu_subitems.gxTpr_Linktarget = "";
         Gxm4dvelop_menu_subitems.gxTpr_Iconclass = "";
         Gxm4dvelop_menu_subitems.gxTpr_Caption = "Lista de Reportes";
         Gxm4dvelop_menu_subitems.gxTpr_Authorizationkey = "";
         Gxm1dvelop_menu = new GeneXus.Programs.wwpbaseobjects.SdtDVelop_Menu_Item(context);
         Gxm2rootcol.Add(Gxm1dvelop_menu, 0);
         AV5id = (short)(AV5id+1);
         Gxm1dvelop_menu.gxTpr_Id = StringUtil.Str( (decimal)(AV5id), 4, 0);
         Gxm1dvelop_menu.gxTpr_Tooltip = context.GetMessage( "Security of the application", "");
         Gxm1dvelop_menu.gxTpr_Link = "";
         Gxm1dvelop_menu.gxTpr_Linktarget = "";
         Gxm1dvelop_menu.gxTpr_Iconclass = "menu-icon fa fa-key";
         Gxm1dvelop_menu.gxTpr_Caption = "Security";
         Gxm4dvelop_menu_subitems = new GeneXus.Programs.wwpbaseobjects.SdtDVelop_Menu_Item(context);
         Gxm1dvelop_menu.gxTpr_Subitems.Add(Gxm4dvelop_menu_subitems, 0);
         AV5id = (short)(AV5id+1);
         Gxm4dvelop_menu_subitems.gxTpr_Id = StringUtil.Str( (decimal)(AV5id), 4, 0);
         Gxm4dvelop_menu_subitems.gxTpr_Tooltip = context.GetMessage( "Users", "");
         Gxm4dvelop_menu_subitems.gxTpr_Link = formatLink("wwpbaseobjects.secuserww.aspx") ;
         Gxm4dvelop_menu_subitems.gxTpr_Linktarget = "";
         Gxm4dvelop_menu_subitems.gxTpr_Iconclass = "";
         Gxm4dvelop_menu_subitems.gxTpr_Caption = "Users";
         Gxm4dvelop_menu_subitems.gxTpr_Authorizationkey = "";
         Gxm4dvelop_menu_subitems = new GeneXus.Programs.wwpbaseobjects.SdtDVelop_Menu_Item(context);
         Gxm1dvelop_menu.gxTpr_Subitems.Add(Gxm4dvelop_menu_subitems, 0);
         AV5id = (short)(AV5id+1);
         Gxm4dvelop_menu_subitems.gxTpr_Id = StringUtil.Str( (decimal)(AV5id), 4, 0);
         Gxm4dvelop_menu_subitems.gxTpr_Tooltip = context.GetMessage( "Roles", "");
         Gxm4dvelop_menu_subitems.gxTpr_Link = formatLink("wwpbaseobjects.secroleww.aspx") ;
         Gxm4dvelop_menu_subitems.gxTpr_Linktarget = "";
         Gxm4dvelop_menu_subitems.gxTpr_Iconclass = "";
         Gxm4dvelop_menu_subitems.gxTpr_Caption = "Roles";
         Gxm4dvelop_menu_subitems.gxTpr_Authorizationkey = "";
         Gxm4dvelop_menu_subitems = new GeneXus.Programs.wwpbaseobjects.SdtDVelop_Menu_Item(context);
         Gxm1dvelop_menu.gxTpr_Subitems.Add(Gxm4dvelop_menu_subitems, 0);
         AV5id = (short)(AV5id+1);
         Gxm4dvelop_menu_subitems.gxTpr_Id = StringUtil.Str( (decimal)(AV5id), 4, 0);
         Gxm4dvelop_menu_subitems.gxTpr_Tooltip = "";
         Gxm4dvelop_menu_subitems.gxTpr_Link = formatLink("wwpbaseobjects.secfunctionalityww.aspx") ;
         Gxm4dvelop_menu_subitems.gxTpr_Linktarget = "";
         Gxm4dvelop_menu_subitems.gxTpr_Iconclass = "";
         Gxm4dvelop_menu_subitems.gxTpr_Caption = "Functionalities";
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
         Gxm1dvelop_menu = new GeneXus.Programs.wwpbaseobjects.SdtDVelop_Menu_Item(context);
         AV11GXV1 = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtProgramNames_ProgramName>( context, "ProgramName", "AlmangoX");
         GXt_objcol_SdtProgramNames_ProgramName1 = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtProgramNames_ProgramName>( context, "ProgramName", "AlmangoX");
         AV6ProgramName = new GeneXus.Programs.wwpbaseobjects.SdtProgramNames_ProgramName(context);
         Gxm4dvelop_menu_subitems = new GeneXus.Programs.wwpbaseobjects.SdtDVelop_Menu_Item(context);
         /* GeneXus formulas. */
      }

      private short AV5id ;
      private int Gxv3skipcount ;
      private int AV12GXV2 ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVelop_Menu_Item> Gxm2rootcol ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVelop_Menu_Item Gxm1dvelop_menu ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtProgramNames_ProgramName> AV11GXV1 ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtProgramNames_ProgramName> GXt_objcol_SdtProgramNames_ProgramName1 ;
      private GeneXus.Programs.wwpbaseobjects.SdtProgramNames_ProgramName AV6ProgramName ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVelop_Menu_Item Gxm4dvelop_menu_subitems ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVelop_Menu_Item> aP0_Gxm2rootcol ;
   }

}

using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using System.Data;
using GeneXus.Data;
using com.genexus;
using GeneXus.Data.ADO;
using GeneXus.Data.NTier;
using GeneXus.Data.NTier.ADO;
using GeneXus.WebControls;
using GeneXus.Http;
using GeneXus.XML;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Xml.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Runtime.Serialization;
namespace GeneXus.Programs.wwpbaseobjects.notifications.web {
   public class wwp_webclient_bc : GXHttpHandler, IGxSilentTrn
   {
      public wwp_webclient_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wwp_webclient_bc( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      protected void INITTRN( )
      {
      }

      public void GetInsDefault( )
      {
         ReadRow0C13( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey0C13( ) ;
         standaloneModal( ) ;
         AddRow0C13( ) ;
         Gx_mode = "INS";
         return  ;
      }

      protected void AfterTrn( )
      {
         if ( trnEnded == 1 )
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( endTrnMsgTxt)) )
            {
               GX_msglist.addItem(endTrnMsgTxt, endTrnMsgCod, 0, "", true);
            }
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               Z57WWPWebClientId = A57WWPWebClientId;
               SetMode( "UPD") ;
            }
         }
         endTrnMsgTxt = "";
      }

      public override string ToString( )
      {
         return "" ;
      }

      public GxContentInfo GetContentInfo( )
      {
         return (GxContentInfo)(null) ;
      }

      public bool Reindex( )
      {
         return true ;
      }

      protected void CONFIRM_0C0( )
      {
         BeforeValidate0C13( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls0C13( ) ;
            }
            else
            {
               CheckExtendedTable0C13( ) ;
               if ( AnyError == 0 )
               {
                  ZM0C13( 6) ;
               }
               CloseExtendedTableCursors0C13( ) ;
            }
         }
         if ( AnyError == 0 )
         {
         }
      }

      protected void ZM0C13( short GX_JID )
      {
         if ( ( GX_JID == 5 ) || ( GX_JID == 0 ) )
         {
            Z58WWPWebClientBrowserId = A58WWPWebClientBrowserId;
            Z60WWPWebClientFirstRegistered = A60WWPWebClientFirstRegistered;
            Z61WWPWebClientLastRegistered = A61WWPWebClientLastRegistered;
            Z1WWPUserExtendedId = A1WWPUserExtendedId;
         }
         if ( ( GX_JID == 6 ) || ( GX_JID == 0 ) )
         {
         }
         if ( GX_JID == -5 )
         {
            Z57WWPWebClientId = A57WWPWebClientId;
            Z58WWPWebClientBrowserId = A58WWPWebClientBrowserId;
            Z59WWPWebClientBrowserVersion = A59WWPWebClientBrowserVersion;
            Z60WWPWebClientFirstRegistered = A60WWPWebClientFirstRegistered;
            Z61WWPWebClientLastRegistered = A61WWPWebClientLastRegistered;
            Z1WWPUserExtendedId = A1WWPUserExtendedId;
         }
      }

      protected void standaloneNotModal( )
      {
         Gx_BScreen = 0;
      }

      protected void standaloneModal( )
      {
         if ( IsIns( )  && (DateTime.MinValue==A60WWPWebClientFirstRegistered) && ( Gx_BScreen == 0 ) )
         {
            A60WWPWebClientFirstRegistered = DateTimeUtil.ServerNowMs( context, pr_default);
         }
         if ( IsIns( )  && (DateTime.MinValue==A61WWPWebClientLastRegistered) && ( Gx_BScreen == 0 ) )
         {
            A61WWPWebClientLastRegistered = DateTimeUtil.ServerNowMs( context, pr_default);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
         }
      }

      protected void Load0C13( )
      {
         /* Using cursor BC000C5 */
         pr_default.execute(3, new Object[] {A57WWPWebClientId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound13 = 1;
            A58WWPWebClientBrowserId = BC000C5_A58WWPWebClientBrowserId[0];
            A59WWPWebClientBrowserVersion = BC000C5_A59WWPWebClientBrowserVersion[0];
            A60WWPWebClientFirstRegistered = BC000C5_A60WWPWebClientFirstRegistered[0];
            A61WWPWebClientLastRegistered = BC000C5_A61WWPWebClientLastRegistered[0];
            A1WWPUserExtendedId = BC000C5_A1WWPUserExtendedId[0];
            n1WWPUserExtendedId = BC000C5_n1WWPUserExtendedId[0];
            ZM0C13( -5) ;
         }
         pr_default.close(3);
         OnLoadActions0C13( ) ;
      }

      protected void OnLoadActions0C13( )
      {
      }

      protected void CheckExtendedTable0C13( )
      {
         standaloneModal( ) ;
         if ( ! ( (DateTime.MinValue==A60WWPWebClientFirstRegistered) || ( A60WWPWebClientFirstRegistered >= context.localUtil.YMDHMSToT( 1753, 1, 1, 0, 0, 0) ) ) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_OutOfRange", ""), context.GetMessage( "Web Client First Registered", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, "");
            AnyError = 1;
         }
         if ( ! ( (DateTime.MinValue==A61WWPWebClientLastRegistered) || ( A61WWPWebClientLastRegistered >= context.localUtil.YMDHMSToT( 1753, 1, 1, 0, 0, 0) ) ) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_OutOfRange", ""), context.GetMessage( "Web Client Last Registered", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, "");
            AnyError = 1;
         }
         /* Using cursor BC000C4 */
         pr_default.execute(2, new Object[] {n1WWPUserExtendedId, A1WWPUserExtendedId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( A1WWPUserExtendedId)) ) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "WWP_UserExtended", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "WWPUSEREXTENDEDID");
               AnyError = 1;
            }
         }
         pr_default.close(2);
      }

      protected void CloseExtendedTableCursors0C13( )
      {
         pr_default.close(2);
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey0C13( )
      {
         /* Using cursor BC000C6 */
         pr_default.execute(4, new Object[] {A57WWPWebClientId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            RcdFound13 = 1;
         }
         else
         {
            RcdFound13 = 0;
         }
         pr_default.close(4);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC000C3 */
         pr_default.execute(1, new Object[] {A57WWPWebClientId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0C13( 5) ;
            RcdFound13 = 1;
            A57WWPWebClientId = BC000C3_A57WWPWebClientId[0];
            A58WWPWebClientBrowserId = BC000C3_A58WWPWebClientBrowserId[0];
            A59WWPWebClientBrowserVersion = BC000C3_A59WWPWebClientBrowserVersion[0];
            A60WWPWebClientFirstRegistered = BC000C3_A60WWPWebClientFirstRegistered[0];
            A61WWPWebClientLastRegistered = BC000C3_A61WWPWebClientLastRegistered[0];
            A1WWPUserExtendedId = BC000C3_A1WWPUserExtendedId[0];
            n1WWPUserExtendedId = BC000C3_n1WWPUserExtendedId[0];
            Z57WWPWebClientId = A57WWPWebClientId;
            sMode13 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load0C13( ) ;
            if ( AnyError == 1 )
            {
               RcdFound13 = 0;
               InitializeNonKey0C13( ) ;
            }
            Gx_mode = sMode13;
         }
         else
         {
            RcdFound13 = 0;
            InitializeNonKey0C13( ) ;
            sMode13 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode13;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey0C13( ) ;
         if ( RcdFound13 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
         }
         getByPrimaryKey( ) ;
      }

      protected void insert_Check( )
      {
         CONFIRM_0C0( ) ;
      }

      protected void update_Check( )
      {
         insert_Check( ) ;
      }

      protected void delete_Check( )
      {
         insert_Check( ) ;
      }

      protected void CheckOptimisticConcurrency0C13( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC000C2 */
            pr_default.execute(0, new Object[] {A57WWPWebClientId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"WWP_WebClient"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( Z58WWPWebClientBrowserId != BC000C2_A58WWPWebClientBrowserId[0] ) || ( Z60WWPWebClientFirstRegistered != BC000C2_A60WWPWebClientFirstRegistered[0] ) || ( Z61WWPWebClientLastRegistered != BC000C2_A61WWPWebClientLastRegistered[0] ) || ( StringUtil.StrCmp(Z1WWPUserExtendedId, BC000C2_A1WWPUserExtendedId[0]) != 0 ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"WWP_WebClient"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0C13( )
      {
         BeforeValidate0C13( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0C13( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0C13( 0) ;
            CheckOptimisticConcurrency0C13( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0C13( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0C13( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000C7 */
                     pr_default.execute(5, new Object[] {A57WWPWebClientId, A58WWPWebClientBrowserId, A59WWPWebClientBrowserVersion, A60WWPWebClientFirstRegistered, A61WWPWebClientLastRegistered, n1WWPUserExtendedId, A1WWPUserExtendedId});
                     pr_default.close(5);
                     pr_default.SmartCacheProvider.SetUpdated("WWP_WebClient");
                     if ( (pr_default.getStatus(5) == 1) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
                        AnyError = 1;
                     }
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
                           endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                           endTrnMsgCod = "SuccessfullyAdded";
                        }
                     }
                  }
                  else
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                     AnyError = 1;
                  }
               }
            }
            else
            {
               Load0C13( ) ;
            }
            EndLevel0C13( ) ;
         }
         CloseExtendedTableCursors0C13( ) ;
      }

      protected void Update0C13( )
      {
         BeforeValidate0C13( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0C13( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0C13( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0C13( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0C13( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000C8 */
                     pr_default.execute(6, new Object[] {A58WWPWebClientBrowserId, A59WWPWebClientBrowserVersion, A60WWPWebClientFirstRegistered, A61WWPWebClientLastRegistered, n1WWPUserExtendedId, A1WWPUserExtendedId, A57WWPWebClientId});
                     pr_default.close(6);
                     pr_default.SmartCacheProvider.SetUpdated("WWP_WebClient");
                     if ( (pr_default.getStatus(6) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"WWP_WebClient"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0C13( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                        AnyError = 1;
                     }
                  }
               }
            }
            EndLevel0C13( ) ;
         }
         CloseExtendedTableCursors0C13( ) ;
      }

      protected void DeferredUpdate0C13( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate0C13( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0C13( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0C13( ) ;
            AfterConfirm0C13( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0C13( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC000C9 */
                  pr_default.execute(7, new Object[] {A57WWPWebClientId});
                  pr_default.close(7);
                  pr_default.SmartCacheProvider.SetUpdated("WWP_WebClient");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        endTrnMsgTxt = context.GetMessage( "GXM_sucdeleted", "");
                        endTrnMsgCod = "SuccessfullyDeleted";
                     }
                  }
                  else
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                     AnyError = 1;
                  }
               }
            }
         }
         sMode13 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel0C13( ) ;
         Gx_mode = sMode13;
      }

      protected void OnDeleteControls0C13( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel0C13( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0C13( ) ;
         }
         if ( AnyError == 0 )
         {
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
         }
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanKeyStart0C13( )
      {
         /* Using cursor BC000C10 */
         pr_default.execute(8, new Object[] {A57WWPWebClientId});
         RcdFound13 = 0;
         if ( (pr_default.getStatus(8) != 101) )
         {
            RcdFound13 = 1;
            A57WWPWebClientId = BC000C10_A57WWPWebClientId[0];
            A58WWPWebClientBrowserId = BC000C10_A58WWPWebClientBrowserId[0];
            A59WWPWebClientBrowserVersion = BC000C10_A59WWPWebClientBrowserVersion[0];
            A60WWPWebClientFirstRegistered = BC000C10_A60WWPWebClientFirstRegistered[0];
            A61WWPWebClientLastRegistered = BC000C10_A61WWPWebClientLastRegistered[0];
            A1WWPUserExtendedId = BC000C10_A1WWPUserExtendedId[0];
            n1WWPUserExtendedId = BC000C10_n1WWPUserExtendedId[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext0C13( )
      {
         /* Scan next routine */
         pr_default.readNext(8);
         RcdFound13 = 0;
         ScanKeyLoad0C13( ) ;
      }

      protected void ScanKeyLoad0C13( )
      {
         sMode13 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(8) != 101) )
         {
            RcdFound13 = 1;
            A57WWPWebClientId = BC000C10_A57WWPWebClientId[0];
            A58WWPWebClientBrowserId = BC000C10_A58WWPWebClientBrowserId[0];
            A59WWPWebClientBrowserVersion = BC000C10_A59WWPWebClientBrowserVersion[0];
            A60WWPWebClientFirstRegistered = BC000C10_A60WWPWebClientFirstRegistered[0];
            A61WWPWebClientLastRegistered = BC000C10_A61WWPWebClientLastRegistered[0];
            A1WWPUserExtendedId = BC000C10_A1WWPUserExtendedId[0];
            n1WWPUserExtendedId = BC000C10_n1WWPUserExtendedId[0];
         }
         Gx_mode = sMode13;
      }

      protected void ScanKeyEnd0C13( )
      {
         pr_default.close(8);
      }

      protected void AfterConfirm0C13( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0C13( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0C13( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0C13( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0C13( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0C13( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0C13( )
      {
      }

      protected void send_integrity_lvl_hashes0C13( )
      {
      }

      protected void AddRow0C13( )
      {
         VarsToRow13( bcwwpbaseobjects_notifications_web_WWP_WebClient) ;
      }

      protected void ReadRow0C13( )
      {
         RowToVars13( bcwwpbaseobjects_notifications_web_WWP_WebClient, 1) ;
      }

      protected void InitializeNonKey0C13( )
      {
         A58WWPWebClientBrowserId = 0;
         A59WWPWebClientBrowserVersion = "";
         A1WWPUserExtendedId = "";
         n1WWPUserExtendedId = false;
         A60WWPWebClientFirstRegistered = DateTimeUtil.ServerNowMs( context, pr_default);
         A61WWPWebClientLastRegistered = DateTimeUtil.ServerNowMs( context, pr_default);
         Z58WWPWebClientBrowserId = 0;
         Z60WWPWebClientFirstRegistered = (DateTime)(DateTime.MinValue);
         Z61WWPWebClientLastRegistered = (DateTime)(DateTime.MinValue);
         Z1WWPUserExtendedId = "";
      }

      protected void InitAll0C13( )
      {
         A57WWPWebClientId = "";
         InitializeNonKey0C13( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A60WWPWebClientFirstRegistered = i60WWPWebClientFirstRegistered;
         A61WWPWebClientLastRegistered = i61WWPWebClientLastRegistered;
      }

      protected bool IsIns( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "INS")==0) ? true : false) ;
      }

      protected bool IsDlt( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "DLT")==0) ? true : false) ;
      }

      protected bool IsUpd( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "UPD")==0) ? true : false) ;
      }

      protected bool IsDsp( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? true : false) ;
      }

      public void VarsToRow13( GeneXus.Programs.wwpbaseobjects.notifications.web.SdtWWP_WebClient obj13 )
      {
         obj13.gxTpr_Mode = Gx_mode;
         obj13.gxTpr_Wwpwebclientbrowserid = A58WWPWebClientBrowserId;
         obj13.gxTpr_Wwpwebclientbrowserversion = A59WWPWebClientBrowserVersion;
         obj13.gxTpr_Wwpuserextendedid = A1WWPUserExtendedId;
         obj13.gxTpr_Wwpwebclientfirstregistered = A60WWPWebClientFirstRegistered;
         obj13.gxTpr_Wwpwebclientlastregistered = A61WWPWebClientLastRegistered;
         obj13.gxTpr_Wwpwebclientid = A57WWPWebClientId;
         obj13.gxTpr_Wwpwebclientid_Z = Z57WWPWebClientId;
         obj13.gxTpr_Wwpwebclientbrowserid_Z = Z58WWPWebClientBrowserId;
         obj13.gxTpr_Wwpwebclientfirstregistered_Z = Z60WWPWebClientFirstRegistered;
         obj13.gxTpr_Wwpwebclientlastregistered_Z = Z61WWPWebClientLastRegistered;
         obj13.gxTpr_Wwpuserextendedid_Z = Z1WWPUserExtendedId;
         obj13.gxTpr_Wwpuserextendedid_N = (short)(Convert.ToInt16(n1WWPUserExtendedId));
         obj13.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow13( GeneXus.Programs.wwpbaseobjects.notifications.web.SdtWWP_WebClient obj13 )
      {
         obj13.gxTpr_Wwpwebclientid = A57WWPWebClientId;
         return  ;
      }

      public void RowToVars13( GeneXus.Programs.wwpbaseobjects.notifications.web.SdtWWP_WebClient obj13 ,
                               int forceLoad )
      {
         Gx_mode = obj13.gxTpr_Mode;
         A58WWPWebClientBrowserId = obj13.gxTpr_Wwpwebclientbrowserid;
         A59WWPWebClientBrowserVersion = obj13.gxTpr_Wwpwebclientbrowserversion;
         A1WWPUserExtendedId = obj13.gxTpr_Wwpuserextendedid;
         n1WWPUserExtendedId = false;
         A60WWPWebClientFirstRegistered = obj13.gxTpr_Wwpwebclientfirstregistered;
         A61WWPWebClientLastRegistered = obj13.gxTpr_Wwpwebclientlastregistered;
         A57WWPWebClientId = obj13.gxTpr_Wwpwebclientid;
         Z57WWPWebClientId = obj13.gxTpr_Wwpwebclientid_Z;
         Z58WWPWebClientBrowserId = obj13.gxTpr_Wwpwebclientbrowserid_Z;
         Z60WWPWebClientFirstRegistered = obj13.gxTpr_Wwpwebclientfirstregistered_Z;
         Z61WWPWebClientLastRegistered = obj13.gxTpr_Wwpwebclientlastregistered_Z;
         Z1WWPUserExtendedId = obj13.gxTpr_Wwpuserextendedid_Z;
         n1WWPUserExtendedId = (bool)(Convert.ToBoolean(obj13.gxTpr_Wwpuserextendedid_N));
         Gx_mode = obj13.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A57WWPWebClientId = (string)getParm(obj,0);
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey0C13( ) ;
         ScanKeyStart0C13( ) ;
         if ( RcdFound13 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z57WWPWebClientId = A57WWPWebClientId;
         }
         ZM0C13( -5) ;
         OnLoadActions0C13( ) ;
         AddRow0C13( ) ;
         ScanKeyEnd0C13( ) ;
         if ( RcdFound13 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      public void Load( )
      {
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         RowToVars13( bcwwpbaseobjects_notifications_web_WWP_WebClient, 0) ;
         ScanKeyStart0C13( ) ;
         if ( RcdFound13 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z57WWPWebClientId = A57WWPWebClientId;
         }
         ZM0C13( -5) ;
         OnLoadActions0C13( ) ;
         AddRow0C13( ) ;
         ScanKeyEnd0C13( ) ;
         if ( RcdFound13 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         GetKey0C13( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert0C13( ) ;
         }
         else
         {
            if ( RcdFound13 == 1 )
            {
               if ( StringUtil.StrCmp(A57WWPWebClientId, Z57WWPWebClientId) != 0 )
               {
                  A57WWPWebClientId = Z57WWPWebClientId;
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "");
                  AnyError = 1;
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
               }
               else
               {
                  Gx_mode = "UPD";
                  /* Update record */
                  Update0C13( ) ;
               }
            }
            else
            {
               if ( IsDlt( ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "");
                  AnyError = 1;
               }
               else
               {
                  if ( StringUtil.StrCmp(A57WWPWebClientId, Z57WWPWebClientId) != 0 )
                  {
                     if ( IsUpd( ) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "DuplicatePrimaryKey", 1, "");
                        AnyError = 1;
                     }
                     else
                     {
                        Gx_mode = "INS";
                        /* Insert record */
                        Insert0C13( ) ;
                     }
                  }
                  else
                  {
                     if ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "");
                        AnyError = 1;
                     }
                     else
                     {
                        Gx_mode = "INS";
                        /* Insert record */
                        Insert0C13( ) ;
                     }
                  }
               }
            }
         }
         AfterTrn( ) ;
      }

      public void Save( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars13( bcwwpbaseobjects_notifications_web_WWP_WebClient, 1) ;
         SaveImpl( ) ;
         VarsToRow13( bcwwpbaseobjects_notifications_web_WWP_WebClient) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public bool Insert( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars13( bcwwpbaseobjects_notifications_web_WWP_WebClient, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert0C13( ) ;
         AfterTrn( ) ;
         VarsToRow13( bcwwpbaseobjects_notifications_web_WWP_WebClient) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
            VarsToRow13( bcwwpbaseobjects_notifications_web_WWP_WebClient) ;
         }
         else
         {
            GeneXus.Programs.wwpbaseobjects.notifications.web.SdtWWP_WebClient auxBC = new GeneXus.Programs.wwpbaseobjects.notifications.web.SdtWWP_WebClient(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A57WWPWebClientId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcwwpbaseobjects_notifications_web_WWP_WebClient);
               auxBC.Save();
               bcwwpbaseobjects_notifications_web_WWP_WebClient.Copy((GxSilentTrnSdt)(auxBC));
            }
            LclMsgLst = (msglist)(auxTrn.GetMessages());
            AnyError = (short)(auxTrn.Errors());
            context.GX_msglist = LclMsgLst;
            if ( auxTrn.Errors() == 0 )
            {
               Gx_mode = auxTrn.GetMode();
               AfterTrn( ) ;
            }
         }
      }

      public bool Update( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars13( bcwwpbaseobjects_notifications_web_WWP_WebClient, 1) ;
         UpdateImpl( ) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      public bool InsertOrUpdate( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars13( bcwwpbaseobjects_notifications_web_WWP_WebClient, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert0C13( ) ;
         if ( AnyError == 1 )
         {
            if ( StringUtil.StrCmp(context.GX_msglist.getItemValue(1), "DuplicatePrimaryKey") == 0 )
            {
               AnyError = 0;
               context.GX_msglist.removeAllItems();
               UpdateImpl( ) ;
            }
            else
            {
               VarsToRow13( bcwwpbaseobjects_notifications_web_WWP_WebClient) ;
            }
         }
         else
         {
            AfterTrn( ) ;
            VarsToRow13( bcwwpbaseobjects_notifications_web_WWP_WebClient) ;
         }
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      public void Check( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars13( bcwwpbaseobjects_notifications_web_WWP_WebClient, 0) ;
         GetKey0C13( ) ;
         if ( RcdFound13 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( StringUtil.StrCmp(A57WWPWebClientId, Z57WWPWebClientId) != 0 )
            {
               A57WWPWebClientId = Z57WWPWebClientId;
               GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( IsDlt( ) )
            {
               delete_Check( ) ;
            }
            else
            {
               Gx_mode = "UPD";
               update_Check( ) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(A57WWPWebClientId, Z57WWPWebClientId) != 0 )
            {
               Gx_mode = "INS";
               insert_Check( ) ;
            }
            else
            {
               if ( IsUpd( ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "");
                  AnyError = 1;
               }
               else
               {
                  Gx_mode = "INS";
                  insert_Check( ) ;
               }
            }
         }
         pr_default.close(1);
         context.RollbackDataStores("wwpbaseobjects.notifications.web.wwp_webclient_bc",pr_default);
         VarsToRow13( bcwwpbaseobjects_notifications_web_WWP_WebClient) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public int Errors( )
      {
         if ( AnyError == 0 )
         {
            return (int)(0) ;
         }
         return (int)(1) ;
      }

      public msglist GetMessages( )
      {
         return LclMsgLst ;
      }

      public string GetMode( )
      {
         Gx_mode = bcwwpbaseobjects_notifications_web_WWP_WebClient.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcwwpbaseobjects_notifications_web_WWP_WebClient.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcwwpbaseobjects_notifications_web_WWP_WebClient )
         {
            bcwwpbaseobjects_notifications_web_WWP_WebClient = (GeneXus.Programs.wwpbaseobjects.notifications.web.SdtWWP_WebClient)(sdt);
            if ( StringUtil.StrCmp(bcwwpbaseobjects_notifications_web_WWP_WebClient.gxTpr_Mode, "") == 0 )
            {
               bcwwpbaseobjects_notifications_web_WWP_WebClient.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow13( bcwwpbaseobjects_notifications_web_WWP_WebClient) ;
            }
            else
            {
               RowToVars13( bcwwpbaseobjects_notifications_web_WWP_WebClient, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcwwpbaseobjects_notifications_web_WWP_WebClient.gxTpr_Mode, "") == 0 )
            {
               bcwwpbaseobjects_notifications_web_WWP_WebClient.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars13( bcwwpbaseobjects_notifications_web_WWP_WebClient, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         return  ;
      }

      public SdtWWP_WebClient WWP_WebClient_BC
      {
         get {
            return bcwwpbaseobjects_notifications_web_WWP_WebClient ;
         }

      }

      public override void webExecute( )
      {
         createObjects();
         initialize();
      }

      public bool isMasterPage( )
      {
         return false;
      }

      protected override void createObjects( )
      {
      }

      protected void Process( )
      {
      }

      public override void cleanup( )
      {
         CloseCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
      }

      protected override void CloseCursors( )
      {
         pr_default.close(1);
      }

      public override void initialize( )
      {
         Gx_mode = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         Z57WWPWebClientId = "";
         A57WWPWebClientId = "";
         Z60WWPWebClientFirstRegistered = (DateTime)(DateTime.MinValue);
         A60WWPWebClientFirstRegistered = (DateTime)(DateTime.MinValue);
         Z61WWPWebClientLastRegistered = (DateTime)(DateTime.MinValue);
         A61WWPWebClientLastRegistered = (DateTime)(DateTime.MinValue);
         Z1WWPUserExtendedId = "";
         A1WWPUserExtendedId = "";
         Z59WWPWebClientBrowserVersion = "";
         A59WWPWebClientBrowserVersion = "";
         BC000C5_A57WWPWebClientId = new string[] {""} ;
         BC000C5_A58WWPWebClientBrowserId = new short[1] ;
         BC000C5_A59WWPWebClientBrowserVersion = new string[] {""} ;
         BC000C5_A60WWPWebClientFirstRegistered = new DateTime[] {DateTime.MinValue} ;
         BC000C5_A61WWPWebClientLastRegistered = new DateTime[] {DateTime.MinValue} ;
         BC000C5_A1WWPUserExtendedId = new string[] {""} ;
         BC000C5_n1WWPUserExtendedId = new bool[] {false} ;
         BC000C4_A1WWPUserExtendedId = new string[] {""} ;
         BC000C4_n1WWPUserExtendedId = new bool[] {false} ;
         BC000C6_A57WWPWebClientId = new string[] {""} ;
         BC000C3_A57WWPWebClientId = new string[] {""} ;
         BC000C3_A58WWPWebClientBrowserId = new short[1] ;
         BC000C3_A59WWPWebClientBrowserVersion = new string[] {""} ;
         BC000C3_A60WWPWebClientFirstRegistered = new DateTime[] {DateTime.MinValue} ;
         BC000C3_A61WWPWebClientLastRegistered = new DateTime[] {DateTime.MinValue} ;
         BC000C3_A1WWPUserExtendedId = new string[] {""} ;
         BC000C3_n1WWPUserExtendedId = new bool[] {false} ;
         sMode13 = "";
         BC000C2_A57WWPWebClientId = new string[] {""} ;
         BC000C2_A58WWPWebClientBrowserId = new short[1] ;
         BC000C2_A59WWPWebClientBrowserVersion = new string[] {""} ;
         BC000C2_A60WWPWebClientFirstRegistered = new DateTime[] {DateTime.MinValue} ;
         BC000C2_A61WWPWebClientLastRegistered = new DateTime[] {DateTime.MinValue} ;
         BC000C2_A1WWPUserExtendedId = new string[] {""} ;
         BC000C2_n1WWPUserExtendedId = new bool[] {false} ;
         BC000C10_A57WWPWebClientId = new string[] {""} ;
         BC000C10_A58WWPWebClientBrowserId = new short[1] ;
         BC000C10_A59WWPWebClientBrowserVersion = new string[] {""} ;
         BC000C10_A60WWPWebClientFirstRegistered = new DateTime[] {DateTime.MinValue} ;
         BC000C10_A61WWPWebClientLastRegistered = new DateTime[] {DateTime.MinValue} ;
         BC000C10_A1WWPUserExtendedId = new string[] {""} ;
         BC000C10_n1WWPUserExtendedId = new bool[] {false} ;
         i60WWPWebClientFirstRegistered = (DateTime)(DateTime.MinValue);
         i61WWPWebClientLastRegistered = (DateTime)(DateTime.MinValue);
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.notifications.web.wwp_webclient_bc__datastore1(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.notifications.web.wwp_webclient_bc__default(),
            new Object[][] {
                new Object[] {
               BC000C2_A57WWPWebClientId, BC000C2_A58WWPWebClientBrowserId, BC000C2_A59WWPWebClientBrowserVersion, BC000C2_A60WWPWebClientFirstRegistered, BC000C2_A61WWPWebClientLastRegistered, BC000C2_A1WWPUserExtendedId, BC000C2_n1WWPUserExtendedId
               }
               , new Object[] {
               BC000C3_A57WWPWebClientId, BC000C3_A58WWPWebClientBrowserId, BC000C3_A59WWPWebClientBrowserVersion, BC000C3_A60WWPWebClientFirstRegistered, BC000C3_A61WWPWebClientLastRegistered, BC000C3_A1WWPUserExtendedId, BC000C3_n1WWPUserExtendedId
               }
               , new Object[] {
               BC000C4_A1WWPUserExtendedId
               }
               , new Object[] {
               BC000C5_A57WWPWebClientId, BC000C5_A58WWPWebClientBrowserId, BC000C5_A59WWPWebClientBrowserVersion, BC000C5_A60WWPWebClientFirstRegistered, BC000C5_A61WWPWebClientLastRegistered, BC000C5_A1WWPUserExtendedId, BC000C5_n1WWPUserExtendedId
               }
               , new Object[] {
               BC000C6_A57WWPWebClientId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC000C10_A57WWPWebClientId, BC000C10_A58WWPWebClientBrowserId, BC000C10_A59WWPWebClientBrowserVersion, BC000C10_A60WWPWebClientFirstRegistered, BC000C10_A61WWPWebClientLastRegistered, BC000C10_A1WWPUserExtendedId, BC000C10_n1WWPUserExtendedId
               }
            }
         );
         Z61WWPWebClientLastRegistered = DateTimeUtil.ServerNowMs( context, pr_default);
         A61WWPWebClientLastRegistered = DateTimeUtil.ServerNowMs( context, pr_default);
         i61WWPWebClientLastRegistered = DateTimeUtil.ServerNowMs( context, pr_default);
         Z60WWPWebClientFirstRegistered = DateTimeUtil.ServerNowMs( context, pr_default);
         A60WWPWebClientFirstRegistered = DateTimeUtil.ServerNowMs( context, pr_default);
         i60WWPWebClientFirstRegistered = DateTimeUtil.ServerNowMs( context, pr_default);
         INITTRN();
         /* Execute Start event if defined. */
         standaloneNotModal( ) ;
      }

      private short AnyError ;
      private short Z58WWPWebClientBrowserId ;
      private short A58WWPWebClientBrowserId ;
      private short Gx_BScreen ;
      private short RcdFound13 ;
      private int trnEnded ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string Z57WWPWebClientId ;
      private string A57WWPWebClientId ;
      private string Z1WWPUserExtendedId ;
      private string A1WWPUserExtendedId ;
      private string sMode13 ;
      private DateTime Z60WWPWebClientFirstRegistered ;
      private DateTime A60WWPWebClientFirstRegistered ;
      private DateTime Z61WWPWebClientLastRegistered ;
      private DateTime A61WWPWebClientLastRegistered ;
      private DateTime i60WWPWebClientFirstRegistered ;
      private DateTime i61WWPWebClientLastRegistered ;
      private bool n1WWPUserExtendedId ;
      private string Z59WWPWebClientBrowserVersion ;
      private string A59WWPWebClientBrowserVersion ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] BC000C5_A57WWPWebClientId ;
      private short[] BC000C5_A58WWPWebClientBrowserId ;
      private string[] BC000C5_A59WWPWebClientBrowserVersion ;
      private DateTime[] BC000C5_A60WWPWebClientFirstRegistered ;
      private DateTime[] BC000C5_A61WWPWebClientLastRegistered ;
      private string[] BC000C5_A1WWPUserExtendedId ;
      private bool[] BC000C5_n1WWPUserExtendedId ;
      private string[] BC000C4_A1WWPUserExtendedId ;
      private bool[] BC000C4_n1WWPUserExtendedId ;
      private string[] BC000C6_A57WWPWebClientId ;
      private string[] BC000C3_A57WWPWebClientId ;
      private short[] BC000C3_A58WWPWebClientBrowserId ;
      private string[] BC000C3_A59WWPWebClientBrowserVersion ;
      private DateTime[] BC000C3_A60WWPWebClientFirstRegistered ;
      private DateTime[] BC000C3_A61WWPWebClientLastRegistered ;
      private string[] BC000C3_A1WWPUserExtendedId ;
      private bool[] BC000C3_n1WWPUserExtendedId ;
      private string[] BC000C2_A57WWPWebClientId ;
      private short[] BC000C2_A58WWPWebClientBrowserId ;
      private string[] BC000C2_A59WWPWebClientBrowserVersion ;
      private DateTime[] BC000C2_A60WWPWebClientFirstRegistered ;
      private DateTime[] BC000C2_A61WWPWebClientLastRegistered ;
      private string[] BC000C2_A1WWPUserExtendedId ;
      private bool[] BC000C2_n1WWPUserExtendedId ;
      private string[] BC000C10_A57WWPWebClientId ;
      private short[] BC000C10_A58WWPWebClientBrowserId ;
      private string[] BC000C10_A59WWPWebClientBrowserVersion ;
      private DateTime[] BC000C10_A60WWPWebClientFirstRegistered ;
      private DateTime[] BC000C10_A61WWPWebClientLastRegistered ;
      private string[] BC000C10_A1WWPUserExtendedId ;
      private bool[] BC000C10_n1WWPUserExtendedId ;
      private GeneXus.Programs.wwpbaseobjects.notifications.web.SdtWWP_WebClient bcwwpbaseobjects_notifications_web_WWP_WebClient ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_datastore1 ;
   }

   public class wwp_webclient_bc__datastore1 : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          def= new CursorDef[] {
          };
       }
    }

    public void getResults( int cursor ,
                            IFieldGetter rslt ,
                            Object[] buf )
    {
    }

    public override string getDataStoreName( )
    {
       return "DATASTORE1";
    }

 }

 public class wwp_webclient_bc__default : DataStoreHelperBase, IDataStoreHelper
 {
    public ICursor[] getCursors( )
    {
       cursorDefinitions();
       return new Cursor[] {
        new ForEachCursor(def[0])
       ,new ForEachCursor(def[1])
       ,new ForEachCursor(def[2])
       ,new ForEachCursor(def[3])
       ,new ForEachCursor(def[4])
       ,new UpdateCursor(def[5])
       ,new UpdateCursor(def[6])
       ,new UpdateCursor(def[7])
       ,new ForEachCursor(def[8])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmBC000C2;
        prmBC000C2 = new Object[] {
        new ParDef("@WWPWebClientId",GXType.NChar,100,0)
        };
        Object[] prmBC000C3;
        prmBC000C3 = new Object[] {
        new ParDef("@WWPWebClientId",GXType.NChar,100,0)
        };
        Object[] prmBC000C4;
        prmBC000C4 = new Object[] {
        new ParDef("@WWPUserExtendedId",GXType.NChar,40,0){Nullable=true}
        };
        Object[] prmBC000C5;
        prmBC000C5 = new Object[] {
        new ParDef("@WWPWebClientId",GXType.NChar,100,0)
        };
        Object[] prmBC000C6;
        prmBC000C6 = new Object[] {
        new ParDef("@WWPWebClientId",GXType.NChar,100,0)
        };
        Object[] prmBC000C7;
        prmBC000C7 = new Object[] {
        new ParDef("@WWPWebClientId",GXType.NChar,100,0) ,
        new ParDef("@WWPWebClientBrowserId",GXType.Int16,4,0) ,
        new ParDef("@WWPWebClientBrowserVersion",GXType.NVarChar,2097152,0) ,
        new ParDef("@WWPWebClientFirstRegistered",GXType.DateTime2,10,12) ,
        new ParDef("@WWPWebClientLastRegistered",GXType.DateTime2,10,12) ,
        new ParDef("@WWPUserExtendedId",GXType.NChar,40,0){Nullable=true}
        };
        Object[] prmBC000C8;
        prmBC000C8 = new Object[] {
        new ParDef("@WWPWebClientBrowserId",GXType.Int16,4,0) ,
        new ParDef("@WWPWebClientBrowserVersion",GXType.NVarChar,2097152,0) ,
        new ParDef("@WWPWebClientFirstRegistered",GXType.DateTime2,10,12) ,
        new ParDef("@WWPWebClientLastRegistered",GXType.DateTime2,10,12) ,
        new ParDef("@WWPUserExtendedId",GXType.NChar,40,0){Nullable=true} ,
        new ParDef("@WWPWebClientId",GXType.NChar,100,0)
        };
        Object[] prmBC000C9;
        prmBC000C9 = new Object[] {
        new ParDef("@WWPWebClientId",GXType.NChar,100,0)
        };
        Object[] prmBC000C10;
        prmBC000C10 = new Object[] {
        new ParDef("@WWPWebClientId",GXType.NChar,100,0)
        };
        def= new CursorDef[] {
            new CursorDef("BC000C2", "SELECT [WWPWebClientId], [WWPWebClientBrowserId], [WWPWebClientBrowserVersion], [WWPWebClientFirstRegistered], [WWPWebClientLastRegistered], [WWPUserExtendedId] FROM [WWP_WebClient] WITH (UPDLOCK) WHERE [WWPWebClientId] = @WWPWebClientId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000C2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000C3", "SELECT [WWPWebClientId], [WWPWebClientBrowserId], [WWPWebClientBrowserVersion], [WWPWebClientFirstRegistered], [WWPWebClientLastRegistered], [WWPUserExtendedId] FROM [WWP_WebClient] WHERE [WWPWebClientId] = @WWPWebClientId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000C3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000C4", "SELECT [WWPUserExtendedId] FROM [WWP_UserExtended] WHERE [WWPUserExtendedId] = @WWPUserExtendedId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000C4,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000C5", "SELECT TM1.[WWPWebClientId], TM1.[WWPWebClientBrowserId], TM1.[WWPWebClientBrowserVersion], TM1.[WWPWebClientFirstRegistered], TM1.[WWPWebClientLastRegistered], TM1.[WWPUserExtendedId] FROM [WWP_WebClient] TM1 WHERE TM1.[WWPWebClientId] = @WWPWebClientId ORDER BY TM1.[WWPWebClientId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmBC000C5,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000C6", "SELECT [WWPWebClientId] FROM [WWP_WebClient] WHERE [WWPWebClientId] = @WWPWebClientId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmBC000C6,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000C7", "INSERT INTO [WWP_WebClient]([WWPWebClientId], [WWPWebClientBrowserId], [WWPWebClientBrowserVersion], [WWPWebClientFirstRegistered], [WWPWebClientLastRegistered], [WWPUserExtendedId]) VALUES(@WWPWebClientId, @WWPWebClientBrowserId, @WWPWebClientBrowserVersion, @WWPWebClientFirstRegistered, @WWPWebClientLastRegistered, @WWPUserExtendedId)", GxErrorMask.GX_NOMASK,prmBC000C7)
           ,new CursorDef("BC000C8", "UPDATE [WWP_WebClient] SET [WWPWebClientBrowserId]=@WWPWebClientBrowserId, [WWPWebClientBrowserVersion]=@WWPWebClientBrowserVersion, [WWPWebClientFirstRegistered]=@WWPWebClientFirstRegistered, [WWPWebClientLastRegistered]=@WWPWebClientLastRegistered, [WWPUserExtendedId]=@WWPUserExtendedId  WHERE [WWPWebClientId] = @WWPWebClientId", GxErrorMask.GX_NOMASK,prmBC000C8)
           ,new CursorDef("BC000C9", "DELETE FROM [WWP_WebClient]  WHERE [WWPWebClientId] = @WWPWebClientId", GxErrorMask.GX_NOMASK,prmBC000C9)
           ,new CursorDef("BC000C10", "SELECT TM1.[WWPWebClientId], TM1.[WWPWebClientBrowserId], TM1.[WWPWebClientBrowserVersion], TM1.[WWPWebClientFirstRegistered], TM1.[WWPWebClientLastRegistered], TM1.[WWPUserExtendedId] FROM [WWP_WebClient] TM1 WHERE TM1.[WWPWebClientId] = @WWPWebClientId ORDER BY TM1.[WWPWebClientId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmBC000C10,100, GxCacheFrequency.OFF ,true,false )
        };
     }
  }

  public void getResults( int cursor ,
                          IFieldGetter rslt ,
                          Object[] buf )
  {
     switch ( cursor )
     {
           case 0 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              ((string[]) buf[2])[0] = rslt.getLongVarchar(3);
              ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(4, true);
              ((DateTime[]) buf[4])[0] = rslt.getGXDateTime(5, true);
              ((string[]) buf[5])[0] = rslt.getString(6, 40);
              ((bool[]) buf[6])[0] = rslt.wasNull(6);
              return;
           case 1 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              ((string[]) buf[2])[0] = rslt.getLongVarchar(3);
              ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(4, true);
              ((DateTime[]) buf[4])[0] = rslt.getGXDateTime(5, true);
              ((string[]) buf[5])[0] = rslt.getString(6, 40);
              ((bool[]) buf[6])[0] = rslt.wasNull(6);
              return;
           case 2 :
              ((string[]) buf[0])[0] = rslt.getString(1, 40);
              return;
           case 3 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              ((string[]) buf[2])[0] = rslt.getLongVarchar(3);
              ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(4, true);
              ((DateTime[]) buf[4])[0] = rslt.getGXDateTime(5, true);
              ((string[]) buf[5])[0] = rslt.getString(6, 40);
              ((bool[]) buf[6])[0] = rslt.wasNull(6);
              return;
           case 4 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 8 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              ((string[]) buf[2])[0] = rslt.getLongVarchar(3);
              ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(4, true);
              ((DateTime[]) buf[4])[0] = rslt.getGXDateTime(5, true);
              ((string[]) buf[5])[0] = rslt.getString(6, 40);
              ((bool[]) buf[6])[0] = rslt.wasNull(6);
              return;
     }
  }

}

}

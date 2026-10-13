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
namespace GeneXus.Programs.wwpbaseobjects.mail {
   public class wwp_mailtemplate_bc : GXHttpHandler, IGxSilentTrn
   {
      public wwp_mailtemplate_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wwp_mailtemplate_bc( IGxContext context )
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
         ReadRow0F16( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey0F16( ) ;
         standaloneModal( ) ;
         AddRow0F16( ) ;
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
            /* Execute user event: After Trn */
            E110F2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               Z97WWPMailTemplateName = A97WWPMailTemplateName;
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

      protected void CONFIRM_0F0( )
      {
         BeforeValidate0F16( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls0F16( ) ;
            }
            else
            {
               CheckExtendedTable0F16( ) ;
               if ( AnyError == 0 )
               {
               }
               CloseExtendedTableCursors0F16( ) ;
            }
         }
         if ( AnyError == 0 )
         {
         }
      }

      protected void E120F2( )
      {
         /* Start Routine */
         returnInSub = false;
      }

      protected void E110F2( )
      {
         /* After Trn Routine */
         returnInSub = false;
      }

      protected void ZM0F16( short GX_JID )
      {
         if ( ( GX_JID == 1 ) || ( GX_JID == 0 ) )
         {
            Z98WWPMailTemplateDescription = A98WWPMailTemplateDescription;
            Z99WWPMailTemplateSubject = A99WWPMailTemplateSubject;
         }
         if ( GX_JID == -1 )
         {
            Z97WWPMailTemplateName = A97WWPMailTemplateName;
            Z98WWPMailTemplateDescription = A98WWPMailTemplateDescription;
            Z99WWPMailTemplateSubject = A99WWPMailTemplateSubject;
            Z82WWPMailTemplateBody = A82WWPMailTemplateBody;
            Z83WWPMailTemplateSenderAddress = A83WWPMailTemplateSenderAddress;
            Z84WWPMailTemplateSenderName = A84WWPMailTemplateSenderName;
         }
      }

      protected void standaloneNotModal( )
      {
      }

      protected void standaloneModal( )
      {
      }

      protected void Load0F16( )
      {
         /* Using cursor BC000F4 */
         pr_default.execute(2, new Object[] {A97WWPMailTemplateName});
         if ( (pr_default.getStatus(2) != 101) )
         {
            RcdFound16 = 1;
            A98WWPMailTemplateDescription = BC000F4_A98WWPMailTemplateDescription[0];
            A99WWPMailTemplateSubject = BC000F4_A99WWPMailTemplateSubject[0];
            A82WWPMailTemplateBody = BC000F4_A82WWPMailTemplateBody[0];
            A83WWPMailTemplateSenderAddress = BC000F4_A83WWPMailTemplateSenderAddress[0];
            A84WWPMailTemplateSenderName = BC000F4_A84WWPMailTemplateSenderName[0];
            ZM0F16( -1) ;
         }
         pr_default.close(2);
         OnLoadActions0F16( ) ;
      }

      protected void OnLoadActions0F16( )
      {
      }

      protected void CheckExtendedTable0F16( )
      {
         standaloneModal( ) ;
      }

      protected void CloseExtendedTableCursors0F16( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey0F16( )
      {
         /* Using cursor BC000F5 */
         pr_default.execute(3, new Object[] {A97WWPMailTemplateName});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound16 = 1;
         }
         else
         {
            RcdFound16 = 0;
         }
         pr_default.close(3);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC000F3 */
         pr_default.execute(1, new Object[] {A97WWPMailTemplateName});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0F16( 1) ;
            RcdFound16 = 1;
            A97WWPMailTemplateName = BC000F3_A97WWPMailTemplateName[0];
            A98WWPMailTemplateDescription = BC000F3_A98WWPMailTemplateDescription[0];
            A99WWPMailTemplateSubject = BC000F3_A99WWPMailTemplateSubject[0];
            A82WWPMailTemplateBody = BC000F3_A82WWPMailTemplateBody[0];
            A83WWPMailTemplateSenderAddress = BC000F3_A83WWPMailTemplateSenderAddress[0];
            A84WWPMailTemplateSenderName = BC000F3_A84WWPMailTemplateSenderName[0];
            Z97WWPMailTemplateName = A97WWPMailTemplateName;
            sMode16 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load0F16( ) ;
            if ( AnyError == 1 )
            {
               RcdFound16 = 0;
               InitializeNonKey0F16( ) ;
            }
            Gx_mode = sMode16;
         }
         else
         {
            RcdFound16 = 0;
            InitializeNonKey0F16( ) ;
            sMode16 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode16;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey0F16( ) ;
         if ( RcdFound16 == 0 )
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
         CONFIRM_0F0( ) ;
      }

      protected void update_Check( )
      {
         insert_Check( ) ;
      }

      protected void delete_Check( )
      {
         insert_Check( ) ;
      }

      protected void CheckOptimisticConcurrency0F16( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC000F2 */
            pr_default.execute(0, new Object[] {A97WWPMailTemplateName});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"WWP_MailTemplate"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z98WWPMailTemplateDescription, BC000F2_A98WWPMailTemplateDescription[0]) != 0 ) || ( StringUtil.StrCmp(Z99WWPMailTemplateSubject, BC000F2_A99WWPMailTemplateSubject[0]) != 0 ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"WWP_MailTemplate"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0F16( )
      {
         BeforeValidate0F16( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0F16( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0F16( 0) ;
            CheckOptimisticConcurrency0F16( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0F16( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0F16( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000F6 */
                     pr_default.execute(4, new Object[] {A97WWPMailTemplateName, A98WWPMailTemplateDescription, A99WWPMailTemplateSubject, A82WWPMailTemplateBody, A83WWPMailTemplateSenderAddress, A84WWPMailTemplateSenderName});
                     pr_default.close(4);
                     pr_default.SmartCacheProvider.SetUpdated("WWP_MailTemplate");
                     if ( (pr_default.getStatus(4) == 1) )
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
               Load0F16( ) ;
            }
            EndLevel0F16( ) ;
         }
         CloseExtendedTableCursors0F16( ) ;
      }

      protected void Update0F16( )
      {
         BeforeValidate0F16( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0F16( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0F16( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0F16( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0F16( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000F7 */
                     pr_default.execute(5, new Object[] {A98WWPMailTemplateDescription, A99WWPMailTemplateSubject, A82WWPMailTemplateBody, A83WWPMailTemplateSenderAddress, A84WWPMailTemplateSenderName, A97WWPMailTemplateName});
                     pr_default.close(5);
                     pr_default.SmartCacheProvider.SetUpdated("WWP_MailTemplate");
                     if ( (pr_default.getStatus(5) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"WWP_MailTemplate"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0F16( ) ;
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
            EndLevel0F16( ) ;
         }
         CloseExtendedTableCursors0F16( ) ;
      }

      protected void DeferredUpdate0F16( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate0F16( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0F16( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0F16( ) ;
            AfterConfirm0F16( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0F16( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC000F8 */
                  pr_default.execute(6, new Object[] {A97WWPMailTemplateName});
                  pr_default.close(6);
                  pr_default.SmartCacheProvider.SetUpdated("WWP_MailTemplate");
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
         sMode16 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel0F16( ) ;
         Gx_mode = sMode16;
      }

      protected void OnDeleteControls0F16( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel0F16( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0F16( ) ;
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

      public void ScanKeyStart0F16( )
      {
         /* Using cursor BC000F9 */
         pr_default.execute(7, new Object[] {A97WWPMailTemplateName});
         RcdFound16 = 0;
         if ( (pr_default.getStatus(7) != 101) )
         {
            RcdFound16 = 1;
            A97WWPMailTemplateName = BC000F9_A97WWPMailTemplateName[0];
            A98WWPMailTemplateDescription = BC000F9_A98WWPMailTemplateDescription[0];
            A99WWPMailTemplateSubject = BC000F9_A99WWPMailTemplateSubject[0];
            A82WWPMailTemplateBody = BC000F9_A82WWPMailTemplateBody[0];
            A83WWPMailTemplateSenderAddress = BC000F9_A83WWPMailTemplateSenderAddress[0];
            A84WWPMailTemplateSenderName = BC000F9_A84WWPMailTemplateSenderName[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext0F16( )
      {
         /* Scan next routine */
         pr_default.readNext(7);
         RcdFound16 = 0;
         ScanKeyLoad0F16( ) ;
      }

      protected void ScanKeyLoad0F16( )
      {
         sMode16 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(7) != 101) )
         {
            RcdFound16 = 1;
            A97WWPMailTemplateName = BC000F9_A97WWPMailTemplateName[0];
            A98WWPMailTemplateDescription = BC000F9_A98WWPMailTemplateDescription[0];
            A99WWPMailTemplateSubject = BC000F9_A99WWPMailTemplateSubject[0];
            A82WWPMailTemplateBody = BC000F9_A82WWPMailTemplateBody[0];
            A83WWPMailTemplateSenderAddress = BC000F9_A83WWPMailTemplateSenderAddress[0];
            A84WWPMailTemplateSenderName = BC000F9_A84WWPMailTemplateSenderName[0];
         }
         Gx_mode = sMode16;
      }

      protected void ScanKeyEnd0F16( )
      {
         pr_default.close(7);
      }

      protected void AfterConfirm0F16( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0F16( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0F16( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0F16( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0F16( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0F16( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0F16( )
      {
      }

      protected void send_integrity_lvl_hashes0F16( )
      {
      }

      protected void AddRow0F16( )
      {
         VarsToRow16( bcwwpbaseobjects_mail_WWP_MailTemplate) ;
      }

      protected void ReadRow0F16( )
      {
         RowToVars16( bcwwpbaseobjects_mail_WWP_MailTemplate, 1) ;
      }

      protected void InitializeNonKey0F16( )
      {
         A98WWPMailTemplateDescription = "";
         A99WWPMailTemplateSubject = "";
         A82WWPMailTemplateBody = "";
         A83WWPMailTemplateSenderAddress = "";
         A84WWPMailTemplateSenderName = "";
         Z98WWPMailTemplateDescription = "";
         Z99WWPMailTemplateSubject = "";
      }

      protected void InitAll0F16( )
      {
         A97WWPMailTemplateName = "";
         InitializeNonKey0F16( ) ;
      }

      protected void StandaloneModalInsert( )
      {
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

      public void VarsToRow16( GeneXus.Programs.wwpbaseobjects.mail.SdtWWP_MailTemplate obj16 )
      {
         obj16.gxTpr_Mode = Gx_mode;
         obj16.gxTpr_Wwpmailtemplatedescription = A98WWPMailTemplateDescription;
         obj16.gxTpr_Wwpmailtemplatesubject = A99WWPMailTemplateSubject;
         obj16.gxTpr_Wwpmailtemplatebody = A82WWPMailTemplateBody;
         obj16.gxTpr_Wwpmailtemplatesenderaddress = A83WWPMailTemplateSenderAddress;
         obj16.gxTpr_Wwpmailtemplatesendername = A84WWPMailTemplateSenderName;
         obj16.gxTpr_Wwpmailtemplatename = A97WWPMailTemplateName;
         obj16.gxTpr_Wwpmailtemplatename_Z = Z97WWPMailTemplateName;
         obj16.gxTpr_Wwpmailtemplatedescription_Z = Z98WWPMailTemplateDescription;
         obj16.gxTpr_Wwpmailtemplatesubject_Z = Z99WWPMailTemplateSubject;
         obj16.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow16( GeneXus.Programs.wwpbaseobjects.mail.SdtWWP_MailTemplate obj16 )
      {
         obj16.gxTpr_Wwpmailtemplatename = A97WWPMailTemplateName;
         return  ;
      }

      public void RowToVars16( GeneXus.Programs.wwpbaseobjects.mail.SdtWWP_MailTemplate obj16 ,
                               int forceLoad )
      {
         Gx_mode = obj16.gxTpr_Mode;
         A98WWPMailTemplateDescription = obj16.gxTpr_Wwpmailtemplatedescription;
         A99WWPMailTemplateSubject = obj16.gxTpr_Wwpmailtemplatesubject;
         A82WWPMailTemplateBody = obj16.gxTpr_Wwpmailtemplatebody;
         A83WWPMailTemplateSenderAddress = obj16.gxTpr_Wwpmailtemplatesenderaddress;
         A84WWPMailTemplateSenderName = obj16.gxTpr_Wwpmailtemplatesendername;
         A97WWPMailTemplateName = obj16.gxTpr_Wwpmailtemplatename;
         Z97WWPMailTemplateName = obj16.gxTpr_Wwpmailtemplatename_Z;
         Z98WWPMailTemplateDescription = obj16.gxTpr_Wwpmailtemplatedescription_Z;
         Z99WWPMailTemplateSubject = obj16.gxTpr_Wwpmailtemplatesubject_Z;
         Gx_mode = obj16.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A97WWPMailTemplateName = (string)getParm(obj,0);
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey0F16( ) ;
         ScanKeyStart0F16( ) ;
         if ( RcdFound16 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z97WWPMailTemplateName = A97WWPMailTemplateName;
         }
         ZM0F16( -1) ;
         OnLoadActions0F16( ) ;
         AddRow0F16( ) ;
         ScanKeyEnd0F16( ) ;
         if ( RcdFound16 == 0 )
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
         RowToVars16( bcwwpbaseobjects_mail_WWP_MailTemplate, 0) ;
         ScanKeyStart0F16( ) ;
         if ( RcdFound16 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z97WWPMailTemplateName = A97WWPMailTemplateName;
         }
         ZM0F16( -1) ;
         OnLoadActions0F16( ) ;
         AddRow0F16( ) ;
         ScanKeyEnd0F16( ) ;
         if ( RcdFound16 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         GetKey0F16( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert0F16( ) ;
         }
         else
         {
            if ( RcdFound16 == 1 )
            {
               if ( StringUtil.StrCmp(A97WWPMailTemplateName, Z97WWPMailTemplateName) != 0 )
               {
                  A97WWPMailTemplateName = Z97WWPMailTemplateName;
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
                  Update0F16( ) ;
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
                  if ( StringUtil.StrCmp(A97WWPMailTemplateName, Z97WWPMailTemplateName) != 0 )
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
                        Insert0F16( ) ;
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
                        Insert0F16( ) ;
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
         RowToVars16( bcwwpbaseobjects_mail_WWP_MailTemplate, 1) ;
         SaveImpl( ) ;
         VarsToRow16( bcwwpbaseobjects_mail_WWP_MailTemplate) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public bool Insert( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars16( bcwwpbaseobjects_mail_WWP_MailTemplate, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert0F16( ) ;
         AfterTrn( ) ;
         VarsToRow16( bcwwpbaseobjects_mail_WWP_MailTemplate) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
            VarsToRow16( bcwwpbaseobjects_mail_WWP_MailTemplate) ;
         }
         else
         {
            GeneXus.Programs.wwpbaseobjects.mail.SdtWWP_MailTemplate auxBC = new GeneXus.Programs.wwpbaseobjects.mail.SdtWWP_MailTemplate(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A97WWPMailTemplateName);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcwwpbaseobjects_mail_WWP_MailTemplate);
               auxBC.Save();
               bcwwpbaseobjects_mail_WWP_MailTemplate.Copy((GxSilentTrnSdt)(auxBC));
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
         RowToVars16( bcwwpbaseobjects_mail_WWP_MailTemplate, 1) ;
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
         RowToVars16( bcwwpbaseobjects_mail_WWP_MailTemplate, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert0F16( ) ;
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
               VarsToRow16( bcwwpbaseobjects_mail_WWP_MailTemplate) ;
            }
         }
         else
         {
            AfterTrn( ) ;
            VarsToRow16( bcwwpbaseobjects_mail_WWP_MailTemplate) ;
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
         RowToVars16( bcwwpbaseobjects_mail_WWP_MailTemplate, 0) ;
         GetKey0F16( ) ;
         if ( RcdFound16 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( StringUtil.StrCmp(A97WWPMailTemplateName, Z97WWPMailTemplateName) != 0 )
            {
               A97WWPMailTemplateName = Z97WWPMailTemplateName;
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
            if ( StringUtil.StrCmp(A97WWPMailTemplateName, Z97WWPMailTemplateName) != 0 )
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
         context.RollbackDataStores("wwpbaseobjects.mail.wwp_mailtemplate_bc",pr_default);
         VarsToRow16( bcwwpbaseobjects_mail_WWP_MailTemplate) ;
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
         Gx_mode = bcwwpbaseobjects_mail_WWP_MailTemplate.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcwwpbaseobjects_mail_WWP_MailTemplate.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcwwpbaseobjects_mail_WWP_MailTemplate )
         {
            bcwwpbaseobjects_mail_WWP_MailTemplate = (GeneXus.Programs.wwpbaseobjects.mail.SdtWWP_MailTemplate)(sdt);
            if ( StringUtil.StrCmp(bcwwpbaseobjects_mail_WWP_MailTemplate.gxTpr_Mode, "") == 0 )
            {
               bcwwpbaseobjects_mail_WWP_MailTemplate.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow16( bcwwpbaseobjects_mail_WWP_MailTemplate) ;
            }
            else
            {
               RowToVars16( bcwwpbaseobjects_mail_WWP_MailTemplate, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcwwpbaseobjects_mail_WWP_MailTemplate.gxTpr_Mode, "") == 0 )
            {
               bcwwpbaseobjects_mail_WWP_MailTemplate.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars16( bcwwpbaseobjects_mail_WWP_MailTemplate, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         return  ;
      }

      public SdtWWP_MailTemplate WWP_MailTemplate_BC
      {
         get {
            return bcwwpbaseobjects_mail_WWP_MailTemplate ;
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
         Z97WWPMailTemplateName = "";
         A97WWPMailTemplateName = "";
         Z98WWPMailTemplateDescription = "";
         A98WWPMailTemplateDescription = "";
         Z99WWPMailTemplateSubject = "";
         A99WWPMailTemplateSubject = "";
         Z82WWPMailTemplateBody = "";
         A82WWPMailTemplateBody = "";
         Z83WWPMailTemplateSenderAddress = "";
         A83WWPMailTemplateSenderAddress = "";
         Z84WWPMailTemplateSenderName = "";
         A84WWPMailTemplateSenderName = "";
         BC000F4_A97WWPMailTemplateName = new string[] {""} ;
         BC000F4_A98WWPMailTemplateDescription = new string[] {""} ;
         BC000F4_A99WWPMailTemplateSubject = new string[] {""} ;
         BC000F4_A82WWPMailTemplateBody = new string[] {""} ;
         BC000F4_A83WWPMailTemplateSenderAddress = new string[] {""} ;
         BC000F4_A84WWPMailTemplateSenderName = new string[] {""} ;
         BC000F5_A97WWPMailTemplateName = new string[] {""} ;
         BC000F3_A97WWPMailTemplateName = new string[] {""} ;
         BC000F3_A98WWPMailTemplateDescription = new string[] {""} ;
         BC000F3_A99WWPMailTemplateSubject = new string[] {""} ;
         BC000F3_A82WWPMailTemplateBody = new string[] {""} ;
         BC000F3_A83WWPMailTemplateSenderAddress = new string[] {""} ;
         BC000F3_A84WWPMailTemplateSenderName = new string[] {""} ;
         sMode16 = "";
         BC000F2_A97WWPMailTemplateName = new string[] {""} ;
         BC000F2_A98WWPMailTemplateDescription = new string[] {""} ;
         BC000F2_A99WWPMailTemplateSubject = new string[] {""} ;
         BC000F2_A82WWPMailTemplateBody = new string[] {""} ;
         BC000F2_A83WWPMailTemplateSenderAddress = new string[] {""} ;
         BC000F2_A84WWPMailTemplateSenderName = new string[] {""} ;
         BC000F9_A97WWPMailTemplateName = new string[] {""} ;
         BC000F9_A98WWPMailTemplateDescription = new string[] {""} ;
         BC000F9_A99WWPMailTemplateSubject = new string[] {""} ;
         BC000F9_A82WWPMailTemplateBody = new string[] {""} ;
         BC000F9_A83WWPMailTemplateSenderAddress = new string[] {""} ;
         BC000F9_A84WWPMailTemplateSenderName = new string[] {""} ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.mail.wwp_mailtemplate_bc__datastore1(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.mail.wwp_mailtemplate_bc__default(),
            new Object[][] {
                new Object[] {
               BC000F2_A97WWPMailTemplateName, BC000F2_A98WWPMailTemplateDescription, BC000F2_A99WWPMailTemplateSubject, BC000F2_A82WWPMailTemplateBody, BC000F2_A83WWPMailTemplateSenderAddress, BC000F2_A84WWPMailTemplateSenderName
               }
               , new Object[] {
               BC000F3_A97WWPMailTemplateName, BC000F3_A98WWPMailTemplateDescription, BC000F3_A99WWPMailTemplateSubject, BC000F3_A82WWPMailTemplateBody, BC000F3_A83WWPMailTemplateSenderAddress, BC000F3_A84WWPMailTemplateSenderName
               }
               , new Object[] {
               BC000F4_A97WWPMailTemplateName, BC000F4_A98WWPMailTemplateDescription, BC000F4_A99WWPMailTemplateSubject, BC000F4_A82WWPMailTemplateBody, BC000F4_A83WWPMailTemplateSenderAddress, BC000F4_A84WWPMailTemplateSenderName
               }
               , new Object[] {
               BC000F5_A97WWPMailTemplateName
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC000F9_A97WWPMailTemplateName, BC000F9_A98WWPMailTemplateDescription, BC000F9_A99WWPMailTemplateSubject, BC000F9_A82WWPMailTemplateBody, BC000F9_A83WWPMailTemplateSenderAddress, BC000F9_A84WWPMailTemplateSenderName
               }
            }
         );
         INITTRN();
         /* Execute Start event if defined. */
         /* Execute user event: Start */
         E120F2 ();
         standaloneNotModal( ) ;
      }

      private short AnyError ;
      private short RcdFound16 ;
      private int trnEnded ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string sMode16 ;
      private bool returnInSub ;
      private string Z82WWPMailTemplateBody ;
      private string A82WWPMailTemplateBody ;
      private string Z83WWPMailTemplateSenderAddress ;
      private string A83WWPMailTemplateSenderAddress ;
      private string Z84WWPMailTemplateSenderName ;
      private string A84WWPMailTemplateSenderName ;
      private string Z97WWPMailTemplateName ;
      private string A97WWPMailTemplateName ;
      private string Z98WWPMailTemplateDescription ;
      private string A98WWPMailTemplateDescription ;
      private string Z99WWPMailTemplateSubject ;
      private string A99WWPMailTemplateSubject ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] BC000F4_A97WWPMailTemplateName ;
      private string[] BC000F4_A98WWPMailTemplateDescription ;
      private string[] BC000F4_A99WWPMailTemplateSubject ;
      private string[] BC000F4_A82WWPMailTemplateBody ;
      private string[] BC000F4_A83WWPMailTemplateSenderAddress ;
      private string[] BC000F4_A84WWPMailTemplateSenderName ;
      private string[] BC000F5_A97WWPMailTemplateName ;
      private string[] BC000F3_A97WWPMailTemplateName ;
      private string[] BC000F3_A98WWPMailTemplateDescription ;
      private string[] BC000F3_A99WWPMailTemplateSubject ;
      private string[] BC000F3_A82WWPMailTemplateBody ;
      private string[] BC000F3_A83WWPMailTemplateSenderAddress ;
      private string[] BC000F3_A84WWPMailTemplateSenderName ;
      private string[] BC000F2_A97WWPMailTemplateName ;
      private string[] BC000F2_A98WWPMailTemplateDescription ;
      private string[] BC000F2_A99WWPMailTemplateSubject ;
      private string[] BC000F2_A82WWPMailTemplateBody ;
      private string[] BC000F2_A83WWPMailTemplateSenderAddress ;
      private string[] BC000F2_A84WWPMailTemplateSenderName ;
      private string[] BC000F9_A97WWPMailTemplateName ;
      private string[] BC000F9_A98WWPMailTemplateDescription ;
      private string[] BC000F9_A99WWPMailTemplateSubject ;
      private string[] BC000F9_A82WWPMailTemplateBody ;
      private string[] BC000F9_A83WWPMailTemplateSenderAddress ;
      private string[] BC000F9_A84WWPMailTemplateSenderName ;
      private GeneXus.Programs.wwpbaseobjects.mail.SdtWWP_MailTemplate bcwwpbaseobjects_mail_WWP_MailTemplate ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_datastore1 ;
   }

   public class wwp_mailtemplate_bc__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class wwp_mailtemplate_bc__default : DataStoreHelperBase, IDataStoreHelper
 {
    public ICursor[] getCursors( )
    {
       cursorDefinitions();
       return new Cursor[] {
        new ForEachCursor(def[0])
       ,new ForEachCursor(def[1])
       ,new ForEachCursor(def[2])
       ,new ForEachCursor(def[3])
       ,new UpdateCursor(def[4])
       ,new UpdateCursor(def[5])
       ,new UpdateCursor(def[6])
       ,new ForEachCursor(def[7])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmBC000F2;
        prmBC000F2 = new Object[] {
        new ParDef("@WWPMailTemplateName",GXType.NVarChar,40,0)
        };
        Object[] prmBC000F3;
        prmBC000F3 = new Object[] {
        new ParDef("@WWPMailTemplateName",GXType.NVarChar,40,0)
        };
        Object[] prmBC000F4;
        prmBC000F4 = new Object[] {
        new ParDef("@WWPMailTemplateName",GXType.NVarChar,40,0)
        };
        Object[] prmBC000F5;
        prmBC000F5 = new Object[] {
        new ParDef("@WWPMailTemplateName",GXType.NVarChar,40,0)
        };
        Object[] prmBC000F6;
        prmBC000F6 = new Object[] {
        new ParDef("@WWPMailTemplateName",GXType.NVarChar,40,0) ,
        new ParDef("@WWPMailTemplateDescription",GXType.NVarChar,100,0) ,
        new ParDef("@WWPMailTemplateSubject",GXType.NVarChar,80,0) ,
        new ParDef("@WWPMailTemplateBody",GXType.NVarChar,2097152,0) ,
        new ParDef("@WWPMailTemplateSenderAddress",GXType.NVarChar,2097152,0) ,
        new ParDef("@WWPMailTemplateSenderName",GXType.NVarChar,2097152,0)
        };
        Object[] prmBC000F7;
        prmBC000F7 = new Object[] {
        new ParDef("@WWPMailTemplateDescription",GXType.NVarChar,100,0) ,
        new ParDef("@WWPMailTemplateSubject",GXType.NVarChar,80,0) ,
        new ParDef("@WWPMailTemplateBody",GXType.NVarChar,2097152,0) ,
        new ParDef("@WWPMailTemplateSenderAddress",GXType.NVarChar,2097152,0) ,
        new ParDef("@WWPMailTemplateSenderName",GXType.NVarChar,2097152,0) ,
        new ParDef("@WWPMailTemplateName",GXType.NVarChar,40,0)
        };
        Object[] prmBC000F8;
        prmBC000F8 = new Object[] {
        new ParDef("@WWPMailTemplateName",GXType.NVarChar,40,0)
        };
        Object[] prmBC000F9;
        prmBC000F9 = new Object[] {
        new ParDef("@WWPMailTemplateName",GXType.NVarChar,40,0)
        };
        def= new CursorDef[] {
            new CursorDef("BC000F2", "SELECT [WWPMailTemplateName], [WWPMailTemplateDescription], [WWPMailTemplateSubject], [WWPMailTemplateBody], [WWPMailTemplateSenderAddress], [WWPMailTemplateSenderName] FROM [WWP_MailTemplate] WITH (UPDLOCK) WHERE [WWPMailTemplateName] = @WWPMailTemplateName ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000F2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000F3", "SELECT [WWPMailTemplateName], [WWPMailTemplateDescription], [WWPMailTemplateSubject], [WWPMailTemplateBody], [WWPMailTemplateSenderAddress], [WWPMailTemplateSenderName] FROM [WWP_MailTemplate] WHERE [WWPMailTemplateName] = @WWPMailTemplateName ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000F3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000F4", "SELECT TM1.[WWPMailTemplateName], TM1.[WWPMailTemplateDescription], TM1.[WWPMailTemplateSubject], TM1.[WWPMailTemplateBody], TM1.[WWPMailTemplateSenderAddress], TM1.[WWPMailTemplateSenderName] FROM [WWP_MailTemplate] TM1 WHERE TM1.[WWPMailTemplateName] = @WWPMailTemplateName ORDER BY TM1.[WWPMailTemplateName]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmBC000F4,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000F5", "SELECT [WWPMailTemplateName] FROM [WWP_MailTemplate] WHERE [WWPMailTemplateName] = @WWPMailTemplateName  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmBC000F5,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000F6", "INSERT INTO [WWP_MailTemplate]([WWPMailTemplateName], [WWPMailTemplateDescription], [WWPMailTemplateSubject], [WWPMailTemplateBody], [WWPMailTemplateSenderAddress], [WWPMailTemplateSenderName]) VALUES(@WWPMailTemplateName, @WWPMailTemplateDescription, @WWPMailTemplateSubject, @WWPMailTemplateBody, @WWPMailTemplateSenderAddress, @WWPMailTemplateSenderName)", GxErrorMask.GX_NOMASK,prmBC000F6)
           ,new CursorDef("BC000F7", "UPDATE [WWP_MailTemplate] SET [WWPMailTemplateDescription]=@WWPMailTemplateDescription, [WWPMailTemplateSubject]=@WWPMailTemplateSubject, [WWPMailTemplateBody]=@WWPMailTemplateBody, [WWPMailTemplateSenderAddress]=@WWPMailTemplateSenderAddress, [WWPMailTemplateSenderName]=@WWPMailTemplateSenderName  WHERE [WWPMailTemplateName] = @WWPMailTemplateName", GxErrorMask.GX_NOMASK,prmBC000F7)
           ,new CursorDef("BC000F8", "DELETE FROM [WWP_MailTemplate]  WHERE [WWPMailTemplateName] = @WWPMailTemplateName", GxErrorMask.GX_NOMASK,prmBC000F8)
           ,new CursorDef("BC000F9", "SELECT TM1.[WWPMailTemplateName], TM1.[WWPMailTemplateDescription], TM1.[WWPMailTemplateSubject], TM1.[WWPMailTemplateBody], TM1.[WWPMailTemplateSenderAddress], TM1.[WWPMailTemplateSenderName] FROM [WWP_MailTemplate] TM1 WHERE TM1.[WWPMailTemplateName] = @WWPMailTemplateName ORDER BY TM1.[WWPMailTemplateName]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmBC000F9,100, GxCacheFrequency.OFF ,true,false )
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
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((string[]) buf[3])[0] = rslt.getLongVarchar(4);
              ((string[]) buf[4])[0] = rslt.getLongVarchar(5);
              ((string[]) buf[5])[0] = rslt.getLongVarchar(6);
              return;
           case 1 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((string[]) buf[3])[0] = rslt.getLongVarchar(4);
              ((string[]) buf[4])[0] = rslt.getLongVarchar(5);
              ((string[]) buf[5])[0] = rslt.getLongVarchar(6);
              return;
           case 2 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((string[]) buf[3])[0] = rslt.getLongVarchar(4);
              ((string[]) buf[4])[0] = rslt.getLongVarchar(5);
              ((string[]) buf[5])[0] = rslt.getLongVarchar(6);
              return;
           case 3 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 7 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((string[]) buf[3])[0] = rslt.getLongVarchar(4);
              ((string[]) buf[4])[0] = rslt.getLongVarchar(5);
              ((string[]) buf[5])[0] = rslt.getLongVarchar(6);
              return;
     }
  }

}

}

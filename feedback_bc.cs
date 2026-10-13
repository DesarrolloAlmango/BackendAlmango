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
namespace GeneXus.Programs {
   public class feedback_bc : GXHttpHandler, IGxSilentTrn
   {
      public feedback_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public feedback_bc( IGxContext context )
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
         ReadRow0L25( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey0L25( ) ;
         standaloneModal( ) ;
         AddRow0L25( ) ;
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
            E110L2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               Z117FeedBackId = A117FeedBackId;
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

      protected void CONFIRM_0L0( )
      {
         BeforeValidate0L25( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls0L25( ) ;
            }
            else
            {
               CheckExtendedTable0L25( ) ;
               if ( AnyError == 0 )
               {
               }
               CloseExtendedTableCursors0L25( ) ;
            }
         }
         if ( AnyError == 0 )
         {
         }
      }

      protected void E120L2( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV8WWPContext) ;
         AV9IsAuthorized = true;
         if ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )
         {
            GXt_boolean1 = AV9IsAuthorized;
            new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWFeedBack_Insert", out  GXt_boolean1) ;
            AV9IsAuthorized = GXt_boolean1;
         }
         if ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 )
         {
            GXt_boolean1 = AV9IsAuthorized;
            new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWFeedBack_Update", out  GXt_boolean1) ;
            AV9IsAuthorized = GXt_boolean1;
         }
         if ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 )
         {
            GXt_boolean1 = AV9IsAuthorized;
            new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWFeedBack_Delete", out  GXt_boolean1) ;
            AV9IsAuthorized = GXt_boolean1;
         }
         if ( ! AV9IsAuthorized )
         {
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "wwpbaseobjects.notauthorized.aspx"+UrlEncode(StringUtil.RTrim(AV13Pgmname));
            CallWebObject(formatLink("wwpbaseobjects.notauthorized.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
            context.wjLocDisableFrm = 1;
         }
         AV11TrnContext.FromXml(AV12WebSession.Get("TrnContext"), null, "", "");
      }

      protected void E110L2( )
      {
         /* After Trn Routine */
         returnInSub = false;
      }

      protected void ZM0L25( short GX_JID )
      {
         if ( ( GX_JID == 3 ) || ( GX_JID == 0 ) )
         {
            Z272FeedBackSolicitudId = A272FeedBackSolicitudId;
            Z273FeedBackProfesionalId = A273FeedBackProfesionalId;
            Z274FeedBackClienteId = A274FeedBackClienteId;
            Z275FeedBackNum = A275FeedBackNum;
            Z276FeedBackFechaAlta = A276FeedBackFechaAlta;
            Z277FeedBackFechaModif = A277FeedBackFechaModif;
         }
         if ( GX_JID == -3 )
         {
            Z117FeedBackId = A117FeedBackId;
            Z272FeedBackSolicitudId = A272FeedBackSolicitudId;
            Z273FeedBackProfesionalId = A273FeedBackProfesionalId;
            Z274FeedBackClienteId = A274FeedBackClienteId;
            Z275FeedBackNum = A275FeedBackNum;
            Z271FeedBackComentario = A271FeedBackComentario;
            Z276FeedBackFechaAlta = A276FeedBackFechaAlta;
            Z277FeedBackFechaModif = A277FeedBackFechaModif;
         }
      }

      protected void standaloneNotModal( )
      {
      }

      protected void standaloneModal( )
      {
      }

      protected void Load0L25( )
      {
         /* Using cursor BC000L4 */
         pr_default.execute(2, new Object[] {A117FeedBackId});
         if ( (pr_default.getStatus(2) != 101) )
         {
            RcdFound25 = 1;
            A272FeedBackSolicitudId = BC000L4_A272FeedBackSolicitudId[0];
            A273FeedBackProfesionalId = BC000L4_A273FeedBackProfesionalId[0];
            A274FeedBackClienteId = BC000L4_A274FeedBackClienteId[0];
            A275FeedBackNum = BC000L4_A275FeedBackNum[0];
            A271FeedBackComentario = BC000L4_A271FeedBackComentario[0];
            A276FeedBackFechaAlta = BC000L4_A276FeedBackFechaAlta[0];
            A277FeedBackFechaModif = BC000L4_A277FeedBackFechaModif[0];
            ZM0L25( -3) ;
         }
         pr_default.close(2);
         OnLoadActions0L25( ) ;
      }

      protected void OnLoadActions0L25( )
      {
         AV13Pgmname = "FeedBack_BC";
      }

      protected void CheckExtendedTable0L25( )
      {
         standaloneModal( ) ;
         AV13Pgmname = "FeedBack_BC";
         if ( ! ( (DateTime.MinValue==A276FeedBackFechaAlta) || ( DateTimeUtil.ResetTime ( A276FeedBackFechaAlta ) >= DateTimeUtil.ResetTime ( context.localUtil.YMDToD( 1753, 1, 1) ) ) ) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_OutOfRange", ""), context.GetMessage( "Feed Back Fecha Alta", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, "");
            AnyError = 1;
         }
         if ( ! ( (DateTime.MinValue==A277FeedBackFechaModif) || ( DateTimeUtil.ResetTime ( A277FeedBackFechaModif ) >= DateTimeUtil.ResetTime ( context.localUtil.YMDToD( 1753, 1, 1) ) ) ) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_OutOfRange", ""), context.GetMessage( "Feed Back Fecha Modif", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, "");
            AnyError = 1;
         }
      }

      protected void CloseExtendedTableCursors0L25( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey0L25( )
      {
         /* Using cursor BC000L5 */
         pr_default.execute(3, new Object[] {A117FeedBackId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound25 = 1;
         }
         else
         {
            RcdFound25 = 0;
         }
         pr_default.close(3);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC000L3 */
         pr_default.execute(1, new Object[] {A117FeedBackId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0L25( 3) ;
            RcdFound25 = 1;
            A117FeedBackId = BC000L3_A117FeedBackId[0];
            A272FeedBackSolicitudId = BC000L3_A272FeedBackSolicitudId[0];
            A273FeedBackProfesionalId = BC000L3_A273FeedBackProfesionalId[0];
            A274FeedBackClienteId = BC000L3_A274FeedBackClienteId[0];
            A275FeedBackNum = BC000L3_A275FeedBackNum[0];
            A271FeedBackComentario = BC000L3_A271FeedBackComentario[0];
            A276FeedBackFechaAlta = BC000L3_A276FeedBackFechaAlta[0];
            A277FeedBackFechaModif = BC000L3_A277FeedBackFechaModif[0];
            Z117FeedBackId = A117FeedBackId;
            sMode25 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load0L25( ) ;
            if ( AnyError == 1 )
            {
               RcdFound25 = 0;
               InitializeNonKey0L25( ) ;
            }
            Gx_mode = sMode25;
         }
         else
         {
            RcdFound25 = 0;
            InitializeNonKey0L25( ) ;
            sMode25 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode25;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey0L25( ) ;
         if ( RcdFound25 == 0 )
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
         CONFIRM_0L0( ) ;
      }

      protected void update_Check( )
      {
         insert_Check( ) ;
      }

      protected void delete_Check( )
      {
         insert_Check( ) ;
      }

      protected void CheckOptimisticConcurrency0L25( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC000L2 */
            pr_default.execute(0, new Object[] {A117FeedBackId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"FeedBack"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( Z272FeedBackSolicitudId != BC000L2_A272FeedBackSolicitudId[0] ) || ( StringUtil.StrCmp(Z273FeedBackProfesionalId, BC000L2_A273FeedBackProfesionalId[0]) != 0 ) || ( Z274FeedBackClienteId != BC000L2_A274FeedBackClienteId[0] ) || ( Z275FeedBackNum != BC000L2_A275FeedBackNum[0] ) || ( DateTimeUtil.ResetTime ( Z276FeedBackFechaAlta ) != DateTimeUtil.ResetTime ( BC000L2_A276FeedBackFechaAlta[0] ) ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( DateTimeUtil.ResetTime ( Z277FeedBackFechaModif ) != DateTimeUtil.ResetTime ( BC000L2_A277FeedBackFechaModif[0] ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"FeedBack"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0L25( )
      {
         BeforeValidate0L25( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0L25( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0L25( 0) ;
            CheckOptimisticConcurrency0L25( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0L25( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0L25( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000L6 */
                     pr_default.execute(4, new Object[] {A272FeedBackSolicitudId, A273FeedBackProfesionalId, A274FeedBackClienteId, A275FeedBackNum, A271FeedBackComentario, A276FeedBackFechaAlta, A277FeedBackFechaModif});
                     A117FeedBackId = BC000L6_A117FeedBackId[0];
                     pr_default.close(4);
                     pr_default.SmartCacheProvider.SetUpdated("FeedBack");
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
               Load0L25( ) ;
            }
            EndLevel0L25( ) ;
         }
         CloseExtendedTableCursors0L25( ) ;
      }

      protected void Update0L25( )
      {
         BeforeValidate0L25( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0L25( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0L25( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0L25( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0L25( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000L7 */
                     pr_default.execute(5, new Object[] {A272FeedBackSolicitudId, A273FeedBackProfesionalId, A274FeedBackClienteId, A275FeedBackNum, A271FeedBackComentario, A276FeedBackFechaAlta, A277FeedBackFechaModif, A117FeedBackId});
                     pr_default.close(5);
                     pr_default.SmartCacheProvider.SetUpdated("FeedBack");
                     if ( (pr_default.getStatus(5) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"FeedBack"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0L25( ) ;
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
            EndLevel0L25( ) ;
         }
         CloseExtendedTableCursors0L25( ) ;
      }

      protected void DeferredUpdate0L25( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate0L25( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0L25( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0L25( ) ;
            AfterConfirm0L25( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0L25( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC000L8 */
                  pr_default.execute(6, new Object[] {A117FeedBackId});
                  pr_default.close(6);
                  pr_default.SmartCacheProvider.SetUpdated("FeedBack");
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
         sMode25 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel0L25( ) ;
         Gx_mode = sMode25;
      }

      protected void OnDeleteControls0L25( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            AV13Pgmname = "FeedBack_BC";
         }
      }

      protected void EndLevel0L25( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0L25( ) ;
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

      public void ScanKeyStart0L25( )
      {
         /* Scan By routine */
         /* Using cursor BC000L9 */
         pr_default.execute(7, new Object[] {A117FeedBackId});
         RcdFound25 = 0;
         if ( (pr_default.getStatus(7) != 101) )
         {
            RcdFound25 = 1;
            A117FeedBackId = BC000L9_A117FeedBackId[0];
            A272FeedBackSolicitudId = BC000L9_A272FeedBackSolicitudId[0];
            A273FeedBackProfesionalId = BC000L9_A273FeedBackProfesionalId[0];
            A274FeedBackClienteId = BC000L9_A274FeedBackClienteId[0];
            A275FeedBackNum = BC000L9_A275FeedBackNum[0];
            A271FeedBackComentario = BC000L9_A271FeedBackComentario[0];
            A276FeedBackFechaAlta = BC000L9_A276FeedBackFechaAlta[0];
            A277FeedBackFechaModif = BC000L9_A277FeedBackFechaModif[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext0L25( )
      {
         /* Scan next routine */
         pr_default.readNext(7);
         RcdFound25 = 0;
         ScanKeyLoad0L25( ) ;
      }

      protected void ScanKeyLoad0L25( )
      {
         sMode25 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(7) != 101) )
         {
            RcdFound25 = 1;
            A117FeedBackId = BC000L9_A117FeedBackId[0];
            A272FeedBackSolicitudId = BC000L9_A272FeedBackSolicitudId[0];
            A273FeedBackProfesionalId = BC000L9_A273FeedBackProfesionalId[0];
            A274FeedBackClienteId = BC000L9_A274FeedBackClienteId[0];
            A275FeedBackNum = BC000L9_A275FeedBackNum[0];
            A271FeedBackComentario = BC000L9_A271FeedBackComentario[0];
            A276FeedBackFechaAlta = BC000L9_A276FeedBackFechaAlta[0];
            A277FeedBackFechaModif = BC000L9_A277FeedBackFechaModif[0];
         }
         Gx_mode = sMode25;
      }

      protected void ScanKeyEnd0L25( )
      {
         pr_default.close(7);
      }

      protected void AfterConfirm0L25( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0L25( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0L25( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0L25( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0L25( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0L25( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0L25( )
      {
      }

      protected void send_integrity_lvl_hashes0L25( )
      {
      }

      protected void AddRow0L25( )
      {
         VarsToRow25( bcFeedBack) ;
      }

      protected void ReadRow0L25( )
      {
         RowToVars25( bcFeedBack, 1) ;
      }

      protected void InitializeNonKey0L25( )
      {
         A272FeedBackSolicitudId = 0;
         A273FeedBackProfesionalId = "";
         A274FeedBackClienteId = 0;
         A275FeedBackNum = 0;
         A271FeedBackComentario = "";
         A276FeedBackFechaAlta = DateTime.MinValue;
         A277FeedBackFechaModif = DateTime.MinValue;
         Z272FeedBackSolicitudId = 0;
         Z273FeedBackProfesionalId = "";
         Z274FeedBackClienteId = 0;
         Z275FeedBackNum = 0;
         Z276FeedBackFechaAlta = DateTime.MinValue;
         Z277FeedBackFechaModif = DateTime.MinValue;
      }

      protected void InitAll0L25( )
      {
         A117FeedBackId = 0;
         InitializeNonKey0L25( ) ;
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

      public void VarsToRow25( SdtFeedBack obj25 )
      {
         obj25.gxTpr_Mode = Gx_mode;
         obj25.gxTpr_Feedbacksolicitudid = A272FeedBackSolicitudId;
         obj25.gxTpr_Feedbackprofesionalid = A273FeedBackProfesionalId;
         obj25.gxTpr_Feedbackclienteid = A274FeedBackClienteId;
         obj25.gxTpr_Feedbacknum = A275FeedBackNum;
         obj25.gxTpr_Feedbackcomentario = A271FeedBackComentario;
         obj25.gxTpr_Feedbackfechaalta = A276FeedBackFechaAlta;
         obj25.gxTpr_Feedbackfechamodif = A277FeedBackFechaModif;
         obj25.gxTpr_Feedbackid = A117FeedBackId;
         obj25.gxTpr_Feedbackid_Z = Z117FeedBackId;
         obj25.gxTpr_Feedbacksolicitudid_Z = Z272FeedBackSolicitudId;
         obj25.gxTpr_Feedbackprofesionalid_Z = Z273FeedBackProfesionalId;
         obj25.gxTpr_Feedbackclienteid_Z = Z274FeedBackClienteId;
         obj25.gxTpr_Feedbacknum_Z = Z275FeedBackNum;
         obj25.gxTpr_Feedbackfechaalta_Z = Z276FeedBackFechaAlta;
         obj25.gxTpr_Feedbackfechamodif_Z = Z277FeedBackFechaModif;
         obj25.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow25( SdtFeedBack obj25 )
      {
         obj25.gxTpr_Feedbackid = A117FeedBackId;
         return  ;
      }

      public void RowToVars25( SdtFeedBack obj25 ,
                               int forceLoad )
      {
         Gx_mode = obj25.gxTpr_Mode;
         A272FeedBackSolicitudId = obj25.gxTpr_Feedbacksolicitudid;
         A273FeedBackProfesionalId = obj25.gxTpr_Feedbackprofesionalid;
         A274FeedBackClienteId = obj25.gxTpr_Feedbackclienteid;
         A275FeedBackNum = obj25.gxTpr_Feedbacknum;
         A271FeedBackComentario = obj25.gxTpr_Feedbackcomentario;
         A276FeedBackFechaAlta = obj25.gxTpr_Feedbackfechaalta;
         A277FeedBackFechaModif = obj25.gxTpr_Feedbackfechamodif;
         A117FeedBackId = obj25.gxTpr_Feedbackid;
         Z117FeedBackId = obj25.gxTpr_Feedbackid_Z;
         Z272FeedBackSolicitudId = obj25.gxTpr_Feedbacksolicitudid_Z;
         Z273FeedBackProfesionalId = obj25.gxTpr_Feedbackprofesionalid_Z;
         Z274FeedBackClienteId = obj25.gxTpr_Feedbackclienteid_Z;
         Z275FeedBackNum = obj25.gxTpr_Feedbacknum_Z;
         Z276FeedBackFechaAlta = obj25.gxTpr_Feedbackfechaalta_Z;
         Z277FeedBackFechaModif = obj25.gxTpr_Feedbackfechamodif_Z;
         Gx_mode = obj25.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A117FeedBackId = (long)getParm(obj,0);
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey0L25( ) ;
         ScanKeyStart0L25( ) ;
         if ( RcdFound25 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z117FeedBackId = A117FeedBackId;
         }
         ZM0L25( -3) ;
         OnLoadActions0L25( ) ;
         AddRow0L25( ) ;
         ScanKeyEnd0L25( ) ;
         if ( RcdFound25 == 0 )
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
         RowToVars25( bcFeedBack, 0) ;
         ScanKeyStart0L25( ) ;
         if ( RcdFound25 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z117FeedBackId = A117FeedBackId;
         }
         ZM0L25( -3) ;
         OnLoadActions0L25( ) ;
         AddRow0L25( ) ;
         ScanKeyEnd0L25( ) ;
         if ( RcdFound25 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         GetKey0L25( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert0L25( ) ;
         }
         else
         {
            if ( RcdFound25 == 1 )
            {
               if ( A117FeedBackId != Z117FeedBackId )
               {
                  A117FeedBackId = Z117FeedBackId;
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
                  Update0L25( ) ;
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
                  if ( A117FeedBackId != Z117FeedBackId )
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
                        Insert0L25( ) ;
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
                        Insert0L25( ) ;
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
         RowToVars25( bcFeedBack, 1) ;
         SaveImpl( ) ;
         VarsToRow25( bcFeedBack) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public bool Insert( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars25( bcFeedBack, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert0L25( ) ;
         AfterTrn( ) ;
         VarsToRow25( bcFeedBack) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
            VarsToRow25( bcFeedBack) ;
         }
         else
         {
            SdtFeedBack auxBC = new SdtFeedBack(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A117FeedBackId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcFeedBack);
               auxBC.Save();
               bcFeedBack.Copy((GxSilentTrnSdt)(auxBC));
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
         RowToVars25( bcFeedBack, 1) ;
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
         RowToVars25( bcFeedBack, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert0L25( ) ;
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
               VarsToRow25( bcFeedBack) ;
            }
         }
         else
         {
            AfterTrn( ) ;
            VarsToRow25( bcFeedBack) ;
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
         RowToVars25( bcFeedBack, 0) ;
         GetKey0L25( ) ;
         if ( RcdFound25 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( A117FeedBackId != Z117FeedBackId )
            {
               A117FeedBackId = Z117FeedBackId;
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
            if ( A117FeedBackId != Z117FeedBackId )
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
         context.RollbackDataStores("feedback_bc",pr_default);
         VarsToRow25( bcFeedBack) ;
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
         Gx_mode = bcFeedBack.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcFeedBack.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcFeedBack )
         {
            bcFeedBack = (SdtFeedBack)(sdt);
            if ( StringUtil.StrCmp(bcFeedBack.gxTpr_Mode, "") == 0 )
            {
               bcFeedBack.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow25( bcFeedBack) ;
            }
            else
            {
               RowToVars25( bcFeedBack, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcFeedBack.gxTpr_Mode, "") == 0 )
            {
               bcFeedBack.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars25( bcFeedBack, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         return  ;
      }

      public SdtFeedBack FeedBack_BC
      {
         get {
            return bcFeedBack ;
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
         AV8WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV13Pgmname = "";
         GXKey = "";
         GXEncryptionTmp = "";
         AV11TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV12WebSession = context.GetSession();
         Z273FeedBackProfesionalId = "";
         A273FeedBackProfesionalId = "";
         Z276FeedBackFechaAlta = DateTime.MinValue;
         A276FeedBackFechaAlta = DateTime.MinValue;
         Z277FeedBackFechaModif = DateTime.MinValue;
         A277FeedBackFechaModif = DateTime.MinValue;
         Z271FeedBackComentario = "";
         A271FeedBackComentario = "";
         BC000L4_A117FeedBackId = new long[1] ;
         BC000L4_A272FeedBackSolicitudId = new long[1] ;
         BC000L4_A273FeedBackProfesionalId = new string[] {""} ;
         BC000L4_A274FeedBackClienteId = new long[1] ;
         BC000L4_A275FeedBackNum = new long[1] ;
         BC000L4_A271FeedBackComentario = new string[] {""} ;
         BC000L4_A276FeedBackFechaAlta = new DateTime[] {DateTime.MinValue} ;
         BC000L4_A277FeedBackFechaModif = new DateTime[] {DateTime.MinValue} ;
         BC000L5_A117FeedBackId = new long[1] ;
         BC000L3_A117FeedBackId = new long[1] ;
         BC000L3_A272FeedBackSolicitudId = new long[1] ;
         BC000L3_A273FeedBackProfesionalId = new string[] {""} ;
         BC000L3_A274FeedBackClienteId = new long[1] ;
         BC000L3_A275FeedBackNum = new long[1] ;
         BC000L3_A271FeedBackComentario = new string[] {""} ;
         BC000L3_A276FeedBackFechaAlta = new DateTime[] {DateTime.MinValue} ;
         BC000L3_A277FeedBackFechaModif = new DateTime[] {DateTime.MinValue} ;
         sMode25 = "";
         BC000L2_A117FeedBackId = new long[1] ;
         BC000L2_A272FeedBackSolicitudId = new long[1] ;
         BC000L2_A273FeedBackProfesionalId = new string[] {""} ;
         BC000L2_A274FeedBackClienteId = new long[1] ;
         BC000L2_A275FeedBackNum = new long[1] ;
         BC000L2_A271FeedBackComentario = new string[] {""} ;
         BC000L2_A276FeedBackFechaAlta = new DateTime[] {DateTime.MinValue} ;
         BC000L2_A277FeedBackFechaModif = new DateTime[] {DateTime.MinValue} ;
         BC000L6_A117FeedBackId = new long[1] ;
         BC000L9_A117FeedBackId = new long[1] ;
         BC000L9_A272FeedBackSolicitudId = new long[1] ;
         BC000L9_A273FeedBackProfesionalId = new string[] {""} ;
         BC000L9_A274FeedBackClienteId = new long[1] ;
         BC000L9_A275FeedBackNum = new long[1] ;
         BC000L9_A271FeedBackComentario = new string[] {""} ;
         BC000L9_A276FeedBackFechaAlta = new DateTime[] {DateTime.MinValue} ;
         BC000L9_A277FeedBackFechaModif = new DateTime[] {DateTime.MinValue} ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.feedback_bc__datastore1(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.feedback_bc__default(),
            new Object[][] {
                new Object[] {
               BC000L2_A117FeedBackId, BC000L2_A272FeedBackSolicitudId, BC000L2_A273FeedBackProfesionalId, BC000L2_A274FeedBackClienteId, BC000L2_A275FeedBackNum, BC000L2_A271FeedBackComentario, BC000L2_A276FeedBackFechaAlta, BC000L2_A277FeedBackFechaModif
               }
               , new Object[] {
               BC000L3_A117FeedBackId, BC000L3_A272FeedBackSolicitudId, BC000L3_A273FeedBackProfesionalId, BC000L3_A274FeedBackClienteId, BC000L3_A275FeedBackNum, BC000L3_A271FeedBackComentario, BC000L3_A276FeedBackFechaAlta, BC000L3_A277FeedBackFechaModif
               }
               , new Object[] {
               BC000L4_A117FeedBackId, BC000L4_A272FeedBackSolicitudId, BC000L4_A273FeedBackProfesionalId, BC000L4_A274FeedBackClienteId, BC000L4_A275FeedBackNum, BC000L4_A271FeedBackComentario, BC000L4_A276FeedBackFechaAlta, BC000L4_A277FeedBackFechaModif
               }
               , new Object[] {
               BC000L5_A117FeedBackId
               }
               , new Object[] {
               BC000L6_A117FeedBackId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC000L9_A117FeedBackId, BC000L9_A272FeedBackSolicitudId, BC000L9_A273FeedBackProfesionalId, BC000L9_A274FeedBackClienteId, BC000L9_A275FeedBackNum, BC000L9_A271FeedBackComentario, BC000L9_A276FeedBackFechaAlta, BC000L9_A277FeedBackFechaModif
               }
            }
         );
         AV13Pgmname = "FeedBack_BC";
         INITTRN();
         /* Execute Start event if defined. */
         /* Execute user event: Start */
         E120L2 ();
         standaloneNotModal( ) ;
      }

      private short AnyError ;
      private short RcdFound25 ;
      private int trnEnded ;
      private long Z117FeedBackId ;
      private long A117FeedBackId ;
      private long Z272FeedBackSolicitudId ;
      private long A272FeedBackSolicitudId ;
      private long Z274FeedBackClienteId ;
      private long A274FeedBackClienteId ;
      private long Z275FeedBackNum ;
      private long A275FeedBackNum ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string AV13Pgmname ;
      private string GXKey ;
      private string GXEncryptionTmp ;
      private string Z273FeedBackProfesionalId ;
      private string A273FeedBackProfesionalId ;
      private string sMode25 ;
      private DateTime Z276FeedBackFechaAlta ;
      private DateTime A276FeedBackFechaAlta ;
      private DateTime Z277FeedBackFechaModif ;
      private DateTime A277FeedBackFechaModif ;
      private bool returnInSub ;
      private bool AV9IsAuthorized ;
      private bool GXt_boolean1 ;
      private bool Gx_longc ;
      private string Z271FeedBackComentario ;
      private string A271FeedBackComentario ;
      private IGxSession AV12WebSession ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV11TrnContext ;
      private IDataStoreProvider pr_default ;
      private long[] BC000L4_A117FeedBackId ;
      private long[] BC000L4_A272FeedBackSolicitudId ;
      private string[] BC000L4_A273FeedBackProfesionalId ;
      private long[] BC000L4_A274FeedBackClienteId ;
      private long[] BC000L4_A275FeedBackNum ;
      private string[] BC000L4_A271FeedBackComentario ;
      private DateTime[] BC000L4_A276FeedBackFechaAlta ;
      private DateTime[] BC000L4_A277FeedBackFechaModif ;
      private long[] BC000L5_A117FeedBackId ;
      private long[] BC000L3_A117FeedBackId ;
      private long[] BC000L3_A272FeedBackSolicitudId ;
      private string[] BC000L3_A273FeedBackProfesionalId ;
      private long[] BC000L3_A274FeedBackClienteId ;
      private long[] BC000L3_A275FeedBackNum ;
      private string[] BC000L3_A271FeedBackComentario ;
      private DateTime[] BC000L3_A276FeedBackFechaAlta ;
      private DateTime[] BC000L3_A277FeedBackFechaModif ;
      private long[] BC000L2_A117FeedBackId ;
      private long[] BC000L2_A272FeedBackSolicitudId ;
      private string[] BC000L2_A273FeedBackProfesionalId ;
      private long[] BC000L2_A274FeedBackClienteId ;
      private long[] BC000L2_A275FeedBackNum ;
      private string[] BC000L2_A271FeedBackComentario ;
      private DateTime[] BC000L2_A276FeedBackFechaAlta ;
      private DateTime[] BC000L2_A277FeedBackFechaModif ;
      private long[] BC000L6_A117FeedBackId ;
      private long[] BC000L9_A117FeedBackId ;
      private long[] BC000L9_A272FeedBackSolicitudId ;
      private string[] BC000L9_A273FeedBackProfesionalId ;
      private long[] BC000L9_A274FeedBackClienteId ;
      private long[] BC000L9_A275FeedBackNum ;
      private string[] BC000L9_A271FeedBackComentario ;
      private DateTime[] BC000L9_A276FeedBackFechaAlta ;
      private DateTime[] BC000L9_A277FeedBackFechaModif ;
      private SdtFeedBack bcFeedBack ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_datastore1 ;
   }

   public class feedback_bc__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class feedback_bc__default : DataStoreHelperBase, IDataStoreHelper
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
       ,new ForEachCursor(def[7])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmBC000L2;
        prmBC000L2 = new Object[] {
        new ParDef("@FeedBackId",GXType.Decimal,18,0)
        };
        Object[] prmBC000L3;
        prmBC000L3 = new Object[] {
        new ParDef("@FeedBackId",GXType.Decimal,18,0)
        };
        Object[] prmBC000L4;
        prmBC000L4 = new Object[] {
        new ParDef("@FeedBackId",GXType.Decimal,18,0)
        };
        Object[] prmBC000L5;
        prmBC000L5 = new Object[] {
        new ParDef("@FeedBackId",GXType.Decimal,18,0)
        };
        Object[] prmBC000L6;
        prmBC000L6 = new Object[] {
        new ParDef("@FeedBackSolicitudId",GXType.Decimal,18,0) ,
        new ParDef("@FeedBackProfesionalId",GXType.NChar,20,0) ,
        new ParDef("@FeedBackClienteId",GXType.Decimal,18,0) ,
        new ParDef("@FeedBackNum",GXType.Decimal,10,0) ,
        new ParDef("@FeedBackComentario",GXType.NVarChar,2097152,0) ,
        new ParDef("@FeedBackFechaAlta",GXType.Date,8,0) ,
        new ParDef("@FeedBackFechaModif",GXType.Date,8,0)
        };
        Object[] prmBC000L7;
        prmBC000L7 = new Object[] {
        new ParDef("@FeedBackSolicitudId",GXType.Decimal,18,0) ,
        new ParDef("@FeedBackProfesionalId",GXType.NChar,20,0) ,
        new ParDef("@FeedBackClienteId",GXType.Decimal,18,0) ,
        new ParDef("@FeedBackNum",GXType.Decimal,10,0) ,
        new ParDef("@FeedBackComentario",GXType.NVarChar,2097152,0) ,
        new ParDef("@FeedBackFechaAlta",GXType.Date,8,0) ,
        new ParDef("@FeedBackFechaModif",GXType.Date,8,0) ,
        new ParDef("@FeedBackId",GXType.Decimal,18,0)
        };
        Object[] prmBC000L8;
        prmBC000L8 = new Object[] {
        new ParDef("@FeedBackId",GXType.Decimal,18,0)
        };
        Object[] prmBC000L9;
        prmBC000L9 = new Object[] {
        new ParDef("@FeedBackId",GXType.Decimal,18,0)
        };
        def= new CursorDef[] {
            new CursorDef("BC000L2", "SELECT [FeedBackId], [FeedBackSolicitudId], [FeedBackProfesionalId], [FeedBackClienteId], [FeedBackNum], [FeedBackComentario], [FeedBackFechaAlta], [FeedBackFechaModif] FROM [FeedBack] WITH (UPDLOCK) WHERE [FeedBackId] = @FeedBackId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000L2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000L3", "SELECT [FeedBackId], [FeedBackSolicitudId], [FeedBackProfesionalId], [FeedBackClienteId], [FeedBackNum], [FeedBackComentario], [FeedBackFechaAlta], [FeedBackFechaModif] FROM [FeedBack] WHERE [FeedBackId] = @FeedBackId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000L3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000L4", "SELECT TM1.[FeedBackId], TM1.[FeedBackSolicitudId], TM1.[FeedBackProfesionalId], TM1.[FeedBackClienteId], TM1.[FeedBackNum], TM1.[FeedBackComentario], TM1.[FeedBackFechaAlta], TM1.[FeedBackFechaModif] FROM [FeedBack] TM1 WHERE TM1.[FeedBackId] = @FeedBackId ORDER BY TM1.[FeedBackId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmBC000L4,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000L5", "SELECT [FeedBackId] FROM [FeedBack] WHERE [FeedBackId] = @FeedBackId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmBC000L5,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000L6", "INSERT INTO [FeedBack]([FeedBackSolicitudId], [FeedBackProfesionalId], [FeedBackClienteId], [FeedBackNum], [FeedBackComentario], [FeedBackFechaAlta], [FeedBackFechaModif]) VALUES(@FeedBackSolicitudId, @FeedBackProfesionalId, @FeedBackClienteId, @FeedBackNum, @FeedBackComentario, @FeedBackFechaAlta, @FeedBackFechaModif); SELECT SCOPE_IDENTITY()",true, GxErrorMask.GX_NOMASK, false, this,prmBC000L6,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("BC000L7", "UPDATE [FeedBack] SET [FeedBackSolicitudId]=@FeedBackSolicitudId, [FeedBackProfesionalId]=@FeedBackProfesionalId, [FeedBackClienteId]=@FeedBackClienteId, [FeedBackNum]=@FeedBackNum, [FeedBackComentario]=@FeedBackComentario, [FeedBackFechaAlta]=@FeedBackFechaAlta, [FeedBackFechaModif]=@FeedBackFechaModif  WHERE [FeedBackId] = @FeedBackId", GxErrorMask.GX_NOMASK,prmBC000L7)
           ,new CursorDef("BC000L8", "DELETE FROM [FeedBack]  WHERE [FeedBackId] = @FeedBackId", GxErrorMask.GX_NOMASK,prmBC000L8)
           ,new CursorDef("BC000L9", "SELECT TM1.[FeedBackId], TM1.[FeedBackSolicitudId], TM1.[FeedBackProfesionalId], TM1.[FeedBackClienteId], TM1.[FeedBackNum], TM1.[FeedBackComentario], TM1.[FeedBackFechaAlta], TM1.[FeedBackFechaModif] FROM [FeedBack] TM1 WHERE TM1.[FeedBackId] = @FeedBackId ORDER BY TM1.[FeedBackId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmBC000L9,100, GxCacheFrequency.OFF ,true,false )
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
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              ((string[]) buf[2])[0] = rslt.getString(3, 20);
              ((long[]) buf[3])[0] = rslt.getLong(4);
              ((long[]) buf[4])[0] = rslt.getLong(5);
              ((string[]) buf[5])[0] = rslt.getLongVarchar(6);
              ((DateTime[]) buf[6])[0] = rslt.getGXDate(7);
              ((DateTime[]) buf[7])[0] = rslt.getGXDate(8);
              return;
           case 1 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              ((string[]) buf[2])[0] = rslt.getString(3, 20);
              ((long[]) buf[3])[0] = rslt.getLong(4);
              ((long[]) buf[4])[0] = rslt.getLong(5);
              ((string[]) buf[5])[0] = rslt.getLongVarchar(6);
              ((DateTime[]) buf[6])[0] = rslt.getGXDate(7);
              ((DateTime[]) buf[7])[0] = rslt.getGXDate(8);
              return;
           case 2 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              ((string[]) buf[2])[0] = rslt.getString(3, 20);
              ((long[]) buf[3])[0] = rslt.getLong(4);
              ((long[]) buf[4])[0] = rslt.getLong(5);
              ((string[]) buf[5])[0] = rslt.getLongVarchar(6);
              ((DateTime[]) buf[6])[0] = rslt.getGXDate(7);
              ((DateTime[]) buf[7])[0] = rslt.getGXDate(8);
              return;
           case 3 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 4 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 7 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              ((string[]) buf[2])[0] = rslt.getString(3, 20);
              ((long[]) buf[3])[0] = rslt.getLong(4);
              ((long[]) buf[4])[0] = rslt.getLong(5);
              ((string[]) buf[5])[0] = rslt.getLongVarchar(6);
              ((DateTime[]) buf[6])[0] = rslt.getGXDate(7);
              ((DateTime[]) buf[7])[0] = rslt.getGXDate(8);
              return;
     }
  }

}

}

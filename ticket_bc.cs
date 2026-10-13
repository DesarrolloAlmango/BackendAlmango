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
   public class ticket_bc : GXHttpHandler, IGxSilentTrn
   {
      public ticket_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public ticket_bc( IGxContext context )
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
         ReadRow31148( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey31148( ) ;
         standaloneModal( ) ;
         AddRow31148( ) ;
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
               Z1020TicketId = A1020TicketId;
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

      protected void CONFIRM_310( )
      {
         BeforeValidate31148( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls31148( ) ;
            }
            else
            {
               CheckExtendedTable31148( ) ;
               if ( AnyError == 0 )
               {
                  ZM31148( 2) ;
               }
               CloseExtendedTableCursors31148( ) ;
            }
         }
         if ( AnyError == 0 )
         {
         }
      }

      protected void ZM31148( short GX_JID )
      {
         if ( ( GX_JID == 1 ) || ( GX_JID == 0 ) )
         {
            Z1023TicketSolicitudId = A1023TicketSolicitudId;
            Z1030TicketEstado = A1030TicketEstado;
            Z1024TicketComentario = A1024TicketComentario;
            Z1026TicketAdjunto = A1026TicketAdjunto;
            Z1021TicketMotivoId = A1021TicketMotivoId;
         }
         if ( ( GX_JID == 2 ) || ( GX_JID == 0 ) )
         {
            Z1022TicketMotivoDescripcion = A1022TicketMotivoDescripcion;
         }
         if ( GX_JID == -1 )
         {
            Z1020TicketId = A1020TicketId;
            Z1023TicketSolicitudId = A1023TicketSolicitudId;
            Z1030TicketEstado = A1030TicketEstado;
            Z1024TicketComentario = A1024TicketComentario;
            Z1026TicketAdjunto = A1026TicketAdjunto;
            Z1021TicketMotivoId = A1021TicketMotivoId;
            Z1022TicketMotivoDescripcion = A1022TicketMotivoDescripcion;
         }
      }

      protected void standaloneNotModal( )
      {
      }

      protected void standaloneModal( )
      {
      }

      protected void Load31148( )
      {
         /* Using cursor BC00315 */
         pr_default.execute(3, new Object[] {n1020TicketId, A1020TicketId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound148 = 1;
            A1023TicketSolicitudId = BC00315_A1023TicketSolicitudId[0];
            A1022TicketMotivoDescripcion = BC00315_A1022TicketMotivoDescripcion[0];
            A1030TicketEstado = BC00315_A1030TicketEstado[0];
            A1024TicketComentario = BC00315_A1024TicketComentario[0];
            A1026TicketAdjunto = BC00315_A1026TicketAdjunto[0];
            A1021TicketMotivoId = BC00315_A1021TicketMotivoId[0];
            ZM31148( -1) ;
         }
         pr_default.close(3);
         OnLoadActions31148( ) ;
      }

      protected void OnLoadActions31148( )
      {
      }

      protected void CheckExtendedTable31148( )
      {
         standaloneModal( ) ;
         /* Using cursor BC00314 */
         pr_default.execute(2, new Object[] {A1021TicketMotivoId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Ticket Motivo", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "TICKETMOTIVOID");
            AnyError = 1;
         }
         A1022TicketMotivoDescripcion = BC00314_A1022TicketMotivoDescripcion[0];
         pr_default.close(2);
      }

      protected void CloseExtendedTableCursors31148( )
      {
         pr_default.close(2);
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey31148( )
      {
         /* Using cursor BC00316 */
         pr_default.execute(4, new Object[] {n1020TicketId, A1020TicketId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            RcdFound148 = 1;
         }
         else
         {
            RcdFound148 = 0;
         }
         pr_default.close(4);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC00313 */
         pr_default.execute(1, new Object[] {n1020TicketId, A1020TicketId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM31148( 1) ;
            RcdFound148 = 1;
            A1020TicketId = BC00313_A1020TicketId[0];
            n1020TicketId = BC00313_n1020TicketId[0];
            A1023TicketSolicitudId = BC00313_A1023TicketSolicitudId[0];
            A1030TicketEstado = BC00313_A1030TicketEstado[0];
            A1024TicketComentario = BC00313_A1024TicketComentario[0];
            A1026TicketAdjunto = BC00313_A1026TicketAdjunto[0];
            A1021TicketMotivoId = BC00313_A1021TicketMotivoId[0];
            Z1020TicketId = A1020TicketId;
            sMode148 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load31148( ) ;
            if ( AnyError == 1 )
            {
               RcdFound148 = 0;
               InitializeNonKey31148( ) ;
            }
            Gx_mode = sMode148;
         }
         else
         {
            RcdFound148 = 0;
            InitializeNonKey31148( ) ;
            sMode148 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode148;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey31148( ) ;
         if ( RcdFound148 == 0 )
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
         CONFIRM_310( ) ;
      }

      protected void update_Check( )
      {
         insert_Check( ) ;
      }

      protected void delete_Check( )
      {
         insert_Check( ) ;
      }

      protected void CheckOptimisticConcurrency31148( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC00312 */
            pr_default.execute(0, new Object[] {n1020TicketId, A1020TicketId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Ticket"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( Z1023TicketSolicitudId != BC00312_A1023TicketSolicitudId[0] ) || ( Z1030TicketEstado != BC00312_A1030TicketEstado[0] ) || ( StringUtil.StrCmp(Z1024TicketComentario, BC00312_A1024TicketComentario[0]) != 0 ) || ( StringUtil.StrCmp(Z1026TicketAdjunto, BC00312_A1026TicketAdjunto[0]) != 0 ) || ( Z1021TicketMotivoId != BC00312_A1021TicketMotivoId[0] ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Ticket"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert31148( )
      {
         BeforeValidate31148( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable31148( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM31148( 0) ;
            CheckOptimisticConcurrency31148( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm31148( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert31148( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC00317 */
                     pr_default.execute(5, new Object[] {A1023TicketSolicitudId, A1030TicketEstado, A1024TicketComentario, A1026TicketAdjunto, A1021TicketMotivoId});
                     A1020TicketId = BC00317_A1020TicketId[0];
                     n1020TicketId = BC00317_n1020TicketId[0];
                     pr_default.close(5);
                     pr_default.SmartCacheProvider.SetUpdated("Ticket");
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
               Load31148( ) ;
            }
            EndLevel31148( ) ;
         }
         CloseExtendedTableCursors31148( ) ;
      }

      protected void Update31148( )
      {
         BeforeValidate31148( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable31148( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency31148( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm31148( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate31148( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC00318 */
                     pr_default.execute(6, new Object[] {A1023TicketSolicitudId, A1030TicketEstado, A1024TicketComentario, A1026TicketAdjunto, A1021TicketMotivoId, n1020TicketId, A1020TicketId});
                     pr_default.close(6);
                     pr_default.SmartCacheProvider.SetUpdated("Ticket");
                     if ( (pr_default.getStatus(6) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Ticket"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate31148( ) ;
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
            EndLevel31148( ) ;
         }
         CloseExtendedTableCursors31148( ) ;
      }

      protected void DeferredUpdate31148( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate31148( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency31148( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls31148( ) ;
            AfterConfirm31148( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete31148( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC00319 */
                  pr_default.execute(7, new Object[] {n1020TicketId, A1020TicketId});
                  pr_default.close(7);
                  pr_default.SmartCacheProvider.SetUpdated("Ticket");
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
         sMode148 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel31148( ) ;
         Gx_mode = sMode148;
      }

      protected void OnDeleteControls31148( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor BC003110 */
            pr_default.execute(8, new Object[] {A1021TicketMotivoId});
            A1022TicketMotivoDescripcion = BC003110_A1022TicketMotivoDescripcion[0];
            pr_default.close(8);
         }
         if ( AnyError == 0 )
         {
            /* Using cursor BC003111 */
            pr_default.execute(9, new Object[] {n1020TicketId, A1020TicketId});
            if ( (pr_default.getStatus(9) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "Registro de Solicitudes", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(9);
         }
      }

      protected void EndLevel31148( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete31148( ) ;
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

      public void ScanKeyStart31148( )
      {
         /* Using cursor BC003112 */
         pr_default.execute(10, new Object[] {n1020TicketId, A1020TicketId});
         RcdFound148 = 0;
         if ( (pr_default.getStatus(10) != 101) )
         {
            RcdFound148 = 1;
            A1020TicketId = BC003112_A1020TicketId[0];
            n1020TicketId = BC003112_n1020TicketId[0];
            A1023TicketSolicitudId = BC003112_A1023TicketSolicitudId[0];
            A1022TicketMotivoDescripcion = BC003112_A1022TicketMotivoDescripcion[0];
            A1030TicketEstado = BC003112_A1030TicketEstado[0];
            A1024TicketComentario = BC003112_A1024TicketComentario[0];
            A1026TicketAdjunto = BC003112_A1026TicketAdjunto[0];
            A1021TicketMotivoId = BC003112_A1021TicketMotivoId[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext31148( )
      {
         /* Scan next routine */
         pr_default.readNext(10);
         RcdFound148 = 0;
         ScanKeyLoad31148( ) ;
      }

      protected void ScanKeyLoad31148( )
      {
         sMode148 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(10) != 101) )
         {
            RcdFound148 = 1;
            A1020TicketId = BC003112_A1020TicketId[0];
            n1020TicketId = BC003112_n1020TicketId[0];
            A1023TicketSolicitudId = BC003112_A1023TicketSolicitudId[0];
            A1022TicketMotivoDescripcion = BC003112_A1022TicketMotivoDescripcion[0];
            A1030TicketEstado = BC003112_A1030TicketEstado[0];
            A1024TicketComentario = BC003112_A1024TicketComentario[0];
            A1026TicketAdjunto = BC003112_A1026TicketAdjunto[0];
            A1021TicketMotivoId = BC003112_A1021TicketMotivoId[0];
         }
         Gx_mode = sMode148;
      }

      protected void ScanKeyEnd31148( )
      {
         pr_default.close(10);
      }

      protected void AfterConfirm31148( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert31148( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate31148( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete31148( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete31148( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate31148( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes31148( )
      {
      }

      protected void send_integrity_lvl_hashes31148( )
      {
      }

      protected void AddRow31148( )
      {
         VarsToRow148( bcTicket) ;
      }

      protected void ReadRow31148( )
      {
         RowToVars148( bcTicket, 1) ;
      }

      protected void InitializeNonKey31148( )
      {
         A1023TicketSolicitudId = 0;
         A1021TicketMotivoId = 0;
         A1022TicketMotivoDescripcion = "";
         A1030TicketEstado = false;
         A1024TicketComentario = "";
         A1026TicketAdjunto = "";
         Z1023TicketSolicitudId = 0;
         Z1030TicketEstado = false;
         Z1024TicketComentario = "";
         Z1026TicketAdjunto = "";
         Z1021TicketMotivoId = 0;
      }

      protected void InitAll31148( )
      {
         A1020TicketId = 0;
         n1020TicketId = false;
         InitializeNonKey31148( ) ;
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

      public void VarsToRow148( SdtTicket obj148 )
      {
         obj148.gxTpr_Mode = Gx_mode;
         obj148.gxTpr_Ticketsolicitudid = A1023TicketSolicitudId;
         obj148.gxTpr_Ticketmotivoid = A1021TicketMotivoId;
         obj148.gxTpr_Ticketmotivodescripcion = A1022TicketMotivoDescripcion;
         obj148.gxTpr_Ticketestado = A1030TicketEstado;
         obj148.gxTpr_Ticketcomentario = A1024TicketComentario;
         obj148.gxTpr_Ticketadjunto = A1026TicketAdjunto;
         obj148.gxTpr_Ticketid = A1020TicketId;
         obj148.gxTpr_Ticketid_Z = Z1020TicketId;
         obj148.gxTpr_Ticketsolicitudid_Z = Z1023TicketSolicitudId;
         obj148.gxTpr_Ticketmotivoid_Z = Z1021TicketMotivoId;
         obj148.gxTpr_Ticketmotivodescripcion_Z = Z1022TicketMotivoDescripcion;
         obj148.gxTpr_Ticketestado_Z = Z1030TicketEstado;
         obj148.gxTpr_Ticketcomentario_Z = Z1024TicketComentario;
         obj148.gxTpr_Ticketadjunto_Z = Z1026TicketAdjunto;
         obj148.gxTpr_Ticketid_N = (short)(Convert.ToInt16(n1020TicketId));
         obj148.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow148( SdtTicket obj148 )
      {
         obj148.gxTpr_Ticketid = A1020TicketId;
         return  ;
      }

      public void RowToVars148( SdtTicket obj148 ,
                                int forceLoad )
      {
         Gx_mode = obj148.gxTpr_Mode;
         A1023TicketSolicitudId = obj148.gxTpr_Ticketsolicitudid;
         A1021TicketMotivoId = obj148.gxTpr_Ticketmotivoid;
         A1022TicketMotivoDescripcion = obj148.gxTpr_Ticketmotivodescripcion;
         A1030TicketEstado = obj148.gxTpr_Ticketestado;
         A1024TicketComentario = obj148.gxTpr_Ticketcomentario;
         A1026TicketAdjunto = obj148.gxTpr_Ticketadjunto;
         A1020TicketId = obj148.gxTpr_Ticketid;
         n1020TicketId = false;
         Z1020TicketId = obj148.gxTpr_Ticketid_Z;
         Z1023TicketSolicitudId = obj148.gxTpr_Ticketsolicitudid_Z;
         Z1021TicketMotivoId = obj148.gxTpr_Ticketmotivoid_Z;
         Z1022TicketMotivoDescripcion = obj148.gxTpr_Ticketmotivodescripcion_Z;
         Z1030TicketEstado = obj148.gxTpr_Ticketestado_Z;
         Z1024TicketComentario = obj148.gxTpr_Ticketcomentario_Z;
         Z1026TicketAdjunto = obj148.gxTpr_Ticketadjunto_Z;
         n1020TicketId = (bool)(Convert.ToBoolean(obj148.gxTpr_Ticketid_N));
         Gx_mode = obj148.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A1020TicketId = (long)getParm(obj,0);
         n1020TicketId = false;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey31148( ) ;
         ScanKeyStart31148( ) ;
         if ( RcdFound148 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z1020TicketId = A1020TicketId;
         }
         ZM31148( -1) ;
         OnLoadActions31148( ) ;
         AddRow31148( ) ;
         ScanKeyEnd31148( ) ;
         if ( RcdFound148 == 0 )
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
         RowToVars148( bcTicket, 0) ;
         ScanKeyStart31148( ) ;
         if ( RcdFound148 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z1020TicketId = A1020TicketId;
         }
         ZM31148( -1) ;
         OnLoadActions31148( ) ;
         AddRow31148( ) ;
         ScanKeyEnd31148( ) ;
         if ( RcdFound148 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         GetKey31148( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert31148( ) ;
         }
         else
         {
            if ( RcdFound148 == 1 )
            {
               if ( A1020TicketId != Z1020TicketId )
               {
                  A1020TicketId = Z1020TicketId;
                  n1020TicketId = false;
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
                  Update31148( ) ;
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
                  if ( A1020TicketId != Z1020TicketId )
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
                        Insert31148( ) ;
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
                        Insert31148( ) ;
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
         RowToVars148( bcTicket, 1) ;
         SaveImpl( ) ;
         VarsToRow148( bcTicket) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public bool Insert( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars148( bcTicket, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert31148( ) ;
         AfterTrn( ) ;
         VarsToRow148( bcTicket) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
            VarsToRow148( bcTicket) ;
         }
         else
         {
            SdtTicket auxBC = new SdtTicket(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A1020TicketId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcTicket);
               auxBC.Save();
               bcTicket.Copy((GxSilentTrnSdt)(auxBC));
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
         RowToVars148( bcTicket, 1) ;
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
         RowToVars148( bcTicket, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert31148( ) ;
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
               VarsToRow148( bcTicket) ;
            }
         }
         else
         {
            AfterTrn( ) ;
            VarsToRow148( bcTicket) ;
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
         RowToVars148( bcTicket, 0) ;
         GetKey31148( ) ;
         if ( RcdFound148 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( A1020TicketId != Z1020TicketId )
            {
               A1020TicketId = Z1020TicketId;
               n1020TicketId = false;
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
            if ( A1020TicketId != Z1020TicketId )
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
         pr_default.close(8);
         context.RollbackDataStores("ticket_bc",pr_default);
         VarsToRow148( bcTicket) ;
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
         Gx_mode = bcTicket.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcTicket.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcTicket )
         {
            bcTicket = (SdtTicket)(sdt);
            if ( StringUtil.StrCmp(bcTicket.gxTpr_Mode, "") == 0 )
            {
               bcTicket.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow148( bcTicket) ;
            }
            else
            {
               RowToVars148( bcTicket, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcTicket.gxTpr_Mode, "") == 0 )
            {
               bcTicket.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars148( bcTicket, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         return  ;
      }

      public SdtTicket Ticket_BC
      {
         get {
            return bcTicket ;
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
         pr_default.close(8);
      }

      public override void initialize( )
      {
         Gx_mode = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         Z1024TicketComentario = "";
         A1024TicketComentario = "";
         Z1026TicketAdjunto = "";
         A1026TicketAdjunto = "";
         Z1022TicketMotivoDescripcion = "";
         A1022TicketMotivoDescripcion = "";
         BC00315_A1020TicketId = new long[1] ;
         BC00315_n1020TicketId = new bool[] {false} ;
         BC00315_A1023TicketSolicitudId = new long[1] ;
         BC00315_A1022TicketMotivoDescripcion = new string[] {""} ;
         BC00315_A1030TicketEstado = new bool[] {false} ;
         BC00315_A1024TicketComentario = new string[] {""} ;
         BC00315_A1026TicketAdjunto = new string[] {""} ;
         BC00315_A1021TicketMotivoId = new long[1] ;
         BC00314_A1022TicketMotivoDescripcion = new string[] {""} ;
         BC00316_A1020TicketId = new long[1] ;
         BC00316_n1020TicketId = new bool[] {false} ;
         BC00313_A1020TicketId = new long[1] ;
         BC00313_n1020TicketId = new bool[] {false} ;
         BC00313_A1023TicketSolicitudId = new long[1] ;
         BC00313_A1030TicketEstado = new bool[] {false} ;
         BC00313_A1024TicketComentario = new string[] {""} ;
         BC00313_A1026TicketAdjunto = new string[] {""} ;
         BC00313_A1021TicketMotivoId = new long[1] ;
         sMode148 = "";
         BC00312_A1020TicketId = new long[1] ;
         BC00312_n1020TicketId = new bool[] {false} ;
         BC00312_A1023TicketSolicitudId = new long[1] ;
         BC00312_A1030TicketEstado = new bool[] {false} ;
         BC00312_A1024TicketComentario = new string[] {""} ;
         BC00312_A1026TicketAdjunto = new string[] {""} ;
         BC00312_A1021TicketMotivoId = new long[1] ;
         BC00317_A1020TicketId = new long[1] ;
         BC00317_n1020TicketId = new bool[] {false} ;
         BC003110_A1022TicketMotivoDescripcion = new string[] {""} ;
         BC003111_A127SolicitudesID = new long[1] ;
         BC003112_A1020TicketId = new long[1] ;
         BC003112_n1020TicketId = new bool[] {false} ;
         BC003112_A1023TicketSolicitudId = new long[1] ;
         BC003112_A1022TicketMotivoDescripcion = new string[] {""} ;
         BC003112_A1030TicketEstado = new bool[] {false} ;
         BC003112_A1024TicketComentario = new string[] {""} ;
         BC003112_A1026TicketAdjunto = new string[] {""} ;
         BC003112_A1021TicketMotivoId = new long[1] ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.ticket_bc__datastore1(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.ticket_bc__default(),
            new Object[][] {
                new Object[] {
               BC00312_A1020TicketId, BC00312_A1023TicketSolicitudId, BC00312_A1030TicketEstado, BC00312_A1024TicketComentario, BC00312_A1026TicketAdjunto, BC00312_A1021TicketMotivoId
               }
               , new Object[] {
               BC00313_A1020TicketId, BC00313_A1023TicketSolicitudId, BC00313_A1030TicketEstado, BC00313_A1024TicketComentario, BC00313_A1026TicketAdjunto, BC00313_A1021TicketMotivoId
               }
               , new Object[] {
               BC00314_A1022TicketMotivoDescripcion
               }
               , new Object[] {
               BC00315_A1020TicketId, BC00315_A1023TicketSolicitudId, BC00315_A1022TicketMotivoDescripcion, BC00315_A1030TicketEstado, BC00315_A1024TicketComentario, BC00315_A1026TicketAdjunto, BC00315_A1021TicketMotivoId
               }
               , new Object[] {
               BC00316_A1020TicketId
               }
               , new Object[] {
               BC00317_A1020TicketId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC003110_A1022TicketMotivoDescripcion
               }
               , new Object[] {
               BC003111_A127SolicitudesID
               }
               , new Object[] {
               BC003112_A1020TicketId, BC003112_A1023TicketSolicitudId, BC003112_A1022TicketMotivoDescripcion, BC003112_A1030TicketEstado, BC003112_A1024TicketComentario, BC003112_A1026TicketAdjunto, BC003112_A1021TicketMotivoId
               }
            }
         );
         INITTRN();
         /* Execute Start event if defined. */
         standaloneNotModal( ) ;
      }

      private short AnyError ;
      private short RcdFound148 ;
      private int trnEnded ;
      private long Z1020TicketId ;
      private long A1020TicketId ;
      private long Z1023TicketSolicitudId ;
      private long A1023TicketSolicitudId ;
      private long Z1021TicketMotivoId ;
      private long A1021TicketMotivoId ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string Z1024TicketComentario ;
      private string A1024TicketComentario ;
      private string Z1026TicketAdjunto ;
      private string A1026TicketAdjunto ;
      private string Z1022TicketMotivoDescripcion ;
      private string A1022TicketMotivoDescripcion ;
      private string sMode148 ;
      private bool Z1030TicketEstado ;
      private bool A1030TicketEstado ;
      private bool n1020TicketId ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private long[] BC00315_A1020TicketId ;
      private bool[] BC00315_n1020TicketId ;
      private long[] BC00315_A1023TicketSolicitudId ;
      private string[] BC00315_A1022TicketMotivoDescripcion ;
      private bool[] BC00315_A1030TicketEstado ;
      private string[] BC00315_A1024TicketComentario ;
      private string[] BC00315_A1026TicketAdjunto ;
      private long[] BC00315_A1021TicketMotivoId ;
      private string[] BC00314_A1022TicketMotivoDescripcion ;
      private long[] BC00316_A1020TicketId ;
      private bool[] BC00316_n1020TicketId ;
      private long[] BC00313_A1020TicketId ;
      private bool[] BC00313_n1020TicketId ;
      private long[] BC00313_A1023TicketSolicitudId ;
      private bool[] BC00313_A1030TicketEstado ;
      private string[] BC00313_A1024TicketComentario ;
      private string[] BC00313_A1026TicketAdjunto ;
      private long[] BC00313_A1021TicketMotivoId ;
      private long[] BC00312_A1020TicketId ;
      private bool[] BC00312_n1020TicketId ;
      private long[] BC00312_A1023TicketSolicitudId ;
      private bool[] BC00312_A1030TicketEstado ;
      private string[] BC00312_A1024TicketComentario ;
      private string[] BC00312_A1026TicketAdjunto ;
      private long[] BC00312_A1021TicketMotivoId ;
      private long[] BC00317_A1020TicketId ;
      private bool[] BC00317_n1020TicketId ;
      private string[] BC003110_A1022TicketMotivoDescripcion ;
      private long[] BC003111_A127SolicitudesID ;
      private long[] BC003112_A1020TicketId ;
      private bool[] BC003112_n1020TicketId ;
      private long[] BC003112_A1023TicketSolicitudId ;
      private string[] BC003112_A1022TicketMotivoDescripcion ;
      private bool[] BC003112_A1030TicketEstado ;
      private string[] BC003112_A1024TicketComentario ;
      private string[] BC003112_A1026TicketAdjunto ;
      private long[] BC003112_A1021TicketMotivoId ;
      private SdtTicket bcTicket ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_datastore1 ;
   }

   public class ticket_bc__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class ticket_bc__default : DataStoreHelperBase, IDataStoreHelper
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
       ,new ForEachCursor(def[5])
       ,new UpdateCursor(def[6])
       ,new UpdateCursor(def[7])
       ,new ForEachCursor(def[8])
       ,new ForEachCursor(def[9])
       ,new ForEachCursor(def[10])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmBC00312;
        prmBC00312 = new Object[] {
        new ParDef("@TicketId",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmBC00313;
        prmBC00313 = new Object[] {
        new ParDef("@TicketId",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmBC00314;
        prmBC00314 = new Object[] {
        new ParDef("@TicketMotivoId",GXType.Decimal,18,0)
        };
        Object[] prmBC00315;
        prmBC00315 = new Object[] {
        new ParDef("@TicketId",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmBC00316;
        prmBC00316 = new Object[] {
        new ParDef("@TicketId",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmBC00317;
        prmBC00317 = new Object[] {
        new ParDef("@TicketSolicitudId",GXType.Decimal,18,0) ,
        new ParDef("@TicketEstado",GXType.Boolean,40,0) ,
        new ParDef("@TicketComentario",GXType.NChar,250,0) ,
        new ParDef("@TicketAdjunto",GXType.NChar,250,0) ,
        new ParDef("@TicketMotivoId",GXType.Decimal,18,0)
        };
        Object[] prmBC00318;
        prmBC00318 = new Object[] {
        new ParDef("@TicketSolicitudId",GXType.Decimal,18,0) ,
        new ParDef("@TicketEstado",GXType.Boolean,40,0) ,
        new ParDef("@TicketComentario",GXType.NChar,250,0) ,
        new ParDef("@TicketAdjunto",GXType.NChar,250,0) ,
        new ParDef("@TicketMotivoId",GXType.Decimal,18,0) ,
        new ParDef("@TicketId",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmBC00319;
        prmBC00319 = new Object[] {
        new ParDef("@TicketId",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmBC003110;
        prmBC003110 = new Object[] {
        new ParDef("@TicketMotivoId",GXType.Decimal,18,0)
        };
        Object[] prmBC003111;
        prmBC003111 = new Object[] {
        new ParDef("@TicketId",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmBC003112;
        prmBC003112 = new Object[] {
        new ParDef("@TicketId",GXType.Decimal,18,0){Nullable=true}
        };
        def= new CursorDef[] {
            new CursorDef("BC00312", "SELECT [TicketId], [TicketSolicitudId], [TicketEstado], [TicketComentario], [TicketAdjunto], [TicketMotivoId] FROM [Ticket] WITH (UPDLOCK) WHERE [TicketId] = @TicketId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00312,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00313", "SELECT [TicketId], [TicketSolicitudId], [TicketEstado], [TicketComentario], [TicketAdjunto], [TicketMotivoId] FROM [Ticket] WHERE [TicketId] = @TicketId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00313,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00314", "SELECT [TicketMotivoDescripcion] FROM [TicketMotivo] WHERE [TicketMotivoId] = @TicketMotivoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00314,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00315", "SELECT TM1.[TicketId], TM1.[TicketSolicitudId], T2.[TicketMotivoDescripcion], TM1.[TicketEstado], TM1.[TicketComentario], TM1.[TicketAdjunto], TM1.[TicketMotivoId] FROM ([Ticket] TM1 INNER JOIN [TicketMotivo] T2 ON T2.[TicketMotivoId] = TM1.[TicketMotivoId]) WHERE TM1.[TicketId] = @TicketId ORDER BY TM1.[TicketId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmBC00315,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00316", "SELECT [TicketId] FROM [Ticket] WHERE [TicketId] = @TicketId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmBC00316,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00317", "INSERT INTO [Ticket]([TicketSolicitudId], [TicketEstado], [TicketComentario], [TicketAdjunto], [TicketMotivoId]) VALUES(@TicketSolicitudId, @TicketEstado, @TicketComentario, @TicketAdjunto, @TicketMotivoId); SELECT SCOPE_IDENTITY()",true, GxErrorMask.GX_NOMASK, false, this,prmBC00317,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("BC00318", "UPDATE [Ticket] SET [TicketSolicitudId]=@TicketSolicitudId, [TicketEstado]=@TicketEstado, [TicketComentario]=@TicketComentario, [TicketAdjunto]=@TicketAdjunto, [TicketMotivoId]=@TicketMotivoId  WHERE [TicketId] = @TicketId", GxErrorMask.GX_NOMASK,prmBC00318)
           ,new CursorDef("BC00319", "DELETE FROM [Ticket]  WHERE [TicketId] = @TicketId", GxErrorMask.GX_NOMASK,prmBC00319)
           ,new CursorDef("BC003110", "SELECT [TicketMotivoDescripcion] FROM [TicketMotivo] WHERE [TicketMotivoId] = @TicketMotivoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC003110,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC003111", "SELECT TOP 1 [SolicitudesID] FROM [Solicitudes] WHERE [TicketId] = @TicketId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC003111,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("BC003112", "SELECT TM1.[TicketId], TM1.[TicketSolicitudId], T2.[TicketMotivoDescripcion], TM1.[TicketEstado], TM1.[TicketComentario], TM1.[TicketAdjunto], TM1.[TicketMotivoId] FROM ([Ticket] TM1 INNER JOIN [TicketMotivo] T2 ON T2.[TicketMotivoId] = TM1.[TicketMotivoId]) WHERE TM1.[TicketId] = @TicketId ORDER BY TM1.[TicketId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmBC003112,100, GxCacheFrequency.OFF ,true,false )
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
              ((bool[]) buf[2])[0] = rslt.getBool(3);
              ((string[]) buf[3])[0] = rslt.getString(4, 250);
              ((string[]) buf[4])[0] = rslt.getString(5, 250);
              ((long[]) buf[5])[0] = rslt.getLong(6);
              return;
           case 1 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              ((bool[]) buf[2])[0] = rslt.getBool(3);
              ((string[]) buf[3])[0] = rslt.getString(4, 250);
              ((string[]) buf[4])[0] = rslt.getString(5, 250);
              ((long[]) buf[5])[0] = rslt.getLong(6);
              return;
           case 2 :
              ((string[]) buf[0])[0] = rslt.getString(1, 250);
              return;
           case 3 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              ((string[]) buf[2])[0] = rslt.getString(3, 250);
              ((bool[]) buf[3])[0] = rslt.getBool(4);
              ((string[]) buf[4])[0] = rslt.getString(5, 250);
              ((string[]) buf[5])[0] = rslt.getString(6, 250);
              ((long[]) buf[6])[0] = rslt.getLong(7);
              return;
           case 4 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 5 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 8 :
              ((string[]) buf[0])[0] = rslt.getString(1, 250);
              return;
           case 9 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 10 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              ((string[]) buf[2])[0] = rslt.getString(3, 250);
              ((bool[]) buf[3])[0] = rslt.getBool(4);
              ((string[]) buf[4])[0] = rslt.getString(5, 250);
              ((string[]) buf[5])[0] = rslt.getString(6, 250);
              ((long[]) buf[6])[0] = rslt.getLong(7);
              return;
     }
  }

}

}

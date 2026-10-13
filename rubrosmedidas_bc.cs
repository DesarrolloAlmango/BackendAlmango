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
   public class rubrosmedidas_bc : GXHttpHandler, IGxSilentTrn
   {
      public rubrosmedidas_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public rubrosmedidas_bc( IGxContext context )
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
         ReadRow0U37( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey0U37( ) ;
         standaloneModal( ) ;
         AddRow0U37( ) ;
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
            E110U2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               Z121RubrosId = A121RubrosId;
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

      protected void CONFIRM_0U0( )
      {
         BeforeValidate0U37( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls0U37( ) ;
            }
            else
            {
               CheckExtendedTable0U37( ) ;
               if ( AnyError == 0 )
               {
               }
               CloseExtendedTableCursors0U37( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            /* Save parent mode. */
            sMode37 = Gx_mode;
            CONFIRM_0U26( ) ;
            if ( AnyError == 0 )
            {
               /* Restore parent mode. */
               Gx_mode = sMode37;
            }
            /* Restore parent mode. */
            Gx_mode = sMode37;
         }
      }

      protected void CONFIRM_0U26( )
      {
         s217RubrosMedidasSerial = O217RubrosMedidasSerial;
         nGXsfl_26_idx = 0;
         while ( nGXsfl_26_idx < bcRubrosMedidas.gxTpr_Medidas.Count )
         {
            ReadRow0U26( ) ;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( Gx_mode)) )
            {
               if ( RcdFound26 == 0 )
               {
                  Gx_mode = "INS";
               }
               else
               {
                  Gx_mode = "UPD";
               }
            }
            if ( ! IsIns( ) || ( nIsMod_26 != 0 ) )
            {
               GetKey0U26( ) ;
               if ( IsIns( ) && ! IsDlt( ) )
               {
                  if ( RcdFound26 == 0 )
                  {
                     Gx_mode = "INS";
                     BeforeValidate0U26( ) ;
                     if ( AnyError == 0 )
                     {
                        CheckExtendedTable0U26( ) ;
                        if ( AnyError == 0 )
                        {
                           ZM0U26( 8) ;
                           ZM0U26( 9) ;
                        }
                        CloseExtendedTableCursors0U26( ) ;
                        if ( AnyError == 0 )
                        {
                        }
                        O217RubrosMedidasSerial = A217RubrosMedidasSerial;
                     }
                  }
                  else
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
                     AnyError = 1;
                  }
               }
               else
               {
                  if ( RcdFound26 != 0 )
                  {
                     if ( IsDlt( ) )
                     {
                        Gx_mode = "DLT";
                        getByPrimaryKey0U26( ) ;
                        Load0U26( ) ;
                        BeforeValidate0U26( ) ;
                        if ( AnyError == 0 )
                        {
                           OnDeleteControls0U26( ) ;
                           O217RubrosMedidasSerial = A217RubrosMedidasSerial;
                        }
                     }
                     else
                     {
                        if ( nIsMod_26 != 0 )
                        {
                           Gx_mode = "UPD";
                           BeforeValidate0U26( ) ;
                           if ( AnyError == 0 )
                           {
                              CheckExtendedTable0U26( ) ;
                              if ( AnyError == 0 )
                              {
                                 ZM0U26( 8) ;
                                 ZM0U26( 9) ;
                              }
                              CloseExtendedTableCursors0U26( ) ;
                              if ( AnyError == 0 )
                              {
                              }
                              O217RubrosMedidasSerial = A217RubrosMedidasSerial;
                           }
                        }
                     }
                  }
                  else
                  {
                     if ( ! IsDlt( ) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "");
                        AnyError = 1;
                     }
                  }
               }
               VarsToRow26( ((SdtRubrosMedidas_Caracteristicas)bcRubrosMedidas.gxTpr_Medidas.Item(nGXsfl_26_idx))) ;
            }
         }
         O217RubrosMedidasSerial = s217RubrosMedidasSerial;
         /* Start of After( level) rules */
         /* End of After( level) rules */
      }

      protected void E120U2( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV8WWPContext) ;
         AV11TrnContext.FromXml(AV12WebSession.Get("TrnContext"), null, "", "");
      }

      protected void E110U2( )
      {
         /* After Trn Routine */
         returnInSub = false;
      }

      protected void ZM0U37( short GX_JID )
      {
         if ( ( GX_JID == 6 ) || ( GX_JID == 0 ) )
         {
            Z122RubrosNombre = A122RubrosNombre;
            Z217RubrosMedidasSerial = A217RubrosMedidasSerial;
            Z123RubrosEstado = A123RubrosEstado;
         }
         if ( GX_JID == -6 )
         {
            Z121RubrosId = A121RubrosId;
            Z122RubrosNombre = A122RubrosNombre;
            Z168RubrosImagen = A168RubrosImagen;
            Z40000RubrosImagen_GXI = A40000RubrosImagen_GXI;
            Z217RubrosMedidasSerial = A217RubrosMedidasSerial;
            Z123RubrosEstado = A123RubrosEstado;
         }
      }

      protected void standaloneNotModal( )
      {
         Gx_BScreen = 0;
      }

      protected void standaloneModal( )
      {
      }

      protected void Load0U37( )
      {
         /* Using cursor BC000U8 */
         pr_default.execute(6, new Object[] {A121RubrosId});
         if ( (pr_default.getStatus(6) != 101) )
         {
            RcdFound37 = 1;
            A122RubrosNombre = BC000U8_A122RubrosNombre[0];
            A40000RubrosImagen_GXI = BC000U8_A40000RubrosImagen_GXI[0];
            A217RubrosMedidasSerial = BC000U8_A217RubrosMedidasSerial[0];
            A123RubrosEstado = BC000U8_A123RubrosEstado[0];
            n123RubrosEstado = BC000U8_n123RubrosEstado[0];
            A168RubrosImagen = BC000U8_A168RubrosImagen[0];
            ZM0U37( -6) ;
         }
         pr_default.close(6);
         OnLoadActions0U37( ) ;
      }

      protected void OnLoadActions0U37( )
      {
      }

      protected void CheckExtendedTable0U37( )
      {
         standaloneModal( ) ;
         if ( ! ( ( StringUtil.StrCmp(A123RubrosEstado, "HAB") == 0 ) || ( StringUtil.StrCmp(A123RubrosEstado, "DES") == 0 ) || ( StringUtil.StrCmp(A123RubrosEstado, "PEN") == 0 ) || ( StringUtil.StrCmp(A123RubrosEstado, "BLO") == 0 ) || String.IsNullOrEmpty(StringUtil.RTrim( A123RubrosEstado)) ) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_OutOfRange", ""), context.GetMessage( "Estado", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, "");
            AnyError = 1;
         }
      }

      protected void CloseExtendedTableCursors0U37( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey0U37( )
      {
         /* Using cursor BC000U9 */
         pr_default.execute(7, new Object[] {A121RubrosId});
         if ( (pr_default.getStatus(7) != 101) )
         {
            RcdFound37 = 1;
         }
         else
         {
            RcdFound37 = 0;
         }
         pr_default.close(7);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC000U7 */
         pr_default.execute(5, new Object[] {A121RubrosId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            ZM0U37( 6) ;
            RcdFound37 = 1;
            A121RubrosId = BC000U7_A121RubrosId[0];
            A122RubrosNombre = BC000U7_A122RubrosNombre[0];
            A40000RubrosImagen_GXI = BC000U7_A40000RubrosImagen_GXI[0];
            A217RubrosMedidasSerial = BC000U7_A217RubrosMedidasSerial[0];
            A123RubrosEstado = BC000U7_A123RubrosEstado[0];
            n123RubrosEstado = BC000U7_n123RubrosEstado[0];
            A168RubrosImagen = BC000U7_A168RubrosImagen[0];
            O217RubrosMedidasSerial = A217RubrosMedidasSerial;
            Z121RubrosId = A121RubrosId;
            sMode37 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load0U37( ) ;
            if ( AnyError == 1 )
            {
               RcdFound37 = 0;
               InitializeNonKey0U37( ) ;
            }
            Gx_mode = sMode37;
         }
         else
         {
            RcdFound37 = 0;
            InitializeNonKey0U37( ) ;
            sMode37 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode37;
         }
         pr_default.close(5);
      }

      protected void getEqualNoModal( )
      {
         GetKey0U37( ) ;
         if ( RcdFound37 == 0 )
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
         CONFIRM_0U0( ) ;
      }

      protected void update_Check( )
      {
         insert_Check( ) ;
      }

      protected void delete_Check( )
      {
         insert_Check( ) ;
      }

      protected void CheckOptimisticConcurrency0U37( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC000U6 */
            pr_default.execute(4, new Object[] {A121RubrosId});
            if ( (pr_default.getStatus(4) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Rubros"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(4) == 101) || ( StringUtil.StrCmp(Z122RubrosNombre, BC000U6_A122RubrosNombre[0]) != 0 ) || ( Z217RubrosMedidasSerial != BC000U6_A217RubrosMedidasSerial[0] ) || ( StringUtil.StrCmp(Z123RubrosEstado, BC000U6_A123RubrosEstado[0]) != 0 ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Rubros"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0U37( )
      {
         BeforeValidate0U37( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0U37( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0U37( 0) ;
            CheckOptimisticConcurrency0U37( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0U37( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0U37( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000U10 */
                     pr_default.execute(8, new Object[] {A122RubrosNombre, A168RubrosImagen, A40000RubrosImagen_GXI, A217RubrosMedidasSerial, n123RubrosEstado, A123RubrosEstado});
                     A121RubrosId = BC000U10_A121RubrosId[0];
                     pr_default.close(8);
                     pr_default.SmartCacheProvider.SetUpdated("Rubros");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           ProcessLevel0U37( ) ;
                           if ( AnyError == 0 )
                           {
                              /* Save values for previous() function. */
                              endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                              endTrnMsgCod = "SuccessfullyAdded";
                           }
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
               Load0U37( ) ;
            }
            EndLevel0U37( ) ;
         }
         CloseExtendedTableCursors0U37( ) ;
      }

      protected void Update0U37( )
      {
         BeforeValidate0U37( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0U37( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0U37( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0U37( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0U37( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000U11 */
                     pr_default.execute(9, new Object[] {A122RubrosNombre, A217RubrosMedidasSerial, n123RubrosEstado, A123RubrosEstado, A121RubrosId});
                     pr_default.close(9);
                     pr_default.SmartCacheProvider.SetUpdated("Rubros");
                     if ( (pr_default.getStatus(9) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Rubros"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0U37( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           ProcessLevel0U37( ) ;
                           if ( AnyError == 0 )
                           {
                              getByPrimaryKey( ) ;
                              endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                              endTrnMsgCod = "SuccessfullyUpdated";
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
            }
            EndLevel0U37( ) ;
         }
         CloseExtendedTableCursors0U37( ) ;
      }

      protected void DeferredUpdate0U37( )
      {
         if ( AnyError == 0 )
         {
            /* Using cursor BC000U12 */
            pr_default.execute(10, new Object[] {A168RubrosImagen, A40000RubrosImagen_GXI, A121RubrosId});
            pr_default.close(10);
            pr_default.SmartCacheProvider.SetUpdated("Rubros");
         }
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate0U37( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0U37( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0U37( ) ;
            AfterConfirm0U37( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0U37( ) ;
               if ( AnyError == 0 )
               {
                  A217RubrosMedidasSerial = O217RubrosMedidasSerial;
                  ScanKeyStart0U26( ) ;
                  while ( RcdFound26 != 0 )
                  {
                     getByPrimaryKey0U26( ) ;
                     Delete0U26( ) ;
                     ScanKeyNext0U26( ) ;
                     O217RubrosMedidasSerial = A217RubrosMedidasSerial;
                  }
                  ScanKeyEnd0U26( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000U13 */
                     pr_default.execute(11, new Object[] {A121RubrosId});
                     pr_default.close(11);
                     pr_default.SmartCacheProvider.SetUpdated("Rubros");
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
         }
         sMode37 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel0U37( ) ;
         Gx_mode = sMode37;
      }

      protected void OnDeleteControls0U37( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
         if ( AnyError == 0 )
         {
            /* Using cursor BC000U14 */
            pr_default.execute(12, new Object[] {A121RubrosId});
            if ( (pr_default.getStatus(12) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "Capacidad Productiva", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(12);
            /* Using cursor BC000U15 */
            pr_default.execute(13, new Object[] {A121RubrosId});
            if ( (pr_default.getStatus(13) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "Rubros", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(13);
            /* Using cursor BC000U16 */
            pr_default.execute(14, new Object[] {A121RubrosId});
            if ( (pr_default.getStatus(14) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "Inventario", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(14);
         }
      }

      protected void ProcessNestedLevel0U26( )
      {
         s217RubrosMedidasSerial = O217RubrosMedidasSerial;
         nGXsfl_26_idx = 0;
         while ( nGXsfl_26_idx < bcRubrosMedidas.gxTpr_Medidas.Count )
         {
            ReadRow0U26( ) ;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( Gx_mode)) )
            {
               if ( RcdFound26 == 0 )
               {
                  Gx_mode = "INS";
               }
               else
               {
                  Gx_mode = "UPD";
               }
            }
            if ( ! IsIns( ) || ( nIsMod_26 != 0 ) )
            {
               standaloneNotModal0U26( ) ;
               if ( IsIns( ) )
               {
                  Gx_mode = "INS";
                  Insert0U26( ) ;
               }
               else
               {
                  if ( IsDlt( ) )
                  {
                     Gx_mode = "DLT";
                     Delete0U26( ) ;
                  }
                  else
                  {
                     Gx_mode = "UPD";
                     Update0U26( ) ;
                  }
               }
               O217RubrosMedidasSerial = A217RubrosMedidasSerial;
            }
            KeyVarsToRow26( ((SdtRubrosMedidas_Caracteristicas)bcRubrosMedidas.gxTpr_Medidas.Item(nGXsfl_26_idx))) ;
         }
         if ( AnyError == 0 )
         {
            /* Batch update SDT rows */
            nGXsfl_26_idx = 0;
            while ( nGXsfl_26_idx < bcRubrosMedidas.gxTpr_Medidas.Count )
            {
               ReadRow0U26( ) ;
               if ( String.IsNullOrEmpty(StringUtil.RTrim( Gx_mode)) )
               {
                  if ( RcdFound26 == 0 )
                  {
                     Gx_mode = "INS";
                  }
                  else
                  {
                     Gx_mode = "UPD";
                  }
               }
               /* Update SDT row */
               if ( IsDlt( ) )
               {
                  bcRubrosMedidas.gxTpr_Medidas.RemoveElement(nGXsfl_26_idx);
                  nGXsfl_26_idx = (int)(nGXsfl_26_idx-1);
               }
               else
               {
                  Gx_mode = "UPD";
                  getByPrimaryKey0U26( ) ;
                  VarsToRow26( ((SdtRubrosMedidas_Caracteristicas)bcRubrosMedidas.gxTpr_Medidas.Item(nGXsfl_26_idx))) ;
               }
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
         InitAll0U26( ) ;
         if ( AnyError != 0 )
         {
            O217RubrosMedidasSerial = s217RubrosMedidasSerial;
         }
         nRcdExists_26 = 0;
         nIsMod_26 = 0;
      }

      protected void ProcessLevel0U37( )
      {
         /* Save parent mode. */
         sMode37 = Gx_mode;
         ProcessNestedLevel0U26( ) ;
         if ( AnyError != 0 )
         {
            O217RubrosMedidasSerial = s217RubrosMedidasSerial;
         }
         /* Restore parent mode. */
         Gx_mode = sMode37;
         /* ' Update level parameters */
         /* Using cursor BC000U17 */
         pr_default.execute(15, new Object[] {A217RubrosMedidasSerial, A121RubrosId});
         pr_default.close(15);
         pr_default.SmartCacheProvider.SetUpdated("Rubros");
      }

      protected void EndLevel0U37( )
      {
         pr_default.close(4);
         if ( AnyError == 0 )
         {
            BeforeComplete0U37( ) ;
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

      public void ScanKeyStart0U37( )
      {
         /* Scan By routine */
         /* Using cursor BC000U18 */
         pr_default.execute(16, new Object[] {A121RubrosId});
         RcdFound37 = 0;
         if ( (pr_default.getStatus(16) != 101) )
         {
            RcdFound37 = 1;
            A121RubrosId = BC000U18_A121RubrosId[0];
            A122RubrosNombre = BC000U18_A122RubrosNombre[0];
            A40000RubrosImagen_GXI = BC000U18_A40000RubrosImagen_GXI[0];
            A217RubrosMedidasSerial = BC000U18_A217RubrosMedidasSerial[0];
            A123RubrosEstado = BC000U18_A123RubrosEstado[0];
            n123RubrosEstado = BC000U18_n123RubrosEstado[0];
            A168RubrosImagen = BC000U18_A168RubrosImagen[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext0U37( )
      {
         /* Scan next routine */
         pr_default.readNext(16);
         RcdFound37 = 0;
         ScanKeyLoad0U37( ) ;
      }

      protected void ScanKeyLoad0U37( )
      {
         sMode37 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(16) != 101) )
         {
            RcdFound37 = 1;
            A121RubrosId = BC000U18_A121RubrosId[0];
            A122RubrosNombre = BC000U18_A122RubrosNombre[0];
            A40000RubrosImagen_GXI = BC000U18_A40000RubrosImagen_GXI[0];
            A217RubrosMedidasSerial = BC000U18_A217RubrosMedidasSerial[0];
            A123RubrosEstado = BC000U18_A123RubrosEstado[0];
            n123RubrosEstado = BC000U18_n123RubrosEstado[0];
            A168RubrosImagen = BC000U18_A168RubrosImagen[0];
         }
         Gx_mode = sMode37;
      }

      protected void ScanKeyEnd0U37( )
      {
         pr_default.close(16);
      }

      protected void AfterConfirm0U37( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0U37( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0U37( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0U37( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0U37( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0U37( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0U37( )
      {
      }

      protected void ZM0U26( short GX_JID )
      {
         if ( ( GX_JID == 7 ) || ( GX_JID == 0 ) )
         {
            Z139MedidasEstado = A139MedidasEstado;
            Z138MedidasNombre = A138MedidasNombre;
            Z215RubrosCosto = A215RubrosCosto;
            Z216RubrosPrecioBase = A216RubrosPrecioBase;
            Z150TextosId = A150TextosId;
            Z118MonedaId = A118MonedaId;
         }
         if ( ( GX_JID == 8 ) || ( GX_JID == 0 ) )
         {
            Z259TextosTitulo = A259TextosTitulo;
         }
         if ( ( GX_JID == 9 ) || ( GX_JID == 0 ) )
         {
         }
         if ( GX_JID == -7 )
         {
            Z121RubrosId = A121RubrosId;
            Z137MedidasID = A137MedidasID;
            Z139MedidasEstado = A139MedidasEstado;
            Z138MedidasNombre = A138MedidasNombre;
            Z842MedidasImagen = A842MedidasImagen;
            Z40001MedidasImagen_GXI = A40001MedidasImagen_GXI;
            Z215RubrosCosto = A215RubrosCosto;
            Z216RubrosPrecioBase = A216RubrosPrecioBase;
            Z150TextosId = A150TextosId;
            Z118MonedaId = A118MonedaId;
            Z259TextosTitulo = A259TextosTitulo;
         }
      }

      protected void standaloneNotModal0U26( )
      {
      }

      protected void standaloneModal0U26( )
      {
         if ( IsIns( )  )
         {
            A217RubrosMedidasSerial = (short)(O217RubrosMedidasSerial+1);
         }
         if ( IsIns( )  )
         {
            A137MedidasID = A217RubrosMedidasSerial;
         }
         if ( IsIns( )  && String.IsNullOrEmpty(StringUtil.RTrim( A139MedidasEstado)) && ( Gx_BScreen == 0 ) )
         {
            A139MedidasEstado = "HAB";
            n139MedidasEstado = false;
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
         }
      }

      protected void Load0U26( )
      {
         /* Using cursor BC000U19 */
         pr_default.execute(17, new Object[] {A121RubrosId, A137MedidasID});
         if ( (pr_default.getStatus(17) != 101) )
         {
            RcdFound26 = 1;
            A139MedidasEstado = BC000U19_A139MedidasEstado[0];
            n139MedidasEstado = BC000U19_n139MedidasEstado[0];
            A138MedidasNombre = BC000U19_A138MedidasNombre[0];
            A40001MedidasImagen_GXI = BC000U19_A40001MedidasImagen_GXI[0];
            n40001MedidasImagen_GXI = BC000U19_n40001MedidasImagen_GXI[0];
            A215RubrosCosto = BC000U19_A215RubrosCosto[0];
            A216RubrosPrecioBase = BC000U19_A216RubrosPrecioBase[0];
            A259TextosTitulo = BC000U19_A259TextosTitulo[0];
            A150TextosId = BC000U19_A150TextosId[0];
            n150TextosId = BC000U19_n150TextosId[0];
            A118MonedaId = BC000U19_A118MonedaId[0];
            A842MedidasImagen = BC000U19_A842MedidasImagen[0];
            n842MedidasImagen = BC000U19_n842MedidasImagen[0];
            ZM0U26( -7) ;
         }
         pr_default.close(17);
         OnLoadActions0U26( ) ;
      }

      protected void OnLoadActions0U26( )
      {
      }

      protected void CheckExtendedTable0U26( )
      {
         Gx_BScreen = 1;
         standaloneModal0U26( ) ;
         Gx_BScreen = 0;
         /* Using cursor BC000U5 */
         pr_default.execute(3, new Object[] {A118MonedaId});
         if ( (pr_default.getStatus(3) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( " T12", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "MONEDAID");
            AnyError = 1;
         }
         pr_default.close(3);
         if ( ! ( ( StringUtil.StrCmp(A139MedidasEstado, "HAB") == 0 ) || ( StringUtil.StrCmp(A139MedidasEstado, "DES") == 0 ) || ( StringUtil.StrCmp(A139MedidasEstado, "PEN") == 0 ) || ( StringUtil.StrCmp(A139MedidasEstado, "BLO") == 0 ) || String.IsNullOrEmpty(StringUtil.RTrim( A139MedidasEstado)) ) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_OutOfRange", ""), context.GetMessage( "Estado de la Lista", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, "");
            AnyError = 1;
         }
         /* Using cursor BC000U4 */
         pr_default.execute(2, new Object[] {n150TextosId, A150TextosId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            if ( ! ( (0==A150TextosId) ) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Textos", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "TEXTOSID");
               AnyError = 1;
            }
         }
         A259TextosTitulo = BC000U4_A259TextosTitulo[0];
         pr_default.close(2);
      }

      protected void CloseExtendedTableCursors0U26( )
      {
         pr_default.close(3);
         pr_default.close(2);
      }

      protected void enableDisable0U26( )
      {
      }

      protected void GetKey0U26( )
      {
         /* Using cursor BC000U20 */
         pr_default.execute(18, new Object[] {A121RubrosId, A137MedidasID});
         if ( (pr_default.getStatus(18) != 101) )
         {
            RcdFound26 = 1;
         }
         else
         {
            RcdFound26 = 0;
         }
         pr_default.close(18);
      }

      protected void getByPrimaryKey0U26( )
      {
         /* Using cursor BC000U3 */
         pr_default.execute(1, new Object[] {A121RubrosId, A137MedidasID});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0U26( 7) ;
            RcdFound26 = 1;
            InitializeNonKey0U26( ) ;
            A137MedidasID = BC000U3_A137MedidasID[0];
            A139MedidasEstado = BC000U3_A139MedidasEstado[0];
            n139MedidasEstado = BC000U3_n139MedidasEstado[0];
            A138MedidasNombre = BC000U3_A138MedidasNombre[0];
            A40001MedidasImagen_GXI = BC000U3_A40001MedidasImagen_GXI[0];
            n40001MedidasImagen_GXI = BC000U3_n40001MedidasImagen_GXI[0];
            A215RubrosCosto = BC000U3_A215RubrosCosto[0];
            A216RubrosPrecioBase = BC000U3_A216RubrosPrecioBase[0];
            A150TextosId = BC000U3_A150TextosId[0];
            n150TextosId = BC000U3_n150TextosId[0];
            A118MonedaId = BC000U3_A118MonedaId[0];
            A842MedidasImagen = BC000U3_A842MedidasImagen[0];
            n842MedidasImagen = BC000U3_n842MedidasImagen[0];
            Z121RubrosId = A121RubrosId;
            Z137MedidasID = A137MedidasID;
            sMode26 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal0U26( ) ;
            Load0U26( ) ;
            Gx_mode = sMode26;
         }
         else
         {
            RcdFound26 = 0;
            InitializeNonKey0U26( ) ;
            sMode26 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal0U26( ) ;
            Gx_mode = sMode26;
         }
         if ( IsDsp( ) || IsDlt( ) )
         {
            DisableAttributes0U26( ) ;
         }
         pr_default.close(1);
      }

      protected void CheckOptimisticConcurrency0U26( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC000U2 */
            pr_default.execute(0, new Object[] {A121RubrosId, A137MedidasID});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"RubrosMedidas"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z139MedidasEstado, BC000U2_A139MedidasEstado[0]) != 0 ) || ( StringUtil.StrCmp(Z138MedidasNombre, BC000U2_A138MedidasNombre[0]) != 0 ) || ( Z215RubrosCosto != BC000U2_A215RubrosCosto[0] ) || ( Z216RubrosPrecioBase != BC000U2_A216RubrosPrecioBase[0] ) || ( Z150TextosId != BC000U2_A150TextosId[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z118MonedaId != BC000U2_A118MonedaId[0] ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"RubrosMedidas"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0U26( )
      {
         BeforeValidate0U26( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0U26( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0U26( 0) ;
            CheckOptimisticConcurrency0U26( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0U26( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0U26( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000U21 */
                     pr_default.execute(19, new Object[] {A121RubrosId, A137MedidasID, n139MedidasEstado, A139MedidasEstado, A138MedidasNombre, n842MedidasImagen, A842MedidasImagen, n40001MedidasImagen_GXI, A40001MedidasImagen_GXI, A215RubrosCosto, A216RubrosPrecioBase, n150TextosId, A150TextosId, A118MonedaId});
                     pr_default.close(19);
                     pr_default.SmartCacheProvider.SetUpdated("RubrosMedidas");
                     if ( (pr_default.getStatus(19) == 1) )
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
               Load0U26( ) ;
            }
            EndLevel0U26( ) ;
         }
         CloseExtendedTableCursors0U26( ) ;
      }

      protected void Update0U26( )
      {
         BeforeValidate0U26( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0U26( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0U26( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0U26( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0U26( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000U22 */
                     pr_default.execute(20, new Object[] {n139MedidasEstado, A139MedidasEstado, A138MedidasNombre, A215RubrosCosto, A216RubrosPrecioBase, n150TextosId, A150TextosId, A118MonedaId, A121RubrosId, A137MedidasID});
                     pr_default.close(20);
                     pr_default.SmartCacheProvider.SetUpdated("RubrosMedidas");
                     if ( (pr_default.getStatus(20) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"RubrosMedidas"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0U26( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey0U26( ) ;
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
            EndLevel0U26( ) ;
         }
         CloseExtendedTableCursors0U26( ) ;
      }

      protected void DeferredUpdate0U26( )
      {
         if ( AnyError == 0 )
         {
            /* Using cursor BC000U23 */
            pr_default.execute(21, new Object[] {n842MedidasImagen, A842MedidasImagen, n40001MedidasImagen_GXI, A40001MedidasImagen_GXI, A121RubrosId, A137MedidasID});
            pr_default.close(21);
            pr_default.SmartCacheProvider.SetUpdated("RubrosMedidas");
         }
      }

      protected void Delete0U26( )
      {
         Gx_mode = "DLT";
         BeforeValidate0U26( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0U26( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0U26( ) ;
            AfterConfirm0U26( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0U26( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC000U24 */
                  pr_default.execute(22, new Object[] {A121RubrosId, A137MedidasID});
                  pr_default.close(22);
                  pr_default.SmartCacheProvider.SetUpdated("RubrosMedidas");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                  }
                  else
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                     AnyError = 1;
                  }
               }
            }
         }
         sMode26 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel0U26( ) ;
         Gx_mode = sMode26;
      }

      protected void OnDeleteControls0U26( )
      {
         standaloneModal0U26( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor BC000U25 */
            pr_default.execute(23, new Object[] {n150TextosId, A150TextosId});
            A259TextosTitulo = BC000U25_A259TextosTitulo[0];
            pr_default.close(23);
         }
         if ( AnyError == 0 )
         {
            /* Using cursor BC000U26 */
            pr_default.execute(24, new Object[] {A121RubrosId, A137MedidasID});
            if ( (pr_default.getStatus(24) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "Inventario", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(24);
         }
      }

      protected void EndLevel0U26( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanKeyStart0U26( )
      {
         /* Scan By routine */
         /* Using cursor BC000U27 */
         pr_default.execute(25, new Object[] {A121RubrosId});
         RcdFound26 = 0;
         if ( (pr_default.getStatus(25) != 101) )
         {
            RcdFound26 = 1;
            A137MedidasID = BC000U27_A137MedidasID[0];
            A139MedidasEstado = BC000U27_A139MedidasEstado[0];
            n139MedidasEstado = BC000U27_n139MedidasEstado[0];
            A138MedidasNombre = BC000U27_A138MedidasNombre[0];
            A40001MedidasImagen_GXI = BC000U27_A40001MedidasImagen_GXI[0];
            n40001MedidasImagen_GXI = BC000U27_n40001MedidasImagen_GXI[0];
            A215RubrosCosto = BC000U27_A215RubrosCosto[0];
            A216RubrosPrecioBase = BC000U27_A216RubrosPrecioBase[0];
            A259TextosTitulo = BC000U27_A259TextosTitulo[0];
            A150TextosId = BC000U27_A150TextosId[0];
            n150TextosId = BC000U27_n150TextosId[0];
            A118MonedaId = BC000U27_A118MonedaId[0];
            A842MedidasImagen = BC000U27_A842MedidasImagen[0];
            n842MedidasImagen = BC000U27_n842MedidasImagen[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext0U26( )
      {
         /* Scan next routine */
         pr_default.readNext(25);
         RcdFound26 = 0;
         ScanKeyLoad0U26( ) ;
      }

      protected void ScanKeyLoad0U26( )
      {
         sMode26 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(25) != 101) )
         {
            RcdFound26 = 1;
            A137MedidasID = BC000U27_A137MedidasID[0];
            A139MedidasEstado = BC000U27_A139MedidasEstado[0];
            n139MedidasEstado = BC000U27_n139MedidasEstado[0];
            A138MedidasNombre = BC000U27_A138MedidasNombre[0];
            A40001MedidasImagen_GXI = BC000U27_A40001MedidasImagen_GXI[0];
            n40001MedidasImagen_GXI = BC000U27_n40001MedidasImagen_GXI[0];
            A215RubrosCosto = BC000U27_A215RubrosCosto[0];
            A216RubrosPrecioBase = BC000U27_A216RubrosPrecioBase[0];
            A259TextosTitulo = BC000U27_A259TextosTitulo[0];
            A150TextosId = BC000U27_A150TextosId[0];
            n150TextosId = BC000U27_n150TextosId[0];
            A118MonedaId = BC000U27_A118MonedaId[0];
            A842MedidasImagen = BC000U27_A842MedidasImagen[0];
            n842MedidasImagen = BC000U27_n842MedidasImagen[0];
         }
         Gx_mode = sMode26;
      }

      protected void ScanKeyEnd0U26( )
      {
         pr_default.close(25);
      }

      protected void AfterConfirm0U26( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0U26( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0U26( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0U26( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0U26( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0U26( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0U26( )
      {
      }

      protected void send_integrity_lvl_hashes0U26( )
      {
      }

      protected void send_integrity_lvl_hashes0U37( )
      {
      }

      protected void AddRow0U37( )
      {
         VarsToRow37( bcRubrosMedidas) ;
      }

      protected void ReadRow0U37( )
      {
         RowToVars37( bcRubrosMedidas, 1) ;
      }

      protected void AddRow0U26( )
      {
         SdtRubrosMedidas_Caracteristicas obj26;
         obj26 = new SdtRubrosMedidas_Caracteristicas(context);
         VarsToRow26( obj26) ;
         bcRubrosMedidas.gxTpr_Medidas.Add(obj26, 0);
         obj26.gxTpr_Mode = "UPD";
         obj26.gxTpr_Modified = 0;
      }

      protected void ReadRow0U26( )
      {
         nGXsfl_26_idx = (int)(nGXsfl_26_idx+1);
         RowToVars26( ((SdtRubrosMedidas_Caracteristicas)bcRubrosMedidas.gxTpr_Medidas.Item(nGXsfl_26_idx)), 1) ;
      }

      protected void InitializeNonKey0U37( )
      {
         A122RubrosNombre = "";
         A168RubrosImagen = "";
         A40000RubrosImagen_GXI = "";
         A217RubrosMedidasSerial = 0;
         A123RubrosEstado = "";
         n123RubrosEstado = false;
         O217RubrosMedidasSerial = A217RubrosMedidasSerial;
         Z122RubrosNombre = "";
         Z217RubrosMedidasSerial = 0;
         Z123RubrosEstado = "";
      }

      protected void InitAll0U37( )
      {
         A121RubrosId = 0;
         InitializeNonKey0U37( ) ;
      }

      protected void StandaloneModalInsert( )
      {
      }

      protected void InitializeNonKey0U26( )
      {
         A138MedidasNombre = "";
         A842MedidasImagen = "";
         n842MedidasImagen = false;
         A40001MedidasImagen_GXI = "";
         n40001MedidasImagen_GXI = false;
         A118MonedaId = 0;
         A215RubrosCosto = 0;
         A216RubrosPrecioBase = 0;
         A150TextosId = 0;
         n150TextosId = false;
         A259TextosTitulo = "";
         A139MedidasEstado = "HAB";
         n139MedidasEstado = false;
         Z139MedidasEstado = "";
         Z138MedidasNombre = "";
         Z215RubrosCosto = 0;
         Z216RubrosPrecioBase = 0;
         Z150TextosId = 0;
         Z118MonedaId = 0;
      }

      protected void InitAll0U26( )
      {
         A137MedidasID = 0;
         InitializeNonKey0U26( ) ;
      }

      protected void StandaloneModalInsert0U26( )
      {
         A217RubrosMedidasSerial = i217RubrosMedidasSerial;
         A139MedidasEstado = i139MedidasEstado;
         n139MedidasEstado = false;
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

      public void VarsToRow37( SdtRubrosMedidas obj37 )
      {
         obj37.gxTpr_Mode = Gx_mode;
         obj37.gxTpr_Rubrosnombre = A122RubrosNombre;
         obj37.gxTpr_Rubrosimagen = A168RubrosImagen;
         obj37.gxTpr_Rubrosimagen_gxi = A40000RubrosImagen_GXI;
         obj37.gxTpr_Rubrosmedidasserial = A217RubrosMedidasSerial;
         obj37.gxTpr_Rubrosestado = A123RubrosEstado;
         obj37.gxTpr_Rubrosid = A121RubrosId;
         obj37.gxTpr_Rubrosid_Z = Z121RubrosId;
         obj37.gxTpr_Rubrosnombre_Z = Z122RubrosNombre;
         obj37.gxTpr_Rubrosmedidasserial_Z = Z217RubrosMedidasSerial;
         obj37.gxTpr_Rubrosestado_Z = Z123RubrosEstado;
         obj37.gxTpr_Rubrosimagen_gxi_Z = Z40000RubrosImagen_GXI;
         obj37.gxTpr_Rubrosestado_N = (short)(Convert.ToInt16(n123RubrosEstado));
         obj37.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow37( SdtRubrosMedidas obj37 )
      {
         obj37.gxTpr_Rubrosid = A121RubrosId;
         return  ;
      }

      public void RowToVars37( SdtRubrosMedidas obj37 ,
                               int forceLoad )
      {
         Gx_mode = obj37.gxTpr_Mode;
         A122RubrosNombre = obj37.gxTpr_Rubrosnombre;
         A168RubrosImagen = obj37.gxTpr_Rubrosimagen;
         A40000RubrosImagen_GXI = obj37.gxTpr_Rubrosimagen_gxi;
         if ( forceLoad == 1 )
         {
            A217RubrosMedidasSerial = obj37.gxTpr_Rubrosmedidasserial;
         }
         A123RubrosEstado = obj37.gxTpr_Rubrosestado;
         n123RubrosEstado = false;
         A121RubrosId = obj37.gxTpr_Rubrosid;
         Z121RubrosId = obj37.gxTpr_Rubrosid_Z;
         Z122RubrosNombre = obj37.gxTpr_Rubrosnombre_Z;
         Z217RubrosMedidasSerial = obj37.gxTpr_Rubrosmedidasserial_Z;
         O217RubrosMedidasSerial = obj37.gxTpr_Rubrosmedidasserial_Z;
         Z123RubrosEstado = obj37.gxTpr_Rubrosestado_Z;
         Z40000RubrosImagen_GXI = obj37.gxTpr_Rubrosimagen_gxi_Z;
         n123RubrosEstado = (bool)(Convert.ToBoolean(obj37.gxTpr_Rubrosestado_N));
         Gx_mode = obj37.gxTpr_Mode;
         return  ;
      }

      public void VarsToRow26( SdtRubrosMedidas_Caracteristicas obj26 )
      {
         obj26.gxTpr_Mode = Gx_mode;
         obj26.gxTpr_Medidasnombre = A138MedidasNombre;
         obj26.gxTpr_Medidasimagen = A842MedidasImagen;
         obj26.gxTpr_Medidasimagen_gxi = A40001MedidasImagen_GXI;
         obj26.gxTpr_Monedaid = A118MonedaId;
         obj26.gxTpr_Rubroscosto = A215RubrosCosto;
         obj26.gxTpr_Rubrospreciobase = A216RubrosPrecioBase;
         obj26.gxTpr_Textosid = A150TextosId;
         obj26.gxTpr_Textostitulo = A259TextosTitulo;
         obj26.gxTpr_Medidasestado = A139MedidasEstado;
         obj26.gxTpr_Medidasid = A137MedidasID;
         obj26.gxTpr_Medidasid_Z = Z137MedidasID;
         obj26.gxTpr_Medidasnombre_Z = Z138MedidasNombre;
         obj26.gxTpr_Monedaid_Z = Z118MonedaId;
         obj26.gxTpr_Rubroscosto_Z = Z215RubrosCosto;
         obj26.gxTpr_Rubrospreciobase_Z = Z216RubrosPrecioBase;
         obj26.gxTpr_Medidasestado_Z = Z139MedidasEstado;
         obj26.gxTpr_Textosid_Z = Z150TextosId;
         obj26.gxTpr_Textostitulo_Z = Z259TextosTitulo;
         obj26.gxTpr_Medidasimagen_gxi_Z = Z40001MedidasImagen_GXI;
         obj26.gxTpr_Medidasimagen_N = (short)(Convert.ToInt16(n842MedidasImagen));
         obj26.gxTpr_Medidasestado_N = (short)(Convert.ToInt16(n139MedidasEstado));
         obj26.gxTpr_Textosid_N = (short)(Convert.ToInt16(n150TextosId));
         obj26.gxTpr_Medidasimagen_gxi_N = (short)(Convert.ToInt16(n40001MedidasImagen_GXI));
         obj26.gxTpr_Modified = nIsMod_26;
         return  ;
      }

      public void KeyVarsToRow26( SdtRubrosMedidas_Caracteristicas obj26 )
      {
         obj26.gxTpr_Medidasid = A137MedidasID;
         return  ;
      }

      public void RowToVars26( SdtRubrosMedidas_Caracteristicas obj26 ,
                               int forceLoad )
      {
         Gx_mode = obj26.gxTpr_Mode;
         A138MedidasNombre = obj26.gxTpr_Medidasnombre;
         A842MedidasImagen = obj26.gxTpr_Medidasimagen;
         n842MedidasImagen = false;
         A40001MedidasImagen_GXI = obj26.gxTpr_Medidasimagen_gxi;
         n40001MedidasImagen_GXI = false;
         A118MonedaId = obj26.gxTpr_Monedaid;
         A215RubrosCosto = obj26.gxTpr_Rubroscosto;
         A216RubrosPrecioBase = obj26.gxTpr_Rubrospreciobase;
         A150TextosId = obj26.gxTpr_Textosid;
         n150TextosId = false;
         A259TextosTitulo = obj26.gxTpr_Textostitulo;
         A139MedidasEstado = obj26.gxTpr_Medidasestado;
         n139MedidasEstado = false;
         if ( forceLoad == 1 )
         {
            A137MedidasID = obj26.gxTpr_Medidasid;
         }
         Z137MedidasID = obj26.gxTpr_Medidasid_Z;
         Z138MedidasNombre = obj26.gxTpr_Medidasnombre_Z;
         Z118MonedaId = obj26.gxTpr_Monedaid_Z;
         Z215RubrosCosto = obj26.gxTpr_Rubroscosto_Z;
         Z216RubrosPrecioBase = obj26.gxTpr_Rubrospreciobase_Z;
         Z139MedidasEstado = obj26.gxTpr_Medidasestado_Z;
         Z150TextosId = obj26.gxTpr_Textosid_Z;
         Z259TextosTitulo = obj26.gxTpr_Textostitulo_Z;
         Z40001MedidasImagen_GXI = obj26.gxTpr_Medidasimagen_gxi_Z;
         n842MedidasImagen = (bool)(Convert.ToBoolean(obj26.gxTpr_Medidasimagen_N));
         n139MedidasEstado = (bool)(Convert.ToBoolean(obj26.gxTpr_Medidasestado_N));
         n150TextosId = (bool)(Convert.ToBoolean(obj26.gxTpr_Textosid_N));
         n40001MedidasImagen_GXI = (bool)(Convert.ToBoolean(obj26.gxTpr_Medidasimagen_gxi_N));
         nIsMod_26 = obj26.gxTpr_Modified;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A121RubrosId = (short)getParm(obj,0);
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey0U37( ) ;
         ScanKeyStart0U37( ) ;
         if ( RcdFound37 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z121RubrosId = A121RubrosId;
            O217RubrosMedidasSerial = A217RubrosMedidasSerial;
         }
         ZM0U37( -6) ;
         OnLoadActions0U37( ) ;
         AddRow0U37( ) ;
         bcRubrosMedidas.gxTpr_Medidas.ClearCollection();
         if ( RcdFound37 == 1 )
         {
            ScanKeyStart0U26( ) ;
            nGXsfl_26_idx = 1;
            while ( RcdFound26 != 0 )
            {
               Z121RubrosId = A121RubrosId;
               Z137MedidasID = A137MedidasID;
               ZM0U26( -7) ;
               OnLoadActions0U26( ) ;
               nRcdExists_26 = 1;
               nIsMod_26 = 0;
               AddRow0U26( ) ;
               nGXsfl_26_idx = (int)(nGXsfl_26_idx+1);
               ScanKeyNext0U26( ) ;
            }
            ScanKeyEnd0U26( ) ;
         }
         ScanKeyEnd0U37( ) ;
         if ( RcdFound37 == 0 )
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
         RowToVars37( bcRubrosMedidas, 0) ;
         ScanKeyStart0U37( ) ;
         if ( RcdFound37 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z121RubrosId = A121RubrosId;
            O217RubrosMedidasSerial = A217RubrosMedidasSerial;
         }
         ZM0U37( -6) ;
         OnLoadActions0U37( ) ;
         AddRow0U37( ) ;
         bcRubrosMedidas.gxTpr_Medidas.ClearCollection();
         if ( RcdFound37 == 1 )
         {
            ScanKeyStart0U26( ) ;
            nGXsfl_26_idx = 1;
            while ( RcdFound26 != 0 )
            {
               Z121RubrosId = A121RubrosId;
               Z137MedidasID = A137MedidasID;
               ZM0U26( -7) ;
               OnLoadActions0U26( ) ;
               nRcdExists_26 = 1;
               nIsMod_26 = 0;
               AddRow0U26( ) ;
               nGXsfl_26_idx = (int)(nGXsfl_26_idx+1);
               ScanKeyNext0U26( ) ;
            }
            ScanKeyEnd0U26( ) ;
         }
         ScanKeyEnd0U37( ) ;
         if ( RcdFound37 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         GetKey0U37( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            A217RubrosMedidasSerial = O217RubrosMedidasSerial;
            Insert0U37( ) ;
         }
         else
         {
            if ( RcdFound37 == 1 )
            {
               if ( A121RubrosId != Z121RubrosId )
               {
                  A121RubrosId = Z121RubrosId;
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "");
                  AnyError = 1;
               }
               else if ( IsDlt( ) )
               {
                  A217RubrosMedidasSerial = O217RubrosMedidasSerial;
                  delete( ) ;
                  AfterTrn( ) ;
               }
               else
               {
                  Gx_mode = "UPD";
                  /* Update record */
                  A217RubrosMedidasSerial = O217RubrosMedidasSerial;
                  Update0U37( ) ;
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
                  if ( A121RubrosId != Z121RubrosId )
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
                        A217RubrosMedidasSerial = O217RubrosMedidasSerial;
                        Insert0U37( ) ;
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
                        A217RubrosMedidasSerial = O217RubrosMedidasSerial;
                        Insert0U37( ) ;
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
         RowToVars37( bcRubrosMedidas, 1) ;
         SaveImpl( ) ;
         VarsToRow37( bcRubrosMedidas) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public bool Insert( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars37( bcRubrosMedidas, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         A217RubrosMedidasSerial = O217RubrosMedidasSerial;
         Insert0U37( ) ;
         AfterTrn( ) ;
         VarsToRow37( bcRubrosMedidas) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
            VarsToRow37( bcRubrosMedidas) ;
         }
         else
         {
            SdtRubrosMedidas auxBC = new SdtRubrosMedidas(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A121RubrosId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcRubrosMedidas);
               auxBC.Save();
               bcRubrosMedidas.Copy((GxSilentTrnSdt)(auxBC));
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
         RowToVars37( bcRubrosMedidas, 1) ;
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
         RowToVars37( bcRubrosMedidas, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert0U37( ) ;
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
               VarsToRow37( bcRubrosMedidas) ;
            }
         }
         else
         {
            AfterTrn( ) ;
            VarsToRow37( bcRubrosMedidas) ;
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
         RowToVars37( bcRubrosMedidas, 0) ;
         GetKey0U37( ) ;
         if ( RcdFound37 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( A121RubrosId != Z121RubrosId )
            {
               A121RubrosId = Z121RubrosId;
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
            if ( A121RubrosId != Z121RubrosId )
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
         pr_default.close(5);
         pr_default.close(1);
         pr_default.close(23);
         context.RollbackDataStores("rubrosmedidas_bc",pr_default);
         VarsToRow37( bcRubrosMedidas) ;
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
         Gx_mode = bcRubrosMedidas.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcRubrosMedidas.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcRubrosMedidas )
         {
            bcRubrosMedidas = (SdtRubrosMedidas)(sdt);
            if ( StringUtil.StrCmp(bcRubrosMedidas.gxTpr_Mode, "") == 0 )
            {
               bcRubrosMedidas.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow37( bcRubrosMedidas) ;
            }
            else
            {
               RowToVars37( bcRubrosMedidas, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcRubrosMedidas.gxTpr_Mode, "") == 0 )
            {
               bcRubrosMedidas.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars37( bcRubrosMedidas, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         return  ;
      }

      public SdtRubrosMedidas RubrosMedidas_BC
      {
         get {
            return bcRubrosMedidas ;
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
         pr_default.close(23);
         pr_default.close(5);
      }

      public override void initialize( )
      {
         Gx_mode = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         sMode37 = "";
         AV8WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV11TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV12WebSession = context.GetSession();
         Z122RubrosNombre = "";
         A122RubrosNombre = "";
         Z123RubrosEstado = "";
         A123RubrosEstado = "";
         Z168RubrosImagen = "";
         A168RubrosImagen = "";
         Z40000RubrosImagen_GXI = "";
         A40000RubrosImagen_GXI = "";
         BC000U8_A121RubrosId = new short[1] ;
         BC000U8_A122RubrosNombre = new string[] {""} ;
         BC000U8_A40000RubrosImagen_GXI = new string[] {""} ;
         BC000U8_A217RubrosMedidasSerial = new short[1] ;
         BC000U8_A123RubrosEstado = new string[] {""} ;
         BC000U8_n123RubrosEstado = new bool[] {false} ;
         BC000U8_A168RubrosImagen = new string[] {""} ;
         BC000U9_A121RubrosId = new short[1] ;
         BC000U7_A121RubrosId = new short[1] ;
         BC000U7_A122RubrosNombre = new string[] {""} ;
         BC000U7_A40000RubrosImagen_GXI = new string[] {""} ;
         BC000U7_A217RubrosMedidasSerial = new short[1] ;
         BC000U7_A123RubrosEstado = new string[] {""} ;
         BC000U7_n123RubrosEstado = new bool[] {false} ;
         BC000U7_A168RubrosImagen = new string[] {""} ;
         BC000U6_A121RubrosId = new short[1] ;
         BC000U6_A122RubrosNombre = new string[] {""} ;
         BC000U6_A40000RubrosImagen_GXI = new string[] {""} ;
         BC000U6_A217RubrosMedidasSerial = new short[1] ;
         BC000U6_A123RubrosEstado = new string[] {""} ;
         BC000U6_n123RubrosEstado = new bool[] {false} ;
         BC000U6_A168RubrosImagen = new string[] {""} ;
         BC000U10_A121RubrosId = new short[1] ;
         BC000U14_A804CapacidadProdId = new long[1] ;
         BC000U15_A120ProfesionalesId = new string[] {""} ;
         BC000U15_A121RubrosId = new short[1] ;
         BC000U16_A121RubrosId = new short[1] ;
         BC000U16_A137MedidasID = new long[1] ;
         BC000U16_A135InventarioId = new long[1] ;
         BC000U18_A121RubrosId = new short[1] ;
         BC000U18_A122RubrosNombre = new string[] {""} ;
         BC000U18_A40000RubrosImagen_GXI = new string[] {""} ;
         BC000U18_A217RubrosMedidasSerial = new short[1] ;
         BC000U18_A123RubrosEstado = new string[] {""} ;
         BC000U18_n123RubrosEstado = new bool[] {false} ;
         BC000U18_A168RubrosImagen = new string[] {""} ;
         Z139MedidasEstado = "";
         A139MedidasEstado = "";
         Z138MedidasNombre = "";
         A138MedidasNombre = "";
         Z259TextosTitulo = "";
         A259TextosTitulo = "";
         Z842MedidasImagen = "";
         A842MedidasImagen = "";
         Z40001MedidasImagen_GXI = "";
         A40001MedidasImagen_GXI = "";
         BC000U19_A121RubrosId = new short[1] ;
         BC000U19_A137MedidasID = new long[1] ;
         BC000U19_A139MedidasEstado = new string[] {""} ;
         BC000U19_n139MedidasEstado = new bool[] {false} ;
         BC000U19_A138MedidasNombre = new string[] {""} ;
         BC000U19_A40001MedidasImagen_GXI = new string[] {""} ;
         BC000U19_n40001MedidasImagen_GXI = new bool[] {false} ;
         BC000U19_A215RubrosCosto = new decimal[1] ;
         BC000U19_A216RubrosPrecioBase = new decimal[1] ;
         BC000U19_A259TextosTitulo = new string[] {""} ;
         BC000U19_A150TextosId = new long[1] ;
         BC000U19_n150TextosId = new bool[] {false} ;
         BC000U19_A118MonedaId = new short[1] ;
         BC000U19_A842MedidasImagen = new string[] {""} ;
         BC000U19_n842MedidasImagen = new bool[] {false} ;
         BC000U5_A118MonedaId = new short[1] ;
         BC000U4_A259TextosTitulo = new string[] {""} ;
         BC000U20_A121RubrosId = new short[1] ;
         BC000U20_A137MedidasID = new long[1] ;
         BC000U3_A121RubrosId = new short[1] ;
         BC000U3_A137MedidasID = new long[1] ;
         BC000U3_A139MedidasEstado = new string[] {""} ;
         BC000U3_n139MedidasEstado = new bool[] {false} ;
         BC000U3_A138MedidasNombre = new string[] {""} ;
         BC000U3_A40001MedidasImagen_GXI = new string[] {""} ;
         BC000U3_n40001MedidasImagen_GXI = new bool[] {false} ;
         BC000U3_A215RubrosCosto = new decimal[1] ;
         BC000U3_A216RubrosPrecioBase = new decimal[1] ;
         BC000U3_A150TextosId = new long[1] ;
         BC000U3_n150TextosId = new bool[] {false} ;
         BC000U3_A118MonedaId = new short[1] ;
         BC000U3_A842MedidasImagen = new string[] {""} ;
         BC000U3_n842MedidasImagen = new bool[] {false} ;
         sMode26 = "";
         BC000U2_A121RubrosId = new short[1] ;
         BC000U2_A137MedidasID = new long[1] ;
         BC000U2_A139MedidasEstado = new string[] {""} ;
         BC000U2_n139MedidasEstado = new bool[] {false} ;
         BC000U2_A138MedidasNombre = new string[] {""} ;
         BC000U2_A40001MedidasImagen_GXI = new string[] {""} ;
         BC000U2_n40001MedidasImagen_GXI = new bool[] {false} ;
         BC000U2_A215RubrosCosto = new decimal[1] ;
         BC000U2_A216RubrosPrecioBase = new decimal[1] ;
         BC000U2_A150TextosId = new long[1] ;
         BC000U2_n150TextosId = new bool[] {false} ;
         BC000U2_A118MonedaId = new short[1] ;
         BC000U2_A842MedidasImagen = new string[] {""} ;
         BC000U2_n842MedidasImagen = new bool[] {false} ;
         BC000U25_A259TextosTitulo = new string[] {""} ;
         BC000U26_A121RubrosId = new short[1] ;
         BC000U26_A137MedidasID = new long[1] ;
         BC000U26_A135InventarioId = new long[1] ;
         BC000U27_A121RubrosId = new short[1] ;
         BC000U27_A137MedidasID = new long[1] ;
         BC000U27_A139MedidasEstado = new string[] {""} ;
         BC000U27_n139MedidasEstado = new bool[] {false} ;
         BC000U27_A138MedidasNombre = new string[] {""} ;
         BC000U27_A40001MedidasImagen_GXI = new string[] {""} ;
         BC000U27_n40001MedidasImagen_GXI = new bool[] {false} ;
         BC000U27_A215RubrosCosto = new decimal[1] ;
         BC000U27_A216RubrosPrecioBase = new decimal[1] ;
         BC000U27_A259TextosTitulo = new string[] {""} ;
         BC000U27_A150TextosId = new long[1] ;
         BC000U27_n150TextosId = new bool[] {false} ;
         BC000U27_A118MonedaId = new short[1] ;
         BC000U27_A842MedidasImagen = new string[] {""} ;
         BC000U27_n842MedidasImagen = new bool[] {false} ;
         i139MedidasEstado = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.rubrosmedidas_bc__datastore1(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.rubrosmedidas_bc__default(),
            new Object[][] {
                new Object[] {
               BC000U2_A121RubrosId, BC000U2_A137MedidasID, BC000U2_A139MedidasEstado, BC000U2_n139MedidasEstado, BC000U2_A138MedidasNombre, BC000U2_A40001MedidasImagen_GXI, BC000U2_n40001MedidasImagen_GXI, BC000U2_A215RubrosCosto, BC000U2_A216RubrosPrecioBase, BC000U2_A150TextosId,
               BC000U2_n150TextosId, BC000U2_A118MonedaId, BC000U2_A842MedidasImagen, BC000U2_n842MedidasImagen
               }
               , new Object[] {
               BC000U3_A121RubrosId, BC000U3_A137MedidasID, BC000U3_A139MedidasEstado, BC000U3_n139MedidasEstado, BC000U3_A138MedidasNombre, BC000U3_A40001MedidasImagen_GXI, BC000U3_n40001MedidasImagen_GXI, BC000U3_A215RubrosCosto, BC000U3_A216RubrosPrecioBase, BC000U3_A150TextosId,
               BC000U3_n150TextosId, BC000U3_A118MonedaId, BC000U3_A842MedidasImagen, BC000U3_n842MedidasImagen
               }
               , new Object[] {
               BC000U4_A259TextosTitulo
               }
               , new Object[] {
               BC000U5_A118MonedaId
               }
               , new Object[] {
               BC000U6_A121RubrosId, BC000U6_A122RubrosNombre, BC000U6_A40000RubrosImagen_GXI, BC000U6_A217RubrosMedidasSerial, BC000U6_A123RubrosEstado, BC000U6_n123RubrosEstado, BC000U6_A168RubrosImagen
               }
               , new Object[] {
               BC000U7_A121RubrosId, BC000U7_A122RubrosNombre, BC000U7_A40000RubrosImagen_GXI, BC000U7_A217RubrosMedidasSerial, BC000U7_A123RubrosEstado, BC000U7_n123RubrosEstado, BC000U7_A168RubrosImagen
               }
               , new Object[] {
               BC000U8_A121RubrosId, BC000U8_A122RubrosNombre, BC000U8_A40000RubrosImagen_GXI, BC000U8_A217RubrosMedidasSerial, BC000U8_A123RubrosEstado, BC000U8_n123RubrosEstado, BC000U8_A168RubrosImagen
               }
               , new Object[] {
               BC000U9_A121RubrosId
               }
               , new Object[] {
               BC000U10_A121RubrosId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC000U14_A804CapacidadProdId
               }
               , new Object[] {
               BC000U15_A120ProfesionalesId, BC000U15_A121RubrosId
               }
               , new Object[] {
               BC000U16_A121RubrosId, BC000U16_A137MedidasID, BC000U16_A135InventarioId
               }
               , new Object[] {
               }
               , new Object[] {
               BC000U18_A121RubrosId, BC000U18_A122RubrosNombre, BC000U18_A40000RubrosImagen_GXI, BC000U18_A217RubrosMedidasSerial, BC000U18_A123RubrosEstado, BC000U18_n123RubrosEstado, BC000U18_A168RubrosImagen
               }
               , new Object[] {
               BC000U19_A121RubrosId, BC000U19_A137MedidasID, BC000U19_A139MedidasEstado, BC000U19_n139MedidasEstado, BC000U19_A138MedidasNombre, BC000U19_A40001MedidasImagen_GXI, BC000U19_n40001MedidasImagen_GXI, BC000U19_A215RubrosCosto, BC000U19_A216RubrosPrecioBase, BC000U19_A259TextosTitulo,
               BC000U19_A150TextosId, BC000U19_n150TextosId, BC000U19_A118MonedaId, BC000U19_A842MedidasImagen, BC000U19_n842MedidasImagen
               }
               , new Object[] {
               BC000U20_A121RubrosId, BC000U20_A137MedidasID
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC000U25_A259TextosTitulo
               }
               , new Object[] {
               BC000U26_A121RubrosId, BC000U26_A137MedidasID, BC000U26_A135InventarioId
               }
               , new Object[] {
               BC000U27_A121RubrosId, BC000U27_A137MedidasID, BC000U27_A139MedidasEstado, BC000U27_n139MedidasEstado, BC000U27_A138MedidasNombre, BC000U27_A40001MedidasImagen_GXI, BC000U27_n40001MedidasImagen_GXI, BC000U27_A215RubrosCosto, BC000U27_A216RubrosPrecioBase, BC000U27_A259TextosTitulo,
               BC000U27_A150TextosId, BC000U27_n150TextosId, BC000U27_A118MonedaId, BC000U27_A842MedidasImagen, BC000U27_n842MedidasImagen
               }
            }
         );
         Z139MedidasEstado = "HAB";
         n139MedidasEstado = false;
         A139MedidasEstado = "HAB";
         n139MedidasEstado = false;
         i139MedidasEstado = "HAB";
         n139MedidasEstado = false;
         INITTRN();
         /* Execute Start event if defined. */
         /* Execute user event: Start */
         E120U2 ();
         standaloneNotModal( ) ;
      }

      private short AnyError ;
      private short Z121RubrosId ;
      private short A121RubrosId ;
      private short s217RubrosMedidasSerial ;
      private short O217RubrosMedidasSerial ;
      private short A217RubrosMedidasSerial ;
      private short nIsMod_26 ;
      private short RcdFound26 ;
      private short Z217RubrosMedidasSerial ;
      private short Gx_BScreen ;
      private short RcdFound37 ;
      private short nRcdExists_26 ;
      private short Z118MonedaId ;
      private short A118MonedaId ;
      private short Gxremove26 ;
      private short i217RubrosMedidasSerial ;
      private int trnEnded ;
      private int nGXsfl_26_idx=1 ;
      private long Z150TextosId ;
      private long A150TextosId ;
      private long Z137MedidasID ;
      private long A137MedidasID ;
      private decimal Z215RubrosCosto ;
      private decimal A215RubrosCosto ;
      private decimal Z216RubrosPrecioBase ;
      private decimal A216RubrosPrecioBase ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string sMode37 ;
      private string Z122RubrosNombre ;
      private string A122RubrosNombre ;
      private string Z123RubrosEstado ;
      private string A123RubrosEstado ;
      private string Z139MedidasEstado ;
      private string A139MedidasEstado ;
      private string Z138MedidasNombre ;
      private string A138MedidasNombre ;
      private string Z259TextosTitulo ;
      private string A259TextosTitulo ;
      private string sMode26 ;
      private string i139MedidasEstado ;
      private bool returnInSub ;
      private bool n123RubrosEstado ;
      private bool n139MedidasEstado ;
      private bool n40001MedidasImagen_GXI ;
      private bool n150TextosId ;
      private bool n842MedidasImagen ;
      private bool Gx_longc ;
      private string Z40000RubrosImagen_GXI ;
      private string A40000RubrosImagen_GXI ;
      private string Z40001MedidasImagen_GXI ;
      private string A40001MedidasImagen_GXI ;
      private string Z168RubrosImagen ;
      private string A168RubrosImagen ;
      private string Z842MedidasImagen ;
      private string A842MedidasImagen ;
      private IGxSession AV12WebSession ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private SdtRubrosMedidas bcRubrosMedidas ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV11TrnContext ;
      private IDataStoreProvider pr_default ;
      private short[] BC000U8_A121RubrosId ;
      private string[] BC000U8_A122RubrosNombre ;
      private string[] BC000U8_A40000RubrosImagen_GXI ;
      private short[] BC000U8_A217RubrosMedidasSerial ;
      private string[] BC000U8_A123RubrosEstado ;
      private bool[] BC000U8_n123RubrosEstado ;
      private string[] BC000U8_A168RubrosImagen ;
      private short[] BC000U9_A121RubrosId ;
      private short[] BC000U7_A121RubrosId ;
      private string[] BC000U7_A122RubrosNombre ;
      private string[] BC000U7_A40000RubrosImagen_GXI ;
      private short[] BC000U7_A217RubrosMedidasSerial ;
      private string[] BC000U7_A123RubrosEstado ;
      private bool[] BC000U7_n123RubrosEstado ;
      private string[] BC000U7_A168RubrosImagen ;
      private short[] BC000U6_A121RubrosId ;
      private string[] BC000U6_A122RubrosNombre ;
      private string[] BC000U6_A40000RubrosImagen_GXI ;
      private short[] BC000U6_A217RubrosMedidasSerial ;
      private string[] BC000U6_A123RubrosEstado ;
      private bool[] BC000U6_n123RubrosEstado ;
      private string[] BC000U6_A168RubrosImagen ;
      private short[] BC000U10_A121RubrosId ;
      private long[] BC000U14_A804CapacidadProdId ;
      private string[] BC000U15_A120ProfesionalesId ;
      private short[] BC000U15_A121RubrosId ;
      private short[] BC000U16_A121RubrosId ;
      private long[] BC000U16_A137MedidasID ;
      private long[] BC000U16_A135InventarioId ;
      private short[] BC000U18_A121RubrosId ;
      private string[] BC000U18_A122RubrosNombre ;
      private string[] BC000U18_A40000RubrosImagen_GXI ;
      private short[] BC000U18_A217RubrosMedidasSerial ;
      private string[] BC000U18_A123RubrosEstado ;
      private bool[] BC000U18_n123RubrosEstado ;
      private string[] BC000U18_A168RubrosImagen ;
      private short[] BC000U19_A121RubrosId ;
      private long[] BC000U19_A137MedidasID ;
      private string[] BC000U19_A139MedidasEstado ;
      private bool[] BC000U19_n139MedidasEstado ;
      private string[] BC000U19_A138MedidasNombre ;
      private string[] BC000U19_A40001MedidasImagen_GXI ;
      private bool[] BC000U19_n40001MedidasImagen_GXI ;
      private decimal[] BC000U19_A215RubrosCosto ;
      private decimal[] BC000U19_A216RubrosPrecioBase ;
      private string[] BC000U19_A259TextosTitulo ;
      private long[] BC000U19_A150TextosId ;
      private bool[] BC000U19_n150TextosId ;
      private short[] BC000U19_A118MonedaId ;
      private string[] BC000U19_A842MedidasImagen ;
      private bool[] BC000U19_n842MedidasImagen ;
      private short[] BC000U5_A118MonedaId ;
      private string[] BC000U4_A259TextosTitulo ;
      private short[] BC000U20_A121RubrosId ;
      private long[] BC000U20_A137MedidasID ;
      private short[] BC000U3_A121RubrosId ;
      private long[] BC000U3_A137MedidasID ;
      private string[] BC000U3_A139MedidasEstado ;
      private bool[] BC000U3_n139MedidasEstado ;
      private string[] BC000U3_A138MedidasNombre ;
      private string[] BC000U3_A40001MedidasImagen_GXI ;
      private bool[] BC000U3_n40001MedidasImagen_GXI ;
      private decimal[] BC000U3_A215RubrosCosto ;
      private decimal[] BC000U3_A216RubrosPrecioBase ;
      private long[] BC000U3_A150TextosId ;
      private bool[] BC000U3_n150TextosId ;
      private short[] BC000U3_A118MonedaId ;
      private string[] BC000U3_A842MedidasImagen ;
      private bool[] BC000U3_n842MedidasImagen ;
      private short[] BC000U2_A121RubrosId ;
      private long[] BC000U2_A137MedidasID ;
      private string[] BC000U2_A139MedidasEstado ;
      private bool[] BC000U2_n139MedidasEstado ;
      private string[] BC000U2_A138MedidasNombre ;
      private string[] BC000U2_A40001MedidasImagen_GXI ;
      private bool[] BC000U2_n40001MedidasImagen_GXI ;
      private decimal[] BC000U2_A215RubrosCosto ;
      private decimal[] BC000U2_A216RubrosPrecioBase ;
      private long[] BC000U2_A150TextosId ;
      private bool[] BC000U2_n150TextosId ;
      private short[] BC000U2_A118MonedaId ;
      private string[] BC000U2_A842MedidasImagen ;
      private bool[] BC000U2_n842MedidasImagen ;
      private string[] BC000U25_A259TextosTitulo ;
      private short[] BC000U26_A121RubrosId ;
      private long[] BC000U26_A137MedidasID ;
      private long[] BC000U26_A135InventarioId ;
      private short[] BC000U27_A121RubrosId ;
      private long[] BC000U27_A137MedidasID ;
      private string[] BC000U27_A139MedidasEstado ;
      private bool[] BC000U27_n139MedidasEstado ;
      private string[] BC000U27_A138MedidasNombre ;
      private string[] BC000U27_A40001MedidasImagen_GXI ;
      private bool[] BC000U27_n40001MedidasImagen_GXI ;
      private decimal[] BC000U27_A215RubrosCosto ;
      private decimal[] BC000U27_A216RubrosPrecioBase ;
      private string[] BC000U27_A259TextosTitulo ;
      private long[] BC000U27_A150TextosId ;
      private bool[] BC000U27_n150TextosId ;
      private short[] BC000U27_A118MonedaId ;
      private string[] BC000U27_A842MedidasImagen ;
      private bool[] BC000U27_n842MedidasImagen ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_datastore1 ;
   }

   public class rubrosmedidas_bc__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class rubrosmedidas_bc__default : DataStoreHelperBase, IDataStoreHelper
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
       ,new ForEachCursor(def[6])
       ,new ForEachCursor(def[7])
       ,new ForEachCursor(def[8])
       ,new UpdateCursor(def[9])
       ,new UpdateCursor(def[10])
       ,new UpdateCursor(def[11])
       ,new ForEachCursor(def[12])
       ,new ForEachCursor(def[13])
       ,new ForEachCursor(def[14])
       ,new UpdateCursor(def[15])
       ,new ForEachCursor(def[16])
       ,new ForEachCursor(def[17])
       ,new ForEachCursor(def[18])
       ,new UpdateCursor(def[19])
       ,new UpdateCursor(def[20])
       ,new UpdateCursor(def[21])
       ,new UpdateCursor(def[22])
       ,new ForEachCursor(def[23])
       ,new ForEachCursor(def[24])
       ,new ForEachCursor(def[25])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmBC000U2;
        prmBC000U2 = new Object[] {
        new ParDef("@RubrosId",GXType.Int16,4,0) ,
        new ParDef("@MedidasID",GXType.Decimal,18,0)
        };
        Object[] prmBC000U3;
        prmBC000U3 = new Object[] {
        new ParDef("@RubrosId",GXType.Int16,4,0) ,
        new ParDef("@MedidasID",GXType.Decimal,18,0)
        };
        Object[] prmBC000U4;
        prmBC000U4 = new Object[] {
        new ParDef("@TextosId",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmBC000U5;
        prmBC000U5 = new Object[] {
        new ParDef("@MonedaId",GXType.Int16,4,0)
        };
        Object[] prmBC000U6;
        prmBC000U6 = new Object[] {
        new ParDef("@RubrosId",GXType.Int16,4,0)
        };
        Object[] prmBC000U7;
        prmBC000U7 = new Object[] {
        new ParDef("@RubrosId",GXType.Int16,4,0)
        };
        Object[] prmBC000U8;
        prmBC000U8 = new Object[] {
        new ParDef("@RubrosId",GXType.Int16,4,0)
        };
        Object[] prmBC000U9;
        prmBC000U9 = new Object[] {
        new ParDef("@RubrosId",GXType.Int16,4,0)
        };
        Object[] prmBC000U10;
        prmBC000U10 = new Object[] {
        new ParDef("@RubrosNombre",GXType.NChar,100,0) ,
        new ParDef("@RubrosImagen",GXType.Blob,1024,0){InDB=false} ,
        new ParDef("@RubrosImagen_GXI",GXType.VarChar,2048,0){AddAtt=true, ImgIdx=1, Tbl="Rubros", Fld="RubrosImagen"} ,
        new ParDef("@RubrosMedidasSerial",GXType.Int16,4,0) ,
        new ParDef("@RubrosEstado",GXType.NChar,3,0){Nullable=true}
        };
        Object[] prmBC000U11;
        prmBC000U11 = new Object[] {
        new ParDef("@RubrosNombre",GXType.NChar,100,0) ,
        new ParDef("@RubrosMedidasSerial",GXType.Int16,4,0) ,
        new ParDef("@RubrosEstado",GXType.NChar,3,0){Nullable=true} ,
        new ParDef("@RubrosId",GXType.Int16,4,0)
        };
        Object[] prmBC000U12;
        prmBC000U12 = new Object[] {
        new ParDef("@RubrosImagen",GXType.Blob,1024,0){InDB=false} ,
        new ParDef("@RubrosImagen_GXI",GXType.VarChar,2048,0){AddAtt=true, ImgIdx=0, Tbl="Rubros", Fld="RubrosImagen"} ,
        new ParDef("@RubrosId",GXType.Int16,4,0)
        };
        Object[] prmBC000U13;
        prmBC000U13 = new Object[] {
        new ParDef("@RubrosId",GXType.Int16,4,0)
        };
        Object[] prmBC000U14;
        prmBC000U14 = new Object[] {
        new ParDef("@RubrosId",GXType.Int16,4,0)
        };
        Object[] prmBC000U15;
        prmBC000U15 = new Object[] {
        new ParDef("@RubrosId",GXType.Int16,4,0)
        };
        Object[] prmBC000U16;
        prmBC000U16 = new Object[] {
        new ParDef("@RubrosId",GXType.Int16,4,0)
        };
        Object[] prmBC000U17;
        prmBC000U17 = new Object[] {
        new ParDef("@RubrosMedidasSerial",GXType.Int16,4,0) ,
        new ParDef("@RubrosId",GXType.Int16,4,0)
        };
        Object[] prmBC000U18;
        prmBC000U18 = new Object[] {
        new ParDef("@RubrosId",GXType.Int16,4,0)
        };
        Object[] prmBC000U19;
        prmBC000U19 = new Object[] {
        new ParDef("@RubrosId",GXType.Int16,4,0) ,
        new ParDef("@MedidasID",GXType.Decimal,18,0)
        };
        Object[] prmBC000U20;
        prmBC000U20 = new Object[] {
        new ParDef("@RubrosId",GXType.Int16,4,0) ,
        new ParDef("@MedidasID",GXType.Decimal,18,0)
        };
        Object[] prmBC000U21;
        prmBC000U21 = new Object[] {
        new ParDef("@RubrosId",GXType.Int16,4,0) ,
        new ParDef("@MedidasID",GXType.Decimal,18,0) ,
        new ParDef("@MedidasEstado",GXType.NChar,3,0){Nullable=true} ,
        new ParDef("@MedidasNombre",GXType.NChar,50,0) ,
        new ParDef("@MedidasImagen",GXType.Blob,1024,0){Nullable=true,InDB=false} ,
        new ParDef("@MedidasImagen_GXI",GXType.VarChar,2048,0){Nullable=true,AddAtt=true, ImgIdx=4, Tbl="RubrosMedidas", Fld="MedidasImagen"} ,
        new ParDef("@RubrosCosto",GXType.Decimal,18,2) ,
        new ParDef("@RubrosPrecioBase",GXType.Decimal,18,2) ,
        new ParDef("@TextosId",GXType.Decimal,18,0){Nullable=true} ,
        new ParDef("@MonedaId",GXType.Int16,4,0)
        };
        Object[] prmBC000U22;
        prmBC000U22 = new Object[] {
        new ParDef("@MedidasEstado",GXType.NChar,3,0){Nullable=true} ,
        new ParDef("@MedidasNombre",GXType.NChar,50,0) ,
        new ParDef("@RubrosCosto",GXType.Decimal,18,2) ,
        new ParDef("@RubrosPrecioBase",GXType.Decimal,18,2) ,
        new ParDef("@TextosId",GXType.Decimal,18,0){Nullable=true} ,
        new ParDef("@MonedaId",GXType.Int16,4,0) ,
        new ParDef("@RubrosId",GXType.Int16,4,0) ,
        new ParDef("@MedidasID",GXType.Decimal,18,0)
        };
        Object[] prmBC000U23;
        prmBC000U23 = new Object[] {
        new ParDef("@MedidasImagen",GXType.Blob,1024,0){Nullable=true,InDB=false} ,
        new ParDef("@MedidasImagen_GXI",GXType.VarChar,2048,0){Nullable=true,AddAtt=true, ImgIdx=0, Tbl="RubrosMedidas", Fld="MedidasImagen"} ,
        new ParDef("@RubrosId",GXType.Int16,4,0) ,
        new ParDef("@MedidasID",GXType.Decimal,18,0)
        };
        Object[] prmBC000U24;
        prmBC000U24 = new Object[] {
        new ParDef("@RubrosId",GXType.Int16,4,0) ,
        new ParDef("@MedidasID",GXType.Decimal,18,0)
        };
        Object[] prmBC000U25;
        prmBC000U25 = new Object[] {
        new ParDef("@TextosId",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmBC000U26;
        prmBC000U26 = new Object[] {
        new ParDef("@RubrosId",GXType.Int16,4,0) ,
        new ParDef("@MedidasID",GXType.Decimal,18,0)
        };
        Object[] prmBC000U27;
        prmBC000U27 = new Object[] {
        new ParDef("@RubrosId",GXType.Int16,4,0)
        };
        def= new CursorDef[] {
            new CursorDef("BC000U2", "SELECT [RubrosId], [MedidasID], [MedidasEstado], [MedidasNombre], [MedidasImagen_GXI], [RubrosCosto], [RubrosPrecioBase], [TextosId], [MonedaId], [MedidasImagen] FROM [RubrosMedidas] WITH (UPDLOCK) WHERE [RubrosId] = @RubrosId AND [MedidasID] = @MedidasID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000U2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000U3", "SELECT [RubrosId], [MedidasID], [MedidasEstado], [MedidasNombre], [MedidasImagen_GXI], [RubrosCosto], [RubrosPrecioBase], [TextosId], [MonedaId], [MedidasImagen] FROM [RubrosMedidas] WHERE [RubrosId] = @RubrosId AND [MedidasID] = @MedidasID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000U3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000U4", "SELECT [TextosTitulo] FROM [Textos] WHERE [TextosId] = @TextosId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000U4,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000U5", "SELECT [MonedaId] FROM [Moneda] WHERE [MonedaId] = @MonedaId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000U5,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000U6", "SELECT [RubrosId], [RubrosNombre], [RubrosImagen_GXI], [RubrosMedidasSerial], [RubrosEstado], [RubrosImagen] FROM [Rubros] WITH (UPDLOCK) WHERE [RubrosId] = @RubrosId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000U6,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000U7", "SELECT [RubrosId], [RubrosNombre], [RubrosImagen_GXI], [RubrosMedidasSerial], [RubrosEstado], [RubrosImagen] FROM [Rubros] WHERE [RubrosId] = @RubrosId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000U7,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000U8", "SELECT TM1.[RubrosId], TM1.[RubrosNombre], TM1.[RubrosImagen_GXI], TM1.[RubrosMedidasSerial], TM1.[RubrosEstado], TM1.[RubrosImagen] FROM [Rubros] TM1 WHERE TM1.[RubrosId] = @RubrosId ORDER BY TM1.[RubrosId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmBC000U8,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000U9", "SELECT [RubrosId] FROM [Rubros] WHERE [RubrosId] = @RubrosId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmBC000U9,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000U10", "INSERT INTO [Rubros]([RubrosNombre], [RubrosImagen], [RubrosImagen_GXI], [RubrosMedidasSerial], [RubrosEstado], [RubrosDefault], [RubrosImagenURL]) VALUES(@RubrosNombre, @RubrosImagen, @RubrosImagen_GXI, @RubrosMedidasSerial, @RubrosEstado, convert(bit, 0), ''); SELECT SCOPE_IDENTITY()",true, GxErrorMask.GX_NOMASK, false, this,prmBC000U10,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("BC000U11", "UPDATE [Rubros] SET [RubrosNombre]=@RubrosNombre, [RubrosMedidasSerial]=@RubrosMedidasSerial, [RubrosEstado]=@RubrosEstado  WHERE [RubrosId] = @RubrosId", GxErrorMask.GX_NOMASK,prmBC000U11)
           ,new CursorDef("BC000U12", "UPDATE [Rubros] SET [RubrosImagen]=@RubrosImagen, [RubrosImagen_GXI]=@RubrosImagen_GXI  WHERE [RubrosId] = @RubrosId", GxErrorMask.GX_NOMASK,prmBC000U12)
           ,new CursorDef("BC000U13", "DELETE FROM [Rubros]  WHERE [RubrosId] = @RubrosId", GxErrorMask.GX_NOMASK,prmBC000U13)
           ,new CursorDef("BC000U14", "SELECT TOP 1 [CapacidadProdId] FROM [CapacidadProductiva] WHERE [RubrosId] = @RubrosId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000U14,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("BC000U15", "SELECT TOP 1 [ProfesionalesId], [RubrosId] FROM [ProfesionalesRubros] WHERE [RubrosId] = @RubrosId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000U15,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("BC000U16", "SELECT TOP 1 [RubrosId], [MedidasID], [InventarioId] FROM [Inventario] WHERE [RubrosId] = @RubrosId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000U16,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("BC000U17", "UPDATE [Rubros] SET [RubrosMedidasSerial]=@RubrosMedidasSerial  WHERE [RubrosId] = @RubrosId", GxErrorMask.GX_NOMASK,prmBC000U17)
           ,new CursorDef("BC000U18", "SELECT TM1.[RubrosId], TM1.[RubrosNombre], TM1.[RubrosImagen_GXI], TM1.[RubrosMedidasSerial], TM1.[RubrosEstado], TM1.[RubrosImagen] FROM [Rubros] TM1 WHERE TM1.[RubrosId] = @RubrosId ORDER BY TM1.[RubrosId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmBC000U18,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000U19", "SELECT T1.[RubrosId], T1.[MedidasID], T1.[MedidasEstado], T1.[MedidasNombre], T1.[MedidasImagen_GXI], T1.[RubrosCosto], T1.[RubrosPrecioBase], T2.[TextosTitulo], T1.[TextosId], T1.[MonedaId], T1.[MedidasImagen] FROM ([RubrosMedidas] T1 LEFT JOIN [Textos] T2 ON T2.[TextosId] = T1.[TextosId]) WHERE T1.[RubrosId] = @RubrosId and T1.[MedidasID] = @MedidasID ORDER BY T1.[RubrosId], T1.[MedidasID]  OPTION (FAST 11)",true, GxErrorMask.GX_NOMASK, false, this,prmBC000U19,11, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000U20", "SELECT [RubrosId], [MedidasID] FROM [RubrosMedidas] WHERE [RubrosId] = @RubrosId AND [MedidasID] = @MedidasID  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmBC000U20,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000U21", "INSERT INTO [RubrosMedidas]([RubrosId], [MedidasID], [MedidasEstado], [MedidasNombre], [MedidasImagen], [MedidasImagen_GXI], [RubrosCosto], [RubrosPrecioBase], [TextosId], [MonedaId], [InventarioSerial]) VALUES(@RubrosId, @MedidasID, @MedidasEstado, @MedidasNombre, @MedidasImagen, @MedidasImagen_GXI, @RubrosCosto, @RubrosPrecioBase, @TextosId, @MonedaId, convert(int, 0))", GxErrorMask.GX_NOMASK,prmBC000U21)
           ,new CursorDef("BC000U22", "UPDATE [RubrosMedidas] SET [MedidasEstado]=@MedidasEstado, [MedidasNombre]=@MedidasNombre, [RubrosCosto]=@RubrosCosto, [RubrosPrecioBase]=@RubrosPrecioBase, [TextosId]=@TextosId, [MonedaId]=@MonedaId  WHERE [RubrosId] = @RubrosId AND [MedidasID] = @MedidasID", GxErrorMask.GX_NOMASK,prmBC000U22)
           ,new CursorDef("BC000U23", "UPDATE [RubrosMedidas] SET [MedidasImagen]=@MedidasImagen, [MedidasImagen_GXI]=@MedidasImagen_GXI  WHERE [RubrosId] = @RubrosId AND [MedidasID] = @MedidasID", GxErrorMask.GX_NOMASK,prmBC000U23)
           ,new CursorDef("BC000U24", "DELETE FROM [RubrosMedidas]  WHERE [RubrosId] = @RubrosId AND [MedidasID] = @MedidasID", GxErrorMask.GX_NOMASK,prmBC000U24)
           ,new CursorDef("BC000U25", "SELECT [TextosTitulo] FROM [Textos] WHERE [TextosId] = @TextosId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000U25,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000U26", "SELECT TOP 1 [RubrosId], [MedidasID], [InventarioId] FROM [Inventario] WHERE [RubrosId] = @RubrosId AND [MedidasID] = @MedidasID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000U26,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("BC000U27", "SELECT T1.[RubrosId], T1.[MedidasID], T1.[MedidasEstado], T1.[MedidasNombre], T1.[MedidasImagen_GXI], T1.[RubrosCosto], T1.[RubrosPrecioBase], T2.[TextosTitulo], T1.[TextosId], T1.[MonedaId], T1.[MedidasImagen] FROM ([RubrosMedidas] T1 LEFT JOIN [Textos] T2 ON T2.[TextosId] = T1.[TextosId]) WHERE T1.[RubrosId] = @RubrosId ORDER BY T1.[RubrosId], T1.[MedidasID]  OPTION (FAST 11)",true, GxErrorMask.GX_NOMASK, false, this,prmBC000U27,11, GxCacheFrequency.OFF ,true,false )
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
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              ((string[]) buf[2])[0] = rslt.getString(3, 3);
              ((bool[]) buf[3])[0] = rslt.wasNull(3);
              ((string[]) buf[4])[0] = rslt.getString(4, 50);
              ((string[]) buf[5])[0] = rslt.getMultimediaUri(5);
              ((bool[]) buf[6])[0] = rslt.wasNull(5);
              ((decimal[]) buf[7])[0] = rslt.getDecimal(6);
              ((decimal[]) buf[8])[0] = rslt.getDecimal(7);
              ((long[]) buf[9])[0] = rslt.getLong(8);
              ((bool[]) buf[10])[0] = rslt.wasNull(8);
              ((short[]) buf[11])[0] = rslt.getShort(9);
              ((string[]) buf[12])[0] = rslt.getMultimediaFile(10, rslt.getVarchar(5));
              ((bool[]) buf[13])[0] = rslt.wasNull(10);
              return;
           case 1 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              ((string[]) buf[2])[0] = rslt.getString(3, 3);
              ((bool[]) buf[3])[0] = rslt.wasNull(3);
              ((string[]) buf[4])[0] = rslt.getString(4, 50);
              ((string[]) buf[5])[0] = rslt.getMultimediaUri(5);
              ((bool[]) buf[6])[0] = rslt.wasNull(5);
              ((decimal[]) buf[7])[0] = rslt.getDecimal(6);
              ((decimal[]) buf[8])[0] = rslt.getDecimal(7);
              ((long[]) buf[9])[0] = rslt.getLong(8);
              ((bool[]) buf[10])[0] = rslt.wasNull(8);
              ((short[]) buf[11])[0] = rslt.getShort(9);
              ((string[]) buf[12])[0] = rslt.getMultimediaFile(10, rslt.getVarchar(5));
              ((bool[]) buf[13])[0] = rslt.wasNull(10);
              return;
           case 2 :
              ((string[]) buf[0])[0] = rslt.getString(1, 80);
              return;
           case 3 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              return;
           case 4 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 100);
              ((string[]) buf[2])[0] = rslt.getMultimediaUri(3);
              ((short[]) buf[3])[0] = rslt.getShort(4);
              ((string[]) buf[4])[0] = rslt.getString(5, 3);
              ((bool[]) buf[5])[0] = rslt.wasNull(5);
              ((string[]) buf[6])[0] = rslt.getMultimediaFile(6, rslt.getVarchar(3));
              return;
           case 5 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 100);
              ((string[]) buf[2])[0] = rslt.getMultimediaUri(3);
              ((short[]) buf[3])[0] = rslt.getShort(4);
              ((string[]) buf[4])[0] = rslt.getString(5, 3);
              ((bool[]) buf[5])[0] = rslt.wasNull(5);
              ((string[]) buf[6])[0] = rslt.getMultimediaFile(6, rslt.getVarchar(3));
              return;
           case 6 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 100);
              ((string[]) buf[2])[0] = rslt.getMultimediaUri(3);
              ((short[]) buf[3])[0] = rslt.getShort(4);
              ((string[]) buf[4])[0] = rslt.getString(5, 3);
              ((bool[]) buf[5])[0] = rslt.wasNull(5);
              ((string[]) buf[6])[0] = rslt.getMultimediaFile(6, rslt.getVarchar(3));
              return;
           case 7 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              return;
           case 8 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              return;
           case 12 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 13 :
              ((string[]) buf[0])[0] = rslt.getString(1, 20);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              return;
           case 14 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              ((long[]) buf[2])[0] = rslt.getLong(3);
              return;
           case 16 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 100);
              ((string[]) buf[2])[0] = rslt.getMultimediaUri(3);
              ((short[]) buf[3])[0] = rslt.getShort(4);
              ((string[]) buf[4])[0] = rslt.getString(5, 3);
              ((bool[]) buf[5])[0] = rslt.wasNull(5);
              ((string[]) buf[6])[0] = rslt.getMultimediaFile(6, rslt.getVarchar(3));
              return;
           case 17 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              ((string[]) buf[2])[0] = rslt.getString(3, 3);
              ((bool[]) buf[3])[0] = rslt.wasNull(3);
              ((string[]) buf[4])[0] = rslt.getString(4, 50);
              ((string[]) buf[5])[0] = rslt.getMultimediaUri(5);
              ((bool[]) buf[6])[0] = rslt.wasNull(5);
              ((decimal[]) buf[7])[0] = rslt.getDecimal(6);
              ((decimal[]) buf[8])[0] = rslt.getDecimal(7);
              ((string[]) buf[9])[0] = rslt.getString(8, 80);
              ((long[]) buf[10])[0] = rslt.getLong(9);
              ((bool[]) buf[11])[0] = rslt.wasNull(9);
              ((short[]) buf[12])[0] = rslt.getShort(10);
              ((string[]) buf[13])[0] = rslt.getMultimediaFile(11, rslt.getVarchar(5));
              ((bool[]) buf[14])[0] = rslt.wasNull(11);
              return;
           case 18 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              return;
           case 23 :
              ((string[]) buf[0])[0] = rslt.getString(1, 80);
              return;
           case 24 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              ((long[]) buf[2])[0] = rslt.getLong(3);
              return;
           case 25 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              ((string[]) buf[2])[0] = rslt.getString(3, 3);
              ((bool[]) buf[3])[0] = rslt.wasNull(3);
              ((string[]) buf[4])[0] = rslt.getString(4, 50);
              ((string[]) buf[5])[0] = rslt.getMultimediaUri(5);
              ((bool[]) buf[6])[0] = rslt.wasNull(5);
              ((decimal[]) buf[7])[0] = rslt.getDecimal(6);
              ((decimal[]) buf[8])[0] = rslt.getDecimal(7);
              ((string[]) buf[9])[0] = rslt.getString(8, 80);
              ((long[]) buf[10])[0] = rslt.getLong(9);
              ((bool[]) buf[11])[0] = rslt.wasNull(9);
              ((short[]) buf[12])[0] = rslt.getShort(10);
              ((string[]) buf[13])[0] = rslt.getMultimediaFile(11, rslt.getVarchar(5));
              ((bool[]) buf[14])[0] = rslt.wasNull(11);
              return;
     }
  }

}

}

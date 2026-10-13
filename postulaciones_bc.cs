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
   public class postulaciones_bc : GXHttpHandler, IGxSilentTrn
   {
      public postulaciones_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public postulaciones_bc( IGxContext context )
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
         ReadRow1K126( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey1K126( ) ;
         standaloneModal( ) ;
         AddRow1K126( ) ;
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
            E111K2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               Z422PostulacionesId = A422PostulacionesId;
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

      protected void CONFIRM_1K0( )
      {
         BeforeValidate1K126( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls1K126( ) ;
            }
            else
            {
               CheckExtendedTable1K126( ) ;
               if ( AnyError == 0 )
               {
                  ZM1K126( 17) ;
                  ZM1K126( 18) ;
                  ZM1K126( 19) ;
               }
               CloseExtendedTableCursors1K126( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            /* Save parent mode. */
            sMode126 = Gx_mode;
            CONFIRM_1K142( ) ;
            if ( AnyError == 0 )
            {
               CONFIRM_1K139( ) ;
               if ( AnyError == 0 )
               {
                  CONFIRM_1K137( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Restore parent mode. */
                     Gx_mode = sMode126;
                  }
               }
            }
            /* Restore parent mode. */
            Gx_mode = sMode126;
         }
      }

      protected void CONFIRM_1K137( )
      {
         nGXsfl_137_idx = 0;
         while ( nGXsfl_137_idx < bcPostulaciones.gxTpr_Profesionales.Count )
         {
            ReadRow1K137( ) ;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( Gx_mode)) )
            {
               if ( RcdFound137 == 0 )
               {
                  Gx_mode = "INS";
               }
               else
               {
                  Gx_mode = "UPD";
               }
            }
            if ( ! IsIns( ) || ( nIsMod_137 != 0 ) )
            {
               GetKey1K137( ) ;
               if ( IsIns( ) && ! IsDlt( ) )
               {
                  if ( RcdFound137 == 0 )
                  {
                     Gx_mode = "INS";
                     BeforeValidate1K137( ) ;
                     if ( AnyError == 0 )
                     {
                        CheckExtendedTable1K137( ) ;
                        if ( AnyError == 0 )
                        {
                           ZM1K137( 24) ;
                        }
                        CloseExtendedTableCursors1K137( ) ;
                        if ( AnyError == 0 )
                        {
                        }
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
                  if ( RcdFound137 != 0 )
                  {
                     if ( IsDlt( ) )
                     {
                        Gx_mode = "DLT";
                        getByPrimaryKey1K137( ) ;
                        Load1K137( ) ;
                        BeforeValidate1K137( ) ;
                        if ( AnyError == 0 )
                        {
                           OnDeleteControls1K137( ) ;
                        }
                     }
                     else
                     {
                        if ( nIsMod_137 != 0 )
                        {
                           Gx_mode = "UPD";
                           BeforeValidate1K137( ) ;
                           if ( AnyError == 0 )
                           {
                              CheckExtendedTable1K137( ) ;
                              if ( AnyError == 0 )
                              {
                                 ZM1K137( 24) ;
                              }
                              CloseExtendedTableCursors1K137( ) ;
                              if ( AnyError == 0 )
                              {
                              }
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
               VarsToRow137( ((SdtPostulaciones_Profesionales)bcPostulaciones.gxTpr_Profesionales.Item(nGXsfl_137_idx))) ;
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
      }

      protected void CONFIRM_1K139( )
      {
         s961PostulacionesMultimediaSerial = O961PostulacionesMultimediaSerial;
         nGXsfl_139_idx = 0;
         while ( nGXsfl_139_idx < bcPostulaciones.gxTpr_Multimedia.Count )
         {
            ReadRow1K139( ) ;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( Gx_mode)) )
            {
               if ( RcdFound139 == 0 )
               {
                  Gx_mode = "INS";
               }
               else
               {
                  Gx_mode = "UPD";
               }
            }
            if ( ! IsIns( ) || ( nIsMod_139 != 0 ) )
            {
               GetKey1K139( ) ;
               if ( IsIns( ) && ! IsDlt( ) )
               {
                  if ( RcdFound139 == 0 )
                  {
                     Gx_mode = "INS";
                     BeforeValidate1K139( ) ;
                     if ( AnyError == 0 )
                     {
                        CheckExtendedTable1K139( ) ;
                        if ( AnyError == 0 )
                        {
                        }
                        CloseExtendedTableCursors1K139( ) ;
                        if ( AnyError == 0 )
                        {
                        }
                        O961PostulacionesMultimediaSerial = A961PostulacionesMultimediaSerial;
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
                  if ( RcdFound139 != 0 )
                  {
                     if ( IsDlt( ) )
                     {
                        Gx_mode = "DLT";
                        getByPrimaryKey1K139( ) ;
                        Load1K139( ) ;
                        BeforeValidate1K139( ) ;
                        if ( AnyError == 0 )
                        {
                           OnDeleteControls1K139( ) ;
                           O961PostulacionesMultimediaSerial = A961PostulacionesMultimediaSerial;
                        }
                     }
                     else
                     {
                        if ( nIsMod_139 != 0 )
                        {
                           Gx_mode = "UPD";
                           BeforeValidate1K139( ) ;
                           if ( AnyError == 0 )
                           {
                              CheckExtendedTable1K139( ) ;
                              if ( AnyError == 0 )
                              {
                              }
                              CloseExtendedTableCursors1K139( ) ;
                              if ( AnyError == 0 )
                              {
                              }
                              O961PostulacionesMultimediaSerial = A961PostulacionesMultimediaSerial;
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
               VarsToRow139( ((SdtPostulaciones_Multimedia)bcPostulaciones.gxTpr_Multimedia.Item(nGXsfl_139_idx))) ;
            }
         }
         O961PostulacionesMultimediaSerial = s961PostulacionesMultimediaSerial;
         /* Start of After( level) rules */
         /* End of After( level) rules */
      }

      protected void CONFIRM_1K142( )
      {
         nGXsfl_142_idx = 0;
         while ( nGXsfl_142_idx < bcPostulaciones.gxTpr_Categorias.Count )
         {
            ReadRow1K142( ) ;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( Gx_mode)) )
            {
               if ( RcdFound142 == 0 )
               {
                  Gx_mode = "INS";
               }
               else
               {
                  Gx_mode = "UPD";
               }
            }
            if ( ! IsIns( ) || ( nIsMod_142 != 0 ) )
            {
               GetKey1K142( ) ;
               if ( IsIns( ) && ! IsDlt( ) )
               {
                  if ( RcdFound142 == 0 )
                  {
                     Gx_mode = "INS";
                     BeforeValidate1K142( ) ;
                     if ( AnyError == 0 )
                     {
                        CheckExtendedTable1K142( ) ;
                        if ( AnyError == 0 )
                        {
                           ZM1K142( 21) ;
                        }
                        CloseExtendedTableCursors1K142( ) ;
                        if ( AnyError == 0 )
                        {
                        }
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
                  if ( RcdFound142 != 0 )
                  {
                     if ( IsDlt( ) )
                     {
                        Gx_mode = "DLT";
                        getByPrimaryKey1K142( ) ;
                        Load1K142( ) ;
                        BeforeValidate1K142( ) ;
                        if ( AnyError == 0 )
                        {
                           OnDeleteControls1K142( ) ;
                        }
                     }
                     else
                     {
                        if ( nIsMod_142 != 0 )
                        {
                           Gx_mode = "UPD";
                           BeforeValidate1K142( ) ;
                           if ( AnyError == 0 )
                           {
                              CheckExtendedTable1K142( ) ;
                              if ( AnyError == 0 )
                              {
                                 ZM1K142( 21) ;
                              }
                              CloseExtendedTableCursors1K142( ) ;
                              if ( AnyError == 0 )
                              {
                              }
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
               VarsToRow142( ((SdtPostulaciones_Categorias)bcPostulaciones.gxTpr_Categorias.Item(nGXsfl_142_idx))) ;
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
      }

      protected void E121K2( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV9WWPContext) ;
         AV10IsAuthorized = true;
         if ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )
         {
            GXt_boolean1 = AV10IsAuthorized;
            new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWPostulaciones_Insert", out  GXt_boolean1) ;
            AV10IsAuthorized = GXt_boolean1;
         }
         if ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 )
         {
            GXt_boolean1 = AV10IsAuthorized;
            new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWPostulaciones_Update", out  GXt_boolean1) ;
            AV10IsAuthorized = GXt_boolean1;
         }
         if ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 )
         {
            GXt_boolean1 = AV10IsAuthorized;
            new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWPostulaciones_Delete", out  GXt_boolean1) ;
            AV10IsAuthorized = GXt_boolean1;
         }
         if ( ! AV10IsAuthorized )
         {
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "wwpbaseobjects.notauthorized.aspx"+UrlEncode(StringUtil.RTrim(AV25Pgmname));
            CallWebObject(formatLink("wwpbaseobjects.notauthorized.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
            context.wjLocDisableFrm = 1;
         }
         AV12TrnContext.FromXml(AV13WebSession.Get("TrnContext"), null, "", "");
         if ( ( StringUtil.StrCmp(AV12TrnContext.gxTpr_Transactionname, AV25Pgmname) == 0 ) && ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) )
         {
            AV26GXV1 = 1;
            while ( AV26GXV1 <= AV12TrnContext.gxTpr_Attributes.Count )
            {
               AV15TrnContextAtt = ((GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute)AV12TrnContext.gxTpr_Attributes.Item(AV26GXV1));
               if ( StringUtil.StrCmp(AV15TrnContextAtt.gxTpr_Attributename, "ServiciosId") == 0 )
               {
                  AV14Insert_ServiciosId = (long)(Math.Round(NumberUtil.Val( AV15TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
               }
               else if ( StringUtil.StrCmp(AV15TrnContextAtt.gxTpr_Attributename, "PostulacionesProveedorId") == 0 )
               {
                  AV17Insert_PostulacionesProveedorId = (long)(Math.Round(NumberUtil.Val( AV15TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
               }
               AV26GXV1 = (int)(AV26GXV1+1);
            }
         }
         imgVermas_gximage = "prompt";
         AV24VerMas = context.GetImagePath( "f5b04895-0024-488b-8e3b-b687ca4598ee", "", context.GetTheme( ));
         AV27Vermas_GXI = GXDbFile.PathToUrl( context.GetImagePath( "f5b04895-0024-488b-8e3b-b687ca4598ee", "", context.GetTheme( )), context);
         imgVermas_Tooltiptext = context.GetMessage( "Ver aclaración", "");
      }

      protected void E111K2( )
      {
         /* After Trn Routine */
         returnInSub = false;
      }

      protected void E131K2( )
      {
         /* Vermas_Click Routine */
         returnInSub = false;
      }

      protected void ZM1K126( short GX_JID )
      {
         if ( ( GX_JID == 16 ) || ( GX_JID == 0 ) )
         {
            Z971PostulacionesProvNombreAux = A971PostulacionesProvNombreAux;
            Z946PostulacionesPrecio = A946PostulacionesPrecio;
            Z961PostulacionesMultimediaSerial = A961PostulacionesMultimediaSerial;
            Z936PostulacionesDescripcion = A936PostulacionesDescripcion;
            Z937PostulacionesReqSuministros = A937PostulacionesReqSuministros;
            Z938PostulacionesSuministrosDescri = A938PostulacionesSuministrosDescri;
            Z947PostulacionesFechaTrabajo = A947PostulacionesFechaTrabajo;
            Z939PostulacionesFechaCierre = A939PostulacionesFechaCierre;
            Z940PostulacionesHoraCierre = A940PostulacionesHoraCierre;
            Z941PostulacionesTipoFecha = A941PostulacionesTipoFecha;
            Z949PostulacionesRgoHoraservicio = A949PostulacionesRgoHoraservicio;
            Z950PostulacionesApellidoNombre = A950PostulacionesApellidoNombre;
            Z951PostulacionesMail = A951PostulacionesMail;
            Z952PostulacionesTelefono = A952PostulacionesTelefono;
            Z979PostulacionesDepartamentoId = A979PostulacionesDepartamentoId;
            Z980PostulacionesDepartamentoMunic = A980PostulacionesDepartamentoMunic;
            Z981PostulacionesZonasID = A981PostulacionesZonasID;
            Z998PostulacionesDireccion = A998PostulacionesDireccion;
            Z425PostulacionesFechaAlta = A425PostulacionesFechaAlta;
            Z424PostulacionesEstado = A424PostulacionesEstado;
            Z948PostulacionesSecUserId = A948PostulacionesSecUserId;
            Z942ServiciosId = A942ServiciosId;
            Z945PostulacionesProveedorId = A945PostulacionesProveedorId;
            Z970PostulacionesSolicitudesId = A970PostulacionesSolicitudesId;
         }
         if ( ( GX_JID == 17 ) || ( GX_JID == 0 ) )
         {
            Z970PostulacionesSolicitudesId = A970PostulacionesSolicitudesId;
         }
         if ( ( GX_JID == 18 ) || ( GX_JID == 0 ) )
         {
            Z943ServiciosNombre = A943ServiciosNombre;
            Z970PostulacionesSolicitudesId = A970PostulacionesSolicitudesId;
         }
         if ( ( GX_JID == 19 ) || ( GX_JID == 0 ) )
         {
            Z969PostulacionesProveedorNombre = A969PostulacionesProveedorNombre;
            Z970PostulacionesSolicitudesId = A970PostulacionesSolicitudesId;
         }
         if ( GX_JID == -16 )
         {
            Z422PostulacionesId = A422PostulacionesId;
            Z971PostulacionesProvNombreAux = A971PostulacionesProvNombreAux;
            Z946PostulacionesPrecio = A946PostulacionesPrecio;
            Z961PostulacionesMultimediaSerial = A961PostulacionesMultimediaSerial;
            Z936PostulacionesDescripcion = A936PostulacionesDescripcion;
            Z937PostulacionesReqSuministros = A937PostulacionesReqSuministros;
            Z938PostulacionesSuministrosDescri = A938PostulacionesSuministrosDescri;
            Z947PostulacionesFechaTrabajo = A947PostulacionesFechaTrabajo;
            Z939PostulacionesFechaCierre = A939PostulacionesFechaCierre;
            Z940PostulacionesHoraCierre = A940PostulacionesHoraCierre;
            Z941PostulacionesTipoFecha = A941PostulacionesTipoFecha;
            Z949PostulacionesRgoHoraservicio = A949PostulacionesRgoHoraservicio;
            Z950PostulacionesApellidoNombre = A950PostulacionesApellidoNombre;
            Z951PostulacionesMail = A951PostulacionesMail;
            Z952PostulacionesTelefono = A952PostulacionesTelefono;
            Z979PostulacionesDepartamentoId = A979PostulacionesDepartamentoId;
            Z980PostulacionesDepartamentoMunic = A980PostulacionesDepartamentoMunic;
            Z981PostulacionesZonasID = A981PostulacionesZonasID;
            Z998PostulacionesDireccion = A998PostulacionesDireccion;
            Z425PostulacionesFechaAlta = A425PostulacionesFechaAlta;
            Z424PostulacionesEstado = A424PostulacionesEstado;
            Z948PostulacionesSecUserId = A948PostulacionesSecUserId;
            Z942ServiciosId = A942ServiciosId;
            Z945PostulacionesProveedorId = A945PostulacionesProveedorId;
            Z970PostulacionesSolicitudesId = A970PostulacionesSolicitudesId;
            Z943ServiciosNombre = A943ServiciosNombre;
            Z969PostulacionesProveedorNombre = A969PostulacionesProveedorNombre;
         }
      }

      protected void standaloneNotModal( )
      {
         /* Using cursor BC001K13 */
         pr_default.execute(10, new Object[] {n422PostulacionesId, A422PostulacionesId});
         if ( (pr_default.getStatus(10) != 101) )
         {
            A970PostulacionesSolicitudesId = BC001K13_A970PostulacionesSolicitudesId[0];
            n970PostulacionesSolicitudesId = BC001K13_n970PostulacionesSolicitudesId[0];
         }
         else
         {
            A970PostulacionesSolicitudesId = 0;
            n970PostulacionesSolicitudesId = false;
         }
         pr_default.close(10);
      }

      protected void standaloneModal( )
      {
      }

      protected void Load1K126( )
      {
         /* Using cursor BC001K17 */
         pr_default.execute(13, new Object[] {n422PostulacionesId, A422PostulacionesId});
         if ( (pr_default.getStatus(13) != 101) )
         {
            RcdFound126 = 1;
            A943ServiciosNombre = BC001K17_A943ServiciosNombre[0];
            A971PostulacionesProvNombreAux = BC001K17_A971PostulacionesProvNombreAux[0];
            A969PostulacionesProveedorNombre = BC001K17_A969PostulacionesProveedorNombre[0];
            A946PostulacionesPrecio = BC001K17_A946PostulacionesPrecio[0];
            A961PostulacionesMultimediaSerial = BC001K17_A961PostulacionesMultimediaSerial[0];
            A936PostulacionesDescripcion = BC001K17_A936PostulacionesDescripcion[0];
            A937PostulacionesReqSuministros = BC001K17_A937PostulacionesReqSuministros[0];
            A938PostulacionesSuministrosDescri = BC001K17_A938PostulacionesSuministrosDescri[0];
            A947PostulacionesFechaTrabajo = BC001K17_A947PostulacionesFechaTrabajo[0];
            A939PostulacionesFechaCierre = BC001K17_A939PostulacionesFechaCierre[0];
            A940PostulacionesHoraCierre = BC001K17_A940PostulacionesHoraCierre[0];
            A941PostulacionesTipoFecha = BC001K17_A941PostulacionesTipoFecha[0];
            A949PostulacionesRgoHoraservicio = BC001K17_A949PostulacionesRgoHoraservicio[0];
            A950PostulacionesApellidoNombre = BC001K17_A950PostulacionesApellidoNombre[0];
            A951PostulacionesMail = BC001K17_A951PostulacionesMail[0];
            A952PostulacionesTelefono = BC001K17_A952PostulacionesTelefono[0];
            A979PostulacionesDepartamentoId = BC001K17_A979PostulacionesDepartamentoId[0];
            A980PostulacionesDepartamentoMunic = BC001K17_A980PostulacionesDepartamentoMunic[0];
            A981PostulacionesZonasID = BC001K17_A981PostulacionesZonasID[0];
            A998PostulacionesDireccion = BC001K17_A998PostulacionesDireccion[0];
            A425PostulacionesFechaAlta = BC001K17_A425PostulacionesFechaAlta[0];
            A424PostulacionesEstado = BC001K17_A424PostulacionesEstado[0];
            A948PostulacionesSecUserId = BC001K17_A948PostulacionesSecUserId[0];
            A942ServiciosId = BC001K17_A942ServiciosId[0];
            n942ServiciosId = BC001K17_n942ServiciosId[0];
            A945PostulacionesProveedorId = BC001K17_A945PostulacionesProveedorId[0];
            A970PostulacionesSolicitudesId = BC001K17_A970PostulacionesSolicitudesId[0];
            n970PostulacionesSolicitudesId = BC001K17_n970PostulacionesSolicitudesId[0];
            ZM1K126( -16) ;
         }
         pr_default.close(13);
         OnLoadActions1K126( ) ;
      }

      protected void OnLoadActions1K126( )
      {
         AV25Pgmname = "Postulaciones_BC";
      }

      protected void CheckExtendedTable1K126( )
      {
         standaloneModal( ) ;
         AV25Pgmname = "Postulaciones_BC";
         /* Using cursor BC001K14 */
         pr_default.execute(11, new Object[] {n942ServiciosId, A942ServiciosId});
         if ( (pr_default.getStatus(11) == 101) )
         {
            if ( ! ( (0==A942ServiciosId) ) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Servicios", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "SERVICIOSID");
               AnyError = 1;
            }
         }
         A943ServiciosNombre = BC001K14_A943ServiciosNombre[0];
         pr_default.close(11);
         /* Using cursor BC001K15 */
         pr_default.execute(12, new Object[] {A945PostulacionesProveedorId});
         if ( (pr_default.getStatus(12) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Postulaciones Proveedor", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "POSTULACIONESPROVEEDORID");
            AnyError = 1;
         }
         A969PostulacionesProveedorNombre = BC001K15_A969PostulacionesProveedorNombre[0];
         pr_default.close(12);
         if ( ! ( (DateTime.MinValue==A947PostulacionesFechaTrabajo) || ( DateTimeUtil.ResetTime ( A947PostulacionesFechaTrabajo ) >= DateTimeUtil.ResetTime ( context.localUtil.YMDToD( 1753, 1, 1) ) ) ) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_OutOfRange", ""), context.GetMessage( "Postulaciones Fecha Trabajo", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, "");
            AnyError = 1;
         }
         if ( ! ( (DateTime.MinValue==A939PostulacionesFechaCierre) || ( DateTimeUtil.ResetTime ( A939PostulacionesFechaCierre ) >= DateTimeUtil.ResetTime ( context.localUtil.YMDToD( 1753, 1, 1) ) ) ) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_OutOfRange", ""), context.GetMessage( "Postulaciones Fecha Cierre", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, "");
            AnyError = 1;
         }
         if ( ! ( GxRegex.IsMatch(A951PostulacionesMail,"^((\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*)|(\\s*))$") ) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXM_DoesNotMatchRegExp", ""), context.GetMessage( "Postulaciones Mail", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, "");
            AnyError = 1;
         }
         if ( ! ( (DateTime.MinValue==A425PostulacionesFechaAlta) || ( A425PostulacionesFechaAlta >= context.localUtil.YMDHMSToT( 1753, 1, 1, 0, 0, 0) ) ) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_OutOfRange", ""), context.GetMessage( "Fecha", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, "");
            AnyError = 1;
         }
      }

      protected void CloseExtendedTableCursors1K126( )
      {
         pr_default.close(11);
         pr_default.close(12);
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey1K126( )
      {
         /* Using cursor BC001K18 */
         pr_default.execute(14, new Object[] {n422PostulacionesId, A422PostulacionesId});
         if ( (pr_default.getStatus(14) != 101) )
         {
            RcdFound126 = 1;
         }
         else
         {
            RcdFound126 = 0;
         }
         pr_default.close(14);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC001K11 */
         pr_default.execute(9, new Object[] {n422PostulacionesId, A422PostulacionesId});
         if ( (pr_default.getStatus(9) != 101) )
         {
            ZM1K126( 16) ;
            RcdFound126 = 1;
            A422PostulacionesId = BC001K11_A422PostulacionesId[0];
            n422PostulacionesId = BC001K11_n422PostulacionesId[0];
            A971PostulacionesProvNombreAux = BC001K11_A971PostulacionesProvNombreAux[0];
            A946PostulacionesPrecio = BC001K11_A946PostulacionesPrecio[0];
            A961PostulacionesMultimediaSerial = BC001K11_A961PostulacionesMultimediaSerial[0];
            A936PostulacionesDescripcion = BC001K11_A936PostulacionesDescripcion[0];
            A937PostulacionesReqSuministros = BC001K11_A937PostulacionesReqSuministros[0];
            A938PostulacionesSuministrosDescri = BC001K11_A938PostulacionesSuministrosDescri[0];
            A947PostulacionesFechaTrabajo = BC001K11_A947PostulacionesFechaTrabajo[0];
            A939PostulacionesFechaCierre = BC001K11_A939PostulacionesFechaCierre[0];
            A940PostulacionesHoraCierre = BC001K11_A940PostulacionesHoraCierre[0];
            A941PostulacionesTipoFecha = BC001K11_A941PostulacionesTipoFecha[0];
            A949PostulacionesRgoHoraservicio = BC001K11_A949PostulacionesRgoHoraservicio[0];
            A950PostulacionesApellidoNombre = BC001K11_A950PostulacionesApellidoNombre[0];
            A951PostulacionesMail = BC001K11_A951PostulacionesMail[0];
            A952PostulacionesTelefono = BC001K11_A952PostulacionesTelefono[0];
            A979PostulacionesDepartamentoId = BC001K11_A979PostulacionesDepartamentoId[0];
            A980PostulacionesDepartamentoMunic = BC001K11_A980PostulacionesDepartamentoMunic[0];
            A981PostulacionesZonasID = BC001K11_A981PostulacionesZonasID[0];
            A998PostulacionesDireccion = BC001K11_A998PostulacionesDireccion[0];
            A425PostulacionesFechaAlta = BC001K11_A425PostulacionesFechaAlta[0];
            A424PostulacionesEstado = BC001K11_A424PostulacionesEstado[0];
            A948PostulacionesSecUserId = BC001K11_A948PostulacionesSecUserId[0];
            A942ServiciosId = BC001K11_A942ServiciosId[0];
            n942ServiciosId = BC001K11_n942ServiciosId[0];
            A945PostulacionesProveedorId = BC001K11_A945PostulacionesProveedorId[0];
            O961PostulacionesMultimediaSerial = A961PostulacionesMultimediaSerial;
            Z422PostulacionesId = A422PostulacionesId;
            sMode126 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load1K126( ) ;
            if ( AnyError == 1 )
            {
               RcdFound126 = 0;
               InitializeNonKey1K126( ) ;
            }
            Gx_mode = sMode126;
         }
         else
         {
            RcdFound126 = 0;
            InitializeNonKey1K126( ) ;
            sMode126 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode126;
         }
         pr_default.close(9);
      }

      protected void getEqualNoModal( )
      {
         GetKey1K126( ) ;
         if ( RcdFound126 == 0 )
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
         CONFIRM_1K0( ) ;
      }

      protected void update_Check( )
      {
         insert_Check( ) ;
      }

      protected void delete_Check( )
      {
         insert_Check( ) ;
      }

      protected void CheckOptimisticConcurrency1K126( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC001K10 */
            pr_default.execute(8, new Object[] {n422PostulacionesId, A422PostulacionesId});
            if ( (pr_default.getStatus(8) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Postulaciones"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(8) == 101) || ( StringUtil.StrCmp(Z971PostulacionesProvNombreAux, BC001K10_A971PostulacionesProvNombreAux[0]) != 0 ) || ( Z946PostulacionesPrecio != BC001K10_A946PostulacionesPrecio[0] ) || ( Z961PostulacionesMultimediaSerial != BC001K10_A961PostulacionesMultimediaSerial[0] ) || ( StringUtil.StrCmp(Z936PostulacionesDescripcion, BC001K10_A936PostulacionesDescripcion[0]) != 0 ) || ( Z937PostulacionesReqSuministros != BC001K10_A937PostulacionesReqSuministros[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z938PostulacionesSuministrosDescri, BC001K10_A938PostulacionesSuministrosDescri[0]) != 0 ) || ( DateTimeUtil.ResetTime ( Z947PostulacionesFechaTrabajo ) != DateTimeUtil.ResetTime ( BC001K10_A947PostulacionesFechaTrabajo[0] ) ) || ( DateTimeUtil.ResetTime ( Z939PostulacionesFechaCierre ) != DateTimeUtil.ResetTime ( BC001K10_A939PostulacionesFechaCierre[0] ) ) || ( StringUtil.StrCmp(Z940PostulacionesHoraCierre, BC001K10_A940PostulacionesHoraCierre[0]) != 0 ) || ( StringUtil.StrCmp(Z941PostulacionesTipoFecha, BC001K10_A941PostulacionesTipoFecha[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z949PostulacionesRgoHoraservicio, BC001K10_A949PostulacionesRgoHoraservicio[0]) != 0 ) || ( StringUtil.StrCmp(Z950PostulacionesApellidoNombre, BC001K10_A950PostulacionesApellidoNombre[0]) != 0 ) || ( StringUtil.StrCmp(Z951PostulacionesMail, BC001K10_A951PostulacionesMail[0]) != 0 ) || ( StringUtil.StrCmp(Z952PostulacionesTelefono, BC001K10_A952PostulacionesTelefono[0]) != 0 ) || ( Z979PostulacionesDepartamentoId != BC001K10_A979PostulacionesDepartamentoId[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z980PostulacionesDepartamentoMunic != BC001K10_A980PostulacionesDepartamentoMunic[0] ) || ( Z981PostulacionesZonasID != BC001K10_A981PostulacionesZonasID[0] ) || ( StringUtil.StrCmp(Z998PostulacionesDireccion, BC001K10_A998PostulacionesDireccion[0]) != 0 ) || ( Z425PostulacionesFechaAlta != BC001K10_A425PostulacionesFechaAlta[0] ) || ( StringUtil.StrCmp(Z424PostulacionesEstado, BC001K10_A424PostulacionesEstado[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z948PostulacionesSecUserId != BC001K10_A948PostulacionesSecUserId[0] ) || ( Z942ServiciosId != BC001K10_A942ServiciosId[0] ) || ( Z945PostulacionesProveedorId != BC001K10_A945PostulacionesProveedorId[0] ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Postulaciones"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert1K126( )
      {
         BeforeValidate1K126( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1K126( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM1K126( 0) ;
            CheckOptimisticConcurrency1K126( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1K126( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert1K126( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC001K19 */
                     pr_default.execute(15, new Object[] {A971PostulacionesProvNombreAux, A946PostulacionesPrecio, A961PostulacionesMultimediaSerial, A936PostulacionesDescripcion, A937PostulacionesReqSuministros, A938PostulacionesSuministrosDescri, A947PostulacionesFechaTrabajo, A939PostulacionesFechaCierre, A940PostulacionesHoraCierre, A941PostulacionesTipoFecha, A949PostulacionesRgoHoraservicio, A950PostulacionesApellidoNombre, A951PostulacionesMail, A952PostulacionesTelefono, A979PostulacionesDepartamentoId, A980PostulacionesDepartamentoMunic, A981PostulacionesZonasID, A998PostulacionesDireccion, A425PostulacionesFechaAlta, A424PostulacionesEstado, A948PostulacionesSecUserId, n942ServiciosId, A942ServiciosId, A945PostulacionesProveedorId});
                     A422PostulacionesId = BC001K19_A422PostulacionesId[0];
                     n422PostulacionesId = BC001K19_n422PostulacionesId[0];
                     pr_default.close(15);
                     pr_default.SmartCacheProvider.SetUpdated("Postulaciones");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           ProcessLevel1K126( ) ;
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
               Load1K126( ) ;
            }
            EndLevel1K126( ) ;
         }
         CloseExtendedTableCursors1K126( ) ;
      }

      protected void Update1K126( )
      {
         BeforeValidate1K126( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1K126( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1K126( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1K126( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate1K126( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC001K20 */
                     pr_default.execute(16, new Object[] {A971PostulacionesProvNombreAux, A946PostulacionesPrecio, A961PostulacionesMultimediaSerial, A936PostulacionesDescripcion, A937PostulacionesReqSuministros, A938PostulacionesSuministrosDescri, A947PostulacionesFechaTrabajo, A939PostulacionesFechaCierre, A940PostulacionesHoraCierre, A941PostulacionesTipoFecha, A949PostulacionesRgoHoraservicio, A950PostulacionesApellidoNombre, A951PostulacionesMail, A952PostulacionesTelefono, A979PostulacionesDepartamentoId, A980PostulacionesDepartamentoMunic, A981PostulacionesZonasID, A998PostulacionesDireccion, A425PostulacionesFechaAlta, A424PostulacionesEstado, A948PostulacionesSecUserId, n942ServiciosId, A942ServiciosId, A945PostulacionesProveedorId, n422PostulacionesId, A422PostulacionesId});
                     pr_default.close(16);
                     pr_default.SmartCacheProvider.SetUpdated("Postulaciones");
                     if ( (pr_default.getStatus(16) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Postulaciones"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate1K126( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        new sincronizarpostulacionessolicitudes(context ).execute(  A970PostulacionesSolicitudesId,  A422PostulacionesId) ;
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           ProcessLevel1K126( ) ;
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
            EndLevel1K126( ) ;
         }
         CloseExtendedTableCursors1K126( ) ;
      }

      protected void DeferredUpdate1K126( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate1K126( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1K126( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls1K126( ) ;
            AfterConfirm1K126( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete1K126( ) ;
               if ( AnyError == 0 )
               {
                  ScanKeyStart1K142( ) ;
                  while ( RcdFound142 != 0 )
                  {
                     getByPrimaryKey1K142( ) ;
                     Delete1K142( ) ;
                     ScanKeyNext1K142( ) ;
                  }
                  ScanKeyEnd1K142( ) ;
                  A961PostulacionesMultimediaSerial = O961PostulacionesMultimediaSerial;
                  ScanKeyStart1K139( ) ;
                  while ( RcdFound139 != 0 )
                  {
                     getByPrimaryKey1K139( ) ;
                     Delete1K139( ) ;
                     ScanKeyNext1K139( ) ;
                     O961PostulacionesMultimediaSerial = A961PostulacionesMultimediaSerial;
                  }
                  ScanKeyEnd1K139( ) ;
                  ScanKeyStart1K137( ) ;
                  while ( RcdFound137 != 0 )
                  {
                     getByPrimaryKey1K137( ) ;
                     Delete1K137( ) ;
                     ScanKeyNext1K137( ) ;
                  }
                  ScanKeyEnd1K137( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC001K21 */
                     pr_default.execute(17, new Object[] {n422PostulacionesId, A422PostulacionesId});
                     pr_default.close(17);
                     pr_default.SmartCacheProvider.SetUpdated("Postulaciones");
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
         sMode126 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel1K126( ) ;
         Gx_mode = sMode126;
      }

      protected void OnDeleteControls1K126( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            AV25Pgmname = "Postulaciones_BC";
            /* Using cursor BC001K22 */
            pr_default.execute(18, new Object[] {n942ServiciosId, A942ServiciosId});
            A943ServiciosNombre = BC001K22_A943ServiciosNombre[0];
            pr_default.close(18);
            /* Using cursor BC001K23 */
            pr_default.execute(19, new Object[] {A945PostulacionesProveedorId});
            A969PostulacionesProveedorNombre = BC001K23_A969PostulacionesProveedorNombre[0];
            pr_default.close(19);
         }
         if ( AnyError == 0 )
         {
            /* Using cursor BC001K24 */
            pr_default.execute(20, new Object[] {n422PostulacionesId, A422PostulacionesId});
            if ( (pr_default.getStatus(20) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "Registro de Solicitudes", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(20);
         }
      }

      protected void ProcessNestedLevel1K142( )
      {
         nGXsfl_142_idx = 0;
         while ( nGXsfl_142_idx < bcPostulaciones.gxTpr_Categorias.Count )
         {
            ReadRow1K142( ) ;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( Gx_mode)) )
            {
               if ( RcdFound142 == 0 )
               {
                  Gx_mode = "INS";
               }
               else
               {
                  Gx_mode = "UPD";
               }
            }
            if ( ! IsIns( ) || ( nIsMod_142 != 0 ) )
            {
               standaloneNotModal1K142( ) ;
               if ( IsIns( ) )
               {
                  Gx_mode = "INS";
                  Insert1K142( ) ;
               }
               else
               {
                  if ( IsDlt( ) )
                  {
                     Gx_mode = "DLT";
                     Delete1K142( ) ;
                  }
                  else
                  {
                     Gx_mode = "UPD";
                     Update1K142( ) ;
                  }
               }
            }
            KeyVarsToRow142( ((SdtPostulaciones_Categorias)bcPostulaciones.gxTpr_Categorias.Item(nGXsfl_142_idx))) ;
         }
         if ( AnyError == 0 )
         {
            /* Batch update SDT rows */
            nGXsfl_142_idx = 0;
            while ( nGXsfl_142_idx < bcPostulaciones.gxTpr_Categorias.Count )
            {
               ReadRow1K142( ) ;
               if ( String.IsNullOrEmpty(StringUtil.RTrim( Gx_mode)) )
               {
                  if ( RcdFound142 == 0 )
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
                  bcPostulaciones.gxTpr_Categorias.RemoveElement(nGXsfl_142_idx);
                  nGXsfl_142_idx = (int)(nGXsfl_142_idx-1);
               }
               else
               {
                  Gx_mode = "UPD";
                  getByPrimaryKey1K142( ) ;
                  VarsToRow142( ((SdtPostulaciones_Categorias)bcPostulaciones.gxTpr_Categorias.Item(nGXsfl_142_idx))) ;
               }
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
         InitAll1K142( ) ;
         if ( AnyError != 0 )
         {
         }
         nRcdExists_142 = 0;
         nIsMod_142 = 0;
      }

      protected void ProcessNestedLevel1K139( )
      {
         s961PostulacionesMultimediaSerial = O961PostulacionesMultimediaSerial;
         nGXsfl_139_idx = 0;
         while ( nGXsfl_139_idx < bcPostulaciones.gxTpr_Multimedia.Count )
         {
            ReadRow1K139( ) ;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( Gx_mode)) )
            {
               if ( RcdFound139 == 0 )
               {
                  Gx_mode = "INS";
               }
               else
               {
                  Gx_mode = "UPD";
               }
            }
            if ( ! IsIns( ) || ( nIsMod_139 != 0 ) )
            {
               standaloneNotModal1K139( ) ;
               if ( IsIns( ) )
               {
                  Gx_mode = "INS";
                  Insert1K139( ) ;
               }
               else
               {
                  if ( IsDlt( ) )
                  {
                     Gx_mode = "DLT";
                     Delete1K139( ) ;
                  }
                  else
                  {
                     Gx_mode = "UPD";
                     Update1K139( ) ;
                  }
               }
               O961PostulacionesMultimediaSerial = A961PostulacionesMultimediaSerial;
            }
            KeyVarsToRow139( ((SdtPostulaciones_Multimedia)bcPostulaciones.gxTpr_Multimedia.Item(nGXsfl_139_idx))) ;
         }
         if ( AnyError == 0 )
         {
            /* Batch update SDT rows */
            nGXsfl_139_idx = 0;
            while ( nGXsfl_139_idx < bcPostulaciones.gxTpr_Multimedia.Count )
            {
               ReadRow1K139( ) ;
               if ( String.IsNullOrEmpty(StringUtil.RTrim( Gx_mode)) )
               {
                  if ( RcdFound139 == 0 )
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
                  bcPostulaciones.gxTpr_Multimedia.RemoveElement(nGXsfl_139_idx);
                  nGXsfl_139_idx = (int)(nGXsfl_139_idx-1);
               }
               else
               {
                  Gx_mode = "UPD";
                  getByPrimaryKey1K139( ) ;
                  VarsToRow139( ((SdtPostulaciones_Multimedia)bcPostulaciones.gxTpr_Multimedia.Item(nGXsfl_139_idx))) ;
               }
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
         InitAll1K139( ) ;
         if ( AnyError != 0 )
         {
            O961PostulacionesMultimediaSerial = s961PostulacionesMultimediaSerial;
         }
         nRcdExists_139 = 0;
         nIsMod_139 = 0;
      }

      protected void ProcessNestedLevel1K137( )
      {
         nGXsfl_137_idx = 0;
         while ( nGXsfl_137_idx < bcPostulaciones.gxTpr_Profesionales.Count )
         {
            ReadRow1K137( ) ;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( Gx_mode)) )
            {
               if ( RcdFound137 == 0 )
               {
                  Gx_mode = "INS";
               }
               else
               {
                  Gx_mode = "UPD";
               }
            }
            if ( ! IsIns( ) || ( nIsMod_137 != 0 ) )
            {
               standaloneNotModal1K137( ) ;
               if ( IsIns( ) )
               {
                  Gx_mode = "INS";
                  Insert1K137( ) ;
               }
               else
               {
                  if ( IsDlt( ) )
                  {
                     Gx_mode = "DLT";
                     Delete1K137( ) ;
                  }
                  else
                  {
                     Gx_mode = "UPD";
                     Update1K137( ) ;
                  }
               }
            }
            KeyVarsToRow137( ((SdtPostulaciones_Profesionales)bcPostulaciones.gxTpr_Profesionales.Item(nGXsfl_137_idx))) ;
         }
         if ( AnyError == 0 )
         {
            /* Batch update SDT rows */
            nGXsfl_137_idx = 0;
            while ( nGXsfl_137_idx < bcPostulaciones.gxTpr_Profesionales.Count )
            {
               ReadRow1K137( ) ;
               if ( String.IsNullOrEmpty(StringUtil.RTrim( Gx_mode)) )
               {
                  if ( RcdFound137 == 0 )
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
                  bcPostulaciones.gxTpr_Profesionales.RemoveElement(nGXsfl_137_idx);
                  nGXsfl_137_idx = (int)(nGXsfl_137_idx-1);
               }
               else
               {
                  Gx_mode = "UPD";
                  getByPrimaryKey1K137( ) ;
                  VarsToRow137( ((SdtPostulaciones_Profesionales)bcPostulaciones.gxTpr_Profesionales.Item(nGXsfl_137_idx))) ;
               }
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
         InitAll1K137( ) ;
         if ( AnyError != 0 )
         {
         }
         nRcdExists_137 = 0;
         nIsMod_137 = 0;
      }

      protected void ProcessLevel1K126( )
      {
         /* Save parent mode. */
         sMode126 = Gx_mode;
         ProcessNestedLevel1K142( ) ;
         ProcessNestedLevel1K139( ) ;
         ProcessNestedLevel1K137( ) ;
         if ( AnyError != 0 )
         {
            O961PostulacionesMultimediaSerial = s961PostulacionesMultimediaSerial;
         }
         /* Restore parent mode. */
         Gx_mode = sMode126;
         /* ' Update level parameters */
         /* Using cursor BC001K25 */
         pr_default.execute(21, new Object[] {A961PostulacionesMultimediaSerial, n422PostulacionesId, A422PostulacionesId});
         pr_default.close(21);
         pr_default.SmartCacheProvider.SetUpdated("Postulaciones");
      }

      protected void EndLevel1K126( )
      {
         pr_default.close(8);
         if ( AnyError == 0 )
         {
            BeforeComplete1K126( ) ;
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

      public void ScanKeyStart1K126( )
      {
         /* Scan By routine */
         /* Using cursor BC001K27 */
         pr_default.execute(22, new Object[] {n422PostulacionesId, A422PostulacionesId});
         RcdFound126 = 0;
         if ( (pr_default.getStatus(22) != 101) )
         {
            RcdFound126 = 1;
            A422PostulacionesId = BC001K27_A422PostulacionesId[0];
            n422PostulacionesId = BC001K27_n422PostulacionesId[0];
            A943ServiciosNombre = BC001K27_A943ServiciosNombre[0];
            A971PostulacionesProvNombreAux = BC001K27_A971PostulacionesProvNombreAux[0];
            A969PostulacionesProveedorNombre = BC001K27_A969PostulacionesProveedorNombre[0];
            A946PostulacionesPrecio = BC001K27_A946PostulacionesPrecio[0];
            A961PostulacionesMultimediaSerial = BC001K27_A961PostulacionesMultimediaSerial[0];
            A936PostulacionesDescripcion = BC001K27_A936PostulacionesDescripcion[0];
            A937PostulacionesReqSuministros = BC001K27_A937PostulacionesReqSuministros[0];
            A938PostulacionesSuministrosDescri = BC001K27_A938PostulacionesSuministrosDescri[0];
            A947PostulacionesFechaTrabajo = BC001K27_A947PostulacionesFechaTrabajo[0];
            A939PostulacionesFechaCierre = BC001K27_A939PostulacionesFechaCierre[0];
            A940PostulacionesHoraCierre = BC001K27_A940PostulacionesHoraCierre[0];
            A941PostulacionesTipoFecha = BC001K27_A941PostulacionesTipoFecha[0];
            A949PostulacionesRgoHoraservicio = BC001K27_A949PostulacionesRgoHoraservicio[0];
            A950PostulacionesApellidoNombre = BC001K27_A950PostulacionesApellidoNombre[0];
            A951PostulacionesMail = BC001K27_A951PostulacionesMail[0];
            A952PostulacionesTelefono = BC001K27_A952PostulacionesTelefono[0];
            A979PostulacionesDepartamentoId = BC001K27_A979PostulacionesDepartamentoId[0];
            A980PostulacionesDepartamentoMunic = BC001K27_A980PostulacionesDepartamentoMunic[0];
            A981PostulacionesZonasID = BC001K27_A981PostulacionesZonasID[0];
            A998PostulacionesDireccion = BC001K27_A998PostulacionesDireccion[0];
            A425PostulacionesFechaAlta = BC001K27_A425PostulacionesFechaAlta[0];
            A424PostulacionesEstado = BC001K27_A424PostulacionesEstado[0];
            A948PostulacionesSecUserId = BC001K27_A948PostulacionesSecUserId[0];
            A942ServiciosId = BC001K27_A942ServiciosId[0];
            n942ServiciosId = BC001K27_n942ServiciosId[0];
            A945PostulacionesProveedorId = BC001K27_A945PostulacionesProveedorId[0];
            A970PostulacionesSolicitudesId = BC001K27_A970PostulacionesSolicitudesId[0];
            n970PostulacionesSolicitudesId = BC001K27_n970PostulacionesSolicitudesId[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext1K126( )
      {
         /* Scan next routine */
         pr_default.readNext(22);
         RcdFound126 = 0;
         ScanKeyLoad1K126( ) ;
      }

      protected void ScanKeyLoad1K126( )
      {
         sMode126 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(22) != 101) )
         {
            RcdFound126 = 1;
            A422PostulacionesId = BC001K27_A422PostulacionesId[0];
            n422PostulacionesId = BC001K27_n422PostulacionesId[0];
            A943ServiciosNombre = BC001K27_A943ServiciosNombre[0];
            A971PostulacionesProvNombreAux = BC001K27_A971PostulacionesProvNombreAux[0];
            A969PostulacionesProveedorNombre = BC001K27_A969PostulacionesProveedorNombre[0];
            A946PostulacionesPrecio = BC001K27_A946PostulacionesPrecio[0];
            A961PostulacionesMultimediaSerial = BC001K27_A961PostulacionesMultimediaSerial[0];
            A936PostulacionesDescripcion = BC001K27_A936PostulacionesDescripcion[0];
            A937PostulacionesReqSuministros = BC001K27_A937PostulacionesReqSuministros[0];
            A938PostulacionesSuministrosDescri = BC001K27_A938PostulacionesSuministrosDescri[0];
            A947PostulacionesFechaTrabajo = BC001K27_A947PostulacionesFechaTrabajo[0];
            A939PostulacionesFechaCierre = BC001K27_A939PostulacionesFechaCierre[0];
            A940PostulacionesHoraCierre = BC001K27_A940PostulacionesHoraCierre[0];
            A941PostulacionesTipoFecha = BC001K27_A941PostulacionesTipoFecha[0];
            A949PostulacionesRgoHoraservicio = BC001K27_A949PostulacionesRgoHoraservicio[0];
            A950PostulacionesApellidoNombre = BC001K27_A950PostulacionesApellidoNombre[0];
            A951PostulacionesMail = BC001K27_A951PostulacionesMail[0];
            A952PostulacionesTelefono = BC001K27_A952PostulacionesTelefono[0];
            A979PostulacionesDepartamentoId = BC001K27_A979PostulacionesDepartamentoId[0];
            A980PostulacionesDepartamentoMunic = BC001K27_A980PostulacionesDepartamentoMunic[0];
            A981PostulacionesZonasID = BC001K27_A981PostulacionesZonasID[0];
            A998PostulacionesDireccion = BC001K27_A998PostulacionesDireccion[0];
            A425PostulacionesFechaAlta = BC001K27_A425PostulacionesFechaAlta[0];
            A424PostulacionesEstado = BC001K27_A424PostulacionesEstado[0];
            A948PostulacionesSecUserId = BC001K27_A948PostulacionesSecUserId[0];
            A942ServiciosId = BC001K27_A942ServiciosId[0];
            n942ServiciosId = BC001K27_n942ServiciosId[0];
            A945PostulacionesProveedorId = BC001K27_A945PostulacionesProveedorId[0];
            A970PostulacionesSolicitudesId = BC001K27_A970PostulacionesSolicitudesId[0];
            n970PostulacionesSolicitudesId = BC001K27_n970PostulacionesSolicitudesId[0];
         }
         Gx_mode = sMode126;
      }

      protected void ScanKeyEnd1K126( )
      {
         pr_default.close(22);
      }

      protected void AfterConfirm1K126( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert1K126( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate1K126( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete1K126( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete1K126( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate1K126( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes1K126( )
      {
      }

      protected void ZM1K142( short GX_JID )
      {
         if ( ( GX_JID == 20 ) || ( GX_JID == 0 ) )
         {
         }
         if ( ( GX_JID == 21 ) || ( GX_JID == 0 ) )
         {
            Z944CategoriasNombre = A944CategoriasNombre;
         }
         if ( GX_JID == -20 )
         {
            Z422PostulacionesId = A422PostulacionesId;
            Z931CategoriasId = A931CategoriasId;
            Z944CategoriasNombre = A944CategoriasNombre;
         }
      }

      protected void standaloneNotModal1K142( )
      {
      }

      protected void standaloneModal1K142( )
      {
      }

      protected void Load1K142( )
      {
         /* Using cursor BC001K28 */
         pr_default.execute(23, new Object[] {n942ServiciosId, A942ServiciosId, n422PostulacionesId, A422PostulacionesId, A931CategoriasId});
         if ( (pr_default.getStatus(23) != 101) )
         {
            RcdFound142 = 1;
            A944CategoriasNombre = BC001K28_A944CategoriasNombre[0];
            ZM1K142( -20) ;
         }
         pr_default.close(23);
         OnLoadActions1K142( ) ;
      }

      protected void OnLoadActions1K142( )
      {
      }

      protected void CheckExtendedTable1K142( )
      {
         Gx_BScreen = 1;
         standaloneModal1K142( ) ;
         Gx_BScreen = 0;
         /* Using cursor BC001K9 */
         pr_default.execute(7, new Object[] {n942ServiciosId, A942ServiciosId, A931CategoriasId});
         if ( (pr_default.getStatus(7) == 101) )
         {
            if ( ! ( (0==A942ServiciosId) || (0==A931CategoriasId) ) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Categorias", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "CATEGORIASID");
               AnyError = 1;
            }
         }
         A944CategoriasNombre = BC001K9_A944CategoriasNombre[0];
         pr_default.close(7);
      }

      protected void CloseExtendedTableCursors1K142( )
      {
         pr_default.close(7);
      }

      protected void enableDisable1K142( )
      {
      }

      protected void GetKey1K142( )
      {
         /* Using cursor BC001K29 */
         pr_default.execute(24, new Object[] {n422PostulacionesId, A422PostulacionesId, A931CategoriasId});
         if ( (pr_default.getStatus(24) != 101) )
         {
            RcdFound142 = 1;
         }
         else
         {
            RcdFound142 = 0;
         }
         pr_default.close(24);
      }

      protected void getByPrimaryKey1K142( )
      {
         /* Using cursor BC001K8 */
         pr_default.execute(6, new Object[] {n422PostulacionesId, A422PostulacionesId, A931CategoriasId});
         if ( (pr_default.getStatus(6) != 101) )
         {
            ZM1K142( 20) ;
            RcdFound142 = 1;
            InitializeNonKey1K142( ) ;
            A931CategoriasId = BC001K8_A931CategoriasId[0];
            Z422PostulacionesId = A422PostulacionesId;
            Z931CategoriasId = A931CategoriasId;
            sMode142 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal1K142( ) ;
            Load1K142( ) ;
            Gx_mode = sMode142;
         }
         else
         {
            RcdFound142 = 0;
            InitializeNonKey1K142( ) ;
            sMode142 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal1K142( ) ;
            Gx_mode = sMode142;
         }
         if ( IsDsp( ) || IsDlt( ) )
         {
            DisableAttributes1K142( ) ;
         }
         pr_default.close(6);
      }

      protected void CheckOptimisticConcurrency1K142( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC001K7 */
            pr_default.execute(5, new Object[] {n422PostulacionesId, A422PostulacionesId, A931CategoriasId});
            if ( (pr_default.getStatus(5) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"PostulacionesCategorias"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(5) == 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"PostulacionesCategorias"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert1K142( )
      {
         BeforeValidate1K142( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1K142( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM1K142( 0) ;
            CheckOptimisticConcurrency1K142( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1K142( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert1K142( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC001K30 */
                     pr_default.execute(25, new Object[] {n422PostulacionesId, A422PostulacionesId, A931CategoriasId});
                     pr_default.close(25);
                     pr_default.SmartCacheProvider.SetUpdated("PostulacionesCategorias");
                     if ( (pr_default.getStatus(25) == 1) )
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
               Load1K142( ) ;
            }
            EndLevel1K142( ) ;
         }
         CloseExtendedTableCursors1K142( ) ;
      }

      protected void Update1K142( )
      {
         BeforeValidate1K142( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1K142( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1K142( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1K142( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate1K142( ) ;
                  if ( AnyError == 0 )
                  {
                     /* No attributes to update on table [PostulacionesCategorias] */
                     DeferredUpdate1K142( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey1K142( ) ;
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
            EndLevel1K142( ) ;
         }
         CloseExtendedTableCursors1K142( ) ;
      }

      protected void DeferredUpdate1K142( )
      {
      }

      protected void Delete1K142( )
      {
         Gx_mode = "DLT";
         BeforeValidate1K142( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1K142( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls1K142( ) ;
            AfterConfirm1K142( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete1K142( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC001K31 */
                  pr_default.execute(26, new Object[] {n422PostulacionesId, A422PostulacionesId, A931CategoriasId});
                  pr_default.close(26);
                  pr_default.SmartCacheProvider.SetUpdated("PostulacionesCategorias");
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
         sMode142 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel1K142( ) ;
         Gx_mode = sMode142;
      }

      protected void OnDeleteControls1K142( )
      {
         standaloneModal1K142( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor BC001K32 */
            pr_default.execute(27, new Object[] {n942ServiciosId, A942ServiciosId, A931CategoriasId});
            A944CategoriasNombre = BC001K32_A944CategoriasNombre[0];
            pr_default.close(27);
         }
      }

      protected void EndLevel1K142( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(5);
         }
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanKeyStart1K142( )
      {
         /* Scan By routine */
         /* Using cursor BC001K33 */
         pr_default.execute(28, new Object[] {n942ServiciosId, A942ServiciosId, n422PostulacionesId, A422PostulacionesId});
         RcdFound142 = 0;
         if ( (pr_default.getStatus(28) != 101) )
         {
            RcdFound142 = 1;
            A944CategoriasNombre = BC001K33_A944CategoriasNombre[0];
            A931CategoriasId = BC001K33_A931CategoriasId[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext1K142( )
      {
         /* Scan next routine */
         pr_default.readNext(28);
         RcdFound142 = 0;
         ScanKeyLoad1K142( ) ;
      }

      protected void ScanKeyLoad1K142( )
      {
         sMode142 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(28) != 101) )
         {
            RcdFound142 = 1;
            A944CategoriasNombre = BC001K33_A944CategoriasNombre[0];
            A931CategoriasId = BC001K33_A931CategoriasId[0];
         }
         Gx_mode = sMode142;
      }

      protected void ScanKeyEnd1K142( )
      {
         pr_default.close(28);
      }

      protected void AfterConfirm1K142( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert1K142( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate1K142( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete1K142( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete1K142( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate1K142( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes1K142( )
      {
      }

      protected void send_integrity_lvl_hashes1K142( )
      {
      }

      protected void ZM1K139( short GX_JID )
      {
         if ( ( GX_JID == 22 ) || ( GX_JID == 0 ) )
         {
            Z933MultimediaDireccion = A933MultimediaDireccion;
            Z960MultimediaDescripcion = A960MultimediaDescripcion;
            Z934MultimediaTipo = A934MultimediaTipo;
         }
         if ( GX_JID == -22 )
         {
            Z422PostulacionesId = A422PostulacionesId;
            Z932MultimediaId = A932MultimediaId;
            Z933MultimediaDireccion = A933MultimediaDireccion;
            Z960MultimediaDescripcion = A960MultimediaDescripcion;
            Z934MultimediaTipo = A934MultimediaTipo;
         }
      }

      protected void standaloneNotModal1K139( )
      {
      }

      protected void standaloneModal1K139( )
      {
         if ( IsIns( )  )
         {
            A961PostulacionesMultimediaSerial = (short)(O961PostulacionesMultimediaSerial+1);
         }
         if ( IsIns( )  )
         {
            A932MultimediaId = A961PostulacionesMultimediaSerial;
         }
      }

      protected void Load1K139( )
      {
         /* Using cursor BC001K34 */
         pr_default.execute(29, new Object[] {n422PostulacionesId, A422PostulacionesId, A932MultimediaId});
         if ( (pr_default.getStatus(29) != 101) )
         {
            RcdFound139 = 1;
            A933MultimediaDireccion = BC001K34_A933MultimediaDireccion[0];
            A960MultimediaDescripcion = BC001K34_A960MultimediaDescripcion[0];
            A934MultimediaTipo = BC001K34_A934MultimediaTipo[0];
            ZM1K139( -22) ;
         }
         pr_default.close(29);
         OnLoadActions1K139( ) ;
      }

      protected void OnLoadActions1K139( )
      {
      }

      protected void CheckExtendedTable1K139( )
      {
         Gx_BScreen = 1;
         standaloneModal1K139( ) ;
         Gx_BScreen = 0;
      }

      protected void CloseExtendedTableCursors1K139( )
      {
      }

      protected void enableDisable1K139( )
      {
      }

      protected void GetKey1K139( )
      {
         /* Using cursor BC001K35 */
         pr_default.execute(30, new Object[] {n422PostulacionesId, A422PostulacionesId, A932MultimediaId});
         if ( (pr_default.getStatus(30) != 101) )
         {
            RcdFound139 = 1;
         }
         else
         {
            RcdFound139 = 0;
         }
         pr_default.close(30);
      }

      protected void getByPrimaryKey1K139( )
      {
         /* Using cursor BC001K6 */
         pr_default.execute(4, new Object[] {n422PostulacionesId, A422PostulacionesId, A932MultimediaId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            ZM1K139( 22) ;
            RcdFound139 = 1;
            InitializeNonKey1K139( ) ;
            A932MultimediaId = BC001K6_A932MultimediaId[0];
            A933MultimediaDireccion = BC001K6_A933MultimediaDireccion[0];
            A960MultimediaDescripcion = BC001K6_A960MultimediaDescripcion[0];
            A934MultimediaTipo = BC001K6_A934MultimediaTipo[0];
            Z422PostulacionesId = A422PostulacionesId;
            Z932MultimediaId = A932MultimediaId;
            sMode139 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal1K139( ) ;
            Load1K139( ) ;
            Gx_mode = sMode139;
         }
         else
         {
            RcdFound139 = 0;
            InitializeNonKey1K139( ) ;
            sMode139 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal1K139( ) ;
            Gx_mode = sMode139;
         }
         if ( IsDsp( ) || IsDlt( ) )
         {
            DisableAttributes1K139( ) ;
         }
         pr_default.close(4);
      }

      protected void CheckOptimisticConcurrency1K139( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC001K5 */
            pr_default.execute(3, new Object[] {n422PostulacionesId, A422PostulacionesId, A932MultimediaId});
            if ( (pr_default.getStatus(3) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"PostulacionesMultimedia"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(3) == 101) || ( StringUtil.StrCmp(Z933MultimediaDireccion, BC001K5_A933MultimediaDireccion[0]) != 0 ) || ( StringUtil.StrCmp(Z960MultimediaDescripcion, BC001K5_A960MultimediaDescripcion[0]) != 0 ) || ( StringUtil.StrCmp(Z934MultimediaTipo, BC001K5_A934MultimediaTipo[0]) != 0 ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"PostulacionesMultimedia"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert1K139( )
      {
         BeforeValidate1K139( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1K139( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM1K139( 0) ;
            CheckOptimisticConcurrency1K139( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1K139( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert1K139( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC001K36 */
                     pr_default.execute(31, new Object[] {n422PostulacionesId, A422PostulacionesId, A932MultimediaId, A933MultimediaDireccion, A960MultimediaDescripcion, A934MultimediaTipo});
                     pr_default.close(31);
                     pr_default.SmartCacheProvider.SetUpdated("PostulacionesMultimedia");
                     if ( (pr_default.getStatus(31) == 1) )
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
               Load1K139( ) ;
            }
            EndLevel1K139( ) ;
         }
         CloseExtendedTableCursors1K139( ) ;
      }

      protected void Update1K139( )
      {
         BeforeValidate1K139( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1K139( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1K139( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1K139( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate1K139( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC001K37 */
                     pr_default.execute(32, new Object[] {A933MultimediaDireccion, A960MultimediaDescripcion, A934MultimediaTipo, n422PostulacionesId, A422PostulacionesId, A932MultimediaId});
                     pr_default.close(32);
                     pr_default.SmartCacheProvider.SetUpdated("PostulacionesMultimedia");
                     if ( (pr_default.getStatus(32) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"PostulacionesMultimedia"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate1K139( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey1K139( ) ;
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
            EndLevel1K139( ) ;
         }
         CloseExtendedTableCursors1K139( ) ;
      }

      protected void DeferredUpdate1K139( )
      {
      }

      protected void Delete1K139( )
      {
         Gx_mode = "DLT";
         BeforeValidate1K139( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1K139( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls1K139( ) ;
            AfterConfirm1K139( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete1K139( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC001K38 */
                  pr_default.execute(33, new Object[] {n422PostulacionesId, A422PostulacionesId, A932MultimediaId});
                  pr_default.close(33);
                  pr_default.SmartCacheProvider.SetUpdated("PostulacionesMultimedia");
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
         sMode139 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel1K139( ) ;
         Gx_mode = sMode139;
      }

      protected void OnDeleteControls1K139( )
      {
         standaloneModal1K139( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel1K139( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(3);
         }
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanKeyStart1K139( )
      {
         /* Scan By routine */
         /* Using cursor BC001K39 */
         pr_default.execute(34, new Object[] {n422PostulacionesId, A422PostulacionesId});
         RcdFound139 = 0;
         if ( (pr_default.getStatus(34) != 101) )
         {
            RcdFound139 = 1;
            A932MultimediaId = BC001K39_A932MultimediaId[0];
            A933MultimediaDireccion = BC001K39_A933MultimediaDireccion[0];
            A960MultimediaDescripcion = BC001K39_A960MultimediaDescripcion[0];
            A934MultimediaTipo = BC001K39_A934MultimediaTipo[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext1K139( )
      {
         /* Scan next routine */
         pr_default.readNext(34);
         RcdFound139 = 0;
         ScanKeyLoad1K139( ) ;
      }

      protected void ScanKeyLoad1K139( )
      {
         sMode139 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(34) != 101) )
         {
            RcdFound139 = 1;
            A932MultimediaId = BC001K39_A932MultimediaId[0];
            A933MultimediaDireccion = BC001K39_A933MultimediaDireccion[0];
            A960MultimediaDescripcion = BC001K39_A960MultimediaDescripcion[0];
            A934MultimediaTipo = BC001K39_A934MultimediaTipo[0];
         }
         Gx_mode = sMode139;
      }

      protected void ScanKeyEnd1K139( )
      {
         pr_default.close(34);
      }

      protected void AfterConfirm1K139( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert1K139( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate1K139( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete1K139( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete1K139( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate1K139( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes1K139( )
      {
      }

      protected void send_integrity_lvl_hashes1K139( )
      {
      }

      protected void ZM1K137( short GX_JID )
      {
         if ( ( GX_JID == 23 ) || ( GX_JID == 0 ) )
         {
            Z956PostulacionProfesionalEstado = A956PostulacionProfesionalEstado;
            Z957PostulacionProfesionalFechaA = A957PostulacionProfesionalFechaA;
            Z958PostulacionProfesionalFechaT = A958PostulacionProfesionalFechaT;
            Z959PostulacionProfesionalTurnoT = A959PostulacionProfesionalTurnoT;
            Z982PostulacionProfesionalPrecio = A982PostulacionProfesionalPrecio;
            Z983PostulacionProfesionalPlazoE = A983PostulacionProfesionalPlazoE;
            Z986PostulacionProfesionalUniE = A986PostulacionProfesionalUniE;
            Z985PostulacionProfesionalGar = A985PostulacionProfesionalGar;
            Z987PostulacionProfesionalUniG = A987PostulacionProfesionalUniG;
            Z984PostulacionProfesionalA = A984PostulacionProfesionalA;
            Z886ProfesionalesNombreCompleto = A886ProfesionalesNombreCompleto;
         }
         if ( ( GX_JID == 24 ) || ( GX_JID == 0 ) )
         {
            Z167ProfesionalesApellidoPrimero = A167ProfesionalesApellidoPrimero;
            Z166ProfesionalesPrimerNombre = A166ProfesionalesPrimerNombre;
            Z191ProfesionalesSegundoNombre = A191ProfesionalesSegundoNombre;
            Z886ProfesionalesNombreCompleto = A886ProfesionalesNombreCompleto;
         }
         if ( GX_JID == -23 )
         {
            Z422PostulacionesId = A422PostulacionesId;
            Z956PostulacionProfesionalEstado = A956PostulacionProfesionalEstado;
            Z957PostulacionProfesionalFechaA = A957PostulacionProfesionalFechaA;
            Z958PostulacionProfesionalFechaT = A958PostulacionProfesionalFechaT;
            Z959PostulacionProfesionalTurnoT = A959PostulacionProfesionalTurnoT;
            Z982PostulacionProfesionalPrecio = A982PostulacionProfesionalPrecio;
            Z983PostulacionProfesionalPlazoE = A983PostulacionProfesionalPlazoE;
            Z986PostulacionProfesionalUniE = A986PostulacionProfesionalUniE;
            Z985PostulacionProfesionalGar = A985PostulacionProfesionalGar;
            Z987PostulacionProfesionalUniG = A987PostulacionProfesionalUniG;
            Z984PostulacionProfesionalA = A984PostulacionProfesionalA;
            Z120ProfesionalesId = A120ProfesionalesId;
            Z167ProfesionalesApellidoPrimero = A167ProfesionalesApellidoPrimero;
            Z166ProfesionalesPrimerNombre = A166ProfesionalesPrimerNombre;
            Z191ProfesionalesSegundoNombre = A191ProfesionalesSegundoNombre;
         }
      }

      protected void standaloneNotModal1K137( )
      {
      }

      protected void standaloneModal1K137( )
      {
      }

      protected void Load1K137( )
      {
         /* Using cursor BC001K40 */
         pr_default.execute(35, new Object[] {n422PostulacionesId, A422PostulacionesId, A120ProfesionalesId});
         if ( (pr_default.getStatus(35) != 101) )
         {
            RcdFound137 = 1;
            A956PostulacionProfesionalEstado = BC001K40_A956PostulacionProfesionalEstado[0];
            A957PostulacionProfesionalFechaA = BC001K40_A957PostulacionProfesionalFechaA[0];
            A958PostulacionProfesionalFechaT = BC001K40_A958PostulacionProfesionalFechaT[0];
            A959PostulacionProfesionalTurnoT = BC001K40_A959PostulacionProfesionalTurnoT[0];
            A982PostulacionProfesionalPrecio = BC001K40_A982PostulacionProfesionalPrecio[0];
            n982PostulacionProfesionalPrecio = BC001K40_n982PostulacionProfesionalPrecio[0];
            A983PostulacionProfesionalPlazoE = BC001K40_A983PostulacionProfesionalPlazoE[0];
            n983PostulacionProfesionalPlazoE = BC001K40_n983PostulacionProfesionalPlazoE[0];
            A986PostulacionProfesionalUniE = BC001K40_A986PostulacionProfesionalUniE[0];
            n986PostulacionProfesionalUniE = BC001K40_n986PostulacionProfesionalUniE[0];
            A985PostulacionProfesionalGar = BC001K40_A985PostulacionProfesionalGar[0];
            n985PostulacionProfesionalGar = BC001K40_n985PostulacionProfesionalGar[0];
            A987PostulacionProfesionalUniG = BC001K40_A987PostulacionProfesionalUniG[0];
            n987PostulacionProfesionalUniG = BC001K40_n987PostulacionProfesionalUniG[0];
            A984PostulacionProfesionalA = BC001K40_A984PostulacionProfesionalA[0];
            n984PostulacionProfesionalA = BC001K40_n984PostulacionProfesionalA[0];
            A167ProfesionalesApellidoPrimero = BC001K40_A167ProfesionalesApellidoPrimero[0];
            A166ProfesionalesPrimerNombre = BC001K40_A166ProfesionalesPrimerNombre[0];
            A191ProfesionalesSegundoNombre = BC001K40_A191ProfesionalesSegundoNombre[0];
            ZM1K137( -23) ;
         }
         pr_default.close(35);
         OnLoadActions1K137( ) ;
      }

      protected void OnLoadActions1K137( )
      {
         A886ProfesionalesNombreCompleto = StringUtil.Trim( A167ProfesionalesApellidoPrimero) + ", " + StringUtil.Trim( A166ProfesionalesPrimerNombre) + " " + StringUtil.Trim( A191ProfesionalesSegundoNombre);
      }

      protected void CheckExtendedTable1K137( )
      {
         Gx_BScreen = 1;
         standaloneModal1K137( ) ;
         Gx_BScreen = 0;
         /* Using cursor BC001K4 */
         pr_default.execute(2, new Object[] {A120ProfesionalesId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Profesionales", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "PROFESIONALESID");
            AnyError = 1;
         }
         A167ProfesionalesApellidoPrimero = BC001K4_A167ProfesionalesApellidoPrimero[0];
         A166ProfesionalesPrimerNombre = BC001K4_A166ProfesionalesPrimerNombre[0];
         A191ProfesionalesSegundoNombre = BC001K4_A191ProfesionalesSegundoNombre[0];
         pr_default.close(2);
         A886ProfesionalesNombreCompleto = StringUtil.Trim( A167ProfesionalesApellidoPrimero) + ", " + StringUtil.Trim( A166ProfesionalesPrimerNombre) + " " + StringUtil.Trim( A191ProfesionalesSegundoNombre);
         if ( ! ( ( StringUtil.StrCmp(A956PostulacionProfesionalEstado, "HAB") == 0 ) || ( StringUtil.StrCmp(A956PostulacionProfesionalEstado, "DES") == 0 ) || ( StringUtil.StrCmp(A956PostulacionProfesionalEstado, "PEN") == 0 ) || ( StringUtil.StrCmp(A956PostulacionProfesionalEstado, "BLO") == 0 ) ) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_OutOfRange", ""), context.GetMessage( "Postulacion Profesional Estado", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, "");
            AnyError = 1;
         }
         if ( ! ( (DateTime.MinValue==A957PostulacionProfesionalFechaA) || ( A957PostulacionProfesionalFechaA >= context.localUtil.YMDHMSToT( 1753, 1, 1, 0, 0, 0) ) ) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_OutOfRange", ""), context.GetMessage( "Postulacion Profesional Fecha A", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, "");
            AnyError = 1;
         }
         if ( ! ( (DateTime.MinValue==A958PostulacionProfesionalFechaT) || ( DateTimeUtil.ResetTime ( A958PostulacionProfesionalFechaT ) >= DateTimeUtil.ResetTime ( context.localUtil.YMDToD( 1753, 1, 1) ) ) ) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_OutOfRange", ""), context.GetMessage( "Postulacion Profesional Fecha T", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, "");
            AnyError = 1;
         }
         if ( ! ( ( StringUtil.StrCmp(A986PostulacionProfesionalUniE, "D") == 0 ) || ( StringUtil.StrCmp(A986PostulacionProfesionalUniE, "M") == 0 ) || String.IsNullOrEmpty(StringUtil.RTrim( A986PostulacionProfesionalUniE)) ) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_OutOfRange", ""), context.GetMessage( "Unidad tiempo de ejecucion", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, "");
            AnyError = 1;
         }
         if ( ! ( ( StringUtil.StrCmp(A987PostulacionProfesionalUniG, "D") == 0 ) || ( StringUtil.StrCmp(A987PostulacionProfesionalUniG, "M") == 0 ) || String.IsNullOrEmpty(StringUtil.RTrim( A987PostulacionProfesionalUniG)) ) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_OutOfRange", ""), context.GetMessage( "Unidad tiempo Garantia", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, "");
            AnyError = 1;
         }
      }

      protected void CloseExtendedTableCursors1K137( )
      {
         pr_default.close(2);
      }

      protected void enableDisable1K137( )
      {
      }

      protected void GetKey1K137( )
      {
         /* Using cursor BC001K41 */
         pr_default.execute(36, new Object[] {n422PostulacionesId, A422PostulacionesId, A120ProfesionalesId});
         if ( (pr_default.getStatus(36) != 101) )
         {
            RcdFound137 = 1;
         }
         else
         {
            RcdFound137 = 0;
         }
         pr_default.close(36);
      }

      protected void getByPrimaryKey1K137( )
      {
         /* Using cursor BC001K3 */
         pr_default.execute(1, new Object[] {n422PostulacionesId, A422PostulacionesId, A120ProfesionalesId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM1K137( 23) ;
            RcdFound137 = 1;
            InitializeNonKey1K137( ) ;
            A956PostulacionProfesionalEstado = BC001K3_A956PostulacionProfesionalEstado[0];
            A957PostulacionProfesionalFechaA = BC001K3_A957PostulacionProfesionalFechaA[0];
            A958PostulacionProfesionalFechaT = BC001K3_A958PostulacionProfesionalFechaT[0];
            A959PostulacionProfesionalTurnoT = BC001K3_A959PostulacionProfesionalTurnoT[0];
            A982PostulacionProfesionalPrecio = BC001K3_A982PostulacionProfesionalPrecio[0];
            n982PostulacionProfesionalPrecio = BC001K3_n982PostulacionProfesionalPrecio[0];
            A983PostulacionProfesionalPlazoE = BC001K3_A983PostulacionProfesionalPlazoE[0];
            n983PostulacionProfesionalPlazoE = BC001K3_n983PostulacionProfesionalPlazoE[0];
            A986PostulacionProfesionalUniE = BC001K3_A986PostulacionProfesionalUniE[0];
            n986PostulacionProfesionalUniE = BC001K3_n986PostulacionProfesionalUniE[0];
            A985PostulacionProfesionalGar = BC001K3_A985PostulacionProfesionalGar[0];
            n985PostulacionProfesionalGar = BC001K3_n985PostulacionProfesionalGar[0];
            A987PostulacionProfesionalUniG = BC001K3_A987PostulacionProfesionalUniG[0];
            n987PostulacionProfesionalUniG = BC001K3_n987PostulacionProfesionalUniG[0];
            A984PostulacionProfesionalA = BC001K3_A984PostulacionProfesionalA[0];
            n984PostulacionProfesionalA = BC001K3_n984PostulacionProfesionalA[0];
            A120ProfesionalesId = BC001K3_A120ProfesionalesId[0];
            Z422PostulacionesId = A422PostulacionesId;
            Z120ProfesionalesId = A120ProfesionalesId;
            sMode137 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal1K137( ) ;
            Load1K137( ) ;
            Gx_mode = sMode137;
         }
         else
         {
            RcdFound137 = 0;
            InitializeNonKey1K137( ) ;
            sMode137 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal1K137( ) ;
            Gx_mode = sMode137;
         }
         if ( IsDsp( ) || IsDlt( ) )
         {
            DisableAttributes1K137( ) ;
         }
         pr_default.close(1);
      }

      protected void CheckOptimisticConcurrency1K137( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC001K2 */
            pr_default.execute(0, new Object[] {n422PostulacionesId, A422PostulacionesId, A120ProfesionalesId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"PostulacionesProfesionales"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z956PostulacionProfesionalEstado, BC001K2_A956PostulacionProfesionalEstado[0]) != 0 ) || ( Z957PostulacionProfesionalFechaA != BC001K2_A957PostulacionProfesionalFechaA[0] ) || ( DateTimeUtil.ResetTime ( Z958PostulacionProfesionalFechaT ) != DateTimeUtil.ResetTime ( BC001K2_A958PostulacionProfesionalFechaT[0] ) ) || ( StringUtil.StrCmp(Z959PostulacionProfesionalTurnoT, BC001K2_A959PostulacionProfesionalTurnoT[0]) != 0 ) || ( Z982PostulacionProfesionalPrecio != BC001K2_A982PostulacionProfesionalPrecio[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z983PostulacionProfesionalPlazoE != BC001K2_A983PostulacionProfesionalPlazoE[0] ) || ( StringUtil.StrCmp(Z986PostulacionProfesionalUniE, BC001K2_A986PostulacionProfesionalUniE[0]) != 0 ) || ( Z985PostulacionProfesionalGar != BC001K2_A985PostulacionProfesionalGar[0] ) || ( StringUtil.StrCmp(Z987PostulacionProfesionalUniG, BC001K2_A987PostulacionProfesionalUniG[0]) != 0 ) || ( StringUtil.StrCmp(Z984PostulacionProfesionalA, BC001K2_A984PostulacionProfesionalA[0]) != 0 ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"PostulacionesProfesionales"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert1K137( )
      {
         BeforeValidate1K137( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1K137( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM1K137( 0) ;
            CheckOptimisticConcurrency1K137( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1K137( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert1K137( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC001K42 */
                     pr_default.execute(37, new Object[] {n422PostulacionesId, A422PostulacionesId, A956PostulacionProfesionalEstado, A957PostulacionProfesionalFechaA, A958PostulacionProfesionalFechaT, A959PostulacionProfesionalTurnoT, n982PostulacionProfesionalPrecio, A982PostulacionProfesionalPrecio, n983PostulacionProfesionalPlazoE, A983PostulacionProfesionalPlazoE, n986PostulacionProfesionalUniE, A986PostulacionProfesionalUniE, n985PostulacionProfesionalGar, A985PostulacionProfesionalGar, n987PostulacionProfesionalUniG, A987PostulacionProfesionalUniG, n984PostulacionProfesionalA, A984PostulacionProfesionalA, A120ProfesionalesId});
                     pr_default.close(37);
                     pr_default.SmartCacheProvider.SetUpdated("PostulacionesProfesionales");
                     if ( (pr_default.getStatus(37) == 1) )
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
               Load1K137( ) ;
            }
            EndLevel1K137( ) ;
         }
         CloseExtendedTableCursors1K137( ) ;
      }

      protected void Update1K137( )
      {
         BeforeValidate1K137( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1K137( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1K137( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1K137( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate1K137( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC001K43 */
                     pr_default.execute(38, new Object[] {A956PostulacionProfesionalEstado, A957PostulacionProfesionalFechaA, A958PostulacionProfesionalFechaT, A959PostulacionProfesionalTurnoT, n982PostulacionProfesionalPrecio, A982PostulacionProfesionalPrecio, n983PostulacionProfesionalPlazoE, A983PostulacionProfesionalPlazoE, n986PostulacionProfesionalUniE, A986PostulacionProfesionalUniE, n985PostulacionProfesionalGar, A985PostulacionProfesionalGar, n987PostulacionProfesionalUniG, A987PostulacionProfesionalUniG, n984PostulacionProfesionalA, A984PostulacionProfesionalA, n422PostulacionesId, A422PostulacionesId, A120ProfesionalesId});
                     pr_default.close(38);
                     pr_default.SmartCacheProvider.SetUpdated("PostulacionesProfesionales");
                     if ( (pr_default.getStatus(38) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"PostulacionesProfesionales"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate1K137( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey1K137( ) ;
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
            EndLevel1K137( ) ;
         }
         CloseExtendedTableCursors1K137( ) ;
      }

      protected void DeferredUpdate1K137( )
      {
      }

      protected void Delete1K137( )
      {
         Gx_mode = "DLT";
         BeforeValidate1K137( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1K137( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls1K137( ) ;
            AfterConfirm1K137( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete1K137( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC001K44 */
                  pr_default.execute(39, new Object[] {n422PostulacionesId, A422PostulacionesId, A120ProfesionalesId});
                  pr_default.close(39);
                  pr_default.SmartCacheProvider.SetUpdated("PostulacionesProfesionales");
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
         sMode137 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel1K137( ) ;
         Gx_mode = sMode137;
      }

      protected void OnDeleteControls1K137( )
      {
         standaloneModal1K137( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor BC001K45 */
            pr_default.execute(40, new Object[] {A120ProfesionalesId});
            A167ProfesionalesApellidoPrimero = BC001K45_A167ProfesionalesApellidoPrimero[0];
            A166ProfesionalesPrimerNombre = BC001K45_A166ProfesionalesPrimerNombre[0];
            A191ProfesionalesSegundoNombre = BC001K45_A191ProfesionalesSegundoNombre[0];
            pr_default.close(40);
            A886ProfesionalesNombreCompleto = StringUtil.Trim( A167ProfesionalesApellidoPrimero) + ", " + StringUtil.Trim( A166ProfesionalesPrimerNombre) + " " + StringUtil.Trim( A191ProfesionalesSegundoNombre);
         }
      }

      protected void EndLevel1K137( )
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

      public void ScanKeyStart1K137( )
      {
         /* Scan By routine */
         /* Using cursor BC001K46 */
         pr_default.execute(41, new Object[] {n422PostulacionesId, A422PostulacionesId});
         RcdFound137 = 0;
         if ( (pr_default.getStatus(41) != 101) )
         {
            RcdFound137 = 1;
            A956PostulacionProfesionalEstado = BC001K46_A956PostulacionProfesionalEstado[0];
            A957PostulacionProfesionalFechaA = BC001K46_A957PostulacionProfesionalFechaA[0];
            A958PostulacionProfesionalFechaT = BC001K46_A958PostulacionProfesionalFechaT[0];
            A959PostulacionProfesionalTurnoT = BC001K46_A959PostulacionProfesionalTurnoT[0];
            A982PostulacionProfesionalPrecio = BC001K46_A982PostulacionProfesionalPrecio[0];
            n982PostulacionProfesionalPrecio = BC001K46_n982PostulacionProfesionalPrecio[0];
            A983PostulacionProfesionalPlazoE = BC001K46_A983PostulacionProfesionalPlazoE[0];
            n983PostulacionProfesionalPlazoE = BC001K46_n983PostulacionProfesionalPlazoE[0];
            A986PostulacionProfesionalUniE = BC001K46_A986PostulacionProfesionalUniE[0];
            n986PostulacionProfesionalUniE = BC001K46_n986PostulacionProfesionalUniE[0];
            A985PostulacionProfesionalGar = BC001K46_A985PostulacionProfesionalGar[0];
            n985PostulacionProfesionalGar = BC001K46_n985PostulacionProfesionalGar[0];
            A987PostulacionProfesionalUniG = BC001K46_A987PostulacionProfesionalUniG[0];
            n987PostulacionProfesionalUniG = BC001K46_n987PostulacionProfesionalUniG[0];
            A984PostulacionProfesionalA = BC001K46_A984PostulacionProfesionalA[0];
            n984PostulacionProfesionalA = BC001K46_n984PostulacionProfesionalA[0];
            A167ProfesionalesApellidoPrimero = BC001K46_A167ProfesionalesApellidoPrimero[0];
            A166ProfesionalesPrimerNombre = BC001K46_A166ProfesionalesPrimerNombre[0];
            A191ProfesionalesSegundoNombre = BC001K46_A191ProfesionalesSegundoNombre[0];
            A120ProfesionalesId = BC001K46_A120ProfesionalesId[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext1K137( )
      {
         /* Scan next routine */
         pr_default.readNext(41);
         RcdFound137 = 0;
         ScanKeyLoad1K137( ) ;
      }

      protected void ScanKeyLoad1K137( )
      {
         sMode137 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(41) != 101) )
         {
            RcdFound137 = 1;
            A956PostulacionProfesionalEstado = BC001K46_A956PostulacionProfesionalEstado[0];
            A957PostulacionProfesionalFechaA = BC001K46_A957PostulacionProfesionalFechaA[0];
            A958PostulacionProfesionalFechaT = BC001K46_A958PostulacionProfesionalFechaT[0];
            A959PostulacionProfesionalTurnoT = BC001K46_A959PostulacionProfesionalTurnoT[0];
            A982PostulacionProfesionalPrecio = BC001K46_A982PostulacionProfesionalPrecio[0];
            n982PostulacionProfesionalPrecio = BC001K46_n982PostulacionProfesionalPrecio[0];
            A983PostulacionProfesionalPlazoE = BC001K46_A983PostulacionProfesionalPlazoE[0];
            n983PostulacionProfesionalPlazoE = BC001K46_n983PostulacionProfesionalPlazoE[0];
            A986PostulacionProfesionalUniE = BC001K46_A986PostulacionProfesionalUniE[0];
            n986PostulacionProfesionalUniE = BC001K46_n986PostulacionProfesionalUniE[0];
            A985PostulacionProfesionalGar = BC001K46_A985PostulacionProfesionalGar[0];
            n985PostulacionProfesionalGar = BC001K46_n985PostulacionProfesionalGar[0];
            A987PostulacionProfesionalUniG = BC001K46_A987PostulacionProfesionalUniG[0];
            n987PostulacionProfesionalUniG = BC001K46_n987PostulacionProfesionalUniG[0];
            A984PostulacionProfesionalA = BC001K46_A984PostulacionProfesionalA[0];
            n984PostulacionProfesionalA = BC001K46_n984PostulacionProfesionalA[0];
            A167ProfesionalesApellidoPrimero = BC001K46_A167ProfesionalesApellidoPrimero[0];
            A166ProfesionalesPrimerNombre = BC001K46_A166ProfesionalesPrimerNombre[0];
            A191ProfesionalesSegundoNombre = BC001K46_A191ProfesionalesSegundoNombre[0];
            A120ProfesionalesId = BC001K46_A120ProfesionalesId[0];
         }
         Gx_mode = sMode137;
      }

      protected void ScanKeyEnd1K137( )
      {
         pr_default.close(41);
      }

      protected void AfterConfirm1K137( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert1K137( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate1K137( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete1K137( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete1K137( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate1K137( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes1K137( )
      {
      }

      protected void send_integrity_lvl_hashes1K137( )
      {
      }

      protected void send_integrity_lvl_hashes1K126( )
      {
      }

      protected void AddRow1K126( )
      {
         VarsToRow126( bcPostulaciones) ;
      }

      protected void ReadRow1K126( )
      {
         RowToVars126( bcPostulaciones, 1) ;
      }

      protected void AddRow1K142( )
      {
         SdtPostulaciones_Categorias obj142;
         obj142 = new SdtPostulaciones_Categorias(context);
         VarsToRow142( obj142) ;
         bcPostulaciones.gxTpr_Categorias.Add(obj142, 0);
         obj142.gxTpr_Mode = "UPD";
         obj142.gxTpr_Modified = 0;
      }

      protected void ReadRow1K142( )
      {
         nGXsfl_142_idx = (int)(nGXsfl_142_idx+1);
         RowToVars142( ((SdtPostulaciones_Categorias)bcPostulaciones.gxTpr_Categorias.Item(nGXsfl_142_idx)), 1) ;
      }

      protected void AddRow1K139( )
      {
         SdtPostulaciones_Multimedia obj139;
         obj139 = new SdtPostulaciones_Multimedia(context);
         VarsToRow139( obj139) ;
         bcPostulaciones.gxTpr_Multimedia.Add(obj139, 0);
         obj139.gxTpr_Mode = "UPD";
         obj139.gxTpr_Modified = 0;
      }

      protected void ReadRow1K139( )
      {
         nGXsfl_139_idx = (int)(nGXsfl_139_idx+1);
         RowToVars139( ((SdtPostulaciones_Multimedia)bcPostulaciones.gxTpr_Multimedia.Item(nGXsfl_139_idx)), 1) ;
      }

      protected void AddRow1K137( )
      {
         SdtPostulaciones_Profesionales obj137;
         obj137 = new SdtPostulaciones_Profesionales(context);
         VarsToRow137( obj137) ;
         bcPostulaciones.gxTpr_Profesionales.Add(obj137, 0);
         obj137.gxTpr_Mode = "UPD";
         obj137.gxTpr_Modified = 0;
      }

      protected void ReadRow1K137( )
      {
         nGXsfl_137_idx = (int)(nGXsfl_137_idx+1);
         RowToVars137( ((SdtPostulaciones_Profesionales)bcPostulaciones.gxTpr_Profesionales.Item(nGXsfl_137_idx)), 1) ;
      }

      protected void InitializeNonKey1K126( )
      {
         A942ServiciosId = 0;
         n942ServiciosId = false;
         A943ServiciosNombre = "";
         A945PostulacionesProveedorId = 0;
         A971PostulacionesProvNombreAux = "";
         A969PostulacionesProveedorNombre = "";
         A946PostulacionesPrecio = 0;
         A961PostulacionesMultimediaSerial = 0;
         A936PostulacionesDescripcion = "";
         A937PostulacionesReqSuministros = false;
         A938PostulacionesSuministrosDescri = "";
         A947PostulacionesFechaTrabajo = DateTime.MinValue;
         A939PostulacionesFechaCierre = DateTime.MinValue;
         A940PostulacionesHoraCierre = "";
         A941PostulacionesTipoFecha = "";
         A949PostulacionesRgoHoraservicio = "";
         A950PostulacionesApellidoNombre = "";
         A951PostulacionesMail = "";
         A952PostulacionesTelefono = "";
         A979PostulacionesDepartamentoId = 0;
         A980PostulacionesDepartamentoMunic = 0;
         A981PostulacionesZonasID = 0;
         A998PostulacionesDireccion = "";
         A425PostulacionesFechaAlta = (DateTime)(DateTime.MinValue);
         A424PostulacionesEstado = "";
         A948PostulacionesSecUserId = 0;
         O961PostulacionesMultimediaSerial = A961PostulacionesMultimediaSerial;
         Z971PostulacionesProvNombreAux = "";
         Z946PostulacionesPrecio = 0;
         Z961PostulacionesMultimediaSerial = 0;
         Z936PostulacionesDescripcion = "";
         Z937PostulacionesReqSuministros = false;
         Z938PostulacionesSuministrosDescri = "";
         Z947PostulacionesFechaTrabajo = DateTime.MinValue;
         Z939PostulacionesFechaCierre = DateTime.MinValue;
         Z940PostulacionesHoraCierre = "";
         Z941PostulacionesTipoFecha = "";
         Z949PostulacionesRgoHoraservicio = "";
         Z950PostulacionesApellidoNombre = "";
         Z951PostulacionesMail = "";
         Z952PostulacionesTelefono = "";
         Z979PostulacionesDepartamentoId = 0;
         Z980PostulacionesDepartamentoMunic = 0;
         Z981PostulacionesZonasID = 0;
         Z998PostulacionesDireccion = "";
         Z425PostulacionesFechaAlta = (DateTime)(DateTime.MinValue);
         Z424PostulacionesEstado = "";
         Z948PostulacionesSecUserId = 0;
         Z942ServiciosId = 0;
         Z945PostulacionesProveedorId = 0;
      }

      protected void InitAll1K126( )
      {
         A422PostulacionesId = 0;
         n422PostulacionesId = false;
         InitializeNonKey1K126( ) ;
      }

      protected void StandaloneModalInsert( )
      {
      }

      protected void InitializeNonKey1K142( )
      {
         A944CategoriasNombre = "";
      }

      protected void InitAll1K142( )
      {
         A931CategoriasId = 0;
         InitializeNonKey1K142( ) ;
      }

      protected void StandaloneModalInsert1K142( )
      {
      }

      protected void InitializeNonKey1K139( )
      {
         A933MultimediaDireccion = "";
         A960MultimediaDescripcion = "";
         A934MultimediaTipo = "";
         Z933MultimediaDireccion = "";
         Z960MultimediaDescripcion = "";
         Z934MultimediaTipo = "";
      }

      protected void InitAll1K139( )
      {
         A932MultimediaId = 0;
         InitializeNonKey1K139( ) ;
      }

      protected void StandaloneModalInsert1K139( )
      {
         A961PostulacionesMultimediaSerial = i961PostulacionesMultimediaSerial;
      }

      protected void InitializeNonKey1K137( )
      {
         A886ProfesionalesNombreCompleto = "";
         A956PostulacionProfesionalEstado = "";
         A957PostulacionProfesionalFechaA = (DateTime)(DateTime.MinValue);
         A958PostulacionProfesionalFechaT = DateTime.MinValue;
         A959PostulacionProfesionalTurnoT = "";
         A982PostulacionProfesionalPrecio = 0;
         n982PostulacionProfesionalPrecio = false;
         A983PostulacionProfesionalPlazoE = 0;
         n983PostulacionProfesionalPlazoE = false;
         A986PostulacionProfesionalUniE = "";
         n986PostulacionProfesionalUniE = false;
         A985PostulacionProfesionalGar = 0;
         n985PostulacionProfesionalGar = false;
         A987PostulacionProfesionalUniG = "";
         n987PostulacionProfesionalUniG = false;
         A984PostulacionProfesionalA = "";
         n984PostulacionProfesionalA = false;
         A167ProfesionalesApellidoPrimero = "";
         A166ProfesionalesPrimerNombre = "";
         A191ProfesionalesSegundoNombre = "";
         Z956PostulacionProfesionalEstado = "";
         Z957PostulacionProfesionalFechaA = (DateTime)(DateTime.MinValue);
         Z958PostulacionProfesionalFechaT = DateTime.MinValue;
         Z959PostulacionProfesionalTurnoT = "";
         Z982PostulacionProfesionalPrecio = 0;
         Z983PostulacionProfesionalPlazoE = 0;
         Z986PostulacionProfesionalUniE = "";
         Z985PostulacionProfesionalGar = 0;
         Z987PostulacionProfesionalUniG = "";
         Z984PostulacionProfesionalA = "";
      }

      protected void InitAll1K137( )
      {
         A120ProfesionalesId = "";
         InitializeNonKey1K137( ) ;
      }

      protected void StandaloneModalInsert1K137( )
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

      public void VarsToRow126( SdtPostulaciones obj126 )
      {
         obj126.gxTpr_Mode = Gx_mode;
         obj126.gxTpr_Postulacionessolicitudesid = A970PostulacionesSolicitudesId;
         obj126.gxTpr_Serviciosid = A942ServiciosId;
         obj126.gxTpr_Serviciosnombre = A943ServiciosNombre;
         obj126.gxTpr_Postulacionesproveedorid = A945PostulacionesProveedorId;
         obj126.gxTpr_Postulacionesprovnombreaux = A971PostulacionesProvNombreAux;
         obj126.gxTpr_Postulacionesproveedornombre = A969PostulacionesProveedorNombre;
         obj126.gxTpr_Postulacionesprecio = A946PostulacionesPrecio;
         obj126.gxTpr_Postulacionesmultimediaserial = A961PostulacionesMultimediaSerial;
         obj126.gxTpr_Postulacionesdescripcion = A936PostulacionesDescripcion;
         obj126.gxTpr_Postulacionesreqsuministros = A937PostulacionesReqSuministros;
         obj126.gxTpr_Postulacionessuministrosdescripcion = A938PostulacionesSuministrosDescri;
         obj126.gxTpr_Postulacionesfechatrabajo = A947PostulacionesFechaTrabajo;
         obj126.gxTpr_Postulacionesfechacierre = A939PostulacionesFechaCierre;
         obj126.gxTpr_Postulacioneshoracierre = A940PostulacionesHoraCierre;
         obj126.gxTpr_Postulacionestipofecha = A941PostulacionesTipoFecha;
         obj126.gxTpr_Postulacionesrgohoraservicio = A949PostulacionesRgoHoraservicio;
         obj126.gxTpr_Postulacionesapellidonombre = A950PostulacionesApellidoNombre;
         obj126.gxTpr_Postulacionesmail = A951PostulacionesMail;
         obj126.gxTpr_Postulacionestelefono = A952PostulacionesTelefono;
         obj126.gxTpr_Postulacionesdepartamentoid = A979PostulacionesDepartamentoId;
         obj126.gxTpr_Postulacionesdepartamentomunicipioid = A980PostulacionesDepartamentoMunic;
         obj126.gxTpr_Postulacioneszonasid = A981PostulacionesZonasID;
         obj126.gxTpr_Postulacionesdireccion = A998PostulacionesDireccion;
         obj126.gxTpr_Postulacionesfechaalta = A425PostulacionesFechaAlta;
         obj126.gxTpr_Postulacionesestado = A424PostulacionesEstado;
         obj126.gxTpr_Postulacionessecuserid = A948PostulacionesSecUserId;
         obj126.gxTpr_Postulacionesid = A422PostulacionesId;
         obj126.gxTpr_Postulacionesid_Z = Z422PostulacionesId;
         obj126.gxTpr_Serviciosid_Z = Z942ServiciosId;
         obj126.gxTpr_Serviciosnombre_Z = Z943ServiciosNombre;
         obj126.gxTpr_Postulacionesproveedorid_Z = Z945PostulacionesProveedorId;
         obj126.gxTpr_Postulacionesprovnombreaux_Z = Z971PostulacionesProvNombreAux;
         obj126.gxTpr_Postulacionesproveedornombre_Z = Z969PostulacionesProveedorNombre;
         obj126.gxTpr_Postulacionesprecio_Z = Z946PostulacionesPrecio;
         obj126.gxTpr_Postulacionesmultimediaserial_Z = Z961PostulacionesMultimediaSerial;
         obj126.gxTpr_Postulacionessolicitudesid_Z = Z970PostulacionesSolicitudesId;
         obj126.gxTpr_Postulacionesdescripcion_Z = Z936PostulacionesDescripcion;
         obj126.gxTpr_Postulacionesreqsuministros_Z = Z937PostulacionesReqSuministros;
         obj126.gxTpr_Postulacionessuministrosdescripcion_Z = Z938PostulacionesSuministrosDescri;
         obj126.gxTpr_Postulacionesfechatrabajo_Z = Z947PostulacionesFechaTrabajo;
         obj126.gxTpr_Postulacionesfechacierre_Z = Z939PostulacionesFechaCierre;
         obj126.gxTpr_Postulacioneshoracierre_Z = Z940PostulacionesHoraCierre;
         obj126.gxTpr_Postulacionestipofecha_Z = Z941PostulacionesTipoFecha;
         obj126.gxTpr_Postulacionesrgohoraservicio_Z = Z949PostulacionesRgoHoraservicio;
         obj126.gxTpr_Postulacionesapellidonombre_Z = Z950PostulacionesApellidoNombre;
         obj126.gxTpr_Postulacionesmail_Z = Z951PostulacionesMail;
         obj126.gxTpr_Postulacionestelefono_Z = Z952PostulacionesTelefono;
         obj126.gxTpr_Postulacionesdepartamentoid_Z = Z979PostulacionesDepartamentoId;
         obj126.gxTpr_Postulacionesdepartamentomunicipioid_Z = Z980PostulacionesDepartamentoMunic;
         obj126.gxTpr_Postulacioneszonasid_Z = Z981PostulacionesZonasID;
         obj126.gxTpr_Postulacionesdireccion_Z = Z998PostulacionesDireccion;
         obj126.gxTpr_Postulacionesfechaalta_Z = Z425PostulacionesFechaAlta;
         obj126.gxTpr_Postulacionesestado_Z = Z424PostulacionesEstado;
         obj126.gxTpr_Postulacionessecuserid_Z = Z948PostulacionesSecUserId;
         obj126.gxTpr_Postulacionesid_N = (short)(Convert.ToInt16(n422PostulacionesId));
         obj126.gxTpr_Serviciosid_N = (short)(Convert.ToInt16(n942ServiciosId));
         obj126.gxTpr_Postulacionessolicitudesid_N = (short)(Convert.ToInt16(n970PostulacionesSolicitudesId));
         obj126.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow126( SdtPostulaciones obj126 )
      {
         obj126.gxTpr_Postulacionesid = A422PostulacionesId;
         return  ;
      }

      public void RowToVars126( SdtPostulaciones obj126 ,
                                int forceLoad )
      {
         Gx_mode = obj126.gxTpr_Mode;
         A970PostulacionesSolicitudesId = obj126.gxTpr_Postulacionessolicitudesid;
         n970PostulacionesSolicitudesId = false;
         A942ServiciosId = obj126.gxTpr_Serviciosid;
         n942ServiciosId = false;
         A943ServiciosNombre = obj126.gxTpr_Serviciosnombre;
         A945PostulacionesProveedorId = obj126.gxTpr_Postulacionesproveedorid;
         A971PostulacionesProvNombreAux = obj126.gxTpr_Postulacionesprovnombreaux;
         A969PostulacionesProveedorNombre = obj126.gxTpr_Postulacionesproveedornombre;
         A946PostulacionesPrecio = obj126.gxTpr_Postulacionesprecio;
         if ( forceLoad == 1 )
         {
            A961PostulacionesMultimediaSerial = obj126.gxTpr_Postulacionesmultimediaserial;
         }
         A936PostulacionesDescripcion = obj126.gxTpr_Postulacionesdescripcion;
         A937PostulacionesReqSuministros = obj126.gxTpr_Postulacionesreqsuministros;
         A938PostulacionesSuministrosDescri = obj126.gxTpr_Postulacionessuministrosdescripcion;
         A947PostulacionesFechaTrabajo = obj126.gxTpr_Postulacionesfechatrabajo;
         A939PostulacionesFechaCierre = obj126.gxTpr_Postulacionesfechacierre;
         A940PostulacionesHoraCierre = obj126.gxTpr_Postulacioneshoracierre;
         A941PostulacionesTipoFecha = obj126.gxTpr_Postulacionestipofecha;
         A949PostulacionesRgoHoraservicio = obj126.gxTpr_Postulacionesrgohoraservicio;
         A950PostulacionesApellidoNombre = obj126.gxTpr_Postulacionesapellidonombre;
         A951PostulacionesMail = obj126.gxTpr_Postulacionesmail;
         A952PostulacionesTelefono = obj126.gxTpr_Postulacionestelefono;
         A979PostulacionesDepartamentoId = obj126.gxTpr_Postulacionesdepartamentoid;
         A980PostulacionesDepartamentoMunic = obj126.gxTpr_Postulacionesdepartamentomunicipioid;
         A981PostulacionesZonasID = obj126.gxTpr_Postulacioneszonasid;
         A998PostulacionesDireccion = obj126.gxTpr_Postulacionesdireccion;
         A425PostulacionesFechaAlta = obj126.gxTpr_Postulacionesfechaalta;
         A424PostulacionesEstado = obj126.gxTpr_Postulacionesestado;
         A948PostulacionesSecUserId = obj126.gxTpr_Postulacionessecuserid;
         A422PostulacionesId = obj126.gxTpr_Postulacionesid;
         n422PostulacionesId = false;
         Z422PostulacionesId = obj126.gxTpr_Postulacionesid_Z;
         Z942ServiciosId = obj126.gxTpr_Serviciosid_Z;
         Z943ServiciosNombre = obj126.gxTpr_Serviciosnombre_Z;
         Z945PostulacionesProveedorId = obj126.gxTpr_Postulacionesproveedorid_Z;
         Z971PostulacionesProvNombreAux = obj126.gxTpr_Postulacionesprovnombreaux_Z;
         Z969PostulacionesProveedorNombre = obj126.gxTpr_Postulacionesproveedornombre_Z;
         Z946PostulacionesPrecio = obj126.gxTpr_Postulacionesprecio_Z;
         Z961PostulacionesMultimediaSerial = obj126.gxTpr_Postulacionesmultimediaserial_Z;
         O961PostulacionesMultimediaSerial = obj126.gxTpr_Postulacionesmultimediaserial_Z;
         Z970PostulacionesSolicitudesId = obj126.gxTpr_Postulacionessolicitudesid_Z;
         Z936PostulacionesDescripcion = obj126.gxTpr_Postulacionesdescripcion_Z;
         Z937PostulacionesReqSuministros = obj126.gxTpr_Postulacionesreqsuministros_Z;
         Z938PostulacionesSuministrosDescri = obj126.gxTpr_Postulacionessuministrosdescripcion_Z;
         Z947PostulacionesFechaTrabajo = obj126.gxTpr_Postulacionesfechatrabajo_Z;
         Z939PostulacionesFechaCierre = obj126.gxTpr_Postulacionesfechacierre_Z;
         Z940PostulacionesHoraCierre = obj126.gxTpr_Postulacioneshoracierre_Z;
         Z941PostulacionesTipoFecha = obj126.gxTpr_Postulacionestipofecha_Z;
         Z949PostulacionesRgoHoraservicio = obj126.gxTpr_Postulacionesrgohoraservicio_Z;
         Z950PostulacionesApellidoNombre = obj126.gxTpr_Postulacionesapellidonombre_Z;
         Z951PostulacionesMail = obj126.gxTpr_Postulacionesmail_Z;
         Z952PostulacionesTelefono = obj126.gxTpr_Postulacionestelefono_Z;
         Z979PostulacionesDepartamentoId = obj126.gxTpr_Postulacionesdepartamentoid_Z;
         Z980PostulacionesDepartamentoMunic = obj126.gxTpr_Postulacionesdepartamentomunicipioid_Z;
         Z981PostulacionesZonasID = obj126.gxTpr_Postulacioneszonasid_Z;
         Z998PostulacionesDireccion = obj126.gxTpr_Postulacionesdireccion_Z;
         Z425PostulacionesFechaAlta = obj126.gxTpr_Postulacionesfechaalta_Z;
         Z424PostulacionesEstado = obj126.gxTpr_Postulacionesestado_Z;
         Z948PostulacionesSecUserId = obj126.gxTpr_Postulacionessecuserid_Z;
         n422PostulacionesId = (bool)(Convert.ToBoolean(obj126.gxTpr_Postulacionesid_N));
         n942ServiciosId = (bool)(Convert.ToBoolean(obj126.gxTpr_Serviciosid_N));
         n970PostulacionesSolicitudesId = (bool)(Convert.ToBoolean(obj126.gxTpr_Postulacionessolicitudesid_N));
         Gx_mode = obj126.gxTpr_Mode;
         return  ;
      }

      public void VarsToRow142( SdtPostulaciones_Categorias obj142 )
      {
         obj142.gxTpr_Mode = Gx_mode;
         obj142.gxTpr_Categoriasnombre = A944CategoriasNombre;
         obj142.gxTpr_Categoriasid = A931CategoriasId;
         obj142.gxTpr_Categoriasid_Z = Z931CategoriasId;
         obj142.gxTpr_Categoriasnombre_Z = Z944CategoriasNombre;
         obj142.gxTpr_Modified = nIsMod_142;
         return  ;
      }

      public void KeyVarsToRow142( SdtPostulaciones_Categorias obj142 )
      {
         obj142.gxTpr_Categoriasid = A931CategoriasId;
         return  ;
      }

      public void RowToVars142( SdtPostulaciones_Categorias obj142 ,
                                int forceLoad )
      {
         Gx_mode = obj142.gxTpr_Mode;
         A944CategoriasNombre = obj142.gxTpr_Categoriasnombre;
         A931CategoriasId = obj142.gxTpr_Categoriasid;
         Z931CategoriasId = obj142.gxTpr_Categoriasid_Z;
         Z944CategoriasNombre = obj142.gxTpr_Categoriasnombre_Z;
         nIsMod_142 = obj142.gxTpr_Modified;
         return  ;
      }

      public void VarsToRow139( SdtPostulaciones_Multimedia obj139 )
      {
         obj139.gxTpr_Mode = Gx_mode;
         obj139.gxTpr_Multimediadireccion = A933MultimediaDireccion;
         obj139.gxTpr_Multimediadescripcion = A960MultimediaDescripcion;
         obj139.gxTpr_Multimediatipo = A934MultimediaTipo;
         obj139.gxTpr_Multimediaid = A932MultimediaId;
         obj139.gxTpr_Multimediaid_Z = Z932MultimediaId;
         obj139.gxTpr_Multimediadireccion_Z = Z933MultimediaDireccion;
         obj139.gxTpr_Multimediadescripcion_Z = Z960MultimediaDescripcion;
         obj139.gxTpr_Multimediatipo_Z = Z934MultimediaTipo;
         obj139.gxTpr_Modified = nIsMod_139;
         return  ;
      }

      public void KeyVarsToRow139( SdtPostulaciones_Multimedia obj139 )
      {
         obj139.gxTpr_Multimediaid = A932MultimediaId;
         return  ;
      }

      public void RowToVars139( SdtPostulaciones_Multimedia obj139 ,
                                int forceLoad )
      {
         Gx_mode = obj139.gxTpr_Mode;
         A933MultimediaDireccion = obj139.gxTpr_Multimediadireccion;
         A960MultimediaDescripcion = obj139.gxTpr_Multimediadescripcion;
         A934MultimediaTipo = obj139.gxTpr_Multimediatipo;
         A932MultimediaId = obj139.gxTpr_Multimediaid;
         Z932MultimediaId = obj139.gxTpr_Multimediaid_Z;
         Z933MultimediaDireccion = obj139.gxTpr_Multimediadireccion_Z;
         Z960MultimediaDescripcion = obj139.gxTpr_Multimediadescripcion_Z;
         Z934MultimediaTipo = obj139.gxTpr_Multimediatipo_Z;
         nIsMod_139 = obj139.gxTpr_Modified;
         return  ;
      }

      public void VarsToRow137( SdtPostulaciones_Profesionales obj137 )
      {
         obj137.gxTpr_Mode = Gx_mode;
         obj137.gxTpr_Profesionalesnombrecompleto = A886ProfesionalesNombreCompleto;
         obj137.gxTpr_Postulacionprofesionalestado = A956PostulacionProfesionalEstado;
         obj137.gxTpr_Postulacionprofesionalfechaa = A957PostulacionProfesionalFechaA;
         obj137.gxTpr_Postulacionprofesionalfechat = A958PostulacionProfesionalFechaT;
         obj137.gxTpr_Postulacionprofesionalturnot = A959PostulacionProfesionalTurnoT;
         obj137.gxTpr_Postulacionprofesionalprecio = A982PostulacionProfesionalPrecio;
         obj137.gxTpr_Postulacionprofesionalplazoe = A983PostulacionProfesionalPlazoE;
         obj137.gxTpr_Postulacionprofesionalunie = A986PostulacionProfesionalUniE;
         obj137.gxTpr_Postulacionprofesionalgar = A985PostulacionProfesionalGar;
         obj137.gxTpr_Postulacionprofesionalunig = A987PostulacionProfesionalUniG;
         obj137.gxTpr_Postulacionprofesionala = A984PostulacionProfesionalA;
         obj137.gxTpr_Profesionalesid = A120ProfesionalesId;
         obj137.gxTpr_Profesionalesid_Z = Z120ProfesionalesId;
         obj137.gxTpr_Profesionalesnombrecompleto_Z = Z886ProfesionalesNombreCompleto;
         obj137.gxTpr_Postulacionprofesionalestado_Z = Z956PostulacionProfesionalEstado;
         obj137.gxTpr_Postulacionprofesionalfechaa_Z = Z957PostulacionProfesionalFechaA;
         obj137.gxTpr_Postulacionprofesionalfechat_Z = Z958PostulacionProfesionalFechaT;
         obj137.gxTpr_Postulacionprofesionalturnot_Z = Z959PostulacionProfesionalTurnoT;
         obj137.gxTpr_Postulacionprofesionalprecio_Z = Z982PostulacionProfesionalPrecio;
         obj137.gxTpr_Postulacionprofesionalplazoe_Z = Z983PostulacionProfesionalPlazoE;
         obj137.gxTpr_Postulacionprofesionalunie_Z = Z986PostulacionProfesionalUniE;
         obj137.gxTpr_Postulacionprofesionalgar_Z = Z985PostulacionProfesionalGar;
         obj137.gxTpr_Postulacionprofesionalunig_Z = Z987PostulacionProfesionalUniG;
         obj137.gxTpr_Postulacionprofesionala_Z = Z984PostulacionProfesionalA;
         obj137.gxTpr_Postulacionprofesionalprecio_N = (short)(Convert.ToInt16(n982PostulacionProfesionalPrecio));
         obj137.gxTpr_Postulacionprofesionalplazoe_N = (short)(Convert.ToInt16(n983PostulacionProfesionalPlazoE));
         obj137.gxTpr_Postulacionprofesionalunie_N = (short)(Convert.ToInt16(n986PostulacionProfesionalUniE));
         obj137.gxTpr_Postulacionprofesionalgar_N = (short)(Convert.ToInt16(n985PostulacionProfesionalGar));
         obj137.gxTpr_Postulacionprofesionalunig_N = (short)(Convert.ToInt16(n987PostulacionProfesionalUniG));
         obj137.gxTpr_Postulacionprofesionala_N = (short)(Convert.ToInt16(n984PostulacionProfesionalA));
         obj137.gxTpr_Modified = nIsMod_137;
         return  ;
      }

      public void KeyVarsToRow137( SdtPostulaciones_Profesionales obj137 )
      {
         obj137.gxTpr_Profesionalesid = A120ProfesionalesId;
         return  ;
      }

      public void RowToVars137( SdtPostulaciones_Profesionales obj137 ,
                                int forceLoad )
      {
         Gx_mode = obj137.gxTpr_Mode;
         A886ProfesionalesNombreCompleto = obj137.gxTpr_Profesionalesnombrecompleto;
         A956PostulacionProfesionalEstado = obj137.gxTpr_Postulacionprofesionalestado;
         A957PostulacionProfesionalFechaA = obj137.gxTpr_Postulacionprofesionalfechaa;
         A958PostulacionProfesionalFechaT = obj137.gxTpr_Postulacionprofesionalfechat;
         A959PostulacionProfesionalTurnoT = obj137.gxTpr_Postulacionprofesionalturnot;
         A982PostulacionProfesionalPrecio = obj137.gxTpr_Postulacionprofesionalprecio;
         n982PostulacionProfesionalPrecio = false;
         A983PostulacionProfesionalPlazoE = obj137.gxTpr_Postulacionprofesionalplazoe;
         n983PostulacionProfesionalPlazoE = false;
         A986PostulacionProfesionalUniE = obj137.gxTpr_Postulacionprofesionalunie;
         n986PostulacionProfesionalUniE = false;
         A985PostulacionProfesionalGar = obj137.gxTpr_Postulacionprofesionalgar;
         n985PostulacionProfesionalGar = false;
         A987PostulacionProfesionalUniG = obj137.gxTpr_Postulacionprofesionalunig;
         n987PostulacionProfesionalUniG = false;
         A984PostulacionProfesionalA = obj137.gxTpr_Postulacionprofesionala;
         n984PostulacionProfesionalA = false;
         A120ProfesionalesId = obj137.gxTpr_Profesionalesid;
         Z120ProfesionalesId = obj137.gxTpr_Profesionalesid_Z;
         Z886ProfesionalesNombreCompleto = obj137.gxTpr_Profesionalesnombrecompleto_Z;
         Z956PostulacionProfesionalEstado = obj137.gxTpr_Postulacionprofesionalestado_Z;
         Z957PostulacionProfesionalFechaA = obj137.gxTpr_Postulacionprofesionalfechaa_Z;
         Z958PostulacionProfesionalFechaT = obj137.gxTpr_Postulacionprofesionalfechat_Z;
         Z959PostulacionProfesionalTurnoT = obj137.gxTpr_Postulacionprofesionalturnot_Z;
         Z982PostulacionProfesionalPrecio = obj137.gxTpr_Postulacionprofesionalprecio_Z;
         Z983PostulacionProfesionalPlazoE = obj137.gxTpr_Postulacionprofesionalplazoe_Z;
         Z986PostulacionProfesionalUniE = obj137.gxTpr_Postulacionprofesionalunie_Z;
         Z985PostulacionProfesionalGar = obj137.gxTpr_Postulacionprofesionalgar_Z;
         Z987PostulacionProfesionalUniG = obj137.gxTpr_Postulacionprofesionalunig_Z;
         Z984PostulacionProfesionalA = obj137.gxTpr_Postulacionprofesionala_Z;
         n982PostulacionProfesionalPrecio = (bool)(Convert.ToBoolean(obj137.gxTpr_Postulacionprofesionalprecio_N));
         n983PostulacionProfesionalPlazoE = (bool)(Convert.ToBoolean(obj137.gxTpr_Postulacionprofesionalplazoe_N));
         n986PostulacionProfesionalUniE = (bool)(Convert.ToBoolean(obj137.gxTpr_Postulacionprofesionalunie_N));
         n985PostulacionProfesionalGar = (bool)(Convert.ToBoolean(obj137.gxTpr_Postulacionprofesionalgar_N));
         n987PostulacionProfesionalUniG = (bool)(Convert.ToBoolean(obj137.gxTpr_Postulacionprofesionalunig_N));
         n984PostulacionProfesionalA = (bool)(Convert.ToBoolean(obj137.gxTpr_Postulacionprofesionala_N));
         nIsMod_137 = obj137.gxTpr_Modified;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A422PostulacionesId = (long)getParm(obj,0);
         n422PostulacionesId = false;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey1K126( ) ;
         ScanKeyStart1K126( ) ;
         if ( RcdFound126 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z422PostulacionesId = A422PostulacionesId;
            O961PostulacionesMultimediaSerial = A961PostulacionesMultimediaSerial;
         }
         ZM1K126( -16) ;
         OnLoadActions1K126( ) ;
         AddRow1K126( ) ;
         bcPostulaciones.gxTpr_Categorias.ClearCollection();
         if ( RcdFound126 == 1 )
         {
            ScanKeyStart1K142( ) ;
            nGXsfl_142_idx = 1;
            while ( RcdFound142 != 0 )
            {
               Z422PostulacionesId = A422PostulacionesId;
               Z931CategoriasId = A931CategoriasId;
               ZM1K142( -20) ;
               OnLoadActions1K142( ) ;
               nRcdExists_142 = 1;
               nIsMod_142 = 0;
               AddRow1K142( ) ;
               nGXsfl_142_idx = (int)(nGXsfl_142_idx+1);
               ScanKeyNext1K142( ) ;
            }
            ScanKeyEnd1K142( ) ;
         }
         bcPostulaciones.gxTpr_Multimedia.ClearCollection();
         if ( RcdFound126 == 1 )
         {
            ScanKeyStart1K139( ) ;
            nGXsfl_139_idx = 1;
            while ( RcdFound139 != 0 )
            {
               Z422PostulacionesId = A422PostulacionesId;
               Z932MultimediaId = A932MultimediaId;
               ZM1K139( -22) ;
               OnLoadActions1K139( ) ;
               nRcdExists_139 = 1;
               nIsMod_139 = 0;
               AddRow1K139( ) ;
               nGXsfl_139_idx = (int)(nGXsfl_139_idx+1);
               ScanKeyNext1K139( ) ;
            }
            ScanKeyEnd1K139( ) ;
         }
         bcPostulaciones.gxTpr_Profesionales.ClearCollection();
         if ( RcdFound126 == 1 )
         {
            ScanKeyStart1K137( ) ;
            nGXsfl_137_idx = 1;
            while ( RcdFound137 != 0 )
            {
               Z422PostulacionesId = A422PostulacionesId;
               Z120ProfesionalesId = A120ProfesionalesId;
               ZM1K137( -23) ;
               OnLoadActions1K137( ) ;
               nRcdExists_137 = 1;
               nIsMod_137 = 0;
               AddRow1K137( ) ;
               nGXsfl_137_idx = (int)(nGXsfl_137_idx+1);
               ScanKeyNext1K137( ) ;
            }
            ScanKeyEnd1K137( ) ;
         }
         ScanKeyEnd1K126( ) ;
         if ( RcdFound126 == 0 )
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
         RowToVars126( bcPostulaciones, 0) ;
         ScanKeyStart1K126( ) ;
         if ( RcdFound126 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z422PostulacionesId = A422PostulacionesId;
            O961PostulacionesMultimediaSerial = A961PostulacionesMultimediaSerial;
         }
         ZM1K126( -16) ;
         OnLoadActions1K126( ) ;
         AddRow1K126( ) ;
         bcPostulaciones.gxTpr_Categorias.ClearCollection();
         if ( RcdFound126 == 1 )
         {
            ScanKeyStart1K142( ) ;
            nGXsfl_142_idx = 1;
            while ( RcdFound142 != 0 )
            {
               Z422PostulacionesId = A422PostulacionesId;
               Z931CategoriasId = A931CategoriasId;
               ZM1K142( -20) ;
               OnLoadActions1K142( ) ;
               nRcdExists_142 = 1;
               nIsMod_142 = 0;
               AddRow1K142( ) ;
               nGXsfl_142_idx = (int)(nGXsfl_142_idx+1);
               ScanKeyNext1K142( ) ;
            }
            ScanKeyEnd1K142( ) ;
         }
         bcPostulaciones.gxTpr_Multimedia.ClearCollection();
         if ( RcdFound126 == 1 )
         {
            ScanKeyStart1K139( ) ;
            nGXsfl_139_idx = 1;
            while ( RcdFound139 != 0 )
            {
               Z422PostulacionesId = A422PostulacionesId;
               Z932MultimediaId = A932MultimediaId;
               ZM1K139( -22) ;
               OnLoadActions1K139( ) ;
               nRcdExists_139 = 1;
               nIsMod_139 = 0;
               AddRow1K139( ) ;
               nGXsfl_139_idx = (int)(nGXsfl_139_idx+1);
               ScanKeyNext1K139( ) ;
            }
            ScanKeyEnd1K139( ) ;
         }
         bcPostulaciones.gxTpr_Profesionales.ClearCollection();
         if ( RcdFound126 == 1 )
         {
            ScanKeyStart1K137( ) ;
            nGXsfl_137_idx = 1;
            while ( RcdFound137 != 0 )
            {
               Z422PostulacionesId = A422PostulacionesId;
               Z120ProfesionalesId = A120ProfesionalesId;
               ZM1K137( -23) ;
               OnLoadActions1K137( ) ;
               nRcdExists_137 = 1;
               nIsMod_137 = 0;
               AddRow1K137( ) ;
               nGXsfl_137_idx = (int)(nGXsfl_137_idx+1);
               ScanKeyNext1K137( ) ;
            }
            ScanKeyEnd1K137( ) ;
         }
         ScanKeyEnd1K126( ) ;
         if ( RcdFound126 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         GetKey1K126( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            A961PostulacionesMultimediaSerial = O961PostulacionesMultimediaSerial;
            Insert1K126( ) ;
         }
         else
         {
            if ( RcdFound126 == 1 )
            {
               if ( A422PostulacionesId != Z422PostulacionesId )
               {
                  A422PostulacionesId = Z422PostulacionesId;
                  n422PostulacionesId = false;
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "");
                  AnyError = 1;
               }
               else if ( IsDlt( ) )
               {
                  A961PostulacionesMultimediaSerial = O961PostulacionesMultimediaSerial;
                  delete( ) ;
                  AfterTrn( ) ;
               }
               else
               {
                  Gx_mode = "UPD";
                  /* Update record */
                  A961PostulacionesMultimediaSerial = O961PostulacionesMultimediaSerial;
                  Update1K126( ) ;
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
                  if ( A422PostulacionesId != Z422PostulacionesId )
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
                        A961PostulacionesMultimediaSerial = O961PostulacionesMultimediaSerial;
                        Insert1K126( ) ;
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
                        A961PostulacionesMultimediaSerial = O961PostulacionesMultimediaSerial;
                        Insert1K126( ) ;
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
         RowToVars126( bcPostulaciones, 1) ;
         SaveImpl( ) ;
         VarsToRow126( bcPostulaciones) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public bool Insert( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars126( bcPostulaciones, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         A961PostulacionesMultimediaSerial = O961PostulacionesMultimediaSerial;
         Insert1K126( ) ;
         AfterTrn( ) ;
         VarsToRow126( bcPostulaciones) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
            VarsToRow126( bcPostulaciones) ;
         }
         else
         {
            SdtPostulaciones auxBC = new SdtPostulaciones(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A422PostulacionesId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcPostulaciones);
               auxBC.Save();
               bcPostulaciones.Copy((GxSilentTrnSdt)(auxBC));
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
         RowToVars126( bcPostulaciones, 1) ;
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
         RowToVars126( bcPostulaciones, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert1K126( ) ;
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
               VarsToRow126( bcPostulaciones) ;
            }
         }
         else
         {
            AfterTrn( ) ;
            VarsToRow126( bcPostulaciones) ;
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
         RowToVars126( bcPostulaciones, 0) ;
         GetKey1K126( ) ;
         if ( RcdFound126 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( A422PostulacionesId != Z422PostulacionesId )
            {
               A422PostulacionesId = Z422PostulacionesId;
               n422PostulacionesId = false;
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
            if ( A422PostulacionesId != Z422PostulacionesId )
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
         pr_default.close(9);
         pr_default.close(6);
         pr_default.close(4);
         pr_default.close(1);
         pr_default.close(18);
         pr_default.close(19);
         pr_default.close(27);
         pr_default.close(40);
         context.RollbackDataStores("postulaciones_bc",pr_default);
         VarsToRow126( bcPostulaciones) ;
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
         Gx_mode = bcPostulaciones.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcPostulaciones.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcPostulaciones )
         {
            bcPostulaciones = (SdtPostulaciones)(sdt);
            if ( StringUtil.StrCmp(bcPostulaciones.gxTpr_Mode, "") == 0 )
            {
               bcPostulaciones.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow126( bcPostulaciones) ;
            }
            else
            {
               RowToVars126( bcPostulaciones, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcPostulaciones.gxTpr_Mode, "") == 0 )
            {
               bcPostulaciones.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars126( bcPostulaciones, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         return  ;
      }

      public SdtPostulaciones Postulaciones_BC
      {
         get {
            return bcPostulaciones ;
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
         pr_default.close(40);
         pr_default.close(4);
         pr_default.close(6);
         pr_default.close(27);
         pr_default.close(9);
         pr_default.close(18);
         pr_default.close(19);
      }

      public override void initialize( )
      {
         Gx_mode = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         sMode126 = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV25Pgmname = "";
         GXKey = "";
         GXEncryptionTmp = "";
         AV12TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV13WebSession = context.GetSession();
         AV15TrnContextAtt = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute(context);
         AV24VerMas = "";
         imgVermas_gximage = "";
         AV27Vermas_GXI = "";
         imgVermas_Tooltiptext = "";
         Z971PostulacionesProvNombreAux = "";
         A971PostulacionesProvNombreAux = "";
         Z936PostulacionesDescripcion = "";
         A936PostulacionesDescripcion = "";
         Z938PostulacionesSuministrosDescri = "";
         A938PostulacionesSuministrosDescri = "";
         Z947PostulacionesFechaTrabajo = DateTime.MinValue;
         A947PostulacionesFechaTrabajo = DateTime.MinValue;
         Z939PostulacionesFechaCierre = DateTime.MinValue;
         A939PostulacionesFechaCierre = DateTime.MinValue;
         Z940PostulacionesHoraCierre = "";
         A940PostulacionesHoraCierre = "";
         Z941PostulacionesTipoFecha = "";
         A941PostulacionesTipoFecha = "";
         Z949PostulacionesRgoHoraservicio = "";
         A949PostulacionesRgoHoraservicio = "";
         Z950PostulacionesApellidoNombre = "";
         A950PostulacionesApellidoNombre = "";
         Z951PostulacionesMail = "";
         A951PostulacionesMail = "";
         Z952PostulacionesTelefono = "";
         A952PostulacionesTelefono = "";
         Z998PostulacionesDireccion = "";
         A998PostulacionesDireccion = "";
         Z425PostulacionesFechaAlta = (DateTime)(DateTime.MinValue);
         A425PostulacionesFechaAlta = (DateTime)(DateTime.MinValue);
         Z424PostulacionesEstado = "";
         A424PostulacionesEstado = "";
         Z943ServiciosNombre = "";
         A943ServiciosNombre = "";
         Z969PostulacionesProveedorNombre = "";
         A969PostulacionesProveedorNombre = "";
         BC001K13_A970PostulacionesSolicitudesId = new long[1] ;
         BC001K13_n970PostulacionesSolicitudesId = new bool[] {false} ;
         BC001K17_A422PostulacionesId = new long[1] ;
         BC001K17_n422PostulacionesId = new bool[] {false} ;
         BC001K17_A943ServiciosNombre = new string[] {""} ;
         BC001K17_A971PostulacionesProvNombreAux = new string[] {""} ;
         BC001K17_A969PostulacionesProveedorNombre = new string[] {""} ;
         BC001K17_A946PostulacionesPrecio = new decimal[1] ;
         BC001K17_A961PostulacionesMultimediaSerial = new short[1] ;
         BC001K17_A936PostulacionesDescripcion = new string[] {""} ;
         BC001K17_A937PostulacionesReqSuministros = new bool[] {false} ;
         BC001K17_A938PostulacionesSuministrosDescri = new string[] {""} ;
         BC001K17_A947PostulacionesFechaTrabajo = new DateTime[] {DateTime.MinValue} ;
         BC001K17_A939PostulacionesFechaCierre = new DateTime[] {DateTime.MinValue} ;
         BC001K17_A940PostulacionesHoraCierre = new string[] {""} ;
         BC001K17_A941PostulacionesTipoFecha = new string[] {""} ;
         BC001K17_A949PostulacionesRgoHoraservicio = new string[] {""} ;
         BC001K17_A950PostulacionesApellidoNombre = new string[] {""} ;
         BC001K17_A951PostulacionesMail = new string[] {""} ;
         BC001K17_A952PostulacionesTelefono = new string[] {""} ;
         BC001K17_A979PostulacionesDepartamentoId = new long[1] ;
         BC001K17_A980PostulacionesDepartamentoMunic = new long[1] ;
         BC001K17_A981PostulacionesZonasID = new long[1] ;
         BC001K17_A998PostulacionesDireccion = new string[] {""} ;
         BC001K17_A425PostulacionesFechaAlta = new DateTime[] {DateTime.MinValue} ;
         BC001K17_A424PostulacionesEstado = new string[] {""} ;
         BC001K17_A948PostulacionesSecUserId = new long[1] ;
         BC001K17_A942ServiciosId = new long[1] ;
         BC001K17_n942ServiciosId = new bool[] {false} ;
         BC001K17_A945PostulacionesProveedorId = new long[1] ;
         BC001K17_A970PostulacionesSolicitudesId = new long[1] ;
         BC001K17_n970PostulacionesSolicitudesId = new bool[] {false} ;
         BC001K14_A943ServiciosNombre = new string[] {""} ;
         BC001K15_A969PostulacionesProveedorNombre = new string[] {""} ;
         BC001K18_A422PostulacionesId = new long[1] ;
         BC001K18_n422PostulacionesId = new bool[] {false} ;
         BC001K11_A422PostulacionesId = new long[1] ;
         BC001K11_n422PostulacionesId = new bool[] {false} ;
         BC001K11_A971PostulacionesProvNombreAux = new string[] {""} ;
         BC001K11_A946PostulacionesPrecio = new decimal[1] ;
         BC001K11_A961PostulacionesMultimediaSerial = new short[1] ;
         BC001K11_A936PostulacionesDescripcion = new string[] {""} ;
         BC001K11_A937PostulacionesReqSuministros = new bool[] {false} ;
         BC001K11_A938PostulacionesSuministrosDescri = new string[] {""} ;
         BC001K11_A947PostulacionesFechaTrabajo = new DateTime[] {DateTime.MinValue} ;
         BC001K11_A939PostulacionesFechaCierre = new DateTime[] {DateTime.MinValue} ;
         BC001K11_A940PostulacionesHoraCierre = new string[] {""} ;
         BC001K11_A941PostulacionesTipoFecha = new string[] {""} ;
         BC001K11_A949PostulacionesRgoHoraservicio = new string[] {""} ;
         BC001K11_A950PostulacionesApellidoNombre = new string[] {""} ;
         BC001K11_A951PostulacionesMail = new string[] {""} ;
         BC001K11_A952PostulacionesTelefono = new string[] {""} ;
         BC001K11_A979PostulacionesDepartamentoId = new long[1] ;
         BC001K11_A980PostulacionesDepartamentoMunic = new long[1] ;
         BC001K11_A981PostulacionesZonasID = new long[1] ;
         BC001K11_A998PostulacionesDireccion = new string[] {""} ;
         BC001K11_A425PostulacionesFechaAlta = new DateTime[] {DateTime.MinValue} ;
         BC001K11_A424PostulacionesEstado = new string[] {""} ;
         BC001K11_A948PostulacionesSecUserId = new long[1] ;
         BC001K11_A942ServiciosId = new long[1] ;
         BC001K11_n942ServiciosId = new bool[] {false} ;
         BC001K11_A945PostulacionesProveedorId = new long[1] ;
         BC001K10_A422PostulacionesId = new long[1] ;
         BC001K10_n422PostulacionesId = new bool[] {false} ;
         BC001K10_A971PostulacionesProvNombreAux = new string[] {""} ;
         BC001K10_A946PostulacionesPrecio = new decimal[1] ;
         BC001K10_A961PostulacionesMultimediaSerial = new short[1] ;
         BC001K10_A936PostulacionesDescripcion = new string[] {""} ;
         BC001K10_A937PostulacionesReqSuministros = new bool[] {false} ;
         BC001K10_A938PostulacionesSuministrosDescri = new string[] {""} ;
         BC001K10_A947PostulacionesFechaTrabajo = new DateTime[] {DateTime.MinValue} ;
         BC001K10_A939PostulacionesFechaCierre = new DateTime[] {DateTime.MinValue} ;
         BC001K10_A940PostulacionesHoraCierre = new string[] {""} ;
         BC001K10_A941PostulacionesTipoFecha = new string[] {""} ;
         BC001K10_A949PostulacionesRgoHoraservicio = new string[] {""} ;
         BC001K10_A950PostulacionesApellidoNombre = new string[] {""} ;
         BC001K10_A951PostulacionesMail = new string[] {""} ;
         BC001K10_A952PostulacionesTelefono = new string[] {""} ;
         BC001K10_A979PostulacionesDepartamentoId = new long[1] ;
         BC001K10_A980PostulacionesDepartamentoMunic = new long[1] ;
         BC001K10_A981PostulacionesZonasID = new long[1] ;
         BC001K10_A998PostulacionesDireccion = new string[] {""} ;
         BC001K10_A425PostulacionesFechaAlta = new DateTime[] {DateTime.MinValue} ;
         BC001K10_A424PostulacionesEstado = new string[] {""} ;
         BC001K10_A948PostulacionesSecUserId = new long[1] ;
         BC001K10_A942ServiciosId = new long[1] ;
         BC001K10_n942ServiciosId = new bool[] {false} ;
         BC001K10_A945PostulacionesProveedorId = new long[1] ;
         BC001K19_A422PostulacionesId = new long[1] ;
         BC001K19_n422PostulacionesId = new bool[] {false} ;
         BC001K22_A943ServiciosNombre = new string[] {""} ;
         BC001K23_A969PostulacionesProveedorNombre = new string[] {""} ;
         BC001K24_A127SolicitudesID = new long[1] ;
         BC001K27_A422PostulacionesId = new long[1] ;
         BC001K27_n422PostulacionesId = new bool[] {false} ;
         BC001K27_A943ServiciosNombre = new string[] {""} ;
         BC001K27_A971PostulacionesProvNombreAux = new string[] {""} ;
         BC001K27_A969PostulacionesProveedorNombre = new string[] {""} ;
         BC001K27_A946PostulacionesPrecio = new decimal[1] ;
         BC001K27_A961PostulacionesMultimediaSerial = new short[1] ;
         BC001K27_A936PostulacionesDescripcion = new string[] {""} ;
         BC001K27_A937PostulacionesReqSuministros = new bool[] {false} ;
         BC001K27_A938PostulacionesSuministrosDescri = new string[] {""} ;
         BC001K27_A947PostulacionesFechaTrabajo = new DateTime[] {DateTime.MinValue} ;
         BC001K27_A939PostulacionesFechaCierre = new DateTime[] {DateTime.MinValue} ;
         BC001K27_A940PostulacionesHoraCierre = new string[] {""} ;
         BC001K27_A941PostulacionesTipoFecha = new string[] {""} ;
         BC001K27_A949PostulacionesRgoHoraservicio = new string[] {""} ;
         BC001K27_A950PostulacionesApellidoNombre = new string[] {""} ;
         BC001K27_A951PostulacionesMail = new string[] {""} ;
         BC001K27_A952PostulacionesTelefono = new string[] {""} ;
         BC001K27_A979PostulacionesDepartamentoId = new long[1] ;
         BC001K27_A980PostulacionesDepartamentoMunic = new long[1] ;
         BC001K27_A981PostulacionesZonasID = new long[1] ;
         BC001K27_A998PostulacionesDireccion = new string[] {""} ;
         BC001K27_A425PostulacionesFechaAlta = new DateTime[] {DateTime.MinValue} ;
         BC001K27_A424PostulacionesEstado = new string[] {""} ;
         BC001K27_A948PostulacionesSecUserId = new long[1] ;
         BC001K27_A942ServiciosId = new long[1] ;
         BC001K27_n942ServiciosId = new bool[] {false} ;
         BC001K27_A945PostulacionesProveedorId = new long[1] ;
         BC001K27_A970PostulacionesSolicitudesId = new long[1] ;
         BC001K27_n970PostulacionesSolicitudesId = new bool[] {false} ;
         Z944CategoriasNombre = "";
         A944CategoriasNombre = "";
         BC001K28_A942ServiciosId = new long[1] ;
         BC001K28_n942ServiciosId = new bool[] {false} ;
         BC001K28_A422PostulacionesId = new long[1] ;
         BC001K28_n422PostulacionesId = new bool[] {false} ;
         BC001K28_A944CategoriasNombre = new string[] {""} ;
         BC001K28_A931CategoriasId = new long[1] ;
         BC001K9_A944CategoriasNombre = new string[] {""} ;
         BC001K29_A422PostulacionesId = new long[1] ;
         BC001K29_n422PostulacionesId = new bool[] {false} ;
         BC001K29_A931CategoriasId = new long[1] ;
         BC001K8_A422PostulacionesId = new long[1] ;
         BC001K8_n422PostulacionesId = new bool[] {false} ;
         BC001K8_A931CategoriasId = new long[1] ;
         sMode142 = "";
         BC001K7_A422PostulacionesId = new long[1] ;
         BC001K7_n422PostulacionesId = new bool[] {false} ;
         BC001K7_A931CategoriasId = new long[1] ;
         BC001K32_A944CategoriasNombre = new string[] {""} ;
         BC001K33_A942ServiciosId = new long[1] ;
         BC001K33_n942ServiciosId = new bool[] {false} ;
         BC001K33_A422PostulacionesId = new long[1] ;
         BC001K33_n422PostulacionesId = new bool[] {false} ;
         BC001K33_A944CategoriasNombre = new string[] {""} ;
         BC001K33_A931CategoriasId = new long[1] ;
         Z933MultimediaDireccion = "";
         A933MultimediaDireccion = "";
         Z960MultimediaDescripcion = "";
         A960MultimediaDescripcion = "";
         Z934MultimediaTipo = "";
         A934MultimediaTipo = "";
         BC001K34_A422PostulacionesId = new long[1] ;
         BC001K34_n422PostulacionesId = new bool[] {false} ;
         BC001K34_A932MultimediaId = new long[1] ;
         BC001K34_A933MultimediaDireccion = new string[] {""} ;
         BC001K34_A960MultimediaDescripcion = new string[] {""} ;
         BC001K34_A934MultimediaTipo = new string[] {""} ;
         BC001K35_A422PostulacionesId = new long[1] ;
         BC001K35_n422PostulacionesId = new bool[] {false} ;
         BC001K35_A932MultimediaId = new long[1] ;
         BC001K6_A422PostulacionesId = new long[1] ;
         BC001K6_n422PostulacionesId = new bool[] {false} ;
         BC001K6_A932MultimediaId = new long[1] ;
         BC001K6_A933MultimediaDireccion = new string[] {""} ;
         BC001K6_A960MultimediaDescripcion = new string[] {""} ;
         BC001K6_A934MultimediaTipo = new string[] {""} ;
         sMode139 = "";
         BC001K5_A422PostulacionesId = new long[1] ;
         BC001K5_n422PostulacionesId = new bool[] {false} ;
         BC001K5_A932MultimediaId = new long[1] ;
         BC001K5_A933MultimediaDireccion = new string[] {""} ;
         BC001K5_A960MultimediaDescripcion = new string[] {""} ;
         BC001K5_A934MultimediaTipo = new string[] {""} ;
         BC001K39_A422PostulacionesId = new long[1] ;
         BC001K39_n422PostulacionesId = new bool[] {false} ;
         BC001K39_A932MultimediaId = new long[1] ;
         BC001K39_A933MultimediaDireccion = new string[] {""} ;
         BC001K39_A960MultimediaDescripcion = new string[] {""} ;
         BC001K39_A934MultimediaTipo = new string[] {""} ;
         Z956PostulacionProfesionalEstado = "";
         A956PostulacionProfesionalEstado = "";
         Z957PostulacionProfesionalFechaA = (DateTime)(DateTime.MinValue);
         A957PostulacionProfesionalFechaA = (DateTime)(DateTime.MinValue);
         Z958PostulacionProfesionalFechaT = DateTime.MinValue;
         A958PostulacionProfesionalFechaT = DateTime.MinValue;
         Z959PostulacionProfesionalTurnoT = "";
         A959PostulacionProfesionalTurnoT = "";
         Z986PostulacionProfesionalUniE = "";
         A986PostulacionProfesionalUniE = "";
         Z987PostulacionProfesionalUniG = "";
         A987PostulacionProfesionalUniG = "";
         Z984PostulacionProfesionalA = "";
         A984PostulacionProfesionalA = "";
         Z886ProfesionalesNombreCompleto = "";
         A886ProfesionalesNombreCompleto = "";
         Z167ProfesionalesApellidoPrimero = "";
         A167ProfesionalesApellidoPrimero = "";
         Z166ProfesionalesPrimerNombre = "";
         A166ProfesionalesPrimerNombre = "";
         Z191ProfesionalesSegundoNombre = "";
         A191ProfesionalesSegundoNombre = "";
         Z120ProfesionalesId = "";
         A120ProfesionalesId = "";
         BC001K40_A422PostulacionesId = new long[1] ;
         BC001K40_n422PostulacionesId = new bool[] {false} ;
         BC001K40_A956PostulacionProfesionalEstado = new string[] {""} ;
         BC001K40_A957PostulacionProfesionalFechaA = new DateTime[] {DateTime.MinValue} ;
         BC001K40_A958PostulacionProfesionalFechaT = new DateTime[] {DateTime.MinValue} ;
         BC001K40_A959PostulacionProfesionalTurnoT = new string[] {""} ;
         BC001K40_A982PostulacionProfesionalPrecio = new decimal[1] ;
         BC001K40_n982PostulacionProfesionalPrecio = new bool[] {false} ;
         BC001K40_A983PostulacionProfesionalPlazoE = new short[1] ;
         BC001K40_n983PostulacionProfesionalPlazoE = new bool[] {false} ;
         BC001K40_A986PostulacionProfesionalUniE = new string[] {""} ;
         BC001K40_n986PostulacionProfesionalUniE = new bool[] {false} ;
         BC001K40_A985PostulacionProfesionalGar = new short[1] ;
         BC001K40_n985PostulacionProfesionalGar = new bool[] {false} ;
         BC001K40_A987PostulacionProfesionalUniG = new string[] {""} ;
         BC001K40_n987PostulacionProfesionalUniG = new bool[] {false} ;
         BC001K40_A984PostulacionProfesionalA = new string[] {""} ;
         BC001K40_n984PostulacionProfesionalA = new bool[] {false} ;
         BC001K40_A167ProfesionalesApellidoPrimero = new string[] {""} ;
         BC001K40_A166ProfesionalesPrimerNombre = new string[] {""} ;
         BC001K40_A191ProfesionalesSegundoNombre = new string[] {""} ;
         BC001K40_A120ProfesionalesId = new string[] {""} ;
         BC001K4_A167ProfesionalesApellidoPrimero = new string[] {""} ;
         BC001K4_A166ProfesionalesPrimerNombre = new string[] {""} ;
         BC001K4_A191ProfesionalesSegundoNombre = new string[] {""} ;
         BC001K41_A422PostulacionesId = new long[1] ;
         BC001K41_n422PostulacionesId = new bool[] {false} ;
         BC001K41_A120ProfesionalesId = new string[] {""} ;
         BC001K3_A422PostulacionesId = new long[1] ;
         BC001K3_n422PostulacionesId = new bool[] {false} ;
         BC001K3_A956PostulacionProfesionalEstado = new string[] {""} ;
         BC001K3_A957PostulacionProfesionalFechaA = new DateTime[] {DateTime.MinValue} ;
         BC001K3_A958PostulacionProfesionalFechaT = new DateTime[] {DateTime.MinValue} ;
         BC001K3_A959PostulacionProfesionalTurnoT = new string[] {""} ;
         BC001K3_A982PostulacionProfesionalPrecio = new decimal[1] ;
         BC001K3_n982PostulacionProfesionalPrecio = new bool[] {false} ;
         BC001K3_A983PostulacionProfesionalPlazoE = new short[1] ;
         BC001K3_n983PostulacionProfesionalPlazoE = new bool[] {false} ;
         BC001K3_A986PostulacionProfesionalUniE = new string[] {""} ;
         BC001K3_n986PostulacionProfesionalUniE = new bool[] {false} ;
         BC001K3_A985PostulacionProfesionalGar = new short[1] ;
         BC001K3_n985PostulacionProfesionalGar = new bool[] {false} ;
         BC001K3_A987PostulacionProfesionalUniG = new string[] {""} ;
         BC001K3_n987PostulacionProfesionalUniG = new bool[] {false} ;
         BC001K3_A984PostulacionProfesionalA = new string[] {""} ;
         BC001K3_n984PostulacionProfesionalA = new bool[] {false} ;
         BC001K3_A120ProfesionalesId = new string[] {""} ;
         sMode137 = "";
         BC001K2_A422PostulacionesId = new long[1] ;
         BC001K2_n422PostulacionesId = new bool[] {false} ;
         BC001K2_A956PostulacionProfesionalEstado = new string[] {""} ;
         BC001K2_A957PostulacionProfesionalFechaA = new DateTime[] {DateTime.MinValue} ;
         BC001K2_A958PostulacionProfesionalFechaT = new DateTime[] {DateTime.MinValue} ;
         BC001K2_A959PostulacionProfesionalTurnoT = new string[] {""} ;
         BC001K2_A982PostulacionProfesionalPrecio = new decimal[1] ;
         BC001K2_n982PostulacionProfesionalPrecio = new bool[] {false} ;
         BC001K2_A983PostulacionProfesionalPlazoE = new short[1] ;
         BC001K2_n983PostulacionProfesionalPlazoE = new bool[] {false} ;
         BC001K2_A986PostulacionProfesionalUniE = new string[] {""} ;
         BC001K2_n986PostulacionProfesionalUniE = new bool[] {false} ;
         BC001K2_A985PostulacionProfesionalGar = new short[1] ;
         BC001K2_n985PostulacionProfesionalGar = new bool[] {false} ;
         BC001K2_A987PostulacionProfesionalUniG = new string[] {""} ;
         BC001K2_n987PostulacionProfesionalUniG = new bool[] {false} ;
         BC001K2_A984PostulacionProfesionalA = new string[] {""} ;
         BC001K2_n984PostulacionProfesionalA = new bool[] {false} ;
         BC001K2_A120ProfesionalesId = new string[] {""} ;
         BC001K45_A167ProfesionalesApellidoPrimero = new string[] {""} ;
         BC001K45_A166ProfesionalesPrimerNombre = new string[] {""} ;
         BC001K45_A191ProfesionalesSegundoNombre = new string[] {""} ;
         BC001K46_A422PostulacionesId = new long[1] ;
         BC001K46_n422PostulacionesId = new bool[] {false} ;
         BC001K46_A956PostulacionProfesionalEstado = new string[] {""} ;
         BC001K46_A957PostulacionProfesionalFechaA = new DateTime[] {DateTime.MinValue} ;
         BC001K46_A958PostulacionProfesionalFechaT = new DateTime[] {DateTime.MinValue} ;
         BC001K46_A959PostulacionProfesionalTurnoT = new string[] {""} ;
         BC001K46_A982PostulacionProfesionalPrecio = new decimal[1] ;
         BC001K46_n982PostulacionProfesionalPrecio = new bool[] {false} ;
         BC001K46_A983PostulacionProfesionalPlazoE = new short[1] ;
         BC001K46_n983PostulacionProfesionalPlazoE = new bool[] {false} ;
         BC001K46_A986PostulacionProfesionalUniE = new string[] {""} ;
         BC001K46_n986PostulacionProfesionalUniE = new bool[] {false} ;
         BC001K46_A985PostulacionProfesionalGar = new short[1] ;
         BC001K46_n985PostulacionProfesionalGar = new bool[] {false} ;
         BC001K46_A987PostulacionProfesionalUniG = new string[] {""} ;
         BC001K46_n987PostulacionProfesionalUniG = new bool[] {false} ;
         BC001K46_A984PostulacionProfesionalA = new string[] {""} ;
         BC001K46_n984PostulacionProfesionalA = new bool[] {false} ;
         BC001K46_A167ProfesionalesApellidoPrimero = new string[] {""} ;
         BC001K46_A166ProfesionalesPrimerNombre = new string[] {""} ;
         BC001K46_A191ProfesionalesSegundoNombre = new string[] {""} ;
         BC001K46_A120ProfesionalesId = new string[] {""} ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.postulaciones_bc__datastore1(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.postulaciones_bc__default(),
            new Object[][] {
                new Object[] {
               BC001K2_A422PostulacionesId, BC001K2_A956PostulacionProfesionalEstado, BC001K2_A957PostulacionProfesionalFechaA, BC001K2_A958PostulacionProfesionalFechaT, BC001K2_A959PostulacionProfesionalTurnoT, BC001K2_A982PostulacionProfesionalPrecio, BC001K2_n982PostulacionProfesionalPrecio, BC001K2_A983PostulacionProfesionalPlazoE, BC001K2_n983PostulacionProfesionalPlazoE, BC001K2_A986PostulacionProfesionalUniE,
               BC001K2_n986PostulacionProfesionalUniE, BC001K2_A985PostulacionProfesionalGar, BC001K2_n985PostulacionProfesionalGar, BC001K2_A987PostulacionProfesionalUniG, BC001K2_n987PostulacionProfesionalUniG, BC001K2_A984PostulacionProfesionalA, BC001K2_n984PostulacionProfesionalA, BC001K2_A120ProfesionalesId
               }
               , new Object[] {
               BC001K3_A422PostulacionesId, BC001K3_A956PostulacionProfesionalEstado, BC001K3_A957PostulacionProfesionalFechaA, BC001K3_A958PostulacionProfesionalFechaT, BC001K3_A959PostulacionProfesionalTurnoT, BC001K3_A982PostulacionProfesionalPrecio, BC001K3_n982PostulacionProfesionalPrecio, BC001K3_A983PostulacionProfesionalPlazoE, BC001K3_n983PostulacionProfesionalPlazoE, BC001K3_A986PostulacionProfesionalUniE,
               BC001K3_n986PostulacionProfesionalUniE, BC001K3_A985PostulacionProfesionalGar, BC001K3_n985PostulacionProfesionalGar, BC001K3_A987PostulacionProfesionalUniG, BC001K3_n987PostulacionProfesionalUniG, BC001K3_A984PostulacionProfesionalA, BC001K3_n984PostulacionProfesionalA, BC001K3_A120ProfesionalesId
               }
               , new Object[] {
               BC001K4_A167ProfesionalesApellidoPrimero, BC001K4_A166ProfesionalesPrimerNombre, BC001K4_A191ProfesionalesSegundoNombre
               }
               , new Object[] {
               BC001K5_A422PostulacionesId, BC001K5_A932MultimediaId, BC001K5_A933MultimediaDireccion, BC001K5_A960MultimediaDescripcion, BC001K5_A934MultimediaTipo
               }
               , new Object[] {
               BC001K6_A422PostulacionesId, BC001K6_A932MultimediaId, BC001K6_A933MultimediaDireccion, BC001K6_A960MultimediaDescripcion, BC001K6_A934MultimediaTipo
               }
               , new Object[] {
               BC001K7_A422PostulacionesId, BC001K7_A931CategoriasId
               }
               , new Object[] {
               BC001K8_A422PostulacionesId, BC001K8_A931CategoriasId
               }
               , new Object[] {
               BC001K9_A944CategoriasNombre
               }
               , new Object[] {
               BC001K10_A422PostulacionesId, BC001K10_A971PostulacionesProvNombreAux, BC001K10_A946PostulacionesPrecio, BC001K10_A961PostulacionesMultimediaSerial, BC001K10_A936PostulacionesDescripcion, BC001K10_A937PostulacionesReqSuministros, BC001K10_A938PostulacionesSuministrosDescri, BC001K10_A947PostulacionesFechaTrabajo, BC001K10_A939PostulacionesFechaCierre, BC001K10_A940PostulacionesHoraCierre,
               BC001K10_A941PostulacionesTipoFecha, BC001K10_A949PostulacionesRgoHoraservicio, BC001K10_A950PostulacionesApellidoNombre, BC001K10_A951PostulacionesMail, BC001K10_A952PostulacionesTelefono, BC001K10_A979PostulacionesDepartamentoId, BC001K10_A980PostulacionesDepartamentoMunic, BC001K10_A981PostulacionesZonasID, BC001K10_A998PostulacionesDireccion, BC001K10_A425PostulacionesFechaAlta,
               BC001K10_A424PostulacionesEstado, BC001K10_A948PostulacionesSecUserId, BC001K10_A942ServiciosId, BC001K10_n942ServiciosId, BC001K10_A945PostulacionesProveedorId
               }
               , new Object[] {
               BC001K11_A422PostulacionesId, BC001K11_A971PostulacionesProvNombreAux, BC001K11_A946PostulacionesPrecio, BC001K11_A961PostulacionesMultimediaSerial, BC001K11_A936PostulacionesDescripcion, BC001K11_A937PostulacionesReqSuministros, BC001K11_A938PostulacionesSuministrosDescri, BC001K11_A947PostulacionesFechaTrabajo, BC001K11_A939PostulacionesFechaCierre, BC001K11_A940PostulacionesHoraCierre,
               BC001K11_A941PostulacionesTipoFecha, BC001K11_A949PostulacionesRgoHoraservicio, BC001K11_A950PostulacionesApellidoNombre, BC001K11_A951PostulacionesMail, BC001K11_A952PostulacionesTelefono, BC001K11_A979PostulacionesDepartamentoId, BC001K11_A980PostulacionesDepartamentoMunic, BC001K11_A981PostulacionesZonasID, BC001K11_A998PostulacionesDireccion, BC001K11_A425PostulacionesFechaAlta,
               BC001K11_A424PostulacionesEstado, BC001K11_A948PostulacionesSecUserId, BC001K11_A942ServiciosId, BC001K11_n942ServiciosId, BC001K11_A945PostulacionesProveedorId
               }
               , new Object[] {
               BC001K13_A970PostulacionesSolicitudesId, BC001K13_n970PostulacionesSolicitudesId
               }
               , new Object[] {
               BC001K14_A943ServiciosNombre
               }
               , new Object[] {
               BC001K15_A969PostulacionesProveedorNombre
               }
               , new Object[] {
               BC001K17_A422PostulacionesId, BC001K17_A943ServiciosNombre, BC001K17_A971PostulacionesProvNombreAux, BC001K17_A969PostulacionesProveedorNombre, BC001K17_A946PostulacionesPrecio, BC001K17_A961PostulacionesMultimediaSerial, BC001K17_A936PostulacionesDescripcion, BC001K17_A937PostulacionesReqSuministros, BC001K17_A938PostulacionesSuministrosDescri, BC001K17_A947PostulacionesFechaTrabajo,
               BC001K17_A939PostulacionesFechaCierre, BC001K17_A940PostulacionesHoraCierre, BC001K17_A941PostulacionesTipoFecha, BC001K17_A949PostulacionesRgoHoraservicio, BC001K17_A950PostulacionesApellidoNombre, BC001K17_A951PostulacionesMail, BC001K17_A952PostulacionesTelefono, BC001K17_A979PostulacionesDepartamentoId, BC001K17_A980PostulacionesDepartamentoMunic, BC001K17_A981PostulacionesZonasID,
               BC001K17_A998PostulacionesDireccion, BC001K17_A425PostulacionesFechaAlta, BC001K17_A424PostulacionesEstado, BC001K17_A948PostulacionesSecUserId, BC001K17_A942ServiciosId, BC001K17_n942ServiciosId, BC001K17_A945PostulacionesProveedorId, BC001K17_A970PostulacionesSolicitudesId, BC001K17_n970PostulacionesSolicitudesId
               }
               , new Object[] {
               BC001K18_A422PostulacionesId
               }
               , new Object[] {
               BC001K19_A422PostulacionesId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC001K22_A943ServiciosNombre
               }
               , new Object[] {
               BC001K23_A969PostulacionesProveedorNombre
               }
               , new Object[] {
               BC001K24_A127SolicitudesID
               }
               , new Object[] {
               }
               , new Object[] {
               BC001K27_A422PostulacionesId, BC001K27_A943ServiciosNombre, BC001K27_A971PostulacionesProvNombreAux, BC001K27_A969PostulacionesProveedorNombre, BC001K27_A946PostulacionesPrecio, BC001K27_A961PostulacionesMultimediaSerial, BC001K27_A936PostulacionesDescripcion, BC001K27_A937PostulacionesReqSuministros, BC001K27_A938PostulacionesSuministrosDescri, BC001K27_A947PostulacionesFechaTrabajo,
               BC001K27_A939PostulacionesFechaCierre, BC001K27_A940PostulacionesHoraCierre, BC001K27_A941PostulacionesTipoFecha, BC001K27_A949PostulacionesRgoHoraservicio, BC001K27_A950PostulacionesApellidoNombre, BC001K27_A951PostulacionesMail, BC001K27_A952PostulacionesTelefono, BC001K27_A979PostulacionesDepartamentoId, BC001K27_A980PostulacionesDepartamentoMunic, BC001K27_A981PostulacionesZonasID,
               BC001K27_A998PostulacionesDireccion, BC001K27_A425PostulacionesFechaAlta, BC001K27_A424PostulacionesEstado, BC001K27_A948PostulacionesSecUserId, BC001K27_A942ServiciosId, BC001K27_n942ServiciosId, BC001K27_A945PostulacionesProveedorId, BC001K27_A970PostulacionesSolicitudesId, BC001K27_n970PostulacionesSolicitudesId
               }
               , new Object[] {
               BC001K28_A942ServiciosId, BC001K28_A422PostulacionesId, BC001K28_A944CategoriasNombre, BC001K28_A931CategoriasId
               }
               , new Object[] {
               BC001K29_A422PostulacionesId, BC001K29_A931CategoriasId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC001K32_A944CategoriasNombre
               }
               , new Object[] {
               BC001K33_A942ServiciosId, BC001K33_A422PostulacionesId, BC001K33_A944CategoriasNombre, BC001K33_A931CategoriasId
               }
               , new Object[] {
               BC001K34_A422PostulacionesId, BC001K34_A932MultimediaId, BC001K34_A933MultimediaDireccion, BC001K34_A960MultimediaDescripcion, BC001K34_A934MultimediaTipo
               }
               , new Object[] {
               BC001K35_A422PostulacionesId, BC001K35_A932MultimediaId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC001K39_A422PostulacionesId, BC001K39_A932MultimediaId, BC001K39_A933MultimediaDireccion, BC001K39_A960MultimediaDescripcion, BC001K39_A934MultimediaTipo
               }
               , new Object[] {
               BC001K40_A422PostulacionesId, BC001K40_A956PostulacionProfesionalEstado, BC001K40_A957PostulacionProfesionalFechaA, BC001K40_A958PostulacionProfesionalFechaT, BC001K40_A959PostulacionProfesionalTurnoT, BC001K40_A982PostulacionProfesionalPrecio, BC001K40_n982PostulacionProfesionalPrecio, BC001K40_A983PostulacionProfesionalPlazoE, BC001K40_n983PostulacionProfesionalPlazoE, BC001K40_A986PostulacionProfesionalUniE,
               BC001K40_n986PostulacionProfesionalUniE, BC001K40_A985PostulacionProfesionalGar, BC001K40_n985PostulacionProfesionalGar, BC001K40_A987PostulacionProfesionalUniG, BC001K40_n987PostulacionProfesionalUniG, BC001K40_A984PostulacionProfesionalA, BC001K40_n984PostulacionProfesionalA, BC001K40_A167ProfesionalesApellidoPrimero, BC001K40_A166ProfesionalesPrimerNombre, BC001K40_A191ProfesionalesSegundoNombre,
               BC001K40_A120ProfesionalesId
               }
               , new Object[] {
               BC001K41_A422PostulacionesId, BC001K41_A120ProfesionalesId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC001K45_A167ProfesionalesApellidoPrimero, BC001K45_A166ProfesionalesPrimerNombre, BC001K45_A191ProfesionalesSegundoNombre
               }
               , new Object[] {
               BC001K46_A422PostulacionesId, BC001K46_A956PostulacionProfesionalEstado, BC001K46_A957PostulacionProfesionalFechaA, BC001K46_A958PostulacionProfesionalFechaT, BC001K46_A959PostulacionProfesionalTurnoT, BC001K46_A982PostulacionProfesionalPrecio, BC001K46_n982PostulacionProfesionalPrecio, BC001K46_A983PostulacionProfesionalPlazoE, BC001K46_n983PostulacionProfesionalPlazoE, BC001K46_A986PostulacionProfesionalUniE,
               BC001K46_n986PostulacionProfesionalUniE, BC001K46_A985PostulacionProfesionalGar, BC001K46_n985PostulacionProfesionalGar, BC001K46_A987PostulacionProfesionalUniG, BC001K46_n987PostulacionProfesionalUniG, BC001K46_A984PostulacionProfesionalA, BC001K46_n984PostulacionProfesionalA, BC001K46_A167ProfesionalesApellidoPrimero, BC001K46_A166ProfesionalesPrimerNombre, BC001K46_A191ProfesionalesSegundoNombre,
               BC001K46_A120ProfesionalesId
               }
            }
         );
         AV25Pgmname = "Postulaciones_BC";
         INITTRN();
         /* Execute Start event if defined. */
         /* Execute user event: Start */
         E121K2 ();
         standaloneNotModal( ) ;
      }

      private short AnyError ;
      private short nIsMod_137 ;
      private short RcdFound137 ;
      private short s961PostulacionesMultimediaSerial ;
      private short O961PostulacionesMultimediaSerial ;
      private short A961PostulacionesMultimediaSerial ;
      private short nIsMod_139 ;
      private short RcdFound139 ;
      private short nIsMod_142 ;
      private short RcdFound142 ;
      private short Z961PostulacionesMultimediaSerial ;
      private short RcdFound126 ;
      private short nRcdExists_142 ;
      private short nRcdExists_139 ;
      private short nRcdExists_137 ;
      private short Gx_BScreen ;
      private short Gxremove142 ;
      private short Gxremove139 ;
      private short Z983PostulacionProfesionalPlazoE ;
      private short A983PostulacionProfesionalPlazoE ;
      private short Z985PostulacionProfesionalGar ;
      private short A985PostulacionProfesionalGar ;
      private short Gxremove137 ;
      private short i961PostulacionesMultimediaSerial ;
      private int trnEnded ;
      private int nGXsfl_137_idx=1 ;
      private int nGXsfl_139_idx=1 ;
      private int nGXsfl_142_idx=1 ;
      private int AV26GXV1 ;
      private long Z422PostulacionesId ;
      private long A422PostulacionesId ;
      private long AV14Insert_ServiciosId ;
      private long AV17Insert_PostulacionesProveedorId ;
      private long Z979PostulacionesDepartamentoId ;
      private long A979PostulacionesDepartamentoId ;
      private long Z980PostulacionesDepartamentoMunic ;
      private long A980PostulacionesDepartamentoMunic ;
      private long Z981PostulacionesZonasID ;
      private long A981PostulacionesZonasID ;
      private long Z948PostulacionesSecUserId ;
      private long A948PostulacionesSecUserId ;
      private long Z942ServiciosId ;
      private long A942ServiciosId ;
      private long Z945PostulacionesProveedorId ;
      private long A945PostulacionesProveedorId ;
      private long Z970PostulacionesSolicitudesId ;
      private long A970PostulacionesSolicitudesId ;
      private long Z931CategoriasId ;
      private long A931CategoriasId ;
      private long Z932MultimediaId ;
      private long A932MultimediaId ;
      private decimal Z946PostulacionesPrecio ;
      private decimal A946PostulacionesPrecio ;
      private decimal Z982PostulacionProfesionalPrecio ;
      private decimal A982PostulacionProfesionalPrecio ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string sMode126 ;
      private string AV25Pgmname ;
      private string GXKey ;
      private string GXEncryptionTmp ;
      private string imgVermas_gximage ;
      private string imgVermas_Tooltiptext ;
      private string Z971PostulacionesProvNombreAux ;
      private string A971PostulacionesProvNombreAux ;
      private string Z936PostulacionesDescripcion ;
      private string A936PostulacionesDescripcion ;
      private string Z938PostulacionesSuministrosDescri ;
      private string A938PostulacionesSuministrosDescri ;
      private string Z949PostulacionesRgoHoraservicio ;
      private string A949PostulacionesRgoHoraservicio ;
      private string Z950PostulacionesApellidoNombre ;
      private string A950PostulacionesApellidoNombre ;
      private string Z952PostulacionesTelefono ;
      private string A952PostulacionesTelefono ;
      private string Z998PostulacionesDireccion ;
      private string A998PostulacionesDireccion ;
      private string Z424PostulacionesEstado ;
      private string A424PostulacionesEstado ;
      private string Z943ServiciosNombre ;
      private string A943ServiciosNombre ;
      private string Z969PostulacionesProveedorNombre ;
      private string A969PostulacionesProveedorNombre ;
      private string Z944CategoriasNombre ;
      private string A944CategoriasNombre ;
      private string sMode142 ;
      private string Z933MultimediaDireccion ;
      private string A933MultimediaDireccion ;
      private string Z960MultimediaDescripcion ;
      private string A960MultimediaDescripcion ;
      private string sMode139 ;
      private string Z956PostulacionProfesionalEstado ;
      private string A956PostulacionProfesionalEstado ;
      private string Z959PostulacionProfesionalTurnoT ;
      private string A959PostulacionProfesionalTurnoT ;
      private string Z986PostulacionProfesionalUniE ;
      private string A986PostulacionProfesionalUniE ;
      private string Z987PostulacionProfesionalUniG ;
      private string A987PostulacionProfesionalUniG ;
      private string Z167ProfesionalesApellidoPrimero ;
      private string A167ProfesionalesApellidoPrimero ;
      private string Z166ProfesionalesPrimerNombre ;
      private string A166ProfesionalesPrimerNombre ;
      private string Z191ProfesionalesSegundoNombre ;
      private string A191ProfesionalesSegundoNombre ;
      private string Z120ProfesionalesId ;
      private string A120ProfesionalesId ;
      private string sMode137 ;
      private DateTime Z425PostulacionesFechaAlta ;
      private DateTime A425PostulacionesFechaAlta ;
      private DateTime Z957PostulacionProfesionalFechaA ;
      private DateTime A957PostulacionProfesionalFechaA ;
      private DateTime Z947PostulacionesFechaTrabajo ;
      private DateTime A947PostulacionesFechaTrabajo ;
      private DateTime Z939PostulacionesFechaCierre ;
      private DateTime A939PostulacionesFechaCierre ;
      private DateTime Z958PostulacionProfesionalFechaT ;
      private DateTime A958PostulacionProfesionalFechaT ;
      private bool returnInSub ;
      private bool AV10IsAuthorized ;
      private bool GXt_boolean1 ;
      private bool Z937PostulacionesReqSuministros ;
      private bool A937PostulacionesReqSuministros ;
      private bool n422PostulacionesId ;
      private bool n970PostulacionesSolicitudesId ;
      private bool n942ServiciosId ;
      private bool Gx_longc ;
      private bool n982PostulacionProfesionalPrecio ;
      private bool n983PostulacionProfesionalPlazoE ;
      private bool n986PostulacionProfesionalUniE ;
      private bool n985PostulacionProfesionalGar ;
      private bool n987PostulacionProfesionalUniG ;
      private bool n984PostulacionProfesionalA ;
      private string AV27Vermas_GXI ;
      private string Z940PostulacionesHoraCierre ;
      private string A940PostulacionesHoraCierre ;
      private string Z941PostulacionesTipoFecha ;
      private string A941PostulacionesTipoFecha ;
      private string Z951PostulacionesMail ;
      private string A951PostulacionesMail ;
      private string Z934MultimediaTipo ;
      private string A934MultimediaTipo ;
      private string Z984PostulacionProfesionalA ;
      private string A984PostulacionProfesionalA ;
      private string Z886ProfesionalesNombreCompleto ;
      private string A886ProfesionalesNombreCompleto ;
      private string AV24VerMas ;
      private IGxSession AV13WebSession ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private SdtPostulaciones bcPostulaciones ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV12TrnContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute AV15TrnContextAtt ;
      private IDataStoreProvider pr_default ;
      private long[] BC001K13_A970PostulacionesSolicitudesId ;
      private bool[] BC001K13_n970PostulacionesSolicitudesId ;
      private long[] BC001K17_A422PostulacionesId ;
      private bool[] BC001K17_n422PostulacionesId ;
      private string[] BC001K17_A943ServiciosNombre ;
      private string[] BC001K17_A971PostulacionesProvNombreAux ;
      private string[] BC001K17_A969PostulacionesProveedorNombre ;
      private decimal[] BC001K17_A946PostulacionesPrecio ;
      private short[] BC001K17_A961PostulacionesMultimediaSerial ;
      private string[] BC001K17_A936PostulacionesDescripcion ;
      private bool[] BC001K17_A937PostulacionesReqSuministros ;
      private string[] BC001K17_A938PostulacionesSuministrosDescri ;
      private DateTime[] BC001K17_A947PostulacionesFechaTrabajo ;
      private DateTime[] BC001K17_A939PostulacionesFechaCierre ;
      private string[] BC001K17_A940PostulacionesHoraCierre ;
      private string[] BC001K17_A941PostulacionesTipoFecha ;
      private string[] BC001K17_A949PostulacionesRgoHoraservicio ;
      private string[] BC001K17_A950PostulacionesApellidoNombre ;
      private string[] BC001K17_A951PostulacionesMail ;
      private string[] BC001K17_A952PostulacionesTelefono ;
      private long[] BC001K17_A979PostulacionesDepartamentoId ;
      private long[] BC001K17_A980PostulacionesDepartamentoMunic ;
      private long[] BC001K17_A981PostulacionesZonasID ;
      private string[] BC001K17_A998PostulacionesDireccion ;
      private DateTime[] BC001K17_A425PostulacionesFechaAlta ;
      private string[] BC001K17_A424PostulacionesEstado ;
      private long[] BC001K17_A948PostulacionesSecUserId ;
      private long[] BC001K17_A942ServiciosId ;
      private bool[] BC001K17_n942ServiciosId ;
      private long[] BC001K17_A945PostulacionesProveedorId ;
      private long[] BC001K17_A970PostulacionesSolicitudesId ;
      private bool[] BC001K17_n970PostulacionesSolicitudesId ;
      private string[] BC001K14_A943ServiciosNombre ;
      private string[] BC001K15_A969PostulacionesProveedorNombre ;
      private long[] BC001K18_A422PostulacionesId ;
      private bool[] BC001K18_n422PostulacionesId ;
      private long[] BC001K11_A422PostulacionesId ;
      private bool[] BC001K11_n422PostulacionesId ;
      private string[] BC001K11_A971PostulacionesProvNombreAux ;
      private decimal[] BC001K11_A946PostulacionesPrecio ;
      private short[] BC001K11_A961PostulacionesMultimediaSerial ;
      private string[] BC001K11_A936PostulacionesDescripcion ;
      private bool[] BC001K11_A937PostulacionesReqSuministros ;
      private string[] BC001K11_A938PostulacionesSuministrosDescri ;
      private DateTime[] BC001K11_A947PostulacionesFechaTrabajo ;
      private DateTime[] BC001K11_A939PostulacionesFechaCierre ;
      private string[] BC001K11_A940PostulacionesHoraCierre ;
      private string[] BC001K11_A941PostulacionesTipoFecha ;
      private string[] BC001K11_A949PostulacionesRgoHoraservicio ;
      private string[] BC001K11_A950PostulacionesApellidoNombre ;
      private string[] BC001K11_A951PostulacionesMail ;
      private string[] BC001K11_A952PostulacionesTelefono ;
      private long[] BC001K11_A979PostulacionesDepartamentoId ;
      private long[] BC001K11_A980PostulacionesDepartamentoMunic ;
      private long[] BC001K11_A981PostulacionesZonasID ;
      private string[] BC001K11_A998PostulacionesDireccion ;
      private DateTime[] BC001K11_A425PostulacionesFechaAlta ;
      private string[] BC001K11_A424PostulacionesEstado ;
      private long[] BC001K11_A948PostulacionesSecUserId ;
      private long[] BC001K11_A942ServiciosId ;
      private bool[] BC001K11_n942ServiciosId ;
      private long[] BC001K11_A945PostulacionesProveedorId ;
      private long[] BC001K10_A422PostulacionesId ;
      private bool[] BC001K10_n422PostulacionesId ;
      private string[] BC001K10_A971PostulacionesProvNombreAux ;
      private decimal[] BC001K10_A946PostulacionesPrecio ;
      private short[] BC001K10_A961PostulacionesMultimediaSerial ;
      private string[] BC001K10_A936PostulacionesDescripcion ;
      private bool[] BC001K10_A937PostulacionesReqSuministros ;
      private string[] BC001K10_A938PostulacionesSuministrosDescri ;
      private DateTime[] BC001K10_A947PostulacionesFechaTrabajo ;
      private DateTime[] BC001K10_A939PostulacionesFechaCierre ;
      private string[] BC001K10_A940PostulacionesHoraCierre ;
      private string[] BC001K10_A941PostulacionesTipoFecha ;
      private string[] BC001K10_A949PostulacionesRgoHoraservicio ;
      private string[] BC001K10_A950PostulacionesApellidoNombre ;
      private string[] BC001K10_A951PostulacionesMail ;
      private string[] BC001K10_A952PostulacionesTelefono ;
      private long[] BC001K10_A979PostulacionesDepartamentoId ;
      private long[] BC001K10_A980PostulacionesDepartamentoMunic ;
      private long[] BC001K10_A981PostulacionesZonasID ;
      private string[] BC001K10_A998PostulacionesDireccion ;
      private DateTime[] BC001K10_A425PostulacionesFechaAlta ;
      private string[] BC001K10_A424PostulacionesEstado ;
      private long[] BC001K10_A948PostulacionesSecUserId ;
      private long[] BC001K10_A942ServiciosId ;
      private bool[] BC001K10_n942ServiciosId ;
      private long[] BC001K10_A945PostulacionesProveedorId ;
      private long[] BC001K19_A422PostulacionesId ;
      private bool[] BC001K19_n422PostulacionesId ;
      private string[] BC001K22_A943ServiciosNombre ;
      private string[] BC001K23_A969PostulacionesProveedorNombre ;
      private long[] BC001K24_A127SolicitudesID ;
      private long[] BC001K27_A422PostulacionesId ;
      private bool[] BC001K27_n422PostulacionesId ;
      private string[] BC001K27_A943ServiciosNombre ;
      private string[] BC001K27_A971PostulacionesProvNombreAux ;
      private string[] BC001K27_A969PostulacionesProveedorNombre ;
      private decimal[] BC001K27_A946PostulacionesPrecio ;
      private short[] BC001K27_A961PostulacionesMultimediaSerial ;
      private string[] BC001K27_A936PostulacionesDescripcion ;
      private bool[] BC001K27_A937PostulacionesReqSuministros ;
      private string[] BC001K27_A938PostulacionesSuministrosDescri ;
      private DateTime[] BC001K27_A947PostulacionesFechaTrabajo ;
      private DateTime[] BC001K27_A939PostulacionesFechaCierre ;
      private string[] BC001K27_A940PostulacionesHoraCierre ;
      private string[] BC001K27_A941PostulacionesTipoFecha ;
      private string[] BC001K27_A949PostulacionesRgoHoraservicio ;
      private string[] BC001K27_A950PostulacionesApellidoNombre ;
      private string[] BC001K27_A951PostulacionesMail ;
      private string[] BC001K27_A952PostulacionesTelefono ;
      private long[] BC001K27_A979PostulacionesDepartamentoId ;
      private long[] BC001K27_A980PostulacionesDepartamentoMunic ;
      private long[] BC001K27_A981PostulacionesZonasID ;
      private string[] BC001K27_A998PostulacionesDireccion ;
      private DateTime[] BC001K27_A425PostulacionesFechaAlta ;
      private string[] BC001K27_A424PostulacionesEstado ;
      private long[] BC001K27_A948PostulacionesSecUserId ;
      private long[] BC001K27_A942ServiciosId ;
      private bool[] BC001K27_n942ServiciosId ;
      private long[] BC001K27_A945PostulacionesProveedorId ;
      private long[] BC001K27_A970PostulacionesSolicitudesId ;
      private bool[] BC001K27_n970PostulacionesSolicitudesId ;
      private long[] BC001K28_A942ServiciosId ;
      private bool[] BC001K28_n942ServiciosId ;
      private long[] BC001K28_A422PostulacionesId ;
      private bool[] BC001K28_n422PostulacionesId ;
      private string[] BC001K28_A944CategoriasNombre ;
      private long[] BC001K28_A931CategoriasId ;
      private string[] BC001K9_A944CategoriasNombre ;
      private long[] BC001K29_A422PostulacionesId ;
      private bool[] BC001K29_n422PostulacionesId ;
      private long[] BC001K29_A931CategoriasId ;
      private long[] BC001K8_A422PostulacionesId ;
      private bool[] BC001K8_n422PostulacionesId ;
      private long[] BC001K8_A931CategoriasId ;
      private long[] BC001K7_A422PostulacionesId ;
      private bool[] BC001K7_n422PostulacionesId ;
      private long[] BC001K7_A931CategoriasId ;
      private string[] BC001K32_A944CategoriasNombre ;
      private long[] BC001K33_A942ServiciosId ;
      private bool[] BC001K33_n942ServiciosId ;
      private long[] BC001K33_A422PostulacionesId ;
      private bool[] BC001K33_n422PostulacionesId ;
      private string[] BC001K33_A944CategoriasNombre ;
      private long[] BC001K33_A931CategoriasId ;
      private long[] BC001K34_A422PostulacionesId ;
      private bool[] BC001K34_n422PostulacionesId ;
      private long[] BC001K34_A932MultimediaId ;
      private string[] BC001K34_A933MultimediaDireccion ;
      private string[] BC001K34_A960MultimediaDescripcion ;
      private string[] BC001K34_A934MultimediaTipo ;
      private long[] BC001K35_A422PostulacionesId ;
      private bool[] BC001K35_n422PostulacionesId ;
      private long[] BC001K35_A932MultimediaId ;
      private long[] BC001K6_A422PostulacionesId ;
      private bool[] BC001K6_n422PostulacionesId ;
      private long[] BC001K6_A932MultimediaId ;
      private string[] BC001K6_A933MultimediaDireccion ;
      private string[] BC001K6_A960MultimediaDescripcion ;
      private string[] BC001K6_A934MultimediaTipo ;
      private long[] BC001K5_A422PostulacionesId ;
      private bool[] BC001K5_n422PostulacionesId ;
      private long[] BC001K5_A932MultimediaId ;
      private string[] BC001K5_A933MultimediaDireccion ;
      private string[] BC001K5_A960MultimediaDescripcion ;
      private string[] BC001K5_A934MultimediaTipo ;
      private long[] BC001K39_A422PostulacionesId ;
      private bool[] BC001K39_n422PostulacionesId ;
      private long[] BC001K39_A932MultimediaId ;
      private string[] BC001K39_A933MultimediaDireccion ;
      private string[] BC001K39_A960MultimediaDescripcion ;
      private string[] BC001K39_A934MultimediaTipo ;
      private long[] BC001K40_A422PostulacionesId ;
      private bool[] BC001K40_n422PostulacionesId ;
      private string[] BC001K40_A956PostulacionProfesionalEstado ;
      private DateTime[] BC001K40_A957PostulacionProfesionalFechaA ;
      private DateTime[] BC001K40_A958PostulacionProfesionalFechaT ;
      private string[] BC001K40_A959PostulacionProfesionalTurnoT ;
      private decimal[] BC001K40_A982PostulacionProfesionalPrecio ;
      private bool[] BC001K40_n982PostulacionProfesionalPrecio ;
      private short[] BC001K40_A983PostulacionProfesionalPlazoE ;
      private bool[] BC001K40_n983PostulacionProfesionalPlazoE ;
      private string[] BC001K40_A986PostulacionProfesionalUniE ;
      private bool[] BC001K40_n986PostulacionProfesionalUniE ;
      private short[] BC001K40_A985PostulacionProfesionalGar ;
      private bool[] BC001K40_n985PostulacionProfesionalGar ;
      private string[] BC001K40_A987PostulacionProfesionalUniG ;
      private bool[] BC001K40_n987PostulacionProfesionalUniG ;
      private string[] BC001K40_A984PostulacionProfesionalA ;
      private bool[] BC001K40_n984PostulacionProfesionalA ;
      private string[] BC001K40_A167ProfesionalesApellidoPrimero ;
      private string[] BC001K40_A166ProfesionalesPrimerNombre ;
      private string[] BC001K40_A191ProfesionalesSegundoNombre ;
      private string[] BC001K40_A120ProfesionalesId ;
      private string[] BC001K4_A167ProfesionalesApellidoPrimero ;
      private string[] BC001K4_A166ProfesionalesPrimerNombre ;
      private string[] BC001K4_A191ProfesionalesSegundoNombre ;
      private long[] BC001K41_A422PostulacionesId ;
      private bool[] BC001K41_n422PostulacionesId ;
      private string[] BC001K41_A120ProfesionalesId ;
      private long[] BC001K3_A422PostulacionesId ;
      private bool[] BC001K3_n422PostulacionesId ;
      private string[] BC001K3_A956PostulacionProfesionalEstado ;
      private DateTime[] BC001K3_A957PostulacionProfesionalFechaA ;
      private DateTime[] BC001K3_A958PostulacionProfesionalFechaT ;
      private string[] BC001K3_A959PostulacionProfesionalTurnoT ;
      private decimal[] BC001K3_A982PostulacionProfesionalPrecio ;
      private bool[] BC001K3_n982PostulacionProfesionalPrecio ;
      private short[] BC001K3_A983PostulacionProfesionalPlazoE ;
      private bool[] BC001K3_n983PostulacionProfesionalPlazoE ;
      private string[] BC001K3_A986PostulacionProfesionalUniE ;
      private bool[] BC001K3_n986PostulacionProfesionalUniE ;
      private short[] BC001K3_A985PostulacionProfesionalGar ;
      private bool[] BC001K3_n985PostulacionProfesionalGar ;
      private string[] BC001K3_A987PostulacionProfesionalUniG ;
      private bool[] BC001K3_n987PostulacionProfesionalUniG ;
      private string[] BC001K3_A984PostulacionProfesionalA ;
      private bool[] BC001K3_n984PostulacionProfesionalA ;
      private string[] BC001K3_A120ProfesionalesId ;
      private long[] BC001K2_A422PostulacionesId ;
      private bool[] BC001K2_n422PostulacionesId ;
      private string[] BC001K2_A956PostulacionProfesionalEstado ;
      private DateTime[] BC001K2_A957PostulacionProfesionalFechaA ;
      private DateTime[] BC001K2_A958PostulacionProfesionalFechaT ;
      private string[] BC001K2_A959PostulacionProfesionalTurnoT ;
      private decimal[] BC001K2_A982PostulacionProfesionalPrecio ;
      private bool[] BC001K2_n982PostulacionProfesionalPrecio ;
      private short[] BC001K2_A983PostulacionProfesionalPlazoE ;
      private bool[] BC001K2_n983PostulacionProfesionalPlazoE ;
      private string[] BC001K2_A986PostulacionProfesionalUniE ;
      private bool[] BC001K2_n986PostulacionProfesionalUniE ;
      private short[] BC001K2_A985PostulacionProfesionalGar ;
      private bool[] BC001K2_n985PostulacionProfesionalGar ;
      private string[] BC001K2_A987PostulacionProfesionalUniG ;
      private bool[] BC001K2_n987PostulacionProfesionalUniG ;
      private string[] BC001K2_A984PostulacionProfesionalA ;
      private bool[] BC001K2_n984PostulacionProfesionalA ;
      private string[] BC001K2_A120ProfesionalesId ;
      private string[] BC001K45_A167ProfesionalesApellidoPrimero ;
      private string[] BC001K45_A166ProfesionalesPrimerNombre ;
      private string[] BC001K45_A191ProfesionalesSegundoNombre ;
      private long[] BC001K46_A422PostulacionesId ;
      private bool[] BC001K46_n422PostulacionesId ;
      private string[] BC001K46_A956PostulacionProfesionalEstado ;
      private DateTime[] BC001K46_A957PostulacionProfesionalFechaA ;
      private DateTime[] BC001K46_A958PostulacionProfesionalFechaT ;
      private string[] BC001K46_A959PostulacionProfesionalTurnoT ;
      private decimal[] BC001K46_A982PostulacionProfesionalPrecio ;
      private bool[] BC001K46_n982PostulacionProfesionalPrecio ;
      private short[] BC001K46_A983PostulacionProfesionalPlazoE ;
      private bool[] BC001K46_n983PostulacionProfesionalPlazoE ;
      private string[] BC001K46_A986PostulacionProfesionalUniE ;
      private bool[] BC001K46_n986PostulacionProfesionalUniE ;
      private short[] BC001K46_A985PostulacionProfesionalGar ;
      private bool[] BC001K46_n985PostulacionProfesionalGar ;
      private string[] BC001K46_A987PostulacionProfesionalUniG ;
      private bool[] BC001K46_n987PostulacionProfesionalUniG ;
      private string[] BC001K46_A984PostulacionProfesionalA ;
      private bool[] BC001K46_n984PostulacionProfesionalA ;
      private string[] BC001K46_A167ProfesionalesApellidoPrimero ;
      private string[] BC001K46_A166ProfesionalesPrimerNombre ;
      private string[] BC001K46_A191ProfesionalesSegundoNombre ;
      private string[] BC001K46_A120ProfesionalesId ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_datastore1 ;
   }

   public class postulaciones_bc__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class postulaciones_bc__default : DataStoreHelperBase, IDataStoreHelper
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
       ,new ForEachCursor(def[9])
       ,new ForEachCursor(def[10])
       ,new ForEachCursor(def[11])
       ,new ForEachCursor(def[12])
       ,new ForEachCursor(def[13])
       ,new ForEachCursor(def[14])
       ,new ForEachCursor(def[15])
       ,new UpdateCursor(def[16])
       ,new UpdateCursor(def[17])
       ,new ForEachCursor(def[18])
       ,new ForEachCursor(def[19])
       ,new ForEachCursor(def[20])
       ,new UpdateCursor(def[21])
       ,new ForEachCursor(def[22])
       ,new ForEachCursor(def[23])
       ,new ForEachCursor(def[24])
       ,new UpdateCursor(def[25])
       ,new UpdateCursor(def[26])
       ,new ForEachCursor(def[27])
       ,new ForEachCursor(def[28])
       ,new ForEachCursor(def[29])
       ,new ForEachCursor(def[30])
       ,new UpdateCursor(def[31])
       ,new UpdateCursor(def[32])
       ,new UpdateCursor(def[33])
       ,new ForEachCursor(def[34])
       ,new ForEachCursor(def[35])
       ,new ForEachCursor(def[36])
       ,new UpdateCursor(def[37])
       ,new UpdateCursor(def[38])
       ,new UpdateCursor(def[39])
       ,new ForEachCursor(def[40])
       ,new ForEachCursor(def[41])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmBC001K2;
        prmBC001K2 = new Object[] {
        new ParDef("@PostulacionesId",GXType.Decimal,18,0){Nullable=true} ,
        new ParDef("@ProfesionalesId",GXType.Char,20,0)
        };
        Object[] prmBC001K3;
        prmBC001K3 = new Object[] {
        new ParDef("@PostulacionesId",GXType.Decimal,18,0){Nullable=true} ,
        new ParDef("@ProfesionalesId",GXType.Char,20,0)
        };
        Object[] prmBC001K4;
        prmBC001K4 = new Object[] {
        new ParDef("@ProfesionalesId",GXType.Char,20,0)
        };
        Object[] prmBC001K5;
        prmBC001K5 = new Object[] {
        new ParDef("@PostulacionesId",GXType.Decimal,18,0){Nullable=true} ,
        new ParDef("@MultimediaId",GXType.Decimal,18,0)
        };
        Object[] prmBC001K6;
        prmBC001K6 = new Object[] {
        new ParDef("@PostulacionesId",GXType.Decimal,18,0){Nullable=true} ,
        new ParDef("@MultimediaId",GXType.Decimal,18,0)
        };
        Object[] prmBC001K7;
        prmBC001K7 = new Object[] {
        new ParDef("@PostulacionesId",GXType.Decimal,18,0){Nullable=true} ,
        new ParDef("@CategoriasId",GXType.Decimal,18,0)
        };
        Object[] prmBC001K8;
        prmBC001K8 = new Object[] {
        new ParDef("@PostulacionesId",GXType.Decimal,18,0){Nullable=true} ,
        new ParDef("@CategoriasId",GXType.Decimal,18,0)
        };
        Object[] prmBC001K9;
        prmBC001K9 = new Object[] {
        new ParDef("@ServiciosId",GXType.Decimal,18,0){Nullable=true} ,
        new ParDef("@CategoriasId",GXType.Decimal,18,0)
        };
        Object[] prmBC001K10;
        prmBC001K10 = new Object[] {
        new ParDef("@PostulacionesId",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmBC001K11;
        prmBC001K11 = new Object[] {
        new ParDef("@PostulacionesId",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmBC001K14;
        prmBC001K14 = new Object[] {
        new ParDef("@ServiciosId",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmBC001K15;
        prmBC001K15 = new Object[] {
        new ParDef("@PostulacionesProveedorId",GXType.Decimal,18,0)
        };
        Object[] prmBC001K13;
        prmBC001K13 = new Object[] {
        new ParDef("@PostulacionesId",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmBC001K17;
        prmBC001K17 = new Object[] {
        new ParDef("@PostulacionesId",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmBC001K18;
        prmBC001K18 = new Object[] {
        new ParDef("@PostulacionesId",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmBC001K19;
        prmBC001K19 = new Object[] {
        new ParDef("@PostulacionesProvNombreAux",GXType.NChar,80,0) ,
        new ParDef("@PostulacionesPrecio",GXType.Decimal,18,2) ,
        new ParDef("@PostulacionesMultimediaSerial",GXType.Int16,4,0) ,
        new ParDef("@PostulacionesDescripcion",GXType.NChar,2000,0) ,
        new ParDef("@PostulacionesReqSuministros",GXType.Boolean,4,0) ,
        new ParDef("@PostulacionesSuministrosDescri",GXType.NChar,250,0) ,
        new ParDef("@PostulacionesFechaTrabajo",GXType.Date,8,0) ,
        new ParDef("@PostulacionesFechaCierre",GXType.Date,8,0) ,
        new ParDef("@PostulacionesHoraCierre",GXType.NVarChar,8,5) ,
        new ParDef("@PostulacionesTipoFecha",GXType.NVarChar,10,0) ,
        new ParDef("@PostulacionesRgoHoraservicio",GXType.NChar,5,0) ,
        new ParDef("@PostulacionesApellidoNombre",GXType.NChar,80,0) ,
        new ParDef("@PostulacionesMail",GXType.NVarChar,100,0) ,
        new ParDef("@PostulacionesTelefono",GXType.NChar,20,0) ,
        new ParDef("@PostulacionesDepartamentoId",GXType.Decimal,18,0) ,
        new ParDef("@PostulacionesDepartamentoMunic",GXType.Decimal,18,0) ,
        new ParDef("@PostulacionesZonasID",GXType.Decimal,18,0) ,
        new ParDef("@PostulacionesDireccion",GXType.NChar,100,0) ,
        new ParDef("@PostulacionesFechaAlta",GXType.DateTime,8,5) ,
        new ParDef("@PostulacionesEstado",GXType.NChar,3,0) ,
        new ParDef("@PostulacionesSecUserId",GXType.Decimal,18,0) ,
        new ParDef("@ServiciosId",GXType.Decimal,18,0){Nullable=true} ,
        new ParDef("@PostulacionesProveedorId",GXType.Decimal,18,0)
        };
        Object[] prmBC001K20;
        prmBC001K20 = new Object[] {
        new ParDef("@PostulacionesProvNombreAux",GXType.NChar,80,0) ,
        new ParDef("@PostulacionesPrecio",GXType.Decimal,18,2) ,
        new ParDef("@PostulacionesMultimediaSerial",GXType.Int16,4,0) ,
        new ParDef("@PostulacionesDescripcion",GXType.NChar,2000,0) ,
        new ParDef("@PostulacionesReqSuministros",GXType.Boolean,4,0) ,
        new ParDef("@PostulacionesSuministrosDescri",GXType.NChar,250,0) ,
        new ParDef("@PostulacionesFechaTrabajo",GXType.Date,8,0) ,
        new ParDef("@PostulacionesFechaCierre",GXType.Date,8,0) ,
        new ParDef("@PostulacionesHoraCierre",GXType.NVarChar,8,5) ,
        new ParDef("@PostulacionesTipoFecha",GXType.NVarChar,10,0) ,
        new ParDef("@PostulacionesRgoHoraservicio",GXType.NChar,5,0) ,
        new ParDef("@PostulacionesApellidoNombre",GXType.NChar,80,0) ,
        new ParDef("@PostulacionesMail",GXType.NVarChar,100,0) ,
        new ParDef("@PostulacionesTelefono",GXType.NChar,20,0) ,
        new ParDef("@PostulacionesDepartamentoId",GXType.Decimal,18,0) ,
        new ParDef("@PostulacionesDepartamentoMunic",GXType.Decimal,18,0) ,
        new ParDef("@PostulacionesZonasID",GXType.Decimal,18,0) ,
        new ParDef("@PostulacionesDireccion",GXType.NChar,100,0) ,
        new ParDef("@PostulacionesFechaAlta",GXType.DateTime,8,5) ,
        new ParDef("@PostulacionesEstado",GXType.NChar,3,0) ,
        new ParDef("@PostulacionesSecUserId",GXType.Decimal,18,0) ,
        new ParDef("@ServiciosId",GXType.Decimal,18,0){Nullable=true} ,
        new ParDef("@PostulacionesProveedorId",GXType.Decimal,18,0) ,
        new ParDef("@PostulacionesId",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmBC001K21;
        prmBC001K21 = new Object[] {
        new ParDef("@PostulacionesId",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmBC001K22;
        prmBC001K22 = new Object[] {
        new ParDef("@ServiciosId",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmBC001K23;
        prmBC001K23 = new Object[] {
        new ParDef("@PostulacionesProveedorId",GXType.Decimal,18,0)
        };
        Object[] prmBC001K24;
        prmBC001K24 = new Object[] {
        new ParDef("@PostulacionesId",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmBC001K25;
        prmBC001K25 = new Object[] {
        new ParDef("@PostulacionesMultimediaSerial",GXType.Int16,4,0) ,
        new ParDef("@PostulacionesId",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmBC001K27;
        prmBC001K27 = new Object[] {
        new ParDef("@PostulacionesId",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmBC001K28;
        prmBC001K28 = new Object[] {
        new ParDef("@ServiciosId",GXType.Decimal,18,0){Nullable=true} ,
        new ParDef("@PostulacionesId",GXType.Decimal,18,0){Nullable=true} ,
        new ParDef("@CategoriasId",GXType.Decimal,18,0)
        };
        Object[] prmBC001K29;
        prmBC001K29 = new Object[] {
        new ParDef("@PostulacionesId",GXType.Decimal,18,0){Nullable=true} ,
        new ParDef("@CategoriasId",GXType.Decimal,18,0)
        };
        Object[] prmBC001K30;
        prmBC001K30 = new Object[] {
        new ParDef("@PostulacionesId",GXType.Decimal,18,0){Nullable=true} ,
        new ParDef("@CategoriasId",GXType.Decimal,18,0)
        };
        Object[] prmBC001K31;
        prmBC001K31 = new Object[] {
        new ParDef("@PostulacionesId",GXType.Decimal,18,0){Nullable=true} ,
        new ParDef("@CategoriasId",GXType.Decimal,18,0)
        };
        Object[] prmBC001K32;
        prmBC001K32 = new Object[] {
        new ParDef("@ServiciosId",GXType.Decimal,18,0){Nullable=true} ,
        new ParDef("@CategoriasId",GXType.Decimal,18,0)
        };
        Object[] prmBC001K33;
        prmBC001K33 = new Object[] {
        new ParDef("@ServiciosId",GXType.Decimal,18,0){Nullable=true} ,
        new ParDef("@PostulacionesId",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmBC001K34;
        prmBC001K34 = new Object[] {
        new ParDef("@PostulacionesId",GXType.Decimal,18,0){Nullable=true} ,
        new ParDef("@MultimediaId",GXType.Decimal,18,0)
        };
        Object[] prmBC001K35;
        prmBC001K35 = new Object[] {
        new ParDef("@PostulacionesId",GXType.Decimal,18,0){Nullable=true} ,
        new ParDef("@MultimediaId",GXType.Decimal,18,0)
        };
        Object[] prmBC001K36;
        prmBC001K36 = new Object[] {
        new ParDef("@PostulacionesId",GXType.Decimal,18,0){Nullable=true} ,
        new ParDef("@MultimediaId",GXType.Decimal,18,0) ,
        new ParDef("@MultimediaDireccion",GXType.NChar,100,0) ,
        new ParDef("@MultimediaDescripcion",GXType.NChar,250,0) ,
        new ParDef("@MultimediaTipo",GXType.NVarChar,40,0)
        };
        Object[] prmBC001K37;
        prmBC001K37 = new Object[] {
        new ParDef("@MultimediaDireccion",GXType.NChar,100,0) ,
        new ParDef("@MultimediaDescripcion",GXType.NChar,250,0) ,
        new ParDef("@MultimediaTipo",GXType.NVarChar,40,0) ,
        new ParDef("@PostulacionesId",GXType.Decimal,18,0){Nullable=true} ,
        new ParDef("@MultimediaId",GXType.Decimal,18,0)
        };
        Object[] prmBC001K38;
        prmBC001K38 = new Object[] {
        new ParDef("@PostulacionesId",GXType.Decimal,18,0){Nullable=true} ,
        new ParDef("@MultimediaId",GXType.Decimal,18,0)
        };
        Object[] prmBC001K39;
        prmBC001K39 = new Object[] {
        new ParDef("@PostulacionesId",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmBC001K40;
        prmBC001K40 = new Object[] {
        new ParDef("@PostulacionesId",GXType.Decimal,18,0){Nullable=true} ,
        new ParDef("@ProfesionalesId",GXType.Char,20,0)
        };
        Object[] prmBC001K41;
        prmBC001K41 = new Object[] {
        new ParDef("@PostulacionesId",GXType.Decimal,18,0){Nullable=true} ,
        new ParDef("@ProfesionalesId",GXType.Char,20,0)
        };
        Object[] prmBC001K42;
        prmBC001K42 = new Object[] {
        new ParDef("@PostulacionesId",GXType.Decimal,18,0){Nullable=true} ,
        new ParDef("@PostulacionProfesionalEstado",GXType.NChar,3,0) ,
        new ParDef("@PostulacionProfesionalFechaA",GXType.DateTime,8,5) ,
        new ParDef("@PostulacionProfesionalFechaT",GXType.Date,8,0) ,
        new ParDef("@PostulacionProfesionalTurnoT",GXType.NChar,1,0) ,
        new ParDef("@PostulacionProfesionalPrecio",GXType.Decimal,18,2){Nullable=true} ,
        new ParDef("@PostulacionProfesionalPlazoE",GXType.Int16,4,0){Nullable=true} ,
        new ParDef("@PostulacionProfesionalUniE",GXType.NChar,1,0){Nullable=true} ,
        new ParDef("@PostulacionProfesionalGar",GXType.Int16,4,0){Nullable=true} ,
        new ParDef("@PostulacionProfesionalUniG",GXType.NChar,1,0){Nullable=true} ,
        new ParDef("@PostulacionProfesionalA",GXType.NVarChar,500,0){Nullable=true} ,
        new ParDef("@ProfesionalesId",GXType.Char,20,0)
        };
        Object[] prmBC001K43;
        prmBC001K43 = new Object[] {
        new ParDef("@PostulacionProfesionalEstado",GXType.NChar,3,0) ,
        new ParDef("@PostulacionProfesionalFechaA",GXType.DateTime,8,5) ,
        new ParDef("@PostulacionProfesionalFechaT",GXType.Date,8,0) ,
        new ParDef("@PostulacionProfesionalTurnoT",GXType.NChar,1,0) ,
        new ParDef("@PostulacionProfesionalPrecio",GXType.Decimal,18,2){Nullable=true} ,
        new ParDef("@PostulacionProfesionalPlazoE",GXType.Int16,4,0){Nullable=true} ,
        new ParDef("@PostulacionProfesionalUniE",GXType.NChar,1,0){Nullable=true} ,
        new ParDef("@PostulacionProfesionalGar",GXType.Int16,4,0){Nullable=true} ,
        new ParDef("@PostulacionProfesionalUniG",GXType.NChar,1,0){Nullable=true} ,
        new ParDef("@PostulacionProfesionalA",GXType.NVarChar,500,0){Nullable=true} ,
        new ParDef("@PostulacionesId",GXType.Decimal,18,0){Nullable=true} ,
        new ParDef("@ProfesionalesId",GXType.Char,20,0)
        };
        Object[] prmBC001K44;
        prmBC001K44 = new Object[] {
        new ParDef("@PostulacionesId",GXType.Decimal,18,0){Nullable=true} ,
        new ParDef("@ProfesionalesId",GXType.Char,20,0)
        };
        Object[] prmBC001K45;
        prmBC001K45 = new Object[] {
        new ParDef("@ProfesionalesId",GXType.Char,20,0)
        };
        Object[] prmBC001K46;
        prmBC001K46 = new Object[] {
        new ParDef("@PostulacionesId",GXType.Decimal,18,0){Nullable=true}
        };
        def= new CursorDef[] {
            new CursorDef("BC001K2", "SELECT [PostulacionesId], [PostulacionProfesionalEstado], [PostulacionProfesionalFechaA], [PostulacionProfesionalFechaT], [PostulacionProfesionalTurnoT], [PostulacionProfesionalPrecio], [PostulacionProfesionalPlazoE], [PostulacionProfesionalUniE], [PostulacionProfesionalGar], [PostulacionProfesionalUniG], [PostulacionProfesionalA], [ProfesionalesId] FROM [PostulacionesProfesionales] WITH (UPDLOCK) WHERE [PostulacionesId] = @PostulacionesId AND [ProfesionalesId] = @ProfesionalesId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001K2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC001K3", "SELECT [PostulacionesId], [PostulacionProfesionalEstado], [PostulacionProfesionalFechaA], [PostulacionProfesionalFechaT], [PostulacionProfesionalTurnoT], [PostulacionProfesionalPrecio], [PostulacionProfesionalPlazoE], [PostulacionProfesionalUniE], [PostulacionProfesionalGar], [PostulacionProfesionalUniG], [PostulacionProfesionalA], [ProfesionalesId] FROM [PostulacionesProfesionales] WHERE [PostulacionesId] = @PostulacionesId AND [ProfesionalesId] = @ProfesionalesId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001K3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC001K4", "SELECT [ProfesionalesApellidoPrimero], [ProfesionalesPrimerNombre], [ProfesionalesSegundoNombre] FROM [Profesionales] WHERE [ProfesionalesId] = @ProfesionalesId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001K4,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC001K5", "SELECT [PostulacionesId], [MultimediaId], [MultimediaDireccion], [MultimediaDescripcion], [MultimediaTipo] FROM [PostulacionesMultimedia] WITH (UPDLOCK) WHERE [PostulacionesId] = @PostulacionesId AND [MultimediaId] = @MultimediaId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001K5,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC001K6", "SELECT [PostulacionesId], [MultimediaId], [MultimediaDireccion], [MultimediaDescripcion], [MultimediaTipo] FROM [PostulacionesMultimedia] WHERE [PostulacionesId] = @PostulacionesId AND [MultimediaId] = @MultimediaId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001K6,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC001K7", "SELECT [PostulacionesId], [CategoriasId] FROM [PostulacionesCategorias] WITH (UPDLOCK) WHERE [PostulacionesId] = @PostulacionesId AND [CategoriasId] = @CategoriasId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001K7,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC001K8", "SELECT [PostulacionesId], [CategoriasId] FROM [PostulacionesCategorias] WHERE [PostulacionesId] = @PostulacionesId AND [CategoriasId] = @CategoriasId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001K8,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC001K9", "SELECT [CategoriasNombre] FROM [ServiciosCategorias] WHERE [ServiciosId] = @ServiciosId AND [CategoriasId] = @CategoriasId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001K9,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC001K10", "SELECT [PostulacionesId], [PostulacionesProvNombreAux], [PostulacionesPrecio], [PostulacionesMultimediaSerial], [PostulacionesDescripcion], [PostulacionesReqSuministros], [PostulacionesSuministrosDescri], [PostulacionesFechaTrabajo], [PostulacionesFechaCierre], [PostulacionesHoraCierre], [PostulacionesTipoFecha], [PostulacionesRgoHoraservicio], [PostulacionesApellidoNombre], [PostulacionesMail], [PostulacionesTelefono], [PostulacionesDepartamentoId], [PostulacionesDepartamentoMunic], [PostulacionesZonasID], [PostulacionesDireccion], [PostulacionesFechaAlta], [PostulacionesEstado], [PostulacionesSecUserId], [ServiciosId], [PostulacionesProveedorId] AS PostulacionesProveedorId FROM [Postulaciones] WITH (UPDLOCK) WHERE [PostulacionesId] = @PostulacionesId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001K10,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC001K11", "SELECT [PostulacionesId], [PostulacionesProvNombreAux], [PostulacionesPrecio], [PostulacionesMultimediaSerial], [PostulacionesDescripcion], [PostulacionesReqSuministros], [PostulacionesSuministrosDescri], [PostulacionesFechaTrabajo], [PostulacionesFechaCierre], [PostulacionesHoraCierre], [PostulacionesTipoFecha], [PostulacionesRgoHoraservicio], [PostulacionesApellidoNombre], [PostulacionesMail], [PostulacionesTelefono], [PostulacionesDepartamentoId], [PostulacionesDepartamentoMunic], [PostulacionesZonasID], [PostulacionesDireccion], [PostulacionesFechaAlta], [PostulacionesEstado], [PostulacionesSecUserId], [ServiciosId], [PostulacionesProveedorId] AS PostulacionesProveedorId FROM [Postulaciones] WHERE [PostulacionesId] = @PostulacionesId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001K11,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC001K13", "SELECT COALESCE( T1.[PostulacionesSolicitudesId], 0) AS PostulacionesSolicitudesId FROM (SELECT MIN([SolicitudesID]) AS PostulacionesSolicitudesId FROM [Solicitudes] WHERE [PostulacionesId] = @PostulacionesId ) T1 ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001K13,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC001K14", "SELECT [ServiciosNombre] FROM [Servicios] WHERE [ServiciosId] = @ServiciosId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001K14,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC001K15", "SELECT [ProveedorNombre] AS PostulacionesProveedorNombre FROM [Proveedor] WHERE [ProveedorID] = @PostulacionesProveedorId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001K15,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC001K17", "SELECT TM1.[PostulacionesId], T3.[ServiciosNombre], TM1.[PostulacionesProvNombreAux], T4.[ProveedorNombre] AS PostulacionesProveedorNombre, TM1.[PostulacionesPrecio], TM1.[PostulacionesMultimediaSerial], TM1.[PostulacionesDescripcion], TM1.[PostulacionesReqSuministros], TM1.[PostulacionesSuministrosDescri], TM1.[PostulacionesFechaTrabajo], TM1.[PostulacionesFechaCierre], TM1.[PostulacionesHoraCierre], TM1.[PostulacionesTipoFecha], TM1.[PostulacionesRgoHoraservicio], TM1.[PostulacionesApellidoNombre], TM1.[PostulacionesMail], TM1.[PostulacionesTelefono], TM1.[PostulacionesDepartamentoId], TM1.[PostulacionesDepartamentoMunic], TM1.[PostulacionesZonasID], TM1.[PostulacionesDireccion], TM1.[PostulacionesFechaAlta], TM1.[PostulacionesEstado], TM1.[PostulacionesSecUserId], TM1.[ServiciosId], TM1.[PostulacionesProveedorId] AS PostulacionesProveedorId, COALESCE( T2.[PostulacionesSolicitudesId], 0) AS PostulacionesSolicitudesId FROM (([Postulaciones] TM1 LEFT JOIN [Servicios] T3 ON T3.[ServiciosId] = TM1.[ServiciosId]) INNER JOIN [Proveedor] T4 ON T4.[ProveedorID] = TM1.[PostulacionesProveedorId]),  (SELECT MIN([SolicitudesID]) AS PostulacionesSolicitudesId FROM [Solicitudes] WHERE [PostulacionesId] = @PostulacionesId ) T2 WHERE TM1.[PostulacionesId] = @PostulacionesId ORDER BY TM1.[PostulacionesId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmBC001K17,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC001K18", "SELECT [PostulacionesId] FROM [Postulaciones] WHERE [PostulacionesId] = @PostulacionesId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmBC001K18,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC001K19", "INSERT INTO [Postulaciones]([PostulacionesProvNombreAux], [PostulacionesPrecio], [PostulacionesMultimediaSerial], [PostulacionesDescripcion], [PostulacionesReqSuministros], [PostulacionesSuministrosDescri], [PostulacionesFechaTrabajo], [PostulacionesFechaCierre], [PostulacionesHoraCierre], [PostulacionesTipoFecha], [PostulacionesRgoHoraservicio], [PostulacionesApellidoNombre], [PostulacionesMail], [PostulacionesTelefono], [PostulacionesDepartamentoId], [PostulacionesDepartamentoMunic], [PostulacionesZonasID], [PostulacionesDireccion], [PostulacionesFechaAlta], [PostulacionesEstado], [PostulacionesSecUserId], [ServiciosId], [PostulacionesProveedorId]) VALUES(@PostulacionesProvNombreAux, @PostulacionesPrecio, @PostulacionesMultimediaSerial, @PostulacionesDescripcion, @PostulacionesReqSuministros, @PostulacionesSuministrosDescri, @PostulacionesFechaTrabajo, @PostulacionesFechaCierre, @PostulacionesHoraCierre, @PostulacionesTipoFecha, @PostulacionesRgoHoraservicio, @PostulacionesApellidoNombre, @PostulacionesMail, @PostulacionesTelefono, @PostulacionesDepartamentoId, @PostulacionesDepartamentoMunic, @PostulacionesZonasID, @PostulacionesDireccion, @PostulacionesFechaAlta, @PostulacionesEstado, @PostulacionesSecUserId, @ServiciosId, @PostulacionesProveedorId); SELECT SCOPE_IDENTITY()",true, GxErrorMask.GX_NOMASK, false, this,prmBC001K19,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("BC001K20", "UPDATE [Postulaciones] SET [PostulacionesProvNombreAux]=@PostulacionesProvNombreAux, [PostulacionesPrecio]=@PostulacionesPrecio, [PostulacionesMultimediaSerial]=@PostulacionesMultimediaSerial, [PostulacionesDescripcion]=@PostulacionesDescripcion, [PostulacionesReqSuministros]=@PostulacionesReqSuministros, [PostulacionesSuministrosDescri]=@PostulacionesSuministrosDescri, [PostulacionesFechaTrabajo]=@PostulacionesFechaTrabajo, [PostulacionesFechaCierre]=@PostulacionesFechaCierre, [PostulacionesHoraCierre]=@PostulacionesHoraCierre, [PostulacionesTipoFecha]=@PostulacionesTipoFecha, [PostulacionesRgoHoraservicio]=@PostulacionesRgoHoraservicio, [PostulacionesApellidoNombre]=@PostulacionesApellidoNombre, [PostulacionesMail]=@PostulacionesMail, [PostulacionesTelefono]=@PostulacionesTelefono, [PostulacionesDepartamentoId]=@PostulacionesDepartamentoId, [PostulacionesDepartamentoMunic]=@PostulacionesDepartamentoMunic, [PostulacionesZonasID]=@PostulacionesZonasID, [PostulacionesDireccion]=@PostulacionesDireccion, [PostulacionesFechaAlta]=@PostulacionesFechaAlta, [PostulacionesEstado]=@PostulacionesEstado, [PostulacionesSecUserId]=@PostulacionesSecUserId, [ServiciosId]=@ServiciosId, [PostulacionesProveedorId]=@PostulacionesProveedorId  WHERE [PostulacionesId] = @PostulacionesId", GxErrorMask.GX_NOMASK,prmBC001K20)
           ,new CursorDef("BC001K21", "DELETE FROM [Postulaciones]  WHERE [PostulacionesId] = @PostulacionesId", GxErrorMask.GX_NOMASK,prmBC001K21)
           ,new CursorDef("BC001K22", "SELECT [ServiciosNombre] FROM [Servicios] WHERE [ServiciosId] = @ServiciosId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001K22,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC001K23", "SELECT [ProveedorNombre] AS PostulacionesProveedorNombre FROM [Proveedor] WHERE [ProveedorID] = @PostulacionesProveedorId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001K23,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC001K24", "SELECT TOP 1 [SolicitudesID] FROM [Solicitudes] WHERE [PostulacionesId] = @PostulacionesId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001K24,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("BC001K25", "UPDATE [Postulaciones] SET [PostulacionesMultimediaSerial]=@PostulacionesMultimediaSerial  WHERE [PostulacionesId] = @PostulacionesId", GxErrorMask.GX_NOMASK,prmBC001K25)
           ,new CursorDef("BC001K27", "SELECT TM1.[PostulacionesId], T3.[ServiciosNombre], TM1.[PostulacionesProvNombreAux], T4.[ProveedorNombre] AS PostulacionesProveedorNombre, TM1.[PostulacionesPrecio], TM1.[PostulacionesMultimediaSerial], TM1.[PostulacionesDescripcion], TM1.[PostulacionesReqSuministros], TM1.[PostulacionesSuministrosDescri], TM1.[PostulacionesFechaTrabajo], TM1.[PostulacionesFechaCierre], TM1.[PostulacionesHoraCierre], TM1.[PostulacionesTipoFecha], TM1.[PostulacionesRgoHoraservicio], TM1.[PostulacionesApellidoNombre], TM1.[PostulacionesMail], TM1.[PostulacionesTelefono], TM1.[PostulacionesDepartamentoId], TM1.[PostulacionesDepartamentoMunic], TM1.[PostulacionesZonasID], TM1.[PostulacionesDireccion], TM1.[PostulacionesFechaAlta], TM1.[PostulacionesEstado], TM1.[PostulacionesSecUserId], TM1.[ServiciosId], TM1.[PostulacionesProveedorId] AS PostulacionesProveedorId, COALESCE( T2.[PostulacionesSolicitudesId], 0) AS PostulacionesSolicitudesId FROM (([Postulaciones] TM1 LEFT JOIN [Servicios] T3 ON T3.[ServiciosId] = TM1.[ServiciosId]) INNER JOIN [Proveedor] T4 ON T4.[ProveedorID] = TM1.[PostulacionesProveedorId]),  (SELECT MIN([SolicitudesID]) AS PostulacionesSolicitudesId FROM [Solicitudes] WHERE [PostulacionesId] = @PostulacionesId ) T2 WHERE TM1.[PostulacionesId] = @PostulacionesId ORDER BY TM1.[PostulacionesId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmBC001K27,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC001K28", "SELECT T2.[ServiciosId], T1.[PostulacionesId], T2.[CategoriasNombre], T1.[CategoriasId] FROM ([PostulacionesCategorias] T1 LEFT JOIN [ServiciosCategorias] T2 ON T2.[ServiciosId] = @ServiciosId AND T2.[CategoriasId] = T1.[CategoriasId]) WHERE T1.[PostulacionesId] = @PostulacionesId and T1.[CategoriasId] = @CategoriasId ORDER BY T1.[PostulacionesId], T1.[CategoriasId]  OPTION (FAST 11)",true, GxErrorMask.GX_NOMASK, false, this,prmBC001K28,11, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC001K29", "SELECT [PostulacionesId], [CategoriasId] FROM [PostulacionesCategorias] WHERE [PostulacionesId] = @PostulacionesId AND [CategoriasId] = @CategoriasId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmBC001K29,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC001K30", "INSERT INTO [PostulacionesCategorias]([PostulacionesId], [CategoriasId]) VALUES(@PostulacionesId, @CategoriasId)", GxErrorMask.GX_NOMASK,prmBC001K30)
           ,new CursorDef("BC001K31", "DELETE FROM [PostulacionesCategorias]  WHERE [PostulacionesId] = @PostulacionesId AND [CategoriasId] = @CategoriasId", GxErrorMask.GX_NOMASK,prmBC001K31)
           ,new CursorDef("BC001K32", "SELECT [CategoriasNombre] FROM [ServiciosCategorias] WHERE [ServiciosId] = @ServiciosId AND [CategoriasId] = @CategoriasId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001K32,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC001K33", "SELECT T2.[ServiciosId], T1.[PostulacionesId], T2.[CategoriasNombre], T1.[CategoriasId] FROM ([PostulacionesCategorias] T1 LEFT JOIN [ServiciosCategorias] T2 ON T2.[ServiciosId] = @ServiciosId AND T2.[CategoriasId] = T1.[CategoriasId]) WHERE T1.[PostulacionesId] = @PostulacionesId ORDER BY T1.[PostulacionesId], T1.[CategoriasId]  OPTION (FAST 11)",true, GxErrorMask.GX_NOMASK, false, this,prmBC001K33,11, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC001K34", "SELECT [PostulacionesId], [MultimediaId], [MultimediaDireccion], [MultimediaDescripcion], [MultimediaTipo] FROM [PostulacionesMultimedia] WHERE [PostulacionesId] = @PostulacionesId and [MultimediaId] = @MultimediaId ORDER BY [PostulacionesId], [MultimediaId]  OPTION (FAST 11)",true, GxErrorMask.GX_NOMASK, false, this,prmBC001K34,11, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC001K35", "SELECT [PostulacionesId], [MultimediaId] FROM [PostulacionesMultimedia] WHERE [PostulacionesId] = @PostulacionesId AND [MultimediaId] = @MultimediaId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmBC001K35,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC001K36", "INSERT INTO [PostulacionesMultimedia]([PostulacionesId], [MultimediaId], [MultimediaDireccion], [MultimediaDescripcion], [MultimediaTipo]) VALUES(@PostulacionesId, @MultimediaId, @MultimediaDireccion, @MultimediaDescripcion, @MultimediaTipo)", GxErrorMask.GX_NOMASK,prmBC001K36)
           ,new CursorDef("BC001K37", "UPDATE [PostulacionesMultimedia] SET [MultimediaDireccion]=@MultimediaDireccion, [MultimediaDescripcion]=@MultimediaDescripcion, [MultimediaTipo]=@MultimediaTipo  WHERE [PostulacionesId] = @PostulacionesId AND [MultimediaId] = @MultimediaId", GxErrorMask.GX_NOMASK,prmBC001K37)
           ,new CursorDef("BC001K38", "DELETE FROM [PostulacionesMultimedia]  WHERE [PostulacionesId] = @PostulacionesId AND [MultimediaId] = @MultimediaId", GxErrorMask.GX_NOMASK,prmBC001K38)
           ,new CursorDef("BC001K39", "SELECT [PostulacionesId], [MultimediaId], [MultimediaDireccion], [MultimediaDescripcion], [MultimediaTipo] FROM [PostulacionesMultimedia] WHERE [PostulacionesId] = @PostulacionesId ORDER BY [PostulacionesId], [MultimediaId]  OPTION (FAST 11)",true, GxErrorMask.GX_NOMASK, false, this,prmBC001K39,11, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC001K40", "SELECT T1.[PostulacionesId], T1.[PostulacionProfesionalEstado], T1.[PostulacionProfesionalFechaA], T1.[PostulacionProfesionalFechaT], T1.[PostulacionProfesionalTurnoT], T1.[PostulacionProfesionalPrecio], T1.[PostulacionProfesionalPlazoE], T1.[PostulacionProfesionalUniE], T1.[PostulacionProfesionalGar], T1.[PostulacionProfesionalUniG], T1.[PostulacionProfesionalA], T2.[ProfesionalesApellidoPrimero], T2.[ProfesionalesPrimerNombre], T2.[ProfesionalesSegundoNombre], T1.[ProfesionalesId] FROM ([PostulacionesProfesionales] T1 INNER JOIN [Profesionales] T2 ON T2.[ProfesionalesId] = T1.[ProfesionalesId]) WHERE T1.[PostulacionesId] = @PostulacionesId and T1.[ProfesionalesId] = @ProfesionalesId ORDER BY T1.[PostulacionesId], T1.[ProfesionalesId]  OPTION (FAST 11)",true, GxErrorMask.GX_NOMASK, false, this,prmBC001K40,11, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC001K41", "SELECT [PostulacionesId], [ProfesionalesId] FROM [PostulacionesProfesionales] WHERE [PostulacionesId] = @PostulacionesId AND [ProfesionalesId] = @ProfesionalesId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmBC001K41,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC001K42", "INSERT INTO [PostulacionesProfesionales]([PostulacionesId], [PostulacionProfesionalEstado], [PostulacionProfesionalFechaA], [PostulacionProfesionalFechaT], [PostulacionProfesionalTurnoT], [PostulacionProfesionalPrecio], [PostulacionProfesionalPlazoE], [PostulacionProfesionalUniE], [PostulacionProfesionalGar], [PostulacionProfesionalUniG], [PostulacionProfesionalA], [ProfesionalesId]) VALUES(@PostulacionesId, @PostulacionProfesionalEstado, @PostulacionProfesionalFechaA, @PostulacionProfesionalFechaT, @PostulacionProfesionalTurnoT, @PostulacionProfesionalPrecio, @PostulacionProfesionalPlazoE, @PostulacionProfesionalUniE, @PostulacionProfesionalGar, @PostulacionProfesionalUniG, @PostulacionProfesionalA, @ProfesionalesId)", GxErrorMask.GX_NOMASK,prmBC001K42)
           ,new CursorDef("BC001K43", "UPDATE [PostulacionesProfesionales] SET [PostulacionProfesionalEstado]=@PostulacionProfesionalEstado, [PostulacionProfesionalFechaA]=@PostulacionProfesionalFechaA, [PostulacionProfesionalFechaT]=@PostulacionProfesionalFechaT, [PostulacionProfesionalTurnoT]=@PostulacionProfesionalTurnoT, [PostulacionProfesionalPrecio]=@PostulacionProfesionalPrecio, [PostulacionProfesionalPlazoE]=@PostulacionProfesionalPlazoE, [PostulacionProfesionalUniE]=@PostulacionProfesionalUniE, [PostulacionProfesionalGar]=@PostulacionProfesionalGar, [PostulacionProfesionalUniG]=@PostulacionProfesionalUniG, [PostulacionProfesionalA]=@PostulacionProfesionalA  WHERE [PostulacionesId] = @PostulacionesId AND [ProfesionalesId] = @ProfesionalesId", GxErrorMask.GX_NOMASK,prmBC001K43)
           ,new CursorDef("BC001K44", "DELETE FROM [PostulacionesProfesionales]  WHERE [PostulacionesId] = @PostulacionesId AND [ProfesionalesId] = @ProfesionalesId", GxErrorMask.GX_NOMASK,prmBC001K44)
           ,new CursorDef("BC001K45", "SELECT [ProfesionalesApellidoPrimero], [ProfesionalesPrimerNombre], [ProfesionalesSegundoNombre] FROM [Profesionales] WHERE [ProfesionalesId] = @ProfesionalesId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001K45,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC001K46", "SELECT T1.[PostulacionesId], T1.[PostulacionProfesionalEstado], T1.[PostulacionProfesionalFechaA], T1.[PostulacionProfesionalFechaT], T1.[PostulacionProfesionalTurnoT], T1.[PostulacionProfesionalPrecio], T1.[PostulacionProfesionalPlazoE], T1.[PostulacionProfesionalUniE], T1.[PostulacionProfesionalGar], T1.[PostulacionProfesionalUniG], T1.[PostulacionProfesionalA], T2.[ProfesionalesApellidoPrimero], T2.[ProfesionalesPrimerNombre], T2.[ProfesionalesSegundoNombre], T1.[ProfesionalesId] FROM ([PostulacionesProfesionales] T1 INNER JOIN [Profesionales] T2 ON T2.[ProfesionalesId] = T1.[ProfesionalesId]) WHERE T1.[PostulacionesId] = @PostulacionesId ORDER BY T1.[PostulacionesId], T1.[ProfesionalesId]  OPTION (FAST 11)",true, GxErrorMask.GX_NOMASK, false, this,prmBC001K46,11, GxCacheFrequency.OFF ,true,false )
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
              ((string[]) buf[1])[0] = rslt.getString(2, 3);
              ((DateTime[]) buf[2])[0] = rslt.getGXDateTime(3);
              ((DateTime[]) buf[3])[0] = rslt.getGXDate(4);
              ((string[]) buf[4])[0] = rslt.getString(5, 1);
              ((decimal[]) buf[5])[0] = rslt.getDecimal(6);
              ((bool[]) buf[6])[0] = rslt.wasNull(6);
              ((short[]) buf[7])[0] = rslt.getShort(7);
              ((bool[]) buf[8])[0] = rslt.wasNull(7);
              ((string[]) buf[9])[0] = rslt.getString(8, 1);
              ((bool[]) buf[10])[0] = rslt.wasNull(8);
              ((short[]) buf[11])[0] = rslt.getShort(9);
              ((bool[]) buf[12])[0] = rslt.wasNull(9);
              ((string[]) buf[13])[0] = rslt.getString(10, 1);
              ((bool[]) buf[14])[0] = rslt.wasNull(10);
              ((string[]) buf[15])[0] = rslt.getVarchar(11);
              ((bool[]) buf[16])[0] = rslt.wasNull(11);
              ((string[]) buf[17])[0] = rslt.getString(12, 20);
              return;
           case 1 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 3);
              ((DateTime[]) buf[2])[0] = rslt.getGXDateTime(3);
              ((DateTime[]) buf[3])[0] = rslt.getGXDate(4);
              ((string[]) buf[4])[0] = rslt.getString(5, 1);
              ((decimal[]) buf[5])[0] = rslt.getDecimal(6);
              ((bool[]) buf[6])[0] = rslt.wasNull(6);
              ((short[]) buf[7])[0] = rslt.getShort(7);
              ((bool[]) buf[8])[0] = rslt.wasNull(7);
              ((string[]) buf[9])[0] = rslt.getString(8, 1);
              ((bool[]) buf[10])[0] = rslt.wasNull(8);
              ((short[]) buf[11])[0] = rslt.getShort(9);
              ((bool[]) buf[12])[0] = rslt.wasNull(9);
              ((string[]) buf[13])[0] = rslt.getString(10, 1);
              ((bool[]) buf[14])[0] = rslt.wasNull(10);
              ((string[]) buf[15])[0] = rslt.getVarchar(11);
              ((bool[]) buf[16])[0] = rslt.wasNull(11);
              ((string[]) buf[17])[0] = rslt.getString(12, 20);
              return;
           case 2 :
              ((string[]) buf[0])[0] = rslt.getString(1, 30);
              ((string[]) buf[1])[0] = rslt.getString(2, 30);
              ((string[]) buf[2])[0] = rslt.getString(3, 30);
              return;
           case 3 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              ((string[]) buf[2])[0] = rslt.getString(3, 100);
              ((string[]) buf[3])[0] = rslt.getString(4, 250);
              ((string[]) buf[4])[0] = rslt.getVarchar(5);
              return;
           case 4 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              ((string[]) buf[2])[0] = rslt.getString(3, 100);
              ((string[]) buf[3])[0] = rslt.getString(4, 250);
              ((string[]) buf[4])[0] = rslt.getVarchar(5);
              return;
           case 5 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              return;
           case 6 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              return;
           case 7 :
              ((string[]) buf[0])[0] = rslt.getString(1, 80);
              return;
           case 8 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 80);
              ((decimal[]) buf[2])[0] = rslt.getDecimal(3);
              ((short[]) buf[3])[0] = rslt.getShort(4);
              ((string[]) buf[4])[0] = rslt.getString(5, 2000);
              ((bool[]) buf[5])[0] = rslt.getBool(6);
              ((string[]) buf[6])[0] = rslt.getString(7, 250);
              ((DateTime[]) buf[7])[0] = rslt.getGXDate(8);
              ((DateTime[]) buf[8])[0] = rslt.getGXDate(9);
              ((string[]) buf[9])[0] = rslt.getVarchar(10);
              ((string[]) buf[10])[0] = rslt.getVarchar(11);
              ((string[]) buf[11])[0] = rslt.getString(12, 5);
              ((string[]) buf[12])[0] = rslt.getString(13, 80);
              ((string[]) buf[13])[0] = rslt.getVarchar(14);
              ((string[]) buf[14])[0] = rslt.getString(15, 20);
              ((long[]) buf[15])[0] = rslt.getLong(16);
              ((long[]) buf[16])[0] = rslt.getLong(17);
              ((long[]) buf[17])[0] = rslt.getLong(18);
              ((string[]) buf[18])[0] = rslt.getString(19, 100);
              ((DateTime[]) buf[19])[0] = rslt.getGXDateTime(20);
              ((string[]) buf[20])[0] = rslt.getString(21, 3);
              ((long[]) buf[21])[0] = rslt.getLong(22);
              ((long[]) buf[22])[0] = rslt.getLong(23);
              ((bool[]) buf[23])[0] = rslt.wasNull(23);
              ((long[]) buf[24])[0] = rslt.getLong(24);
              return;
           case 9 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 80);
              ((decimal[]) buf[2])[0] = rslt.getDecimal(3);
              ((short[]) buf[3])[0] = rslt.getShort(4);
              ((string[]) buf[4])[0] = rslt.getString(5, 2000);
              ((bool[]) buf[5])[0] = rslt.getBool(6);
              ((string[]) buf[6])[0] = rslt.getString(7, 250);
              ((DateTime[]) buf[7])[0] = rslt.getGXDate(8);
              ((DateTime[]) buf[8])[0] = rslt.getGXDate(9);
              ((string[]) buf[9])[0] = rslt.getVarchar(10);
              ((string[]) buf[10])[0] = rslt.getVarchar(11);
              ((string[]) buf[11])[0] = rslt.getString(12, 5);
              ((string[]) buf[12])[0] = rslt.getString(13, 80);
              ((string[]) buf[13])[0] = rslt.getVarchar(14);
              ((string[]) buf[14])[0] = rslt.getString(15, 20);
              ((long[]) buf[15])[0] = rslt.getLong(16);
              ((long[]) buf[16])[0] = rslt.getLong(17);
              ((long[]) buf[17])[0] = rslt.getLong(18);
              ((string[]) buf[18])[0] = rslt.getString(19, 100);
              ((DateTime[]) buf[19])[0] = rslt.getGXDateTime(20);
              ((string[]) buf[20])[0] = rslt.getString(21, 3);
              ((long[]) buf[21])[0] = rslt.getLong(22);
              ((long[]) buf[22])[0] = rslt.getLong(23);
              ((bool[]) buf[23])[0] = rslt.wasNull(23);
              ((long[]) buf[24])[0] = rslt.getLong(24);
              return;
           case 10 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((bool[]) buf[1])[0] = rslt.wasNull(1);
              return;
           case 11 :
              ((string[]) buf[0])[0] = rslt.getString(1, 80);
              return;
           case 12 :
              ((string[]) buf[0])[0] = rslt.getString(1, 80);
              return;
           case 13 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 80);
              ((string[]) buf[2])[0] = rslt.getString(3, 80);
              ((string[]) buf[3])[0] = rslt.getString(4, 80);
              ((decimal[]) buf[4])[0] = rslt.getDecimal(5);
              ((short[]) buf[5])[0] = rslt.getShort(6);
              ((string[]) buf[6])[0] = rslt.getString(7, 2000);
              ((bool[]) buf[7])[0] = rslt.getBool(8);
              ((string[]) buf[8])[0] = rslt.getString(9, 250);
              ((DateTime[]) buf[9])[0] = rslt.getGXDate(10);
              ((DateTime[]) buf[10])[0] = rslt.getGXDate(11);
              ((string[]) buf[11])[0] = rslt.getVarchar(12);
              ((string[]) buf[12])[0] = rslt.getVarchar(13);
              ((string[]) buf[13])[0] = rslt.getString(14, 5);
              ((string[]) buf[14])[0] = rslt.getString(15, 80);
              ((string[]) buf[15])[0] = rslt.getVarchar(16);
              ((string[]) buf[16])[0] = rslt.getString(17, 20);
              ((long[]) buf[17])[0] = rslt.getLong(18);
              ((long[]) buf[18])[0] = rslt.getLong(19);
              ((long[]) buf[19])[0] = rslt.getLong(20);
              ((string[]) buf[20])[0] = rslt.getString(21, 100);
              ((DateTime[]) buf[21])[0] = rslt.getGXDateTime(22);
              ((string[]) buf[22])[0] = rslt.getString(23, 3);
              ((long[]) buf[23])[0] = rslt.getLong(24);
              ((long[]) buf[24])[0] = rslt.getLong(25);
              ((bool[]) buf[25])[0] = rslt.wasNull(25);
              ((long[]) buf[26])[0] = rslt.getLong(26);
              ((long[]) buf[27])[0] = rslt.getLong(27);
              ((bool[]) buf[28])[0] = rslt.wasNull(27);
              return;
           case 14 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 15 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 18 :
              ((string[]) buf[0])[0] = rslt.getString(1, 80);
              return;
           case 19 :
              ((string[]) buf[0])[0] = rslt.getString(1, 80);
              return;
           case 20 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 22 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 80);
              ((string[]) buf[2])[0] = rslt.getString(3, 80);
              ((string[]) buf[3])[0] = rslt.getString(4, 80);
              ((decimal[]) buf[4])[0] = rslt.getDecimal(5);
              ((short[]) buf[5])[0] = rslt.getShort(6);
              ((string[]) buf[6])[0] = rslt.getString(7, 2000);
              ((bool[]) buf[7])[0] = rslt.getBool(8);
              ((string[]) buf[8])[0] = rslt.getString(9, 250);
              ((DateTime[]) buf[9])[0] = rslt.getGXDate(10);
              ((DateTime[]) buf[10])[0] = rslt.getGXDate(11);
              ((string[]) buf[11])[0] = rslt.getVarchar(12);
              ((string[]) buf[12])[0] = rslt.getVarchar(13);
              ((string[]) buf[13])[0] = rslt.getString(14, 5);
              ((string[]) buf[14])[0] = rslt.getString(15, 80);
              ((string[]) buf[15])[0] = rslt.getVarchar(16);
              ((string[]) buf[16])[0] = rslt.getString(17, 20);
              ((long[]) buf[17])[0] = rslt.getLong(18);
              ((long[]) buf[18])[0] = rslt.getLong(19);
              ((long[]) buf[19])[0] = rslt.getLong(20);
              ((string[]) buf[20])[0] = rslt.getString(21, 100);
              ((DateTime[]) buf[21])[0] = rslt.getGXDateTime(22);
              ((string[]) buf[22])[0] = rslt.getString(23, 3);
              ((long[]) buf[23])[0] = rslt.getLong(24);
              ((long[]) buf[24])[0] = rslt.getLong(25);
              ((bool[]) buf[25])[0] = rslt.wasNull(25);
              ((long[]) buf[26])[0] = rslt.getLong(26);
              ((long[]) buf[27])[0] = rslt.getLong(27);
              ((bool[]) buf[28])[0] = rslt.wasNull(27);
              return;
           case 23 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              ((string[]) buf[2])[0] = rslt.getString(3, 80);
              ((long[]) buf[3])[0] = rslt.getLong(4);
              return;
           case 24 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              return;
           case 27 :
              ((string[]) buf[0])[0] = rslt.getString(1, 80);
              return;
           case 28 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              ((string[]) buf[2])[0] = rslt.getString(3, 80);
              ((long[]) buf[3])[0] = rslt.getLong(4);
              return;
           case 29 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              ((string[]) buf[2])[0] = rslt.getString(3, 100);
              ((string[]) buf[3])[0] = rslt.getString(4, 250);
              ((string[]) buf[4])[0] = rslt.getVarchar(5);
              return;
     }
     getresults30( cursor, rslt, buf) ;
  }

  public void getresults30( int cursor ,
                            IFieldGetter rslt ,
                            Object[] buf )
  {
     switch ( cursor )
     {
           case 30 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              return;
           case 34 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              ((string[]) buf[2])[0] = rslt.getString(3, 100);
              ((string[]) buf[3])[0] = rslt.getString(4, 250);
              ((string[]) buf[4])[0] = rslt.getVarchar(5);
              return;
           case 35 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 3);
              ((DateTime[]) buf[2])[0] = rslt.getGXDateTime(3);
              ((DateTime[]) buf[3])[0] = rslt.getGXDate(4);
              ((string[]) buf[4])[0] = rslt.getString(5, 1);
              ((decimal[]) buf[5])[0] = rslt.getDecimal(6);
              ((bool[]) buf[6])[0] = rslt.wasNull(6);
              ((short[]) buf[7])[0] = rslt.getShort(7);
              ((bool[]) buf[8])[0] = rslt.wasNull(7);
              ((string[]) buf[9])[0] = rslt.getString(8, 1);
              ((bool[]) buf[10])[0] = rslt.wasNull(8);
              ((short[]) buf[11])[0] = rslt.getShort(9);
              ((bool[]) buf[12])[0] = rslt.wasNull(9);
              ((string[]) buf[13])[0] = rslt.getString(10, 1);
              ((bool[]) buf[14])[0] = rslt.wasNull(10);
              ((string[]) buf[15])[0] = rslt.getVarchar(11);
              ((bool[]) buf[16])[0] = rslt.wasNull(11);
              ((string[]) buf[17])[0] = rslt.getString(12, 30);
              ((string[]) buf[18])[0] = rslt.getString(13, 30);
              ((string[]) buf[19])[0] = rslt.getString(14, 30);
              ((string[]) buf[20])[0] = rslt.getString(15, 20);
              return;
           case 36 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 20);
              return;
           case 40 :
              ((string[]) buf[0])[0] = rslt.getString(1, 30);
              ((string[]) buf[1])[0] = rslt.getString(2, 30);
              ((string[]) buf[2])[0] = rslt.getString(3, 30);
              return;
           case 41 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 3);
              ((DateTime[]) buf[2])[0] = rslt.getGXDateTime(3);
              ((DateTime[]) buf[3])[0] = rslt.getGXDate(4);
              ((string[]) buf[4])[0] = rslt.getString(5, 1);
              ((decimal[]) buf[5])[0] = rslt.getDecimal(6);
              ((bool[]) buf[6])[0] = rslt.wasNull(6);
              ((short[]) buf[7])[0] = rslt.getShort(7);
              ((bool[]) buf[8])[0] = rslt.wasNull(7);
              ((string[]) buf[9])[0] = rslt.getString(8, 1);
              ((bool[]) buf[10])[0] = rslt.wasNull(8);
              ((short[]) buf[11])[0] = rslt.getShort(9);
              ((bool[]) buf[12])[0] = rslt.wasNull(9);
              ((string[]) buf[13])[0] = rslt.getString(10, 1);
              ((bool[]) buf[14])[0] = rslt.wasNull(10);
              ((string[]) buf[15])[0] = rslt.getVarchar(11);
              ((bool[]) buf[16])[0] = rslt.wasNull(11);
              ((string[]) buf[17])[0] = rslt.getString(12, 30);
              ((string[]) buf[18])[0] = rslt.getString(13, 30);
              ((string[]) buf[19])[0] = rslt.getString(14, 30);
              ((string[]) buf[20])[0] = rslt.getString(15, 20);
              return;
     }
  }

}

}

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
   public class publicaciones_bc : GXHttpHandler, IGxSilentTrn
   {
      public publicaciones_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public publicaciones_bc( IGxContext context )
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
         ReadRow1G127( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey1G127( ) ;
         standaloneModal( ) ;
         AddRow1G127( ) ;
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
            E111G2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               Z381PublicacionesId = A381PublicacionesId;
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

      protected void CONFIRM_1G0( )
      {
         BeforeValidate1G127( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls1G127( ) ;
            }
            else
            {
               CheckExtendedTable1G127( ) ;
               if ( AnyError == 0 )
               {
                  ZM1G127( 8) ;
                  ZM1G127( 9) ;
               }
               CloseExtendedTableCursors1G127( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            /* Save parent mode. */
            sMode127 = Gx_mode;
            CONFIRM_1G128( ) ;
            if ( AnyError == 0 )
            {
               CONFIRM_1G129( ) ;
               if ( AnyError == 0 )
               {
                  /* Restore parent mode. */
                  Gx_mode = sMode127;
               }
            }
            /* Restore parent mode. */
            Gx_mode = sMode127;
         }
      }

      protected void CONFIRM_1G129( )
      {
         nGXsfl_129_idx = 0;
         while ( nGXsfl_129_idx < bcPublicaciones.gxTpr_Multimedia.Count )
         {
            ReadRow1G129( ) ;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( Gx_mode)) )
            {
               if ( RcdFound129 == 0 )
               {
                  Gx_mode = "INS";
               }
               else
               {
                  Gx_mode = "UPD";
               }
            }
            if ( ! IsIns( ) || ( nIsMod_129 != 0 ) )
            {
               GetKey1G129( ) ;
               if ( IsIns( ) && ! IsDlt( ) )
               {
                  if ( RcdFound129 == 0 )
                  {
                     Gx_mode = "INS";
                     BeforeValidate1G129( ) ;
                     if ( AnyError == 0 )
                     {
                        CheckExtendedTable1G129( ) ;
                        if ( AnyError == 0 )
                        {
                        }
                        CloseExtendedTableCursors1G129( ) ;
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
                  if ( RcdFound129 != 0 )
                  {
                     if ( IsDlt( ) )
                     {
                        Gx_mode = "DLT";
                        getByPrimaryKey1G129( ) ;
                        Load1G129( ) ;
                        BeforeValidate1G129( ) ;
                        if ( AnyError == 0 )
                        {
                           OnDeleteControls1G129( ) ;
                        }
                     }
                     else
                     {
                        if ( nIsMod_129 != 0 )
                        {
                           Gx_mode = "UPD";
                           BeforeValidate1G129( ) ;
                           if ( AnyError == 0 )
                           {
                              CheckExtendedTable1G129( ) ;
                              if ( AnyError == 0 )
                              {
                              }
                              CloseExtendedTableCursors1G129( ) ;
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
               VarsToRow129( ((SdtPublicaciones_Multimedia)bcPublicaciones.gxTpr_Multimedia.Item(nGXsfl_129_idx))) ;
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
      }

      protected void CONFIRM_1G128( )
      {
         nGXsfl_128_idx = 0;
         while ( nGXsfl_128_idx < bcPublicaciones.gxTpr_Documento.Count )
         {
            ReadRow1G128( ) ;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( Gx_mode)) )
            {
               if ( RcdFound128 == 0 )
               {
                  Gx_mode = "INS";
               }
               else
               {
                  Gx_mode = "UPD";
               }
            }
            if ( ! IsIns( ) || ( nIsMod_128 != 0 ) )
            {
               GetKey1G128( ) ;
               if ( IsIns( ) && ! IsDlt( ) )
               {
                  if ( RcdFound128 == 0 )
                  {
                     Gx_mode = "INS";
                     BeforeValidate1G128( ) ;
                     if ( AnyError == 0 )
                     {
                        CheckExtendedTable1G128( ) ;
                        if ( AnyError == 0 )
                        {
                        }
                        CloseExtendedTableCursors1G128( ) ;
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
                  if ( RcdFound128 != 0 )
                  {
                     if ( IsDlt( ) )
                     {
                        Gx_mode = "DLT";
                        getByPrimaryKey1G128( ) ;
                        Load1G128( ) ;
                        BeforeValidate1G128( ) ;
                        if ( AnyError == 0 )
                        {
                           OnDeleteControls1G128( ) ;
                        }
                     }
                     else
                     {
                        if ( nIsMod_128 != 0 )
                        {
                           Gx_mode = "UPD";
                           BeforeValidate1G128( ) ;
                           if ( AnyError == 0 )
                           {
                              CheckExtendedTable1G128( ) ;
                              if ( AnyError == 0 )
                              {
                              }
                              CloseExtendedTableCursors1G128( ) ;
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
               VarsToRow128( ((SdtPublicaciones_Documento)bcPublicaciones.gxTpr_Documento.Item(nGXsfl_128_idx))) ;
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
      }

      protected void E121G2( )
      {
         /* Start Routine */
         returnInSub = false;
      }

      protected void E111G2( )
      {
         /* After Trn Routine */
         returnInSub = false;
      }

      protected void ZM1G127( short GX_JID )
      {
         if ( ( GX_JID == 7 ) || ( GX_JID == 0 ) )
         {
            Z382PublicacionesTitulo = A382PublicacionesTitulo;
            Z843PublicacionesFecTentInicio = A843PublicacionesFecTentInicio;
            Z844PublicacionesFecRealInicio = A844PublicacionesFecRealInicio;
            Z845PublicacionesFecFinPostulacion = A845PublicacionesFecFinPostulacion;
            Z846PublicacionesDetalleMateriales = A846PublicacionesDetalleMateriales;
            Z847PublicacionesFecVisita = A847PublicacionesFecVisita;
            Z848PublicacionesHoraVisita = A848PublicacionesHoraVisita;
            Z849PublicacionesDirVisita = A849PublicacionesDirVisita;
            Z850PublicacionesCondiciones = A850PublicacionesCondiciones;
            Z851PublicacionesTipoDesembolso = A851PublicacionesTipoDesembolso;
            Z859PublicacionesOtroTipoDes = A859PublicacionesOtroTipoDes;
            Z852PublicacionesModalidad = A852PublicacionesModalidad;
            Z389PublicacionesPrecio = A389PublicacionesPrecio;
            Z854PublicacionesFecCierre = A854PublicacionesFecCierre;
            Z855PublicacionesDocReq = A855PublicacionesDocReq;
            Z856PublicacionesDocDescripcion = A856PublicacionesDocDescripcion;
            Z857PublicacionesTipoEmpresa = A857PublicacionesTipoEmpresa;
            Z858PublicacionesContratoId = A858PublicacionesContratoId;
            Z860PublicacionesTerminoObra = A860PublicacionesTerminoObra;
            Z384PublicacionesEstado = A384PublicacionesEstado;
            Z385PublicacionesSerialIma = A385PublicacionesSerialIma;
            Z395PublicacionesSerialRem = A395PublicacionesSerialRem;
            Z112DepartamentoId = A112DepartamentoId;
            Z114DepartamentoMunicipioId = A114DepartamentoMunicipioId;
            Z118MonedaId = A118MonedaId;
         }
         if ( ( GX_JID == 8 ) || ( GX_JID == 0 ) )
         {
         }
         if ( ( GX_JID == 9 ) || ( GX_JID == 0 ) )
         {
            Z119MonedaISOSimbolo = A119MonedaISOSimbolo;
         }
         if ( GX_JID == -7 )
         {
            Z381PublicacionesId = A381PublicacionesId;
            Z382PublicacionesTitulo = A382PublicacionesTitulo;
            Z383PublicacionesDescripcion = A383PublicacionesDescripcion;
            Z843PublicacionesFecTentInicio = A843PublicacionesFecTentInicio;
            Z844PublicacionesFecRealInicio = A844PublicacionesFecRealInicio;
            Z845PublicacionesFecFinPostulacion = A845PublicacionesFecFinPostulacion;
            Z846PublicacionesDetalleMateriales = A846PublicacionesDetalleMateriales;
            Z847PublicacionesFecVisita = A847PublicacionesFecVisita;
            Z848PublicacionesHoraVisita = A848PublicacionesHoraVisita;
            Z849PublicacionesDirVisita = A849PublicacionesDirVisita;
            Z850PublicacionesCondiciones = A850PublicacionesCondiciones;
            Z851PublicacionesTipoDesembolso = A851PublicacionesTipoDesembolso;
            Z859PublicacionesOtroTipoDes = A859PublicacionesOtroTipoDes;
            Z852PublicacionesModalidad = A852PublicacionesModalidad;
            Z389PublicacionesPrecio = A389PublicacionesPrecio;
            Z854PublicacionesFecCierre = A854PublicacionesFecCierre;
            Z855PublicacionesDocReq = A855PublicacionesDocReq;
            Z856PublicacionesDocDescripcion = A856PublicacionesDocDescripcion;
            Z857PublicacionesTipoEmpresa = A857PublicacionesTipoEmpresa;
            Z858PublicacionesContratoId = A858PublicacionesContratoId;
            Z860PublicacionesTerminoObra = A860PublicacionesTerminoObra;
            Z384PublicacionesEstado = A384PublicacionesEstado;
            Z385PublicacionesSerialIma = A385PublicacionesSerialIma;
            Z395PublicacionesSerialRem = A395PublicacionesSerialRem;
            Z112DepartamentoId = A112DepartamentoId;
            Z114DepartamentoMunicipioId = A114DepartamentoMunicipioId;
            Z118MonedaId = A118MonedaId;
            Z119MonedaISOSimbolo = A119MonedaISOSimbolo;
         }
      }

      protected void standaloneNotModal( )
      {
      }

      protected void standaloneModal( )
      {
      }

      protected void Load1G127( )
      {
         /* Using cursor BC001G10 */
         pr_default.execute(8, new Object[] {A381PublicacionesId});
         if ( (pr_default.getStatus(8) != 101) )
         {
            RcdFound127 = 1;
            A382PublicacionesTitulo = BC001G10_A382PublicacionesTitulo[0];
            A383PublicacionesDescripcion = BC001G10_A383PublicacionesDescripcion[0];
            A843PublicacionesFecTentInicio = BC001G10_A843PublicacionesFecTentInicio[0];
            A844PublicacionesFecRealInicio = BC001G10_A844PublicacionesFecRealInicio[0];
            A845PublicacionesFecFinPostulacion = BC001G10_A845PublicacionesFecFinPostulacion[0];
            A846PublicacionesDetalleMateriales = BC001G10_A846PublicacionesDetalleMateriales[0];
            A847PublicacionesFecVisita = BC001G10_A847PublicacionesFecVisita[0];
            A848PublicacionesHoraVisita = BC001G10_A848PublicacionesHoraVisita[0];
            A849PublicacionesDirVisita = BC001G10_A849PublicacionesDirVisita[0];
            A850PublicacionesCondiciones = BC001G10_A850PublicacionesCondiciones[0];
            A851PublicacionesTipoDesembolso = BC001G10_A851PublicacionesTipoDesembolso[0];
            A859PublicacionesOtroTipoDes = BC001G10_A859PublicacionesOtroTipoDes[0];
            A852PublicacionesModalidad = BC001G10_A852PublicacionesModalidad[0];
            A389PublicacionesPrecio = BC001G10_A389PublicacionesPrecio[0];
            A119MonedaISOSimbolo = BC001G10_A119MonedaISOSimbolo[0];
            A854PublicacionesFecCierre = BC001G10_A854PublicacionesFecCierre[0];
            A855PublicacionesDocReq = BC001G10_A855PublicacionesDocReq[0];
            A856PublicacionesDocDescripcion = BC001G10_A856PublicacionesDocDescripcion[0];
            A857PublicacionesTipoEmpresa = BC001G10_A857PublicacionesTipoEmpresa[0];
            A858PublicacionesContratoId = BC001G10_A858PublicacionesContratoId[0];
            A860PublicacionesTerminoObra = BC001G10_A860PublicacionesTerminoObra[0];
            A384PublicacionesEstado = BC001G10_A384PublicacionesEstado[0];
            A385PublicacionesSerialIma = BC001G10_A385PublicacionesSerialIma[0];
            A395PublicacionesSerialRem = BC001G10_A395PublicacionesSerialRem[0];
            A112DepartamentoId = BC001G10_A112DepartamentoId[0];
            A114DepartamentoMunicipioId = BC001G10_A114DepartamentoMunicipioId[0];
            A118MonedaId = BC001G10_A118MonedaId[0];
            n118MonedaId = BC001G10_n118MonedaId[0];
            ZM1G127( -7) ;
         }
         pr_default.close(8);
         OnLoadActions1G127( ) ;
      }

      protected void OnLoadActions1G127( )
      {
         if ( (0==A118MonedaId) )
         {
            A118MonedaId = 1;
            n118MonedaId = false;
         }
      }

      protected void CheckExtendedTable1G127( )
      {
         standaloneModal( ) ;
         /* Using cursor BC001G8 */
         pr_default.execute(6, new Object[] {A112DepartamentoId, A114DepartamentoMunicipioId});
         if ( (pr_default.getStatus(6) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Municipio", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "DEPARTAMENTOMUNICIPIOID");
            AnyError = 1;
         }
         pr_default.close(6);
         if ( ! ( (DateTime.MinValue==A843PublicacionesFecTentInicio) || ( DateTimeUtil.ResetTime ( A843PublicacionesFecTentInicio ) >= DateTimeUtil.ResetTime ( context.localUtil.YMDToD( 1753, 1, 1) ) ) ) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_OutOfRange", ""), context.GetMessage( "Publicaciones Fec Tent Inicio", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, "");
            AnyError = 1;
         }
         if ( ! ( (DateTime.MinValue==A844PublicacionesFecRealInicio) || ( DateTimeUtil.ResetTime ( A844PublicacionesFecRealInicio ) >= DateTimeUtil.ResetTime ( context.localUtil.YMDToD( 1753, 1, 1) ) ) ) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_OutOfRange", ""), context.GetMessage( "Publicaciones Fec Real Inicio", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, "");
            AnyError = 1;
         }
         if ( ! ( (DateTime.MinValue==A845PublicacionesFecFinPostulacion) || ( DateTimeUtil.ResetTime ( A845PublicacionesFecFinPostulacion ) >= DateTimeUtil.ResetTime ( context.localUtil.YMDToD( 1753, 1, 1) ) ) ) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_OutOfRange", ""), context.GetMessage( "Publicaciones Fec Fin Postulacion", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, "");
            AnyError = 1;
         }
         if ( ! ( (DateTime.MinValue==A847PublicacionesFecVisita) || ( DateTimeUtil.ResetTime ( A847PublicacionesFecVisita ) >= DateTimeUtil.ResetTime ( context.localUtil.YMDToD( 1753, 1, 1) ) ) ) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_OutOfRange", ""), context.GetMessage( "Publicaciones Fec Visita", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, "");
            AnyError = 1;
         }
         if ( (0==A118MonedaId) )
         {
            A118MonedaId = 1;
            n118MonedaId = false;
         }
         /* Using cursor BC001G9 */
         pr_default.execute(7, new Object[] {n118MonedaId, A118MonedaId});
         if ( (pr_default.getStatus(7) == 101) )
         {
            if ( ! ( (0==A118MonedaId) ) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( " T12", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "MONEDAID");
               AnyError = 1;
            }
         }
         A119MonedaISOSimbolo = BC001G9_A119MonedaISOSimbolo[0];
         pr_default.close(7);
         if ( ! ( (DateTime.MinValue==A854PublicacionesFecCierre) || ( DateTimeUtil.ResetTime ( A854PublicacionesFecCierre ) >= DateTimeUtil.ResetTime ( context.localUtil.YMDToD( 1753, 1, 1) ) ) ) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_OutOfRange", ""), context.GetMessage( "Publicaciones Fec Cierre", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, "");
            AnyError = 1;
         }
      }

      protected void CloseExtendedTableCursors1G127( )
      {
         pr_default.close(6);
         pr_default.close(7);
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey1G127( )
      {
         /* Using cursor BC001G11 */
         pr_default.execute(9, new Object[] {A381PublicacionesId});
         if ( (pr_default.getStatus(9) != 101) )
         {
            RcdFound127 = 1;
         }
         else
         {
            RcdFound127 = 0;
         }
         pr_default.close(9);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC001G7 */
         pr_default.execute(5, new Object[] {A381PublicacionesId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            ZM1G127( 7) ;
            RcdFound127 = 1;
            A381PublicacionesId = BC001G7_A381PublicacionesId[0];
            A382PublicacionesTitulo = BC001G7_A382PublicacionesTitulo[0];
            A383PublicacionesDescripcion = BC001G7_A383PublicacionesDescripcion[0];
            A843PublicacionesFecTentInicio = BC001G7_A843PublicacionesFecTentInicio[0];
            A844PublicacionesFecRealInicio = BC001G7_A844PublicacionesFecRealInicio[0];
            A845PublicacionesFecFinPostulacion = BC001G7_A845PublicacionesFecFinPostulacion[0];
            A846PublicacionesDetalleMateriales = BC001G7_A846PublicacionesDetalleMateriales[0];
            A847PublicacionesFecVisita = BC001G7_A847PublicacionesFecVisita[0];
            A848PublicacionesHoraVisita = BC001G7_A848PublicacionesHoraVisita[0];
            A849PublicacionesDirVisita = BC001G7_A849PublicacionesDirVisita[0];
            A850PublicacionesCondiciones = BC001G7_A850PublicacionesCondiciones[0];
            A851PublicacionesTipoDesembolso = BC001G7_A851PublicacionesTipoDesembolso[0];
            A859PublicacionesOtroTipoDes = BC001G7_A859PublicacionesOtroTipoDes[0];
            A852PublicacionesModalidad = BC001G7_A852PublicacionesModalidad[0];
            A389PublicacionesPrecio = BC001G7_A389PublicacionesPrecio[0];
            A854PublicacionesFecCierre = BC001G7_A854PublicacionesFecCierre[0];
            A855PublicacionesDocReq = BC001G7_A855PublicacionesDocReq[0];
            A856PublicacionesDocDescripcion = BC001G7_A856PublicacionesDocDescripcion[0];
            A857PublicacionesTipoEmpresa = BC001G7_A857PublicacionesTipoEmpresa[0];
            A858PublicacionesContratoId = BC001G7_A858PublicacionesContratoId[0];
            A860PublicacionesTerminoObra = BC001G7_A860PublicacionesTerminoObra[0];
            A384PublicacionesEstado = BC001G7_A384PublicacionesEstado[0];
            A385PublicacionesSerialIma = BC001G7_A385PublicacionesSerialIma[0];
            A395PublicacionesSerialRem = BC001G7_A395PublicacionesSerialRem[0];
            A112DepartamentoId = BC001G7_A112DepartamentoId[0];
            A114DepartamentoMunicipioId = BC001G7_A114DepartamentoMunicipioId[0];
            A118MonedaId = BC001G7_A118MonedaId[0];
            n118MonedaId = BC001G7_n118MonedaId[0];
            Z381PublicacionesId = A381PublicacionesId;
            sMode127 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load1G127( ) ;
            if ( AnyError == 1 )
            {
               RcdFound127 = 0;
               InitializeNonKey1G127( ) ;
            }
            Gx_mode = sMode127;
         }
         else
         {
            RcdFound127 = 0;
            InitializeNonKey1G127( ) ;
            sMode127 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode127;
         }
         pr_default.close(5);
      }

      protected void getEqualNoModal( )
      {
         GetKey1G127( ) ;
         if ( RcdFound127 == 0 )
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
         CONFIRM_1G0( ) ;
      }

      protected void update_Check( )
      {
         insert_Check( ) ;
      }

      protected void delete_Check( )
      {
         insert_Check( ) ;
      }

      protected void CheckOptimisticConcurrency1G127( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC001G6 */
            pr_default.execute(4, new Object[] {A381PublicacionesId});
            if ( (pr_default.getStatus(4) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Publicaciones"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(4) == 101) || ( StringUtil.StrCmp(Z382PublicacionesTitulo, BC001G6_A382PublicacionesTitulo[0]) != 0 ) || ( DateTimeUtil.ResetTime ( Z843PublicacionesFecTentInicio ) != DateTimeUtil.ResetTime ( BC001G6_A843PublicacionesFecTentInicio[0] ) ) || ( DateTimeUtil.ResetTime ( Z844PublicacionesFecRealInicio ) != DateTimeUtil.ResetTime ( BC001G6_A844PublicacionesFecRealInicio[0] ) ) || ( DateTimeUtil.ResetTime ( Z845PublicacionesFecFinPostulacion ) != DateTimeUtil.ResetTime ( BC001G6_A845PublicacionesFecFinPostulacion[0] ) ) || ( StringUtil.StrCmp(Z846PublicacionesDetalleMateriales, BC001G6_A846PublicacionesDetalleMateriales[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( DateTimeUtil.ResetTime ( Z847PublicacionesFecVisita ) != DateTimeUtil.ResetTime ( BC001G6_A847PublicacionesFecVisita[0] ) ) || ( StringUtil.StrCmp(Z848PublicacionesHoraVisita, BC001G6_A848PublicacionesHoraVisita[0]) != 0 ) || ( StringUtil.StrCmp(Z849PublicacionesDirVisita, BC001G6_A849PublicacionesDirVisita[0]) != 0 ) || ( StringUtil.StrCmp(Z850PublicacionesCondiciones, BC001G6_A850PublicacionesCondiciones[0]) != 0 ) || ( StringUtil.StrCmp(Z851PublicacionesTipoDesembolso, BC001G6_A851PublicacionesTipoDesembolso[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z859PublicacionesOtroTipoDes, BC001G6_A859PublicacionesOtroTipoDes[0]) != 0 ) || ( StringUtil.StrCmp(Z852PublicacionesModalidad, BC001G6_A852PublicacionesModalidad[0]) != 0 ) || ( Z389PublicacionesPrecio != BC001G6_A389PublicacionesPrecio[0] ) || ( DateTimeUtil.ResetTime ( Z854PublicacionesFecCierre ) != DateTimeUtil.ResetTime ( BC001G6_A854PublicacionesFecCierre[0] ) ) || ( StringUtil.StrCmp(Z855PublicacionesDocReq, BC001G6_A855PublicacionesDocReq[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z856PublicacionesDocDescripcion, BC001G6_A856PublicacionesDocDescripcion[0]) != 0 ) || ( StringUtil.StrCmp(Z857PublicacionesTipoEmpresa, BC001G6_A857PublicacionesTipoEmpresa[0]) != 0 ) || ( StringUtil.StrCmp(Z858PublicacionesContratoId, BC001G6_A858PublicacionesContratoId[0]) != 0 ) || ( StringUtil.StrCmp(Z860PublicacionesTerminoObra, BC001G6_A860PublicacionesTerminoObra[0]) != 0 ) || ( StringUtil.StrCmp(Z384PublicacionesEstado, BC001G6_A384PublicacionesEstado[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z385PublicacionesSerialIma != BC001G6_A385PublicacionesSerialIma[0] ) || ( Z395PublicacionesSerialRem != BC001G6_A395PublicacionesSerialRem[0] ) || ( Z112DepartamentoId != BC001G6_A112DepartamentoId[0] ) || ( Z114DepartamentoMunicipioId != BC001G6_A114DepartamentoMunicipioId[0] ) || ( Z118MonedaId != BC001G6_A118MonedaId[0] ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Publicaciones"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert1G127( )
      {
         BeforeValidate1G127( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1G127( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM1G127( 0) ;
            CheckOptimisticConcurrency1G127( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1G127( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert1G127( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC001G12 */
                     pr_default.execute(10, new Object[] {A382PublicacionesTitulo, A383PublicacionesDescripcion, A843PublicacionesFecTentInicio, A844PublicacionesFecRealInicio, A845PublicacionesFecFinPostulacion, A846PublicacionesDetalleMateriales, A847PublicacionesFecVisita, A848PublicacionesHoraVisita, A849PublicacionesDirVisita, A850PublicacionesCondiciones, A851PublicacionesTipoDesembolso, A859PublicacionesOtroTipoDes, A852PublicacionesModalidad, A389PublicacionesPrecio, A854PublicacionesFecCierre, A855PublicacionesDocReq, A856PublicacionesDocDescripcion, A857PublicacionesTipoEmpresa, A858PublicacionesContratoId, A860PublicacionesTerminoObra, A384PublicacionesEstado, A385PublicacionesSerialIma, A395PublicacionesSerialRem, A112DepartamentoId, A114DepartamentoMunicipioId, n118MonedaId, A118MonedaId});
                     A381PublicacionesId = BC001G12_A381PublicacionesId[0];
                     pr_default.close(10);
                     pr_default.SmartCacheProvider.SetUpdated("Publicaciones");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           ProcessLevel1G127( ) ;
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
               Load1G127( ) ;
            }
            EndLevel1G127( ) ;
         }
         CloseExtendedTableCursors1G127( ) ;
      }

      protected void Update1G127( )
      {
         BeforeValidate1G127( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1G127( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1G127( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1G127( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate1G127( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC001G13 */
                     pr_default.execute(11, new Object[] {A382PublicacionesTitulo, A383PublicacionesDescripcion, A843PublicacionesFecTentInicio, A844PublicacionesFecRealInicio, A845PublicacionesFecFinPostulacion, A846PublicacionesDetalleMateriales, A847PublicacionesFecVisita, A848PublicacionesHoraVisita, A849PublicacionesDirVisita, A850PublicacionesCondiciones, A851PublicacionesTipoDesembolso, A859PublicacionesOtroTipoDes, A852PublicacionesModalidad, A389PublicacionesPrecio, A854PublicacionesFecCierre, A855PublicacionesDocReq, A856PublicacionesDocDescripcion, A857PublicacionesTipoEmpresa, A858PublicacionesContratoId, A860PublicacionesTerminoObra, A384PublicacionesEstado, A385PublicacionesSerialIma, A395PublicacionesSerialRem, A112DepartamentoId, A114DepartamentoMunicipioId, n118MonedaId, A118MonedaId, A381PublicacionesId});
                     pr_default.close(11);
                     pr_default.SmartCacheProvider.SetUpdated("Publicaciones");
                     if ( (pr_default.getStatus(11) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Publicaciones"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate1G127( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           ProcessLevel1G127( ) ;
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
            EndLevel1G127( ) ;
         }
         CloseExtendedTableCursors1G127( ) ;
      }

      protected void DeferredUpdate1G127( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate1G127( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1G127( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls1G127( ) ;
            AfterConfirm1G127( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete1G127( ) ;
               if ( AnyError == 0 )
               {
                  ScanKeyStart1G129( ) ;
                  while ( RcdFound129 != 0 )
                  {
                     getByPrimaryKey1G129( ) ;
                     Delete1G129( ) ;
                     ScanKeyNext1G129( ) ;
                  }
                  ScanKeyEnd1G129( ) ;
                  ScanKeyStart1G128( ) ;
                  while ( RcdFound128 != 0 )
                  {
                     getByPrimaryKey1G128( ) ;
                     Delete1G128( ) ;
                     ScanKeyNext1G128( ) ;
                  }
                  ScanKeyEnd1G128( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC001G14 */
                     pr_default.execute(12, new Object[] {A381PublicacionesId});
                     pr_default.close(12);
                     pr_default.SmartCacheProvider.SetUpdated("Publicaciones");
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
         sMode127 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel1G127( ) ;
         Gx_mode = sMode127;
      }

      protected void OnDeleteControls1G127( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor BC001G15 */
            pr_default.execute(13, new Object[] {n118MonedaId, A118MonedaId});
            A119MonedaISOSimbolo = BC001G15_A119MonedaISOSimbolo[0];
            pr_default.close(13);
         }
      }

      protected void ProcessNestedLevel1G128( )
      {
         nGXsfl_128_idx = 0;
         while ( nGXsfl_128_idx < bcPublicaciones.gxTpr_Documento.Count )
         {
            ReadRow1G128( ) ;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( Gx_mode)) )
            {
               if ( RcdFound128 == 0 )
               {
                  Gx_mode = "INS";
               }
               else
               {
                  Gx_mode = "UPD";
               }
            }
            if ( ! IsIns( ) || ( nIsMod_128 != 0 ) )
            {
               standaloneNotModal1G128( ) ;
               if ( IsIns( ) )
               {
                  Gx_mode = "INS";
                  Insert1G128( ) ;
               }
               else
               {
                  if ( IsDlt( ) )
                  {
                     Gx_mode = "DLT";
                     Delete1G128( ) ;
                  }
                  else
                  {
                     Gx_mode = "UPD";
                     Update1G128( ) ;
                  }
               }
            }
            KeyVarsToRow128( ((SdtPublicaciones_Documento)bcPublicaciones.gxTpr_Documento.Item(nGXsfl_128_idx))) ;
         }
         if ( AnyError == 0 )
         {
            /* Batch update SDT rows */
            nGXsfl_128_idx = 0;
            while ( nGXsfl_128_idx < bcPublicaciones.gxTpr_Documento.Count )
            {
               ReadRow1G128( ) ;
               if ( String.IsNullOrEmpty(StringUtil.RTrim( Gx_mode)) )
               {
                  if ( RcdFound128 == 0 )
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
                  bcPublicaciones.gxTpr_Documento.RemoveElement(nGXsfl_128_idx);
                  nGXsfl_128_idx = (int)(nGXsfl_128_idx-1);
               }
               else
               {
                  Gx_mode = "UPD";
                  getByPrimaryKey1G128( ) ;
                  VarsToRow128( ((SdtPublicaciones_Documento)bcPublicaciones.gxTpr_Documento.Item(nGXsfl_128_idx))) ;
               }
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
         InitAll1G128( ) ;
         if ( AnyError != 0 )
         {
         }
         nRcdExists_128 = 0;
         nIsMod_128 = 0;
      }

      protected void ProcessNestedLevel1G129( )
      {
         nGXsfl_129_idx = 0;
         while ( nGXsfl_129_idx < bcPublicaciones.gxTpr_Multimedia.Count )
         {
            ReadRow1G129( ) ;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( Gx_mode)) )
            {
               if ( RcdFound129 == 0 )
               {
                  Gx_mode = "INS";
               }
               else
               {
                  Gx_mode = "UPD";
               }
            }
            if ( ! IsIns( ) || ( nIsMod_129 != 0 ) )
            {
               standaloneNotModal1G129( ) ;
               if ( IsIns( ) )
               {
                  Gx_mode = "INS";
                  Insert1G129( ) ;
               }
               else
               {
                  if ( IsDlt( ) )
                  {
                     Gx_mode = "DLT";
                     Delete1G129( ) ;
                  }
                  else
                  {
                     Gx_mode = "UPD";
                     Update1G129( ) ;
                  }
               }
            }
            KeyVarsToRow129( ((SdtPublicaciones_Multimedia)bcPublicaciones.gxTpr_Multimedia.Item(nGXsfl_129_idx))) ;
         }
         if ( AnyError == 0 )
         {
            /* Batch update SDT rows */
            nGXsfl_129_idx = 0;
            while ( nGXsfl_129_idx < bcPublicaciones.gxTpr_Multimedia.Count )
            {
               ReadRow1G129( ) ;
               if ( String.IsNullOrEmpty(StringUtil.RTrim( Gx_mode)) )
               {
                  if ( RcdFound129 == 0 )
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
                  bcPublicaciones.gxTpr_Multimedia.RemoveElement(nGXsfl_129_idx);
                  nGXsfl_129_idx = (int)(nGXsfl_129_idx-1);
               }
               else
               {
                  Gx_mode = "UPD";
                  getByPrimaryKey1G129( ) ;
                  VarsToRow129( ((SdtPublicaciones_Multimedia)bcPublicaciones.gxTpr_Multimedia.Item(nGXsfl_129_idx))) ;
               }
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
         InitAll1G129( ) ;
         if ( AnyError != 0 )
         {
         }
         nRcdExists_129 = 0;
         nIsMod_129 = 0;
      }

      protected void ProcessLevel1G127( )
      {
         /* Save parent mode. */
         sMode127 = Gx_mode;
         ProcessNestedLevel1G128( ) ;
         ProcessNestedLevel1G129( ) ;
         if ( AnyError != 0 )
         {
         }
         /* Restore parent mode. */
         Gx_mode = sMode127;
         /* ' Update level parameters */
      }

      protected void EndLevel1G127( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(4);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete1G127( ) ;
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

      public void ScanKeyStart1G127( )
      {
         /* Scan By routine */
         /* Using cursor BC001G16 */
         pr_default.execute(14, new Object[] {A381PublicacionesId});
         RcdFound127 = 0;
         if ( (pr_default.getStatus(14) != 101) )
         {
            RcdFound127 = 1;
            A381PublicacionesId = BC001G16_A381PublicacionesId[0];
            A382PublicacionesTitulo = BC001G16_A382PublicacionesTitulo[0];
            A383PublicacionesDescripcion = BC001G16_A383PublicacionesDescripcion[0];
            A843PublicacionesFecTentInicio = BC001G16_A843PublicacionesFecTentInicio[0];
            A844PublicacionesFecRealInicio = BC001G16_A844PublicacionesFecRealInicio[0];
            A845PublicacionesFecFinPostulacion = BC001G16_A845PublicacionesFecFinPostulacion[0];
            A846PublicacionesDetalleMateriales = BC001G16_A846PublicacionesDetalleMateriales[0];
            A847PublicacionesFecVisita = BC001G16_A847PublicacionesFecVisita[0];
            A848PublicacionesHoraVisita = BC001G16_A848PublicacionesHoraVisita[0];
            A849PublicacionesDirVisita = BC001G16_A849PublicacionesDirVisita[0];
            A850PublicacionesCondiciones = BC001G16_A850PublicacionesCondiciones[0];
            A851PublicacionesTipoDesembolso = BC001G16_A851PublicacionesTipoDesembolso[0];
            A859PublicacionesOtroTipoDes = BC001G16_A859PublicacionesOtroTipoDes[0];
            A852PublicacionesModalidad = BC001G16_A852PublicacionesModalidad[0];
            A389PublicacionesPrecio = BC001G16_A389PublicacionesPrecio[0];
            A119MonedaISOSimbolo = BC001G16_A119MonedaISOSimbolo[0];
            A854PublicacionesFecCierre = BC001G16_A854PublicacionesFecCierre[0];
            A855PublicacionesDocReq = BC001G16_A855PublicacionesDocReq[0];
            A856PublicacionesDocDescripcion = BC001G16_A856PublicacionesDocDescripcion[0];
            A857PublicacionesTipoEmpresa = BC001G16_A857PublicacionesTipoEmpresa[0];
            A858PublicacionesContratoId = BC001G16_A858PublicacionesContratoId[0];
            A860PublicacionesTerminoObra = BC001G16_A860PublicacionesTerminoObra[0];
            A384PublicacionesEstado = BC001G16_A384PublicacionesEstado[0];
            A385PublicacionesSerialIma = BC001G16_A385PublicacionesSerialIma[0];
            A395PublicacionesSerialRem = BC001G16_A395PublicacionesSerialRem[0];
            A112DepartamentoId = BC001G16_A112DepartamentoId[0];
            A114DepartamentoMunicipioId = BC001G16_A114DepartamentoMunicipioId[0];
            A118MonedaId = BC001G16_A118MonedaId[0];
            n118MonedaId = BC001G16_n118MonedaId[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext1G127( )
      {
         /* Scan next routine */
         pr_default.readNext(14);
         RcdFound127 = 0;
         ScanKeyLoad1G127( ) ;
      }

      protected void ScanKeyLoad1G127( )
      {
         sMode127 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(14) != 101) )
         {
            RcdFound127 = 1;
            A381PublicacionesId = BC001G16_A381PublicacionesId[0];
            A382PublicacionesTitulo = BC001G16_A382PublicacionesTitulo[0];
            A383PublicacionesDescripcion = BC001G16_A383PublicacionesDescripcion[0];
            A843PublicacionesFecTentInicio = BC001G16_A843PublicacionesFecTentInicio[0];
            A844PublicacionesFecRealInicio = BC001G16_A844PublicacionesFecRealInicio[0];
            A845PublicacionesFecFinPostulacion = BC001G16_A845PublicacionesFecFinPostulacion[0];
            A846PublicacionesDetalleMateriales = BC001G16_A846PublicacionesDetalleMateriales[0];
            A847PublicacionesFecVisita = BC001G16_A847PublicacionesFecVisita[0];
            A848PublicacionesHoraVisita = BC001G16_A848PublicacionesHoraVisita[0];
            A849PublicacionesDirVisita = BC001G16_A849PublicacionesDirVisita[0];
            A850PublicacionesCondiciones = BC001G16_A850PublicacionesCondiciones[0];
            A851PublicacionesTipoDesembolso = BC001G16_A851PublicacionesTipoDesembolso[0];
            A859PublicacionesOtroTipoDes = BC001G16_A859PublicacionesOtroTipoDes[0];
            A852PublicacionesModalidad = BC001G16_A852PublicacionesModalidad[0];
            A389PublicacionesPrecio = BC001G16_A389PublicacionesPrecio[0];
            A119MonedaISOSimbolo = BC001G16_A119MonedaISOSimbolo[0];
            A854PublicacionesFecCierre = BC001G16_A854PublicacionesFecCierre[0];
            A855PublicacionesDocReq = BC001G16_A855PublicacionesDocReq[0];
            A856PublicacionesDocDescripcion = BC001G16_A856PublicacionesDocDescripcion[0];
            A857PublicacionesTipoEmpresa = BC001G16_A857PublicacionesTipoEmpresa[0];
            A858PublicacionesContratoId = BC001G16_A858PublicacionesContratoId[0];
            A860PublicacionesTerminoObra = BC001G16_A860PublicacionesTerminoObra[0];
            A384PublicacionesEstado = BC001G16_A384PublicacionesEstado[0];
            A385PublicacionesSerialIma = BC001G16_A385PublicacionesSerialIma[0];
            A395PublicacionesSerialRem = BC001G16_A395PublicacionesSerialRem[0];
            A112DepartamentoId = BC001G16_A112DepartamentoId[0];
            A114DepartamentoMunicipioId = BC001G16_A114DepartamentoMunicipioId[0];
            A118MonedaId = BC001G16_A118MonedaId[0];
            n118MonedaId = BC001G16_n118MonedaId[0];
         }
         Gx_mode = sMode127;
      }

      protected void ScanKeyEnd1G127( )
      {
         pr_default.close(14);
      }

      protected void AfterConfirm1G127( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert1G127( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate1G127( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete1G127( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete1G127( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate1G127( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes1G127( )
      {
      }

      protected void ZM1G128( short GX_JID )
      {
         if ( ( GX_JID == 10 ) || ( GX_JID == 0 ) )
         {
            Z387PublicacionesDoc = A387PublicacionesDoc;
            Z388PublicacionesDocDescrip = A388PublicacionesDocDescrip;
         }
         if ( GX_JID == -10 )
         {
            Z381PublicacionesId = A381PublicacionesId;
            Z386PublicacionesDocId = A386PublicacionesDocId;
            Z387PublicacionesDoc = A387PublicacionesDoc;
            Z388PublicacionesDocDescrip = A388PublicacionesDocDescrip;
         }
      }

      protected void standaloneNotModal1G128( )
      {
      }

      protected void standaloneModal1G128( )
      {
      }

      protected void Load1G128( )
      {
         /* Using cursor BC001G17 */
         pr_default.execute(15, new Object[] {A381PublicacionesId, A386PublicacionesDocId});
         if ( (pr_default.getStatus(15) != 101) )
         {
            RcdFound128 = 1;
            A387PublicacionesDoc = BC001G17_A387PublicacionesDoc[0];
            A388PublicacionesDocDescrip = BC001G17_A388PublicacionesDocDescrip[0];
            ZM1G128( -10) ;
         }
         pr_default.close(15);
         OnLoadActions1G128( ) ;
      }

      protected void OnLoadActions1G128( )
      {
      }

      protected void CheckExtendedTable1G128( )
      {
         Gx_BScreen = 1;
         standaloneModal1G128( ) ;
         Gx_BScreen = 0;
      }

      protected void CloseExtendedTableCursors1G128( )
      {
      }

      protected void enableDisable1G128( )
      {
      }

      protected void GetKey1G128( )
      {
         /* Using cursor BC001G18 */
         pr_default.execute(16, new Object[] {A381PublicacionesId, A386PublicacionesDocId});
         if ( (pr_default.getStatus(16) != 101) )
         {
            RcdFound128 = 1;
         }
         else
         {
            RcdFound128 = 0;
         }
         pr_default.close(16);
      }

      protected void getByPrimaryKey1G128( )
      {
         /* Using cursor BC001G5 */
         pr_default.execute(3, new Object[] {A381PublicacionesId, A386PublicacionesDocId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            ZM1G128( 10) ;
            RcdFound128 = 1;
            InitializeNonKey1G128( ) ;
            A386PublicacionesDocId = BC001G5_A386PublicacionesDocId[0];
            A387PublicacionesDoc = BC001G5_A387PublicacionesDoc[0];
            A388PublicacionesDocDescrip = BC001G5_A388PublicacionesDocDescrip[0];
            Z381PublicacionesId = A381PublicacionesId;
            Z386PublicacionesDocId = A386PublicacionesDocId;
            sMode128 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal1G128( ) ;
            Load1G128( ) ;
            Gx_mode = sMode128;
         }
         else
         {
            RcdFound128 = 0;
            InitializeNonKey1G128( ) ;
            sMode128 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal1G128( ) ;
            Gx_mode = sMode128;
         }
         if ( IsDsp( ) || IsDlt( ) )
         {
            DisableAttributes1G128( ) ;
         }
         pr_default.close(3);
      }

      protected void CheckOptimisticConcurrency1G128( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC001G4 */
            pr_default.execute(2, new Object[] {A381PublicacionesId, A386PublicacionesDocId});
            if ( (pr_default.getStatus(2) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"PublicacionesDocumento"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(2) == 101) || ( StringUtil.StrCmp(Z387PublicacionesDoc, BC001G4_A387PublicacionesDoc[0]) != 0 ) || ( StringUtil.StrCmp(Z388PublicacionesDocDescrip, BC001G4_A388PublicacionesDocDescrip[0]) != 0 ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"PublicacionesDocumento"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert1G128( )
      {
         BeforeValidate1G128( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1G128( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM1G128( 0) ;
            CheckOptimisticConcurrency1G128( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1G128( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert1G128( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC001G19 */
                     pr_default.execute(17, new Object[] {A381PublicacionesId, A386PublicacionesDocId, A387PublicacionesDoc, A388PublicacionesDocDescrip});
                     pr_default.close(17);
                     pr_default.SmartCacheProvider.SetUpdated("PublicacionesDocumento");
                     if ( (pr_default.getStatus(17) == 1) )
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
               Load1G128( ) ;
            }
            EndLevel1G128( ) ;
         }
         CloseExtendedTableCursors1G128( ) ;
      }

      protected void Update1G128( )
      {
         BeforeValidate1G128( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1G128( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1G128( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1G128( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate1G128( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC001G20 */
                     pr_default.execute(18, new Object[] {A387PublicacionesDoc, A388PublicacionesDocDescrip, A381PublicacionesId, A386PublicacionesDocId});
                     pr_default.close(18);
                     pr_default.SmartCacheProvider.SetUpdated("PublicacionesDocumento");
                     if ( (pr_default.getStatus(18) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"PublicacionesDocumento"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate1G128( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey1G128( ) ;
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
            EndLevel1G128( ) ;
         }
         CloseExtendedTableCursors1G128( ) ;
      }

      protected void DeferredUpdate1G128( )
      {
      }

      protected void Delete1G128( )
      {
         Gx_mode = "DLT";
         BeforeValidate1G128( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1G128( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls1G128( ) ;
            AfterConfirm1G128( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete1G128( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC001G21 */
                  pr_default.execute(19, new Object[] {A381PublicacionesId, A386PublicacionesDocId});
                  pr_default.close(19);
                  pr_default.SmartCacheProvider.SetUpdated("PublicacionesDocumento");
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
         sMode128 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel1G128( ) ;
         Gx_mode = sMode128;
      }

      protected void OnDeleteControls1G128( )
      {
         standaloneModal1G128( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel1G128( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(2);
         }
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanKeyStart1G128( )
      {
         /* Scan By routine */
         /* Using cursor BC001G22 */
         pr_default.execute(20, new Object[] {A381PublicacionesId});
         RcdFound128 = 0;
         if ( (pr_default.getStatus(20) != 101) )
         {
            RcdFound128 = 1;
            A386PublicacionesDocId = BC001G22_A386PublicacionesDocId[0];
            A387PublicacionesDoc = BC001G22_A387PublicacionesDoc[0];
            A388PublicacionesDocDescrip = BC001G22_A388PublicacionesDocDescrip[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext1G128( )
      {
         /* Scan next routine */
         pr_default.readNext(20);
         RcdFound128 = 0;
         ScanKeyLoad1G128( ) ;
      }

      protected void ScanKeyLoad1G128( )
      {
         sMode128 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(20) != 101) )
         {
            RcdFound128 = 1;
            A386PublicacionesDocId = BC001G22_A386PublicacionesDocId[0];
            A387PublicacionesDoc = BC001G22_A387PublicacionesDoc[0];
            A388PublicacionesDocDescrip = BC001G22_A388PublicacionesDocDescrip[0];
         }
         Gx_mode = sMode128;
      }

      protected void ScanKeyEnd1G128( )
      {
         pr_default.close(20);
      }

      protected void AfterConfirm1G128( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert1G128( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate1G128( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete1G128( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete1G128( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate1G128( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes1G128( )
      {
      }

      protected void send_integrity_lvl_hashes1G128( )
      {
      }

      protected void ZM1G129( short GX_JID )
      {
         if ( ( GX_JID == 11 ) || ( GX_JID == 0 ) )
         {
            Z392PublicacionesMult = A392PublicacionesMult;
            Z861PublicacionesMultDescrip = A861PublicacionesMultDescrip;
         }
         if ( GX_JID == -11 )
         {
            Z381PublicacionesId = A381PublicacionesId;
            Z394PublicacionesMultId = A394PublicacionesMultId;
            Z392PublicacionesMult = A392PublicacionesMult;
            Z861PublicacionesMultDescrip = A861PublicacionesMultDescrip;
         }
      }

      protected void standaloneNotModal1G129( )
      {
      }

      protected void standaloneModal1G129( )
      {
      }

      protected void Load1G129( )
      {
         /* Using cursor BC001G23 */
         pr_default.execute(21, new Object[] {A381PublicacionesId, A394PublicacionesMultId});
         if ( (pr_default.getStatus(21) != 101) )
         {
            RcdFound129 = 1;
            A392PublicacionesMult = BC001G23_A392PublicacionesMult[0];
            A861PublicacionesMultDescrip = BC001G23_A861PublicacionesMultDescrip[0];
            ZM1G129( -11) ;
         }
         pr_default.close(21);
         OnLoadActions1G129( ) ;
      }

      protected void OnLoadActions1G129( )
      {
      }

      protected void CheckExtendedTable1G129( )
      {
         Gx_BScreen = 1;
         standaloneModal1G129( ) ;
         Gx_BScreen = 0;
      }

      protected void CloseExtendedTableCursors1G129( )
      {
      }

      protected void enableDisable1G129( )
      {
      }

      protected void GetKey1G129( )
      {
         /* Using cursor BC001G24 */
         pr_default.execute(22, new Object[] {A381PublicacionesId, A394PublicacionesMultId});
         if ( (pr_default.getStatus(22) != 101) )
         {
            RcdFound129 = 1;
         }
         else
         {
            RcdFound129 = 0;
         }
         pr_default.close(22);
      }

      protected void getByPrimaryKey1G129( )
      {
         /* Using cursor BC001G3 */
         pr_default.execute(1, new Object[] {A381PublicacionesId, A394PublicacionesMultId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM1G129( 11) ;
            RcdFound129 = 1;
            InitializeNonKey1G129( ) ;
            A394PublicacionesMultId = BC001G3_A394PublicacionesMultId[0];
            A392PublicacionesMult = BC001G3_A392PublicacionesMult[0];
            A861PublicacionesMultDescrip = BC001G3_A861PublicacionesMultDescrip[0];
            Z381PublicacionesId = A381PublicacionesId;
            Z394PublicacionesMultId = A394PublicacionesMultId;
            sMode129 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal1G129( ) ;
            Load1G129( ) ;
            Gx_mode = sMode129;
         }
         else
         {
            RcdFound129 = 0;
            InitializeNonKey1G129( ) ;
            sMode129 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal1G129( ) ;
            Gx_mode = sMode129;
         }
         if ( IsDsp( ) || IsDlt( ) )
         {
            DisableAttributes1G129( ) ;
         }
         pr_default.close(1);
      }

      protected void CheckOptimisticConcurrency1G129( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC001G2 */
            pr_default.execute(0, new Object[] {A381PublicacionesId, A394PublicacionesMultId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"PublicacionesMultimedia"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z392PublicacionesMult, BC001G2_A392PublicacionesMult[0]) != 0 ) || ( StringUtil.StrCmp(Z861PublicacionesMultDescrip, BC001G2_A861PublicacionesMultDescrip[0]) != 0 ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"PublicacionesMultimedia"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert1G129( )
      {
         BeforeValidate1G129( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1G129( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM1G129( 0) ;
            CheckOptimisticConcurrency1G129( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1G129( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert1G129( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC001G25 */
                     pr_default.execute(23, new Object[] {A381PublicacionesId, A394PublicacionesMultId, A392PublicacionesMult, A861PublicacionesMultDescrip});
                     pr_default.close(23);
                     pr_default.SmartCacheProvider.SetUpdated("PublicacionesMultimedia");
                     if ( (pr_default.getStatus(23) == 1) )
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
               Load1G129( ) ;
            }
            EndLevel1G129( ) ;
         }
         CloseExtendedTableCursors1G129( ) ;
      }

      protected void Update1G129( )
      {
         BeforeValidate1G129( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1G129( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1G129( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1G129( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate1G129( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC001G26 */
                     pr_default.execute(24, new Object[] {A392PublicacionesMult, A861PublicacionesMultDescrip, A381PublicacionesId, A394PublicacionesMultId});
                     pr_default.close(24);
                     pr_default.SmartCacheProvider.SetUpdated("PublicacionesMultimedia");
                     if ( (pr_default.getStatus(24) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"PublicacionesMultimedia"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate1G129( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey1G129( ) ;
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
            EndLevel1G129( ) ;
         }
         CloseExtendedTableCursors1G129( ) ;
      }

      protected void DeferredUpdate1G129( )
      {
      }

      protected void Delete1G129( )
      {
         Gx_mode = "DLT";
         BeforeValidate1G129( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1G129( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls1G129( ) ;
            AfterConfirm1G129( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete1G129( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC001G27 */
                  pr_default.execute(25, new Object[] {A381PublicacionesId, A394PublicacionesMultId});
                  pr_default.close(25);
                  pr_default.SmartCacheProvider.SetUpdated("PublicacionesMultimedia");
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
         sMode129 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel1G129( ) ;
         Gx_mode = sMode129;
      }

      protected void OnDeleteControls1G129( )
      {
         standaloneModal1G129( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel1G129( )
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

      public void ScanKeyStart1G129( )
      {
         /* Scan By routine */
         /* Using cursor BC001G28 */
         pr_default.execute(26, new Object[] {A381PublicacionesId});
         RcdFound129 = 0;
         if ( (pr_default.getStatus(26) != 101) )
         {
            RcdFound129 = 1;
            A394PublicacionesMultId = BC001G28_A394PublicacionesMultId[0];
            A392PublicacionesMult = BC001G28_A392PublicacionesMult[0];
            A861PublicacionesMultDescrip = BC001G28_A861PublicacionesMultDescrip[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext1G129( )
      {
         /* Scan next routine */
         pr_default.readNext(26);
         RcdFound129 = 0;
         ScanKeyLoad1G129( ) ;
      }

      protected void ScanKeyLoad1G129( )
      {
         sMode129 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(26) != 101) )
         {
            RcdFound129 = 1;
            A394PublicacionesMultId = BC001G28_A394PublicacionesMultId[0];
            A392PublicacionesMult = BC001G28_A392PublicacionesMult[0];
            A861PublicacionesMultDescrip = BC001G28_A861PublicacionesMultDescrip[0];
         }
         Gx_mode = sMode129;
      }

      protected void ScanKeyEnd1G129( )
      {
         pr_default.close(26);
      }

      protected void AfterConfirm1G129( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert1G129( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate1G129( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete1G129( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete1G129( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate1G129( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes1G129( )
      {
      }

      protected void send_integrity_lvl_hashes1G129( )
      {
      }

      protected void send_integrity_lvl_hashes1G127( )
      {
      }

      protected void AddRow1G127( )
      {
         VarsToRow127( bcPublicaciones) ;
      }

      protected void ReadRow1G127( )
      {
         RowToVars127( bcPublicaciones, 1) ;
      }

      protected void AddRow1G128( )
      {
         SdtPublicaciones_Documento obj128;
         obj128 = new SdtPublicaciones_Documento(context);
         VarsToRow128( obj128) ;
         bcPublicaciones.gxTpr_Documento.Add(obj128, 0);
         obj128.gxTpr_Mode = "UPD";
         obj128.gxTpr_Modified = 0;
      }

      protected void ReadRow1G128( )
      {
         nGXsfl_128_idx = (int)(nGXsfl_128_idx+1);
         RowToVars128( ((SdtPublicaciones_Documento)bcPublicaciones.gxTpr_Documento.Item(nGXsfl_128_idx)), 1) ;
      }

      protected void AddRow1G129( )
      {
         SdtPublicaciones_Multimedia obj129;
         obj129 = new SdtPublicaciones_Multimedia(context);
         VarsToRow129( obj129) ;
         bcPublicaciones.gxTpr_Multimedia.Add(obj129, 0);
         obj129.gxTpr_Mode = "UPD";
         obj129.gxTpr_Modified = 0;
      }

      protected void ReadRow1G129( )
      {
         nGXsfl_129_idx = (int)(nGXsfl_129_idx+1);
         RowToVars129( ((SdtPublicaciones_Multimedia)bcPublicaciones.gxTpr_Multimedia.Item(nGXsfl_129_idx)), 1) ;
      }

      protected void InitializeNonKey1G127( )
      {
         A118MonedaId = 0;
         n118MonedaId = false;
         A382PublicacionesTitulo = "";
         A383PublicacionesDescripcion = "";
         A112DepartamentoId = 0;
         A114DepartamentoMunicipioId = 0;
         A843PublicacionesFecTentInicio = DateTime.MinValue;
         A844PublicacionesFecRealInicio = DateTime.MinValue;
         A845PublicacionesFecFinPostulacion = DateTime.MinValue;
         A846PublicacionesDetalleMateriales = "";
         A847PublicacionesFecVisita = DateTime.MinValue;
         A848PublicacionesHoraVisita = "";
         A849PublicacionesDirVisita = "";
         A850PublicacionesCondiciones = "";
         A851PublicacionesTipoDesembolso = "";
         A859PublicacionesOtroTipoDes = "";
         A852PublicacionesModalidad = "";
         A389PublicacionesPrecio = 0;
         A119MonedaISOSimbolo = "";
         A854PublicacionesFecCierre = DateTime.MinValue;
         A855PublicacionesDocReq = "";
         A856PublicacionesDocDescripcion = "";
         A857PublicacionesTipoEmpresa = "";
         A858PublicacionesContratoId = "";
         A860PublicacionesTerminoObra = "";
         A384PublicacionesEstado = "";
         A385PublicacionesSerialIma = 0;
         A395PublicacionesSerialRem = 0;
         Z382PublicacionesTitulo = "";
         Z843PublicacionesFecTentInicio = DateTime.MinValue;
         Z844PublicacionesFecRealInicio = DateTime.MinValue;
         Z845PublicacionesFecFinPostulacion = DateTime.MinValue;
         Z846PublicacionesDetalleMateriales = "";
         Z847PublicacionesFecVisita = DateTime.MinValue;
         Z848PublicacionesHoraVisita = "";
         Z849PublicacionesDirVisita = "";
         Z850PublicacionesCondiciones = "";
         Z851PublicacionesTipoDesembolso = "";
         Z859PublicacionesOtroTipoDes = "";
         Z852PublicacionesModalidad = "";
         Z389PublicacionesPrecio = 0;
         Z854PublicacionesFecCierre = DateTime.MinValue;
         Z855PublicacionesDocReq = "";
         Z856PublicacionesDocDescripcion = "";
         Z857PublicacionesTipoEmpresa = "";
         Z858PublicacionesContratoId = "";
         Z860PublicacionesTerminoObra = "";
         Z384PublicacionesEstado = "";
         Z385PublicacionesSerialIma = 0;
         Z395PublicacionesSerialRem = 0;
         Z112DepartamentoId = 0;
         Z114DepartamentoMunicipioId = 0;
         Z118MonedaId = 0;
      }

      protected void InitAll1G127( )
      {
         A381PublicacionesId = 0;
         InitializeNonKey1G127( ) ;
      }

      protected void StandaloneModalInsert( )
      {
      }

      protected void InitializeNonKey1G128( )
      {
         A387PublicacionesDoc = "";
         A388PublicacionesDocDescrip = "";
         Z387PublicacionesDoc = "";
         Z388PublicacionesDocDescrip = "";
      }

      protected void InitAll1G128( )
      {
         A386PublicacionesDocId = 0;
         InitializeNonKey1G128( ) ;
      }

      protected void StandaloneModalInsert1G128( )
      {
      }

      protected void InitializeNonKey1G129( )
      {
         A392PublicacionesMult = "";
         A861PublicacionesMultDescrip = "";
         Z392PublicacionesMult = "";
         Z861PublicacionesMultDescrip = "";
      }

      protected void InitAll1G129( )
      {
         A394PublicacionesMultId = 0;
         InitializeNonKey1G129( ) ;
      }

      protected void StandaloneModalInsert1G129( )
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

      public void VarsToRow127( SdtPublicaciones obj127 )
      {
         obj127.gxTpr_Mode = Gx_mode;
         obj127.gxTpr_Monedaid = A118MonedaId;
         obj127.gxTpr_Publicacionestitulo = A382PublicacionesTitulo;
         obj127.gxTpr_Publicacionesdescripcion = A383PublicacionesDescripcion;
         obj127.gxTpr_Departamentoid = A112DepartamentoId;
         obj127.gxTpr_Departamentomunicipioid = A114DepartamentoMunicipioId;
         obj127.gxTpr_Publicacionesfectentinicio = A843PublicacionesFecTentInicio;
         obj127.gxTpr_Publicacionesfecrealinicio = A844PublicacionesFecRealInicio;
         obj127.gxTpr_Publicacionesfecfinpostulacion = A845PublicacionesFecFinPostulacion;
         obj127.gxTpr_Publicacionesdetallemateriales = A846PublicacionesDetalleMateriales;
         obj127.gxTpr_Publicacionesfecvisita = A847PublicacionesFecVisita;
         obj127.gxTpr_Publicacioneshoravisita = A848PublicacionesHoraVisita;
         obj127.gxTpr_Publicacionesdirvisita = A849PublicacionesDirVisita;
         obj127.gxTpr_Publicacionescondiciones = A850PublicacionesCondiciones;
         obj127.gxTpr_Publicacionestipodesembolso = A851PublicacionesTipoDesembolso;
         obj127.gxTpr_Publicacionesotrotipodes = A859PublicacionesOtroTipoDes;
         obj127.gxTpr_Publicacionesmodalidad = A852PublicacionesModalidad;
         obj127.gxTpr_Publicacionesprecio = A389PublicacionesPrecio;
         obj127.gxTpr_Monedaisosimbolo = A119MonedaISOSimbolo;
         obj127.gxTpr_Publicacionesfeccierre = A854PublicacionesFecCierre;
         obj127.gxTpr_Publicacionesdocreq = A855PublicacionesDocReq;
         obj127.gxTpr_Publicacionesdocdescripcion = A856PublicacionesDocDescripcion;
         obj127.gxTpr_Publicacionestipoempresa = A857PublicacionesTipoEmpresa;
         obj127.gxTpr_Publicacionescontratoid = A858PublicacionesContratoId;
         obj127.gxTpr_Publicacionesterminoobra = A860PublicacionesTerminoObra;
         obj127.gxTpr_Publicacionesestado = A384PublicacionesEstado;
         obj127.gxTpr_Publicacionesserialima = A385PublicacionesSerialIma;
         obj127.gxTpr_Publicacionesserialrem = A395PublicacionesSerialRem;
         obj127.gxTpr_Publicacionesid = A381PublicacionesId;
         obj127.gxTpr_Publicacionesid_Z = Z381PublicacionesId;
         obj127.gxTpr_Publicacionestitulo_Z = Z382PublicacionesTitulo;
         obj127.gxTpr_Departamentoid_Z = Z112DepartamentoId;
         obj127.gxTpr_Departamentomunicipioid_Z = Z114DepartamentoMunicipioId;
         obj127.gxTpr_Publicacionesfectentinicio_Z = Z843PublicacionesFecTentInicio;
         obj127.gxTpr_Publicacionesfecrealinicio_Z = Z844PublicacionesFecRealInicio;
         obj127.gxTpr_Publicacionesfecfinpostulacion_Z = Z845PublicacionesFecFinPostulacion;
         obj127.gxTpr_Publicacionesdetallemateriales_Z = Z846PublicacionesDetalleMateriales;
         obj127.gxTpr_Publicacionesfecvisita_Z = Z847PublicacionesFecVisita;
         obj127.gxTpr_Publicacioneshoravisita_Z = Z848PublicacionesHoraVisita;
         obj127.gxTpr_Publicacionesdirvisita_Z = Z849PublicacionesDirVisita;
         obj127.gxTpr_Publicacionescondiciones_Z = Z850PublicacionesCondiciones;
         obj127.gxTpr_Publicacionestipodesembolso_Z = Z851PublicacionesTipoDesembolso;
         obj127.gxTpr_Publicacionesotrotipodes_Z = Z859PublicacionesOtroTipoDes;
         obj127.gxTpr_Publicacionesmodalidad_Z = Z852PublicacionesModalidad;
         obj127.gxTpr_Publicacionesprecio_Z = Z389PublicacionesPrecio;
         obj127.gxTpr_Monedaid_Z = Z118MonedaId;
         obj127.gxTpr_Monedaisosimbolo_Z = Z119MonedaISOSimbolo;
         obj127.gxTpr_Publicacionesfeccierre_Z = Z854PublicacionesFecCierre;
         obj127.gxTpr_Publicacionesdocreq_Z = Z855PublicacionesDocReq;
         obj127.gxTpr_Publicacionesdocdescripcion_Z = Z856PublicacionesDocDescripcion;
         obj127.gxTpr_Publicacionestipoempresa_Z = Z857PublicacionesTipoEmpresa;
         obj127.gxTpr_Publicacionescontratoid_Z = Z858PublicacionesContratoId;
         obj127.gxTpr_Publicacionesterminoobra_Z = Z860PublicacionesTerminoObra;
         obj127.gxTpr_Publicacionesestado_Z = Z384PublicacionesEstado;
         obj127.gxTpr_Publicacionesserialima_Z = Z385PublicacionesSerialIma;
         obj127.gxTpr_Publicacionesserialrem_Z = Z395PublicacionesSerialRem;
         obj127.gxTpr_Monedaid_N = (short)(Convert.ToInt16(n118MonedaId));
         obj127.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow127( SdtPublicaciones obj127 )
      {
         obj127.gxTpr_Publicacionesid = A381PublicacionesId;
         return  ;
      }

      public void RowToVars127( SdtPublicaciones obj127 ,
                                int forceLoad )
      {
         Gx_mode = obj127.gxTpr_Mode;
         A118MonedaId = obj127.gxTpr_Monedaid;
         n118MonedaId = false;
         A382PublicacionesTitulo = obj127.gxTpr_Publicacionestitulo;
         A383PublicacionesDescripcion = obj127.gxTpr_Publicacionesdescripcion;
         A112DepartamentoId = obj127.gxTpr_Departamentoid;
         A114DepartamentoMunicipioId = obj127.gxTpr_Departamentomunicipioid;
         A843PublicacionesFecTentInicio = obj127.gxTpr_Publicacionesfectentinicio;
         A844PublicacionesFecRealInicio = obj127.gxTpr_Publicacionesfecrealinicio;
         A845PublicacionesFecFinPostulacion = obj127.gxTpr_Publicacionesfecfinpostulacion;
         A846PublicacionesDetalleMateriales = obj127.gxTpr_Publicacionesdetallemateriales;
         A847PublicacionesFecVisita = obj127.gxTpr_Publicacionesfecvisita;
         A848PublicacionesHoraVisita = obj127.gxTpr_Publicacioneshoravisita;
         A849PublicacionesDirVisita = obj127.gxTpr_Publicacionesdirvisita;
         A850PublicacionesCondiciones = obj127.gxTpr_Publicacionescondiciones;
         A851PublicacionesTipoDesembolso = obj127.gxTpr_Publicacionestipodesembolso;
         A859PublicacionesOtroTipoDes = obj127.gxTpr_Publicacionesotrotipodes;
         A852PublicacionesModalidad = obj127.gxTpr_Publicacionesmodalidad;
         A389PublicacionesPrecio = obj127.gxTpr_Publicacionesprecio;
         A119MonedaISOSimbolo = obj127.gxTpr_Monedaisosimbolo;
         A854PublicacionesFecCierre = obj127.gxTpr_Publicacionesfeccierre;
         A855PublicacionesDocReq = obj127.gxTpr_Publicacionesdocreq;
         A856PublicacionesDocDescripcion = obj127.gxTpr_Publicacionesdocdescripcion;
         A857PublicacionesTipoEmpresa = obj127.gxTpr_Publicacionestipoempresa;
         A858PublicacionesContratoId = obj127.gxTpr_Publicacionescontratoid;
         A860PublicacionesTerminoObra = obj127.gxTpr_Publicacionesterminoobra;
         A384PublicacionesEstado = obj127.gxTpr_Publicacionesestado;
         A385PublicacionesSerialIma = obj127.gxTpr_Publicacionesserialima;
         A395PublicacionesSerialRem = obj127.gxTpr_Publicacionesserialrem;
         A381PublicacionesId = obj127.gxTpr_Publicacionesid;
         Z381PublicacionesId = obj127.gxTpr_Publicacionesid_Z;
         Z382PublicacionesTitulo = obj127.gxTpr_Publicacionestitulo_Z;
         Z112DepartamentoId = obj127.gxTpr_Departamentoid_Z;
         Z114DepartamentoMunicipioId = obj127.gxTpr_Departamentomunicipioid_Z;
         Z843PublicacionesFecTentInicio = obj127.gxTpr_Publicacionesfectentinicio_Z;
         Z844PublicacionesFecRealInicio = obj127.gxTpr_Publicacionesfecrealinicio_Z;
         Z845PublicacionesFecFinPostulacion = obj127.gxTpr_Publicacionesfecfinpostulacion_Z;
         Z846PublicacionesDetalleMateriales = obj127.gxTpr_Publicacionesdetallemateriales_Z;
         Z847PublicacionesFecVisita = obj127.gxTpr_Publicacionesfecvisita_Z;
         Z848PublicacionesHoraVisita = obj127.gxTpr_Publicacioneshoravisita_Z;
         Z849PublicacionesDirVisita = obj127.gxTpr_Publicacionesdirvisita_Z;
         Z850PublicacionesCondiciones = obj127.gxTpr_Publicacionescondiciones_Z;
         Z851PublicacionesTipoDesembolso = obj127.gxTpr_Publicacionestipodesembolso_Z;
         Z859PublicacionesOtroTipoDes = obj127.gxTpr_Publicacionesotrotipodes_Z;
         Z852PublicacionesModalidad = obj127.gxTpr_Publicacionesmodalidad_Z;
         Z389PublicacionesPrecio = obj127.gxTpr_Publicacionesprecio_Z;
         Z118MonedaId = obj127.gxTpr_Monedaid_Z;
         Z119MonedaISOSimbolo = obj127.gxTpr_Monedaisosimbolo_Z;
         Z854PublicacionesFecCierre = obj127.gxTpr_Publicacionesfeccierre_Z;
         Z855PublicacionesDocReq = obj127.gxTpr_Publicacionesdocreq_Z;
         Z856PublicacionesDocDescripcion = obj127.gxTpr_Publicacionesdocdescripcion_Z;
         Z857PublicacionesTipoEmpresa = obj127.gxTpr_Publicacionestipoempresa_Z;
         Z858PublicacionesContratoId = obj127.gxTpr_Publicacionescontratoid_Z;
         Z860PublicacionesTerminoObra = obj127.gxTpr_Publicacionesterminoobra_Z;
         Z384PublicacionesEstado = obj127.gxTpr_Publicacionesestado_Z;
         Z385PublicacionesSerialIma = obj127.gxTpr_Publicacionesserialima_Z;
         Z395PublicacionesSerialRem = obj127.gxTpr_Publicacionesserialrem_Z;
         n118MonedaId = (bool)(Convert.ToBoolean(obj127.gxTpr_Monedaid_N));
         Gx_mode = obj127.gxTpr_Mode;
         return  ;
      }

      public void VarsToRow128( SdtPublicaciones_Documento obj128 )
      {
         obj128.gxTpr_Mode = Gx_mode;
         obj128.gxTpr_Publicacionesdoc = A387PublicacionesDoc;
         obj128.gxTpr_Publicacionesdocdescrip = A388PublicacionesDocDescrip;
         obj128.gxTpr_Publicacionesdocid = A386PublicacionesDocId;
         obj128.gxTpr_Publicacionesdocid_Z = Z386PublicacionesDocId;
         obj128.gxTpr_Publicacionesdoc_Z = Z387PublicacionesDoc;
         obj128.gxTpr_Publicacionesdocdescrip_Z = Z388PublicacionesDocDescrip;
         obj128.gxTpr_Modified = nIsMod_128;
         return  ;
      }

      public void KeyVarsToRow128( SdtPublicaciones_Documento obj128 )
      {
         obj128.gxTpr_Publicacionesdocid = A386PublicacionesDocId;
         return  ;
      }

      public void RowToVars128( SdtPublicaciones_Documento obj128 ,
                                int forceLoad )
      {
         Gx_mode = obj128.gxTpr_Mode;
         A387PublicacionesDoc = obj128.gxTpr_Publicacionesdoc;
         A388PublicacionesDocDescrip = obj128.gxTpr_Publicacionesdocdescrip;
         A386PublicacionesDocId = obj128.gxTpr_Publicacionesdocid;
         Z386PublicacionesDocId = obj128.gxTpr_Publicacionesdocid_Z;
         Z387PublicacionesDoc = obj128.gxTpr_Publicacionesdoc_Z;
         Z388PublicacionesDocDescrip = obj128.gxTpr_Publicacionesdocdescrip_Z;
         nIsMod_128 = obj128.gxTpr_Modified;
         return  ;
      }

      public void VarsToRow129( SdtPublicaciones_Multimedia obj129 )
      {
         obj129.gxTpr_Mode = Gx_mode;
         obj129.gxTpr_Publicacionesmult = A392PublicacionesMult;
         obj129.gxTpr_Publicacionesmultdescrip = A861PublicacionesMultDescrip;
         obj129.gxTpr_Publicacionesmultid = A394PublicacionesMultId;
         obj129.gxTpr_Publicacionesmultid_Z = Z394PublicacionesMultId;
         obj129.gxTpr_Publicacionesmult_Z = Z392PublicacionesMult;
         obj129.gxTpr_Publicacionesmultdescrip_Z = Z861PublicacionesMultDescrip;
         obj129.gxTpr_Modified = nIsMod_129;
         return  ;
      }

      public void KeyVarsToRow129( SdtPublicaciones_Multimedia obj129 )
      {
         obj129.gxTpr_Publicacionesmultid = A394PublicacionesMultId;
         return  ;
      }

      public void RowToVars129( SdtPublicaciones_Multimedia obj129 ,
                                int forceLoad )
      {
         Gx_mode = obj129.gxTpr_Mode;
         A392PublicacionesMult = obj129.gxTpr_Publicacionesmult;
         A861PublicacionesMultDescrip = obj129.gxTpr_Publicacionesmultdescrip;
         A394PublicacionesMultId = obj129.gxTpr_Publicacionesmultid;
         Z394PublicacionesMultId = obj129.gxTpr_Publicacionesmultid_Z;
         Z392PublicacionesMult = obj129.gxTpr_Publicacionesmult_Z;
         Z861PublicacionesMultDescrip = obj129.gxTpr_Publicacionesmultdescrip_Z;
         nIsMod_129 = obj129.gxTpr_Modified;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A381PublicacionesId = (long)getParm(obj,0);
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey1G127( ) ;
         ScanKeyStart1G127( ) ;
         if ( RcdFound127 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z381PublicacionesId = A381PublicacionesId;
         }
         ZM1G127( -7) ;
         OnLoadActions1G127( ) ;
         AddRow1G127( ) ;
         bcPublicaciones.gxTpr_Documento.ClearCollection();
         if ( RcdFound127 == 1 )
         {
            ScanKeyStart1G128( ) ;
            nGXsfl_128_idx = 1;
            while ( RcdFound128 != 0 )
            {
               Z381PublicacionesId = A381PublicacionesId;
               Z386PublicacionesDocId = A386PublicacionesDocId;
               ZM1G128( -10) ;
               OnLoadActions1G128( ) ;
               nRcdExists_128 = 1;
               nIsMod_128 = 0;
               AddRow1G128( ) ;
               nGXsfl_128_idx = (int)(nGXsfl_128_idx+1);
               ScanKeyNext1G128( ) ;
            }
            ScanKeyEnd1G128( ) ;
         }
         bcPublicaciones.gxTpr_Multimedia.ClearCollection();
         if ( RcdFound127 == 1 )
         {
            ScanKeyStart1G129( ) ;
            nGXsfl_129_idx = 1;
            while ( RcdFound129 != 0 )
            {
               Z381PublicacionesId = A381PublicacionesId;
               Z394PublicacionesMultId = A394PublicacionesMultId;
               ZM1G129( -11) ;
               OnLoadActions1G129( ) ;
               nRcdExists_129 = 1;
               nIsMod_129 = 0;
               AddRow1G129( ) ;
               nGXsfl_129_idx = (int)(nGXsfl_129_idx+1);
               ScanKeyNext1G129( ) ;
            }
            ScanKeyEnd1G129( ) ;
         }
         ScanKeyEnd1G127( ) ;
         if ( RcdFound127 == 0 )
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
         RowToVars127( bcPublicaciones, 0) ;
         ScanKeyStart1G127( ) ;
         if ( RcdFound127 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z381PublicacionesId = A381PublicacionesId;
         }
         ZM1G127( -7) ;
         OnLoadActions1G127( ) ;
         AddRow1G127( ) ;
         bcPublicaciones.gxTpr_Documento.ClearCollection();
         if ( RcdFound127 == 1 )
         {
            ScanKeyStart1G128( ) ;
            nGXsfl_128_idx = 1;
            while ( RcdFound128 != 0 )
            {
               Z381PublicacionesId = A381PublicacionesId;
               Z386PublicacionesDocId = A386PublicacionesDocId;
               ZM1G128( -10) ;
               OnLoadActions1G128( ) ;
               nRcdExists_128 = 1;
               nIsMod_128 = 0;
               AddRow1G128( ) ;
               nGXsfl_128_idx = (int)(nGXsfl_128_idx+1);
               ScanKeyNext1G128( ) ;
            }
            ScanKeyEnd1G128( ) ;
         }
         bcPublicaciones.gxTpr_Multimedia.ClearCollection();
         if ( RcdFound127 == 1 )
         {
            ScanKeyStart1G129( ) ;
            nGXsfl_129_idx = 1;
            while ( RcdFound129 != 0 )
            {
               Z381PublicacionesId = A381PublicacionesId;
               Z394PublicacionesMultId = A394PublicacionesMultId;
               ZM1G129( -11) ;
               OnLoadActions1G129( ) ;
               nRcdExists_129 = 1;
               nIsMod_129 = 0;
               AddRow1G129( ) ;
               nGXsfl_129_idx = (int)(nGXsfl_129_idx+1);
               ScanKeyNext1G129( ) ;
            }
            ScanKeyEnd1G129( ) ;
         }
         ScanKeyEnd1G127( ) ;
         if ( RcdFound127 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         GetKey1G127( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert1G127( ) ;
         }
         else
         {
            if ( RcdFound127 == 1 )
            {
               if ( A381PublicacionesId != Z381PublicacionesId )
               {
                  A381PublicacionesId = Z381PublicacionesId;
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
                  Update1G127( ) ;
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
                  if ( A381PublicacionesId != Z381PublicacionesId )
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
                        Insert1G127( ) ;
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
                        Insert1G127( ) ;
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
         RowToVars127( bcPublicaciones, 1) ;
         SaveImpl( ) ;
         VarsToRow127( bcPublicaciones) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public bool Insert( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars127( bcPublicaciones, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert1G127( ) ;
         AfterTrn( ) ;
         VarsToRow127( bcPublicaciones) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
            VarsToRow127( bcPublicaciones) ;
         }
         else
         {
            SdtPublicaciones auxBC = new SdtPublicaciones(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A381PublicacionesId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcPublicaciones);
               auxBC.Save();
               bcPublicaciones.Copy((GxSilentTrnSdt)(auxBC));
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
         RowToVars127( bcPublicaciones, 1) ;
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
         RowToVars127( bcPublicaciones, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert1G127( ) ;
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
               VarsToRow127( bcPublicaciones) ;
            }
         }
         else
         {
            AfterTrn( ) ;
            VarsToRow127( bcPublicaciones) ;
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
         RowToVars127( bcPublicaciones, 0) ;
         GetKey1G127( ) ;
         if ( RcdFound127 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( A381PublicacionesId != Z381PublicacionesId )
            {
               A381PublicacionesId = Z381PublicacionesId;
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
            if ( A381PublicacionesId != Z381PublicacionesId )
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
         pr_default.close(3);
         pr_default.close(1);
         pr_default.close(13);
         context.RollbackDataStores("publicaciones_bc",pr_default);
         VarsToRow127( bcPublicaciones) ;
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
         Gx_mode = bcPublicaciones.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcPublicaciones.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcPublicaciones )
         {
            bcPublicaciones = (SdtPublicaciones)(sdt);
            if ( StringUtil.StrCmp(bcPublicaciones.gxTpr_Mode, "") == 0 )
            {
               bcPublicaciones.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow127( bcPublicaciones) ;
            }
            else
            {
               RowToVars127( bcPublicaciones, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcPublicaciones.gxTpr_Mode, "") == 0 )
            {
               bcPublicaciones.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars127( bcPublicaciones, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         return  ;
      }

      public SdtPublicaciones Publicaciones_BC
      {
         get {
            return bcPublicaciones ;
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
         pr_default.close(3);
         pr_default.close(5);
         pr_default.close(13);
      }

      public override void initialize( )
      {
         Gx_mode = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         sMode127 = "";
         Z382PublicacionesTitulo = "";
         A382PublicacionesTitulo = "";
         Z843PublicacionesFecTentInicio = DateTime.MinValue;
         A843PublicacionesFecTentInicio = DateTime.MinValue;
         Z844PublicacionesFecRealInicio = DateTime.MinValue;
         A844PublicacionesFecRealInicio = DateTime.MinValue;
         Z845PublicacionesFecFinPostulacion = DateTime.MinValue;
         A845PublicacionesFecFinPostulacion = DateTime.MinValue;
         Z846PublicacionesDetalleMateriales = "";
         A846PublicacionesDetalleMateriales = "";
         Z847PublicacionesFecVisita = DateTime.MinValue;
         A847PublicacionesFecVisita = DateTime.MinValue;
         Z848PublicacionesHoraVisita = "";
         A848PublicacionesHoraVisita = "";
         Z849PublicacionesDirVisita = "";
         A849PublicacionesDirVisita = "";
         Z850PublicacionesCondiciones = "";
         A850PublicacionesCondiciones = "";
         Z851PublicacionesTipoDesembolso = "";
         A851PublicacionesTipoDesembolso = "";
         Z859PublicacionesOtroTipoDes = "";
         A859PublicacionesOtroTipoDes = "";
         Z852PublicacionesModalidad = "";
         A852PublicacionesModalidad = "";
         Z854PublicacionesFecCierre = DateTime.MinValue;
         A854PublicacionesFecCierre = DateTime.MinValue;
         Z855PublicacionesDocReq = "";
         A855PublicacionesDocReq = "";
         Z856PublicacionesDocDescripcion = "";
         A856PublicacionesDocDescripcion = "";
         Z857PublicacionesTipoEmpresa = "";
         A857PublicacionesTipoEmpresa = "";
         Z858PublicacionesContratoId = "";
         A858PublicacionesContratoId = "";
         Z860PublicacionesTerminoObra = "";
         A860PublicacionesTerminoObra = "";
         Z384PublicacionesEstado = "";
         A384PublicacionesEstado = "";
         Z119MonedaISOSimbolo = "";
         A119MonedaISOSimbolo = "";
         Z383PublicacionesDescripcion = "";
         A383PublicacionesDescripcion = "";
         BC001G10_A381PublicacionesId = new long[1] ;
         BC001G10_A382PublicacionesTitulo = new string[] {""} ;
         BC001G10_A383PublicacionesDescripcion = new string[] {""} ;
         BC001G10_A843PublicacionesFecTentInicio = new DateTime[] {DateTime.MinValue} ;
         BC001G10_A844PublicacionesFecRealInicio = new DateTime[] {DateTime.MinValue} ;
         BC001G10_A845PublicacionesFecFinPostulacion = new DateTime[] {DateTime.MinValue} ;
         BC001G10_A846PublicacionesDetalleMateriales = new string[] {""} ;
         BC001G10_A847PublicacionesFecVisita = new DateTime[] {DateTime.MinValue} ;
         BC001G10_A848PublicacionesHoraVisita = new string[] {""} ;
         BC001G10_A849PublicacionesDirVisita = new string[] {""} ;
         BC001G10_A850PublicacionesCondiciones = new string[] {""} ;
         BC001G10_A851PublicacionesTipoDesembolso = new string[] {""} ;
         BC001G10_A859PublicacionesOtroTipoDes = new string[] {""} ;
         BC001G10_A852PublicacionesModalidad = new string[] {""} ;
         BC001G10_A389PublicacionesPrecio = new decimal[1] ;
         BC001G10_A119MonedaISOSimbolo = new string[] {""} ;
         BC001G10_A854PublicacionesFecCierre = new DateTime[] {DateTime.MinValue} ;
         BC001G10_A855PublicacionesDocReq = new string[] {""} ;
         BC001G10_A856PublicacionesDocDescripcion = new string[] {""} ;
         BC001G10_A857PublicacionesTipoEmpresa = new string[] {""} ;
         BC001G10_A858PublicacionesContratoId = new string[] {""} ;
         BC001G10_A860PublicacionesTerminoObra = new string[] {""} ;
         BC001G10_A384PublicacionesEstado = new string[] {""} ;
         BC001G10_A385PublicacionesSerialIma = new short[1] ;
         BC001G10_A395PublicacionesSerialRem = new short[1] ;
         BC001G10_A112DepartamentoId = new long[1] ;
         BC001G10_A114DepartamentoMunicipioId = new long[1] ;
         BC001G10_A118MonedaId = new short[1] ;
         BC001G10_n118MonedaId = new bool[] {false} ;
         BC001G8_A112DepartamentoId = new long[1] ;
         BC001G9_A119MonedaISOSimbolo = new string[] {""} ;
         BC001G11_A381PublicacionesId = new long[1] ;
         BC001G7_A381PublicacionesId = new long[1] ;
         BC001G7_A382PublicacionesTitulo = new string[] {""} ;
         BC001G7_A383PublicacionesDescripcion = new string[] {""} ;
         BC001G7_A843PublicacionesFecTentInicio = new DateTime[] {DateTime.MinValue} ;
         BC001G7_A844PublicacionesFecRealInicio = new DateTime[] {DateTime.MinValue} ;
         BC001G7_A845PublicacionesFecFinPostulacion = new DateTime[] {DateTime.MinValue} ;
         BC001G7_A846PublicacionesDetalleMateriales = new string[] {""} ;
         BC001G7_A847PublicacionesFecVisita = new DateTime[] {DateTime.MinValue} ;
         BC001G7_A848PublicacionesHoraVisita = new string[] {""} ;
         BC001G7_A849PublicacionesDirVisita = new string[] {""} ;
         BC001G7_A850PublicacionesCondiciones = new string[] {""} ;
         BC001G7_A851PublicacionesTipoDesembolso = new string[] {""} ;
         BC001G7_A859PublicacionesOtroTipoDes = new string[] {""} ;
         BC001G7_A852PublicacionesModalidad = new string[] {""} ;
         BC001G7_A389PublicacionesPrecio = new decimal[1] ;
         BC001G7_A854PublicacionesFecCierre = new DateTime[] {DateTime.MinValue} ;
         BC001G7_A855PublicacionesDocReq = new string[] {""} ;
         BC001G7_A856PublicacionesDocDescripcion = new string[] {""} ;
         BC001G7_A857PublicacionesTipoEmpresa = new string[] {""} ;
         BC001G7_A858PublicacionesContratoId = new string[] {""} ;
         BC001G7_A860PublicacionesTerminoObra = new string[] {""} ;
         BC001G7_A384PublicacionesEstado = new string[] {""} ;
         BC001G7_A385PublicacionesSerialIma = new short[1] ;
         BC001G7_A395PublicacionesSerialRem = new short[1] ;
         BC001G7_A112DepartamentoId = new long[1] ;
         BC001G7_A114DepartamentoMunicipioId = new long[1] ;
         BC001G7_A118MonedaId = new short[1] ;
         BC001G7_n118MonedaId = new bool[] {false} ;
         BC001G6_A381PublicacionesId = new long[1] ;
         BC001G6_A382PublicacionesTitulo = new string[] {""} ;
         BC001G6_A383PublicacionesDescripcion = new string[] {""} ;
         BC001G6_A843PublicacionesFecTentInicio = new DateTime[] {DateTime.MinValue} ;
         BC001G6_A844PublicacionesFecRealInicio = new DateTime[] {DateTime.MinValue} ;
         BC001G6_A845PublicacionesFecFinPostulacion = new DateTime[] {DateTime.MinValue} ;
         BC001G6_A846PublicacionesDetalleMateriales = new string[] {""} ;
         BC001G6_A847PublicacionesFecVisita = new DateTime[] {DateTime.MinValue} ;
         BC001G6_A848PublicacionesHoraVisita = new string[] {""} ;
         BC001G6_A849PublicacionesDirVisita = new string[] {""} ;
         BC001G6_A850PublicacionesCondiciones = new string[] {""} ;
         BC001G6_A851PublicacionesTipoDesembolso = new string[] {""} ;
         BC001G6_A859PublicacionesOtroTipoDes = new string[] {""} ;
         BC001G6_A852PublicacionesModalidad = new string[] {""} ;
         BC001G6_A389PublicacionesPrecio = new decimal[1] ;
         BC001G6_A854PublicacionesFecCierre = new DateTime[] {DateTime.MinValue} ;
         BC001G6_A855PublicacionesDocReq = new string[] {""} ;
         BC001G6_A856PublicacionesDocDescripcion = new string[] {""} ;
         BC001G6_A857PublicacionesTipoEmpresa = new string[] {""} ;
         BC001G6_A858PublicacionesContratoId = new string[] {""} ;
         BC001G6_A860PublicacionesTerminoObra = new string[] {""} ;
         BC001G6_A384PublicacionesEstado = new string[] {""} ;
         BC001G6_A385PublicacionesSerialIma = new short[1] ;
         BC001G6_A395PublicacionesSerialRem = new short[1] ;
         BC001G6_A112DepartamentoId = new long[1] ;
         BC001G6_A114DepartamentoMunicipioId = new long[1] ;
         BC001G6_A118MonedaId = new short[1] ;
         BC001G6_n118MonedaId = new bool[] {false} ;
         BC001G12_A381PublicacionesId = new long[1] ;
         BC001G15_A119MonedaISOSimbolo = new string[] {""} ;
         BC001G16_A381PublicacionesId = new long[1] ;
         BC001G16_A382PublicacionesTitulo = new string[] {""} ;
         BC001G16_A383PublicacionesDescripcion = new string[] {""} ;
         BC001G16_A843PublicacionesFecTentInicio = new DateTime[] {DateTime.MinValue} ;
         BC001G16_A844PublicacionesFecRealInicio = new DateTime[] {DateTime.MinValue} ;
         BC001G16_A845PublicacionesFecFinPostulacion = new DateTime[] {DateTime.MinValue} ;
         BC001G16_A846PublicacionesDetalleMateriales = new string[] {""} ;
         BC001G16_A847PublicacionesFecVisita = new DateTime[] {DateTime.MinValue} ;
         BC001G16_A848PublicacionesHoraVisita = new string[] {""} ;
         BC001G16_A849PublicacionesDirVisita = new string[] {""} ;
         BC001G16_A850PublicacionesCondiciones = new string[] {""} ;
         BC001G16_A851PublicacionesTipoDesembolso = new string[] {""} ;
         BC001G16_A859PublicacionesOtroTipoDes = new string[] {""} ;
         BC001G16_A852PublicacionesModalidad = new string[] {""} ;
         BC001G16_A389PublicacionesPrecio = new decimal[1] ;
         BC001G16_A119MonedaISOSimbolo = new string[] {""} ;
         BC001G16_A854PublicacionesFecCierre = new DateTime[] {DateTime.MinValue} ;
         BC001G16_A855PublicacionesDocReq = new string[] {""} ;
         BC001G16_A856PublicacionesDocDescripcion = new string[] {""} ;
         BC001G16_A857PublicacionesTipoEmpresa = new string[] {""} ;
         BC001G16_A858PublicacionesContratoId = new string[] {""} ;
         BC001G16_A860PublicacionesTerminoObra = new string[] {""} ;
         BC001G16_A384PublicacionesEstado = new string[] {""} ;
         BC001G16_A385PublicacionesSerialIma = new short[1] ;
         BC001G16_A395PublicacionesSerialRem = new short[1] ;
         BC001G16_A112DepartamentoId = new long[1] ;
         BC001G16_A114DepartamentoMunicipioId = new long[1] ;
         BC001G16_A118MonedaId = new short[1] ;
         BC001G16_n118MonedaId = new bool[] {false} ;
         Z387PublicacionesDoc = "";
         A387PublicacionesDoc = "";
         Z388PublicacionesDocDescrip = "";
         A388PublicacionesDocDescrip = "";
         BC001G17_A381PublicacionesId = new long[1] ;
         BC001G17_A386PublicacionesDocId = new long[1] ;
         BC001G17_A387PublicacionesDoc = new string[] {""} ;
         BC001G17_A388PublicacionesDocDescrip = new string[] {""} ;
         BC001G18_A381PublicacionesId = new long[1] ;
         BC001G18_A386PublicacionesDocId = new long[1] ;
         BC001G5_A381PublicacionesId = new long[1] ;
         BC001G5_A386PublicacionesDocId = new long[1] ;
         BC001G5_A387PublicacionesDoc = new string[] {""} ;
         BC001G5_A388PublicacionesDocDescrip = new string[] {""} ;
         sMode128 = "";
         BC001G4_A381PublicacionesId = new long[1] ;
         BC001G4_A386PublicacionesDocId = new long[1] ;
         BC001G4_A387PublicacionesDoc = new string[] {""} ;
         BC001G4_A388PublicacionesDocDescrip = new string[] {""} ;
         BC001G22_A381PublicacionesId = new long[1] ;
         BC001G22_A386PublicacionesDocId = new long[1] ;
         BC001G22_A387PublicacionesDoc = new string[] {""} ;
         BC001G22_A388PublicacionesDocDescrip = new string[] {""} ;
         Z392PublicacionesMult = "";
         A392PublicacionesMult = "";
         Z861PublicacionesMultDescrip = "";
         A861PublicacionesMultDescrip = "";
         BC001G23_A381PublicacionesId = new long[1] ;
         BC001G23_A394PublicacionesMultId = new long[1] ;
         BC001G23_A392PublicacionesMult = new string[] {""} ;
         BC001G23_A861PublicacionesMultDescrip = new string[] {""} ;
         BC001G24_A381PublicacionesId = new long[1] ;
         BC001G24_A394PublicacionesMultId = new long[1] ;
         BC001G3_A381PublicacionesId = new long[1] ;
         BC001G3_A394PublicacionesMultId = new long[1] ;
         BC001G3_A392PublicacionesMult = new string[] {""} ;
         BC001G3_A861PublicacionesMultDescrip = new string[] {""} ;
         sMode129 = "";
         BC001G2_A381PublicacionesId = new long[1] ;
         BC001G2_A394PublicacionesMultId = new long[1] ;
         BC001G2_A392PublicacionesMult = new string[] {""} ;
         BC001G2_A861PublicacionesMultDescrip = new string[] {""} ;
         BC001G28_A381PublicacionesId = new long[1] ;
         BC001G28_A394PublicacionesMultId = new long[1] ;
         BC001G28_A392PublicacionesMult = new string[] {""} ;
         BC001G28_A861PublicacionesMultDescrip = new string[] {""} ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.publicaciones_bc__datastore1(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.publicaciones_bc__default(),
            new Object[][] {
                new Object[] {
               BC001G2_A381PublicacionesId, BC001G2_A394PublicacionesMultId, BC001G2_A392PublicacionesMult, BC001G2_A861PublicacionesMultDescrip
               }
               , new Object[] {
               BC001G3_A381PublicacionesId, BC001G3_A394PublicacionesMultId, BC001G3_A392PublicacionesMult, BC001G3_A861PublicacionesMultDescrip
               }
               , new Object[] {
               BC001G4_A381PublicacionesId, BC001G4_A386PublicacionesDocId, BC001G4_A387PublicacionesDoc, BC001G4_A388PublicacionesDocDescrip
               }
               , new Object[] {
               BC001G5_A381PublicacionesId, BC001G5_A386PublicacionesDocId, BC001G5_A387PublicacionesDoc, BC001G5_A388PublicacionesDocDescrip
               }
               , new Object[] {
               BC001G6_A381PublicacionesId, BC001G6_A382PublicacionesTitulo, BC001G6_A383PublicacionesDescripcion, BC001G6_A843PublicacionesFecTentInicio, BC001G6_A844PublicacionesFecRealInicio, BC001G6_A845PublicacionesFecFinPostulacion, BC001G6_A846PublicacionesDetalleMateriales, BC001G6_A847PublicacionesFecVisita, BC001G6_A848PublicacionesHoraVisita, BC001G6_A849PublicacionesDirVisita,
               BC001G6_A850PublicacionesCondiciones, BC001G6_A851PublicacionesTipoDesembolso, BC001G6_A859PublicacionesOtroTipoDes, BC001G6_A852PublicacionesModalidad, BC001G6_A389PublicacionesPrecio, BC001G6_A854PublicacionesFecCierre, BC001G6_A855PublicacionesDocReq, BC001G6_A856PublicacionesDocDescripcion, BC001G6_A857PublicacionesTipoEmpresa, BC001G6_A858PublicacionesContratoId,
               BC001G6_A860PublicacionesTerminoObra, BC001G6_A384PublicacionesEstado, BC001G6_A385PublicacionesSerialIma, BC001G6_A395PublicacionesSerialRem, BC001G6_A112DepartamentoId, BC001G6_A114DepartamentoMunicipioId, BC001G6_A118MonedaId, BC001G6_n118MonedaId
               }
               , new Object[] {
               BC001G7_A381PublicacionesId, BC001G7_A382PublicacionesTitulo, BC001G7_A383PublicacionesDescripcion, BC001G7_A843PublicacionesFecTentInicio, BC001G7_A844PublicacionesFecRealInicio, BC001G7_A845PublicacionesFecFinPostulacion, BC001G7_A846PublicacionesDetalleMateriales, BC001G7_A847PublicacionesFecVisita, BC001G7_A848PublicacionesHoraVisita, BC001G7_A849PublicacionesDirVisita,
               BC001G7_A850PublicacionesCondiciones, BC001G7_A851PublicacionesTipoDesembolso, BC001G7_A859PublicacionesOtroTipoDes, BC001G7_A852PublicacionesModalidad, BC001G7_A389PublicacionesPrecio, BC001G7_A854PublicacionesFecCierre, BC001G7_A855PublicacionesDocReq, BC001G7_A856PublicacionesDocDescripcion, BC001G7_A857PublicacionesTipoEmpresa, BC001G7_A858PublicacionesContratoId,
               BC001G7_A860PublicacionesTerminoObra, BC001G7_A384PublicacionesEstado, BC001G7_A385PublicacionesSerialIma, BC001G7_A395PublicacionesSerialRem, BC001G7_A112DepartamentoId, BC001G7_A114DepartamentoMunicipioId, BC001G7_A118MonedaId, BC001G7_n118MonedaId
               }
               , new Object[] {
               BC001G8_A112DepartamentoId
               }
               , new Object[] {
               BC001G9_A119MonedaISOSimbolo
               }
               , new Object[] {
               BC001G10_A381PublicacionesId, BC001G10_A382PublicacionesTitulo, BC001G10_A383PublicacionesDescripcion, BC001G10_A843PublicacionesFecTentInicio, BC001G10_A844PublicacionesFecRealInicio, BC001G10_A845PublicacionesFecFinPostulacion, BC001G10_A846PublicacionesDetalleMateriales, BC001G10_A847PublicacionesFecVisita, BC001G10_A848PublicacionesHoraVisita, BC001G10_A849PublicacionesDirVisita,
               BC001G10_A850PublicacionesCondiciones, BC001G10_A851PublicacionesTipoDesembolso, BC001G10_A859PublicacionesOtroTipoDes, BC001G10_A852PublicacionesModalidad, BC001G10_A389PublicacionesPrecio, BC001G10_A119MonedaISOSimbolo, BC001G10_A854PublicacionesFecCierre, BC001G10_A855PublicacionesDocReq, BC001G10_A856PublicacionesDocDescripcion, BC001G10_A857PublicacionesTipoEmpresa,
               BC001G10_A858PublicacionesContratoId, BC001G10_A860PublicacionesTerminoObra, BC001G10_A384PublicacionesEstado, BC001G10_A385PublicacionesSerialIma, BC001G10_A395PublicacionesSerialRem, BC001G10_A112DepartamentoId, BC001G10_A114DepartamentoMunicipioId, BC001G10_A118MonedaId, BC001G10_n118MonedaId
               }
               , new Object[] {
               BC001G11_A381PublicacionesId
               }
               , new Object[] {
               BC001G12_A381PublicacionesId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC001G15_A119MonedaISOSimbolo
               }
               , new Object[] {
               BC001G16_A381PublicacionesId, BC001G16_A382PublicacionesTitulo, BC001G16_A383PublicacionesDescripcion, BC001G16_A843PublicacionesFecTentInicio, BC001G16_A844PublicacionesFecRealInicio, BC001G16_A845PublicacionesFecFinPostulacion, BC001G16_A846PublicacionesDetalleMateriales, BC001G16_A847PublicacionesFecVisita, BC001G16_A848PublicacionesHoraVisita, BC001G16_A849PublicacionesDirVisita,
               BC001G16_A850PublicacionesCondiciones, BC001G16_A851PublicacionesTipoDesembolso, BC001G16_A859PublicacionesOtroTipoDes, BC001G16_A852PublicacionesModalidad, BC001G16_A389PublicacionesPrecio, BC001G16_A119MonedaISOSimbolo, BC001G16_A854PublicacionesFecCierre, BC001G16_A855PublicacionesDocReq, BC001G16_A856PublicacionesDocDescripcion, BC001G16_A857PublicacionesTipoEmpresa,
               BC001G16_A858PublicacionesContratoId, BC001G16_A860PublicacionesTerminoObra, BC001G16_A384PublicacionesEstado, BC001G16_A385PublicacionesSerialIma, BC001G16_A395PublicacionesSerialRem, BC001G16_A112DepartamentoId, BC001G16_A114DepartamentoMunicipioId, BC001G16_A118MonedaId, BC001G16_n118MonedaId
               }
               , new Object[] {
               BC001G17_A381PublicacionesId, BC001G17_A386PublicacionesDocId, BC001G17_A387PublicacionesDoc, BC001G17_A388PublicacionesDocDescrip
               }
               , new Object[] {
               BC001G18_A381PublicacionesId, BC001G18_A386PublicacionesDocId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC001G22_A381PublicacionesId, BC001G22_A386PublicacionesDocId, BC001G22_A387PublicacionesDoc, BC001G22_A388PublicacionesDocDescrip
               }
               , new Object[] {
               BC001G23_A381PublicacionesId, BC001G23_A394PublicacionesMultId, BC001G23_A392PublicacionesMult, BC001G23_A861PublicacionesMultDescrip
               }
               , new Object[] {
               BC001G24_A381PublicacionesId, BC001G24_A394PublicacionesMultId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC001G28_A381PublicacionesId, BC001G28_A394PublicacionesMultId, BC001G28_A392PublicacionesMult, BC001G28_A861PublicacionesMultDescrip
               }
            }
         );
         INITTRN();
         /* Execute Start event if defined. */
         /* Execute user event: Start */
         E121G2 ();
         standaloneNotModal( ) ;
      }

      private short AnyError ;
      private short nIsMod_129 ;
      private short RcdFound129 ;
      private short nIsMod_128 ;
      private short RcdFound128 ;
      private short Z385PublicacionesSerialIma ;
      private short A385PublicacionesSerialIma ;
      private short Z395PublicacionesSerialRem ;
      private short A395PublicacionesSerialRem ;
      private short Z118MonedaId ;
      private short A118MonedaId ;
      private short RcdFound127 ;
      private short nRcdExists_128 ;
      private short nRcdExists_129 ;
      private short Gx_BScreen ;
      private short Gxremove128 ;
      private short Gxremove129 ;
      private int trnEnded ;
      private int nGXsfl_129_idx=1 ;
      private int nGXsfl_128_idx=1 ;
      private long Z381PublicacionesId ;
      private long A381PublicacionesId ;
      private long Z112DepartamentoId ;
      private long A112DepartamentoId ;
      private long Z114DepartamentoMunicipioId ;
      private long A114DepartamentoMunicipioId ;
      private long Z386PublicacionesDocId ;
      private long A386PublicacionesDocId ;
      private long Z394PublicacionesMultId ;
      private long A394PublicacionesMultId ;
      private decimal Z389PublicacionesPrecio ;
      private decimal A389PublicacionesPrecio ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string sMode127 ;
      private string Z382PublicacionesTitulo ;
      private string A382PublicacionesTitulo ;
      private string Z846PublicacionesDetalleMateriales ;
      private string A846PublicacionesDetalleMateriales ;
      private string Z848PublicacionesHoraVisita ;
      private string A848PublicacionesHoraVisita ;
      private string Z852PublicacionesModalidad ;
      private string A852PublicacionesModalidad ;
      private string Z384PublicacionesEstado ;
      private string A384PublicacionesEstado ;
      private string Z119MonedaISOSimbolo ;
      private string A119MonedaISOSimbolo ;
      private string sMode128 ;
      private string sMode129 ;
      private DateTime Z843PublicacionesFecTentInicio ;
      private DateTime A843PublicacionesFecTentInicio ;
      private DateTime Z844PublicacionesFecRealInicio ;
      private DateTime A844PublicacionesFecRealInicio ;
      private DateTime Z845PublicacionesFecFinPostulacion ;
      private DateTime A845PublicacionesFecFinPostulacion ;
      private DateTime Z847PublicacionesFecVisita ;
      private DateTime A847PublicacionesFecVisita ;
      private DateTime Z854PublicacionesFecCierre ;
      private DateTime A854PublicacionesFecCierre ;
      private bool returnInSub ;
      private bool n118MonedaId ;
      private bool Gx_longc ;
      private string Z383PublicacionesDescripcion ;
      private string A383PublicacionesDescripcion ;
      private string Z849PublicacionesDirVisita ;
      private string A849PublicacionesDirVisita ;
      private string Z850PublicacionesCondiciones ;
      private string A850PublicacionesCondiciones ;
      private string Z851PublicacionesTipoDesembolso ;
      private string A851PublicacionesTipoDesembolso ;
      private string Z859PublicacionesOtroTipoDes ;
      private string A859PublicacionesOtroTipoDes ;
      private string Z855PublicacionesDocReq ;
      private string A855PublicacionesDocReq ;
      private string Z856PublicacionesDocDescripcion ;
      private string A856PublicacionesDocDescripcion ;
      private string Z857PublicacionesTipoEmpresa ;
      private string A857PublicacionesTipoEmpresa ;
      private string Z858PublicacionesContratoId ;
      private string A858PublicacionesContratoId ;
      private string Z860PublicacionesTerminoObra ;
      private string A860PublicacionesTerminoObra ;
      private string Z387PublicacionesDoc ;
      private string A387PublicacionesDoc ;
      private string Z388PublicacionesDocDescrip ;
      private string A388PublicacionesDocDescrip ;
      private string Z392PublicacionesMult ;
      private string A392PublicacionesMult ;
      private string Z861PublicacionesMultDescrip ;
      private string A861PublicacionesMultDescrip ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private SdtPublicaciones bcPublicaciones ;
      private IDataStoreProvider pr_default ;
      private long[] BC001G10_A381PublicacionesId ;
      private string[] BC001G10_A382PublicacionesTitulo ;
      private string[] BC001G10_A383PublicacionesDescripcion ;
      private DateTime[] BC001G10_A843PublicacionesFecTentInicio ;
      private DateTime[] BC001G10_A844PublicacionesFecRealInicio ;
      private DateTime[] BC001G10_A845PublicacionesFecFinPostulacion ;
      private string[] BC001G10_A846PublicacionesDetalleMateriales ;
      private DateTime[] BC001G10_A847PublicacionesFecVisita ;
      private string[] BC001G10_A848PublicacionesHoraVisita ;
      private string[] BC001G10_A849PublicacionesDirVisita ;
      private string[] BC001G10_A850PublicacionesCondiciones ;
      private string[] BC001G10_A851PublicacionesTipoDesembolso ;
      private string[] BC001G10_A859PublicacionesOtroTipoDes ;
      private string[] BC001G10_A852PublicacionesModalidad ;
      private decimal[] BC001G10_A389PublicacionesPrecio ;
      private string[] BC001G10_A119MonedaISOSimbolo ;
      private DateTime[] BC001G10_A854PublicacionesFecCierre ;
      private string[] BC001G10_A855PublicacionesDocReq ;
      private string[] BC001G10_A856PublicacionesDocDescripcion ;
      private string[] BC001G10_A857PublicacionesTipoEmpresa ;
      private string[] BC001G10_A858PublicacionesContratoId ;
      private string[] BC001G10_A860PublicacionesTerminoObra ;
      private string[] BC001G10_A384PublicacionesEstado ;
      private short[] BC001G10_A385PublicacionesSerialIma ;
      private short[] BC001G10_A395PublicacionesSerialRem ;
      private long[] BC001G10_A112DepartamentoId ;
      private long[] BC001G10_A114DepartamentoMunicipioId ;
      private short[] BC001G10_A118MonedaId ;
      private bool[] BC001G10_n118MonedaId ;
      private long[] BC001G8_A112DepartamentoId ;
      private string[] BC001G9_A119MonedaISOSimbolo ;
      private long[] BC001G11_A381PublicacionesId ;
      private long[] BC001G7_A381PublicacionesId ;
      private string[] BC001G7_A382PublicacionesTitulo ;
      private string[] BC001G7_A383PublicacionesDescripcion ;
      private DateTime[] BC001G7_A843PublicacionesFecTentInicio ;
      private DateTime[] BC001G7_A844PublicacionesFecRealInicio ;
      private DateTime[] BC001G7_A845PublicacionesFecFinPostulacion ;
      private string[] BC001G7_A846PublicacionesDetalleMateriales ;
      private DateTime[] BC001G7_A847PublicacionesFecVisita ;
      private string[] BC001G7_A848PublicacionesHoraVisita ;
      private string[] BC001G7_A849PublicacionesDirVisita ;
      private string[] BC001G7_A850PublicacionesCondiciones ;
      private string[] BC001G7_A851PublicacionesTipoDesembolso ;
      private string[] BC001G7_A859PublicacionesOtroTipoDes ;
      private string[] BC001G7_A852PublicacionesModalidad ;
      private decimal[] BC001G7_A389PublicacionesPrecio ;
      private DateTime[] BC001G7_A854PublicacionesFecCierre ;
      private string[] BC001G7_A855PublicacionesDocReq ;
      private string[] BC001G7_A856PublicacionesDocDescripcion ;
      private string[] BC001G7_A857PublicacionesTipoEmpresa ;
      private string[] BC001G7_A858PublicacionesContratoId ;
      private string[] BC001G7_A860PublicacionesTerminoObra ;
      private string[] BC001G7_A384PublicacionesEstado ;
      private short[] BC001G7_A385PublicacionesSerialIma ;
      private short[] BC001G7_A395PublicacionesSerialRem ;
      private long[] BC001G7_A112DepartamentoId ;
      private long[] BC001G7_A114DepartamentoMunicipioId ;
      private short[] BC001G7_A118MonedaId ;
      private bool[] BC001G7_n118MonedaId ;
      private long[] BC001G6_A381PublicacionesId ;
      private string[] BC001G6_A382PublicacionesTitulo ;
      private string[] BC001G6_A383PublicacionesDescripcion ;
      private DateTime[] BC001G6_A843PublicacionesFecTentInicio ;
      private DateTime[] BC001G6_A844PublicacionesFecRealInicio ;
      private DateTime[] BC001G6_A845PublicacionesFecFinPostulacion ;
      private string[] BC001G6_A846PublicacionesDetalleMateriales ;
      private DateTime[] BC001G6_A847PublicacionesFecVisita ;
      private string[] BC001G6_A848PublicacionesHoraVisita ;
      private string[] BC001G6_A849PublicacionesDirVisita ;
      private string[] BC001G6_A850PublicacionesCondiciones ;
      private string[] BC001G6_A851PublicacionesTipoDesembolso ;
      private string[] BC001G6_A859PublicacionesOtroTipoDes ;
      private string[] BC001G6_A852PublicacionesModalidad ;
      private decimal[] BC001G6_A389PublicacionesPrecio ;
      private DateTime[] BC001G6_A854PublicacionesFecCierre ;
      private string[] BC001G6_A855PublicacionesDocReq ;
      private string[] BC001G6_A856PublicacionesDocDescripcion ;
      private string[] BC001G6_A857PublicacionesTipoEmpresa ;
      private string[] BC001G6_A858PublicacionesContratoId ;
      private string[] BC001G6_A860PublicacionesTerminoObra ;
      private string[] BC001G6_A384PublicacionesEstado ;
      private short[] BC001G6_A385PublicacionesSerialIma ;
      private short[] BC001G6_A395PublicacionesSerialRem ;
      private long[] BC001G6_A112DepartamentoId ;
      private long[] BC001G6_A114DepartamentoMunicipioId ;
      private short[] BC001G6_A118MonedaId ;
      private bool[] BC001G6_n118MonedaId ;
      private long[] BC001G12_A381PublicacionesId ;
      private string[] BC001G15_A119MonedaISOSimbolo ;
      private long[] BC001G16_A381PublicacionesId ;
      private string[] BC001G16_A382PublicacionesTitulo ;
      private string[] BC001G16_A383PublicacionesDescripcion ;
      private DateTime[] BC001G16_A843PublicacionesFecTentInicio ;
      private DateTime[] BC001G16_A844PublicacionesFecRealInicio ;
      private DateTime[] BC001G16_A845PublicacionesFecFinPostulacion ;
      private string[] BC001G16_A846PublicacionesDetalleMateriales ;
      private DateTime[] BC001G16_A847PublicacionesFecVisita ;
      private string[] BC001G16_A848PublicacionesHoraVisita ;
      private string[] BC001G16_A849PublicacionesDirVisita ;
      private string[] BC001G16_A850PublicacionesCondiciones ;
      private string[] BC001G16_A851PublicacionesTipoDesembolso ;
      private string[] BC001G16_A859PublicacionesOtroTipoDes ;
      private string[] BC001G16_A852PublicacionesModalidad ;
      private decimal[] BC001G16_A389PublicacionesPrecio ;
      private string[] BC001G16_A119MonedaISOSimbolo ;
      private DateTime[] BC001G16_A854PublicacionesFecCierre ;
      private string[] BC001G16_A855PublicacionesDocReq ;
      private string[] BC001G16_A856PublicacionesDocDescripcion ;
      private string[] BC001G16_A857PublicacionesTipoEmpresa ;
      private string[] BC001G16_A858PublicacionesContratoId ;
      private string[] BC001G16_A860PublicacionesTerminoObra ;
      private string[] BC001G16_A384PublicacionesEstado ;
      private short[] BC001G16_A385PublicacionesSerialIma ;
      private short[] BC001G16_A395PublicacionesSerialRem ;
      private long[] BC001G16_A112DepartamentoId ;
      private long[] BC001G16_A114DepartamentoMunicipioId ;
      private short[] BC001G16_A118MonedaId ;
      private bool[] BC001G16_n118MonedaId ;
      private long[] BC001G17_A381PublicacionesId ;
      private long[] BC001G17_A386PublicacionesDocId ;
      private string[] BC001G17_A387PublicacionesDoc ;
      private string[] BC001G17_A388PublicacionesDocDescrip ;
      private long[] BC001G18_A381PublicacionesId ;
      private long[] BC001G18_A386PublicacionesDocId ;
      private long[] BC001G5_A381PublicacionesId ;
      private long[] BC001G5_A386PublicacionesDocId ;
      private string[] BC001G5_A387PublicacionesDoc ;
      private string[] BC001G5_A388PublicacionesDocDescrip ;
      private long[] BC001G4_A381PublicacionesId ;
      private long[] BC001G4_A386PublicacionesDocId ;
      private string[] BC001G4_A387PublicacionesDoc ;
      private string[] BC001G4_A388PublicacionesDocDescrip ;
      private long[] BC001G22_A381PublicacionesId ;
      private long[] BC001G22_A386PublicacionesDocId ;
      private string[] BC001G22_A387PublicacionesDoc ;
      private string[] BC001G22_A388PublicacionesDocDescrip ;
      private long[] BC001G23_A381PublicacionesId ;
      private long[] BC001G23_A394PublicacionesMultId ;
      private string[] BC001G23_A392PublicacionesMult ;
      private string[] BC001G23_A861PublicacionesMultDescrip ;
      private long[] BC001G24_A381PublicacionesId ;
      private long[] BC001G24_A394PublicacionesMultId ;
      private long[] BC001G3_A381PublicacionesId ;
      private long[] BC001G3_A394PublicacionesMultId ;
      private string[] BC001G3_A392PublicacionesMult ;
      private string[] BC001G3_A861PublicacionesMultDescrip ;
      private long[] BC001G2_A381PublicacionesId ;
      private long[] BC001G2_A394PublicacionesMultId ;
      private string[] BC001G2_A392PublicacionesMult ;
      private string[] BC001G2_A861PublicacionesMultDescrip ;
      private long[] BC001G28_A381PublicacionesId ;
      private long[] BC001G28_A394PublicacionesMultId ;
      private string[] BC001G28_A392PublicacionesMult ;
      private string[] BC001G28_A861PublicacionesMultDescrip ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_datastore1 ;
   }

   public class publicaciones_bc__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class publicaciones_bc__default : DataStoreHelperBase, IDataStoreHelper
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
       ,new UpdateCursor(def[11])
       ,new UpdateCursor(def[12])
       ,new ForEachCursor(def[13])
       ,new ForEachCursor(def[14])
       ,new ForEachCursor(def[15])
       ,new ForEachCursor(def[16])
       ,new UpdateCursor(def[17])
       ,new UpdateCursor(def[18])
       ,new UpdateCursor(def[19])
       ,new ForEachCursor(def[20])
       ,new ForEachCursor(def[21])
       ,new ForEachCursor(def[22])
       ,new UpdateCursor(def[23])
       ,new UpdateCursor(def[24])
       ,new UpdateCursor(def[25])
       ,new ForEachCursor(def[26])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmBC001G2;
        prmBC001G2 = new Object[] {
        new ParDef("@PublicacionesId",GXType.Decimal,18,0) ,
        new ParDef("@PublicacionesMultId",GXType.Decimal,18,0)
        };
        Object[] prmBC001G3;
        prmBC001G3 = new Object[] {
        new ParDef("@PublicacionesId",GXType.Decimal,18,0) ,
        new ParDef("@PublicacionesMultId",GXType.Decimal,18,0)
        };
        Object[] prmBC001G4;
        prmBC001G4 = new Object[] {
        new ParDef("@PublicacionesId",GXType.Decimal,18,0) ,
        new ParDef("@PublicacionesDocId",GXType.Decimal,18,0)
        };
        Object[] prmBC001G5;
        prmBC001G5 = new Object[] {
        new ParDef("@PublicacionesId",GXType.Decimal,18,0) ,
        new ParDef("@PublicacionesDocId",GXType.Decimal,18,0)
        };
        Object[] prmBC001G6;
        prmBC001G6 = new Object[] {
        new ParDef("@PublicacionesId",GXType.Decimal,18,0)
        };
        Object[] prmBC001G7;
        prmBC001G7 = new Object[] {
        new ParDef("@PublicacionesId",GXType.Decimal,18,0)
        };
        Object[] prmBC001G8;
        prmBC001G8 = new Object[] {
        new ParDef("@DepartamentoId",GXType.Decimal,18,0) ,
        new ParDef("@DepartamentoMunicipioId",GXType.Decimal,18,0)
        };
        Object[] prmBC001G9;
        prmBC001G9 = new Object[] {
        new ParDef("@MonedaId",GXType.Int16,4,0){Nullable=true}
        };
        Object[] prmBC001G10;
        prmBC001G10 = new Object[] {
        new ParDef("@PublicacionesId",GXType.Decimal,18,0)
        };
        Object[] prmBC001G11;
        prmBC001G11 = new Object[] {
        new ParDef("@PublicacionesId",GXType.Decimal,18,0)
        };
        Object[] prmBC001G12;
        prmBC001G12 = new Object[] {
        new ParDef("@PublicacionesTitulo",GXType.NChar,80,0) ,
        new ParDef("@PublicacionesDescripcion",GXType.NVarChar,2097152,0) ,
        new ParDef("@PublicacionesFecTentInicio",GXType.Date,8,0) ,
        new ParDef("@PublicacionesFecRealInicio",GXType.Date,8,0) ,
        new ParDef("@PublicacionesFecFinPostulacion",GXType.Date,8,0) ,
        new ParDef("@PublicacionesDetalleMateriales",GXType.NChar,100,0) ,
        new ParDef("@PublicacionesFecVisita",GXType.Date,8,0) ,
        new ParDef("@PublicacionesHoraVisita",GXType.NChar,8,0) ,
        new ParDef("@PublicacionesDirVisita",GXType.NVarChar,40,0) ,
        new ParDef("@PublicacionesCondiciones",GXType.NVarChar,100,0) ,
        new ParDef("@PublicacionesTipoDesembolso",GXType.NVarChar,40,0) ,
        new ParDef("@PublicacionesOtroTipoDes",GXType.NVarChar,40,0) ,
        new ParDef("@PublicacionesModalidad",GXType.NChar,1,0) ,
        new ParDef("@PublicacionesPrecio",GXType.Decimal,18,2) ,
        new ParDef("@PublicacionesFecCierre",GXType.Date,8,0) ,
        new ParDef("@PublicacionesDocReq",GXType.NVarChar,100,0) ,
        new ParDef("@PublicacionesDocDescripcion",GXType.NVarChar,100,0) ,
        new ParDef("@PublicacionesTipoEmpresa",GXType.NVarChar,40,0) ,
        new ParDef("@PublicacionesContratoId",GXType.NVarChar,40,0) ,
        new ParDef("@PublicacionesTerminoObra",GXType.NVarChar,40,0) ,
        new ParDef("@PublicacionesEstado",GXType.NChar,3,0) ,
        new ParDef("@PublicacionesSerialIma",GXType.Int16,4,0) ,
        new ParDef("@PublicacionesSerialRem",GXType.Int16,4,0) ,
        new ParDef("@DepartamentoId",GXType.Decimal,18,0) ,
        new ParDef("@DepartamentoMunicipioId",GXType.Decimal,18,0) ,
        new ParDef("@MonedaId",GXType.Int16,4,0){Nullable=true}
        };
        Object[] prmBC001G13;
        prmBC001G13 = new Object[] {
        new ParDef("@PublicacionesTitulo",GXType.NChar,80,0) ,
        new ParDef("@PublicacionesDescripcion",GXType.NVarChar,2097152,0) ,
        new ParDef("@PublicacionesFecTentInicio",GXType.Date,8,0) ,
        new ParDef("@PublicacionesFecRealInicio",GXType.Date,8,0) ,
        new ParDef("@PublicacionesFecFinPostulacion",GXType.Date,8,0) ,
        new ParDef("@PublicacionesDetalleMateriales",GXType.NChar,100,0) ,
        new ParDef("@PublicacionesFecVisita",GXType.Date,8,0) ,
        new ParDef("@PublicacionesHoraVisita",GXType.NChar,8,0) ,
        new ParDef("@PublicacionesDirVisita",GXType.NVarChar,40,0) ,
        new ParDef("@PublicacionesCondiciones",GXType.NVarChar,100,0) ,
        new ParDef("@PublicacionesTipoDesembolso",GXType.NVarChar,40,0) ,
        new ParDef("@PublicacionesOtroTipoDes",GXType.NVarChar,40,0) ,
        new ParDef("@PublicacionesModalidad",GXType.NChar,1,0) ,
        new ParDef("@PublicacionesPrecio",GXType.Decimal,18,2) ,
        new ParDef("@PublicacionesFecCierre",GXType.Date,8,0) ,
        new ParDef("@PublicacionesDocReq",GXType.NVarChar,100,0) ,
        new ParDef("@PublicacionesDocDescripcion",GXType.NVarChar,100,0) ,
        new ParDef("@PublicacionesTipoEmpresa",GXType.NVarChar,40,0) ,
        new ParDef("@PublicacionesContratoId",GXType.NVarChar,40,0) ,
        new ParDef("@PublicacionesTerminoObra",GXType.NVarChar,40,0) ,
        new ParDef("@PublicacionesEstado",GXType.NChar,3,0) ,
        new ParDef("@PublicacionesSerialIma",GXType.Int16,4,0) ,
        new ParDef("@PublicacionesSerialRem",GXType.Int16,4,0) ,
        new ParDef("@DepartamentoId",GXType.Decimal,18,0) ,
        new ParDef("@DepartamentoMunicipioId",GXType.Decimal,18,0) ,
        new ParDef("@MonedaId",GXType.Int16,4,0){Nullable=true} ,
        new ParDef("@PublicacionesId",GXType.Decimal,18,0)
        };
        Object[] prmBC001G14;
        prmBC001G14 = new Object[] {
        new ParDef("@PublicacionesId",GXType.Decimal,18,0)
        };
        Object[] prmBC001G15;
        prmBC001G15 = new Object[] {
        new ParDef("@MonedaId",GXType.Int16,4,0){Nullable=true}
        };
        Object[] prmBC001G16;
        prmBC001G16 = new Object[] {
        new ParDef("@PublicacionesId",GXType.Decimal,18,0)
        };
        Object[] prmBC001G17;
        prmBC001G17 = new Object[] {
        new ParDef("@PublicacionesId",GXType.Decimal,18,0) ,
        new ParDef("@PublicacionesDocId",GXType.Decimal,18,0)
        };
        Object[] prmBC001G18;
        prmBC001G18 = new Object[] {
        new ParDef("@PublicacionesId",GXType.Decimal,18,0) ,
        new ParDef("@PublicacionesDocId",GXType.Decimal,18,0)
        };
        Object[] prmBC001G19;
        prmBC001G19 = new Object[] {
        new ParDef("@PublicacionesId",GXType.Decimal,18,0) ,
        new ParDef("@PublicacionesDocId",GXType.Decimal,18,0) ,
        new ParDef("@PublicacionesDoc",GXType.NVarChar,80,0) ,
        new ParDef("@PublicacionesDocDescrip",GXType.NVarChar,80,0)
        };
        Object[] prmBC001G20;
        prmBC001G20 = new Object[] {
        new ParDef("@PublicacionesDoc",GXType.NVarChar,80,0) ,
        new ParDef("@PublicacionesDocDescrip",GXType.NVarChar,80,0) ,
        new ParDef("@PublicacionesId",GXType.Decimal,18,0) ,
        new ParDef("@PublicacionesDocId",GXType.Decimal,18,0)
        };
        Object[] prmBC001G21;
        prmBC001G21 = new Object[] {
        new ParDef("@PublicacionesId",GXType.Decimal,18,0) ,
        new ParDef("@PublicacionesDocId",GXType.Decimal,18,0)
        };
        Object[] prmBC001G22;
        prmBC001G22 = new Object[] {
        new ParDef("@PublicacionesId",GXType.Decimal,18,0)
        };
        Object[] prmBC001G23;
        prmBC001G23 = new Object[] {
        new ParDef("@PublicacionesId",GXType.Decimal,18,0) ,
        new ParDef("@PublicacionesMultId",GXType.Decimal,18,0)
        };
        Object[] prmBC001G24;
        prmBC001G24 = new Object[] {
        new ParDef("@PublicacionesId",GXType.Decimal,18,0) ,
        new ParDef("@PublicacionesMultId",GXType.Decimal,18,0)
        };
        Object[] prmBC001G25;
        prmBC001G25 = new Object[] {
        new ParDef("@PublicacionesId",GXType.Decimal,18,0) ,
        new ParDef("@PublicacionesMultId",GXType.Decimal,18,0) ,
        new ParDef("@PublicacionesMult",GXType.NVarChar,80,0) ,
        new ParDef("@PublicacionesMultDescrip",GXType.NVarChar,80,0)
        };
        Object[] prmBC001G26;
        prmBC001G26 = new Object[] {
        new ParDef("@PublicacionesMult",GXType.NVarChar,80,0) ,
        new ParDef("@PublicacionesMultDescrip",GXType.NVarChar,80,0) ,
        new ParDef("@PublicacionesId",GXType.Decimal,18,0) ,
        new ParDef("@PublicacionesMultId",GXType.Decimal,18,0)
        };
        Object[] prmBC001G27;
        prmBC001G27 = new Object[] {
        new ParDef("@PublicacionesId",GXType.Decimal,18,0) ,
        new ParDef("@PublicacionesMultId",GXType.Decimal,18,0)
        };
        Object[] prmBC001G28;
        prmBC001G28 = new Object[] {
        new ParDef("@PublicacionesId",GXType.Decimal,18,0)
        };
        def= new CursorDef[] {
            new CursorDef("BC001G2", "SELECT [PublicacionesId], [PublicacionesMultId], [PublicacionesMult], [PublicacionesMultDescrip] FROM [PublicacionesMultimedia] WITH (UPDLOCK) WHERE [PublicacionesId] = @PublicacionesId AND [PublicacionesMultId] = @PublicacionesMultId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001G2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC001G3", "SELECT [PublicacionesId], [PublicacionesMultId], [PublicacionesMult], [PublicacionesMultDescrip] FROM [PublicacionesMultimedia] WHERE [PublicacionesId] = @PublicacionesId AND [PublicacionesMultId] = @PublicacionesMultId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001G3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC001G4", "SELECT [PublicacionesId], [PublicacionesDocId], [PublicacionesDoc], [PublicacionesDocDescrip] FROM [PublicacionesDocumento] WITH (UPDLOCK) WHERE [PublicacionesId] = @PublicacionesId AND [PublicacionesDocId] = @PublicacionesDocId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001G4,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC001G5", "SELECT [PublicacionesId], [PublicacionesDocId], [PublicacionesDoc], [PublicacionesDocDescrip] FROM [PublicacionesDocumento] WHERE [PublicacionesId] = @PublicacionesId AND [PublicacionesDocId] = @PublicacionesDocId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001G5,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC001G6", "SELECT [PublicacionesId], [PublicacionesTitulo], [PublicacionesDescripcion], [PublicacionesFecTentInicio], [PublicacionesFecRealInicio], [PublicacionesFecFinPostulacion], [PublicacionesDetalleMateriales], [PublicacionesFecVisita], [PublicacionesHoraVisita], [PublicacionesDirVisita], [PublicacionesCondiciones], [PublicacionesTipoDesembolso], [PublicacionesOtroTipoDes], [PublicacionesModalidad], [PublicacionesPrecio], [PublicacionesFecCierre], [PublicacionesDocReq], [PublicacionesDocDescripcion], [PublicacionesTipoEmpresa], [PublicacionesContratoId], [PublicacionesTerminoObra], [PublicacionesEstado], [PublicacionesSerialIma], [PublicacionesSerialRem], [DepartamentoId], [DepartamentoMunicipioId], [MonedaId] FROM [Publicaciones] WITH (UPDLOCK) WHERE [PublicacionesId] = @PublicacionesId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001G6,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC001G7", "SELECT [PublicacionesId], [PublicacionesTitulo], [PublicacionesDescripcion], [PublicacionesFecTentInicio], [PublicacionesFecRealInicio], [PublicacionesFecFinPostulacion], [PublicacionesDetalleMateriales], [PublicacionesFecVisita], [PublicacionesHoraVisita], [PublicacionesDirVisita], [PublicacionesCondiciones], [PublicacionesTipoDesembolso], [PublicacionesOtroTipoDes], [PublicacionesModalidad], [PublicacionesPrecio], [PublicacionesFecCierre], [PublicacionesDocReq], [PublicacionesDocDescripcion], [PublicacionesTipoEmpresa], [PublicacionesContratoId], [PublicacionesTerminoObra], [PublicacionesEstado], [PublicacionesSerialIma], [PublicacionesSerialRem], [DepartamentoId], [DepartamentoMunicipioId], [MonedaId] FROM [Publicaciones] WHERE [PublicacionesId] = @PublicacionesId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001G7,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC001G8", "SELECT [DepartamentoId] FROM [DepartamentoMunicipio] WHERE [DepartamentoId] = @DepartamentoId AND [DepartamentoMunicipioId] = @DepartamentoMunicipioId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001G8,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC001G9", "SELECT [MonedaISOSimbolo] FROM [Moneda] WHERE [MonedaId] = @MonedaId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001G9,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC001G10", "SELECT TM1.[PublicacionesId], TM1.[PublicacionesTitulo], TM1.[PublicacionesDescripcion], TM1.[PublicacionesFecTentInicio], TM1.[PublicacionesFecRealInicio], TM1.[PublicacionesFecFinPostulacion], TM1.[PublicacionesDetalleMateriales], TM1.[PublicacionesFecVisita], TM1.[PublicacionesHoraVisita], TM1.[PublicacionesDirVisita], TM1.[PublicacionesCondiciones], TM1.[PublicacionesTipoDesembolso], TM1.[PublicacionesOtroTipoDes], TM1.[PublicacionesModalidad], TM1.[PublicacionesPrecio], T2.[MonedaISOSimbolo], TM1.[PublicacionesFecCierre], TM1.[PublicacionesDocReq], TM1.[PublicacionesDocDescripcion], TM1.[PublicacionesTipoEmpresa], TM1.[PublicacionesContratoId], TM1.[PublicacionesTerminoObra], TM1.[PublicacionesEstado], TM1.[PublicacionesSerialIma], TM1.[PublicacionesSerialRem], TM1.[DepartamentoId], TM1.[DepartamentoMunicipioId], TM1.[MonedaId] FROM ([Publicaciones] TM1 LEFT JOIN [Moneda] T2 ON T2.[MonedaId] = TM1.[MonedaId]) WHERE TM1.[PublicacionesId] = @PublicacionesId ORDER BY TM1.[PublicacionesId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmBC001G10,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC001G11", "SELECT [PublicacionesId] FROM [Publicaciones] WHERE [PublicacionesId] = @PublicacionesId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmBC001G11,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC001G12", "INSERT INTO [Publicaciones]([PublicacionesTitulo], [PublicacionesDescripcion], [PublicacionesFecTentInicio], [PublicacionesFecRealInicio], [PublicacionesFecFinPostulacion], [PublicacionesDetalleMateriales], [PublicacionesFecVisita], [PublicacionesHoraVisita], [PublicacionesDirVisita], [PublicacionesCondiciones], [PublicacionesTipoDesembolso], [PublicacionesOtroTipoDes], [PublicacionesModalidad], [PublicacionesPrecio], [PublicacionesFecCierre], [PublicacionesDocReq], [PublicacionesDocDescripcion], [PublicacionesTipoEmpresa], [PublicacionesContratoId], [PublicacionesTerminoObra], [PublicacionesEstado], [PublicacionesSerialIma], [PublicacionesSerialRem], [DepartamentoId], [DepartamentoMunicipioId], [MonedaId]) VALUES(@PublicacionesTitulo, @PublicacionesDescripcion, @PublicacionesFecTentInicio, @PublicacionesFecRealInicio, @PublicacionesFecFinPostulacion, @PublicacionesDetalleMateriales, @PublicacionesFecVisita, @PublicacionesHoraVisita, @PublicacionesDirVisita, @PublicacionesCondiciones, @PublicacionesTipoDesembolso, @PublicacionesOtroTipoDes, @PublicacionesModalidad, @PublicacionesPrecio, @PublicacionesFecCierre, @PublicacionesDocReq, @PublicacionesDocDescripcion, @PublicacionesTipoEmpresa, @PublicacionesContratoId, @PublicacionesTerminoObra, @PublicacionesEstado, @PublicacionesSerialIma, @PublicacionesSerialRem, @DepartamentoId, @DepartamentoMunicipioId, @MonedaId); SELECT SCOPE_IDENTITY()",true, GxErrorMask.GX_NOMASK, false, this,prmBC001G12,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("BC001G13", "UPDATE [Publicaciones] SET [PublicacionesTitulo]=@PublicacionesTitulo, [PublicacionesDescripcion]=@PublicacionesDescripcion, [PublicacionesFecTentInicio]=@PublicacionesFecTentInicio, [PublicacionesFecRealInicio]=@PublicacionesFecRealInicio, [PublicacionesFecFinPostulacion]=@PublicacionesFecFinPostulacion, [PublicacionesDetalleMateriales]=@PublicacionesDetalleMateriales, [PublicacionesFecVisita]=@PublicacionesFecVisita, [PublicacionesHoraVisita]=@PublicacionesHoraVisita, [PublicacionesDirVisita]=@PublicacionesDirVisita, [PublicacionesCondiciones]=@PublicacionesCondiciones, [PublicacionesTipoDesembolso]=@PublicacionesTipoDesembolso, [PublicacionesOtroTipoDes]=@PublicacionesOtroTipoDes, [PublicacionesModalidad]=@PublicacionesModalidad, [PublicacionesPrecio]=@PublicacionesPrecio, [PublicacionesFecCierre]=@PublicacionesFecCierre, [PublicacionesDocReq]=@PublicacionesDocReq, [PublicacionesDocDescripcion]=@PublicacionesDocDescripcion, [PublicacionesTipoEmpresa]=@PublicacionesTipoEmpresa, [PublicacionesContratoId]=@PublicacionesContratoId, [PublicacionesTerminoObra]=@PublicacionesTerminoObra, [PublicacionesEstado]=@PublicacionesEstado, [PublicacionesSerialIma]=@PublicacionesSerialIma, [PublicacionesSerialRem]=@PublicacionesSerialRem, [DepartamentoId]=@DepartamentoId, [DepartamentoMunicipioId]=@DepartamentoMunicipioId, [MonedaId]=@MonedaId  WHERE [PublicacionesId] = @PublicacionesId", GxErrorMask.GX_NOMASK,prmBC001G13)
           ,new CursorDef("BC001G14", "DELETE FROM [Publicaciones]  WHERE [PublicacionesId] = @PublicacionesId", GxErrorMask.GX_NOMASK,prmBC001G14)
           ,new CursorDef("BC001G15", "SELECT [MonedaISOSimbolo] FROM [Moneda] WHERE [MonedaId] = @MonedaId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001G15,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC001G16", "SELECT TM1.[PublicacionesId], TM1.[PublicacionesTitulo], TM1.[PublicacionesDescripcion], TM1.[PublicacionesFecTentInicio], TM1.[PublicacionesFecRealInicio], TM1.[PublicacionesFecFinPostulacion], TM1.[PublicacionesDetalleMateriales], TM1.[PublicacionesFecVisita], TM1.[PublicacionesHoraVisita], TM1.[PublicacionesDirVisita], TM1.[PublicacionesCondiciones], TM1.[PublicacionesTipoDesembolso], TM1.[PublicacionesOtroTipoDes], TM1.[PublicacionesModalidad], TM1.[PublicacionesPrecio], T2.[MonedaISOSimbolo], TM1.[PublicacionesFecCierre], TM1.[PublicacionesDocReq], TM1.[PublicacionesDocDescripcion], TM1.[PublicacionesTipoEmpresa], TM1.[PublicacionesContratoId], TM1.[PublicacionesTerminoObra], TM1.[PublicacionesEstado], TM1.[PublicacionesSerialIma], TM1.[PublicacionesSerialRem], TM1.[DepartamentoId], TM1.[DepartamentoMunicipioId], TM1.[MonedaId] FROM ([Publicaciones] TM1 LEFT JOIN [Moneda] T2 ON T2.[MonedaId] = TM1.[MonedaId]) WHERE TM1.[PublicacionesId] = @PublicacionesId ORDER BY TM1.[PublicacionesId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmBC001G16,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC001G17", "SELECT [PublicacionesId], [PublicacionesDocId], [PublicacionesDoc], [PublicacionesDocDescrip] FROM [PublicacionesDocumento] WHERE [PublicacionesId] = @PublicacionesId and [PublicacionesDocId] = @PublicacionesDocId ORDER BY [PublicacionesId], [PublicacionesDocId]  OPTION (FAST 11)",true, GxErrorMask.GX_NOMASK, false, this,prmBC001G17,11, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC001G18", "SELECT [PublicacionesId], [PublicacionesDocId] FROM [PublicacionesDocumento] WHERE [PublicacionesId] = @PublicacionesId AND [PublicacionesDocId] = @PublicacionesDocId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmBC001G18,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC001G19", "INSERT INTO [PublicacionesDocumento]([PublicacionesId], [PublicacionesDocId], [PublicacionesDoc], [PublicacionesDocDescrip]) VALUES(@PublicacionesId, @PublicacionesDocId, @PublicacionesDoc, @PublicacionesDocDescrip)", GxErrorMask.GX_NOMASK,prmBC001G19)
           ,new CursorDef("BC001G20", "UPDATE [PublicacionesDocumento] SET [PublicacionesDoc]=@PublicacionesDoc, [PublicacionesDocDescrip]=@PublicacionesDocDescrip  WHERE [PublicacionesId] = @PublicacionesId AND [PublicacionesDocId] = @PublicacionesDocId", GxErrorMask.GX_NOMASK,prmBC001G20)
           ,new CursorDef("BC001G21", "DELETE FROM [PublicacionesDocumento]  WHERE [PublicacionesId] = @PublicacionesId AND [PublicacionesDocId] = @PublicacionesDocId", GxErrorMask.GX_NOMASK,prmBC001G21)
           ,new CursorDef("BC001G22", "SELECT [PublicacionesId], [PublicacionesDocId], [PublicacionesDoc], [PublicacionesDocDescrip] FROM [PublicacionesDocumento] WHERE [PublicacionesId] = @PublicacionesId ORDER BY [PublicacionesId], [PublicacionesDocId]  OPTION (FAST 11)",true, GxErrorMask.GX_NOMASK, false, this,prmBC001G22,11, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC001G23", "SELECT [PublicacionesId], [PublicacionesMultId], [PublicacionesMult], [PublicacionesMultDescrip] FROM [PublicacionesMultimedia] WHERE [PublicacionesId] = @PublicacionesId and [PublicacionesMultId] = @PublicacionesMultId ORDER BY [PublicacionesId], [PublicacionesMultId]  OPTION (FAST 11)",true, GxErrorMask.GX_NOMASK, false, this,prmBC001G23,11, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC001G24", "SELECT [PublicacionesId], [PublicacionesMultId] FROM [PublicacionesMultimedia] WHERE [PublicacionesId] = @PublicacionesId AND [PublicacionesMultId] = @PublicacionesMultId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmBC001G24,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC001G25", "INSERT INTO [PublicacionesMultimedia]([PublicacionesId], [PublicacionesMultId], [PublicacionesMult], [PublicacionesMultDescrip]) VALUES(@PublicacionesId, @PublicacionesMultId, @PublicacionesMult, @PublicacionesMultDescrip)", GxErrorMask.GX_NOMASK,prmBC001G25)
           ,new CursorDef("BC001G26", "UPDATE [PublicacionesMultimedia] SET [PublicacionesMult]=@PublicacionesMult, [PublicacionesMultDescrip]=@PublicacionesMultDescrip  WHERE [PublicacionesId] = @PublicacionesId AND [PublicacionesMultId] = @PublicacionesMultId", GxErrorMask.GX_NOMASK,prmBC001G26)
           ,new CursorDef("BC001G27", "DELETE FROM [PublicacionesMultimedia]  WHERE [PublicacionesId] = @PublicacionesId AND [PublicacionesMultId] = @PublicacionesMultId", GxErrorMask.GX_NOMASK,prmBC001G27)
           ,new CursorDef("BC001G28", "SELECT [PublicacionesId], [PublicacionesMultId], [PublicacionesMult], [PublicacionesMultDescrip] FROM [PublicacionesMultimedia] WHERE [PublicacionesId] = @PublicacionesId ORDER BY [PublicacionesId], [PublicacionesMultId]  OPTION (FAST 11)",true, GxErrorMask.GX_NOMASK, false, this,prmBC001G28,11, GxCacheFrequency.OFF ,true,false )
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
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              return;
           case 1 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              return;
           case 2 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              return;
           case 3 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              return;
           case 4 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 80);
              ((string[]) buf[2])[0] = rslt.getLongVarchar(3);
              ((DateTime[]) buf[3])[0] = rslt.getGXDate(4);
              ((DateTime[]) buf[4])[0] = rslt.getGXDate(5);
              ((DateTime[]) buf[5])[0] = rslt.getGXDate(6);
              ((string[]) buf[6])[0] = rslt.getString(7, 100);
              ((DateTime[]) buf[7])[0] = rslt.getGXDate(8);
              ((string[]) buf[8])[0] = rslt.getString(9, 8);
              ((string[]) buf[9])[0] = rslt.getVarchar(10);
              ((string[]) buf[10])[0] = rslt.getVarchar(11);
              ((string[]) buf[11])[0] = rslt.getVarchar(12);
              ((string[]) buf[12])[0] = rslt.getVarchar(13);
              ((string[]) buf[13])[0] = rslt.getString(14, 1);
              ((decimal[]) buf[14])[0] = rslt.getDecimal(15);
              ((DateTime[]) buf[15])[0] = rslt.getGXDate(16);
              ((string[]) buf[16])[0] = rslt.getVarchar(17);
              ((string[]) buf[17])[0] = rslt.getVarchar(18);
              ((string[]) buf[18])[0] = rslt.getVarchar(19);
              ((string[]) buf[19])[0] = rslt.getVarchar(20);
              ((string[]) buf[20])[0] = rslt.getVarchar(21);
              ((string[]) buf[21])[0] = rslt.getString(22, 3);
              ((short[]) buf[22])[0] = rslt.getShort(23);
              ((short[]) buf[23])[0] = rslt.getShort(24);
              ((long[]) buf[24])[0] = rslt.getLong(25);
              ((long[]) buf[25])[0] = rslt.getLong(26);
              ((short[]) buf[26])[0] = rslt.getShort(27);
              ((bool[]) buf[27])[0] = rslt.wasNull(27);
              return;
           case 5 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 80);
              ((string[]) buf[2])[0] = rslt.getLongVarchar(3);
              ((DateTime[]) buf[3])[0] = rslt.getGXDate(4);
              ((DateTime[]) buf[4])[0] = rslt.getGXDate(5);
              ((DateTime[]) buf[5])[0] = rslt.getGXDate(6);
              ((string[]) buf[6])[0] = rslt.getString(7, 100);
              ((DateTime[]) buf[7])[0] = rslt.getGXDate(8);
              ((string[]) buf[8])[0] = rslt.getString(9, 8);
              ((string[]) buf[9])[0] = rslt.getVarchar(10);
              ((string[]) buf[10])[0] = rslt.getVarchar(11);
              ((string[]) buf[11])[0] = rslt.getVarchar(12);
              ((string[]) buf[12])[0] = rslt.getVarchar(13);
              ((string[]) buf[13])[0] = rslt.getString(14, 1);
              ((decimal[]) buf[14])[0] = rslt.getDecimal(15);
              ((DateTime[]) buf[15])[0] = rslt.getGXDate(16);
              ((string[]) buf[16])[0] = rslt.getVarchar(17);
              ((string[]) buf[17])[0] = rslt.getVarchar(18);
              ((string[]) buf[18])[0] = rslt.getVarchar(19);
              ((string[]) buf[19])[0] = rslt.getVarchar(20);
              ((string[]) buf[20])[0] = rslt.getVarchar(21);
              ((string[]) buf[21])[0] = rslt.getString(22, 3);
              ((short[]) buf[22])[0] = rslt.getShort(23);
              ((short[]) buf[23])[0] = rslt.getShort(24);
              ((long[]) buf[24])[0] = rslt.getLong(25);
              ((long[]) buf[25])[0] = rslt.getLong(26);
              ((short[]) buf[26])[0] = rslt.getShort(27);
              ((bool[]) buf[27])[0] = rslt.wasNull(27);
              return;
           case 6 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 7 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              return;
           case 8 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 80);
              ((string[]) buf[2])[0] = rslt.getLongVarchar(3);
              ((DateTime[]) buf[3])[0] = rslt.getGXDate(4);
              ((DateTime[]) buf[4])[0] = rslt.getGXDate(5);
              ((DateTime[]) buf[5])[0] = rslt.getGXDate(6);
              ((string[]) buf[6])[0] = rslt.getString(7, 100);
              ((DateTime[]) buf[7])[0] = rslt.getGXDate(8);
              ((string[]) buf[8])[0] = rslt.getString(9, 8);
              ((string[]) buf[9])[0] = rslt.getVarchar(10);
              ((string[]) buf[10])[0] = rslt.getVarchar(11);
              ((string[]) buf[11])[0] = rslt.getVarchar(12);
              ((string[]) buf[12])[0] = rslt.getVarchar(13);
              ((string[]) buf[13])[0] = rslt.getString(14, 1);
              ((decimal[]) buf[14])[0] = rslt.getDecimal(15);
              ((string[]) buf[15])[0] = rslt.getString(16, 3);
              ((DateTime[]) buf[16])[0] = rslt.getGXDate(17);
              ((string[]) buf[17])[0] = rslt.getVarchar(18);
              ((string[]) buf[18])[0] = rslt.getVarchar(19);
              ((string[]) buf[19])[0] = rslt.getVarchar(20);
              ((string[]) buf[20])[0] = rslt.getVarchar(21);
              ((string[]) buf[21])[0] = rslt.getVarchar(22);
              ((string[]) buf[22])[0] = rslt.getString(23, 3);
              ((short[]) buf[23])[0] = rslt.getShort(24);
              ((short[]) buf[24])[0] = rslt.getShort(25);
              ((long[]) buf[25])[0] = rslt.getLong(26);
              ((long[]) buf[26])[0] = rslt.getLong(27);
              ((short[]) buf[27])[0] = rslt.getShort(28);
              ((bool[]) buf[28])[0] = rslt.wasNull(28);
              return;
           case 9 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 10 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 13 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              return;
           case 14 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 80);
              ((string[]) buf[2])[0] = rslt.getLongVarchar(3);
              ((DateTime[]) buf[3])[0] = rslt.getGXDate(4);
              ((DateTime[]) buf[4])[0] = rslt.getGXDate(5);
              ((DateTime[]) buf[5])[0] = rslt.getGXDate(6);
              ((string[]) buf[6])[0] = rslt.getString(7, 100);
              ((DateTime[]) buf[7])[0] = rslt.getGXDate(8);
              ((string[]) buf[8])[0] = rslt.getString(9, 8);
              ((string[]) buf[9])[0] = rslt.getVarchar(10);
              ((string[]) buf[10])[0] = rslt.getVarchar(11);
              ((string[]) buf[11])[0] = rslt.getVarchar(12);
              ((string[]) buf[12])[0] = rslt.getVarchar(13);
              ((string[]) buf[13])[0] = rslt.getString(14, 1);
              ((decimal[]) buf[14])[0] = rslt.getDecimal(15);
              ((string[]) buf[15])[0] = rslt.getString(16, 3);
              ((DateTime[]) buf[16])[0] = rslt.getGXDate(17);
              ((string[]) buf[17])[0] = rslt.getVarchar(18);
              ((string[]) buf[18])[0] = rslt.getVarchar(19);
              ((string[]) buf[19])[0] = rslt.getVarchar(20);
              ((string[]) buf[20])[0] = rslt.getVarchar(21);
              ((string[]) buf[21])[0] = rslt.getVarchar(22);
              ((string[]) buf[22])[0] = rslt.getString(23, 3);
              ((short[]) buf[23])[0] = rslt.getShort(24);
              ((short[]) buf[24])[0] = rslt.getShort(25);
              ((long[]) buf[25])[0] = rslt.getLong(26);
              ((long[]) buf[26])[0] = rslt.getLong(27);
              ((short[]) buf[27])[0] = rslt.getShort(28);
              ((bool[]) buf[28])[0] = rslt.wasNull(28);
              return;
           case 15 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              return;
           case 16 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              return;
           case 20 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              return;
           case 21 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              return;
           case 22 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              return;
           case 26 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              return;
     }
  }

}

}

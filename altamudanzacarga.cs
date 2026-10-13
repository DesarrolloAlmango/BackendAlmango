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
namespace GeneXus.Programs {
   public class altamudanzacarga : GXProcedure
   {
      public altamudanzacarga( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public altamudanzacarga( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( long aP0_MudanzaId ,
                           string aP1_Gx_mode )
      {
         this.AV12MudanzaId = aP0_MudanzaId;
         this.Gx_mode = aP1_Gx_mode;
         initialize();
         ExecutePrivate();
      }

      public void executeSubmit( long aP0_MudanzaId ,
                                 string aP1_Gx_mode )
      {
         this.AV12MudanzaId = aP0_MudanzaId;
         this.Gx_mode = aP1_Gx_mode;
         SubmitImpl();
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV8SDTCargaJson = AV9WebSession.Get(context.GetMessage( "SDTCargaJson1", ""));
         AV10SDTCarga.FromJSonString(AV8SDTCargaJson, null);
         AV15GXV1 = 1;
         while ( AV15GXV1 <= AV10SDTCarga.Count )
         {
            AV11SDTCargaItem = ((SdtSDTCarga_SDTCargaItem)AV10SDTCarga.Item(AV15GXV1));
            if ( AV11SDTCargaItem.gxTpr_Cantidad > 0 )
            {
               if ( StringUtil.StrCmp(Gx_mode, context.GetMessage( "INS", "")) == 0 )
               {
                  /*
                     INSERT RECORD ON TABLE MudanzaCarga

                  */
                  A735MudanzaId = AV12MudanzaId;
                  A751ItemCargaId = AV11SDTCargaItem.gxTpr_Id;
                  A753ItemCargaCantidad = AV11SDTCargaItem.gxTpr_Cantidad;
                  A813ItemCargaEmbCant = AV11SDTCargaItem.gxTpr_Embalajecant;
                  n813ItemCargaEmbCant = false;
                  A816ItemCargaElevacion = AV11SDTCargaItem.gxTpr_Elevacion;
                  A815ItemCargaEmbalaje = AV11SDTCargaItem.gxTpr_Embalaje;
                  A814ItemCargaElevCant = AV11SDTCargaItem.gxTpr_Elevacioncant;
                  n814ItemCargaElevCant = false;
                  /* Using cursor P00FQ2 */
                  pr_default.execute(0, new Object[] {A735MudanzaId, A751ItemCargaId, A753ItemCargaCantidad, n813ItemCargaEmbCant, A813ItemCargaEmbCant, n814ItemCargaElevCant, A814ItemCargaElevCant, A815ItemCargaEmbalaje, A816ItemCargaElevacion});
                  pr_default.close(0);
                  pr_default.SmartCacheProvider.SetUpdated("MudanzaCarga");
                  if ( (pr_default.getStatus(0) == 1) )
                  {
                     context.Gx_err = 1;
                     Gx_emsg = (string)(context.GetMessage( "GXM_noupdate", ""));
                  }
                  else
                  {
                     context.Gx_err = 0;
                     Gx_emsg = "";
                  }
                  /* End Insert */
               }
            }
            if ( StringUtil.StrCmp(Gx_mode, context.GetMessage( "UPD", "")) == 0 )
            {
               AV16GXLvl18 = 0;
               n814ItemCargaElevCant = false;
               n813ItemCargaEmbCant = false;
               /* Optimized UPDATE. */
               /* Using cursor P00FQ3 */
               pr_default.execute(1, new Object[] {n814ItemCargaElevCant, AV11SDTCargaItem.gxTpr_Elevacioncant, AV11SDTCargaItem.gxTpr_Embalaje, AV11SDTCargaItem.gxTpr_Elevacion, n813ItemCargaEmbCant, AV11SDTCargaItem.gxTpr_Embalajecant, AV11SDTCargaItem.gxTpr_Cantidad, AV12MudanzaId, AV11SDTCargaItem.gxTpr_Id});
               if ( (pr_default.getStatus(1) != 101) )
               {
                  AV16GXLvl18 = 1;
               }
               pr_default.close(1);
               pr_default.SmartCacheProvider.SetUpdated("MudanzaCarga");
               /* End optimized UPDATE. */
               if ( AV16GXLvl18 == 0 )
               {
                  if ( AV11SDTCargaItem.gxTpr_Cantidad > 0 )
                  {
                     /*
                        INSERT RECORD ON TABLE MudanzaCarga

                     */
                     A735MudanzaId = AV12MudanzaId;
                     A751ItemCargaId = AV11SDTCargaItem.gxTpr_Id;
                     A753ItemCargaCantidad = AV11SDTCargaItem.gxTpr_Cantidad;
                     A813ItemCargaEmbCant = AV11SDTCargaItem.gxTpr_Embalajecant;
                     n813ItemCargaEmbCant = false;
                     A816ItemCargaElevacion = AV11SDTCargaItem.gxTpr_Elevacion;
                     A815ItemCargaEmbalaje = AV11SDTCargaItem.gxTpr_Embalaje;
                     A814ItemCargaElevCant = AV11SDTCargaItem.gxTpr_Elevacioncant;
                     n814ItemCargaElevCant = false;
                     /* Using cursor P00FQ4 */
                     pr_default.execute(2, new Object[] {A735MudanzaId, A751ItemCargaId, A753ItemCargaCantidad, n813ItemCargaEmbCant, A813ItemCargaEmbCant, n814ItemCargaElevCant, A814ItemCargaElevCant, A815ItemCargaEmbalaje, A816ItemCargaElevacion});
                     pr_default.close(2);
                     pr_default.SmartCacheProvider.SetUpdated("MudanzaCarga");
                     if ( (pr_default.getStatus(2) == 1) )
                     {
                        context.Gx_err = 1;
                        Gx_emsg = (string)(context.GetMessage( "GXM_noupdate", ""));
                     }
                     else
                     {
                        context.Gx_err = 0;
                        Gx_emsg = "";
                     }
                     /* End Insert */
                  }
               }
            }
            AV15GXV1 = (int)(AV15GXV1+1);
         }
         AV8SDTCargaJson = AV9WebSession.Get(context.GetMessage( "SDTCargaJson2", ""));
         AV10SDTCarga.FromJSonString(AV8SDTCargaJson, null);
         AV17GXV2 = 1;
         while ( AV17GXV2 <= AV10SDTCarga.Count )
         {
            AV11SDTCargaItem = ((SdtSDTCarga_SDTCargaItem)AV10SDTCarga.Item(AV17GXV2));
            if ( AV11SDTCargaItem.gxTpr_Cantidad > 0 )
            {
               if ( StringUtil.StrCmp(Gx_mode, context.GetMessage( "INS", "")) == 0 )
               {
                  /*
                     INSERT RECORD ON TABLE MudanzaCarga

                  */
                  A735MudanzaId = AV12MudanzaId;
                  A751ItemCargaId = AV11SDTCargaItem.gxTpr_Id;
                  A753ItemCargaCantidad = AV11SDTCargaItem.gxTpr_Cantidad;
                  A813ItemCargaEmbCant = AV11SDTCargaItem.gxTpr_Embalajecant;
                  n813ItemCargaEmbCant = false;
                  A814ItemCargaElevCant = AV11SDTCargaItem.gxTpr_Elevacioncant;
                  n814ItemCargaElevCant = false;
                  A816ItemCargaElevacion = AV11SDTCargaItem.gxTpr_Elevacion;
                  A815ItemCargaEmbalaje = AV11SDTCargaItem.gxTpr_Embalaje;
                  /* Using cursor P00FQ5 */
                  pr_default.execute(3, new Object[] {A735MudanzaId, A751ItemCargaId, A753ItemCargaCantidad, n813ItemCargaEmbCant, A813ItemCargaEmbCant, n814ItemCargaElevCant, A814ItemCargaElevCant, A815ItemCargaEmbalaje, A816ItemCargaElevacion});
                  pr_default.close(3);
                  pr_default.SmartCacheProvider.SetUpdated("MudanzaCarga");
                  if ( (pr_default.getStatus(3) == 1) )
                  {
                     context.Gx_err = 1;
                     Gx_emsg = (string)(context.GetMessage( "GXM_noupdate", ""));
                  }
                  else
                  {
                     context.Gx_err = 0;
                     Gx_emsg = "";
                  }
                  /* End Insert */
               }
            }
            if ( StringUtil.StrCmp(Gx_mode, context.GetMessage( "UPD", "")) == 0 )
            {
               AV18GXLvl61 = 0;
               n814ItemCargaElevCant = false;
               n813ItemCargaEmbCant = false;
               /* Optimized UPDATE. */
               /* Using cursor P00FQ6 */
               pr_default.execute(4, new Object[] {AV11SDTCargaItem.gxTpr_Embalaje, AV11SDTCargaItem.gxTpr_Elevacion, n814ItemCargaElevCant, AV11SDTCargaItem.gxTpr_Elevacioncant, n813ItemCargaEmbCant, AV11SDTCargaItem.gxTpr_Embalajecant, AV11SDTCargaItem.gxTpr_Cantidad, AV12MudanzaId, AV11SDTCargaItem.gxTpr_Id});
               if ( (pr_default.getStatus(4) != 101) )
               {
                  AV18GXLvl61 = 1;
               }
               pr_default.close(4);
               pr_default.SmartCacheProvider.SetUpdated("MudanzaCarga");
               /* End optimized UPDATE. */
               if ( AV18GXLvl61 == 0 )
               {
                  if ( AV11SDTCargaItem.gxTpr_Cantidad > 0 )
                  {
                     /*
                        INSERT RECORD ON TABLE MudanzaCarga

                     */
                     A735MudanzaId = AV12MudanzaId;
                     A751ItemCargaId = AV11SDTCargaItem.gxTpr_Id;
                     A753ItemCargaCantidad = AV11SDTCargaItem.gxTpr_Cantidad;
                     A813ItemCargaEmbCant = AV11SDTCargaItem.gxTpr_Embalajecant;
                     n813ItemCargaEmbCant = false;
                     A814ItemCargaElevCant = AV11SDTCargaItem.gxTpr_Elevacioncant;
                     n814ItemCargaElevCant = false;
                     A816ItemCargaElevacion = AV11SDTCargaItem.gxTpr_Elevacion;
                     A815ItemCargaEmbalaje = AV11SDTCargaItem.gxTpr_Embalaje;
                     /* Using cursor P00FQ7 */
                     pr_default.execute(5, new Object[] {A735MudanzaId, A751ItemCargaId, A753ItemCargaCantidad, n813ItemCargaEmbCant, A813ItemCargaEmbCant, n814ItemCargaElevCant, A814ItemCargaElevCant, A815ItemCargaEmbalaje, A816ItemCargaElevacion});
                     pr_default.close(5);
                     pr_default.SmartCacheProvider.SetUpdated("MudanzaCarga");
                     if ( (pr_default.getStatus(5) == 1) )
                     {
                        context.Gx_err = 1;
                        Gx_emsg = (string)(context.GetMessage( "GXM_noupdate", ""));
                     }
                     else
                     {
                        context.Gx_err = 0;
                        Gx_emsg = "";
                     }
                     /* End Insert */
                  }
               }
            }
            AV17GXV2 = (int)(AV17GXV2+1);
         }
         AV8SDTCargaJson = AV9WebSession.Get(context.GetMessage( "SDTCargaJson3", ""));
         AV10SDTCarga.FromJSonString(AV8SDTCargaJson, null);
         AV19GXV3 = 1;
         while ( AV19GXV3 <= AV10SDTCarga.Count )
         {
            AV11SDTCargaItem = ((SdtSDTCarga_SDTCargaItem)AV10SDTCarga.Item(AV19GXV3));
            if ( AV11SDTCargaItem.gxTpr_Cantidad > 0 )
            {
               if ( StringUtil.StrCmp(Gx_mode, context.GetMessage( "INS", "")) == 0 )
               {
                  /*
                     INSERT RECORD ON TABLE MudanzaCarga

                  */
                  A735MudanzaId = AV12MudanzaId;
                  A751ItemCargaId = AV11SDTCargaItem.gxTpr_Id;
                  A753ItemCargaCantidad = AV11SDTCargaItem.gxTpr_Cantidad;
                  A813ItemCargaEmbCant = AV11SDTCargaItem.gxTpr_Embalajecant;
                  n813ItemCargaEmbCant = false;
                  A814ItemCargaElevCant = AV11SDTCargaItem.gxTpr_Elevacioncant;
                  n814ItemCargaElevCant = false;
                  A816ItemCargaElevacion = AV11SDTCargaItem.gxTpr_Elevacion;
                  A815ItemCargaEmbalaje = AV11SDTCargaItem.gxTpr_Embalaje;
                  /* Using cursor P00FQ8 */
                  pr_default.execute(6, new Object[] {A735MudanzaId, A751ItemCargaId, A753ItemCargaCantidad, n813ItemCargaEmbCant, A813ItemCargaEmbCant, n814ItemCargaElevCant, A814ItemCargaElevCant, A815ItemCargaEmbalaje, A816ItemCargaElevacion});
                  pr_default.close(6);
                  pr_default.SmartCacheProvider.SetUpdated("MudanzaCarga");
                  if ( (pr_default.getStatus(6) == 1) )
                  {
                     context.Gx_err = 1;
                     Gx_emsg = (string)(context.GetMessage( "GXM_noupdate", ""));
                  }
                  else
                  {
                     context.Gx_err = 0;
                     Gx_emsg = "";
                  }
                  /* End Insert */
               }
            }
            if ( StringUtil.StrCmp(Gx_mode, context.GetMessage( "UPD", "")) == 0 )
            {
               AV20GXLvl102 = 0;
               n814ItemCargaElevCant = false;
               n813ItemCargaEmbCant = false;
               /* Optimized UPDATE. */
               /* Using cursor P00FQ9 */
               pr_default.execute(7, new Object[] {AV11SDTCargaItem.gxTpr_Embalaje, AV11SDTCargaItem.gxTpr_Elevacion, n814ItemCargaElevCant, AV11SDTCargaItem.gxTpr_Elevacioncant, n813ItemCargaEmbCant, AV11SDTCargaItem.gxTpr_Embalajecant, AV11SDTCargaItem.gxTpr_Cantidad, AV12MudanzaId, AV11SDTCargaItem.gxTpr_Id});
               if ( (pr_default.getStatus(7) != 101) )
               {
                  AV20GXLvl102 = 1;
               }
               pr_default.close(7);
               pr_default.SmartCacheProvider.SetUpdated("MudanzaCarga");
               /* End optimized UPDATE. */
               if ( AV20GXLvl102 == 0 )
               {
                  if ( AV11SDTCargaItem.gxTpr_Cantidad > 0 )
                  {
                     /*
                        INSERT RECORD ON TABLE MudanzaCarga

                     */
                     A735MudanzaId = AV12MudanzaId;
                     A751ItemCargaId = AV11SDTCargaItem.gxTpr_Id;
                     A753ItemCargaCantidad = AV11SDTCargaItem.gxTpr_Cantidad;
                     A813ItemCargaEmbCant = AV11SDTCargaItem.gxTpr_Embalajecant;
                     n813ItemCargaEmbCant = false;
                     A814ItemCargaElevCant = AV11SDTCargaItem.gxTpr_Elevacioncant;
                     n814ItemCargaElevCant = false;
                     A816ItemCargaElevacion = AV11SDTCargaItem.gxTpr_Elevacion;
                     A815ItemCargaEmbalaje = AV11SDTCargaItem.gxTpr_Embalaje;
                     /* Using cursor P00FQ10 */
                     pr_default.execute(8, new Object[] {A735MudanzaId, A751ItemCargaId, A753ItemCargaCantidad, n813ItemCargaEmbCant, A813ItemCargaEmbCant, n814ItemCargaElevCant, A814ItemCargaElevCant, A815ItemCargaEmbalaje, A816ItemCargaElevacion});
                     pr_default.close(8);
                     pr_default.SmartCacheProvider.SetUpdated("MudanzaCarga");
                     if ( (pr_default.getStatus(8) == 1) )
                     {
                        context.Gx_err = 1;
                        Gx_emsg = (string)(context.GetMessage( "GXM_noupdate", ""));
                     }
                     else
                     {
                        context.Gx_err = 0;
                        Gx_emsg = "";
                     }
                     /* End Insert */
                  }
               }
            }
            AV19GXV3 = (int)(AV19GXV3+1);
         }
         AV8SDTCargaJson = AV9WebSession.Get(context.GetMessage( "SDTCargaJson4", ""));
         AV10SDTCarga.FromJSonString(AV8SDTCargaJson, null);
         AV21GXV4 = 1;
         while ( AV21GXV4 <= AV10SDTCarga.Count )
         {
            AV11SDTCargaItem = ((SdtSDTCarga_SDTCargaItem)AV10SDTCarga.Item(AV21GXV4));
            if ( AV11SDTCargaItem.gxTpr_Cantidad > 0 )
            {
               if ( StringUtil.StrCmp(Gx_mode, context.GetMessage( "INS", "")) == 0 )
               {
                  /*
                     INSERT RECORD ON TABLE MudanzaCarga

                  */
                  A735MudanzaId = AV12MudanzaId;
                  A751ItemCargaId = AV11SDTCargaItem.gxTpr_Id;
                  A753ItemCargaCantidad = AV11SDTCargaItem.gxTpr_Cantidad;
                  A813ItemCargaEmbCant = AV11SDTCargaItem.gxTpr_Embalajecant;
                  n813ItemCargaEmbCant = false;
                  A814ItemCargaElevCant = AV11SDTCargaItem.gxTpr_Elevacioncant;
                  n814ItemCargaElevCant = false;
                  A816ItemCargaElevacion = AV11SDTCargaItem.gxTpr_Elevacion;
                  A815ItemCargaEmbalaje = AV11SDTCargaItem.gxTpr_Embalaje;
                  /* Using cursor P00FQ11 */
                  pr_default.execute(9, new Object[] {A735MudanzaId, A751ItemCargaId, A753ItemCargaCantidad, n813ItemCargaEmbCant, A813ItemCargaEmbCant, n814ItemCargaElevCant, A814ItemCargaElevCant, A815ItemCargaEmbalaje, A816ItemCargaElevacion});
                  pr_default.close(9);
                  pr_default.SmartCacheProvider.SetUpdated("MudanzaCarga");
                  if ( (pr_default.getStatus(9) == 1) )
                  {
                     context.Gx_err = 1;
                     Gx_emsg = (string)(context.GetMessage( "GXM_noupdate", ""));
                  }
                  else
                  {
                     context.Gx_err = 0;
                     Gx_emsg = "";
                  }
                  /* End Insert */
               }
            }
            if ( StringUtil.StrCmp(Gx_mode, context.GetMessage( "UPD", "")) == 0 )
            {
               AV22GXLvl144 = 0;
               n814ItemCargaElevCant = false;
               n813ItemCargaEmbCant = false;
               /* Optimized UPDATE. */
               /* Using cursor P00FQ12 */
               pr_default.execute(10, new Object[] {AV11SDTCargaItem.gxTpr_Embalaje, AV11SDTCargaItem.gxTpr_Elevacion, n814ItemCargaElevCant, AV11SDTCargaItem.gxTpr_Elevacioncant, n813ItemCargaEmbCant, AV11SDTCargaItem.gxTpr_Embalajecant, AV11SDTCargaItem.gxTpr_Cantidad, AV12MudanzaId, AV11SDTCargaItem.gxTpr_Id});
               if ( (pr_default.getStatus(10) != 101) )
               {
                  AV22GXLvl144 = 1;
               }
               pr_default.close(10);
               pr_default.SmartCacheProvider.SetUpdated("MudanzaCarga");
               /* End optimized UPDATE. */
               if ( AV22GXLvl144 == 0 )
               {
                  if ( AV11SDTCargaItem.gxTpr_Cantidad > 0 )
                  {
                     /*
                        INSERT RECORD ON TABLE MudanzaCarga

                     */
                     A735MudanzaId = AV12MudanzaId;
                     A751ItemCargaId = AV11SDTCargaItem.gxTpr_Id;
                     A753ItemCargaCantidad = AV11SDTCargaItem.gxTpr_Cantidad;
                     A813ItemCargaEmbCant = AV11SDTCargaItem.gxTpr_Embalajecant;
                     n813ItemCargaEmbCant = false;
                     A814ItemCargaElevCant = AV11SDTCargaItem.gxTpr_Elevacioncant;
                     n814ItemCargaElevCant = false;
                     A816ItemCargaElevacion = AV11SDTCargaItem.gxTpr_Elevacion;
                     A815ItemCargaEmbalaje = AV11SDTCargaItem.gxTpr_Embalaje;
                     /* Using cursor P00FQ13 */
                     pr_default.execute(11, new Object[] {A735MudanzaId, A751ItemCargaId, A753ItemCargaCantidad, n813ItemCargaEmbCant, A813ItemCargaEmbCant, n814ItemCargaElevCant, A814ItemCargaElevCant, A815ItemCargaEmbalaje, A816ItemCargaElevacion});
                     pr_default.close(11);
                     pr_default.SmartCacheProvider.SetUpdated("MudanzaCarga");
                     if ( (pr_default.getStatus(11) == 1) )
                     {
                        context.Gx_err = 1;
                        Gx_emsg = (string)(context.GetMessage( "GXM_noupdate", ""));
                     }
                     else
                     {
                        context.Gx_err = 0;
                        Gx_emsg = "";
                     }
                     /* End Insert */
                  }
               }
            }
            AV21GXV4 = (int)(AV21GXV4+1);
         }
         AV8SDTCargaJson = AV9WebSession.Get(context.GetMessage( "SDTCargaJson5", ""));
         AV10SDTCarga.FromJSonString(AV8SDTCargaJson, null);
         AV23GXV5 = 1;
         while ( AV23GXV5 <= AV10SDTCarga.Count )
         {
            AV11SDTCargaItem = ((SdtSDTCarga_SDTCargaItem)AV10SDTCarga.Item(AV23GXV5));
            if ( AV11SDTCargaItem.gxTpr_Cantidad > 0 )
            {
               if ( StringUtil.StrCmp(Gx_mode, context.GetMessage( "INS", "")) == 0 )
               {
                  /*
                     INSERT RECORD ON TABLE MudanzaCarga

                  */
                  A735MudanzaId = AV12MudanzaId;
                  A751ItemCargaId = AV11SDTCargaItem.gxTpr_Id;
                  A753ItemCargaCantidad = AV11SDTCargaItem.gxTpr_Cantidad;
                  A813ItemCargaEmbCant = AV11SDTCargaItem.gxTpr_Embalajecant;
                  n813ItemCargaEmbCant = false;
                  A814ItemCargaElevCant = AV11SDTCargaItem.gxTpr_Elevacioncant;
                  n814ItemCargaElevCant = false;
                  A816ItemCargaElevacion = AV11SDTCargaItem.gxTpr_Elevacion;
                  A815ItemCargaEmbalaje = AV11SDTCargaItem.gxTpr_Embalaje;
                  /* Using cursor P00FQ14 */
                  pr_default.execute(12, new Object[] {A735MudanzaId, A751ItemCargaId, A753ItemCargaCantidad, n813ItemCargaEmbCant, A813ItemCargaEmbCant, n814ItemCargaElevCant, A814ItemCargaElevCant, A815ItemCargaEmbalaje, A816ItemCargaElevacion});
                  pr_default.close(12);
                  pr_default.SmartCacheProvider.SetUpdated("MudanzaCarga");
                  if ( (pr_default.getStatus(12) == 1) )
                  {
                     context.Gx_err = 1;
                     Gx_emsg = (string)(context.GetMessage( "GXM_noupdate", ""));
                  }
                  else
                  {
                     context.Gx_err = 0;
                     Gx_emsg = "";
                  }
                  /* End Insert */
               }
            }
            if ( StringUtil.StrCmp(Gx_mode, context.GetMessage( "UPD", "")) == 0 )
            {
               AV24GXLvl185 = 0;
               n814ItemCargaElevCant = false;
               n813ItemCargaEmbCant = false;
               /* Optimized UPDATE. */
               /* Using cursor P00FQ15 */
               pr_default.execute(13, new Object[] {AV11SDTCargaItem.gxTpr_Embalaje, AV11SDTCargaItem.gxTpr_Elevacion, n814ItemCargaElevCant, AV11SDTCargaItem.gxTpr_Elevacioncant, n813ItemCargaEmbCant, AV11SDTCargaItem.gxTpr_Embalajecant, AV11SDTCargaItem.gxTpr_Cantidad, AV12MudanzaId, AV11SDTCargaItem.gxTpr_Id});
               if ( (pr_default.getStatus(13) != 101) )
               {
                  AV24GXLvl185 = 1;
               }
               pr_default.close(13);
               pr_default.SmartCacheProvider.SetUpdated("MudanzaCarga");
               /* End optimized UPDATE. */
               if ( AV24GXLvl185 == 0 )
               {
                  if ( AV11SDTCargaItem.gxTpr_Cantidad > 0 )
                  {
                     /*
                        INSERT RECORD ON TABLE MudanzaCarga

                     */
                     A735MudanzaId = AV12MudanzaId;
                     A751ItemCargaId = AV11SDTCargaItem.gxTpr_Id;
                     A753ItemCargaCantidad = AV11SDTCargaItem.gxTpr_Cantidad;
                     A813ItemCargaEmbCant = AV11SDTCargaItem.gxTpr_Embalajecant;
                     n813ItemCargaEmbCant = false;
                     A814ItemCargaElevCant = AV11SDTCargaItem.gxTpr_Elevacioncant;
                     n814ItemCargaElevCant = false;
                     A816ItemCargaElevacion = AV11SDTCargaItem.gxTpr_Elevacion;
                     A815ItemCargaEmbalaje = AV11SDTCargaItem.gxTpr_Embalaje;
                     /* Using cursor P00FQ16 */
                     pr_default.execute(14, new Object[] {A735MudanzaId, A751ItemCargaId, A753ItemCargaCantidad, n813ItemCargaEmbCant, A813ItemCargaEmbCant, n814ItemCargaElevCant, A814ItemCargaElevCant, A815ItemCargaEmbalaje, A816ItemCargaElevacion});
                     pr_default.close(14);
                     pr_default.SmartCacheProvider.SetUpdated("MudanzaCarga");
                     if ( (pr_default.getStatus(14) == 1) )
                     {
                        context.Gx_err = 1;
                        Gx_emsg = (string)(context.GetMessage( "GXM_noupdate", ""));
                     }
                     else
                     {
                        context.Gx_err = 0;
                        Gx_emsg = "";
                     }
                     /* End Insert */
                  }
               }
            }
            AV23GXV5 = (int)(AV23GXV5+1);
         }
         context.CommitDataStores("altamudanzacarga",pr_default);
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
         AV8SDTCargaJson = "";
         AV9WebSession = context.GetSession();
         AV10SDTCarga = new GXBaseCollection<SdtSDTCarga_SDTCargaItem>( context, "SDTCargaItem", "AlmangoX");
         AV11SDTCargaItem = new SdtSDTCarga_SDTCargaItem(context);
         Gx_emsg = "";
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.altamudanzacarga__datastore1(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.altamudanzacarga__default(),
            new Object[][] {
                new Object[] {
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
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short A751ItemCargaId ;
      private short A753ItemCargaCantidad ;
      private short A813ItemCargaEmbCant ;
      private short A814ItemCargaElevCant ;
      private short AV16GXLvl18 ;
      private short AV18GXLvl61 ;
      private short AV20GXLvl102 ;
      private short AV22GXLvl144 ;
      private short AV24GXLvl185 ;
      private int AV15GXV1 ;
      private int GX_INS120 ;
      private int AV17GXV2 ;
      private int AV19GXV3 ;
      private int AV21GXV4 ;
      private int AV23GXV5 ;
      private long AV12MudanzaId ;
      private long A735MudanzaId ;
      private string Gx_mode ;
      private string Gx_emsg ;
      private bool n813ItemCargaEmbCant ;
      private bool A816ItemCargaElevacion ;
      private bool A815ItemCargaEmbalaje ;
      private bool n814ItemCargaElevCant ;
      private string AV8SDTCargaJson ;
      private IGxSession AV9WebSession ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GXBaseCollection<SdtSDTCarga_SDTCargaItem> AV10SDTCarga ;
      private SdtSDTCarga_SDTCargaItem AV11SDTCargaItem ;
      private IDataStoreProvider pr_default ;
      private IDataStoreProvider pr_datastore1 ;
   }

   public class altamudanzacarga__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class altamudanzacarga__default : DataStoreHelperBase, IDataStoreHelper
 {
    public ICursor[] getCursors( )
    {
       cursorDefinitions();
       return new Cursor[] {
        new UpdateCursor(def[0])
       ,new UpdateCursor(def[1])
       ,new UpdateCursor(def[2])
       ,new UpdateCursor(def[3])
       ,new UpdateCursor(def[4])
       ,new UpdateCursor(def[5])
       ,new UpdateCursor(def[6])
       ,new UpdateCursor(def[7])
       ,new UpdateCursor(def[8])
       ,new UpdateCursor(def[9])
       ,new UpdateCursor(def[10])
       ,new UpdateCursor(def[11])
       ,new UpdateCursor(def[12])
       ,new UpdateCursor(def[13])
       ,new UpdateCursor(def[14])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmP00FQ2;
        prmP00FQ2 = new Object[] {
        new ParDef("@MudanzaId",GXType.Decimal,18,0) ,
        new ParDef("@ItemCargaId",GXType.Int16,4,0) ,
        new ParDef("@ItemCargaCantidad",GXType.Int16,4,0) ,
        new ParDef("@ItemCargaEmbCant",GXType.Int16,4,0){Nullable=true} ,
        new ParDef("@ItemCargaElevCant",GXType.Int16,4,0){Nullable=true} ,
        new ParDef("@ItemCargaEmbalaje",GXType.Boolean,4,0) ,
        new ParDef("@ItemCargaElevacion",GXType.Boolean,4,0)
        };
        Object[] prmP00FQ3;
        prmP00FQ3 = new Object[] {
        new ParDef("@ItemCargaElevCant",GXType.Int16,4,0){Nullable=true} ,
        new ParDef("@ItemCargaEmbalaje",GXType.Boolean,4,0) ,
        new ParDef("@ItemCargaElevacion",GXType.Boolean,4,0) ,
        new ParDef("@ItemCargaEmbCant",GXType.Int16,4,0){Nullable=true} ,
        new ParDef("@ItemCargaCantidad",GXType.Int16,4,0) ,
        new ParDef("@AV12MudanzaId",GXType.Decimal,18,0) ,
        new ParDef("@AV11SDTCargaItem__Id",GXType.Int16,4,0)
        };
        Object[] prmP00FQ4;
        prmP00FQ4 = new Object[] {
        new ParDef("@MudanzaId",GXType.Decimal,18,0) ,
        new ParDef("@ItemCargaId",GXType.Int16,4,0) ,
        new ParDef("@ItemCargaCantidad",GXType.Int16,4,0) ,
        new ParDef("@ItemCargaEmbCant",GXType.Int16,4,0){Nullable=true} ,
        new ParDef("@ItemCargaElevCant",GXType.Int16,4,0){Nullable=true} ,
        new ParDef("@ItemCargaEmbalaje",GXType.Boolean,4,0) ,
        new ParDef("@ItemCargaElevacion",GXType.Boolean,4,0)
        };
        Object[] prmP00FQ5;
        prmP00FQ5 = new Object[] {
        new ParDef("@MudanzaId",GXType.Decimal,18,0) ,
        new ParDef("@ItemCargaId",GXType.Int16,4,0) ,
        new ParDef("@ItemCargaCantidad",GXType.Int16,4,0) ,
        new ParDef("@ItemCargaEmbCant",GXType.Int16,4,0){Nullable=true} ,
        new ParDef("@ItemCargaElevCant",GXType.Int16,4,0){Nullable=true} ,
        new ParDef("@ItemCargaEmbalaje",GXType.Boolean,4,0) ,
        new ParDef("@ItemCargaElevacion",GXType.Boolean,4,0)
        };
        Object[] prmP00FQ6;
        prmP00FQ6 = new Object[] {
        new ParDef("@ItemCargaEmbalaje",GXType.Boolean,4,0) ,
        new ParDef("@ItemCargaElevacion",GXType.Boolean,4,0) ,
        new ParDef("@ItemCargaElevCant",GXType.Int16,4,0){Nullable=true} ,
        new ParDef("@ItemCargaEmbCant",GXType.Int16,4,0){Nullable=true} ,
        new ParDef("@ItemCargaCantidad",GXType.Int16,4,0) ,
        new ParDef("@AV12MudanzaId",GXType.Decimal,18,0) ,
        new ParDef("@AV11SDTCargaItem__Id",GXType.Int16,4,0)
        };
        Object[] prmP00FQ7;
        prmP00FQ7 = new Object[] {
        new ParDef("@MudanzaId",GXType.Decimal,18,0) ,
        new ParDef("@ItemCargaId",GXType.Int16,4,0) ,
        new ParDef("@ItemCargaCantidad",GXType.Int16,4,0) ,
        new ParDef("@ItemCargaEmbCant",GXType.Int16,4,0){Nullable=true} ,
        new ParDef("@ItemCargaElevCant",GXType.Int16,4,0){Nullable=true} ,
        new ParDef("@ItemCargaEmbalaje",GXType.Boolean,4,0) ,
        new ParDef("@ItemCargaElevacion",GXType.Boolean,4,0)
        };
        Object[] prmP00FQ8;
        prmP00FQ8 = new Object[] {
        new ParDef("@MudanzaId",GXType.Decimal,18,0) ,
        new ParDef("@ItemCargaId",GXType.Int16,4,0) ,
        new ParDef("@ItemCargaCantidad",GXType.Int16,4,0) ,
        new ParDef("@ItemCargaEmbCant",GXType.Int16,4,0){Nullable=true} ,
        new ParDef("@ItemCargaElevCant",GXType.Int16,4,0){Nullable=true} ,
        new ParDef("@ItemCargaEmbalaje",GXType.Boolean,4,0) ,
        new ParDef("@ItemCargaElevacion",GXType.Boolean,4,0)
        };
        Object[] prmP00FQ9;
        prmP00FQ9 = new Object[] {
        new ParDef("@ItemCargaEmbalaje",GXType.Boolean,4,0) ,
        new ParDef("@ItemCargaElevacion",GXType.Boolean,4,0) ,
        new ParDef("@ItemCargaElevCant",GXType.Int16,4,0){Nullable=true} ,
        new ParDef("@ItemCargaEmbCant",GXType.Int16,4,0){Nullable=true} ,
        new ParDef("@ItemCargaCantidad",GXType.Int16,4,0) ,
        new ParDef("@AV12MudanzaId",GXType.Decimal,18,0) ,
        new ParDef("@AV11SDTCargaItem__Id",GXType.Int16,4,0)
        };
        Object[] prmP00FQ10;
        prmP00FQ10 = new Object[] {
        new ParDef("@MudanzaId",GXType.Decimal,18,0) ,
        new ParDef("@ItemCargaId",GXType.Int16,4,0) ,
        new ParDef("@ItemCargaCantidad",GXType.Int16,4,0) ,
        new ParDef("@ItemCargaEmbCant",GXType.Int16,4,0){Nullable=true} ,
        new ParDef("@ItemCargaElevCant",GXType.Int16,4,0){Nullable=true} ,
        new ParDef("@ItemCargaEmbalaje",GXType.Boolean,4,0) ,
        new ParDef("@ItemCargaElevacion",GXType.Boolean,4,0)
        };
        Object[] prmP00FQ11;
        prmP00FQ11 = new Object[] {
        new ParDef("@MudanzaId",GXType.Decimal,18,0) ,
        new ParDef("@ItemCargaId",GXType.Int16,4,0) ,
        new ParDef("@ItemCargaCantidad",GXType.Int16,4,0) ,
        new ParDef("@ItemCargaEmbCant",GXType.Int16,4,0){Nullable=true} ,
        new ParDef("@ItemCargaElevCant",GXType.Int16,4,0){Nullable=true} ,
        new ParDef("@ItemCargaEmbalaje",GXType.Boolean,4,0) ,
        new ParDef("@ItemCargaElevacion",GXType.Boolean,4,0)
        };
        Object[] prmP00FQ12;
        prmP00FQ12 = new Object[] {
        new ParDef("@ItemCargaEmbalaje",GXType.Boolean,4,0) ,
        new ParDef("@ItemCargaElevacion",GXType.Boolean,4,0) ,
        new ParDef("@ItemCargaElevCant",GXType.Int16,4,0){Nullable=true} ,
        new ParDef("@ItemCargaEmbCant",GXType.Int16,4,0){Nullable=true} ,
        new ParDef("@ItemCargaCantidad",GXType.Int16,4,0) ,
        new ParDef("@AV12MudanzaId",GXType.Decimal,18,0) ,
        new ParDef("@AV11SDTCargaItem__Id",GXType.Int16,4,0)
        };
        Object[] prmP00FQ13;
        prmP00FQ13 = new Object[] {
        new ParDef("@MudanzaId",GXType.Decimal,18,0) ,
        new ParDef("@ItemCargaId",GXType.Int16,4,0) ,
        new ParDef("@ItemCargaCantidad",GXType.Int16,4,0) ,
        new ParDef("@ItemCargaEmbCant",GXType.Int16,4,0){Nullable=true} ,
        new ParDef("@ItemCargaElevCant",GXType.Int16,4,0){Nullable=true} ,
        new ParDef("@ItemCargaEmbalaje",GXType.Boolean,4,0) ,
        new ParDef("@ItemCargaElevacion",GXType.Boolean,4,0)
        };
        Object[] prmP00FQ14;
        prmP00FQ14 = new Object[] {
        new ParDef("@MudanzaId",GXType.Decimal,18,0) ,
        new ParDef("@ItemCargaId",GXType.Int16,4,0) ,
        new ParDef("@ItemCargaCantidad",GXType.Int16,4,0) ,
        new ParDef("@ItemCargaEmbCant",GXType.Int16,4,0){Nullable=true} ,
        new ParDef("@ItemCargaElevCant",GXType.Int16,4,0){Nullable=true} ,
        new ParDef("@ItemCargaEmbalaje",GXType.Boolean,4,0) ,
        new ParDef("@ItemCargaElevacion",GXType.Boolean,4,0)
        };
        Object[] prmP00FQ15;
        prmP00FQ15 = new Object[] {
        new ParDef("@ItemCargaEmbalaje",GXType.Boolean,4,0) ,
        new ParDef("@ItemCargaElevacion",GXType.Boolean,4,0) ,
        new ParDef("@ItemCargaElevCant",GXType.Int16,4,0){Nullable=true} ,
        new ParDef("@ItemCargaEmbCant",GXType.Int16,4,0){Nullable=true} ,
        new ParDef("@ItemCargaCantidad",GXType.Int16,4,0) ,
        new ParDef("@AV12MudanzaId",GXType.Decimal,18,0) ,
        new ParDef("@AV11SDTCargaItem__Id",GXType.Int16,4,0)
        };
        Object[] prmP00FQ16;
        prmP00FQ16 = new Object[] {
        new ParDef("@MudanzaId",GXType.Decimal,18,0) ,
        new ParDef("@ItemCargaId",GXType.Int16,4,0) ,
        new ParDef("@ItemCargaCantidad",GXType.Int16,4,0) ,
        new ParDef("@ItemCargaEmbCant",GXType.Int16,4,0){Nullable=true} ,
        new ParDef("@ItemCargaElevCant",GXType.Int16,4,0){Nullable=true} ,
        new ParDef("@ItemCargaEmbalaje",GXType.Boolean,4,0) ,
        new ParDef("@ItemCargaElevacion",GXType.Boolean,4,0)
        };
        def= new CursorDef[] {
            new CursorDef("P00FQ2", "INSERT INTO [MudanzaCarga]([MudanzaId], [ItemCargaId], [ItemCargaCantidad], [ItemCargaEmbCant], [ItemCargaElevCant], [ItemCargaEmbalaje], [ItemCargaElevacion]) VALUES(@MudanzaId, @ItemCargaId, @ItemCargaCantidad, @ItemCargaEmbCant, @ItemCargaElevCant, @ItemCargaEmbalaje, @ItemCargaElevacion)", GxErrorMask.GX_NOMASK,prmP00FQ2)
           ,new CursorDef("P00FQ3", "UPDATE [MudanzaCarga] SET [ItemCargaElevCant]=@ItemCargaElevCant, [ItemCargaEmbalaje]=@ItemCargaEmbalaje, [ItemCargaElevacion]=@ItemCargaElevacion, [ItemCargaEmbCant]=@ItemCargaEmbCant, [ItemCargaCantidad]=@ItemCargaCantidad  WHERE [MudanzaId] = @AV12MudanzaId and [ItemCargaId] = @AV11SDTCargaItem__Id", GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP00FQ3)
           ,new CursorDef("P00FQ4", "INSERT INTO [MudanzaCarga]([MudanzaId], [ItemCargaId], [ItemCargaCantidad], [ItemCargaEmbCant], [ItemCargaElevCant], [ItemCargaEmbalaje], [ItemCargaElevacion]) VALUES(@MudanzaId, @ItemCargaId, @ItemCargaCantidad, @ItemCargaEmbCant, @ItemCargaElevCant, @ItemCargaEmbalaje, @ItemCargaElevacion)", GxErrorMask.GX_NOMASK,prmP00FQ4)
           ,new CursorDef("P00FQ5", "INSERT INTO [MudanzaCarga]([MudanzaId], [ItemCargaId], [ItemCargaCantidad], [ItemCargaEmbCant], [ItemCargaElevCant], [ItemCargaEmbalaje], [ItemCargaElevacion]) VALUES(@MudanzaId, @ItemCargaId, @ItemCargaCantidad, @ItemCargaEmbCant, @ItemCargaElevCant, @ItemCargaEmbalaje, @ItemCargaElevacion)", GxErrorMask.GX_NOMASK,prmP00FQ5)
           ,new CursorDef("P00FQ6", "UPDATE [MudanzaCarga] SET [ItemCargaEmbalaje]=@ItemCargaEmbalaje, [ItemCargaElevacion]=@ItemCargaElevacion, [ItemCargaElevCant]=@ItemCargaElevCant, [ItemCargaEmbCant]=@ItemCargaEmbCant, [ItemCargaCantidad]=@ItemCargaCantidad  WHERE [MudanzaId] = @AV12MudanzaId and [ItemCargaId] = @AV11SDTCargaItem__Id", GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP00FQ6)
           ,new CursorDef("P00FQ7", "INSERT INTO [MudanzaCarga]([MudanzaId], [ItemCargaId], [ItemCargaCantidad], [ItemCargaEmbCant], [ItemCargaElevCant], [ItemCargaEmbalaje], [ItemCargaElevacion]) VALUES(@MudanzaId, @ItemCargaId, @ItemCargaCantidad, @ItemCargaEmbCant, @ItemCargaElevCant, @ItemCargaEmbalaje, @ItemCargaElevacion)", GxErrorMask.GX_NOMASK,prmP00FQ7)
           ,new CursorDef("P00FQ8", "INSERT INTO [MudanzaCarga]([MudanzaId], [ItemCargaId], [ItemCargaCantidad], [ItemCargaEmbCant], [ItemCargaElevCant], [ItemCargaEmbalaje], [ItemCargaElevacion]) VALUES(@MudanzaId, @ItemCargaId, @ItemCargaCantidad, @ItemCargaEmbCant, @ItemCargaElevCant, @ItemCargaEmbalaje, @ItemCargaElevacion)", GxErrorMask.GX_NOMASK,prmP00FQ8)
           ,new CursorDef("P00FQ9", "UPDATE [MudanzaCarga] SET [ItemCargaEmbalaje]=@ItemCargaEmbalaje, [ItemCargaElevacion]=@ItemCargaElevacion, [ItemCargaElevCant]=@ItemCargaElevCant, [ItemCargaEmbCant]=@ItemCargaEmbCant, [ItemCargaCantidad]=@ItemCargaCantidad  WHERE [MudanzaId] = @AV12MudanzaId and [ItemCargaId] = @AV11SDTCargaItem__Id", GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP00FQ9)
           ,new CursorDef("P00FQ10", "INSERT INTO [MudanzaCarga]([MudanzaId], [ItemCargaId], [ItemCargaCantidad], [ItemCargaEmbCant], [ItemCargaElevCant], [ItemCargaEmbalaje], [ItemCargaElevacion]) VALUES(@MudanzaId, @ItemCargaId, @ItemCargaCantidad, @ItemCargaEmbCant, @ItemCargaElevCant, @ItemCargaEmbalaje, @ItemCargaElevacion)", GxErrorMask.GX_NOMASK,prmP00FQ10)
           ,new CursorDef("P00FQ11", "INSERT INTO [MudanzaCarga]([MudanzaId], [ItemCargaId], [ItemCargaCantidad], [ItemCargaEmbCant], [ItemCargaElevCant], [ItemCargaEmbalaje], [ItemCargaElevacion]) VALUES(@MudanzaId, @ItemCargaId, @ItemCargaCantidad, @ItemCargaEmbCant, @ItemCargaElevCant, @ItemCargaEmbalaje, @ItemCargaElevacion)", GxErrorMask.GX_NOMASK,prmP00FQ11)
           ,new CursorDef("P00FQ12", "UPDATE [MudanzaCarga] SET [ItemCargaEmbalaje]=@ItemCargaEmbalaje, [ItemCargaElevacion]=@ItemCargaElevacion, [ItemCargaElevCant]=@ItemCargaElevCant, [ItemCargaEmbCant]=@ItemCargaEmbCant, [ItemCargaCantidad]=@ItemCargaCantidad  WHERE [MudanzaId] = @AV12MudanzaId and [ItemCargaId] = @AV11SDTCargaItem__Id", GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP00FQ12)
           ,new CursorDef("P00FQ13", "INSERT INTO [MudanzaCarga]([MudanzaId], [ItemCargaId], [ItemCargaCantidad], [ItemCargaEmbCant], [ItemCargaElevCant], [ItemCargaEmbalaje], [ItemCargaElevacion]) VALUES(@MudanzaId, @ItemCargaId, @ItemCargaCantidad, @ItemCargaEmbCant, @ItemCargaElevCant, @ItemCargaEmbalaje, @ItemCargaElevacion)", GxErrorMask.GX_NOMASK,prmP00FQ13)
           ,new CursorDef("P00FQ14", "INSERT INTO [MudanzaCarga]([MudanzaId], [ItemCargaId], [ItemCargaCantidad], [ItemCargaEmbCant], [ItemCargaElevCant], [ItemCargaEmbalaje], [ItemCargaElevacion]) VALUES(@MudanzaId, @ItemCargaId, @ItemCargaCantidad, @ItemCargaEmbCant, @ItemCargaElevCant, @ItemCargaEmbalaje, @ItemCargaElevacion)", GxErrorMask.GX_NOMASK,prmP00FQ14)
           ,new CursorDef("P00FQ15", "UPDATE [MudanzaCarga] SET [ItemCargaEmbalaje]=@ItemCargaEmbalaje, [ItemCargaElevacion]=@ItemCargaElevacion, [ItemCargaElevCant]=@ItemCargaElevCant, [ItemCargaEmbCant]=@ItemCargaEmbCant, [ItemCargaCantidad]=@ItemCargaCantidad  WHERE [MudanzaId] = @AV12MudanzaId and [ItemCargaId] = @AV11SDTCargaItem__Id", GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP00FQ15)
           ,new CursorDef("P00FQ16", "INSERT INTO [MudanzaCarga]([MudanzaId], [ItemCargaId], [ItemCargaCantidad], [ItemCargaEmbCant], [ItemCargaElevCant], [ItemCargaEmbalaje], [ItemCargaElevacion]) VALUES(@MudanzaId, @ItemCargaId, @ItemCargaCantidad, @ItemCargaEmbCant, @ItemCargaElevCant, @ItemCargaEmbalaje, @ItemCargaElevacion)", GxErrorMask.GX_NOMASK,prmP00FQ16)
        };
     }
  }

  public void getResults( int cursor ,
                          IFieldGetter rslt ,
                          Object[] buf )
  {
  }

}

}

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
using System.ServiceModel.Web;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class his_solicitudeswwgetfilterdata : GXProcedure
   {
      public his_solicitudeswwgetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public his_solicitudeswwgetfilterdata( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_DDOName ,
                           string aP1_SearchTxtParms ,
                           string aP2_SearchTxtTo ,
                           out string aP3_OptionsJson ,
                           out string aP4_OptionsDescJson ,
                           out string aP5_OptionIndexesJson )
      {
         this.AV41DDOName = aP0_DDOName;
         this.AV42SearchTxtParms = aP1_SearchTxtParms;
         this.AV43SearchTxtTo = aP2_SearchTxtTo;
         this.AV44OptionsJson = "" ;
         this.AV45OptionsDescJson = "" ;
         this.AV46OptionIndexesJson = "" ;
         initialize();
         ExecutePrivate();
         aP3_OptionsJson=this.AV44OptionsJson;
         aP4_OptionsDescJson=this.AV45OptionsDescJson;
         aP5_OptionIndexesJson=this.AV46OptionIndexesJson;
      }

      public string executeUdp( string aP0_DDOName ,
                                string aP1_SearchTxtParms ,
                                string aP2_SearchTxtTo ,
                                out string aP3_OptionsJson ,
                                out string aP4_OptionsDescJson )
      {
         execute(aP0_DDOName, aP1_SearchTxtParms, aP2_SearchTxtTo, out aP3_OptionsJson, out aP4_OptionsDescJson, out aP5_OptionIndexesJson);
         return AV46OptionIndexesJson ;
      }

      public void executeSubmit( string aP0_DDOName ,
                                 string aP1_SearchTxtParms ,
                                 string aP2_SearchTxtTo ,
                                 out string aP3_OptionsJson ,
                                 out string aP4_OptionsDescJson ,
                                 out string aP5_OptionIndexesJson )
      {
         this.AV41DDOName = aP0_DDOName;
         this.AV42SearchTxtParms = aP1_SearchTxtParms;
         this.AV43SearchTxtTo = aP2_SearchTxtTo;
         this.AV44OptionsJson = "" ;
         this.AV45OptionsDescJson = "" ;
         this.AV46OptionIndexesJson = "" ;
         SubmitImpl();
         aP3_OptionsJson=this.AV44OptionsJson;
         aP4_OptionsDescJson=this.AV45OptionsDescJson;
         aP5_OptionIndexesJson=this.AV46OptionIndexesJson;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV31Options = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV33OptionsDesc = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV34OptionIndexes = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         GXt_boolean1 = AV8IsAuthorized;
         new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWHIS_Solicitudes", out  GXt_boolean1) ;
         AV8IsAuthorized = GXt_boolean1;
         if ( AV8IsAuthorized )
         {
            AV28MaxItems = 10;
            AV27PageIndex = (short)((String.IsNullOrEmpty(StringUtil.RTrim( AV42SearchTxtParms)) ? 0 : (long)(Math.Round(NumberUtil.Val( StringUtil.Substring( AV42SearchTxtParms, 1, 2), "."), 18, MidpointRounding.ToEven))));
            AV25SearchTxt = (String.IsNullOrEmpty(StringUtil.RTrim( AV42SearchTxtParms)) ? "" : StringUtil.Substring( AV42SearchTxtParms, 3, -1));
            AV26SkipItems = (short)(AV27PageIndex*AV28MaxItems);
            new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV9WWPContext) ;
            /* Execute user subroutine: 'LOADGRIDSTATE' */
            S111 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
            if ( StringUtil.StrCmp(StringUtil.Upper( AV41DDOName), "DDO_USUARIO") == 0 )
            {
               /* Execute user subroutine: 'LOADUSUARIOOPTIONS' */
               S121 ();
               if ( returnInSub )
               {
                  cleanup();
                  if (true) return;
               }
            }
            else if ( StringUtil.StrCmp(StringUtil.Upper( AV41DDOName), "DDO_CAMPOMODIFICADO") == 0 )
            {
               /* Execute user subroutine: 'LOADCAMPOMODIFICADOOPTIONS' */
               S131 ();
               if ( returnInSub )
               {
                  cleanup();
                  if (true) return;
               }
            }
            else if ( StringUtil.StrCmp(StringUtil.Upper( AV41DDOName), "DDO_VALORANTERIOR") == 0 )
            {
               /* Execute user subroutine: 'LOADVALORANTERIOROPTIONS' */
               S141 ();
               if ( returnInSub )
               {
                  cleanup();
                  if (true) return;
               }
            }
            else if ( StringUtil.StrCmp(StringUtil.Upper( AV41DDOName), "DDO_VALORNUEVO") == 0 )
            {
               /* Execute user subroutine: 'LOADVALORNUEVOOPTIONS' */
               S151 ();
               if ( returnInSub )
               {
                  cleanup();
                  if (true) return;
               }
            }
         }
         AV44OptionsJson = AV31Options.ToJSonString(false);
         AV45OptionsDescJson = AV33OptionsDesc.ToJSonString(false);
         AV46OptionIndexesJson = AV34OptionIndexes.ToJSonString(false);
         cleanup();
      }

      protected void S111( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV36Session.Get("HIS_SolicitudesWWGridState"), "") == 0 )
         {
            AV38GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "HIS_SolicitudesWWGridState"), null, "", "");
         }
         else
         {
            AV38GridState.FromXml(AV36Session.Get("HIS_SolicitudesWWGridState"), null, "", "");
         }
         AV49GXV1 = 1;
         while ( AV49GXV1 <= AV38GridState.gxTpr_Filtervalues.Count )
         {
            AV39GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV38GridState.gxTpr_Filtervalues.Item(AV49GXV1));
            if ( StringUtil.StrCmp(AV39GridStateFilterValue.gxTpr_Name, "SOLICITUDESID2") == 0 )
            {
               AV48SolicitudesID2 = (long)(Math.Round(NumberUtil.Val( AV39GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV47SolicitudesID2Operator = AV39GridStateFilterValue.gxTpr_Operator;
            }
            else if ( StringUtil.StrCmp(AV39GridStateFilterValue.gxTpr_Name, "TFSOLICITUDESID2") == 0 )
            {
               AV11TFSolicitudesID2 = (long)(Math.Round(NumberUtil.Val( AV39GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV12TFSolicitudesID2_To = (long)(Math.Round(NumberUtil.Val( AV39GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV39GridStateFilterValue.gxTpr_Name, "TFUSUARIO") == 0 )
            {
               AV13TFUsuario = AV39GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV39GridStateFilterValue.gxTpr_Name, "TFUSUARIO_SEL") == 0 )
            {
               AV14TFUsuario_Sel = AV39GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV39GridStateFilterValue.gxTpr_Name, "TFFECHACAMBIO") == 0 )
            {
               AV15TFFechaCambio = context.localUtil.CToT( AV39GridStateFilterValue.gxTpr_Value, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               AV16TFFechaCambio_To = context.localUtil.CToT( AV39GridStateFilterValue.gxTpr_Valueto, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
            }
            else if ( StringUtil.StrCmp(AV39GridStateFilterValue.gxTpr_Name, "TFCAMPOMODIFICADO") == 0 )
            {
               AV19TFCampoModificado = AV39GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV39GridStateFilterValue.gxTpr_Name, "TFCAMPOMODIFICADO_SEL") == 0 )
            {
               AV20TFCampoModificado_Sel = AV39GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV39GridStateFilterValue.gxTpr_Name, "TFVALORANTERIOR") == 0 )
            {
               AV21TFValorAnterior = AV39GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV39GridStateFilterValue.gxTpr_Name, "TFVALORANTERIOR_SEL") == 0 )
            {
               AV22TFValorAnterior_Sel = AV39GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV39GridStateFilterValue.gxTpr_Name, "TFVALORNUEVO") == 0 )
            {
               AV23TFValorNuevo = AV39GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV39GridStateFilterValue.gxTpr_Name, "TFVALORNUEVO_SEL") == 0 )
            {
               AV24TFValorNuevo_Sel = AV39GridStateFilterValue.gxTpr_Value;
            }
            AV49GXV1 = (int)(AV49GXV1+1);
         }
      }

      protected void S121( )
      {
         /* 'LOADUSUARIOOPTIONS' Routine */
         returnInSub = false;
         AV13TFUsuario = AV25SearchTxt;
         AV14TFUsuario_Sel = "";
         AV51His_solicitudeswwds_1_solicitudesid2 = AV48SolicitudesID2;
         AV52His_solicitudeswwds_2_tfsolicitudesid2 = AV11TFSolicitudesID2;
         AV53His_solicitudeswwds_3_tfsolicitudesid2_to = AV12TFSolicitudesID2_To;
         AV54His_solicitudeswwds_4_tfusuario = AV13TFUsuario;
         AV55His_solicitudeswwds_5_tfusuario_sel = AV14TFUsuario_Sel;
         AV56His_solicitudeswwds_6_tffechacambio = AV15TFFechaCambio;
         AV57His_solicitudeswwds_7_tffechacambio_to = AV16TFFechaCambio_To;
         AV58His_solicitudeswwds_8_tfcampomodificado = AV19TFCampoModificado;
         AV59His_solicitudeswwds_9_tfcampomodificado_sel = AV20TFCampoModificado_Sel;
         AV60His_solicitudeswwds_10_tfvaloranterior = AV21TFValorAnterior;
         AV61His_solicitudeswwds_11_tfvaloranterior_sel = AV22TFValorAnterior_Sel;
         AV62His_solicitudeswwds_12_tfvalornuevo = AV23TFValorNuevo;
         AV63His_solicitudeswwds_13_tfvalornuevo_sel = AV24TFValorNuevo_Sel;
         pr_datastore1.dynParam(0, new Object[]{ new Object[]{
                                              AV47SolicitudesID2Operator ,
                                              AV51His_solicitudeswwds_1_solicitudesid2 ,
                                              AV52His_solicitudeswwds_2_tfsolicitudesid2 ,
                                              AV53His_solicitudeswwds_3_tfsolicitudesid2_to ,
                                              AV55His_solicitudeswwds_5_tfusuario_sel ,
                                              AV54His_solicitudeswwds_4_tfusuario ,
                                              AV56His_solicitudeswwds_6_tffechacambio ,
                                              AV57His_solicitudeswwds_7_tffechacambio_to ,
                                              AV59His_solicitudeswwds_9_tfcampomodificado_sel ,
                                              AV58His_solicitudeswwds_8_tfcampomodificado ,
                                              AV61His_solicitudeswwds_11_tfvaloranterior_sel ,
                                              AV60His_solicitudeswwds_10_tfvaloranterior ,
                                              AV63His_solicitudeswwds_13_tfvalornuevo_sel ,
                                              AV62His_solicitudeswwds_12_tfvalornuevo ,
                                              A910SolicitudesID2 ,
                                              A912Usuario ,
                                              A911FechaCambio ,
                                              A914CampoModificado ,
                                              A915ValorAnterior ,
                                              A916ValorNuevo } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.LONG, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN,
                                              TypeConstants.BOOLEAN
                                              }
         });
         lV54His_solicitudeswwds_4_tfusuario = StringUtil.Concat( StringUtil.RTrim( AV54His_solicitudeswwds_4_tfusuario), "%", "");
         lV58His_solicitudeswwds_8_tfcampomodificado = StringUtil.Concat( StringUtil.RTrim( AV58His_solicitudeswwds_8_tfcampomodificado), "%", "");
         lV60His_solicitudeswwds_10_tfvaloranterior = StringUtil.Concat( StringUtil.RTrim( AV60His_solicitudeswwds_10_tfvaloranterior), "%", "");
         lV62His_solicitudeswwds_12_tfvalornuevo = StringUtil.Concat( StringUtil.RTrim( AV62His_solicitudeswwds_12_tfvalornuevo), "%", "");
         /* Using cursor P00KC2 */
         pr_datastore1.execute(0, new Object[] {AV51His_solicitudeswwds_1_solicitudesid2, AV52His_solicitudeswwds_2_tfsolicitudesid2, AV53His_solicitudeswwds_3_tfsolicitudesid2_to, lV54His_solicitudeswwds_4_tfusuario, AV55His_solicitudeswwds_5_tfusuario_sel, AV56His_solicitudeswwds_6_tffechacambio, AV57His_solicitudeswwds_7_tffechacambio_to, lV58His_solicitudeswwds_8_tfcampomodificado, AV59His_solicitudeswwds_9_tfcampomodificado_sel, lV60His_solicitudeswwds_10_tfvaloranterior, AV61His_solicitudeswwds_11_tfvaloranterior_sel, lV62His_solicitudeswwds_12_tfvalornuevo, AV63His_solicitudeswwds_13_tfvalornuevo_sel});
         while ( (pr_datastore1.getStatus(0) != 101) )
         {
            BRKKC2 = false;
            A912Usuario = P00KC2_A912Usuario[0];
            A916ValorNuevo = P00KC2_A916ValorNuevo[0];
            n916ValorNuevo = P00KC2_n916ValorNuevo[0];
            A915ValorAnterior = P00KC2_A915ValorAnterior[0];
            n915ValorAnterior = P00KC2_n915ValorAnterior[0];
            A914CampoModificado = P00KC2_A914CampoModificado[0];
            n914CampoModificado = P00KC2_n914CampoModificado[0];
            A911FechaCambio = P00KC2_A911FechaCambio[0];
            A910SolicitudesID2 = P00KC2_A910SolicitudesID2[0];
            A909HistorialID = P00KC2_A909HistorialID[0];
            AV35count = 0;
            while ( (pr_datastore1.getStatus(0) != 101) && ( StringUtil.StrCmp(P00KC2_A912Usuario[0], A912Usuario) == 0 ) )
            {
               BRKKC2 = false;
               A909HistorialID = P00KC2_A909HistorialID[0];
               AV35count = (long)(AV35count+1);
               BRKKC2 = true;
               pr_datastore1.readNext(0);
            }
            if ( (0==AV26SkipItems) )
            {
               AV30Option = (String.IsNullOrEmpty(StringUtil.RTrim( A912Usuario)) ? "<#Empty#>" : A912Usuario);
               AV31Options.Add(AV30Option, 0);
               AV34OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV35count), "Z,ZZZ,ZZZ,ZZ9")), 0);
               if ( AV31Options.Count == 10 )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            else
            {
               AV26SkipItems = (short)(AV26SkipItems-1);
            }
            if ( ! BRKKC2 )
            {
               BRKKC2 = true;
               pr_datastore1.readNext(0);
            }
         }
         pr_datastore1.close(0);
      }

      protected void S131( )
      {
         /* 'LOADCAMPOMODIFICADOOPTIONS' Routine */
         returnInSub = false;
         AV19TFCampoModificado = AV25SearchTxt;
         AV20TFCampoModificado_Sel = "";
         AV51His_solicitudeswwds_1_solicitudesid2 = AV48SolicitudesID2;
         AV52His_solicitudeswwds_2_tfsolicitudesid2 = AV11TFSolicitudesID2;
         AV53His_solicitudeswwds_3_tfsolicitudesid2_to = AV12TFSolicitudesID2_To;
         AV54His_solicitudeswwds_4_tfusuario = AV13TFUsuario;
         AV55His_solicitudeswwds_5_tfusuario_sel = AV14TFUsuario_Sel;
         AV56His_solicitudeswwds_6_tffechacambio = AV15TFFechaCambio;
         AV57His_solicitudeswwds_7_tffechacambio_to = AV16TFFechaCambio_To;
         AV58His_solicitudeswwds_8_tfcampomodificado = AV19TFCampoModificado;
         AV59His_solicitudeswwds_9_tfcampomodificado_sel = AV20TFCampoModificado_Sel;
         AV60His_solicitudeswwds_10_tfvaloranterior = AV21TFValorAnterior;
         AV61His_solicitudeswwds_11_tfvaloranterior_sel = AV22TFValorAnterior_Sel;
         AV62His_solicitudeswwds_12_tfvalornuevo = AV23TFValorNuevo;
         AV63His_solicitudeswwds_13_tfvalornuevo_sel = AV24TFValorNuevo_Sel;
         pr_datastore1.dynParam(1, new Object[]{ new Object[]{
                                              AV47SolicitudesID2Operator ,
                                              AV51His_solicitudeswwds_1_solicitudesid2 ,
                                              AV52His_solicitudeswwds_2_tfsolicitudesid2 ,
                                              AV53His_solicitudeswwds_3_tfsolicitudesid2_to ,
                                              AV55His_solicitudeswwds_5_tfusuario_sel ,
                                              AV54His_solicitudeswwds_4_tfusuario ,
                                              AV56His_solicitudeswwds_6_tffechacambio ,
                                              AV57His_solicitudeswwds_7_tffechacambio_to ,
                                              AV59His_solicitudeswwds_9_tfcampomodificado_sel ,
                                              AV58His_solicitudeswwds_8_tfcampomodificado ,
                                              AV61His_solicitudeswwds_11_tfvaloranterior_sel ,
                                              AV60His_solicitudeswwds_10_tfvaloranterior ,
                                              AV63His_solicitudeswwds_13_tfvalornuevo_sel ,
                                              AV62His_solicitudeswwds_12_tfvalornuevo ,
                                              A910SolicitudesID2 ,
                                              A912Usuario ,
                                              A911FechaCambio ,
                                              A914CampoModificado ,
                                              A915ValorAnterior ,
                                              A916ValorNuevo } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.LONG, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN,
                                              TypeConstants.BOOLEAN
                                              }
         });
         lV54His_solicitudeswwds_4_tfusuario = StringUtil.Concat( StringUtil.RTrim( AV54His_solicitudeswwds_4_tfusuario), "%", "");
         lV58His_solicitudeswwds_8_tfcampomodificado = StringUtil.Concat( StringUtil.RTrim( AV58His_solicitudeswwds_8_tfcampomodificado), "%", "");
         lV60His_solicitudeswwds_10_tfvaloranterior = StringUtil.Concat( StringUtil.RTrim( AV60His_solicitudeswwds_10_tfvaloranterior), "%", "");
         lV62His_solicitudeswwds_12_tfvalornuevo = StringUtil.Concat( StringUtil.RTrim( AV62His_solicitudeswwds_12_tfvalornuevo), "%", "");
         /* Using cursor P00KC3 */
         pr_datastore1.execute(1, new Object[] {AV51His_solicitudeswwds_1_solicitudesid2, AV52His_solicitudeswwds_2_tfsolicitudesid2, AV53His_solicitudeswwds_3_tfsolicitudesid2_to, lV54His_solicitudeswwds_4_tfusuario, AV55His_solicitudeswwds_5_tfusuario_sel, AV56His_solicitudeswwds_6_tffechacambio, AV57His_solicitudeswwds_7_tffechacambio_to, lV58His_solicitudeswwds_8_tfcampomodificado, AV59His_solicitudeswwds_9_tfcampomodificado_sel, lV60His_solicitudeswwds_10_tfvaloranterior, AV61His_solicitudeswwds_11_tfvaloranterior_sel, lV62His_solicitudeswwds_12_tfvalornuevo, AV63His_solicitudeswwds_13_tfvalornuevo_sel});
         while ( (pr_datastore1.getStatus(1) != 101) )
         {
            BRKKC4 = false;
            A914CampoModificado = P00KC3_A914CampoModificado[0];
            n914CampoModificado = P00KC3_n914CampoModificado[0];
            A916ValorNuevo = P00KC3_A916ValorNuevo[0];
            n916ValorNuevo = P00KC3_n916ValorNuevo[0];
            A915ValorAnterior = P00KC3_A915ValorAnterior[0];
            n915ValorAnterior = P00KC3_n915ValorAnterior[0];
            A911FechaCambio = P00KC3_A911FechaCambio[0];
            A912Usuario = P00KC3_A912Usuario[0];
            A910SolicitudesID2 = P00KC3_A910SolicitudesID2[0];
            A909HistorialID = P00KC3_A909HistorialID[0];
            AV35count = 0;
            while ( (pr_datastore1.getStatus(1) != 101) && ( StringUtil.StrCmp(P00KC3_A914CampoModificado[0], A914CampoModificado) == 0 ) )
            {
               BRKKC4 = false;
               A909HistorialID = P00KC3_A909HistorialID[0];
               AV35count = (long)(AV35count+1);
               BRKKC4 = true;
               pr_datastore1.readNext(1);
            }
            if ( (0==AV26SkipItems) )
            {
               AV30Option = (String.IsNullOrEmpty(StringUtil.RTrim( A914CampoModificado)) ? "<#Empty#>" : A914CampoModificado);
               AV31Options.Add(AV30Option, 0);
               AV34OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV35count), "Z,ZZZ,ZZZ,ZZ9")), 0);
               if ( AV31Options.Count == 10 )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            else
            {
               AV26SkipItems = (short)(AV26SkipItems-1);
            }
            if ( ! BRKKC4 )
            {
               BRKKC4 = true;
               pr_datastore1.readNext(1);
            }
         }
         pr_datastore1.close(1);
      }

      protected void S141( )
      {
         /* 'LOADVALORANTERIOROPTIONS' Routine */
         returnInSub = false;
         AV21TFValorAnterior = AV25SearchTxt;
         AV22TFValorAnterior_Sel = "";
         AV51His_solicitudeswwds_1_solicitudesid2 = AV48SolicitudesID2;
         AV52His_solicitudeswwds_2_tfsolicitudesid2 = AV11TFSolicitudesID2;
         AV53His_solicitudeswwds_3_tfsolicitudesid2_to = AV12TFSolicitudesID2_To;
         AV54His_solicitudeswwds_4_tfusuario = AV13TFUsuario;
         AV55His_solicitudeswwds_5_tfusuario_sel = AV14TFUsuario_Sel;
         AV56His_solicitudeswwds_6_tffechacambio = AV15TFFechaCambio;
         AV57His_solicitudeswwds_7_tffechacambio_to = AV16TFFechaCambio_To;
         AV58His_solicitudeswwds_8_tfcampomodificado = AV19TFCampoModificado;
         AV59His_solicitudeswwds_9_tfcampomodificado_sel = AV20TFCampoModificado_Sel;
         AV60His_solicitudeswwds_10_tfvaloranterior = AV21TFValorAnterior;
         AV61His_solicitudeswwds_11_tfvaloranterior_sel = AV22TFValorAnterior_Sel;
         AV62His_solicitudeswwds_12_tfvalornuevo = AV23TFValorNuevo;
         AV63His_solicitudeswwds_13_tfvalornuevo_sel = AV24TFValorNuevo_Sel;
         pr_datastore1.dynParam(2, new Object[]{ new Object[]{
                                              AV47SolicitudesID2Operator ,
                                              AV51His_solicitudeswwds_1_solicitudesid2 ,
                                              AV52His_solicitudeswwds_2_tfsolicitudesid2 ,
                                              AV53His_solicitudeswwds_3_tfsolicitudesid2_to ,
                                              AV55His_solicitudeswwds_5_tfusuario_sel ,
                                              AV54His_solicitudeswwds_4_tfusuario ,
                                              AV56His_solicitudeswwds_6_tffechacambio ,
                                              AV57His_solicitudeswwds_7_tffechacambio_to ,
                                              AV59His_solicitudeswwds_9_tfcampomodificado_sel ,
                                              AV58His_solicitudeswwds_8_tfcampomodificado ,
                                              AV61His_solicitudeswwds_11_tfvaloranterior_sel ,
                                              AV60His_solicitudeswwds_10_tfvaloranterior ,
                                              AV63His_solicitudeswwds_13_tfvalornuevo_sel ,
                                              AV62His_solicitudeswwds_12_tfvalornuevo ,
                                              A910SolicitudesID2 ,
                                              A912Usuario ,
                                              A911FechaCambio ,
                                              A914CampoModificado ,
                                              A915ValorAnterior ,
                                              A916ValorNuevo } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.LONG, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN,
                                              TypeConstants.BOOLEAN
                                              }
         });
         lV54His_solicitudeswwds_4_tfusuario = StringUtil.Concat( StringUtil.RTrim( AV54His_solicitudeswwds_4_tfusuario), "%", "");
         lV58His_solicitudeswwds_8_tfcampomodificado = StringUtil.Concat( StringUtil.RTrim( AV58His_solicitudeswwds_8_tfcampomodificado), "%", "");
         lV60His_solicitudeswwds_10_tfvaloranterior = StringUtil.Concat( StringUtil.RTrim( AV60His_solicitudeswwds_10_tfvaloranterior), "%", "");
         lV62His_solicitudeswwds_12_tfvalornuevo = StringUtil.Concat( StringUtil.RTrim( AV62His_solicitudeswwds_12_tfvalornuevo), "%", "");
         /* Using cursor P00KC4 */
         pr_datastore1.execute(2, new Object[] {AV51His_solicitudeswwds_1_solicitudesid2, AV52His_solicitudeswwds_2_tfsolicitudesid2, AV53His_solicitudeswwds_3_tfsolicitudesid2_to, lV54His_solicitudeswwds_4_tfusuario, AV55His_solicitudeswwds_5_tfusuario_sel, AV56His_solicitudeswwds_6_tffechacambio, AV57His_solicitudeswwds_7_tffechacambio_to, lV58His_solicitudeswwds_8_tfcampomodificado, AV59His_solicitudeswwds_9_tfcampomodificado_sel, lV60His_solicitudeswwds_10_tfvaloranterior, AV61His_solicitudeswwds_11_tfvaloranterior_sel, lV62His_solicitudeswwds_12_tfvalornuevo, AV63His_solicitudeswwds_13_tfvalornuevo_sel});
         while ( (pr_datastore1.getStatus(2) != 101) )
         {
            BRKKC6 = false;
            A915ValorAnterior = P00KC4_A915ValorAnterior[0];
            n915ValorAnterior = P00KC4_n915ValorAnterior[0];
            A916ValorNuevo = P00KC4_A916ValorNuevo[0];
            n916ValorNuevo = P00KC4_n916ValorNuevo[0];
            A914CampoModificado = P00KC4_A914CampoModificado[0];
            n914CampoModificado = P00KC4_n914CampoModificado[0];
            A911FechaCambio = P00KC4_A911FechaCambio[0];
            A912Usuario = P00KC4_A912Usuario[0];
            A910SolicitudesID2 = P00KC4_A910SolicitudesID2[0];
            A909HistorialID = P00KC4_A909HistorialID[0];
            AV35count = 0;
            while ( (pr_datastore1.getStatus(2) != 101) && ( StringUtil.StrCmp(P00KC4_A915ValorAnterior[0], A915ValorAnterior) == 0 ) )
            {
               BRKKC6 = false;
               A909HistorialID = P00KC4_A909HistorialID[0];
               AV35count = (long)(AV35count+1);
               BRKKC6 = true;
               pr_datastore1.readNext(2);
            }
            if ( (0==AV26SkipItems) )
            {
               AV30Option = (String.IsNullOrEmpty(StringUtil.RTrim( A915ValorAnterior)) ? "<#Empty#>" : A915ValorAnterior);
               AV31Options.Add(AV30Option, 0);
               AV34OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV35count), "Z,ZZZ,ZZZ,ZZ9")), 0);
               if ( AV31Options.Count == 10 )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            else
            {
               AV26SkipItems = (short)(AV26SkipItems-1);
            }
            if ( ! BRKKC6 )
            {
               BRKKC6 = true;
               pr_datastore1.readNext(2);
            }
         }
         pr_datastore1.close(2);
      }

      protected void S151( )
      {
         /* 'LOADVALORNUEVOOPTIONS' Routine */
         returnInSub = false;
         AV23TFValorNuevo = AV25SearchTxt;
         AV24TFValorNuevo_Sel = "";
         AV51His_solicitudeswwds_1_solicitudesid2 = AV48SolicitudesID2;
         AV52His_solicitudeswwds_2_tfsolicitudesid2 = AV11TFSolicitudesID2;
         AV53His_solicitudeswwds_3_tfsolicitudesid2_to = AV12TFSolicitudesID2_To;
         AV54His_solicitudeswwds_4_tfusuario = AV13TFUsuario;
         AV55His_solicitudeswwds_5_tfusuario_sel = AV14TFUsuario_Sel;
         AV56His_solicitudeswwds_6_tffechacambio = AV15TFFechaCambio;
         AV57His_solicitudeswwds_7_tffechacambio_to = AV16TFFechaCambio_To;
         AV58His_solicitudeswwds_8_tfcampomodificado = AV19TFCampoModificado;
         AV59His_solicitudeswwds_9_tfcampomodificado_sel = AV20TFCampoModificado_Sel;
         AV60His_solicitudeswwds_10_tfvaloranterior = AV21TFValorAnterior;
         AV61His_solicitudeswwds_11_tfvaloranterior_sel = AV22TFValorAnterior_Sel;
         AV62His_solicitudeswwds_12_tfvalornuevo = AV23TFValorNuevo;
         AV63His_solicitudeswwds_13_tfvalornuevo_sel = AV24TFValorNuevo_Sel;
         pr_datastore1.dynParam(3, new Object[]{ new Object[]{
                                              AV47SolicitudesID2Operator ,
                                              AV51His_solicitudeswwds_1_solicitudesid2 ,
                                              AV52His_solicitudeswwds_2_tfsolicitudesid2 ,
                                              AV53His_solicitudeswwds_3_tfsolicitudesid2_to ,
                                              AV55His_solicitudeswwds_5_tfusuario_sel ,
                                              AV54His_solicitudeswwds_4_tfusuario ,
                                              AV56His_solicitudeswwds_6_tffechacambio ,
                                              AV57His_solicitudeswwds_7_tffechacambio_to ,
                                              AV59His_solicitudeswwds_9_tfcampomodificado_sel ,
                                              AV58His_solicitudeswwds_8_tfcampomodificado ,
                                              AV61His_solicitudeswwds_11_tfvaloranterior_sel ,
                                              AV60His_solicitudeswwds_10_tfvaloranterior ,
                                              AV63His_solicitudeswwds_13_tfvalornuevo_sel ,
                                              AV62His_solicitudeswwds_12_tfvalornuevo ,
                                              A910SolicitudesID2 ,
                                              A912Usuario ,
                                              A911FechaCambio ,
                                              A914CampoModificado ,
                                              A915ValorAnterior ,
                                              A916ValorNuevo } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.LONG, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN,
                                              TypeConstants.BOOLEAN
                                              }
         });
         lV54His_solicitudeswwds_4_tfusuario = StringUtil.Concat( StringUtil.RTrim( AV54His_solicitudeswwds_4_tfusuario), "%", "");
         lV58His_solicitudeswwds_8_tfcampomodificado = StringUtil.Concat( StringUtil.RTrim( AV58His_solicitudeswwds_8_tfcampomodificado), "%", "");
         lV60His_solicitudeswwds_10_tfvaloranterior = StringUtil.Concat( StringUtil.RTrim( AV60His_solicitudeswwds_10_tfvaloranterior), "%", "");
         lV62His_solicitudeswwds_12_tfvalornuevo = StringUtil.Concat( StringUtil.RTrim( AV62His_solicitudeswwds_12_tfvalornuevo), "%", "");
         /* Using cursor P00KC5 */
         pr_datastore1.execute(3, new Object[] {AV51His_solicitudeswwds_1_solicitudesid2, AV52His_solicitudeswwds_2_tfsolicitudesid2, AV53His_solicitudeswwds_3_tfsolicitudesid2_to, lV54His_solicitudeswwds_4_tfusuario, AV55His_solicitudeswwds_5_tfusuario_sel, AV56His_solicitudeswwds_6_tffechacambio, AV57His_solicitudeswwds_7_tffechacambio_to, lV58His_solicitudeswwds_8_tfcampomodificado, AV59His_solicitudeswwds_9_tfcampomodificado_sel, lV60His_solicitudeswwds_10_tfvaloranterior, AV61His_solicitudeswwds_11_tfvaloranterior_sel, lV62His_solicitudeswwds_12_tfvalornuevo, AV63His_solicitudeswwds_13_tfvalornuevo_sel});
         while ( (pr_datastore1.getStatus(3) != 101) )
         {
            BRKKC8 = false;
            A916ValorNuevo = P00KC5_A916ValorNuevo[0];
            n916ValorNuevo = P00KC5_n916ValorNuevo[0];
            A915ValorAnterior = P00KC5_A915ValorAnterior[0];
            n915ValorAnterior = P00KC5_n915ValorAnterior[0];
            A914CampoModificado = P00KC5_A914CampoModificado[0];
            n914CampoModificado = P00KC5_n914CampoModificado[0];
            A911FechaCambio = P00KC5_A911FechaCambio[0];
            A912Usuario = P00KC5_A912Usuario[0];
            A910SolicitudesID2 = P00KC5_A910SolicitudesID2[0];
            A909HistorialID = P00KC5_A909HistorialID[0];
            AV35count = 0;
            while ( (pr_datastore1.getStatus(3) != 101) && ( StringUtil.StrCmp(P00KC5_A916ValorNuevo[0], A916ValorNuevo) == 0 ) )
            {
               BRKKC8 = false;
               A909HistorialID = P00KC5_A909HistorialID[0];
               AV35count = (long)(AV35count+1);
               BRKKC8 = true;
               pr_datastore1.readNext(3);
            }
            if ( (0==AV26SkipItems) )
            {
               AV30Option = (String.IsNullOrEmpty(StringUtil.RTrim( A916ValorNuevo)) ? "<#Empty#>" : A916ValorNuevo);
               AV31Options.Add(AV30Option, 0);
               AV34OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV35count), "Z,ZZZ,ZZZ,ZZ9")), 0);
               if ( AV31Options.Count == 10 )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            else
            {
               AV26SkipItems = (short)(AV26SkipItems-1);
            }
            if ( ! BRKKC8 )
            {
               BRKKC8 = true;
               pr_datastore1.readNext(3);
            }
         }
         pr_datastore1.close(3);
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
         AV44OptionsJson = "";
         AV45OptionsDescJson = "";
         AV46OptionIndexesJson = "";
         AV31Options = new GxSimpleCollection<string>();
         AV33OptionsDesc = new GxSimpleCollection<string>();
         AV34OptionIndexes = new GxSimpleCollection<string>();
         AV25SearchTxt = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV36Session = context.GetSession();
         AV38GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV39GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV13TFUsuario = "";
         AV14TFUsuario_Sel = "";
         AV15TFFechaCambio = (DateTime)(DateTime.MinValue);
         AV16TFFechaCambio_To = (DateTime)(DateTime.MinValue);
         AV19TFCampoModificado = "";
         AV20TFCampoModificado_Sel = "";
         AV21TFValorAnterior = "";
         AV22TFValorAnterior_Sel = "";
         AV23TFValorNuevo = "";
         AV24TFValorNuevo_Sel = "";
         AV54His_solicitudeswwds_4_tfusuario = "";
         AV55His_solicitudeswwds_5_tfusuario_sel = "";
         AV56His_solicitudeswwds_6_tffechacambio = (DateTime)(DateTime.MinValue);
         AV57His_solicitudeswwds_7_tffechacambio_to = (DateTime)(DateTime.MinValue);
         AV58His_solicitudeswwds_8_tfcampomodificado = "";
         AV59His_solicitudeswwds_9_tfcampomodificado_sel = "";
         AV60His_solicitudeswwds_10_tfvaloranterior = "";
         AV61His_solicitudeswwds_11_tfvaloranterior_sel = "";
         AV62His_solicitudeswwds_12_tfvalornuevo = "";
         AV63His_solicitudeswwds_13_tfvalornuevo_sel = "";
         lV54His_solicitudeswwds_4_tfusuario = "";
         lV58His_solicitudeswwds_8_tfcampomodificado = "";
         lV60His_solicitudeswwds_10_tfvaloranterior = "";
         lV62His_solicitudeswwds_12_tfvalornuevo = "";
         A912Usuario = "";
         A911FechaCambio = (DateTime)(DateTime.MinValue);
         A914CampoModificado = "";
         A915ValorAnterior = "";
         A916ValorNuevo = "";
         P00KC2_A912Usuario = new string[] {""} ;
         P00KC2_A916ValorNuevo = new string[] {""} ;
         P00KC2_n916ValorNuevo = new bool[] {false} ;
         P00KC2_A915ValorAnterior = new string[] {""} ;
         P00KC2_n915ValorAnterior = new bool[] {false} ;
         P00KC2_A914CampoModificado = new string[] {""} ;
         P00KC2_n914CampoModificado = new bool[] {false} ;
         P00KC2_A911FechaCambio = new DateTime[] {DateTime.MinValue} ;
         P00KC2_A910SolicitudesID2 = new long[1] ;
         P00KC2_A909HistorialID = new int[1] ;
         AV30Option = "";
         P00KC3_A914CampoModificado = new string[] {""} ;
         P00KC3_n914CampoModificado = new bool[] {false} ;
         P00KC3_A916ValorNuevo = new string[] {""} ;
         P00KC3_n916ValorNuevo = new bool[] {false} ;
         P00KC3_A915ValorAnterior = new string[] {""} ;
         P00KC3_n915ValorAnterior = new bool[] {false} ;
         P00KC3_A911FechaCambio = new DateTime[] {DateTime.MinValue} ;
         P00KC3_A912Usuario = new string[] {""} ;
         P00KC3_A910SolicitudesID2 = new long[1] ;
         P00KC3_A909HistorialID = new int[1] ;
         P00KC4_A915ValorAnterior = new string[] {""} ;
         P00KC4_n915ValorAnterior = new bool[] {false} ;
         P00KC4_A916ValorNuevo = new string[] {""} ;
         P00KC4_n916ValorNuevo = new bool[] {false} ;
         P00KC4_A914CampoModificado = new string[] {""} ;
         P00KC4_n914CampoModificado = new bool[] {false} ;
         P00KC4_A911FechaCambio = new DateTime[] {DateTime.MinValue} ;
         P00KC4_A912Usuario = new string[] {""} ;
         P00KC4_A910SolicitudesID2 = new long[1] ;
         P00KC4_A909HistorialID = new int[1] ;
         P00KC5_A916ValorNuevo = new string[] {""} ;
         P00KC5_n916ValorNuevo = new bool[] {false} ;
         P00KC5_A915ValorAnterior = new string[] {""} ;
         P00KC5_n915ValorAnterior = new bool[] {false} ;
         P00KC5_A914CampoModificado = new string[] {""} ;
         P00KC5_n914CampoModificado = new bool[] {false} ;
         P00KC5_A911FechaCambio = new DateTime[] {DateTime.MinValue} ;
         P00KC5_A912Usuario = new string[] {""} ;
         P00KC5_A910SolicitudesID2 = new long[1] ;
         P00KC5_A909HistorialID = new int[1] ;
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.his_solicitudeswwgetfilterdata__datastore1(),
            new Object[][] {
                new Object[] {
               P00KC2_A912Usuario, P00KC2_A916ValorNuevo, P00KC2_n916ValorNuevo, P00KC2_A915ValorAnterior, P00KC2_n915ValorAnterior, P00KC2_A914CampoModificado, P00KC2_n914CampoModificado, P00KC2_A911FechaCambio, P00KC2_A910SolicitudesID2, P00KC2_A909HistorialID
               }
               , new Object[] {
               P00KC3_A914CampoModificado, P00KC3_n914CampoModificado, P00KC3_A916ValorNuevo, P00KC3_n916ValorNuevo, P00KC3_A915ValorAnterior, P00KC3_n915ValorAnterior, P00KC3_A911FechaCambio, P00KC3_A912Usuario, P00KC3_A910SolicitudesID2, P00KC3_A909HistorialID
               }
               , new Object[] {
               P00KC4_A915ValorAnterior, P00KC4_n915ValorAnterior, P00KC4_A916ValorNuevo, P00KC4_n916ValorNuevo, P00KC4_A914CampoModificado, P00KC4_n914CampoModificado, P00KC4_A911FechaCambio, P00KC4_A912Usuario, P00KC4_A910SolicitudesID2, P00KC4_A909HistorialID
               }
               , new Object[] {
               P00KC5_A916ValorNuevo, P00KC5_n916ValorNuevo, P00KC5_A915ValorAnterior, P00KC5_n915ValorAnterior, P00KC5_A914CampoModificado, P00KC5_n914CampoModificado, P00KC5_A911FechaCambio, P00KC5_A912Usuario, P00KC5_A910SolicitudesID2, P00KC5_A909HistorialID
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV28MaxItems ;
      private short AV27PageIndex ;
      private short AV26SkipItems ;
      private short AV47SolicitudesID2Operator ;
      private int AV49GXV1 ;
      private int A909HistorialID ;
      private long AV48SolicitudesID2 ;
      private long AV11TFSolicitudesID2 ;
      private long AV12TFSolicitudesID2_To ;
      private long AV51His_solicitudeswwds_1_solicitudesid2 ;
      private long AV52His_solicitudeswwds_2_tfsolicitudesid2 ;
      private long AV53His_solicitudeswwds_3_tfsolicitudesid2_to ;
      private long A910SolicitudesID2 ;
      private long AV35count ;
      private DateTime AV15TFFechaCambio ;
      private DateTime AV16TFFechaCambio_To ;
      private DateTime AV56His_solicitudeswwds_6_tffechacambio ;
      private DateTime AV57His_solicitudeswwds_7_tffechacambio_to ;
      private DateTime A911FechaCambio ;
      private bool AV8IsAuthorized ;
      private bool GXt_boolean1 ;
      private bool returnInSub ;
      private bool BRKKC2 ;
      private bool n916ValorNuevo ;
      private bool n915ValorAnterior ;
      private bool n914CampoModificado ;
      private bool BRKKC4 ;
      private bool BRKKC6 ;
      private bool BRKKC8 ;
      private string AV44OptionsJson ;
      private string AV45OptionsDescJson ;
      private string AV46OptionIndexesJson ;
      private string AV41DDOName ;
      private string AV42SearchTxtParms ;
      private string AV43SearchTxtTo ;
      private string AV25SearchTxt ;
      private string AV13TFUsuario ;
      private string AV14TFUsuario_Sel ;
      private string AV19TFCampoModificado ;
      private string AV20TFCampoModificado_Sel ;
      private string AV21TFValorAnterior ;
      private string AV22TFValorAnterior_Sel ;
      private string AV23TFValorNuevo ;
      private string AV24TFValorNuevo_Sel ;
      private string AV54His_solicitudeswwds_4_tfusuario ;
      private string AV55His_solicitudeswwds_5_tfusuario_sel ;
      private string AV58His_solicitudeswwds_8_tfcampomodificado ;
      private string AV59His_solicitudeswwds_9_tfcampomodificado_sel ;
      private string AV60His_solicitudeswwds_10_tfvaloranterior ;
      private string AV61His_solicitudeswwds_11_tfvaloranterior_sel ;
      private string AV62His_solicitudeswwds_12_tfvalornuevo ;
      private string AV63His_solicitudeswwds_13_tfvalornuevo_sel ;
      private string lV54His_solicitudeswwds_4_tfusuario ;
      private string lV58His_solicitudeswwds_8_tfcampomodificado ;
      private string lV60His_solicitudeswwds_10_tfvaloranterior ;
      private string lV62His_solicitudeswwds_12_tfvalornuevo ;
      private string A912Usuario ;
      private string A914CampoModificado ;
      private string A915ValorAnterior ;
      private string A916ValorNuevo ;
      private string AV30Option ;
      private IGxSession AV36Session ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GxSimpleCollection<string> AV31Options ;
      private GxSimpleCollection<string> AV33OptionsDesc ;
      private GxSimpleCollection<string> AV34OptionIndexes ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV38GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV39GridStateFilterValue ;
      private IDataStoreProvider pr_datastore1 ;
      private string[] P00KC2_A912Usuario ;
      private string[] P00KC2_A916ValorNuevo ;
      private bool[] P00KC2_n916ValorNuevo ;
      private string[] P00KC2_A915ValorAnterior ;
      private bool[] P00KC2_n915ValorAnterior ;
      private string[] P00KC2_A914CampoModificado ;
      private bool[] P00KC2_n914CampoModificado ;
      private DateTime[] P00KC2_A911FechaCambio ;
      private long[] P00KC2_A910SolicitudesID2 ;
      private int[] P00KC2_A909HistorialID ;
      private string[] P00KC3_A914CampoModificado ;
      private bool[] P00KC3_n914CampoModificado ;
      private string[] P00KC3_A916ValorNuevo ;
      private bool[] P00KC3_n916ValorNuevo ;
      private string[] P00KC3_A915ValorAnterior ;
      private bool[] P00KC3_n915ValorAnterior ;
      private DateTime[] P00KC3_A911FechaCambio ;
      private string[] P00KC3_A912Usuario ;
      private long[] P00KC3_A910SolicitudesID2 ;
      private int[] P00KC3_A909HistorialID ;
      private string[] P00KC4_A915ValorAnterior ;
      private bool[] P00KC4_n915ValorAnterior ;
      private string[] P00KC4_A916ValorNuevo ;
      private bool[] P00KC4_n916ValorNuevo ;
      private string[] P00KC4_A914CampoModificado ;
      private bool[] P00KC4_n914CampoModificado ;
      private DateTime[] P00KC4_A911FechaCambio ;
      private string[] P00KC4_A912Usuario ;
      private long[] P00KC4_A910SolicitudesID2 ;
      private int[] P00KC4_A909HistorialID ;
      private string[] P00KC5_A916ValorNuevo ;
      private bool[] P00KC5_n916ValorNuevo ;
      private string[] P00KC5_A915ValorAnterior ;
      private bool[] P00KC5_n915ValorAnterior ;
      private string[] P00KC5_A914CampoModificado ;
      private bool[] P00KC5_n914CampoModificado ;
      private DateTime[] P00KC5_A911FechaCambio ;
      private string[] P00KC5_A912Usuario ;
      private long[] P00KC5_A910SolicitudesID2 ;
      private int[] P00KC5_A909HistorialID ;
      private string aP3_OptionsJson ;
      private string aP4_OptionsDescJson ;
      private string aP5_OptionIndexesJson ;
   }

   public class his_solicitudeswwgetfilterdata__datastore1 : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00KC2( IGxContext context ,
                                             short AV47SolicitudesID2Operator ,
                                             long AV51His_solicitudeswwds_1_solicitudesid2 ,
                                             long AV52His_solicitudeswwds_2_tfsolicitudesid2 ,
                                             long AV53His_solicitudeswwds_3_tfsolicitudesid2_to ,
                                             string AV55His_solicitudeswwds_5_tfusuario_sel ,
                                             string AV54His_solicitudeswwds_4_tfusuario ,
                                             DateTime AV56His_solicitudeswwds_6_tffechacambio ,
                                             DateTime AV57His_solicitudeswwds_7_tffechacambio_to ,
                                             string AV59His_solicitudeswwds_9_tfcampomodificado_sel ,
                                             string AV58His_solicitudeswwds_8_tfcampomodificado ,
                                             string AV61His_solicitudeswwds_11_tfvaloranterior_sel ,
                                             string AV60His_solicitudeswwds_10_tfvaloranterior ,
                                             string AV63His_solicitudeswwds_13_tfvalornuevo_sel ,
                                             string AV62His_solicitudeswwds_12_tfvalornuevo ,
                                             long A910SolicitudesID2 ,
                                             string A912Usuario ,
                                             DateTime A911FechaCambio ,
                                             string A914CampoModificado ,
                                             string A915ValorAnterior ,
                                             string A916ValorNuevo )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int2 = new short[13];
         Object[] GXv_Object3 = new Object[2];
         scmdbuf = "SELECT [Usuario], [ValorNuevo], [ValorAnterior], [CampoModificado], [FechaCambio], [SolicitudesID], [HistorialID] FROM dbo.[HIS_Solicitudes]";
         if ( ( AV47SolicitudesID2Operator == 0 ) && ( ! (0==AV51His_solicitudeswwds_1_solicitudesid2) ) )
         {
            AddWhere(sWhereString, "([SolicitudesID] = @AV51His_solicitudeswwds_1_solicitudesid2)");
         }
         else
         {
            GXv_int2[0] = 1;
         }
         if ( ! (0==AV52His_solicitudeswwds_2_tfsolicitudesid2) )
         {
            AddWhere(sWhereString, "([SolicitudesID] >= @AV52His_solicitudeswwds_2_tfsolicitudesid2)");
         }
         else
         {
            GXv_int2[1] = 1;
         }
         if ( ! (0==AV53His_solicitudeswwds_3_tfsolicitudesid2_to) )
         {
            AddWhere(sWhereString, "([SolicitudesID] <= @AV53His_solicitudeswwds_3_tfsolicitudesid2_to)");
         }
         else
         {
            GXv_int2[2] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV55His_solicitudeswwds_5_tfusuario_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV54His_solicitudeswwds_4_tfusuario)) ) )
         {
            AddWhere(sWhereString, "(UPPER([Usuario]) like UPPER(@lV54His_solicitudeswwds_4_tfusuario))");
         }
         else
         {
            GXv_int2[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV55His_solicitudeswwds_5_tfusuario_sel)) && ! ( StringUtil.StrCmp(AV55His_solicitudeswwds_5_tfusuario_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([Usuario] = @AV55His_solicitudeswwds_5_tfusuario_sel)");
         }
         else
         {
            GXv_int2[4] = 1;
         }
         if ( StringUtil.StrCmp(AV55His_solicitudeswwds_5_tfusuario_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([Usuario] = ''))");
         }
         if ( ! (DateTime.MinValue==AV56His_solicitudeswwds_6_tffechacambio) )
         {
            AddWhere(sWhereString, "([FechaCambio] >= @AV56His_solicitudeswwds_6_tffechacambio)");
         }
         else
         {
            GXv_int2[5] = 1;
         }
         if ( ! (DateTime.MinValue==AV57His_solicitudeswwds_7_tffechacambio_to) )
         {
            AddWhere(sWhereString, "([FechaCambio] <= @AV57His_solicitudeswwds_7_tffechacambio_to)");
         }
         else
         {
            GXv_int2[6] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV59His_solicitudeswwds_9_tfcampomodificado_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV58His_solicitudeswwds_8_tfcampomodificado)) ) )
         {
            AddWhere(sWhereString, "(UPPER([CampoModificado]) like UPPER(@lV58His_solicitudeswwds_8_tfcampomodificado))");
         }
         else
         {
            GXv_int2[7] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59His_solicitudeswwds_9_tfcampomodificado_sel)) && ! ( StringUtil.StrCmp(AV59His_solicitudeswwds_9_tfcampomodificado_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([CampoModificado] = @AV59His_solicitudeswwds_9_tfcampomodificado_sel)");
         }
         else
         {
            GXv_int2[8] = 1;
         }
         if ( StringUtil.StrCmp(AV59His_solicitudeswwds_9_tfcampomodificado_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "([CampoModificado] IS NULL or ([CampoModificado] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV61His_solicitudeswwds_11_tfvaloranterior_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60His_solicitudeswwds_10_tfvaloranterior)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ValorAnterior]) like UPPER(@lV60His_solicitudeswwds_10_tfvaloranterior))");
         }
         else
         {
            GXv_int2[9] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61His_solicitudeswwds_11_tfvaloranterior_sel)) && ! ( StringUtil.StrCmp(AV61His_solicitudeswwds_11_tfvaloranterior_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([ValorAnterior] = @AV61His_solicitudeswwds_11_tfvaloranterior_sel)");
         }
         else
         {
            GXv_int2[10] = 1;
         }
         if ( StringUtil.StrCmp(AV61His_solicitudeswwds_11_tfvaloranterior_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "([ValorAnterior] IS NULL or ([ValorAnterior] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV63His_solicitudeswwds_13_tfvalornuevo_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62His_solicitudeswwds_12_tfvalornuevo)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ValorNuevo]) like UPPER(@lV62His_solicitudeswwds_12_tfvalornuevo))");
         }
         else
         {
            GXv_int2[11] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63His_solicitudeswwds_13_tfvalornuevo_sel)) && ! ( StringUtil.StrCmp(AV63His_solicitudeswwds_13_tfvalornuevo_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([ValorNuevo] = @AV63His_solicitudeswwds_13_tfvalornuevo_sel)");
         }
         else
         {
            GXv_int2[12] = 1;
         }
         if ( StringUtil.StrCmp(AV63His_solicitudeswwds_13_tfvalornuevo_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "([ValorNuevo] IS NULL or ([ValorNuevo] = ''))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY [Usuario]";
         GXv_Object3[0] = scmdbuf;
         GXv_Object3[1] = GXv_int2;
         return GXv_Object3 ;
      }

      protected Object[] conditional_P00KC3( IGxContext context ,
                                             short AV47SolicitudesID2Operator ,
                                             long AV51His_solicitudeswwds_1_solicitudesid2 ,
                                             long AV52His_solicitudeswwds_2_tfsolicitudesid2 ,
                                             long AV53His_solicitudeswwds_3_tfsolicitudesid2_to ,
                                             string AV55His_solicitudeswwds_5_tfusuario_sel ,
                                             string AV54His_solicitudeswwds_4_tfusuario ,
                                             DateTime AV56His_solicitudeswwds_6_tffechacambio ,
                                             DateTime AV57His_solicitudeswwds_7_tffechacambio_to ,
                                             string AV59His_solicitudeswwds_9_tfcampomodificado_sel ,
                                             string AV58His_solicitudeswwds_8_tfcampomodificado ,
                                             string AV61His_solicitudeswwds_11_tfvaloranterior_sel ,
                                             string AV60His_solicitudeswwds_10_tfvaloranterior ,
                                             string AV63His_solicitudeswwds_13_tfvalornuevo_sel ,
                                             string AV62His_solicitudeswwds_12_tfvalornuevo ,
                                             long A910SolicitudesID2 ,
                                             string A912Usuario ,
                                             DateTime A911FechaCambio ,
                                             string A914CampoModificado ,
                                             string A915ValorAnterior ,
                                             string A916ValorNuevo )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int4 = new short[13];
         Object[] GXv_Object5 = new Object[2];
         scmdbuf = "SELECT [CampoModificado], [ValorNuevo], [ValorAnterior], [FechaCambio], [Usuario], [SolicitudesID], [HistorialID] FROM dbo.[HIS_Solicitudes]";
         if ( ( AV47SolicitudesID2Operator == 0 ) && ( ! (0==AV51His_solicitudeswwds_1_solicitudesid2) ) )
         {
            AddWhere(sWhereString, "([SolicitudesID] = @AV51His_solicitudeswwds_1_solicitudesid2)");
         }
         else
         {
            GXv_int4[0] = 1;
         }
         if ( ! (0==AV52His_solicitudeswwds_2_tfsolicitudesid2) )
         {
            AddWhere(sWhereString, "([SolicitudesID] >= @AV52His_solicitudeswwds_2_tfsolicitudesid2)");
         }
         else
         {
            GXv_int4[1] = 1;
         }
         if ( ! (0==AV53His_solicitudeswwds_3_tfsolicitudesid2_to) )
         {
            AddWhere(sWhereString, "([SolicitudesID] <= @AV53His_solicitudeswwds_3_tfsolicitudesid2_to)");
         }
         else
         {
            GXv_int4[2] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV55His_solicitudeswwds_5_tfusuario_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV54His_solicitudeswwds_4_tfusuario)) ) )
         {
            AddWhere(sWhereString, "(UPPER([Usuario]) like UPPER(@lV54His_solicitudeswwds_4_tfusuario))");
         }
         else
         {
            GXv_int4[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV55His_solicitudeswwds_5_tfusuario_sel)) && ! ( StringUtil.StrCmp(AV55His_solicitudeswwds_5_tfusuario_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([Usuario] = @AV55His_solicitudeswwds_5_tfusuario_sel)");
         }
         else
         {
            GXv_int4[4] = 1;
         }
         if ( StringUtil.StrCmp(AV55His_solicitudeswwds_5_tfusuario_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([Usuario] = ''))");
         }
         if ( ! (DateTime.MinValue==AV56His_solicitudeswwds_6_tffechacambio) )
         {
            AddWhere(sWhereString, "([FechaCambio] >= @AV56His_solicitudeswwds_6_tffechacambio)");
         }
         else
         {
            GXv_int4[5] = 1;
         }
         if ( ! (DateTime.MinValue==AV57His_solicitudeswwds_7_tffechacambio_to) )
         {
            AddWhere(sWhereString, "([FechaCambio] <= @AV57His_solicitudeswwds_7_tffechacambio_to)");
         }
         else
         {
            GXv_int4[6] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV59His_solicitudeswwds_9_tfcampomodificado_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV58His_solicitudeswwds_8_tfcampomodificado)) ) )
         {
            AddWhere(sWhereString, "(UPPER([CampoModificado]) like UPPER(@lV58His_solicitudeswwds_8_tfcampomodificado))");
         }
         else
         {
            GXv_int4[7] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59His_solicitudeswwds_9_tfcampomodificado_sel)) && ! ( StringUtil.StrCmp(AV59His_solicitudeswwds_9_tfcampomodificado_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([CampoModificado] = @AV59His_solicitudeswwds_9_tfcampomodificado_sel)");
         }
         else
         {
            GXv_int4[8] = 1;
         }
         if ( StringUtil.StrCmp(AV59His_solicitudeswwds_9_tfcampomodificado_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "([CampoModificado] IS NULL or ([CampoModificado] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV61His_solicitudeswwds_11_tfvaloranterior_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60His_solicitudeswwds_10_tfvaloranterior)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ValorAnterior]) like UPPER(@lV60His_solicitudeswwds_10_tfvaloranterior))");
         }
         else
         {
            GXv_int4[9] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61His_solicitudeswwds_11_tfvaloranterior_sel)) && ! ( StringUtil.StrCmp(AV61His_solicitudeswwds_11_tfvaloranterior_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([ValorAnterior] = @AV61His_solicitudeswwds_11_tfvaloranterior_sel)");
         }
         else
         {
            GXv_int4[10] = 1;
         }
         if ( StringUtil.StrCmp(AV61His_solicitudeswwds_11_tfvaloranterior_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "([ValorAnterior] IS NULL or ([ValorAnterior] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV63His_solicitudeswwds_13_tfvalornuevo_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62His_solicitudeswwds_12_tfvalornuevo)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ValorNuevo]) like UPPER(@lV62His_solicitudeswwds_12_tfvalornuevo))");
         }
         else
         {
            GXv_int4[11] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63His_solicitudeswwds_13_tfvalornuevo_sel)) && ! ( StringUtil.StrCmp(AV63His_solicitudeswwds_13_tfvalornuevo_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([ValorNuevo] = @AV63His_solicitudeswwds_13_tfvalornuevo_sel)");
         }
         else
         {
            GXv_int4[12] = 1;
         }
         if ( StringUtil.StrCmp(AV63His_solicitudeswwds_13_tfvalornuevo_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "([ValorNuevo] IS NULL or ([ValorNuevo] = ''))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY [CampoModificado]";
         GXv_Object5[0] = scmdbuf;
         GXv_Object5[1] = GXv_int4;
         return GXv_Object5 ;
      }

      protected Object[] conditional_P00KC4( IGxContext context ,
                                             short AV47SolicitudesID2Operator ,
                                             long AV51His_solicitudeswwds_1_solicitudesid2 ,
                                             long AV52His_solicitudeswwds_2_tfsolicitudesid2 ,
                                             long AV53His_solicitudeswwds_3_tfsolicitudesid2_to ,
                                             string AV55His_solicitudeswwds_5_tfusuario_sel ,
                                             string AV54His_solicitudeswwds_4_tfusuario ,
                                             DateTime AV56His_solicitudeswwds_6_tffechacambio ,
                                             DateTime AV57His_solicitudeswwds_7_tffechacambio_to ,
                                             string AV59His_solicitudeswwds_9_tfcampomodificado_sel ,
                                             string AV58His_solicitudeswwds_8_tfcampomodificado ,
                                             string AV61His_solicitudeswwds_11_tfvaloranterior_sel ,
                                             string AV60His_solicitudeswwds_10_tfvaloranterior ,
                                             string AV63His_solicitudeswwds_13_tfvalornuevo_sel ,
                                             string AV62His_solicitudeswwds_12_tfvalornuevo ,
                                             long A910SolicitudesID2 ,
                                             string A912Usuario ,
                                             DateTime A911FechaCambio ,
                                             string A914CampoModificado ,
                                             string A915ValorAnterior ,
                                             string A916ValorNuevo )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int6 = new short[13];
         Object[] GXv_Object7 = new Object[2];
         scmdbuf = "SELECT [ValorAnterior], [ValorNuevo], [CampoModificado], [FechaCambio], [Usuario], [SolicitudesID], [HistorialID] FROM dbo.[HIS_Solicitudes]";
         if ( ( AV47SolicitudesID2Operator == 0 ) && ( ! (0==AV51His_solicitudeswwds_1_solicitudesid2) ) )
         {
            AddWhere(sWhereString, "([SolicitudesID] = @AV51His_solicitudeswwds_1_solicitudesid2)");
         }
         else
         {
            GXv_int6[0] = 1;
         }
         if ( ! (0==AV52His_solicitudeswwds_2_tfsolicitudesid2) )
         {
            AddWhere(sWhereString, "([SolicitudesID] >= @AV52His_solicitudeswwds_2_tfsolicitudesid2)");
         }
         else
         {
            GXv_int6[1] = 1;
         }
         if ( ! (0==AV53His_solicitudeswwds_3_tfsolicitudesid2_to) )
         {
            AddWhere(sWhereString, "([SolicitudesID] <= @AV53His_solicitudeswwds_3_tfsolicitudesid2_to)");
         }
         else
         {
            GXv_int6[2] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV55His_solicitudeswwds_5_tfusuario_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV54His_solicitudeswwds_4_tfusuario)) ) )
         {
            AddWhere(sWhereString, "(UPPER([Usuario]) like UPPER(@lV54His_solicitudeswwds_4_tfusuario))");
         }
         else
         {
            GXv_int6[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV55His_solicitudeswwds_5_tfusuario_sel)) && ! ( StringUtil.StrCmp(AV55His_solicitudeswwds_5_tfusuario_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([Usuario] = @AV55His_solicitudeswwds_5_tfusuario_sel)");
         }
         else
         {
            GXv_int6[4] = 1;
         }
         if ( StringUtil.StrCmp(AV55His_solicitudeswwds_5_tfusuario_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([Usuario] = ''))");
         }
         if ( ! (DateTime.MinValue==AV56His_solicitudeswwds_6_tffechacambio) )
         {
            AddWhere(sWhereString, "([FechaCambio] >= @AV56His_solicitudeswwds_6_tffechacambio)");
         }
         else
         {
            GXv_int6[5] = 1;
         }
         if ( ! (DateTime.MinValue==AV57His_solicitudeswwds_7_tffechacambio_to) )
         {
            AddWhere(sWhereString, "([FechaCambio] <= @AV57His_solicitudeswwds_7_tffechacambio_to)");
         }
         else
         {
            GXv_int6[6] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV59His_solicitudeswwds_9_tfcampomodificado_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV58His_solicitudeswwds_8_tfcampomodificado)) ) )
         {
            AddWhere(sWhereString, "(UPPER([CampoModificado]) like UPPER(@lV58His_solicitudeswwds_8_tfcampomodificado))");
         }
         else
         {
            GXv_int6[7] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59His_solicitudeswwds_9_tfcampomodificado_sel)) && ! ( StringUtil.StrCmp(AV59His_solicitudeswwds_9_tfcampomodificado_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([CampoModificado] = @AV59His_solicitudeswwds_9_tfcampomodificado_sel)");
         }
         else
         {
            GXv_int6[8] = 1;
         }
         if ( StringUtil.StrCmp(AV59His_solicitudeswwds_9_tfcampomodificado_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "([CampoModificado] IS NULL or ([CampoModificado] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV61His_solicitudeswwds_11_tfvaloranterior_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60His_solicitudeswwds_10_tfvaloranterior)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ValorAnterior]) like UPPER(@lV60His_solicitudeswwds_10_tfvaloranterior))");
         }
         else
         {
            GXv_int6[9] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61His_solicitudeswwds_11_tfvaloranterior_sel)) && ! ( StringUtil.StrCmp(AV61His_solicitudeswwds_11_tfvaloranterior_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([ValorAnterior] = @AV61His_solicitudeswwds_11_tfvaloranterior_sel)");
         }
         else
         {
            GXv_int6[10] = 1;
         }
         if ( StringUtil.StrCmp(AV61His_solicitudeswwds_11_tfvaloranterior_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "([ValorAnterior] IS NULL or ([ValorAnterior] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV63His_solicitudeswwds_13_tfvalornuevo_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62His_solicitudeswwds_12_tfvalornuevo)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ValorNuevo]) like UPPER(@lV62His_solicitudeswwds_12_tfvalornuevo))");
         }
         else
         {
            GXv_int6[11] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63His_solicitudeswwds_13_tfvalornuevo_sel)) && ! ( StringUtil.StrCmp(AV63His_solicitudeswwds_13_tfvalornuevo_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([ValorNuevo] = @AV63His_solicitudeswwds_13_tfvalornuevo_sel)");
         }
         else
         {
            GXv_int6[12] = 1;
         }
         if ( StringUtil.StrCmp(AV63His_solicitudeswwds_13_tfvalornuevo_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "([ValorNuevo] IS NULL or ([ValorNuevo] = ''))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY [ValorAnterior]";
         GXv_Object7[0] = scmdbuf;
         GXv_Object7[1] = GXv_int6;
         return GXv_Object7 ;
      }

      protected Object[] conditional_P00KC5( IGxContext context ,
                                             short AV47SolicitudesID2Operator ,
                                             long AV51His_solicitudeswwds_1_solicitudesid2 ,
                                             long AV52His_solicitudeswwds_2_tfsolicitudesid2 ,
                                             long AV53His_solicitudeswwds_3_tfsolicitudesid2_to ,
                                             string AV55His_solicitudeswwds_5_tfusuario_sel ,
                                             string AV54His_solicitudeswwds_4_tfusuario ,
                                             DateTime AV56His_solicitudeswwds_6_tffechacambio ,
                                             DateTime AV57His_solicitudeswwds_7_tffechacambio_to ,
                                             string AV59His_solicitudeswwds_9_tfcampomodificado_sel ,
                                             string AV58His_solicitudeswwds_8_tfcampomodificado ,
                                             string AV61His_solicitudeswwds_11_tfvaloranterior_sel ,
                                             string AV60His_solicitudeswwds_10_tfvaloranterior ,
                                             string AV63His_solicitudeswwds_13_tfvalornuevo_sel ,
                                             string AV62His_solicitudeswwds_12_tfvalornuevo ,
                                             long A910SolicitudesID2 ,
                                             string A912Usuario ,
                                             DateTime A911FechaCambio ,
                                             string A914CampoModificado ,
                                             string A915ValorAnterior ,
                                             string A916ValorNuevo )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int8 = new short[13];
         Object[] GXv_Object9 = new Object[2];
         scmdbuf = "SELECT [ValorNuevo], [ValorAnterior], [CampoModificado], [FechaCambio], [Usuario], [SolicitudesID], [HistorialID] FROM dbo.[HIS_Solicitudes]";
         if ( ( AV47SolicitudesID2Operator == 0 ) && ( ! (0==AV51His_solicitudeswwds_1_solicitudesid2) ) )
         {
            AddWhere(sWhereString, "([SolicitudesID] = @AV51His_solicitudeswwds_1_solicitudesid2)");
         }
         else
         {
            GXv_int8[0] = 1;
         }
         if ( ! (0==AV52His_solicitudeswwds_2_tfsolicitudesid2) )
         {
            AddWhere(sWhereString, "([SolicitudesID] >= @AV52His_solicitudeswwds_2_tfsolicitudesid2)");
         }
         else
         {
            GXv_int8[1] = 1;
         }
         if ( ! (0==AV53His_solicitudeswwds_3_tfsolicitudesid2_to) )
         {
            AddWhere(sWhereString, "([SolicitudesID] <= @AV53His_solicitudeswwds_3_tfsolicitudesid2_to)");
         }
         else
         {
            GXv_int8[2] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV55His_solicitudeswwds_5_tfusuario_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV54His_solicitudeswwds_4_tfusuario)) ) )
         {
            AddWhere(sWhereString, "(UPPER([Usuario]) like UPPER(@lV54His_solicitudeswwds_4_tfusuario))");
         }
         else
         {
            GXv_int8[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV55His_solicitudeswwds_5_tfusuario_sel)) && ! ( StringUtil.StrCmp(AV55His_solicitudeswwds_5_tfusuario_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([Usuario] = @AV55His_solicitudeswwds_5_tfusuario_sel)");
         }
         else
         {
            GXv_int8[4] = 1;
         }
         if ( StringUtil.StrCmp(AV55His_solicitudeswwds_5_tfusuario_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([Usuario] = ''))");
         }
         if ( ! (DateTime.MinValue==AV56His_solicitudeswwds_6_tffechacambio) )
         {
            AddWhere(sWhereString, "([FechaCambio] >= @AV56His_solicitudeswwds_6_tffechacambio)");
         }
         else
         {
            GXv_int8[5] = 1;
         }
         if ( ! (DateTime.MinValue==AV57His_solicitudeswwds_7_tffechacambio_to) )
         {
            AddWhere(sWhereString, "([FechaCambio] <= @AV57His_solicitudeswwds_7_tffechacambio_to)");
         }
         else
         {
            GXv_int8[6] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV59His_solicitudeswwds_9_tfcampomodificado_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV58His_solicitudeswwds_8_tfcampomodificado)) ) )
         {
            AddWhere(sWhereString, "(UPPER([CampoModificado]) like UPPER(@lV58His_solicitudeswwds_8_tfcampomodificado))");
         }
         else
         {
            GXv_int8[7] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59His_solicitudeswwds_9_tfcampomodificado_sel)) && ! ( StringUtil.StrCmp(AV59His_solicitudeswwds_9_tfcampomodificado_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([CampoModificado] = @AV59His_solicitudeswwds_9_tfcampomodificado_sel)");
         }
         else
         {
            GXv_int8[8] = 1;
         }
         if ( StringUtil.StrCmp(AV59His_solicitudeswwds_9_tfcampomodificado_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "([CampoModificado] IS NULL or ([CampoModificado] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV61His_solicitudeswwds_11_tfvaloranterior_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60His_solicitudeswwds_10_tfvaloranterior)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ValorAnterior]) like UPPER(@lV60His_solicitudeswwds_10_tfvaloranterior))");
         }
         else
         {
            GXv_int8[9] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61His_solicitudeswwds_11_tfvaloranterior_sel)) && ! ( StringUtil.StrCmp(AV61His_solicitudeswwds_11_tfvaloranterior_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([ValorAnterior] = @AV61His_solicitudeswwds_11_tfvaloranterior_sel)");
         }
         else
         {
            GXv_int8[10] = 1;
         }
         if ( StringUtil.StrCmp(AV61His_solicitudeswwds_11_tfvaloranterior_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "([ValorAnterior] IS NULL or ([ValorAnterior] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV63His_solicitudeswwds_13_tfvalornuevo_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62His_solicitudeswwds_12_tfvalornuevo)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ValorNuevo]) like UPPER(@lV62His_solicitudeswwds_12_tfvalornuevo))");
         }
         else
         {
            GXv_int8[11] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63His_solicitudeswwds_13_tfvalornuevo_sel)) && ! ( StringUtil.StrCmp(AV63His_solicitudeswwds_13_tfvalornuevo_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([ValorNuevo] = @AV63His_solicitudeswwds_13_tfvalornuevo_sel)");
         }
         else
         {
            GXv_int8[12] = 1;
         }
         if ( StringUtil.StrCmp(AV63His_solicitudeswwds_13_tfvalornuevo_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "([ValorNuevo] IS NULL or ([ValorNuevo] = ''))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY [ValorNuevo]";
         GXv_Object9[0] = scmdbuf;
         GXv_Object9[1] = GXv_int8;
         return GXv_Object9 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_P00KC2(context, (short)dynConstraints[0] , (long)dynConstraints[1] , (long)dynConstraints[2] , (long)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (DateTime)dynConstraints[6] , (DateTime)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (long)dynConstraints[14] , (string)dynConstraints[15] , (DateTime)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] );
               case 1 :
                     return conditional_P00KC3(context, (short)dynConstraints[0] , (long)dynConstraints[1] , (long)dynConstraints[2] , (long)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (DateTime)dynConstraints[6] , (DateTime)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (long)dynConstraints[14] , (string)dynConstraints[15] , (DateTime)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] );
               case 2 :
                     return conditional_P00KC4(context, (short)dynConstraints[0] , (long)dynConstraints[1] , (long)dynConstraints[2] , (long)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (DateTime)dynConstraints[6] , (DateTime)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (long)dynConstraints[14] , (string)dynConstraints[15] , (DateTime)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] );
               case 3 :
                     return conditional_P00KC5(context, (short)dynConstraints[0] , (long)dynConstraints[1] , (long)dynConstraints[2] , (long)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (DateTime)dynConstraints[6] , (DateTime)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (long)dynConstraints[14] , (string)dynConstraints[15] , (DateTime)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] );
         }
         return base.getDynamicStatement(cursor, context, dynConstraints);
      }

      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
         ,new ForEachCursor(def[2])
         ,new ForEachCursor(def[3])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP00KC2;
          prmP00KC2 = new Object[] {
          new ParDef("@AV51His_solicitudeswwds_1_solicitudesid2",GXType.Decimal,18,0) ,
          new ParDef("@AV52His_solicitudeswwds_2_tfsolicitudesid2",GXType.Decimal,18,0) ,
          new ParDef("@AV53His_solicitudeswwds_3_tfsolicitudesid2_to",GXType.Decimal,18,0) ,
          new ParDef("@lV54His_solicitudeswwds_4_tfusuario",GXType.VarChar,100,0) ,
          new ParDef("@AV55His_solicitudeswwds_5_tfusuario_sel",GXType.NVarChar,100,0) ,
          new ParDef("@AV56His_solicitudeswwds_6_tffechacambio",GXType.DateTime,10,8) ,
          new ParDef("@AV57His_solicitudeswwds_7_tffechacambio_to",GXType.DateTime,10,8) ,
          new ParDef("@lV58His_solicitudeswwds_8_tfcampomodificado",GXType.VarChar,100,0) ,
          new ParDef("@AV59His_solicitudeswwds_9_tfcampomodificado_sel",GXType.NVarChar,100,0) ,
          new ParDef("@lV60His_solicitudeswwds_10_tfvaloranterior",GXType.VarChar,500,0) ,
          new ParDef("@AV61His_solicitudeswwds_11_tfvaloranterior_sel",GXType.NVarChar,500,0) ,
          new ParDef("@lV62His_solicitudeswwds_12_tfvalornuevo",GXType.VarChar,500,0) ,
          new ParDef("@AV63His_solicitudeswwds_13_tfvalornuevo_sel",GXType.NVarChar,500,0)
          };
          Object[] prmP00KC3;
          prmP00KC3 = new Object[] {
          new ParDef("@AV51His_solicitudeswwds_1_solicitudesid2",GXType.Decimal,18,0) ,
          new ParDef("@AV52His_solicitudeswwds_2_tfsolicitudesid2",GXType.Decimal,18,0) ,
          new ParDef("@AV53His_solicitudeswwds_3_tfsolicitudesid2_to",GXType.Decimal,18,0) ,
          new ParDef("@lV54His_solicitudeswwds_4_tfusuario",GXType.VarChar,100,0) ,
          new ParDef("@AV55His_solicitudeswwds_5_tfusuario_sel",GXType.NVarChar,100,0) ,
          new ParDef("@AV56His_solicitudeswwds_6_tffechacambio",GXType.DateTime,10,8) ,
          new ParDef("@AV57His_solicitudeswwds_7_tffechacambio_to",GXType.DateTime,10,8) ,
          new ParDef("@lV58His_solicitudeswwds_8_tfcampomodificado",GXType.VarChar,100,0) ,
          new ParDef("@AV59His_solicitudeswwds_9_tfcampomodificado_sel",GXType.NVarChar,100,0) ,
          new ParDef("@lV60His_solicitudeswwds_10_tfvaloranterior",GXType.VarChar,500,0) ,
          new ParDef("@AV61His_solicitudeswwds_11_tfvaloranterior_sel",GXType.NVarChar,500,0) ,
          new ParDef("@lV62His_solicitudeswwds_12_tfvalornuevo",GXType.VarChar,500,0) ,
          new ParDef("@AV63His_solicitudeswwds_13_tfvalornuevo_sel",GXType.NVarChar,500,0)
          };
          Object[] prmP00KC4;
          prmP00KC4 = new Object[] {
          new ParDef("@AV51His_solicitudeswwds_1_solicitudesid2",GXType.Decimal,18,0) ,
          new ParDef("@AV52His_solicitudeswwds_2_tfsolicitudesid2",GXType.Decimal,18,0) ,
          new ParDef("@AV53His_solicitudeswwds_3_tfsolicitudesid2_to",GXType.Decimal,18,0) ,
          new ParDef("@lV54His_solicitudeswwds_4_tfusuario",GXType.VarChar,100,0) ,
          new ParDef("@AV55His_solicitudeswwds_5_tfusuario_sel",GXType.NVarChar,100,0) ,
          new ParDef("@AV56His_solicitudeswwds_6_tffechacambio",GXType.DateTime,10,8) ,
          new ParDef("@AV57His_solicitudeswwds_7_tffechacambio_to",GXType.DateTime,10,8) ,
          new ParDef("@lV58His_solicitudeswwds_8_tfcampomodificado",GXType.VarChar,100,0) ,
          new ParDef("@AV59His_solicitudeswwds_9_tfcampomodificado_sel",GXType.NVarChar,100,0) ,
          new ParDef("@lV60His_solicitudeswwds_10_tfvaloranterior",GXType.VarChar,500,0) ,
          new ParDef("@AV61His_solicitudeswwds_11_tfvaloranterior_sel",GXType.NVarChar,500,0) ,
          new ParDef("@lV62His_solicitudeswwds_12_tfvalornuevo",GXType.VarChar,500,0) ,
          new ParDef("@AV63His_solicitudeswwds_13_tfvalornuevo_sel",GXType.NVarChar,500,0)
          };
          Object[] prmP00KC5;
          prmP00KC5 = new Object[] {
          new ParDef("@AV51His_solicitudeswwds_1_solicitudesid2",GXType.Decimal,18,0) ,
          new ParDef("@AV52His_solicitudeswwds_2_tfsolicitudesid2",GXType.Decimal,18,0) ,
          new ParDef("@AV53His_solicitudeswwds_3_tfsolicitudesid2_to",GXType.Decimal,18,0) ,
          new ParDef("@lV54His_solicitudeswwds_4_tfusuario",GXType.VarChar,100,0) ,
          new ParDef("@AV55His_solicitudeswwds_5_tfusuario_sel",GXType.NVarChar,100,0) ,
          new ParDef("@AV56His_solicitudeswwds_6_tffechacambio",GXType.DateTime,10,8) ,
          new ParDef("@AV57His_solicitudeswwds_7_tffechacambio_to",GXType.DateTime,10,8) ,
          new ParDef("@lV58His_solicitudeswwds_8_tfcampomodificado",GXType.VarChar,100,0) ,
          new ParDef("@AV59His_solicitudeswwds_9_tfcampomodificado_sel",GXType.NVarChar,100,0) ,
          new ParDef("@lV60His_solicitudeswwds_10_tfvaloranterior",GXType.VarChar,500,0) ,
          new ParDef("@AV61His_solicitudeswwds_11_tfvaloranterior_sel",GXType.NVarChar,500,0) ,
          new ParDef("@lV62His_solicitudeswwds_12_tfvalornuevo",GXType.VarChar,500,0) ,
          new ParDef("@AV63His_solicitudeswwds_13_tfvalornuevo_sel",GXType.NVarChar,500,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00KC2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00KC2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00KC3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00KC3,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00KC4", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00KC4,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00KC5", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00KC5,100, GxCacheFrequency.OFF ,true,false )
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
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((DateTime[]) buf[7])[0] = rslt.getGXDateTime(5);
                ((long[]) buf[8])[0] = rslt.getLong(6);
                ((int[]) buf[9])[0] = rslt.getInt(7);
                return;
             case 1 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getVarchar(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((string[]) buf[4])[0] = rslt.getVarchar(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((DateTime[]) buf[6])[0] = rslt.getGXDateTime(4);
                ((string[]) buf[7])[0] = rslt.getVarchar(5);
                ((long[]) buf[8])[0] = rslt.getLong(6);
                ((int[]) buf[9])[0] = rslt.getInt(7);
                return;
             case 2 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getVarchar(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((string[]) buf[4])[0] = rslt.getVarchar(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((DateTime[]) buf[6])[0] = rslt.getGXDateTime(4);
                ((string[]) buf[7])[0] = rslt.getVarchar(5);
                ((long[]) buf[8])[0] = rslt.getLong(6);
                ((int[]) buf[9])[0] = rslt.getInt(7);
                return;
             case 3 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getVarchar(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((string[]) buf[4])[0] = rslt.getVarchar(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((DateTime[]) buf[6])[0] = rslt.getGXDateTime(4);
                ((string[]) buf[7])[0] = rslt.getVarchar(5);
                ((long[]) buf[8])[0] = rslt.getLong(6);
                ((int[]) buf[9])[0] = rslt.getInt(7);
                return;
       }
    }

    public override string getDataStoreName( )
    {
       return "DATASTORE1";
    }

 }

 [ServiceContract(Namespace = "GeneXus.Programs.his_solicitudeswwgetfilterdata_services")]
 [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple)]
 [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
 public class his_solicitudeswwgetfilterdata_services : GxRestService
 {
    [OperationContract(Name = "HIS_SolicitudesWWGetFilterData" )]
    [WebInvoke(Method =  "POST" ,
    	BodyStyle =  WebMessageBodyStyle.Wrapped  ,
    	ResponseFormat = WebMessageFormat.Json,
    	UriTemplate = "/")]
    public void execute( string DDOName ,
                         string SearchTxtParms ,
                         string SearchTxtTo ,
                         out string OptionsJson ,
                         out string OptionsDescJson ,
                         out string OptionIndexesJson )
    {
       OptionsJson = "" ;
       OptionsDescJson = "" ;
       OptionIndexesJson = "" ;
       try
       {
          if ( ! ProcessHeaders("his_solicitudeswwgetfilterdata") )
          {
             return  ;
          }
          his_solicitudeswwgetfilterdata worker = new his_solicitudeswwgetfilterdata(context);
          worker.IsMain = RunAsMain ;
          worker.execute(DDOName,SearchTxtParms,SearchTxtTo,out OptionsJson,out OptionsDescJson,out OptionIndexesJson );
          worker.cleanup( );
       }
       catch ( Exception e )
       {
          WebException(e);
       }
       finally
       {
          Cleanup();
       }
    }

 }

}

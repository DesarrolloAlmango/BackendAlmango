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
   public class historicorelacionesrelacioneswcgetfilterdata : GXProcedure
   {
      public historicorelacionesrelacioneswcgetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public historicorelacionesrelacioneswcgetfilterdata( IGxContext context )
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
         this.AV43DDOName = aP0_DDOName;
         this.AV44SearchTxtParms = aP1_SearchTxtParms;
         this.AV45SearchTxtTo = aP2_SearchTxtTo;
         this.AV46OptionsJson = "" ;
         this.AV47OptionsDescJson = "" ;
         this.AV48OptionIndexesJson = "" ;
         initialize();
         ExecutePrivate();
         aP3_OptionsJson=this.AV46OptionsJson;
         aP4_OptionsDescJson=this.AV47OptionsDescJson;
         aP5_OptionIndexesJson=this.AV48OptionIndexesJson;
      }

      public string executeUdp( string aP0_DDOName ,
                                string aP1_SearchTxtParms ,
                                string aP2_SearchTxtTo ,
                                out string aP3_OptionsJson ,
                                out string aP4_OptionsDescJson )
      {
         execute(aP0_DDOName, aP1_SearchTxtParms, aP2_SearchTxtTo, out aP3_OptionsJson, out aP4_OptionsDescJson, out aP5_OptionIndexesJson);
         return AV48OptionIndexesJson ;
      }

      public void executeSubmit( string aP0_DDOName ,
                                 string aP1_SearchTxtParms ,
                                 string aP2_SearchTxtTo ,
                                 out string aP3_OptionsJson ,
                                 out string aP4_OptionsDescJson ,
                                 out string aP5_OptionIndexesJson )
      {
         this.AV43DDOName = aP0_DDOName;
         this.AV44SearchTxtParms = aP1_SearchTxtParms;
         this.AV45SearchTxtTo = aP2_SearchTxtTo;
         this.AV46OptionsJson = "" ;
         this.AV47OptionsDescJson = "" ;
         this.AV48OptionIndexesJson = "" ;
         SubmitImpl();
         aP3_OptionsJson=this.AV46OptionsJson;
         aP4_OptionsDescJson=this.AV47OptionsDescJson;
         aP5_OptionIndexesJson=this.AV48OptionIndexesJson;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV33Options = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV35OptionsDesc = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV36OptionIndexes = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         GXt_boolean1 = AV8IsAuthorized;
         new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWHistoricoRelaciones", out  GXt_boolean1) ;
         AV8IsAuthorized = GXt_boolean1;
         if ( AV8IsAuthorized )
         {
            AV30MaxItems = 10;
            AV29PageIndex = (short)((String.IsNullOrEmpty(StringUtil.RTrim( AV44SearchTxtParms)) ? 0 : (long)(Math.Round(NumberUtil.Val( StringUtil.Substring( AV44SearchTxtParms, 1, 2), "."), 18, MidpointRounding.ToEven))));
            AV27SearchTxt = (String.IsNullOrEmpty(StringUtil.RTrim( AV44SearchTxtParms)) ? "" : StringUtil.Substring( AV44SearchTxtParms, 3, -1));
            AV28SkipItems = (short)(AV29PageIndex*AV30MaxItems);
            new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV9WWPContext) ;
            /* Execute user subroutine: 'LOADGRIDSTATE' */
            S111 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
            if ( StringUtil.StrCmp(StringUtil.Upper( AV43DDOName), "DDO_HISTORICORELACIONESPROFESIONALESID") == 0 )
            {
               /* Execute user subroutine: 'LOADHISTORICORELACIONESPROFESIONALESIDOPTIONS' */
               S121 ();
               if ( returnInSub )
               {
                  cleanup();
                  if (true) return;
               }
            }
            else if ( StringUtil.StrCmp(StringUtil.Upper( AV43DDOName), "DDO_HISTORICORELACIONESNOMBRE") == 0 )
            {
               /* Execute user subroutine: 'LOADHISTORICORELACIONESNOMBREOPTIONS' */
               S131 ();
               if ( returnInSub )
               {
                  cleanup();
                  if (true) return;
               }
            }
            else if ( StringUtil.StrCmp(StringUtil.Upper( AV43DDOName), "DDO_HISTORICORELACIONESAPELLIDO") == 0 )
            {
               /* Execute user subroutine: 'LOADHISTORICORELACIONESAPELLIDOOPTIONS' */
               S141 ();
               if ( returnInSub )
               {
                  cleanup();
                  if (true) return;
               }
            }
            else if ( StringUtil.StrCmp(StringUtil.Upper( AV43DDOName), "DDO_ESTADOSGTIPO") == 0 )
            {
               /* Execute user subroutine: 'LOADESTADOSGTIPOOPTIONS' */
               S151 ();
               if ( returnInSub )
               {
                  cleanup();
                  if (true) return;
               }
            }
            else if ( StringUtil.StrCmp(StringUtil.Upper( AV43DDOName), "DDO_ESTADOSGNOMBRE") == 0 )
            {
               /* Execute user subroutine: 'LOADESTADOSGNOMBREOPTIONS' */
               S161 ();
               if ( returnInSub )
               {
                  cleanup();
                  if (true) return;
               }
            }
         }
         AV46OptionsJson = AV33Options.ToJSonString(false);
         AV47OptionsDescJson = AV35OptionsDesc.ToJSonString(false);
         AV48OptionIndexesJson = AV36OptionIndexes.ToJSonString(false);
         cleanup();
      }

      protected void S111( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV38Session.Get("HistoricoRelacionesRelacionesWCGridState"), "") == 0 )
         {
            AV40GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "HistoricoRelacionesRelacionesWCGridState"), null, "", "");
         }
         else
         {
            AV40GridState.FromXml(AV38Session.Get("HistoricoRelacionesRelacionesWCGridState"), null, "", "");
         }
         AV50GXV1 = 1;
         while ( AV50GXV1 <= AV40GridState.gxTpr_Filtervalues.Count )
         {
            AV41GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV40GridState.gxTpr_Filtervalues.Item(AV50GXV1));
            if ( StringUtil.StrCmp(AV41GridStateFilterValue.gxTpr_Name, "TFHISTORICORELACIONESID") == 0 )
            {
               AV11TFHistoricoRelacionesId = (long)(Math.Round(NumberUtil.Val( AV41GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV12TFHistoricoRelacionesId_To = (long)(Math.Round(NumberUtil.Val( AV41GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV41GridStateFilterValue.gxTpr_Name, "TFHISTORICORELACIONESPROFESIONALESID") == 0 )
            {
               AV13TFHistoricoRelacionesProfesionalesId = AV41GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV41GridStateFilterValue.gxTpr_Name, "TFHISTORICORELACIONESPROFESIONALESID_SEL") == 0 )
            {
               AV14TFHistoricoRelacionesProfesionalesId_Sel = AV41GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV41GridStateFilterValue.gxTpr_Name, "TFHISTORICORELACIONESNOMBRE") == 0 )
            {
               AV15TFHistoricoRelacionesNombre = AV41GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV41GridStateFilterValue.gxTpr_Name, "TFHISTORICORELACIONESNOMBRE_SEL") == 0 )
            {
               AV16TFHistoricoRelacionesNombre_Sel = AV41GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV41GridStateFilterValue.gxTpr_Name, "TFHISTORICORELACIONESAPELLIDO") == 0 )
            {
               AV17TFHistoricoRelacionesApellido = AV41GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV41GridStateFilterValue.gxTpr_Name, "TFHISTORICORELACIONESAPELLIDO_SEL") == 0 )
            {
               AV18TFHistoricoRelacionesApellido_Sel = AV41GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV41GridStateFilterValue.gxTpr_Name, "TFESTADOSGTIPO") == 0 )
            {
               AV19TFEstadoSGTipo = AV41GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV41GridStateFilterValue.gxTpr_Name, "TFESTADOSGTIPO_SEL") == 0 )
            {
               AV20TFEstadoSGTipo_Sel = AV41GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV41GridStateFilterValue.gxTpr_Name, "TFESTADOSGNOMBRE") == 0 )
            {
               AV21TFEstadoSGNombre = AV41GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV41GridStateFilterValue.gxTpr_Name, "TFESTADOSGNOMBRE_SEL") == 0 )
            {
               AV22TFEstadoSGNombre_Sel = AV41GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV41GridStateFilterValue.gxTpr_Name, "TFHISTORICORELACIONESFECHAALTA") == 0 )
            {
               AV23TFHistoricoRelacionesFechaAlta = context.localUtil.CToT( AV41GridStateFilterValue.gxTpr_Value, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               AV24TFHistoricoRelacionesFechaAlta_To = context.localUtil.CToT( AV41GridStateFilterValue.gxTpr_Valueto, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
            }
            else if ( StringUtil.StrCmp(AV41GridStateFilterValue.gxTpr_Name, "TFHISTORICORELACIONESFECHAMODIF") == 0 )
            {
               AV25TFHistoricoRelacionesFechaModif = context.localUtil.CToT( AV41GridStateFilterValue.gxTpr_Value, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               AV26TFHistoricoRelacionesFechaModif_To = context.localUtil.CToT( AV41GridStateFilterValue.gxTpr_Valueto, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
            }
            else if ( StringUtil.StrCmp(AV41GridStateFilterValue.gxTpr_Name, "PARM_&HISTORICOSOLICITUDESID") == 0 )
            {
               AV49HistoricoSolicitudesID = (long)(Math.Round(NumberUtil.Val( AV41GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
            }
            AV50GXV1 = (int)(AV50GXV1+1);
         }
      }

      protected void S121( )
      {
         /* 'LOADHISTORICORELACIONESPROFESIONALESIDOPTIONS' Routine */
         returnInSub = false;
         AV13TFHistoricoRelacionesProfesionalesId = AV27SearchTxt;
         AV14TFHistoricoRelacionesProfesionalesId_Sel = "";
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV11TFHistoricoRelacionesId ,
                                              AV12TFHistoricoRelacionesId_To ,
                                              AV14TFHistoricoRelacionesProfesionalesId_Sel ,
                                              AV13TFHistoricoRelacionesProfesionalesId ,
                                              AV16TFHistoricoRelacionesNombre_Sel ,
                                              AV15TFHistoricoRelacionesNombre ,
                                              AV18TFHistoricoRelacionesApellido_Sel ,
                                              AV17TFHistoricoRelacionesApellido ,
                                              AV20TFEstadoSGTipo_Sel ,
                                              AV19TFEstadoSGTipo ,
                                              AV22TFEstadoSGNombre_Sel ,
                                              AV21TFEstadoSGNombre ,
                                              AV23TFHistoricoRelacionesFechaAlta ,
                                              AV24TFHistoricoRelacionesFechaAlta_To ,
                                              AV25TFHistoricoRelacionesFechaModif ,
                                              AV26TFHistoricoRelacionesFechaModif_To ,
                                              A156HistoricoRelacionesId ,
                                              A320HistoricoRelacionesProfesional ,
                                              A323HistoricoRelacionesNombre ,
                                              A324HistoricoRelacionesApellido ,
                                              A141EstadoSGTipo ,
                                              A143EstadoSGNombre ,
                                              A321HistoricoRelacionesFechaAlta ,
                                              A322HistoricoRelacionesFechaModif ,
                                              AV49HistoricoSolicitudesID ,
                                              A153HistoricoSolicitudesID } ,
                                              new int[]{
                                              TypeConstants.LONG, TypeConstants.LONG, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.LONG, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.LONG,
                                              TypeConstants.LONG
                                              }
         });
         lV13TFHistoricoRelacionesProfesionalesId = StringUtil.PadR( StringUtil.RTrim( AV13TFHistoricoRelacionesProfesionalesId), 20, "%");
         lV15TFHistoricoRelacionesNombre = StringUtil.PadR( StringUtil.RTrim( AV15TFHistoricoRelacionesNombre), 80, "%");
         lV17TFHistoricoRelacionesApellido = StringUtil.PadR( StringUtil.RTrim( AV17TFHistoricoRelacionesApellido), 80, "%");
         lV19TFEstadoSGTipo = StringUtil.PadR( StringUtil.RTrim( AV19TFEstadoSGTipo), 3, "%");
         lV21TFEstadoSGNombre = StringUtil.PadR( StringUtil.RTrim( AV21TFEstadoSGNombre), 80, "%");
         /* Using cursor P004T2 */
         pr_default.execute(0, new Object[] {AV49HistoricoSolicitudesID, AV11TFHistoricoRelacionesId, AV12TFHistoricoRelacionesId_To, lV13TFHistoricoRelacionesProfesionalesId, AV14TFHistoricoRelacionesProfesionalesId_Sel, lV15TFHistoricoRelacionesNombre, AV16TFHistoricoRelacionesNombre_Sel, lV17TFHistoricoRelacionesApellido, AV18TFHistoricoRelacionesApellido_Sel, lV19TFEstadoSGTipo, AV20TFEstadoSGTipo_Sel, lV21TFEstadoSGNombre, AV22TFEstadoSGNombre_Sel, AV23TFHistoricoRelacionesFechaAlta, AV24TFHistoricoRelacionesFechaAlta_To, AV25TFHistoricoRelacionesFechaModif, AV26TFHistoricoRelacionesFechaModif_To});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRK4T2 = false;
            A142EstadoSGId = P004T2_A142EstadoSGId[0];
            A153HistoricoSolicitudesID = P004T2_A153HistoricoSolicitudesID[0];
            A320HistoricoRelacionesProfesional = P004T2_A320HistoricoRelacionesProfesional[0];
            A322HistoricoRelacionesFechaModif = P004T2_A322HistoricoRelacionesFechaModif[0];
            A321HistoricoRelacionesFechaAlta = P004T2_A321HistoricoRelacionesFechaAlta[0];
            A143EstadoSGNombre = P004T2_A143EstadoSGNombre[0];
            A141EstadoSGTipo = P004T2_A141EstadoSGTipo[0];
            A324HistoricoRelacionesApellido = P004T2_A324HistoricoRelacionesApellido[0];
            A323HistoricoRelacionesNombre = P004T2_A323HistoricoRelacionesNombre[0];
            A156HistoricoRelacionesId = P004T2_A156HistoricoRelacionesId[0];
            A143EstadoSGNombre = P004T2_A143EstadoSGNombre[0];
            AV37count = 0;
            while ( (pr_default.getStatus(0) != 101) && ( P004T2_A153HistoricoSolicitudesID[0] == A153HistoricoSolicitudesID ) && ( StringUtil.StrCmp(P004T2_A320HistoricoRelacionesProfesional[0], A320HistoricoRelacionesProfesional) == 0 ) )
            {
               BRK4T2 = false;
               A156HistoricoRelacionesId = P004T2_A156HistoricoRelacionesId[0];
               AV37count = (long)(AV37count+1);
               BRK4T2 = true;
               pr_default.readNext(0);
            }
            if ( (0==AV28SkipItems) )
            {
               AV32Option = (String.IsNullOrEmpty(StringUtil.RTrim( A320HistoricoRelacionesProfesional)) ? "<#Empty#>" : A320HistoricoRelacionesProfesional);
               AV33Options.Add(AV32Option, 0);
               AV36OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV37count), "Z,ZZZ,ZZZ,ZZ9")), 0);
               if ( AV33Options.Count == 10 )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            else
            {
               AV28SkipItems = (short)(AV28SkipItems-1);
            }
            if ( ! BRK4T2 )
            {
               BRK4T2 = true;
               pr_default.readNext(0);
            }
         }
         pr_default.close(0);
      }

      protected void S131( )
      {
         /* 'LOADHISTORICORELACIONESNOMBREOPTIONS' Routine */
         returnInSub = false;
         AV15TFHistoricoRelacionesNombre = AV27SearchTxt;
         AV16TFHistoricoRelacionesNombre_Sel = "";
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              AV11TFHistoricoRelacionesId ,
                                              AV12TFHistoricoRelacionesId_To ,
                                              AV14TFHistoricoRelacionesProfesionalesId_Sel ,
                                              AV13TFHistoricoRelacionesProfesionalesId ,
                                              AV16TFHistoricoRelacionesNombre_Sel ,
                                              AV15TFHistoricoRelacionesNombre ,
                                              AV18TFHistoricoRelacionesApellido_Sel ,
                                              AV17TFHistoricoRelacionesApellido ,
                                              AV20TFEstadoSGTipo_Sel ,
                                              AV19TFEstadoSGTipo ,
                                              AV22TFEstadoSGNombre_Sel ,
                                              AV21TFEstadoSGNombre ,
                                              AV23TFHistoricoRelacionesFechaAlta ,
                                              AV24TFHistoricoRelacionesFechaAlta_To ,
                                              AV25TFHistoricoRelacionesFechaModif ,
                                              AV26TFHistoricoRelacionesFechaModif_To ,
                                              A156HistoricoRelacionesId ,
                                              A320HistoricoRelacionesProfesional ,
                                              A323HistoricoRelacionesNombre ,
                                              A324HistoricoRelacionesApellido ,
                                              A141EstadoSGTipo ,
                                              A143EstadoSGNombre ,
                                              A321HistoricoRelacionesFechaAlta ,
                                              A322HistoricoRelacionesFechaModif ,
                                              AV49HistoricoSolicitudesID ,
                                              A153HistoricoSolicitudesID } ,
                                              new int[]{
                                              TypeConstants.LONG, TypeConstants.LONG, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.LONG, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.LONG,
                                              TypeConstants.LONG
                                              }
         });
         lV13TFHistoricoRelacionesProfesionalesId = StringUtil.PadR( StringUtil.RTrim( AV13TFHistoricoRelacionesProfesionalesId), 20, "%");
         lV15TFHistoricoRelacionesNombre = StringUtil.PadR( StringUtil.RTrim( AV15TFHistoricoRelacionesNombre), 80, "%");
         lV17TFHistoricoRelacionesApellido = StringUtil.PadR( StringUtil.RTrim( AV17TFHistoricoRelacionesApellido), 80, "%");
         lV19TFEstadoSGTipo = StringUtil.PadR( StringUtil.RTrim( AV19TFEstadoSGTipo), 3, "%");
         lV21TFEstadoSGNombre = StringUtil.PadR( StringUtil.RTrim( AV21TFEstadoSGNombre), 80, "%");
         /* Using cursor P004T3 */
         pr_default.execute(1, new Object[] {AV49HistoricoSolicitudesID, AV11TFHistoricoRelacionesId, AV12TFHistoricoRelacionesId_To, lV13TFHistoricoRelacionesProfesionalesId, AV14TFHistoricoRelacionesProfesionalesId_Sel, lV15TFHistoricoRelacionesNombre, AV16TFHistoricoRelacionesNombre_Sel, lV17TFHistoricoRelacionesApellido, AV18TFHistoricoRelacionesApellido_Sel, lV19TFEstadoSGTipo, AV20TFEstadoSGTipo_Sel, lV21TFEstadoSGNombre, AV22TFEstadoSGNombre_Sel, AV23TFHistoricoRelacionesFechaAlta, AV24TFHistoricoRelacionesFechaAlta_To, AV25TFHistoricoRelacionesFechaModif, AV26TFHistoricoRelacionesFechaModif_To});
         while ( (pr_default.getStatus(1) != 101) )
         {
            BRK4T4 = false;
            A142EstadoSGId = P004T3_A142EstadoSGId[0];
            A153HistoricoSolicitudesID = P004T3_A153HistoricoSolicitudesID[0];
            A323HistoricoRelacionesNombre = P004T3_A323HistoricoRelacionesNombre[0];
            A322HistoricoRelacionesFechaModif = P004T3_A322HistoricoRelacionesFechaModif[0];
            A321HistoricoRelacionesFechaAlta = P004T3_A321HistoricoRelacionesFechaAlta[0];
            A143EstadoSGNombre = P004T3_A143EstadoSGNombre[0];
            A141EstadoSGTipo = P004T3_A141EstadoSGTipo[0];
            A324HistoricoRelacionesApellido = P004T3_A324HistoricoRelacionesApellido[0];
            A320HistoricoRelacionesProfesional = P004T3_A320HistoricoRelacionesProfesional[0];
            A156HistoricoRelacionesId = P004T3_A156HistoricoRelacionesId[0];
            A143EstadoSGNombre = P004T3_A143EstadoSGNombre[0];
            AV37count = 0;
            while ( (pr_default.getStatus(1) != 101) && ( P004T3_A153HistoricoSolicitudesID[0] == A153HistoricoSolicitudesID ) && ( StringUtil.StrCmp(P004T3_A323HistoricoRelacionesNombre[0], A323HistoricoRelacionesNombre) == 0 ) )
            {
               BRK4T4 = false;
               A156HistoricoRelacionesId = P004T3_A156HistoricoRelacionesId[0];
               AV37count = (long)(AV37count+1);
               BRK4T4 = true;
               pr_default.readNext(1);
            }
            if ( (0==AV28SkipItems) )
            {
               AV32Option = (String.IsNullOrEmpty(StringUtil.RTrim( A323HistoricoRelacionesNombre)) ? "<#Empty#>" : A323HistoricoRelacionesNombre);
               AV33Options.Add(AV32Option, 0);
               AV36OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV37count), "Z,ZZZ,ZZZ,ZZ9")), 0);
               if ( AV33Options.Count == 10 )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            else
            {
               AV28SkipItems = (short)(AV28SkipItems-1);
            }
            if ( ! BRK4T4 )
            {
               BRK4T4 = true;
               pr_default.readNext(1);
            }
         }
         pr_default.close(1);
      }

      protected void S141( )
      {
         /* 'LOADHISTORICORELACIONESAPELLIDOOPTIONS' Routine */
         returnInSub = false;
         AV17TFHistoricoRelacionesApellido = AV27SearchTxt;
         AV18TFHistoricoRelacionesApellido_Sel = "";
         pr_default.dynParam(2, new Object[]{ new Object[]{
                                              AV11TFHistoricoRelacionesId ,
                                              AV12TFHistoricoRelacionesId_To ,
                                              AV14TFHistoricoRelacionesProfesionalesId_Sel ,
                                              AV13TFHistoricoRelacionesProfesionalesId ,
                                              AV16TFHistoricoRelacionesNombre_Sel ,
                                              AV15TFHistoricoRelacionesNombre ,
                                              AV18TFHistoricoRelacionesApellido_Sel ,
                                              AV17TFHistoricoRelacionesApellido ,
                                              AV20TFEstadoSGTipo_Sel ,
                                              AV19TFEstadoSGTipo ,
                                              AV22TFEstadoSGNombre_Sel ,
                                              AV21TFEstadoSGNombre ,
                                              AV23TFHistoricoRelacionesFechaAlta ,
                                              AV24TFHistoricoRelacionesFechaAlta_To ,
                                              AV25TFHistoricoRelacionesFechaModif ,
                                              AV26TFHistoricoRelacionesFechaModif_To ,
                                              A156HistoricoRelacionesId ,
                                              A320HistoricoRelacionesProfesional ,
                                              A323HistoricoRelacionesNombre ,
                                              A324HistoricoRelacionesApellido ,
                                              A141EstadoSGTipo ,
                                              A143EstadoSGNombre ,
                                              A321HistoricoRelacionesFechaAlta ,
                                              A322HistoricoRelacionesFechaModif ,
                                              AV49HistoricoSolicitudesID ,
                                              A153HistoricoSolicitudesID } ,
                                              new int[]{
                                              TypeConstants.LONG, TypeConstants.LONG, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.LONG, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.LONG,
                                              TypeConstants.LONG
                                              }
         });
         lV13TFHistoricoRelacionesProfesionalesId = StringUtil.PadR( StringUtil.RTrim( AV13TFHistoricoRelacionesProfesionalesId), 20, "%");
         lV15TFHistoricoRelacionesNombre = StringUtil.PadR( StringUtil.RTrim( AV15TFHistoricoRelacionesNombre), 80, "%");
         lV17TFHistoricoRelacionesApellido = StringUtil.PadR( StringUtil.RTrim( AV17TFHistoricoRelacionesApellido), 80, "%");
         lV19TFEstadoSGTipo = StringUtil.PadR( StringUtil.RTrim( AV19TFEstadoSGTipo), 3, "%");
         lV21TFEstadoSGNombre = StringUtil.PadR( StringUtil.RTrim( AV21TFEstadoSGNombre), 80, "%");
         /* Using cursor P004T4 */
         pr_default.execute(2, new Object[] {AV49HistoricoSolicitudesID, AV11TFHistoricoRelacionesId, AV12TFHistoricoRelacionesId_To, lV13TFHistoricoRelacionesProfesionalesId, AV14TFHistoricoRelacionesProfesionalesId_Sel, lV15TFHistoricoRelacionesNombre, AV16TFHistoricoRelacionesNombre_Sel, lV17TFHistoricoRelacionesApellido, AV18TFHistoricoRelacionesApellido_Sel, lV19TFEstadoSGTipo, AV20TFEstadoSGTipo_Sel, lV21TFEstadoSGNombre, AV22TFEstadoSGNombre_Sel, AV23TFHistoricoRelacionesFechaAlta, AV24TFHistoricoRelacionesFechaAlta_To, AV25TFHistoricoRelacionesFechaModif, AV26TFHistoricoRelacionesFechaModif_To});
         while ( (pr_default.getStatus(2) != 101) )
         {
            BRK4T6 = false;
            A142EstadoSGId = P004T4_A142EstadoSGId[0];
            A153HistoricoSolicitudesID = P004T4_A153HistoricoSolicitudesID[0];
            A324HistoricoRelacionesApellido = P004T4_A324HistoricoRelacionesApellido[0];
            A322HistoricoRelacionesFechaModif = P004T4_A322HistoricoRelacionesFechaModif[0];
            A321HistoricoRelacionesFechaAlta = P004T4_A321HistoricoRelacionesFechaAlta[0];
            A143EstadoSGNombre = P004T4_A143EstadoSGNombre[0];
            A141EstadoSGTipo = P004T4_A141EstadoSGTipo[0];
            A323HistoricoRelacionesNombre = P004T4_A323HistoricoRelacionesNombre[0];
            A320HistoricoRelacionesProfesional = P004T4_A320HistoricoRelacionesProfesional[0];
            A156HistoricoRelacionesId = P004T4_A156HistoricoRelacionesId[0];
            A143EstadoSGNombre = P004T4_A143EstadoSGNombre[0];
            AV37count = 0;
            while ( (pr_default.getStatus(2) != 101) && ( P004T4_A153HistoricoSolicitudesID[0] == A153HistoricoSolicitudesID ) && ( StringUtil.StrCmp(P004T4_A324HistoricoRelacionesApellido[0], A324HistoricoRelacionesApellido) == 0 ) )
            {
               BRK4T6 = false;
               A156HistoricoRelacionesId = P004T4_A156HistoricoRelacionesId[0];
               AV37count = (long)(AV37count+1);
               BRK4T6 = true;
               pr_default.readNext(2);
            }
            if ( (0==AV28SkipItems) )
            {
               AV32Option = (String.IsNullOrEmpty(StringUtil.RTrim( A324HistoricoRelacionesApellido)) ? "<#Empty#>" : A324HistoricoRelacionesApellido);
               AV33Options.Add(AV32Option, 0);
               AV36OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV37count), "Z,ZZZ,ZZZ,ZZ9")), 0);
               if ( AV33Options.Count == 10 )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            else
            {
               AV28SkipItems = (short)(AV28SkipItems-1);
            }
            if ( ! BRK4T6 )
            {
               BRK4T6 = true;
               pr_default.readNext(2);
            }
         }
         pr_default.close(2);
      }

      protected void S151( )
      {
         /* 'LOADESTADOSGTIPOOPTIONS' Routine */
         returnInSub = false;
         AV19TFEstadoSGTipo = AV27SearchTxt;
         AV20TFEstadoSGTipo_Sel = "";
         pr_default.dynParam(3, new Object[]{ new Object[]{
                                              AV11TFHistoricoRelacionesId ,
                                              AV12TFHistoricoRelacionesId_To ,
                                              AV14TFHistoricoRelacionesProfesionalesId_Sel ,
                                              AV13TFHistoricoRelacionesProfesionalesId ,
                                              AV16TFHistoricoRelacionesNombre_Sel ,
                                              AV15TFHistoricoRelacionesNombre ,
                                              AV18TFHistoricoRelacionesApellido_Sel ,
                                              AV17TFHistoricoRelacionesApellido ,
                                              AV20TFEstadoSGTipo_Sel ,
                                              AV19TFEstadoSGTipo ,
                                              AV22TFEstadoSGNombre_Sel ,
                                              AV21TFEstadoSGNombre ,
                                              AV23TFHistoricoRelacionesFechaAlta ,
                                              AV24TFHistoricoRelacionesFechaAlta_To ,
                                              AV25TFHistoricoRelacionesFechaModif ,
                                              AV26TFHistoricoRelacionesFechaModif_To ,
                                              A156HistoricoRelacionesId ,
                                              A320HistoricoRelacionesProfesional ,
                                              A323HistoricoRelacionesNombre ,
                                              A324HistoricoRelacionesApellido ,
                                              A141EstadoSGTipo ,
                                              A143EstadoSGNombre ,
                                              A321HistoricoRelacionesFechaAlta ,
                                              A322HistoricoRelacionesFechaModif ,
                                              AV49HistoricoSolicitudesID ,
                                              A153HistoricoSolicitudesID } ,
                                              new int[]{
                                              TypeConstants.LONG, TypeConstants.LONG, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.LONG, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.LONG,
                                              TypeConstants.LONG
                                              }
         });
         lV13TFHistoricoRelacionesProfesionalesId = StringUtil.PadR( StringUtil.RTrim( AV13TFHistoricoRelacionesProfesionalesId), 20, "%");
         lV15TFHistoricoRelacionesNombre = StringUtil.PadR( StringUtil.RTrim( AV15TFHistoricoRelacionesNombre), 80, "%");
         lV17TFHistoricoRelacionesApellido = StringUtil.PadR( StringUtil.RTrim( AV17TFHistoricoRelacionesApellido), 80, "%");
         lV19TFEstadoSGTipo = StringUtil.PadR( StringUtil.RTrim( AV19TFEstadoSGTipo), 3, "%");
         lV21TFEstadoSGNombre = StringUtil.PadR( StringUtil.RTrim( AV21TFEstadoSGNombre), 80, "%");
         /* Using cursor P004T5 */
         pr_default.execute(3, new Object[] {AV49HistoricoSolicitudesID, AV11TFHistoricoRelacionesId, AV12TFHistoricoRelacionesId_To, lV13TFHistoricoRelacionesProfesionalesId, AV14TFHistoricoRelacionesProfesionalesId_Sel, lV15TFHistoricoRelacionesNombre, AV16TFHistoricoRelacionesNombre_Sel, lV17TFHistoricoRelacionesApellido, AV18TFHistoricoRelacionesApellido_Sel, lV19TFEstadoSGTipo, AV20TFEstadoSGTipo_Sel, lV21TFEstadoSGNombre, AV22TFEstadoSGNombre_Sel, AV23TFHistoricoRelacionesFechaAlta, AV24TFHistoricoRelacionesFechaAlta_To, AV25TFHistoricoRelacionesFechaModif, AV26TFHistoricoRelacionesFechaModif_To});
         while ( (pr_default.getStatus(3) != 101) )
         {
            BRK4T8 = false;
            A142EstadoSGId = P004T5_A142EstadoSGId[0];
            A153HistoricoSolicitudesID = P004T5_A153HistoricoSolicitudesID[0];
            A141EstadoSGTipo = P004T5_A141EstadoSGTipo[0];
            A322HistoricoRelacionesFechaModif = P004T5_A322HistoricoRelacionesFechaModif[0];
            A321HistoricoRelacionesFechaAlta = P004T5_A321HistoricoRelacionesFechaAlta[0];
            A143EstadoSGNombre = P004T5_A143EstadoSGNombre[0];
            A324HistoricoRelacionesApellido = P004T5_A324HistoricoRelacionesApellido[0];
            A323HistoricoRelacionesNombre = P004T5_A323HistoricoRelacionesNombre[0];
            A320HistoricoRelacionesProfesional = P004T5_A320HistoricoRelacionesProfesional[0];
            A156HistoricoRelacionesId = P004T5_A156HistoricoRelacionesId[0];
            A143EstadoSGNombre = P004T5_A143EstadoSGNombre[0];
            AV37count = 0;
            while ( (pr_default.getStatus(3) != 101) && ( P004T5_A153HistoricoSolicitudesID[0] == A153HistoricoSolicitudesID ) && ( StringUtil.StrCmp(P004T5_A141EstadoSGTipo[0], A141EstadoSGTipo) == 0 ) )
            {
               BRK4T8 = false;
               A156HistoricoRelacionesId = P004T5_A156HistoricoRelacionesId[0];
               AV37count = (long)(AV37count+1);
               BRK4T8 = true;
               pr_default.readNext(3);
            }
            if ( (0==AV28SkipItems) )
            {
               AV32Option = (String.IsNullOrEmpty(StringUtil.RTrim( A141EstadoSGTipo)) ? "<#Empty#>" : A141EstadoSGTipo);
               AV33Options.Add(AV32Option, 0);
               AV36OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV37count), "Z,ZZZ,ZZZ,ZZ9")), 0);
               if ( AV33Options.Count == 10 )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            else
            {
               AV28SkipItems = (short)(AV28SkipItems-1);
            }
            if ( ! BRK4T8 )
            {
               BRK4T8 = true;
               pr_default.readNext(3);
            }
         }
         pr_default.close(3);
      }

      protected void S161( )
      {
         /* 'LOADESTADOSGNOMBREOPTIONS' Routine */
         returnInSub = false;
         AV21TFEstadoSGNombre = AV27SearchTxt;
         AV22TFEstadoSGNombre_Sel = "";
         pr_default.dynParam(4, new Object[]{ new Object[]{
                                              AV11TFHistoricoRelacionesId ,
                                              AV12TFHistoricoRelacionesId_To ,
                                              AV14TFHistoricoRelacionesProfesionalesId_Sel ,
                                              AV13TFHistoricoRelacionesProfesionalesId ,
                                              AV16TFHistoricoRelacionesNombre_Sel ,
                                              AV15TFHistoricoRelacionesNombre ,
                                              AV18TFHistoricoRelacionesApellido_Sel ,
                                              AV17TFHistoricoRelacionesApellido ,
                                              AV20TFEstadoSGTipo_Sel ,
                                              AV19TFEstadoSGTipo ,
                                              AV22TFEstadoSGNombre_Sel ,
                                              AV21TFEstadoSGNombre ,
                                              AV23TFHistoricoRelacionesFechaAlta ,
                                              AV24TFHistoricoRelacionesFechaAlta_To ,
                                              AV25TFHistoricoRelacionesFechaModif ,
                                              AV26TFHistoricoRelacionesFechaModif_To ,
                                              A156HistoricoRelacionesId ,
                                              A320HistoricoRelacionesProfesional ,
                                              A323HistoricoRelacionesNombre ,
                                              A324HistoricoRelacionesApellido ,
                                              A141EstadoSGTipo ,
                                              A143EstadoSGNombre ,
                                              A321HistoricoRelacionesFechaAlta ,
                                              A322HistoricoRelacionesFechaModif ,
                                              AV49HistoricoSolicitudesID ,
                                              A153HistoricoSolicitudesID } ,
                                              new int[]{
                                              TypeConstants.LONG, TypeConstants.LONG, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.LONG, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.LONG,
                                              TypeConstants.LONG
                                              }
         });
         lV13TFHistoricoRelacionesProfesionalesId = StringUtil.PadR( StringUtil.RTrim( AV13TFHistoricoRelacionesProfesionalesId), 20, "%");
         lV15TFHistoricoRelacionesNombre = StringUtil.PadR( StringUtil.RTrim( AV15TFHistoricoRelacionesNombre), 80, "%");
         lV17TFHistoricoRelacionesApellido = StringUtil.PadR( StringUtil.RTrim( AV17TFHistoricoRelacionesApellido), 80, "%");
         lV19TFEstadoSGTipo = StringUtil.PadR( StringUtil.RTrim( AV19TFEstadoSGTipo), 3, "%");
         lV21TFEstadoSGNombre = StringUtil.PadR( StringUtil.RTrim( AV21TFEstadoSGNombre), 80, "%");
         /* Using cursor P004T6 */
         pr_default.execute(4, new Object[] {AV49HistoricoSolicitudesID, AV11TFHistoricoRelacionesId, AV12TFHistoricoRelacionesId_To, lV13TFHistoricoRelacionesProfesionalesId, AV14TFHistoricoRelacionesProfesionalesId_Sel, lV15TFHistoricoRelacionesNombre, AV16TFHistoricoRelacionesNombre_Sel, lV17TFHistoricoRelacionesApellido, AV18TFHistoricoRelacionesApellido_Sel, lV19TFEstadoSGTipo, AV20TFEstadoSGTipo_Sel, lV21TFEstadoSGNombre, AV22TFEstadoSGNombre_Sel, AV23TFHistoricoRelacionesFechaAlta, AV24TFHistoricoRelacionesFechaAlta_To, AV25TFHistoricoRelacionesFechaModif, AV26TFHistoricoRelacionesFechaModif_To});
         while ( (pr_default.getStatus(4) != 101) )
         {
            BRK4T10 = false;
            A153HistoricoSolicitudesID = P004T6_A153HistoricoSolicitudesID[0];
            A142EstadoSGId = P004T6_A142EstadoSGId[0];
            A141EstadoSGTipo = P004T6_A141EstadoSGTipo[0];
            A322HistoricoRelacionesFechaModif = P004T6_A322HistoricoRelacionesFechaModif[0];
            A321HistoricoRelacionesFechaAlta = P004T6_A321HistoricoRelacionesFechaAlta[0];
            A143EstadoSGNombre = P004T6_A143EstadoSGNombre[0];
            A324HistoricoRelacionesApellido = P004T6_A324HistoricoRelacionesApellido[0];
            A323HistoricoRelacionesNombre = P004T6_A323HistoricoRelacionesNombre[0];
            A320HistoricoRelacionesProfesional = P004T6_A320HistoricoRelacionesProfesional[0];
            A156HistoricoRelacionesId = P004T6_A156HistoricoRelacionesId[0];
            A143EstadoSGNombre = P004T6_A143EstadoSGNombre[0];
            AV37count = 0;
            while ( (pr_default.getStatus(4) != 101) && ( P004T6_A153HistoricoSolicitudesID[0] == A153HistoricoSolicitudesID ) && ( StringUtil.StrCmp(P004T6_A141EstadoSGTipo[0], A141EstadoSGTipo) == 0 ) && ( P004T6_A142EstadoSGId[0] == A142EstadoSGId ) )
            {
               BRK4T10 = false;
               A156HistoricoRelacionesId = P004T6_A156HistoricoRelacionesId[0];
               AV37count = (long)(AV37count+1);
               BRK4T10 = true;
               pr_default.readNext(4);
            }
            AV32Option = (String.IsNullOrEmpty(StringUtil.RTrim( A143EstadoSGNombre)) ? "<#Empty#>" : A143EstadoSGNombre);
            AV31InsertIndex = 1;
            while ( ( StringUtil.StrCmp(AV32Option, "<#Empty#>") != 0 ) && ( AV31InsertIndex <= AV33Options.Count ) && ( ( StringUtil.StrCmp(((string)AV33Options.Item(AV31InsertIndex)), AV32Option) < 0 ) || ( StringUtil.StrCmp(((string)AV33Options.Item(AV31InsertIndex)), "<#Empty#>") == 0 ) ) )
            {
               AV31InsertIndex = (int)(AV31InsertIndex+1);
            }
            AV33Options.Add(AV32Option, AV31InsertIndex);
            AV36OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV37count), "Z,ZZZ,ZZZ,ZZ9")), AV31InsertIndex);
            if ( AV33Options.Count == AV28SkipItems + 11 )
            {
               AV33Options.RemoveItem(AV33Options.Count);
               AV36OptionIndexes.RemoveItem(AV36OptionIndexes.Count);
            }
            if ( ! BRK4T10 )
            {
               BRK4T10 = true;
               pr_default.readNext(4);
            }
         }
         pr_default.close(4);
         while ( AV28SkipItems > 0 )
         {
            AV33Options.RemoveItem(1);
            AV36OptionIndexes.RemoveItem(1);
            AV28SkipItems = (short)(AV28SkipItems-1);
         }
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
         AV46OptionsJson = "";
         AV47OptionsDescJson = "";
         AV48OptionIndexesJson = "";
         AV33Options = new GxSimpleCollection<string>();
         AV35OptionsDesc = new GxSimpleCollection<string>();
         AV36OptionIndexes = new GxSimpleCollection<string>();
         AV27SearchTxt = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV38Session = context.GetSession();
         AV40GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV41GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV13TFHistoricoRelacionesProfesionalesId = "";
         AV14TFHistoricoRelacionesProfesionalesId_Sel = "";
         AV15TFHistoricoRelacionesNombre = "";
         AV16TFHistoricoRelacionesNombre_Sel = "";
         AV17TFHistoricoRelacionesApellido = "";
         AV18TFHistoricoRelacionesApellido_Sel = "";
         AV19TFEstadoSGTipo = "";
         AV20TFEstadoSGTipo_Sel = "";
         AV21TFEstadoSGNombre = "";
         AV22TFEstadoSGNombre_Sel = "";
         AV23TFHistoricoRelacionesFechaAlta = (DateTime)(DateTime.MinValue);
         AV24TFHistoricoRelacionesFechaAlta_To = (DateTime)(DateTime.MinValue);
         AV25TFHistoricoRelacionesFechaModif = (DateTime)(DateTime.MinValue);
         AV26TFHistoricoRelacionesFechaModif_To = (DateTime)(DateTime.MinValue);
         lV13TFHistoricoRelacionesProfesionalesId = "";
         lV15TFHistoricoRelacionesNombre = "";
         lV17TFHistoricoRelacionesApellido = "";
         lV19TFEstadoSGTipo = "";
         lV21TFEstadoSGNombre = "";
         A320HistoricoRelacionesProfesional = "";
         A323HistoricoRelacionesNombre = "";
         A324HistoricoRelacionesApellido = "";
         A141EstadoSGTipo = "";
         A143EstadoSGNombre = "";
         A321HistoricoRelacionesFechaAlta = (DateTime)(DateTime.MinValue);
         A322HistoricoRelacionesFechaModif = (DateTime)(DateTime.MinValue);
         P004T2_A142EstadoSGId = new int[1] ;
         P004T2_A153HistoricoSolicitudesID = new long[1] ;
         P004T2_A320HistoricoRelacionesProfesional = new string[] {""} ;
         P004T2_A322HistoricoRelacionesFechaModif = new DateTime[] {DateTime.MinValue} ;
         P004T2_A321HistoricoRelacionesFechaAlta = new DateTime[] {DateTime.MinValue} ;
         P004T2_A143EstadoSGNombre = new string[] {""} ;
         P004T2_A141EstadoSGTipo = new string[] {""} ;
         P004T2_A324HistoricoRelacionesApellido = new string[] {""} ;
         P004T2_A323HistoricoRelacionesNombre = new string[] {""} ;
         P004T2_A156HistoricoRelacionesId = new long[1] ;
         AV32Option = "";
         P004T3_A142EstadoSGId = new int[1] ;
         P004T3_A153HistoricoSolicitudesID = new long[1] ;
         P004T3_A323HistoricoRelacionesNombre = new string[] {""} ;
         P004T3_A322HistoricoRelacionesFechaModif = new DateTime[] {DateTime.MinValue} ;
         P004T3_A321HistoricoRelacionesFechaAlta = new DateTime[] {DateTime.MinValue} ;
         P004T3_A143EstadoSGNombre = new string[] {""} ;
         P004T3_A141EstadoSGTipo = new string[] {""} ;
         P004T3_A324HistoricoRelacionesApellido = new string[] {""} ;
         P004T3_A320HistoricoRelacionesProfesional = new string[] {""} ;
         P004T3_A156HistoricoRelacionesId = new long[1] ;
         P004T4_A142EstadoSGId = new int[1] ;
         P004T4_A153HistoricoSolicitudesID = new long[1] ;
         P004T4_A324HistoricoRelacionesApellido = new string[] {""} ;
         P004T4_A322HistoricoRelacionesFechaModif = new DateTime[] {DateTime.MinValue} ;
         P004T4_A321HistoricoRelacionesFechaAlta = new DateTime[] {DateTime.MinValue} ;
         P004T4_A143EstadoSGNombre = new string[] {""} ;
         P004T4_A141EstadoSGTipo = new string[] {""} ;
         P004T4_A323HistoricoRelacionesNombre = new string[] {""} ;
         P004T4_A320HistoricoRelacionesProfesional = new string[] {""} ;
         P004T4_A156HistoricoRelacionesId = new long[1] ;
         P004T5_A142EstadoSGId = new int[1] ;
         P004T5_A153HistoricoSolicitudesID = new long[1] ;
         P004T5_A141EstadoSGTipo = new string[] {""} ;
         P004T5_A322HistoricoRelacionesFechaModif = new DateTime[] {DateTime.MinValue} ;
         P004T5_A321HistoricoRelacionesFechaAlta = new DateTime[] {DateTime.MinValue} ;
         P004T5_A143EstadoSGNombre = new string[] {""} ;
         P004T5_A324HistoricoRelacionesApellido = new string[] {""} ;
         P004T5_A323HistoricoRelacionesNombre = new string[] {""} ;
         P004T5_A320HistoricoRelacionesProfesional = new string[] {""} ;
         P004T5_A156HistoricoRelacionesId = new long[1] ;
         P004T6_A153HistoricoSolicitudesID = new long[1] ;
         P004T6_A142EstadoSGId = new int[1] ;
         P004T6_A141EstadoSGTipo = new string[] {""} ;
         P004T6_A322HistoricoRelacionesFechaModif = new DateTime[] {DateTime.MinValue} ;
         P004T6_A321HistoricoRelacionesFechaAlta = new DateTime[] {DateTime.MinValue} ;
         P004T6_A143EstadoSGNombre = new string[] {""} ;
         P004T6_A324HistoricoRelacionesApellido = new string[] {""} ;
         P004T6_A323HistoricoRelacionesNombre = new string[] {""} ;
         P004T6_A320HistoricoRelacionesProfesional = new string[] {""} ;
         P004T6_A156HistoricoRelacionesId = new long[1] ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.historicorelacionesrelacioneswcgetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P004T2_A142EstadoSGId, P004T2_A153HistoricoSolicitudesID, P004T2_A320HistoricoRelacionesProfesional, P004T2_A322HistoricoRelacionesFechaModif, P004T2_A321HistoricoRelacionesFechaAlta, P004T2_A143EstadoSGNombre, P004T2_A141EstadoSGTipo, P004T2_A324HistoricoRelacionesApellido, P004T2_A323HistoricoRelacionesNombre, P004T2_A156HistoricoRelacionesId
               }
               , new Object[] {
               P004T3_A142EstadoSGId, P004T3_A153HistoricoSolicitudesID, P004T3_A323HistoricoRelacionesNombre, P004T3_A322HistoricoRelacionesFechaModif, P004T3_A321HistoricoRelacionesFechaAlta, P004T3_A143EstadoSGNombre, P004T3_A141EstadoSGTipo, P004T3_A324HistoricoRelacionesApellido, P004T3_A320HistoricoRelacionesProfesional, P004T3_A156HistoricoRelacionesId
               }
               , new Object[] {
               P004T4_A142EstadoSGId, P004T4_A153HistoricoSolicitudesID, P004T4_A324HistoricoRelacionesApellido, P004T4_A322HistoricoRelacionesFechaModif, P004T4_A321HistoricoRelacionesFechaAlta, P004T4_A143EstadoSGNombre, P004T4_A141EstadoSGTipo, P004T4_A323HistoricoRelacionesNombre, P004T4_A320HistoricoRelacionesProfesional, P004T4_A156HistoricoRelacionesId
               }
               , new Object[] {
               P004T5_A142EstadoSGId, P004T5_A153HistoricoSolicitudesID, P004T5_A141EstadoSGTipo, P004T5_A322HistoricoRelacionesFechaModif, P004T5_A321HistoricoRelacionesFechaAlta, P004T5_A143EstadoSGNombre, P004T5_A324HistoricoRelacionesApellido, P004T5_A323HistoricoRelacionesNombre, P004T5_A320HistoricoRelacionesProfesional, P004T5_A156HistoricoRelacionesId
               }
               , new Object[] {
               P004T6_A153HistoricoSolicitudesID, P004T6_A142EstadoSGId, P004T6_A141EstadoSGTipo, P004T6_A322HistoricoRelacionesFechaModif, P004T6_A321HistoricoRelacionesFechaAlta, P004T6_A143EstadoSGNombre, P004T6_A324HistoricoRelacionesApellido, P004T6_A323HistoricoRelacionesNombre, P004T6_A320HistoricoRelacionesProfesional, P004T6_A156HistoricoRelacionesId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV30MaxItems ;
      private short AV29PageIndex ;
      private short AV28SkipItems ;
      private int AV50GXV1 ;
      private int A142EstadoSGId ;
      private int AV31InsertIndex ;
      private long AV11TFHistoricoRelacionesId ;
      private long AV12TFHistoricoRelacionesId_To ;
      private long AV49HistoricoSolicitudesID ;
      private long A156HistoricoRelacionesId ;
      private long A153HistoricoSolicitudesID ;
      private long AV37count ;
      private string AV13TFHistoricoRelacionesProfesionalesId ;
      private string AV14TFHistoricoRelacionesProfesionalesId_Sel ;
      private string AV15TFHistoricoRelacionesNombre ;
      private string AV16TFHistoricoRelacionesNombre_Sel ;
      private string AV17TFHistoricoRelacionesApellido ;
      private string AV18TFHistoricoRelacionesApellido_Sel ;
      private string AV19TFEstadoSGTipo ;
      private string AV20TFEstadoSGTipo_Sel ;
      private string AV21TFEstadoSGNombre ;
      private string AV22TFEstadoSGNombre_Sel ;
      private string lV13TFHistoricoRelacionesProfesionalesId ;
      private string lV15TFHistoricoRelacionesNombre ;
      private string lV17TFHistoricoRelacionesApellido ;
      private string lV19TFEstadoSGTipo ;
      private string lV21TFEstadoSGNombre ;
      private string A320HistoricoRelacionesProfesional ;
      private string A323HistoricoRelacionesNombre ;
      private string A324HistoricoRelacionesApellido ;
      private string A141EstadoSGTipo ;
      private string A143EstadoSGNombre ;
      private DateTime AV23TFHistoricoRelacionesFechaAlta ;
      private DateTime AV24TFHistoricoRelacionesFechaAlta_To ;
      private DateTime AV25TFHistoricoRelacionesFechaModif ;
      private DateTime AV26TFHistoricoRelacionesFechaModif_To ;
      private DateTime A321HistoricoRelacionesFechaAlta ;
      private DateTime A322HistoricoRelacionesFechaModif ;
      private bool AV8IsAuthorized ;
      private bool GXt_boolean1 ;
      private bool returnInSub ;
      private bool BRK4T2 ;
      private bool BRK4T4 ;
      private bool BRK4T6 ;
      private bool BRK4T8 ;
      private bool BRK4T10 ;
      private string AV46OptionsJson ;
      private string AV47OptionsDescJson ;
      private string AV48OptionIndexesJson ;
      private string AV43DDOName ;
      private string AV44SearchTxtParms ;
      private string AV45SearchTxtTo ;
      private string AV27SearchTxt ;
      private string AV32Option ;
      private IGxSession AV38Session ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GxSimpleCollection<string> AV33Options ;
      private GxSimpleCollection<string> AV35OptionsDesc ;
      private GxSimpleCollection<string> AV36OptionIndexes ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV40GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV41GridStateFilterValue ;
      private IDataStoreProvider pr_default ;
      private int[] P004T2_A142EstadoSGId ;
      private long[] P004T2_A153HistoricoSolicitudesID ;
      private string[] P004T2_A320HistoricoRelacionesProfesional ;
      private DateTime[] P004T2_A322HistoricoRelacionesFechaModif ;
      private DateTime[] P004T2_A321HistoricoRelacionesFechaAlta ;
      private string[] P004T2_A143EstadoSGNombre ;
      private string[] P004T2_A141EstadoSGTipo ;
      private string[] P004T2_A324HistoricoRelacionesApellido ;
      private string[] P004T2_A323HistoricoRelacionesNombre ;
      private long[] P004T2_A156HistoricoRelacionesId ;
      private int[] P004T3_A142EstadoSGId ;
      private long[] P004T3_A153HistoricoSolicitudesID ;
      private string[] P004T3_A323HistoricoRelacionesNombre ;
      private DateTime[] P004T3_A322HistoricoRelacionesFechaModif ;
      private DateTime[] P004T3_A321HistoricoRelacionesFechaAlta ;
      private string[] P004T3_A143EstadoSGNombre ;
      private string[] P004T3_A141EstadoSGTipo ;
      private string[] P004T3_A324HistoricoRelacionesApellido ;
      private string[] P004T3_A320HistoricoRelacionesProfesional ;
      private long[] P004T3_A156HistoricoRelacionesId ;
      private int[] P004T4_A142EstadoSGId ;
      private long[] P004T4_A153HistoricoSolicitudesID ;
      private string[] P004T4_A324HistoricoRelacionesApellido ;
      private DateTime[] P004T4_A322HistoricoRelacionesFechaModif ;
      private DateTime[] P004T4_A321HistoricoRelacionesFechaAlta ;
      private string[] P004T4_A143EstadoSGNombre ;
      private string[] P004T4_A141EstadoSGTipo ;
      private string[] P004T4_A323HistoricoRelacionesNombre ;
      private string[] P004T4_A320HistoricoRelacionesProfesional ;
      private long[] P004T4_A156HistoricoRelacionesId ;
      private int[] P004T5_A142EstadoSGId ;
      private long[] P004T5_A153HistoricoSolicitudesID ;
      private string[] P004T5_A141EstadoSGTipo ;
      private DateTime[] P004T5_A322HistoricoRelacionesFechaModif ;
      private DateTime[] P004T5_A321HistoricoRelacionesFechaAlta ;
      private string[] P004T5_A143EstadoSGNombre ;
      private string[] P004T5_A324HistoricoRelacionesApellido ;
      private string[] P004T5_A323HistoricoRelacionesNombre ;
      private string[] P004T5_A320HistoricoRelacionesProfesional ;
      private long[] P004T5_A156HistoricoRelacionesId ;
      private long[] P004T6_A153HistoricoSolicitudesID ;
      private int[] P004T6_A142EstadoSGId ;
      private string[] P004T6_A141EstadoSGTipo ;
      private DateTime[] P004T6_A322HistoricoRelacionesFechaModif ;
      private DateTime[] P004T6_A321HistoricoRelacionesFechaAlta ;
      private string[] P004T6_A143EstadoSGNombre ;
      private string[] P004T6_A324HistoricoRelacionesApellido ;
      private string[] P004T6_A323HistoricoRelacionesNombre ;
      private string[] P004T6_A320HistoricoRelacionesProfesional ;
      private long[] P004T6_A156HistoricoRelacionesId ;
      private string aP3_OptionsJson ;
      private string aP4_OptionsDescJson ;
      private string aP5_OptionIndexesJson ;
   }

   public class historicorelacionesrelacioneswcgetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P004T2( IGxContext context ,
                                             long AV11TFHistoricoRelacionesId ,
                                             long AV12TFHistoricoRelacionesId_To ,
                                             string AV14TFHistoricoRelacionesProfesionalesId_Sel ,
                                             string AV13TFHistoricoRelacionesProfesionalesId ,
                                             string AV16TFHistoricoRelacionesNombre_Sel ,
                                             string AV15TFHistoricoRelacionesNombre ,
                                             string AV18TFHistoricoRelacionesApellido_Sel ,
                                             string AV17TFHistoricoRelacionesApellido ,
                                             string AV20TFEstadoSGTipo_Sel ,
                                             string AV19TFEstadoSGTipo ,
                                             string AV22TFEstadoSGNombre_Sel ,
                                             string AV21TFEstadoSGNombre ,
                                             DateTime AV23TFHistoricoRelacionesFechaAlta ,
                                             DateTime AV24TFHistoricoRelacionesFechaAlta_To ,
                                             DateTime AV25TFHistoricoRelacionesFechaModif ,
                                             DateTime AV26TFHistoricoRelacionesFechaModif_To ,
                                             long A156HistoricoRelacionesId ,
                                             string A320HistoricoRelacionesProfesional ,
                                             string A323HistoricoRelacionesNombre ,
                                             string A324HistoricoRelacionesApellido ,
                                             string A141EstadoSGTipo ,
                                             string A143EstadoSGNombre ,
                                             DateTime A321HistoricoRelacionesFechaAlta ,
                                             DateTime A322HistoricoRelacionesFechaModif ,
                                             long AV49HistoricoSolicitudesID ,
                                             long A153HistoricoSolicitudesID )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int2 = new short[17];
         Object[] GXv_Object3 = new Object[2];
         scmdbuf = "SELECT T1.[EstadoSGId] AS EstadoSGId, T1.[HistoricoSolicitudesID], T1.[HistoricoRelacionesProfesional], T1.[HistoricoRelacionesFechaModif], T1.[HistoricoRelacionesFechaAlta], T2.[EstadosGenericosNombre] AS EstadoSGNombre, T1.[EstadoSGTipo] AS EstadoSGTipo, T1.[HistoricoRelacionesApellido], T1.[HistoricoRelacionesNombre], T1.[HistoricoRelacionesId] FROM ([HistoricoRelacionesRelaciones] T1 INNER JOIN [EstadosGenericos] T2 ON T2.[EstadosTipo] = T1.[EstadoSGTipo] AND T2.[EstadosGenericosId] = T1.[EstadoSGId])";
         AddWhere(sWhereString, "(T1.[HistoricoSolicitudesID] = @AV49HistoricoSolicitudesID)");
         if ( ! (0==AV11TFHistoricoRelacionesId) )
         {
            AddWhere(sWhereString, "(T1.[HistoricoRelacionesId] >= @AV11TFHistoricoRelacionesId)");
         }
         else
         {
            GXv_int2[1] = 1;
         }
         if ( ! (0==AV12TFHistoricoRelacionesId_To) )
         {
            AddWhere(sWhereString, "(T1.[HistoricoRelacionesId] <= @AV12TFHistoricoRelacionesId_To)");
         }
         else
         {
            GXv_int2[2] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV14TFHistoricoRelacionesProfesionalesId_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV13TFHistoricoRelacionesProfesionalesId)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[HistoricoRelacionesProfesional]) like UPPER(@lV13TFHistoricoRelacionesProfesionalesId))");
         }
         else
         {
            GXv_int2[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV14TFHistoricoRelacionesProfesionalesId_Sel)) && ! ( StringUtil.StrCmp(AV14TFHistoricoRelacionesProfesionalesId_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[HistoricoRelacionesProfesional] = @AV14TFHistoricoRelacionesProfesionalesId_Sel)");
         }
         else
         {
            GXv_int2[4] = 1;
         }
         if ( StringUtil.StrCmp(AV14TFHistoricoRelacionesProfesionalesId_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[HistoricoRelacionesProfesional] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV16TFHistoricoRelacionesNombre_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV15TFHistoricoRelacionesNombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[HistoricoRelacionesNombre]) like UPPER(@lV15TFHistoricoRelacionesNombre))");
         }
         else
         {
            GXv_int2[5] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV16TFHistoricoRelacionesNombre_Sel)) && ! ( StringUtil.StrCmp(AV16TFHistoricoRelacionesNombre_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[HistoricoRelacionesNombre] = @AV16TFHistoricoRelacionesNombre_Sel)");
         }
         else
         {
            GXv_int2[6] = 1;
         }
         if ( StringUtil.StrCmp(AV16TFHistoricoRelacionesNombre_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[HistoricoRelacionesNombre] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV18TFHistoricoRelacionesApellido_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV17TFHistoricoRelacionesApellido)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[HistoricoRelacionesApellido]) like UPPER(@lV17TFHistoricoRelacionesApellido))");
         }
         else
         {
            GXv_int2[7] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV18TFHistoricoRelacionesApellido_Sel)) && ! ( StringUtil.StrCmp(AV18TFHistoricoRelacionesApellido_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[HistoricoRelacionesApellido] = @AV18TFHistoricoRelacionesApellido_Sel)");
         }
         else
         {
            GXv_int2[8] = 1;
         }
         if ( StringUtil.StrCmp(AV18TFHistoricoRelacionesApellido_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[HistoricoRelacionesApellido] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV20TFEstadoSGTipo_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV19TFEstadoSGTipo)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[EstadoSGTipo]) like UPPER(@lV19TFEstadoSGTipo))");
         }
         else
         {
            GXv_int2[9] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV20TFEstadoSGTipo_Sel)) && ! ( StringUtil.StrCmp(AV20TFEstadoSGTipo_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[EstadoSGTipo] = @AV20TFEstadoSGTipo_Sel)");
         }
         else
         {
            GXv_int2[10] = 1;
         }
         if ( StringUtil.StrCmp(AV20TFEstadoSGTipo_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[EstadoSGTipo] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV22TFEstadoSGNombre_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV21TFEstadoSGNombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[EstadosGenericosNombre]) like UPPER(@lV21TFEstadoSGNombre))");
         }
         else
         {
            GXv_int2[11] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV22TFEstadoSGNombre_Sel)) && ! ( StringUtil.StrCmp(AV22TFEstadoSGNombre_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.[EstadosGenericosNombre] = @AV22TFEstadoSGNombre_Sel)");
         }
         else
         {
            GXv_int2[12] = 1;
         }
         if ( StringUtil.StrCmp(AV22TFEstadoSGNombre_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T2.[EstadosGenericosNombre] = ''))");
         }
         if ( ! (DateTime.MinValue==AV23TFHistoricoRelacionesFechaAlta) )
         {
            AddWhere(sWhereString, "(T1.[HistoricoRelacionesFechaAlta] >= @AV23TFHistoricoRelacionesFechaAlta)");
         }
         else
         {
            GXv_int2[13] = 1;
         }
         if ( ! (DateTime.MinValue==AV24TFHistoricoRelacionesFechaAlta_To) )
         {
            AddWhere(sWhereString, "(T1.[HistoricoRelacionesFechaAlta] <= @AV24TFHistoricoRelacionesFechaAlta_To)");
         }
         else
         {
            GXv_int2[14] = 1;
         }
         if ( ! (DateTime.MinValue==AV25TFHistoricoRelacionesFechaModif) )
         {
            AddWhere(sWhereString, "(T1.[HistoricoRelacionesFechaModif] >= @AV25TFHistoricoRelacionesFechaModif)");
         }
         else
         {
            GXv_int2[15] = 1;
         }
         if ( ! (DateTime.MinValue==AV26TFHistoricoRelacionesFechaModif_To) )
         {
            AddWhere(sWhereString, "(T1.[HistoricoRelacionesFechaModif] <= @AV26TFHistoricoRelacionesFechaModif_To)");
         }
         else
         {
            GXv_int2[16] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[HistoricoSolicitudesID], T1.[HistoricoRelacionesProfesional]";
         GXv_Object3[0] = scmdbuf;
         GXv_Object3[1] = GXv_int2;
         return GXv_Object3 ;
      }

      protected Object[] conditional_P004T3( IGxContext context ,
                                             long AV11TFHistoricoRelacionesId ,
                                             long AV12TFHistoricoRelacionesId_To ,
                                             string AV14TFHistoricoRelacionesProfesionalesId_Sel ,
                                             string AV13TFHistoricoRelacionesProfesionalesId ,
                                             string AV16TFHistoricoRelacionesNombre_Sel ,
                                             string AV15TFHistoricoRelacionesNombre ,
                                             string AV18TFHistoricoRelacionesApellido_Sel ,
                                             string AV17TFHistoricoRelacionesApellido ,
                                             string AV20TFEstadoSGTipo_Sel ,
                                             string AV19TFEstadoSGTipo ,
                                             string AV22TFEstadoSGNombre_Sel ,
                                             string AV21TFEstadoSGNombre ,
                                             DateTime AV23TFHistoricoRelacionesFechaAlta ,
                                             DateTime AV24TFHistoricoRelacionesFechaAlta_To ,
                                             DateTime AV25TFHistoricoRelacionesFechaModif ,
                                             DateTime AV26TFHistoricoRelacionesFechaModif_To ,
                                             long A156HistoricoRelacionesId ,
                                             string A320HistoricoRelacionesProfesional ,
                                             string A323HistoricoRelacionesNombre ,
                                             string A324HistoricoRelacionesApellido ,
                                             string A141EstadoSGTipo ,
                                             string A143EstadoSGNombre ,
                                             DateTime A321HistoricoRelacionesFechaAlta ,
                                             DateTime A322HistoricoRelacionesFechaModif ,
                                             long AV49HistoricoSolicitudesID ,
                                             long A153HistoricoSolicitudesID )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int4 = new short[17];
         Object[] GXv_Object5 = new Object[2];
         scmdbuf = "SELECT T1.[EstadoSGId] AS EstadoSGId, T1.[HistoricoSolicitudesID], T1.[HistoricoRelacionesNombre], T1.[HistoricoRelacionesFechaModif], T1.[HistoricoRelacionesFechaAlta], T2.[EstadosGenericosNombre] AS EstadoSGNombre, T1.[EstadoSGTipo] AS EstadoSGTipo, T1.[HistoricoRelacionesApellido], T1.[HistoricoRelacionesProfesional], T1.[HistoricoRelacionesId] FROM ([HistoricoRelacionesRelaciones] T1 INNER JOIN [EstadosGenericos] T2 ON T2.[EstadosTipo] = T1.[EstadoSGTipo] AND T2.[EstadosGenericosId] = T1.[EstadoSGId])";
         AddWhere(sWhereString, "(T1.[HistoricoSolicitudesID] = @AV49HistoricoSolicitudesID)");
         if ( ! (0==AV11TFHistoricoRelacionesId) )
         {
            AddWhere(sWhereString, "(T1.[HistoricoRelacionesId] >= @AV11TFHistoricoRelacionesId)");
         }
         else
         {
            GXv_int4[1] = 1;
         }
         if ( ! (0==AV12TFHistoricoRelacionesId_To) )
         {
            AddWhere(sWhereString, "(T1.[HistoricoRelacionesId] <= @AV12TFHistoricoRelacionesId_To)");
         }
         else
         {
            GXv_int4[2] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV14TFHistoricoRelacionesProfesionalesId_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV13TFHistoricoRelacionesProfesionalesId)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[HistoricoRelacionesProfesional]) like UPPER(@lV13TFHistoricoRelacionesProfesionalesId))");
         }
         else
         {
            GXv_int4[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV14TFHistoricoRelacionesProfesionalesId_Sel)) && ! ( StringUtil.StrCmp(AV14TFHistoricoRelacionesProfesionalesId_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[HistoricoRelacionesProfesional] = @AV14TFHistoricoRelacionesProfesionalesId_Sel)");
         }
         else
         {
            GXv_int4[4] = 1;
         }
         if ( StringUtil.StrCmp(AV14TFHistoricoRelacionesProfesionalesId_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[HistoricoRelacionesProfesional] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV16TFHistoricoRelacionesNombre_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV15TFHistoricoRelacionesNombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[HistoricoRelacionesNombre]) like UPPER(@lV15TFHistoricoRelacionesNombre))");
         }
         else
         {
            GXv_int4[5] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV16TFHistoricoRelacionesNombre_Sel)) && ! ( StringUtil.StrCmp(AV16TFHistoricoRelacionesNombre_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[HistoricoRelacionesNombre] = @AV16TFHistoricoRelacionesNombre_Sel)");
         }
         else
         {
            GXv_int4[6] = 1;
         }
         if ( StringUtil.StrCmp(AV16TFHistoricoRelacionesNombre_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[HistoricoRelacionesNombre] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV18TFHistoricoRelacionesApellido_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV17TFHistoricoRelacionesApellido)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[HistoricoRelacionesApellido]) like UPPER(@lV17TFHistoricoRelacionesApellido))");
         }
         else
         {
            GXv_int4[7] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV18TFHistoricoRelacionesApellido_Sel)) && ! ( StringUtil.StrCmp(AV18TFHistoricoRelacionesApellido_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[HistoricoRelacionesApellido] = @AV18TFHistoricoRelacionesApellido_Sel)");
         }
         else
         {
            GXv_int4[8] = 1;
         }
         if ( StringUtil.StrCmp(AV18TFHistoricoRelacionesApellido_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[HistoricoRelacionesApellido] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV20TFEstadoSGTipo_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV19TFEstadoSGTipo)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[EstadoSGTipo]) like UPPER(@lV19TFEstadoSGTipo))");
         }
         else
         {
            GXv_int4[9] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV20TFEstadoSGTipo_Sel)) && ! ( StringUtil.StrCmp(AV20TFEstadoSGTipo_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[EstadoSGTipo] = @AV20TFEstadoSGTipo_Sel)");
         }
         else
         {
            GXv_int4[10] = 1;
         }
         if ( StringUtil.StrCmp(AV20TFEstadoSGTipo_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[EstadoSGTipo] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV22TFEstadoSGNombre_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV21TFEstadoSGNombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[EstadosGenericosNombre]) like UPPER(@lV21TFEstadoSGNombre))");
         }
         else
         {
            GXv_int4[11] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV22TFEstadoSGNombre_Sel)) && ! ( StringUtil.StrCmp(AV22TFEstadoSGNombre_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.[EstadosGenericosNombre] = @AV22TFEstadoSGNombre_Sel)");
         }
         else
         {
            GXv_int4[12] = 1;
         }
         if ( StringUtil.StrCmp(AV22TFEstadoSGNombre_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T2.[EstadosGenericosNombre] = ''))");
         }
         if ( ! (DateTime.MinValue==AV23TFHistoricoRelacionesFechaAlta) )
         {
            AddWhere(sWhereString, "(T1.[HistoricoRelacionesFechaAlta] >= @AV23TFHistoricoRelacionesFechaAlta)");
         }
         else
         {
            GXv_int4[13] = 1;
         }
         if ( ! (DateTime.MinValue==AV24TFHistoricoRelacionesFechaAlta_To) )
         {
            AddWhere(sWhereString, "(T1.[HistoricoRelacionesFechaAlta] <= @AV24TFHistoricoRelacionesFechaAlta_To)");
         }
         else
         {
            GXv_int4[14] = 1;
         }
         if ( ! (DateTime.MinValue==AV25TFHistoricoRelacionesFechaModif) )
         {
            AddWhere(sWhereString, "(T1.[HistoricoRelacionesFechaModif] >= @AV25TFHistoricoRelacionesFechaModif)");
         }
         else
         {
            GXv_int4[15] = 1;
         }
         if ( ! (DateTime.MinValue==AV26TFHistoricoRelacionesFechaModif_To) )
         {
            AddWhere(sWhereString, "(T1.[HistoricoRelacionesFechaModif] <= @AV26TFHistoricoRelacionesFechaModif_To)");
         }
         else
         {
            GXv_int4[16] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[HistoricoSolicitudesID], T1.[HistoricoRelacionesNombre]";
         GXv_Object5[0] = scmdbuf;
         GXv_Object5[1] = GXv_int4;
         return GXv_Object5 ;
      }

      protected Object[] conditional_P004T4( IGxContext context ,
                                             long AV11TFHistoricoRelacionesId ,
                                             long AV12TFHistoricoRelacionesId_To ,
                                             string AV14TFHistoricoRelacionesProfesionalesId_Sel ,
                                             string AV13TFHistoricoRelacionesProfesionalesId ,
                                             string AV16TFHistoricoRelacionesNombre_Sel ,
                                             string AV15TFHistoricoRelacionesNombre ,
                                             string AV18TFHistoricoRelacionesApellido_Sel ,
                                             string AV17TFHistoricoRelacionesApellido ,
                                             string AV20TFEstadoSGTipo_Sel ,
                                             string AV19TFEstadoSGTipo ,
                                             string AV22TFEstadoSGNombre_Sel ,
                                             string AV21TFEstadoSGNombre ,
                                             DateTime AV23TFHistoricoRelacionesFechaAlta ,
                                             DateTime AV24TFHistoricoRelacionesFechaAlta_To ,
                                             DateTime AV25TFHistoricoRelacionesFechaModif ,
                                             DateTime AV26TFHistoricoRelacionesFechaModif_To ,
                                             long A156HistoricoRelacionesId ,
                                             string A320HistoricoRelacionesProfesional ,
                                             string A323HistoricoRelacionesNombre ,
                                             string A324HistoricoRelacionesApellido ,
                                             string A141EstadoSGTipo ,
                                             string A143EstadoSGNombre ,
                                             DateTime A321HistoricoRelacionesFechaAlta ,
                                             DateTime A322HistoricoRelacionesFechaModif ,
                                             long AV49HistoricoSolicitudesID ,
                                             long A153HistoricoSolicitudesID )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int6 = new short[17];
         Object[] GXv_Object7 = new Object[2];
         scmdbuf = "SELECT T1.[EstadoSGId] AS EstadoSGId, T1.[HistoricoSolicitudesID], T1.[HistoricoRelacionesApellido], T1.[HistoricoRelacionesFechaModif], T1.[HistoricoRelacionesFechaAlta], T2.[EstadosGenericosNombre] AS EstadoSGNombre, T1.[EstadoSGTipo] AS EstadoSGTipo, T1.[HistoricoRelacionesNombre], T1.[HistoricoRelacionesProfesional], T1.[HistoricoRelacionesId] FROM ([HistoricoRelacionesRelaciones] T1 INNER JOIN [EstadosGenericos] T2 ON T2.[EstadosTipo] = T1.[EstadoSGTipo] AND T2.[EstadosGenericosId] = T1.[EstadoSGId])";
         AddWhere(sWhereString, "(T1.[HistoricoSolicitudesID] = @AV49HistoricoSolicitudesID)");
         if ( ! (0==AV11TFHistoricoRelacionesId) )
         {
            AddWhere(sWhereString, "(T1.[HistoricoRelacionesId] >= @AV11TFHistoricoRelacionesId)");
         }
         else
         {
            GXv_int6[1] = 1;
         }
         if ( ! (0==AV12TFHistoricoRelacionesId_To) )
         {
            AddWhere(sWhereString, "(T1.[HistoricoRelacionesId] <= @AV12TFHistoricoRelacionesId_To)");
         }
         else
         {
            GXv_int6[2] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV14TFHistoricoRelacionesProfesionalesId_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV13TFHistoricoRelacionesProfesionalesId)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[HistoricoRelacionesProfesional]) like UPPER(@lV13TFHistoricoRelacionesProfesionalesId))");
         }
         else
         {
            GXv_int6[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV14TFHistoricoRelacionesProfesionalesId_Sel)) && ! ( StringUtil.StrCmp(AV14TFHistoricoRelacionesProfesionalesId_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[HistoricoRelacionesProfesional] = @AV14TFHistoricoRelacionesProfesionalesId_Sel)");
         }
         else
         {
            GXv_int6[4] = 1;
         }
         if ( StringUtil.StrCmp(AV14TFHistoricoRelacionesProfesionalesId_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[HistoricoRelacionesProfesional] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV16TFHistoricoRelacionesNombre_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV15TFHistoricoRelacionesNombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[HistoricoRelacionesNombre]) like UPPER(@lV15TFHistoricoRelacionesNombre))");
         }
         else
         {
            GXv_int6[5] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV16TFHistoricoRelacionesNombre_Sel)) && ! ( StringUtil.StrCmp(AV16TFHistoricoRelacionesNombre_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[HistoricoRelacionesNombre] = @AV16TFHistoricoRelacionesNombre_Sel)");
         }
         else
         {
            GXv_int6[6] = 1;
         }
         if ( StringUtil.StrCmp(AV16TFHistoricoRelacionesNombre_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[HistoricoRelacionesNombre] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV18TFHistoricoRelacionesApellido_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV17TFHistoricoRelacionesApellido)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[HistoricoRelacionesApellido]) like UPPER(@lV17TFHistoricoRelacionesApellido))");
         }
         else
         {
            GXv_int6[7] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV18TFHistoricoRelacionesApellido_Sel)) && ! ( StringUtil.StrCmp(AV18TFHistoricoRelacionesApellido_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[HistoricoRelacionesApellido] = @AV18TFHistoricoRelacionesApellido_Sel)");
         }
         else
         {
            GXv_int6[8] = 1;
         }
         if ( StringUtil.StrCmp(AV18TFHistoricoRelacionesApellido_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[HistoricoRelacionesApellido] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV20TFEstadoSGTipo_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV19TFEstadoSGTipo)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[EstadoSGTipo]) like UPPER(@lV19TFEstadoSGTipo))");
         }
         else
         {
            GXv_int6[9] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV20TFEstadoSGTipo_Sel)) && ! ( StringUtil.StrCmp(AV20TFEstadoSGTipo_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[EstadoSGTipo] = @AV20TFEstadoSGTipo_Sel)");
         }
         else
         {
            GXv_int6[10] = 1;
         }
         if ( StringUtil.StrCmp(AV20TFEstadoSGTipo_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[EstadoSGTipo] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV22TFEstadoSGNombre_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV21TFEstadoSGNombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[EstadosGenericosNombre]) like UPPER(@lV21TFEstadoSGNombre))");
         }
         else
         {
            GXv_int6[11] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV22TFEstadoSGNombre_Sel)) && ! ( StringUtil.StrCmp(AV22TFEstadoSGNombre_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.[EstadosGenericosNombre] = @AV22TFEstadoSGNombre_Sel)");
         }
         else
         {
            GXv_int6[12] = 1;
         }
         if ( StringUtil.StrCmp(AV22TFEstadoSGNombre_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T2.[EstadosGenericosNombre] = ''))");
         }
         if ( ! (DateTime.MinValue==AV23TFHistoricoRelacionesFechaAlta) )
         {
            AddWhere(sWhereString, "(T1.[HistoricoRelacionesFechaAlta] >= @AV23TFHistoricoRelacionesFechaAlta)");
         }
         else
         {
            GXv_int6[13] = 1;
         }
         if ( ! (DateTime.MinValue==AV24TFHistoricoRelacionesFechaAlta_To) )
         {
            AddWhere(sWhereString, "(T1.[HistoricoRelacionesFechaAlta] <= @AV24TFHistoricoRelacionesFechaAlta_To)");
         }
         else
         {
            GXv_int6[14] = 1;
         }
         if ( ! (DateTime.MinValue==AV25TFHistoricoRelacionesFechaModif) )
         {
            AddWhere(sWhereString, "(T1.[HistoricoRelacionesFechaModif] >= @AV25TFHistoricoRelacionesFechaModif)");
         }
         else
         {
            GXv_int6[15] = 1;
         }
         if ( ! (DateTime.MinValue==AV26TFHistoricoRelacionesFechaModif_To) )
         {
            AddWhere(sWhereString, "(T1.[HistoricoRelacionesFechaModif] <= @AV26TFHistoricoRelacionesFechaModif_To)");
         }
         else
         {
            GXv_int6[16] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[HistoricoSolicitudesID], T1.[HistoricoRelacionesApellido]";
         GXv_Object7[0] = scmdbuf;
         GXv_Object7[1] = GXv_int6;
         return GXv_Object7 ;
      }

      protected Object[] conditional_P004T5( IGxContext context ,
                                             long AV11TFHistoricoRelacionesId ,
                                             long AV12TFHistoricoRelacionesId_To ,
                                             string AV14TFHistoricoRelacionesProfesionalesId_Sel ,
                                             string AV13TFHistoricoRelacionesProfesionalesId ,
                                             string AV16TFHistoricoRelacionesNombre_Sel ,
                                             string AV15TFHistoricoRelacionesNombre ,
                                             string AV18TFHistoricoRelacionesApellido_Sel ,
                                             string AV17TFHistoricoRelacionesApellido ,
                                             string AV20TFEstadoSGTipo_Sel ,
                                             string AV19TFEstadoSGTipo ,
                                             string AV22TFEstadoSGNombre_Sel ,
                                             string AV21TFEstadoSGNombre ,
                                             DateTime AV23TFHistoricoRelacionesFechaAlta ,
                                             DateTime AV24TFHistoricoRelacionesFechaAlta_To ,
                                             DateTime AV25TFHistoricoRelacionesFechaModif ,
                                             DateTime AV26TFHistoricoRelacionesFechaModif_To ,
                                             long A156HistoricoRelacionesId ,
                                             string A320HistoricoRelacionesProfesional ,
                                             string A323HistoricoRelacionesNombre ,
                                             string A324HistoricoRelacionesApellido ,
                                             string A141EstadoSGTipo ,
                                             string A143EstadoSGNombre ,
                                             DateTime A321HistoricoRelacionesFechaAlta ,
                                             DateTime A322HistoricoRelacionesFechaModif ,
                                             long AV49HistoricoSolicitudesID ,
                                             long A153HistoricoSolicitudesID )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int8 = new short[17];
         Object[] GXv_Object9 = new Object[2];
         scmdbuf = "SELECT T1.[EstadoSGId] AS EstadoSGId, T1.[HistoricoSolicitudesID], T1.[EstadoSGTipo] AS EstadoSGTipo, T1.[HistoricoRelacionesFechaModif], T1.[HistoricoRelacionesFechaAlta], T2.[EstadosGenericosNombre] AS EstadoSGNombre, T1.[HistoricoRelacionesApellido], T1.[HistoricoRelacionesNombre], T1.[HistoricoRelacionesProfesional], T1.[HistoricoRelacionesId] FROM ([HistoricoRelacionesRelaciones] T1 INNER JOIN [EstadosGenericos] T2 ON T2.[EstadosTipo] = T1.[EstadoSGTipo] AND T2.[EstadosGenericosId] = T1.[EstadoSGId])";
         AddWhere(sWhereString, "(T1.[HistoricoSolicitudesID] = @AV49HistoricoSolicitudesID)");
         if ( ! (0==AV11TFHistoricoRelacionesId) )
         {
            AddWhere(sWhereString, "(T1.[HistoricoRelacionesId] >= @AV11TFHistoricoRelacionesId)");
         }
         else
         {
            GXv_int8[1] = 1;
         }
         if ( ! (0==AV12TFHistoricoRelacionesId_To) )
         {
            AddWhere(sWhereString, "(T1.[HistoricoRelacionesId] <= @AV12TFHistoricoRelacionesId_To)");
         }
         else
         {
            GXv_int8[2] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV14TFHistoricoRelacionesProfesionalesId_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV13TFHistoricoRelacionesProfesionalesId)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[HistoricoRelacionesProfesional]) like UPPER(@lV13TFHistoricoRelacionesProfesionalesId))");
         }
         else
         {
            GXv_int8[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV14TFHistoricoRelacionesProfesionalesId_Sel)) && ! ( StringUtil.StrCmp(AV14TFHistoricoRelacionesProfesionalesId_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[HistoricoRelacionesProfesional] = @AV14TFHistoricoRelacionesProfesionalesId_Sel)");
         }
         else
         {
            GXv_int8[4] = 1;
         }
         if ( StringUtil.StrCmp(AV14TFHistoricoRelacionesProfesionalesId_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[HistoricoRelacionesProfesional] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV16TFHistoricoRelacionesNombre_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV15TFHistoricoRelacionesNombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[HistoricoRelacionesNombre]) like UPPER(@lV15TFHistoricoRelacionesNombre))");
         }
         else
         {
            GXv_int8[5] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV16TFHistoricoRelacionesNombre_Sel)) && ! ( StringUtil.StrCmp(AV16TFHistoricoRelacionesNombre_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[HistoricoRelacionesNombre] = @AV16TFHistoricoRelacionesNombre_Sel)");
         }
         else
         {
            GXv_int8[6] = 1;
         }
         if ( StringUtil.StrCmp(AV16TFHistoricoRelacionesNombre_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[HistoricoRelacionesNombre] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV18TFHistoricoRelacionesApellido_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV17TFHistoricoRelacionesApellido)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[HistoricoRelacionesApellido]) like UPPER(@lV17TFHistoricoRelacionesApellido))");
         }
         else
         {
            GXv_int8[7] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV18TFHistoricoRelacionesApellido_Sel)) && ! ( StringUtil.StrCmp(AV18TFHistoricoRelacionesApellido_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[HistoricoRelacionesApellido] = @AV18TFHistoricoRelacionesApellido_Sel)");
         }
         else
         {
            GXv_int8[8] = 1;
         }
         if ( StringUtil.StrCmp(AV18TFHistoricoRelacionesApellido_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[HistoricoRelacionesApellido] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV20TFEstadoSGTipo_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV19TFEstadoSGTipo)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[EstadoSGTipo]) like UPPER(@lV19TFEstadoSGTipo))");
         }
         else
         {
            GXv_int8[9] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV20TFEstadoSGTipo_Sel)) && ! ( StringUtil.StrCmp(AV20TFEstadoSGTipo_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[EstadoSGTipo] = @AV20TFEstadoSGTipo_Sel)");
         }
         else
         {
            GXv_int8[10] = 1;
         }
         if ( StringUtil.StrCmp(AV20TFEstadoSGTipo_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[EstadoSGTipo] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV22TFEstadoSGNombre_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV21TFEstadoSGNombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[EstadosGenericosNombre]) like UPPER(@lV21TFEstadoSGNombre))");
         }
         else
         {
            GXv_int8[11] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV22TFEstadoSGNombre_Sel)) && ! ( StringUtil.StrCmp(AV22TFEstadoSGNombre_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.[EstadosGenericosNombre] = @AV22TFEstadoSGNombre_Sel)");
         }
         else
         {
            GXv_int8[12] = 1;
         }
         if ( StringUtil.StrCmp(AV22TFEstadoSGNombre_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T2.[EstadosGenericosNombre] = ''))");
         }
         if ( ! (DateTime.MinValue==AV23TFHistoricoRelacionesFechaAlta) )
         {
            AddWhere(sWhereString, "(T1.[HistoricoRelacionesFechaAlta] >= @AV23TFHistoricoRelacionesFechaAlta)");
         }
         else
         {
            GXv_int8[13] = 1;
         }
         if ( ! (DateTime.MinValue==AV24TFHistoricoRelacionesFechaAlta_To) )
         {
            AddWhere(sWhereString, "(T1.[HistoricoRelacionesFechaAlta] <= @AV24TFHistoricoRelacionesFechaAlta_To)");
         }
         else
         {
            GXv_int8[14] = 1;
         }
         if ( ! (DateTime.MinValue==AV25TFHistoricoRelacionesFechaModif) )
         {
            AddWhere(sWhereString, "(T1.[HistoricoRelacionesFechaModif] >= @AV25TFHistoricoRelacionesFechaModif)");
         }
         else
         {
            GXv_int8[15] = 1;
         }
         if ( ! (DateTime.MinValue==AV26TFHistoricoRelacionesFechaModif_To) )
         {
            AddWhere(sWhereString, "(T1.[HistoricoRelacionesFechaModif] <= @AV26TFHistoricoRelacionesFechaModif_To)");
         }
         else
         {
            GXv_int8[16] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[HistoricoSolicitudesID], T1.[EstadoSGTipo]";
         GXv_Object9[0] = scmdbuf;
         GXv_Object9[1] = GXv_int8;
         return GXv_Object9 ;
      }

      protected Object[] conditional_P004T6( IGxContext context ,
                                             long AV11TFHistoricoRelacionesId ,
                                             long AV12TFHistoricoRelacionesId_To ,
                                             string AV14TFHistoricoRelacionesProfesionalesId_Sel ,
                                             string AV13TFHistoricoRelacionesProfesionalesId ,
                                             string AV16TFHistoricoRelacionesNombre_Sel ,
                                             string AV15TFHistoricoRelacionesNombre ,
                                             string AV18TFHistoricoRelacionesApellido_Sel ,
                                             string AV17TFHistoricoRelacionesApellido ,
                                             string AV20TFEstadoSGTipo_Sel ,
                                             string AV19TFEstadoSGTipo ,
                                             string AV22TFEstadoSGNombre_Sel ,
                                             string AV21TFEstadoSGNombre ,
                                             DateTime AV23TFHistoricoRelacionesFechaAlta ,
                                             DateTime AV24TFHistoricoRelacionesFechaAlta_To ,
                                             DateTime AV25TFHistoricoRelacionesFechaModif ,
                                             DateTime AV26TFHistoricoRelacionesFechaModif_To ,
                                             long A156HistoricoRelacionesId ,
                                             string A320HistoricoRelacionesProfesional ,
                                             string A323HistoricoRelacionesNombre ,
                                             string A324HistoricoRelacionesApellido ,
                                             string A141EstadoSGTipo ,
                                             string A143EstadoSGNombre ,
                                             DateTime A321HistoricoRelacionesFechaAlta ,
                                             DateTime A322HistoricoRelacionesFechaModif ,
                                             long AV49HistoricoSolicitudesID ,
                                             long A153HistoricoSolicitudesID )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int10 = new short[17];
         Object[] GXv_Object11 = new Object[2];
         scmdbuf = "SELECT T1.[HistoricoSolicitudesID], T1.[EstadoSGId] AS EstadoSGId, T1.[EstadoSGTipo] AS EstadoSGTipo, T1.[HistoricoRelacionesFechaModif], T1.[HistoricoRelacionesFechaAlta], T2.[EstadosGenericosNombre] AS EstadoSGNombre, T1.[HistoricoRelacionesApellido], T1.[HistoricoRelacionesNombre], T1.[HistoricoRelacionesProfesional], T1.[HistoricoRelacionesId] FROM ([HistoricoRelacionesRelaciones] T1 INNER JOIN [EstadosGenericos] T2 ON T2.[EstadosTipo] = T1.[EstadoSGTipo] AND T2.[EstadosGenericosId] = T1.[EstadoSGId])";
         AddWhere(sWhereString, "(T1.[HistoricoSolicitudesID] = @AV49HistoricoSolicitudesID)");
         if ( ! (0==AV11TFHistoricoRelacionesId) )
         {
            AddWhere(sWhereString, "(T1.[HistoricoRelacionesId] >= @AV11TFHistoricoRelacionesId)");
         }
         else
         {
            GXv_int10[1] = 1;
         }
         if ( ! (0==AV12TFHistoricoRelacionesId_To) )
         {
            AddWhere(sWhereString, "(T1.[HistoricoRelacionesId] <= @AV12TFHistoricoRelacionesId_To)");
         }
         else
         {
            GXv_int10[2] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV14TFHistoricoRelacionesProfesionalesId_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV13TFHistoricoRelacionesProfesionalesId)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[HistoricoRelacionesProfesional]) like UPPER(@lV13TFHistoricoRelacionesProfesionalesId))");
         }
         else
         {
            GXv_int10[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV14TFHistoricoRelacionesProfesionalesId_Sel)) && ! ( StringUtil.StrCmp(AV14TFHistoricoRelacionesProfesionalesId_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[HistoricoRelacionesProfesional] = @AV14TFHistoricoRelacionesProfesionalesId_Sel)");
         }
         else
         {
            GXv_int10[4] = 1;
         }
         if ( StringUtil.StrCmp(AV14TFHistoricoRelacionesProfesionalesId_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[HistoricoRelacionesProfesional] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV16TFHistoricoRelacionesNombre_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV15TFHistoricoRelacionesNombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[HistoricoRelacionesNombre]) like UPPER(@lV15TFHistoricoRelacionesNombre))");
         }
         else
         {
            GXv_int10[5] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV16TFHistoricoRelacionesNombre_Sel)) && ! ( StringUtil.StrCmp(AV16TFHistoricoRelacionesNombre_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[HistoricoRelacionesNombre] = @AV16TFHistoricoRelacionesNombre_Sel)");
         }
         else
         {
            GXv_int10[6] = 1;
         }
         if ( StringUtil.StrCmp(AV16TFHistoricoRelacionesNombre_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[HistoricoRelacionesNombre] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV18TFHistoricoRelacionesApellido_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV17TFHistoricoRelacionesApellido)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[HistoricoRelacionesApellido]) like UPPER(@lV17TFHistoricoRelacionesApellido))");
         }
         else
         {
            GXv_int10[7] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV18TFHistoricoRelacionesApellido_Sel)) && ! ( StringUtil.StrCmp(AV18TFHistoricoRelacionesApellido_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[HistoricoRelacionesApellido] = @AV18TFHistoricoRelacionesApellido_Sel)");
         }
         else
         {
            GXv_int10[8] = 1;
         }
         if ( StringUtil.StrCmp(AV18TFHistoricoRelacionesApellido_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[HistoricoRelacionesApellido] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV20TFEstadoSGTipo_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV19TFEstadoSGTipo)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[EstadoSGTipo]) like UPPER(@lV19TFEstadoSGTipo))");
         }
         else
         {
            GXv_int10[9] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV20TFEstadoSGTipo_Sel)) && ! ( StringUtil.StrCmp(AV20TFEstadoSGTipo_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[EstadoSGTipo] = @AV20TFEstadoSGTipo_Sel)");
         }
         else
         {
            GXv_int10[10] = 1;
         }
         if ( StringUtil.StrCmp(AV20TFEstadoSGTipo_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[EstadoSGTipo] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV22TFEstadoSGNombre_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV21TFEstadoSGNombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[EstadosGenericosNombre]) like UPPER(@lV21TFEstadoSGNombre))");
         }
         else
         {
            GXv_int10[11] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV22TFEstadoSGNombre_Sel)) && ! ( StringUtil.StrCmp(AV22TFEstadoSGNombre_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.[EstadosGenericosNombre] = @AV22TFEstadoSGNombre_Sel)");
         }
         else
         {
            GXv_int10[12] = 1;
         }
         if ( StringUtil.StrCmp(AV22TFEstadoSGNombre_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T2.[EstadosGenericosNombre] = ''))");
         }
         if ( ! (DateTime.MinValue==AV23TFHistoricoRelacionesFechaAlta) )
         {
            AddWhere(sWhereString, "(T1.[HistoricoRelacionesFechaAlta] >= @AV23TFHistoricoRelacionesFechaAlta)");
         }
         else
         {
            GXv_int10[13] = 1;
         }
         if ( ! (DateTime.MinValue==AV24TFHistoricoRelacionesFechaAlta_To) )
         {
            AddWhere(sWhereString, "(T1.[HistoricoRelacionesFechaAlta] <= @AV24TFHistoricoRelacionesFechaAlta_To)");
         }
         else
         {
            GXv_int10[14] = 1;
         }
         if ( ! (DateTime.MinValue==AV25TFHistoricoRelacionesFechaModif) )
         {
            AddWhere(sWhereString, "(T1.[HistoricoRelacionesFechaModif] >= @AV25TFHistoricoRelacionesFechaModif)");
         }
         else
         {
            GXv_int10[15] = 1;
         }
         if ( ! (DateTime.MinValue==AV26TFHistoricoRelacionesFechaModif_To) )
         {
            AddWhere(sWhereString, "(T1.[HistoricoRelacionesFechaModif] <= @AV26TFHistoricoRelacionesFechaModif_To)");
         }
         else
         {
            GXv_int10[16] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[HistoricoSolicitudesID], T1.[EstadoSGTipo], T1.[EstadoSGId]";
         GXv_Object11[0] = scmdbuf;
         GXv_Object11[1] = GXv_int10;
         return GXv_Object11 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_P004T2(context, (long)dynConstraints[0] , (long)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (DateTime)dynConstraints[12] , (DateTime)dynConstraints[13] , (DateTime)dynConstraints[14] , (DateTime)dynConstraints[15] , (long)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (DateTime)dynConstraints[22] , (DateTime)dynConstraints[23] , (long)dynConstraints[24] , (long)dynConstraints[25] );
               case 1 :
                     return conditional_P004T3(context, (long)dynConstraints[0] , (long)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (DateTime)dynConstraints[12] , (DateTime)dynConstraints[13] , (DateTime)dynConstraints[14] , (DateTime)dynConstraints[15] , (long)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (DateTime)dynConstraints[22] , (DateTime)dynConstraints[23] , (long)dynConstraints[24] , (long)dynConstraints[25] );
               case 2 :
                     return conditional_P004T4(context, (long)dynConstraints[0] , (long)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (DateTime)dynConstraints[12] , (DateTime)dynConstraints[13] , (DateTime)dynConstraints[14] , (DateTime)dynConstraints[15] , (long)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (DateTime)dynConstraints[22] , (DateTime)dynConstraints[23] , (long)dynConstraints[24] , (long)dynConstraints[25] );
               case 3 :
                     return conditional_P004T5(context, (long)dynConstraints[0] , (long)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (DateTime)dynConstraints[12] , (DateTime)dynConstraints[13] , (DateTime)dynConstraints[14] , (DateTime)dynConstraints[15] , (long)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (DateTime)dynConstraints[22] , (DateTime)dynConstraints[23] , (long)dynConstraints[24] , (long)dynConstraints[25] );
               case 4 :
                     return conditional_P004T6(context, (long)dynConstraints[0] , (long)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (DateTime)dynConstraints[12] , (DateTime)dynConstraints[13] , (DateTime)dynConstraints[14] , (DateTime)dynConstraints[15] , (long)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (DateTime)dynConstraints[22] , (DateTime)dynConstraints[23] , (long)dynConstraints[24] , (long)dynConstraints[25] );
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
         ,new ForEachCursor(def[4])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP004T2;
          prmP004T2 = new Object[] {
          new ParDef("@AV49HistoricoSolicitudesID",GXType.Decimal,18,0) ,
          new ParDef("@AV11TFHistoricoRelacionesId",GXType.Decimal,18,0) ,
          new ParDef("@AV12TFHistoricoRelacionesId_To",GXType.Decimal,18,0) ,
          new ParDef("@lV13TFHistoricoRelacionesProfesionalesId",GXType.Char,20,0) ,
          new ParDef("@AV14TFHistoricoRelacionesProfesionalesId_Sel",GXType.NChar,20,0) ,
          new ParDef("@lV15TFHistoricoRelacionesNombre",GXType.Char,80,0) ,
          new ParDef("@AV16TFHistoricoRelacionesNombre_Sel",GXType.NChar,80,0) ,
          new ParDef("@lV17TFHistoricoRelacionesApellido",GXType.Char,80,0) ,
          new ParDef("@AV18TFHistoricoRelacionesApellido_Sel",GXType.NChar,80,0) ,
          new ParDef("@lV19TFEstadoSGTipo",GXType.Char,3,0) ,
          new ParDef("@AV20TFEstadoSGTipo_Sel",GXType.NChar,3,0) ,
          new ParDef("@lV21TFEstadoSGNombre",GXType.Char,80,0) ,
          new ParDef("@AV22TFEstadoSGNombre_Sel",GXType.NChar,80,0) ,
          new ParDef("@AV23TFHistoricoRelacionesFechaAlta",GXType.DateTime,8,5) ,
          new ParDef("@AV24TFHistoricoRelacionesFechaAlta_To",GXType.DateTime,8,5) ,
          new ParDef("@AV25TFHistoricoRelacionesFechaModif",GXType.DateTime,8,5) ,
          new ParDef("@AV26TFHistoricoRelacionesFechaModif_To",GXType.DateTime,8,5)
          };
          Object[] prmP004T3;
          prmP004T3 = new Object[] {
          new ParDef("@AV49HistoricoSolicitudesID",GXType.Decimal,18,0) ,
          new ParDef("@AV11TFHistoricoRelacionesId",GXType.Decimal,18,0) ,
          new ParDef("@AV12TFHistoricoRelacionesId_To",GXType.Decimal,18,0) ,
          new ParDef("@lV13TFHistoricoRelacionesProfesionalesId",GXType.Char,20,0) ,
          new ParDef("@AV14TFHistoricoRelacionesProfesionalesId_Sel",GXType.NChar,20,0) ,
          new ParDef("@lV15TFHistoricoRelacionesNombre",GXType.Char,80,0) ,
          new ParDef("@AV16TFHistoricoRelacionesNombre_Sel",GXType.NChar,80,0) ,
          new ParDef("@lV17TFHistoricoRelacionesApellido",GXType.Char,80,0) ,
          new ParDef("@AV18TFHistoricoRelacionesApellido_Sel",GXType.NChar,80,0) ,
          new ParDef("@lV19TFEstadoSGTipo",GXType.Char,3,0) ,
          new ParDef("@AV20TFEstadoSGTipo_Sel",GXType.NChar,3,0) ,
          new ParDef("@lV21TFEstadoSGNombre",GXType.Char,80,0) ,
          new ParDef("@AV22TFEstadoSGNombre_Sel",GXType.NChar,80,0) ,
          new ParDef("@AV23TFHistoricoRelacionesFechaAlta",GXType.DateTime,8,5) ,
          new ParDef("@AV24TFHistoricoRelacionesFechaAlta_To",GXType.DateTime,8,5) ,
          new ParDef("@AV25TFHistoricoRelacionesFechaModif",GXType.DateTime,8,5) ,
          new ParDef("@AV26TFHistoricoRelacionesFechaModif_To",GXType.DateTime,8,5)
          };
          Object[] prmP004T4;
          prmP004T4 = new Object[] {
          new ParDef("@AV49HistoricoSolicitudesID",GXType.Decimal,18,0) ,
          new ParDef("@AV11TFHistoricoRelacionesId",GXType.Decimal,18,0) ,
          new ParDef("@AV12TFHistoricoRelacionesId_To",GXType.Decimal,18,0) ,
          new ParDef("@lV13TFHistoricoRelacionesProfesionalesId",GXType.Char,20,0) ,
          new ParDef("@AV14TFHistoricoRelacionesProfesionalesId_Sel",GXType.NChar,20,0) ,
          new ParDef("@lV15TFHistoricoRelacionesNombre",GXType.Char,80,0) ,
          new ParDef("@AV16TFHistoricoRelacionesNombre_Sel",GXType.NChar,80,0) ,
          new ParDef("@lV17TFHistoricoRelacionesApellido",GXType.Char,80,0) ,
          new ParDef("@AV18TFHistoricoRelacionesApellido_Sel",GXType.NChar,80,0) ,
          new ParDef("@lV19TFEstadoSGTipo",GXType.Char,3,0) ,
          new ParDef("@AV20TFEstadoSGTipo_Sel",GXType.NChar,3,0) ,
          new ParDef("@lV21TFEstadoSGNombre",GXType.Char,80,0) ,
          new ParDef("@AV22TFEstadoSGNombre_Sel",GXType.NChar,80,0) ,
          new ParDef("@AV23TFHistoricoRelacionesFechaAlta",GXType.DateTime,8,5) ,
          new ParDef("@AV24TFHistoricoRelacionesFechaAlta_To",GXType.DateTime,8,5) ,
          new ParDef("@AV25TFHistoricoRelacionesFechaModif",GXType.DateTime,8,5) ,
          new ParDef("@AV26TFHistoricoRelacionesFechaModif_To",GXType.DateTime,8,5)
          };
          Object[] prmP004T5;
          prmP004T5 = new Object[] {
          new ParDef("@AV49HistoricoSolicitudesID",GXType.Decimal,18,0) ,
          new ParDef("@AV11TFHistoricoRelacionesId",GXType.Decimal,18,0) ,
          new ParDef("@AV12TFHistoricoRelacionesId_To",GXType.Decimal,18,0) ,
          new ParDef("@lV13TFHistoricoRelacionesProfesionalesId",GXType.Char,20,0) ,
          new ParDef("@AV14TFHistoricoRelacionesProfesionalesId_Sel",GXType.NChar,20,0) ,
          new ParDef("@lV15TFHistoricoRelacionesNombre",GXType.Char,80,0) ,
          new ParDef("@AV16TFHistoricoRelacionesNombre_Sel",GXType.NChar,80,0) ,
          new ParDef("@lV17TFHistoricoRelacionesApellido",GXType.Char,80,0) ,
          new ParDef("@AV18TFHistoricoRelacionesApellido_Sel",GXType.NChar,80,0) ,
          new ParDef("@lV19TFEstadoSGTipo",GXType.Char,3,0) ,
          new ParDef("@AV20TFEstadoSGTipo_Sel",GXType.NChar,3,0) ,
          new ParDef("@lV21TFEstadoSGNombre",GXType.Char,80,0) ,
          new ParDef("@AV22TFEstadoSGNombre_Sel",GXType.NChar,80,0) ,
          new ParDef("@AV23TFHistoricoRelacionesFechaAlta",GXType.DateTime,8,5) ,
          new ParDef("@AV24TFHistoricoRelacionesFechaAlta_To",GXType.DateTime,8,5) ,
          new ParDef("@AV25TFHistoricoRelacionesFechaModif",GXType.DateTime,8,5) ,
          new ParDef("@AV26TFHistoricoRelacionesFechaModif_To",GXType.DateTime,8,5)
          };
          Object[] prmP004T6;
          prmP004T6 = new Object[] {
          new ParDef("@AV49HistoricoSolicitudesID",GXType.Decimal,18,0) ,
          new ParDef("@AV11TFHistoricoRelacionesId",GXType.Decimal,18,0) ,
          new ParDef("@AV12TFHistoricoRelacionesId_To",GXType.Decimal,18,0) ,
          new ParDef("@lV13TFHistoricoRelacionesProfesionalesId",GXType.Char,20,0) ,
          new ParDef("@AV14TFHistoricoRelacionesProfesionalesId_Sel",GXType.NChar,20,0) ,
          new ParDef("@lV15TFHistoricoRelacionesNombre",GXType.Char,80,0) ,
          new ParDef("@AV16TFHistoricoRelacionesNombre_Sel",GXType.NChar,80,0) ,
          new ParDef("@lV17TFHistoricoRelacionesApellido",GXType.Char,80,0) ,
          new ParDef("@AV18TFHistoricoRelacionesApellido_Sel",GXType.NChar,80,0) ,
          new ParDef("@lV19TFEstadoSGTipo",GXType.Char,3,0) ,
          new ParDef("@AV20TFEstadoSGTipo_Sel",GXType.NChar,3,0) ,
          new ParDef("@lV21TFEstadoSGNombre",GXType.Char,80,0) ,
          new ParDef("@AV22TFEstadoSGNombre_Sel",GXType.NChar,80,0) ,
          new ParDef("@AV23TFHistoricoRelacionesFechaAlta",GXType.DateTime,8,5) ,
          new ParDef("@AV24TFHistoricoRelacionesFechaAlta_To",GXType.DateTime,8,5) ,
          new ParDef("@AV25TFHistoricoRelacionesFechaModif",GXType.DateTime,8,5) ,
          new ParDef("@AV26TFHistoricoRelacionesFechaModif_To",GXType.DateTime,8,5)
          };
          def= new CursorDef[] {
              new CursorDef("P004T2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP004T2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P004T3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP004T3,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P004T4", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP004T4,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P004T5", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP004T5,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P004T6", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP004T6,100, GxCacheFrequency.OFF ,true,false )
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
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((long[]) buf[1])[0] = rslt.getLong(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 20);
                ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(4);
                ((DateTime[]) buf[4])[0] = rslt.getGXDateTime(5);
                ((string[]) buf[5])[0] = rslt.getString(6, 80);
                ((string[]) buf[6])[0] = rslt.getString(7, 3);
                ((string[]) buf[7])[0] = rslt.getString(8, 80);
                ((string[]) buf[8])[0] = rslt.getString(9, 80);
                ((long[]) buf[9])[0] = rslt.getLong(10);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((long[]) buf[1])[0] = rslt.getLong(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 80);
                ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(4);
                ((DateTime[]) buf[4])[0] = rslt.getGXDateTime(5);
                ((string[]) buf[5])[0] = rslt.getString(6, 80);
                ((string[]) buf[6])[0] = rslt.getString(7, 3);
                ((string[]) buf[7])[0] = rslt.getString(8, 80);
                ((string[]) buf[8])[0] = rslt.getString(9, 20);
                ((long[]) buf[9])[0] = rslt.getLong(10);
                return;
             case 2 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((long[]) buf[1])[0] = rslt.getLong(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 80);
                ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(4);
                ((DateTime[]) buf[4])[0] = rslt.getGXDateTime(5);
                ((string[]) buf[5])[0] = rslt.getString(6, 80);
                ((string[]) buf[6])[0] = rslt.getString(7, 3);
                ((string[]) buf[7])[0] = rslt.getString(8, 80);
                ((string[]) buf[8])[0] = rslt.getString(9, 20);
                ((long[]) buf[9])[0] = rslt.getLong(10);
                return;
             case 3 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((long[]) buf[1])[0] = rslt.getLong(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 3);
                ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(4);
                ((DateTime[]) buf[4])[0] = rslt.getGXDateTime(5);
                ((string[]) buf[5])[0] = rslt.getString(6, 80);
                ((string[]) buf[6])[0] = rslt.getString(7, 80);
                ((string[]) buf[7])[0] = rslt.getString(8, 80);
                ((string[]) buf[8])[0] = rslt.getString(9, 20);
                ((long[]) buf[9])[0] = rslt.getLong(10);
                return;
             case 4 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 3);
                ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(4);
                ((DateTime[]) buf[4])[0] = rslt.getGXDateTime(5);
                ((string[]) buf[5])[0] = rslt.getString(6, 80);
                ((string[]) buf[6])[0] = rslt.getString(7, 80);
                ((string[]) buf[7])[0] = rslt.getString(8, 80);
                ((string[]) buf[8])[0] = rslt.getString(9, 20);
                ((long[]) buf[9])[0] = rslt.getLong(10);
                return;
       }
    }

 }

 [ServiceContract(Namespace = "GeneXus.Programs.historicorelacionesrelacioneswcgetfilterdata_services")]
 [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple)]
 [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
 public class historicorelacionesrelacioneswcgetfilterdata_services : GxRestService
 {
    [OperationContract(Name = "HistoricoRelacionesRelacionesWCGetFilterData" )]
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
          if ( ! ProcessHeaders("historicorelacionesrelacioneswcgetfilterdata") )
          {
             return  ;
          }
          historicorelacionesrelacioneswcgetfilterdata worker = new historicorelacionesrelacioneswcgetfilterdata(context);
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

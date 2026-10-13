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
   public class rubrosmedidasmedidaswcgetfilterdata : GXProcedure
   {
      public rubrosmedidasmedidaswcgetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public rubrosmedidasmedidaswcgetfilterdata( IGxContext context )
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
         new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWRubrosMedidas", out  GXt_boolean1) ;
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
            if ( StringUtil.StrCmp(StringUtil.Upper( AV43DDOName), "DDO_MEDIDASNOMBRE") == 0 )
            {
               /* Execute user subroutine: 'LOADMEDIDASNOMBREOPTIONS' */
               S121 ();
               if ( returnInSub )
               {
                  cleanup();
                  if (true) return;
               }
            }
            else if ( StringUtil.StrCmp(StringUtil.Upper( AV43DDOName), "DDO_MONEDAISOSIMBOLO") == 0 )
            {
               /* Execute user subroutine: 'LOADMONEDAISOSIMBOLOOPTIONS' */
               S131 ();
               if ( returnInSub )
               {
                  cleanup();
                  if (true) return;
               }
            }
            else if ( StringUtil.StrCmp(StringUtil.Upper( AV43DDOName), "DDO_TEXTOSTITULO") == 0 )
            {
               /* Execute user subroutine: 'LOADTEXTOSTITULOOPTIONS' */
               S141 ();
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
         if ( StringUtil.StrCmp(AV38Session.Get("RubrosMedidasMedidasWCGridState"), "") == 0 )
         {
            AV40GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "RubrosMedidasMedidasWCGridState"), null, "", "");
         }
         else
         {
            AV40GridState.FromXml(AV38Session.Get("RubrosMedidasMedidasWCGridState"), null, "", "");
         }
         AV50GXV1 = 1;
         while ( AV50GXV1 <= AV40GridState.gxTpr_Filtervalues.Count )
         {
            AV41GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV40GridState.gxTpr_Filtervalues.Item(AV50GXV1));
            if ( StringUtil.StrCmp(AV41GridStateFilterValue.gxTpr_Name, "TFMEDIDASNOMBRE") == 0 )
            {
               AV13TFMedidasNombre = AV41GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV41GridStateFilterValue.gxTpr_Name, "TFMEDIDASNOMBRE_SEL") == 0 )
            {
               AV14TFMedidasNombre_Sel = AV41GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV41GridStateFilterValue.gxTpr_Name, "TFRUBROSCOSTO") == 0 )
            {
               AV15TFRubrosCosto = NumberUtil.Val( AV41GridStateFilterValue.gxTpr_Value, ".");
               AV16TFRubrosCosto_To = NumberUtil.Val( AV41GridStateFilterValue.gxTpr_Valueto, ".");
            }
            else if ( StringUtil.StrCmp(AV41GridStateFilterValue.gxTpr_Name, "TFRUBROSPRECIOBASE") == 0 )
            {
               AV17TFRubrosPrecioBase = NumberUtil.Val( AV41GridStateFilterValue.gxTpr_Value, ".");
               AV18TFRubrosPrecioBase_To = NumberUtil.Val( AV41GridStateFilterValue.gxTpr_Valueto, ".");
            }
            else if ( StringUtil.StrCmp(AV41GridStateFilterValue.gxTpr_Name, "TFMONEDAISOSIMBOLO") == 0 )
            {
               AV19TFMonedaISOSimbolo = AV41GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV41GridStateFilterValue.gxTpr_Name, "TFMONEDAISOSIMBOLO_SEL") == 0 )
            {
               AV20TFMonedaISOSimbolo_Sel = AV41GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV41GridStateFilterValue.gxTpr_Name, "TFMEDIDASESTADO_SEL") == 0 )
            {
               AV21TFMedidasEstado_SelsJson = AV41GridStateFilterValue.gxTpr_Value;
               AV22TFMedidasEstado_Sels.FromJSonString(AV21TFMedidasEstado_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV41GridStateFilterValue.gxTpr_Name, "TFTEXTOSID") == 0 )
            {
               AV23TFTextosId = (long)(Math.Round(NumberUtil.Val( AV41GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV24TFTextosId_To = (long)(Math.Round(NumberUtil.Val( AV41GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV41GridStateFilterValue.gxTpr_Name, "TFTEXTOSTITULO") == 0 )
            {
               AV25TFTextosTitulo = AV41GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV41GridStateFilterValue.gxTpr_Name, "TFTEXTOSTITULO_SEL") == 0 )
            {
               AV26TFTextosTitulo_Sel = AV41GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV41GridStateFilterValue.gxTpr_Name, "PARM_&RUBROSID") == 0 )
            {
               AV49RubrosId = (short)(Math.Round(NumberUtil.Val( AV41GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
            }
            AV50GXV1 = (int)(AV50GXV1+1);
         }
      }

      protected void S121( )
      {
         /* 'LOADMEDIDASNOMBREOPTIONS' Routine */
         returnInSub = false;
         AV13TFMedidasNombre = AV27SearchTxt;
         AV14TFMedidasNombre_Sel = "";
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A139MedidasEstado ,
                                              AV22TFMedidasEstado_Sels ,
                                              AV14TFMedidasNombre_Sel ,
                                              AV13TFMedidasNombre ,
                                              AV15TFRubrosCosto ,
                                              AV16TFRubrosCosto_To ,
                                              AV17TFRubrosPrecioBase ,
                                              AV18TFRubrosPrecioBase_To ,
                                              AV20TFMonedaISOSimbolo_Sel ,
                                              AV19TFMonedaISOSimbolo ,
                                              AV22TFMedidasEstado_Sels.Count ,
                                              AV23TFTextosId ,
                                              AV24TFTextosId_To ,
                                              AV26TFTextosTitulo_Sel ,
                                              AV25TFTextosTitulo ,
                                              A138MedidasNombre ,
                                              A215RubrosCosto ,
                                              A216RubrosPrecioBase ,
                                              A119MonedaISOSimbolo ,
                                              A150TextosId ,
                                              A259TextosTitulo ,
                                              AV49RubrosId ,
                                              A121RubrosId } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.INT, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.DECIMAL, TypeConstants.DECIMAL,
                                              TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.SHORT
                                              }
         });
         lV13TFMedidasNombre = StringUtil.PadR( StringUtil.RTrim( AV13TFMedidasNombre), 50, "%");
         lV19TFMonedaISOSimbolo = StringUtil.PadR( StringUtil.RTrim( AV19TFMonedaISOSimbolo), 3, "%");
         lV25TFTextosTitulo = StringUtil.PadR( StringUtil.RTrim( AV25TFTextosTitulo), 80, "%");
         /* Using cursor P004D2 */
         pr_default.execute(0, new Object[] {AV49RubrosId, lV13TFMedidasNombre, AV14TFMedidasNombre_Sel, AV15TFRubrosCosto, AV16TFRubrosCosto_To, AV17TFRubrosPrecioBase, AV18TFRubrosPrecioBase_To, lV19TFMonedaISOSimbolo, AV20TFMonedaISOSimbolo_Sel, AV23TFTextosId, AV24TFTextosId_To, lV25TFTextosTitulo, AV26TFTextosTitulo_Sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRK4D2 = false;
            A118MonedaId = P004D2_A118MonedaId[0];
            A121RubrosId = P004D2_A121RubrosId[0];
            A138MedidasNombre = P004D2_A138MedidasNombre[0];
            A259TextosTitulo = P004D2_A259TextosTitulo[0];
            A150TextosId = P004D2_A150TextosId[0];
            n150TextosId = P004D2_n150TextosId[0];
            A139MedidasEstado = P004D2_A139MedidasEstado[0];
            n139MedidasEstado = P004D2_n139MedidasEstado[0];
            A119MonedaISOSimbolo = P004D2_A119MonedaISOSimbolo[0];
            A216RubrosPrecioBase = P004D2_A216RubrosPrecioBase[0];
            A215RubrosCosto = P004D2_A215RubrosCosto[0];
            A137MedidasID = P004D2_A137MedidasID[0];
            A119MonedaISOSimbolo = P004D2_A119MonedaISOSimbolo[0];
            A259TextosTitulo = P004D2_A259TextosTitulo[0];
            AV37count = 0;
            while ( (pr_default.getStatus(0) != 101) && ( P004D2_A121RubrosId[0] == A121RubrosId ) && ( StringUtil.StrCmp(P004D2_A138MedidasNombre[0], A138MedidasNombre) == 0 ) )
            {
               BRK4D2 = false;
               A137MedidasID = P004D2_A137MedidasID[0];
               AV37count = (long)(AV37count+1);
               BRK4D2 = true;
               pr_default.readNext(0);
            }
            if ( (0==AV28SkipItems) )
            {
               AV32Option = (String.IsNullOrEmpty(StringUtil.RTrim( A138MedidasNombre)) ? "<#Empty#>" : A138MedidasNombre);
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
            if ( ! BRK4D2 )
            {
               BRK4D2 = true;
               pr_default.readNext(0);
            }
         }
         pr_default.close(0);
      }

      protected void S131( )
      {
         /* 'LOADMONEDAISOSIMBOLOOPTIONS' Routine */
         returnInSub = false;
         AV19TFMonedaISOSimbolo = AV27SearchTxt;
         AV20TFMonedaISOSimbolo_Sel = "";
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              A139MedidasEstado ,
                                              AV22TFMedidasEstado_Sels ,
                                              AV14TFMedidasNombre_Sel ,
                                              AV13TFMedidasNombre ,
                                              AV15TFRubrosCosto ,
                                              AV16TFRubrosCosto_To ,
                                              AV17TFRubrosPrecioBase ,
                                              AV18TFRubrosPrecioBase_To ,
                                              AV20TFMonedaISOSimbolo_Sel ,
                                              AV19TFMonedaISOSimbolo ,
                                              AV22TFMedidasEstado_Sels.Count ,
                                              AV23TFTextosId ,
                                              AV24TFTextosId_To ,
                                              AV26TFTextosTitulo_Sel ,
                                              AV25TFTextosTitulo ,
                                              A138MedidasNombre ,
                                              A215RubrosCosto ,
                                              A216RubrosPrecioBase ,
                                              A119MonedaISOSimbolo ,
                                              A150TextosId ,
                                              A259TextosTitulo ,
                                              AV49RubrosId ,
                                              A121RubrosId } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.INT, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.DECIMAL, TypeConstants.DECIMAL,
                                              TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.SHORT
                                              }
         });
         lV13TFMedidasNombre = StringUtil.PadR( StringUtil.RTrim( AV13TFMedidasNombre), 50, "%");
         lV19TFMonedaISOSimbolo = StringUtil.PadR( StringUtil.RTrim( AV19TFMonedaISOSimbolo), 3, "%");
         lV25TFTextosTitulo = StringUtil.PadR( StringUtil.RTrim( AV25TFTextosTitulo), 80, "%");
         /* Using cursor P004D3 */
         pr_default.execute(1, new Object[] {AV49RubrosId, lV13TFMedidasNombre, AV14TFMedidasNombre_Sel, AV15TFRubrosCosto, AV16TFRubrosCosto_To, AV17TFRubrosPrecioBase, AV18TFRubrosPrecioBase_To, lV19TFMonedaISOSimbolo, AV20TFMonedaISOSimbolo_Sel, AV23TFTextosId, AV24TFTextosId_To, lV25TFTextosTitulo, AV26TFTextosTitulo_Sel});
         while ( (pr_default.getStatus(1) != 101) )
         {
            BRK4D4 = false;
            A118MonedaId = P004D3_A118MonedaId[0];
            A121RubrosId = P004D3_A121RubrosId[0];
            A119MonedaISOSimbolo = P004D3_A119MonedaISOSimbolo[0];
            A259TextosTitulo = P004D3_A259TextosTitulo[0];
            A150TextosId = P004D3_A150TextosId[0];
            n150TextosId = P004D3_n150TextosId[0];
            A139MedidasEstado = P004D3_A139MedidasEstado[0];
            n139MedidasEstado = P004D3_n139MedidasEstado[0];
            A216RubrosPrecioBase = P004D3_A216RubrosPrecioBase[0];
            A215RubrosCosto = P004D3_A215RubrosCosto[0];
            A138MedidasNombre = P004D3_A138MedidasNombre[0];
            A137MedidasID = P004D3_A137MedidasID[0];
            A119MonedaISOSimbolo = P004D3_A119MonedaISOSimbolo[0];
            A259TextosTitulo = P004D3_A259TextosTitulo[0];
            AV37count = 0;
            while ( (pr_default.getStatus(1) != 101) && ( P004D3_A121RubrosId[0] == A121RubrosId ) && ( StringUtil.StrCmp(P004D3_A119MonedaISOSimbolo[0], A119MonedaISOSimbolo) == 0 ) )
            {
               BRK4D4 = false;
               A118MonedaId = P004D3_A118MonedaId[0];
               A137MedidasID = P004D3_A137MedidasID[0];
               AV37count = (long)(AV37count+1);
               BRK4D4 = true;
               pr_default.readNext(1);
            }
            if ( (0==AV28SkipItems) )
            {
               AV32Option = (String.IsNullOrEmpty(StringUtil.RTrim( A119MonedaISOSimbolo)) ? "<#Empty#>" : A119MonedaISOSimbolo);
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
            if ( ! BRK4D4 )
            {
               BRK4D4 = true;
               pr_default.readNext(1);
            }
         }
         pr_default.close(1);
      }

      protected void S141( )
      {
         /* 'LOADTEXTOSTITULOOPTIONS' Routine */
         returnInSub = false;
         AV25TFTextosTitulo = AV27SearchTxt;
         AV26TFTextosTitulo_Sel = "";
         pr_default.dynParam(2, new Object[]{ new Object[]{
                                              A139MedidasEstado ,
                                              AV22TFMedidasEstado_Sels ,
                                              AV14TFMedidasNombre_Sel ,
                                              AV13TFMedidasNombre ,
                                              AV15TFRubrosCosto ,
                                              AV16TFRubrosCosto_To ,
                                              AV17TFRubrosPrecioBase ,
                                              AV18TFRubrosPrecioBase_To ,
                                              AV20TFMonedaISOSimbolo_Sel ,
                                              AV19TFMonedaISOSimbolo ,
                                              AV22TFMedidasEstado_Sels.Count ,
                                              AV23TFTextosId ,
                                              AV24TFTextosId_To ,
                                              AV26TFTextosTitulo_Sel ,
                                              AV25TFTextosTitulo ,
                                              A138MedidasNombre ,
                                              A215RubrosCosto ,
                                              A216RubrosPrecioBase ,
                                              A119MonedaISOSimbolo ,
                                              A150TextosId ,
                                              A259TextosTitulo ,
                                              AV49RubrosId ,
                                              A121RubrosId } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.INT, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.DECIMAL, TypeConstants.DECIMAL,
                                              TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.SHORT
                                              }
         });
         lV13TFMedidasNombre = StringUtil.PadR( StringUtil.RTrim( AV13TFMedidasNombre), 50, "%");
         lV19TFMonedaISOSimbolo = StringUtil.PadR( StringUtil.RTrim( AV19TFMonedaISOSimbolo), 3, "%");
         lV25TFTextosTitulo = StringUtil.PadR( StringUtil.RTrim( AV25TFTextosTitulo), 80, "%");
         /* Using cursor P004D4 */
         pr_default.execute(2, new Object[] {AV49RubrosId, lV13TFMedidasNombre, AV14TFMedidasNombre_Sel, AV15TFRubrosCosto, AV16TFRubrosCosto_To, AV17TFRubrosPrecioBase, AV18TFRubrosPrecioBase_To, lV19TFMonedaISOSimbolo, AV20TFMonedaISOSimbolo_Sel, AV23TFTextosId, AV24TFTextosId_To, lV25TFTextosTitulo, AV26TFTextosTitulo_Sel});
         while ( (pr_default.getStatus(2) != 101) )
         {
            BRK4D6 = false;
            A118MonedaId = P004D4_A118MonedaId[0];
            A121RubrosId = P004D4_A121RubrosId[0];
            A259TextosTitulo = P004D4_A259TextosTitulo[0];
            A150TextosId = P004D4_A150TextosId[0];
            n150TextosId = P004D4_n150TextosId[0];
            A139MedidasEstado = P004D4_A139MedidasEstado[0];
            n139MedidasEstado = P004D4_n139MedidasEstado[0];
            A119MonedaISOSimbolo = P004D4_A119MonedaISOSimbolo[0];
            A216RubrosPrecioBase = P004D4_A216RubrosPrecioBase[0];
            A215RubrosCosto = P004D4_A215RubrosCosto[0];
            A138MedidasNombre = P004D4_A138MedidasNombre[0];
            A137MedidasID = P004D4_A137MedidasID[0];
            A119MonedaISOSimbolo = P004D4_A119MonedaISOSimbolo[0];
            A259TextosTitulo = P004D4_A259TextosTitulo[0];
            AV37count = 0;
            while ( (pr_default.getStatus(2) != 101) && ( P004D4_A121RubrosId[0] == A121RubrosId ) && ( StringUtil.StrCmp(P004D4_A259TextosTitulo[0], A259TextosTitulo) == 0 ) )
            {
               BRK4D6 = false;
               A150TextosId = P004D4_A150TextosId[0];
               n150TextosId = P004D4_n150TextosId[0];
               A137MedidasID = P004D4_A137MedidasID[0];
               AV37count = (long)(AV37count+1);
               BRK4D6 = true;
               pr_default.readNext(2);
            }
            if ( (0==AV28SkipItems) )
            {
               AV32Option = (String.IsNullOrEmpty(StringUtil.RTrim( A259TextosTitulo)) ? "<#Empty#>" : A259TextosTitulo);
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
            if ( ! BRK4D6 )
            {
               BRK4D6 = true;
               pr_default.readNext(2);
            }
         }
         pr_default.close(2);
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
         AV13TFMedidasNombre = "";
         AV14TFMedidasNombre_Sel = "";
         AV19TFMonedaISOSimbolo = "";
         AV20TFMonedaISOSimbolo_Sel = "";
         AV21TFMedidasEstado_SelsJson = "";
         AV22TFMedidasEstado_Sels = new GxSimpleCollection<string>();
         AV25TFTextosTitulo = "";
         AV26TFTextosTitulo_Sel = "";
         lV13TFMedidasNombre = "";
         lV19TFMonedaISOSimbolo = "";
         lV25TFTextosTitulo = "";
         A139MedidasEstado = "";
         A138MedidasNombre = "";
         A119MonedaISOSimbolo = "";
         A259TextosTitulo = "";
         P004D2_A118MonedaId = new short[1] ;
         P004D2_A121RubrosId = new short[1] ;
         P004D2_A138MedidasNombre = new string[] {""} ;
         P004D2_A259TextosTitulo = new string[] {""} ;
         P004D2_A150TextosId = new long[1] ;
         P004D2_n150TextosId = new bool[] {false} ;
         P004D2_A139MedidasEstado = new string[] {""} ;
         P004D2_n139MedidasEstado = new bool[] {false} ;
         P004D2_A119MonedaISOSimbolo = new string[] {""} ;
         P004D2_A216RubrosPrecioBase = new decimal[1] ;
         P004D2_A215RubrosCosto = new decimal[1] ;
         P004D2_A137MedidasID = new long[1] ;
         AV32Option = "";
         P004D3_A118MonedaId = new short[1] ;
         P004D3_A121RubrosId = new short[1] ;
         P004D3_A119MonedaISOSimbolo = new string[] {""} ;
         P004D3_A259TextosTitulo = new string[] {""} ;
         P004D3_A150TextosId = new long[1] ;
         P004D3_n150TextosId = new bool[] {false} ;
         P004D3_A139MedidasEstado = new string[] {""} ;
         P004D3_n139MedidasEstado = new bool[] {false} ;
         P004D3_A216RubrosPrecioBase = new decimal[1] ;
         P004D3_A215RubrosCosto = new decimal[1] ;
         P004D3_A138MedidasNombre = new string[] {""} ;
         P004D3_A137MedidasID = new long[1] ;
         P004D4_A118MonedaId = new short[1] ;
         P004D4_A121RubrosId = new short[1] ;
         P004D4_A259TextosTitulo = new string[] {""} ;
         P004D4_A150TextosId = new long[1] ;
         P004D4_n150TextosId = new bool[] {false} ;
         P004D4_A139MedidasEstado = new string[] {""} ;
         P004D4_n139MedidasEstado = new bool[] {false} ;
         P004D4_A119MonedaISOSimbolo = new string[] {""} ;
         P004D4_A216RubrosPrecioBase = new decimal[1] ;
         P004D4_A215RubrosCosto = new decimal[1] ;
         P004D4_A138MedidasNombre = new string[] {""} ;
         P004D4_A137MedidasID = new long[1] ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.rubrosmedidasmedidaswcgetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P004D2_A118MonedaId, P004D2_A121RubrosId, P004D2_A138MedidasNombre, P004D2_A259TextosTitulo, P004D2_A150TextosId, P004D2_n150TextosId, P004D2_A139MedidasEstado, P004D2_n139MedidasEstado, P004D2_A119MonedaISOSimbolo, P004D2_A216RubrosPrecioBase,
               P004D2_A215RubrosCosto, P004D2_A137MedidasID
               }
               , new Object[] {
               P004D3_A118MonedaId, P004D3_A121RubrosId, P004D3_A119MonedaISOSimbolo, P004D3_A259TextosTitulo, P004D3_A150TextosId, P004D3_n150TextosId, P004D3_A139MedidasEstado, P004D3_n139MedidasEstado, P004D3_A216RubrosPrecioBase, P004D3_A215RubrosCosto,
               P004D3_A138MedidasNombre, P004D3_A137MedidasID
               }
               , new Object[] {
               P004D4_A118MonedaId, P004D4_A121RubrosId, P004D4_A259TextosTitulo, P004D4_A150TextosId, P004D4_n150TextosId, P004D4_A139MedidasEstado, P004D4_n139MedidasEstado, P004D4_A119MonedaISOSimbolo, P004D4_A216RubrosPrecioBase, P004D4_A215RubrosCosto,
               P004D4_A138MedidasNombre, P004D4_A137MedidasID
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV30MaxItems ;
      private short AV29PageIndex ;
      private short AV28SkipItems ;
      private short AV49RubrosId ;
      private short A121RubrosId ;
      private short A118MonedaId ;
      private int AV50GXV1 ;
      private int AV22TFMedidasEstado_Sels_Count ;
      private long AV23TFTextosId ;
      private long AV24TFTextosId_To ;
      private long A150TextosId ;
      private long A137MedidasID ;
      private long AV37count ;
      private decimal AV15TFRubrosCosto ;
      private decimal AV16TFRubrosCosto_To ;
      private decimal AV17TFRubrosPrecioBase ;
      private decimal AV18TFRubrosPrecioBase_To ;
      private decimal A215RubrosCosto ;
      private decimal A216RubrosPrecioBase ;
      private string AV13TFMedidasNombre ;
      private string AV14TFMedidasNombre_Sel ;
      private string AV19TFMonedaISOSimbolo ;
      private string AV20TFMonedaISOSimbolo_Sel ;
      private string AV25TFTextosTitulo ;
      private string AV26TFTextosTitulo_Sel ;
      private string lV13TFMedidasNombre ;
      private string lV19TFMonedaISOSimbolo ;
      private string lV25TFTextosTitulo ;
      private string A139MedidasEstado ;
      private string A138MedidasNombre ;
      private string A119MonedaISOSimbolo ;
      private string A259TextosTitulo ;
      private bool AV8IsAuthorized ;
      private bool GXt_boolean1 ;
      private bool returnInSub ;
      private bool BRK4D2 ;
      private bool n150TextosId ;
      private bool n139MedidasEstado ;
      private bool BRK4D4 ;
      private bool BRK4D6 ;
      private string AV46OptionsJson ;
      private string AV47OptionsDescJson ;
      private string AV48OptionIndexesJson ;
      private string AV21TFMedidasEstado_SelsJson ;
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
      private GxSimpleCollection<string> AV22TFMedidasEstado_Sels ;
      private IDataStoreProvider pr_default ;
      private short[] P004D2_A118MonedaId ;
      private short[] P004D2_A121RubrosId ;
      private string[] P004D2_A138MedidasNombre ;
      private string[] P004D2_A259TextosTitulo ;
      private long[] P004D2_A150TextosId ;
      private bool[] P004D2_n150TextosId ;
      private string[] P004D2_A139MedidasEstado ;
      private bool[] P004D2_n139MedidasEstado ;
      private string[] P004D2_A119MonedaISOSimbolo ;
      private decimal[] P004D2_A216RubrosPrecioBase ;
      private decimal[] P004D2_A215RubrosCosto ;
      private long[] P004D2_A137MedidasID ;
      private short[] P004D3_A118MonedaId ;
      private short[] P004D3_A121RubrosId ;
      private string[] P004D3_A119MonedaISOSimbolo ;
      private string[] P004D3_A259TextosTitulo ;
      private long[] P004D3_A150TextosId ;
      private bool[] P004D3_n150TextosId ;
      private string[] P004D3_A139MedidasEstado ;
      private bool[] P004D3_n139MedidasEstado ;
      private decimal[] P004D3_A216RubrosPrecioBase ;
      private decimal[] P004D3_A215RubrosCosto ;
      private string[] P004D3_A138MedidasNombre ;
      private long[] P004D3_A137MedidasID ;
      private short[] P004D4_A118MonedaId ;
      private short[] P004D4_A121RubrosId ;
      private string[] P004D4_A259TextosTitulo ;
      private long[] P004D4_A150TextosId ;
      private bool[] P004D4_n150TextosId ;
      private string[] P004D4_A139MedidasEstado ;
      private bool[] P004D4_n139MedidasEstado ;
      private string[] P004D4_A119MonedaISOSimbolo ;
      private decimal[] P004D4_A216RubrosPrecioBase ;
      private decimal[] P004D4_A215RubrosCosto ;
      private string[] P004D4_A138MedidasNombre ;
      private long[] P004D4_A137MedidasID ;
      private string aP3_OptionsJson ;
      private string aP4_OptionsDescJson ;
      private string aP5_OptionIndexesJson ;
   }

   public class rubrosmedidasmedidaswcgetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P004D2( IGxContext context ,
                                             string A139MedidasEstado ,
                                             GxSimpleCollection<string> AV22TFMedidasEstado_Sels ,
                                             string AV14TFMedidasNombre_Sel ,
                                             string AV13TFMedidasNombre ,
                                             decimal AV15TFRubrosCosto ,
                                             decimal AV16TFRubrosCosto_To ,
                                             decimal AV17TFRubrosPrecioBase ,
                                             decimal AV18TFRubrosPrecioBase_To ,
                                             string AV20TFMonedaISOSimbolo_Sel ,
                                             string AV19TFMonedaISOSimbolo ,
                                             int AV22TFMedidasEstado_Sels_Count ,
                                             long AV23TFTextosId ,
                                             long AV24TFTextosId_To ,
                                             string AV26TFTextosTitulo_Sel ,
                                             string AV25TFTextosTitulo ,
                                             string A138MedidasNombre ,
                                             decimal A215RubrosCosto ,
                                             decimal A216RubrosPrecioBase ,
                                             string A119MonedaISOSimbolo ,
                                             long A150TextosId ,
                                             string A259TextosTitulo ,
                                             short AV49RubrosId ,
                                             short A121RubrosId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int2 = new short[13];
         Object[] GXv_Object3 = new Object[2];
         scmdbuf = "SELECT T1.[MonedaId], T1.[RubrosId], T1.[MedidasNombre], T3.[TextosTitulo], T1.[TextosId], T1.[MedidasEstado], T2.[MonedaISOSimbolo], T1.[RubrosPrecioBase], T1.[RubrosCosto], T1.[MedidasID] FROM (([RubrosMedidas] T1 INNER JOIN [Moneda] T2 ON T2.[MonedaId] = T1.[MonedaId]) LEFT JOIN [Textos] T3 ON T3.[TextosId] = T1.[TextosId])";
         AddWhere(sWhereString, "(T1.[RubrosId] = @AV49RubrosId)");
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV14TFMedidasNombre_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV13TFMedidasNombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[MedidasNombre]) like UPPER(@lV13TFMedidasNombre))");
         }
         else
         {
            GXv_int2[1] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV14TFMedidasNombre_Sel)) && ! ( StringUtil.StrCmp(AV14TFMedidasNombre_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[MedidasNombre] = @AV14TFMedidasNombre_Sel)");
         }
         else
         {
            GXv_int2[2] = 1;
         }
         if ( StringUtil.StrCmp(AV14TFMedidasNombre_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[MedidasNombre] = ''))");
         }
         if ( ! (Convert.ToDecimal(0)==AV15TFRubrosCosto) )
         {
            AddWhere(sWhereString, "(T1.[RubrosCosto] >= @AV15TFRubrosCosto)");
         }
         else
         {
            GXv_int2[3] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV16TFRubrosCosto_To) )
         {
            AddWhere(sWhereString, "(T1.[RubrosCosto] <= @AV16TFRubrosCosto_To)");
         }
         else
         {
            GXv_int2[4] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV17TFRubrosPrecioBase) )
         {
            AddWhere(sWhereString, "(T1.[RubrosPrecioBase] >= @AV17TFRubrosPrecioBase)");
         }
         else
         {
            GXv_int2[5] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV18TFRubrosPrecioBase_To) )
         {
            AddWhere(sWhereString, "(T1.[RubrosPrecioBase] <= @AV18TFRubrosPrecioBase_To)");
         }
         else
         {
            GXv_int2[6] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV20TFMonedaISOSimbolo_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV19TFMonedaISOSimbolo)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[MonedaISOSimbolo]) like UPPER(@lV19TFMonedaISOSimbolo))");
         }
         else
         {
            GXv_int2[7] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV20TFMonedaISOSimbolo_Sel)) && ! ( StringUtil.StrCmp(AV20TFMonedaISOSimbolo_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.[MonedaISOSimbolo] = @AV20TFMonedaISOSimbolo_Sel)");
         }
         else
         {
            GXv_int2[8] = 1;
         }
         if ( StringUtil.StrCmp(AV20TFMonedaISOSimbolo_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T2.[MonedaISOSimbolo] = ''))");
         }
         if ( AV22TFMedidasEstado_Sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV22TFMedidasEstado_Sels, "T1.[MedidasEstado] IN (", ")")+")");
         }
         if ( ! (0==AV23TFTextosId) )
         {
            AddWhere(sWhereString, "(T1.[TextosId] >= @AV23TFTextosId)");
         }
         else
         {
            GXv_int2[9] = 1;
         }
         if ( ! (0==AV24TFTextosId_To) )
         {
            AddWhere(sWhereString, "(T1.[TextosId] <= @AV24TFTextosId_To)");
         }
         else
         {
            GXv_int2[10] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV26TFTextosTitulo_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV25TFTextosTitulo)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T3.[TextosTitulo]) like UPPER(@lV25TFTextosTitulo))");
         }
         else
         {
            GXv_int2[11] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV26TFTextosTitulo_Sel)) && ! ( StringUtil.StrCmp(AV26TFTextosTitulo_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T3.[TextosTitulo] = @AV26TFTextosTitulo_Sel)");
         }
         else
         {
            GXv_int2[12] = 1;
         }
         if ( StringUtil.StrCmp(AV26TFTextosTitulo_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T3.[TextosTitulo] IS NULL or (T3.[TextosTitulo] = ''))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[RubrosId], T1.[MedidasNombre]";
         GXv_Object3[0] = scmdbuf;
         GXv_Object3[1] = GXv_int2;
         return GXv_Object3 ;
      }

      protected Object[] conditional_P004D3( IGxContext context ,
                                             string A139MedidasEstado ,
                                             GxSimpleCollection<string> AV22TFMedidasEstado_Sels ,
                                             string AV14TFMedidasNombre_Sel ,
                                             string AV13TFMedidasNombre ,
                                             decimal AV15TFRubrosCosto ,
                                             decimal AV16TFRubrosCosto_To ,
                                             decimal AV17TFRubrosPrecioBase ,
                                             decimal AV18TFRubrosPrecioBase_To ,
                                             string AV20TFMonedaISOSimbolo_Sel ,
                                             string AV19TFMonedaISOSimbolo ,
                                             int AV22TFMedidasEstado_Sels_Count ,
                                             long AV23TFTextosId ,
                                             long AV24TFTextosId_To ,
                                             string AV26TFTextosTitulo_Sel ,
                                             string AV25TFTextosTitulo ,
                                             string A138MedidasNombre ,
                                             decimal A215RubrosCosto ,
                                             decimal A216RubrosPrecioBase ,
                                             string A119MonedaISOSimbolo ,
                                             long A150TextosId ,
                                             string A259TextosTitulo ,
                                             short AV49RubrosId ,
                                             short A121RubrosId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int4 = new short[13];
         Object[] GXv_Object5 = new Object[2];
         scmdbuf = "SELECT T1.[MonedaId], T1.[RubrosId], T2.[MonedaISOSimbolo], T3.[TextosTitulo], T1.[TextosId], T1.[MedidasEstado], T1.[RubrosPrecioBase], T1.[RubrosCosto], T1.[MedidasNombre], T1.[MedidasID] FROM (([RubrosMedidas] T1 INNER JOIN [Moneda] T2 ON T2.[MonedaId] = T1.[MonedaId]) LEFT JOIN [Textos] T3 ON T3.[TextosId] = T1.[TextosId])";
         AddWhere(sWhereString, "(T1.[RubrosId] = @AV49RubrosId)");
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV14TFMedidasNombre_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV13TFMedidasNombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[MedidasNombre]) like UPPER(@lV13TFMedidasNombre))");
         }
         else
         {
            GXv_int4[1] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV14TFMedidasNombre_Sel)) && ! ( StringUtil.StrCmp(AV14TFMedidasNombre_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[MedidasNombre] = @AV14TFMedidasNombre_Sel)");
         }
         else
         {
            GXv_int4[2] = 1;
         }
         if ( StringUtil.StrCmp(AV14TFMedidasNombre_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[MedidasNombre] = ''))");
         }
         if ( ! (Convert.ToDecimal(0)==AV15TFRubrosCosto) )
         {
            AddWhere(sWhereString, "(T1.[RubrosCosto] >= @AV15TFRubrosCosto)");
         }
         else
         {
            GXv_int4[3] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV16TFRubrosCosto_To) )
         {
            AddWhere(sWhereString, "(T1.[RubrosCosto] <= @AV16TFRubrosCosto_To)");
         }
         else
         {
            GXv_int4[4] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV17TFRubrosPrecioBase) )
         {
            AddWhere(sWhereString, "(T1.[RubrosPrecioBase] >= @AV17TFRubrosPrecioBase)");
         }
         else
         {
            GXv_int4[5] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV18TFRubrosPrecioBase_To) )
         {
            AddWhere(sWhereString, "(T1.[RubrosPrecioBase] <= @AV18TFRubrosPrecioBase_To)");
         }
         else
         {
            GXv_int4[6] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV20TFMonedaISOSimbolo_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV19TFMonedaISOSimbolo)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[MonedaISOSimbolo]) like UPPER(@lV19TFMonedaISOSimbolo))");
         }
         else
         {
            GXv_int4[7] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV20TFMonedaISOSimbolo_Sel)) && ! ( StringUtil.StrCmp(AV20TFMonedaISOSimbolo_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.[MonedaISOSimbolo] = @AV20TFMonedaISOSimbolo_Sel)");
         }
         else
         {
            GXv_int4[8] = 1;
         }
         if ( StringUtil.StrCmp(AV20TFMonedaISOSimbolo_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T2.[MonedaISOSimbolo] = ''))");
         }
         if ( AV22TFMedidasEstado_Sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV22TFMedidasEstado_Sels, "T1.[MedidasEstado] IN (", ")")+")");
         }
         if ( ! (0==AV23TFTextosId) )
         {
            AddWhere(sWhereString, "(T1.[TextosId] >= @AV23TFTextosId)");
         }
         else
         {
            GXv_int4[9] = 1;
         }
         if ( ! (0==AV24TFTextosId_To) )
         {
            AddWhere(sWhereString, "(T1.[TextosId] <= @AV24TFTextosId_To)");
         }
         else
         {
            GXv_int4[10] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV26TFTextosTitulo_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV25TFTextosTitulo)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T3.[TextosTitulo]) like UPPER(@lV25TFTextosTitulo))");
         }
         else
         {
            GXv_int4[11] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV26TFTextosTitulo_Sel)) && ! ( StringUtil.StrCmp(AV26TFTextosTitulo_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T3.[TextosTitulo] = @AV26TFTextosTitulo_Sel)");
         }
         else
         {
            GXv_int4[12] = 1;
         }
         if ( StringUtil.StrCmp(AV26TFTextosTitulo_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T3.[TextosTitulo] IS NULL or (T3.[TextosTitulo] = ''))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[RubrosId], T2.[MonedaISOSimbolo]";
         GXv_Object5[0] = scmdbuf;
         GXv_Object5[1] = GXv_int4;
         return GXv_Object5 ;
      }

      protected Object[] conditional_P004D4( IGxContext context ,
                                             string A139MedidasEstado ,
                                             GxSimpleCollection<string> AV22TFMedidasEstado_Sels ,
                                             string AV14TFMedidasNombre_Sel ,
                                             string AV13TFMedidasNombre ,
                                             decimal AV15TFRubrosCosto ,
                                             decimal AV16TFRubrosCosto_To ,
                                             decimal AV17TFRubrosPrecioBase ,
                                             decimal AV18TFRubrosPrecioBase_To ,
                                             string AV20TFMonedaISOSimbolo_Sel ,
                                             string AV19TFMonedaISOSimbolo ,
                                             int AV22TFMedidasEstado_Sels_Count ,
                                             long AV23TFTextosId ,
                                             long AV24TFTextosId_To ,
                                             string AV26TFTextosTitulo_Sel ,
                                             string AV25TFTextosTitulo ,
                                             string A138MedidasNombre ,
                                             decimal A215RubrosCosto ,
                                             decimal A216RubrosPrecioBase ,
                                             string A119MonedaISOSimbolo ,
                                             long A150TextosId ,
                                             string A259TextosTitulo ,
                                             short AV49RubrosId ,
                                             short A121RubrosId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int6 = new short[13];
         Object[] GXv_Object7 = new Object[2];
         scmdbuf = "SELECT T1.[MonedaId], T1.[RubrosId], T3.[TextosTitulo], T1.[TextosId], T1.[MedidasEstado], T2.[MonedaISOSimbolo], T1.[RubrosPrecioBase], T1.[RubrosCosto], T1.[MedidasNombre], T1.[MedidasID] FROM (([RubrosMedidas] T1 INNER JOIN [Moneda] T2 ON T2.[MonedaId] = T1.[MonedaId]) LEFT JOIN [Textos] T3 ON T3.[TextosId] = T1.[TextosId])";
         AddWhere(sWhereString, "(T1.[RubrosId] = @AV49RubrosId)");
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV14TFMedidasNombre_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV13TFMedidasNombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[MedidasNombre]) like UPPER(@lV13TFMedidasNombre))");
         }
         else
         {
            GXv_int6[1] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV14TFMedidasNombre_Sel)) && ! ( StringUtil.StrCmp(AV14TFMedidasNombre_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[MedidasNombre] = @AV14TFMedidasNombre_Sel)");
         }
         else
         {
            GXv_int6[2] = 1;
         }
         if ( StringUtil.StrCmp(AV14TFMedidasNombre_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[MedidasNombre] = ''))");
         }
         if ( ! (Convert.ToDecimal(0)==AV15TFRubrosCosto) )
         {
            AddWhere(sWhereString, "(T1.[RubrosCosto] >= @AV15TFRubrosCosto)");
         }
         else
         {
            GXv_int6[3] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV16TFRubrosCosto_To) )
         {
            AddWhere(sWhereString, "(T1.[RubrosCosto] <= @AV16TFRubrosCosto_To)");
         }
         else
         {
            GXv_int6[4] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV17TFRubrosPrecioBase) )
         {
            AddWhere(sWhereString, "(T1.[RubrosPrecioBase] >= @AV17TFRubrosPrecioBase)");
         }
         else
         {
            GXv_int6[5] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV18TFRubrosPrecioBase_To) )
         {
            AddWhere(sWhereString, "(T1.[RubrosPrecioBase] <= @AV18TFRubrosPrecioBase_To)");
         }
         else
         {
            GXv_int6[6] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV20TFMonedaISOSimbolo_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV19TFMonedaISOSimbolo)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[MonedaISOSimbolo]) like UPPER(@lV19TFMonedaISOSimbolo))");
         }
         else
         {
            GXv_int6[7] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV20TFMonedaISOSimbolo_Sel)) && ! ( StringUtil.StrCmp(AV20TFMonedaISOSimbolo_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.[MonedaISOSimbolo] = @AV20TFMonedaISOSimbolo_Sel)");
         }
         else
         {
            GXv_int6[8] = 1;
         }
         if ( StringUtil.StrCmp(AV20TFMonedaISOSimbolo_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T2.[MonedaISOSimbolo] = ''))");
         }
         if ( AV22TFMedidasEstado_Sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV22TFMedidasEstado_Sels, "T1.[MedidasEstado] IN (", ")")+")");
         }
         if ( ! (0==AV23TFTextosId) )
         {
            AddWhere(sWhereString, "(T1.[TextosId] >= @AV23TFTextosId)");
         }
         else
         {
            GXv_int6[9] = 1;
         }
         if ( ! (0==AV24TFTextosId_To) )
         {
            AddWhere(sWhereString, "(T1.[TextosId] <= @AV24TFTextosId_To)");
         }
         else
         {
            GXv_int6[10] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV26TFTextosTitulo_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV25TFTextosTitulo)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T3.[TextosTitulo]) like UPPER(@lV25TFTextosTitulo))");
         }
         else
         {
            GXv_int6[11] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV26TFTextosTitulo_Sel)) && ! ( StringUtil.StrCmp(AV26TFTextosTitulo_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T3.[TextosTitulo] = @AV26TFTextosTitulo_Sel)");
         }
         else
         {
            GXv_int6[12] = 1;
         }
         if ( StringUtil.StrCmp(AV26TFTextosTitulo_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T3.[TextosTitulo] IS NULL or (T3.[TextosTitulo] = ''))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[RubrosId], T3.[TextosTitulo]";
         GXv_Object7[0] = scmdbuf;
         GXv_Object7[1] = GXv_int6;
         return GXv_Object7 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_P004D2(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (decimal)dynConstraints[4] , (decimal)dynConstraints[5] , (decimal)dynConstraints[6] , (decimal)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (int)dynConstraints[10] , (long)dynConstraints[11] , (long)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (decimal)dynConstraints[16] , (decimal)dynConstraints[17] , (string)dynConstraints[18] , (long)dynConstraints[19] , (string)dynConstraints[20] , (short)dynConstraints[21] , (short)dynConstraints[22] );
               case 1 :
                     return conditional_P004D3(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (decimal)dynConstraints[4] , (decimal)dynConstraints[5] , (decimal)dynConstraints[6] , (decimal)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (int)dynConstraints[10] , (long)dynConstraints[11] , (long)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (decimal)dynConstraints[16] , (decimal)dynConstraints[17] , (string)dynConstraints[18] , (long)dynConstraints[19] , (string)dynConstraints[20] , (short)dynConstraints[21] , (short)dynConstraints[22] );
               case 2 :
                     return conditional_P004D4(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (decimal)dynConstraints[4] , (decimal)dynConstraints[5] , (decimal)dynConstraints[6] , (decimal)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (int)dynConstraints[10] , (long)dynConstraints[11] , (long)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (decimal)dynConstraints[16] , (decimal)dynConstraints[17] , (string)dynConstraints[18] , (long)dynConstraints[19] , (string)dynConstraints[20] , (short)dynConstraints[21] , (short)dynConstraints[22] );
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
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP004D2;
          prmP004D2 = new Object[] {
          new ParDef("@AV49RubrosId",GXType.Int16,4,0) ,
          new ParDef("@lV13TFMedidasNombre",GXType.Char,50,0) ,
          new ParDef("@AV14TFMedidasNombre_Sel",GXType.NChar,50,0) ,
          new ParDef("@AV15TFRubrosCosto",GXType.Decimal,18,2) ,
          new ParDef("@AV16TFRubrosCosto_To",GXType.Decimal,18,2) ,
          new ParDef("@AV17TFRubrosPrecioBase",GXType.Decimal,18,2) ,
          new ParDef("@AV18TFRubrosPrecioBase_To",GXType.Decimal,18,2) ,
          new ParDef("@lV19TFMonedaISOSimbolo",GXType.Char,3,0) ,
          new ParDef("@AV20TFMonedaISOSimbolo_Sel",GXType.NChar,3,0) ,
          new ParDef("@AV23TFTextosId",GXType.Decimal,18,0) ,
          new ParDef("@AV24TFTextosId_To",GXType.Decimal,18,0) ,
          new ParDef("@lV25TFTextosTitulo",GXType.Char,80,0) ,
          new ParDef("@AV26TFTextosTitulo_Sel",GXType.NChar,80,0)
          };
          Object[] prmP004D3;
          prmP004D3 = new Object[] {
          new ParDef("@AV49RubrosId",GXType.Int16,4,0) ,
          new ParDef("@lV13TFMedidasNombre",GXType.Char,50,0) ,
          new ParDef("@AV14TFMedidasNombre_Sel",GXType.NChar,50,0) ,
          new ParDef("@AV15TFRubrosCosto",GXType.Decimal,18,2) ,
          new ParDef("@AV16TFRubrosCosto_To",GXType.Decimal,18,2) ,
          new ParDef("@AV17TFRubrosPrecioBase",GXType.Decimal,18,2) ,
          new ParDef("@AV18TFRubrosPrecioBase_To",GXType.Decimal,18,2) ,
          new ParDef("@lV19TFMonedaISOSimbolo",GXType.Char,3,0) ,
          new ParDef("@AV20TFMonedaISOSimbolo_Sel",GXType.NChar,3,0) ,
          new ParDef("@AV23TFTextosId",GXType.Decimal,18,0) ,
          new ParDef("@AV24TFTextosId_To",GXType.Decimal,18,0) ,
          new ParDef("@lV25TFTextosTitulo",GXType.Char,80,0) ,
          new ParDef("@AV26TFTextosTitulo_Sel",GXType.NChar,80,0)
          };
          Object[] prmP004D4;
          prmP004D4 = new Object[] {
          new ParDef("@AV49RubrosId",GXType.Int16,4,0) ,
          new ParDef("@lV13TFMedidasNombre",GXType.Char,50,0) ,
          new ParDef("@AV14TFMedidasNombre_Sel",GXType.NChar,50,0) ,
          new ParDef("@AV15TFRubrosCosto",GXType.Decimal,18,2) ,
          new ParDef("@AV16TFRubrosCosto_To",GXType.Decimal,18,2) ,
          new ParDef("@AV17TFRubrosPrecioBase",GXType.Decimal,18,2) ,
          new ParDef("@AV18TFRubrosPrecioBase_To",GXType.Decimal,18,2) ,
          new ParDef("@lV19TFMonedaISOSimbolo",GXType.Char,3,0) ,
          new ParDef("@AV20TFMonedaISOSimbolo_Sel",GXType.NChar,3,0) ,
          new ParDef("@AV23TFTextosId",GXType.Decimal,18,0) ,
          new ParDef("@AV24TFTextosId_To",GXType.Decimal,18,0) ,
          new ParDef("@lV25TFTextosTitulo",GXType.Char,80,0) ,
          new ParDef("@AV26TFTextosTitulo_Sel",GXType.NChar,80,0)
          };
          def= new CursorDef[] {
              new CursorDef("P004D2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP004D2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P004D3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP004D3,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P004D4", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP004D4,100, GxCacheFrequency.OFF ,true,false )
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
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 50);
                ((string[]) buf[3])[0] = rslt.getString(4, 80);
                ((long[]) buf[4])[0] = rslt.getLong(5);
                ((bool[]) buf[5])[0] = rslt.wasNull(5);
                ((string[]) buf[6])[0] = rslt.getString(6, 3);
                ((bool[]) buf[7])[0] = rslt.wasNull(6);
                ((string[]) buf[8])[0] = rslt.getString(7, 3);
                ((decimal[]) buf[9])[0] = rslt.getDecimal(8);
                ((decimal[]) buf[10])[0] = rslt.getDecimal(9);
                ((long[]) buf[11])[0] = rslt.getLong(10);
                return;
             case 1 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 3);
                ((string[]) buf[3])[0] = rslt.getString(4, 80);
                ((long[]) buf[4])[0] = rslt.getLong(5);
                ((bool[]) buf[5])[0] = rslt.wasNull(5);
                ((string[]) buf[6])[0] = rslt.getString(6, 3);
                ((bool[]) buf[7])[0] = rslt.wasNull(6);
                ((decimal[]) buf[8])[0] = rslt.getDecimal(7);
                ((decimal[]) buf[9])[0] = rslt.getDecimal(8);
                ((string[]) buf[10])[0] = rslt.getString(9, 50);
                ((long[]) buf[11])[0] = rslt.getLong(10);
                return;
             case 2 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 80);
                ((long[]) buf[3])[0] = rslt.getLong(4);
                ((bool[]) buf[4])[0] = rslt.wasNull(4);
                ((string[]) buf[5])[0] = rslt.getString(5, 3);
                ((bool[]) buf[6])[0] = rslt.wasNull(5);
                ((string[]) buf[7])[0] = rslt.getString(6, 3);
                ((decimal[]) buf[8])[0] = rslt.getDecimal(7);
                ((decimal[]) buf[9])[0] = rslt.getDecimal(8);
                ((string[]) buf[10])[0] = rslt.getString(9, 50);
                ((long[]) buf[11])[0] = rslt.getLong(10);
                return;
       }
    }

 }

 [ServiceContract(Namespace = "GeneXus.Programs.rubrosmedidasmedidaswcgetfilterdata_services")]
 [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple)]
 [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
 public class rubrosmedidasmedidaswcgetfilterdata_services : GxRestService
 {
    [OperationContract(Name = "RubrosMedidasMedidasWCGetFilterData" )]
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
          if ( ! ProcessHeaders("rubrosmedidasmedidaswcgetfilterdata") )
          {
             return  ;
          }
          rubrosmedidasmedidaswcgetfilterdata worker = new rubrosmedidasmedidaswcgetfilterdata(context);
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

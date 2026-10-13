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
   public class textoslistawcgetfilterdata : GXProcedure
   {
      public textoslistawcgetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public textoslistawcgetfilterdata( IGxContext context )
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
         new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWInventario", out  GXt_boolean1) ;
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
            if ( StringUtil.StrCmp(StringUtil.Upper( AV41DDOName), "DDO_RUBROSNOMBRE") == 0 )
            {
               /* Execute user subroutine: 'LOADRUBROSNOMBREOPTIONS' */
               S121 ();
               if ( returnInSub )
               {
                  cleanup();
                  if (true) return;
               }
            }
            else if ( StringUtil.StrCmp(StringUtil.Upper( AV41DDOName), "DDO_MEDIDASNOMBRE") == 0 )
            {
               /* Execute user subroutine: 'LOADMEDIDASNOMBREOPTIONS' */
               S131 ();
               if ( returnInSub )
               {
                  cleanup();
                  if (true) return;
               }
            }
            else if ( StringUtil.StrCmp(StringUtil.Upper( AV41DDOName), "DDO_TEXTOSTITULO") == 0 )
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
         AV44OptionsJson = AV31Options.ToJSonString(false);
         AV45OptionsDescJson = AV33OptionsDesc.ToJSonString(false);
         AV46OptionIndexesJson = AV34OptionIndexes.ToJSonString(false);
         cleanup();
      }

      protected void S111( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV36Session.Get("TextoslistaWCGridState"), "") == 0 )
         {
            AV38GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "TextoslistaWCGridState"), null, "", "");
         }
         else
         {
            AV38GridState.FromXml(AV36Session.Get("TextoslistaWCGridState"), null, "", "");
         }
         AV49GXV1 = 1;
         while ( AV49GXV1 <= AV38GridState.gxTpr_Filtervalues.Count )
         {
            AV39GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV38GridState.gxTpr_Filtervalues.Item(AV49GXV1));
            if ( StringUtil.StrCmp(AV39GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV47FilterFullText = AV39GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV39GridStateFilterValue.gxTpr_Name, "TFRUBROSID") == 0 )
            {
               AV11TFRubrosId = (short)(Math.Round(NumberUtil.Val( AV39GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV12TFRubrosId_To = (short)(Math.Round(NumberUtil.Val( AV39GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV39GridStateFilterValue.gxTpr_Name, "TFRUBROSNOMBRE") == 0 )
            {
               AV13TFRubrosNombre = AV39GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV39GridStateFilterValue.gxTpr_Name, "TFRUBROSNOMBRE_SEL") == 0 )
            {
               AV14TFRubrosNombre_Sel = AV39GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV39GridStateFilterValue.gxTpr_Name, "TFMEDIDASID") == 0 )
            {
               AV15TFMedidasID = (long)(Math.Round(NumberUtil.Val( AV39GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV16TFMedidasID_To = (long)(Math.Round(NumberUtil.Val( AV39GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV39GridStateFilterValue.gxTpr_Name, "TFMEDIDASNOMBRE") == 0 )
            {
               AV17TFMedidasNombre = AV39GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV39GridStateFilterValue.gxTpr_Name, "TFMEDIDASNOMBRE_SEL") == 0 )
            {
               AV18TFMedidasNombre_Sel = AV39GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV39GridStateFilterValue.gxTpr_Name, "TFMEDIDASESTADO_SEL") == 0 )
            {
               AV19TFMedidasEstado_SelsJson = AV39GridStateFilterValue.gxTpr_Value;
               AV20TFMedidasEstado_Sels.FromJSonString(AV19TFMedidasEstado_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV39GridStateFilterValue.gxTpr_Name, "TFTEXTOSID") == 0 )
            {
               AV21TFTextosId = (long)(Math.Round(NumberUtil.Val( AV39GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV22TFTextosId_To = (long)(Math.Round(NumberUtil.Val( AV39GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV39GridStateFilterValue.gxTpr_Name, "TFTEXTOSTITULO") == 0 )
            {
               AV23TFTextosTitulo = AV39GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV39GridStateFilterValue.gxTpr_Name, "TFTEXTOSTITULO_SEL") == 0 )
            {
               AV24TFTextosTitulo_Sel = AV39GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV39GridStateFilterValue.gxTpr_Name, "PARM_&INVENTARIOTEXTOSID") == 0 )
            {
               AV48InventarioTextosId = (long)(Math.Round(NumberUtil.Val( AV39GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
            }
            AV49GXV1 = (int)(AV49GXV1+1);
         }
      }

      protected void S121( )
      {
         /* 'LOADRUBROSNOMBREOPTIONS' Routine */
         returnInSub = false;
         AV13TFRubrosNombre = AV25SearchTxt;
         AV14TFRubrosNombre_Sel = "";
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A139MedidasEstado ,
                                              AV20TFMedidasEstado_Sels ,
                                              AV11TFRubrosId ,
                                              AV12TFRubrosId_To ,
                                              AV14TFRubrosNombre_Sel ,
                                              AV13TFRubrosNombre ,
                                              AV15TFMedidasID ,
                                              AV16TFMedidasID_To ,
                                              AV18TFMedidasNombre_Sel ,
                                              AV17TFMedidasNombre ,
                                              AV20TFMedidasEstado_Sels.Count ,
                                              AV21TFTextosId ,
                                              AV22TFTextosId_To ,
                                              AV24TFTextosTitulo_Sel ,
                                              AV23TFTextosTitulo ,
                                              A121RubrosId ,
                                              A122RubrosNombre ,
                                              A137MedidasID ,
                                              A138MedidasNombre ,
                                              A150TextosId ,
                                              A259TextosTitulo ,
                                              AV47FilterFullText ,
                                              AV48InventarioTextosId ,
                                              A535InventarioTextosId } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.INT, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.SHORT, TypeConstants.LONG,
                                              TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.BOOLEAN
                                              }
         });
         lV13TFRubrosNombre = StringUtil.PadR( StringUtil.RTrim( AV13TFRubrosNombre), 100, "%");
         lV17TFMedidasNombre = StringUtil.PadR( StringUtil.RTrim( AV17TFMedidasNombre), 50, "%");
         lV23TFTextosTitulo = StringUtil.PadR( StringUtil.RTrim( AV23TFTextosTitulo), 80, "%");
         /* Using cursor P00502 */
         pr_default.execute(0, new Object[] {AV48InventarioTextosId, AV11TFRubrosId, AV12TFRubrosId_To, lV13TFRubrosNombre, AV14TFRubrosNombre_Sel, AV15TFMedidasID, AV16TFMedidasID_To, lV17TFMedidasNombre, AV18TFMedidasNombre_Sel, AV21TFTextosId, AV22TFTextosId_To, lV23TFTextosTitulo, AV24TFTextosTitulo_Sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRK502 = false;
            A535InventarioTextosId = P00502_A535InventarioTextosId[0];
            n535InventarioTextosId = P00502_n535InventarioTextosId[0];
            A121RubrosId = P00502_A121RubrosId[0];
            A259TextosTitulo = P00502_A259TextosTitulo[0];
            A150TextosId = P00502_A150TextosId[0];
            n150TextosId = P00502_n150TextosId[0];
            A139MedidasEstado = P00502_A139MedidasEstado[0];
            n139MedidasEstado = P00502_n139MedidasEstado[0];
            A138MedidasNombre = P00502_A138MedidasNombre[0];
            A137MedidasID = P00502_A137MedidasID[0];
            A122RubrosNombre = P00502_A122RubrosNombre[0];
            A135InventarioId = P00502_A135InventarioId[0];
            A122RubrosNombre = P00502_A122RubrosNombre[0];
            A150TextosId = P00502_A150TextosId[0];
            n150TextosId = P00502_n150TextosId[0];
            A139MedidasEstado = P00502_A139MedidasEstado[0];
            n139MedidasEstado = P00502_n139MedidasEstado[0];
            A138MedidasNombre = P00502_A138MedidasNombre[0];
            A259TextosTitulo = P00502_A259TextosTitulo[0];
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV47FilterFullText)) || ( ( StringUtil.Like( StringUtil.Str( (decimal)(A121RubrosId), 4, 0) , StringUtil.PadR( "%" + AV47FilterFullText , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A122RubrosNombre) , StringUtil.PadR( "%" + StringUtil.Upper( AV47FilterFullText) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Str( (decimal)(A137MedidasID), 18, 0) , StringUtil.PadR( "%" + AV47FilterFullText , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A138MedidasNombre) , StringUtil.PadR( "%" + StringUtil.Upper( AV47FilterFullText) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( context.GetMessage( "habilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV47FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A139MedidasEstado, "HAB") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "deshabilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV47FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A139MedidasEstado, "DES") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "pendiente", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV47FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A139MedidasEstado, "PEN") == 0 ) ) || ( StringUtil.Like( StringUtil.Str( (decimal)(A150TextosId), 18, 0) , StringUtil.PadR( "%" + AV47FilterFullText , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A259TextosTitulo) , StringUtil.PadR( "%" + StringUtil.Upper( AV47FilterFullText) , 255 , "%"),  ' ' ) ) ) )
            {
               AV35count = 0;
               while ( (pr_default.getStatus(0) != 101) && ( P00502_A535InventarioTextosId[0] == A535InventarioTextosId ) && ( P00502_A121RubrosId[0] == A121RubrosId ) )
               {
                  BRK502 = false;
                  A137MedidasID = P00502_A137MedidasID[0];
                  A135InventarioId = P00502_A135InventarioId[0];
                  AV35count = (long)(AV35count+1);
                  BRK502 = true;
                  pr_default.readNext(0);
               }
               AV30Option = (String.IsNullOrEmpty(StringUtil.RTrim( A122RubrosNombre)) ? "<#Empty#>" : A122RubrosNombre);
               AV29InsertIndex = 1;
               while ( ( StringUtil.StrCmp(AV30Option, "<#Empty#>") != 0 ) && ( AV29InsertIndex <= AV31Options.Count ) && ( ( StringUtil.StrCmp(((string)AV31Options.Item(AV29InsertIndex)), AV30Option) < 0 ) || ( StringUtil.StrCmp(((string)AV31Options.Item(AV29InsertIndex)), "<#Empty#>") == 0 ) ) )
               {
                  AV29InsertIndex = (int)(AV29InsertIndex+1);
               }
               AV31Options.Add(AV30Option, AV29InsertIndex);
               AV34OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV35count), "Z,ZZZ,ZZZ,ZZ9")), AV29InsertIndex);
               if ( AV31Options.Count == AV26SkipItems + 11 )
               {
                  AV31Options.RemoveItem(AV31Options.Count);
                  AV34OptionIndexes.RemoveItem(AV34OptionIndexes.Count);
               }
            }
            if ( ! BRK502 )
            {
               BRK502 = true;
               pr_default.readNext(0);
            }
         }
         pr_default.close(0);
         while ( AV26SkipItems > 0 )
         {
            AV31Options.RemoveItem(1);
            AV34OptionIndexes.RemoveItem(1);
            AV26SkipItems = (short)(AV26SkipItems-1);
         }
      }

      protected void S131( )
      {
         /* 'LOADMEDIDASNOMBREOPTIONS' Routine */
         returnInSub = false;
         AV17TFMedidasNombre = AV25SearchTxt;
         AV18TFMedidasNombre_Sel = "";
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              A139MedidasEstado ,
                                              AV20TFMedidasEstado_Sels ,
                                              AV11TFRubrosId ,
                                              AV12TFRubrosId_To ,
                                              AV14TFRubrosNombre_Sel ,
                                              AV13TFRubrosNombre ,
                                              AV15TFMedidasID ,
                                              AV16TFMedidasID_To ,
                                              AV18TFMedidasNombre_Sel ,
                                              AV17TFMedidasNombre ,
                                              AV20TFMedidasEstado_Sels.Count ,
                                              AV21TFTextosId ,
                                              AV22TFTextosId_To ,
                                              AV24TFTextosTitulo_Sel ,
                                              AV23TFTextosTitulo ,
                                              A121RubrosId ,
                                              A122RubrosNombre ,
                                              A137MedidasID ,
                                              A138MedidasNombre ,
                                              A150TextosId ,
                                              A259TextosTitulo ,
                                              AV47FilterFullText ,
                                              AV48InventarioTextosId ,
                                              A535InventarioTextosId } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.INT, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.SHORT, TypeConstants.LONG,
                                              TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.BOOLEAN
                                              }
         });
         lV13TFRubrosNombre = StringUtil.PadR( StringUtil.RTrim( AV13TFRubrosNombre), 100, "%");
         lV17TFMedidasNombre = StringUtil.PadR( StringUtil.RTrim( AV17TFMedidasNombre), 50, "%");
         lV23TFTextosTitulo = StringUtil.PadR( StringUtil.RTrim( AV23TFTextosTitulo), 80, "%");
         /* Using cursor P00503 */
         pr_default.execute(1, new Object[] {AV48InventarioTextosId, AV11TFRubrosId, AV12TFRubrosId_To, lV13TFRubrosNombre, AV14TFRubrosNombre_Sel, AV15TFMedidasID, AV16TFMedidasID_To, lV17TFMedidasNombre, AV18TFMedidasNombre_Sel, AV21TFTextosId, AV22TFTextosId_To, lV23TFTextosTitulo, AV24TFTextosTitulo_Sel});
         while ( (pr_default.getStatus(1) != 101) )
         {
            BRK504 = false;
            A535InventarioTextosId = P00503_A535InventarioTextosId[0];
            n535InventarioTextosId = P00503_n535InventarioTextosId[0];
            A138MedidasNombre = P00503_A138MedidasNombre[0];
            A259TextosTitulo = P00503_A259TextosTitulo[0];
            A150TextosId = P00503_A150TextosId[0];
            n150TextosId = P00503_n150TextosId[0];
            A139MedidasEstado = P00503_A139MedidasEstado[0];
            n139MedidasEstado = P00503_n139MedidasEstado[0];
            A137MedidasID = P00503_A137MedidasID[0];
            A122RubrosNombre = P00503_A122RubrosNombre[0];
            A121RubrosId = P00503_A121RubrosId[0];
            A135InventarioId = P00503_A135InventarioId[0];
            A122RubrosNombre = P00503_A122RubrosNombre[0];
            A138MedidasNombre = P00503_A138MedidasNombre[0];
            A150TextosId = P00503_A150TextosId[0];
            n150TextosId = P00503_n150TextosId[0];
            A139MedidasEstado = P00503_A139MedidasEstado[0];
            n139MedidasEstado = P00503_n139MedidasEstado[0];
            A259TextosTitulo = P00503_A259TextosTitulo[0];
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV47FilterFullText)) || ( ( StringUtil.Like( StringUtil.Str( (decimal)(A121RubrosId), 4, 0) , StringUtil.PadR( "%" + AV47FilterFullText , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A122RubrosNombre) , StringUtil.PadR( "%" + StringUtil.Upper( AV47FilterFullText) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Str( (decimal)(A137MedidasID), 18, 0) , StringUtil.PadR( "%" + AV47FilterFullText , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A138MedidasNombre) , StringUtil.PadR( "%" + StringUtil.Upper( AV47FilterFullText) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( context.GetMessage( "habilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV47FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A139MedidasEstado, "HAB") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "deshabilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV47FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A139MedidasEstado, "DES") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "pendiente", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV47FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A139MedidasEstado, "PEN") == 0 ) ) || ( StringUtil.Like( StringUtil.Str( (decimal)(A150TextosId), 18, 0) , StringUtil.PadR( "%" + AV47FilterFullText , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A259TextosTitulo) , StringUtil.PadR( "%" + StringUtil.Upper( AV47FilterFullText) , 255 , "%"),  ' ' ) ) ) )
            {
               AV35count = 0;
               while ( (pr_default.getStatus(1) != 101) && ( P00503_A535InventarioTextosId[0] == A535InventarioTextosId ) && ( StringUtil.StrCmp(P00503_A138MedidasNombre[0], A138MedidasNombre) == 0 ) )
               {
                  BRK504 = false;
                  A137MedidasID = P00503_A137MedidasID[0];
                  A121RubrosId = P00503_A121RubrosId[0];
                  A135InventarioId = P00503_A135InventarioId[0];
                  AV35count = (long)(AV35count+1);
                  BRK504 = true;
                  pr_default.readNext(1);
               }
               if ( (0==AV26SkipItems) )
               {
                  AV30Option = (String.IsNullOrEmpty(StringUtil.RTrim( A138MedidasNombre)) ? "<#Empty#>" : A138MedidasNombre);
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
            }
            if ( ! BRK504 )
            {
               BRK504 = true;
               pr_default.readNext(1);
            }
         }
         pr_default.close(1);
      }

      protected void S141( )
      {
         /* 'LOADTEXTOSTITULOOPTIONS' Routine */
         returnInSub = false;
         AV23TFTextosTitulo = AV25SearchTxt;
         AV24TFTextosTitulo_Sel = "";
         pr_default.dynParam(2, new Object[]{ new Object[]{
                                              A139MedidasEstado ,
                                              AV20TFMedidasEstado_Sels ,
                                              AV11TFRubrosId ,
                                              AV12TFRubrosId_To ,
                                              AV14TFRubrosNombre_Sel ,
                                              AV13TFRubrosNombre ,
                                              AV15TFMedidasID ,
                                              AV16TFMedidasID_To ,
                                              AV18TFMedidasNombre_Sel ,
                                              AV17TFMedidasNombre ,
                                              AV20TFMedidasEstado_Sels.Count ,
                                              AV21TFTextosId ,
                                              AV22TFTextosId_To ,
                                              AV24TFTextosTitulo_Sel ,
                                              AV23TFTextosTitulo ,
                                              A121RubrosId ,
                                              A122RubrosNombre ,
                                              A137MedidasID ,
                                              A138MedidasNombre ,
                                              A150TextosId ,
                                              A259TextosTitulo ,
                                              AV47FilterFullText ,
                                              AV48InventarioTextosId ,
                                              A535InventarioTextosId } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.INT, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.SHORT, TypeConstants.LONG,
                                              TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.BOOLEAN
                                              }
         });
         lV13TFRubrosNombre = StringUtil.PadR( StringUtil.RTrim( AV13TFRubrosNombre), 100, "%");
         lV17TFMedidasNombre = StringUtil.PadR( StringUtil.RTrim( AV17TFMedidasNombre), 50, "%");
         lV23TFTextosTitulo = StringUtil.PadR( StringUtil.RTrim( AV23TFTextosTitulo), 80, "%");
         /* Using cursor P00504 */
         pr_default.execute(2, new Object[] {AV48InventarioTextosId, AV11TFRubrosId, AV12TFRubrosId_To, lV13TFRubrosNombre, AV14TFRubrosNombre_Sel, AV15TFMedidasID, AV16TFMedidasID_To, lV17TFMedidasNombre, AV18TFMedidasNombre_Sel, AV21TFTextosId, AV22TFTextosId_To, lV23TFTextosTitulo, AV24TFTextosTitulo_Sel});
         while ( (pr_default.getStatus(2) != 101) )
         {
            BRK506 = false;
            A535InventarioTextosId = P00504_A535InventarioTextosId[0];
            n535InventarioTextosId = P00504_n535InventarioTextosId[0];
            A259TextosTitulo = P00504_A259TextosTitulo[0];
            A150TextosId = P00504_A150TextosId[0];
            n150TextosId = P00504_n150TextosId[0];
            A139MedidasEstado = P00504_A139MedidasEstado[0];
            n139MedidasEstado = P00504_n139MedidasEstado[0];
            A138MedidasNombre = P00504_A138MedidasNombre[0];
            A137MedidasID = P00504_A137MedidasID[0];
            A122RubrosNombre = P00504_A122RubrosNombre[0];
            A121RubrosId = P00504_A121RubrosId[0];
            A135InventarioId = P00504_A135InventarioId[0];
            A122RubrosNombre = P00504_A122RubrosNombre[0];
            A150TextosId = P00504_A150TextosId[0];
            n150TextosId = P00504_n150TextosId[0];
            A139MedidasEstado = P00504_A139MedidasEstado[0];
            n139MedidasEstado = P00504_n139MedidasEstado[0];
            A138MedidasNombre = P00504_A138MedidasNombre[0];
            A259TextosTitulo = P00504_A259TextosTitulo[0];
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV47FilterFullText)) || ( ( StringUtil.Like( StringUtil.Str( (decimal)(A121RubrosId), 4, 0) , StringUtil.PadR( "%" + AV47FilterFullText , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A122RubrosNombre) , StringUtil.PadR( "%" + StringUtil.Upper( AV47FilterFullText) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Str( (decimal)(A137MedidasID), 18, 0) , StringUtil.PadR( "%" + AV47FilterFullText , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A138MedidasNombre) , StringUtil.PadR( "%" + StringUtil.Upper( AV47FilterFullText) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( context.GetMessage( "habilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV47FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A139MedidasEstado, "HAB") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "deshabilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV47FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A139MedidasEstado, "DES") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "pendiente", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV47FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A139MedidasEstado, "PEN") == 0 ) ) || ( StringUtil.Like( StringUtil.Str( (decimal)(A150TextosId), 18, 0) , StringUtil.PadR( "%" + AV47FilterFullText , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A259TextosTitulo) , StringUtil.PadR( "%" + StringUtil.Upper( AV47FilterFullText) , 255 , "%"),  ' ' ) ) ) )
            {
               AV35count = 0;
               while ( (pr_default.getStatus(2) != 101) && ( P00504_A535InventarioTextosId[0] == A535InventarioTextosId ) && ( StringUtil.StrCmp(P00504_A259TextosTitulo[0], A259TextosTitulo) == 0 ) )
               {
                  BRK506 = false;
                  A150TextosId = P00504_A150TextosId[0];
                  n150TextosId = P00504_n150TextosId[0];
                  A137MedidasID = P00504_A137MedidasID[0];
                  A121RubrosId = P00504_A121RubrosId[0];
                  A135InventarioId = P00504_A135InventarioId[0];
                  A150TextosId = P00504_A150TextosId[0];
                  n150TextosId = P00504_n150TextosId[0];
                  AV35count = (long)(AV35count+1);
                  BRK506 = true;
                  pr_default.readNext(2);
               }
               if ( (0==AV26SkipItems) )
               {
                  AV30Option = (String.IsNullOrEmpty(StringUtil.RTrim( A259TextosTitulo)) ? "<#Empty#>" : A259TextosTitulo);
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
            }
            if ( ! BRK506 )
            {
               BRK506 = true;
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
         AV47FilterFullText = "";
         AV13TFRubrosNombre = "";
         AV14TFRubrosNombre_Sel = "";
         AV17TFMedidasNombre = "";
         AV18TFMedidasNombre_Sel = "";
         AV19TFMedidasEstado_SelsJson = "";
         AV20TFMedidasEstado_Sels = new GxSimpleCollection<string>();
         AV23TFTextosTitulo = "";
         AV24TFTextosTitulo_Sel = "";
         lV47FilterFullText = "";
         lV13TFRubrosNombre = "";
         lV17TFMedidasNombre = "";
         lV23TFTextosTitulo = "";
         A139MedidasEstado = "";
         A122RubrosNombre = "";
         A138MedidasNombre = "";
         A259TextosTitulo = "";
         P00502_A535InventarioTextosId = new long[1] ;
         P00502_n535InventarioTextosId = new bool[] {false} ;
         P00502_A121RubrosId = new short[1] ;
         P00502_A259TextosTitulo = new string[] {""} ;
         P00502_A150TextosId = new long[1] ;
         P00502_n150TextosId = new bool[] {false} ;
         P00502_A139MedidasEstado = new string[] {""} ;
         P00502_n139MedidasEstado = new bool[] {false} ;
         P00502_A138MedidasNombre = new string[] {""} ;
         P00502_A137MedidasID = new long[1] ;
         P00502_A122RubrosNombre = new string[] {""} ;
         P00502_A135InventarioId = new long[1] ;
         AV30Option = "";
         P00503_A535InventarioTextosId = new long[1] ;
         P00503_n535InventarioTextosId = new bool[] {false} ;
         P00503_A138MedidasNombre = new string[] {""} ;
         P00503_A259TextosTitulo = new string[] {""} ;
         P00503_A150TextosId = new long[1] ;
         P00503_n150TextosId = new bool[] {false} ;
         P00503_A139MedidasEstado = new string[] {""} ;
         P00503_n139MedidasEstado = new bool[] {false} ;
         P00503_A137MedidasID = new long[1] ;
         P00503_A122RubrosNombre = new string[] {""} ;
         P00503_A121RubrosId = new short[1] ;
         P00503_A135InventarioId = new long[1] ;
         P00504_A535InventarioTextosId = new long[1] ;
         P00504_n535InventarioTextosId = new bool[] {false} ;
         P00504_A259TextosTitulo = new string[] {""} ;
         P00504_A150TextosId = new long[1] ;
         P00504_n150TextosId = new bool[] {false} ;
         P00504_A139MedidasEstado = new string[] {""} ;
         P00504_n139MedidasEstado = new bool[] {false} ;
         P00504_A138MedidasNombre = new string[] {""} ;
         P00504_A137MedidasID = new long[1] ;
         P00504_A122RubrosNombre = new string[] {""} ;
         P00504_A121RubrosId = new short[1] ;
         P00504_A135InventarioId = new long[1] ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.textoslistawcgetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P00502_A535InventarioTextosId, P00502_n535InventarioTextosId, P00502_A121RubrosId, P00502_A259TextosTitulo, P00502_A150TextosId, P00502_n150TextosId, P00502_A139MedidasEstado, P00502_n139MedidasEstado, P00502_A138MedidasNombre, P00502_A137MedidasID,
               P00502_A122RubrosNombre, P00502_A135InventarioId
               }
               , new Object[] {
               P00503_A535InventarioTextosId, P00503_n535InventarioTextosId, P00503_A138MedidasNombre, P00503_A259TextosTitulo, P00503_A150TextosId, P00503_n150TextosId, P00503_A139MedidasEstado, P00503_n139MedidasEstado, P00503_A137MedidasID, P00503_A122RubrosNombre,
               P00503_A121RubrosId, P00503_A135InventarioId
               }
               , new Object[] {
               P00504_A535InventarioTextosId, P00504_n535InventarioTextosId, P00504_A259TextosTitulo, P00504_A150TextosId, P00504_n150TextosId, P00504_A139MedidasEstado, P00504_n139MedidasEstado, P00504_A138MedidasNombre, P00504_A137MedidasID, P00504_A122RubrosNombre,
               P00504_A121RubrosId, P00504_A135InventarioId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV28MaxItems ;
      private short AV27PageIndex ;
      private short AV26SkipItems ;
      private short AV11TFRubrosId ;
      private short AV12TFRubrosId_To ;
      private short A121RubrosId ;
      private int AV49GXV1 ;
      private int AV20TFMedidasEstado_Sels_Count ;
      private int AV29InsertIndex ;
      private long AV15TFMedidasID ;
      private long AV16TFMedidasID_To ;
      private long AV21TFTextosId ;
      private long AV22TFTextosId_To ;
      private long AV48InventarioTextosId ;
      private long A137MedidasID ;
      private long A150TextosId ;
      private long A535InventarioTextosId ;
      private long A135InventarioId ;
      private long AV35count ;
      private string AV13TFRubrosNombre ;
      private string AV14TFRubrosNombre_Sel ;
      private string AV17TFMedidasNombre ;
      private string AV18TFMedidasNombre_Sel ;
      private string AV23TFTextosTitulo ;
      private string AV24TFTextosTitulo_Sel ;
      private string lV13TFRubrosNombre ;
      private string lV17TFMedidasNombre ;
      private string lV23TFTextosTitulo ;
      private string A139MedidasEstado ;
      private string A122RubrosNombre ;
      private string A138MedidasNombre ;
      private string A259TextosTitulo ;
      private bool AV8IsAuthorized ;
      private bool GXt_boolean1 ;
      private bool returnInSub ;
      private bool BRK502 ;
      private bool n535InventarioTextosId ;
      private bool n150TextosId ;
      private bool n139MedidasEstado ;
      private bool BRK504 ;
      private bool BRK506 ;
      private string AV44OptionsJson ;
      private string AV45OptionsDescJson ;
      private string AV46OptionIndexesJson ;
      private string AV19TFMedidasEstado_SelsJson ;
      private string AV41DDOName ;
      private string AV42SearchTxtParms ;
      private string AV43SearchTxtTo ;
      private string AV25SearchTxt ;
      private string AV47FilterFullText ;
      private string lV47FilterFullText ;
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
      private GxSimpleCollection<string> AV20TFMedidasEstado_Sels ;
      private IDataStoreProvider pr_default ;
      private long[] P00502_A535InventarioTextosId ;
      private bool[] P00502_n535InventarioTextosId ;
      private short[] P00502_A121RubrosId ;
      private string[] P00502_A259TextosTitulo ;
      private long[] P00502_A150TextosId ;
      private bool[] P00502_n150TextosId ;
      private string[] P00502_A139MedidasEstado ;
      private bool[] P00502_n139MedidasEstado ;
      private string[] P00502_A138MedidasNombre ;
      private long[] P00502_A137MedidasID ;
      private string[] P00502_A122RubrosNombre ;
      private long[] P00502_A135InventarioId ;
      private long[] P00503_A535InventarioTextosId ;
      private bool[] P00503_n535InventarioTextosId ;
      private string[] P00503_A138MedidasNombre ;
      private string[] P00503_A259TextosTitulo ;
      private long[] P00503_A150TextosId ;
      private bool[] P00503_n150TextosId ;
      private string[] P00503_A139MedidasEstado ;
      private bool[] P00503_n139MedidasEstado ;
      private long[] P00503_A137MedidasID ;
      private string[] P00503_A122RubrosNombre ;
      private short[] P00503_A121RubrosId ;
      private long[] P00503_A135InventarioId ;
      private long[] P00504_A535InventarioTextosId ;
      private bool[] P00504_n535InventarioTextosId ;
      private string[] P00504_A259TextosTitulo ;
      private long[] P00504_A150TextosId ;
      private bool[] P00504_n150TextosId ;
      private string[] P00504_A139MedidasEstado ;
      private bool[] P00504_n139MedidasEstado ;
      private string[] P00504_A138MedidasNombre ;
      private long[] P00504_A137MedidasID ;
      private string[] P00504_A122RubrosNombre ;
      private short[] P00504_A121RubrosId ;
      private long[] P00504_A135InventarioId ;
      private string aP3_OptionsJson ;
      private string aP4_OptionsDescJson ;
      private string aP5_OptionIndexesJson ;
   }

   public class textoslistawcgetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00502( IGxContext context ,
                                             string A139MedidasEstado ,
                                             GxSimpleCollection<string> AV20TFMedidasEstado_Sels ,
                                             short AV11TFRubrosId ,
                                             short AV12TFRubrosId_To ,
                                             string AV14TFRubrosNombre_Sel ,
                                             string AV13TFRubrosNombre ,
                                             long AV15TFMedidasID ,
                                             long AV16TFMedidasID_To ,
                                             string AV18TFMedidasNombre_Sel ,
                                             string AV17TFMedidasNombre ,
                                             int AV20TFMedidasEstado_Sels_Count ,
                                             long AV21TFTextosId ,
                                             long AV22TFTextosId_To ,
                                             string AV24TFTextosTitulo_Sel ,
                                             string AV23TFTextosTitulo ,
                                             short A121RubrosId ,
                                             string A122RubrosNombre ,
                                             long A137MedidasID ,
                                             string A138MedidasNombre ,
                                             long A150TextosId ,
                                             string A259TextosTitulo ,
                                             string AV47FilterFullText ,
                                             long AV48InventarioTextosId ,
                                             long A535InventarioTextosId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int2 = new short[13];
         Object[] GXv_Object3 = new Object[2];
         scmdbuf = "SELECT T1.[InventarioTextosId], T1.[RubrosId], T4.[TextosTitulo], T3.[TextosId], T3.[MedidasEstado], T3.[MedidasNombre], T1.[MedidasID], T2.[RubrosNombre], T1.[InventarioId] FROM ((([Inventario] T1 INNER JOIN [Rubros] T2 ON T2.[RubrosId] = T1.[RubrosId]) INNER JOIN [RubrosMedidas] T3 ON T3.[RubrosId] = T1.[RubrosId] AND T3.[MedidasID] = T1.[MedidasID]) LEFT JOIN [Textos] T4 ON T4.[TextosId] = T3.[TextosId])";
         AddWhere(sWhereString, "(T1.[InventarioTextosId] = @AV48InventarioTextosId)");
         if ( ! (0==AV11TFRubrosId) )
         {
            AddWhere(sWhereString, "(T1.[RubrosId] >= @AV11TFRubrosId)");
         }
         else
         {
            GXv_int2[1] = 1;
         }
         if ( ! (0==AV12TFRubrosId_To) )
         {
            AddWhere(sWhereString, "(T1.[RubrosId] <= @AV12TFRubrosId_To)");
         }
         else
         {
            GXv_int2[2] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV14TFRubrosNombre_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV13TFRubrosNombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[RubrosNombre]) like UPPER(@lV13TFRubrosNombre))");
         }
         else
         {
            GXv_int2[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV14TFRubrosNombre_Sel)) && ! ( StringUtil.StrCmp(AV14TFRubrosNombre_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.[RubrosNombre] = @AV14TFRubrosNombre_Sel)");
         }
         else
         {
            GXv_int2[4] = 1;
         }
         if ( StringUtil.StrCmp(AV14TFRubrosNombre_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T2.[RubrosNombre] = ''))");
         }
         if ( ! (0==AV15TFMedidasID) )
         {
            AddWhere(sWhereString, "(T1.[MedidasID] >= @AV15TFMedidasID)");
         }
         else
         {
            GXv_int2[5] = 1;
         }
         if ( ! (0==AV16TFMedidasID_To) )
         {
            AddWhere(sWhereString, "(T1.[MedidasID] <= @AV16TFMedidasID_To)");
         }
         else
         {
            GXv_int2[6] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV18TFMedidasNombre_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV17TFMedidasNombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T3.[MedidasNombre]) like UPPER(@lV17TFMedidasNombre))");
         }
         else
         {
            GXv_int2[7] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV18TFMedidasNombre_Sel)) && ! ( StringUtil.StrCmp(AV18TFMedidasNombre_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T3.[MedidasNombre] = @AV18TFMedidasNombre_Sel)");
         }
         else
         {
            GXv_int2[8] = 1;
         }
         if ( StringUtil.StrCmp(AV18TFMedidasNombre_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T3.[MedidasNombre] = ''))");
         }
         if ( AV20TFMedidasEstado_Sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV20TFMedidasEstado_Sels, "T3.[MedidasEstado] IN (", ")")+")");
         }
         if ( ! (0==AV21TFTextosId) )
         {
            AddWhere(sWhereString, "(T3.[TextosId] >= @AV21TFTextosId)");
         }
         else
         {
            GXv_int2[9] = 1;
         }
         if ( ! (0==AV22TFTextosId_To) )
         {
            AddWhere(sWhereString, "(T3.[TextosId] <= @AV22TFTextosId_To)");
         }
         else
         {
            GXv_int2[10] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV24TFTextosTitulo_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV23TFTextosTitulo)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T4.[TextosTitulo]) like UPPER(@lV23TFTextosTitulo))");
         }
         else
         {
            GXv_int2[11] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV24TFTextosTitulo_Sel)) && ! ( StringUtil.StrCmp(AV24TFTextosTitulo_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T4.[TextosTitulo] = @AV24TFTextosTitulo_Sel)");
         }
         else
         {
            GXv_int2[12] = 1;
         }
         if ( StringUtil.StrCmp(AV24TFTextosTitulo_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T4.[TextosTitulo] IS NULL or (T4.[TextosTitulo] = ''))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[InventarioTextosId], T1.[RubrosId]";
         GXv_Object3[0] = scmdbuf;
         GXv_Object3[1] = GXv_int2;
         return GXv_Object3 ;
      }

      protected Object[] conditional_P00503( IGxContext context ,
                                             string A139MedidasEstado ,
                                             GxSimpleCollection<string> AV20TFMedidasEstado_Sels ,
                                             short AV11TFRubrosId ,
                                             short AV12TFRubrosId_To ,
                                             string AV14TFRubrosNombre_Sel ,
                                             string AV13TFRubrosNombre ,
                                             long AV15TFMedidasID ,
                                             long AV16TFMedidasID_To ,
                                             string AV18TFMedidasNombre_Sel ,
                                             string AV17TFMedidasNombre ,
                                             int AV20TFMedidasEstado_Sels_Count ,
                                             long AV21TFTextosId ,
                                             long AV22TFTextosId_To ,
                                             string AV24TFTextosTitulo_Sel ,
                                             string AV23TFTextosTitulo ,
                                             short A121RubrosId ,
                                             string A122RubrosNombre ,
                                             long A137MedidasID ,
                                             string A138MedidasNombre ,
                                             long A150TextosId ,
                                             string A259TextosTitulo ,
                                             string AV47FilterFullText ,
                                             long AV48InventarioTextosId ,
                                             long A535InventarioTextosId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int4 = new short[13];
         Object[] GXv_Object5 = new Object[2];
         scmdbuf = "SELECT T1.[InventarioTextosId], T3.[MedidasNombre], T4.[TextosTitulo], T3.[TextosId], T3.[MedidasEstado], T1.[MedidasID], T2.[RubrosNombre], T1.[RubrosId], T1.[InventarioId] FROM ((([Inventario] T1 INNER JOIN [Rubros] T2 ON T2.[RubrosId] = T1.[RubrosId]) INNER JOIN [RubrosMedidas] T3 ON T3.[RubrosId] = T1.[RubrosId] AND T3.[MedidasID] = T1.[MedidasID]) LEFT JOIN [Textos] T4 ON T4.[TextosId] = T3.[TextosId])";
         AddWhere(sWhereString, "(T1.[InventarioTextosId] = @AV48InventarioTextosId)");
         if ( ! (0==AV11TFRubrosId) )
         {
            AddWhere(sWhereString, "(T1.[RubrosId] >= @AV11TFRubrosId)");
         }
         else
         {
            GXv_int4[1] = 1;
         }
         if ( ! (0==AV12TFRubrosId_To) )
         {
            AddWhere(sWhereString, "(T1.[RubrosId] <= @AV12TFRubrosId_To)");
         }
         else
         {
            GXv_int4[2] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV14TFRubrosNombre_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV13TFRubrosNombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[RubrosNombre]) like UPPER(@lV13TFRubrosNombre))");
         }
         else
         {
            GXv_int4[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV14TFRubrosNombre_Sel)) && ! ( StringUtil.StrCmp(AV14TFRubrosNombre_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.[RubrosNombre] = @AV14TFRubrosNombre_Sel)");
         }
         else
         {
            GXv_int4[4] = 1;
         }
         if ( StringUtil.StrCmp(AV14TFRubrosNombre_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T2.[RubrosNombre] = ''))");
         }
         if ( ! (0==AV15TFMedidasID) )
         {
            AddWhere(sWhereString, "(T1.[MedidasID] >= @AV15TFMedidasID)");
         }
         else
         {
            GXv_int4[5] = 1;
         }
         if ( ! (0==AV16TFMedidasID_To) )
         {
            AddWhere(sWhereString, "(T1.[MedidasID] <= @AV16TFMedidasID_To)");
         }
         else
         {
            GXv_int4[6] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV18TFMedidasNombre_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV17TFMedidasNombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T3.[MedidasNombre]) like UPPER(@lV17TFMedidasNombre))");
         }
         else
         {
            GXv_int4[7] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV18TFMedidasNombre_Sel)) && ! ( StringUtil.StrCmp(AV18TFMedidasNombre_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T3.[MedidasNombre] = @AV18TFMedidasNombre_Sel)");
         }
         else
         {
            GXv_int4[8] = 1;
         }
         if ( StringUtil.StrCmp(AV18TFMedidasNombre_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T3.[MedidasNombre] = ''))");
         }
         if ( AV20TFMedidasEstado_Sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV20TFMedidasEstado_Sels, "T3.[MedidasEstado] IN (", ")")+")");
         }
         if ( ! (0==AV21TFTextosId) )
         {
            AddWhere(sWhereString, "(T3.[TextosId] >= @AV21TFTextosId)");
         }
         else
         {
            GXv_int4[9] = 1;
         }
         if ( ! (0==AV22TFTextosId_To) )
         {
            AddWhere(sWhereString, "(T3.[TextosId] <= @AV22TFTextosId_To)");
         }
         else
         {
            GXv_int4[10] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV24TFTextosTitulo_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV23TFTextosTitulo)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T4.[TextosTitulo]) like UPPER(@lV23TFTextosTitulo))");
         }
         else
         {
            GXv_int4[11] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV24TFTextosTitulo_Sel)) && ! ( StringUtil.StrCmp(AV24TFTextosTitulo_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T4.[TextosTitulo] = @AV24TFTextosTitulo_Sel)");
         }
         else
         {
            GXv_int4[12] = 1;
         }
         if ( StringUtil.StrCmp(AV24TFTextosTitulo_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T4.[TextosTitulo] IS NULL or (T4.[TextosTitulo] = ''))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[InventarioTextosId], T3.[MedidasNombre]";
         GXv_Object5[0] = scmdbuf;
         GXv_Object5[1] = GXv_int4;
         return GXv_Object5 ;
      }

      protected Object[] conditional_P00504( IGxContext context ,
                                             string A139MedidasEstado ,
                                             GxSimpleCollection<string> AV20TFMedidasEstado_Sels ,
                                             short AV11TFRubrosId ,
                                             short AV12TFRubrosId_To ,
                                             string AV14TFRubrosNombre_Sel ,
                                             string AV13TFRubrosNombre ,
                                             long AV15TFMedidasID ,
                                             long AV16TFMedidasID_To ,
                                             string AV18TFMedidasNombre_Sel ,
                                             string AV17TFMedidasNombre ,
                                             int AV20TFMedidasEstado_Sels_Count ,
                                             long AV21TFTextosId ,
                                             long AV22TFTextosId_To ,
                                             string AV24TFTextosTitulo_Sel ,
                                             string AV23TFTextosTitulo ,
                                             short A121RubrosId ,
                                             string A122RubrosNombre ,
                                             long A137MedidasID ,
                                             string A138MedidasNombre ,
                                             long A150TextosId ,
                                             string A259TextosTitulo ,
                                             string AV47FilterFullText ,
                                             long AV48InventarioTextosId ,
                                             long A535InventarioTextosId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int6 = new short[13];
         Object[] GXv_Object7 = new Object[2];
         scmdbuf = "SELECT T1.[InventarioTextosId], T4.[TextosTitulo], T3.[TextosId], T3.[MedidasEstado], T3.[MedidasNombre], T1.[MedidasID], T2.[RubrosNombre], T1.[RubrosId], T1.[InventarioId] FROM ((([Inventario] T1 INNER JOIN [Rubros] T2 ON T2.[RubrosId] = T1.[RubrosId]) INNER JOIN [RubrosMedidas] T3 ON T3.[RubrosId] = T1.[RubrosId] AND T3.[MedidasID] = T1.[MedidasID]) LEFT JOIN [Textos] T4 ON T4.[TextosId] = T3.[TextosId])";
         AddWhere(sWhereString, "(T1.[InventarioTextosId] = @AV48InventarioTextosId)");
         if ( ! (0==AV11TFRubrosId) )
         {
            AddWhere(sWhereString, "(T1.[RubrosId] >= @AV11TFRubrosId)");
         }
         else
         {
            GXv_int6[1] = 1;
         }
         if ( ! (0==AV12TFRubrosId_To) )
         {
            AddWhere(sWhereString, "(T1.[RubrosId] <= @AV12TFRubrosId_To)");
         }
         else
         {
            GXv_int6[2] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV14TFRubrosNombre_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV13TFRubrosNombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[RubrosNombre]) like UPPER(@lV13TFRubrosNombre))");
         }
         else
         {
            GXv_int6[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV14TFRubrosNombre_Sel)) && ! ( StringUtil.StrCmp(AV14TFRubrosNombre_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.[RubrosNombre] = @AV14TFRubrosNombre_Sel)");
         }
         else
         {
            GXv_int6[4] = 1;
         }
         if ( StringUtil.StrCmp(AV14TFRubrosNombre_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T2.[RubrosNombre] = ''))");
         }
         if ( ! (0==AV15TFMedidasID) )
         {
            AddWhere(sWhereString, "(T1.[MedidasID] >= @AV15TFMedidasID)");
         }
         else
         {
            GXv_int6[5] = 1;
         }
         if ( ! (0==AV16TFMedidasID_To) )
         {
            AddWhere(sWhereString, "(T1.[MedidasID] <= @AV16TFMedidasID_To)");
         }
         else
         {
            GXv_int6[6] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV18TFMedidasNombre_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV17TFMedidasNombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T3.[MedidasNombre]) like UPPER(@lV17TFMedidasNombre))");
         }
         else
         {
            GXv_int6[7] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV18TFMedidasNombre_Sel)) && ! ( StringUtil.StrCmp(AV18TFMedidasNombre_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T3.[MedidasNombre] = @AV18TFMedidasNombre_Sel)");
         }
         else
         {
            GXv_int6[8] = 1;
         }
         if ( StringUtil.StrCmp(AV18TFMedidasNombre_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T3.[MedidasNombre] = ''))");
         }
         if ( AV20TFMedidasEstado_Sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV20TFMedidasEstado_Sels, "T3.[MedidasEstado] IN (", ")")+")");
         }
         if ( ! (0==AV21TFTextosId) )
         {
            AddWhere(sWhereString, "(T3.[TextosId] >= @AV21TFTextosId)");
         }
         else
         {
            GXv_int6[9] = 1;
         }
         if ( ! (0==AV22TFTextosId_To) )
         {
            AddWhere(sWhereString, "(T3.[TextosId] <= @AV22TFTextosId_To)");
         }
         else
         {
            GXv_int6[10] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV24TFTextosTitulo_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV23TFTextosTitulo)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T4.[TextosTitulo]) like UPPER(@lV23TFTextosTitulo))");
         }
         else
         {
            GXv_int6[11] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV24TFTextosTitulo_Sel)) && ! ( StringUtil.StrCmp(AV24TFTextosTitulo_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T4.[TextosTitulo] = @AV24TFTextosTitulo_Sel)");
         }
         else
         {
            GXv_int6[12] = 1;
         }
         if ( StringUtil.StrCmp(AV24TFTextosTitulo_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T4.[TextosTitulo] IS NULL or (T4.[TextosTitulo] = ''))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[InventarioTextosId], T4.[TextosTitulo]";
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
                     return conditional_P00502(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (short)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (long)dynConstraints[6] , (long)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (int)dynConstraints[10] , (long)dynConstraints[11] , (long)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (short)dynConstraints[15] , (string)dynConstraints[16] , (long)dynConstraints[17] , (string)dynConstraints[18] , (long)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (long)dynConstraints[22] , (long)dynConstraints[23] );
               case 1 :
                     return conditional_P00503(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (short)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (long)dynConstraints[6] , (long)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (int)dynConstraints[10] , (long)dynConstraints[11] , (long)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (short)dynConstraints[15] , (string)dynConstraints[16] , (long)dynConstraints[17] , (string)dynConstraints[18] , (long)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (long)dynConstraints[22] , (long)dynConstraints[23] );
               case 2 :
                     return conditional_P00504(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (short)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (long)dynConstraints[6] , (long)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (int)dynConstraints[10] , (long)dynConstraints[11] , (long)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (short)dynConstraints[15] , (string)dynConstraints[16] , (long)dynConstraints[17] , (string)dynConstraints[18] , (long)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (long)dynConstraints[22] , (long)dynConstraints[23] );
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
          Object[] prmP00502;
          prmP00502 = new Object[] {
          new ParDef("@AV48InventarioTextosId",GXType.Decimal,18,0) ,
          new ParDef("@AV11TFRubrosId",GXType.Int16,4,0) ,
          new ParDef("@AV12TFRubrosId_To",GXType.Int16,4,0) ,
          new ParDef("@lV13TFRubrosNombre",GXType.Char,100,0) ,
          new ParDef("@AV14TFRubrosNombre_Sel",GXType.NChar,100,0) ,
          new ParDef("@AV15TFMedidasID",GXType.Decimal,18,0) ,
          new ParDef("@AV16TFMedidasID_To",GXType.Decimal,18,0) ,
          new ParDef("@lV17TFMedidasNombre",GXType.Char,50,0) ,
          new ParDef("@AV18TFMedidasNombre_Sel",GXType.NChar,50,0) ,
          new ParDef("@AV21TFTextosId",GXType.Decimal,18,0) ,
          new ParDef("@AV22TFTextosId_To",GXType.Decimal,18,0) ,
          new ParDef("@lV23TFTextosTitulo",GXType.Char,80,0) ,
          new ParDef("@AV24TFTextosTitulo_Sel",GXType.NChar,80,0)
          };
          Object[] prmP00503;
          prmP00503 = new Object[] {
          new ParDef("@AV48InventarioTextosId",GXType.Decimal,18,0) ,
          new ParDef("@AV11TFRubrosId",GXType.Int16,4,0) ,
          new ParDef("@AV12TFRubrosId_To",GXType.Int16,4,0) ,
          new ParDef("@lV13TFRubrosNombre",GXType.Char,100,0) ,
          new ParDef("@AV14TFRubrosNombre_Sel",GXType.NChar,100,0) ,
          new ParDef("@AV15TFMedidasID",GXType.Decimal,18,0) ,
          new ParDef("@AV16TFMedidasID_To",GXType.Decimal,18,0) ,
          new ParDef("@lV17TFMedidasNombre",GXType.Char,50,0) ,
          new ParDef("@AV18TFMedidasNombre_Sel",GXType.NChar,50,0) ,
          new ParDef("@AV21TFTextosId",GXType.Decimal,18,0) ,
          new ParDef("@AV22TFTextosId_To",GXType.Decimal,18,0) ,
          new ParDef("@lV23TFTextosTitulo",GXType.Char,80,0) ,
          new ParDef("@AV24TFTextosTitulo_Sel",GXType.NChar,80,0)
          };
          Object[] prmP00504;
          prmP00504 = new Object[] {
          new ParDef("@AV48InventarioTextosId",GXType.Decimal,18,0) ,
          new ParDef("@AV11TFRubrosId",GXType.Int16,4,0) ,
          new ParDef("@AV12TFRubrosId_To",GXType.Int16,4,0) ,
          new ParDef("@lV13TFRubrosNombre",GXType.Char,100,0) ,
          new ParDef("@AV14TFRubrosNombre_Sel",GXType.NChar,100,0) ,
          new ParDef("@AV15TFMedidasID",GXType.Decimal,18,0) ,
          new ParDef("@AV16TFMedidasID_To",GXType.Decimal,18,0) ,
          new ParDef("@lV17TFMedidasNombre",GXType.Char,50,0) ,
          new ParDef("@AV18TFMedidasNombre_Sel",GXType.NChar,50,0) ,
          new ParDef("@AV21TFTextosId",GXType.Decimal,18,0) ,
          new ParDef("@AV22TFTextosId_To",GXType.Decimal,18,0) ,
          new ParDef("@lV23TFTextosTitulo",GXType.Char,80,0) ,
          new ParDef("@AV24TFTextosTitulo_Sel",GXType.NChar,80,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00502", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00502,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00503", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00503,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00504", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00504,100, GxCacheFrequency.OFF ,true,false )
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
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((short[]) buf[2])[0] = rslt.getShort(2);
                ((string[]) buf[3])[0] = rslt.getString(3, 80);
                ((long[]) buf[4])[0] = rslt.getLong(4);
                ((bool[]) buf[5])[0] = rslt.wasNull(4);
                ((string[]) buf[6])[0] = rslt.getString(5, 3);
                ((bool[]) buf[7])[0] = rslt.wasNull(5);
                ((string[]) buf[8])[0] = rslt.getString(6, 50);
                ((long[]) buf[9])[0] = rslt.getLong(7);
                ((string[]) buf[10])[0] = rslt.getString(8, 100);
                ((long[]) buf[11])[0] = rslt.getLong(9);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getString(2, 50);
                ((string[]) buf[3])[0] = rslt.getString(3, 80);
                ((long[]) buf[4])[0] = rslt.getLong(4);
                ((bool[]) buf[5])[0] = rslt.wasNull(4);
                ((string[]) buf[6])[0] = rslt.getString(5, 3);
                ((bool[]) buf[7])[0] = rslt.wasNull(5);
                ((long[]) buf[8])[0] = rslt.getLong(6);
                ((string[]) buf[9])[0] = rslt.getString(7, 100);
                ((short[]) buf[10])[0] = rslt.getShort(8);
                ((long[]) buf[11])[0] = rslt.getLong(9);
                return;
             case 2 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getString(2, 80);
                ((long[]) buf[3])[0] = rslt.getLong(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getString(4, 3);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((string[]) buf[7])[0] = rslt.getString(5, 50);
                ((long[]) buf[8])[0] = rslt.getLong(6);
                ((string[]) buf[9])[0] = rslt.getString(7, 100);
                ((short[]) buf[10])[0] = rslt.getShort(8);
                ((long[]) buf[11])[0] = rslt.getLong(9);
                return;
       }
    }

 }

 [ServiceContract(Namespace = "GeneXus.Programs.textoslistawcgetfilterdata_services")]
 [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple)]
 [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
 public class textoslistawcgetfilterdata_services : GxRestService
 {
    [OperationContract(Name = "TextoslistaWCGetFilterData" )]
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
          if ( ! ProcessHeaders("textoslistawcgetfilterdata") )
          {
             return  ;
          }
          textoslistawcgetfilterdata worker = new textoslistawcgetfilterdata(context);
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

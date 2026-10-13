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
   public class rubrosinventariowcgetfilterdata : GXProcedure
   {
      public rubrosinventariowcgetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public rubrosinventariowcgetfilterdata( IGxContext context )
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
         this.AV39DDOName = aP0_DDOName;
         this.AV40SearchTxtParms = aP1_SearchTxtParms;
         this.AV41SearchTxtTo = aP2_SearchTxtTo;
         this.AV42OptionsJson = "" ;
         this.AV43OptionsDescJson = "" ;
         this.AV44OptionIndexesJson = "" ;
         initialize();
         ExecutePrivate();
         aP3_OptionsJson=this.AV42OptionsJson;
         aP4_OptionsDescJson=this.AV43OptionsDescJson;
         aP5_OptionIndexesJson=this.AV44OptionIndexesJson;
      }

      public string executeUdp( string aP0_DDOName ,
                                string aP1_SearchTxtParms ,
                                string aP2_SearchTxtTo ,
                                out string aP3_OptionsJson ,
                                out string aP4_OptionsDescJson )
      {
         execute(aP0_DDOName, aP1_SearchTxtParms, aP2_SearchTxtTo, out aP3_OptionsJson, out aP4_OptionsDescJson, out aP5_OptionIndexesJson);
         return AV44OptionIndexesJson ;
      }

      public void executeSubmit( string aP0_DDOName ,
                                 string aP1_SearchTxtParms ,
                                 string aP2_SearchTxtTo ,
                                 out string aP3_OptionsJson ,
                                 out string aP4_OptionsDescJson ,
                                 out string aP5_OptionIndexesJson )
      {
         this.AV39DDOName = aP0_DDOName;
         this.AV40SearchTxtParms = aP1_SearchTxtParms;
         this.AV41SearchTxtTo = aP2_SearchTxtTo;
         this.AV42OptionsJson = "" ;
         this.AV43OptionsDescJson = "" ;
         this.AV44OptionIndexesJson = "" ;
         SubmitImpl();
         aP3_OptionsJson=this.AV42OptionsJson;
         aP4_OptionsDescJson=this.AV43OptionsDescJson;
         aP5_OptionIndexesJson=this.AV44OptionIndexesJson;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV29Options = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV31OptionsDesc = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV32OptionIndexes = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         GXt_boolean1 = AV8IsAuthorized;
         new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWInventario", out  GXt_boolean1) ;
         AV8IsAuthorized = GXt_boolean1;
         if ( AV8IsAuthorized )
         {
            AV26MaxItems = 10;
            AV25PageIndex = (short)((String.IsNullOrEmpty(StringUtil.RTrim( AV40SearchTxtParms)) ? 0 : (long)(Math.Round(NumberUtil.Val( StringUtil.Substring( AV40SearchTxtParms, 1, 2), "."), 18, MidpointRounding.ToEven))));
            AV23SearchTxt = (String.IsNullOrEmpty(StringUtil.RTrim( AV40SearchTxtParms)) ? "" : StringUtil.Substring( AV40SearchTxtParms, 3, -1));
            AV24SkipItems = (short)(AV25PageIndex*AV26MaxItems);
            new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV9WWPContext) ;
            /* Execute user subroutine: 'LOADGRIDSTATE' */
            S111 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
            if ( StringUtil.StrCmp(StringUtil.Upper( AV39DDOName), "DDO_MEDIDASNOMBRE") == 0 )
            {
               /* Execute user subroutine: 'LOADMEDIDASNOMBREOPTIONS' */
               S121 ();
               if ( returnInSub )
               {
                  cleanup();
                  if (true) return;
               }
            }
            else if ( StringUtil.StrCmp(StringUtil.Upper( AV39DDOName), "DDO_RUBROSNOMBRE") == 0 )
            {
               /* Execute user subroutine: 'LOADRUBROSNOMBREOPTIONS' */
               S131 ();
               if ( returnInSub )
               {
                  cleanup();
                  if (true) return;
               }
            }
            else if ( StringUtil.StrCmp(StringUtil.Upper( AV39DDOName), "DDO_TEXTOSTITULO") == 0 )
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
         AV42OptionsJson = AV29Options.ToJSonString(false);
         AV43OptionsDescJson = AV31OptionsDesc.ToJSonString(false);
         AV44OptionIndexesJson = AV32OptionIndexes.ToJSonString(false);
         cleanup();
      }

      protected void S111( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV34Session.Get("RubrosInventarioWCGridState"), "") == 0 )
         {
            AV36GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "RubrosInventarioWCGridState"), null, "", "");
         }
         else
         {
            AV36GridState.FromXml(AV34Session.Get("RubrosInventarioWCGridState"), null, "", "");
         }
         AV47GXV1 = 1;
         while ( AV47GXV1 <= AV36GridState.gxTpr_Filtervalues.Count )
         {
            AV37GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV36GridState.gxTpr_Filtervalues.Item(AV47GXV1));
            if ( StringUtil.StrCmp(AV37GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV45FilterFullText = AV37GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV37GridStateFilterValue.gxTpr_Name, "TFMEDIDASNOMBRE") == 0 )
            {
               AV13TFMedidasNombre = AV37GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV37GridStateFilterValue.gxTpr_Name, "TFMEDIDASNOMBRE_SEL") == 0 )
            {
               AV14TFMedidasNombre_Sel = AV37GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV37GridStateFilterValue.gxTpr_Name, "TFRUBROSNOMBRE") == 0 )
            {
               AV15TFRubrosNombre = AV37GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV37GridStateFilterValue.gxTpr_Name, "TFRUBROSNOMBRE_SEL") == 0 )
            {
               AV16TFRubrosNombre_Sel = AV37GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV37GridStateFilterValue.gxTpr_Name, "TFMEDIDASESTADO_SEL") == 0 )
            {
               AV17TFMedidasEstado_SelsJson = AV37GridStateFilterValue.gxTpr_Value;
               AV18TFMedidasEstado_Sels.FromJSonString(AV17TFMedidasEstado_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV37GridStateFilterValue.gxTpr_Name, "TFTEXTOSID") == 0 )
            {
               AV19TFTextosId = (long)(Math.Round(NumberUtil.Val( AV37GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV20TFTextosId_To = (long)(Math.Round(NumberUtil.Val( AV37GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV37GridStateFilterValue.gxTpr_Name, "TFTEXTOSTITULO") == 0 )
            {
               AV21TFTextosTitulo = AV37GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV37GridStateFilterValue.gxTpr_Name, "TFTEXTOSTITULO_SEL") == 0 )
            {
               AV22TFTextosTitulo_Sel = AV37GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV37GridStateFilterValue.gxTpr_Name, "PARM_&RUBROSID") == 0 )
            {
               AV46RubrosId = (short)(Math.Round(NumberUtil.Val( AV37GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
            }
            AV47GXV1 = (int)(AV47GXV1+1);
         }
      }

      protected void S121( )
      {
         /* 'LOADMEDIDASNOMBREOPTIONS' Routine */
         returnInSub = false;
         AV13TFMedidasNombre = AV23SearchTxt;
         AV14TFMedidasNombre_Sel = "";
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A139MedidasEstado ,
                                              AV18TFMedidasEstado_Sels ,
                                              AV14TFMedidasNombre_Sel ,
                                              AV13TFMedidasNombre ,
                                              AV16TFRubrosNombre_Sel ,
                                              AV15TFRubrosNombre ,
                                              AV18TFMedidasEstado_Sels.Count ,
                                              AV19TFTextosId ,
                                              AV20TFTextosId_To ,
                                              AV22TFTextosTitulo_Sel ,
                                              AV21TFTextosTitulo ,
                                              A138MedidasNombre ,
                                              A122RubrosNombre ,
                                              A150TextosId ,
                                              A259TextosTitulo ,
                                              AV45FilterFullText ,
                                              AV46RubrosId ,
                                              A121RubrosId } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.SHORT
                                              }
         });
         lV13TFMedidasNombre = StringUtil.PadR( StringUtil.RTrim( AV13TFMedidasNombre), 50, "%");
         lV15TFRubrosNombre = StringUtil.PadR( StringUtil.RTrim( AV15TFRubrosNombre), 100, "%");
         lV21TFTextosTitulo = StringUtil.PadR( StringUtil.RTrim( AV21TFTextosTitulo), 80, "%");
         /* Using cursor P00482 */
         pr_default.execute(0, new Object[] {AV46RubrosId, lV13TFMedidasNombre, AV14TFMedidasNombre_Sel, lV15TFRubrosNombre, AV16TFRubrosNombre_Sel, AV19TFTextosId, AV20TFTextosId_To, lV21TFTextosTitulo, AV22TFTextosTitulo_Sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRK482 = false;
            A121RubrosId = P00482_A121RubrosId[0];
            A138MedidasNombre = P00482_A138MedidasNombre[0];
            A259TextosTitulo = P00482_A259TextosTitulo[0];
            A150TextosId = P00482_A150TextosId[0];
            n150TextosId = P00482_n150TextosId[0];
            A139MedidasEstado = P00482_A139MedidasEstado[0];
            n139MedidasEstado = P00482_n139MedidasEstado[0];
            A122RubrosNombre = P00482_A122RubrosNombre[0];
            A137MedidasID = P00482_A137MedidasID[0];
            A122RubrosNombre = P00482_A122RubrosNombre[0];
            A259TextosTitulo = P00482_A259TextosTitulo[0];
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV45FilterFullText)) || ( ( StringUtil.Like( StringUtil.Upper( A138MedidasNombre) , StringUtil.PadR( "%" + StringUtil.Upper( AV45FilterFullText) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A122RubrosNombre) , StringUtil.PadR( "%" + StringUtil.Upper( AV45FilterFullText) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( context.GetMessage( "habilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV45FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A139MedidasEstado, "HAB") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "deshabilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV45FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A139MedidasEstado, "DES") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "pendiente", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV45FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A139MedidasEstado, "PEN") == 0 ) ) || ( StringUtil.Like( StringUtil.Str( (decimal)(A150TextosId), 18, 0) , StringUtil.PadR( "%" + AV45FilterFullText , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A259TextosTitulo) , StringUtil.PadR( "%" + StringUtil.Upper( AV45FilterFullText) , 255 , "%"),  ' ' ) ) ) )
            {
               AV33count = 0;
               while ( (pr_default.getStatus(0) != 101) && ( P00482_A121RubrosId[0] == A121RubrosId ) && ( StringUtil.StrCmp(P00482_A138MedidasNombre[0], A138MedidasNombre) == 0 ) )
               {
                  BRK482 = false;
                  A137MedidasID = P00482_A137MedidasID[0];
                  AV33count = (long)(AV33count+1);
                  BRK482 = true;
                  pr_default.readNext(0);
               }
               if ( (0==AV24SkipItems) )
               {
                  AV28Option = (String.IsNullOrEmpty(StringUtil.RTrim( A138MedidasNombre)) ? "<#Empty#>" : A138MedidasNombre);
                  AV29Options.Add(AV28Option, 0);
                  AV32OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV33count), "Z,ZZZ,ZZZ,ZZ9")), 0);
                  if ( AV29Options.Count == 10 )
                  {
                     /* Exit For each command. Update data (if necessary), close cursors & exit. */
                     if (true) break;
                  }
               }
               else
               {
                  AV24SkipItems = (short)(AV24SkipItems-1);
               }
            }
            if ( ! BRK482 )
            {
               BRK482 = true;
               pr_default.readNext(0);
            }
         }
         pr_default.close(0);
      }

      protected void S131( )
      {
         /* 'LOADRUBROSNOMBREOPTIONS' Routine */
         returnInSub = false;
         AV15TFRubrosNombre = AV23SearchTxt;
         AV16TFRubrosNombre_Sel = "";
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              A139MedidasEstado ,
                                              AV18TFMedidasEstado_Sels ,
                                              AV14TFMedidasNombre_Sel ,
                                              AV13TFMedidasNombre ,
                                              AV16TFRubrosNombre_Sel ,
                                              AV15TFRubrosNombre ,
                                              AV18TFMedidasEstado_Sels.Count ,
                                              AV19TFTextosId ,
                                              AV20TFTextosId_To ,
                                              AV22TFTextosTitulo_Sel ,
                                              AV21TFTextosTitulo ,
                                              A138MedidasNombre ,
                                              A122RubrosNombre ,
                                              A150TextosId ,
                                              A259TextosTitulo ,
                                              AV45FilterFullText ,
                                              AV46RubrosId ,
                                              A121RubrosId } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.SHORT
                                              }
         });
         lV13TFMedidasNombre = StringUtil.PadR( StringUtil.RTrim( AV13TFMedidasNombre), 50, "%");
         lV15TFRubrosNombre = StringUtil.PadR( StringUtil.RTrim( AV15TFRubrosNombre), 100, "%");
         lV21TFTextosTitulo = StringUtil.PadR( StringUtil.RTrim( AV21TFTextosTitulo), 80, "%");
         /* Using cursor P00483 */
         pr_default.execute(1, new Object[] {AV46RubrosId, lV13TFMedidasNombre, AV14TFMedidasNombre_Sel, lV15TFRubrosNombre, AV16TFRubrosNombre_Sel, AV19TFTextosId, AV20TFTextosId_To, lV21TFTextosTitulo, AV22TFTextosTitulo_Sel});
         while ( (pr_default.getStatus(1) != 101) )
         {
            BRK484 = false;
            A121RubrosId = P00483_A121RubrosId[0];
            A259TextosTitulo = P00483_A259TextosTitulo[0];
            A150TextosId = P00483_A150TextosId[0];
            n150TextosId = P00483_n150TextosId[0];
            A139MedidasEstado = P00483_A139MedidasEstado[0];
            n139MedidasEstado = P00483_n139MedidasEstado[0];
            A122RubrosNombre = P00483_A122RubrosNombre[0];
            A138MedidasNombre = P00483_A138MedidasNombre[0];
            A137MedidasID = P00483_A137MedidasID[0];
            A122RubrosNombre = P00483_A122RubrosNombre[0];
            A259TextosTitulo = P00483_A259TextosTitulo[0];
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV45FilterFullText)) || ( ( StringUtil.Like( StringUtil.Upper( A138MedidasNombre) , StringUtil.PadR( "%" + StringUtil.Upper( AV45FilterFullText) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A122RubrosNombre) , StringUtil.PadR( "%" + StringUtil.Upper( AV45FilterFullText) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( context.GetMessage( "habilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV45FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A139MedidasEstado, "HAB") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "deshabilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV45FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A139MedidasEstado, "DES") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "pendiente", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV45FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A139MedidasEstado, "PEN") == 0 ) ) || ( StringUtil.Like( StringUtil.Str( (decimal)(A150TextosId), 18, 0) , StringUtil.PadR( "%" + AV45FilterFullText , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A259TextosTitulo) , StringUtil.PadR( "%" + StringUtil.Upper( AV45FilterFullText) , 255 , "%"),  ' ' ) ) ) )
            {
               AV33count = 0;
               while ( (pr_default.getStatus(1) != 101) && ( P00483_A121RubrosId[0] == A121RubrosId ) )
               {
                  BRK484 = false;
                  A137MedidasID = P00483_A137MedidasID[0];
                  AV33count = (long)(AV33count+1);
                  BRK484 = true;
                  pr_default.readNext(1);
               }
               AV28Option = (String.IsNullOrEmpty(StringUtil.RTrim( A122RubrosNombre)) ? "<#Empty#>" : A122RubrosNombre);
               AV27InsertIndex = 1;
               while ( ( StringUtil.StrCmp(AV28Option, "<#Empty#>") != 0 ) && ( AV27InsertIndex <= AV29Options.Count ) && ( ( StringUtil.StrCmp(((string)AV29Options.Item(AV27InsertIndex)), AV28Option) < 0 ) || ( StringUtil.StrCmp(((string)AV29Options.Item(AV27InsertIndex)), "<#Empty#>") == 0 ) ) )
               {
                  AV27InsertIndex = (int)(AV27InsertIndex+1);
               }
               AV29Options.Add(AV28Option, AV27InsertIndex);
               AV32OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV33count), "Z,ZZZ,ZZZ,ZZ9")), AV27InsertIndex);
               if ( AV29Options.Count == AV24SkipItems + 11 )
               {
                  AV29Options.RemoveItem(AV29Options.Count);
                  AV32OptionIndexes.RemoveItem(AV32OptionIndexes.Count);
               }
            }
            if ( ! BRK484 )
            {
               BRK484 = true;
               pr_default.readNext(1);
            }
         }
         pr_default.close(1);
         while ( AV24SkipItems > 0 )
         {
            AV29Options.RemoveItem(1);
            AV32OptionIndexes.RemoveItem(1);
            AV24SkipItems = (short)(AV24SkipItems-1);
         }
      }

      protected void S141( )
      {
         /* 'LOADTEXTOSTITULOOPTIONS' Routine */
         returnInSub = false;
         AV21TFTextosTitulo = AV23SearchTxt;
         AV22TFTextosTitulo_Sel = "";
         pr_default.dynParam(2, new Object[]{ new Object[]{
                                              A139MedidasEstado ,
                                              AV18TFMedidasEstado_Sels ,
                                              AV14TFMedidasNombre_Sel ,
                                              AV13TFMedidasNombre ,
                                              AV16TFRubrosNombre_Sel ,
                                              AV15TFRubrosNombre ,
                                              AV18TFMedidasEstado_Sels.Count ,
                                              AV19TFTextosId ,
                                              AV20TFTextosId_To ,
                                              AV22TFTextosTitulo_Sel ,
                                              AV21TFTextosTitulo ,
                                              A138MedidasNombre ,
                                              A122RubrosNombre ,
                                              A150TextosId ,
                                              A259TextosTitulo ,
                                              AV45FilterFullText ,
                                              AV46RubrosId ,
                                              A121RubrosId } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.SHORT
                                              }
         });
         lV13TFMedidasNombre = StringUtil.PadR( StringUtil.RTrim( AV13TFMedidasNombre), 50, "%");
         lV15TFRubrosNombre = StringUtil.PadR( StringUtil.RTrim( AV15TFRubrosNombre), 100, "%");
         lV21TFTextosTitulo = StringUtil.PadR( StringUtil.RTrim( AV21TFTextosTitulo), 80, "%");
         /* Using cursor P00484 */
         pr_default.execute(2, new Object[] {AV46RubrosId, lV13TFMedidasNombre, AV14TFMedidasNombre_Sel, lV15TFRubrosNombre, AV16TFRubrosNombre_Sel, AV19TFTextosId, AV20TFTextosId_To, lV21TFTextosTitulo, AV22TFTextosTitulo_Sel});
         while ( (pr_default.getStatus(2) != 101) )
         {
            BRK486 = false;
            A121RubrosId = P00484_A121RubrosId[0];
            A259TextosTitulo = P00484_A259TextosTitulo[0];
            A150TextosId = P00484_A150TextosId[0];
            n150TextosId = P00484_n150TextosId[0];
            A139MedidasEstado = P00484_A139MedidasEstado[0];
            n139MedidasEstado = P00484_n139MedidasEstado[0];
            A122RubrosNombre = P00484_A122RubrosNombre[0];
            A138MedidasNombre = P00484_A138MedidasNombre[0];
            A137MedidasID = P00484_A137MedidasID[0];
            A122RubrosNombre = P00484_A122RubrosNombre[0];
            A259TextosTitulo = P00484_A259TextosTitulo[0];
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV45FilterFullText)) || ( ( StringUtil.Like( StringUtil.Upper( A138MedidasNombre) , StringUtil.PadR( "%" + StringUtil.Upper( AV45FilterFullText) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A122RubrosNombre) , StringUtil.PadR( "%" + StringUtil.Upper( AV45FilterFullText) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( context.GetMessage( "habilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV45FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A139MedidasEstado, "HAB") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "deshabilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV45FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A139MedidasEstado, "DES") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "pendiente", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV45FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A139MedidasEstado, "PEN") == 0 ) ) || ( StringUtil.Like( StringUtil.Str( (decimal)(A150TextosId), 18, 0) , StringUtil.PadR( "%" + AV45FilterFullText , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A259TextosTitulo) , StringUtil.PadR( "%" + StringUtil.Upper( AV45FilterFullText) , 255 , "%"),  ' ' ) ) ) )
            {
               AV33count = 0;
               while ( (pr_default.getStatus(2) != 101) && ( P00484_A121RubrosId[0] == A121RubrosId ) && ( StringUtil.StrCmp(P00484_A259TextosTitulo[0], A259TextosTitulo) == 0 ) )
               {
                  BRK486 = false;
                  A150TextosId = P00484_A150TextosId[0];
                  n150TextosId = P00484_n150TextosId[0];
                  A137MedidasID = P00484_A137MedidasID[0];
                  AV33count = (long)(AV33count+1);
                  BRK486 = true;
                  pr_default.readNext(2);
               }
               if ( (0==AV24SkipItems) )
               {
                  AV28Option = (String.IsNullOrEmpty(StringUtil.RTrim( A259TextosTitulo)) ? "<#Empty#>" : A259TextosTitulo);
                  AV29Options.Add(AV28Option, 0);
                  AV32OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV33count), "Z,ZZZ,ZZZ,ZZ9")), 0);
                  if ( AV29Options.Count == 10 )
                  {
                     /* Exit For each command. Update data (if necessary), close cursors & exit. */
                     if (true) break;
                  }
               }
               else
               {
                  AV24SkipItems = (short)(AV24SkipItems-1);
               }
            }
            if ( ! BRK486 )
            {
               BRK486 = true;
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
         AV42OptionsJson = "";
         AV43OptionsDescJson = "";
         AV44OptionIndexesJson = "";
         AV29Options = new GxSimpleCollection<string>();
         AV31OptionsDesc = new GxSimpleCollection<string>();
         AV32OptionIndexes = new GxSimpleCollection<string>();
         AV23SearchTxt = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV34Session = context.GetSession();
         AV36GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV37GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV45FilterFullText = "";
         AV13TFMedidasNombre = "";
         AV14TFMedidasNombre_Sel = "";
         AV15TFRubrosNombre = "";
         AV16TFRubrosNombre_Sel = "";
         AV17TFMedidasEstado_SelsJson = "";
         AV18TFMedidasEstado_Sels = new GxSimpleCollection<string>();
         AV21TFTextosTitulo = "";
         AV22TFTextosTitulo_Sel = "";
         lV45FilterFullText = "";
         lV13TFMedidasNombre = "";
         lV15TFRubrosNombre = "";
         lV21TFTextosTitulo = "";
         A139MedidasEstado = "";
         A138MedidasNombre = "";
         A122RubrosNombre = "";
         A259TextosTitulo = "";
         P00482_A121RubrosId = new short[1] ;
         P00482_A138MedidasNombre = new string[] {""} ;
         P00482_A259TextosTitulo = new string[] {""} ;
         P00482_A150TextosId = new long[1] ;
         P00482_n150TextosId = new bool[] {false} ;
         P00482_A139MedidasEstado = new string[] {""} ;
         P00482_n139MedidasEstado = new bool[] {false} ;
         P00482_A122RubrosNombre = new string[] {""} ;
         P00482_A137MedidasID = new long[1] ;
         AV28Option = "";
         P00483_A121RubrosId = new short[1] ;
         P00483_A259TextosTitulo = new string[] {""} ;
         P00483_A150TextosId = new long[1] ;
         P00483_n150TextosId = new bool[] {false} ;
         P00483_A139MedidasEstado = new string[] {""} ;
         P00483_n139MedidasEstado = new bool[] {false} ;
         P00483_A122RubrosNombre = new string[] {""} ;
         P00483_A138MedidasNombre = new string[] {""} ;
         P00483_A137MedidasID = new long[1] ;
         P00484_A121RubrosId = new short[1] ;
         P00484_A259TextosTitulo = new string[] {""} ;
         P00484_A150TextosId = new long[1] ;
         P00484_n150TextosId = new bool[] {false} ;
         P00484_A139MedidasEstado = new string[] {""} ;
         P00484_n139MedidasEstado = new bool[] {false} ;
         P00484_A122RubrosNombre = new string[] {""} ;
         P00484_A138MedidasNombre = new string[] {""} ;
         P00484_A137MedidasID = new long[1] ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.rubrosinventariowcgetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P00482_A121RubrosId, P00482_A138MedidasNombre, P00482_A259TextosTitulo, P00482_A150TextosId, P00482_n150TextosId, P00482_A139MedidasEstado, P00482_n139MedidasEstado, P00482_A122RubrosNombre, P00482_A137MedidasID
               }
               , new Object[] {
               P00483_A121RubrosId, P00483_A259TextosTitulo, P00483_A150TextosId, P00483_n150TextosId, P00483_A139MedidasEstado, P00483_n139MedidasEstado, P00483_A122RubrosNombre, P00483_A138MedidasNombre, P00483_A137MedidasID
               }
               , new Object[] {
               P00484_A121RubrosId, P00484_A259TextosTitulo, P00484_A150TextosId, P00484_n150TextosId, P00484_A139MedidasEstado, P00484_n139MedidasEstado, P00484_A122RubrosNombre, P00484_A138MedidasNombre, P00484_A137MedidasID
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV26MaxItems ;
      private short AV25PageIndex ;
      private short AV24SkipItems ;
      private short AV46RubrosId ;
      private short A121RubrosId ;
      private int AV47GXV1 ;
      private int AV18TFMedidasEstado_Sels_Count ;
      private int AV27InsertIndex ;
      private long AV19TFTextosId ;
      private long AV20TFTextosId_To ;
      private long A150TextosId ;
      private long A137MedidasID ;
      private long AV33count ;
      private string AV13TFMedidasNombre ;
      private string AV14TFMedidasNombre_Sel ;
      private string AV15TFRubrosNombre ;
      private string AV16TFRubrosNombre_Sel ;
      private string AV21TFTextosTitulo ;
      private string AV22TFTextosTitulo_Sel ;
      private string lV13TFMedidasNombre ;
      private string lV15TFRubrosNombre ;
      private string lV21TFTextosTitulo ;
      private string A139MedidasEstado ;
      private string A138MedidasNombre ;
      private string A122RubrosNombre ;
      private string A259TextosTitulo ;
      private bool AV8IsAuthorized ;
      private bool GXt_boolean1 ;
      private bool returnInSub ;
      private bool BRK482 ;
      private bool n150TextosId ;
      private bool n139MedidasEstado ;
      private bool BRK484 ;
      private bool BRK486 ;
      private string AV42OptionsJson ;
      private string AV43OptionsDescJson ;
      private string AV44OptionIndexesJson ;
      private string AV17TFMedidasEstado_SelsJson ;
      private string AV39DDOName ;
      private string AV40SearchTxtParms ;
      private string AV41SearchTxtTo ;
      private string AV23SearchTxt ;
      private string AV45FilterFullText ;
      private string lV45FilterFullText ;
      private string AV28Option ;
      private IGxSession AV34Session ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GxSimpleCollection<string> AV29Options ;
      private GxSimpleCollection<string> AV31OptionsDesc ;
      private GxSimpleCollection<string> AV32OptionIndexes ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV36GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV37GridStateFilterValue ;
      private GxSimpleCollection<string> AV18TFMedidasEstado_Sels ;
      private IDataStoreProvider pr_default ;
      private short[] P00482_A121RubrosId ;
      private string[] P00482_A138MedidasNombre ;
      private string[] P00482_A259TextosTitulo ;
      private long[] P00482_A150TextosId ;
      private bool[] P00482_n150TextosId ;
      private string[] P00482_A139MedidasEstado ;
      private bool[] P00482_n139MedidasEstado ;
      private string[] P00482_A122RubrosNombre ;
      private long[] P00482_A137MedidasID ;
      private short[] P00483_A121RubrosId ;
      private string[] P00483_A259TextosTitulo ;
      private long[] P00483_A150TextosId ;
      private bool[] P00483_n150TextosId ;
      private string[] P00483_A139MedidasEstado ;
      private bool[] P00483_n139MedidasEstado ;
      private string[] P00483_A122RubrosNombre ;
      private string[] P00483_A138MedidasNombre ;
      private long[] P00483_A137MedidasID ;
      private short[] P00484_A121RubrosId ;
      private string[] P00484_A259TextosTitulo ;
      private long[] P00484_A150TextosId ;
      private bool[] P00484_n150TextosId ;
      private string[] P00484_A139MedidasEstado ;
      private bool[] P00484_n139MedidasEstado ;
      private string[] P00484_A122RubrosNombre ;
      private string[] P00484_A138MedidasNombre ;
      private long[] P00484_A137MedidasID ;
      private string aP3_OptionsJson ;
      private string aP4_OptionsDescJson ;
      private string aP5_OptionIndexesJson ;
   }

   public class rubrosinventariowcgetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00482( IGxContext context ,
                                             string A139MedidasEstado ,
                                             GxSimpleCollection<string> AV18TFMedidasEstado_Sels ,
                                             string AV14TFMedidasNombre_Sel ,
                                             string AV13TFMedidasNombre ,
                                             string AV16TFRubrosNombre_Sel ,
                                             string AV15TFRubrosNombre ,
                                             int AV18TFMedidasEstado_Sels_Count ,
                                             long AV19TFTextosId ,
                                             long AV20TFTextosId_To ,
                                             string AV22TFTextosTitulo_Sel ,
                                             string AV21TFTextosTitulo ,
                                             string A138MedidasNombre ,
                                             string A122RubrosNombre ,
                                             long A150TextosId ,
                                             string A259TextosTitulo ,
                                             string AV45FilterFullText ,
                                             short AV46RubrosId ,
                                             short A121RubrosId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int2 = new short[9];
         Object[] GXv_Object3 = new Object[2];
         scmdbuf = "SELECT T1.[RubrosId], T1.[MedidasNombre], T3.[TextosTitulo], T1.[TextosId], T1.[MedidasEstado], T2.[RubrosNombre], T1.[MedidasID] FROM (([RubrosMedidas] T1 INNER JOIN [Rubros] T2 ON T2.[RubrosId] = T1.[RubrosId]) LEFT JOIN [Textos] T3 ON T3.[TextosId] = T1.[TextosId])";
         AddWhere(sWhereString, "(T1.[RubrosId] = @AV46RubrosId)");
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
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV16TFRubrosNombre_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV15TFRubrosNombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[RubrosNombre]) like UPPER(@lV15TFRubrosNombre))");
         }
         else
         {
            GXv_int2[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV16TFRubrosNombre_Sel)) && ! ( StringUtil.StrCmp(AV16TFRubrosNombre_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.[RubrosNombre] = @AV16TFRubrosNombre_Sel)");
         }
         else
         {
            GXv_int2[4] = 1;
         }
         if ( StringUtil.StrCmp(AV16TFRubrosNombre_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T2.[RubrosNombre] = ''))");
         }
         if ( AV18TFMedidasEstado_Sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV18TFMedidasEstado_Sels, "T1.[MedidasEstado] IN (", ")")+")");
         }
         if ( ! (0==AV19TFTextosId) )
         {
            AddWhere(sWhereString, "(T1.[TextosId] >= @AV19TFTextosId)");
         }
         else
         {
            GXv_int2[5] = 1;
         }
         if ( ! (0==AV20TFTextosId_To) )
         {
            AddWhere(sWhereString, "(T1.[TextosId] <= @AV20TFTextosId_To)");
         }
         else
         {
            GXv_int2[6] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV22TFTextosTitulo_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV21TFTextosTitulo)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T3.[TextosTitulo]) like UPPER(@lV21TFTextosTitulo))");
         }
         else
         {
            GXv_int2[7] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV22TFTextosTitulo_Sel)) && ! ( StringUtil.StrCmp(AV22TFTextosTitulo_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T3.[TextosTitulo] = @AV22TFTextosTitulo_Sel)");
         }
         else
         {
            GXv_int2[8] = 1;
         }
         if ( StringUtil.StrCmp(AV22TFTextosTitulo_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T3.[TextosTitulo] IS NULL or (T3.[TextosTitulo] = ''))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[RubrosId], T1.[MedidasNombre]";
         GXv_Object3[0] = scmdbuf;
         GXv_Object3[1] = GXv_int2;
         return GXv_Object3 ;
      }

      protected Object[] conditional_P00483( IGxContext context ,
                                             string A139MedidasEstado ,
                                             GxSimpleCollection<string> AV18TFMedidasEstado_Sels ,
                                             string AV14TFMedidasNombre_Sel ,
                                             string AV13TFMedidasNombre ,
                                             string AV16TFRubrosNombre_Sel ,
                                             string AV15TFRubrosNombre ,
                                             int AV18TFMedidasEstado_Sels_Count ,
                                             long AV19TFTextosId ,
                                             long AV20TFTextosId_To ,
                                             string AV22TFTextosTitulo_Sel ,
                                             string AV21TFTextosTitulo ,
                                             string A138MedidasNombre ,
                                             string A122RubrosNombre ,
                                             long A150TextosId ,
                                             string A259TextosTitulo ,
                                             string AV45FilterFullText ,
                                             short AV46RubrosId ,
                                             short A121RubrosId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int4 = new short[9];
         Object[] GXv_Object5 = new Object[2];
         scmdbuf = "SELECT T1.[RubrosId], T3.[TextosTitulo], T1.[TextosId], T1.[MedidasEstado], T2.[RubrosNombre], T1.[MedidasNombre], T1.[MedidasID] FROM (([RubrosMedidas] T1 INNER JOIN [Rubros] T2 ON T2.[RubrosId] = T1.[RubrosId]) LEFT JOIN [Textos] T3 ON T3.[TextosId] = T1.[TextosId])";
         AddWhere(sWhereString, "(T1.[RubrosId] = @AV46RubrosId)");
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
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV16TFRubrosNombre_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV15TFRubrosNombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[RubrosNombre]) like UPPER(@lV15TFRubrosNombre))");
         }
         else
         {
            GXv_int4[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV16TFRubrosNombre_Sel)) && ! ( StringUtil.StrCmp(AV16TFRubrosNombre_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.[RubrosNombre] = @AV16TFRubrosNombre_Sel)");
         }
         else
         {
            GXv_int4[4] = 1;
         }
         if ( StringUtil.StrCmp(AV16TFRubrosNombre_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T2.[RubrosNombre] = ''))");
         }
         if ( AV18TFMedidasEstado_Sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV18TFMedidasEstado_Sels, "T1.[MedidasEstado] IN (", ")")+")");
         }
         if ( ! (0==AV19TFTextosId) )
         {
            AddWhere(sWhereString, "(T1.[TextosId] >= @AV19TFTextosId)");
         }
         else
         {
            GXv_int4[5] = 1;
         }
         if ( ! (0==AV20TFTextosId_To) )
         {
            AddWhere(sWhereString, "(T1.[TextosId] <= @AV20TFTextosId_To)");
         }
         else
         {
            GXv_int4[6] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV22TFTextosTitulo_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV21TFTextosTitulo)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T3.[TextosTitulo]) like UPPER(@lV21TFTextosTitulo))");
         }
         else
         {
            GXv_int4[7] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV22TFTextosTitulo_Sel)) && ! ( StringUtil.StrCmp(AV22TFTextosTitulo_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T3.[TextosTitulo] = @AV22TFTextosTitulo_Sel)");
         }
         else
         {
            GXv_int4[8] = 1;
         }
         if ( StringUtil.StrCmp(AV22TFTextosTitulo_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T3.[TextosTitulo] IS NULL or (T3.[TextosTitulo] = ''))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[RubrosId]";
         GXv_Object5[0] = scmdbuf;
         GXv_Object5[1] = GXv_int4;
         return GXv_Object5 ;
      }

      protected Object[] conditional_P00484( IGxContext context ,
                                             string A139MedidasEstado ,
                                             GxSimpleCollection<string> AV18TFMedidasEstado_Sels ,
                                             string AV14TFMedidasNombre_Sel ,
                                             string AV13TFMedidasNombre ,
                                             string AV16TFRubrosNombre_Sel ,
                                             string AV15TFRubrosNombre ,
                                             int AV18TFMedidasEstado_Sels_Count ,
                                             long AV19TFTextosId ,
                                             long AV20TFTextosId_To ,
                                             string AV22TFTextosTitulo_Sel ,
                                             string AV21TFTextosTitulo ,
                                             string A138MedidasNombre ,
                                             string A122RubrosNombre ,
                                             long A150TextosId ,
                                             string A259TextosTitulo ,
                                             string AV45FilterFullText ,
                                             short AV46RubrosId ,
                                             short A121RubrosId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int6 = new short[9];
         Object[] GXv_Object7 = new Object[2];
         scmdbuf = "SELECT T1.[RubrosId], T3.[TextosTitulo], T1.[TextosId], T1.[MedidasEstado], T2.[RubrosNombre], T1.[MedidasNombre], T1.[MedidasID] FROM (([RubrosMedidas] T1 INNER JOIN [Rubros] T2 ON T2.[RubrosId] = T1.[RubrosId]) LEFT JOIN [Textos] T3 ON T3.[TextosId] = T1.[TextosId])";
         AddWhere(sWhereString, "(T1.[RubrosId] = @AV46RubrosId)");
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
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV16TFRubrosNombre_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV15TFRubrosNombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[RubrosNombre]) like UPPER(@lV15TFRubrosNombre))");
         }
         else
         {
            GXv_int6[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV16TFRubrosNombre_Sel)) && ! ( StringUtil.StrCmp(AV16TFRubrosNombre_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.[RubrosNombre] = @AV16TFRubrosNombre_Sel)");
         }
         else
         {
            GXv_int6[4] = 1;
         }
         if ( StringUtil.StrCmp(AV16TFRubrosNombre_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T2.[RubrosNombre] = ''))");
         }
         if ( AV18TFMedidasEstado_Sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV18TFMedidasEstado_Sels, "T1.[MedidasEstado] IN (", ")")+")");
         }
         if ( ! (0==AV19TFTextosId) )
         {
            AddWhere(sWhereString, "(T1.[TextosId] >= @AV19TFTextosId)");
         }
         else
         {
            GXv_int6[5] = 1;
         }
         if ( ! (0==AV20TFTextosId_To) )
         {
            AddWhere(sWhereString, "(T1.[TextosId] <= @AV20TFTextosId_To)");
         }
         else
         {
            GXv_int6[6] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV22TFTextosTitulo_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV21TFTextosTitulo)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T3.[TextosTitulo]) like UPPER(@lV21TFTextosTitulo))");
         }
         else
         {
            GXv_int6[7] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV22TFTextosTitulo_Sel)) && ! ( StringUtil.StrCmp(AV22TFTextosTitulo_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T3.[TextosTitulo] = @AV22TFTextosTitulo_Sel)");
         }
         else
         {
            GXv_int6[8] = 1;
         }
         if ( StringUtil.StrCmp(AV22TFTextosTitulo_Sel, "<#Empty#>") == 0 )
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
                     return conditional_P00482(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (int)dynConstraints[6] , (long)dynConstraints[7] , (long)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (long)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (short)dynConstraints[16] , (short)dynConstraints[17] );
               case 1 :
                     return conditional_P00483(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (int)dynConstraints[6] , (long)dynConstraints[7] , (long)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (long)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (short)dynConstraints[16] , (short)dynConstraints[17] );
               case 2 :
                     return conditional_P00484(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (int)dynConstraints[6] , (long)dynConstraints[7] , (long)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (long)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (short)dynConstraints[16] , (short)dynConstraints[17] );
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
          Object[] prmP00482;
          prmP00482 = new Object[] {
          new ParDef("@AV46RubrosId",GXType.Int16,4,0) ,
          new ParDef("@lV13TFMedidasNombre",GXType.Char,50,0) ,
          new ParDef("@AV14TFMedidasNombre_Sel",GXType.NChar,50,0) ,
          new ParDef("@lV15TFRubrosNombre",GXType.Char,100,0) ,
          new ParDef("@AV16TFRubrosNombre_Sel",GXType.NChar,100,0) ,
          new ParDef("@AV19TFTextosId",GXType.Decimal,18,0) ,
          new ParDef("@AV20TFTextosId_To",GXType.Decimal,18,0) ,
          new ParDef("@lV21TFTextosTitulo",GXType.Char,80,0) ,
          new ParDef("@AV22TFTextosTitulo_Sel",GXType.NChar,80,0)
          };
          Object[] prmP00483;
          prmP00483 = new Object[] {
          new ParDef("@AV46RubrosId",GXType.Int16,4,0) ,
          new ParDef("@lV13TFMedidasNombre",GXType.Char,50,0) ,
          new ParDef("@AV14TFMedidasNombre_Sel",GXType.NChar,50,0) ,
          new ParDef("@lV15TFRubrosNombre",GXType.Char,100,0) ,
          new ParDef("@AV16TFRubrosNombre_Sel",GXType.NChar,100,0) ,
          new ParDef("@AV19TFTextosId",GXType.Decimal,18,0) ,
          new ParDef("@AV20TFTextosId_To",GXType.Decimal,18,0) ,
          new ParDef("@lV21TFTextosTitulo",GXType.Char,80,0) ,
          new ParDef("@AV22TFTextosTitulo_Sel",GXType.NChar,80,0)
          };
          Object[] prmP00484;
          prmP00484 = new Object[] {
          new ParDef("@AV46RubrosId",GXType.Int16,4,0) ,
          new ParDef("@lV13TFMedidasNombre",GXType.Char,50,0) ,
          new ParDef("@AV14TFMedidasNombre_Sel",GXType.NChar,50,0) ,
          new ParDef("@lV15TFRubrosNombre",GXType.Char,100,0) ,
          new ParDef("@AV16TFRubrosNombre_Sel",GXType.NChar,100,0) ,
          new ParDef("@AV19TFTextosId",GXType.Decimal,18,0) ,
          new ParDef("@AV20TFTextosId_To",GXType.Decimal,18,0) ,
          new ParDef("@lV21TFTextosTitulo",GXType.Char,80,0) ,
          new ParDef("@AV22TFTextosTitulo_Sel",GXType.NChar,80,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00482", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00482,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00483", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00483,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00484", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00484,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[1])[0] = rslt.getString(2, 50);
                ((string[]) buf[2])[0] = rslt.getString(3, 80);
                ((long[]) buf[3])[0] = rslt.getLong(4);
                ((bool[]) buf[4])[0] = rslt.wasNull(4);
                ((string[]) buf[5])[0] = rslt.getString(5, 3);
                ((bool[]) buf[6])[0] = rslt.wasNull(5);
                ((string[]) buf[7])[0] = rslt.getString(6, 100);
                ((long[]) buf[8])[0] = rslt.getLong(7);
                return;
             case 1 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 80);
                ((long[]) buf[2])[0] = rslt.getLong(3);
                ((bool[]) buf[3])[0] = rslt.wasNull(3);
                ((string[]) buf[4])[0] = rslt.getString(4, 3);
                ((bool[]) buf[5])[0] = rslt.wasNull(4);
                ((string[]) buf[6])[0] = rslt.getString(5, 100);
                ((string[]) buf[7])[0] = rslt.getString(6, 50);
                ((long[]) buf[8])[0] = rslt.getLong(7);
                return;
             case 2 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 80);
                ((long[]) buf[2])[0] = rslt.getLong(3);
                ((bool[]) buf[3])[0] = rslt.wasNull(3);
                ((string[]) buf[4])[0] = rslt.getString(4, 3);
                ((bool[]) buf[5])[0] = rslt.wasNull(4);
                ((string[]) buf[6])[0] = rslt.getString(5, 100);
                ((string[]) buf[7])[0] = rslt.getString(6, 50);
                ((long[]) buf[8])[0] = rslt.getLong(7);
                return;
       }
    }

 }

 [ServiceContract(Namespace = "GeneXus.Programs.rubrosinventariowcgetfilterdata_services")]
 [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple)]
 [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
 public class rubrosinventariowcgetfilterdata_services : GxRestService
 {
    [OperationContract(Name = "RubrosInventarioWCGetFilterData" )]
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
          if ( ! ProcessHeaders("rubrosinventariowcgetfilterdata") )
          {
             return  ;
          }
          rubrosinventariowcgetfilterdata worker = new rubrosinventariowcgetfilterdata(context);
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

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
   public class textospromptgetfilterdata : GXProcedure
   {
      public textospromptgetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public textospromptgetfilterdata( IGxContext context )
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
         this.AV35DDOName = aP0_DDOName;
         this.AV36SearchTxtParms = aP1_SearchTxtParms;
         this.AV37SearchTxtTo = aP2_SearchTxtTo;
         this.AV38OptionsJson = "" ;
         this.AV39OptionsDescJson = "" ;
         this.AV40OptionIndexesJson = "" ;
         initialize();
         ExecutePrivate();
         aP3_OptionsJson=this.AV38OptionsJson;
         aP4_OptionsDescJson=this.AV39OptionsDescJson;
         aP5_OptionIndexesJson=this.AV40OptionIndexesJson;
      }

      public string executeUdp( string aP0_DDOName ,
                                string aP1_SearchTxtParms ,
                                string aP2_SearchTxtTo ,
                                out string aP3_OptionsJson ,
                                out string aP4_OptionsDescJson )
      {
         execute(aP0_DDOName, aP1_SearchTxtParms, aP2_SearchTxtTo, out aP3_OptionsJson, out aP4_OptionsDescJson, out aP5_OptionIndexesJson);
         return AV40OptionIndexesJson ;
      }

      public void executeSubmit( string aP0_DDOName ,
                                 string aP1_SearchTxtParms ,
                                 string aP2_SearchTxtTo ,
                                 out string aP3_OptionsJson ,
                                 out string aP4_OptionsDescJson ,
                                 out string aP5_OptionIndexesJson )
      {
         this.AV35DDOName = aP0_DDOName;
         this.AV36SearchTxtParms = aP1_SearchTxtParms;
         this.AV37SearchTxtTo = aP2_SearchTxtTo;
         this.AV38OptionsJson = "" ;
         this.AV39OptionsDescJson = "" ;
         this.AV40OptionIndexesJson = "" ;
         SubmitImpl();
         aP3_OptionsJson=this.AV38OptionsJson;
         aP4_OptionsDescJson=this.AV39OptionsDescJson;
         aP5_OptionIndexesJson=this.AV40OptionIndexesJson;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV25Options = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV27OptionsDesc = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV28OptionIndexes = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         GXt_boolean1 = AV8IsAuthorized;
         new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWTextos", out  GXt_boolean1) ;
         AV8IsAuthorized = GXt_boolean1;
         if ( AV8IsAuthorized )
         {
            AV22MaxItems = 10;
            AV21PageIndex = (short)((String.IsNullOrEmpty(StringUtil.RTrim( AV36SearchTxtParms)) ? 0 : (long)(Math.Round(NumberUtil.Val( StringUtil.Substring( AV36SearchTxtParms, 1, 2), "."), 18, MidpointRounding.ToEven))));
            AV19SearchTxt = (String.IsNullOrEmpty(StringUtil.RTrim( AV36SearchTxtParms)) ? "" : StringUtil.Substring( AV36SearchTxtParms, 3, -1));
            AV20SkipItems = (short)(AV21PageIndex*AV22MaxItems);
            new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV9WWPContext) ;
            /* Execute user subroutine: 'LOADGRIDSTATE' */
            S111 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
            if ( StringUtil.StrCmp(StringUtil.Upper( AV35DDOName), "DDO_TEXTOSTIPO") == 0 )
            {
               /* Execute user subroutine: 'LOADTEXTOSTIPOOPTIONS' */
               S121 ();
               if ( returnInSub )
               {
                  cleanup();
                  if (true) return;
               }
            }
            else if ( StringUtil.StrCmp(StringUtil.Upper( AV35DDOName), "DDO_TEXTOSTITULO") == 0 )
            {
               /* Execute user subroutine: 'LOADTEXTOSTITULOOPTIONS' */
               S131 ();
               if ( returnInSub )
               {
                  cleanup();
                  if (true) return;
               }
            }
            else if ( StringUtil.StrCmp(StringUtil.Upper( AV35DDOName), "DDO_TEXTOSRUTAPDF") == 0 )
            {
               /* Execute user subroutine: 'LOADTEXTOSRUTAPDFOPTIONS' */
               S141 ();
               if ( returnInSub )
               {
                  cleanup();
                  if (true) return;
               }
            }
         }
         AV38OptionsJson = AV25Options.ToJSonString(false);
         AV39OptionsDescJson = AV27OptionsDesc.ToJSonString(false);
         AV40OptionIndexesJson = AV28OptionIndexes.ToJSonString(false);
         cleanup();
      }

      protected void S111( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV30Session.Get("TextosPromptGridState"), "") == 0 )
         {
            AV32GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "TextosPromptGridState"), null, "", "");
         }
         else
         {
            AV32GridState.FromXml(AV30Session.Get("TextosPromptGridState"), null, "", "");
         }
         AV44GXV1 = 1;
         while ( AV44GXV1 <= AV32GridState.gxTpr_Filtervalues.Count )
         {
            AV33GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV32GridState.gxTpr_Filtervalues.Item(AV44GXV1));
            if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV41FilterFullText = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFTEXTOSID") == 0 )
            {
               AV11TFTextosId = (long)(Math.Round(NumberUtil.Val( AV33GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV12TFTextosId_To = (long)(Math.Round(NumberUtil.Val( AV33GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFTEXTOSTIPO") == 0 )
            {
               AV13TFTextosTipo = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFTEXTOSTIPO_SEL") == 0 )
            {
               AV14TFTextosTipo_Sel = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFTEXTOSTITULO") == 0 )
            {
               AV15TFTextosTitulo = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFTEXTOSTITULO_SEL") == 0 )
            {
               AV16TFTextosTitulo_Sel = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFTEXTOSESTADO_SEL") == 0 )
            {
               AV17TFTextosEstado_SelsJson = AV33GridStateFilterValue.gxTpr_Value;
               AV18TFTextosEstado_Sels.FromJSonString(AV17TFTextosEstado_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFTEXTOSRUTAPDF") == 0 )
            {
               AV42TFTextosRutaPDF = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFTEXTOSRUTAPDF_SEL") == 0 )
            {
               AV43TFTextosRutaPDF_Sel = AV33GridStateFilterValue.gxTpr_Value;
            }
            AV44GXV1 = (int)(AV44GXV1+1);
         }
      }

      protected void S121( )
      {
         /* 'LOADTEXTOSTIPOOPTIONS' Routine */
         returnInSub = false;
         AV13TFTextosTipo = AV19SearchTxt;
         AV14TFTextosTipo_Sel = "";
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A534TextosEstado ,
                                              AV18TFTextosEstado_Sels ,
                                              AV11TFTextosId ,
                                              AV12TFTextosId_To ,
                                              AV14TFTextosTipo_Sel ,
                                              AV13TFTextosTipo ,
                                              AV16TFTextosTitulo_Sel ,
                                              AV15TFTextosTitulo ,
                                              AV18TFTextosEstado_Sels.Count ,
                                              AV43TFTextosRutaPDF_Sel ,
                                              AV42TFTextosRutaPDF ,
                                              A150TextosId ,
                                              A258TextosTipo ,
                                              A259TextosTitulo ,
                                              A977TextosRutaPDF ,
                                              AV41FilterFullText } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.INT, TypeConstants.LONG, TypeConstants.BOOLEAN
                                              }
         });
         lV13TFTextosTipo = StringUtil.PadR( StringUtil.RTrim( AV13TFTextosTipo), 20, "%");
         lV15TFTextosTitulo = StringUtil.PadR( StringUtil.RTrim( AV15TFTextosTitulo), 80, "%");
         lV42TFTextosRutaPDF = StringUtil.Concat( StringUtil.RTrim( AV42TFTextosRutaPDF), "%", "");
         /* Using cursor P00AU2 */
         pr_default.execute(0, new Object[] {AV11TFTextosId, AV12TFTextosId_To, lV13TFTextosTipo, AV14TFTextosTipo_Sel, lV15TFTextosTitulo, AV16TFTextosTitulo_Sel, lV42TFTextosRutaPDF, AV43TFTextosRutaPDF_Sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRKAU2 = false;
            A258TextosTipo = P00AU2_A258TextosTipo[0];
            A977TextosRutaPDF = P00AU2_A977TextosRutaPDF[0];
            n977TextosRutaPDF = P00AU2_n977TextosRutaPDF[0];
            A534TextosEstado = P00AU2_A534TextosEstado[0];
            n534TextosEstado = P00AU2_n534TextosEstado[0];
            A259TextosTitulo = P00AU2_A259TextosTitulo[0];
            A150TextosId = P00AU2_A150TextosId[0];
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV41FilterFullText)) || ( ( StringUtil.Like( StringUtil.Str( (decimal)(A150TextosId), 18, 0) , StringUtil.PadR( "%" + AV41FilterFullText , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A258TextosTipo) , StringUtil.PadR( "%" + StringUtil.Upper( AV41FilterFullText) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A259TextosTitulo) , StringUtil.PadR( "%" + StringUtil.Upper( AV41FilterFullText) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( context.GetMessage( "habilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV41FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A534TextosEstado, "HAB") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "deshabilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV41FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A534TextosEstado, "DES") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "pendiente", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV41FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A534TextosEstado, "PEN") == 0 ) ) || ( StringUtil.Like( StringUtil.Upper( A977TextosRutaPDF) , StringUtil.PadR( "%" + StringUtil.Upper( AV41FilterFullText) , 255 , "%"),  ' ' ) ) ) )
            {
               AV29count = 0;
               while ( (pr_default.getStatus(0) != 101) && ( StringUtil.StrCmp(P00AU2_A258TextosTipo[0], A258TextosTipo) == 0 ) )
               {
                  BRKAU2 = false;
                  A150TextosId = P00AU2_A150TextosId[0];
                  AV29count = (long)(AV29count+1);
                  BRKAU2 = true;
                  pr_default.readNext(0);
               }
               if ( (0==AV20SkipItems) )
               {
                  AV24Option = (String.IsNullOrEmpty(StringUtil.RTrim( A258TextosTipo)) ? "<#Empty#>" : A258TextosTipo);
                  AV25Options.Add(AV24Option, 0);
                  AV28OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV29count), "Z,ZZZ,ZZZ,ZZ9")), 0);
                  if ( AV25Options.Count == 10 )
                  {
                     /* Exit For each command. Update data (if necessary), close cursors & exit. */
                     if (true) break;
                  }
               }
               else
               {
                  AV20SkipItems = (short)(AV20SkipItems-1);
               }
            }
            if ( ! BRKAU2 )
            {
               BRKAU2 = true;
               pr_default.readNext(0);
            }
         }
         pr_default.close(0);
      }

      protected void S131( )
      {
         /* 'LOADTEXTOSTITULOOPTIONS' Routine */
         returnInSub = false;
         AV15TFTextosTitulo = AV19SearchTxt;
         AV16TFTextosTitulo_Sel = "";
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              A534TextosEstado ,
                                              AV18TFTextosEstado_Sels ,
                                              AV11TFTextosId ,
                                              AV12TFTextosId_To ,
                                              AV14TFTextosTipo_Sel ,
                                              AV13TFTextosTipo ,
                                              AV16TFTextosTitulo_Sel ,
                                              AV15TFTextosTitulo ,
                                              AV18TFTextosEstado_Sels.Count ,
                                              AV43TFTextosRutaPDF_Sel ,
                                              AV42TFTextosRutaPDF ,
                                              A150TextosId ,
                                              A258TextosTipo ,
                                              A259TextosTitulo ,
                                              A977TextosRutaPDF ,
                                              AV41FilterFullText } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.INT, TypeConstants.LONG, TypeConstants.BOOLEAN
                                              }
         });
         lV13TFTextosTipo = StringUtil.PadR( StringUtil.RTrim( AV13TFTextosTipo), 20, "%");
         lV15TFTextosTitulo = StringUtil.PadR( StringUtil.RTrim( AV15TFTextosTitulo), 80, "%");
         lV42TFTextosRutaPDF = StringUtil.Concat( StringUtil.RTrim( AV42TFTextosRutaPDF), "%", "");
         /* Using cursor P00AU3 */
         pr_default.execute(1, new Object[] {AV11TFTextosId, AV12TFTextosId_To, lV13TFTextosTipo, AV14TFTextosTipo_Sel, lV15TFTextosTitulo, AV16TFTextosTitulo_Sel, lV42TFTextosRutaPDF, AV43TFTextosRutaPDF_Sel});
         while ( (pr_default.getStatus(1) != 101) )
         {
            BRKAU4 = false;
            A259TextosTitulo = P00AU3_A259TextosTitulo[0];
            A977TextosRutaPDF = P00AU3_A977TextosRutaPDF[0];
            n977TextosRutaPDF = P00AU3_n977TextosRutaPDF[0];
            A534TextosEstado = P00AU3_A534TextosEstado[0];
            n534TextosEstado = P00AU3_n534TextosEstado[0];
            A258TextosTipo = P00AU3_A258TextosTipo[0];
            A150TextosId = P00AU3_A150TextosId[0];
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV41FilterFullText)) || ( ( StringUtil.Like( StringUtil.Str( (decimal)(A150TextosId), 18, 0) , StringUtil.PadR( "%" + AV41FilterFullText , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A258TextosTipo) , StringUtil.PadR( "%" + StringUtil.Upper( AV41FilterFullText) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A259TextosTitulo) , StringUtil.PadR( "%" + StringUtil.Upper( AV41FilterFullText) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( context.GetMessage( "habilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV41FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A534TextosEstado, "HAB") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "deshabilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV41FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A534TextosEstado, "DES") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "pendiente", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV41FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A534TextosEstado, "PEN") == 0 ) ) || ( StringUtil.Like( StringUtil.Upper( A977TextosRutaPDF) , StringUtil.PadR( "%" + StringUtil.Upper( AV41FilterFullText) , 255 , "%"),  ' ' ) ) ) )
            {
               AV29count = 0;
               while ( (pr_default.getStatus(1) != 101) && ( StringUtil.StrCmp(P00AU3_A259TextosTitulo[0], A259TextosTitulo) == 0 ) )
               {
                  BRKAU4 = false;
                  A150TextosId = P00AU3_A150TextosId[0];
                  AV29count = (long)(AV29count+1);
                  BRKAU4 = true;
                  pr_default.readNext(1);
               }
               if ( (0==AV20SkipItems) )
               {
                  AV24Option = (String.IsNullOrEmpty(StringUtil.RTrim( A259TextosTitulo)) ? "<#Empty#>" : A259TextosTitulo);
                  AV25Options.Add(AV24Option, 0);
                  AV28OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV29count), "Z,ZZZ,ZZZ,ZZ9")), 0);
                  if ( AV25Options.Count == 10 )
                  {
                     /* Exit For each command. Update data (if necessary), close cursors & exit. */
                     if (true) break;
                  }
               }
               else
               {
                  AV20SkipItems = (short)(AV20SkipItems-1);
               }
            }
            if ( ! BRKAU4 )
            {
               BRKAU4 = true;
               pr_default.readNext(1);
            }
         }
         pr_default.close(1);
      }

      protected void S141( )
      {
         /* 'LOADTEXTOSRUTAPDFOPTIONS' Routine */
         returnInSub = false;
         AV42TFTextosRutaPDF = AV19SearchTxt;
         AV43TFTextosRutaPDF_Sel = "";
         pr_default.dynParam(2, new Object[]{ new Object[]{
                                              A534TextosEstado ,
                                              AV18TFTextosEstado_Sels ,
                                              AV11TFTextosId ,
                                              AV12TFTextosId_To ,
                                              AV14TFTextosTipo_Sel ,
                                              AV13TFTextosTipo ,
                                              AV16TFTextosTitulo_Sel ,
                                              AV15TFTextosTitulo ,
                                              AV18TFTextosEstado_Sels.Count ,
                                              AV43TFTextosRutaPDF_Sel ,
                                              AV42TFTextosRutaPDF ,
                                              A150TextosId ,
                                              A258TextosTipo ,
                                              A259TextosTitulo ,
                                              A977TextosRutaPDF ,
                                              AV41FilterFullText } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.INT, TypeConstants.LONG, TypeConstants.BOOLEAN
                                              }
         });
         lV13TFTextosTipo = StringUtil.PadR( StringUtil.RTrim( AV13TFTextosTipo), 20, "%");
         lV15TFTextosTitulo = StringUtil.PadR( StringUtil.RTrim( AV15TFTextosTitulo), 80, "%");
         lV42TFTextosRutaPDF = StringUtil.Concat( StringUtil.RTrim( AV42TFTextosRutaPDF), "%", "");
         /* Using cursor P00AU4 */
         pr_default.execute(2, new Object[] {AV11TFTextosId, AV12TFTextosId_To, lV13TFTextosTipo, AV14TFTextosTipo_Sel, lV15TFTextosTitulo, AV16TFTextosTitulo_Sel, lV42TFTextosRutaPDF, AV43TFTextosRutaPDF_Sel});
         while ( (pr_default.getStatus(2) != 101) )
         {
            BRKAU6 = false;
            A977TextosRutaPDF = P00AU4_A977TextosRutaPDF[0];
            n977TextosRutaPDF = P00AU4_n977TextosRutaPDF[0];
            A534TextosEstado = P00AU4_A534TextosEstado[0];
            n534TextosEstado = P00AU4_n534TextosEstado[0];
            A259TextosTitulo = P00AU4_A259TextosTitulo[0];
            A258TextosTipo = P00AU4_A258TextosTipo[0];
            A150TextosId = P00AU4_A150TextosId[0];
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV41FilterFullText)) || ( ( StringUtil.Like( StringUtil.Str( (decimal)(A150TextosId), 18, 0) , StringUtil.PadR( "%" + AV41FilterFullText , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A258TextosTipo) , StringUtil.PadR( "%" + StringUtil.Upper( AV41FilterFullText) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A259TextosTitulo) , StringUtil.PadR( "%" + StringUtil.Upper( AV41FilterFullText) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( context.GetMessage( "habilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV41FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A534TextosEstado, "HAB") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "deshabilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV41FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A534TextosEstado, "DES") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "pendiente", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV41FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A534TextosEstado, "PEN") == 0 ) ) || ( StringUtil.Like( StringUtil.Upper( A977TextosRutaPDF) , StringUtil.PadR( "%" + StringUtil.Upper( AV41FilterFullText) , 255 , "%"),  ' ' ) ) ) )
            {
               AV29count = 0;
               while ( (pr_default.getStatus(2) != 101) && ( StringUtil.StrCmp(P00AU4_A977TextosRutaPDF[0], A977TextosRutaPDF) == 0 ) )
               {
                  BRKAU6 = false;
                  A150TextosId = P00AU4_A150TextosId[0];
                  AV29count = (long)(AV29count+1);
                  BRKAU6 = true;
                  pr_default.readNext(2);
               }
               if ( (0==AV20SkipItems) )
               {
                  AV24Option = (String.IsNullOrEmpty(StringUtil.RTrim( A977TextosRutaPDF)) ? "<#Empty#>" : A977TextosRutaPDF);
                  AV25Options.Add(AV24Option, 0);
                  AV28OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV29count), "Z,ZZZ,ZZZ,ZZ9")), 0);
                  if ( AV25Options.Count == 10 )
                  {
                     /* Exit For each command. Update data (if necessary), close cursors & exit. */
                     if (true) break;
                  }
               }
               else
               {
                  AV20SkipItems = (short)(AV20SkipItems-1);
               }
            }
            if ( ! BRKAU6 )
            {
               BRKAU6 = true;
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
         AV38OptionsJson = "";
         AV39OptionsDescJson = "";
         AV40OptionIndexesJson = "";
         AV25Options = new GxSimpleCollection<string>();
         AV27OptionsDesc = new GxSimpleCollection<string>();
         AV28OptionIndexes = new GxSimpleCollection<string>();
         AV19SearchTxt = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV30Session = context.GetSession();
         AV32GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV33GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV41FilterFullText = "";
         AV13TFTextosTipo = "";
         AV14TFTextosTipo_Sel = "";
         AV15TFTextosTitulo = "";
         AV16TFTextosTitulo_Sel = "";
         AV17TFTextosEstado_SelsJson = "";
         AV18TFTextosEstado_Sels = new GxSimpleCollection<string>();
         AV42TFTextosRutaPDF = "";
         AV43TFTextosRutaPDF_Sel = "";
         lV41FilterFullText = "";
         lV13TFTextosTipo = "";
         lV15TFTextosTitulo = "";
         lV42TFTextosRutaPDF = "";
         A534TextosEstado = "";
         A258TextosTipo = "";
         A259TextosTitulo = "";
         A977TextosRutaPDF = "";
         P00AU2_A258TextosTipo = new string[] {""} ;
         P00AU2_A977TextosRutaPDF = new string[] {""} ;
         P00AU2_n977TextosRutaPDF = new bool[] {false} ;
         P00AU2_A534TextosEstado = new string[] {""} ;
         P00AU2_n534TextosEstado = new bool[] {false} ;
         P00AU2_A259TextosTitulo = new string[] {""} ;
         P00AU2_A150TextosId = new long[1] ;
         AV24Option = "";
         P00AU3_A259TextosTitulo = new string[] {""} ;
         P00AU3_A977TextosRutaPDF = new string[] {""} ;
         P00AU3_n977TextosRutaPDF = new bool[] {false} ;
         P00AU3_A534TextosEstado = new string[] {""} ;
         P00AU3_n534TextosEstado = new bool[] {false} ;
         P00AU3_A258TextosTipo = new string[] {""} ;
         P00AU3_A150TextosId = new long[1] ;
         P00AU4_A977TextosRutaPDF = new string[] {""} ;
         P00AU4_n977TextosRutaPDF = new bool[] {false} ;
         P00AU4_A534TextosEstado = new string[] {""} ;
         P00AU4_n534TextosEstado = new bool[] {false} ;
         P00AU4_A259TextosTitulo = new string[] {""} ;
         P00AU4_A258TextosTipo = new string[] {""} ;
         P00AU4_A150TextosId = new long[1] ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.textospromptgetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P00AU2_A258TextosTipo, P00AU2_A977TextosRutaPDF, P00AU2_n977TextosRutaPDF, P00AU2_A534TextosEstado, P00AU2_n534TextosEstado, P00AU2_A259TextosTitulo, P00AU2_A150TextosId
               }
               , new Object[] {
               P00AU3_A259TextosTitulo, P00AU3_A977TextosRutaPDF, P00AU3_n977TextosRutaPDF, P00AU3_A534TextosEstado, P00AU3_n534TextosEstado, P00AU3_A258TextosTipo, P00AU3_A150TextosId
               }
               , new Object[] {
               P00AU4_A977TextosRutaPDF, P00AU4_n977TextosRutaPDF, P00AU4_A534TextosEstado, P00AU4_n534TextosEstado, P00AU4_A259TextosTitulo, P00AU4_A258TextosTipo, P00AU4_A150TextosId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV22MaxItems ;
      private short AV21PageIndex ;
      private short AV20SkipItems ;
      private int AV44GXV1 ;
      private int AV18TFTextosEstado_Sels_Count ;
      private long AV11TFTextosId ;
      private long AV12TFTextosId_To ;
      private long A150TextosId ;
      private long AV29count ;
      private string AV13TFTextosTipo ;
      private string AV14TFTextosTipo_Sel ;
      private string AV15TFTextosTitulo ;
      private string AV16TFTextosTitulo_Sel ;
      private string lV13TFTextosTipo ;
      private string lV15TFTextosTitulo ;
      private string A534TextosEstado ;
      private string A258TextosTipo ;
      private string A259TextosTitulo ;
      private bool AV8IsAuthorized ;
      private bool GXt_boolean1 ;
      private bool returnInSub ;
      private bool BRKAU2 ;
      private bool n977TextosRutaPDF ;
      private bool n534TextosEstado ;
      private bool BRKAU4 ;
      private bool BRKAU6 ;
      private string AV38OptionsJson ;
      private string AV39OptionsDescJson ;
      private string AV40OptionIndexesJson ;
      private string AV17TFTextosEstado_SelsJson ;
      private string AV35DDOName ;
      private string AV36SearchTxtParms ;
      private string AV37SearchTxtTo ;
      private string AV19SearchTxt ;
      private string AV41FilterFullText ;
      private string AV42TFTextosRutaPDF ;
      private string AV43TFTextosRutaPDF_Sel ;
      private string lV41FilterFullText ;
      private string lV42TFTextosRutaPDF ;
      private string A977TextosRutaPDF ;
      private string AV24Option ;
      private IGxSession AV30Session ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GxSimpleCollection<string> AV25Options ;
      private GxSimpleCollection<string> AV27OptionsDesc ;
      private GxSimpleCollection<string> AV28OptionIndexes ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV32GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV33GridStateFilterValue ;
      private GxSimpleCollection<string> AV18TFTextosEstado_Sels ;
      private IDataStoreProvider pr_default ;
      private string[] P00AU2_A258TextosTipo ;
      private string[] P00AU2_A977TextosRutaPDF ;
      private bool[] P00AU2_n977TextosRutaPDF ;
      private string[] P00AU2_A534TextosEstado ;
      private bool[] P00AU2_n534TextosEstado ;
      private string[] P00AU2_A259TextosTitulo ;
      private long[] P00AU2_A150TextosId ;
      private string[] P00AU3_A259TextosTitulo ;
      private string[] P00AU3_A977TextosRutaPDF ;
      private bool[] P00AU3_n977TextosRutaPDF ;
      private string[] P00AU3_A534TextosEstado ;
      private bool[] P00AU3_n534TextosEstado ;
      private string[] P00AU3_A258TextosTipo ;
      private long[] P00AU3_A150TextosId ;
      private string[] P00AU4_A977TextosRutaPDF ;
      private bool[] P00AU4_n977TextosRutaPDF ;
      private string[] P00AU4_A534TextosEstado ;
      private bool[] P00AU4_n534TextosEstado ;
      private string[] P00AU4_A259TextosTitulo ;
      private string[] P00AU4_A258TextosTipo ;
      private long[] P00AU4_A150TextosId ;
      private string aP3_OptionsJson ;
      private string aP4_OptionsDescJson ;
      private string aP5_OptionIndexesJson ;
   }

   public class textospromptgetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00AU2( IGxContext context ,
                                             string A534TextosEstado ,
                                             GxSimpleCollection<string> AV18TFTextosEstado_Sels ,
                                             long AV11TFTextosId ,
                                             long AV12TFTextosId_To ,
                                             string AV14TFTextosTipo_Sel ,
                                             string AV13TFTextosTipo ,
                                             string AV16TFTextosTitulo_Sel ,
                                             string AV15TFTextosTitulo ,
                                             int AV18TFTextosEstado_Sels_Count ,
                                             string AV43TFTextosRutaPDF_Sel ,
                                             string AV42TFTextosRutaPDF ,
                                             long A150TextosId ,
                                             string A258TextosTipo ,
                                             string A259TextosTitulo ,
                                             string A977TextosRutaPDF ,
                                             string AV41FilterFullText )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int2 = new short[8];
         Object[] GXv_Object3 = new Object[2];
         scmdbuf = "SELECT [TextosTipo], [TextosRutaPDF], [TextosEstado], [TextosTitulo], [TextosId] FROM [Textos]";
         if ( ! (0==AV11TFTextosId) )
         {
            AddWhere(sWhereString, "([TextosId] >= @AV11TFTextosId)");
         }
         else
         {
            GXv_int2[0] = 1;
         }
         if ( ! (0==AV12TFTextosId_To) )
         {
            AddWhere(sWhereString, "([TextosId] <= @AV12TFTextosId_To)");
         }
         else
         {
            GXv_int2[1] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV14TFTextosTipo_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV13TFTextosTipo)) ) )
         {
            AddWhere(sWhereString, "(UPPER([TextosTipo]) like UPPER(@lV13TFTextosTipo))");
         }
         else
         {
            GXv_int2[2] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV14TFTextosTipo_Sel)) && ! ( StringUtil.StrCmp(AV14TFTextosTipo_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([TextosTipo] = @AV14TFTextosTipo_Sel)");
         }
         else
         {
            GXv_int2[3] = 1;
         }
         if ( StringUtil.StrCmp(AV14TFTextosTipo_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([TextosTipo] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV16TFTextosTitulo_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV15TFTextosTitulo)) ) )
         {
            AddWhere(sWhereString, "(UPPER([TextosTitulo]) like UPPER(@lV15TFTextosTitulo))");
         }
         else
         {
            GXv_int2[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV16TFTextosTitulo_Sel)) && ! ( StringUtil.StrCmp(AV16TFTextosTitulo_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([TextosTitulo] = @AV16TFTextosTitulo_Sel)");
         }
         else
         {
            GXv_int2[5] = 1;
         }
         if ( StringUtil.StrCmp(AV16TFTextosTitulo_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([TextosTitulo] = ''))");
         }
         if ( AV18TFTextosEstado_Sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV18TFTextosEstado_Sels, "[TextosEstado] IN (", ")")+")");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV43TFTextosRutaPDF_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV42TFTextosRutaPDF)) ) )
         {
            AddWhere(sWhereString, "(UPPER([TextosRutaPDF]) like UPPER(@lV42TFTextosRutaPDF))");
         }
         else
         {
            GXv_int2[6] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV43TFTextosRutaPDF_Sel)) && ! ( StringUtil.StrCmp(AV43TFTextosRutaPDF_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([TextosRutaPDF] = @AV43TFTextosRutaPDF_Sel)");
         }
         else
         {
            GXv_int2[7] = 1;
         }
         if ( StringUtil.StrCmp(AV43TFTextosRutaPDF_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "([TextosRutaPDF] IS NULL or ([TextosRutaPDF] = ''))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY [TextosTipo]";
         GXv_Object3[0] = scmdbuf;
         GXv_Object3[1] = GXv_int2;
         return GXv_Object3 ;
      }

      protected Object[] conditional_P00AU3( IGxContext context ,
                                             string A534TextosEstado ,
                                             GxSimpleCollection<string> AV18TFTextosEstado_Sels ,
                                             long AV11TFTextosId ,
                                             long AV12TFTextosId_To ,
                                             string AV14TFTextosTipo_Sel ,
                                             string AV13TFTextosTipo ,
                                             string AV16TFTextosTitulo_Sel ,
                                             string AV15TFTextosTitulo ,
                                             int AV18TFTextosEstado_Sels_Count ,
                                             string AV43TFTextosRutaPDF_Sel ,
                                             string AV42TFTextosRutaPDF ,
                                             long A150TextosId ,
                                             string A258TextosTipo ,
                                             string A259TextosTitulo ,
                                             string A977TextosRutaPDF ,
                                             string AV41FilterFullText )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int4 = new short[8];
         Object[] GXv_Object5 = new Object[2];
         scmdbuf = "SELECT [TextosTitulo], [TextosRutaPDF], [TextosEstado], [TextosTipo], [TextosId] FROM [Textos]";
         if ( ! (0==AV11TFTextosId) )
         {
            AddWhere(sWhereString, "([TextosId] >= @AV11TFTextosId)");
         }
         else
         {
            GXv_int4[0] = 1;
         }
         if ( ! (0==AV12TFTextosId_To) )
         {
            AddWhere(sWhereString, "([TextosId] <= @AV12TFTextosId_To)");
         }
         else
         {
            GXv_int4[1] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV14TFTextosTipo_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV13TFTextosTipo)) ) )
         {
            AddWhere(sWhereString, "(UPPER([TextosTipo]) like UPPER(@lV13TFTextosTipo))");
         }
         else
         {
            GXv_int4[2] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV14TFTextosTipo_Sel)) && ! ( StringUtil.StrCmp(AV14TFTextosTipo_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([TextosTipo] = @AV14TFTextosTipo_Sel)");
         }
         else
         {
            GXv_int4[3] = 1;
         }
         if ( StringUtil.StrCmp(AV14TFTextosTipo_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([TextosTipo] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV16TFTextosTitulo_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV15TFTextosTitulo)) ) )
         {
            AddWhere(sWhereString, "(UPPER([TextosTitulo]) like UPPER(@lV15TFTextosTitulo))");
         }
         else
         {
            GXv_int4[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV16TFTextosTitulo_Sel)) && ! ( StringUtil.StrCmp(AV16TFTextosTitulo_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([TextosTitulo] = @AV16TFTextosTitulo_Sel)");
         }
         else
         {
            GXv_int4[5] = 1;
         }
         if ( StringUtil.StrCmp(AV16TFTextosTitulo_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([TextosTitulo] = ''))");
         }
         if ( AV18TFTextosEstado_Sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV18TFTextosEstado_Sels, "[TextosEstado] IN (", ")")+")");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV43TFTextosRutaPDF_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV42TFTextosRutaPDF)) ) )
         {
            AddWhere(sWhereString, "(UPPER([TextosRutaPDF]) like UPPER(@lV42TFTextosRutaPDF))");
         }
         else
         {
            GXv_int4[6] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV43TFTextosRutaPDF_Sel)) && ! ( StringUtil.StrCmp(AV43TFTextosRutaPDF_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([TextosRutaPDF] = @AV43TFTextosRutaPDF_Sel)");
         }
         else
         {
            GXv_int4[7] = 1;
         }
         if ( StringUtil.StrCmp(AV43TFTextosRutaPDF_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "([TextosRutaPDF] IS NULL or ([TextosRutaPDF] = ''))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY [TextosTitulo]";
         GXv_Object5[0] = scmdbuf;
         GXv_Object5[1] = GXv_int4;
         return GXv_Object5 ;
      }

      protected Object[] conditional_P00AU4( IGxContext context ,
                                             string A534TextosEstado ,
                                             GxSimpleCollection<string> AV18TFTextosEstado_Sels ,
                                             long AV11TFTextosId ,
                                             long AV12TFTextosId_To ,
                                             string AV14TFTextosTipo_Sel ,
                                             string AV13TFTextosTipo ,
                                             string AV16TFTextosTitulo_Sel ,
                                             string AV15TFTextosTitulo ,
                                             int AV18TFTextosEstado_Sels_Count ,
                                             string AV43TFTextosRutaPDF_Sel ,
                                             string AV42TFTextosRutaPDF ,
                                             long A150TextosId ,
                                             string A258TextosTipo ,
                                             string A259TextosTitulo ,
                                             string A977TextosRutaPDF ,
                                             string AV41FilterFullText )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int6 = new short[8];
         Object[] GXv_Object7 = new Object[2];
         scmdbuf = "SELECT [TextosRutaPDF], [TextosEstado], [TextosTitulo], [TextosTipo], [TextosId] FROM [Textos]";
         if ( ! (0==AV11TFTextosId) )
         {
            AddWhere(sWhereString, "([TextosId] >= @AV11TFTextosId)");
         }
         else
         {
            GXv_int6[0] = 1;
         }
         if ( ! (0==AV12TFTextosId_To) )
         {
            AddWhere(sWhereString, "([TextosId] <= @AV12TFTextosId_To)");
         }
         else
         {
            GXv_int6[1] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV14TFTextosTipo_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV13TFTextosTipo)) ) )
         {
            AddWhere(sWhereString, "(UPPER([TextosTipo]) like UPPER(@lV13TFTextosTipo))");
         }
         else
         {
            GXv_int6[2] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV14TFTextosTipo_Sel)) && ! ( StringUtil.StrCmp(AV14TFTextosTipo_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([TextosTipo] = @AV14TFTextosTipo_Sel)");
         }
         else
         {
            GXv_int6[3] = 1;
         }
         if ( StringUtil.StrCmp(AV14TFTextosTipo_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([TextosTipo] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV16TFTextosTitulo_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV15TFTextosTitulo)) ) )
         {
            AddWhere(sWhereString, "(UPPER([TextosTitulo]) like UPPER(@lV15TFTextosTitulo))");
         }
         else
         {
            GXv_int6[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV16TFTextosTitulo_Sel)) && ! ( StringUtil.StrCmp(AV16TFTextosTitulo_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([TextosTitulo] = @AV16TFTextosTitulo_Sel)");
         }
         else
         {
            GXv_int6[5] = 1;
         }
         if ( StringUtil.StrCmp(AV16TFTextosTitulo_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([TextosTitulo] = ''))");
         }
         if ( AV18TFTextosEstado_Sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV18TFTextosEstado_Sels, "[TextosEstado] IN (", ")")+")");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV43TFTextosRutaPDF_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV42TFTextosRutaPDF)) ) )
         {
            AddWhere(sWhereString, "(UPPER([TextosRutaPDF]) like UPPER(@lV42TFTextosRutaPDF))");
         }
         else
         {
            GXv_int6[6] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV43TFTextosRutaPDF_Sel)) && ! ( StringUtil.StrCmp(AV43TFTextosRutaPDF_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([TextosRutaPDF] = @AV43TFTextosRutaPDF_Sel)");
         }
         else
         {
            GXv_int6[7] = 1;
         }
         if ( StringUtil.StrCmp(AV43TFTextosRutaPDF_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "([TextosRutaPDF] IS NULL or ([TextosRutaPDF] = ''))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY [TextosRutaPDF]";
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
                     return conditional_P00AU2(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (long)dynConstraints[2] , (long)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (int)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (long)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] );
               case 1 :
                     return conditional_P00AU3(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (long)dynConstraints[2] , (long)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (int)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (long)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] );
               case 2 :
                     return conditional_P00AU4(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (long)dynConstraints[2] , (long)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (int)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (long)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] );
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
          Object[] prmP00AU2;
          prmP00AU2 = new Object[] {
          new ParDef("@AV11TFTextosId",GXType.Decimal,18,0) ,
          new ParDef("@AV12TFTextosId_To",GXType.Decimal,18,0) ,
          new ParDef("@lV13TFTextosTipo",GXType.Char,20,0) ,
          new ParDef("@AV14TFTextosTipo_Sel",GXType.NChar,20,0) ,
          new ParDef("@lV15TFTextosTitulo",GXType.Char,80,0) ,
          new ParDef("@AV16TFTextosTitulo_Sel",GXType.NChar,80,0) ,
          new ParDef("@lV42TFTextosRutaPDF",GXType.VarChar,100,0) ,
          new ParDef("@AV43TFTextosRutaPDF_Sel",GXType.NVarChar,100,0)
          };
          Object[] prmP00AU3;
          prmP00AU3 = new Object[] {
          new ParDef("@AV11TFTextosId",GXType.Decimal,18,0) ,
          new ParDef("@AV12TFTextosId_To",GXType.Decimal,18,0) ,
          new ParDef("@lV13TFTextosTipo",GXType.Char,20,0) ,
          new ParDef("@AV14TFTextosTipo_Sel",GXType.NChar,20,0) ,
          new ParDef("@lV15TFTextosTitulo",GXType.Char,80,0) ,
          new ParDef("@AV16TFTextosTitulo_Sel",GXType.NChar,80,0) ,
          new ParDef("@lV42TFTextosRutaPDF",GXType.VarChar,100,0) ,
          new ParDef("@AV43TFTextosRutaPDF_Sel",GXType.NVarChar,100,0)
          };
          Object[] prmP00AU4;
          prmP00AU4 = new Object[] {
          new ParDef("@AV11TFTextosId",GXType.Decimal,18,0) ,
          new ParDef("@AV12TFTextosId_To",GXType.Decimal,18,0) ,
          new ParDef("@lV13TFTextosTipo",GXType.Char,20,0) ,
          new ParDef("@AV14TFTextosTipo_Sel",GXType.NChar,20,0) ,
          new ParDef("@lV15TFTextosTitulo",GXType.Char,80,0) ,
          new ParDef("@AV16TFTextosTitulo_Sel",GXType.NChar,80,0) ,
          new ParDef("@lV42TFTextosRutaPDF",GXType.VarChar,100,0) ,
          new ParDef("@AV43TFTextosRutaPDF_Sel",GXType.NVarChar,100,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00AU2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00AU2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00AU3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00AU3,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00AU4", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00AU4,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[0])[0] = rslt.getString(1, 20);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getString(3, 3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getString(4, 80);
                ((long[]) buf[6])[0] = rslt.getLong(5);
                return;
             case 1 :
                ((string[]) buf[0])[0] = rslt.getString(1, 80);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getString(3, 3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getString(4, 20);
                ((long[]) buf[6])[0] = rslt.getLong(5);
                return;
             case 2 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getString(2, 3);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((string[]) buf[4])[0] = rslt.getString(3, 80);
                ((string[]) buf[5])[0] = rslt.getString(4, 20);
                ((long[]) buf[6])[0] = rslt.getLong(5);
                return;
       }
    }

 }

 [ServiceContract(Namespace = "GeneXus.Programs.textospromptgetfilterdata_services")]
 [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple)]
 [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
 public class textospromptgetfilterdata_services : GxRestService
 {
    [OperationContract(Name = "TextosPromptGetFilterData" )]
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
          if ( ! ProcessHeaders("textospromptgetfilterdata") )
          {
             return  ;
          }
          textospromptgetfilterdata worker = new textospromptgetfilterdata(context);
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

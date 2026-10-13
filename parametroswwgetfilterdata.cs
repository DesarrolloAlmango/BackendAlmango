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
   public class parametroswwgetfilterdata : GXProcedure
   {
      public parametroswwgetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public parametroswwgetfilterdata( IGxContext context )
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
         this.AV37DDOName = aP0_DDOName;
         this.AV38SearchTxtParms = aP1_SearchTxtParms;
         this.AV39SearchTxtTo = aP2_SearchTxtTo;
         this.AV40OptionsJson = "" ;
         this.AV41OptionsDescJson = "" ;
         this.AV42OptionIndexesJson = "" ;
         initialize();
         ExecutePrivate();
         aP3_OptionsJson=this.AV40OptionsJson;
         aP4_OptionsDescJson=this.AV41OptionsDescJson;
         aP5_OptionIndexesJson=this.AV42OptionIndexesJson;
      }

      public string executeUdp( string aP0_DDOName ,
                                string aP1_SearchTxtParms ,
                                string aP2_SearchTxtTo ,
                                out string aP3_OptionsJson ,
                                out string aP4_OptionsDescJson )
      {
         execute(aP0_DDOName, aP1_SearchTxtParms, aP2_SearchTxtTo, out aP3_OptionsJson, out aP4_OptionsDescJson, out aP5_OptionIndexesJson);
         return AV42OptionIndexesJson ;
      }

      public void executeSubmit( string aP0_DDOName ,
                                 string aP1_SearchTxtParms ,
                                 string aP2_SearchTxtTo ,
                                 out string aP3_OptionsJson ,
                                 out string aP4_OptionsDescJson ,
                                 out string aP5_OptionIndexesJson )
      {
         this.AV37DDOName = aP0_DDOName;
         this.AV38SearchTxtParms = aP1_SearchTxtParms;
         this.AV39SearchTxtTo = aP2_SearchTxtTo;
         this.AV40OptionsJson = "" ;
         this.AV41OptionsDescJson = "" ;
         this.AV42OptionIndexesJson = "" ;
         SubmitImpl();
         aP3_OptionsJson=this.AV40OptionsJson;
         aP4_OptionsDescJson=this.AV41OptionsDescJson;
         aP5_OptionIndexesJson=this.AV42OptionIndexesJson;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV27Options = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV29OptionsDesc = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV30OptionIndexes = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         GXt_boolean1 = AV8IsAuthorized;
         new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWParametros", out  GXt_boolean1) ;
         AV8IsAuthorized = GXt_boolean1;
         if ( AV8IsAuthorized )
         {
            AV24MaxItems = 10;
            AV23PageIndex = (short)((String.IsNullOrEmpty(StringUtil.RTrim( AV38SearchTxtParms)) ? 0 : (long)(Math.Round(NumberUtil.Val( StringUtil.Substring( AV38SearchTxtParms, 1, 2), "."), 18, MidpointRounding.ToEven))));
            AV21SearchTxt = (String.IsNullOrEmpty(StringUtil.RTrim( AV38SearchTxtParms)) ? "" : StringUtil.Substring( AV38SearchTxtParms, 3, -1));
            AV22SkipItems = (short)(AV23PageIndex*AV24MaxItems);
            new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV9WWPContext) ;
            /* Execute user subroutine: 'LOADGRIDSTATE' */
            S111 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
            if ( StringUtil.StrCmp(StringUtil.Upper( AV37DDOName), "DDO_PARAMETROSCODIGO") == 0 )
            {
               /* Execute user subroutine: 'LOADPARAMETROSCODIGOOPTIONS' */
               S121 ();
               if ( returnInSub )
               {
                  cleanup();
                  if (true) return;
               }
            }
            else if ( StringUtil.StrCmp(StringUtil.Upper( AV37DDOName), "DDO_PARAMETROSNOMBRE") == 0 )
            {
               /* Execute user subroutine: 'LOADPARAMETROSNOMBREOPTIONS' */
               S131 ();
               if ( returnInSub )
               {
                  cleanup();
                  if (true) return;
               }
            }
            else if ( StringUtil.StrCmp(StringUtil.Upper( AV37DDOName), "DDO_PARAMETROSVALOR") == 0 )
            {
               /* Execute user subroutine: 'LOADPARAMETROSVALOROPTIONS' */
               S141 ();
               if ( returnInSub )
               {
                  cleanup();
                  if (true) return;
               }
            }
         }
         AV40OptionsJson = AV27Options.ToJSonString(false);
         AV41OptionsDescJson = AV29OptionsDesc.ToJSonString(false);
         AV42OptionIndexesJson = AV30OptionIndexes.ToJSonString(false);
         cleanup();
      }

      protected void S111( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV32Session.Get("ParametrosWWGridState"), "") == 0 )
         {
            AV34GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "ParametrosWWGridState"), null, "", "");
         }
         else
         {
            AV34GridState.FromXml(AV32Session.Get("ParametrosWWGridState"), null, "", "");
         }
         AV46GXV1 = 1;
         while ( AV46GXV1 <= AV34GridState.gxTpr_Filtervalues.Count )
         {
            AV35GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV34GridState.gxTpr_Filtervalues.Item(AV46GXV1));
            if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV43FilterFullText = AV35GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFPARAMETROSID") == 0 )
            {
               AV11TFParametrosId = (long)(Math.Round(NumberUtil.Val( AV35GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV12TFParametrosId_To = (long)(Math.Round(NumberUtil.Val( AV35GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFPARAMETROSCODIGO") == 0 )
            {
               AV13TFParametrosCodigo = AV35GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFPARAMETROSCODIGO_SEL") == 0 )
            {
               AV14TFParametrosCodigo_Sel = AV35GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFPARAMETROSNOMBRE") == 0 )
            {
               AV15TFParametrosNombre = AV35GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFPARAMETROSNOMBRE_SEL") == 0 )
            {
               AV16TFParametrosNombre_Sel = AV35GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFPARAMETROSVALOR") == 0 )
            {
               AV17TFParametrosValor = AV35GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFPARAMETROSVALOR_SEL") == 0 )
            {
               AV18TFParametrosValor_Sel = AV35GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFPARAMETROSNUMERICO") == 0 )
            {
               AV44TFParametrosNumerico = (int)(Math.Round(NumberUtil.Val( AV35GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV45TFParametrosNumerico_To = (int)(Math.Round(NumberUtil.Val( AV35GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFPARAMETROSESTADO_SEL") == 0 )
            {
               AV19TFParametrosEstado_SelsJson = AV35GridStateFilterValue.gxTpr_Value;
               AV20TFParametrosEstado_Sels.FromJSonString(AV19TFParametrosEstado_SelsJson, null);
            }
            AV46GXV1 = (int)(AV46GXV1+1);
         }
      }

      protected void S121( )
      {
         /* 'LOADPARAMETROSCODIGOOPTIONS' Routine */
         returnInSub = false;
         AV13TFParametrosCodigo = AV21SearchTxt;
         AV14TFParametrosCodigo_Sel = "";
         AV48Parametroswwds_1_filterfulltext = AV43FilterFullText;
         AV49Parametroswwds_2_tfparametrosid = AV11TFParametrosId;
         AV50Parametroswwds_3_tfparametrosid_to = AV12TFParametrosId_To;
         AV51Parametroswwds_4_tfparametroscodigo = AV13TFParametrosCodigo;
         AV52Parametroswwds_5_tfparametroscodigo_sel = AV14TFParametrosCodigo_Sel;
         AV53Parametroswwds_6_tfparametrosnombre = AV15TFParametrosNombre;
         AV54Parametroswwds_7_tfparametrosnombre_sel = AV16TFParametrosNombre_Sel;
         AV55Parametroswwds_8_tfparametrosvalor = AV17TFParametrosValor;
         AV56Parametroswwds_9_tfparametrosvalor_sel = AV18TFParametrosValor_Sel;
         AV57Parametroswwds_10_tfparametrosnumerico = AV44TFParametrosNumerico;
         AV58Parametroswwds_11_tfparametrosnumerico_to = AV45TFParametrosNumerico_To;
         AV59Parametroswwds_12_tfparametrosestado_sels = AV20TFParametrosEstado_Sels;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A238ParametrosEstado ,
                                              AV59Parametroswwds_12_tfparametrosestado_sels ,
                                              AV49Parametroswwds_2_tfparametrosid ,
                                              AV50Parametroswwds_3_tfparametrosid_to ,
                                              AV52Parametroswwds_5_tfparametroscodigo_sel ,
                                              AV51Parametroswwds_4_tfparametroscodigo ,
                                              AV54Parametroswwds_7_tfparametrosnombre_sel ,
                                              AV53Parametroswwds_6_tfparametrosnombre ,
                                              AV56Parametroswwds_9_tfparametrosvalor_sel ,
                                              AV55Parametroswwds_8_tfparametrosvalor ,
                                              AV57Parametroswwds_10_tfparametrosnumerico ,
                                              AV58Parametroswwds_11_tfparametrosnumerico_to ,
                                              AV59Parametroswwds_12_tfparametrosestado_sels.Count ,
                                              A283ParametrosId ,
                                              A237ParametrosCodigo ,
                                              A284ParametrosNombre ,
                                              A602ParametrosValor ,
                                              A635ParametrosNumerico ,
                                              AV48Parametroswwds_1_filterfulltext } ,
                                              new int[]{
                                              TypeConstants.LONG, TypeConstants.LONG, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.LONG, TypeConstants.INT
                                              }
         });
         lV51Parametroswwds_4_tfparametroscodigo = StringUtil.PadR( StringUtil.RTrim( AV51Parametroswwds_4_tfparametroscodigo), 20, "%");
         lV53Parametroswwds_6_tfparametrosnombre = StringUtil.PadR( StringUtil.RTrim( AV53Parametroswwds_6_tfparametrosnombre), 80, "%");
         lV55Parametroswwds_8_tfparametrosvalor = StringUtil.Concat( StringUtil.RTrim( AV55Parametroswwds_8_tfparametrosvalor), "%", "");
         /* Using cursor P00B52 */
         pr_default.execute(0, new Object[] {AV49Parametroswwds_2_tfparametrosid, AV50Parametroswwds_3_tfparametrosid_to, lV51Parametroswwds_4_tfparametroscodigo, AV52Parametroswwds_5_tfparametroscodigo_sel, lV53Parametroswwds_6_tfparametrosnombre, AV54Parametroswwds_7_tfparametrosnombre_sel, lV55Parametroswwds_8_tfparametrosvalor, AV56Parametroswwds_9_tfparametrosvalor_sel, AV57Parametroswwds_10_tfparametrosnumerico, AV58Parametroswwds_11_tfparametrosnumerico_to});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRKB52 = false;
            A237ParametrosCodigo = P00B52_A237ParametrosCodigo[0];
            A635ParametrosNumerico = P00B52_A635ParametrosNumerico[0];
            A602ParametrosValor = P00B52_A602ParametrosValor[0];
            A284ParametrosNombre = P00B52_A284ParametrosNombre[0];
            A283ParametrosId = P00B52_A283ParametrosId[0];
            A238ParametrosEstado = P00B52_A238ParametrosEstado[0];
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV48Parametroswwds_1_filterfulltext)) || ( ( StringUtil.Like( StringUtil.Str( (decimal)(A283ParametrosId), 18, 0) , StringUtil.PadR( "%" + AV48Parametroswwds_1_filterfulltext , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A237ParametrosCodigo) , StringUtil.PadR( "%" + StringUtil.Upper( AV48Parametroswwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A284ParametrosNombre) , StringUtil.PadR( "%" + StringUtil.Upper( AV48Parametroswwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A602ParametrosValor) , StringUtil.PadR( "%" + StringUtil.Upper( AV48Parametroswwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Str( (decimal)(A635ParametrosNumerico), 9, 0) , StringUtil.PadR( "%" + AV48Parametroswwds_1_filterfulltext , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( context.GetMessage( "habilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV48Parametroswwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A238ParametrosEstado, "HAB") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "deshabilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV48Parametroswwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A238ParametrosEstado, "DES") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "pendiente", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV48Parametroswwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A238ParametrosEstado, "PEN") == 0 ) ) ) )
            {
               AV31count = 0;
               while ( (pr_default.getStatus(0) != 101) && ( StringUtil.StrCmp(P00B52_A237ParametrosCodigo[0], A237ParametrosCodigo) == 0 ) )
               {
                  BRKB52 = false;
                  A283ParametrosId = P00B52_A283ParametrosId[0];
                  AV31count = (long)(AV31count+1);
                  BRKB52 = true;
                  pr_default.readNext(0);
               }
               if ( (0==AV22SkipItems) )
               {
                  AV26Option = (String.IsNullOrEmpty(StringUtil.RTrim( A237ParametrosCodigo)) ? "<#Empty#>" : A237ParametrosCodigo);
                  AV27Options.Add(AV26Option, 0);
                  AV30OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV31count), "Z,ZZZ,ZZZ,ZZ9")), 0);
                  if ( AV27Options.Count == 10 )
                  {
                     /* Exit For each command. Update data (if necessary), close cursors & exit. */
                     if (true) break;
                  }
               }
               else
               {
                  AV22SkipItems = (short)(AV22SkipItems-1);
               }
            }
            if ( ! BRKB52 )
            {
               BRKB52 = true;
               pr_default.readNext(0);
            }
         }
         pr_default.close(0);
      }

      protected void S131( )
      {
         /* 'LOADPARAMETROSNOMBREOPTIONS' Routine */
         returnInSub = false;
         AV15TFParametrosNombre = AV21SearchTxt;
         AV16TFParametrosNombre_Sel = "";
         AV48Parametroswwds_1_filterfulltext = AV43FilterFullText;
         AV49Parametroswwds_2_tfparametrosid = AV11TFParametrosId;
         AV50Parametroswwds_3_tfparametrosid_to = AV12TFParametrosId_To;
         AV51Parametroswwds_4_tfparametroscodigo = AV13TFParametrosCodigo;
         AV52Parametroswwds_5_tfparametroscodigo_sel = AV14TFParametrosCodigo_Sel;
         AV53Parametroswwds_6_tfparametrosnombre = AV15TFParametrosNombre;
         AV54Parametroswwds_7_tfparametrosnombre_sel = AV16TFParametrosNombre_Sel;
         AV55Parametroswwds_8_tfparametrosvalor = AV17TFParametrosValor;
         AV56Parametroswwds_9_tfparametrosvalor_sel = AV18TFParametrosValor_Sel;
         AV57Parametroswwds_10_tfparametrosnumerico = AV44TFParametrosNumerico;
         AV58Parametroswwds_11_tfparametrosnumerico_to = AV45TFParametrosNumerico_To;
         AV59Parametroswwds_12_tfparametrosestado_sels = AV20TFParametrosEstado_Sels;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              A238ParametrosEstado ,
                                              AV59Parametroswwds_12_tfparametrosestado_sels ,
                                              AV49Parametroswwds_2_tfparametrosid ,
                                              AV50Parametroswwds_3_tfparametrosid_to ,
                                              AV52Parametroswwds_5_tfparametroscodigo_sel ,
                                              AV51Parametroswwds_4_tfparametroscodigo ,
                                              AV54Parametroswwds_7_tfparametrosnombre_sel ,
                                              AV53Parametroswwds_6_tfparametrosnombre ,
                                              AV56Parametroswwds_9_tfparametrosvalor_sel ,
                                              AV55Parametroswwds_8_tfparametrosvalor ,
                                              AV57Parametroswwds_10_tfparametrosnumerico ,
                                              AV58Parametroswwds_11_tfparametrosnumerico_to ,
                                              AV59Parametroswwds_12_tfparametrosestado_sels.Count ,
                                              A283ParametrosId ,
                                              A237ParametrosCodigo ,
                                              A284ParametrosNombre ,
                                              A602ParametrosValor ,
                                              A635ParametrosNumerico ,
                                              AV48Parametroswwds_1_filterfulltext } ,
                                              new int[]{
                                              TypeConstants.LONG, TypeConstants.LONG, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.LONG, TypeConstants.INT
                                              }
         });
         lV51Parametroswwds_4_tfparametroscodigo = StringUtil.PadR( StringUtil.RTrim( AV51Parametroswwds_4_tfparametroscodigo), 20, "%");
         lV53Parametroswwds_6_tfparametrosnombre = StringUtil.PadR( StringUtil.RTrim( AV53Parametroswwds_6_tfparametrosnombre), 80, "%");
         lV55Parametroswwds_8_tfparametrosvalor = StringUtil.Concat( StringUtil.RTrim( AV55Parametroswwds_8_tfparametrosvalor), "%", "");
         /* Using cursor P00B53 */
         pr_default.execute(1, new Object[] {AV49Parametroswwds_2_tfparametrosid, AV50Parametroswwds_3_tfparametrosid_to, lV51Parametroswwds_4_tfparametroscodigo, AV52Parametroswwds_5_tfparametroscodigo_sel, lV53Parametroswwds_6_tfparametrosnombre, AV54Parametroswwds_7_tfparametrosnombre_sel, lV55Parametroswwds_8_tfparametrosvalor, AV56Parametroswwds_9_tfparametrosvalor_sel, AV57Parametroswwds_10_tfparametrosnumerico, AV58Parametroswwds_11_tfparametrosnumerico_to});
         while ( (pr_default.getStatus(1) != 101) )
         {
            BRKB54 = false;
            A284ParametrosNombre = P00B53_A284ParametrosNombre[0];
            A635ParametrosNumerico = P00B53_A635ParametrosNumerico[0];
            A602ParametrosValor = P00B53_A602ParametrosValor[0];
            A237ParametrosCodigo = P00B53_A237ParametrosCodigo[0];
            A283ParametrosId = P00B53_A283ParametrosId[0];
            A238ParametrosEstado = P00B53_A238ParametrosEstado[0];
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV48Parametroswwds_1_filterfulltext)) || ( ( StringUtil.Like( StringUtil.Str( (decimal)(A283ParametrosId), 18, 0) , StringUtil.PadR( "%" + AV48Parametroswwds_1_filterfulltext , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A237ParametrosCodigo) , StringUtil.PadR( "%" + StringUtil.Upper( AV48Parametroswwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A284ParametrosNombre) , StringUtil.PadR( "%" + StringUtil.Upper( AV48Parametroswwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A602ParametrosValor) , StringUtil.PadR( "%" + StringUtil.Upper( AV48Parametroswwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Str( (decimal)(A635ParametrosNumerico), 9, 0) , StringUtil.PadR( "%" + AV48Parametroswwds_1_filterfulltext , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( context.GetMessage( "habilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV48Parametroswwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A238ParametrosEstado, "HAB") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "deshabilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV48Parametroswwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A238ParametrosEstado, "DES") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "pendiente", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV48Parametroswwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A238ParametrosEstado, "PEN") == 0 ) ) ) )
            {
               AV31count = 0;
               while ( (pr_default.getStatus(1) != 101) && ( StringUtil.StrCmp(P00B53_A284ParametrosNombre[0], A284ParametrosNombre) == 0 ) )
               {
                  BRKB54 = false;
                  A283ParametrosId = P00B53_A283ParametrosId[0];
                  AV31count = (long)(AV31count+1);
                  BRKB54 = true;
                  pr_default.readNext(1);
               }
               if ( (0==AV22SkipItems) )
               {
                  AV26Option = (String.IsNullOrEmpty(StringUtil.RTrim( A284ParametrosNombre)) ? "<#Empty#>" : A284ParametrosNombre);
                  AV27Options.Add(AV26Option, 0);
                  AV30OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV31count), "Z,ZZZ,ZZZ,ZZ9")), 0);
                  if ( AV27Options.Count == 10 )
                  {
                     /* Exit For each command. Update data (if necessary), close cursors & exit. */
                     if (true) break;
                  }
               }
               else
               {
                  AV22SkipItems = (short)(AV22SkipItems-1);
               }
            }
            if ( ! BRKB54 )
            {
               BRKB54 = true;
               pr_default.readNext(1);
            }
         }
         pr_default.close(1);
      }

      protected void S141( )
      {
         /* 'LOADPARAMETROSVALOROPTIONS' Routine */
         returnInSub = false;
         AV17TFParametrosValor = AV21SearchTxt;
         AV18TFParametrosValor_Sel = "";
         AV48Parametroswwds_1_filterfulltext = AV43FilterFullText;
         AV49Parametroswwds_2_tfparametrosid = AV11TFParametrosId;
         AV50Parametroswwds_3_tfparametrosid_to = AV12TFParametrosId_To;
         AV51Parametroswwds_4_tfparametroscodigo = AV13TFParametrosCodigo;
         AV52Parametroswwds_5_tfparametroscodigo_sel = AV14TFParametrosCodigo_Sel;
         AV53Parametroswwds_6_tfparametrosnombre = AV15TFParametrosNombre;
         AV54Parametroswwds_7_tfparametrosnombre_sel = AV16TFParametrosNombre_Sel;
         AV55Parametroswwds_8_tfparametrosvalor = AV17TFParametrosValor;
         AV56Parametroswwds_9_tfparametrosvalor_sel = AV18TFParametrosValor_Sel;
         AV57Parametroswwds_10_tfparametrosnumerico = AV44TFParametrosNumerico;
         AV58Parametroswwds_11_tfparametrosnumerico_to = AV45TFParametrosNumerico_To;
         AV59Parametroswwds_12_tfparametrosestado_sels = AV20TFParametrosEstado_Sels;
         pr_default.dynParam(2, new Object[]{ new Object[]{
                                              A238ParametrosEstado ,
                                              AV59Parametroswwds_12_tfparametrosestado_sels ,
                                              AV49Parametroswwds_2_tfparametrosid ,
                                              AV50Parametroswwds_3_tfparametrosid_to ,
                                              AV52Parametroswwds_5_tfparametroscodigo_sel ,
                                              AV51Parametroswwds_4_tfparametroscodigo ,
                                              AV54Parametroswwds_7_tfparametrosnombre_sel ,
                                              AV53Parametroswwds_6_tfparametrosnombre ,
                                              AV56Parametroswwds_9_tfparametrosvalor_sel ,
                                              AV55Parametroswwds_8_tfparametrosvalor ,
                                              AV57Parametroswwds_10_tfparametrosnumerico ,
                                              AV58Parametroswwds_11_tfparametrosnumerico_to ,
                                              AV59Parametroswwds_12_tfparametrosestado_sels.Count ,
                                              A283ParametrosId ,
                                              A237ParametrosCodigo ,
                                              A284ParametrosNombre ,
                                              A602ParametrosValor ,
                                              A635ParametrosNumerico ,
                                              AV48Parametroswwds_1_filterfulltext } ,
                                              new int[]{
                                              TypeConstants.LONG, TypeConstants.LONG, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.LONG, TypeConstants.INT
                                              }
         });
         lV51Parametroswwds_4_tfparametroscodigo = StringUtil.PadR( StringUtil.RTrim( AV51Parametroswwds_4_tfparametroscodigo), 20, "%");
         lV53Parametroswwds_6_tfparametrosnombre = StringUtil.PadR( StringUtil.RTrim( AV53Parametroswwds_6_tfparametrosnombre), 80, "%");
         lV55Parametroswwds_8_tfparametrosvalor = StringUtil.Concat( StringUtil.RTrim( AV55Parametroswwds_8_tfparametrosvalor), "%", "");
         /* Using cursor P00B54 */
         pr_default.execute(2, new Object[] {AV49Parametroswwds_2_tfparametrosid, AV50Parametroswwds_3_tfparametrosid_to, lV51Parametroswwds_4_tfparametroscodigo, AV52Parametroswwds_5_tfparametroscodigo_sel, lV53Parametroswwds_6_tfparametrosnombre, AV54Parametroswwds_7_tfparametrosnombre_sel, lV55Parametroswwds_8_tfparametrosvalor, AV56Parametroswwds_9_tfparametrosvalor_sel, AV57Parametroswwds_10_tfparametrosnumerico, AV58Parametroswwds_11_tfparametrosnumerico_to});
         while ( (pr_default.getStatus(2) != 101) )
         {
            BRKB56 = false;
            A602ParametrosValor = P00B54_A602ParametrosValor[0];
            A635ParametrosNumerico = P00B54_A635ParametrosNumerico[0];
            A284ParametrosNombre = P00B54_A284ParametrosNombre[0];
            A237ParametrosCodigo = P00B54_A237ParametrosCodigo[0];
            A283ParametrosId = P00B54_A283ParametrosId[0];
            A238ParametrosEstado = P00B54_A238ParametrosEstado[0];
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV48Parametroswwds_1_filterfulltext)) || ( ( StringUtil.Like( StringUtil.Str( (decimal)(A283ParametrosId), 18, 0) , StringUtil.PadR( "%" + AV48Parametroswwds_1_filterfulltext , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A237ParametrosCodigo) , StringUtil.PadR( "%" + StringUtil.Upper( AV48Parametroswwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A284ParametrosNombre) , StringUtil.PadR( "%" + StringUtil.Upper( AV48Parametroswwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A602ParametrosValor) , StringUtil.PadR( "%" + StringUtil.Upper( AV48Parametroswwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Str( (decimal)(A635ParametrosNumerico), 9, 0) , StringUtil.PadR( "%" + AV48Parametroswwds_1_filterfulltext , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( context.GetMessage( "habilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV48Parametroswwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A238ParametrosEstado, "HAB") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "deshabilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV48Parametroswwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A238ParametrosEstado, "DES") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "pendiente", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV48Parametroswwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A238ParametrosEstado, "PEN") == 0 ) ) ) )
            {
               AV31count = 0;
               while ( (pr_default.getStatus(2) != 101) && ( StringUtil.StrCmp(P00B54_A602ParametrosValor[0], A602ParametrosValor) == 0 ) )
               {
                  BRKB56 = false;
                  A283ParametrosId = P00B54_A283ParametrosId[0];
                  AV31count = (long)(AV31count+1);
                  BRKB56 = true;
                  pr_default.readNext(2);
               }
               if ( (0==AV22SkipItems) )
               {
                  AV26Option = (String.IsNullOrEmpty(StringUtil.RTrim( A602ParametrosValor)) ? "<#Empty#>" : A602ParametrosValor);
                  AV27Options.Add(AV26Option, 0);
                  AV30OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV31count), "Z,ZZZ,ZZZ,ZZ9")), 0);
                  if ( AV27Options.Count == 10 )
                  {
                     /* Exit For each command. Update data (if necessary), close cursors & exit. */
                     if (true) break;
                  }
               }
               else
               {
                  AV22SkipItems = (short)(AV22SkipItems-1);
               }
            }
            if ( ! BRKB56 )
            {
               BRKB56 = true;
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
         AV40OptionsJson = "";
         AV41OptionsDescJson = "";
         AV42OptionIndexesJson = "";
         AV27Options = new GxSimpleCollection<string>();
         AV29OptionsDesc = new GxSimpleCollection<string>();
         AV30OptionIndexes = new GxSimpleCollection<string>();
         AV21SearchTxt = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV32Session = context.GetSession();
         AV34GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV35GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV43FilterFullText = "";
         AV13TFParametrosCodigo = "";
         AV14TFParametrosCodigo_Sel = "";
         AV15TFParametrosNombre = "";
         AV16TFParametrosNombre_Sel = "";
         AV17TFParametrosValor = "";
         AV18TFParametrosValor_Sel = "";
         AV19TFParametrosEstado_SelsJson = "";
         AV20TFParametrosEstado_Sels = new GxSimpleCollection<string>();
         AV48Parametroswwds_1_filterfulltext = "";
         AV51Parametroswwds_4_tfparametroscodigo = "";
         AV52Parametroswwds_5_tfparametroscodigo_sel = "";
         AV53Parametroswwds_6_tfparametrosnombre = "";
         AV54Parametroswwds_7_tfparametrosnombre_sel = "";
         AV55Parametroswwds_8_tfparametrosvalor = "";
         AV56Parametroswwds_9_tfparametrosvalor_sel = "";
         AV59Parametroswwds_12_tfparametrosestado_sels = new GxSimpleCollection<string>();
         lV51Parametroswwds_4_tfparametroscodigo = "";
         lV53Parametroswwds_6_tfparametrosnombre = "";
         lV55Parametroswwds_8_tfparametrosvalor = "";
         A238ParametrosEstado = "";
         A237ParametrosCodigo = "";
         A284ParametrosNombre = "";
         A602ParametrosValor = "";
         P00B52_A237ParametrosCodigo = new string[] {""} ;
         P00B52_A635ParametrosNumerico = new int[1] ;
         P00B52_A602ParametrosValor = new string[] {""} ;
         P00B52_A284ParametrosNombre = new string[] {""} ;
         P00B52_A283ParametrosId = new long[1] ;
         P00B52_A238ParametrosEstado = new string[] {""} ;
         AV26Option = "";
         P00B53_A284ParametrosNombre = new string[] {""} ;
         P00B53_A635ParametrosNumerico = new int[1] ;
         P00B53_A602ParametrosValor = new string[] {""} ;
         P00B53_A237ParametrosCodigo = new string[] {""} ;
         P00B53_A283ParametrosId = new long[1] ;
         P00B53_A238ParametrosEstado = new string[] {""} ;
         P00B54_A602ParametrosValor = new string[] {""} ;
         P00B54_A635ParametrosNumerico = new int[1] ;
         P00B54_A284ParametrosNombre = new string[] {""} ;
         P00B54_A237ParametrosCodigo = new string[] {""} ;
         P00B54_A283ParametrosId = new long[1] ;
         P00B54_A238ParametrosEstado = new string[] {""} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.parametroswwgetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P00B52_A237ParametrosCodigo, P00B52_A635ParametrosNumerico, P00B52_A602ParametrosValor, P00B52_A284ParametrosNombre, P00B52_A283ParametrosId, P00B52_A238ParametrosEstado
               }
               , new Object[] {
               P00B53_A284ParametrosNombre, P00B53_A635ParametrosNumerico, P00B53_A602ParametrosValor, P00B53_A237ParametrosCodigo, P00B53_A283ParametrosId, P00B53_A238ParametrosEstado
               }
               , new Object[] {
               P00B54_A602ParametrosValor, P00B54_A635ParametrosNumerico, P00B54_A284ParametrosNombre, P00B54_A237ParametrosCodigo, P00B54_A283ParametrosId, P00B54_A238ParametrosEstado
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV24MaxItems ;
      private short AV23PageIndex ;
      private short AV22SkipItems ;
      private int AV46GXV1 ;
      private int AV44TFParametrosNumerico ;
      private int AV45TFParametrosNumerico_To ;
      private int AV57Parametroswwds_10_tfparametrosnumerico ;
      private int AV58Parametroswwds_11_tfparametrosnumerico_to ;
      private int AV59Parametroswwds_12_tfparametrosestado_sels_Count ;
      private int A635ParametrosNumerico ;
      private long AV11TFParametrosId ;
      private long AV12TFParametrosId_To ;
      private long AV49Parametroswwds_2_tfparametrosid ;
      private long AV50Parametroswwds_3_tfparametrosid_to ;
      private long A283ParametrosId ;
      private long AV31count ;
      private string AV13TFParametrosCodigo ;
      private string AV14TFParametrosCodigo_Sel ;
      private string AV15TFParametrosNombre ;
      private string AV16TFParametrosNombre_Sel ;
      private string AV51Parametroswwds_4_tfparametroscodigo ;
      private string AV52Parametroswwds_5_tfparametroscodigo_sel ;
      private string AV53Parametroswwds_6_tfparametrosnombre ;
      private string AV54Parametroswwds_7_tfparametrosnombre_sel ;
      private string lV51Parametroswwds_4_tfparametroscodigo ;
      private string lV53Parametroswwds_6_tfparametrosnombre ;
      private string A238ParametrosEstado ;
      private string A237ParametrosCodigo ;
      private string A284ParametrosNombre ;
      private bool AV8IsAuthorized ;
      private bool GXt_boolean1 ;
      private bool returnInSub ;
      private bool BRKB52 ;
      private bool BRKB54 ;
      private bool BRKB56 ;
      private string AV40OptionsJson ;
      private string AV41OptionsDescJson ;
      private string AV42OptionIndexesJson ;
      private string AV19TFParametrosEstado_SelsJson ;
      private string AV37DDOName ;
      private string AV38SearchTxtParms ;
      private string AV39SearchTxtTo ;
      private string AV21SearchTxt ;
      private string AV43FilterFullText ;
      private string AV17TFParametrosValor ;
      private string AV18TFParametrosValor_Sel ;
      private string AV48Parametroswwds_1_filterfulltext ;
      private string AV55Parametroswwds_8_tfparametrosvalor ;
      private string AV56Parametroswwds_9_tfparametrosvalor_sel ;
      private string lV55Parametroswwds_8_tfparametrosvalor ;
      private string A602ParametrosValor ;
      private string AV26Option ;
      private IGxSession AV32Session ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GxSimpleCollection<string> AV27Options ;
      private GxSimpleCollection<string> AV29OptionsDesc ;
      private GxSimpleCollection<string> AV30OptionIndexes ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV34GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV35GridStateFilterValue ;
      private GxSimpleCollection<string> AV20TFParametrosEstado_Sels ;
      private GxSimpleCollection<string> AV59Parametroswwds_12_tfparametrosestado_sels ;
      private IDataStoreProvider pr_default ;
      private string[] P00B52_A237ParametrosCodigo ;
      private int[] P00B52_A635ParametrosNumerico ;
      private string[] P00B52_A602ParametrosValor ;
      private string[] P00B52_A284ParametrosNombre ;
      private long[] P00B52_A283ParametrosId ;
      private string[] P00B52_A238ParametrosEstado ;
      private string[] P00B53_A284ParametrosNombre ;
      private int[] P00B53_A635ParametrosNumerico ;
      private string[] P00B53_A602ParametrosValor ;
      private string[] P00B53_A237ParametrosCodigo ;
      private long[] P00B53_A283ParametrosId ;
      private string[] P00B53_A238ParametrosEstado ;
      private string[] P00B54_A602ParametrosValor ;
      private int[] P00B54_A635ParametrosNumerico ;
      private string[] P00B54_A284ParametrosNombre ;
      private string[] P00B54_A237ParametrosCodigo ;
      private long[] P00B54_A283ParametrosId ;
      private string[] P00B54_A238ParametrosEstado ;
      private string aP3_OptionsJson ;
      private string aP4_OptionsDescJson ;
      private string aP5_OptionIndexesJson ;
   }

   public class parametroswwgetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00B52( IGxContext context ,
                                             string A238ParametrosEstado ,
                                             GxSimpleCollection<string> AV59Parametroswwds_12_tfparametrosestado_sels ,
                                             long AV49Parametroswwds_2_tfparametrosid ,
                                             long AV50Parametroswwds_3_tfparametrosid_to ,
                                             string AV52Parametroswwds_5_tfparametroscodigo_sel ,
                                             string AV51Parametroswwds_4_tfparametroscodigo ,
                                             string AV54Parametroswwds_7_tfparametrosnombre_sel ,
                                             string AV53Parametroswwds_6_tfparametrosnombre ,
                                             string AV56Parametroswwds_9_tfparametrosvalor_sel ,
                                             string AV55Parametroswwds_8_tfparametrosvalor ,
                                             int AV57Parametroswwds_10_tfparametrosnumerico ,
                                             int AV58Parametroswwds_11_tfparametrosnumerico_to ,
                                             int AV59Parametroswwds_12_tfparametrosestado_sels_Count ,
                                             long A283ParametrosId ,
                                             string A237ParametrosCodigo ,
                                             string A284ParametrosNombre ,
                                             string A602ParametrosValor ,
                                             int A635ParametrosNumerico ,
                                             string AV48Parametroswwds_1_filterfulltext )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int2 = new short[10];
         Object[] GXv_Object3 = new Object[2];
         scmdbuf = "SELECT [ParametrosCodigo], [ParametrosNumerico], [ParametrosValor], [ParametrosNombre], [ParametrosId], [ParametrosEstado] FROM [Parametros]";
         if ( ! (0==AV49Parametroswwds_2_tfparametrosid) )
         {
            AddWhere(sWhereString, "([ParametrosId] >= @AV49Parametroswwds_2_tfparametrosid)");
         }
         else
         {
            GXv_int2[0] = 1;
         }
         if ( ! (0==AV50Parametroswwds_3_tfparametrosid_to) )
         {
            AddWhere(sWhereString, "([ParametrosId] <= @AV50Parametroswwds_3_tfparametrosid_to)");
         }
         else
         {
            GXv_int2[1] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV52Parametroswwds_5_tfparametroscodigo_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV51Parametroswwds_4_tfparametroscodigo)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ParametrosCodigo]) like UPPER(@lV51Parametroswwds_4_tfparametroscodigo))");
         }
         else
         {
            GXv_int2[2] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV52Parametroswwds_5_tfparametroscodigo_sel)) && ! ( StringUtil.StrCmp(AV52Parametroswwds_5_tfparametroscodigo_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([ParametrosCodigo] = @AV52Parametroswwds_5_tfparametroscodigo_sel)");
         }
         else
         {
            GXv_int2[3] = 1;
         }
         if ( StringUtil.StrCmp(AV52Parametroswwds_5_tfparametroscodigo_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([ParametrosCodigo] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV54Parametroswwds_7_tfparametrosnombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV53Parametroswwds_6_tfparametrosnombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ParametrosNombre]) like UPPER(@lV53Parametroswwds_6_tfparametrosnombre))");
         }
         else
         {
            GXv_int2[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV54Parametroswwds_7_tfparametrosnombre_sel)) && ! ( StringUtil.StrCmp(AV54Parametroswwds_7_tfparametrosnombre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([ParametrosNombre] = @AV54Parametroswwds_7_tfparametrosnombre_sel)");
         }
         else
         {
            GXv_int2[5] = 1;
         }
         if ( StringUtil.StrCmp(AV54Parametroswwds_7_tfparametrosnombre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([ParametrosNombre] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV56Parametroswwds_9_tfparametrosvalor_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV55Parametroswwds_8_tfparametrosvalor)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ParametrosValor]) like UPPER(@lV55Parametroswwds_8_tfparametrosvalor))");
         }
         else
         {
            GXv_int2[6] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV56Parametroswwds_9_tfparametrosvalor_sel)) && ! ( StringUtil.StrCmp(AV56Parametroswwds_9_tfparametrosvalor_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([ParametrosValor] = @AV56Parametroswwds_9_tfparametrosvalor_sel)");
         }
         else
         {
            GXv_int2[7] = 1;
         }
         if ( StringUtil.StrCmp(AV56Parametroswwds_9_tfparametrosvalor_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([ParametrosValor] = ''))");
         }
         if ( ! (0==AV57Parametroswwds_10_tfparametrosnumerico) )
         {
            AddWhere(sWhereString, "([ParametrosNumerico] >= @AV57Parametroswwds_10_tfparametrosnumerico)");
         }
         else
         {
            GXv_int2[8] = 1;
         }
         if ( ! (0==AV58Parametroswwds_11_tfparametrosnumerico_to) )
         {
            AddWhere(sWhereString, "([ParametrosNumerico] <= @AV58Parametroswwds_11_tfparametrosnumerico_to)");
         }
         else
         {
            GXv_int2[9] = 1;
         }
         if ( AV59Parametroswwds_12_tfparametrosestado_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV59Parametroswwds_12_tfparametrosestado_sels, "[ParametrosEstado] IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY [ParametrosCodigo]";
         GXv_Object3[0] = scmdbuf;
         GXv_Object3[1] = GXv_int2;
         return GXv_Object3 ;
      }

      protected Object[] conditional_P00B53( IGxContext context ,
                                             string A238ParametrosEstado ,
                                             GxSimpleCollection<string> AV59Parametroswwds_12_tfparametrosestado_sels ,
                                             long AV49Parametroswwds_2_tfparametrosid ,
                                             long AV50Parametroswwds_3_tfparametrosid_to ,
                                             string AV52Parametroswwds_5_tfparametroscodigo_sel ,
                                             string AV51Parametroswwds_4_tfparametroscodigo ,
                                             string AV54Parametroswwds_7_tfparametrosnombre_sel ,
                                             string AV53Parametroswwds_6_tfparametrosnombre ,
                                             string AV56Parametroswwds_9_tfparametrosvalor_sel ,
                                             string AV55Parametroswwds_8_tfparametrosvalor ,
                                             int AV57Parametroswwds_10_tfparametrosnumerico ,
                                             int AV58Parametroswwds_11_tfparametrosnumerico_to ,
                                             int AV59Parametroswwds_12_tfparametrosestado_sels_Count ,
                                             long A283ParametrosId ,
                                             string A237ParametrosCodigo ,
                                             string A284ParametrosNombre ,
                                             string A602ParametrosValor ,
                                             int A635ParametrosNumerico ,
                                             string AV48Parametroswwds_1_filterfulltext )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int4 = new short[10];
         Object[] GXv_Object5 = new Object[2];
         scmdbuf = "SELECT [ParametrosNombre], [ParametrosNumerico], [ParametrosValor], [ParametrosCodigo], [ParametrosId], [ParametrosEstado] FROM [Parametros]";
         if ( ! (0==AV49Parametroswwds_2_tfparametrosid) )
         {
            AddWhere(sWhereString, "([ParametrosId] >= @AV49Parametroswwds_2_tfparametrosid)");
         }
         else
         {
            GXv_int4[0] = 1;
         }
         if ( ! (0==AV50Parametroswwds_3_tfparametrosid_to) )
         {
            AddWhere(sWhereString, "([ParametrosId] <= @AV50Parametroswwds_3_tfparametrosid_to)");
         }
         else
         {
            GXv_int4[1] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV52Parametroswwds_5_tfparametroscodigo_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV51Parametroswwds_4_tfparametroscodigo)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ParametrosCodigo]) like UPPER(@lV51Parametroswwds_4_tfparametroscodigo))");
         }
         else
         {
            GXv_int4[2] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV52Parametroswwds_5_tfparametroscodigo_sel)) && ! ( StringUtil.StrCmp(AV52Parametroswwds_5_tfparametroscodigo_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([ParametrosCodigo] = @AV52Parametroswwds_5_tfparametroscodigo_sel)");
         }
         else
         {
            GXv_int4[3] = 1;
         }
         if ( StringUtil.StrCmp(AV52Parametroswwds_5_tfparametroscodigo_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([ParametrosCodigo] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV54Parametroswwds_7_tfparametrosnombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV53Parametroswwds_6_tfparametrosnombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ParametrosNombre]) like UPPER(@lV53Parametroswwds_6_tfparametrosnombre))");
         }
         else
         {
            GXv_int4[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV54Parametroswwds_7_tfparametrosnombre_sel)) && ! ( StringUtil.StrCmp(AV54Parametroswwds_7_tfparametrosnombre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([ParametrosNombre] = @AV54Parametroswwds_7_tfparametrosnombre_sel)");
         }
         else
         {
            GXv_int4[5] = 1;
         }
         if ( StringUtil.StrCmp(AV54Parametroswwds_7_tfparametrosnombre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([ParametrosNombre] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV56Parametroswwds_9_tfparametrosvalor_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV55Parametroswwds_8_tfparametrosvalor)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ParametrosValor]) like UPPER(@lV55Parametroswwds_8_tfparametrosvalor))");
         }
         else
         {
            GXv_int4[6] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV56Parametroswwds_9_tfparametrosvalor_sel)) && ! ( StringUtil.StrCmp(AV56Parametroswwds_9_tfparametrosvalor_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([ParametrosValor] = @AV56Parametroswwds_9_tfparametrosvalor_sel)");
         }
         else
         {
            GXv_int4[7] = 1;
         }
         if ( StringUtil.StrCmp(AV56Parametroswwds_9_tfparametrosvalor_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([ParametrosValor] = ''))");
         }
         if ( ! (0==AV57Parametroswwds_10_tfparametrosnumerico) )
         {
            AddWhere(sWhereString, "([ParametrosNumerico] >= @AV57Parametroswwds_10_tfparametrosnumerico)");
         }
         else
         {
            GXv_int4[8] = 1;
         }
         if ( ! (0==AV58Parametroswwds_11_tfparametrosnumerico_to) )
         {
            AddWhere(sWhereString, "([ParametrosNumerico] <= @AV58Parametroswwds_11_tfparametrosnumerico_to)");
         }
         else
         {
            GXv_int4[9] = 1;
         }
         if ( AV59Parametroswwds_12_tfparametrosestado_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV59Parametroswwds_12_tfparametrosestado_sels, "[ParametrosEstado] IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY [ParametrosNombre]";
         GXv_Object5[0] = scmdbuf;
         GXv_Object5[1] = GXv_int4;
         return GXv_Object5 ;
      }

      protected Object[] conditional_P00B54( IGxContext context ,
                                             string A238ParametrosEstado ,
                                             GxSimpleCollection<string> AV59Parametroswwds_12_tfparametrosestado_sels ,
                                             long AV49Parametroswwds_2_tfparametrosid ,
                                             long AV50Parametroswwds_3_tfparametrosid_to ,
                                             string AV52Parametroswwds_5_tfparametroscodigo_sel ,
                                             string AV51Parametroswwds_4_tfparametroscodigo ,
                                             string AV54Parametroswwds_7_tfparametrosnombre_sel ,
                                             string AV53Parametroswwds_6_tfparametrosnombre ,
                                             string AV56Parametroswwds_9_tfparametrosvalor_sel ,
                                             string AV55Parametroswwds_8_tfparametrosvalor ,
                                             int AV57Parametroswwds_10_tfparametrosnumerico ,
                                             int AV58Parametroswwds_11_tfparametrosnumerico_to ,
                                             int AV59Parametroswwds_12_tfparametrosestado_sels_Count ,
                                             long A283ParametrosId ,
                                             string A237ParametrosCodigo ,
                                             string A284ParametrosNombre ,
                                             string A602ParametrosValor ,
                                             int A635ParametrosNumerico ,
                                             string AV48Parametroswwds_1_filterfulltext )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int6 = new short[10];
         Object[] GXv_Object7 = new Object[2];
         scmdbuf = "SELECT [ParametrosValor], [ParametrosNumerico], [ParametrosNombre], [ParametrosCodigo], [ParametrosId], [ParametrosEstado] FROM [Parametros]";
         if ( ! (0==AV49Parametroswwds_2_tfparametrosid) )
         {
            AddWhere(sWhereString, "([ParametrosId] >= @AV49Parametroswwds_2_tfparametrosid)");
         }
         else
         {
            GXv_int6[0] = 1;
         }
         if ( ! (0==AV50Parametroswwds_3_tfparametrosid_to) )
         {
            AddWhere(sWhereString, "([ParametrosId] <= @AV50Parametroswwds_3_tfparametrosid_to)");
         }
         else
         {
            GXv_int6[1] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV52Parametroswwds_5_tfparametroscodigo_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV51Parametroswwds_4_tfparametroscodigo)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ParametrosCodigo]) like UPPER(@lV51Parametroswwds_4_tfparametroscodigo))");
         }
         else
         {
            GXv_int6[2] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV52Parametroswwds_5_tfparametroscodigo_sel)) && ! ( StringUtil.StrCmp(AV52Parametroswwds_5_tfparametroscodigo_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([ParametrosCodigo] = @AV52Parametroswwds_5_tfparametroscodigo_sel)");
         }
         else
         {
            GXv_int6[3] = 1;
         }
         if ( StringUtil.StrCmp(AV52Parametroswwds_5_tfparametroscodigo_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([ParametrosCodigo] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV54Parametroswwds_7_tfparametrosnombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV53Parametroswwds_6_tfparametrosnombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ParametrosNombre]) like UPPER(@lV53Parametroswwds_6_tfparametrosnombre))");
         }
         else
         {
            GXv_int6[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV54Parametroswwds_7_tfparametrosnombre_sel)) && ! ( StringUtil.StrCmp(AV54Parametroswwds_7_tfparametrosnombre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([ParametrosNombre] = @AV54Parametroswwds_7_tfparametrosnombre_sel)");
         }
         else
         {
            GXv_int6[5] = 1;
         }
         if ( StringUtil.StrCmp(AV54Parametroswwds_7_tfparametrosnombre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([ParametrosNombre] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV56Parametroswwds_9_tfparametrosvalor_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV55Parametroswwds_8_tfparametrosvalor)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ParametrosValor]) like UPPER(@lV55Parametroswwds_8_tfparametrosvalor))");
         }
         else
         {
            GXv_int6[6] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV56Parametroswwds_9_tfparametrosvalor_sel)) && ! ( StringUtil.StrCmp(AV56Parametroswwds_9_tfparametrosvalor_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([ParametrosValor] = @AV56Parametroswwds_9_tfparametrosvalor_sel)");
         }
         else
         {
            GXv_int6[7] = 1;
         }
         if ( StringUtil.StrCmp(AV56Parametroswwds_9_tfparametrosvalor_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([ParametrosValor] = ''))");
         }
         if ( ! (0==AV57Parametroswwds_10_tfparametrosnumerico) )
         {
            AddWhere(sWhereString, "([ParametrosNumerico] >= @AV57Parametroswwds_10_tfparametrosnumerico)");
         }
         else
         {
            GXv_int6[8] = 1;
         }
         if ( ! (0==AV58Parametroswwds_11_tfparametrosnumerico_to) )
         {
            AddWhere(sWhereString, "([ParametrosNumerico] <= @AV58Parametroswwds_11_tfparametrosnumerico_to)");
         }
         else
         {
            GXv_int6[9] = 1;
         }
         if ( AV59Parametroswwds_12_tfparametrosestado_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV59Parametroswwds_12_tfparametrosestado_sels, "[ParametrosEstado] IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY [ParametrosValor]";
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
                     return conditional_P00B52(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (long)dynConstraints[2] , (long)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (int)dynConstraints[10] , (int)dynConstraints[11] , (int)dynConstraints[12] , (long)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (int)dynConstraints[17] , (string)dynConstraints[18] );
               case 1 :
                     return conditional_P00B53(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (long)dynConstraints[2] , (long)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (int)dynConstraints[10] , (int)dynConstraints[11] , (int)dynConstraints[12] , (long)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (int)dynConstraints[17] , (string)dynConstraints[18] );
               case 2 :
                     return conditional_P00B54(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (long)dynConstraints[2] , (long)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (int)dynConstraints[10] , (int)dynConstraints[11] , (int)dynConstraints[12] , (long)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (int)dynConstraints[17] , (string)dynConstraints[18] );
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
          Object[] prmP00B52;
          prmP00B52 = new Object[] {
          new ParDef("@AV49Parametroswwds_2_tfparametrosid",GXType.Decimal,18,0) ,
          new ParDef("@AV50Parametroswwds_3_tfparametrosid_to",GXType.Decimal,18,0) ,
          new ParDef("@lV51Parametroswwds_4_tfparametroscodigo",GXType.Char,20,0) ,
          new ParDef("@AV52Parametroswwds_5_tfparametroscodigo_sel",GXType.NChar,20,0) ,
          new ParDef("@lV53Parametroswwds_6_tfparametrosnombre",GXType.Char,80,0) ,
          new ParDef("@AV54Parametroswwds_7_tfparametrosnombre_sel",GXType.NChar,80,0) ,
          new ParDef("@lV55Parametroswwds_8_tfparametrosvalor",GXType.VarChar,255,0) ,
          new ParDef("@AV56Parametroswwds_9_tfparametrosvalor_sel",GXType.NVarChar,255,0) ,
          new ParDef("@AV57Parametroswwds_10_tfparametrosnumerico",GXType.Int32,9,0) ,
          new ParDef("@AV58Parametroswwds_11_tfparametrosnumerico_to",GXType.Int32,9,0)
          };
          Object[] prmP00B53;
          prmP00B53 = new Object[] {
          new ParDef("@AV49Parametroswwds_2_tfparametrosid",GXType.Decimal,18,0) ,
          new ParDef("@AV50Parametroswwds_3_tfparametrosid_to",GXType.Decimal,18,0) ,
          new ParDef("@lV51Parametroswwds_4_tfparametroscodigo",GXType.Char,20,0) ,
          new ParDef("@AV52Parametroswwds_5_tfparametroscodigo_sel",GXType.NChar,20,0) ,
          new ParDef("@lV53Parametroswwds_6_tfparametrosnombre",GXType.Char,80,0) ,
          new ParDef("@AV54Parametroswwds_7_tfparametrosnombre_sel",GXType.NChar,80,0) ,
          new ParDef("@lV55Parametroswwds_8_tfparametrosvalor",GXType.VarChar,255,0) ,
          new ParDef("@AV56Parametroswwds_9_tfparametrosvalor_sel",GXType.NVarChar,255,0) ,
          new ParDef("@AV57Parametroswwds_10_tfparametrosnumerico",GXType.Int32,9,0) ,
          new ParDef("@AV58Parametroswwds_11_tfparametrosnumerico_to",GXType.Int32,9,0)
          };
          Object[] prmP00B54;
          prmP00B54 = new Object[] {
          new ParDef("@AV49Parametroswwds_2_tfparametrosid",GXType.Decimal,18,0) ,
          new ParDef("@AV50Parametroswwds_3_tfparametrosid_to",GXType.Decimal,18,0) ,
          new ParDef("@lV51Parametroswwds_4_tfparametroscodigo",GXType.Char,20,0) ,
          new ParDef("@AV52Parametroswwds_5_tfparametroscodigo_sel",GXType.NChar,20,0) ,
          new ParDef("@lV53Parametroswwds_6_tfparametrosnombre",GXType.Char,80,0) ,
          new ParDef("@AV54Parametroswwds_7_tfparametrosnombre_sel",GXType.NChar,80,0) ,
          new ParDef("@lV55Parametroswwds_8_tfparametrosvalor",GXType.VarChar,255,0) ,
          new ParDef("@AV56Parametroswwds_9_tfparametrosvalor_sel",GXType.NVarChar,255,0) ,
          new ParDef("@AV57Parametroswwds_10_tfparametrosnumerico",GXType.Int32,9,0) ,
          new ParDef("@AV58Parametroswwds_11_tfparametrosnumerico_to",GXType.Int32,9,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00B52", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00B52,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00B53", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00B53,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00B54", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00B54,100, GxCacheFrequency.OFF ,true,false )
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
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 80);
                ((long[]) buf[4])[0] = rslt.getLong(5);
                ((string[]) buf[5])[0] = rslt.getString(6, 3);
                return;
             case 1 :
                ((string[]) buf[0])[0] = rslt.getString(1, 80);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 20);
                ((long[]) buf[4])[0] = rslt.getLong(5);
                ((string[]) buf[5])[0] = rslt.getString(6, 3);
                return;
             case 2 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 80);
                ((string[]) buf[3])[0] = rslt.getString(4, 20);
                ((long[]) buf[4])[0] = rslt.getLong(5);
                ((string[]) buf[5])[0] = rslt.getString(6, 3);
                return;
       }
    }

 }

 [ServiceContract(Namespace = "GeneXus.Programs.parametroswwgetfilterdata_services")]
 [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple)]
 [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
 public class parametroswwgetfilterdata_services : GxRestService
 {
    [OperationContract(Name = "ParametrosWWGetFilterData" )]
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
          if ( ! ProcessHeaders("parametroswwgetfilterdata") )
          {
             return  ;
          }
          parametroswwgetfilterdata worker = new parametroswwgetfilterdata(context);
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

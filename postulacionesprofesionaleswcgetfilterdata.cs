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
   public class postulacionesprofesionaleswcgetfilterdata : GXProcedure
   {
      public postulacionesprofesionaleswcgetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public postulacionesprofesionaleswcgetfilterdata( IGxContext context )
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
         this.AV29DDOName = aP0_DDOName;
         this.AV30SearchTxtParms = aP1_SearchTxtParms;
         this.AV31SearchTxtTo = aP2_SearchTxtTo;
         this.AV32OptionsJson = "" ;
         this.AV33OptionsDescJson = "" ;
         this.AV34OptionIndexesJson = "" ;
         initialize();
         ExecutePrivate();
         aP3_OptionsJson=this.AV32OptionsJson;
         aP4_OptionsDescJson=this.AV33OptionsDescJson;
         aP5_OptionIndexesJson=this.AV34OptionIndexesJson;
      }

      public string executeUdp( string aP0_DDOName ,
                                string aP1_SearchTxtParms ,
                                string aP2_SearchTxtTo ,
                                out string aP3_OptionsJson ,
                                out string aP4_OptionsDescJson )
      {
         execute(aP0_DDOName, aP1_SearchTxtParms, aP2_SearchTxtTo, out aP3_OptionsJson, out aP4_OptionsDescJson, out aP5_OptionIndexesJson);
         return AV34OptionIndexesJson ;
      }

      public void executeSubmit( string aP0_DDOName ,
                                 string aP1_SearchTxtParms ,
                                 string aP2_SearchTxtTo ,
                                 out string aP3_OptionsJson ,
                                 out string aP4_OptionsDescJson ,
                                 out string aP5_OptionIndexesJson )
      {
         this.AV29DDOName = aP0_DDOName;
         this.AV30SearchTxtParms = aP1_SearchTxtParms;
         this.AV31SearchTxtTo = aP2_SearchTxtTo;
         this.AV32OptionsJson = "" ;
         this.AV33OptionsDescJson = "" ;
         this.AV34OptionIndexesJson = "" ;
         SubmitImpl();
         aP3_OptionsJson=this.AV32OptionsJson;
         aP4_OptionsDescJson=this.AV33OptionsDescJson;
         aP5_OptionIndexesJson=this.AV34OptionIndexesJson;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV19Options = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV21OptionsDesc = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV22OptionIndexes = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         GXt_boolean1 = AV8IsAuthorized;
         new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWPostulaciones", out  GXt_boolean1) ;
         AV8IsAuthorized = GXt_boolean1;
         if ( AV8IsAuthorized )
         {
            AV16MaxItems = 10;
            AV15PageIndex = (short)((String.IsNullOrEmpty(StringUtil.RTrim( AV30SearchTxtParms)) ? 0 : (long)(Math.Round(NumberUtil.Val( StringUtil.Substring( AV30SearchTxtParms, 1, 2), "."), 18, MidpointRounding.ToEven))));
            AV13SearchTxt = (String.IsNullOrEmpty(StringUtil.RTrim( AV30SearchTxtParms)) ? "" : StringUtil.Substring( AV30SearchTxtParms, 3, -1));
            AV14SkipItems = (short)(AV15PageIndex*AV16MaxItems);
            new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV9WWPContext) ;
            /* Execute user subroutine: 'LOADGRIDSTATE' */
            S111 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
            if ( StringUtil.StrCmp(StringUtil.Upper( AV29DDOName), "DDO_PROFESIONALESNOMBRECOMPLETO") == 0 )
            {
               /* Execute user subroutine: 'LOADPROFESIONALESNOMBRECOMPLETOOPTIONS' */
               S121 ();
               if ( returnInSub )
               {
                  cleanup();
                  if (true) return;
               }
            }
            else if ( StringUtil.StrCmp(StringUtil.Upper( AV29DDOName), "DDO_POSTULACIONPROFESIONALA") == 0 )
            {
               /* Execute user subroutine: 'LOADPOSTULACIONPROFESIONALAOPTIONS' */
               S131 ();
               if ( returnInSub )
               {
                  cleanup();
                  if (true) return;
               }
            }
         }
         AV32OptionsJson = AV19Options.ToJSonString(false);
         AV33OptionsDescJson = AV21OptionsDesc.ToJSonString(false);
         AV34OptionIndexesJson = AV22OptionIndexes.ToJSonString(false);
         cleanup();
      }

      protected void S111( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV24Session.Get("PostulacionesProfesionalesWCGridState"), "") == 0 )
         {
            AV26GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "PostulacionesProfesionalesWCGridState"), null, "", "");
         }
         else
         {
            AV26GridState.FromXml(AV24Session.Get("PostulacionesProfesionalesWCGridState"), null, "", "");
         }
         AV48GXV1 = 1;
         while ( AV48GXV1 <= AV26GridState.gxTpr_Filtervalues.Count )
         {
            AV27GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV26GridState.gxTpr_Filtervalues.Item(AV48GXV1));
            if ( StringUtil.StrCmp(AV27GridStateFilterValue.gxTpr_Name, "TFPROFESIONALESNOMBRECOMPLETO") == 0 )
            {
               AV11TFProfesionalesNombreCompleto = AV27GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV27GridStateFilterValue.gxTpr_Name, "TFPROFESIONALESNOMBRECOMPLETO_SEL") == 0 )
            {
               AV12TFProfesionalesNombreCompleto_Sel = AV27GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV27GridStateFilterValue.gxTpr_Name, "TFPOSTULACIONPROFESIONALPRECIO") == 0 )
            {
               AV36TFPostulacionProfesionalPrecio = NumberUtil.Val( AV27GridStateFilterValue.gxTpr_Value, ".");
               AV37TFPostulacionProfesionalPrecio_To = NumberUtil.Val( AV27GridStateFilterValue.gxTpr_Valueto, ".");
            }
            else if ( StringUtil.StrCmp(AV27GridStateFilterValue.gxTpr_Name, "TFPOSTULACIONPROFESIONALPLAZOE") == 0 )
            {
               AV38TFPostulacionProfesionalPlazoE = (short)(Math.Round(NumberUtil.Val( AV27GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV39TFPostulacionProfesionalPlazoE_To = (short)(Math.Round(NumberUtil.Val( AV27GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV27GridStateFilterValue.gxTpr_Name, "TFPOSTULACIONPROFESIONALUNIE_SEL") == 0 )
            {
               AV40TFPostulacionProfesionalUniE_SelsJson = AV27GridStateFilterValue.gxTpr_Value;
               AV41TFPostulacionProfesionalUniE_Sels.FromJSonString(AV40TFPostulacionProfesionalUniE_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV27GridStateFilterValue.gxTpr_Name, "TFPOSTULACIONPROFESIONALGAR") == 0 )
            {
               AV44TFPostulacionProfesionalGar = (short)(Math.Round(NumberUtil.Val( AV27GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV45TFPostulacionProfesionalGar_To = (short)(Math.Round(NumberUtil.Val( AV27GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV27GridStateFilterValue.gxTpr_Name, "TFPOSTULACIONPROFESIONALUNIG_SEL") == 0 )
            {
               AV42TFPostulacionProfesionalUniG_SelsJson = AV27GridStateFilterValue.gxTpr_Value;
               AV43TFPostulacionProfesionalUniG_Sels.FromJSonString(AV42TFPostulacionProfesionalUniG_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV27GridStateFilterValue.gxTpr_Name, "TFPOSTULACIONPROFESIONALA") == 0 )
            {
               AV46TFPostulacionProfesionalA = AV27GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV27GridStateFilterValue.gxTpr_Name, "TFPOSTULACIONPROFESIONALA_SEL") == 0 )
            {
               AV47TFPostulacionProfesionalA_Sel = AV27GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV27GridStateFilterValue.gxTpr_Name, "PARM_&POSTULACIONESID") == 0 )
            {
               AV35PostulacionesId = (long)(Math.Round(NumberUtil.Val( AV27GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
            }
            AV48GXV1 = (int)(AV48GXV1+1);
         }
      }

      protected void S121( )
      {
         /* 'LOADPROFESIONALESNOMBRECOMPLETOOPTIONS' Routine */
         returnInSub = false;
         AV11TFProfesionalesNombreCompleto = AV13SearchTxt;
         AV12TFProfesionalesNombreCompleto_Sel = "";
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A986PostulacionProfesionalUniE ,
                                              AV41TFPostulacionProfesionalUniE_Sels ,
                                              A987PostulacionProfesionalUniG ,
                                              AV43TFPostulacionProfesionalUniG_Sels ,
                                              AV12TFProfesionalesNombreCompleto_Sel ,
                                              AV11TFProfesionalesNombreCompleto ,
                                              AV36TFPostulacionProfesionalPrecio ,
                                              AV37TFPostulacionProfesionalPrecio_To ,
                                              AV38TFPostulacionProfesionalPlazoE ,
                                              AV39TFPostulacionProfesionalPlazoE_To ,
                                              AV41TFPostulacionProfesionalUniE_Sels.Count ,
                                              AV44TFPostulacionProfesionalGar ,
                                              AV45TFPostulacionProfesionalGar_To ,
                                              AV43TFPostulacionProfesionalUniG_Sels.Count ,
                                              AV47TFPostulacionProfesionalA_Sel ,
                                              AV46TFPostulacionProfesionalA ,
                                              A167ProfesionalesApellidoPrimero ,
                                              A166ProfesionalesPrimerNombre ,
                                              A191ProfesionalesSegundoNombre ,
                                              A982PostulacionProfesionalPrecio ,
                                              A983PostulacionProfesionalPlazoE ,
                                              A985PostulacionProfesionalGar ,
                                              A984PostulacionProfesionalA ,
                                              AV35PostulacionesId ,
                                              A422PostulacionesId } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.INT,
                                              TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.LONG, TypeConstants.LONG
                                              }
         });
         lV11TFProfesionalesNombreCompleto = StringUtil.Concat( StringUtil.RTrim( AV11TFProfesionalesNombreCompleto), "%", "");
         lV46TFPostulacionProfesionalA = StringUtil.Concat( StringUtil.RTrim( AV46TFPostulacionProfesionalA), "%", "");
         /* Using cursor P00M72 */
         pr_default.execute(0, new Object[] {AV35PostulacionesId, lV11TFProfesionalesNombreCompleto, AV12TFProfesionalesNombreCompleto_Sel, AV36TFPostulacionProfesionalPrecio, AV37TFPostulacionProfesionalPrecio_To, AV38TFPostulacionProfesionalPlazoE, AV39TFPostulacionProfesionalPlazoE_To, AV44TFPostulacionProfesionalGar, AV45TFPostulacionProfesionalGar_To, lV46TFPostulacionProfesionalA, AV47TFPostulacionProfesionalA_Sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A120ProfesionalesId = P00M72_A120ProfesionalesId[0];
            A984PostulacionProfesionalA = P00M72_A984PostulacionProfesionalA[0];
            n984PostulacionProfesionalA = P00M72_n984PostulacionProfesionalA[0];
            A987PostulacionProfesionalUniG = P00M72_A987PostulacionProfesionalUniG[0];
            n987PostulacionProfesionalUniG = P00M72_n987PostulacionProfesionalUniG[0];
            A985PostulacionProfesionalGar = P00M72_A985PostulacionProfesionalGar[0];
            n985PostulacionProfesionalGar = P00M72_n985PostulacionProfesionalGar[0];
            A986PostulacionProfesionalUniE = P00M72_A986PostulacionProfesionalUniE[0];
            n986PostulacionProfesionalUniE = P00M72_n986PostulacionProfesionalUniE[0];
            A983PostulacionProfesionalPlazoE = P00M72_A983PostulacionProfesionalPlazoE[0];
            n983PostulacionProfesionalPlazoE = P00M72_n983PostulacionProfesionalPlazoE[0];
            A982PostulacionProfesionalPrecio = P00M72_A982PostulacionProfesionalPrecio[0];
            n982PostulacionProfesionalPrecio = P00M72_n982PostulacionProfesionalPrecio[0];
            A422PostulacionesId = P00M72_A422PostulacionesId[0];
            A191ProfesionalesSegundoNombre = P00M72_A191ProfesionalesSegundoNombre[0];
            A166ProfesionalesPrimerNombre = P00M72_A166ProfesionalesPrimerNombre[0];
            A167ProfesionalesApellidoPrimero = P00M72_A167ProfesionalesApellidoPrimero[0];
            A191ProfesionalesSegundoNombre = P00M72_A191ProfesionalesSegundoNombre[0];
            A166ProfesionalesPrimerNombre = P00M72_A166ProfesionalesPrimerNombre[0];
            A167ProfesionalesApellidoPrimero = P00M72_A167ProfesionalesApellidoPrimero[0];
            A886ProfesionalesNombreCompleto = StringUtil.Trim( A167ProfesionalesApellidoPrimero) + ", " + StringUtil.Trim( A166ProfesionalesPrimerNombre) + " " + StringUtil.Trim( A191ProfesionalesSegundoNombre);
            AV18Option = (String.IsNullOrEmpty(StringUtil.RTrim( A886ProfesionalesNombreCompleto)) ? "<#Empty#>" : A886ProfesionalesNombreCompleto);
            AV17InsertIndex = 1;
            while ( ( StringUtil.StrCmp(AV18Option, "<#Empty#>") != 0 ) && ( AV17InsertIndex <= AV19Options.Count ) && ( ( StringUtil.StrCmp(((string)AV19Options.Item(AV17InsertIndex)), AV18Option) < 0 ) || ( StringUtil.StrCmp(((string)AV19Options.Item(AV17InsertIndex)), "<#Empty#>") == 0 ) ) )
            {
               AV17InsertIndex = (int)(AV17InsertIndex+1);
            }
            if ( ( AV17InsertIndex <= AV19Options.Count ) && ( StringUtil.StrCmp(((string)AV19Options.Item(AV17InsertIndex)), AV18Option) == 0 ) )
            {
               AV23count = (long)(Math.Round(NumberUtil.Val( ((string)AV22OptionIndexes.Item(AV17InsertIndex)), "."), 18, MidpointRounding.ToEven));
               AV23count = (long)(AV23count+1);
               AV22OptionIndexes.RemoveItem(AV17InsertIndex);
               AV22OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV23count), "Z,ZZZ,ZZZ,ZZ9")), AV17InsertIndex);
            }
            else
            {
               AV19Options.Add(AV18Option, AV17InsertIndex);
               AV22OptionIndexes.Add("1", AV17InsertIndex);
            }
            if ( AV19Options.Count == AV14SkipItems + 11 )
            {
               AV19Options.RemoveItem(AV19Options.Count);
               AV22OptionIndexes.RemoveItem(AV22OptionIndexes.Count);
            }
            pr_default.readNext(0);
         }
         pr_default.close(0);
         while ( AV14SkipItems > 0 )
         {
            AV19Options.RemoveItem(1);
            AV22OptionIndexes.RemoveItem(1);
            AV14SkipItems = (short)(AV14SkipItems-1);
         }
      }

      protected void S131( )
      {
         /* 'LOADPOSTULACIONPROFESIONALAOPTIONS' Routine */
         returnInSub = false;
         AV46TFPostulacionProfesionalA = AV13SearchTxt;
         AV47TFPostulacionProfesionalA_Sel = "";
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              A986PostulacionProfesionalUniE ,
                                              AV41TFPostulacionProfesionalUniE_Sels ,
                                              A987PostulacionProfesionalUniG ,
                                              AV43TFPostulacionProfesionalUniG_Sels ,
                                              AV12TFProfesionalesNombreCompleto_Sel ,
                                              AV11TFProfesionalesNombreCompleto ,
                                              AV36TFPostulacionProfesionalPrecio ,
                                              AV37TFPostulacionProfesionalPrecio_To ,
                                              AV38TFPostulacionProfesionalPlazoE ,
                                              AV39TFPostulacionProfesionalPlazoE_To ,
                                              AV41TFPostulacionProfesionalUniE_Sels.Count ,
                                              AV44TFPostulacionProfesionalGar ,
                                              AV45TFPostulacionProfesionalGar_To ,
                                              AV43TFPostulacionProfesionalUniG_Sels.Count ,
                                              AV47TFPostulacionProfesionalA_Sel ,
                                              AV46TFPostulacionProfesionalA ,
                                              A167ProfesionalesApellidoPrimero ,
                                              A166ProfesionalesPrimerNombre ,
                                              A191ProfesionalesSegundoNombre ,
                                              A982PostulacionProfesionalPrecio ,
                                              A983PostulacionProfesionalPlazoE ,
                                              A985PostulacionProfesionalGar ,
                                              A984PostulacionProfesionalA ,
                                              AV35PostulacionesId ,
                                              A422PostulacionesId } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.INT,
                                              TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.LONG, TypeConstants.LONG
                                              }
         });
         lV11TFProfesionalesNombreCompleto = StringUtil.Concat( StringUtil.RTrim( AV11TFProfesionalesNombreCompleto), "%", "");
         lV46TFPostulacionProfesionalA = StringUtil.Concat( StringUtil.RTrim( AV46TFPostulacionProfesionalA), "%", "");
         /* Using cursor P00M73 */
         pr_default.execute(1, new Object[] {AV35PostulacionesId, lV11TFProfesionalesNombreCompleto, AV12TFProfesionalesNombreCompleto_Sel, AV36TFPostulacionProfesionalPrecio, AV37TFPostulacionProfesionalPrecio_To, AV38TFPostulacionProfesionalPlazoE, AV39TFPostulacionProfesionalPlazoE_To, AV44TFPostulacionProfesionalGar, AV45TFPostulacionProfesionalGar_To, lV46TFPostulacionProfesionalA, AV47TFPostulacionProfesionalA_Sel});
         while ( (pr_default.getStatus(1) != 101) )
         {
            BRKM73 = false;
            A120ProfesionalesId = P00M73_A120ProfesionalesId[0];
            A422PostulacionesId = P00M73_A422PostulacionesId[0];
            A984PostulacionProfesionalA = P00M73_A984PostulacionProfesionalA[0];
            n984PostulacionProfesionalA = P00M73_n984PostulacionProfesionalA[0];
            A987PostulacionProfesionalUniG = P00M73_A987PostulacionProfesionalUniG[0];
            n987PostulacionProfesionalUniG = P00M73_n987PostulacionProfesionalUniG[0];
            A985PostulacionProfesionalGar = P00M73_A985PostulacionProfesionalGar[0];
            n985PostulacionProfesionalGar = P00M73_n985PostulacionProfesionalGar[0];
            A986PostulacionProfesionalUniE = P00M73_A986PostulacionProfesionalUniE[0];
            n986PostulacionProfesionalUniE = P00M73_n986PostulacionProfesionalUniE[0];
            A983PostulacionProfesionalPlazoE = P00M73_A983PostulacionProfesionalPlazoE[0];
            n983PostulacionProfesionalPlazoE = P00M73_n983PostulacionProfesionalPlazoE[0];
            A982PostulacionProfesionalPrecio = P00M73_A982PostulacionProfesionalPrecio[0];
            n982PostulacionProfesionalPrecio = P00M73_n982PostulacionProfesionalPrecio[0];
            A191ProfesionalesSegundoNombre = P00M73_A191ProfesionalesSegundoNombre[0];
            A166ProfesionalesPrimerNombre = P00M73_A166ProfesionalesPrimerNombre[0];
            A167ProfesionalesApellidoPrimero = P00M73_A167ProfesionalesApellidoPrimero[0];
            A191ProfesionalesSegundoNombre = P00M73_A191ProfesionalesSegundoNombre[0];
            A166ProfesionalesPrimerNombre = P00M73_A166ProfesionalesPrimerNombre[0];
            A167ProfesionalesApellidoPrimero = P00M73_A167ProfesionalesApellidoPrimero[0];
            A886ProfesionalesNombreCompleto = StringUtil.Trim( A167ProfesionalesApellidoPrimero) + ", " + StringUtil.Trim( A166ProfesionalesPrimerNombre) + " " + StringUtil.Trim( A191ProfesionalesSegundoNombre);
            AV23count = 0;
            while ( (pr_default.getStatus(1) != 101) && ( P00M73_A422PostulacionesId[0] == A422PostulacionesId ) && ( StringUtil.StrCmp(P00M73_A984PostulacionProfesionalA[0], A984PostulacionProfesionalA) == 0 ) )
            {
               BRKM73 = false;
               A120ProfesionalesId = P00M73_A120ProfesionalesId[0];
               AV23count = (long)(AV23count+1);
               BRKM73 = true;
               pr_default.readNext(1);
            }
            if ( (0==AV14SkipItems) )
            {
               AV18Option = (String.IsNullOrEmpty(StringUtil.RTrim( A984PostulacionProfesionalA)) ? "<#Empty#>" : A984PostulacionProfesionalA);
               AV19Options.Add(AV18Option, 0);
               AV22OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV23count), "Z,ZZZ,ZZZ,ZZ9")), 0);
               if ( AV19Options.Count == 10 )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            else
            {
               AV14SkipItems = (short)(AV14SkipItems-1);
            }
            if ( ! BRKM73 )
            {
               BRKM73 = true;
               pr_default.readNext(1);
            }
         }
         pr_default.close(1);
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
         AV32OptionsJson = "";
         AV33OptionsDescJson = "";
         AV34OptionIndexesJson = "";
         AV19Options = new GxSimpleCollection<string>();
         AV21OptionsDesc = new GxSimpleCollection<string>();
         AV22OptionIndexes = new GxSimpleCollection<string>();
         AV13SearchTxt = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV24Session = context.GetSession();
         AV26GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV27GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV11TFProfesionalesNombreCompleto = "";
         AV12TFProfesionalesNombreCompleto_Sel = "";
         AV40TFPostulacionProfesionalUniE_SelsJson = "";
         AV41TFPostulacionProfesionalUniE_Sels = new GxSimpleCollection<string>();
         AV42TFPostulacionProfesionalUniG_SelsJson = "";
         AV43TFPostulacionProfesionalUniG_Sels = new GxSimpleCollection<string>();
         AV46TFPostulacionProfesionalA = "";
         AV47TFPostulacionProfesionalA_Sel = "";
         lV11TFProfesionalesNombreCompleto = "";
         lV46TFPostulacionProfesionalA = "";
         A986PostulacionProfesionalUniE = "";
         A987PostulacionProfesionalUniG = "";
         A167ProfesionalesApellidoPrimero = "";
         A166ProfesionalesPrimerNombre = "";
         A191ProfesionalesSegundoNombre = "";
         A984PostulacionProfesionalA = "";
         P00M72_A120ProfesionalesId = new string[] {""} ;
         P00M72_A984PostulacionProfesionalA = new string[] {""} ;
         P00M72_n984PostulacionProfesionalA = new bool[] {false} ;
         P00M72_A987PostulacionProfesionalUniG = new string[] {""} ;
         P00M72_n987PostulacionProfesionalUniG = new bool[] {false} ;
         P00M72_A985PostulacionProfesionalGar = new short[1] ;
         P00M72_n985PostulacionProfesionalGar = new bool[] {false} ;
         P00M72_A986PostulacionProfesionalUniE = new string[] {""} ;
         P00M72_n986PostulacionProfesionalUniE = new bool[] {false} ;
         P00M72_A983PostulacionProfesionalPlazoE = new short[1] ;
         P00M72_n983PostulacionProfesionalPlazoE = new bool[] {false} ;
         P00M72_A982PostulacionProfesionalPrecio = new decimal[1] ;
         P00M72_n982PostulacionProfesionalPrecio = new bool[] {false} ;
         P00M72_A422PostulacionesId = new long[1] ;
         P00M72_A191ProfesionalesSegundoNombre = new string[] {""} ;
         P00M72_A166ProfesionalesPrimerNombre = new string[] {""} ;
         P00M72_A167ProfesionalesApellidoPrimero = new string[] {""} ;
         A120ProfesionalesId = "";
         A886ProfesionalesNombreCompleto = "";
         AV18Option = "";
         P00M73_A120ProfesionalesId = new string[] {""} ;
         P00M73_A422PostulacionesId = new long[1] ;
         P00M73_A984PostulacionProfesionalA = new string[] {""} ;
         P00M73_n984PostulacionProfesionalA = new bool[] {false} ;
         P00M73_A987PostulacionProfesionalUniG = new string[] {""} ;
         P00M73_n987PostulacionProfesionalUniG = new bool[] {false} ;
         P00M73_A985PostulacionProfesionalGar = new short[1] ;
         P00M73_n985PostulacionProfesionalGar = new bool[] {false} ;
         P00M73_A986PostulacionProfesionalUniE = new string[] {""} ;
         P00M73_n986PostulacionProfesionalUniE = new bool[] {false} ;
         P00M73_A983PostulacionProfesionalPlazoE = new short[1] ;
         P00M73_n983PostulacionProfesionalPlazoE = new bool[] {false} ;
         P00M73_A982PostulacionProfesionalPrecio = new decimal[1] ;
         P00M73_n982PostulacionProfesionalPrecio = new bool[] {false} ;
         P00M73_A191ProfesionalesSegundoNombre = new string[] {""} ;
         P00M73_A166ProfesionalesPrimerNombre = new string[] {""} ;
         P00M73_A167ProfesionalesApellidoPrimero = new string[] {""} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.postulacionesprofesionaleswcgetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P00M72_A120ProfesionalesId, P00M72_A984PostulacionProfesionalA, P00M72_n984PostulacionProfesionalA, P00M72_A987PostulacionProfesionalUniG, P00M72_n987PostulacionProfesionalUniG, P00M72_A985PostulacionProfesionalGar, P00M72_n985PostulacionProfesionalGar, P00M72_A986PostulacionProfesionalUniE, P00M72_n986PostulacionProfesionalUniE, P00M72_A983PostulacionProfesionalPlazoE,
               P00M72_n983PostulacionProfesionalPlazoE, P00M72_A982PostulacionProfesionalPrecio, P00M72_n982PostulacionProfesionalPrecio, P00M72_A422PostulacionesId, P00M72_A191ProfesionalesSegundoNombre, P00M72_A166ProfesionalesPrimerNombre, P00M72_A167ProfesionalesApellidoPrimero
               }
               , new Object[] {
               P00M73_A120ProfesionalesId, P00M73_A422PostulacionesId, P00M73_A984PostulacionProfesionalA, P00M73_n984PostulacionProfesionalA, P00M73_A987PostulacionProfesionalUniG, P00M73_n987PostulacionProfesionalUniG, P00M73_A985PostulacionProfesionalGar, P00M73_n985PostulacionProfesionalGar, P00M73_A986PostulacionProfesionalUniE, P00M73_n986PostulacionProfesionalUniE,
               P00M73_A983PostulacionProfesionalPlazoE, P00M73_n983PostulacionProfesionalPlazoE, P00M73_A982PostulacionProfesionalPrecio, P00M73_n982PostulacionProfesionalPrecio, P00M73_A191ProfesionalesSegundoNombre, P00M73_A166ProfesionalesPrimerNombre, P00M73_A167ProfesionalesApellidoPrimero
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV16MaxItems ;
      private short AV15PageIndex ;
      private short AV14SkipItems ;
      private short AV38TFPostulacionProfesionalPlazoE ;
      private short AV39TFPostulacionProfesionalPlazoE_To ;
      private short AV44TFPostulacionProfesionalGar ;
      private short AV45TFPostulacionProfesionalGar_To ;
      private short A983PostulacionProfesionalPlazoE ;
      private short A985PostulacionProfesionalGar ;
      private int AV48GXV1 ;
      private int AV41TFPostulacionProfesionalUniE_Sels_Count ;
      private int AV43TFPostulacionProfesionalUniG_Sels_Count ;
      private int AV17InsertIndex ;
      private long AV35PostulacionesId ;
      private long A422PostulacionesId ;
      private long AV23count ;
      private decimal AV36TFPostulacionProfesionalPrecio ;
      private decimal AV37TFPostulacionProfesionalPrecio_To ;
      private decimal A982PostulacionProfesionalPrecio ;
      private string A986PostulacionProfesionalUniE ;
      private string A987PostulacionProfesionalUniG ;
      private string A167ProfesionalesApellidoPrimero ;
      private string A166ProfesionalesPrimerNombre ;
      private string A191ProfesionalesSegundoNombre ;
      private string A120ProfesionalesId ;
      private bool AV8IsAuthorized ;
      private bool GXt_boolean1 ;
      private bool returnInSub ;
      private bool n984PostulacionProfesionalA ;
      private bool n987PostulacionProfesionalUniG ;
      private bool n985PostulacionProfesionalGar ;
      private bool n986PostulacionProfesionalUniE ;
      private bool n983PostulacionProfesionalPlazoE ;
      private bool n982PostulacionProfesionalPrecio ;
      private bool BRKM73 ;
      private string AV32OptionsJson ;
      private string AV33OptionsDescJson ;
      private string AV34OptionIndexesJson ;
      private string AV40TFPostulacionProfesionalUniE_SelsJson ;
      private string AV42TFPostulacionProfesionalUniG_SelsJson ;
      private string AV29DDOName ;
      private string AV30SearchTxtParms ;
      private string AV31SearchTxtTo ;
      private string AV13SearchTxt ;
      private string AV11TFProfesionalesNombreCompleto ;
      private string AV12TFProfesionalesNombreCompleto_Sel ;
      private string AV46TFPostulacionProfesionalA ;
      private string AV47TFPostulacionProfesionalA_Sel ;
      private string lV11TFProfesionalesNombreCompleto ;
      private string lV46TFPostulacionProfesionalA ;
      private string A984PostulacionProfesionalA ;
      private string A886ProfesionalesNombreCompleto ;
      private string AV18Option ;
      private IGxSession AV24Session ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GxSimpleCollection<string> AV19Options ;
      private GxSimpleCollection<string> AV21OptionsDesc ;
      private GxSimpleCollection<string> AV22OptionIndexes ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV26GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV27GridStateFilterValue ;
      private GxSimpleCollection<string> AV41TFPostulacionProfesionalUniE_Sels ;
      private GxSimpleCollection<string> AV43TFPostulacionProfesionalUniG_Sels ;
      private IDataStoreProvider pr_default ;
      private string[] P00M72_A120ProfesionalesId ;
      private string[] P00M72_A984PostulacionProfesionalA ;
      private bool[] P00M72_n984PostulacionProfesionalA ;
      private string[] P00M72_A987PostulacionProfesionalUniG ;
      private bool[] P00M72_n987PostulacionProfesionalUniG ;
      private short[] P00M72_A985PostulacionProfesionalGar ;
      private bool[] P00M72_n985PostulacionProfesionalGar ;
      private string[] P00M72_A986PostulacionProfesionalUniE ;
      private bool[] P00M72_n986PostulacionProfesionalUniE ;
      private short[] P00M72_A983PostulacionProfesionalPlazoE ;
      private bool[] P00M72_n983PostulacionProfesionalPlazoE ;
      private decimal[] P00M72_A982PostulacionProfesionalPrecio ;
      private bool[] P00M72_n982PostulacionProfesionalPrecio ;
      private long[] P00M72_A422PostulacionesId ;
      private string[] P00M72_A191ProfesionalesSegundoNombre ;
      private string[] P00M72_A166ProfesionalesPrimerNombre ;
      private string[] P00M72_A167ProfesionalesApellidoPrimero ;
      private string[] P00M73_A120ProfesionalesId ;
      private long[] P00M73_A422PostulacionesId ;
      private string[] P00M73_A984PostulacionProfesionalA ;
      private bool[] P00M73_n984PostulacionProfesionalA ;
      private string[] P00M73_A987PostulacionProfesionalUniG ;
      private bool[] P00M73_n987PostulacionProfesionalUniG ;
      private short[] P00M73_A985PostulacionProfesionalGar ;
      private bool[] P00M73_n985PostulacionProfesionalGar ;
      private string[] P00M73_A986PostulacionProfesionalUniE ;
      private bool[] P00M73_n986PostulacionProfesionalUniE ;
      private short[] P00M73_A983PostulacionProfesionalPlazoE ;
      private bool[] P00M73_n983PostulacionProfesionalPlazoE ;
      private decimal[] P00M73_A982PostulacionProfesionalPrecio ;
      private bool[] P00M73_n982PostulacionProfesionalPrecio ;
      private string[] P00M73_A191ProfesionalesSegundoNombre ;
      private string[] P00M73_A166ProfesionalesPrimerNombre ;
      private string[] P00M73_A167ProfesionalesApellidoPrimero ;
      private string aP3_OptionsJson ;
      private string aP4_OptionsDescJson ;
      private string aP5_OptionIndexesJson ;
   }

   public class postulacionesprofesionaleswcgetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00M72( IGxContext context ,
                                             string A986PostulacionProfesionalUniE ,
                                             GxSimpleCollection<string> AV41TFPostulacionProfesionalUniE_Sels ,
                                             string A987PostulacionProfesionalUniG ,
                                             GxSimpleCollection<string> AV43TFPostulacionProfesionalUniG_Sels ,
                                             string AV12TFProfesionalesNombreCompleto_Sel ,
                                             string AV11TFProfesionalesNombreCompleto ,
                                             decimal AV36TFPostulacionProfesionalPrecio ,
                                             decimal AV37TFPostulacionProfesionalPrecio_To ,
                                             short AV38TFPostulacionProfesionalPlazoE ,
                                             short AV39TFPostulacionProfesionalPlazoE_To ,
                                             int AV41TFPostulacionProfesionalUniE_Sels_Count ,
                                             short AV44TFPostulacionProfesionalGar ,
                                             short AV45TFPostulacionProfesionalGar_To ,
                                             int AV43TFPostulacionProfesionalUniG_Sels_Count ,
                                             string AV47TFPostulacionProfesionalA_Sel ,
                                             string AV46TFPostulacionProfesionalA ,
                                             string A167ProfesionalesApellidoPrimero ,
                                             string A166ProfesionalesPrimerNombre ,
                                             string A191ProfesionalesSegundoNombre ,
                                             decimal A982PostulacionProfesionalPrecio ,
                                             short A983PostulacionProfesionalPlazoE ,
                                             short A985PostulacionProfesionalGar ,
                                             string A984PostulacionProfesionalA ,
                                             long AV35PostulacionesId ,
                                             long A422PostulacionesId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int2 = new short[11];
         Object[] GXv_Object3 = new Object[2];
         scmdbuf = "SELECT T1.[ProfesionalesId], T1.[PostulacionProfesionalA], T1.[PostulacionProfesionalUniG], T1.[PostulacionProfesionalGar], T1.[PostulacionProfesionalUniE], T1.[PostulacionProfesionalPlazoE], T1.[PostulacionProfesionalPrecio], T1.[PostulacionesId], T2.[ProfesionalesSegundoNombre], T2.[ProfesionalesPrimerNombre], T2.[ProfesionalesApellidoPrimero] FROM ([PostulacionesProfesionales] T1 INNER JOIN [Profesionales] T2 ON T2.[ProfesionalesId] = T1.[ProfesionalesId])";
         AddWhere(sWhereString, "(T1.[PostulacionesId] = @AV35PostulacionesId)");
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV12TFProfesionalesNombreCompleto_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV11TFProfesionalesNombreCompleto)) ) )
         {
            AddWhere(sWhereString, "(UPPER(RTRIM(LTRIM(T2.[ProfesionalesApellidoPrimero])) + ', ' + RTRIM(LTRIM(T2.[ProfesionalesPrimerNombre])) + ' ' + RTRIM(LTRIM(T2.[ProfesionalesSegundoNombre]))) like UPPER(@lV11TFProfesionalesNombreCompleto))");
         }
         else
         {
            GXv_int2[1] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV12TFProfesionalesNombreCompleto_Sel)) && ! ( StringUtil.StrCmp(AV12TFProfesionalesNombreCompleto_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(RTRIM(LTRIM(T2.[ProfesionalesApellidoPrimero])) + ', ' + RTRIM(LTRIM(T2.[ProfesionalesPrimerNombre])) + ' ' + RTRIM(LTRIM(T2.[ProfesionalesSegundoNombre])) = @AV12TFProfesionalesNombreCompleto_Sel)");
         }
         else
         {
            GXv_int2[2] = 1;
         }
         if ( StringUtil.StrCmp(AV12TFProfesionalesNombreCompleto_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((RTRIM(LTRIM(T2.[ProfesionalesApellidoPrimero])) + ', ' + RTRIM(LTRIM(T2.[ProfesionalesPrimerNombre])) + ' ' + RTRIM(LTRIM(T2.[ProfesionalesSegundoNombre])) = ''))");
         }
         if ( ! (Convert.ToDecimal(0)==AV36TFPostulacionProfesionalPrecio) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionProfesionalPrecio] >= @AV36TFPostulacionProfesionalPrecio)");
         }
         else
         {
            GXv_int2[3] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV37TFPostulacionProfesionalPrecio_To) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionProfesionalPrecio] <= @AV37TFPostulacionProfesionalPrecio_To)");
         }
         else
         {
            GXv_int2[4] = 1;
         }
         if ( ! (0==AV38TFPostulacionProfesionalPlazoE) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionProfesionalPlazoE] >= @AV38TFPostulacionProfesionalPlazoE)");
         }
         else
         {
            GXv_int2[5] = 1;
         }
         if ( ! (0==AV39TFPostulacionProfesionalPlazoE_To) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionProfesionalPlazoE] <= @AV39TFPostulacionProfesionalPlazoE_To)");
         }
         else
         {
            GXv_int2[6] = 1;
         }
         if ( AV41TFPostulacionProfesionalUniE_Sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV41TFPostulacionProfesionalUniE_Sels, "T1.[PostulacionProfesionalUniE] IN (", ")")+")");
         }
         if ( ! (0==AV44TFPostulacionProfesionalGar) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionProfesionalGar] >= @AV44TFPostulacionProfesionalGar)");
         }
         else
         {
            GXv_int2[7] = 1;
         }
         if ( ! (0==AV45TFPostulacionProfesionalGar_To) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionProfesionalGar] <= @AV45TFPostulacionProfesionalGar_To)");
         }
         else
         {
            GXv_int2[8] = 1;
         }
         if ( AV43TFPostulacionProfesionalUniG_Sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV43TFPostulacionProfesionalUniG_Sels, "T1.[PostulacionProfesionalUniG] IN (", ")")+")");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV47TFPostulacionProfesionalA_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV46TFPostulacionProfesionalA)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[PostulacionProfesionalA]) like UPPER(@lV46TFPostulacionProfesionalA))");
         }
         else
         {
            GXv_int2[9] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV47TFPostulacionProfesionalA_Sel)) && ! ( StringUtil.StrCmp(AV47TFPostulacionProfesionalA_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionProfesionalA] = @AV47TFPostulacionProfesionalA_Sel)");
         }
         else
         {
            GXv_int2[10] = 1;
         }
         if ( StringUtil.StrCmp(AV47TFPostulacionProfesionalA_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.[PostulacionProfesionalA] IS NULL or (T1.[PostulacionProfesionalA] = ''))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[PostulacionesId]";
         GXv_Object3[0] = scmdbuf;
         GXv_Object3[1] = GXv_int2;
         return GXv_Object3 ;
      }

      protected Object[] conditional_P00M73( IGxContext context ,
                                             string A986PostulacionProfesionalUniE ,
                                             GxSimpleCollection<string> AV41TFPostulacionProfesionalUniE_Sels ,
                                             string A987PostulacionProfesionalUniG ,
                                             GxSimpleCollection<string> AV43TFPostulacionProfesionalUniG_Sels ,
                                             string AV12TFProfesionalesNombreCompleto_Sel ,
                                             string AV11TFProfesionalesNombreCompleto ,
                                             decimal AV36TFPostulacionProfesionalPrecio ,
                                             decimal AV37TFPostulacionProfesionalPrecio_To ,
                                             short AV38TFPostulacionProfesionalPlazoE ,
                                             short AV39TFPostulacionProfesionalPlazoE_To ,
                                             int AV41TFPostulacionProfesionalUniE_Sels_Count ,
                                             short AV44TFPostulacionProfesionalGar ,
                                             short AV45TFPostulacionProfesionalGar_To ,
                                             int AV43TFPostulacionProfesionalUniG_Sels_Count ,
                                             string AV47TFPostulacionProfesionalA_Sel ,
                                             string AV46TFPostulacionProfesionalA ,
                                             string A167ProfesionalesApellidoPrimero ,
                                             string A166ProfesionalesPrimerNombre ,
                                             string A191ProfesionalesSegundoNombre ,
                                             decimal A982PostulacionProfesionalPrecio ,
                                             short A983PostulacionProfesionalPlazoE ,
                                             short A985PostulacionProfesionalGar ,
                                             string A984PostulacionProfesionalA ,
                                             long AV35PostulacionesId ,
                                             long A422PostulacionesId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int4 = new short[11];
         Object[] GXv_Object5 = new Object[2];
         scmdbuf = "SELECT T1.[ProfesionalesId], T1.[PostulacionesId], T1.[PostulacionProfesionalA], T1.[PostulacionProfesionalUniG], T1.[PostulacionProfesionalGar], T1.[PostulacionProfesionalUniE], T1.[PostulacionProfesionalPlazoE], T1.[PostulacionProfesionalPrecio], T2.[ProfesionalesSegundoNombre], T2.[ProfesionalesPrimerNombre], T2.[ProfesionalesApellidoPrimero] FROM ([PostulacionesProfesionales] T1 INNER JOIN [Profesionales] T2 ON T2.[ProfesionalesId] = T1.[ProfesionalesId])";
         AddWhere(sWhereString, "(T1.[PostulacionesId] = @AV35PostulacionesId)");
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV12TFProfesionalesNombreCompleto_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV11TFProfesionalesNombreCompleto)) ) )
         {
            AddWhere(sWhereString, "(UPPER(RTRIM(LTRIM(T2.[ProfesionalesApellidoPrimero])) + ', ' + RTRIM(LTRIM(T2.[ProfesionalesPrimerNombre])) + ' ' + RTRIM(LTRIM(T2.[ProfesionalesSegundoNombre]))) like UPPER(@lV11TFProfesionalesNombreCompleto))");
         }
         else
         {
            GXv_int4[1] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV12TFProfesionalesNombreCompleto_Sel)) && ! ( StringUtil.StrCmp(AV12TFProfesionalesNombreCompleto_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(RTRIM(LTRIM(T2.[ProfesionalesApellidoPrimero])) + ', ' + RTRIM(LTRIM(T2.[ProfesionalesPrimerNombre])) + ' ' + RTRIM(LTRIM(T2.[ProfesionalesSegundoNombre])) = @AV12TFProfesionalesNombreCompleto_Sel)");
         }
         else
         {
            GXv_int4[2] = 1;
         }
         if ( StringUtil.StrCmp(AV12TFProfesionalesNombreCompleto_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((RTRIM(LTRIM(T2.[ProfesionalesApellidoPrimero])) + ', ' + RTRIM(LTRIM(T2.[ProfesionalesPrimerNombre])) + ' ' + RTRIM(LTRIM(T2.[ProfesionalesSegundoNombre])) = ''))");
         }
         if ( ! (Convert.ToDecimal(0)==AV36TFPostulacionProfesionalPrecio) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionProfesionalPrecio] >= @AV36TFPostulacionProfesionalPrecio)");
         }
         else
         {
            GXv_int4[3] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV37TFPostulacionProfesionalPrecio_To) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionProfesionalPrecio] <= @AV37TFPostulacionProfesionalPrecio_To)");
         }
         else
         {
            GXv_int4[4] = 1;
         }
         if ( ! (0==AV38TFPostulacionProfesionalPlazoE) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionProfesionalPlazoE] >= @AV38TFPostulacionProfesionalPlazoE)");
         }
         else
         {
            GXv_int4[5] = 1;
         }
         if ( ! (0==AV39TFPostulacionProfesionalPlazoE_To) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionProfesionalPlazoE] <= @AV39TFPostulacionProfesionalPlazoE_To)");
         }
         else
         {
            GXv_int4[6] = 1;
         }
         if ( AV41TFPostulacionProfesionalUniE_Sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV41TFPostulacionProfesionalUniE_Sels, "T1.[PostulacionProfesionalUniE] IN (", ")")+")");
         }
         if ( ! (0==AV44TFPostulacionProfesionalGar) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionProfesionalGar] >= @AV44TFPostulacionProfesionalGar)");
         }
         else
         {
            GXv_int4[7] = 1;
         }
         if ( ! (0==AV45TFPostulacionProfesionalGar_To) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionProfesionalGar] <= @AV45TFPostulacionProfesionalGar_To)");
         }
         else
         {
            GXv_int4[8] = 1;
         }
         if ( AV43TFPostulacionProfesionalUniG_Sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV43TFPostulacionProfesionalUniG_Sels, "T1.[PostulacionProfesionalUniG] IN (", ")")+")");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV47TFPostulacionProfesionalA_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV46TFPostulacionProfesionalA)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[PostulacionProfesionalA]) like UPPER(@lV46TFPostulacionProfesionalA))");
         }
         else
         {
            GXv_int4[9] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV47TFPostulacionProfesionalA_Sel)) && ! ( StringUtil.StrCmp(AV47TFPostulacionProfesionalA_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionProfesionalA] = @AV47TFPostulacionProfesionalA_Sel)");
         }
         else
         {
            GXv_int4[10] = 1;
         }
         if ( StringUtil.StrCmp(AV47TFPostulacionProfesionalA_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.[PostulacionProfesionalA] IS NULL or (T1.[PostulacionProfesionalA] = ''))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[PostulacionesId], T1.[PostulacionProfesionalA]";
         GXv_Object5[0] = scmdbuf;
         GXv_Object5[1] = GXv_int4;
         return GXv_Object5 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_P00M72(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (GxSimpleCollection<string>)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (decimal)dynConstraints[6] , (decimal)dynConstraints[7] , (short)dynConstraints[8] , (short)dynConstraints[9] , (int)dynConstraints[10] , (short)dynConstraints[11] , (short)dynConstraints[12] , (int)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (decimal)dynConstraints[19] , (short)dynConstraints[20] , (short)dynConstraints[21] , (string)dynConstraints[22] , (long)dynConstraints[23] , (long)dynConstraints[24] );
               case 1 :
                     return conditional_P00M73(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (GxSimpleCollection<string>)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (decimal)dynConstraints[6] , (decimal)dynConstraints[7] , (short)dynConstraints[8] , (short)dynConstraints[9] , (int)dynConstraints[10] , (short)dynConstraints[11] , (short)dynConstraints[12] , (int)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (decimal)dynConstraints[19] , (short)dynConstraints[20] , (short)dynConstraints[21] , (string)dynConstraints[22] , (long)dynConstraints[23] , (long)dynConstraints[24] );
         }
         return base.getDynamicStatement(cursor, context, dynConstraints);
      }

      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP00M72;
          prmP00M72 = new Object[] {
          new ParDef("@AV35PostulacionesId",GXType.Decimal,18,0) ,
          new ParDef("@lV11TFProfesionalesNombreCompleto",GXType.VarChar,100,0) ,
          new ParDef("@AV12TFProfesionalesNombreCompleto_Sel",GXType.VarChar,100,0) ,
          new ParDef("@AV36TFPostulacionProfesionalPrecio",GXType.Decimal,18,2) ,
          new ParDef("@AV37TFPostulacionProfesionalPrecio_To",GXType.Decimal,18,2) ,
          new ParDef("@AV38TFPostulacionProfesionalPlazoE",GXType.Int16,4,0) ,
          new ParDef("@AV39TFPostulacionProfesionalPlazoE_To",GXType.Int16,4,0) ,
          new ParDef("@AV44TFPostulacionProfesionalGar",GXType.Int16,4,0) ,
          new ParDef("@AV45TFPostulacionProfesionalGar_To",GXType.Int16,4,0) ,
          new ParDef("@lV46TFPostulacionProfesionalA",GXType.VarChar,500,0) ,
          new ParDef("@AV47TFPostulacionProfesionalA_Sel",GXType.NVarChar,500,0)
          };
          Object[] prmP00M73;
          prmP00M73 = new Object[] {
          new ParDef("@AV35PostulacionesId",GXType.Decimal,18,0) ,
          new ParDef("@lV11TFProfesionalesNombreCompleto",GXType.VarChar,100,0) ,
          new ParDef("@AV12TFProfesionalesNombreCompleto_Sel",GXType.VarChar,100,0) ,
          new ParDef("@AV36TFPostulacionProfesionalPrecio",GXType.Decimal,18,2) ,
          new ParDef("@AV37TFPostulacionProfesionalPrecio_To",GXType.Decimal,18,2) ,
          new ParDef("@AV38TFPostulacionProfesionalPlazoE",GXType.Int16,4,0) ,
          new ParDef("@AV39TFPostulacionProfesionalPlazoE_To",GXType.Int16,4,0) ,
          new ParDef("@AV44TFPostulacionProfesionalGar",GXType.Int16,4,0) ,
          new ParDef("@AV45TFPostulacionProfesionalGar_To",GXType.Int16,4,0) ,
          new ParDef("@lV46TFPostulacionProfesionalA",GXType.VarChar,500,0) ,
          new ParDef("@AV47TFPostulacionProfesionalA_Sel",GXType.NVarChar,500,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00M72", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00M72,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P00M73", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00M73,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[3])[0] = rslt.getString(3, 1);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((short[]) buf[5])[0] = rslt.getShort(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((string[]) buf[7])[0] = rslt.getString(5, 1);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((short[]) buf[9])[0] = rslt.getShort(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((decimal[]) buf[11])[0] = rslt.getDecimal(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((long[]) buf[13])[0] = rslt.getLong(8);
                ((string[]) buf[14])[0] = rslt.getString(9, 30);
                ((string[]) buf[15])[0] = rslt.getString(10, 30);
                ((string[]) buf[16])[0] = rslt.getString(11, 30);
                return;
             case 1 :
                ((string[]) buf[0])[0] = rslt.getString(1, 20);
                ((long[]) buf[1])[0] = rslt.getLong(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((bool[]) buf[3])[0] = rslt.wasNull(3);
                ((string[]) buf[4])[0] = rslt.getString(4, 1);
                ((bool[]) buf[5])[0] = rslt.wasNull(4);
                ((short[]) buf[6])[0] = rslt.getShort(5);
                ((bool[]) buf[7])[0] = rslt.wasNull(5);
                ((string[]) buf[8])[0] = rslt.getString(6, 1);
                ((bool[]) buf[9])[0] = rslt.wasNull(6);
                ((short[]) buf[10])[0] = rslt.getShort(7);
                ((bool[]) buf[11])[0] = rslt.wasNull(7);
                ((decimal[]) buf[12])[0] = rslt.getDecimal(8);
                ((bool[]) buf[13])[0] = rslt.wasNull(8);
                ((string[]) buf[14])[0] = rslt.getString(9, 30);
                ((string[]) buf[15])[0] = rslt.getString(10, 30);
                ((string[]) buf[16])[0] = rslt.getString(11, 30);
                return;
       }
    }

 }

 [ServiceContract(Namespace = "GeneXus.Programs.postulacionesprofesionaleswcgetfilterdata_services")]
 [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple)]
 [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
 public class postulacionesprofesionaleswcgetfilterdata_services : GxRestService
 {
    [OperationContract(Name = "PostulacionesProfesionalesWCGetFilterData" )]
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
          if ( ! ProcessHeaders("postulacionesprofesionaleswcgetfilterdata") )
          {
             return  ;
          }
          postulacionesprofesionaleswcgetfilterdata worker = new postulacionesprofesionaleswcgetfilterdata(context);
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

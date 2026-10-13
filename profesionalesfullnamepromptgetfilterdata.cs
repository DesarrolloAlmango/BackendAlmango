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
   public class profesionalesfullnamepromptgetfilterdata : GXProcedure
   {
      public profesionalesfullnamepromptgetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public profesionalesfullnamepromptgetfilterdata( IGxContext context )
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
         new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWProfesionales", out  GXt_boolean1) ;
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
            if ( StringUtil.StrCmp(StringUtil.Upper( AV41DDOName), "DDO_PROFESIONALESID") == 0 )
            {
               /* Execute user subroutine: 'LOADPROFESIONALESIDOPTIONS' */
               S121 ();
               if ( returnInSub )
               {
                  cleanup();
                  if (true) return;
               }
            }
            else if ( StringUtil.StrCmp(StringUtil.Upper( AV41DDOName), "DDO_PROFESIONALESPRIMERNOMBRE") == 0 )
            {
               /* Execute user subroutine: 'LOADPROFESIONALESPRIMERNOMBREOPTIONS' */
               S131 ();
               if ( returnInSub )
               {
                  cleanup();
                  if (true) return;
               }
            }
            else if ( StringUtil.StrCmp(StringUtil.Upper( AV41DDOName), "DDO_PROFESIONALESSEGUNDONOMBRE") == 0 )
            {
               /* Execute user subroutine: 'LOADPROFESIONALESSEGUNDONOMBREOPTIONS' */
               S141 ();
               if ( returnInSub )
               {
                  cleanup();
                  if (true) return;
               }
            }
            else if ( StringUtil.StrCmp(StringUtil.Upper( AV41DDOName), "DDO_PROFESIONALESAPELLIDOPRIMERO") == 0 )
            {
               /* Execute user subroutine: 'LOADPROFESIONALESAPELLIDOPRIMEROOPTIONS' */
               S151 ();
               if ( returnInSub )
               {
                  cleanup();
                  if (true) return;
               }
            }
            else if ( StringUtil.StrCmp(StringUtil.Upper( AV41DDOName), "DDO_PROFESIONALESAPELLIDOSEGUNDO") == 0 )
            {
               /* Execute user subroutine: 'LOADPROFESIONALESAPELLIDOSEGUNDOOPTIONS' */
               S161 ();
               if ( returnInSub )
               {
                  cleanup();
                  if (true) return;
               }
            }
            else if ( StringUtil.StrCmp(StringUtil.Upper( AV41DDOName), "DDO_PROFESIONALESTELEFONO") == 0 )
            {
               /* Execute user subroutine: 'LOADPROFESIONALESTELEFONOOPTIONS' */
               S171 ();
               if ( returnInSub )
               {
                  cleanup();
                  if (true) return;
               }
            }
            else if ( StringUtil.StrCmp(StringUtil.Upper( AV41DDOName), "DDO_PROFESIONALESEMAIL") == 0 )
            {
               /* Execute user subroutine: 'LOADPROFESIONALESEMAILOPTIONS' */
               S181 ();
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
         if ( StringUtil.StrCmp(AV36Session.Get("ProfesionalesFullNamePromptGridState"), "") == 0 )
         {
            AV38GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "ProfesionalesFullNamePromptGridState"), null, "", "");
         }
         else
         {
            AV38GridState.FromXml(AV36Session.Get("ProfesionalesFullNamePromptGridState"), null, "", "");
         }
         AV49GXV1 = 1;
         while ( AV49GXV1 <= AV38GridState.gxTpr_Filtervalues.Count )
         {
            AV39GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV38GridState.gxTpr_Filtervalues.Item(AV49GXV1));
            if ( StringUtil.StrCmp(AV39GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV47FilterFullText = AV39GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV39GridStateFilterValue.gxTpr_Name, "TFPROFESIONALESID") == 0 )
            {
               AV11TFProfesionalesId = AV39GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV39GridStateFilterValue.gxTpr_Name, "TFPROFESIONALESID_SEL") == 0 )
            {
               AV12TFProfesionalesId_Sel = AV39GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV39GridStateFilterValue.gxTpr_Name, "TFPROFESIONALESPRIMERNOMBRE") == 0 )
            {
               AV13TFProfesionalesPrimerNombre = AV39GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV39GridStateFilterValue.gxTpr_Name, "TFPROFESIONALESPRIMERNOMBRE_SEL") == 0 )
            {
               AV14TFProfesionalesPrimerNombre_Sel = AV39GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV39GridStateFilterValue.gxTpr_Name, "TFPROFESIONALESSEGUNDONOMBRE") == 0 )
            {
               AV15TFProfesionalesSegundoNombre = AV39GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV39GridStateFilterValue.gxTpr_Name, "TFPROFESIONALESSEGUNDONOMBRE_SEL") == 0 )
            {
               AV16TFProfesionalesSegundoNombre_Sel = AV39GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV39GridStateFilterValue.gxTpr_Name, "TFPROFESIONALESAPELLIDOPRIMERO") == 0 )
            {
               AV17TFProfesionalesApellidoPrimero = AV39GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV39GridStateFilterValue.gxTpr_Name, "TFPROFESIONALESAPELLIDOPRIMERO_SEL") == 0 )
            {
               AV18TFProfesionalesApellidoPrimero_Sel = AV39GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV39GridStateFilterValue.gxTpr_Name, "TFPROFESIONALESAPELLIDOSEGUNDO") == 0 )
            {
               AV19TFProfesionalesApellidoSegundo = AV39GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV39GridStateFilterValue.gxTpr_Name, "TFPROFESIONALESAPELLIDOSEGUNDO_SEL") == 0 )
            {
               AV20TFProfesionalesApellidoSegundo_Sel = AV39GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV39GridStateFilterValue.gxTpr_Name, "TFPROFESIONALESTELEFONO") == 0 )
            {
               AV21TFProfesionalesTelefono = AV39GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV39GridStateFilterValue.gxTpr_Name, "TFPROFESIONALESTELEFONO_SEL") == 0 )
            {
               AV22TFProfesionalesTelefono_Sel = AV39GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV39GridStateFilterValue.gxTpr_Name, "TFPROFESIONALESEMAIL") == 0 )
            {
               AV23TFProfesionalesEmail = AV39GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV39GridStateFilterValue.gxTpr_Name, "TFPROFESIONALESEMAIL_SEL") == 0 )
            {
               AV24TFProfesionalesEmail_Sel = AV39GridStateFilterValue.gxTpr_Value;
            }
            AV49GXV1 = (int)(AV49GXV1+1);
         }
      }

      protected void S121( )
      {
         /* 'LOADPROFESIONALESIDOPTIONS' Routine */
         returnInSub = false;
         AV11TFProfesionalesId = AV25SearchTxt;
         AV12TFProfesionalesId_Sel = "";
         GXPagingFrom2 = AV26SkipItems;
         GXPagingTo2 = AV28MaxItems;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV47FilterFullText ,
                                              AV12TFProfesionalesId_Sel ,
                                              AV11TFProfesionalesId ,
                                              AV14TFProfesionalesPrimerNombre_Sel ,
                                              AV13TFProfesionalesPrimerNombre ,
                                              AV16TFProfesionalesSegundoNombre_Sel ,
                                              AV15TFProfesionalesSegundoNombre ,
                                              AV18TFProfesionalesApellidoPrimero_Sel ,
                                              AV17TFProfesionalesApellidoPrimero ,
                                              AV20TFProfesionalesApellidoSegundo_Sel ,
                                              AV19TFProfesionalesApellidoSegundo ,
                                              AV22TFProfesionalesTelefono_Sel ,
                                              AV21TFProfesionalesTelefono ,
                                              AV24TFProfesionalesEmail_Sel ,
                                              AV23TFProfesionalesEmail ,
                                              A120ProfesionalesId ,
                                              A166ProfesionalesPrimerNombre ,
                                              A191ProfesionalesSegundoNombre ,
                                              A167ProfesionalesApellidoPrimero ,
                                              A192ProfesionalesApellidoSegundo ,
                                              A170ProfesionalesTelefono ,
                                              A193ProfesionalesEmail ,
                                              A108EstadosGenericosId } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.INT
                                              }
         });
         lV47FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV47FilterFullText), "%", "");
         lV47FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV47FilterFullText), "%", "");
         lV47FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV47FilterFullText), "%", "");
         lV47FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV47FilterFullText), "%", "");
         lV47FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV47FilterFullText), "%", "");
         lV47FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV47FilterFullText), "%", "");
         lV47FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV47FilterFullText), "%", "");
         lV11TFProfesionalesId = StringUtil.PadR( StringUtil.RTrim( AV11TFProfesionalesId), 20, "%");
         lV13TFProfesionalesPrimerNombre = StringUtil.PadR( StringUtil.RTrim( AV13TFProfesionalesPrimerNombre), 30, "%");
         lV15TFProfesionalesSegundoNombre = StringUtil.PadR( StringUtil.RTrim( AV15TFProfesionalesSegundoNombre), 30, "%");
         lV17TFProfesionalesApellidoPrimero = StringUtil.PadR( StringUtil.RTrim( AV17TFProfesionalesApellidoPrimero), 30, "%");
         lV19TFProfesionalesApellidoSegundo = StringUtil.PadR( StringUtil.RTrim( AV19TFProfesionalesApellidoSegundo), 30, "%");
         lV21TFProfesionalesTelefono = StringUtil.PadR( StringUtil.RTrim( AV21TFProfesionalesTelefono), 20, "%");
         lV23TFProfesionalesEmail = StringUtil.Concat( StringUtil.RTrim( AV23TFProfesionalesEmail), "%", "");
         /* Using cursor P00BG2 */
         pr_default.execute(0, new Object[] {lV47FilterFullText, lV47FilterFullText, lV47FilterFullText, lV47FilterFullText, lV47FilterFullText, lV47FilterFullText, lV47FilterFullText, lV11TFProfesionalesId, AV12TFProfesionalesId_Sel, lV13TFProfesionalesPrimerNombre, AV14TFProfesionalesPrimerNombre_Sel, lV15TFProfesionalesSegundoNombre, AV16TFProfesionalesSegundoNombre_Sel, lV17TFProfesionalesApellidoPrimero, AV18TFProfesionalesApellidoPrimero_Sel, lV19TFProfesionalesApellidoSegundo, AV20TFProfesionalesApellidoSegundo_Sel, lV21TFProfesionalesTelefono, AV22TFProfesionalesTelefono_Sel, lV23TFProfesionalesEmail, AV24TFProfesionalesEmail_Sel, GXPagingFrom2, GXPagingTo2, GXPagingTo2});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A108EstadosGenericosId = P00BG2_A108EstadosGenericosId[0];
            A193ProfesionalesEmail = P00BG2_A193ProfesionalesEmail[0];
            n193ProfesionalesEmail = P00BG2_n193ProfesionalesEmail[0];
            A170ProfesionalesTelefono = P00BG2_A170ProfesionalesTelefono[0];
            A192ProfesionalesApellidoSegundo = P00BG2_A192ProfesionalesApellidoSegundo[0];
            A167ProfesionalesApellidoPrimero = P00BG2_A167ProfesionalesApellidoPrimero[0];
            A191ProfesionalesSegundoNombre = P00BG2_A191ProfesionalesSegundoNombre[0];
            A166ProfesionalesPrimerNombre = P00BG2_A166ProfesionalesPrimerNombre[0];
            A120ProfesionalesId = P00BG2_A120ProfesionalesId[0];
            AV30Option = (String.IsNullOrEmpty(StringUtil.RTrim( A120ProfesionalesId)) ? "<#Empty#>" : A120ProfesionalesId);
            AV31Options.Add(AV30Option, 0);
            pr_default.readNext(0);
         }
         pr_default.close(0);
      }

      protected void S131( )
      {
         /* 'LOADPROFESIONALESPRIMERNOMBREOPTIONS' Routine */
         returnInSub = false;
         AV13TFProfesionalesPrimerNombre = AV25SearchTxt;
         AV14TFProfesionalesPrimerNombre_Sel = "";
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              AV47FilterFullText ,
                                              AV12TFProfesionalesId_Sel ,
                                              AV11TFProfesionalesId ,
                                              AV14TFProfesionalesPrimerNombre_Sel ,
                                              AV13TFProfesionalesPrimerNombre ,
                                              AV16TFProfesionalesSegundoNombre_Sel ,
                                              AV15TFProfesionalesSegundoNombre ,
                                              AV18TFProfesionalesApellidoPrimero_Sel ,
                                              AV17TFProfesionalesApellidoPrimero ,
                                              AV20TFProfesionalesApellidoSegundo_Sel ,
                                              AV19TFProfesionalesApellidoSegundo ,
                                              AV22TFProfesionalesTelefono_Sel ,
                                              AV21TFProfesionalesTelefono ,
                                              AV24TFProfesionalesEmail_Sel ,
                                              AV23TFProfesionalesEmail ,
                                              A120ProfesionalesId ,
                                              A166ProfesionalesPrimerNombre ,
                                              A191ProfesionalesSegundoNombre ,
                                              A167ProfesionalesApellidoPrimero ,
                                              A192ProfesionalesApellidoSegundo ,
                                              A170ProfesionalesTelefono ,
                                              A193ProfesionalesEmail ,
                                              A108EstadosGenericosId } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.INT
                                              }
         });
         lV47FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV47FilterFullText), "%", "");
         lV47FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV47FilterFullText), "%", "");
         lV47FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV47FilterFullText), "%", "");
         lV47FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV47FilterFullText), "%", "");
         lV47FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV47FilterFullText), "%", "");
         lV47FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV47FilterFullText), "%", "");
         lV47FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV47FilterFullText), "%", "");
         lV11TFProfesionalesId = StringUtil.PadR( StringUtil.RTrim( AV11TFProfesionalesId), 20, "%");
         lV13TFProfesionalesPrimerNombre = StringUtil.PadR( StringUtil.RTrim( AV13TFProfesionalesPrimerNombre), 30, "%");
         lV15TFProfesionalesSegundoNombre = StringUtil.PadR( StringUtil.RTrim( AV15TFProfesionalesSegundoNombre), 30, "%");
         lV17TFProfesionalesApellidoPrimero = StringUtil.PadR( StringUtil.RTrim( AV17TFProfesionalesApellidoPrimero), 30, "%");
         lV19TFProfesionalesApellidoSegundo = StringUtil.PadR( StringUtil.RTrim( AV19TFProfesionalesApellidoSegundo), 30, "%");
         lV21TFProfesionalesTelefono = StringUtil.PadR( StringUtil.RTrim( AV21TFProfesionalesTelefono), 20, "%");
         lV23TFProfesionalesEmail = StringUtil.Concat( StringUtil.RTrim( AV23TFProfesionalesEmail), "%", "");
         /* Using cursor P00BG3 */
         pr_default.execute(1, new Object[] {lV47FilterFullText, lV47FilterFullText, lV47FilterFullText, lV47FilterFullText, lV47FilterFullText, lV47FilterFullText, lV47FilterFullText, lV11TFProfesionalesId, AV12TFProfesionalesId_Sel, lV13TFProfesionalesPrimerNombre, AV14TFProfesionalesPrimerNombre_Sel, lV15TFProfesionalesSegundoNombre, AV16TFProfesionalesSegundoNombre_Sel, lV17TFProfesionalesApellidoPrimero, AV18TFProfesionalesApellidoPrimero_Sel, lV19TFProfesionalesApellidoSegundo, AV20TFProfesionalesApellidoSegundo_Sel, lV21TFProfesionalesTelefono, AV22TFProfesionalesTelefono_Sel, lV23TFProfesionalesEmail, AV24TFProfesionalesEmail_Sel});
         while ( (pr_default.getStatus(1) != 101) )
         {
            BRKBG3 = false;
            A166ProfesionalesPrimerNombre = P00BG3_A166ProfesionalesPrimerNombre[0];
            A108EstadosGenericosId = P00BG3_A108EstadosGenericosId[0];
            A193ProfesionalesEmail = P00BG3_A193ProfesionalesEmail[0];
            n193ProfesionalesEmail = P00BG3_n193ProfesionalesEmail[0];
            A170ProfesionalesTelefono = P00BG3_A170ProfesionalesTelefono[0];
            A192ProfesionalesApellidoSegundo = P00BG3_A192ProfesionalesApellidoSegundo[0];
            A167ProfesionalesApellidoPrimero = P00BG3_A167ProfesionalesApellidoPrimero[0];
            A191ProfesionalesSegundoNombre = P00BG3_A191ProfesionalesSegundoNombre[0];
            A120ProfesionalesId = P00BG3_A120ProfesionalesId[0];
            AV35count = 0;
            while ( (pr_default.getStatus(1) != 101) && ( StringUtil.StrCmp(P00BG3_A166ProfesionalesPrimerNombre[0], A166ProfesionalesPrimerNombre) == 0 ) )
            {
               BRKBG3 = false;
               A120ProfesionalesId = P00BG3_A120ProfesionalesId[0];
               AV35count = (long)(AV35count+1);
               BRKBG3 = true;
               pr_default.readNext(1);
            }
            if ( (0==AV26SkipItems) )
            {
               AV30Option = (String.IsNullOrEmpty(StringUtil.RTrim( A166ProfesionalesPrimerNombre)) ? "<#Empty#>" : A166ProfesionalesPrimerNombre);
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
            if ( ! BRKBG3 )
            {
               BRKBG3 = true;
               pr_default.readNext(1);
            }
         }
         pr_default.close(1);
      }

      protected void S141( )
      {
         /* 'LOADPROFESIONALESSEGUNDONOMBREOPTIONS' Routine */
         returnInSub = false;
         AV15TFProfesionalesSegundoNombre = AV25SearchTxt;
         AV16TFProfesionalesSegundoNombre_Sel = "";
         pr_default.dynParam(2, new Object[]{ new Object[]{
                                              AV47FilterFullText ,
                                              AV12TFProfesionalesId_Sel ,
                                              AV11TFProfesionalesId ,
                                              AV14TFProfesionalesPrimerNombre_Sel ,
                                              AV13TFProfesionalesPrimerNombre ,
                                              AV16TFProfesionalesSegundoNombre_Sel ,
                                              AV15TFProfesionalesSegundoNombre ,
                                              AV18TFProfesionalesApellidoPrimero_Sel ,
                                              AV17TFProfesionalesApellidoPrimero ,
                                              AV20TFProfesionalesApellidoSegundo_Sel ,
                                              AV19TFProfesionalesApellidoSegundo ,
                                              AV22TFProfesionalesTelefono_Sel ,
                                              AV21TFProfesionalesTelefono ,
                                              AV24TFProfesionalesEmail_Sel ,
                                              AV23TFProfesionalesEmail ,
                                              A120ProfesionalesId ,
                                              A166ProfesionalesPrimerNombre ,
                                              A191ProfesionalesSegundoNombre ,
                                              A167ProfesionalesApellidoPrimero ,
                                              A192ProfesionalesApellidoSegundo ,
                                              A170ProfesionalesTelefono ,
                                              A193ProfesionalesEmail ,
                                              A108EstadosGenericosId } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.INT
                                              }
         });
         lV47FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV47FilterFullText), "%", "");
         lV47FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV47FilterFullText), "%", "");
         lV47FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV47FilterFullText), "%", "");
         lV47FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV47FilterFullText), "%", "");
         lV47FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV47FilterFullText), "%", "");
         lV47FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV47FilterFullText), "%", "");
         lV47FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV47FilterFullText), "%", "");
         lV11TFProfesionalesId = StringUtil.PadR( StringUtil.RTrim( AV11TFProfesionalesId), 20, "%");
         lV13TFProfesionalesPrimerNombre = StringUtil.PadR( StringUtil.RTrim( AV13TFProfesionalesPrimerNombre), 30, "%");
         lV15TFProfesionalesSegundoNombre = StringUtil.PadR( StringUtil.RTrim( AV15TFProfesionalesSegundoNombre), 30, "%");
         lV17TFProfesionalesApellidoPrimero = StringUtil.PadR( StringUtil.RTrim( AV17TFProfesionalesApellidoPrimero), 30, "%");
         lV19TFProfesionalesApellidoSegundo = StringUtil.PadR( StringUtil.RTrim( AV19TFProfesionalesApellidoSegundo), 30, "%");
         lV21TFProfesionalesTelefono = StringUtil.PadR( StringUtil.RTrim( AV21TFProfesionalesTelefono), 20, "%");
         lV23TFProfesionalesEmail = StringUtil.Concat( StringUtil.RTrim( AV23TFProfesionalesEmail), "%", "");
         /* Using cursor P00BG4 */
         pr_default.execute(2, new Object[] {lV47FilterFullText, lV47FilterFullText, lV47FilterFullText, lV47FilterFullText, lV47FilterFullText, lV47FilterFullText, lV47FilterFullText, lV11TFProfesionalesId, AV12TFProfesionalesId_Sel, lV13TFProfesionalesPrimerNombre, AV14TFProfesionalesPrimerNombre_Sel, lV15TFProfesionalesSegundoNombre, AV16TFProfesionalesSegundoNombre_Sel, lV17TFProfesionalesApellidoPrimero, AV18TFProfesionalesApellidoPrimero_Sel, lV19TFProfesionalesApellidoSegundo, AV20TFProfesionalesApellidoSegundo_Sel, lV21TFProfesionalesTelefono, AV22TFProfesionalesTelefono_Sel, lV23TFProfesionalesEmail, AV24TFProfesionalesEmail_Sel});
         while ( (pr_default.getStatus(2) != 101) )
         {
            BRKBG5 = false;
            A191ProfesionalesSegundoNombre = P00BG4_A191ProfesionalesSegundoNombre[0];
            A108EstadosGenericosId = P00BG4_A108EstadosGenericosId[0];
            A193ProfesionalesEmail = P00BG4_A193ProfesionalesEmail[0];
            n193ProfesionalesEmail = P00BG4_n193ProfesionalesEmail[0];
            A170ProfesionalesTelefono = P00BG4_A170ProfesionalesTelefono[0];
            A192ProfesionalesApellidoSegundo = P00BG4_A192ProfesionalesApellidoSegundo[0];
            A167ProfesionalesApellidoPrimero = P00BG4_A167ProfesionalesApellidoPrimero[0];
            A166ProfesionalesPrimerNombre = P00BG4_A166ProfesionalesPrimerNombre[0];
            A120ProfesionalesId = P00BG4_A120ProfesionalesId[0];
            AV35count = 0;
            while ( (pr_default.getStatus(2) != 101) && ( StringUtil.StrCmp(P00BG4_A191ProfesionalesSegundoNombre[0], A191ProfesionalesSegundoNombre) == 0 ) )
            {
               BRKBG5 = false;
               A120ProfesionalesId = P00BG4_A120ProfesionalesId[0];
               AV35count = (long)(AV35count+1);
               BRKBG5 = true;
               pr_default.readNext(2);
            }
            if ( (0==AV26SkipItems) )
            {
               AV30Option = (String.IsNullOrEmpty(StringUtil.RTrim( A191ProfesionalesSegundoNombre)) ? "<#Empty#>" : A191ProfesionalesSegundoNombre);
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
            if ( ! BRKBG5 )
            {
               BRKBG5 = true;
               pr_default.readNext(2);
            }
         }
         pr_default.close(2);
      }

      protected void S151( )
      {
         /* 'LOADPROFESIONALESAPELLIDOPRIMEROOPTIONS' Routine */
         returnInSub = false;
         AV17TFProfesionalesApellidoPrimero = AV25SearchTxt;
         AV18TFProfesionalesApellidoPrimero_Sel = "";
         pr_default.dynParam(3, new Object[]{ new Object[]{
                                              AV47FilterFullText ,
                                              AV12TFProfesionalesId_Sel ,
                                              AV11TFProfesionalesId ,
                                              AV14TFProfesionalesPrimerNombre_Sel ,
                                              AV13TFProfesionalesPrimerNombre ,
                                              AV16TFProfesionalesSegundoNombre_Sel ,
                                              AV15TFProfesionalesSegundoNombre ,
                                              AV18TFProfesionalesApellidoPrimero_Sel ,
                                              AV17TFProfesionalesApellidoPrimero ,
                                              AV20TFProfesionalesApellidoSegundo_Sel ,
                                              AV19TFProfesionalesApellidoSegundo ,
                                              AV22TFProfesionalesTelefono_Sel ,
                                              AV21TFProfesionalesTelefono ,
                                              AV24TFProfesionalesEmail_Sel ,
                                              AV23TFProfesionalesEmail ,
                                              A120ProfesionalesId ,
                                              A166ProfesionalesPrimerNombre ,
                                              A191ProfesionalesSegundoNombre ,
                                              A167ProfesionalesApellidoPrimero ,
                                              A192ProfesionalesApellidoSegundo ,
                                              A170ProfesionalesTelefono ,
                                              A193ProfesionalesEmail ,
                                              A108EstadosGenericosId } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.INT
                                              }
         });
         lV47FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV47FilterFullText), "%", "");
         lV47FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV47FilterFullText), "%", "");
         lV47FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV47FilterFullText), "%", "");
         lV47FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV47FilterFullText), "%", "");
         lV47FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV47FilterFullText), "%", "");
         lV47FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV47FilterFullText), "%", "");
         lV47FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV47FilterFullText), "%", "");
         lV11TFProfesionalesId = StringUtil.PadR( StringUtil.RTrim( AV11TFProfesionalesId), 20, "%");
         lV13TFProfesionalesPrimerNombre = StringUtil.PadR( StringUtil.RTrim( AV13TFProfesionalesPrimerNombre), 30, "%");
         lV15TFProfesionalesSegundoNombre = StringUtil.PadR( StringUtil.RTrim( AV15TFProfesionalesSegundoNombre), 30, "%");
         lV17TFProfesionalesApellidoPrimero = StringUtil.PadR( StringUtil.RTrim( AV17TFProfesionalesApellidoPrimero), 30, "%");
         lV19TFProfesionalesApellidoSegundo = StringUtil.PadR( StringUtil.RTrim( AV19TFProfesionalesApellidoSegundo), 30, "%");
         lV21TFProfesionalesTelefono = StringUtil.PadR( StringUtil.RTrim( AV21TFProfesionalesTelefono), 20, "%");
         lV23TFProfesionalesEmail = StringUtil.Concat( StringUtil.RTrim( AV23TFProfesionalesEmail), "%", "");
         /* Using cursor P00BG5 */
         pr_default.execute(3, new Object[] {lV47FilterFullText, lV47FilterFullText, lV47FilterFullText, lV47FilterFullText, lV47FilterFullText, lV47FilterFullText, lV47FilterFullText, lV11TFProfesionalesId, AV12TFProfesionalesId_Sel, lV13TFProfesionalesPrimerNombre, AV14TFProfesionalesPrimerNombre_Sel, lV15TFProfesionalesSegundoNombre, AV16TFProfesionalesSegundoNombre_Sel, lV17TFProfesionalesApellidoPrimero, AV18TFProfesionalesApellidoPrimero_Sel, lV19TFProfesionalesApellidoSegundo, AV20TFProfesionalesApellidoSegundo_Sel, lV21TFProfesionalesTelefono, AV22TFProfesionalesTelefono_Sel, lV23TFProfesionalesEmail, AV24TFProfesionalesEmail_Sel});
         while ( (pr_default.getStatus(3) != 101) )
         {
            BRKBG7 = false;
            A167ProfesionalesApellidoPrimero = P00BG5_A167ProfesionalesApellidoPrimero[0];
            A108EstadosGenericosId = P00BG5_A108EstadosGenericosId[0];
            A193ProfesionalesEmail = P00BG5_A193ProfesionalesEmail[0];
            n193ProfesionalesEmail = P00BG5_n193ProfesionalesEmail[0];
            A170ProfesionalesTelefono = P00BG5_A170ProfesionalesTelefono[0];
            A192ProfesionalesApellidoSegundo = P00BG5_A192ProfesionalesApellidoSegundo[0];
            A191ProfesionalesSegundoNombre = P00BG5_A191ProfesionalesSegundoNombre[0];
            A166ProfesionalesPrimerNombre = P00BG5_A166ProfesionalesPrimerNombre[0];
            A120ProfesionalesId = P00BG5_A120ProfesionalesId[0];
            AV35count = 0;
            while ( (pr_default.getStatus(3) != 101) && ( StringUtil.StrCmp(P00BG5_A167ProfesionalesApellidoPrimero[0], A167ProfesionalesApellidoPrimero) == 0 ) )
            {
               BRKBG7 = false;
               A120ProfesionalesId = P00BG5_A120ProfesionalesId[0];
               AV35count = (long)(AV35count+1);
               BRKBG7 = true;
               pr_default.readNext(3);
            }
            if ( (0==AV26SkipItems) )
            {
               AV30Option = (String.IsNullOrEmpty(StringUtil.RTrim( A167ProfesionalesApellidoPrimero)) ? "<#Empty#>" : A167ProfesionalesApellidoPrimero);
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
            if ( ! BRKBG7 )
            {
               BRKBG7 = true;
               pr_default.readNext(3);
            }
         }
         pr_default.close(3);
      }

      protected void S161( )
      {
         /* 'LOADPROFESIONALESAPELLIDOSEGUNDOOPTIONS' Routine */
         returnInSub = false;
         AV19TFProfesionalesApellidoSegundo = AV25SearchTxt;
         AV20TFProfesionalesApellidoSegundo_Sel = "";
         pr_default.dynParam(4, new Object[]{ new Object[]{
                                              AV47FilterFullText ,
                                              AV12TFProfesionalesId_Sel ,
                                              AV11TFProfesionalesId ,
                                              AV14TFProfesionalesPrimerNombre_Sel ,
                                              AV13TFProfesionalesPrimerNombre ,
                                              AV16TFProfesionalesSegundoNombre_Sel ,
                                              AV15TFProfesionalesSegundoNombre ,
                                              AV18TFProfesionalesApellidoPrimero_Sel ,
                                              AV17TFProfesionalesApellidoPrimero ,
                                              AV20TFProfesionalesApellidoSegundo_Sel ,
                                              AV19TFProfesionalesApellidoSegundo ,
                                              AV22TFProfesionalesTelefono_Sel ,
                                              AV21TFProfesionalesTelefono ,
                                              AV24TFProfesionalesEmail_Sel ,
                                              AV23TFProfesionalesEmail ,
                                              A120ProfesionalesId ,
                                              A166ProfesionalesPrimerNombre ,
                                              A191ProfesionalesSegundoNombre ,
                                              A167ProfesionalesApellidoPrimero ,
                                              A192ProfesionalesApellidoSegundo ,
                                              A170ProfesionalesTelefono ,
                                              A193ProfesionalesEmail ,
                                              A108EstadosGenericosId } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.INT
                                              }
         });
         lV47FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV47FilterFullText), "%", "");
         lV47FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV47FilterFullText), "%", "");
         lV47FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV47FilterFullText), "%", "");
         lV47FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV47FilterFullText), "%", "");
         lV47FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV47FilterFullText), "%", "");
         lV47FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV47FilterFullText), "%", "");
         lV47FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV47FilterFullText), "%", "");
         lV11TFProfesionalesId = StringUtil.PadR( StringUtil.RTrim( AV11TFProfesionalesId), 20, "%");
         lV13TFProfesionalesPrimerNombre = StringUtil.PadR( StringUtil.RTrim( AV13TFProfesionalesPrimerNombre), 30, "%");
         lV15TFProfesionalesSegundoNombre = StringUtil.PadR( StringUtil.RTrim( AV15TFProfesionalesSegundoNombre), 30, "%");
         lV17TFProfesionalesApellidoPrimero = StringUtil.PadR( StringUtil.RTrim( AV17TFProfesionalesApellidoPrimero), 30, "%");
         lV19TFProfesionalesApellidoSegundo = StringUtil.PadR( StringUtil.RTrim( AV19TFProfesionalesApellidoSegundo), 30, "%");
         lV21TFProfesionalesTelefono = StringUtil.PadR( StringUtil.RTrim( AV21TFProfesionalesTelefono), 20, "%");
         lV23TFProfesionalesEmail = StringUtil.Concat( StringUtil.RTrim( AV23TFProfesionalesEmail), "%", "");
         /* Using cursor P00BG6 */
         pr_default.execute(4, new Object[] {lV47FilterFullText, lV47FilterFullText, lV47FilterFullText, lV47FilterFullText, lV47FilterFullText, lV47FilterFullText, lV47FilterFullText, lV11TFProfesionalesId, AV12TFProfesionalesId_Sel, lV13TFProfesionalesPrimerNombre, AV14TFProfesionalesPrimerNombre_Sel, lV15TFProfesionalesSegundoNombre, AV16TFProfesionalesSegundoNombre_Sel, lV17TFProfesionalesApellidoPrimero, AV18TFProfesionalesApellidoPrimero_Sel, lV19TFProfesionalesApellidoSegundo, AV20TFProfesionalesApellidoSegundo_Sel, lV21TFProfesionalesTelefono, AV22TFProfesionalesTelefono_Sel, lV23TFProfesionalesEmail, AV24TFProfesionalesEmail_Sel});
         while ( (pr_default.getStatus(4) != 101) )
         {
            BRKBG9 = false;
            A192ProfesionalesApellidoSegundo = P00BG6_A192ProfesionalesApellidoSegundo[0];
            A108EstadosGenericosId = P00BG6_A108EstadosGenericosId[0];
            A193ProfesionalesEmail = P00BG6_A193ProfesionalesEmail[0];
            n193ProfesionalesEmail = P00BG6_n193ProfesionalesEmail[0];
            A170ProfesionalesTelefono = P00BG6_A170ProfesionalesTelefono[0];
            A167ProfesionalesApellidoPrimero = P00BG6_A167ProfesionalesApellidoPrimero[0];
            A191ProfesionalesSegundoNombre = P00BG6_A191ProfesionalesSegundoNombre[0];
            A166ProfesionalesPrimerNombre = P00BG6_A166ProfesionalesPrimerNombre[0];
            A120ProfesionalesId = P00BG6_A120ProfesionalesId[0];
            AV35count = 0;
            while ( (pr_default.getStatus(4) != 101) && ( StringUtil.StrCmp(P00BG6_A192ProfesionalesApellidoSegundo[0], A192ProfesionalesApellidoSegundo) == 0 ) )
            {
               BRKBG9 = false;
               A120ProfesionalesId = P00BG6_A120ProfesionalesId[0];
               AV35count = (long)(AV35count+1);
               BRKBG9 = true;
               pr_default.readNext(4);
            }
            if ( (0==AV26SkipItems) )
            {
               AV30Option = (String.IsNullOrEmpty(StringUtil.RTrim( A192ProfesionalesApellidoSegundo)) ? "<#Empty#>" : A192ProfesionalesApellidoSegundo);
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
            if ( ! BRKBG9 )
            {
               BRKBG9 = true;
               pr_default.readNext(4);
            }
         }
         pr_default.close(4);
      }

      protected void S171( )
      {
         /* 'LOADPROFESIONALESTELEFONOOPTIONS' Routine */
         returnInSub = false;
         AV21TFProfesionalesTelefono = AV25SearchTxt;
         AV22TFProfesionalesTelefono_Sel = "";
         pr_default.dynParam(5, new Object[]{ new Object[]{
                                              AV47FilterFullText ,
                                              AV12TFProfesionalesId_Sel ,
                                              AV11TFProfesionalesId ,
                                              AV14TFProfesionalesPrimerNombre_Sel ,
                                              AV13TFProfesionalesPrimerNombre ,
                                              AV16TFProfesionalesSegundoNombre_Sel ,
                                              AV15TFProfesionalesSegundoNombre ,
                                              AV18TFProfesionalesApellidoPrimero_Sel ,
                                              AV17TFProfesionalesApellidoPrimero ,
                                              AV20TFProfesionalesApellidoSegundo_Sel ,
                                              AV19TFProfesionalesApellidoSegundo ,
                                              AV22TFProfesionalesTelefono_Sel ,
                                              AV21TFProfesionalesTelefono ,
                                              AV24TFProfesionalesEmail_Sel ,
                                              AV23TFProfesionalesEmail ,
                                              A120ProfesionalesId ,
                                              A166ProfesionalesPrimerNombre ,
                                              A191ProfesionalesSegundoNombre ,
                                              A167ProfesionalesApellidoPrimero ,
                                              A192ProfesionalesApellidoSegundo ,
                                              A170ProfesionalesTelefono ,
                                              A193ProfesionalesEmail ,
                                              A108EstadosGenericosId } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.INT
                                              }
         });
         lV47FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV47FilterFullText), "%", "");
         lV47FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV47FilterFullText), "%", "");
         lV47FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV47FilterFullText), "%", "");
         lV47FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV47FilterFullText), "%", "");
         lV47FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV47FilterFullText), "%", "");
         lV47FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV47FilterFullText), "%", "");
         lV47FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV47FilterFullText), "%", "");
         lV11TFProfesionalesId = StringUtil.PadR( StringUtil.RTrim( AV11TFProfesionalesId), 20, "%");
         lV13TFProfesionalesPrimerNombre = StringUtil.PadR( StringUtil.RTrim( AV13TFProfesionalesPrimerNombre), 30, "%");
         lV15TFProfesionalesSegundoNombre = StringUtil.PadR( StringUtil.RTrim( AV15TFProfesionalesSegundoNombre), 30, "%");
         lV17TFProfesionalesApellidoPrimero = StringUtil.PadR( StringUtil.RTrim( AV17TFProfesionalesApellidoPrimero), 30, "%");
         lV19TFProfesionalesApellidoSegundo = StringUtil.PadR( StringUtil.RTrim( AV19TFProfesionalesApellidoSegundo), 30, "%");
         lV21TFProfesionalesTelefono = StringUtil.PadR( StringUtil.RTrim( AV21TFProfesionalesTelefono), 20, "%");
         lV23TFProfesionalesEmail = StringUtil.Concat( StringUtil.RTrim( AV23TFProfesionalesEmail), "%", "");
         /* Using cursor P00BG7 */
         pr_default.execute(5, new Object[] {lV47FilterFullText, lV47FilterFullText, lV47FilterFullText, lV47FilterFullText, lV47FilterFullText, lV47FilterFullText, lV47FilterFullText, lV11TFProfesionalesId, AV12TFProfesionalesId_Sel, lV13TFProfesionalesPrimerNombre, AV14TFProfesionalesPrimerNombre_Sel, lV15TFProfesionalesSegundoNombre, AV16TFProfesionalesSegundoNombre_Sel, lV17TFProfesionalesApellidoPrimero, AV18TFProfesionalesApellidoPrimero_Sel, lV19TFProfesionalesApellidoSegundo, AV20TFProfesionalesApellidoSegundo_Sel, lV21TFProfesionalesTelefono, AV22TFProfesionalesTelefono_Sel, lV23TFProfesionalesEmail, AV24TFProfesionalesEmail_Sel});
         while ( (pr_default.getStatus(5) != 101) )
         {
            BRKBG11 = false;
            A170ProfesionalesTelefono = P00BG7_A170ProfesionalesTelefono[0];
            A108EstadosGenericosId = P00BG7_A108EstadosGenericosId[0];
            A193ProfesionalesEmail = P00BG7_A193ProfesionalesEmail[0];
            n193ProfesionalesEmail = P00BG7_n193ProfesionalesEmail[0];
            A192ProfesionalesApellidoSegundo = P00BG7_A192ProfesionalesApellidoSegundo[0];
            A167ProfesionalesApellidoPrimero = P00BG7_A167ProfesionalesApellidoPrimero[0];
            A191ProfesionalesSegundoNombre = P00BG7_A191ProfesionalesSegundoNombre[0];
            A166ProfesionalesPrimerNombre = P00BG7_A166ProfesionalesPrimerNombre[0];
            A120ProfesionalesId = P00BG7_A120ProfesionalesId[0];
            AV35count = 0;
            while ( (pr_default.getStatus(5) != 101) && ( StringUtil.StrCmp(P00BG7_A170ProfesionalesTelefono[0], A170ProfesionalesTelefono) == 0 ) )
            {
               BRKBG11 = false;
               A120ProfesionalesId = P00BG7_A120ProfesionalesId[0];
               AV35count = (long)(AV35count+1);
               BRKBG11 = true;
               pr_default.readNext(5);
            }
            if ( (0==AV26SkipItems) )
            {
               AV30Option = (String.IsNullOrEmpty(StringUtil.RTrim( A170ProfesionalesTelefono)) ? "<#Empty#>" : A170ProfesionalesTelefono);
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
            if ( ! BRKBG11 )
            {
               BRKBG11 = true;
               pr_default.readNext(5);
            }
         }
         pr_default.close(5);
      }

      protected void S181( )
      {
         /* 'LOADPROFESIONALESEMAILOPTIONS' Routine */
         returnInSub = false;
         AV23TFProfesionalesEmail = AV25SearchTxt;
         AV24TFProfesionalesEmail_Sel = "";
         pr_default.dynParam(6, new Object[]{ new Object[]{
                                              AV47FilterFullText ,
                                              AV12TFProfesionalesId_Sel ,
                                              AV11TFProfesionalesId ,
                                              AV14TFProfesionalesPrimerNombre_Sel ,
                                              AV13TFProfesionalesPrimerNombre ,
                                              AV16TFProfesionalesSegundoNombre_Sel ,
                                              AV15TFProfesionalesSegundoNombre ,
                                              AV18TFProfesionalesApellidoPrimero_Sel ,
                                              AV17TFProfesionalesApellidoPrimero ,
                                              AV20TFProfesionalesApellidoSegundo_Sel ,
                                              AV19TFProfesionalesApellidoSegundo ,
                                              AV22TFProfesionalesTelefono_Sel ,
                                              AV21TFProfesionalesTelefono ,
                                              AV24TFProfesionalesEmail_Sel ,
                                              AV23TFProfesionalesEmail ,
                                              A120ProfesionalesId ,
                                              A166ProfesionalesPrimerNombre ,
                                              A191ProfesionalesSegundoNombre ,
                                              A167ProfesionalesApellidoPrimero ,
                                              A192ProfesionalesApellidoSegundo ,
                                              A170ProfesionalesTelefono ,
                                              A193ProfesionalesEmail ,
                                              A108EstadosGenericosId } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.INT
                                              }
         });
         lV47FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV47FilterFullText), "%", "");
         lV47FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV47FilterFullText), "%", "");
         lV47FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV47FilterFullText), "%", "");
         lV47FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV47FilterFullText), "%", "");
         lV47FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV47FilterFullText), "%", "");
         lV47FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV47FilterFullText), "%", "");
         lV47FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV47FilterFullText), "%", "");
         lV11TFProfesionalesId = StringUtil.PadR( StringUtil.RTrim( AV11TFProfesionalesId), 20, "%");
         lV13TFProfesionalesPrimerNombre = StringUtil.PadR( StringUtil.RTrim( AV13TFProfesionalesPrimerNombre), 30, "%");
         lV15TFProfesionalesSegundoNombre = StringUtil.PadR( StringUtil.RTrim( AV15TFProfesionalesSegundoNombre), 30, "%");
         lV17TFProfesionalesApellidoPrimero = StringUtil.PadR( StringUtil.RTrim( AV17TFProfesionalesApellidoPrimero), 30, "%");
         lV19TFProfesionalesApellidoSegundo = StringUtil.PadR( StringUtil.RTrim( AV19TFProfesionalesApellidoSegundo), 30, "%");
         lV21TFProfesionalesTelefono = StringUtil.PadR( StringUtil.RTrim( AV21TFProfesionalesTelefono), 20, "%");
         lV23TFProfesionalesEmail = StringUtil.Concat( StringUtil.RTrim( AV23TFProfesionalesEmail), "%", "");
         /* Using cursor P00BG8 */
         pr_default.execute(6, new Object[] {lV47FilterFullText, lV47FilterFullText, lV47FilterFullText, lV47FilterFullText, lV47FilterFullText, lV47FilterFullText, lV47FilterFullText, lV11TFProfesionalesId, AV12TFProfesionalesId_Sel, lV13TFProfesionalesPrimerNombre, AV14TFProfesionalesPrimerNombre_Sel, lV15TFProfesionalesSegundoNombre, AV16TFProfesionalesSegundoNombre_Sel, lV17TFProfesionalesApellidoPrimero, AV18TFProfesionalesApellidoPrimero_Sel, lV19TFProfesionalesApellidoSegundo, AV20TFProfesionalesApellidoSegundo_Sel, lV21TFProfesionalesTelefono, AV22TFProfesionalesTelefono_Sel, lV23TFProfesionalesEmail, AV24TFProfesionalesEmail_Sel});
         while ( (pr_default.getStatus(6) != 101) )
         {
            BRKBG13 = false;
            A193ProfesionalesEmail = P00BG8_A193ProfesionalesEmail[0];
            n193ProfesionalesEmail = P00BG8_n193ProfesionalesEmail[0];
            A108EstadosGenericosId = P00BG8_A108EstadosGenericosId[0];
            A170ProfesionalesTelefono = P00BG8_A170ProfesionalesTelefono[0];
            A192ProfesionalesApellidoSegundo = P00BG8_A192ProfesionalesApellidoSegundo[0];
            A167ProfesionalesApellidoPrimero = P00BG8_A167ProfesionalesApellidoPrimero[0];
            A191ProfesionalesSegundoNombre = P00BG8_A191ProfesionalesSegundoNombre[0];
            A166ProfesionalesPrimerNombre = P00BG8_A166ProfesionalesPrimerNombre[0];
            A120ProfesionalesId = P00BG8_A120ProfesionalesId[0];
            AV35count = 0;
            while ( (pr_default.getStatus(6) != 101) && ( StringUtil.StrCmp(P00BG8_A193ProfesionalesEmail[0], A193ProfesionalesEmail) == 0 ) )
            {
               BRKBG13 = false;
               A120ProfesionalesId = P00BG8_A120ProfesionalesId[0];
               AV35count = (long)(AV35count+1);
               BRKBG13 = true;
               pr_default.readNext(6);
            }
            if ( (0==AV26SkipItems) )
            {
               AV30Option = (String.IsNullOrEmpty(StringUtil.RTrim( A193ProfesionalesEmail)) ? "<#Empty#>" : A193ProfesionalesEmail);
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
            if ( ! BRKBG13 )
            {
               BRKBG13 = true;
               pr_default.readNext(6);
            }
         }
         pr_default.close(6);
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
         AV11TFProfesionalesId = "";
         AV12TFProfesionalesId_Sel = "";
         AV13TFProfesionalesPrimerNombre = "";
         AV14TFProfesionalesPrimerNombre_Sel = "";
         AV15TFProfesionalesSegundoNombre = "";
         AV16TFProfesionalesSegundoNombre_Sel = "";
         AV17TFProfesionalesApellidoPrimero = "";
         AV18TFProfesionalesApellidoPrimero_Sel = "";
         AV19TFProfesionalesApellidoSegundo = "";
         AV20TFProfesionalesApellidoSegundo_Sel = "";
         AV21TFProfesionalesTelefono = "";
         AV22TFProfesionalesTelefono_Sel = "";
         AV23TFProfesionalesEmail = "";
         AV24TFProfesionalesEmail_Sel = "";
         lV47FilterFullText = "";
         lV11TFProfesionalesId = "";
         lV13TFProfesionalesPrimerNombre = "";
         lV15TFProfesionalesSegundoNombre = "";
         lV17TFProfesionalesApellidoPrimero = "";
         lV19TFProfesionalesApellidoSegundo = "";
         lV21TFProfesionalesTelefono = "";
         lV23TFProfesionalesEmail = "";
         A120ProfesionalesId = "";
         A166ProfesionalesPrimerNombre = "";
         A191ProfesionalesSegundoNombre = "";
         A167ProfesionalesApellidoPrimero = "";
         A192ProfesionalesApellidoSegundo = "";
         A170ProfesionalesTelefono = "";
         A193ProfesionalesEmail = "";
         P00BG2_A108EstadosGenericosId = new int[1] ;
         P00BG2_A193ProfesionalesEmail = new string[] {""} ;
         P00BG2_n193ProfesionalesEmail = new bool[] {false} ;
         P00BG2_A170ProfesionalesTelefono = new string[] {""} ;
         P00BG2_A192ProfesionalesApellidoSegundo = new string[] {""} ;
         P00BG2_A167ProfesionalesApellidoPrimero = new string[] {""} ;
         P00BG2_A191ProfesionalesSegundoNombre = new string[] {""} ;
         P00BG2_A166ProfesionalesPrimerNombre = new string[] {""} ;
         P00BG2_A120ProfesionalesId = new string[] {""} ;
         AV30Option = "";
         P00BG3_A166ProfesionalesPrimerNombre = new string[] {""} ;
         P00BG3_A108EstadosGenericosId = new int[1] ;
         P00BG3_A193ProfesionalesEmail = new string[] {""} ;
         P00BG3_n193ProfesionalesEmail = new bool[] {false} ;
         P00BG3_A170ProfesionalesTelefono = new string[] {""} ;
         P00BG3_A192ProfesionalesApellidoSegundo = new string[] {""} ;
         P00BG3_A167ProfesionalesApellidoPrimero = new string[] {""} ;
         P00BG3_A191ProfesionalesSegundoNombre = new string[] {""} ;
         P00BG3_A120ProfesionalesId = new string[] {""} ;
         P00BG4_A191ProfesionalesSegundoNombre = new string[] {""} ;
         P00BG4_A108EstadosGenericosId = new int[1] ;
         P00BG4_A193ProfesionalesEmail = new string[] {""} ;
         P00BG4_n193ProfesionalesEmail = new bool[] {false} ;
         P00BG4_A170ProfesionalesTelefono = new string[] {""} ;
         P00BG4_A192ProfesionalesApellidoSegundo = new string[] {""} ;
         P00BG4_A167ProfesionalesApellidoPrimero = new string[] {""} ;
         P00BG4_A166ProfesionalesPrimerNombre = new string[] {""} ;
         P00BG4_A120ProfesionalesId = new string[] {""} ;
         P00BG5_A167ProfesionalesApellidoPrimero = new string[] {""} ;
         P00BG5_A108EstadosGenericosId = new int[1] ;
         P00BG5_A193ProfesionalesEmail = new string[] {""} ;
         P00BG5_n193ProfesionalesEmail = new bool[] {false} ;
         P00BG5_A170ProfesionalesTelefono = new string[] {""} ;
         P00BG5_A192ProfesionalesApellidoSegundo = new string[] {""} ;
         P00BG5_A191ProfesionalesSegundoNombre = new string[] {""} ;
         P00BG5_A166ProfesionalesPrimerNombre = new string[] {""} ;
         P00BG5_A120ProfesionalesId = new string[] {""} ;
         P00BG6_A192ProfesionalesApellidoSegundo = new string[] {""} ;
         P00BG6_A108EstadosGenericosId = new int[1] ;
         P00BG6_A193ProfesionalesEmail = new string[] {""} ;
         P00BG6_n193ProfesionalesEmail = new bool[] {false} ;
         P00BG6_A170ProfesionalesTelefono = new string[] {""} ;
         P00BG6_A167ProfesionalesApellidoPrimero = new string[] {""} ;
         P00BG6_A191ProfesionalesSegundoNombre = new string[] {""} ;
         P00BG6_A166ProfesionalesPrimerNombre = new string[] {""} ;
         P00BG6_A120ProfesionalesId = new string[] {""} ;
         P00BG7_A170ProfesionalesTelefono = new string[] {""} ;
         P00BG7_A108EstadosGenericosId = new int[1] ;
         P00BG7_A193ProfesionalesEmail = new string[] {""} ;
         P00BG7_n193ProfesionalesEmail = new bool[] {false} ;
         P00BG7_A192ProfesionalesApellidoSegundo = new string[] {""} ;
         P00BG7_A167ProfesionalesApellidoPrimero = new string[] {""} ;
         P00BG7_A191ProfesionalesSegundoNombre = new string[] {""} ;
         P00BG7_A166ProfesionalesPrimerNombre = new string[] {""} ;
         P00BG7_A120ProfesionalesId = new string[] {""} ;
         P00BG8_A193ProfesionalesEmail = new string[] {""} ;
         P00BG8_n193ProfesionalesEmail = new bool[] {false} ;
         P00BG8_A108EstadosGenericosId = new int[1] ;
         P00BG8_A170ProfesionalesTelefono = new string[] {""} ;
         P00BG8_A192ProfesionalesApellidoSegundo = new string[] {""} ;
         P00BG8_A167ProfesionalesApellidoPrimero = new string[] {""} ;
         P00BG8_A191ProfesionalesSegundoNombre = new string[] {""} ;
         P00BG8_A166ProfesionalesPrimerNombre = new string[] {""} ;
         P00BG8_A120ProfesionalesId = new string[] {""} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.profesionalesfullnamepromptgetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P00BG2_A108EstadosGenericosId, P00BG2_A193ProfesionalesEmail, P00BG2_n193ProfesionalesEmail, P00BG2_A170ProfesionalesTelefono, P00BG2_A192ProfesionalesApellidoSegundo, P00BG2_A167ProfesionalesApellidoPrimero, P00BG2_A191ProfesionalesSegundoNombre, P00BG2_A166ProfesionalesPrimerNombre, P00BG2_A120ProfesionalesId
               }
               , new Object[] {
               P00BG3_A166ProfesionalesPrimerNombre, P00BG3_A108EstadosGenericosId, P00BG3_A193ProfesionalesEmail, P00BG3_n193ProfesionalesEmail, P00BG3_A170ProfesionalesTelefono, P00BG3_A192ProfesionalesApellidoSegundo, P00BG3_A167ProfesionalesApellidoPrimero, P00BG3_A191ProfesionalesSegundoNombre, P00BG3_A120ProfesionalesId
               }
               , new Object[] {
               P00BG4_A191ProfesionalesSegundoNombre, P00BG4_A108EstadosGenericosId, P00BG4_A193ProfesionalesEmail, P00BG4_n193ProfesionalesEmail, P00BG4_A170ProfesionalesTelefono, P00BG4_A192ProfesionalesApellidoSegundo, P00BG4_A167ProfesionalesApellidoPrimero, P00BG4_A166ProfesionalesPrimerNombre, P00BG4_A120ProfesionalesId
               }
               , new Object[] {
               P00BG5_A167ProfesionalesApellidoPrimero, P00BG5_A108EstadosGenericosId, P00BG5_A193ProfesionalesEmail, P00BG5_n193ProfesionalesEmail, P00BG5_A170ProfesionalesTelefono, P00BG5_A192ProfesionalesApellidoSegundo, P00BG5_A191ProfesionalesSegundoNombre, P00BG5_A166ProfesionalesPrimerNombre, P00BG5_A120ProfesionalesId
               }
               , new Object[] {
               P00BG6_A192ProfesionalesApellidoSegundo, P00BG6_A108EstadosGenericosId, P00BG6_A193ProfesionalesEmail, P00BG6_n193ProfesionalesEmail, P00BG6_A170ProfesionalesTelefono, P00BG6_A167ProfesionalesApellidoPrimero, P00BG6_A191ProfesionalesSegundoNombre, P00BG6_A166ProfesionalesPrimerNombre, P00BG6_A120ProfesionalesId
               }
               , new Object[] {
               P00BG7_A170ProfesionalesTelefono, P00BG7_A108EstadosGenericosId, P00BG7_A193ProfesionalesEmail, P00BG7_n193ProfesionalesEmail, P00BG7_A192ProfesionalesApellidoSegundo, P00BG7_A167ProfesionalesApellidoPrimero, P00BG7_A191ProfesionalesSegundoNombre, P00BG7_A166ProfesionalesPrimerNombre, P00BG7_A120ProfesionalesId
               }
               , new Object[] {
               P00BG8_A193ProfesionalesEmail, P00BG8_n193ProfesionalesEmail, P00BG8_A108EstadosGenericosId, P00BG8_A170ProfesionalesTelefono, P00BG8_A192ProfesionalesApellidoSegundo, P00BG8_A167ProfesionalesApellidoPrimero, P00BG8_A191ProfesionalesSegundoNombre, P00BG8_A166ProfesionalesPrimerNombre, P00BG8_A120ProfesionalesId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV28MaxItems ;
      private short AV27PageIndex ;
      private short AV26SkipItems ;
      private int AV49GXV1 ;
      private int GXPagingFrom2 ;
      private int GXPagingTo2 ;
      private int A108EstadosGenericosId ;
      private long AV35count ;
      private string AV11TFProfesionalesId ;
      private string AV12TFProfesionalesId_Sel ;
      private string AV13TFProfesionalesPrimerNombre ;
      private string AV14TFProfesionalesPrimerNombre_Sel ;
      private string AV15TFProfesionalesSegundoNombre ;
      private string AV16TFProfesionalesSegundoNombre_Sel ;
      private string AV17TFProfesionalesApellidoPrimero ;
      private string AV18TFProfesionalesApellidoPrimero_Sel ;
      private string AV19TFProfesionalesApellidoSegundo ;
      private string AV20TFProfesionalesApellidoSegundo_Sel ;
      private string AV21TFProfesionalesTelefono ;
      private string AV22TFProfesionalesTelefono_Sel ;
      private string lV11TFProfesionalesId ;
      private string lV13TFProfesionalesPrimerNombre ;
      private string lV15TFProfesionalesSegundoNombre ;
      private string lV17TFProfesionalesApellidoPrimero ;
      private string lV19TFProfesionalesApellidoSegundo ;
      private string lV21TFProfesionalesTelefono ;
      private string A120ProfesionalesId ;
      private string A166ProfesionalesPrimerNombre ;
      private string A191ProfesionalesSegundoNombre ;
      private string A167ProfesionalesApellidoPrimero ;
      private string A192ProfesionalesApellidoSegundo ;
      private string A170ProfesionalesTelefono ;
      private bool AV8IsAuthorized ;
      private bool GXt_boolean1 ;
      private bool returnInSub ;
      private bool n193ProfesionalesEmail ;
      private bool BRKBG3 ;
      private bool BRKBG5 ;
      private bool BRKBG7 ;
      private bool BRKBG9 ;
      private bool BRKBG11 ;
      private bool BRKBG13 ;
      private string AV44OptionsJson ;
      private string AV45OptionsDescJson ;
      private string AV46OptionIndexesJson ;
      private string AV41DDOName ;
      private string AV42SearchTxtParms ;
      private string AV43SearchTxtTo ;
      private string AV25SearchTxt ;
      private string AV47FilterFullText ;
      private string AV23TFProfesionalesEmail ;
      private string AV24TFProfesionalesEmail_Sel ;
      private string lV47FilterFullText ;
      private string lV23TFProfesionalesEmail ;
      private string A193ProfesionalesEmail ;
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
      private IDataStoreProvider pr_default ;
      private int[] P00BG2_A108EstadosGenericosId ;
      private string[] P00BG2_A193ProfesionalesEmail ;
      private bool[] P00BG2_n193ProfesionalesEmail ;
      private string[] P00BG2_A170ProfesionalesTelefono ;
      private string[] P00BG2_A192ProfesionalesApellidoSegundo ;
      private string[] P00BG2_A167ProfesionalesApellidoPrimero ;
      private string[] P00BG2_A191ProfesionalesSegundoNombre ;
      private string[] P00BG2_A166ProfesionalesPrimerNombre ;
      private string[] P00BG2_A120ProfesionalesId ;
      private string[] P00BG3_A166ProfesionalesPrimerNombre ;
      private int[] P00BG3_A108EstadosGenericosId ;
      private string[] P00BG3_A193ProfesionalesEmail ;
      private bool[] P00BG3_n193ProfesionalesEmail ;
      private string[] P00BG3_A170ProfesionalesTelefono ;
      private string[] P00BG3_A192ProfesionalesApellidoSegundo ;
      private string[] P00BG3_A167ProfesionalesApellidoPrimero ;
      private string[] P00BG3_A191ProfesionalesSegundoNombre ;
      private string[] P00BG3_A120ProfesionalesId ;
      private string[] P00BG4_A191ProfesionalesSegundoNombre ;
      private int[] P00BG4_A108EstadosGenericosId ;
      private string[] P00BG4_A193ProfesionalesEmail ;
      private bool[] P00BG4_n193ProfesionalesEmail ;
      private string[] P00BG4_A170ProfesionalesTelefono ;
      private string[] P00BG4_A192ProfesionalesApellidoSegundo ;
      private string[] P00BG4_A167ProfesionalesApellidoPrimero ;
      private string[] P00BG4_A166ProfesionalesPrimerNombre ;
      private string[] P00BG4_A120ProfesionalesId ;
      private string[] P00BG5_A167ProfesionalesApellidoPrimero ;
      private int[] P00BG5_A108EstadosGenericosId ;
      private string[] P00BG5_A193ProfesionalesEmail ;
      private bool[] P00BG5_n193ProfesionalesEmail ;
      private string[] P00BG5_A170ProfesionalesTelefono ;
      private string[] P00BG5_A192ProfesionalesApellidoSegundo ;
      private string[] P00BG5_A191ProfesionalesSegundoNombre ;
      private string[] P00BG5_A166ProfesionalesPrimerNombre ;
      private string[] P00BG5_A120ProfesionalesId ;
      private string[] P00BG6_A192ProfesionalesApellidoSegundo ;
      private int[] P00BG6_A108EstadosGenericosId ;
      private string[] P00BG6_A193ProfesionalesEmail ;
      private bool[] P00BG6_n193ProfesionalesEmail ;
      private string[] P00BG6_A170ProfesionalesTelefono ;
      private string[] P00BG6_A167ProfesionalesApellidoPrimero ;
      private string[] P00BG6_A191ProfesionalesSegundoNombre ;
      private string[] P00BG6_A166ProfesionalesPrimerNombre ;
      private string[] P00BG6_A120ProfesionalesId ;
      private string[] P00BG7_A170ProfesionalesTelefono ;
      private int[] P00BG7_A108EstadosGenericosId ;
      private string[] P00BG7_A193ProfesionalesEmail ;
      private bool[] P00BG7_n193ProfesionalesEmail ;
      private string[] P00BG7_A192ProfesionalesApellidoSegundo ;
      private string[] P00BG7_A167ProfesionalesApellidoPrimero ;
      private string[] P00BG7_A191ProfesionalesSegundoNombre ;
      private string[] P00BG7_A166ProfesionalesPrimerNombre ;
      private string[] P00BG7_A120ProfesionalesId ;
      private string[] P00BG8_A193ProfesionalesEmail ;
      private bool[] P00BG8_n193ProfesionalesEmail ;
      private int[] P00BG8_A108EstadosGenericosId ;
      private string[] P00BG8_A170ProfesionalesTelefono ;
      private string[] P00BG8_A192ProfesionalesApellidoSegundo ;
      private string[] P00BG8_A167ProfesionalesApellidoPrimero ;
      private string[] P00BG8_A191ProfesionalesSegundoNombre ;
      private string[] P00BG8_A166ProfesionalesPrimerNombre ;
      private string[] P00BG8_A120ProfesionalesId ;
      private string aP3_OptionsJson ;
      private string aP4_OptionsDescJson ;
      private string aP5_OptionIndexesJson ;
   }

   public class profesionalesfullnamepromptgetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00BG2( IGxContext context ,
                                             string AV47FilterFullText ,
                                             string AV12TFProfesionalesId_Sel ,
                                             string AV11TFProfesionalesId ,
                                             string AV14TFProfesionalesPrimerNombre_Sel ,
                                             string AV13TFProfesionalesPrimerNombre ,
                                             string AV16TFProfesionalesSegundoNombre_Sel ,
                                             string AV15TFProfesionalesSegundoNombre ,
                                             string AV18TFProfesionalesApellidoPrimero_Sel ,
                                             string AV17TFProfesionalesApellidoPrimero ,
                                             string AV20TFProfesionalesApellidoSegundo_Sel ,
                                             string AV19TFProfesionalesApellidoSegundo ,
                                             string AV22TFProfesionalesTelefono_Sel ,
                                             string AV21TFProfesionalesTelefono ,
                                             string AV24TFProfesionalesEmail_Sel ,
                                             string AV23TFProfesionalesEmail ,
                                             string A120ProfesionalesId ,
                                             string A166ProfesionalesPrimerNombre ,
                                             string A191ProfesionalesSegundoNombre ,
                                             string A167ProfesionalesApellidoPrimero ,
                                             string A192ProfesionalesApellidoSegundo ,
                                             string A170ProfesionalesTelefono ,
                                             string A193ProfesionalesEmail ,
                                             int A108EstadosGenericosId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int2 = new short[24];
         Object[] GXv_Object3 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " DISTINCT NULL AS [EstadosGenericosId], NULL AS [ProfesionalesEmail], NULL AS [ProfesionalesTelefono], NULL AS [ProfesionalesApellidoSegundo], NULL AS [ProfesionalesApellidoPrimero], NULL AS [ProfesionalesSegundoNombre], NULL AS [ProfesionalesPrimerNombre], [ProfesionalesId] FROM ( SELECT TOP(100) PERCENT [EstadosGenericosId], [ProfesionalesEmail], [ProfesionalesTelefono], [ProfesionalesApellidoSegundo], [ProfesionalesApellidoPrimero], [ProfesionalesSegundoNombre], [ProfesionalesPrimerNombre], [ProfesionalesId]";
         sFromString = " FROM [Profesionales]";
         sOrderString = "";
         string sOrderStringT;
         sOrderStringT = " ORDER BY [ProfesionalesId]";
         AddWhere(sWhereString, "([EstadosGenericosId] <> 2)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV47FilterFullText)) )
         {
            AddWhere(sWhereString, "(( UPPER([ProfesionalesId]) like '%' + UPPER(@lV47FilterFullText)) or ( UPPER([ProfesionalesPrimerNombre]) like '%' + UPPER(@lV47FilterFullText)) or ( UPPER([ProfesionalesSegundoNombre]) like '%' + UPPER(@lV47FilterFullText)) or ( UPPER([ProfesionalesApellidoPrimero]) like '%' + UPPER(@lV47FilterFullText)) or ( UPPER([ProfesionalesApellidoSegundo]) like '%' + UPPER(@lV47FilterFullText)) or ( UPPER([ProfesionalesTelefono]) like '%' + UPPER(@lV47FilterFullText)) or ( UPPER([ProfesionalesEmail]) like '%' + UPPER(@lV47FilterFullText)))");
         }
         else
         {
            GXv_int2[0] = 1;
            GXv_int2[1] = 1;
            GXv_int2[2] = 1;
            GXv_int2[3] = 1;
            GXv_int2[4] = 1;
            GXv_int2[5] = 1;
            GXv_int2[6] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV12TFProfesionalesId_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV11TFProfesionalesId)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ProfesionalesId]) like UPPER(@lV11TFProfesionalesId))");
         }
         else
         {
            GXv_int2[7] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV12TFProfesionalesId_Sel)) && ! ( StringUtil.StrCmp(AV12TFProfesionalesId_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([ProfesionalesId] = @AV12TFProfesionalesId_Sel)");
         }
         else
         {
            GXv_int2[8] = 1;
         }
         if ( StringUtil.StrCmp(AV12TFProfesionalesId_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([ProfesionalesId] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV14TFProfesionalesPrimerNombre_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV13TFProfesionalesPrimerNombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ProfesionalesPrimerNombre]) like UPPER(@lV13TFProfesionalesPrimerNombre))");
         }
         else
         {
            GXv_int2[9] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV14TFProfesionalesPrimerNombre_Sel)) && ! ( StringUtil.StrCmp(AV14TFProfesionalesPrimerNombre_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([ProfesionalesPrimerNombre] = @AV14TFProfesionalesPrimerNombre_Sel)");
         }
         else
         {
            GXv_int2[10] = 1;
         }
         if ( StringUtil.StrCmp(AV14TFProfesionalesPrimerNombre_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([ProfesionalesPrimerNombre] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV16TFProfesionalesSegundoNombre_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV15TFProfesionalesSegundoNombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ProfesionalesSegundoNombre]) like UPPER(@lV15TFProfesionalesSegundoNombre))");
         }
         else
         {
            GXv_int2[11] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV16TFProfesionalesSegundoNombre_Sel)) && ! ( StringUtil.StrCmp(AV16TFProfesionalesSegundoNombre_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([ProfesionalesSegundoNombre] = @AV16TFProfesionalesSegundoNombre_Sel)");
         }
         else
         {
            GXv_int2[12] = 1;
         }
         if ( StringUtil.StrCmp(AV16TFProfesionalesSegundoNombre_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([ProfesionalesSegundoNombre] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV18TFProfesionalesApellidoPrimero_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV17TFProfesionalesApellidoPrimero)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ProfesionalesApellidoPrimero]) like UPPER(@lV17TFProfesionalesApellidoPrimero))");
         }
         else
         {
            GXv_int2[13] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV18TFProfesionalesApellidoPrimero_Sel)) && ! ( StringUtil.StrCmp(AV18TFProfesionalesApellidoPrimero_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([ProfesionalesApellidoPrimero] = @AV18TFProfesionalesApellidoPrimero_Sel)");
         }
         else
         {
            GXv_int2[14] = 1;
         }
         if ( StringUtil.StrCmp(AV18TFProfesionalesApellidoPrimero_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([ProfesionalesApellidoPrimero] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV20TFProfesionalesApellidoSegundo_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV19TFProfesionalesApellidoSegundo)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ProfesionalesApellidoSegundo]) like UPPER(@lV19TFProfesionalesApellidoSegundo))");
         }
         else
         {
            GXv_int2[15] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV20TFProfesionalesApellidoSegundo_Sel)) && ! ( StringUtil.StrCmp(AV20TFProfesionalesApellidoSegundo_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([ProfesionalesApellidoSegundo] = @AV20TFProfesionalesApellidoSegundo_Sel)");
         }
         else
         {
            GXv_int2[16] = 1;
         }
         if ( StringUtil.StrCmp(AV20TFProfesionalesApellidoSegundo_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([ProfesionalesApellidoSegundo] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV22TFProfesionalesTelefono_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV21TFProfesionalesTelefono)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ProfesionalesTelefono]) like UPPER(@lV21TFProfesionalesTelefono))");
         }
         else
         {
            GXv_int2[17] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV22TFProfesionalesTelefono_Sel)) && ! ( StringUtil.StrCmp(AV22TFProfesionalesTelefono_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([ProfesionalesTelefono] = @AV22TFProfesionalesTelefono_Sel)");
         }
         else
         {
            GXv_int2[18] = 1;
         }
         if ( StringUtil.StrCmp(AV22TFProfesionalesTelefono_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([ProfesionalesTelefono] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV24TFProfesionalesEmail_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV23TFProfesionalesEmail)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ProfesionalesEmail]) like UPPER(@lV23TFProfesionalesEmail))");
         }
         else
         {
            GXv_int2[19] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV24TFProfesionalesEmail_Sel)) && ! ( StringUtil.StrCmp(AV24TFProfesionalesEmail_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([ProfesionalesEmail] = @AV24TFProfesionalesEmail_Sel)");
         }
         else
         {
            GXv_int2[20] = 1;
         }
         if ( StringUtil.StrCmp(AV24TFProfesionalesEmail_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "([ProfesionalesEmail] IS NULL or ([ProfesionalesEmail] = ''))");
         }
         sOrderString += " ORDER BY [ProfesionalesId]";
         sOrderStringT = " ORDER BY [ProfesionalesId]";
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + ") DistinctT" + sOrderStringT + " OFFSET " + "@GXPagingFrom2" + " ROWS FETCH NEXT CAST((SELECT CASE WHEN " + "@GXPagingTo2" + " > 0 THEN " + "@GXPagingTo2" + " ELSE 1e9 END) AS INTEGER) ROWS ONLY";
         GXv_Object3[0] = scmdbuf;
         GXv_Object3[1] = GXv_int2;
         return GXv_Object3 ;
      }

      protected Object[] conditional_P00BG3( IGxContext context ,
                                             string AV47FilterFullText ,
                                             string AV12TFProfesionalesId_Sel ,
                                             string AV11TFProfesionalesId ,
                                             string AV14TFProfesionalesPrimerNombre_Sel ,
                                             string AV13TFProfesionalesPrimerNombre ,
                                             string AV16TFProfesionalesSegundoNombre_Sel ,
                                             string AV15TFProfesionalesSegundoNombre ,
                                             string AV18TFProfesionalesApellidoPrimero_Sel ,
                                             string AV17TFProfesionalesApellidoPrimero ,
                                             string AV20TFProfesionalesApellidoSegundo_Sel ,
                                             string AV19TFProfesionalesApellidoSegundo ,
                                             string AV22TFProfesionalesTelefono_Sel ,
                                             string AV21TFProfesionalesTelefono ,
                                             string AV24TFProfesionalesEmail_Sel ,
                                             string AV23TFProfesionalesEmail ,
                                             string A120ProfesionalesId ,
                                             string A166ProfesionalesPrimerNombre ,
                                             string A191ProfesionalesSegundoNombre ,
                                             string A167ProfesionalesApellidoPrimero ,
                                             string A192ProfesionalesApellidoSegundo ,
                                             string A170ProfesionalesTelefono ,
                                             string A193ProfesionalesEmail ,
                                             int A108EstadosGenericosId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int4 = new short[21];
         Object[] GXv_Object5 = new Object[2];
         scmdbuf = "SELECT [ProfesionalesPrimerNombre], [EstadosGenericosId], [ProfesionalesEmail], [ProfesionalesTelefono], [ProfesionalesApellidoSegundo], [ProfesionalesApellidoPrimero], [ProfesionalesSegundoNombre], [ProfesionalesId] FROM [Profesionales]";
         AddWhere(sWhereString, "([EstadosGenericosId] <> 2)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV47FilterFullText)) )
         {
            AddWhere(sWhereString, "(( UPPER([ProfesionalesId]) like '%' + UPPER(@lV47FilterFullText)) or ( UPPER([ProfesionalesPrimerNombre]) like '%' + UPPER(@lV47FilterFullText)) or ( UPPER([ProfesionalesSegundoNombre]) like '%' + UPPER(@lV47FilterFullText)) or ( UPPER([ProfesionalesApellidoPrimero]) like '%' + UPPER(@lV47FilterFullText)) or ( UPPER([ProfesionalesApellidoSegundo]) like '%' + UPPER(@lV47FilterFullText)) or ( UPPER([ProfesionalesTelefono]) like '%' + UPPER(@lV47FilterFullText)) or ( UPPER([ProfesionalesEmail]) like '%' + UPPER(@lV47FilterFullText)))");
         }
         else
         {
            GXv_int4[0] = 1;
            GXv_int4[1] = 1;
            GXv_int4[2] = 1;
            GXv_int4[3] = 1;
            GXv_int4[4] = 1;
            GXv_int4[5] = 1;
            GXv_int4[6] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV12TFProfesionalesId_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV11TFProfesionalesId)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ProfesionalesId]) like UPPER(@lV11TFProfesionalesId))");
         }
         else
         {
            GXv_int4[7] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV12TFProfesionalesId_Sel)) && ! ( StringUtil.StrCmp(AV12TFProfesionalesId_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([ProfesionalesId] = @AV12TFProfesionalesId_Sel)");
         }
         else
         {
            GXv_int4[8] = 1;
         }
         if ( StringUtil.StrCmp(AV12TFProfesionalesId_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([ProfesionalesId] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV14TFProfesionalesPrimerNombre_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV13TFProfesionalesPrimerNombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ProfesionalesPrimerNombre]) like UPPER(@lV13TFProfesionalesPrimerNombre))");
         }
         else
         {
            GXv_int4[9] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV14TFProfesionalesPrimerNombre_Sel)) && ! ( StringUtil.StrCmp(AV14TFProfesionalesPrimerNombre_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([ProfesionalesPrimerNombre] = @AV14TFProfesionalesPrimerNombre_Sel)");
         }
         else
         {
            GXv_int4[10] = 1;
         }
         if ( StringUtil.StrCmp(AV14TFProfesionalesPrimerNombre_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([ProfesionalesPrimerNombre] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV16TFProfesionalesSegundoNombre_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV15TFProfesionalesSegundoNombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ProfesionalesSegundoNombre]) like UPPER(@lV15TFProfesionalesSegundoNombre))");
         }
         else
         {
            GXv_int4[11] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV16TFProfesionalesSegundoNombre_Sel)) && ! ( StringUtil.StrCmp(AV16TFProfesionalesSegundoNombre_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([ProfesionalesSegundoNombre] = @AV16TFProfesionalesSegundoNombre_Sel)");
         }
         else
         {
            GXv_int4[12] = 1;
         }
         if ( StringUtil.StrCmp(AV16TFProfesionalesSegundoNombre_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([ProfesionalesSegundoNombre] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV18TFProfesionalesApellidoPrimero_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV17TFProfesionalesApellidoPrimero)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ProfesionalesApellidoPrimero]) like UPPER(@lV17TFProfesionalesApellidoPrimero))");
         }
         else
         {
            GXv_int4[13] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV18TFProfesionalesApellidoPrimero_Sel)) && ! ( StringUtil.StrCmp(AV18TFProfesionalesApellidoPrimero_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([ProfesionalesApellidoPrimero] = @AV18TFProfesionalesApellidoPrimero_Sel)");
         }
         else
         {
            GXv_int4[14] = 1;
         }
         if ( StringUtil.StrCmp(AV18TFProfesionalesApellidoPrimero_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([ProfesionalesApellidoPrimero] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV20TFProfesionalesApellidoSegundo_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV19TFProfesionalesApellidoSegundo)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ProfesionalesApellidoSegundo]) like UPPER(@lV19TFProfesionalesApellidoSegundo))");
         }
         else
         {
            GXv_int4[15] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV20TFProfesionalesApellidoSegundo_Sel)) && ! ( StringUtil.StrCmp(AV20TFProfesionalesApellidoSegundo_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([ProfesionalesApellidoSegundo] = @AV20TFProfesionalesApellidoSegundo_Sel)");
         }
         else
         {
            GXv_int4[16] = 1;
         }
         if ( StringUtil.StrCmp(AV20TFProfesionalesApellidoSegundo_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([ProfesionalesApellidoSegundo] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV22TFProfesionalesTelefono_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV21TFProfesionalesTelefono)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ProfesionalesTelefono]) like UPPER(@lV21TFProfesionalesTelefono))");
         }
         else
         {
            GXv_int4[17] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV22TFProfesionalesTelefono_Sel)) && ! ( StringUtil.StrCmp(AV22TFProfesionalesTelefono_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([ProfesionalesTelefono] = @AV22TFProfesionalesTelefono_Sel)");
         }
         else
         {
            GXv_int4[18] = 1;
         }
         if ( StringUtil.StrCmp(AV22TFProfesionalesTelefono_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([ProfesionalesTelefono] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV24TFProfesionalesEmail_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV23TFProfesionalesEmail)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ProfesionalesEmail]) like UPPER(@lV23TFProfesionalesEmail))");
         }
         else
         {
            GXv_int4[19] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV24TFProfesionalesEmail_Sel)) && ! ( StringUtil.StrCmp(AV24TFProfesionalesEmail_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([ProfesionalesEmail] = @AV24TFProfesionalesEmail_Sel)");
         }
         else
         {
            GXv_int4[20] = 1;
         }
         if ( StringUtil.StrCmp(AV24TFProfesionalesEmail_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "([ProfesionalesEmail] IS NULL or ([ProfesionalesEmail] = ''))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY [ProfesionalesPrimerNombre]";
         GXv_Object5[0] = scmdbuf;
         GXv_Object5[1] = GXv_int4;
         return GXv_Object5 ;
      }

      protected Object[] conditional_P00BG4( IGxContext context ,
                                             string AV47FilterFullText ,
                                             string AV12TFProfesionalesId_Sel ,
                                             string AV11TFProfesionalesId ,
                                             string AV14TFProfesionalesPrimerNombre_Sel ,
                                             string AV13TFProfesionalesPrimerNombre ,
                                             string AV16TFProfesionalesSegundoNombre_Sel ,
                                             string AV15TFProfesionalesSegundoNombre ,
                                             string AV18TFProfesionalesApellidoPrimero_Sel ,
                                             string AV17TFProfesionalesApellidoPrimero ,
                                             string AV20TFProfesionalesApellidoSegundo_Sel ,
                                             string AV19TFProfesionalesApellidoSegundo ,
                                             string AV22TFProfesionalesTelefono_Sel ,
                                             string AV21TFProfesionalesTelefono ,
                                             string AV24TFProfesionalesEmail_Sel ,
                                             string AV23TFProfesionalesEmail ,
                                             string A120ProfesionalesId ,
                                             string A166ProfesionalesPrimerNombre ,
                                             string A191ProfesionalesSegundoNombre ,
                                             string A167ProfesionalesApellidoPrimero ,
                                             string A192ProfesionalesApellidoSegundo ,
                                             string A170ProfesionalesTelefono ,
                                             string A193ProfesionalesEmail ,
                                             int A108EstadosGenericosId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int6 = new short[21];
         Object[] GXv_Object7 = new Object[2];
         scmdbuf = "SELECT [ProfesionalesSegundoNombre], [EstadosGenericosId], [ProfesionalesEmail], [ProfesionalesTelefono], [ProfesionalesApellidoSegundo], [ProfesionalesApellidoPrimero], [ProfesionalesPrimerNombre], [ProfesionalesId] FROM [Profesionales]";
         AddWhere(sWhereString, "([EstadosGenericosId] <> 2)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV47FilterFullText)) )
         {
            AddWhere(sWhereString, "(( UPPER([ProfesionalesId]) like '%' + UPPER(@lV47FilterFullText)) or ( UPPER([ProfesionalesPrimerNombre]) like '%' + UPPER(@lV47FilterFullText)) or ( UPPER([ProfesionalesSegundoNombre]) like '%' + UPPER(@lV47FilterFullText)) or ( UPPER([ProfesionalesApellidoPrimero]) like '%' + UPPER(@lV47FilterFullText)) or ( UPPER([ProfesionalesApellidoSegundo]) like '%' + UPPER(@lV47FilterFullText)) or ( UPPER([ProfesionalesTelefono]) like '%' + UPPER(@lV47FilterFullText)) or ( UPPER([ProfesionalesEmail]) like '%' + UPPER(@lV47FilterFullText)))");
         }
         else
         {
            GXv_int6[0] = 1;
            GXv_int6[1] = 1;
            GXv_int6[2] = 1;
            GXv_int6[3] = 1;
            GXv_int6[4] = 1;
            GXv_int6[5] = 1;
            GXv_int6[6] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV12TFProfesionalesId_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV11TFProfesionalesId)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ProfesionalesId]) like UPPER(@lV11TFProfesionalesId))");
         }
         else
         {
            GXv_int6[7] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV12TFProfesionalesId_Sel)) && ! ( StringUtil.StrCmp(AV12TFProfesionalesId_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([ProfesionalesId] = @AV12TFProfesionalesId_Sel)");
         }
         else
         {
            GXv_int6[8] = 1;
         }
         if ( StringUtil.StrCmp(AV12TFProfesionalesId_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([ProfesionalesId] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV14TFProfesionalesPrimerNombre_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV13TFProfesionalesPrimerNombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ProfesionalesPrimerNombre]) like UPPER(@lV13TFProfesionalesPrimerNombre))");
         }
         else
         {
            GXv_int6[9] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV14TFProfesionalesPrimerNombre_Sel)) && ! ( StringUtil.StrCmp(AV14TFProfesionalesPrimerNombre_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([ProfesionalesPrimerNombre] = @AV14TFProfesionalesPrimerNombre_Sel)");
         }
         else
         {
            GXv_int6[10] = 1;
         }
         if ( StringUtil.StrCmp(AV14TFProfesionalesPrimerNombre_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([ProfesionalesPrimerNombre] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV16TFProfesionalesSegundoNombre_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV15TFProfesionalesSegundoNombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ProfesionalesSegundoNombre]) like UPPER(@lV15TFProfesionalesSegundoNombre))");
         }
         else
         {
            GXv_int6[11] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV16TFProfesionalesSegundoNombre_Sel)) && ! ( StringUtil.StrCmp(AV16TFProfesionalesSegundoNombre_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([ProfesionalesSegundoNombre] = @AV16TFProfesionalesSegundoNombre_Sel)");
         }
         else
         {
            GXv_int6[12] = 1;
         }
         if ( StringUtil.StrCmp(AV16TFProfesionalesSegundoNombre_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([ProfesionalesSegundoNombre] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV18TFProfesionalesApellidoPrimero_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV17TFProfesionalesApellidoPrimero)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ProfesionalesApellidoPrimero]) like UPPER(@lV17TFProfesionalesApellidoPrimero))");
         }
         else
         {
            GXv_int6[13] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV18TFProfesionalesApellidoPrimero_Sel)) && ! ( StringUtil.StrCmp(AV18TFProfesionalesApellidoPrimero_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([ProfesionalesApellidoPrimero] = @AV18TFProfesionalesApellidoPrimero_Sel)");
         }
         else
         {
            GXv_int6[14] = 1;
         }
         if ( StringUtil.StrCmp(AV18TFProfesionalesApellidoPrimero_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([ProfesionalesApellidoPrimero] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV20TFProfesionalesApellidoSegundo_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV19TFProfesionalesApellidoSegundo)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ProfesionalesApellidoSegundo]) like UPPER(@lV19TFProfesionalesApellidoSegundo))");
         }
         else
         {
            GXv_int6[15] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV20TFProfesionalesApellidoSegundo_Sel)) && ! ( StringUtil.StrCmp(AV20TFProfesionalesApellidoSegundo_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([ProfesionalesApellidoSegundo] = @AV20TFProfesionalesApellidoSegundo_Sel)");
         }
         else
         {
            GXv_int6[16] = 1;
         }
         if ( StringUtil.StrCmp(AV20TFProfesionalesApellidoSegundo_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([ProfesionalesApellidoSegundo] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV22TFProfesionalesTelefono_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV21TFProfesionalesTelefono)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ProfesionalesTelefono]) like UPPER(@lV21TFProfesionalesTelefono))");
         }
         else
         {
            GXv_int6[17] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV22TFProfesionalesTelefono_Sel)) && ! ( StringUtil.StrCmp(AV22TFProfesionalesTelefono_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([ProfesionalesTelefono] = @AV22TFProfesionalesTelefono_Sel)");
         }
         else
         {
            GXv_int6[18] = 1;
         }
         if ( StringUtil.StrCmp(AV22TFProfesionalesTelefono_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([ProfesionalesTelefono] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV24TFProfesionalesEmail_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV23TFProfesionalesEmail)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ProfesionalesEmail]) like UPPER(@lV23TFProfesionalesEmail))");
         }
         else
         {
            GXv_int6[19] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV24TFProfesionalesEmail_Sel)) && ! ( StringUtil.StrCmp(AV24TFProfesionalesEmail_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([ProfesionalesEmail] = @AV24TFProfesionalesEmail_Sel)");
         }
         else
         {
            GXv_int6[20] = 1;
         }
         if ( StringUtil.StrCmp(AV24TFProfesionalesEmail_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "([ProfesionalesEmail] IS NULL or ([ProfesionalesEmail] = ''))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY [ProfesionalesSegundoNombre]";
         GXv_Object7[0] = scmdbuf;
         GXv_Object7[1] = GXv_int6;
         return GXv_Object7 ;
      }

      protected Object[] conditional_P00BG5( IGxContext context ,
                                             string AV47FilterFullText ,
                                             string AV12TFProfesionalesId_Sel ,
                                             string AV11TFProfesionalesId ,
                                             string AV14TFProfesionalesPrimerNombre_Sel ,
                                             string AV13TFProfesionalesPrimerNombre ,
                                             string AV16TFProfesionalesSegundoNombre_Sel ,
                                             string AV15TFProfesionalesSegundoNombre ,
                                             string AV18TFProfesionalesApellidoPrimero_Sel ,
                                             string AV17TFProfesionalesApellidoPrimero ,
                                             string AV20TFProfesionalesApellidoSegundo_Sel ,
                                             string AV19TFProfesionalesApellidoSegundo ,
                                             string AV22TFProfesionalesTelefono_Sel ,
                                             string AV21TFProfesionalesTelefono ,
                                             string AV24TFProfesionalesEmail_Sel ,
                                             string AV23TFProfesionalesEmail ,
                                             string A120ProfesionalesId ,
                                             string A166ProfesionalesPrimerNombre ,
                                             string A191ProfesionalesSegundoNombre ,
                                             string A167ProfesionalesApellidoPrimero ,
                                             string A192ProfesionalesApellidoSegundo ,
                                             string A170ProfesionalesTelefono ,
                                             string A193ProfesionalesEmail ,
                                             int A108EstadosGenericosId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int8 = new short[21];
         Object[] GXv_Object9 = new Object[2];
         scmdbuf = "SELECT [ProfesionalesApellidoPrimero], [EstadosGenericosId], [ProfesionalesEmail], [ProfesionalesTelefono], [ProfesionalesApellidoSegundo], [ProfesionalesSegundoNombre], [ProfesionalesPrimerNombre], [ProfesionalesId] FROM [Profesionales]";
         AddWhere(sWhereString, "([EstadosGenericosId] <> 2)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV47FilterFullText)) )
         {
            AddWhere(sWhereString, "(( UPPER([ProfesionalesId]) like '%' + UPPER(@lV47FilterFullText)) or ( UPPER([ProfesionalesPrimerNombre]) like '%' + UPPER(@lV47FilterFullText)) or ( UPPER([ProfesionalesSegundoNombre]) like '%' + UPPER(@lV47FilterFullText)) or ( UPPER([ProfesionalesApellidoPrimero]) like '%' + UPPER(@lV47FilterFullText)) or ( UPPER([ProfesionalesApellidoSegundo]) like '%' + UPPER(@lV47FilterFullText)) or ( UPPER([ProfesionalesTelefono]) like '%' + UPPER(@lV47FilterFullText)) or ( UPPER([ProfesionalesEmail]) like '%' + UPPER(@lV47FilterFullText)))");
         }
         else
         {
            GXv_int8[0] = 1;
            GXv_int8[1] = 1;
            GXv_int8[2] = 1;
            GXv_int8[3] = 1;
            GXv_int8[4] = 1;
            GXv_int8[5] = 1;
            GXv_int8[6] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV12TFProfesionalesId_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV11TFProfesionalesId)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ProfesionalesId]) like UPPER(@lV11TFProfesionalesId))");
         }
         else
         {
            GXv_int8[7] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV12TFProfesionalesId_Sel)) && ! ( StringUtil.StrCmp(AV12TFProfesionalesId_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([ProfesionalesId] = @AV12TFProfesionalesId_Sel)");
         }
         else
         {
            GXv_int8[8] = 1;
         }
         if ( StringUtil.StrCmp(AV12TFProfesionalesId_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([ProfesionalesId] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV14TFProfesionalesPrimerNombre_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV13TFProfesionalesPrimerNombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ProfesionalesPrimerNombre]) like UPPER(@lV13TFProfesionalesPrimerNombre))");
         }
         else
         {
            GXv_int8[9] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV14TFProfesionalesPrimerNombre_Sel)) && ! ( StringUtil.StrCmp(AV14TFProfesionalesPrimerNombre_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([ProfesionalesPrimerNombre] = @AV14TFProfesionalesPrimerNombre_Sel)");
         }
         else
         {
            GXv_int8[10] = 1;
         }
         if ( StringUtil.StrCmp(AV14TFProfesionalesPrimerNombre_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([ProfesionalesPrimerNombre] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV16TFProfesionalesSegundoNombre_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV15TFProfesionalesSegundoNombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ProfesionalesSegundoNombre]) like UPPER(@lV15TFProfesionalesSegundoNombre))");
         }
         else
         {
            GXv_int8[11] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV16TFProfesionalesSegundoNombre_Sel)) && ! ( StringUtil.StrCmp(AV16TFProfesionalesSegundoNombre_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([ProfesionalesSegundoNombre] = @AV16TFProfesionalesSegundoNombre_Sel)");
         }
         else
         {
            GXv_int8[12] = 1;
         }
         if ( StringUtil.StrCmp(AV16TFProfesionalesSegundoNombre_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([ProfesionalesSegundoNombre] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV18TFProfesionalesApellidoPrimero_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV17TFProfesionalesApellidoPrimero)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ProfesionalesApellidoPrimero]) like UPPER(@lV17TFProfesionalesApellidoPrimero))");
         }
         else
         {
            GXv_int8[13] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV18TFProfesionalesApellidoPrimero_Sel)) && ! ( StringUtil.StrCmp(AV18TFProfesionalesApellidoPrimero_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([ProfesionalesApellidoPrimero] = @AV18TFProfesionalesApellidoPrimero_Sel)");
         }
         else
         {
            GXv_int8[14] = 1;
         }
         if ( StringUtil.StrCmp(AV18TFProfesionalesApellidoPrimero_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([ProfesionalesApellidoPrimero] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV20TFProfesionalesApellidoSegundo_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV19TFProfesionalesApellidoSegundo)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ProfesionalesApellidoSegundo]) like UPPER(@lV19TFProfesionalesApellidoSegundo))");
         }
         else
         {
            GXv_int8[15] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV20TFProfesionalesApellidoSegundo_Sel)) && ! ( StringUtil.StrCmp(AV20TFProfesionalesApellidoSegundo_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([ProfesionalesApellidoSegundo] = @AV20TFProfesionalesApellidoSegundo_Sel)");
         }
         else
         {
            GXv_int8[16] = 1;
         }
         if ( StringUtil.StrCmp(AV20TFProfesionalesApellidoSegundo_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([ProfesionalesApellidoSegundo] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV22TFProfesionalesTelefono_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV21TFProfesionalesTelefono)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ProfesionalesTelefono]) like UPPER(@lV21TFProfesionalesTelefono))");
         }
         else
         {
            GXv_int8[17] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV22TFProfesionalesTelefono_Sel)) && ! ( StringUtil.StrCmp(AV22TFProfesionalesTelefono_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([ProfesionalesTelefono] = @AV22TFProfesionalesTelefono_Sel)");
         }
         else
         {
            GXv_int8[18] = 1;
         }
         if ( StringUtil.StrCmp(AV22TFProfesionalesTelefono_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([ProfesionalesTelefono] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV24TFProfesionalesEmail_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV23TFProfesionalesEmail)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ProfesionalesEmail]) like UPPER(@lV23TFProfesionalesEmail))");
         }
         else
         {
            GXv_int8[19] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV24TFProfesionalesEmail_Sel)) && ! ( StringUtil.StrCmp(AV24TFProfesionalesEmail_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([ProfesionalesEmail] = @AV24TFProfesionalesEmail_Sel)");
         }
         else
         {
            GXv_int8[20] = 1;
         }
         if ( StringUtil.StrCmp(AV24TFProfesionalesEmail_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "([ProfesionalesEmail] IS NULL or ([ProfesionalesEmail] = ''))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY [ProfesionalesApellidoPrimero]";
         GXv_Object9[0] = scmdbuf;
         GXv_Object9[1] = GXv_int8;
         return GXv_Object9 ;
      }

      protected Object[] conditional_P00BG6( IGxContext context ,
                                             string AV47FilterFullText ,
                                             string AV12TFProfesionalesId_Sel ,
                                             string AV11TFProfesionalesId ,
                                             string AV14TFProfesionalesPrimerNombre_Sel ,
                                             string AV13TFProfesionalesPrimerNombre ,
                                             string AV16TFProfesionalesSegundoNombre_Sel ,
                                             string AV15TFProfesionalesSegundoNombre ,
                                             string AV18TFProfesionalesApellidoPrimero_Sel ,
                                             string AV17TFProfesionalesApellidoPrimero ,
                                             string AV20TFProfesionalesApellidoSegundo_Sel ,
                                             string AV19TFProfesionalesApellidoSegundo ,
                                             string AV22TFProfesionalesTelefono_Sel ,
                                             string AV21TFProfesionalesTelefono ,
                                             string AV24TFProfesionalesEmail_Sel ,
                                             string AV23TFProfesionalesEmail ,
                                             string A120ProfesionalesId ,
                                             string A166ProfesionalesPrimerNombre ,
                                             string A191ProfesionalesSegundoNombre ,
                                             string A167ProfesionalesApellidoPrimero ,
                                             string A192ProfesionalesApellidoSegundo ,
                                             string A170ProfesionalesTelefono ,
                                             string A193ProfesionalesEmail ,
                                             int A108EstadosGenericosId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int10 = new short[21];
         Object[] GXv_Object11 = new Object[2];
         scmdbuf = "SELECT [ProfesionalesApellidoSegundo], [EstadosGenericosId], [ProfesionalesEmail], [ProfesionalesTelefono], [ProfesionalesApellidoPrimero], [ProfesionalesSegundoNombre], [ProfesionalesPrimerNombre], [ProfesionalesId] FROM [Profesionales]";
         AddWhere(sWhereString, "([EstadosGenericosId] <> 2)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV47FilterFullText)) )
         {
            AddWhere(sWhereString, "(( UPPER([ProfesionalesId]) like '%' + UPPER(@lV47FilterFullText)) or ( UPPER([ProfesionalesPrimerNombre]) like '%' + UPPER(@lV47FilterFullText)) or ( UPPER([ProfesionalesSegundoNombre]) like '%' + UPPER(@lV47FilterFullText)) or ( UPPER([ProfesionalesApellidoPrimero]) like '%' + UPPER(@lV47FilterFullText)) or ( UPPER([ProfesionalesApellidoSegundo]) like '%' + UPPER(@lV47FilterFullText)) or ( UPPER([ProfesionalesTelefono]) like '%' + UPPER(@lV47FilterFullText)) or ( UPPER([ProfesionalesEmail]) like '%' + UPPER(@lV47FilterFullText)))");
         }
         else
         {
            GXv_int10[0] = 1;
            GXv_int10[1] = 1;
            GXv_int10[2] = 1;
            GXv_int10[3] = 1;
            GXv_int10[4] = 1;
            GXv_int10[5] = 1;
            GXv_int10[6] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV12TFProfesionalesId_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV11TFProfesionalesId)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ProfesionalesId]) like UPPER(@lV11TFProfesionalesId))");
         }
         else
         {
            GXv_int10[7] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV12TFProfesionalesId_Sel)) && ! ( StringUtil.StrCmp(AV12TFProfesionalesId_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([ProfesionalesId] = @AV12TFProfesionalesId_Sel)");
         }
         else
         {
            GXv_int10[8] = 1;
         }
         if ( StringUtil.StrCmp(AV12TFProfesionalesId_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([ProfesionalesId] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV14TFProfesionalesPrimerNombre_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV13TFProfesionalesPrimerNombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ProfesionalesPrimerNombre]) like UPPER(@lV13TFProfesionalesPrimerNombre))");
         }
         else
         {
            GXv_int10[9] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV14TFProfesionalesPrimerNombre_Sel)) && ! ( StringUtil.StrCmp(AV14TFProfesionalesPrimerNombre_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([ProfesionalesPrimerNombre] = @AV14TFProfesionalesPrimerNombre_Sel)");
         }
         else
         {
            GXv_int10[10] = 1;
         }
         if ( StringUtil.StrCmp(AV14TFProfesionalesPrimerNombre_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([ProfesionalesPrimerNombre] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV16TFProfesionalesSegundoNombre_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV15TFProfesionalesSegundoNombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ProfesionalesSegundoNombre]) like UPPER(@lV15TFProfesionalesSegundoNombre))");
         }
         else
         {
            GXv_int10[11] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV16TFProfesionalesSegundoNombre_Sel)) && ! ( StringUtil.StrCmp(AV16TFProfesionalesSegundoNombre_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([ProfesionalesSegundoNombre] = @AV16TFProfesionalesSegundoNombre_Sel)");
         }
         else
         {
            GXv_int10[12] = 1;
         }
         if ( StringUtil.StrCmp(AV16TFProfesionalesSegundoNombre_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([ProfesionalesSegundoNombre] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV18TFProfesionalesApellidoPrimero_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV17TFProfesionalesApellidoPrimero)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ProfesionalesApellidoPrimero]) like UPPER(@lV17TFProfesionalesApellidoPrimero))");
         }
         else
         {
            GXv_int10[13] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV18TFProfesionalesApellidoPrimero_Sel)) && ! ( StringUtil.StrCmp(AV18TFProfesionalesApellidoPrimero_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([ProfesionalesApellidoPrimero] = @AV18TFProfesionalesApellidoPrimero_Sel)");
         }
         else
         {
            GXv_int10[14] = 1;
         }
         if ( StringUtil.StrCmp(AV18TFProfesionalesApellidoPrimero_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([ProfesionalesApellidoPrimero] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV20TFProfesionalesApellidoSegundo_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV19TFProfesionalesApellidoSegundo)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ProfesionalesApellidoSegundo]) like UPPER(@lV19TFProfesionalesApellidoSegundo))");
         }
         else
         {
            GXv_int10[15] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV20TFProfesionalesApellidoSegundo_Sel)) && ! ( StringUtil.StrCmp(AV20TFProfesionalesApellidoSegundo_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([ProfesionalesApellidoSegundo] = @AV20TFProfesionalesApellidoSegundo_Sel)");
         }
         else
         {
            GXv_int10[16] = 1;
         }
         if ( StringUtil.StrCmp(AV20TFProfesionalesApellidoSegundo_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([ProfesionalesApellidoSegundo] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV22TFProfesionalesTelefono_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV21TFProfesionalesTelefono)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ProfesionalesTelefono]) like UPPER(@lV21TFProfesionalesTelefono))");
         }
         else
         {
            GXv_int10[17] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV22TFProfesionalesTelefono_Sel)) && ! ( StringUtil.StrCmp(AV22TFProfesionalesTelefono_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([ProfesionalesTelefono] = @AV22TFProfesionalesTelefono_Sel)");
         }
         else
         {
            GXv_int10[18] = 1;
         }
         if ( StringUtil.StrCmp(AV22TFProfesionalesTelefono_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([ProfesionalesTelefono] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV24TFProfesionalesEmail_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV23TFProfesionalesEmail)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ProfesionalesEmail]) like UPPER(@lV23TFProfesionalesEmail))");
         }
         else
         {
            GXv_int10[19] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV24TFProfesionalesEmail_Sel)) && ! ( StringUtil.StrCmp(AV24TFProfesionalesEmail_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([ProfesionalesEmail] = @AV24TFProfesionalesEmail_Sel)");
         }
         else
         {
            GXv_int10[20] = 1;
         }
         if ( StringUtil.StrCmp(AV24TFProfesionalesEmail_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "([ProfesionalesEmail] IS NULL or ([ProfesionalesEmail] = ''))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY [ProfesionalesApellidoSegundo]";
         GXv_Object11[0] = scmdbuf;
         GXv_Object11[1] = GXv_int10;
         return GXv_Object11 ;
      }

      protected Object[] conditional_P00BG7( IGxContext context ,
                                             string AV47FilterFullText ,
                                             string AV12TFProfesionalesId_Sel ,
                                             string AV11TFProfesionalesId ,
                                             string AV14TFProfesionalesPrimerNombre_Sel ,
                                             string AV13TFProfesionalesPrimerNombre ,
                                             string AV16TFProfesionalesSegundoNombre_Sel ,
                                             string AV15TFProfesionalesSegundoNombre ,
                                             string AV18TFProfesionalesApellidoPrimero_Sel ,
                                             string AV17TFProfesionalesApellidoPrimero ,
                                             string AV20TFProfesionalesApellidoSegundo_Sel ,
                                             string AV19TFProfesionalesApellidoSegundo ,
                                             string AV22TFProfesionalesTelefono_Sel ,
                                             string AV21TFProfesionalesTelefono ,
                                             string AV24TFProfesionalesEmail_Sel ,
                                             string AV23TFProfesionalesEmail ,
                                             string A120ProfesionalesId ,
                                             string A166ProfesionalesPrimerNombre ,
                                             string A191ProfesionalesSegundoNombre ,
                                             string A167ProfesionalesApellidoPrimero ,
                                             string A192ProfesionalesApellidoSegundo ,
                                             string A170ProfesionalesTelefono ,
                                             string A193ProfesionalesEmail ,
                                             int A108EstadosGenericosId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int12 = new short[21];
         Object[] GXv_Object13 = new Object[2];
         scmdbuf = "SELECT [ProfesionalesTelefono], [EstadosGenericosId], [ProfesionalesEmail], [ProfesionalesApellidoSegundo], [ProfesionalesApellidoPrimero], [ProfesionalesSegundoNombre], [ProfesionalesPrimerNombre], [ProfesionalesId] FROM [Profesionales]";
         AddWhere(sWhereString, "([EstadosGenericosId] <> 2)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV47FilterFullText)) )
         {
            AddWhere(sWhereString, "(( UPPER([ProfesionalesId]) like '%' + UPPER(@lV47FilterFullText)) or ( UPPER([ProfesionalesPrimerNombre]) like '%' + UPPER(@lV47FilterFullText)) or ( UPPER([ProfesionalesSegundoNombre]) like '%' + UPPER(@lV47FilterFullText)) or ( UPPER([ProfesionalesApellidoPrimero]) like '%' + UPPER(@lV47FilterFullText)) or ( UPPER([ProfesionalesApellidoSegundo]) like '%' + UPPER(@lV47FilterFullText)) or ( UPPER([ProfesionalesTelefono]) like '%' + UPPER(@lV47FilterFullText)) or ( UPPER([ProfesionalesEmail]) like '%' + UPPER(@lV47FilterFullText)))");
         }
         else
         {
            GXv_int12[0] = 1;
            GXv_int12[1] = 1;
            GXv_int12[2] = 1;
            GXv_int12[3] = 1;
            GXv_int12[4] = 1;
            GXv_int12[5] = 1;
            GXv_int12[6] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV12TFProfesionalesId_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV11TFProfesionalesId)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ProfesionalesId]) like UPPER(@lV11TFProfesionalesId))");
         }
         else
         {
            GXv_int12[7] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV12TFProfesionalesId_Sel)) && ! ( StringUtil.StrCmp(AV12TFProfesionalesId_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([ProfesionalesId] = @AV12TFProfesionalesId_Sel)");
         }
         else
         {
            GXv_int12[8] = 1;
         }
         if ( StringUtil.StrCmp(AV12TFProfesionalesId_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([ProfesionalesId] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV14TFProfesionalesPrimerNombre_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV13TFProfesionalesPrimerNombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ProfesionalesPrimerNombre]) like UPPER(@lV13TFProfesionalesPrimerNombre))");
         }
         else
         {
            GXv_int12[9] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV14TFProfesionalesPrimerNombre_Sel)) && ! ( StringUtil.StrCmp(AV14TFProfesionalesPrimerNombre_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([ProfesionalesPrimerNombre] = @AV14TFProfesionalesPrimerNombre_Sel)");
         }
         else
         {
            GXv_int12[10] = 1;
         }
         if ( StringUtil.StrCmp(AV14TFProfesionalesPrimerNombre_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([ProfesionalesPrimerNombre] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV16TFProfesionalesSegundoNombre_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV15TFProfesionalesSegundoNombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ProfesionalesSegundoNombre]) like UPPER(@lV15TFProfesionalesSegundoNombre))");
         }
         else
         {
            GXv_int12[11] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV16TFProfesionalesSegundoNombre_Sel)) && ! ( StringUtil.StrCmp(AV16TFProfesionalesSegundoNombre_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([ProfesionalesSegundoNombre] = @AV16TFProfesionalesSegundoNombre_Sel)");
         }
         else
         {
            GXv_int12[12] = 1;
         }
         if ( StringUtil.StrCmp(AV16TFProfesionalesSegundoNombre_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([ProfesionalesSegundoNombre] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV18TFProfesionalesApellidoPrimero_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV17TFProfesionalesApellidoPrimero)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ProfesionalesApellidoPrimero]) like UPPER(@lV17TFProfesionalesApellidoPrimero))");
         }
         else
         {
            GXv_int12[13] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV18TFProfesionalesApellidoPrimero_Sel)) && ! ( StringUtil.StrCmp(AV18TFProfesionalesApellidoPrimero_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([ProfesionalesApellidoPrimero] = @AV18TFProfesionalesApellidoPrimero_Sel)");
         }
         else
         {
            GXv_int12[14] = 1;
         }
         if ( StringUtil.StrCmp(AV18TFProfesionalesApellidoPrimero_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([ProfesionalesApellidoPrimero] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV20TFProfesionalesApellidoSegundo_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV19TFProfesionalesApellidoSegundo)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ProfesionalesApellidoSegundo]) like UPPER(@lV19TFProfesionalesApellidoSegundo))");
         }
         else
         {
            GXv_int12[15] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV20TFProfesionalesApellidoSegundo_Sel)) && ! ( StringUtil.StrCmp(AV20TFProfesionalesApellidoSegundo_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([ProfesionalesApellidoSegundo] = @AV20TFProfesionalesApellidoSegundo_Sel)");
         }
         else
         {
            GXv_int12[16] = 1;
         }
         if ( StringUtil.StrCmp(AV20TFProfesionalesApellidoSegundo_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([ProfesionalesApellidoSegundo] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV22TFProfesionalesTelefono_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV21TFProfesionalesTelefono)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ProfesionalesTelefono]) like UPPER(@lV21TFProfesionalesTelefono))");
         }
         else
         {
            GXv_int12[17] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV22TFProfesionalesTelefono_Sel)) && ! ( StringUtil.StrCmp(AV22TFProfesionalesTelefono_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([ProfesionalesTelefono] = @AV22TFProfesionalesTelefono_Sel)");
         }
         else
         {
            GXv_int12[18] = 1;
         }
         if ( StringUtil.StrCmp(AV22TFProfesionalesTelefono_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([ProfesionalesTelefono] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV24TFProfesionalesEmail_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV23TFProfesionalesEmail)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ProfesionalesEmail]) like UPPER(@lV23TFProfesionalesEmail))");
         }
         else
         {
            GXv_int12[19] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV24TFProfesionalesEmail_Sel)) && ! ( StringUtil.StrCmp(AV24TFProfesionalesEmail_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([ProfesionalesEmail] = @AV24TFProfesionalesEmail_Sel)");
         }
         else
         {
            GXv_int12[20] = 1;
         }
         if ( StringUtil.StrCmp(AV24TFProfesionalesEmail_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "([ProfesionalesEmail] IS NULL or ([ProfesionalesEmail] = ''))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY [ProfesionalesTelefono]";
         GXv_Object13[0] = scmdbuf;
         GXv_Object13[1] = GXv_int12;
         return GXv_Object13 ;
      }

      protected Object[] conditional_P00BG8( IGxContext context ,
                                             string AV47FilterFullText ,
                                             string AV12TFProfesionalesId_Sel ,
                                             string AV11TFProfesionalesId ,
                                             string AV14TFProfesionalesPrimerNombre_Sel ,
                                             string AV13TFProfesionalesPrimerNombre ,
                                             string AV16TFProfesionalesSegundoNombre_Sel ,
                                             string AV15TFProfesionalesSegundoNombre ,
                                             string AV18TFProfesionalesApellidoPrimero_Sel ,
                                             string AV17TFProfesionalesApellidoPrimero ,
                                             string AV20TFProfesionalesApellidoSegundo_Sel ,
                                             string AV19TFProfesionalesApellidoSegundo ,
                                             string AV22TFProfesionalesTelefono_Sel ,
                                             string AV21TFProfesionalesTelefono ,
                                             string AV24TFProfesionalesEmail_Sel ,
                                             string AV23TFProfesionalesEmail ,
                                             string A120ProfesionalesId ,
                                             string A166ProfesionalesPrimerNombre ,
                                             string A191ProfesionalesSegundoNombre ,
                                             string A167ProfesionalesApellidoPrimero ,
                                             string A192ProfesionalesApellidoSegundo ,
                                             string A170ProfesionalesTelefono ,
                                             string A193ProfesionalesEmail ,
                                             int A108EstadosGenericosId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int14 = new short[21];
         Object[] GXv_Object15 = new Object[2];
         scmdbuf = "SELECT [ProfesionalesEmail], [EstadosGenericosId], [ProfesionalesTelefono], [ProfesionalesApellidoSegundo], [ProfesionalesApellidoPrimero], [ProfesionalesSegundoNombre], [ProfesionalesPrimerNombre], [ProfesionalesId] FROM [Profesionales]";
         AddWhere(sWhereString, "([EstadosGenericosId] <> 2)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV47FilterFullText)) )
         {
            AddWhere(sWhereString, "(( UPPER([ProfesionalesId]) like '%' + UPPER(@lV47FilterFullText)) or ( UPPER([ProfesionalesPrimerNombre]) like '%' + UPPER(@lV47FilterFullText)) or ( UPPER([ProfesionalesSegundoNombre]) like '%' + UPPER(@lV47FilterFullText)) or ( UPPER([ProfesionalesApellidoPrimero]) like '%' + UPPER(@lV47FilterFullText)) or ( UPPER([ProfesionalesApellidoSegundo]) like '%' + UPPER(@lV47FilterFullText)) or ( UPPER([ProfesionalesTelefono]) like '%' + UPPER(@lV47FilterFullText)) or ( UPPER([ProfesionalesEmail]) like '%' + UPPER(@lV47FilterFullText)))");
         }
         else
         {
            GXv_int14[0] = 1;
            GXv_int14[1] = 1;
            GXv_int14[2] = 1;
            GXv_int14[3] = 1;
            GXv_int14[4] = 1;
            GXv_int14[5] = 1;
            GXv_int14[6] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV12TFProfesionalesId_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV11TFProfesionalesId)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ProfesionalesId]) like UPPER(@lV11TFProfesionalesId))");
         }
         else
         {
            GXv_int14[7] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV12TFProfesionalesId_Sel)) && ! ( StringUtil.StrCmp(AV12TFProfesionalesId_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([ProfesionalesId] = @AV12TFProfesionalesId_Sel)");
         }
         else
         {
            GXv_int14[8] = 1;
         }
         if ( StringUtil.StrCmp(AV12TFProfesionalesId_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([ProfesionalesId] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV14TFProfesionalesPrimerNombre_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV13TFProfesionalesPrimerNombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ProfesionalesPrimerNombre]) like UPPER(@lV13TFProfesionalesPrimerNombre))");
         }
         else
         {
            GXv_int14[9] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV14TFProfesionalesPrimerNombre_Sel)) && ! ( StringUtil.StrCmp(AV14TFProfesionalesPrimerNombre_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([ProfesionalesPrimerNombre] = @AV14TFProfesionalesPrimerNombre_Sel)");
         }
         else
         {
            GXv_int14[10] = 1;
         }
         if ( StringUtil.StrCmp(AV14TFProfesionalesPrimerNombre_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([ProfesionalesPrimerNombre] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV16TFProfesionalesSegundoNombre_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV15TFProfesionalesSegundoNombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ProfesionalesSegundoNombre]) like UPPER(@lV15TFProfesionalesSegundoNombre))");
         }
         else
         {
            GXv_int14[11] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV16TFProfesionalesSegundoNombre_Sel)) && ! ( StringUtil.StrCmp(AV16TFProfesionalesSegundoNombre_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([ProfesionalesSegundoNombre] = @AV16TFProfesionalesSegundoNombre_Sel)");
         }
         else
         {
            GXv_int14[12] = 1;
         }
         if ( StringUtil.StrCmp(AV16TFProfesionalesSegundoNombre_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([ProfesionalesSegundoNombre] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV18TFProfesionalesApellidoPrimero_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV17TFProfesionalesApellidoPrimero)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ProfesionalesApellidoPrimero]) like UPPER(@lV17TFProfesionalesApellidoPrimero))");
         }
         else
         {
            GXv_int14[13] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV18TFProfesionalesApellidoPrimero_Sel)) && ! ( StringUtil.StrCmp(AV18TFProfesionalesApellidoPrimero_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([ProfesionalesApellidoPrimero] = @AV18TFProfesionalesApellidoPrimero_Sel)");
         }
         else
         {
            GXv_int14[14] = 1;
         }
         if ( StringUtil.StrCmp(AV18TFProfesionalesApellidoPrimero_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([ProfesionalesApellidoPrimero] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV20TFProfesionalesApellidoSegundo_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV19TFProfesionalesApellidoSegundo)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ProfesionalesApellidoSegundo]) like UPPER(@lV19TFProfesionalesApellidoSegundo))");
         }
         else
         {
            GXv_int14[15] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV20TFProfesionalesApellidoSegundo_Sel)) && ! ( StringUtil.StrCmp(AV20TFProfesionalesApellidoSegundo_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([ProfesionalesApellidoSegundo] = @AV20TFProfesionalesApellidoSegundo_Sel)");
         }
         else
         {
            GXv_int14[16] = 1;
         }
         if ( StringUtil.StrCmp(AV20TFProfesionalesApellidoSegundo_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([ProfesionalesApellidoSegundo] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV22TFProfesionalesTelefono_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV21TFProfesionalesTelefono)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ProfesionalesTelefono]) like UPPER(@lV21TFProfesionalesTelefono))");
         }
         else
         {
            GXv_int14[17] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV22TFProfesionalesTelefono_Sel)) && ! ( StringUtil.StrCmp(AV22TFProfesionalesTelefono_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([ProfesionalesTelefono] = @AV22TFProfesionalesTelefono_Sel)");
         }
         else
         {
            GXv_int14[18] = 1;
         }
         if ( StringUtil.StrCmp(AV22TFProfesionalesTelefono_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([ProfesionalesTelefono] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV24TFProfesionalesEmail_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV23TFProfesionalesEmail)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ProfesionalesEmail]) like UPPER(@lV23TFProfesionalesEmail))");
         }
         else
         {
            GXv_int14[19] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV24TFProfesionalesEmail_Sel)) && ! ( StringUtil.StrCmp(AV24TFProfesionalesEmail_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([ProfesionalesEmail] = @AV24TFProfesionalesEmail_Sel)");
         }
         else
         {
            GXv_int14[20] = 1;
         }
         if ( StringUtil.StrCmp(AV24TFProfesionalesEmail_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "([ProfesionalesEmail] IS NULL or ([ProfesionalesEmail] = ''))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY [ProfesionalesEmail]";
         GXv_Object15[0] = scmdbuf;
         GXv_Object15[1] = GXv_int14;
         return GXv_Object15 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_P00BG2(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (int)dynConstraints[22] );
               case 1 :
                     return conditional_P00BG3(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (int)dynConstraints[22] );
               case 2 :
                     return conditional_P00BG4(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (int)dynConstraints[22] );
               case 3 :
                     return conditional_P00BG5(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (int)dynConstraints[22] );
               case 4 :
                     return conditional_P00BG6(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (int)dynConstraints[22] );
               case 5 :
                     return conditional_P00BG7(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (int)dynConstraints[22] );
               case 6 :
                     return conditional_P00BG8(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (int)dynConstraints[22] );
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
         ,new ForEachCursor(def[5])
         ,new ForEachCursor(def[6])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP00BG2;
          prmP00BG2 = new Object[] {
          new ParDef("@lV47FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("@lV47FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("@lV47FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("@lV47FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("@lV47FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("@lV47FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("@lV47FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("@lV11TFProfesionalesId",GXType.Char,20,0) ,
          new ParDef("@AV12TFProfesionalesId_Sel",GXType.Char,20,0) ,
          new ParDef("@lV13TFProfesionalesPrimerNombre",GXType.Char,30,0) ,
          new ParDef("@AV14TFProfesionalesPrimerNombre_Sel",GXType.NChar,30,0) ,
          new ParDef("@lV15TFProfesionalesSegundoNombre",GXType.Char,30,0) ,
          new ParDef("@AV16TFProfesionalesSegundoNombre_Sel",GXType.NChar,30,0) ,
          new ParDef("@lV17TFProfesionalesApellidoPrimero",GXType.Char,30,0) ,
          new ParDef("@AV18TFProfesionalesApellidoPrimero_Sel",GXType.NChar,30,0) ,
          new ParDef("@lV19TFProfesionalesApellidoSegundo",GXType.Char,30,0) ,
          new ParDef("@AV20TFProfesionalesApellidoSegundo_Sel",GXType.NChar,30,0) ,
          new ParDef("@lV21TFProfesionalesTelefono",GXType.Char,20,0) ,
          new ParDef("@AV22TFProfesionalesTelefono_Sel",GXType.NChar,20,0) ,
          new ParDef("@lV23TFProfesionalesEmail",GXType.VarChar,100,0) ,
          new ParDef("@AV24TFProfesionalesEmail_Sel",GXType.NVarChar,100,0) ,
          new ParDef("@GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0)
          };
          Object[] prmP00BG3;
          prmP00BG3 = new Object[] {
          new ParDef("@lV47FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("@lV47FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("@lV47FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("@lV47FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("@lV47FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("@lV47FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("@lV47FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("@lV11TFProfesionalesId",GXType.Char,20,0) ,
          new ParDef("@AV12TFProfesionalesId_Sel",GXType.Char,20,0) ,
          new ParDef("@lV13TFProfesionalesPrimerNombre",GXType.Char,30,0) ,
          new ParDef("@AV14TFProfesionalesPrimerNombre_Sel",GXType.NChar,30,0) ,
          new ParDef("@lV15TFProfesionalesSegundoNombre",GXType.Char,30,0) ,
          new ParDef("@AV16TFProfesionalesSegundoNombre_Sel",GXType.NChar,30,0) ,
          new ParDef("@lV17TFProfesionalesApellidoPrimero",GXType.Char,30,0) ,
          new ParDef("@AV18TFProfesionalesApellidoPrimero_Sel",GXType.NChar,30,0) ,
          new ParDef("@lV19TFProfesionalesApellidoSegundo",GXType.Char,30,0) ,
          new ParDef("@AV20TFProfesionalesApellidoSegundo_Sel",GXType.NChar,30,0) ,
          new ParDef("@lV21TFProfesionalesTelefono",GXType.Char,20,0) ,
          new ParDef("@AV22TFProfesionalesTelefono_Sel",GXType.NChar,20,0) ,
          new ParDef("@lV23TFProfesionalesEmail",GXType.VarChar,100,0) ,
          new ParDef("@AV24TFProfesionalesEmail_Sel",GXType.NVarChar,100,0)
          };
          Object[] prmP00BG4;
          prmP00BG4 = new Object[] {
          new ParDef("@lV47FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("@lV47FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("@lV47FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("@lV47FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("@lV47FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("@lV47FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("@lV47FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("@lV11TFProfesionalesId",GXType.Char,20,0) ,
          new ParDef("@AV12TFProfesionalesId_Sel",GXType.Char,20,0) ,
          new ParDef("@lV13TFProfesionalesPrimerNombre",GXType.Char,30,0) ,
          new ParDef("@AV14TFProfesionalesPrimerNombre_Sel",GXType.NChar,30,0) ,
          new ParDef("@lV15TFProfesionalesSegundoNombre",GXType.Char,30,0) ,
          new ParDef("@AV16TFProfesionalesSegundoNombre_Sel",GXType.NChar,30,0) ,
          new ParDef("@lV17TFProfesionalesApellidoPrimero",GXType.Char,30,0) ,
          new ParDef("@AV18TFProfesionalesApellidoPrimero_Sel",GXType.NChar,30,0) ,
          new ParDef("@lV19TFProfesionalesApellidoSegundo",GXType.Char,30,0) ,
          new ParDef("@AV20TFProfesionalesApellidoSegundo_Sel",GXType.NChar,30,0) ,
          new ParDef("@lV21TFProfesionalesTelefono",GXType.Char,20,0) ,
          new ParDef("@AV22TFProfesionalesTelefono_Sel",GXType.NChar,20,0) ,
          new ParDef("@lV23TFProfesionalesEmail",GXType.VarChar,100,0) ,
          new ParDef("@AV24TFProfesionalesEmail_Sel",GXType.NVarChar,100,0)
          };
          Object[] prmP00BG5;
          prmP00BG5 = new Object[] {
          new ParDef("@lV47FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("@lV47FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("@lV47FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("@lV47FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("@lV47FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("@lV47FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("@lV47FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("@lV11TFProfesionalesId",GXType.Char,20,0) ,
          new ParDef("@AV12TFProfesionalesId_Sel",GXType.Char,20,0) ,
          new ParDef("@lV13TFProfesionalesPrimerNombre",GXType.Char,30,0) ,
          new ParDef("@AV14TFProfesionalesPrimerNombre_Sel",GXType.NChar,30,0) ,
          new ParDef("@lV15TFProfesionalesSegundoNombre",GXType.Char,30,0) ,
          new ParDef("@AV16TFProfesionalesSegundoNombre_Sel",GXType.NChar,30,0) ,
          new ParDef("@lV17TFProfesionalesApellidoPrimero",GXType.Char,30,0) ,
          new ParDef("@AV18TFProfesionalesApellidoPrimero_Sel",GXType.NChar,30,0) ,
          new ParDef("@lV19TFProfesionalesApellidoSegundo",GXType.Char,30,0) ,
          new ParDef("@AV20TFProfesionalesApellidoSegundo_Sel",GXType.NChar,30,0) ,
          new ParDef("@lV21TFProfesionalesTelefono",GXType.Char,20,0) ,
          new ParDef("@AV22TFProfesionalesTelefono_Sel",GXType.NChar,20,0) ,
          new ParDef("@lV23TFProfesionalesEmail",GXType.VarChar,100,0) ,
          new ParDef("@AV24TFProfesionalesEmail_Sel",GXType.NVarChar,100,0)
          };
          Object[] prmP00BG6;
          prmP00BG6 = new Object[] {
          new ParDef("@lV47FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("@lV47FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("@lV47FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("@lV47FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("@lV47FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("@lV47FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("@lV47FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("@lV11TFProfesionalesId",GXType.Char,20,0) ,
          new ParDef("@AV12TFProfesionalesId_Sel",GXType.Char,20,0) ,
          new ParDef("@lV13TFProfesionalesPrimerNombre",GXType.Char,30,0) ,
          new ParDef("@AV14TFProfesionalesPrimerNombre_Sel",GXType.NChar,30,0) ,
          new ParDef("@lV15TFProfesionalesSegundoNombre",GXType.Char,30,0) ,
          new ParDef("@AV16TFProfesionalesSegundoNombre_Sel",GXType.NChar,30,0) ,
          new ParDef("@lV17TFProfesionalesApellidoPrimero",GXType.Char,30,0) ,
          new ParDef("@AV18TFProfesionalesApellidoPrimero_Sel",GXType.NChar,30,0) ,
          new ParDef("@lV19TFProfesionalesApellidoSegundo",GXType.Char,30,0) ,
          new ParDef("@AV20TFProfesionalesApellidoSegundo_Sel",GXType.NChar,30,0) ,
          new ParDef("@lV21TFProfesionalesTelefono",GXType.Char,20,0) ,
          new ParDef("@AV22TFProfesionalesTelefono_Sel",GXType.NChar,20,0) ,
          new ParDef("@lV23TFProfesionalesEmail",GXType.VarChar,100,0) ,
          new ParDef("@AV24TFProfesionalesEmail_Sel",GXType.NVarChar,100,0)
          };
          Object[] prmP00BG7;
          prmP00BG7 = new Object[] {
          new ParDef("@lV47FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("@lV47FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("@lV47FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("@lV47FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("@lV47FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("@lV47FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("@lV47FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("@lV11TFProfesionalesId",GXType.Char,20,0) ,
          new ParDef("@AV12TFProfesionalesId_Sel",GXType.Char,20,0) ,
          new ParDef("@lV13TFProfesionalesPrimerNombre",GXType.Char,30,0) ,
          new ParDef("@AV14TFProfesionalesPrimerNombre_Sel",GXType.NChar,30,0) ,
          new ParDef("@lV15TFProfesionalesSegundoNombre",GXType.Char,30,0) ,
          new ParDef("@AV16TFProfesionalesSegundoNombre_Sel",GXType.NChar,30,0) ,
          new ParDef("@lV17TFProfesionalesApellidoPrimero",GXType.Char,30,0) ,
          new ParDef("@AV18TFProfesionalesApellidoPrimero_Sel",GXType.NChar,30,0) ,
          new ParDef("@lV19TFProfesionalesApellidoSegundo",GXType.Char,30,0) ,
          new ParDef("@AV20TFProfesionalesApellidoSegundo_Sel",GXType.NChar,30,0) ,
          new ParDef("@lV21TFProfesionalesTelefono",GXType.Char,20,0) ,
          new ParDef("@AV22TFProfesionalesTelefono_Sel",GXType.NChar,20,0) ,
          new ParDef("@lV23TFProfesionalesEmail",GXType.VarChar,100,0) ,
          new ParDef("@AV24TFProfesionalesEmail_Sel",GXType.NVarChar,100,0)
          };
          Object[] prmP00BG8;
          prmP00BG8 = new Object[] {
          new ParDef("@lV47FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("@lV47FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("@lV47FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("@lV47FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("@lV47FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("@lV47FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("@lV47FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("@lV11TFProfesionalesId",GXType.Char,20,0) ,
          new ParDef("@AV12TFProfesionalesId_Sel",GXType.Char,20,0) ,
          new ParDef("@lV13TFProfesionalesPrimerNombre",GXType.Char,30,0) ,
          new ParDef("@AV14TFProfesionalesPrimerNombre_Sel",GXType.NChar,30,0) ,
          new ParDef("@lV15TFProfesionalesSegundoNombre",GXType.Char,30,0) ,
          new ParDef("@AV16TFProfesionalesSegundoNombre_Sel",GXType.NChar,30,0) ,
          new ParDef("@lV17TFProfesionalesApellidoPrimero",GXType.Char,30,0) ,
          new ParDef("@AV18TFProfesionalesApellidoPrimero_Sel",GXType.NChar,30,0) ,
          new ParDef("@lV19TFProfesionalesApellidoSegundo",GXType.Char,30,0) ,
          new ParDef("@AV20TFProfesionalesApellidoSegundo_Sel",GXType.NChar,30,0) ,
          new ParDef("@lV21TFProfesionalesTelefono",GXType.Char,20,0) ,
          new ParDef("@AV22TFProfesionalesTelefono_Sel",GXType.NChar,20,0) ,
          new ParDef("@lV23TFProfesionalesEmail",GXType.VarChar,100,0) ,
          new ParDef("@AV24TFProfesionalesEmail_Sel",GXType.NVarChar,100,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00BG2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00BG2,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P00BG3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00BG3,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00BG4", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00BG4,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00BG5", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00BG5,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00BG6", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00BG6,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00BG7", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00BG7,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00BG8", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00BG8,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getString(3, 20);
                ((string[]) buf[4])[0] = rslt.getString(4, 30);
                ((string[]) buf[5])[0] = rslt.getString(5, 30);
                ((string[]) buf[6])[0] = rslt.getString(6, 30);
                ((string[]) buf[7])[0] = rslt.getString(7, 30);
                ((string[]) buf[8])[0] = rslt.getString(8, 20);
                return;
             case 1 :
                ((string[]) buf[0])[0] = rslt.getString(1, 30);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((bool[]) buf[3])[0] = rslt.wasNull(3);
                ((string[]) buf[4])[0] = rslt.getString(4, 20);
                ((string[]) buf[5])[0] = rslt.getString(5, 30);
                ((string[]) buf[6])[0] = rslt.getString(6, 30);
                ((string[]) buf[7])[0] = rslt.getString(7, 30);
                ((string[]) buf[8])[0] = rslt.getString(8, 20);
                return;
             case 2 :
                ((string[]) buf[0])[0] = rslt.getString(1, 30);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((bool[]) buf[3])[0] = rslt.wasNull(3);
                ((string[]) buf[4])[0] = rslt.getString(4, 20);
                ((string[]) buf[5])[0] = rslt.getString(5, 30);
                ((string[]) buf[6])[0] = rslt.getString(6, 30);
                ((string[]) buf[7])[0] = rslt.getString(7, 30);
                ((string[]) buf[8])[0] = rslt.getString(8, 20);
                return;
             case 3 :
                ((string[]) buf[0])[0] = rslt.getString(1, 30);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((bool[]) buf[3])[0] = rslt.wasNull(3);
                ((string[]) buf[4])[0] = rslt.getString(4, 20);
                ((string[]) buf[5])[0] = rslt.getString(5, 30);
                ((string[]) buf[6])[0] = rslt.getString(6, 30);
                ((string[]) buf[7])[0] = rslt.getString(7, 30);
                ((string[]) buf[8])[0] = rslt.getString(8, 20);
                return;
             case 4 :
                ((string[]) buf[0])[0] = rslt.getString(1, 30);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((bool[]) buf[3])[0] = rslt.wasNull(3);
                ((string[]) buf[4])[0] = rslt.getString(4, 20);
                ((string[]) buf[5])[0] = rslt.getString(5, 30);
                ((string[]) buf[6])[0] = rslt.getString(6, 30);
                ((string[]) buf[7])[0] = rslt.getString(7, 30);
                ((string[]) buf[8])[0] = rslt.getString(8, 20);
                return;
             case 5 :
                ((string[]) buf[0])[0] = rslt.getString(1, 20);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((bool[]) buf[3])[0] = rslt.wasNull(3);
                ((string[]) buf[4])[0] = rslt.getString(4, 30);
                ((string[]) buf[5])[0] = rslt.getString(5, 30);
                ((string[]) buf[6])[0] = rslt.getString(6, 30);
                ((string[]) buf[7])[0] = rslt.getString(7, 30);
                ((string[]) buf[8])[0] = rslt.getString(8, 20);
                return;
             case 6 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((int[]) buf[2])[0] = rslt.getInt(2);
                ((string[]) buf[3])[0] = rslt.getString(3, 20);
                ((string[]) buf[4])[0] = rslt.getString(4, 30);
                ((string[]) buf[5])[0] = rslt.getString(5, 30);
                ((string[]) buf[6])[0] = rslt.getString(6, 30);
                ((string[]) buf[7])[0] = rslt.getString(7, 30);
                ((string[]) buf[8])[0] = rslt.getString(8, 20);
                return;
       }
    }

 }

 [ServiceContract(Namespace = "GeneXus.Programs.profesionalesfullnamepromptgetfilterdata_services")]
 [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple)]
 [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
 public class profesionalesfullnamepromptgetfilterdata_services : GxRestService
 {
    [OperationContract(Name = "ProfesionalesFullNamePromptGetFilterData" )]
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
          if ( ! ProcessHeaders("profesionalesfullnamepromptgetfilterdata") )
          {
             return  ;
          }
          profesionalesfullnamepromptgetfilterdata worker = new profesionalesfullnamepromptgetfilterdata(context);
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

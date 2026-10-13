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
   public class comisionesprofesionaleswcgetfilterdata : GXProcedure
   {
      public comisionesprofesionaleswcgetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public comisionesprofesionaleswcgetfilterdata( IGxContext context )
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
         new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWComisiones", out  GXt_boolean1) ;
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
            else if ( StringUtil.StrCmp(StringUtil.Upper( AV41DDOName), "DDO_ESTADOSGENERICOSNOMBRE") == 0 )
            {
               /* Execute user subroutine: 'LOADESTADOSGENERICOSNOMBREOPTIONS' */
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
         if ( StringUtil.StrCmp(AV36Session.Get("ComisionesProfesionalesWCGridState"), "") == 0 )
         {
            AV38GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "ComisionesProfesionalesWCGridState"), null, "", "");
         }
         else
         {
            AV38GridState.FromXml(AV36Session.Get("ComisionesProfesionalesWCGridState"), null, "", "");
         }
         AV48GXV1 = 1;
         while ( AV48GXV1 <= AV38GridState.gxTpr_Filtervalues.Count )
         {
            AV39GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV38GridState.gxTpr_Filtervalues.Item(AV48GXV1));
            if ( StringUtil.StrCmp(AV39GridStateFilterValue.gxTpr_Name, "TFPROFESIONALESID") == 0 )
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
            else if ( StringUtil.StrCmp(AV39GridStateFilterValue.gxTpr_Name, "TFESTADOSGENERICOSNOMBRE") == 0 )
            {
               AV23TFEstadosGenericosNombre = AV39GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV39GridStateFilterValue.gxTpr_Name, "TFESTADOSGENERICOSNOMBRE_SEL") == 0 )
            {
               AV24TFEstadosGenericosNombre_Sel = AV39GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV39GridStateFilterValue.gxTpr_Name, "PARM_&COMISIONESID") == 0 )
            {
               AV47ComisionesID = (long)(Math.Round(NumberUtil.Val( AV39GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
            }
            AV48GXV1 = (int)(AV48GXV1+1);
         }
      }

      protected void S121( )
      {
         /* 'LOADPROFESIONALESIDOPTIONS' Routine */
         returnInSub = false;
         AV11TFProfesionalesId = AV25SearchTxt;
         AV12TFProfesionalesId_Sel = "";
         pr_default.dynParam(0, new Object[]{ new Object[]{
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
                                              AV24TFEstadosGenericosNombre_Sel ,
                                              AV23TFEstadosGenericosNombre ,
                                              A120ProfesionalesId ,
                                              A166ProfesionalesPrimerNombre ,
                                              A191ProfesionalesSegundoNombre ,
                                              A167ProfesionalesApellidoPrimero ,
                                              A192ProfesionalesApellidoSegundo ,
                                              A170ProfesionalesTelefono ,
                                              A109EstadosGenericosNombre ,
                                              AV47ComisionesID ,
                                              A503ComisionesID } ,
                                              new int[]{
                                              TypeConstants.LONG, TypeConstants.LONG
                                              }
         });
         lV11TFProfesionalesId = StringUtil.PadR( StringUtil.RTrim( AV11TFProfesionalesId), 20, "%");
         lV13TFProfesionalesPrimerNombre = StringUtil.PadR( StringUtil.RTrim( AV13TFProfesionalesPrimerNombre), 30, "%");
         lV15TFProfesionalesSegundoNombre = StringUtil.PadR( StringUtil.RTrim( AV15TFProfesionalesSegundoNombre), 30, "%");
         lV17TFProfesionalesApellidoPrimero = StringUtil.PadR( StringUtil.RTrim( AV17TFProfesionalesApellidoPrimero), 30, "%");
         lV19TFProfesionalesApellidoSegundo = StringUtil.PadR( StringUtil.RTrim( AV19TFProfesionalesApellidoSegundo), 30, "%");
         lV21TFProfesionalesTelefono = StringUtil.PadR( StringUtil.RTrim( AV21TFProfesionalesTelefono), 20, "%");
         lV23TFEstadosGenericosNombre = StringUtil.PadR( StringUtil.RTrim( AV23TFEstadosGenericosNombre), 80, "%");
         /* Using cursor P006G2 */
         pr_default.execute(0, new Object[] {AV47ComisionesID, lV11TFProfesionalesId, AV12TFProfesionalesId_Sel, lV13TFProfesionalesPrimerNombre, AV14TFProfesionalesPrimerNombre_Sel, lV15TFProfesionalesSegundoNombre, AV16TFProfesionalesSegundoNombre_Sel, lV17TFProfesionalesApellidoPrimero, AV18TFProfesionalesApellidoPrimero_Sel, lV19TFProfesionalesApellidoSegundo, AV20TFProfesionalesApellidoSegundo_Sel, lV21TFProfesionalesTelefono, AV22TFProfesionalesTelefono_Sel, lV23TFEstadosGenericosNombre, AV24TFEstadosGenericosNombre_Sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRK6G2 = false;
            A107EstadosTipo = P006G2_A107EstadosTipo[0];
            A108EstadosGenericosId = P006G2_A108EstadosGenericosId[0];
            A120ProfesionalesId = P006G2_A120ProfesionalesId[0];
            A503ComisionesID = P006G2_A503ComisionesID[0];
            A109EstadosGenericosNombre = P006G2_A109EstadosGenericosNombre[0];
            A170ProfesionalesTelefono = P006G2_A170ProfesionalesTelefono[0];
            A192ProfesionalesApellidoSegundo = P006G2_A192ProfesionalesApellidoSegundo[0];
            A167ProfesionalesApellidoPrimero = P006G2_A167ProfesionalesApellidoPrimero[0];
            A191ProfesionalesSegundoNombre = P006G2_A191ProfesionalesSegundoNombre[0];
            A166ProfesionalesPrimerNombre = P006G2_A166ProfesionalesPrimerNombre[0];
            A107EstadosTipo = P006G2_A107EstadosTipo[0];
            A108EstadosGenericosId = P006G2_A108EstadosGenericosId[0];
            A170ProfesionalesTelefono = P006G2_A170ProfesionalesTelefono[0];
            A192ProfesionalesApellidoSegundo = P006G2_A192ProfesionalesApellidoSegundo[0];
            A167ProfesionalesApellidoPrimero = P006G2_A167ProfesionalesApellidoPrimero[0];
            A191ProfesionalesSegundoNombre = P006G2_A191ProfesionalesSegundoNombre[0];
            A166ProfesionalesPrimerNombre = P006G2_A166ProfesionalesPrimerNombre[0];
            A109EstadosGenericosNombre = P006G2_A109EstadosGenericosNombre[0];
            AV35count = 0;
            while ( (pr_default.getStatus(0) != 101) && ( P006G2_A503ComisionesID[0] == A503ComisionesID ) && ( StringUtil.StrCmp(P006G2_A120ProfesionalesId[0], A120ProfesionalesId) == 0 ) )
            {
               BRK6G2 = false;
               AV35count = (long)(AV35count+1);
               BRK6G2 = true;
               pr_default.readNext(0);
            }
            if ( (0==AV26SkipItems) )
            {
               AV30Option = (String.IsNullOrEmpty(StringUtil.RTrim( A120ProfesionalesId)) ? "<#Empty#>" : A120ProfesionalesId);
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
            if ( ! BRK6G2 )
            {
               BRK6G2 = true;
               pr_default.readNext(0);
            }
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
                                              AV24TFEstadosGenericosNombre_Sel ,
                                              AV23TFEstadosGenericosNombre ,
                                              A120ProfesionalesId ,
                                              A166ProfesionalesPrimerNombre ,
                                              A191ProfesionalesSegundoNombre ,
                                              A167ProfesionalesApellidoPrimero ,
                                              A192ProfesionalesApellidoSegundo ,
                                              A170ProfesionalesTelefono ,
                                              A109EstadosGenericosNombre ,
                                              AV47ComisionesID ,
                                              A503ComisionesID } ,
                                              new int[]{
                                              TypeConstants.LONG, TypeConstants.LONG
                                              }
         });
         lV11TFProfesionalesId = StringUtil.PadR( StringUtil.RTrim( AV11TFProfesionalesId), 20, "%");
         lV13TFProfesionalesPrimerNombre = StringUtil.PadR( StringUtil.RTrim( AV13TFProfesionalesPrimerNombre), 30, "%");
         lV15TFProfesionalesSegundoNombre = StringUtil.PadR( StringUtil.RTrim( AV15TFProfesionalesSegundoNombre), 30, "%");
         lV17TFProfesionalesApellidoPrimero = StringUtil.PadR( StringUtil.RTrim( AV17TFProfesionalesApellidoPrimero), 30, "%");
         lV19TFProfesionalesApellidoSegundo = StringUtil.PadR( StringUtil.RTrim( AV19TFProfesionalesApellidoSegundo), 30, "%");
         lV21TFProfesionalesTelefono = StringUtil.PadR( StringUtil.RTrim( AV21TFProfesionalesTelefono), 20, "%");
         lV23TFEstadosGenericosNombre = StringUtil.PadR( StringUtil.RTrim( AV23TFEstadosGenericosNombre), 80, "%");
         /* Using cursor P006G3 */
         pr_default.execute(1, new Object[] {AV47ComisionesID, lV11TFProfesionalesId, AV12TFProfesionalesId_Sel, lV13TFProfesionalesPrimerNombre, AV14TFProfesionalesPrimerNombre_Sel, lV15TFProfesionalesSegundoNombre, AV16TFProfesionalesSegundoNombre_Sel, lV17TFProfesionalesApellidoPrimero, AV18TFProfesionalesApellidoPrimero_Sel, lV19TFProfesionalesApellidoSegundo, AV20TFProfesionalesApellidoSegundo_Sel, lV21TFProfesionalesTelefono, AV22TFProfesionalesTelefono_Sel, lV23TFEstadosGenericosNombre, AV24TFEstadosGenericosNombre_Sel});
         while ( (pr_default.getStatus(1) != 101) )
         {
            BRK6G4 = false;
            A107EstadosTipo = P006G3_A107EstadosTipo[0];
            A108EstadosGenericosId = P006G3_A108EstadosGenericosId[0];
            A503ComisionesID = P006G3_A503ComisionesID[0];
            A166ProfesionalesPrimerNombre = P006G3_A166ProfesionalesPrimerNombre[0];
            A109EstadosGenericosNombre = P006G3_A109EstadosGenericosNombre[0];
            A170ProfesionalesTelefono = P006G3_A170ProfesionalesTelefono[0];
            A192ProfesionalesApellidoSegundo = P006G3_A192ProfesionalesApellidoSegundo[0];
            A167ProfesionalesApellidoPrimero = P006G3_A167ProfesionalesApellidoPrimero[0];
            A191ProfesionalesSegundoNombre = P006G3_A191ProfesionalesSegundoNombre[0];
            A120ProfesionalesId = P006G3_A120ProfesionalesId[0];
            A107EstadosTipo = P006G3_A107EstadosTipo[0];
            A108EstadosGenericosId = P006G3_A108EstadosGenericosId[0];
            A166ProfesionalesPrimerNombre = P006G3_A166ProfesionalesPrimerNombre[0];
            A170ProfesionalesTelefono = P006G3_A170ProfesionalesTelefono[0];
            A192ProfesionalesApellidoSegundo = P006G3_A192ProfesionalesApellidoSegundo[0];
            A167ProfesionalesApellidoPrimero = P006G3_A167ProfesionalesApellidoPrimero[0];
            A191ProfesionalesSegundoNombre = P006G3_A191ProfesionalesSegundoNombre[0];
            A109EstadosGenericosNombre = P006G3_A109EstadosGenericosNombre[0];
            AV35count = 0;
            while ( (pr_default.getStatus(1) != 101) && ( P006G3_A503ComisionesID[0] == A503ComisionesID ) && ( StringUtil.StrCmp(P006G3_A166ProfesionalesPrimerNombre[0], A166ProfesionalesPrimerNombre) == 0 ) )
            {
               BRK6G4 = false;
               A120ProfesionalesId = P006G3_A120ProfesionalesId[0];
               AV35count = (long)(AV35count+1);
               BRK6G4 = true;
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
            if ( ! BRK6G4 )
            {
               BRK6G4 = true;
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
                                              AV24TFEstadosGenericosNombre_Sel ,
                                              AV23TFEstadosGenericosNombre ,
                                              A120ProfesionalesId ,
                                              A166ProfesionalesPrimerNombre ,
                                              A191ProfesionalesSegundoNombre ,
                                              A167ProfesionalesApellidoPrimero ,
                                              A192ProfesionalesApellidoSegundo ,
                                              A170ProfesionalesTelefono ,
                                              A109EstadosGenericosNombre ,
                                              AV47ComisionesID ,
                                              A503ComisionesID } ,
                                              new int[]{
                                              TypeConstants.LONG, TypeConstants.LONG
                                              }
         });
         lV11TFProfesionalesId = StringUtil.PadR( StringUtil.RTrim( AV11TFProfesionalesId), 20, "%");
         lV13TFProfesionalesPrimerNombre = StringUtil.PadR( StringUtil.RTrim( AV13TFProfesionalesPrimerNombre), 30, "%");
         lV15TFProfesionalesSegundoNombre = StringUtil.PadR( StringUtil.RTrim( AV15TFProfesionalesSegundoNombre), 30, "%");
         lV17TFProfesionalesApellidoPrimero = StringUtil.PadR( StringUtil.RTrim( AV17TFProfesionalesApellidoPrimero), 30, "%");
         lV19TFProfesionalesApellidoSegundo = StringUtil.PadR( StringUtil.RTrim( AV19TFProfesionalesApellidoSegundo), 30, "%");
         lV21TFProfesionalesTelefono = StringUtil.PadR( StringUtil.RTrim( AV21TFProfesionalesTelefono), 20, "%");
         lV23TFEstadosGenericosNombre = StringUtil.PadR( StringUtil.RTrim( AV23TFEstadosGenericosNombre), 80, "%");
         /* Using cursor P006G4 */
         pr_default.execute(2, new Object[] {AV47ComisionesID, lV11TFProfesionalesId, AV12TFProfesionalesId_Sel, lV13TFProfesionalesPrimerNombre, AV14TFProfesionalesPrimerNombre_Sel, lV15TFProfesionalesSegundoNombre, AV16TFProfesionalesSegundoNombre_Sel, lV17TFProfesionalesApellidoPrimero, AV18TFProfesionalesApellidoPrimero_Sel, lV19TFProfesionalesApellidoSegundo, AV20TFProfesionalesApellidoSegundo_Sel, lV21TFProfesionalesTelefono, AV22TFProfesionalesTelefono_Sel, lV23TFEstadosGenericosNombre, AV24TFEstadosGenericosNombre_Sel});
         while ( (pr_default.getStatus(2) != 101) )
         {
            BRK6G6 = false;
            A107EstadosTipo = P006G4_A107EstadosTipo[0];
            A108EstadosGenericosId = P006G4_A108EstadosGenericosId[0];
            A503ComisionesID = P006G4_A503ComisionesID[0];
            A191ProfesionalesSegundoNombre = P006G4_A191ProfesionalesSegundoNombre[0];
            A109EstadosGenericosNombre = P006G4_A109EstadosGenericosNombre[0];
            A170ProfesionalesTelefono = P006G4_A170ProfesionalesTelefono[0];
            A192ProfesionalesApellidoSegundo = P006G4_A192ProfesionalesApellidoSegundo[0];
            A167ProfesionalesApellidoPrimero = P006G4_A167ProfesionalesApellidoPrimero[0];
            A166ProfesionalesPrimerNombre = P006G4_A166ProfesionalesPrimerNombre[0];
            A120ProfesionalesId = P006G4_A120ProfesionalesId[0];
            A107EstadosTipo = P006G4_A107EstadosTipo[0];
            A108EstadosGenericosId = P006G4_A108EstadosGenericosId[0];
            A191ProfesionalesSegundoNombre = P006G4_A191ProfesionalesSegundoNombre[0];
            A170ProfesionalesTelefono = P006G4_A170ProfesionalesTelefono[0];
            A192ProfesionalesApellidoSegundo = P006G4_A192ProfesionalesApellidoSegundo[0];
            A167ProfesionalesApellidoPrimero = P006G4_A167ProfesionalesApellidoPrimero[0];
            A166ProfesionalesPrimerNombre = P006G4_A166ProfesionalesPrimerNombre[0];
            A109EstadosGenericosNombre = P006G4_A109EstadosGenericosNombre[0];
            AV35count = 0;
            while ( (pr_default.getStatus(2) != 101) && ( P006G4_A503ComisionesID[0] == A503ComisionesID ) && ( StringUtil.StrCmp(P006G4_A191ProfesionalesSegundoNombre[0], A191ProfesionalesSegundoNombre) == 0 ) )
            {
               BRK6G6 = false;
               A120ProfesionalesId = P006G4_A120ProfesionalesId[0];
               AV35count = (long)(AV35count+1);
               BRK6G6 = true;
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
            if ( ! BRK6G6 )
            {
               BRK6G6 = true;
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
                                              AV24TFEstadosGenericosNombre_Sel ,
                                              AV23TFEstadosGenericosNombre ,
                                              A120ProfesionalesId ,
                                              A166ProfesionalesPrimerNombre ,
                                              A191ProfesionalesSegundoNombre ,
                                              A167ProfesionalesApellidoPrimero ,
                                              A192ProfesionalesApellidoSegundo ,
                                              A170ProfesionalesTelefono ,
                                              A109EstadosGenericosNombre ,
                                              AV47ComisionesID ,
                                              A503ComisionesID } ,
                                              new int[]{
                                              TypeConstants.LONG, TypeConstants.LONG
                                              }
         });
         lV11TFProfesionalesId = StringUtil.PadR( StringUtil.RTrim( AV11TFProfesionalesId), 20, "%");
         lV13TFProfesionalesPrimerNombre = StringUtil.PadR( StringUtil.RTrim( AV13TFProfesionalesPrimerNombre), 30, "%");
         lV15TFProfesionalesSegundoNombre = StringUtil.PadR( StringUtil.RTrim( AV15TFProfesionalesSegundoNombre), 30, "%");
         lV17TFProfesionalesApellidoPrimero = StringUtil.PadR( StringUtil.RTrim( AV17TFProfesionalesApellidoPrimero), 30, "%");
         lV19TFProfesionalesApellidoSegundo = StringUtil.PadR( StringUtil.RTrim( AV19TFProfesionalesApellidoSegundo), 30, "%");
         lV21TFProfesionalesTelefono = StringUtil.PadR( StringUtil.RTrim( AV21TFProfesionalesTelefono), 20, "%");
         lV23TFEstadosGenericosNombre = StringUtil.PadR( StringUtil.RTrim( AV23TFEstadosGenericosNombre), 80, "%");
         /* Using cursor P006G5 */
         pr_default.execute(3, new Object[] {AV47ComisionesID, lV11TFProfesionalesId, AV12TFProfesionalesId_Sel, lV13TFProfesionalesPrimerNombre, AV14TFProfesionalesPrimerNombre_Sel, lV15TFProfesionalesSegundoNombre, AV16TFProfesionalesSegundoNombre_Sel, lV17TFProfesionalesApellidoPrimero, AV18TFProfesionalesApellidoPrimero_Sel, lV19TFProfesionalesApellidoSegundo, AV20TFProfesionalesApellidoSegundo_Sel, lV21TFProfesionalesTelefono, AV22TFProfesionalesTelefono_Sel, lV23TFEstadosGenericosNombre, AV24TFEstadosGenericosNombre_Sel});
         while ( (pr_default.getStatus(3) != 101) )
         {
            BRK6G8 = false;
            A107EstadosTipo = P006G5_A107EstadosTipo[0];
            A108EstadosGenericosId = P006G5_A108EstadosGenericosId[0];
            A503ComisionesID = P006G5_A503ComisionesID[0];
            A167ProfesionalesApellidoPrimero = P006G5_A167ProfesionalesApellidoPrimero[0];
            A109EstadosGenericosNombre = P006G5_A109EstadosGenericosNombre[0];
            A170ProfesionalesTelefono = P006G5_A170ProfesionalesTelefono[0];
            A192ProfesionalesApellidoSegundo = P006G5_A192ProfesionalesApellidoSegundo[0];
            A191ProfesionalesSegundoNombre = P006G5_A191ProfesionalesSegundoNombre[0];
            A166ProfesionalesPrimerNombre = P006G5_A166ProfesionalesPrimerNombre[0];
            A120ProfesionalesId = P006G5_A120ProfesionalesId[0];
            A107EstadosTipo = P006G5_A107EstadosTipo[0];
            A108EstadosGenericosId = P006G5_A108EstadosGenericosId[0];
            A167ProfesionalesApellidoPrimero = P006G5_A167ProfesionalesApellidoPrimero[0];
            A170ProfesionalesTelefono = P006G5_A170ProfesionalesTelefono[0];
            A192ProfesionalesApellidoSegundo = P006G5_A192ProfesionalesApellidoSegundo[0];
            A191ProfesionalesSegundoNombre = P006G5_A191ProfesionalesSegundoNombre[0];
            A166ProfesionalesPrimerNombre = P006G5_A166ProfesionalesPrimerNombre[0];
            A109EstadosGenericosNombre = P006G5_A109EstadosGenericosNombre[0];
            AV35count = 0;
            while ( (pr_default.getStatus(3) != 101) && ( P006G5_A503ComisionesID[0] == A503ComisionesID ) && ( StringUtil.StrCmp(P006G5_A167ProfesionalesApellidoPrimero[0], A167ProfesionalesApellidoPrimero) == 0 ) )
            {
               BRK6G8 = false;
               A120ProfesionalesId = P006G5_A120ProfesionalesId[0];
               AV35count = (long)(AV35count+1);
               BRK6G8 = true;
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
            if ( ! BRK6G8 )
            {
               BRK6G8 = true;
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
                                              AV24TFEstadosGenericosNombre_Sel ,
                                              AV23TFEstadosGenericosNombre ,
                                              A120ProfesionalesId ,
                                              A166ProfesionalesPrimerNombre ,
                                              A191ProfesionalesSegundoNombre ,
                                              A167ProfesionalesApellidoPrimero ,
                                              A192ProfesionalesApellidoSegundo ,
                                              A170ProfesionalesTelefono ,
                                              A109EstadosGenericosNombre ,
                                              AV47ComisionesID ,
                                              A503ComisionesID } ,
                                              new int[]{
                                              TypeConstants.LONG, TypeConstants.LONG
                                              }
         });
         lV11TFProfesionalesId = StringUtil.PadR( StringUtil.RTrim( AV11TFProfesionalesId), 20, "%");
         lV13TFProfesionalesPrimerNombre = StringUtil.PadR( StringUtil.RTrim( AV13TFProfesionalesPrimerNombre), 30, "%");
         lV15TFProfesionalesSegundoNombre = StringUtil.PadR( StringUtil.RTrim( AV15TFProfesionalesSegundoNombre), 30, "%");
         lV17TFProfesionalesApellidoPrimero = StringUtil.PadR( StringUtil.RTrim( AV17TFProfesionalesApellidoPrimero), 30, "%");
         lV19TFProfesionalesApellidoSegundo = StringUtil.PadR( StringUtil.RTrim( AV19TFProfesionalesApellidoSegundo), 30, "%");
         lV21TFProfesionalesTelefono = StringUtil.PadR( StringUtil.RTrim( AV21TFProfesionalesTelefono), 20, "%");
         lV23TFEstadosGenericosNombre = StringUtil.PadR( StringUtil.RTrim( AV23TFEstadosGenericosNombre), 80, "%");
         /* Using cursor P006G6 */
         pr_default.execute(4, new Object[] {AV47ComisionesID, lV11TFProfesionalesId, AV12TFProfesionalesId_Sel, lV13TFProfesionalesPrimerNombre, AV14TFProfesionalesPrimerNombre_Sel, lV15TFProfesionalesSegundoNombre, AV16TFProfesionalesSegundoNombre_Sel, lV17TFProfesionalesApellidoPrimero, AV18TFProfesionalesApellidoPrimero_Sel, lV19TFProfesionalesApellidoSegundo, AV20TFProfesionalesApellidoSegundo_Sel, lV21TFProfesionalesTelefono, AV22TFProfesionalesTelefono_Sel, lV23TFEstadosGenericosNombre, AV24TFEstadosGenericosNombre_Sel});
         while ( (pr_default.getStatus(4) != 101) )
         {
            BRK6G10 = false;
            A107EstadosTipo = P006G6_A107EstadosTipo[0];
            A108EstadosGenericosId = P006G6_A108EstadosGenericosId[0];
            A503ComisionesID = P006G6_A503ComisionesID[0];
            A192ProfesionalesApellidoSegundo = P006G6_A192ProfesionalesApellidoSegundo[0];
            A109EstadosGenericosNombre = P006G6_A109EstadosGenericosNombre[0];
            A170ProfesionalesTelefono = P006G6_A170ProfesionalesTelefono[0];
            A167ProfesionalesApellidoPrimero = P006G6_A167ProfesionalesApellidoPrimero[0];
            A191ProfesionalesSegundoNombre = P006G6_A191ProfesionalesSegundoNombre[0];
            A166ProfesionalesPrimerNombre = P006G6_A166ProfesionalesPrimerNombre[0];
            A120ProfesionalesId = P006G6_A120ProfesionalesId[0];
            A107EstadosTipo = P006G6_A107EstadosTipo[0];
            A108EstadosGenericosId = P006G6_A108EstadosGenericosId[0];
            A192ProfesionalesApellidoSegundo = P006G6_A192ProfesionalesApellidoSegundo[0];
            A170ProfesionalesTelefono = P006G6_A170ProfesionalesTelefono[0];
            A167ProfesionalesApellidoPrimero = P006G6_A167ProfesionalesApellidoPrimero[0];
            A191ProfesionalesSegundoNombre = P006G6_A191ProfesionalesSegundoNombre[0];
            A166ProfesionalesPrimerNombre = P006G6_A166ProfesionalesPrimerNombre[0];
            A109EstadosGenericosNombre = P006G6_A109EstadosGenericosNombre[0];
            AV35count = 0;
            while ( (pr_default.getStatus(4) != 101) && ( P006G6_A503ComisionesID[0] == A503ComisionesID ) && ( StringUtil.StrCmp(P006G6_A192ProfesionalesApellidoSegundo[0], A192ProfesionalesApellidoSegundo) == 0 ) )
            {
               BRK6G10 = false;
               A120ProfesionalesId = P006G6_A120ProfesionalesId[0];
               AV35count = (long)(AV35count+1);
               BRK6G10 = true;
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
            if ( ! BRK6G10 )
            {
               BRK6G10 = true;
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
                                              AV24TFEstadosGenericosNombre_Sel ,
                                              AV23TFEstadosGenericosNombre ,
                                              A120ProfesionalesId ,
                                              A166ProfesionalesPrimerNombre ,
                                              A191ProfesionalesSegundoNombre ,
                                              A167ProfesionalesApellidoPrimero ,
                                              A192ProfesionalesApellidoSegundo ,
                                              A170ProfesionalesTelefono ,
                                              A109EstadosGenericosNombre ,
                                              AV47ComisionesID ,
                                              A503ComisionesID } ,
                                              new int[]{
                                              TypeConstants.LONG, TypeConstants.LONG
                                              }
         });
         lV11TFProfesionalesId = StringUtil.PadR( StringUtil.RTrim( AV11TFProfesionalesId), 20, "%");
         lV13TFProfesionalesPrimerNombre = StringUtil.PadR( StringUtil.RTrim( AV13TFProfesionalesPrimerNombre), 30, "%");
         lV15TFProfesionalesSegundoNombre = StringUtil.PadR( StringUtil.RTrim( AV15TFProfesionalesSegundoNombre), 30, "%");
         lV17TFProfesionalesApellidoPrimero = StringUtil.PadR( StringUtil.RTrim( AV17TFProfesionalesApellidoPrimero), 30, "%");
         lV19TFProfesionalesApellidoSegundo = StringUtil.PadR( StringUtil.RTrim( AV19TFProfesionalesApellidoSegundo), 30, "%");
         lV21TFProfesionalesTelefono = StringUtil.PadR( StringUtil.RTrim( AV21TFProfesionalesTelefono), 20, "%");
         lV23TFEstadosGenericosNombre = StringUtil.PadR( StringUtil.RTrim( AV23TFEstadosGenericosNombre), 80, "%");
         /* Using cursor P006G7 */
         pr_default.execute(5, new Object[] {AV47ComisionesID, lV11TFProfesionalesId, AV12TFProfesionalesId_Sel, lV13TFProfesionalesPrimerNombre, AV14TFProfesionalesPrimerNombre_Sel, lV15TFProfesionalesSegundoNombre, AV16TFProfesionalesSegundoNombre_Sel, lV17TFProfesionalesApellidoPrimero, AV18TFProfesionalesApellidoPrimero_Sel, lV19TFProfesionalesApellidoSegundo, AV20TFProfesionalesApellidoSegundo_Sel, lV21TFProfesionalesTelefono, AV22TFProfesionalesTelefono_Sel, lV23TFEstadosGenericosNombre, AV24TFEstadosGenericosNombre_Sel});
         while ( (pr_default.getStatus(5) != 101) )
         {
            BRK6G12 = false;
            A107EstadosTipo = P006G7_A107EstadosTipo[0];
            A108EstadosGenericosId = P006G7_A108EstadosGenericosId[0];
            A503ComisionesID = P006G7_A503ComisionesID[0];
            A170ProfesionalesTelefono = P006G7_A170ProfesionalesTelefono[0];
            A109EstadosGenericosNombre = P006G7_A109EstadosGenericosNombre[0];
            A192ProfesionalesApellidoSegundo = P006G7_A192ProfesionalesApellidoSegundo[0];
            A167ProfesionalesApellidoPrimero = P006G7_A167ProfesionalesApellidoPrimero[0];
            A191ProfesionalesSegundoNombre = P006G7_A191ProfesionalesSegundoNombre[0];
            A166ProfesionalesPrimerNombre = P006G7_A166ProfesionalesPrimerNombre[0];
            A120ProfesionalesId = P006G7_A120ProfesionalesId[0];
            A107EstadosTipo = P006G7_A107EstadosTipo[0];
            A108EstadosGenericosId = P006G7_A108EstadosGenericosId[0];
            A170ProfesionalesTelefono = P006G7_A170ProfesionalesTelefono[0];
            A192ProfesionalesApellidoSegundo = P006G7_A192ProfesionalesApellidoSegundo[0];
            A167ProfesionalesApellidoPrimero = P006G7_A167ProfesionalesApellidoPrimero[0];
            A191ProfesionalesSegundoNombre = P006G7_A191ProfesionalesSegundoNombre[0];
            A166ProfesionalesPrimerNombre = P006G7_A166ProfesionalesPrimerNombre[0];
            A109EstadosGenericosNombre = P006G7_A109EstadosGenericosNombre[0];
            AV35count = 0;
            while ( (pr_default.getStatus(5) != 101) && ( P006G7_A503ComisionesID[0] == A503ComisionesID ) && ( StringUtil.StrCmp(P006G7_A170ProfesionalesTelefono[0], A170ProfesionalesTelefono) == 0 ) )
            {
               BRK6G12 = false;
               A120ProfesionalesId = P006G7_A120ProfesionalesId[0];
               AV35count = (long)(AV35count+1);
               BRK6G12 = true;
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
            if ( ! BRK6G12 )
            {
               BRK6G12 = true;
               pr_default.readNext(5);
            }
         }
         pr_default.close(5);
      }

      protected void S181( )
      {
         /* 'LOADESTADOSGENERICOSNOMBREOPTIONS' Routine */
         returnInSub = false;
         AV23TFEstadosGenericosNombre = AV25SearchTxt;
         AV24TFEstadosGenericosNombre_Sel = "";
         pr_default.dynParam(6, new Object[]{ new Object[]{
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
                                              AV24TFEstadosGenericosNombre_Sel ,
                                              AV23TFEstadosGenericosNombre ,
                                              A120ProfesionalesId ,
                                              A166ProfesionalesPrimerNombre ,
                                              A191ProfesionalesSegundoNombre ,
                                              A167ProfesionalesApellidoPrimero ,
                                              A192ProfesionalesApellidoSegundo ,
                                              A170ProfesionalesTelefono ,
                                              A109EstadosGenericosNombre ,
                                              AV47ComisionesID ,
                                              A503ComisionesID } ,
                                              new int[]{
                                              TypeConstants.LONG, TypeConstants.LONG
                                              }
         });
         lV11TFProfesionalesId = StringUtil.PadR( StringUtil.RTrim( AV11TFProfesionalesId), 20, "%");
         lV13TFProfesionalesPrimerNombre = StringUtil.PadR( StringUtil.RTrim( AV13TFProfesionalesPrimerNombre), 30, "%");
         lV15TFProfesionalesSegundoNombre = StringUtil.PadR( StringUtil.RTrim( AV15TFProfesionalesSegundoNombre), 30, "%");
         lV17TFProfesionalesApellidoPrimero = StringUtil.PadR( StringUtil.RTrim( AV17TFProfesionalesApellidoPrimero), 30, "%");
         lV19TFProfesionalesApellidoSegundo = StringUtil.PadR( StringUtil.RTrim( AV19TFProfesionalesApellidoSegundo), 30, "%");
         lV21TFProfesionalesTelefono = StringUtil.PadR( StringUtil.RTrim( AV21TFProfesionalesTelefono), 20, "%");
         lV23TFEstadosGenericosNombre = StringUtil.PadR( StringUtil.RTrim( AV23TFEstadosGenericosNombre), 80, "%");
         /* Using cursor P006G8 */
         pr_default.execute(6, new Object[] {AV47ComisionesID, lV11TFProfesionalesId, AV12TFProfesionalesId_Sel, lV13TFProfesionalesPrimerNombre, AV14TFProfesionalesPrimerNombre_Sel, lV15TFProfesionalesSegundoNombre, AV16TFProfesionalesSegundoNombre_Sel, lV17TFProfesionalesApellidoPrimero, AV18TFProfesionalesApellidoPrimero_Sel, lV19TFProfesionalesApellidoSegundo, AV20TFProfesionalesApellidoSegundo_Sel, lV21TFProfesionalesTelefono, AV22TFProfesionalesTelefono_Sel, lV23TFEstadosGenericosNombre, AV24TFEstadosGenericosNombre_Sel});
         while ( (pr_default.getStatus(6) != 101) )
         {
            BRK6G14 = false;
            A107EstadosTipo = P006G8_A107EstadosTipo[0];
            A108EstadosGenericosId = P006G8_A108EstadosGenericosId[0];
            A503ComisionesID = P006G8_A503ComisionesID[0];
            A109EstadosGenericosNombre = P006G8_A109EstadosGenericosNombre[0];
            A170ProfesionalesTelefono = P006G8_A170ProfesionalesTelefono[0];
            A192ProfesionalesApellidoSegundo = P006G8_A192ProfesionalesApellidoSegundo[0];
            A167ProfesionalesApellidoPrimero = P006G8_A167ProfesionalesApellidoPrimero[0];
            A191ProfesionalesSegundoNombre = P006G8_A191ProfesionalesSegundoNombre[0];
            A166ProfesionalesPrimerNombre = P006G8_A166ProfesionalesPrimerNombre[0];
            A120ProfesionalesId = P006G8_A120ProfesionalesId[0];
            A107EstadosTipo = P006G8_A107EstadosTipo[0];
            A108EstadosGenericosId = P006G8_A108EstadosGenericosId[0];
            A170ProfesionalesTelefono = P006G8_A170ProfesionalesTelefono[0];
            A192ProfesionalesApellidoSegundo = P006G8_A192ProfesionalesApellidoSegundo[0];
            A167ProfesionalesApellidoPrimero = P006G8_A167ProfesionalesApellidoPrimero[0];
            A191ProfesionalesSegundoNombre = P006G8_A191ProfesionalesSegundoNombre[0];
            A166ProfesionalesPrimerNombre = P006G8_A166ProfesionalesPrimerNombre[0];
            A109EstadosGenericosNombre = P006G8_A109EstadosGenericosNombre[0];
            AV35count = 0;
            while ( (pr_default.getStatus(6) != 101) && ( P006G8_A503ComisionesID[0] == A503ComisionesID ) && ( StringUtil.StrCmp(P006G8_A109EstadosGenericosNombre[0], A109EstadosGenericosNombre) == 0 ) )
            {
               BRK6G14 = false;
               A107EstadosTipo = P006G8_A107EstadosTipo[0];
               A108EstadosGenericosId = P006G8_A108EstadosGenericosId[0];
               A120ProfesionalesId = P006G8_A120ProfesionalesId[0];
               A107EstadosTipo = P006G8_A107EstadosTipo[0];
               A108EstadosGenericosId = P006G8_A108EstadosGenericosId[0];
               AV35count = (long)(AV35count+1);
               BRK6G14 = true;
               pr_default.readNext(6);
            }
            if ( (0==AV26SkipItems) )
            {
               AV30Option = (String.IsNullOrEmpty(StringUtil.RTrim( A109EstadosGenericosNombre)) ? "<#Empty#>" : A109EstadosGenericosNombre);
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
            if ( ! BRK6G14 )
            {
               BRK6G14 = true;
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
         AV23TFEstadosGenericosNombre = "";
         AV24TFEstadosGenericosNombre_Sel = "";
         lV11TFProfesionalesId = "";
         lV13TFProfesionalesPrimerNombre = "";
         lV15TFProfesionalesSegundoNombre = "";
         lV17TFProfesionalesApellidoPrimero = "";
         lV19TFProfesionalesApellidoSegundo = "";
         lV21TFProfesionalesTelefono = "";
         lV23TFEstadosGenericosNombre = "";
         A120ProfesionalesId = "";
         A166ProfesionalesPrimerNombre = "";
         A191ProfesionalesSegundoNombre = "";
         A167ProfesionalesApellidoPrimero = "";
         A192ProfesionalesApellidoSegundo = "";
         A170ProfesionalesTelefono = "";
         A109EstadosGenericosNombre = "";
         P006G2_A107EstadosTipo = new string[] {""} ;
         P006G2_A108EstadosGenericosId = new int[1] ;
         P006G2_A120ProfesionalesId = new string[] {""} ;
         P006G2_A503ComisionesID = new long[1] ;
         P006G2_A109EstadosGenericosNombre = new string[] {""} ;
         P006G2_A170ProfesionalesTelefono = new string[] {""} ;
         P006G2_A192ProfesionalesApellidoSegundo = new string[] {""} ;
         P006G2_A167ProfesionalesApellidoPrimero = new string[] {""} ;
         P006G2_A191ProfesionalesSegundoNombre = new string[] {""} ;
         P006G2_A166ProfesionalesPrimerNombre = new string[] {""} ;
         A107EstadosTipo = "";
         AV30Option = "";
         P006G3_A107EstadosTipo = new string[] {""} ;
         P006G3_A108EstadosGenericosId = new int[1] ;
         P006G3_A503ComisionesID = new long[1] ;
         P006G3_A166ProfesionalesPrimerNombre = new string[] {""} ;
         P006G3_A109EstadosGenericosNombre = new string[] {""} ;
         P006G3_A170ProfesionalesTelefono = new string[] {""} ;
         P006G3_A192ProfesionalesApellidoSegundo = new string[] {""} ;
         P006G3_A167ProfesionalesApellidoPrimero = new string[] {""} ;
         P006G3_A191ProfesionalesSegundoNombre = new string[] {""} ;
         P006G3_A120ProfesionalesId = new string[] {""} ;
         P006G4_A107EstadosTipo = new string[] {""} ;
         P006G4_A108EstadosGenericosId = new int[1] ;
         P006G4_A503ComisionesID = new long[1] ;
         P006G4_A191ProfesionalesSegundoNombre = new string[] {""} ;
         P006G4_A109EstadosGenericosNombre = new string[] {""} ;
         P006G4_A170ProfesionalesTelefono = new string[] {""} ;
         P006G4_A192ProfesionalesApellidoSegundo = new string[] {""} ;
         P006G4_A167ProfesionalesApellidoPrimero = new string[] {""} ;
         P006G4_A166ProfesionalesPrimerNombre = new string[] {""} ;
         P006G4_A120ProfesionalesId = new string[] {""} ;
         P006G5_A107EstadosTipo = new string[] {""} ;
         P006G5_A108EstadosGenericosId = new int[1] ;
         P006G5_A503ComisionesID = new long[1] ;
         P006G5_A167ProfesionalesApellidoPrimero = new string[] {""} ;
         P006G5_A109EstadosGenericosNombre = new string[] {""} ;
         P006G5_A170ProfesionalesTelefono = new string[] {""} ;
         P006G5_A192ProfesionalesApellidoSegundo = new string[] {""} ;
         P006G5_A191ProfesionalesSegundoNombre = new string[] {""} ;
         P006G5_A166ProfesionalesPrimerNombre = new string[] {""} ;
         P006G5_A120ProfesionalesId = new string[] {""} ;
         P006G6_A107EstadosTipo = new string[] {""} ;
         P006G6_A108EstadosGenericosId = new int[1] ;
         P006G6_A503ComisionesID = new long[1] ;
         P006G6_A192ProfesionalesApellidoSegundo = new string[] {""} ;
         P006G6_A109EstadosGenericosNombre = new string[] {""} ;
         P006G6_A170ProfesionalesTelefono = new string[] {""} ;
         P006G6_A167ProfesionalesApellidoPrimero = new string[] {""} ;
         P006G6_A191ProfesionalesSegundoNombre = new string[] {""} ;
         P006G6_A166ProfesionalesPrimerNombre = new string[] {""} ;
         P006G6_A120ProfesionalesId = new string[] {""} ;
         P006G7_A107EstadosTipo = new string[] {""} ;
         P006G7_A108EstadosGenericosId = new int[1] ;
         P006G7_A503ComisionesID = new long[1] ;
         P006G7_A170ProfesionalesTelefono = new string[] {""} ;
         P006G7_A109EstadosGenericosNombre = new string[] {""} ;
         P006G7_A192ProfesionalesApellidoSegundo = new string[] {""} ;
         P006G7_A167ProfesionalesApellidoPrimero = new string[] {""} ;
         P006G7_A191ProfesionalesSegundoNombre = new string[] {""} ;
         P006G7_A166ProfesionalesPrimerNombre = new string[] {""} ;
         P006G7_A120ProfesionalesId = new string[] {""} ;
         P006G8_A107EstadosTipo = new string[] {""} ;
         P006G8_A108EstadosGenericosId = new int[1] ;
         P006G8_A503ComisionesID = new long[1] ;
         P006G8_A109EstadosGenericosNombre = new string[] {""} ;
         P006G8_A170ProfesionalesTelefono = new string[] {""} ;
         P006G8_A192ProfesionalesApellidoSegundo = new string[] {""} ;
         P006G8_A167ProfesionalesApellidoPrimero = new string[] {""} ;
         P006G8_A191ProfesionalesSegundoNombre = new string[] {""} ;
         P006G8_A166ProfesionalesPrimerNombre = new string[] {""} ;
         P006G8_A120ProfesionalesId = new string[] {""} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.comisionesprofesionaleswcgetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P006G2_A107EstadosTipo, P006G2_A108EstadosGenericosId, P006G2_A120ProfesionalesId, P006G2_A503ComisionesID, P006G2_A109EstadosGenericosNombre, P006G2_A170ProfesionalesTelefono, P006G2_A192ProfesionalesApellidoSegundo, P006G2_A167ProfesionalesApellidoPrimero, P006G2_A191ProfesionalesSegundoNombre, P006G2_A166ProfesionalesPrimerNombre
               }
               , new Object[] {
               P006G3_A107EstadosTipo, P006G3_A108EstadosGenericosId, P006G3_A503ComisionesID, P006G3_A166ProfesionalesPrimerNombre, P006G3_A109EstadosGenericosNombre, P006G3_A170ProfesionalesTelefono, P006G3_A192ProfesionalesApellidoSegundo, P006G3_A167ProfesionalesApellidoPrimero, P006G3_A191ProfesionalesSegundoNombre, P006G3_A120ProfesionalesId
               }
               , new Object[] {
               P006G4_A107EstadosTipo, P006G4_A108EstadosGenericosId, P006G4_A503ComisionesID, P006G4_A191ProfesionalesSegundoNombre, P006G4_A109EstadosGenericosNombre, P006G4_A170ProfesionalesTelefono, P006G4_A192ProfesionalesApellidoSegundo, P006G4_A167ProfesionalesApellidoPrimero, P006G4_A166ProfesionalesPrimerNombre, P006G4_A120ProfesionalesId
               }
               , new Object[] {
               P006G5_A107EstadosTipo, P006G5_A108EstadosGenericosId, P006G5_A503ComisionesID, P006G5_A167ProfesionalesApellidoPrimero, P006G5_A109EstadosGenericosNombre, P006G5_A170ProfesionalesTelefono, P006G5_A192ProfesionalesApellidoSegundo, P006G5_A191ProfesionalesSegundoNombre, P006G5_A166ProfesionalesPrimerNombre, P006G5_A120ProfesionalesId
               }
               , new Object[] {
               P006G6_A107EstadosTipo, P006G6_A108EstadosGenericosId, P006G6_A503ComisionesID, P006G6_A192ProfesionalesApellidoSegundo, P006G6_A109EstadosGenericosNombre, P006G6_A170ProfesionalesTelefono, P006G6_A167ProfesionalesApellidoPrimero, P006G6_A191ProfesionalesSegundoNombre, P006G6_A166ProfesionalesPrimerNombre, P006G6_A120ProfesionalesId
               }
               , new Object[] {
               P006G7_A107EstadosTipo, P006G7_A108EstadosGenericosId, P006G7_A503ComisionesID, P006G7_A170ProfesionalesTelefono, P006G7_A109EstadosGenericosNombre, P006G7_A192ProfesionalesApellidoSegundo, P006G7_A167ProfesionalesApellidoPrimero, P006G7_A191ProfesionalesSegundoNombre, P006G7_A166ProfesionalesPrimerNombre, P006G7_A120ProfesionalesId
               }
               , new Object[] {
               P006G8_A107EstadosTipo, P006G8_A108EstadosGenericosId, P006G8_A503ComisionesID, P006G8_A109EstadosGenericosNombre, P006G8_A170ProfesionalesTelefono, P006G8_A192ProfesionalesApellidoSegundo, P006G8_A167ProfesionalesApellidoPrimero, P006G8_A191ProfesionalesSegundoNombre, P006G8_A166ProfesionalesPrimerNombre, P006G8_A120ProfesionalesId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV28MaxItems ;
      private short AV27PageIndex ;
      private short AV26SkipItems ;
      private int AV48GXV1 ;
      private int A108EstadosGenericosId ;
      private long AV47ComisionesID ;
      private long A503ComisionesID ;
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
      private string AV23TFEstadosGenericosNombre ;
      private string AV24TFEstadosGenericosNombre_Sel ;
      private string lV11TFProfesionalesId ;
      private string lV13TFProfesionalesPrimerNombre ;
      private string lV15TFProfesionalesSegundoNombre ;
      private string lV17TFProfesionalesApellidoPrimero ;
      private string lV19TFProfesionalesApellidoSegundo ;
      private string lV21TFProfesionalesTelefono ;
      private string lV23TFEstadosGenericosNombre ;
      private string A120ProfesionalesId ;
      private string A166ProfesionalesPrimerNombre ;
      private string A191ProfesionalesSegundoNombre ;
      private string A167ProfesionalesApellidoPrimero ;
      private string A192ProfesionalesApellidoSegundo ;
      private string A170ProfesionalesTelefono ;
      private string A109EstadosGenericosNombre ;
      private string A107EstadosTipo ;
      private bool AV8IsAuthorized ;
      private bool GXt_boolean1 ;
      private bool returnInSub ;
      private bool BRK6G2 ;
      private bool BRK6G4 ;
      private bool BRK6G6 ;
      private bool BRK6G8 ;
      private bool BRK6G10 ;
      private bool BRK6G12 ;
      private bool BRK6G14 ;
      private string AV44OptionsJson ;
      private string AV45OptionsDescJson ;
      private string AV46OptionIndexesJson ;
      private string AV41DDOName ;
      private string AV42SearchTxtParms ;
      private string AV43SearchTxtTo ;
      private string AV25SearchTxt ;
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
      private string[] P006G2_A107EstadosTipo ;
      private int[] P006G2_A108EstadosGenericosId ;
      private string[] P006G2_A120ProfesionalesId ;
      private long[] P006G2_A503ComisionesID ;
      private string[] P006G2_A109EstadosGenericosNombre ;
      private string[] P006G2_A170ProfesionalesTelefono ;
      private string[] P006G2_A192ProfesionalesApellidoSegundo ;
      private string[] P006G2_A167ProfesionalesApellidoPrimero ;
      private string[] P006G2_A191ProfesionalesSegundoNombre ;
      private string[] P006G2_A166ProfesionalesPrimerNombre ;
      private string[] P006G3_A107EstadosTipo ;
      private int[] P006G3_A108EstadosGenericosId ;
      private long[] P006G3_A503ComisionesID ;
      private string[] P006G3_A166ProfesionalesPrimerNombre ;
      private string[] P006G3_A109EstadosGenericosNombre ;
      private string[] P006G3_A170ProfesionalesTelefono ;
      private string[] P006G3_A192ProfesionalesApellidoSegundo ;
      private string[] P006G3_A167ProfesionalesApellidoPrimero ;
      private string[] P006G3_A191ProfesionalesSegundoNombre ;
      private string[] P006G3_A120ProfesionalesId ;
      private string[] P006G4_A107EstadosTipo ;
      private int[] P006G4_A108EstadosGenericosId ;
      private long[] P006G4_A503ComisionesID ;
      private string[] P006G4_A191ProfesionalesSegundoNombre ;
      private string[] P006G4_A109EstadosGenericosNombre ;
      private string[] P006G4_A170ProfesionalesTelefono ;
      private string[] P006G4_A192ProfesionalesApellidoSegundo ;
      private string[] P006G4_A167ProfesionalesApellidoPrimero ;
      private string[] P006G4_A166ProfesionalesPrimerNombre ;
      private string[] P006G4_A120ProfesionalesId ;
      private string[] P006G5_A107EstadosTipo ;
      private int[] P006G5_A108EstadosGenericosId ;
      private long[] P006G5_A503ComisionesID ;
      private string[] P006G5_A167ProfesionalesApellidoPrimero ;
      private string[] P006G5_A109EstadosGenericosNombre ;
      private string[] P006G5_A170ProfesionalesTelefono ;
      private string[] P006G5_A192ProfesionalesApellidoSegundo ;
      private string[] P006G5_A191ProfesionalesSegundoNombre ;
      private string[] P006G5_A166ProfesionalesPrimerNombre ;
      private string[] P006G5_A120ProfesionalesId ;
      private string[] P006G6_A107EstadosTipo ;
      private int[] P006G6_A108EstadosGenericosId ;
      private long[] P006G6_A503ComisionesID ;
      private string[] P006G6_A192ProfesionalesApellidoSegundo ;
      private string[] P006G6_A109EstadosGenericosNombre ;
      private string[] P006G6_A170ProfesionalesTelefono ;
      private string[] P006G6_A167ProfesionalesApellidoPrimero ;
      private string[] P006G6_A191ProfesionalesSegundoNombre ;
      private string[] P006G6_A166ProfesionalesPrimerNombre ;
      private string[] P006G6_A120ProfesionalesId ;
      private string[] P006G7_A107EstadosTipo ;
      private int[] P006G7_A108EstadosGenericosId ;
      private long[] P006G7_A503ComisionesID ;
      private string[] P006G7_A170ProfesionalesTelefono ;
      private string[] P006G7_A109EstadosGenericosNombre ;
      private string[] P006G7_A192ProfesionalesApellidoSegundo ;
      private string[] P006G7_A167ProfesionalesApellidoPrimero ;
      private string[] P006G7_A191ProfesionalesSegundoNombre ;
      private string[] P006G7_A166ProfesionalesPrimerNombre ;
      private string[] P006G7_A120ProfesionalesId ;
      private string[] P006G8_A107EstadosTipo ;
      private int[] P006G8_A108EstadosGenericosId ;
      private long[] P006G8_A503ComisionesID ;
      private string[] P006G8_A109EstadosGenericosNombre ;
      private string[] P006G8_A170ProfesionalesTelefono ;
      private string[] P006G8_A192ProfesionalesApellidoSegundo ;
      private string[] P006G8_A167ProfesionalesApellidoPrimero ;
      private string[] P006G8_A191ProfesionalesSegundoNombre ;
      private string[] P006G8_A166ProfesionalesPrimerNombre ;
      private string[] P006G8_A120ProfesionalesId ;
      private string aP3_OptionsJson ;
      private string aP4_OptionsDescJson ;
      private string aP5_OptionIndexesJson ;
   }

   public class comisionesprofesionaleswcgetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P006G2( IGxContext context ,
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
                                             string AV24TFEstadosGenericosNombre_Sel ,
                                             string AV23TFEstadosGenericosNombre ,
                                             string A120ProfesionalesId ,
                                             string A166ProfesionalesPrimerNombre ,
                                             string A191ProfesionalesSegundoNombre ,
                                             string A167ProfesionalesApellidoPrimero ,
                                             string A192ProfesionalesApellidoSegundo ,
                                             string A170ProfesionalesTelefono ,
                                             string A109EstadosGenericosNombre ,
                                             long AV47ComisionesID ,
                                             long A503ComisionesID )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int2 = new short[15];
         Object[] GXv_Object3 = new Object[2];
         scmdbuf = "SELECT T2.[EstadosTipo], T2.[EstadosGenericosId], T1.[ProfesionalesId], T1.[ComisionesID], T3.[EstadosGenericosNombre], T2.[ProfesionalesTelefono], T2.[ProfesionalesApellidoSegundo], T2.[ProfesionalesApellidoPrimero], T2.[ProfesionalesSegundoNombre], T2.[ProfesionalesPrimerNombre] FROM (([ComisionesProfesionales] T1 INNER JOIN [Profesionales] T2 ON T2.[ProfesionalesId] = T1.[ProfesionalesId]) INNER JOIN [EstadosGenericos] T3 ON T3.[EstadosTipo] = T2.[EstadosTipo] AND T3.[EstadosGenericosId] = T2.[EstadosGenericosId])";
         AddWhere(sWhereString, "(T1.[ComisionesID] = @AV47ComisionesID)");
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV12TFProfesionalesId_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV11TFProfesionalesId)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[ProfesionalesId]) like UPPER(@lV11TFProfesionalesId))");
         }
         else
         {
            GXv_int2[1] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV12TFProfesionalesId_Sel)) && ! ( StringUtil.StrCmp(AV12TFProfesionalesId_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[ProfesionalesId] = @AV12TFProfesionalesId_Sel)");
         }
         else
         {
            GXv_int2[2] = 1;
         }
         if ( StringUtil.StrCmp(AV12TFProfesionalesId_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[ProfesionalesId] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV14TFProfesionalesPrimerNombre_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV13TFProfesionalesPrimerNombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ProfesionalesPrimerNombre]) like UPPER(@lV13TFProfesionalesPrimerNombre))");
         }
         else
         {
            GXv_int2[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV14TFProfesionalesPrimerNombre_Sel)) && ! ( StringUtil.StrCmp(AV14TFProfesionalesPrimerNombre_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.[ProfesionalesPrimerNombre] = @AV14TFProfesionalesPrimerNombre_Sel)");
         }
         else
         {
            GXv_int2[4] = 1;
         }
         if ( StringUtil.StrCmp(AV14TFProfesionalesPrimerNombre_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T2.[ProfesionalesPrimerNombre] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV16TFProfesionalesSegundoNombre_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV15TFProfesionalesSegundoNombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ProfesionalesSegundoNombre]) like UPPER(@lV15TFProfesionalesSegundoNombre))");
         }
         else
         {
            GXv_int2[5] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV16TFProfesionalesSegundoNombre_Sel)) && ! ( StringUtil.StrCmp(AV16TFProfesionalesSegundoNombre_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.[ProfesionalesSegundoNombre] = @AV16TFProfesionalesSegundoNombre_Sel)");
         }
         else
         {
            GXv_int2[6] = 1;
         }
         if ( StringUtil.StrCmp(AV16TFProfesionalesSegundoNombre_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T2.[ProfesionalesSegundoNombre] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV18TFProfesionalesApellidoPrimero_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV17TFProfesionalesApellidoPrimero)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ProfesionalesApellidoPrimero]) like UPPER(@lV17TFProfesionalesApellidoPrimero))");
         }
         else
         {
            GXv_int2[7] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV18TFProfesionalesApellidoPrimero_Sel)) && ! ( StringUtil.StrCmp(AV18TFProfesionalesApellidoPrimero_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.[ProfesionalesApellidoPrimero] = @AV18TFProfesionalesApellidoPrimero_Sel)");
         }
         else
         {
            GXv_int2[8] = 1;
         }
         if ( StringUtil.StrCmp(AV18TFProfesionalesApellidoPrimero_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T2.[ProfesionalesApellidoPrimero] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV20TFProfesionalesApellidoSegundo_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV19TFProfesionalesApellidoSegundo)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ProfesionalesApellidoSegundo]) like UPPER(@lV19TFProfesionalesApellidoSegundo))");
         }
         else
         {
            GXv_int2[9] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV20TFProfesionalesApellidoSegundo_Sel)) && ! ( StringUtil.StrCmp(AV20TFProfesionalesApellidoSegundo_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.[ProfesionalesApellidoSegundo] = @AV20TFProfesionalesApellidoSegundo_Sel)");
         }
         else
         {
            GXv_int2[10] = 1;
         }
         if ( StringUtil.StrCmp(AV20TFProfesionalesApellidoSegundo_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T2.[ProfesionalesApellidoSegundo] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV22TFProfesionalesTelefono_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV21TFProfesionalesTelefono)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ProfesionalesTelefono]) like UPPER(@lV21TFProfesionalesTelefono))");
         }
         else
         {
            GXv_int2[11] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV22TFProfesionalesTelefono_Sel)) && ! ( StringUtil.StrCmp(AV22TFProfesionalesTelefono_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.[ProfesionalesTelefono] = @AV22TFProfesionalesTelefono_Sel)");
         }
         else
         {
            GXv_int2[12] = 1;
         }
         if ( StringUtil.StrCmp(AV22TFProfesionalesTelefono_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T2.[ProfesionalesTelefono] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV24TFEstadosGenericosNombre_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV23TFEstadosGenericosNombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T3.[EstadosGenericosNombre]) like UPPER(@lV23TFEstadosGenericosNombre))");
         }
         else
         {
            GXv_int2[13] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV24TFEstadosGenericosNombre_Sel)) && ! ( StringUtil.StrCmp(AV24TFEstadosGenericosNombre_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T3.[EstadosGenericosNombre] = @AV24TFEstadosGenericosNombre_Sel)");
         }
         else
         {
            GXv_int2[14] = 1;
         }
         if ( StringUtil.StrCmp(AV24TFEstadosGenericosNombre_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T3.[EstadosGenericosNombre] = ''))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[ComisionesID], T1.[ProfesionalesId]";
         GXv_Object3[0] = scmdbuf;
         GXv_Object3[1] = GXv_int2;
         return GXv_Object3 ;
      }

      protected Object[] conditional_P006G3( IGxContext context ,
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
                                             string AV24TFEstadosGenericosNombre_Sel ,
                                             string AV23TFEstadosGenericosNombre ,
                                             string A120ProfesionalesId ,
                                             string A166ProfesionalesPrimerNombre ,
                                             string A191ProfesionalesSegundoNombre ,
                                             string A167ProfesionalesApellidoPrimero ,
                                             string A192ProfesionalesApellidoSegundo ,
                                             string A170ProfesionalesTelefono ,
                                             string A109EstadosGenericosNombre ,
                                             long AV47ComisionesID ,
                                             long A503ComisionesID )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int4 = new short[15];
         Object[] GXv_Object5 = new Object[2];
         scmdbuf = "SELECT T2.[EstadosTipo], T2.[EstadosGenericosId], T1.[ComisionesID], T2.[ProfesionalesPrimerNombre], T3.[EstadosGenericosNombre], T2.[ProfesionalesTelefono], T2.[ProfesionalesApellidoSegundo], T2.[ProfesionalesApellidoPrimero], T2.[ProfesionalesSegundoNombre], T1.[ProfesionalesId] FROM (([ComisionesProfesionales] T1 INNER JOIN [Profesionales] T2 ON T2.[ProfesionalesId] = T1.[ProfesionalesId]) INNER JOIN [EstadosGenericos] T3 ON T3.[EstadosTipo] = T2.[EstadosTipo] AND T3.[EstadosGenericosId] = T2.[EstadosGenericosId])";
         AddWhere(sWhereString, "(T1.[ComisionesID] = @AV47ComisionesID)");
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV12TFProfesionalesId_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV11TFProfesionalesId)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[ProfesionalesId]) like UPPER(@lV11TFProfesionalesId))");
         }
         else
         {
            GXv_int4[1] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV12TFProfesionalesId_Sel)) && ! ( StringUtil.StrCmp(AV12TFProfesionalesId_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[ProfesionalesId] = @AV12TFProfesionalesId_Sel)");
         }
         else
         {
            GXv_int4[2] = 1;
         }
         if ( StringUtil.StrCmp(AV12TFProfesionalesId_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[ProfesionalesId] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV14TFProfesionalesPrimerNombre_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV13TFProfesionalesPrimerNombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ProfesionalesPrimerNombre]) like UPPER(@lV13TFProfesionalesPrimerNombre))");
         }
         else
         {
            GXv_int4[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV14TFProfesionalesPrimerNombre_Sel)) && ! ( StringUtil.StrCmp(AV14TFProfesionalesPrimerNombre_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.[ProfesionalesPrimerNombre] = @AV14TFProfesionalesPrimerNombre_Sel)");
         }
         else
         {
            GXv_int4[4] = 1;
         }
         if ( StringUtil.StrCmp(AV14TFProfesionalesPrimerNombre_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T2.[ProfesionalesPrimerNombre] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV16TFProfesionalesSegundoNombre_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV15TFProfesionalesSegundoNombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ProfesionalesSegundoNombre]) like UPPER(@lV15TFProfesionalesSegundoNombre))");
         }
         else
         {
            GXv_int4[5] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV16TFProfesionalesSegundoNombre_Sel)) && ! ( StringUtil.StrCmp(AV16TFProfesionalesSegundoNombre_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.[ProfesionalesSegundoNombre] = @AV16TFProfesionalesSegundoNombre_Sel)");
         }
         else
         {
            GXv_int4[6] = 1;
         }
         if ( StringUtil.StrCmp(AV16TFProfesionalesSegundoNombre_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T2.[ProfesionalesSegundoNombre] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV18TFProfesionalesApellidoPrimero_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV17TFProfesionalesApellidoPrimero)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ProfesionalesApellidoPrimero]) like UPPER(@lV17TFProfesionalesApellidoPrimero))");
         }
         else
         {
            GXv_int4[7] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV18TFProfesionalesApellidoPrimero_Sel)) && ! ( StringUtil.StrCmp(AV18TFProfesionalesApellidoPrimero_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.[ProfesionalesApellidoPrimero] = @AV18TFProfesionalesApellidoPrimero_Sel)");
         }
         else
         {
            GXv_int4[8] = 1;
         }
         if ( StringUtil.StrCmp(AV18TFProfesionalesApellidoPrimero_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T2.[ProfesionalesApellidoPrimero] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV20TFProfesionalesApellidoSegundo_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV19TFProfesionalesApellidoSegundo)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ProfesionalesApellidoSegundo]) like UPPER(@lV19TFProfesionalesApellidoSegundo))");
         }
         else
         {
            GXv_int4[9] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV20TFProfesionalesApellidoSegundo_Sel)) && ! ( StringUtil.StrCmp(AV20TFProfesionalesApellidoSegundo_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.[ProfesionalesApellidoSegundo] = @AV20TFProfesionalesApellidoSegundo_Sel)");
         }
         else
         {
            GXv_int4[10] = 1;
         }
         if ( StringUtil.StrCmp(AV20TFProfesionalesApellidoSegundo_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T2.[ProfesionalesApellidoSegundo] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV22TFProfesionalesTelefono_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV21TFProfesionalesTelefono)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ProfesionalesTelefono]) like UPPER(@lV21TFProfesionalesTelefono))");
         }
         else
         {
            GXv_int4[11] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV22TFProfesionalesTelefono_Sel)) && ! ( StringUtil.StrCmp(AV22TFProfesionalesTelefono_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.[ProfesionalesTelefono] = @AV22TFProfesionalesTelefono_Sel)");
         }
         else
         {
            GXv_int4[12] = 1;
         }
         if ( StringUtil.StrCmp(AV22TFProfesionalesTelefono_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T2.[ProfesionalesTelefono] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV24TFEstadosGenericosNombre_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV23TFEstadosGenericosNombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T3.[EstadosGenericosNombre]) like UPPER(@lV23TFEstadosGenericosNombre))");
         }
         else
         {
            GXv_int4[13] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV24TFEstadosGenericosNombre_Sel)) && ! ( StringUtil.StrCmp(AV24TFEstadosGenericosNombre_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T3.[EstadosGenericosNombre] = @AV24TFEstadosGenericosNombre_Sel)");
         }
         else
         {
            GXv_int4[14] = 1;
         }
         if ( StringUtil.StrCmp(AV24TFEstadosGenericosNombre_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T3.[EstadosGenericosNombre] = ''))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[ComisionesID], T2.[ProfesionalesPrimerNombre]";
         GXv_Object5[0] = scmdbuf;
         GXv_Object5[1] = GXv_int4;
         return GXv_Object5 ;
      }

      protected Object[] conditional_P006G4( IGxContext context ,
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
                                             string AV24TFEstadosGenericosNombre_Sel ,
                                             string AV23TFEstadosGenericosNombre ,
                                             string A120ProfesionalesId ,
                                             string A166ProfesionalesPrimerNombre ,
                                             string A191ProfesionalesSegundoNombre ,
                                             string A167ProfesionalesApellidoPrimero ,
                                             string A192ProfesionalesApellidoSegundo ,
                                             string A170ProfesionalesTelefono ,
                                             string A109EstadosGenericosNombre ,
                                             long AV47ComisionesID ,
                                             long A503ComisionesID )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int6 = new short[15];
         Object[] GXv_Object7 = new Object[2];
         scmdbuf = "SELECT T2.[EstadosTipo], T2.[EstadosGenericosId], T1.[ComisionesID], T2.[ProfesionalesSegundoNombre], T3.[EstadosGenericosNombre], T2.[ProfesionalesTelefono], T2.[ProfesionalesApellidoSegundo], T2.[ProfesionalesApellidoPrimero], T2.[ProfesionalesPrimerNombre], T1.[ProfesionalesId] FROM (([ComisionesProfesionales] T1 INNER JOIN [Profesionales] T2 ON T2.[ProfesionalesId] = T1.[ProfesionalesId]) INNER JOIN [EstadosGenericos] T3 ON T3.[EstadosTipo] = T2.[EstadosTipo] AND T3.[EstadosGenericosId] = T2.[EstadosGenericosId])";
         AddWhere(sWhereString, "(T1.[ComisionesID] = @AV47ComisionesID)");
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV12TFProfesionalesId_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV11TFProfesionalesId)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[ProfesionalesId]) like UPPER(@lV11TFProfesionalesId))");
         }
         else
         {
            GXv_int6[1] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV12TFProfesionalesId_Sel)) && ! ( StringUtil.StrCmp(AV12TFProfesionalesId_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[ProfesionalesId] = @AV12TFProfesionalesId_Sel)");
         }
         else
         {
            GXv_int6[2] = 1;
         }
         if ( StringUtil.StrCmp(AV12TFProfesionalesId_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[ProfesionalesId] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV14TFProfesionalesPrimerNombre_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV13TFProfesionalesPrimerNombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ProfesionalesPrimerNombre]) like UPPER(@lV13TFProfesionalesPrimerNombre))");
         }
         else
         {
            GXv_int6[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV14TFProfesionalesPrimerNombre_Sel)) && ! ( StringUtil.StrCmp(AV14TFProfesionalesPrimerNombre_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.[ProfesionalesPrimerNombre] = @AV14TFProfesionalesPrimerNombre_Sel)");
         }
         else
         {
            GXv_int6[4] = 1;
         }
         if ( StringUtil.StrCmp(AV14TFProfesionalesPrimerNombre_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T2.[ProfesionalesPrimerNombre] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV16TFProfesionalesSegundoNombre_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV15TFProfesionalesSegundoNombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ProfesionalesSegundoNombre]) like UPPER(@lV15TFProfesionalesSegundoNombre))");
         }
         else
         {
            GXv_int6[5] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV16TFProfesionalesSegundoNombre_Sel)) && ! ( StringUtil.StrCmp(AV16TFProfesionalesSegundoNombre_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.[ProfesionalesSegundoNombre] = @AV16TFProfesionalesSegundoNombre_Sel)");
         }
         else
         {
            GXv_int6[6] = 1;
         }
         if ( StringUtil.StrCmp(AV16TFProfesionalesSegundoNombre_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T2.[ProfesionalesSegundoNombre] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV18TFProfesionalesApellidoPrimero_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV17TFProfesionalesApellidoPrimero)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ProfesionalesApellidoPrimero]) like UPPER(@lV17TFProfesionalesApellidoPrimero))");
         }
         else
         {
            GXv_int6[7] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV18TFProfesionalesApellidoPrimero_Sel)) && ! ( StringUtil.StrCmp(AV18TFProfesionalesApellidoPrimero_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.[ProfesionalesApellidoPrimero] = @AV18TFProfesionalesApellidoPrimero_Sel)");
         }
         else
         {
            GXv_int6[8] = 1;
         }
         if ( StringUtil.StrCmp(AV18TFProfesionalesApellidoPrimero_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T2.[ProfesionalesApellidoPrimero] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV20TFProfesionalesApellidoSegundo_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV19TFProfesionalesApellidoSegundo)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ProfesionalesApellidoSegundo]) like UPPER(@lV19TFProfesionalesApellidoSegundo))");
         }
         else
         {
            GXv_int6[9] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV20TFProfesionalesApellidoSegundo_Sel)) && ! ( StringUtil.StrCmp(AV20TFProfesionalesApellidoSegundo_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.[ProfesionalesApellidoSegundo] = @AV20TFProfesionalesApellidoSegundo_Sel)");
         }
         else
         {
            GXv_int6[10] = 1;
         }
         if ( StringUtil.StrCmp(AV20TFProfesionalesApellidoSegundo_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T2.[ProfesionalesApellidoSegundo] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV22TFProfesionalesTelefono_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV21TFProfesionalesTelefono)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ProfesionalesTelefono]) like UPPER(@lV21TFProfesionalesTelefono))");
         }
         else
         {
            GXv_int6[11] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV22TFProfesionalesTelefono_Sel)) && ! ( StringUtil.StrCmp(AV22TFProfesionalesTelefono_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.[ProfesionalesTelefono] = @AV22TFProfesionalesTelefono_Sel)");
         }
         else
         {
            GXv_int6[12] = 1;
         }
         if ( StringUtil.StrCmp(AV22TFProfesionalesTelefono_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T2.[ProfesionalesTelefono] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV24TFEstadosGenericosNombre_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV23TFEstadosGenericosNombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T3.[EstadosGenericosNombre]) like UPPER(@lV23TFEstadosGenericosNombre))");
         }
         else
         {
            GXv_int6[13] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV24TFEstadosGenericosNombre_Sel)) && ! ( StringUtil.StrCmp(AV24TFEstadosGenericosNombre_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T3.[EstadosGenericosNombre] = @AV24TFEstadosGenericosNombre_Sel)");
         }
         else
         {
            GXv_int6[14] = 1;
         }
         if ( StringUtil.StrCmp(AV24TFEstadosGenericosNombre_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T3.[EstadosGenericosNombre] = ''))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[ComisionesID], T2.[ProfesionalesSegundoNombre]";
         GXv_Object7[0] = scmdbuf;
         GXv_Object7[1] = GXv_int6;
         return GXv_Object7 ;
      }

      protected Object[] conditional_P006G5( IGxContext context ,
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
                                             string AV24TFEstadosGenericosNombre_Sel ,
                                             string AV23TFEstadosGenericosNombre ,
                                             string A120ProfesionalesId ,
                                             string A166ProfesionalesPrimerNombre ,
                                             string A191ProfesionalesSegundoNombre ,
                                             string A167ProfesionalesApellidoPrimero ,
                                             string A192ProfesionalesApellidoSegundo ,
                                             string A170ProfesionalesTelefono ,
                                             string A109EstadosGenericosNombre ,
                                             long AV47ComisionesID ,
                                             long A503ComisionesID )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int8 = new short[15];
         Object[] GXv_Object9 = new Object[2];
         scmdbuf = "SELECT T2.[EstadosTipo], T2.[EstadosGenericosId], T1.[ComisionesID], T2.[ProfesionalesApellidoPrimero], T3.[EstadosGenericosNombre], T2.[ProfesionalesTelefono], T2.[ProfesionalesApellidoSegundo], T2.[ProfesionalesSegundoNombre], T2.[ProfesionalesPrimerNombre], T1.[ProfesionalesId] FROM (([ComisionesProfesionales] T1 INNER JOIN [Profesionales] T2 ON T2.[ProfesionalesId] = T1.[ProfesionalesId]) INNER JOIN [EstadosGenericos] T3 ON T3.[EstadosTipo] = T2.[EstadosTipo] AND T3.[EstadosGenericosId] = T2.[EstadosGenericosId])";
         AddWhere(sWhereString, "(T1.[ComisionesID] = @AV47ComisionesID)");
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV12TFProfesionalesId_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV11TFProfesionalesId)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[ProfesionalesId]) like UPPER(@lV11TFProfesionalesId))");
         }
         else
         {
            GXv_int8[1] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV12TFProfesionalesId_Sel)) && ! ( StringUtil.StrCmp(AV12TFProfesionalesId_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[ProfesionalesId] = @AV12TFProfesionalesId_Sel)");
         }
         else
         {
            GXv_int8[2] = 1;
         }
         if ( StringUtil.StrCmp(AV12TFProfesionalesId_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[ProfesionalesId] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV14TFProfesionalesPrimerNombre_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV13TFProfesionalesPrimerNombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ProfesionalesPrimerNombre]) like UPPER(@lV13TFProfesionalesPrimerNombre))");
         }
         else
         {
            GXv_int8[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV14TFProfesionalesPrimerNombre_Sel)) && ! ( StringUtil.StrCmp(AV14TFProfesionalesPrimerNombre_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.[ProfesionalesPrimerNombre] = @AV14TFProfesionalesPrimerNombre_Sel)");
         }
         else
         {
            GXv_int8[4] = 1;
         }
         if ( StringUtil.StrCmp(AV14TFProfesionalesPrimerNombre_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T2.[ProfesionalesPrimerNombre] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV16TFProfesionalesSegundoNombre_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV15TFProfesionalesSegundoNombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ProfesionalesSegundoNombre]) like UPPER(@lV15TFProfesionalesSegundoNombre))");
         }
         else
         {
            GXv_int8[5] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV16TFProfesionalesSegundoNombre_Sel)) && ! ( StringUtil.StrCmp(AV16TFProfesionalesSegundoNombre_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.[ProfesionalesSegundoNombre] = @AV16TFProfesionalesSegundoNombre_Sel)");
         }
         else
         {
            GXv_int8[6] = 1;
         }
         if ( StringUtil.StrCmp(AV16TFProfesionalesSegundoNombre_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T2.[ProfesionalesSegundoNombre] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV18TFProfesionalesApellidoPrimero_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV17TFProfesionalesApellidoPrimero)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ProfesionalesApellidoPrimero]) like UPPER(@lV17TFProfesionalesApellidoPrimero))");
         }
         else
         {
            GXv_int8[7] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV18TFProfesionalesApellidoPrimero_Sel)) && ! ( StringUtil.StrCmp(AV18TFProfesionalesApellidoPrimero_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.[ProfesionalesApellidoPrimero] = @AV18TFProfesionalesApellidoPrimero_Sel)");
         }
         else
         {
            GXv_int8[8] = 1;
         }
         if ( StringUtil.StrCmp(AV18TFProfesionalesApellidoPrimero_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T2.[ProfesionalesApellidoPrimero] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV20TFProfesionalesApellidoSegundo_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV19TFProfesionalesApellidoSegundo)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ProfesionalesApellidoSegundo]) like UPPER(@lV19TFProfesionalesApellidoSegundo))");
         }
         else
         {
            GXv_int8[9] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV20TFProfesionalesApellidoSegundo_Sel)) && ! ( StringUtil.StrCmp(AV20TFProfesionalesApellidoSegundo_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.[ProfesionalesApellidoSegundo] = @AV20TFProfesionalesApellidoSegundo_Sel)");
         }
         else
         {
            GXv_int8[10] = 1;
         }
         if ( StringUtil.StrCmp(AV20TFProfesionalesApellidoSegundo_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T2.[ProfesionalesApellidoSegundo] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV22TFProfesionalesTelefono_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV21TFProfesionalesTelefono)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ProfesionalesTelefono]) like UPPER(@lV21TFProfesionalesTelefono))");
         }
         else
         {
            GXv_int8[11] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV22TFProfesionalesTelefono_Sel)) && ! ( StringUtil.StrCmp(AV22TFProfesionalesTelefono_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.[ProfesionalesTelefono] = @AV22TFProfesionalesTelefono_Sel)");
         }
         else
         {
            GXv_int8[12] = 1;
         }
         if ( StringUtil.StrCmp(AV22TFProfesionalesTelefono_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T2.[ProfesionalesTelefono] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV24TFEstadosGenericosNombre_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV23TFEstadosGenericosNombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T3.[EstadosGenericosNombre]) like UPPER(@lV23TFEstadosGenericosNombre))");
         }
         else
         {
            GXv_int8[13] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV24TFEstadosGenericosNombre_Sel)) && ! ( StringUtil.StrCmp(AV24TFEstadosGenericosNombre_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T3.[EstadosGenericosNombre] = @AV24TFEstadosGenericosNombre_Sel)");
         }
         else
         {
            GXv_int8[14] = 1;
         }
         if ( StringUtil.StrCmp(AV24TFEstadosGenericosNombre_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T3.[EstadosGenericosNombre] = ''))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[ComisionesID], T2.[ProfesionalesApellidoPrimero]";
         GXv_Object9[0] = scmdbuf;
         GXv_Object9[1] = GXv_int8;
         return GXv_Object9 ;
      }

      protected Object[] conditional_P006G6( IGxContext context ,
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
                                             string AV24TFEstadosGenericosNombre_Sel ,
                                             string AV23TFEstadosGenericosNombre ,
                                             string A120ProfesionalesId ,
                                             string A166ProfesionalesPrimerNombre ,
                                             string A191ProfesionalesSegundoNombre ,
                                             string A167ProfesionalesApellidoPrimero ,
                                             string A192ProfesionalesApellidoSegundo ,
                                             string A170ProfesionalesTelefono ,
                                             string A109EstadosGenericosNombre ,
                                             long AV47ComisionesID ,
                                             long A503ComisionesID )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int10 = new short[15];
         Object[] GXv_Object11 = new Object[2];
         scmdbuf = "SELECT T2.[EstadosTipo], T2.[EstadosGenericosId], T1.[ComisionesID], T2.[ProfesionalesApellidoSegundo], T3.[EstadosGenericosNombre], T2.[ProfesionalesTelefono], T2.[ProfesionalesApellidoPrimero], T2.[ProfesionalesSegundoNombre], T2.[ProfesionalesPrimerNombre], T1.[ProfesionalesId] FROM (([ComisionesProfesionales] T1 INNER JOIN [Profesionales] T2 ON T2.[ProfesionalesId] = T1.[ProfesionalesId]) INNER JOIN [EstadosGenericos] T3 ON T3.[EstadosTipo] = T2.[EstadosTipo] AND T3.[EstadosGenericosId] = T2.[EstadosGenericosId])";
         AddWhere(sWhereString, "(T1.[ComisionesID] = @AV47ComisionesID)");
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV12TFProfesionalesId_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV11TFProfesionalesId)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[ProfesionalesId]) like UPPER(@lV11TFProfesionalesId))");
         }
         else
         {
            GXv_int10[1] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV12TFProfesionalesId_Sel)) && ! ( StringUtil.StrCmp(AV12TFProfesionalesId_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[ProfesionalesId] = @AV12TFProfesionalesId_Sel)");
         }
         else
         {
            GXv_int10[2] = 1;
         }
         if ( StringUtil.StrCmp(AV12TFProfesionalesId_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[ProfesionalesId] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV14TFProfesionalesPrimerNombre_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV13TFProfesionalesPrimerNombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ProfesionalesPrimerNombre]) like UPPER(@lV13TFProfesionalesPrimerNombre))");
         }
         else
         {
            GXv_int10[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV14TFProfesionalesPrimerNombre_Sel)) && ! ( StringUtil.StrCmp(AV14TFProfesionalesPrimerNombre_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.[ProfesionalesPrimerNombre] = @AV14TFProfesionalesPrimerNombre_Sel)");
         }
         else
         {
            GXv_int10[4] = 1;
         }
         if ( StringUtil.StrCmp(AV14TFProfesionalesPrimerNombre_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T2.[ProfesionalesPrimerNombre] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV16TFProfesionalesSegundoNombre_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV15TFProfesionalesSegundoNombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ProfesionalesSegundoNombre]) like UPPER(@lV15TFProfesionalesSegundoNombre))");
         }
         else
         {
            GXv_int10[5] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV16TFProfesionalesSegundoNombre_Sel)) && ! ( StringUtil.StrCmp(AV16TFProfesionalesSegundoNombre_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.[ProfesionalesSegundoNombre] = @AV16TFProfesionalesSegundoNombre_Sel)");
         }
         else
         {
            GXv_int10[6] = 1;
         }
         if ( StringUtil.StrCmp(AV16TFProfesionalesSegundoNombre_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T2.[ProfesionalesSegundoNombre] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV18TFProfesionalesApellidoPrimero_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV17TFProfesionalesApellidoPrimero)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ProfesionalesApellidoPrimero]) like UPPER(@lV17TFProfesionalesApellidoPrimero))");
         }
         else
         {
            GXv_int10[7] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV18TFProfesionalesApellidoPrimero_Sel)) && ! ( StringUtil.StrCmp(AV18TFProfesionalesApellidoPrimero_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.[ProfesionalesApellidoPrimero] = @AV18TFProfesionalesApellidoPrimero_Sel)");
         }
         else
         {
            GXv_int10[8] = 1;
         }
         if ( StringUtil.StrCmp(AV18TFProfesionalesApellidoPrimero_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T2.[ProfesionalesApellidoPrimero] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV20TFProfesionalesApellidoSegundo_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV19TFProfesionalesApellidoSegundo)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ProfesionalesApellidoSegundo]) like UPPER(@lV19TFProfesionalesApellidoSegundo))");
         }
         else
         {
            GXv_int10[9] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV20TFProfesionalesApellidoSegundo_Sel)) && ! ( StringUtil.StrCmp(AV20TFProfesionalesApellidoSegundo_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.[ProfesionalesApellidoSegundo] = @AV20TFProfesionalesApellidoSegundo_Sel)");
         }
         else
         {
            GXv_int10[10] = 1;
         }
         if ( StringUtil.StrCmp(AV20TFProfesionalesApellidoSegundo_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T2.[ProfesionalesApellidoSegundo] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV22TFProfesionalesTelefono_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV21TFProfesionalesTelefono)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ProfesionalesTelefono]) like UPPER(@lV21TFProfesionalesTelefono))");
         }
         else
         {
            GXv_int10[11] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV22TFProfesionalesTelefono_Sel)) && ! ( StringUtil.StrCmp(AV22TFProfesionalesTelefono_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.[ProfesionalesTelefono] = @AV22TFProfesionalesTelefono_Sel)");
         }
         else
         {
            GXv_int10[12] = 1;
         }
         if ( StringUtil.StrCmp(AV22TFProfesionalesTelefono_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T2.[ProfesionalesTelefono] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV24TFEstadosGenericosNombre_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV23TFEstadosGenericosNombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T3.[EstadosGenericosNombre]) like UPPER(@lV23TFEstadosGenericosNombre))");
         }
         else
         {
            GXv_int10[13] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV24TFEstadosGenericosNombre_Sel)) && ! ( StringUtil.StrCmp(AV24TFEstadosGenericosNombre_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T3.[EstadosGenericosNombre] = @AV24TFEstadosGenericosNombre_Sel)");
         }
         else
         {
            GXv_int10[14] = 1;
         }
         if ( StringUtil.StrCmp(AV24TFEstadosGenericosNombre_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T3.[EstadosGenericosNombre] = ''))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[ComisionesID], T2.[ProfesionalesApellidoSegundo]";
         GXv_Object11[0] = scmdbuf;
         GXv_Object11[1] = GXv_int10;
         return GXv_Object11 ;
      }

      protected Object[] conditional_P006G7( IGxContext context ,
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
                                             string AV24TFEstadosGenericosNombre_Sel ,
                                             string AV23TFEstadosGenericosNombre ,
                                             string A120ProfesionalesId ,
                                             string A166ProfesionalesPrimerNombre ,
                                             string A191ProfesionalesSegundoNombre ,
                                             string A167ProfesionalesApellidoPrimero ,
                                             string A192ProfesionalesApellidoSegundo ,
                                             string A170ProfesionalesTelefono ,
                                             string A109EstadosGenericosNombre ,
                                             long AV47ComisionesID ,
                                             long A503ComisionesID )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int12 = new short[15];
         Object[] GXv_Object13 = new Object[2];
         scmdbuf = "SELECT T2.[EstadosTipo], T2.[EstadosGenericosId], T1.[ComisionesID], T2.[ProfesionalesTelefono], T3.[EstadosGenericosNombre], T2.[ProfesionalesApellidoSegundo], T2.[ProfesionalesApellidoPrimero], T2.[ProfesionalesSegundoNombre], T2.[ProfesionalesPrimerNombre], T1.[ProfesionalesId] FROM (([ComisionesProfesionales] T1 INNER JOIN [Profesionales] T2 ON T2.[ProfesionalesId] = T1.[ProfesionalesId]) INNER JOIN [EstadosGenericos] T3 ON T3.[EstadosTipo] = T2.[EstadosTipo] AND T3.[EstadosGenericosId] = T2.[EstadosGenericosId])";
         AddWhere(sWhereString, "(T1.[ComisionesID] = @AV47ComisionesID)");
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV12TFProfesionalesId_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV11TFProfesionalesId)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[ProfesionalesId]) like UPPER(@lV11TFProfesionalesId))");
         }
         else
         {
            GXv_int12[1] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV12TFProfesionalesId_Sel)) && ! ( StringUtil.StrCmp(AV12TFProfesionalesId_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[ProfesionalesId] = @AV12TFProfesionalesId_Sel)");
         }
         else
         {
            GXv_int12[2] = 1;
         }
         if ( StringUtil.StrCmp(AV12TFProfesionalesId_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[ProfesionalesId] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV14TFProfesionalesPrimerNombre_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV13TFProfesionalesPrimerNombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ProfesionalesPrimerNombre]) like UPPER(@lV13TFProfesionalesPrimerNombre))");
         }
         else
         {
            GXv_int12[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV14TFProfesionalesPrimerNombre_Sel)) && ! ( StringUtil.StrCmp(AV14TFProfesionalesPrimerNombre_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.[ProfesionalesPrimerNombre] = @AV14TFProfesionalesPrimerNombre_Sel)");
         }
         else
         {
            GXv_int12[4] = 1;
         }
         if ( StringUtil.StrCmp(AV14TFProfesionalesPrimerNombre_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T2.[ProfesionalesPrimerNombre] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV16TFProfesionalesSegundoNombre_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV15TFProfesionalesSegundoNombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ProfesionalesSegundoNombre]) like UPPER(@lV15TFProfesionalesSegundoNombre))");
         }
         else
         {
            GXv_int12[5] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV16TFProfesionalesSegundoNombre_Sel)) && ! ( StringUtil.StrCmp(AV16TFProfesionalesSegundoNombre_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.[ProfesionalesSegundoNombre] = @AV16TFProfesionalesSegundoNombre_Sel)");
         }
         else
         {
            GXv_int12[6] = 1;
         }
         if ( StringUtil.StrCmp(AV16TFProfesionalesSegundoNombre_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T2.[ProfesionalesSegundoNombre] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV18TFProfesionalesApellidoPrimero_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV17TFProfesionalesApellidoPrimero)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ProfesionalesApellidoPrimero]) like UPPER(@lV17TFProfesionalesApellidoPrimero))");
         }
         else
         {
            GXv_int12[7] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV18TFProfesionalesApellidoPrimero_Sel)) && ! ( StringUtil.StrCmp(AV18TFProfesionalesApellidoPrimero_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.[ProfesionalesApellidoPrimero] = @AV18TFProfesionalesApellidoPrimero_Sel)");
         }
         else
         {
            GXv_int12[8] = 1;
         }
         if ( StringUtil.StrCmp(AV18TFProfesionalesApellidoPrimero_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T2.[ProfesionalesApellidoPrimero] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV20TFProfesionalesApellidoSegundo_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV19TFProfesionalesApellidoSegundo)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ProfesionalesApellidoSegundo]) like UPPER(@lV19TFProfesionalesApellidoSegundo))");
         }
         else
         {
            GXv_int12[9] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV20TFProfesionalesApellidoSegundo_Sel)) && ! ( StringUtil.StrCmp(AV20TFProfesionalesApellidoSegundo_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.[ProfesionalesApellidoSegundo] = @AV20TFProfesionalesApellidoSegundo_Sel)");
         }
         else
         {
            GXv_int12[10] = 1;
         }
         if ( StringUtil.StrCmp(AV20TFProfesionalesApellidoSegundo_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T2.[ProfesionalesApellidoSegundo] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV22TFProfesionalesTelefono_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV21TFProfesionalesTelefono)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ProfesionalesTelefono]) like UPPER(@lV21TFProfesionalesTelefono))");
         }
         else
         {
            GXv_int12[11] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV22TFProfesionalesTelefono_Sel)) && ! ( StringUtil.StrCmp(AV22TFProfesionalesTelefono_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.[ProfesionalesTelefono] = @AV22TFProfesionalesTelefono_Sel)");
         }
         else
         {
            GXv_int12[12] = 1;
         }
         if ( StringUtil.StrCmp(AV22TFProfesionalesTelefono_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T2.[ProfesionalesTelefono] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV24TFEstadosGenericosNombre_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV23TFEstadosGenericosNombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T3.[EstadosGenericosNombre]) like UPPER(@lV23TFEstadosGenericosNombre))");
         }
         else
         {
            GXv_int12[13] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV24TFEstadosGenericosNombre_Sel)) && ! ( StringUtil.StrCmp(AV24TFEstadosGenericosNombre_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T3.[EstadosGenericosNombre] = @AV24TFEstadosGenericosNombre_Sel)");
         }
         else
         {
            GXv_int12[14] = 1;
         }
         if ( StringUtil.StrCmp(AV24TFEstadosGenericosNombre_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T3.[EstadosGenericosNombre] = ''))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[ComisionesID], T2.[ProfesionalesTelefono]";
         GXv_Object13[0] = scmdbuf;
         GXv_Object13[1] = GXv_int12;
         return GXv_Object13 ;
      }

      protected Object[] conditional_P006G8( IGxContext context ,
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
                                             string AV24TFEstadosGenericosNombre_Sel ,
                                             string AV23TFEstadosGenericosNombre ,
                                             string A120ProfesionalesId ,
                                             string A166ProfesionalesPrimerNombre ,
                                             string A191ProfesionalesSegundoNombre ,
                                             string A167ProfesionalesApellidoPrimero ,
                                             string A192ProfesionalesApellidoSegundo ,
                                             string A170ProfesionalesTelefono ,
                                             string A109EstadosGenericosNombre ,
                                             long AV47ComisionesID ,
                                             long A503ComisionesID )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int14 = new short[15];
         Object[] GXv_Object15 = new Object[2];
         scmdbuf = "SELECT T2.[EstadosTipo], T2.[EstadosGenericosId], T1.[ComisionesID], T3.[EstadosGenericosNombre], T2.[ProfesionalesTelefono], T2.[ProfesionalesApellidoSegundo], T2.[ProfesionalesApellidoPrimero], T2.[ProfesionalesSegundoNombre], T2.[ProfesionalesPrimerNombre], T1.[ProfesionalesId] FROM (([ComisionesProfesionales] T1 INNER JOIN [Profesionales] T2 ON T2.[ProfesionalesId] = T1.[ProfesionalesId]) INNER JOIN [EstadosGenericos] T3 ON T3.[EstadosTipo] = T2.[EstadosTipo] AND T3.[EstadosGenericosId] = T2.[EstadosGenericosId])";
         AddWhere(sWhereString, "(T1.[ComisionesID] = @AV47ComisionesID)");
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV12TFProfesionalesId_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV11TFProfesionalesId)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[ProfesionalesId]) like UPPER(@lV11TFProfesionalesId))");
         }
         else
         {
            GXv_int14[1] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV12TFProfesionalesId_Sel)) && ! ( StringUtil.StrCmp(AV12TFProfesionalesId_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[ProfesionalesId] = @AV12TFProfesionalesId_Sel)");
         }
         else
         {
            GXv_int14[2] = 1;
         }
         if ( StringUtil.StrCmp(AV12TFProfesionalesId_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[ProfesionalesId] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV14TFProfesionalesPrimerNombre_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV13TFProfesionalesPrimerNombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ProfesionalesPrimerNombre]) like UPPER(@lV13TFProfesionalesPrimerNombre))");
         }
         else
         {
            GXv_int14[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV14TFProfesionalesPrimerNombre_Sel)) && ! ( StringUtil.StrCmp(AV14TFProfesionalesPrimerNombre_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.[ProfesionalesPrimerNombre] = @AV14TFProfesionalesPrimerNombre_Sel)");
         }
         else
         {
            GXv_int14[4] = 1;
         }
         if ( StringUtil.StrCmp(AV14TFProfesionalesPrimerNombre_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T2.[ProfesionalesPrimerNombre] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV16TFProfesionalesSegundoNombre_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV15TFProfesionalesSegundoNombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ProfesionalesSegundoNombre]) like UPPER(@lV15TFProfesionalesSegundoNombre))");
         }
         else
         {
            GXv_int14[5] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV16TFProfesionalesSegundoNombre_Sel)) && ! ( StringUtil.StrCmp(AV16TFProfesionalesSegundoNombre_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.[ProfesionalesSegundoNombre] = @AV16TFProfesionalesSegundoNombre_Sel)");
         }
         else
         {
            GXv_int14[6] = 1;
         }
         if ( StringUtil.StrCmp(AV16TFProfesionalesSegundoNombre_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T2.[ProfesionalesSegundoNombre] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV18TFProfesionalesApellidoPrimero_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV17TFProfesionalesApellidoPrimero)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ProfesionalesApellidoPrimero]) like UPPER(@lV17TFProfesionalesApellidoPrimero))");
         }
         else
         {
            GXv_int14[7] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV18TFProfesionalesApellidoPrimero_Sel)) && ! ( StringUtil.StrCmp(AV18TFProfesionalesApellidoPrimero_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.[ProfesionalesApellidoPrimero] = @AV18TFProfesionalesApellidoPrimero_Sel)");
         }
         else
         {
            GXv_int14[8] = 1;
         }
         if ( StringUtil.StrCmp(AV18TFProfesionalesApellidoPrimero_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T2.[ProfesionalesApellidoPrimero] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV20TFProfesionalesApellidoSegundo_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV19TFProfesionalesApellidoSegundo)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ProfesionalesApellidoSegundo]) like UPPER(@lV19TFProfesionalesApellidoSegundo))");
         }
         else
         {
            GXv_int14[9] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV20TFProfesionalesApellidoSegundo_Sel)) && ! ( StringUtil.StrCmp(AV20TFProfesionalesApellidoSegundo_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.[ProfesionalesApellidoSegundo] = @AV20TFProfesionalesApellidoSegundo_Sel)");
         }
         else
         {
            GXv_int14[10] = 1;
         }
         if ( StringUtil.StrCmp(AV20TFProfesionalesApellidoSegundo_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T2.[ProfesionalesApellidoSegundo] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV22TFProfesionalesTelefono_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV21TFProfesionalesTelefono)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ProfesionalesTelefono]) like UPPER(@lV21TFProfesionalesTelefono))");
         }
         else
         {
            GXv_int14[11] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV22TFProfesionalesTelefono_Sel)) && ! ( StringUtil.StrCmp(AV22TFProfesionalesTelefono_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.[ProfesionalesTelefono] = @AV22TFProfesionalesTelefono_Sel)");
         }
         else
         {
            GXv_int14[12] = 1;
         }
         if ( StringUtil.StrCmp(AV22TFProfesionalesTelefono_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T2.[ProfesionalesTelefono] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV24TFEstadosGenericosNombre_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV23TFEstadosGenericosNombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T3.[EstadosGenericosNombre]) like UPPER(@lV23TFEstadosGenericosNombre))");
         }
         else
         {
            GXv_int14[13] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV24TFEstadosGenericosNombre_Sel)) && ! ( StringUtil.StrCmp(AV24TFEstadosGenericosNombre_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T3.[EstadosGenericosNombre] = @AV24TFEstadosGenericosNombre_Sel)");
         }
         else
         {
            GXv_int14[14] = 1;
         }
         if ( StringUtil.StrCmp(AV24TFEstadosGenericosNombre_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T3.[EstadosGenericosNombre] = ''))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[ComisionesID], T3.[EstadosGenericosNombre]";
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
                     return conditional_P006G2(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (long)dynConstraints[21] , (long)dynConstraints[22] );
               case 1 :
                     return conditional_P006G3(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (long)dynConstraints[21] , (long)dynConstraints[22] );
               case 2 :
                     return conditional_P006G4(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (long)dynConstraints[21] , (long)dynConstraints[22] );
               case 3 :
                     return conditional_P006G5(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (long)dynConstraints[21] , (long)dynConstraints[22] );
               case 4 :
                     return conditional_P006G6(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (long)dynConstraints[21] , (long)dynConstraints[22] );
               case 5 :
                     return conditional_P006G7(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (long)dynConstraints[21] , (long)dynConstraints[22] );
               case 6 :
                     return conditional_P006G8(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (long)dynConstraints[21] , (long)dynConstraints[22] );
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
          Object[] prmP006G2;
          prmP006G2 = new Object[] {
          new ParDef("@AV47ComisionesID",GXType.Decimal,18,0) ,
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
          new ParDef("@lV23TFEstadosGenericosNombre",GXType.Char,80,0) ,
          new ParDef("@AV24TFEstadosGenericosNombre_Sel",GXType.NChar,80,0)
          };
          Object[] prmP006G3;
          prmP006G3 = new Object[] {
          new ParDef("@AV47ComisionesID",GXType.Decimal,18,0) ,
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
          new ParDef("@lV23TFEstadosGenericosNombre",GXType.Char,80,0) ,
          new ParDef("@AV24TFEstadosGenericosNombre_Sel",GXType.NChar,80,0)
          };
          Object[] prmP006G4;
          prmP006G4 = new Object[] {
          new ParDef("@AV47ComisionesID",GXType.Decimal,18,0) ,
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
          new ParDef("@lV23TFEstadosGenericosNombre",GXType.Char,80,0) ,
          new ParDef("@AV24TFEstadosGenericosNombre_Sel",GXType.NChar,80,0)
          };
          Object[] prmP006G5;
          prmP006G5 = new Object[] {
          new ParDef("@AV47ComisionesID",GXType.Decimal,18,0) ,
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
          new ParDef("@lV23TFEstadosGenericosNombre",GXType.Char,80,0) ,
          new ParDef("@AV24TFEstadosGenericosNombre_Sel",GXType.NChar,80,0)
          };
          Object[] prmP006G6;
          prmP006G6 = new Object[] {
          new ParDef("@AV47ComisionesID",GXType.Decimal,18,0) ,
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
          new ParDef("@lV23TFEstadosGenericosNombre",GXType.Char,80,0) ,
          new ParDef("@AV24TFEstadosGenericosNombre_Sel",GXType.NChar,80,0)
          };
          Object[] prmP006G7;
          prmP006G7 = new Object[] {
          new ParDef("@AV47ComisionesID",GXType.Decimal,18,0) ,
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
          new ParDef("@lV23TFEstadosGenericosNombre",GXType.Char,80,0) ,
          new ParDef("@AV24TFEstadosGenericosNombre_Sel",GXType.NChar,80,0)
          };
          Object[] prmP006G8;
          prmP006G8 = new Object[] {
          new ParDef("@AV47ComisionesID",GXType.Decimal,18,0) ,
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
          new ParDef("@lV23TFEstadosGenericosNombre",GXType.Char,80,0) ,
          new ParDef("@AV24TFEstadosGenericosNombre_Sel",GXType.NChar,80,0)
          };
          def= new CursorDef[] {
              new CursorDef("P006G2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP006G2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P006G3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP006G3,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P006G4", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP006G4,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P006G5", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP006G5,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P006G6", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP006G6,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P006G7", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP006G7,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P006G8", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP006G8,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[0])[0] = rslt.getString(1, 3);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 20);
                ((long[]) buf[3])[0] = rslt.getLong(4);
                ((string[]) buf[4])[0] = rslt.getString(5, 80);
                ((string[]) buf[5])[0] = rslt.getString(6, 20);
                ((string[]) buf[6])[0] = rslt.getString(7, 30);
                ((string[]) buf[7])[0] = rslt.getString(8, 30);
                ((string[]) buf[8])[0] = rslt.getString(9, 30);
                ((string[]) buf[9])[0] = rslt.getString(10, 30);
                return;
             case 1 :
                ((string[]) buf[0])[0] = rslt.getString(1, 3);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((long[]) buf[2])[0] = rslt.getLong(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 30);
                ((string[]) buf[4])[0] = rslt.getString(5, 80);
                ((string[]) buf[5])[0] = rslt.getString(6, 20);
                ((string[]) buf[6])[0] = rslt.getString(7, 30);
                ((string[]) buf[7])[0] = rslt.getString(8, 30);
                ((string[]) buf[8])[0] = rslt.getString(9, 30);
                ((string[]) buf[9])[0] = rslt.getString(10, 20);
                return;
             case 2 :
                ((string[]) buf[0])[0] = rslt.getString(1, 3);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((long[]) buf[2])[0] = rslt.getLong(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 30);
                ((string[]) buf[4])[0] = rslt.getString(5, 80);
                ((string[]) buf[5])[0] = rslt.getString(6, 20);
                ((string[]) buf[6])[0] = rslt.getString(7, 30);
                ((string[]) buf[7])[0] = rslt.getString(8, 30);
                ((string[]) buf[8])[0] = rslt.getString(9, 30);
                ((string[]) buf[9])[0] = rslt.getString(10, 20);
                return;
             case 3 :
                ((string[]) buf[0])[0] = rslt.getString(1, 3);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((long[]) buf[2])[0] = rslt.getLong(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 30);
                ((string[]) buf[4])[0] = rslt.getString(5, 80);
                ((string[]) buf[5])[0] = rslt.getString(6, 20);
                ((string[]) buf[6])[0] = rslt.getString(7, 30);
                ((string[]) buf[7])[0] = rslt.getString(8, 30);
                ((string[]) buf[8])[0] = rslt.getString(9, 30);
                ((string[]) buf[9])[0] = rslt.getString(10, 20);
                return;
             case 4 :
                ((string[]) buf[0])[0] = rslt.getString(1, 3);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((long[]) buf[2])[0] = rslt.getLong(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 30);
                ((string[]) buf[4])[0] = rslt.getString(5, 80);
                ((string[]) buf[5])[0] = rslt.getString(6, 20);
                ((string[]) buf[6])[0] = rslt.getString(7, 30);
                ((string[]) buf[7])[0] = rslt.getString(8, 30);
                ((string[]) buf[8])[0] = rslt.getString(9, 30);
                ((string[]) buf[9])[0] = rslt.getString(10, 20);
                return;
             case 5 :
                ((string[]) buf[0])[0] = rslt.getString(1, 3);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((long[]) buf[2])[0] = rslt.getLong(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 20);
                ((string[]) buf[4])[0] = rslt.getString(5, 80);
                ((string[]) buf[5])[0] = rslt.getString(6, 30);
                ((string[]) buf[6])[0] = rslt.getString(7, 30);
                ((string[]) buf[7])[0] = rslt.getString(8, 30);
                ((string[]) buf[8])[0] = rslt.getString(9, 30);
                ((string[]) buf[9])[0] = rslt.getString(10, 20);
                return;
             case 6 :
                ((string[]) buf[0])[0] = rslt.getString(1, 3);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((long[]) buf[2])[0] = rslt.getLong(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 80);
                ((string[]) buf[4])[0] = rslt.getString(5, 20);
                ((string[]) buf[5])[0] = rslt.getString(6, 30);
                ((string[]) buf[6])[0] = rslt.getString(7, 30);
                ((string[]) buf[7])[0] = rslt.getString(8, 30);
                ((string[]) buf[8])[0] = rslt.getString(9, 30);
                ((string[]) buf[9])[0] = rslt.getString(10, 20);
                return;
       }
    }

 }

 [ServiceContract(Namespace = "GeneXus.Programs.comisionesprofesionaleswcgetfilterdata_services")]
 [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple)]
 [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
 public class comisionesprofesionaleswcgetfilterdata_services : GxRestService
 {
    [OperationContract(Name = "ComisionesProfesionalesWCGetFilterData" )]
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
          if ( ! ProcessHeaders("comisionesprofesionaleswcgetfilterdata") )
          {
             return  ;
          }
          comisionesprofesionaleswcgetfilterdata worker = new comisionesprofesionaleswcgetfilterdata(context);
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

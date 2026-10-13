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
   public class rubrosrubroswcgetfilterdata : GXProcedure
   {
      public rubrosrubroswcgetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public rubrosrubroswcgetfilterdata( IGxContext context )
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
         this.AV53DDOName = aP0_DDOName;
         this.AV54SearchTxtParms = aP1_SearchTxtParms;
         this.AV55SearchTxtTo = aP2_SearchTxtTo;
         this.AV56OptionsJson = "" ;
         this.AV57OptionsDescJson = "" ;
         this.AV58OptionIndexesJson = "" ;
         initialize();
         ExecutePrivate();
         aP3_OptionsJson=this.AV56OptionsJson;
         aP4_OptionsDescJson=this.AV57OptionsDescJson;
         aP5_OptionIndexesJson=this.AV58OptionIndexesJson;
      }

      public string executeUdp( string aP0_DDOName ,
                                string aP1_SearchTxtParms ,
                                string aP2_SearchTxtTo ,
                                out string aP3_OptionsJson ,
                                out string aP4_OptionsDescJson )
      {
         execute(aP0_DDOName, aP1_SearchTxtParms, aP2_SearchTxtTo, out aP3_OptionsJson, out aP4_OptionsDescJson, out aP5_OptionIndexesJson);
         return AV58OptionIndexesJson ;
      }

      public void executeSubmit( string aP0_DDOName ,
                                 string aP1_SearchTxtParms ,
                                 string aP2_SearchTxtTo ,
                                 out string aP3_OptionsJson ,
                                 out string aP4_OptionsDescJson ,
                                 out string aP5_OptionIndexesJson )
      {
         this.AV53DDOName = aP0_DDOName;
         this.AV54SearchTxtParms = aP1_SearchTxtParms;
         this.AV55SearchTxtTo = aP2_SearchTxtTo;
         this.AV56OptionsJson = "" ;
         this.AV57OptionsDescJson = "" ;
         this.AV58OptionIndexesJson = "" ;
         SubmitImpl();
         aP3_OptionsJson=this.AV56OptionsJson;
         aP4_OptionsDescJson=this.AV57OptionsDescJson;
         aP5_OptionIndexesJson=this.AV58OptionIndexesJson;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV43Options = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV45OptionsDesc = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV46OptionIndexes = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         GXt_boolean1 = AV8IsAuthorized;
         new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWProfesionales", out  GXt_boolean1) ;
         AV8IsAuthorized = GXt_boolean1;
         if ( AV8IsAuthorized )
         {
            AV40MaxItems = 10;
            AV39PageIndex = (short)((String.IsNullOrEmpty(StringUtil.RTrim( AV54SearchTxtParms)) ? 0 : (long)(Math.Round(NumberUtil.Val( StringUtil.Substring( AV54SearchTxtParms, 1, 2), "."), 18, MidpointRounding.ToEven))));
            AV37SearchTxt = (String.IsNullOrEmpty(StringUtil.RTrim( AV54SearchTxtParms)) ? "" : StringUtil.Substring( AV54SearchTxtParms, 3, -1));
            AV38SkipItems = (short)(AV39PageIndex*AV40MaxItems);
            new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV9WWPContext) ;
            /* Execute user subroutine: 'LOADGRIDSTATE' */
            S111 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
            if ( StringUtil.StrCmp(StringUtil.Upper( AV53DDOName), "DDO_PROFESIONALESID") == 0 )
            {
               /* Execute user subroutine: 'LOADPROFESIONALESIDOPTIONS' */
               S121 ();
               if ( returnInSub )
               {
                  cleanup();
                  if (true) return;
               }
            }
            else if ( StringUtil.StrCmp(StringUtil.Upper( AV53DDOName), "DDO_PROFESIONALESPRIMERNOMBRE") == 0 )
            {
               /* Execute user subroutine: 'LOADPROFESIONALESPRIMERNOMBREOPTIONS' */
               S131 ();
               if ( returnInSub )
               {
                  cleanup();
                  if (true) return;
               }
            }
            else if ( StringUtil.StrCmp(StringUtil.Upper( AV53DDOName), "DDO_PROFESIONALESSEGUNDONOMBRE") == 0 )
            {
               /* Execute user subroutine: 'LOADPROFESIONALESSEGUNDONOMBREOPTIONS' */
               S141 ();
               if ( returnInSub )
               {
                  cleanup();
                  if (true) return;
               }
            }
            else if ( StringUtil.StrCmp(StringUtil.Upper( AV53DDOName), "DDO_PROFESIONALESAPELLIDOPRIMERO") == 0 )
            {
               /* Execute user subroutine: 'LOADPROFESIONALESAPELLIDOPRIMEROOPTIONS' */
               S151 ();
               if ( returnInSub )
               {
                  cleanup();
                  if (true) return;
               }
            }
            else if ( StringUtil.StrCmp(StringUtil.Upper( AV53DDOName), "DDO_PROFESIONALESAPELLIDOSEGUNDO") == 0 )
            {
               /* Execute user subroutine: 'LOADPROFESIONALESAPELLIDOSEGUNDOOPTIONS' */
               S161 ();
               if ( returnInSub )
               {
                  cleanup();
                  if (true) return;
               }
            }
            else if ( StringUtil.StrCmp(StringUtil.Upper( AV53DDOName), "DDO_PROFESIONALESTELEFONO") == 0 )
            {
               /* Execute user subroutine: 'LOADPROFESIONALESTELEFONOOPTIONS' */
               S171 ();
               if ( returnInSub )
               {
                  cleanup();
                  if (true) return;
               }
            }
            else if ( StringUtil.StrCmp(StringUtil.Upper( AV53DDOName), "DDO_PROFESIONALESEMAIL") == 0 )
            {
               /* Execute user subroutine: 'LOADPROFESIONALESEMAILOPTIONS' */
               S181 ();
               if ( returnInSub )
               {
                  cleanup();
                  if (true) return;
               }
            }
            else if ( StringUtil.StrCmp(StringUtil.Upper( AV53DDOName), "DDO_PROFESIONALESDIRECCION") == 0 )
            {
               /* Execute user subroutine: 'LOADPROFESIONALESDIRECCIONOPTIONS' */
               S191 ();
               if ( returnInSub )
               {
                  cleanup();
                  if (true) return;
               }
            }
         }
         AV56OptionsJson = AV43Options.ToJSonString(false);
         AV57OptionsDescJson = AV45OptionsDesc.ToJSonString(false);
         AV58OptionIndexesJson = AV46OptionIndexes.ToJSonString(false);
         cleanup();
      }

      protected void S111( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV48Session.Get("RubrosRubrosWCGridState"), "") == 0 )
         {
            AV50GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "RubrosRubrosWCGridState"), null, "", "");
         }
         else
         {
            AV50GridState.FromXml(AV48Session.Get("RubrosRubrosWCGridState"), null, "", "");
         }
         AV61GXV1 = 1;
         while ( AV61GXV1 <= AV50GridState.gxTpr_Filtervalues.Count )
         {
            AV51GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV50GridState.gxTpr_Filtervalues.Item(AV61GXV1));
            if ( StringUtil.StrCmp(AV51GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV59FilterFullText = AV51GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV51GridStateFilterValue.gxTpr_Name, "TFPROFESIONALESID") == 0 )
            {
               AV11TFProfesionalesId = AV51GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV51GridStateFilterValue.gxTpr_Name, "TFPROFESIONALESID_SEL") == 0 )
            {
               AV12TFProfesionalesId_Sel = AV51GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV51GridStateFilterValue.gxTpr_Name, "TFPROFESIONALESPRIMERNOMBRE") == 0 )
            {
               AV13TFProfesionalesPrimerNombre = AV51GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV51GridStateFilterValue.gxTpr_Name, "TFPROFESIONALESPRIMERNOMBRE_SEL") == 0 )
            {
               AV14TFProfesionalesPrimerNombre_Sel = AV51GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV51GridStateFilterValue.gxTpr_Name, "TFPROFESIONALESSEGUNDONOMBRE") == 0 )
            {
               AV15TFProfesionalesSegundoNombre = AV51GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV51GridStateFilterValue.gxTpr_Name, "TFPROFESIONALESSEGUNDONOMBRE_SEL") == 0 )
            {
               AV16TFProfesionalesSegundoNombre_Sel = AV51GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV51GridStateFilterValue.gxTpr_Name, "TFPROFESIONALESAPELLIDOPRIMERO") == 0 )
            {
               AV17TFProfesionalesApellidoPrimero = AV51GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV51GridStateFilterValue.gxTpr_Name, "TFPROFESIONALESAPELLIDOPRIMERO_SEL") == 0 )
            {
               AV18TFProfesionalesApellidoPrimero_Sel = AV51GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV51GridStateFilterValue.gxTpr_Name, "TFPROFESIONALESAPELLIDOSEGUNDO") == 0 )
            {
               AV19TFProfesionalesApellidoSegundo = AV51GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV51GridStateFilterValue.gxTpr_Name, "TFPROFESIONALESAPELLIDOSEGUNDO_SEL") == 0 )
            {
               AV20TFProfesionalesApellidoSegundo_Sel = AV51GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV51GridStateFilterValue.gxTpr_Name, "TFPROFESIONALESTELEFONO") == 0 )
            {
               AV21TFProfesionalesTelefono = AV51GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV51GridStateFilterValue.gxTpr_Name, "TFPROFESIONALESTELEFONO_SEL") == 0 )
            {
               AV22TFProfesionalesTelefono_Sel = AV51GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV51GridStateFilterValue.gxTpr_Name, "TFPROFESIONALESEMAIL") == 0 )
            {
               AV23TFProfesionalesEmail = AV51GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV51GridStateFilterValue.gxTpr_Name, "TFPROFESIONALESEMAIL_SEL") == 0 )
            {
               AV24TFProfesionalesEmail_Sel = AV51GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV51GridStateFilterValue.gxTpr_Name, "TFPROFESIONALESDIRECCION") == 0 )
            {
               AV25TFProfesionalesDireccion = AV51GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV51GridStateFilterValue.gxTpr_Name, "TFPROFESIONALESDIRECCION_SEL") == 0 )
            {
               AV26TFProfesionalesDireccion_Sel = AV51GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV51GridStateFilterValue.gxTpr_Name, "TFESTADOSGENERICOSID") == 0 )
            {
               AV27TFEstadosGenericosId = (int)(Math.Round(NumberUtil.Val( AV51GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV28TFEstadosGenericosId_To = (int)(Math.Round(NumberUtil.Val( AV51GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV51GridStateFilterValue.gxTpr_Name, "TFPROFESIONALESVERDATPERSOL_SEL") == 0 )
            {
               AV29TFProfesionalesVerDatPerSol_SelsJson = AV51GridStateFilterValue.gxTpr_Value;
               AV30TFProfesionalesVerDatPerSol_Sels.FromJSonString(AV29TFProfesionalesVerDatPerSol_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV51GridStateFilterValue.gxTpr_Name, "TFPROFESIONALESFEEDBACKCANT") == 0 )
            {
               AV31TFProfesionalesFeedBackCant = (long)(Math.Round(NumberUtil.Val( AV51GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV32TFProfesionalesFeedBackCant_To = (long)(Math.Round(NumberUtil.Val( AV51GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV51GridStateFilterValue.gxTpr_Name, "TFPROFESIONALESFEEDBACK") == 0 )
            {
               AV33TFProfesionalesFeedback = NumberUtil.Val( AV51GridStateFilterValue.gxTpr_Value, ".");
               AV34TFProfesionalesFeedback_To = NumberUtil.Val( AV51GridStateFilterValue.gxTpr_Valueto, ".");
            }
            else if ( StringUtil.StrCmp(AV51GridStateFilterValue.gxTpr_Name, "TFPROFESIONALESPERALTSHOP_SEL") == 0 )
            {
               AV35TFProfesionalesPerAltShop_SelsJson = AV51GridStateFilterValue.gxTpr_Value;
               AV36TFProfesionalesPerAltShop_Sels.FromJSonString(AV35TFProfesionalesPerAltShop_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV51GridStateFilterValue.gxTpr_Name, "PARM_&RUBROSID") == 0 )
            {
               AV60RubrosId = (short)(Math.Round(NumberUtil.Val( AV51GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
            }
            AV61GXV1 = (int)(AV61GXV1+1);
         }
      }

      protected void S121( )
      {
         /* 'LOADPROFESIONALESIDOPTIONS' Routine */
         returnInSub = false;
         AV11TFProfesionalesId = AV37SearchTxt;
         AV12TFProfesionalesId_Sel = "";
         GXPagingIdx2 = 0;
         GXPagingFrom2 = AV38SkipItems;
         GXPagingTo2 = (int)(AV38SkipItems+AV40MaxItems);
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A267ProfesionalesVerDatPerSol ,
                                              AV30TFProfesionalesVerDatPerSol_Sels ,
                                              A436ProfesionalesPerAltShop ,
                                              AV36TFProfesionalesPerAltShop_Sels ,
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
                                              AV26TFProfesionalesDireccion_Sel ,
                                              AV25TFProfesionalesDireccion ,
                                              AV27TFEstadosGenericosId ,
                                              AV28TFEstadosGenericosId_To ,
                                              AV30TFProfesionalesVerDatPerSol_Sels.Count ,
                                              AV31TFProfesionalesFeedBackCant ,
                                              AV32TFProfesionalesFeedBackCant_To ,
                                              AV33TFProfesionalesFeedback ,
                                              AV34TFProfesionalesFeedback_To ,
                                              AV36TFProfesionalesPerAltShop_Sels.Count ,
                                              A120ProfesionalesId ,
                                              A166ProfesionalesPrimerNombre ,
                                              A191ProfesionalesSegundoNombre ,
                                              A167ProfesionalesApellidoPrimero ,
                                              A192ProfesionalesApellidoSegundo ,
                                              A170ProfesionalesTelefono ,
                                              A193ProfesionalesEmail ,
                                              A198ProfesionalesDireccion ,
                                              A108EstadosGenericosId ,
                                              A268ProfesionalesFeedBackCant ,
                                              A269ProfesionalesFeedBackProm ,
                                              AV59FilterFullText ,
                                              A270ProfesionalesFeedback ,
                                              AV60RubrosId ,
                                              A121RubrosId } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.INT, TypeConstants.BOOLEAN,
                                              TypeConstants.INT, TypeConstants.LONG, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.SHORT, TypeConstants.SHORT
                                              }
         });
         lV11TFProfesionalesId = StringUtil.PadR( StringUtil.RTrim( AV11TFProfesionalesId), 20, "%");
         lV13TFProfesionalesPrimerNombre = StringUtil.PadR( StringUtil.RTrim( AV13TFProfesionalesPrimerNombre), 30, "%");
         lV15TFProfesionalesSegundoNombre = StringUtil.PadR( StringUtil.RTrim( AV15TFProfesionalesSegundoNombre), 30, "%");
         lV17TFProfesionalesApellidoPrimero = StringUtil.PadR( StringUtil.RTrim( AV17TFProfesionalesApellidoPrimero), 30, "%");
         lV19TFProfesionalesApellidoSegundo = StringUtil.PadR( StringUtil.RTrim( AV19TFProfesionalesApellidoSegundo), 30, "%");
         lV21TFProfesionalesTelefono = StringUtil.PadR( StringUtil.RTrim( AV21TFProfesionalesTelefono), 20, "%");
         lV23TFProfesionalesEmail = StringUtil.Concat( StringUtil.RTrim( AV23TFProfesionalesEmail), "%", "");
         lV25TFProfesionalesDireccion = StringUtil.Concat( StringUtil.RTrim( AV25TFProfesionalesDireccion), "%", "");
         /* Using cursor P00462 */
         pr_default.execute(0, new Object[] {AV60RubrosId, lV11TFProfesionalesId, AV12TFProfesionalesId_Sel, lV13TFProfesionalesPrimerNombre, AV14TFProfesionalesPrimerNombre_Sel, lV15TFProfesionalesSegundoNombre, AV16TFProfesionalesSegundoNombre_Sel, lV17TFProfesionalesApellidoPrimero, AV18TFProfesionalesApellidoPrimero_Sel, lV19TFProfesionalesApellidoSegundo, AV20TFProfesionalesApellidoSegundo_Sel, lV21TFProfesionalesTelefono, AV22TFProfesionalesTelefono_Sel, lV23TFProfesionalesEmail, AV24TFProfesionalesEmail_Sel, lV25TFProfesionalesDireccion, AV26TFProfesionalesDireccion_Sel, AV27TFEstadosGenericosId, AV28TFEstadosGenericosId_To, AV31TFProfesionalesFeedBackCant, AV32TFProfesionalesFeedBackCant_To, AV33TFProfesionalesFeedback, AV34TFProfesionalesFeedback_To});
         while ( ( (pr_default.getStatus(0) != 101) ) && ( ( GXPagingTo2 == GXPagingFrom2 ) || ( GXPagingIdx2 < GXPagingTo2 ) ) )
         {
            A121RubrosId = P00462_A121RubrosId[0];
            A436ProfesionalesPerAltShop = P00462_A436ProfesionalesPerAltShop[0];
            n436ProfesionalesPerAltShop = P00462_n436ProfesionalesPerAltShop[0];
            A270ProfesionalesFeedback = P00462_A270ProfesionalesFeedback[0];
            A267ProfesionalesVerDatPerSol = P00462_A267ProfesionalesVerDatPerSol[0];
            A108EstadosGenericosId = P00462_A108EstadosGenericosId[0];
            A198ProfesionalesDireccion = P00462_A198ProfesionalesDireccion[0];
            A193ProfesionalesEmail = P00462_A193ProfesionalesEmail[0];
            n193ProfesionalesEmail = P00462_n193ProfesionalesEmail[0];
            A170ProfesionalesTelefono = P00462_A170ProfesionalesTelefono[0];
            A192ProfesionalesApellidoSegundo = P00462_A192ProfesionalesApellidoSegundo[0];
            A167ProfesionalesApellidoPrimero = P00462_A167ProfesionalesApellidoPrimero[0];
            A191ProfesionalesSegundoNombre = P00462_A191ProfesionalesSegundoNombre[0];
            A166ProfesionalesPrimerNombre = P00462_A166ProfesionalesPrimerNombre[0];
            A120ProfesionalesId = P00462_A120ProfesionalesId[0];
            A269ProfesionalesFeedBackProm = P00462_A269ProfesionalesFeedBackProm[0];
            A268ProfesionalesFeedBackCant = P00462_A268ProfesionalesFeedBackCant[0];
            A436ProfesionalesPerAltShop = P00462_A436ProfesionalesPerAltShop[0];
            n436ProfesionalesPerAltShop = P00462_n436ProfesionalesPerAltShop[0];
            A270ProfesionalesFeedback = P00462_A270ProfesionalesFeedback[0];
            A267ProfesionalesVerDatPerSol = P00462_A267ProfesionalesVerDatPerSol[0];
            A108EstadosGenericosId = P00462_A108EstadosGenericosId[0];
            A198ProfesionalesDireccion = P00462_A198ProfesionalesDireccion[0];
            A193ProfesionalesEmail = P00462_A193ProfesionalesEmail[0];
            n193ProfesionalesEmail = P00462_n193ProfesionalesEmail[0];
            A170ProfesionalesTelefono = P00462_A170ProfesionalesTelefono[0];
            A192ProfesionalesApellidoSegundo = P00462_A192ProfesionalesApellidoSegundo[0];
            A167ProfesionalesApellidoPrimero = P00462_A167ProfesionalesApellidoPrimero[0];
            A191ProfesionalesSegundoNombre = P00462_A191ProfesionalesSegundoNombre[0];
            A166ProfesionalesPrimerNombre = P00462_A166ProfesionalesPrimerNombre[0];
            A269ProfesionalesFeedBackProm = P00462_A269ProfesionalesFeedBackProm[0];
            A268ProfesionalesFeedBackCant = P00462_A268ProfesionalesFeedBackCant[0];
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV59FilterFullText)) || ( ( StringUtil.Like( StringUtil.Upper( A120ProfesionalesId) , StringUtil.PadR( "%" + StringUtil.Upper( AV59FilterFullText) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A166ProfesionalesPrimerNombre) , StringUtil.PadR( "%" + StringUtil.Upper( AV59FilterFullText) , 255 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Upper( A191ProfesionalesSegundoNombre) , StringUtil.PadR( "%" + StringUtil.Upper( AV59FilterFullText) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A167ProfesionalesApellidoPrimero) , StringUtil.PadR( "%" + StringUtil.Upper( AV59FilterFullText) , 255 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Upper( A192ProfesionalesApellidoSegundo) , StringUtil.PadR( "%" + StringUtil.Upper( AV59FilterFullText) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A170ProfesionalesTelefono) , StringUtil.PadR( "%" + StringUtil.Upper( AV59FilterFullText) , 255 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Upper( A193ProfesionalesEmail) , StringUtil.PadR( "%" + StringUtil.Upper( AV59FilterFullText) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A198ProfesionalesDireccion) , StringUtil.PadR( "%" + StringUtil.Upper( AV59FilterFullText) , 255 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Str( (decimal)(A108EstadosGenericosId), 5, 0) , StringUtil.PadR( "%" + AV59FilterFullText , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( context.GetMessage( "si", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV59FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A267ProfesionalesVerDatPerSol, "S") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "no", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV59FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A267ProfesionalesVerDatPerSol, "N") == 0 ) ) || ( StringUtil.Like( StringUtil.Str( (decimal)(A268ProfesionalesFeedBackCant), 18, 0) , StringUtil.PadR( "%" + AV59FilterFullText , 254 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Str( A270ProfesionalesFeedback, 10, 2) , StringUtil.PadR( "%" + AV59FilterFullText , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( context.GetMessage( "no permitir", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV59FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A436ProfesionalesPerAltShop, "N") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "permitir", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV59FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A436ProfesionalesPerAltShop, "S") == 0 ) ) )
            )
            {
               GXPagingIdx2 = (int)(GXPagingIdx2+1);
               if ( GXPagingIdx2 > GXPagingFrom2 )
               {
                  AV42Option = (String.IsNullOrEmpty(StringUtil.RTrim( A120ProfesionalesId)) ? "<#Empty#>" : A120ProfesionalesId);
                  AV43Options.Add(AV42Option, 0);
               }
            }
            pr_default.readNext(0);
         }
         pr_default.close(0);
      }

      protected void S131( )
      {
         /* 'LOADPROFESIONALESPRIMERNOMBREOPTIONS' Routine */
         returnInSub = false;
         AV13TFProfesionalesPrimerNombre = AV37SearchTxt;
         AV14TFProfesionalesPrimerNombre_Sel = "";
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              A267ProfesionalesVerDatPerSol ,
                                              AV30TFProfesionalesVerDatPerSol_Sels ,
                                              A436ProfesionalesPerAltShop ,
                                              AV36TFProfesionalesPerAltShop_Sels ,
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
                                              AV26TFProfesionalesDireccion_Sel ,
                                              AV25TFProfesionalesDireccion ,
                                              AV27TFEstadosGenericosId ,
                                              AV28TFEstadosGenericosId_To ,
                                              AV30TFProfesionalesVerDatPerSol_Sels.Count ,
                                              AV31TFProfesionalesFeedBackCant ,
                                              AV32TFProfesionalesFeedBackCant_To ,
                                              AV33TFProfesionalesFeedback ,
                                              AV34TFProfesionalesFeedback_To ,
                                              AV36TFProfesionalesPerAltShop_Sels.Count ,
                                              A120ProfesionalesId ,
                                              A166ProfesionalesPrimerNombre ,
                                              A191ProfesionalesSegundoNombre ,
                                              A167ProfesionalesApellidoPrimero ,
                                              A192ProfesionalesApellidoSegundo ,
                                              A170ProfesionalesTelefono ,
                                              A193ProfesionalesEmail ,
                                              A198ProfesionalesDireccion ,
                                              A108EstadosGenericosId ,
                                              A268ProfesionalesFeedBackCant ,
                                              A269ProfesionalesFeedBackProm ,
                                              AV59FilterFullText ,
                                              A270ProfesionalesFeedback ,
                                              AV60RubrosId ,
                                              A121RubrosId } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.INT, TypeConstants.BOOLEAN,
                                              TypeConstants.INT, TypeConstants.LONG, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.SHORT, TypeConstants.SHORT
                                              }
         });
         lV11TFProfesionalesId = StringUtil.PadR( StringUtil.RTrim( AV11TFProfesionalesId), 20, "%");
         lV13TFProfesionalesPrimerNombre = StringUtil.PadR( StringUtil.RTrim( AV13TFProfesionalesPrimerNombre), 30, "%");
         lV15TFProfesionalesSegundoNombre = StringUtil.PadR( StringUtil.RTrim( AV15TFProfesionalesSegundoNombre), 30, "%");
         lV17TFProfesionalesApellidoPrimero = StringUtil.PadR( StringUtil.RTrim( AV17TFProfesionalesApellidoPrimero), 30, "%");
         lV19TFProfesionalesApellidoSegundo = StringUtil.PadR( StringUtil.RTrim( AV19TFProfesionalesApellidoSegundo), 30, "%");
         lV21TFProfesionalesTelefono = StringUtil.PadR( StringUtil.RTrim( AV21TFProfesionalesTelefono), 20, "%");
         lV23TFProfesionalesEmail = StringUtil.Concat( StringUtil.RTrim( AV23TFProfesionalesEmail), "%", "");
         lV25TFProfesionalesDireccion = StringUtil.Concat( StringUtil.RTrim( AV25TFProfesionalesDireccion), "%", "");
         /* Using cursor P00463 */
         pr_default.execute(1, new Object[] {AV60RubrosId, lV11TFProfesionalesId, AV12TFProfesionalesId_Sel, lV13TFProfesionalesPrimerNombre, AV14TFProfesionalesPrimerNombre_Sel, lV15TFProfesionalesSegundoNombre, AV16TFProfesionalesSegundoNombre_Sel, lV17TFProfesionalesApellidoPrimero, AV18TFProfesionalesApellidoPrimero_Sel, lV19TFProfesionalesApellidoSegundo, AV20TFProfesionalesApellidoSegundo_Sel, lV21TFProfesionalesTelefono, AV22TFProfesionalesTelefono_Sel, lV23TFProfesionalesEmail, AV24TFProfesionalesEmail_Sel, lV25TFProfesionalesDireccion, AV26TFProfesionalesDireccion_Sel, AV27TFEstadosGenericosId, AV28TFEstadosGenericosId_To, AV31TFProfesionalesFeedBackCant, AV32TFProfesionalesFeedBackCant_To, AV33TFProfesionalesFeedback, AV34TFProfesionalesFeedback_To});
         while ( (pr_default.getStatus(1) != 101) )
         {
            BRK463 = false;
            A121RubrosId = P00463_A121RubrosId[0];
            A166ProfesionalesPrimerNombre = P00463_A166ProfesionalesPrimerNombre[0];
            A436ProfesionalesPerAltShop = P00463_A436ProfesionalesPerAltShop[0];
            n436ProfesionalesPerAltShop = P00463_n436ProfesionalesPerAltShop[0];
            A270ProfesionalesFeedback = P00463_A270ProfesionalesFeedback[0];
            A267ProfesionalesVerDatPerSol = P00463_A267ProfesionalesVerDatPerSol[0];
            A108EstadosGenericosId = P00463_A108EstadosGenericosId[0];
            A198ProfesionalesDireccion = P00463_A198ProfesionalesDireccion[0];
            A193ProfesionalesEmail = P00463_A193ProfesionalesEmail[0];
            n193ProfesionalesEmail = P00463_n193ProfesionalesEmail[0];
            A170ProfesionalesTelefono = P00463_A170ProfesionalesTelefono[0];
            A192ProfesionalesApellidoSegundo = P00463_A192ProfesionalesApellidoSegundo[0];
            A167ProfesionalesApellidoPrimero = P00463_A167ProfesionalesApellidoPrimero[0];
            A191ProfesionalesSegundoNombre = P00463_A191ProfesionalesSegundoNombre[0];
            A120ProfesionalesId = P00463_A120ProfesionalesId[0];
            A269ProfesionalesFeedBackProm = P00463_A269ProfesionalesFeedBackProm[0];
            A268ProfesionalesFeedBackCant = P00463_A268ProfesionalesFeedBackCant[0];
            A166ProfesionalesPrimerNombre = P00463_A166ProfesionalesPrimerNombre[0];
            A436ProfesionalesPerAltShop = P00463_A436ProfesionalesPerAltShop[0];
            n436ProfesionalesPerAltShop = P00463_n436ProfesionalesPerAltShop[0];
            A270ProfesionalesFeedback = P00463_A270ProfesionalesFeedback[0];
            A267ProfesionalesVerDatPerSol = P00463_A267ProfesionalesVerDatPerSol[0];
            A108EstadosGenericosId = P00463_A108EstadosGenericosId[0];
            A198ProfesionalesDireccion = P00463_A198ProfesionalesDireccion[0];
            A193ProfesionalesEmail = P00463_A193ProfesionalesEmail[0];
            n193ProfesionalesEmail = P00463_n193ProfesionalesEmail[0];
            A170ProfesionalesTelefono = P00463_A170ProfesionalesTelefono[0];
            A192ProfesionalesApellidoSegundo = P00463_A192ProfesionalesApellidoSegundo[0];
            A167ProfesionalesApellidoPrimero = P00463_A167ProfesionalesApellidoPrimero[0];
            A191ProfesionalesSegundoNombre = P00463_A191ProfesionalesSegundoNombre[0];
            A269ProfesionalesFeedBackProm = P00463_A269ProfesionalesFeedBackProm[0];
            A268ProfesionalesFeedBackCant = P00463_A268ProfesionalesFeedBackCant[0];
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV59FilterFullText)) || ( ( StringUtil.Like( StringUtil.Upper( A120ProfesionalesId) , StringUtil.PadR( "%" + StringUtil.Upper( AV59FilterFullText) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A166ProfesionalesPrimerNombre) , StringUtil.PadR( "%" + StringUtil.Upper( AV59FilterFullText) , 255 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Upper( A191ProfesionalesSegundoNombre) , StringUtil.PadR( "%" + StringUtil.Upper( AV59FilterFullText) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A167ProfesionalesApellidoPrimero) , StringUtil.PadR( "%" + StringUtil.Upper( AV59FilterFullText) , 255 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Upper( A192ProfesionalesApellidoSegundo) , StringUtil.PadR( "%" + StringUtil.Upper( AV59FilterFullText) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A170ProfesionalesTelefono) , StringUtil.PadR( "%" + StringUtil.Upper( AV59FilterFullText) , 255 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Upper( A193ProfesionalesEmail) , StringUtil.PadR( "%" + StringUtil.Upper( AV59FilterFullText) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A198ProfesionalesDireccion) , StringUtil.PadR( "%" + StringUtil.Upper( AV59FilterFullText) , 255 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Str( (decimal)(A108EstadosGenericosId), 5, 0) , StringUtil.PadR( "%" + AV59FilterFullText , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( context.GetMessage( "si", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV59FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A267ProfesionalesVerDatPerSol, "S") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "no", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV59FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A267ProfesionalesVerDatPerSol, "N") == 0 ) ) || ( StringUtil.Like( StringUtil.Str( (decimal)(A268ProfesionalesFeedBackCant), 18, 0) , StringUtil.PadR( "%" + AV59FilterFullText , 254 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Str( A270ProfesionalesFeedback, 10, 2) , StringUtil.PadR( "%" + AV59FilterFullText , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( context.GetMessage( "no permitir", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV59FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A436ProfesionalesPerAltShop, "N") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "permitir", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV59FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A436ProfesionalesPerAltShop, "S") == 0 ) ) )
            )
            {
               AV47count = 0;
               while ( (pr_default.getStatus(1) != 101) && ( P00463_A121RubrosId[0] == A121RubrosId ) && ( StringUtil.StrCmp(P00463_A166ProfesionalesPrimerNombre[0], A166ProfesionalesPrimerNombre) == 0 ) )
               {
                  BRK463 = false;
                  A120ProfesionalesId = P00463_A120ProfesionalesId[0];
                  AV47count = (long)(AV47count+1);
                  BRK463 = true;
                  pr_default.readNext(1);
               }
               if ( (0==AV38SkipItems) )
               {
                  AV42Option = (String.IsNullOrEmpty(StringUtil.RTrim( A166ProfesionalesPrimerNombre)) ? "<#Empty#>" : A166ProfesionalesPrimerNombre);
                  AV43Options.Add(AV42Option, 0);
                  AV46OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV47count), "Z,ZZZ,ZZZ,ZZ9")), 0);
                  if ( AV43Options.Count == 10 )
                  {
                     /* Exit For each command. Update data (if necessary), close cursors & exit. */
                     if (true) break;
                  }
               }
               else
               {
                  AV38SkipItems = (short)(AV38SkipItems-1);
               }
            }
            if ( ! BRK463 )
            {
               BRK463 = true;
               pr_default.readNext(1);
            }
         }
         pr_default.close(1);
      }

      protected void S141( )
      {
         /* 'LOADPROFESIONALESSEGUNDONOMBREOPTIONS' Routine */
         returnInSub = false;
         AV15TFProfesionalesSegundoNombre = AV37SearchTxt;
         AV16TFProfesionalesSegundoNombre_Sel = "";
         pr_default.dynParam(2, new Object[]{ new Object[]{
                                              A267ProfesionalesVerDatPerSol ,
                                              AV30TFProfesionalesVerDatPerSol_Sels ,
                                              A436ProfesionalesPerAltShop ,
                                              AV36TFProfesionalesPerAltShop_Sels ,
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
                                              AV26TFProfesionalesDireccion_Sel ,
                                              AV25TFProfesionalesDireccion ,
                                              AV27TFEstadosGenericosId ,
                                              AV28TFEstadosGenericosId_To ,
                                              AV30TFProfesionalesVerDatPerSol_Sels.Count ,
                                              AV31TFProfesionalesFeedBackCant ,
                                              AV32TFProfesionalesFeedBackCant_To ,
                                              AV33TFProfesionalesFeedback ,
                                              AV34TFProfesionalesFeedback_To ,
                                              AV36TFProfesionalesPerAltShop_Sels.Count ,
                                              A120ProfesionalesId ,
                                              A166ProfesionalesPrimerNombre ,
                                              A191ProfesionalesSegundoNombre ,
                                              A167ProfesionalesApellidoPrimero ,
                                              A192ProfesionalesApellidoSegundo ,
                                              A170ProfesionalesTelefono ,
                                              A193ProfesionalesEmail ,
                                              A198ProfesionalesDireccion ,
                                              A108EstadosGenericosId ,
                                              A268ProfesionalesFeedBackCant ,
                                              A269ProfesionalesFeedBackProm ,
                                              AV59FilterFullText ,
                                              A270ProfesionalesFeedback ,
                                              AV60RubrosId ,
                                              A121RubrosId } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.INT, TypeConstants.BOOLEAN,
                                              TypeConstants.INT, TypeConstants.LONG, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.SHORT, TypeConstants.SHORT
                                              }
         });
         lV11TFProfesionalesId = StringUtil.PadR( StringUtil.RTrim( AV11TFProfesionalesId), 20, "%");
         lV13TFProfesionalesPrimerNombre = StringUtil.PadR( StringUtil.RTrim( AV13TFProfesionalesPrimerNombre), 30, "%");
         lV15TFProfesionalesSegundoNombre = StringUtil.PadR( StringUtil.RTrim( AV15TFProfesionalesSegundoNombre), 30, "%");
         lV17TFProfesionalesApellidoPrimero = StringUtil.PadR( StringUtil.RTrim( AV17TFProfesionalesApellidoPrimero), 30, "%");
         lV19TFProfesionalesApellidoSegundo = StringUtil.PadR( StringUtil.RTrim( AV19TFProfesionalesApellidoSegundo), 30, "%");
         lV21TFProfesionalesTelefono = StringUtil.PadR( StringUtil.RTrim( AV21TFProfesionalesTelefono), 20, "%");
         lV23TFProfesionalesEmail = StringUtil.Concat( StringUtil.RTrim( AV23TFProfesionalesEmail), "%", "");
         lV25TFProfesionalesDireccion = StringUtil.Concat( StringUtil.RTrim( AV25TFProfesionalesDireccion), "%", "");
         /* Using cursor P00464 */
         pr_default.execute(2, new Object[] {AV60RubrosId, lV11TFProfesionalesId, AV12TFProfesionalesId_Sel, lV13TFProfesionalesPrimerNombre, AV14TFProfesionalesPrimerNombre_Sel, lV15TFProfesionalesSegundoNombre, AV16TFProfesionalesSegundoNombre_Sel, lV17TFProfesionalesApellidoPrimero, AV18TFProfesionalesApellidoPrimero_Sel, lV19TFProfesionalesApellidoSegundo, AV20TFProfesionalesApellidoSegundo_Sel, lV21TFProfesionalesTelefono, AV22TFProfesionalesTelefono_Sel, lV23TFProfesionalesEmail, AV24TFProfesionalesEmail_Sel, lV25TFProfesionalesDireccion, AV26TFProfesionalesDireccion_Sel, AV27TFEstadosGenericosId, AV28TFEstadosGenericosId_To, AV31TFProfesionalesFeedBackCant, AV32TFProfesionalesFeedBackCant_To, AV33TFProfesionalesFeedback, AV34TFProfesionalesFeedback_To});
         while ( (pr_default.getStatus(2) != 101) )
         {
            BRK465 = false;
            A121RubrosId = P00464_A121RubrosId[0];
            A191ProfesionalesSegundoNombre = P00464_A191ProfesionalesSegundoNombre[0];
            A436ProfesionalesPerAltShop = P00464_A436ProfesionalesPerAltShop[0];
            n436ProfesionalesPerAltShop = P00464_n436ProfesionalesPerAltShop[0];
            A270ProfesionalesFeedback = P00464_A270ProfesionalesFeedback[0];
            A267ProfesionalesVerDatPerSol = P00464_A267ProfesionalesVerDatPerSol[0];
            A108EstadosGenericosId = P00464_A108EstadosGenericosId[0];
            A198ProfesionalesDireccion = P00464_A198ProfesionalesDireccion[0];
            A193ProfesionalesEmail = P00464_A193ProfesionalesEmail[0];
            n193ProfesionalesEmail = P00464_n193ProfesionalesEmail[0];
            A170ProfesionalesTelefono = P00464_A170ProfesionalesTelefono[0];
            A192ProfesionalesApellidoSegundo = P00464_A192ProfesionalesApellidoSegundo[0];
            A167ProfesionalesApellidoPrimero = P00464_A167ProfesionalesApellidoPrimero[0];
            A166ProfesionalesPrimerNombre = P00464_A166ProfesionalesPrimerNombre[0];
            A120ProfesionalesId = P00464_A120ProfesionalesId[0];
            A269ProfesionalesFeedBackProm = P00464_A269ProfesionalesFeedBackProm[0];
            A268ProfesionalesFeedBackCant = P00464_A268ProfesionalesFeedBackCant[0];
            A191ProfesionalesSegundoNombre = P00464_A191ProfesionalesSegundoNombre[0];
            A436ProfesionalesPerAltShop = P00464_A436ProfesionalesPerAltShop[0];
            n436ProfesionalesPerAltShop = P00464_n436ProfesionalesPerAltShop[0];
            A270ProfesionalesFeedback = P00464_A270ProfesionalesFeedback[0];
            A267ProfesionalesVerDatPerSol = P00464_A267ProfesionalesVerDatPerSol[0];
            A108EstadosGenericosId = P00464_A108EstadosGenericosId[0];
            A198ProfesionalesDireccion = P00464_A198ProfesionalesDireccion[0];
            A193ProfesionalesEmail = P00464_A193ProfesionalesEmail[0];
            n193ProfesionalesEmail = P00464_n193ProfesionalesEmail[0];
            A170ProfesionalesTelefono = P00464_A170ProfesionalesTelefono[0];
            A192ProfesionalesApellidoSegundo = P00464_A192ProfesionalesApellidoSegundo[0];
            A167ProfesionalesApellidoPrimero = P00464_A167ProfesionalesApellidoPrimero[0];
            A166ProfesionalesPrimerNombre = P00464_A166ProfesionalesPrimerNombre[0];
            A269ProfesionalesFeedBackProm = P00464_A269ProfesionalesFeedBackProm[0];
            A268ProfesionalesFeedBackCant = P00464_A268ProfesionalesFeedBackCant[0];
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV59FilterFullText)) || ( ( StringUtil.Like( StringUtil.Upper( A120ProfesionalesId) , StringUtil.PadR( "%" + StringUtil.Upper( AV59FilterFullText) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A166ProfesionalesPrimerNombre) , StringUtil.PadR( "%" + StringUtil.Upper( AV59FilterFullText) , 255 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Upper( A191ProfesionalesSegundoNombre) , StringUtil.PadR( "%" + StringUtil.Upper( AV59FilterFullText) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A167ProfesionalesApellidoPrimero) , StringUtil.PadR( "%" + StringUtil.Upper( AV59FilterFullText) , 255 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Upper( A192ProfesionalesApellidoSegundo) , StringUtil.PadR( "%" + StringUtil.Upper( AV59FilterFullText) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A170ProfesionalesTelefono) , StringUtil.PadR( "%" + StringUtil.Upper( AV59FilterFullText) , 255 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Upper( A193ProfesionalesEmail) , StringUtil.PadR( "%" + StringUtil.Upper( AV59FilterFullText) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A198ProfesionalesDireccion) , StringUtil.PadR( "%" + StringUtil.Upper( AV59FilterFullText) , 255 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Str( (decimal)(A108EstadosGenericosId), 5, 0) , StringUtil.PadR( "%" + AV59FilterFullText , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( context.GetMessage( "si", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV59FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A267ProfesionalesVerDatPerSol, "S") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "no", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV59FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A267ProfesionalesVerDatPerSol, "N") == 0 ) ) || ( StringUtil.Like( StringUtil.Str( (decimal)(A268ProfesionalesFeedBackCant), 18, 0) , StringUtil.PadR( "%" + AV59FilterFullText , 254 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Str( A270ProfesionalesFeedback, 10, 2) , StringUtil.PadR( "%" + AV59FilterFullText , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( context.GetMessage( "no permitir", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV59FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A436ProfesionalesPerAltShop, "N") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "permitir", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV59FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A436ProfesionalesPerAltShop, "S") == 0 ) ) )
            )
            {
               AV47count = 0;
               while ( (pr_default.getStatus(2) != 101) && ( P00464_A121RubrosId[0] == A121RubrosId ) && ( StringUtil.StrCmp(P00464_A191ProfesionalesSegundoNombre[0], A191ProfesionalesSegundoNombre) == 0 ) )
               {
                  BRK465 = false;
                  A120ProfesionalesId = P00464_A120ProfesionalesId[0];
                  AV47count = (long)(AV47count+1);
                  BRK465 = true;
                  pr_default.readNext(2);
               }
               if ( (0==AV38SkipItems) )
               {
                  AV42Option = (String.IsNullOrEmpty(StringUtil.RTrim( A191ProfesionalesSegundoNombre)) ? "<#Empty#>" : A191ProfesionalesSegundoNombre);
                  AV43Options.Add(AV42Option, 0);
                  AV46OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV47count), "Z,ZZZ,ZZZ,ZZ9")), 0);
                  if ( AV43Options.Count == 10 )
                  {
                     /* Exit For each command. Update data (if necessary), close cursors & exit. */
                     if (true) break;
                  }
               }
               else
               {
                  AV38SkipItems = (short)(AV38SkipItems-1);
               }
            }
            if ( ! BRK465 )
            {
               BRK465 = true;
               pr_default.readNext(2);
            }
         }
         pr_default.close(2);
      }

      protected void S151( )
      {
         /* 'LOADPROFESIONALESAPELLIDOPRIMEROOPTIONS' Routine */
         returnInSub = false;
         AV17TFProfesionalesApellidoPrimero = AV37SearchTxt;
         AV18TFProfesionalesApellidoPrimero_Sel = "";
         pr_default.dynParam(3, new Object[]{ new Object[]{
                                              A267ProfesionalesVerDatPerSol ,
                                              AV30TFProfesionalesVerDatPerSol_Sels ,
                                              A436ProfesionalesPerAltShop ,
                                              AV36TFProfesionalesPerAltShop_Sels ,
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
                                              AV26TFProfesionalesDireccion_Sel ,
                                              AV25TFProfesionalesDireccion ,
                                              AV27TFEstadosGenericosId ,
                                              AV28TFEstadosGenericosId_To ,
                                              AV30TFProfesionalesVerDatPerSol_Sels.Count ,
                                              AV31TFProfesionalesFeedBackCant ,
                                              AV32TFProfesionalesFeedBackCant_To ,
                                              AV33TFProfesionalesFeedback ,
                                              AV34TFProfesionalesFeedback_To ,
                                              AV36TFProfesionalesPerAltShop_Sels.Count ,
                                              A120ProfesionalesId ,
                                              A166ProfesionalesPrimerNombre ,
                                              A191ProfesionalesSegundoNombre ,
                                              A167ProfesionalesApellidoPrimero ,
                                              A192ProfesionalesApellidoSegundo ,
                                              A170ProfesionalesTelefono ,
                                              A193ProfesionalesEmail ,
                                              A198ProfesionalesDireccion ,
                                              A108EstadosGenericosId ,
                                              A268ProfesionalesFeedBackCant ,
                                              A269ProfesionalesFeedBackProm ,
                                              AV59FilterFullText ,
                                              A270ProfesionalesFeedback ,
                                              AV60RubrosId ,
                                              A121RubrosId } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.INT, TypeConstants.BOOLEAN,
                                              TypeConstants.INT, TypeConstants.LONG, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.SHORT, TypeConstants.SHORT
                                              }
         });
         lV11TFProfesionalesId = StringUtil.PadR( StringUtil.RTrim( AV11TFProfesionalesId), 20, "%");
         lV13TFProfesionalesPrimerNombre = StringUtil.PadR( StringUtil.RTrim( AV13TFProfesionalesPrimerNombre), 30, "%");
         lV15TFProfesionalesSegundoNombre = StringUtil.PadR( StringUtil.RTrim( AV15TFProfesionalesSegundoNombre), 30, "%");
         lV17TFProfesionalesApellidoPrimero = StringUtil.PadR( StringUtil.RTrim( AV17TFProfesionalesApellidoPrimero), 30, "%");
         lV19TFProfesionalesApellidoSegundo = StringUtil.PadR( StringUtil.RTrim( AV19TFProfesionalesApellidoSegundo), 30, "%");
         lV21TFProfesionalesTelefono = StringUtil.PadR( StringUtil.RTrim( AV21TFProfesionalesTelefono), 20, "%");
         lV23TFProfesionalesEmail = StringUtil.Concat( StringUtil.RTrim( AV23TFProfesionalesEmail), "%", "");
         lV25TFProfesionalesDireccion = StringUtil.Concat( StringUtil.RTrim( AV25TFProfesionalesDireccion), "%", "");
         /* Using cursor P00465 */
         pr_default.execute(3, new Object[] {AV60RubrosId, lV11TFProfesionalesId, AV12TFProfesionalesId_Sel, lV13TFProfesionalesPrimerNombre, AV14TFProfesionalesPrimerNombre_Sel, lV15TFProfesionalesSegundoNombre, AV16TFProfesionalesSegundoNombre_Sel, lV17TFProfesionalesApellidoPrimero, AV18TFProfesionalesApellidoPrimero_Sel, lV19TFProfesionalesApellidoSegundo, AV20TFProfesionalesApellidoSegundo_Sel, lV21TFProfesionalesTelefono, AV22TFProfesionalesTelefono_Sel, lV23TFProfesionalesEmail, AV24TFProfesionalesEmail_Sel, lV25TFProfesionalesDireccion, AV26TFProfesionalesDireccion_Sel, AV27TFEstadosGenericosId, AV28TFEstadosGenericosId_To, AV31TFProfesionalesFeedBackCant, AV32TFProfesionalesFeedBackCant_To, AV33TFProfesionalesFeedback, AV34TFProfesionalesFeedback_To});
         while ( (pr_default.getStatus(3) != 101) )
         {
            BRK467 = false;
            A121RubrosId = P00465_A121RubrosId[0];
            A167ProfesionalesApellidoPrimero = P00465_A167ProfesionalesApellidoPrimero[0];
            A436ProfesionalesPerAltShop = P00465_A436ProfesionalesPerAltShop[0];
            n436ProfesionalesPerAltShop = P00465_n436ProfesionalesPerAltShop[0];
            A270ProfesionalesFeedback = P00465_A270ProfesionalesFeedback[0];
            A267ProfesionalesVerDatPerSol = P00465_A267ProfesionalesVerDatPerSol[0];
            A108EstadosGenericosId = P00465_A108EstadosGenericosId[0];
            A198ProfesionalesDireccion = P00465_A198ProfesionalesDireccion[0];
            A193ProfesionalesEmail = P00465_A193ProfesionalesEmail[0];
            n193ProfesionalesEmail = P00465_n193ProfesionalesEmail[0];
            A170ProfesionalesTelefono = P00465_A170ProfesionalesTelefono[0];
            A192ProfesionalesApellidoSegundo = P00465_A192ProfesionalesApellidoSegundo[0];
            A191ProfesionalesSegundoNombre = P00465_A191ProfesionalesSegundoNombre[0];
            A166ProfesionalesPrimerNombre = P00465_A166ProfesionalesPrimerNombre[0];
            A120ProfesionalesId = P00465_A120ProfesionalesId[0];
            A269ProfesionalesFeedBackProm = P00465_A269ProfesionalesFeedBackProm[0];
            A268ProfesionalesFeedBackCant = P00465_A268ProfesionalesFeedBackCant[0];
            A167ProfesionalesApellidoPrimero = P00465_A167ProfesionalesApellidoPrimero[0];
            A436ProfesionalesPerAltShop = P00465_A436ProfesionalesPerAltShop[0];
            n436ProfesionalesPerAltShop = P00465_n436ProfesionalesPerAltShop[0];
            A270ProfesionalesFeedback = P00465_A270ProfesionalesFeedback[0];
            A267ProfesionalesVerDatPerSol = P00465_A267ProfesionalesVerDatPerSol[0];
            A108EstadosGenericosId = P00465_A108EstadosGenericosId[0];
            A198ProfesionalesDireccion = P00465_A198ProfesionalesDireccion[0];
            A193ProfesionalesEmail = P00465_A193ProfesionalesEmail[0];
            n193ProfesionalesEmail = P00465_n193ProfesionalesEmail[0];
            A170ProfesionalesTelefono = P00465_A170ProfesionalesTelefono[0];
            A192ProfesionalesApellidoSegundo = P00465_A192ProfesionalesApellidoSegundo[0];
            A191ProfesionalesSegundoNombre = P00465_A191ProfesionalesSegundoNombre[0];
            A166ProfesionalesPrimerNombre = P00465_A166ProfesionalesPrimerNombre[0];
            A269ProfesionalesFeedBackProm = P00465_A269ProfesionalesFeedBackProm[0];
            A268ProfesionalesFeedBackCant = P00465_A268ProfesionalesFeedBackCant[0];
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV59FilterFullText)) || ( ( StringUtil.Like( StringUtil.Upper( A120ProfesionalesId) , StringUtil.PadR( "%" + StringUtil.Upper( AV59FilterFullText) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A166ProfesionalesPrimerNombre) , StringUtil.PadR( "%" + StringUtil.Upper( AV59FilterFullText) , 255 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Upper( A191ProfesionalesSegundoNombre) , StringUtil.PadR( "%" + StringUtil.Upper( AV59FilterFullText) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A167ProfesionalesApellidoPrimero) , StringUtil.PadR( "%" + StringUtil.Upper( AV59FilterFullText) , 255 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Upper( A192ProfesionalesApellidoSegundo) , StringUtil.PadR( "%" + StringUtil.Upper( AV59FilterFullText) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A170ProfesionalesTelefono) , StringUtil.PadR( "%" + StringUtil.Upper( AV59FilterFullText) , 255 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Upper( A193ProfesionalesEmail) , StringUtil.PadR( "%" + StringUtil.Upper( AV59FilterFullText) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A198ProfesionalesDireccion) , StringUtil.PadR( "%" + StringUtil.Upper( AV59FilterFullText) , 255 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Str( (decimal)(A108EstadosGenericosId), 5, 0) , StringUtil.PadR( "%" + AV59FilterFullText , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( context.GetMessage( "si", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV59FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A267ProfesionalesVerDatPerSol, "S") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "no", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV59FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A267ProfesionalesVerDatPerSol, "N") == 0 ) ) || ( StringUtil.Like( StringUtil.Str( (decimal)(A268ProfesionalesFeedBackCant), 18, 0) , StringUtil.PadR( "%" + AV59FilterFullText , 254 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Str( A270ProfesionalesFeedback, 10, 2) , StringUtil.PadR( "%" + AV59FilterFullText , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( context.GetMessage( "no permitir", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV59FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A436ProfesionalesPerAltShop, "N") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "permitir", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV59FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A436ProfesionalesPerAltShop, "S") == 0 ) ) )
            )
            {
               AV47count = 0;
               while ( (pr_default.getStatus(3) != 101) && ( P00465_A121RubrosId[0] == A121RubrosId ) && ( StringUtil.StrCmp(P00465_A167ProfesionalesApellidoPrimero[0], A167ProfesionalesApellidoPrimero) == 0 ) )
               {
                  BRK467 = false;
                  A120ProfesionalesId = P00465_A120ProfesionalesId[0];
                  AV47count = (long)(AV47count+1);
                  BRK467 = true;
                  pr_default.readNext(3);
               }
               if ( (0==AV38SkipItems) )
               {
                  AV42Option = (String.IsNullOrEmpty(StringUtil.RTrim( A167ProfesionalesApellidoPrimero)) ? "<#Empty#>" : A167ProfesionalesApellidoPrimero);
                  AV43Options.Add(AV42Option, 0);
                  AV46OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV47count), "Z,ZZZ,ZZZ,ZZ9")), 0);
                  if ( AV43Options.Count == 10 )
                  {
                     /* Exit For each command. Update data (if necessary), close cursors & exit. */
                     if (true) break;
                  }
               }
               else
               {
                  AV38SkipItems = (short)(AV38SkipItems-1);
               }
            }
            if ( ! BRK467 )
            {
               BRK467 = true;
               pr_default.readNext(3);
            }
         }
         pr_default.close(3);
      }

      protected void S161( )
      {
         /* 'LOADPROFESIONALESAPELLIDOSEGUNDOOPTIONS' Routine */
         returnInSub = false;
         AV19TFProfesionalesApellidoSegundo = AV37SearchTxt;
         AV20TFProfesionalesApellidoSegundo_Sel = "";
         pr_default.dynParam(4, new Object[]{ new Object[]{
                                              A267ProfesionalesVerDatPerSol ,
                                              AV30TFProfesionalesVerDatPerSol_Sels ,
                                              A436ProfesionalesPerAltShop ,
                                              AV36TFProfesionalesPerAltShop_Sels ,
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
                                              AV26TFProfesionalesDireccion_Sel ,
                                              AV25TFProfesionalesDireccion ,
                                              AV27TFEstadosGenericosId ,
                                              AV28TFEstadosGenericosId_To ,
                                              AV30TFProfesionalesVerDatPerSol_Sels.Count ,
                                              AV31TFProfesionalesFeedBackCant ,
                                              AV32TFProfesionalesFeedBackCant_To ,
                                              AV33TFProfesionalesFeedback ,
                                              AV34TFProfesionalesFeedback_To ,
                                              AV36TFProfesionalesPerAltShop_Sels.Count ,
                                              A120ProfesionalesId ,
                                              A166ProfesionalesPrimerNombre ,
                                              A191ProfesionalesSegundoNombre ,
                                              A167ProfesionalesApellidoPrimero ,
                                              A192ProfesionalesApellidoSegundo ,
                                              A170ProfesionalesTelefono ,
                                              A193ProfesionalesEmail ,
                                              A198ProfesionalesDireccion ,
                                              A108EstadosGenericosId ,
                                              A268ProfesionalesFeedBackCant ,
                                              A269ProfesionalesFeedBackProm ,
                                              AV59FilterFullText ,
                                              A270ProfesionalesFeedback ,
                                              AV60RubrosId ,
                                              A121RubrosId } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.INT, TypeConstants.BOOLEAN,
                                              TypeConstants.INT, TypeConstants.LONG, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.SHORT, TypeConstants.SHORT
                                              }
         });
         lV11TFProfesionalesId = StringUtil.PadR( StringUtil.RTrim( AV11TFProfesionalesId), 20, "%");
         lV13TFProfesionalesPrimerNombre = StringUtil.PadR( StringUtil.RTrim( AV13TFProfesionalesPrimerNombre), 30, "%");
         lV15TFProfesionalesSegundoNombre = StringUtil.PadR( StringUtil.RTrim( AV15TFProfesionalesSegundoNombre), 30, "%");
         lV17TFProfesionalesApellidoPrimero = StringUtil.PadR( StringUtil.RTrim( AV17TFProfesionalesApellidoPrimero), 30, "%");
         lV19TFProfesionalesApellidoSegundo = StringUtil.PadR( StringUtil.RTrim( AV19TFProfesionalesApellidoSegundo), 30, "%");
         lV21TFProfesionalesTelefono = StringUtil.PadR( StringUtil.RTrim( AV21TFProfesionalesTelefono), 20, "%");
         lV23TFProfesionalesEmail = StringUtil.Concat( StringUtil.RTrim( AV23TFProfesionalesEmail), "%", "");
         lV25TFProfesionalesDireccion = StringUtil.Concat( StringUtil.RTrim( AV25TFProfesionalesDireccion), "%", "");
         /* Using cursor P00466 */
         pr_default.execute(4, new Object[] {AV60RubrosId, lV11TFProfesionalesId, AV12TFProfesionalesId_Sel, lV13TFProfesionalesPrimerNombre, AV14TFProfesionalesPrimerNombre_Sel, lV15TFProfesionalesSegundoNombre, AV16TFProfesionalesSegundoNombre_Sel, lV17TFProfesionalesApellidoPrimero, AV18TFProfesionalesApellidoPrimero_Sel, lV19TFProfesionalesApellidoSegundo, AV20TFProfesionalesApellidoSegundo_Sel, lV21TFProfesionalesTelefono, AV22TFProfesionalesTelefono_Sel, lV23TFProfesionalesEmail, AV24TFProfesionalesEmail_Sel, lV25TFProfesionalesDireccion, AV26TFProfesionalesDireccion_Sel, AV27TFEstadosGenericosId, AV28TFEstadosGenericosId_To, AV31TFProfesionalesFeedBackCant, AV32TFProfesionalesFeedBackCant_To, AV33TFProfesionalesFeedback, AV34TFProfesionalesFeedback_To});
         while ( (pr_default.getStatus(4) != 101) )
         {
            BRK469 = false;
            A121RubrosId = P00466_A121RubrosId[0];
            A192ProfesionalesApellidoSegundo = P00466_A192ProfesionalesApellidoSegundo[0];
            A436ProfesionalesPerAltShop = P00466_A436ProfesionalesPerAltShop[0];
            n436ProfesionalesPerAltShop = P00466_n436ProfesionalesPerAltShop[0];
            A270ProfesionalesFeedback = P00466_A270ProfesionalesFeedback[0];
            A267ProfesionalesVerDatPerSol = P00466_A267ProfesionalesVerDatPerSol[0];
            A108EstadosGenericosId = P00466_A108EstadosGenericosId[0];
            A198ProfesionalesDireccion = P00466_A198ProfesionalesDireccion[0];
            A193ProfesionalesEmail = P00466_A193ProfesionalesEmail[0];
            n193ProfesionalesEmail = P00466_n193ProfesionalesEmail[0];
            A170ProfesionalesTelefono = P00466_A170ProfesionalesTelefono[0];
            A167ProfesionalesApellidoPrimero = P00466_A167ProfesionalesApellidoPrimero[0];
            A191ProfesionalesSegundoNombre = P00466_A191ProfesionalesSegundoNombre[0];
            A166ProfesionalesPrimerNombre = P00466_A166ProfesionalesPrimerNombre[0];
            A120ProfesionalesId = P00466_A120ProfesionalesId[0];
            A269ProfesionalesFeedBackProm = P00466_A269ProfesionalesFeedBackProm[0];
            A268ProfesionalesFeedBackCant = P00466_A268ProfesionalesFeedBackCant[0];
            A192ProfesionalesApellidoSegundo = P00466_A192ProfesionalesApellidoSegundo[0];
            A436ProfesionalesPerAltShop = P00466_A436ProfesionalesPerAltShop[0];
            n436ProfesionalesPerAltShop = P00466_n436ProfesionalesPerAltShop[0];
            A270ProfesionalesFeedback = P00466_A270ProfesionalesFeedback[0];
            A267ProfesionalesVerDatPerSol = P00466_A267ProfesionalesVerDatPerSol[0];
            A108EstadosGenericosId = P00466_A108EstadosGenericosId[0];
            A198ProfesionalesDireccion = P00466_A198ProfesionalesDireccion[0];
            A193ProfesionalesEmail = P00466_A193ProfesionalesEmail[0];
            n193ProfesionalesEmail = P00466_n193ProfesionalesEmail[0];
            A170ProfesionalesTelefono = P00466_A170ProfesionalesTelefono[0];
            A167ProfesionalesApellidoPrimero = P00466_A167ProfesionalesApellidoPrimero[0];
            A191ProfesionalesSegundoNombre = P00466_A191ProfesionalesSegundoNombre[0];
            A166ProfesionalesPrimerNombre = P00466_A166ProfesionalesPrimerNombre[0];
            A269ProfesionalesFeedBackProm = P00466_A269ProfesionalesFeedBackProm[0];
            A268ProfesionalesFeedBackCant = P00466_A268ProfesionalesFeedBackCant[0];
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV59FilterFullText)) || ( ( StringUtil.Like( StringUtil.Upper( A120ProfesionalesId) , StringUtil.PadR( "%" + StringUtil.Upper( AV59FilterFullText) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A166ProfesionalesPrimerNombre) , StringUtil.PadR( "%" + StringUtil.Upper( AV59FilterFullText) , 255 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Upper( A191ProfesionalesSegundoNombre) , StringUtil.PadR( "%" + StringUtil.Upper( AV59FilterFullText) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A167ProfesionalesApellidoPrimero) , StringUtil.PadR( "%" + StringUtil.Upper( AV59FilterFullText) , 255 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Upper( A192ProfesionalesApellidoSegundo) , StringUtil.PadR( "%" + StringUtil.Upper( AV59FilterFullText) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A170ProfesionalesTelefono) , StringUtil.PadR( "%" + StringUtil.Upper( AV59FilterFullText) , 255 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Upper( A193ProfesionalesEmail) , StringUtil.PadR( "%" + StringUtil.Upper( AV59FilterFullText) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A198ProfesionalesDireccion) , StringUtil.PadR( "%" + StringUtil.Upper( AV59FilterFullText) , 255 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Str( (decimal)(A108EstadosGenericosId), 5, 0) , StringUtil.PadR( "%" + AV59FilterFullText , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( context.GetMessage( "si", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV59FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A267ProfesionalesVerDatPerSol, "S") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "no", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV59FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A267ProfesionalesVerDatPerSol, "N") == 0 ) ) || ( StringUtil.Like( StringUtil.Str( (decimal)(A268ProfesionalesFeedBackCant), 18, 0) , StringUtil.PadR( "%" + AV59FilterFullText , 254 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Str( A270ProfesionalesFeedback, 10, 2) , StringUtil.PadR( "%" + AV59FilterFullText , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( context.GetMessage( "no permitir", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV59FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A436ProfesionalesPerAltShop, "N") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "permitir", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV59FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A436ProfesionalesPerAltShop, "S") == 0 ) ) )
            )
            {
               AV47count = 0;
               while ( (pr_default.getStatus(4) != 101) && ( P00466_A121RubrosId[0] == A121RubrosId ) && ( StringUtil.StrCmp(P00466_A192ProfesionalesApellidoSegundo[0], A192ProfesionalesApellidoSegundo) == 0 ) )
               {
                  BRK469 = false;
                  A120ProfesionalesId = P00466_A120ProfesionalesId[0];
                  AV47count = (long)(AV47count+1);
                  BRK469 = true;
                  pr_default.readNext(4);
               }
               if ( (0==AV38SkipItems) )
               {
                  AV42Option = (String.IsNullOrEmpty(StringUtil.RTrim( A192ProfesionalesApellidoSegundo)) ? "<#Empty#>" : A192ProfesionalesApellidoSegundo);
                  AV43Options.Add(AV42Option, 0);
                  AV46OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV47count), "Z,ZZZ,ZZZ,ZZ9")), 0);
                  if ( AV43Options.Count == 10 )
                  {
                     /* Exit For each command. Update data (if necessary), close cursors & exit. */
                     if (true) break;
                  }
               }
               else
               {
                  AV38SkipItems = (short)(AV38SkipItems-1);
               }
            }
            if ( ! BRK469 )
            {
               BRK469 = true;
               pr_default.readNext(4);
            }
         }
         pr_default.close(4);
      }

      protected void S171( )
      {
         /* 'LOADPROFESIONALESTELEFONOOPTIONS' Routine */
         returnInSub = false;
         AV21TFProfesionalesTelefono = AV37SearchTxt;
         AV22TFProfesionalesTelefono_Sel = "";
         pr_default.dynParam(5, new Object[]{ new Object[]{
                                              A267ProfesionalesVerDatPerSol ,
                                              AV30TFProfesionalesVerDatPerSol_Sels ,
                                              A436ProfesionalesPerAltShop ,
                                              AV36TFProfesionalesPerAltShop_Sels ,
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
                                              AV26TFProfesionalesDireccion_Sel ,
                                              AV25TFProfesionalesDireccion ,
                                              AV27TFEstadosGenericosId ,
                                              AV28TFEstadosGenericosId_To ,
                                              AV30TFProfesionalesVerDatPerSol_Sels.Count ,
                                              AV31TFProfesionalesFeedBackCant ,
                                              AV32TFProfesionalesFeedBackCant_To ,
                                              AV33TFProfesionalesFeedback ,
                                              AV34TFProfesionalesFeedback_To ,
                                              AV36TFProfesionalesPerAltShop_Sels.Count ,
                                              A120ProfesionalesId ,
                                              A166ProfesionalesPrimerNombre ,
                                              A191ProfesionalesSegundoNombre ,
                                              A167ProfesionalesApellidoPrimero ,
                                              A192ProfesionalesApellidoSegundo ,
                                              A170ProfesionalesTelefono ,
                                              A193ProfesionalesEmail ,
                                              A198ProfesionalesDireccion ,
                                              A108EstadosGenericosId ,
                                              A268ProfesionalesFeedBackCant ,
                                              A269ProfesionalesFeedBackProm ,
                                              AV59FilterFullText ,
                                              A270ProfesionalesFeedback ,
                                              AV60RubrosId ,
                                              A121RubrosId } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.INT, TypeConstants.BOOLEAN,
                                              TypeConstants.INT, TypeConstants.LONG, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.SHORT, TypeConstants.SHORT
                                              }
         });
         lV11TFProfesionalesId = StringUtil.PadR( StringUtil.RTrim( AV11TFProfesionalesId), 20, "%");
         lV13TFProfesionalesPrimerNombre = StringUtil.PadR( StringUtil.RTrim( AV13TFProfesionalesPrimerNombre), 30, "%");
         lV15TFProfesionalesSegundoNombre = StringUtil.PadR( StringUtil.RTrim( AV15TFProfesionalesSegundoNombre), 30, "%");
         lV17TFProfesionalesApellidoPrimero = StringUtil.PadR( StringUtil.RTrim( AV17TFProfesionalesApellidoPrimero), 30, "%");
         lV19TFProfesionalesApellidoSegundo = StringUtil.PadR( StringUtil.RTrim( AV19TFProfesionalesApellidoSegundo), 30, "%");
         lV21TFProfesionalesTelefono = StringUtil.PadR( StringUtil.RTrim( AV21TFProfesionalesTelefono), 20, "%");
         lV23TFProfesionalesEmail = StringUtil.Concat( StringUtil.RTrim( AV23TFProfesionalesEmail), "%", "");
         lV25TFProfesionalesDireccion = StringUtil.Concat( StringUtil.RTrim( AV25TFProfesionalesDireccion), "%", "");
         /* Using cursor P00467 */
         pr_default.execute(5, new Object[] {AV60RubrosId, lV11TFProfesionalesId, AV12TFProfesionalesId_Sel, lV13TFProfesionalesPrimerNombre, AV14TFProfesionalesPrimerNombre_Sel, lV15TFProfesionalesSegundoNombre, AV16TFProfesionalesSegundoNombre_Sel, lV17TFProfesionalesApellidoPrimero, AV18TFProfesionalesApellidoPrimero_Sel, lV19TFProfesionalesApellidoSegundo, AV20TFProfesionalesApellidoSegundo_Sel, lV21TFProfesionalesTelefono, AV22TFProfesionalesTelefono_Sel, lV23TFProfesionalesEmail, AV24TFProfesionalesEmail_Sel, lV25TFProfesionalesDireccion, AV26TFProfesionalesDireccion_Sel, AV27TFEstadosGenericosId, AV28TFEstadosGenericosId_To, AV31TFProfesionalesFeedBackCant, AV32TFProfesionalesFeedBackCant_To, AV33TFProfesionalesFeedback, AV34TFProfesionalesFeedback_To});
         while ( (pr_default.getStatus(5) != 101) )
         {
            BRK4611 = false;
            A121RubrosId = P00467_A121RubrosId[0];
            A170ProfesionalesTelefono = P00467_A170ProfesionalesTelefono[0];
            A436ProfesionalesPerAltShop = P00467_A436ProfesionalesPerAltShop[0];
            n436ProfesionalesPerAltShop = P00467_n436ProfesionalesPerAltShop[0];
            A270ProfesionalesFeedback = P00467_A270ProfesionalesFeedback[0];
            A267ProfesionalesVerDatPerSol = P00467_A267ProfesionalesVerDatPerSol[0];
            A108EstadosGenericosId = P00467_A108EstadosGenericosId[0];
            A198ProfesionalesDireccion = P00467_A198ProfesionalesDireccion[0];
            A193ProfesionalesEmail = P00467_A193ProfesionalesEmail[0];
            n193ProfesionalesEmail = P00467_n193ProfesionalesEmail[0];
            A192ProfesionalesApellidoSegundo = P00467_A192ProfesionalesApellidoSegundo[0];
            A167ProfesionalesApellidoPrimero = P00467_A167ProfesionalesApellidoPrimero[0];
            A191ProfesionalesSegundoNombre = P00467_A191ProfesionalesSegundoNombre[0];
            A166ProfesionalesPrimerNombre = P00467_A166ProfesionalesPrimerNombre[0];
            A120ProfesionalesId = P00467_A120ProfesionalesId[0];
            A269ProfesionalesFeedBackProm = P00467_A269ProfesionalesFeedBackProm[0];
            A268ProfesionalesFeedBackCant = P00467_A268ProfesionalesFeedBackCant[0];
            A170ProfesionalesTelefono = P00467_A170ProfesionalesTelefono[0];
            A436ProfesionalesPerAltShop = P00467_A436ProfesionalesPerAltShop[0];
            n436ProfesionalesPerAltShop = P00467_n436ProfesionalesPerAltShop[0];
            A270ProfesionalesFeedback = P00467_A270ProfesionalesFeedback[0];
            A267ProfesionalesVerDatPerSol = P00467_A267ProfesionalesVerDatPerSol[0];
            A108EstadosGenericosId = P00467_A108EstadosGenericosId[0];
            A198ProfesionalesDireccion = P00467_A198ProfesionalesDireccion[0];
            A193ProfesionalesEmail = P00467_A193ProfesionalesEmail[0];
            n193ProfesionalesEmail = P00467_n193ProfesionalesEmail[0];
            A192ProfesionalesApellidoSegundo = P00467_A192ProfesionalesApellidoSegundo[0];
            A167ProfesionalesApellidoPrimero = P00467_A167ProfesionalesApellidoPrimero[0];
            A191ProfesionalesSegundoNombre = P00467_A191ProfesionalesSegundoNombre[0];
            A166ProfesionalesPrimerNombre = P00467_A166ProfesionalesPrimerNombre[0];
            A269ProfesionalesFeedBackProm = P00467_A269ProfesionalesFeedBackProm[0];
            A268ProfesionalesFeedBackCant = P00467_A268ProfesionalesFeedBackCant[0];
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV59FilterFullText)) || ( ( StringUtil.Like( StringUtil.Upper( A120ProfesionalesId) , StringUtil.PadR( "%" + StringUtil.Upper( AV59FilterFullText) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A166ProfesionalesPrimerNombre) , StringUtil.PadR( "%" + StringUtil.Upper( AV59FilterFullText) , 255 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Upper( A191ProfesionalesSegundoNombre) , StringUtil.PadR( "%" + StringUtil.Upper( AV59FilterFullText) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A167ProfesionalesApellidoPrimero) , StringUtil.PadR( "%" + StringUtil.Upper( AV59FilterFullText) , 255 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Upper( A192ProfesionalesApellidoSegundo) , StringUtil.PadR( "%" + StringUtil.Upper( AV59FilterFullText) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A170ProfesionalesTelefono) , StringUtil.PadR( "%" + StringUtil.Upper( AV59FilterFullText) , 255 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Upper( A193ProfesionalesEmail) , StringUtil.PadR( "%" + StringUtil.Upper( AV59FilterFullText) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A198ProfesionalesDireccion) , StringUtil.PadR( "%" + StringUtil.Upper( AV59FilterFullText) , 255 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Str( (decimal)(A108EstadosGenericosId), 5, 0) , StringUtil.PadR( "%" + AV59FilterFullText , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( context.GetMessage( "si", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV59FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A267ProfesionalesVerDatPerSol, "S") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "no", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV59FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A267ProfesionalesVerDatPerSol, "N") == 0 ) ) || ( StringUtil.Like( StringUtil.Str( (decimal)(A268ProfesionalesFeedBackCant), 18, 0) , StringUtil.PadR( "%" + AV59FilterFullText , 254 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Str( A270ProfesionalesFeedback, 10, 2) , StringUtil.PadR( "%" + AV59FilterFullText , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( context.GetMessage( "no permitir", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV59FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A436ProfesionalesPerAltShop, "N") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "permitir", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV59FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A436ProfesionalesPerAltShop, "S") == 0 ) ) )
            )
            {
               AV47count = 0;
               while ( (pr_default.getStatus(5) != 101) && ( P00467_A121RubrosId[0] == A121RubrosId ) && ( StringUtil.StrCmp(P00467_A170ProfesionalesTelefono[0], A170ProfesionalesTelefono) == 0 ) )
               {
                  BRK4611 = false;
                  A120ProfesionalesId = P00467_A120ProfesionalesId[0];
                  AV47count = (long)(AV47count+1);
                  BRK4611 = true;
                  pr_default.readNext(5);
               }
               if ( (0==AV38SkipItems) )
               {
                  AV42Option = (String.IsNullOrEmpty(StringUtil.RTrim( A170ProfesionalesTelefono)) ? "<#Empty#>" : A170ProfesionalesTelefono);
                  AV43Options.Add(AV42Option, 0);
                  AV46OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV47count), "Z,ZZZ,ZZZ,ZZ9")), 0);
                  if ( AV43Options.Count == 10 )
                  {
                     /* Exit For each command. Update data (if necessary), close cursors & exit. */
                     if (true) break;
                  }
               }
               else
               {
                  AV38SkipItems = (short)(AV38SkipItems-1);
               }
            }
            if ( ! BRK4611 )
            {
               BRK4611 = true;
               pr_default.readNext(5);
            }
         }
         pr_default.close(5);
      }

      protected void S181( )
      {
         /* 'LOADPROFESIONALESEMAILOPTIONS' Routine */
         returnInSub = false;
         AV23TFProfesionalesEmail = AV37SearchTxt;
         AV24TFProfesionalesEmail_Sel = "";
         pr_default.dynParam(6, new Object[]{ new Object[]{
                                              A267ProfesionalesVerDatPerSol ,
                                              AV30TFProfesionalesVerDatPerSol_Sels ,
                                              A436ProfesionalesPerAltShop ,
                                              AV36TFProfesionalesPerAltShop_Sels ,
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
                                              AV26TFProfesionalesDireccion_Sel ,
                                              AV25TFProfesionalesDireccion ,
                                              AV27TFEstadosGenericosId ,
                                              AV28TFEstadosGenericosId_To ,
                                              AV30TFProfesionalesVerDatPerSol_Sels.Count ,
                                              AV31TFProfesionalesFeedBackCant ,
                                              AV32TFProfesionalesFeedBackCant_To ,
                                              AV33TFProfesionalesFeedback ,
                                              AV34TFProfesionalesFeedback_To ,
                                              AV36TFProfesionalesPerAltShop_Sels.Count ,
                                              A120ProfesionalesId ,
                                              A166ProfesionalesPrimerNombre ,
                                              A191ProfesionalesSegundoNombre ,
                                              A167ProfesionalesApellidoPrimero ,
                                              A192ProfesionalesApellidoSegundo ,
                                              A170ProfesionalesTelefono ,
                                              A193ProfesionalesEmail ,
                                              A198ProfesionalesDireccion ,
                                              A108EstadosGenericosId ,
                                              A268ProfesionalesFeedBackCant ,
                                              A269ProfesionalesFeedBackProm ,
                                              AV59FilterFullText ,
                                              A270ProfesionalesFeedback ,
                                              AV60RubrosId ,
                                              A121RubrosId } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.INT, TypeConstants.BOOLEAN,
                                              TypeConstants.INT, TypeConstants.LONG, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.SHORT, TypeConstants.SHORT
                                              }
         });
         lV11TFProfesionalesId = StringUtil.PadR( StringUtil.RTrim( AV11TFProfesionalesId), 20, "%");
         lV13TFProfesionalesPrimerNombre = StringUtil.PadR( StringUtil.RTrim( AV13TFProfesionalesPrimerNombre), 30, "%");
         lV15TFProfesionalesSegundoNombre = StringUtil.PadR( StringUtil.RTrim( AV15TFProfesionalesSegundoNombre), 30, "%");
         lV17TFProfesionalesApellidoPrimero = StringUtil.PadR( StringUtil.RTrim( AV17TFProfesionalesApellidoPrimero), 30, "%");
         lV19TFProfesionalesApellidoSegundo = StringUtil.PadR( StringUtil.RTrim( AV19TFProfesionalesApellidoSegundo), 30, "%");
         lV21TFProfesionalesTelefono = StringUtil.PadR( StringUtil.RTrim( AV21TFProfesionalesTelefono), 20, "%");
         lV23TFProfesionalesEmail = StringUtil.Concat( StringUtil.RTrim( AV23TFProfesionalesEmail), "%", "");
         lV25TFProfesionalesDireccion = StringUtil.Concat( StringUtil.RTrim( AV25TFProfesionalesDireccion), "%", "");
         /* Using cursor P00468 */
         pr_default.execute(6, new Object[] {AV60RubrosId, lV11TFProfesionalesId, AV12TFProfesionalesId_Sel, lV13TFProfesionalesPrimerNombre, AV14TFProfesionalesPrimerNombre_Sel, lV15TFProfesionalesSegundoNombre, AV16TFProfesionalesSegundoNombre_Sel, lV17TFProfesionalesApellidoPrimero, AV18TFProfesionalesApellidoPrimero_Sel, lV19TFProfesionalesApellidoSegundo, AV20TFProfesionalesApellidoSegundo_Sel, lV21TFProfesionalesTelefono, AV22TFProfesionalesTelefono_Sel, lV23TFProfesionalesEmail, AV24TFProfesionalesEmail_Sel, lV25TFProfesionalesDireccion, AV26TFProfesionalesDireccion_Sel, AV27TFEstadosGenericosId, AV28TFEstadosGenericosId_To, AV31TFProfesionalesFeedBackCant, AV32TFProfesionalesFeedBackCant_To, AV33TFProfesionalesFeedback, AV34TFProfesionalesFeedback_To});
         while ( (pr_default.getStatus(6) != 101) )
         {
            BRK4613 = false;
            A121RubrosId = P00468_A121RubrosId[0];
            A193ProfesionalesEmail = P00468_A193ProfesionalesEmail[0];
            n193ProfesionalesEmail = P00468_n193ProfesionalesEmail[0];
            A436ProfesionalesPerAltShop = P00468_A436ProfesionalesPerAltShop[0];
            n436ProfesionalesPerAltShop = P00468_n436ProfesionalesPerAltShop[0];
            A270ProfesionalesFeedback = P00468_A270ProfesionalesFeedback[0];
            A267ProfesionalesVerDatPerSol = P00468_A267ProfesionalesVerDatPerSol[0];
            A108EstadosGenericosId = P00468_A108EstadosGenericosId[0];
            A198ProfesionalesDireccion = P00468_A198ProfesionalesDireccion[0];
            A170ProfesionalesTelefono = P00468_A170ProfesionalesTelefono[0];
            A192ProfesionalesApellidoSegundo = P00468_A192ProfesionalesApellidoSegundo[0];
            A167ProfesionalesApellidoPrimero = P00468_A167ProfesionalesApellidoPrimero[0];
            A191ProfesionalesSegundoNombre = P00468_A191ProfesionalesSegundoNombre[0];
            A166ProfesionalesPrimerNombre = P00468_A166ProfesionalesPrimerNombre[0];
            A120ProfesionalesId = P00468_A120ProfesionalesId[0];
            A269ProfesionalesFeedBackProm = P00468_A269ProfesionalesFeedBackProm[0];
            A268ProfesionalesFeedBackCant = P00468_A268ProfesionalesFeedBackCant[0];
            A193ProfesionalesEmail = P00468_A193ProfesionalesEmail[0];
            n193ProfesionalesEmail = P00468_n193ProfesionalesEmail[0];
            A436ProfesionalesPerAltShop = P00468_A436ProfesionalesPerAltShop[0];
            n436ProfesionalesPerAltShop = P00468_n436ProfesionalesPerAltShop[0];
            A270ProfesionalesFeedback = P00468_A270ProfesionalesFeedback[0];
            A267ProfesionalesVerDatPerSol = P00468_A267ProfesionalesVerDatPerSol[0];
            A108EstadosGenericosId = P00468_A108EstadosGenericosId[0];
            A198ProfesionalesDireccion = P00468_A198ProfesionalesDireccion[0];
            A170ProfesionalesTelefono = P00468_A170ProfesionalesTelefono[0];
            A192ProfesionalesApellidoSegundo = P00468_A192ProfesionalesApellidoSegundo[0];
            A167ProfesionalesApellidoPrimero = P00468_A167ProfesionalesApellidoPrimero[0];
            A191ProfesionalesSegundoNombre = P00468_A191ProfesionalesSegundoNombre[0];
            A166ProfesionalesPrimerNombre = P00468_A166ProfesionalesPrimerNombre[0];
            A269ProfesionalesFeedBackProm = P00468_A269ProfesionalesFeedBackProm[0];
            A268ProfesionalesFeedBackCant = P00468_A268ProfesionalesFeedBackCant[0];
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV59FilterFullText)) || ( ( StringUtil.Like( StringUtil.Upper( A120ProfesionalesId) , StringUtil.PadR( "%" + StringUtil.Upper( AV59FilterFullText) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A166ProfesionalesPrimerNombre) , StringUtil.PadR( "%" + StringUtil.Upper( AV59FilterFullText) , 255 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Upper( A191ProfesionalesSegundoNombre) , StringUtil.PadR( "%" + StringUtil.Upper( AV59FilterFullText) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A167ProfesionalesApellidoPrimero) , StringUtil.PadR( "%" + StringUtil.Upper( AV59FilterFullText) , 255 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Upper( A192ProfesionalesApellidoSegundo) , StringUtil.PadR( "%" + StringUtil.Upper( AV59FilterFullText) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A170ProfesionalesTelefono) , StringUtil.PadR( "%" + StringUtil.Upper( AV59FilterFullText) , 255 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Upper( A193ProfesionalesEmail) , StringUtil.PadR( "%" + StringUtil.Upper( AV59FilterFullText) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A198ProfesionalesDireccion) , StringUtil.PadR( "%" + StringUtil.Upper( AV59FilterFullText) , 255 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Str( (decimal)(A108EstadosGenericosId), 5, 0) , StringUtil.PadR( "%" + AV59FilterFullText , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( context.GetMessage( "si", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV59FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A267ProfesionalesVerDatPerSol, "S") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "no", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV59FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A267ProfesionalesVerDatPerSol, "N") == 0 ) ) || ( StringUtil.Like( StringUtil.Str( (decimal)(A268ProfesionalesFeedBackCant), 18, 0) , StringUtil.PadR( "%" + AV59FilterFullText , 254 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Str( A270ProfesionalesFeedback, 10, 2) , StringUtil.PadR( "%" + AV59FilterFullText , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( context.GetMessage( "no permitir", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV59FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A436ProfesionalesPerAltShop, "N") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "permitir", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV59FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A436ProfesionalesPerAltShop, "S") == 0 ) ) )
            )
            {
               AV47count = 0;
               while ( (pr_default.getStatus(6) != 101) && ( P00468_A121RubrosId[0] == A121RubrosId ) && ( StringUtil.StrCmp(P00468_A193ProfesionalesEmail[0], A193ProfesionalesEmail) == 0 ) )
               {
                  BRK4613 = false;
                  A120ProfesionalesId = P00468_A120ProfesionalesId[0];
                  AV47count = (long)(AV47count+1);
                  BRK4613 = true;
                  pr_default.readNext(6);
               }
               if ( (0==AV38SkipItems) )
               {
                  AV42Option = (String.IsNullOrEmpty(StringUtil.RTrim( A193ProfesionalesEmail)) ? "<#Empty#>" : A193ProfesionalesEmail);
                  AV43Options.Add(AV42Option, 0);
                  AV46OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV47count), "Z,ZZZ,ZZZ,ZZ9")), 0);
                  if ( AV43Options.Count == 10 )
                  {
                     /* Exit For each command. Update data (if necessary), close cursors & exit. */
                     if (true) break;
                  }
               }
               else
               {
                  AV38SkipItems = (short)(AV38SkipItems-1);
               }
            }
            if ( ! BRK4613 )
            {
               BRK4613 = true;
               pr_default.readNext(6);
            }
         }
         pr_default.close(6);
      }

      protected void S191( )
      {
         /* 'LOADPROFESIONALESDIRECCIONOPTIONS' Routine */
         returnInSub = false;
         AV25TFProfesionalesDireccion = AV37SearchTxt;
         AV26TFProfesionalesDireccion_Sel = "";
         pr_default.dynParam(7, new Object[]{ new Object[]{
                                              A267ProfesionalesVerDatPerSol ,
                                              AV30TFProfesionalesVerDatPerSol_Sels ,
                                              A436ProfesionalesPerAltShop ,
                                              AV36TFProfesionalesPerAltShop_Sels ,
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
                                              AV26TFProfesionalesDireccion_Sel ,
                                              AV25TFProfesionalesDireccion ,
                                              AV27TFEstadosGenericosId ,
                                              AV28TFEstadosGenericosId_To ,
                                              AV30TFProfesionalesVerDatPerSol_Sels.Count ,
                                              AV31TFProfesionalesFeedBackCant ,
                                              AV32TFProfesionalesFeedBackCant_To ,
                                              AV33TFProfesionalesFeedback ,
                                              AV34TFProfesionalesFeedback_To ,
                                              AV36TFProfesionalesPerAltShop_Sels.Count ,
                                              A120ProfesionalesId ,
                                              A166ProfesionalesPrimerNombre ,
                                              A191ProfesionalesSegundoNombre ,
                                              A167ProfesionalesApellidoPrimero ,
                                              A192ProfesionalesApellidoSegundo ,
                                              A170ProfesionalesTelefono ,
                                              A193ProfesionalesEmail ,
                                              A198ProfesionalesDireccion ,
                                              A108EstadosGenericosId ,
                                              A268ProfesionalesFeedBackCant ,
                                              A269ProfesionalesFeedBackProm ,
                                              AV59FilterFullText ,
                                              A270ProfesionalesFeedback ,
                                              AV60RubrosId ,
                                              A121RubrosId } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.INT, TypeConstants.BOOLEAN,
                                              TypeConstants.INT, TypeConstants.LONG, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.SHORT, TypeConstants.SHORT
                                              }
         });
         lV11TFProfesionalesId = StringUtil.PadR( StringUtil.RTrim( AV11TFProfesionalesId), 20, "%");
         lV13TFProfesionalesPrimerNombre = StringUtil.PadR( StringUtil.RTrim( AV13TFProfesionalesPrimerNombre), 30, "%");
         lV15TFProfesionalesSegundoNombre = StringUtil.PadR( StringUtil.RTrim( AV15TFProfesionalesSegundoNombre), 30, "%");
         lV17TFProfesionalesApellidoPrimero = StringUtil.PadR( StringUtil.RTrim( AV17TFProfesionalesApellidoPrimero), 30, "%");
         lV19TFProfesionalesApellidoSegundo = StringUtil.PadR( StringUtil.RTrim( AV19TFProfesionalesApellidoSegundo), 30, "%");
         lV21TFProfesionalesTelefono = StringUtil.PadR( StringUtil.RTrim( AV21TFProfesionalesTelefono), 20, "%");
         lV23TFProfesionalesEmail = StringUtil.Concat( StringUtil.RTrim( AV23TFProfesionalesEmail), "%", "");
         lV25TFProfesionalesDireccion = StringUtil.Concat( StringUtil.RTrim( AV25TFProfesionalesDireccion), "%", "");
         /* Using cursor P00469 */
         pr_default.execute(7, new Object[] {AV60RubrosId, lV11TFProfesionalesId, AV12TFProfesionalesId_Sel, lV13TFProfesionalesPrimerNombre, AV14TFProfesionalesPrimerNombre_Sel, lV15TFProfesionalesSegundoNombre, AV16TFProfesionalesSegundoNombre_Sel, lV17TFProfesionalesApellidoPrimero, AV18TFProfesionalesApellidoPrimero_Sel, lV19TFProfesionalesApellidoSegundo, AV20TFProfesionalesApellidoSegundo_Sel, lV21TFProfesionalesTelefono, AV22TFProfesionalesTelefono_Sel, lV23TFProfesionalesEmail, AV24TFProfesionalesEmail_Sel, lV25TFProfesionalesDireccion, AV26TFProfesionalesDireccion_Sel, AV27TFEstadosGenericosId, AV28TFEstadosGenericosId_To, AV31TFProfesionalesFeedBackCant, AV32TFProfesionalesFeedBackCant_To, AV33TFProfesionalesFeedback, AV34TFProfesionalesFeedback_To});
         while ( (pr_default.getStatus(7) != 101) )
         {
            BRK4615 = false;
            A121RubrosId = P00469_A121RubrosId[0];
            A198ProfesionalesDireccion = P00469_A198ProfesionalesDireccion[0];
            A436ProfesionalesPerAltShop = P00469_A436ProfesionalesPerAltShop[0];
            n436ProfesionalesPerAltShop = P00469_n436ProfesionalesPerAltShop[0];
            A270ProfesionalesFeedback = P00469_A270ProfesionalesFeedback[0];
            A267ProfesionalesVerDatPerSol = P00469_A267ProfesionalesVerDatPerSol[0];
            A108EstadosGenericosId = P00469_A108EstadosGenericosId[0];
            A193ProfesionalesEmail = P00469_A193ProfesionalesEmail[0];
            n193ProfesionalesEmail = P00469_n193ProfesionalesEmail[0];
            A170ProfesionalesTelefono = P00469_A170ProfesionalesTelefono[0];
            A192ProfesionalesApellidoSegundo = P00469_A192ProfesionalesApellidoSegundo[0];
            A167ProfesionalesApellidoPrimero = P00469_A167ProfesionalesApellidoPrimero[0];
            A191ProfesionalesSegundoNombre = P00469_A191ProfesionalesSegundoNombre[0];
            A166ProfesionalesPrimerNombre = P00469_A166ProfesionalesPrimerNombre[0];
            A120ProfesionalesId = P00469_A120ProfesionalesId[0];
            A269ProfesionalesFeedBackProm = P00469_A269ProfesionalesFeedBackProm[0];
            A268ProfesionalesFeedBackCant = P00469_A268ProfesionalesFeedBackCant[0];
            A198ProfesionalesDireccion = P00469_A198ProfesionalesDireccion[0];
            A436ProfesionalesPerAltShop = P00469_A436ProfesionalesPerAltShop[0];
            n436ProfesionalesPerAltShop = P00469_n436ProfesionalesPerAltShop[0];
            A270ProfesionalesFeedback = P00469_A270ProfesionalesFeedback[0];
            A267ProfesionalesVerDatPerSol = P00469_A267ProfesionalesVerDatPerSol[0];
            A108EstadosGenericosId = P00469_A108EstadosGenericosId[0];
            A193ProfesionalesEmail = P00469_A193ProfesionalesEmail[0];
            n193ProfesionalesEmail = P00469_n193ProfesionalesEmail[0];
            A170ProfesionalesTelefono = P00469_A170ProfesionalesTelefono[0];
            A192ProfesionalesApellidoSegundo = P00469_A192ProfesionalesApellidoSegundo[0];
            A167ProfesionalesApellidoPrimero = P00469_A167ProfesionalesApellidoPrimero[0];
            A191ProfesionalesSegundoNombre = P00469_A191ProfesionalesSegundoNombre[0];
            A166ProfesionalesPrimerNombre = P00469_A166ProfesionalesPrimerNombre[0];
            A269ProfesionalesFeedBackProm = P00469_A269ProfesionalesFeedBackProm[0];
            A268ProfesionalesFeedBackCant = P00469_A268ProfesionalesFeedBackCant[0];
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV59FilterFullText)) || ( ( StringUtil.Like( StringUtil.Upper( A120ProfesionalesId) , StringUtil.PadR( "%" + StringUtil.Upper( AV59FilterFullText) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A166ProfesionalesPrimerNombre) , StringUtil.PadR( "%" + StringUtil.Upper( AV59FilterFullText) , 255 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Upper( A191ProfesionalesSegundoNombre) , StringUtil.PadR( "%" + StringUtil.Upper( AV59FilterFullText) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A167ProfesionalesApellidoPrimero) , StringUtil.PadR( "%" + StringUtil.Upper( AV59FilterFullText) , 255 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Upper( A192ProfesionalesApellidoSegundo) , StringUtil.PadR( "%" + StringUtil.Upper( AV59FilterFullText) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A170ProfesionalesTelefono) , StringUtil.PadR( "%" + StringUtil.Upper( AV59FilterFullText) , 255 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Upper( A193ProfesionalesEmail) , StringUtil.PadR( "%" + StringUtil.Upper( AV59FilterFullText) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A198ProfesionalesDireccion) , StringUtil.PadR( "%" + StringUtil.Upper( AV59FilterFullText) , 255 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Str( (decimal)(A108EstadosGenericosId), 5, 0) , StringUtil.PadR( "%" + AV59FilterFullText , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( context.GetMessage( "si", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV59FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A267ProfesionalesVerDatPerSol, "S") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "no", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV59FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A267ProfesionalesVerDatPerSol, "N") == 0 ) ) || ( StringUtil.Like( StringUtil.Str( (decimal)(A268ProfesionalesFeedBackCant), 18, 0) , StringUtil.PadR( "%" + AV59FilterFullText , 254 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Str( A270ProfesionalesFeedback, 10, 2) , StringUtil.PadR( "%" + AV59FilterFullText , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( context.GetMessage( "no permitir", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV59FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A436ProfesionalesPerAltShop, "N") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "permitir", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV59FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A436ProfesionalesPerAltShop, "S") == 0 ) ) )
            )
            {
               AV47count = 0;
               while ( (pr_default.getStatus(7) != 101) && ( P00469_A121RubrosId[0] == A121RubrosId ) && ( StringUtil.StrCmp(P00469_A198ProfesionalesDireccion[0], A198ProfesionalesDireccion) == 0 ) )
               {
                  BRK4615 = false;
                  A120ProfesionalesId = P00469_A120ProfesionalesId[0];
                  AV47count = (long)(AV47count+1);
                  BRK4615 = true;
                  pr_default.readNext(7);
               }
               if ( (0==AV38SkipItems) )
               {
                  AV42Option = (String.IsNullOrEmpty(StringUtil.RTrim( A198ProfesionalesDireccion)) ? "<#Empty#>" : A198ProfesionalesDireccion);
                  AV43Options.Add(AV42Option, 0);
                  AV46OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV47count), "Z,ZZZ,ZZZ,ZZ9")), 0);
                  if ( AV43Options.Count == 10 )
                  {
                     /* Exit For each command. Update data (if necessary), close cursors & exit. */
                     if (true) break;
                  }
               }
               else
               {
                  AV38SkipItems = (short)(AV38SkipItems-1);
               }
            }
            if ( ! BRK4615 )
            {
               BRK4615 = true;
               pr_default.readNext(7);
            }
         }
         pr_default.close(7);
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
         AV56OptionsJson = "";
         AV57OptionsDescJson = "";
         AV58OptionIndexesJson = "";
         AV43Options = new GxSimpleCollection<string>();
         AV45OptionsDesc = new GxSimpleCollection<string>();
         AV46OptionIndexes = new GxSimpleCollection<string>();
         AV37SearchTxt = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV48Session = context.GetSession();
         AV50GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV51GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV59FilterFullText = "";
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
         AV25TFProfesionalesDireccion = "";
         AV26TFProfesionalesDireccion_Sel = "";
         AV29TFProfesionalesVerDatPerSol_SelsJson = "";
         AV30TFProfesionalesVerDatPerSol_Sels = new GxSimpleCollection<string>();
         AV35TFProfesionalesPerAltShop_SelsJson = "";
         AV36TFProfesionalesPerAltShop_Sels = new GxSimpleCollection<string>();
         lV11TFProfesionalesId = "";
         lV13TFProfesionalesPrimerNombre = "";
         lV15TFProfesionalesSegundoNombre = "";
         lV17TFProfesionalesApellidoPrimero = "";
         lV19TFProfesionalesApellidoSegundo = "";
         lV21TFProfesionalesTelefono = "";
         lV23TFProfesionalesEmail = "";
         lV25TFProfesionalesDireccion = "";
         A267ProfesionalesVerDatPerSol = "";
         A436ProfesionalesPerAltShop = "";
         A120ProfesionalesId = "";
         A166ProfesionalesPrimerNombre = "";
         A191ProfesionalesSegundoNombre = "";
         A167ProfesionalesApellidoPrimero = "";
         A192ProfesionalesApellidoSegundo = "";
         A170ProfesionalesTelefono = "";
         A193ProfesionalesEmail = "";
         A198ProfesionalesDireccion = "";
         P00462_A121RubrosId = new short[1] ;
         P00462_A436ProfesionalesPerAltShop = new string[] {""} ;
         P00462_n436ProfesionalesPerAltShop = new bool[] {false} ;
         P00462_A270ProfesionalesFeedback = new decimal[1] ;
         P00462_A267ProfesionalesVerDatPerSol = new string[] {""} ;
         P00462_A108EstadosGenericosId = new int[1] ;
         P00462_A198ProfesionalesDireccion = new string[] {""} ;
         P00462_A193ProfesionalesEmail = new string[] {""} ;
         P00462_n193ProfesionalesEmail = new bool[] {false} ;
         P00462_A170ProfesionalesTelefono = new string[] {""} ;
         P00462_A192ProfesionalesApellidoSegundo = new string[] {""} ;
         P00462_A167ProfesionalesApellidoPrimero = new string[] {""} ;
         P00462_A191ProfesionalesSegundoNombre = new string[] {""} ;
         P00462_A166ProfesionalesPrimerNombre = new string[] {""} ;
         P00462_A120ProfesionalesId = new string[] {""} ;
         P00462_A269ProfesionalesFeedBackProm = new decimal[1] ;
         P00462_A268ProfesionalesFeedBackCant = new long[1] ;
         AV42Option = "";
         P00463_A121RubrosId = new short[1] ;
         P00463_A166ProfesionalesPrimerNombre = new string[] {""} ;
         P00463_A436ProfesionalesPerAltShop = new string[] {""} ;
         P00463_n436ProfesionalesPerAltShop = new bool[] {false} ;
         P00463_A270ProfesionalesFeedback = new decimal[1] ;
         P00463_A267ProfesionalesVerDatPerSol = new string[] {""} ;
         P00463_A108EstadosGenericosId = new int[1] ;
         P00463_A198ProfesionalesDireccion = new string[] {""} ;
         P00463_A193ProfesionalesEmail = new string[] {""} ;
         P00463_n193ProfesionalesEmail = new bool[] {false} ;
         P00463_A170ProfesionalesTelefono = new string[] {""} ;
         P00463_A192ProfesionalesApellidoSegundo = new string[] {""} ;
         P00463_A167ProfesionalesApellidoPrimero = new string[] {""} ;
         P00463_A191ProfesionalesSegundoNombre = new string[] {""} ;
         P00463_A120ProfesionalesId = new string[] {""} ;
         P00463_A269ProfesionalesFeedBackProm = new decimal[1] ;
         P00463_A268ProfesionalesFeedBackCant = new long[1] ;
         P00464_A121RubrosId = new short[1] ;
         P00464_A191ProfesionalesSegundoNombre = new string[] {""} ;
         P00464_A436ProfesionalesPerAltShop = new string[] {""} ;
         P00464_n436ProfesionalesPerAltShop = new bool[] {false} ;
         P00464_A270ProfesionalesFeedback = new decimal[1] ;
         P00464_A267ProfesionalesVerDatPerSol = new string[] {""} ;
         P00464_A108EstadosGenericosId = new int[1] ;
         P00464_A198ProfesionalesDireccion = new string[] {""} ;
         P00464_A193ProfesionalesEmail = new string[] {""} ;
         P00464_n193ProfesionalesEmail = new bool[] {false} ;
         P00464_A170ProfesionalesTelefono = new string[] {""} ;
         P00464_A192ProfesionalesApellidoSegundo = new string[] {""} ;
         P00464_A167ProfesionalesApellidoPrimero = new string[] {""} ;
         P00464_A166ProfesionalesPrimerNombre = new string[] {""} ;
         P00464_A120ProfesionalesId = new string[] {""} ;
         P00464_A269ProfesionalesFeedBackProm = new decimal[1] ;
         P00464_A268ProfesionalesFeedBackCant = new long[1] ;
         P00465_A121RubrosId = new short[1] ;
         P00465_A167ProfesionalesApellidoPrimero = new string[] {""} ;
         P00465_A436ProfesionalesPerAltShop = new string[] {""} ;
         P00465_n436ProfesionalesPerAltShop = new bool[] {false} ;
         P00465_A270ProfesionalesFeedback = new decimal[1] ;
         P00465_A267ProfesionalesVerDatPerSol = new string[] {""} ;
         P00465_A108EstadosGenericosId = new int[1] ;
         P00465_A198ProfesionalesDireccion = new string[] {""} ;
         P00465_A193ProfesionalesEmail = new string[] {""} ;
         P00465_n193ProfesionalesEmail = new bool[] {false} ;
         P00465_A170ProfesionalesTelefono = new string[] {""} ;
         P00465_A192ProfesionalesApellidoSegundo = new string[] {""} ;
         P00465_A191ProfesionalesSegundoNombre = new string[] {""} ;
         P00465_A166ProfesionalesPrimerNombre = new string[] {""} ;
         P00465_A120ProfesionalesId = new string[] {""} ;
         P00465_A269ProfesionalesFeedBackProm = new decimal[1] ;
         P00465_A268ProfesionalesFeedBackCant = new long[1] ;
         P00466_A121RubrosId = new short[1] ;
         P00466_A192ProfesionalesApellidoSegundo = new string[] {""} ;
         P00466_A436ProfesionalesPerAltShop = new string[] {""} ;
         P00466_n436ProfesionalesPerAltShop = new bool[] {false} ;
         P00466_A270ProfesionalesFeedback = new decimal[1] ;
         P00466_A267ProfesionalesVerDatPerSol = new string[] {""} ;
         P00466_A108EstadosGenericosId = new int[1] ;
         P00466_A198ProfesionalesDireccion = new string[] {""} ;
         P00466_A193ProfesionalesEmail = new string[] {""} ;
         P00466_n193ProfesionalesEmail = new bool[] {false} ;
         P00466_A170ProfesionalesTelefono = new string[] {""} ;
         P00466_A167ProfesionalesApellidoPrimero = new string[] {""} ;
         P00466_A191ProfesionalesSegundoNombre = new string[] {""} ;
         P00466_A166ProfesionalesPrimerNombre = new string[] {""} ;
         P00466_A120ProfesionalesId = new string[] {""} ;
         P00466_A269ProfesionalesFeedBackProm = new decimal[1] ;
         P00466_A268ProfesionalesFeedBackCant = new long[1] ;
         P00467_A121RubrosId = new short[1] ;
         P00467_A170ProfesionalesTelefono = new string[] {""} ;
         P00467_A436ProfesionalesPerAltShop = new string[] {""} ;
         P00467_n436ProfesionalesPerAltShop = new bool[] {false} ;
         P00467_A270ProfesionalesFeedback = new decimal[1] ;
         P00467_A267ProfesionalesVerDatPerSol = new string[] {""} ;
         P00467_A108EstadosGenericosId = new int[1] ;
         P00467_A198ProfesionalesDireccion = new string[] {""} ;
         P00467_A193ProfesionalesEmail = new string[] {""} ;
         P00467_n193ProfesionalesEmail = new bool[] {false} ;
         P00467_A192ProfesionalesApellidoSegundo = new string[] {""} ;
         P00467_A167ProfesionalesApellidoPrimero = new string[] {""} ;
         P00467_A191ProfesionalesSegundoNombre = new string[] {""} ;
         P00467_A166ProfesionalesPrimerNombre = new string[] {""} ;
         P00467_A120ProfesionalesId = new string[] {""} ;
         P00467_A269ProfesionalesFeedBackProm = new decimal[1] ;
         P00467_A268ProfesionalesFeedBackCant = new long[1] ;
         P00468_A121RubrosId = new short[1] ;
         P00468_A193ProfesionalesEmail = new string[] {""} ;
         P00468_n193ProfesionalesEmail = new bool[] {false} ;
         P00468_A436ProfesionalesPerAltShop = new string[] {""} ;
         P00468_n436ProfesionalesPerAltShop = new bool[] {false} ;
         P00468_A270ProfesionalesFeedback = new decimal[1] ;
         P00468_A267ProfesionalesVerDatPerSol = new string[] {""} ;
         P00468_A108EstadosGenericosId = new int[1] ;
         P00468_A198ProfesionalesDireccion = new string[] {""} ;
         P00468_A170ProfesionalesTelefono = new string[] {""} ;
         P00468_A192ProfesionalesApellidoSegundo = new string[] {""} ;
         P00468_A167ProfesionalesApellidoPrimero = new string[] {""} ;
         P00468_A191ProfesionalesSegundoNombre = new string[] {""} ;
         P00468_A166ProfesionalesPrimerNombre = new string[] {""} ;
         P00468_A120ProfesionalesId = new string[] {""} ;
         P00468_A269ProfesionalesFeedBackProm = new decimal[1] ;
         P00468_A268ProfesionalesFeedBackCant = new long[1] ;
         P00469_A121RubrosId = new short[1] ;
         P00469_A198ProfesionalesDireccion = new string[] {""} ;
         P00469_A436ProfesionalesPerAltShop = new string[] {""} ;
         P00469_n436ProfesionalesPerAltShop = new bool[] {false} ;
         P00469_A270ProfesionalesFeedback = new decimal[1] ;
         P00469_A267ProfesionalesVerDatPerSol = new string[] {""} ;
         P00469_A108EstadosGenericosId = new int[1] ;
         P00469_A193ProfesionalesEmail = new string[] {""} ;
         P00469_n193ProfesionalesEmail = new bool[] {false} ;
         P00469_A170ProfesionalesTelefono = new string[] {""} ;
         P00469_A192ProfesionalesApellidoSegundo = new string[] {""} ;
         P00469_A167ProfesionalesApellidoPrimero = new string[] {""} ;
         P00469_A191ProfesionalesSegundoNombre = new string[] {""} ;
         P00469_A166ProfesionalesPrimerNombre = new string[] {""} ;
         P00469_A120ProfesionalesId = new string[] {""} ;
         P00469_A269ProfesionalesFeedBackProm = new decimal[1] ;
         P00469_A268ProfesionalesFeedBackCant = new long[1] ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.rubrosrubroswcgetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P00462_A121RubrosId, P00462_A436ProfesionalesPerAltShop, P00462_n436ProfesionalesPerAltShop, P00462_A270ProfesionalesFeedback, P00462_A267ProfesionalesVerDatPerSol, P00462_A108EstadosGenericosId, P00462_A198ProfesionalesDireccion, P00462_A193ProfesionalesEmail, P00462_n193ProfesionalesEmail, P00462_A170ProfesionalesTelefono,
               P00462_A192ProfesionalesApellidoSegundo, P00462_A167ProfesionalesApellidoPrimero, P00462_A191ProfesionalesSegundoNombre, P00462_A166ProfesionalesPrimerNombre, P00462_A120ProfesionalesId, P00462_A269ProfesionalesFeedBackProm, P00462_A268ProfesionalesFeedBackCant
               }
               , new Object[] {
               P00463_A121RubrosId, P00463_A166ProfesionalesPrimerNombre, P00463_A436ProfesionalesPerAltShop, P00463_n436ProfesionalesPerAltShop, P00463_A270ProfesionalesFeedback, P00463_A267ProfesionalesVerDatPerSol, P00463_A108EstadosGenericosId, P00463_A198ProfesionalesDireccion, P00463_A193ProfesionalesEmail, P00463_n193ProfesionalesEmail,
               P00463_A170ProfesionalesTelefono, P00463_A192ProfesionalesApellidoSegundo, P00463_A167ProfesionalesApellidoPrimero, P00463_A191ProfesionalesSegundoNombre, P00463_A120ProfesionalesId, P00463_A269ProfesionalesFeedBackProm, P00463_A268ProfesionalesFeedBackCant
               }
               , new Object[] {
               P00464_A121RubrosId, P00464_A191ProfesionalesSegundoNombre, P00464_A436ProfesionalesPerAltShop, P00464_n436ProfesionalesPerAltShop, P00464_A270ProfesionalesFeedback, P00464_A267ProfesionalesVerDatPerSol, P00464_A108EstadosGenericosId, P00464_A198ProfesionalesDireccion, P00464_A193ProfesionalesEmail, P00464_n193ProfesionalesEmail,
               P00464_A170ProfesionalesTelefono, P00464_A192ProfesionalesApellidoSegundo, P00464_A167ProfesionalesApellidoPrimero, P00464_A166ProfesionalesPrimerNombre, P00464_A120ProfesionalesId, P00464_A269ProfesionalesFeedBackProm, P00464_A268ProfesionalesFeedBackCant
               }
               , new Object[] {
               P00465_A121RubrosId, P00465_A167ProfesionalesApellidoPrimero, P00465_A436ProfesionalesPerAltShop, P00465_n436ProfesionalesPerAltShop, P00465_A270ProfesionalesFeedback, P00465_A267ProfesionalesVerDatPerSol, P00465_A108EstadosGenericosId, P00465_A198ProfesionalesDireccion, P00465_A193ProfesionalesEmail, P00465_n193ProfesionalesEmail,
               P00465_A170ProfesionalesTelefono, P00465_A192ProfesionalesApellidoSegundo, P00465_A191ProfesionalesSegundoNombre, P00465_A166ProfesionalesPrimerNombre, P00465_A120ProfesionalesId, P00465_A269ProfesionalesFeedBackProm, P00465_A268ProfesionalesFeedBackCant
               }
               , new Object[] {
               P00466_A121RubrosId, P00466_A192ProfesionalesApellidoSegundo, P00466_A436ProfesionalesPerAltShop, P00466_n436ProfesionalesPerAltShop, P00466_A270ProfesionalesFeedback, P00466_A267ProfesionalesVerDatPerSol, P00466_A108EstadosGenericosId, P00466_A198ProfesionalesDireccion, P00466_A193ProfesionalesEmail, P00466_n193ProfesionalesEmail,
               P00466_A170ProfesionalesTelefono, P00466_A167ProfesionalesApellidoPrimero, P00466_A191ProfesionalesSegundoNombre, P00466_A166ProfesionalesPrimerNombre, P00466_A120ProfesionalesId, P00466_A269ProfesionalesFeedBackProm, P00466_A268ProfesionalesFeedBackCant
               }
               , new Object[] {
               P00467_A121RubrosId, P00467_A170ProfesionalesTelefono, P00467_A436ProfesionalesPerAltShop, P00467_n436ProfesionalesPerAltShop, P00467_A270ProfesionalesFeedback, P00467_A267ProfesionalesVerDatPerSol, P00467_A108EstadosGenericosId, P00467_A198ProfesionalesDireccion, P00467_A193ProfesionalesEmail, P00467_n193ProfesionalesEmail,
               P00467_A192ProfesionalesApellidoSegundo, P00467_A167ProfesionalesApellidoPrimero, P00467_A191ProfesionalesSegundoNombre, P00467_A166ProfesionalesPrimerNombre, P00467_A120ProfesionalesId, P00467_A269ProfesionalesFeedBackProm, P00467_A268ProfesionalesFeedBackCant
               }
               , new Object[] {
               P00468_A121RubrosId, P00468_A193ProfesionalesEmail, P00468_n193ProfesionalesEmail, P00468_A436ProfesionalesPerAltShop, P00468_n436ProfesionalesPerAltShop, P00468_A270ProfesionalesFeedback, P00468_A267ProfesionalesVerDatPerSol, P00468_A108EstadosGenericosId, P00468_A198ProfesionalesDireccion, P00468_A170ProfesionalesTelefono,
               P00468_A192ProfesionalesApellidoSegundo, P00468_A167ProfesionalesApellidoPrimero, P00468_A191ProfesionalesSegundoNombre, P00468_A166ProfesionalesPrimerNombre, P00468_A120ProfesionalesId, P00468_A269ProfesionalesFeedBackProm, P00468_A268ProfesionalesFeedBackCant
               }
               , new Object[] {
               P00469_A121RubrosId, P00469_A198ProfesionalesDireccion, P00469_A436ProfesionalesPerAltShop, P00469_n436ProfesionalesPerAltShop, P00469_A270ProfesionalesFeedback, P00469_A267ProfesionalesVerDatPerSol, P00469_A108EstadosGenericosId, P00469_A193ProfesionalesEmail, P00469_n193ProfesionalesEmail, P00469_A170ProfesionalesTelefono,
               P00469_A192ProfesionalesApellidoSegundo, P00469_A167ProfesionalesApellidoPrimero, P00469_A191ProfesionalesSegundoNombre, P00469_A166ProfesionalesPrimerNombre, P00469_A120ProfesionalesId, P00469_A269ProfesionalesFeedBackProm, P00469_A268ProfesionalesFeedBackCant
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV40MaxItems ;
      private short AV39PageIndex ;
      private short AV38SkipItems ;
      private short AV60RubrosId ;
      private short A121RubrosId ;
      private int AV61GXV1 ;
      private int AV27TFEstadosGenericosId ;
      private int AV28TFEstadosGenericosId_To ;
      private int GXPagingFrom2 ;
      private int GXPagingTo2 ;
      private int GXPagingIdx2 ;
      private int AV30TFProfesionalesVerDatPerSol_Sels_Count ;
      private int AV36TFProfesionalesPerAltShop_Sels_Count ;
      private int A108EstadosGenericosId ;
      private long AV31TFProfesionalesFeedBackCant ;
      private long AV32TFProfesionalesFeedBackCant_To ;
      private long A268ProfesionalesFeedBackCant ;
      private long AV47count ;
      private decimal AV33TFProfesionalesFeedback ;
      private decimal AV34TFProfesionalesFeedback_To ;
      private decimal A269ProfesionalesFeedBackProm ;
      private decimal A270ProfesionalesFeedback ;
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
      private string A267ProfesionalesVerDatPerSol ;
      private string A436ProfesionalesPerAltShop ;
      private string A120ProfesionalesId ;
      private string A166ProfesionalesPrimerNombre ;
      private string A191ProfesionalesSegundoNombre ;
      private string A167ProfesionalesApellidoPrimero ;
      private string A192ProfesionalesApellidoSegundo ;
      private string A170ProfesionalesTelefono ;
      private bool AV8IsAuthorized ;
      private bool GXt_boolean1 ;
      private bool returnInSub ;
      private bool n436ProfesionalesPerAltShop ;
      private bool n193ProfesionalesEmail ;
      private bool BRK463 ;
      private bool BRK465 ;
      private bool BRK467 ;
      private bool BRK469 ;
      private bool BRK4611 ;
      private bool BRK4613 ;
      private bool BRK4615 ;
      private string AV56OptionsJson ;
      private string AV57OptionsDescJson ;
      private string AV58OptionIndexesJson ;
      private string AV29TFProfesionalesVerDatPerSol_SelsJson ;
      private string AV35TFProfesionalesPerAltShop_SelsJson ;
      private string AV53DDOName ;
      private string AV54SearchTxtParms ;
      private string AV55SearchTxtTo ;
      private string AV37SearchTxt ;
      private string AV59FilterFullText ;
      private string AV23TFProfesionalesEmail ;
      private string AV24TFProfesionalesEmail_Sel ;
      private string AV25TFProfesionalesDireccion ;
      private string AV26TFProfesionalesDireccion_Sel ;
      private string lV23TFProfesionalesEmail ;
      private string lV25TFProfesionalesDireccion ;
      private string A193ProfesionalesEmail ;
      private string A198ProfesionalesDireccion ;
      private string AV42Option ;
      private IGxSession AV48Session ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GxSimpleCollection<string> AV43Options ;
      private GxSimpleCollection<string> AV45OptionsDesc ;
      private GxSimpleCollection<string> AV46OptionIndexes ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV50GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV51GridStateFilterValue ;
      private GxSimpleCollection<string> AV30TFProfesionalesVerDatPerSol_Sels ;
      private GxSimpleCollection<string> AV36TFProfesionalesPerAltShop_Sels ;
      private IDataStoreProvider pr_default ;
      private short[] P00462_A121RubrosId ;
      private string[] P00462_A436ProfesionalesPerAltShop ;
      private bool[] P00462_n436ProfesionalesPerAltShop ;
      private decimal[] P00462_A270ProfesionalesFeedback ;
      private string[] P00462_A267ProfesionalesVerDatPerSol ;
      private int[] P00462_A108EstadosGenericosId ;
      private string[] P00462_A198ProfesionalesDireccion ;
      private string[] P00462_A193ProfesionalesEmail ;
      private bool[] P00462_n193ProfesionalesEmail ;
      private string[] P00462_A170ProfesionalesTelefono ;
      private string[] P00462_A192ProfesionalesApellidoSegundo ;
      private string[] P00462_A167ProfesionalesApellidoPrimero ;
      private string[] P00462_A191ProfesionalesSegundoNombre ;
      private string[] P00462_A166ProfesionalesPrimerNombre ;
      private string[] P00462_A120ProfesionalesId ;
      private decimal[] P00462_A269ProfesionalesFeedBackProm ;
      private long[] P00462_A268ProfesionalesFeedBackCant ;
      private short[] P00463_A121RubrosId ;
      private string[] P00463_A166ProfesionalesPrimerNombre ;
      private string[] P00463_A436ProfesionalesPerAltShop ;
      private bool[] P00463_n436ProfesionalesPerAltShop ;
      private decimal[] P00463_A270ProfesionalesFeedback ;
      private string[] P00463_A267ProfesionalesVerDatPerSol ;
      private int[] P00463_A108EstadosGenericosId ;
      private string[] P00463_A198ProfesionalesDireccion ;
      private string[] P00463_A193ProfesionalesEmail ;
      private bool[] P00463_n193ProfesionalesEmail ;
      private string[] P00463_A170ProfesionalesTelefono ;
      private string[] P00463_A192ProfesionalesApellidoSegundo ;
      private string[] P00463_A167ProfesionalesApellidoPrimero ;
      private string[] P00463_A191ProfesionalesSegundoNombre ;
      private string[] P00463_A120ProfesionalesId ;
      private decimal[] P00463_A269ProfesionalesFeedBackProm ;
      private long[] P00463_A268ProfesionalesFeedBackCant ;
      private short[] P00464_A121RubrosId ;
      private string[] P00464_A191ProfesionalesSegundoNombre ;
      private string[] P00464_A436ProfesionalesPerAltShop ;
      private bool[] P00464_n436ProfesionalesPerAltShop ;
      private decimal[] P00464_A270ProfesionalesFeedback ;
      private string[] P00464_A267ProfesionalesVerDatPerSol ;
      private int[] P00464_A108EstadosGenericosId ;
      private string[] P00464_A198ProfesionalesDireccion ;
      private string[] P00464_A193ProfesionalesEmail ;
      private bool[] P00464_n193ProfesionalesEmail ;
      private string[] P00464_A170ProfesionalesTelefono ;
      private string[] P00464_A192ProfesionalesApellidoSegundo ;
      private string[] P00464_A167ProfesionalesApellidoPrimero ;
      private string[] P00464_A166ProfesionalesPrimerNombre ;
      private string[] P00464_A120ProfesionalesId ;
      private decimal[] P00464_A269ProfesionalesFeedBackProm ;
      private long[] P00464_A268ProfesionalesFeedBackCant ;
      private short[] P00465_A121RubrosId ;
      private string[] P00465_A167ProfesionalesApellidoPrimero ;
      private string[] P00465_A436ProfesionalesPerAltShop ;
      private bool[] P00465_n436ProfesionalesPerAltShop ;
      private decimal[] P00465_A270ProfesionalesFeedback ;
      private string[] P00465_A267ProfesionalesVerDatPerSol ;
      private int[] P00465_A108EstadosGenericosId ;
      private string[] P00465_A198ProfesionalesDireccion ;
      private string[] P00465_A193ProfesionalesEmail ;
      private bool[] P00465_n193ProfesionalesEmail ;
      private string[] P00465_A170ProfesionalesTelefono ;
      private string[] P00465_A192ProfesionalesApellidoSegundo ;
      private string[] P00465_A191ProfesionalesSegundoNombre ;
      private string[] P00465_A166ProfesionalesPrimerNombre ;
      private string[] P00465_A120ProfesionalesId ;
      private decimal[] P00465_A269ProfesionalesFeedBackProm ;
      private long[] P00465_A268ProfesionalesFeedBackCant ;
      private short[] P00466_A121RubrosId ;
      private string[] P00466_A192ProfesionalesApellidoSegundo ;
      private string[] P00466_A436ProfesionalesPerAltShop ;
      private bool[] P00466_n436ProfesionalesPerAltShop ;
      private decimal[] P00466_A270ProfesionalesFeedback ;
      private string[] P00466_A267ProfesionalesVerDatPerSol ;
      private int[] P00466_A108EstadosGenericosId ;
      private string[] P00466_A198ProfesionalesDireccion ;
      private string[] P00466_A193ProfesionalesEmail ;
      private bool[] P00466_n193ProfesionalesEmail ;
      private string[] P00466_A170ProfesionalesTelefono ;
      private string[] P00466_A167ProfesionalesApellidoPrimero ;
      private string[] P00466_A191ProfesionalesSegundoNombre ;
      private string[] P00466_A166ProfesionalesPrimerNombre ;
      private string[] P00466_A120ProfesionalesId ;
      private decimal[] P00466_A269ProfesionalesFeedBackProm ;
      private long[] P00466_A268ProfesionalesFeedBackCant ;
      private short[] P00467_A121RubrosId ;
      private string[] P00467_A170ProfesionalesTelefono ;
      private string[] P00467_A436ProfesionalesPerAltShop ;
      private bool[] P00467_n436ProfesionalesPerAltShop ;
      private decimal[] P00467_A270ProfesionalesFeedback ;
      private string[] P00467_A267ProfesionalesVerDatPerSol ;
      private int[] P00467_A108EstadosGenericosId ;
      private string[] P00467_A198ProfesionalesDireccion ;
      private string[] P00467_A193ProfesionalesEmail ;
      private bool[] P00467_n193ProfesionalesEmail ;
      private string[] P00467_A192ProfesionalesApellidoSegundo ;
      private string[] P00467_A167ProfesionalesApellidoPrimero ;
      private string[] P00467_A191ProfesionalesSegundoNombre ;
      private string[] P00467_A166ProfesionalesPrimerNombre ;
      private string[] P00467_A120ProfesionalesId ;
      private decimal[] P00467_A269ProfesionalesFeedBackProm ;
      private long[] P00467_A268ProfesionalesFeedBackCant ;
      private short[] P00468_A121RubrosId ;
      private string[] P00468_A193ProfesionalesEmail ;
      private bool[] P00468_n193ProfesionalesEmail ;
      private string[] P00468_A436ProfesionalesPerAltShop ;
      private bool[] P00468_n436ProfesionalesPerAltShop ;
      private decimal[] P00468_A270ProfesionalesFeedback ;
      private string[] P00468_A267ProfesionalesVerDatPerSol ;
      private int[] P00468_A108EstadosGenericosId ;
      private string[] P00468_A198ProfesionalesDireccion ;
      private string[] P00468_A170ProfesionalesTelefono ;
      private string[] P00468_A192ProfesionalesApellidoSegundo ;
      private string[] P00468_A167ProfesionalesApellidoPrimero ;
      private string[] P00468_A191ProfesionalesSegundoNombre ;
      private string[] P00468_A166ProfesionalesPrimerNombre ;
      private string[] P00468_A120ProfesionalesId ;
      private decimal[] P00468_A269ProfesionalesFeedBackProm ;
      private long[] P00468_A268ProfesionalesFeedBackCant ;
      private short[] P00469_A121RubrosId ;
      private string[] P00469_A198ProfesionalesDireccion ;
      private string[] P00469_A436ProfesionalesPerAltShop ;
      private bool[] P00469_n436ProfesionalesPerAltShop ;
      private decimal[] P00469_A270ProfesionalesFeedback ;
      private string[] P00469_A267ProfesionalesVerDatPerSol ;
      private int[] P00469_A108EstadosGenericosId ;
      private string[] P00469_A193ProfesionalesEmail ;
      private bool[] P00469_n193ProfesionalesEmail ;
      private string[] P00469_A170ProfesionalesTelefono ;
      private string[] P00469_A192ProfesionalesApellidoSegundo ;
      private string[] P00469_A167ProfesionalesApellidoPrimero ;
      private string[] P00469_A191ProfesionalesSegundoNombre ;
      private string[] P00469_A166ProfesionalesPrimerNombre ;
      private string[] P00469_A120ProfesionalesId ;
      private decimal[] P00469_A269ProfesionalesFeedBackProm ;
      private long[] P00469_A268ProfesionalesFeedBackCant ;
      private string aP3_OptionsJson ;
      private string aP4_OptionsDescJson ;
      private string aP5_OptionIndexesJson ;
   }

   public class rubrosrubroswcgetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00462( IGxContext context ,
                                             string A267ProfesionalesVerDatPerSol ,
                                             GxSimpleCollection<string> AV30TFProfesionalesVerDatPerSol_Sels ,
                                             string A436ProfesionalesPerAltShop ,
                                             GxSimpleCollection<string> AV36TFProfesionalesPerAltShop_Sels ,
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
                                             string AV26TFProfesionalesDireccion_Sel ,
                                             string AV25TFProfesionalesDireccion ,
                                             int AV27TFEstadosGenericosId ,
                                             int AV28TFEstadosGenericosId_To ,
                                             int AV30TFProfesionalesVerDatPerSol_Sels_Count ,
                                             long AV31TFProfesionalesFeedBackCant ,
                                             long AV32TFProfesionalesFeedBackCant_To ,
                                             decimal AV33TFProfesionalesFeedback ,
                                             decimal AV34TFProfesionalesFeedback_To ,
                                             int AV36TFProfesionalesPerAltShop_Sels_Count ,
                                             string A120ProfesionalesId ,
                                             string A166ProfesionalesPrimerNombre ,
                                             string A191ProfesionalesSegundoNombre ,
                                             string A167ProfesionalesApellidoPrimero ,
                                             string A192ProfesionalesApellidoSegundo ,
                                             string A170ProfesionalesTelefono ,
                                             string A193ProfesionalesEmail ,
                                             string A198ProfesionalesDireccion ,
                                             int A108EstadosGenericosId ,
                                             long A268ProfesionalesFeedBackCant ,
                                             decimal A269ProfesionalesFeedBackProm ,
                                             string AV59FilterFullText ,
                                             decimal A270ProfesionalesFeedback ,
                                             short AV60RubrosId ,
                                             short A121RubrosId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int2 = new short[23];
         Object[] GXv_Object3 = new Object[2];
         scmdbuf = "SELECT DISTINCT NULL AS [RubrosId], NULL AS [ProfesionalesPerAltShop], NULL AS [ProfesionalesFeedback], NULL AS [ProfesionalesVerDatPerSol], NULL AS [EstadosGenericosId], NULL AS [ProfesionalesDireccion], NULL AS [ProfesionalesEmail], NULL AS [ProfesionalesTelefono], NULL AS [ProfesionalesApellidoSegundo], NULL AS [ProfesionalesApellidoPrimero], NULL AS [ProfesionalesSegundoNombre], NULL AS [ProfesionalesPrimerNombre], [ProfesionalesId], NULL AS [ProfesionalesFeedBackProm], NULL AS [ProfesionalesFeedBackCant] FROM ( SELECT TOP(100) PERCENT T1.[RubrosId], T2.[ProfesionalesPerAltShop], CASE  WHEN T2.[ProfesionalesFeedBackCant] > 0 THEN CAST(T2.[ProfesionalesFeedBackProm] AS decimal( 28, 10)) / T2.[ProfesionalesFeedBackCant] END AS ProfesionalesFeedback, T2.[ProfesionalesVerDatPerSol], T2.[EstadosGenericosId], T2.[ProfesionalesDireccion], T2.[ProfesionalesEmail], T2.[ProfesionalesTelefono], T2.[ProfesionalesApellidoSegundo], T2.[ProfesionalesApellidoPrimero], T2.[ProfesionalesSegundoNombre], T2.[ProfesionalesPrimerNombre], T1.[ProfesionalesId], T2.[ProfesionalesFeedBackProm], T2.[ProfesionalesFeedBackCant] FROM ([ProfesionalesRubros] T1 INNER JOIN [Profesionales] T2 ON T2.[ProfesionalesId] = T1.[ProfesionalesId])";
         AddWhere(sWhereString, "(T1.[RubrosId] = @AV60RubrosId)");
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
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV24TFProfesionalesEmail_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV23TFProfesionalesEmail)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ProfesionalesEmail]) like UPPER(@lV23TFProfesionalesEmail))");
         }
         else
         {
            GXv_int2[13] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV24TFProfesionalesEmail_Sel)) && ! ( StringUtil.StrCmp(AV24TFProfesionalesEmail_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.[ProfesionalesEmail] = @AV24TFProfesionalesEmail_Sel)");
         }
         else
         {
            GXv_int2[14] = 1;
         }
         if ( StringUtil.StrCmp(AV24TFProfesionalesEmail_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T2.[ProfesionalesEmail] IS NULL or (T2.[ProfesionalesEmail] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV26TFProfesionalesDireccion_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV25TFProfesionalesDireccion)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ProfesionalesDireccion]) like UPPER(@lV25TFProfesionalesDireccion))");
         }
         else
         {
            GXv_int2[15] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV26TFProfesionalesDireccion_Sel)) && ! ( StringUtil.StrCmp(AV26TFProfesionalesDireccion_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.[ProfesionalesDireccion] = @AV26TFProfesionalesDireccion_Sel)");
         }
         else
         {
            GXv_int2[16] = 1;
         }
         if ( StringUtil.StrCmp(AV26TFProfesionalesDireccion_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T2.[ProfesionalesDireccion] = ''))");
         }
         if ( ! (0==AV27TFEstadosGenericosId) )
         {
            AddWhere(sWhereString, "(T2.[EstadosGenericosId] >= @AV27TFEstadosGenericosId)");
         }
         else
         {
            GXv_int2[17] = 1;
         }
         if ( ! (0==AV28TFEstadosGenericosId_To) )
         {
            AddWhere(sWhereString, "(T2.[EstadosGenericosId] <= @AV28TFEstadosGenericosId_To)");
         }
         else
         {
            GXv_int2[18] = 1;
         }
         if ( AV30TFProfesionalesVerDatPerSol_Sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV30TFProfesionalesVerDatPerSol_Sels, "T2.[ProfesionalesVerDatPerSol] IN (", ")")+")");
         }
         if ( ! (0==AV31TFProfesionalesFeedBackCant) )
         {
            AddWhere(sWhereString, "(T2.[ProfesionalesFeedBackCant] >= @AV31TFProfesionalesFeedBackCant)");
         }
         else
         {
            GXv_int2[19] = 1;
         }
         if ( ! (0==AV32TFProfesionalesFeedBackCant_To) )
         {
            AddWhere(sWhereString, "(T2.[ProfesionalesFeedBackCant] <= @AV32TFProfesionalesFeedBackCant_To)");
         }
         else
         {
            GXv_int2[20] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV33TFProfesionalesFeedback) )
         {
            AddWhere(sWhereString, "(( CASE  WHEN T2.[ProfesionalesFeedBackCant] > 0 THEN CAST(T2.[ProfesionalesFeedBackProm] AS decimal( 28, 10)) / T2.[ProfesionalesFeedBackCant] END) >= @AV33TFProfesionalesFeedback)");
         }
         else
         {
            GXv_int2[21] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV34TFProfesionalesFeedback_To) )
         {
            AddWhere(sWhereString, "(( CASE  WHEN T2.[ProfesionalesFeedBackCant] > 0 THEN CAST(T2.[ProfesionalesFeedBackProm] AS decimal( 28, 10)) / T2.[ProfesionalesFeedBackCant] END) <= @AV34TFProfesionalesFeedback_To)");
         }
         else
         {
            GXv_int2[22] = 1;
         }
         if ( AV36TFProfesionalesPerAltShop_Sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV36TFProfesionalesPerAltShop_Sels, "T2.[ProfesionalesPerAltShop] IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[RubrosId], T1.[ProfesionalesId]";
         scmdbuf += ") DistinctT";
         scmdbuf += " ORDER BY [ProfesionalesId]";
         GXv_Object3[0] = scmdbuf;
         GXv_Object3[1] = GXv_int2;
         return GXv_Object3 ;
      }

      protected Object[] conditional_P00463( IGxContext context ,
                                             string A267ProfesionalesVerDatPerSol ,
                                             GxSimpleCollection<string> AV30TFProfesionalesVerDatPerSol_Sels ,
                                             string A436ProfesionalesPerAltShop ,
                                             GxSimpleCollection<string> AV36TFProfesionalesPerAltShop_Sels ,
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
                                             string AV26TFProfesionalesDireccion_Sel ,
                                             string AV25TFProfesionalesDireccion ,
                                             int AV27TFEstadosGenericosId ,
                                             int AV28TFEstadosGenericosId_To ,
                                             int AV30TFProfesionalesVerDatPerSol_Sels_Count ,
                                             long AV31TFProfesionalesFeedBackCant ,
                                             long AV32TFProfesionalesFeedBackCant_To ,
                                             decimal AV33TFProfesionalesFeedback ,
                                             decimal AV34TFProfesionalesFeedback_To ,
                                             int AV36TFProfesionalesPerAltShop_Sels_Count ,
                                             string A120ProfesionalesId ,
                                             string A166ProfesionalesPrimerNombre ,
                                             string A191ProfesionalesSegundoNombre ,
                                             string A167ProfesionalesApellidoPrimero ,
                                             string A192ProfesionalesApellidoSegundo ,
                                             string A170ProfesionalesTelefono ,
                                             string A193ProfesionalesEmail ,
                                             string A198ProfesionalesDireccion ,
                                             int A108EstadosGenericosId ,
                                             long A268ProfesionalesFeedBackCant ,
                                             decimal A269ProfesionalesFeedBackProm ,
                                             string AV59FilterFullText ,
                                             decimal A270ProfesionalesFeedback ,
                                             short AV60RubrosId ,
                                             short A121RubrosId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int4 = new short[23];
         Object[] GXv_Object5 = new Object[2];
         scmdbuf = "SELECT T1.[RubrosId], T2.[ProfesionalesPrimerNombre], T2.[ProfesionalesPerAltShop], CASE  WHEN T2.[ProfesionalesFeedBackCant] > 0 THEN CAST(T2.[ProfesionalesFeedBackProm] AS decimal( 28, 10)) / T2.[ProfesionalesFeedBackCant] END AS ProfesionalesFeedback, T2.[ProfesionalesVerDatPerSol], T2.[EstadosGenericosId], T2.[ProfesionalesDireccion], T2.[ProfesionalesEmail], T2.[ProfesionalesTelefono], T2.[ProfesionalesApellidoSegundo], T2.[ProfesionalesApellidoPrimero], T2.[ProfesionalesSegundoNombre], T1.[ProfesionalesId], T2.[ProfesionalesFeedBackProm], T2.[ProfesionalesFeedBackCant] FROM ([ProfesionalesRubros] T1 INNER JOIN [Profesionales] T2 ON T2.[ProfesionalesId] = T1.[ProfesionalesId])";
         AddWhere(sWhereString, "(T1.[RubrosId] = @AV60RubrosId)");
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
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV24TFProfesionalesEmail_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV23TFProfesionalesEmail)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ProfesionalesEmail]) like UPPER(@lV23TFProfesionalesEmail))");
         }
         else
         {
            GXv_int4[13] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV24TFProfesionalesEmail_Sel)) && ! ( StringUtil.StrCmp(AV24TFProfesionalesEmail_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.[ProfesionalesEmail] = @AV24TFProfesionalesEmail_Sel)");
         }
         else
         {
            GXv_int4[14] = 1;
         }
         if ( StringUtil.StrCmp(AV24TFProfesionalesEmail_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T2.[ProfesionalesEmail] IS NULL or (T2.[ProfesionalesEmail] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV26TFProfesionalesDireccion_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV25TFProfesionalesDireccion)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ProfesionalesDireccion]) like UPPER(@lV25TFProfesionalesDireccion))");
         }
         else
         {
            GXv_int4[15] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV26TFProfesionalesDireccion_Sel)) && ! ( StringUtil.StrCmp(AV26TFProfesionalesDireccion_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.[ProfesionalesDireccion] = @AV26TFProfesionalesDireccion_Sel)");
         }
         else
         {
            GXv_int4[16] = 1;
         }
         if ( StringUtil.StrCmp(AV26TFProfesionalesDireccion_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T2.[ProfesionalesDireccion] = ''))");
         }
         if ( ! (0==AV27TFEstadosGenericosId) )
         {
            AddWhere(sWhereString, "(T2.[EstadosGenericosId] >= @AV27TFEstadosGenericosId)");
         }
         else
         {
            GXv_int4[17] = 1;
         }
         if ( ! (0==AV28TFEstadosGenericosId_To) )
         {
            AddWhere(sWhereString, "(T2.[EstadosGenericosId] <= @AV28TFEstadosGenericosId_To)");
         }
         else
         {
            GXv_int4[18] = 1;
         }
         if ( AV30TFProfesionalesVerDatPerSol_Sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV30TFProfesionalesVerDatPerSol_Sels, "T2.[ProfesionalesVerDatPerSol] IN (", ")")+")");
         }
         if ( ! (0==AV31TFProfesionalesFeedBackCant) )
         {
            AddWhere(sWhereString, "(T2.[ProfesionalesFeedBackCant] >= @AV31TFProfesionalesFeedBackCant)");
         }
         else
         {
            GXv_int4[19] = 1;
         }
         if ( ! (0==AV32TFProfesionalesFeedBackCant_To) )
         {
            AddWhere(sWhereString, "(T2.[ProfesionalesFeedBackCant] <= @AV32TFProfesionalesFeedBackCant_To)");
         }
         else
         {
            GXv_int4[20] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV33TFProfesionalesFeedback) )
         {
            AddWhere(sWhereString, "(( CASE  WHEN T2.[ProfesionalesFeedBackCant] > 0 THEN CAST(T2.[ProfesionalesFeedBackProm] AS decimal( 28, 10)) / T2.[ProfesionalesFeedBackCant] END) >= @AV33TFProfesionalesFeedback)");
         }
         else
         {
            GXv_int4[21] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV34TFProfesionalesFeedback_To) )
         {
            AddWhere(sWhereString, "(( CASE  WHEN T2.[ProfesionalesFeedBackCant] > 0 THEN CAST(T2.[ProfesionalesFeedBackProm] AS decimal( 28, 10)) / T2.[ProfesionalesFeedBackCant] END) <= @AV34TFProfesionalesFeedback_To)");
         }
         else
         {
            GXv_int4[22] = 1;
         }
         if ( AV36TFProfesionalesPerAltShop_Sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV36TFProfesionalesPerAltShop_Sels, "T2.[ProfesionalesPerAltShop] IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[RubrosId], T2.[ProfesionalesPrimerNombre]";
         GXv_Object5[0] = scmdbuf;
         GXv_Object5[1] = GXv_int4;
         return GXv_Object5 ;
      }

      protected Object[] conditional_P00464( IGxContext context ,
                                             string A267ProfesionalesVerDatPerSol ,
                                             GxSimpleCollection<string> AV30TFProfesionalesVerDatPerSol_Sels ,
                                             string A436ProfesionalesPerAltShop ,
                                             GxSimpleCollection<string> AV36TFProfesionalesPerAltShop_Sels ,
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
                                             string AV26TFProfesionalesDireccion_Sel ,
                                             string AV25TFProfesionalesDireccion ,
                                             int AV27TFEstadosGenericosId ,
                                             int AV28TFEstadosGenericosId_To ,
                                             int AV30TFProfesionalesVerDatPerSol_Sels_Count ,
                                             long AV31TFProfesionalesFeedBackCant ,
                                             long AV32TFProfesionalesFeedBackCant_To ,
                                             decimal AV33TFProfesionalesFeedback ,
                                             decimal AV34TFProfesionalesFeedback_To ,
                                             int AV36TFProfesionalesPerAltShop_Sels_Count ,
                                             string A120ProfesionalesId ,
                                             string A166ProfesionalesPrimerNombre ,
                                             string A191ProfesionalesSegundoNombre ,
                                             string A167ProfesionalesApellidoPrimero ,
                                             string A192ProfesionalesApellidoSegundo ,
                                             string A170ProfesionalesTelefono ,
                                             string A193ProfesionalesEmail ,
                                             string A198ProfesionalesDireccion ,
                                             int A108EstadosGenericosId ,
                                             long A268ProfesionalesFeedBackCant ,
                                             decimal A269ProfesionalesFeedBackProm ,
                                             string AV59FilterFullText ,
                                             decimal A270ProfesionalesFeedback ,
                                             short AV60RubrosId ,
                                             short A121RubrosId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int6 = new short[23];
         Object[] GXv_Object7 = new Object[2];
         scmdbuf = "SELECT T1.[RubrosId], T2.[ProfesionalesSegundoNombre], T2.[ProfesionalesPerAltShop], CASE  WHEN T2.[ProfesionalesFeedBackCant] > 0 THEN CAST(T2.[ProfesionalesFeedBackProm] AS decimal( 28, 10)) / T2.[ProfesionalesFeedBackCant] END AS ProfesionalesFeedback, T2.[ProfesionalesVerDatPerSol], T2.[EstadosGenericosId], T2.[ProfesionalesDireccion], T2.[ProfesionalesEmail], T2.[ProfesionalesTelefono], T2.[ProfesionalesApellidoSegundo], T2.[ProfesionalesApellidoPrimero], T2.[ProfesionalesPrimerNombre], T1.[ProfesionalesId], T2.[ProfesionalesFeedBackProm], T2.[ProfesionalesFeedBackCant] FROM ([ProfesionalesRubros] T1 INNER JOIN [Profesionales] T2 ON T2.[ProfesionalesId] = T1.[ProfesionalesId])";
         AddWhere(sWhereString, "(T1.[RubrosId] = @AV60RubrosId)");
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
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV24TFProfesionalesEmail_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV23TFProfesionalesEmail)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ProfesionalesEmail]) like UPPER(@lV23TFProfesionalesEmail))");
         }
         else
         {
            GXv_int6[13] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV24TFProfesionalesEmail_Sel)) && ! ( StringUtil.StrCmp(AV24TFProfesionalesEmail_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.[ProfesionalesEmail] = @AV24TFProfesionalesEmail_Sel)");
         }
         else
         {
            GXv_int6[14] = 1;
         }
         if ( StringUtil.StrCmp(AV24TFProfesionalesEmail_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T2.[ProfesionalesEmail] IS NULL or (T2.[ProfesionalesEmail] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV26TFProfesionalesDireccion_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV25TFProfesionalesDireccion)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ProfesionalesDireccion]) like UPPER(@lV25TFProfesionalesDireccion))");
         }
         else
         {
            GXv_int6[15] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV26TFProfesionalesDireccion_Sel)) && ! ( StringUtil.StrCmp(AV26TFProfesionalesDireccion_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.[ProfesionalesDireccion] = @AV26TFProfesionalesDireccion_Sel)");
         }
         else
         {
            GXv_int6[16] = 1;
         }
         if ( StringUtil.StrCmp(AV26TFProfesionalesDireccion_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T2.[ProfesionalesDireccion] = ''))");
         }
         if ( ! (0==AV27TFEstadosGenericosId) )
         {
            AddWhere(sWhereString, "(T2.[EstadosGenericosId] >= @AV27TFEstadosGenericosId)");
         }
         else
         {
            GXv_int6[17] = 1;
         }
         if ( ! (0==AV28TFEstadosGenericosId_To) )
         {
            AddWhere(sWhereString, "(T2.[EstadosGenericosId] <= @AV28TFEstadosGenericosId_To)");
         }
         else
         {
            GXv_int6[18] = 1;
         }
         if ( AV30TFProfesionalesVerDatPerSol_Sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV30TFProfesionalesVerDatPerSol_Sels, "T2.[ProfesionalesVerDatPerSol] IN (", ")")+")");
         }
         if ( ! (0==AV31TFProfesionalesFeedBackCant) )
         {
            AddWhere(sWhereString, "(T2.[ProfesionalesFeedBackCant] >= @AV31TFProfesionalesFeedBackCant)");
         }
         else
         {
            GXv_int6[19] = 1;
         }
         if ( ! (0==AV32TFProfesionalesFeedBackCant_To) )
         {
            AddWhere(sWhereString, "(T2.[ProfesionalesFeedBackCant] <= @AV32TFProfesionalesFeedBackCant_To)");
         }
         else
         {
            GXv_int6[20] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV33TFProfesionalesFeedback) )
         {
            AddWhere(sWhereString, "(( CASE  WHEN T2.[ProfesionalesFeedBackCant] > 0 THEN CAST(T2.[ProfesionalesFeedBackProm] AS decimal( 28, 10)) / T2.[ProfesionalesFeedBackCant] END) >= @AV33TFProfesionalesFeedback)");
         }
         else
         {
            GXv_int6[21] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV34TFProfesionalesFeedback_To) )
         {
            AddWhere(sWhereString, "(( CASE  WHEN T2.[ProfesionalesFeedBackCant] > 0 THEN CAST(T2.[ProfesionalesFeedBackProm] AS decimal( 28, 10)) / T2.[ProfesionalesFeedBackCant] END) <= @AV34TFProfesionalesFeedback_To)");
         }
         else
         {
            GXv_int6[22] = 1;
         }
         if ( AV36TFProfesionalesPerAltShop_Sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV36TFProfesionalesPerAltShop_Sels, "T2.[ProfesionalesPerAltShop] IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[RubrosId], T2.[ProfesionalesSegundoNombre]";
         GXv_Object7[0] = scmdbuf;
         GXv_Object7[1] = GXv_int6;
         return GXv_Object7 ;
      }

      protected Object[] conditional_P00465( IGxContext context ,
                                             string A267ProfesionalesVerDatPerSol ,
                                             GxSimpleCollection<string> AV30TFProfesionalesVerDatPerSol_Sels ,
                                             string A436ProfesionalesPerAltShop ,
                                             GxSimpleCollection<string> AV36TFProfesionalesPerAltShop_Sels ,
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
                                             string AV26TFProfesionalesDireccion_Sel ,
                                             string AV25TFProfesionalesDireccion ,
                                             int AV27TFEstadosGenericosId ,
                                             int AV28TFEstadosGenericosId_To ,
                                             int AV30TFProfesionalesVerDatPerSol_Sels_Count ,
                                             long AV31TFProfesionalesFeedBackCant ,
                                             long AV32TFProfesionalesFeedBackCant_To ,
                                             decimal AV33TFProfesionalesFeedback ,
                                             decimal AV34TFProfesionalesFeedback_To ,
                                             int AV36TFProfesionalesPerAltShop_Sels_Count ,
                                             string A120ProfesionalesId ,
                                             string A166ProfesionalesPrimerNombre ,
                                             string A191ProfesionalesSegundoNombre ,
                                             string A167ProfesionalesApellidoPrimero ,
                                             string A192ProfesionalesApellidoSegundo ,
                                             string A170ProfesionalesTelefono ,
                                             string A193ProfesionalesEmail ,
                                             string A198ProfesionalesDireccion ,
                                             int A108EstadosGenericosId ,
                                             long A268ProfesionalesFeedBackCant ,
                                             decimal A269ProfesionalesFeedBackProm ,
                                             string AV59FilterFullText ,
                                             decimal A270ProfesionalesFeedback ,
                                             short AV60RubrosId ,
                                             short A121RubrosId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int8 = new short[23];
         Object[] GXv_Object9 = new Object[2];
         scmdbuf = "SELECT T1.[RubrosId], T2.[ProfesionalesApellidoPrimero], T2.[ProfesionalesPerAltShop], CASE  WHEN T2.[ProfesionalesFeedBackCant] > 0 THEN CAST(T2.[ProfesionalesFeedBackProm] AS decimal( 28, 10)) / T2.[ProfesionalesFeedBackCant] END AS ProfesionalesFeedback, T2.[ProfesionalesVerDatPerSol], T2.[EstadosGenericosId], T2.[ProfesionalesDireccion], T2.[ProfesionalesEmail], T2.[ProfesionalesTelefono], T2.[ProfesionalesApellidoSegundo], T2.[ProfesionalesSegundoNombre], T2.[ProfesionalesPrimerNombre], T1.[ProfesionalesId], T2.[ProfesionalesFeedBackProm], T2.[ProfesionalesFeedBackCant] FROM ([ProfesionalesRubros] T1 INNER JOIN [Profesionales] T2 ON T2.[ProfesionalesId] = T1.[ProfesionalesId])";
         AddWhere(sWhereString, "(T1.[RubrosId] = @AV60RubrosId)");
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
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV24TFProfesionalesEmail_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV23TFProfesionalesEmail)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ProfesionalesEmail]) like UPPER(@lV23TFProfesionalesEmail))");
         }
         else
         {
            GXv_int8[13] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV24TFProfesionalesEmail_Sel)) && ! ( StringUtil.StrCmp(AV24TFProfesionalesEmail_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.[ProfesionalesEmail] = @AV24TFProfesionalesEmail_Sel)");
         }
         else
         {
            GXv_int8[14] = 1;
         }
         if ( StringUtil.StrCmp(AV24TFProfesionalesEmail_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T2.[ProfesionalesEmail] IS NULL or (T2.[ProfesionalesEmail] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV26TFProfesionalesDireccion_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV25TFProfesionalesDireccion)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ProfesionalesDireccion]) like UPPER(@lV25TFProfesionalesDireccion))");
         }
         else
         {
            GXv_int8[15] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV26TFProfesionalesDireccion_Sel)) && ! ( StringUtil.StrCmp(AV26TFProfesionalesDireccion_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.[ProfesionalesDireccion] = @AV26TFProfesionalesDireccion_Sel)");
         }
         else
         {
            GXv_int8[16] = 1;
         }
         if ( StringUtil.StrCmp(AV26TFProfesionalesDireccion_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T2.[ProfesionalesDireccion] = ''))");
         }
         if ( ! (0==AV27TFEstadosGenericosId) )
         {
            AddWhere(sWhereString, "(T2.[EstadosGenericosId] >= @AV27TFEstadosGenericosId)");
         }
         else
         {
            GXv_int8[17] = 1;
         }
         if ( ! (0==AV28TFEstadosGenericosId_To) )
         {
            AddWhere(sWhereString, "(T2.[EstadosGenericosId] <= @AV28TFEstadosGenericosId_To)");
         }
         else
         {
            GXv_int8[18] = 1;
         }
         if ( AV30TFProfesionalesVerDatPerSol_Sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV30TFProfesionalesVerDatPerSol_Sels, "T2.[ProfesionalesVerDatPerSol] IN (", ")")+")");
         }
         if ( ! (0==AV31TFProfesionalesFeedBackCant) )
         {
            AddWhere(sWhereString, "(T2.[ProfesionalesFeedBackCant] >= @AV31TFProfesionalesFeedBackCant)");
         }
         else
         {
            GXv_int8[19] = 1;
         }
         if ( ! (0==AV32TFProfesionalesFeedBackCant_To) )
         {
            AddWhere(sWhereString, "(T2.[ProfesionalesFeedBackCant] <= @AV32TFProfesionalesFeedBackCant_To)");
         }
         else
         {
            GXv_int8[20] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV33TFProfesionalesFeedback) )
         {
            AddWhere(sWhereString, "(( CASE  WHEN T2.[ProfesionalesFeedBackCant] > 0 THEN CAST(T2.[ProfesionalesFeedBackProm] AS decimal( 28, 10)) / T2.[ProfesionalesFeedBackCant] END) >= @AV33TFProfesionalesFeedback)");
         }
         else
         {
            GXv_int8[21] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV34TFProfesionalesFeedback_To) )
         {
            AddWhere(sWhereString, "(( CASE  WHEN T2.[ProfesionalesFeedBackCant] > 0 THEN CAST(T2.[ProfesionalesFeedBackProm] AS decimal( 28, 10)) / T2.[ProfesionalesFeedBackCant] END) <= @AV34TFProfesionalesFeedback_To)");
         }
         else
         {
            GXv_int8[22] = 1;
         }
         if ( AV36TFProfesionalesPerAltShop_Sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV36TFProfesionalesPerAltShop_Sels, "T2.[ProfesionalesPerAltShop] IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[RubrosId], T2.[ProfesionalesApellidoPrimero]";
         GXv_Object9[0] = scmdbuf;
         GXv_Object9[1] = GXv_int8;
         return GXv_Object9 ;
      }

      protected Object[] conditional_P00466( IGxContext context ,
                                             string A267ProfesionalesVerDatPerSol ,
                                             GxSimpleCollection<string> AV30TFProfesionalesVerDatPerSol_Sels ,
                                             string A436ProfesionalesPerAltShop ,
                                             GxSimpleCollection<string> AV36TFProfesionalesPerAltShop_Sels ,
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
                                             string AV26TFProfesionalesDireccion_Sel ,
                                             string AV25TFProfesionalesDireccion ,
                                             int AV27TFEstadosGenericosId ,
                                             int AV28TFEstadosGenericosId_To ,
                                             int AV30TFProfesionalesVerDatPerSol_Sels_Count ,
                                             long AV31TFProfesionalesFeedBackCant ,
                                             long AV32TFProfesionalesFeedBackCant_To ,
                                             decimal AV33TFProfesionalesFeedback ,
                                             decimal AV34TFProfesionalesFeedback_To ,
                                             int AV36TFProfesionalesPerAltShop_Sels_Count ,
                                             string A120ProfesionalesId ,
                                             string A166ProfesionalesPrimerNombre ,
                                             string A191ProfesionalesSegundoNombre ,
                                             string A167ProfesionalesApellidoPrimero ,
                                             string A192ProfesionalesApellidoSegundo ,
                                             string A170ProfesionalesTelefono ,
                                             string A193ProfesionalesEmail ,
                                             string A198ProfesionalesDireccion ,
                                             int A108EstadosGenericosId ,
                                             long A268ProfesionalesFeedBackCant ,
                                             decimal A269ProfesionalesFeedBackProm ,
                                             string AV59FilterFullText ,
                                             decimal A270ProfesionalesFeedback ,
                                             short AV60RubrosId ,
                                             short A121RubrosId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int10 = new short[23];
         Object[] GXv_Object11 = new Object[2];
         scmdbuf = "SELECT T1.[RubrosId], T2.[ProfesionalesApellidoSegundo], T2.[ProfesionalesPerAltShop], CASE  WHEN T2.[ProfesionalesFeedBackCant] > 0 THEN CAST(T2.[ProfesionalesFeedBackProm] AS decimal( 28, 10)) / T2.[ProfesionalesFeedBackCant] END AS ProfesionalesFeedback, T2.[ProfesionalesVerDatPerSol], T2.[EstadosGenericosId], T2.[ProfesionalesDireccion], T2.[ProfesionalesEmail], T2.[ProfesionalesTelefono], T2.[ProfesionalesApellidoPrimero], T2.[ProfesionalesSegundoNombre], T2.[ProfesionalesPrimerNombre], T1.[ProfesionalesId], T2.[ProfesionalesFeedBackProm], T2.[ProfesionalesFeedBackCant] FROM ([ProfesionalesRubros] T1 INNER JOIN [Profesionales] T2 ON T2.[ProfesionalesId] = T1.[ProfesionalesId])";
         AddWhere(sWhereString, "(T1.[RubrosId] = @AV60RubrosId)");
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
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV24TFProfesionalesEmail_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV23TFProfesionalesEmail)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ProfesionalesEmail]) like UPPER(@lV23TFProfesionalesEmail))");
         }
         else
         {
            GXv_int10[13] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV24TFProfesionalesEmail_Sel)) && ! ( StringUtil.StrCmp(AV24TFProfesionalesEmail_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.[ProfesionalesEmail] = @AV24TFProfesionalesEmail_Sel)");
         }
         else
         {
            GXv_int10[14] = 1;
         }
         if ( StringUtil.StrCmp(AV24TFProfesionalesEmail_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T2.[ProfesionalesEmail] IS NULL or (T2.[ProfesionalesEmail] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV26TFProfesionalesDireccion_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV25TFProfesionalesDireccion)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ProfesionalesDireccion]) like UPPER(@lV25TFProfesionalesDireccion))");
         }
         else
         {
            GXv_int10[15] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV26TFProfesionalesDireccion_Sel)) && ! ( StringUtil.StrCmp(AV26TFProfesionalesDireccion_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.[ProfesionalesDireccion] = @AV26TFProfesionalesDireccion_Sel)");
         }
         else
         {
            GXv_int10[16] = 1;
         }
         if ( StringUtil.StrCmp(AV26TFProfesionalesDireccion_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T2.[ProfesionalesDireccion] = ''))");
         }
         if ( ! (0==AV27TFEstadosGenericosId) )
         {
            AddWhere(sWhereString, "(T2.[EstadosGenericosId] >= @AV27TFEstadosGenericosId)");
         }
         else
         {
            GXv_int10[17] = 1;
         }
         if ( ! (0==AV28TFEstadosGenericosId_To) )
         {
            AddWhere(sWhereString, "(T2.[EstadosGenericosId] <= @AV28TFEstadosGenericosId_To)");
         }
         else
         {
            GXv_int10[18] = 1;
         }
         if ( AV30TFProfesionalesVerDatPerSol_Sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV30TFProfesionalesVerDatPerSol_Sels, "T2.[ProfesionalesVerDatPerSol] IN (", ")")+")");
         }
         if ( ! (0==AV31TFProfesionalesFeedBackCant) )
         {
            AddWhere(sWhereString, "(T2.[ProfesionalesFeedBackCant] >= @AV31TFProfesionalesFeedBackCant)");
         }
         else
         {
            GXv_int10[19] = 1;
         }
         if ( ! (0==AV32TFProfesionalesFeedBackCant_To) )
         {
            AddWhere(sWhereString, "(T2.[ProfesionalesFeedBackCant] <= @AV32TFProfesionalesFeedBackCant_To)");
         }
         else
         {
            GXv_int10[20] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV33TFProfesionalesFeedback) )
         {
            AddWhere(sWhereString, "(( CASE  WHEN T2.[ProfesionalesFeedBackCant] > 0 THEN CAST(T2.[ProfesionalesFeedBackProm] AS decimal( 28, 10)) / T2.[ProfesionalesFeedBackCant] END) >= @AV33TFProfesionalesFeedback)");
         }
         else
         {
            GXv_int10[21] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV34TFProfesionalesFeedback_To) )
         {
            AddWhere(sWhereString, "(( CASE  WHEN T2.[ProfesionalesFeedBackCant] > 0 THEN CAST(T2.[ProfesionalesFeedBackProm] AS decimal( 28, 10)) / T2.[ProfesionalesFeedBackCant] END) <= @AV34TFProfesionalesFeedback_To)");
         }
         else
         {
            GXv_int10[22] = 1;
         }
         if ( AV36TFProfesionalesPerAltShop_Sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV36TFProfesionalesPerAltShop_Sels, "T2.[ProfesionalesPerAltShop] IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[RubrosId], T2.[ProfesionalesApellidoSegundo]";
         GXv_Object11[0] = scmdbuf;
         GXv_Object11[1] = GXv_int10;
         return GXv_Object11 ;
      }

      protected Object[] conditional_P00467( IGxContext context ,
                                             string A267ProfesionalesVerDatPerSol ,
                                             GxSimpleCollection<string> AV30TFProfesionalesVerDatPerSol_Sels ,
                                             string A436ProfesionalesPerAltShop ,
                                             GxSimpleCollection<string> AV36TFProfesionalesPerAltShop_Sels ,
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
                                             string AV26TFProfesionalesDireccion_Sel ,
                                             string AV25TFProfesionalesDireccion ,
                                             int AV27TFEstadosGenericosId ,
                                             int AV28TFEstadosGenericosId_To ,
                                             int AV30TFProfesionalesVerDatPerSol_Sels_Count ,
                                             long AV31TFProfesionalesFeedBackCant ,
                                             long AV32TFProfesionalesFeedBackCant_To ,
                                             decimal AV33TFProfesionalesFeedback ,
                                             decimal AV34TFProfesionalesFeedback_To ,
                                             int AV36TFProfesionalesPerAltShop_Sels_Count ,
                                             string A120ProfesionalesId ,
                                             string A166ProfesionalesPrimerNombre ,
                                             string A191ProfesionalesSegundoNombre ,
                                             string A167ProfesionalesApellidoPrimero ,
                                             string A192ProfesionalesApellidoSegundo ,
                                             string A170ProfesionalesTelefono ,
                                             string A193ProfesionalesEmail ,
                                             string A198ProfesionalesDireccion ,
                                             int A108EstadosGenericosId ,
                                             long A268ProfesionalesFeedBackCant ,
                                             decimal A269ProfesionalesFeedBackProm ,
                                             string AV59FilterFullText ,
                                             decimal A270ProfesionalesFeedback ,
                                             short AV60RubrosId ,
                                             short A121RubrosId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int12 = new short[23];
         Object[] GXv_Object13 = new Object[2];
         scmdbuf = "SELECT T1.[RubrosId], T2.[ProfesionalesTelefono], T2.[ProfesionalesPerAltShop], CASE  WHEN T2.[ProfesionalesFeedBackCant] > 0 THEN CAST(T2.[ProfesionalesFeedBackProm] AS decimal( 28, 10)) / T2.[ProfesionalesFeedBackCant] END AS ProfesionalesFeedback, T2.[ProfesionalesVerDatPerSol], T2.[EstadosGenericosId], T2.[ProfesionalesDireccion], T2.[ProfesionalesEmail], T2.[ProfesionalesApellidoSegundo], T2.[ProfesionalesApellidoPrimero], T2.[ProfesionalesSegundoNombre], T2.[ProfesionalesPrimerNombre], T1.[ProfesionalesId], T2.[ProfesionalesFeedBackProm], T2.[ProfesionalesFeedBackCant] FROM ([ProfesionalesRubros] T1 INNER JOIN [Profesionales] T2 ON T2.[ProfesionalesId] = T1.[ProfesionalesId])";
         AddWhere(sWhereString, "(T1.[RubrosId] = @AV60RubrosId)");
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
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV24TFProfesionalesEmail_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV23TFProfesionalesEmail)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ProfesionalesEmail]) like UPPER(@lV23TFProfesionalesEmail))");
         }
         else
         {
            GXv_int12[13] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV24TFProfesionalesEmail_Sel)) && ! ( StringUtil.StrCmp(AV24TFProfesionalesEmail_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.[ProfesionalesEmail] = @AV24TFProfesionalesEmail_Sel)");
         }
         else
         {
            GXv_int12[14] = 1;
         }
         if ( StringUtil.StrCmp(AV24TFProfesionalesEmail_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T2.[ProfesionalesEmail] IS NULL or (T2.[ProfesionalesEmail] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV26TFProfesionalesDireccion_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV25TFProfesionalesDireccion)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ProfesionalesDireccion]) like UPPER(@lV25TFProfesionalesDireccion))");
         }
         else
         {
            GXv_int12[15] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV26TFProfesionalesDireccion_Sel)) && ! ( StringUtil.StrCmp(AV26TFProfesionalesDireccion_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.[ProfesionalesDireccion] = @AV26TFProfesionalesDireccion_Sel)");
         }
         else
         {
            GXv_int12[16] = 1;
         }
         if ( StringUtil.StrCmp(AV26TFProfesionalesDireccion_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T2.[ProfesionalesDireccion] = ''))");
         }
         if ( ! (0==AV27TFEstadosGenericosId) )
         {
            AddWhere(sWhereString, "(T2.[EstadosGenericosId] >= @AV27TFEstadosGenericosId)");
         }
         else
         {
            GXv_int12[17] = 1;
         }
         if ( ! (0==AV28TFEstadosGenericosId_To) )
         {
            AddWhere(sWhereString, "(T2.[EstadosGenericosId] <= @AV28TFEstadosGenericosId_To)");
         }
         else
         {
            GXv_int12[18] = 1;
         }
         if ( AV30TFProfesionalesVerDatPerSol_Sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV30TFProfesionalesVerDatPerSol_Sels, "T2.[ProfesionalesVerDatPerSol] IN (", ")")+")");
         }
         if ( ! (0==AV31TFProfesionalesFeedBackCant) )
         {
            AddWhere(sWhereString, "(T2.[ProfesionalesFeedBackCant] >= @AV31TFProfesionalesFeedBackCant)");
         }
         else
         {
            GXv_int12[19] = 1;
         }
         if ( ! (0==AV32TFProfesionalesFeedBackCant_To) )
         {
            AddWhere(sWhereString, "(T2.[ProfesionalesFeedBackCant] <= @AV32TFProfesionalesFeedBackCant_To)");
         }
         else
         {
            GXv_int12[20] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV33TFProfesionalesFeedback) )
         {
            AddWhere(sWhereString, "(( CASE  WHEN T2.[ProfesionalesFeedBackCant] > 0 THEN CAST(T2.[ProfesionalesFeedBackProm] AS decimal( 28, 10)) / T2.[ProfesionalesFeedBackCant] END) >= @AV33TFProfesionalesFeedback)");
         }
         else
         {
            GXv_int12[21] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV34TFProfesionalesFeedback_To) )
         {
            AddWhere(sWhereString, "(( CASE  WHEN T2.[ProfesionalesFeedBackCant] > 0 THEN CAST(T2.[ProfesionalesFeedBackProm] AS decimal( 28, 10)) / T2.[ProfesionalesFeedBackCant] END) <= @AV34TFProfesionalesFeedback_To)");
         }
         else
         {
            GXv_int12[22] = 1;
         }
         if ( AV36TFProfesionalesPerAltShop_Sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV36TFProfesionalesPerAltShop_Sels, "T2.[ProfesionalesPerAltShop] IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[RubrosId], T2.[ProfesionalesTelefono]";
         GXv_Object13[0] = scmdbuf;
         GXv_Object13[1] = GXv_int12;
         return GXv_Object13 ;
      }

      protected Object[] conditional_P00468( IGxContext context ,
                                             string A267ProfesionalesVerDatPerSol ,
                                             GxSimpleCollection<string> AV30TFProfesionalesVerDatPerSol_Sels ,
                                             string A436ProfesionalesPerAltShop ,
                                             GxSimpleCollection<string> AV36TFProfesionalesPerAltShop_Sels ,
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
                                             string AV26TFProfesionalesDireccion_Sel ,
                                             string AV25TFProfesionalesDireccion ,
                                             int AV27TFEstadosGenericosId ,
                                             int AV28TFEstadosGenericosId_To ,
                                             int AV30TFProfesionalesVerDatPerSol_Sels_Count ,
                                             long AV31TFProfesionalesFeedBackCant ,
                                             long AV32TFProfesionalesFeedBackCant_To ,
                                             decimal AV33TFProfesionalesFeedback ,
                                             decimal AV34TFProfesionalesFeedback_To ,
                                             int AV36TFProfesionalesPerAltShop_Sels_Count ,
                                             string A120ProfesionalesId ,
                                             string A166ProfesionalesPrimerNombre ,
                                             string A191ProfesionalesSegundoNombre ,
                                             string A167ProfesionalesApellidoPrimero ,
                                             string A192ProfesionalesApellidoSegundo ,
                                             string A170ProfesionalesTelefono ,
                                             string A193ProfesionalesEmail ,
                                             string A198ProfesionalesDireccion ,
                                             int A108EstadosGenericosId ,
                                             long A268ProfesionalesFeedBackCant ,
                                             decimal A269ProfesionalesFeedBackProm ,
                                             string AV59FilterFullText ,
                                             decimal A270ProfesionalesFeedback ,
                                             short AV60RubrosId ,
                                             short A121RubrosId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int14 = new short[23];
         Object[] GXv_Object15 = new Object[2];
         scmdbuf = "SELECT T1.[RubrosId], T2.[ProfesionalesEmail], T2.[ProfesionalesPerAltShop], CASE  WHEN T2.[ProfesionalesFeedBackCant] > 0 THEN CAST(T2.[ProfesionalesFeedBackProm] AS decimal( 28, 10)) / T2.[ProfesionalesFeedBackCant] END AS ProfesionalesFeedback, T2.[ProfesionalesVerDatPerSol], T2.[EstadosGenericosId], T2.[ProfesionalesDireccion], T2.[ProfesionalesTelefono], T2.[ProfesionalesApellidoSegundo], T2.[ProfesionalesApellidoPrimero], T2.[ProfesionalesSegundoNombre], T2.[ProfesionalesPrimerNombre], T1.[ProfesionalesId], T2.[ProfesionalesFeedBackProm], T2.[ProfesionalesFeedBackCant] FROM ([ProfesionalesRubros] T1 INNER JOIN [Profesionales] T2 ON T2.[ProfesionalesId] = T1.[ProfesionalesId])";
         AddWhere(sWhereString, "(T1.[RubrosId] = @AV60RubrosId)");
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
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV24TFProfesionalesEmail_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV23TFProfesionalesEmail)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ProfesionalesEmail]) like UPPER(@lV23TFProfesionalesEmail))");
         }
         else
         {
            GXv_int14[13] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV24TFProfesionalesEmail_Sel)) && ! ( StringUtil.StrCmp(AV24TFProfesionalesEmail_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.[ProfesionalesEmail] = @AV24TFProfesionalesEmail_Sel)");
         }
         else
         {
            GXv_int14[14] = 1;
         }
         if ( StringUtil.StrCmp(AV24TFProfesionalesEmail_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T2.[ProfesionalesEmail] IS NULL or (T2.[ProfesionalesEmail] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV26TFProfesionalesDireccion_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV25TFProfesionalesDireccion)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ProfesionalesDireccion]) like UPPER(@lV25TFProfesionalesDireccion))");
         }
         else
         {
            GXv_int14[15] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV26TFProfesionalesDireccion_Sel)) && ! ( StringUtil.StrCmp(AV26TFProfesionalesDireccion_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.[ProfesionalesDireccion] = @AV26TFProfesionalesDireccion_Sel)");
         }
         else
         {
            GXv_int14[16] = 1;
         }
         if ( StringUtil.StrCmp(AV26TFProfesionalesDireccion_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T2.[ProfesionalesDireccion] = ''))");
         }
         if ( ! (0==AV27TFEstadosGenericosId) )
         {
            AddWhere(sWhereString, "(T2.[EstadosGenericosId] >= @AV27TFEstadosGenericosId)");
         }
         else
         {
            GXv_int14[17] = 1;
         }
         if ( ! (0==AV28TFEstadosGenericosId_To) )
         {
            AddWhere(sWhereString, "(T2.[EstadosGenericosId] <= @AV28TFEstadosGenericosId_To)");
         }
         else
         {
            GXv_int14[18] = 1;
         }
         if ( AV30TFProfesionalesVerDatPerSol_Sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV30TFProfesionalesVerDatPerSol_Sels, "T2.[ProfesionalesVerDatPerSol] IN (", ")")+")");
         }
         if ( ! (0==AV31TFProfesionalesFeedBackCant) )
         {
            AddWhere(sWhereString, "(T2.[ProfesionalesFeedBackCant] >= @AV31TFProfesionalesFeedBackCant)");
         }
         else
         {
            GXv_int14[19] = 1;
         }
         if ( ! (0==AV32TFProfesionalesFeedBackCant_To) )
         {
            AddWhere(sWhereString, "(T2.[ProfesionalesFeedBackCant] <= @AV32TFProfesionalesFeedBackCant_To)");
         }
         else
         {
            GXv_int14[20] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV33TFProfesionalesFeedback) )
         {
            AddWhere(sWhereString, "(( CASE  WHEN T2.[ProfesionalesFeedBackCant] > 0 THEN CAST(T2.[ProfesionalesFeedBackProm] AS decimal( 28, 10)) / T2.[ProfesionalesFeedBackCant] END) >= @AV33TFProfesionalesFeedback)");
         }
         else
         {
            GXv_int14[21] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV34TFProfesionalesFeedback_To) )
         {
            AddWhere(sWhereString, "(( CASE  WHEN T2.[ProfesionalesFeedBackCant] > 0 THEN CAST(T2.[ProfesionalesFeedBackProm] AS decimal( 28, 10)) / T2.[ProfesionalesFeedBackCant] END) <= @AV34TFProfesionalesFeedback_To)");
         }
         else
         {
            GXv_int14[22] = 1;
         }
         if ( AV36TFProfesionalesPerAltShop_Sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV36TFProfesionalesPerAltShop_Sels, "T2.[ProfesionalesPerAltShop] IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[RubrosId], T2.[ProfesionalesEmail]";
         GXv_Object15[0] = scmdbuf;
         GXv_Object15[1] = GXv_int14;
         return GXv_Object15 ;
      }

      protected Object[] conditional_P00469( IGxContext context ,
                                             string A267ProfesionalesVerDatPerSol ,
                                             GxSimpleCollection<string> AV30TFProfesionalesVerDatPerSol_Sels ,
                                             string A436ProfesionalesPerAltShop ,
                                             GxSimpleCollection<string> AV36TFProfesionalesPerAltShop_Sels ,
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
                                             string AV26TFProfesionalesDireccion_Sel ,
                                             string AV25TFProfesionalesDireccion ,
                                             int AV27TFEstadosGenericosId ,
                                             int AV28TFEstadosGenericosId_To ,
                                             int AV30TFProfesionalesVerDatPerSol_Sels_Count ,
                                             long AV31TFProfesionalesFeedBackCant ,
                                             long AV32TFProfesionalesFeedBackCant_To ,
                                             decimal AV33TFProfesionalesFeedback ,
                                             decimal AV34TFProfesionalesFeedback_To ,
                                             int AV36TFProfesionalesPerAltShop_Sels_Count ,
                                             string A120ProfesionalesId ,
                                             string A166ProfesionalesPrimerNombre ,
                                             string A191ProfesionalesSegundoNombre ,
                                             string A167ProfesionalesApellidoPrimero ,
                                             string A192ProfesionalesApellidoSegundo ,
                                             string A170ProfesionalesTelefono ,
                                             string A193ProfesionalesEmail ,
                                             string A198ProfesionalesDireccion ,
                                             int A108EstadosGenericosId ,
                                             long A268ProfesionalesFeedBackCant ,
                                             decimal A269ProfesionalesFeedBackProm ,
                                             string AV59FilterFullText ,
                                             decimal A270ProfesionalesFeedback ,
                                             short AV60RubrosId ,
                                             short A121RubrosId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int16 = new short[23];
         Object[] GXv_Object17 = new Object[2];
         scmdbuf = "SELECT T1.[RubrosId], T2.[ProfesionalesDireccion], T2.[ProfesionalesPerAltShop], CASE  WHEN T2.[ProfesionalesFeedBackCant] > 0 THEN CAST(T2.[ProfesionalesFeedBackProm] AS decimal( 28, 10)) / T2.[ProfesionalesFeedBackCant] END AS ProfesionalesFeedback, T2.[ProfesionalesVerDatPerSol], T2.[EstadosGenericosId], T2.[ProfesionalesEmail], T2.[ProfesionalesTelefono], T2.[ProfesionalesApellidoSegundo], T2.[ProfesionalesApellidoPrimero], T2.[ProfesionalesSegundoNombre], T2.[ProfesionalesPrimerNombre], T1.[ProfesionalesId], T2.[ProfesionalesFeedBackProm], T2.[ProfesionalesFeedBackCant] FROM ([ProfesionalesRubros] T1 INNER JOIN [Profesionales] T2 ON T2.[ProfesionalesId] = T1.[ProfesionalesId])";
         AddWhere(sWhereString, "(T1.[RubrosId] = @AV60RubrosId)");
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV12TFProfesionalesId_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV11TFProfesionalesId)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[ProfesionalesId]) like UPPER(@lV11TFProfesionalesId))");
         }
         else
         {
            GXv_int16[1] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV12TFProfesionalesId_Sel)) && ! ( StringUtil.StrCmp(AV12TFProfesionalesId_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[ProfesionalesId] = @AV12TFProfesionalesId_Sel)");
         }
         else
         {
            GXv_int16[2] = 1;
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
            GXv_int16[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV14TFProfesionalesPrimerNombre_Sel)) && ! ( StringUtil.StrCmp(AV14TFProfesionalesPrimerNombre_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.[ProfesionalesPrimerNombre] = @AV14TFProfesionalesPrimerNombre_Sel)");
         }
         else
         {
            GXv_int16[4] = 1;
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
            GXv_int16[5] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV16TFProfesionalesSegundoNombre_Sel)) && ! ( StringUtil.StrCmp(AV16TFProfesionalesSegundoNombre_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.[ProfesionalesSegundoNombre] = @AV16TFProfesionalesSegundoNombre_Sel)");
         }
         else
         {
            GXv_int16[6] = 1;
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
            GXv_int16[7] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV18TFProfesionalesApellidoPrimero_Sel)) && ! ( StringUtil.StrCmp(AV18TFProfesionalesApellidoPrimero_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.[ProfesionalesApellidoPrimero] = @AV18TFProfesionalesApellidoPrimero_Sel)");
         }
         else
         {
            GXv_int16[8] = 1;
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
            GXv_int16[9] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV20TFProfesionalesApellidoSegundo_Sel)) && ! ( StringUtil.StrCmp(AV20TFProfesionalesApellidoSegundo_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.[ProfesionalesApellidoSegundo] = @AV20TFProfesionalesApellidoSegundo_Sel)");
         }
         else
         {
            GXv_int16[10] = 1;
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
            GXv_int16[11] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV22TFProfesionalesTelefono_Sel)) && ! ( StringUtil.StrCmp(AV22TFProfesionalesTelefono_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.[ProfesionalesTelefono] = @AV22TFProfesionalesTelefono_Sel)");
         }
         else
         {
            GXv_int16[12] = 1;
         }
         if ( StringUtil.StrCmp(AV22TFProfesionalesTelefono_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T2.[ProfesionalesTelefono] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV24TFProfesionalesEmail_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV23TFProfesionalesEmail)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ProfesionalesEmail]) like UPPER(@lV23TFProfesionalesEmail))");
         }
         else
         {
            GXv_int16[13] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV24TFProfesionalesEmail_Sel)) && ! ( StringUtil.StrCmp(AV24TFProfesionalesEmail_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.[ProfesionalesEmail] = @AV24TFProfesionalesEmail_Sel)");
         }
         else
         {
            GXv_int16[14] = 1;
         }
         if ( StringUtil.StrCmp(AV24TFProfesionalesEmail_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T2.[ProfesionalesEmail] IS NULL or (T2.[ProfesionalesEmail] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV26TFProfesionalesDireccion_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV25TFProfesionalesDireccion)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ProfesionalesDireccion]) like UPPER(@lV25TFProfesionalesDireccion))");
         }
         else
         {
            GXv_int16[15] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV26TFProfesionalesDireccion_Sel)) && ! ( StringUtil.StrCmp(AV26TFProfesionalesDireccion_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.[ProfesionalesDireccion] = @AV26TFProfesionalesDireccion_Sel)");
         }
         else
         {
            GXv_int16[16] = 1;
         }
         if ( StringUtil.StrCmp(AV26TFProfesionalesDireccion_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T2.[ProfesionalesDireccion] = ''))");
         }
         if ( ! (0==AV27TFEstadosGenericosId) )
         {
            AddWhere(sWhereString, "(T2.[EstadosGenericosId] >= @AV27TFEstadosGenericosId)");
         }
         else
         {
            GXv_int16[17] = 1;
         }
         if ( ! (0==AV28TFEstadosGenericosId_To) )
         {
            AddWhere(sWhereString, "(T2.[EstadosGenericosId] <= @AV28TFEstadosGenericosId_To)");
         }
         else
         {
            GXv_int16[18] = 1;
         }
         if ( AV30TFProfesionalesVerDatPerSol_Sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV30TFProfesionalesVerDatPerSol_Sels, "T2.[ProfesionalesVerDatPerSol] IN (", ")")+")");
         }
         if ( ! (0==AV31TFProfesionalesFeedBackCant) )
         {
            AddWhere(sWhereString, "(T2.[ProfesionalesFeedBackCant] >= @AV31TFProfesionalesFeedBackCant)");
         }
         else
         {
            GXv_int16[19] = 1;
         }
         if ( ! (0==AV32TFProfesionalesFeedBackCant_To) )
         {
            AddWhere(sWhereString, "(T2.[ProfesionalesFeedBackCant] <= @AV32TFProfesionalesFeedBackCant_To)");
         }
         else
         {
            GXv_int16[20] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV33TFProfesionalesFeedback) )
         {
            AddWhere(sWhereString, "(( CASE  WHEN T2.[ProfesionalesFeedBackCant] > 0 THEN CAST(T2.[ProfesionalesFeedBackProm] AS decimal( 28, 10)) / T2.[ProfesionalesFeedBackCant] END) >= @AV33TFProfesionalesFeedback)");
         }
         else
         {
            GXv_int16[21] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV34TFProfesionalesFeedback_To) )
         {
            AddWhere(sWhereString, "(( CASE  WHEN T2.[ProfesionalesFeedBackCant] > 0 THEN CAST(T2.[ProfesionalesFeedBackProm] AS decimal( 28, 10)) / T2.[ProfesionalesFeedBackCant] END) <= @AV34TFProfesionalesFeedback_To)");
         }
         else
         {
            GXv_int16[22] = 1;
         }
         if ( AV36TFProfesionalesPerAltShop_Sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV36TFProfesionalesPerAltShop_Sels, "T2.[ProfesionalesPerAltShop] IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[RubrosId], T2.[ProfesionalesDireccion]";
         GXv_Object17[0] = scmdbuf;
         GXv_Object17[1] = GXv_int16;
         return GXv_Object17 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_P00462(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (GxSimpleCollection<string>)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (int)dynConstraints[20] , (int)dynConstraints[21] , (int)dynConstraints[22] , (long)dynConstraints[23] , (long)dynConstraints[24] , (decimal)dynConstraints[25] , (decimal)dynConstraints[26] , (int)dynConstraints[27] , (string)dynConstraints[28] , (string)dynConstraints[29] , (string)dynConstraints[30] , (string)dynConstraints[31] , (string)dynConstraints[32] , (string)dynConstraints[33] , (string)dynConstraints[34] , (string)dynConstraints[35] , (int)dynConstraints[36] , (long)dynConstraints[37] , (decimal)dynConstraints[38] , (string)dynConstraints[39] , (decimal)dynConstraints[40] , (short)dynConstraints[41] , (short)dynConstraints[42] );
               case 1 :
                     return conditional_P00463(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (GxSimpleCollection<string>)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (int)dynConstraints[20] , (int)dynConstraints[21] , (int)dynConstraints[22] , (long)dynConstraints[23] , (long)dynConstraints[24] , (decimal)dynConstraints[25] , (decimal)dynConstraints[26] , (int)dynConstraints[27] , (string)dynConstraints[28] , (string)dynConstraints[29] , (string)dynConstraints[30] , (string)dynConstraints[31] , (string)dynConstraints[32] , (string)dynConstraints[33] , (string)dynConstraints[34] , (string)dynConstraints[35] , (int)dynConstraints[36] , (long)dynConstraints[37] , (decimal)dynConstraints[38] , (string)dynConstraints[39] , (decimal)dynConstraints[40] , (short)dynConstraints[41] , (short)dynConstraints[42] );
               case 2 :
                     return conditional_P00464(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (GxSimpleCollection<string>)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (int)dynConstraints[20] , (int)dynConstraints[21] , (int)dynConstraints[22] , (long)dynConstraints[23] , (long)dynConstraints[24] , (decimal)dynConstraints[25] , (decimal)dynConstraints[26] , (int)dynConstraints[27] , (string)dynConstraints[28] , (string)dynConstraints[29] , (string)dynConstraints[30] , (string)dynConstraints[31] , (string)dynConstraints[32] , (string)dynConstraints[33] , (string)dynConstraints[34] , (string)dynConstraints[35] , (int)dynConstraints[36] , (long)dynConstraints[37] , (decimal)dynConstraints[38] , (string)dynConstraints[39] , (decimal)dynConstraints[40] , (short)dynConstraints[41] , (short)dynConstraints[42] );
               case 3 :
                     return conditional_P00465(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (GxSimpleCollection<string>)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (int)dynConstraints[20] , (int)dynConstraints[21] , (int)dynConstraints[22] , (long)dynConstraints[23] , (long)dynConstraints[24] , (decimal)dynConstraints[25] , (decimal)dynConstraints[26] , (int)dynConstraints[27] , (string)dynConstraints[28] , (string)dynConstraints[29] , (string)dynConstraints[30] , (string)dynConstraints[31] , (string)dynConstraints[32] , (string)dynConstraints[33] , (string)dynConstraints[34] , (string)dynConstraints[35] , (int)dynConstraints[36] , (long)dynConstraints[37] , (decimal)dynConstraints[38] , (string)dynConstraints[39] , (decimal)dynConstraints[40] , (short)dynConstraints[41] , (short)dynConstraints[42] );
               case 4 :
                     return conditional_P00466(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (GxSimpleCollection<string>)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (int)dynConstraints[20] , (int)dynConstraints[21] , (int)dynConstraints[22] , (long)dynConstraints[23] , (long)dynConstraints[24] , (decimal)dynConstraints[25] , (decimal)dynConstraints[26] , (int)dynConstraints[27] , (string)dynConstraints[28] , (string)dynConstraints[29] , (string)dynConstraints[30] , (string)dynConstraints[31] , (string)dynConstraints[32] , (string)dynConstraints[33] , (string)dynConstraints[34] , (string)dynConstraints[35] , (int)dynConstraints[36] , (long)dynConstraints[37] , (decimal)dynConstraints[38] , (string)dynConstraints[39] , (decimal)dynConstraints[40] , (short)dynConstraints[41] , (short)dynConstraints[42] );
               case 5 :
                     return conditional_P00467(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (GxSimpleCollection<string>)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (int)dynConstraints[20] , (int)dynConstraints[21] , (int)dynConstraints[22] , (long)dynConstraints[23] , (long)dynConstraints[24] , (decimal)dynConstraints[25] , (decimal)dynConstraints[26] , (int)dynConstraints[27] , (string)dynConstraints[28] , (string)dynConstraints[29] , (string)dynConstraints[30] , (string)dynConstraints[31] , (string)dynConstraints[32] , (string)dynConstraints[33] , (string)dynConstraints[34] , (string)dynConstraints[35] , (int)dynConstraints[36] , (long)dynConstraints[37] , (decimal)dynConstraints[38] , (string)dynConstraints[39] , (decimal)dynConstraints[40] , (short)dynConstraints[41] , (short)dynConstraints[42] );
               case 6 :
                     return conditional_P00468(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (GxSimpleCollection<string>)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (int)dynConstraints[20] , (int)dynConstraints[21] , (int)dynConstraints[22] , (long)dynConstraints[23] , (long)dynConstraints[24] , (decimal)dynConstraints[25] , (decimal)dynConstraints[26] , (int)dynConstraints[27] , (string)dynConstraints[28] , (string)dynConstraints[29] , (string)dynConstraints[30] , (string)dynConstraints[31] , (string)dynConstraints[32] , (string)dynConstraints[33] , (string)dynConstraints[34] , (string)dynConstraints[35] , (int)dynConstraints[36] , (long)dynConstraints[37] , (decimal)dynConstraints[38] , (string)dynConstraints[39] , (decimal)dynConstraints[40] , (short)dynConstraints[41] , (short)dynConstraints[42] );
               case 7 :
                     return conditional_P00469(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (GxSimpleCollection<string>)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (int)dynConstraints[20] , (int)dynConstraints[21] , (int)dynConstraints[22] , (long)dynConstraints[23] , (long)dynConstraints[24] , (decimal)dynConstraints[25] , (decimal)dynConstraints[26] , (int)dynConstraints[27] , (string)dynConstraints[28] , (string)dynConstraints[29] , (string)dynConstraints[30] , (string)dynConstraints[31] , (string)dynConstraints[32] , (string)dynConstraints[33] , (string)dynConstraints[34] , (string)dynConstraints[35] , (int)dynConstraints[36] , (long)dynConstraints[37] , (decimal)dynConstraints[38] , (string)dynConstraints[39] , (decimal)dynConstraints[40] , (short)dynConstraints[41] , (short)dynConstraints[42] );
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
         ,new ForEachCursor(def[7])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP00462;
          prmP00462 = new Object[] {
          new ParDef("@AV60RubrosId",GXType.Int16,4,0) ,
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
          new ParDef("@lV25TFProfesionalesDireccion",GXType.VarChar,1024,0) ,
          new ParDef("@AV26TFProfesionalesDireccion_Sel",GXType.NVarChar,1024,0) ,
          new ParDef("@AV27TFEstadosGenericosId",GXType.Int32,5,0) ,
          new ParDef("@AV28TFEstadosGenericosId_To",GXType.Int32,5,0) ,
          new ParDef("@AV31TFProfesionalesFeedBackCant",GXType.Decimal,18,0) ,
          new ParDef("@AV32TFProfesionalesFeedBackCant_To",GXType.Decimal,18,0) ,
          new ParDef("@AV33TFProfesionalesFeedback",GXType.Decimal,10,2) ,
          new ParDef("@AV34TFProfesionalesFeedback_To",GXType.Decimal,10,2)
          };
          Object[] prmP00463;
          prmP00463 = new Object[] {
          new ParDef("@AV60RubrosId",GXType.Int16,4,0) ,
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
          new ParDef("@lV25TFProfesionalesDireccion",GXType.VarChar,1024,0) ,
          new ParDef("@AV26TFProfesionalesDireccion_Sel",GXType.NVarChar,1024,0) ,
          new ParDef("@AV27TFEstadosGenericosId",GXType.Int32,5,0) ,
          new ParDef("@AV28TFEstadosGenericosId_To",GXType.Int32,5,0) ,
          new ParDef("@AV31TFProfesionalesFeedBackCant",GXType.Decimal,18,0) ,
          new ParDef("@AV32TFProfesionalesFeedBackCant_To",GXType.Decimal,18,0) ,
          new ParDef("@AV33TFProfesionalesFeedback",GXType.Decimal,10,2) ,
          new ParDef("@AV34TFProfesionalesFeedback_To",GXType.Decimal,10,2)
          };
          Object[] prmP00464;
          prmP00464 = new Object[] {
          new ParDef("@AV60RubrosId",GXType.Int16,4,0) ,
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
          new ParDef("@lV25TFProfesionalesDireccion",GXType.VarChar,1024,0) ,
          new ParDef("@AV26TFProfesionalesDireccion_Sel",GXType.NVarChar,1024,0) ,
          new ParDef("@AV27TFEstadosGenericosId",GXType.Int32,5,0) ,
          new ParDef("@AV28TFEstadosGenericosId_To",GXType.Int32,5,0) ,
          new ParDef("@AV31TFProfesionalesFeedBackCant",GXType.Decimal,18,0) ,
          new ParDef("@AV32TFProfesionalesFeedBackCant_To",GXType.Decimal,18,0) ,
          new ParDef("@AV33TFProfesionalesFeedback",GXType.Decimal,10,2) ,
          new ParDef("@AV34TFProfesionalesFeedback_To",GXType.Decimal,10,2)
          };
          Object[] prmP00465;
          prmP00465 = new Object[] {
          new ParDef("@AV60RubrosId",GXType.Int16,4,0) ,
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
          new ParDef("@lV25TFProfesionalesDireccion",GXType.VarChar,1024,0) ,
          new ParDef("@AV26TFProfesionalesDireccion_Sel",GXType.NVarChar,1024,0) ,
          new ParDef("@AV27TFEstadosGenericosId",GXType.Int32,5,0) ,
          new ParDef("@AV28TFEstadosGenericosId_To",GXType.Int32,5,0) ,
          new ParDef("@AV31TFProfesionalesFeedBackCant",GXType.Decimal,18,0) ,
          new ParDef("@AV32TFProfesionalesFeedBackCant_To",GXType.Decimal,18,0) ,
          new ParDef("@AV33TFProfesionalesFeedback",GXType.Decimal,10,2) ,
          new ParDef("@AV34TFProfesionalesFeedback_To",GXType.Decimal,10,2)
          };
          Object[] prmP00466;
          prmP00466 = new Object[] {
          new ParDef("@AV60RubrosId",GXType.Int16,4,0) ,
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
          new ParDef("@lV25TFProfesionalesDireccion",GXType.VarChar,1024,0) ,
          new ParDef("@AV26TFProfesionalesDireccion_Sel",GXType.NVarChar,1024,0) ,
          new ParDef("@AV27TFEstadosGenericosId",GXType.Int32,5,0) ,
          new ParDef("@AV28TFEstadosGenericosId_To",GXType.Int32,5,0) ,
          new ParDef("@AV31TFProfesionalesFeedBackCant",GXType.Decimal,18,0) ,
          new ParDef("@AV32TFProfesionalesFeedBackCant_To",GXType.Decimal,18,0) ,
          new ParDef("@AV33TFProfesionalesFeedback",GXType.Decimal,10,2) ,
          new ParDef("@AV34TFProfesionalesFeedback_To",GXType.Decimal,10,2)
          };
          Object[] prmP00467;
          prmP00467 = new Object[] {
          new ParDef("@AV60RubrosId",GXType.Int16,4,0) ,
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
          new ParDef("@lV25TFProfesionalesDireccion",GXType.VarChar,1024,0) ,
          new ParDef("@AV26TFProfesionalesDireccion_Sel",GXType.NVarChar,1024,0) ,
          new ParDef("@AV27TFEstadosGenericosId",GXType.Int32,5,0) ,
          new ParDef("@AV28TFEstadosGenericosId_To",GXType.Int32,5,0) ,
          new ParDef("@AV31TFProfesionalesFeedBackCant",GXType.Decimal,18,0) ,
          new ParDef("@AV32TFProfesionalesFeedBackCant_To",GXType.Decimal,18,0) ,
          new ParDef("@AV33TFProfesionalesFeedback",GXType.Decimal,10,2) ,
          new ParDef("@AV34TFProfesionalesFeedback_To",GXType.Decimal,10,2)
          };
          Object[] prmP00468;
          prmP00468 = new Object[] {
          new ParDef("@AV60RubrosId",GXType.Int16,4,0) ,
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
          new ParDef("@lV25TFProfesionalesDireccion",GXType.VarChar,1024,0) ,
          new ParDef("@AV26TFProfesionalesDireccion_Sel",GXType.NVarChar,1024,0) ,
          new ParDef("@AV27TFEstadosGenericosId",GXType.Int32,5,0) ,
          new ParDef("@AV28TFEstadosGenericosId_To",GXType.Int32,5,0) ,
          new ParDef("@AV31TFProfesionalesFeedBackCant",GXType.Decimal,18,0) ,
          new ParDef("@AV32TFProfesionalesFeedBackCant_To",GXType.Decimal,18,0) ,
          new ParDef("@AV33TFProfesionalesFeedback",GXType.Decimal,10,2) ,
          new ParDef("@AV34TFProfesionalesFeedback_To",GXType.Decimal,10,2)
          };
          Object[] prmP00469;
          prmP00469 = new Object[] {
          new ParDef("@AV60RubrosId",GXType.Int16,4,0) ,
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
          new ParDef("@lV25TFProfesionalesDireccion",GXType.VarChar,1024,0) ,
          new ParDef("@AV26TFProfesionalesDireccion_Sel",GXType.NVarChar,1024,0) ,
          new ParDef("@AV27TFEstadosGenericosId",GXType.Int32,5,0) ,
          new ParDef("@AV28TFEstadosGenericosId_To",GXType.Int32,5,0) ,
          new ParDef("@AV31TFProfesionalesFeedBackCant",GXType.Decimal,18,0) ,
          new ParDef("@AV32TFProfesionalesFeedBackCant_To",GXType.Decimal,18,0) ,
          new ParDef("@AV33TFProfesionalesFeedback",GXType.Decimal,10,2) ,
          new ParDef("@AV34TFProfesionalesFeedback_To",GXType.Decimal,10,2)
          };
          def= new CursorDef[] {
              new CursorDef("P00462", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00462,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P00463", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00463,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00464", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00464,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00465", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00465,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00466", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00466,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00467", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00467,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00468", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00468,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00469", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00469,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[1])[0] = rslt.getString(2, 1);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((decimal[]) buf[3])[0] = rslt.getDecimal(3);
                ((string[]) buf[4])[0] = rslt.getString(4, 1);
                ((int[]) buf[5])[0] = rslt.getInt(5);
                ((string[]) buf[6])[0] = rslt.getVarchar(6);
                ((string[]) buf[7])[0] = rslt.getVarchar(7);
                ((bool[]) buf[8])[0] = rslt.wasNull(7);
                ((string[]) buf[9])[0] = rslt.getString(8, 20);
                ((string[]) buf[10])[0] = rslt.getString(9, 30);
                ((string[]) buf[11])[0] = rslt.getString(10, 30);
                ((string[]) buf[12])[0] = rslt.getString(11, 30);
                ((string[]) buf[13])[0] = rslt.getString(12, 30);
                ((string[]) buf[14])[0] = rslt.getString(13, 20);
                ((decimal[]) buf[15])[0] = rslt.getDecimal(14);
                ((long[]) buf[16])[0] = rslt.getLong(15);
                return;
             case 1 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 30);
                ((string[]) buf[2])[0] = rslt.getString(3, 1);
                ((bool[]) buf[3])[0] = rslt.wasNull(3);
                ((decimal[]) buf[4])[0] = rslt.getDecimal(4);
                ((string[]) buf[5])[0] = rslt.getString(5, 1);
                ((int[]) buf[6])[0] = rslt.getInt(6);
                ((string[]) buf[7])[0] = rslt.getVarchar(7);
                ((string[]) buf[8])[0] = rslt.getVarchar(8);
                ((bool[]) buf[9])[0] = rslt.wasNull(8);
                ((string[]) buf[10])[0] = rslt.getString(9, 20);
                ((string[]) buf[11])[0] = rslt.getString(10, 30);
                ((string[]) buf[12])[0] = rslt.getString(11, 30);
                ((string[]) buf[13])[0] = rslt.getString(12, 30);
                ((string[]) buf[14])[0] = rslt.getString(13, 20);
                ((decimal[]) buf[15])[0] = rslt.getDecimal(14);
                ((long[]) buf[16])[0] = rslt.getLong(15);
                return;
             case 2 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 30);
                ((string[]) buf[2])[0] = rslt.getString(3, 1);
                ((bool[]) buf[3])[0] = rslt.wasNull(3);
                ((decimal[]) buf[4])[0] = rslt.getDecimal(4);
                ((string[]) buf[5])[0] = rslt.getString(5, 1);
                ((int[]) buf[6])[0] = rslt.getInt(6);
                ((string[]) buf[7])[0] = rslt.getVarchar(7);
                ((string[]) buf[8])[0] = rslt.getVarchar(8);
                ((bool[]) buf[9])[0] = rslt.wasNull(8);
                ((string[]) buf[10])[0] = rslt.getString(9, 20);
                ((string[]) buf[11])[0] = rslt.getString(10, 30);
                ((string[]) buf[12])[0] = rslt.getString(11, 30);
                ((string[]) buf[13])[0] = rslt.getString(12, 30);
                ((string[]) buf[14])[0] = rslt.getString(13, 20);
                ((decimal[]) buf[15])[0] = rslt.getDecimal(14);
                ((long[]) buf[16])[0] = rslt.getLong(15);
                return;
             case 3 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 30);
                ((string[]) buf[2])[0] = rslt.getString(3, 1);
                ((bool[]) buf[3])[0] = rslt.wasNull(3);
                ((decimal[]) buf[4])[0] = rslt.getDecimal(4);
                ((string[]) buf[5])[0] = rslt.getString(5, 1);
                ((int[]) buf[6])[0] = rslt.getInt(6);
                ((string[]) buf[7])[0] = rslt.getVarchar(7);
                ((string[]) buf[8])[0] = rslt.getVarchar(8);
                ((bool[]) buf[9])[0] = rslt.wasNull(8);
                ((string[]) buf[10])[0] = rslt.getString(9, 20);
                ((string[]) buf[11])[0] = rslt.getString(10, 30);
                ((string[]) buf[12])[0] = rslt.getString(11, 30);
                ((string[]) buf[13])[0] = rslt.getString(12, 30);
                ((string[]) buf[14])[0] = rslt.getString(13, 20);
                ((decimal[]) buf[15])[0] = rslt.getDecimal(14);
                ((long[]) buf[16])[0] = rslt.getLong(15);
                return;
             case 4 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 30);
                ((string[]) buf[2])[0] = rslt.getString(3, 1);
                ((bool[]) buf[3])[0] = rslt.wasNull(3);
                ((decimal[]) buf[4])[0] = rslt.getDecimal(4);
                ((string[]) buf[5])[0] = rslt.getString(5, 1);
                ((int[]) buf[6])[0] = rslt.getInt(6);
                ((string[]) buf[7])[0] = rslt.getVarchar(7);
                ((string[]) buf[8])[0] = rslt.getVarchar(8);
                ((bool[]) buf[9])[0] = rslt.wasNull(8);
                ((string[]) buf[10])[0] = rslt.getString(9, 20);
                ((string[]) buf[11])[0] = rslt.getString(10, 30);
                ((string[]) buf[12])[0] = rslt.getString(11, 30);
                ((string[]) buf[13])[0] = rslt.getString(12, 30);
                ((string[]) buf[14])[0] = rslt.getString(13, 20);
                ((decimal[]) buf[15])[0] = rslt.getDecimal(14);
                ((long[]) buf[16])[0] = rslt.getLong(15);
                return;
             case 5 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 20);
                ((string[]) buf[2])[0] = rslt.getString(3, 1);
                ((bool[]) buf[3])[0] = rslt.wasNull(3);
                ((decimal[]) buf[4])[0] = rslt.getDecimal(4);
                ((string[]) buf[5])[0] = rslt.getString(5, 1);
                ((int[]) buf[6])[0] = rslt.getInt(6);
                ((string[]) buf[7])[0] = rslt.getVarchar(7);
                ((string[]) buf[8])[0] = rslt.getVarchar(8);
                ((bool[]) buf[9])[0] = rslt.wasNull(8);
                ((string[]) buf[10])[0] = rslt.getString(9, 30);
                ((string[]) buf[11])[0] = rslt.getString(10, 30);
                ((string[]) buf[12])[0] = rslt.getString(11, 30);
                ((string[]) buf[13])[0] = rslt.getString(12, 30);
                ((string[]) buf[14])[0] = rslt.getString(13, 20);
                ((decimal[]) buf[15])[0] = rslt.getDecimal(14);
                ((long[]) buf[16])[0] = rslt.getLong(15);
                return;
             case 6 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getString(3, 1);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((decimal[]) buf[5])[0] = rslt.getDecimal(4);
                ((string[]) buf[6])[0] = rslt.getString(5, 1);
                ((int[]) buf[7])[0] = rslt.getInt(6);
                ((string[]) buf[8])[0] = rslt.getVarchar(7);
                ((string[]) buf[9])[0] = rslt.getString(8, 20);
                ((string[]) buf[10])[0] = rslt.getString(9, 30);
                ((string[]) buf[11])[0] = rslt.getString(10, 30);
                ((string[]) buf[12])[0] = rslt.getString(11, 30);
                ((string[]) buf[13])[0] = rslt.getString(12, 30);
                ((string[]) buf[14])[0] = rslt.getString(13, 20);
                ((decimal[]) buf[15])[0] = rslt.getDecimal(14);
                ((long[]) buf[16])[0] = rslt.getLong(15);
                return;
             case 7 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 1);
                ((bool[]) buf[3])[0] = rslt.wasNull(3);
                ((decimal[]) buf[4])[0] = rslt.getDecimal(4);
                ((string[]) buf[5])[0] = rslt.getString(5, 1);
                ((int[]) buf[6])[0] = rslt.getInt(6);
                ((string[]) buf[7])[0] = rslt.getVarchar(7);
                ((bool[]) buf[8])[0] = rslt.wasNull(7);
                ((string[]) buf[9])[0] = rslt.getString(8, 20);
                ((string[]) buf[10])[0] = rslt.getString(9, 30);
                ((string[]) buf[11])[0] = rslt.getString(10, 30);
                ((string[]) buf[12])[0] = rslt.getString(11, 30);
                ((string[]) buf[13])[0] = rslt.getString(12, 30);
                ((string[]) buf[14])[0] = rslt.getString(13, 20);
                ((decimal[]) buf[15])[0] = rslt.getDecimal(14);
                ((long[]) buf[16])[0] = rslt.getLong(15);
                return;
       }
    }

 }

 [ServiceContract(Namespace = "GeneXus.Programs.rubrosrubroswcgetfilterdata_services")]
 [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple)]
 [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
 public class rubrosrubroswcgetfilterdata_services : GxRestService
 {
    [OperationContract(Name = "RubrosRubrosWCGetFilterData" )]
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
          if ( ! ProcessHeaders("rubrosrubroswcgetfilterdata") )
          {
             return  ;
          }
          rubrosrubroswcgetfilterdata worker = new rubrosrubroswcgetfilterdata(context);
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

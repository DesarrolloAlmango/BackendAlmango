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
   public class rubrosmedidasrubroswcgetfilterdata : GXProcedure
   {
      public rubrosmedidasrubroswcgetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public rubrosmedidasrubroswcgetfilterdata( IGxContext context )
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
         this.AV49DDOName = aP0_DDOName;
         this.AV50SearchTxtParms = aP1_SearchTxtParms;
         this.AV51SearchTxtTo = aP2_SearchTxtTo;
         this.AV52OptionsJson = "" ;
         this.AV53OptionsDescJson = "" ;
         this.AV54OptionIndexesJson = "" ;
         initialize();
         ExecutePrivate();
         aP3_OptionsJson=this.AV52OptionsJson;
         aP4_OptionsDescJson=this.AV53OptionsDescJson;
         aP5_OptionIndexesJson=this.AV54OptionIndexesJson;
      }

      public string executeUdp( string aP0_DDOName ,
                                string aP1_SearchTxtParms ,
                                string aP2_SearchTxtTo ,
                                out string aP3_OptionsJson ,
                                out string aP4_OptionsDescJson )
      {
         execute(aP0_DDOName, aP1_SearchTxtParms, aP2_SearchTxtTo, out aP3_OptionsJson, out aP4_OptionsDescJson, out aP5_OptionIndexesJson);
         return AV54OptionIndexesJson ;
      }

      public void executeSubmit( string aP0_DDOName ,
                                 string aP1_SearchTxtParms ,
                                 string aP2_SearchTxtTo ,
                                 out string aP3_OptionsJson ,
                                 out string aP4_OptionsDescJson ,
                                 out string aP5_OptionIndexesJson )
      {
         this.AV49DDOName = aP0_DDOName;
         this.AV50SearchTxtParms = aP1_SearchTxtParms;
         this.AV51SearchTxtTo = aP2_SearchTxtTo;
         this.AV52OptionsJson = "" ;
         this.AV53OptionsDescJson = "" ;
         this.AV54OptionIndexesJson = "" ;
         SubmitImpl();
         aP3_OptionsJson=this.AV52OptionsJson;
         aP4_OptionsDescJson=this.AV53OptionsDescJson;
         aP5_OptionIndexesJson=this.AV54OptionIndexesJson;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV39Options = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV41OptionsDesc = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV42OptionIndexes = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         GXt_boolean1 = AV8IsAuthorized;
         new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWProfesionales", out  GXt_boolean1) ;
         AV8IsAuthorized = GXt_boolean1;
         if ( AV8IsAuthorized )
         {
            AV36MaxItems = 10;
            AV35PageIndex = (short)((String.IsNullOrEmpty(StringUtil.RTrim( AV50SearchTxtParms)) ? 0 : (long)(Math.Round(NumberUtil.Val( StringUtil.Substring( AV50SearchTxtParms, 1, 2), "."), 18, MidpointRounding.ToEven))));
            AV33SearchTxt = (String.IsNullOrEmpty(StringUtil.RTrim( AV50SearchTxtParms)) ? "" : StringUtil.Substring( AV50SearchTxtParms, 3, -1));
            AV34SkipItems = (short)(AV35PageIndex*AV36MaxItems);
            new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV9WWPContext) ;
            /* Execute user subroutine: 'LOADGRIDSTATE' */
            S111 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
            if ( StringUtil.StrCmp(StringUtil.Upper( AV49DDOName), "DDO_PROFESIONALESID") == 0 )
            {
               /* Execute user subroutine: 'LOADPROFESIONALESIDOPTIONS' */
               S121 ();
               if ( returnInSub )
               {
                  cleanup();
                  if (true) return;
               }
            }
            else if ( StringUtil.StrCmp(StringUtil.Upper( AV49DDOName), "DDO_PROFESIONALESPRIMERNOMBRE") == 0 )
            {
               /* Execute user subroutine: 'LOADPROFESIONALESPRIMERNOMBREOPTIONS' */
               S131 ();
               if ( returnInSub )
               {
                  cleanup();
                  if (true) return;
               }
            }
            else if ( StringUtil.StrCmp(StringUtil.Upper( AV49DDOName), "DDO_PROFESIONALESSEGUNDONOMBRE") == 0 )
            {
               /* Execute user subroutine: 'LOADPROFESIONALESSEGUNDONOMBREOPTIONS' */
               S141 ();
               if ( returnInSub )
               {
                  cleanup();
                  if (true) return;
               }
            }
            else if ( StringUtil.StrCmp(StringUtil.Upper( AV49DDOName), "DDO_PROFESIONALESAPELLIDOPRIMERO") == 0 )
            {
               /* Execute user subroutine: 'LOADPROFESIONALESAPELLIDOPRIMEROOPTIONS' */
               S151 ();
               if ( returnInSub )
               {
                  cleanup();
                  if (true) return;
               }
            }
            else if ( StringUtil.StrCmp(StringUtil.Upper( AV49DDOName), "DDO_PROFESIONALESAPELLIDOSEGUNDO") == 0 )
            {
               /* Execute user subroutine: 'LOADPROFESIONALESAPELLIDOSEGUNDOOPTIONS' */
               S161 ();
               if ( returnInSub )
               {
                  cleanup();
                  if (true) return;
               }
            }
            else if ( StringUtil.StrCmp(StringUtil.Upper( AV49DDOName), "DDO_PROFESIONALESTELEFONO") == 0 )
            {
               /* Execute user subroutine: 'LOADPROFESIONALESTELEFONOOPTIONS' */
               S171 ();
               if ( returnInSub )
               {
                  cleanup();
                  if (true) return;
               }
            }
            else if ( StringUtil.StrCmp(StringUtil.Upper( AV49DDOName), "DDO_ESTADOSGENERICOSNOMBRE") == 0 )
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
         AV52OptionsJson = AV39Options.ToJSonString(false);
         AV53OptionsDescJson = AV41OptionsDesc.ToJSonString(false);
         AV54OptionIndexesJson = AV42OptionIndexes.ToJSonString(false);
         cleanup();
      }

      protected void S111( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV44Session.Get("RubrosMedidasRubrosWCGridState"), "") == 0 )
         {
            AV46GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "RubrosMedidasRubrosWCGridState"), null, "", "");
         }
         else
         {
            AV46GridState.FromXml(AV44Session.Get("RubrosMedidasRubrosWCGridState"), null, "", "");
         }
         AV57GXV1 = 1;
         while ( AV57GXV1 <= AV46GridState.gxTpr_Filtervalues.Count )
         {
            AV47GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV46GridState.gxTpr_Filtervalues.Item(AV57GXV1));
            if ( StringUtil.StrCmp(AV47GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV55FilterFullText = AV47GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV47GridStateFilterValue.gxTpr_Name, "TFPROFESIONALESID") == 0 )
            {
               AV11TFProfesionalesId = AV47GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV47GridStateFilterValue.gxTpr_Name, "TFPROFESIONALESID_SEL") == 0 )
            {
               AV12TFProfesionalesId_Sel = AV47GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV47GridStateFilterValue.gxTpr_Name, "TFPROFESIONALESPRIMERNOMBRE") == 0 )
            {
               AV13TFProfesionalesPrimerNombre = AV47GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV47GridStateFilterValue.gxTpr_Name, "TFPROFESIONALESPRIMERNOMBRE_SEL") == 0 )
            {
               AV14TFProfesionalesPrimerNombre_Sel = AV47GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV47GridStateFilterValue.gxTpr_Name, "TFPROFESIONALESSEGUNDONOMBRE") == 0 )
            {
               AV15TFProfesionalesSegundoNombre = AV47GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV47GridStateFilterValue.gxTpr_Name, "TFPROFESIONALESSEGUNDONOMBRE_SEL") == 0 )
            {
               AV16TFProfesionalesSegundoNombre_Sel = AV47GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV47GridStateFilterValue.gxTpr_Name, "TFPROFESIONALESAPELLIDOPRIMERO") == 0 )
            {
               AV17TFProfesionalesApellidoPrimero = AV47GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV47GridStateFilterValue.gxTpr_Name, "TFPROFESIONALESAPELLIDOPRIMERO_SEL") == 0 )
            {
               AV18TFProfesionalesApellidoPrimero_Sel = AV47GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV47GridStateFilterValue.gxTpr_Name, "TFPROFESIONALESAPELLIDOSEGUNDO") == 0 )
            {
               AV19TFProfesionalesApellidoSegundo = AV47GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV47GridStateFilterValue.gxTpr_Name, "TFPROFESIONALESAPELLIDOSEGUNDO_SEL") == 0 )
            {
               AV20TFProfesionalesApellidoSegundo_Sel = AV47GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV47GridStateFilterValue.gxTpr_Name, "TFPROFESIONALESTELEFONO") == 0 )
            {
               AV21TFProfesionalesTelefono = AV47GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV47GridStateFilterValue.gxTpr_Name, "TFPROFESIONALESTELEFONO_SEL") == 0 )
            {
               AV22TFProfesionalesTelefono_Sel = AV47GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV47GridStateFilterValue.gxTpr_Name, "TFESTADOSGENERICOSNOMBRE") == 0 )
            {
               AV23TFEstadosGenericosNombre = AV47GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV47GridStateFilterValue.gxTpr_Name, "TFESTADOSGENERICOSNOMBRE_SEL") == 0 )
            {
               AV24TFEstadosGenericosNombre_Sel = AV47GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV47GridStateFilterValue.gxTpr_Name, "TFPROFESIONALESVERDATPERSOL_SEL") == 0 )
            {
               AV25TFProfesionalesVerDatPerSol_SelsJson = AV47GridStateFilterValue.gxTpr_Value;
               AV26TFProfesionalesVerDatPerSol_Sels.FromJSonString(AV25TFProfesionalesVerDatPerSol_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV47GridStateFilterValue.gxTpr_Name, "TFPROFESIONALESFEEDBACKCANT") == 0 )
            {
               AV27TFProfesionalesFeedBackCant = (long)(Math.Round(NumberUtil.Val( AV47GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV28TFProfesionalesFeedBackCant_To = (long)(Math.Round(NumberUtil.Val( AV47GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV47GridStateFilterValue.gxTpr_Name, "TFPROFESIONALESFEEDBACK") == 0 )
            {
               AV29TFProfesionalesFeedback = NumberUtil.Val( AV47GridStateFilterValue.gxTpr_Value, ".");
               AV30TFProfesionalesFeedback_To = NumberUtil.Val( AV47GridStateFilterValue.gxTpr_Valueto, ".");
            }
            else if ( StringUtil.StrCmp(AV47GridStateFilterValue.gxTpr_Name, "TFPROFESIONALESPERALTSHOP_SEL") == 0 )
            {
               AV31TFProfesionalesPerAltShop_SelsJson = AV47GridStateFilterValue.gxTpr_Value;
               AV32TFProfesionalesPerAltShop_Sels.FromJSonString(AV31TFProfesionalesPerAltShop_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV47GridStateFilterValue.gxTpr_Name, "PARM_&RUBROSID") == 0 )
            {
               AV56RubrosId = (short)(Math.Round(NumberUtil.Val( AV47GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
            }
            AV57GXV1 = (int)(AV57GXV1+1);
         }
      }

      protected void S121( )
      {
         /* 'LOADPROFESIONALESIDOPTIONS' Routine */
         returnInSub = false;
         AV11TFProfesionalesId = AV33SearchTxt;
         AV12TFProfesionalesId_Sel = "";
         GXPagingIdx2 = 0;
         GXPagingFrom2 = AV34SkipItems;
         GXPagingTo2 = (int)(AV34SkipItems+AV36MaxItems);
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A267ProfesionalesVerDatPerSol ,
                                              AV26TFProfesionalesVerDatPerSol_Sels ,
                                              A436ProfesionalesPerAltShop ,
                                              AV32TFProfesionalesPerAltShop_Sels ,
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
                                              AV26TFProfesionalesVerDatPerSol_Sels.Count ,
                                              AV27TFProfesionalesFeedBackCant ,
                                              AV28TFProfesionalesFeedBackCant_To ,
                                              AV29TFProfesionalesFeedback ,
                                              AV30TFProfesionalesFeedback_To ,
                                              AV32TFProfesionalesPerAltShop_Sels.Count ,
                                              A120ProfesionalesId ,
                                              A166ProfesionalesPrimerNombre ,
                                              A191ProfesionalesSegundoNombre ,
                                              A167ProfesionalesApellidoPrimero ,
                                              A192ProfesionalesApellidoSegundo ,
                                              A170ProfesionalesTelefono ,
                                              A109EstadosGenericosNombre ,
                                              A268ProfesionalesFeedBackCant ,
                                              A269ProfesionalesFeedBackProm ,
                                              AV55FilterFullText ,
                                              A270ProfesionalesFeedback ,
                                              AV56RubrosId ,
                                              A121RubrosId } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.INT, TypeConstants.LONG, TypeConstants.DECIMAL, TypeConstants.DECIMAL,
                                              TypeConstants.SHORT, TypeConstants.SHORT
                                              }
         });
         lV11TFProfesionalesId = StringUtil.PadR( StringUtil.RTrim( AV11TFProfesionalesId), 20, "%");
         lV13TFProfesionalesPrimerNombre = StringUtil.PadR( StringUtil.RTrim( AV13TFProfesionalesPrimerNombre), 30, "%");
         lV15TFProfesionalesSegundoNombre = StringUtil.PadR( StringUtil.RTrim( AV15TFProfesionalesSegundoNombre), 30, "%");
         lV17TFProfesionalesApellidoPrimero = StringUtil.PadR( StringUtil.RTrim( AV17TFProfesionalesApellidoPrimero), 30, "%");
         lV19TFProfesionalesApellidoSegundo = StringUtil.PadR( StringUtil.RTrim( AV19TFProfesionalesApellidoSegundo), 30, "%");
         lV21TFProfesionalesTelefono = StringUtil.PadR( StringUtil.RTrim( AV21TFProfesionalesTelefono), 20, "%");
         lV23TFEstadosGenericosNombre = StringUtil.PadR( StringUtil.RTrim( AV23TFEstadosGenericosNombre), 80, "%");
         /* Using cursor P004E2 */
         pr_default.execute(0, new Object[] {AV56RubrosId, lV11TFProfesionalesId, AV12TFProfesionalesId_Sel, lV13TFProfesionalesPrimerNombre, AV14TFProfesionalesPrimerNombre_Sel, lV15TFProfesionalesSegundoNombre, AV16TFProfesionalesSegundoNombre_Sel, lV17TFProfesionalesApellidoPrimero, AV18TFProfesionalesApellidoPrimero_Sel, lV19TFProfesionalesApellidoSegundo, AV20TFProfesionalesApellidoSegundo_Sel, lV21TFProfesionalesTelefono, AV22TFProfesionalesTelefono_Sel, lV23TFEstadosGenericosNombre, AV24TFEstadosGenericosNombre_Sel, AV27TFProfesionalesFeedBackCant, AV28TFProfesionalesFeedBackCant_To, AV29TFProfesionalesFeedback, AV30TFProfesionalesFeedback_To});
         while ( ( (pr_default.getStatus(0) != 101) ) && ( ( GXPagingTo2 == GXPagingFrom2 ) || ( GXPagingIdx2 < GXPagingTo2 ) ) )
         {
            A107EstadosTipo = P004E2_A107EstadosTipo[0];
            A108EstadosGenericosId = P004E2_A108EstadosGenericosId[0];
            A121RubrosId = P004E2_A121RubrosId[0];
            A436ProfesionalesPerAltShop = P004E2_A436ProfesionalesPerAltShop[0];
            n436ProfesionalesPerAltShop = P004E2_n436ProfesionalesPerAltShop[0];
            A270ProfesionalesFeedback = P004E2_A270ProfesionalesFeedback[0];
            A267ProfesionalesVerDatPerSol = P004E2_A267ProfesionalesVerDatPerSol[0];
            A109EstadosGenericosNombre = P004E2_A109EstadosGenericosNombre[0];
            A170ProfesionalesTelefono = P004E2_A170ProfesionalesTelefono[0];
            A192ProfesionalesApellidoSegundo = P004E2_A192ProfesionalesApellidoSegundo[0];
            A167ProfesionalesApellidoPrimero = P004E2_A167ProfesionalesApellidoPrimero[0];
            A191ProfesionalesSegundoNombre = P004E2_A191ProfesionalesSegundoNombre[0];
            A166ProfesionalesPrimerNombre = P004E2_A166ProfesionalesPrimerNombre[0];
            A120ProfesionalesId = P004E2_A120ProfesionalesId[0];
            A269ProfesionalesFeedBackProm = P004E2_A269ProfesionalesFeedBackProm[0];
            A268ProfesionalesFeedBackCant = P004E2_A268ProfesionalesFeedBackCant[0];
            A107EstadosTipo = P004E2_A107EstadosTipo[0];
            A108EstadosGenericosId = P004E2_A108EstadosGenericosId[0];
            A436ProfesionalesPerAltShop = P004E2_A436ProfesionalesPerAltShop[0];
            n436ProfesionalesPerAltShop = P004E2_n436ProfesionalesPerAltShop[0];
            A270ProfesionalesFeedback = P004E2_A270ProfesionalesFeedback[0];
            A267ProfesionalesVerDatPerSol = P004E2_A267ProfesionalesVerDatPerSol[0];
            A170ProfesionalesTelefono = P004E2_A170ProfesionalesTelefono[0];
            A192ProfesionalesApellidoSegundo = P004E2_A192ProfesionalesApellidoSegundo[0];
            A167ProfesionalesApellidoPrimero = P004E2_A167ProfesionalesApellidoPrimero[0];
            A191ProfesionalesSegundoNombre = P004E2_A191ProfesionalesSegundoNombre[0];
            A166ProfesionalesPrimerNombre = P004E2_A166ProfesionalesPrimerNombre[0];
            A269ProfesionalesFeedBackProm = P004E2_A269ProfesionalesFeedBackProm[0];
            A268ProfesionalesFeedBackCant = P004E2_A268ProfesionalesFeedBackCant[0];
            A109EstadosGenericosNombre = P004E2_A109EstadosGenericosNombre[0];
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV55FilterFullText)) || ( ( StringUtil.Like( StringUtil.Upper( A120ProfesionalesId) , StringUtil.PadR( "%" + StringUtil.Upper( AV55FilterFullText) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A166ProfesionalesPrimerNombre) , StringUtil.PadR( "%" + StringUtil.Upper( AV55FilterFullText) , 255 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Upper( A191ProfesionalesSegundoNombre) , StringUtil.PadR( "%" + StringUtil.Upper( AV55FilterFullText) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A167ProfesionalesApellidoPrimero) , StringUtil.PadR( "%" + StringUtil.Upper( AV55FilterFullText) , 255 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Upper( A192ProfesionalesApellidoSegundo) , StringUtil.PadR( "%" + StringUtil.Upper( AV55FilterFullText) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A170ProfesionalesTelefono) , StringUtil.PadR( "%" + StringUtil.Upper( AV55FilterFullText) , 255 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Upper( A109EstadosGenericosNombre) , StringUtil.PadR( "%" + StringUtil.Upper( AV55FilterFullText) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( context.GetMessage( "si", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV55FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A267ProfesionalesVerDatPerSol, "S") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "no", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV55FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A267ProfesionalesVerDatPerSol, "N") == 0 ) ) || ( StringUtil.Like( StringUtil.Str( (decimal)(A268ProfesionalesFeedBackCant), 18, 0) , StringUtil.PadR( "%" + AV55FilterFullText , 254 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Str( A270ProfesionalesFeedback, 10, 2) , StringUtil.PadR( "%" + AV55FilterFullText , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( context.GetMessage( "no permitir", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV55FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A436ProfesionalesPerAltShop, "N") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "permitir", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV55FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A436ProfesionalesPerAltShop, "S") == 0 ) ) )
            )
            {
               GXPagingIdx2 = (int)(GXPagingIdx2+1);
               if ( GXPagingIdx2 > GXPagingFrom2 )
               {
                  AV38Option = (String.IsNullOrEmpty(StringUtil.RTrim( A120ProfesionalesId)) ? "<#Empty#>" : A120ProfesionalesId);
                  AV39Options.Add(AV38Option, 0);
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
         AV13TFProfesionalesPrimerNombre = AV33SearchTxt;
         AV14TFProfesionalesPrimerNombre_Sel = "";
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              A267ProfesionalesVerDatPerSol ,
                                              AV26TFProfesionalesVerDatPerSol_Sels ,
                                              A436ProfesionalesPerAltShop ,
                                              AV32TFProfesionalesPerAltShop_Sels ,
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
                                              AV26TFProfesionalesVerDatPerSol_Sels.Count ,
                                              AV27TFProfesionalesFeedBackCant ,
                                              AV28TFProfesionalesFeedBackCant_To ,
                                              AV29TFProfesionalesFeedback ,
                                              AV30TFProfesionalesFeedback_To ,
                                              AV32TFProfesionalesPerAltShop_Sels.Count ,
                                              A120ProfesionalesId ,
                                              A166ProfesionalesPrimerNombre ,
                                              A191ProfesionalesSegundoNombre ,
                                              A167ProfesionalesApellidoPrimero ,
                                              A192ProfesionalesApellidoSegundo ,
                                              A170ProfesionalesTelefono ,
                                              A109EstadosGenericosNombre ,
                                              A268ProfesionalesFeedBackCant ,
                                              A269ProfesionalesFeedBackProm ,
                                              AV55FilterFullText ,
                                              A270ProfesionalesFeedback ,
                                              AV56RubrosId ,
                                              A121RubrosId } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.INT, TypeConstants.LONG, TypeConstants.DECIMAL, TypeConstants.DECIMAL,
                                              TypeConstants.SHORT, TypeConstants.SHORT
                                              }
         });
         lV11TFProfesionalesId = StringUtil.PadR( StringUtil.RTrim( AV11TFProfesionalesId), 20, "%");
         lV13TFProfesionalesPrimerNombre = StringUtil.PadR( StringUtil.RTrim( AV13TFProfesionalesPrimerNombre), 30, "%");
         lV15TFProfesionalesSegundoNombre = StringUtil.PadR( StringUtil.RTrim( AV15TFProfesionalesSegundoNombre), 30, "%");
         lV17TFProfesionalesApellidoPrimero = StringUtil.PadR( StringUtil.RTrim( AV17TFProfesionalesApellidoPrimero), 30, "%");
         lV19TFProfesionalesApellidoSegundo = StringUtil.PadR( StringUtil.RTrim( AV19TFProfesionalesApellidoSegundo), 30, "%");
         lV21TFProfesionalesTelefono = StringUtil.PadR( StringUtil.RTrim( AV21TFProfesionalesTelefono), 20, "%");
         lV23TFEstadosGenericosNombre = StringUtil.PadR( StringUtil.RTrim( AV23TFEstadosGenericosNombre), 80, "%");
         /* Using cursor P004E3 */
         pr_default.execute(1, new Object[] {AV56RubrosId, lV11TFProfesionalesId, AV12TFProfesionalesId_Sel, lV13TFProfesionalesPrimerNombre, AV14TFProfesionalesPrimerNombre_Sel, lV15TFProfesionalesSegundoNombre, AV16TFProfesionalesSegundoNombre_Sel, lV17TFProfesionalesApellidoPrimero, AV18TFProfesionalesApellidoPrimero_Sel, lV19TFProfesionalesApellidoSegundo, AV20TFProfesionalesApellidoSegundo_Sel, lV21TFProfesionalesTelefono, AV22TFProfesionalesTelefono_Sel, lV23TFEstadosGenericosNombre, AV24TFEstadosGenericosNombre_Sel, AV27TFProfesionalesFeedBackCant, AV28TFProfesionalesFeedBackCant_To, AV29TFProfesionalesFeedback, AV30TFProfesionalesFeedback_To});
         while ( (pr_default.getStatus(1) != 101) )
         {
            BRK4E3 = false;
            A107EstadosTipo = P004E3_A107EstadosTipo[0];
            A108EstadosGenericosId = P004E3_A108EstadosGenericosId[0];
            A121RubrosId = P004E3_A121RubrosId[0];
            A166ProfesionalesPrimerNombre = P004E3_A166ProfesionalesPrimerNombre[0];
            A436ProfesionalesPerAltShop = P004E3_A436ProfesionalesPerAltShop[0];
            n436ProfesionalesPerAltShop = P004E3_n436ProfesionalesPerAltShop[0];
            A270ProfesionalesFeedback = P004E3_A270ProfesionalesFeedback[0];
            A267ProfesionalesVerDatPerSol = P004E3_A267ProfesionalesVerDatPerSol[0];
            A109EstadosGenericosNombre = P004E3_A109EstadosGenericosNombre[0];
            A170ProfesionalesTelefono = P004E3_A170ProfesionalesTelefono[0];
            A192ProfesionalesApellidoSegundo = P004E3_A192ProfesionalesApellidoSegundo[0];
            A167ProfesionalesApellidoPrimero = P004E3_A167ProfesionalesApellidoPrimero[0];
            A191ProfesionalesSegundoNombre = P004E3_A191ProfesionalesSegundoNombre[0];
            A120ProfesionalesId = P004E3_A120ProfesionalesId[0];
            A269ProfesionalesFeedBackProm = P004E3_A269ProfesionalesFeedBackProm[0];
            A268ProfesionalesFeedBackCant = P004E3_A268ProfesionalesFeedBackCant[0];
            A107EstadosTipo = P004E3_A107EstadosTipo[0];
            A108EstadosGenericosId = P004E3_A108EstadosGenericosId[0];
            A166ProfesionalesPrimerNombre = P004E3_A166ProfesionalesPrimerNombre[0];
            A436ProfesionalesPerAltShop = P004E3_A436ProfesionalesPerAltShop[0];
            n436ProfesionalesPerAltShop = P004E3_n436ProfesionalesPerAltShop[0];
            A270ProfesionalesFeedback = P004E3_A270ProfesionalesFeedback[0];
            A267ProfesionalesVerDatPerSol = P004E3_A267ProfesionalesVerDatPerSol[0];
            A170ProfesionalesTelefono = P004E3_A170ProfesionalesTelefono[0];
            A192ProfesionalesApellidoSegundo = P004E3_A192ProfesionalesApellidoSegundo[0];
            A167ProfesionalesApellidoPrimero = P004E3_A167ProfesionalesApellidoPrimero[0];
            A191ProfesionalesSegundoNombre = P004E3_A191ProfesionalesSegundoNombre[0];
            A269ProfesionalesFeedBackProm = P004E3_A269ProfesionalesFeedBackProm[0];
            A268ProfesionalesFeedBackCant = P004E3_A268ProfesionalesFeedBackCant[0];
            A109EstadosGenericosNombre = P004E3_A109EstadosGenericosNombre[0];
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV55FilterFullText)) || ( ( StringUtil.Like( StringUtil.Upper( A120ProfesionalesId) , StringUtil.PadR( "%" + StringUtil.Upper( AV55FilterFullText) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A166ProfesionalesPrimerNombre) , StringUtil.PadR( "%" + StringUtil.Upper( AV55FilterFullText) , 255 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Upper( A191ProfesionalesSegundoNombre) , StringUtil.PadR( "%" + StringUtil.Upper( AV55FilterFullText) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A167ProfesionalesApellidoPrimero) , StringUtil.PadR( "%" + StringUtil.Upper( AV55FilterFullText) , 255 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Upper( A192ProfesionalesApellidoSegundo) , StringUtil.PadR( "%" + StringUtil.Upper( AV55FilterFullText) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A170ProfesionalesTelefono) , StringUtil.PadR( "%" + StringUtil.Upper( AV55FilterFullText) , 255 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Upper( A109EstadosGenericosNombre) , StringUtil.PadR( "%" + StringUtil.Upper( AV55FilterFullText) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( context.GetMessage( "si", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV55FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A267ProfesionalesVerDatPerSol, "S") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "no", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV55FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A267ProfesionalesVerDatPerSol, "N") == 0 ) ) || ( StringUtil.Like( StringUtil.Str( (decimal)(A268ProfesionalesFeedBackCant), 18, 0) , StringUtil.PadR( "%" + AV55FilterFullText , 254 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Str( A270ProfesionalesFeedback, 10, 2) , StringUtil.PadR( "%" + AV55FilterFullText , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( context.GetMessage( "no permitir", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV55FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A436ProfesionalesPerAltShop, "N") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "permitir", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV55FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A436ProfesionalesPerAltShop, "S") == 0 ) ) )
            )
            {
               AV43count = 0;
               while ( (pr_default.getStatus(1) != 101) && ( P004E3_A121RubrosId[0] == A121RubrosId ) && ( StringUtil.StrCmp(P004E3_A166ProfesionalesPrimerNombre[0], A166ProfesionalesPrimerNombre) == 0 ) )
               {
                  BRK4E3 = false;
                  A120ProfesionalesId = P004E3_A120ProfesionalesId[0];
                  AV43count = (long)(AV43count+1);
                  BRK4E3 = true;
                  pr_default.readNext(1);
               }
               if ( (0==AV34SkipItems) )
               {
                  AV38Option = (String.IsNullOrEmpty(StringUtil.RTrim( A166ProfesionalesPrimerNombre)) ? "<#Empty#>" : A166ProfesionalesPrimerNombre);
                  AV39Options.Add(AV38Option, 0);
                  AV42OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV43count), "Z,ZZZ,ZZZ,ZZ9")), 0);
                  if ( AV39Options.Count == 10 )
                  {
                     /* Exit For each command. Update data (if necessary), close cursors & exit. */
                     if (true) break;
                  }
               }
               else
               {
                  AV34SkipItems = (short)(AV34SkipItems-1);
               }
            }
            if ( ! BRK4E3 )
            {
               BRK4E3 = true;
               pr_default.readNext(1);
            }
         }
         pr_default.close(1);
      }

      protected void S141( )
      {
         /* 'LOADPROFESIONALESSEGUNDONOMBREOPTIONS' Routine */
         returnInSub = false;
         AV15TFProfesionalesSegundoNombre = AV33SearchTxt;
         AV16TFProfesionalesSegundoNombre_Sel = "";
         pr_default.dynParam(2, new Object[]{ new Object[]{
                                              A267ProfesionalesVerDatPerSol ,
                                              AV26TFProfesionalesVerDatPerSol_Sels ,
                                              A436ProfesionalesPerAltShop ,
                                              AV32TFProfesionalesPerAltShop_Sels ,
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
                                              AV26TFProfesionalesVerDatPerSol_Sels.Count ,
                                              AV27TFProfesionalesFeedBackCant ,
                                              AV28TFProfesionalesFeedBackCant_To ,
                                              AV29TFProfesionalesFeedback ,
                                              AV30TFProfesionalesFeedback_To ,
                                              AV32TFProfesionalesPerAltShop_Sels.Count ,
                                              A120ProfesionalesId ,
                                              A166ProfesionalesPrimerNombre ,
                                              A191ProfesionalesSegundoNombre ,
                                              A167ProfesionalesApellidoPrimero ,
                                              A192ProfesionalesApellidoSegundo ,
                                              A170ProfesionalesTelefono ,
                                              A109EstadosGenericosNombre ,
                                              A268ProfesionalesFeedBackCant ,
                                              A269ProfesionalesFeedBackProm ,
                                              AV55FilterFullText ,
                                              A270ProfesionalesFeedback ,
                                              AV56RubrosId ,
                                              A121RubrosId } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.INT, TypeConstants.LONG, TypeConstants.DECIMAL, TypeConstants.DECIMAL,
                                              TypeConstants.SHORT, TypeConstants.SHORT
                                              }
         });
         lV11TFProfesionalesId = StringUtil.PadR( StringUtil.RTrim( AV11TFProfesionalesId), 20, "%");
         lV13TFProfesionalesPrimerNombre = StringUtil.PadR( StringUtil.RTrim( AV13TFProfesionalesPrimerNombre), 30, "%");
         lV15TFProfesionalesSegundoNombre = StringUtil.PadR( StringUtil.RTrim( AV15TFProfesionalesSegundoNombre), 30, "%");
         lV17TFProfesionalesApellidoPrimero = StringUtil.PadR( StringUtil.RTrim( AV17TFProfesionalesApellidoPrimero), 30, "%");
         lV19TFProfesionalesApellidoSegundo = StringUtil.PadR( StringUtil.RTrim( AV19TFProfesionalesApellidoSegundo), 30, "%");
         lV21TFProfesionalesTelefono = StringUtil.PadR( StringUtil.RTrim( AV21TFProfesionalesTelefono), 20, "%");
         lV23TFEstadosGenericosNombre = StringUtil.PadR( StringUtil.RTrim( AV23TFEstadosGenericosNombre), 80, "%");
         /* Using cursor P004E4 */
         pr_default.execute(2, new Object[] {AV56RubrosId, lV11TFProfesionalesId, AV12TFProfesionalesId_Sel, lV13TFProfesionalesPrimerNombre, AV14TFProfesionalesPrimerNombre_Sel, lV15TFProfesionalesSegundoNombre, AV16TFProfesionalesSegundoNombre_Sel, lV17TFProfesionalesApellidoPrimero, AV18TFProfesionalesApellidoPrimero_Sel, lV19TFProfesionalesApellidoSegundo, AV20TFProfesionalesApellidoSegundo_Sel, lV21TFProfesionalesTelefono, AV22TFProfesionalesTelefono_Sel, lV23TFEstadosGenericosNombre, AV24TFEstadosGenericosNombre_Sel, AV27TFProfesionalesFeedBackCant, AV28TFProfesionalesFeedBackCant_To, AV29TFProfesionalesFeedback, AV30TFProfesionalesFeedback_To});
         while ( (pr_default.getStatus(2) != 101) )
         {
            BRK4E5 = false;
            A107EstadosTipo = P004E4_A107EstadosTipo[0];
            A108EstadosGenericosId = P004E4_A108EstadosGenericosId[0];
            A121RubrosId = P004E4_A121RubrosId[0];
            A191ProfesionalesSegundoNombre = P004E4_A191ProfesionalesSegundoNombre[0];
            A436ProfesionalesPerAltShop = P004E4_A436ProfesionalesPerAltShop[0];
            n436ProfesionalesPerAltShop = P004E4_n436ProfesionalesPerAltShop[0];
            A270ProfesionalesFeedback = P004E4_A270ProfesionalesFeedback[0];
            A267ProfesionalesVerDatPerSol = P004E4_A267ProfesionalesVerDatPerSol[0];
            A109EstadosGenericosNombre = P004E4_A109EstadosGenericosNombre[0];
            A170ProfesionalesTelefono = P004E4_A170ProfesionalesTelefono[0];
            A192ProfesionalesApellidoSegundo = P004E4_A192ProfesionalesApellidoSegundo[0];
            A167ProfesionalesApellidoPrimero = P004E4_A167ProfesionalesApellidoPrimero[0];
            A166ProfesionalesPrimerNombre = P004E4_A166ProfesionalesPrimerNombre[0];
            A120ProfesionalesId = P004E4_A120ProfesionalesId[0];
            A269ProfesionalesFeedBackProm = P004E4_A269ProfesionalesFeedBackProm[0];
            A268ProfesionalesFeedBackCant = P004E4_A268ProfesionalesFeedBackCant[0];
            A107EstadosTipo = P004E4_A107EstadosTipo[0];
            A108EstadosGenericosId = P004E4_A108EstadosGenericosId[0];
            A191ProfesionalesSegundoNombre = P004E4_A191ProfesionalesSegundoNombre[0];
            A436ProfesionalesPerAltShop = P004E4_A436ProfesionalesPerAltShop[0];
            n436ProfesionalesPerAltShop = P004E4_n436ProfesionalesPerAltShop[0];
            A270ProfesionalesFeedback = P004E4_A270ProfesionalesFeedback[0];
            A267ProfesionalesVerDatPerSol = P004E4_A267ProfesionalesVerDatPerSol[0];
            A170ProfesionalesTelefono = P004E4_A170ProfesionalesTelefono[0];
            A192ProfesionalesApellidoSegundo = P004E4_A192ProfesionalesApellidoSegundo[0];
            A167ProfesionalesApellidoPrimero = P004E4_A167ProfesionalesApellidoPrimero[0];
            A166ProfesionalesPrimerNombre = P004E4_A166ProfesionalesPrimerNombre[0];
            A269ProfesionalesFeedBackProm = P004E4_A269ProfesionalesFeedBackProm[0];
            A268ProfesionalesFeedBackCant = P004E4_A268ProfesionalesFeedBackCant[0];
            A109EstadosGenericosNombre = P004E4_A109EstadosGenericosNombre[0];
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV55FilterFullText)) || ( ( StringUtil.Like( StringUtil.Upper( A120ProfesionalesId) , StringUtil.PadR( "%" + StringUtil.Upper( AV55FilterFullText) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A166ProfesionalesPrimerNombre) , StringUtil.PadR( "%" + StringUtil.Upper( AV55FilterFullText) , 255 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Upper( A191ProfesionalesSegundoNombre) , StringUtil.PadR( "%" + StringUtil.Upper( AV55FilterFullText) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A167ProfesionalesApellidoPrimero) , StringUtil.PadR( "%" + StringUtil.Upper( AV55FilterFullText) , 255 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Upper( A192ProfesionalesApellidoSegundo) , StringUtil.PadR( "%" + StringUtil.Upper( AV55FilterFullText) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A170ProfesionalesTelefono) , StringUtil.PadR( "%" + StringUtil.Upper( AV55FilterFullText) , 255 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Upper( A109EstadosGenericosNombre) , StringUtil.PadR( "%" + StringUtil.Upper( AV55FilterFullText) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( context.GetMessage( "si", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV55FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A267ProfesionalesVerDatPerSol, "S") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "no", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV55FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A267ProfesionalesVerDatPerSol, "N") == 0 ) ) || ( StringUtil.Like( StringUtil.Str( (decimal)(A268ProfesionalesFeedBackCant), 18, 0) , StringUtil.PadR( "%" + AV55FilterFullText , 254 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Str( A270ProfesionalesFeedback, 10, 2) , StringUtil.PadR( "%" + AV55FilterFullText , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( context.GetMessage( "no permitir", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV55FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A436ProfesionalesPerAltShop, "N") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "permitir", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV55FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A436ProfesionalesPerAltShop, "S") == 0 ) ) )
            )
            {
               AV43count = 0;
               while ( (pr_default.getStatus(2) != 101) && ( P004E4_A121RubrosId[0] == A121RubrosId ) && ( StringUtil.StrCmp(P004E4_A191ProfesionalesSegundoNombre[0], A191ProfesionalesSegundoNombre) == 0 ) )
               {
                  BRK4E5 = false;
                  A120ProfesionalesId = P004E4_A120ProfesionalesId[0];
                  AV43count = (long)(AV43count+1);
                  BRK4E5 = true;
                  pr_default.readNext(2);
               }
               if ( (0==AV34SkipItems) )
               {
                  AV38Option = (String.IsNullOrEmpty(StringUtil.RTrim( A191ProfesionalesSegundoNombre)) ? "<#Empty#>" : A191ProfesionalesSegundoNombre);
                  AV39Options.Add(AV38Option, 0);
                  AV42OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV43count), "Z,ZZZ,ZZZ,ZZ9")), 0);
                  if ( AV39Options.Count == 10 )
                  {
                     /* Exit For each command. Update data (if necessary), close cursors & exit. */
                     if (true) break;
                  }
               }
               else
               {
                  AV34SkipItems = (short)(AV34SkipItems-1);
               }
            }
            if ( ! BRK4E5 )
            {
               BRK4E5 = true;
               pr_default.readNext(2);
            }
         }
         pr_default.close(2);
      }

      protected void S151( )
      {
         /* 'LOADPROFESIONALESAPELLIDOPRIMEROOPTIONS' Routine */
         returnInSub = false;
         AV17TFProfesionalesApellidoPrimero = AV33SearchTxt;
         AV18TFProfesionalesApellidoPrimero_Sel = "";
         pr_default.dynParam(3, new Object[]{ new Object[]{
                                              A267ProfesionalesVerDatPerSol ,
                                              AV26TFProfesionalesVerDatPerSol_Sels ,
                                              A436ProfesionalesPerAltShop ,
                                              AV32TFProfesionalesPerAltShop_Sels ,
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
                                              AV26TFProfesionalesVerDatPerSol_Sels.Count ,
                                              AV27TFProfesionalesFeedBackCant ,
                                              AV28TFProfesionalesFeedBackCant_To ,
                                              AV29TFProfesionalesFeedback ,
                                              AV30TFProfesionalesFeedback_To ,
                                              AV32TFProfesionalesPerAltShop_Sels.Count ,
                                              A120ProfesionalesId ,
                                              A166ProfesionalesPrimerNombre ,
                                              A191ProfesionalesSegundoNombre ,
                                              A167ProfesionalesApellidoPrimero ,
                                              A192ProfesionalesApellidoSegundo ,
                                              A170ProfesionalesTelefono ,
                                              A109EstadosGenericosNombre ,
                                              A268ProfesionalesFeedBackCant ,
                                              A269ProfesionalesFeedBackProm ,
                                              AV55FilterFullText ,
                                              A270ProfesionalesFeedback ,
                                              AV56RubrosId ,
                                              A121RubrosId } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.INT, TypeConstants.LONG, TypeConstants.DECIMAL, TypeConstants.DECIMAL,
                                              TypeConstants.SHORT, TypeConstants.SHORT
                                              }
         });
         lV11TFProfesionalesId = StringUtil.PadR( StringUtil.RTrim( AV11TFProfesionalesId), 20, "%");
         lV13TFProfesionalesPrimerNombre = StringUtil.PadR( StringUtil.RTrim( AV13TFProfesionalesPrimerNombre), 30, "%");
         lV15TFProfesionalesSegundoNombre = StringUtil.PadR( StringUtil.RTrim( AV15TFProfesionalesSegundoNombre), 30, "%");
         lV17TFProfesionalesApellidoPrimero = StringUtil.PadR( StringUtil.RTrim( AV17TFProfesionalesApellidoPrimero), 30, "%");
         lV19TFProfesionalesApellidoSegundo = StringUtil.PadR( StringUtil.RTrim( AV19TFProfesionalesApellidoSegundo), 30, "%");
         lV21TFProfesionalesTelefono = StringUtil.PadR( StringUtil.RTrim( AV21TFProfesionalesTelefono), 20, "%");
         lV23TFEstadosGenericosNombre = StringUtil.PadR( StringUtil.RTrim( AV23TFEstadosGenericosNombre), 80, "%");
         /* Using cursor P004E5 */
         pr_default.execute(3, new Object[] {AV56RubrosId, lV11TFProfesionalesId, AV12TFProfesionalesId_Sel, lV13TFProfesionalesPrimerNombre, AV14TFProfesionalesPrimerNombre_Sel, lV15TFProfesionalesSegundoNombre, AV16TFProfesionalesSegundoNombre_Sel, lV17TFProfesionalesApellidoPrimero, AV18TFProfesionalesApellidoPrimero_Sel, lV19TFProfesionalesApellidoSegundo, AV20TFProfesionalesApellidoSegundo_Sel, lV21TFProfesionalesTelefono, AV22TFProfesionalesTelefono_Sel, lV23TFEstadosGenericosNombre, AV24TFEstadosGenericosNombre_Sel, AV27TFProfesionalesFeedBackCant, AV28TFProfesionalesFeedBackCant_To, AV29TFProfesionalesFeedback, AV30TFProfesionalesFeedback_To});
         while ( (pr_default.getStatus(3) != 101) )
         {
            BRK4E7 = false;
            A107EstadosTipo = P004E5_A107EstadosTipo[0];
            A108EstadosGenericosId = P004E5_A108EstadosGenericosId[0];
            A121RubrosId = P004E5_A121RubrosId[0];
            A167ProfesionalesApellidoPrimero = P004E5_A167ProfesionalesApellidoPrimero[0];
            A436ProfesionalesPerAltShop = P004E5_A436ProfesionalesPerAltShop[0];
            n436ProfesionalesPerAltShop = P004E5_n436ProfesionalesPerAltShop[0];
            A270ProfesionalesFeedback = P004E5_A270ProfesionalesFeedback[0];
            A267ProfesionalesVerDatPerSol = P004E5_A267ProfesionalesVerDatPerSol[0];
            A109EstadosGenericosNombre = P004E5_A109EstadosGenericosNombre[0];
            A170ProfesionalesTelefono = P004E5_A170ProfesionalesTelefono[0];
            A192ProfesionalesApellidoSegundo = P004E5_A192ProfesionalesApellidoSegundo[0];
            A191ProfesionalesSegundoNombre = P004E5_A191ProfesionalesSegundoNombre[0];
            A166ProfesionalesPrimerNombre = P004E5_A166ProfesionalesPrimerNombre[0];
            A120ProfesionalesId = P004E5_A120ProfesionalesId[0];
            A269ProfesionalesFeedBackProm = P004E5_A269ProfesionalesFeedBackProm[0];
            A268ProfesionalesFeedBackCant = P004E5_A268ProfesionalesFeedBackCant[0];
            A107EstadosTipo = P004E5_A107EstadosTipo[0];
            A108EstadosGenericosId = P004E5_A108EstadosGenericosId[0];
            A167ProfesionalesApellidoPrimero = P004E5_A167ProfesionalesApellidoPrimero[0];
            A436ProfesionalesPerAltShop = P004E5_A436ProfesionalesPerAltShop[0];
            n436ProfesionalesPerAltShop = P004E5_n436ProfesionalesPerAltShop[0];
            A270ProfesionalesFeedback = P004E5_A270ProfesionalesFeedback[0];
            A267ProfesionalesVerDatPerSol = P004E5_A267ProfesionalesVerDatPerSol[0];
            A170ProfesionalesTelefono = P004E5_A170ProfesionalesTelefono[0];
            A192ProfesionalesApellidoSegundo = P004E5_A192ProfesionalesApellidoSegundo[0];
            A191ProfesionalesSegundoNombre = P004E5_A191ProfesionalesSegundoNombre[0];
            A166ProfesionalesPrimerNombre = P004E5_A166ProfesionalesPrimerNombre[0];
            A269ProfesionalesFeedBackProm = P004E5_A269ProfesionalesFeedBackProm[0];
            A268ProfesionalesFeedBackCant = P004E5_A268ProfesionalesFeedBackCant[0];
            A109EstadosGenericosNombre = P004E5_A109EstadosGenericosNombre[0];
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV55FilterFullText)) || ( ( StringUtil.Like( StringUtil.Upper( A120ProfesionalesId) , StringUtil.PadR( "%" + StringUtil.Upper( AV55FilterFullText) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A166ProfesionalesPrimerNombre) , StringUtil.PadR( "%" + StringUtil.Upper( AV55FilterFullText) , 255 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Upper( A191ProfesionalesSegundoNombre) , StringUtil.PadR( "%" + StringUtil.Upper( AV55FilterFullText) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A167ProfesionalesApellidoPrimero) , StringUtil.PadR( "%" + StringUtil.Upper( AV55FilterFullText) , 255 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Upper( A192ProfesionalesApellidoSegundo) , StringUtil.PadR( "%" + StringUtil.Upper( AV55FilterFullText) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A170ProfesionalesTelefono) , StringUtil.PadR( "%" + StringUtil.Upper( AV55FilterFullText) , 255 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Upper( A109EstadosGenericosNombre) , StringUtil.PadR( "%" + StringUtil.Upper( AV55FilterFullText) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( context.GetMessage( "si", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV55FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A267ProfesionalesVerDatPerSol, "S") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "no", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV55FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A267ProfesionalesVerDatPerSol, "N") == 0 ) ) || ( StringUtil.Like( StringUtil.Str( (decimal)(A268ProfesionalesFeedBackCant), 18, 0) , StringUtil.PadR( "%" + AV55FilterFullText , 254 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Str( A270ProfesionalesFeedback, 10, 2) , StringUtil.PadR( "%" + AV55FilterFullText , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( context.GetMessage( "no permitir", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV55FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A436ProfesionalesPerAltShop, "N") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "permitir", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV55FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A436ProfesionalesPerAltShop, "S") == 0 ) ) )
            )
            {
               AV43count = 0;
               while ( (pr_default.getStatus(3) != 101) && ( P004E5_A121RubrosId[0] == A121RubrosId ) && ( StringUtil.StrCmp(P004E5_A167ProfesionalesApellidoPrimero[0], A167ProfesionalesApellidoPrimero) == 0 ) )
               {
                  BRK4E7 = false;
                  A120ProfesionalesId = P004E5_A120ProfesionalesId[0];
                  AV43count = (long)(AV43count+1);
                  BRK4E7 = true;
                  pr_default.readNext(3);
               }
               if ( (0==AV34SkipItems) )
               {
                  AV38Option = (String.IsNullOrEmpty(StringUtil.RTrim( A167ProfesionalesApellidoPrimero)) ? "<#Empty#>" : A167ProfesionalesApellidoPrimero);
                  AV39Options.Add(AV38Option, 0);
                  AV42OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV43count), "Z,ZZZ,ZZZ,ZZ9")), 0);
                  if ( AV39Options.Count == 10 )
                  {
                     /* Exit For each command. Update data (if necessary), close cursors & exit. */
                     if (true) break;
                  }
               }
               else
               {
                  AV34SkipItems = (short)(AV34SkipItems-1);
               }
            }
            if ( ! BRK4E7 )
            {
               BRK4E7 = true;
               pr_default.readNext(3);
            }
         }
         pr_default.close(3);
      }

      protected void S161( )
      {
         /* 'LOADPROFESIONALESAPELLIDOSEGUNDOOPTIONS' Routine */
         returnInSub = false;
         AV19TFProfesionalesApellidoSegundo = AV33SearchTxt;
         AV20TFProfesionalesApellidoSegundo_Sel = "";
         pr_default.dynParam(4, new Object[]{ new Object[]{
                                              A267ProfesionalesVerDatPerSol ,
                                              AV26TFProfesionalesVerDatPerSol_Sels ,
                                              A436ProfesionalesPerAltShop ,
                                              AV32TFProfesionalesPerAltShop_Sels ,
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
                                              AV26TFProfesionalesVerDatPerSol_Sels.Count ,
                                              AV27TFProfesionalesFeedBackCant ,
                                              AV28TFProfesionalesFeedBackCant_To ,
                                              AV29TFProfesionalesFeedback ,
                                              AV30TFProfesionalesFeedback_To ,
                                              AV32TFProfesionalesPerAltShop_Sels.Count ,
                                              A120ProfesionalesId ,
                                              A166ProfesionalesPrimerNombre ,
                                              A191ProfesionalesSegundoNombre ,
                                              A167ProfesionalesApellidoPrimero ,
                                              A192ProfesionalesApellidoSegundo ,
                                              A170ProfesionalesTelefono ,
                                              A109EstadosGenericosNombre ,
                                              A268ProfesionalesFeedBackCant ,
                                              A269ProfesionalesFeedBackProm ,
                                              AV55FilterFullText ,
                                              A270ProfesionalesFeedback ,
                                              AV56RubrosId ,
                                              A121RubrosId } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.INT, TypeConstants.LONG, TypeConstants.DECIMAL, TypeConstants.DECIMAL,
                                              TypeConstants.SHORT, TypeConstants.SHORT
                                              }
         });
         lV11TFProfesionalesId = StringUtil.PadR( StringUtil.RTrim( AV11TFProfesionalesId), 20, "%");
         lV13TFProfesionalesPrimerNombre = StringUtil.PadR( StringUtil.RTrim( AV13TFProfesionalesPrimerNombre), 30, "%");
         lV15TFProfesionalesSegundoNombre = StringUtil.PadR( StringUtil.RTrim( AV15TFProfesionalesSegundoNombre), 30, "%");
         lV17TFProfesionalesApellidoPrimero = StringUtil.PadR( StringUtil.RTrim( AV17TFProfesionalesApellidoPrimero), 30, "%");
         lV19TFProfesionalesApellidoSegundo = StringUtil.PadR( StringUtil.RTrim( AV19TFProfesionalesApellidoSegundo), 30, "%");
         lV21TFProfesionalesTelefono = StringUtil.PadR( StringUtil.RTrim( AV21TFProfesionalesTelefono), 20, "%");
         lV23TFEstadosGenericosNombre = StringUtil.PadR( StringUtil.RTrim( AV23TFEstadosGenericosNombre), 80, "%");
         /* Using cursor P004E6 */
         pr_default.execute(4, new Object[] {AV56RubrosId, lV11TFProfesionalesId, AV12TFProfesionalesId_Sel, lV13TFProfesionalesPrimerNombre, AV14TFProfesionalesPrimerNombre_Sel, lV15TFProfesionalesSegundoNombre, AV16TFProfesionalesSegundoNombre_Sel, lV17TFProfesionalesApellidoPrimero, AV18TFProfesionalesApellidoPrimero_Sel, lV19TFProfesionalesApellidoSegundo, AV20TFProfesionalesApellidoSegundo_Sel, lV21TFProfesionalesTelefono, AV22TFProfesionalesTelefono_Sel, lV23TFEstadosGenericosNombre, AV24TFEstadosGenericosNombre_Sel, AV27TFProfesionalesFeedBackCant, AV28TFProfesionalesFeedBackCant_To, AV29TFProfesionalesFeedback, AV30TFProfesionalesFeedback_To});
         while ( (pr_default.getStatus(4) != 101) )
         {
            BRK4E9 = false;
            A107EstadosTipo = P004E6_A107EstadosTipo[0];
            A108EstadosGenericosId = P004E6_A108EstadosGenericosId[0];
            A121RubrosId = P004E6_A121RubrosId[0];
            A192ProfesionalesApellidoSegundo = P004E6_A192ProfesionalesApellidoSegundo[0];
            A436ProfesionalesPerAltShop = P004E6_A436ProfesionalesPerAltShop[0];
            n436ProfesionalesPerAltShop = P004E6_n436ProfesionalesPerAltShop[0];
            A270ProfesionalesFeedback = P004E6_A270ProfesionalesFeedback[0];
            A267ProfesionalesVerDatPerSol = P004E6_A267ProfesionalesVerDatPerSol[0];
            A109EstadosGenericosNombre = P004E6_A109EstadosGenericosNombre[0];
            A170ProfesionalesTelefono = P004E6_A170ProfesionalesTelefono[0];
            A167ProfesionalesApellidoPrimero = P004E6_A167ProfesionalesApellidoPrimero[0];
            A191ProfesionalesSegundoNombre = P004E6_A191ProfesionalesSegundoNombre[0];
            A166ProfesionalesPrimerNombre = P004E6_A166ProfesionalesPrimerNombre[0];
            A120ProfesionalesId = P004E6_A120ProfesionalesId[0];
            A269ProfesionalesFeedBackProm = P004E6_A269ProfesionalesFeedBackProm[0];
            A268ProfesionalesFeedBackCant = P004E6_A268ProfesionalesFeedBackCant[0];
            A107EstadosTipo = P004E6_A107EstadosTipo[0];
            A108EstadosGenericosId = P004E6_A108EstadosGenericosId[0];
            A192ProfesionalesApellidoSegundo = P004E6_A192ProfesionalesApellidoSegundo[0];
            A436ProfesionalesPerAltShop = P004E6_A436ProfesionalesPerAltShop[0];
            n436ProfesionalesPerAltShop = P004E6_n436ProfesionalesPerAltShop[0];
            A270ProfesionalesFeedback = P004E6_A270ProfesionalesFeedback[0];
            A267ProfesionalesVerDatPerSol = P004E6_A267ProfesionalesVerDatPerSol[0];
            A170ProfesionalesTelefono = P004E6_A170ProfesionalesTelefono[0];
            A167ProfesionalesApellidoPrimero = P004E6_A167ProfesionalesApellidoPrimero[0];
            A191ProfesionalesSegundoNombre = P004E6_A191ProfesionalesSegundoNombre[0];
            A166ProfesionalesPrimerNombre = P004E6_A166ProfesionalesPrimerNombre[0];
            A269ProfesionalesFeedBackProm = P004E6_A269ProfesionalesFeedBackProm[0];
            A268ProfesionalesFeedBackCant = P004E6_A268ProfesionalesFeedBackCant[0];
            A109EstadosGenericosNombre = P004E6_A109EstadosGenericosNombre[0];
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV55FilterFullText)) || ( ( StringUtil.Like( StringUtil.Upper( A120ProfesionalesId) , StringUtil.PadR( "%" + StringUtil.Upper( AV55FilterFullText) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A166ProfesionalesPrimerNombre) , StringUtil.PadR( "%" + StringUtil.Upper( AV55FilterFullText) , 255 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Upper( A191ProfesionalesSegundoNombre) , StringUtil.PadR( "%" + StringUtil.Upper( AV55FilterFullText) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A167ProfesionalesApellidoPrimero) , StringUtil.PadR( "%" + StringUtil.Upper( AV55FilterFullText) , 255 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Upper( A192ProfesionalesApellidoSegundo) , StringUtil.PadR( "%" + StringUtil.Upper( AV55FilterFullText) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A170ProfesionalesTelefono) , StringUtil.PadR( "%" + StringUtil.Upper( AV55FilterFullText) , 255 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Upper( A109EstadosGenericosNombre) , StringUtil.PadR( "%" + StringUtil.Upper( AV55FilterFullText) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( context.GetMessage( "si", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV55FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A267ProfesionalesVerDatPerSol, "S") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "no", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV55FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A267ProfesionalesVerDatPerSol, "N") == 0 ) ) || ( StringUtil.Like( StringUtil.Str( (decimal)(A268ProfesionalesFeedBackCant), 18, 0) , StringUtil.PadR( "%" + AV55FilterFullText , 254 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Str( A270ProfesionalesFeedback, 10, 2) , StringUtil.PadR( "%" + AV55FilterFullText , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( context.GetMessage( "no permitir", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV55FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A436ProfesionalesPerAltShop, "N") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "permitir", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV55FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A436ProfesionalesPerAltShop, "S") == 0 ) ) )
            )
            {
               AV43count = 0;
               while ( (pr_default.getStatus(4) != 101) && ( P004E6_A121RubrosId[0] == A121RubrosId ) && ( StringUtil.StrCmp(P004E6_A192ProfesionalesApellidoSegundo[0], A192ProfesionalesApellidoSegundo) == 0 ) )
               {
                  BRK4E9 = false;
                  A120ProfesionalesId = P004E6_A120ProfesionalesId[0];
                  AV43count = (long)(AV43count+1);
                  BRK4E9 = true;
                  pr_default.readNext(4);
               }
               if ( (0==AV34SkipItems) )
               {
                  AV38Option = (String.IsNullOrEmpty(StringUtil.RTrim( A192ProfesionalesApellidoSegundo)) ? "<#Empty#>" : A192ProfesionalesApellidoSegundo);
                  AV39Options.Add(AV38Option, 0);
                  AV42OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV43count), "Z,ZZZ,ZZZ,ZZ9")), 0);
                  if ( AV39Options.Count == 10 )
                  {
                     /* Exit For each command. Update data (if necessary), close cursors & exit. */
                     if (true) break;
                  }
               }
               else
               {
                  AV34SkipItems = (short)(AV34SkipItems-1);
               }
            }
            if ( ! BRK4E9 )
            {
               BRK4E9 = true;
               pr_default.readNext(4);
            }
         }
         pr_default.close(4);
      }

      protected void S171( )
      {
         /* 'LOADPROFESIONALESTELEFONOOPTIONS' Routine */
         returnInSub = false;
         AV21TFProfesionalesTelefono = AV33SearchTxt;
         AV22TFProfesionalesTelefono_Sel = "";
         pr_default.dynParam(5, new Object[]{ new Object[]{
                                              A267ProfesionalesVerDatPerSol ,
                                              AV26TFProfesionalesVerDatPerSol_Sels ,
                                              A436ProfesionalesPerAltShop ,
                                              AV32TFProfesionalesPerAltShop_Sels ,
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
                                              AV26TFProfesionalesVerDatPerSol_Sels.Count ,
                                              AV27TFProfesionalesFeedBackCant ,
                                              AV28TFProfesionalesFeedBackCant_To ,
                                              AV29TFProfesionalesFeedback ,
                                              AV30TFProfesionalesFeedback_To ,
                                              AV32TFProfesionalesPerAltShop_Sels.Count ,
                                              A120ProfesionalesId ,
                                              A166ProfesionalesPrimerNombre ,
                                              A191ProfesionalesSegundoNombre ,
                                              A167ProfesionalesApellidoPrimero ,
                                              A192ProfesionalesApellidoSegundo ,
                                              A170ProfesionalesTelefono ,
                                              A109EstadosGenericosNombre ,
                                              A268ProfesionalesFeedBackCant ,
                                              A269ProfesionalesFeedBackProm ,
                                              AV55FilterFullText ,
                                              A270ProfesionalesFeedback ,
                                              AV56RubrosId ,
                                              A121RubrosId } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.INT, TypeConstants.LONG, TypeConstants.DECIMAL, TypeConstants.DECIMAL,
                                              TypeConstants.SHORT, TypeConstants.SHORT
                                              }
         });
         lV11TFProfesionalesId = StringUtil.PadR( StringUtil.RTrim( AV11TFProfesionalesId), 20, "%");
         lV13TFProfesionalesPrimerNombre = StringUtil.PadR( StringUtil.RTrim( AV13TFProfesionalesPrimerNombre), 30, "%");
         lV15TFProfesionalesSegundoNombre = StringUtil.PadR( StringUtil.RTrim( AV15TFProfesionalesSegundoNombre), 30, "%");
         lV17TFProfesionalesApellidoPrimero = StringUtil.PadR( StringUtil.RTrim( AV17TFProfesionalesApellidoPrimero), 30, "%");
         lV19TFProfesionalesApellidoSegundo = StringUtil.PadR( StringUtil.RTrim( AV19TFProfesionalesApellidoSegundo), 30, "%");
         lV21TFProfesionalesTelefono = StringUtil.PadR( StringUtil.RTrim( AV21TFProfesionalesTelefono), 20, "%");
         lV23TFEstadosGenericosNombre = StringUtil.PadR( StringUtil.RTrim( AV23TFEstadosGenericosNombre), 80, "%");
         /* Using cursor P004E7 */
         pr_default.execute(5, new Object[] {AV56RubrosId, lV11TFProfesionalesId, AV12TFProfesionalesId_Sel, lV13TFProfesionalesPrimerNombre, AV14TFProfesionalesPrimerNombre_Sel, lV15TFProfesionalesSegundoNombre, AV16TFProfesionalesSegundoNombre_Sel, lV17TFProfesionalesApellidoPrimero, AV18TFProfesionalesApellidoPrimero_Sel, lV19TFProfesionalesApellidoSegundo, AV20TFProfesionalesApellidoSegundo_Sel, lV21TFProfesionalesTelefono, AV22TFProfesionalesTelefono_Sel, lV23TFEstadosGenericosNombre, AV24TFEstadosGenericosNombre_Sel, AV27TFProfesionalesFeedBackCant, AV28TFProfesionalesFeedBackCant_To, AV29TFProfesionalesFeedback, AV30TFProfesionalesFeedback_To});
         while ( (pr_default.getStatus(5) != 101) )
         {
            BRK4E11 = false;
            A107EstadosTipo = P004E7_A107EstadosTipo[0];
            A108EstadosGenericosId = P004E7_A108EstadosGenericosId[0];
            A121RubrosId = P004E7_A121RubrosId[0];
            A170ProfesionalesTelefono = P004E7_A170ProfesionalesTelefono[0];
            A436ProfesionalesPerAltShop = P004E7_A436ProfesionalesPerAltShop[0];
            n436ProfesionalesPerAltShop = P004E7_n436ProfesionalesPerAltShop[0];
            A270ProfesionalesFeedback = P004E7_A270ProfesionalesFeedback[0];
            A267ProfesionalesVerDatPerSol = P004E7_A267ProfesionalesVerDatPerSol[0];
            A109EstadosGenericosNombre = P004E7_A109EstadosGenericosNombre[0];
            A192ProfesionalesApellidoSegundo = P004E7_A192ProfesionalesApellidoSegundo[0];
            A167ProfesionalesApellidoPrimero = P004E7_A167ProfesionalesApellidoPrimero[0];
            A191ProfesionalesSegundoNombre = P004E7_A191ProfesionalesSegundoNombre[0];
            A166ProfesionalesPrimerNombre = P004E7_A166ProfesionalesPrimerNombre[0];
            A120ProfesionalesId = P004E7_A120ProfesionalesId[0];
            A269ProfesionalesFeedBackProm = P004E7_A269ProfesionalesFeedBackProm[0];
            A268ProfesionalesFeedBackCant = P004E7_A268ProfesionalesFeedBackCant[0];
            A107EstadosTipo = P004E7_A107EstadosTipo[0];
            A108EstadosGenericosId = P004E7_A108EstadosGenericosId[0];
            A170ProfesionalesTelefono = P004E7_A170ProfesionalesTelefono[0];
            A436ProfesionalesPerAltShop = P004E7_A436ProfesionalesPerAltShop[0];
            n436ProfesionalesPerAltShop = P004E7_n436ProfesionalesPerAltShop[0];
            A270ProfesionalesFeedback = P004E7_A270ProfesionalesFeedback[0];
            A267ProfesionalesVerDatPerSol = P004E7_A267ProfesionalesVerDatPerSol[0];
            A192ProfesionalesApellidoSegundo = P004E7_A192ProfesionalesApellidoSegundo[0];
            A167ProfesionalesApellidoPrimero = P004E7_A167ProfesionalesApellidoPrimero[0];
            A191ProfesionalesSegundoNombre = P004E7_A191ProfesionalesSegundoNombre[0];
            A166ProfesionalesPrimerNombre = P004E7_A166ProfesionalesPrimerNombre[0];
            A269ProfesionalesFeedBackProm = P004E7_A269ProfesionalesFeedBackProm[0];
            A268ProfesionalesFeedBackCant = P004E7_A268ProfesionalesFeedBackCant[0];
            A109EstadosGenericosNombre = P004E7_A109EstadosGenericosNombre[0];
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV55FilterFullText)) || ( ( StringUtil.Like( StringUtil.Upper( A120ProfesionalesId) , StringUtil.PadR( "%" + StringUtil.Upper( AV55FilterFullText) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A166ProfesionalesPrimerNombre) , StringUtil.PadR( "%" + StringUtil.Upper( AV55FilterFullText) , 255 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Upper( A191ProfesionalesSegundoNombre) , StringUtil.PadR( "%" + StringUtil.Upper( AV55FilterFullText) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A167ProfesionalesApellidoPrimero) , StringUtil.PadR( "%" + StringUtil.Upper( AV55FilterFullText) , 255 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Upper( A192ProfesionalesApellidoSegundo) , StringUtil.PadR( "%" + StringUtil.Upper( AV55FilterFullText) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A170ProfesionalesTelefono) , StringUtil.PadR( "%" + StringUtil.Upper( AV55FilterFullText) , 255 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Upper( A109EstadosGenericosNombre) , StringUtil.PadR( "%" + StringUtil.Upper( AV55FilterFullText) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( context.GetMessage( "si", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV55FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A267ProfesionalesVerDatPerSol, "S") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "no", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV55FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A267ProfesionalesVerDatPerSol, "N") == 0 ) ) || ( StringUtil.Like( StringUtil.Str( (decimal)(A268ProfesionalesFeedBackCant), 18, 0) , StringUtil.PadR( "%" + AV55FilterFullText , 254 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Str( A270ProfesionalesFeedback, 10, 2) , StringUtil.PadR( "%" + AV55FilterFullText , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( context.GetMessage( "no permitir", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV55FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A436ProfesionalesPerAltShop, "N") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "permitir", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV55FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A436ProfesionalesPerAltShop, "S") == 0 ) ) )
            )
            {
               AV43count = 0;
               while ( (pr_default.getStatus(5) != 101) && ( P004E7_A121RubrosId[0] == A121RubrosId ) && ( StringUtil.StrCmp(P004E7_A170ProfesionalesTelefono[0], A170ProfesionalesTelefono) == 0 ) )
               {
                  BRK4E11 = false;
                  A120ProfesionalesId = P004E7_A120ProfesionalesId[0];
                  AV43count = (long)(AV43count+1);
                  BRK4E11 = true;
                  pr_default.readNext(5);
               }
               if ( (0==AV34SkipItems) )
               {
                  AV38Option = (String.IsNullOrEmpty(StringUtil.RTrim( A170ProfesionalesTelefono)) ? "<#Empty#>" : A170ProfesionalesTelefono);
                  AV39Options.Add(AV38Option, 0);
                  AV42OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV43count), "Z,ZZZ,ZZZ,ZZ9")), 0);
                  if ( AV39Options.Count == 10 )
                  {
                     /* Exit For each command. Update data (if necessary), close cursors & exit. */
                     if (true) break;
                  }
               }
               else
               {
                  AV34SkipItems = (short)(AV34SkipItems-1);
               }
            }
            if ( ! BRK4E11 )
            {
               BRK4E11 = true;
               pr_default.readNext(5);
            }
         }
         pr_default.close(5);
      }

      protected void S181( )
      {
         /* 'LOADESTADOSGENERICOSNOMBREOPTIONS' Routine */
         returnInSub = false;
         AV23TFEstadosGenericosNombre = AV33SearchTxt;
         AV24TFEstadosGenericosNombre_Sel = "";
         pr_default.dynParam(6, new Object[]{ new Object[]{
                                              A267ProfesionalesVerDatPerSol ,
                                              AV26TFProfesionalesVerDatPerSol_Sels ,
                                              A436ProfesionalesPerAltShop ,
                                              AV32TFProfesionalesPerAltShop_Sels ,
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
                                              AV26TFProfesionalesVerDatPerSol_Sels.Count ,
                                              AV27TFProfesionalesFeedBackCant ,
                                              AV28TFProfesionalesFeedBackCant_To ,
                                              AV29TFProfesionalesFeedback ,
                                              AV30TFProfesionalesFeedback_To ,
                                              AV32TFProfesionalesPerAltShop_Sels.Count ,
                                              A120ProfesionalesId ,
                                              A166ProfesionalesPrimerNombre ,
                                              A191ProfesionalesSegundoNombre ,
                                              A167ProfesionalesApellidoPrimero ,
                                              A192ProfesionalesApellidoSegundo ,
                                              A170ProfesionalesTelefono ,
                                              A109EstadosGenericosNombre ,
                                              A268ProfesionalesFeedBackCant ,
                                              A269ProfesionalesFeedBackProm ,
                                              AV55FilterFullText ,
                                              A270ProfesionalesFeedback ,
                                              AV56RubrosId ,
                                              A121RubrosId } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.INT, TypeConstants.LONG, TypeConstants.DECIMAL, TypeConstants.DECIMAL,
                                              TypeConstants.SHORT, TypeConstants.SHORT
                                              }
         });
         lV11TFProfesionalesId = StringUtil.PadR( StringUtil.RTrim( AV11TFProfesionalesId), 20, "%");
         lV13TFProfesionalesPrimerNombre = StringUtil.PadR( StringUtil.RTrim( AV13TFProfesionalesPrimerNombre), 30, "%");
         lV15TFProfesionalesSegundoNombre = StringUtil.PadR( StringUtil.RTrim( AV15TFProfesionalesSegundoNombre), 30, "%");
         lV17TFProfesionalesApellidoPrimero = StringUtil.PadR( StringUtil.RTrim( AV17TFProfesionalesApellidoPrimero), 30, "%");
         lV19TFProfesionalesApellidoSegundo = StringUtil.PadR( StringUtil.RTrim( AV19TFProfesionalesApellidoSegundo), 30, "%");
         lV21TFProfesionalesTelefono = StringUtil.PadR( StringUtil.RTrim( AV21TFProfesionalesTelefono), 20, "%");
         lV23TFEstadosGenericosNombre = StringUtil.PadR( StringUtil.RTrim( AV23TFEstadosGenericosNombre), 80, "%");
         /* Using cursor P004E8 */
         pr_default.execute(6, new Object[] {AV56RubrosId, lV11TFProfesionalesId, AV12TFProfesionalesId_Sel, lV13TFProfesionalesPrimerNombre, AV14TFProfesionalesPrimerNombre_Sel, lV15TFProfesionalesSegundoNombre, AV16TFProfesionalesSegundoNombre_Sel, lV17TFProfesionalesApellidoPrimero, AV18TFProfesionalesApellidoPrimero_Sel, lV19TFProfesionalesApellidoSegundo, AV20TFProfesionalesApellidoSegundo_Sel, lV21TFProfesionalesTelefono, AV22TFProfesionalesTelefono_Sel, lV23TFEstadosGenericosNombre, AV24TFEstadosGenericosNombre_Sel, AV27TFProfesionalesFeedBackCant, AV28TFProfesionalesFeedBackCant_To, AV29TFProfesionalesFeedback, AV30TFProfesionalesFeedback_To});
         while ( (pr_default.getStatus(6) != 101) )
         {
            BRK4E13 = false;
            A107EstadosTipo = P004E8_A107EstadosTipo[0];
            A108EstadosGenericosId = P004E8_A108EstadosGenericosId[0];
            A121RubrosId = P004E8_A121RubrosId[0];
            A109EstadosGenericosNombre = P004E8_A109EstadosGenericosNombre[0];
            A436ProfesionalesPerAltShop = P004E8_A436ProfesionalesPerAltShop[0];
            n436ProfesionalesPerAltShop = P004E8_n436ProfesionalesPerAltShop[0];
            A270ProfesionalesFeedback = P004E8_A270ProfesionalesFeedback[0];
            A267ProfesionalesVerDatPerSol = P004E8_A267ProfesionalesVerDatPerSol[0];
            A170ProfesionalesTelefono = P004E8_A170ProfesionalesTelefono[0];
            A192ProfesionalesApellidoSegundo = P004E8_A192ProfesionalesApellidoSegundo[0];
            A167ProfesionalesApellidoPrimero = P004E8_A167ProfesionalesApellidoPrimero[0];
            A191ProfesionalesSegundoNombre = P004E8_A191ProfesionalesSegundoNombre[0];
            A166ProfesionalesPrimerNombre = P004E8_A166ProfesionalesPrimerNombre[0];
            A120ProfesionalesId = P004E8_A120ProfesionalesId[0];
            A269ProfesionalesFeedBackProm = P004E8_A269ProfesionalesFeedBackProm[0];
            A268ProfesionalesFeedBackCant = P004E8_A268ProfesionalesFeedBackCant[0];
            A107EstadosTipo = P004E8_A107EstadosTipo[0];
            A108EstadosGenericosId = P004E8_A108EstadosGenericosId[0];
            A436ProfesionalesPerAltShop = P004E8_A436ProfesionalesPerAltShop[0];
            n436ProfesionalesPerAltShop = P004E8_n436ProfesionalesPerAltShop[0];
            A270ProfesionalesFeedback = P004E8_A270ProfesionalesFeedback[0];
            A267ProfesionalesVerDatPerSol = P004E8_A267ProfesionalesVerDatPerSol[0];
            A170ProfesionalesTelefono = P004E8_A170ProfesionalesTelefono[0];
            A192ProfesionalesApellidoSegundo = P004E8_A192ProfesionalesApellidoSegundo[0];
            A167ProfesionalesApellidoPrimero = P004E8_A167ProfesionalesApellidoPrimero[0];
            A191ProfesionalesSegundoNombre = P004E8_A191ProfesionalesSegundoNombre[0];
            A166ProfesionalesPrimerNombre = P004E8_A166ProfesionalesPrimerNombre[0];
            A269ProfesionalesFeedBackProm = P004E8_A269ProfesionalesFeedBackProm[0];
            A268ProfesionalesFeedBackCant = P004E8_A268ProfesionalesFeedBackCant[0];
            A109EstadosGenericosNombre = P004E8_A109EstadosGenericosNombre[0];
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV55FilterFullText)) || ( ( StringUtil.Like( StringUtil.Upper( A120ProfesionalesId) , StringUtil.PadR( "%" + StringUtil.Upper( AV55FilterFullText) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A166ProfesionalesPrimerNombre) , StringUtil.PadR( "%" + StringUtil.Upper( AV55FilterFullText) , 255 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Upper( A191ProfesionalesSegundoNombre) , StringUtil.PadR( "%" + StringUtil.Upper( AV55FilterFullText) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A167ProfesionalesApellidoPrimero) , StringUtil.PadR( "%" + StringUtil.Upper( AV55FilterFullText) , 255 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Upper( A192ProfesionalesApellidoSegundo) , StringUtil.PadR( "%" + StringUtil.Upper( AV55FilterFullText) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A170ProfesionalesTelefono) , StringUtil.PadR( "%" + StringUtil.Upper( AV55FilterFullText) , 255 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Upper( A109EstadosGenericosNombre) , StringUtil.PadR( "%" + StringUtil.Upper( AV55FilterFullText) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( context.GetMessage( "si", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV55FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A267ProfesionalesVerDatPerSol, "S") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "no", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV55FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A267ProfesionalesVerDatPerSol, "N") == 0 ) ) || ( StringUtil.Like( StringUtil.Str( (decimal)(A268ProfesionalesFeedBackCant), 18, 0) , StringUtil.PadR( "%" + AV55FilterFullText , 254 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Str( A270ProfesionalesFeedback, 10, 2) , StringUtil.PadR( "%" + AV55FilterFullText , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( context.GetMessage( "no permitir", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV55FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A436ProfesionalesPerAltShop, "N") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "permitir", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV55FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A436ProfesionalesPerAltShop, "S") == 0 ) ) )
            )
            {
               AV43count = 0;
               while ( (pr_default.getStatus(6) != 101) && ( P004E8_A121RubrosId[0] == A121RubrosId ) && ( StringUtil.StrCmp(P004E8_A109EstadosGenericosNombre[0], A109EstadosGenericosNombre) == 0 ) )
               {
                  BRK4E13 = false;
                  A107EstadosTipo = P004E8_A107EstadosTipo[0];
                  A108EstadosGenericosId = P004E8_A108EstadosGenericosId[0];
                  A120ProfesionalesId = P004E8_A120ProfesionalesId[0];
                  A107EstadosTipo = P004E8_A107EstadosTipo[0];
                  A108EstadosGenericosId = P004E8_A108EstadosGenericosId[0];
                  AV43count = (long)(AV43count+1);
                  BRK4E13 = true;
                  pr_default.readNext(6);
               }
               if ( (0==AV34SkipItems) )
               {
                  AV38Option = (String.IsNullOrEmpty(StringUtil.RTrim( A109EstadosGenericosNombre)) ? "<#Empty#>" : A109EstadosGenericosNombre);
                  AV39Options.Add(AV38Option, 0);
                  AV42OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV43count), "Z,ZZZ,ZZZ,ZZ9")), 0);
                  if ( AV39Options.Count == 10 )
                  {
                     /* Exit For each command. Update data (if necessary), close cursors & exit. */
                     if (true) break;
                  }
               }
               else
               {
                  AV34SkipItems = (short)(AV34SkipItems-1);
               }
            }
            if ( ! BRK4E13 )
            {
               BRK4E13 = true;
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
         AV52OptionsJson = "";
         AV53OptionsDescJson = "";
         AV54OptionIndexesJson = "";
         AV39Options = new GxSimpleCollection<string>();
         AV41OptionsDesc = new GxSimpleCollection<string>();
         AV42OptionIndexes = new GxSimpleCollection<string>();
         AV33SearchTxt = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV44Session = context.GetSession();
         AV46GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV47GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV55FilterFullText = "";
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
         AV25TFProfesionalesVerDatPerSol_SelsJson = "";
         AV26TFProfesionalesVerDatPerSol_Sels = new GxSimpleCollection<string>();
         AV31TFProfesionalesPerAltShop_SelsJson = "";
         AV32TFProfesionalesPerAltShop_Sels = new GxSimpleCollection<string>();
         lV11TFProfesionalesId = "";
         lV13TFProfesionalesPrimerNombre = "";
         lV15TFProfesionalesSegundoNombre = "";
         lV17TFProfesionalesApellidoPrimero = "";
         lV19TFProfesionalesApellidoSegundo = "";
         lV21TFProfesionalesTelefono = "";
         lV23TFEstadosGenericosNombre = "";
         A267ProfesionalesVerDatPerSol = "";
         A436ProfesionalesPerAltShop = "";
         A120ProfesionalesId = "";
         A166ProfesionalesPrimerNombre = "";
         A191ProfesionalesSegundoNombre = "";
         A167ProfesionalesApellidoPrimero = "";
         A192ProfesionalesApellidoSegundo = "";
         A170ProfesionalesTelefono = "";
         A109EstadosGenericosNombre = "";
         P004E2_A107EstadosTipo = new string[] {""} ;
         P004E2_A108EstadosGenericosId = new int[1] ;
         P004E2_A121RubrosId = new short[1] ;
         P004E2_A436ProfesionalesPerAltShop = new string[] {""} ;
         P004E2_n436ProfesionalesPerAltShop = new bool[] {false} ;
         P004E2_A270ProfesionalesFeedback = new decimal[1] ;
         P004E2_A267ProfesionalesVerDatPerSol = new string[] {""} ;
         P004E2_A109EstadosGenericosNombre = new string[] {""} ;
         P004E2_A170ProfesionalesTelefono = new string[] {""} ;
         P004E2_A192ProfesionalesApellidoSegundo = new string[] {""} ;
         P004E2_A167ProfesionalesApellidoPrimero = new string[] {""} ;
         P004E2_A191ProfesionalesSegundoNombre = new string[] {""} ;
         P004E2_A166ProfesionalesPrimerNombre = new string[] {""} ;
         P004E2_A120ProfesionalesId = new string[] {""} ;
         P004E2_A269ProfesionalesFeedBackProm = new decimal[1] ;
         P004E2_A268ProfesionalesFeedBackCant = new long[1] ;
         A107EstadosTipo = "";
         AV38Option = "";
         P004E3_A107EstadosTipo = new string[] {""} ;
         P004E3_A108EstadosGenericosId = new int[1] ;
         P004E3_A121RubrosId = new short[1] ;
         P004E3_A166ProfesionalesPrimerNombre = new string[] {""} ;
         P004E3_A436ProfesionalesPerAltShop = new string[] {""} ;
         P004E3_n436ProfesionalesPerAltShop = new bool[] {false} ;
         P004E3_A270ProfesionalesFeedback = new decimal[1] ;
         P004E3_A267ProfesionalesVerDatPerSol = new string[] {""} ;
         P004E3_A109EstadosGenericosNombre = new string[] {""} ;
         P004E3_A170ProfesionalesTelefono = new string[] {""} ;
         P004E3_A192ProfesionalesApellidoSegundo = new string[] {""} ;
         P004E3_A167ProfesionalesApellidoPrimero = new string[] {""} ;
         P004E3_A191ProfesionalesSegundoNombre = new string[] {""} ;
         P004E3_A120ProfesionalesId = new string[] {""} ;
         P004E3_A269ProfesionalesFeedBackProm = new decimal[1] ;
         P004E3_A268ProfesionalesFeedBackCant = new long[1] ;
         P004E4_A107EstadosTipo = new string[] {""} ;
         P004E4_A108EstadosGenericosId = new int[1] ;
         P004E4_A121RubrosId = new short[1] ;
         P004E4_A191ProfesionalesSegundoNombre = new string[] {""} ;
         P004E4_A436ProfesionalesPerAltShop = new string[] {""} ;
         P004E4_n436ProfesionalesPerAltShop = new bool[] {false} ;
         P004E4_A270ProfesionalesFeedback = new decimal[1] ;
         P004E4_A267ProfesionalesVerDatPerSol = new string[] {""} ;
         P004E4_A109EstadosGenericosNombre = new string[] {""} ;
         P004E4_A170ProfesionalesTelefono = new string[] {""} ;
         P004E4_A192ProfesionalesApellidoSegundo = new string[] {""} ;
         P004E4_A167ProfesionalesApellidoPrimero = new string[] {""} ;
         P004E4_A166ProfesionalesPrimerNombre = new string[] {""} ;
         P004E4_A120ProfesionalesId = new string[] {""} ;
         P004E4_A269ProfesionalesFeedBackProm = new decimal[1] ;
         P004E4_A268ProfesionalesFeedBackCant = new long[1] ;
         P004E5_A107EstadosTipo = new string[] {""} ;
         P004E5_A108EstadosGenericosId = new int[1] ;
         P004E5_A121RubrosId = new short[1] ;
         P004E5_A167ProfesionalesApellidoPrimero = new string[] {""} ;
         P004E5_A436ProfesionalesPerAltShop = new string[] {""} ;
         P004E5_n436ProfesionalesPerAltShop = new bool[] {false} ;
         P004E5_A270ProfesionalesFeedback = new decimal[1] ;
         P004E5_A267ProfesionalesVerDatPerSol = new string[] {""} ;
         P004E5_A109EstadosGenericosNombre = new string[] {""} ;
         P004E5_A170ProfesionalesTelefono = new string[] {""} ;
         P004E5_A192ProfesionalesApellidoSegundo = new string[] {""} ;
         P004E5_A191ProfesionalesSegundoNombre = new string[] {""} ;
         P004E5_A166ProfesionalesPrimerNombre = new string[] {""} ;
         P004E5_A120ProfesionalesId = new string[] {""} ;
         P004E5_A269ProfesionalesFeedBackProm = new decimal[1] ;
         P004E5_A268ProfesionalesFeedBackCant = new long[1] ;
         P004E6_A107EstadosTipo = new string[] {""} ;
         P004E6_A108EstadosGenericosId = new int[1] ;
         P004E6_A121RubrosId = new short[1] ;
         P004E6_A192ProfesionalesApellidoSegundo = new string[] {""} ;
         P004E6_A436ProfesionalesPerAltShop = new string[] {""} ;
         P004E6_n436ProfesionalesPerAltShop = new bool[] {false} ;
         P004E6_A270ProfesionalesFeedback = new decimal[1] ;
         P004E6_A267ProfesionalesVerDatPerSol = new string[] {""} ;
         P004E6_A109EstadosGenericosNombre = new string[] {""} ;
         P004E6_A170ProfesionalesTelefono = new string[] {""} ;
         P004E6_A167ProfesionalesApellidoPrimero = new string[] {""} ;
         P004E6_A191ProfesionalesSegundoNombre = new string[] {""} ;
         P004E6_A166ProfesionalesPrimerNombre = new string[] {""} ;
         P004E6_A120ProfesionalesId = new string[] {""} ;
         P004E6_A269ProfesionalesFeedBackProm = new decimal[1] ;
         P004E6_A268ProfesionalesFeedBackCant = new long[1] ;
         P004E7_A107EstadosTipo = new string[] {""} ;
         P004E7_A108EstadosGenericosId = new int[1] ;
         P004E7_A121RubrosId = new short[1] ;
         P004E7_A170ProfesionalesTelefono = new string[] {""} ;
         P004E7_A436ProfesionalesPerAltShop = new string[] {""} ;
         P004E7_n436ProfesionalesPerAltShop = new bool[] {false} ;
         P004E7_A270ProfesionalesFeedback = new decimal[1] ;
         P004E7_A267ProfesionalesVerDatPerSol = new string[] {""} ;
         P004E7_A109EstadosGenericosNombre = new string[] {""} ;
         P004E7_A192ProfesionalesApellidoSegundo = new string[] {""} ;
         P004E7_A167ProfesionalesApellidoPrimero = new string[] {""} ;
         P004E7_A191ProfesionalesSegundoNombre = new string[] {""} ;
         P004E7_A166ProfesionalesPrimerNombre = new string[] {""} ;
         P004E7_A120ProfesionalesId = new string[] {""} ;
         P004E7_A269ProfesionalesFeedBackProm = new decimal[1] ;
         P004E7_A268ProfesionalesFeedBackCant = new long[1] ;
         P004E8_A107EstadosTipo = new string[] {""} ;
         P004E8_A108EstadosGenericosId = new int[1] ;
         P004E8_A121RubrosId = new short[1] ;
         P004E8_A109EstadosGenericosNombre = new string[] {""} ;
         P004E8_A436ProfesionalesPerAltShop = new string[] {""} ;
         P004E8_n436ProfesionalesPerAltShop = new bool[] {false} ;
         P004E8_A270ProfesionalesFeedback = new decimal[1] ;
         P004E8_A267ProfesionalesVerDatPerSol = new string[] {""} ;
         P004E8_A170ProfesionalesTelefono = new string[] {""} ;
         P004E8_A192ProfesionalesApellidoSegundo = new string[] {""} ;
         P004E8_A167ProfesionalesApellidoPrimero = new string[] {""} ;
         P004E8_A191ProfesionalesSegundoNombre = new string[] {""} ;
         P004E8_A166ProfesionalesPrimerNombre = new string[] {""} ;
         P004E8_A120ProfesionalesId = new string[] {""} ;
         P004E8_A269ProfesionalesFeedBackProm = new decimal[1] ;
         P004E8_A268ProfesionalesFeedBackCant = new long[1] ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.rubrosmedidasrubroswcgetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P004E2_A107EstadosTipo, P004E2_A108EstadosGenericosId, P004E2_A121RubrosId, P004E2_A436ProfesionalesPerAltShop, P004E2_n436ProfesionalesPerAltShop, P004E2_A270ProfesionalesFeedback, P004E2_A267ProfesionalesVerDatPerSol, P004E2_A109EstadosGenericosNombre, P004E2_A170ProfesionalesTelefono, P004E2_A192ProfesionalesApellidoSegundo,
               P004E2_A167ProfesionalesApellidoPrimero, P004E2_A191ProfesionalesSegundoNombre, P004E2_A166ProfesionalesPrimerNombre, P004E2_A120ProfesionalesId, P004E2_A269ProfesionalesFeedBackProm, P004E2_A268ProfesionalesFeedBackCant
               }
               , new Object[] {
               P004E3_A107EstadosTipo, P004E3_A108EstadosGenericosId, P004E3_A121RubrosId, P004E3_A166ProfesionalesPrimerNombre, P004E3_A436ProfesionalesPerAltShop, P004E3_n436ProfesionalesPerAltShop, P004E3_A270ProfesionalesFeedback, P004E3_A267ProfesionalesVerDatPerSol, P004E3_A109EstadosGenericosNombre, P004E3_A170ProfesionalesTelefono,
               P004E3_A192ProfesionalesApellidoSegundo, P004E3_A167ProfesionalesApellidoPrimero, P004E3_A191ProfesionalesSegundoNombre, P004E3_A120ProfesionalesId, P004E3_A269ProfesionalesFeedBackProm, P004E3_A268ProfesionalesFeedBackCant
               }
               , new Object[] {
               P004E4_A107EstadosTipo, P004E4_A108EstadosGenericosId, P004E4_A121RubrosId, P004E4_A191ProfesionalesSegundoNombre, P004E4_A436ProfesionalesPerAltShop, P004E4_n436ProfesionalesPerAltShop, P004E4_A270ProfesionalesFeedback, P004E4_A267ProfesionalesVerDatPerSol, P004E4_A109EstadosGenericosNombre, P004E4_A170ProfesionalesTelefono,
               P004E4_A192ProfesionalesApellidoSegundo, P004E4_A167ProfesionalesApellidoPrimero, P004E4_A166ProfesionalesPrimerNombre, P004E4_A120ProfesionalesId, P004E4_A269ProfesionalesFeedBackProm, P004E4_A268ProfesionalesFeedBackCant
               }
               , new Object[] {
               P004E5_A107EstadosTipo, P004E5_A108EstadosGenericosId, P004E5_A121RubrosId, P004E5_A167ProfesionalesApellidoPrimero, P004E5_A436ProfesionalesPerAltShop, P004E5_n436ProfesionalesPerAltShop, P004E5_A270ProfesionalesFeedback, P004E5_A267ProfesionalesVerDatPerSol, P004E5_A109EstadosGenericosNombre, P004E5_A170ProfesionalesTelefono,
               P004E5_A192ProfesionalesApellidoSegundo, P004E5_A191ProfesionalesSegundoNombre, P004E5_A166ProfesionalesPrimerNombre, P004E5_A120ProfesionalesId, P004E5_A269ProfesionalesFeedBackProm, P004E5_A268ProfesionalesFeedBackCant
               }
               , new Object[] {
               P004E6_A107EstadosTipo, P004E6_A108EstadosGenericosId, P004E6_A121RubrosId, P004E6_A192ProfesionalesApellidoSegundo, P004E6_A436ProfesionalesPerAltShop, P004E6_n436ProfesionalesPerAltShop, P004E6_A270ProfesionalesFeedback, P004E6_A267ProfesionalesVerDatPerSol, P004E6_A109EstadosGenericosNombre, P004E6_A170ProfesionalesTelefono,
               P004E6_A167ProfesionalesApellidoPrimero, P004E6_A191ProfesionalesSegundoNombre, P004E6_A166ProfesionalesPrimerNombre, P004E6_A120ProfesionalesId, P004E6_A269ProfesionalesFeedBackProm, P004E6_A268ProfesionalesFeedBackCant
               }
               , new Object[] {
               P004E7_A107EstadosTipo, P004E7_A108EstadosGenericosId, P004E7_A121RubrosId, P004E7_A170ProfesionalesTelefono, P004E7_A436ProfesionalesPerAltShop, P004E7_n436ProfesionalesPerAltShop, P004E7_A270ProfesionalesFeedback, P004E7_A267ProfesionalesVerDatPerSol, P004E7_A109EstadosGenericosNombre, P004E7_A192ProfesionalesApellidoSegundo,
               P004E7_A167ProfesionalesApellidoPrimero, P004E7_A191ProfesionalesSegundoNombre, P004E7_A166ProfesionalesPrimerNombre, P004E7_A120ProfesionalesId, P004E7_A269ProfesionalesFeedBackProm, P004E7_A268ProfesionalesFeedBackCant
               }
               , new Object[] {
               P004E8_A107EstadosTipo, P004E8_A108EstadosGenericosId, P004E8_A121RubrosId, P004E8_A109EstadosGenericosNombre, P004E8_A436ProfesionalesPerAltShop, P004E8_n436ProfesionalesPerAltShop, P004E8_A270ProfesionalesFeedback, P004E8_A267ProfesionalesVerDatPerSol, P004E8_A170ProfesionalesTelefono, P004E8_A192ProfesionalesApellidoSegundo,
               P004E8_A167ProfesionalesApellidoPrimero, P004E8_A191ProfesionalesSegundoNombre, P004E8_A166ProfesionalesPrimerNombre, P004E8_A120ProfesionalesId, P004E8_A269ProfesionalesFeedBackProm, P004E8_A268ProfesionalesFeedBackCant
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV36MaxItems ;
      private short AV35PageIndex ;
      private short AV34SkipItems ;
      private short AV56RubrosId ;
      private short A121RubrosId ;
      private int AV57GXV1 ;
      private int GXPagingFrom2 ;
      private int GXPagingTo2 ;
      private int GXPagingIdx2 ;
      private int AV26TFProfesionalesVerDatPerSol_Sels_Count ;
      private int AV32TFProfesionalesPerAltShop_Sels_Count ;
      private int A108EstadosGenericosId ;
      private long AV27TFProfesionalesFeedBackCant ;
      private long AV28TFProfesionalesFeedBackCant_To ;
      private long A268ProfesionalesFeedBackCant ;
      private long AV43count ;
      private decimal AV29TFProfesionalesFeedback ;
      private decimal AV30TFProfesionalesFeedback_To ;
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
      private string AV23TFEstadosGenericosNombre ;
      private string AV24TFEstadosGenericosNombre_Sel ;
      private string lV11TFProfesionalesId ;
      private string lV13TFProfesionalesPrimerNombre ;
      private string lV15TFProfesionalesSegundoNombre ;
      private string lV17TFProfesionalesApellidoPrimero ;
      private string lV19TFProfesionalesApellidoSegundo ;
      private string lV21TFProfesionalesTelefono ;
      private string lV23TFEstadosGenericosNombre ;
      private string A267ProfesionalesVerDatPerSol ;
      private string A436ProfesionalesPerAltShop ;
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
      private bool n436ProfesionalesPerAltShop ;
      private bool BRK4E3 ;
      private bool BRK4E5 ;
      private bool BRK4E7 ;
      private bool BRK4E9 ;
      private bool BRK4E11 ;
      private bool BRK4E13 ;
      private string AV52OptionsJson ;
      private string AV53OptionsDescJson ;
      private string AV54OptionIndexesJson ;
      private string AV25TFProfesionalesVerDatPerSol_SelsJson ;
      private string AV31TFProfesionalesPerAltShop_SelsJson ;
      private string AV49DDOName ;
      private string AV50SearchTxtParms ;
      private string AV51SearchTxtTo ;
      private string AV33SearchTxt ;
      private string AV55FilterFullText ;
      private string AV38Option ;
      private IGxSession AV44Session ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GxSimpleCollection<string> AV39Options ;
      private GxSimpleCollection<string> AV41OptionsDesc ;
      private GxSimpleCollection<string> AV42OptionIndexes ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV46GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV47GridStateFilterValue ;
      private GxSimpleCollection<string> AV26TFProfesionalesVerDatPerSol_Sels ;
      private GxSimpleCollection<string> AV32TFProfesionalesPerAltShop_Sels ;
      private IDataStoreProvider pr_default ;
      private string[] P004E2_A107EstadosTipo ;
      private int[] P004E2_A108EstadosGenericosId ;
      private short[] P004E2_A121RubrosId ;
      private string[] P004E2_A436ProfesionalesPerAltShop ;
      private bool[] P004E2_n436ProfesionalesPerAltShop ;
      private decimal[] P004E2_A270ProfesionalesFeedback ;
      private string[] P004E2_A267ProfesionalesVerDatPerSol ;
      private string[] P004E2_A109EstadosGenericosNombre ;
      private string[] P004E2_A170ProfesionalesTelefono ;
      private string[] P004E2_A192ProfesionalesApellidoSegundo ;
      private string[] P004E2_A167ProfesionalesApellidoPrimero ;
      private string[] P004E2_A191ProfesionalesSegundoNombre ;
      private string[] P004E2_A166ProfesionalesPrimerNombre ;
      private string[] P004E2_A120ProfesionalesId ;
      private decimal[] P004E2_A269ProfesionalesFeedBackProm ;
      private long[] P004E2_A268ProfesionalesFeedBackCant ;
      private string[] P004E3_A107EstadosTipo ;
      private int[] P004E3_A108EstadosGenericosId ;
      private short[] P004E3_A121RubrosId ;
      private string[] P004E3_A166ProfesionalesPrimerNombre ;
      private string[] P004E3_A436ProfesionalesPerAltShop ;
      private bool[] P004E3_n436ProfesionalesPerAltShop ;
      private decimal[] P004E3_A270ProfesionalesFeedback ;
      private string[] P004E3_A267ProfesionalesVerDatPerSol ;
      private string[] P004E3_A109EstadosGenericosNombre ;
      private string[] P004E3_A170ProfesionalesTelefono ;
      private string[] P004E3_A192ProfesionalesApellidoSegundo ;
      private string[] P004E3_A167ProfesionalesApellidoPrimero ;
      private string[] P004E3_A191ProfesionalesSegundoNombre ;
      private string[] P004E3_A120ProfesionalesId ;
      private decimal[] P004E3_A269ProfesionalesFeedBackProm ;
      private long[] P004E3_A268ProfesionalesFeedBackCant ;
      private string[] P004E4_A107EstadosTipo ;
      private int[] P004E4_A108EstadosGenericosId ;
      private short[] P004E4_A121RubrosId ;
      private string[] P004E4_A191ProfesionalesSegundoNombre ;
      private string[] P004E4_A436ProfesionalesPerAltShop ;
      private bool[] P004E4_n436ProfesionalesPerAltShop ;
      private decimal[] P004E4_A270ProfesionalesFeedback ;
      private string[] P004E4_A267ProfesionalesVerDatPerSol ;
      private string[] P004E4_A109EstadosGenericosNombre ;
      private string[] P004E4_A170ProfesionalesTelefono ;
      private string[] P004E4_A192ProfesionalesApellidoSegundo ;
      private string[] P004E4_A167ProfesionalesApellidoPrimero ;
      private string[] P004E4_A166ProfesionalesPrimerNombre ;
      private string[] P004E4_A120ProfesionalesId ;
      private decimal[] P004E4_A269ProfesionalesFeedBackProm ;
      private long[] P004E4_A268ProfesionalesFeedBackCant ;
      private string[] P004E5_A107EstadosTipo ;
      private int[] P004E5_A108EstadosGenericosId ;
      private short[] P004E5_A121RubrosId ;
      private string[] P004E5_A167ProfesionalesApellidoPrimero ;
      private string[] P004E5_A436ProfesionalesPerAltShop ;
      private bool[] P004E5_n436ProfesionalesPerAltShop ;
      private decimal[] P004E5_A270ProfesionalesFeedback ;
      private string[] P004E5_A267ProfesionalesVerDatPerSol ;
      private string[] P004E5_A109EstadosGenericosNombre ;
      private string[] P004E5_A170ProfesionalesTelefono ;
      private string[] P004E5_A192ProfesionalesApellidoSegundo ;
      private string[] P004E5_A191ProfesionalesSegundoNombre ;
      private string[] P004E5_A166ProfesionalesPrimerNombre ;
      private string[] P004E5_A120ProfesionalesId ;
      private decimal[] P004E5_A269ProfesionalesFeedBackProm ;
      private long[] P004E5_A268ProfesionalesFeedBackCant ;
      private string[] P004E6_A107EstadosTipo ;
      private int[] P004E6_A108EstadosGenericosId ;
      private short[] P004E6_A121RubrosId ;
      private string[] P004E6_A192ProfesionalesApellidoSegundo ;
      private string[] P004E6_A436ProfesionalesPerAltShop ;
      private bool[] P004E6_n436ProfesionalesPerAltShop ;
      private decimal[] P004E6_A270ProfesionalesFeedback ;
      private string[] P004E6_A267ProfesionalesVerDatPerSol ;
      private string[] P004E6_A109EstadosGenericosNombre ;
      private string[] P004E6_A170ProfesionalesTelefono ;
      private string[] P004E6_A167ProfesionalesApellidoPrimero ;
      private string[] P004E6_A191ProfesionalesSegundoNombre ;
      private string[] P004E6_A166ProfesionalesPrimerNombre ;
      private string[] P004E6_A120ProfesionalesId ;
      private decimal[] P004E6_A269ProfesionalesFeedBackProm ;
      private long[] P004E6_A268ProfesionalesFeedBackCant ;
      private string[] P004E7_A107EstadosTipo ;
      private int[] P004E7_A108EstadosGenericosId ;
      private short[] P004E7_A121RubrosId ;
      private string[] P004E7_A170ProfesionalesTelefono ;
      private string[] P004E7_A436ProfesionalesPerAltShop ;
      private bool[] P004E7_n436ProfesionalesPerAltShop ;
      private decimal[] P004E7_A270ProfesionalesFeedback ;
      private string[] P004E7_A267ProfesionalesVerDatPerSol ;
      private string[] P004E7_A109EstadosGenericosNombre ;
      private string[] P004E7_A192ProfesionalesApellidoSegundo ;
      private string[] P004E7_A167ProfesionalesApellidoPrimero ;
      private string[] P004E7_A191ProfesionalesSegundoNombre ;
      private string[] P004E7_A166ProfesionalesPrimerNombre ;
      private string[] P004E7_A120ProfesionalesId ;
      private decimal[] P004E7_A269ProfesionalesFeedBackProm ;
      private long[] P004E7_A268ProfesionalesFeedBackCant ;
      private string[] P004E8_A107EstadosTipo ;
      private int[] P004E8_A108EstadosGenericosId ;
      private short[] P004E8_A121RubrosId ;
      private string[] P004E8_A109EstadosGenericosNombre ;
      private string[] P004E8_A436ProfesionalesPerAltShop ;
      private bool[] P004E8_n436ProfesionalesPerAltShop ;
      private decimal[] P004E8_A270ProfesionalesFeedback ;
      private string[] P004E8_A267ProfesionalesVerDatPerSol ;
      private string[] P004E8_A170ProfesionalesTelefono ;
      private string[] P004E8_A192ProfesionalesApellidoSegundo ;
      private string[] P004E8_A167ProfesionalesApellidoPrimero ;
      private string[] P004E8_A191ProfesionalesSegundoNombre ;
      private string[] P004E8_A166ProfesionalesPrimerNombre ;
      private string[] P004E8_A120ProfesionalesId ;
      private decimal[] P004E8_A269ProfesionalesFeedBackProm ;
      private long[] P004E8_A268ProfesionalesFeedBackCant ;
      private string aP3_OptionsJson ;
      private string aP4_OptionsDescJson ;
      private string aP5_OptionIndexesJson ;
   }

   public class rubrosmedidasrubroswcgetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P004E2( IGxContext context ,
                                             string A267ProfesionalesVerDatPerSol ,
                                             GxSimpleCollection<string> AV26TFProfesionalesVerDatPerSol_Sels ,
                                             string A436ProfesionalesPerAltShop ,
                                             GxSimpleCollection<string> AV32TFProfesionalesPerAltShop_Sels ,
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
                                             int AV26TFProfesionalesVerDatPerSol_Sels_Count ,
                                             long AV27TFProfesionalesFeedBackCant ,
                                             long AV28TFProfesionalesFeedBackCant_To ,
                                             decimal AV29TFProfesionalesFeedback ,
                                             decimal AV30TFProfesionalesFeedback_To ,
                                             int AV32TFProfesionalesPerAltShop_Sels_Count ,
                                             string A120ProfesionalesId ,
                                             string A166ProfesionalesPrimerNombre ,
                                             string A191ProfesionalesSegundoNombre ,
                                             string A167ProfesionalesApellidoPrimero ,
                                             string A192ProfesionalesApellidoSegundo ,
                                             string A170ProfesionalesTelefono ,
                                             string A109EstadosGenericosNombre ,
                                             long A268ProfesionalesFeedBackCant ,
                                             decimal A269ProfesionalesFeedBackProm ,
                                             string AV55FilterFullText ,
                                             decimal A270ProfesionalesFeedback ,
                                             short AV56RubrosId ,
                                             short A121RubrosId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int2 = new short[19];
         Object[] GXv_Object3 = new Object[2];
         scmdbuf = "SELECT DISTINCT NULL AS [EstadosTipo], NULL AS [EstadosGenericosId], NULL AS [RubrosId], NULL AS [ProfesionalesPerAltShop], NULL AS [ProfesionalesFeedback], NULL AS [ProfesionalesVerDatPerSol], NULL AS [EstadosGenericosNombre], NULL AS [ProfesionalesTelefono], NULL AS [ProfesionalesApellidoSegundo], NULL AS [ProfesionalesApellidoPrimero], NULL AS [ProfesionalesSegundoNombre], NULL AS [ProfesionalesPrimerNombre], [ProfesionalesId], NULL AS [ProfesionalesFeedBackProm], NULL AS [ProfesionalesFeedBackCant] FROM ( SELECT TOP(100) PERCENT T2.[EstadosTipo], T2.[EstadosGenericosId], T1.[RubrosId], T2.[ProfesionalesPerAltShop], CASE  WHEN T2.[ProfesionalesFeedBackCant] > 0 THEN CAST(T2.[ProfesionalesFeedBackProm] AS decimal( 28, 10)) / T2.[ProfesionalesFeedBackCant] END AS ProfesionalesFeedback, T2.[ProfesionalesVerDatPerSol], T3.[EstadosGenericosNombre], T2.[ProfesionalesTelefono], T2.[ProfesionalesApellidoSegundo], T2.[ProfesionalesApellidoPrimero], T2.[ProfesionalesSegundoNombre], T2.[ProfesionalesPrimerNombre], T1.[ProfesionalesId], T2.[ProfesionalesFeedBackProm], T2.[ProfesionalesFeedBackCant] FROM (([ProfesionalesRubros] T1 INNER JOIN [Profesionales] T2 ON T2.[ProfesionalesId] = T1.[ProfesionalesId]) INNER JOIN [EstadosGenericos] T3 ON T3.[EstadosTipo] = T2.[EstadosTipo] AND T3.[EstadosGenericosId] = T2.[EstadosGenericosId])";
         AddWhere(sWhereString, "(T1.[RubrosId] = @AV56RubrosId)");
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
         if ( AV26TFProfesionalesVerDatPerSol_Sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV26TFProfesionalesVerDatPerSol_Sels, "T2.[ProfesionalesVerDatPerSol] IN (", ")")+")");
         }
         if ( ! (0==AV27TFProfesionalesFeedBackCant) )
         {
            AddWhere(sWhereString, "(T2.[ProfesionalesFeedBackCant] >= @AV27TFProfesionalesFeedBackCant)");
         }
         else
         {
            GXv_int2[15] = 1;
         }
         if ( ! (0==AV28TFProfesionalesFeedBackCant_To) )
         {
            AddWhere(sWhereString, "(T2.[ProfesionalesFeedBackCant] <= @AV28TFProfesionalesFeedBackCant_To)");
         }
         else
         {
            GXv_int2[16] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV29TFProfesionalesFeedback) )
         {
            AddWhere(sWhereString, "(( CASE  WHEN T2.[ProfesionalesFeedBackCant] > 0 THEN CAST(T2.[ProfesionalesFeedBackProm] AS decimal( 28, 10)) / T2.[ProfesionalesFeedBackCant] END) >= @AV29TFProfesionalesFeedback)");
         }
         else
         {
            GXv_int2[17] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV30TFProfesionalesFeedback_To) )
         {
            AddWhere(sWhereString, "(( CASE  WHEN T2.[ProfesionalesFeedBackCant] > 0 THEN CAST(T2.[ProfesionalesFeedBackProm] AS decimal( 28, 10)) / T2.[ProfesionalesFeedBackCant] END) <= @AV30TFProfesionalesFeedback_To)");
         }
         else
         {
            GXv_int2[18] = 1;
         }
         if ( AV32TFProfesionalesPerAltShop_Sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV32TFProfesionalesPerAltShop_Sels, "T2.[ProfesionalesPerAltShop] IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[RubrosId], T1.[ProfesionalesId]";
         scmdbuf += ") DistinctT";
         scmdbuf += " ORDER BY [ProfesionalesId]";
         GXv_Object3[0] = scmdbuf;
         GXv_Object3[1] = GXv_int2;
         return GXv_Object3 ;
      }

      protected Object[] conditional_P004E3( IGxContext context ,
                                             string A267ProfesionalesVerDatPerSol ,
                                             GxSimpleCollection<string> AV26TFProfesionalesVerDatPerSol_Sels ,
                                             string A436ProfesionalesPerAltShop ,
                                             GxSimpleCollection<string> AV32TFProfesionalesPerAltShop_Sels ,
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
                                             int AV26TFProfesionalesVerDatPerSol_Sels_Count ,
                                             long AV27TFProfesionalesFeedBackCant ,
                                             long AV28TFProfesionalesFeedBackCant_To ,
                                             decimal AV29TFProfesionalesFeedback ,
                                             decimal AV30TFProfesionalesFeedback_To ,
                                             int AV32TFProfesionalesPerAltShop_Sels_Count ,
                                             string A120ProfesionalesId ,
                                             string A166ProfesionalesPrimerNombre ,
                                             string A191ProfesionalesSegundoNombre ,
                                             string A167ProfesionalesApellidoPrimero ,
                                             string A192ProfesionalesApellidoSegundo ,
                                             string A170ProfesionalesTelefono ,
                                             string A109EstadosGenericosNombre ,
                                             long A268ProfesionalesFeedBackCant ,
                                             decimal A269ProfesionalesFeedBackProm ,
                                             string AV55FilterFullText ,
                                             decimal A270ProfesionalesFeedback ,
                                             short AV56RubrosId ,
                                             short A121RubrosId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int4 = new short[19];
         Object[] GXv_Object5 = new Object[2];
         scmdbuf = "SELECT T2.[EstadosTipo], T2.[EstadosGenericosId], T1.[RubrosId], T2.[ProfesionalesPrimerNombre], T2.[ProfesionalesPerAltShop], CASE  WHEN T2.[ProfesionalesFeedBackCant] > 0 THEN CAST(T2.[ProfesionalesFeedBackProm] AS decimal( 28, 10)) / T2.[ProfesionalesFeedBackCant] END AS ProfesionalesFeedback, T2.[ProfesionalesVerDatPerSol], T3.[EstadosGenericosNombre], T2.[ProfesionalesTelefono], T2.[ProfesionalesApellidoSegundo], T2.[ProfesionalesApellidoPrimero], T2.[ProfesionalesSegundoNombre], T1.[ProfesionalesId], T2.[ProfesionalesFeedBackProm], T2.[ProfesionalesFeedBackCant] FROM (([ProfesionalesRubros] T1 INNER JOIN [Profesionales] T2 ON T2.[ProfesionalesId] = T1.[ProfesionalesId]) INNER JOIN [EstadosGenericos] T3 ON T3.[EstadosTipo] = T2.[EstadosTipo] AND T3.[EstadosGenericosId] = T2.[EstadosGenericosId])";
         AddWhere(sWhereString, "(T1.[RubrosId] = @AV56RubrosId)");
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
         if ( AV26TFProfesionalesVerDatPerSol_Sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV26TFProfesionalesVerDatPerSol_Sels, "T2.[ProfesionalesVerDatPerSol] IN (", ")")+")");
         }
         if ( ! (0==AV27TFProfesionalesFeedBackCant) )
         {
            AddWhere(sWhereString, "(T2.[ProfesionalesFeedBackCant] >= @AV27TFProfesionalesFeedBackCant)");
         }
         else
         {
            GXv_int4[15] = 1;
         }
         if ( ! (0==AV28TFProfesionalesFeedBackCant_To) )
         {
            AddWhere(sWhereString, "(T2.[ProfesionalesFeedBackCant] <= @AV28TFProfesionalesFeedBackCant_To)");
         }
         else
         {
            GXv_int4[16] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV29TFProfesionalesFeedback) )
         {
            AddWhere(sWhereString, "(( CASE  WHEN T2.[ProfesionalesFeedBackCant] > 0 THEN CAST(T2.[ProfesionalesFeedBackProm] AS decimal( 28, 10)) / T2.[ProfesionalesFeedBackCant] END) >= @AV29TFProfesionalesFeedback)");
         }
         else
         {
            GXv_int4[17] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV30TFProfesionalesFeedback_To) )
         {
            AddWhere(sWhereString, "(( CASE  WHEN T2.[ProfesionalesFeedBackCant] > 0 THEN CAST(T2.[ProfesionalesFeedBackProm] AS decimal( 28, 10)) / T2.[ProfesionalesFeedBackCant] END) <= @AV30TFProfesionalesFeedback_To)");
         }
         else
         {
            GXv_int4[18] = 1;
         }
         if ( AV32TFProfesionalesPerAltShop_Sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV32TFProfesionalesPerAltShop_Sels, "T2.[ProfesionalesPerAltShop] IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[RubrosId], T2.[ProfesionalesPrimerNombre]";
         GXv_Object5[0] = scmdbuf;
         GXv_Object5[1] = GXv_int4;
         return GXv_Object5 ;
      }

      protected Object[] conditional_P004E4( IGxContext context ,
                                             string A267ProfesionalesVerDatPerSol ,
                                             GxSimpleCollection<string> AV26TFProfesionalesVerDatPerSol_Sels ,
                                             string A436ProfesionalesPerAltShop ,
                                             GxSimpleCollection<string> AV32TFProfesionalesPerAltShop_Sels ,
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
                                             int AV26TFProfesionalesVerDatPerSol_Sels_Count ,
                                             long AV27TFProfesionalesFeedBackCant ,
                                             long AV28TFProfesionalesFeedBackCant_To ,
                                             decimal AV29TFProfesionalesFeedback ,
                                             decimal AV30TFProfesionalesFeedback_To ,
                                             int AV32TFProfesionalesPerAltShop_Sels_Count ,
                                             string A120ProfesionalesId ,
                                             string A166ProfesionalesPrimerNombre ,
                                             string A191ProfesionalesSegundoNombre ,
                                             string A167ProfesionalesApellidoPrimero ,
                                             string A192ProfesionalesApellidoSegundo ,
                                             string A170ProfesionalesTelefono ,
                                             string A109EstadosGenericosNombre ,
                                             long A268ProfesionalesFeedBackCant ,
                                             decimal A269ProfesionalesFeedBackProm ,
                                             string AV55FilterFullText ,
                                             decimal A270ProfesionalesFeedback ,
                                             short AV56RubrosId ,
                                             short A121RubrosId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int6 = new short[19];
         Object[] GXv_Object7 = new Object[2];
         scmdbuf = "SELECT T2.[EstadosTipo], T2.[EstadosGenericosId], T1.[RubrosId], T2.[ProfesionalesSegundoNombre], T2.[ProfesionalesPerAltShop], CASE  WHEN T2.[ProfesionalesFeedBackCant] > 0 THEN CAST(T2.[ProfesionalesFeedBackProm] AS decimal( 28, 10)) / T2.[ProfesionalesFeedBackCant] END AS ProfesionalesFeedback, T2.[ProfesionalesVerDatPerSol], T3.[EstadosGenericosNombre], T2.[ProfesionalesTelefono], T2.[ProfesionalesApellidoSegundo], T2.[ProfesionalesApellidoPrimero], T2.[ProfesionalesPrimerNombre], T1.[ProfesionalesId], T2.[ProfesionalesFeedBackProm], T2.[ProfesionalesFeedBackCant] FROM (([ProfesionalesRubros] T1 INNER JOIN [Profesionales] T2 ON T2.[ProfesionalesId] = T1.[ProfesionalesId]) INNER JOIN [EstadosGenericos] T3 ON T3.[EstadosTipo] = T2.[EstadosTipo] AND T3.[EstadosGenericosId] = T2.[EstadosGenericosId])";
         AddWhere(sWhereString, "(T1.[RubrosId] = @AV56RubrosId)");
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
         if ( AV26TFProfesionalesVerDatPerSol_Sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV26TFProfesionalesVerDatPerSol_Sels, "T2.[ProfesionalesVerDatPerSol] IN (", ")")+")");
         }
         if ( ! (0==AV27TFProfesionalesFeedBackCant) )
         {
            AddWhere(sWhereString, "(T2.[ProfesionalesFeedBackCant] >= @AV27TFProfesionalesFeedBackCant)");
         }
         else
         {
            GXv_int6[15] = 1;
         }
         if ( ! (0==AV28TFProfesionalesFeedBackCant_To) )
         {
            AddWhere(sWhereString, "(T2.[ProfesionalesFeedBackCant] <= @AV28TFProfesionalesFeedBackCant_To)");
         }
         else
         {
            GXv_int6[16] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV29TFProfesionalesFeedback) )
         {
            AddWhere(sWhereString, "(( CASE  WHEN T2.[ProfesionalesFeedBackCant] > 0 THEN CAST(T2.[ProfesionalesFeedBackProm] AS decimal( 28, 10)) / T2.[ProfesionalesFeedBackCant] END) >= @AV29TFProfesionalesFeedback)");
         }
         else
         {
            GXv_int6[17] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV30TFProfesionalesFeedback_To) )
         {
            AddWhere(sWhereString, "(( CASE  WHEN T2.[ProfesionalesFeedBackCant] > 0 THEN CAST(T2.[ProfesionalesFeedBackProm] AS decimal( 28, 10)) / T2.[ProfesionalesFeedBackCant] END) <= @AV30TFProfesionalesFeedback_To)");
         }
         else
         {
            GXv_int6[18] = 1;
         }
         if ( AV32TFProfesionalesPerAltShop_Sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV32TFProfesionalesPerAltShop_Sels, "T2.[ProfesionalesPerAltShop] IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[RubrosId], T2.[ProfesionalesSegundoNombre]";
         GXv_Object7[0] = scmdbuf;
         GXv_Object7[1] = GXv_int6;
         return GXv_Object7 ;
      }

      protected Object[] conditional_P004E5( IGxContext context ,
                                             string A267ProfesionalesVerDatPerSol ,
                                             GxSimpleCollection<string> AV26TFProfesionalesVerDatPerSol_Sels ,
                                             string A436ProfesionalesPerAltShop ,
                                             GxSimpleCollection<string> AV32TFProfesionalesPerAltShop_Sels ,
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
                                             int AV26TFProfesionalesVerDatPerSol_Sels_Count ,
                                             long AV27TFProfesionalesFeedBackCant ,
                                             long AV28TFProfesionalesFeedBackCant_To ,
                                             decimal AV29TFProfesionalesFeedback ,
                                             decimal AV30TFProfesionalesFeedback_To ,
                                             int AV32TFProfesionalesPerAltShop_Sels_Count ,
                                             string A120ProfesionalesId ,
                                             string A166ProfesionalesPrimerNombre ,
                                             string A191ProfesionalesSegundoNombre ,
                                             string A167ProfesionalesApellidoPrimero ,
                                             string A192ProfesionalesApellidoSegundo ,
                                             string A170ProfesionalesTelefono ,
                                             string A109EstadosGenericosNombre ,
                                             long A268ProfesionalesFeedBackCant ,
                                             decimal A269ProfesionalesFeedBackProm ,
                                             string AV55FilterFullText ,
                                             decimal A270ProfesionalesFeedback ,
                                             short AV56RubrosId ,
                                             short A121RubrosId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int8 = new short[19];
         Object[] GXv_Object9 = new Object[2];
         scmdbuf = "SELECT T2.[EstadosTipo], T2.[EstadosGenericosId], T1.[RubrosId], T2.[ProfesionalesApellidoPrimero], T2.[ProfesionalesPerAltShop], CASE  WHEN T2.[ProfesionalesFeedBackCant] > 0 THEN CAST(T2.[ProfesionalesFeedBackProm] AS decimal( 28, 10)) / T2.[ProfesionalesFeedBackCant] END AS ProfesionalesFeedback, T2.[ProfesionalesVerDatPerSol], T3.[EstadosGenericosNombre], T2.[ProfesionalesTelefono], T2.[ProfesionalesApellidoSegundo], T2.[ProfesionalesSegundoNombre], T2.[ProfesionalesPrimerNombre], T1.[ProfesionalesId], T2.[ProfesionalesFeedBackProm], T2.[ProfesionalesFeedBackCant] FROM (([ProfesionalesRubros] T1 INNER JOIN [Profesionales] T2 ON T2.[ProfesionalesId] = T1.[ProfesionalesId]) INNER JOIN [EstadosGenericos] T3 ON T3.[EstadosTipo] = T2.[EstadosTipo] AND T3.[EstadosGenericosId] = T2.[EstadosGenericosId])";
         AddWhere(sWhereString, "(T1.[RubrosId] = @AV56RubrosId)");
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
         if ( AV26TFProfesionalesVerDatPerSol_Sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV26TFProfesionalesVerDatPerSol_Sels, "T2.[ProfesionalesVerDatPerSol] IN (", ")")+")");
         }
         if ( ! (0==AV27TFProfesionalesFeedBackCant) )
         {
            AddWhere(sWhereString, "(T2.[ProfesionalesFeedBackCant] >= @AV27TFProfesionalesFeedBackCant)");
         }
         else
         {
            GXv_int8[15] = 1;
         }
         if ( ! (0==AV28TFProfesionalesFeedBackCant_To) )
         {
            AddWhere(sWhereString, "(T2.[ProfesionalesFeedBackCant] <= @AV28TFProfesionalesFeedBackCant_To)");
         }
         else
         {
            GXv_int8[16] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV29TFProfesionalesFeedback) )
         {
            AddWhere(sWhereString, "(( CASE  WHEN T2.[ProfesionalesFeedBackCant] > 0 THEN CAST(T2.[ProfesionalesFeedBackProm] AS decimal( 28, 10)) / T2.[ProfesionalesFeedBackCant] END) >= @AV29TFProfesionalesFeedback)");
         }
         else
         {
            GXv_int8[17] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV30TFProfesionalesFeedback_To) )
         {
            AddWhere(sWhereString, "(( CASE  WHEN T2.[ProfesionalesFeedBackCant] > 0 THEN CAST(T2.[ProfesionalesFeedBackProm] AS decimal( 28, 10)) / T2.[ProfesionalesFeedBackCant] END) <= @AV30TFProfesionalesFeedback_To)");
         }
         else
         {
            GXv_int8[18] = 1;
         }
         if ( AV32TFProfesionalesPerAltShop_Sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV32TFProfesionalesPerAltShop_Sels, "T2.[ProfesionalesPerAltShop] IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[RubrosId], T2.[ProfesionalesApellidoPrimero]";
         GXv_Object9[0] = scmdbuf;
         GXv_Object9[1] = GXv_int8;
         return GXv_Object9 ;
      }

      protected Object[] conditional_P004E6( IGxContext context ,
                                             string A267ProfesionalesVerDatPerSol ,
                                             GxSimpleCollection<string> AV26TFProfesionalesVerDatPerSol_Sels ,
                                             string A436ProfesionalesPerAltShop ,
                                             GxSimpleCollection<string> AV32TFProfesionalesPerAltShop_Sels ,
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
                                             int AV26TFProfesionalesVerDatPerSol_Sels_Count ,
                                             long AV27TFProfesionalesFeedBackCant ,
                                             long AV28TFProfesionalesFeedBackCant_To ,
                                             decimal AV29TFProfesionalesFeedback ,
                                             decimal AV30TFProfesionalesFeedback_To ,
                                             int AV32TFProfesionalesPerAltShop_Sels_Count ,
                                             string A120ProfesionalesId ,
                                             string A166ProfesionalesPrimerNombre ,
                                             string A191ProfesionalesSegundoNombre ,
                                             string A167ProfesionalesApellidoPrimero ,
                                             string A192ProfesionalesApellidoSegundo ,
                                             string A170ProfesionalesTelefono ,
                                             string A109EstadosGenericosNombre ,
                                             long A268ProfesionalesFeedBackCant ,
                                             decimal A269ProfesionalesFeedBackProm ,
                                             string AV55FilterFullText ,
                                             decimal A270ProfesionalesFeedback ,
                                             short AV56RubrosId ,
                                             short A121RubrosId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int10 = new short[19];
         Object[] GXv_Object11 = new Object[2];
         scmdbuf = "SELECT T2.[EstadosTipo], T2.[EstadosGenericosId], T1.[RubrosId], T2.[ProfesionalesApellidoSegundo], T2.[ProfesionalesPerAltShop], CASE  WHEN T2.[ProfesionalesFeedBackCant] > 0 THEN CAST(T2.[ProfesionalesFeedBackProm] AS decimal( 28, 10)) / T2.[ProfesionalesFeedBackCant] END AS ProfesionalesFeedback, T2.[ProfesionalesVerDatPerSol], T3.[EstadosGenericosNombre], T2.[ProfesionalesTelefono], T2.[ProfesionalesApellidoPrimero], T2.[ProfesionalesSegundoNombre], T2.[ProfesionalesPrimerNombre], T1.[ProfesionalesId], T2.[ProfesionalesFeedBackProm], T2.[ProfesionalesFeedBackCant] FROM (([ProfesionalesRubros] T1 INNER JOIN [Profesionales] T2 ON T2.[ProfesionalesId] = T1.[ProfesionalesId]) INNER JOIN [EstadosGenericos] T3 ON T3.[EstadosTipo] = T2.[EstadosTipo] AND T3.[EstadosGenericosId] = T2.[EstadosGenericosId])";
         AddWhere(sWhereString, "(T1.[RubrosId] = @AV56RubrosId)");
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
         if ( AV26TFProfesionalesVerDatPerSol_Sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV26TFProfesionalesVerDatPerSol_Sels, "T2.[ProfesionalesVerDatPerSol] IN (", ")")+")");
         }
         if ( ! (0==AV27TFProfesionalesFeedBackCant) )
         {
            AddWhere(sWhereString, "(T2.[ProfesionalesFeedBackCant] >= @AV27TFProfesionalesFeedBackCant)");
         }
         else
         {
            GXv_int10[15] = 1;
         }
         if ( ! (0==AV28TFProfesionalesFeedBackCant_To) )
         {
            AddWhere(sWhereString, "(T2.[ProfesionalesFeedBackCant] <= @AV28TFProfesionalesFeedBackCant_To)");
         }
         else
         {
            GXv_int10[16] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV29TFProfesionalesFeedback) )
         {
            AddWhere(sWhereString, "(( CASE  WHEN T2.[ProfesionalesFeedBackCant] > 0 THEN CAST(T2.[ProfesionalesFeedBackProm] AS decimal( 28, 10)) / T2.[ProfesionalesFeedBackCant] END) >= @AV29TFProfesionalesFeedback)");
         }
         else
         {
            GXv_int10[17] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV30TFProfesionalesFeedback_To) )
         {
            AddWhere(sWhereString, "(( CASE  WHEN T2.[ProfesionalesFeedBackCant] > 0 THEN CAST(T2.[ProfesionalesFeedBackProm] AS decimal( 28, 10)) / T2.[ProfesionalesFeedBackCant] END) <= @AV30TFProfesionalesFeedback_To)");
         }
         else
         {
            GXv_int10[18] = 1;
         }
         if ( AV32TFProfesionalesPerAltShop_Sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV32TFProfesionalesPerAltShop_Sels, "T2.[ProfesionalesPerAltShop] IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[RubrosId], T2.[ProfesionalesApellidoSegundo]";
         GXv_Object11[0] = scmdbuf;
         GXv_Object11[1] = GXv_int10;
         return GXv_Object11 ;
      }

      protected Object[] conditional_P004E7( IGxContext context ,
                                             string A267ProfesionalesVerDatPerSol ,
                                             GxSimpleCollection<string> AV26TFProfesionalesVerDatPerSol_Sels ,
                                             string A436ProfesionalesPerAltShop ,
                                             GxSimpleCollection<string> AV32TFProfesionalesPerAltShop_Sels ,
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
                                             int AV26TFProfesionalesVerDatPerSol_Sels_Count ,
                                             long AV27TFProfesionalesFeedBackCant ,
                                             long AV28TFProfesionalesFeedBackCant_To ,
                                             decimal AV29TFProfesionalesFeedback ,
                                             decimal AV30TFProfesionalesFeedback_To ,
                                             int AV32TFProfesionalesPerAltShop_Sels_Count ,
                                             string A120ProfesionalesId ,
                                             string A166ProfesionalesPrimerNombre ,
                                             string A191ProfesionalesSegundoNombre ,
                                             string A167ProfesionalesApellidoPrimero ,
                                             string A192ProfesionalesApellidoSegundo ,
                                             string A170ProfesionalesTelefono ,
                                             string A109EstadosGenericosNombre ,
                                             long A268ProfesionalesFeedBackCant ,
                                             decimal A269ProfesionalesFeedBackProm ,
                                             string AV55FilterFullText ,
                                             decimal A270ProfesionalesFeedback ,
                                             short AV56RubrosId ,
                                             short A121RubrosId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int12 = new short[19];
         Object[] GXv_Object13 = new Object[2];
         scmdbuf = "SELECT T2.[EstadosTipo], T2.[EstadosGenericosId], T1.[RubrosId], T2.[ProfesionalesTelefono], T2.[ProfesionalesPerAltShop], CASE  WHEN T2.[ProfesionalesFeedBackCant] > 0 THEN CAST(T2.[ProfesionalesFeedBackProm] AS decimal( 28, 10)) / T2.[ProfesionalesFeedBackCant] END AS ProfesionalesFeedback, T2.[ProfesionalesVerDatPerSol], T3.[EstadosGenericosNombre], T2.[ProfesionalesApellidoSegundo], T2.[ProfesionalesApellidoPrimero], T2.[ProfesionalesSegundoNombre], T2.[ProfesionalesPrimerNombre], T1.[ProfesionalesId], T2.[ProfesionalesFeedBackProm], T2.[ProfesionalesFeedBackCant] FROM (([ProfesionalesRubros] T1 INNER JOIN [Profesionales] T2 ON T2.[ProfesionalesId] = T1.[ProfesionalesId]) INNER JOIN [EstadosGenericos] T3 ON T3.[EstadosTipo] = T2.[EstadosTipo] AND T3.[EstadosGenericosId] = T2.[EstadosGenericosId])";
         AddWhere(sWhereString, "(T1.[RubrosId] = @AV56RubrosId)");
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
         if ( AV26TFProfesionalesVerDatPerSol_Sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV26TFProfesionalesVerDatPerSol_Sels, "T2.[ProfesionalesVerDatPerSol] IN (", ")")+")");
         }
         if ( ! (0==AV27TFProfesionalesFeedBackCant) )
         {
            AddWhere(sWhereString, "(T2.[ProfesionalesFeedBackCant] >= @AV27TFProfesionalesFeedBackCant)");
         }
         else
         {
            GXv_int12[15] = 1;
         }
         if ( ! (0==AV28TFProfesionalesFeedBackCant_To) )
         {
            AddWhere(sWhereString, "(T2.[ProfesionalesFeedBackCant] <= @AV28TFProfesionalesFeedBackCant_To)");
         }
         else
         {
            GXv_int12[16] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV29TFProfesionalesFeedback) )
         {
            AddWhere(sWhereString, "(( CASE  WHEN T2.[ProfesionalesFeedBackCant] > 0 THEN CAST(T2.[ProfesionalesFeedBackProm] AS decimal( 28, 10)) / T2.[ProfesionalesFeedBackCant] END) >= @AV29TFProfesionalesFeedback)");
         }
         else
         {
            GXv_int12[17] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV30TFProfesionalesFeedback_To) )
         {
            AddWhere(sWhereString, "(( CASE  WHEN T2.[ProfesionalesFeedBackCant] > 0 THEN CAST(T2.[ProfesionalesFeedBackProm] AS decimal( 28, 10)) / T2.[ProfesionalesFeedBackCant] END) <= @AV30TFProfesionalesFeedback_To)");
         }
         else
         {
            GXv_int12[18] = 1;
         }
         if ( AV32TFProfesionalesPerAltShop_Sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV32TFProfesionalesPerAltShop_Sels, "T2.[ProfesionalesPerAltShop] IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[RubrosId], T2.[ProfesionalesTelefono]";
         GXv_Object13[0] = scmdbuf;
         GXv_Object13[1] = GXv_int12;
         return GXv_Object13 ;
      }

      protected Object[] conditional_P004E8( IGxContext context ,
                                             string A267ProfesionalesVerDatPerSol ,
                                             GxSimpleCollection<string> AV26TFProfesionalesVerDatPerSol_Sels ,
                                             string A436ProfesionalesPerAltShop ,
                                             GxSimpleCollection<string> AV32TFProfesionalesPerAltShop_Sels ,
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
                                             int AV26TFProfesionalesVerDatPerSol_Sels_Count ,
                                             long AV27TFProfesionalesFeedBackCant ,
                                             long AV28TFProfesionalesFeedBackCant_To ,
                                             decimal AV29TFProfesionalesFeedback ,
                                             decimal AV30TFProfesionalesFeedback_To ,
                                             int AV32TFProfesionalesPerAltShop_Sels_Count ,
                                             string A120ProfesionalesId ,
                                             string A166ProfesionalesPrimerNombre ,
                                             string A191ProfesionalesSegundoNombre ,
                                             string A167ProfesionalesApellidoPrimero ,
                                             string A192ProfesionalesApellidoSegundo ,
                                             string A170ProfesionalesTelefono ,
                                             string A109EstadosGenericosNombre ,
                                             long A268ProfesionalesFeedBackCant ,
                                             decimal A269ProfesionalesFeedBackProm ,
                                             string AV55FilterFullText ,
                                             decimal A270ProfesionalesFeedback ,
                                             short AV56RubrosId ,
                                             short A121RubrosId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int14 = new short[19];
         Object[] GXv_Object15 = new Object[2];
         scmdbuf = "SELECT T2.[EstadosTipo], T2.[EstadosGenericosId], T1.[RubrosId], T3.[EstadosGenericosNombre], T2.[ProfesionalesPerAltShop], CASE  WHEN T2.[ProfesionalesFeedBackCant] > 0 THEN CAST(T2.[ProfesionalesFeedBackProm] AS decimal( 28, 10)) / T2.[ProfesionalesFeedBackCant] END AS ProfesionalesFeedback, T2.[ProfesionalesVerDatPerSol], T2.[ProfesionalesTelefono], T2.[ProfesionalesApellidoSegundo], T2.[ProfesionalesApellidoPrimero], T2.[ProfesionalesSegundoNombre], T2.[ProfesionalesPrimerNombre], T1.[ProfesionalesId], T2.[ProfesionalesFeedBackProm], T2.[ProfesionalesFeedBackCant] FROM (([ProfesionalesRubros] T1 INNER JOIN [Profesionales] T2 ON T2.[ProfesionalesId] = T1.[ProfesionalesId]) INNER JOIN [EstadosGenericos] T3 ON T3.[EstadosTipo] = T2.[EstadosTipo] AND T3.[EstadosGenericosId] = T2.[EstadosGenericosId])";
         AddWhere(sWhereString, "(T1.[RubrosId] = @AV56RubrosId)");
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
         if ( AV26TFProfesionalesVerDatPerSol_Sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV26TFProfesionalesVerDatPerSol_Sels, "T2.[ProfesionalesVerDatPerSol] IN (", ")")+")");
         }
         if ( ! (0==AV27TFProfesionalesFeedBackCant) )
         {
            AddWhere(sWhereString, "(T2.[ProfesionalesFeedBackCant] >= @AV27TFProfesionalesFeedBackCant)");
         }
         else
         {
            GXv_int14[15] = 1;
         }
         if ( ! (0==AV28TFProfesionalesFeedBackCant_To) )
         {
            AddWhere(sWhereString, "(T2.[ProfesionalesFeedBackCant] <= @AV28TFProfesionalesFeedBackCant_To)");
         }
         else
         {
            GXv_int14[16] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV29TFProfesionalesFeedback) )
         {
            AddWhere(sWhereString, "(( CASE  WHEN T2.[ProfesionalesFeedBackCant] > 0 THEN CAST(T2.[ProfesionalesFeedBackProm] AS decimal( 28, 10)) / T2.[ProfesionalesFeedBackCant] END) >= @AV29TFProfesionalesFeedback)");
         }
         else
         {
            GXv_int14[17] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV30TFProfesionalesFeedback_To) )
         {
            AddWhere(sWhereString, "(( CASE  WHEN T2.[ProfesionalesFeedBackCant] > 0 THEN CAST(T2.[ProfesionalesFeedBackProm] AS decimal( 28, 10)) / T2.[ProfesionalesFeedBackCant] END) <= @AV30TFProfesionalesFeedback_To)");
         }
         else
         {
            GXv_int14[18] = 1;
         }
         if ( AV32TFProfesionalesPerAltShop_Sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV32TFProfesionalesPerAltShop_Sels, "T2.[ProfesionalesPerAltShop] IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[RubrosId], T3.[EstadosGenericosNombre]";
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
                     return conditional_P004E2(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (GxSimpleCollection<string>)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (int)dynConstraints[18] , (long)dynConstraints[19] , (long)dynConstraints[20] , (decimal)dynConstraints[21] , (decimal)dynConstraints[22] , (int)dynConstraints[23] , (string)dynConstraints[24] , (string)dynConstraints[25] , (string)dynConstraints[26] , (string)dynConstraints[27] , (string)dynConstraints[28] , (string)dynConstraints[29] , (string)dynConstraints[30] , (long)dynConstraints[31] , (decimal)dynConstraints[32] , (string)dynConstraints[33] , (decimal)dynConstraints[34] , (short)dynConstraints[35] , (short)dynConstraints[36] );
               case 1 :
                     return conditional_P004E3(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (GxSimpleCollection<string>)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (int)dynConstraints[18] , (long)dynConstraints[19] , (long)dynConstraints[20] , (decimal)dynConstraints[21] , (decimal)dynConstraints[22] , (int)dynConstraints[23] , (string)dynConstraints[24] , (string)dynConstraints[25] , (string)dynConstraints[26] , (string)dynConstraints[27] , (string)dynConstraints[28] , (string)dynConstraints[29] , (string)dynConstraints[30] , (long)dynConstraints[31] , (decimal)dynConstraints[32] , (string)dynConstraints[33] , (decimal)dynConstraints[34] , (short)dynConstraints[35] , (short)dynConstraints[36] );
               case 2 :
                     return conditional_P004E4(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (GxSimpleCollection<string>)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (int)dynConstraints[18] , (long)dynConstraints[19] , (long)dynConstraints[20] , (decimal)dynConstraints[21] , (decimal)dynConstraints[22] , (int)dynConstraints[23] , (string)dynConstraints[24] , (string)dynConstraints[25] , (string)dynConstraints[26] , (string)dynConstraints[27] , (string)dynConstraints[28] , (string)dynConstraints[29] , (string)dynConstraints[30] , (long)dynConstraints[31] , (decimal)dynConstraints[32] , (string)dynConstraints[33] , (decimal)dynConstraints[34] , (short)dynConstraints[35] , (short)dynConstraints[36] );
               case 3 :
                     return conditional_P004E5(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (GxSimpleCollection<string>)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (int)dynConstraints[18] , (long)dynConstraints[19] , (long)dynConstraints[20] , (decimal)dynConstraints[21] , (decimal)dynConstraints[22] , (int)dynConstraints[23] , (string)dynConstraints[24] , (string)dynConstraints[25] , (string)dynConstraints[26] , (string)dynConstraints[27] , (string)dynConstraints[28] , (string)dynConstraints[29] , (string)dynConstraints[30] , (long)dynConstraints[31] , (decimal)dynConstraints[32] , (string)dynConstraints[33] , (decimal)dynConstraints[34] , (short)dynConstraints[35] , (short)dynConstraints[36] );
               case 4 :
                     return conditional_P004E6(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (GxSimpleCollection<string>)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (int)dynConstraints[18] , (long)dynConstraints[19] , (long)dynConstraints[20] , (decimal)dynConstraints[21] , (decimal)dynConstraints[22] , (int)dynConstraints[23] , (string)dynConstraints[24] , (string)dynConstraints[25] , (string)dynConstraints[26] , (string)dynConstraints[27] , (string)dynConstraints[28] , (string)dynConstraints[29] , (string)dynConstraints[30] , (long)dynConstraints[31] , (decimal)dynConstraints[32] , (string)dynConstraints[33] , (decimal)dynConstraints[34] , (short)dynConstraints[35] , (short)dynConstraints[36] );
               case 5 :
                     return conditional_P004E7(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (GxSimpleCollection<string>)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (int)dynConstraints[18] , (long)dynConstraints[19] , (long)dynConstraints[20] , (decimal)dynConstraints[21] , (decimal)dynConstraints[22] , (int)dynConstraints[23] , (string)dynConstraints[24] , (string)dynConstraints[25] , (string)dynConstraints[26] , (string)dynConstraints[27] , (string)dynConstraints[28] , (string)dynConstraints[29] , (string)dynConstraints[30] , (long)dynConstraints[31] , (decimal)dynConstraints[32] , (string)dynConstraints[33] , (decimal)dynConstraints[34] , (short)dynConstraints[35] , (short)dynConstraints[36] );
               case 6 :
                     return conditional_P004E8(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (GxSimpleCollection<string>)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (int)dynConstraints[18] , (long)dynConstraints[19] , (long)dynConstraints[20] , (decimal)dynConstraints[21] , (decimal)dynConstraints[22] , (int)dynConstraints[23] , (string)dynConstraints[24] , (string)dynConstraints[25] , (string)dynConstraints[26] , (string)dynConstraints[27] , (string)dynConstraints[28] , (string)dynConstraints[29] , (string)dynConstraints[30] , (long)dynConstraints[31] , (decimal)dynConstraints[32] , (string)dynConstraints[33] , (decimal)dynConstraints[34] , (short)dynConstraints[35] , (short)dynConstraints[36] );
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
          Object[] prmP004E2;
          prmP004E2 = new Object[] {
          new ParDef("@AV56RubrosId",GXType.Int16,4,0) ,
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
          new ParDef("@AV24TFEstadosGenericosNombre_Sel",GXType.NChar,80,0) ,
          new ParDef("@AV27TFProfesionalesFeedBackCant",GXType.Decimal,18,0) ,
          new ParDef("@AV28TFProfesionalesFeedBackCant_To",GXType.Decimal,18,0) ,
          new ParDef("@AV29TFProfesionalesFeedback",GXType.Decimal,10,2) ,
          new ParDef("@AV30TFProfesionalesFeedback_To",GXType.Decimal,10,2)
          };
          Object[] prmP004E3;
          prmP004E3 = new Object[] {
          new ParDef("@AV56RubrosId",GXType.Int16,4,0) ,
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
          new ParDef("@AV24TFEstadosGenericosNombre_Sel",GXType.NChar,80,0) ,
          new ParDef("@AV27TFProfesionalesFeedBackCant",GXType.Decimal,18,0) ,
          new ParDef("@AV28TFProfesionalesFeedBackCant_To",GXType.Decimal,18,0) ,
          new ParDef("@AV29TFProfesionalesFeedback",GXType.Decimal,10,2) ,
          new ParDef("@AV30TFProfesionalesFeedback_To",GXType.Decimal,10,2)
          };
          Object[] prmP004E4;
          prmP004E4 = new Object[] {
          new ParDef("@AV56RubrosId",GXType.Int16,4,0) ,
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
          new ParDef("@AV24TFEstadosGenericosNombre_Sel",GXType.NChar,80,0) ,
          new ParDef("@AV27TFProfesionalesFeedBackCant",GXType.Decimal,18,0) ,
          new ParDef("@AV28TFProfesionalesFeedBackCant_To",GXType.Decimal,18,0) ,
          new ParDef("@AV29TFProfesionalesFeedback",GXType.Decimal,10,2) ,
          new ParDef("@AV30TFProfesionalesFeedback_To",GXType.Decimal,10,2)
          };
          Object[] prmP004E5;
          prmP004E5 = new Object[] {
          new ParDef("@AV56RubrosId",GXType.Int16,4,0) ,
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
          new ParDef("@AV24TFEstadosGenericosNombre_Sel",GXType.NChar,80,0) ,
          new ParDef("@AV27TFProfesionalesFeedBackCant",GXType.Decimal,18,0) ,
          new ParDef("@AV28TFProfesionalesFeedBackCant_To",GXType.Decimal,18,0) ,
          new ParDef("@AV29TFProfesionalesFeedback",GXType.Decimal,10,2) ,
          new ParDef("@AV30TFProfesionalesFeedback_To",GXType.Decimal,10,2)
          };
          Object[] prmP004E6;
          prmP004E6 = new Object[] {
          new ParDef("@AV56RubrosId",GXType.Int16,4,0) ,
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
          new ParDef("@AV24TFEstadosGenericosNombre_Sel",GXType.NChar,80,0) ,
          new ParDef("@AV27TFProfesionalesFeedBackCant",GXType.Decimal,18,0) ,
          new ParDef("@AV28TFProfesionalesFeedBackCant_To",GXType.Decimal,18,0) ,
          new ParDef("@AV29TFProfesionalesFeedback",GXType.Decimal,10,2) ,
          new ParDef("@AV30TFProfesionalesFeedback_To",GXType.Decimal,10,2)
          };
          Object[] prmP004E7;
          prmP004E7 = new Object[] {
          new ParDef("@AV56RubrosId",GXType.Int16,4,0) ,
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
          new ParDef("@AV24TFEstadosGenericosNombre_Sel",GXType.NChar,80,0) ,
          new ParDef("@AV27TFProfesionalesFeedBackCant",GXType.Decimal,18,0) ,
          new ParDef("@AV28TFProfesionalesFeedBackCant_To",GXType.Decimal,18,0) ,
          new ParDef("@AV29TFProfesionalesFeedback",GXType.Decimal,10,2) ,
          new ParDef("@AV30TFProfesionalesFeedback_To",GXType.Decimal,10,2)
          };
          Object[] prmP004E8;
          prmP004E8 = new Object[] {
          new ParDef("@AV56RubrosId",GXType.Int16,4,0) ,
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
          new ParDef("@AV24TFEstadosGenericosNombre_Sel",GXType.NChar,80,0) ,
          new ParDef("@AV27TFProfesionalesFeedBackCant",GXType.Decimal,18,0) ,
          new ParDef("@AV28TFProfesionalesFeedBackCant_To",GXType.Decimal,18,0) ,
          new ParDef("@AV29TFProfesionalesFeedback",GXType.Decimal,10,2) ,
          new ParDef("@AV30TFProfesionalesFeedback_To",GXType.Decimal,10,2)
          };
          def= new CursorDef[] {
              new CursorDef("P004E2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP004E2,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P004E3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP004E3,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P004E4", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP004E4,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P004E5", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP004E5,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P004E6", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP004E6,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P004E7", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP004E7,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P004E8", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP004E8,100, GxCacheFrequency.OFF ,true,false )
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
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 1);
                ((bool[]) buf[4])[0] = rslt.wasNull(4);
                ((decimal[]) buf[5])[0] = rslt.getDecimal(5);
                ((string[]) buf[6])[0] = rslt.getString(6, 1);
                ((string[]) buf[7])[0] = rslt.getString(7, 80);
                ((string[]) buf[8])[0] = rslt.getString(8, 20);
                ((string[]) buf[9])[0] = rslt.getString(9, 30);
                ((string[]) buf[10])[0] = rslt.getString(10, 30);
                ((string[]) buf[11])[0] = rslt.getString(11, 30);
                ((string[]) buf[12])[0] = rslt.getString(12, 30);
                ((string[]) buf[13])[0] = rslt.getString(13, 20);
                ((decimal[]) buf[14])[0] = rslt.getDecimal(14);
                ((long[]) buf[15])[0] = rslt.getLong(15);
                return;
             case 1 :
                ((string[]) buf[0])[0] = rslt.getString(1, 3);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 30);
                ((string[]) buf[4])[0] = rslt.getString(5, 1);
                ((bool[]) buf[5])[0] = rslt.wasNull(5);
                ((decimal[]) buf[6])[0] = rslt.getDecimal(6);
                ((string[]) buf[7])[0] = rslt.getString(7, 1);
                ((string[]) buf[8])[0] = rslt.getString(8, 80);
                ((string[]) buf[9])[0] = rslt.getString(9, 20);
                ((string[]) buf[10])[0] = rslt.getString(10, 30);
                ((string[]) buf[11])[0] = rslt.getString(11, 30);
                ((string[]) buf[12])[0] = rslt.getString(12, 30);
                ((string[]) buf[13])[0] = rslt.getString(13, 20);
                ((decimal[]) buf[14])[0] = rslt.getDecimal(14);
                ((long[]) buf[15])[0] = rslt.getLong(15);
                return;
             case 2 :
                ((string[]) buf[0])[0] = rslt.getString(1, 3);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 30);
                ((string[]) buf[4])[0] = rslt.getString(5, 1);
                ((bool[]) buf[5])[0] = rslt.wasNull(5);
                ((decimal[]) buf[6])[0] = rslt.getDecimal(6);
                ((string[]) buf[7])[0] = rslt.getString(7, 1);
                ((string[]) buf[8])[0] = rslt.getString(8, 80);
                ((string[]) buf[9])[0] = rslt.getString(9, 20);
                ((string[]) buf[10])[0] = rslt.getString(10, 30);
                ((string[]) buf[11])[0] = rslt.getString(11, 30);
                ((string[]) buf[12])[0] = rslt.getString(12, 30);
                ((string[]) buf[13])[0] = rslt.getString(13, 20);
                ((decimal[]) buf[14])[0] = rslt.getDecimal(14);
                ((long[]) buf[15])[0] = rslt.getLong(15);
                return;
             case 3 :
                ((string[]) buf[0])[0] = rslt.getString(1, 3);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 30);
                ((string[]) buf[4])[0] = rslt.getString(5, 1);
                ((bool[]) buf[5])[0] = rslt.wasNull(5);
                ((decimal[]) buf[6])[0] = rslt.getDecimal(6);
                ((string[]) buf[7])[0] = rslt.getString(7, 1);
                ((string[]) buf[8])[0] = rslt.getString(8, 80);
                ((string[]) buf[9])[0] = rslt.getString(9, 20);
                ((string[]) buf[10])[0] = rslt.getString(10, 30);
                ((string[]) buf[11])[0] = rslt.getString(11, 30);
                ((string[]) buf[12])[0] = rslt.getString(12, 30);
                ((string[]) buf[13])[0] = rslt.getString(13, 20);
                ((decimal[]) buf[14])[0] = rslt.getDecimal(14);
                ((long[]) buf[15])[0] = rslt.getLong(15);
                return;
             case 4 :
                ((string[]) buf[0])[0] = rslt.getString(1, 3);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 30);
                ((string[]) buf[4])[0] = rslt.getString(5, 1);
                ((bool[]) buf[5])[0] = rslt.wasNull(5);
                ((decimal[]) buf[6])[0] = rslt.getDecimal(6);
                ((string[]) buf[7])[0] = rslt.getString(7, 1);
                ((string[]) buf[8])[0] = rslt.getString(8, 80);
                ((string[]) buf[9])[0] = rslt.getString(9, 20);
                ((string[]) buf[10])[0] = rslt.getString(10, 30);
                ((string[]) buf[11])[0] = rslt.getString(11, 30);
                ((string[]) buf[12])[0] = rslt.getString(12, 30);
                ((string[]) buf[13])[0] = rslt.getString(13, 20);
                ((decimal[]) buf[14])[0] = rslt.getDecimal(14);
                ((long[]) buf[15])[0] = rslt.getLong(15);
                return;
             case 5 :
                ((string[]) buf[0])[0] = rslt.getString(1, 3);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 20);
                ((string[]) buf[4])[0] = rslt.getString(5, 1);
                ((bool[]) buf[5])[0] = rslt.wasNull(5);
                ((decimal[]) buf[6])[0] = rslt.getDecimal(6);
                ((string[]) buf[7])[0] = rslt.getString(7, 1);
                ((string[]) buf[8])[0] = rslt.getString(8, 80);
                ((string[]) buf[9])[0] = rslt.getString(9, 30);
                ((string[]) buf[10])[0] = rslt.getString(10, 30);
                ((string[]) buf[11])[0] = rslt.getString(11, 30);
                ((string[]) buf[12])[0] = rslt.getString(12, 30);
                ((string[]) buf[13])[0] = rslt.getString(13, 20);
                ((decimal[]) buf[14])[0] = rslt.getDecimal(14);
                ((long[]) buf[15])[0] = rslt.getLong(15);
                return;
             case 6 :
                ((string[]) buf[0])[0] = rslt.getString(1, 3);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 80);
                ((string[]) buf[4])[0] = rslt.getString(5, 1);
                ((bool[]) buf[5])[0] = rslt.wasNull(5);
                ((decimal[]) buf[6])[0] = rslt.getDecimal(6);
                ((string[]) buf[7])[0] = rslt.getString(7, 1);
                ((string[]) buf[8])[0] = rslt.getString(8, 20);
                ((string[]) buf[9])[0] = rslt.getString(9, 30);
                ((string[]) buf[10])[0] = rslt.getString(10, 30);
                ((string[]) buf[11])[0] = rslt.getString(11, 30);
                ((string[]) buf[12])[0] = rslt.getString(12, 30);
                ((string[]) buf[13])[0] = rslt.getString(13, 20);
                ((decimal[]) buf[14])[0] = rslt.getDecimal(14);
                ((long[]) buf[15])[0] = rslt.getLong(15);
                return;
       }
    }

 }

 [ServiceContract(Namespace = "GeneXus.Programs.rubrosmedidasrubroswcgetfilterdata_services")]
 [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple)]
 [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
 public class rubrosmedidasrubroswcgetfilterdata_services : GxRestService
 {
    [OperationContract(Name = "RubrosMedidasRubrosWCGetFilterData" )]
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
          if ( ! ProcessHeaders("rubrosmedidasrubroswcgetfilterdata") )
          {
             return  ;
          }
          rubrosmedidasrubroswcgetfilterdata worker = new rubrosmedidasrubroswcgetfilterdata(context);
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

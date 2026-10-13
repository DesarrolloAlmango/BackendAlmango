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
   public class listacostosdetalles1wcgetfilterdata : GXProcedure
   {
      public listacostosdetalles1wcgetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public listacostosdetalles1wcgetfilterdata( IGxContext context )
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
         new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWCostoServicios", out  GXt_boolean1) ;
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
            if ( StringUtil.StrCmp(StringUtil.Upper( AV53DDOName), "DDO_CENTROCOSTOSNOMBRE") == 0 )
            {
               /* Execute user subroutine: 'LOADCENTROCOSTOSNOMBREOPTIONS' */
               S121 ();
               if ( returnInSub )
               {
                  cleanup();
                  if (true) return;
               }
            }
            else if ( StringUtil.StrCmp(StringUtil.Upper( AV53DDOName), "DDO_CENTROCOSTOSUSRALTA") == 0 )
            {
               /* Execute user subroutine: 'LOADCENTROCOSTOSUSRALTAOPTIONS' */
               S131 ();
               if ( returnInSub )
               {
                  cleanup();
                  if (true) return;
               }
            }
            else if ( StringUtil.StrCmp(StringUtil.Upper( AV53DDOName), "DDO_CENTROCOSTOSUSRMOD") == 0 )
            {
               /* Execute user subroutine: 'LOADCENTROCOSTOSUSRMODOPTIONS' */
               S141 ();
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
         if ( StringUtil.StrCmp(AV48Session.Get("ListaCostosDetalles1WCGridState"), "") == 0 )
         {
            AV50GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "ListaCostosDetalles1WCGridState"), null, "", "");
         }
         else
         {
            AV50GridState.FromXml(AV48Session.Get("ListaCostosDetalles1WCGridState"), null, "", "");
         }
         AV61GXV1 = 1;
         while ( AV61GXV1 <= AV50GridState.gxTpr_Filtervalues.Count )
         {
            AV51GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV50GridState.gxTpr_Filtervalues.Item(AV61GXV1));
            if ( StringUtil.StrCmp(AV51GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV59FilterFullText = AV51GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV51GridStateFilterValue.gxTpr_Name, "TFCENTROCOSTOSID") == 0 )
            {
               AV11TFCentroCostosId = (long)(Math.Round(NumberUtil.Val( AV51GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV12TFCentroCostosId_To = (long)(Math.Round(NumberUtil.Val( AV51GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV51GridStateFilterValue.gxTpr_Name, "TFCENTROCOSTOSTIPOREF_SEL") == 0 )
            {
               AV13TFCentroCostosTipoRef_SelsJson = AV51GridStateFilterValue.gxTpr_Value;
               AV14TFCentroCostosTipoRef_Sels.FromJSonString(AV13TFCentroCostosTipoRef_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV51GridStateFilterValue.gxTpr_Name, "TFCENTROCOSTOSREF") == 0 )
            {
               AV15TFCentroCostosRef = (long)(Math.Round(NumberUtil.Val( AV51GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV16TFCentroCostosRef_To = (long)(Math.Round(NumberUtil.Val( AV51GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV51GridStateFilterValue.gxTpr_Name, "TFCENTROCOSTOSNOMBRE") == 0 )
            {
               AV17TFCentroCostosNombre = AV51GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV51GridStateFilterValue.gxTpr_Name, "TFCENTROCOSTOSNOMBRE_SEL") == 0 )
            {
               AV18TFCentroCostosNombre_Sel = AV51GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV51GridStateFilterValue.gxTpr_Name, "TFCENTROCOSTOSPRECIOFINAL") == 0 )
            {
               AV19TFCentroCostosPrecioFinal = NumberUtil.Val( AV51GridStateFilterValue.gxTpr_Value, ".");
               AV20TFCentroCostosPrecioFinal_To = NumberUtil.Val( AV51GridStateFilterValue.gxTpr_Valueto, ".");
            }
            else if ( StringUtil.StrCmp(AV51GridStateFilterValue.gxTpr_Name, "TFCENTROCOSTOSSUBTOTAL") == 0 )
            {
               AV21TFCentroCostosSubTotal = NumberUtil.Val( AV51GridStateFilterValue.gxTpr_Value, ".");
               AV22TFCentroCostosSubTotal_To = NumberUtil.Val( AV51GridStateFilterValue.gxTpr_Valueto, ".");
            }
            else if ( StringUtil.StrCmp(AV51GridStateFilterValue.gxTpr_Name, "TFCENTROCOSTOSCOSTO") == 0 )
            {
               AV23TFCentroCostosCosto = NumberUtil.Val( AV51GridStateFilterValue.gxTpr_Value, ".");
               AV24TFCentroCostosCosto_To = NumberUtil.Val( AV51GridStateFilterValue.gxTpr_Valueto, ".");
            }
            else if ( StringUtil.StrCmp(AV51GridStateFilterValue.gxTpr_Name, "TFCENTROCOSTOSGAM") == 0 )
            {
               AV25TFCentroCostosGam = NumberUtil.Val( AV51GridStateFilterValue.gxTpr_Value, ".");
               AV26TFCentroCostosGam_To = NumberUtil.Val( AV51GridStateFilterValue.gxTpr_Valueto, ".");
            }
            else if ( StringUtil.StrCmp(AV51GridStateFilterValue.gxTpr_Name, "TFCENTROCOSTOSUSRALTA") == 0 )
            {
               AV27TFCentroCostosUsrAlta = AV51GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV51GridStateFilterValue.gxTpr_Name, "TFCENTROCOSTOSUSRALTA_SEL") == 0 )
            {
               AV28TFCentroCostosUsrAlta_Sel = AV51GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV51GridStateFilterValue.gxTpr_Name, "TFCENTROCOSTOSUSRMOD") == 0 )
            {
               AV29TFCentroCostosUsrMod = AV51GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV51GridStateFilterValue.gxTpr_Name, "TFCENTROCOSTOSUSRMOD_SEL") == 0 )
            {
               AV30TFCentroCostosUsrMod_Sel = AV51GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV51GridStateFilterValue.gxTpr_Name, "TFCENTROCOSTOSHORAALT") == 0 )
            {
               AV31TFCentroCostosHoraAlt = context.localUtil.CToD( AV51GridStateFilterValue.gxTpr_Value, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               AV32TFCentroCostosHoraAlt_To = context.localUtil.CToD( AV51GridStateFilterValue.gxTpr_Valueto, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
            }
            else if ( StringUtil.StrCmp(AV51GridStateFilterValue.gxTpr_Name, "TFCENTROCOSTOSHORAMOD") == 0 )
            {
               AV33TFCentroCostosHoraMod = context.localUtil.CToD( AV51GridStateFilterValue.gxTpr_Value, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               AV34TFCentroCostosHoraMod_To = context.localUtil.CToD( AV51GridStateFilterValue.gxTpr_Valueto, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
            }
            else if ( StringUtil.StrCmp(AV51GridStateFilterValue.gxTpr_Name, "TFCENTROCOSTOSESTADO_SEL") == 0 )
            {
               AV35TFCentroCostosEstado_SelsJson = AV51GridStateFilterValue.gxTpr_Value;
               AV36TFCentroCostosEstado_Sels.FromJSonString(AV35TFCentroCostosEstado_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV51GridStateFilterValue.gxTpr_Name, "PARM_&LISTACOSTOSID") == 0 )
            {
               AV60ListaCostosId = (long)(Math.Round(NumberUtil.Val( AV51GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
            }
            AV61GXV1 = (int)(AV61GXV1+1);
         }
      }

      protected void S121( )
      {
         /* 'LOADCENTROCOSTOSNOMBREOPTIONS' Routine */
         returnInSub = false;
         AV17TFCentroCostosNombre = AV37SearchTxt;
         AV18TFCentroCostosNombre_Sel = "";
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A487CentroCostosTipoRef ,
                                              AV14TFCentroCostosTipoRef_Sels ,
                                              A482CentroCostosEstado ,
                                              AV36TFCentroCostosEstado_Sels ,
                                              AV11TFCentroCostosId ,
                                              AV12TFCentroCostosId_To ,
                                              AV14TFCentroCostosTipoRef_Sels.Count ,
                                              AV15TFCentroCostosRef ,
                                              AV16TFCentroCostosRef_To ,
                                              AV18TFCentroCostosNombre_Sel ,
                                              AV17TFCentroCostosNombre ,
                                              AV19TFCentroCostosPrecioFinal ,
                                              AV20TFCentroCostosPrecioFinal_To ,
                                              AV21TFCentroCostosSubTotal ,
                                              AV22TFCentroCostosSubTotal_To ,
                                              AV23TFCentroCostosCosto ,
                                              AV24TFCentroCostosCosto_To ,
                                              AV25TFCentroCostosGam ,
                                              AV26TFCentroCostosGam_To ,
                                              AV28TFCentroCostosUsrAlta_Sel ,
                                              AV27TFCentroCostosUsrAlta ,
                                              AV30TFCentroCostosUsrMod_Sel ,
                                              AV29TFCentroCostosUsrMod ,
                                              AV31TFCentroCostosHoraAlt ,
                                              AV32TFCentroCostosHoraAlt_To ,
                                              AV33TFCentroCostosHoraMod ,
                                              AV34TFCentroCostosHoraMod_To ,
                                              AV36TFCentroCostosEstado_Sels.Count ,
                                              A461CentroCostosId ,
                                              A462CentroCostosRef ,
                                              A463CentroCostosNombre ,
                                              A464CentroCostosPrecioFinal ,
                                              A469CentroCostosSubTotal ,
                                              A475CentroCostosCosto ,
                                              A478CentroCostosUsrAlta ,
                                              A479CentroCostosUsrMod ,
                                              A480CentroCostosHoraAlt ,
                                              A481CentroCostosHoraMod ,
                                              AV59FilterFullText ,
                                              A474CentroCostosGam ,
                                              AV60ListaCostosId ,
                                              A459ListaCostosId } ,
                                              new int[]{
                                              TypeConstants.LONG, TypeConstants.LONG, TypeConstants.INT, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL,
                                              TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.INT, TypeConstants.LONG, TypeConstants.LONG,
                                              TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DECIMAL, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.BOOLEAN
                                              }
         });
         lV17TFCentroCostosNombre = StringUtil.PadR( StringUtil.RTrim( AV17TFCentroCostosNombre), 80, "%");
         lV27TFCentroCostosUsrAlta = StringUtil.PadR( StringUtil.RTrim( AV27TFCentroCostosUsrAlta), 30, "%");
         lV29TFCentroCostosUsrMod = StringUtil.PadR( StringUtil.RTrim( AV29TFCentroCostosUsrMod), 30, "%");
         /* Using cursor P00623 */
         pr_default.execute(0, new Object[] {AV60ListaCostosId, AV11TFCentroCostosId, AV12TFCentroCostosId_To, AV15TFCentroCostosRef, AV16TFCentroCostosRef_To, lV17TFCentroCostosNombre, AV18TFCentroCostosNombre_Sel, AV19TFCentroCostosPrecioFinal, AV20TFCentroCostosPrecioFinal_To, AV21TFCentroCostosSubTotal, AV22TFCentroCostosSubTotal_To, AV23TFCentroCostosCosto, AV24TFCentroCostosCosto_To, AV25TFCentroCostosGam, AV26TFCentroCostosGam_To, lV27TFCentroCostosUsrAlta, AV28TFCentroCostosUsrAlta_Sel, lV29TFCentroCostosUsrMod, AV30TFCentroCostosUsrMod_Sel, AV31TFCentroCostosHoraAlt, AV32TFCentroCostosHoraAlt_To, AV33TFCentroCostosHoraMod, AV34TFCentroCostosHoraMod_To});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRK622 = false;
            A459ListaCostosId = P00623_A459ListaCostosId[0];
            n459ListaCostosId = P00623_n459ListaCostosId[0];
            A463CentroCostosNombre = P00623_A463CentroCostosNombre[0];
            A481CentroCostosHoraMod = P00623_A481CentroCostosHoraMod[0];
            A480CentroCostosHoraAlt = P00623_A480CentroCostosHoraAlt[0];
            A482CentroCostosEstado = P00623_A482CentroCostosEstado[0];
            A479CentroCostosUsrMod = P00623_A479CentroCostosUsrMod[0];
            A478CentroCostosUsrAlta = P00623_A478CentroCostosUsrAlta[0];
            A474CentroCostosGam = P00623_A474CentroCostosGam[0];
            A462CentroCostosRef = P00623_A462CentroCostosRef[0];
            A487CentroCostosTipoRef = P00623_A487CentroCostosTipoRef[0];
            A461CentroCostosId = P00623_A461CentroCostosId[0];
            A464CentroCostosPrecioFinal = P00623_A464CentroCostosPrecioFinal[0];
            A475CentroCostosCosto = P00623_A475CentroCostosCosto[0];
            A469CentroCostosSubTotal = P00623_A469CentroCostosSubTotal[0];
            n469CentroCostosSubTotal = P00623_n469CentroCostosSubTotal[0];
            A466CentroCostosDetallesId = P00623_A466CentroCostosDetallesId[0];
            A463CentroCostosNombre = P00623_A463CentroCostosNombre[0];
            A481CentroCostosHoraMod = P00623_A481CentroCostosHoraMod[0];
            A480CentroCostosHoraAlt = P00623_A480CentroCostosHoraAlt[0];
            A482CentroCostosEstado = P00623_A482CentroCostosEstado[0];
            A479CentroCostosUsrMod = P00623_A479CentroCostosUsrMod[0];
            A478CentroCostosUsrAlta = P00623_A478CentroCostosUsrAlta[0];
            A474CentroCostosGam = P00623_A474CentroCostosGam[0];
            A462CentroCostosRef = P00623_A462CentroCostosRef[0];
            A487CentroCostosTipoRef = P00623_A487CentroCostosTipoRef[0];
            A464CentroCostosPrecioFinal = P00623_A464CentroCostosPrecioFinal[0];
            A475CentroCostosCosto = P00623_A475CentroCostosCosto[0];
            A469CentroCostosSubTotal = P00623_A469CentroCostosSubTotal[0];
            n469CentroCostosSubTotal = P00623_n469CentroCostosSubTotal[0];
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV59FilterFullText)) || ( ( StringUtil.Like( StringUtil.Str( (decimal)(A461CentroCostosId), 18, 0) , StringUtil.PadR( "%" + AV59FilterFullText , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( context.GetMessage( "servicios", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV59FilterFullText) , 255 , "%"),  ' ' ) &&
            ( StringUtil.StrCmp(A487CentroCostosTipoRef, "S") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "otros", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV59FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A487CentroCostosTipoRef, "O") == 0 ) ) ||
            ( StringUtil.Like( StringUtil.Str( (decimal)(A462CentroCostosRef), 18, 0) , StringUtil.PadR( "%" + AV59FilterFullText , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A463CentroCostosNombre) , StringUtil.PadR( "%" + StringUtil.Upper( AV59FilterFullText) , 255 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Str( A464CentroCostosPrecioFinal, 18, 2) , StringUtil.PadR( "%" + AV59FilterFullText , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Str( A469CentroCostosSubTotal, 18, 2) , StringUtil.PadR( "%" + AV59FilterFullText , 254 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Str( A475CentroCostosCosto, 18, 2) , StringUtil.PadR( "%" + AV59FilterFullText , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Str( A474CentroCostosGam, 18, 2) , StringUtil.PadR( "%" + AV59FilterFullText , 254 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Upper( A478CentroCostosUsrAlta) , StringUtil.PadR( "%" + StringUtil.Upper( AV59FilterFullText) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A479CentroCostosUsrMod) , StringUtil.PadR( "%" + StringUtil.Upper( AV59FilterFullText) , 255 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( context.GetMessage( "aprobado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV59FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A482CentroCostosEstado, "HAB") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "deshabilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV59FilterFullText) , 255 , "%"),  ' ' ) &&
            ( StringUtil.StrCmp(A482CentroCostosEstado, "DES") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "pendiente de aprobación", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV59FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A482CentroCostosEstado, "PND") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "desaprobado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV59FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A482CentroCostosEstado, "DES") == 0 ) ) )
            )
            {
               AV47count = 0;
               while ( (pr_default.getStatus(0) != 101) && ( P00623_A459ListaCostosId[0] == A459ListaCostosId ) && ( StringUtil.StrCmp(P00623_A463CentroCostosNombre[0], A463CentroCostosNombre) == 0 ) )
               {
                  BRK622 = false;
                  A461CentroCostosId = P00623_A461CentroCostosId[0];
                  A466CentroCostosDetallesId = P00623_A466CentroCostosDetallesId[0];
                  AV47count = (long)(AV47count+1);
                  BRK622 = true;
                  pr_default.readNext(0);
               }
               if ( (0==AV38SkipItems) )
               {
                  AV42Option = (String.IsNullOrEmpty(StringUtil.RTrim( A463CentroCostosNombre)) ? "<#Empty#>" : A463CentroCostosNombre);
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
            if ( ! BRK622 )
            {
               BRK622 = true;
               pr_default.readNext(0);
            }
         }
         pr_default.close(0);
      }

      protected void S131( )
      {
         /* 'LOADCENTROCOSTOSUSRALTAOPTIONS' Routine */
         returnInSub = false;
         AV27TFCentroCostosUsrAlta = AV37SearchTxt;
         AV28TFCentroCostosUsrAlta_Sel = "";
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              A487CentroCostosTipoRef ,
                                              AV14TFCentroCostosTipoRef_Sels ,
                                              A482CentroCostosEstado ,
                                              AV36TFCentroCostosEstado_Sels ,
                                              AV11TFCentroCostosId ,
                                              AV12TFCentroCostosId_To ,
                                              AV14TFCentroCostosTipoRef_Sels.Count ,
                                              AV15TFCentroCostosRef ,
                                              AV16TFCentroCostosRef_To ,
                                              AV18TFCentroCostosNombre_Sel ,
                                              AV17TFCentroCostosNombre ,
                                              AV19TFCentroCostosPrecioFinal ,
                                              AV20TFCentroCostosPrecioFinal_To ,
                                              AV21TFCentroCostosSubTotal ,
                                              AV22TFCentroCostosSubTotal_To ,
                                              AV23TFCentroCostosCosto ,
                                              AV24TFCentroCostosCosto_To ,
                                              AV25TFCentroCostosGam ,
                                              AV26TFCentroCostosGam_To ,
                                              AV28TFCentroCostosUsrAlta_Sel ,
                                              AV27TFCentroCostosUsrAlta ,
                                              AV30TFCentroCostosUsrMod_Sel ,
                                              AV29TFCentroCostosUsrMod ,
                                              AV31TFCentroCostosHoraAlt ,
                                              AV32TFCentroCostosHoraAlt_To ,
                                              AV33TFCentroCostosHoraMod ,
                                              AV34TFCentroCostosHoraMod_To ,
                                              AV36TFCentroCostosEstado_Sels.Count ,
                                              A461CentroCostosId ,
                                              A462CentroCostosRef ,
                                              A463CentroCostosNombre ,
                                              A464CentroCostosPrecioFinal ,
                                              A469CentroCostosSubTotal ,
                                              A475CentroCostosCosto ,
                                              A478CentroCostosUsrAlta ,
                                              A479CentroCostosUsrMod ,
                                              A480CentroCostosHoraAlt ,
                                              A481CentroCostosHoraMod ,
                                              AV59FilterFullText ,
                                              A474CentroCostosGam ,
                                              AV60ListaCostosId ,
                                              A459ListaCostosId } ,
                                              new int[]{
                                              TypeConstants.LONG, TypeConstants.LONG, TypeConstants.INT, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL,
                                              TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.INT, TypeConstants.LONG, TypeConstants.LONG,
                                              TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DECIMAL, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.BOOLEAN
                                              }
         });
         lV17TFCentroCostosNombre = StringUtil.PadR( StringUtil.RTrim( AV17TFCentroCostosNombre), 80, "%");
         lV27TFCentroCostosUsrAlta = StringUtil.PadR( StringUtil.RTrim( AV27TFCentroCostosUsrAlta), 30, "%");
         lV29TFCentroCostosUsrMod = StringUtil.PadR( StringUtil.RTrim( AV29TFCentroCostosUsrMod), 30, "%");
         /* Using cursor P00625 */
         pr_default.execute(1, new Object[] {AV60ListaCostosId, AV11TFCentroCostosId, AV12TFCentroCostosId_To, AV15TFCentroCostosRef, AV16TFCentroCostosRef_To, lV17TFCentroCostosNombre, AV18TFCentroCostosNombre_Sel, AV19TFCentroCostosPrecioFinal, AV20TFCentroCostosPrecioFinal_To, AV21TFCentroCostosSubTotal, AV22TFCentroCostosSubTotal_To, AV23TFCentroCostosCosto, AV24TFCentroCostosCosto_To, AV25TFCentroCostosGam, AV26TFCentroCostosGam_To, lV27TFCentroCostosUsrAlta, AV28TFCentroCostosUsrAlta_Sel, lV29TFCentroCostosUsrMod, AV30TFCentroCostosUsrMod_Sel, AV31TFCentroCostosHoraAlt, AV32TFCentroCostosHoraAlt_To, AV33TFCentroCostosHoraMod, AV34TFCentroCostosHoraMod_To});
         while ( (pr_default.getStatus(1) != 101) )
         {
            BRK624 = false;
            A459ListaCostosId = P00625_A459ListaCostosId[0];
            n459ListaCostosId = P00625_n459ListaCostosId[0];
            A478CentroCostosUsrAlta = P00625_A478CentroCostosUsrAlta[0];
            A481CentroCostosHoraMod = P00625_A481CentroCostosHoraMod[0];
            A480CentroCostosHoraAlt = P00625_A480CentroCostosHoraAlt[0];
            A482CentroCostosEstado = P00625_A482CentroCostosEstado[0];
            A479CentroCostosUsrMod = P00625_A479CentroCostosUsrMod[0];
            A474CentroCostosGam = P00625_A474CentroCostosGam[0];
            A463CentroCostosNombre = P00625_A463CentroCostosNombre[0];
            A462CentroCostosRef = P00625_A462CentroCostosRef[0];
            A487CentroCostosTipoRef = P00625_A487CentroCostosTipoRef[0];
            A461CentroCostosId = P00625_A461CentroCostosId[0];
            A464CentroCostosPrecioFinal = P00625_A464CentroCostosPrecioFinal[0];
            A475CentroCostosCosto = P00625_A475CentroCostosCosto[0];
            A469CentroCostosSubTotal = P00625_A469CentroCostosSubTotal[0];
            n469CentroCostosSubTotal = P00625_n469CentroCostosSubTotal[0];
            A466CentroCostosDetallesId = P00625_A466CentroCostosDetallesId[0];
            A478CentroCostosUsrAlta = P00625_A478CentroCostosUsrAlta[0];
            A481CentroCostosHoraMod = P00625_A481CentroCostosHoraMod[0];
            A480CentroCostosHoraAlt = P00625_A480CentroCostosHoraAlt[0];
            A482CentroCostosEstado = P00625_A482CentroCostosEstado[0];
            A479CentroCostosUsrMod = P00625_A479CentroCostosUsrMod[0];
            A474CentroCostosGam = P00625_A474CentroCostosGam[0];
            A463CentroCostosNombre = P00625_A463CentroCostosNombre[0];
            A462CentroCostosRef = P00625_A462CentroCostosRef[0];
            A487CentroCostosTipoRef = P00625_A487CentroCostosTipoRef[0];
            A464CentroCostosPrecioFinal = P00625_A464CentroCostosPrecioFinal[0];
            A475CentroCostosCosto = P00625_A475CentroCostosCosto[0];
            A469CentroCostosSubTotal = P00625_A469CentroCostosSubTotal[0];
            n469CentroCostosSubTotal = P00625_n469CentroCostosSubTotal[0];
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV59FilterFullText)) || ( ( StringUtil.Like( StringUtil.Str( (decimal)(A461CentroCostosId), 18, 0) , StringUtil.PadR( "%" + AV59FilterFullText , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( context.GetMessage( "servicios", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV59FilterFullText) , 255 , "%"),  ' ' ) &&
            ( StringUtil.StrCmp(A487CentroCostosTipoRef, "S") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "otros", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV59FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A487CentroCostosTipoRef, "O") == 0 ) ) ||
            ( StringUtil.Like( StringUtil.Str( (decimal)(A462CentroCostosRef), 18, 0) , StringUtil.PadR( "%" + AV59FilterFullText , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A463CentroCostosNombre) , StringUtil.PadR( "%" + StringUtil.Upper( AV59FilterFullText) , 255 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Str( A464CentroCostosPrecioFinal, 18, 2) , StringUtil.PadR( "%" + AV59FilterFullText , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Str( A469CentroCostosSubTotal, 18, 2) , StringUtil.PadR( "%" + AV59FilterFullText , 254 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Str( A475CentroCostosCosto, 18, 2) , StringUtil.PadR( "%" + AV59FilterFullText , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Str( A474CentroCostosGam, 18, 2) , StringUtil.PadR( "%" + AV59FilterFullText , 254 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Upper( A478CentroCostosUsrAlta) , StringUtil.PadR( "%" + StringUtil.Upper( AV59FilterFullText) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A479CentroCostosUsrMod) , StringUtil.PadR( "%" + StringUtil.Upper( AV59FilterFullText) , 255 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( context.GetMessage( "aprobado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV59FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A482CentroCostosEstado, "HAB") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "deshabilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV59FilterFullText) , 255 , "%"),  ' ' ) &&
            ( StringUtil.StrCmp(A482CentroCostosEstado, "DES") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "pendiente de aprobación", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV59FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A482CentroCostosEstado, "PND") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "desaprobado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV59FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A482CentroCostosEstado, "DES") == 0 ) ) )
            )
            {
               AV47count = 0;
               while ( (pr_default.getStatus(1) != 101) && ( P00625_A459ListaCostosId[0] == A459ListaCostosId ) && ( StringUtil.StrCmp(P00625_A478CentroCostosUsrAlta[0], A478CentroCostosUsrAlta) == 0 ) )
               {
                  BRK624 = false;
                  A461CentroCostosId = P00625_A461CentroCostosId[0];
                  A466CentroCostosDetallesId = P00625_A466CentroCostosDetallesId[0];
                  AV47count = (long)(AV47count+1);
                  BRK624 = true;
                  pr_default.readNext(1);
               }
               if ( (0==AV38SkipItems) )
               {
                  AV42Option = (String.IsNullOrEmpty(StringUtil.RTrim( A478CentroCostosUsrAlta)) ? "<#Empty#>" : A478CentroCostosUsrAlta);
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
            if ( ! BRK624 )
            {
               BRK624 = true;
               pr_default.readNext(1);
            }
         }
         pr_default.close(1);
      }

      protected void S141( )
      {
         /* 'LOADCENTROCOSTOSUSRMODOPTIONS' Routine */
         returnInSub = false;
         AV29TFCentroCostosUsrMod = AV37SearchTxt;
         AV30TFCentroCostosUsrMod_Sel = "";
         pr_default.dynParam(2, new Object[]{ new Object[]{
                                              A487CentroCostosTipoRef ,
                                              AV14TFCentroCostosTipoRef_Sels ,
                                              A482CentroCostosEstado ,
                                              AV36TFCentroCostosEstado_Sels ,
                                              AV11TFCentroCostosId ,
                                              AV12TFCentroCostosId_To ,
                                              AV14TFCentroCostosTipoRef_Sels.Count ,
                                              AV15TFCentroCostosRef ,
                                              AV16TFCentroCostosRef_To ,
                                              AV18TFCentroCostosNombre_Sel ,
                                              AV17TFCentroCostosNombre ,
                                              AV19TFCentroCostosPrecioFinal ,
                                              AV20TFCentroCostosPrecioFinal_To ,
                                              AV21TFCentroCostosSubTotal ,
                                              AV22TFCentroCostosSubTotal_To ,
                                              AV23TFCentroCostosCosto ,
                                              AV24TFCentroCostosCosto_To ,
                                              AV25TFCentroCostosGam ,
                                              AV26TFCentroCostosGam_To ,
                                              AV28TFCentroCostosUsrAlta_Sel ,
                                              AV27TFCentroCostosUsrAlta ,
                                              AV30TFCentroCostosUsrMod_Sel ,
                                              AV29TFCentroCostosUsrMod ,
                                              AV31TFCentroCostosHoraAlt ,
                                              AV32TFCentroCostosHoraAlt_To ,
                                              AV33TFCentroCostosHoraMod ,
                                              AV34TFCentroCostosHoraMod_To ,
                                              AV36TFCentroCostosEstado_Sels.Count ,
                                              A461CentroCostosId ,
                                              A462CentroCostosRef ,
                                              A463CentroCostosNombre ,
                                              A464CentroCostosPrecioFinal ,
                                              A469CentroCostosSubTotal ,
                                              A475CentroCostosCosto ,
                                              A478CentroCostosUsrAlta ,
                                              A479CentroCostosUsrMod ,
                                              A480CentroCostosHoraAlt ,
                                              A481CentroCostosHoraMod ,
                                              AV59FilterFullText ,
                                              A474CentroCostosGam ,
                                              AV60ListaCostosId ,
                                              A459ListaCostosId } ,
                                              new int[]{
                                              TypeConstants.LONG, TypeConstants.LONG, TypeConstants.INT, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL,
                                              TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.INT, TypeConstants.LONG, TypeConstants.LONG,
                                              TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DECIMAL, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.BOOLEAN
                                              }
         });
         lV17TFCentroCostosNombre = StringUtil.PadR( StringUtil.RTrim( AV17TFCentroCostosNombre), 80, "%");
         lV27TFCentroCostosUsrAlta = StringUtil.PadR( StringUtil.RTrim( AV27TFCentroCostosUsrAlta), 30, "%");
         lV29TFCentroCostosUsrMod = StringUtil.PadR( StringUtil.RTrim( AV29TFCentroCostosUsrMod), 30, "%");
         /* Using cursor P00627 */
         pr_default.execute(2, new Object[] {AV60ListaCostosId, AV11TFCentroCostosId, AV12TFCentroCostosId_To, AV15TFCentroCostosRef, AV16TFCentroCostosRef_To, lV17TFCentroCostosNombre, AV18TFCentroCostosNombre_Sel, AV19TFCentroCostosPrecioFinal, AV20TFCentroCostosPrecioFinal_To, AV21TFCentroCostosSubTotal, AV22TFCentroCostosSubTotal_To, AV23TFCentroCostosCosto, AV24TFCentroCostosCosto_To, AV25TFCentroCostosGam, AV26TFCentroCostosGam_To, lV27TFCentroCostosUsrAlta, AV28TFCentroCostosUsrAlta_Sel, lV29TFCentroCostosUsrMod, AV30TFCentroCostosUsrMod_Sel, AV31TFCentroCostosHoraAlt, AV32TFCentroCostosHoraAlt_To, AV33TFCentroCostosHoraMod, AV34TFCentroCostosHoraMod_To});
         while ( (pr_default.getStatus(2) != 101) )
         {
            BRK626 = false;
            A459ListaCostosId = P00627_A459ListaCostosId[0];
            n459ListaCostosId = P00627_n459ListaCostosId[0];
            A479CentroCostosUsrMod = P00627_A479CentroCostosUsrMod[0];
            A481CentroCostosHoraMod = P00627_A481CentroCostosHoraMod[0];
            A480CentroCostosHoraAlt = P00627_A480CentroCostosHoraAlt[0];
            A482CentroCostosEstado = P00627_A482CentroCostosEstado[0];
            A478CentroCostosUsrAlta = P00627_A478CentroCostosUsrAlta[0];
            A474CentroCostosGam = P00627_A474CentroCostosGam[0];
            A463CentroCostosNombre = P00627_A463CentroCostosNombre[0];
            A462CentroCostosRef = P00627_A462CentroCostosRef[0];
            A487CentroCostosTipoRef = P00627_A487CentroCostosTipoRef[0];
            A461CentroCostosId = P00627_A461CentroCostosId[0];
            A464CentroCostosPrecioFinal = P00627_A464CentroCostosPrecioFinal[0];
            A475CentroCostosCosto = P00627_A475CentroCostosCosto[0];
            A469CentroCostosSubTotal = P00627_A469CentroCostosSubTotal[0];
            n469CentroCostosSubTotal = P00627_n469CentroCostosSubTotal[0];
            A466CentroCostosDetallesId = P00627_A466CentroCostosDetallesId[0];
            A479CentroCostosUsrMod = P00627_A479CentroCostosUsrMod[0];
            A481CentroCostosHoraMod = P00627_A481CentroCostosHoraMod[0];
            A480CentroCostosHoraAlt = P00627_A480CentroCostosHoraAlt[0];
            A482CentroCostosEstado = P00627_A482CentroCostosEstado[0];
            A478CentroCostosUsrAlta = P00627_A478CentroCostosUsrAlta[0];
            A474CentroCostosGam = P00627_A474CentroCostosGam[0];
            A463CentroCostosNombre = P00627_A463CentroCostosNombre[0];
            A462CentroCostosRef = P00627_A462CentroCostosRef[0];
            A487CentroCostosTipoRef = P00627_A487CentroCostosTipoRef[0];
            A464CentroCostosPrecioFinal = P00627_A464CentroCostosPrecioFinal[0];
            A475CentroCostosCosto = P00627_A475CentroCostosCosto[0];
            A469CentroCostosSubTotal = P00627_A469CentroCostosSubTotal[0];
            n469CentroCostosSubTotal = P00627_n469CentroCostosSubTotal[0];
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV59FilterFullText)) || ( ( StringUtil.Like( StringUtil.Str( (decimal)(A461CentroCostosId), 18, 0) , StringUtil.PadR( "%" + AV59FilterFullText , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( context.GetMessage( "servicios", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV59FilterFullText) , 255 , "%"),  ' ' ) &&
            ( StringUtil.StrCmp(A487CentroCostosTipoRef, "S") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "otros", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV59FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A487CentroCostosTipoRef, "O") == 0 ) ) ||
            ( StringUtil.Like( StringUtil.Str( (decimal)(A462CentroCostosRef), 18, 0) , StringUtil.PadR( "%" + AV59FilterFullText , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A463CentroCostosNombre) , StringUtil.PadR( "%" + StringUtil.Upper( AV59FilterFullText) , 255 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Str( A464CentroCostosPrecioFinal, 18, 2) , StringUtil.PadR( "%" + AV59FilterFullText , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Str( A469CentroCostosSubTotal, 18, 2) , StringUtil.PadR( "%" + AV59FilterFullText , 254 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Str( A475CentroCostosCosto, 18, 2) , StringUtil.PadR( "%" + AV59FilterFullText , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Str( A474CentroCostosGam, 18, 2) , StringUtil.PadR( "%" + AV59FilterFullText , 254 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Upper( A478CentroCostosUsrAlta) , StringUtil.PadR( "%" + StringUtil.Upper( AV59FilterFullText) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A479CentroCostosUsrMod) , StringUtil.PadR( "%" + StringUtil.Upper( AV59FilterFullText) , 255 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( context.GetMessage( "aprobado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV59FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A482CentroCostosEstado, "HAB") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "deshabilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV59FilterFullText) , 255 , "%"),  ' ' ) &&
            ( StringUtil.StrCmp(A482CentroCostosEstado, "DES") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "pendiente de aprobación", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV59FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A482CentroCostosEstado, "PND") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "desaprobado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV59FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A482CentroCostosEstado, "DES") == 0 ) ) )
            )
            {
               AV47count = 0;
               while ( (pr_default.getStatus(2) != 101) && ( P00627_A459ListaCostosId[0] == A459ListaCostosId ) && ( StringUtil.StrCmp(P00627_A479CentroCostosUsrMod[0], A479CentroCostosUsrMod) == 0 ) )
               {
                  BRK626 = false;
                  A461CentroCostosId = P00627_A461CentroCostosId[0];
                  A466CentroCostosDetallesId = P00627_A466CentroCostosDetallesId[0];
                  AV47count = (long)(AV47count+1);
                  BRK626 = true;
                  pr_default.readNext(2);
               }
               if ( (0==AV38SkipItems) )
               {
                  AV42Option = (String.IsNullOrEmpty(StringUtil.RTrim( A479CentroCostosUsrMod)) ? "<#Empty#>" : A479CentroCostosUsrMod);
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
            if ( ! BRK626 )
            {
               BRK626 = true;
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
         AV13TFCentroCostosTipoRef_SelsJson = "";
         AV14TFCentroCostosTipoRef_Sels = new GxSimpleCollection<string>();
         AV17TFCentroCostosNombre = "";
         AV18TFCentroCostosNombre_Sel = "";
         AV27TFCentroCostosUsrAlta = "";
         AV28TFCentroCostosUsrAlta_Sel = "";
         AV29TFCentroCostosUsrMod = "";
         AV30TFCentroCostosUsrMod_Sel = "";
         AV31TFCentroCostosHoraAlt = DateTime.MinValue;
         AV32TFCentroCostosHoraAlt_To = DateTime.MinValue;
         AV33TFCentroCostosHoraMod = DateTime.MinValue;
         AV34TFCentroCostosHoraMod_To = DateTime.MinValue;
         AV35TFCentroCostosEstado_SelsJson = "";
         AV36TFCentroCostosEstado_Sels = new GxSimpleCollection<string>();
         lV17TFCentroCostosNombre = "";
         lV27TFCentroCostosUsrAlta = "";
         lV29TFCentroCostosUsrMod = "";
         A487CentroCostosTipoRef = "";
         A482CentroCostosEstado = "";
         A463CentroCostosNombre = "";
         A478CentroCostosUsrAlta = "";
         A479CentroCostosUsrMod = "";
         A480CentroCostosHoraAlt = DateTime.MinValue;
         A481CentroCostosHoraMod = DateTime.MinValue;
         P00623_A459ListaCostosId = new long[1] ;
         P00623_n459ListaCostosId = new bool[] {false} ;
         P00623_A463CentroCostosNombre = new string[] {""} ;
         P00623_A481CentroCostosHoraMod = new DateTime[] {DateTime.MinValue} ;
         P00623_A480CentroCostosHoraAlt = new DateTime[] {DateTime.MinValue} ;
         P00623_A482CentroCostosEstado = new string[] {""} ;
         P00623_A479CentroCostosUsrMod = new string[] {""} ;
         P00623_A478CentroCostosUsrAlta = new string[] {""} ;
         P00623_A474CentroCostosGam = new decimal[1] ;
         P00623_A462CentroCostosRef = new long[1] ;
         P00623_A487CentroCostosTipoRef = new string[] {""} ;
         P00623_A461CentroCostosId = new long[1] ;
         P00623_A464CentroCostosPrecioFinal = new decimal[1] ;
         P00623_A475CentroCostosCosto = new decimal[1] ;
         P00623_A469CentroCostosSubTotal = new decimal[1] ;
         P00623_n469CentroCostosSubTotal = new bool[] {false} ;
         P00623_A466CentroCostosDetallesId = new long[1] ;
         AV42Option = "";
         P00625_A459ListaCostosId = new long[1] ;
         P00625_n459ListaCostosId = new bool[] {false} ;
         P00625_A478CentroCostosUsrAlta = new string[] {""} ;
         P00625_A481CentroCostosHoraMod = new DateTime[] {DateTime.MinValue} ;
         P00625_A480CentroCostosHoraAlt = new DateTime[] {DateTime.MinValue} ;
         P00625_A482CentroCostosEstado = new string[] {""} ;
         P00625_A479CentroCostosUsrMod = new string[] {""} ;
         P00625_A474CentroCostosGam = new decimal[1] ;
         P00625_A463CentroCostosNombre = new string[] {""} ;
         P00625_A462CentroCostosRef = new long[1] ;
         P00625_A487CentroCostosTipoRef = new string[] {""} ;
         P00625_A461CentroCostosId = new long[1] ;
         P00625_A464CentroCostosPrecioFinal = new decimal[1] ;
         P00625_A475CentroCostosCosto = new decimal[1] ;
         P00625_A469CentroCostosSubTotal = new decimal[1] ;
         P00625_n469CentroCostosSubTotal = new bool[] {false} ;
         P00625_A466CentroCostosDetallesId = new long[1] ;
         P00627_A459ListaCostosId = new long[1] ;
         P00627_n459ListaCostosId = new bool[] {false} ;
         P00627_A479CentroCostosUsrMod = new string[] {""} ;
         P00627_A481CentroCostosHoraMod = new DateTime[] {DateTime.MinValue} ;
         P00627_A480CentroCostosHoraAlt = new DateTime[] {DateTime.MinValue} ;
         P00627_A482CentroCostosEstado = new string[] {""} ;
         P00627_A478CentroCostosUsrAlta = new string[] {""} ;
         P00627_A474CentroCostosGam = new decimal[1] ;
         P00627_A463CentroCostosNombre = new string[] {""} ;
         P00627_A462CentroCostosRef = new long[1] ;
         P00627_A487CentroCostosTipoRef = new string[] {""} ;
         P00627_A461CentroCostosId = new long[1] ;
         P00627_A464CentroCostosPrecioFinal = new decimal[1] ;
         P00627_A475CentroCostosCosto = new decimal[1] ;
         P00627_A469CentroCostosSubTotal = new decimal[1] ;
         P00627_n469CentroCostosSubTotal = new bool[] {false} ;
         P00627_A466CentroCostosDetallesId = new long[1] ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.listacostosdetalles1wcgetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P00623_A459ListaCostosId, P00623_n459ListaCostosId, P00623_A463CentroCostosNombre, P00623_A481CentroCostosHoraMod, P00623_A480CentroCostosHoraAlt, P00623_A482CentroCostosEstado, P00623_A479CentroCostosUsrMod, P00623_A478CentroCostosUsrAlta, P00623_A474CentroCostosGam, P00623_A462CentroCostosRef,
               P00623_A487CentroCostosTipoRef, P00623_A461CentroCostosId, P00623_A464CentroCostosPrecioFinal, P00623_A475CentroCostosCosto, P00623_A469CentroCostosSubTotal, P00623_n469CentroCostosSubTotal, P00623_A466CentroCostosDetallesId
               }
               , new Object[] {
               P00625_A459ListaCostosId, P00625_n459ListaCostosId, P00625_A478CentroCostosUsrAlta, P00625_A481CentroCostosHoraMod, P00625_A480CentroCostosHoraAlt, P00625_A482CentroCostosEstado, P00625_A479CentroCostosUsrMod, P00625_A474CentroCostosGam, P00625_A463CentroCostosNombre, P00625_A462CentroCostosRef,
               P00625_A487CentroCostosTipoRef, P00625_A461CentroCostosId, P00625_A464CentroCostosPrecioFinal, P00625_A475CentroCostosCosto, P00625_A469CentroCostosSubTotal, P00625_n469CentroCostosSubTotal, P00625_A466CentroCostosDetallesId
               }
               , new Object[] {
               P00627_A459ListaCostosId, P00627_n459ListaCostosId, P00627_A479CentroCostosUsrMod, P00627_A481CentroCostosHoraMod, P00627_A480CentroCostosHoraAlt, P00627_A482CentroCostosEstado, P00627_A478CentroCostosUsrAlta, P00627_A474CentroCostosGam, P00627_A463CentroCostosNombre, P00627_A462CentroCostosRef,
               P00627_A487CentroCostosTipoRef, P00627_A461CentroCostosId, P00627_A464CentroCostosPrecioFinal, P00627_A475CentroCostosCosto, P00627_A469CentroCostosSubTotal, P00627_n469CentroCostosSubTotal, P00627_A466CentroCostosDetallesId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV40MaxItems ;
      private short AV39PageIndex ;
      private short AV38SkipItems ;
      private int AV61GXV1 ;
      private int AV14TFCentroCostosTipoRef_Sels_Count ;
      private int AV36TFCentroCostosEstado_Sels_Count ;
      private long AV11TFCentroCostosId ;
      private long AV12TFCentroCostosId_To ;
      private long AV15TFCentroCostosRef ;
      private long AV16TFCentroCostosRef_To ;
      private long AV60ListaCostosId ;
      private long A461CentroCostosId ;
      private long A462CentroCostosRef ;
      private long A459ListaCostosId ;
      private long A466CentroCostosDetallesId ;
      private long AV47count ;
      private decimal AV19TFCentroCostosPrecioFinal ;
      private decimal AV20TFCentroCostosPrecioFinal_To ;
      private decimal AV21TFCentroCostosSubTotal ;
      private decimal AV22TFCentroCostosSubTotal_To ;
      private decimal AV23TFCentroCostosCosto ;
      private decimal AV24TFCentroCostosCosto_To ;
      private decimal AV25TFCentroCostosGam ;
      private decimal AV26TFCentroCostosGam_To ;
      private decimal A464CentroCostosPrecioFinal ;
      private decimal A469CentroCostosSubTotal ;
      private decimal A475CentroCostosCosto ;
      private decimal A474CentroCostosGam ;
      private string AV17TFCentroCostosNombre ;
      private string AV18TFCentroCostosNombre_Sel ;
      private string AV27TFCentroCostosUsrAlta ;
      private string AV28TFCentroCostosUsrAlta_Sel ;
      private string AV29TFCentroCostosUsrMod ;
      private string AV30TFCentroCostosUsrMod_Sel ;
      private string lV17TFCentroCostosNombre ;
      private string lV27TFCentroCostosUsrAlta ;
      private string lV29TFCentroCostosUsrMod ;
      private string A487CentroCostosTipoRef ;
      private string A482CentroCostosEstado ;
      private string A463CentroCostosNombre ;
      private string A478CentroCostosUsrAlta ;
      private string A479CentroCostosUsrMod ;
      private DateTime AV31TFCentroCostosHoraAlt ;
      private DateTime AV32TFCentroCostosHoraAlt_To ;
      private DateTime AV33TFCentroCostosHoraMod ;
      private DateTime AV34TFCentroCostosHoraMod_To ;
      private DateTime A480CentroCostosHoraAlt ;
      private DateTime A481CentroCostosHoraMod ;
      private bool AV8IsAuthorized ;
      private bool GXt_boolean1 ;
      private bool returnInSub ;
      private bool BRK622 ;
      private bool n459ListaCostosId ;
      private bool n469CentroCostosSubTotal ;
      private bool BRK624 ;
      private bool BRK626 ;
      private string AV56OptionsJson ;
      private string AV57OptionsDescJson ;
      private string AV58OptionIndexesJson ;
      private string AV13TFCentroCostosTipoRef_SelsJson ;
      private string AV35TFCentroCostosEstado_SelsJson ;
      private string AV53DDOName ;
      private string AV54SearchTxtParms ;
      private string AV55SearchTxtTo ;
      private string AV37SearchTxt ;
      private string AV59FilterFullText ;
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
      private GxSimpleCollection<string> AV14TFCentroCostosTipoRef_Sels ;
      private GxSimpleCollection<string> AV36TFCentroCostosEstado_Sels ;
      private IDataStoreProvider pr_default ;
      private long[] P00623_A459ListaCostosId ;
      private bool[] P00623_n459ListaCostosId ;
      private string[] P00623_A463CentroCostosNombre ;
      private DateTime[] P00623_A481CentroCostosHoraMod ;
      private DateTime[] P00623_A480CentroCostosHoraAlt ;
      private string[] P00623_A482CentroCostosEstado ;
      private string[] P00623_A479CentroCostosUsrMod ;
      private string[] P00623_A478CentroCostosUsrAlta ;
      private decimal[] P00623_A474CentroCostosGam ;
      private long[] P00623_A462CentroCostosRef ;
      private string[] P00623_A487CentroCostosTipoRef ;
      private long[] P00623_A461CentroCostosId ;
      private decimal[] P00623_A464CentroCostosPrecioFinal ;
      private decimal[] P00623_A475CentroCostosCosto ;
      private decimal[] P00623_A469CentroCostosSubTotal ;
      private bool[] P00623_n469CentroCostosSubTotal ;
      private long[] P00623_A466CentroCostosDetallesId ;
      private long[] P00625_A459ListaCostosId ;
      private bool[] P00625_n459ListaCostosId ;
      private string[] P00625_A478CentroCostosUsrAlta ;
      private DateTime[] P00625_A481CentroCostosHoraMod ;
      private DateTime[] P00625_A480CentroCostosHoraAlt ;
      private string[] P00625_A482CentroCostosEstado ;
      private string[] P00625_A479CentroCostosUsrMod ;
      private decimal[] P00625_A474CentroCostosGam ;
      private string[] P00625_A463CentroCostosNombre ;
      private long[] P00625_A462CentroCostosRef ;
      private string[] P00625_A487CentroCostosTipoRef ;
      private long[] P00625_A461CentroCostosId ;
      private decimal[] P00625_A464CentroCostosPrecioFinal ;
      private decimal[] P00625_A475CentroCostosCosto ;
      private decimal[] P00625_A469CentroCostosSubTotal ;
      private bool[] P00625_n469CentroCostosSubTotal ;
      private long[] P00625_A466CentroCostosDetallesId ;
      private long[] P00627_A459ListaCostosId ;
      private bool[] P00627_n459ListaCostosId ;
      private string[] P00627_A479CentroCostosUsrMod ;
      private DateTime[] P00627_A481CentroCostosHoraMod ;
      private DateTime[] P00627_A480CentroCostosHoraAlt ;
      private string[] P00627_A482CentroCostosEstado ;
      private string[] P00627_A478CentroCostosUsrAlta ;
      private decimal[] P00627_A474CentroCostosGam ;
      private string[] P00627_A463CentroCostosNombre ;
      private long[] P00627_A462CentroCostosRef ;
      private string[] P00627_A487CentroCostosTipoRef ;
      private long[] P00627_A461CentroCostosId ;
      private decimal[] P00627_A464CentroCostosPrecioFinal ;
      private decimal[] P00627_A475CentroCostosCosto ;
      private decimal[] P00627_A469CentroCostosSubTotal ;
      private bool[] P00627_n469CentroCostosSubTotal ;
      private long[] P00627_A466CentroCostosDetallesId ;
      private string aP3_OptionsJson ;
      private string aP4_OptionsDescJson ;
      private string aP5_OptionIndexesJson ;
   }

   public class listacostosdetalles1wcgetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00623( IGxContext context ,
                                             string A487CentroCostosTipoRef ,
                                             GxSimpleCollection<string> AV14TFCentroCostosTipoRef_Sels ,
                                             string A482CentroCostosEstado ,
                                             GxSimpleCollection<string> AV36TFCentroCostosEstado_Sels ,
                                             long AV11TFCentroCostosId ,
                                             long AV12TFCentroCostosId_To ,
                                             int AV14TFCentroCostosTipoRef_Sels_Count ,
                                             long AV15TFCentroCostosRef ,
                                             long AV16TFCentroCostosRef_To ,
                                             string AV18TFCentroCostosNombre_Sel ,
                                             string AV17TFCentroCostosNombre ,
                                             decimal AV19TFCentroCostosPrecioFinal ,
                                             decimal AV20TFCentroCostosPrecioFinal_To ,
                                             decimal AV21TFCentroCostosSubTotal ,
                                             decimal AV22TFCentroCostosSubTotal_To ,
                                             decimal AV23TFCentroCostosCosto ,
                                             decimal AV24TFCentroCostosCosto_To ,
                                             decimal AV25TFCentroCostosGam ,
                                             decimal AV26TFCentroCostosGam_To ,
                                             string AV28TFCentroCostosUsrAlta_Sel ,
                                             string AV27TFCentroCostosUsrAlta ,
                                             string AV30TFCentroCostosUsrMod_Sel ,
                                             string AV29TFCentroCostosUsrMod ,
                                             DateTime AV31TFCentroCostosHoraAlt ,
                                             DateTime AV32TFCentroCostosHoraAlt_To ,
                                             DateTime AV33TFCentroCostosHoraMod ,
                                             DateTime AV34TFCentroCostosHoraMod_To ,
                                             int AV36TFCentroCostosEstado_Sels_Count ,
                                             long A461CentroCostosId ,
                                             long A462CentroCostosRef ,
                                             string A463CentroCostosNombre ,
                                             decimal A464CentroCostosPrecioFinal ,
                                             decimal A469CentroCostosSubTotal ,
                                             decimal A475CentroCostosCosto ,
                                             string A478CentroCostosUsrAlta ,
                                             string A479CentroCostosUsrMod ,
                                             DateTime A480CentroCostosHoraAlt ,
                                             DateTime A481CentroCostosHoraMod ,
                                             string AV59FilterFullText ,
                                             decimal A474CentroCostosGam ,
                                             long AV60ListaCostosId ,
                                             long A459ListaCostosId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int2 = new short[23];
         Object[] GXv_Object3 = new Object[2];
         scmdbuf = "SELECT T1.[ListaCostosId], T2.[CentroCostosNombre], T2.[CentroCostosHoraMod], T2.[CentroCostosHoraAlt], T2.[CentroCostosEstado], T2.[CentroCostosUsrMod], T2.[CentroCostosUsrAlta], T2.[CentroCostosPrecioFinal] - T2.[CentroCostosCosto] AS CentroCostosGam, T2.[CentroCostosRef], T2.[CentroCostosTipoRef], T1.[CentroCostosId], T2.[CentroCostosPrecioFinal], T2.[CentroCostosCosto], COALESCE( T3.[CentroCostosSubTotal], 0) AS CentroCostosSubTotal, T1.[CentroCostosDetallesId] FROM (([CentroCostosDetalles] T1 INNER JOIN [CentroCostos] T2 ON T2.[CentroCostosId] = T1.[CentroCostosId]) LEFT JOIN (SELECT SUM([CentroCostosDetallesValor]) AS CentroCostosSubTotal, [CentroCostosId] FROM [CentroCostosDetalles] GROUP BY [CentroCostosId] ) T3 ON T3.[CentroCostosId] = T1.[CentroCostosId])";
         AddWhere(sWhereString, "(T1.[ListaCostosId] = @AV60ListaCostosId)");
         if ( ! (0==AV11TFCentroCostosId) )
         {
            AddWhere(sWhereString, "(T1.[CentroCostosId] >= @AV11TFCentroCostosId)");
         }
         else
         {
            GXv_int2[1] = 1;
         }
         if ( ! (0==AV12TFCentroCostosId_To) )
         {
            AddWhere(sWhereString, "(T1.[CentroCostosId] <= @AV12TFCentroCostosId_To)");
         }
         else
         {
            GXv_int2[2] = 1;
         }
         if ( AV14TFCentroCostosTipoRef_Sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV14TFCentroCostosTipoRef_Sels, "T2.[CentroCostosTipoRef] IN (", ")")+")");
         }
         if ( ! (0==AV15TFCentroCostosRef) )
         {
            AddWhere(sWhereString, "(T2.[CentroCostosRef] >= @AV15TFCentroCostosRef)");
         }
         else
         {
            GXv_int2[3] = 1;
         }
         if ( ! (0==AV16TFCentroCostosRef_To) )
         {
            AddWhere(sWhereString, "(T2.[CentroCostosRef] <= @AV16TFCentroCostosRef_To)");
         }
         else
         {
            GXv_int2[4] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV18TFCentroCostosNombre_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV17TFCentroCostosNombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[CentroCostosNombre]) like UPPER(@lV17TFCentroCostosNombre))");
         }
         else
         {
            GXv_int2[5] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV18TFCentroCostosNombre_Sel)) && ! ( StringUtil.StrCmp(AV18TFCentroCostosNombre_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.[CentroCostosNombre] = @AV18TFCentroCostosNombre_Sel)");
         }
         else
         {
            GXv_int2[6] = 1;
         }
         if ( StringUtil.StrCmp(AV18TFCentroCostosNombre_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T2.[CentroCostosNombre] = ''))");
         }
         if ( ! (Convert.ToDecimal(0)==AV19TFCentroCostosPrecioFinal) )
         {
            AddWhere(sWhereString, "(T2.[CentroCostosPrecioFinal] >= @AV19TFCentroCostosPrecioFinal)");
         }
         else
         {
            GXv_int2[7] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV20TFCentroCostosPrecioFinal_To) )
         {
            AddWhere(sWhereString, "(T2.[CentroCostosPrecioFinal] <= @AV20TFCentroCostosPrecioFinal_To)");
         }
         else
         {
            GXv_int2[8] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV21TFCentroCostosSubTotal) )
         {
            AddWhere(sWhereString, "(COALESCE( T3.[CentroCostosSubTotal], 0) >= @AV21TFCentroCostosSubTotal)");
         }
         else
         {
            GXv_int2[9] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV22TFCentroCostosSubTotal_To) )
         {
            AddWhere(sWhereString, "(COALESCE( T3.[CentroCostosSubTotal], 0) <= @AV22TFCentroCostosSubTotal_To)");
         }
         else
         {
            GXv_int2[10] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV23TFCentroCostosCosto) )
         {
            AddWhere(sWhereString, "(T2.[CentroCostosCosto] >= @AV23TFCentroCostosCosto)");
         }
         else
         {
            GXv_int2[11] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV24TFCentroCostosCosto_To) )
         {
            AddWhere(sWhereString, "(T2.[CentroCostosCosto] <= @AV24TFCentroCostosCosto_To)");
         }
         else
         {
            GXv_int2[12] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV25TFCentroCostosGam) )
         {
            AddWhere(sWhereString, "(( T2.[CentroCostosPrecioFinal] - T2.[CentroCostosCosto]) >= @AV25TFCentroCostosGam)");
         }
         else
         {
            GXv_int2[13] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV26TFCentroCostosGam_To) )
         {
            AddWhere(sWhereString, "(( T2.[CentroCostosPrecioFinal] - T2.[CentroCostosCosto]) <= @AV26TFCentroCostosGam_To)");
         }
         else
         {
            GXv_int2[14] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV28TFCentroCostosUsrAlta_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV27TFCentroCostosUsrAlta)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[CentroCostosUsrAlta]) like UPPER(@lV27TFCentroCostosUsrAlta))");
         }
         else
         {
            GXv_int2[15] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV28TFCentroCostosUsrAlta_Sel)) && ! ( StringUtil.StrCmp(AV28TFCentroCostosUsrAlta_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.[CentroCostosUsrAlta] = @AV28TFCentroCostosUsrAlta_Sel)");
         }
         else
         {
            GXv_int2[16] = 1;
         }
         if ( StringUtil.StrCmp(AV28TFCentroCostosUsrAlta_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T2.[CentroCostosUsrAlta] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV30TFCentroCostosUsrMod_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV29TFCentroCostosUsrMod)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[CentroCostosUsrMod]) like UPPER(@lV29TFCentroCostosUsrMod))");
         }
         else
         {
            GXv_int2[17] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV30TFCentroCostosUsrMod_Sel)) && ! ( StringUtil.StrCmp(AV30TFCentroCostosUsrMod_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.[CentroCostosUsrMod] = @AV30TFCentroCostosUsrMod_Sel)");
         }
         else
         {
            GXv_int2[18] = 1;
         }
         if ( StringUtil.StrCmp(AV30TFCentroCostosUsrMod_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T2.[CentroCostosUsrMod] = ''))");
         }
         if ( ! (DateTime.MinValue==AV31TFCentroCostosHoraAlt) )
         {
            AddWhere(sWhereString, "(T2.[CentroCostosHoraAlt] >= @AV31TFCentroCostosHoraAlt)");
         }
         else
         {
            GXv_int2[19] = 1;
         }
         if ( ! (DateTime.MinValue==AV32TFCentroCostosHoraAlt_To) )
         {
            AddWhere(sWhereString, "(T2.[CentroCostosHoraAlt] <= @AV32TFCentroCostosHoraAlt_To)");
         }
         else
         {
            GXv_int2[20] = 1;
         }
         if ( ! (DateTime.MinValue==AV33TFCentroCostosHoraMod) )
         {
            AddWhere(sWhereString, "(T2.[CentroCostosHoraMod] >= @AV33TFCentroCostosHoraMod)");
         }
         else
         {
            GXv_int2[21] = 1;
         }
         if ( ! (DateTime.MinValue==AV34TFCentroCostosHoraMod_To) )
         {
            AddWhere(sWhereString, "(T2.[CentroCostosHoraMod] <= @AV34TFCentroCostosHoraMod_To)");
         }
         else
         {
            GXv_int2[22] = 1;
         }
         if ( AV36TFCentroCostosEstado_Sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV36TFCentroCostosEstado_Sels, "T2.[CentroCostosEstado] IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[ListaCostosId], T2.[CentroCostosNombre]";
         GXv_Object3[0] = scmdbuf;
         GXv_Object3[1] = GXv_int2;
         return GXv_Object3 ;
      }

      protected Object[] conditional_P00625( IGxContext context ,
                                             string A487CentroCostosTipoRef ,
                                             GxSimpleCollection<string> AV14TFCentroCostosTipoRef_Sels ,
                                             string A482CentroCostosEstado ,
                                             GxSimpleCollection<string> AV36TFCentroCostosEstado_Sels ,
                                             long AV11TFCentroCostosId ,
                                             long AV12TFCentroCostosId_To ,
                                             int AV14TFCentroCostosTipoRef_Sels_Count ,
                                             long AV15TFCentroCostosRef ,
                                             long AV16TFCentroCostosRef_To ,
                                             string AV18TFCentroCostosNombre_Sel ,
                                             string AV17TFCentroCostosNombre ,
                                             decimal AV19TFCentroCostosPrecioFinal ,
                                             decimal AV20TFCentroCostosPrecioFinal_To ,
                                             decimal AV21TFCentroCostosSubTotal ,
                                             decimal AV22TFCentroCostosSubTotal_To ,
                                             decimal AV23TFCentroCostosCosto ,
                                             decimal AV24TFCentroCostosCosto_To ,
                                             decimal AV25TFCentroCostosGam ,
                                             decimal AV26TFCentroCostosGam_To ,
                                             string AV28TFCentroCostosUsrAlta_Sel ,
                                             string AV27TFCentroCostosUsrAlta ,
                                             string AV30TFCentroCostosUsrMod_Sel ,
                                             string AV29TFCentroCostosUsrMod ,
                                             DateTime AV31TFCentroCostosHoraAlt ,
                                             DateTime AV32TFCentroCostosHoraAlt_To ,
                                             DateTime AV33TFCentroCostosHoraMod ,
                                             DateTime AV34TFCentroCostosHoraMod_To ,
                                             int AV36TFCentroCostosEstado_Sels_Count ,
                                             long A461CentroCostosId ,
                                             long A462CentroCostosRef ,
                                             string A463CentroCostosNombre ,
                                             decimal A464CentroCostosPrecioFinal ,
                                             decimal A469CentroCostosSubTotal ,
                                             decimal A475CentroCostosCosto ,
                                             string A478CentroCostosUsrAlta ,
                                             string A479CentroCostosUsrMod ,
                                             DateTime A480CentroCostosHoraAlt ,
                                             DateTime A481CentroCostosHoraMod ,
                                             string AV59FilterFullText ,
                                             decimal A474CentroCostosGam ,
                                             long AV60ListaCostosId ,
                                             long A459ListaCostosId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int4 = new short[23];
         Object[] GXv_Object5 = new Object[2];
         scmdbuf = "SELECT T1.[ListaCostosId], T2.[CentroCostosUsrAlta], T2.[CentroCostosHoraMod], T2.[CentroCostosHoraAlt], T2.[CentroCostosEstado], T2.[CentroCostosUsrMod], T2.[CentroCostosPrecioFinal] - T2.[CentroCostosCosto] AS CentroCostosGam, T2.[CentroCostosNombre], T2.[CentroCostosRef], T2.[CentroCostosTipoRef], T1.[CentroCostosId], T2.[CentroCostosPrecioFinal], T2.[CentroCostosCosto], COALESCE( T3.[CentroCostosSubTotal], 0) AS CentroCostosSubTotal, T1.[CentroCostosDetallesId] FROM (([CentroCostosDetalles] T1 INNER JOIN [CentroCostos] T2 ON T2.[CentroCostosId] = T1.[CentroCostosId]) LEFT JOIN (SELECT SUM([CentroCostosDetallesValor]) AS CentroCostosSubTotal, [CentroCostosId] FROM [CentroCostosDetalles] GROUP BY [CentroCostosId] ) T3 ON T3.[CentroCostosId] = T1.[CentroCostosId])";
         AddWhere(sWhereString, "(T1.[ListaCostosId] = @AV60ListaCostosId)");
         if ( ! (0==AV11TFCentroCostosId) )
         {
            AddWhere(sWhereString, "(T1.[CentroCostosId] >= @AV11TFCentroCostosId)");
         }
         else
         {
            GXv_int4[1] = 1;
         }
         if ( ! (0==AV12TFCentroCostosId_To) )
         {
            AddWhere(sWhereString, "(T1.[CentroCostosId] <= @AV12TFCentroCostosId_To)");
         }
         else
         {
            GXv_int4[2] = 1;
         }
         if ( AV14TFCentroCostosTipoRef_Sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV14TFCentroCostosTipoRef_Sels, "T2.[CentroCostosTipoRef] IN (", ")")+")");
         }
         if ( ! (0==AV15TFCentroCostosRef) )
         {
            AddWhere(sWhereString, "(T2.[CentroCostosRef] >= @AV15TFCentroCostosRef)");
         }
         else
         {
            GXv_int4[3] = 1;
         }
         if ( ! (0==AV16TFCentroCostosRef_To) )
         {
            AddWhere(sWhereString, "(T2.[CentroCostosRef] <= @AV16TFCentroCostosRef_To)");
         }
         else
         {
            GXv_int4[4] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV18TFCentroCostosNombre_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV17TFCentroCostosNombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[CentroCostosNombre]) like UPPER(@lV17TFCentroCostosNombre))");
         }
         else
         {
            GXv_int4[5] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV18TFCentroCostosNombre_Sel)) && ! ( StringUtil.StrCmp(AV18TFCentroCostosNombre_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.[CentroCostosNombre] = @AV18TFCentroCostosNombre_Sel)");
         }
         else
         {
            GXv_int4[6] = 1;
         }
         if ( StringUtil.StrCmp(AV18TFCentroCostosNombre_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T2.[CentroCostosNombre] = ''))");
         }
         if ( ! (Convert.ToDecimal(0)==AV19TFCentroCostosPrecioFinal) )
         {
            AddWhere(sWhereString, "(T2.[CentroCostosPrecioFinal] >= @AV19TFCentroCostosPrecioFinal)");
         }
         else
         {
            GXv_int4[7] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV20TFCentroCostosPrecioFinal_To) )
         {
            AddWhere(sWhereString, "(T2.[CentroCostosPrecioFinal] <= @AV20TFCentroCostosPrecioFinal_To)");
         }
         else
         {
            GXv_int4[8] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV21TFCentroCostosSubTotal) )
         {
            AddWhere(sWhereString, "(COALESCE( T3.[CentroCostosSubTotal], 0) >= @AV21TFCentroCostosSubTotal)");
         }
         else
         {
            GXv_int4[9] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV22TFCentroCostosSubTotal_To) )
         {
            AddWhere(sWhereString, "(COALESCE( T3.[CentroCostosSubTotal], 0) <= @AV22TFCentroCostosSubTotal_To)");
         }
         else
         {
            GXv_int4[10] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV23TFCentroCostosCosto) )
         {
            AddWhere(sWhereString, "(T2.[CentroCostosCosto] >= @AV23TFCentroCostosCosto)");
         }
         else
         {
            GXv_int4[11] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV24TFCentroCostosCosto_To) )
         {
            AddWhere(sWhereString, "(T2.[CentroCostosCosto] <= @AV24TFCentroCostosCosto_To)");
         }
         else
         {
            GXv_int4[12] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV25TFCentroCostosGam) )
         {
            AddWhere(sWhereString, "(( T2.[CentroCostosPrecioFinal] - T2.[CentroCostosCosto]) >= @AV25TFCentroCostosGam)");
         }
         else
         {
            GXv_int4[13] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV26TFCentroCostosGam_To) )
         {
            AddWhere(sWhereString, "(( T2.[CentroCostosPrecioFinal] - T2.[CentroCostosCosto]) <= @AV26TFCentroCostosGam_To)");
         }
         else
         {
            GXv_int4[14] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV28TFCentroCostosUsrAlta_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV27TFCentroCostosUsrAlta)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[CentroCostosUsrAlta]) like UPPER(@lV27TFCentroCostosUsrAlta))");
         }
         else
         {
            GXv_int4[15] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV28TFCentroCostosUsrAlta_Sel)) && ! ( StringUtil.StrCmp(AV28TFCentroCostosUsrAlta_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.[CentroCostosUsrAlta] = @AV28TFCentroCostosUsrAlta_Sel)");
         }
         else
         {
            GXv_int4[16] = 1;
         }
         if ( StringUtil.StrCmp(AV28TFCentroCostosUsrAlta_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T2.[CentroCostosUsrAlta] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV30TFCentroCostosUsrMod_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV29TFCentroCostosUsrMod)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[CentroCostosUsrMod]) like UPPER(@lV29TFCentroCostosUsrMod))");
         }
         else
         {
            GXv_int4[17] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV30TFCentroCostosUsrMod_Sel)) && ! ( StringUtil.StrCmp(AV30TFCentroCostosUsrMod_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.[CentroCostosUsrMod] = @AV30TFCentroCostosUsrMod_Sel)");
         }
         else
         {
            GXv_int4[18] = 1;
         }
         if ( StringUtil.StrCmp(AV30TFCentroCostosUsrMod_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T2.[CentroCostosUsrMod] = ''))");
         }
         if ( ! (DateTime.MinValue==AV31TFCentroCostosHoraAlt) )
         {
            AddWhere(sWhereString, "(T2.[CentroCostosHoraAlt] >= @AV31TFCentroCostosHoraAlt)");
         }
         else
         {
            GXv_int4[19] = 1;
         }
         if ( ! (DateTime.MinValue==AV32TFCentroCostosHoraAlt_To) )
         {
            AddWhere(sWhereString, "(T2.[CentroCostosHoraAlt] <= @AV32TFCentroCostosHoraAlt_To)");
         }
         else
         {
            GXv_int4[20] = 1;
         }
         if ( ! (DateTime.MinValue==AV33TFCentroCostosHoraMod) )
         {
            AddWhere(sWhereString, "(T2.[CentroCostosHoraMod] >= @AV33TFCentroCostosHoraMod)");
         }
         else
         {
            GXv_int4[21] = 1;
         }
         if ( ! (DateTime.MinValue==AV34TFCentroCostosHoraMod_To) )
         {
            AddWhere(sWhereString, "(T2.[CentroCostosHoraMod] <= @AV34TFCentroCostosHoraMod_To)");
         }
         else
         {
            GXv_int4[22] = 1;
         }
         if ( AV36TFCentroCostosEstado_Sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV36TFCentroCostosEstado_Sels, "T2.[CentroCostosEstado] IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[ListaCostosId], T2.[CentroCostosUsrAlta]";
         GXv_Object5[0] = scmdbuf;
         GXv_Object5[1] = GXv_int4;
         return GXv_Object5 ;
      }

      protected Object[] conditional_P00627( IGxContext context ,
                                             string A487CentroCostosTipoRef ,
                                             GxSimpleCollection<string> AV14TFCentroCostosTipoRef_Sels ,
                                             string A482CentroCostosEstado ,
                                             GxSimpleCollection<string> AV36TFCentroCostosEstado_Sels ,
                                             long AV11TFCentroCostosId ,
                                             long AV12TFCentroCostosId_To ,
                                             int AV14TFCentroCostosTipoRef_Sels_Count ,
                                             long AV15TFCentroCostosRef ,
                                             long AV16TFCentroCostosRef_To ,
                                             string AV18TFCentroCostosNombre_Sel ,
                                             string AV17TFCentroCostosNombre ,
                                             decimal AV19TFCentroCostosPrecioFinal ,
                                             decimal AV20TFCentroCostosPrecioFinal_To ,
                                             decimal AV21TFCentroCostosSubTotal ,
                                             decimal AV22TFCentroCostosSubTotal_To ,
                                             decimal AV23TFCentroCostosCosto ,
                                             decimal AV24TFCentroCostosCosto_To ,
                                             decimal AV25TFCentroCostosGam ,
                                             decimal AV26TFCentroCostosGam_To ,
                                             string AV28TFCentroCostosUsrAlta_Sel ,
                                             string AV27TFCentroCostosUsrAlta ,
                                             string AV30TFCentroCostosUsrMod_Sel ,
                                             string AV29TFCentroCostosUsrMod ,
                                             DateTime AV31TFCentroCostosHoraAlt ,
                                             DateTime AV32TFCentroCostosHoraAlt_To ,
                                             DateTime AV33TFCentroCostosHoraMod ,
                                             DateTime AV34TFCentroCostosHoraMod_To ,
                                             int AV36TFCentroCostosEstado_Sels_Count ,
                                             long A461CentroCostosId ,
                                             long A462CentroCostosRef ,
                                             string A463CentroCostosNombre ,
                                             decimal A464CentroCostosPrecioFinal ,
                                             decimal A469CentroCostosSubTotal ,
                                             decimal A475CentroCostosCosto ,
                                             string A478CentroCostosUsrAlta ,
                                             string A479CentroCostosUsrMod ,
                                             DateTime A480CentroCostosHoraAlt ,
                                             DateTime A481CentroCostosHoraMod ,
                                             string AV59FilterFullText ,
                                             decimal A474CentroCostosGam ,
                                             long AV60ListaCostosId ,
                                             long A459ListaCostosId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int6 = new short[23];
         Object[] GXv_Object7 = new Object[2];
         scmdbuf = "SELECT T1.[ListaCostosId], T2.[CentroCostosUsrMod], T2.[CentroCostosHoraMod], T2.[CentroCostosHoraAlt], T2.[CentroCostosEstado], T2.[CentroCostosUsrAlta], T2.[CentroCostosPrecioFinal] - T2.[CentroCostosCosto] AS CentroCostosGam, T2.[CentroCostosNombre], T2.[CentroCostosRef], T2.[CentroCostosTipoRef], T1.[CentroCostosId], T2.[CentroCostosPrecioFinal], T2.[CentroCostosCosto], COALESCE( T3.[CentroCostosSubTotal], 0) AS CentroCostosSubTotal, T1.[CentroCostosDetallesId] FROM (([CentroCostosDetalles] T1 INNER JOIN [CentroCostos] T2 ON T2.[CentroCostosId] = T1.[CentroCostosId]) LEFT JOIN (SELECT SUM([CentroCostosDetallesValor]) AS CentroCostosSubTotal, [CentroCostosId] FROM [CentroCostosDetalles] GROUP BY [CentroCostosId] ) T3 ON T3.[CentroCostosId] = T1.[CentroCostosId])";
         AddWhere(sWhereString, "(T1.[ListaCostosId] = @AV60ListaCostosId)");
         if ( ! (0==AV11TFCentroCostosId) )
         {
            AddWhere(sWhereString, "(T1.[CentroCostosId] >= @AV11TFCentroCostosId)");
         }
         else
         {
            GXv_int6[1] = 1;
         }
         if ( ! (0==AV12TFCentroCostosId_To) )
         {
            AddWhere(sWhereString, "(T1.[CentroCostosId] <= @AV12TFCentroCostosId_To)");
         }
         else
         {
            GXv_int6[2] = 1;
         }
         if ( AV14TFCentroCostosTipoRef_Sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV14TFCentroCostosTipoRef_Sels, "T2.[CentroCostosTipoRef] IN (", ")")+")");
         }
         if ( ! (0==AV15TFCentroCostosRef) )
         {
            AddWhere(sWhereString, "(T2.[CentroCostosRef] >= @AV15TFCentroCostosRef)");
         }
         else
         {
            GXv_int6[3] = 1;
         }
         if ( ! (0==AV16TFCentroCostosRef_To) )
         {
            AddWhere(sWhereString, "(T2.[CentroCostosRef] <= @AV16TFCentroCostosRef_To)");
         }
         else
         {
            GXv_int6[4] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV18TFCentroCostosNombre_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV17TFCentroCostosNombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[CentroCostosNombre]) like UPPER(@lV17TFCentroCostosNombre))");
         }
         else
         {
            GXv_int6[5] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV18TFCentroCostosNombre_Sel)) && ! ( StringUtil.StrCmp(AV18TFCentroCostosNombre_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.[CentroCostosNombre] = @AV18TFCentroCostosNombre_Sel)");
         }
         else
         {
            GXv_int6[6] = 1;
         }
         if ( StringUtil.StrCmp(AV18TFCentroCostosNombre_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T2.[CentroCostosNombre] = ''))");
         }
         if ( ! (Convert.ToDecimal(0)==AV19TFCentroCostosPrecioFinal) )
         {
            AddWhere(sWhereString, "(T2.[CentroCostosPrecioFinal] >= @AV19TFCentroCostosPrecioFinal)");
         }
         else
         {
            GXv_int6[7] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV20TFCentroCostosPrecioFinal_To) )
         {
            AddWhere(sWhereString, "(T2.[CentroCostosPrecioFinal] <= @AV20TFCentroCostosPrecioFinal_To)");
         }
         else
         {
            GXv_int6[8] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV21TFCentroCostosSubTotal) )
         {
            AddWhere(sWhereString, "(COALESCE( T3.[CentroCostosSubTotal], 0) >= @AV21TFCentroCostosSubTotal)");
         }
         else
         {
            GXv_int6[9] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV22TFCentroCostosSubTotal_To) )
         {
            AddWhere(sWhereString, "(COALESCE( T3.[CentroCostosSubTotal], 0) <= @AV22TFCentroCostosSubTotal_To)");
         }
         else
         {
            GXv_int6[10] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV23TFCentroCostosCosto) )
         {
            AddWhere(sWhereString, "(T2.[CentroCostosCosto] >= @AV23TFCentroCostosCosto)");
         }
         else
         {
            GXv_int6[11] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV24TFCentroCostosCosto_To) )
         {
            AddWhere(sWhereString, "(T2.[CentroCostosCosto] <= @AV24TFCentroCostosCosto_To)");
         }
         else
         {
            GXv_int6[12] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV25TFCentroCostosGam) )
         {
            AddWhere(sWhereString, "(( T2.[CentroCostosPrecioFinal] - T2.[CentroCostosCosto]) >= @AV25TFCentroCostosGam)");
         }
         else
         {
            GXv_int6[13] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV26TFCentroCostosGam_To) )
         {
            AddWhere(sWhereString, "(( T2.[CentroCostosPrecioFinal] - T2.[CentroCostosCosto]) <= @AV26TFCentroCostosGam_To)");
         }
         else
         {
            GXv_int6[14] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV28TFCentroCostosUsrAlta_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV27TFCentroCostosUsrAlta)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[CentroCostosUsrAlta]) like UPPER(@lV27TFCentroCostosUsrAlta))");
         }
         else
         {
            GXv_int6[15] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV28TFCentroCostosUsrAlta_Sel)) && ! ( StringUtil.StrCmp(AV28TFCentroCostosUsrAlta_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.[CentroCostosUsrAlta] = @AV28TFCentroCostosUsrAlta_Sel)");
         }
         else
         {
            GXv_int6[16] = 1;
         }
         if ( StringUtil.StrCmp(AV28TFCentroCostosUsrAlta_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T2.[CentroCostosUsrAlta] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV30TFCentroCostosUsrMod_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV29TFCentroCostosUsrMod)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[CentroCostosUsrMod]) like UPPER(@lV29TFCentroCostosUsrMod))");
         }
         else
         {
            GXv_int6[17] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV30TFCentroCostosUsrMod_Sel)) && ! ( StringUtil.StrCmp(AV30TFCentroCostosUsrMod_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.[CentroCostosUsrMod] = @AV30TFCentroCostosUsrMod_Sel)");
         }
         else
         {
            GXv_int6[18] = 1;
         }
         if ( StringUtil.StrCmp(AV30TFCentroCostosUsrMod_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T2.[CentroCostosUsrMod] = ''))");
         }
         if ( ! (DateTime.MinValue==AV31TFCentroCostosHoraAlt) )
         {
            AddWhere(sWhereString, "(T2.[CentroCostosHoraAlt] >= @AV31TFCentroCostosHoraAlt)");
         }
         else
         {
            GXv_int6[19] = 1;
         }
         if ( ! (DateTime.MinValue==AV32TFCentroCostosHoraAlt_To) )
         {
            AddWhere(sWhereString, "(T2.[CentroCostosHoraAlt] <= @AV32TFCentroCostosHoraAlt_To)");
         }
         else
         {
            GXv_int6[20] = 1;
         }
         if ( ! (DateTime.MinValue==AV33TFCentroCostosHoraMod) )
         {
            AddWhere(sWhereString, "(T2.[CentroCostosHoraMod] >= @AV33TFCentroCostosHoraMod)");
         }
         else
         {
            GXv_int6[21] = 1;
         }
         if ( ! (DateTime.MinValue==AV34TFCentroCostosHoraMod_To) )
         {
            AddWhere(sWhereString, "(T2.[CentroCostosHoraMod] <= @AV34TFCentroCostosHoraMod_To)");
         }
         else
         {
            GXv_int6[22] = 1;
         }
         if ( AV36TFCentroCostosEstado_Sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV36TFCentroCostosEstado_Sels, "T2.[CentroCostosEstado] IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[ListaCostosId], T2.[CentroCostosUsrMod]";
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
                     return conditional_P00623(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (GxSimpleCollection<string>)dynConstraints[3] , (long)dynConstraints[4] , (long)dynConstraints[5] , (int)dynConstraints[6] , (long)dynConstraints[7] , (long)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (decimal)dynConstraints[11] , (decimal)dynConstraints[12] , (decimal)dynConstraints[13] , (decimal)dynConstraints[14] , (decimal)dynConstraints[15] , (decimal)dynConstraints[16] , (decimal)dynConstraints[17] , (decimal)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (DateTime)dynConstraints[23] , (DateTime)dynConstraints[24] , (DateTime)dynConstraints[25] , (DateTime)dynConstraints[26] , (int)dynConstraints[27] , (long)dynConstraints[28] , (long)dynConstraints[29] , (string)dynConstraints[30] , (decimal)dynConstraints[31] , (decimal)dynConstraints[32] , (decimal)dynConstraints[33] , (string)dynConstraints[34] , (string)dynConstraints[35] , (DateTime)dynConstraints[36] , (DateTime)dynConstraints[37] , (string)dynConstraints[38] , (decimal)dynConstraints[39] , (long)dynConstraints[40] , (long)dynConstraints[41] );
               case 1 :
                     return conditional_P00625(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (GxSimpleCollection<string>)dynConstraints[3] , (long)dynConstraints[4] , (long)dynConstraints[5] , (int)dynConstraints[6] , (long)dynConstraints[7] , (long)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (decimal)dynConstraints[11] , (decimal)dynConstraints[12] , (decimal)dynConstraints[13] , (decimal)dynConstraints[14] , (decimal)dynConstraints[15] , (decimal)dynConstraints[16] , (decimal)dynConstraints[17] , (decimal)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (DateTime)dynConstraints[23] , (DateTime)dynConstraints[24] , (DateTime)dynConstraints[25] , (DateTime)dynConstraints[26] , (int)dynConstraints[27] , (long)dynConstraints[28] , (long)dynConstraints[29] , (string)dynConstraints[30] , (decimal)dynConstraints[31] , (decimal)dynConstraints[32] , (decimal)dynConstraints[33] , (string)dynConstraints[34] , (string)dynConstraints[35] , (DateTime)dynConstraints[36] , (DateTime)dynConstraints[37] , (string)dynConstraints[38] , (decimal)dynConstraints[39] , (long)dynConstraints[40] , (long)dynConstraints[41] );
               case 2 :
                     return conditional_P00627(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (GxSimpleCollection<string>)dynConstraints[3] , (long)dynConstraints[4] , (long)dynConstraints[5] , (int)dynConstraints[6] , (long)dynConstraints[7] , (long)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (decimal)dynConstraints[11] , (decimal)dynConstraints[12] , (decimal)dynConstraints[13] , (decimal)dynConstraints[14] , (decimal)dynConstraints[15] , (decimal)dynConstraints[16] , (decimal)dynConstraints[17] , (decimal)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (DateTime)dynConstraints[23] , (DateTime)dynConstraints[24] , (DateTime)dynConstraints[25] , (DateTime)dynConstraints[26] , (int)dynConstraints[27] , (long)dynConstraints[28] , (long)dynConstraints[29] , (string)dynConstraints[30] , (decimal)dynConstraints[31] , (decimal)dynConstraints[32] , (decimal)dynConstraints[33] , (string)dynConstraints[34] , (string)dynConstraints[35] , (DateTime)dynConstraints[36] , (DateTime)dynConstraints[37] , (string)dynConstraints[38] , (decimal)dynConstraints[39] , (long)dynConstraints[40] , (long)dynConstraints[41] );
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
          Object[] prmP00623;
          prmP00623 = new Object[] {
          new ParDef("@AV60ListaCostosId",GXType.Decimal,18,0) ,
          new ParDef("@AV11TFCentroCostosId",GXType.Decimal,18,0) ,
          new ParDef("@AV12TFCentroCostosId_To",GXType.Decimal,18,0) ,
          new ParDef("@AV15TFCentroCostosRef",GXType.Decimal,18,0) ,
          new ParDef("@AV16TFCentroCostosRef_To",GXType.Decimal,18,0) ,
          new ParDef("@lV17TFCentroCostosNombre",GXType.Char,80,0) ,
          new ParDef("@AV18TFCentroCostosNombre_Sel",GXType.NChar,80,0) ,
          new ParDef("@AV19TFCentroCostosPrecioFinal",GXType.Decimal,18,2) ,
          new ParDef("@AV20TFCentroCostosPrecioFinal_To",GXType.Decimal,18,2) ,
          new ParDef("@AV21TFCentroCostosSubTotal",GXType.Decimal,18,2) ,
          new ParDef("@AV22TFCentroCostosSubTotal_To",GXType.Decimal,18,2) ,
          new ParDef("@AV23TFCentroCostosCosto",GXType.Decimal,18,2) ,
          new ParDef("@AV24TFCentroCostosCosto_To",GXType.Decimal,18,2) ,
          new ParDef("@AV25TFCentroCostosGam",GXType.Decimal,18,2) ,
          new ParDef("@AV26TFCentroCostosGam_To",GXType.Decimal,18,2) ,
          new ParDef("@lV27TFCentroCostosUsrAlta",GXType.Char,30,0) ,
          new ParDef("@AV28TFCentroCostosUsrAlta_Sel",GXType.NChar,30,0) ,
          new ParDef("@lV29TFCentroCostosUsrMod",GXType.Char,30,0) ,
          new ParDef("@AV30TFCentroCostosUsrMod_Sel",GXType.NChar,30,0) ,
          new ParDef("@AV31TFCentroCostosHoraAlt",GXType.Date,8,0) ,
          new ParDef("@AV32TFCentroCostosHoraAlt_To",GXType.Date,8,0) ,
          new ParDef("@AV33TFCentroCostosHoraMod",GXType.Date,8,0) ,
          new ParDef("@AV34TFCentroCostosHoraMod_To",GXType.Date,8,0)
          };
          Object[] prmP00625;
          prmP00625 = new Object[] {
          new ParDef("@AV60ListaCostosId",GXType.Decimal,18,0) ,
          new ParDef("@AV11TFCentroCostosId",GXType.Decimal,18,0) ,
          new ParDef("@AV12TFCentroCostosId_To",GXType.Decimal,18,0) ,
          new ParDef("@AV15TFCentroCostosRef",GXType.Decimal,18,0) ,
          new ParDef("@AV16TFCentroCostosRef_To",GXType.Decimal,18,0) ,
          new ParDef("@lV17TFCentroCostosNombre",GXType.Char,80,0) ,
          new ParDef("@AV18TFCentroCostosNombre_Sel",GXType.NChar,80,0) ,
          new ParDef("@AV19TFCentroCostosPrecioFinal",GXType.Decimal,18,2) ,
          new ParDef("@AV20TFCentroCostosPrecioFinal_To",GXType.Decimal,18,2) ,
          new ParDef("@AV21TFCentroCostosSubTotal",GXType.Decimal,18,2) ,
          new ParDef("@AV22TFCentroCostosSubTotal_To",GXType.Decimal,18,2) ,
          new ParDef("@AV23TFCentroCostosCosto",GXType.Decimal,18,2) ,
          new ParDef("@AV24TFCentroCostosCosto_To",GXType.Decimal,18,2) ,
          new ParDef("@AV25TFCentroCostosGam",GXType.Decimal,18,2) ,
          new ParDef("@AV26TFCentroCostosGam_To",GXType.Decimal,18,2) ,
          new ParDef("@lV27TFCentroCostosUsrAlta",GXType.Char,30,0) ,
          new ParDef("@AV28TFCentroCostosUsrAlta_Sel",GXType.NChar,30,0) ,
          new ParDef("@lV29TFCentroCostosUsrMod",GXType.Char,30,0) ,
          new ParDef("@AV30TFCentroCostosUsrMod_Sel",GXType.NChar,30,0) ,
          new ParDef("@AV31TFCentroCostosHoraAlt",GXType.Date,8,0) ,
          new ParDef("@AV32TFCentroCostosHoraAlt_To",GXType.Date,8,0) ,
          new ParDef("@AV33TFCentroCostosHoraMod",GXType.Date,8,0) ,
          new ParDef("@AV34TFCentroCostosHoraMod_To",GXType.Date,8,0)
          };
          Object[] prmP00627;
          prmP00627 = new Object[] {
          new ParDef("@AV60ListaCostosId",GXType.Decimal,18,0) ,
          new ParDef("@AV11TFCentroCostosId",GXType.Decimal,18,0) ,
          new ParDef("@AV12TFCentroCostosId_To",GXType.Decimal,18,0) ,
          new ParDef("@AV15TFCentroCostosRef",GXType.Decimal,18,0) ,
          new ParDef("@AV16TFCentroCostosRef_To",GXType.Decimal,18,0) ,
          new ParDef("@lV17TFCentroCostosNombre",GXType.Char,80,0) ,
          new ParDef("@AV18TFCentroCostosNombre_Sel",GXType.NChar,80,0) ,
          new ParDef("@AV19TFCentroCostosPrecioFinal",GXType.Decimal,18,2) ,
          new ParDef("@AV20TFCentroCostosPrecioFinal_To",GXType.Decimal,18,2) ,
          new ParDef("@AV21TFCentroCostosSubTotal",GXType.Decimal,18,2) ,
          new ParDef("@AV22TFCentroCostosSubTotal_To",GXType.Decimal,18,2) ,
          new ParDef("@AV23TFCentroCostosCosto",GXType.Decimal,18,2) ,
          new ParDef("@AV24TFCentroCostosCosto_To",GXType.Decimal,18,2) ,
          new ParDef("@AV25TFCentroCostosGam",GXType.Decimal,18,2) ,
          new ParDef("@AV26TFCentroCostosGam_To",GXType.Decimal,18,2) ,
          new ParDef("@lV27TFCentroCostosUsrAlta",GXType.Char,30,0) ,
          new ParDef("@AV28TFCentroCostosUsrAlta_Sel",GXType.NChar,30,0) ,
          new ParDef("@lV29TFCentroCostosUsrMod",GXType.Char,30,0) ,
          new ParDef("@AV30TFCentroCostosUsrMod_Sel",GXType.NChar,30,0) ,
          new ParDef("@AV31TFCentroCostosHoraAlt",GXType.Date,8,0) ,
          new ParDef("@AV32TFCentroCostosHoraAlt_To",GXType.Date,8,0) ,
          new ParDef("@AV33TFCentroCostosHoraMod",GXType.Date,8,0) ,
          new ParDef("@AV34TFCentroCostosHoraMod_To",GXType.Date,8,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00623", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00623,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00625", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00625,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00627", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00627,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[2])[0] = rslt.getString(2, 80);
                ((DateTime[]) buf[3])[0] = rslt.getGXDate(3);
                ((DateTime[]) buf[4])[0] = rslt.getGXDate(4);
                ((string[]) buf[5])[0] = rslt.getString(5, 3);
                ((string[]) buf[6])[0] = rslt.getString(6, 30);
                ((string[]) buf[7])[0] = rslt.getString(7, 30);
                ((decimal[]) buf[8])[0] = rslt.getDecimal(8);
                ((long[]) buf[9])[0] = rslt.getLong(9);
                ((string[]) buf[10])[0] = rslt.getString(10, 1);
                ((long[]) buf[11])[0] = rslt.getLong(11);
                ((decimal[]) buf[12])[0] = rslt.getDecimal(12);
                ((decimal[]) buf[13])[0] = rslt.getDecimal(13);
                ((decimal[]) buf[14])[0] = rslt.getDecimal(14);
                ((bool[]) buf[15])[0] = rslt.wasNull(14);
                ((long[]) buf[16])[0] = rslt.getLong(15);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getString(2, 30);
                ((DateTime[]) buf[3])[0] = rslt.getGXDate(3);
                ((DateTime[]) buf[4])[0] = rslt.getGXDate(4);
                ((string[]) buf[5])[0] = rslt.getString(5, 3);
                ((string[]) buf[6])[0] = rslt.getString(6, 30);
                ((decimal[]) buf[7])[0] = rslt.getDecimal(7);
                ((string[]) buf[8])[0] = rslt.getString(8, 80);
                ((long[]) buf[9])[0] = rslt.getLong(9);
                ((string[]) buf[10])[0] = rslt.getString(10, 1);
                ((long[]) buf[11])[0] = rslt.getLong(11);
                ((decimal[]) buf[12])[0] = rslt.getDecimal(12);
                ((decimal[]) buf[13])[0] = rslt.getDecimal(13);
                ((decimal[]) buf[14])[0] = rslt.getDecimal(14);
                ((bool[]) buf[15])[0] = rslt.wasNull(14);
                ((long[]) buf[16])[0] = rslt.getLong(15);
                return;
             case 2 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getString(2, 30);
                ((DateTime[]) buf[3])[0] = rslt.getGXDate(3);
                ((DateTime[]) buf[4])[0] = rslt.getGXDate(4);
                ((string[]) buf[5])[0] = rslt.getString(5, 3);
                ((string[]) buf[6])[0] = rslt.getString(6, 30);
                ((decimal[]) buf[7])[0] = rslt.getDecimal(7);
                ((string[]) buf[8])[0] = rslt.getString(8, 80);
                ((long[]) buf[9])[0] = rslt.getLong(9);
                ((string[]) buf[10])[0] = rslt.getString(10, 1);
                ((long[]) buf[11])[0] = rslt.getLong(11);
                ((decimal[]) buf[12])[0] = rslt.getDecimal(12);
                ((decimal[]) buf[13])[0] = rslt.getDecimal(13);
                ((decimal[]) buf[14])[0] = rslt.getDecimal(14);
                ((bool[]) buf[15])[0] = rslt.wasNull(14);
                ((long[]) buf[16])[0] = rslt.getLong(15);
                return;
       }
    }

 }

 [ServiceContract(Namespace = "GeneXus.Programs.listacostosdetalles1wcgetfilterdata_services")]
 [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple)]
 [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
 public class listacostosdetalles1wcgetfilterdata_services : GxRestService
 {
    [OperationContract(Name = "ListaCostosDetalles1WCGetFilterData" )]
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
          if ( ! ProcessHeaders("listacostosdetalles1wcgetfilterdata") )
          {
             return  ;
          }
          listacostosdetalles1wcgetfilterdata worker = new listacostosdetalles1wcgetfilterdata(context);
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

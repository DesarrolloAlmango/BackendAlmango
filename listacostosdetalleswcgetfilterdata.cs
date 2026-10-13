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
   public class listacostosdetalleswcgetfilterdata : GXProcedure
   {
      public listacostosdetalleswcgetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public listacostosdetalleswcgetfilterdata( IGxContext context )
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
         this.AV45DDOName = aP0_DDOName;
         this.AV46SearchTxtParms = aP1_SearchTxtParms;
         this.AV47SearchTxtTo = aP2_SearchTxtTo;
         this.AV48OptionsJson = "" ;
         this.AV49OptionsDescJson = "" ;
         this.AV50OptionIndexesJson = "" ;
         initialize();
         ExecutePrivate();
         aP3_OptionsJson=this.AV48OptionsJson;
         aP4_OptionsDescJson=this.AV49OptionsDescJson;
         aP5_OptionIndexesJson=this.AV50OptionIndexesJson;
      }

      public string executeUdp( string aP0_DDOName ,
                                string aP1_SearchTxtParms ,
                                string aP2_SearchTxtTo ,
                                out string aP3_OptionsJson ,
                                out string aP4_OptionsDescJson )
      {
         execute(aP0_DDOName, aP1_SearchTxtParms, aP2_SearchTxtTo, out aP3_OptionsJson, out aP4_OptionsDescJson, out aP5_OptionIndexesJson);
         return AV50OptionIndexesJson ;
      }

      public void executeSubmit( string aP0_DDOName ,
                                 string aP1_SearchTxtParms ,
                                 string aP2_SearchTxtTo ,
                                 out string aP3_OptionsJson ,
                                 out string aP4_OptionsDescJson ,
                                 out string aP5_OptionIndexesJson )
      {
         this.AV45DDOName = aP0_DDOName;
         this.AV46SearchTxtParms = aP1_SearchTxtParms;
         this.AV47SearchTxtTo = aP2_SearchTxtTo;
         this.AV48OptionsJson = "" ;
         this.AV49OptionsDescJson = "" ;
         this.AV50OptionIndexesJson = "" ;
         SubmitImpl();
         aP3_OptionsJson=this.AV48OptionsJson;
         aP4_OptionsDescJson=this.AV49OptionsDescJson;
         aP5_OptionIndexesJson=this.AV50OptionIndexesJson;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV35Options = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV37OptionsDesc = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV38OptionIndexes = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         GXt_boolean1 = AV8IsAuthorized;
         new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWCentroCostos", out  GXt_boolean1) ;
         AV8IsAuthorized = GXt_boolean1;
         if ( AV8IsAuthorized )
         {
            AV32MaxItems = 10;
            AV31PageIndex = (short)((String.IsNullOrEmpty(StringUtil.RTrim( AV46SearchTxtParms)) ? 0 : (long)(Math.Round(NumberUtil.Val( StringUtil.Substring( AV46SearchTxtParms, 1, 2), "."), 18, MidpointRounding.ToEven))));
            AV29SearchTxt = (String.IsNullOrEmpty(StringUtil.RTrim( AV46SearchTxtParms)) ? "" : StringUtil.Substring( AV46SearchTxtParms, 3, -1));
            AV30SkipItems = (short)(AV31PageIndex*AV32MaxItems);
            new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV9WWPContext) ;
            /* Execute user subroutine: 'LOADGRIDSTATE' */
            S111 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
            if ( StringUtil.StrCmp(StringUtil.Upper( AV45DDOName), "DDO_CENTROCOSTOSNOMBRE") == 0 )
            {
               /* Execute user subroutine: 'LOADCENTROCOSTOSNOMBREOPTIONS' */
               S121 ();
               if ( returnInSub )
               {
                  cleanup();
                  if (true) return;
               }
            }
            else if ( StringUtil.StrCmp(StringUtil.Upper( AV45DDOName), "DDO_CENTROCOSTOSUSRALTA") == 0 )
            {
               /* Execute user subroutine: 'LOADCENTROCOSTOSUSRALTAOPTIONS' */
               S131 ();
               if ( returnInSub )
               {
                  cleanup();
                  if (true) return;
               }
            }
         }
         AV48OptionsJson = AV35Options.ToJSonString(false);
         AV49OptionsDescJson = AV37OptionsDesc.ToJSonString(false);
         AV50OptionIndexesJson = AV38OptionIndexes.ToJSonString(false);
         cleanup();
      }

      protected void S111( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV40Session.Get("ListaCostosDetallesWCGridState"), "") == 0 )
         {
            AV42GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "ListaCostosDetallesWCGridState"), null, "", "");
         }
         else
         {
            AV42GridState.FromXml(AV40Session.Get("ListaCostosDetallesWCGridState"), null, "", "");
         }
         AV53GXV1 = 1;
         while ( AV53GXV1 <= AV42GridState.gxTpr_Filtervalues.Count )
         {
            AV43GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV42GridState.gxTpr_Filtervalues.Item(AV53GXV1));
            if ( StringUtil.StrCmp(AV43GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV51FilterFullText = AV43GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV43GridStateFilterValue.gxTpr_Name, "TFCENTROCOSTOSID") == 0 )
            {
               AV11TFCentroCostosId = (long)(Math.Round(NumberUtil.Val( AV43GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV12TFCentroCostosId_To = (long)(Math.Round(NumberUtil.Val( AV43GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV43GridStateFilterValue.gxTpr_Name, "TFCENTROCOSTOSREF") == 0 )
            {
               AV13TFCentroCostosRef = (long)(Math.Round(NumberUtil.Val( AV43GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV14TFCentroCostosRef_To = (long)(Math.Round(NumberUtil.Val( AV43GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV43GridStateFilterValue.gxTpr_Name, "TFCENTROCOSTOSNOMBRE") == 0 )
            {
               AV15TFCentroCostosNombre = AV43GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV43GridStateFilterValue.gxTpr_Name, "TFCENTROCOSTOSNOMBRE_SEL") == 0 )
            {
               AV16TFCentroCostosNombre_Sel = AV43GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV43GridStateFilterValue.gxTpr_Name, "TFCENTROCOSTOSPRECIOFINAL") == 0 )
            {
               AV17TFCentroCostosPrecioFinal = NumberUtil.Val( AV43GridStateFilterValue.gxTpr_Value, ".");
               AV18TFCentroCostosPrecioFinal_To = NumberUtil.Val( AV43GridStateFilterValue.gxTpr_Valueto, ".");
            }
            else if ( StringUtil.StrCmp(AV43GridStateFilterValue.gxTpr_Name, "TFCENTROCOSTOSCOSTO") == 0 )
            {
               AV19TFCentroCostosCosto = NumberUtil.Val( AV43GridStateFilterValue.gxTpr_Value, ".");
               AV20TFCentroCostosCosto_To = NumberUtil.Val( AV43GridStateFilterValue.gxTpr_Valueto, ".");
            }
            else if ( StringUtil.StrCmp(AV43GridStateFilterValue.gxTpr_Name, "TFCENTROCOSTOSUSRALTA") == 0 )
            {
               AV21TFCentroCostosUsrAlta = AV43GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV43GridStateFilterValue.gxTpr_Name, "TFCENTROCOSTOSUSRALTA_SEL") == 0 )
            {
               AV22TFCentroCostosUsrAlta_Sel = AV43GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV43GridStateFilterValue.gxTpr_Name, "TFCENTROCOSTOSHORAALT") == 0 )
            {
               AV23TFCentroCostosHoraAlt = context.localUtil.CToD( AV43GridStateFilterValue.gxTpr_Value, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               AV24TFCentroCostosHoraAlt_To = context.localUtil.CToD( AV43GridStateFilterValue.gxTpr_Valueto, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
            }
            else if ( StringUtil.StrCmp(AV43GridStateFilterValue.gxTpr_Name, "TFCENTROCOSTOSESTADO_SEL") == 0 )
            {
               AV25TFCentroCostosEstado_SelsJson = AV43GridStateFilterValue.gxTpr_Value;
               AV26TFCentroCostosEstado_Sels.FromJSonString(AV25TFCentroCostosEstado_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV43GridStateFilterValue.gxTpr_Name, "TFCENTROCOSTOSTIPOREF_SEL") == 0 )
            {
               AV27TFCentroCostosTipoRef_SelsJson = AV43GridStateFilterValue.gxTpr_Value;
               AV28TFCentroCostosTipoRef_Sels.FromJSonString(AV27TFCentroCostosTipoRef_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV43GridStateFilterValue.gxTpr_Name, "PARM_&LISTACOSTOSID") == 0 )
            {
               AV52ListaCostosId = (long)(Math.Round(NumberUtil.Val( AV43GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
            }
            AV53GXV1 = (int)(AV53GXV1+1);
         }
      }

      protected void S121( )
      {
         /* 'LOADCENTROCOSTOSNOMBREOPTIONS' Routine */
         returnInSub = false;
         AV15TFCentroCostosNombre = AV29SearchTxt;
         AV16TFCentroCostosNombre_Sel = "";
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A482CentroCostosEstado ,
                                              AV26TFCentroCostosEstado_Sels ,
                                              A487CentroCostosTipoRef ,
                                              AV28TFCentroCostosTipoRef_Sels ,
                                              AV11TFCentroCostosId ,
                                              AV12TFCentroCostosId_To ,
                                              AV13TFCentroCostosRef ,
                                              AV14TFCentroCostosRef_To ,
                                              AV16TFCentroCostosNombre_Sel ,
                                              AV15TFCentroCostosNombre ,
                                              AV17TFCentroCostosPrecioFinal ,
                                              AV18TFCentroCostosPrecioFinal_To ,
                                              AV19TFCentroCostosCosto ,
                                              AV20TFCentroCostosCosto_To ,
                                              AV22TFCentroCostosUsrAlta_Sel ,
                                              AV21TFCentroCostosUsrAlta ,
                                              AV23TFCentroCostosHoraAlt ,
                                              AV24TFCentroCostosHoraAlt_To ,
                                              AV26TFCentroCostosEstado_Sels.Count ,
                                              AV28TFCentroCostosTipoRef_Sels.Count ,
                                              A461CentroCostosId ,
                                              A462CentroCostosRef ,
                                              A463CentroCostosNombre ,
                                              A464CentroCostosPrecioFinal ,
                                              A475CentroCostosCosto ,
                                              A478CentroCostosUsrAlta ,
                                              A480CentroCostosHoraAlt ,
                                              AV51FilterFullText ,
                                              AV52ListaCostosId ,
                                              A459ListaCostosId } ,
                                              new int[]{
                                              TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DATE, TypeConstants.DATE,
                                              TypeConstants.INT, TypeConstants.INT, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DATE, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.BOOLEAN
                                              }
         });
         lV15TFCentroCostosNombre = StringUtil.PadR( StringUtil.RTrim( AV15TFCentroCostosNombre), 80, "%");
         lV21TFCentroCostosUsrAlta = StringUtil.PadR( StringUtil.RTrim( AV21TFCentroCostosUsrAlta), 30, "%");
         /* Using cursor P00612 */
         pr_default.execute(0, new Object[] {AV52ListaCostosId, AV11TFCentroCostosId, AV12TFCentroCostosId_To, AV13TFCentroCostosRef, AV14TFCentroCostosRef_To, lV15TFCentroCostosNombre, AV16TFCentroCostosNombre_Sel, AV17TFCentroCostosPrecioFinal, AV18TFCentroCostosPrecioFinal_To, AV19TFCentroCostosCosto, AV20TFCentroCostosCosto_To, lV21TFCentroCostosUsrAlta, AV22TFCentroCostosUsrAlta_Sel, AV23TFCentroCostosHoraAlt, AV24TFCentroCostosHoraAlt_To});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRK612 = false;
            A459ListaCostosId = P00612_A459ListaCostosId[0];
            n459ListaCostosId = P00612_n459ListaCostosId[0];
            A463CentroCostosNombre = P00612_A463CentroCostosNombre[0];
            A480CentroCostosHoraAlt = P00612_A480CentroCostosHoraAlt[0];
            A487CentroCostosTipoRef = P00612_A487CentroCostosTipoRef[0];
            A482CentroCostosEstado = P00612_A482CentroCostosEstado[0];
            A478CentroCostosUsrAlta = P00612_A478CentroCostosUsrAlta[0];
            A475CentroCostosCosto = P00612_A475CentroCostosCosto[0];
            A464CentroCostosPrecioFinal = P00612_A464CentroCostosPrecioFinal[0];
            A462CentroCostosRef = P00612_A462CentroCostosRef[0];
            A461CentroCostosId = P00612_A461CentroCostosId[0];
            A466CentroCostosDetallesId = P00612_A466CentroCostosDetallesId[0];
            A463CentroCostosNombre = P00612_A463CentroCostosNombre[0];
            A480CentroCostosHoraAlt = P00612_A480CentroCostosHoraAlt[0];
            A487CentroCostosTipoRef = P00612_A487CentroCostosTipoRef[0];
            A482CentroCostosEstado = P00612_A482CentroCostosEstado[0];
            A478CentroCostosUsrAlta = P00612_A478CentroCostosUsrAlta[0];
            A475CentroCostosCosto = P00612_A475CentroCostosCosto[0];
            A464CentroCostosPrecioFinal = P00612_A464CentroCostosPrecioFinal[0];
            A462CentroCostosRef = P00612_A462CentroCostosRef[0];
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV51FilterFullText)) || ( ( StringUtil.Like( StringUtil.Str( (decimal)(A461CentroCostosId), 18, 0) , StringUtil.PadR( "%" + AV51FilterFullText , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Str( (decimal)(A462CentroCostosRef), 18, 0) , StringUtil.PadR( "%" + AV51FilterFullText , 254 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Upper( A463CentroCostosNombre) , StringUtil.PadR( "%" + StringUtil.Upper( AV51FilterFullText) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Str( A464CentroCostosPrecioFinal, 18, 2) , StringUtil.PadR( "%" + AV51FilterFullText , 254 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Str( A475CentroCostosCosto, 18, 2) , StringUtil.PadR( "%" + AV51FilterFullText , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A478CentroCostosUsrAlta) , StringUtil.PadR( "%" + StringUtil.Upper( AV51FilterFullText) , 255 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( context.GetMessage( "aprobado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV51FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A482CentroCostosEstado, "HAB") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "deshabilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV51FilterFullText) , 255 , "%"),  ' ' ) &&
            ( StringUtil.StrCmp(A482CentroCostosEstado, "DES") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "pendiente de aprobación", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV51FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A482CentroCostosEstado, "PND") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "desaprobado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV51FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A482CentroCostosEstado, "DES") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "servicios", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV51FilterFullText) , 255 , "%"),  ' ' ) &&
            ( StringUtil.StrCmp(A487CentroCostosTipoRef, "S") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "otros", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV51FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A487CentroCostosTipoRef, "O") == 0 ) ) )
            )
            {
               AV39count = 0;
               while ( (pr_default.getStatus(0) != 101) && ( P00612_A459ListaCostosId[0] == A459ListaCostosId ) && ( StringUtil.StrCmp(P00612_A463CentroCostosNombre[0], A463CentroCostosNombre) == 0 ) )
               {
                  BRK612 = false;
                  A461CentroCostosId = P00612_A461CentroCostosId[0];
                  A466CentroCostosDetallesId = P00612_A466CentroCostosDetallesId[0];
                  AV39count = (long)(AV39count+1);
                  BRK612 = true;
                  pr_default.readNext(0);
               }
               if ( (0==AV30SkipItems) )
               {
                  AV34Option = (String.IsNullOrEmpty(StringUtil.RTrim( A463CentroCostosNombre)) ? "<#Empty#>" : A463CentroCostosNombre);
                  AV35Options.Add(AV34Option, 0);
                  AV38OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV39count), "Z,ZZZ,ZZZ,ZZ9")), 0);
                  if ( AV35Options.Count == 10 )
                  {
                     /* Exit For each command. Update data (if necessary), close cursors & exit. */
                     if (true) break;
                  }
               }
               else
               {
                  AV30SkipItems = (short)(AV30SkipItems-1);
               }
            }
            if ( ! BRK612 )
            {
               BRK612 = true;
               pr_default.readNext(0);
            }
         }
         pr_default.close(0);
      }

      protected void S131( )
      {
         /* 'LOADCENTROCOSTOSUSRALTAOPTIONS' Routine */
         returnInSub = false;
         AV21TFCentroCostosUsrAlta = AV29SearchTxt;
         AV22TFCentroCostosUsrAlta_Sel = "";
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              A482CentroCostosEstado ,
                                              AV26TFCentroCostosEstado_Sels ,
                                              A487CentroCostosTipoRef ,
                                              AV28TFCentroCostosTipoRef_Sels ,
                                              AV11TFCentroCostosId ,
                                              AV12TFCentroCostosId_To ,
                                              AV13TFCentroCostosRef ,
                                              AV14TFCentroCostosRef_To ,
                                              AV16TFCentroCostosNombre_Sel ,
                                              AV15TFCentroCostosNombre ,
                                              AV17TFCentroCostosPrecioFinal ,
                                              AV18TFCentroCostosPrecioFinal_To ,
                                              AV19TFCentroCostosCosto ,
                                              AV20TFCentroCostosCosto_To ,
                                              AV22TFCentroCostosUsrAlta_Sel ,
                                              AV21TFCentroCostosUsrAlta ,
                                              AV23TFCentroCostosHoraAlt ,
                                              AV24TFCentroCostosHoraAlt_To ,
                                              AV26TFCentroCostosEstado_Sels.Count ,
                                              AV28TFCentroCostosTipoRef_Sels.Count ,
                                              A461CentroCostosId ,
                                              A462CentroCostosRef ,
                                              A463CentroCostosNombre ,
                                              A464CentroCostosPrecioFinal ,
                                              A475CentroCostosCosto ,
                                              A478CentroCostosUsrAlta ,
                                              A480CentroCostosHoraAlt ,
                                              AV51FilterFullText ,
                                              AV52ListaCostosId ,
                                              A459ListaCostosId } ,
                                              new int[]{
                                              TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DATE, TypeConstants.DATE,
                                              TypeConstants.INT, TypeConstants.INT, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DATE, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.BOOLEAN
                                              }
         });
         lV15TFCentroCostosNombre = StringUtil.PadR( StringUtil.RTrim( AV15TFCentroCostosNombre), 80, "%");
         lV21TFCentroCostosUsrAlta = StringUtil.PadR( StringUtil.RTrim( AV21TFCentroCostosUsrAlta), 30, "%");
         /* Using cursor P00613 */
         pr_default.execute(1, new Object[] {AV52ListaCostosId, AV11TFCentroCostosId, AV12TFCentroCostosId_To, AV13TFCentroCostosRef, AV14TFCentroCostosRef_To, lV15TFCentroCostosNombre, AV16TFCentroCostosNombre_Sel, AV17TFCentroCostosPrecioFinal, AV18TFCentroCostosPrecioFinal_To, AV19TFCentroCostosCosto, AV20TFCentroCostosCosto_To, lV21TFCentroCostosUsrAlta, AV22TFCentroCostosUsrAlta_Sel, AV23TFCentroCostosHoraAlt, AV24TFCentroCostosHoraAlt_To});
         while ( (pr_default.getStatus(1) != 101) )
         {
            BRK614 = false;
            A459ListaCostosId = P00613_A459ListaCostosId[0];
            n459ListaCostosId = P00613_n459ListaCostosId[0];
            A478CentroCostosUsrAlta = P00613_A478CentroCostosUsrAlta[0];
            A480CentroCostosHoraAlt = P00613_A480CentroCostosHoraAlt[0];
            A487CentroCostosTipoRef = P00613_A487CentroCostosTipoRef[0];
            A482CentroCostosEstado = P00613_A482CentroCostosEstado[0];
            A475CentroCostosCosto = P00613_A475CentroCostosCosto[0];
            A464CentroCostosPrecioFinal = P00613_A464CentroCostosPrecioFinal[0];
            A463CentroCostosNombre = P00613_A463CentroCostosNombre[0];
            A462CentroCostosRef = P00613_A462CentroCostosRef[0];
            A461CentroCostosId = P00613_A461CentroCostosId[0];
            A466CentroCostosDetallesId = P00613_A466CentroCostosDetallesId[0];
            A478CentroCostosUsrAlta = P00613_A478CentroCostosUsrAlta[0];
            A480CentroCostosHoraAlt = P00613_A480CentroCostosHoraAlt[0];
            A487CentroCostosTipoRef = P00613_A487CentroCostosTipoRef[0];
            A482CentroCostosEstado = P00613_A482CentroCostosEstado[0];
            A475CentroCostosCosto = P00613_A475CentroCostosCosto[0];
            A464CentroCostosPrecioFinal = P00613_A464CentroCostosPrecioFinal[0];
            A463CentroCostosNombre = P00613_A463CentroCostosNombre[0];
            A462CentroCostosRef = P00613_A462CentroCostosRef[0];
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV51FilterFullText)) || ( ( StringUtil.Like( StringUtil.Str( (decimal)(A461CentroCostosId), 18, 0) , StringUtil.PadR( "%" + AV51FilterFullText , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Str( (decimal)(A462CentroCostosRef), 18, 0) , StringUtil.PadR( "%" + AV51FilterFullText , 254 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Upper( A463CentroCostosNombre) , StringUtil.PadR( "%" + StringUtil.Upper( AV51FilterFullText) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Str( A464CentroCostosPrecioFinal, 18, 2) , StringUtil.PadR( "%" + AV51FilterFullText , 254 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Str( A475CentroCostosCosto, 18, 2) , StringUtil.PadR( "%" + AV51FilterFullText , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A478CentroCostosUsrAlta) , StringUtil.PadR( "%" + StringUtil.Upper( AV51FilterFullText) , 255 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( context.GetMessage( "aprobado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV51FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A482CentroCostosEstado, "HAB") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "deshabilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV51FilterFullText) , 255 , "%"),  ' ' ) &&
            ( StringUtil.StrCmp(A482CentroCostosEstado, "DES") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "pendiente de aprobación", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV51FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A482CentroCostosEstado, "PND") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "desaprobado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV51FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A482CentroCostosEstado, "DES") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "servicios", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV51FilterFullText) , 255 , "%"),  ' ' ) &&
            ( StringUtil.StrCmp(A487CentroCostosTipoRef, "S") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "otros", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV51FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A487CentroCostosTipoRef, "O") == 0 ) ) )
            )
            {
               AV39count = 0;
               while ( (pr_default.getStatus(1) != 101) && ( P00613_A459ListaCostosId[0] == A459ListaCostosId ) && ( StringUtil.StrCmp(P00613_A478CentroCostosUsrAlta[0], A478CentroCostosUsrAlta) == 0 ) )
               {
                  BRK614 = false;
                  A461CentroCostosId = P00613_A461CentroCostosId[0];
                  A466CentroCostosDetallesId = P00613_A466CentroCostosDetallesId[0];
                  AV39count = (long)(AV39count+1);
                  BRK614 = true;
                  pr_default.readNext(1);
               }
               if ( (0==AV30SkipItems) )
               {
                  AV34Option = (String.IsNullOrEmpty(StringUtil.RTrim( A478CentroCostosUsrAlta)) ? "<#Empty#>" : A478CentroCostosUsrAlta);
                  AV35Options.Add(AV34Option, 0);
                  AV38OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV39count), "Z,ZZZ,ZZZ,ZZ9")), 0);
                  if ( AV35Options.Count == 10 )
                  {
                     /* Exit For each command. Update data (if necessary), close cursors & exit. */
                     if (true) break;
                  }
               }
               else
               {
                  AV30SkipItems = (short)(AV30SkipItems-1);
               }
            }
            if ( ! BRK614 )
            {
               BRK614 = true;
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
         AV48OptionsJson = "";
         AV49OptionsDescJson = "";
         AV50OptionIndexesJson = "";
         AV35Options = new GxSimpleCollection<string>();
         AV37OptionsDesc = new GxSimpleCollection<string>();
         AV38OptionIndexes = new GxSimpleCollection<string>();
         AV29SearchTxt = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV40Session = context.GetSession();
         AV42GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV43GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV51FilterFullText = "";
         AV15TFCentroCostosNombre = "";
         AV16TFCentroCostosNombre_Sel = "";
         AV21TFCentroCostosUsrAlta = "";
         AV22TFCentroCostosUsrAlta_Sel = "";
         AV23TFCentroCostosHoraAlt = DateTime.MinValue;
         AV24TFCentroCostosHoraAlt_To = DateTime.MinValue;
         AV25TFCentroCostosEstado_SelsJson = "";
         AV26TFCentroCostosEstado_Sels = new GxSimpleCollection<string>();
         AV27TFCentroCostosTipoRef_SelsJson = "";
         AV28TFCentroCostosTipoRef_Sels = new GxSimpleCollection<string>();
         lV15TFCentroCostosNombre = "";
         lV21TFCentroCostosUsrAlta = "";
         A482CentroCostosEstado = "";
         A487CentroCostosTipoRef = "";
         A463CentroCostosNombre = "";
         A478CentroCostosUsrAlta = "";
         A480CentroCostosHoraAlt = DateTime.MinValue;
         P00612_A459ListaCostosId = new long[1] ;
         P00612_n459ListaCostosId = new bool[] {false} ;
         P00612_A463CentroCostosNombre = new string[] {""} ;
         P00612_A480CentroCostosHoraAlt = new DateTime[] {DateTime.MinValue} ;
         P00612_A487CentroCostosTipoRef = new string[] {""} ;
         P00612_A482CentroCostosEstado = new string[] {""} ;
         P00612_A478CentroCostosUsrAlta = new string[] {""} ;
         P00612_A475CentroCostosCosto = new decimal[1] ;
         P00612_A464CentroCostosPrecioFinal = new decimal[1] ;
         P00612_A462CentroCostosRef = new long[1] ;
         P00612_A461CentroCostosId = new long[1] ;
         P00612_A466CentroCostosDetallesId = new long[1] ;
         AV34Option = "";
         P00613_A459ListaCostosId = new long[1] ;
         P00613_n459ListaCostosId = new bool[] {false} ;
         P00613_A478CentroCostosUsrAlta = new string[] {""} ;
         P00613_A480CentroCostosHoraAlt = new DateTime[] {DateTime.MinValue} ;
         P00613_A487CentroCostosTipoRef = new string[] {""} ;
         P00613_A482CentroCostosEstado = new string[] {""} ;
         P00613_A475CentroCostosCosto = new decimal[1] ;
         P00613_A464CentroCostosPrecioFinal = new decimal[1] ;
         P00613_A463CentroCostosNombre = new string[] {""} ;
         P00613_A462CentroCostosRef = new long[1] ;
         P00613_A461CentroCostosId = new long[1] ;
         P00613_A466CentroCostosDetallesId = new long[1] ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.listacostosdetalleswcgetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P00612_A459ListaCostosId, P00612_n459ListaCostosId, P00612_A463CentroCostosNombre, P00612_A480CentroCostosHoraAlt, P00612_A487CentroCostosTipoRef, P00612_A482CentroCostosEstado, P00612_A478CentroCostosUsrAlta, P00612_A475CentroCostosCosto, P00612_A464CentroCostosPrecioFinal, P00612_A462CentroCostosRef,
               P00612_A461CentroCostosId, P00612_A466CentroCostosDetallesId
               }
               , new Object[] {
               P00613_A459ListaCostosId, P00613_n459ListaCostosId, P00613_A478CentroCostosUsrAlta, P00613_A480CentroCostosHoraAlt, P00613_A487CentroCostosTipoRef, P00613_A482CentroCostosEstado, P00613_A475CentroCostosCosto, P00613_A464CentroCostosPrecioFinal, P00613_A463CentroCostosNombre, P00613_A462CentroCostosRef,
               P00613_A461CentroCostosId, P00613_A466CentroCostosDetallesId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV32MaxItems ;
      private short AV31PageIndex ;
      private short AV30SkipItems ;
      private int AV53GXV1 ;
      private int AV26TFCentroCostosEstado_Sels_Count ;
      private int AV28TFCentroCostosTipoRef_Sels_Count ;
      private long AV11TFCentroCostosId ;
      private long AV12TFCentroCostosId_To ;
      private long AV13TFCentroCostosRef ;
      private long AV14TFCentroCostosRef_To ;
      private long AV52ListaCostosId ;
      private long A461CentroCostosId ;
      private long A462CentroCostosRef ;
      private long A459ListaCostosId ;
      private long A466CentroCostosDetallesId ;
      private long AV39count ;
      private decimal AV17TFCentroCostosPrecioFinal ;
      private decimal AV18TFCentroCostosPrecioFinal_To ;
      private decimal AV19TFCentroCostosCosto ;
      private decimal AV20TFCentroCostosCosto_To ;
      private decimal A464CentroCostosPrecioFinal ;
      private decimal A475CentroCostosCosto ;
      private string AV15TFCentroCostosNombre ;
      private string AV16TFCentroCostosNombre_Sel ;
      private string AV21TFCentroCostosUsrAlta ;
      private string AV22TFCentroCostosUsrAlta_Sel ;
      private string lV15TFCentroCostosNombre ;
      private string lV21TFCentroCostosUsrAlta ;
      private string A482CentroCostosEstado ;
      private string A487CentroCostosTipoRef ;
      private string A463CentroCostosNombre ;
      private string A478CentroCostosUsrAlta ;
      private DateTime AV23TFCentroCostosHoraAlt ;
      private DateTime AV24TFCentroCostosHoraAlt_To ;
      private DateTime A480CentroCostosHoraAlt ;
      private bool AV8IsAuthorized ;
      private bool GXt_boolean1 ;
      private bool returnInSub ;
      private bool BRK612 ;
      private bool n459ListaCostosId ;
      private bool BRK614 ;
      private string AV48OptionsJson ;
      private string AV49OptionsDescJson ;
      private string AV50OptionIndexesJson ;
      private string AV25TFCentroCostosEstado_SelsJson ;
      private string AV27TFCentroCostosTipoRef_SelsJson ;
      private string AV45DDOName ;
      private string AV46SearchTxtParms ;
      private string AV47SearchTxtTo ;
      private string AV29SearchTxt ;
      private string AV51FilterFullText ;
      private string AV34Option ;
      private IGxSession AV40Session ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GxSimpleCollection<string> AV35Options ;
      private GxSimpleCollection<string> AV37OptionsDesc ;
      private GxSimpleCollection<string> AV38OptionIndexes ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV42GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV43GridStateFilterValue ;
      private GxSimpleCollection<string> AV26TFCentroCostosEstado_Sels ;
      private GxSimpleCollection<string> AV28TFCentroCostosTipoRef_Sels ;
      private IDataStoreProvider pr_default ;
      private long[] P00612_A459ListaCostosId ;
      private bool[] P00612_n459ListaCostosId ;
      private string[] P00612_A463CentroCostosNombre ;
      private DateTime[] P00612_A480CentroCostosHoraAlt ;
      private string[] P00612_A487CentroCostosTipoRef ;
      private string[] P00612_A482CentroCostosEstado ;
      private string[] P00612_A478CentroCostosUsrAlta ;
      private decimal[] P00612_A475CentroCostosCosto ;
      private decimal[] P00612_A464CentroCostosPrecioFinal ;
      private long[] P00612_A462CentroCostosRef ;
      private long[] P00612_A461CentroCostosId ;
      private long[] P00612_A466CentroCostosDetallesId ;
      private long[] P00613_A459ListaCostosId ;
      private bool[] P00613_n459ListaCostosId ;
      private string[] P00613_A478CentroCostosUsrAlta ;
      private DateTime[] P00613_A480CentroCostosHoraAlt ;
      private string[] P00613_A487CentroCostosTipoRef ;
      private string[] P00613_A482CentroCostosEstado ;
      private decimal[] P00613_A475CentroCostosCosto ;
      private decimal[] P00613_A464CentroCostosPrecioFinal ;
      private string[] P00613_A463CentroCostosNombre ;
      private long[] P00613_A462CentroCostosRef ;
      private long[] P00613_A461CentroCostosId ;
      private long[] P00613_A466CentroCostosDetallesId ;
      private string aP3_OptionsJson ;
      private string aP4_OptionsDescJson ;
      private string aP5_OptionIndexesJson ;
   }

   public class listacostosdetalleswcgetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00612( IGxContext context ,
                                             string A482CentroCostosEstado ,
                                             GxSimpleCollection<string> AV26TFCentroCostosEstado_Sels ,
                                             string A487CentroCostosTipoRef ,
                                             GxSimpleCollection<string> AV28TFCentroCostosTipoRef_Sels ,
                                             long AV11TFCentroCostosId ,
                                             long AV12TFCentroCostosId_To ,
                                             long AV13TFCentroCostosRef ,
                                             long AV14TFCentroCostosRef_To ,
                                             string AV16TFCentroCostosNombre_Sel ,
                                             string AV15TFCentroCostosNombre ,
                                             decimal AV17TFCentroCostosPrecioFinal ,
                                             decimal AV18TFCentroCostosPrecioFinal_To ,
                                             decimal AV19TFCentroCostosCosto ,
                                             decimal AV20TFCentroCostosCosto_To ,
                                             string AV22TFCentroCostosUsrAlta_Sel ,
                                             string AV21TFCentroCostosUsrAlta ,
                                             DateTime AV23TFCentroCostosHoraAlt ,
                                             DateTime AV24TFCentroCostosHoraAlt_To ,
                                             int AV26TFCentroCostosEstado_Sels_Count ,
                                             int AV28TFCentroCostosTipoRef_Sels_Count ,
                                             long A461CentroCostosId ,
                                             long A462CentroCostosRef ,
                                             string A463CentroCostosNombre ,
                                             decimal A464CentroCostosPrecioFinal ,
                                             decimal A475CentroCostosCosto ,
                                             string A478CentroCostosUsrAlta ,
                                             DateTime A480CentroCostosHoraAlt ,
                                             string AV51FilterFullText ,
                                             long AV52ListaCostosId ,
                                             long A459ListaCostosId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int2 = new short[15];
         Object[] GXv_Object3 = new Object[2];
         scmdbuf = "SELECT T1.[ListaCostosId], T2.[CentroCostosNombre], T2.[CentroCostosHoraAlt], T2.[CentroCostosTipoRef], T2.[CentroCostosEstado], T2.[CentroCostosUsrAlta], T2.[CentroCostosCosto], T2.[CentroCostosPrecioFinal], T2.[CentroCostosRef], T1.[CentroCostosId], T1.[CentroCostosDetallesId] FROM ([CentroCostosDetalles] T1 INNER JOIN [CentroCostos] T2 ON T2.[CentroCostosId] = T1.[CentroCostosId])";
         AddWhere(sWhereString, "(T1.[ListaCostosId] = @AV52ListaCostosId)");
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
         if ( ! (0==AV13TFCentroCostosRef) )
         {
            AddWhere(sWhereString, "(T2.[CentroCostosRef] >= @AV13TFCentroCostosRef)");
         }
         else
         {
            GXv_int2[3] = 1;
         }
         if ( ! (0==AV14TFCentroCostosRef_To) )
         {
            AddWhere(sWhereString, "(T2.[CentroCostosRef] <= @AV14TFCentroCostosRef_To)");
         }
         else
         {
            GXv_int2[4] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV16TFCentroCostosNombre_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV15TFCentroCostosNombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[CentroCostosNombre]) like UPPER(@lV15TFCentroCostosNombre))");
         }
         else
         {
            GXv_int2[5] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV16TFCentroCostosNombre_Sel)) && ! ( StringUtil.StrCmp(AV16TFCentroCostosNombre_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.[CentroCostosNombre] = @AV16TFCentroCostosNombre_Sel)");
         }
         else
         {
            GXv_int2[6] = 1;
         }
         if ( StringUtil.StrCmp(AV16TFCentroCostosNombre_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T2.[CentroCostosNombre] = ''))");
         }
         if ( ! (Convert.ToDecimal(0)==AV17TFCentroCostosPrecioFinal) )
         {
            AddWhere(sWhereString, "(T2.[CentroCostosPrecioFinal] >= @AV17TFCentroCostosPrecioFinal)");
         }
         else
         {
            GXv_int2[7] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV18TFCentroCostosPrecioFinal_To) )
         {
            AddWhere(sWhereString, "(T2.[CentroCostosPrecioFinal] <= @AV18TFCentroCostosPrecioFinal_To)");
         }
         else
         {
            GXv_int2[8] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV19TFCentroCostosCosto) )
         {
            AddWhere(sWhereString, "(T2.[CentroCostosCosto] >= @AV19TFCentroCostosCosto)");
         }
         else
         {
            GXv_int2[9] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV20TFCentroCostosCosto_To) )
         {
            AddWhere(sWhereString, "(T2.[CentroCostosCosto] <= @AV20TFCentroCostosCosto_To)");
         }
         else
         {
            GXv_int2[10] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV22TFCentroCostosUsrAlta_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV21TFCentroCostosUsrAlta)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[CentroCostosUsrAlta]) like UPPER(@lV21TFCentroCostosUsrAlta))");
         }
         else
         {
            GXv_int2[11] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV22TFCentroCostosUsrAlta_Sel)) && ! ( StringUtil.StrCmp(AV22TFCentroCostosUsrAlta_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.[CentroCostosUsrAlta] = @AV22TFCentroCostosUsrAlta_Sel)");
         }
         else
         {
            GXv_int2[12] = 1;
         }
         if ( StringUtil.StrCmp(AV22TFCentroCostosUsrAlta_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T2.[CentroCostosUsrAlta] = ''))");
         }
         if ( ! (DateTime.MinValue==AV23TFCentroCostosHoraAlt) )
         {
            AddWhere(sWhereString, "(T2.[CentroCostosHoraAlt] >= @AV23TFCentroCostosHoraAlt)");
         }
         else
         {
            GXv_int2[13] = 1;
         }
         if ( ! (DateTime.MinValue==AV24TFCentroCostosHoraAlt_To) )
         {
            AddWhere(sWhereString, "(T2.[CentroCostosHoraAlt] <= @AV24TFCentroCostosHoraAlt_To)");
         }
         else
         {
            GXv_int2[14] = 1;
         }
         if ( AV26TFCentroCostosEstado_Sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV26TFCentroCostosEstado_Sels, "T2.[CentroCostosEstado] IN (", ")")+")");
         }
         if ( AV28TFCentroCostosTipoRef_Sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV28TFCentroCostosTipoRef_Sels, "T2.[CentroCostosTipoRef] IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[ListaCostosId], T2.[CentroCostosNombre]";
         GXv_Object3[0] = scmdbuf;
         GXv_Object3[1] = GXv_int2;
         return GXv_Object3 ;
      }

      protected Object[] conditional_P00613( IGxContext context ,
                                             string A482CentroCostosEstado ,
                                             GxSimpleCollection<string> AV26TFCentroCostosEstado_Sels ,
                                             string A487CentroCostosTipoRef ,
                                             GxSimpleCollection<string> AV28TFCentroCostosTipoRef_Sels ,
                                             long AV11TFCentroCostosId ,
                                             long AV12TFCentroCostosId_To ,
                                             long AV13TFCentroCostosRef ,
                                             long AV14TFCentroCostosRef_To ,
                                             string AV16TFCentroCostosNombre_Sel ,
                                             string AV15TFCentroCostosNombre ,
                                             decimal AV17TFCentroCostosPrecioFinal ,
                                             decimal AV18TFCentroCostosPrecioFinal_To ,
                                             decimal AV19TFCentroCostosCosto ,
                                             decimal AV20TFCentroCostosCosto_To ,
                                             string AV22TFCentroCostosUsrAlta_Sel ,
                                             string AV21TFCentroCostosUsrAlta ,
                                             DateTime AV23TFCentroCostosHoraAlt ,
                                             DateTime AV24TFCentroCostosHoraAlt_To ,
                                             int AV26TFCentroCostosEstado_Sels_Count ,
                                             int AV28TFCentroCostosTipoRef_Sels_Count ,
                                             long A461CentroCostosId ,
                                             long A462CentroCostosRef ,
                                             string A463CentroCostosNombre ,
                                             decimal A464CentroCostosPrecioFinal ,
                                             decimal A475CentroCostosCosto ,
                                             string A478CentroCostosUsrAlta ,
                                             DateTime A480CentroCostosHoraAlt ,
                                             string AV51FilterFullText ,
                                             long AV52ListaCostosId ,
                                             long A459ListaCostosId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int4 = new short[15];
         Object[] GXv_Object5 = new Object[2];
         scmdbuf = "SELECT T1.[ListaCostosId], T2.[CentroCostosUsrAlta], T2.[CentroCostosHoraAlt], T2.[CentroCostosTipoRef], T2.[CentroCostosEstado], T2.[CentroCostosCosto], T2.[CentroCostosPrecioFinal], T2.[CentroCostosNombre], T2.[CentroCostosRef], T1.[CentroCostosId], T1.[CentroCostosDetallesId] FROM ([CentroCostosDetalles] T1 INNER JOIN [CentroCostos] T2 ON T2.[CentroCostosId] = T1.[CentroCostosId])";
         AddWhere(sWhereString, "(T1.[ListaCostosId] = @AV52ListaCostosId)");
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
         if ( ! (0==AV13TFCentroCostosRef) )
         {
            AddWhere(sWhereString, "(T2.[CentroCostosRef] >= @AV13TFCentroCostosRef)");
         }
         else
         {
            GXv_int4[3] = 1;
         }
         if ( ! (0==AV14TFCentroCostosRef_To) )
         {
            AddWhere(sWhereString, "(T2.[CentroCostosRef] <= @AV14TFCentroCostosRef_To)");
         }
         else
         {
            GXv_int4[4] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV16TFCentroCostosNombre_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV15TFCentroCostosNombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[CentroCostosNombre]) like UPPER(@lV15TFCentroCostosNombre))");
         }
         else
         {
            GXv_int4[5] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV16TFCentroCostosNombre_Sel)) && ! ( StringUtil.StrCmp(AV16TFCentroCostosNombre_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.[CentroCostosNombre] = @AV16TFCentroCostosNombre_Sel)");
         }
         else
         {
            GXv_int4[6] = 1;
         }
         if ( StringUtil.StrCmp(AV16TFCentroCostosNombre_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T2.[CentroCostosNombre] = ''))");
         }
         if ( ! (Convert.ToDecimal(0)==AV17TFCentroCostosPrecioFinal) )
         {
            AddWhere(sWhereString, "(T2.[CentroCostosPrecioFinal] >= @AV17TFCentroCostosPrecioFinal)");
         }
         else
         {
            GXv_int4[7] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV18TFCentroCostosPrecioFinal_To) )
         {
            AddWhere(sWhereString, "(T2.[CentroCostosPrecioFinal] <= @AV18TFCentroCostosPrecioFinal_To)");
         }
         else
         {
            GXv_int4[8] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV19TFCentroCostosCosto) )
         {
            AddWhere(sWhereString, "(T2.[CentroCostosCosto] >= @AV19TFCentroCostosCosto)");
         }
         else
         {
            GXv_int4[9] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV20TFCentroCostosCosto_To) )
         {
            AddWhere(sWhereString, "(T2.[CentroCostosCosto] <= @AV20TFCentroCostosCosto_To)");
         }
         else
         {
            GXv_int4[10] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV22TFCentroCostosUsrAlta_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV21TFCentroCostosUsrAlta)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[CentroCostosUsrAlta]) like UPPER(@lV21TFCentroCostosUsrAlta))");
         }
         else
         {
            GXv_int4[11] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV22TFCentroCostosUsrAlta_Sel)) && ! ( StringUtil.StrCmp(AV22TFCentroCostosUsrAlta_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.[CentroCostosUsrAlta] = @AV22TFCentroCostosUsrAlta_Sel)");
         }
         else
         {
            GXv_int4[12] = 1;
         }
         if ( StringUtil.StrCmp(AV22TFCentroCostosUsrAlta_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T2.[CentroCostosUsrAlta] = ''))");
         }
         if ( ! (DateTime.MinValue==AV23TFCentroCostosHoraAlt) )
         {
            AddWhere(sWhereString, "(T2.[CentroCostosHoraAlt] >= @AV23TFCentroCostosHoraAlt)");
         }
         else
         {
            GXv_int4[13] = 1;
         }
         if ( ! (DateTime.MinValue==AV24TFCentroCostosHoraAlt_To) )
         {
            AddWhere(sWhereString, "(T2.[CentroCostosHoraAlt] <= @AV24TFCentroCostosHoraAlt_To)");
         }
         else
         {
            GXv_int4[14] = 1;
         }
         if ( AV26TFCentroCostosEstado_Sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV26TFCentroCostosEstado_Sels, "T2.[CentroCostosEstado] IN (", ")")+")");
         }
         if ( AV28TFCentroCostosTipoRef_Sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV28TFCentroCostosTipoRef_Sels, "T2.[CentroCostosTipoRef] IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[ListaCostosId], T2.[CentroCostosUsrAlta]";
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
                     return conditional_P00612(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (GxSimpleCollection<string>)dynConstraints[3] , (long)dynConstraints[4] , (long)dynConstraints[5] , (long)dynConstraints[6] , (long)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (decimal)dynConstraints[10] , (decimal)dynConstraints[11] , (decimal)dynConstraints[12] , (decimal)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (DateTime)dynConstraints[16] , (DateTime)dynConstraints[17] , (int)dynConstraints[18] , (int)dynConstraints[19] , (long)dynConstraints[20] , (long)dynConstraints[21] , (string)dynConstraints[22] , (decimal)dynConstraints[23] , (decimal)dynConstraints[24] , (string)dynConstraints[25] , (DateTime)dynConstraints[26] , (string)dynConstraints[27] , (long)dynConstraints[28] , (long)dynConstraints[29] );
               case 1 :
                     return conditional_P00613(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (GxSimpleCollection<string>)dynConstraints[3] , (long)dynConstraints[4] , (long)dynConstraints[5] , (long)dynConstraints[6] , (long)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (decimal)dynConstraints[10] , (decimal)dynConstraints[11] , (decimal)dynConstraints[12] , (decimal)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (DateTime)dynConstraints[16] , (DateTime)dynConstraints[17] , (int)dynConstraints[18] , (int)dynConstraints[19] , (long)dynConstraints[20] , (long)dynConstraints[21] , (string)dynConstraints[22] , (decimal)dynConstraints[23] , (decimal)dynConstraints[24] , (string)dynConstraints[25] , (DateTime)dynConstraints[26] , (string)dynConstraints[27] , (long)dynConstraints[28] , (long)dynConstraints[29] );
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
          Object[] prmP00612;
          prmP00612 = new Object[] {
          new ParDef("@AV52ListaCostosId",GXType.Decimal,18,0) ,
          new ParDef("@AV11TFCentroCostosId",GXType.Decimal,18,0) ,
          new ParDef("@AV12TFCentroCostosId_To",GXType.Decimal,18,0) ,
          new ParDef("@AV13TFCentroCostosRef",GXType.Decimal,18,0) ,
          new ParDef("@AV14TFCentroCostosRef_To",GXType.Decimal,18,0) ,
          new ParDef("@lV15TFCentroCostosNombre",GXType.Char,80,0) ,
          new ParDef("@AV16TFCentroCostosNombre_Sel",GXType.NChar,80,0) ,
          new ParDef("@AV17TFCentroCostosPrecioFinal",GXType.Decimal,18,2) ,
          new ParDef("@AV18TFCentroCostosPrecioFinal_To",GXType.Decimal,18,2) ,
          new ParDef("@AV19TFCentroCostosCosto",GXType.Decimal,18,2) ,
          new ParDef("@AV20TFCentroCostosCosto_To",GXType.Decimal,18,2) ,
          new ParDef("@lV21TFCentroCostosUsrAlta",GXType.Char,30,0) ,
          new ParDef("@AV22TFCentroCostosUsrAlta_Sel",GXType.NChar,30,0) ,
          new ParDef("@AV23TFCentroCostosHoraAlt",GXType.Date,8,0) ,
          new ParDef("@AV24TFCentroCostosHoraAlt_To",GXType.Date,8,0)
          };
          Object[] prmP00613;
          prmP00613 = new Object[] {
          new ParDef("@AV52ListaCostosId",GXType.Decimal,18,0) ,
          new ParDef("@AV11TFCentroCostosId",GXType.Decimal,18,0) ,
          new ParDef("@AV12TFCentroCostosId_To",GXType.Decimal,18,0) ,
          new ParDef("@AV13TFCentroCostosRef",GXType.Decimal,18,0) ,
          new ParDef("@AV14TFCentroCostosRef_To",GXType.Decimal,18,0) ,
          new ParDef("@lV15TFCentroCostosNombre",GXType.Char,80,0) ,
          new ParDef("@AV16TFCentroCostosNombre_Sel",GXType.NChar,80,0) ,
          new ParDef("@AV17TFCentroCostosPrecioFinal",GXType.Decimal,18,2) ,
          new ParDef("@AV18TFCentroCostosPrecioFinal_To",GXType.Decimal,18,2) ,
          new ParDef("@AV19TFCentroCostosCosto",GXType.Decimal,18,2) ,
          new ParDef("@AV20TFCentroCostosCosto_To",GXType.Decimal,18,2) ,
          new ParDef("@lV21TFCentroCostosUsrAlta",GXType.Char,30,0) ,
          new ParDef("@AV22TFCentroCostosUsrAlta_Sel",GXType.NChar,30,0) ,
          new ParDef("@AV23TFCentroCostosHoraAlt",GXType.Date,8,0) ,
          new ParDef("@AV24TFCentroCostosHoraAlt_To",GXType.Date,8,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00612", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00612,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00613", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00613,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[4])[0] = rslt.getString(4, 1);
                ((string[]) buf[5])[0] = rslt.getString(5, 3);
                ((string[]) buf[6])[0] = rslt.getString(6, 30);
                ((decimal[]) buf[7])[0] = rslt.getDecimal(7);
                ((decimal[]) buf[8])[0] = rslt.getDecimal(8);
                ((long[]) buf[9])[0] = rslt.getLong(9);
                ((long[]) buf[10])[0] = rslt.getLong(10);
                ((long[]) buf[11])[0] = rslt.getLong(11);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getString(2, 30);
                ((DateTime[]) buf[3])[0] = rslt.getGXDate(3);
                ((string[]) buf[4])[0] = rslt.getString(4, 1);
                ((string[]) buf[5])[0] = rslt.getString(5, 3);
                ((decimal[]) buf[6])[0] = rslt.getDecimal(6);
                ((decimal[]) buf[7])[0] = rslt.getDecimal(7);
                ((string[]) buf[8])[0] = rslt.getString(8, 80);
                ((long[]) buf[9])[0] = rslt.getLong(9);
                ((long[]) buf[10])[0] = rslt.getLong(10);
                ((long[]) buf[11])[0] = rslt.getLong(11);
                return;
       }
    }

 }

 [ServiceContract(Namespace = "GeneXus.Programs.listacostosdetalleswcgetfilterdata_services")]
 [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple)]
 [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
 public class listacostosdetalleswcgetfilterdata_services : GxRestService
 {
    [OperationContract(Name = "ListaCostosDetallesWCGetFilterData" )]
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
          if ( ! ProcessHeaders("listacostosdetalleswcgetfilterdata") )
          {
             return  ;
          }
          listacostosdetalleswcgetfilterdata worker = new listacostosdetalleswcgetfilterdata(context);
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

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
   public class historicosolicitudesitemswcgetfilterdata : GXProcedure
   {
      public historicosolicitudesitemswcgetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public historicosolicitudesitemswcgetfilterdata( IGxContext context )
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
         new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWHistoricoSolicitudes", out  GXt_boolean1) ;
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
            if ( StringUtil.StrCmp(StringUtil.Upper( AV53DDOName), "DDO_HITEMSRUBROSNOMBRE") == 0 )
            {
               /* Execute user subroutine: 'LOADHITEMSRUBROSNOMBREOPTIONS' */
               S121 ();
               if ( returnInSub )
               {
                  cleanup();
                  if (true) return;
               }
            }
            else if ( StringUtil.StrCmp(StringUtil.Upper( AV53DDOName), "DDO_HITEMSINVENTARIONOMBRE") == 0 )
            {
               /* Execute user subroutine: 'LOADHITEMSINVENTARIONOMBREOPTIONS' */
               S131 ();
               if ( returnInSub )
               {
                  cleanup();
                  if (true) return;
               }
            }
            else if ( StringUtil.StrCmp(StringUtil.Upper( AV53DDOName), "DDO_HISTORICOSOLICITUDESITEMSSR") == 0 )
            {
               /* Execute user subroutine: 'LOADHISTORICOSOLICITUDESITEMSSROPTIONS' */
               S141 ();
               if ( returnInSub )
               {
                  cleanup();
                  if (true) return;
               }
            }
            else if ( StringUtil.StrCmp(StringUtil.Upper( AV53DDOName), "DDO_HISTORICOSOLICITUDESITEMSCT") == 0 )
            {
               /* Execute user subroutine: 'LOADHISTORICOSOLICITUDESITEMSCTOPTIONS' */
               S151 ();
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
         if ( StringUtil.StrCmp(AV48Session.Get("HistoricoSolicitudesItemsWCGridState"), "") == 0 )
         {
            AV50GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "HistoricoSolicitudesItemsWCGridState"), null, "", "");
         }
         else
         {
            AV50GridState.FromXml(AV48Session.Get("HistoricoSolicitudesItemsWCGridState"), null, "", "");
         }
         AV60GXV1 = 1;
         while ( AV60GXV1 <= AV50GridState.gxTpr_Filtervalues.Count )
         {
            AV51GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV50GridState.gxTpr_Filtervalues.Item(AV60GXV1));
            if ( StringUtil.StrCmp(AV51GridStateFilterValue.gxTpr_Name, "TFHISTORICOSOLICITUDESITEMSID") == 0 )
            {
               AV11TFHistoricoSolicitudesItemsID = (short)(Math.Round(NumberUtil.Val( AV51GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV12TFHistoricoSolicitudesItemsID_To = (short)(Math.Round(NumberUtil.Val( AV51GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV51GridStateFilterValue.gxTpr_Name, "TFHITEMSRUBROSID") == 0 )
            {
               AV13TFHItemsRubrosId = (long)(Math.Round(NumberUtil.Val( AV51GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV14TFHItemsRubrosId_To = (long)(Math.Round(NumberUtil.Val( AV51GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV51GridStateFilterValue.gxTpr_Name, "TFHITEMSRUBROSNOMBRE") == 0 )
            {
               AV15TFHItemsRubrosNombre = AV51GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV51GridStateFilterValue.gxTpr_Name, "TFHITEMSRUBROSNOMBRE_SEL") == 0 )
            {
               AV16TFHItemsRubrosNombre_Sel = AV51GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV51GridStateFilterValue.gxTpr_Name, "TFHITEMSMEDIDASID") == 0 )
            {
               AV17TFHItemsMedidasID = (long)(Math.Round(NumberUtil.Val( AV51GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV18TFHItemsMedidasID_To = (long)(Math.Round(NumberUtil.Val( AV51GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV51GridStateFilterValue.gxTpr_Name, "TFHITEMSINVENTARIOID") == 0 )
            {
               AV19TFHItemsInventarioId = (long)(Math.Round(NumberUtil.Val( AV51GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV20TFHItemsInventarioId_To = (long)(Math.Round(NumberUtil.Val( AV51GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV51GridStateFilterValue.gxTpr_Name, "TFHITEMSINVENTARIONOMBRE") == 0 )
            {
               AV21TFHItemsInventarioNombre = AV51GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV51GridStateFilterValue.gxTpr_Name, "TFHITEMSINVENTARIONOMBRE_SEL") == 0 )
            {
               AV22TFHItemsInventarioNombre_Sel = AV51GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV51GridStateFilterValue.gxTpr_Name, "TFHITEMSINVENTARIOPRECIOFINAL") == 0 )
            {
               AV23TFHItemsInventarioPrecioFinal = (short)(Math.Round(NumberUtil.Val( AV51GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV24TFHItemsInventarioPrecioFinal_To = (short)(Math.Round(NumberUtil.Val( AV51GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV51GridStateFilterValue.gxTpr_Name, "TFHITEMSSOLICITUDESITEMSCANTIDAD") == 0 )
            {
               AV25TFHItemsSolicitudesItemsCantidad = (short)(Math.Round(NumberUtil.Val( AV51GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV26TFHItemsSolicitudesItemsCantidad_To = (short)(Math.Round(NumberUtil.Val( AV51GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV51GridStateFilterValue.gxTpr_Name, "TFHITEMSSOLICITUDESITEMSPRECIOINSTALACION") == 0 )
            {
               AV27TFHItemsSolicitudesItemsPrecioInstalacion = NumberUtil.Val( AV51GridStateFilterValue.gxTpr_Value, ".");
               AV28TFHItemsSolicitudesItemsPrecioInstalacion_To = NumberUtil.Val( AV51GridStateFilterValue.gxTpr_Valueto, ".");
            }
            else if ( StringUtil.StrCmp(AV51GridStateFilterValue.gxTpr_Name, "TFHITEMSSOLICITUDESMONEDAID") == 0 )
            {
               AV29TFHItemsSolicitudesMonedaId = (long)(Math.Round(NumberUtil.Val( AV51GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV30TFHItemsSolicitudesMonedaId_To = (long)(Math.Round(NumberUtil.Val( AV51GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV51GridStateFilterValue.gxTpr_Name, "TFHISTORICOSOLICITUDESITEMSSR") == 0 )
            {
               AV31TFHistoricoSolicitudesItemsSR = AV51GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV51GridStateFilterValue.gxTpr_Name, "TFHISTORICOSOLICITUDESITEMSSR_SEL") == 0 )
            {
               AV32TFHistoricoSolicitudesItemsSR_Sel = AV51GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV51GridStateFilterValue.gxTpr_Name, "TFHISTORICOSOLICITUDESITEMSCT") == 0 )
            {
               AV33TFHistoricoSolicitudesItemsCT = AV51GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV51GridStateFilterValue.gxTpr_Name, "TFHISTORICOSOLICITUDESITEMSCT_SEL") == 0 )
            {
               AV34TFHistoricoSolicitudesItemsCT_Sel = AV51GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV51GridStateFilterValue.gxTpr_Name, "TFHISTORICOSOLICITUDESITEMSCOMISION") == 0 )
            {
               AV35TFHistoricoSolicitudesItemsComision = NumberUtil.Val( AV51GridStateFilterValue.gxTpr_Value, ".");
               AV36TFHistoricoSolicitudesItemsComision_To = NumberUtil.Val( AV51GridStateFilterValue.gxTpr_Valueto, ".");
            }
            else if ( StringUtil.StrCmp(AV51GridStateFilterValue.gxTpr_Name, "PARM_&HISTORICOSOLICITUDESID") == 0 )
            {
               AV59HistoricoSolicitudesID = (long)(Math.Round(NumberUtil.Val( AV51GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
            }
            AV60GXV1 = (int)(AV60GXV1+1);
         }
      }

      protected void S121( )
      {
         /* 'LOADHITEMSRUBROSNOMBREOPTIONS' Routine */
         returnInSub = false;
         AV15TFHItemsRubrosNombre = AV37SearchTxt;
         AV16TFHItemsRubrosNombre_Sel = "";
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV11TFHistoricoSolicitudesItemsID ,
                                              AV12TFHistoricoSolicitudesItemsID_To ,
                                              AV13TFHItemsRubrosId ,
                                              AV14TFHItemsRubrosId_To ,
                                              AV16TFHItemsRubrosNombre_Sel ,
                                              AV15TFHItemsRubrosNombre ,
                                              AV17TFHItemsMedidasID ,
                                              AV18TFHItemsMedidasID_To ,
                                              AV19TFHItemsInventarioId ,
                                              AV20TFHItemsInventarioId_To ,
                                              AV22TFHItemsInventarioNombre_Sel ,
                                              AV21TFHItemsInventarioNombre ,
                                              AV23TFHItemsInventarioPrecioFinal ,
                                              AV24TFHItemsInventarioPrecioFinal_To ,
                                              AV25TFHItemsSolicitudesItemsCantidad ,
                                              AV26TFHItemsSolicitudesItemsCantidad_To ,
                                              AV29TFHItemsSolicitudesMonedaId ,
                                              AV30TFHItemsSolicitudesMonedaId_To ,
                                              AV32TFHistoricoSolicitudesItemsSR_Sel ,
                                              AV31TFHistoricoSolicitudesItemsSR ,
                                              AV34TFHistoricoSolicitudesItemsCT_Sel ,
                                              AV33TFHistoricoSolicitudesItemsCT ,
                                              AV35TFHistoricoSolicitudesItemsComision ,
                                              AV36TFHistoricoSolicitudesItemsComision_To ,
                                              A154HistoricoSolicitudesItemsID ,
                                              A330HItemsRubrosId ,
                                              A331HItemsRubrosNombre ,
                                              A327HItemsMedidasID ,
                                              A328HItemsInventarioId ,
                                              A329HItemsInventarioNombre ,
                                              A295HItemsInventarioPrecioFinal ,
                                              A293HItemsSolicitudesItemsCantidad ,
                                              A319HItemsSolicitudesMonedaId ,
                                              A296HistoricoSolicitudesItemsSR ,
                                              A297HistoricoSolicitudesItemsCT ,
                                              A298HistoricoSolicitudesItemsComis ,
                                              AV27TFHItemsSolicitudesItemsPrecioInstalacion ,
                                              A294HItemsSolicitudesItemsPrecioIn ,
                                              AV28TFHItemsSolicitudesItemsPrecioInstalacion_To ,
                                              AV59HistoricoSolicitudesID ,
                                              A153HistoricoSolicitudesID } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.SHORT, TypeConstants.SHORT,
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG,
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.LONG, TypeConstants.LONG
                                              }
         });
         lV15TFHItemsRubrosNombre = StringUtil.PadR( StringUtil.RTrim( AV15TFHItemsRubrosNombre), 100, "%");
         lV21TFHItemsInventarioNombre = StringUtil.PadR( StringUtil.RTrim( AV21TFHItemsInventarioNombre), 100, "%");
         lV31TFHistoricoSolicitudesItemsSR = StringUtil.PadR( StringUtil.RTrim( AV31TFHistoricoSolicitudesItemsSR), 1, "%");
         lV33TFHistoricoSolicitudesItemsCT = StringUtil.PadR( StringUtil.RTrim( AV33TFHistoricoSolicitudesItemsCT), 1, "%");
         /* Using cursor P004O2 */
         pr_default.execute(0, new Object[] {AV59HistoricoSolicitudesID, AV11TFHistoricoSolicitudesItemsID, AV12TFHistoricoSolicitudesItemsID_To, AV13TFHItemsRubrosId, AV14TFHItemsRubrosId_To, lV15TFHItemsRubrosNombre, AV16TFHItemsRubrosNombre_Sel, AV17TFHItemsMedidasID, AV18TFHItemsMedidasID_To, AV19TFHItemsInventarioId, AV20TFHItemsInventarioId_To, lV21TFHItemsInventarioNombre, AV22TFHItemsInventarioNombre_Sel, AV23TFHItemsInventarioPrecioFinal, AV24TFHItemsInventarioPrecioFinal_To, AV25TFHItemsSolicitudesItemsCantidad, AV26TFHItemsSolicitudesItemsCantidad_To, AV29TFHItemsSolicitudesMonedaId, AV30TFHItemsSolicitudesMonedaId_To, lV31TFHistoricoSolicitudesItemsSR, AV32TFHistoricoSolicitudesItemsSR_Sel, lV33TFHistoricoSolicitudesItemsCT, AV34TFHistoricoSolicitudesItemsCT_Sel, AV35TFHistoricoSolicitudesItemsComision, AV36TFHistoricoSolicitudesItemsComision_To});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRK4O2 = false;
            A153HistoricoSolicitudesID = P004O2_A153HistoricoSolicitudesID[0];
            A331HItemsRubrosNombre = P004O2_A331HItemsRubrosNombre[0];
            A319HItemsSolicitudesMonedaId = P004O2_A319HItemsSolicitudesMonedaId[0];
            A329HItemsInventarioNombre = P004O2_A329HItemsInventarioNombre[0];
            A328HItemsInventarioId = P004O2_A328HItemsInventarioId[0];
            A327HItemsMedidasID = P004O2_A327HItemsMedidasID[0];
            A330HItemsRubrosId = P004O2_A330HItemsRubrosId[0];
            A154HistoricoSolicitudesItemsID = P004O2_A154HistoricoSolicitudesItemsID[0];
            A298HistoricoSolicitudesItemsComis = P004O2_A298HistoricoSolicitudesItemsComis[0];
            A297HistoricoSolicitudesItemsCT = P004O2_A297HistoricoSolicitudesItemsCT[0];
            A296HistoricoSolicitudesItemsSR = P004O2_A296HistoricoSolicitudesItemsSR[0];
            A293HItemsSolicitudesItemsCantidad = P004O2_A293HItemsSolicitudesItemsCantidad[0];
            A295HItemsInventarioPrecioFinal = P004O2_A295HItemsInventarioPrecioFinal[0];
            if ( String.IsNullOrEmpty(StringUtil.RTrim( A296HistoricoSolicitudesItemsSR)) || ( StringUtil.StrCmp(A297HistoricoSolicitudesItemsCT, context.GetMessage( "N", "")) == 0 ) )
            {
               A294HItemsSolicitudesItemsPrecioIn = (decimal)(A295HItemsInventarioPrecioFinal*A293HItemsSolicitudesItemsCantidad);
            }
            else
            {
               if ( ( StringUtil.StrCmp(A297HistoricoSolicitudesItemsCT, context.GetMessage( "F", "")) == 0 ) && ( StringUtil.StrCmp(A296HistoricoSolicitudesItemsSR, context.GetMessage( "R", "")) == 0 ) )
               {
                  A294HItemsSolicitudesItemsPrecioIn = (decimal)((A295HItemsInventarioPrecioFinal*A293HItemsSolicitudesItemsCantidad)-(A298HistoricoSolicitudesItemsComis*A293HItemsSolicitudesItemsCantidad));
               }
               else
               {
                  if ( ( StringUtil.StrCmp(A297HistoricoSolicitudesItemsCT, context.GetMessage( "F", "")) == 0 ) && ( StringUtil.StrCmp(A296HistoricoSolicitudesItemsSR, context.GetMessage( "S", "")) == 0 ) )
                  {
                     A294HItemsSolicitudesItemsPrecioIn = (decimal)((A295HItemsInventarioPrecioFinal*A293HItemsSolicitudesItemsCantidad)+(A298HistoricoSolicitudesItemsComis*A293HItemsSolicitudesItemsCantidad));
                  }
                  else
                  {
                     if ( ( StringUtil.StrCmp(A297HistoricoSolicitudesItemsCT, context.GetMessage( "P", "")) == 0 ) && ( StringUtil.StrCmp(A296HistoricoSolicitudesItemsSR, context.GetMessage( "R", "")) == 0 ) )
                     {
                        A294HItemsSolicitudesItemsPrecioIn = (decimal)((A295HItemsInventarioPrecioFinal*A293HItemsSolicitudesItemsCantidad)-((A295HItemsInventarioPrecioFinal*A293HItemsSolicitudesItemsCantidad)*(A298HistoricoSolicitudesItemsComis/ (decimal)(100))));
                     }
                     else
                     {
                        if ( ( StringUtil.StrCmp(A297HistoricoSolicitudesItemsCT, context.GetMessage( "P", "")) == 0 ) && ( StringUtil.StrCmp(A296HistoricoSolicitudesItemsSR, context.GetMessage( "S", "")) == 0 ) )
                        {
                           A294HItemsSolicitudesItemsPrecioIn = (decimal)((A295HItemsInventarioPrecioFinal*A293HItemsSolicitudesItemsCantidad)+((A295HItemsInventarioPrecioFinal*A293HItemsSolicitudesItemsCantidad)*(A298HistoricoSolicitudesItemsComis/ (decimal)(100))));
                        }
                        else
                        {
                           A294HItemsSolicitudesItemsPrecioIn = 0;
                        }
                     }
                  }
               }
            }
            if ( (Convert.ToDecimal(0)==AV27TFHItemsSolicitudesItemsPrecioInstalacion) || ( ( A294HItemsSolicitudesItemsPrecioIn >= AV27TFHItemsSolicitudesItemsPrecioInstalacion ) ) )
            {
               if ( (Convert.ToDecimal(0)==AV28TFHItemsSolicitudesItemsPrecioInstalacion_To) || ( ( A294HItemsSolicitudesItemsPrecioIn <= AV28TFHItemsSolicitudesItemsPrecioInstalacion_To ) ) )
               {
                  AV47count = 0;
                  while ( (pr_default.getStatus(0) != 101) && ( P004O2_A153HistoricoSolicitudesID[0] == A153HistoricoSolicitudesID ) && ( StringUtil.StrCmp(P004O2_A331HItemsRubrosNombre[0], A331HItemsRubrosNombre) == 0 ) )
                  {
                     BRK4O2 = false;
                     A154HistoricoSolicitudesItemsID = P004O2_A154HistoricoSolicitudesItemsID[0];
                     AV47count = (long)(AV47count+1);
                     BRK4O2 = true;
                     pr_default.readNext(0);
                  }
                  if ( (0==AV38SkipItems) )
                  {
                     AV42Option = (String.IsNullOrEmpty(StringUtil.RTrim( A331HItemsRubrosNombre)) ? "<#Empty#>" : A331HItemsRubrosNombre);
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
            }
            if ( ! BRK4O2 )
            {
               BRK4O2 = true;
               pr_default.readNext(0);
            }
         }
         pr_default.close(0);
      }

      protected void S131( )
      {
         /* 'LOADHITEMSINVENTARIONOMBREOPTIONS' Routine */
         returnInSub = false;
         AV21TFHItemsInventarioNombre = AV37SearchTxt;
         AV22TFHItemsInventarioNombre_Sel = "";
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              AV11TFHistoricoSolicitudesItemsID ,
                                              AV12TFHistoricoSolicitudesItemsID_To ,
                                              AV13TFHItemsRubrosId ,
                                              AV14TFHItemsRubrosId_To ,
                                              AV16TFHItemsRubrosNombre_Sel ,
                                              AV15TFHItemsRubrosNombre ,
                                              AV17TFHItemsMedidasID ,
                                              AV18TFHItemsMedidasID_To ,
                                              AV19TFHItemsInventarioId ,
                                              AV20TFHItemsInventarioId_To ,
                                              AV22TFHItemsInventarioNombre_Sel ,
                                              AV21TFHItemsInventarioNombre ,
                                              AV23TFHItemsInventarioPrecioFinal ,
                                              AV24TFHItemsInventarioPrecioFinal_To ,
                                              AV25TFHItemsSolicitudesItemsCantidad ,
                                              AV26TFHItemsSolicitudesItemsCantidad_To ,
                                              AV29TFHItemsSolicitudesMonedaId ,
                                              AV30TFHItemsSolicitudesMonedaId_To ,
                                              AV32TFHistoricoSolicitudesItemsSR_Sel ,
                                              AV31TFHistoricoSolicitudesItemsSR ,
                                              AV34TFHistoricoSolicitudesItemsCT_Sel ,
                                              AV33TFHistoricoSolicitudesItemsCT ,
                                              AV35TFHistoricoSolicitudesItemsComision ,
                                              AV36TFHistoricoSolicitudesItemsComision_To ,
                                              A154HistoricoSolicitudesItemsID ,
                                              A330HItemsRubrosId ,
                                              A331HItemsRubrosNombre ,
                                              A327HItemsMedidasID ,
                                              A328HItemsInventarioId ,
                                              A329HItemsInventarioNombre ,
                                              A295HItemsInventarioPrecioFinal ,
                                              A293HItemsSolicitudesItemsCantidad ,
                                              A319HItemsSolicitudesMonedaId ,
                                              A296HistoricoSolicitudesItemsSR ,
                                              A297HistoricoSolicitudesItemsCT ,
                                              A298HistoricoSolicitudesItemsComis ,
                                              AV27TFHItemsSolicitudesItemsPrecioInstalacion ,
                                              A294HItemsSolicitudesItemsPrecioIn ,
                                              AV28TFHItemsSolicitudesItemsPrecioInstalacion_To ,
                                              AV59HistoricoSolicitudesID ,
                                              A153HistoricoSolicitudesID } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.SHORT, TypeConstants.SHORT,
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG,
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.LONG, TypeConstants.LONG
                                              }
         });
         lV15TFHItemsRubrosNombre = StringUtil.PadR( StringUtil.RTrim( AV15TFHItemsRubrosNombre), 100, "%");
         lV21TFHItemsInventarioNombre = StringUtil.PadR( StringUtil.RTrim( AV21TFHItemsInventarioNombre), 100, "%");
         lV31TFHistoricoSolicitudesItemsSR = StringUtil.PadR( StringUtil.RTrim( AV31TFHistoricoSolicitudesItemsSR), 1, "%");
         lV33TFHistoricoSolicitudesItemsCT = StringUtil.PadR( StringUtil.RTrim( AV33TFHistoricoSolicitudesItemsCT), 1, "%");
         /* Using cursor P004O3 */
         pr_default.execute(1, new Object[] {AV59HistoricoSolicitudesID, AV11TFHistoricoSolicitudesItemsID, AV12TFHistoricoSolicitudesItemsID_To, AV13TFHItemsRubrosId, AV14TFHItemsRubrosId_To, lV15TFHItemsRubrosNombre, AV16TFHItemsRubrosNombre_Sel, AV17TFHItemsMedidasID, AV18TFHItemsMedidasID_To, AV19TFHItemsInventarioId, AV20TFHItemsInventarioId_To, lV21TFHItemsInventarioNombre, AV22TFHItemsInventarioNombre_Sel, AV23TFHItemsInventarioPrecioFinal, AV24TFHItemsInventarioPrecioFinal_To, AV25TFHItemsSolicitudesItemsCantidad, AV26TFHItemsSolicitudesItemsCantidad_To, AV29TFHItemsSolicitudesMonedaId, AV30TFHItemsSolicitudesMonedaId_To, lV31TFHistoricoSolicitudesItemsSR, AV32TFHistoricoSolicitudesItemsSR_Sel, lV33TFHistoricoSolicitudesItemsCT, AV34TFHistoricoSolicitudesItemsCT_Sel, AV35TFHistoricoSolicitudesItemsComision, AV36TFHistoricoSolicitudesItemsComision_To});
         while ( (pr_default.getStatus(1) != 101) )
         {
            BRK4O4 = false;
            A153HistoricoSolicitudesID = P004O3_A153HistoricoSolicitudesID[0];
            A329HItemsInventarioNombre = P004O3_A329HItemsInventarioNombre[0];
            A319HItemsSolicitudesMonedaId = P004O3_A319HItemsSolicitudesMonedaId[0];
            A328HItemsInventarioId = P004O3_A328HItemsInventarioId[0];
            A327HItemsMedidasID = P004O3_A327HItemsMedidasID[0];
            A331HItemsRubrosNombre = P004O3_A331HItemsRubrosNombre[0];
            A330HItemsRubrosId = P004O3_A330HItemsRubrosId[0];
            A154HistoricoSolicitudesItemsID = P004O3_A154HistoricoSolicitudesItemsID[0];
            A298HistoricoSolicitudesItemsComis = P004O3_A298HistoricoSolicitudesItemsComis[0];
            A297HistoricoSolicitudesItemsCT = P004O3_A297HistoricoSolicitudesItemsCT[0];
            A296HistoricoSolicitudesItemsSR = P004O3_A296HistoricoSolicitudesItemsSR[0];
            A293HItemsSolicitudesItemsCantidad = P004O3_A293HItemsSolicitudesItemsCantidad[0];
            A295HItemsInventarioPrecioFinal = P004O3_A295HItemsInventarioPrecioFinal[0];
            if ( String.IsNullOrEmpty(StringUtil.RTrim( A296HistoricoSolicitudesItemsSR)) || ( StringUtil.StrCmp(A297HistoricoSolicitudesItemsCT, context.GetMessage( "N", "")) == 0 ) )
            {
               A294HItemsSolicitudesItemsPrecioIn = (decimal)(A295HItemsInventarioPrecioFinal*A293HItemsSolicitudesItemsCantidad);
            }
            else
            {
               if ( ( StringUtil.StrCmp(A297HistoricoSolicitudesItemsCT, context.GetMessage( "F", "")) == 0 ) && ( StringUtil.StrCmp(A296HistoricoSolicitudesItemsSR, context.GetMessage( "R", "")) == 0 ) )
               {
                  A294HItemsSolicitudesItemsPrecioIn = (decimal)((A295HItemsInventarioPrecioFinal*A293HItemsSolicitudesItemsCantidad)-(A298HistoricoSolicitudesItemsComis*A293HItemsSolicitudesItemsCantidad));
               }
               else
               {
                  if ( ( StringUtil.StrCmp(A297HistoricoSolicitudesItemsCT, context.GetMessage( "F", "")) == 0 ) && ( StringUtil.StrCmp(A296HistoricoSolicitudesItemsSR, context.GetMessage( "S", "")) == 0 ) )
                  {
                     A294HItemsSolicitudesItemsPrecioIn = (decimal)((A295HItemsInventarioPrecioFinal*A293HItemsSolicitudesItemsCantidad)+(A298HistoricoSolicitudesItemsComis*A293HItemsSolicitudesItemsCantidad));
                  }
                  else
                  {
                     if ( ( StringUtil.StrCmp(A297HistoricoSolicitudesItemsCT, context.GetMessage( "P", "")) == 0 ) && ( StringUtil.StrCmp(A296HistoricoSolicitudesItemsSR, context.GetMessage( "R", "")) == 0 ) )
                     {
                        A294HItemsSolicitudesItemsPrecioIn = (decimal)((A295HItemsInventarioPrecioFinal*A293HItemsSolicitudesItemsCantidad)-((A295HItemsInventarioPrecioFinal*A293HItemsSolicitudesItemsCantidad)*(A298HistoricoSolicitudesItemsComis/ (decimal)(100))));
                     }
                     else
                     {
                        if ( ( StringUtil.StrCmp(A297HistoricoSolicitudesItemsCT, context.GetMessage( "P", "")) == 0 ) && ( StringUtil.StrCmp(A296HistoricoSolicitudesItemsSR, context.GetMessage( "S", "")) == 0 ) )
                        {
                           A294HItemsSolicitudesItemsPrecioIn = (decimal)((A295HItemsInventarioPrecioFinal*A293HItemsSolicitudesItemsCantidad)+((A295HItemsInventarioPrecioFinal*A293HItemsSolicitudesItemsCantidad)*(A298HistoricoSolicitudesItemsComis/ (decimal)(100))));
                        }
                        else
                        {
                           A294HItemsSolicitudesItemsPrecioIn = 0;
                        }
                     }
                  }
               }
            }
            if ( (Convert.ToDecimal(0)==AV27TFHItemsSolicitudesItemsPrecioInstalacion) || ( ( A294HItemsSolicitudesItemsPrecioIn >= AV27TFHItemsSolicitudesItemsPrecioInstalacion ) ) )
            {
               if ( (Convert.ToDecimal(0)==AV28TFHItemsSolicitudesItemsPrecioInstalacion_To) || ( ( A294HItemsSolicitudesItemsPrecioIn <= AV28TFHItemsSolicitudesItemsPrecioInstalacion_To ) ) )
               {
                  AV47count = 0;
                  while ( (pr_default.getStatus(1) != 101) && ( P004O3_A153HistoricoSolicitudesID[0] == A153HistoricoSolicitudesID ) && ( StringUtil.StrCmp(P004O3_A329HItemsInventarioNombre[0], A329HItemsInventarioNombre) == 0 ) )
                  {
                     BRK4O4 = false;
                     A154HistoricoSolicitudesItemsID = P004O3_A154HistoricoSolicitudesItemsID[0];
                     AV47count = (long)(AV47count+1);
                     BRK4O4 = true;
                     pr_default.readNext(1);
                  }
                  if ( (0==AV38SkipItems) )
                  {
                     AV42Option = (String.IsNullOrEmpty(StringUtil.RTrim( A329HItemsInventarioNombre)) ? "<#Empty#>" : A329HItemsInventarioNombre);
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
            }
            if ( ! BRK4O4 )
            {
               BRK4O4 = true;
               pr_default.readNext(1);
            }
         }
         pr_default.close(1);
      }

      protected void S141( )
      {
         /* 'LOADHISTORICOSOLICITUDESITEMSSROPTIONS' Routine */
         returnInSub = false;
         AV31TFHistoricoSolicitudesItemsSR = AV37SearchTxt;
         AV32TFHistoricoSolicitudesItemsSR_Sel = "";
         pr_default.dynParam(2, new Object[]{ new Object[]{
                                              AV11TFHistoricoSolicitudesItemsID ,
                                              AV12TFHistoricoSolicitudesItemsID_To ,
                                              AV13TFHItemsRubrosId ,
                                              AV14TFHItemsRubrosId_To ,
                                              AV16TFHItemsRubrosNombre_Sel ,
                                              AV15TFHItemsRubrosNombre ,
                                              AV17TFHItemsMedidasID ,
                                              AV18TFHItemsMedidasID_To ,
                                              AV19TFHItemsInventarioId ,
                                              AV20TFHItemsInventarioId_To ,
                                              AV22TFHItemsInventarioNombre_Sel ,
                                              AV21TFHItemsInventarioNombre ,
                                              AV23TFHItemsInventarioPrecioFinal ,
                                              AV24TFHItemsInventarioPrecioFinal_To ,
                                              AV25TFHItemsSolicitudesItemsCantidad ,
                                              AV26TFHItemsSolicitudesItemsCantidad_To ,
                                              AV29TFHItemsSolicitudesMonedaId ,
                                              AV30TFHItemsSolicitudesMonedaId_To ,
                                              AV32TFHistoricoSolicitudesItemsSR_Sel ,
                                              AV31TFHistoricoSolicitudesItemsSR ,
                                              AV34TFHistoricoSolicitudesItemsCT_Sel ,
                                              AV33TFHistoricoSolicitudesItemsCT ,
                                              AV35TFHistoricoSolicitudesItemsComision ,
                                              AV36TFHistoricoSolicitudesItemsComision_To ,
                                              A154HistoricoSolicitudesItemsID ,
                                              A330HItemsRubrosId ,
                                              A331HItemsRubrosNombre ,
                                              A327HItemsMedidasID ,
                                              A328HItemsInventarioId ,
                                              A329HItemsInventarioNombre ,
                                              A295HItemsInventarioPrecioFinal ,
                                              A293HItemsSolicitudesItemsCantidad ,
                                              A319HItemsSolicitudesMonedaId ,
                                              A296HistoricoSolicitudesItemsSR ,
                                              A297HistoricoSolicitudesItemsCT ,
                                              A298HistoricoSolicitudesItemsComis ,
                                              AV27TFHItemsSolicitudesItemsPrecioInstalacion ,
                                              A294HItemsSolicitudesItemsPrecioIn ,
                                              AV28TFHItemsSolicitudesItemsPrecioInstalacion_To ,
                                              AV59HistoricoSolicitudesID ,
                                              A153HistoricoSolicitudesID } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.SHORT, TypeConstants.SHORT,
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG,
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.LONG, TypeConstants.LONG
                                              }
         });
         lV15TFHItemsRubrosNombre = StringUtil.PadR( StringUtil.RTrim( AV15TFHItemsRubrosNombre), 100, "%");
         lV21TFHItemsInventarioNombre = StringUtil.PadR( StringUtil.RTrim( AV21TFHItemsInventarioNombre), 100, "%");
         lV31TFHistoricoSolicitudesItemsSR = StringUtil.PadR( StringUtil.RTrim( AV31TFHistoricoSolicitudesItemsSR), 1, "%");
         lV33TFHistoricoSolicitudesItemsCT = StringUtil.PadR( StringUtil.RTrim( AV33TFHistoricoSolicitudesItemsCT), 1, "%");
         /* Using cursor P004O4 */
         pr_default.execute(2, new Object[] {AV59HistoricoSolicitudesID, AV11TFHistoricoSolicitudesItemsID, AV12TFHistoricoSolicitudesItemsID_To, AV13TFHItemsRubrosId, AV14TFHItemsRubrosId_To, lV15TFHItemsRubrosNombre, AV16TFHItemsRubrosNombre_Sel, AV17TFHItemsMedidasID, AV18TFHItemsMedidasID_To, AV19TFHItemsInventarioId, AV20TFHItemsInventarioId_To, lV21TFHItemsInventarioNombre, AV22TFHItemsInventarioNombre_Sel, AV23TFHItemsInventarioPrecioFinal, AV24TFHItemsInventarioPrecioFinal_To, AV25TFHItemsSolicitudesItemsCantidad, AV26TFHItemsSolicitudesItemsCantidad_To, AV29TFHItemsSolicitudesMonedaId, AV30TFHItemsSolicitudesMonedaId_To, lV31TFHistoricoSolicitudesItemsSR, AV32TFHistoricoSolicitudesItemsSR_Sel, lV33TFHistoricoSolicitudesItemsCT, AV34TFHistoricoSolicitudesItemsCT_Sel, AV35TFHistoricoSolicitudesItemsComision, AV36TFHistoricoSolicitudesItemsComision_To});
         while ( (pr_default.getStatus(2) != 101) )
         {
            BRK4O6 = false;
            A153HistoricoSolicitudesID = P004O4_A153HistoricoSolicitudesID[0];
            A319HItemsSolicitudesMonedaId = P004O4_A319HItemsSolicitudesMonedaId[0];
            A329HItemsInventarioNombre = P004O4_A329HItemsInventarioNombre[0];
            A328HItemsInventarioId = P004O4_A328HItemsInventarioId[0];
            A327HItemsMedidasID = P004O4_A327HItemsMedidasID[0];
            A331HItemsRubrosNombre = P004O4_A331HItemsRubrosNombre[0];
            A330HItemsRubrosId = P004O4_A330HItemsRubrosId[0];
            A154HistoricoSolicitudesItemsID = P004O4_A154HistoricoSolicitudesItemsID[0];
            A298HistoricoSolicitudesItemsComis = P004O4_A298HistoricoSolicitudesItemsComis[0];
            A297HistoricoSolicitudesItemsCT = P004O4_A297HistoricoSolicitudesItemsCT[0];
            A296HistoricoSolicitudesItemsSR = P004O4_A296HistoricoSolicitudesItemsSR[0];
            A293HItemsSolicitudesItemsCantidad = P004O4_A293HItemsSolicitudesItemsCantidad[0];
            A295HItemsInventarioPrecioFinal = P004O4_A295HItemsInventarioPrecioFinal[0];
            if ( String.IsNullOrEmpty(StringUtil.RTrim( A296HistoricoSolicitudesItemsSR)) || ( StringUtil.StrCmp(A297HistoricoSolicitudesItemsCT, context.GetMessage( "N", "")) == 0 ) )
            {
               A294HItemsSolicitudesItemsPrecioIn = (decimal)(A295HItemsInventarioPrecioFinal*A293HItemsSolicitudesItemsCantidad);
            }
            else
            {
               if ( ( StringUtil.StrCmp(A297HistoricoSolicitudesItemsCT, context.GetMessage( "F", "")) == 0 ) && ( StringUtil.StrCmp(A296HistoricoSolicitudesItemsSR, context.GetMessage( "R", "")) == 0 ) )
               {
                  A294HItemsSolicitudesItemsPrecioIn = (decimal)((A295HItemsInventarioPrecioFinal*A293HItemsSolicitudesItemsCantidad)-(A298HistoricoSolicitudesItemsComis*A293HItemsSolicitudesItemsCantidad));
               }
               else
               {
                  if ( ( StringUtil.StrCmp(A297HistoricoSolicitudesItemsCT, context.GetMessage( "F", "")) == 0 ) && ( StringUtil.StrCmp(A296HistoricoSolicitudesItemsSR, context.GetMessage( "S", "")) == 0 ) )
                  {
                     A294HItemsSolicitudesItemsPrecioIn = (decimal)((A295HItemsInventarioPrecioFinal*A293HItemsSolicitudesItemsCantidad)+(A298HistoricoSolicitudesItemsComis*A293HItemsSolicitudesItemsCantidad));
                  }
                  else
                  {
                     if ( ( StringUtil.StrCmp(A297HistoricoSolicitudesItemsCT, context.GetMessage( "P", "")) == 0 ) && ( StringUtil.StrCmp(A296HistoricoSolicitudesItemsSR, context.GetMessage( "R", "")) == 0 ) )
                     {
                        A294HItemsSolicitudesItemsPrecioIn = (decimal)((A295HItemsInventarioPrecioFinal*A293HItemsSolicitudesItemsCantidad)-((A295HItemsInventarioPrecioFinal*A293HItemsSolicitudesItemsCantidad)*(A298HistoricoSolicitudesItemsComis/ (decimal)(100))));
                     }
                     else
                     {
                        if ( ( StringUtil.StrCmp(A297HistoricoSolicitudesItemsCT, context.GetMessage( "P", "")) == 0 ) && ( StringUtil.StrCmp(A296HistoricoSolicitudesItemsSR, context.GetMessage( "S", "")) == 0 ) )
                        {
                           A294HItemsSolicitudesItemsPrecioIn = (decimal)((A295HItemsInventarioPrecioFinal*A293HItemsSolicitudesItemsCantidad)+((A295HItemsInventarioPrecioFinal*A293HItemsSolicitudesItemsCantidad)*(A298HistoricoSolicitudesItemsComis/ (decimal)(100))));
                        }
                        else
                        {
                           A294HItemsSolicitudesItemsPrecioIn = 0;
                        }
                     }
                  }
               }
            }
            if ( (Convert.ToDecimal(0)==AV27TFHItemsSolicitudesItemsPrecioInstalacion) || ( ( A294HItemsSolicitudesItemsPrecioIn >= AV27TFHItemsSolicitudesItemsPrecioInstalacion ) ) )
            {
               if ( (Convert.ToDecimal(0)==AV28TFHItemsSolicitudesItemsPrecioInstalacion_To) || ( ( A294HItemsSolicitudesItemsPrecioIn <= AV28TFHItemsSolicitudesItemsPrecioInstalacion_To ) ) )
               {
                  AV47count = 0;
                  while ( (pr_default.getStatus(2) != 101) && ( P004O4_A153HistoricoSolicitudesID[0] == A153HistoricoSolicitudesID ) && ( StringUtil.StrCmp(P004O4_A296HistoricoSolicitudesItemsSR[0], A296HistoricoSolicitudesItemsSR) == 0 ) )
                  {
                     BRK4O6 = false;
                     A154HistoricoSolicitudesItemsID = P004O4_A154HistoricoSolicitudesItemsID[0];
                     AV47count = (long)(AV47count+1);
                     BRK4O6 = true;
                     pr_default.readNext(2);
                  }
                  if ( (0==AV38SkipItems) )
                  {
                     AV42Option = (String.IsNullOrEmpty(StringUtil.RTrim( A296HistoricoSolicitudesItemsSR)) ? "<#Empty#>" : A296HistoricoSolicitudesItemsSR);
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
            }
            if ( ! BRK4O6 )
            {
               BRK4O6 = true;
               pr_default.readNext(2);
            }
         }
         pr_default.close(2);
      }

      protected void S151( )
      {
         /* 'LOADHISTORICOSOLICITUDESITEMSCTOPTIONS' Routine */
         returnInSub = false;
         AV33TFHistoricoSolicitudesItemsCT = AV37SearchTxt;
         AV34TFHistoricoSolicitudesItemsCT_Sel = "";
         pr_default.dynParam(3, new Object[]{ new Object[]{
                                              AV11TFHistoricoSolicitudesItemsID ,
                                              AV12TFHistoricoSolicitudesItemsID_To ,
                                              AV13TFHItemsRubrosId ,
                                              AV14TFHItemsRubrosId_To ,
                                              AV16TFHItemsRubrosNombre_Sel ,
                                              AV15TFHItemsRubrosNombre ,
                                              AV17TFHItemsMedidasID ,
                                              AV18TFHItemsMedidasID_To ,
                                              AV19TFHItemsInventarioId ,
                                              AV20TFHItemsInventarioId_To ,
                                              AV22TFHItemsInventarioNombre_Sel ,
                                              AV21TFHItemsInventarioNombre ,
                                              AV23TFHItemsInventarioPrecioFinal ,
                                              AV24TFHItemsInventarioPrecioFinal_To ,
                                              AV25TFHItemsSolicitudesItemsCantidad ,
                                              AV26TFHItemsSolicitudesItemsCantidad_To ,
                                              AV29TFHItemsSolicitudesMonedaId ,
                                              AV30TFHItemsSolicitudesMonedaId_To ,
                                              AV32TFHistoricoSolicitudesItemsSR_Sel ,
                                              AV31TFHistoricoSolicitudesItemsSR ,
                                              AV34TFHistoricoSolicitudesItemsCT_Sel ,
                                              AV33TFHistoricoSolicitudesItemsCT ,
                                              AV35TFHistoricoSolicitudesItemsComision ,
                                              AV36TFHistoricoSolicitudesItemsComision_To ,
                                              A154HistoricoSolicitudesItemsID ,
                                              A330HItemsRubrosId ,
                                              A331HItemsRubrosNombre ,
                                              A327HItemsMedidasID ,
                                              A328HItemsInventarioId ,
                                              A329HItemsInventarioNombre ,
                                              A295HItemsInventarioPrecioFinal ,
                                              A293HItemsSolicitudesItemsCantidad ,
                                              A319HItemsSolicitudesMonedaId ,
                                              A296HistoricoSolicitudesItemsSR ,
                                              A297HistoricoSolicitudesItemsCT ,
                                              A298HistoricoSolicitudesItemsComis ,
                                              AV27TFHItemsSolicitudesItemsPrecioInstalacion ,
                                              A294HItemsSolicitudesItemsPrecioIn ,
                                              AV28TFHItemsSolicitudesItemsPrecioInstalacion_To ,
                                              AV59HistoricoSolicitudesID ,
                                              A153HistoricoSolicitudesID } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.SHORT, TypeConstants.SHORT,
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG,
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.LONG, TypeConstants.LONG
                                              }
         });
         lV15TFHItemsRubrosNombre = StringUtil.PadR( StringUtil.RTrim( AV15TFHItemsRubrosNombre), 100, "%");
         lV21TFHItemsInventarioNombre = StringUtil.PadR( StringUtil.RTrim( AV21TFHItemsInventarioNombre), 100, "%");
         lV31TFHistoricoSolicitudesItemsSR = StringUtil.PadR( StringUtil.RTrim( AV31TFHistoricoSolicitudesItemsSR), 1, "%");
         lV33TFHistoricoSolicitudesItemsCT = StringUtil.PadR( StringUtil.RTrim( AV33TFHistoricoSolicitudesItemsCT), 1, "%");
         /* Using cursor P004O5 */
         pr_default.execute(3, new Object[] {AV59HistoricoSolicitudesID, AV11TFHistoricoSolicitudesItemsID, AV12TFHistoricoSolicitudesItemsID_To, AV13TFHItemsRubrosId, AV14TFHItemsRubrosId_To, lV15TFHItemsRubrosNombre, AV16TFHItemsRubrosNombre_Sel, AV17TFHItemsMedidasID, AV18TFHItemsMedidasID_To, AV19TFHItemsInventarioId, AV20TFHItemsInventarioId_To, lV21TFHItemsInventarioNombre, AV22TFHItemsInventarioNombre_Sel, AV23TFHItemsInventarioPrecioFinal, AV24TFHItemsInventarioPrecioFinal_To, AV25TFHItemsSolicitudesItemsCantidad, AV26TFHItemsSolicitudesItemsCantidad_To, AV29TFHItemsSolicitudesMonedaId, AV30TFHItemsSolicitudesMonedaId_To, lV31TFHistoricoSolicitudesItemsSR, AV32TFHistoricoSolicitudesItemsSR_Sel, lV33TFHistoricoSolicitudesItemsCT, AV34TFHistoricoSolicitudesItemsCT_Sel, AV35TFHistoricoSolicitudesItemsComision, AV36TFHistoricoSolicitudesItemsComision_To});
         while ( (pr_default.getStatus(3) != 101) )
         {
            BRK4O8 = false;
            A153HistoricoSolicitudesID = P004O5_A153HistoricoSolicitudesID[0];
            A319HItemsSolicitudesMonedaId = P004O5_A319HItemsSolicitudesMonedaId[0];
            A329HItemsInventarioNombre = P004O5_A329HItemsInventarioNombre[0];
            A328HItemsInventarioId = P004O5_A328HItemsInventarioId[0];
            A327HItemsMedidasID = P004O5_A327HItemsMedidasID[0];
            A331HItemsRubrosNombre = P004O5_A331HItemsRubrosNombre[0];
            A330HItemsRubrosId = P004O5_A330HItemsRubrosId[0];
            A154HistoricoSolicitudesItemsID = P004O5_A154HistoricoSolicitudesItemsID[0];
            A298HistoricoSolicitudesItemsComis = P004O5_A298HistoricoSolicitudesItemsComis[0];
            A297HistoricoSolicitudesItemsCT = P004O5_A297HistoricoSolicitudesItemsCT[0];
            A296HistoricoSolicitudesItemsSR = P004O5_A296HistoricoSolicitudesItemsSR[0];
            A293HItemsSolicitudesItemsCantidad = P004O5_A293HItemsSolicitudesItemsCantidad[0];
            A295HItemsInventarioPrecioFinal = P004O5_A295HItemsInventarioPrecioFinal[0];
            if ( String.IsNullOrEmpty(StringUtil.RTrim( A296HistoricoSolicitudesItemsSR)) || ( StringUtil.StrCmp(A297HistoricoSolicitudesItemsCT, context.GetMessage( "N", "")) == 0 ) )
            {
               A294HItemsSolicitudesItemsPrecioIn = (decimal)(A295HItemsInventarioPrecioFinal*A293HItemsSolicitudesItemsCantidad);
            }
            else
            {
               if ( ( StringUtil.StrCmp(A297HistoricoSolicitudesItemsCT, context.GetMessage( "F", "")) == 0 ) && ( StringUtil.StrCmp(A296HistoricoSolicitudesItemsSR, context.GetMessage( "R", "")) == 0 ) )
               {
                  A294HItemsSolicitudesItemsPrecioIn = (decimal)((A295HItemsInventarioPrecioFinal*A293HItemsSolicitudesItemsCantidad)-(A298HistoricoSolicitudesItemsComis*A293HItemsSolicitudesItemsCantidad));
               }
               else
               {
                  if ( ( StringUtil.StrCmp(A297HistoricoSolicitudesItemsCT, context.GetMessage( "F", "")) == 0 ) && ( StringUtil.StrCmp(A296HistoricoSolicitudesItemsSR, context.GetMessage( "S", "")) == 0 ) )
                  {
                     A294HItemsSolicitudesItemsPrecioIn = (decimal)((A295HItemsInventarioPrecioFinal*A293HItemsSolicitudesItemsCantidad)+(A298HistoricoSolicitudesItemsComis*A293HItemsSolicitudesItemsCantidad));
                  }
                  else
                  {
                     if ( ( StringUtil.StrCmp(A297HistoricoSolicitudesItemsCT, context.GetMessage( "P", "")) == 0 ) && ( StringUtil.StrCmp(A296HistoricoSolicitudesItemsSR, context.GetMessage( "R", "")) == 0 ) )
                     {
                        A294HItemsSolicitudesItemsPrecioIn = (decimal)((A295HItemsInventarioPrecioFinal*A293HItemsSolicitudesItemsCantidad)-((A295HItemsInventarioPrecioFinal*A293HItemsSolicitudesItemsCantidad)*(A298HistoricoSolicitudesItemsComis/ (decimal)(100))));
                     }
                     else
                     {
                        if ( ( StringUtil.StrCmp(A297HistoricoSolicitudesItemsCT, context.GetMessage( "P", "")) == 0 ) && ( StringUtil.StrCmp(A296HistoricoSolicitudesItemsSR, context.GetMessage( "S", "")) == 0 ) )
                        {
                           A294HItemsSolicitudesItemsPrecioIn = (decimal)((A295HItemsInventarioPrecioFinal*A293HItemsSolicitudesItemsCantidad)+((A295HItemsInventarioPrecioFinal*A293HItemsSolicitudesItemsCantidad)*(A298HistoricoSolicitudesItemsComis/ (decimal)(100))));
                        }
                        else
                        {
                           A294HItemsSolicitudesItemsPrecioIn = 0;
                        }
                     }
                  }
               }
            }
            if ( (Convert.ToDecimal(0)==AV27TFHItemsSolicitudesItemsPrecioInstalacion) || ( ( A294HItemsSolicitudesItemsPrecioIn >= AV27TFHItemsSolicitudesItemsPrecioInstalacion ) ) )
            {
               if ( (Convert.ToDecimal(0)==AV28TFHItemsSolicitudesItemsPrecioInstalacion_To) || ( ( A294HItemsSolicitudesItemsPrecioIn <= AV28TFHItemsSolicitudesItemsPrecioInstalacion_To ) ) )
               {
                  AV47count = 0;
                  while ( (pr_default.getStatus(3) != 101) && ( P004O5_A153HistoricoSolicitudesID[0] == A153HistoricoSolicitudesID ) && ( StringUtil.StrCmp(P004O5_A297HistoricoSolicitudesItemsCT[0], A297HistoricoSolicitudesItemsCT) == 0 ) )
                  {
                     BRK4O8 = false;
                     A154HistoricoSolicitudesItemsID = P004O5_A154HistoricoSolicitudesItemsID[0];
                     AV47count = (long)(AV47count+1);
                     BRK4O8 = true;
                     pr_default.readNext(3);
                  }
                  if ( (0==AV38SkipItems) )
                  {
                     AV42Option = (String.IsNullOrEmpty(StringUtil.RTrim( A297HistoricoSolicitudesItemsCT)) ? "<#Empty#>" : A297HistoricoSolicitudesItemsCT);
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
            }
            if ( ! BRK4O8 )
            {
               BRK4O8 = true;
               pr_default.readNext(3);
            }
         }
         pr_default.close(3);
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
         AV15TFHItemsRubrosNombre = "";
         AV16TFHItemsRubrosNombre_Sel = "";
         AV21TFHItemsInventarioNombre = "";
         AV22TFHItemsInventarioNombre_Sel = "";
         AV31TFHistoricoSolicitudesItemsSR = "";
         AV32TFHistoricoSolicitudesItemsSR_Sel = "";
         AV33TFHistoricoSolicitudesItemsCT = "";
         AV34TFHistoricoSolicitudesItemsCT_Sel = "";
         lV15TFHItemsRubrosNombre = "";
         lV21TFHItemsInventarioNombre = "";
         lV31TFHistoricoSolicitudesItemsSR = "";
         lV33TFHistoricoSolicitudesItemsCT = "";
         A331HItemsRubrosNombre = "";
         A329HItemsInventarioNombre = "";
         A296HistoricoSolicitudesItemsSR = "";
         A297HistoricoSolicitudesItemsCT = "";
         P004O2_A153HistoricoSolicitudesID = new long[1] ;
         P004O2_A331HItemsRubrosNombre = new string[] {""} ;
         P004O2_A319HItemsSolicitudesMonedaId = new long[1] ;
         P004O2_A329HItemsInventarioNombre = new string[] {""} ;
         P004O2_A328HItemsInventarioId = new long[1] ;
         P004O2_A327HItemsMedidasID = new long[1] ;
         P004O2_A330HItemsRubrosId = new long[1] ;
         P004O2_A154HistoricoSolicitudesItemsID = new short[1] ;
         P004O2_A298HistoricoSolicitudesItemsComis = new decimal[1] ;
         P004O2_A297HistoricoSolicitudesItemsCT = new string[] {""} ;
         P004O2_A296HistoricoSolicitudesItemsSR = new string[] {""} ;
         P004O2_A293HItemsSolicitudesItemsCantidad = new short[1] ;
         P004O2_A295HItemsInventarioPrecioFinal = new short[1] ;
         AV42Option = "";
         P004O3_A153HistoricoSolicitudesID = new long[1] ;
         P004O3_A329HItemsInventarioNombre = new string[] {""} ;
         P004O3_A319HItemsSolicitudesMonedaId = new long[1] ;
         P004O3_A328HItemsInventarioId = new long[1] ;
         P004O3_A327HItemsMedidasID = new long[1] ;
         P004O3_A331HItemsRubrosNombre = new string[] {""} ;
         P004O3_A330HItemsRubrosId = new long[1] ;
         P004O3_A154HistoricoSolicitudesItemsID = new short[1] ;
         P004O3_A298HistoricoSolicitudesItemsComis = new decimal[1] ;
         P004O3_A297HistoricoSolicitudesItemsCT = new string[] {""} ;
         P004O3_A296HistoricoSolicitudesItemsSR = new string[] {""} ;
         P004O3_A293HItemsSolicitudesItemsCantidad = new short[1] ;
         P004O3_A295HItemsInventarioPrecioFinal = new short[1] ;
         P004O4_A153HistoricoSolicitudesID = new long[1] ;
         P004O4_A319HItemsSolicitudesMonedaId = new long[1] ;
         P004O4_A329HItemsInventarioNombre = new string[] {""} ;
         P004O4_A328HItemsInventarioId = new long[1] ;
         P004O4_A327HItemsMedidasID = new long[1] ;
         P004O4_A331HItemsRubrosNombre = new string[] {""} ;
         P004O4_A330HItemsRubrosId = new long[1] ;
         P004O4_A154HistoricoSolicitudesItemsID = new short[1] ;
         P004O4_A298HistoricoSolicitudesItemsComis = new decimal[1] ;
         P004O4_A297HistoricoSolicitudesItemsCT = new string[] {""} ;
         P004O4_A296HistoricoSolicitudesItemsSR = new string[] {""} ;
         P004O4_A293HItemsSolicitudesItemsCantidad = new short[1] ;
         P004O4_A295HItemsInventarioPrecioFinal = new short[1] ;
         P004O5_A153HistoricoSolicitudesID = new long[1] ;
         P004O5_A319HItemsSolicitudesMonedaId = new long[1] ;
         P004O5_A329HItemsInventarioNombre = new string[] {""} ;
         P004O5_A328HItemsInventarioId = new long[1] ;
         P004O5_A327HItemsMedidasID = new long[1] ;
         P004O5_A331HItemsRubrosNombre = new string[] {""} ;
         P004O5_A330HItemsRubrosId = new long[1] ;
         P004O5_A154HistoricoSolicitudesItemsID = new short[1] ;
         P004O5_A298HistoricoSolicitudesItemsComis = new decimal[1] ;
         P004O5_A297HistoricoSolicitudesItemsCT = new string[] {""} ;
         P004O5_A296HistoricoSolicitudesItemsSR = new string[] {""} ;
         P004O5_A293HItemsSolicitudesItemsCantidad = new short[1] ;
         P004O5_A295HItemsInventarioPrecioFinal = new short[1] ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.historicosolicitudesitemswcgetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P004O2_A153HistoricoSolicitudesID, P004O2_A331HItemsRubrosNombre, P004O2_A319HItemsSolicitudesMonedaId, P004O2_A329HItemsInventarioNombre, P004O2_A328HItemsInventarioId, P004O2_A327HItemsMedidasID, P004O2_A330HItemsRubrosId, P004O2_A154HistoricoSolicitudesItemsID, P004O2_A298HistoricoSolicitudesItemsComis, P004O2_A297HistoricoSolicitudesItemsCT,
               P004O2_A296HistoricoSolicitudesItemsSR, P004O2_A293HItemsSolicitudesItemsCantidad, P004O2_A295HItemsInventarioPrecioFinal
               }
               , new Object[] {
               P004O3_A153HistoricoSolicitudesID, P004O3_A329HItemsInventarioNombre, P004O3_A319HItemsSolicitudesMonedaId, P004O3_A328HItemsInventarioId, P004O3_A327HItemsMedidasID, P004O3_A331HItemsRubrosNombre, P004O3_A330HItemsRubrosId, P004O3_A154HistoricoSolicitudesItemsID, P004O3_A298HistoricoSolicitudesItemsComis, P004O3_A297HistoricoSolicitudesItemsCT,
               P004O3_A296HistoricoSolicitudesItemsSR, P004O3_A293HItemsSolicitudesItemsCantidad, P004O3_A295HItemsInventarioPrecioFinal
               }
               , new Object[] {
               P004O4_A153HistoricoSolicitudesID, P004O4_A319HItemsSolicitudesMonedaId, P004O4_A329HItemsInventarioNombre, P004O4_A328HItemsInventarioId, P004O4_A327HItemsMedidasID, P004O4_A331HItemsRubrosNombre, P004O4_A330HItemsRubrosId, P004O4_A154HistoricoSolicitudesItemsID, P004O4_A298HistoricoSolicitudesItemsComis, P004O4_A297HistoricoSolicitudesItemsCT,
               P004O4_A296HistoricoSolicitudesItemsSR, P004O4_A293HItemsSolicitudesItemsCantidad, P004O4_A295HItemsInventarioPrecioFinal
               }
               , new Object[] {
               P004O5_A153HistoricoSolicitudesID, P004O5_A319HItemsSolicitudesMonedaId, P004O5_A329HItemsInventarioNombre, P004O5_A328HItemsInventarioId, P004O5_A327HItemsMedidasID, P004O5_A331HItemsRubrosNombre, P004O5_A330HItemsRubrosId, P004O5_A154HistoricoSolicitudesItemsID, P004O5_A298HistoricoSolicitudesItemsComis, P004O5_A297HistoricoSolicitudesItemsCT,
               P004O5_A296HistoricoSolicitudesItemsSR, P004O5_A293HItemsSolicitudesItemsCantidad, P004O5_A295HItemsInventarioPrecioFinal
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV40MaxItems ;
      private short AV39PageIndex ;
      private short AV38SkipItems ;
      private short AV11TFHistoricoSolicitudesItemsID ;
      private short AV12TFHistoricoSolicitudesItemsID_To ;
      private short AV23TFHItemsInventarioPrecioFinal ;
      private short AV24TFHItemsInventarioPrecioFinal_To ;
      private short AV25TFHItemsSolicitudesItemsCantidad ;
      private short AV26TFHItemsSolicitudesItemsCantidad_To ;
      private short A154HistoricoSolicitudesItemsID ;
      private short A295HItemsInventarioPrecioFinal ;
      private short A293HItemsSolicitudesItemsCantidad ;
      private int AV60GXV1 ;
      private long AV13TFHItemsRubrosId ;
      private long AV14TFHItemsRubrosId_To ;
      private long AV17TFHItemsMedidasID ;
      private long AV18TFHItemsMedidasID_To ;
      private long AV19TFHItemsInventarioId ;
      private long AV20TFHItemsInventarioId_To ;
      private long AV29TFHItemsSolicitudesMonedaId ;
      private long AV30TFHItemsSolicitudesMonedaId_To ;
      private long AV59HistoricoSolicitudesID ;
      private long A330HItemsRubrosId ;
      private long A327HItemsMedidasID ;
      private long A328HItemsInventarioId ;
      private long A319HItemsSolicitudesMonedaId ;
      private long A153HistoricoSolicitudesID ;
      private long AV47count ;
      private decimal AV27TFHItemsSolicitudesItemsPrecioInstalacion ;
      private decimal AV28TFHItemsSolicitudesItemsPrecioInstalacion_To ;
      private decimal AV35TFHistoricoSolicitudesItemsComision ;
      private decimal AV36TFHistoricoSolicitudesItemsComision_To ;
      private decimal A298HistoricoSolicitudesItemsComis ;
      private decimal A294HItemsSolicitudesItemsPrecioIn ;
      private string AV15TFHItemsRubrosNombre ;
      private string AV16TFHItemsRubrosNombre_Sel ;
      private string AV21TFHItemsInventarioNombre ;
      private string AV22TFHItemsInventarioNombre_Sel ;
      private string AV31TFHistoricoSolicitudesItemsSR ;
      private string AV32TFHistoricoSolicitudesItemsSR_Sel ;
      private string AV33TFHistoricoSolicitudesItemsCT ;
      private string AV34TFHistoricoSolicitudesItemsCT_Sel ;
      private string lV15TFHItemsRubrosNombre ;
      private string lV21TFHItemsInventarioNombre ;
      private string lV31TFHistoricoSolicitudesItemsSR ;
      private string lV33TFHistoricoSolicitudesItemsCT ;
      private string A331HItemsRubrosNombre ;
      private string A329HItemsInventarioNombre ;
      private string A296HistoricoSolicitudesItemsSR ;
      private string A297HistoricoSolicitudesItemsCT ;
      private bool AV8IsAuthorized ;
      private bool GXt_boolean1 ;
      private bool returnInSub ;
      private bool BRK4O2 ;
      private bool BRK4O4 ;
      private bool BRK4O6 ;
      private bool BRK4O8 ;
      private string AV56OptionsJson ;
      private string AV57OptionsDescJson ;
      private string AV58OptionIndexesJson ;
      private string AV53DDOName ;
      private string AV54SearchTxtParms ;
      private string AV55SearchTxtTo ;
      private string AV37SearchTxt ;
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
      private IDataStoreProvider pr_default ;
      private long[] P004O2_A153HistoricoSolicitudesID ;
      private string[] P004O2_A331HItemsRubrosNombre ;
      private long[] P004O2_A319HItemsSolicitudesMonedaId ;
      private string[] P004O2_A329HItemsInventarioNombre ;
      private long[] P004O2_A328HItemsInventarioId ;
      private long[] P004O2_A327HItemsMedidasID ;
      private long[] P004O2_A330HItemsRubrosId ;
      private short[] P004O2_A154HistoricoSolicitudesItemsID ;
      private decimal[] P004O2_A298HistoricoSolicitudesItemsComis ;
      private string[] P004O2_A297HistoricoSolicitudesItemsCT ;
      private string[] P004O2_A296HistoricoSolicitudesItemsSR ;
      private short[] P004O2_A293HItemsSolicitudesItemsCantidad ;
      private short[] P004O2_A295HItemsInventarioPrecioFinal ;
      private long[] P004O3_A153HistoricoSolicitudesID ;
      private string[] P004O3_A329HItemsInventarioNombre ;
      private long[] P004O3_A319HItemsSolicitudesMonedaId ;
      private long[] P004O3_A328HItemsInventarioId ;
      private long[] P004O3_A327HItemsMedidasID ;
      private string[] P004O3_A331HItemsRubrosNombre ;
      private long[] P004O3_A330HItemsRubrosId ;
      private short[] P004O3_A154HistoricoSolicitudesItemsID ;
      private decimal[] P004O3_A298HistoricoSolicitudesItemsComis ;
      private string[] P004O3_A297HistoricoSolicitudesItemsCT ;
      private string[] P004O3_A296HistoricoSolicitudesItemsSR ;
      private short[] P004O3_A293HItemsSolicitudesItemsCantidad ;
      private short[] P004O3_A295HItemsInventarioPrecioFinal ;
      private long[] P004O4_A153HistoricoSolicitudesID ;
      private long[] P004O4_A319HItemsSolicitudesMonedaId ;
      private string[] P004O4_A329HItemsInventarioNombre ;
      private long[] P004O4_A328HItemsInventarioId ;
      private long[] P004O4_A327HItemsMedidasID ;
      private string[] P004O4_A331HItemsRubrosNombre ;
      private long[] P004O4_A330HItemsRubrosId ;
      private short[] P004O4_A154HistoricoSolicitudesItemsID ;
      private decimal[] P004O4_A298HistoricoSolicitudesItemsComis ;
      private string[] P004O4_A297HistoricoSolicitudesItemsCT ;
      private string[] P004O4_A296HistoricoSolicitudesItemsSR ;
      private short[] P004O4_A293HItemsSolicitudesItemsCantidad ;
      private short[] P004O4_A295HItemsInventarioPrecioFinal ;
      private long[] P004O5_A153HistoricoSolicitudesID ;
      private long[] P004O5_A319HItemsSolicitudesMonedaId ;
      private string[] P004O5_A329HItemsInventarioNombre ;
      private long[] P004O5_A328HItemsInventarioId ;
      private long[] P004O5_A327HItemsMedidasID ;
      private string[] P004O5_A331HItemsRubrosNombre ;
      private long[] P004O5_A330HItemsRubrosId ;
      private short[] P004O5_A154HistoricoSolicitudesItemsID ;
      private decimal[] P004O5_A298HistoricoSolicitudesItemsComis ;
      private string[] P004O5_A297HistoricoSolicitudesItemsCT ;
      private string[] P004O5_A296HistoricoSolicitudesItemsSR ;
      private short[] P004O5_A293HItemsSolicitudesItemsCantidad ;
      private short[] P004O5_A295HItemsInventarioPrecioFinal ;
      private string aP3_OptionsJson ;
      private string aP4_OptionsDescJson ;
      private string aP5_OptionIndexesJson ;
   }

   public class historicosolicitudesitemswcgetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P004O2( IGxContext context ,
                                             short AV11TFHistoricoSolicitudesItemsID ,
                                             short AV12TFHistoricoSolicitudesItemsID_To ,
                                             long AV13TFHItemsRubrosId ,
                                             long AV14TFHItemsRubrosId_To ,
                                             string AV16TFHItemsRubrosNombre_Sel ,
                                             string AV15TFHItemsRubrosNombre ,
                                             long AV17TFHItemsMedidasID ,
                                             long AV18TFHItemsMedidasID_To ,
                                             long AV19TFHItemsInventarioId ,
                                             long AV20TFHItemsInventarioId_To ,
                                             string AV22TFHItemsInventarioNombre_Sel ,
                                             string AV21TFHItemsInventarioNombre ,
                                             short AV23TFHItemsInventarioPrecioFinal ,
                                             short AV24TFHItemsInventarioPrecioFinal_To ,
                                             short AV25TFHItemsSolicitudesItemsCantidad ,
                                             short AV26TFHItemsSolicitudesItemsCantidad_To ,
                                             long AV29TFHItemsSolicitudesMonedaId ,
                                             long AV30TFHItemsSolicitudesMonedaId_To ,
                                             string AV32TFHistoricoSolicitudesItemsSR_Sel ,
                                             string AV31TFHistoricoSolicitudesItemsSR ,
                                             string AV34TFHistoricoSolicitudesItemsCT_Sel ,
                                             string AV33TFHistoricoSolicitudesItemsCT ,
                                             decimal AV35TFHistoricoSolicitudesItemsComision ,
                                             decimal AV36TFHistoricoSolicitudesItemsComision_To ,
                                             short A154HistoricoSolicitudesItemsID ,
                                             long A330HItemsRubrosId ,
                                             string A331HItemsRubrosNombre ,
                                             long A327HItemsMedidasID ,
                                             long A328HItemsInventarioId ,
                                             string A329HItemsInventarioNombre ,
                                             short A295HItemsInventarioPrecioFinal ,
                                             short A293HItemsSolicitudesItemsCantidad ,
                                             long A319HItemsSolicitudesMonedaId ,
                                             string A296HistoricoSolicitudesItemsSR ,
                                             string A297HistoricoSolicitudesItemsCT ,
                                             decimal A298HistoricoSolicitudesItemsComis ,
                                             decimal AV27TFHItemsSolicitudesItemsPrecioInstalacion ,
                                             decimal A294HItemsSolicitudesItemsPrecioIn ,
                                             decimal AV28TFHItemsSolicitudesItemsPrecioInstalacion_To ,
                                             long AV59HistoricoSolicitudesID ,
                                             long A153HistoricoSolicitudesID )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int2 = new short[25];
         Object[] GXv_Object3 = new Object[2];
         scmdbuf = "SELECT [HistoricoSolicitudesID], [HItemsRubrosNombre], [HItemsSolicitudesMonedaId], [HItemsInventarioNombre], [HItemsInventarioId], [HItemsMedidasID], [HItemsRubrosId], [HistoricoSolicitudesItemsID], [HistoricoSolicitudesItemsComis], [HistoricoSolicitudesItemsCT], [HistoricoSolicitudesItemsSR], [HItemsSolicitudesItemsCantidad], [HItemsInventarioPrecioFinal] FROM [HistoricoSolicitudesItems]";
         AddWhere(sWhereString, "([HistoricoSolicitudesID] = @AV59HistoricoSolicitudesID)");
         if ( ! (0==AV11TFHistoricoSolicitudesItemsID) )
         {
            AddWhere(sWhereString, "([HistoricoSolicitudesItemsID] >= @AV11TFHistoricoSolicitudesItemsID)");
         }
         else
         {
            GXv_int2[1] = 1;
         }
         if ( ! (0==AV12TFHistoricoSolicitudesItemsID_To) )
         {
            AddWhere(sWhereString, "([HistoricoSolicitudesItemsID] <= @AV12TFHistoricoSolicitudesItemsID_To)");
         }
         else
         {
            GXv_int2[2] = 1;
         }
         if ( ! (0==AV13TFHItemsRubrosId) )
         {
            AddWhere(sWhereString, "([HItemsRubrosId] >= @AV13TFHItemsRubrosId)");
         }
         else
         {
            GXv_int2[3] = 1;
         }
         if ( ! (0==AV14TFHItemsRubrosId_To) )
         {
            AddWhere(sWhereString, "([HItemsRubrosId] <= @AV14TFHItemsRubrosId_To)");
         }
         else
         {
            GXv_int2[4] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV16TFHItemsRubrosNombre_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV15TFHItemsRubrosNombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER([HItemsRubrosNombre]) like UPPER(@lV15TFHItemsRubrosNombre))");
         }
         else
         {
            GXv_int2[5] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV16TFHItemsRubrosNombre_Sel)) && ! ( StringUtil.StrCmp(AV16TFHItemsRubrosNombre_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([HItemsRubrosNombre] = @AV16TFHItemsRubrosNombre_Sel)");
         }
         else
         {
            GXv_int2[6] = 1;
         }
         if ( StringUtil.StrCmp(AV16TFHItemsRubrosNombre_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([HItemsRubrosNombre] = ''))");
         }
         if ( ! (0==AV17TFHItemsMedidasID) )
         {
            AddWhere(sWhereString, "([HItemsMedidasID] >= @AV17TFHItemsMedidasID)");
         }
         else
         {
            GXv_int2[7] = 1;
         }
         if ( ! (0==AV18TFHItemsMedidasID_To) )
         {
            AddWhere(sWhereString, "([HItemsMedidasID] <= @AV18TFHItemsMedidasID_To)");
         }
         else
         {
            GXv_int2[8] = 1;
         }
         if ( ! (0==AV19TFHItemsInventarioId) )
         {
            AddWhere(sWhereString, "([HItemsInventarioId] >= @AV19TFHItemsInventarioId)");
         }
         else
         {
            GXv_int2[9] = 1;
         }
         if ( ! (0==AV20TFHItemsInventarioId_To) )
         {
            AddWhere(sWhereString, "([HItemsInventarioId] <= @AV20TFHItemsInventarioId_To)");
         }
         else
         {
            GXv_int2[10] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV22TFHItemsInventarioNombre_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV21TFHItemsInventarioNombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER([HItemsInventarioNombre]) like UPPER(@lV21TFHItemsInventarioNombre))");
         }
         else
         {
            GXv_int2[11] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV22TFHItemsInventarioNombre_Sel)) && ! ( StringUtil.StrCmp(AV22TFHItemsInventarioNombre_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([HItemsInventarioNombre] = @AV22TFHItemsInventarioNombre_Sel)");
         }
         else
         {
            GXv_int2[12] = 1;
         }
         if ( StringUtil.StrCmp(AV22TFHItemsInventarioNombre_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([HItemsInventarioNombre] = ''))");
         }
         if ( ! (0==AV23TFHItemsInventarioPrecioFinal) )
         {
            AddWhere(sWhereString, "([HItemsInventarioPrecioFinal] >= @AV23TFHItemsInventarioPrecioFinal)");
         }
         else
         {
            GXv_int2[13] = 1;
         }
         if ( ! (0==AV24TFHItemsInventarioPrecioFinal_To) )
         {
            AddWhere(sWhereString, "([HItemsInventarioPrecioFinal] <= @AV24TFHItemsInventarioPrecioFinal_To)");
         }
         else
         {
            GXv_int2[14] = 1;
         }
         if ( ! (0==AV25TFHItemsSolicitudesItemsCantidad) )
         {
            AddWhere(sWhereString, "([HItemsSolicitudesItemsCantidad] >= @AV25TFHItemsSolicitudesItemsCantidad)");
         }
         else
         {
            GXv_int2[15] = 1;
         }
         if ( ! (0==AV26TFHItemsSolicitudesItemsCantidad_To) )
         {
            AddWhere(sWhereString, "([HItemsSolicitudesItemsCantidad] <= @AV26TFHItemsSolicitudesItemsCantidad_To)");
         }
         else
         {
            GXv_int2[16] = 1;
         }
         if ( ! (0==AV29TFHItemsSolicitudesMonedaId) )
         {
            AddWhere(sWhereString, "([HItemsSolicitudesMonedaId] >= @AV29TFHItemsSolicitudesMonedaId)");
         }
         else
         {
            GXv_int2[17] = 1;
         }
         if ( ! (0==AV30TFHItemsSolicitudesMonedaId_To) )
         {
            AddWhere(sWhereString, "([HItemsSolicitudesMonedaId] <= @AV30TFHItemsSolicitudesMonedaId_To)");
         }
         else
         {
            GXv_int2[18] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV32TFHistoricoSolicitudesItemsSR_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV31TFHistoricoSolicitudesItemsSR)) ) )
         {
            AddWhere(sWhereString, "(UPPER([HistoricoSolicitudesItemsSR]) like UPPER(@lV31TFHistoricoSolicitudesItemsSR))");
         }
         else
         {
            GXv_int2[19] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV32TFHistoricoSolicitudesItemsSR_Sel)) && ! ( StringUtil.StrCmp(AV32TFHistoricoSolicitudesItemsSR_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([HistoricoSolicitudesItemsSR] = @AV32TFHistoricoSolicitudesItemsSR_Sel)");
         }
         else
         {
            GXv_int2[20] = 1;
         }
         if ( StringUtil.StrCmp(AV32TFHistoricoSolicitudesItemsSR_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([HistoricoSolicitudesItemsSR] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV34TFHistoricoSolicitudesItemsCT_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV33TFHistoricoSolicitudesItemsCT)) ) )
         {
            AddWhere(sWhereString, "(UPPER([HistoricoSolicitudesItemsCT]) like UPPER(@lV33TFHistoricoSolicitudesItemsCT))");
         }
         else
         {
            GXv_int2[21] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV34TFHistoricoSolicitudesItemsCT_Sel)) && ! ( StringUtil.StrCmp(AV34TFHistoricoSolicitudesItemsCT_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([HistoricoSolicitudesItemsCT] = @AV34TFHistoricoSolicitudesItemsCT_Sel)");
         }
         else
         {
            GXv_int2[22] = 1;
         }
         if ( StringUtil.StrCmp(AV34TFHistoricoSolicitudesItemsCT_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([HistoricoSolicitudesItemsCT] = ''))");
         }
         if ( ! (Convert.ToDecimal(0)==AV35TFHistoricoSolicitudesItemsComision) )
         {
            AddWhere(sWhereString, "([HistoricoSolicitudesItemsComis] >= @AV35TFHistoricoSolicitudesItemsComision)");
         }
         else
         {
            GXv_int2[23] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV36TFHistoricoSolicitudesItemsComision_To) )
         {
            AddWhere(sWhereString, "([HistoricoSolicitudesItemsComis] <= @AV36TFHistoricoSolicitudesItemsComision_To)");
         }
         else
         {
            GXv_int2[24] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY [HistoricoSolicitudesID], [HItemsRubrosNombre]";
         GXv_Object3[0] = scmdbuf;
         GXv_Object3[1] = GXv_int2;
         return GXv_Object3 ;
      }

      protected Object[] conditional_P004O3( IGxContext context ,
                                             short AV11TFHistoricoSolicitudesItemsID ,
                                             short AV12TFHistoricoSolicitudesItemsID_To ,
                                             long AV13TFHItemsRubrosId ,
                                             long AV14TFHItemsRubrosId_To ,
                                             string AV16TFHItemsRubrosNombre_Sel ,
                                             string AV15TFHItemsRubrosNombre ,
                                             long AV17TFHItemsMedidasID ,
                                             long AV18TFHItemsMedidasID_To ,
                                             long AV19TFHItemsInventarioId ,
                                             long AV20TFHItemsInventarioId_To ,
                                             string AV22TFHItemsInventarioNombre_Sel ,
                                             string AV21TFHItemsInventarioNombre ,
                                             short AV23TFHItemsInventarioPrecioFinal ,
                                             short AV24TFHItemsInventarioPrecioFinal_To ,
                                             short AV25TFHItemsSolicitudesItemsCantidad ,
                                             short AV26TFHItemsSolicitudesItemsCantidad_To ,
                                             long AV29TFHItemsSolicitudesMonedaId ,
                                             long AV30TFHItemsSolicitudesMonedaId_To ,
                                             string AV32TFHistoricoSolicitudesItemsSR_Sel ,
                                             string AV31TFHistoricoSolicitudesItemsSR ,
                                             string AV34TFHistoricoSolicitudesItemsCT_Sel ,
                                             string AV33TFHistoricoSolicitudesItemsCT ,
                                             decimal AV35TFHistoricoSolicitudesItemsComision ,
                                             decimal AV36TFHistoricoSolicitudesItemsComision_To ,
                                             short A154HistoricoSolicitudesItemsID ,
                                             long A330HItemsRubrosId ,
                                             string A331HItemsRubrosNombre ,
                                             long A327HItemsMedidasID ,
                                             long A328HItemsInventarioId ,
                                             string A329HItemsInventarioNombre ,
                                             short A295HItemsInventarioPrecioFinal ,
                                             short A293HItemsSolicitudesItemsCantidad ,
                                             long A319HItemsSolicitudesMonedaId ,
                                             string A296HistoricoSolicitudesItemsSR ,
                                             string A297HistoricoSolicitudesItemsCT ,
                                             decimal A298HistoricoSolicitudesItemsComis ,
                                             decimal AV27TFHItemsSolicitudesItemsPrecioInstalacion ,
                                             decimal A294HItemsSolicitudesItemsPrecioIn ,
                                             decimal AV28TFHItemsSolicitudesItemsPrecioInstalacion_To ,
                                             long AV59HistoricoSolicitudesID ,
                                             long A153HistoricoSolicitudesID )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int4 = new short[25];
         Object[] GXv_Object5 = new Object[2];
         scmdbuf = "SELECT [HistoricoSolicitudesID], [HItemsInventarioNombre], [HItemsSolicitudesMonedaId], [HItemsInventarioId], [HItemsMedidasID], [HItemsRubrosNombre], [HItemsRubrosId], [HistoricoSolicitudesItemsID], [HistoricoSolicitudesItemsComis], [HistoricoSolicitudesItemsCT], [HistoricoSolicitudesItemsSR], [HItemsSolicitudesItemsCantidad], [HItemsInventarioPrecioFinal] FROM [HistoricoSolicitudesItems]";
         AddWhere(sWhereString, "([HistoricoSolicitudesID] = @AV59HistoricoSolicitudesID)");
         if ( ! (0==AV11TFHistoricoSolicitudesItemsID) )
         {
            AddWhere(sWhereString, "([HistoricoSolicitudesItemsID] >= @AV11TFHistoricoSolicitudesItemsID)");
         }
         else
         {
            GXv_int4[1] = 1;
         }
         if ( ! (0==AV12TFHistoricoSolicitudesItemsID_To) )
         {
            AddWhere(sWhereString, "([HistoricoSolicitudesItemsID] <= @AV12TFHistoricoSolicitudesItemsID_To)");
         }
         else
         {
            GXv_int4[2] = 1;
         }
         if ( ! (0==AV13TFHItemsRubrosId) )
         {
            AddWhere(sWhereString, "([HItemsRubrosId] >= @AV13TFHItemsRubrosId)");
         }
         else
         {
            GXv_int4[3] = 1;
         }
         if ( ! (0==AV14TFHItemsRubrosId_To) )
         {
            AddWhere(sWhereString, "([HItemsRubrosId] <= @AV14TFHItemsRubrosId_To)");
         }
         else
         {
            GXv_int4[4] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV16TFHItemsRubrosNombre_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV15TFHItemsRubrosNombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER([HItemsRubrosNombre]) like UPPER(@lV15TFHItemsRubrosNombre))");
         }
         else
         {
            GXv_int4[5] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV16TFHItemsRubrosNombre_Sel)) && ! ( StringUtil.StrCmp(AV16TFHItemsRubrosNombre_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([HItemsRubrosNombre] = @AV16TFHItemsRubrosNombre_Sel)");
         }
         else
         {
            GXv_int4[6] = 1;
         }
         if ( StringUtil.StrCmp(AV16TFHItemsRubrosNombre_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([HItemsRubrosNombre] = ''))");
         }
         if ( ! (0==AV17TFHItemsMedidasID) )
         {
            AddWhere(sWhereString, "([HItemsMedidasID] >= @AV17TFHItemsMedidasID)");
         }
         else
         {
            GXv_int4[7] = 1;
         }
         if ( ! (0==AV18TFHItemsMedidasID_To) )
         {
            AddWhere(sWhereString, "([HItemsMedidasID] <= @AV18TFHItemsMedidasID_To)");
         }
         else
         {
            GXv_int4[8] = 1;
         }
         if ( ! (0==AV19TFHItemsInventarioId) )
         {
            AddWhere(sWhereString, "([HItemsInventarioId] >= @AV19TFHItemsInventarioId)");
         }
         else
         {
            GXv_int4[9] = 1;
         }
         if ( ! (0==AV20TFHItemsInventarioId_To) )
         {
            AddWhere(sWhereString, "([HItemsInventarioId] <= @AV20TFHItemsInventarioId_To)");
         }
         else
         {
            GXv_int4[10] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV22TFHItemsInventarioNombre_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV21TFHItemsInventarioNombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER([HItemsInventarioNombre]) like UPPER(@lV21TFHItemsInventarioNombre))");
         }
         else
         {
            GXv_int4[11] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV22TFHItemsInventarioNombre_Sel)) && ! ( StringUtil.StrCmp(AV22TFHItemsInventarioNombre_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([HItemsInventarioNombre] = @AV22TFHItemsInventarioNombre_Sel)");
         }
         else
         {
            GXv_int4[12] = 1;
         }
         if ( StringUtil.StrCmp(AV22TFHItemsInventarioNombre_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([HItemsInventarioNombre] = ''))");
         }
         if ( ! (0==AV23TFHItemsInventarioPrecioFinal) )
         {
            AddWhere(sWhereString, "([HItemsInventarioPrecioFinal] >= @AV23TFHItemsInventarioPrecioFinal)");
         }
         else
         {
            GXv_int4[13] = 1;
         }
         if ( ! (0==AV24TFHItemsInventarioPrecioFinal_To) )
         {
            AddWhere(sWhereString, "([HItemsInventarioPrecioFinal] <= @AV24TFHItemsInventarioPrecioFinal_To)");
         }
         else
         {
            GXv_int4[14] = 1;
         }
         if ( ! (0==AV25TFHItemsSolicitudesItemsCantidad) )
         {
            AddWhere(sWhereString, "([HItemsSolicitudesItemsCantidad] >= @AV25TFHItemsSolicitudesItemsCantidad)");
         }
         else
         {
            GXv_int4[15] = 1;
         }
         if ( ! (0==AV26TFHItemsSolicitudesItemsCantidad_To) )
         {
            AddWhere(sWhereString, "([HItemsSolicitudesItemsCantidad] <= @AV26TFHItemsSolicitudesItemsCantidad_To)");
         }
         else
         {
            GXv_int4[16] = 1;
         }
         if ( ! (0==AV29TFHItemsSolicitudesMonedaId) )
         {
            AddWhere(sWhereString, "([HItemsSolicitudesMonedaId] >= @AV29TFHItemsSolicitudesMonedaId)");
         }
         else
         {
            GXv_int4[17] = 1;
         }
         if ( ! (0==AV30TFHItemsSolicitudesMonedaId_To) )
         {
            AddWhere(sWhereString, "([HItemsSolicitudesMonedaId] <= @AV30TFHItemsSolicitudesMonedaId_To)");
         }
         else
         {
            GXv_int4[18] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV32TFHistoricoSolicitudesItemsSR_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV31TFHistoricoSolicitudesItemsSR)) ) )
         {
            AddWhere(sWhereString, "(UPPER([HistoricoSolicitudesItemsSR]) like UPPER(@lV31TFHistoricoSolicitudesItemsSR))");
         }
         else
         {
            GXv_int4[19] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV32TFHistoricoSolicitudesItemsSR_Sel)) && ! ( StringUtil.StrCmp(AV32TFHistoricoSolicitudesItemsSR_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([HistoricoSolicitudesItemsSR] = @AV32TFHistoricoSolicitudesItemsSR_Sel)");
         }
         else
         {
            GXv_int4[20] = 1;
         }
         if ( StringUtil.StrCmp(AV32TFHistoricoSolicitudesItemsSR_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([HistoricoSolicitudesItemsSR] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV34TFHistoricoSolicitudesItemsCT_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV33TFHistoricoSolicitudesItemsCT)) ) )
         {
            AddWhere(sWhereString, "(UPPER([HistoricoSolicitudesItemsCT]) like UPPER(@lV33TFHistoricoSolicitudesItemsCT))");
         }
         else
         {
            GXv_int4[21] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV34TFHistoricoSolicitudesItemsCT_Sel)) && ! ( StringUtil.StrCmp(AV34TFHistoricoSolicitudesItemsCT_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([HistoricoSolicitudesItemsCT] = @AV34TFHistoricoSolicitudesItemsCT_Sel)");
         }
         else
         {
            GXv_int4[22] = 1;
         }
         if ( StringUtil.StrCmp(AV34TFHistoricoSolicitudesItemsCT_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([HistoricoSolicitudesItemsCT] = ''))");
         }
         if ( ! (Convert.ToDecimal(0)==AV35TFHistoricoSolicitudesItemsComision) )
         {
            AddWhere(sWhereString, "([HistoricoSolicitudesItemsComis] >= @AV35TFHistoricoSolicitudesItemsComision)");
         }
         else
         {
            GXv_int4[23] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV36TFHistoricoSolicitudesItemsComision_To) )
         {
            AddWhere(sWhereString, "([HistoricoSolicitudesItemsComis] <= @AV36TFHistoricoSolicitudesItemsComision_To)");
         }
         else
         {
            GXv_int4[24] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY [HistoricoSolicitudesID], [HItemsInventarioNombre]";
         GXv_Object5[0] = scmdbuf;
         GXv_Object5[1] = GXv_int4;
         return GXv_Object5 ;
      }

      protected Object[] conditional_P004O4( IGxContext context ,
                                             short AV11TFHistoricoSolicitudesItemsID ,
                                             short AV12TFHistoricoSolicitudesItemsID_To ,
                                             long AV13TFHItemsRubrosId ,
                                             long AV14TFHItemsRubrosId_To ,
                                             string AV16TFHItemsRubrosNombre_Sel ,
                                             string AV15TFHItemsRubrosNombre ,
                                             long AV17TFHItemsMedidasID ,
                                             long AV18TFHItemsMedidasID_To ,
                                             long AV19TFHItemsInventarioId ,
                                             long AV20TFHItemsInventarioId_To ,
                                             string AV22TFHItemsInventarioNombre_Sel ,
                                             string AV21TFHItemsInventarioNombre ,
                                             short AV23TFHItemsInventarioPrecioFinal ,
                                             short AV24TFHItemsInventarioPrecioFinal_To ,
                                             short AV25TFHItemsSolicitudesItemsCantidad ,
                                             short AV26TFHItemsSolicitudesItemsCantidad_To ,
                                             long AV29TFHItemsSolicitudesMonedaId ,
                                             long AV30TFHItemsSolicitudesMonedaId_To ,
                                             string AV32TFHistoricoSolicitudesItemsSR_Sel ,
                                             string AV31TFHistoricoSolicitudesItemsSR ,
                                             string AV34TFHistoricoSolicitudesItemsCT_Sel ,
                                             string AV33TFHistoricoSolicitudesItemsCT ,
                                             decimal AV35TFHistoricoSolicitudesItemsComision ,
                                             decimal AV36TFHistoricoSolicitudesItemsComision_To ,
                                             short A154HistoricoSolicitudesItemsID ,
                                             long A330HItemsRubrosId ,
                                             string A331HItemsRubrosNombre ,
                                             long A327HItemsMedidasID ,
                                             long A328HItemsInventarioId ,
                                             string A329HItemsInventarioNombre ,
                                             short A295HItemsInventarioPrecioFinal ,
                                             short A293HItemsSolicitudesItemsCantidad ,
                                             long A319HItemsSolicitudesMonedaId ,
                                             string A296HistoricoSolicitudesItemsSR ,
                                             string A297HistoricoSolicitudesItemsCT ,
                                             decimal A298HistoricoSolicitudesItemsComis ,
                                             decimal AV27TFHItemsSolicitudesItemsPrecioInstalacion ,
                                             decimal A294HItemsSolicitudesItemsPrecioIn ,
                                             decimal AV28TFHItemsSolicitudesItemsPrecioInstalacion_To ,
                                             long AV59HistoricoSolicitudesID ,
                                             long A153HistoricoSolicitudesID )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int6 = new short[25];
         Object[] GXv_Object7 = new Object[2];
         scmdbuf = "SELECT [HistoricoSolicitudesID], [HItemsSolicitudesMonedaId], [HItemsInventarioNombre], [HItemsInventarioId], [HItemsMedidasID], [HItemsRubrosNombre], [HItemsRubrosId], [HistoricoSolicitudesItemsID], [HistoricoSolicitudesItemsComis], [HistoricoSolicitudesItemsCT], [HistoricoSolicitudesItemsSR], [HItemsSolicitudesItemsCantidad], [HItemsInventarioPrecioFinal] FROM [HistoricoSolicitudesItems]";
         AddWhere(sWhereString, "([HistoricoSolicitudesID] = @AV59HistoricoSolicitudesID)");
         if ( ! (0==AV11TFHistoricoSolicitudesItemsID) )
         {
            AddWhere(sWhereString, "([HistoricoSolicitudesItemsID] >= @AV11TFHistoricoSolicitudesItemsID)");
         }
         else
         {
            GXv_int6[1] = 1;
         }
         if ( ! (0==AV12TFHistoricoSolicitudesItemsID_To) )
         {
            AddWhere(sWhereString, "([HistoricoSolicitudesItemsID] <= @AV12TFHistoricoSolicitudesItemsID_To)");
         }
         else
         {
            GXv_int6[2] = 1;
         }
         if ( ! (0==AV13TFHItemsRubrosId) )
         {
            AddWhere(sWhereString, "([HItemsRubrosId] >= @AV13TFHItemsRubrosId)");
         }
         else
         {
            GXv_int6[3] = 1;
         }
         if ( ! (0==AV14TFHItemsRubrosId_To) )
         {
            AddWhere(sWhereString, "([HItemsRubrosId] <= @AV14TFHItemsRubrosId_To)");
         }
         else
         {
            GXv_int6[4] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV16TFHItemsRubrosNombre_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV15TFHItemsRubrosNombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER([HItemsRubrosNombre]) like UPPER(@lV15TFHItemsRubrosNombre))");
         }
         else
         {
            GXv_int6[5] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV16TFHItemsRubrosNombre_Sel)) && ! ( StringUtil.StrCmp(AV16TFHItemsRubrosNombre_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([HItemsRubrosNombre] = @AV16TFHItemsRubrosNombre_Sel)");
         }
         else
         {
            GXv_int6[6] = 1;
         }
         if ( StringUtil.StrCmp(AV16TFHItemsRubrosNombre_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([HItemsRubrosNombre] = ''))");
         }
         if ( ! (0==AV17TFHItemsMedidasID) )
         {
            AddWhere(sWhereString, "([HItemsMedidasID] >= @AV17TFHItemsMedidasID)");
         }
         else
         {
            GXv_int6[7] = 1;
         }
         if ( ! (0==AV18TFHItemsMedidasID_To) )
         {
            AddWhere(sWhereString, "([HItemsMedidasID] <= @AV18TFHItemsMedidasID_To)");
         }
         else
         {
            GXv_int6[8] = 1;
         }
         if ( ! (0==AV19TFHItemsInventarioId) )
         {
            AddWhere(sWhereString, "([HItemsInventarioId] >= @AV19TFHItemsInventarioId)");
         }
         else
         {
            GXv_int6[9] = 1;
         }
         if ( ! (0==AV20TFHItemsInventarioId_To) )
         {
            AddWhere(sWhereString, "([HItemsInventarioId] <= @AV20TFHItemsInventarioId_To)");
         }
         else
         {
            GXv_int6[10] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV22TFHItemsInventarioNombre_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV21TFHItemsInventarioNombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER([HItemsInventarioNombre]) like UPPER(@lV21TFHItemsInventarioNombre))");
         }
         else
         {
            GXv_int6[11] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV22TFHItemsInventarioNombre_Sel)) && ! ( StringUtil.StrCmp(AV22TFHItemsInventarioNombre_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([HItemsInventarioNombre] = @AV22TFHItemsInventarioNombre_Sel)");
         }
         else
         {
            GXv_int6[12] = 1;
         }
         if ( StringUtil.StrCmp(AV22TFHItemsInventarioNombre_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([HItemsInventarioNombre] = ''))");
         }
         if ( ! (0==AV23TFHItemsInventarioPrecioFinal) )
         {
            AddWhere(sWhereString, "([HItemsInventarioPrecioFinal] >= @AV23TFHItemsInventarioPrecioFinal)");
         }
         else
         {
            GXv_int6[13] = 1;
         }
         if ( ! (0==AV24TFHItemsInventarioPrecioFinal_To) )
         {
            AddWhere(sWhereString, "([HItemsInventarioPrecioFinal] <= @AV24TFHItemsInventarioPrecioFinal_To)");
         }
         else
         {
            GXv_int6[14] = 1;
         }
         if ( ! (0==AV25TFHItemsSolicitudesItemsCantidad) )
         {
            AddWhere(sWhereString, "([HItemsSolicitudesItemsCantidad] >= @AV25TFHItemsSolicitudesItemsCantidad)");
         }
         else
         {
            GXv_int6[15] = 1;
         }
         if ( ! (0==AV26TFHItemsSolicitudesItemsCantidad_To) )
         {
            AddWhere(sWhereString, "([HItemsSolicitudesItemsCantidad] <= @AV26TFHItemsSolicitudesItemsCantidad_To)");
         }
         else
         {
            GXv_int6[16] = 1;
         }
         if ( ! (0==AV29TFHItemsSolicitudesMonedaId) )
         {
            AddWhere(sWhereString, "([HItemsSolicitudesMonedaId] >= @AV29TFHItemsSolicitudesMonedaId)");
         }
         else
         {
            GXv_int6[17] = 1;
         }
         if ( ! (0==AV30TFHItemsSolicitudesMonedaId_To) )
         {
            AddWhere(sWhereString, "([HItemsSolicitudesMonedaId] <= @AV30TFHItemsSolicitudesMonedaId_To)");
         }
         else
         {
            GXv_int6[18] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV32TFHistoricoSolicitudesItemsSR_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV31TFHistoricoSolicitudesItemsSR)) ) )
         {
            AddWhere(sWhereString, "(UPPER([HistoricoSolicitudesItemsSR]) like UPPER(@lV31TFHistoricoSolicitudesItemsSR))");
         }
         else
         {
            GXv_int6[19] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV32TFHistoricoSolicitudesItemsSR_Sel)) && ! ( StringUtil.StrCmp(AV32TFHistoricoSolicitudesItemsSR_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([HistoricoSolicitudesItemsSR] = @AV32TFHistoricoSolicitudesItemsSR_Sel)");
         }
         else
         {
            GXv_int6[20] = 1;
         }
         if ( StringUtil.StrCmp(AV32TFHistoricoSolicitudesItemsSR_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([HistoricoSolicitudesItemsSR] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV34TFHistoricoSolicitudesItemsCT_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV33TFHistoricoSolicitudesItemsCT)) ) )
         {
            AddWhere(sWhereString, "(UPPER([HistoricoSolicitudesItemsCT]) like UPPER(@lV33TFHistoricoSolicitudesItemsCT))");
         }
         else
         {
            GXv_int6[21] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV34TFHistoricoSolicitudesItemsCT_Sel)) && ! ( StringUtil.StrCmp(AV34TFHistoricoSolicitudesItemsCT_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([HistoricoSolicitudesItemsCT] = @AV34TFHistoricoSolicitudesItemsCT_Sel)");
         }
         else
         {
            GXv_int6[22] = 1;
         }
         if ( StringUtil.StrCmp(AV34TFHistoricoSolicitudesItemsCT_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([HistoricoSolicitudesItemsCT] = ''))");
         }
         if ( ! (Convert.ToDecimal(0)==AV35TFHistoricoSolicitudesItemsComision) )
         {
            AddWhere(sWhereString, "([HistoricoSolicitudesItemsComis] >= @AV35TFHistoricoSolicitudesItemsComision)");
         }
         else
         {
            GXv_int6[23] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV36TFHistoricoSolicitudesItemsComision_To) )
         {
            AddWhere(sWhereString, "([HistoricoSolicitudesItemsComis] <= @AV36TFHistoricoSolicitudesItemsComision_To)");
         }
         else
         {
            GXv_int6[24] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY [HistoricoSolicitudesID], [HistoricoSolicitudesItemsSR]";
         GXv_Object7[0] = scmdbuf;
         GXv_Object7[1] = GXv_int6;
         return GXv_Object7 ;
      }

      protected Object[] conditional_P004O5( IGxContext context ,
                                             short AV11TFHistoricoSolicitudesItemsID ,
                                             short AV12TFHistoricoSolicitudesItemsID_To ,
                                             long AV13TFHItemsRubrosId ,
                                             long AV14TFHItemsRubrosId_To ,
                                             string AV16TFHItemsRubrosNombre_Sel ,
                                             string AV15TFHItemsRubrosNombre ,
                                             long AV17TFHItemsMedidasID ,
                                             long AV18TFHItemsMedidasID_To ,
                                             long AV19TFHItemsInventarioId ,
                                             long AV20TFHItemsInventarioId_To ,
                                             string AV22TFHItemsInventarioNombre_Sel ,
                                             string AV21TFHItemsInventarioNombre ,
                                             short AV23TFHItemsInventarioPrecioFinal ,
                                             short AV24TFHItemsInventarioPrecioFinal_To ,
                                             short AV25TFHItemsSolicitudesItemsCantidad ,
                                             short AV26TFHItemsSolicitudesItemsCantidad_To ,
                                             long AV29TFHItemsSolicitudesMonedaId ,
                                             long AV30TFHItemsSolicitudesMonedaId_To ,
                                             string AV32TFHistoricoSolicitudesItemsSR_Sel ,
                                             string AV31TFHistoricoSolicitudesItemsSR ,
                                             string AV34TFHistoricoSolicitudesItemsCT_Sel ,
                                             string AV33TFHistoricoSolicitudesItemsCT ,
                                             decimal AV35TFHistoricoSolicitudesItemsComision ,
                                             decimal AV36TFHistoricoSolicitudesItemsComision_To ,
                                             short A154HistoricoSolicitudesItemsID ,
                                             long A330HItemsRubrosId ,
                                             string A331HItemsRubrosNombre ,
                                             long A327HItemsMedidasID ,
                                             long A328HItemsInventarioId ,
                                             string A329HItemsInventarioNombre ,
                                             short A295HItemsInventarioPrecioFinal ,
                                             short A293HItemsSolicitudesItemsCantidad ,
                                             long A319HItemsSolicitudesMonedaId ,
                                             string A296HistoricoSolicitudesItemsSR ,
                                             string A297HistoricoSolicitudesItemsCT ,
                                             decimal A298HistoricoSolicitudesItemsComis ,
                                             decimal AV27TFHItemsSolicitudesItemsPrecioInstalacion ,
                                             decimal A294HItemsSolicitudesItemsPrecioIn ,
                                             decimal AV28TFHItemsSolicitudesItemsPrecioInstalacion_To ,
                                             long AV59HistoricoSolicitudesID ,
                                             long A153HistoricoSolicitudesID )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int8 = new short[25];
         Object[] GXv_Object9 = new Object[2];
         scmdbuf = "SELECT [HistoricoSolicitudesID], [HItemsSolicitudesMonedaId], [HItemsInventarioNombre], [HItemsInventarioId], [HItemsMedidasID], [HItemsRubrosNombre], [HItemsRubrosId], [HistoricoSolicitudesItemsID], [HistoricoSolicitudesItemsComis], [HistoricoSolicitudesItemsCT], [HistoricoSolicitudesItemsSR], [HItemsSolicitudesItemsCantidad], [HItemsInventarioPrecioFinal] FROM [HistoricoSolicitudesItems]";
         AddWhere(sWhereString, "([HistoricoSolicitudesID] = @AV59HistoricoSolicitudesID)");
         if ( ! (0==AV11TFHistoricoSolicitudesItemsID) )
         {
            AddWhere(sWhereString, "([HistoricoSolicitudesItemsID] >= @AV11TFHistoricoSolicitudesItemsID)");
         }
         else
         {
            GXv_int8[1] = 1;
         }
         if ( ! (0==AV12TFHistoricoSolicitudesItemsID_To) )
         {
            AddWhere(sWhereString, "([HistoricoSolicitudesItemsID] <= @AV12TFHistoricoSolicitudesItemsID_To)");
         }
         else
         {
            GXv_int8[2] = 1;
         }
         if ( ! (0==AV13TFHItemsRubrosId) )
         {
            AddWhere(sWhereString, "([HItemsRubrosId] >= @AV13TFHItemsRubrosId)");
         }
         else
         {
            GXv_int8[3] = 1;
         }
         if ( ! (0==AV14TFHItemsRubrosId_To) )
         {
            AddWhere(sWhereString, "([HItemsRubrosId] <= @AV14TFHItemsRubrosId_To)");
         }
         else
         {
            GXv_int8[4] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV16TFHItemsRubrosNombre_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV15TFHItemsRubrosNombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER([HItemsRubrosNombre]) like UPPER(@lV15TFHItemsRubrosNombre))");
         }
         else
         {
            GXv_int8[5] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV16TFHItemsRubrosNombre_Sel)) && ! ( StringUtil.StrCmp(AV16TFHItemsRubrosNombre_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([HItemsRubrosNombre] = @AV16TFHItemsRubrosNombre_Sel)");
         }
         else
         {
            GXv_int8[6] = 1;
         }
         if ( StringUtil.StrCmp(AV16TFHItemsRubrosNombre_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([HItemsRubrosNombre] = ''))");
         }
         if ( ! (0==AV17TFHItemsMedidasID) )
         {
            AddWhere(sWhereString, "([HItemsMedidasID] >= @AV17TFHItemsMedidasID)");
         }
         else
         {
            GXv_int8[7] = 1;
         }
         if ( ! (0==AV18TFHItemsMedidasID_To) )
         {
            AddWhere(sWhereString, "([HItemsMedidasID] <= @AV18TFHItemsMedidasID_To)");
         }
         else
         {
            GXv_int8[8] = 1;
         }
         if ( ! (0==AV19TFHItemsInventarioId) )
         {
            AddWhere(sWhereString, "([HItemsInventarioId] >= @AV19TFHItemsInventarioId)");
         }
         else
         {
            GXv_int8[9] = 1;
         }
         if ( ! (0==AV20TFHItemsInventarioId_To) )
         {
            AddWhere(sWhereString, "([HItemsInventarioId] <= @AV20TFHItemsInventarioId_To)");
         }
         else
         {
            GXv_int8[10] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV22TFHItemsInventarioNombre_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV21TFHItemsInventarioNombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER([HItemsInventarioNombre]) like UPPER(@lV21TFHItemsInventarioNombre))");
         }
         else
         {
            GXv_int8[11] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV22TFHItemsInventarioNombre_Sel)) && ! ( StringUtil.StrCmp(AV22TFHItemsInventarioNombre_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([HItemsInventarioNombre] = @AV22TFHItemsInventarioNombre_Sel)");
         }
         else
         {
            GXv_int8[12] = 1;
         }
         if ( StringUtil.StrCmp(AV22TFHItemsInventarioNombre_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([HItemsInventarioNombre] = ''))");
         }
         if ( ! (0==AV23TFHItemsInventarioPrecioFinal) )
         {
            AddWhere(sWhereString, "([HItemsInventarioPrecioFinal] >= @AV23TFHItemsInventarioPrecioFinal)");
         }
         else
         {
            GXv_int8[13] = 1;
         }
         if ( ! (0==AV24TFHItemsInventarioPrecioFinal_To) )
         {
            AddWhere(sWhereString, "([HItemsInventarioPrecioFinal] <= @AV24TFHItemsInventarioPrecioFinal_To)");
         }
         else
         {
            GXv_int8[14] = 1;
         }
         if ( ! (0==AV25TFHItemsSolicitudesItemsCantidad) )
         {
            AddWhere(sWhereString, "([HItemsSolicitudesItemsCantidad] >= @AV25TFHItemsSolicitudesItemsCantidad)");
         }
         else
         {
            GXv_int8[15] = 1;
         }
         if ( ! (0==AV26TFHItemsSolicitudesItemsCantidad_To) )
         {
            AddWhere(sWhereString, "([HItemsSolicitudesItemsCantidad] <= @AV26TFHItemsSolicitudesItemsCantidad_To)");
         }
         else
         {
            GXv_int8[16] = 1;
         }
         if ( ! (0==AV29TFHItemsSolicitudesMonedaId) )
         {
            AddWhere(sWhereString, "([HItemsSolicitudesMonedaId] >= @AV29TFHItemsSolicitudesMonedaId)");
         }
         else
         {
            GXv_int8[17] = 1;
         }
         if ( ! (0==AV30TFHItemsSolicitudesMonedaId_To) )
         {
            AddWhere(sWhereString, "([HItemsSolicitudesMonedaId] <= @AV30TFHItemsSolicitudesMonedaId_To)");
         }
         else
         {
            GXv_int8[18] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV32TFHistoricoSolicitudesItemsSR_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV31TFHistoricoSolicitudesItemsSR)) ) )
         {
            AddWhere(sWhereString, "(UPPER([HistoricoSolicitudesItemsSR]) like UPPER(@lV31TFHistoricoSolicitudesItemsSR))");
         }
         else
         {
            GXv_int8[19] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV32TFHistoricoSolicitudesItemsSR_Sel)) && ! ( StringUtil.StrCmp(AV32TFHistoricoSolicitudesItemsSR_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([HistoricoSolicitudesItemsSR] = @AV32TFHistoricoSolicitudesItemsSR_Sel)");
         }
         else
         {
            GXv_int8[20] = 1;
         }
         if ( StringUtil.StrCmp(AV32TFHistoricoSolicitudesItemsSR_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([HistoricoSolicitudesItemsSR] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV34TFHistoricoSolicitudesItemsCT_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV33TFHistoricoSolicitudesItemsCT)) ) )
         {
            AddWhere(sWhereString, "(UPPER([HistoricoSolicitudesItemsCT]) like UPPER(@lV33TFHistoricoSolicitudesItemsCT))");
         }
         else
         {
            GXv_int8[21] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV34TFHistoricoSolicitudesItemsCT_Sel)) && ! ( StringUtil.StrCmp(AV34TFHistoricoSolicitudesItemsCT_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([HistoricoSolicitudesItemsCT] = @AV34TFHistoricoSolicitudesItemsCT_Sel)");
         }
         else
         {
            GXv_int8[22] = 1;
         }
         if ( StringUtil.StrCmp(AV34TFHistoricoSolicitudesItemsCT_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([HistoricoSolicitudesItemsCT] = ''))");
         }
         if ( ! (Convert.ToDecimal(0)==AV35TFHistoricoSolicitudesItemsComision) )
         {
            AddWhere(sWhereString, "([HistoricoSolicitudesItemsComis] >= @AV35TFHistoricoSolicitudesItemsComision)");
         }
         else
         {
            GXv_int8[23] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV36TFHistoricoSolicitudesItemsComision_To) )
         {
            AddWhere(sWhereString, "([HistoricoSolicitudesItemsComis] <= @AV36TFHistoricoSolicitudesItemsComision_To)");
         }
         else
         {
            GXv_int8[24] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY [HistoricoSolicitudesID], [HistoricoSolicitudesItemsCT]";
         GXv_Object9[0] = scmdbuf;
         GXv_Object9[1] = GXv_int8;
         return GXv_Object9 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_P004O2(context, (short)dynConstraints[0] , (short)dynConstraints[1] , (long)dynConstraints[2] , (long)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (long)dynConstraints[6] , (long)dynConstraints[7] , (long)dynConstraints[8] , (long)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (short)dynConstraints[12] , (short)dynConstraints[13] , (short)dynConstraints[14] , (short)dynConstraints[15] , (long)dynConstraints[16] , (long)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (decimal)dynConstraints[22] , (decimal)dynConstraints[23] , (short)dynConstraints[24] , (long)dynConstraints[25] , (string)dynConstraints[26] , (long)dynConstraints[27] , (long)dynConstraints[28] , (string)dynConstraints[29] , (short)dynConstraints[30] , (short)dynConstraints[31] , (long)dynConstraints[32] , (string)dynConstraints[33] , (string)dynConstraints[34] , (decimal)dynConstraints[35] , (decimal)dynConstraints[36] , (decimal)dynConstraints[37] , (decimal)dynConstraints[38] , (long)dynConstraints[39] , (long)dynConstraints[40] );
               case 1 :
                     return conditional_P004O3(context, (short)dynConstraints[0] , (short)dynConstraints[1] , (long)dynConstraints[2] , (long)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (long)dynConstraints[6] , (long)dynConstraints[7] , (long)dynConstraints[8] , (long)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (short)dynConstraints[12] , (short)dynConstraints[13] , (short)dynConstraints[14] , (short)dynConstraints[15] , (long)dynConstraints[16] , (long)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (decimal)dynConstraints[22] , (decimal)dynConstraints[23] , (short)dynConstraints[24] , (long)dynConstraints[25] , (string)dynConstraints[26] , (long)dynConstraints[27] , (long)dynConstraints[28] , (string)dynConstraints[29] , (short)dynConstraints[30] , (short)dynConstraints[31] , (long)dynConstraints[32] , (string)dynConstraints[33] , (string)dynConstraints[34] , (decimal)dynConstraints[35] , (decimal)dynConstraints[36] , (decimal)dynConstraints[37] , (decimal)dynConstraints[38] , (long)dynConstraints[39] , (long)dynConstraints[40] );
               case 2 :
                     return conditional_P004O4(context, (short)dynConstraints[0] , (short)dynConstraints[1] , (long)dynConstraints[2] , (long)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (long)dynConstraints[6] , (long)dynConstraints[7] , (long)dynConstraints[8] , (long)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (short)dynConstraints[12] , (short)dynConstraints[13] , (short)dynConstraints[14] , (short)dynConstraints[15] , (long)dynConstraints[16] , (long)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (decimal)dynConstraints[22] , (decimal)dynConstraints[23] , (short)dynConstraints[24] , (long)dynConstraints[25] , (string)dynConstraints[26] , (long)dynConstraints[27] , (long)dynConstraints[28] , (string)dynConstraints[29] , (short)dynConstraints[30] , (short)dynConstraints[31] , (long)dynConstraints[32] , (string)dynConstraints[33] , (string)dynConstraints[34] , (decimal)dynConstraints[35] , (decimal)dynConstraints[36] , (decimal)dynConstraints[37] , (decimal)dynConstraints[38] , (long)dynConstraints[39] , (long)dynConstraints[40] );
               case 3 :
                     return conditional_P004O5(context, (short)dynConstraints[0] , (short)dynConstraints[1] , (long)dynConstraints[2] , (long)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (long)dynConstraints[6] , (long)dynConstraints[7] , (long)dynConstraints[8] , (long)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (short)dynConstraints[12] , (short)dynConstraints[13] , (short)dynConstraints[14] , (short)dynConstraints[15] , (long)dynConstraints[16] , (long)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (decimal)dynConstraints[22] , (decimal)dynConstraints[23] , (short)dynConstraints[24] , (long)dynConstraints[25] , (string)dynConstraints[26] , (long)dynConstraints[27] , (long)dynConstraints[28] , (string)dynConstraints[29] , (short)dynConstraints[30] , (short)dynConstraints[31] , (long)dynConstraints[32] , (string)dynConstraints[33] , (string)dynConstraints[34] , (decimal)dynConstraints[35] , (decimal)dynConstraints[36] , (decimal)dynConstraints[37] , (decimal)dynConstraints[38] , (long)dynConstraints[39] , (long)dynConstraints[40] );
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
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP004O2;
          prmP004O2 = new Object[] {
          new ParDef("@AV59HistoricoSolicitudesID",GXType.Decimal,18,0) ,
          new ParDef("@AV11TFHistoricoSolicitudesItemsID",GXType.Int16,4,0) ,
          new ParDef("@AV12TFHistoricoSolicitudesItemsID_To",GXType.Int16,4,0) ,
          new ParDef("@AV13TFHItemsRubrosId",GXType.Decimal,18,0) ,
          new ParDef("@AV14TFHItemsRubrosId_To",GXType.Decimal,18,0) ,
          new ParDef("@lV15TFHItemsRubrosNombre",GXType.Char,100,0) ,
          new ParDef("@AV16TFHItemsRubrosNombre_Sel",GXType.NChar,100,0) ,
          new ParDef("@AV17TFHItemsMedidasID",GXType.Decimal,18,0) ,
          new ParDef("@AV18TFHItemsMedidasID_To",GXType.Decimal,18,0) ,
          new ParDef("@AV19TFHItemsInventarioId",GXType.Decimal,18,0) ,
          new ParDef("@AV20TFHItemsInventarioId_To",GXType.Decimal,18,0) ,
          new ParDef("@lV21TFHItemsInventarioNombre",GXType.Char,100,0) ,
          new ParDef("@AV22TFHItemsInventarioNombre_Sel",GXType.NChar,100,0) ,
          new ParDef("@AV23TFHItemsInventarioPrecioFinal",GXType.Int16,4,0) ,
          new ParDef("@AV24TFHItemsInventarioPrecioFinal_To",GXType.Int16,4,0) ,
          new ParDef("@AV25TFHItemsSolicitudesItemsCantidad",GXType.Int16,4,0) ,
          new ParDef("@AV26TFHItemsSolicitudesItemsCantidad_To",GXType.Int16,4,0) ,
          new ParDef("@AV29TFHItemsSolicitudesMonedaId",GXType.Decimal,18,0) ,
          new ParDef("@AV30TFHItemsSolicitudesMonedaId_To",GXType.Decimal,18,0) ,
          new ParDef("@lV31TFHistoricoSolicitudesItemsSR",GXType.Char,1,0) ,
          new ParDef("@AV32TFHistoricoSolicitudesItemsSR_Sel",GXType.NChar,1,0) ,
          new ParDef("@lV33TFHistoricoSolicitudesItemsCT",GXType.Char,1,0) ,
          new ParDef("@AV34TFHistoricoSolicitudesItemsCT_Sel",GXType.NChar,1,0) ,
          new ParDef("@AV35TFHistoricoSolicitudesItemsComision",GXType.Decimal,18,2) ,
          new ParDef("@AV36TFHistoricoSolicitudesItemsComision_To",GXType.Decimal,18,2)
          };
          Object[] prmP004O3;
          prmP004O3 = new Object[] {
          new ParDef("@AV59HistoricoSolicitudesID",GXType.Decimal,18,0) ,
          new ParDef("@AV11TFHistoricoSolicitudesItemsID",GXType.Int16,4,0) ,
          new ParDef("@AV12TFHistoricoSolicitudesItemsID_To",GXType.Int16,4,0) ,
          new ParDef("@AV13TFHItemsRubrosId",GXType.Decimal,18,0) ,
          new ParDef("@AV14TFHItemsRubrosId_To",GXType.Decimal,18,0) ,
          new ParDef("@lV15TFHItemsRubrosNombre",GXType.Char,100,0) ,
          new ParDef("@AV16TFHItemsRubrosNombre_Sel",GXType.NChar,100,0) ,
          new ParDef("@AV17TFHItemsMedidasID",GXType.Decimal,18,0) ,
          new ParDef("@AV18TFHItemsMedidasID_To",GXType.Decimal,18,0) ,
          new ParDef("@AV19TFHItemsInventarioId",GXType.Decimal,18,0) ,
          new ParDef("@AV20TFHItemsInventarioId_To",GXType.Decimal,18,0) ,
          new ParDef("@lV21TFHItemsInventarioNombre",GXType.Char,100,0) ,
          new ParDef("@AV22TFHItemsInventarioNombre_Sel",GXType.NChar,100,0) ,
          new ParDef("@AV23TFHItemsInventarioPrecioFinal",GXType.Int16,4,0) ,
          new ParDef("@AV24TFHItemsInventarioPrecioFinal_To",GXType.Int16,4,0) ,
          new ParDef("@AV25TFHItemsSolicitudesItemsCantidad",GXType.Int16,4,0) ,
          new ParDef("@AV26TFHItemsSolicitudesItemsCantidad_To",GXType.Int16,4,0) ,
          new ParDef("@AV29TFHItemsSolicitudesMonedaId",GXType.Decimal,18,0) ,
          new ParDef("@AV30TFHItemsSolicitudesMonedaId_To",GXType.Decimal,18,0) ,
          new ParDef("@lV31TFHistoricoSolicitudesItemsSR",GXType.Char,1,0) ,
          new ParDef("@AV32TFHistoricoSolicitudesItemsSR_Sel",GXType.NChar,1,0) ,
          new ParDef("@lV33TFHistoricoSolicitudesItemsCT",GXType.Char,1,0) ,
          new ParDef("@AV34TFHistoricoSolicitudesItemsCT_Sel",GXType.NChar,1,0) ,
          new ParDef("@AV35TFHistoricoSolicitudesItemsComision",GXType.Decimal,18,2) ,
          new ParDef("@AV36TFHistoricoSolicitudesItemsComision_To",GXType.Decimal,18,2)
          };
          Object[] prmP004O4;
          prmP004O4 = new Object[] {
          new ParDef("@AV59HistoricoSolicitudesID",GXType.Decimal,18,0) ,
          new ParDef("@AV11TFHistoricoSolicitudesItemsID",GXType.Int16,4,0) ,
          new ParDef("@AV12TFHistoricoSolicitudesItemsID_To",GXType.Int16,4,0) ,
          new ParDef("@AV13TFHItemsRubrosId",GXType.Decimal,18,0) ,
          new ParDef("@AV14TFHItemsRubrosId_To",GXType.Decimal,18,0) ,
          new ParDef("@lV15TFHItemsRubrosNombre",GXType.Char,100,0) ,
          new ParDef("@AV16TFHItemsRubrosNombre_Sel",GXType.NChar,100,0) ,
          new ParDef("@AV17TFHItemsMedidasID",GXType.Decimal,18,0) ,
          new ParDef("@AV18TFHItemsMedidasID_To",GXType.Decimal,18,0) ,
          new ParDef("@AV19TFHItemsInventarioId",GXType.Decimal,18,0) ,
          new ParDef("@AV20TFHItemsInventarioId_To",GXType.Decimal,18,0) ,
          new ParDef("@lV21TFHItemsInventarioNombre",GXType.Char,100,0) ,
          new ParDef("@AV22TFHItemsInventarioNombre_Sel",GXType.NChar,100,0) ,
          new ParDef("@AV23TFHItemsInventarioPrecioFinal",GXType.Int16,4,0) ,
          new ParDef("@AV24TFHItemsInventarioPrecioFinal_To",GXType.Int16,4,0) ,
          new ParDef("@AV25TFHItemsSolicitudesItemsCantidad",GXType.Int16,4,0) ,
          new ParDef("@AV26TFHItemsSolicitudesItemsCantidad_To",GXType.Int16,4,0) ,
          new ParDef("@AV29TFHItemsSolicitudesMonedaId",GXType.Decimal,18,0) ,
          new ParDef("@AV30TFHItemsSolicitudesMonedaId_To",GXType.Decimal,18,0) ,
          new ParDef("@lV31TFHistoricoSolicitudesItemsSR",GXType.Char,1,0) ,
          new ParDef("@AV32TFHistoricoSolicitudesItemsSR_Sel",GXType.NChar,1,0) ,
          new ParDef("@lV33TFHistoricoSolicitudesItemsCT",GXType.Char,1,0) ,
          new ParDef("@AV34TFHistoricoSolicitudesItemsCT_Sel",GXType.NChar,1,0) ,
          new ParDef("@AV35TFHistoricoSolicitudesItemsComision",GXType.Decimal,18,2) ,
          new ParDef("@AV36TFHistoricoSolicitudesItemsComision_To",GXType.Decimal,18,2)
          };
          Object[] prmP004O5;
          prmP004O5 = new Object[] {
          new ParDef("@AV59HistoricoSolicitudesID",GXType.Decimal,18,0) ,
          new ParDef("@AV11TFHistoricoSolicitudesItemsID",GXType.Int16,4,0) ,
          new ParDef("@AV12TFHistoricoSolicitudesItemsID_To",GXType.Int16,4,0) ,
          new ParDef("@AV13TFHItemsRubrosId",GXType.Decimal,18,0) ,
          new ParDef("@AV14TFHItemsRubrosId_To",GXType.Decimal,18,0) ,
          new ParDef("@lV15TFHItemsRubrosNombre",GXType.Char,100,0) ,
          new ParDef("@AV16TFHItemsRubrosNombre_Sel",GXType.NChar,100,0) ,
          new ParDef("@AV17TFHItemsMedidasID",GXType.Decimal,18,0) ,
          new ParDef("@AV18TFHItemsMedidasID_To",GXType.Decimal,18,0) ,
          new ParDef("@AV19TFHItemsInventarioId",GXType.Decimal,18,0) ,
          new ParDef("@AV20TFHItemsInventarioId_To",GXType.Decimal,18,0) ,
          new ParDef("@lV21TFHItemsInventarioNombre",GXType.Char,100,0) ,
          new ParDef("@AV22TFHItemsInventarioNombre_Sel",GXType.NChar,100,0) ,
          new ParDef("@AV23TFHItemsInventarioPrecioFinal",GXType.Int16,4,0) ,
          new ParDef("@AV24TFHItemsInventarioPrecioFinal_To",GXType.Int16,4,0) ,
          new ParDef("@AV25TFHItemsSolicitudesItemsCantidad",GXType.Int16,4,0) ,
          new ParDef("@AV26TFHItemsSolicitudesItemsCantidad_To",GXType.Int16,4,0) ,
          new ParDef("@AV29TFHItemsSolicitudesMonedaId",GXType.Decimal,18,0) ,
          new ParDef("@AV30TFHItemsSolicitudesMonedaId_To",GXType.Decimal,18,0) ,
          new ParDef("@lV31TFHistoricoSolicitudesItemsSR",GXType.Char,1,0) ,
          new ParDef("@AV32TFHistoricoSolicitudesItemsSR_Sel",GXType.NChar,1,0) ,
          new ParDef("@lV33TFHistoricoSolicitudesItemsCT",GXType.Char,1,0) ,
          new ParDef("@AV34TFHistoricoSolicitudesItemsCT_Sel",GXType.NChar,1,0) ,
          new ParDef("@AV35TFHistoricoSolicitudesItemsComision",GXType.Decimal,18,2) ,
          new ParDef("@AV36TFHistoricoSolicitudesItemsComision_To",GXType.Decimal,18,2)
          };
          def= new CursorDef[] {
              new CursorDef("P004O2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP004O2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P004O3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP004O3,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P004O4", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP004O4,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P004O5", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP004O5,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[1])[0] = rslt.getString(2, 100);
                ((long[]) buf[2])[0] = rslt.getLong(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 100);
                ((long[]) buf[4])[0] = rslt.getLong(5);
                ((long[]) buf[5])[0] = rslt.getLong(6);
                ((long[]) buf[6])[0] = rslt.getLong(7);
                ((short[]) buf[7])[0] = rslt.getShort(8);
                ((decimal[]) buf[8])[0] = rslt.getDecimal(9);
                ((string[]) buf[9])[0] = rslt.getString(10, 1);
                ((string[]) buf[10])[0] = rslt.getString(11, 1);
                ((short[]) buf[11])[0] = rslt.getShort(12);
                ((short[]) buf[12])[0] = rslt.getShort(13);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 100);
                ((long[]) buf[2])[0] = rslt.getLong(3);
                ((long[]) buf[3])[0] = rslt.getLong(4);
                ((long[]) buf[4])[0] = rslt.getLong(5);
                ((string[]) buf[5])[0] = rslt.getString(6, 100);
                ((long[]) buf[6])[0] = rslt.getLong(7);
                ((short[]) buf[7])[0] = rslt.getShort(8);
                ((decimal[]) buf[8])[0] = rslt.getDecimal(9);
                ((string[]) buf[9])[0] = rslt.getString(10, 1);
                ((string[]) buf[10])[0] = rslt.getString(11, 1);
                ((short[]) buf[11])[0] = rslt.getShort(12);
                ((short[]) buf[12])[0] = rslt.getShort(13);
                return;
             case 2 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((long[]) buf[1])[0] = rslt.getLong(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 100);
                ((long[]) buf[3])[0] = rslt.getLong(4);
                ((long[]) buf[4])[0] = rslt.getLong(5);
                ((string[]) buf[5])[0] = rslt.getString(6, 100);
                ((long[]) buf[6])[0] = rslt.getLong(7);
                ((short[]) buf[7])[0] = rslt.getShort(8);
                ((decimal[]) buf[8])[0] = rslt.getDecimal(9);
                ((string[]) buf[9])[0] = rslt.getString(10, 1);
                ((string[]) buf[10])[0] = rslt.getString(11, 1);
                ((short[]) buf[11])[0] = rslt.getShort(12);
                ((short[]) buf[12])[0] = rslt.getShort(13);
                return;
             case 3 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((long[]) buf[1])[0] = rslt.getLong(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 100);
                ((long[]) buf[3])[0] = rslt.getLong(4);
                ((long[]) buf[4])[0] = rslt.getLong(5);
                ((string[]) buf[5])[0] = rslt.getString(6, 100);
                ((long[]) buf[6])[0] = rslt.getLong(7);
                ((short[]) buf[7])[0] = rslt.getShort(8);
                ((decimal[]) buf[8])[0] = rslt.getDecimal(9);
                ((string[]) buf[9])[0] = rslt.getString(10, 1);
                ((string[]) buf[10])[0] = rslt.getString(11, 1);
                ((short[]) buf[11])[0] = rslt.getShort(12);
                ((short[]) buf[12])[0] = rslt.getShort(13);
                return;
       }
    }

 }

 [ServiceContract(Namespace = "GeneXus.Programs.historicosolicitudesitemswcgetfilterdata_services")]
 [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple)]
 [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
 public class historicosolicitudesitemswcgetfilterdata_services : GxRestService
 {
    [OperationContract(Name = "HistoricoSolicitudesItemsWCGetFilterData" )]
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
          if ( ! ProcessHeaders("historicosolicitudesitemswcgetfilterdata") )
          {
             return  ;
          }
          historicosolicitudesitemswcgetfilterdata worker = new historicosolicitudesitemswcgetfilterdata(context);
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

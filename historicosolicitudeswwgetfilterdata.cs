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
   public class historicosolicitudeswwgetfilterdata : GXProcedure
   {
      public historicosolicitudeswwgetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public historicosolicitudeswwgetfilterdata( IGxContext context )
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
         this.AV31DDOName = aP0_DDOName;
         this.AV32SearchTxtParms = aP1_SearchTxtParms;
         this.AV33SearchTxtTo = aP2_SearchTxtTo;
         this.AV34OptionsJson = "" ;
         this.AV35OptionsDescJson = "" ;
         this.AV36OptionIndexesJson = "" ;
         initialize();
         ExecutePrivate();
         aP3_OptionsJson=this.AV34OptionsJson;
         aP4_OptionsDescJson=this.AV35OptionsDescJson;
         aP5_OptionIndexesJson=this.AV36OptionIndexesJson;
      }

      public string executeUdp( string aP0_DDOName ,
                                string aP1_SearchTxtParms ,
                                string aP2_SearchTxtTo ,
                                out string aP3_OptionsJson ,
                                out string aP4_OptionsDescJson )
      {
         execute(aP0_DDOName, aP1_SearchTxtParms, aP2_SearchTxtTo, out aP3_OptionsJson, out aP4_OptionsDescJson, out aP5_OptionIndexesJson);
         return AV36OptionIndexesJson ;
      }

      public void executeSubmit( string aP0_DDOName ,
                                 string aP1_SearchTxtParms ,
                                 string aP2_SearchTxtTo ,
                                 out string aP3_OptionsJson ,
                                 out string aP4_OptionsDescJson ,
                                 out string aP5_OptionIndexesJson )
      {
         this.AV31DDOName = aP0_DDOName;
         this.AV32SearchTxtParms = aP1_SearchTxtParms;
         this.AV33SearchTxtTo = aP2_SearchTxtTo;
         this.AV34OptionsJson = "" ;
         this.AV35OptionsDescJson = "" ;
         this.AV36OptionIndexesJson = "" ;
         SubmitImpl();
         aP3_OptionsJson=this.AV34OptionsJson;
         aP4_OptionsDescJson=this.AV35OptionsDescJson;
         aP5_OptionIndexesJson=this.AV36OptionIndexesJson;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV21Options = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV23OptionsDesc = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV24OptionIndexes = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         GXt_boolean1 = AV8IsAuthorized;
         new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWHistoricoSolicitudes", out  GXt_boolean1) ;
         AV8IsAuthorized = GXt_boolean1;
         if ( AV8IsAuthorized )
         {
            AV18MaxItems = 10;
            AV17PageIndex = (short)((String.IsNullOrEmpty(StringUtil.RTrim( AV32SearchTxtParms)) ? 0 : (long)(Math.Round(NumberUtil.Val( StringUtil.Substring( AV32SearchTxtParms, 1, 2), "."), 18, MidpointRounding.ToEven))));
            AV15SearchTxt = (String.IsNullOrEmpty(StringUtil.RTrim( AV32SearchTxtParms)) ? "" : StringUtil.Substring( AV32SearchTxtParms, 3, -1));
            AV16SkipItems = (short)(AV17PageIndex*AV18MaxItems);
            new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV9WWPContext) ;
            /* Execute user subroutine: 'LOADGRIDSTATE' */
            S111 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
            if ( StringUtil.StrCmp(StringUtil.Upper( AV31DDOName), "DDO_HISTORICOSOLICITUDESPROVNOMBRE") == 0 )
            {
               /* Execute user subroutine: 'LOADHISTORICOSOLICITUDESPROVNOMBREOPTIONS' */
               S121 ();
               if ( returnInSub )
               {
                  cleanup();
                  if (true) return;
               }
            }
         }
         AV34OptionsJson = AV21Options.ToJSonString(false);
         AV35OptionsDescJson = AV23OptionsDesc.ToJSonString(false);
         AV36OptionIndexesJson = AV24OptionIndexes.ToJSonString(false);
         cleanup();
      }

      protected void S111( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV26Session.Get("HistoricoSolicitudesWWGridState"), "") == 0 )
         {
            AV28GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "HistoricoSolicitudesWWGridState"), null, "", "");
         }
         else
         {
            AV28GridState.FromXml(AV26Session.Get("HistoricoSolicitudesWWGridState"), null, "", "");
         }
         AV42GXV1 = 1;
         while ( AV42GXV1 <= AV28GridState.gxTpr_Filtervalues.Count )
         {
            AV29GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV28GridState.gxTpr_Filtervalues.Item(AV42GXV1));
            if ( StringUtil.StrCmp(AV29GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV37FilterFullText = AV29GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV29GridStateFilterValue.gxTpr_Name, "TFHISTORICOSOLICITUDESPROVID") == 0 )
            {
               AV11TFHistoricoSolicitudesProvID = (long)(Math.Round(NumberUtil.Val( AV29GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV12TFHistoricoSolicitudesProvID_To = (long)(Math.Round(NumberUtil.Val( AV29GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV29GridStateFilterValue.gxTpr_Name, "TFHISTORICOSOLICITUDESPROVNOMBRE") == 0 )
            {
               AV13TFHistoricoSolicitudesProvNombre = AV29GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV29GridStateFilterValue.gxTpr_Name, "TFHISTORICOSOLICITUDESPROVNOMBRE_SEL") == 0 )
            {
               AV14TFHistoricoSolicitudesProvNombre_Sel = AV29GridStateFilterValue.gxTpr_Value;
            }
            AV42GXV1 = (int)(AV42GXV1+1);
         }
      }

      protected void S121( )
      {
         /* 'LOADHISTORICOSOLICITUDESPROVNOMBREOPTIONS' Routine */
         returnInSub = false;
         AV13TFHistoricoSolicitudesProvNombre = AV15SearchTxt;
         AV14TFHistoricoSolicitudesProvNombre_Sel = "";
         AV44Historicosolicitudeswwds_1_filterfulltext = AV37FilterFullText;
         AV45Historicosolicitudeswwds_2_tfhistoricosolicitudesprovid = AV11TFHistoricoSolicitudesProvID;
         AV46Historicosolicitudeswwds_3_tfhistoricosolicitudesprovid_to = AV12TFHistoricoSolicitudesProvID_To;
         AV47Historicosolicitudeswwds_4_tfhistoricosolicitudesprovnombre = AV13TFHistoricoSolicitudesProvNombre;
         AV48Historicosolicitudeswwds_5_tfhistoricosolicitudesprovnombre_sel = AV14TFHistoricoSolicitudesProvNombre_Sel;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV45Historicosolicitudeswwds_2_tfhistoricosolicitudesprovid ,
                                              AV46Historicosolicitudeswwds_3_tfhistoricosolicitudesprovid_to ,
                                              AV48Historicosolicitudeswwds_5_tfhistoricosolicitudesprovnombre_sel ,
                                              AV47Historicosolicitudeswwds_4_tfhistoricosolicitudesprovnombre ,
                                              AV38EstadosGenericosID ,
                                              AV41ProveedorID ,
                                              A633HistoricoSolicitudesProvID ,
                                              A634HistoricoSolicitudesProvNombre ,
                                              A131EstadosSolId ,
                                              AV44Historicosolicitudeswwds_1_filterfulltext ,
                                              A153HistoricoSolicitudesID ,
                                              A288HistoricoSolicitudesNombre ,
                                              A289HistoricoSolicitudesTelefono ,
                                              A290HistoricoSolicitudesMail ,
                                              A291HistoricoSolicitudesDireccion ,
                                              A302HistoricoSolicitudServicioPFin ,
                                              A306HistoricoSolicitudesFechaAlta ,
                                              AV39FechaIni ,
                                              AV40FechaFin } ,
                                              new int[]{
                                              TypeConstants.LONG, TypeConstants.LONG, TypeConstants.INT, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.INT, TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.DATE,
                                              TypeConstants.DATE, TypeConstants.DATE
                                              }
         });
         lV47Historicosolicitudeswwds_4_tfhistoricosolicitudesprovnombre = StringUtil.PadR( StringUtil.RTrim( AV47Historicosolicitudeswwds_4_tfhistoricosolicitudesprovnombre), 120, "%");
         /* Using cursor P00BA2 */
         pr_default.execute(0, new Object[] {AV39FechaIni, AV40FechaFin, AV45Historicosolicitudeswwds_2_tfhistoricosolicitudesprovid, AV46Historicosolicitudeswwds_3_tfhistoricosolicitudesprovid_to, lV47Historicosolicitudeswwds_4_tfhistoricosolicitudesprovnombre, AV48Historicosolicitudeswwds_5_tfhistoricosolicitudesprovnombre_sel, AV38EstadosGenericosID, AV41ProveedorID});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRKBA2 = false;
            A634HistoricoSolicitudesProvNombre = P00BA2_A634HistoricoSolicitudesProvNombre[0];
            A306HistoricoSolicitudesFechaAlta = P00BA2_A306HistoricoSolicitudesFechaAlta[0];
            A131EstadosSolId = P00BA2_A131EstadosSolId[0];
            A291HistoricoSolicitudesDireccion = P00BA2_A291HistoricoSolicitudesDireccion[0];
            A290HistoricoSolicitudesMail = P00BA2_A290HistoricoSolicitudesMail[0];
            n290HistoricoSolicitudesMail = P00BA2_n290HistoricoSolicitudesMail[0];
            A289HistoricoSolicitudesTelefono = P00BA2_A289HistoricoSolicitudesTelefono[0];
            A288HistoricoSolicitudesNombre = P00BA2_A288HistoricoSolicitudesNombre[0];
            A153HistoricoSolicitudesID = P00BA2_A153HistoricoSolicitudesID[0];
            A633HistoricoSolicitudesProvID = P00BA2_A633HistoricoSolicitudesProvID[0];
            A299HistoricoSolicitudesCotizacion = P00BA2_A299HistoricoSolicitudesCotizacion[0];
            GetHistoricoSolicitudesTotal( A153HistoricoSolicitudesID) ;
            if ( ( A299HistoricoSolicitudesCotizacion == Convert.ToDecimal( 0 )) )
            {
               A302HistoricoSolicitudServicioPFin = A300HistoricoSolicitudesTotal;
            }
            else
            {
               if ( ( A299HistoricoSolicitudesCotizacion > Convert.ToDecimal( 0 )) )
               {
                  A302HistoricoSolicitudServicioPFin = A299HistoricoSolicitudesCotizacion;
               }
               else
               {
                  A302HistoricoSolicitudServicioPFin = 0;
               }
            }
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV44Historicosolicitudeswwds_1_filterfulltext)) || ( ( StringUtil.Like( StringUtil.Str( (decimal)(A153HistoricoSolicitudesID), 18, 0) , StringUtil.PadR( "%" + AV44Historicosolicitudeswwds_1_filterfulltext , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A288HistoricoSolicitudesNombre) , StringUtil.PadR( "%" + StringUtil.Upper( AV44Historicosolicitudeswwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A289HistoricoSolicitudesTelefono) , StringUtil.PadR( "%" + StringUtil.Upper( AV44Historicosolicitudeswwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A290HistoricoSolicitudesMail) , StringUtil.PadR( "%" + StringUtil.Upper( AV44Historicosolicitudeswwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A291HistoricoSolicitudesDireccion) , StringUtil.PadR( "%" + StringUtil.Upper( AV44Historicosolicitudeswwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Str( A302HistoricoSolicitudServicioPFin, 18, 2) , StringUtil.PadR( "%" + AV44Historicosolicitudeswwds_1_filterfulltext , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A634HistoricoSolicitudesProvNombre) , StringUtil.PadR( "%" + StringUtil.Upper( AV44Historicosolicitudeswwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) ) )
            {
               AV25count = 0;
               while ( (pr_default.getStatus(0) != 101) && ( StringUtil.StrCmp(P00BA2_A634HistoricoSolicitudesProvNombre[0], A634HistoricoSolicitudesProvNombre) == 0 ) )
               {
                  BRKBA2 = false;
                  A153HistoricoSolicitudesID = P00BA2_A153HistoricoSolicitudesID[0];
                  AV25count = (long)(AV25count+1);
                  BRKBA2 = true;
                  pr_default.readNext(0);
               }
               if ( (0==AV16SkipItems) )
               {
                  AV20Option = (String.IsNullOrEmpty(StringUtil.RTrim( A634HistoricoSolicitudesProvNombre)) ? "<#Empty#>" : A634HistoricoSolicitudesProvNombre);
                  AV21Options.Add(AV20Option, 0);
                  AV24OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV25count), "Z,ZZZ,ZZZ,ZZ9")), 0);
                  if ( AV21Options.Count == 10 )
                  {
                     /* Exit For each command. Update data (if necessary), close cursors & exit. */
                     if (true) break;
                  }
               }
               else
               {
                  AV16SkipItems = (short)(AV16SkipItems-1);
               }
            }
            if ( ! BRKBA2 )
            {
               BRKBA2 = true;
               pr_default.readNext(0);
            }
         }
         pr_default.close(0);
      }

      protected void GetHistoricoSolicitudesTotal( long A153HistoricoSolicitudesID )
      {
         /* Create private dbobjects */
         /* Navigation */
         A300HistoricoSolicitudesTotal = 0;
         /* Using cursor P00BA3 */
         pr_default.execute(1, new Object[] {A153HistoricoSolicitudesID});
         while ( (pr_default.getStatus(1) != 101) && ( P00BA3_A153HistoricoSolicitudesID[0] == A153HistoricoSolicitudesID ) )
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( P00BA3_A296HistoricoSolicitudesItemsSR[0])) || ( StringUtil.StrCmp(P00BA3_A297HistoricoSolicitudesItemsCT[0], "N") == 0 ) )
            {
               A294HItemsSolicitudesItemsPrecioIn = (decimal)(P00BA3_A295HItemsInventarioPrecioFinal[0]*P00BA3_A293HItemsSolicitudesItemsCantidad[0]);
            }
            else
            {
               if ( ( StringUtil.StrCmp(P00BA3_A297HistoricoSolicitudesItemsCT[0], "F") == 0 ) && ( StringUtil.StrCmp(P00BA3_A296HistoricoSolicitudesItemsSR[0], "R") == 0 ) )
               {
                  A294HItemsSolicitudesItemsPrecioIn = (decimal)((P00BA3_A295HItemsInventarioPrecioFinal[0]*P00BA3_A293HItemsSolicitudesItemsCantidad[0])-(P00BA3_A298HistoricoSolicitudesItemsComis[0]*P00BA3_A293HItemsSolicitudesItemsCantidad[0]));
               }
               else
               {
                  if ( ( StringUtil.StrCmp(P00BA3_A297HistoricoSolicitudesItemsCT[0], "F") == 0 ) && ( StringUtil.StrCmp(P00BA3_A296HistoricoSolicitudesItemsSR[0], "S") == 0 ) )
                  {
                     A294HItemsSolicitudesItemsPrecioIn = (decimal)((P00BA3_A295HItemsInventarioPrecioFinal[0]*P00BA3_A293HItemsSolicitudesItemsCantidad[0])+(P00BA3_A298HistoricoSolicitudesItemsComis[0]*P00BA3_A293HItemsSolicitudesItemsCantidad[0]));
                  }
                  else
                  {
                     if ( ( StringUtil.StrCmp(P00BA3_A297HistoricoSolicitudesItemsCT[0], "P") == 0 ) && ( StringUtil.StrCmp(P00BA3_A296HistoricoSolicitudesItemsSR[0], "R") == 0 ) )
                     {
                        A294HItemsSolicitudesItemsPrecioIn = (decimal)((P00BA3_A295HItemsInventarioPrecioFinal[0]*P00BA3_A293HItemsSolicitudesItemsCantidad[0])-((P00BA3_A295HItemsInventarioPrecioFinal[0]*P00BA3_A293HItemsSolicitudesItemsCantidad[0])*(P00BA3_A298HistoricoSolicitudesItemsComis[0]/ (decimal)(100))));
                     }
                     else
                     {
                        if ( ( StringUtil.StrCmp(P00BA3_A297HistoricoSolicitudesItemsCT[0], "P") == 0 ) && ( StringUtil.StrCmp(P00BA3_A296HistoricoSolicitudesItemsSR[0], "S") == 0 ) )
                        {
                           A294HItemsSolicitudesItemsPrecioIn = (decimal)((P00BA3_A295HItemsInventarioPrecioFinal[0]*P00BA3_A293HItemsSolicitudesItemsCantidad[0])+((P00BA3_A295HItemsInventarioPrecioFinal[0]*P00BA3_A293HItemsSolicitudesItemsCantidad[0])*(P00BA3_A298HistoricoSolicitudesItemsComis[0]/ (decimal)(100))));
                        }
                        else
                        {
                           A294HItemsSolicitudesItemsPrecioIn = 0;
                        }
                     }
                  }
               }
            }
            A300HistoricoSolicitudesTotal = (decimal)(A300HistoricoSolicitudesTotal+A294HItemsSolicitudesItemsPrecioIn);
            pr_default.readNext(1);
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
         AV34OptionsJson = "";
         AV35OptionsDescJson = "";
         AV36OptionIndexesJson = "";
         AV21Options = new GxSimpleCollection<string>();
         AV23OptionsDesc = new GxSimpleCollection<string>();
         AV24OptionIndexes = new GxSimpleCollection<string>();
         AV15SearchTxt = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV26Session = context.GetSession();
         AV28GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV29GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV37FilterFullText = "";
         AV13TFHistoricoSolicitudesProvNombre = "";
         AV14TFHistoricoSolicitudesProvNombre_Sel = "";
         AV44Historicosolicitudeswwds_1_filterfulltext = "";
         AV47Historicosolicitudeswwds_4_tfhistoricosolicitudesprovnombre = "";
         AV48Historicosolicitudeswwds_5_tfhistoricosolicitudesprovnombre_sel = "";
         lV44Historicosolicitudeswwds_1_filterfulltext = "";
         lV47Historicosolicitudeswwds_4_tfhistoricosolicitudesprovnombre = "";
         A634HistoricoSolicitudesProvNombre = "";
         A288HistoricoSolicitudesNombre = "";
         A289HistoricoSolicitudesTelefono = "";
         A290HistoricoSolicitudesMail = "";
         A291HistoricoSolicitudesDireccion = "";
         A306HistoricoSolicitudesFechaAlta = DateTime.MinValue;
         AV39FechaIni = DateTime.MinValue;
         AV40FechaFin = DateTime.MinValue;
         P00BA2_A634HistoricoSolicitudesProvNombre = new string[] {""} ;
         P00BA2_A306HistoricoSolicitudesFechaAlta = new DateTime[] {DateTime.MinValue} ;
         P00BA2_A131EstadosSolId = new int[1] ;
         P00BA2_A291HistoricoSolicitudesDireccion = new string[] {""} ;
         P00BA2_A290HistoricoSolicitudesMail = new string[] {""} ;
         P00BA2_n290HistoricoSolicitudesMail = new bool[] {false} ;
         P00BA2_A289HistoricoSolicitudesTelefono = new string[] {""} ;
         P00BA2_A288HistoricoSolicitudesNombre = new string[] {""} ;
         P00BA2_A153HistoricoSolicitudesID = new long[1] ;
         P00BA2_A633HistoricoSolicitudesProvID = new long[1] ;
         P00BA2_A299HistoricoSolicitudesCotizacion = new decimal[1] ;
         AV20Option = "";
         P00BA3_A153HistoricoSolicitudesID = new long[1] ;
         P00BA3_A154HistoricoSolicitudesItemsID = new short[1] ;
         P00BA3_A298HistoricoSolicitudesItemsComis = new decimal[1] ;
         P00BA3_A297HistoricoSolicitudesItemsCT = new string[] {""} ;
         P00BA3_A296HistoricoSolicitudesItemsSR = new string[] {""} ;
         P00BA3_A293HItemsSolicitudesItemsCantidad = new short[1] ;
         P00BA3_A295HItemsInventarioPrecioFinal = new short[1] ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.historicosolicitudeswwgetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P00BA2_A634HistoricoSolicitudesProvNombre, P00BA2_A306HistoricoSolicitudesFechaAlta, P00BA2_A131EstadosSolId, P00BA2_A291HistoricoSolicitudesDireccion, P00BA2_A290HistoricoSolicitudesMail, P00BA2_n290HistoricoSolicitudesMail, P00BA2_A289HistoricoSolicitudesTelefono, P00BA2_A288HistoricoSolicitudesNombre, P00BA2_A153HistoricoSolicitudesID, P00BA2_A633HistoricoSolicitudesProvID,
               P00BA2_A299HistoricoSolicitudesCotizacion
               }
               , new Object[] {
               P00BA3_A153HistoricoSolicitudesID, P00BA3_A154HistoricoSolicitudesItemsID, P00BA3_A298HistoricoSolicitudesItemsComis, P00BA3_A297HistoricoSolicitudesItemsCT, P00BA3_A296HistoricoSolicitudesItemsSR, P00BA3_A293HItemsSolicitudesItemsCantidad, P00BA3_A295HItemsInventarioPrecioFinal
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV18MaxItems ;
      private short AV17PageIndex ;
      private short AV16SkipItems ;
      private int AV42GXV1 ;
      private int AV38EstadosGenericosID ;
      private int A131EstadosSolId ;
      private long AV11TFHistoricoSolicitudesProvID ;
      private long AV12TFHistoricoSolicitudesProvID_To ;
      private long AV45Historicosolicitudeswwds_2_tfhistoricosolicitudesprovid ;
      private long AV46Historicosolicitudeswwds_3_tfhistoricosolicitudesprovid_to ;
      private long AV41ProveedorID ;
      private long A633HistoricoSolicitudesProvID ;
      private long A153HistoricoSolicitudesID ;
      private long AV25count ;
      private decimal A302HistoricoSolicitudServicioPFin ;
      private decimal A299HistoricoSolicitudesCotizacion ;
      private decimal A300HistoricoSolicitudesTotal ;
      private decimal A294HItemsSolicitudesItemsPrecioIn ;
      private string AV13TFHistoricoSolicitudesProvNombre ;
      private string AV14TFHistoricoSolicitudesProvNombre_Sel ;
      private string AV47Historicosolicitudeswwds_4_tfhistoricosolicitudesprovnombre ;
      private string AV48Historicosolicitudeswwds_5_tfhistoricosolicitudesprovnombre_sel ;
      private string lV47Historicosolicitudeswwds_4_tfhistoricosolicitudesprovnombre ;
      private string A634HistoricoSolicitudesProvNombre ;
      private string A288HistoricoSolicitudesNombre ;
      private string A289HistoricoSolicitudesTelefono ;
      private DateTime A306HistoricoSolicitudesFechaAlta ;
      private DateTime AV39FechaIni ;
      private DateTime AV40FechaFin ;
      private bool AV8IsAuthorized ;
      private bool GXt_boolean1 ;
      private bool returnInSub ;
      private bool BRKBA2 ;
      private bool n290HistoricoSolicitudesMail ;
      private string AV34OptionsJson ;
      private string AV35OptionsDescJson ;
      private string AV36OptionIndexesJson ;
      private string AV31DDOName ;
      private string AV32SearchTxtParms ;
      private string AV33SearchTxtTo ;
      private string AV15SearchTxt ;
      private string AV37FilterFullText ;
      private string AV44Historicosolicitudeswwds_1_filterfulltext ;
      private string lV44Historicosolicitudeswwds_1_filterfulltext ;
      private string A290HistoricoSolicitudesMail ;
      private string A291HistoricoSolicitudesDireccion ;
      private string AV20Option ;
      private IGxSession AV26Session ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GxSimpleCollection<string> AV21Options ;
      private GxSimpleCollection<string> AV23OptionsDesc ;
      private GxSimpleCollection<string> AV24OptionIndexes ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV28GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV29GridStateFilterValue ;
      private IDataStoreProvider pr_default ;
      private string[] P00BA2_A634HistoricoSolicitudesProvNombre ;
      private DateTime[] P00BA2_A306HistoricoSolicitudesFechaAlta ;
      private int[] P00BA2_A131EstadosSolId ;
      private string[] P00BA2_A291HistoricoSolicitudesDireccion ;
      private string[] P00BA2_A290HistoricoSolicitudesMail ;
      private bool[] P00BA2_n290HistoricoSolicitudesMail ;
      private string[] P00BA2_A289HistoricoSolicitudesTelefono ;
      private string[] P00BA2_A288HistoricoSolicitudesNombre ;
      private long[] P00BA2_A153HistoricoSolicitudesID ;
      private long[] P00BA2_A633HistoricoSolicitudesProvID ;
      private decimal[] P00BA2_A299HistoricoSolicitudesCotizacion ;
      private long[] P00BA3_A153HistoricoSolicitudesID ;
      private short[] P00BA3_A154HistoricoSolicitudesItemsID ;
      private decimal[] P00BA3_A298HistoricoSolicitudesItemsComis ;
      private string[] P00BA3_A297HistoricoSolicitudesItemsCT ;
      private string[] P00BA3_A296HistoricoSolicitudesItemsSR ;
      private short[] P00BA3_A293HItemsSolicitudesItemsCantidad ;
      private short[] P00BA3_A295HItemsInventarioPrecioFinal ;
      private string aP3_OptionsJson ;
      private string aP4_OptionsDescJson ;
      private string aP5_OptionIndexesJson ;
   }

   public class historicosolicitudeswwgetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00BA2( IGxContext context ,
                                             long AV45Historicosolicitudeswwds_2_tfhistoricosolicitudesprovid ,
                                             long AV46Historicosolicitudeswwds_3_tfhistoricosolicitudesprovid_to ,
                                             string AV48Historicosolicitudeswwds_5_tfhistoricosolicitudesprovnombre_sel ,
                                             string AV47Historicosolicitudeswwds_4_tfhistoricosolicitudesprovnombre ,
                                             int AV38EstadosGenericosID ,
                                             long AV41ProveedorID ,
                                             long A633HistoricoSolicitudesProvID ,
                                             string A634HistoricoSolicitudesProvNombre ,
                                             int A131EstadosSolId ,
                                             string AV44Historicosolicitudeswwds_1_filterfulltext ,
                                             long A153HistoricoSolicitudesID ,
                                             string A288HistoricoSolicitudesNombre ,
                                             string A289HistoricoSolicitudesTelefono ,
                                             string A290HistoricoSolicitudesMail ,
                                             string A291HistoricoSolicitudesDireccion ,
                                             decimal A302HistoricoSolicitudServicioPFin ,
                                             DateTime A306HistoricoSolicitudesFechaAlta ,
                                             DateTime AV39FechaIni ,
                                             DateTime AV40FechaFin )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int2 = new short[8];
         Object[] GXv_Object3 = new Object[2];
         scmdbuf = "SELECT [HistoricoSolicitudesProvNombre], [HistoricoSolicitudesFechaAlta], [EstadosSolId], [HistoricoSolicitudesDireccion], [HistoricoSolicitudesMail], [HistoricoSolicitudesTelefono], [HistoricoSolicitudesNombre], [HistoricoSolicitudesID], [HistoricoSolicitudesProvID], [HistoricoSolicitudesCotizacion] FROM [HistoricoSolicitudes]";
         AddWhere(sWhereString, "([HistoricoSolicitudesFechaAlta] >= @AV39FechaIni and [HistoricoSolicitudesFechaAlta] <= @AV40FechaFin)");
         if ( ! (0==AV45Historicosolicitudeswwds_2_tfhistoricosolicitudesprovid) )
         {
            AddWhere(sWhereString, "([HistoricoSolicitudesProvID] >= @AV45Historicosolicitudeswwds_2_tfhistoricosolicitudesprovid)");
         }
         else
         {
            GXv_int2[2] = 1;
         }
         if ( ! (0==AV46Historicosolicitudeswwds_3_tfhistoricosolicitudesprovid_to) )
         {
            AddWhere(sWhereString, "([HistoricoSolicitudesProvID] <= @AV46Historicosolicitudeswwds_3_tfhistoricosolicitudesprovid_to)");
         }
         else
         {
            GXv_int2[3] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV48Historicosolicitudeswwds_5_tfhistoricosolicitudesprovnombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV47Historicosolicitudeswwds_4_tfhistoricosolicitudesprovnombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER([HistoricoSolicitudesProvNombre]) like UPPER(@lV47Historicosolicitudeswwds_4_tfhistoricosolicitudesprovnombre))");
         }
         else
         {
            GXv_int2[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV48Historicosolicitudeswwds_5_tfhistoricosolicitudesprovnombre_sel)) && ! ( StringUtil.StrCmp(AV48Historicosolicitudeswwds_5_tfhistoricosolicitudesprovnombre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([HistoricoSolicitudesProvNombre] = @AV48Historicosolicitudeswwds_5_tfhistoricosolicitudesprovnombre_sel)");
         }
         else
         {
            GXv_int2[5] = 1;
         }
         if ( StringUtil.StrCmp(AV48Historicosolicitudeswwds_5_tfhistoricosolicitudesprovnombre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([HistoricoSolicitudesProvNombre] = ''))");
         }
         if ( ! ( AV38EstadosGenericosID == 0 ) )
         {
            AddWhere(sWhereString, "([EstadosSolId] = @AV38EstadosGenericosID)");
         }
         else
         {
            GXv_int2[6] = 1;
         }
         if ( ! (0==AV41ProveedorID) )
         {
            AddWhere(sWhereString, "([HistoricoSolicitudesProvID] = @AV41ProveedorID)");
         }
         else
         {
            GXv_int2[7] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY [HistoricoSolicitudesProvNombre]";
         GXv_Object3[0] = scmdbuf;
         GXv_Object3[1] = GXv_int2;
         return GXv_Object3 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_P00BA2(context, (long)dynConstraints[0] , (long)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (int)dynConstraints[4] , (long)dynConstraints[5] , (long)dynConstraints[6] , (string)dynConstraints[7] , (int)dynConstraints[8] , (string)dynConstraints[9] , (long)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (decimal)dynConstraints[15] , (DateTime)dynConstraints[16] , (DateTime)dynConstraints[17] , (DateTime)dynConstraints[18] );
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
          Object[] prmP00BA3;
          prmP00BA3 = new Object[] {
          new ParDef("@HistoricoSolicitudesID",GXType.Decimal,18,0)
          };
          Object[] prmP00BA2;
          prmP00BA2 = new Object[] {
          new ParDef("@AV39FechaIni",GXType.Date,8,0) ,
          new ParDef("@AV40FechaFin",GXType.Date,8,0) ,
          new ParDef("@AV45Historicosolicitudeswwds_2_tfhistoricosolicitudesprovid",GXType.Decimal,18,0) ,
          new ParDef("@AV46Historicosolicitudeswwds_3_tfhistoricosolicitudesprovid_to",GXType.Decimal,18,0) ,
          new ParDef("@lV47Historicosolicitudeswwds_4_tfhistoricosolicitudesprovnombre",GXType.Char,120,0) ,
          new ParDef("@AV48Historicosolicitudeswwds_5_tfhistoricosolicitudesprovnombre_sel",GXType.NChar,120,0) ,
          new ParDef("@AV38EstadosGenericosID",GXType.Int32,5,0) ,
          new ParDef("@AV41ProveedorID",GXType.Decimal,18,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00BA2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00BA2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00BA3", "SELECT [HistoricoSolicitudesID], [HistoricoSolicitudesItemsID], [HistoricoSolicitudesItemsComis], [HistoricoSolicitudesItemsCT], [HistoricoSolicitudesItemsSR], [HItemsSolicitudesItemsCantidad], [HItemsInventarioPrecioFinal] FROM [HistoricoSolicitudesItems] WHERE [HistoricoSolicitudesID] = @HistoricoSolicitudesID ORDER BY [HistoricoSolicitudesID] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00BA3,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[0])[0] = rslt.getString(1, 120);
                ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
                ((int[]) buf[2])[0] = rslt.getInt(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((bool[]) buf[5])[0] = rslt.wasNull(5);
                ((string[]) buf[6])[0] = rslt.getString(6, 20);
                ((string[]) buf[7])[0] = rslt.getString(7, 100);
                ((long[]) buf[8])[0] = rslt.getLong(8);
                ((long[]) buf[9])[0] = rslt.getLong(9);
                ((decimal[]) buf[10])[0] = rslt.getDecimal(10);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((decimal[]) buf[2])[0] = rslt.getDecimal(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 1);
                ((string[]) buf[4])[0] = rslt.getString(5, 1);
                ((short[]) buf[5])[0] = rslt.getShort(6);
                ((short[]) buf[6])[0] = rslt.getShort(7);
                return;
       }
    }

 }

 [ServiceContract(Namespace = "GeneXus.Programs.historicosolicitudeswwgetfilterdata_services")]
 [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple)]
 [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
 public class historicosolicitudeswwgetfilterdata_services : GxRestService
 {
    [OperationContract(Name = "HistoricoSolicitudesWWGetFilterData" )]
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
          if ( ! ProcessHeaders("historicosolicitudeswwgetfilterdata") )
          {
             return  ;
          }
          historicosolicitudeswwgetfilterdata worker = new historicosolicitudeswwgetfilterdata(context);
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

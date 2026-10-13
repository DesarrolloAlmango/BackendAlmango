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
   public class proveedorwwgetfilterdata : GXProcedure
   {
      public proveedorwwgetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public proveedorwwgetfilterdata( IGxContext context )
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
         new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWProveedor", out  GXt_boolean1) ;
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
            if ( StringUtil.StrCmp(StringUtil.Upper( AV41DDOName), "DDO_PROVEEDORNOMBRE") == 0 )
            {
               /* Execute user subroutine: 'LOADPROVEEDORNOMBREOPTIONS' */
               S121 ();
               if ( returnInSub )
               {
                  cleanup();
                  if (true) return;
               }
            }
            else if ( StringUtil.StrCmp(StringUtil.Upper( AV41DDOName), "DDO_PROVEEDORDOCIDENTIDAD") == 0 )
            {
               /* Execute user subroutine: 'LOADPROVEEDORDOCIDENTIDADOPTIONS' */
               S131 ();
               if ( returnInSub )
               {
                  cleanup();
                  if (true) return;
               }
            }
            else if ( StringUtil.StrCmp(StringUtil.Upper( AV41DDOName), "DDO_PROVEEDORTELEFONO") == 0 )
            {
               /* Execute user subroutine: 'LOADPROVEEDORTELEFONOOPTIONS' */
               S141 ();
               if ( returnInSub )
               {
                  cleanup();
                  if (true) return;
               }
            }
            else if ( StringUtil.StrCmp(StringUtil.Upper( AV41DDOName), "DDO_PROVEEDORDIRECCION") == 0 )
            {
               /* Execute user subroutine: 'LOADPROVEEDORDIRECCIONOPTIONS' */
               S151 ();
               if ( returnInSub )
               {
                  cleanup();
                  if (true) return;
               }
            }
            else if ( StringUtil.StrCmp(StringUtil.Upper( AV41DDOName), "DDO_PROVEEDOREMAIL") == 0 )
            {
               /* Execute user subroutine: 'LOADPROVEEDOREMAILOPTIONS' */
               S161 ();
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
         if ( StringUtil.StrCmp(AV36Session.Get("ProveedorWWGridState"), "") == 0 )
         {
            AV38GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "ProveedorWWGridState"), null, "", "");
         }
         else
         {
            AV38GridState.FromXml(AV36Session.Get("ProveedorWWGridState"), null, "", "");
         }
         AV66GXV1 = 1;
         while ( AV66GXV1 <= AV38GridState.gxTpr_Filtervalues.Count )
         {
            AV39GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV38GridState.gxTpr_Filtervalues.Item(AV66GXV1));
            if ( StringUtil.StrCmp(AV39GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV47FilterFullText = AV39GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV39GridStateFilterValue.gxTpr_Name, "TFPROVEEDORID") == 0 )
            {
               AV11TFProveedorID = (long)(Math.Round(NumberUtil.Val( AV39GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV12TFProveedorID_To = (long)(Math.Round(NumberUtil.Val( AV39GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV39GridStateFilterValue.gxTpr_Name, "TFPROVEEDORNOMBRE") == 0 )
            {
               AV13TFProveedorNombre = AV39GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV39GridStateFilterValue.gxTpr_Name, "TFPROVEEDORNOMBRE_SEL") == 0 )
            {
               AV14TFProveedorNombre_Sel = AV39GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV39GridStateFilterValue.gxTpr_Name, "TFPROVEEDORDOCIDENTIDAD") == 0 )
            {
               AV15TFProveedorDocIdentidad = AV39GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV39GridStateFilterValue.gxTpr_Name, "TFPROVEEDORDOCIDENTIDAD_SEL") == 0 )
            {
               AV16TFProveedorDocIdentidad_Sel = AV39GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV39GridStateFilterValue.gxTpr_Name, "TFPROVEEDORTELEFONO") == 0 )
            {
               AV17TFProveedorTelefono = AV39GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV39GridStateFilterValue.gxTpr_Name, "TFPROVEEDORTELEFONO_SEL") == 0 )
            {
               AV18TFProveedorTelefono_Sel = AV39GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV39GridStateFilterValue.gxTpr_Name, "TFPROVEEDORDIRECCION") == 0 )
            {
               AV19TFProveedorDireccion = AV39GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV39GridStateFilterValue.gxTpr_Name, "TFPROVEEDORDIRECCION_SEL") == 0 )
            {
               AV20TFProveedorDireccion_Sel = AV39GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV39GridStateFilterValue.gxTpr_Name, "TFPROVEEDOREMAIL") == 0 )
            {
               AV21TFProveedorEmail = AV39GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV39GridStateFilterValue.gxTpr_Name, "TFPROVEEDOREMAIL_SEL") == 0 )
            {
               AV22TFProveedorEmail_Sel = AV39GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV39GridStateFilterValue.gxTpr_Name, "TFPROVEEDORPAGODEFAULT_SEL") == 0 )
            {
               AV63TFProveedorPagoDefault_SelsJson = AV39GridStateFilterValue.gxTpr_Value;
               AV64TFProveedorPagoDefault_Sels.FromJSonString(AV63TFProveedorPagoDefault_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV39GridStateFilterValue.gxTpr_Name, "TFPROVEEDORESTADO_SEL") == 0 )
            {
               AV23TFProveedorEstado_SelsJson = AV39GridStateFilterValue.gxTpr_Value;
               AV24TFProveedorEstado_Sels.FromJSonString(AV23TFProveedorEstado_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV39GridStateFilterValue.gxTpr_Name, "GRIDCFFILTER") == 0 )
            {
               AV48GridConditionalFormattingFilter = (short)(Math.Round(NumberUtil.Val( AV39GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
            }
            AV66GXV1 = (int)(AV66GXV1+1);
         }
      }

      protected void S121( )
      {
         /* 'LOADPROVEEDORNOMBREOPTIONS' Routine */
         returnInSub = false;
         AV13TFProveedorNombre = AV25SearchTxt;
         AV14TFProveedorNombre_Sel = "";
         AV68Proveedorwwds_1_gridconditionalformattingfilter = AV48GridConditionalFormattingFilter;
         AV69Proveedorwwds_2_filterfulltext = AV47FilterFullText;
         AV70Proveedorwwds_3_tfproveedorid = AV11TFProveedorID;
         AV71Proveedorwwds_4_tfproveedorid_to = AV12TFProveedorID_To;
         AV72Proveedorwwds_5_tfproveedornombre = AV13TFProveedorNombre;
         AV73Proveedorwwds_6_tfproveedornombre_sel = AV14TFProveedorNombre_Sel;
         AV74Proveedorwwds_7_tfproveedordocidentidad = AV15TFProveedorDocIdentidad;
         AV75Proveedorwwds_8_tfproveedordocidentidad_sel = AV16TFProveedorDocIdentidad_Sel;
         AV76Proveedorwwds_9_tfproveedortelefono = AV17TFProveedorTelefono;
         AV77Proveedorwwds_10_tfproveedortelefono_sel = AV18TFProveedorTelefono_Sel;
         AV78Proveedorwwds_11_tfproveedordireccion = AV19TFProveedorDireccion;
         AV79Proveedorwwds_12_tfproveedordireccion_sel = AV20TFProveedorDireccion_Sel;
         AV80Proveedorwwds_13_tfproveedoremail = AV21TFProveedorEmail;
         AV81Proveedorwwds_14_tfproveedoremail_sel = AV22TFProveedorEmail_Sel;
         AV82Proveedorwwds_15_tfproveedorpagodefault_sels = AV64TFProveedorPagoDefault_Sels;
         AV83Proveedorwwds_16_tfproveedorestado_sels = AV24TFProveedorEstado_Sels;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A440ProveedorPagoDefault ,
                                              AV82Proveedorwwds_15_tfproveedorpagodefault_sels ,
                                              A344ProveedorEstado ,
                                              AV83Proveedorwwds_16_tfproveedorestado_sels ,
                                              AV68Proveedorwwds_1_gridconditionalformattingfilter ,
                                              AV70Proveedorwwds_3_tfproveedorid ,
                                              AV71Proveedorwwds_4_tfproveedorid_to ,
                                              AV73Proveedorwwds_6_tfproveedornombre_sel ,
                                              AV72Proveedorwwds_5_tfproveedornombre ,
                                              AV75Proveedorwwds_8_tfproveedordocidentidad_sel ,
                                              AV74Proveedorwwds_7_tfproveedordocidentidad ,
                                              AV77Proveedorwwds_10_tfproveedortelefono_sel ,
                                              AV76Proveedorwwds_9_tfproveedortelefono ,
                                              AV79Proveedorwwds_12_tfproveedordireccion_sel ,
                                              AV78Proveedorwwds_11_tfproveedordireccion ,
                                              AV81Proveedorwwds_14_tfproveedoremail_sel ,
                                              AV80Proveedorwwds_13_tfproveedoremail ,
                                              AV82Proveedorwwds_15_tfproveedorpagodefault_sels.Count ,
                                              AV83Proveedorwwds_16_tfproveedorestado_sels.Count ,
                                              AV65VerTodProv ,
                                              AV84Hacerload ,
                                              A133ProveedorID ,
                                              A282ProveedorNombre ,
                                              A338ProveedorDocIdentidad ,
                                              A430ProveedorTelefono ,
                                              A431ProveedorDireccion ,
                                              A433ProveedorEmail ,
                                              AV69Proveedorwwds_2_filterfulltext } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN,
                                              TypeConstants.BOOLEAN
                                              }
         });
         lV72Proveedorwwds_5_tfproveedornombre = StringUtil.PadR( StringUtil.RTrim( AV72Proveedorwwds_5_tfproveedornombre), 80, "%");
         lV74Proveedorwwds_7_tfproveedordocidentidad = StringUtil.PadR( StringUtil.RTrim( AV74Proveedorwwds_7_tfproveedordocidentidad), 25, "%");
         lV76Proveedorwwds_9_tfproveedortelefono = StringUtil.PadR( StringUtil.RTrim( AV76Proveedorwwds_9_tfproveedortelefono), 20, "%");
         lV78Proveedorwwds_11_tfproveedordireccion = StringUtil.Concat( StringUtil.RTrim( AV78Proveedorwwds_11_tfproveedordireccion), "%", "");
         lV80Proveedorwwds_13_tfproveedoremail = StringUtil.Concat( StringUtil.RTrim( AV80Proveedorwwds_13_tfproveedoremail), "%", "");
         /* Using cursor P006V2 */
         pr_default.execute(0, new Object[] {AV84Hacerload, AV70Proveedorwwds_3_tfproveedorid, AV71Proveedorwwds_4_tfproveedorid_to, lV72Proveedorwwds_5_tfproveedornombre, AV73Proveedorwwds_6_tfproveedornombre_sel, lV74Proveedorwwds_7_tfproveedordocidentidad, AV75Proveedorwwds_8_tfproveedordocidentidad_sel, lV76Proveedorwwds_9_tfproveedortelefono, AV77Proveedorwwds_10_tfproveedortelefono_sel, lV78Proveedorwwds_11_tfproveedordireccion, AV79Proveedorwwds_12_tfproveedordireccion_sel, lV80Proveedorwwds_13_tfproveedoremail, AV81Proveedorwwds_14_tfproveedoremail_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRK6V2 = false;
            A282ProveedorNombre = P006V2_A282ProveedorNombre[0];
            A433ProveedorEmail = P006V2_A433ProveedorEmail[0];
            n433ProveedorEmail = P006V2_n433ProveedorEmail[0];
            A431ProveedorDireccion = P006V2_A431ProveedorDireccion[0];
            n431ProveedorDireccion = P006V2_n431ProveedorDireccion[0];
            A430ProveedorTelefono = P006V2_A430ProveedorTelefono[0];
            n430ProveedorTelefono = P006V2_n430ProveedorTelefono[0];
            A338ProveedorDocIdentidad = P006V2_A338ProveedorDocIdentidad[0];
            A133ProveedorID = P006V2_A133ProveedorID[0];
            A344ProveedorEstado = P006V2_A344ProveedorEstado[0];
            A440ProveedorPagoDefault = P006V2_A440ProveedorPagoDefault[0];
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV69Proveedorwwds_2_filterfulltext)) || ( ( StringUtil.Like( StringUtil.Str( (decimal)(A133ProveedorID), 18, 0) , StringUtil.PadR( "%" + AV69Proveedorwwds_2_filterfulltext , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A282ProveedorNombre) , StringUtil.PadR( "%" + StringUtil.Upper( AV69Proveedorwwds_2_filterfulltext) , 255 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Upper( A338ProveedorDocIdentidad) , StringUtil.PadR( "%" + StringUtil.Upper( AV69Proveedorwwds_2_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A430ProveedorTelefono) , StringUtil.PadR( "%" + StringUtil.Upper( AV69Proveedorwwds_2_filterfulltext) , 255 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Upper( A431ProveedorDireccion) , StringUtil.PadR( "%" + StringUtil.Upper( AV69Proveedorwwds_2_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A433ProveedorEmail) , StringUtil.PadR( "%" + StringUtil.Upper( AV69Proveedorwwds_2_filterfulltext) , 255 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( context.GetMessage( "cobro directo", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV69Proveedorwwds_2_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A440ProveedorPagoDefault, "F") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "cobro prepago comercio", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV69Proveedorwwds_2_filterfulltext) , 255 , "%"),  ' ' ) &&
            ( StringUtil.StrCmp(A440ProveedorPagoDefault, "T") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "cobro prepago almango", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV69Proveedorwwds_2_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A440ProveedorPagoDefault, "O") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "habilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV69Proveedorwwds_2_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A344ProveedorEstado, "HAB") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "deshabilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV69Proveedorwwds_2_filterfulltext) , 255 , "%"),  ' ' ) &&
            ( StringUtil.StrCmp(A344ProveedorEstado, "DES") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "pendiente", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV69Proveedorwwds_2_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A344ProveedorEstado, "PEN") == 0 ) ) )
            )
            {
               AV35count = 0;
               while ( (pr_default.getStatus(0) != 101) && ( StringUtil.StrCmp(P006V2_A282ProveedorNombre[0], A282ProveedorNombre) == 0 ) )
               {
                  BRK6V2 = false;
                  A133ProveedorID = P006V2_A133ProveedorID[0];
                  AV35count = (long)(AV35count+1);
                  BRK6V2 = true;
                  pr_default.readNext(0);
               }
               if ( (0==AV26SkipItems) )
               {
                  AV30Option = (String.IsNullOrEmpty(StringUtil.RTrim( A282ProveedorNombre)) ? "<#Empty#>" : A282ProveedorNombre);
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
            }
            if ( ! BRK6V2 )
            {
               BRK6V2 = true;
               pr_default.readNext(0);
            }
         }
         pr_default.close(0);
      }

      protected void S131( )
      {
         /* 'LOADPROVEEDORDOCIDENTIDADOPTIONS' Routine */
         returnInSub = false;
         AV15TFProveedorDocIdentidad = AV25SearchTxt;
         AV16TFProveedorDocIdentidad_Sel = "";
         AV68Proveedorwwds_1_gridconditionalformattingfilter = AV48GridConditionalFormattingFilter;
         AV69Proveedorwwds_2_filterfulltext = AV47FilterFullText;
         AV70Proveedorwwds_3_tfproveedorid = AV11TFProveedorID;
         AV71Proveedorwwds_4_tfproveedorid_to = AV12TFProveedorID_To;
         AV72Proveedorwwds_5_tfproveedornombre = AV13TFProveedorNombre;
         AV73Proveedorwwds_6_tfproveedornombre_sel = AV14TFProveedorNombre_Sel;
         AV74Proveedorwwds_7_tfproveedordocidentidad = AV15TFProveedorDocIdentidad;
         AV75Proveedorwwds_8_tfproveedordocidentidad_sel = AV16TFProveedorDocIdentidad_Sel;
         AV76Proveedorwwds_9_tfproveedortelefono = AV17TFProveedorTelefono;
         AV77Proveedorwwds_10_tfproveedortelefono_sel = AV18TFProveedorTelefono_Sel;
         AV78Proveedorwwds_11_tfproveedordireccion = AV19TFProveedorDireccion;
         AV79Proveedorwwds_12_tfproveedordireccion_sel = AV20TFProveedorDireccion_Sel;
         AV80Proveedorwwds_13_tfproveedoremail = AV21TFProveedorEmail;
         AV81Proveedorwwds_14_tfproveedoremail_sel = AV22TFProveedorEmail_Sel;
         AV82Proveedorwwds_15_tfproveedorpagodefault_sels = AV64TFProveedorPagoDefault_Sels;
         AV83Proveedorwwds_16_tfproveedorestado_sels = AV24TFProveedorEstado_Sels;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              A440ProveedorPagoDefault ,
                                              AV82Proveedorwwds_15_tfproveedorpagodefault_sels ,
                                              A344ProveedorEstado ,
                                              AV83Proveedorwwds_16_tfproveedorestado_sels ,
                                              AV68Proveedorwwds_1_gridconditionalformattingfilter ,
                                              AV70Proveedorwwds_3_tfproveedorid ,
                                              AV71Proveedorwwds_4_tfproveedorid_to ,
                                              AV73Proveedorwwds_6_tfproveedornombre_sel ,
                                              AV72Proveedorwwds_5_tfproveedornombre ,
                                              AV75Proveedorwwds_8_tfproveedordocidentidad_sel ,
                                              AV74Proveedorwwds_7_tfproveedordocidentidad ,
                                              AV77Proveedorwwds_10_tfproveedortelefono_sel ,
                                              AV76Proveedorwwds_9_tfproveedortelefono ,
                                              AV79Proveedorwwds_12_tfproveedordireccion_sel ,
                                              AV78Proveedorwwds_11_tfproveedordireccion ,
                                              AV81Proveedorwwds_14_tfproveedoremail_sel ,
                                              AV80Proveedorwwds_13_tfproveedoremail ,
                                              AV82Proveedorwwds_15_tfproveedorpagodefault_sels.Count ,
                                              AV83Proveedorwwds_16_tfproveedorestado_sels.Count ,
                                              AV65VerTodProv ,
                                              AV84Hacerload ,
                                              A133ProveedorID ,
                                              A282ProveedorNombre ,
                                              A338ProveedorDocIdentidad ,
                                              A430ProveedorTelefono ,
                                              A431ProveedorDireccion ,
                                              A433ProveedorEmail ,
                                              AV69Proveedorwwds_2_filterfulltext } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN,
                                              TypeConstants.BOOLEAN
                                              }
         });
         lV72Proveedorwwds_5_tfproveedornombre = StringUtil.PadR( StringUtil.RTrim( AV72Proveedorwwds_5_tfproveedornombre), 80, "%");
         lV74Proveedorwwds_7_tfproveedordocidentidad = StringUtil.PadR( StringUtil.RTrim( AV74Proveedorwwds_7_tfproveedordocidentidad), 25, "%");
         lV76Proveedorwwds_9_tfproveedortelefono = StringUtil.PadR( StringUtil.RTrim( AV76Proveedorwwds_9_tfproveedortelefono), 20, "%");
         lV78Proveedorwwds_11_tfproveedordireccion = StringUtil.Concat( StringUtil.RTrim( AV78Proveedorwwds_11_tfproveedordireccion), "%", "");
         lV80Proveedorwwds_13_tfproveedoremail = StringUtil.Concat( StringUtil.RTrim( AV80Proveedorwwds_13_tfproveedoremail), "%", "");
         /* Using cursor P006V3 */
         pr_default.execute(1, new Object[] {AV84Hacerload, AV70Proveedorwwds_3_tfproveedorid, AV71Proveedorwwds_4_tfproveedorid_to, lV72Proveedorwwds_5_tfproveedornombre, AV73Proveedorwwds_6_tfproveedornombre_sel, lV74Proveedorwwds_7_tfproveedordocidentidad, AV75Proveedorwwds_8_tfproveedordocidentidad_sel, lV76Proveedorwwds_9_tfproveedortelefono, AV77Proveedorwwds_10_tfproveedortelefono_sel, lV78Proveedorwwds_11_tfproveedordireccion, AV79Proveedorwwds_12_tfproveedordireccion_sel, lV80Proveedorwwds_13_tfproveedoremail, AV81Proveedorwwds_14_tfproveedoremail_sel});
         while ( (pr_default.getStatus(1) != 101) )
         {
            BRK6V4 = false;
            A338ProveedorDocIdentidad = P006V3_A338ProveedorDocIdentidad[0];
            A433ProveedorEmail = P006V3_A433ProveedorEmail[0];
            n433ProveedorEmail = P006V3_n433ProveedorEmail[0];
            A431ProveedorDireccion = P006V3_A431ProveedorDireccion[0];
            n431ProveedorDireccion = P006V3_n431ProveedorDireccion[0];
            A430ProveedorTelefono = P006V3_A430ProveedorTelefono[0];
            n430ProveedorTelefono = P006V3_n430ProveedorTelefono[0];
            A282ProveedorNombre = P006V3_A282ProveedorNombre[0];
            A133ProveedorID = P006V3_A133ProveedorID[0];
            A344ProveedorEstado = P006V3_A344ProveedorEstado[0];
            A440ProveedorPagoDefault = P006V3_A440ProveedorPagoDefault[0];
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV69Proveedorwwds_2_filterfulltext)) || ( ( StringUtil.Like( StringUtil.Str( (decimal)(A133ProveedorID), 18, 0) , StringUtil.PadR( "%" + AV69Proveedorwwds_2_filterfulltext , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A282ProveedorNombre) , StringUtil.PadR( "%" + StringUtil.Upper( AV69Proveedorwwds_2_filterfulltext) , 255 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Upper( A338ProveedorDocIdentidad) , StringUtil.PadR( "%" + StringUtil.Upper( AV69Proveedorwwds_2_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A430ProveedorTelefono) , StringUtil.PadR( "%" + StringUtil.Upper( AV69Proveedorwwds_2_filterfulltext) , 255 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Upper( A431ProveedorDireccion) , StringUtil.PadR( "%" + StringUtil.Upper( AV69Proveedorwwds_2_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A433ProveedorEmail) , StringUtil.PadR( "%" + StringUtil.Upper( AV69Proveedorwwds_2_filterfulltext) , 255 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( context.GetMessage( "cobro directo", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV69Proveedorwwds_2_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A440ProveedorPagoDefault, "F") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "cobro prepago comercio", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV69Proveedorwwds_2_filterfulltext) , 255 , "%"),  ' ' ) &&
            ( StringUtil.StrCmp(A440ProveedorPagoDefault, "T") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "cobro prepago almango", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV69Proveedorwwds_2_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A440ProveedorPagoDefault, "O") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "habilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV69Proveedorwwds_2_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A344ProveedorEstado, "HAB") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "deshabilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV69Proveedorwwds_2_filterfulltext) , 255 , "%"),  ' ' ) &&
            ( StringUtil.StrCmp(A344ProveedorEstado, "DES") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "pendiente", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV69Proveedorwwds_2_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A344ProveedorEstado, "PEN") == 0 ) ) )
            )
            {
               AV35count = 0;
               while ( (pr_default.getStatus(1) != 101) && ( StringUtil.StrCmp(P006V3_A338ProveedorDocIdentidad[0], A338ProveedorDocIdentidad) == 0 ) )
               {
                  BRK6V4 = false;
                  A133ProveedorID = P006V3_A133ProveedorID[0];
                  AV35count = (long)(AV35count+1);
                  BRK6V4 = true;
                  pr_default.readNext(1);
               }
               if ( (0==AV26SkipItems) )
               {
                  AV30Option = (String.IsNullOrEmpty(StringUtil.RTrim( A338ProveedorDocIdentidad)) ? "<#Empty#>" : A338ProveedorDocIdentidad);
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
            }
            if ( ! BRK6V4 )
            {
               BRK6V4 = true;
               pr_default.readNext(1);
            }
         }
         pr_default.close(1);
      }

      protected void S141( )
      {
         /* 'LOADPROVEEDORTELEFONOOPTIONS' Routine */
         returnInSub = false;
         AV17TFProveedorTelefono = AV25SearchTxt;
         AV18TFProveedorTelefono_Sel = "";
         AV68Proveedorwwds_1_gridconditionalformattingfilter = AV48GridConditionalFormattingFilter;
         AV69Proveedorwwds_2_filterfulltext = AV47FilterFullText;
         AV70Proveedorwwds_3_tfproveedorid = AV11TFProveedorID;
         AV71Proveedorwwds_4_tfproveedorid_to = AV12TFProveedorID_To;
         AV72Proveedorwwds_5_tfproveedornombre = AV13TFProveedorNombre;
         AV73Proveedorwwds_6_tfproveedornombre_sel = AV14TFProveedorNombre_Sel;
         AV74Proveedorwwds_7_tfproveedordocidentidad = AV15TFProveedorDocIdentidad;
         AV75Proveedorwwds_8_tfproveedordocidentidad_sel = AV16TFProveedorDocIdentidad_Sel;
         AV76Proveedorwwds_9_tfproveedortelefono = AV17TFProveedorTelefono;
         AV77Proveedorwwds_10_tfproveedortelefono_sel = AV18TFProveedorTelefono_Sel;
         AV78Proveedorwwds_11_tfproveedordireccion = AV19TFProveedorDireccion;
         AV79Proveedorwwds_12_tfproveedordireccion_sel = AV20TFProveedorDireccion_Sel;
         AV80Proveedorwwds_13_tfproveedoremail = AV21TFProveedorEmail;
         AV81Proveedorwwds_14_tfproveedoremail_sel = AV22TFProveedorEmail_Sel;
         AV82Proveedorwwds_15_tfproveedorpagodefault_sels = AV64TFProveedorPagoDefault_Sels;
         AV83Proveedorwwds_16_tfproveedorestado_sels = AV24TFProveedorEstado_Sels;
         pr_default.dynParam(2, new Object[]{ new Object[]{
                                              A440ProveedorPagoDefault ,
                                              AV82Proveedorwwds_15_tfproveedorpagodefault_sels ,
                                              A344ProveedorEstado ,
                                              AV83Proveedorwwds_16_tfproveedorestado_sels ,
                                              AV68Proveedorwwds_1_gridconditionalformattingfilter ,
                                              AV70Proveedorwwds_3_tfproveedorid ,
                                              AV71Proveedorwwds_4_tfproveedorid_to ,
                                              AV73Proveedorwwds_6_tfproveedornombre_sel ,
                                              AV72Proveedorwwds_5_tfproveedornombre ,
                                              AV75Proveedorwwds_8_tfproveedordocidentidad_sel ,
                                              AV74Proveedorwwds_7_tfproveedordocidentidad ,
                                              AV77Proveedorwwds_10_tfproveedortelefono_sel ,
                                              AV76Proveedorwwds_9_tfproveedortelefono ,
                                              AV79Proveedorwwds_12_tfproveedordireccion_sel ,
                                              AV78Proveedorwwds_11_tfproveedordireccion ,
                                              AV81Proveedorwwds_14_tfproveedoremail_sel ,
                                              AV80Proveedorwwds_13_tfproveedoremail ,
                                              AV82Proveedorwwds_15_tfproveedorpagodefault_sels.Count ,
                                              AV83Proveedorwwds_16_tfproveedorestado_sels.Count ,
                                              AV65VerTodProv ,
                                              AV84Hacerload ,
                                              A133ProveedorID ,
                                              A282ProveedorNombre ,
                                              A338ProveedorDocIdentidad ,
                                              A430ProveedorTelefono ,
                                              A431ProveedorDireccion ,
                                              A433ProveedorEmail ,
                                              AV69Proveedorwwds_2_filterfulltext } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN,
                                              TypeConstants.BOOLEAN
                                              }
         });
         lV72Proveedorwwds_5_tfproveedornombre = StringUtil.PadR( StringUtil.RTrim( AV72Proveedorwwds_5_tfproveedornombre), 80, "%");
         lV74Proveedorwwds_7_tfproveedordocidentidad = StringUtil.PadR( StringUtil.RTrim( AV74Proveedorwwds_7_tfproveedordocidentidad), 25, "%");
         lV76Proveedorwwds_9_tfproveedortelefono = StringUtil.PadR( StringUtil.RTrim( AV76Proveedorwwds_9_tfproveedortelefono), 20, "%");
         lV78Proveedorwwds_11_tfproveedordireccion = StringUtil.Concat( StringUtil.RTrim( AV78Proveedorwwds_11_tfproveedordireccion), "%", "");
         lV80Proveedorwwds_13_tfproveedoremail = StringUtil.Concat( StringUtil.RTrim( AV80Proveedorwwds_13_tfproveedoremail), "%", "");
         /* Using cursor P006V4 */
         pr_default.execute(2, new Object[] {AV84Hacerload, AV70Proveedorwwds_3_tfproveedorid, AV71Proveedorwwds_4_tfproveedorid_to, lV72Proveedorwwds_5_tfproveedornombre, AV73Proveedorwwds_6_tfproveedornombre_sel, lV74Proveedorwwds_7_tfproveedordocidentidad, AV75Proveedorwwds_8_tfproveedordocidentidad_sel, lV76Proveedorwwds_9_tfproveedortelefono, AV77Proveedorwwds_10_tfproveedortelefono_sel, lV78Proveedorwwds_11_tfproveedordireccion, AV79Proveedorwwds_12_tfproveedordireccion_sel, lV80Proveedorwwds_13_tfproveedoremail, AV81Proveedorwwds_14_tfproveedoremail_sel});
         while ( (pr_default.getStatus(2) != 101) )
         {
            BRK6V6 = false;
            A430ProveedorTelefono = P006V4_A430ProveedorTelefono[0];
            n430ProveedorTelefono = P006V4_n430ProveedorTelefono[0];
            A433ProveedorEmail = P006V4_A433ProveedorEmail[0];
            n433ProveedorEmail = P006V4_n433ProveedorEmail[0];
            A431ProveedorDireccion = P006V4_A431ProveedorDireccion[0];
            n431ProveedorDireccion = P006V4_n431ProveedorDireccion[0];
            A338ProveedorDocIdentidad = P006V4_A338ProveedorDocIdentidad[0];
            A282ProveedorNombre = P006V4_A282ProveedorNombre[0];
            A133ProveedorID = P006V4_A133ProveedorID[0];
            A344ProveedorEstado = P006V4_A344ProveedorEstado[0];
            A440ProveedorPagoDefault = P006V4_A440ProveedorPagoDefault[0];
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV69Proveedorwwds_2_filterfulltext)) || ( ( StringUtil.Like( StringUtil.Str( (decimal)(A133ProveedorID), 18, 0) , StringUtil.PadR( "%" + AV69Proveedorwwds_2_filterfulltext , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A282ProveedorNombre) , StringUtil.PadR( "%" + StringUtil.Upper( AV69Proveedorwwds_2_filterfulltext) , 255 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Upper( A338ProveedorDocIdentidad) , StringUtil.PadR( "%" + StringUtil.Upper( AV69Proveedorwwds_2_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A430ProveedorTelefono) , StringUtil.PadR( "%" + StringUtil.Upper( AV69Proveedorwwds_2_filterfulltext) , 255 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Upper( A431ProveedorDireccion) , StringUtil.PadR( "%" + StringUtil.Upper( AV69Proveedorwwds_2_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A433ProveedorEmail) , StringUtil.PadR( "%" + StringUtil.Upper( AV69Proveedorwwds_2_filterfulltext) , 255 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( context.GetMessage( "cobro directo", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV69Proveedorwwds_2_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A440ProveedorPagoDefault, "F") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "cobro prepago comercio", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV69Proveedorwwds_2_filterfulltext) , 255 , "%"),  ' ' ) &&
            ( StringUtil.StrCmp(A440ProveedorPagoDefault, "T") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "cobro prepago almango", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV69Proveedorwwds_2_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A440ProveedorPagoDefault, "O") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "habilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV69Proveedorwwds_2_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A344ProveedorEstado, "HAB") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "deshabilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV69Proveedorwwds_2_filterfulltext) , 255 , "%"),  ' ' ) &&
            ( StringUtil.StrCmp(A344ProveedorEstado, "DES") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "pendiente", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV69Proveedorwwds_2_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A344ProveedorEstado, "PEN") == 0 ) ) )
            )
            {
               AV35count = 0;
               while ( (pr_default.getStatus(2) != 101) && ( StringUtil.StrCmp(P006V4_A430ProveedorTelefono[0], A430ProveedorTelefono) == 0 ) )
               {
                  BRK6V6 = false;
                  A133ProveedorID = P006V4_A133ProveedorID[0];
                  AV35count = (long)(AV35count+1);
                  BRK6V6 = true;
                  pr_default.readNext(2);
               }
               if ( (0==AV26SkipItems) )
               {
                  AV30Option = (String.IsNullOrEmpty(StringUtil.RTrim( A430ProveedorTelefono)) ? "<#Empty#>" : A430ProveedorTelefono);
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
            }
            if ( ! BRK6V6 )
            {
               BRK6V6 = true;
               pr_default.readNext(2);
            }
         }
         pr_default.close(2);
      }

      protected void S151( )
      {
         /* 'LOADPROVEEDORDIRECCIONOPTIONS' Routine */
         returnInSub = false;
         AV19TFProveedorDireccion = AV25SearchTxt;
         AV20TFProveedorDireccion_Sel = "";
         AV68Proveedorwwds_1_gridconditionalformattingfilter = AV48GridConditionalFormattingFilter;
         AV69Proveedorwwds_2_filterfulltext = AV47FilterFullText;
         AV70Proveedorwwds_3_tfproveedorid = AV11TFProveedorID;
         AV71Proveedorwwds_4_tfproveedorid_to = AV12TFProveedorID_To;
         AV72Proveedorwwds_5_tfproveedornombre = AV13TFProveedorNombre;
         AV73Proveedorwwds_6_tfproveedornombre_sel = AV14TFProveedorNombre_Sel;
         AV74Proveedorwwds_7_tfproveedordocidentidad = AV15TFProveedorDocIdentidad;
         AV75Proveedorwwds_8_tfproveedordocidentidad_sel = AV16TFProveedorDocIdentidad_Sel;
         AV76Proveedorwwds_9_tfproveedortelefono = AV17TFProveedorTelefono;
         AV77Proveedorwwds_10_tfproveedortelefono_sel = AV18TFProveedorTelefono_Sel;
         AV78Proveedorwwds_11_tfproveedordireccion = AV19TFProveedorDireccion;
         AV79Proveedorwwds_12_tfproveedordireccion_sel = AV20TFProveedorDireccion_Sel;
         AV80Proveedorwwds_13_tfproveedoremail = AV21TFProveedorEmail;
         AV81Proveedorwwds_14_tfproveedoremail_sel = AV22TFProveedorEmail_Sel;
         AV82Proveedorwwds_15_tfproveedorpagodefault_sels = AV64TFProveedorPagoDefault_Sels;
         AV83Proveedorwwds_16_tfproveedorestado_sels = AV24TFProveedorEstado_Sels;
         pr_default.dynParam(3, new Object[]{ new Object[]{
                                              A440ProveedorPagoDefault ,
                                              AV82Proveedorwwds_15_tfproveedorpagodefault_sels ,
                                              A344ProveedorEstado ,
                                              AV83Proveedorwwds_16_tfproveedorestado_sels ,
                                              AV68Proveedorwwds_1_gridconditionalformattingfilter ,
                                              AV70Proveedorwwds_3_tfproveedorid ,
                                              AV71Proveedorwwds_4_tfproveedorid_to ,
                                              AV73Proveedorwwds_6_tfproveedornombre_sel ,
                                              AV72Proveedorwwds_5_tfproveedornombre ,
                                              AV75Proveedorwwds_8_tfproveedordocidentidad_sel ,
                                              AV74Proveedorwwds_7_tfproveedordocidentidad ,
                                              AV77Proveedorwwds_10_tfproveedortelefono_sel ,
                                              AV76Proveedorwwds_9_tfproveedortelefono ,
                                              AV79Proveedorwwds_12_tfproveedordireccion_sel ,
                                              AV78Proveedorwwds_11_tfproveedordireccion ,
                                              AV81Proveedorwwds_14_tfproveedoremail_sel ,
                                              AV80Proveedorwwds_13_tfproveedoremail ,
                                              AV82Proveedorwwds_15_tfproveedorpagodefault_sels.Count ,
                                              AV83Proveedorwwds_16_tfproveedorestado_sels.Count ,
                                              AV65VerTodProv ,
                                              AV84Hacerload ,
                                              A133ProveedorID ,
                                              A282ProveedorNombre ,
                                              A338ProveedorDocIdentidad ,
                                              A430ProveedorTelefono ,
                                              A431ProveedorDireccion ,
                                              A433ProveedorEmail ,
                                              AV69Proveedorwwds_2_filterfulltext } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN,
                                              TypeConstants.BOOLEAN
                                              }
         });
         lV72Proveedorwwds_5_tfproveedornombre = StringUtil.PadR( StringUtil.RTrim( AV72Proveedorwwds_5_tfproveedornombre), 80, "%");
         lV74Proveedorwwds_7_tfproveedordocidentidad = StringUtil.PadR( StringUtil.RTrim( AV74Proveedorwwds_7_tfproveedordocidentidad), 25, "%");
         lV76Proveedorwwds_9_tfproveedortelefono = StringUtil.PadR( StringUtil.RTrim( AV76Proveedorwwds_9_tfproveedortelefono), 20, "%");
         lV78Proveedorwwds_11_tfproveedordireccion = StringUtil.Concat( StringUtil.RTrim( AV78Proveedorwwds_11_tfproveedordireccion), "%", "");
         lV80Proveedorwwds_13_tfproveedoremail = StringUtil.Concat( StringUtil.RTrim( AV80Proveedorwwds_13_tfproveedoremail), "%", "");
         /* Using cursor P006V5 */
         pr_default.execute(3, new Object[] {AV84Hacerload, AV70Proveedorwwds_3_tfproveedorid, AV71Proveedorwwds_4_tfproveedorid_to, lV72Proveedorwwds_5_tfproveedornombre, AV73Proveedorwwds_6_tfproveedornombre_sel, lV74Proveedorwwds_7_tfproveedordocidentidad, AV75Proveedorwwds_8_tfproveedordocidentidad_sel, lV76Proveedorwwds_9_tfproveedortelefono, AV77Proveedorwwds_10_tfproveedortelefono_sel, lV78Proveedorwwds_11_tfproveedordireccion, AV79Proveedorwwds_12_tfproveedordireccion_sel, lV80Proveedorwwds_13_tfproveedoremail, AV81Proveedorwwds_14_tfproveedoremail_sel});
         while ( (pr_default.getStatus(3) != 101) )
         {
            BRK6V8 = false;
            A431ProveedorDireccion = P006V5_A431ProveedorDireccion[0];
            n431ProveedorDireccion = P006V5_n431ProveedorDireccion[0];
            A433ProveedorEmail = P006V5_A433ProveedorEmail[0];
            n433ProveedorEmail = P006V5_n433ProveedorEmail[0];
            A430ProveedorTelefono = P006V5_A430ProveedorTelefono[0];
            n430ProveedorTelefono = P006V5_n430ProveedorTelefono[0];
            A338ProveedorDocIdentidad = P006V5_A338ProveedorDocIdentidad[0];
            A282ProveedorNombre = P006V5_A282ProveedorNombre[0];
            A133ProveedorID = P006V5_A133ProveedorID[0];
            A344ProveedorEstado = P006V5_A344ProveedorEstado[0];
            A440ProveedorPagoDefault = P006V5_A440ProveedorPagoDefault[0];
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV69Proveedorwwds_2_filterfulltext)) || ( ( StringUtil.Like( StringUtil.Str( (decimal)(A133ProveedorID), 18, 0) , StringUtil.PadR( "%" + AV69Proveedorwwds_2_filterfulltext , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A282ProveedorNombre) , StringUtil.PadR( "%" + StringUtil.Upper( AV69Proveedorwwds_2_filterfulltext) , 255 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Upper( A338ProveedorDocIdentidad) , StringUtil.PadR( "%" + StringUtil.Upper( AV69Proveedorwwds_2_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A430ProveedorTelefono) , StringUtil.PadR( "%" + StringUtil.Upper( AV69Proveedorwwds_2_filterfulltext) , 255 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Upper( A431ProveedorDireccion) , StringUtil.PadR( "%" + StringUtil.Upper( AV69Proveedorwwds_2_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A433ProveedorEmail) , StringUtil.PadR( "%" + StringUtil.Upper( AV69Proveedorwwds_2_filterfulltext) , 255 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( context.GetMessage( "cobro directo", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV69Proveedorwwds_2_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A440ProveedorPagoDefault, "F") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "cobro prepago comercio", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV69Proveedorwwds_2_filterfulltext) , 255 , "%"),  ' ' ) &&
            ( StringUtil.StrCmp(A440ProveedorPagoDefault, "T") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "cobro prepago almango", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV69Proveedorwwds_2_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A440ProveedorPagoDefault, "O") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "habilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV69Proveedorwwds_2_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A344ProveedorEstado, "HAB") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "deshabilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV69Proveedorwwds_2_filterfulltext) , 255 , "%"),  ' ' ) &&
            ( StringUtil.StrCmp(A344ProveedorEstado, "DES") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "pendiente", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV69Proveedorwwds_2_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A344ProveedorEstado, "PEN") == 0 ) ) )
            )
            {
               AV35count = 0;
               while ( (pr_default.getStatus(3) != 101) && ( StringUtil.StrCmp(P006V5_A431ProveedorDireccion[0], A431ProveedorDireccion) == 0 ) )
               {
                  BRK6V8 = false;
                  A133ProveedorID = P006V5_A133ProveedorID[0];
                  AV35count = (long)(AV35count+1);
                  BRK6V8 = true;
                  pr_default.readNext(3);
               }
               if ( (0==AV26SkipItems) )
               {
                  AV30Option = (String.IsNullOrEmpty(StringUtil.RTrim( A431ProveedorDireccion)) ? "<#Empty#>" : A431ProveedorDireccion);
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
            }
            if ( ! BRK6V8 )
            {
               BRK6V8 = true;
               pr_default.readNext(3);
            }
         }
         pr_default.close(3);
      }

      protected void S161( )
      {
         /* 'LOADPROVEEDOREMAILOPTIONS' Routine */
         returnInSub = false;
         AV21TFProveedorEmail = AV25SearchTxt;
         AV22TFProveedorEmail_Sel = "";
         AV68Proveedorwwds_1_gridconditionalformattingfilter = AV48GridConditionalFormattingFilter;
         AV69Proveedorwwds_2_filterfulltext = AV47FilterFullText;
         AV70Proveedorwwds_3_tfproveedorid = AV11TFProveedorID;
         AV71Proveedorwwds_4_tfproveedorid_to = AV12TFProveedorID_To;
         AV72Proveedorwwds_5_tfproveedornombre = AV13TFProveedorNombre;
         AV73Proveedorwwds_6_tfproveedornombre_sel = AV14TFProveedorNombre_Sel;
         AV74Proveedorwwds_7_tfproveedordocidentidad = AV15TFProveedorDocIdentidad;
         AV75Proveedorwwds_8_tfproveedordocidentidad_sel = AV16TFProveedorDocIdentidad_Sel;
         AV76Proveedorwwds_9_tfproveedortelefono = AV17TFProveedorTelefono;
         AV77Proveedorwwds_10_tfproveedortelefono_sel = AV18TFProveedorTelefono_Sel;
         AV78Proveedorwwds_11_tfproveedordireccion = AV19TFProveedorDireccion;
         AV79Proveedorwwds_12_tfproveedordireccion_sel = AV20TFProveedorDireccion_Sel;
         AV80Proveedorwwds_13_tfproveedoremail = AV21TFProveedorEmail;
         AV81Proveedorwwds_14_tfproveedoremail_sel = AV22TFProveedorEmail_Sel;
         AV82Proveedorwwds_15_tfproveedorpagodefault_sels = AV64TFProveedorPagoDefault_Sels;
         AV83Proveedorwwds_16_tfproveedorestado_sels = AV24TFProveedorEstado_Sels;
         pr_default.dynParam(4, new Object[]{ new Object[]{
                                              A440ProveedorPagoDefault ,
                                              AV82Proveedorwwds_15_tfproveedorpagodefault_sels ,
                                              A344ProveedorEstado ,
                                              AV83Proveedorwwds_16_tfproveedorestado_sels ,
                                              AV68Proveedorwwds_1_gridconditionalformattingfilter ,
                                              AV70Proveedorwwds_3_tfproveedorid ,
                                              AV71Proveedorwwds_4_tfproveedorid_to ,
                                              AV73Proveedorwwds_6_tfproveedornombre_sel ,
                                              AV72Proveedorwwds_5_tfproveedornombre ,
                                              AV75Proveedorwwds_8_tfproveedordocidentidad_sel ,
                                              AV74Proveedorwwds_7_tfproveedordocidentidad ,
                                              AV77Proveedorwwds_10_tfproveedortelefono_sel ,
                                              AV76Proveedorwwds_9_tfproveedortelefono ,
                                              AV79Proveedorwwds_12_tfproveedordireccion_sel ,
                                              AV78Proveedorwwds_11_tfproveedordireccion ,
                                              AV81Proveedorwwds_14_tfproveedoremail_sel ,
                                              AV80Proveedorwwds_13_tfproveedoremail ,
                                              AV82Proveedorwwds_15_tfproveedorpagodefault_sels.Count ,
                                              AV83Proveedorwwds_16_tfproveedorestado_sels.Count ,
                                              AV65VerTodProv ,
                                              AV84Hacerload ,
                                              A133ProveedorID ,
                                              A282ProveedorNombre ,
                                              A338ProveedorDocIdentidad ,
                                              A430ProveedorTelefono ,
                                              A431ProveedorDireccion ,
                                              A433ProveedorEmail ,
                                              AV69Proveedorwwds_2_filterfulltext } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN,
                                              TypeConstants.BOOLEAN
                                              }
         });
         lV72Proveedorwwds_5_tfproveedornombre = StringUtil.PadR( StringUtil.RTrim( AV72Proveedorwwds_5_tfproveedornombre), 80, "%");
         lV74Proveedorwwds_7_tfproveedordocidentidad = StringUtil.PadR( StringUtil.RTrim( AV74Proveedorwwds_7_tfproveedordocidentidad), 25, "%");
         lV76Proveedorwwds_9_tfproveedortelefono = StringUtil.PadR( StringUtil.RTrim( AV76Proveedorwwds_9_tfproveedortelefono), 20, "%");
         lV78Proveedorwwds_11_tfproveedordireccion = StringUtil.Concat( StringUtil.RTrim( AV78Proveedorwwds_11_tfproveedordireccion), "%", "");
         lV80Proveedorwwds_13_tfproveedoremail = StringUtil.Concat( StringUtil.RTrim( AV80Proveedorwwds_13_tfproveedoremail), "%", "");
         /* Using cursor P006V6 */
         pr_default.execute(4, new Object[] {AV84Hacerload, AV70Proveedorwwds_3_tfproveedorid, AV71Proveedorwwds_4_tfproveedorid_to, lV72Proveedorwwds_5_tfproveedornombre, AV73Proveedorwwds_6_tfproveedornombre_sel, lV74Proveedorwwds_7_tfproveedordocidentidad, AV75Proveedorwwds_8_tfproveedordocidentidad_sel, lV76Proveedorwwds_9_tfproveedortelefono, AV77Proveedorwwds_10_tfproveedortelefono_sel, lV78Proveedorwwds_11_tfproveedordireccion, AV79Proveedorwwds_12_tfproveedordireccion_sel, lV80Proveedorwwds_13_tfproveedoremail, AV81Proveedorwwds_14_tfproveedoremail_sel});
         while ( (pr_default.getStatus(4) != 101) )
         {
            BRK6V10 = false;
            A433ProveedorEmail = P006V6_A433ProveedorEmail[0];
            n433ProveedorEmail = P006V6_n433ProveedorEmail[0];
            A431ProveedorDireccion = P006V6_A431ProveedorDireccion[0];
            n431ProveedorDireccion = P006V6_n431ProveedorDireccion[0];
            A430ProveedorTelefono = P006V6_A430ProveedorTelefono[0];
            n430ProveedorTelefono = P006V6_n430ProveedorTelefono[0];
            A338ProveedorDocIdentidad = P006V6_A338ProveedorDocIdentidad[0];
            A282ProveedorNombre = P006V6_A282ProveedorNombre[0];
            A133ProveedorID = P006V6_A133ProveedorID[0];
            A344ProveedorEstado = P006V6_A344ProveedorEstado[0];
            A440ProveedorPagoDefault = P006V6_A440ProveedorPagoDefault[0];
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV69Proveedorwwds_2_filterfulltext)) || ( ( StringUtil.Like( StringUtil.Str( (decimal)(A133ProveedorID), 18, 0) , StringUtil.PadR( "%" + AV69Proveedorwwds_2_filterfulltext , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A282ProveedorNombre) , StringUtil.PadR( "%" + StringUtil.Upper( AV69Proveedorwwds_2_filterfulltext) , 255 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Upper( A338ProveedorDocIdentidad) , StringUtil.PadR( "%" + StringUtil.Upper( AV69Proveedorwwds_2_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A430ProveedorTelefono) , StringUtil.PadR( "%" + StringUtil.Upper( AV69Proveedorwwds_2_filterfulltext) , 255 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Upper( A431ProveedorDireccion) , StringUtil.PadR( "%" + StringUtil.Upper( AV69Proveedorwwds_2_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A433ProveedorEmail) , StringUtil.PadR( "%" + StringUtil.Upper( AV69Proveedorwwds_2_filterfulltext) , 255 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( context.GetMessage( "cobro directo", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV69Proveedorwwds_2_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A440ProveedorPagoDefault, "F") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "cobro prepago comercio", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV69Proveedorwwds_2_filterfulltext) , 255 , "%"),  ' ' ) &&
            ( StringUtil.StrCmp(A440ProveedorPagoDefault, "T") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "cobro prepago almango", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV69Proveedorwwds_2_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A440ProveedorPagoDefault, "O") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "habilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV69Proveedorwwds_2_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A344ProveedorEstado, "HAB") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "deshabilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV69Proveedorwwds_2_filterfulltext) , 255 , "%"),  ' ' ) &&
            ( StringUtil.StrCmp(A344ProveedorEstado, "DES") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "pendiente", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV69Proveedorwwds_2_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A344ProveedorEstado, "PEN") == 0 ) ) )
            )
            {
               AV35count = 0;
               while ( (pr_default.getStatus(4) != 101) && ( StringUtil.StrCmp(P006V6_A433ProveedorEmail[0], A433ProveedorEmail) == 0 ) )
               {
                  BRK6V10 = false;
                  A133ProveedorID = P006V6_A133ProveedorID[0];
                  AV35count = (long)(AV35count+1);
                  BRK6V10 = true;
                  pr_default.readNext(4);
               }
               if ( (0==AV26SkipItems) )
               {
                  AV30Option = (String.IsNullOrEmpty(StringUtil.RTrim( A433ProveedorEmail)) ? "<#Empty#>" : A433ProveedorEmail);
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
            }
            if ( ! BRK6V10 )
            {
               BRK6V10 = true;
               pr_default.readNext(4);
            }
         }
         pr_default.close(4);
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
         AV13TFProveedorNombre = "";
         AV14TFProveedorNombre_Sel = "";
         AV15TFProveedorDocIdentidad = "";
         AV16TFProveedorDocIdentidad_Sel = "";
         AV17TFProveedorTelefono = "";
         AV18TFProveedorTelefono_Sel = "";
         AV19TFProveedorDireccion = "";
         AV20TFProveedorDireccion_Sel = "";
         AV21TFProveedorEmail = "";
         AV22TFProveedorEmail_Sel = "";
         AV63TFProveedorPagoDefault_SelsJson = "";
         AV64TFProveedorPagoDefault_Sels = new GxSimpleCollection<string>();
         AV23TFProveedorEstado_SelsJson = "";
         AV24TFProveedorEstado_Sels = new GxSimpleCollection<string>();
         AV69Proveedorwwds_2_filterfulltext = "";
         AV72Proveedorwwds_5_tfproveedornombre = "";
         AV73Proveedorwwds_6_tfproveedornombre_sel = "";
         AV74Proveedorwwds_7_tfproveedordocidentidad = "";
         AV75Proveedorwwds_8_tfproveedordocidentidad_sel = "";
         AV76Proveedorwwds_9_tfproveedortelefono = "";
         AV77Proveedorwwds_10_tfproveedortelefono_sel = "";
         AV78Proveedorwwds_11_tfproveedordireccion = "";
         AV79Proveedorwwds_12_tfproveedordireccion_sel = "";
         AV80Proveedorwwds_13_tfproveedoremail = "";
         AV81Proveedorwwds_14_tfproveedoremail_sel = "";
         AV82Proveedorwwds_15_tfproveedorpagodefault_sels = new GxSimpleCollection<string>();
         AV83Proveedorwwds_16_tfproveedorestado_sels = new GxSimpleCollection<string>();
         lV72Proveedorwwds_5_tfproveedornombre = "";
         lV74Proveedorwwds_7_tfproveedordocidentidad = "";
         lV76Proveedorwwds_9_tfproveedortelefono = "";
         lV78Proveedorwwds_11_tfproveedordireccion = "";
         lV80Proveedorwwds_13_tfproveedoremail = "";
         A440ProveedorPagoDefault = "";
         A344ProveedorEstado = "";
         A282ProveedorNombre = "";
         A338ProveedorDocIdentidad = "";
         A430ProveedorTelefono = "";
         A431ProveedorDireccion = "";
         A433ProveedorEmail = "";
         P006V2_A282ProveedorNombre = new string[] {""} ;
         P006V2_A433ProveedorEmail = new string[] {""} ;
         P006V2_n433ProveedorEmail = new bool[] {false} ;
         P006V2_A431ProveedorDireccion = new string[] {""} ;
         P006V2_n431ProveedorDireccion = new bool[] {false} ;
         P006V2_A430ProveedorTelefono = new string[] {""} ;
         P006V2_n430ProveedorTelefono = new bool[] {false} ;
         P006V2_A338ProveedorDocIdentidad = new string[] {""} ;
         P006V2_A133ProveedorID = new long[1] ;
         P006V2_A344ProveedorEstado = new string[] {""} ;
         P006V2_A440ProveedorPagoDefault = new string[] {""} ;
         AV30Option = "";
         P006V3_A338ProveedorDocIdentidad = new string[] {""} ;
         P006V3_A433ProveedorEmail = new string[] {""} ;
         P006V3_n433ProveedorEmail = new bool[] {false} ;
         P006V3_A431ProveedorDireccion = new string[] {""} ;
         P006V3_n431ProveedorDireccion = new bool[] {false} ;
         P006V3_A430ProveedorTelefono = new string[] {""} ;
         P006V3_n430ProveedorTelefono = new bool[] {false} ;
         P006V3_A282ProveedorNombre = new string[] {""} ;
         P006V3_A133ProveedorID = new long[1] ;
         P006V3_A344ProveedorEstado = new string[] {""} ;
         P006V3_A440ProveedorPagoDefault = new string[] {""} ;
         P006V4_A430ProveedorTelefono = new string[] {""} ;
         P006V4_n430ProveedorTelefono = new bool[] {false} ;
         P006V4_A433ProveedorEmail = new string[] {""} ;
         P006V4_n433ProveedorEmail = new bool[] {false} ;
         P006V4_A431ProveedorDireccion = new string[] {""} ;
         P006V4_n431ProveedorDireccion = new bool[] {false} ;
         P006V4_A338ProveedorDocIdentidad = new string[] {""} ;
         P006V4_A282ProveedorNombre = new string[] {""} ;
         P006V4_A133ProveedorID = new long[1] ;
         P006V4_A344ProveedorEstado = new string[] {""} ;
         P006V4_A440ProveedorPagoDefault = new string[] {""} ;
         P006V5_A431ProveedorDireccion = new string[] {""} ;
         P006V5_n431ProveedorDireccion = new bool[] {false} ;
         P006V5_A433ProveedorEmail = new string[] {""} ;
         P006V5_n433ProveedorEmail = new bool[] {false} ;
         P006V5_A430ProveedorTelefono = new string[] {""} ;
         P006V5_n430ProveedorTelefono = new bool[] {false} ;
         P006V5_A338ProveedorDocIdentidad = new string[] {""} ;
         P006V5_A282ProveedorNombre = new string[] {""} ;
         P006V5_A133ProveedorID = new long[1] ;
         P006V5_A344ProveedorEstado = new string[] {""} ;
         P006V5_A440ProveedorPagoDefault = new string[] {""} ;
         P006V6_A433ProveedorEmail = new string[] {""} ;
         P006V6_n433ProveedorEmail = new bool[] {false} ;
         P006V6_A431ProveedorDireccion = new string[] {""} ;
         P006V6_n431ProveedorDireccion = new bool[] {false} ;
         P006V6_A430ProveedorTelefono = new string[] {""} ;
         P006V6_n430ProveedorTelefono = new bool[] {false} ;
         P006V6_A338ProveedorDocIdentidad = new string[] {""} ;
         P006V6_A282ProveedorNombre = new string[] {""} ;
         P006V6_A133ProveedorID = new long[1] ;
         P006V6_A344ProveedorEstado = new string[] {""} ;
         P006V6_A440ProveedorPagoDefault = new string[] {""} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.proveedorwwgetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P006V2_A282ProveedorNombre, P006V2_A433ProveedorEmail, P006V2_n433ProveedorEmail, P006V2_A431ProveedorDireccion, P006V2_n431ProveedorDireccion, P006V2_A430ProveedorTelefono, P006V2_n430ProveedorTelefono, P006V2_A338ProveedorDocIdentidad, P006V2_A133ProveedorID, P006V2_A344ProveedorEstado,
               P006V2_A440ProveedorPagoDefault
               }
               , new Object[] {
               P006V3_A338ProveedorDocIdentidad, P006V3_A433ProveedorEmail, P006V3_n433ProveedorEmail, P006V3_A431ProveedorDireccion, P006V3_n431ProveedorDireccion, P006V3_A430ProveedorTelefono, P006V3_n430ProveedorTelefono, P006V3_A282ProveedorNombre, P006V3_A133ProveedorID, P006V3_A344ProveedorEstado,
               P006V3_A440ProveedorPagoDefault
               }
               , new Object[] {
               P006V4_A430ProveedorTelefono, P006V4_n430ProveedorTelefono, P006V4_A433ProveedorEmail, P006V4_n433ProveedorEmail, P006V4_A431ProveedorDireccion, P006V4_n431ProveedorDireccion, P006V4_A338ProveedorDocIdentidad, P006V4_A282ProveedorNombre, P006V4_A133ProveedorID, P006V4_A344ProveedorEstado,
               P006V4_A440ProveedorPagoDefault
               }
               , new Object[] {
               P006V5_A431ProveedorDireccion, P006V5_n431ProveedorDireccion, P006V5_A433ProveedorEmail, P006V5_n433ProveedorEmail, P006V5_A430ProveedorTelefono, P006V5_n430ProveedorTelefono, P006V5_A338ProveedorDocIdentidad, P006V5_A282ProveedorNombre, P006V5_A133ProveedorID, P006V5_A344ProveedorEstado,
               P006V5_A440ProveedorPagoDefault
               }
               , new Object[] {
               P006V6_A433ProveedorEmail, P006V6_n433ProveedorEmail, P006V6_A431ProveedorDireccion, P006V6_n431ProveedorDireccion, P006V6_A430ProveedorTelefono, P006V6_n430ProveedorTelefono, P006V6_A338ProveedorDocIdentidad, P006V6_A282ProveedorNombre, P006V6_A133ProveedorID, P006V6_A344ProveedorEstado,
               P006V6_A440ProveedorPagoDefault
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV28MaxItems ;
      private short AV27PageIndex ;
      private short AV26SkipItems ;
      private short AV48GridConditionalFormattingFilter ;
      private short AV68Proveedorwwds_1_gridconditionalformattingfilter ;
      private int AV66GXV1 ;
      private int AV82Proveedorwwds_15_tfproveedorpagodefault_sels_Count ;
      private int AV83Proveedorwwds_16_tfproveedorestado_sels_Count ;
      private long AV11TFProveedorID ;
      private long AV12TFProveedorID_To ;
      private long AV70Proveedorwwds_3_tfproveedorid ;
      private long AV71Proveedorwwds_4_tfproveedorid_to ;
      private long A133ProveedorID ;
      private long AV35count ;
      private decimal AV84Hacerload ;
      private string AV13TFProveedorNombre ;
      private string AV14TFProveedorNombre_Sel ;
      private string AV15TFProveedorDocIdentidad ;
      private string AV16TFProveedorDocIdentidad_Sel ;
      private string AV17TFProveedorTelefono ;
      private string AV18TFProveedorTelefono_Sel ;
      private string AV72Proveedorwwds_5_tfproveedornombre ;
      private string AV73Proveedorwwds_6_tfproveedornombre_sel ;
      private string AV74Proveedorwwds_7_tfproveedordocidentidad ;
      private string AV75Proveedorwwds_8_tfproveedordocidentidad_sel ;
      private string AV76Proveedorwwds_9_tfproveedortelefono ;
      private string AV77Proveedorwwds_10_tfproveedortelefono_sel ;
      private string lV72Proveedorwwds_5_tfproveedornombre ;
      private string lV74Proveedorwwds_7_tfproveedordocidentidad ;
      private string lV76Proveedorwwds_9_tfproveedortelefono ;
      private string A440ProveedorPagoDefault ;
      private string A344ProveedorEstado ;
      private string A282ProveedorNombre ;
      private string A338ProveedorDocIdentidad ;
      private string A430ProveedorTelefono ;
      private bool AV8IsAuthorized ;
      private bool GXt_boolean1 ;
      private bool returnInSub ;
      private bool AV65VerTodProv ;
      private bool BRK6V2 ;
      private bool n433ProveedorEmail ;
      private bool n431ProveedorDireccion ;
      private bool n430ProveedorTelefono ;
      private bool BRK6V4 ;
      private bool BRK6V6 ;
      private bool BRK6V8 ;
      private bool BRK6V10 ;
      private string AV44OptionsJson ;
      private string AV45OptionsDescJson ;
      private string AV46OptionIndexesJson ;
      private string AV63TFProveedorPagoDefault_SelsJson ;
      private string AV23TFProveedorEstado_SelsJson ;
      private string AV41DDOName ;
      private string AV42SearchTxtParms ;
      private string AV43SearchTxtTo ;
      private string AV25SearchTxt ;
      private string AV47FilterFullText ;
      private string AV19TFProveedorDireccion ;
      private string AV20TFProveedorDireccion_Sel ;
      private string AV21TFProveedorEmail ;
      private string AV22TFProveedorEmail_Sel ;
      private string AV69Proveedorwwds_2_filterfulltext ;
      private string AV78Proveedorwwds_11_tfproveedordireccion ;
      private string AV79Proveedorwwds_12_tfproveedordireccion_sel ;
      private string AV80Proveedorwwds_13_tfproveedoremail ;
      private string AV81Proveedorwwds_14_tfproveedoremail_sel ;
      private string lV78Proveedorwwds_11_tfproveedordireccion ;
      private string lV80Proveedorwwds_13_tfproveedoremail ;
      private string A431ProveedorDireccion ;
      private string A433ProveedorEmail ;
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
      private GxSimpleCollection<string> AV64TFProveedorPagoDefault_Sels ;
      private GxSimpleCollection<string> AV24TFProveedorEstado_Sels ;
      private GxSimpleCollection<string> AV82Proveedorwwds_15_tfproveedorpagodefault_sels ;
      private GxSimpleCollection<string> AV83Proveedorwwds_16_tfproveedorestado_sels ;
      private IDataStoreProvider pr_default ;
      private string[] P006V2_A282ProveedorNombre ;
      private string[] P006V2_A433ProveedorEmail ;
      private bool[] P006V2_n433ProveedorEmail ;
      private string[] P006V2_A431ProveedorDireccion ;
      private bool[] P006V2_n431ProveedorDireccion ;
      private string[] P006V2_A430ProveedorTelefono ;
      private bool[] P006V2_n430ProveedorTelefono ;
      private string[] P006V2_A338ProveedorDocIdentidad ;
      private long[] P006V2_A133ProveedorID ;
      private string[] P006V2_A344ProveedorEstado ;
      private string[] P006V2_A440ProveedorPagoDefault ;
      private string[] P006V3_A338ProveedorDocIdentidad ;
      private string[] P006V3_A433ProveedorEmail ;
      private bool[] P006V3_n433ProveedorEmail ;
      private string[] P006V3_A431ProveedorDireccion ;
      private bool[] P006V3_n431ProveedorDireccion ;
      private string[] P006V3_A430ProveedorTelefono ;
      private bool[] P006V3_n430ProveedorTelefono ;
      private string[] P006V3_A282ProveedorNombre ;
      private long[] P006V3_A133ProveedorID ;
      private string[] P006V3_A344ProveedorEstado ;
      private string[] P006V3_A440ProveedorPagoDefault ;
      private string[] P006V4_A430ProveedorTelefono ;
      private bool[] P006V4_n430ProveedorTelefono ;
      private string[] P006V4_A433ProveedorEmail ;
      private bool[] P006V4_n433ProveedorEmail ;
      private string[] P006V4_A431ProveedorDireccion ;
      private bool[] P006V4_n431ProveedorDireccion ;
      private string[] P006V4_A338ProveedorDocIdentidad ;
      private string[] P006V4_A282ProveedorNombre ;
      private long[] P006V4_A133ProveedorID ;
      private string[] P006V4_A344ProveedorEstado ;
      private string[] P006V4_A440ProveedorPagoDefault ;
      private string[] P006V5_A431ProveedorDireccion ;
      private bool[] P006V5_n431ProveedorDireccion ;
      private string[] P006V5_A433ProveedorEmail ;
      private bool[] P006V5_n433ProveedorEmail ;
      private string[] P006V5_A430ProveedorTelefono ;
      private bool[] P006V5_n430ProveedorTelefono ;
      private string[] P006V5_A338ProveedorDocIdentidad ;
      private string[] P006V5_A282ProveedorNombre ;
      private long[] P006V5_A133ProveedorID ;
      private string[] P006V5_A344ProveedorEstado ;
      private string[] P006V5_A440ProveedorPagoDefault ;
      private string[] P006V6_A433ProveedorEmail ;
      private bool[] P006V6_n433ProveedorEmail ;
      private string[] P006V6_A431ProveedorDireccion ;
      private bool[] P006V6_n431ProveedorDireccion ;
      private string[] P006V6_A430ProveedorTelefono ;
      private bool[] P006V6_n430ProveedorTelefono ;
      private string[] P006V6_A338ProveedorDocIdentidad ;
      private string[] P006V6_A282ProveedorNombre ;
      private long[] P006V6_A133ProveedorID ;
      private string[] P006V6_A344ProveedorEstado ;
      private string[] P006V6_A440ProveedorPagoDefault ;
      private string aP3_OptionsJson ;
      private string aP4_OptionsDescJson ;
      private string aP5_OptionIndexesJson ;
   }

   public class proveedorwwgetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P006V2( IGxContext context ,
                                             string A440ProveedorPagoDefault ,
                                             GxSimpleCollection<string> AV82Proveedorwwds_15_tfproveedorpagodefault_sels ,
                                             string A344ProveedorEstado ,
                                             GxSimpleCollection<string> AV83Proveedorwwds_16_tfproveedorestado_sels ,
                                             short AV68Proveedorwwds_1_gridconditionalformattingfilter ,
                                             long AV70Proveedorwwds_3_tfproveedorid ,
                                             long AV71Proveedorwwds_4_tfproveedorid_to ,
                                             string AV73Proveedorwwds_6_tfproveedornombre_sel ,
                                             string AV72Proveedorwwds_5_tfproveedornombre ,
                                             string AV75Proveedorwwds_8_tfproveedordocidentidad_sel ,
                                             string AV74Proveedorwwds_7_tfproveedordocidentidad ,
                                             string AV77Proveedorwwds_10_tfproveedortelefono_sel ,
                                             string AV76Proveedorwwds_9_tfproveedortelefono ,
                                             string AV79Proveedorwwds_12_tfproveedordireccion_sel ,
                                             string AV78Proveedorwwds_11_tfproveedordireccion ,
                                             string AV81Proveedorwwds_14_tfproveedoremail_sel ,
                                             string AV80Proveedorwwds_13_tfproveedoremail ,
                                             int AV82Proveedorwwds_15_tfproveedorpagodefault_sels_Count ,
                                             int AV83Proveedorwwds_16_tfproveedorestado_sels_Count ,
                                             bool AV65VerTodProv ,
                                             decimal AV84Hacerload ,
                                             long A133ProveedorID ,
                                             string A282ProveedorNombre ,
                                             string A338ProveedorDocIdentidad ,
                                             string A430ProveedorTelefono ,
                                             string A431ProveedorDireccion ,
                                             string A433ProveedorEmail ,
                                             string AV69Proveedorwwds_2_filterfulltext )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int2 = new short[13];
         Object[] GXv_Object3 = new Object[2];
         scmdbuf = "SELECT [ProveedorNombre], [ProveedorEmail], [ProveedorDireccion], [ProveedorTelefono], [ProveedorDocIdentidad], [ProveedorID], [ProveedorEstado], [ProveedorPagoDefault] FROM [Proveedor]";
         if ( AV68Proveedorwwds_1_gridconditionalformattingfilter == 1 )
         {
            AddWhere(sWhereString, "(@AV84Hacerload = 1)");
         }
         else
         {
            GXv_int2[0] = 1;
         }
         if ( ! (0==AV70Proveedorwwds_3_tfproveedorid) )
         {
            AddWhere(sWhereString, "([ProveedorID] >= @AV70Proveedorwwds_3_tfproveedorid)");
         }
         else
         {
            GXv_int2[1] = 1;
         }
         if ( ! (0==AV71Proveedorwwds_4_tfproveedorid_to) )
         {
            AddWhere(sWhereString, "([ProveedorID] <= @AV71Proveedorwwds_4_tfproveedorid_to)");
         }
         else
         {
            GXv_int2[2] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV73Proveedorwwds_6_tfproveedornombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Proveedorwwds_5_tfproveedornombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ProveedorNombre]) like UPPER(@lV72Proveedorwwds_5_tfproveedornombre))");
         }
         else
         {
            GXv_int2[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Proveedorwwds_6_tfproveedornombre_sel)) && ! ( StringUtil.StrCmp(AV73Proveedorwwds_6_tfproveedornombre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([ProveedorNombre] = @AV73Proveedorwwds_6_tfproveedornombre_sel)");
         }
         else
         {
            GXv_int2[4] = 1;
         }
         if ( StringUtil.StrCmp(AV73Proveedorwwds_6_tfproveedornombre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([ProveedorNombre] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV75Proveedorwwds_8_tfproveedordocidentidad_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Proveedorwwds_7_tfproveedordocidentidad)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ProveedorDocIdentidad]) like UPPER(@lV74Proveedorwwds_7_tfproveedordocidentidad))");
         }
         else
         {
            GXv_int2[5] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75Proveedorwwds_8_tfproveedordocidentidad_sel)) && ! ( StringUtil.StrCmp(AV75Proveedorwwds_8_tfproveedordocidentidad_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([ProveedorDocIdentidad] = @AV75Proveedorwwds_8_tfproveedordocidentidad_sel)");
         }
         else
         {
            GXv_int2[6] = 1;
         }
         if ( StringUtil.StrCmp(AV75Proveedorwwds_8_tfproveedordocidentidad_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([ProveedorDocIdentidad] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV77Proveedorwwds_10_tfproveedortelefono_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV76Proveedorwwds_9_tfproveedortelefono)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ProveedorTelefono]) like UPPER(@lV76Proveedorwwds_9_tfproveedortelefono))");
         }
         else
         {
            GXv_int2[7] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV77Proveedorwwds_10_tfproveedortelefono_sel)) && ! ( StringUtil.StrCmp(AV77Proveedorwwds_10_tfproveedortelefono_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([ProveedorTelefono] = @AV77Proveedorwwds_10_tfproveedortelefono_sel)");
         }
         else
         {
            GXv_int2[8] = 1;
         }
         if ( StringUtil.StrCmp(AV77Proveedorwwds_10_tfproveedortelefono_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "([ProveedorTelefono] IS NULL or ([ProveedorTelefono] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV79Proveedorwwds_12_tfproveedordireccion_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV78Proveedorwwds_11_tfproveedordireccion)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ProveedorDireccion]) like UPPER(@lV78Proveedorwwds_11_tfproveedordireccion))");
         }
         else
         {
            GXv_int2[9] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV79Proveedorwwds_12_tfproveedordireccion_sel)) && ! ( StringUtil.StrCmp(AV79Proveedorwwds_12_tfproveedordireccion_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([ProveedorDireccion] = @AV79Proveedorwwds_12_tfproveedordireccion_sel)");
         }
         else
         {
            GXv_int2[10] = 1;
         }
         if ( StringUtil.StrCmp(AV79Proveedorwwds_12_tfproveedordireccion_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "([ProveedorDireccion] IS NULL or ([ProveedorDireccion] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV81Proveedorwwds_14_tfproveedoremail_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV80Proveedorwwds_13_tfproveedoremail)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ProveedorEmail]) like UPPER(@lV80Proveedorwwds_13_tfproveedoremail))");
         }
         else
         {
            GXv_int2[11] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV81Proveedorwwds_14_tfproveedoremail_sel)) && ! ( StringUtil.StrCmp(AV81Proveedorwwds_14_tfproveedoremail_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([ProveedorEmail] = @AV81Proveedorwwds_14_tfproveedoremail_sel)");
         }
         else
         {
            GXv_int2[12] = 1;
         }
         if ( StringUtil.StrCmp(AV81Proveedorwwds_14_tfproveedoremail_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "([ProveedorEmail] IS NULL or ([ProveedorEmail] = ''))");
         }
         if ( AV82Proveedorwwds_15_tfproveedorpagodefault_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV82Proveedorwwds_15_tfproveedorpagodefault_sels, "[ProveedorPagoDefault] IN (", ")")+")");
         }
         if ( AV83Proveedorwwds_16_tfproveedorestado_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV83Proveedorwwds_16_tfproveedorestado_sels, "[ProveedorEstado] IN (", ")")+")");
         }
         if ( ! AV65VerTodProv )
         {
            AddWhere(sWhereString, "([ProveedorEstado] = 'HAB')");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY [ProveedorNombre]";
         GXv_Object3[0] = scmdbuf;
         GXv_Object3[1] = GXv_int2;
         return GXv_Object3 ;
      }

      protected Object[] conditional_P006V3( IGxContext context ,
                                             string A440ProveedorPagoDefault ,
                                             GxSimpleCollection<string> AV82Proveedorwwds_15_tfproveedorpagodefault_sels ,
                                             string A344ProveedorEstado ,
                                             GxSimpleCollection<string> AV83Proveedorwwds_16_tfproveedorestado_sels ,
                                             short AV68Proveedorwwds_1_gridconditionalformattingfilter ,
                                             long AV70Proveedorwwds_3_tfproveedorid ,
                                             long AV71Proveedorwwds_4_tfproveedorid_to ,
                                             string AV73Proveedorwwds_6_tfproveedornombre_sel ,
                                             string AV72Proveedorwwds_5_tfproveedornombre ,
                                             string AV75Proveedorwwds_8_tfproveedordocidentidad_sel ,
                                             string AV74Proveedorwwds_7_tfproveedordocidentidad ,
                                             string AV77Proveedorwwds_10_tfproveedortelefono_sel ,
                                             string AV76Proveedorwwds_9_tfproveedortelefono ,
                                             string AV79Proveedorwwds_12_tfproveedordireccion_sel ,
                                             string AV78Proveedorwwds_11_tfproveedordireccion ,
                                             string AV81Proveedorwwds_14_tfproveedoremail_sel ,
                                             string AV80Proveedorwwds_13_tfproveedoremail ,
                                             int AV82Proveedorwwds_15_tfproveedorpagodefault_sels_Count ,
                                             int AV83Proveedorwwds_16_tfproveedorestado_sels_Count ,
                                             bool AV65VerTodProv ,
                                             decimal AV84Hacerload ,
                                             long A133ProveedorID ,
                                             string A282ProveedorNombre ,
                                             string A338ProveedorDocIdentidad ,
                                             string A430ProveedorTelefono ,
                                             string A431ProveedorDireccion ,
                                             string A433ProveedorEmail ,
                                             string AV69Proveedorwwds_2_filterfulltext )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int4 = new short[13];
         Object[] GXv_Object5 = new Object[2];
         scmdbuf = "SELECT [ProveedorDocIdentidad], [ProveedorEmail], [ProveedorDireccion], [ProveedorTelefono], [ProveedorNombre], [ProveedorID], [ProveedorEstado], [ProveedorPagoDefault] FROM [Proveedor]";
         if ( AV68Proveedorwwds_1_gridconditionalformattingfilter == 1 )
         {
            AddWhere(sWhereString, "(@AV84Hacerload = 1)");
         }
         else
         {
            GXv_int4[0] = 1;
         }
         if ( ! (0==AV70Proveedorwwds_3_tfproveedorid) )
         {
            AddWhere(sWhereString, "([ProveedorID] >= @AV70Proveedorwwds_3_tfproveedorid)");
         }
         else
         {
            GXv_int4[1] = 1;
         }
         if ( ! (0==AV71Proveedorwwds_4_tfproveedorid_to) )
         {
            AddWhere(sWhereString, "([ProveedorID] <= @AV71Proveedorwwds_4_tfproveedorid_to)");
         }
         else
         {
            GXv_int4[2] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV73Proveedorwwds_6_tfproveedornombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Proveedorwwds_5_tfproveedornombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ProveedorNombre]) like UPPER(@lV72Proveedorwwds_5_tfproveedornombre))");
         }
         else
         {
            GXv_int4[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Proveedorwwds_6_tfproveedornombre_sel)) && ! ( StringUtil.StrCmp(AV73Proveedorwwds_6_tfproveedornombre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([ProveedorNombre] = @AV73Proveedorwwds_6_tfproveedornombre_sel)");
         }
         else
         {
            GXv_int4[4] = 1;
         }
         if ( StringUtil.StrCmp(AV73Proveedorwwds_6_tfproveedornombre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([ProveedorNombre] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV75Proveedorwwds_8_tfproveedordocidentidad_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Proveedorwwds_7_tfproveedordocidentidad)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ProveedorDocIdentidad]) like UPPER(@lV74Proveedorwwds_7_tfproveedordocidentidad))");
         }
         else
         {
            GXv_int4[5] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75Proveedorwwds_8_tfproveedordocidentidad_sel)) && ! ( StringUtil.StrCmp(AV75Proveedorwwds_8_tfproveedordocidentidad_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([ProveedorDocIdentidad] = @AV75Proveedorwwds_8_tfproveedordocidentidad_sel)");
         }
         else
         {
            GXv_int4[6] = 1;
         }
         if ( StringUtil.StrCmp(AV75Proveedorwwds_8_tfproveedordocidentidad_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([ProveedorDocIdentidad] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV77Proveedorwwds_10_tfproveedortelefono_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV76Proveedorwwds_9_tfproveedortelefono)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ProveedorTelefono]) like UPPER(@lV76Proveedorwwds_9_tfproveedortelefono))");
         }
         else
         {
            GXv_int4[7] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV77Proveedorwwds_10_tfproveedortelefono_sel)) && ! ( StringUtil.StrCmp(AV77Proveedorwwds_10_tfproveedortelefono_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([ProveedorTelefono] = @AV77Proveedorwwds_10_tfproveedortelefono_sel)");
         }
         else
         {
            GXv_int4[8] = 1;
         }
         if ( StringUtil.StrCmp(AV77Proveedorwwds_10_tfproveedortelefono_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "([ProveedorTelefono] IS NULL or ([ProveedorTelefono] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV79Proveedorwwds_12_tfproveedordireccion_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV78Proveedorwwds_11_tfproveedordireccion)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ProveedorDireccion]) like UPPER(@lV78Proveedorwwds_11_tfproveedordireccion))");
         }
         else
         {
            GXv_int4[9] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV79Proveedorwwds_12_tfproveedordireccion_sel)) && ! ( StringUtil.StrCmp(AV79Proveedorwwds_12_tfproveedordireccion_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([ProveedorDireccion] = @AV79Proveedorwwds_12_tfproveedordireccion_sel)");
         }
         else
         {
            GXv_int4[10] = 1;
         }
         if ( StringUtil.StrCmp(AV79Proveedorwwds_12_tfproveedordireccion_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "([ProveedorDireccion] IS NULL or ([ProveedorDireccion] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV81Proveedorwwds_14_tfproveedoremail_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV80Proveedorwwds_13_tfproveedoremail)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ProveedorEmail]) like UPPER(@lV80Proveedorwwds_13_tfproveedoremail))");
         }
         else
         {
            GXv_int4[11] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV81Proveedorwwds_14_tfproveedoremail_sel)) && ! ( StringUtil.StrCmp(AV81Proveedorwwds_14_tfproveedoremail_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([ProveedorEmail] = @AV81Proveedorwwds_14_tfproveedoremail_sel)");
         }
         else
         {
            GXv_int4[12] = 1;
         }
         if ( StringUtil.StrCmp(AV81Proveedorwwds_14_tfproveedoremail_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "([ProveedorEmail] IS NULL or ([ProveedorEmail] = ''))");
         }
         if ( AV82Proveedorwwds_15_tfproveedorpagodefault_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV82Proveedorwwds_15_tfproveedorpagodefault_sels, "[ProveedorPagoDefault] IN (", ")")+")");
         }
         if ( AV83Proveedorwwds_16_tfproveedorestado_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV83Proveedorwwds_16_tfproveedorestado_sels, "[ProveedorEstado] IN (", ")")+")");
         }
         if ( ! AV65VerTodProv )
         {
            AddWhere(sWhereString, "([ProveedorEstado] = 'HAB')");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY [ProveedorDocIdentidad]";
         GXv_Object5[0] = scmdbuf;
         GXv_Object5[1] = GXv_int4;
         return GXv_Object5 ;
      }

      protected Object[] conditional_P006V4( IGxContext context ,
                                             string A440ProveedorPagoDefault ,
                                             GxSimpleCollection<string> AV82Proveedorwwds_15_tfproveedorpagodefault_sels ,
                                             string A344ProveedorEstado ,
                                             GxSimpleCollection<string> AV83Proveedorwwds_16_tfproveedorestado_sels ,
                                             short AV68Proveedorwwds_1_gridconditionalformattingfilter ,
                                             long AV70Proveedorwwds_3_tfproveedorid ,
                                             long AV71Proveedorwwds_4_tfproveedorid_to ,
                                             string AV73Proveedorwwds_6_tfproveedornombre_sel ,
                                             string AV72Proveedorwwds_5_tfproveedornombre ,
                                             string AV75Proveedorwwds_8_tfproveedordocidentidad_sel ,
                                             string AV74Proveedorwwds_7_tfproveedordocidentidad ,
                                             string AV77Proveedorwwds_10_tfproveedortelefono_sel ,
                                             string AV76Proveedorwwds_9_tfproveedortelefono ,
                                             string AV79Proveedorwwds_12_tfproveedordireccion_sel ,
                                             string AV78Proveedorwwds_11_tfproveedordireccion ,
                                             string AV81Proveedorwwds_14_tfproveedoremail_sel ,
                                             string AV80Proveedorwwds_13_tfproveedoremail ,
                                             int AV82Proveedorwwds_15_tfproveedorpagodefault_sels_Count ,
                                             int AV83Proveedorwwds_16_tfproveedorestado_sels_Count ,
                                             bool AV65VerTodProv ,
                                             decimal AV84Hacerload ,
                                             long A133ProveedorID ,
                                             string A282ProveedorNombre ,
                                             string A338ProveedorDocIdentidad ,
                                             string A430ProveedorTelefono ,
                                             string A431ProveedorDireccion ,
                                             string A433ProveedorEmail ,
                                             string AV69Proveedorwwds_2_filterfulltext )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int6 = new short[13];
         Object[] GXv_Object7 = new Object[2];
         scmdbuf = "SELECT [ProveedorTelefono], [ProveedorEmail], [ProveedorDireccion], [ProveedorDocIdentidad], [ProveedorNombre], [ProveedorID], [ProveedorEstado], [ProveedorPagoDefault] FROM [Proveedor]";
         if ( AV68Proveedorwwds_1_gridconditionalformattingfilter == 1 )
         {
            AddWhere(sWhereString, "(@AV84Hacerload = 1)");
         }
         else
         {
            GXv_int6[0] = 1;
         }
         if ( ! (0==AV70Proveedorwwds_3_tfproveedorid) )
         {
            AddWhere(sWhereString, "([ProveedorID] >= @AV70Proveedorwwds_3_tfproveedorid)");
         }
         else
         {
            GXv_int6[1] = 1;
         }
         if ( ! (0==AV71Proveedorwwds_4_tfproveedorid_to) )
         {
            AddWhere(sWhereString, "([ProveedorID] <= @AV71Proveedorwwds_4_tfproveedorid_to)");
         }
         else
         {
            GXv_int6[2] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV73Proveedorwwds_6_tfproveedornombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Proveedorwwds_5_tfproveedornombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ProveedorNombre]) like UPPER(@lV72Proveedorwwds_5_tfproveedornombre))");
         }
         else
         {
            GXv_int6[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Proveedorwwds_6_tfproveedornombre_sel)) && ! ( StringUtil.StrCmp(AV73Proveedorwwds_6_tfproveedornombre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([ProveedorNombre] = @AV73Proveedorwwds_6_tfproveedornombre_sel)");
         }
         else
         {
            GXv_int6[4] = 1;
         }
         if ( StringUtil.StrCmp(AV73Proveedorwwds_6_tfproveedornombre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([ProveedorNombre] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV75Proveedorwwds_8_tfproveedordocidentidad_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Proveedorwwds_7_tfproveedordocidentidad)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ProveedorDocIdentidad]) like UPPER(@lV74Proveedorwwds_7_tfproveedordocidentidad))");
         }
         else
         {
            GXv_int6[5] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75Proveedorwwds_8_tfproveedordocidentidad_sel)) && ! ( StringUtil.StrCmp(AV75Proveedorwwds_8_tfproveedordocidentidad_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([ProveedorDocIdentidad] = @AV75Proveedorwwds_8_tfproveedordocidentidad_sel)");
         }
         else
         {
            GXv_int6[6] = 1;
         }
         if ( StringUtil.StrCmp(AV75Proveedorwwds_8_tfproveedordocidentidad_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([ProveedorDocIdentidad] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV77Proveedorwwds_10_tfproveedortelefono_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV76Proveedorwwds_9_tfproveedortelefono)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ProveedorTelefono]) like UPPER(@lV76Proveedorwwds_9_tfproveedortelefono))");
         }
         else
         {
            GXv_int6[7] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV77Proveedorwwds_10_tfproveedortelefono_sel)) && ! ( StringUtil.StrCmp(AV77Proveedorwwds_10_tfproveedortelefono_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([ProveedorTelefono] = @AV77Proveedorwwds_10_tfproveedortelefono_sel)");
         }
         else
         {
            GXv_int6[8] = 1;
         }
         if ( StringUtil.StrCmp(AV77Proveedorwwds_10_tfproveedortelefono_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "([ProveedorTelefono] IS NULL or ([ProveedorTelefono] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV79Proveedorwwds_12_tfproveedordireccion_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV78Proveedorwwds_11_tfproveedordireccion)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ProveedorDireccion]) like UPPER(@lV78Proveedorwwds_11_tfproveedordireccion))");
         }
         else
         {
            GXv_int6[9] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV79Proveedorwwds_12_tfproveedordireccion_sel)) && ! ( StringUtil.StrCmp(AV79Proveedorwwds_12_tfproveedordireccion_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([ProveedorDireccion] = @AV79Proveedorwwds_12_tfproveedordireccion_sel)");
         }
         else
         {
            GXv_int6[10] = 1;
         }
         if ( StringUtil.StrCmp(AV79Proveedorwwds_12_tfproveedordireccion_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "([ProveedorDireccion] IS NULL or ([ProveedorDireccion] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV81Proveedorwwds_14_tfproveedoremail_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV80Proveedorwwds_13_tfproveedoremail)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ProveedorEmail]) like UPPER(@lV80Proveedorwwds_13_tfproveedoremail))");
         }
         else
         {
            GXv_int6[11] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV81Proveedorwwds_14_tfproveedoremail_sel)) && ! ( StringUtil.StrCmp(AV81Proveedorwwds_14_tfproveedoremail_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([ProveedorEmail] = @AV81Proveedorwwds_14_tfproveedoremail_sel)");
         }
         else
         {
            GXv_int6[12] = 1;
         }
         if ( StringUtil.StrCmp(AV81Proveedorwwds_14_tfproveedoremail_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "([ProveedorEmail] IS NULL or ([ProveedorEmail] = ''))");
         }
         if ( AV82Proveedorwwds_15_tfproveedorpagodefault_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV82Proveedorwwds_15_tfproveedorpagodefault_sels, "[ProveedorPagoDefault] IN (", ")")+")");
         }
         if ( AV83Proveedorwwds_16_tfproveedorestado_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV83Proveedorwwds_16_tfproveedorestado_sels, "[ProveedorEstado] IN (", ")")+")");
         }
         if ( ! AV65VerTodProv )
         {
            AddWhere(sWhereString, "([ProveedorEstado] = 'HAB')");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY [ProveedorTelefono]";
         GXv_Object7[0] = scmdbuf;
         GXv_Object7[1] = GXv_int6;
         return GXv_Object7 ;
      }

      protected Object[] conditional_P006V5( IGxContext context ,
                                             string A440ProveedorPagoDefault ,
                                             GxSimpleCollection<string> AV82Proveedorwwds_15_tfproveedorpagodefault_sels ,
                                             string A344ProveedorEstado ,
                                             GxSimpleCollection<string> AV83Proveedorwwds_16_tfproveedorestado_sels ,
                                             short AV68Proveedorwwds_1_gridconditionalformattingfilter ,
                                             long AV70Proveedorwwds_3_tfproveedorid ,
                                             long AV71Proveedorwwds_4_tfproveedorid_to ,
                                             string AV73Proveedorwwds_6_tfproveedornombre_sel ,
                                             string AV72Proveedorwwds_5_tfproveedornombre ,
                                             string AV75Proveedorwwds_8_tfproveedordocidentidad_sel ,
                                             string AV74Proveedorwwds_7_tfproveedordocidentidad ,
                                             string AV77Proveedorwwds_10_tfproveedortelefono_sel ,
                                             string AV76Proveedorwwds_9_tfproveedortelefono ,
                                             string AV79Proveedorwwds_12_tfproveedordireccion_sel ,
                                             string AV78Proveedorwwds_11_tfproveedordireccion ,
                                             string AV81Proveedorwwds_14_tfproveedoremail_sel ,
                                             string AV80Proveedorwwds_13_tfproveedoremail ,
                                             int AV82Proveedorwwds_15_tfproveedorpagodefault_sels_Count ,
                                             int AV83Proveedorwwds_16_tfproveedorestado_sels_Count ,
                                             bool AV65VerTodProv ,
                                             decimal AV84Hacerload ,
                                             long A133ProveedorID ,
                                             string A282ProveedorNombre ,
                                             string A338ProveedorDocIdentidad ,
                                             string A430ProveedorTelefono ,
                                             string A431ProveedorDireccion ,
                                             string A433ProveedorEmail ,
                                             string AV69Proveedorwwds_2_filterfulltext )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int8 = new short[13];
         Object[] GXv_Object9 = new Object[2];
         scmdbuf = "SELECT [ProveedorDireccion], [ProveedorEmail], [ProveedorTelefono], [ProveedorDocIdentidad], [ProveedorNombre], [ProveedorID], [ProveedorEstado], [ProveedorPagoDefault] FROM [Proveedor]";
         if ( AV68Proveedorwwds_1_gridconditionalformattingfilter == 1 )
         {
            AddWhere(sWhereString, "(@AV84Hacerload = 1)");
         }
         else
         {
            GXv_int8[0] = 1;
         }
         if ( ! (0==AV70Proveedorwwds_3_tfproveedorid) )
         {
            AddWhere(sWhereString, "([ProveedorID] >= @AV70Proveedorwwds_3_tfproveedorid)");
         }
         else
         {
            GXv_int8[1] = 1;
         }
         if ( ! (0==AV71Proveedorwwds_4_tfproveedorid_to) )
         {
            AddWhere(sWhereString, "([ProveedorID] <= @AV71Proveedorwwds_4_tfproveedorid_to)");
         }
         else
         {
            GXv_int8[2] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV73Proveedorwwds_6_tfproveedornombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Proveedorwwds_5_tfproveedornombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ProveedorNombre]) like UPPER(@lV72Proveedorwwds_5_tfproveedornombre))");
         }
         else
         {
            GXv_int8[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Proveedorwwds_6_tfproveedornombre_sel)) && ! ( StringUtil.StrCmp(AV73Proveedorwwds_6_tfproveedornombre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([ProveedorNombre] = @AV73Proveedorwwds_6_tfproveedornombre_sel)");
         }
         else
         {
            GXv_int8[4] = 1;
         }
         if ( StringUtil.StrCmp(AV73Proveedorwwds_6_tfproveedornombre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([ProveedorNombre] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV75Proveedorwwds_8_tfproveedordocidentidad_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Proveedorwwds_7_tfproveedordocidentidad)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ProveedorDocIdentidad]) like UPPER(@lV74Proveedorwwds_7_tfproveedordocidentidad))");
         }
         else
         {
            GXv_int8[5] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75Proveedorwwds_8_tfproveedordocidentidad_sel)) && ! ( StringUtil.StrCmp(AV75Proveedorwwds_8_tfproveedordocidentidad_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([ProveedorDocIdentidad] = @AV75Proveedorwwds_8_tfproveedordocidentidad_sel)");
         }
         else
         {
            GXv_int8[6] = 1;
         }
         if ( StringUtil.StrCmp(AV75Proveedorwwds_8_tfproveedordocidentidad_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([ProveedorDocIdentidad] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV77Proveedorwwds_10_tfproveedortelefono_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV76Proveedorwwds_9_tfproveedortelefono)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ProveedorTelefono]) like UPPER(@lV76Proveedorwwds_9_tfproveedortelefono))");
         }
         else
         {
            GXv_int8[7] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV77Proveedorwwds_10_tfproveedortelefono_sel)) && ! ( StringUtil.StrCmp(AV77Proveedorwwds_10_tfproveedortelefono_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([ProveedorTelefono] = @AV77Proveedorwwds_10_tfproveedortelefono_sel)");
         }
         else
         {
            GXv_int8[8] = 1;
         }
         if ( StringUtil.StrCmp(AV77Proveedorwwds_10_tfproveedortelefono_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "([ProveedorTelefono] IS NULL or ([ProveedorTelefono] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV79Proveedorwwds_12_tfproveedordireccion_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV78Proveedorwwds_11_tfproveedordireccion)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ProveedorDireccion]) like UPPER(@lV78Proveedorwwds_11_tfproveedordireccion))");
         }
         else
         {
            GXv_int8[9] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV79Proveedorwwds_12_tfproveedordireccion_sel)) && ! ( StringUtil.StrCmp(AV79Proveedorwwds_12_tfproveedordireccion_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([ProveedorDireccion] = @AV79Proveedorwwds_12_tfproveedordireccion_sel)");
         }
         else
         {
            GXv_int8[10] = 1;
         }
         if ( StringUtil.StrCmp(AV79Proveedorwwds_12_tfproveedordireccion_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "([ProveedorDireccion] IS NULL or ([ProveedorDireccion] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV81Proveedorwwds_14_tfproveedoremail_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV80Proveedorwwds_13_tfproveedoremail)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ProveedorEmail]) like UPPER(@lV80Proveedorwwds_13_tfproveedoremail))");
         }
         else
         {
            GXv_int8[11] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV81Proveedorwwds_14_tfproveedoremail_sel)) && ! ( StringUtil.StrCmp(AV81Proveedorwwds_14_tfproveedoremail_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([ProveedorEmail] = @AV81Proveedorwwds_14_tfproveedoremail_sel)");
         }
         else
         {
            GXv_int8[12] = 1;
         }
         if ( StringUtil.StrCmp(AV81Proveedorwwds_14_tfproveedoremail_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "([ProveedorEmail] IS NULL or ([ProveedorEmail] = ''))");
         }
         if ( AV82Proveedorwwds_15_tfproveedorpagodefault_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV82Proveedorwwds_15_tfproveedorpagodefault_sels, "[ProveedorPagoDefault] IN (", ")")+")");
         }
         if ( AV83Proveedorwwds_16_tfproveedorestado_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV83Proveedorwwds_16_tfproveedorestado_sels, "[ProveedorEstado] IN (", ")")+")");
         }
         if ( ! AV65VerTodProv )
         {
            AddWhere(sWhereString, "([ProveedorEstado] = 'HAB')");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY [ProveedorDireccion]";
         GXv_Object9[0] = scmdbuf;
         GXv_Object9[1] = GXv_int8;
         return GXv_Object9 ;
      }

      protected Object[] conditional_P006V6( IGxContext context ,
                                             string A440ProveedorPagoDefault ,
                                             GxSimpleCollection<string> AV82Proveedorwwds_15_tfproveedorpagodefault_sels ,
                                             string A344ProveedorEstado ,
                                             GxSimpleCollection<string> AV83Proveedorwwds_16_tfproveedorestado_sels ,
                                             short AV68Proveedorwwds_1_gridconditionalformattingfilter ,
                                             long AV70Proveedorwwds_3_tfproveedorid ,
                                             long AV71Proveedorwwds_4_tfproveedorid_to ,
                                             string AV73Proveedorwwds_6_tfproveedornombre_sel ,
                                             string AV72Proveedorwwds_5_tfproveedornombre ,
                                             string AV75Proveedorwwds_8_tfproveedordocidentidad_sel ,
                                             string AV74Proveedorwwds_7_tfproveedordocidentidad ,
                                             string AV77Proveedorwwds_10_tfproveedortelefono_sel ,
                                             string AV76Proveedorwwds_9_tfproveedortelefono ,
                                             string AV79Proveedorwwds_12_tfproveedordireccion_sel ,
                                             string AV78Proveedorwwds_11_tfproveedordireccion ,
                                             string AV81Proveedorwwds_14_tfproveedoremail_sel ,
                                             string AV80Proveedorwwds_13_tfproveedoremail ,
                                             int AV82Proveedorwwds_15_tfproveedorpagodefault_sels_Count ,
                                             int AV83Proveedorwwds_16_tfproveedorestado_sels_Count ,
                                             bool AV65VerTodProv ,
                                             decimal AV84Hacerload ,
                                             long A133ProveedorID ,
                                             string A282ProveedorNombre ,
                                             string A338ProveedorDocIdentidad ,
                                             string A430ProveedorTelefono ,
                                             string A431ProveedorDireccion ,
                                             string A433ProveedorEmail ,
                                             string AV69Proveedorwwds_2_filterfulltext )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int10 = new short[13];
         Object[] GXv_Object11 = new Object[2];
         scmdbuf = "SELECT [ProveedorEmail], [ProveedorDireccion], [ProveedorTelefono], [ProveedorDocIdentidad], [ProveedorNombre], [ProveedorID], [ProveedorEstado], [ProveedorPagoDefault] FROM [Proveedor]";
         if ( AV68Proveedorwwds_1_gridconditionalformattingfilter == 1 )
         {
            AddWhere(sWhereString, "(@AV84Hacerload = 1)");
         }
         else
         {
            GXv_int10[0] = 1;
         }
         if ( ! (0==AV70Proveedorwwds_3_tfproveedorid) )
         {
            AddWhere(sWhereString, "([ProveedorID] >= @AV70Proveedorwwds_3_tfproveedorid)");
         }
         else
         {
            GXv_int10[1] = 1;
         }
         if ( ! (0==AV71Proveedorwwds_4_tfproveedorid_to) )
         {
            AddWhere(sWhereString, "([ProveedorID] <= @AV71Proveedorwwds_4_tfproveedorid_to)");
         }
         else
         {
            GXv_int10[2] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV73Proveedorwwds_6_tfproveedornombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Proveedorwwds_5_tfproveedornombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ProveedorNombre]) like UPPER(@lV72Proveedorwwds_5_tfproveedornombre))");
         }
         else
         {
            GXv_int10[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Proveedorwwds_6_tfproveedornombre_sel)) && ! ( StringUtil.StrCmp(AV73Proveedorwwds_6_tfproveedornombre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([ProveedorNombre] = @AV73Proveedorwwds_6_tfproveedornombre_sel)");
         }
         else
         {
            GXv_int10[4] = 1;
         }
         if ( StringUtil.StrCmp(AV73Proveedorwwds_6_tfproveedornombre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([ProveedorNombre] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV75Proveedorwwds_8_tfproveedordocidentidad_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Proveedorwwds_7_tfproveedordocidentidad)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ProveedorDocIdentidad]) like UPPER(@lV74Proveedorwwds_7_tfproveedordocidentidad))");
         }
         else
         {
            GXv_int10[5] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75Proveedorwwds_8_tfproveedordocidentidad_sel)) && ! ( StringUtil.StrCmp(AV75Proveedorwwds_8_tfproveedordocidentidad_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([ProveedorDocIdentidad] = @AV75Proveedorwwds_8_tfproveedordocidentidad_sel)");
         }
         else
         {
            GXv_int10[6] = 1;
         }
         if ( StringUtil.StrCmp(AV75Proveedorwwds_8_tfproveedordocidentidad_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([ProveedorDocIdentidad] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV77Proveedorwwds_10_tfproveedortelefono_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV76Proveedorwwds_9_tfproveedortelefono)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ProveedorTelefono]) like UPPER(@lV76Proveedorwwds_9_tfproveedortelefono))");
         }
         else
         {
            GXv_int10[7] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV77Proveedorwwds_10_tfproveedortelefono_sel)) && ! ( StringUtil.StrCmp(AV77Proveedorwwds_10_tfproveedortelefono_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([ProveedorTelefono] = @AV77Proveedorwwds_10_tfproveedortelefono_sel)");
         }
         else
         {
            GXv_int10[8] = 1;
         }
         if ( StringUtil.StrCmp(AV77Proveedorwwds_10_tfproveedortelefono_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "([ProveedorTelefono] IS NULL or ([ProveedorTelefono] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV79Proveedorwwds_12_tfproveedordireccion_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV78Proveedorwwds_11_tfproveedordireccion)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ProveedorDireccion]) like UPPER(@lV78Proveedorwwds_11_tfproveedordireccion))");
         }
         else
         {
            GXv_int10[9] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV79Proveedorwwds_12_tfproveedordireccion_sel)) && ! ( StringUtil.StrCmp(AV79Proveedorwwds_12_tfproveedordireccion_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([ProveedorDireccion] = @AV79Proveedorwwds_12_tfproveedordireccion_sel)");
         }
         else
         {
            GXv_int10[10] = 1;
         }
         if ( StringUtil.StrCmp(AV79Proveedorwwds_12_tfproveedordireccion_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "([ProveedorDireccion] IS NULL or ([ProveedorDireccion] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV81Proveedorwwds_14_tfproveedoremail_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV80Proveedorwwds_13_tfproveedoremail)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ProveedorEmail]) like UPPER(@lV80Proveedorwwds_13_tfproveedoremail))");
         }
         else
         {
            GXv_int10[11] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV81Proveedorwwds_14_tfproveedoremail_sel)) && ! ( StringUtil.StrCmp(AV81Proveedorwwds_14_tfproveedoremail_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([ProveedorEmail] = @AV81Proveedorwwds_14_tfproveedoremail_sel)");
         }
         else
         {
            GXv_int10[12] = 1;
         }
         if ( StringUtil.StrCmp(AV81Proveedorwwds_14_tfproveedoremail_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "([ProveedorEmail] IS NULL or ([ProveedorEmail] = ''))");
         }
         if ( AV82Proveedorwwds_15_tfproveedorpagodefault_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV82Proveedorwwds_15_tfproveedorpagodefault_sels, "[ProveedorPagoDefault] IN (", ")")+")");
         }
         if ( AV83Proveedorwwds_16_tfproveedorestado_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV83Proveedorwwds_16_tfproveedorestado_sels, "[ProveedorEstado] IN (", ")")+")");
         }
         if ( ! AV65VerTodProv )
         {
            AddWhere(sWhereString, "([ProveedorEstado] = 'HAB')");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY [ProveedorEmail]";
         GXv_Object11[0] = scmdbuf;
         GXv_Object11[1] = GXv_int10;
         return GXv_Object11 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_P006V2(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (GxSimpleCollection<string>)dynConstraints[3] , (short)dynConstraints[4] , (long)dynConstraints[5] , (long)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (int)dynConstraints[17] , (int)dynConstraints[18] , (bool)dynConstraints[19] , (decimal)dynConstraints[20] , (long)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (string)dynConstraints[25] , (string)dynConstraints[26] , (string)dynConstraints[27] );
               case 1 :
                     return conditional_P006V3(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (GxSimpleCollection<string>)dynConstraints[3] , (short)dynConstraints[4] , (long)dynConstraints[5] , (long)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (int)dynConstraints[17] , (int)dynConstraints[18] , (bool)dynConstraints[19] , (decimal)dynConstraints[20] , (long)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (string)dynConstraints[25] , (string)dynConstraints[26] , (string)dynConstraints[27] );
               case 2 :
                     return conditional_P006V4(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (GxSimpleCollection<string>)dynConstraints[3] , (short)dynConstraints[4] , (long)dynConstraints[5] , (long)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (int)dynConstraints[17] , (int)dynConstraints[18] , (bool)dynConstraints[19] , (decimal)dynConstraints[20] , (long)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (string)dynConstraints[25] , (string)dynConstraints[26] , (string)dynConstraints[27] );
               case 3 :
                     return conditional_P006V5(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (GxSimpleCollection<string>)dynConstraints[3] , (short)dynConstraints[4] , (long)dynConstraints[5] , (long)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (int)dynConstraints[17] , (int)dynConstraints[18] , (bool)dynConstraints[19] , (decimal)dynConstraints[20] , (long)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (string)dynConstraints[25] , (string)dynConstraints[26] , (string)dynConstraints[27] );
               case 4 :
                     return conditional_P006V6(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (GxSimpleCollection<string>)dynConstraints[3] , (short)dynConstraints[4] , (long)dynConstraints[5] , (long)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (int)dynConstraints[17] , (int)dynConstraints[18] , (bool)dynConstraints[19] , (decimal)dynConstraints[20] , (long)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (string)dynConstraints[25] , (string)dynConstraints[26] , (string)dynConstraints[27] );
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
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP006V2;
          prmP006V2 = new Object[] {
          new ParDef("@AV84Hacerload",GXType.Decimal,10,2) ,
          new ParDef("@AV70Proveedorwwds_3_tfproveedorid",GXType.Decimal,18,0) ,
          new ParDef("@AV71Proveedorwwds_4_tfproveedorid_to",GXType.Decimal,18,0) ,
          new ParDef("@lV72Proveedorwwds_5_tfproveedornombre",GXType.Char,80,0) ,
          new ParDef("@AV73Proveedorwwds_6_tfproveedornombre_sel",GXType.NChar,80,0) ,
          new ParDef("@lV74Proveedorwwds_7_tfproveedordocidentidad",GXType.Char,25,0) ,
          new ParDef("@AV75Proveedorwwds_8_tfproveedordocidentidad_sel",GXType.NChar,25,0) ,
          new ParDef("@lV76Proveedorwwds_9_tfproveedortelefono",GXType.Char,20,0) ,
          new ParDef("@AV77Proveedorwwds_10_tfproveedortelefono_sel",GXType.NChar,20,0) ,
          new ParDef("@lV78Proveedorwwds_11_tfproveedordireccion",GXType.VarChar,1024,0) ,
          new ParDef("@AV79Proveedorwwds_12_tfproveedordireccion_sel",GXType.NVarChar,1024,0) ,
          new ParDef("@lV80Proveedorwwds_13_tfproveedoremail",GXType.VarChar,100,0) ,
          new ParDef("@AV81Proveedorwwds_14_tfproveedoremail_sel",GXType.NVarChar,100,0)
          };
          Object[] prmP006V3;
          prmP006V3 = new Object[] {
          new ParDef("@AV84Hacerload",GXType.Decimal,10,2) ,
          new ParDef("@AV70Proveedorwwds_3_tfproveedorid",GXType.Decimal,18,0) ,
          new ParDef("@AV71Proveedorwwds_4_tfproveedorid_to",GXType.Decimal,18,0) ,
          new ParDef("@lV72Proveedorwwds_5_tfproveedornombre",GXType.Char,80,0) ,
          new ParDef("@AV73Proveedorwwds_6_tfproveedornombre_sel",GXType.NChar,80,0) ,
          new ParDef("@lV74Proveedorwwds_7_tfproveedordocidentidad",GXType.Char,25,0) ,
          new ParDef("@AV75Proveedorwwds_8_tfproveedordocidentidad_sel",GXType.NChar,25,0) ,
          new ParDef("@lV76Proveedorwwds_9_tfproveedortelefono",GXType.Char,20,0) ,
          new ParDef("@AV77Proveedorwwds_10_tfproveedortelefono_sel",GXType.NChar,20,0) ,
          new ParDef("@lV78Proveedorwwds_11_tfproveedordireccion",GXType.VarChar,1024,0) ,
          new ParDef("@AV79Proveedorwwds_12_tfproveedordireccion_sel",GXType.NVarChar,1024,0) ,
          new ParDef("@lV80Proveedorwwds_13_tfproveedoremail",GXType.VarChar,100,0) ,
          new ParDef("@AV81Proveedorwwds_14_tfproveedoremail_sel",GXType.NVarChar,100,0)
          };
          Object[] prmP006V4;
          prmP006V4 = new Object[] {
          new ParDef("@AV84Hacerload",GXType.Decimal,10,2) ,
          new ParDef("@AV70Proveedorwwds_3_tfproveedorid",GXType.Decimal,18,0) ,
          new ParDef("@AV71Proveedorwwds_4_tfproveedorid_to",GXType.Decimal,18,0) ,
          new ParDef("@lV72Proveedorwwds_5_tfproveedornombre",GXType.Char,80,0) ,
          new ParDef("@AV73Proveedorwwds_6_tfproveedornombre_sel",GXType.NChar,80,0) ,
          new ParDef("@lV74Proveedorwwds_7_tfproveedordocidentidad",GXType.Char,25,0) ,
          new ParDef("@AV75Proveedorwwds_8_tfproveedordocidentidad_sel",GXType.NChar,25,0) ,
          new ParDef("@lV76Proveedorwwds_9_tfproveedortelefono",GXType.Char,20,0) ,
          new ParDef("@AV77Proveedorwwds_10_tfproveedortelefono_sel",GXType.NChar,20,0) ,
          new ParDef("@lV78Proveedorwwds_11_tfproveedordireccion",GXType.VarChar,1024,0) ,
          new ParDef("@AV79Proveedorwwds_12_tfproveedordireccion_sel",GXType.NVarChar,1024,0) ,
          new ParDef("@lV80Proveedorwwds_13_tfproveedoremail",GXType.VarChar,100,0) ,
          new ParDef("@AV81Proveedorwwds_14_tfproveedoremail_sel",GXType.NVarChar,100,0)
          };
          Object[] prmP006V5;
          prmP006V5 = new Object[] {
          new ParDef("@AV84Hacerload",GXType.Decimal,10,2) ,
          new ParDef("@AV70Proveedorwwds_3_tfproveedorid",GXType.Decimal,18,0) ,
          new ParDef("@AV71Proveedorwwds_4_tfproveedorid_to",GXType.Decimal,18,0) ,
          new ParDef("@lV72Proveedorwwds_5_tfproveedornombre",GXType.Char,80,0) ,
          new ParDef("@AV73Proveedorwwds_6_tfproveedornombre_sel",GXType.NChar,80,0) ,
          new ParDef("@lV74Proveedorwwds_7_tfproveedordocidentidad",GXType.Char,25,0) ,
          new ParDef("@AV75Proveedorwwds_8_tfproveedordocidentidad_sel",GXType.NChar,25,0) ,
          new ParDef("@lV76Proveedorwwds_9_tfproveedortelefono",GXType.Char,20,0) ,
          new ParDef("@AV77Proveedorwwds_10_tfproveedortelefono_sel",GXType.NChar,20,0) ,
          new ParDef("@lV78Proveedorwwds_11_tfproveedordireccion",GXType.VarChar,1024,0) ,
          new ParDef("@AV79Proveedorwwds_12_tfproveedordireccion_sel",GXType.NVarChar,1024,0) ,
          new ParDef("@lV80Proveedorwwds_13_tfproveedoremail",GXType.VarChar,100,0) ,
          new ParDef("@AV81Proveedorwwds_14_tfproveedoremail_sel",GXType.NVarChar,100,0)
          };
          Object[] prmP006V6;
          prmP006V6 = new Object[] {
          new ParDef("@AV84Hacerload",GXType.Decimal,10,2) ,
          new ParDef("@AV70Proveedorwwds_3_tfproveedorid",GXType.Decimal,18,0) ,
          new ParDef("@AV71Proveedorwwds_4_tfproveedorid_to",GXType.Decimal,18,0) ,
          new ParDef("@lV72Proveedorwwds_5_tfproveedornombre",GXType.Char,80,0) ,
          new ParDef("@AV73Proveedorwwds_6_tfproveedornombre_sel",GXType.NChar,80,0) ,
          new ParDef("@lV74Proveedorwwds_7_tfproveedordocidentidad",GXType.Char,25,0) ,
          new ParDef("@AV75Proveedorwwds_8_tfproveedordocidentidad_sel",GXType.NChar,25,0) ,
          new ParDef("@lV76Proveedorwwds_9_tfproveedortelefono",GXType.Char,20,0) ,
          new ParDef("@AV77Proveedorwwds_10_tfproveedortelefono_sel",GXType.NChar,20,0) ,
          new ParDef("@lV78Proveedorwwds_11_tfproveedordireccion",GXType.VarChar,1024,0) ,
          new ParDef("@AV79Proveedorwwds_12_tfproveedordireccion_sel",GXType.NVarChar,1024,0) ,
          new ParDef("@lV80Proveedorwwds_13_tfproveedoremail",GXType.VarChar,100,0) ,
          new ParDef("@AV81Proveedorwwds_14_tfproveedoremail_sel",GXType.NVarChar,100,0)
          };
          def= new CursorDef[] {
              new CursorDef("P006V2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP006V2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P006V3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP006V3,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P006V4", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP006V4,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P006V5", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP006V5,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P006V6", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP006V6,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[0])[0] = rslt.getString(1, 80);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getString(4, 20);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((string[]) buf[7])[0] = rslt.getString(5, 25);
                ((long[]) buf[8])[0] = rslt.getLong(6);
                ((string[]) buf[9])[0] = rslt.getString(7, 3);
                ((string[]) buf[10])[0] = rslt.getString(8, 1);
                return;
             case 1 :
                ((string[]) buf[0])[0] = rslt.getString(1, 25);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getString(4, 20);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((string[]) buf[7])[0] = rslt.getString(5, 80);
                ((long[]) buf[8])[0] = rslt.getLong(6);
                ((string[]) buf[9])[0] = rslt.getString(7, 3);
                ((string[]) buf[10])[0] = rslt.getString(8, 1);
                return;
             case 2 :
                ((string[]) buf[0])[0] = rslt.getString(1, 20);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getVarchar(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((string[]) buf[4])[0] = rslt.getVarchar(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((string[]) buf[6])[0] = rslt.getString(4, 25);
                ((string[]) buf[7])[0] = rslt.getString(5, 80);
                ((long[]) buf[8])[0] = rslt.getLong(6);
                ((string[]) buf[9])[0] = rslt.getString(7, 3);
                ((string[]) buf[10])[0] = rslt.getString(8, 1);
                return;
             case 3 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getVarchar(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((string[]) buf[4])[0] = rslt.getString(3, 20);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((string[]) buf[6])[0] = rslt.getString(4, 25);
                ((string[]) buf[7])[0] = rslt.getString(5, 80);
                ((long[]) buf[8])[0] = rslt.getLong(6);
                ((string[]) buf[9])[0] = rslt.getString(7, 3);
                ((string[]) buf[10])[0] = rslt.getString(8, 1);
                return;
             case 4 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getVarchar(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((string[]) buf[4])[0] = rslt.getString(3, 20);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((string[]) buf[6])[0] = rslt.getString(4, 25);
                ((string[]) buf[7])[0] = rslt.getString(5, 80);
                ((long[]) buf[8])[0] = rslt.getLong(6);
                ((string[]) buf[9])[0] = rslt.getString(7, 3);
                ((string[]) buf[10])[0] = rslt.getString(8, 1);
                return;
       }
    }

 }

 [ServiceContract(Namespace = "GeneXus.Programs.proveedorwwgetfilterdata_services")]
 [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple)]
 [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
 public class proveedorwwgetfilterdata_services : GxRestService
 {
    [OperationContract(Name = "ProveedorWWGetFilterData" )]
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
          if ( ! ProcessHeaders("proveedorwwgetfilterdata") )
          {
             return  ;
          }
          proveedorwwgetfilterdata worker = new proveedorwwgetfilterdata(context);
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

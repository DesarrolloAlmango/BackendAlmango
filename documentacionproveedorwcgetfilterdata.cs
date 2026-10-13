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
   public class documentacionproveedorwcgetfilterdata : GXProcedure
   {
      public documentacionproveedorwcgetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public documentacionproveedorwcgetfilterdata( IGxContext context )
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
         this.AV47DDOName = aP0_DDOName;
         this.AV48SearchTxtParms = aP1_SearchTxtParms;
         this.AV49SearchTxtTo = aP2_SearchTxtTo;
         this.AV50OptionsJson = "" ;
         this.AV51OptionsDescJson = "" ;
         this.AV52OptionIndexesJson = "" ;
         initialize();
         ExecutePrivate();
         aP3_OptionsJson=this.AV50OptionsJson;
         aP4_OptionsDescJson=this.AV51OptionsDescJson;
         aP5_OptionIndexesJson=this.AV52OptionIndexesJson;
      }

      public string executeUdp( string aP0_DDOName ,
                                string aP1_SearchTxtParms ,
                                string aP2_SearchTxtTo ,
                                out string aP3_OptionsJson ,
                                out string aP4_OptionsDescJson )
      {
         execute(aP0_DDOName, aP1_SearchTxtParms, aP2_SearchTxtTo, out aP3_OptionsJson, out aP4_OptionsDescJson, out aP5_OptionIndexesJson);
         return AV52OptionIndexesJson ;
      }

      public void executeSubmit( string aP0_DDOName ,
                                 string aP1_SearchTxtParms ,
                                 string aP2_SearchTxtTo ,
                                 out string aP3_OptionsJson ,
                                 out string aP4_OptionsDescJson ,
                                 out string aP5_OptionIndexesJson )
      {
         this.AV47DDOName = aP0_DDOName;
         this.AV48SearchTxtParms = aP1_SearchTxtParms;
         this.AV49SearchTxtTo = aP2_SearchTxtTo;
         this.AV50OptionsJson = "" ;
         this.AV51OptionsDescJson = "" ;
         this.AV52OptionIndexesJson = "" ;
         SubmitImpl();
         aP3_OptionsJson=this.AV50OptionsJson;
         aP4_OptionsDescJson=this.AV51OptionsDescJson;
         aP5_OptionIndexesJson=this.AV52OptionIndexesJson;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV37Options = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV39OptionsDesc = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV40OptionIndexes = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         GXt_boolean1 = AV8IsAuthorized;
         new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWProveedor", out  GXt_boolean1) ;
         AV8IsAuthorized = GXt_boolean1;
         if ( AV8IsAuthorized )
         {
            AV34MaxItems = 10;
            AV33PageIndex = (short)((String.IsNullOrEmpty(StringUtil.RTrim( AV48SearchTxtParms)) ? 0 : (long)(Math.Round(NumberUtil.Val( StringUtil.Substring( AV48SearchTxtParms, 1, 2), "."), 18, MidpointRounding.ToEven))));
            AV31SearchTxt = (String.IsNullOrEmpty(StringUtil.RTrim( AV48SearchTxtParms)) ? "" : StringUtil.Substring( AV48SearchTxtParms, 3, -1));
            AV32SkipItems = (short)(AV33PageIndex*AV34MaxItems);
            new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV9WWPContext) ;
            /* Execute user subroutine: 'LOADGRIDSTATE' */
            S111 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
            if ( StringUtil.StrCmp(StringUtil.Upper( AV47DDOName), "DDO_PROVEEDORESTIPONOMBRE") == 0 )
            {
               /* Execute user subroutine: 'LOADPROVEEDORESTIPONOMBREOPTIONS' */
               S121 ();
               if ( returnInSub )
               {
                  cleanup();
                  if (true) return;
               }
            }
            else if ( StringUtil.StrCmp(StringUtil.Upper( AV47DDOName), "DDO_PROVEEDORNOMBRE") == 0 )
            {
               /* Execute user subroutine: 'LOADPROVEEDORNOMBREOPTIONS' */
               S131 ();
               if ( returnInSub )
               {
                  cleanup();
                  if (true) return;
               }
            }
            else if ( StringUtil.StrCmp(StringUtil.Upper( AV47DDOName), "DDO_PROVEEDORDOCIDENTIDAD") == 0 )
            {
               /* Execute user subroutine: 'LOADPROVEEDORDOCIDENTIDADOPTIONS' */
               S141 ();
               if ( returnInSub )
               {
                  cleanup();
                  if (true) return;
               }
            }
            else if ( StringUtil.StrCmp(StringUtil.Upper( AV47DDOName), "DDO_PROVEEDORTELEFONO") == 0 )
            {
               /* Execute user subroutine: 'LOADPROVEEDORTELEFONOOPTIONS' */
               S151 ();
               if ( returnInSub )
               {
                  cleanup();
                  if (true) return;
               }
            }
            else if ( StringUtil.StrCmp(StringUtil.Upper( AV47DDOName), "DDO_PROVEEDORDIRECCION") == 0 )
            {
               /* Execute user subroutine: 'LOADPROVEEDORDIRECCIONOPTIONS' */
               S161 ();
               if ( returnInSub )
               {
                  cleanup();
                  if (true) return;
               }
            }
            else if ( StringUtil.StrCmp(StringUtil.Upper( AV47DDOName), "DDO_PROVEEDOREMAIL") == 0 )
            {
               /* Execute user subroutine: 'LOADPROVEEDOREMAILOPTIONS' */
               S171 ();
               if ( returnInSub )
               {
                  cleanup();
                  if (true) return;
               }
            }
         }
         AV50OptionsJson = AV37Options.ToJSonString(false);
         AV51OptionsDescJson = AV39OptionsDesc.ToJSonString(false);
         AV52OptionIndexesJson = AV40OptionIndexes.ToJSonString(false);
         cleanup();
      }

      protected void S111( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV42Session.Get("DocumentacionProveedorWCGridState"), "") == 0 )
         {
            AV44GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "DocumentacionProveedorWCGridState"), null, "", "");
         }
         else
         {
            AV44GridState.FromXml(AV42Session.Get("DocumentacionProveedorWCGridState"), null, "", "");
         }
         AV55GXV1 = 1;
         while ( AV55GXV1 <= AV44GridState.gxTpr_Filtervalues.Count )
         {
            AV45GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV44GridState.gxTpr_Filtervalues.Item(AV55GXV1));
            if ( StringUtil.StrCmp(AV45GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV53FilterFullText = AV45GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV45GridStateFilterValue.gxTpr_Name, "TFPROVEEDORID") == 0 )
            {
               AV11TFProveedorID = (long)(Math.Round(NumberUtil.Val( AV45GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV12TFProveedorID_To = (long)(Math.Round(NumberUtil.Val( AV45GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV45GridStateFilterValue.gxTpr_Name, "TFPROVEEDORESTIPOID") == 0 )
            {
               AV13TFProveedoresTipoId = (long)(Math.Round(NumberUtil.Val( AV45GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV14TFProveedoresTipoId_To = (long)(Math.Round(NumberUtil.Val( AV45GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV45GridStateFilterValue.gxTpr_Name, "TFPROVEEDORESTIPONOMBRE") == 0 )
            {
               AV15TFProveedoresTipoNombre = AV45GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV45GridStateFilterValue.gxTpr_Name, "TFPROVEEDORESTIPONOMBRE_SEL") == 0 )
            {
               AV16TFProveedoresTipoNombre_Sel = AV45GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV45GridStateFilterValue.gxTpr_Name, "TFPROVEEDORNOMBRE") == 0 )
            {
               AV17TFProveedorNombre = AV45GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV45GridStateFilterValue.gxTpr_Name, "TFPROVEEDORNOMBRE_SEL") == 0 )
            {
               AV18TFProveedorNombre_Sel = AV45GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV45GridStateFilterValue.gxTpr_Name, "TFPROVEEDORDOCIDENTIDAD") == 0 )
            {
               AV19TFProveedorDocIdentidad = AV45GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV45GridStateFilterValue.gxTpr_Name, "TFPROVEEDORDOCIDENTIDAD_SEL") == 0 )
            {
               AV20TFProveedorDocIdentidad_Sel = AV45GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV45GridStateFilterValue.gxTpr_Name, "TFPROVEEDORTELEFONO") == 0 )
            {
               AV21TFProveedorTelefono = AV45GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV45GridStateFilterValue.gxTpr_Name, "TFPROVEEDORTELEFONO_SEL") == 0 )
            {
               AV22TFProveedorTelefono_Sel = AV45GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV45GridStateFilterValue.gxTpr_Name, "TFPROVEEDORDIRECCION") == 0 )
            {
               AV23TFProveedorDireccion = AV45GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV45GridStateFilterValue.gxTpr_Name, "TFPROVEEDORDIRECCION_SEL") == 0 )
            {
               AV24TFProveedorDireccion_Sel = AV45GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV45GridStateFilterValue.gxTpr_Name, "TFPROVEEDOREMAIL") == 0 )
            {
               AV25TFProveedorEmail = AV45GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV45GridStateFilterValue.gxTpr_Name, "TFPROVEEDOREMAIL_SEL") == 0 )
            {
               AV26TFProveedorEmail_Sel = AV45GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV45GridStateFilterValue.gxTpr_Name, "TFPROVEEDORESTADO_SEL") == 0 )
            {
               AV27TFProveedorEstado_SelsJson = AV45GridStateFilterValue.gxTpr_Value;
               AV28TFProveedorEstado_Sels.FromJSonString(AV27TFProveedorEstado_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV45GridStateFilterValue.gxTpr_Name, "TFPROVEEDORPAGODEFAULT_SEL") == 0 )
            {
               AV29TFProveedorPagoDefault_SelsJson = AV45GridStateFilterValue.gxTpr_Value;
               AV30TFProveedorPagoDefault_Sels.FromJSonString(AV29TFProveedorPagoDefault_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV45GridStateFilterValue.gxTpr_Name, "PARM_&DOCUMENTACIONID") == 0 )
            {
               AV54DocumentacionId = (long)(Math.Round(NumberUtil.Val( AV45GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
            }
            AV55GXV1 = (int)(AV55GXV1+1);
         }
      }

      protected void S121( )
      {
         /* 'LOADPROVEEDORESTIPONOMBREOPTIONS' Routine */
         returnInSub = false;
         AV15TFProveedoresTipoNombre = AV31SearchTxt;
         AV16TFProveedoresTipoNombre_Sel = "";
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A344ProveedorEstado ,
                                              AV28TFProveedorEstado_Sels ,
                                              A440ProveedorPagoDefault ,
                                              AV30TFProveedorPagoDefault_Sels ,
                                              AV11TFProveedorID ,
                                              AV12TFProveedorID_To ,
                                              AV13TFProveedoresTipoId ,
                                              AV14TFProveedoresTipoId_To ,
                                              AV16TFProveedoresTipoNombre_Sel ,
                                              AV15TFProveedoresTipoNombre ,
                                              AV18TFProveedorNombre_Sel ,
                                              AV17TFProveedorNombre ,
                                              AV20TFProveedorDocIdentidad_Sel ,
                                              AV19TFProveedorDocIdentidad ,
                                              AV22TFProveedorTelefono_Sel ,
                                              AV21TFProveedorTelefono ,
                                              AV24TFProveedorDireccion_Sel ,
                                              AV23TFProveedorDireccion ,
                                              AV26TFProveedorEmail_Sel ,
                                              AV25TFProveedorEmail ,
                                              AV28TFProveedorEstado_Sels.Count ,
                                              AV30TFProveedorPagoDefault_Sels.Count ,
                                              A133ProveedorID ,
                                              A151ProveedoresTipoId ,
                                              A278ProveedoresTipoNombre ,
                                              A282ProveedorNombre ,
                                              A338ProveedorDocIdentidad ,
                                              A430ProveedorTelefono ,
                                              A431ProveedorDireccion ,
                                              A433ProveedorEmail ,
                                              AV53FilterFullText ,
                                              AV54DocumentacionId ,
                                              A488DocumentacionId } ,
                                              new int[]{
                                              TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.INT, TypeConstants.INT, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN,
                                              TypeConstants.BOOLEAN, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.BOOLEAN
                                              }
         });
         lV15TFProveedoresTipoNombre = StringUtil.PadR( StringUtil.RTrim( AV15TFProveedoresTipoNombre), 120, "%");
         lV17TFProveedorNombre = StringUtil.PadR( StringUtil.RTrim( AV17TFProveedorNombre), 80, "%");
         lV19TFProveedorDocIdentidad = StringUtil.PadR( StringUtil.RTrim( AV19TFProveedorDocIdentidad), 25, "%");
         lV21TFProveedorTelefono = StringUtil.PadR( StringUtil.RTrim( AV21TFProveedorTelefono), 20, "%");
         lV23TFProveedorDireccion = StringUtil.Concat( StringUtil.RTrim( AV23TFProveedorDireccion), "%", "");
         lV25TFProveedorEmail = StringUtil.Concat( StringUtil.RTrim( AV25TFProveedorEmail), "%", "");
         /* Using cursor P00662 */
         pr_default.execute(0, new Object[] {AV54DocumentacionId, AV11TFProveedorID, AV12TFProveedorID_To, AV13TFProveedoresTipoId, AV14TFProveedoresTipoId_To, lV15TFProveedoresTipoNombre, AV16TFProveedoresTipoNombre_Sel, lV17TFProveedorNombre, AV18TFProveedorNombre_Sel, lV19TFProveedorDocIdentidad, AV20TFProveedorDocIdentidad_Sel, lV21TFProveedorTelefono, AV22TFProveedorTelefono_Sel, lV23TFProveedorDireccion, AV24TFProveedorDireccion_Sel, lV25TFProveedorEmail, AV26TFProveedorEmail_Sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRK662 = false;
            A488DocumentacionId = P00662_A488DocumentacionId[0];
            n488DocumentacionId = P00662_n488DocumentacionId[0];
            A151ProveedoresTipoId = P00662_A151ProveedoresTipoId[0];
            A440ProveedorPagoDefault = P00662_A440ProveedorPagoDefault[0];
            A344ProveedorEstado = P00662_A344ProveedorEstado[0];
            A433ProveedorEmail = P00662_A433ProveedorEmail[0];
            n433ProveedorEmail = P00662_n433ProveedorEmail[0];
            A431ProveedorDireccion = P00662_A431ProveedorDireccion[0];
            n431ProveedorDireccion = P00662_n431ProveedorDireccion[0];
            A430ProveedorTelefono = P00662_A430ProveedorTelefono[0];
            n430ProveedorTelefono = P00662_n430ProveedorTelefono[0];
            A338ProveedorDocIdentidad = P00662_A338ProveedorDocIdentidad[0];
            A282ProveedorNombre = P00662_A282ProveedorNombre[0];
            A278ProveedoresTipoNombre = P00662_A278ProveedoresTipoNombre[0];
            A133ProveedorID = P00662_A133ProveedorID[0];
            A278ProveedoresTipoNombre = P00662_A278ProveedoresTipoNombre[0];
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV53FilterFullText)) || ( ( StringUtil.Like( StringUtil.Str( (decimal)(A133ProveedorID), 18, 0) , StringUtil.PadR( "%" + AV53FilterFullText , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Str( (decimal)(A151ProveedoresTipoId), 18, 0) , StringUtil.PadR( "%" + AV53FilterFullText , 254 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Upper( A278ProveedoresTipoNombre) , StringUtil.PadR( "%" + StringUtil.Upper( AV53FilterFullText) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A282ProveedorNombre) , StringUtil.PadR( "%" + StringUtil.Upper( AV53FilterFullText) , 255 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Upper( A338ProveedorDocIdentidad) , StringUtil.PadR( "%" + StringUtil.Upper( AV53FilterFullText) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A430ProveedorTelefono) , StringUtil.PadR( "%" + StringUtil.Upper( AV53FilterFullText) , 255 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Upper( A431ProveedorDireccion) , StringUtil.PadR( "%" + StringUtil.Upper( AV53FilterFullText) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A433ProveedorEmail) , StringUtil.PadR( "%" + StringUtil.Upper( AV53FilterFullText) , 255 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( context.GetMessage( "habilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV53FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A344ProveedorEstado, "HAB") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "deshabilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV53FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A344ProveedorEstado, "DES") ==
            0 ) ) || ( StringUtil.Like( context.GetMessage( "pendiente", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV53FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A344ProveedorEstado, "PEN") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "cobro directo", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV53FilterFullText) , 255 , "%"),  ' ' ) &&
            ( StringUtil.StrCmp(A440ProveedorPagoDefault, "F") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "cobro prepago comercio", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV53FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A440ProveedorPagoDefault, "T") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "cobro prepago almango", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV53FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A440ProveedorPagoDefault, "O") == 0 ) ) )
            )
            {
               AV41count = 0;
               while ( (pr_default.getStatus(0) != 101) && ( P00662_A488DocumentacionId[0] == A488DocumentacionId ) && ( P00662_A151ProveedoresTipoId[0] == A151ProveedoresTipoId ) )
               {
                  BRK662 = false;
                  A133ProveedorID = P00662_A133ProveedorID[0];
                  AV41count = (long)(AV41count+1);
                  BRK662 = true;
                  pr_default.readNext(0);
               }
               AV36Option = (String.IsNullOrEmpty(StringUtil.RTrim( A278ProveedoresTipoNombre)) ? "<#Empty#>" : A278ProveedoresTipoNombre);
               AV35InsertIndex = 1;
               while ( ( StringUtil.StrCmp(AV36Option, "<#Empty#>") != 0 ) && ( AV35InsertIndex <= AV37Options.Count ) && ( ( StringUtil.StrCmp(((string)AV37Options.Item(AV35InsertIndex)), AV36Option) < 0 ) || ( StringUtil.StrCmp(((string)AV37Options.Item(AV35InsertIndex)), "<#Empty#>") == 0 ) ) )
               {
                  AV35InsertIndex = (int)(AV35InsertIndex+1);
               }
               AV37Options.Add(AV36Option, AV35InsertIndex);
               AV40OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV41count), "Z,ZZZ,ZZZ,ZZ9")), AV35InsertIndex);
               if ( AV37Options.Count == AV32SkipItems + 11 )
               {
                  AV37Options.RemoveItem(AV37Options.Count);
                  AV40OptionIndexes.RemoveItem(AV40OptionIndexes.Count);
               }
            }
            if ( ! BRK662 )
            {
               BRK662 = true;
               pr_default.readNext(0);
            }
         }
         pr_default.close(0);
         while ( AV32SkipItems > 0 )
         {
            AV37Options.RemoveItem(1);
            AV40OptionIndexes.RemoveItem(1);
            AV32SkipItems = (short)(AV32SkipItems-1);
         }
      }

      protected void S131( )
      {
         /* 'LOADPROVEEDORNOMBREOPTIONS' Routine */
         returnInSub = false;
         AV17TFProveedorNombre = AV31SearchTxt;
         AV18TFProveedorNombre_Sel = "";
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              A344ProveedorEstado ,
                                              AV28TFProveedorEstado_Sels ,
                                              A440ProveedorPagoDefault ,
                                              AV30TFProveedorPagoDefault_Sels ,
                                              AV11TFProveedorID ,
                                              AV12TFProveedorID_To ,
                                              AV13TFProveedoresTipoId ,
                                              AV14TFProveedoresTipoId_To ,
                                              AV16TFProveedoresTipoNombre_Sel ,
                                              AV15TFProveedoresTipoNombre ,
                                              AV18TFProveedorNombre_Sel ,
                                              AV17TFProveedorNombre ,
                                              AV20TFProveedorDocIdentidad_Sel ,
                                              AV19TFProveedorDocIdentidad ,
                                              AV22TFProveedorTelefono_Sel ,
                                              AV21TFProveedorTelefono ,
                                              AV24TFProveedorDireccion_Sel ,
                                              AV23TFProveedorDireccion ,
                                              AV26TFProveedorEmail_Sel ,
                                              AV25TFProveedorEmail ,
                                              AV28TFProveedorEstado_Sels.Count ,
                                              AV30TFProveedorPagoDefault_Sels.Count ,
                                              A133ProveedorID ,
                                              A151ProveedoresTipoId ,
                                              A278ProveedoresTipoNombre ,
                                              A282ProveedorNombre ,
                                              A338ProveedorDocIdentidad ,
                                              A430ProveedorTelefono ,
                                              A431ProveedorDireccion ,
                                              A433ProveedorEmail ,
                                              AV53FilterFullText ,
                                              AV54DocumentacionId ,
                                              A488DocumentacionId } ,
                                              new int[]{
                                              TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.INT, TypeConstants.INT, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN,
                                              TypeConstants.BOOLEAN, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.BOOLEAN
                                              }
         });
         lV15TFProveedoresTipoNombre = StringUtil.PadR( StringUtil.RTrim( AV15TFProveedoresTipoNombre), 120, "%");
         lV17TFProveedorNombre = StringUtil.PadR( StringUtil.RTrim( AV17TFProveedorNombre), 80, "%");
         lV19TFProveedorDocIdentidad = StringUtil.PadR( StringUtil.RTrim( AV19TFProveedorDocIdentidad), 25, "%");
         lV21TFProveedorTelefono = StringUtil.PadR( StringUtil.RTrim( AV21TFProveedorTelefono), 20, "%");
         lV23TFProveedorDireccion = StringUtil.Concat( StringUtil.RTrim( AV23TFProveedorDireccion), "%", "");
         lV25TFProveedorEmail = StringUtil.Concat( StringUtil.RTrim( AV25TFProveedorEmail), "%", "");
         /* Using cursor P00663 */
         pr_default.execute(1, new Object[] {AV54DocumentacionId, AV11TFProveedorID, AV12TFProveedorID_To, AV13TFProveedoresTipoId, AV14TFProveedoresTipoId_To, lV15TFProveedoresTipoNombre, AV16TFProveedoresTipoNombre_Sel, lV17TFProveedorNombre, AV18TFProveedorNombre_Sel, lV19TFProveedorDocIdentidad, AV20TFProveedorDocIdentidad_Sel, lV21TFProveedorTelefono, AV22TFProveedorTelefono_Sel, lV23TFProveedorDireccion, AV24TFProveedorDireccion_Sel, lV25TFProveedorEmail, AV26TFProveedorEmail_Sel});
         while ( (pr_default.getStatus(1) != 101) )
         {
            BRK664 = false;
            A488DocumentacionId = P00663_A488DocumentacionId[0];
            n488DocumentacionId = P00663_n488DocumentacionId[0];
            A282ProveedorNombre = P00663_A282ProveedorNombre[0];
            A440ProveedorPagoDefault = P00663_A440ProveedorPagoDefault[0];
            A344ProveedorEstado = P00663_A344ProveedorEstado[0];
            A433ProveedorEmail = P00663_A433ProveedorEmail[0];
            n433ProveedorEmail = P00663_n433ProveedorEmail[0];
            A431ProveedorDireccion = P00663_A431ProveedorDireccion[0];
            n431ProveedorDireccion = P00663_n431ProveedorDireccion[0];
            A430ProveedorTelefono = P00663_A430ProveedorTelefono[0];
            n430ProveedorTelefono = P00663_n430ProveedorTelefono[0];
            A338ProveedorDocIdentidad = P00663_A338ProveedorDocIdentidad[0];
            A278ProveedoresTipoNombre = P00663_A278ProveedoresTipoNombre[0];
            A151ProveedoresTipoId = P00663_A151ProveedoresTipoId[0];
            A133ProveedorID = P00663_A133ProveedorID[0];
            A278ProveedoresTipoNombre = P00663_A278ProveedoresTipoNombre[0];
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV53FilterFullText)) || ( ( StringUtil.Like( StringUtil.Str( (decimal)(A133ProveedorID), 18, 0) , StringUtil.PadR( "%" + AV53FilterFullText , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Str( (decimal)(A151ProveedoresTipoId), 18, 0) , StringUtil.PadR( "%" + AV53FilterFullText , 254 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Upper( A278ProveedoresTipoNombre) , StringUtil.PadR( "%" + StringUtil.Upper( AV53FilterFullText) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A282ProveedorNombre) , StringUtil.PadR( "%" + StringUtil.Upper( AV53FilterFullText) , 255 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Upper( A338ProveedorDocIdentidad) , StringUtil.PadR( "%" + StringUtil.Upper( AV53FilterFullText) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A430ProveedorTelefono) , StringUtil.PadR( "%" + StringUtil.Upper( AV53FilterFullText) , 255 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Upper( A431ProveedorDireccion) , StringUtil.PadR( "%" + StringUtil.Upper( AV53FilterFullText) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A433ProveedorEmail) , StringUtil.PadR( "%" + StringUtil.Upper( AV53FilterFullText) , 255 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( context.GetMessage( "habilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV53FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A344ProveedorEstado, "HAB") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "deshabilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV53FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A344ProveedorEstado, "DES") ==
            0 ) ) || ( StringUtil.Like( context.GetMessage( "pendiente", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV53FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A344ProveedorEstado, "PEN") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "cobro directo", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV53FilterFullText) , 255 , "%"),  ' ' ) &&
            ( StringUtil.StrCmp(A440ProveedorPagoDefault, "F") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "cobro prepago comercio", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV53FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A440ProveedorPagoDefault, "T") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "cobro prepago almango", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV53FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A440ProveedorPagoDefault, "O") == 0 ) ) )
            )
            {
               AV41count = 0;
               while ( (pr_default.getStatus(1) != 101) && ( P00663_A488DocumentacionId[0] == A488DocumentacionId ) && ( StringUtil.StrCmp(P00663_A282ProveedorNombre[0], A282ProveedorNombre) == 0 ) )
               {
                  BRK664 = false;
                  A133ProveedorID = P00663_A133ProveedorID[0];
                  AV41count = (long)(AV41count+1);
                  BRK664 = true;
                  pr_default.readNext(1);
               }
               if ( (0==AV32SkipItems) )
               {
                  AV36Option = (String.IsNullOrEmpty(StringUtil.RTrim( A282ProveedorNombre)) ? "<#Empty#>" : A282ProveedorNombre);
                  AV37Options.Add(AV36Option, 0);
                  AV40OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV41count), "Z,ZZZ,ZZZ,ZZ9")), 0);
                  if ( AV37Options.Count == 10 )
                  {
                     /* Exit For each command. Update data (if necessary), close cursors & exit. */
                     if (true) break;
                  }
               }
               else
               {
                  AV32SkipItems = (short)(AV32SkipItems-1);
               }
            }
            if ( ! BRK664 )
            {
               BRK664 = true;
               pr_default.readNext(1);
            }
         }
         pr_default.close(1);
      }

      protected void S141( )
      {
         /* 'LOADPROVEEDORDOCIDENTIDADOPTIONS' Routine */
         returnInSub = false;
         AV19TFProveedorDocIdentidad = AV31SearchTxt;
         AV20TFProveedorDocIdentidad_Sel = "";
         pr_default.dynParam(2, new Object[]{ new Object[]{
                                              A344ProveedorEstado ,
                                              AV28TFProveedorEstado_Sels ,
                                              A440ProveedorPagoDefault ,
                                              AV30TFProveedorPagoDefault_Sels ,
                                              AV11TFProveedorID ,
                                              AV12TFProveedorID_To ,
                                              AV13TFProveedoresTipoId ,
                                              AV14TFProveedoresTipoId_To ,
                                              AV16TFProveedoresTipoNombre_Sel ,
                                              AV15TFProveedoresTipoNombre ,
                                              AV18TFProveedorNombre_Sel ,
                                              AV17TFProveedorNombre ,
                                              AV20TFProveedorDocIdentidad_Sel ,
                                              AV19TFProveedorDocIdentidad ,
                                              AV22TFProveedorTelefono_Sel ,
                                              AV21TFProveedorTelefono ,
                                              AV24TFProveedorDireccion_Sel ,
                                              AV23TFProveedorDireccion ,
                                              AV26TFProveedorEmail_Sel ,
                                              AV25TFProveedorEmail ,
                                              AV28TFProveedorEstado_Sels.Count ,
                                              AV30TFProveedorPagoDefault_Sels.Count ,
                                              A133ProveedorID ,
                                              A151ProveedoresTipoId ,
                                              A278ProveedoresTipoNombre ,
                                              A282ProveedorNombre ,
                                              A338ProveedorDocIdentidad ,
                                              A430ProveedorTelefono ,
                                              A431ProveedorDireccion ,
                                              A433ProveedorEmail ,
                                              AV53FilterFullText ,
                                              AV54DocumentacionId ,
                                              A488DocumentacionId } ,
                                              new int[]{
                                              TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.INT, TypeConstants.INT, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN,
                                              TypeConstants.BOOLEAN, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.BOOLEAN
                                              }
         });
         lV15TFProveedoresTipoNombre = StringUtil.PadR( StringUtil.RTrim( AV15TFProveedoresTipoNombre), 120, "%");
         lV17TFProveedorNombre = StringUtil.PadR( StringUtil.RTrim( AV17TFProveedorNombre), 80, "%");
         lV19TFProveedorDocIdentidad = StringUtil.PadR( StringUtil.RTrim( AV19TFProveedorDocIdentidad), 25, "%");
         lV21TFProveedorTelefono = StringUtil.PadR( StringUtil.RTrim( AV21TFProveedorTelefono), 20, "%");
         lV23TFProveedorDireccion = StringUtil.Concat( StringUtil.RTrim( AV23TFProveedorDireccion), "%", "");
         lV25TFProveedorEmail = StringUtil.Concat( StringUtil.RTrim( AV25TFProveedorEmail), "%", "");
         /* Using cursor P00664 */
         pr_default.execute(2, new Object[] {AV54DocumentacionId, AV11TFProveedorID, AV12TFProveedorID_To, AV13TFProveedoresTipoId, AV14TFProveedoresTipoId_To, lV15TFProveedoresTipoNombre, AV16TFProveedoresTipoNombre_Sel, lV17TFProveedorNombre, AV18TFProveedorNombre_Sel, lV19TFProveedorDocIdentidad, AV20TFProveedorDocIdentidad_Sel, lV21TFProveedorTelefono, AV22TFProveedorTelefono_Sel, lV23TFProveedorDireccion, AV24TFProveedorDireccion_Sel, lV25TFProveedorEmail, AV26TFProveedorEmail_Sel});
         while ( (pr_default.getStatus(2) != 101) )
         {
            BRK666 = false;
            A488DocumentacionId = P00664_A488DocumentacionId[0];
            n488DocumentacionId = P00664_n488DocumentacionId[0];
            A338ProveedorDocIdentidad = P00664_A338ProveedorDocIdentidad[0];
            A440ProveedorPagoDefault = P00664_A440ProveedorPagoDefault[0];
            A344ProveedorEstado = P00664_A344ProveedorEstado[0];
            A433ProveedorEmail = P00664_A433ProveedorEmail[0];
            n433ProveedorEmail = P00664_n433ProveedorEmail[0];
            A431ProveedorDireccion = P00664_A431ProveedorDireccion[0];
            n431ProveedorDireccion = P00664_n431ProveedorDireccion[0];
            A430ProveedorTelefono = P00664_A430ProveedorTelefono[0];
            n430ProveedorTelefono = P00664_n430ProveedorTelefono[0];
            A282ProveedorNombre = P00664_A282ProveedorNombre[0];
            A278ProveedoresTipoNombre = P00664_A278ProveedoresTipoNombre[0];
            A151ProveedoresTipoId = P00664_A151ProveedoresTipoId[0];
            A133ProveedorID = P00664_A133ProveedorID[0];
            A278ProveedoresTipoNombre = P00664_A278ProveedoresTipoNombre[0];
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV53FilterFullText)) || ( ( StringUtil.Like( StringUtil.Str( (decimal)(A133ProveedorID), 18, 0) , StringUtil.PadR( "%" + AV53FilterFullText , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Str( (decimal)(A151ProveedoresTipoId), 18, 0) , StringUtil.PadR( "%" + AV53FilterFullText , 254 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Upper( A278ProveedoresTipoNombre) , StringUtil.PadR( "%" + StringUtil.Upper( AV53FilterFullText) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A282ProveedorNombre) , StringUtil.PadR( "%" + StringUtil.Upper( AV53FilterFullText) , 255 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Upper( A338ProveedorDocIdentidad) , StringUtil.PadR( "%" + StringUtil.Upper( AV53FilterFullText) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A430ProveedorTelefono) , StringUtil.PadR( "%" + StringUtil.Upper( AV53FilterFullText) , 255 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Upper( A431ProveedorDireccion) , StringUtil.PadR( "%" + StringUtil.Upper( AV53FilterFullText) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A433ProveedorEmail) , StringUtil.PadR( "%" + StringUtil.Upper( AV53FilterFullText) , 255 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( context.GetMessage( "habilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV53FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A344ProveedorEstado, "HAB") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "deshabilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV53FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A344ProveedorEstado, "DES") ==
            0 ) ) || ( StringUtil.Like( context.GetMessage( "pendiente", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV53FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A344ProveedorEstado, "PEN") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "cobro directo", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV53FilterFullText) , 255 , "%"),  ' ' ) &&
            ( StringUtil.StrCmp(A440ProveedorPagoDefault, "F") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "cobro prepago comercio", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV53FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A440ProveedorPagoDefault, "T") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "cobro prepago almango", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV53FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A440ProveedorPagoDefault, "O") == 0 ) ) )
            )
            {
               AV41count = 0;
               while ( (pr_default.getStatus(2) != 101) && ( P00664_A488DocumentacionId[0] == A488DocumentacionId ) && ( StringUtil.StrCmp(P00664_A338ProveedorDocIdentidad[0], A338ProveedorDocIdentidad) == 0 ) )
               {
                  BRK666 = false;
                  A133ProveedorID = P00664_A133ProveedorID[0];
                  AV41count = (long)(AV41count+1);
                  BRK666 = true;
                  pr_default.readNext(2);
               }
               if ( (0==AV32SkipItems) )
               {
                  AV36Option = (String.IsNullOrEmpty(StringUtil.RTrim( A338ProveedorDocIdentidad)) ? "<#Empty#>" : A338ProveedorDocIdentidad);
                  AV37Options.Add(AV36Option, 0);
                  AV40OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV41count), "Z,ZZZ,ZZZ,ZZ9")), 0);
                  if ( AV37Options.Count == 10 )
                  {
                     /* Exit For each command. Update data (if necessary), close cursors & exit. */
                     if (true) break;
                  }
               }
               else
               {
                  AV32SkipItems = (short)(AV32SkipItems-1);
               }
            }
            if ( ! BRK666 )
            {
               BRK666 = true;
               pr_default.readNext(2);
            }
         }
         pr_default.close(2);
      }

      protected void S151( )
      {
         /* 'LOADPROVEEDORTELEFONOOPTIONS' Routine */
         returnInSub = false;
         AV21TFProveedorTelefono = AV31SearchTxt;
         AV22TFProveedorTelefono_Sel = "";
         pr_default.dynParam(3, new Object[]{ new Object[]{
                                              A344ProveedorEstado ,
                                              AV28TFProveedorEstado_Sels ,
                                              A440ProveedorPagoDefault ,
                                              AV30TFProveedorPagoDefault_Sels ,
                                              AV11TFProveedorID ,
                                              AV12TFProveedorID_To ,
                                              AV13TFProveedoresTipoId ,
                                              AV14TFProveedoresTipoId_To ,
                                              AV16TFProveedoresTipoNombre_Sel ,
                                              AV15TFProveedoresTipoNombre ,
                                              AV18TFProveedorNombre_Sel ,
                                              AV17TFProveedorNombre ,
                                              AV20TFProveedorDocIdentidad_Sel ,
                                              AV19TFProveedorDocIdentidad ,
                                              AV22TFProveedorTelefono_Sel ,
                                              AV21TFProveedorTelefono ,
                                              AV24TFProveedorDireccion_Sel ,
                                              AV23TFProveedorDireccion ,
                                              AV26TFProveedorEmail_Sel ,
                                              AV25TFProveedorEmail ,
                                              AV28TFProveedorEstado_Sels.Count ,
                                              AV30TFProveedorPagoDefault_Sels.Count ,
                                              A133ProveedorID ,
                                              A151ProveedoresTipoId ,
                                              A278ProveedoresTipoNombre ,
                                              A282ProveedorNombre ,
                                              A338ProveedorDocIdentidad ,
                                              A430ProveedorTelefono ,
                                              A431ProveedorDireccion ,
                                              A433ProveedorEmail ,
                                              AV53FilterFullText ,
                                              AV54DocumentacionId ,
                                              A488DocumentacionId } ,
                                              new int[]{
                                              TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.INT, TypeConstants.INT, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN,
                                              TypeConstants.BOOLEAN, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.BOOLEAN
                                              }
         });
         lV15TFProveedoresTipoNombre = StringUtil.PadR( StringUtil.RTrim( AV15TFProveedoresTipoNombre), 120, "%");
         lV17TFProveedorNombre = StringUtil.PadR( StringUtil.RTrim( AV17TFProveedorNombre), 80, "%");
         lV19TFProveedorDocIdentidad = StringUtil.PadR( StringUtil.RTrim( AV19TFProveedorDocIdentidad), 25, "%");
         lV21TFProveedorTelefono = StringUtil.PadR( StringUtil.RTrim( AV21TFProveedorTelefono), 20, "%");
         lV23TFProveedorDireccion = StringUtil.Concat( StringUtil.RTrim( AV23TFProveedorDireccion), "%", "");
         lV25TFProveedorEmail = StringUtil.Concat( StringUtil.RTrim( AV25TFProveedorEmail), "%", "");
         /* Using cursor P00665 */
         pr_default.execute(3, new Object[] {AV54DocumentacionId, AV11TFProveedorID, AV12TFProveedorID_To, AV13TFProveedoresTipoId, AV14TFProveedoresTipoId_To, lV15TFProveedoresTipoNombre, AV16TFProveedoresTipoNombre_Sel, lV17TFProveedorNombre, AV18TFProveedorNombre_Sel, lV19TFProveedorDocIdentidad, AV20TFProveedorDocIdentidad_Sel, lV21TFProveedorTelefono, AV22TFProveedorTelefono_Sel, lV23TFProveedorDireccion, AV24TFProveedorDireccion_Sel, lV25TFProveedorEmail, AV26TFProveedorEmail_Sel});
         while ( (pr_default.getStatus(3) != 101) )
         {
            BRK668 = false;
            A488DocumentacionId = P00665_A488DocumentacionId[0];
            n488DocumentacionId = P00665_n488DocumentacionId[0];
            A430ProveedorTelefono = P00665_A430ProveedorTelefono[0];
            n430ProveedorTelefono = P00665_n430ProveedorTelefono[0];
            A440ProveedorPagoDefault = P00665_A440ProveedorPagoDefault[0];
            A344ProveedorEstado = P00665_A344ProveedorEstado[0];
            A433ProveedorEmail = P00665_A433ProveedorEmail[0];
            n433ProveedorEmail = P00665_n433ProveedorEmail[0];
            A431ProveedorDireccion = P00665_A431ProveedorDireccion[0];
            n431ProveedorDireccion = P00665_n431ProveedorDireccion[0];
            A338ProveedorDocIdentidad = P00665_A338ProveedorDocIdentidad[0];
            A282ProveedorNombre = P00665_A282ProveedorNombre[0];
            A278ProveedoresTipoNombre = P00665_A278ProveedoresTipoNombre[0];
            A151ProveedoresTipoId = P00665_A151ProveedoresTipoId[0];
            A133ProveedorID = P00665_A133ProveedorID[0];
            A278ProveedoresTipoNombre = P00665_A278ProveedoresTipoNombre[0];
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV53FilterFullText)) || ( ( StringUtil.Like( StringUtil.Str( (decimal)(A133ProveedorID), 18, 0) , StringUtil.PadR( "%" + AV53FilterFullText , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Str( (decimal)(A151ProveedoresTipoId), 18, 0) , StringUtil.PadR( "%" + AV53FilterFullText , 254 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Upper( A278ProveedoresTipoNombre) , StringUtil.PadR( "%" + StringUtil.Upper( AV53FilterFullText) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A282ProveedorNombre) , StringUtil.PadR( "%" + StringUtil.Upper( AV53FilterFullText) , 255 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Upper( A338ProveedorDocIdentidad) , StringUtil.PadR( "%" + StringUtil.Upper( AV53FilterFullText) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A430ProveedorTelefono) , StringUtil.PadR( "%" + StringUtil.Upper( AV53FilterFullText) , 255 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Upper( A431ProveedorDireccion) , StringUtil.PadR( "%" + StringUtil.Upper( AV53FilterFullText) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A433ProveedorEmail) , StringUtil.PadR( "%" + StringUtil.Upper( AV53FilterFullText) , 255 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( context.GetMessage( "habilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV53FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A344ProveedorEstado, "HAB") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "deshabilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV53FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A344ProveedorEstado, "DES") ==
            0 ) ) || ( StringUtil.Like( context.GetMessage( "pendiente", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV53FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A344ProveedorEstado, "PEN") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "cobro directo", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV53FilterFullText) , 255 , "%"),  ' ' ) &&
            ( StringUtil.StrCmp(A440ProveedorPagoDefault, "F") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "cobro prepago comercio", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV53FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A440ProveedorPagoDefault, "T") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "cobro prepago almango", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV53FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A440ProveedorPagoDefault, "O") == 0 ) ) )
            )
            {
               AV41count = 0;
               while ( (pr_default.getStatus(3) != 101) && ( P00665_A488DocumentacionId[0] == A488DocumentacionId ) && ( StringUtil.StrCmp(P00665_A430ProveedorTelefono[0], A430ProveedorTelefono) == 0 ) )
               {
                  BRK668 = false;
                  A133ProveedorID = P00665_A133ProveedorID[0];
                  AV41count = (long)(AV41count+1);
                  BRK668 = true;
                  pr_default.readNext(3);
               }
               if ( (0==AV32SkipItems) )
               {
                  AV36Option = (String.IsNullOrEmpty(StringUtil.RTrim( A430ProveedorTelefono)) ? "<#Empty#>" : A430ProveedorTelefono);
                  AV37Options.Add(AV36Option, 0);
                  AV40OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV41count), "Z,ZZZ,ZZZ,ZZ9")), 0);
                  if ( AV37Options.Count == 10 )
                  {
                     /* Exit For each command. Update data (if necessary), close cursors & exit. */
                     if (true) break;
                  }
               }
               else
               {
                  AV32SkipItems = (short)(AV32SkipItems-1);
               }
            }
            if ( ! BRK668 )
            {
               BRK668 = true;
               pr_default.readNext(3);
            }
         }
         pr_default.close(3);
      }

      protected void S161( )
      {
         /* 'LOADPROVEEDORDIRECCIONOPTIONS' Routine */
         returnInSub = false;
         AV23TFProveedorDireccion = AV31SearchTxt;
         AV24TFProveedorDireccion_Sel = "";
         pr_default.dynParam(4, new Object[]{ new Object[]{
                                              A344ProveedorEstado ,
                                              AV28TFProveedorEstado_Sels ,
                                              A440ProveedorPagoDefault ,
                                              AV30TFProveedorPagoDefault_Sels ,
                                              AV11TFProveedorID ,
                                              AV12TFProveedorID_To ,
                                              AV13TFProveedoresTipoId ,
                                              AV14TFProveedoresTipoId_To ,
                                              AV16TFProveedoresTipoNombre_Sel ,
                                              AV15TFProveedoresTipoNombre ,
                                              AV18TFProveedorNombre_Sel ,
                                              AV17TFProveedorNombre ,
                                              AV20TFProveedorDocIdentidad_Sel ,
                                              AV19TFProveedorDocIdentidad ,
                                              AV22TFProveedorTelefono_Sel ,
                                              AV21TFProveedorTelefono ,
                                              AV24TFProveedorDireccion_Sel ,
                                              AV23TFProveedorDireccion ,
                                              AV26TFProveedorEmail_Sel ,
                                              AV25TFProveedorEmail ,
                                              AV28TFProveedorEstado_Sels.Count ,
                                              AV30TFProveedorPagoDefault_Sels.Count ,
                                              A133ProveedorID ,
                                              A151ProveedoresTipoId ,
                                              A278ProveedoresTipoNombre ,
                                              A282ProveedorNombre ,
                                              A338ProveedorDocIdentidad ,
                                              A430ProveedorTelefono ,
                                              A431ProveedorDireccion ,
                                              A433ProveedorEmail ,
                                              AV53FilterFullText ,
                                              AV54DocumentacionId ,
                                              A488DocumentacionId } ,
                                              new int[]{
                                              TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.INT, TypeConstants.INT, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN,
                                              TypeConstants.BOOLEAN, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.BOOLEAN
                                              }
         });
         lV15TFProveedoresTipoNombre = StringUtil.PadR( StringUtil.RTrim( AV15TFProveedoresTipoNombre), 120, "%");
         lV17TFProveedorNombre = StringUtil.PadR( StringUtil.RTrim( AV17TFProveedorNombre), 80, "%");
         lV19TFProveedorDocIdentidad = StringUtil.PadR( StringUtil.RTrim( AV19TFProveedorDocIdentidad), 25, "%");
         lV21TFProveedorTelefono = StringUtil.PadR( StringUtil.RTrim( AV21TFProveedorTelefono), 20, "%");
         lV23TFProveedorDireccion = StringUtil.Concat( StringUtil.RTrim( AV23TFProveedorDireccion), "%", "");
         lV25TFProveedorEmail = StringUtil.Concat( StringUtil.RTrim( AV25TFProveedorEmail), "%", "");
         /* Using cursor P00666 */
         pr_default.execute(4, new Object[] {AV54DocumentacionId, AV11TFProveedorID, AV12TFProveedorID_To, AV13TFProveedoresTipoId, AV14TFProveedoresTipoId_To, lV15TFProveedoresTipoNombre, AV16TFProveedoresTipoNombre_Sel, lV17TFProveedorNombre, AV18TFProveedorNombre_Sel, lV19TFProveedorDocIdentidad, AV20TFProveedorDocIdentidad_Sel, lV21TFProveedorTelefono, AV22TFProveedorTelefono_Sel, lV23TFProveedorDireccion, AV24TFProveedorDireccion_Sel, lV25TFProveedorEmail, AV26TFProveedorEmail_Sel});
         while ( (pr_default.getStatus(4) != 101) )
         {
            BRK6610 = false;
            A488DocumentacionId = P00666_A488DocumentacionId[0];
            n488DocumentacionId = P00666_n488DocumentacionId[0];
            A431ProveedorDireccion = P00666_A431ProveedorDireccion[0];
            n431ProveedorDireccion = P00666_n431ProveedorDireccion[0];
            A440ProveedorPagoDefault = P00666_A440ProveedorPagoDefault[0];
            A344ProveedorEstado = P00666_A344ProveedorEstado[0];
            A433ProveedorEmail = P00666_A433ProveedorEmail[0];
            n433ProveedorEmail = P00666_n433ProveedorEmail[0];
            A430ProveedorTelefono = P00666_A430ProveedorTelefono[0];
            n430ProveedorTelefono = P00666_n430ProveedorTelefono[0];
            A338ProveedorDocIdentidad = P00666_A338ProveedorDocIdentidad[0];
            A282ProveedorNombre = P00666_A282ProveedorNombre[0];
            A278ProveedoresTipoNombre = P00666_A278ProveedoresTipoNombre[0];
            A151ProveedoresTipoId = P00666_A151ProveedoresTipoId[0];
            A133ProveedorID = P00666_A133ProveedorID[0];
            A278ProveedoresTipoNombre = P00666_A278ProveedoresTipoNombre[0];
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV53FilterFullText)) || ( ( StringUtil.Like( StringUtil.Str( (decimal)(A133ProveedorID), 18, 0) , StringUtil.PadR( "%" + AV53FilterFullText , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Str( (decimal)(A151ProveedoresTipoId), 18, 0) , StringUtil.PadR( "%" + AV53FilterFullText , 254 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Upper( A278ProveedoresTipoNombre) , StringUtil.PadR( "%" + StringUtil.Upper( AV53FilterFullText) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A282ProveedorNombre) , StringUtil.PadR( "%" + StringUtil.Upper( AV53FilterFullText) , 255 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Upper( A338ProveedorDocIdentidad) , StringUtil.PadR( "%" + StringUtil.Upper( AV53FilterFullText) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A430ProveedorTelefono) , StringUtil.PadR( "%" + StringUtil.Upper( AV53FilterFullText) , 255 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Upper( A431ProveedorDireccion) , StringUtil.PadR( "%" + StringUtil.Upper( AV53FilterFullText) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A433ProveedorEmail) , StringUtil.PadR( "%" + StringUtil.Upper( AV53FilterFullText) , 255 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( context.GetMessage( "habilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV53FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A344ProveedorEstado, "HAB") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "deshabilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV53FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A344ProveedorEstado, "DES") ==
            0 ) ) || ( StringUtil.Like( context.GetMessage( "pendiente", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV53FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A344ProveedorEstado, "PEN") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "cobro directo", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV53FilterFullText) , 255 , "%"),  ' ' ) &&
            ( StringUtil.StrCmp(A440ProveedorPagoDefault, "F") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "cobro prepago comercio", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV53FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A440ProveedorPagoDefault, "T") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "cobro prepago almango", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV53FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A440ProveedorPagoDefault, "O") == 0 ) ) )
            )
            {
               AV41count = 0;
               while ( (pr_default.getStatus(4) != 101) && ( P00666_A488DocumentacionId[0] == A488DocumentacionId ) && ( StringUtil.StrCmp(P00666_A431ProveedorDireccion[0], A431ProveedorDireccion) == 0 ) )
               {
                  BRK6610 = false;
                  A133ProveedorID = P00666_A133ProveedorID[0];
                  AV41count = (long)(AV41count+1);
                  BRK6610 = true;
                  pr_default.readNext(4);
               }
               if ( (0==AV32SkipItems) )
               {
                  AV36Option = (String.IsNullOrEmpty(StringUtil.RTrim( A431ProveedorDireccion)) ? "<#Empty#>" : A431ProveedorDireccion);
                  AV37Options.Add(AV36Option, 0);
                  AV40OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV41count), "Z,ZZZ,ZZZ,ZZ9")), 0);
                  if ( AV37Options.Count == 10 )
                  {
                     /* Exit For each command. Update data (if necessary), close cursors & exit. */
                     if (true) break;
                  }
               }
               else
               {
                  AV32SkipItems = (short)(AV32SkipItems-1);
               }
            }
            if ( ! BRK6610 )
            {
               BRK6610 = true;
               pr_default.readNext(4);
            }
         }
         pr_default.close(4);
      }

      protected void S171( )
      {
         /* 'LOADPROVEEDOREMAILOPTIONS' Routine */
         returnInSub = false;
         AV25TFProveedorEmail = AV31SearchTxt;
         AV26TFProveedorEmail_Sel = "";
         pr_default.dynParam(5, new Object[]{ new Object[]{
                                              A344ProveedorEstado ,
                                              AV28TFProveedorEstado_Sels ,
                                              A440ProveedorPagoDefault ,
                                              AV30TFProveedorPagoDefault_Sels ,
                                              AV11TFProveedorID ,
                                              AV12TFProveedorID_To ,
                                              AV13TFProveedoresTipoId ,
                                              AV14TFProveedoresTipoId_To ,
                                              AV16TFProveedoresTipoNombre_Sel ,
                                              AV15TFProveedoresTipoNombre ,
                                              AV18TFProveedorNombre_Sel ,
                                              AV17TFProveedorNombre ,
                                              AV20TFProveedorDocIdentidad_Sel ,
                                              AV19TFProveedorDocIdentidad ,
                                              AV22TFProveedorTelefono_Sel ,
                                              AV21TFProveedorTelefono ,
                                              AV24TFProveedorDireccion_Sel ,
                                              AV23TFProveedorDireccion ,
                                              AV26TFProveedorEmail_Sel ,
                                              AV25TFProveedorEmail ,
                                              AV28TFProveedorEstado_Sels.Count ,
                                              AV30TFProveedorPagoDefault_Sels.Count ,
                                              A133ProveedorID ,
                                              A151ProveedoresTipoId ,
                                              A278ProveedoresTipoNombre ,
                                              A282ProveedorNombre ,
                                              A338ProveedorDocIdentidad ,
                                              A430ProveedorTelefono ,
                                              A431ProveedorDireccion ,
                                              A433ProveedorEmail ,
                                              AV53FilterFullText ,
                                              AV54DocumentacionId ,
                                              A488DocumentacionId } ,
                                              new int[]{
                                              TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.INT, TypeConstants.INT, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN,
                                              TypeConstants.BOOLEAN, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.BOOLEAN
                                              }
         });
         lV15TFProveedoresTipoNombre = StringUtil.PadR( StringUtil.RTrim( AV15TFProveedoresTipoNombre), 120, "%");
         lV17TFProveedorNombre = StringUtil.PadR( StringUtil.RTrim( AV17TFProveedorNombre), 80, "%");
         lV19TFProveedorDocIdentidad = StringUtil.PadR( StringUtil.RTrim( AV19TFProveedorDocIdentidad), 25, "%");
         lV21TFProveedorTelefono = StringUtil.PadR( StringUtil.RTrim( AV21TFProveedorTelefono), 20, "%");
         lV23TFProveedorDireccion = StringUtil.Concat( StringUtil.RTrim( AV23TFProveedorDireccion), "%", "");
         lV25TFProveedorEmail = StringUtil.Concat( StringUtil.RTrim( AV25TFProveedorEmail), "%", "");
         /* Using cursor P00667 */
         pr_default.execute(5, new Object[] {AV54DocumentacionId, AV11TFProveedorID, AV12TFProveedorID_To, AV13TFProveedoresTipoId, AV14TFProveedoresTipoId_To, lV15TFProveedoresTipoNombre, AV16TFProveedoresTipoNombre_Sel, lV17TFProveedorNombre, AV18TFProveedorNombre_Sel, lV19TFProveedorDocIdentidad, AV20TFProveedorDocIdentidad_Sel, lV21TFProveedorTelefono, AV22TFProveedorTelefono_Sel, lV23TFProveedorDireccion, AV24TFProveedorDireccion_Sel, lV25TFProveedorEmail, AV26TFProveedorEmail_Sel});
         while ( (pr_default.getStatus(5) != 101) )
         {
            BRK6612 = false;
            A488DocumentacionId = P00667_A488DocumentacionId[0];
            n488DocumentacionId = P00667_n488DocumentacionId[0];
            A433ProveedorEmail = P00667_A433ProveedorEmail[0];
            n433ProveedorEmail = P00667_n433ProveedorEmail[0];
            A440ProveedorPagoDefault = P00667_A440ProveedorPagoDefault[0];
            A344ProveedorEstado = P00667_A344ProveedorEstado[0];
            A431ProveedorDireccion = P00667_A431ProveedorDireccion[0];
            n431ProveedorDireccion = P00667_n431ProveedorDireccion[0];
            A430ProveedorTelefono = P00667_A430ProveedorTelefono[0];
            n430ProveedorTelefono = P00667_n430ProveedorTelefono[0];
            A338ProveedorDocIdentidad = P00667_A338ProveedorDocIdentidad[0];
            A282ProveedorNombre = P00667_A282ProveedorNombre[0];
            A278ProveedoresTipoNombre = P00667_A278ProveedoresTipoNombre[0];
            A151ProveedoresTipoId = P00667_A151ProveedoresTipoId[0];
            A133ProveedorID = P00667_A133ProveedorID[0];
            A278ProveedoresTipoNombre = P00667_A278ProveedoresTipoNombre[0];
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV53FilterFullText)) || ( ( StringUtil.Like( StringUtil.Str( (decimal)(A133ProveedorID), 18, 0) , StringUtil.PadR( "%" + AV53FilterFullText , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Str( (decimal)(A151ProveedoresTipoId), 18, 0) , StringUtil.PadR( "%" + AV53FilterFullText , 254 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Upper( A278ProveedoresTipoNombre) , StringUtil.PadR( "%" + StringUtil.Upper( AV53FilterFullText) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A282ProveedorNombre) , StringUtil.PadR( "%" + StringUtil.Upper( AV53FilterFullText) , 255 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Upper( A338ProveedorDocIdentidad) , StringUtil.PadR( "%" + StringUtil.Upper( AV53FilterFullText) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A430ProveedorTelefono) , StringUtil.PadR( "%" + StringUtil.Upper( AV53FilterFullText) , 255 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Upper( A431ProveedorDireccion) , StringUtil.PadR( "%" + StringUtil.Upper( AV53FilterFullText) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A433ProveedorEmail) , StringUtil.PadR( "%" + StringUtil.Upper( AV53FilterFullText) , 255 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( context.GetMessage( "habilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV53FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A344ProveedorEstado, "HAB") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "deshabilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV53FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A344ProveedorEstado, "DES") ==
            0 ) ) || ( StringUtil.Like( context.GetMessage( "pendiente", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV53FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A344ProveedorEstado, "PEN") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "cobro directo", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV53FilterFullText) , 255 , "%"),  ' ' ) &&
            ( StringUtil.StrCmp(A440ProveedorPagoDefault, "F") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "cobro prepago comercio", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV53FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A440ProveedorPagoDefault, "T") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "cobro prepago almango", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV53FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A440ProveedorPagoDefault, "O") == 0 ) ) )
            )
            {
               AV41count = 0;
               while ( (pr_default.getStatus(5) != 101) && ( P00667_A488DocumentacionId[0] == A488DocumentacionId ) && ( StringUtil.StrCmp(P00667_A433ProveedorEmail[0], A433ProveedorEmail) == 0 ) )
               {
                  BRK6612 = false;
                  A133ProveedorID = P00667_A133ProveedorID[0];
                  AV41count = (long)(AV41count+1);
                  BRK6612 = true;
                  pr_default.readNext(5);
               }
               if ( (0==AV32SkipItems) )
               {
                  AV36Option = (String.IsNullOrEmpty(StringUtil.RTrim( A433ProveedorEmail)) ? "<#Empty#>" : A433ProveedorEmail);
                  AV37Options.Add(AV36Option, 0);
                  AV40OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV41count), "Z,ZZZ,ZZZ,ZZ9")), 0);
                  if ( AV37Options.Count == 10 )
                  {
                     /* Exit For each command. Update data (if necessary), close cursors & exit. */
                     if (true) break;
                  }
               }
               else
               {
                  AV32SkipItems = (short)(AV32SkipItems-1);
               }
            }
            if ( ! BRK6612 )
            {
               BRK6612 = true;
               pr_default.readNext(5);
            }
         }
         pr_default.close(5);
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
         AV50OptionsJson = "";
         AV51OptionsDescJson = "";
         AV52OptionIndexesJson = "";
         AV37Options = new GxSimpleCollection<string>();
         AV39OptionsDesc = new GxSimpleCollection<string>();
         AV40OptionIndexes = new GxSimpleCollection<string>();
         AV31SearchTxt = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV42Session = context.GetSession();
         AV44GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV45GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV53FilterFullText = "";
         AV15TFProveedoresTipoNombre = "";
         AV16TFProveedoresTipoNombre_Sel = "";
         AV17TFProveedorNombre = "";
         AV18TFProveedorNombre_Sel = "";
         AV19TFProveedorDocIdentidad = "";
         AV20TFProveedorDocIdentidad_Sel = "";
         AV21TFProveedorTelefono = "";
         AV22TFProveedorTelefono_Sel = "";
         AV23TFProveedorDireccion = "";
         AV24TFProveedorDireccion_Sel = "";
         AV25TFProveedorEmail = "";
         AV26TFProveedorEmail_Sel = "";
         AV27TFProveedorEstado_SelsJson = "";
         AV28TFProveedorEstado_Sels = new GxSimpleCollection<string>();
         AV29TFProveedorPagoDefault_SelsJson = "";
         AV30TFProveedorPagoDefault_Sels = new GxSimpleCollection<string>();
         lV15TFProveedoresTipoNombre = "";
         lV17TFProveedorNombre = "";
         lV19TFProveedorDocIdentidad = "";
         lV21TFProveedorTelefono = "";
         lV23TFProveedorDireccion = "";
         lV25TFProveedorEmail = "";
         A344ProveedorEstado = "";
         A440ProveedorPagoDefault = "";
         A278ProveedoresTipoNombre = "";
         A282ProveedorNombre = "";
         A338ProveedorDocIdentidad = "";
         A430ProveedorTelefono = "";
         A431ProveedorDireccion = "";
         A433ProveedorEmail = "";
         P00662_A488DocumentacionId = new long[1] ;
         P00662_n488DocumentacionId = new bool[] {false} ;
         P00662_A151ProveedoresTipoId = new long[1] ;
         P00662_A440ProveedorPagoDefault = new string[] {""} ;
         P00662_A344ProveedorEstado = new string[] {""} ;
         P00662_A433ProveedorEmail = new string[] {""} ;
         P00662_n433ProveedorEmail = new bool[] {false} ;
         P00662_A431ProveedorDireccion = new string[] {""} ;
         P00662_n431ProveedorDireccion = new bool[] {false} ;
         P00662_A430ProveedorTelefono = new string[] {""} ;
         P00662_n430ProveedorTelefono = new bool[] {false} ;
         P00662_A338ProveedorDocIdentidad = new string[] {""} ;
         P00662_A282ProveedorNombre = new string[] {""} ;
         P00662_A278ProveedoresTipoNombre = new string[] {""} ;
         P00662_A133ProveedorID = new long[1] ;
         AV36Option = "";
         P00663_A488DocumentacionId = new long[1] ;
         P00663_n488DocumentacionId = new bool[] {false} ;
         P00663_A282ProveedorNombre = new string[] {""} ;
         P00663_A440ProveedorPagoDefault = new string[] {""} ;
         P00663_A344ProveedorEstado = new string[] {""} ;
         P00663_A433ProveedorEmail = new string[] {""} ;
         P00663_n433ProveedorEmail = new bool[] {false} ;
         P00663_A431ProveedorDireccion = new string[] {""} ;
         P00663_n431ProveedorDireccion = new bool[] {false} ;
         P00663_A430ProveedorTelefono = new string[] {""} ;
         P00663_n430ProveedorTelefono = new bool[] {false} ;
         P00663_A338ProveedorDocIdentidad = new string[] {""} ;
         P00663_A278ProveedoresTipoNombre = new string[] {""} ;
         P00663_A151ProveedoresTipoId = new long[1] ;
         P00663_A133ProveedorID = new long[1] ;
         P00664_A488DocumentacionId = new long[1] ;
         P00664_n488DocumentacionId = new bool[] {false} ;
         P00664_A338ProveedorDocIdentidad = new string[] {""} ;
         P00664_A440ProveedorPagoDefault = new string[] {""} ;
         P00664_A344ProveedorEstado = new string[] {""} ;
         P00664_A433ProveedorEmail = new string[] {""} ;
         P00664_n433ProveedorEmail = new bool[] {false} ;
         P00664_A431ProveedorDireccion = new string[] {""} ;
         P00664_n431ProveedorDireccion = new bool[] {false} ;
         P00664_A430ProveedorTelefono = new string[] {""} ;
         P00664_n430ProveedorTelefono = new bool[] {false} ;
         P00664_A282ProveedorNombre = new string[] {""} ;
         P00664_A278ProveedoresTipoNombre = new string[] {""} ;
         P00664_A151ProveedoresTipoId = new long[1] ;
         P00664_A133ProveedorID = new long[1] ;
         P00665_A488DocumentacionId = new long[1] ;
         P00665_n488DocumentacionId = new bool[] {false} ;
         P00665_A430ProveedorTelefono = new string[] {""} ;
         P00665_n430ProveedorTelefono = new bool[] {false} ;
         P00665_A440ProveedorPagoDefault = new string[] {""} ;
         P00665_A344ProveedorEstado = new string[] {""} ;
         P00665_A433ProveedorEmail = new string[] {""} ;
         P00665_n433ProveedorEmail = new bool[] {false} ;
         P00665_A431ProveedorDireccion = new string[] {""} ;
         P00665_n431ProveedorDireccion = new bool[] {false} ;
         P00665_A338ProveedorDocIdentidad = new string[] {""} ;
         P00665_A282ProveedorNombre = new string[] {""} ;
         P00665_A278ProveedoresTipoNombre = new string[] {""} ;
         P00665_A151ProveedoresTipoId = new long[1] ;
         P00665_A133ProveedorID = new long[1] ;
         P00666_A488DocumentacionId = new long[1] ;
         P00666_n488DocumentacionId = new bool[] {false} ;
         P00666_A431ProveedorDireccion = new string[] {""} ;
         P00666_n431ProveedorDireccion = new bool[] {false} ;
         P00666_A440ProveedorPagoDefault = new string[] {""} ;
         P00666_A344ProveedorEstado = new string[] {""} ;
         P00666_A433ProveedorEmail = new string[] {""} ;
         P00666_n433ProveedorEmail = new bool[] {false} ;
         P00666_A430ProveedorTelefono = new string[] {""} ;
         P00666_n430ProveedorTelefono = new bool[] {false} ;
         P00666_A338ProveedorDocIdentidad = new string[] {""} ;
         P00666_A282ProveedorNombre = new string[] {""} ;
         P00666_A278ProveedoresTipoNombre = new string[] {""} ;
         P00666_A151ProveedoresTipoId = new long[1] ;
         P00666_A133ProveedorID = new long[1] ;
         P00667_A488DocumentacionId = new long[1] ;
         P00667_n488DocumentacionId = new bool[] {false} ;
         P00667_A433ProveedorEmail = new string[] {""} ;
         P00667_n433ProveedorEmail = new bool[] {false} ;
         P00667_A440ProveedorPagoDefault = new string[] {""} ;
         P00667_A344ProveedorEstado = new string[] {""} ;
         P00667_A431ProveedorDireccion = new string[] {""} ;
         P00667_n431ProveedorDireccion = new bool[] {false} ;
         P00667_A430ProveedorTelefono = new string[] {""} ;
         P00667_n430ProveedorTelefono = new bool[] {false} ;
         P00667_A338ProveedorDocIdentidad = new string[] {""} ;
         P00667_A282ProveedorNombre = new string[] {""} ;
         P00667_A278ProveedoresTipoNombre = new string[] {""} ;
         P00667_A151ProveedoresTipoId = new long[1] ;
         P00667_A133ProveedorID = new long[1] ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.documentacionproveedorwcgetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P00662_A488DocumentacionId, P00662_n488DocumentacionId, P00662_A151ProveedoresTipoId, P00662_A440ProveedorPagoDefault, P00662_A344ProveedorEstado, P00662_A433ProveedorEmail, P00662_n433ProveedorEmail, P00662_A431ProveedorDireccion, P00662_n431ProveedorDireccion, P00662_A430ProveedorTelefono,
               P00662_n430ProveedorTelefono, P00662_A338ProveedorDocIdentidad, P00662_A282ProveedorNombre, P00662_A278ProveedoresTipoNombre, P00662_A133ProveedorID
               }
               , new Object[] {
               P00663_A488DocumentacionId, P00663_n488DocumentacionId, P00663_A282ProveedorNombre, P00663_A440ProveedorPagoDefault, P00663_A344ProveedorEstado, P00663_A433ProveedorEmail, P00663_n433ProveedorEmail, P00663_A431ProveedorDireccion, P00663_n431ProveedorDireccion, P00663_A430ProveedorTelefono,
               P00663_n430ProveedorTelefono, P00663_A338ProveedorDocIdentidad, P00663_A278ProveedoresTipoNombre, P00663_A151ProveedoresTipoId, P00663_A133ProveedorID
               }
               , new Object[] {
               P00664_A488DocumentacionId, P00664_n488DocumentacionId, P00664_A338ProveedorDocIdentidad, P00664_A440ProveedorPagoDefault, P00664_A344ProveedorEstado, P00664_A433ProveedorEmail, P00664_n433ProveedorEmail, P00664_A431ProveedorDireccion, P00664_n431ProveedorDireccion, P00664_A430ProveedorTelefono,
               P00664_n430ProveedorTelefono, P00664_A282ProveedorNombre, P00664_A278ProveedoresTipoNombre, P00664_A151ProveedoresTipoId, P00664_A133ProveedorID
               }
               , new Object[] {
               P00665_A488DocumentacionId, P00665_n488DocumentacionId, P00665_A430ProveedorTelefono, P00665_n430ProveedorTelefono, P00665_A440ProveedorPagoDefault, P00665_A344ProveedorEstado, P00665_A433ProveedorEmail, P00665_n433ProveedorEmail, P00665_A431ProveedorDireccion, P00665_n431ProveedorDireccion,
               P00665_A338ProveedorDocIdentidad, P00665_A282ProveedorNombre, P00665_A278ProveedoresTipoNombre, P00665_A151ProveedoresTipoId, P00665_A133ProveedorID
               }
               , new Object[] {
               P00666_A488DocumentacionId, P00666_n488DocumentacionId, P00666_A431ProveedorDireccion, P00666_n431ProveedorDireccion, P00666_A440ProveedorPagoDefault, P00666_A344ProveedorEstado, P00666_A433ProveedorEmail, P00666_n433ProveedorEmail, P00666_A430ProveedorTelefono, P00666_n430ProveedorTelefono,
               P00666_A338ProveedorDocIdentidad, P00666_A282ProveedorNombre, P00666_A278ProveedoresTipoNombre, P00666_A151ProveedoresTipoId, P00666_A133ProveedorID
               }
               , new Object[] {
               P00667_A488DocumentacionId, P00667_n488DocumentacionId, P00667_A433ProveedorEmail, P00667_n433ProveedorEmail, P00667_A440ProveedorPagoDefault, P00667_A344ProveedorEstado, P00667_A431ProveedorDireccion, P00667_n431ProveedorDireccion, P00667_A430ProveedorTelefono, P00667_n430ProveedorTelefono,
               P00667_A338ProveedorDocIdentidad, P00667_A282ProveedorNombre, P00667_A278ProveedoresTipoNombre, P00667_A151ProveedoresTipoId, P00667_A133ProveedorID
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV34MaxItems ;
      private short AV33PageIndex ;
      private short AV32SkipItems ;
      private int AV55GXV1 ;
      private int AV28TFProveedorEstado_Sels_Count ;
      private int AV30TFProveedorPagoDefault_Sels_Count ;
      private int AV35InsertIndex ;
      private long AV11TFProveedorID ;
      private long AV12TFProveedorID_To ;
      private long AV13TFProveedoresTipoId ;
      private long AV14TFProveedoresTipoId_To ;
      private long AV54DocumentacionId ;
      private long A133ProveedorID ;
      private long A151ProveedoresTipoId ;
      private long A488DocumentacionId ;
      private long AV41count ;
      private string AV15TFProveedoresTipoNombre ;
      private string AV16TFProveedoresTipoNombre_Sel ;
      private string AV17TFProveedorNombre ;
      private string AV18TFProveedorNombre_Sel ;
      private string AV19TFProveedorDocIdentidad ;
      private string AV20TFProveedorDocIdentidad_Sel ;
      private string AV21TFProveedorTelefono ;
      private string AV22TFProveedorTelefono_Sel ;
      private string lV15TFProveedoresTipoNombre ;
      private string lV17TFProveedorNombre ;
      private string lV19TFProveedorDocIdentidad ;
      private string lV21TFProveedorTelefono ;
      private string A344ProveedorEstado ;
      private string A440ProveedorPagoDefault ;
      private string A278ProveedoresTipoNombre ;
      private string A282ProveedorNombre ;
      private string A338ProveedorDocIdentidad ;
      private string A430ProveedorTelefono ;
      private bool AV8IsAuthorized ;
      private bool GXt_boolean1 ;
      private bool returnInSub ;
      private bool BRK662 ;
      private bool n488DocumentacionId ;
      private bool n433ProveedorEmail ;
      private bool n431ProveedorDireccion ;
      private bool n430ProveedorTelefono ;
      private bool BRK664 ;
      private bool BRK666 ;
      private bool BRK668 ;
      private bool BRK6610 ;
      private bool BRK6612 ;
      private string AV50OptionsJson ;
      private string AV51OptionsDescJson ;
      private string AV52OptionIndexesJson ;
      private string AV27TFProveedorEstado_SelsJson ;
      private string AV29TFProveedorPagoDefault_SelsJson ;
      private string AV47DDOName ;
      private string AV48SearchTxtParms ;
      private string AV49SearchTxtTo ;
      private string AV31SearchTxt ;
      private string AV53FilterFullText ;
      private string AV23TFProveedorDireccion ;
      private string AV24TFProveedorDireccion_Sel ;
      private string AV25TFProveedorEmail ;
      private string AV26TFProveedorEmail_Sel ;
      private string lV23TFProveedorDireccion ;
      private string lV25TFProveedorEmail ;
      private string A431ProveedorDireccion ;
      private string A433ProveedorEmail ;
      private string AV36Option ;
      private IGxSession AV42Session ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GxSimpleCollection<string> AV37Options ;
      private GxSimpleCollection<string> AV39OptionsDesc ;
      private GxSimpleCollection<string> AV40OptionIndexes ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV44GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV45GridStateFilterValue ;
      private GxSimpleCollection<string> AV28TFProveedorEstado_Sels ;
      private GxSimpleCollection<string> AV30TFProveedorPagoDefault_Sels ;
      private IDataStoreProvider pr_default ;
      private long[] P00662_A488DocumentacionId ;
      private bool[] P00662_n488DocumentacionId ;
      private long[] P00662_A151ProveedoresTipoId ;
      private string[] P00662_A440ProveedorPagoDefault ;
      private string[] P00662_A344ProveedorEstado ;
      private string[] P00662_A433ProveedorEmail ;
      private bool[] P00662_n433ProveedorEmail ;
      private string[] P00662_A431ProveedorDireccion ;
      private bool[] P00662_n431ProveedorDireccion ;
      private string[] P00662_A430ProveedorTelefono ;
      private bool[] P00662_n430ProveedorTelefono ;
      private string[] P00662_A338ProveedorDocIdentidad ;
      private string[] P00662_A282ProveedorNombre ;
      private string[] P00662_A278ProveedoresTipoNombre ;
      private long[] P00662_A133ProveedorID ;
      private long[] P00663_A488DocumentacionId ;
      private bool[] P00663_n488DocumentacionId ;
      private string[] P00663_A282ProveedorNombre ;
      private string[] P00663_A440ProveedorPagoDefault ;
      private string[] P00663_A344ProveedorEstado ;
      private string[] P00663_A433ProveedorEmail ;
      private bool[] P00663_n433ProveedorEmail ;
      private string[] P00663_A431ProveedorDireccion ;
      private bool[] P00663_n431ProveedorDireccion ;
      private string[] P00663_A430ProveedorTelefono ;
      private bool[] P00663_n430ProveedorTelefono ;
      private string[] P00663_A338ProveedorDocIdentidad ;
      private string[] P00663_A278ProveedoresTipoNombre ;
      private long[] P00663_A151ProveedoresTipoId ;
      private long[] P00663_A133ProveedorID ;
      private long[] P00664_A488DocumentacionId ;
      private bool[] P00664_n488DocumentacionId ;
      private string[] P00664_A338ProveedorDocIdentidad ;
      private string[] P00664_A440ProveedorPagoDefault ;
      private string[] P00664_A344ProveedorEstado ;
      private string[] P00664_A433ProveedorEmail ;
      private bool[] P00664_n433ProveedorEmail ;
      private string[] P00664_A431ProveedorDireccion ;
      private bool[] P00664_n431ProveedorDireccion ;
      private string[] P00664_A430ProveedorTelefono ;
      private bool[] P00664_n430ProveedorTelefono ;
      private string[] P00664_A282ProveedorNombre ;
      private string[] P00664_A278ProveedoresTipoNombre ;
      private long[] P00664_A151ProveedoresTipoId ;
      private long[] P00664_A133ProveedorID ;
      private long[] P00665_A488DocumentacionId ;
      private bool[] P00665_n488DocumentacionId ;
      private string[] P00665_A430ProveedorTelefono ;
      private bool[] P00665_n430ProveedorTelefono ;
      private string[] P00665_A440ProveedorPagoDefault ;
      private string[] P00665_A344ProveedorEstado ;
      private string[] P00665_A433ProveedorEmail ;
      private bool[] P00665_n433ProveedorEmail ;
      private string[] P00665_A431ProveedorDireccion ;
      private bool[] P00665_n431ProveedorDireccion ;
      private string[] P00665_A338ProveedorDocIdentidad ;
      private string[] P00665_A282ProveedorNombre ;
      private string[] P00665_A278ProveedoresTipoNombre ;
      private long[] P00665_A151ProveedoresTipoId ;
      private long[] P00665_A133ProveedorID ;
      private long[] P00666_A488DocumentacionId ;
      private bool[] P00666_n488DocumentacionId ;
      private string[] P00666_A431ProveedorDireccion ;
      private bool[] P00666_n431ProveedorDireccion ;
      private string[] P00666_A440ProveedorPagoDefault ;
      private string[] P00666_A344ProveedorEstado ;
      private string[] P00666_A433ProveedorEmail ;
      private bool[] P00666_n433ProveedorEmail ;
      private string[] P00666_A430ProveedorTelefono ;
      private bool[] P00666_n430ProveedorTelefono ;
      private string[] P00666_A338ProveedorDocIdentidad ;
      private string[] P00666_A282ProveedorNombre ;
      private string[] P00666_A278ProveedoresTipoNombre ;
      private long[] P00666_A151ProveedoresTipoId ;
      private long[] P00666_A133ProveedorID ;
      private long[] P00667_A488DocumentacionId ;
      private bool[] P00667_n488DocumentacionId ;
      private string[] P00667_A433ProveedorEmail ;
      private bool[] P00667_n433ProveedorEmail ;
      private string[] P00667_A440ProveedorPagoDefault ;
      private string[] P00667_A344ProveedorEstado ;
      private string[] P00667_A431ProveedorDireccion ;
      private bool[] P00667_n431ProveedorDireccion ;
      private string[] P00667_A430ProveedorTelefono ;
      private bool[] P00667_n430ProveedorTelefono ;
      private string[] P00667_A338ProveedorDocIdentidad ;
      private string[] P00667_A282ProveedorNombre ;
      private string[] P00667_A278ProveedoresTipoNombre ;
      private long[] P00667_A151ProveedoresTipoId ;
      private long[] P00667_A133ProveedorID ;
      private string aP3_OptionsJson ;
      private string aP4_OptionsDescJson ;
      private string aP5_OptionIndexesJson ;
   }

   public class documentacionproveedorwcgetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00662( IGxContext context ,
                                             string A344ProveedorEstado ,
                                             GxSimpleCollection<string> AV28TFProveedorEstado_Sels ,
                                             string A440ProveedorPagoDefault ,
                                             GxSimpleCollection<string> AV30TFProveedorPagoDefault_Sels ,
                                             long AV11TFProveedorID ,
                                             long AV12TFProveedorID_To ,
                                             long AV13TFProveedoresTipoId ,
                                             long AV14TFProveedoresTipoId_To ,
                                             string AV16TFProveedoresTipoNombre_Sel ,
                                             string AV15TFProveedoresTipoNombre ,
                                             string AV18TFProveedorNombre_Sel ,
                                             string AV17TFProveedorNombre ,
                                             string AV20TFProveedorDocIdentidad_Sel ,
                                             string AV19TFProveedorDocIdentidad ,
                                             string AV22TFProveedorTelefono_Sel ,
                                             string AV21TFProveedorTelefono ,
                                             string AV24TFProveedorDireccion_Sel ,
                                             string AV23TFProveedorDireccion ,
                                             string AV26TFProveedorEmail_Sel ,
                                             string AV25TFProveedorEmail ,
                                             int AV28TFProveedorEstado_Sels_Count ,
                                             int AV30TFProveedorPagoDefault_Sels_Count ,
                                             long A133ProveedorID ,
                                             long A151ProveedoresTipoId ,
                                             string A278ProveedoresTipoNombre ,
                                             string A282ProveedorNombre ,
                                             string A338ProveedorDocIdentidad ,
                                             string A430ProveedorTelefono ,
                                             string A431ProveedorDireccion ,
                                             string A433ProveedorEmail ,
                                             string AV53FilterFullText ,
                                             long AV54DocumentacionId ,
                                             long A488DocumentacionId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int2 = new short[17];
         Object[] GXv_Object3 = new Object[2];
         scmdbuf = "SELECT T1.[DocumentacionId], T1.[ProveedoresTipoId], T1.[ProveedorPagoDefault], T1.[ProveedorEstado], T1.[ProveedorEmail], T1.[ProveedorDireccion], T1.[ProveedorTelefono], T1.[ProveedorDocIdentidad], T1.[ProveedorNombre], T2.[ProveedoresTipoNombre], T1.[ProveedorID] FROM ([Proveedor] T1 INNER JOIN [ProveedoresTipo] T2 ON T2.[ProveedoresTipoId] = T1.[ProveedoresTipoId])";
         AddWhere(sWhereString, "(T1.[DocumentacionId] = @AV54DocumentacionId)");
         if ( ! (0==AV11TFProveedorID) )
         {
            AddWhere(sWhereString, "(T1.[ProveedorID] >= @AV11TFProveedorID)");
         }
         else
         {
            GXv_int2[1] = 1;
         }
         if ( ! (0==AV12TFProveedorID_To) )
         {
            AddWhere(sWhereString, "(T1.[ProveedorID] <= @AV12TFProveedorID_To)");
         }
         else
         {
            GXv_int2[2] = 1;
         }
         if ( ! (0==AV13TFProveedoresTipoId) )
         {
            AddWhere(sWhereString, "(T1.[ProveedoresTipoId] >= @AV13TFProveedoresTipoId)");
         }
         else
         {
            GXv_int2[3] = 1;
         }
         if ( ! (0==AV14TFProveedoresTipoId_To) )
         {
            AddWhere(sWhereString, "(T1.[ProveedoresTipoId] <= @AV14TFProveedoresTipoId_To)");
         }
         else
         {
            GXv_int2[4] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV16TFProveedoresTipoNombre_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV15TFProveedoresTipoNombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ProveedoresTipoNombre]) like UPPER(@lV15TFProveedoresTipoNombre))");
         }
         else
         {
            GXv_int2[5] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV16TFProveedoresTipoNombre_Sel)) && ! ( StringUtil.StrCmp(AV16TFProveedoresTipoNombre_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.[ProveedoresTipoNombre] = @AV16TFProveedoresTipoNombre_Sel)");
         }
         else
         {
            GXv_int2[6] = 1;
         }
         if ( StringUtil.StrCmp(AV16TFProveedoresTipoNombre_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T2.[ProveedoresTipoNombre] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV18TFProveedorNombre_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV17TFProveedorNombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[ProveedorNombre]) like UPPER(@lV17TFProveedorNombre))");
         }
         else
         {
            GXv_int2[7] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV18TFProveedorNombre_Sel)) && ! ( StringUtil.StrCmp(AV18TFProveedorNombre_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[ProveedorNombre] = @AV18TFProveedorNombre_Sel)");
         }
         else
         {
            GXv_int2[8] = 1;
         }
         if ( StringUtil.StrCmp(AV18TFProveedorNombre_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[ProveedorNombre] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV20TFProveedorDocIdentidad_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV19TFProveedorDocIdentidad)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[ProveedorDocIdentidad]) like UPPER(@lV19TFProveedorDocIdentidad))");
         }
         else
         {
            GXv_int2[9] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV20TFProveedorDocIdentidad_Sel)) && ! ( StringUtil.StrCmp(AV20TFProveedorDocIdentidad_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[ProveedorDocIdentidad] = @AV20TFProveedorDocIdentidad_Sel)");
         }
         else
         {
            GXv_int2[10] = 1;
         }
         if ( StringUtil.StrCmp(AV20TFProveedorDocIdentidad_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[ProveedorDocIdentidad] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV22TFProveedorTelefono_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV21TFProveedorTelefono)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[ProveedorTelefono]) like UPPER(@lV21TFProveedorTelefono))");
         }
         else
         {
            GXv_int2[11] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV22TFProveedorTelefono_Sel)) && ! ( StringUtil.StrCmp(AV22TFProveedorTelefono_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[ProveedorTelefono] = @AV22TFProveedorTelefono_Sel)");
         }
         else
         {
            GXv_int2[12] = 1;
         }
         if ( StringUtil.StrCmp(AV22TFProveedorTelefono_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.[ProveedorTelefono] IS NULL or (T1.[ProveedorTelefono] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV24TFProveedorDireccion_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV23TFProveedorDireccion)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[ProveedorDireccion]) like UPPER(@lV23TFProveedorDireccion))");
         }
         else
         {
            GXv_int2[13] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV24TFProveedorDireccion_Sel)) && ! ( StringUtil.StrCmp(AV24TFProveedorDireccion_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[ProveedorDireccion] = @AV24TFProveedorDireccion_Sel)");
         }
         else
         {
            GXv_int2[14] = 1;
         }
         if ( StringUtil.StrCmp(AV24TFProveedorDireccion_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.[ProveedorDireccion] IS NULL or (T1.[ProveedorDireccion] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV26TFProveedorEmail_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV25TFProveedorEmail)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[ProveedorEmail]) like UPPER(@lV25TFProveedorEmail))");
         }
         else
         {
            GXv_int2[15] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV26TFProveedorEmail_Sel)) && ! ( StringUtil.StrCmp(AV26TFProveedorEmail_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[ProveedorEmail] = @AV26TFProveedorEmail_Sel)");
         }
         else
         {
            GXv_int2[16] = 1;
         }
         if ( StringUtil.StrCmp(AV26TFProveedorEmail_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.[ProveedorEmail] IS NULL or (T1.[ProveedorEmail] = ''))");
         }
         if ( AV28TFProveedorEstado_Sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV28TFProveedorEstado_Sels, "T1.[ProveedorEstado] IN (", ")")+")");
         }
         if ( AV30TFProveedorPagoDefault_Sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV30TFProveedorPagoDefault_Sels, "T1.[ProveedorPagoDefault] IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[DocumentacionId], T1.[ProveedoresTipoId]";
         GXv_Object3[0] = scmdbuf;
         GXv_Object3[1] = GXv_int2;
         return GXv_Object3 ;
      }

      protected Object[] conditional_P00663( IGxContext context ,
                                             string A344ProveedorEstado ,
                                             GxSimpleCollection<string> AV28TFProveedorEstado_Sels ,
                                             string A440ProveedorPagoDefault ,
                                             GxSimpleCollection<string> AV30TFProveedorPagoDefault_Sels ,
                                             long AV11TFProveedorID ,
                                             long AV12TFProveedorID_To ,
                                             long AV13TFProveedoresTipoId ,
                                             long AV14TFProveedoresTipoId_To ,
                                             string AV16TFProveedoresTipoNombre_Sel ,
                                             string AV15TFProveedoresTipoNombre ,
                                             string AV18TFProveedorNombre_Sel ,
                                             string AV17TFProveedorNombre ,
                                             string AV20TFProveedorDocIdentidad_Sel ,
                                             string AV19TFProveedorDocIdentidad ,
                                             string AV22TFProveedorTelefono_Sel ,
                                             string AV21TFProveedorTelefono ,
                                             string AV24TFProveedorDireccion_Sel ,
                                             string AV23TFProveedorDireccion ,
                                             string AV26TFProveedorEmail_Sel ,
                                             string AV25TFProveedorEmail ,
                                             int AV28TFProveedorEstado_Sels_Count ,
                                             int AV30TFProveedorPagoDefault_Sels_Count ,
                                             long A133ProveedorID ,
                                             long A151ProveedoresTipoId ,
                                             string A278ProveedoresTipoNombre ,
                                             string A282ProveedorNombre ,
                                             string A338ProveedorDocIdentidad ,
                                             string A430ProveedorTelefono ,
                                             string A431ProveedorDireccion ,
                                             string A433ProveedorEmail ,
                                             string AV53FilterFullText ,
                                             long AV54DocumentacionId ,
                                             long A488DocumentacionId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int4 = new short[17];
         Object[] GXv_Object5 = new Object[2];
         scmdbuf = "SELECT T1.[DocumentacionId], T1.[ProveedorNombre], T1.[ProveedorPagoDefault], T1.[ProveedorEstado], T1.[ProveedorEmail], T1.[ProveedorDireccion], T1.[ProveedorTelefono], T1.[ProveedorDocIdentidad], T2.[ProveedoresTipoNombre], T1.[ProveedoresTipoId], T1.[ProveedorID] FROM ([Proveedor] T1 INNER JOIN [ProveedoresTipo] T2 ON T2.[ProveedoresTipoId] = T1.[ProveedoresTipoId])";
         AddWhere(sWhereString, "(T1.[DocumentacionId] = @AV54DocumentacionId)");
         if ( ! (0==AV11TFProveedorID) )
         {
            AddWhere(sWhereString, "(T1.[ProveedorID] >= @AV11TFProveedorID)");
         }
         else
         {
            GXv_int4[1] = 1;
         }
         if ( ! (0==AV12TFProveedorID_To) )
         {
            AddWhere(sWhereString, "(T1.[ProveedorID] <= @AV12TFProveedorID_To)");
         }
         else
         {
            GXv_int4[2] = 1;
         }
         if ( ! (0==AV13TFProveedoresTipoId) )
         {
            AddWhere(sWhereString, "(T1.[ProveedoresTipoId] >= @AV13TFProveedoresTipoId)");
         }
         else
         {
            GXv_int4[3] = 1;
         }
         if ( ! (0==AV14TFProveedoresTipoId_To) )
         {
            AddWhere(sWhereString, "(T1.[ProveedoresTipoId] <= @AV14TFProveedoresTipoId_To)");
         }
         else
         {
            GXv_int4[4] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV16TFProveedoresTipoNombre_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV15TFProveedoresTipoNombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ProveedoresTipoNombre]) like UPPER(@lV15TFProveedoresTipoNombre))");
         }
         else
         {
            GXv_int4[5] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV16TFProveedoresTipoNombre_Sel)) && ! ( StringUtil.StrCmp(AV16TFProveedoresTipoNombre_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.[ProveedoresTipoNombre] = @AV16TFProveedoresTipoNombre_Sel)");
         }
         else
         {
            GXv_int4[6] = 1;
         }
         if ( StringUtil.StrCmp(AV16TFProveedoresTipoNombre_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T2.[ProveedoresTipoNombre] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV18TFProveedorNombre_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV17TFProveedorNombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[ProveedorNombre]) like UPPER(@lV17TFProveedorNombre))");
         }
         else
         {
            GXv_int4[7] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV18TFProveedorNombre_Sel)) && ! ( StringUtil.StrCmp(AV18TFProveedorNombre_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[ProveedorNombre] = @AV18TFProveedorNombre_Sel)");
         }
         else
         {
            GXv_int4[8] = 1;
         }
         if ( StringUtil.StrCmp(AV18TFProveedorNombre_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[ProveedorNombre] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV20TFProveedorDocIdentidad_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV19TFProveedorDocIdentidad)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[ProveedorDocIdentidad]) like UPPER(@lV19TFProveedorDocIdentidad))");
         }
         else
         {
            GXv_int4[9] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV20TFProveedorDocIdentidad_Sel)) && ! ( StringUtil.StrCmp(AV20TFProveedorDocIdentidad_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[ProveedorDocIdentidad] = @AV20TFProveedorDocIdentidad_Sel)");
         }
         else
         {
            GXv_int4[10] = 1;
         }
         if ( StringUtil.StrCmp(AV20TFProveedorDocIdentidad_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[ProveedorDocIdentidad] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV22TFProveedorTelefono_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV21TFProveedorTelefono)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[ProveedorTelefono]) like UPPER(@lV21TFProveedorTelefono))");
         }
         else
         {
            GXv_int4[11] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV22TFProveedorTelefono_Sel)) && ! ( StringUtil.StrCmp(AV22TFProveedorTelefono_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[ProveedorTelefono] = @AV22TFProveedorTelefono_Sel)");
         }
         else
         {
            GXv_int4[12] = 1;
         }
         if ( StringUtil.StrCmp(AV22TFProveedorTelefono_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.[ProveedorTelefono] IS NULL or (T1.[ProveedorTelefono] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV24TFProveedorDireccion_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV23TFProveedorDireccion)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[ProveedorDireccion]) like UPPER(@lV23TFProveedorDireccion))");
         }
         else
         {
            GXv_int4[13] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV24TFProveedorDireccion_Sel)) && ! ( StringUtil.StrCmp(AV24TFProveedorDireccion_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[ProveedorDireccion] = @AV24TFProveedorDireccion_Sel)");
         }
         else
         {
            GXv_int4[14] = 1;
         }
         if ( StringUtil.StrCmp(AV24TFProveedorDireccion_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.[ProveedorDireccion] IS NULL or (T1.[ProveedorDireccion] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV26TFProveedorEmail_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV25TFProveedorEmail)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[ProveedorEmail]) like UPPER(@lV25TFProveedorEmail))");
         }
         else
         {
            GXv_int4[15] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV26TFProveedorEmail_Sel)) && ! ( StringUtil.StrCmp(AV26TFProveedorEmail_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[ProveedorEmail] = @AV26TFProveedorEmail_Sel)");
         }
         else
         {
            GXv_int4[16] = 1;
         }
         if ( StringUtil.StrCmp(AV26TFProveedorEmail_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.[ProveedorEmail] IS NULL or (T1.[ProveedorEmail] = ''))");
         }
         if ( AV28TFProveedorEstado_Sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV28TFProveedorEstado_Sels, "T1.[ProveedorEstado] IN (", ")")+")");
         }
         if ( AV30TFProveedorPagoDefault_Sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV30TFProveedorPagoDefault_Sels, "T1.[ProveedorPagoDefault] IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[DocumentacionId], T1.[ProveedorNombre]";
         GXv_Object5[0] = scmdbuf;
         GXv_Object5[1] = GXv_int4;
         return GXv_Object5 ;
      }

      protected Object[] conditional_P00664( IGxContext context ,
                                             string A344ProveedorEstado ,
                                             GxSimpleCollection<string> AV28TFProveedorEstado_Sels ,
                                             string A440ProveedorPagoDefault ,
                                             GxSimpleCollection<string> AV30TFProveedorPagoDefault_Sels ,
                                             long AV11TFProveedorID ,
                                             long AV12TFProveedorID_To ,
                                             long AV13TFProveedoresTipoId ,
                                             long AV14TFProveedoresTipoId_To ,
                                             string AV16TFProveedoresTipoNombre_Sel ,
                                             string AV15TFProveedoresTipoNombre ,
                                             string AV18TFProveedorNombre_Sel ,
                                             string AV17TFProveedorNombre ,
                                             string AV20TFProveedorDocIdentidad_Sel ,
                                             string AV19TFProveedorDocIdentidad ,
                                             string AV22TFProveedorTelefono_Sel ,
                                             string AV21TFProveedorTelefono ,
                                             string AV24TFProveedorDireccion_Sel ,
                                             string AV23TFProveedorDireccion ,
                                             string AV26TFProveedorEmail_Sel ,
                                             string AV25TFProveedorEmail ,
                                             int AV28TFProveedorEstado_Sels_Count ,
                                             int AV30TFProveedorPagoDefault_Sels_Count ,
                                             long A133ProveedorID ,
                                             long A151ProveedoresTipoId ,
                                             string A278ProveedoresTipoNombre ,
                                             string A282ProveedorNombre ,
                                             string A338ProveedorDocIdentidad ,
                                             string A430ProveedorTelefono ,
                                             string A431ProveedorDireccion ,
                                             string A433ProveedorEmail ,
                                             string AV53FilterFullText ,
                                             long AV54DocumentacionId ,
                                             long A488DocumentacionId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int6 = new short[17];
         Object[] GXv_Object7 = new Object[2];
         scmdbuf = "SELECT T1.[DocumentacionId], T1.[ProveedorDocIdentidad], T1.[ProveedorPagoDefault], T1.[ProveedorEstado], T1.[ProveedorEmail], T1.[ProveedorDireccion], T1.[ProveedorTelefono], T1.[ProveedorNombre], T2.[ProveedoresTipoNombre], T1.[ProveedoresTipoId], T1.[ProveedorID] FROM ([Proveedor] T1 INNER JOIN [ProveedoresTipo] T2 ON T2.[ProveedoresTipoId] = T1.[ProveedoresTipoId])";
         AddWhere(sWhereString, "(T1.[DocumentacionId] = @AV54DocumentacionId)");
         if ( ! (0==AV11TFProveedorID) )
         {
            AddWhere(sWhereString, "(T1.[ProveedorID] >= @AV11TFProveedorID)");
         }
         else
         {
            GXv_int6[1] = 1;
         }
         if ( ! (0==AV12TFProveedorID_To) )
         {
            AddWhere(sWhereString, "(T1.[ProveedorID] <= @AV12TFProveedorID_To)");
         }
         else
         {
            GXv_int6[2] = 1;
         }
         if ( ! (0==AV13TFProveedoresTipoId) )
         {
            AddWhere(sWhereString, "(T1.[ProveedoresTipoId] >= @AV13TFProveedoresTipoId)");
         }
         else
         {
            GXv_int6[3] = 1;
         }
         if ( ! (0==AV14TFProveedoresTipoId_To) )
         {
            AddWhere(sWhereString, "(T1.[ProveedoresTipoId] <= @AV14TFProveedoresTipoId_To)");
         }
         else
         {
            GXv_int6[4] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV16TFProveedoresTipoNombre_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV15TFProveedoresTipoNombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ProveedoresTipoNombre]) like UPPER(@lV15TFProveedoresTipoNombre))");
         }
         else
         {
            GXv_int6[5] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV16TFProveedoresTipoNombre_Sel)) && ! ( StringUtil.StrCmp(AV16TFProveedoresTipoNombre_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.[ProveedoresTipoNombre] = @AV16TFProveedoresTipoNombre_Sel)");
         }
         else
         {
            GXv_int6[6] = 1;
         }
         if ( StringUtil.StrCmp(AV16TFProveedoresTipoNombre_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T2.[ProveedoresTipoNombre] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV18TFProveedorNombre_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV17TFProveedorNombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[ProveedorNombre]) like UPPER(@lV17TFProveedorNombre))");
         }
         else
         {
            GXv_int6[7] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV18TFProveedorNombre_Sel)) && ! ( StringUtil.StrCmp(AV18TFProveedorNombre_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[ProveedorNombre] = @AV18TFProveedorNombre_Sel)");
         }
         else
         {
            GXv_int6[8] = 1;
         }
         if ( StringUtil.StrCmp(AV18TFProveedorNombre_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[ProveedorNombre] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV20TFProveedorDocIdentidad_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV19TFProveedorDocIdentidad)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[ProveedorDocIdentidad]) like UPPER(@lV19TFProveedorDocIdentidad))");
         }
         else
         {
            GXv_int6[9] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV20TFProveedorDocIdentidad_Sel)) && ! ( StringUtil.StrCmp(AV20TFProveedorDocIdentidad_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[ProveedorDocIdentidad] = @AV20TFProveedorDocIdentidad_Sel)");
         }
         else
         {
            GXv_int6[10] = 1;
         }
         if ( StringUtil.StrCmp(AV20TFProveedorDocIdentidad_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[ProveedorDocIdentidad] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV22TFProveedorTelefono_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV21TFProveedorTelefono)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[ProveedorTelefono]) like UPPER(@lV21TFProveedorTelefono))");
         }
         else
         {
            GXv_int6[11] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV22TFProveedorTelefono_Sel)) && ! ( StringUtil.StrCmp(AV22TFProveedorTelefono_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[ProveedorTelefono] = @AV22TFProveedorTelefono_Sel)");
         }
         else
         {
            GXv_int6[12] = 1;
         }
         if ( StringUtil.StrCmp(AV22TFProveedorTelefono_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.[ProveedorTelefono] IS NULL or (T1.[ProveedorTelefono] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV24TFProveedorDireccion_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV23TFProveedorDireccion)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[ProveedorDireccion]) like UPPER(@lV23TFProveedorDireccion))");
         }
         else
         {
            GXv_int6[13] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV24TFProveedorDireccion_Sel)) && ! ( StringUtil.StrCmp(AV24TFProveedorDireccion_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[ProveedorDireccion] = @AV24TFProveedorDireccion_Sel)");
         }
         else
         {
            GXv_int6[14] = 1;
         }
         if ( StringUtil.StrCmp(AV24TFProveedorDireccion_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.[ProveedorDireccion] IS NULL or (T1.[ProveedorDireccion] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV26TFProveedorEmail_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV25TFProveedorEmail)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[ProveedorEmail]) like UPPER(@lV25TFProveedorEmail))");
         }
         else
         {
            GXv_int6[15] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV26TFProveedorEmail_Sel)) && ! ( StringUtil.StrCmp(AV26TFProveedorEmail_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[ProveedorEmail] = @AV26TFProveedorEmail_Sel)");
         }
         else
         {
            GXv_int6[16] = 1;
         }
         if ( StringUtil.StrCmp(AV26TFProveedorEmail_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.[ProveedorEmail] IS NULL or (T1.[ProveedorEmail] = ''))");
         }
         if ( AV28TFProveedorEstado_Sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV28TFProveedorEstado_Sels, "T1.[ProveedorEstado] IN (", ")")+")");
         }
         if ( AV30TFProveedorPagoDefault_Sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV30TFProveedorPagoDefault_Sels, "T1.[ProveedorPagoDefault] IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[DocumentacionId], T1.[ProveedorDocIdentidad]";
         GXv_Object7[0] = scmdbuf;
         GXv_Object7[1] = GXv_int6;
         return GXv_Object7 ;
      }

      protected Object[] conditional_P00665( IGxContext context ,
                                             string A344ProveedorEstado ,
                                             GxSimpleCollection<string> AV28TFProveedorEstado_Sels ,
                                             string A440ProveedorPagoDefault ,
                                             GxSimpleCollection<string> AV30TFProveedorPagoDefault_Sels ,
                                             long AV11TFProveedorID ,
                                             long AV12TFProveedorID_To ,
                                             long AV13TFProveedoresTipoId ,
                                             long AV14TFProveedoresTipoId_To ,
                                             string AV16TFProveedoresTipoNombre_Sel ,
                                             string AV15TFProveedoresTipoNombre ,
                                             string AV18TFProveedorNombre_Sel ,
                                             string AV17TFProveedorNombre ,
                                             string AV20TFProveedorDocIdentidad_Sel ,
                                             string AV19TFProveedorDocIdentidad ,
                                             string AV22TFProveedorTelefono_Sel ,
                                             string AV21TFProveedorTelefono ,
                                             string AV24TFProveedorDireccion_Sel ,
                                             string AV23TFProveedorDireccion ,
                                             string AV26TFProveedorEmail_Sel ,
                                             string AV25TFProveedorEmail ,
                                             int AV28TFProveedorEstado_Sels_Count ,
                                             int AV30TFProveedorPagoDefault_Sels_Count ,
                                             long A133ProveedorID ,
                                             long A151ProveedoresTipoId ,
                                             string A278ProveedoresTipoNombre ,
                                             string A282ProveedorNombre ,
                                             string A338ProveedorDocIdentidad ,
                                             string A430ProveedorTelefono ,
                                             string A431ProveedorDireccion ,
                                             string A433ProveedorEmail ,
                                             string AV53FilterFullText ,
                                             long AV54DocumentacionId ,
                                             long A488DocumentacionId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int8 = new short[17];
         Object[] GXv_Object9 = new Object[2];
         scmdbuf = "SELECT T1.[DocumentacionId], T1.[ProveedorTelefono], T1.[ProveedorPagoDefault], T1.[ProveedorEstado], T1.[ProveedorEmail], T1.[ProveedorDireccion], T1.[ProveedorDocIdentidad], T1.[ProveedorNombre], T2.[ProveedoresTipoNombre], T1.[ProveedoresTipoId], T1.[ProveedorID] FROM ([Proveedor] T1 INNER JOIN [ProveedoresTipo] T2 ON T2.[ProveedoresTipoId] = T1.[ProveedoresTipoId])";
         AddWhere(sWhereString, "(T1.[DocumentacionId] = @AV54DocumentacionId)");
         if ( ! (0==AV11TFProveedorID) )
         {
            AddWhere(sWhereString, "(T1.[ProveedorID] >= @AV11TFProveedorID)");
         }
         else
         {
            GXv_int8[1] = 1;
         }
         if ( ! (0==AV12TFProveedorID_To) )
         {
            AddWhere(sWhereString, "(T1.[ProveedorID] <= @AV12TFProveedorID_To)");
         }
         else
         {
            GXv_int8[2] = 1;
         }
         if ( ! (0==AV13TFProveedoresTipoId) )
         {
            AddWhere(sWhereString, "(T1.[ProveedoresTipoId] >= @AV13TFProveedoresTipoId)");
         }
         else
         {
            GXv_int8[3] = 1;
         }
         if ( ! (0==AV14TFProveedoresTipoId_To) )
         {
            AddWhere(sWhereString, "(T1.[ProveedoresTipoId] <= @AV14TFProveedoresTipoId_To)");
         }
         else
         {
            GXv_int8[4] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV16TFProveedoresTipoNombre_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV15TFProveedoresTipoNombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ProveedoresTipoNombre]) like UPPER(@lV15TFProveedoresTipoNombre))");
         }
         else
         {
            GXv_int8[5] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV16TFProveedoresTipoNombre_Sel)) && ! ( StringUtil.StrCmp(AV16TFProveedoresTipoNombre_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.[ProveedoresTipoNombre] = @AV16TFProveedoresTipoNombre_Sel)");
         }
         else
         {
            GXv_int8[6] = 1;
         }
         if ( StringUtil.StrCmp(AV16TFProveedoresTipoNombre_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T2.[ProveedoresTipoNombre] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV18TFProveedorNombre_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV17TFProveedorNombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[ProveedorNombre]) like UPPER(@lV17TFProveedorNombre))");
         }
         else
         {
            GXv_int8[7] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV18TFProveedorNombre_Sel)) && ! ( StringUtil.StrCmp(AV18TFProveedorNombre_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[ProveedorNombre] = @AV18TFProveedorNombre_Sel)");
         }
         else
         {
            GXv_int8[8] = 1;
         }
         if ( StringUtil.StrCmp(AV18TFProveedorNombre_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[ProveedorNombre] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV20TFProveedorDocIdentidad_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV19TFProveedorDocIdentidad)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[ProveedorDocIdentidad]) like UPPER(@lV19TFProveedorDocIdentidad))");
         }
         else
         {
            GXv_int8[9] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV20TFProveedorDocIdentidad_Sel)) && ! ( StringUtil.StrCmp(AV20TFProveedorDocIdentidad_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[ProveedorDocIdentidad] = @AV20TFProveedorDocIdentidad_Sel)");
         }
         else
         {
            GXv_int8[10] = 1;
         }
         if ( StringUtil.StrCmp(AV20TFProveedorDocIdentidad_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[ProveedorDocIdentidad] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV22TFProveedorTelefono_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV21TFProveedorTelefono)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[ProveedorTelefono]) like UPPER(@lV21TFProveedorTelefono))");
         }
         else
         {
            GXv_int8[11] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV22TFProveedorTelefono_Sel)) && ! ( StringUtil.StrCmp(AV22TFProveedorTelefono_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[ProveedorTelefono] = @AV22TFProveedorTelefono_Sel)");
         }
         else
         {
            GXv_int8[12] = 1;
         }
         if ( StringUtil.StrCmp(AV22TFProveedorTelefono_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.[ProveedorTelefono] IS NULL or (T1.[ProveedorTelefono] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV24TFProveedorDireccion_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV23TFProveedorDireccion)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[ProveedorDireccion]) like UPPER(@lV23TFProveedorDireccion))");
         }
         else
         {
            GXv_int8[13] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV24TFProveedorDireccion_Sel)) && ! ( StringUtil.StrCmp(AV24TFProveedorDireccion_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[ProveedorDireccion] = @AV24TFProveedorDireccion_Sel)");
         }
         else
         {
            GXv_int8[14] = 1;
         }
         if ( StringUtil.StrCmp(AV24TFProveedorDireccion_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.[ProveedorDireccion] IS NULL or (T1.[ProveedorDireccion] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV26TFProveedorEmail_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV25TFProveedorEmail)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[ProveedorEmail]) like UPPER(@lV25TFProveedorEmail))");
         }
         else
         {
            GXv_int8[15] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV26TFProveedorEmail_Sel)) && ! ( StringUtil.StrCmp(AV26TFProveedorEmail_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[ProveedorEmail] = @AV26TFProveedorEmail_Sel)");
         }
         else
         {
            GXv_int8[16] = 1;
         }
         if ( StringUtil.StrCmp(AV26TFProveedorEmail_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.[ProveedorEmail] IS NULL or (T1.[ProveedorEmail] = ''))");
         }
         if ( AV28TFProveedorEstado_Sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV28TFProveedorEstado_Sels, "T1.[ProveedorEstado] IN (", ")")+")");
         }
         if ( AV30TFProveedorPagoDefault_Sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV30TFProveedorPagoDefault_Sels, "T1.[ProveedorPagoDefault] IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[DocumentacionId], T1.[ProveedorTelefono]";
         GXv_Object9[0] = scmdbuf;
         GXv_Object9[1] = GXv_int8;
         return GXv_Object9 ;
      }

      protected Object[] conditional_P00666( IGxContext context ,
                                             string A344ProveedorEstado ,
                                             GxSimpleCollection<string> AV28TFProveedorEstado_Sels ,
                                             string A440ProveedorPagoDefault ,
                                             GxSimpleCollection<string> AV30TFProveedorPagoDefault_Sels ,
                                             long AV11TFProveedorID ,
                                             long AV12TFProveedorID_To ,
                                             long AV13TFProveedoresTipoId ,
                                             long AV14TFProveedoresTipoId_To ,
                                             string AV16TFProveedoresTipoNombre_Sel ,
                                             string AV15TFProveedoresTipoNombre ,
                                             string AV18TFProveedorNombre_Sel ,
                                             string AV17TFProveedorNombre ,
                                             string AV20TFProveedorDocIdentidad_Sel ,
                                             string AV19TFProveedorDocIdentidad ,
                                             string AV22TFProveedorTelefono_Sel ,
                                             string AV21TFProveedorTelefono ,
                                             string AV24TFProveedorDireccion_Sel ,
                                             string AV23TFProveedorDireccion ,
                                             string AV26TFProveedorEmail_Sel ,
                                             string AV25TFProveedorEmail ,
                                             int AV28TFProveedorEstado_Sels_Count ,
                                             int AV30TFProveedorPagoDefault_Sels_Count ,
                                             long A133ProveedorID ,
                                             long A151ProveedoresTipoId ,
                                             string A278ProveedoresTipoNombre ,
                                             string A282ProveedorNombre ,
                                             string A338ProveedorDocIdentidad ,
                                             string A430ProveedorTelefono ,
                                             string A431ProveedorDireccion ,
                                             string A433ProveedorEmail ,
                                             string AV53FilterFullText ,
                                             long AV54DocumentacionId ,
                                             long A488DocumentacionId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int10 = new short[17];
         Object[] GXv_Object11 = new Object[2];
         scmdbuf = "SELECT T1.[DocumentacionId], T1.[ProveedorDireccion], T1.[ProveedorPagoDefault], T1.[ProveedorEstado], T1.[ProveedorEmail], T1.[ProveedorTelefono], T1.[ProveedorDocIdentidad], T1.[ProveedorNombre], T2.[ProveedoresTipoNombre], T1.[ProveedoresTipoId], T1.[ProveedorID] FROM ([Proveedor] T1 INNER JOIN [ProveedoresTipo] T2 ON T2.[ProveedoresTipoId] = T1.[ProveedoresTipoId])";
         AddWhere(sWhereString, "(T1.[DocumentacionId] = @AV54DocumentacionId)");
         if ( ! (0==AV11TFProveedorID) )
         {
            AddWhere(sWhereString, "(T1.[ProveedorID] >= @AV11TFProveedorID)");
         }
         else
         {
            GXv_int10[1] = 1;
         }
         if ( ! (0==AV12TFProveedorID_To) )
         {
            AddWhere(sWhereString, "(T1.[ProveedorID] <= @AV12TFProveedorID_To)");
         }
         else
         {
            GXv_int10[2] = 1;
         }
         if ( ! (0==AV13TFProveedoresTipoId) )
         {
            AddWhere(sWhereString, "(T1.[ProveedoresTipoId] >= @AV13TFProveedoresTipoId)");
         }
         else
         {
            GXv_int10[3] = 1;
         }
         if ( ! (0==AV14TFProveedoresTipoId_To) )
         {
            AddWhere(sWhereString, "(T1.[ProveedoresTipoId] <= @AV14TFProveedoresTipoId_To)");
         }
         else
         {
            GXv_int10[4] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV16TFProveedoresTipoNombre_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV15TFProveedoresTipoNombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ProveedoresTipoNombre]) like UPPER(@lV15TFProveedoresTipoNombre))");
         }
         else
         {
            GXv_int10[5] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV16TFProveedoresTipoNombre_Sel)) && ! ( StringUtil.StrCmp(AV16TFProveedoresTipoNombre_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.[ProveedoresTipoNombre] = @AV16TFProveedoresTipoNombre_Sel)");
         }
         else
         {
            GXv_int10[6] = 1;
         }
         if ( StringUtil.StrCmp(AV16TFProveedoresTipoNombre_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T2.[ProveedoresTipoNombre] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV18TFProveedorNombre_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV17TFProveedorNombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[ProveedorNombre]) like UPPER(@lV17TFProveedorNombre))");
         }
         else
         {
            GXv_int10[7] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV18TFProveedorNombre_Sel)) && ! ( StringUtil.StrCmp(AV18TFProveedorNombre_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[ProveedorNombre] = @AV18TFProveedorNombre_Sel)");
         }
         else
         {
            GXv_int10[8] = 1;
         }
         if ( StringUtil.StrCmp(AV18TFProveedorNombre_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[ProveedorNombre] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV20TFProveedorDocIdentidad_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV19TFProveedorDocIdentidad)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[ProveedorDocIdentidad]) like UPPER(@lV19TFProveedorDocIdentidad))");
         }
         else
         {
            GXv_int10[9] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV20TFProveedorDocIdentidad_Sel)) && ! ( StringUtil.StrCmp(AV20TFProveedorDocIdentidad_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[ProveedorDocIdentidad] = @AV20TFProveedorDocIdentidad_Sel)");
         }
         else
         {
            GXv_int10[10] = 1;
         }
         if ( StringUtil.StrCmp(AV20TFProveedorDocIdentidad_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[ProveedorDocIdentidad] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV22TFProveedorTelefono_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV21TFProveedorTelefono)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[ProveedorTelefono]) like UPPER(@lV21TFProveedorTelefono))");
         }
         else
         {
            GXv_int10[11] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV22TFProveedorTelefono_Sel)) && ! ( StringUtil.StrCmp(AV22TFProveedorTelefono_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[ProveedorTelefono] = @AV22TFProveedorTelefono_Sel)");
         }
         else
         {
            GXv_int10[12] = 1;
         }
         if ( StringUtil.StrCmp(AV22TFProveedorTelefono_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.[ProveedorTelefono] IS NULL or (T1.[ProveedorTelefono] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV24TFProveedorDireccion_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV23TFProveedorDireccion)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[ProveedorDireccion]) like UPPER(@lV23TFProveedorDireccion))");
         }
         else
         {
            GXv_int10[13] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV24TFProveedorDireccion_Sel)) && ! ( StringUtil.StrCmp(AV24TFProveedorDireccion_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[ProveedorDireccion] = @AV24TFProveedorDireccion_Sel)");
         }
         else
         {
            GXv_int10[14] = 1;
         }
         if ( StringUtil.StrCmp(AV24TFProveedorDireccion_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.[ProveedorDireccion] IS NULL or (T1.[ProveedorDireccion] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV26TFProveedorEmail_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV25TFProveedorEmail)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[ProveedorEmail]) like UPPER(@lV25TFProveedorEmail))");
         }
         else
         {
            GXv_int10[15] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV26TFProveedorEmail_Sel)) && ! ( StringUtil.StrCmp(AV26TFProveedorEmail_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[ProveedorEmail] = @AV26TFProveedorEmail_Sel)");
         }
         else
         {
            GXv_int10[16] = 1;
         }
         if ( StringUtil.StrCmp(AV26TFProveedorEmail_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.[ProveedorEmail] IS NULL or (T1.[ProveedorEmail] = ''))");
         }
         if ( AV28TFProveedorEstado_Sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV28TFProveedorEstado_Sels, "T1.[ProveedorEstado] IN (", ")")+")");
         }
         if ( AV30TFProveedorPagoDefault_Sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV30TFProveedorPagoDefault_Sels, "T1.[ProveedorPagoDefault] IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[DocumentacionId], T1.[ProveedorDireccion]";
         GXv_Object11[0] = scmdbuf;
         GXv_Object11[1] = GXv_int10;
         return GXv_Object11 ;
      }

      protected Object[] conditional_P00667( IGxContext context ,
                                             string A344ProveedorEstado ,
                                             GxSimpleCollection<string> AV28TFProveedorEstado_Sels ,
                                             string A440ProveedorPagoDefault ,
                                             GxSimpleCollection<string> AV30TFProveedorPagoDefault_Sels ,
                                             long AV11TFProveedorID ,
                                             long AV12TFProveedorID_To ,
                                             long AV13TFProveedoresTipoId ,
                                             long AV14TFProveedoresTipoId_To ,
                                             string AV16TFProveedoresTipoNombre_Sel ,
                                             string AV15TFProveedoresTipoNombre ,
                                             string AV18TFProveedorNombre_Sel ,
                                             string AV17TFProveedorNombre ,
                                             string AV20TFProveedorDocIdentidad_Sel ,
                                             string AV19TFProveedorDocIdentidad ,
                                             string AV22TFProveedorTelefono_Sel ,
                                             string AV21TFProveedorTelefono ,
                                             string AV24TFProveedorDireccion_Sel ,
                                             string AV23TFProveedorDireccion ,
                                             string AV26TFProveedorEmail_Sel ,
                                             string AV25TFProveedorEmail ,
                                             int AV28TFProveedorEstado_Sels_Count ,
                                             int AV30TFProveedorPagoDefault_Sels_Count ,
                                             long A133ProveedorID ,
                                             long A151ProveedoresTipoId ,
                                             string A278ProveedoresTipoNombre ,
                                             string A282ProveedorNombre ,
                                             string A338ProveedorDocIdentidad ,
                                             string A430ProveedorTelefono ,
                                             string A431ProveedorDireccion ,
                                             string A433ProveedorEmail ,
                                             string AV53FilterFullText ,
                                             long AV54DocumentacionId ,
                                             long A488DocumentacionId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int12 = new short[17];
         Object[] GXv_Object13 = new Object[2];
         scmdbuf = "SELECT T1.[DocumentacionId], T1.[ProveedorEmail], T1.[ProveedorPagoDefault], T1.[ProveedorEstado], T1.[ProveedorDireccion], T1.[ProveedorTelefono], T1.[ProveedorDocIdentidad], T1.[ProveedorNombre], T2.[ProveedoresTipoNombre], T1.[ProveedoresTipoId], T1.[ProveedorID] FROM ([Proveedor] T1 INNER JOIN [ProveedoresTipo] T2 ON T2.[ProveedoresTipoId] = T1.[ProveedoresTipoId])";
         AddWhere(sWhereString, "(T1.[DocumentacionId] = @AV54DocumentacionId)");
         if ( ! (0==AV11TFProveedorID) )
         {
            AddWhere(sWhereString, "(T1.[ProveedorID] >= @AV11TFProveedorID)");
         }
         else
         {
            GXv_int12[1] = 1;
         }
         if ( ! (0==AV12TFProveedorID_To) )
         {
            AddWhere(sWhereString, "(T1.[ProveedorID] <= @AV12TFProveedorID_To)");
         }
         else
         {
            GXv_int12[2] = 1;
         }
         if ( ! (0==AV13TFProveedoresTipoId) )
         {
            AddWhere(sWhereString, "(T1.[ProveedoresTipoId] >= @AV13TFProveedoresTipoId)");
         }
         else
         {
            GXv_int12[3] = 1;
         }
         if ( ! (0==AV14TFProveedoresTipoId_To) )
         {
            AddWhere(sWhereString, "(T1.[ProveedoresTipoId] <= @AV14TFProveedoresTipoId_To)");
         }
         else
         {
            GXv_int12[4] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV16TFProveedoresTipoNombre_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV15TFProveedoresTipoNombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ProveedoresTipoNombre]) like UPPER(@lV15TFProveedoresTipoNombre))");
         }
         else
         {
            GXv_int12[5] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV16TFProveedoresTipoNombre_Sel)) && ! ( StringUtil.StrCmp(AV16TFProveedoresTipoNombre_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.[ProveedoresTipoNombre] = @AV16TFProveedoresTipoNombre_Sel)");
         }
         else
         {
            GXv_int12[6] = 1;
         }
         if ( StringUtil.StrCmp(AV16TFProveedoresTipoNombre_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T2.[ProveedoresTipoNombre] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV18TFProveedorNombre_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV17TFProveedorNombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[ProveedorNombre]) like UPPER(@lV17TFProveedorNombre))");
         }
         else
         {
            GXv_int12[7] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV18TFProveedorNombre_Sel)) && ! ( StringUtil.StrCmp(AV18TFProveedorNombre_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[ProveedorNombre] = @AV18TFProveedorNombre_Sel)");
         }
         else
         {
            GXv_int12[8] = 1;
         }
         if ( StringUtil.StrCmp(AV18TFProveedorNombre_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[ProveedorNombre] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV20TFProveedorDocIdentidad_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV19TFProveedorDocIdentidad)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[ProveedorDocIdentidad]) like UPPER(@lV19TFProveedorDocIdentidad))");
         }
         else
         {
            GXv_int12[9] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV20TFProveedorDocIdentidad_Sel)) && ! ( StringUtil.StrCmp(AV20TFProveedorDocIdentidad_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[ProveedorDocIdentidad] = @AV20TFProveedorDocIdentidad_Sel)");
         }
         else
         {
            GXv_int12[10] = 1;
         }
         if ( StringUtil.StrCmp(AV20TFProveedorDocIdentidad_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[ProveedorDocIdentidad] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV22TFProveedorTelefono_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV21TFProveedorTelefono)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[ProveedorTelefono]) like UPPER(@lV21TFProveedorTelefono))");
         }
         else
         {
            GXv_int12[11] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV22TFProveedorTelefono_Sel)) && ! ( StringUtil.StrCmp(AV22TFProveedorTelefono_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[ProveedorTelefono] = @AV22TFProveedorTelefono_Sel)");
         }
         else
         {
            GXv_int12[12] = 1;
         }
         if ( StringUtil.StrCmp(AV22TFProveedorTelefono_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.[ProveedorTelefono] IS NULL or (T1.[ProveedorTelefono] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV24TFProveedorDireccion_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV23TFProveedorDireccion)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[ProveedorDireccion]) like UPPER(@lV23TFProveedorDireccion))");
         }
         else
         {
            GXv_int12[13] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV24TFProveedorDireccion_Sel)) && ! ( StringUtil.StrCmp(AV24TFProveedorDireccion_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[ProveedorDireccion] = @AV24TFProveedorDireccion_Sel)");
         }
         else
         {
            GXv_int12[14] = 1;
         }
         if ( StringUtil.StrCmp(AV24TFProveedorDireccion_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.[ProveedorDireccion] IS NULL or (T1.[ProveedorDireccion] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV26TFProveedorEmail_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV25TFProveedorEmail)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[ProveedorEmail]) like UPPER(@lV25TFProveedorEmail))");
         }
         else
         {
            GXv_int12[15] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV26TFProveedorEmail_Sel)) && ! ( StringUtil.StrCmp(AV26TFProveedorEmail_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[ProveedorEmail] = @AV26TFProveedorEmail_Sel)");
         }
         else
         {
            GXv_int12[16] = 1;
         }
         if ( StringUtil.StrCmp(AV26TFProveedorEmail_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.[ProveedorEmail] IS NULL or (T1.[ProveedorEmail] = ''))");
         }
         if ( AV28TFProveedorEstado_Sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV28TFProveedorEstado_Sels, "T1.[ProveedorEstado] IN (", ")")+")");
         }
         if ( AV30TFProveedorPagoDefault_Sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV30TFProveedorPagoDefault_Sels, "T1.[ProveedorPagoDefault] IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[DocumentacionId], T1.[ProveedorEmail]";
         GXv_Object13[0] = scmdbuf;
         GXv_Object13[1] = GXv_int12;
         return GXv_Object13 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_P00662(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (GxSimpleCollection<string>)dynConstraints[3] , (long)dynConstraints[4] , (long)dynConstraints[5] , (long)dynConstraints[6] , (long)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (int)dynConstraints[20] , (int)dynConstraints[21] , (long)dynConstraints[22] , (long)dynConstraints[23] , (string)dynConstraints[24] , (string)dynConstraints[25] , (string)dynConstraints[26] , (string)dynConstraints[27] , (string)dynConstraints[28] , (string)dynConstraints[29] , (string)dynConstraints[30] , (long)dynConstraints[31] , (long)dynConstraints[32] );
               case 1 :
                     return conditional_P00663(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (GxSimpleCollection<string>)dynConstraints[3] , (long)dynConstraints[4] , (long)dynConstraints[5] , (long)dynConstraints[6] , (long)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (int)dynConstraints[20] , (int)dynConstraints[21] , (long)dynConstraints[22] , (long)dynConstraints[23] , (string)dynConstraints[24] , (string)dynConstraints[25] , (string)dynConstraints[26] , (string)dynConstraints[27] , (string)dynConstraints[28] , (string)dynConstraints[29] , (string)dynConstraints[30] , (long)dynConstraints[31] , (long)dynConstraints[32] );
               case 2 :
                     return conditional_P00664(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (GxSimpleCollection<string>)dynConstraints[3] , (long)dynConstraints[4] , (long)dynConstraints[5] , (long)dynConstraints[6] , (long)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (int)dynConstraints[20] , (int)dynConstraints[21] , (long)dynConstraints[22] , (long)dynConstraints[23] , (string)dynConstraints[24] , (string)dynConstraints[25] , (string)dynConstraints[26] , (string)dynConstraints[27] , (string)dynConstraints[28] , (string)dynConstraints[29] , (string)dynConstraints[30] , (long)dynConstraints[31] , (long)dynConstraints[32] );
               case 3 :
                     return conditional_P00665(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (GxSimpleCollection<string>)dynConstraints[3] , (long)dynConstraints[4] , (long)dynConstraints[5] , (long)dynConstraints[6] , (long)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (int)dynConstraints[20] , (int)dynConstraints[21] , (long)dynConstraints[22] , (long)dynConstraints[23] , (string)dynConstraints[24] , (string)dynConstraints[25] , (string)dynConstraints[26] , (string)dynConstraints[27] , (string)dynConstraints[28] , (string)dynConstraints[29] , (string)dynConstraints[30] , (long)dynConstraints[31] , (long)dynConstraints[32] );
               case 4 :
                     return conditional_P00666(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (GxSimpleCollection<string>)dynConstraints[3] , (long)dynConstraints[4] , (long)dynConstraints[5] , (long)dynConstraints[6] , (long)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (int)dynConstraints[20] , (int)dynConstraints[21] , (long)dynConstraints[22] , (long)dynConstraints[23] , (string)dynConstraints[24] , (string)dynConstraints[25] , (string)dynConstraints[26] , (string)dynConstraints[27] , (string)dynConstraints[28] , (string)dynConstraints[29] , (string)dynConstraints[30] , (long)dynConstraints[31] , (long)dynConstraints[32] );
               case 5 :
                     return conditional_P00667(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (GxSimpleCollection<string>)dynConstraints[3] , (long)dynConstraints[4] , (long)dynConstraints[5] , (long)dynConstraints[6] , (long)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (int)dynConstraints[20] , (int)dynConstraints[21] , (long)dynConstraints[22] , (long)dynConstraints[23] , (string)dynConstraints[24] , (string)dynConstraints[25] , (string)dynConstraints[26] , (string)dynConstraints[27] , (string)dynConstraints[28] , (string)dynConstraints[29] , (string)dynConstraints[30] , (long)dynConstraints[31] , (long)dynConstraints[32] );
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
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP00662;
          prmP00662 = new Object[] {
          new ParDef("@AV54DocumentacionId",GXType.Decimal,18,0) ,
          new ParDef("@AV11TFProveedorID",GXType.Decimal,18,0) ,
          new ParDef("@AV12TFProveedorID_To",GXType.Decimal,18,0) ,
          new ParDef("@AV13TFProveedoresTipoId",GXType.Decimal,18,0) ,
          new ParDef("@AV14TFProveedoresTipoId_To",GXType.Decimal,18,0) ,
          new ParDef("@lV15TFProveedoresTipoNombre",GXType.Char,120,0) ,
          new ParDef("@AV16TFProveedoresTipoNombre_Sel",GXType.NChar,120,0) ,
          new ParDef("@lV17TFProveedorNombre",GXType.Char,80,0) ,
          new ParDef("@AV18TFProveedorNombre_Sel",GXType.NChar,80,0) ,
          new ParDef("@lV19TFProveedorDocIdentidad",GXType.Char,25,0) ,
          new ParDef("@AV20TFProveedorDocIdentidad_Sel",GXType.NChar,25,0) ,
          new ParDef("@lV21TFProveedorTelefono",GXType.Char,20,0) ,
          new ParDef("@AV22TFProveedorTelefono_Sel",GXType.NChar,20,0) ,
          new ParDef("@lV23TFProveedorDireccion",GXType.VarChar,1024,0) ,
          new ParDef("@AV24TFProveedorDireccion_Sel",GXType.NVarChar,1024,0) ,
          new ParDef("@lV25TFProveedorEmail",GXType.VarChar,100,0) ,
          new ParDef("@AV26TFProveedorEmail_Sel",GXType.NVarChar,100,0)
          };
          Object[] prmP00663;
          prmP00663 = new Object[] {
          new ParDef("@AV54DocumentacionId",GXType.Decimal,18,0) ,
          new ParDef("@AV11TFProveedorID",GXType.Decimal,18,0) ,
          new ParDef("@AV12TFProveedorID_To",GXType.Decimal,18,0) ,
          new ParDef("@AV13TFProveedoresTipoId",GXType.Decimal,18,0) ,
          new ParDef("@AV14TFProveedoresTipoId_To",GXType.Decimal,18,0) ,
          new ParDef("@lV15TFProveedoresTipoNombre",GXType.Char,120,0) ,
          new ParDef("@AV16TFProveedoresTipoNombre_Sel",GXType.NChar,120,0) ,
          new ParDef("@lV17TFProveedorNombre",GXType.Char,80,0) ,
          new ParDef("@AV18TFProveedorNombre_Sel",GXType.NChar,80,0) ,
          new ParDef("@lV19TFProveedorDocIdentidad",GXType.Char,25,0) ,
          new ParDef("@AV20TFProveedorDocIdentidad_Sel",GXType.NChar,25,0) ,
          new ParDef("@lV21TFProveedorTelefono",GXType.Char,20,0) ,
          new ParDef("@AV22TFProveedorTelefono_Sel",GXType.NChar,20,0) ,
          new ParDef("@lV23TFProveedorDireccion",GXType.VarChar,1024,0) ,
          new ParDef("@AV24TFProveedorDireccion_Sel",GXType.NVarChar,1024,0) ,
          new ParDef("@lV25TFProveedorEmail",GXType.VarChar,100,0) ,
          new ParDef("@AV26TFProveedorEmail_Sel",GXType.NVarChar,100,0)
          };
          Object[] prmP00664;
          prmP00664 = new Object[] {
          new ParDef("@AV54DocumentacionId",GXType.Decimal,18,0) ,
          new ParDef("@AV11TFProveedorID",GXType.Decimal,18,0) ,
          new ParDef("@AV12TFProveedorID_To",GXType.Decimal,18,0) ,
          new ParDef("@AV13TFProveedoresTipoId",GXType.Decimal,18,0) ,
          new ParDef("@AV14TFProveedoresTipoId_To",GXType.Decimal,18,0) ,
          new ParDef("@lV15TFProveedoresTipoNombre",GXType.Char,120,0) ,
          new ParDef("@AV16TFProveedoresTipoNombre_Sel",GXType.NChar,120,0) ,
          new ParDef("@lV17TFProveedorNombre",GXType.Char,80,0) ,
          new ParDef("@AV18TFProveedorNombre_Sel",GXType.NChar,80,0) ,
          new ParDef("@lV19TFProveedorDocIdentidad",GXType.Char,25,0) ,
          new ParDef("@AV20TFProveedorDocIdentidad_Sel",GXType.NChar,25,0) ,
          new ParDef("@lV21TFProveedorTelefono",GXType.Char,20,0) ,
          new ParDef("@AV22TFProveedorTelefono_Sel",GXType.NChar,20,0) ,
          new ParDef("@lV23TFProveedorDireccion",GXType.VarChar,1024,0) ,
          new ParDef("@AV24TFProveedorDireccion_Sel",GXType.NVarChar,1024,0) ,
          new ParDef("@lV25TFProveedorEmail",GXType.VarChar,100,0) ,
          new ParDef("@AV26TFProveedorEmail_Sel",GXType.NVarChar,100,0)
          };
          Object[] prmP00665;
          prmP00665 = new Object[] {
          new ParDef("@AV54DocumentacionId",GXType.Decimal,18,0) ,
          new ParDef("@AV11TFProveedorID",GXType.Decimal,18,0) ,
          new ParDef("@AV12TFProveedorID_To",GXType.Decimal,18,0) ,
          new ParDef("@AV13TFProveedoresTipoId",GXType.Decimal,18,0) ,
          new ParDef("@AV14TFProveedoresTipoId_To",GXType.Decimal,18,0) ,
          new ParDef("@lV15TFProveedoresTipoNombre",GXType.Char,120,0) ,
          new ParDef("@AV16TFProveedoresTipoNombre_Sel",GXType.NChar,120,0) ,
          new ParDef("@lV17TFProveedorNombre",GXType.Char,80,0) ,
          new ParDef("@AV18TFProveedorNombre_Sel",GXType.NChar,80,0) ,
          new ParDef("@lV19TFProveedorDocIdentidad",GXType.Char,25,0) ,
          new ParDef("@AV20TFProveedorDocIdentidad_Sel",GXType.NChar,25,0) ,
          new ParDef("@lV21TFProveedorTelefono",GXType.Char,20,0) ,
          new ParDef("@AV22TFProveedorTelefono_Sel",GXType.NChar,20,0) ,
          new ParDef("@lV23TFProveedorDireccion",GXType.VarChar,1024,0) ,
          new ParDef("@AV24TFProveedorDireccion_Sel",GXType.NVarChar,1024,0) ,
          new ParDef("@lV25TFProveedorEmail",GXType.VarChar,100,0) ,
          new ParDef("@AV26TFProveedorEmail_Sel",GXType.NVarChar,100,0)
          };
          Object[] prmP00666;
          prmP00666 = new Object[] {
          new ParDef("@AV54DocumentacionId",GXType.Decimal,18,0) ,
          new ParDef("@AV11TFProveedorID",GXType.Decimal,18,0) ,
          new ParDef("@AV12TFProveedorID_To",GXType.Decimal,18,0) ,
          new ParDef("@AV13TFProveedoresTipoId",GXType.Decimal,18,0) ,
          new ParDef("@AV14TFProveedoresTipoId_To",GXType.Decimal,18,0) ,
          new ParDef("@lV15TFProveedoresTipoNombre",GXType.Char,120,0) ,
          new ParDef("@AV16TFProveedoresTipoNombre_Sel",GXType.NChar,120,0) ,
          new ParDef("@lV17TFProveedorNombre",GXType.Char,80,0) ,
          new ParDef("@AV18TFProveedorNombre_Sel",GXType.NChar,80,0) ,
          new ParDef("@lV19TFProveedorDocIdentidad",GXType.Char,25,0) ,
          new ParDef("@AV20TFProveedorDocIdentidad_Sel",GXType.NChar,25,0) ,
          new ParDef("@lV21TFProveedorTelefono",GXType.Char,20,0) ,
          new ParDef("@AV22TFProveedorTelefono_Sel",GXType.NChar,20,0) ,
          new ParDef("@lV23TFProveedorDireccion",GXType.VarChar,1024,0) ,
          new ParDef("@AV24TFProveedorDireccion_Sel",GXType.NVarChar,1024,0) ,
          new ParDef("@lV25TFProveedorEmail",GXType.VarChar,100,0) ,
          new ParDef("@AV26TFProveedorEmail_Sel",GXType.NVarChar,100,0)
          };
          Object[] prmP00667;
          prmP00667 = new Object[] {
          new ParDef("@AV54DocumentacionId",GXType.Decimal,18,0) ,
          new ParDef("@AV11TFProveedorID",GXType.Decimal,18,0) ,
          new ParDef("@AV12TFProveedorID_To",GXType.Decimal,18,0) ,
          new ParDef("@AV13TFProveedoresTipoId",GXType.Decimal,18,0) ,
          new ParDef("@AV14TFProveedoresTipoId_To",GXType.Decimal,18,0) ,
          new ParDef("@lV15TFProveedoresTipoNombre",GXType.Char,120,0) ,
          new ParDef("@AV16TFProveedoresTipoNombre_Sel",GXType.NChar,120,0) ,
          new ParDef("@lV17TFProveedorNombre",GXType.Char,80,0) ,
          new ParDef("@AV18TFProveedorNombre_Sel",GXType.NChar,80,0) ,
          new ParDef("@lV19TFProveedorDocIdentidad",GXType.Char,25,0) ,
          new ParDef("@AV20TFProveedorDocIdentidad_Sel",GXType.NChar,25,0) ,
          new ParDef("@lV21TFProveedorTelefono",GXType.Char,20,0) ,
          new ParDef("@AV22TFProveedorTelefono_Sel",GXType.NChar,20,0) ,
          new ParDef("@lV23TFProveedorDireccion",GXType.VarChar,1024,0) ,
          new ParDef("@AV24TFProveedorDireccion_Sel",GXType.NVarChar,1024,0) ,
          new ParDef("@lV25TFProveedorEmail",GXType.VarChar,100,0) ,
          new ParDef("@AV26TFProveedorEmail_Sel",GXType.NVarChar,100,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00662", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00662,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00663", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00663,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00664", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00664,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00665", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00665,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00666", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00666,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00667", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00667,100, GxCacheFrequency.OFF ,true,false )
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
                ((long[]) buf[2])[0] = rslt.getLong(2);
                ((string[]) buf[3])[0] = rslt.getString(3, 1);
                ((string[]) buf[4])[0] = rslt.getString(4, 3);
                ((string[]) buf[5])[0] = rslt.getVarchar(5);
                ((bool[]) buf[6])[0] = rslt.wasNull(5);
                ((string[]) buf[7])[0] = rslt.getVarchar(6);
                ((bool[]) buf[8])[0] = rslt.wasNull(6);
                ((string[]) buf[9])[0] = rslt.getString(7, 20);
                ((bool[]) buf[10])[0] = rslt.wasNull(7);
                ((string[]) buf[11])[0] = rslt.getString(8, 25);
                ((string[]) buf[12])[0] = rslt.getString(9, 80);
                ((string[]) buf[13])[0] = rslt.getString(10, 120);
                ((long[]) buf[14])[0] = rslt.getLong(11);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getString(2, 80);
                ((string[]) buf[3])[0] = rslt.getString(3, 1);
                ((string[]) buf[4])[0] = rslt.getString(4, 3);
                ((string[]) buf[5])[0] = rslt.getVarchar(5);
                ((bool[]) buf[6])[0] = rslt.wasNull(5);
                ((string[]) buf[7])[0] = rslt.getVarchar(6);
                ((bool[]) buf[8])[0] = rslt.wasNull(6);
                ((string[]) buf[9])[0] = rslt.getString(7, 20);
                ((bool[]) buf[10])[0] = rslt.wasNull(7);
                ((string[]) buf[11])[0] = rslt.getString(8, 25);
                ((string[]) buf[12])[0] = rslt.getString(9, 120);
                ((long[]) buf[13])[0] = rslt.getLong(10);
                ((long[]) buf[14])[0] = rslt.getLong(11);
                return;
             case 2 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getString(2, 25);
                ((string[]) buf[3])[0] = rslt.getString(3, 1);
                ((string[]) buf[4])[0] = rslt.getString(4, 3);
                ((string[]) buf[5])[0] = rslt.getVarchar(5);
                ((bool[]) buf[6])[0] = rslt.wasNull(5);
                ((string[]) buf[7])[0] = rslt.getVarchar(6);
                ((bool[]) buf[8])[0] = rslt.wasNull(6);
                ((string[]) buf[9])[0] = rslt.getString(7, 20);
                ((bool[]) buf[10])[0] = rslt.wasNull(7);
                ((string[]) buf[11])[0] = rslt.getString(8, 80);
                ((string[]) buf[12])[0] = rslt.getString(9, 120);
                ((long[]) buf[13])[0] = rslt.getLong(10);
                ((long[]) buf[14])[0] = rslt.getLong(11);
                return;
             case 3 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getString(2, 20);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((string[]) buf[4])[0] = rslt.getString(3, 1);
                ((string[]) buf[5])[0] = rslt.getString(4, 3);
                ((string[]) buf[6])[0] = rslt.getVarchar(5);
                ((bool[]) buf[7])[0] = rslt.wasNull(5);
                ((string[]) buf[8])[0] = rslt.getVarchar(6);
                ((bool[]) buf[9])[0] = rslt.wasNull(6);
                ((string[]) buf[10])[0] = rslt.getString(7, 25);
                ((string[]) buf[11])[0] = rslt.getString(8, 80);
                ((string[]) buf[12])[0] = rslt.getString(9, 120);
                ((long[]) buf[13])[0] = rslt.getLong(10);
                ((long[]) buf[14])[0] = rslt.getLong(11);
                return;
             case 4 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getVarchar(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((string[]) buf[4])[0] = rslt.getString(3, 1);
                ((string[]) buf[5])[0] = rslt.getString(4, 3);
                ((string[]) buf[6])[0] = rslt.getVarchar(5);
                ((bool[]) buf[7])[0] = rslt.wasNull(5);
                ((string[]) buf[8])[0] = rslt.getString(6, 20);
                ((bool[]) buf[9])[0] = rslt.wasNull(6);
                ((string[]) buf[10])[0] = rslt.getString(7, 25);
                ((string[]) buf[11])[0] = rslt.getString(8, 80);
                ((string[]) buf[12])[0] = rslt.getString(9, 120);
                ((long[]) buf[13])[0] = rslt.getLong(10);
                ((long[]) buf[14])[0] = rslt.getLong(11);
                return;
             case 5 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getVarchar(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((string[]) buf[4])[0] = rslt.getString(3, 1);
                ((string[]) buf[5])[0] = rslt.getString(4, 3);
                ((string[]) buf[6])[0] = rslt.getVarchar(5);
                ((bool[]) buf[7])[0] = rslt.wasNull(5);
                ((string[]) buf[8])[0] = rslt.getString(6, 20);
                ((bool[]) buf[9])[0] = rslt.wasNull(6);
                ((string[]) buf[10])[0] = rslt.getString(7, 25);
                ((string[]) buf[11])[0] = rslt.getString(8, 80);
                ((string[]) buf[12])[0] = rslt.getString(9, 120);
                ((long[]) buf[13])[0] = rslt.getLong(10);
                ((long[]) buf[14])[0] = rslt.getLong(11);
                return;
       }
    }

 }

 [ServiceContract(Namespace = "GeneXus.Programs.documentacionproveedorwcgetfilterdata_services")]
 [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple)]
 [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
 public class documentacionproveedorwcgetfilterdata_services : GxRestService
 {
    [OperationContract(Name = "DocumentacionProveedorWCGetFilterData" )]
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
          if ( ! ProcessHeaders("documentacionproveedorwcgetfilterdata") )
          {
             return  ;
          }
          documentacionproveedorwcgetfilterdata worker = new documentacionproveedorwcgetfilterdata(context);
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

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
   public class postulacioneswwgetfilterdata : GXProcedure
   {
      public postulacioneswwgetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public postulacioneswwgetfilterdata( IGxContext context )
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
         this.AV64DDOName = aP0_DDOName;
         this.AV65SearchTxtParms = aP1_SearchTxtParms;
         this.AV66SearchTxtTo = aP2_SearchTxtTo;
         this.AV67OptionsJson = "" ;
         this.AV68OptionsDescJson = "" ;
         this.AV69OptionIndexesJson = "" ;
         initialize();
         ExecutePrivate();
         aP3_OptionsJson=this.AV67OptionsJson;
         aP4_OptionsDescJson=this.AV68OptionsDescJson;
         aP5_OptionIndexesJson=this.AV69OptionIndexesJson;
      }

      public string executeUdp( string aP0_DDOName ,
                                string aP1_SearchTxtParms ,
                                string aP2_SearchTxtTo ,
                                out string aP3_OptionsJson ,
                                out string aP4_OptionsDescJson )
      {
         execute(aP0_DDOName, aP1_SearchTxtParms, aP2_SearchTxtTo, out aP3_OptionsJson, out aP4_OptionsDescJson, out aP5_OptionIndexesJson);
         return AV69OptionIndexesJson ;
      }

      public void executeSubmit( string aP0_DDOName ,
                                 string aP1_SearchTxtParms ,
                                 string aP2_SearchTxtTo ,
                                 out string aP3_OptionsJson ,
                                 out string aP4_OptionsDescJson ,
                                 out string aP5_OptionIndexesJson )
      {
         this.AV64DDOName = aP0_DDOName;
         this.AV65SearchTxtParms = aP1_SearchTxtParms;
         this.AV66SearchTxtTo = aP2_SearchTxtTo;
         this.AV67OptionsJson = "" ;
         this.AV68OptionsDescJson = "" ;
         this.AV69OptionIndexesJson = "" ;
         SubmitImpl();
         aP3_OptionsJson=this.AV67OptionsJson;
         aP4_OptionsDescJson=this.AV68OptionsDescJson;
         aP5_OptionIndexesJson=this.AV69OptionIndexesJson;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV54Options = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV56OptionsDesc = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV57OptionIndexes = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         GXt_boolean1 = AV8IsAuthorized;
         new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWPostulaciones", out  GXt_boolean1) ;
         AV8IsAuthorized = GXt_boolean1;
         if ( AV8IsAuthorized )
         {
            AV51MaxItems = 10;
            AV50PageIndex = (short)((String.IsNullOrEmpty(StringUtil.RTrim( AV65SearchTxtParms)) ? 0 : (long)(Math.Round(NumberUtil.Val( StringUtil.Substring( AV65SearchTxtParms, 1, 2), "."), 18, MidpointRounding.ToEven))));
            AV48SearchTxt = (String.IsNullOrEmpty(StringUtil.RTrim( AV65SearchTxtParms)) ? "" : StringUtil.Substring( AV65SearchTxtParms, 3, -1));
            AV49SkipItems = (short)(AV50PageIndex*AV51MaxItems);
            new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV9WWPContext) ;
            /* Execute user subroutine: 'LOADGRIDSTATE' */
            S111 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
            if ( StringUtil.StrCmp(StringUtil.Upper( AV64DDOName), "DDO_SERVICIOSNOMBRE") == 0 )
            {
               /* Execute user subroutine: 'LOADSERVICIOSNOMBREOPTIONS' */
               S121 ();
               if ( returnInSub )
               {
                  cleanup();
                  if (true) return;
               }
            }
            else if ( StringUtil.StrCmp(StringUtil.Upper( AV64DDOName), "DDO_POSTULACIONESPROVEEDORNOMBRE") == 0 )
            {
               /* Execute user subroutine: 'LOADPOSTULACIONESPROVEEDORNOMBREOPTIONS' */
               S131 ();
               if ( returnInSub )
               {
                  cleanup();
                  if (true) return;
               }
            }
            else if ( StringUtil.StrCmp(StringUtil.Upper( AV64DDOName), "DDO_POSTULACIONESDESCRIPCION") == 0 )
            {
               /* Execute user subroutine: 'LOADPOSTULACIONESDESCRIPCIONOPTIONS' */
               S141 ();
               if ( returnInSub )
               {
                  cleanup();
                  if (true) return;
               }
            }
            else if ( StringUtil.StrCmp(StringUtil.Upper( AV64DDOName), "DDO_POSTULACIONESSUMINISTROSDESCRIPCION") == 0 )
            {
               /* Execute user subroutine: 'LOADPOSTULACIONESSUMINISTROSDESCRIPCIONOPTIONS' */
               S151 ();
               if ( returnInSub )
               {
                  cleanup();
                  if (true) return;
               }
            }
            else if ( StringUtil.StrCmp(StringUtil.Upper( AV64DDOName), "DDO_POSTULACIONESHORACIERRE") == 0 )
            {
               /* Execute user subroutine: 'LOADPOSTULACIONESHORACIERREOPTIONS' */
               S161 ();
               if ( returnInSub )
               {
                  cleanup();
                  if (true) return;
               }
            }
            else if ( StringUtil.StrCmp(StringUtil.Upper( AV64DDOName), "DDO_POSTULACIONESTIPOFECHA") == 0 )
            {
               /* Execute user subroutine: 'LOADPOSTULACIONESTIPOFECHAOPTIONS' */
               S171 ();
               if ( returnInSub )
               {
                  cleanup();
                  if (true) return;
               }
            }
            else if ( StringUtil.StrCmp(StringUtil.Upper( AV64DDOName), "DDO_POSTULACIONESRGOHORASERVICIO") == 0 )
            {
               /* Execute user subroutine: 'LOADPOSTULACIONESRGOHORASERVICIOOPTIONS' */
               S181 ();
               if ( returnInSub )
               {
                  cleanup();
                  if (true) return;
               }
            }
            else if ( StringUtil.StrCmp(StringUtil.Upper( AV64DDOName), "DDO_POSTULACIONESAPELLIDONOMBRE") == 0 )
            {
               /* Execute user subroutine: 'LOADPOSTULACIONESAPELLIDONOMBREOPTIONS' */
               S191 ();
               if ( returnInSub )
               {
                  cleanup();
                  if (true) return;
               }
            }
            else if ( StringUtil.StrCmp(StringUtil.Upper( AV64DDOName), "DDO_POSTULACIONESMAIL") == 0 )
            {
               /* Execute user subroutine: 'LOADPOSTULACIONESMAILOPTIONS' */
               S201 ();
               if ( returnInSub )
               {
                  cleanup();
                  if (true) return;
               }
            }
            else if ( StringUtil.StrCmp(StringUtil.Upper( AV64DDOName), "DDO_POSTULACIONESTELEFONO") == 0 )
            {
               /* Execute user subroutine: 'LOADPOSTULACIONESTELEFONOOPTIONS' */
               S211 ();
               if ( returnInSub )
               {
                  cleanup();
                  if (true) return;
               }
            }
         }
         AV67OptionsJson = AV54Options.ToJSonString(false);
         AV68OptionsDescJson = AV56OptionsDesc.ToJSonString(false);
         AV69OptionIndexesJson = AV57OptionIndexes.ToJSonString(false);
         cleanup();
      }

      protected void S111( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV59Session.Get("PostulacionesWWGridState"), "") == 0 )
         {
            AV61GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "PostulacionesWWGridState"), null, "", "");
         }
         else
         {
            AV61GridState.FromXml(AV59Session.Get("PostulacionesWWGridState"), null, "", "");
         }
         AV104GXV1 = 1;
         while ( AV104GXV1 <= AV61GridState.gxTpr_Filtervalues.Count )
         {
            AV62GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV61GridState.gxTpr_Filtervalues.Item(AV104GXV1));
            if ( StringUtil.StrCmp(AV62GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV70FilterFullText = AV62GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV62GridStateFilterValue.gxTpr_Name, "TFPOSTULACIONESID") == 0 )
            {
               AV11TFPostulacionesId = (long)(Math.Round(NumberUtil.Val( AV62GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV12TFPostulacionesId_To = (long)(Math.Round(NumberUtil.Val( AV62GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV62GridStateFilterValue.gxTpr_Name, "TFSERVICIOSID") == 0 )
            {
               AV13TFServiciosId = (long)(Math.Round(NumberUtil.Val( AV62GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV14TFServiciosId_To = (long)(Math.Round(NumberUtil.Val( AV62GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV62GridStateFilterValue.gxTpr_Name, "TFSERVICIOSNOMBRE") == 0 )
            {
               AV15TFServiciosNombre = AV62GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV62GridStateFilterValue.gxTpr_Name, "TFSERVICIOSNOMBRE_SEL") == 0 )
            {
               AV16TFServiciosNombre_Sel = AV62GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV62GridStateFilterValue.gxTpr_Name, "TFPOSTULACIONESPROVEEDORID") == 0 )
            {
               AV17TFPostulacionesProveedorId = (long)(Math.Round(NumberUtil.Val( AV62GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV18TFPostulacionesProveedorId_To = (long)(Math.Round(NumberUtil.Val( AV62GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV62GridStateFilterValue.gxTpr_Name, "TFPOSTULACIONESPROVEEDORNOMBRE") == 0 )
            {
               AV85TFPostulacionesProveedorNombre = AV62GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV62GridStateFilterValue.gxTpr_Name, "TFPOSTULACIONESPROVEEDORNOMBRE_SEL") == 0 )
            {
               AV86TFPostulacionesProveedorNombre_Sel = AV62GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV62GridStateFilterValue.gxTpr_Name, "TFPOSTULACIONESPRECIO") == 0 )
            {
               AV19TFPostulacionesPrecio = NumberUtil.Val( AV62GridStateFilterValue.gxTpr_Value, ".");
               AV20TFPostulacionesPrecio_To = NumberUtil.Val( AV62GridStateFilterValue.gxTpr_Valueto, ".");
            }
            else if ( StringUtil.StrCmp(AV62GridStateFilterValue.gxTpr_Name, "TFPOSTULACIONESMULTIMEDIASERIAL") == 0 )
            {
               AV87TFPostulacionesMultimediaSerial = (short)(Math.Round(NumberUtil.Val( AV62GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV88TFPostulacionesMultimediaSerial_To = (short)(Math.Round(NumberUtil.Val( AV62GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV62GridStateFilterValue.gxTpr_Name, "TFPOSTULACIONESSOLICITUDESID") == 0 )
            {
               AV89TFPostulacionesSolicitudesId = (long)(Math.Round(NumberUtil.Val( AV62GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV90TFPostulacionesSolicitudesId_To = (long)(Math.Round(NumberUtil.Val( AV62GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV62GridStateFilterValue.gxTpr_Name, "TFPOSTULACIONESDESCRIPCION") == 0 )
            {
               AV21TFPostulacionesDescripcion = AV62GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV62GridStateFilterValue.gxTpr_Name, "TFPOSTULACIONESDESCRIPCION_SEL") == 0 )
            {
               AV22TFPostulacionesDescripcion_Sel = AV62GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV62GridStateFilterValue.gxTpr_Name, "TFPOSTULACIONESREQSUMINISTROS_SEL") == 0 )
            {
               AV23TFPostulacionesReqSuministros_Sel = (short)(Math.Round(NumberUtil.Val( AV62GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV62GridStateFilterValue.gxTpr_Name, "TFPOSTULACIONESSUMINISTROSDESCRIPCION") == 0 )
            {
               AV24TFPostulacionesSuministrosDescripcion = AV62GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV62GridStateFilterValue.gxTpr_Name, "TFPOSTULACIONESSUMINISTROSDESCRIPCION_SEL") == 0 )
            {
               AV25TFPostulacionesSuministrosDescripcion_Sel = AV62GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV62GridStateFilterValue.gxTpr_Name, "TFPOSTULACIONESFECHATRABAJO") == 0 )
            {
               AV26TFPostulacionesFechaTrabajo = context.localUtil.CToD( AV62GridStateFilterValue.gxTpr_Value, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               AV27TFPostulacionesFechaTrabajo_To = context.localUtil.CToD( AV62GridStateFilterValue.gxTpr_Valueto, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
            }
            else if ( StringUtil.StrCmp(AV62GridStateFilterValue.gxTpr_Name, "TFPOSTULACIONESFECHACIERRE") == 0 )
            {
               AV28TFPostulacionesFechaCierre = context.localUtil.CToD( AV62GridStateFilterValue.gxTpr_Value, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               AV29TFPostulacionesFechaCierre_To = context.localUtil.CToD( AV62GridStateFilterValue.gxTpr_Valueto, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
            }
            else if ( StringUtil.StrCmp(AV62GridStateFilterValue.gxTpr_Name, "TFPOSTULACIONESHORACIERRE") == 0 )
            {
               AV30TFPostulacionesHoraCierre = AV62GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV62GridStateFilterValue.gxTpr_Name, "TFPOSTULACIONESHORACIERRE_SEL") == 0 )
            {
               AV31TFPostulacionesHoraCierre_Sel = AV62GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV62GridStateFilterValue.gxTpr_Name, "TFPOSTULACIONESTIPOFECHA") == 0 )
            {
               AV32TFPostulacionesTipoFecha = AV62GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV62GridStateFilterValue.gxTpr_Name, "TFPOSTULACIONESTIPOFECHA_SEL") == 0 )
            {
               AV103TFPostulacionesTipoFecha_Sel = AV62GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV62GridStateFilterValue.gxTpr_Name, "TFPOSTULACIONESRGOHORASERVICIO") == 0 )
            {
               AV34TFPostulacionesRgoHoraservicio = AV62GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV62GridStateFilterValue.gxTpr_Name, "TFPOSTULACIONESRGOHORASERVICIO_SEL") == 0 )
            {
               AV35TFPostulacionesRgoHoraservicio_Sel = AV62GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV62GridStateFilterValue.gxTpr_Name, "TFPOSTULACIONESAPELLIDONOMBRE") == 0 )
            {
               AV36TFPostulacionesApellidoNombre = AV62GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV62GridStateFilterValue.gxTpr_Name, "TFPOSTULACIONESAPELLIDONOMBRE_SEL") == 0 )
            {
               AV37TFPostulacionesApellidoNombre_Sel = AV62GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV62GridStateFilterValue.gxTpr_Name, "TFPOSTULACIONESMAIL") == 0 )
            {
               AV38TFPostulacionesMail = AV62GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV62GridStateFilterValue.gxTpr_Name, "TFPOSTULACIONESMAIL_SEL") == 0 )
            {
               AV39TFPostulacionesMail_Sel = AV62GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV62GridStateFilterValue.gxTpr_Name, "TFPOSTULACIONESTELEFONO") == 0 )
            {
               AV40TFPostulacionesTelefono = AV62GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV62GridStateFilterValue.gxTpr_Name, "TFPOSTULACIONESTELEFONO_SEL") == 0 )
            {
               AV41TFPostulacionesTelefono_Sel = AV62GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV62GridStateFilterValue.gxTpr_Name, "TFPOSTULACIONESFECHAALTA") == 0 )
            {
               AV42TFPostulacionesFechaAlta = context.localUtil.CToT( AV62GridStateFilterValue.gxTpr_Value, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               AV43TFPostulacionesFechaAlta_To = context.localUtil.CToT( AV62GridStateFilterValue.gxTpr_Valueto, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
            }
            else if ( StringUtil.StrCmp(AV62GridStateFilterValue.gxTpr_Name, "TFPOSTULACIONESESTADO_SEL") == 0 )
            {
               AV44TFPostulacionesEstado_SelsJson = AV62GridStateFilterValue.gxTpr_Value;
               AV45TFPostulacionesEstado_Sels.FromJSonString(AV44TFPostulacionesEstado_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV62GridStateFilterValue.gxTpr_Name, "TFPOSTULACIONESSECUSERID") == 0 )
            {
               AV46TFPostulacionesSecUserId = (long)(Math.Round(NumberUtil.Val( AV62GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV47TFPostulacionesSecUserId_To = (long)(Math.Round(NumberUtil.Val( AV62GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            AV104GXV1 = (int)(AV104GXV1+1);
         }
         if ( AV61GridState.gxTpr_Dynamicfilters.Count >= 1 )
         {
            AV63GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV61GridState.gxTpr_Dynamicfilters.Item(1));
            AV71DynamicFiltersSelector1 = AV63GridStateDynamicFilter.gxTpr_Selected;
            if ( StringUtil.StrCmp(AV71DynamicFiltersSelector1, "POSTULACIONESPROVEEDORNOMBRE") == 0 )
            {
               AV72DynamicFiltersOperator1 = AV63GridStateDynamicFilter.gxTpr_Operator;
               AV91PostulacionesProveedorNombre1 = AV63GridStateDynamicFilter.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV71DynamicFiltersSelector1, "POSTULACIONESPROVEEDORID") == 0 )
            {
               AV72DynamicFiltersOperator1 = AV63GridStateDynamicFilter.gxTpr_Operator;
               AV73PostulacionesProveedorId1 = (long)(Math.Round(NumberUtil.Val( AV63GridStateDynamicFilter.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV71DynamicFiltersSelector1, "SERVICIOSNOMBRE") == 0 )
            {
               AV72DynamicFiltersOperator1 = AV63GridStateDynamicFilter.gxTpr_Operator;
               AV74ServiciosNombre1 = AV63GridStateDynamicFilter.gxTpr_Value;
            }
            if ( AV61GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV75DynamicFiltersEnabled2 = true;
               AV63GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV61GridState.gxTpr_Dynamicfilters.Item(2));
               AV76DynamicFiltersSelector2 = AV63GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV76DynamicFiltersSelector2, "POSTULACIONESPROVEEDORNOMBRE") == 0 )
               {
                  AV77DynamicFiltersOperator2 = AV63GridStateDynamicFilter.gxTpr_Operator;
                  AV92PostulacionesProveedorNombre2 = AV63GridStateDynamicFilter.gxTpr_Value;
               }
               else if ( StringUtil.StrCmp(AV76DynamicFiltersSelector2, "POSTULACIONESPROVEEDORID") == 0 )
               {
                  AV77DynamicFiltersOperator2 = AV63GridStateDynamicFilter.gxTpr_Operator;
                  AV78PostulacionesProveedorId2 = (long)(Math.Round(NumberUtil.Val( AV63GridStateDynamicFilter.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               }
               else if ( StringUtil.StrCmp(AV76DynamicFiltersSelector2, "SERVICIOSNOMBRE") == 0 )
               {
                  AV77DynamicFiltersOperator2 = AV63GridStateDynamicFilter.gxTpr_Operator;
                  AV79ServiciosNombre2 = AV63GridStateDynamicFilter.gxTpr_Value;
               }
               if ( AV61GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV80DynamicFiltersEnabled3 = true;
                  AV63GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV61GridState.gxTpr_Dynamicfilters.Item(3));
                  AV81DynamicFiltersSelector3 = AV63GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV81DynamicFiltersSelector3, "POSTULACIONESPROVEEDORNOMBRE") == 0 )
                  {
                     AV82DynamicFiltersOperator3 = AV63GridStateDynamicFilter.gxTpr_Operator;
                     AV93PostulacionesProveedorNombre3 = AV63GridStateDynamicFilter.gxTpr_Value;
                  }
                  else if ( StringUtil.StrCmp(AV81DynamicFiltersSelector3, "POSTULACIONESPROVEEDORID") == 0 )
                  {
                     AV82DynamicFiltersOperator3 = AV63GridStateDynamicFilter.gxTpr_Operator;
                     AV83PostulacionesProveedorId3 = (long)(Math.Round(NumberUtil.Val( AV63GridStateDynamicFilter.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
                  }
                  else if ( StringUtil.StrCmp(AV81DynamicFiltersSelector3, "SERVICIOSNOMBRE") == 0 )
                  {
                     AV82DynamicFiltersOperator3 = AV63GridStateDynamicFilter.gxTpr_Operator;
                     AV84ServiciosNombre3 = AV63GridStateDynamicFilter.gxTpr_Value;
                  }
               }
            }
         }
      }

      protected void S121( )
      {
         /* 'LOADSERVICIOSNOMBREOPTIONS' Routine */
         returnInSub = false;
         AV15TFServiciosNombre = AV48SearchTxt;
         AV16TFServiciosNombre_Sel = "";
         AV106Postulacioneswwds_1_filterfulltext = AV70FilterFullText;
         AV107Postulacioneswwds_2_dynamicfiltersselector1 = AV71DynamicFiltersSelector1;
         AV108Postulacioneswwds_3_dynamicfiltersoperator1 = AV72DynamicFiltersOperator1;
         AV109Postulacioneswwds_4_postulacionesproveedornombre1 = AV91PostulacionesProveedorNombre1;
         AV110Postulacioneswwds_5_postulacionesproveedorid1 = AV73PostulacionesProveedorId1;
         AV111Postulacioneswwds_6_serviciosnombre1 = AV74ServiciosNombre1;
         AV112Postulacioneswwds_7_dynamicfiltersenabled2 = AV75DynamicFiltersEnabled2;
         AV113Postulacioneswwds_8_dynamicfiltersselector2 = AV76DynamicFiltersSelector2;
         AV114Postulacioneswwds_9_dynamicfiltersoperator2 = AV77DynamicFiltersOperator2;
         AV115Postulacioneswwds_10_postulacionesproveedornombre2 = AV92PostulacionesProveedorNombre2;
         AV116Postulacioneswwds_11_postulacionesproveedorid2 = AV78PostulacionesProveedorId2;
         AV117Postulacioneswwds_12_serviciosnombre2 = AV79ServiciosNombre2;
         AV118Postulacioneswwds_13_dynamicfiltersenabled3 = AV80DynamicFiltersEnabled3;
         AV119Postulacioneswwds_14_dynamicfiltersselector3 = AV81DynamicFiltersSelector3;
         AV120Postulacioneswwds_15_dynamicfiltersoperator3 = AV82DynamicFiltersOperator3;
         AV121Postulacioneswwds_16_postulacionesproveedornombre3 = AV93PostulacionesProveedorNombre3;
         AV122Postulacioneswwds_17_postulacionesproveedorid3 = AV83PostulacionesProveedorId3;
         AV123Postulacioneswwds_18_serviciosnombre3 = AV84ServiciosNombre3;
         AV124Postulacioneswwds_19_tfpostulacionesid = AV11TFPostulacionesId;
         AV125Postulacioneswwds_20_tfpostulacionesid_to = AV12TFPostulacionesId_To;
         AV126Postulacioneswwds_21_tfserviciosid = AV13TFServiciosId;
         AV127Postulacioneswwds_22_tfserviciosid_to = AV14TFServiciosId_To;
         AV128Postulacioneswwds_23_tfserviciosnombre = AV15TFServiciosNombre;
         AV129Postulacioneswwds_24_tfserviciosnombre_sel = AV16TFServiciosNombre_Sel;
         AV130Postulacioneswwds_25_tfpostulacionesproveedorid = AV17TFPostulacionesProveedorId;
         AV131Postulacioneswwds_26_tfpostulacionesproveedorid_to = AV18TFPostulacionesProveedorId_To;
         AV132Postulacioneswwds_27_tfpostulacionesproveedornombre = AV85TFPostulacionesProveedorNombre;
         AV133Postulacioneswwds_28_tfpostulacionesproveedornombre_sel = AV86TFPostulacionesProveedorNombre_Sel;
         AV134Postulacioneswwds_29_tfpostulacionesprecio = AV19TFPostulacionesPrecio;
         AV135Postulacioneswwds_30_tfpostulacionesprecio_to = AV20TFPostulacionesPrecio_To;
         AV136Postulacioneswwds_31_tfpostulacionesmultimediaserial = AV87TFPostulacionesMultimediaSerial;
         AV137Postulacioneswwds_32_tfpostulacionesmultimediaserial_to = AV88TFPostulacionesMultimediaSerial_To;
         AV138Postulacioneswwds_33_tfpostulacionessolicitudesid = AV89TFPostulacionesSolicitudesId;
         AV139Postulacioneswwds_34_tfpostulacionessolicitudesid_to = AV90TFPostulacionesSolicitudesId_To;
         AV140Postulacioneswwds_35_tfpostulacionesdescripcion = AV21TFPostulacionesDescripcion;
         AV141Postulacioneswwds_36_tfpostulacionesdescripcion_sel = AV22TFPostulacionesDescripcion_Sel;
         AV142Postulacioneswwds_37_tfpostulacionesreqsuministros_sel = AV23TFPostulacionesReqSuministros_Sel;
         AV143Postulacioneswwds_38_tfpostulacionessuministrosdescripcion = AV24TFPostulacionesSuministrosDescripcion;
         AV144Postulacioneswwds_39_tfpostulacionessuministrosdescripcion_sel = AV25TFPostulacionesSuministrosDescripcion_Sel;
         AV145Postulacioneswwds_40_tfpostulacionesfechatrabajo = AV26TFPostulacionesFechaTrabajo;
         AV146Postulacioneswwds_41_tfpostulacionesfechatrabajo_to = AV27TFPostulacionesFechaTrabajo_To;
         AV147Postulacioneswwds_42_tfpostulacionesfechacierre = AV28TFPostulacionesFechaCierre;
         AV148Postulacioneswwds_43_tfpostulacionesfechacierre_to = AV29TFPostulacionesFechaCierre_To;
         AV149Postulacioneswwds_44_tfpostulacioneshoracierre = AV30TFPostulacionesHoraCierre;
         AV150Postulacioneswwds_45_tfpostulacioneshoracierre_sel = AV31TFPostulacionesHoraCierre_Sel;
         AV151Postulacioneswwds_46_tfpostulacionestipofecha = AV32TFPostulacionesTipoFecha;
         AV152Postulacioneswwds_47_tfpostulacionestipofecha_sel = AV103TFPostulacionesTipoFecha_Sel;
         AV153Postulacioneswwds_48_tfpostulacionesrgohoraservicio = AV34TFPostulacionesRgoHoraservicio;
         AV154Postulacioneswwds_49_tfpostulacionesrgohoraservicio_sel = AV35TFPostulacionesRgoHoraservicio_Sel;
         AV155Postulacioneswwds_50_tfpostulacionesapellidonombre = AV36TFPostulacionesApellidoNombre;
         AV156Postulacioneswwds_51_tfpostulacionesapellidonombre_sel = AV37TFPostulacionesApellidoNombre_Sel;
         AV157Postulacioneswwds_52_tfpostulacionesmail = AV38TFPostulacionesMail;
         AV158Postulacioneswwds_53_tfpostulacionesmail_sel = AV39TFPostulacionesMail_Sel;
         AV159Postulacioneswwds_54_tfpostulacionestelefono = AV40TFPostulacionesTelefono;
         AV160Postulacioneswwds_55_tfpostulacionestelefono_sel = AV41TFPostulacionesTelefono_Sel;
         AV161Postulacioneswwds_56_tfpostulacionesfechaalta = AV42TFPostulacionesFechaAlta;
         AV162Postulacioneswwds_57_tfpostulacionesfechaalta_to = AV43TFPostulacionesFechaAlta_To;
         AV163Postulacioneswwds_58_tfpostulacionesestado_sels = AV45TFPostulacionesEstado_Sels;
         AV164Postulacioneswwds_59_tfpostulacionessecuserid = AV46TFPostulacionesSecUserId;
         AV165Postulacioneswwds_60_tfpostulacionessecuserid_to = AV47TFPostulacionesSecUserId_To;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A424PostulacionesEstado ,
                                              AV163Postulacioneswwds_58_tfpostulacionesestado_sels ,
                                              AV107Postulacioneswwds_2_dynamicfiltersselector1 ,
                                              AV108Postulacioneswwds_3_dynamicfiltersoperator1 ,
                                              AV109Postulacioneswwds_4_postulacionesproveedornombre1 ,
                                              AV110Postulacioneswwds_5_postulacionesproveedorid1 ,
                                              AV111Postulacioneswwds_6_serviciosnombre1 ,
                                              AV112Postulacioneswwds_7_dynamicfiltersenabled2 ,
                                              AV113Postulacioneswwds_8_dynamicfiltersselector2 ,
                                              AV114Postulacioneswwds_9_dynamicfiltersoperator2 ,
                                              AV115Postulacioneswwds_10_postulacionesproveedornombre2 ,
                                              AV116Postulacioneswwds_11_postulacionesproveedorid2 ,
                                              AV117Postulacioneswwds_12_serviciosnombre2 ,
                                              AV118Postulacioneswwds_13_dynamicfiltersenabled3 ,
                                              AV119Postulacioneswwds_14_dynamicfiltersselector3 ,
                                              AV120Postulacioneswwds_15_dynamicfiltersoperator3 ,
                                              AV121Postulacioneswwds_16_postulacionesproveedornombre3 ,
                                              AV122Postulacioneswwds_17_postulacionesproveedorid3 ,
                                              AV123Postulacioneswwds_18_serviciosnombre3 ,
                                              AV124Postulacioneswwds_19_tfpostulacionesid ,
                                              AV125Postulacioneswwds_20_tfpostulacionesid_to ,
                                              AV126Postulacioneswwds_21_tfserviciosid ,
                                              AV127Postulacioneswwds_22_tfserviciosid_to ,
                                              AV129Postulacioneswwds_24_tfserviciosnombre_sel ,
                                              AV128Postulacioneswwds_23_tfserviciosnombre ,
                                              AV130Postulacioneswwds_25_tfpostulacionesproveedorid ,
                                              AV131Postulacioneswwds_26_tfpostulacionesproveedorid_to ,
                                              AV133Postulacioneswwds_28_tfpostulacionesproveedornombre_sel ,
                                              AV132Postulacioneswwds_27_tfpostulacionesproveedornombre ,
                                              AV134Postulacioneswwds_29_tfpostulacionesprecio ,
                                              AV135Postulacioneswwds_30_tfpostulacionesprecio_to ,
                                              AV136Postulacioneswwds_31_tfpostulacionesmultimediaserial ,
                                              AV137Postulacioneswwds_32_tfpostulacionesmultimediaserial_to ,
                                              AV141Postulacioneswwds_36_tfpostulacionesdescripcion_sel ,
                                              AV140Postulacioneswwds_35_tfpostulacionesdescripcion ,
                                              AV142Postulacioneswwds_37_tfpostulacionesreqsuministros_sel ,
                                              AV144Postulacioneswwds_39_tfpostulacionessuministrosdescripcion_sel ,
                                              AV143Postulacioneswwds_38_tfpostulacionessuministrosdescripcion ,
                                              AV145Postulacioneswwds_40_tfpostulacionesfechatrabajo ,
                                              AV146Postulacioneswwds_41_tfpostulacionesfechatrabajo_to ,
                                              AV147Postulacioneswwds_42_tfpostulacionesfechacierre ,
                                              AV148Postulacioneswwds_43_tfpostulacionesfechacierre_to ,
                                              AV150Postulacioneswwds_45_tfpostulacioneshoracierre_sel ,
                                              AV149Postulacioneswwds_44_tfpostulacioneshoracierre ,
                                              AV152Postulacioneswwds_47_tfpostulacionestipofecha_sel ,
                                              AV151Postulacioneswwds_46_tfpostulacionestipofecha ,
                                              AV154Postulacioneswwds_49_tfpostulacionesrgohoraservicio_sel ,
                                              AV153Postulacioneswwds_48_tfpostulacionesrgohoraservicio ,
                                              AV156Postulacioneswwds_51_tfpostulacionesapellidonombre_sel ,
                                              AV155Postulacioneswwds_50_tfpostulacionesapellidonombre ,
                                              AV158Postulacioneswwds_53_tfpostulacionesmail_sel ,
                                              AV157Postulacioneswwds_52_tfpostulacionesmail ,
                                              AV160Postulacioneswwds_55_tfpostulacionestelefono_sel ,
                                              AV159Postulacioneswwds_54_tfpostulacionestelefono ,
                                              AV161Postulacioneswwds_56_tfpostulacionesfechaalta ,
                                              AV162Postulacioneswwds_57_tfpostulacionesfechaalta_to ,
                                              AV163Postulacioneswwds_58_tfpostulacionesestado_sels.Count ,
                                              AV164Postulacioneswwds_59_tfpostulacionessecuserid ,
                                              AV165Postulacioneswwds_60_tfpostulacionessecuserid_to ,
                                              A969PostulacionesProveedorNombre ,
                                              A945PostulacionesProveedorId ,
                                              A943ServiciosNombre ,
                                              A422PostulacionesId ,
                                              A942ServiciosId ,
                                              A946PostulacionesPrecio ,
                                              A961PostulacionesMultimediaSerial ,
                                              A936PostulacionesDescripcion ,
                                              A937PostulacionesReqSuministros ,
                                              A938PostulacionesSuministrosDescri ,
                                              A947PostulacionesFechaTrabajo ,
                                              A939PostulacionesFechaCierre ,
                                              A940PostulacionesHoraCierre ,
                                              A941PostulacionesTipoFecha ,
                                              A949PostulacionesRgoHoraservicio ,
                                              A950PostulacionesApellidoNombre ,
                                              A951PostulacionesMail ,
                                              A952PostulacionesTelefono ,
                                              A425PostulacionesFechaAlta ,
                                              A948PostulacionesSecUserId ,
                                              AV106Postulacioneswwds_1_filterfulltext ,
                                              A970PostulacionesSolicitudesId ,
                                              AV138Postulacioneswwds_33_tfpostulacionessolicitudesid ,
                                              AV139Postulacioneswwds_34_tfpostulacionessolicitudesid_to } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG,
                                              TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.DATE,
                                              TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.INT, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG,
                                              TypeConstants.BOOLEAN, TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.LONG,
                                              TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.LONG, TypeConstants.LONG
                                              }
         });
         lV109Postulacioneswwds_4_postulacionesproveedornombre1 = StringUtil.PadR( StringUtil.RTrim( AV109Postulacioneswwds_4_postulacionesproveedornombre1), 80, "%");
         lV109Postulacioneswwds_4_postulacionesproveedornombre1 = StringUtil.PadR( StringUtil.RTrim( AV109Postulacioneswwds_4_postulacionesproveedornombre1), 80, "%");
         lV111Postulacioneswwds_6_serviciosnombre1 = StringUtil.PadR( StringUtil.RTrim( AV111Postulacioneswwds_6_serviciosnombre1), 80, "%");
         lV111Postulacioneswwds_6_serviciosnombre1 = StringUtil.PadR( StringUtil.RTrim( AV111Postulacioneswwds_6_serviciosnombre1), 80, "%");
         lV115Postulacioneswwds_10_postulacionesproveedornombre2 = StringUtil.PadR( StringUtil.RTrim( AV115Postulacioneswwds_10_postulacionesproveedornombre2), 80, "%");
         lV115Postulacioneswwds_10_postulacionesproveedornombre2 = StringUtil.PadR( StringUtil.RTrim( AV115Postulacioneswwds_10_postulacionesproveedornombre2), 80, "%");
         lV117Postulacioneswwds_12_serviciosnombre2 = StringUtil.PadR( StringUtil.RTrim( AV117Postulacioneswwds_12_serviciosnombre2), 80, "%");
         lV117Postulacioneswwds_12_serviciosnombre2 = StringUtil.PadR( StringUtil.RTrim( AV117Postulacioneswwds_12_serviciosnombre2), 80, "%");
         lV121Postulacioneswwds_16_postulacionesproveedornombre3 = StringUtil.PadR( StringUtil.RTrim( AV121Postulacioneswwds_16_postulacionesproveedornombre3), 80, "%");
         lV121Postulacioneswwds_16_postulacionesproveedornombre3 = StringUtil.PadR( StringUtil.RTrim( AV121Postulacioneswwds_16_postulacionesproveedornombre3), 80, "%");
         lV123Postulacioneswwds_18_serviciosnombre3 = StringUtil.PadR( StringUtil.RTrim( AV123Postulacioneswwds_18_serviciosnombre3), 80, "%");
         lV123Postulacioneswwds_18_serviciosnombre3 = StringUtil.PadR( StringUtil.RTrim( AV123Postulacioneswwds_18_serviciosnombre3), 80, "%");
         lV128Postulacioneswwds_23_tfserviciosnombre = StringUtil.PadR( StringUtil.RTrim( AV128Postulacioneswwds_23_tfserviciosnombre), 80, "%");
         lV132Postulacioneswwds_27_tfpostulacionesproveedornombre = StringUtil.PadR( StringUtil.RTrim( AV132Postulacioneswwds_27_tfpostulacionesproveedornombre), 80, "%");
         lV140Postulacioneswwds_35_tfpostulacionesdescripcion = StringUtil.PadR( StringUtil.RTrim( AV140Postulacioneswwds_35_tfpostulacionesdescripcion), 2000, "%");
         lV143Postulacioneswwds_38_tfpostulacionessuministrosdescripcion = StringUtil.PadR( StringUtil.RTrim( AV143Postulacioneswwds_38_tfpostulacionessuministrosdescripcion), 250, "%");
         lV149Postulacioneswwds_44_tfpostulacioneshoracierre = StringUtil.Concat( StringUtil.RTrim( AV149Postulacioneswwds_44_tfpostulacioneshoracierre), "%", "");
         lV151Postulacioneswwds_46_tfpostulacionestipofecha = StringUtil.Concat( StringUtil.RTrim( AV151Postulacioneswwds_46_tfpostulacionestipofecha), "%", "");
         lV153Postulacioneswwds_48_tfpostulacionesrgohoraservicio = StringUtil.PadR( StringUtil.RTrim( AV153Postulacioneswwds_48_tfpostulacionesrgohoraservicio), 5, "%");
         lV155Postulacioneswwds_50_tfpostulacionesapellidonombre = StringUtil.PadR( StringUtil.RTrim( AV155Postulacioneswwds_50_tfpostulacionesapellidonombre), 80, "%");
         lV157Postulacioneswwds_52_tfpostulacionesmail = StringUtil.Concat( StringUtil.RTrim( AV157Postulacioneswwds_52_tfpostulacionesmail), "%", "");
         lV159Postulacioneswwds_54_tfpostulacionestelefono = StringUtil.PadR( StringUtil.RTrim( AV159Postulacioneswwds_54_tfpostulacionestelefono), 20, "%");
         /* Using cursor P00LA3 */
         pr_default.execute(0, new Object[] {n422PostulacionesId, A422PostulacionesId, AV138Postulacioneswwds_33_tfpostulacionessolicitudesid, AV138Postulacioneswwds_33_tfpostulacionessolicitudesid, AV139Postulacioneswwds_34_tfpostulacionessolicitudesid_to, AV139Postulacioneswwds_34_tfpostulacionessolicitudesid_to, lV109Postulacioneswwds_4_postulacionesproveedornombre1, lV109Postulacioneswwds_4_postulacionesproveedornombre1, AV110Postulacioneswwds_5_postulacionesproveedorid1, AV110Postulacioneswwds_5_postulacionesproveedorid1, AV110Postulacioneswwds_5_postulacionesproveedorid1, lV111Postulacioneswwds_6_serviciosnombre1, lV111Postulacioneswwds_6_serviciosnombre1, lV115Postulacioneswwds_10_postulacionesproveedornombre2, lV115Postulacioneswwds_10_postulacionesproveedornombre2, AV116Postulacioneswwds_11_postulacionesproveedorid2, AV116Postulacioneswwds_11_postulacionesproveedorid2, AV116Postulacioneswwds_11_postulacionesproveedorid2, lV117Postulacioneswwds_12_serviciosnombre2, lV117Postulacioneswwds_12_serviciosnombre2, lV121Postulacioneswwds_16_postulacionesproveedornombre3, lV121Postulacioneswwds_16_postulacionesproveedornombre3, AV122Postulacioneswwds_17_postulacionesproveedorid3, AV122Postulacioneswwds_17_postulacionesproveedorid3, AV122Postulacioneswwds_17_postulacionesproveedorid3, lV123Postulacioneswwds_18_serviciosnombre3, lV123Postulacioneswwds_18_serviciosnombre3, AV124Postulacioneswwds_19_tfpostulacionesid, AV125Postulacioneswwds_20_tfpostulacionesid_to, AV126Postulacioneswwds_21_tfserviciosid, AV127Postulacioneswwds_22_tfserviciosid_to, lV128Postulacioneswwds_23_tfserviciosnombre, AV129Postulacioneswwds_24_tfserviciosnombre_sel, AV130Postulacioneswwds_25_tfpostulacionesproveedorid, AV131Postulacioneswwds_26_tfpostulacionesproveedorid_to, lV132Postulacioneswwds_27_tfpostulacionesproveedornombre, AV133Postulacioneswwds_28_tfpostulacionesproveedornombre_sel, AV134Postulacioneswwds_29_tfpostulacionesprecio, AV135Postulacioneswwds_30_tfpostulacionesprecio_to, AV136Postulacioneswwds_31_tfpostulacionesmultimediaserial, AV137Postulacioneswwds_32_tfpostulacionesmultimediaserial_to, lV140Postulacioneswwds_35_tfpostulacionesdescripcion, AV141Postulacioneswwds_36_tfpostulacionesdescripcion_sel, lV143Postulacioneswwds_38_tfpostulacionessuministrosdescripcion, AV144Postulacioneswwds_39_tfpostulacionessuministrosdescripcion_sel, AV145Postulacioneswwds_40_tfpostulacionesfechatrabajo, AV146Postulacioneswwds_41_tfpostulacionesfechatrabajo_to, AV147Postulacioneswwds_42_tfpostulacionesfechacierre, AV148Postulacioneswwds_43_tfpostulacionesfechacierre_to, lV149Postulacioneswwds_44_tfpostulacioneshoracierre, AV150Postulacioneswwds_45_tfpostulacioneshoracierre_sel, lV151Postulacioneswwds_46_tfpostulacionestipofecha, AV152Postulacioneswwds_47_tfpostulacionestipofecha_sel, lV153Postulacioneswwds_48_tfpostulacionesrgohoraservicio, AV154Postulacioneswwds_49_tfpostulacionesrgohoraservicio_sel, lV155Postulacioneswwds_50_tfpostulacionesapellidonombre, AV156Postulacioneswwds_51_tfpostulacionesapellidonombre_sel, lV157Postulacioneswwds_52_tfpostulacionesmail, AV158Postulacioneswwds_53_tfpostulacionesmail_sel, lV159Postulacioneswwds_54_tfpostulacionestelefono, AV160Postulacioneswwds_55_tfpostulacionestelefono_sel, AV161Postulacioneswwds_56_tfpostulacionesfechaalta, AV162Postulacioneswwds_57_tfpostulacionesfechaalta_to, AV164Postulacioneswwds_59_tfpostulacionessecuserid, AV165Postulacioneswwds_60_tfpostulacionessecuserid_to});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRKLA2 = false;
            A942ServiciosId = P00LA3_A942ServiciosId[0];
            n942ServiciosId = P00LA3_n942ServiciosId[0];
            A948PostulacionesSecUserId = P00LA3_A948PostulacionesSecUserId[0];
            A425PostulacionesFechaAlta = P00LA3_A425PostulacionesFechaAlta[0];
            A952PostulacionesTelefono = P00LA3_A952PostulacionesTelefono[0];
            A951PostulacionesMail = P00LA3_A951PostulacionesMail[0];
            A950PostulacionesApellidoNombre = P00LA3_A950PostulacionesApellidoNombre[0];
            A949PostulacionesRgoHoraservicio = P00LA3_A949PostulacionesRgoHoraservicio[0];
            A941PostulacionesTipoFecha = P00LA3_A941PostulacionesTipoFecha[0];
            A940PostulacionesHoraCierre = P00LA3_A940PostulacionesHoraCierre[0];
            A939PostulacionesFechaCierre = P00LA3_A939PostulacionesFechaCierre[0];
            A947PostulacionesFechaTrabajo = P00LA3_A947PostulacionesFechaTrabajo[0];
            A938PostulacionesSuministrosDescri = P00LA3_A938PostulacionesSuministrosDescri[0];
            A937PostulacionesReqSuministros = P00LA3_A937PostulacionesReqSuministros[0];
            A936PostulacionesDescripcion = P00LA3_A936PostulacionesDescripcion[0];
            A961PostulacionesMultimediaSerial = P00LA3_A961PostulacionesMultimediaSerial[0];
            A946PostulacionesPrecio = P00LA3_A946PostulacionesPrecio[0];
            A969PostulacionesProveedorNombre = P00LA3_A969PostulacionesProveedorNombre[0];
            A943ServiciosNombre = P00LA3_A943ServiciosNombre[0];
            A422PostulacionesId = P00LA3_A422PostulacionesId[0];
            n422PostulacionesId = P00LA3_n422PostulacionesId[0];
            A945PostulacionesProveedorId = P00LA3_A945PostulacionesProveedorId[0];
            A424PostulacionesEstado = P00LA3_A424PostulacionesEstado[0];
            A970PostulacionesSolicitudesId = P00LA3_A970PostulacionesSolicitudesId[0];
            n970PostulacionesSolicitudesId = P00LA3_n970PostulacionesSolicitudesId[0];
            A943ServiciosNombre = P00LA3_A943ServiciosNombre[0];
            A969PostulacionesProveedorNombre = P00LA3_A969PostulacionesProveedorNombre[0];
            A970PostulacionesSolicitudesId = P00LA3_A970PostulacionesSolicitudesId[0];
            n970PostulacionesSolicitudesId = P00LA3_n970PostulacionesSolicitudesId[0];
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV106Postulacioneswwds_1_filterfulltext)) || ( ( StringUtil.Like( StringUtil.Str( (decimal)(A422PostulacionesId), 18, 0) , StringUtil.PadR( "%" + AV106Postulacioneswwds_1_filterfulltext , 254 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Str( (decimal)(A942ServiciosId), 18, 0) , StringUtil.PadR( "%" + AV106Postulacioneswwds_1_filterfulltext , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A943ServiciosNombre) , StringUtil.PadR( "%" + StringUtil.Upper( AV106Postulacioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Str( (decimal)(A945PostulacionesProveedorId), 18, 0) , StringUtil.PadR( "%" + AV106Postulacioneswwds_1_filterfulltext , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A969PostulacionesProveedorNombre) , StringUtil.PadR( "%" + StringUtil.Upper( AV106Postulacioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Str( A946PostulacionesPrecio, 18, 2) , StringUtil.PadR( "%" + AV106Postulacioneswwds_1_filterfulltext , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Str( (decimal)(A961PostulacionesMultimediaSerial), 4, 0) , StringUtil.PadR( "%" + AV106Postulacioneswwds_1_filterfulltext , 254 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Str( (decimal)(A970PostulacionesSolicitudesId), 18, 0) , StringUtil.PadR( "%" + AV106Postulacioneswwds_1_filterfulltext , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A936PostulacionesDescripcion) , StringUtil.PadR( "%" + StringUtil.Upper( AV106Postulacioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Upper( A938PostulacionesSuministrosDescri) , StringUtil.PadR( "%" + StringUtil.Upper( AV106Postulacioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A940PostulacionesHoraCierre) , StringUtil.PadR( "%" + StringUtil.Upper( AV106Postulacioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Upper( A941PostulacionesTipoFecha) , StringUtil.PadR( "%" + StringUtil.Upper( AV106Postulacioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A949PostulacionesRgoHoraservicio) , StringUtil.PadR( "%" + StringUtil.Upper( AV106Postulacioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Upper( A950PostulacionesApellidoNombre) , StringUtil.PadR( "%" + StringUtil.Upper( AV106Postulacioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A951PostulacionesMail) , StringUtil.PadR( "%" + StringUtil.Upper( AV106Postulacioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Upper( A952PostulacionesTelefono) , StringUtil.PadR( "%" + StringUtil.Upper( AV106Postulacioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( context.GetMessage( "habilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV106Postulacioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A424PostulacionesEstado, "HAB") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "deshabilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV106Postulacioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A424PostulacionesEstado, "DES") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "ganador", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV106Postulacioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) &&
            ( StringUtil.StrCmp(A424PostulacionesEstado, "GAN") == 0 ) ) || ( StringUtil.Like( StringUtil.Str( (decimal)(A948PostulacionesSecUserId), 18, 0) , StringUtil.PadR( "%" + AV106Postulacioneswwds_1_filterfulltext , 254 , "%"),  ' ' ) ) )
            )
            {
               AV58count = 0;
               while ( (pr_default.getStatus(0) != 101) && ( P00LA3_A942ServiciosId[0] == A942ServiciosId ) )
               {
                  BRKLA2 = false;
                  A422PostulacionesId = P00LA3_A422PostulacionesId[0];
                  n422PostulacionesId = P00LA3_n422PostulacionesId[0];
                  AV58count = (long)(AV58count+1);
                  BRKLA2 = true;
                  pr_default.readNext(0);
               }
               AV53Option = (String.IsNullOrEmpty(StringUtil.RTrim( A943ServiciosNombre)) ? "<#Empty#>" : A943ServiciosNombre);
               AV52InsertIndex = 1;
               while ( ( StringUtil.StrCmp(AV53Option, "<#Empty#>") != 0 ) && ( AV52InsertIndex <= AV54Options.Count ) && ( ( StringUtil.StrCmp(((string)AV54Options.Item(AV52InsertIndex)), AV53Option) < 0 ) || ( StringUtil.StrCmp(((string)AV54Options.Item(AV52InsertIndex)), "<#Empty#>") == 0 ) ) )
               {
                  AV52InsertIndex = (int)(AV52InsertIndex+1);
               }
               AV54Options.Add(AV53Option, AV52InsertIndex);
               AV57OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV58count), "Z,ZZZ,ZZZ,ZZ9")), AV52InsertIndex);
               if ( AV54Options.Count == AV49SkipItems + 11 )
               {
                  AV54Options.RemoveItem(AV54Options.Count);
                  AV57OptionIndexes.RemoveItem(AV57OptionIndexes.Count);
               }
            }
            if ( ! BRKLA2 )
            {
               BRKLA2 = true;
               pr_default.readNext(0);
            }
         }
         pr_default.close(0);
         while ( AV49SkipItems > 0 )
         {
            AV54Options.RemoveItem(1);
            AV57OptionIndexes.RemoveItem(1);
            AV49SkipItems = (short)(AV49SkipItems-1);
         }
      }

      protected void S131( )
      {
         /* 'LOADPOSTULACIONESPROVEEDORNOMBREOPTIONS' Routine */
         returnInSub = false;
         AV85TFPostulacionesProveedorNombre = AV48SearchTxt;
         AV86TFPostulacionesProveedorNombre_Sel = "";
         AV106Postulacioneswwds_1_filterfulltext = AV70FilterFullText;
         AV107Postulacioneswwds_2_dynamicfiltersselector1 = AV71DynamicFiltersSelector1;
         AV108Postulacioneswwds_3_dynamicfiltersoperator1 = AV72DynamicFiltersOperator1;
         AV109Postulacioneswwds_4_postulacionesproveedornombre1 = AV91PostulacionesProveedorNombre1;
         AV110Postulacioneswwds_5_postulacionesproveedorid1 = AV73PostulacionesProveedorId1;
         AV111Postulacioneswwds_6_serviciosnombre1 = AV74ServiciosNombre1;
         AV112Postulacioneswwds_7_dynamicfiltersenabled2 = AV75DynamicFiltersEnabled2;
         AV113Postulacioneswwds_8_dynamicfiltersselector2 = AV76DynamicFiltersSelector2;
         AV114Postulacioneswwds_9_dynamicfiltersoperator2 = AV77DynamicFiltersOperator2;
         AV115Postulacioneswwds_10_postulacionesproveedornombre2 = AV92PostulacionesProveedorNombre2;
         AV116Postulacioneswwds_11_postulacionesproveedorid2 = AV78PostulacionesProveedorId2;
         AV117Postulacioneswwds_12_serviciosnombre2 = AV79ServiciosNombre2;
         AV118Postulacioneswwds_13_dynamicfiltersenabled3 = AV80DynamicFiltersEnabled3;
         AV119Postulacioneswwds_14_dynamicfiltersselector3 = AV81DynamicFiltersSelector3;
         AV120Postulacioneswwds_15_dynamicfiltersoperator3 = AV82DynamicFiltersOperator3;
         AV121Postulacioneswwds_16_postulacionesproveedornombre3 = AV93PostulacionesProveedorNombre3;
         AV122Postulacioneswwds_17_postulacionesproveedorid3 = AV83PostulacionesProveedorId3;
         AV123Postulacioneswwds_18_serviciosnombre3 = AV84ServiciosNombre3;
         AV124Postulacioneswwds_19_tfpostulacionesid = AV11TFPostulacionesId;
         AV125Postulacioneswwds_20_tfpostulacionesid_to = AV12TFPostulacionesId_To;
         AV126Postulacioneswwds_21_tfserviciosid = AV13TFServiciosId;
         AV127Postulacioneswwds_22_tfserviciosid_to = AV14TFServiciosId_To;
         AV128Postulacioneswwds_23_tfserviciosnombre = AV15TFServiciosNombre;
         AV129Postulacioneswwds_24_tfserviciosnombre_sel = AV16TFServiciosNombre_Sel;
         AV130Postulacioneswwds_25_tfpostulacionesproveedorid = AV17TFPostulacionesProveedorId;
         AV131Postulacioneswwds_26_tfpostulacionesproveedorid_to = AV18TFPostulacionesProveedorId_To;
         AV132Postulacioneswwds_27_tfpostulacionesproveedornombre = AV85TFPostulacionesProveedorNombre;
         AV133Postulacioneswwds_28_tfpostulacionesproveedornombre_sel = AV86TFPostulacionesProveedorNombre_Sel;
         AV134Postulacioneswwds_29_tfpostulacionesprecio = AV19TFPostulacionesPrecio;
         AV135Postulacioneswwds_30_tfpostulacionesprecio_to = AV20TFPostulacionesPrecio_To;
         AV136Postulacioneswwds_31_tfpostulacionesmultimediaserial = AV87TFPostulacionesMultimediaSerial;
         AV137Postulacioneswwds_32_tfpostulacionesmultimediaserial_to = AV88TFPostulacionesMultimediaSerial_To;
         AV138Postulacioneswwds_33_tfpostulacionessolicitudesid = AV89TFPostulacionesSolicitudesId;
         AV139Postulacioneswwds_34_tfpostulacionessolicitudesid_to = AV90TFPostulacionesSolicitudesId_To;
         AV140Postulacioneswwds_35_tfpostulacionesdescripcion = AV21TFPostulacionesDescripcion;
         AV141Postulacioneswwds_36_tfpostulacionesdescripcion_sel = AV22TFPostulacionesDescripcion_Sel;
         AV142Postulacioneswwds_37_tfpostulacionesreqsuministros_sel = AV23TFPostulacionesReqSuministros_Sel;
         AV143Postulacioneswwds_38_tfpostulacionessuministrosdescripcion = AV24TFPostulacionesSuministrosDescripcion;
         AV144Postulacioneswwds_39_tfpostulacionessuministrosdescripcion_sel = AV25TFPostulacionesSuministrosDescripcion_Sel;
         AV145Postulacioneswwds_40_tfpostulacionesfechatrabajo = AV26TFPostulacionesFechaTrabajo;
         AV146Postulacioneswwds_41_tfpostulacionesfechatrabajo_to = AV27TFPostulacionesFechaTrabajo_To;
         AV147Postulacioneswwds_42_tfpostulacionesfechacierre = AV28TFPostulacionesFechaCierre;
         AV148Postulacioneswwds_43_tfpostulacionesfechacierre_to = AV29TFPostulacionesFechaCierre_To;
         AV149Postulacioneswwds_44_tfpostulacioneshoracierre = AV30TFPostulacionesHoraCierre;
         AV150Postulacioneswwds_45_tfpostulacioneshoracierre_sel = AV31TFPostulacionesHoraCierre_Sel;
         AV151Postulacioneswwds_46_tfpostulacionestipofecha = AV32TFPostulacionesTipoFecha;
         AV152Postulacioneswwds_47_tfpostulacionestipofecha_sel = AV103TFPostulacionesTipoFecha_Sel;
         AV153Postulacioneswwds_48_tfpostulacionesrgohoraservicio = AV34TFPostulacionesRgoHoraservicio;
         AV154Postulacioneswwds_49_tfpostulacionesrgohoraservicio_sel = AV35TFPostulacionesRgoHoraservicio_Sel;
         AV155Postulacioneswwds_50_tfpostulacionesapellidonombre = AV36TFPostulacionesApellidoNombre;
         AV156Postulacioneswwds_51_tfpostulacionesapellidonombre_sel = AV37TFPostulacionesApellidoNombre_Sel;
         AV157Postulacioneswwds_52_tfpostulacionesmail = AV38TFPostulacionesMail;
         AV158Postulacioneswwds_53_tfpostulacionesmail_sel = AV39TFPostulacionesMail_Sel;
         AV159Postulacioneswwds_54_tfpostulacionestelefono = AV40TFPostulacionesTelefono;
         AV160Postulacioneswwds_55_tfpostulacionestelefono_sel = AV41TFPostulacionesTelefono_Sel;
         AV161Postulacioneswwds_56_tfpostulacionesfechaalta = AV42TFPostulacionesFechaAlta;
         AV162Postulacioneswwds_57_tfpostulacionesfechaalta_to = AV43TFPostulacionesFechaAlta_To;
         AV163Postulacioneswwds_58_tfpostulacionesestado_sels = AV45TFPostulacionesEstado_Sels;
         AV164Postulacioneswwds_59_tfpostulacionessecuserid = AV46TFPostulacionesSecUserId;
         AV165Postulacioneswwds_60_tfpostulacionessecuserid_to = AV47TFPostulacionesSecUserId_To;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              A424PostulacionesEstado ,
                                              AV163Postulacioneswwds_58_tfpostulacionesestado_sels ,
                                              AV107Postulacioneswwds_2_dynamicfiltersselector1 ,
                                              AV108Postulacioneswwds_3_dynamicfiltersoperator1 ,
                                              AV109Postulacioneswwds_4_postulacionesproveedornombre1 ,
                                              AV110Postulacioneswwds_5_postulacionesproveedorid1 ,
                                              AV111Postulacioneswwds_6_serviciosnombre1 ,
                                              AV112Postulacioneswwds_7_dynamicfiltersenabled2 ,
                                              AV113Postulacioneswwds_8_dynamicfiltersselector2 ,
                                              AV114Postulacioneswwds_9_dynamicfiltersoperator2 ,
                                              AV115Postulacioneswwds_10_postulacionesproveedornombre2 ,
                                              AV116Postulacioneswwds_11_postulacionesproveedorid2 ,
                                              AV117Postulacioneswwds_12_serviciosnombre2 ,
                                              AV118Postulacioneswwds_13_dynamicfiltersenabled3 ,
                                              AV119Postulacioneswwds_14_dynamicfiltersselector3 ,
                                              AV120Postulacioneswwds_15_dynamicfiltersoperator3 ,
                                              AV121Postulacioneswwds_16_postulacionesproveedornombre3 ,
                                              AV122Postulacioneswwds_17_postulacionesproveedorid3 ,
                                              AV123Postulacioneswwds_18_serviciosnombre3 ,
                                              AV124Postulacioneswwds_19_tfpostulacionesid ,
                                              AV125Postulacioneswwds_20_tfpostulacionesid_to ,
                                              AV126Postulacioneswwds_21_tfserviciosid ,
                                              AV127Postulacioneswwds_22_tfserviciosid_to ,
                                              AV129Postulacioneswwds_24_tfserviciosnombre_sel ,
                                              AV128Postulacioneswwds_23_tfserviciosnombre ,
                                              AV130Postulacioneswwds_25_tfpostulacionesproveedorid ,
                                              AV131Postulacioneswwds_26_tfpostulacionesproveedorid_to ,
                                              AV133Postulacioneswwds_28_tfpostulacionesproveedornombre_sel ,
                                              AV132Postulacioneswwds_27_tfpostulacionesproveedornombre ,
                                              AV134Postulacioneswwds_29_tfpostulacionesprecio ,
                                              AV135Postulacioneswwds_30_tfpostulacionesprecio_to ,
                                              AV136Postulacioneswwds_31_tfpostulacionesmultimediaserial ,
                                              AV137Postulacioneswwds_32_tfpostulacionesmultimediaserial_to ,
                                              AV141Postulacioneswwds_36_tfpostulacionesdescripcion_sel ,
                                              AV140Postulacioneswwds_35_tfpostulacionesdescripcion ,
                                              AV142Postulacioneswwds_37_tfpostulacionesreqsuministros_sel ,
                                              AV144Postulacioneswwds_39_tfpostulacionessuministrosdescripcion_sel ,
                                              AV143Postulacioneswwds_38_tfpostulacionessuministrosdescripcion ,
                                              AV145Postulacioneswwds_40_tfpostulacionesfechatrabajo ,
                                              AV146Postulacioneswwds_41_tfpostulacionesfechatrabajo_to ,
                                              AV147Postulacioneswwds_42_tfpostulacionesfechacierre ,
                                              AV148Postulacioneswwds_43_tfpostulacionesfechacierre_to ,
                                              AV150Postulacioneswwds_45_tfpostulacioneshoracierre_sel ,
                                              AV149Postulacioneswwds_44_tfpostulacioneshoracierre ,
                                              AV152Postulacioneswwds_47_tfpostulacionestipofecha_sel ,
                                              AV151Postulacioneswwds_46_tfpostulacionestipofecha ,
                                              AV154Postulacioneswwds_49_tfpostulacionesrgohoraservicio_sel ,
                                              AV153Postulacioneswwds_48_tfpostulacionesrgohoraservicio ,
                                              AV156Postulacioneswwds_51_tfpostulacionesapellidonombre_sel ,
                                              AV155Postulacioneswwds_50_tfpostulacionesapellidonombre ,
                                              AV158Postulacioneswwds_53_tfpostulacionesmail_sel ,
                                              AV157Postulacioneswwds_52_tfpostulacionesmail ,
                                              AV160Postulacioneswwds_55_tfpostulacionestelefono_sel ,
                                              AV159Postulacioneswwds_54_tfpostulacionestelefono ,
                                              AV161Postulacioneswwds_56_tfpostulacionesfechaalta ,
                                              AV162Postulacioneswwds_57_tfpostulacionesfechaalta_to ,
                                              AV163Postulacioneswwds_58_tfpostulacionesestado_sels.Count ,
                                              AV164Postulacioneswwds_59_tfpostulacionessecuserid ,
                                              AV165Postulacioneswwds_60_tfpostulacionessecuserid_to ,
                                              A969PostulacionesProveedorNombre ,
                                              A945PostulacionesProveedorId ,
                                              A943ServiciosNombre ,
                                              A422PostulacionesId ,
                                              A942ServiciosId ,
                                              A946PostulacionesPrecio ,
                                              A961PostulacionesMultimediaSerial ,
                                              A936PostulacionesDescripcion ,
                                              A937PostulacionesReqSuministros ,
                                              A938PostulacionesSuministrosDescri ,
                                              A947PostulacionesFechaTrabajo ,
                                              A939PostulacionesFechaCierre ,
                                              A940PostulacionesHoraCierre ,
                                              A941PostulacionesTipoFecha ,
                                              A949PostulacionesRgoHoraservicio ,
                                              A950PostulacionesApellidoNombre ,
                                              A951PostulacionesMail ,
                                              A952PostulacionesTelefono ,
                                              A425PostulacionesFechaAlta ,
                                              A948PostulacionesSecUserId ,
                                              AV106Postulacioneswwds_1_filterfulltext ,
                                              A970PostulacionesSolicitudesId ,
                                              AV138Postulacioneswwds_33_tfpostulacionessolicitudesid ,
                                              AV139Postulacioneswwds_34_tfpostulacionessolicitudesid_to } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG,
                                              TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.DATE,
                                              TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.INT, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG,
                                              TypeConstants.BOOLEAN, TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.LONG,
                                              TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.LONG, TypeConstants.LONG
                                              }
         });
         lV109Postulacioneswwds_4_postulacionesproveedornombre1 = StringUtil.PadR( StringUtil.RTrim( AV109Postulacioneswwds_4_postulacionesproveedornombre1), 80, "%");
         lV109Postulacioneswwds_4_postulacionesproveedornombre1 = StringUtil.PadR( StringUtil.RTrim( AV109Postulacioneswwds_4_postulacionesproveedornombre1), 80, "%");
         lV111Postulacioneswwds_6_serviciosnombre1 = StringUtil.PadR( StringUtil.RTrim( AV111Postulacioneswwds_6_serviciosnombre1), 80, "%");
         lV111Postulacioneswwds_6_serviciosnombre1 = StringUtil.PadR( StringUtil.RTrim( AV111Postulacioneswwds_6_serviciosnombre1), 80, "%");
         lV115Postulacioneswwds_10_postulacionesproveedornombre2 = StringUtil.PadR( StringUtil.RTrim( AV115Postulacioneswwds_10_postulacionesproveedornombre2), 80, "%");
         lV115Postulacioneswwds_10_postulacionesproveedornombre2 = StringUtil.PadR( StringUtil.RTrim( AV115Postulacioneswwds_10_postulacionesproveedornombre2), 80, "%");
         lV117Postulacioneswwds_12_serviciosnombre2 = StringUtil.PadR( StringUtil.RTrim( AV117Postulacioneswwds_12_serviciosnombre2), 80, "%");
         lV117Postulacioneswwds_12_serviciosnombre2 = StringUtil.PadR( StringUtil.RTrim( AV117Postulacioneswwds_12_serviciosnombre2), 80, "%");
         lV121Postulacioneswwds_16_postulacionesproveedornombre3 = StringUtil.PadR( StringUtil.RTrim( AV121Postulacioneswwds_16_postulacionesproveedornombre3), 80, "%");
         lV121Postulacioneswwds_16_postulacionesproveedornombre3 = StringUtil.PadR( StringUtil.RTrim( AV121Postulacioneswwds_16_postulacionesproveedornombre3), 80, "%");
         lV123Postulacioneswwds_18_serviciosnombre3 = StringUtil.PadR( StringUtil.RTrim( AV123Postulacioneswwds_18_serviciosnombre3), 80, "%");
         lV123Postulacioneswwds_18_serviciosnombre3 = StringUtil.PadR( StringUtil.RTrim( AV123Postulacioneswwds_18_serviciosnombre3), 80, "%");
         lV128Postulacioneswwds_23_tfserviciosnombre = StringUtil.PadR( StringUtil.RTrim( AV128Postulacioneswwds_23_tfserviciosnombre), 80, "%");
         lV132Postulacioneswwds_27_tfpostulacionesproveedornombre = StringUtil.PadR( StringUtil.RTrim( AV132Postulacioneswwds_27_tfpostulacionesproveedornombre), 80, "%");
         lV140Postulacioneswwds_35_tfpostulacionesdescripcion = StringUtil.PadR( StringUtil.RTrim( AV140Postulacioneswwds_35_tfpostulacionesdescripcion), 2000, "%");
         lV143Postulacioneswwds_38_tfpostulacionessuministrosdescripcion = StringUtil.PadR( StringUtil.RTrim( AV143Postulacioneswwds_38_tfpostulacionessuministrosdescripcion), 250, "%");
         lV149Postulacioneswwds_44_tfpostulacioneshoracierre = StringUtil.Concat( StringUtil.RTrim( AV149Postulacioneswwds_44_tfpostulacioneshoracierre), "%", "");
         lV151Postulacioneswwds_46_tfpostulacionestipofecha = StringUtil.Concat( StringUtil.RTrim( AV151Postulacioneswwds_46_tfpostulacionestipofecha), "%", "");
         lV153Postulacioneswwds_48_tfpostulacionesrgohoraservicio = StringUtil.PadR( StringUtil.RTrim( AV153Postulacioneswwds_48_tfpostulacionesrgohoraservicio), 5, "%");
         lV155Postulacioneswwds_50_tfpostulacionesapellidonombre = StringUtil.PadR( StringUtil.RTrim( AV155Postulacioneswwds_50_tfpostulacionesapellidonombre), 80, "%");
         lV157Postulacioneswwds_52_tfpostulacionesmail = StringUtil.Concat( StringUtil.RTrim( AV157Postulacioneswwds_52_tfpostulacionesmail), "%", "");
         lV159Postulacioneswwds_54_tfpostulacionestelefono = StringUtil.PadR( StringUtil.RTrim( AV159Postulacioneswwds_54_tfpostulacionestelefono), 20, "%");
         /* Using cursor P00LA5 */
         pr_default.execute(1, new Object[] {n422PostulacionesId, A422PostulacionesId, AV138Postulacioneswwds_33_tfpostulacionessolicitudesid, AV138Postulacioneswwds_33_tfpostulacionessolicitudesid, AV139Postulacioneswwds_34_tfpostulacionessolicitudesid_to, AV139Postulacioneswwds_34_tfpostulacionessolicitudesid_to, lV109Postulacioneswwds_4_postulacionesproveedornombre1, lV109Postulacioneswwds_4_postulacionesproveedornombre1, AV110Postulacioneswwds_5_postulacionesproveedorid1, AV110Postulacioneswwds_5_postulacionesproveedorid1, AV110Postulacioneswwds_5_postulacionesproveedorid1, lV111Postulacioneswwds_6_serviciosnombre1, lV111Postulacioneswwds_6_serviciosnombre1, lV115Postulacioneswwds_10_postulacionesproveedornombre2, lV115Postulacioneswwds_10_postulacionesproveedornombre2, AV116Postulacioneswwds_11_postulacionesproveedorid2, AV116Postulacioneswwds_11_postulacionesproveedorid2, AV116Postulacioneswwds_11_postulacionesproveedorid2, lV117Postulacioneswwds_12_serviciosnombre2, lV117Postulacioneswwds_12_serviciosnombre2, lV121Postulacioneswwds_16_postulacionesproveedornombre3, lV121Postulacioneswwds_16_postulacionesproveedornombre3, AV122Postulacioneswwds_17_postulacionesproveedorid3, AV122Postulacioneswwds_17_postulacionesproveedorid3, AV122Postulacioneswwds_17_postulacionesproveedorid3, lV123Postulacioneswwds_18_serviciosnombre3, lV123Postulacioneswwds_18_serviciosnombre3, AV124Postulacioneswwds_19_tfpostulacionesid, AV125Postulacioneswwds_20_tfpostulacionesid_to, AV126Postulacioneswwds_21_tfserviciosid, AV127Postulacioneswwds_22_tfserviciosid_to, lV128Postulacioneswwds_23_tfserviciosnombre, AV129Postulacioneswwds_24_tfserviciosnombre_sel, AV130Postulacioneswwds_25_tfpostulacionesproveedorid, AV131Postulacioneswwds_26_tfpostulacionesproveedorid_to, lV132Postulacioneswwds_27_tfpostulacionesproveedornombre, AV133Postulacioneswwds_28_tfpostulacionesproveedornombre_sel, AV134Postulacioneswwds_29_tfpostulacionesprecio, AV135Postulacioneswwds_30_tfpostulacionesprecio_to, AV136Postulacioneswwds_31_tfpostulacionesmultimediaserial, AV137Postulacioneswwds_32_tfpostulacionesmultimediaserial_to, lV140Postulacioneswwds_35_tfpostulacionesdescripcion, AV141Postulacioneswwds_36_tfpostulacionesdescripcion_sel, lV143Postulacioneswwds_38_tfpostulacionessuministrosdescripcion, AV144Postulacioneswwds_39_tfpostulacionessuministrosdescripcion_sel, AV145Postulacioneswwds_40_tfpostulacionesfechatrabajo, AV146Postulacioneswwds_41_tfpostulacionesfechatrabajo_to, AV147Postulacioneswwds_42_tfpostulacionesfechacierre, AV148Postulacioneswwds_43_tfpostulacionesfechacierre_to, lV149Postulacioneswwds_44_tfpostulacioneshoracierre, AV150Postulacioneswwds_45_tfpostulacioneshoracierre_sel, lV151Postulacioneswwds_46_tfpostulacionestipofecha, AV152Postulacioneswwds_47_tfpostulacionestipofecha_sel, lV153Postulacioneswwds_48_tfpostulacionesrgohoraservicio, AV154Postulacioneswwds_49_tfpostulacionesrgohoraservicio_sel, lV155Postulacioneswwds_50_tfpostulacionesapellidonombre, AV156Postulacioneswwds_51_tfpostulacionesapellidonombre_sel, lV157Postulacioneswwds_52_tfpostulacionesmail, AV158Postulacioneswwds_53_tfpostulacionesmail_sel, lV159Postulacioneswwds_54_tfpostulacionestelefono, AV160Postulacioneswwds_55_tfpostulacionestelefono_sel, AV161Postulacioneswwds_56_tfpostulacionesfechaalta, AV162Postulacioneswwds_57_tfpostulacionesfechaalta_to, AV164Postulacioneswwds_59_tfpostulacionessecuserid, AV165Postulacioneswwds_60_tfpostulacionessecuserid_to});
         while ( (pr_default.getStatus(1) != 101) )
         {
            BRKLA4 = false;
            A945PostulacionesProveedorId = P00LA5_A945PostulacionesProveedorId[0];
            A948PostulacionesSecUserId = P00LA5_A948PostulacionesSecUserId[0];
            A425PostulacionesFechaAlta = P00LA5_A425PostulacionesFechaAlta[0];
            A952PostulacionesTelefono = P00LA5_A952PostulacionesTelefono[0];
            A951PostulacionesMail = P00LA5_A951PostulacionesMail[0];
            A950PostulacionesApellidoNombre = P00LA5_A950PostulacionesApellidoNombre[0];
            A949PostulacionesRgoHoraservicio = P00LA5_A949PostulacionesRgoHoraservicio[0];
            A941PostulacionesTipoFecha = P00LA5_A941PostulacionesTipoFecha[0];
            A940PostulacionesHoraCierre = P00LA5_A940PostulacionesHoraCierre[0];
            A939PostulacionesFechaCierre = P00LA5_A939PostulacionesFechaCierre[0];
            A947PostulacionesFechaTrabajo = P00LA5_A947PostulacionesFechaTrabajo[0];
            A938PostulacionesSuministrosDescri = P00LA5_A938PostulacionesSuministrosDescri[0];
            A937PostulacionesReqSuministros = P00LA5_A937PostulacionesReqSuministros[0];
            A936PostulacionesDescripcion = P00LA5_A936PostulacionesDescripcion[0];
            A961PostulacionesMultimediaSerial = P00LA5_A961PostulacionesMultimediaSerial[0];
            A946PostulacionesPrecio = P00LA5_A946PostulacionesPrecio[0];
            A969PostulacionesProveedorNombre = P00LA5_A969PostulacionesProveedorNombre[0];
            A943ServiciosNombre = P00LA5_A943ServiciosNombre[0];
            A942ServiciosId = P00LA5_A942ServiciosId[0];
            n942ServiciosId = P00LA5_n942ServiciosId[0];
            A422PostulacionesId = P00LA5_A422PostulacionesId[0];
            n422PostulacionesId = P00LA5_n422PostulacionesId[0];
            A424PostulacionesEstado = P00LA5_A424PostulacionesEstado[0];
            A970PostulacionesSolicitudesId = P00LA5_A970PostulacionesSolicitudesId[0];
            n970PostulacionesSolicitudesId = P00LA5_n970PostulacionesSolicitudesId[0];
            A969PostulacionesProveedorNombre = P00LA5_A969PostulacionesProveedorNombre[0];
            A943ServiciosNombre = P00LA5_A943ServiciosNombre[0];
            A970PostulacionesSolicitudesId = P00LA5_A970PostulacionesSolicitudesId[0];
            n970PostulacionesSolicitudesId = P00LA5_n970PostulacionesSolicitudesId[0];
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV106Postulacioneswwds_1_filterfulltext)) || ( ( StringUtil.Like( StringUtil.Str( (decimal)(A422PostulacionesId), 18, 0) , StringUtil.PadR( "%" + AV106Postulacioneswwds_1_filterfulltext , 254 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Str( (decimal)(A942ServiciosId), 18, 0) , StringUtil.PadR( "%" + AV106Postulacioneswwds_1_filterfulltext , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A943ServiciosNombre) , StringUtil.PadR( "%" + StringUtil.Upper( AV106Postulacioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Str( (decimal)(A945PostulacionesProveedorId), 18, 0) , StringUtil.PadR( "%" + AV106Postulacioneswwds_1_filterfulltext , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A969PostulacionesProveedorNombre) , StringUtil.PadR( "%" + StringUtil.Upper( AV106Postulacioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Str( A946PostulacionesPrecio, 18, 2) , StringUtil.PadR( "%" + AV106Postulacioneswwds_1_filterfulltext , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Str( (decimal)(A961PostulacionesMultimediaSerial), 4, 0) , StringUtil.PadR( "%" + AV106Postulacioneswwds_1_filterfulltext , 254 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Str( (decimal)(A970PostulacionesSolicitudesId), 18, 0) , StringUtil.PadR( "%" + AV106Postulacioneswwds_1_filterfulltext , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A936PostulacionesDescripcion) , StringUtil.PadR( "%" + StringUtil.Upper( AV106Postulacioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Upper( A938PostulacionesSuministrosDescri) , StringUtil.PadR( "%" + StringUtil.Upper( AV106Postulacioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A940PostulacionesHoraCierre) , StringUtil.PadR( "%" + StringUtil.Upper( AV106Postulacioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Upper( A941PostulacionesTipoFecha) , StringUtil.PadR( "%" + StringUtil.Upper( AV106Postulacioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A949PostulacionesRgoHoraservicio) , StringUtil.PadR( "%" + StringUtil.Upper( AV106Postulacioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Upper( A950PostulacionesApellidoNombre) , StringUtil.PadR( "%" + StringUtil.Upper( AV106Postulacioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A951PostulacionesMail) , StringUtil.PadR( "%" + StringUtil.Upper( AV106Postulacioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Upper( A952PostulacionesTelefono) , StringUtil.PadR( "%" + StringUtil.Upper( AV106Postulacioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( context.GetMessage( "habilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV106Postulacioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A424PostulacionesEstado, "HAB") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "deshabilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV106Postulacioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A424PostulacionesEstado, "DES") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "ganador", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV106Postulacioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) &&
            ( StringUtil.StrCmp(A424PostulacionesEstado, "GAN") == 0 ) ) || ( StringUtil.Like( StringUtil.Str( (decimal)(A948PostulacionesSecUserId), 18, 0) , StringUtil.PadR( "%" + AV106Postulacioneswwds_1_filterfulltext , 254 , "%"),  ' ' ) ) )
            )
            {
               AV58count = 0;
               while ( (pr_default.getStatus(1) != 101) && ( P00LA5_A945PostulacionesProveedorId[0] == A945PostulacionesProveedorId ) )
               {
                  BRKLA4 = false;
                  A422PostulacionesId = P00LA5_A422PostulacionesId[0];
                  n422PostulacionesId = P00LA5_n422PostulacionesId[0];
                  AV58count = (long)(AV58count+1);
                  BRKLA4 = true;
                  pr_default.readNext(1);
               }
               AV53Option = (String.IsNullOrEmpty(StringUtil.RTrim( A969PostulacionesProveedorNombre)) ? "<#Empty#>" : A969PostulacionesProveedorNombre);
               AV52InsertIndex = 1;
               while ( ( StringUtil.StrCmp(AV53Option, "<#Empty#>") != 0 ) && ( AV52InsertIndex <= AV54Options.Count ) && ( ( StringUtil.StrCmp(((string)AV54Options.Item(AV52InsertIndex)), AV53Option) < 0 ) || ( StringUtil.StrCmp(((string)AV54Options.Item(AV52InsertIndex)), "<#Empty#>") == 0 ) ) )
               {
                  AV52InsertIndex = (int)(AV52InsertIndex+1);
               }
               AV54Options.Add(AV53Option, AV52InsertIndex);
               AV57OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV58count), "Z,ZZZ,ZZZ,ZZ9")), AV52InsertIndex);
               if ( AV54Options.Count == AV49SkipItems + 11 )
               {
                  AV54Options.RemoveItem(AV54Options.Count);
                  AV57OptionIndexes.RemoveItem(AV57OptionIndexes.Count);
               }
            }
            if ( ! BRKLA4 )
            {
               BRKLA4 = true;
               pr_default.readNext(1);
            }
         }
         pr_default.close(1);
         while ( AV49SkipItems > 0 )
         {
            AV54Options.RemoveItem(1);
            AV57OptionIndexes.RemoveItem(1);
            AV49SkipItems = (short)(AV49SkipItems-1);
         }
      }

      protected void S141( )
      {
         /* 'LOADPOSTULACIONESDESCRIPCIONOPTIONS' Routine */
         returnInSub = false;
         AV21TFPostulacionesDescripcion = AV48SearchTxt;
         AV22TFPostulacionesDescripcion_Sel = "";
         AV106Postulacioneswwds_1_filterfulltext = AV70FilterFullText;
         AV107Postulacioneswwds_2_dynamicfiltersselector1 = AV71DynamicFiltersSelector1;
         AV108Postulacioneswwds_3_dynamicfiltersoperator1 = AV72DynamicFiltersOperator1;
         AV109Postulacioneswwds_4_postulacionesproveedornombre1 = AV91PostulacionesProveedorNombre1;
         AV110Postulacioneswwds_5_postulacionesproveedorid1 = AV73PostulacionesProveedorId1;
         AV111Postulacioneswwds_6_serviciosnombre1 = AV74ServiciosNombre1;
         AV112Postulacioneswwds_7_dynamicfiltersenabled2 = AV75DynamicFiltersEnabled2;
         AV113Postulacioneswwds_8_dynamicfiltersselector2 = AV76DynamicFiltersSelector2;
         AV114Postulacioneswwds_9_dynamicfiltersoperator2 = AV77DynamicFiltersOperator2;
         AV115Postulacioneswwds_10_postulacionesproveedornombre2 = AV92PostulacionesProveedorNombre2;
         AV116Postulacioneswwds_11_postulacionesproveedorid2 = AV78PostulacionesProveedorId2;
         AV117Postulacioneswwds_12_serviciosnombre2 = AV79ServiciosNombre2;
         AV118Postulacioneswwds_13_dynamicfiltersenabled3 = AV80DynamicFiltersEnabled3;
         AV119Postulacioneswwds_14_dynamicfiltersselector3 = AV81DynamicFiltersSelector3;
         AV120Postulacioneswwds_15_dynamicfiltersoperator3 = AV82DynamicFiltersOperator3;
         AV121Postulacioneswwds_16_postulacionesproveedornombre3 = AV93PostulacionesProveedorNombre3;
         AV122Postulacioneswwds_17_postulacionesproveedorid3 = AV83PostulacionesProveedorId3;
         AV123Postulacioneswwds_18_serviciosnombre3 = AV84ServiciosNombre3;
         AV124Postulacioneswwds_19_tfpostulacionesid = AV11TFPostulacionesId;
         AV125Postulacioneswwds_20_tfpostulacionesid_to = AV12TFPostulacionesId_To;
         AV126Postulacioneswwds_21_tfserviciosid = AV13TFServiciosId;
         AV127Postulacioneswwds_22_tfserviciosid_to = AV14TFServiciosId_To;
         AV128Postulacioneswwds_23_tfserviciosnombre = AV15TFServiciosNombre;
         AV129Postulacioneswwds_24_tfserviciosnombre_sel = AV16TFServiciosNombre_Sel;
         AV130Postulacioneswwds_25_tfpostulacionesproveedorid = AV17TFPostulacionesProveedorId;
         AV131Postulacioneswwds_26_tfpostulacionesproveedorid_to = AV18TFPostulacionesProveedorId_To;
         AV132Postulacioneswwds_27_tfpostulacionesproveedornombre = AV85TFPostulacionesProveedorNombre;
         AV133Postulacioneswwds_28_tfpostulacionesproveedornombre_sel = AV86TFPostulacionesProveedorNombre_Sel;
         AV134Postulacioneswwds_29_tfpostulacionesprecio = AV19TFPostulacionesPrecio;
         AV135Postulacioneswwds_30_tfpostulacionesprecio_to = AV20TFPostulacionesPrecio_To;
         AV136Postulacioneswwds_31_tfpostulacionesmultimediaserial = AV87TFPostulacionesMultimediaSerial;
         AV137Postulacioneswwds_32_tfpostulacionesmultimediaserial_to = AV88TFPostulacionesMultimediaSerial_To;
         AV138Postulacioneswwds_33_tfpostulacionessolicitudesid = AV89TFPostulacionesSolicitudesId;
         AV139Postulacioneswwds_34_tfpostulacionessolicitudesid_to = AV90TFPostulacionesSolicitudesId_To;
         AV140Postulacioneswwds_35_tfpostulacionesdescripcion = AV21TFPostulacionesDescripcion;
         AV141Postulacioneswwds_36_tfpostulacionesdescripcion_sel = AV22TFPostulacionesDescripcion_Sel;
         AV142Postulacioneswwds_37_tfpostulacionesreqsuministros_sel = AV23TFPostulacionesReqSuministros_Sel;
         AV143Postulacioneswwds_38_tfpostulacionessuministrosdescripcion = AV24TFPostulacionesSuministrosDescripcion;
         AV144Postulacioneswwds_39_tfpostulacionessuministrosdescripcion_sel = AV25TFPostulacionesSuministrosDescripcion_Sel;
         AV145Postulacioneswwds_40_tfpostulacionesfechatrabajo = AV26TFPostulacionesFechaTrabajo;
         AV146Postulacioneswwds_41_tfpostulacionesfechatrabajo_to = AV27TFPostulacionesFechaTrabajo_To;
         AV147Postulacioneswwds_42_tfpostulacionesfechacierre = AV28TFPostulacionesFechaCierre;
         AV148Postulacioneswwds_43_tfpostulacionesfechacierre_to = AV29TFPostulacionesFechaCierre_To;
         AV149Postulacioneswwds_44_tfpostulacioneshoracierre = AV30TFPostulacionesHoraCierre;
         AV150Postulacioneswwds_45_tfpostulacioneshoracierre_sel = AV31TFPostulacionesHoraCierre_Sel;
         AV151Postulacioneswwds_46_tfpostulacionestipofecha = AV32TFPostulacionesTipoFecha;
         AV152Postulacioneswwds_47_tfpostulacionestipofecha_sel = AV103TFPostulacionesTipoFecha_Sel;
         AV153Postulacioneswwds_48_tfpostulacionesrgohoraservicio = AV34TFPostulacionesRgoHoraservicio;
         AV154Postulacioneswwds_49_tfpostulacionesrgohoraservicio_sel = AV35TFPostulacionesRgoHoraservicio_Sel;
         AV155Postulacioneswwds_50_tfpostulacionesapellidonombre = AV36TFPostulacionesApellidoNombre;
         AV156Postulacioneswwds_51_tfpostulacionesapellidonombre_sel = AV37TFPostulacionesApellidoNombre_Sel;
         AV157Postulacioneswwds_52_tfpostulacionesmail = AV38TFPostulacionesMail;
         AV158Postulacioneswwds_53_tfpostulacionesmail_sel = AV39TFPostulacionesMail_Sel;
         AV159Postulacioneswwds_54_tfpostulacionestelefono = AV40TFPostulacionesTelefono;
         AV160Postulacioneswwds_55_tfpostulacionestelefono_sel = AV41TFPostulacionesTelefono_Sel;
         AV161Postulacioneswwds_56_tfpostulacionesfechaalta = AV42TFPostulacionesFechaAlta;
         AV162Postulacioneswwds_57_tfpostulacionesfechaalta_to = AV43TFPostulacionesFechaAlta_To;
         AV163Postulacioneswwds_58_tfpostulacionesestado_sels = AV45TFPostulacionesEstado_Sels;
         AV164Postulacioneswwds_59_tfpostulacionessecuserid = AV46TFPostulacionesSecUserId;
         AV165Postulacioneswwds_60_tfpostulacionessecuserid_to = AV47TFPostulacionesSecUserId_To;
         pr_default.dynParam(2, new Object[]{ new Object[]{
                                              A424PostulacionesEstado ,
                                              AV163Postulacioneswwds_58_tfpostulacionesestado_sels ,
                                              AV107Postulacioneswwds_2_dynamicfiltersselector1 ,
                                              AV108Postulacioneswwds_3_dynamicfiltersoperator1 ,
                                              AV109Postulacioneswwds_4_postulacionesproveedornombre1 ,
                                              AV110Postulacioneswwds_5_postulacionesproveedorid1 ,
                                              AV111Postulacioneswwds_6_serviciosnombre1 ,
                                              AV112Postulacioneswwds_7_dynamicfiltersenabled2 ,
                                              AV113Postulacioneswwds_8_dynamicfiltersselector2 ,
                                              AV114Postulacioneswwds_9_dynamicfiltersoperator2 ,
                                              AV115Postulacioneswwds_10_postulacionesproveedornombre2 ,
                                              AV116Postulacioneswwds_11_postulacionesproveedorid2 ,
                                              AV117Postulacioneswwds_12_serviciosnombre2 ,
                                              AV118Postulacioneswwds_13_dynamicfiltersenabled3 ,
                                              AV119Postulacioneswwds_14_dynamicfiltersselector3 ,
                                              AV120Postulacioneswwds_15_dynamicfiltersoperator3 ,
                                              AV121Postulacioneswwds_16_postulacionesproveedornombre3 ,
                                              AV122Postulacioneswwds_17_postulacionesproveedorid3 ,
                                              AV123Postulacioneswwds_18_serviciosnombre3 ,
                                              AV124Postulacioneswwds_19_tfpostulacionesid ,
                                              AV125Postulacioneswwds_20_tfpostulacionesid_to ,
                                              AV126Postulacioneswwds_21_tfserviciosid ,
                                              AV127Postulacioneswwds_22_tfserviciosid_to ,
                                              AV129Postulacioneswwds_24_tfserviciosnombre_sel ,
                                              AV128Postulacioneswwds_23_tfserviciosnombre ,
                                              AV130Postulacioneswwds_25_tfpostulacionesproveedorid ,
                                              AV131Postulacioneswwds_26_tfpostulacionesproveedorid_to ,
                                              AV133Postulacioneswwds_28_tfpostulacionesproveedornombre_sel ,
                                              AV132Postulacioneswwds_27_tfpostulacionesproveedornombre ,
                                              AV134Postulacioneswwds_29_tfpostulacionesprecio ,
                                              AV135Postulacioneswwds_30_tfpostulacionesprecio_to ,
                                              AV136Postulacioneswwds_31_tfpostulacionesmultimediaserial ,
                                              AV137Postulacioneswwds_32_tfpostulacionesmultimediaserial_to ,
                                              AV141Postulacioneswwds_36_tfpostulacionesdescripcion_sel ,
                                              AV140Postulacioneswwds_35_tfpostulacionesdescripcion ,
                                              AV142Postulacioneswwds_37_tfpostulacionesreqsuministros_sel ,
                                              AV144Postulacioneswwds_39_tfpostulacionessuministrosdescripcion_sel ,
                                              AV143Postulacioneswwds_38_tfpostulacionessuministrosdescripcion ,
                                              AV145Postulacioneswwds_40_tfpostulacionesfechatrabajo ,
                                              AV146Postulacioneswwds_41_tfpostulacionesfechatrabajo_to ,
                                              AV147Postulacioneswwds_42_tfpostulacionesfechacierre ,
                                              AV148Postulacioneswwds_43_tfpostulacionesfechacierre_to ,
                                              AV150Postulacioneswwds_45_tfpostulacioneshoracierre_sel ,
                                              AV149Postulacioneswwds_44_tfpostulacioneshoracierre ,
                                              AV152Postulacioneswwds_47_tfpostulacionestipofecha_sel ,
                                              AV151Postulacioneswwds_46_tfpostulacionestipofecha ,
                                              AV154Postulacioneswwds_49_tfpostulacionesrgohoraservicio_sel ,
                                              AV153Postulacioneswwds_48_tfpostulacionesrgohoraservicio ,
                                              AV156Postulacioneswwds_51_tfpostulacionesapellidonombre_sel ,
                                              AV155Postulacioneswwds_50_tfpostulacionesapellidonombre ,
                                              AV158Postulacioneswwds_53_tfpostulacionesmail_sel ,
                                              AV157Postulacioneswwds_52_tfpostulacionesmail ,
                                              AV160Postulacioneswwds_55_tfpostulacionestelefono_sel ,
                                              AV159Postulacioneswwds_54_tfpostulacionestelefono ,
                                              AV161Postulacioneswwds_56_tfpostulacionesfechaalta ,
                                              AV162Postulacioneswwds_57_tfpostulacionesfechaalta_to ,
                                              AV163Postulacioneswwds_58_tfpostulacionesestado_sels.Count ,
                                              AV164Postulacioneswwds_59_tfpostulacionessecuserid ,
                                              AV165Postulacioneswwds_60_tfpostulacionessecuserid_to ,
                                              A969PostulacionesProveedorNombre ,
                                              A945PostulacionesProveedorId ,
                                              A943ServiciosNombre ,
                                              A422PostulacionesId ,
                                              A942ServiciosId ,
                                              A946PostulacionesPrecio ,
                                              A961PostulacionesMultimediaSerial ,
                                              A936PostulacionesDescripcion ,
                                              A937PostulacionesReqSuministros ,
                                              A938PostulacionesSuministrosDescri ,
                                              A947PostulacionesFechaTrabajo ,
                                              A939PostulacionesFechaCierre ,
                                              A940PostulacionesHoraCierre ,
                                              A941PostulacionesTipoFecha ,
                                              A949PostulacionesRgoHoraservicio ,
                                              A950PostulacionesApellidoNombre ,
                                              A951PostulacionesMail ,
                                              A952PostulacionesTelefono ,
                                              A425PostulacionesFechaAlta ,
                                              A948PostulacionesSecUserId ,
                                              AV106Postulacioneswwds_1_filterfulltext ,
                                              A970PostulacionesSolicitudesId ,
                                              AV138Postulacioneswwds_33_tfpostulacionessolicitudesid ,
                                              AV139Postulacioneswwds_34_tfpostulacionessolicitudesid_to } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG,
                                              TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.DATE,
                                              TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.INT, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG,
                                              TypeConstants.BOOLEAN, TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.LONG,
                                              TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.LONG, TypeConstants.LONG
                                              }
         });
         lV109Postulacioneswwds_4_postulacionesproveedornombre1 = StringUtil.PadR( StringUtil.RTrim( AV109Postulacioneswwds_4_postulacionesproveedornombre1), 80, "%");
         lV109Postulacioneswwds_4_postulacionesproveedornombre1 = StringUtil.PadR( StringUtil.RTrim( AV109Postulacioneswwds_4_postulacionesproveedornombre1), 80, "%");
         lV111Postulacioneswwds_6_serviciosnombre1 = StringUtil.PadR( StringUtil.RTrim( AV111Postulacioneswwds_6_serviciosnombre1), 80, "%");
         lV111Postulacioneswwds_6_serviciosnombre1 = StringUtil.PadR( StringUtil.RTrim( AV111Postulacioneswwds_6_serviciosnombre1), 80, "%");
         lV115Postulacioneswwds_10_postulacionesproveedornombre2 = StringUtil.PadR( StringUtil.RTrim( AV115Postulacioneswwds_10_postulacionesproveedornombre2), 80, "%");
         lV115Postulacioneswwds_10_postulacionesproveedornombre2 = StringUtil.PadR( StringUtil.RTrim( AV115Postulacioneswwds_10_postulacionesproveedornombre2), 80, "%");
         lV117Postulacioneswwds_12_serviciosnombre2 = StringUtil.PadR( StringUtil.RTrim( AV117Postulacioneswwds_12_serviciosnombre2), 80, "%");
         lV117Postulacioneswwds_12_serviciosnombre2 = StringUtil.PadR( StringUtil.RTrim( AV117Postulacioneswwds_12_serviciosnombre2), 80, "%");
         lV121Postulacioneswwds_16_postulacionesproveedornombre3 = StringUtil.PadR( StringUtil.RTrim( AV121Postulacioneswwds_16_postulacionesproveedornombre3), 80, "%");
         lV121Postulacioneswwds_16_postulacionesproveedornombre3 = StringUtil.PadR( StringUtil.RTrim( AV121Postulacioneswwds_16_postulacionesproveedornombre3), 80, "%");
         lV123Postulacioneswwds_18_serviciosnombre3 = StringUtil.PadR( StringUtil.RTrim( AV123Postulacioneswwds_18_serviciosnombre3), 80, "%");
         lV123Postulacioneswwds_18_serviciosnombre3 = StringUtil.PadR( StringUtil.RTrim( AV123Postulacioneswwds_18_serviciosnombre3), 80, "%");
         lV128Postulacioneswwds_23_tfserviciosnombre = StringUtil.PadR( StringUtil.RTrim( AV128Postulacioneswwds_23_tfserviciosnombre), 80, "%");
         lV132Postulacioneswwds_27_tfpostulacionesproveedornombre = StringUtil.PadR( StringUtil.RTrim( AV132Postulacioneswwds_27_tfpostulacionesproveedornombre), 80, "%");
         lV140Postulacioneswwds_35_tfpostulacionesdescripcion = StringUtil.PadR( StringUtil.RTrim( AV140Postulacioneswwds_35_tfpostulacionesdescripcion), 2000, "%");
         lV143Postulacioneswwds_38_tfpostulacionessuministrosdescripcion = StringUtil.PadR( StringUtil.RTrim( AV143Postulacioneswwds_38_tfpostulacionessuministrosdescripcion), 250, "%");
         lV149Postulacioneswwds_44_tfpostulacioneshoracierre = StringUtil.Concat( StringUtil.RTrim( AV149Postulacioneswwds_44_tfpostulacioneshoracierre), "%", "");
         lV151Postulacioneswwds_46_tfpostulacionestipofecha = StringUtil.Concat( StringUtil.RTrim( AV151Postulacioneswwds_46_tfpostulacionestipofecha), "%", "");
         lV153Postulacioneswwds_48_tfpostulacionesrgohoraservicio = StringUtil.PadR( StringUtil.RTrim( AV153Postulacioneswwds_48_tfpostulacionesrgohoraservicio), 5, "%");
         lV155Postulacioneswwds_50_tfpostulacionesapellidonombre = StringUtil.PadR( StringUtil.RTrim( AV155Postulacioneswwds_50_tfpostulacionesapellidonombre), 80, "%");
         lV157Postulacioneswwds_52_tfpostulacionesmail = StringUtil.Concat( StringUtil.RTrim( AV157Postulacioneswwds_52_tfpostulacionesmail), "%", "");
         lV159Postulacioneswwds_54_tfpostulacionestelefono = StringUtil.PadR( StringUtil.RTrim( AV159Postulacioneswwds_54_tfpostulacionestelefono), 20, "%");
         /* Using cursor P00LA7 */
         pr_default.execute(2, new Object[] {n422PostulacionesId, A422PostulacionesId, AV138Postulacioneswwds_33_tfpostulacionessolicitudesid, AV138Postulacioneswwds_33_tfpostulacionessolicitudesid, AV139Postulacioneswwds_34_tfpostulacionessolicitudesid_to, AV139Postulacioneswwds_34_tfpostulacionessolicitudesid_to, lV109Postulacioneswwds_4_postulacionesproveedornombre1, lV109Postulacioneswwds_4_postulacionesproveedornombre1, AV110Postulacioneswwds_5_postulacionesproveedorid1, AV110Postulacioneswwds_5_postulacionesproveedorid1, AV110Postulacioneswwds_5_postulacionesproveedorid1, lV111Postulacioneswwds_6_serviciosnombre1, lV111Postulacioneswwds_6_serviciosnombre1, lV115Postulacioneswwds_10_postulacionesproveedornombre2, lV115Postulacioneswwds_10_postulacionesproveedornombre2, AV116Postulacioneswwds_11_postulacionesproveedorid2, AV116Postulacioneswwds_11_postulacionesproveedorid2, AV116Postulacioneswwds_11_postulacionesproveedorid2, lV117Postulacioneswwds_12_serviciosnombre2, lV117Postulacioneswwds_12_serviciosnombre2, lV121Postulacioneswwds_16_postulacionesproveedornombre3, lV121Postulacioneswwds_16_postulacionesproveedornombre3, AV122Postulacioneswwds_17_postulacionesproveedorid3, AV122Postulacioneswwds_17_postulacionesproveedorid3, AV122Postulacioneswwds_17_postulacionesproveedorid3, lV123Postulacioneswwds_18_serviciosnombre3, lV123Postulacioneswwds_18_serviciosnombre3, AV124Postulacioneswwds_19_tfpostulacionesid, AV125Postulacioneswwds_20_tfpostulacionesid_to, AV126Postulacioneswwds_21_tfserviciosid, AV127Postulacioneswwds_22_tfserviciosid_to, lV128Postulacioneswwds_23_tfserviciosnombre, AV129Postulacioneswwds_24_tfserviciosnombre_sel, AV130Postulacioneswwds_25_tfpostulacionesproveedorid, AV131Postulacioneswwds_26_tfpostulacionesproveedorid_to, lV132Postulacioneswwds_27_tfpostulacionesproveedornombre, AV133Postulacioneswwds_28_tfpostulacionesproveedornombre_sel, AV134Postulacioneswwds_29_tfpostulacionesprecio, AV135Postulacioneswwds_30_tfpostulacionesprecio_to, AV136Postulacioneswwds_31_tfpostulacionesmultimediaserial, AV137Postulacioneswwds_32_tfpostulacionesmultimediaserial_to, lV140Postulacioneswwds_35_tfpostulacionesdescripcion, AV141Postulacioneswwds_36_tfpostulacionesdescripcion_sel, lV143Postulacioneswwds_38_tfpostulacionessuministrosdescripcion, AV144Postulacioneswwds_39_tfpostulacionessuministrosdescripcion_sel, AV145Postulacioneswwds_40_tfpostulacionesfechatrabajo, AV146Postulacioneswwds_41_tfpostulacionesfechatrabajo_to, AV147Postulacioneswwds_42_tfpostulacionesfechacierre, AV148Postulacioneswwds_43_tfpostulacionesfechacierre_to, lV149Postulacioneswwds_44_tfpostulacioneshoracierre, AV150Postulacioneswwds_45_tfpostulacioneshoracierre_sel, lV151Postulacioneswwds_46_tfpostulacionestipofecha, AV152Postulacioneswwds_47_tfpostulacionestipofecha_sel, lV153Postulacioneswwds_48_tfpostulacionesrgohoraservicio, AV154Postulacioneswwds_49_tfpostulacionesrgohoraservicio_sel, lV155Postulacioneswwds_50_tfpostulacionesapellidonombre, AV156Postulacioneswwds_51_tfpostulacionesapellidonombre_sel, lV157Postulacioneswwds_52_tfpostulacionesmail, AV158Postulacioneswwds_53_tfpostulacionesmail_sel, lV159Postulacioneswwds_54_tfpostulacionestelefono, AV160Postulacioneswwds_55_tfpostulacionestelefono_sel, AV161Postulacioneswwds_56_tfpostulacionesfechaalta, AV162Postulacioneswwds_57_tfpostulacionesfechaalta_to, AV164Postulacioneswwds_59_tfpostulacionessecuserid, AV165Postulacioneswwds_60_tfpostulacionessecuserid_to});
         while ( (pr_default.getStatus(2) != 101) )
         {
            BRKLA6 = false;
            A936PostulacionesDescripcion = P00LA7_A936PostulacionesDescripcion[0];
            A948PostulacionesSecUserId = P00LA7_A948PostulacionesSecUserId[0];
            A425PostulacionesFechaAlta = P00LA7_A425PostulacionesFechaAlta[0];
            A952PostulacionesTelefono = P00LA7_A952PostulacionesTelefono[0];
            A951PostulacionesMail = P00LA7_A951PostulacionesMail[0];
            A950PostulacionesApellidoNombre = P00LA7_A950PostulacionesApellidoNombre[0];
            A949PostulacionesRgoHoraservicio = P00LA7_A949PostulacionesRgoHoraservicio[0];
            A941PostulacionesTipoFecha = P00LA7_A941PostulacionesTipoFecha[0];
            A940PostulacionesHoraCierre = P00LA7_A940PostulacionesHoraCierre[0];
            A939PostulacionesFechaCierre = P00LA7_A939PostulacionesFechaCierre[0];
            A947PostulacionesFechaTrabajo = P00LA7_A947PostulacionesFechaTrabajo[0];
            A938PostulacionesSuministrosDescri = P00LA7_A938PostulacionesSuministrosDescri[0];
            A937PostulacionesReqSuministros = P00LA7_A937PostulacionesReqSuministros[0];
            A961PostulacionesMultimediaSerial = P00LA7_A961PostulacionesMultimediaSerial[0];
            A946PostulacionesPrecio = P00LA7_A946PostulacionesPrecio[0];
            A969PostulacionesProveedorNombre = P00LA7_A969PostulacionesProveedorNombre[0];
            A943ServiciosNombre = P00LA7_A943ServiciosNombre[0];
            A942ServiciosId = P00LA7_A942ServiciosId[0];
            n942ServiciosId = P00LA7_n942ServiciosId[0];
            A422PostulacionesId = P00LA7_A422PostulacionesId[0];
            n422PostulacionesId = P00LA7_n422PostulacionesId[0];
            A945PostulacionesProveedorId = P00LA7_A945PostulacionesProveedorId[0];
            A424PostulacionesEstado = P00LA7_A424PostulacionesEstado[0];
            A970PostulacionesSolicitudesId = P00LA7_A970PostulacionesSolicitudesId[0];
            n970PostulacionesSolicitudesId = P00LA7_n970PostulacionesSolicitudesId[0];
            A943ServiciosNombre = P00LA7_A943ServiciosNombre[0];
            A969PostulacionesProveedorNombre = P00LA7_A969PostulacionesProveedorNombre[0];
            A970PostulacionesSolicitudesId = P00LA7_A970PostulacionesSolicitudesId[0];
            n970PostulacionesSolicitudesId = P00LA7_n970PostulacionesSolicitudesId[0];
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV106Postulacioneswwds_1_filterfulltext)) || ( ( StringUtil.Like( StringUtil.Str( (decimal)(A422PostulacionesId), 18, 0) , StringUtil.PadR( "%" + AV106Postulacioneswwds_1_filterfulltext , 254 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Str( (decimal)(A942ServiciosId), 18, 0) , StringUtil.PadR( "%" + AV106Postulacioneswwds_1_filterfulltext , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A943ServiciosNombre) , StringUtil.PadR( "%" + StringUtil.Upper( AV106Postulacioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Str( (decimal)(A945PostulacionesProveedorId), 18, 0) , StringUtil.PadR( "%" + AV106Postulacioneswwds_1_filterfulltext , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A969PostulacionesProveedorNombre) , StringUtil.PadR( "%" + StringUtil.Upper( AV106Postulacioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Str( A946PostulacionesPrecio, 18, 2) , StringUtil.PadR( "%" + AV106Postulacioneswwds_1_filterfulltext , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Str( (decimal)(A961PostulacionesMultimediaSerial), 4, 0) , StringUtil.PadR( "%" + AV106Postulacioneswwds_1_filterfulltext , 254 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Str( (decimal)(A970PostulacionesSolicitudesId), 18, 0) , StringUtil.PadR( "%" + AV106Postulacioneswwds_1_filterfulltext , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A936PostulacionesDescripcion) , StringUtil.PadR( "%" + StringUtil.Upper( AV106Postulacioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Upper( A938PostulacionesSuministrosDescri) , StringUtil.PadR( "%" + StringUtil.Upper( AV106Postulacioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A940PostulacionesHoraCierre) , StringUtil.PadR( "%" + StringUtil.Upper( AV106Postulacioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Upper( A941PostulacionesTipoFecha) , StringUtil.PadR( "%" + StringUtil.Upper( AV106Postulacioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A949PostulacionesRgoHoraservicio) , StringUtil.PadR( "%" + StringUtil.Upper( AV106Postulacioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Upper( A950PostulacionesApellidoNombre) , StringUtil.PadR( "%" + StringUtil.Upper( AV106Postulacioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A951PostulacionesMail) , StringUtil.PadR( "%" + StringUtil.Upper( AV106Postulacioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Upper( A952PostulacionesTelefono) , StringUtil.PadR( "%" + StringUtil.Upper( AV106Postulacioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( context.GetMessage( "habilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV106Postulacioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A424PostulacionesEstado, "HAB") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "deshabilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV106Postulacioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A424PostulacionesEstado, "DES") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "ganador", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV106Postulacioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) &&
            ( StringUtil.StrCmp(A424PostulacionesEstado, "GAN") == 0 ) ) || ( StringUtil.Like( StringUtil.Str( (decimal)(A948PostulacionesSecUserId), 18, 0) , StringUtil.PadR( "%" + AV106Postulacioneswwds_1_filterfulltext , 254 , "%"),  ' ' ) ) )
            )
            {
               AV58count = 0;
               while ( (pr_default.getStatus(2) != 101) && ( StringUtil.StrCmp(P00LA7_A936PostulacionesDescripcion[0], A936PostulacionesDescripcion) == 0 ) )
               {
                  BRKLA6 = false;
                  A422PostulacionesId = P00LA7_A422PostulacionesId[0];
                  n422PostulacionesId = P00LA7_n422PostulacionesId[0];
                  AV58count = (long)(AV58count+1);
                  BRKLA6 = true;
                  pr_default.readNext(2);
               }
               if ( (0==AV49SkipItems) )
               {
                  AV53Option = (String.IsNullOrEmpty(StringUtil.RTrim( A936PostulacionesDescripcion)) ? "<#Empty#>" : A936PostulacionesDescripcion);
                  AV54Options.Add(AV53Option, 0);
                  AV57OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV58count), "Z,ZZZ,ZZZ,ZZ9")), 0);
                  if ( AV54Options.Count == 10 )
                  {
                     /* Exit For each command. Update data (if necessary), close cursors & exit. */
                     if (true) break;
                  }
               }
               else
               {
                  AV49SkipItems = (short)(AV49SkipItems-1);
               }
            }
            if ( ! BRKLA6 )
            {
               BRKLA6 = true;
               pr_default.readNext(2);
            }
         }
         pr_default.close(2);
      }

      protected void S151( )
      {
         /* 'LOADPOSTULACIONESSUMINISTROSDESCRIPCIONOPTIONS' Routine */
         returnInSub = false;
         AV24TFPostulacionesSuministrosDescripcion = AV48SearchTxt;
         AV25TFPostulacionesSuministrosDescripcion_Sel = "";
         AV106Postulacioneswwds_1_filterfulltext = AV70FilterFullText;
         AV107Postulacioneswwds_2_dynamicfiltersselector1 = AV71DynamicFiltersSelector1;
         AV108Postulacioneswwds_3_dynamicfiltersoperator1 = AV72DynamicFiltersOperator1;
         AV109Postulacioneswwds_4_postulacionesproveedornombre1 = AV91PostulacionesProveedorNombre1;
         AV110Postulacioneswwds_5_postulacionesproveedorid1 = AV73PostulacionesProveedorId1;
         AV111Postulacioneswwds_6_serviciosnombre1 = AV74ServiciosNombre1;
         AV112Postulacioneswwds_7_dynamicfiltersenabled2 = AV75DynamicFiltersEnabled2;
         AV113Postulacioneswwds_8_dynamicfiltersselector2 = AV76DynamicFiltersSelector2;
         AV114Postulacioneswwds_9_dynamicfiltersoperator2 = AV77DynamicFiltersOperator2;
         AV115Postulacioneswwds_10_postulacionesproveedornombre2 = AV92PostulacionesProveedorNombre2;
         AV116Postulacioneswwds_11_postulacionesproveedorid2 = AV78PostulacionesProveedorId2;
         AV117Postulacioneswwds_12_serviciosnombre2 = AV79ServiciosNombre2;
         AV118Postulacioneswwds_13_dynamicfiltersenabled3 = AV80DynamicFiltersEnabled3;
         AV119Postulacioneswwds_14_dynamicfiltersselector3 = AV81DynamicFiltersSelector3;
         AV120Postulacioneswwds_15_dynamicfiltersoperator3 = AV82DynamicFiltersOperator3;
         AV121Postulacioneswwds_16_postulacionesproveedornombre3 = AV93PostulacionesProveedorNombre3;
         AV122Postulacioneswwds_17_postulacionesproveedorid3 = AV83PostulacionesProveedorId3;
         AV123Postulacioneswwds_18_serviciosnombre3 = AV84ServiciosNombre3;
         AV124Postulacioneswwds_19_tfpostulacionesid = AV11TFPostulacionesId;
         AV125Postulacioneswwds_20_tfpostulacionesid_to = AV12TFPostulacionesId_To;
         AV126Postulacioneswwds_21_tfserviciosid = AV13TFServiciosId;
         AV127Postulacioneswwds_22_tfserviciosid_to = AV14TFServiciosId_To;
         AV128Postulacioneswwds_23_tfserviciosnombre = AV15TFServiciosNombre;
         AV129Postulacioneswwds_24_tfserviciosnombre_sel = AV16TFServiciosNombre_Sel;
         AV130Postulacioneswwds_25_tfpostulacionesproveedorid = AV17TFPostulacionesProveedorId;
         AV131Postulacioneswwds_26_tfpostulacionesproveedorid_to = AV18TFPostulacionesProveedorId_To;
         AV132Postulacioneswwds_27_tfpostulacionesproveedornombre = AV85TFPostulacionesProveedorNombre;
         AV133Postulacioneswwds_28_tfpostulacionesproveedornombre_sel = AV86TFPostulacionesProveedorNombre_Sel;
         AV134Postulacioneswwds_29_tfpostulacionesprecio = AV19TFPostulacionesPrecio;
         AV135Postulacioneswwds_30_tfpostulacionesprecio_to = AV20TFPostulacionesPrecio_To;
         AV136Postulacioneswwds_31_tfpostulacionesmultimediaserial = AV87TFPostulacionesMultimediaSerial;
         AV137Postulacioneswwds_32_tfpostulacionesmultimediaserial_to = AV88TFPostulacionesMultimediaSerial_To;
         AV138Postulacioneswwds_33_tfpostulacionessolicitudesid = AV89TFPostulacionesSolicitudesId;
         AV139Postulacioneswwds_34_tfpostulacionessolicitudesid_to = AV90TFPostulacionesSolicitudesId_To;
         AV140Postulacioneswwds_35_tfpostulacionesdescripcion = AV21TFPostulacionesDescripcion;
         AV141Postulacioneswwds_36_tfpostulacionesdescripcion_sel = AV22TFPostulacionesDescripcion_Sel;
         AV142Postulacioneswwds_37_tfpostulacionesreqsuministros_sel = AV23TFPostulacionesReqSuministros_Sel;
         AV143Postulacioneswwds_38_tfpostulacionessuministrosdescripcion = AV24TFPostulacionesSuministrosDescripcion;
         AV144Postulacioneswwds_39_tfpostulacionessuministrosdescripcion_sel = AV25TFPostulacionesSuministrosDescripcion_Sel;
         AV145Postulacioneswwds_40_tfpostulacionesfechatrabajo = AV26TFPostulacionesFechaTrabajo;
         AV146Postulacioneswwds_41_tfpostulacionesfechatrabajo_to = AV27TFPostulacionesFechaTrabajo_To;
         AV147Postulacioneswwds_42_tfpostulacionesfechacierre = AV28TFPostulacionesFechaCierre;
         AV148Postulacioneswwds_43_tfpostulacionesfechacierre_to = AV29TFPostulacionesFechaCierre_To;
         AV149Postulacioneswwds_44_tfpostulacioneshoracierre = AV30TFPostulacionesHoraCierre;
         AV150Postulacioneswwds_45_tfpostulacioneshoracierre_sel = AV31TFPostulacionesHoraCierre_Sel;
         AV151Postulacioneswwds_46_tfpostulacionestipofecha = AV32TFPostulacionesTipoFecha;
         AV152Postulacioneswwds_47_tfpostulacionestipofecha_sel = AV103TFPostulacionesTipoFecha_Sel;
         AV153Postulacioneswwds_48_tfpostulacionesrgohoraservicio = AV34TFPostulacionesRgoHoraservicio;
         AV154Postulacioneswwds_49_tfpostulacionesrgohoraservicio_sel = AV35TFPostulacionesRgoHoraservicio_Sel;
         AV155Postulacioneswwds_50_tfpostulacionesapellidonombre = AV36TFPostulacionesApellidoNombre;
         AV156Postulacioneswwds_51_tfpostulacionesapellidonombre_sel = AV37TFPostulacionesApellidoNombre_Sel;
         AV157Postulacioneswwds_52_tfpostulacionesmail = AV38TFPostulacionesMail;
         AV158Postulacioneswwds_53_tfpostulacionesmail_sel = AV39TFPostulacionesMail_Sel;
         AV159Postulacioneswwds_54_tfpostulacionestelefono = AV40TFPostulacionesTelefono;
         AV160Postulacioneswwds_55_tfpostulacionestelefono_sel = AV41TFPostulacionesTelefono_Sel;
         AV161Postulacioneswwds_56_tfpostulacionesfechaalta = AV42TFPostulacionesFechaAlta;
         AV162Postulacioneswwds_57_tfpostulacionesfechaalta_to = AV43TFPostulacionesFechaAlta_To;
         AV163Postulacioneswwds_58_tfpostulacionesestado_sels = AV45TFPostulacionesEstado_Sels;
         AV164Postulacioneswwds_59_tfpostulacionessecuserid = AV46TFPostulacionesSecUserId;
         AV165Postulacioneswwds_60_tfpostulacionessecuserid_to = AV47TFPostulacionesSecUserId_To;
         pr_default.dynParam(3, new Object[]{ new Object[]{
                                              A424PostulacionesEstado ,
                                              AV163Postulacioneswwds_58_tfpostulacionesestado_sels ,
                                              AV107Postulacioneswwds_2_dynamicfiltersselector1 ,
                                              AV108Postulacioneswwds_3_dynamicfiltersoperator1 ,
                                              AV109Postulacioneswwds_4_postulacionesproveedornombre1 ,
                                              AV110Postulacioneswwds_5_postulacionesproveedorid1 ,
                                              AV111Postulacioneswwds_6_serviciosnombre1 ,
                                              AV112Postulacioneswwds_7_dynamicfiltersenabled2 ,
                                              AV113Postulacioneswwds_8_dynamicfiltersselector2 ,
                                              AV114Postulacioneswwds_9_dynamicfiltersoperator2 ,
                                              AV115Postulacioneswwds_10_postulacionesproveedornombre2 ,
                                              AV116Postulacioneswwds_11_postulacionesproveedorid2 ,
                                              AV117Postulacioneswwds_12_serviciosnombre2 ,
                                              AV118Postulacioneswwds_13_dynamicfiltersenabled3 ,
                                              AV119Postulacioneswwds_14_dynamicfiltersselector3 ,
                                              AV120Postulacioneswwds_15_dynamicfiltersoperator3 ,
                                              AV121Postulacioneswwds_16_postulacionesproveedornombre3 ,
                                              AV122Postulacioneswwds_17_postulacionesproveedorid3 ,
                                              AV123Postulacioneswwds_18_serviciosnombre3 ,
                                              AV124Postulacioneswwds_19_tfpostulacionesid ,
                                              AV125Postulacioneswwds_20_tfpostulacionesid_to ,
                                              AV126Postulacioneswwds_21_tfserviciosid ,
                                              AV127Postulacioneswwds_22_tfserviciosid_to ,
                                              AV129Postulacioneswwds_24_tfserviciosnombre_sel ,
                                              AV128Postulacioneswwds_23_tfserviciosnombre ,
                                              AV130Postulacioneswwds_25_tfpostulacionesproveedorid ,
                                              AV131Postulacioneswwds_26_tfpostulacionesproveedorid_to ,
                                              AV133Postulacioneswwds_28_tfpostulacionesproveedornombre_sel ,
                                              AV132Postulacioneswwds_27_tfpostulacionesproveedornombre ,
                                              AV134Postulacioneswwds_29_tfpostulacionesprecio ,
                                              AV135Postulacioneswwds_30_tfpostulacionesprecio_to ,
                                              AV136Postulacioneswwds_31_tfpostulacionesmultimediaserial ,
                                              AV137Postulacioneswwds_32_tfpostulacionesmultimediaserial_to ,
                                              AV141Postulacioneswwds_36_tfpostulacionesdescripcion_sel ,
                                              AV140Postulacioneswwds_35_tfpostulacionesdescripcion ,
                                              AV142Postulacioneswwds_37_tfpostulacionesreqsuministros_sel ,
                                              AV144Postulacioneswwds_39_tfpostulacionessuministrosdescripcion_sel ,
                                              AV143Postulacioneswwds_38_tfpostulacionessuministrosdescripcion ,
                                              AV145Postulacioneswwds_40_tfpostulacionesfechatrabajo ,
                                              AV146Postulacioneswwds_41_tfpostulacionesfechatrabajo_to ,
                                              AV147Postulacioneswwds_42_tfpostulacionesfechacierre ,
                                              AV148Postulacioneswwds_43_tfpostulacionesfechacierre_to ,
                                              AV150Postulacioneswwds_45_tfpostulacioneshoracierre_sel ,
                                              AV149Postulacioneswwds_44_tfpostulacioneshoracierre ,
                                              AV152Postulacioneswwds_47_tfpostulacionestipofecha_sel ,
                                              AV151Postulacioneswwds_46_tfpostulacionestipofecha ,
                                              AV154Postulacioneswwds_49_tfpostulacionesrgohoraservicio_sel ,
                                              AV153Postulacioneswwds_48_tfpostulacionesrgohoraservicio ,
                                              AV156Postulacioneswwds_51_tfpostulacionesapellidonombre_sel ,
                                              AV155Postulacioneswwds_50_tfpostulacionesapellidonombre ,
                                              AV158Postulacioneswwds_53_tfpostulacionesmail_sel ,
                                              AV157Postulacioneswwds_52_tfpostulacionesmail ,
                                              AV160Postulacioneswwds_55_tfpostulacionestelefono_sel ,
                                              AV159Postulacioneswwds_54_tfpostulacionestelefono ,
                                              AV161Postulacioneswwds_56_tfpostulacionesfechaalta ,
                                              AV162Postulacioneswwds_57_tfpostulacionesfechaalta_to ,
                                              AV163Postulacioneswwds_58_tfpostulacionesestado_sels.Count ,
                                              AV164Postulacioneswwds_59_tfpostulacionessecuserid ,
                                              AV165Postulacioneswwds_60_tfpostulacionessecuserid_to ,
                                              A969PostulacionesProveedorNombre ,
                                              A945PostulacionesProveedorId ,
                                              A943ServiciosNombre ,
                                              A422PostulacionesId ,
                                              A942ServiciosId ,
                                              A946PostulacionesPrecio ,
                                              A961PostulacionesMultimediaSerial ,
                                              A936PostulacionesDescripcion ,
                                              A937PostulacionesReqSuministros ,
                                              A938PostulacionesSuministrosDescri ,
                                              A947PostulacionesFechaTrabajo ,
                                              A939PostulacionesFechaCierre ,
                                              A940PostulacionesHoraCierre ,
                                              A941PostulacionesTipoFecha ,
                                              A949PostulacionesRgoHoraservicio ,
                                              A950PostulacionesApellidoNombre ,
                                              A951PostulacionesMail ,
                                              A952PostulacionesTelefono ,
                                              A425PostulacionesFechaAlta ,
                                              A948PostulacionesSecUserId ,
                                              AV106Postulacioneswwds_1_filterfulltext ,
                                              A970PostulacionesSolicitudesId ,
                                              AV138Postulacioneswwds_33_tfpostulacionessolicitudesid ,
                                              AV139Postulacioneswwds_34_tfpostulacionessolicitudesid_to } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG,
                                              TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.DATE,
                                              TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.INT, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG,
                                              TypeConstants.BOOLEAN, TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.LONG,
                                              TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.LONG, TypeConstants.LONG
                                              }
         });
         lV109Postulacioneswwds_4_postulacionesproveedornombre1 = StringUtil.PadR( StringUtil.RTrim( AV109Postulacioneswwds_4_postulacionesproveedornombre1), 80, "%");
         lV109Postulacioneswwds_4_postulacionesproveedornombre1 = StringUtil.PadR( StringUtil.RTrim( AV109Postulacioneswwds_4_postulacionesproveedornombre1), 80, "%");
         lV111Postulacioneswwds_6_serviciosnombre1 = StringUtil.PadR( StringUtil.RTrim( AV111Postulacioneswwds_6_serviciosnombre1), 80, "%");
         lV111Postulacioneswwds_6_serviciosnombre1 = StringUtil.PadR( StringUtil.RTrim( AV111Postulacioneswwds_6_serviciosnombre1), 80, "%");
         lV115Postulacioneswwds_10_postulacionesproveedornombre2 = StringUtil.PadR( StringUtil.RTrim( AV115Postulacioneswwds_10_postulacionesproveedornombre2), 80, "%");
         lV115Postulacioneswwds_10_postulacionesproveedornombre2 = StringUtil.PadR( StringUtil.RTrim( AV115Postulacioneswwds_10_postulacionesproveedornombre2), 80, "%");
         lV117Postulacioneswwds_12_serviciosnombre2 = StringUtil.PadR( StringUtil.RTrim( AV117Postulacioneswwds_12_serviciosnombre2), 80, "%");
         lV117Postulacioneswwds_12_serviciosnombre2 = StringUtil.PadR( StringUtil.RTrim( AV117Postulacioneswwds_12_serviciosnombre2), 80, "%");
         lV121Postulacioneswwds_16_postulacionesproveedornombre3 = StringUtil.PadR( StringUtil.RTrim( AV121Postulacioneswwds_16_postulacionesproveedornombre3), 80, "%");
         lV121Postulacioneswwds_16_postulacionesproveedornombre3 = StringUtil.PadR( StringUtil.RTrim( AV121Postulacioneswwds_16_postulacionesproveedornombre3), 80, "%");
         lV123Postulacioneswwds_18_serviciosnombre3 = StringUtil.PadR( StringUtil.RTrim( AV123Postulacioneswwds_18_serviciosnombre3), 80, "%");
         lV123Postulacioneswwds_18_serviciosnombre3 = StringUtil.PadR( StringUtil.RTrim( AV123Postulacioneswwds_18_serviciosnombre3), 80, "%");
         lV128Postulacioneswwds_23_tfserviciosnombre = StringUtil.PadR( StringUtil.RTrim( AV128Postulacioneswwds_23_tfserviciosnombre), 80, "%");
         lV132Postulacioneswwds_27_tfpostulacionesproveedornombre = StringUtil.PadR( StringUtil.RTrim( AV132Postulacioneswwds_27_tfpostulacionesproveedornombre), 80, "%");
         lV140Postulacioneswwds_35_tfpostulacionesdescripcion = StringUtil.PadR( StringUtil.RTrim( AV140Postulacioneswwds_35_tfpostulacionesdescripcion), 2000, "%");
         lV143Postulacioneswwds_38_tfpostulacionessuministrosdescripcion = StringUtil.PadR( StringUtil.RTrim( AV143Postulacioneswwds_38_tfpostulacionessuministrosdescripcion), 250, "%");
         lV149Postulacioneswwds_44_tfpostulacioneshoracierre = StringUtil.Concat( StringUtil.RTrim( AV149Postulacioneswwds_44_tfpostulacioneshoracierre), "%", "");
         lV151Postulacioneswwds_46_tfpostulacionestipofecha = StringUtil.Concat( StringUtil.RTrim( AV151Postulacioneswwds_46_tfpostulacionestipofecha), "%", "");
         lV153Postulacioneswwds_48_tfpostulacionesrgohoraservicio = StringUtil.PadR( StringUtil.RTrim( AV153Postulacioneswwds_48_tfpostulacionesrgohoraservicio), 5, "%");
         lV155Postulacioneswwds_50_tfpostulacionesapellidonombre = StringUtil.PadR( StringUtil.RTrim( AV155Postulacioneswwds_50_tfpostulacionesapellidonombre), 80, "%");
         lV157Postulacioneswwds_52_tfpostulacionesmail = StringUtil.Concat( StringUtil.RTrim( AV157Postulacioneswwds_52_tfpostulacionesmail), "%", "");
         lV159Postulacioneswwds_54_tfpostulacionestelefono = StringUtil.PadR( StringUtil.RTrim( AV159Postulacioneswwds_54_tfpostulacionestelefono), 20, "%");
         /* Using cursor P00LA9 */
         pr_default.execute(3, new Object[] {n422PostulacionesId, A422PostulacionesId, AV138Postulacioneswwds_33_tfpostulacionessolicitudesid, AV138Postulacioneswwds_33_tfpostulacionessolicitudesid, AV139Postulacioneswwds_34_tfpostulacionessolicitudesid_to, AV139Postulacioneswwds_34_tfpostulacionessolicitudesid_to, lV109Postulacioneswwds_4_postulacionesproveedornombre1, lV109Postulacioneswwds_4_postulacionesproveedornombre1, AV110Postulacioneswwds_5_postulacionesproveedorid1, AV110Postulacioneswwds_5_postulacionesproveedorid1, AV110Postulacioneswwds_5_postulacionesproveedorid1, lV111Postulacioneswwds_6_serviciosnombre1, lV111Postulacioneswwds_6_serviciosnombre1, lV115Postulacioneswwds_10_postulacionesproveedornombre2, lV115Postulacioneswwds_10_postulacionesproveedornombre2, AV116Postulacioneswwds_11_postulacionesproveedorid2, AV116Postulacioneswwds_11_postulacionesproveedorid2, AV116Postulacioneswwds_11_postulacionesproveedorid2, lV117Postulacioneswwds_12_serviciosnombre2, lV117Postulacioneswwds_12_serviciosnombre2, lV121Postulacioneswwds_16_postulacionesproveedornombre3, lV121Postulacioneswwds_16_postulacionesproveedornombre3, AV122Postulacioneswwds_17_postulacionesproveedorid3, AV122Postulacioneswwds_17_postulacionesproveedorid3, AV122Postulacioneswwds_17_postulacionesproveedorid3, lV123Postulacioneswwds_18_serviciosnombre3, lV123Postulacioneswwds_18_serviciosnombre3, AV124Postulacioneswwds_19_tfpostulacionesid, AV125Postulacioneswwds_20_tfpostulacionesid_to, AV126Postulacioneswwds_21_tfserviciosid, AV127Postulacioneswwds_22_tfserviciosid_to, lV128Postulacioneswwds_23_tfserviciosnombre, AV129Postulacioneswwds_24_tfserviciosnombre_sel, AV130Postulacioneswwds_25_tfpostulacionesproveedorid, AV131Postulacioneswwds_26_tfpostulacionesproveedorid_to, lV132Postulacioneswwds_27_tfpostulacionesproveedornombre, AV133Postulacioneswwds_28_tfpostulacionesproveedornombre_sel, AV134Postulacioneswwds_29_tfpostulacionesprecio, AV135Postulacioneswwds_30_tfpostulacionesprecio_to, AV136Postulacioneswwds_31_tfpostulacionesmultimediaserial, AV137Postulacioneswwds_32_tfpostulacionesmultimediaserial_to, lV140Postulacioneswwds_35_tfpostulacionesdescripcion, AV141Postulacioneswwds_36_tfpostulacionesdescripcion_sel, lV143Postulacioneswwds_38_tfpostulacionessuministrosdescripcion, AV144Postulacioneswwds_39_tfpostulacionessuministrosdescripcion_sel, AV145Postulacioneswwds_40_tfpostulacionesfechatrabajo, AV146Postulacioneswwds_41_tfpostulacionesfechatrabajo_to, AV147Postulacioneswwds_42_tfpostulacionesfechacierre, AV148Postulacioneswwds_43_tfpostulacionesfechacierre_to, lV149Postulacioneswwds_44_tfpostulacioneshoracierre, AV150Postulacioneswwds_45_tfpostulacioneshoracierre_sel, lV151Postulacioneswwds_46_tfpostulacionestipofecha, AV152Postulacioneswwds_47_tfpostulacionestipofecha_sel, lV153Postulacioneswwds_48_tfpostulacionesrgohoraservicio, AV154Postulacioneswwds_49_tfpostulacionesrgohoraservicio_sel, lV155Postulacioneswwds_50_tfpostulacionesapellidonombre, AV156Postulacioneswwds_51_tfpostulacionesapellidonombre_sel, lV157Postulacioneswwds_52_tfpostulacionesmail, AV158Postulacioneswwds_53_tfpostulacionesmail_sel, lV159Postulacioneswwds_54_tfpostulacionestelefono, AV160Postulacioneswwds_55_tfpostulacionestelefono_sel, AV161Postulacioneswwds_56_tfpostulacionesfechaalta, AV162Postulacioneswwds_57_tfpostulacionesfechaalta_to, AV164Postulacioneswwds_59_tfpostulacionessecuserid, AV165Postulacioneswwds_60_tfpostulacionessecuserid_to});
         while ( (pr_default.getStatus(3) != 101) )
         {
            BRKLA8 = false;
            A938PostulacionesSuministrosDescri = P00LA9_A938PostulacionesSuministrosDescri[0];
            A948PostulacionesSecUserId = P00LA9_A948PostulacionesSecUserId[0];
            A425PostulacionesFechaAlta = P00LA9_A425PostulacionesFechaAlta[0];
            A952PostulacionesTelefono = P00LA9_A952PostulacionesTelefono[0];
            A951PostulacionesMail = P00LA9_A951PostulacionesMail[0];
            A950PostulacionesApellidoNombre = P00LA9_A950PostulacionesApellidoNombre[0];
            A949PostulacionesRgoHoraservicio = P00LA9_A949PostulacionesRgoHoraservicio[0];
            A941PostulacionesTipoFecha = P00LA9_A941PostulacionesTipoFecha[0];
            A940PostulacionesHoraCierre = P00LA9_A940PostulacionesHoraCierre[0];
            A939PostulacionesFechaCierre = P00LA9_A939PostulacionesFechaCierre[0];
            A947PostulacionesFechaTrabajo = P00LA9_A947PostulacionesFechaTrabajo[0];
            A937PostulacionesReqSuministros = P00LA9_A937PostulacionesReqSuministros[0];
            A936PostulacionesDescripcion = P00LA9_A936PostulacionesDescripcion[0];
            A961PostulacionesMultimediaSerial = P00LA9_A961PostulacionesMultimediaSerial[0];
            A946PostulacionesPrecio = P00LA9_A946PostulacionesPrecio[0];
            A969PostulacionesProveedorNombre = P00LA9_A969PostulacionesProveedorNombre[0];
            A943ServiciosNombre = P00LA9_A943ServiciosNombre[0];
            A942ServiciosId = P00LA9_A942ServiciosId[0];
            n942ServiciosId = P00LA9_n942ServiciosId[0];
            A422PostulacionesId = P00LA9_A422PostulacionesId[0];
            n422PostulacionesId = P00LA9_n422PostulacionesId[0];
            A945PostulacionesProveedorId = P00LA9_A945PostulacionesProveedorId[0];
            A424PostulacionesEstado = P00LA9_A424PostulacionesEstado[0];
            A970PostulacionesSolicitudesId = P00LA9_A970PostulacionesSolicitudesId[0];
            n970PostulacionesSolicitudesId = P00LA9_n970PostulacionesSolicitudesId[0];
            A943ServiciosNombre = P00LA9_A943ServiciosNombre[0];
            A969PostulacionesProveedorNombre = P00LA9_A969PostulacionesProveedorNombre[0];
            A970PostulacionesSolicitudesId = P00LA9_A970PostulacionesSolicitudesId[0];
            n970PostulacionesSolicitudesId = P00LA9_n970PostulacionesSolicitudesId[0];
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV106Postulacioneswwds_1_filterfulltext)) || ( ( StringUtil.Like( StringUtil.Str( (decimal)(A422PostulacionesId), 18, 0) , StringUtil.PadR( "%" + AV106Postulacioneswwds_1_filterfulltext , 254 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Str( (decimal)(A942ServiciosId), 18, 0) , StringUtil.PadR( "%" + AV106Postulacioneswwds_1_filterfulltext , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A943ServiciosNombre) , StringUtil.PadR( "%" + StringUtil.Upper( AV106Postulacioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Str( (decimal)(A945PostulacionesProveedorId), 18, 0) , StringUtil.PadR( "%" + AV106Postulacioneswwds_1_filterfulltext , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A969PostulacionesProveedorNombre) , StringUtil.PadR( "%" + StringUtil.Upper( AV106Postulacioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Str( A946PostulacionesPrecio, 18, 2) , StringUtil.PadR( "%" + AV106Postulacioneswwds_1_filterfulltext , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Str( (decimal)(A961PostulacionesMultimediaSerial), 4, 0) , StringUtil.PadR( "%" + AV106Postulacioneswwds_1_filterfulltext , 254 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Str( (decimal)(A970PostulacionesSolicitudesId), 18, 0) , StringUtil.PadR( "%" + AV106Postulacioneswwds_1_filterfulltext , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A936PostulacionesDescripcion) , StringUtil.PadR( "%" + StringUtil.Upper( AV106Postulacioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Upper( A938PostulacionesSuministrosDescri) , StringUtil.PadR( "%" + StringUtil.Upper( AV106Postulacioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A940PostulacionesHoraCierre) , StringUtil.PadR( "%" + StringUtil.Upper( AV106Postulacioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Upper( A941PostulacionesTipoFecha) , StringUtil.PadR( "%" + StringUtil.Upper( AV106Postulacioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A949PostulacionesRgoHoraservicio) , StringUtil.PadR( "%" + StringUtil.Upper( AV106Postulacioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Upper( A950PostulacionesApellidoNombre) , StringUtil.PadR( "%" + StringUtil.Upper( AV106Postulacioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A951PostulacionesMail) , StringUtil.PadR( "%" + StringUtil.Upper( AV106Postulacioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Upper( A952PostulacionesTelefono) , StringUtil.PadR( "%" + StringUtil.Upper( AV106Postulacioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( context.GetMessage( "habilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV106Postulacioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A424PostulacionesEstado, "HAB") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "deshabilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV106Postulacioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A424PostulacionesEstado, "DES") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "ganador", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV106Postulacioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) &&
            ( StringUtil.StrCmp(A424PostulacionesEstado, "GAN") == 0 ) ) || ( StringUtil.Like( StringUtil.Str( (decimal)(A948PostulacionesSecUserId), 18, 0) , StringUtil.PadR( "%" + AV106Postulacioneswwds_1_filterfulltext , 254 , "%"),  ' ' ) ) )
            )
            {
               AV58count = 0;
               while ( (pr_default.getStatus(3) != 101) && ( StringUtil.StrCmp(P00LA9_A938PostulacionesSuministrosDescri[0], A938PostulacionesSuministrosDescri) == 0 ) )
               {
                  BRKLA8 = false;
                  A422PostulacionesId = P00LA9_A422PostulacionesId[0];
                  n422PostulacionesId = P00LA9_n422PostulacionesId[0];
                  AV58count = (long)(AV58count+1);
                  BRKLA8 = true;
                  pr_default.readNext(3);
               }
               if ( (0==AV49SkipItems) )
               {
                  AV53Option = (String.IsNullOrEmpty(StringUtil.RTrim( A938PostulacionesSuministrosDescri)) ? "<#Empty#>" : A938PostulacionesSuministrosDescri);
                  AV54Options.Add(AV53Option, 0);
                  AV57OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV58count), "Z,ZZZ,ZZZ,ZZ9")), 0);
                  if ( AV54Options.Count == 10 )
                  {
                     /* Exit For each command. Update data (if necessary), close cursors & exit. */
                     if (true) break;
                  }
               }
               else
               {
                  AV49SkipItems = (short)(AV49SkipItems-1);
               }
            }
            if ( ! BRKLA8 )
            {
               BRKLA8 = true;
               pr_default.readNext(3);
            }
         }
         pr_default.close(3);
      }

      protected void S161( )
      {
         /* 'LOADPOSTULACIONESHORACIERREOPTIONS' Routine */
         returnInSub = false;
         AV30TFPostulacionesHoraCierre = AV48SearchTxt;
         AV31TFPostulacionesHoraCierre_Sel = "";
         AV106Postulacioneswwds_1_filterfulltext = AV70FilterFullText;
         AV107Postulacioneswwds_2_dynamicfiltersselector1 = AV71DynamicFiltersSelector1;
         AV108Postulacioneswwds_3_dynamicfiltersoperator1 = AV72DynamicFiltersOperator1;
         AV109Postulacioneswwds_4_postulacionesproveedornombre1 = AV91PostulacionesProveedorNombre1;
         AV110Postulacioneswwds_5_postulacionesproveedorid1 = AV73PostulacionesProveedorId1;
         AV111Postulacioneswwds_6_serviciosnombre1 = AV74ServiciosNombre1;
         AV112Postulacioneswwds_7_dynamicfiltersenabled2 = AV75DynamicFiltersEnabled2;
         AV113Postulacioneswwds_8_dynamicfiltersselector2 = AV76DynamicFiltersSelector2;
         AV114Postulacioneswwds_9_dynamicfiltersoperator2 = AV77DynamicFiltersOperator2;
         AV115Postulacioneswwds_10_postulacionesproveedornombre2 = AV92PostulacionesProveedorNombre2;
         AV116Postulacioneswwds_11_postulacionesproveedorid2 = AV78PostulacionesProveedorId2;
         AV117Postulacioneswwds_12_serviciosnombre2 = AV79ServiciosNombre2;
         AV118Postulacioneswwds_13_dynamicfiltersenabled3 = AV80DynamicFiltersEnabled3;
         AV119Postulacioneswwds_14_dynamicfiltersselector3 = AV81DynamicFiltersSelector3;
         AV120Postulacioneswwds_15_dynamicfiltersoperator3 = AV82DynamicFiltersOperator3;
         AV121Postulacioneswwds_16_postulacionesproveedornombre3 = AV93PostulacionesProveedorNombre3;
         AV122Postulacioneswwds_17_postulacionesproveedorid3 = AV83PostulacionesProveedorId3;
         AV123Postulacioneswwds_18_serviciosnombre3 = AV84ServiciosNombre3;
         AV124Postulacioneswwds_19_tfpostulacionesid = AV11TFPostulacionesId;
         AV125Postulacioneswwds_20_tfpostulacionesid_to = AV12TFPostulacionesId_To;
         AV126Postulacioneswwds_21_tfserviciosid = AV13TFServiciosId;
         AV127Postulacioneswwds_22_tfserviciosid_to = AV14TFServiciosId_To;
         AV128Postulacioneswwds_23_tfserviciosnombre = AV15TFServiciosNombre;
         AV129Postulacioneswwds_24_tfserviciosnombre_sel = AV16TFServiciosNombre_Sel;
         AV130Postulacioneswwds_25_tfpostulacionesproveedorid = AV17TFPostulacionesProveedorId;
         AV131Postulacioneswwds_26_tfpostulacionesproveedorid_to = AV18TFPostulacionesProveedorId_To;
         AV132Postulacioneswwds_27_tfpostulacionesproveedornombre = AV85TFPostulacionesProveedorNombre;
         AV133Postulacioneswwds_28_tfpostulacionesproveedornombre_sel = AV86TFPostulacionesProveedorNombre_Sel;
         AV134Postulacioneswwds_29_tfpostulacionesprecio = AV19TFPostulacionesPrecio;
         AV135Postulacioneswwds_30_tfpostulacionesprecio_to = AV20TFPostulacionesPrecio_To;
         AV136Postulacioneswwds_31_tfpostulacionesmultimediaserial = AV87TFPostulacionesMultimediaSerial;
         AV137Postulacioneswwds_32_tfpostulacionesmultimediaserial_to = AV88TFPostulacionesMultimediaSerial_To;
         AV138Postulacioneswwds_33_tfpostulacionessolicitudesid = AV89TFPostulacionesSolicitudesId;
         AV139Postulacioneswwds_34_tfpostulacionessolicitudesid_to = AV90TFPostulacionesSolicitudesId_To;
         AV140Postulacioneswwds_35_tfpostulacionesdescripcion = AV21TFPostulacionesDescripcion;
         AV141Postulacioneswwds_36_tfpostulacionesdescripcion_sel = AV22TFPostulacionesDescripcion_Sel;
         AV142Postulacioneswwds_37_tfpostulacionesreqsuministros_sel = AV23TFPostulacionesReqSuministros_Sel;
         AV143Postulacioneswwds_38_tfpostulacionessuministrosdescripcion = AV24TFPostulacionesSuministrosDescripcion;
         AV144Postulacioneswwds_39_tfpostulacionessuministrosdescripcion_sel = AV25TFPostulacionesSuministrosDescripcion_Sel;
         AV145Postulacioneswwds_40_tfpostulacionesfechatrabajo = AV26TFPostulacionesFechaTrabajo;
         AV146Postulacioneswwds_41_tfpostulacionesfechatrabajo_to = AV27TFPostulacionesFechaTrabajo_To;
         AV147Postulacioneswwds_42_tfpostulacionesfechacierre = AV28TFPostulacionesFechaCierre;
         AV148Postulacioneswwds_43_tfpostulacionesfechacierre_to = AV29TFPostulacionesFechaCierre_To;
         AV149Postulacioneswwds_44_tfpostulacioneshoracierre = AV30TFPostulacionesHoraCierre;
         AV150Postulacioneswwds_45_tfpostulacioneshoracierre_sel = AV31TFPostulacionesHoraCierre_Sel;
         AV151Postulacioneswwds_46_tfpostulacionestipofecha = AV32TFPostulacionesTipoFecha;
         AV152Postulacioneswwds_47_tfpostulacionestipofecha_sel = AV103TFPostulacionesTipoFecha_Sel;
         AV153Postulacioneswwds_48_tfpostulacionesrgohoraservicio = AV34TFPostulacionesRgoHoraservicio;
         AV154Postulacioneswwds_49_tfpostulacionesrgohoraservicio_sel = AV35TFPostulacionesRgoHoraservicio_Sel;
         AV155Postulacioneswwds_50_tfpostulacionesapellidonombre = AV36TFPostulacionesApellidoNombre;
         AV156Postulacioneswwds_51_tfpostulacionesapellidonombre_sel = AV37TFPostulacionesApellidoNombre_Sel;
         AV157Postulacioneswwds_52_tfpostulacionesmail = AV38TFPostulacionesMail;
         AV158Postulacioneswwds_53_tfpostulacionesmail_sel = AV39TFPostulacionesMail_Sel;
         AV159Postulacioneswwds_54_tfpostulacionestelefono = AV40TFPostulacionesTelefono;
         AV160Postulacioneswwds_55_tfpostulacionestelefono_sel = AV41TFPostulacionesTelefono_Sel;
         AV161Postulacioneswwds_56_tfpostulacionesfechaalta = AV42TFPostulacionesFechaAlta;
         AV162Postulacioneswwds_57_tfpostulacionesfechaalta_to = AV43TFPostulacionesFechaAlta_To;
         AV163Postulacioneswwds_58_tfpostulacionesestado_sels = AV45TFPostulacionesEstado_Sels;
         AV164Postulacioneswwds_59_tfpostulacionessecuserid = AV46TFPostulacionesSecUserId;
         AV165Postulacioneswwds_60_tfpostulacionessecuserid_to = AV47TFPostulacionesSecUserId_To;
         pr_default.dynParam(4, new Object[]{ new Object[]{
                                              A424PostulacionesEstado ,
                                              AV163Postulacioneswwds_58_tfpostulacionesestado_sels ,
                                              AV107Postulacioneswwds_2_dynamicfiltersselector1 ,
                                              AV108Postulacioneswwds_3_dynamicfiltersoperator1 ,
                                              AV109Postulacioneswwds_4_postulacionesproveedornombre1 ,
                                              AV110Postulacioneswwds_5_postulacionesproveedorid1 ,
                                              AV111Postulacioneswwds_6_serviciosnombre1 ,
                                              AV112Postulacioneswwds_7_dynamicfiltersenabled2 ,
                                              AV113Postulacioneswwds_8_dynamicfiltersselector2 ,
                                              AV114Postulacioneswwds_9_dynamicfiltersoperator2 ,
                                              AV115Postulacioneswwds_10_postulacionesproveedornombre2 ,
                                              AV116Postulacioneswwds_11_postulacionesproveedorid2 ,
                                              AV117Postulacioneswwds_12_serviciosnombre2 ,
                                              AV118Postulacioneswwds_13_dynamicfiltersenabled3 ,
                                              AV119Postulacioneswwds_14_dynamicfiltersselector3 ,
                                              AV120Postulacioneswwds_15_dynamicfiltersoperator3 ,
                                              AV121Postulacioneswwds_16_postulacionesproveedornombre3 ,
                                              AV122Postulacioneswwds_17_postulacionesproveedorid3 ,
                                              AV123Postulacioneswwds_18_serviciosnombre3 ,
                                              AV124Postulacioneswwds_19_tfpostulacionesid ,
                                              AV125Postulacioneswwds_20_tfpostulacionesid_to ,
                                              AV126Postulacioneswwds_21_tfserviciosid ,
                                              AV127Postulacioneswwds_22_tfserviciosid_to ,
                                              AV129Postulacioneswwds_24_tfserviciosnombre_sel ,
                                              AV128Postulacioneswwds_23_tfserviciosnombre ,
                                              AV130Postulacioneswwds_25_tfpostulacionesproveedorid ,
                                              AV131Postulacioneswwds_26_tfpostulacionesproveedorid_to ,
                                              AV133Postulacioneswwds_28_tfpostulacionesproveedornombre_sel ,
                                              AV132Postulacioneswwds_27_tfpostulacionesproveedornombre ,
                                              AV134Postulacioneswwds_29_tfpostulacionesprecio ,
                                              AV135Postulacioneswwds_30_tfpostulacionesprecio_to ,
                                              AV136Postulacioneswwds_31_tfpostulacionesmultimediaserial ,
                                              AV137Postulacioneswwds_32_tfpostulacionesmultimediaserial_to ,
                                              AV141Postulacioneswwds_36_tfpostulacionesdescripcion_sel ,
                                              AV140Postulacioneswwds_35_tfpostulacionesdescripcion ,
                                              AV142Postulacioneswwds_37_tfpostulacionesreqsuministros_sel ,
                                              AV144Postulacioneswwds_39_tfpostulacionessuministrosdescripcion_sel ,
                                              AV143Postulacioneswwds_38_tfpostulacionessuministrosdescripcion ,
                                              AV145Postulacioneswwds_40_tfpostulacionesfechatrabajo ,
                                              AV146Postulacioneswwds_41_tfpostulacionesfechatrabajo_to ,
                                              AV147Postulacioneswwds_42_tfpostulacionesfechacierre ,
                                              AV148Postulacioneswwds_43_tfpostulacionesfechacierre_to ,
                                              AV150Postulacioneswwds_45_tfpostulacioneshoracierre_sel ,
                                              AV149Postulacioneswwds_44_tfpostulacioneshoracierre ,
                                              AV152Postulacioneswwds_47_tfpostulacionestipofecha_sel ,
                                              AV151Postulacioneswwds_46_tfpostulacionestipofecha ,
                                              AV154Postulacioneswwds_49_tfpostulacionesrgohoraservicio_sel ,
                                              AV153Postulacioneswwds_48_tfpostulacionesrgohoraservicio ,
                                              AV156Postulacioneswwds_51_tfpostulacionesapellidonombre_sel ,
                                              AV155Postulacioneswwds_50_tfpostulacionesapellidonombre ,
                                              AV158Postulacioneswwds_53_tfpostulacionesmail_sel ,
                                              AV157Postulacioneswwds_52_tfpostulacionesmail ,
                                              AV160Postulacioneswwds_55_tfpostulacionestelefono_sel ,
                                              AV159Postulacioneswwds_54_tfpostulacionestelefono ,
                                              AV161Postulacioneswwds_56_tfpostulacionesfechaalta ,
                                              AV162Postulacioneswwds_57_tfpostulacionesfechaalta_to ,
                                              AV163Postulacioneswwds_58_tfpostulacionesestado_sels.Count ,
                                              AV164Postulacioneswwds_59_tfpostulacionessecuserid ,
                                              AV165Postulacioneswwds_60_tfpostulacionessecuserid_to ,
                                              A969PostulacionesProveedorNombre ,
                                              A945PostulacionesProveedorId ,
                                              A943ServiciosNombre ,
                                              A422PostulacionesId ,
                                              A942ServiciosId ,
                                              A946PostulacionesPrecio ,
                                              A961PostulacionesMultimediaSerial ,
                                              A936PostulacionesDescripcion ,
                                              A937PostulacionesReqSuministros ,
                                              A938PostulacionesSuministrosDescri ,
                                              A947PostulacionesFechaTrabajo ,
                                              A939PostulacionesFechaCierre ,
                                              A940PostulacionesHoraCierre ,
                                              A941PostulacionesTipoFecha ,
                                              A949PostulacionesRgoHoraservicio ,
                                              A950PostulacionesApellidoNombre ,
                                              A951PostulacionesMail ,
                                              A952PostulacionesTelefono ,
                                              A425PostulacionesFechaAlta ,
                                              A948PostulacionesSecUserId ,
                                              AV106Postulacioneswwds_1_filterfulltext ,
                                              A970PostulacionesSolicitudesId ,
                                              AV138Postulacioneswwds_33_tfpostulacionessolicitudesid ,
                                              AV139Postulacioneswwds_34_tfpostulacionessolicitudesid_to } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG,
                                              TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.DATE,
                                              TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.INT, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG,
                                              TypeConstants.BOOLEAN, TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.LONG,
                                              TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.LONG, TypeConstants.LONG
                                              }
         });
         lV109Postulacioneswwds_4_postulacionesproveedornombre1 = StringUtil.PadR( StringUtil.RTrim( AV109Postulacioneswwds_4_postulacionesproveedornombre1), 80, "%");
         lV109Postulacioneswwds_4_postulacionesproveedornombre1 = StringUtil.PadR( StringUtil.RTrim( AV109Postulacioneswwds_4_postulacionesproveedornombre1), 80, "%");
         lV111Postulacioneswwds_6_serviciosnombre1 = StringUtil.PadR( StringUtil.RTrim( AV111Postulacioneswwds_6_serviciosnombre1), 80, "%");
         lV111Postulacioneswwds_6_serviciosnombre1 = StringUtil.PadR( StringUtil.RTrim( AV111Postulacioneswwds_6_serviciosnombre1), 80, "%");
         lV115Postulacioneswwds_10_postulacionesproveedornombre2 = StringUtil.PadR( StringUtil.RTrim( AV115Postulacioneswwds_10_postulacionesproveedornombre2), 80, "%");
         lV115Postulacioneswwds_10_postulacionesproveedornombre2 = StringUtil.PadR( StringUtil.RTrim( AV115Postulacioneswwds_10_postulacionesproveedornombre2), 80, "%");
         lV117Postulacioneswwds_12_serviciosnombre2 = StringUtil.PadR( StringUtil.RTrim( AV117Postulacioneswwds_12_serviciosnombre2), 80, "%");
         lV117Postulacioneswwds_12_serviciosnombre2 = StringUtil.PadR( StringUtil.RTrim( AV117Postulacioneswwds_12_serviciosnombre2), 80, "%");
         lV121Postulacioneswwds_16_postulacionesproveedornombre3 = StringUtil.PadR( StringUtil.RTrim( AV121Postulacioneswwds_16_postulacionesproveedornombre3), 80, "%");
         lV121Postulacioneswwds_16_postulacionesproveedornombre3 = StringUtil.PadR( StringUtil.RTrim( AV121Postulacioneswwds_16_postulacionesproveedornombre3), 80, "%");
         lV123Postulacioneswwds_18_serviciosnombre3 = StringUtil.PadR( StringUtil.RTrim( AV123Postulacioneswwds_18_serviciosnombre3), 80, "%");
         lV123Postulacioneswwds_18_serviciosnombre3 = StringUtil.PadR( StringUtil.RTrim( AV123Postulacioneswwds_18_serviciosnombre3), 80, "%");
         lV128Postulacioneswwds_23_tfserviciosnombre = StringUtil.PadR( StringUtil.RTrim( AV128Postulacioneswwds_23_tfserviciosnombre), 80, "%");
         lV132Postulacioneswwds_27_tfpostulacionesproveedornombre = StringUtil.PadR( StringUtil.RTrim( AV132Postulacioneswwds_27_tfpostulacionesproveedornombre), 80, "%");
         lV140Postulacioneswwds_35_tfpostulacionesdescripcion = StringUtil.PadR( StringUtil.RTrim( AV140Postulacioneswwds_35_tfpostulacionesdescripcion), 2000, "%");
         lV143Postulacioneswwds_38_tfpostulacionessuministrosdescripcion = StringUtil.PadR( StringUtil.RTrim( AV143Postulacioneswwds_38_tfpostulacionessuministrosdescripcion), 250, "%");
         lV149Postulacioneswwds_44_tfpostulacioneshoracierre = StringUtil.Concat( StringUtil.RTrim( AV149Postulacioneswwds_44_tfpostulacioneshoracierre), "%", "");
         lV151Postulacioneswwds_46_tfpostulacionestipofecha = StringUtil.Concat( StringUtil.RTrim( AV151Postulacioneswwds_46_tfpostulacionestipofecha), "%", "");
         lV153Postulacioneswwds_48_tfpostulacionesrgohoraservicio = StringUtil.PadR( StringUtil.RTrim( AV153Postulacioneswwds_48_tfpostulacionesrgohoraservicio), 5, "%");
         lV155Postulacioneswwds_50_tfpostulacionesapellidonombre = StringUtil.PadR( StringUtil.RTrim( AV155Postulacioneswwds_50_tfpostulacionesapellidonombre), 80, "%");
         lV157Postulacioneswwds_52_tfpostulacionesmail = StringUtil.Concat( StringUtil.RTrim( AV157Postulacioneswwds_52_tfpostulacionesmail), "%", "");
         lV159Postulacioneswwds_54_tfpostulacionestelefono = StringUtil.PadR( StringUtil.RTrim( AV159Postulacioneswwds_54_tfpostulacionestelefono), 20, "%");
         /* Using cursor P00LA11 */
         pr_default.execute(4, new Object[] {n422PostulacionesId, A422PostulacionesId, AV138Postulacioneswwds_33_tfpostulacionessolicitudesid, AV138Postulacioneswwds_33_tfpostulacionessolicitudesid, AV139Postulacioneswwds_34_tfpostulacionessolicitudesid_to, AV139Postulacioneswwds_34_tfpostulacionessolicitudesid_to, lV109Postulacioneswwds_4_postulacionesproveedornombre1, lV109Postulacioneswwds_4_postulacionesproveedornombre1, AV110Postulacioneswwds_5_postulacionesproveedorid1, AV110Postulacioneswwds_5_postulacionesproveedorid1, AV110Postulacioneswwds_5_postulacionesproveedorid1, lV111Postulacioneswwds_6_serviciosnombre1, lV111Postulacioneswwds_6_serviciosnombre1, lV115Postulacioneswwds_10_postulacionesproveedornombre2, lV115Postulacioneswwds_10_postulacionesproveedornombre2, AV116Postulacioneswwds_11_postulacionesproveedorid2, AV116Postulacioneswwds_11_postulacionesproveedorid2, AV116Postulacioneswwds_11_postulacionesproveedorid2, lV117Postulacioneswwds_12_serviciosnombre2, lV117Postulacioneswwds_12_serviciosnombre2, lV121Postulacioneswwds_16_postulacionesproveedornombre3, lV121Postulacioneswwds_16_postulacionesproveedornombre3, AV122Postulacioneswwds_17_postulacionesproveedorid3, AV122Postulacioneswwds_17_postulacionesproveedorid3, AV122Postulacioneswwds_17_postulacionesproveedorid3, lV123Postulacioneswwds_18_serviciosnombre3, lV123Postulacioneswwds_18_serviciosnombre3, AV124Postulacioneswwds_19_tfpostulacionesid, AV125Postulacioneswwds_20_tfpostulacionesid_to, AV126Postulacioneswwds_21_tfserviciosid, AV127Postulacioneswwds_22_tfserviciosid_to, lV128Postulacioneswwds_23_tfserviciosnombre, AV129Postulacioneswwds_24_tfserviciosnombre_sel, AV130Postulacioneswwds_25_tfpostulacionesproveedorid, AV131Postulacioneswwds_26_tfpostulacionesproveedorid_to, lV132Postulacioneswwds_27_tfpostulacionesproveedornombre, AV133Postulacioneswwds_28_tfpostulacionesproveedornombre_sel, AV134Postulacioneswwds_29_tfpostulacionesprecio, AV135Postulacioneswwds_30_tfpostulacionesprecio_to, AV136Postulacioneswwds_31_tfpostulacionesmultimediaserial, AV137Postulacioneswwds_32_tfpostulacionesmultimediaserial_to, lV140Postulacioneswwds_35_tfpostulacionesdescripcion, AV141Postulacioneswwds_36_tfpostulacionesdescripcion_sel, lV143Postulacioneswwds_38_tfpostulacionessuministrosdescripcion, AV144Postulacioneswwds_39_tfpostulacionessuministrosdescripcion_sel, AV145Postulacioneswwds_40_tfpostulacionesfechatrabajo, AV146Postulacioneswwds_41_tfpostulacionesfechatrabajo_to, AV147Postulacioneswwds_42_tfpostulacionesfechacierre, AV148Postulacioneswwds_43_tfpostulacionesfechacierre_to, lV149Postulacioneswwds_44_tfpostulacioneshoracierre, AV150Postulacioneswwds_45_tfpostulacioneshoracierre_sel, lV151Postulacioneswwds_46_tfpostulacionestipofecha, AV152Postulacioneswwds_47_tfpostulacionestipofecha_sel, lV153Postulacioneswwds_48_tfpostulacionesrgohoraservicio, AV154Postulacioneswwds_49_tfpostulacionesrgohoraservicio_sel, lV155Postulacioneswwds_50_tfpostulacionesapellidonombre, AV156Postulacioneswwds_51_tfpostulacionesapellidonombre_sel, lV157Postulacioneswwds_52_tfpostulacionesmail, AV158Postulacioneswwds_53_tfpostulacionesmail_sel, lV159Postulacioneswwds_54_tfpostulacionestelefono, AV160Postulacioneswwds_55_tfpostulacionestelefono_sel, AV161Postulacioneswwds_56_tfpostulacionesfechaalta, AV162Postulacioneswwds_57_tfpostulacionesfechaalta_to, AV164Postulacioneswwds_59_tfpostulacionessecuserid, AV165Postulacioneswwds_60_tfpostulacionessecuserid_to});
         while ( (pr_default.getStatus(4) != 101) )
         {
            BRKLA10 = false;
            A940PostulacionesHoraCierre = P00LA11_A940PostulacionesHoraCierre[0];
            A948PostulacionesSecUserId = P00LA11_A948PostulacionesSecUserId[0];
            A425PostulacionesFechaAlta = P00LA11_A425PostulacionesFechaAlta[0];
            A952PostulacionesTelefono = P00LA11_A952PostulacionesTelefono[0];
            A951PostulacionesMail = P00LA11_A951PostulacionesMail[0];
            A950PostulacionesApellidoNombre = P00LA11_A950PostulacionesApellidoNombre[0];
            A949PostulacionesRgoHoraservicio = P00LA11_A949PostulacionesRgoHoraservicio[0];
            A941PostulacionesTipoFecha = P00LA11_A941PostulacionesTipoFecha[0];
            A939PostulacionesFechaCierre = P00LA11_A939PostulacionesFechaCierre[0];
            A947PostulacionesFechaTrabajo = P00LA11_A947PostulacionesFechaTrabajo[0];
            A938PostulacionesSuministrosDescri = P00LA11_A938PostulacionesSuministrosDescri[0];
            A937PostulacionesReqSuministros = P00LA11_A937PostulacionesReqSuministros[0];
            A936PostulacionesDescripcion = P00LA11_A936PostulacionesDescripcion[0];
            A961PostulacionesMultimediaSerial = P00LA11_A961PostulacionesMultimediaSerial[0];
            A946PostulacionesPrecio = P00LA11_A946PostulacionesPrecio[0];
            A969PostulacionesProveedorNombre = P00LA11_A969PostulacionesProveedorNombre[0];
            A943ServiciosNombre = P00LA11_A943ServiciosNombre[0];
            A942ServiciosId = P00LA11_A942ServiciosId[0];
            n942ServiciosId = P00LA11_n942ServiciosId[0];
            A422PostulacionesId = P00LA11_A422PostulacionesId[0];
            n422PostulacionesId = P00LA11_n422PostulacionesId[0];
            A945PostulacionesProveedorId = P00LA11_A945PostulacionesProveedorId[0];
            A424PostulacionesEstado = P00LA11_A424PostulacionesEstado[0];
            A970PostulacionesSolicitudesId = P00LA11_A970PostulacionesSolicitudesId[0];
            n970PostulacionesSolicitudesId = P00LA11_n970PostulacionesSolicitudesId[0];
            A943ServiciosNombre = P00LA11_A943ServiciosNombre[0];
            A969PostulacionesProveedorNombre = P00LA11_A969PostulacionesProveedorNombre[0];
            A970PostulacionesSolicitudesId = P00LA11_A970PostulacionesSolicitudesId[0];
            n970PostulacionesSolicitudesId = P00LA11_n970PostulacionesSolicitudesId[0];
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV106Postulacioneswwds_1_filterfulltext)) || ( ( StringUtil.Like( StringUtil.Str( (decimal)(A422PostulacionesId), 18, 0) , StringUtil.PadR( "%" + AV106Postulacioneswwds_1_filterfulltext , 254 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Str( (decimal)(A942ServiciosId), 18, 0) , StringUtil.PadR( "%" + AV106Postulacioneswwds_1_filterfulltext , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A943ServiciosNombre) , StringUtil.PadR( "%" + StringUtil.Upper( AV106Postulacioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Str( (decimal)(A945PostulacionesProveedorId), 18, 0) , StringUtil.PadR( "%" + AV106Postulacioneswwds_1_filterfulltext , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A969PostulacionesProveedorNombre) , StringUtil.PadR( "%" + StringUtil.Upper( AV106Postulacioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Str( A946PostulacionesPrecio, 18, 2) , StringUtil.PadR( "%" + AV106Postulacioneswwds_1_filterfulltext , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Str( (decimal)(A961PostulacionesMultimediaSerial), 4, 0) , StringUtil.PadR( "%" + AV106Postulacioneswwds_1_filterfulltext , 254 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Str( (decimal)(A970PostulacionesSolicitudesId), 18, 0) , StringUtil.PadR( "%" + AV106Postulacioneswwds_1_filterfulltext , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A936PostulacionesDescripcion) , StringUtil.PadR( "%" + StringUtil.Upper( AV106Postulacioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Upper( A938PostulacionesSuministrosDescri) , StringUtil.PadR( "%" + StringUtil.Upper( AV106Postulacioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A940PostulacionesHoraCierre) , StringUtil.PadR( "%" + StringUtil.Upper( AV106Postulacioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Upper( A941PostulacionesTipoFecha) , StringUtil.PadR( "%" + StringUtil.Upper( AV106Postulacioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A949PostulacionesRgoHoraservicio) , StringUtil.PadR( "%" + StringUtil.Upper( AV106Postulacioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Upper( A950PostulacionesApellidoNombre) , StringUtil.PadR( "%" + StringUtil.Upper( AV106Postulacioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A951PostulacionesMail) , StringUtil.PadR( "%" + StringUtil.Upper( AV106Postulacioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Upper( A952PostulacionesTelefono) , StringUtil.PadR( "%" + StringUtil.Upper( AV106Postulacioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( context.GetMessage( "habilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV106Postulacioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A424PostulacionesEstado, "HAB") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "deshabilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV106Postulacioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A424PostulacionesEstado, "DES") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "ganador", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV106Postulacioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) &&
            ( StringUtil.StrCmp(A424PostulacionesEstado, "GAN") == 0 ) ) || ( StringUtil.Like( StringUtil.Str( (decimal)(A948PostulacionesSecUserId), 18, 0) , StringUtil.PadR( "%" + AV106Postulacioneswwds_1_filterfulltext , 254 , "%"),  ' ' ) ) )
            )
            {
               AV58count = 0;
               while ( (pr_default.getStatus(4) != 101) && ( StringUtil.StrCmp(P00LA11_A940PostulacionesHoraCierre[0], A940PostulacionesHoraCierre) == 0 ) )
               {
                  BRKLA10 = false;
                  A422PostulacionesId = P00LA11_A422PostulacionesId[0];
                  n422PostulacionesId = P00LA11_n422PostulacionesId[0];
                  AV58count = (long)(AV58count+1);
                  BRKLA10 = true;
                  pr_default.readNext(4);
               }
               if ( (0==AV49SkipItems) )
               {
                  AV53Option = (String.IsNullOrEmpty(StringUtil.RTrim( A940PostulacionesHoraCierre)) ? "<#Empty#>" : A940PostulacionesHoraCierre);
                  AV54Options.Add(AV53Option, 0);
                  AV57OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV58count), "Z,ZZZ,ZZZ,ZZ9")), 0);
                  if ( AV54Options.Count == 10 )
                  {
                     /* Exit For each command. Update data (if necessary), close cursors & exit. */
                     if (true) break;
                  }
               }
               else
               {
                  AV49SkipItems = (short)(AV49SkipItems-1);
               }
            }
            if ( ! BRKLA10 )
            {
               BRKLA10 = true;
               pr_default.readNext(4);
            }
         }
         pr_default.close(4);
      }

      protected void S171( )
      {
         /* 'LOADPOSTULACIONESTIPOFECHAOPTIONS' Routine */
         returnInSub = false;
         AV32TFPostulacionesTipoFecha = AV48SearchTxt;
         AV103TFPostulacionesTipoFecha_Sel = "";
         AV106Postulacioneswwds_1_filterfulltext = AV70FilterFullText;
         AV107Postulacioneswwds_2_dynamicfiltersselector1 = AV71DynamicFiltersSelector1;
         AV108Postulacioneswwds_3_dynamicfiltersoperator1 = AV72DynamicFiltersOperator1;
         AV109Postulacioneswwds_4_postulacionesproveedornombre1 = AV91PostulacionesProveedorNombre1;
         AV110Postulacioneswwds_5_postulacionesproveedorid1 = AV73PostulacionesProveedorId1;
         AV111Postulacioneswwds_6_serviciosnombre1 = AV74ServiciosNombre1;
         AV112Postulacioneswwds_7_dynamicfiltersenabled2 = AV75DynamicFiltersEnabled2;
         AV113Postulacioneswwds_8_dynamicfiltersselector2 = AV76DynamicFiltersSelector2;
         AV114Postulacioneswwds_9_dynamicfiltersoperator2 = AV77DynamicFiltersOperator2;
         AV115Postulacioneswwds_10_postulacionesproveedornombre2 = AV92PostulacionesProveedorNombre2;
         AV116Postulacioneswwds_11_postulacionesproveedorid2 = AV78PostulacionesProveedorId2;
         AV117Postulacioneswwds_12_serviciosnombre2 = AV79ServiciosNombre2;
         AV118Postulacioneswwds_13_dynamicfiltersenabled3 = AV80DynamicFiltersEnabled3;
         AV119Postulacioneswwds_14_dynamicfiltersselector3 = AV81DynamicFiltersSelector3;
         AV120Postulacioneswwds_15_dynamicfiltersoperator3 = AV82DynamicFiltersOperator3;
         AV121Postulacioneswwds_16_postulacionesproveedornombre3 = AV93PostulacionesProveedorNombre3;
         AV122Postulacioneswwds_17_postulacionesproveedorid3 = AV83PostulacionesProveedorId3;
         AV123Postulacioneswwds_18_serviciosnombre3 = AV84ServiciosNombre3;
         AV124Postulacioneswwds_19_tfpostulacionesid = AV11TFPostulacionesId;
         AV125Postulacioneswwds_20_tfpostulacionesid_to = AV12TFPostulacionesId_To;
         AV126Postulacioneswwds_21_tfserviciosid = AV13TFServiciosId;
         AV127Postulacioneswwds_22_tfserviciosid_to = AV14TFServiciosId_To;
         AV128Postulacioneswwds_23_tfserviciosnombre = AV15TFServiciosNombre;
         AV129Postulacioneswwds_24_tfserviciosnombre_sel = AV16TFServiciosNombre_Sel;
         AV130Postulacioneswwds_25_tfpostulacionesproveedorid = AV17TFPostulacionesProveedorId;
         AV131Postulacioneswwds_26_tfpostulacionesproveedorid_to = AV18TFPostulacionesProveedorId_To;
         AV132Postulacioneswwds_27_tfpostulacionesproveedornombre = AV85TFPostulacionesProveedorNombre;
         AV133Postulacioneswwds_28_tfpostulacionesproveedornombre_sel = AV86TFPostulacionesProveedorNombre_Sel;
         AV134Postulacioneswwds_29_tfpostulacionesprecio = AV19TFPostulacionesPrecio;
         AV135Postulacioneswwds_30_tfpostulacionesprecio_to = AV20TFPostulacionesPrecio_To;
         AV136Postulacioneswwds_31_tfpostulacionesmultimediaserial = AV87TFPostulacionesMultimediaSerial;
         AV137Postulacioneswwds_32_tfpostulacionesmultimediaserial_to = AV88TFPostulacionesMultimediaSerial_To;
         AV138Postulacioneswwds_33_tfpostulacionessolicitudesid = AV89TFPostulacionesSolicitudesId;
         AV139Postulacioneswwds_34_tfpostulacionessolicitudesid_to = AV90TFPostulacionesSolicitudesId_To;
         AV140Postulacioneswwds_35_tfpostulacionesdescripcion = AV21TFPostulacionesDescripcion;
         AV141Postulacioneswwds_36_tfpostulacionesdescripcion_sel = AV22TFPostulacionesDescripcion_Sel;
         AV142Postulacioneswwds_37_tfpostulacionesreqsuministros_sel = AV23TFPostulacionesReqSuministros_Sel;
         AV143Postulacioneswwds_38_tfpostulacionessuministrosdescripcion = AV24TFPostulacionesSuministrosDescripcion;
         AV144Postulacioneswwds_39_tfpostulacionessuministrosdescripcion_sel = AV25TFPostulacionesSuministrosDescripcion_Sel;
         AV145Postulacioneswwds_40_tfpostulacionesfechatrabajo = AV26TFPostulacionesFechaTrabajo;
         AV146Postulacioneswwds_41_tfpostulacionesfechatrabajo_to = AV27TFPostulacionesFechaTrabajo_To;
         AV147Postulacioneswwds_42_tfpostulacionesfechacierre = AV28TFPostulacionesFechaCierre;
         AV148Postulacioneswwds_43_tfpostulacionesfechacierre_to = AV29TFPostulacionesFechaCierre_To;
         AV149Postulacioneswwds_44_tfpostulacioneshoracierre = AV30TFPostulacionesHoraCierre;
         AV150Postulacioneswwds_45_tfpostulacioneshoracierre_sel = AV31TFPostulacionesHoraCierre_Sel;
         AV151Postulacioneswwds_46_tfpostulacionestipofecha = AV32TFPostulacionesTipoFecha;
         AV152Postulacioneswwds_47_tfpostulacionestipofecha_sel = AV103TFPostulacionesTipoFecha_Sel;
         AV153Postulacioneswwds_48_tfpostulacionesrgohoraservicio = AV34TFPostulacionesRgoHoraservicio;
         AV154Postulacioneswwds_49_tfpostulacionesrgohoraservicio_sel = AV35TFPostulacionesRgoHoraservicio_Sel;
         AV155Postulacioneswwds_50_tfpostulacionesapellidonombre = AV36TFPostulacionesApellidoNombre;
         AV156Postulacioneswwds_51_tfpostulacionesapellidonombre_sel = AV37TFPostulacionesApellidoNombre_Sel;
         AV157Postulacioneswwds_52_tfpostulacionesmail = AV38TFPostulacionesMail;
         AV158Postulacioneswwds_53_tfpostulacionesmail_sel = AV39TFPostulacionesMail_Sel;
         AV159Postulacioneswwds_54_tfpostulacionestelefono = AV40TFPostulacionesTelefono;
         AV160Postulacioneswwds_55_tfpostulacionestelefono_sel = AV41TFPostulacionesTelefono_Sel;
         AV161Postulacioneswwds_56_tfpostulacionesfechaalta = AV42TFPostulacionesFechaAlta;
         AV162Postulacioneswwds_57_tfpostulacionesfechaalta_to = AV43TFPostulacionesFechaAlta_To;
         AV163Postulacioneswwds_58_tfpostulacionesestado_sels = AV45TFPostulacionesEstado_Sels;
         AV164Postulacioneswwds_59_tfpostulacionessecuserid = AV46TFPostulacionesSecUserId;
         AV165Postulacioneswwds_60_tfpostulacionessecuserid_to = AV47TFPostulacionesSecUserId_To;
         pr_default.dynParam(5, new Object[]{ new Object[]{
                                              A424PostulacionesEstado ,
                                              AV163Postulacioneswwds_58_tfpostulacionesestado_sels ,
                                              AV107Postulacioneswwds_2_dynamicfiltersselector1 ,
                                              AV108Postulacioneswwds_3_dynamicfiltersoperator1 ,
                                              AV109Postulacioneswwds_4_postulacionesproveedornombre1 ,
                                              AV110Postulacioneswwds_5_postulacionesproveedorid1 ,
                                              AV111Postulacioneswwds_6_serviciosnombre1 ,
                                              AV112Postulacioneswwds_7_dynamicfiltersenabled2 ,
                                              AV113Postulacioneswwds_8_dynamicfiltersselector2 ,
                                              AV114Postulacioneswwds_9_dynamicfiltersoperator2 ,
                                              AV115Postulacioneswwds_10_postulacionesproveedornombre2 ,
                                              AV116Postulacioneswwds_11_postulacionesproveedorid2 ,
                                              AV117Postulacioneswwds_12_serviciosnombre2 ,
                                              AV118Postulacioneswwds_13_dynamicfiltersenabled3 ,
                                              AV119Postulacioneswwds_14_dynamicfiltersselector3 ,
                                              AV120Postulacioneswwds_15_dynamicfiltersoperator3 ,
                                              AV121Postulacioneswwds_16_postulacionesproveedornombre3 ,
                                              AV122Postulacioneswwds_17_postulacionesproveedorid3 ,
                                              AV123Postulacioneswwds_18_serviciosnombre3 ,
                                              AV124Postulacioneswwds_19_tfpostulacionesid ,
                                              AV125Postulacioneswwds_20_tfpostulacionesid_to ,
                                              AV126Postulacioneswwds_21_tfserviciosid ,
                                              AV127Postulacioneswwds_22_tfserviciosid_to ,
                                              AV129Postulacioneswwds_24_tfserviciosnombre_sel ,
                                              AV128Postulacioneswwds_23_tfserviciosnombre ,
                                              AV130Postulacioneswwds_25_tfpostulacionesproveedorid ,
                                              AV131Postulacioneswwds_26_tfpostulacionesproveedorid_to ,
                                              AV133Postulacioneswwds_28_tfpostulacionesproveedornombre_sel ,
                                              AV132Postulacioneswwds_27_tfpostulacionesproveedornombre ,
                                              AV134Postulacioneswwds_29_tfpostulacionesprecio ,
                                              AV135Postulacioneswwds_30_tfpostulacionesprecio_to ,
                                              AV136Postulacioneswwds_31_tfpostulacionesmultimediaserial ,
                                              AV137Postulacioneswwds_32_tfpostulacionesmultimediaserial_to ,
                                              AV141Postulacioneswwds_36_tfpostulacionesdescripcion_sel ,
                                              AV140Postulacioneswwds_35_tfpostulacionesdescripcion ,
                                              AV142Postulacioneswwds_37_tfpostulacionesreqsuministros_sel ,
                                              AV144Postulacioneswwds_39_tfpostulacionessuministrosdescripcion_sel ,
                                              AV143Postulacioneswwds_38_tfpostulacionessuministrosdescripcion ,
                                              AV145Postulacioneswwds_40_tfpostulacionesfechatrabajo ,
                                              AV146Postulacioneswwds_41_tfpostulacionesfechatrabajo_to ,
                                              AV147Postulacioneswwds_42_tfpostulacionesfechacierre ,
                                              AV148Postulacioneswwds_43_tfpostulacionesfechacierre_to ,
                                              AV150Postulacioneswwds_45_tfpostulacioneshoracierre_sel ,
                                              AV149Postulacioneswwds_44_tfpostulacioneshoracierre ,
                                              AV152Postulacioneswwds_47_tfpostulacionestipofecha_sel ,
                                              AV151Postulacioneswwds_46_tfpostulacionestipofecha ,
                                              AV154Postulacioneswwds_49_tfpostulacionesrgohoraservicio_sel ,
                                              AV153Postulacioneswwds_48_tfpostulacionesrgohoraservicio ,
                                              AV156Postulacioneswwds_51_tfpostulacionesapellidonombre_sel ,
                                              AV155Postulacioneswwds_50_tfpostulacionesapellidonombre ,
                                              AV158Postulacioneswwds_53_tfpostulacionesmail_sel ,
                                              AV157Postulacioneswwds_52_tfpostulacionesmail ,
                                              AV160Postulacioneswwds_55_tfpostulacionestelefono_sel ,
                                              AV159Postulacioneswwds_54_tfpostulacionestelefono ,
                                              AV161Postulacioneswwds_56_tfpostulacionesfechaalta ,
                                              AV162Postulacioneswwds_57_tfpostulacionesfechaalta_to ,
                                              AV163Postulacioneswwds_58_tfpostulacionesestado_sels.Count ,
                                              AV164Postulacioneswwds_59_tfpostulacionessecuserid ,
                                              AV165Postulacioneswwds_60_tfpostulacionessecuserid_to ,
                                              A969PostulacionesProveedorNombre ,
                                              A945PostulacionesProveedorId ,
                                              A943ServiciosNombre ,
                                              A422PostulacionesId ,
                                              A942ServiciosId ,
                                              A946PostulacionesPrecio ,
                                              A961PostulacionesMultimediaSerial ,
                                              A936PostulacionesDescripcion ,
                                              A937PostulacionesReqSuministros ,
                                              A938PostulacionesSuministrosDescri ,
                                              A947PostulacionesFechaTrabajo ,
                                              A939PostulacionesFechaCierre ,
                                              A940PostulacionesHoraCierre ,
                                              A941PostulacionesTipoFecha ,
                                              A949PostulacionesRgoHoraservicio ,
                                              A950PostulacionesApellidoNombre ,
                                              A951PostulacionesMail ,
                                              A952PostulacionesTelefono ,
                                              A425PostulacionesFechaAlta ,
                                              A948PostulacionesSecUserId ,
                                              AV106Postulacioneswwds_1_filterfulltext ,
                                              A970PostulacionesSolicitudesId ,
                                              AV138Postulacioneswwds_33_tfpostulacionessolicitudesid ,
                                              AV139Postulacioneswwds_34_tfpostulacionessolicitudesid_to } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG,
                                              TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.DATE,
                                              TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.INT, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG,
                                              TypeConstants.BOOLEAN, TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.LONG,
                                              TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.LONG, TypeConstants.LONG
                                              }
         });
         lV109Postulacioneswwds_4_postulacionesproveedornombre1 = StringUtil.PadR( StringUtil.RTrim( AV109Postulacioneswwds_4_postulacionesproveedornombre1), 80, "%");
         lV109Postulacioneswwds_4_postulacionesproveedornombre1 = StringUtil.PadR( StringUtil.RTrim( AV109Postulacioneswwds_4_postulacionesproveedornombre1), 80, "%");
         lV111Postulacioneswwds_6_serviciosnombre1 = StringUtil.PadR( StringUtil.RTrim( AV111Postulacioneswwds_6_serviciosnombre1), 80, "%");
         lV111Postulacioneswwds_6_serviciosnombre1 = StringUtil.PadR( StringUtil.RTrim( AV111Postulacioneswwds_6_serviciosnombre1), 80, "%");
         lV115Postulacioneswwds_10_postulacionesproveedornombre2 = StringUtil.PadR( StringUtil.RTrim( AV115Postulacioneswwds_10_postulacionesproveedornombre2), 80, "%");
         lV115Postulacioneswwds_10_postulacionesproveedornombre2 = StringUtil.PadR( StringUtil.RTrim( AV115Postulacioneswwds_10_postulacionesproveedornombre2), 80, "%");
         lV117Postulacioneswwds_12_serviciosnombre2 = StringUtil.PadR( StringUtil.RTrim( AV117Postulacioneswwds_12_serviciosnombre2), 80, "%");
         lV117Postulacioneswwds_12_serviciosnombre2 = StringUtil.PadR( StringUtil.RTrim( AV117Postulacioneswwds_12_serviciosnombre2), 80, "%");
         lV121Postulacioneswwds_16_postulacionesproveedornombre3 = StringUtil.PadR( StringUtil.RTrim( AV121Postulacioneswwds_16_postulacionesproveedornombre3), 80, "%");
         lV121Postulacioneswwds_16_postulacionesproveedornombre3 = StringUtil.PadR( StringUtil.RTrim( AV121Postulacioneswwds_16_postulacionesproveedornombre3), 80, "%");
         lV123Postulacioneswwds_18_serviciosnombre3 = StringUtil.PadR( StringUtil.RTrim( AV123Postulacioneswwds_18_serviciosnombre3), 80, "%");
         lV123Postulacioneswwds_18_serviciosnombre3 = StringUtil.PadR( StringUtil.RTrim( AV123Postulacioneswwds_18_serviciosnombre3), 80, "%");
         lV128Postulacioneswwds_23_tfserviciosnombre = StringUtil.PadR( StringUtil.RTrim( AV128Postulacioneswwds_23_tfserviciosnombre), 80, "%");
         lV132Postulacioneswwds_27_tfpostulacionesproveedornombre = StringUtil.PadR( StringUtil.RTrim( AV132Postulacioneswwds_27_tfpostulacionesproveedornombre), 80, "%");
         lV140Postulacioneswwds_35_tfpostulacionesdescripcion = StringUtil.PadR( StringUtil.RTrim( AV140Postulacioneswwds_35_tfpostulacionesdescripcion), 2000, "%");
         lV143Postulacioneswwds_38_tfpostulacionessuministrosdescripcion = StringUtil.PadR( StringUtil.RTrim( AV143Postulacioneswwds_38_tfpostulacionessuministrosdescripcion), 250, "%");
         lV149Postulacioneswwds_44_tfpostulacioneshoracierre = StringUtil.Concat( StringUtil.RTrim( AV149Postulacioneswwds_44_tfpostulacioneshoracierre), "%", "");
         lV151Postulacioneswwds_46_tfpostulacionestipofecha = StringUtil.Concat( StringUtil.RTrim( AV151Postulacioneswwds_46_tfpostulacionestipofecha), "%", "");
         lV153Postulacioneswwds_48_tfpostulacionesrgohoraservicio = StringUtil.PadR( StringUtil.RTrim( AV153Postulacioneswwds_48_tfpostulacionesrgohoraservicio), 5, "%");
         lV155Postulacioneswwds_50_tfpostulacionesapellidonombre = StringUtil.PadR( StringUtil.RTrim( AV155Postulacioneswwds_50_tfpostulacionesapellidonombre), 80, "%");
         lV157Postulacioneswwds_52_tfpostulacionesmail = StringUtil.Concat( StringUtil.RTrim( AV157Postulacioneswwds_52_tfpostulacionesmail), "%", "");
         lV159Postulacioneswwds_54_tfpostulacionestelefono = StringUtil.PadR( StringUtil.RTrim( AV159Postulacioneswwds_54_tfpostulacionestelefono), 20, "%");
         /* Using cursor P00LA13 */
         pr_default.execute(5, new Object[] {n422PostulacionesId, A422PostulacionesId, AV138Postulacioneswwds_33_tfpostulacionessolicitudesid, AV138Postulacioneswwds_33_tfpostulacionessolicitudesid, AV139Postulacioneswwds_34_tfpostulacionessolicitudesid_to, AV139Postulacioneswwds_34_tfpostulacionessolicitudesid_to, lV109Postulacioneswwds_4_postulacionesproveedornombre1, lV109Postulacioneswwds_4_postulacionesproveedornombre1, AV110Postulacioneswwds_5_postulacionesproveedorid1, AV110Postulacioneswwds_5_postulacionesproveedorid1, AV110Postulacioneswwds_5_postulacionesproveedorid1, lV111Postulacioneswwds_6_serviciosnombre1, lV111Postulacioneswwds_6_serviciosnombre1, lV115Postulacioneswwds_10_postulacionesproveedornombre2, lV115Postulacioneswwds_10_postulacionesproveedornombre2, AV116Postulacioneswwds_11_postulacionesproveedorid2, AV116Postulacioneswwds_11_postulacionesproveedorid2, AV116Postulacioneswwds_11_postulacionesproveedorid2, lV117Postulacioneswwds_12_serviciosnombre2, lV117Postulacioneswwds_12_serviciosnombre2, lV121Postulacioneswwds_16_postulacionesproveedornombre3, lV121Postulacioneswwds_16_postulacionesproveedornombre3, AV122Postulacioneswwds_17_postulacionesproveedorid3, AV122Postulacioneswwds_17_postulacionesproveedorid3, AV122Postulacioneswwds_17_postulacionesproveedorid3, lV123Postulacioneswwds_18_serviciosnombre3, lV123Postulacioneswwds_18_serviciosnombre3, AV124Postulacioneswwds_19_tfpostulacionesid, AV125Postulacioneswwds_20_tfpostulacionesid_to, AV126Postulacioneswwds_21_tfserviciosid, AV127Postulacioneswwds_22_tfserviciosid_to, lV128Postulacioneswwds_23_tfserviciosnombre, AV129Postulacioneswwds_24_tfserviciosnombre_sel, AV130Postulacioneswwds_25_tfpostulacionesproveedorid, AV131Postulacioneswwds_26_tfpostulacionesproveedorid_to, lV132Postulacioneswwds_27_tfpostulacionesproveedornombre, AV133Postulacioneswwds_28_tfpostulacionesproveedornombre_sel, AV134Postulacioneswwds_29_tfpostulacionesprecio, AV135Postulacioneswwds_30_tfpostulacionesprecio_to, AV136Postulacioneswwds_31_tfpostulacionesmultimediaserial, AV137Postulacioneswwds_32_tfpostulacionesmultimediaserial_to, lV140Postulacioneswwds_35_tfpostulacionesdescripcion, AV141Postulacioneswwds_36_tfpostulacionesdescripcion_sel, lV143Postulacioneswwds_38_tfpostulacionessuministrosdescripcion, AV144Postulacioneswwds_39_tfpostulacionessuministrosdescripcion_sel, AV145Postulacioneswwds_40_tfpostulacionesfechatrabajo, AV146Postulacioneswwds_41_tfpostulacionesfechatrabajo_to, AV147Postulacioneswwds_42_tfpostulacionesfechacierre, AV148Postulacioneswwds_43_tfpostulacionesfechacierre_to, lV149Postulacioneswwds_44_tfpostulacioneshoracierre, AV150Postulacioneswwds_45_tfpostulacioneshoracierre_sel, lV151Postulacioneswwds_46_tfpostulacionestipofecha, AV152Postulacioneswwds_47_tfpostulacionestipofecha_sel, lV153Postulacioneswwds_48_tfpostulacionesrgohoraservicio, AV154Postulacioneswwds_49_tfpostulacionesrgohoraservicio_sel, lV155Postulacioneswwds_50_tfpostulacionesapellidonombre, AV156Postulacioneswwds_51_tfpostulacionesapellidonombre_sel, lV157Postulacioneswwds_52_tfpostulacionesmail, AV158Postulacioneswwds_53_tfpostulacionesmail_sel, lV159Postulacioneswwds_54_tfpostulacionestelefono, AV160Postulacioneswwds_55_tfpostulacionestelefono_sel, AV161Postulacioneswwds_56_tfpostulacionesfechaalta, AV162Postulacioneswwds_57_tfpostulacionesfechaalta_to, AV164Postulacioneswwds_59_tfpostulacionessecuserid, AV165Postulacioneswwds_60_tfpostulacionessecuserid_to});
         while ( (pr_default.getStatus(5) != 101) )
         {
            BRKLA12 = false;
            A941PostulacionesTipoFecha = P00LA13_A941PostulacionesTipoFecha[0];
            A948PostulacionesSecUserId = P00LA13_A948PostulacionesSecUserId[0];
            A425PostulacionesFechaAlta = P00LA13_A425PostulacionesFechaAlta[0];
            A952PostulacionesTelefono = P00LA13_A952PostulacionesTelefono[0];
            A951PostulacionesMail = P00LA13_A951PostulacionesMail[0];
            A950PostulacionesApellidoNombre = P00LA13_A950PostulacionesApellidoNombre[0];
            A949PostulacionesRgoHoraservicio = P00LA13_A949PostulacionesRgoHoraservicio[0];
            A940PostulacionesHoraCierre = P00LA13_A940PostulacionesHoraCierre[0];
            A939PostulacionesFechaCierre = P00LA13_A939PostulacionesFechaCierre[0];
            A947PostulacionesFechaTrabajo = P00LA13_A947PostulacionesFechaTrabajo[0];
            A938PostulacionesSuministrosDescri = P00LA13_A938PostulacionesSuministrosDescri[0];
            A937PostulacionesReqSuministros = P00LA13_A937PostulacionesReqSuministros[0];
            A936PostulacionesDescripcion = P00LA13_A936PostulacionesDescripcion[0];
            A961PostulacionesMultimediaSerial = P00LA13_A961PostulacionesMultimediaSerial[0];
            A946PostulacionesPrecio = P00LA13_A946PostulacionesPrecio[0];
            A969PostulacionesProveedorNombre = P00LA13_A969PostulacionesProveedorNombre[0];
            A943ServiciosNombre = P00LA13_A943ServiciosNombre[0];
            A942ServiciosId = P00LA13_A942ServiciosId[0];
            n942ServiciosId = P00LA13_n942ServiciosId[0];
            A422PostulacionesId = P00LA13_A422PostulacionesId[0];
            n422PostulacionesId = P00LA13_n422PostulacionesId[0];
            A945PostulacionesProveedorId = P00LA13_A945PostulacionesProveedorId[0];
            A424PostulacionesEstado = P00LA13_A424PostulacionesEstado[0];
            A970PostulacionesSolicitudesId = P00LA13_A970PostulacionesSolicitudesId[0];
            n970PostulacionesSolicitudesId = P00LA13_n970PostulacionesSolicitudesId[0];
            A943ServiciosNombre = P00LA13_A943ServiciosNombre[0];
            A969PostulacionesProveedorNombre = P00LA13_A969PostulacionesProveedorNombre[0];
            A970PostulacionesSolicitudesId = P00LA13_A970PostulacionesSolicitudesId[0];
            n970PostulacionesSolicitudesId = P00LA13_n970PostulacionesSolicitudesId[0];
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV106Postulacioneswwds_1_filterfulltext)) || ( ( StringUtil.Like( StringUtil.Str( (decimal)(A422PostulacionesId), 18, 0) , StringUtil.PadR( "%" + AV106Postulacioneswwds_1_filterfulltext , 254 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Str( (decimal)(A942ServiciosId), 18, 0) , StringUtil.PadR( "%" + AV106Postulacioneswwds_1_filterfulltext , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A943ServiciosNombre) , StringUtil.PadR( "%" + StringUtil.Upper( AV106Postulacioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Str( (decimal)(A945PostulacionesProveedorId), 18, 0) , StringUtil.PadR( "%" + AV106Postulacioneswwds_1_filterfulltext , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A969PostulacionesProveedorNombre) , StringUtil.PadR( "%" + StringUtil.Upper( AV106Postulacioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Str( A946PostulacionesPrecio, 18, 2) , StringUtil.PadR( "%" + AV106Postulacioneswwds_1_filterfulltext , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Str( (decimal)(A961PostulacionesMultimediaSerial), 4, 0) , StringUtil.PadR( "%" + AV106Postulacioneswwds_1_filterfulltext , 254 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Str( (decimal)(A970PostulacionesSolicitudesId), 18, 0) , StringUtil.PadR( "%" + AV106Postulacioneswwds_1_filterfulltext , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A936PostulacionesDescripcion) , StringUtil.PadR( "%" + StringUtil.Upper( AV106Postulacioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Upper( A938PostulacionesSuministrosDescri) , StringUtil.PadR( "%" + StringUtil.Upper( AV106Postulacioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A940PostulacionesHoraCierre) , StringUtil.PadR( "%" + StringUtil.Upper( AV106Postulacioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Upper( A941PostulacionesTipoFecha) , StringUtil.PadR( "%" + StringUtil.Upper( AV106Postulacioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A949PostulacionesRgoHoraservicio) , StringUtil.PadR( "%" + StringUtil.Upper( AV106Postulacioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Upper( A950PostulacionesApellidoNombre) , StringUtil.PadR( "%" + StringUtil.Upper( AV106Postulacioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A951PostulacionesMail) , StringUtil.PadR( "%" + StringUtil.Upper( AV106Postulacioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Upper( A952PostulacionesTelefono) , StringUtil.PadR( "%" + StringUtil.Upper( AV106Postulacioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( context.GetMessage( "habilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV106Postulacioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A424PostulacionesEstado, "HAB") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "deshabilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV106Postulacioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A424PostulacionesEstado, "DES") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "ganador", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV106Postulacioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) &&
            ( StringUtil.StrCmp(A424PostulacionesEstado, "GAN") == 0 ) ) || ( StringUtil.Like( StringUtil.Str( (decimal)(A948PostulacionesSecUserId), 18, 0) , StringUtil.PadR( "%" + AV106Postulacioneswwds_1_filterfulltext , 254 , "%"),  ' ' ) ) )
            )
            {
               AV58count = 0;
               while ( (pr_default.getStatus(5) != 101) && ( StringUtil.StrCmp(P00LA13_A941PostulacionesTipoFecha[0], A941PostulacionesTipoFecha) == 0 ) )
               {
                  BRKLA12 = false;
                  A422PostulacionesId = P00LA13_A422PostulacionesId[0];
                  n422PostulacionesId = P00LA13_n422PostulacionesId[0];
                  AV58count = (long)(AV58count+1);
                  BRKLA12 = true;
                  pr_default.readNext(5);
               }
               if ( (0==AV49SkipItems) )
               {
                  AV53Option = (String.IsNullOrEmpty(StringUtil.RTrim( A941PostulacionesTipoFecha)) ? "<#Empty#>" : A941PostulacionesTipoFecha);
                  AV54Options.Add(AV53Option, 0);
                  AV57OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV58count), "Z,ZZZ,ZZZ,ZZ9")), 0);
                  if ( AV54Options.Count == 10 )
                  {
                     /* Exit For each command. Update data (if necessary), close cursors & exit. */
                     if (true) break;
                  }
               }
               else
               {
                  AV49SkipItems = (short)(AV49SkipItems-1);
               }
            }
            if ( ! BRKLA12 )
            {
               BRKLA12 = true;
               pr_default.readNext(5);
            }
         }
         pr_default.close(5);
      }

      protected void S181( )
      {
         /* 'LOADPOSTULACIONESRGOHORASERVICIOOPTIONS' Routine */
         returnInSub = false;
         AV34TFPostulacionesRgoHoraservicio = AV48SearchTxt;
         AV35TFPostulacionesRgoHoraservicio_Sel = "";
         AV106Postulacioneswwds_1_filterfulltext = AV70FilterFullText;
         AV107Postulacioneswwds_2_dynamicfiltersselector1 = AV71DynamicFiltersSelector1;
         AV108Postulacioneswwds_3_dynamicfiltersoperator1 = AV72DynamicFiltersOperator1;
         AV109Postulacioneswwds_4_postulacionesproveedornombre1 = AV91PostulacionesProveedorNombre1;
         AV110Postulacioneswwds_5_postulacionesproveedorid1 = AV73PostulacionesProveedorId1;
         AV111Postulacioneswwds_6_serviciosnombre1 = AV74ServiciosNombre1;
         AV112Postulacioneswwds_7_dynamicfiltersenabled2 = AV75DynamicFiltersEnabled2;
         AV113Postulacioneswwds_8_dynamicfiltersselector2 = AV76DynamicFiltersSelector2;
         AV114Postulacioneswwds_9_dynamicfiltersoperator2 = AV77DynamicFiltersOperator2;
         AV115Postulacioneswwds_10_postulacionesproveedornombre2 = AV92PostulacionesProveedorNombre2;
         AV116Postulacioneswwds_11_postulacionesproveedorid2 = AV78PostulacionesProveedorId2;
         AV117Postulacioneswwds_12_serviciosnombre2 = AV79ServiciosNombre2;
         AV118Postulacioneswwds_13_dynamicfiltersenabled3 = AV80DynamicFiltersEnabled3;
         AV119Postulacioneswwds_14_dynamicfiltersselector3 = AV81DynamicFiltersSelector3;
         AV120Postulacioneswwds_15_dynamicfiltersoperator3 = AV82DynamicFiltersOperator3;
         AV121Postulacioneswwds_16_postulacionesproveedornombre3 = AV93PostulacionesProveedorNombre3;
         AV122Postulacioneswwds_17_postulacionesproveedorid3 = AV83PostulacionesProveedorId3;
         AV123Postulacioneswwds_18_serviciosnombre3 = AV84ServiciosNombre3;
         AV124Postulacioneswwds_19_tfpostulacionesid = AV11TFPostulacionesId;
         AV125Postulacioneswwds_20_tfpostulacionesid_to = AV12TFPostulacionesId_To;
         AV126Postulacioneswwds_21_tfserviciosid = AV13TFServiciosId;
         AV127Postulacioneswwds_22_tfserviciosid_to = AV14TFServiciosId_To;
         AV128Postulacioneswwds_23_tfserviciosnombre = AV15TFServiciosNombre;
         AV129Postulacioneswwds_24_tfserviciosnombre_sel = AV16TFServiciosNombre_Sel;
         AV130Postulacioneswwds_25_tfpostulacionesproveedorid = AV17TFPostulacionesProveedorId;
         AV131Postulacioneswwds_26_tfpostulacionesproveedorid_to = AV18TFPostulacionesProveedorId_To;
         AV132Postulacioneswwds_27_tfpostulacionesproveedornombre = AV85TFPostulacionesProveedorNombre;
         AV133Postulacioneswwds_28_tfpostulacionesproveedornombre_sel = AV86TFPostulacionesProveedorNombre_Sel;
         AV134Postulacioneswwds_29_tfpostulacionesprecio = AV19TFPostulacionesPrecio;
         AV135Postulacioneswwds_30_tfpostulacionesprecio_to = AV20TFPostulacionesPrecio_To;
         AV136Postulacioneswwds_31_tfpostulacionesmultimediaserial = AV87TFPostulacionesMultimediaSerial;
         AV137Postulacioneswwds_32_tfpostulacionesmultimediaserial_to = AV88TFPostulacionesMultimediaSerial_To;
         AV138Postulacioneswwds_33_tfpostulacionessolicitudesid = AV89TFPostulacionesSolicitudesId;
         AV139Postulacioneswwds_34_tfpostulacionessolicitudesid_to = AV90TFPostulacionesSolicitudesId_To;
         AV140Postulacioneswwds_35_tfpostulacionesdescripcion = AV21TFPostulacionesDescripcion;
         AV141Postulacioneswwds_36_tfpostulacionesdescripcion_sel = AV22TFPostulacionesDescripcion_Sel;
         AV142Postulacioneswwds_37_tfpostulacionesreqsuministros_sel = AV23TFPostulacionesReqSuministros_Sel;
         AV143Postulacioneswwds_38_tfpostulacionessuministrosdescripcion = AV24TFPostulacionesSuministrosDescripcion;
         AV144Postulacioneswwds_39_tfpostulacionessuministrosdescripcion_sel = AV25TFPostulacionesSuministrosDescripcion_Sel;
         AV145Postulacioneswwds_40_tfpostulacionesfechatrabajo = AV26TFPostulacionesFechaTrabajo;
         AV146Postulacioneswwds_41_tfpostulacionesfechatrabajo_to = AV27TFPostulacionesFechaTrabajo_To;
         AV147Postulacioneswwds_42_tfpostulacionesfechacierre = AV28TFPostulacionesFechaCierre;
         AV148Postulacioneswwds_43_tfpostulacionesfechacierre_to = AV29TFPostulacionesFechaCierre_To;
         AV149Postulacioneswwds_44_tfpostulacioneshoracierre = AV30TFPostulacionesHoraCierre;
         AV150Postulacioneswwds_45_tfpostulacioneshoracierre_sel = AV31TFPostulacionesHoraCierre_Sel;
         AV151Postulacioneswwds_46_tfpostulacionestipofecha = AV32TFPostulacionesTipoFecha;
         AV152Postulacioneswwds_47_tfpostulacionestipofecha_sel = AV103TFPostulacionesTipoFecha_Sel;
         AV153Postulacioneswwds_48_tfpostulacionesrgohoraservicio = AV34TFPostulacionesRgoHoraservicio;
         AV154Postulacioneswwds_49_tfpostulacionesrgohoraservicio_sel = AV35TFPostulacionesRgoHoraservicio_Sel;
         AV155Postulacioneswwds_50_tfpostulacionesapellidonombre = AV36TFPostulacionesApellidoNombre;
         AV156Postulacioneswwds_51_tfpostulacionesapellidonombre_sel = AV37TFPostulacionesApellidoNombre_Sel;
         AV157Postulacioneswwds_52_tfpostulacionesmail = AV38TFPostulacionesMail;
         AV158Postulacioneswwds_53_tfpostulacionesmail_sel = AV39TFPostulacionesMail_Sel;
         AV159Postulacioneswwds_54_tfpostulacionestelefono = AV40TFPostulacionesTelefono;
         AV160Postulacioneswwds_55_tfpostulacionestelefono_sel = AV41TFPostulacionesTelefono_Sel;
         AV161Postulacioneswwds_56_tfpostulacionesfechaalta = AV42TFPostulacionesFechaAlta;
         AV162Postulacioneswwds_57_tfpostulacionesfechaalta_to = AV43TFPostulacionesFechaAlta_To;
         AV163Postulacioneswwds_58_tfpostulacionesestado_sels = AV45TFPostulacionesEstado_Sels;
         AV164Postulacioneswwds_59_tfpostulacionessecuserid = AV46TFPostulacionesSecUserId;
         AV165Postulacioneswwds_60_tfpostulacionessecuserid_to = AV47TFPostulacionesSecUserId_To;
         pr_default.dynParam(6, new Object[]{ new Object[]{
                                              A424PostulacionesEstado ,
                                              AV163Postulacioneswwds_58_tfpostulacionesestado_sels ,
                                              AV107Postulacioneswwds_2_dynamicfiltersselector1 ,
                                              AV108Postulacioneswwds_3_dynamicfiltersoperator1 ,
                                              AV109Postulacioneswwds_4_postulacionesproveedornombre1 ,
                                              AV110Postulacioneswwds_5_postulacionesproveedorid1 ,
                                              AV111Postulacioneswwds_6_serviciosnombre1 ,
                                              AV112Postulacioneswwds_7_dynamicfiltersenabled2 ,
                                              AV113Postulacioneswwds_8_dynamicfiltersselector2 ,
                                              AV114Postulacioneswwds_9_dynamicfiltersoperator2 ,
                                              AV115Postulacioneswwds_10_postulacionesproveedornombre2 ,
                                              AV116Postulacioneswwds_11_postulacionesproveedorid2 ,
                                              AV117Postulacioneswwds_12_serviciosnombre2 ,
                                              AV118Postulacioneswwds_13_dynamicfiltersenabled3 ,
                                              AV119Postulacioneswwds_14_dynamicfiltersselector3 ,
                                              AV120Postulacioneswwds_15_dynamicfiltersoperator3 ,
                                              AV121Postulacioneswwds_16_postulacionesproveedornombre3 ,
                                              AV122Postulacioneswwds_17_postulacionesproveedorid3 ,
                                              AV123Postulacioneswwds_18_serviciosnombre3 ,
                                              AV124Postulacioneswwds_19_tfpostulacionesid ,
                                              AV125Postulacioneswwds_20_tfpostulacionesid_to ,
                                              AV126Postulacioneswwds_21_tfserviciosid ,
                                              AV127Postulacioneswwds_22_tfserviciosid_to ,
                                              AV129Postulacioneswwds_24_tfserviciosnombre_sel ,
                                              AV128Postulacioneswwds_23_tfserviciosnombre ,
                                              AV130Postulacioneswwds_25_tfpostulacionesproveedorid ,
                                              AV131Postulacioneswwds_26_tfpostulacionesproveedorid_to ,
                                              AV133Postulacioneswwds_28_tfpostulacionesproveedornombre_sel ,
                                              AV132Postulacioneswwds_27_tfpostulacionesproveedornombre ,
                                              AV134Postulacioneswwds_29_tfpostulacionesprecio ,
                                              AV135Postulacioneswwds_30_tfpostulacionesprecio_to ,
                                              AV136Postulacioneswwds_31_tfpostulacionesmultimediaserial ,
                                              AV137Postulacioneswwds_32_tfpostulacionesmultimediaserial_to ,
                                              AV141Postulacioneswwds_36_tfpostulacionesdescripcion_sel ,
                                              AV140Postulacioneswwds_35_tfpostulacionesdescripcion ,
                                              AV142Postulacioneswwds_37_tfpostulacionesreqsuministros_sel ,
                                              AV144Postulacioneswwds_39_tfpostulacionessuministrosdescripcion_sel ,
                                              AV143Postulacioneswwds_38_tfpostulacionessuministrosdescripcion ,
                                              AV145Postulacioneswwds_40_tfpostulacionesfechatrabajo ,
                                              AV146Postulacioneswwds_41_tfpostulacionesfechatrabajo_to ,
                                              AV147Postulacioneswwds_42_tfpostulacionesfechacierre ,
                                              AV148Postulacioneswwds_43_tfpostulacionesfechacierre_to ,
                                              AV150Postulacioneswwds_45_tfpostulacioneshoracierre_sel ,
                                              AV149Postulacioneswwds_44_tfpostulacioneshoracierre ,
                                              AV152Postulacioneswwds_47_tfpostulacionestipofecha_sel ,
                                              AV151Postulacioneswwds_46_tfpostulacionestipofecha ,
                                              AV154Postulacioneswwds_49_tfpostulacionesrgohoraservicio_sel ,
                                              AV153Postulacioneswwds_48_tfpostulacionesrgohoraservicio ,
                                              AV156Postulacioneswwds_51_tfpostulacionesapellidonombre_sel ,
                                              AV155Postulacioneswwds_50_tfpostulacionesapellidonombre ,
                                              AV158Postulacioneswwds_53_tfpostulacionesmail_sel ,
                                              AV157Postulacioneswwds_52_tfpostulacionesmail ,
                                              AV160Postulacioneswwds_55_tfpostulacionestelefono_sel ,
                                              AV159Postulacioneswwds_54_tfpostulacionestelefono ,
                                              AV161Postulacioneswwds_56_tfpostulacionesfechaalta ,
                                              AV162Postulacioneswwds_57_tfpostulacionesfechaalta_to ,
                                              AV163Postulacioneswwds_58_tfpostulacionesestado_sels.Count ,
                                              AV164Postulacioneswwds_59_tfpostulacionessecuserid ,
                                              AV165Postulacioneswwds_60_tfpostulacionessecuserid_to ,
                                              A969PostulacionesProveedorNombre ,
                                              A945PostulacionesProveedorId ,
                                              A943ServiciosNombre ,
                                              A422PostulacionesId ,
                                              A942ServiciosId ,
                                              A946PostulacionesPrecio ,
                                              A961PostulacionesMultimediaSerial ,
                                              A936PostulacionesDescripcion ,
                                              A937PostulacionesReqSuministros ,
                                              A938PostulacionesSuministrosDescri ,
                                              A947PostulacionesFechaTrabajo ,
                                              A939PostulacionesFechaCierre ,
                                              A940PostulacionesHoraCierre ,
                                              A941PostulacionesTipoFecha ,
                                              A949PostulacionesRgoHoraservicio ,
                                              A950PostulacionesApellidoNombre ,
                                              A951PostulacionesMail ,
                                              A952PostulacionesTelefono ,
                                              A425PostulacionesFechaAlta ,
                                              A948PostulacionesSecUserId ,
                                              AV106Postulacioneswwds_1_filterfulltext ,
                                              A970PostulacionesSolicitudesId ,
                                              AV138Postulacioneswwds_33_tfpostulacionessolicitudesid ,
                                              AV139Postulacioneswwds_34_tfpostulacionessolicitudesid_to } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG,
                                              TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.DATE,
                                              TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.INT, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG,
                                              TypeConstants.BOOLEAN, TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.LONG,
                                              TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.LONG, TypeConstants.LONG
                                              }
         });
         lV109Postulacioneswwds_4_postulacionesproveedornombre1 = StringUtil.PadR( StringUtil.RTrim( AV109Postulacioneswwds_4_postulacionesproveedornombre1), 80, "%");
         lV109Postulacioneswwds_4_postulacionesproveedornombre1 = StringUtil.PadR( StringUtil.RTrim( AV109Postulacioneswwds_4_postulacionesproveedornombre1), 80, "%");
         lV111Postulacioneswwds_6_serviciosnombre1 = StringUtil.PadR( StringUtil.RTrim( AV111Postulacioneswwds_6_serviciosnombre1), 80, "%");
         lV111Postulacioneswwds_6_serviciosnombre1 = StringUtil.PadR( StringUtil.RTrim( AV111Postulacioneswwds_6_serviciosnombre1), 80, "%");
         lV115Postulacioneswwds_10_postulacionesproveedornombre2 = StringUtil.PadR( StringUtil.RTrim( AV115Postulacioneswwds_10_postulacionesproveedornombre2), 80, "%");
         lV115Postulacioneswwds_10_postulacionesproveedornombre2 = StringUtil.PadR( StringUtil.RTrim( AV115Postulacioneswwds_10_postulacionesproveedornombre2), 80, "%");
         lV117Postulacioneswwds_12_serviciosnombre2 = StringUtil.PadR( StringUtil.RTrim( AV117Postulacioneswwds_12_serviciosnombre2), 80, "%");
         lV117Postulacioneswwds_12_serviciosnombre2 = StringUtil.PadR( StringUtil.RTrim( AV117Postulacioneswwds_12_serviciosnombre2), 80, "%");
         lV121Postulacioneswwds_16_postulacionesproveedornombre3 = StringUtil.PadR( StringUtil.RTrim( AV121Postulacioneswwds_16_postulacionesproveedornombre3), 80, "%");
         lV121Postulacioneswwds_16_postulacionesproveedornombre3 = StringUtil.PadR( StringUtil.RTrim( AV121Postulacioneswwds_16_postulacionesproveedornombre3), 80, "%");
         lV123Postulacioneswwds_18_serviciosnombre3 = StringUtil.PadR( StringUtil.RTrim( AV123Postulacioneswwds_18_serviciosnombre3), 80, "%");
         lV123Postulacioneswwds_18_serviciosnombre3 = StringUtil.PadR( StringUtil.RTrim( AV123Postulacioneswwds_18_serviciosnombre3), 80, "%");
         lV128Postulacioneswwds_23_tfserviciosnombre = StringUtil.PadR( StringUtil.RTrim( AV128Postulacioneswwds_23_tfserviciosnombre), 80, "%");
         lV132Postulacioneswwds_27_tfpostulacionesproveedornombre = StringUtil.PadR( StringUtil.RTrim( AV132Postulacioneswwds_27_tfpostulacionesproveedornombre), 80, "%");
         lV140Postulacioneswwds_35_tfpostulacionesdescripcion = StringUtil.PadR( StringUtil.RTrim( AV140Postulacioneswwds_35_tfpostulacionesdescripcion), 2000, "%");
         lV143Postulacioneswwds_38_tfpostulacionessuministrosdescripcion = StringUtil.PadR( StringUtil.RTrim( AV143Postulacioneswwds_38_tfpostulacionessuministrosdescripcion), 250, "%");
         lV149Postulacioneswwds_44_tfpostulacioneshoracierre = StringUtil.Concat( StringUtil.RTrim( AV149Postulacioneswwds_44_tfpostulacioneshoracierre), "%", "");
         lV151Postulacioneswwds_46_tfpostulacionestipofecha = StringUtil.Concat( StringUtil.RTrim( AV151Postulacioneswwds_46_tfpostulacionestipofecha), "%", "");
         lV153Postulacioneswwds_48_tfpostulacionesrgohoraservicio = StringUtil.PadR( StringUtil.RTrim( AV153Postulacioneswwds_48_tfpostulacionesrgohoraservicio), 5, "%");
         lV155Postulacioneswwds_50_tfpostulacionesapellidonombre = StringUtil.PadR( StringUtil.RTrim( AV155Postulacioneswwds_50_tfpostulacionesapellidonombre), 80, "%");
         lV157Postulacioneswwds_52_tfpostulacionesmail = StringUtil.Concat( StringUtil.RTrim( AV157Postulacioneswwds_52_tfpostulacionesmail), "%", "");
         lV159Postulacioneswwds_54_tfpostulacionestelefono = StringUtil.PadR( StringUtil.RTrim( AV159Postulacioneswwds_54_tfpostulacionestelefono), 20, "%");
         /* Using cursor P00LA15 */
         pr_default.execute(6, new Object[] {n422PostulacionesId, A422PostulacionesId, AV138Postulacioneswwds_33_tfpostulacionessolicitudesid, AV138Postulacioneswwds_33_tfpostulacionessolicitudesid, AV139Postulacioneswwds_34_tfpostulacionessolicitudesid_to, AV139Postulacioneswwds_34_tfpostulacionessolicitudesid_to, lV109Postulacioneswwds_4_postulacionesproveedornombre1, lV109Postulacioneswwds_4_postulacionesproveedornombre1, AV110Postulacioneswwds_5_postulacionesproveedorid1, AV110Postulacioneswwds_5_postulacionesproveedorid1, AV110Postulacioneswwds_5_postulacionesproveedorid1, lV111Postulacioneswwds_6_serviciosnombre1, lV111Postulacioneswwds_6_serviciosnombre1, lV115Postulacioneswwds_10_postulacionesproveedornombre2, lV115Postulacioneswwds_10_postulacionesproveedornombre2, AV116Postulacioneswwds_11_postulacionesproveedorid2, AV116Postulacioneswwds_11_postulacionesproveedorid2, AV116Postulacioneswwds_11_postulacionesproveedorid2, lV117Postulacioneswwds_12_serviciosnombre2, lV117Postulacioneswwds_12_serviciosnombre2, lV121Postulacioneswwds_16_postulacionesproveedornombre3, lV121Postulacioneswwds_16_postulacionesproveedornombre3, AV122Postulacioneswwds_17_postulacionesproveedorid3, AV122Postulacioneswwds_17_postulacionesproveedorid3, AV122Postulacioneswwds_17_postulacionesproveedorid3, lV123Postulacioneswwds_18_serviciosnombre3, lV123Postulacioneswwds_18_serviciosnombre3, AV124Postulacioneswwds_19_tfpostulacionesid, AV125Postulacioneswwds_20_tfpostulacionesid_to, AV126Postulacioneswwds_21_tfserviciosid, AV127Postulacioneswwds_22_tfserviciosid_to, lV128Postulacioneswwds_23_tfserviciosnombre, AV129Postulacioneswwds_24_tfserviciosnombre_sel, AV130Postulacioneswwds_25_tfpostulacionesproveedorid, AV131Postulacioneswwds_26_tfpostulacionesproveedorid_to, lV132Postulacioneswwds_27_tfpostulacionesproveedornombre, AV133Postulacioneswwds_28_tfpostulacionesproveedornombre_sel, AV134Postulacioneswwds_29_tfpostulacionesprecio, AV135Postulacioneswwds_30_tfpostulacionesprecio_to, AV136Postulacioneswwds_31_tfpostulacionesmultimediaserial, AV137Postulacioneswwds_32_tfpostulacionesmultimediaserial_to, lV140Postulacioneswwds_35_tfpostulacionesdescripcion, AV141Postulacioneswwds_36_tfpostulacionesdescripcion_sel, lV143Postulacioneswwds_38_tfpostulacionessuministrosdescripcion, AV144Postulacioneswwds_39_tfpostulacionessuministrosdescripcion_sel, AV145Postulacioneswwds_40_tfpostulacionesfechatrabajo, AV146Postulacioneswwds_41_tfpostulacionesfechatrabajo_to, AV147Postulacioneswwds_42_tfpostulacionesfechacierre, AV148Postulacioneswwds_43_tfpostulacionesfechacierre_to, lV149Postulacioneswwds_44_tfpostulacioneshoracierre, AV150Postulacioneswwds_45_tfpostulacioneshoracierre_sel, lV151Postulacioneswwds_46_tfpostulacionestipofecha, AV152Postulacioneswwds_47_tfpostulacionestipofecha_sel, lV153Postulacioneswwds_48_tfpostulacionesrgohoraservicio, AV154Postulacioneswwds_49_tfpostulacionesrgohoraservicio_sel, lV155Postulacioneswwds_50_tfpostulacionesapellidonombre, AV156Postulacioneswwds_51_tfpostulacionesapellidonombre_sel, lV157Postulacioneswwds_52_tfpostulacionesmail, AV158Postulacioneswwds_53_tfpostulacionesmail_sel, lV159Postulacioneswwds_54_tfpostulacionestelefono, AV160Postulacioneswwds_55_tfpostulacionestelefono_sel, AV161Postulacioneswwds_56_tfpostulacionesfechaalta, AV162Postulacioneswwds_57_tfpostulacionesfechaalta_to, AV164Postulacioneswwds_59_tfpostulacionessecuserid, AV165Postulacioneswwds_60_tfpostulacionessecuserid_to});
         while ( (pr_default.getStatus(6) != 101) )
         {
            BRKLA14 = false;
            A949PostulacionesRgoHoraservicio = P00LA15_A949PostulacionesRgoHoraservicio[0];
            A948PostulacionesSecUserId = P00LA15_A948PostulacionesSecUserId[0];
            A425PostulacionesFechaAlta = P00LA15_A425PostulacionesFechaAlta[0];
            A952PostulacionesTelefono = P00LA15_A952PostulacionesTelefono[0];
            A951PostulacionesMail = P00LA15_A951PostulacionesMail[0];
            A950PostulacionesApellidoNombre = P00LA15_A950PostulacionesApellidoNombre[0];
            A941PostulacionesTipoFecha = P00LA15_A941PostulacionesTipoFecha[0];
            A940PostulacionesHoraCierre = P00LA15_A940PostulacionesHoraCierre[0];
            A939PostulacionesFechaCierre = P00LA15_A939PostulacionesFechaCierre[0];
            A947PostulacionesFechaTrabajo = P00LA15_A947PostulacionesFechaTrabajo[0];
            A938PostulacionesSuministrosDescri = P00LA15_A938PostulacionesSuministrosDescri[0];
            A937PostulacionesReqSuministros = P00LA15_A937PostulacionesReqSuministros[0];
            A936PostulacionesDescripcion = P00LA15_A936PostulacionesDescripcion[0];
            A961PostulacionesMultimediaSerial = P00LA15_A961PostulacionesMultimediaSerial[0];
            A946PostulacionesPrecio = P00LA15_A946PostulacionesPrecio[0];
            A969PostulacionesProveedorNombre = P00LA15_A969PostulacionesProveedorNombre[0];
            A943ServiciosNombre = P00LA15_A943ServiciosNombre[0];
            A942ServiciosId = P00LA15_A942ServiciosId[0];
            n942ServiciosId = P00LA15_n942ServiciosId[0];
            A422PostulacionesId = P00LA15_A422PostulacionesId[0];
            n422PostulacionesId = P00LA15_n422PostulacionesId[0];
            A945PostulacionesProveedorId = P00LA15_A945PostulacionesProveedorId[0];
            A424PostulacionesEstado = P00LA15_A424PostulacionesEstado[0];
            A970PostulacionesSolicitudesId = P00LA15_A970PostulacionesSolicitudesId[0];
            n970PostulacionesSolicitudesId = P00LA15_n970PostulacionesSolicitudesId[0];
            A943ServiciosNombre = P00LA15_A943ServiciosNombre[0];
            A969PostulacionesProveedorNombre = P00LA15_A969PostulacionesProveedorNombre[0];
            A970PostulacionesSolicitudesId = P00LA15_A970PostulacionesSolicitudesId[0];
            n970PostulacionesSolicitudesId = P00LA15_n970PostulacionesSolicitudesId[0];
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV106Postulacioneswwds_1_filterfulltext)) || ( ( StringUtil.Like( StringUtil.Str( (decimal)(A422PostulacionesId), 18, 0) , StringUtil.PadR( "%" + AV106Postulacioneswwds_1_filterfulltext , 254 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Str( (decimal)(A942ServiciosId), 18, 0) , StringUtil.PadR( "%" + AV106Postulacioneswwds_1_filterfulltext , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A943ServiciosNombre) , StringUtil.PadR( "%" + StringUtil.Upper( AV106Postulacioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Str( (decimal)(A945PostulacionesProveedorId), 18, 0) , StringUtil.PadR( "%" + AV106Postulacioneswwds_1_filterfulltext , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A969PostulacionesProveedorNombre) , StringUtil.PadR( "%" + StringUtil.Upper( AV106Postulacioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Str( A946PostulacionesPrecio, 18, 2) , StringUtil.PadR( "%" + AV106Postulacioneswwds_1_filterfulltext , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Str( (decimal)(A961PostulacionesMultimediaSerial), 4, 0) , StringUtil.PadR( "%" + AV106Postulacioneswwds_1_filterfulltext , 254 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Str( (decimal)(A970PostulacionesSolicitudesId), 18, 0) , StringUtil.PadR( "%" + AV106Postulacioneswwds_1_filterfulltext , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A936PostulacionesDescripcion) , StringUtil.PadR( "%" + StringUtil.Upper( AV106Postulacioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Upper( A938PostulacionesSuministrosDescri) , StringUtil.PadR( "%" + StringUtil.Upper( AV106Postulacioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A940PostulacionesHoraCierre) , StringUtil.PadR( "%" + StringUtil.Upper( AV106Postulacioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Upper( A941PostulacionesTipoFecha) , StringUtil.PadR( "%" + StringUtil.Upper( AV106Postulacioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A949PostulacionesRgoHoraservicio) , StringUtil.PadR( "%" + StringUtil.Upper( AV106Postulacioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Upper( A950PostulacionesApellidoNombre) , StringUtil.PadR( "%" + StringUtil.Upper( AV106Postulacioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A951PostulacionesMail) , StringUtil.PadR( "%" + StringUtil.Upper( AV106Postulacioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Upper( A952PostulacionesTelefono) , StringUtil.PadR( "%" + StringUtil.Upper( AV106Postulacioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( context.GetMessage( "habilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV106Postulacioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A424PostulacionesEstado, "HAB") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "deshabilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV106Postulacioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A424PostulacionesEstado, "DES") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "ganador", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV106Postulacioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) &&
            ( StringUtil.StrCmp(A424PostulacionesEstado, "GAN") == 0 ) ) || ( StringUtil.Like( StringUtil.Str( (decimal)(A948PostulacionesSecUserId), 18, 0) , StringUtil.PadR( "%" + AV106Postulacioneswwds_1_filterfulltext , 254 , "%"),  ' ' ) ) )
            )
            {
               AV58count = 0;
               while ( (pr_default.getStatus(6) != 101) && ( StringUtil.StrCmp(P00LA15_A949PostulacionesRgoHoraservicio[0], A949PostulacionesRgoHoraservicio) == 0 ) )
               {
                  BRKLA14 = false;
                  A422PostulacionesId = P00LA15_A422PostulacionesId[0];
                  n422PostulacionesId = P00LA15_n422PostulacionesId[0];
                  AV58count = (long)(AV58count+1);
                  BRKLA14 = true;
                  pr_default.readNext(6);
               }
               if ( (0==AV49SkipItems) )
               {
                  AV53Option = (String.IsNullOrEmpty(StringUtil.RTrim( A949PostulacionesRgoHoraservicio)) ? "<#Empty#>" : A949PostulacionesRgoHoraservicio);
                  AV54Options.Add(AV53Option, 0);
                  AV57OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV58count), "Z,ZZZ,ZZZ,ZZ9")), 0);
                  if ( AV54Options.Count == 10 )
                  {
                     /* Exit For each command. Update data (if necessary), close cursors & exit. */
                     if (true) break;
                  }
               }
               else
               {
                  AV49SkipItems = (short)(AV49SkipItems-1);
               }
            }
            if ( ! BRKLA14 )
            {
               BRKLA14 = true;
               pr_default.readNext(6);
            }
         }
         pr_default.close(6);
      }

      protected void S191( )
      {
         /* 'LOADPOSTULACIONESAPELLIDONOMBREOPTIONS' Routine */
         returnInSub = false;
         AV36TFPostulacionesApellidoNombre = AV48SearchTxt;
         AV37TFPostulacionesApellidoNombre_Sel = "";
         AV106Postulacioneswwds_1_filterfulltext = AV70FilterFullText;
         AV107Postulacioneswwds_2_dynamicfiltersselector1 = AV71DynamicFiltersSelector1;
         AV108Postulacioneswwds_3_dynamicfiltersoperator1 = AV72DynamicFiltersOperator1;
         AV109Postulacioneswwds_4_postulacionesproveedornombre1 = AV91PostulacionesProveedorNombre1;
         AV110Postulacioneswwds_5_postulacionesproveedorid1 = AV73PostulacionesProveedorId1;
         AV111Postulacioneswwds_6_serviciosnombre1 = AV74ServiciosNombre1;
         AV112Postulacioneswwds_7_dynamicfiltersenabled2 = AV75DynamicFiltersEnabled2;
         AV113Postulacioneswwds_8_dynamicfiltersselector2 = AV76DynamicFiltersSelector2;
         AV114Postulacioneswwds_9_dynamicfiltersoperator2 = AV77DynamicFiltersOperator2;
         AV115Postulacioneswwds_10_postulacionesproveedornombre2 = AV92PostulacionesProveedorNombre2;
         AV116Postulacioneswwds_11_postulacionesproveedorid2 = AV78PostulacionesProveedorId2;
         AV117Postulacioneswwds_12_serviciosnombre2 = AV79ServiciosNombre2;
         AV118Postulacioneswwds_13_dynamicfiltersenabled3 = AV80DynamicFiltersEnabled3;
         AV119Postulacioneswwds_14_dynamicfiltersselector3 = AV81DynamicFiltersSelector3;
         AV120Postulacioneswwds_15_dynamicfiltersoperator3 = AV82DynamicFiltersOperator3;
         AV121Postulacioneswwds_16_postulacionesproveedornombre3 = AV93PostulacionesProveedorNombre3;
         AV122Postulacioneswwds_17_postulacionesproveedorid3 = AV83PostulacionesProveedorId3;
         AV123Postulacioneswwds_18_serviciosnombre3 = AV84ServiciosNombre3;
         AV124Postulacioneswwds_19_tfpostulacionesid = AV11TFPostulacionesId;
         AV125Postulacioneswwds_20_tfpostulacionesid_to = AV12TFPostulacionesId_To;
         AV126Postulacioneswwds_21_tfserviciosid = AV13TFServiciosId;
         AV127Postulacioneswwds_22_tfserviciosid_to = AV14TFServiciosId_To;
         AV128Postulacioneswwds_23_tfserviciosnombre = AV15TFServiciosNombre;
         AV129Postulacioneswwds_24_tfserviciosnombre_sel = AV16TFServiciosNombre_Sel;
         AV130Postulacioneswwds_25_tfpostulacionesproveedorid = AV17TFPostulacionesProveedorId;
         AV131Postulacioneswwds_26_tfpostulacionesproveedorid_to = AV18TFPostulacionesProveedorId_To;
         AV132Postulacioneswwds_27_tfpostulacionesproveedornombre = AV85TFPostulacionesProveedorNombre;
         AV133Postulacioneswwds_28_tfpostulacionesproveedornombre_sel = AV86TFPostulacionesProveedorNombre_Sel;
         AV134Postulacioneswwds_29_tfpostulacionesprecio = AV19TFPostulacionesPrecio;
         AV135Postulacioneswwds_30_tfpostulacionesprecio_to = AV20TFPostulacionesPrecio_To;
         AV136Postulacioneswwds_31_tfpostulacionesmultimediaserial = AV87TFPostulacionesMultimediaSerial;
         AV137Postulacioneswwds_32_tfpostulacionesmultimediaserial_to = AV88TFPostulacionesMultimediaSerial_To;
         AV138Postulacioneswwds_33_tfpostulacionessolicitudesid = AV89TFPostulacionesSolicitudesId;
         AV139Postulacioneswwds_34_tfpostulacionessolicitudesid_to = AV90TFPostulacionesSolicitudesId_To;
         AV140Postulacioneswwds_35_tfpostulacionesdescripcion = AV21TFPostulacionesDescripcion;
         AV141Postulacioneswwds_36_tfpostulacionesdescripcion_sel = AV22TFPostulacionesDescripcion_Sel;
         AV142Postulacioneswwds_37_tfpostulacionesreqsuministros_sel = AV23TFPostulacionesReqSuministros_Sel;
         AV143Postulacioneswwds_38_tfpostulacionessuministrosdescripcion = AV24TFPostulacionesSuministrosDescripcion;
         AV144Postulacioneswwds_39_tfpostulacionessuministrosdescripcion_sel = AV25TFPostulacionesSuministrosDescripcion_Sel;
         AV145Postulacioneswwds_40_tfpostulacionesfechatrabajo = AV26TFPostulacionesFechaTrabajo;
         AV146Postulacioneswwds_41_tfpostulacionesfechatrabajo_to = AV27TFPostulacionesFechaTrabajo_To;
         AV147Postulacioneswwds_42_tfpostulacionesfechacierre = AV28TFPostulacionesFechaCierre;
         AV148Postulacioneswwds_43_tfpostulacionesfechacierre_to = AV29TFPostulacionesFechaCierre_To;
         AV149Postulacioneswwds_44_tfpostulacioneshoracierre = AV30TFPostulacionesHoraCierre;
         AV150Postulacioneswwds_45_tfpostulacioneshoracierre_sel = AV31TFPostulacionesHoraCierre_Sel;
         AV151Postulacioneswwds_46_tfpostulacionestipofecha = AV32TFPostulacionesTipoFecha;
         AV152Postulacioneswwds_47_tfpostulacionestipofecha_sel = AV103TFPostulacionesTipoFecha_Sel;
         AV153Postulacioneswwds_48_tfpostulacionesrgohoraservicio = AV34TFPostulacionesRgoHoraservicio;
         AV154Postulacioneswwds_49_tfpostulacionesrgohoraservicio_sel = AV35TFPostulacionesRgoHoraservicio_Sel;
         AV155Postulacioneswwds_50_tfpostulacionesapellidonombre = AV36TFPostulacionesApellidoNombre;
         AV156Postulacioneswwds_51_tfpostulacionesapellidonombre_sel = AV37TFPostulacionesApellidoNombre_Sel;
         AV157Postulacioneswwds_52_tfpostulacionesmail = AV38TFPostulacionesMail;
         AV158Postulacioneswwds_53_tfpostulacionesmail_sel = AV39TFPostulacionesMail_Sel;
         AV159Postulacioneswwds_54_tfpostulacionestelefono = AV40TFPostulacionesTelefono;
         AV160Postulacioneswwds_55_tfpostulacionestelefono_sel = AV41TFPostulacionesTelefono_Sel;
         AV161Postulacioneswwds_56_tfpostulacionesfechaalta = AV42TFPostulacionesFechaAlta;
         AV162Postulacioneswwds_57_tfpostulacionesfechaalta_to = AV43TFPostulacionesFechaAlta_To;
         AV163Postulacioneswwds_58_tfpostulacionesestado_sels = AV45TFPostulacionesEstado_Sels;
         AV164Postulacioneswwds_59_tfpostulacionessecuserid = AV46TFPostulacionesSecUserId;
         AV165Postulacioneswwds_60_tfpostulacionessecuserid_to = AV47TFPostulacionesSecUserId_To;
         pr_default.dynParam(7, new Object[]{ new Object[]{
                                              A424PostulacionesEstado ,
                                              AV163Postulacioneswwds_58_tfpostulacionesestado_sels ,
                                              AV107Postulacioneswwds_2_dynamicfiltersselector1 ,
                                              AV108Postulacioneswwds_3_dynamicfiltersoperator1 ,
                                              AV109Postulacioneswwds_4_postulacionesproveedornombre1 ,
                                              AV110Postulacioneswwds_5_postulacionesproveedorid1 ,
                                              AV111Postulacioneswwds_6_serviciosnombre1 ,
                                              AV112Postulacioneswwds_7_dynamicfiltersenabled2 ,
                                              AV113Postulacioneswwds_8_dynamicfiltersselector2 ,
                                              AV114Postulacioneswwds_9_dynamicfiltersoperator2 ,
                                              AV115Postulacioneswwds_10_postulacionesproveedornombre2 ,
                                              AV116Postulacioneswwds_11_postulacionesproveedorid2 ,
                                              AV117Postulacioneswwds_12_serviciosnombre2 ,
                                              AV118Postulacioneswwds_13_dynamicfiltersenabled3 ,
                                              AV119Postulacioneswwds_14_dynamicfiltersselector3 ,
                                              AV120Postulacioneswwds_15_dynamicfiltersoperator3 ,
                                              AV121Postulacioneswwds_16_postulacionesproveedornombre3 ,
                                              AV122Postulacioneswwds_17_postulacionesproveedorid3 ,
                                              AV123Postulacioneswwds_18_serviciosnombre3 ,
                                              AV124Postulacioneswwds_19_tfpostulacionesid ,
                                              AV125Postulacioneswwds_20_tfpostulacionesid_to ,
                                              AV126Postulacioneswwds_21_tfserviciosid ,
                                              AV127Postulacioneswwds_22_tfserviciosid_to ,
                                              AV129Postulacioneswwds_24_tfserviciosnombre_sel ,
                                              AV128Postulacioneswwds_23_tfserviciosnombre ,
                                              AV130Postulacioneswwds_25_tfpostulacionesproveedorid ,
                                              AV131Postulacioneswwds_26_tfpostulacionesproveedorid_to ,
                                              AV133Postulacioneswwds_28_tfpostulacionesproveedornombre_sel ,
                                              AV132Postulacioneswwds_27_tfpostulacionesproveedornombre ,
                                              AV134Postulacioneswwds_29_tfpostulacionesprecio ,
                                              AV135Postulacioneswwds_30_tfpostulacionesprecio_to ,
                                              AV136Postulacioneswwds_31_tfpostulacionesmultimediaserial ,
                                              AV137Postulacioneswwds_32_tfpostulacionesmultimediaserial_to ,
                                              AV141Postulacioneswwds_36_tfpostulacionesdescripcion_sel ,
                                              AV140Postulacioneswwds_35_tfpostulacionesdescripcion ,
                                              AV142Postulacioneswwds_37_tfpostulacionesreqsuministros_sel ,
                                              AV144Postulacioneswwds_39_tfpostulacionessuministrosdescripcion_sel ,
                                              AV143Postulacioneswwds_38_tfpostulacionessuministrosdescripcion ,
                                              AV145Postulacioneswwds_40_tfpostulacionesfechatrabajo ,
                                              AV146Postulacioneswwds_41_tfpostulacionesfechatrabajo_to ,
                                              AV147Postulacioneswwds_42_tfpostulacionesfechacierre ,
                                              AV148Postulacioneswwds_43_tfpostulacionesfechacierre_to ,
                                              AV150Postulacioneswwds_45_tfpostulacioneshoracierre_sel ,
                                              AV149Postulacioneswwds_44_tfpostulacioneshoracierre ,
                                              AV152Postulacioneswwds_47_tfpostulacionestipofecha_sel ,
                                              AV151Postulacioneswwds_46_tfpostulacionestipofecha ,
                                              AV154Postulacioneswwds_49_tfpostulacionesrgohoraservicio_sel ,
                                              AV153Postulacioneswwds_48_tfpostulacionesrgohoraservicio ,
                                              AV156Postulacioneswwds_51_tfpostulacionesapellidonombre_sel ,
                                              AV155Postulacioneswwds_50_tfpostulacionesapellidonombre ,
                                              AV158Postulacioneswwds_53_tfpostulacionesmail_sel ,
                                              AV157Postulacioneswwds_52_tfpostulacionesmail ,
                                              AV160Postulacioneswwds_55_tfpostulacionestelefono_sel ,
                                              AV159Postulacioneswwds_54_tfpostulacionestelefono ,
                                              AV161Postulacioneswwds_56_tfpostulacionesfechaalta ,
                                              AV162Postulacioneswwds_57_tfpostulacionesfechaalta_to ,
                                              AV163Postulacioneswwds_58_tfpostulacionesestado_sels.Count ,
                                              AV164Postulacioneswwds_59_tfpostulacionessecuserid ,
                                              AV165Postulacioneswwds_60_tfpostulacionessecuserid_to ,
                                              A969PostulacionesProveedorNombre ,
                                              A945PostulacionesProveedorId ,
                                              A943ServiciosNombre ,
                                              A422PostulacionesId ,
                                              A942ServiciosId ,
                                              A946PostulacionesPrecio ,
                                              A961PostulacionesMultimediaSerial ,
                                              A936PostulacionesDescripcion ,
                                              A937PostulacionesReqSuministros ,
                                              A938PostulacionesSuministrosDescri ,
                                              A947PostulacionesFechaTrabajo ,
                                              A939PostulacionesFechaCierre ,
                                              A940PostulacionesHoraCierre ,
                                              A941PostulacionesTipoFecha ,
                                              A949PostulacionesRgoHoraservicio ,
                                              A950PostulacionesApellidoNombre ,
                                              A951PostulacionesMail ,
                                              A952PostulacionesTelefono ,
                                              A425PostulacionesFechaAlta ,
                                              A948PostulacionesSecUserId ,
                                              AV106Postulacioneswwds_1_filterfulltext ,
                                              A970PostulacionesSolicitudesId ,
                                              AV138Postulacioneswwds_33_tfpostulacionessolicitudesid ,
                                              AV139Postulacioneswwds_34_tfpostulacionessolicitudesid_to } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG,
                                              TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.DATE,
                                              TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.INT, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG,
                                              TypeConstants.BOOLEAN, TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.LONG,
                                              TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.LONG, TypeConstants.LONG
                                              }
         });
         lV109Postulacioneswwds_4_postulacionesproveedornombre1 = StringUtil.PadR( StringUtil.RTrim( AV109Postulacioneswwds_4_postulacionesproveedornombre1), 80, "%");
         lV109Postulacioneswwds_4_postulacionesproveedornombre1 = StringUtil.PadR( StringUtil.RTrim( AV109Postulacioneswwds_4_postulacionesproveedornombre1), 80, "%");
         lV111Postulacioneswwds_6_serviciosnombre1 = StringUtil.PadR( StringUtil.RTrim( AV111Postulacioneswwds_6_serviciosnombre1), 80, "%");
         lV111Postulacioneswwds_6_serviciosnombre1 = StringUtil.PadR( StringUtil.RTrim( AV111Postulacioneswwds_6_serviciosnombre1), 80, "%");
         lV115Postulacioneswwds_10_postulacionesproveedornombre2 = StringUtil.PadR( StringUtil.RTrim( AV115Postulacioneswwds_10_postulacionesproveedornombre2), 80, "%");
         lV115Postulacioneswwds_10_postulacionesproveedornombre2 = StringUtil.PadR( StringUtil.RTrim( AV115Postulacioneswwds_10_postulacionesproveedornombre2), 80, "%");
         lV117Postulacioneswwds_12_serviciosnombre2 = StringUtil.PadR( StringUtil.RTrim( AV117Postulacioneswwds_12_serviciosnombre2), 80, "%");
         lV117Postulacioneswwds_12_serviciosnombre2 = StringUtil.PadR( StringUtil.RTrim( AV117Postulacioneswwds_12_serviciosnombre2), 80, "%");
         lV121Postulacioneswwds_16_postulacionesproveedornombre3 = StringUtil.PadR( StringUtil.RTrim( AV121Postulacioneswwds_16_postulacionesproveedornombre3), 80, "%");
         lV121Postulacioneswwds_16_postulacionesproveedornombre3 = StringUtil.PadR( StringUtil.RTrim( AV121Postulacioneswwds_16_postulacionesproveedornombre3), 80, "%");
         lV123Postulacioneswwds_18_serviciosnombre3 = StringUtil.PadR( StringUtil.RTrim( AV123Postulacioneswwds_18_serviciosnombre3), 80, "%");
         lV123Postulacioneswwds_18_serviciosnombre3 = StringUtil.PadR( StringUtil.RTrim( AV123Postulacioneswwds_18_serviciosnombre3), 80, "%");
         lV128Postulacioneswwds_23_tfserviciosnombre = StringUtil.PadR( StringUtil.RTrim( AV128Postulacioneswwds_23_tfserviciosnombre), 80, "%");
         lV132Postulacioneswwds_27_tfpostulacionesproveedornombre = StringUtil.PadR( StringUtil.RTrim( AV132Postulacioneswwds_27_tfpostulacionesproveedornombre), 80, "%");
         lV140Postulacioneswwds_35_tfpostulacionesdescripcion = StringUtil.PadR( StringUtil.RTrim( AV140Postulacioneswwds_35_tfpostulacionesdescripcion), 2000, "%");
         lV143Postulacioneswwds_38_tfpostulacionessuministrosdescripcion = StringUtil.PadR( StringUtil.RTrim( AV143Postulacioneswwds_38_tfpostulacionessuministrosdescripcion), 250, "%");
         lV149Postulacioneswwds_44_tfpostulacioneshoracierre = StringUtil.Concat( StringUtil.RTrim( AV149Postulacioneswwds_44_tfpostulacioneshoracierre), "%", "");
         lV151Postulacioneswwds_46_tfpostulacionestipofecha = StringUtil.Concat( StringUtil.RTrim( AV151Postulacioneswwds_46_tfpostulacionestipofecha), "%", "");
         lV153Postulacioneswwds_48_tfpostulacionesrgohoraservicio = StringUtil.PadR( StringUtil.RTrim( AV153Postulacioneswwds_48_tfpostulacionesrgohoraservicio), 5, "%");
         lV155Postulacioneswwds_50_tfpostulacionesapellidonombre = StringUtil.PadR( StringUtil.RTrim( AV155Postulacioneswwds_50_tfpostulacionesapellidonombre), 80, "%");
         lV157Postulacioneswwds_52_tfpostulacionesmail = StringUtil.Concat( StringUtil.RTrim( AV157Postulacioneswwds_52_tfpostulacionesmail), "%", "");
         lV159Postulacioneswwds_54_tfpostulacionestelefono = StringUtil.PadR( StringUtil.RTrim( AV159Postulacioneswwds_54_tfpostulacionestelefono), 20, "%");
         /* Using cursor P00LA17 */
         pr_default.execute(7, new Object[] {n422PostulacionesId, A422PostulacionesId, AV138Postulacioneswwds_33_tfpostulacionessolicitudesid, AV138Postulacioneswwds_33_tfpostulacionessolicitudesid, AV139Postulacioneswwds_34_tfpostulacionessolicitudesid_to, AV139Postulacioneswwds_34_tfpostulacionessolicitudesid_to, lV109Postulacioneswwds_4_postulacionesproveedornombre1, lV109Postulacioneswwds_4_postulacionesproveedornombre1, AV110Postulacioneswwds_5_postulacionesproveedorid1, AV110Postulacioneswwds_5_postulacionesproveedorid1, AV110Postulacioneswwds_5_postulacionesproveedorid1, lV111Postulacioneswwds_6_serviciosnombre1, lV111Postulacioneswwds_6_serviciosnombre1, lV115Postulacioneswwds_10_postulacionesproveedornombre2, lV115Postulacioneswwds_10_postulacionesproveedornombre2, AV116Postulacioneswwds_11_postulacionesproveedorid2, AV116Postulacioneswwds_11_postulacionesproveedorid2, AV116Postulacioneswwds_11_postulacionesproveedorid2, lV117Postulacioneswwds_12_serviciosnombre2, lV117Postulacioneswwds_12_serviciosnombre2, lV121Postulacioneswwds_16_postulacionesproveedornombre3, lV121Postulacioneswwds_16_postulacionesproveedornombre3, AV122Postulacioneswwds_17_postulacionesproveedorid3, AV122Postulacioneswwds_17_postulacionesproveedorid3, AV122Postulacioneswwds_17_postulacionesproveedorid3, lV123Postulacioneswwds_18_serviciosnombre3, lV123Postulacioneswwds_18_serviciosnombre3, AV124Postulacioneswwds_19_tfpostulacionesid, AV125Postulacioneswwds_20_tfpostulacionesid_to, AV126Postulacioneswwds_21_tfserviciosid, AV127Postulacioneswwds_22_tfserviciosid_to, lV128Postulacioneswwds_23_tfserviciosnombre, AV129Postulacioneswwds_24_tfserviciosnombre_sel, AV130Postulacioneswwds_25_tfpostulacionesproveedorid, AV131Postulacioneswwds_26_tfpostulacionesproveedorid_to, lV132Postulacioneswwds_27_tfpostulacionesproveedornombre, AV133Postulacioneswwds_28_tfpostulacionesproveedornombre_sel, AV134Postulacioneswwds_29_tfpostulacionesprecio, AV135Postulacioneswwds_30_tfpostulacionesprecio_to, AV136Postulacioneswwds_31_tfpostulacionesmultimediaserial, AV137Postulacioneswwds_32_tfpostulacionesmultimediaserial_to, lV140Postulacioneswwds_35_tfpostulacionesdescripcion, AV141Postulacioneswwds_36_tfpostulacionesdescripcion_sel, lV143Postulacioneswwds_38_tfpostulacionessuministrosdescripcion, AV144Postulacioneswwds_39_tfpostulacionessuministrosdescripcion_sel, AV145Postulacioneswwds_40_tfpostulacionesfechatrabajo, AV146Postulacioneswwds_41_tfpostulacionesfechatrabajo_to, AV147Postulacioneswwds_42_tfpostulacionesfechacierre, AV148Postulacioneswwds_43_tfpostulacionesfechacierre_to, lV149Postulacioneswwds_44_tfpostulacioneshoracierre, AV150Postulacioneswwds_45_tfpostulacioneshoracierre_sel, lV151Postulacioneswwds_46_tfpostulacionestipofecha, AV152Postulacioneswwds_47_tfpostulacionestipofecha_sel, lV153Postulacioneswwds_48_tfpostulacionesrgohoraservicio, AV154Postulacioneswwds_49_tfpostulacionesrgohoraservicio_sel, lV155Postulacioneswwds_50_tfpostulacionesapellidonombre, AV156Postulacioneswwds_51_tfpostulacionesapellidonombre_sel, lV157Postulacioneswwds_52_tfpostulacionesmail, AV158Postulacioneswwds_53_tfpostulacionesmail_sel, lV159Postulacioneswwds_54_tfpostulacionestelefono, AV160Postulacioneswwds_55_tfpostulacionestelefono_sel, AV161Postulacioneswwds_56_tfpostulacionesfechaalta, AV162Postulacioneswwds_57_tfpostulacionesfechaalta_to, AV164Postulacioneswwds_59_tfpostulacionessecuserid, AV165Postulacioneswwds_60_tfpostulacionessecuserid_to});
         while ( (pr_default.getStatus(7) != 101) )
         {
            BRKLA16 = false;
            A950PostulacionesApellidoNombre = P00LA17_A950PostulacionesApellidoNombre[0];
            A948PostulacionesSecUserId = P00LA17_A948PostulacionesSecUserId[0];
            A425PostulacionesFechaAlta = P00LA17_A425PostulacionesFechaAlta[0];
            A952PostulacionesTelefono = P00LA17_A952PostulacionesTelefono[0];
            A951PostulacionesMail = P00LA17_A951PostulacionesMail[0];
            A949PostulacionesRgoHoraservicio = P00LA17_A949PostulacionesRgoHoraservicio[0];
            A941PostulacionesTipoFecha = P00LA17_A941PostulacionesTipoFecha[0];
            A940PostulacionesHoraCierre = P00LA17_A940PostulacionesHoraCierre[0];
            A939PostulacionesFechaCierre = P00LA17_A939PostulacionesFechaCierre[0];
            A947PostulacionesFechaTrabajo = P00LA17_A947PostulacionesFechaTrabajo[0];
            A938PostulacionesSuministrosDescri = P00LA17_A938PostulacionesSuministrosDescri[0];
            A937PostulacionesReqSuministros = P00LA17_A937PostulacionesReqSuministros[0];
            A936PostulacionesDescripcion = P00LA17_A936PostulacionesDescripcion[0];
            A961PostulacionesMultimediaSerial = P00LA17_A961PostulacionesMultimediaSerial[0];
            A946PostulacionesPrecio = P00LA17_A946PostulacionesPrecio[0];
            A969PostulacionesProveedorNombre = P00LA17_A969PostulacionesProveedorNombre[0];
            A943ServiciosNombre = P00LA17_A943ServiciosNombre[0];
            A942ServiciosId = P00LA17_A942ServiciosId[0];
            n942ServiciosId = P00LA17_n942ServiciosId[0];
            A422PostulacionesId = P00LA17_A422PostulacionesId[0];
            n422PostulacionesId = P00LA17_n422PostulacionesId[0];
            A945PostulacionesProveedorId = P00LA17_A945PostulacionesProveedorId[0];
            A424PostulacionesEstado = P00LA17_A424PostulacionesEstado[0];
            A970PostulacionesSolicitudesId = P00LA17_A970PostulacionesSolicitudesId[0];
            n970PostulacionesSolicitudesId = P00LA17_n970PostulacionesSolicitudesId[0];
            A943ServiciosNombre = P00LA17_A943ServiciosNombre[0];
            A969PostulacionesProveedorNombre = P00LA17_A969PostulacionesProveedorNombre[0];
            A970PostulacionesSolicitudesId = P00LA17_A970PostulacionesSolicitudesId[0];
            n970PostulacionesSolicitudesId = P00LA17_n970PostulacionesSolicitudesId[0];
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV106Postulacioneswwds_1_filterfulltext)) || ( ( StringUtil.Like( StringUtil.Str( (decimal)(A422PostulacionesId), 18, 0) , StringUtil.PadR( "%" + AV106Postulacioneswwds_1_filterfulltext , 254 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Str( (decimal)(A942ServiciosId), 18, 0) , StringUtil.PadR( "%" + AV106Postulacioneswwds_1_filterfulltext , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A943ServiciosNombre) , StringUtil.PadR( "%" + StringUtil.Upper( AV106Postulacioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Str( (decimal)(A945PostulacionesProveedorId), 18, 0) , StringUtil.PadR( "%" + AV106Postulacioneswwds_1_filterfulltext , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A969PostulacionesProveedorNombre) , StringUtil.PadR( "%" + StringUtil.Upper( AV106Postulacioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Str( A946PostulacionesPrecio, 18, 2) , StringUtil.PadR( "%" + AV106Postulacioneswwds_1_filterfulltext , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Str( (decimal)(A961PostulacionesMultimediaSerial), 4, 0) , StringUtil.PadR( "%" + AV106Postulacioneswwds_1_filterfulltext , 254 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Str( (decimal)(A970PostulacionesSolicitudesId), 18, 0) , StringUtil.PadR( "%" + AV106Postulacioneswwds_1_filterfulltext , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A936PostulacionesDescripcion) , StringUtil.PadR( "%" + StringUtil.Upper( AV106Postulacioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Upper( A938PostulacionesSuministrosDescri) , StringUtil.PadR( "%" + StringUtil.Upper( AV106Postulacioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A940PostulacionesHoraCierre) , StringUtil.PadR( "%" + StringUtil.Upper( AV106Postulacioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Upper( A941PostulacionesTipoFecha) , StringUtil.PadR( "%" + StringUtil.Upper( AV106Postulacioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A949PostulacionesRgoHoraservicio) , StringUtil.PadR( "%" + StringUtil.Upper( AV106Postulacioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Upper( A950PostulacionesApellidoNombre) , StringUtil.PadR( "%" + StringUtil.Upper( AV106Postulacioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A951PostulacionesMail) , StringUtil.PadR( "%" + StringUtil.Upper( AV106Postulacioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Upper( A952PostulacionesTelefono) , StringUtil.PadR( "%" + StringUtil.Upper( AV106Postulacioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( context.GetMessage( "habilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV106Postulacioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A424PostulacionesEstado, "HAB") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "deshabilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV106Postulacioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A424PostulacionesEstado, "DES") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "ganador", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV106Postulacioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) &&
            ( StringUtil.StrCmp(A424PostulacionesEstado, "GAN") == 0 ) ) || ( StringUtil.Like( StringUtil.Str( (decimal)(A948PostulacionesSecUserId), 18, 0) , StringUtil.PadR( "%" + AV106Postulacioneswwds_1_filterfulltext , 254 , "%"),  ' ' ) ) )
            )
            {
               AV58count = 0;
               while ( (pr_default.getStatus(7) != 101) && ( StringUtil.StrCmp(P00LA17_A950PostulacionesApellidoNombre[0], A950PostulacionesApellidoNombre) == 0 ) )
               {
                  BRKLA16 = false;
                  A422PostulacionesId = P00LA17_A422PostulacionesId[0];
                  n422PostulacionesId = P00LA17_n422PostulacionesId[0];
                  AV58count = (long)(AV58count+1);
                  BRKLA16 = true;
                  pr_default.readNext(7);
               }
               if ( (0==AV49SkipItems) )
               {
                  AV53Option = (String.IsNullOrEmpty(StringUtil.RTrim( A950PostulacionesApellidoNombre)) ? "<#Empty#>" : A950PostulacionesApellidoNombre);
                  AV54Options.Add(AV53Option, 0);
                  AV57OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV58count), "Z,ZZZ,ZZZ,ZZ9")), 0);
                  if ( AV54Options.Count == 10 )
                  {
                     /* Exit For each command. Update data (if necessary), close cursors & exit. */
                     if (true) break;
                  }
               }
               else
               {
                  AV49SkipItems = (short)(AV49SkipItems-1);
               }
            }
            if ( ! BRKLA16 )
            {
               BRKLA16 = true;
               pr_default.readNext(7);
            }
         }
         pr_default.close(7);
      }

      protected void S201( )
      {
         /* 'LOADPOSTULACIONESMAILOPTIONS' Routine */
         returnInSub = false;
         AV38TFPostulacionesMail = AV48SearchTxt;
         AV39TFPostulacionesMail_Sel = "";
         AV106Postulacioneswwds_1_filterfulltext = AV70FilterFullText;
         AV107Postulacioneswwds_2_dynamicfiltersselector1 = AV71DynamicFiltersSelector1;
         AV108Postulacioneswwds_3_dynamicfiltersoperator1 = AV72DynamicFiltersOperator1;
         AV109Postulacioneswwds_4_postulacionesproveedornombre1 = AV91PostulacionesProveedorNombre1;
         AV110Postulacioneswwds_5_postulacionesproveedorid1 = AV73PostulacionesProveedorId1;
         AV111Postulacioneswwds_6_serviciosnombre1 = AV74ServiciosNombre1;
         AV112Postulacioneswwds_7_dynamicfiltersenabled2 = AV75DynamicFiltersEnabled2;
         AV113Postulacioneswwds_8_dynamicfiltersselector2 = AV76DynamicFiltersSelector2;
         AV114Postulacioneswwds_9_dynamicfiltersoperator2 = AV77DynamicFiltersOperator2;
         AV115Postulacioneswwds_10_postulacionesproveedornombre2 = AV92PostulacionesProveedorNombre2;
         AV116Postulacioneswwds_11_postulacionesproveedorid2 = AV78PostulacionesProveedorId2;
         AV117Postulacioneswwds_12_serviciosnombre2 = AV79ServiciosNombre2;
         AV118Postulacioneswwds_13_dynamicfiltersenabled3 = AV80DynamicFiltersEnabled3;
         AV119Postulacioneswwds_14_dynamicfiltersselector3 = AV81DynamicFiltersSelector3;
         AV120Postulacioneswwds_15_dynamicfiltersoperator3 = AV82DynamicFiltersOperator3;
         AV121Postulacioneswwds_16_postulacionesproveedornombre3 = AV93PostulacionesProveedorNombre3;
         AV122Postulacioneswwds_17_postulacionesproveedorid3 = AV83PostulacionesProveedorId3;
         AV123Postulacioneswwds_18_serviciosnombre3 = AV84ServiciosNombre3;
         AV124Postulacioneswwds_19_tfpostulacionesid = AV11TFPostulacionesId;
         AV125Postulacioneswwds_20_tfpostulacionesid_to = AV12TFPostulacionesId_To;
         AV126Postulacioneswwds_21_tfserviciosid = AV13TFServiciosId;
         AV127Postulacioneswwds_22_tfserviciosid_to = AV14TFServiciosId_To;
         AV128Postulacioneswwds_23_tfserviciosnombre = AV15TFServiciosNombre;
         AV129Postulacioneswwds_24_tfserviciosnombre_sel = AV16TFServiciosNombre_Sel;
         AV130Postulacioneswwds_25_tfpostulacionesproveedorid = AV17TFPostulacionesProveedorId;
         AV131Postulacioneswwds_26_tfpostulacionesproveedorid_to = AV18TFPostulacionesProveedorId_To;
         AV132Postulacioneswwds_27_tfpostulacionesproveedornombre = AV85TFPostulacionesProveedorNombre;
         AV133Postulacioneswwds_28_tfpostulacionesproveedornombre_sel = AV86TFPostulacionesProveedorNombre_Sel;
         AV134Postulacioneswwds_29_tfpostulacionesprecio = AV19TFPostulacionesPrecio;
         AV135Postulacioneswwds_30_tfpostulacionesprecio_to = AV20TFPostulacionesPrecio_To;
         AV136Postulacioneswwds_31_tfpostulacionesmultimediaserial = AV87TFPostulacionesMultimediaSerial;
         AV137Postulacioneswwds_32_tfpostulacionesmultimediaserial_to = AV88TFPostulacionesMultimediaSerial_To;
         AV138Postulacioneswwds_33_tfpostulacionessolicitudesid = AV89TFPostulacionesSolicitudesId;
         AV139Postulacioneswwds_34_tfpostulacionessolicitudesid_to = AV90TFPostulacionesSolicitudesId_To;
         AV140Postulacioneswwds_35_tfpostulacionesdescripcion = AV21TFPostulacionesDescripcion;
         AV141Postulacioneswwds_36_tfpostulacionesdescripcion_sel = AV22TFPostulacionesDescripcion_Sel;
         AV142Postulacioneswwds_37_tfpostulacionesreqsuministros_sel = AV23TFPostulacionesReqSuministros_Sel;
         AV143Postulacioneswwds_38_tfpostulacionessuministrosdescripcion = AV24TFPostulacionesSuministrosDescripcion;
         AV144Postulacioneswwds_39_tfpostulacionessuministrosdescripcion_sel = AV25TFPostulacionesSuministrosDescripcion_Sel;
         AV145Postulacioneswwds_40_tfpostulacionesfechatrabajo = AV26TFPostulacionesFechaTrabajo;
         AV146Postulacioneswwds_41_tfpostulacionesfechatrabajo_to = AV27TFPostulacionesFechaTrabajo_To;
         AV147Postulacioneswwds_42_tfpostulacionesfechacierre = AV28TFPostulacionesFechaCierre;
         AV148Postulacioneswwds_43_tfpostulacionesfechacierre_to = AV29TFPostulacionesFechaCierre_To;
         AV149Postulacioneswwds_44_tfpostulacioneshoracierre = AV30TFPostulacionesHoraCierre;
         AV150Postulacioneswwds_45_tfpostulacioneshoracierre_sel = AV31TFPostulacionesHoraCierre_Sel;
         AV151Postulacioneswwds_46_tfpostulacionestipofecha = AV32TFPostulacionesTipoFecha;
         AV152Postulacioneswwds_47_tfpostulacionestipofecha_sel = AV103TFPostulacionesTipoFecha_Sel;
         AV153Postulacioneswwds_48_tfpostulacionesrgohoraservicio = AV34TFPostulacionesRgoHoraservicio;
         AV154Postulacioneswwds_49_tfpostulacionesrgohoraservicio_sel = AV35TFPostulacionesRgoHoraservicio_Sel;
         AV155Postulacioneswwds_50_tfpostulacionesapellidonombre = AV36TFPostulacionesApellidoNombre;
         AV156Postulacioneswwds_51_tfpostulacionesapellidonombre_sel = AV37TFPostulacionesApellidoNombre_Sel;
         AV157Postulacioneswwds_52_tfpostulacionesmail = AV38TFPostulacionesMail;
         AV158Postulacioneswwds_53_tfpostulacionesmail_sel = AV39TFPostulacionesMail_Sel;
         AV159Postulacioneswwds_54_tfpostulacionestelefono = AV40TFPostulacionesTelefono;
         AV160Postulacioneswwds_55_tfpostulacionestelefono_sel = AV41TFPostulacionesTelefono_Sel;
         AV161Postulacioneswwds_56_tfpostulacionesfechaalta = AV42TFPostulacionesFechaAlta;
         AV162Postulacioneswwds_57_tfpostulacionesfechaalta_to = AV43TFPostulacionesFechaAlta_To;
         AV163Postulacioneswwds_58_tfpostulacionesestado_sels = AV45TFPostulacionesEstado_Sels;
         AV164Postulacioneswwds_59_tfpostulacionessecuserid = AV46TFPostulacionesSecUserId;
         AV165Postulacioneswwds_60_tfpostulacionessecuserid_to = AV47TFPostulacionesSecUserId_To;
         pr_default.dynParam(8, new Object[]{ new Object[]{
                                              A424PostulacionesEstado ,
                                              AV163Postulacioneswwds_58_tfpostulacionesestado_sels ,
                                              AV107Postulacioneswwds_2_dynamicfiltersselector1 ,
                                              AV108Postulacioneswwds_3_dynamicfiltersoperator1 ,
                                              AV109Postulacioneswwds_4_postulacionesproveedornombre1 ,
                                              AV110Postulacioneswwds_5_postulacionesproveedorid1 ,
                                              AV111Postulacioneswwds_6_serviciosnombre1 ,
                                              AV112Postulacioneswwds_7_dynamicfiltersenabled2 ,
                                              AV113Postulacioneswwds_8_dynamicfiltersselector2 ,
                                              AV114Postulacioneswwds_9_dynamicfiltersoperator2 ,
                                              AV115Postulacioneswwds_10_postulacionesproveedornombre2 ,
                                              AV116Postulacioneswwds_11_postulacionesproveedorid2 ,
                                              AV117Postulacioneswwds_12_serviciosnombre2 ,
                                              AV118Postulacioneswwds_13_dynamicfiltersenabled3 ,
                                              AV119Postulacioneswwds_14_dynamicfiltersselector3 ,
                                              AV120Postulacioneswwds_15_dynamicfiltersoperator3 ,
                                              AV121Postulacioneswwds_16_postulacionesproveedornombre3 ,
                                              AV122Postulacioneswwds_17_postulacionesproveedorid3 ,
                                              AV123Postulacioneswwds_18_serviciosnombre3 ,
                                              AV124Postulacioneswwds_19_tfpostulacionesid ,
                                              AV125Postulacioneswwds_20_tfpostulacionesid_to ,
                                              AV126Postulacioneswwds_21_tfserviciosid ,
                                              AV127Postulacioneswwds_22_tfserviciosid_to ,
                                              AV129Postulacioneswwds_24_tfserviciosnombre_sel ,
                                              AV128Postulacioneswwds_23_tfserviciosnombre ,
                                              AV130Postulacioneswwds_25_tfpostulacionesproveedorid ,
                                              AV131Postulacioneswwds_26_tfpostulacionesproveedorid_to ,
                                              AV133Postulacioneswwds_28_tfpostulacionesproveedornombre_sel ,
                                              AV132Postulacioneswwds_27_tfpostulacionesproveedornombre ,
                                              AV134Postulacioneswwds_29_tfpostulacionesprecio ,
                                              AV135Postulacioneswwds_30_tfpostulacionesprecio_to ,
                                              AV136Postulacioneswwds_31_tfpostulacionesmultimediaserial ,
                                              AV137Postulacioneswwds_32_tfpostulacionesmultimediaserial_to ,
                                              AV141Postulacioneswwds_36_tfpostulacionesdescripcion_sel ,
                                              AV140Postulacioneswwds_35_tfpostulacionesdescripcion ,
                                              AV142Postulacioneswwds_37_tfpostulacionesreqsuministros_sel ,
                                              AV144Postulacioneswwds_39_tfpostulacionessuministrosdescripcion_sel ,
                                              AV143Postulacioneswwds_38_tfpostulacionessuministrosdescripcion ,
                                              AV145Postulacioneswwds_40_tfpostulacionesfechatrabajo ,
                                              AV146Postulacioneswwds_41_tfpostulacionesfechatrabajo_to ,
                                              AV147Postulacioneswwds_42_tfpostulacionesfechacierre ,
                                              AV148Postulacioneswwds_43_tfpostulacionesfechacierre_to ,
                                              AV150Postulacioneswwds_45_tfpostulacioneshoracierre_sel ,
                                              AV149Postulacioneswwds_44_tfpostulacioneshoracierre ,
                                              AV152Postulacioneswwds_47_tfpostulacionestipofecha_sel ,
                                              AV151Postulacioneswwds_46_tfpostulacionestipofecha ,
                                              AV154Postulacioneswwds_49_tfpostulacionesrgohoraservicio_sel ,
                                              AV153Postulacioneswwds_48_tfpostulacionesrgohoraservicio ,
                                              AV156Postulacioneswwds_51_tfpostulacionesapellidonombre_sel ,
                                              AV155Postulacioneswwds_50_tfpostulacionesapellidonombre ,
                                              AV158Postulacioneswwds_53_tfpostulacionesmail_sel ,
                                              AV157Postulacioneswwds_52_tfpostulacionesmail ,
                                              AV160Postulacioneswwds_55_tfpostulacionestelefono_sel ,
                                              AV159Postulacioneswwds_54_tfpostulacionestelefono ,
                                              AV161Postulacioneswwds_56_tfpostulacionesfechaalta ,
                                              AV162Postulacioneswwds_57_tfpostulacionesfechaalta_to ,
                                              AV163Postulacioneswwds_58_tfpostulacionesestado_sels.Count ,
                                              AV164Postulacioneswwds_59_tfpostulacionessecuserid ,
                                              AV165Postulacioneswwds_60_tfpostulacionessecuserid_to ,
                                              A969PostulacionesProveedorNombre ,
                                              A945PostulacionesProveedorId ,
                                              A943ServiciosNombre ,
                                              A422PostulacionesId ,
                                              A942ServiciosId ,
                                              A946PostulacionesPrecio ,
                                              A961PostulacionesMultimediaSerial ,
                                              A936PostulacionesDescripcion ,
                                              A937PostulacionesReqSuministros ,
                                              A938PostulacionesSuministrosDescri ,
                                              A947PostulacionesFechaTrabajo ,
                                              A939PostulacionesFechaCierre ,
                                              A940PostulacionesHoraCierre ,
                                              A941PostulacionesTipoFecha ,
                                              A949PostulacionesRgoHoraservicio ,
                                              A950PostulacionesApellidoNombre ,
                                              A951PostulacionesMail ,
                                              A952PostulacionesTelefono ,
                                              A425PostulacionesFechaAlta ,
                                              A948PostulacionesSecUserId ,
                                              AV106Postulacioneswwds_1_filterfulltext ,
                                              A970PostulacionesSolicitudesId ,
                                              AV138Postulacioneswwds_33_tfpostulacionessolicitudesid ,
                                              AV139Postulacioneswwds_34_tfpostulacionessolicitudesid_to } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG,
                                              TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.DATE,
                                              TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.INT, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG,
                                              TypeConstants.BOOLEAN, TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.LONG,
                                              TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.LONG, TypeConstants.LONG
                                              }
         });
         lV109Postulacioneswwds_4_postulacionesproveedornombre1 = StringUtil.PadR( StringUtil.RTrim( AV109Postulacioneswwds_4_postulacionesproveedornombre1), 80, "%");
         lV109Postulacioneswwds_4_postulacionesproveedornombre1 = StringUtil.PadR( StringUtil.RTrim( AV109Postulacioneswwds_4_postulacionesproveedornombre1), 80, "%");
         lV111Postulacioneswwds_6_serviciosnombre1 = StringUtil.PadR( StringUtil.RTrim( AV111Postulacioneswwds_6_serviciosnombre1), 80, "%");
         lV111Postulacioneswwds_6_serviciosnombre1 = StringUtil.PadR( StringUtil.RTrim( AV111Postulacioneswwds_6_serviciosnombre1), 80, "%");
         lV115Postulacioneswwds_10_postulacionesproveedornombre2 = StringUtil.PadR( StringUtil.RTrim( AV115Postulacioneswwds_10_postulacionesproveedornombre2), 80, "%");
         lV115Postulacioneswwds_10_postulacionesproveedornombre2 = StringUtil.PadR( StringUtil.RTrim( AV115Postulacioneswwds_10_postulacionesproveedornombre2), 80, "%");
         lV117Postulacioneswwds_12_serviciosnombre2 = StringUtil.PadR( StringUtil.RTrim( AV117Postulacioneswwds_12_serviciosnombre2), 80, "%");
         lV117Postulacioneswwds_12_serviciosnombre2 = StringUtil.PadR( StringUtil.RTrim( AV117Postulacioneswwds_12_serviciosnombre2), 80, "%");
         lV121Postulacioneswwds_16_postulacionesproveedornombre3 = StringUtil.PadR( StringUtil.RTrim( AV121Postulacioneswwds_16_postulacionesproveedornombre3), 80, "%");
         lV121Postulacioneswwds_16_postulacionesproveedornombre3 = StringUtil.PadR( StringUtil.RTrim( AV121Postulacioneswwds_16_postulacionesproveedornombre3), 80, "%");
         lV123Postulacioneswwds_18_serviciosnombre3 = StringUtil.PadR( StringUtil.RTrim( AV123Postulacioneswwds_18_serviciosnombre3), 80, "%");
         lV123Postulacioneswwds_18_serviciosnombre3 = StringUtil.PadR( StringUtil.RTrim( AV123Postulacioneswwds_18_serviciosnombre3), 80, "%");
         lV128Postulacioneswwds_23_tfserviciosnombre = StringUtil.PadR( StringUtil.RTrim( AV128Postulacioneswwds_23_tfserviciosnombre), 80, "%");
         lV132Postulacioneswwds_27_tfpostulacionesproveedornombre = StringUtil.PadR( StringUtil.RTrim( AV132Postulacioneswwds_27_tfpostulacionesproveedornombre), 80, "%");
         lV140Postulacioneswwds_35_tfpostulacionesdescripcion = StringUtil.PadR( StringUtil.RTrim( AV140Postulacioneswwds_35_tfpostulacionesdescripcion), 2000, "%");
         lV143Postulacioneswwds_38_tfpostulacionessuministrosdescripcion = StringUtil.PadR( StringUtil.RTrim( AV143Postulacioneswwds_38_tfpostulacionessuministrosdescripcion), 250, "%");
         lV149Postulacioneswwds_44_tfpostulacioneshoracierre = StringUtil.Concat( StringUtil.RTrim( AV149Postulacioneswwds_44_tfpostulacioneshoracierre), "%", "");
         lV151Postulacioneswwds_46_tfpostulacionestipofecha = StringUtil.Concat( StringUtil.RTrim( AV151Postulacioneswwds_46_tfpostulacionestipofecha), "%", "");
         lV153Postulacioneswwds_48_tfpostulacionesrgohoraservicio = StringUtil.PadR( StringUtil.RTrim( AV153Postulacioneswwds_48_tfpostulacionesrgohoraservicio), 5, "%");
         lV155Postulacioneswwds_50_tfpostulacionesapellidonombre = StringUtil.PadR( StringUtil.RTrim( AV155Postulacioneswwds_50_tfpostulacionesapellidonombre), 80, "%");
         lV157Postulacioneswwds_52_tfpostulacionesmail = StringUtil.Concat( StringUtil.RTrim( AV157Postulacioneswwds_52_tfpostulacionesmail), "%", "");
         lV159Postulacioneswwds_54_tfpostulacionestelefono = StringUtil.PadR( StringUtil.RTrim( AV159Postulacioneswwds_54_tfpostulacionestelefono), 20, "%");
         /* Using cursor P00LA19 */
         pr_default.execute(8, new Object[] {n422PostulacionesId, A422PostulacionesId, AV138Postulacioneswwds_33_tfpostulacionessolicitudesid, AV138Postulacioneswwds_33_tfpostulacionessolicitudesid, AV139Postulacioneswwds_34_tfpostulacionessolicitudesid_to, AV139Postulacioneswwds_34_tfpostulacionessolicitudesid_to, lV109Postulacioneswwds_4_postulacionesproveedornombre1, lV109Postulacioneswwds_4_postulacionesproveedornombre1, AV110Postulacioneswwds_5_postulacionesproveedorid1, AV110Postulacioneswwds_5_postulacionesproveedorid1, AV110Postulacioneswwds_5_postulacionesproveedorid1, lV111Postulacioneswwds_6_serviciosnombre1, lV111Postulacioneswwds_6_serviciosnombre1, lV115Postulacioneswwds_10_postulacionesproveedornombre2, lV115Postulacioneswwds_10_postulacionesproveedornombre2, AV116Postulacioneswwds_11_postulacionesproveedorid2, AV116Postulacioneswwds_11_postulacionesproveedorid2, AV116Postulacioneswwds_11_postulacionesproveedorid2, lV117Postulacioneswwds_12_serviciosnombre2, lV117Postulacioneswwds_12_serviciosnombre2, lV121Postulacioneswwds_16_postulacionesproveedornombre3, lV121Postulacioneswwds_16_postulacionesproveedornombre3, AV122Postulacioneswwds_17_postulacionesproveedorid3, AV122Postulacioneswwds_17_postulacionesproveedorid3, AV122Postulacioneswwds_17_postulacionesproveedorid3, lV123Postulacioneswwds_18_serviciosnombre3, lV123Postulacioneswwds_18_serviciosnombre3, AV124Postulacioneswwds_19_tfpostulacionesid, AV125Postulacioneswwds_20_tfpostulacionesid_to, AV126Postulacioneswwds_21_tfserviciosid, AV127Postulacioneswwds_22_tfserviciosid_to, lV128Postulacioneswwds_23_tfserviciosnombre, AV129Postulacioneswwds_24_tfserviciosnombre_sel, AV130Postulacioneswwds_25_tfpostulacionesproveedorid, AV131Postulacioneswwds_26_tfpostulacionesproveedorid_to, lV132Postulacioneswwds_27_tfpostulacionesproveedornombre, AV133Postulacioneswwds_28_tfpostulacionesproveedornombre_sel, AV134Postulacioneswwds_29_tfpostulacionesprecio, AV135Postulacioneswwds_30_tfpostulacionesprecio_to, AV136Postulacioneswwds_31_tfpostulacionesmultimediaserial, AV137Postulacioneswwds_32_tfpostulacionesmultimediaserial_to, lV140Postulacioneswwds_35_tfpostulacionesdescripcion, AV141Postulacioneswwds_36_tfpostulacionesdescripcion_sel, lV143Postulacioneswwds_38_tfpostulacionessuministrosdescripcion, AV144Postulacioneswwds_39_tfpostulacionessuministrosdescripcion_sel, AV145Postulacioneswwds_40_tfpostulacionesfechatrabajo, AV146Postulacioneswwds_41_tfpostulacionesfechatrabajo_to, AV147Postulacioneswwds_42_tfpostulacionesfechacierre, AV148Postulacioneswwds_43_tfpostulacionesfechacierre_to, lV149Postulacioneswwds_44_tfpostulacioneshoracierre, AV150Postulacioneswwds_45_tfpostulacioneshoracierre_sel, lV151Postulacioneswwds_46_tfpostulacionestipofecha, AV152Postulacioneswwds_47_tfpostulacionestipofecha_sel, lV153Postulacioneswwds_48_tfpostulacionesrgohoraservicio, AV154Postulacioneswwds_49_tfpostulacionesrgohoraservicio_sel, lV155Postulacioneswwds_50_tfpostulacionesapellidonombre, AV156Postulacioneswwds_51_tfpostulacionesapellidonombre_sel, lV157Postulacioneswwds_52_tfpostulacionesmail, AV158Postulacioneswwds_53_tfpostulacionesmail_sel, lV159Postulacioneswwds_54_tfpostulacionestelefono, AV160Postulacioneswwds_55_tfpostulacionestelefono_sel, AV161Postulacioneswwds_56_tfpostulacionesfechaalta, AV162Postulacioneswwds_57_tfpostulacionesfechaalta_to, AV164Postulacioneswwds_59_tfpostulacionessecuserid, AV165Postulacioneswwds_60_tfpostulacionessecuserid_to});
         while ( (pr_default.getStatus(8) != 101) )
         {
            BRKLA18 = false;
            A951PostulacionesMail = P00LA19_A951PostulacionesMail[0];
            A948PostulacionesSecUserId = P00LA19_A948PostulacionesSecUserId[0];
            A425PostulacionesFechaAlta = P00LA19_A425PostulacionesFechaAlta[0];
            A952PostulacionesTelefono = P00LA19_A952PostulacionesTelefono[0];
            A950PostulacionesApellidoNombre = P00LA19_A950PostulacionesApellidoNombre[0];
            A949PostulacionesRgoHoraservicio = P00LA19_A949PostulacionesRgoHoraservicio[0];
            A941PostulacionesTipoFecha = P00LA19_A941PostulacionesTipoFecha[0];
            A940PostulacionesHoraCierre = P00LA19_A940PostulacionesHoraCierre[0];
            A939PostulacionesFechaCierre = P00LA19_A939PostulacionesFechaCierre[0];
            A947PostulacionesFechaTrabajo = P00LA19_A947PostulacionesFechaTrabajo[0];
            A938PostulacionesSuministrosDescri = P00LA19_A938PostulacionesSuministrosDescri[0];
            A937PostulacionesReqSuministros = P00LA19_A937PostulacionesReqSuministros[0];
            A936PostulacionesDescripcion = P00LA19_A936PostulacionesDescripcion[0];
            A961PostulacionesMultimediaSerial = P00LA19_A961PostulacionesMultimediaSerial[0];
            A946PostulacionesPrecio = P00LA19_A946PostulacionesPrecio[0];
            A969PostulacionesProveedorNombre = P00LA19_A969PostulacionesProveedorNombre[0];
            A943ServiciosNombre = P00LA19_A943ServiciosNombre[0];
            A942ServiciosId = P00LA19_A942ServiciosId[0];
            n942ServiciosId = P00LA19_n942ServiciosId[0];
            A422PostulacionesId = P00LA19_A422PostulacionesId[0];
            n422PostulacionesId = P00LA19_n422PostulacionesId[0];
            A945PostulacionesProveedorId = P00LA19_A945PostulacionesProveedorId[0];
            A424PostulacionesEstado = P00LA19_A424PostulacionesEstado[0];
            A970PostulacionesSolicitudesId = P00LA19_A970PostulacionesSolicitudesId[0];
            n970PostulacionesSolicitudesId = P00LA19_n970PostulacionesSolicitudesId[0];
            A943ServiciosNombre = P00LA19_A943ServiciosNombre[0];
            A969PostulacionesProveedorNombre = P00LA19_A969PostulacionesProveedorNombre[0];
            A970PostulacionesSolicitudesId = P00LA19_A970PostulacionesSolicitudesId[0];
            n970PostulacionesSolicitudesId = P00LA19_n970PostulacionesSolicitudesId[0];
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV106Postulacioneswwds_1_filterfulltext)) || ( ( StringUtil.Like( StringUtil.Str( (decimal)(A422PostulacionesId), 18, 0) , StringUtil.PadR( "%" + AV106Postulacioneswwds_1_filterfulltext , 254 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Str( (decimal)(A942ServiciosId), 18, 0) , StringUtil.PadR( "%" + AV106Postulacioneswwds_1_filterfulltext , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A943ServiciosNombre) , StringUtil.PadR( "%" + StringUtil.Upper( AV106Postulacioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Str( (decimal)(A945PostulacionesProveedorId), 18, 0) , StringUtil.PadR( "%" + AV106Postulacioneswwds_1_filterfulltext , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A969PostulacionesProveedorNombre) , StringUtil.PadR( "%" + StringUtil.Upper( AV106Postulacioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Str( A946PostulacionesPrecio, 18, 2) , StringUtil.PadR( "%" + AV106Postulacioneswwds_1_filterfulltext , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Str( (decimal)(A961PostulacionesMultimediaSerial), 4, 0) , StringUtil.PadR( "%" + AV106Postulacioneswwds_1_filterfulltext , 254 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Str( (decimal)(A970PostulacionesSolicitudesId), 18, 0) , StringUtil.PadR( "%" + AV106Postulacioneswwds_1_filterfulltext , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A936PostulacionesDescripcion) , StringUtil.PadR( "%" + StringUtil.Upper( AV106Postulacioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Upper( A938PostulacionesSuministrosDescri) , StringUtil.PadR( "%" + StringUtil.Upper( AV106Postulacioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A940PostulacionesHoraCierre) , StringUtil.PadR( "%" + StringUtil.Upper( AV106Postulacioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Upper( A941PostulacionesTipoFecha) , StringUtil.PadR( "%" + StringUtil.Upper( AV106Postulacioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A949PostulacionesRgoHoraservicio) , StringUtil.PadR( "%" + StringUtil.Upper( AV106Postulacioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Upper( A950PostulacionesApellidoNombre) , StringUtil.PadR( "%" + StringUtil.Upper( AV106Postulacioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A951PostulacionesMail) , StringUtil.PadR( "%" + StringUtil.Upper( AV106Postulacioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Upper( A952PostulacionesTelefono) , StringUtil.PadR( "%" + StringUtil.Upper( AV106Postulacioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( context.GetMessage( "habilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV106Postulacioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A424PostulacionesEstado, "HAB") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "deshabilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV106Postulacioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A424PostulacionesEstado, "DES") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "ganador", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV106Postulacioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) &&
            ( StringUtil.StrCmp(A424PostulacionesEstado, "GAN") == 0 ) ) || ( StringUtil.Like( StringUtil.Str( (decimal)(A948PostulacionesSecUserId), 18, 0) , StringUtil.PadR( "%" + AV106Postulacioneswwds_1_filterfulltext , 254 , "%"),  ' ' ) ) )
            )
            {
               AV58count = 0;
               while ( (pr_default.getStatus(8) != 101) && ( StringUtil.StrCmp(P00LA19_A951PostulacionesMail[0], A951PostulacionesMail) == 0 ) )
               {
                  BRKLA18 = false;
                  A422PostulacionesId = P00LA19_A422PostulacionesId[0];
                  n422PostulacionesId = P00LA19_n422PostulacionesId[0];
                  AV58count = (long)(AV58count+1);
                  BRKLA18 = true;
                  pr_default.readNext(8);
               }
               if ( (0==AV49SkipItems) )
               {
                  AV53Option = (String.IsNullOrEmpty(StringUtil.RTrim( A951PostulacionesMail)) ? "<#Empty#>" : A951PostulacionesMail);
                  AV54Options.Add(AV53Option, 0);
                  AV57OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV58count), "Z,ZZZ,ZZZ,ZZ9")), 0);
                  if ( AV54Options.Count == 10 )
                  {
                     /* Exit For each command. Update data (if necessary), close cursors & exit. */
                     if (true) break;
                  }
               }
               else
               {
                  AV49SkipItems = (short)(AV49SkipItems-1);
               }
            }
            if ( ! BRKLA18 )
            {
               BRKLA18 = true;
               pr_default.readNext(8);
            }
         }
         pr_default.close(8);
      }

      protected void S211( )
      {
         /* 'LOADPOSTULACIONESTELEFONOOPTIONS' Routine */
         returnInSub = false;
         AV40TFPostulacionesTelefono = AV48SearchTxt;
         AV41TFPostulacionesTelefono_Sel = "";
         AV106Postulacioneswwds_1_filterfulltext = AV70FilterFullText;
         AV107Postulacioneswwds_2_dynamicfiltersselector1 = AV71DynamicFiltersSelector1;
         AV108Postulacioneswwds_3_dynamicfiltersoperator1 = AV72DynamicFiltersOperator1;
         AV109Postulacioneswwds_4_postulacionesproveedornombre1 = AV91PostulacionesProveedorNombre1;
         AV110Postulacioneswwds_5_postulacionesproveedorid1 = AV73PostulacionesProveedorId1;
         AV111Postulacioneswwds_6_serviciosnombre1 = AV74ServiciosNombre1;
         AV112Postulacioneswwds_7_dynamicfiltersenabled2 = AV75DynamicFiltersEnabled2;
         AV113Postulacioneswwds_8_dynamicfiltersselector2 = AV76DynamicFiltersSelector2;
         AV114Postulacioneswwds_9_dynamicfiltersoperator2 = AV77DynamicFiltersOperator2;
         AV115Postulacioneswwds_10_postulacionesproveedornombre2 = AV92PostulacionesProveedorNombre2;
         AV116Postulacioneswwds_11_postulacionesproveedorid2 = AV78PostulacionesProveedorId2;
         AV117Postulacioneswwds_12_serviciosnombre2 = AV79ServiciosNombre2;
         AV118Postulacioneswwds_13_dynamicfiltersenabled3 = AV80DynamicFiltersEnabled3;
         AV119Postulacioneswwds_14_dynamicfiltersselector3 = AV81DynamicFiltersSelector3;
         AV120Postulacioneswwds_15_dynamicfiltersoperator3 = AV82DynamicFiltersOperator3;
         AV121Postulacioneswwds_16_postulacionesproveedornombre3 = AV93PostulacionesProveedorNombre3;
         AV122Postulacioneswwds_17_postulacionesproveedorid3 = AV83PostulacionesProveedorId3;
         AV123Postulacioneswwds_18_serviciosnombre3 = AV84ServiciosNombre3;
         AV124Postulacioneswwds_19_tfpostulacionesid = AV11TFPostulacionesId;
         AV125Postulacioneswwds_20_tfpostulacionesid_to = AV12TFPostulacionesId_To;
         AV126Postulacioneswwds_21_tfserviciosid = AV13TFServiciosId;
         AV127Postulacioneswwds_22_tfserviciosid_to = AV14TFServiciosId_To;
         AV128Postulacioneswwds_23_tfserviciosnombre = AV15TFServiciosNombre;
         AV129Postulacioneswwds_24_tfserviciosnombre_sel = AV16TFServiciosNombre_Sel;
         AV130Postulacioneswwds_25_tfpostulacionesproveedorid = AV17TFPostulacionesProveedorId;
         AV131Postulacioneswwds_26_tfpostulacionesproveedorid_to = AV18TFPostulacionesProveedorId_To;
         AV132Postulacioneswwds_27_tfpostulacionesproveedornombre = AV85TFPostulacionesProveedorNombre;
         AV133Postulacioneswwds_28_tfpostulacionesproveedornombre_sel = AV86TFPostulacionesProveedorNombre_Sel;
         AV134Postulacioneswwds_29_tfpostulacionesprecio = AV19TFPostulacionesPrecio;
         AV135Postulacioneswwds_30_tfpostulacionesprecio_to = AV20TFPostulacionesPrecio_To;
         AV136Postulacioneswwds_31_tfpostulacionesmultimediaserial = AV87TFPostulacionesMultimediaSerial;
         AV137Postulacioneswwds_32_tfpostulacionesmultimediaserial_to = AV88TFPostulacionesMultimediaSerial_To;
         AV138Postulacioneswwds_33_tfpostulacionessolicitudesid = AV89TFPostulacionesSolicitudesId;
         AV139Postulacioneswwds_34_tfpostulacionessolicitudesid_to = AV90TFPostulacionesSolicitudesId_To;
         AV140Postulacioneswwds_35_tfpostulacionesdescripcion = AV21TFPostulacionesDescripcion;
         AV141Postulacioneswwds_36_tfpostulacionesdescripcion_sel = AV22TFPostulacionesDescripcion_Sel;
         AV142Postulacioneswwds_37_tfpostulacionesreqsuministros_sel = AV23TFPostulacionesReqSuministros_Sel;
         AV143Postulacioneswwds_38_tfpostulacionessuministrosdescripcion = AV24TFPostulacionesSuministrosDescripcion;
         AV144Postulacioneswwds_39_tfpostulacionessuministrosdescripcion_sel = AV25TFPostulacionesSuministrosDescripcion_Sel;
         AV145Postulacioneswwds_40_tfpostulacionesfechatrabajo = AV26TFPostulacionesFechaTrabajo;
         AV146Postulacioneswwds_41_tfpostulacionesfechatrabajo_to = AV27TFPostulacionesFechaTrabajo_To;
         AV147Postulacioneswwds_42_tfpostulacionesfechacierre = AV28TFPostulacionesFechaCierre;
         AV148Postulacioneswwds_43_tfpostulacionesfechacierre_to = AV29TFPostulacionesFechaCierre_To;
         AV149Postulacioneswwds_44_tfpostulacioneshoracierre = AV30TFPostulacionesHoraCierre;
         AV150Postulacioneswwds_45_tfpostulacioneshoracierre_sel = AV31TFPostulacionesHoraCierre_Sel;
         AV151Postulacioneswwds_46_tfpostulacionestipofecha = AV32TFPostulacionesTipoFecha;
         AV152Postulacioneswwds_47_tfpostulacionestipofecha_sel = AV103TFPostulacionesTipoFecha_Sel;
         AV153Postulacioneswwds_48_tfpostulacionesrgohoraservicio = AV34TFPostulacionesRgoHoraservicio;
         AV154Postulacioneswwds_49_tfpostulacionesrgohoraservicio_sel = AV35TFPostulacionesRgoHoraservicio_Sel;
         AV155Postulacioneswwds_50_tfpostulacionesapellidonombre = AV36TFPostulacionesApellidoNombre;
         AV156Postulacioneswwds_51_tfpostulacionesapellidonombre_sel = AV37TFPostulacionesApellidoNombre_Sel;
         AV157Postulacioneswwds_52_tfpostulacionesmail = AV38TFPostulacionesMail;
         AV158Postulacioneswwds_53_tfpostulacionesmail_sel = AV39TFPostulacionesMail_Sel;
         AV159Postulacioneswwds_54_tfpostulacionestelefono = AV40TFPostulacionesTelefono;
         AV160Postulacioneswwds_55_tfpostulacionestelefono_sel = AV41TFPostulacionesTelefono_Sel;
         AV161Postulacioneswwds_56_tfpostulacionesfechaalta = AV42TFPostulacionesFechaAlta;
         AV162Postulacioneswwds_57_tfpostulacionesfechaalta_to = AV43TFPostulacionesFechaAlta_To;
         AV163Postulacioneswwds_58_tfpostulacionesestado_sels = AV45TFPostulacionesEstado_Sels;
         AV164Postulacioneswwds_59_tfpostulacionessecuserid = AV46TFPostulacionesSecUserId;
         AV165Postulacioneswwds_60_tfpostulacionessecuserid_to = AV47TFPostulacionesSecUserId_To;
         pr_default.dynParam(9, new Object[]{ new Object[]{
                                              A424PostulacionesEstado ,
                                              AV163Postulacioneswwds_58_tfpostulacionesestado_sels ,
                                              AV107Postulacioneswwds_2_dynamicfiltersselector1 ,
                                              AV108Postulacioneswwds_3_dynamicfiltersoperator1 ,
                                              AV109Postulacioneswwds_4_postulacionesproveedornombre1 ,
                                              AV110Postulacioneswwds_5_postulacionesproveedorid1 ,
                                              AV111Postulacioneswwds_6_serviciosnombre1 ,
                                              AV112Postulacioneswwds_7_dynamicfiltersenabled2 ,
                                              AV113Postulacioneswwds_8_dynamicfiltersselector2 ,
                                              AV114Postulacioneswwds_9_dynamicfiltersoperator2 ,
                                              AV115Postulacioneswwds_10_postulacionesproveedornombre2 ,
                                              AV116Postulacioneswwds_11_postulacionesproveedorid2 ,
                                              AV117Postulacioneswwds_12_serviciosnombre2 ,
                                              AV118Postulacioneswwds_13_dynamicfiltersenabled3 ,
                                              AV119Postulacioneswwds_14_dynamicfiltersselector3 ,
                                              AV120Postulacioneswwds_15_dynamicfiltersoperator3 ,
                                              AV121Postulacioneswwds_16_postulacionesproveedornombre3 ,
                                              AV122Postulacioneswwds_17_postulacionesproveedorid3 ,
                                              AV123Postulacioneswwds_18_serviciosnombre3 ,
                                              AV124Postulacioneswwds_19_tfpostulacionesid ,
                                              AV125Postulacioneswwds_20_tfpostulacionesid_to ,
                                              AV126Postulacioneswwds_21_tfserviciosid ,
                                              AV127Postulacioneswwds_22_tfserviciosid_to ,
                                              AV129Postulacioneswwds_24_tfserviciosnombre_sel ,
                                              AV128Postulacioneswwds_23_tfserviciosnombre ,
                                              AV130Postulacioneswwds_25_tfpostulacionesproveedorid ,
                                              AV131Postulacioneswwds_26_tfpostulacionesproveedorid_to ,
                                              AV133Postulacioneswwds_28_tfpostulacionesproveedornombre_sel ,
                                              AV132Postulacioneswwds_27_tfpostulacionesproveedornombre ,
                                              AV134Postulacioneswwds_29_tfpostulacionesprecio ,
                                              AV135Postulacioneswwds_30_tfpostulacionesprecio_to ,
                                              AV136Postulacioneswwds_31_tfpostulacionesmultimediaserial ,
                                              AV137Postulacioneswwds_32_tfpostulacionesmultimediaserial_to ,
                                              AV141Postulacioneswwds_36_tfpostulacionesdescripcion_sel ,
                                              AV140Postulacioneswwds_35_tfpostulacionesdescripcion ,
                                              AV142Postulacioneswwds_37_tfpostulacionesreqsuministros_sel ,
                                              AV144Postulacioneswwds_39_tfpostulacionessuministrosdescripcion_sel ,
                                              AV143Postulacioneswwds_38_tfpostulacionessuministrosdescripcion ,
                                              AV145Postulacioneswwds_40_tfpostulacionesfechatrabajo ,
                                              AV146Postulacioneswwds_41_tfpostulacionesfechatrabajo_to ,
                                              AV147Postulacioneswwds_42_tfpostulacionesfechacierre ,
                                              AV148Postulacioneswwds_43_tfpostulacionesfechacierre_to ,
                                              AV150Postulacioneswwds_45_tfpostulacioneshoracierre_sel ,
                                              AV149Postulacioneswwds_44_tfpostulacioneshoracierre ,
                                              AV152Postulacioneswwds_47_tfpostulacionestipofecha_sel ,
                                              AV151Postulacioneswwds_46_tfpostulacionestipofecha ,
                                              AV154Postulacioneswwds_49_tfpostulacionesrgohoraservicio_sel ,
                                              AV153Postulacioneswwds_48_tfpostulacionesrgohoraservicio ,
                                              AV156Postulacioneswwds_51_tfpostulacionesapellidonombre_sel ,
                                              AV155Postulacioneswwds_50_tfpostulacionesapellidonombre ,
                                              AV158Postulacioneswwds_53_tfpostulacionesmail_sel ,
                                              AV157Postulacioneswwds_52_tfpostulacionesmail ,
                                              AV160Postulacioneswwds_55_tfpostulacionestelefono_sel ,
                                              AV159Postulacioneswwds_54_tfpostulacionestelefono ,
                                              AV161Postulacioneswwds_56_tfpostulacionesfechaalta ,
                                              AV162Postulacioneswwds_57_tfpostulacionesfechaalta_to ,
                                              AV163Postulacioneswwds_58_tfpostulacionesestado_sels.Count ,
                                              AV164Postulacioneswwds_59_tfpostulacionessecuserid ,
                                              AV165Postulacioneswwds_60_tfpostulacionessecuserid_to ,
                                              A969PostulacionesProveedorNombre ,
                                              A945PostulacionesProveedorId ,
                                              A943ServiciosNombre ,
                                              A422PostulacionesId ,
                                              A942ServiciosId ,
                                              A946PostulacionesPrecio ,
                                              A961PostulacionesMultimediaSerial ,
                                              A936PostulacionesDescripcion ,
                                              A937PostulacionesReqSuministros ,
                                              A938PostulacionesSuministrosDescri ,
                                              A947PostulacionesFechaTrabajo ,
                                              A939PostulacionesFechaCierre ,
                                              A940PostulacionesHoraCierre ,
                                              A941PostulacionesTipoFecha ,
                                              A949PostulacionesRgoHoraservicio ,
                                              A950PostulacionesApellidoNombre ,
                                              A951PostulacionesMail ,
                                              A952PostulacionesTelefono ,
                                              A425PostulacionesFechaAlta ,
                                              A948PostulacionesSecUserId ,
                                              AV106Postulacioneswwds_1_filterfulltext ,
                                              A970PostulacionesSolicitudesId ,
                                              AV138Postulacioneswwds_33_tfpostulacionessolicitudesid ,
                                              AV139Postulacioneswwds_34_tfpostulacionessolicitudesid_to } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG,
                                              TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.DATE,
                                              TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.INT, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG,
                                              TypeConstants.BOOLEAN, TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.LONG,
                                              TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.LONG, TypeConstants.LONG
                                              }
         });
         lV109Postulacioneswwds_4_postulacionesproveedornombre1 = StringUtil.PadR( StringUtil.RTrim( AV109Postulacioneswwds_4_postulacionesproveedornombre1), 80, "%");
         lV109Postulacioneswwds_4_postulacionesproveedornombre1 = StringUtil.PadR( StringUtil.RTrim( AV109Postulacioneswwds_4_postulacionesproveedornombre1), 80, "%");
         lV111Postulacioneswwds_6_serviciosnombre1 = StringUtil.PadR( StringUtil.RTrim( AV111Postulacioneswwds_6_serviciosnombre1), 80, "%");
         lV111Postulacioneswwds_6_serviciosnombre1 = StringUtil.PadR( StringUtil.RTrim( AV111Postulacioneswwds_6_serviciosnombre1), 80, "%");
         lV115Postulacioneswwds_10_postulacionesproveedornombre2 = StringUtil.PadR( StringUtil.RTrim( AV115Postulacioneswwds_10_postulacionesproveedornombre2), 80, "%");
         lV115Postulacioneswwds_10_postulacionesproveedornombre2 = StringUtil.PadR( StringUtil.RTrim( AV115Postulacioneswwds_10_postulacionesproveedornombre2), 80, "%");
         lV117Postulacioneswwds_12_serviciosnombre2 = StringUtil.PadR( StringUtil.RTrim( AV117Postulacioneswwds_12_serviciosnombre2), 80, "%");
         lV117Postulacioneswwds_12_serviciosnombre2 = StringUtil.PadR( StringUtil.RTrim( AV117Postulacioneswwds_12_serviciosnombre2), 80, "%");
         lV121Postulacioneswwds_16_postulacionesproveedornombre3 = StringUtil.PadR( StringUtil.RTrim( AV121Postulacioneswwds_16_postulacionesproveedornombre3), 80, "%");
         lV121Postulacioneswwds_16_postulacionesproveedornombre3 = StringUtil.PadR( StringUtil.RTrim( AV121Postulacioneswwds_16_postulacionesproveedornombre3), 80, "%");
         lV123Postulacioneswwds_18_serviciosnombre3 = StringUtil.PadR( StringUtil.RTrim( AV123Postulacioneswwds_18_serviciosnombre3), 80, "%");
         lV123Postulacioneswwds_18_serviciosnombre3 = StringUtil.PadR( StringUtil.RTrim( AV123Postulacioneswwds_18_serviciosnombre3), 80, "%");
         lV128Postulacioneswwds_23_tfserviciosnombre = StringUtil.PadR( StringUtil.RTrim( AV128Postulacioneswwds_23_tfserviciosnombre), 80, "%");
         lV132Postulacioneswwds_27_tfpostulacionesproveedornombre = StringUtil.PadR( StringUtil.RTrim( AV132Postulacioneswwds_27_tfpostulacionesproveedornombre), 80, "%");
         lV140Postulacioneswwds_35_tfpostulacionesdescripcion = StringUtil.PadR( StringUtil.RTrim( AV140Postulacioneswwds_35_tfpostulacionesdescripcion), 2000, "%");
         lV143Postulacioneswwds_38_tfpostulacionessuministrosdescripcion = StringUtil.PadR( StringUtil.RTrim( AV143Postulacioneswwds_38_tfpostulacionessuministrosdescripcion), 250, "%");
         lV149Postulacioneswwds_44_tfpostulacioneshoracierre = StringUtil.Concat( StringUtil.RTrim( AV149Postulacioneswwds_44_tfpostulacioneshoracierre), "%", "");
         lV151Postulacioneswwds_46_tfpostulacionestipofecha = StringUtil.Concat( StringUtil.RTrim( AV151Postulacioneswwds_46_tfpostulacionestipofecha), "%", "");
         lV153Postulacioneswwds_48_tfpostulacionesrgohoraservicio = StringUtil.PadR( StringUtil.RTrim( AV153Postulacioneswwds_48_tfpostulacionesrgohoraservicio), 5, "%");
         lV155Postulacioneswwds_50_tfpostulacionesapellidonombre = StringUtil.PadR( StringUtil.RTrim( AV155Postulacioneswwds_50_tfpostulacionesapellidonombre), 80, "%");
         lV157Postulacioneswwds_52_tfpostulacionesmail = StringUtil.Concat( StringUtil.RTrim( AV157Postulacioneswwds_52_tfpostulacionesmail), "%", "");
         lV159Postulacioneswwds_54_tfpostulacionestelefono = StringUtil.PadR( StringUtil.RTrim( AV159Postulacioneswwds_54_tfpostulacionestelefono), 20, "%");
         /* Using cursor P00LA21 */
         pr_default.execute(9, new Object[] {n422PostulacionesId, A422PostulacionesId, AV138Postulacioneswwds_33_tfpostulacionessolicitudesid, AV138Postulacioneswwds_33_tfpostulacionessolicitudesid, AV139Postulacioneswwds_34_tfpostulacionessolicitudesid_to, AV139Postulacioneswwds_34_tfpostulacionessolicitudesid_to, lV109Postulacioneswwds_4_postulacionesproveedornombre1, lV109Postulacioneswwds_4_postulacionesproveedornombre1, AV110Postulacioneswwds_5_postulacionesproveedorid1, AV110Postulacioneswwds_5_postulacionesproveedorid1, AV110Postulacioneswwds_5_postulacionesproveedorid1, lV111Postulacioneswwds_6_serviciosnombre1, lV111Postulacioneswwds_6_serviciosnombre1, lV115Postulacioneswwds_10_postulacionesproveedornombre2, lV115Postulacioneswwds_10_postulacionesproveedornombre2, AV116Postulacioneswwds_11_postulacionesproveedorid2, AV116Postulacioneswwds_11_postulacionesproveedorid2, AV116Postulacioneswwds_11_postulacionesproveedorid2, lV117Postulacioneswwds_12_serviciosnombre2, lV117Postulacioneswwds_12_serviciosnombre2, lV121Postulacioneswwds_16_postulacionesproveedornombre3, lV121Postulacioneswwds_16_postulacionesproveedornombre3, AV122Postulacioneswwds_17_postulacionesproveedorid3, AV122Postulacioneswwds_17_postulacionesproveedorid3, AV122Postulacioneswwds_17_postulacionesproveedorid3, lV123Postulacioneswwds_18_serviciosnombre3, lV123Postulacioneswwds_18_serviciosnombre3, AV124Postulacioneswwds_19_tfpostulacionesid, AV125Postulacioneswwds_20_tfpostulacionesid_to, AV126Postulacioneswwds_21_tfserviciosid, AV127Postulacioneswwds_22_tfserviciosid_to, lV128Postulacioneswwds_23_tfserviciosnombre, AV129Postulacioneswwds_24_tfserviciosnombre_sel, AV130Postulacioneswwds_25_tfpostulacionesproveedorid, AV131Postulacioneswwds_26_tfpostulacionesproveedorid_to, lV132Postulacioneswwds_27_tfpostulacionesproveedornombre, AV133Postulacioneswwds_28_tfpostulacionesproveedornombre_sel, AV134Postulacioneswwds_29_tfpostulacionesprecio, AV135Postulacioneswwds_30_tfpostulacionesprecio_to, AV136Postulacioneswwds_31_tfpostulacionesmultimediaserial, AV137Postulacioneswwds_32_tfpostulacionesmultimediaserial_to, lV140Postulacioneswwds_35_tfpostulacionesdescripcion, AV141Postulacioneswwds_36_tfpostulacionesdescripcion_sel, lV143Postulacioneswwds_38_tfpostulacionessuministrosdescripcion, AV144Postulacioneswwds_39_tfpostulacionessuministrosdescripcion_sel, AV145Postulacioneswwds_40_tfpostulacionesfechatrabajo, AV146Postulacioneswwds_41_tfpostulacionesfechatrabajo_to, AV147Postulacioneswwds_42_tfpostulacionesfechacierre, AV148Postulacioneswwds_43_tfpostulacionesfechacierre_to, lV149Postulacioneswwds_44_tfpostulacioneshoracierre, AV150Postulacioneswwds_45_tfpostulacioneshoracierre_sel, lV151Postulacioneswwds_46_tfpostulacionestipofecha, AV152Postulacioneswwds_47_tfpostulacionestipofecha_sel, lV153Postulacioneswwds_48_tfpostulacionesrgohoraservicio, AV154Postulacioneswwds_49_tfpostulacionesrgohoraservicio_sel, lV155Postulacioneswwds_50_tfpostulacionesapellidonombre, AV156Postulacioneswwds_51_tfpostulacionesapellidonombre_sel, lV157Postulacioneswwds_52_tfpostulacionesmail, AV158Postulacioneswwds_53_tfpostulacionesmail_sel, lV159Postulacioneswwds_54_tfpostulacionestelefono, AV160Postulacioneswwds_55_tfpostulacionestelefono_sel, AV161Postulacioneswwds_56_tfpostulacionesfechaalta, AV162Postulacioneswwds_57_tfpostulacionesfechaalta_to, AV164Postulacioneswwds_59_tfpostulacionessecuserid, AV165Postulacioneswwds_60_tfpostulacionessecuserid_to});
         while ( (pr_default.getStatus(9) != 101) )
         {
            BRKLA20 = false;
            A952PostulacionesTelefono = P00LA21_A952PostulacionesTelefono[0];
            A948PostulacionesSecUserId = P00LA21_A948PostulacionesSecUserId[0];
            A425PostulacionesFechaAlta = P00LA21_A425PostulacionesFechaAlta[0];
            A951PostulacionesMail = P00LA21_A951PostulacionesMail[0];
            A950PostulacionesApellidoNombre = P00LA21_A950PostulacionesApellidoNombre[0];
            A949PostulacionesRgoHoraservicio = P00LA21_A949PostulacionesRgoHoraservicio[0];
            A941PostulacionesTipoFecha = P00LA21_A941PostulacionesTipoFecha[0];
            A940PostulacionesHoraCierre = P00LA21_A940PostulacionesHoraCierre[0];
            A939PostulacionesFechaCierre = P00LA21_A939PostulacionesFechaCierre[0];
            A947PostulacionesFechaTrabajo = P00LA21_A947PostulacionesFechaTrabajo[0];
            A938PostulacionesSuministrosDescri = P00LA21_A938PostulacionesSuministrosDescri[0];
            A937PostulacionesReqSuministros = P00LA21_A937PostulacionesReqSuministros[0];
            A936PostulacionesDescripcion = P00LA21_A936PostulacionesDescripcion[0];
            A961PostulacionesMultimediaSerial = P00LA21_A961PostulacionesMultimediaSerial[0];
            A946PostulacionesPrecio = P00LA21_A946PostulacionesPrecio[0];
            A969PostulacionesProveedorNombre = P00LA21_A969PostulacionesProveedorNombre[0];
            A943ServiciosNombre = P00LA21_A943ServiciosNombre[0];
            A942ServiciosId = P00LA21_A942ServiciosId[0];
            n942ServiciosId = P00LA21_n942ServiciosId[0];
            A422PostulacionesId = P00LA21_A422PostulacionesId[0];
            n422PostulacionesId = P00LA21_n422PostulacionesId[0];
            A945PostulacionesProveedorId = P00LA21_A945PostulacionesProveedorId[0];
            A424PostulacionesEstado = P00LA21_A424PostulacionesEstado[0];
            A970PostulacionesSolicitudesId = P00LA21_A970PostulacionesSolicitudesId[0];
            n970PostulacionesSolicitudesId = P00LA21_n970PostulacionesSolicitudesId[0];
            A943ServiciosNombre = P00LA21_A943ServiciosNombre[0];
            A969PostulacionesProveedorNombre = P00LA21_A969PostulacionesProveedorNombre[0];
            A970PostulacionesSolicitudesId = P00LA21_A970PostulacionesSolicitudesId[0];
            n970PostulacionesSolicitudesId = P00LA21_n970PostulacionesSolicitudesId[0];
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV106Postulacioneswwds_1_filterfulltext)) || ( ( StringUtil.Like( StringUtil.Str( (decimal)(A422PostulacionesId), 18, 0) , StringUtil.PadR( "%" + AV106Postulacioneswwds_1_filterfulltext , 254 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Str( (decimal)(A942ServiciosId), 18, 0) , StringUtil.PadR( "%" + AV106Postulacioneswwds_1_filterfulltext , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A943ServiciosNombre) , StringUtil.PadR( "%" + StringUtil.Upper( AV106Postulacioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Str( (decimal)(A945PostulacionesProveedorId), 18, 0) , StringUtil.PadR( "%" + AV106Postulacioneswwds_1_filterfulltext , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A969PostulacionesProveedorNombre) , StringUtil.PadR( "%" + StringUtil.Upper( AV106Postulacioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Str( A946PostulacionesPrecio, 18, 2) , StringUtil.PadR( "%" + AV106Postulacioneswwds_1_filterfulltext , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Str( (decimal)(A961PostulacionesMultimediaSerial), 4, 0) , StringUtil.PadR( "%" + AV106Postulacioneswwds_1_filterfulltext , 254 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Str( (decimal)(A970PostulacionesSolicitudesId), 18, 0) , StringUtil.PadR( "%" + AV106Postulacioneswwds_1_filterfulltext , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A936PostulacionesDescripcion) , StringUtil.PadR( "%" + StringUtil.Upper( AV106Postulacioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Upper( A938PostulacionesSuministrosDescri) , StringUtil.PadR( "%" + StringUtil.Upper( AV106Postulacioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A940PostulacionesHoraCierre) , StringUtil.PadR( "%" + StringUtil.Upper( AV106Postulacioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Upper( A941PostulacionesTipoFecha) , StringUtil.PadR( "%" + StringUtil.Upper( AV106Postulacioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A949PostulacionesRgoHoraservicio) , StringUtil.PadR( "%" + StringUtil.Upper( AV106Postulacioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Upper( A950PostulacionesApellidoNombre) , StringUtil.PadR( "%" + StringUtil.Upper( AV106Postulacioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A951PostulacionesMail) , StringUtil.PadR( "%" + StringUtil.Upper( AV106Postulacioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Upper( A952PostulacionesTelefono) , StringUtil.PadR( "%" + StringUtil.Upper( AV106Postulacioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( context.GetMessage( "habilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV106Postulacioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A424PostulacionesEstado, "HAB") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "deshabilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV106Postulacioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A424PostulacionesEstado, "DES") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "ganador", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV106Postulacioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) &&
            ( StringUtil.StrCmp(A424PostulacionesEstado, "GAN") == 0 ) ) || ( StringUtil.Like( StringUtil.Str( (decimal)(A948PostulacionesSecUserId), 18, 0) , StringUtil.PadR( "%" + AV106Postulacioneswwds_1_filterfulltext , 254 , "%"),  ' ' ) ) )
            )
            {
               AV58count = 0;
               while ( (pr_default.getStatus(9) != 101) && ( StringUtil.StrCmp(P00LA21_A952PostulacionesTelefono[0], A952PostulacionesTelefono) == 0 ) )
               {
                  BRKLA20 = false;
                  A422PostulacionesId = P00LA21_A422PostulacionesId[0];
                  n422PostulacionesId = P00LA21_n422PostulacionesId[0];
                  AV58count = (long)(AV58count+1);
                  BRKLA20 = true;
                  pr_default.readNext(9);
               }
               if ( (0==AV49SkipItems) )
               {
                  AV53Option = (String.IsNullOrEmpty(StringUtil.RTrim( A952PostulacionesTelefono)) ? "<#Empty#>" : A952PostulacionesTelefono);
                  AV54Options.Add(AV53Option, 0);
                  AV57OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV58count), "Z,ZZZ,ZZZ,ZZ9")), 0);
                  if ( AV54Options.Count == 10 )
                  {
                     /* Exit For each command. Update data (if necessary), close cursors & exit. */
                     if (true) break;
                  }
               }
               else
               {
                  AV49SkipItems = (short)(AV49SkipItems-1);
               }
            }
            if ( ! BRKLA20 )
            {
               BRKLA20 = true;
               pr_default.readNext(9);
            }
         }
         pr_default.close(9);
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
         AV67OptionsJson = "";
         AV68OptionsDescJson = "";
         AV69OptionIndexesJson = "";
         AV54Options = new GxSimpleCollection<string>();
         AV56OptionsDesc = new GxSimpleCollection<string>();
         AV57OptionIndexes = new GxSimpleCollection<string>();
         AV48SearchTxt = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV59Session = context.GetSession();
         AV61GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV62GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV70FilterFullText = "";
         AV15TFServiciosNombre = "";
         AV16TFServiciosNombre_Sel = "";
         AV85TFPostulacionesProveedorNombre = "";
         AV86TFPostulacionesProveedorNombre_Sel = "";
         AV21TFPostulacionesDescripcion = "";
         AV22TFPostulacionesDescripcion_Sel = "";
         AV24TFPostulacionesSuministrosDescripcion = "";
         AV25TFPostulacionesSuministrosDescripcion_Sel = "";
         AV26TFPostulacionesFechaTrabajo = DateTime.MinValue;
         AV27TFPostulacionesFechaTrabajo_To = DateTime.MinValue;
         AV28TFPostulacionesFechaCierre = DateTime.MinValue;
         AV29TFPostulacionesFechaCierre_To = DateTime.MinValue;
         AV30TFPostulacionesHoraCierre = "";
         AV31TFPostulacionesHoraCierre_Sel = "";
         AV32TFPostulacionesTipoFecha = "";
         AV103TFPostulacionesTipoFecha_Sel = "";
         AV34TFPostulacionesRgoHoraservicio = "";
         AV35TFPostulacionesRgoHoraservicio_Sel = "";
         AV36TFPostulacionesApellidoNombre = "";
         AV37TFPostulacionesApellidoNombre_Sel = "";
         AV38TFPostulacionesMail = "";
         AV39TFPostulacionesMail_Sel = "";
         AV40TFPostulacionesTelefono = "";
         AV41TFPostulacionesTelefono_Sel = "";
         AV42TFPostulacionesFechaAlta = (DateTime)(DateTime.MinValue);
         AV43TFPostulacionesFechaAlta_To = (DateTime)(DateTime.MinValue);
         AV44TFPostulacionesEstado_SelsJson = "";
         AV45TFPostulacionesEstado_Sels = new GxSimpleCollection<string>();
         AV63GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV71DynamicFiltersSelector1 = "";
         AV91PostulacionesProveedorNombre1 = "";
         AV74ServiciosNombre1 = "";
         AV76DynamicFiltersSelector2 = "";
         AV92PostulacionesProveedorNombre2 = "";
         AV79ServiciosNombre2 = "";
         AV81DynamicFiltersSelector3 = "";
         AV93PostulacionesProveedorNombre3 = "";
         AV84ServiciosNombre3 = "";
         AV106Postulacioneswwds_1_filterfulltext = "";
         AV107Postulacioneswwds_2_dynamicfiltersselector1 = "";
         AV109Postulacioneswwds_4_postulacionesproveedornombre1 = "";
         AV111Postulacioneswwds_6_serviciosnombre1 = "";
         AV113Postulacioneswwds_8_dynamicfiltersselector2 = "";
         AV115Postulacioneswwds_10_postulacionesproveedornombre2 = "";
         AV117Postulacioneswwds_12_serviciosnombre2 = "";
         AV119Postulacioneswwds_14_dynamicfiltersselector3 = "";
         AV121Postulacioneswwds_16_postulacionesproveedornombre3 = "";
         AV123Postulacioneswwds_18_serviciosnombre3 = "";
         AV128Postulacioneswwds_23_tfserviciosnombre = "";
         AV129Postulacioneswwds_24_tfserviciosnombre_sel = "";
         AV132Postulacioneswwds_27_tfpostulacionesproveedornombre = "";
         AV133Postulacioneswwds_28_tfpostulacionesproveedornombre_sel = "";
         AV140Postulacioneswwds_35_tfpostulacionesdescripcion = "";
         AV141Postulacioneswwds_36_tfpostulacionesdescripcion_sel = "";
         AV143Postulacioneswwds_38_tfpostulacionessuministrosdescripcion = "";
         AV144Postulacioneswwds_39_tfpostulacionessuministrosdescripcion_sel = "";
         AV145Postulacioneswwds_40_tfpostulacionesfechatrabajo = DateTime.MinValue;
         AV146Postulacioneswwds_41_tfpostulacionesfechatrabajo_to = DateTime.MinValue;
         AV147Postulacioneswwds_42_tfpostulacionesfechacierre = DateTime.MinValue;
         AV148Postulacioneswwds_43_tfpostulacionesfechacierre_to = DateTime.MinValue;
         AV149Postulacioneswwds_44_tfpostulacioneshoracierre = "";
         AV150Postulacioneswwds_45_tfpostulacioneshoracierre_sel = "";
         AV151Postulacioneswwds_46_tfpostulacionestipofecha = "";
         AV152Postulacioneswwds_47_tfpostulacionestipofecha_sel = "";
         AV153Postulacioneswwds_48_tfpostulacionesrgohoraservicio = "";
         AV154Postulacioneswwds_49_tfpostulacionesrgohoraservicio_sel = "";
         AV155Postulacioneswwds_50_tfpostulacionesapellidonombre = "";
         AV156Postulacioneswwds_51_tfpostulacionesapellidonombre_sel = "";
         AV157Postulacioneswwds_52_tfpostulacionesmail = "";
         AV158Postulacioneswwds_53_tfpostulacionesmail_sel = "";
         AV159Postulacioneswwds_54_tfpostulacionestelefono = "";
         AV160Postulacioneswwds_55_tfpostulacionestelefono_sel = "";
         AV161Postulacioneswwds_56_tfpostulacionesfechaalta = (DateTime)(DateTime.MinValue);
         AV162Postulacioneswwds_57_tfpostulacionesfechaalta_to = (DateTime)(DateTime.MinValue);
         AV163Postulacioneswwds_58_tfpostulacionesestado_sels = new GxSimpleCollection<string>();
         lV106Postulacioneswwds_1_filterfulltext = "";
         lV109Postulacioneswwds_4_postulacionesproveedornombre1 = "";
         lV111Postulacioneswwds_6_serviciosnombre1 = "";
         lV115Postulacioneswwds_10_postulacionesproveedornombre2 = "";
         lV117Postulacioneswwds_12_serviciosnombre2 = "";
         lV121Postulacioneswwds_16_postulacionesproveedornombre3 = "";
         lV123Postulacioneswwds_18_serviciosnombre3 = "";
         lV128Postulacioneswwds_23_tfserviciosnombre = "";
         lV132Postulacioneswwds_27_tfpostulacionesproveedornombre = "";
         lV140Postulacioneswwds_35_tfpostulacionesdescripcion = "";
         lV143Postulacioneswwds_38_tfpostulacionessuministrosdescripcion = "";
         lV149Postulacioneswwds_44_tfpostulacioneshoracierre = "";
         lV151Postulacioneswwds_46_tfpostulacionestipofecha = "";
         lV153Postulacioneswwds_48_tfpostulacionesrgohoraservicio = "";
         lV155Postulacioneswwds_50_tfpostulacionesapellidonombre = "";
         lV157Postulacioneswwds_52_tfpostulacionesmail = "";
         lV159Postulacioneswwds_54_tfpostulacionestelefono = "";
         A424PostulacionesEstado = "";
         A969PostulacionesProveedorNombre = "";
         A943ServiciosNombre = "";
         A936PostulacionesDescripcion = "";
         A938PostulacionesSuministrosDescri = "";
         A947PostulacionesFechaTrabajo = DateTime.MinValue;
         A939PostulacionesFechaCierre = DateTime.MinValue;
         A940PostulacionesHoraCierre = "";
         A941PostulacionesTipoFecha = "";
         A949PostulacionesRgoHoraservicio = "";
         A950PostulacionesApellidoNombre = "";
         A951PostulacionesMail = "";
         A952PostulacionesTelefono = "";
         A425PostulacionesFechaAlta = (DateTime)(DateTime.MinValue);
         P00LA3_A942ServiciosId = new long[1] ;
         P00LA3_n942ServiciosId = new bool[] {false} ;
         P00LA3_A948PostulacionesSecUserId = new long[1] ;
         P00LA3_A425PostulacionesFechaAlta = new DateTime[] {DateTime.MinValue} ;
         P00LA3_A952PostulacionesTelefono = new string[] {""} ;
         P00LA3_A951PostulacionesMail = new string[] {""} ;
         P00LA3_A950PostulacionesApellidoNombre = new string[] {""} ;
         P00LA3_A949PostulacionesRgoHoraservicio = new string[] {""} ;
         P00LA3_A941PostulacionesTipoFecha = new string[] {""} ;
         P00LA3_A940PostulacionesHoraCierre = new string[] {""} ;
         P00LA3_A939PostulacionesFechaCierre = new DateTime[] {DateTime.MinValue} ;
         P00LA3_A947PostulacionesFechaTrabajo = new DateTime[] {DateTime.MinValue} ;
         P00LA3_A938PostulacionesSuministrosDescri = new string[] {""} ;
         P00LA3_A937PostulacionesReqSuministros = new bool[] {false} ;
         P00LA3_A936PostulacionesDescripcion = new string[] {""} ;
         P00LA3_A961PostulacionesMultimediaSerial = new short[1] ;
         P00LA3_A946PostulacionesPrecio = new decimal[1] ;
         P00LA3_A969PostulacionesProveedorNombre = new string[] {""} ;
         P00LA3_A943ServiciosNombre = new string[] {""} ;
         P00LA3_A422PostulacionesId = new long[1] ;
         P00LA3_n422PostulacionesId = new bool[] {false} ;
         P00LA3_A945PostulacionesProveedorId = new long[1] ;
         P00LA3_A424PostulacionesEstado = new string[] {""} ;
         P00LA3_A970PostulacionesSolicitudesId = new long[1] ;
         P00LA3_n970PostulacionesSolicitudesId = new bool[] {false} ;
         AV53Option = "";
         P00LA5_A945PostulacionesProveedorId = new long[1] ;
         P00LA5_A948PostulacionesSecUserId = new long[1] ;
         P00LA5_A425PostulacionesFechaAlta = new DateTime[] {DateTime.MinValue} ;
         P00LA5_A952PostulacionesTelefono = new string[] {""} ;
         P00LA5_A951PostulacionesMail = new string[] {""} ;
         P00LA5_A950PostulacionesApellidoNombre = new string[] {""} ;
         P00LA5_A949PostulacionesRgoHoraservicio = new string[] {""} ;
         P00LA5_A941PostulacionesTipoFecha = new string[] {""} ;
         P00LA5_A940PostulacionesHoraCierre = new string[] {""} ;
         P00LA5_A939PostulacionesFechaCierre = new DateTime[] {DateTime.MinValue} ;
         P00LA5_A947PostulacionesFechaTrabajo = new DateTime[] {DateTime.MinValue} ;
         P00LA5_A938PostulacionesSuministrosDescri = new string[] {""} ;
         P00LA5_A937PostulacionesReqSuministros = new bool[] {false} ;
         P00LA5_A936PostulacionesDescripcion = new string[] {""} ;
         P00LA5_A961PostulacionesMultimediaSerial = new short[1] ;
         P00LA5_A946PostulacionesPrecio = new decimal[1] ;
         P00LA5_A969PostulacionesProveedorNombre = new string[] {""} ;
         P00LA5_A943ServiciosNombre = new string[] {""} ;
         P00LA5_A942ServiciosId = new long[1] ;
         P00LA5_n942ServiciosId = new bool[] {false} ;
         P00LA5_A422PostulacionesId = new long[1] ;
         P00LA5_n422PostulacionesId = new bool[] {false} ;
         P00LA5_A424PostulacionesEstado = new string[] {""} ;
         P00LA5_A970PostulacionesSolicitudesId = new long[1] ;
         P00LA5_n970PostulacionesSolicitudesId = new bool[] {false} ;
         P00LA7_A936PostulacionesDescripcion = new string[] {""} ;
         P00LA7_A948PostulacionesSecUserId = new long[1] ;
         P00LA7_A425PostulacionesFechaAlta = new DateTime[] {DateTime.MinValue} ;
         P00LA7_A952PostulacionesTelefono = new string[] {""} ;
         P00LA7_A951PostulacionesMail = new string[] {""} ;
         P00LA7_A950PostulacionesApellidoNombre = new string[] {""} ;
         P00LA7_A949PostulacionesRgoHoraservicio = new string[] {""} ;
         P00LA7_A941PostulacionesTipoFecha = new string[] {""} ;
         P00LA7_A940PostulacionesHoraCierre = new string[] {""} ;
         P00LA7_A939PostulacionesFechaCierre = new DateTime[] {DateTime.MinValue} ;
         P00LA7_A947PostulacionesFechaTrabajo = new DateTime[] {DateTime.MinValue} ;
         P00LA7_A938PostulacionesSuministrosDescri = new string[] {""} ;
         P00LA7_A937PostulacionesReqSuministros = new bool[] {false} ;
         P00LA7_A961PostulacionesMultimediaSerial = new short[1] ;
         P00LA7_A946PostulacionesPrecio = new decimal[1] ;
         P00LA7_A969PostulacionesProveedorNombre = new string[] {""} ;
         P00LA7_A943ServiciosNombre = new string[] {""} ;
         P00LA7_A942ServiciosId = new long[1] ;
         P00LA7_n942ServiciosId = new bool[] {false} ;
         P00LA7_A422PostulacionesId = new long[1] ;
         P00LA7_n422PostulacionesId = new bool[] {false} ;
         P00LA7_A945PostulacionesProveedorId = new long[1] ;
         P00LA7_A424PostulacionesEstado = new string[] {""} ;
         P00LA7_A970PostulacionesSolicitudesId = new long[1] ;
         P00LA7_n970PostulacionesSolicitudesId = new bool[] {false} ;
         P00LA9_A938PostulacionesSuministrosDescri = new string[] {""} ;
         P00LA9_A948PostulacionesSecUserId = new long[1] ;
         P00LA9_A425PostulacionesFechaAlta = new DateTime[] {DateTime.MinValue} ;
         P00LA9_A952PostulacionesTelefono = new string[] {""} ;
         P00LA9_A951PostulacionesMail = new string[] {""} ;
         P00LA9_A950PostulacionesApellidoNombre = new string[] {""} ;
         P00LA9_A949PostulacionesRgoHoraservicio = new string[] {""} ;
         P00LA9_A941PostulacionesTipoFecha = new string[] {""} ;
         P00LA9_A940PostulacionesHoraCierre = new string[] {""} ;
         P00LA9_A939PostulacionesFechaCierre = new DateTime[] {DateTime.MinValue} ;
         P00LA9_A947PostulacionesFechaTrabajo = new DateTime[] {DateTime.MinValue} ;
         P00LA9_A937PostulacionesReqSuministros = new bool[] {false} ;
         P00LA9_A936PostulacionesDescripcion = new string[] {""} ;
         P00LA9_A961PostulacionesMultimediaSerial = new short[1] ;
         P00LA9_A946PostulacionesPrecio = new decimal[1] ;
         P00LA9_A969PostulacionesProveedorNombre = new string[] {""} ;
         P00LA9_A943ServiciosNombre = new string[] {""} ;
         P00LA9_A942ServiciosId = new long[1] ;
         P00LA9_n942ServiciosId = new bool[] {false} ;
         P00LA9_A422PostulacionesId = new long[1] ;
         P00LA9_n422PostulacionesId = new bool[] {false} ;
         P00LA9_A945PostulacionesProveedorId = new long[1] ;
         P00LA9_A424PostulacionesEstado = new string[] {""} ;
         P00LA9_A970PostulacionesSolicitudesId = new long[1] ;
         P00LA9_n970PostulacionesSolicitudesId = new bool[] {false} ;
         P00LA11_A940PostulacionesHoraCierre = new string[] {""} ;
         P00LA11_A948PostulacionesSecUserId = new long[1] ;
         P00LA11_A425PostulacionesFechaAlta = new DateTime[] {DateTime.MinValue} ;
         P00LA11_A952PostulacionesTelefono = new string[] {""} ;
         P00LA11_A951PostulacionesMail = new string[] {""} ;
         P00LA11_A950PostulacionesApellidoNombre = new string[] {""} ;
         P00LA11_A949PostulacionesRgoHoraservicio = new string[] {""} ;
         P00LA11_A941PostulacionesTipoFecha = new string[] {""} ;
         P00LA11_A939PostulacionesFechaCierre = new DateTime[] {DateTime.MinValue} ;
         P00LA11_A947PostulacionesFechaTrabajo = new DateTime[] {DateTime.MinValue} ;
         P00LA11_A938PostulacionesSuministrosDescri = new string[] {""} ;
         P00LA11_A937PostulacionesReqSuministros = new bool[] {false} ;
         P00LA11_A936PostulacionesDescripcion = new string[] {""} ;
         P00LA11_A961PostulacionesMultimediaSerial = new short[1] ;
         P00LA11_A946PostulacionesPrecio = new decimal[1] ;
         P00LA11_A969PostulacionesProveedorNombre = new string[] {""} ;
         P00LA11_A943ServiciosNombre = new string[] {""} ;
         P00LA11_A942ServiciosId = new long[1] ;
         P00LA11_n942ServiciosId = new bool[] {false} ;
         P00LA11_A422PostulacionesId = new long[1] ;
         P00LA11_n422PostulacionesId = new bool[] {false} ;
         P00LA11_A945PostulacionesProveedorId = new long[1] ;
         P00LA11_A424PostulacionesEstado = new string[] {""} ;
         P00LA11_A970PostulacionesSolicitudesId = new long[1] ;
         P00LA11_n970PostulacionesSolicitudesId = new bool[] {false} ;
         P00LA13_A941PostulacionesTipoFecha = new string[] {""} ;
         P00LA13_A948PostulacionesSecUserId = new long[1] ;
         P00LA13_A425PostulacionesFechaAlta = new DateTime[] {DateTime.MinValue} ;
         P00LA13_A952PostulacionesTelefono = new string[] {""} ;
         P00LA13_A951PostulacionesMail = new string[] {""} ;
         P00LA13_A950PostulacionesApellidoNombre = new string[] {""} ;
         P00LA13_A949PostulacionesRgoHoraservicio = new string[] {""} ;
         P00LA13_A940PostulacionesHoraCierre = new string[] {""} ;
         P00LA13_A939PostulacionesFechaCierre = new DateTime[] {DateTime.MinValue} ;
         P00LA13_A947PostulacionesFechaTrabajo = new DateTime[] {DateTime.MinValue} ;
         P00LA13_A938PostulacionesSuministrosDescri = new string[] {""} ;
         P00LA13_A937PostulacionesReqSuministros = new bool[] {false} ;
         P00LA13_A936PostulacionesDescripcion = new string[] {""} ;
         P00LA13_A961PostulacionesMultimediaSerial = new short[1] ;
         P00LA13_A946PostulacionesPrecio = new decimal[1] ;
         P00LA13_A969PostulacionesProveedorNombre = new string[] {""} ;
         P00LA13_A943ServiciosNombre = new string[] {""} ;
         P00LA13_A942ServiciosId = new long[1] ;
         P00LA13_n942ServiciosId = new bool[] {false} ;
         P00LA13_A422PostulacionesId = new long[1] ;
         P00LA13_n422PostulacionesId = new bool[] {false} ;
         P00LA13_A945PostulacionesProveedorId = new long[1] ;
         P00LA13_A424PostulacionesEstado = new string[] {""} ;
         P00LA13_A970PostulacionesSolicitudesId = new long[1] ;
         P00LA13_n970PostulacionesSolicitudesId = new bool[] {false} ;
         P00LA15_A949PostulacionesRgoHoraservicio = new string[] {""} ;
         P00LA15_A948PostulacionesSecUserId = new long[1] ;
         P00LA15_A425PostulacionesFechaAlta = new DateTime[] {DateTime.MinValue} ;
         P00LA15_A952PostulacionesTelefono = new string[] {""} ;
         P00LA15_A951PostulacionesMail = new string[] {""} ;
         P00LA15_A950PostulacionesApellidoNombre = new string[] {""} ;
         P00LA15_A941PostulacionesTipoFecha = new string[] {""} ;
         P00LA15_A940PostulacionesHoraCierre = new string[] {""} ;
         P00LA15_A939PostulacionesFechaCierre = new DateTime[] {DateTime.MinValue} ;
         P00LA15_A947PostulacionesFechaTrabajo = new DateTime[] {DateTime.MinValue} ;
         P00LA15_A938PostulacionesSuministrosDescri = new string[] {""} ;
         P00LA15_A937PostulacionesReqSuministros = new bool[] {false} ;
         P00LA15_A936PostulacionesDescripcion = new string[] {""} ;
         P00LA15_A961PostulacionesMultimediaSerial = new short[1] ;
         P00LA15_A946PostulacionesPrecio = new decimal[1] ;
         P00LA15_A969PostulacionesProveedorNombre = new string[] {""} ;
         P00LA15_A943ServiciosNombre = new string[] {""} ;
         P00LA15_A942ServiciosId = new long[1] ;
         P00LA15_n942ServiciosId = new bool[] {false} ;
         P00LA15_A422PostulacionesId = new long[1] ;
         P00LA15_n422PostulacionesId = new bool[] {false} ;
         P00LA15_A945PostulacionesProveedorId = new long[1] ;
         P00LA15_A424PostulacionesEstado = new string[] {""} ;
         P00LA15_A970PostulacionesSolicitudesId = new long[1] ;
         P00LA15_n970PostulacionesSolicitudesId = new bool[] {false} ;
         P00LA17_A950PostulacionesApellidoNombre = new string[] {""} ;
         P00LA17_A948PostulacionesSecUserId = new long[1] ;
         P00LA17_A425PostulacionesFechaAlta = new DateTime[] {DateTime.MinValue} ;
         P00LA17_A952PostulacionesTelefono = new string[] {""} ;
         P00LA17_A951PostulacionesMail = new string[] {""} ;
         P00LA17_A949PostulacionesRgoHoraservicio = new string[] {""} ;
         P00LA17_A941PostulacionesTipoFecha = new string[] {""} ;
         P00LA17_A940PostulacionesHoraCierre = new string[] {""} ;
         P00LA17_A939PostulacionesFechaCierre = new DateTime[] {DateTime.MinValue} ;
         P00LA17_A947PostulacionesFechaTrabajo = new DateTime[] {DateTime.MinValue} ;
         P00LA17_A938PostulacionesSuministrosDescri = new string[] {""} ;
         P00LA17_A937PostulacionesReqSuministros = new bool[] {false} ;
         P00LA17_A936PostulacionesDescripcion = new string[] {""} ;
         P00LA17_A961PostulacionesMultimediaSerial = new short[1] ;
         P00LA17_A946PostulacionesPrecio = new decimal[1] ;
         P00LA17_A969PostulacionesProveedorNombre = new string[] {""} ;
         P00LA17_A943ServiciosNombre = new string[] {""} ;
         P00LA17_A942ServiciosId = new long[1] ;
         P00LA17_n942ServiciosId = new bool[] {false} ;
         P00LA17_A422PostulacionesId = new long[1] ;
         P00LA17_n422PostulacionesId = new bool[] {false} ;
         P00LA17_A945PostulacionesProveedorId = new long[1] ;
         P00LA17_A424PostulacionesEstado = new string[] {""} ;
         P00LA17_A970PostulacionesSolicitudesId = new long[1] ;
         P00LA17_n970PostulacionesSolicitudesId = new bool[] {false} ;
         P00LA19_A951PostulacionesMail = new string[] {""} ;
         P00LA19_A948PostulacionesSecUserId = new long[1] ;
         P00LA19_A425PostulacionesFechaAlta = new DateTime[] {DateTime.MinValue} ;
         P00LA19_A952PostulacionesTelefono = new string[] {""} ;
         P00LA19_A950PostulacionesApellidoNombre = new string[] {""} ;
         P00LA19_A949PostulacionesRgoHoraservicio = new string[] {""} ;
         P00LA19_A941PostulacionesTipoFecha = new string[] {""} ;
         P00LA19_A940PostulacionesHoraCierre = new string[] {""} ;
         P00LA19_A939PostulacionesFechaCierre = new DateTime[] {DateTime.MinValue} ;
         P00LA19_A947PostulacionesFechaTrabajo = new DateTime[] {DateTime.MinValue} ;
         P00LA19_A938PostulacionesSuministrosDescri = new string[] {""} ;
         P00LA19_A937PostulacionesReqSuministros = new bool[] {false} ;
         P00LA19_A936PostulacionesDescripcion = new string[] {""} ;
         P00LA19_A961PostulacionesMultimediaSerial = new short[1] ;
         P00LA19_A946PostulacionesPrecio = new decimal[1] ;
         P00LA19_A969PostulacionesProveedorNombre = new string[] {""} ;
         P00LA19_A943ServiciosNombre = new string[] {""} ;
         P00LA19_A942ServiciosId = new long[1] ;
         P00LA19_n942ServiciosId = new bool[] {false} ;
         P00LA19_A422PostulacionesId = new long[1] ;
         P00LA19_n422PostulacionesId = new bool[] {false} ;
         P00LA19_A945PostulacionesProveedorId = new long[1] ;
         P00LA19_A424PostulacionesEstado = new string[] {""} ;
         P00LA19_A970PostulacionesSolicitudesId = new long[1] ;
         P00LA19_n970PostulacionesSolicitudesId = new bool[] {false} ;
         P00LA21_A952PostulacionesTelefono = new string[] {""} ;
         P00LA21_A948PostulacionesSecUserId = new long[1] ;
         P00LA21_A425PostulacionesFechaAlta = new DateTime[] {DateTime.MinValue} ;
         P00LA21_A951PostulacionesMail = new string[] {""} ;
         P00LA21_A950PostulacionesApellidoNombre = new string[] {""} ;
         P00LA21_A949PostulacionesRgoHoraservicio = new string[] {""} ;
         P00LA21_A941PostulacionesTipoFecha = new string[] {""} ;
         P00LA21_A940PostulacionesHoraCierre = new string[] {""} ;
         P00LA21_A939PostulacionesFechaCierre = new DateTime[] {DateTime.MinValue} ;
         P00LA21_A947PostulacionesFechaTrabajo = new DateTime[] {DateTime.MinValue} ;
         P00LA21_A938PostulacionesSuministrosDescri = new string[] {""} ;
         P00LA21_A937PostulacionesReqSuministros = new bool[] {false} ;
         P00LA21_A936PostulacionesDescripcion = new string[] {""} ;
         P00LA21_A961PostulacionesMultimediaSerial = new short[1] ;
         P00LA21_A946PostulacionesPrecio = new decimal[1] ;
         P00LA21_A969PostulacionesProveedorNombre = new string[] {""} ;
         P00LA21_A943ServiciosNombre = new string[] {""} ;
         P00LA21_A942ServiciosId = new long[1] ;
         P00LA21_n942ServiciosId = new bool[] {false} ;
         P00LA21_A422PostulacionesId = new long[1] ;
         P00LA21_n422PostulacionesId = new bool[] {false} ;
         P00LA21_A945PostulacionesProveedorId = new long[1] ;
         P00LA21_A424PostulacionesEstado = new string[] {""} ;
         P00LA21_A970PostulacionesSolicitudesId = new long[1] ;
         P00LA21_n970PostulacionesSolicitudesId = new bool[] {false} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.postulacioneswwgetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P00LA3_A942ServiciosId, P00LA3_n942ServiciosId, P00LA3_A948PostulacionesSecUserId, P00LA3_A425PostulacionesFechaAlta, P00LA3_A952PostulacionesTelefono, P00LA3_A951PostulacionesMail, P00LA3_A950PostulacionesApellidoNombre, P00LA3_A949PostulacionesRgoHoraservicio, P00LA3_A941PostulacionesTipoFecha, P00LA3_A940PostulacionesHoraCierre,
               P00LA3_A939PostulacionesFechaCierre, P00LA3_A947PostulacionesFechaTrabajo, P00LA3_A938PostulacionesSuministrosDescri, P00LA3_A937PostulacionesReqSuministros, P00LA3_A936PostulacionesDescripcion, P00LA3_A961PostulacionesMultimediaSerial, P00LA3_A946PostulacionesPrecio, P00LA3_A969PostulacionesProveedorNombre, P00LA3_A943ServiciosNombre, P00LA3_A422PostulacionesId,
               P00LA3_A945PostulacionesProveedorId, P00LA3_A424PostulacionesEstado, P00LA3_A970PostulacionesSolicitudesId, P00LA3_n970PostulacionesSolicitudesId
               }
               , new Object[] {
               P00LA5_A945PostulacionesProveedorId, P00LA5_A948PostulacionesSecUserId, P00LA5_A425PostulacionesFechaAlta, P00LA5_A952PostulacionesTelefono, P00LA5_A951PostulacionesMail, P00LA5_A950PostulacionesApellidoNombre, P00LA5_A949PostulacionesRgoHoraservicio, P00LA5_A941PostulacionesTipoFecha, P00LA5_A940PostulacionesHoraCierre, P00LA5_A939PostulacionesFechaCierre,
               P00LA5_A947PostulacionesFechaTrabajo, P00LA5_A938PostulacionesSuministrosDescri, P00LA5_A937PostulacionesReqSuministros, P00LA5_A936PostulacionesDescripcion, P00LA5_A961PostulacionesMultimediaSerial, P00LA5_A946PostulacionesPrecio, P00LA5_A969PostulacionesProveedorNombre, P00LA5_A943ServiciosNombre, P00LA5_A942ServiciosId, P00LA5_n942ServiciosId,
               P00LA5_A422PostulacionesId, P00LA5_A424PostulacionesEstado, P00LA5_A970PostulacionesSolicitudesId, P00LA5_n970PostulacionesSolicitudesId
               }
               , new Object[] {
               P00LA7_A936PostulacionesDescripcion, P00LA7_A948PostulacionesSecUserId, P00LA7_A425PostulacionesFechaAlta, P00LA7_A952PostulacionesTelefono, P00LA7_A951PostulacionesMail, P00LA7_A950PostulacionesApellidoNombre, P00LA7_A949PostulacionesRgoHoraservicio, P00LA7_A941PostulacionesTipoFecha, P00LA7_A940PostulacionesHoraCierre, P00LA7_A939PostulacionesFechaCierre,
               P00LA7_A947PostulacionesFechaTrabajo, P00LA7_A938PostulacionesSuministrosDescri, P00LA7_A937PostulacionesReqSuministros, P00LA7_A961PostulacionesMultimediaSerial, P00LA7_A946PostulacionesPrecio, P00LA7_A969PostulacionesProveedorNombre, P00LA7_A943ServiciosNombre, P00LA7_A942ServiciosId, P00LA7_n942ServiciosId, P00LA7_A422PostulacionesId,
               P00LA7_A945PostulacionesProveedorId, P00LA7_A424PostulacionesEstado, P00LA7_A970PostulacionesSolicitudesId, P00LA7_n970PostulacionesSolicitudesId
               }
               , new Object[] {
               P00LA9_A938PostulacionesSuministrosDescri, P00LA9_A948PostulacionesSecUserId, P00LA9_A425PostulacionesFechaAlta, P00LA9_A952PostulacionesTelefono, P00LA9_A951PostulacionesMail, P00LA9_A950PostulacionesApellidoNombre, P00LA9_A949PostulacionesRgoHoraservicio, P00LA9_A941PostulacionesTipoFecha, P00LA9_A940PostulacionesHoraCierre, P00LA9_A939PostulacionesFechaCierre,
               P00LA9_A947PostulacionesFechaTrabajo, P00LA9_A937PostulacionesReqSuministros, P00LA9_A936PostulacionesDescripcion, P00LA9_A961PostulacionesMultimediaSerial, P00LA9_A946PostulacionesPrecio, P00LA9_A969PostulacionesProveedorNombre, P00LA9_A943ServiciosNombre, P00LA9_A942ServiciosId, P00LA9_n942ServiciosId, P00LA9_A422PostulacionesId,
               P00LA9_A945PostulacionesProveedorId, P00LA9_A424PostulacionesEstado, P00LA9_A970PostulacionesSolicitudesId, P00LA9_n970PostulacionesSolicitudesId
               }
               , new Object[] {
               P00LA11_A940PostulacionesHoraCierre, P00LA11_A948PostulacionesSecUserId, P00LA11_A425PostulacionesFechaAlta, P00LA11_A952PostulacionesTelefono, P00LA11_A951PostulacionesMail, P00LA11_A950PostulacionesApellidoNombre, P00LA11_A949PostulacionesRgoHoraservicio, P00LA11_A941PostulacionesTipoFecha, P00LA11_A939PostulacionesFechaCierre, P00LA11_A947PostulacionesFechaTrabajo,
               P00LA11_A938PostulacionesSuministrosDescri, P00LA11_A937PostulacionesReqSuministros, P00LA11_A936PostulacionesDescripcion, P00LA11_A961PostulacionesMultimediaSerial, P00LA11_A946PostulacionesPrecio, P00LA11_A969PostulacionesProveedorNombre, P00LA11_A943ServiciosNombre, P00LA11_A942ServiciosId, P00LA11_n942ServiciosId, P00LA11_A422PostulacionesId,
               P00LA11_A945PostulacionesProveedorId, P00LA11_A424PostulacionesEstado, P00LA11_A970PostulacionesSolicitudesId, P00LA11_n970PostulacionesSolicitudesId
               }
               , new Object[] {
               P00LA13_A941PostulacionesTipoFecha, P00LA13_A948PostulacionesSecUserId, P00LA13_A425PostulacionesFechaAlta, P00LA13_A952PostulacionesTelefono, P00LA13_A951PostulacionesMail, P00LA13_A950PostulacionesApellidoNombre, P00LA13_A949PostulacionesRgoHoraservicio, P00LA13_A940PostulacionesHoraCierre, P00LA13_A939PostulacionesFechaCierre, P00LA13_A947PostulacionesFechaTrabajo,
               P00LA13_A938PostulacionesSuministrosDescri, P00LA13_A937PostulacionesReqSuministros, P00LA13_A936PostulacionesDescripcion, P00LA13_A961PostulacionesMultimediaSerial, P00LA13_A946PostulacionesPrecio, P00LA13_A969PostulacionesProveedorNombre, P00LA13_A943ServiciosNombre, P00LA13_A942ServiciosId, P00LA13_n942ServiciosId, P00LA13_A422PostulacionesId,
               P00LA13_A945PostulacionesProveedorId, P00LA13_A424PostulacionesEstado, P00LA13_A970PostulacionesSolicitudesId, P00LA13_n970PostulacionesSolicitudesId
               }
               , new Object[] {
               P00LA15_A949PostulacionesRgoHoraservicio, P00LA15_A948PostulacionesSecUserId, P00LA15_A425PostulacionesFechaAlta, P00LA15_A952PostulacionesTelefono, P00LA15_A951PostulacionesMail, P00LA15_A950PostulacionesApellidoNombre, P00LA15_A941PostulacionesTipoFecha, P00LA15_A940PostulacionesHoraCierre, P00LA15_A939PostulacionesFechaCierre, P00LA15_A947PostulacionesFechaTrabajo,
               P00LA15_A938PostulacionesSuministrosDescri, P00LA15_A937PostulacionesReqSuministros, P00LA15_A936PostulacionesDescripcion, P00LA15_A961PostulacionesMultimediaSerial, P00LA15_A946PostulacionesPrecio, P00LA15_A969PostulacionesProveedorNombre, P00LA15_A943ServiciosNombre, P00LA15_A942ServiciosId, P00LA15_n942ServiciosId, P00LA15_A422PostulacionesId,
               P00LA15_A945PostulacionesProveedorId, P00LA15_A424PostulacionesEstado, P00LA15_A970PostulacionesSolicitudesId, P00LA15_n970PostulacionesSolicitudesId
               }
               , new Object[] {
               P00LA17_A950PostulacionesApellidoNombre, P00LA17_A948PostulacionesSecUserId, P00LA17_A425PostulacionesFechaAlta, P00LA17_A952PostulacionesTelefono, P00LA17_A951PostulacionesMail, P00LA17_A949PostulacionesRgoHoraservicio, P00LA17_A941PostulacionesTipoFecha, P00LA17_A940PostulacionesHoraCierre, P00LA17_A939PostulacionesFechaCierre, P00LA17_A947PostulacionesFechaTrabajo,
               P00LA17_A938PostulacionesSuministrosDescri, P00LA17_A937PostulacionesReqSuministros, P00LA17_A936PostulacionesDescripcion, P00LA17_A961PostulacionesMultimediaSerial, P00LA17_A946PostulacionesPrecio, P00LA17_A969PostulacionesProveedorNombre, P00LA17_A943ServiciosNombre, P00LA17_A942ServiciosId, P00LA17_n942ServiciosId, P00LA17_A422PostulacionesId,
               P00LA17_A945PostulacionesProveedorId, P00LA17_A424PostulacionesEstado, P00LA17_A970PostulacionesSolicitudesId, P00LA17_n970PostulacionesSolicitudesId
               }
               , new Object[] {
               P00LA19_A951PostulacionesMail, P00LA19_A948PostulacionesSecUserId, P00LA19_A425PostulacionesFechaAlta, P00LA19_A952PostulacionesTelefono, P00LA19_A950PostulacionesApellidoNombre, P00LA19_A949PostulacionesRgoHoraservicio, P00LA19_A941PostulacionesTipoFecha, P00LA19_A940PostulacionesHoraCierre, P00LA19_A939PostulacionesFechaCierre, P00LA19_A947PostulacionesFechaTrabajo,
               P00LA19_A938PostulacionesSuministrosDescri, P00LA19_A937PostulacionesReqSuministros, P00LA19_A936PostulacionesDescripcion, P00LA19_A961PostulacionesMultimediaSerial, P00LA19_A946PostulacionesPrecio, P00LA19_A969PostulacionesProveedorNombre, P00LA19_A943ServiciosNombre, P00LA19_A942ServiciosId, P00LA19_n942ServiciosId, P00LA19_A422PostulacionesId,
               P00LA19_A945PostulacionesProveedorId, P00LA19_A424PostulacionesEstado, P00LA19_A970PostulacionesSolicitudesId, P00LA19_n970PostulacionesSolicitudesId
               }
               , new Object[] {
               P00LA21_A952PostulacionesTelefono, P00LA21_A948PostulacionesSecUserId, P00LA21_A425PostulacionesFechaAlta, P00LA21_A951PostulacionesMail, P00LA21_A950PostulacionesApellidoNombre, P00LA21_A949PostulacionesRgoHoraservicio, P00LA21_A941PostulacionesTipoFecha, P00LA21_A940PostulacionesHoraCierre, P00LA21_A939PostulacionesFechaCierre, P00LA21_A947PostulacionesFechaTrabajo,
               P00LA21_A938PostulacionesSuministrosDescri, P00LA21_A937PostulacionesReqSuministros, P00LA21_A936PostulacionesDescripcion, P00LA21_A961PostulacionesMultimediaSerial, P00LA21_A946PostulacionesPrecio, P00LA21_A969PostulacionesProveedorNombre, P00LA21_A943ServiciosNombre, P00LA21_A942ServiciosId, P00LA21_n942ServiciosId, P00LA21_A422PostulacionesId,
               P00LA21_A945PostulacionesProveedorId, P00LA21_A424PostulacionesEstado, P00LA21_A970PostulacionesSolicitudesId, P00LA21_n970PostulacionesSolicitudesId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV51MaxItems ;
      private short AV50PageIndex ;
      private short AV49SkipItems ;
      private short AV87TFPostulacionesMultimediaSerial ;
      private short AV88TFPostulacionesMultimediaSerial_To ;
      private short AV23TFPostulacionesReqSuministros_Sel ;
      private short AV72DynamicFiltersOperator1 ;
      private short AV77DynamicFiltersOperator2 ;
      private short AV82DynamicFiltersOperator3 ;
      private short AV108Postulacioneswwds_3_dynamicfiltersoperator1 ;
      private short AV114Postulacioneswwds_9_dynamicfiltersoperator2 ;
      private short AV120Postulacioneswwds_15_dynamicfiltersoperator3 ;
      private short AV136Postulacioneswwds_31_tfpostulacionesmultimediaserial ;
      private short AV137Postulacioneswwds_32_tfpostulacionesmultimediaserial_to ;
      private short AV142Postulacioneswwds_37_tfpostulacionesreqsuministros_sel ;
      private short A961PostulacionesMultimediaSerial ;
      private int AV104GXV1 ;
      private int AV163Postulacioneswwds_58_tfpostulacionesestado_sels_Count ;
      private int AV52InsertIndex ;
      private long AV11TFPostulacionesId ;
      private long AV12TFPostulacionesId_To ;
      private long AV13TFServiciosId ;
      private long AV14TFServiciosId_To ;
      private long AV17TFPostulacionesProveedorId ;
      private long AV18TFPostulacionesProveedorId_To ;
      private long AV89TFPostulacionesSolicitudesId ;
      private long AV90TFPostulacionesSolicitudesId_To ;
      private long AV46TFPostulacionesSecUserId ;
      private long AV47TFPostulacionesSecUserId_To ;
      private long AV73PostulacionesProveedorId1 ;
      private long AV78PostulacionesProveedorId2 ;
      private long AV83PostulacionesProveedorId3 ;
      private long AV110Postulacioneswwds_5_postulacionesproveedorid1 ;
      private long AV116Postulacioneswwds_11_postulacionesproveedorid2 ;
      private long AV122Postulacioneswwds_17_postulacionesproveedorid3 ;
      private long AV124Postulacioneswwds_19_tfpostulacionesid ;
      private long AV125Postulacioneswwds_20_tfpostulacionesid_to ;
      private long AV126Postulacioneswwds_21_tfserviciosid ;
      private long AV127Postulacioneswwds_22_tfserviciosid_to ;
      private long AV130Postulacioneswwds_25_tfpostulacionesproveedorid ;
      private long AV131Postulacioneswwds_26_tfpostulacionesproveedorid_to ;
      private long AV138Postulacioneswwds_33_tfpostulacionessolicitudesid ;
      private long AV139Postulacioneswwds_34_tfpostulacionessolicitudesid_to ;
      private long AV164Postulacioneswwds_59_tfpostulacionessecuserid ;
      private long AV165Postulacioneswwds_60_tfpostulacionessecuserid_to ;
      private long A945PostulacionesProveedorId ;
      private long A422PostulacionesId ;
      private long A942ServiciosId ;
      private long A948PostulacionesSecUserId ;
      private long A970PostulacionesSolicitudesId ;
      private long AV58count ;
      private decimal AV19TFPostulacionesPrecio ;
      private decimal AV20TFPostulacionesPrecio_To ;
      private decimal AV134Postulacioneswwds_29_tfpostulacionesprecio ;
      private decimal AV135Postulacioneswwds_30_tfpostulacionesprecio_to ;
      private decimal A946PostulacionesPrecio ;
      private string AV15TFServiciosNombre ;
      private string AV16TFServiciosNombre_Sel ;
      private string AV85TFPostulacionesProveedorNombre ;
      private string AV86TFPostulacionesProveedorNombre_Sel ;
      private string AV21TFPostulacionesDescripcion ;
      private string AV22TFPostulacionesDescripcion_Sel ;
      private string AV24TFPostulacionesSuministrosDescripcion ;
      private string AV25TFPostulacionesSuministrosDescripcion_Sel ;
      private string AV34TFPostulacionesRgoHoraservicio ;
      private string AV35TFPostulacionesRgoHoraservicio_Sel ;
      private string AV36TFPostulacionesApellidoNombre ;
      private string AV37TFPostulacionesApellidoNombre_Sel ;
      private string AV40TFPostulacionesTelefono ;
      private string AV41TFPostulacionesTelefono_Sel ;
      private string AV91PostulacionesProveedorNombre1 ;
      private string AV74ServiciosNombre1 ;
      private string AV92PostulacionesProveedorNombre2 ;
      private string AV79ServiciosNombre2 ;
      private string AV93PostulacionesProveedorNombre3 ;
      private string AV84ServiciosNombre3 ;
      private string AV109Postulacioneswwds_4_postulacionesproveedornombre1 ;
      private string AV111Postulacioneswwds_6_serviciosnombre1 ;
      private string AV115Postulacioneswwds_10_postulacionesproveedornombre2 ;
      private string AV117Postulacioneswwds_12_serviciosnombre2 ;
      private string AV121Postulacioneswwds_16_postulacionesproveedornombre3 ;
      private string AV123Postulacioneswwds_18_serviciosnombre3 ;
      private string AV128Postulacioneswwds_23_tfserviciosnombre ;
      private string AV129Postulacioneswwds_24_tfserviciosnombre_sel ;
      private string AV132Postulacioneswwds_27_tfpostulacionesproveedornombre ;
      private string AV133Postulacioneswwds_28_tfpostulacionesproveedornombre_sel ;
      private string AV140Postulacioneswwds_35_tfpostulacionesdescripcion ;
      private string AV141Postulacioneswwds_36_tfpostulacionesdescripcion_sel ;
      private string AV143Postulacioneswwds_38_tfpostulacionessuministrosdescripcion ;
      private string AV144Postulacioneswwds_39_tfpostulacionessuministrosdescripcion_sel ;
      private string AV153Postulacioneswwds_48_tfpostulacionesrgohoraservicio ;
      private string AV154Postulacioneswwds_49_tfpostulacionesrgohoraservicio_sel ;
      private string AV155Postulacioneswwds_50_tfpostulacionesapellidonombre ;
      private string AV156Postulacioneswwds_51_tfpostulacionesapellidonombre_sel ;
      private string AV159Postulacioneswwds_54_tfpostulacionestelefono ;
      private string AV160Postulacioneswwds_55_tfpostulacionestelefono_sel ;
      private string lV109Postulacioneswwds_4_postulacionesproveedornombre1 ;
      private string lV111Postulacioneswwds_6_serviciosnombre1 ;
      private string lV115Postulacioneswwds_10_postulacionesproveedornombre2 ;
      private string lV117Postulacioneswwds_12_serviciosnombre2 ;
      private string lV121Postulacioneswwds_16_postulacionesproveedornombre3 ;
      private string lV123Postulacioneswwds_18_serviciosnombre3 ;
      private string lV128Postulacioneswwds_23_tfserviciosnombre ;
      private string lV132Postulacioneswwds_27_tfpostulacionesproveedornombre ;
      private string lV140Postulacioneswwds_35_tfpostulacionesdescripcion ;
      private string lV143Postulacioneswwds_38_tfpostulacionessuministrosdescripcion ;
      private string lV153Postulacioneswwds_48_tfpostulacionesrgohoraservicio ;
      private string lV155Postulacioneswwds_50_tfpostulacionesapellidonombre ;
      private string lV159Postulacioneswwds_54_tfpostulacionestelefono ;
      private string A424PostulacionesEstado ;
      private string A969PostulacionesProveedorNombre ;
      private string A943ServiciosNombre ;
      private string A936PostulacionesDescripcion ;
      private string A938PostulacionesSuministrosDescri ;
      private string A949PostulacionesRgoHoraservicio ;
      private string A950PostulacionesApellidoNombre ;
      private string A952PostulacionesTelefono ;
      private DateTime AV42TFPostulacionesFechaAlta ;
      private DateTime AV43TFPostulacionesFechaAlta_To ;
      private DateTime AV161Postulacioneswwds_56_tfpostulacionesfechaalta ;
      private DateTime AV162Postulacioneswwds_57_tfpostulacionesfechaalta_to ;
      private DateTime A425PostulacionesFechaAlta ;
      private DateTime AV26TFPostulacionesFechaTrabajo ;
      private DateTime AV27TFPostulacionesFechaTrabajo_To ;
      private DateTime AV28TFPostulacionesFechaCierre ;
      private DateTime AV29TFPostulacionesFechaCierre_To ;
      private DateTime AV145Postulacioneswwds_40_tfpostulacionesfechatrabajo ;
      private DateTime AV146Postulacioneswwds_41_tfpostulacionesfechatrabajo_to ;
      private DateTime AV147Postulacioneswwds_42_tfpostulacionesfechacierre ;
      private DateTime AV148Postulacioneswwds_43_tfpostulacionesfechacierre_to ;
      private DateTime A947PostulacionesFechaTrabajo ;
      private DateTime A939PostulacionesFechaCierre ;
      private bool AV8IsAuthorized ;
      private bool GXt_boolean1 ;
      private bool returnInSub ;
      private bool AV75DynamicFiltersEnabled2 ;
      private bool AV80DynamicFiltersEnabled3 ;
      private bool AV112Postulacioneswwds_7_dynamicfiltersenabled2 ;
      private bool AV118Postulacioneswwds_13_dynamicfiltersenabled3 ;
      private bool A937PostulacionesReqSuministros ;
      private bool n422PostulacionesId ;
      private bool BRKLA2 ;
      private bool n942ServiciosId ;
      private bool n970PostulacionesSolicitudesId ;
      private bool BRKLA4 ;
      private bool BRKLA6 ;
      private bool BRKLA8 ;
      private bool BRKLA10 ;
      private bool BRKLA12 ;
      private bool BRKLA14 ;
      private bool BRKLA16 ;
      private bool BRKLA18 ;
      private bool BRKLA20 ;
      private string AV67OptionsJson ;
      private string AV68OptionsDescJson ;
      private string AV69OptionIndexesJson ;
      private string AV44TFPostulacionesEstado_SelsJson ;
      private string AV64DDOName ;
      private string AV65SearchTxtParms ;
      private string AV66SearchTxtTo ;
      private string AV48SearchTxt ;
      private string AV70FilterFullText ;
      private string AV30TFPostulacionesHoraCierre ;
      private string AV31TFPostulacionesHoraCierre_Sel ;
      private string AV32TFPostulacionesTipoFecha ;
      private string AV103TFPostulacionesTipoFecha_Sel ;
      private string AV38TFPostulacionesMail ;
      private string AV39TFPostulacionesMail_Sel ;
      private string AV71DynamicFiltersSelector1 ;
      private string AV76DynamicFiltersSelector2 ;
      private string AV81DynamicFiltersSelector3 ;
      private string AV106Postulacioneswwds_1_filterfulltext ;
      private string AV107Postulacioneswwds_2_dynamicfiltersselector1 ;
      private string AV113Postulacioneswwds_8_dynamicfiltersselector2 ;
      private string AV119Postulacioneswwds_14_dynamicfiltersselector3 ;
      private string AV149Postulacioneswwds_44_tfpostulacioneshoracierre ;
      private string AV150Postulacioneswwds_45_tfpostulacioneshoracierre_sel ;
      private string AV151Postulacioneswwds_46_tfpostulacionestipofecha ;
      private string AV152Postulacioneswwds_47_tfpostulacionestipofecha_sel ;
      private string AV157Postulacioneswwds_52_tfpostulacionesmail ;
      private string AV158Postulacioneswwds_53_tfpostulacionesmail_sel ;
      private string lV106Postulacioneswwds_1_filterfulltext ;
      private string lV149Postulacioneswwds_44_tfpostulacioneshoracierre ;
      private string lV151Postulacioneswwds_46_tfpostulacionestipofecha ;
      private string lV157Postulacioneswwds_52_tfpostulacionesmail ;
      private string A940PostulacionesHoraCierre ;
      private string A941PostulacionesTipoFecha ;
      private string A951PostulacionesMail ;
      private string AV53Option ;
      private IGxSession AV59Session ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GxSimpleCollection<string> AV54Options ;
      private GxSimpleCollection<string> AV56OptionsDesc ;
      private GxSimpleCollection<string> AV57OptionIndexes ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV61GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV62GridStateFilterValue ;
      private GxSimpleCollection<string> AV45TFPostulacionesEstado_Sels ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV63GridStateDynamicFilter ;
      private GxSimpleCollection<string> AV163Postulacioneswwds_58_tfpostulacionesestado_sels ;
      private IDataStoreProvider pr_default ;
      private long[] P00LA3_A942ServiciosId ;
      private bool[] P00LA3_n942ServiciosId ;
      private long[] P00LA3_A948PostulacionesSecUserId ;
      private DateTime[] P00LA3_A425PostulacionesFechaAlta ;
      private string[] P00LA3_A952PostulacionesTelefono ;
      private string[] P00LA3_A951PostulacionesMail ;
      private string[] P00LA3_A950PostulacionesApellidoNombre ;
      private string[] P00LA3_A949PostulacionesRgoHoraservicio ;
      private string[] P00LA3_A941PostulacionesTipoFecha ;
      private string[] P00LA3_A940PostulacionesHoraCierre ;
      private DateTime[] P00LA3_A939PostulacionesFechaCierre ;
      private DateTime[] P00LA3_A947PostulacionesFechaTrabajo ;
      private string[] P00LA3_A938PostulacionesSuministrosDescri ;
      private bool[] P00LA3_A937PostulacionesReqSuministros ;
      private string[] P00LA3_A936PostulacionesDescripcion ;
      private short[] P00LA3_A961PostulacionesMultimediaSerial ;
      private decimal[] P00LA3_A946PostulacionesPrecio ;
      private string[] P00LA3_A969PostulacionesProveedorNombre ;
      private string[] P00LA3_A943ServiciosNombre ;
      private long[] P00LA3_A422PostulacionesId ;
      private bool[] P00LA3_n422PostulacionesId ;
      private long[] P00LA3_A945PostulacionesProveedorId ;
      private string[] P00LA3_A424PostulacionesEstado ;
      private long[] P00LA3_A970PostulacionesSolicitudesId ;
      private bool[] P00LA3_n970PostulacionesSolicitudesId ;
      private long[] P00LA5_A945PostulacionesProveedorId ;
      private long[] P00LA5_A948PostulacionesSecUserId ;
      private DateTime[] P00LA5_A425PostulacionesFechaAlta ;
      private string[] P00LA5_A952PostulacionesTelefono ;
      private string[] P00LA5_A951PostulacionesMail ;
      private string[] P00LA5_A950PostulacionesApellidoNombre ;
      private string[] P00LA5_A949PostulacionesRgoHoraservicio ;
      private string[] P00LA5_A941PostulacionesTipoFecha ;
      private string[] P00LA5_A940PostulacionesHoraCierre ;
      private DateTime[] P00LA5_A939PostulacionesFechaCierre ;
      private DateTime[] P00LA5_A947PostulacionesFechaTrabajo ;
      private string[] P00LA5_A938PostulacionesSuministrosDescri ;
      private bool[] P00LA5_A937PostulacionesReqSuministros ;
      private string[] P00LA5_A936PostulacionesDescripcion ;
      private short[] P00LA5_A961PostulacionesMultimediaSerial ;
      private decimal[] P00LA5_A946PostulacionesPrecio ;
      private string[] P00LA5_A969PostulacionesProveedorNombre ;
      private string[] P00LA5_A943ServiciosNombre ;
      private long[] P00LA5_A942ServiciosId ;
      private bool[] P00LA5_n942ServiciosId ;
      private long[] P00LA5_A422PostulacionesId ;
      private bool[] P00LA5_n422PostulacionesId ;
      private string[] P00LA5_A424PostulacionesEstado ;
      private long[] P00LA5_A970PostulacionesSolicitudesId ;
      private bool[] P00LA5_n970PostulacionesSolicitudesId ;
      private string[] P00LA7_A936PostulacionesDescripcion ;
      private long[] P00LA7_A948PostulacionesSecUserId ;
      private DateTime[] P00LA7_A425PostulacionesFechaAlta ;
      private string[] P00LA7_A952PostulacionesTelefono ;
      private string[] P00LA7_A951PostulacionesMail ;
      private string[] P00LA7_A950PostulacionesApellidoNombre ;
      private string[] P00LA7_A949PostulacionesRgoHoraservicio ;
      private string[] P00LA7_A941PostulacionesTipoFecha ;
      private string[] P00LA7_A940PostulacionesHoraCierre ;
      private DateTime[] P00LA7_A939PostulacionesFechaCierre ;
      private DateTime[] P00LA7_A947PostulacionesFechaTrabajo ;
      private string[] P00LA7_A938PostulacionesSuministrosDescri ;
      private bool[] P00LA7_A937PostulacionesReqSuministros ;
      private short[] P00LA7_A961PostulacionesMultimediaSerial ;
      private decimal[] P00LA7_A946PostulacionesPrecio ;
      private string[] P00LA7_A969PostulacionesProveedorNombre ;
      private string[] P00LA7_A943ServiciosNombre ;
      private long[] P00LA7_A942ServiciosId ;
      private bool[] P00LA7_n942ServiciosId ;
      private long[] P00LA7_A422PostulacionesId ;
      private bool[] P00LA7_n422PostulacionesId ;
      private long[] P00LA7_A945PostulacionesProveedorId ;
      private string[] P00LA7_A424PostulacionesEstado ;
      private long[] P00LA7_A970PostulacionesSolicitudesId ;
      private bool[] P00LA7_n970PostulacionesSolicitudesId ;
      private string[] P00LA9_A938PostulacionesSuministrosDescri ;
      private long[] P00LA9_A948PostulacionesSecUserId ;
      private DateTime[] P00LA9_A425PostulacionesFechaAlta ;
      private string[] P00LA9_A952PostulacionesTelefono ;
      private string[] P00LA9_A951PostulacionesMail ;
      private string[] P00LA9_A950PostulacionesApellidoNombre ;
      private string[] P00LA9_A949PostulacionesRgoHoraservicio ;
      private string[] P00LA9_A941PostulacionesTipoFecha ;
      private string[] P00LA9_A940PostulacionesHoraCierre ;
      private DateTime[] P00LA9_A939PostulacionesFechaCierre ;
      private DateTime[] P00LA9_A947PostulacionesFechaTrabajo ;
      private bool[] P00LA9_A937PostulacionesReqSuministros ;
      private string[] P00LA9_A936PostulacionesDescripcion ;
      private short[] P00LA9_A961PostulacionesMultimediaSerial ;
      private decimal[] P00LA9_A946PostulacionesPrecio ;
      private string[] P00LA9_A969PostulacionesProveedorNombre ;
      private string[] P00LA9_A943ServiciosNombre ;
      private long[] P00LA9_A942ServiciosId ;
      private bool[] P00LA9_n942ServiciosId ;
      private long[] P00LA9_A422PostulacionesId ;
      private bool[] P00LA9_n422PostulacionesId ;
      private long[] P00LA9_A945PostulacionesProveedorId ;
      private string[] P00LA9_A424PostulacionesEstado ;
      private long[] P00LA9_A970PostulacionesSolicitudesId ;
      private bool[] P00LA9_n970PostulacionesSolicitudesId ;
      private string[] P00LA11_A940PostulacionesHoraCierre ;
      private long[] P00LA11_A948PostulacionesSecUserId ;
      private DateTime[] P00LA11_A425PostulacionesFechaAlta ;
      private string[] P00LA11_A952PostulacionesTelefono ;
      private string[] P00LA11_A951PostulacionesMail ;
      private string[] P00LA11_A950PostulacionesApellidoNombre ;
      private string[] P00LA11_A949PostulacionesRgoHoraservicio ;
      private string[] P00LA11_A941PostulacionesTipoFecha ;
      private DateTime[] P00LA11_A939PostulacionesFechaCierre ;
      private DateTime[] P00LA11_A947PostulacionesFechaTrabajo ;
      private string[] P00LA11_A938PostulacionesSuministrosDescri ;
      private bool[] P00LA11_A937PostulacionesReqSuministros ;
      private string[] P00LA11_A936PostulacionesDescripcion ;
      private short[] P00LA11_A961PostulacionesMultimediaSerial ;
      private decimal[] P00LA11_A946PostulacionesPrecio ;
      private string[] P00LA11_A969PostulacionesProveedorNombre ;
      private string[] P00LA11_A943ServiciosNombre ;
      private long[] P00LA11_A942ServiciosId ;
      private bool[] P00LA11_n942ServiciosId ;
      private long[] P00LA11_A422PostulacionesId ;
      private bool[] P00LA11_n422PostulacionesId ;
      private long[] P00LA11_A945PostulacionesProveedorId ;
      private string[] P00LA11_A424PostulacionesEstado ;
      private long[] P00LA11_A970PostulacionesSolicitudesId ;
      private bool[] P00LA11_n970PostulacionesSolicitudesId ;
      private string[] P00LA13_A941PostulacionesTipoFecha ;
      private long[] P00LA13_A948PostulacionesSecUserId ;
      private DateTime[] P00LA13_A425PostulacionesFechaAlta ;
      private string[] P00LA13_A952PostulacionesTelefono ;
      private string[] P00LA13_A951PostulacionesMail ;
      private string[] P00LA13_A950PostulacionesApellidoNombre ;
      private string[] P00LA13_A949PostulacionesRgoHoraservicio ;
      private string[] P00LA13_A940PostulacionesHoraCierre ;
      private DateTime[] P00LA13_A939PostulacionesFechaCierre ;
      private DateTime[] P00LA13_A947PostulacionesFechaTrabajo ;
      private string[] P00LA13_A938PostulacionesSuministrosDescri ;
      private bool[] P00LA13_A937PostulacionesReqSuministros ;
      private string[] P00LA13_A936PostulacionesDescripcion ;
      private short[] P00LA13_A961PostulacionesMultimediaSerial ;
      private decimal[] P00LA13_A946PostulacionesPrecio ;
      private string[] P00LA13_A969PostulacionesProveedorNombre ;
      private string[] P00LA13_A943ServiciosNombre ;
      private long[] P00LA13_A942ServiciosId ;
      private bool[] P00LA13_n942ServiciosId ;
      private long[] P00LA13_A422PostulacionesId ;
      private bool[] P00LA13_n422PostulacionesId ;
      private long[] P00LA13_A945PostulacionesProveedorId ;
      private string[] P00LA13_A424PostulacionesEstado ;
      private long[] P00LA13_A970PostulacionesSolicitudesId ;
      private bool[] P00LA13_n970PostulacionesSolicitudesId ;
      private string[] P00LA15_A949PostulacionesRgoHoraservicio ;
      private long[] P00LA15_A948PostulacionesSecUserId ;
      private DateTime[] P00LA15_A425PostulacionesFechaAlta ;
      private string[] P00LA15_A952PostulacionesTelefono ;
      private string[] P00LA15_A951PostulacionesMail ;
      private string[] P00LA15_A950PostulacionesApellidoNombre ;
      private string[] P00LA15_A941PostulacionesTipoFecha ;
      private string[] P00LA15_A940PostulacionesHoraCierre ;
      private DateTime[] P00LA15_A939PostulacionesFechaCierre ;
      private DateTime[] P00LA15_A947PostulacionesFechaTrabajo ;
      private string[] P00LA15_A938PostulacionesSuministrosDescri ;
      private bool[] P00LA15_A937PostulacionesReqSuministros ;
      private string[] P00LA15_A936PostulacionesDescripcion ;
      private short[] P00LA15_A961PostulacionesMultimediaSerial ;
      private decimal[] P00LA15_A946PostulacionesPrecio ;
      private string[] P00LA15_A969PostulacionesProveedorNombre ;
      private string[] P00LA15_A943ServiciosNombre ;
      private long[] P00LA15_A942ServiciosId ;
      private bool[] P00LA15_n942ServiciosId ;
      private long[] P00LA15_A422PostulacionesId ;
      private bool[] P00LA15_n422PostulacionesId ;
      private long[] P00LA15_A945PostulacionesProveedorId ;
      private string[] P00LA15_A424PostulacionesEstado ;
      private long[] P00LA15_A970PostulacionesSolicitudesId ;
      private bool[] P00LA15_n970PostulacionesSolicitudesId ;
      private string[] P00LA17_A950PostulacionesApellidoNombre ;
      private long[] P00LA17_A948PostulacionesSecUserId ;
      private DateTime[] P00LA17_A425PostulacionesFechaAlta ;
      private string[] P00LA17_A952PostulacionesTelefono ;
      private string[] P00LA17_A951PostulacionesMail ;
      private string[] P00LA17_A949PostulacionesRgoHoraservicio ;
      private string[] P00LA17_A941PostulacionesTipoFecha ;
      private string[] P00LA17_A940PostulacionesHoraCierre ;
      private DateTime[] P00LA17_A939PostulacionesFechaCierre ;
      private DateTime[] P00LA17_A947PostulacionesFechaTrabajo ;
      private string[] P00LA17_A938PostulacionesSuministrosDescri ;
      private bool[] P00LA17_A937PostulacionesReqSuministros ;
      private string[] P00LA17_A936PostulacionesDescripcion ;
      private short[] P00LA17_A961PostulacionesMultimediaSerial ;
      private decimal[] P00LA17_A946PostulacionesPrecio ;
      private string[] P00LA17_A969PostulacionesProveedorNombre ;
      private string[] P00LA17_A943ServiciosNombre ;
      private long[] P00LA17_A942ServiciosId ;
      private bool[] P00LA17_n942ServiciosId ;
      private long[] P00LA17_A422PostulacionesId ;
      private bool[] P00LA17_n422PostulacionesId ;
      private long[] P00LA17_A945PostulacionesProveedorId ;
      private string[] P00LA17_A424PostulacionesEstado ;
      private long[] P00LA17_A970PostulacionesSolicitudesId ;
      private bool[] P00LA17_n970PostulacionesSolicitudesId ;
      private string[] P00LA19_A951PostulacionesMail ;
      private long[] P00LA19_A948PostulacionesSecUserId ;
      private DateTime[] P00LA19_A425PostulacionesFechaAlta ;
      private string[] P00LA19_A952PostulacionesTelefono ;
      private string[] P00LA19_A950PostulacionesApellidoNombre ;
      private string[] P00LA19_A949PostulacionesRgoHoraservicio ;
      private string[] P00LA19_A941PostulacionesTipoFecha ;
      private string[] P00LA19_A940PostulacionesHoraCierre ;
      private DateTime[] P00LA19_A939PostulacionesFechaCierre ;
      private DateTime[] P00LA19_A947PostulacionesFechaTrabajo ;
      private string[] P00LA19_A938PostulacionesSuministrosDescri ;
      private bool[] P00LA19_A937PostulacionesReqSuministros ;
      private string[] P00LA19_A936PostulacionesDescripcion ;
      private short[] P00LA19_A961PostulacionesMultimediaSerial ;
      private decimal[] P00LA19_A946PostulacionesPrecio ;
      private string[] P00LA19_A969PostulacionesProveedorNombre ;
      private string[] P00LA19_A943ServiciosNombre ;
      private long[] P00LA19_A942ServiciosId ;
      private bool[] P00LA19_n942ServiciosId ;
      private long[] P00LA19_A422PostulacionesId ;
      private bool[] P00LA19_n422PostulacionesId ;
      private long[] P00LA19_A945PostulacionesProveedorId ;
      private string[] P00LA19_A424PostulacionesEstado ;
      private long[] P00LA19_A970PostulacionesSolicitudesId ;
      private bool[] P00LA19_n970PostulacionesSolicitudesId ;
      private string[] P00LA21_A952PostulacionesTelefono ;
      private long[] P00LA21_A948PostulacionesSecUserId ;
      private DateTime[] P00LA21_A425PostulacionesFechaAlta ;
      private string[] P00LA21_A951PostulacionesMail ;
      private string[] P00LA21_A950PostulacionesApellidoNombre ;
      private string[] P00LA21_A949PostulacionesRgoHoraservicio ;
      private string[] P00LA21_A941PostulacionesTipoFecha ;
      private string[] P00LA21_A940PostulacionesHoraCierre ;
      private DateTime[] P00LA21_A939PostulacionesFechaCierre ;
      private DateTime[] P00LA21_A947PostulacionesFechaTrabajo ;
      private string[] P00LA21_A938PostulacionesSuministrosDescri ;
      private bool[] P00LA21_A937PostulacionesReqSuministros ;
      private string[] P00LA21_A936PostulacionesDescripcion ;
      private short[] P00LA21_A961PostulacionesMultimediaSerial ;
      private decimal[] P00LA21_A946PostulacionesPrecio ;
      private string[] P00LA21_A969PostulacionesProveedorNombre ;
      private string[] P00LA21_A943ServiciosNombre ;
      private long[] P00LA21_A942ServiciosId ;
      private bool[] P00LA21_n942ServiciosId ;
      private long[] P00LA21_A422PostulacionesId ;
      private bool[] P00LA21_n422PostulacionesId ;
      private long[] P00LA21_A945PostulacionesProveedorId ;
      private string[] P00LA21_A424PostulacionesEstado ;
      private long[] P00LA21_A970PostulacionesSolicitudesId ;
      private bool[] P00LA21_n970PostulacionesSolicitudesId ;
      private string aP3_OptionsJson ;
      private string aP4_OptionsDescJson ;
      private string aP5_OptionIndexesJson ;
   }

   public class postulacioneswwgetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00LA3( IGxContext context ,
                                             string A424PostulacionesEstado ,
                                             GxSimpleCollection<string> AV163Postulacioneswwds_58_tfpostulacionesestado_sels ,
                                             string AV107Postulacioneswwds_2_dynamicfiltersselector1 ,
                                             short AV108Postulacioneswwds_3_dynamicfiltersoperator1 ,
                                             string AV109Postulacioneswwds_4_postulacionesproveedornombre1 ,
                                             long AV110Postulacioneswwds_5_postulacionesproveedorid1 ,
                                             string AV111Postulacioneswwds_6_serviciosnombre1 ,
                                             bool AV112Postulacioneswwds_7_dynamicfiltersenabled2 ,
                                             string AV113Postulacioneswwds_8_dynamicfiltersselector2 ,
                                             short AV114Postulacioneswwds_9_dynamicfiltersoperator2 ,
                                             string AV115Postulacioneswwds_10_postulacionesproveedornombre2 ,
                                             long AV116Postulacioneswwds_11_postulacionesproveedorid2 ,
                                             string AV117Postulacioneswwds_12_serviciosnombre2 ,
                                             bool AV118Postulacioneswwds_13_dynamicfiltersenabled3 ,
                                             string AV119Postulacioneswwds_14_dynamicfiltersselector3 ,
                                             short AV120Postulacioneswwds_15_dynamicfiltersoperator3 ,
                                             string AV121Postulacioneswwds_16_postulacionesproveedornombre3 ,
                                             long AV122Postulacioneswwds_17_postulacionesproveedorid3 ,
                                             string AV123Postulacioneswwds_18_serviciosnombre3 ,
                                             long AV124Postulacioneswwds_19_tfpostulacionesid ,
                                             long AV125Postulacioneswwds_20_tfpostulacionesid_to ,
                                             long AV126Postulacioneswwds_21_tfserviciosid ,
                                             long AV127Postulacioneswwds_22_tfserviciosid_to ,
                                             string AV129Postulacioneswwds_24_tfserviciosnombre_sel ,
                                             string AV128Postulacioneswwds_23_tfserviciosnombre ,
                                             long AV130Postulacioneswwds_25_tfpostulacionesproveedorid ,
                                             long AV131Postulacioneswwds_26_tfpostulacionesproveedorid_to ,
                                             string AV133Postulacioneswwds_28_tfpostulacionesproveedornombre_sel ,
                                             string AV132Postulacioneswwds_27_tfpostulacionesproveedornombre ,
                                             decimal AV134Postulacioneswwds_29_tfpostulacionesprecio ,
                                             decimal AV135Postulacioneswwds_30_tfpostulacionesprecio_to ,
                                             short AV136Postulacioneswwds_31_tfpostulacionesmultimediaserial ,
                                             short AV137Postulacioneswwds_32_tfpostulacionesmultimediaserial_to ,
                                             string AV141Postulacioneswwds_36_tfpostulacionesdescripcion_sel ,
                                             string AV140Postulacioneswwds_35_tfpostulacionesdescripcion ,
                                             short AV142Postulacioneswwds_37_tfpostulacionesreqsuministros_sel ,
                                             string AV144Postulacioneswwds_39_tfpostulacionessuministrosdescripcion_sel ,
                                             string AV143Postulacioneswwds_38_tfpostulacionessuministrosdescripcion ,
                                             DateTime AV145Postulacioneswwds_40_tfpostulacionesfechatrabajo ,
                                             DateTime AV146Postulacioneswwds_41_tfpostulacionesfechatrabajo_to ,
                                             DateTime AV147Postulacioneswwds_42_tfpostulacionesfechacierre ,
                                             DateTime AV148Postulacioneswwds_43_tfpostulacionesfechacierre_to ,
                                             string AV150Postulacioneswwds_45_tfpostulacioneshoracierre_sel ,
                                             string AV149Postulacioneswwds_44_tfpostulacioneshoracierre ,
                                             string AV152Postulacioneswwds_47_tfpostulacionestipofecha_sel ,
                                             string AV151Postulacioneswwds_46_tfpostulacionestipofecha ,
                                             string AV154Postulacioneswwds_49_tfpostulacionesrgohoraservicio_sel ,
                                             string AV153Postulacioneswwds_48_tfpostulacionesrgohoraservicio ,
                                             string AV156Postulacioneswwds_51_tfpostulacionesapellidonombre_sel ,
                                             string AV155Postulacioneswwds_50_tfpostulacionesapellidonombre ,
                                             string AV158Postulacioneswwds_53_tfpostulacionesmail_sel ,
                                             string AV157Postulacioneswwds_52_tfpostulacionesmail ,
                                             string AV160Postulacioneswwds_55_tfpostulacionestelefono_sel ,
                                             string AV159Postulacioneswwds_54_tfpostulacionestelefono ,
                                             DateTime AV161Postulacioneswwds_56_tfpostulacionesfechaalta ,
                                             DateTime AV162Postulacioneswwds_57_tfpostulacionesfechaalta_to ,
                                             int AV163Postulacioneswwds_58_tfpostulacionesestado_sels_Count ,
                                             long AV164Postulacioneswwds_59_tfpostulacionessecuserid ,
                                             long AV165Postulacioneswwds_60_tfpostulacionessecuserid_to ,
                                             string A969PostulacionesProveedorNombre ,
                                             long A945PostulacionesProveedorId ,
                                             string A943ServiciosNombre ,
                                             long A422PostulacionesId ,
                                             long A942ServiciosId ,
                                             decimal A946PostulacionesPrecio ,
                                             short A961PostulacionesMultimediaSerial ,
                                             string A936PostulacionesDescripcion ,
                                             bool A937PostulacionesReqSuministros ,
                                             string A938PostulacionesSuministrosDescri ,
                                             DateTime A947PostulacionesFechaTrabajo ,
                                             DateTime A939PostulacionesFechaCierre ,
                                             string A940PostulacionesHoraCierre ,
                                             string A941PostulacionesTipoFecha ,
                                             string A949PostulacionesRgoHoraservicio ,
                                             string A950PostulacionesApellidoNombre ,
                                             string A951PostulacionesMail ,
                                             string A952PostulacionesTelefono ,
                                             DateTime A425PostulacionesFechaAlta ,
                                             long A948PostulacionesSecUserId ,
                                             string AV106Postulacioneswwds_1_filterfulltext ,
                                             long A970PostulacionesSolicitudesId ,
                                             long AV138Postulacioneswwds_33_tfpostulacionessolicitudesid ,
                                             long AV139Postulacioneswwds_34_tfpostulacionessolicitudesid_to )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int2 = new short[64];
         Object[] GXv_Object3 = new Object[2];
         scmdbuf = "SELECT T1.[ServiciosId], T1.[PostulacionesSecUserId], T1.[PostulacionesFechaAlta], T1.[PostulacionesTelefono], T1.[PostulacionesMail], T1.[PostulacionesApellidoNombre], T1.[PostulacionesRgoHoraservicio], T1.[PostulacionesTipoFecha], T1.[PostulacionesHoraCierre], T1.[PostulacionesFechaCierre], T1.[PostulacionesFechaTrabajo], T1.[PostulacionesSuministrosDescri], T1.[PostulacionesReqSuministros], T1.[PostulacionesDescripcion], T1.[PostulacionesMultimediaSerial], T1.[PostulacionesPrecio], T3.[ProveedorNombre] AS PostulacionesProveedorNombre, T2.[ServiciosNombre], T1.[PostulacionesId], T1.[PostulacionesProveedorId] AS PostulacionesProveedorId, T1.[PostulacionesEstado], COALESCE( T4.[PostulacionesSolicitudesId], 0) AS PostulacionesSolicitudesId FROM (([Postulaciones] T1 LEFT JOIN [Servicios] T2 ON T2.[ServiciosId] = T1.[ServiciosId]) INNER JOIN [Proveedor] T3 ON T3.[ProveedorID] = T1.[PostulacionesProveedorId]),  (SELECT MIN([SolicitudesID]) AS PostulacionesSolicitudesId FROM [Solicitudes] WHERE [PostulacionesId] = @PostulacionesId ) T4";
         AddWhere(sWhereString, "((@AV138Postulacioneswwds_33_tfpostulacionessolicitudesid = convert(int, 0)) or ( COALESCE( T4.[PostulacionesSolicitudesId], 0) >= @AV138Postulacioneswwds_33_tfpostulacionessolicitudesid))");
         AddWhere(sWhereString, "((@AV139Postulacioneswwds_34_tfpostulacionessolicitudesid_to = convert(int, 0)) or ( COALESCE( T4.[PostulacionesSolicitudesId], 0) <= @AV139Postulacioneswwds_34_tfpostulacionessolicitudesid_to))");
         if ( ( StringUtil.StrCmp(AV107Postulacioneswwds_2_dynamicfiltersselector1, "POSTULACIONESPROVEEDORNOMBRE") == 0 ) && ( AV108Postulacioneswwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV109Postulacioneswwds_4_postulacionesproveedornombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T3.[ProveedorNombre]) like UPPER(@lV109Postulacioneswwds_4_postulacionesproveedornombre1))");
         }
         else
         {
            GXv_int2[5] = 1;
         }
         if ( ( StringUtil.StrCmp(AV107Postulacioneswwds_2_dynamicfiltersselector1, "POSTULACIONESPROVEEDORNOMBRE") == 0 ) && ( AV108Postulacioneswwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV109Postulacioneswwds_4_postulacionesproveedornombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T3.[ProveedorNombre]) like '%' + UPPER(@lV109Postulacioneswwds_4_postulacionesproveedornombre1))");
         }
         else
         {
            GXv_int2[6] = 1;
         }
         if ( ( StringUtil.StrCmp(AV107Postulacioneswwds_2_dynamicfiltersselector1, "POSTULACIONESPROVEEDORID") == 0 ) && ( AV108Postulacioneswwds_3_dynamicfiltersoperator1 == 0 ) && ( ! (0==AV110Postulacioneswwds_5_postulacionesproveedorid1) ) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesProveedorId] < @AV110Postulacioneswwds_5_postulacionesproveedorid1)");
         }
         else
         {
            GXv_int2[7] = 1;
         }
         if ( ( StringUtil.StrCmp(AV107Postulacioneswwds_2_dynamicfiltersselector1, "POSTULACIONESPROVEEDORID") == 0 ) && ( AV108Postulacioneswwds_3_dynamicfiltersoperator1 == 1 ) && ( ! (0==AV110Postulacioneswwds_5_postulacionesproveedorid1) ) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesProveedorId] = @AV110Postulacioneswwds_5_postulacionesproveedorid1)");
         }
         else
         {
            GXv_int2[8] = 1;
         }
         if ( ( StringUtil.StrCmp(AV107Postulacioneswwds_2_dynamicfiltersselector1, "POSTULACIONESPROVEEDORID") == 0 ) && ( AV108Postulacioneswwds_3_dynamicfiltersoperator1 == 2 ) && ( ! (0==AV110Postulacioneswwds_5_postulacionesproveedorid1) ) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesProveedorId] > @AV110Postulacioneswwds_5_postulacionesproveedorid1)");
         }
         else
         {
            GXv_int2[9] = 1;
         }
         if ( ( StringUtil.StrCmp(AV107Postulacioneswwds_2_dynamicfiltersselector1, "SERVICIOSNOMBRE") == 0 ) && ( AV108Postulacioneswwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV111Postulacioneswwds_6_serviciosnombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ServiciosNombre]) like UPPER(@lV111Postulacioneswwds_6_serviciosnombre1))");
         }
         else
         {
            GXv_int2[10] = 1;
         }
         if ( ( StringUtil.StrCmp(AV107Postulacioneswwds_2_dynamicfiltersselector1, "SERVICIOSNOMBRE") == 0 ) && ( AV108Postulacioneswwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV111Postulacioneswwds_6_serviciosnombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ServiciosNombre]) like '%' + UPPER(@lV111Postulacioneswwds_6_serviciosnombre1))");
         }
         else
         {
            GXv_int2[11] = 1;
         }
         if ( AV112Postulacioneswwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV113Postulacioneswwds_8_dynamicfiltersselector2, "POSTULACIONESPROVEEDORNOMBRE") == 0 ) && ( AV114Postulacioneswwds_9_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV115Postulacioneswwds_10_postulacionesproveedornombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T3.[ProveedorNombre]) like UPPER(@lV115Postulacioneswwds_10_postulacionesproveedornombre2))");
         }
         else
         {
            GXv_int2[12] = 1;
         }
         if ( AV112Postulacioneswwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV113Postulacioneswwds_8_dynamicfiltersselector2, "POSTULACIONESPROVEEDORNOMBRE") == 0 ) && ( AV114Postulacioneswwds_9_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV115Postulacioneswwds_10_postulacionesproveedornombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T3.[ProveedorNombre]) like '%' + UPPER(@lV115Postulacioneswwds_10_postulacionesproveedornombre2))");
         }
         else
         {
            GXv_int2[13] = 1;
         }
         if ( AV112Postulacioneswwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV113Postulacioneswwds_8_dynamicfiltersselector2, "POSTULACIONESPROVEEDORID") == 0 ) && ( AV114Postulacioneswwds_9_dynamicfiltersoperator2 == 0 ) && ( ! (0==AV116Postulacioneswwds_11_postulacionesproveedorid2) ) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesProveedorId] < @AV116Postulacioneswwds_11_postulacionesproveedorid2)");
         }
         else
         {
            GXv_int2[14] = 1;
         }
         if ( AV112Postulacioneswwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV113Postulacioneswwds_8_dynamicfiltersselector2, "POSTULACIONESPROVEEDORID") == 0 ) && ( AV114Postulacioneswwds_9_dynamicfiltersoperator2 == 1 ) && ( ! (0==AV116Postulacioneswwds_11_postulacionesproveedorid2) ) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesProveedorId] = @AV116Postulacioneswwds_11_postulacionesproveedorid2)");
         }
         else
         {
            GXv_int2[15] = 1;
         }
         if ( AV112Postulacioneswwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV113Postulacioneswwds_8_dynamicfiltersselector2, "POSTULACIONESPROVEEDORID") == 0 ) && ( AV114Postulacioneswwds_9_dynamicfiltersoperator2 == 2 ) && ( ! (0==AV116Postulacioneswwds_11_postulacionesproveedorid2) ) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesProveedorId] > @AV116Postulacioneswwds_11_postulacionesproveedorid2)");
         }
         else
         {
            GXv_int2[16] = 1;
         }
         if ( AV112Postulacioneswwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV113Postulacioneswwds_8_dynamicfiltersselector2, "SERVICIOSNOMBRE") == 0 ) && ( AV114Postulacioneswwds_9_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV117Postulacioneswwds_12_serviciosnombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ServiciosNombre]) like UPPER(@lV117Postulacioneswwds_12_serviciosnombre2))");
         }
         else
         {
            GXv_int2[17] = 1;
         }
         if ( AV112Postulacioneswwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV113Postulacioneswwds_8_dynamicfiltersselector2, "SERVICIOSNOMBRE") == 0 ) && ( AV114Postulacioneswwds_9_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV117Postulacioneswwds_12_serviciosnombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ServiciosNombre]) like '%' + UPPER(@lV117Postulacioneswwds_12_serviciosnombre2))");
         }
         else
         {
            GXv_int2[18] = 1;
         }
         if ( AV118Postulacioneswwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV119Postulacioneswwds_14_dynamicfiltersselector3, "POSTULACIONESPROVEEDORNOMBRE") == 0 ) && ( AV120Postulacioneswwds_15_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV121Postulacioneswwds_16_postulacionesproveedornombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T3.[ProveedorNombre]) like UPPER(@lV121Postulacioneswwds_16_postulacionesproveedornombre3))");
         }
         else
         {
            GXv_int2[19] = 1;
         }
         if ( AV118Postulacioneswwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV119Postulacioneswwds_14_dynamicfiltersselector3, "POSTULACIONESPROVEEDORNOMBRE") == 0 ) && ( AV120Postulacioneswwds_15_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV121Postulacioneswwds_16_postulacionesproveedornombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T3.[ProveedorNombre]) like '%' + UPPER(@lV121Postulacioneswwds_16_postulacionesproveedornombre3))");
         }
         else
         {
            GXv_int2[20] = 1;
         }
         if ( AV118Postulacioneswwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV119Postulacioneswwds_14_dynamicfiltersselector3, "POSTULACIONESPROVEEDORID") == 0 ) && ( AV120Postulacioneswwds_15_dynamicfiltersoperator3 == 0 ) && ( ! (0==AV122Postulacioneswwds_17_postulacionesproveedorid3) ) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesProveedorId] < @AV122Postulacioneswwds_17_postulacionesproveedorid3)");
         }
         else
         {
            GXv_int2[21] = 1;
         }
         if ( AV118Postulacioneswwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV119Postulacioneswwds_14_dynamicfiltersselector3, "POSTULACIONESPROVEEDORID") == 0 ) && ( AV120Postulacioneswwds_15_dynamicfiltersoperator3 == 1 ) && ( ! (0==AV122Postulacioneswwds_17_postulacionesproveedorid3) ) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesProveedorId] = @AV122Postulacioneswwds_17_postulacionesproveedorid3)");
         }
         else
         {
            GXv_int2[22] = 1;
         }
         if ( AV118Postulacioneswwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV119Postulacioneswwds_14_dynamicfiltersselector3, "POSTULACIONESPROVEEDORID") == 0 ) && ( AV120Postulacioneswwds_15_dynamicfiltersoperator3 == 2 ) && ( ! (0==AV122Postulacioneswwds_17_postulacionesproveedorid3) ) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesProveedorId] > @AV122Postulacioneswwds_17_postulacionesproveedorid3)");
         }
         else
         {
            GXv_int2[23] = 1;
         }
         if ( AV118Postulacioneswwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV119Postulacioneswwds_14_dynamicfiltersselector3, "SERVICIOSNOMBRE") == 0 ) && ( AV120Postulacioneswwds_15_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV123Postulacioneswwds_18_serviciosnombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ServiciosNombre]) like UPPER(@lV123Postulacioneswwds_18_serviciosnombre3))");
         }
         else
         {
            GXv_int2[24] = 1;
         }
         if ( AV118Postulacioneswwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV119Postulacioneswwds_14_dynamicfiltersselector3, "SERVICIOSNOMBRE") == 0 ) && ( AV120Postulacioneswwds_15_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV123Postulacioneswwds_18_serviciosnombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ServiciosNombre]) like '%' + UPPER(@lV123Postulacioneswwds_18_serviciosnombre3))");
         }
         else
         {
            GXv_int2[25] = 1;
         }
         if ( ! (0==AV124Postulacioneswwds_19_tfpostulacionesid) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesId] >= @AV124Postulacioneswwds_19_tfpostulacionesid)");
         }
         else
         {
            GXv_int2[26] = 1;
         }
         if ( ! (0==AV125Postulacioneswwds_20_tfpostulacionesid_to) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesId] <= @AV125Postulacioneswwds_20_tfpostulacionesid_to)");
         }
         else
         {
            GXv_int2[27] = 1;
         }
         if ( ! (0==AV126Postulacioneswwds_21_tfserviciosid) )
         {
            AddWhere(sWhereString, "(T1.[ServiciosId] >= @AV126Postulacioneswwds_21_tfserviciosid)");
         }
         else
         {
            GXv_int2[28] = 1;
         }
         if ( ! (0==AV127Postulacioneswwds_22_tfserviciosid_to) )
         {
            AddWhere(sWhereString, "(T1.[ServiciosId] <= @AV127Postulacioneswwds_22_tfserviciosid_to)");
         }
         else
         {
            GXv_int2[29] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV129Postulacioneswwds_24_tfserviciosnombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV128Postulacioneswwds_23_tfserviciosnombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ServiciosNombre]) like UPPER(@lV128Postulacioneswwds_23_tfserviciosnombre))");
         }
         else
         {
            GXv_int2[30] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV129Postulacioneswwds_24_tfserviciosnombre_sel)) && ! ( StringUtil.StrCmp(AV129Postulacioneswwds_24_tfserviciosnombre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.[ServiciosNombre] = @AV129Postulacioneswwds_24_tfserviciosnombre_sel)");
         }
         else
         {
            GXv_int2[31] = 1;
         }
         if ( StringUtil.StrCmp(AV129Postulacioneswwds_24_tfserviciosnombre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T2.[ServiciosNombre] IS NULL or (T2.[ServiciosNombre] = ''))");
         }
         if ( ! (0==AV130Postulacioneswwds_25_tfpostulacionesproveedorid) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesProveedorId] >= @AV130Postulacioneswwds_25_tfpostulacionesproveedorid)");
         }
         else
         {
            GXv_int2[32] = 1;
         }
         if ( ! (0==AV131Postulacioneswwds_26_tfpostulacionesproveedorid_to) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesProveedorId] <= @AV131Postulacioneswwds_26_tfpostulacionesproveedorid_to)");
         }
         else
         {
            GXv_int2[33] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV133Postulacioneswwds_28_tfpostulacionesproveedornombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV132Postulacioneswwds_27_tfpostulacionesproveedornombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T3.[ProveedorNombre]) like UPPER(@lV132Postulacioneswwds_27_tfpostulacionesproveedornombre))");
         }
         else
         {
            GXv_int2[34] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV133Postulacioneswwds_28_tfpostulacionesproveedornombre_sel)) && ! ( StringUtil.StrCmp(AV133Postulacioneswwds_28_tfpostulacionesproveedornombre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T3.[ProveedorNombre] = @AV133Postulacioneswwds_28_tfpostulacionesproveedornombre_sel)");
         }
         else
         {
            GXv_int2[35] = 1;
         }
         if ( StringUtil.StrCmp(AV133Postulacioneswwds_28_tfpostulacionesproveedornombre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T3.[ProveedorNombre] = ''))");
         }
         if ( ! (Convert.ToDecimal(0)==AV134Postulacioneswwds_29_tfpostulacionesprecio) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesPrecio] >= @AV134Postulacioneswwds_29_tfpostulacionesprecio)");
         }
         else
         {
            GXv_int2[36] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV135Postulacioneswwds_30_tfpostulacionesprecio_to) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesPrecio] <= @AV135Postulacioneswwds_30_tfpostulacionesprecio_to)");
         }
         else
         {
            GXv_int2[37] = 1;
         }
         if ( ! (0==AV136Postulacioneswwds_31_tfpostulacionesmultimediaserial) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesMultimediaSerial] >= @AV136Postulacioneswwds_31_tfpostulacionesmultimediaserial)");
         }
         else
         {
            GXv_int2[38] = 1;
         }
         if ( ! (0==AV137Postulacioneswwds_32_tfpostulacionesmultimediaserial_to) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesMultimediaSerial] <= @AV137Postulacioneswwds_32_tfpostulacionesmultimediaserial_to)");
         }
         else
         {
            GXv_int2[39] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV141Postulacioneswwds_36_tfpostulacionesdescripcion_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV140Postulacioneswwds_35_tfpostulacionesdescripcion)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[PostulacionesDescripcion]) like UPPER(@lV140Postulacioneswwds_35_tfpostulacionesdescripcion))");
         }
         else
         {
            GXv_int2[40] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV141Postulacioneswwds_36_tfpostulacionesdescripcion_sel)) && ! ( StringUtil.StrCmp(AV141Postulacioneswwds_36_tfpostulacionesdescripcion_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesDescripcion] = @AV141Postulacioneswwds_36_tfpostulacionesdescripcion_sel)");
         }
         else
         {
            GXv_int2[41] = 1;
         }
         if ( StringUtil.StrCmp(AV141Postulacioneswwds_36_tfpostulacionesdescripcion_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[PostulacionesDescripcion] = ''))");
         }
         if ( AV142Postulacioneswwds_37_tfpostulacionesreqsuministros_sel == 1 )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesReqSuministros] = 1)");
         }
         if ( AV142Postulacioneswwds_37_tfpostulacionesreqsuministros_sel == 2 )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesReqSuministros] = 0)");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV144Postulacioneswwds_39_tfpostulacionessuministrosdescripcion_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV143Postulacioneswwds_38_tfpostulacionessuministrosdescripcion)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[PostulacionesSuministrosDescri]) like UPPER(@lV143Postulacioneswwds_38_tfpostulacionessuministrosdescripcion))");
         }
         else
         {
            GXv_int2[42] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV144Postulacioneswwds_39_tfpostulacionessuministrosdescripcion_sel)) && ! ( StringUtil.StrCmp(AV144Postulacioneswwds_39_tfpostulacionessuministrosdescripcion_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesSuministrosDescri] = @AV144Postulacioneswwds_39_tfpostulacionessuministrosdescripcion_sel)");
         }
         else
         {
            GXv_int2[43] = 1;
         }
         if ( StringUtil.StrCmp(AV144Postulacioneswwds_39_tfpostulacionessuministrosdescripcion_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[PostulacionesSuministrosDescri] = ''))");
         }
         if ( ! (DateTime.MinValue==AV145Postulacioneswwds_40_tfpostulacionesfechatrabajo) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesFechaTrabajo] >= @AV145Postulacioneswwds_40_tfpostulacionesfechatrabajo)");
         }
         else
         {
            GXv_int2[44] = 1;
         }
         if ( ! (DateTime.MinValue==AV146Postulacioneswwds_41_tfpostulacionesfechatrabajo_to) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesFechaTrabajo] <= @AV146Postulacioneswwds_41_tfpostulacionesfechatrabajo_to)");
         }
         else
         {
            GXv_int2[45] = 1;
         }
         if ( ! (DateTime.MinValue==AV147Postulacioneswwds_42_tfpostulacionesfechacierre) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesFechaCierre] >= @AV147Postulacioneswwds_42_tfpostulacionesfechacierre)");
         }
         else
         {
            GXv_int2[46] = 1;
         }
         if ( ! (DateTime.MinValue==AV148Postulacioneswwds_43_tfpostulacionesfechacierre_to) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesFechaCierre] <= @AV148Postulacioneswwds_43_tfpostulacionesfechacierre_to)");
         }
         else
         {
            GXv_int2[47] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV150Postulacioneswwds_45_tfpostulacioneshoracierre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV149Postulacioneswwds_44_tfpostulacioneshoracierre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[PostulacionesHoraCierre]) like UPPER(@lV149Postulacioneswwds_44_tfpostulacioneshoracierre))");
         }
         else
         {
            GXv_int2[48] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV150Postulacioneswwds_45_tfpostulacioneshoracierre_sel)) && ! ( StringUtil.StrCmp(AV150Postulacioneswwds_45_tfpostulacioneshoracierre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesHoraCierre] = @AV150Postulacioneswwds_45_tfpostulacioneshoracierre_sel)");
         }
         else
         {
            GXv_int2[49] = 1;
         }
         if ( StringUtil.StrCmp(AV150Postulacioneswwds_45_tfpostulacioneshoracierre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[PostulacionesHoraCierre] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV152Postulacioneswwds_47_tfpostulacionestipofecha_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV151Postulacioneswwds_46_tfpostulacionestipofecha)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[PostulacionesTipoFecha]) like UPPER(@lV151Postulacioneswwds_46_tfpostulacionestipofecha))");
         }
         else
         {
            GXv_int2[50] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV152Postulacioneswwds_47_tfpostulacionestipofecha_sel)) && ! ( StringUtil.StrCmp(AV152Postulacioneswwds_47_tfpostulacionestipofecha_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesTipoFecha] = @AV152Postulacioneswwds_47_tfpostulacionestipofecha_sel)");
         }
         else
         {
            GXv_int2[51] = 1;
         }
         if ( StringUtil.StrCmp(AV152Postulacioneswwds_47_tfpostulacionestipofecha_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[PostulacionesTipoFecha] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV154Postulacioneswwds_49_tfpostulacionesrgohoraservicio_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV153Postulacioneswwds_48_tfpostulacionesrgohoraservicio)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[PostulacionesRgoHoraservicio]) like UPPER(@lV153Postulacioneswwds_48_tfpostulacionesrgohoraservicio))");
         }
         else
         {
            GXv_int2[52] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV154Postulacioneswwds_49_tfpostulacionesrgohoraservicio_sel)) && ! ( StringUtil.StrCmp(AV154Postulacioneswwds_49_tfpostulacionesrgohoraservicio_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesRgoHoraservicio] = @AV154Postulacioneswwds_49_tfpostulacionesrgohoraservicio_sel)");
         }
         else
         {
            GXv_int2[53] = 1;
         }
         if ( StringUtil.StrCmp(AV154Postulacioneswwds_49_tfpostulacionesrgohoraservicio_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[PostulacionesRgoHoraservicio] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV156Postulacioneswwds_51_tfpostulacionesapellidonombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV155Postulacioneswwds_50_tfpostulacionesapellidonombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[PostulacionesApellidoNombre]) like UPPER(@lV155Postulacioneswwds_50_tfpostulacionesapellidonombre))");
         }
         else
         {
            GXv_int2[54] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV156Postulacioneswwds_51_tfpostulacionesapellidonombre_sel)) && ! ( StringUtil.StrCmp(AV156Postulacioneswwds_51_tfpostulacionesapellidonombre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesApellidoNombre] = @AV156Postulacioneswwds_51_tfpostulacionesapellidonombre_sel)");
         }
         else
         {
            GXv_int2[55] = 1;
         }
         if ( StringUtil.StrCmp(AV156Postulacioneswwds_51_tfpostulacionesapellidonombre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[PostulacionesApellidoNombre] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV158Postulacioneswwds_53_tfpostulacionesmail_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV157Postulacioneswwds_52_tfpostulacionesmail)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[PostulacionesMail]) like UPPER(@lV157Postulacioneswwds_52_tfpostulacionesmail))");
         }
         else
         {
            GXv_int2[56] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV158Postulacioneswwds_53_tfpostulacionesmail_sel)) && ! ( StringUtil.StrCmp(AV158Postulacioneswwds_53_tfpostulacionesmail_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesMail] = @AV158Postulacioneswwds_53_tfpostulacionesmail_sel)");
         }
         else
         {
            GXv_int2[57] = 1;
         }
         if ( StringUtil.StrCmp(AV158Postulacioneswwds_53_tfpostulacionesmail_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[PostulacionesMail] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV160Postulacioneswwds_55_tfpostulacionestelefono_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV159Postulacioneswwds_54_tfpostulacionestelefono)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[PostulacionesTelefono]) like UPPER(@lV159Postulacioneswwds_54_tfpostulacionestelefono))");
         }
         else
         {
            GXv_int2[58] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV160Postulacioneswwds_55_tfpostulacionestelefono_sel)) && ! ( StringUtil.StrCmp(AV160Postulacioneswwds_55_tfpostulacionestelefono_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesTelefono] = @AV160Postulacioneswwds_55_tfpostulacionestelefono_sel)");
         }
         else
         {
            GXv_int2[59] = 1;
         }
         if ( StringUtil.StrCmp(AV160Postulacioneswwds_55_tfpostulacionestelefono_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[PostulacionesTelefono] = ''))");
         }
         if ( ! (DateTime.MinValue==AV161Postulacioneswwds_56_tfpostulacionesfechaalta) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesFechaAlta] >= @AV161Postulacioneswwds_56_tfpostulacionesfechaalta)");
         }
         else
         {
            GXv_int2[60] = 1;
         }
         if ( ! (DateTime.MinValue==AV162Postulacioneswwds_57_tfpostulacionesfechaalta_to) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesFechaAlta] <= @AV162Postulacioneswwds_57_tfpostulacionesfechaalta_to)");
         }
         else
         {
            GXv_int2[61] = 1;
         }
         if ( AV163Postulacioneswwds_58_tfpostulacionesestado_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV163Postulacioneswwds_58_tfpostulacionesestado_sels, "T1.[PostulacionesEstado] IN (", ")")+")");
         }
         if ( ! (0==AV164Postulacioneswwds_59_tfpostulacionessecuserid) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesSecUserId] >= @AV164Postulacioneswwds_59_tfpostulacionessecuserid)");
         }
         else
         {
            GXv_int2[62] = 1;
         }
         if ( ! (0==AV165Postulacioneswwds_60_tfpostulacionessecuserid_to) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesSecUserId] <= @AV165Postulacioneswwds_60_tfpostulacionessecuserid_to)");
         }
         else
         {
            GXv_int2[63] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[ServiciosId]";
         GXv_Object3[0] = scmdbuf;
         GXv_Object3[1] = GXv_int2;
         return GXv_Object3 ;
      }

      protected Object[] conditional_P00LA5( IGxContext context ,
                                             string A424PostulacionesEstado ,
                                             GxSimpleCollection<string> AV163Postulacioneswwds_58_tfpostulacionesestado_sels ,
                                             string AV107Postulacioneswwds_2_dynamicfiltersselector1 ,
                                             short AV108Postulacioneswwds_3_dynamicfiltersoperator1 ,
                                             string AV109Postulacioneswwds_4_postulacionesproveedornombre1 ,
                                             long AV110Postulacioneswwds_5_postulacionesproveedorid1 ,
                                             string AV111Postulacioneswwds_6_serviciosnombre1 ,
                                             bool AV112Postulacioneswwds_7_dynamicfiltersenabled2 ,
                                             string AV113Postulacioneswwds_8_dynamicfiltersselector2 ,
                                             short AV114Postulacioneswwds_9_dynamicfiltersoperator2 ,
                                             string AV115Postulacioneswwds_10_postulacionesproveedornombre2 ,
                                             long AV116Postulacioneswwds_11_postulacionesproveedorid2 ,
                                             string AV117Postulacioneswwds_12_serviciosnombre2 ,
                                             bool AV118Postulacioneswwds_13_dynamicfiltersenabled3 ,
                                             string AV119Postulacioneswwds_14_dynamicfiltersselector3 ,
                                             short AV120Postulacioneswwds_15_dynamicfiltersoperator3 ,
                                             string AV121Postulacioneswwds_16_postulacionesproveedornombre3 ,
                                             long AV122Postulacioneswwds_17_postulacionesproveedorid3 ,
                                             string AV123Postulacioneswwds_18_serviciosnombre3 ,
                                             long AV124Postulacioneswwds_19_tfpostulacionesid ,
                                             long AV125Postulacioneswwds_20_tfpostulacionesid_to ,
                                             long AV126Postulacioneswwds_21_tfserviciosid ,
                                             long AV127Postulacioneswwds_22_tfserviciosid_to ,
                                             string AV129Postulacioneswwds_24_tfserviciosnombre_sel ,
                                             string AV128Postulacioneswwds_23_tfserviciosnombre ,
                                             long AV130Postulacioneswwds_25_tfpostulacionesproveedorid ,
                                             long AV131Postulacioneswwds_26_tfpostulacionesproveedorid_to ,
                                             string AV133Postulacioneswwds_28_tfpostulacionesproveedornombre_sel ,
                                             string AV132Postulacioneswwds_27_tfpostulacionesproveedornombre ,
                                             decimal AV134Postulacioneswwds_29_tfpostulacionesprecio ,
                                             decimal AV135Postulacioneswwds_30_tfpostulacionesprecio_to ,
                                             short AV136Postulacioneswwds_31_tfpostulacionesmultimediaserial ,
                                             short AV137Postulacioneswwds_32_tfpostulacionesmultimediaserial_to ,
                                             string AV141Postulacioneswwds_36_tfpostulacionesdescripcion_sel ,
                                             string AV140Postulacioneswwds_35_tfpostulacionesdescripcion ,
                                             short AV142Postulacioneswwds_37_tfpostulacionesreqsuministros_sel ,
                                             string AV144Postulacioneswwds_39_tfpostulacionessuministrosdescripcion_sel ,
                                             string AV143Postulacioneswwds_38_tfpostulacionessuministrosdescripcion ,
                                             DateTime AV145Postulacioneswwds_40_tfpostulacionesfechatrabajo ,
                                             DateTime AV146Postulacioneswwds_41_tfpostulacionesfechatrabajo_to ,
                                             DateTime AV147Postulacioneswwds_42_tfpostulacionesfechacierre ,
                                             DateTime AV148Postulacioneswwds_43_tfpostulacionesfechacierre_to ,
                                             string AV150Postulacioneswwds_45_tfpostulacioneshoracierre_sel ,
                                             string AV149Postulacioneswwds_44_tfpostulacioneshoracierre ,
                                             string AV152Postulacioneswwds_47_tfpostulacionestipofecha_sel ,
                                             string AV151Postulacioneswwds_46_tfpostulacionestipofecha ,
                                             string AV154Postulacioneswwds_49_tfpostulacionesrgohoraservicio_sel ,
                                             string AV153Postulacioneswwds_48_tfpostulacionesrgohoraservicio ,
                                             string AV156Postulacioneswwds_51_tfpostulacionesapellidonombre_sel ,
                                             string AV155Postulacioneswwds_50_tfpostulacionesapellidonombre ,
                                             string AV158Postulacioneswwds_53_tfpostulacionesmail_sel ,
                                             string AV157Postulacioneswwds_52_tfpostulacionesmail ,
                                             string AV160Postulacioneswwds_55_tfpostulacionestelefono_sel ,
                                             string AV159Postulacioneswwds_54_tfpostulacionestelefono ,
                                             DateTime AV161Postulacioneswwds_56_tfpostulacionesfechaalta ,
                                             DateTime AV162Postulacioneswwds_57_tfpostulacionesfechaalta_to ,
                                             int AV163Postulacioneswwds_58_tfpostulacionesestado_sels_Count ,
                                             long AV164Postulacioneswwds_59_tfpostulacionessecuserid ,
                                             long AV165Postulacioneswwds_60_tfpostulacionessecuserid_to ,
                                             string A969PostulacionesProveedorNombre ,
                                             long A945PostulacionesProveedorId ,
                                             string A943ServiciosNombre ,
                                             long A422PostulacionesId ,
                                             long A942ServiciosId ,
                                             decimal A946PostulacionesPrecio ,
                                             short A961PostulacionesMultimediaSerial ,
                                             string A936PostulacionesDescripcion ,
                                             bool A937PostulacionesReqSuministros ,
                                             string A938PostulacionesSuministrosDescri ,
                                             DateTime A947PostulacionesFechaTrabajo ,
                                             DateTime A939PostulacionesFechaCierre ,
                                             string A940PostulacionesHoraCierre ,
                                             string A941PostulacionesTipoFecha ,
                                             string A949PostulacionesRgoHoraservicio ,
                                             string A950PostulacionesApellidoNombre ,
                                             string A951PostulacionesMail ,
                                             string A952PostulacionesTelefono ,
                                             DateTime A425PostulacionesFechaAlta ,
                                             long A948PostulacionesSecUserId ,
                                             string AV106Postulacioneswwds_1_filterfulltext ,
                                             long A970PostulacionesSolicitudesId ,
                                             long AV138Postulacioneswwds_33_tfpostulacionessolicitudesid ,
                                             long AV139Postulacioneswwds_34_tfpostulacionessolicitudesid_to )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int4 = new short[64];
         Object[] GXv_Object5 = new Object[2];
         scmdbuf = "SELECT T1.[PostulacionesProveedorId] AS PostulacionesProveedorId, T1.[PostulacionesSecUserId], T1.[PostulacionesFechaAlta], T1.[PostulacionesTelefono], T1.[PostulacionesMail], T1.[PostulacionesApellidoNombre], T1.[PostulacionesRgoHoraservicio], T1.[PostulacionesTipoFecha], T1.[PostulacionesHoraCierre], T1.[PostulacionesFechaCierre], T1.[PostulacionesFechaTrabajo], T1.[PostulacionesSuministrosDescri], T1.[PostulacionesReqSuministros], T1.[PostulacionesDescripcion], T1.[PostulacionesMultimediaSerial], T1.[PostulacionesPrecio], T2.[ProveedorNombre] AS PostulacionesProveedorNombre, T3.[ServiciosNombre], T1.[ServiciosId], T1.[PostulacionesId], T1.[PostulacionesEstado], COALESCE( T4.[PostulacionesSolicitudesId], 0) AS PostulacionesSolicitudesId FROM (([Postulaciones] T1 INNER JOIN [Proveedor] T2 ON T2.[ProveedorID] = T1.[PostulacionesProveedorId]) LEFT JOIN [Servicios] T3 ON T3.[ServiciosId] = T1.[ServiciosId]),  (SELECT MIN([SolicitudesID]) AS PostulacionesSolicitudesId FROM [Solicitudes] WHERE [PostulacionesId] = @PostulacionesId ) T4";
         AddWhere(sWhereString, "((@AV138Postulacioneswwds_33_tfpostulacionessolicitudesid = convert(int, 0)) or ( COALESCE( T4.[PostulacionesSolicitudesId], 0) >= @AV138Postulacioneswwds_33_tfpostulacionessolicitudesid))");
         AddWhere(sWhereString, "((@AV139Postulacioneswwds_34_tfpostulacionessolicitudesid_to = convert(int, 0)) or ( COALESCE( T4.[PostulacionesSolicitudesId], 0) <= @AV139Postulacioneswwds_34_tfpostulacionessolicitudesid_to))");
         if ( ( StringUtil.StrCmp(AV107Postulacioneswwds_2_dynamicfiltersselector1, "POSTULACIONESPROVEEDORNOMBRE") == 0 ) && ( AV108Postulacioneswwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV109Postulacioneswwds_4_postulacionesproveedornombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ProveedorNombre]) like UPPER(@lV109Postulacioneswwds_4_postulacionesproveedornombre1))");
         }
         else
         {
            GXv_int4[5] = 1;
         }
         if ( ( StringUtil.StrCmp(AV107Postulacioneswwds_2_dynamicfiltersselector1, "POSTULACIONESPROVEEDORNOMBRE") == 0 ) && ( AV108Postulacioneswwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV109Postulacioneswwds_4_postulacionesproveedornombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ProveedorNombre]) like '%' + UPPER(@lV109Postulacioneswwds_4_postulacionesproveedornombre1))");
         }
         else
         {
            GXv_int4[6] = 1;
         }
         if ( ( StringUtil.StrCmp(AV107Postulacioneswwds_2_dynamicfiltersselector1, "POSTULACIONESPROVEEDORID") == 0 ) && ( AV108Postulacioneswwds_3_dynamicfiltersoperator1 == 0 ) && ( ! (0==AV110Postulacioneswwds_5_postulacionesproveedorid1) ) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesProveedorId] < @AV110Postulacioneswwds_5_postulacionesproveedorid1)");
         }
         else
         {
            GXv_int4[7] = 1;
         }
         if ( ( StringUtil.StrCmp(AV107Postulacioneswwds_2_dynamicfiltersselector1, "POSTULACIONESPROVEEDORID") == 0 ) && ( AV108Postulacioneswwds_3_dynamicfiltersoperator1 == 1 ) && ( ! (0==AV110Postulacioneswwds_5_postulacionesproveedorid1) ) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesProveedorId] = @AV110Postulacioneswwds_5_postulacionesproveedorid1)");
         }
         else
         {
            GXv_int4[8] = 1;
         }
         if ( ( StringUtil.StrCmp(AV107Postulacioneswwds_2_dynamicfiltersselector1, "POSTULACIONESPROVEEDORID") == 0 ) && ( AV108Postulacioneswwds_3_dynamicfiltersoperator1 == 2 ) && ( ! (0==AV110Postulacioneswwds_5_postulacionesproveedorid1) ) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesProveedorId] > @AV110Postulacioneswwds_5_postulacionesproveedorid1)");
         }
         else
         {
            GXv_int4[9] = 1;
         }
         if ( ( StringUtil.StrCmp(AV107Postulacioneswwds_2_dynamicfiltersselector1, "SERVICIOSNOMBRE") == 0 ) && ( AV108Postulacioneswwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV111Postulacioneswwds_6_serviciosnombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T3.[ServiciosNombre]) like UPPER(@lV111Postulacioneswwds_6_serviciosnombre1))");
         }
         else
         {
            GXv_int4[10] = 1;
         }
         if ( ( StringUtil.StrCmp(AV107Postulacioneswwds_2_dynamicfiltersselector1, "SERVICIOSNOMBRE") == 0 ) && ( AV108Postulacioneswwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV111Postulacioneswwds_6_serviciosnombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T3.[ServiciosNombre]) like '%' + UPPER(@lV111Postulacioneswwds_6_serviciosnombre1))");
         }
         else
         {
            GXv_int4[11] = 1;
         }
         if ( AV112Postulacioneswwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV113Postulacioneswwds_8_dynamicfiltersselector2, "POSTULACIONESPROVEEDORNOMBRE") == 0 ) && ( AV114Postulacioneswwds_9_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV115Postulacioneswwds_10_postulacionesproveedornombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ProveedorNombre]) like UPPER(@lV115Postulacioneswwds_10_postulacionesproveedornombre2))");
         }
         else
         {
            GXv_int4[12] = 1;
         }
         if ( AV112Postulacioneswwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV113Postulacioneswwds_8_dynamicfiltersselector2, "POSTULACIONESPROVEEDORNOMBRE") == 0 ) && ( AV114Postulacioneswwds_9_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV115Postulacioneswwds_10_postulacionesproveedornombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ProveedorNombre]) like '%' + UPPER(@lV115Postulacioneswwds_10_postulacionesproveedornombre2))");
         }
         else
         {
            GXv_int4[13] = 1;
         }
         if ( AV112Postulacioneswwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV113Postulacioneswwds_8_dynamicfiltersselector2, "POSTULACIONESPROVEEDORID") == 0 ) && ( AV114Postulacioneswwds_9_dynamicfiltersoperator2 == 0 ) && ( ! (0==AV116Postulacioneswwds_11_postulacionesproveedorid2) ) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesProveedorId] < @AV116Postulacioneswwds_11_postulacionesproveedorid2)");
         }
         else
         {
            GXv_int4[14] = 1;
         }
         if ( AV112Postulacioneswwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV113Postulacioneswwds_8_dynamicfiltersselector2, "POSTULACIONESPROVEEDORID") == 0 ) && ( AV114Postulacioneswwds_9_dynamicfiltersoperator2 == 1 ) && ( ! (0==AV116Postulacioneswwds_11_postulacionesproveedorid2) ) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesProveedorId] = @AV116Postulacioneswwds_11_postulacionesproveedorid2)");
         }
         else
         {
            GXv_int4[15] = 1;
         }
         if ( AV112Postulacioneswwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV113Postulacioneswwds_8_dynamicfiltersselector2, "POSTULACIONESPROVEEDORID") == 0 ) && ( AV114Postulacioneswwds_9_dynamicfiltersoperator2 == 2 ) && ( ! (0==AV116Postulacioneswwds_11_postulacionesproveedorid2) ) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesProveedorId] > @AV116Postulacioneswwds_11_postulacionesproveedorid2)");
         }
         else
         {
            GXv_int4[16] = 1;
         }
         if ( AV112Postulacioneswwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV113Postulacioneswwds_8_dynamicfiltersselector2, "SERVICIOSNOMBRE") == 0 ) && ( AV114Postulacioneswwds_9_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV117Postulacioneswwds_12_serviciosnombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T3.[ServiciosNombre]) like UPPER(@lV117Postulacioneswwds_12_serviciosnombre2))");
         }
         else
         {
            GXv_int4[17] = 1;
         }
         if ( AV112Postulacioneswwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV113Postulacioneswwds_8_dynamicfiltersselector2, "SERVICIOSNOMBRE") == 0 ) && ( AV114Postulacioneswwds_9_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV117Postulacioneswwds_12_serviciosnombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T3.[ServiciosNombre]) like '%' + UPPER(@lV117Postulacioneswwds_12_serviciosnombre2))");
         }
         else
         {
            GXv_int4[18] = 1;
         }
         if ( AV118Postulacioneswwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV119Postulacioneswwds_14_dynamicfiltersselector3, "POSTULACIONESPROVEEDORNOMBRE") == 0 ) && ( AV120Postulacioneswwds_15_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV121Postulacioneswwds_16_postulacionesproveedornombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ProveedorNombre]) like UPPER(@lV121Postulacioneswwds_16_postulacionesproveedornombre3))");
         }
         else
         {
            GXv_int4[19] = 1;
         }
         if ( AV118Postulacioneswwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV119Postulacioneswwds_14_dynamicfiltersselector3, "POSTULACIONESPROVEEDORNOMBRE") == 0 ) && ( AV120Postulacioneswwds_15_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV121Postulacioneswwds_16_postulacionesproveedornombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ProveedorNombre]) like '%' + UPPER(@lV121Postulacioneswwds_16_postulacionesproveedornombre3))");
         }
         else
         {
            GXv_int4[20] = 1;
         }
         if ( AV118Postulacioneswwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV119Postulacioneswwds_14_dynamicfiltersselector3, "POSTULACIONESPROVEEDORID") == 0 ) && ( AV120Postulacioneswwds_15_dynamicfiltersoperator3 == 0 ) && ( ! (0==AV122Postulacioneswwds_17_postulacionesproveedorid3) ) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesProveedorId] < @AV122Postulacioneswwds_17_postulacionesproveedorid3)");
         }
         else
         {
            GXv_int4[21] = 1;
         }
         if ( AV118Postulacioneswwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV119Postulacioneswwds_14_dynamicfiltersselector3, "POSTULACIONESPROVEEDORID") == 0 ) && ( AV120Postulacioneswwds_15_dynamicfiltersoperator3 == 1 ) && ( ! (0==AV122Postulacioneswwds_17_postulacionesproveedorid3) ) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesProveedorId] = @AV122Postulacioneswwds_17_postulacionesproveedorid3)");
         }
         else
         {
            GXv_int4[22] = 1;
         }
         if ( AV118Postulacioneswwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV119Postulacioneswwds_14_dynamicfiltersselector3, "POSTULACIONESPROVEEDORID") == 0 ) && ( AV120Postulacioneswwds_15_dynamicfiltersoperator3 == 2 ) && ( ! (0==AV122Postulacioneswwds_17_postulacionesproveedorid3) ) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesProveedorId] > @AV122Postulacioneswwds_17_postulacionesproveedorid3)");
         }
         else
         {
            GXv_int4[23] = 1;
         }
         if ( AV118Postulacioneswwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV119Postulacioneswwds_14_dynamicfiltersselector3, "SERVICIOSNOMBRE") == 0 ) && ( AV120Postulacioneswwds_15_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV123Postulacioneswwds_18_serviciosnombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T3.[ServiciosNombre]) like UPPER(@lV123Postulacioneswwds_18_serviciosnombre3))");
         }
         else
         {
            GXv_int4[24] = 1;
         }
         if ( AV118Postulacioneswwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV119Postulacioneswwds_14_dynamicfiltersselector3, "SERVICIOSNOMBRE") == 0 ) && ( AV120Postulacioneswwds_15_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV123Postulacioneswwds_18_serviciosnombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T3.[ServiciosNombre]) like '%' + UPPER(@lV123Postulacioneswwds_18_serviciosnombre3))");
         }
         else
         {
            GXv_int4[25] = 1;
         }
         if ( ! (0==AV124Postulacioneswwds_19_tfpostulacionesid) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesId] >= @AV124Postulacioneswwds_19_tfpostulacionesid)");
         }
         else
         {
            GXv_int4[26] = 1;
         }
         if ( ! (0==AV125Postulacioneswwds_20_tfpostulacionesid_to) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesId] <= @AV125Postulacioneswwds_20_tfpostulacionesid_to)");
         }
         else
         {
            GXv_int4[27] = 1;
         }
         if ( ! (0==AV126Postulacioneswwds_21_tfserviciosid) )
         {
            AddWhere(sWhereString, "(T1.[ServiciosId] >= @AV126Postulacioneswwds_21_tfserviciosid)");
         }
         else
         {
            GXv_int4[28] = 1;
         }
         if ( ! (0==AV127Postulacioneswwds_22_tfserviciosid_to) )
         {
            AddWhere(sWhereString, "(T1.[ServiciosId] <= @AV127Postulacioneswwds_22_tfserviciosid_to)");
         }
         else
         {
            GXv_int4[29] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV129Postulacioneswwds_24_tfserviciosnombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV128Postulacioneswwds_23_tfserviciosnombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T3.[ServiciosNombre]) like UPPER(@lV128Postulacioneswwds_23_tfserviciosnombre))");
         }
         else
         {
            GXv_int4[30] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV129Postulacioneswwds_24_tfserviciosnombre_sel)) && ! ( StringUtil.StrCmp(AV129Postulacioneswwds_24_tfserviciosnombre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T3.[ServiciosNombre] = @AV129Postulacioneswwds_24_tfserviciosnombre_sel)");
         }
         else
         {
            GXv_int4[31] = 1;
         }
         if ( StringUtil.StrCmp(AV129Postulacioneswwds_24_tfserviciosnombre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T3.[ServiciosNombre] IS NULL or (T3.[ServiciosNombre] = ''))");
         }
         if ( ! (0==AV130Postulacioneswwds_25_tfpostulacionesproveedorid) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesProveedorId] >= @AV130Postulacioneswwds_25_tfpostulacionesproveedorid)");
         }
         else
         {
            GXv_int4[32] = 1;
         }
         if ( ! (0==AV131Postulacioneswwds_26_tfpostulacionesproveedorid_to) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesProveedorId] <= @AV131Postulacioneswwds_26_tfpostulacionesproveedorid_to)");
         }
         else
         {
            GXv_int4[33] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV133Postulacioneswwds_28_tfpostulacionesproveedornombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV132Postulacioneswwds_27_tfpostulacionesproveedornombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ProveedorNombre]) like UPPER(@lV132Postulacioneswwds_27_tfpostulacionesproveedornombre))");
         }
         else
         {
            GXv_int4[34] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV133Postulacioneswwds_28_tfpostulacionesproveedornombre_sel)) && ! ( StringUtil.StrCmp(AV133Postulacioneswwds_28_tfpostulacionesproveedornombre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.[ProveedorNombre] = @AV133Postulacioneswwds_28_tfpostulacionesproveedornombre_sel)");
         }
         else
         {
            GXv_int4[35] = 1;
         }
         if ( StringUtil.StrCmp(AV133Postulacioneswwds_28_tfpostulacionesproveedornombre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T2.[ProveedorNombre] = ''))");
         }
         if ( ! (Convert.ToDecimal(0)==AV134Postulacioneswwds_29_tfpostulacionesprecio) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesPrecio] >= @AV134Postulacioneswwds_29_tfpostulacionesprecio)");
         }
         else
         {
            GXv_int4[36] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV135Postulacioneswwds_30_tfpostulacionesprecio_to) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesPrecio] <= @AV135Postulacioneswwds_30_tfpostulacionesprecio_to)");
         }
         else
         {
            GXv_int4[37] = 1;
         }
         if ( ! (0==AV136Postulacioneswwds_31_tfpostulacionesmultimediaserial) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesMultimediaSerial] >= @AV136Postulacioneswwds_31_tfpostulacionesmultimediaserial)");
         }
         else
         {
            GXv_int4[38] = 1;
         }
         if ( ! (0==AV137Postulacioneswwds_32_tfpostulacionesmultimediaserial_to) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesMultimediaSerial] <= @AV137Postulacioneswwds_32_tfpostulacionesmultimediaserial_to)");
         }
         else
         {
            GXv_int4[39] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV141Postulacioneswwds_36_tfpostulacionesdescripcion_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV140Postulacioneswwds_35_tfpostulacionesdescripcion)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[PostulacionesDescripcion]) like UPPER(@lV140Postulacioneswwds_35_tfpostulacionesdescripcion))");
         }
         else
         {
            GXv_int4[40] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV141Postulacioneswwds_36_tfpostulacionesdescripcion_sel)) && ! ( StringUtil.StrCmp(AV141Postulacioneswwds_36_tfpostulacionesdescripcion_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesDescripcion] = @AV141Postulacioneswwds_36_tfpostulacionesdescripcion_sel)");
         }
         else
         {
            GXv_int4[41] = 1;
         }
         if ( StringUtil.StrCmp(AV141Postulacioneswwds_36_tfpostulacionesdescripcion_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[PostulacionesDescripcion] = ''))");
         }
         if ( AV142Postulacioneswwds_37_tfpostulacionesreqsuministros_sel == 1 )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesReqSuministros] = 1)");
         }
         if ( AV142Postulacioneswwds_37_tfpostulacionesreqsuministros_sel == 2 )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesReqSuministros] = 0)");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV144Postulacioneswwds_39_tfpostulacionessuministrosdescripcion_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV143Postulacioneswwds_38_tfpostulacionessuministrosdescripcion)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[PostulacionesSuministrosDescri]) like UPPER(@lV143Postulacioneswwds_38_tfpostulacionessuministrosdescripcion))");
         }
         else
         {
            GXv_int4[42] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV144Postulacioneswwds_39_tfpostulacionessuministrosdescripcion_sel)) && ! ( StringUtil.StrCmp(AV144Postulacioneswwds_39_tfpostulacionessuministrosdescripcion_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesSuministrosDescri] = @AV144Postulacioneswwds_39_tfpostulacionessuministrosdescripcion_sel)");
         }
         else
         {
            GXv_int4[43] = 1;
         }
         if ( StringUtil.StrCmp(AV144Postulacioneswwds_39_tfpostulacionessuministrosdescripcion_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[PostulacionesSuministrosDescri] = ''))");
         }
         if ( ! (DateTime.MinValue==AV145Postulacioneswwds_40_tfpostulacionesfechatrabajo) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesFechaTrabajo] >= @AV145Postulacioneswwds_40_tfpostulacionesfechatrabajo)");
         }
         else
         {
            GXv_int4[44] = 1;
         }
         if ( ! (DateTime.MinValue==AV146Postulacioneswwds_41_tfpostulacionesfechatrabajo_to) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesFechaTrabajo] <= @AV146Postulacioneswwds_41_tfpostulacionesfechatrabajo_to)");
         }
         else
         {
            GXv_int4[45] = 1;
         }
         if ( ! (DateTime.MinValue==AV147Postulacioneswwds_42_tfpostulacionesfechacierre) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesFechaCierre] >= @AV147Postulacioneswwds_42_tfpostulacionesfechacierre)");
         }
         else
         {
            GXv_int4[46] = 1;
         }
         if ( ! (DateTime.MinValue==AV148Postulacioneswwds_43_tfpostulacionesfechacierre_to) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesFechaCierre] <= @AV148Postulacioneswwds_43_tfpostulacionesfechacierre_to)");
         }
         else
         {
            GXv_int4[47] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV150Postulacioneswwds_45_tfpostulacioneshoracierre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV149Postulacioneswwds_44_tfpostulacioneshoracierre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[PostulacionesHoraCierre]) like UPPER(@lV149Postulacioneswwds_44_tfpostulacioneshoracierre))");
         }
         else
         {
            GXv_int4[48] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV150Postulacioneswwds_45_tfpostulacioneshoracierre_sel)) && ! ( StringUtil.StrCmp(AV150Postulacioneswwds_45_tfpostulacioneshoracierre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesHoraCierre] = @AV150Postulacioneswwds_45_tfpostulacioneshoracierre_sel)");
         }
         else
         {
            GXv_int4[49] = 1;
         }
         if ( StringUtil.StrCmp(AV150Postulacioneswwds_45_tfpostulacioneshoracierre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[PostulacionesHoraCierre] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV152Postulacioneswwds_47_tfpostulacionestipofecha_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV151Postulacioneswwds_46_tfpostulacionestipofecha)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[PostulacionesTipoFecha]) like UPPER(@lV151Postulacioneswwds_46_tfpostulacionestipofecha))");
         }
         else
         {
            GXv_int4[50] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV152Postulacioneswwds_47_tfpostulacionestipofecha_sel)) && ! ( StringUtil.StrCmp(AV152Postulacioneswwds_47_tfpostulacionestipofecha_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesTipoFecha] = @AV152Postulacioneswwds_47_tfpostulacionestipofecha_sel)");
         }
         else
         {
            GXv_int4[51] = 1;
         }
         if ( StringUtil.StrCmp(AV152Postulacioneswwds_47_tfpostulacionestipofecha_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[PostulacionesTipoFecha] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV154Postulacioneswwds_49_tfpostulacionesrgohoraservicio_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV153Postulacioneswwds_48_tfpostulacionesrgohoraservicio)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[PostulacionesRgoHoraservicio]) like UPPER(@lV153Postulacioneswwds_48_tfpostulacionesrgohoraservicio))");
         }
         else
         {
            GXv_int4[52] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV154Postulacioneswwds_49_tfpostulacionesrgohoraservicio_sel)) && ! ( StringUtil.StrCmp(AV154Postulacioneswwds_49_tfpostulacionesrgohoraservicio_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesRgoHoraservicio] = @AV154Postulacioneswwds_49_tfpostulacionesrgohoraservicio_sel)");
         }
         else
         {
            GXv_int4[53] = 1;
         }
         if ( StringUtil.StrCmp(AV154Postulacioneswwds_49_tfpostulacionesrgohoraservicio_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[PostulacionesRgoHoraservicio] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV156Postulacioneswwds_51_tfpostulacionesapellidonombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV155Postulacioneswwds_50_tfpostulacionesapellidonombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[PostulacionesApellidoNombre]) like UPPER(@lV155Postulacioneswwds_50_tfpostulacionesapellidonombre))");
         }
         else
         {
            GXv_int4[54] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV156Postulacioneswwds_51_tfpostulacionesapellidonombre_sel)) && ! ( StringUtil.StrCmp(AV156Postulacioneswwds_51_tfpostulacionesapellidonombre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesApellidoNombre] = @AV156Postulacioneswwds_51_tfpostulacionesapellidonombre_sel)");
         }
         else
         {
            GXv_int4[55] = 1;
         }
         if ( StringUtil.StrCmp(AV156Postulacioneswwds_51_tfpostulacionesapellidonombre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[PostulacionesApellidoNombre] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV158Postulacioneswwds_53_tfpostulacionesmail_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV157Postulacioneswwds_52_tfpostulacionesmail)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[PostulacionesMail]) like UPPER(@lV157Postulacioneswwds_52_tfpostulacionesmail))");
         }
         else
         {
            GXv_int4[56] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV158Postulacioneswwds_53_tfpostulacionesmail_sel)) && ! ( StringUtil.StrCmp(AV158Postulacioneswwds_53_tfpostulacionesmail_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesMail] = @AV158Postulacioneswwds_53_tfpostulacionesmail_sel)");
         }
         else
         {
            GXv_int4[57] = 1;
         }
         if ( StringUtil.StrCmp(AV158Postulacioneswwds_53_tfpostulacionesmail_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[PostulacionesMail] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV160Postulacioneswwds_55_tfpostulacionestelefono_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV159Postulacioneswwds_54_tfpostulacionestelefono)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[PostulacionesTelefono]) like UPPER(@lV159Postulacioneswwds_54_tfpostulacionestelefono))");
         }
         else
         {
            GXv_int4[58] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV160Postulacioneswwds_55_tfpostulacionestelefono_sel)) && ! ( StringUtil.StrCmp(AV160Postulacioneswwds_55_tfpostulacionestelefono_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesTelefono] = @AV160Postulacioneswwds_55_tfpostulacionestelefono_sel)");
         }
         else
         {
            GXv_int4[59] = 1;
         }
         if ( StringUtil.StrCmp(AV160Postulacioneswwds_55_tfpostulacionestelefono_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[PostulacionesTelefono] = ''))");
         }
         if ( ! (DateTime.MinValue==AV161Postulacioneswwds_56_tfpostulacionesfechaalta) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesFechaAlta] >= @AV161Postulacioneswwds_56_tfpostulacionesfechaalta)");
         }
         else
         {
            GXv_int4[60] = 1;
         }
         if ( ! (DateTime.MinValue==AV162Postulacioneswwds_57_tfpostulacionesfechaalta_to) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesFechaAlta] <= @AV162Postulacioneswwds_57_tfpostulacionesfechaalta_to)");
         }
         else
         {
            GXv_int4[61] = 1;
         }
         if ( AV163Postulacioneswwds_58_tfpostulacionesestado_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV163Postulacioneswwds_58_tfpostulacionesestado_sels, "T1.[PostulacionesEstado] IN (", ")")+")");
         }
         if ( ! (0==AV164Postulacioneswwds_59_tfpostulacionessecuserid) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesSecUserId] >= @AV164Postulacioneswwds_59_tfpostulacionessecuserid)");
         }
         else
         {
            GXv_int4[62] = 1;
         }
         if ( ! (0==AV165Postulacioneswwds_60_tfpostulacionessecuserid_to) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesSecUserId] <= @AV165Postulacioneswwds_60_tfpostulacionessecuserid_to)");
         }
         else
         {
            GXv_int4[63] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[PostulacionesProveedorId]";
         GXv_Object5[0] = scmdbuf;
         GXv_Object5[1] = GXv_int4;
         return GXv_Object5 ;
      }

      protected Object[] conditional_P00LA7( IGxContext context ,
                                             string A424PostulacionesEstado ,
                                             GxSimpleCollection<string> AV163Postulacioneswwds_58_tfpostulacionesestado_sels ,
                                             string AV107Postulacioneswwds_2_dynamicfiltersselector1 ,
                                             short AV108Postulacioneswwds_3_dynamicfiltersoperator1 ,
                                             string AV109Postulacioneswwds_4_postulacionesproveedornombre1 ,
                                             long AV110Postulacioneswwds_5_postulacionesproveedorid1 ,
                                             string AV111Postulacioneswwds_6_serviciosnombre1 ,
                                             bool AV112Postulacioneswwds_7_dynamicfiltersenabled2 ,
                                             string AV113Postulacioneswwds_8_dynamicfiltersselector2 ,
                                             short AV114Postulacioneswwds_9_dynamicfiltersoperator2 ,
                                             string AV115Postulacioneswwds_10_postulacionesproveedornombre2 ,
                                             long AV116Postulacioneswwds_11_postulacionesproveedorid2 ,
                                             string AV117Postulacioneswwds_12_serviciosnombre2 ,
                                             bool AV118Postulacioneswwds_13_dynamicfiltersenabled3 ,
                                             string AV119Postulacioneswwds_14_dynamicfiltersselector3 ,
                                             short AV120Postulacioneswwds_15_dynamicfiltersoperator3 ,
                                             string AV121Postulacioneswwds_16_postulacionesproveedornombre3 ,
                                             long AV122Postulacioneswwds_17_postulacionesproveedorid3 ,
                                             string AV123Postulacioneswwds_18_serviciosnombre3 ,
                                             long AV124Postulacioneswwds_19_tfpostulacionesid ,
                                             long AV125Postulacioneswwds_20_tfpostulacionesid_to ,
                                             long AV126Postulacioneswwds_21_tfserviciosid ,
                                             long AV127Postulacioneswwds_22_tfserviciosid_to ,
                                             string AV129Postulacioneswwds_24_tfserviciosnombre_sel ,
                                             string AV128Postulacioneswwds_23_tfserviciosnombre ,
                                             long AV130Postulacioneswwds_25_tfpostulacionesproveedorid ,
                                             long AV131Postulacioneswwds_26_tfpostulacionesproveedorid_to ,
                                             string AV133Postulacioneswwds_28_tfpostulacionesproveedornombre_sel ,
                                             string AV132Postulacioneswwds_27_tfpostulacionesproveedornombre ,
                                             decimal AV134Postulacioneswwds_29_tfpostulacionesprecio ,
                                             decimal AV135Postulacioneswwds_30_tfpostulacionesprecio_to ,
                                             short AV136Postulacioneswwds_31_tfpostulacionesmultimediaserial ,
                                             short AV137Postulacioneswwds_32_tfpostulacionesmultimediaserial_to ,
                                             string AV141Postulacioneswwds_36_tfpostulacionesdescripcion_sel ,
                                             string AV140Postulacioneswwds_35_tfpostulacionesdescripcion ,
                                             short AV142Postulacioneswwds_37_tfpostulacionesreqsuministros_sel ,
                                             string AV144Postulacioneswwds_39_tfpostulacionessuministrosdescripcion_sel ,
                                             string AV143Postulacioneswwds_38_tfpostulacionessuministrosdescripcion ,
                                             DateTime AV145Postulacioneswwds_40_tfpostulacionesfechatrabajo ,
                                             DateTime AV146Postulacioneswwds_41_tfpostulacionesfechatrabajo_to ,
                                             DateTime AV147Postulacioneswwds_42_tfpostulacionesfechacierre ,
                                             DateTime AV148Postulacioneswwds_43_tfpostulacionesfechacierre_to ,
                                             string AV150Postulacioneswwds_45_tfpostulacioneshoracierre_sel ,
                                             string AV149Postulacioneswwds_44_tfpostulacioneshoracierre ,
                                             string AV152Postulacioneswwds_47_tfpostulacionestipofecha_sel ,
                                             string AV151Postulacioneswwds_46_tfpostulacionestipofecha ,
                                             string AV154Postulacioneswwds_49_tfpostulacionesrgohoraservicio_sel ,
                                             string AV153Postulacioneswwds_48_tfpostulacionesrgohoraservicio ,
                                             string AV156Postulacioneswwds_51_tfpostulacionesapellidonombre_sel ,
                                             string AV155Postulacioneswwds_50_tfpostulacionesapellidonombre ,
                                             string AV158Postulacioneswwds_53_tfpostulacionesmail_sel ,
                                             string AV157Postulacioneswwds_52_tfpostulacionesmail ,
                                             string AV160Postulacioneswwds_55_tfpostulacionestelefono_sel ,
                                             string AV159Postulacioneswwds_54_tfpostulacionestelefono ,
                                             DateTime AV161Postulacioneswwds_56_tfpostulacionesfechaalta ,
                                             DateTime AV162Postulacioneswwds_57_tfpostulacionesfechaalta_to ,
                                             int AV163Postulacioneswwds_58_tfpostulacionesestado_sels_Count ,
                                             long AV164Postulacioneswwds_59_tfpostulacionessecuserid ,
                                             long AV165Postulacioneswwds_60_tfpostulacionessecuserid_to ,
                                             string A969PostulacionesProveedorNombre ,
                                             long A945PostulacionesProveedorId ,
                                             string A943ServiciosNombre ,
                                             long A422PostulacionesId ,
                                             long A942ServiciosId ,
                                             decimal A946PostulacionesPrecio ,
                                             short A961PostulacionesMultimediaSerial ,
                                             string A936PostulacionesDescripcion ,
                                             bool A937PostulacionesReqSuministros ,
                                             string A938PostulacionesSuministrosDescri ,
                                             DateTime A947PostulacionesFechaTrabajo ,
                                             DateTime A939PostulacionesFechaCierre ,
                                             string A940PostulacionesHoraCierre ,
                                             string A941PostulacionesTipoFecha ,
                                             string A949PostulacionesRgoHoraservicio ,
                                             string A950PostulacionesApellidoNombre ,
                                             string A951PostulacionesMail ,
                                             string A952PostulacionesTelefono ,
                                             DateTime A425PostulacionesFechaAlta ,
                                             long A948PostulacionesSecUserId ,
                                             string AV106Postulacioneswwds_1_filterfulltext ,
                                             long A970PostulacionesSolicitudesId ,
                                             long AV138Postulacioneswwds_33_tfpostulacionessolicitudesid ,
                                             long AV139Postulacioneswwds_34_tfpostulacionessolicitudesid_to )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int6 = new short[64];
         Object[] GXv_Object7 = new Object[2];
         scmdbuf = "SELECT T1.[PostulacionesDescripcion], T1.[PostulacionesSecUserId], T1.[PostulacionesFechaAlta], T1.[PostulacionesTelefono], T1.[PostulacionesMail], T1.[PostulacionesApellidoNombre], T1.[PostulacionesRgoHoraservicio], T1.[PostulacionesTipoFecha], T1.[PostulacionesHoraCierre], T1.[PostulacionesFechaCierre], T1.[PostulacionesFechaTrabajo], T1.[PostulacionesSuministrosDescri], T1.[PostulacionesReqSuministros], T1.[PostulacionesMultimediaSerial], T1.[PostulacionesPrecio], T3.[ProveedorNombre] AS PostulacionesProveedorNombre, T2.[ServiciosNombre], T1.[ServiciosId], T1.[PostulacionesId], T1.[PostulacionesProveedorId] AS PostulacionesProveedorId, T1.[PostulacionesEstado], COALESCE( T4.[PostulacionesSolicitudesId], 0) AS PostulacionesSolicitudesId FROM (([Postulaciones] T1 LEFT JOIN [Servicios] T2 ON T2.[ServiciosId] = T1.[ServiciosId]) INNER JOIN [Proveedor] T3 ON T3.[ProveedorID] = T1.[PostulacionesProveedorId]),  (SELECT MIN([SolicitudesID]) AS PostulacionesSolicitudesId FROM [Solicitudes] WHERE [PostulacionesId] = @PostulacionesId ) T4";
         AddWhere(sWhereString, "((@AV138Postulacioneswwds_33_tfpostulacionessolicitudesid = convert(int, 0)) or ( COALESCE( T4.[PostulacionesSolicitudesId], 0) >= @AV138Postulacioneswwds_33_tfpostulacionessolicitudesid))");
         AddWhere(sWhereString, "((@AV139Postulacioneswwds_34_tfpostulacionessolicitudesid_to = convert(int, 0)) or ( COALESCE( T4.[PostulacionesSolicitudesId], 0) <= @AV139Postulacioneswwds_34_tfpostulacionessolicitudesid_to))");
         if ( ( StringUtil.StrCmp(AV107Postulacioneswwds_2_dynamicfiltersselector1, "POSTULACIONESPROVEEDORNOMBRE") == 0 ) && ( AV108Postulacioneswwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV109Postulacioneswwds_4_postulacionesproveedornombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T3.[ProveedorNombre]) like UPPER(@lV109Postulacioneswwds_4_postulacionesproveedornombre1))");
         }
         else
         {
            GXv_int6[5] = 1;
         }
         if ( ( StringUtil.StrCmp(AV107Postulacioneswwds_2_dynamicfiltersselector1, "POSTULACIONESPROVEEDORNOMBRE") == 0 ) && ( AV108Postulacioneswwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV109Postulacioneswwds_4_postulacionesproveedornombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T3.[ProveedorNombre]) like '%' + UPPER(@lV109Postulacioneswwds_4_postulacionesproveedornombre1))");
         }
         else
         {
            GXv_int6[6] = 1;
         }
         if ( ( StringUtil.StrCmp(AV107Postulacioneswwds_2_dynamicfiltersselector1, "POSTULACIONESPROVEEDORID") == 0 ) && ( AV108Postulacioneswwds_3_dynamicfiltersoperator1 == 0 ) && ( ! (0==AV110Postulacioneswwds_5_postulacionesproveedorid1) ) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesProveedorId] < @AV110Postulacioneswwds_5_postulacionesproveedorid1)");
         }
         else
         {
            GXv_int6[7] = 1;
         }
         if ( ( StringUtil.StrCmp(AV107Postulacioneswwds_2_dynamicfiltersselector1, "POSTULACIONESPROVEEDORID") == 0 ) && ( AV108Postulacioneswwds_3_dynamicfiltersoperator1 == 1 ) && ( ! (0==AV110Postulacioneswwds_5_postulacionesproveedorid1) ) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesProveedorId] = @AV110Postulacioneswwds_5_postulacionesproveedorid1)");
         }
         else
         {
            GXv_int6[8] = 1;
         }
         if ( ( StringUtil.StrCmp(AV107Postulacioneswwds_2_dynamicfiltersselector1, "POSTULACIONESPROVEEDORID") == 0 ) && ( AV108Postulacioneswwds_3_dynamicfiltersoperator1 == 2 ) && ( ! (0==AV110Postulacioneswwds_5_postulacionesproveedorid1) ) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesProveedorId] > @AV110Postulacioneswwds_5_postulacionesproveedorid1)");
         }
         else
         {
            GXv_int6[9] = 1;
         }
         if ( ( StringUtil.StrCmp(AV107Postulacioneswwds_2_dynamicfiltersselector1, "SERVICIOSNOMBRE") == 0 ) && ( AV108Postulacioneswwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV111Postulacioneswwds_6_serviciosnombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ServiciosNombre]) like UPPER(@lV111Postulacioneswwds_6_serviciosnombre1))");
         }
         else
         {
            GXv_int6[10] = 1;
         }
         if ( ( StringUtil.StrCmp(AV107Postulacioneswwds_2_dynamicfiltersselector1, "SERVICIOSNOMBRE") == 0 ) && ( AV108Postulacioneswwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV111Postulacioneswwds_6_serviciosnombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ServiciosNombre]) like '%' + UPPER(@lV111Postulacioneswwds_6_serviciosnombre1))");
         }
         else
         {
            GXv_int6[11] = 1;
         }
         if ( AV112Postulacioneswwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV113Postulacioneswwds_8_dynamicfiltersselector2, "POSTULACIONESPROVEEDORNOMBRE") == 0 ) && ( AV114Postulacioneswwds_9_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV115Postulacioneswwds_10_postulacionesproveedornombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T3.[ProveedorNombre]) like UPPER(@lV115Postulacioneswwds_10_postulacionesproveedornombre2))");
         }
         else
         {
            GXv_int6[12] = 1;
         }
         if ( AV112Postulacioneswwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV113Postulacioneswwds_8_dynamicfiltersselector2, "POSTULACIONESPROVEEDORNOMBRE") == 0 ) && ( AV114Postulacioneswwds_9_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV115Postulacioneswwds_10_postulacionesproveedornombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T3.[ProveedorNombre]) like '%' + UPPER(@lV115Postulacioneswwds_10_postulacionesproveedornombre2))");
         }
         else
         {
            GXv_int6[13] = 1;
         }
         if ( AV112Postulacioneswwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV113Postulacioneswwds_8_dynamicfiltersselector2, "POSTULACIONESPROVEEDORID") == 0 ) && ( AV114Postulacioneswwds_9_dynamicfiltersoperator2 == 0 ) && ( ! (0==AV116Postulacioneswwds_11_postulacionesproveedorid2) ) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesProveedorId] < @AV116Postulacioneswwds_11_postulacionesproveedorid2)");
         }
         else
         {
            GXv_int6[14] = 1;
         }
         if ( AV112Postulacioneswwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV113Postulacioneswwds_8_dynamicfiltersselector2, "POSTULACIONESPROVEEDORID") == 0 ) && ( AV114Postulacioneswwds_9_dynamicfiltersoperator2 == 1 ) && ( ! (0==AV116Postulacioneswwds_11_postulacionesproveedorid2) ) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesProveedorId] = @AV116Postulacioneswwds_11_postulacionesproveedorid2)");
         }
         else
         {
            GXv_int6[15] = 1;
         }
         if ( AV112Postulacioneswwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV113Postulacioneswwds_8_dynamicfiltersselector2, "POSTULACIONESPROVEEDORID") == 0 ) && ( AV114Postulacioneswwds_9_dynamicfiltersoperator2 == 2 ) && ( ! (0==AV116Postulacioneswwds_11_postulacionesproveedorid2) ) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesProveedorId] > @AV116Postulacioneswwds_11_postulacionesproveedorid2)");
         }
         else
         {
            GXv_int6[16] = 1;
         }
         if ( AV112Postulacioneswwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV113Postulacioneswwds_8_dynamicfiltersselector2, "SERVICIOSNOMBRE") == 0 ) && ( AV114Postulacioneswwds_9_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV117Postulacioneswwds_12_serviciosnombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ServiciosNombre]) like UPPER(@lV117Postulacioneswwds_12_serviciosnombre2))");
         }
         else
         {
            GXv_int6[17] = 1;
         }
         if ( AV112Postulacioneswwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV113Postulacioneswwds_8_dynamicfiltersselector2, "SERVICIOSNOMBRE") == 0 ) && ( AV114Postulacioneswwds_9_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV117Postulacioneswwds_12_serviciosnombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ServiciosNombre]) like '%' + UPPER(@lV117Postulacioneswwds_12_serviciosnombre2))");
         }
         else
         {
            GXv_int6[18] = 1;
         }
         if ( AV118Postulacioneswwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV119Postulacioneswwds_14_dynamicfiltersselector3, "POSTULACIONESPROVEEDORNOMBRE") == 0 ) && ( AV120Postulacioneswwds_15_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV121Postulacioneswwds_16_postulacionesproveedornombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T3.[ProveedorNombre]) like UPPER(@lV121Postulacioneswwds_16_postulacionesproveedornombre3))");
         }
         else
         {
            GXv_int6[19] = 1;
         }
         if ( AV118Postulacioneswwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV119Postulacioneswwds_14_dynamicfiltersselector3, "POSTULACIONESPROVEEDORNOMBRE") == 0 ) && ( AV120Postulacioneswwds_15_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV121Postulacioneswwds_16_postulacionesproveedornombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T3.[ProveedorNombre]) like '%' + UPPER(@lV121Postulacioneswwds_16_postulacionesproveedornombre3))");
         }
         else
         {
            GXv_int6[20] = 1;
         }
         if ( AV118Postulacioneswwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV119Postulacioneswwds_14_dynamicfiltersselector3, "POSTULACIONESPROVEEDORID") == 0 ) && ( AV120Postulacioneswwds_15_dynamicfiltersoperator3 == 0 ) && ( ! (0==AV122Postulacioneswwds_17_postulacionesproveedorid3) ) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesProveedorId] < @AV122Postulacioneswwds_17_postulacionesproveedorid3)");
         }
         else
         {
            GXv_int6[21] = 1;
         }
         if ( AV118Postulacioneswwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV119Postulacioneswwds_14_dynamicfiltersselector3, "POSTULACIONESPROVEEDORID") == 0 ) && ( AV120Postulacioneswwds_15_dynamicfiltersoperator3 == 1 ) && ( ! (0==AV122Postulacioneswwds_17_postulacionesproveedorid3) ) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesProveedorId] = @AV122Postulacioneswwds_17_postulacionesproveedorid3)");
         }
         else
         {
            GXv_int6[22] = 1;
         }
         if ( AV118Postulacioneswwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV119Postulacioneswwds_14_dynamicfiltersselector3, "POSTULACIONESPROVEEDORID") == 0 ) && ( AV120Postulacioneswwds_15_dynamicfiltersoperator3 == 2 ) && ( ! (0==AV122Postulacioneswwds_17_postulacionesproveedorid3) ) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesProveedorId] > @AV122Postulacioneswwds_17_postulacionesproveedorid3)");
         }
         else
         {
            GXv_int6[23] = 1;
         }
         if ( AV118Postulacioneswwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV119Postulacioneswwds_14_dynamicfiltersselector3, "SERVICIOSNOMBRE") == 0 ) && ( AV120Postulacioneswwds_15_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV123Postulacioneswwds_18_serviciosnombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ServiciosNombre]) like UPPER(@lV123Postulacioneswwds_18_serviciosnombre3))");
         }
         else
         {
            GXv_int6[24] = 1;
         }
         if ( AV118Postulacioneswwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV119Postulacioneswwds_14_dynamicfiltersselector3, "SERVICIOSNOMBRE") == 0 ) && ( AV120Postulacioneswwds_15_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV123Postulacioneswwds_18_serviciosnombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ServiciosNombre]) like '%' + UPPER(@lV123Postulacioneswwds_18_serviciosnombre3))");
         }
         else
         {
            GXv_int6[25] = 1;
         }
         if ( ! (0==AV124Postulacioneswwds_19_tfpostulacionesid) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesId] >= @AV124Postulacioneswwds_19_tfpostulacionesid)");
         }
         else
         {
            GXv_int6[26] = 1;
         }
         if ( ! (0==AV125Postulacioneswwds_20_tfpostulacionesid_to) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesId] <= @AV125Postulacioneswwds_20_tfpostulacionesid_to)");
         }
         else
         {
            GXv_int6[27] = 1;
         }
         if ( ! (0==AV126Postulacioneswwds_21_tfserviciosid) )
         {
            AddWhere(sWhereString, "(T1.[ServiciosId] >= @AV126Postulacioneswwds_21_tfserviciosid)");
         }
         else
         {
            GXv_int6[28] = 1;
         }
         if ( ! (0==AV127Postulacioneswwds_22_tfserviciosid_to) )
         {
            AddWhere(sWhereString, "(T1.[ServiciosId] <= @AV127Postulacioneswwds_22_tfserviciosid_to)");
         }
         else
         {
            GXv_int6[29] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV129Postulacioneswwds_24_tfserviciosnombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV128Postulacioneswwds_23_tfserviciosnombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ServiciosNombre]) like UPPER(@lV128Postulacioneswwds_23_tfserviciosnombre))");
         }
         else
         {
            GXv_int6[30] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV129Postulacioneswwds_24_tfserviciosnombre_sel)) && ! ( StringUtil.StrCmp(AV129Postulacioneswwds_24_tfserviciosnombre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.[ServiciosNombre] = @AV129Postulacioneswwds_24_tfserviciosnombre_sel)");
         }
         else
         {
            GXv_int6[31] = 1;
         }
         if ( StringUtil.StrCmp(AV129Postulacioneswwds_24_tfserviciosnombre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T2.[ServiciosNombre] IS NULL or (T2.[ServiciosNombre] = ''))");
         }
         if ( ! (0==AV130Postulacioneswwds_25_tfpostulacionesproveedorid) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesProveedorId] >= @AV130Postulacioneswwds_25_tfpostulacionesproveedorid)");
         }
         else
         {
            GXv_int6[32] = 1;
         }
         if ( ! (0==AV131Postulacioneswwds_26_tfpostulacionesproveedorid_to) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesProveedorId] <= @AV131Postulacioneswwds_26_tfpostulacionesproveedorid_to)");
         }
         else
         {
            GXv_int6[33] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV133Postulacioneswwds_28_tfpostulacionesproveedornombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV132Postulacioneswwds_27_tfpostulacionesproveedornombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T3.[ProveedorNombre]) like UPPER(@lV132Postulacioneswwds_27_tfpostulacionesproveedornombre))");
         }
         else
         {
            GXv_int6[34] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV133Postulacioneswwds_28_tfpostulacionesproveedornombre_sel)) && ! ( StringUtil.StrCmp(AV133Postulacioneswwds_28_tfpostulacionesproveedornombre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T3.[ProveedorNombre] = @AV133Postulacioneswwds_28_tfpostulacionesproveedornombre_sel)");
         }
         else
         {
            GXv_int6[35] = 1;
         }
         if ( StringUtil.StrCmp(AV133Postulacioneswwds_28_tfpostulacionesproveedornombre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T3.[ProveedorNombre] = ''))");
         }
         if ( ! (Convert.ToDecimal(0)==AV134Postulacioneswwds_29_tfpostulacionesprecio) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesPrecio] >= @AV134Postulacioneswwds_29_tfpostulacionesprecio)");
         }
         else
         {
            GXv_int6[36] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV135Postulacioneswwds_30_tfpostulacionesprecio_to) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesPrecio] <= @AV135Postulacioneswwds_30_tfpostulacionesprecio_to)");
         }
         else
         {
            GXv_int6[37] = 1;
         }
         if ( ! (0==AV136Postulacioneswwds_31_tfpostulacionesmultimediaserial) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesMultimediaSerial] >= @AV136Postulacioneswwds_31_tfpostulacionesmultimediaserial)");
         }
         else
         {
            GXv_int6[38] = 1;
         }
         if ( ! (0==AV137Postulacioneswwds_32_tfpostulacionesmultimediaserial_to) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesMultimediaSerial] <= @AV137Postulacioneswwds_32_tfpostulacionesmultimediaserial_to)");
         }
         else
         {
            GXv_int6[39] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV141Postulacioneswwds_36_tfpostulacionesdescripcion_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV140Postulacioneswwds_35_tfpostulacionesdescripcion)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[PostulacionesDescripcion]) like UPPER(@lV140Postulacioneswwds_35_tfpostulacionesdescripcion))");
         }
         else
         {
            GXv_int6[40] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV141Postulacioneswwds_36_tfpostulacionesdescripcion_sel)) && ! ( StringUtil.StrCmp(AV141Postulacioneswwds_36_tfpostulacionesdescripcion_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesDescripcion] = @AV141Postulacioneswwds_36_tfpostulacionesdescripcion_sel)");
         }
         else
         {
            GXv_int6[41] = 1;
         }
         if ( StringUtil.StrCmp(AV141Postulacioneswwds_36_tfpostulacionesdescripcion_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[PostulacionesDescripcion] = ''))");
         }
         if ( AV142Postulacioneswwds_37_tfpostulacionesreqsuministros_sel == 1 )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesReqSuministros] = 1)");
         }
         if ( AV142Postulacioneswwds_37_tfpostulacionesreqsuministros_sel == 2 )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesReqSuministros] = 0)");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV144Postulacioneswwds_39_tfpostulacionessuministrosdescripcion_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV143Postulacioneswwds_38_tfpostulacionessuministrosdescripcion)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[PostulacionesSuministrosDescri]) like UPPER(@lV143Postulacioneswwds_38_tfpostulacionessuministrosdescripcion))");
         }
         else
         {
            GXv_int6[42] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV144Postulacioneswwds_39_tfpostulacionessuministrosdescripcion_sel)) && ! ( StringUtil.StrCmp(AV144Postulacioneswwds_39_tfpostulacionessuministrosdescripcion_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesSuministrosDescri] = @AV144Postulacioneswwds_39_tfpostulacionessuministrosdescripcion_sel)");
         }
         else
         {
            GXv_int6[43] = 1;
         }
         if ( StringUtil.StrCmp(AV144Postulacioneswwds_39_tfpostulacionessuministrosdescripcion_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[PostulacionesSuministrosDescri] = ''))");
         }
         if ( ! (DateTime.MinValue==AV145Postulacioneswwds_40_tfpostulacionesfechatrabajo) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesFechaTrabajo] >= @AV145Postulacioneswwds_40_tfpostulacionesfechatrabajo)");
         }
         else
         {
            GXv_int6[44] = 1;
         }
         if ( ! (DateTime.MinValue==AV146Postulacioneswwds_41_tfpostulacionesfechatrabajo_to) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesFechaTrabajo] <= @AV146Postulacioneswwds_41_tfpostulacionesfechatrabajo_to)");
         }
         else
         {
            GXv_int6[45] = 1;
         }
         if ( ! (DateTime.MinValue==AV147Postulacioneswwds_42_tfpostulacionesfechacierre) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesFechaCierre] >= @AV147Postulacioneswwds_42_tfpostulacionesfechacierre)");
         }
         else
         {
            GXv_int6[46] = 1;
         }
         if ( ! (DateTime.MinValue==AV148Postulacioneswwds_43_tfpostulacionesfechacierre_to) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesFechaCierre] <= @AV148Postulacioneswwds_43_tfpostulacionesfechacierre_to)");
         }
         else
         {
            GXv_int6[47] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV150Postulacioneswwds_45_tfpostulacioneshoracierre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV149Postulacioneswwds_44_tfpostulacioneshoracierre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[PostulacionesHoraCierre]) like UPPER(@lV149Postulacioneswwds_44_tfpostulacioneshoracierre))");
         }
         else
         {
            GXv_int6[48] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV150Postulacioneswwds_45_tfpostulacioneshoracierre_sel)) && ! ( StringUtil.StrCmp(AV150Postulacioneswwds_45_tfpostulacioneshoracierre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesHoraCierre] = @AV150Postulacioneswwds_45_tfpostulacioneshoracierre_sel)");
         }
         else
         {
            GXv_int6[49] = 1;
         }
         if ( StringUtil.StrCmp(AV150Postulacioneswwds_45_tfpostulacioneshoracierre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[PostulacionesHoraCierre] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV152Postulacioneswwds_47_tfpostulacionestipofecha_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV151Postulacioneswwds_46_tfpostulacionestipofecha)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[PostulacionesTipoFecha]) like UPPER(@lV151Postulacioneswwds_46_tfpostulacionestipofecha))");
         }
         else
         {
            GXv_int6[50] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV152Postulacioneswwds_47_tfpostulacionestipofecha_sel)) && ! ( StringUtil.StrCmp(AV152Postulacioneswwds_47_tfpostulacionestipofecha_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesTipoFecha] = @AV152Postulacioneswwds_47_tfpostulacionestipofecha_sel)");
         }
         else
         {
            GXv_int6[51] = 1;
         }
         if ( StringUtil.StrCmp(AV152Postulacioneswwds_47_tfpostulacionestipofecha_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[PostulacionesTipoFecha] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV154Postulacioneswwds_49_tfpostulacionesrgohoraservicio_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV153Postulacioneswwds_48_tfpostulacionesrgohoraservicio)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[PostulacionesRgoHoraservicio]) like UPPER(@lV153Postulacioneswwds_48_tfpostulacionesrgohoraservicio))");
         }
         else
         {
            GXv_int6[52] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV154Postulacioneswwds_49_tfpostulacionesrgohoraservicio_sel)) && ! ( StringUtil.StrCmp(AV154Postulacioneswwds_49_tfpostulacionesrgohoraservicio_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesRgoHoraservicio] = @AV154Postulacioneswwds_49_tfpostulacionesrgohoraservicio_sel)");
         }
         else
         {
            GXv_int6[53] = 1;
         }
         if ( StringUtil.StrCmp(AV154Postulacioneswwds_49_tfpostulacionesrgohoraservicio_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[PostulacionesRgoHoraservicio] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV156Postulacioneswwds_51_tfpostulacionesapellidonombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV155Postulacioneswwds_50_tfpostulacionesapellidonombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[PostulacionesApellidoNombre]) like UPPER(@lV155Postulacioneswwds_50_tfpostulacionesapellidonombre))");
         }
         else
         {
            GXv_int6[54] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV156Postulacioneswwds_51_tfpostulacionesapellidonombre_sel)) && ! ( StringUtil.StrCmp(AV156Postulacioneswwds_51_tfpostulacionesapellidonombre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesApellidoNombre] = @AV156Postulacioneswwds_51_tfpostulacionesapellidonombre_sel)");
         }
         else
         {
            GXv_int6[55] = 1;
         }
         if ( StringUtil.StrCmp(AV156Postulacioneswwds_51_tfpostulacionesapellidonombre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[PostulacionesApellidoNombre] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV158Postulacioneswwds_53_tfpostulacionesmail_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV157Postulacioneswwds_52_tfpostulacionesmail)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[PostulacionesMail]) like UPPER(@lV157Postulacioneswwds_52_tfpostulacionesmail))");
         }
         else
         {
            GXv_int6[56] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV158Postulacioneswwds_53_tfpostulacionesmail_sel)) && ! ( StringUtil.StrCmp(AV158Postulacioneswwds_53_tfpostulacionesmail_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesMail] = @AV158Postulacioneswwds_53_tfpostulacionesmail_sel)");
         }
         else
         {
            GXv_int6[57] = 1;
         }
         if ( StringUtil.StrCmp(AV158Postulacioneswwds_53_tfpostulacionesmail_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[PostulacionesMail] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV160Postulacioneswwds_55_tfpostulacionestelefono_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV159Postulacioneswwds_54_tfpostulacionestelefono)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[PostulacionesTelefono]) like UPPER(@lV159Postulacioneswwds_54_tfpostulacionestelefono))");
         }
         else
         {
            GXv_int6[58] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV160Postulacioneswwds_55_tfpostulacionestelefono_sel)) && ! ( StringUtil.StrCmp(AV160Postulacioneswwds_55_tfpostulacionestelefono_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesTelefono] = @AV160Postulacioneswwds_55_tfpostulacionestelefono_sel)");
         }
         else
         {
            GXv_int6[59] = 1;
         }
         if ( StringUtil.StrCmp(AV160Postulacioneswwds_55_tfpostulacionestelefono_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[PostulacionesTelefono] = ''))");
         }
         if ( ! (DateTime.MinValue==AV161Postulacioneswwds_56_tfpostulacionesfechaalta) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesFechaAlta] >= @AV161Postulacioneswwds_56_tfpostulacionesfechaalta)");
         }
         else
         {
            GXv_int6[60] = 1;
         }
         if ( ! (DateTime.MinValue==AV162Postulacioneswwds_57_tfpostulacionesfechaalta_to) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesFechaAlta] <= @AV162Postulacioneswwds_57_tfpostulacionesfechaalta_to)");
         }
         else
         {
            GXv_int6[61] = 1;
         }
         if ( AV163Postulacioneswwds_58_tfpostulacionesestado_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV163Postulacioneswwds_58_tfpostulacionesestado_sels, "T1.[PostulacionesEstado] IN (", ")")+")");
         }
         if ( ! (0==AV164Postulacioneswwds_59_tfpostulacionessecuserid) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesSecUserId] >= @AV164Postulacioneswwds_59_tfpostulacionessecuserid)");
         }
         else
         {
            GXv_int6[62] = 1;
         }
         if ( ! (0==AV165Postulacioneswwds_60_tfpostulacionessecuserid_to) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesSecUserId] <= @AV165Postulacioneswwds_60_tfpostulacionessecuserid_to)");
         }
         else
         {
            GXv_int6[63] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[PostulacionesDescripcion]";
         GXv_Object7[0] = scmdbuf;
         GXv_Object7[1] = GXv_int6;
         return GXv_Object7 ;
      }

      protected Object[] conditional_P00LA9( IGxContext context ,
                                             string A424PostulacionesEstado ,
                                             GxSimpleCollection<string> AV163Postulacioneswwds_58_tfpostulacionesestado_sels ,
                                             string AV107Postulacioneswwds_2_dynamicfiltersselector1 ,
                                             short AV108Postulacioneswwds_3_dynamicfiltersoperator1 ,
                                             string AV109Postulacioneswwds_4_postulacionesproveedornombre1 ,
                                             long AV110Postulacioneswwds_5_postulacionesproveedorid1 ,
                                             string AV111Postulacioneswwds_6_serviciosnombre1 ,
                                             bool AV112Postulacioneswwds_7_dynamicfiltersenabled2 ,
                                             string AV113Postulacioneswwds_8_dynamicfiltersselector2 ,
                                             short AV114Postulacioneswwds_9_dynamicfiltersoperator2 ,
                                             string AV115Postulacioneswwds_10_postulacionesproveedornombre2 ,
                                             long AV116Postulacioneswwds_11_postulacionesproveedorid2 ,
                                             string AV117Postulacioneswwds_12_serviciosnombre2 ,
                                             bool AV118Postulacioneswwds_13_dynamicfiltersenabled3 ,
                                             string AV119Postulacioneswwds_14_dynamicfiltersselector3 ,
                                             short AV120Postulacioneswwds_15_dynamicfiltersoperator3 ,
                                             string AV121Postulacioneswwds_16_postulacionesproveedornombre3 ,
                                             long AV122Postulacioneswwds_17_postulacionesproveedorid3 ,
                                             string AV123Postulacioneswwds_18_serviciosnombre3 ,
                                             long AV124Postulacioneswwds_19_tfpostulacionesid ,
                                             long AV125Postulacioneswwds_20_tfpostulacionesid_to ,
                                             long AV126Postulacioneswwds_21_tfserviciosid ,
                                             long AV127Postulacioneswwds_22_tfserviciosid_to ,
                                             string AV129Postulacioneswwds_24_tfserviciosnombre_sel ,
                                             string AV128Postulacioneswwds_23_tfserviciosnombre ,
                                             long AV130Postulacioneswwds_25_tfpostulacionesproveedorid ,
                                             long AV131Postulacioneswwds_26_tfpostulacionesproveedorid_to ,
                                             string AV133Postulacioneswwds_28_tfpostulacionesproveedornombre_sel ,
                                             string AV132Postulacioneswwds_27_tfpostulacionesproveedornombre ,
                                             decimal AV134Postulacioneswwds_29_tfpostulacionesprecio ,
                                             decimal AV135Postulacioneswwds_30_tfpostulacionesprecio_to ,
                                             short AV136Postulacioneswwds_31_tfpostulacionesmultimediaserial ,
                                             short AV137Postulacioneswwds_32_tfpostulacionesmultimediaserial_to ,
                                             string AV141Postulacioneswwds_36_tfpostulacionesdescripcion_sel ,
                                             string AV140Postulacioneswwds_35_tfpostulacionesdescripcion ,
                                             short AV142Postulacioneswwds_37_tfpostulacionesreqsuministros_sel ,
                                             string AV144Postulacioneswwds_39_tfpostulacionessuministrosdescripcion_sel ,
                                             string AV143Postulacioneswwds_38_tfpostulacionessuministrosdescripcion ,
                                             DateTime AV145Postulacioneswwds_40_tfpostulacionesfechatrabajo ,
                                             DateTime AV146Postulacioneswwds_41_tfpostulacionesfechatrabajo_to ,
                                             DateTime AV147Postulacioneswwds_42_tfpostulacionesfechacierre ,
                                             DateTime AV148Postulacioneswwds_43_tfpostulacionesfechacierre_to ,
                                             string AV150Postulacioneswwds_45_tfpostulacioneshoracierre_sel ,
                                             string AV149Postulacioneswwds_44_tfpostulacioneshoracierre ,
                                             string AV152Postulacioneswwds_47_tfpostulacionestipofecha_sel ,
                                             string AV151Postulacioneswwds_46_tfpostulacionestipofecha ,
                                             string AV154Postulacioneswwds_49_tfpostulacionesrgohoraservicio_sel ,
                                             string AV153Postulacioneswwds_48_tfpostulacionesrgohoraservicio ,
                                             string AV156Postulacioneswwds_51_tfpostulacionesapellidonombre_sel ,
                                             string AV155Postulacioneswwds_50_tfpostulacionesapellidonombre ,
                                             string AV158Postulacioneswwds_53_tfpostulacionesmail_sel ,
                                             string AV157Postulacioneswwds_52_tfpostulacionesmail ,
                                             string AV160Postulacioneswwds_55_tfpostulacionestelefono_sel ,
                                             string AV159Postulacioneswwds_54_tfpostulacionestelefono ,
                                             DateTime AV161Postulacioneswwds_56_tfpostulacionesfechaalta ,
                                             DateTime AV162Postulacioneswwds_57_tfpostulacionesfechaalta_to ,
                                             int AV163Postulacioneswwds_58_tfpostulacionesestado_sels_Count ,
                                             long AV164Postulacioneswwds_59_tfpostulacionessecuserid ,
                                             long AV165Postulacioneswwds_60_tfpostulacionessecuserid_to ,
                                             string A969PostulacionesProveedorNombre ,
                                             long A945PostulacionesProveedorId ,
                                             string A943ServiciosNombre ,
                                             long A422PostulacionesId ,
                                             long A942ServiciosId ,
                                             decimal A946PostulacionesPrecio ,
                                             short A961PostulacionesMultimediaSerial ,
                                             string A936PostulacionesDescripcion ,
                                             bool A937PostulacionesReqSuministros ,
                                             string A938PostulacionesSuministrosDescri ,
                                             DateTime A947PostulacionesFechaTrabajo ,
                                             DateTime A939PostulacionesFechaCierre ,
                                             string A940PostulacionesHoraCierre ,
                                             string A941PostulacionesTipoFecha ,
                                             string A949PostulacionesRgoHoraservicio ,
                                             string A950PostulacionesApellidoNombre ,
                                             string A951PostulacionesMail ,
                                             string A952PostulacionesTelefono ,
                                             DateTime A425PostulacionesFechaAlta ,
                                             long A948PostulacionesSecUserId ,
                                             string AV106Postulacioneswwds_1_filterfulltext ,
                                             long A970PostulacionesSolicitudesId ,
                                             long AV138Postulacioneswwds_33_tfpostulacionessolicitudesid ,
                                             long AV139Postulacioneswwds_34_tfpostulacionessolicitudesid_to )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int8 = new short[64];
         Object[] GXv_Object9 = new Object[2];
         scmdbuf = "SELECT T1.[PostulacionesSuministrosDescri], T1.[PostulacionesSecUserId], T1.[PostulacionesFechaAlta], T1.[PostulacionesTelefono], T1.[PostulacionesMail], T1.[PostulacionesApellidoNombre], T1.[PostulacionesRgoHoraservicio], T1.[PostulacionesTipoFecha], T1.[PostulacionesHoraCierre], T1.[PostulacionesFechaCierre], T1.[PostulacionesFechaTrabajo], T1.[PostulacionesReqSuministros], T1.[PostulacionesDescripcion], T1.[PostulacionesMultimediaSerial], T1.[PostulacionesPrecio], T3.[ProveedorNombre] AS PostulacionesProveedorNombre, T2.[ServiciosNombre], T1.[ServiciosId], T1.[PostulacionesId], T1.[PostulacionesProveedorId] AS PostulacionesProveedorId, T1.[PostulacionesEstado], COALESCE( T4.[PostulacionesSolicitudesId], 0) AS PostulacionesSolicitudesId FROM (([Postulaciones] T1 LEFT JOIN [Servicios] T2 ON T2.[ServiciosId] = T1.[ServiciosId]) INNER JOIN [Proveedor] T3 ON T3.[ProveedorID] = T1.[PostulacionesProveedorId]),  (SELECT MIN([SolicitudesID]) AS PostulacionesSolicitudesId FROM [Solicitudes] WHERE [PostulacionesId] = @PostulacionesId ) T4";
         AddWhere(sWhereString, "((@AV138Postulacioneswwds_33_tfpostulacionessolicitudesid = convert(int, 0)) or ( COALESCE( T4.[PostulacionesSolicitudesId], 0) >= @AV138Postulacioneswwds_33_tfpostulacionessolicitudesid))");
         AddWhere(sWhereString, "((@AV139Postulacioneswwds_34_tfpostulacionessolicitudesid_to = convert(int, 0)) or ( COALESCE( T4.[PostulacionesSolicitudesId], 0) <= @AV139Postulacioneswwds_34_tfpostulacionessolicitudesid_to))");
         if ( ( StringUtil.StrCmp(AV107Postulacioneswwds_2_dynamicfiltersselector1, "POSTULACIONESPROVEEDORNOMBRE") == 0 ) && ( AV108Postulacioneswwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV109Postulacioneswwds_4_postulacionesproveedornombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T3.[ProveedorNombre]) like UPPER(@lV109Postulacioneswwds_4_postulacionesproveedornombre1))");
         }
         else
         {
            GXv_int8[5] = 1;
         }
         if ( ( StringUtil.StrCmp(AV107Postulacioneswwds_2_dynamicfiltersselector1, "POSTULACIONESPROVEEDORNOMBRE") == 0 ) && ( AV108Postulacioneswwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV109Postulacioneswwds_4_postulacionesproveedornombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T3.[ProveedorNombre]) like '%' + UPPER(@lV109Postulacioneswwds_4_postulacionesproveedornombre1))");
         }
         else
         {
            GXv_int8[6] = 1;
         }
         if ( ( StringUtil.StrCmp(AV107Postulacioneswwds_2_dynamicfiltersselector1, "POSTULACIONESPROVEEDORID") == 0 ) && ( AV108Postulacioneswwds_3_dynamicfiltersoperator1 == 0 ) && ( ! (0==AV110Postulacioneswwds_5_postulacionesproveedorid1) ) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesProveedorId] < @AV110Postulacioneswwds_5_postulacionesproveedorid1)");
         }
         else
         {
            GXv_int8[7] = 1;
         }
         if ( ( StringUtil.StrCmp(AV107Postulacioneswwds_2_dynamicfiltersselector1, "POSTULACIONESPROVEEDORID") == 0 ) && ( AV108Postulacioneswwds_3_dynamicfiltersoperator1 == 1 ) && ( ! (0==AV110Postulacioneswwds_5_postulacionesproveedorid1) ) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesProveedorId] = @AV110Postulacioneswwds_5_postulacionesproveedorid1)");
         }
         else
         {
            GXv_int8[8] = 1;
         }
         if ( ( StringUtil.StrCmp(AV107Postulacioneswwds_2_dynamicfiltersselector1, "POSTULACIONESPROVEEDORID") == 0 ) && ( AV108Postulacioneswwds_3_dynamicfiltersoperator1 == 2 ) && ( ! (0==AV110Postulacioneswwds_5_postulacionesproveedorid1) ) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesProveedorId] > @AV110Postulacioneswwds_5_postulacionesproveedorid1)");
         }
         else
         {
            GXv_int8[9] = 1;
         }
         if ( ( StringUtil.StrCmp(AV107Postulacioneswwds_2_dynamicfiltersselector1, "SERVICIOSNOMBRE") == 0 ) && ( AV108Postulacioneswwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV111Postulacioneswwds_6_serviciosnombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ServiciosNombre]) like UPPER(@lV111Postulacioneswwds_6_serviciosnombre1))");
         }
         else
         {
            GXv_int8[10] = 1;
         }
         if ( ( StringUtil.StrCmp(AV107Postulacioneswwds_2_dynamicfiltersselector1, "SERVICIOSNOMBRE") == 0 ) && ( AV108Postulacioneswwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV111Postulacioneswwds_6_serviciosnombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ServiciosNombre]) like '%' + UPPER(@lV111Postulacioneswwds_6_serviciosnombre1))");
         }
         else
         {
            GXv_int8[11] = 1;
         }
         if ( AV112Postulacioneswwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV113Postulacioneswwds_8_dynamicfiltersselector2, "POSTULACIONESPROVEEDORNOMBRE") == 0 ) && ( AV114Postulacioneswwds_9_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV115Postulacioneswwds_10_postulacionesproveedornombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T3.[ProveedorNombre]) like UPPER(@lV115Postulacioneswwds_10_postulacionesproveedornombre2))");
         }
         else
         {
            GXv_int8[12] = 1;
         }
         if ( AV112Postulacioneswwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV113Postulacioneswwds_8_dynamicfiltersselector2, "POSTULACIONESPROVEEDORNOMBRE") == 0 ) && ( AV114Postulacioneswwds_9_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV115Postulacioneswwds_10_postulacionesproveedornombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T3.[ProveedorNombre]) like '%' + UPPER(@lV115Postulacioneswwds_10_postulacionesproveedornombre2))");
         }
         else
         {
            GXv_int8[13] = 1;
         }
         if ( AV112Postulacioneswwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV113Postulacioneswwds_8_dynamicfiltersselector2, "POSTULACIONESPROVEEDORID") == 0 ) && ( AV114Postulacioneswwds_9_dynamicfiltersoperator2 == 0 ) && ( ! (0==AV116Postulacioneswwds_11_postulacionesproveedorid2) ) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesProveedorId] < @AV116Postulacioneswwds_11_postulacionesproveedorid2)");
         }
         else
         {
            GXv_int8[14] = 1;
         }
         if ( AV112Postulacioneswwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV113Postulacioneswwds_8_dynamicfiltersselector2, "POSTULACIONESPROVEEDORID") == 0 ) && ( AV114Postulacioneswwds_9_dynamicfiltersoperator2 == 1 ) && ( ! (0==AV116Postulacioneswwds_11_postulacionesproveedorid2) ) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesProveedorId] = @AV116Postulacioneswwds_11_postulacionesproveedorid2)");
         }
         else
         {
            GXv_int8[15] = 1;
         }
         if ( AV112Postulacioneswwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV113Postulacioneswwds_8_dynamicfiltersselector2, "POSTULACIONESPROVEEDORID") == 0 ) && ( AV114Postulacioneswwds_9_dynamicfiltersoperator2 == 2 ) && ( ! (0==AV116Postulacioneswwds_11_postulacionesproveedorid2) ) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesProveedorId] > @AV116Postulacioneswwds_11_postulacionesproveedorid2)");
         }
         else
         {
            GXv_int8[16] = 1;
         }
         if ( AV112Postulacioneswwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV113Postulacioneswwds_8_dynamicfiltersselector2, "SERVICIOSNOMBRE") == 0 ) && ( AV114Postulacioneswwds_9_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV117Postulacioneswwds_12_serviciosnombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ServiciosNombre]) like UPPER(@lV117Postulacioneswwds_12_serviciosnombre2))");
         }
         else
         {
            GXv_int8[17] = 1;
         }
         if ( AV112Postulacioneswwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV113Postulacioneswwds_8_dynamicfiltersselector2, "SERVICIOSNOMBRE") == 0 ) && ( AV114Postulacioneswwds_9_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV117Postulacioneswwds_12_serviciosnombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ServiciosNombre]) like '%' + UPPER(@lV117Postulacioneswwds_12_serviciosnombre2))");
         }
         else
         {
            GXv_int8[18] = 1;
         }
         if ( AV118Postulacioneswwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV119Postulacioneswwds_14_dynamicfiltersselector3, "POSTULACIONESPROVEEDORNOMBRE") == 0 ) && ( AV120Postulacioneswwds_15_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV121Postulacioneswwds_16_postulacionesproveedornombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T3.[ProveedorNombre]) like UPPER(@lV121Postulacioneswwds_16_postulacionesproveedornombre3))");
         }
         else
         {
            GXv_int8[19] = 1;
         }
         if ( AV118Postulacioneswwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV119Postulacioneswwds_14_dynamicfiltersselector3, "POSTULACIONESPROVEEDORNOMBRE") == 0 ) && ( AV120Postulacioneswwds_15_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV121Postulacioneswwds_16_postulacionesproveedornombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T3.[ProveedorNombre]) like '%' + UPPER(@lV121Postulacioneswwds_16_postulacionesproveedornombre3))");
         }
         else
         {
            GXv_int8[20] = 1;
         }
         if ( AV118Postulacioneswwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV119Postulacioneswwds_14_dynamicfiltersselector3, "POSTULACIONESPROVEEDORID") == 0 ) && ( AV120Postulacioneswwds_15_dynamicfiltersoperator3 == 0 ) && ( ! (0==AV122Postulacioneswwds_17_postulacionesproveedorid3) ) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesProveedorId] < @AV122Postulacioneswwds_17_postulacionesproveedorid3)");
         }
         else
         {
            GXv_int8[21] = 1;
         }
         if ( AV118Postulacioneswwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV119Postulacioneswwds_14_dynamicfiltersselector3, "POSTULACIONESPROVEEDORID") == 0 ) && ( AV120Postulacioneswwds_15_dynamicfiltersoperator3 == 1 ) && ( ! (0==AV122Postulacioneswwds_17_postulacionesproveedorid3) ) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesProveedorId] = @AV122Postulacioneswwds_17_postulacionesproveedorid3)");
         }
         else
         {
            GXv_int8[22] = 1;
         }
         if ( AV118Postulacioneswwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV119Postulacioneswwds_14_dynamicfiltersselector3, "POSTULACIONESPROVEEDORID") == 0 ) && ( AV120Postulacioneswwds_15_dynamicfiltersoperator3 == 2 ) && ( ! (0==AV122Postulacioneswwds_17_postulacionesproveedorid3) ) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesProveedorId] > @AV122Postulacioneswwds_17_postulacionesproveedorid3)");
         }
         else
         {
            GXv_int8[23] = 1;
         }
         if ( AV118Postulacioneswwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV119Postulacioneswwds_14_dynamicfiltersselector3, "SERVICIOSNOMBRE") == 0 ) && ( AV120Postulacioneswwds_15_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV123Postulacioneswwds_18_serviciosnombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ServiciosNombre]) like UPPER(@lV123Postulacioneswwds_18_serviciosnombre3))");
         }
         else
         {
            GXv_int8[24] = 1;
         }
         if ( AV118Postulacioneswwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV119Postulacioneswwds_14_dynamicfiltersselector3, "SERVICIOSNOMBRE") == 0 ) && ( AV120Postulacioneswwds_15_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV123Postulacioneswwds_18_serviciosnombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ServiciosNombre]) like '%' + UPPER(@lV123Postulacioneswwds_18_serviciosnombre3))");
         }
         else
         {
            GXv_int8[25] = 1;
         }
         if ( ! (0==AV124Postulacioneswwds_19_tfpostulacionesid) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesId] >= @AV124Postulacioneswwds_19_tfpostulacionesid)");
         }
         else
         {
            GXv_int8[26] = 1;
         }
         if ( ! (0==AV125Postulacioneswwds_20_tfpostulacionesid_to) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesId] <= @AV125Postulacioneswwds_20_tfpostulacionesid_to)");
         }
         else
         {
            GXv_int8[27] = 1;
         }
         if ( ! (0==AV126Postulacioneswwds_21_tfserviciosid) )
         {
            AddWhere(sWhereString, "(T1.[ServiciosId] >= @AV126Postulacioneswwds_21_tfserviciosid)");
         }
         else
         {
            GXv_int8[28] = 1;
         }
         if ( ! (0==AV127Postulacioneswwds_22_tfserviciosid_to) )
         {
            AddWhere(sWhereString, "(T1.[ServiciosId] <= @AV127Postulacioneswwds_22_tfserviciosid_to)");
         }
         else
         {
            GXv_int8[29] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV129Postulacioneswwds_24_tfserviciosnombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV128Postulacioneswwds_23_tfserviciosnombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ServiciosNombre]) like UPPER(@lV128Postulacioneswwds_23_tfserviciosnombre))");
         }
         else
         {
            GXv_int8[30] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV129Postulacioneswwds_24_tfserviciosnombre_sel)) && ! ( StringUtil.StrCmp(AV129Postulacioneswwds_24_tfserviciosnombre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.[ServiciosNombre] = @AV129Postulacioneswwds_24_tfserviciosnombre_sel)");
         }
         else
         {
            GXv_int8[31] = 1;
         }
         if ( StringUtil.StrCmp(AV129Postulacioneswwds_24_tfserviciosnombre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T2.[ServiciosNombre] IS NULL or (T2.[ServiciosNombre] = ''))");
         }
         if ( ! (0==AV130Postulacioneswwds_25_tfpostulacionesproveedorid) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesProveedorId] >= @AV130Postulacioneswwds_25_tfpostulacionesproveedorid)");
         }
         else
         {
            GXv_int8[32] = 1;
         }
         if ( ! (0==AV131Postulacioneswwds_26_tfpostulacionesproveedorid_to) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesProveedorId] <= @AV131Postulacioneswwds_26_tfpostulacionesproveedorid_to)");
         }
         else
         {
            GXv_int8[33] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV133Postulacioneswwds_28_tfpostulacionesproveedornombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV132Postulacioneswwds_27_tfpostulacionesproveedornombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T3.[ProveedorNombre]) like UPPER(@lV132Postulacioneswwds_27_tfpostulacionesproveedornombre))");
         }
         else
         {
            GXv_int8[34] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV133Postulacioneswwds_28_tfpostulacionesproveedornombre_sel)) && ! ( StringUtil.StrCmp(AV133Postulacioneswwds_28_tfpostulacionesproveedornombre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T3.[ProveedorNombre] = @AV133Postulacioneswwds_28_tfpostulacionesproveedornombre_sel)");
         }
         else
         {
            GXv_int8[35] = 1;
         }
         if ( StringUtil.StrCmp(AV133Postulacioneswwds_28_tfpostulacionesproveedornombre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T3.[ProveedorNombre] = ''))");
         }
         if ( ! (Convert.ToDecimal(0)==AV134Postulacioneswwds_29_tfpostulacionesprecio) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesPrecio] >= @AV134Postulacioneswwds_29_tfpostulacionesprecio)");
         }
         else
         {
            GXv_int8[36] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV135Postulacioneswwds_30_tfpostulacionesprecio_to) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesPrecio] <= @AV135Postulacioneswwds_30_tfpostulacionesprecio_to)");
         }
         else
         {
            GXv_int8[37] = 1;
         }
         if ( ! (0==AV136Postulacioneswwds_31_tfpostulacionesmultimediaserial) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesMultimediaSerial] >= @AV136Postulacioneswwds_31_tfpostulacionesmultimediaserial)");
         }
         else
         {
            GXv_int8[38] = 1;
         }
         if ( ! (0==AV137Postulacioneswwds_32_tfpostulacionesmultimediaserial_to) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesMultimediaSerial] <= @AV137Postulacioneswwds_32_tfpostulacionesmultimediaserial_to)");
         }
         else
         {
            GXv_int8[39] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV141Postulacioneswwds_36_tfpostulacionesdescripcion_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV140Postulacioneswwds_35_tfpostulacionesdescripcion)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[PostulacionesDescripcion]) like UPPER(@lV140Postulacioneswwds_35_tfpostulacionesdescripcion))");
         }
         else
         {
            GXv_int8[40] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV141Postulacioneswwds_36_tfpostulacionesdescripcion_sel)) && ! ( StringUtil.StrCmp(AV141Postulacioneswwds_36_tfpostulacionesdescripcion_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesDescripcion] = @AV141Postulacioneswwds_36_tfpostulacionesdescripcion_sel)");
         }
         else
         {
            GXv_int8[41] = 1;
         }
         if ( StringUtil.StrCmp(AV141Postulacioneswwds_36_tfpostulacionesdescripcion_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[PostulacionesDescripcion] = ''))");
         }
         if ( AV142Postulacioneswwds_37_tfpostulacionesreqsuministros_sel == 1 )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesReqSuministros] = 1)");
         }
         if ( AV142Postulacioneswwds_37_tfpostulacionesreqsuministros_sel == 2 )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesReqSuministros] = 0)");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV144Postulacioneswwds_39_tfpostulacionessuministrosdescripcion_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV143Postulacioneswwds_38_tfpostulacionessuministrosdescripcion)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[PostulacionesSuministrosDescri]) like UPPER(@lV143Postulacioneswwds_38_tfpostulacionessuministrosdescripcion))");
         }
         else
         {
            GXv_int8[42] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV144Postulacioneswwds_39_tfpostulacionessuministrosdescripcion_sel)) && ! ( StringUtil.StrCmp(AV144Postulacioneswwds_39_tfpostulacionessuministrosdescripcion_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesSuministrosDescri] = @AV144Postulacioneswwds_39_tfpostulacionessuministrosdescripcion_sel)");
         }
         else
         {
            GXv_int8[43] = 1;
         }
         if ( StringUtil.StrCmp(AV144Postulacioneswwds_39_tfpostulacionessuministrosdescripcion_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[PostulacionesSuministrosDescri] = ''))");
         }
         if ( ! (DateTime.MinValue==AV145Postulacioneswwds_40_tfpostulacionesfechatrabajo) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesFechaTrabajo] >= @AV145Postulacioneswwds_40_tfpostulacionesfechatrabajo)");
         }
         else
         {
            GXv_int8[44] = 1;
         }
         if ( ! (DateTime.MinValue==AV146Postulacioneswwds_41_tfpostulacionesfechatrabajo_to) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesFechaTrabajo] <= @AV146Postulacioneswwds_41_tfpostulacionesfechatrabajo_to)");
         }
         else
         {
            GXv_int8[45] = 1;
         }
         if ( ! (DateTime.MinValue==AV147Postulacioneswwds_42_tfpostulacionesfechacierre) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesFechaCierre] >= @AV147Postulacioneswwds_42_tfpostulacionesfechacierre)");
         }
         else
         {
            GXv_int8[46] = 1;
         }
         if ( ! (DateTime.MinValue==AV148Postulacioneswwds_43_tfpostulacionesfechacierre_to) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesFechaCierre] <= @AV148Postulacioneswwds_43_tfpostulacionesfechacierre_to)");
         }
         else
         {
            GXv_int8[47] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV150Postulacioneswwds_45_tfpostulacioneshoracierre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV149Postulacioneswwds_44_tfpostulacioneshoracierre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[PostulacionesHoraCierre]) like UPPER(@lV149Postulacioneswwds_44_tfpostulacioneshoracierre))");
         }
         else
         {
            GXv_int8[48] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV150Postulacioneswwds_45_tfpostulacioneshoracierre_sel)) && ! ( StringUtil.StrCmp(AV150Postulacioneswwds_45_tfpostulacioneshoracierre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesHoraCierre] = @AV150Postulacioneswwds_45_tfpostulacioneshoracierre_sel)");
         }
         else
         {
            GXv_int8[49] = 1;
         }
         if ( StringUtil.StrCmp(AV150Postulacioneswwds_45_tfpostulacioneshoracierre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[PostulacionesHoraCierre] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV152Postulacioneswwds_47_tfpostulacionestipofecha_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV151Postulacioneswwds_46_tfpostulacionestipofecha)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[PostulacionesTipoFecha]) like UPPER(@lV151Postulacioneswwds_46_tfpostulacionestipofecha))");
         }
         else
         {
            GXv_int8[50] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV152Postulacioneswwds_47_tfpostulacionestipofecha_sel)) && ! ( StringUtil.StrCmp(AV152Postulacioneswwds_47_tfpostulacionestipofecha_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesTipoFecha] = @AV152Postulacioneswwds_47_tfpostulacionestipofecha_sel)");
         }
         else
         {
            GXv_int8[51] = 1;
         }
         if ( StringUtil.StrCmp(AV152Postulacioneswwds_47_tfpostulacionestipofecha_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[PostulacionesTipoFecha] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV154Postulacioneswwds_49_tfpostulacionesrgohoraservicio_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV153Postulacioneswwds_48_tfpostulacionesrgohoraservicio)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[PostulacionesRgoHoraservicio]) like UPPER(@lV153Postulacioneswwds_48_tfpostulacionesrgohoraservicio))");
         }
         else
         {
            GXv_int8[52] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV154Postulacioneswwds_49_tfpostulacionesrgohoraservicio_sel)) && ! ( StringUtil.StrCmp(AV154Postulacioneswwds_49_tfpostulacionesrgohoraservicio_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesRgoHoraservicio] = @AV154Postulacioneswwds_49_tfpostulacionesrgohoraservicio_sel)");
         }
         else
         {
            GXv_int8[53] = 1;
         }
         if ( StringUtil.StrCmp(AV154Postulacioneswwds_49_tfpostulacionesrgohoraservicio_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[PostulacionesRgoHoraservicio] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV156Postulacioneswwds_51_tfpostulacionesapellidonombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV155Postulacioneswwds_50_tfpostulacionesapellidonombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[PostulacionesApellidoNombre]) like UPPER(@lV155Postulacioneswwds_50_tfpostulacionesapellidonombre))");
         }
         else
         {
            GXv_int8[54] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV156Postulacioneswwds_51_tfpostulacionesapellidonombre_sel)) && ! ( StringUtil.StrCmp(AV156Postulacioneswwds_51_tfpostulacionesapellidonombre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesApellidoNombre] = @AV156Postulacioneswwds_51_tfpostulacionesapellidonombre_sel)");
         }
         else
         {
            GXv_int8[55] = 1;
         }
         if ( StringUtil.StrCmp(AV156Postulacioneswwds_51_tfpostulacionesapellidonombre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[PostulacionesApellidoNombre] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV158Postulacioneswwds_53_tfpostulacionesmail_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV157Postulacioneswwds_52_tfpostulacionesmail)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[PostulacionesMail]) like UPPER(@lV157Postulacioneswwds_52_tfpostulacionesmail))");
         }
         else
         {
            GXv_int8[56] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV158Postulacioneswwds_53_tfpostulacionesmail_sel)) && ! ( StringUtil.StrCmp(AV158Postulacioneswwds_53_tfpostulacionesmail_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesMail] = @AV158Postulacioneswwds_53_tfpostulacionesmail_sel)");
         }
         else
         {
            GXv_int8[57] = 1;
         }
         if ( StringUtil.StrCmp(AV158Postulacioneswwds_53_tfpostulacionesmail_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[PostulacionesMail] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV160Postulacioneswwds_55_tfpostulacionestelefono_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV159Postulacioneswwds_54_tfpostulacionestelefono)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[PostulacionesTelefono]) like UPPER(@lV159Postulacioneswwds_54_tfpostulacionestelefono))");
         }
         else
         {
            GXv_int8[58] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV160Postulacioneswwds_55_tfpostulacionestelefono_sel)) && ! ( StringUtil.StrCmp(AV160Postulacioneswwds_55_tfpostulacionestelefono_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesTelefono] = @AV160Postulacioneswwds_55_tfpostulacionestelefono_sel)");
         }
         else
         {
            GXv_int8[59] = 1;
         }
         if ( StringUtil.StrCmp(AV160Postulacioneswwds_55_tfpostulacionestelefono_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[PostulacionesTelefono] = ''))");
         }
         if ( ! (DateTime.MinValue==AV161Postulacioneswwds_56_tfpostulacionesfechaalta) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesFechaAlta] >= @AV161Postulacioneswwds_56_tfpostulacionesfechaalta)");
         }
         else
         {
            GXv_int8[60] = 1;
         }
         if ( ! (DateTime.MinValue==AV162Postulacioneswwds_57_tfpostulacionesfechaalta_to) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesFechaAlta] <= @AV162Postulacioneswwds_57_tfpostulacionesfechaalta_to)");
         }
         else
         {
            GXv_int8[61] = 1;
         }
         if ( AV163Postulacioneswwds_58_tfpostulacionesestado_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV163Postulacioneswwds_58_tfpostulacionesestado_sels, "T1.[PostulacionesEstado] IN (", ")")+")");
         }
         if ( ! (0==AV164Postulacioneswwds_59_tfpostulacionessecuserid) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesSecUserId] >= @AV164Postulacioneswwds_59_tfpostulacionessecuserid)");
         }
         else
         {
            GXv_int8[62] = 1;
         }
         if ( ! (0==AV165Postulacioneswwds_60_tfpostulacionessecuserid_to) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesSecUserId] <= @AV165Postulacioneswwds_60_tfpostulacionessecuserid_to)");
         }
         else
         {
            GXv_int8[63] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[PostulacionesSuministrosDescri]";
         GXv_Object9[0] = scmdbuf;
         GXv_Object9[1] = GXv_int8;
         return GXv_Object9 ;
      }

      protected Object[] conditional_P00LA11( IGxContext context ,
                                              string A424PostulacionesEstado ,
                                              GxSimpleCollection<string> AV163Postulacioneswwds_58_tfpostulacionesestado_sels ,
                                              string AV107Postulacioneswwds_2_dynamicfiltersselector1 ,
                                              short AV108Postulacioneswwds_3_dynamicfiltersoperator1 ,
                                              string AV109Postulacioneswwds_4_postulacionesproveedornombre1 ,
                                              long AV110Postulacioneswwds_5_postulacionesproveedorid1 ,
                                              string AV111Postulacioneswwds_6_serviciosnombre1 ,
                                              bool AV112Postulacioneswwds_7_dynamicfiltersenabled2 ,
                                              string AV113Postulacioneswwds_8_dynamicfiltersselector2 ,
                                              short AV114Postulacioneswwds_9_dynamicfiltersoperator2 ,
                                              string AV115Postulacioneswwds_10_postulacionesproveedornombre2 ,
                                              long AV116Postulacioneswwds_11_postulacionesproveedorid2 ,
                                              string AV117Postulacioneswwds_12_serviciosnombre2 ,
                                              bool AV118Postulacioneswwds_13_dynamicfiltersenabled3 ,
                                              string AV119Postulacioneswwds_14_dynamicfiltersselector3 ,
                                              short AV120Postulacioneswwds_15_dynamicfiltersoperator3 ,
                                              string AV121Postulacioneswwds_16_postulacionesproveedornombre3 ,
                                              long AV122Postulacioneswwds_17_postulacionesproveedorid3 ,
                                              string AV123Postulacioneswwds_18_serviciosnombre3 ,
                                              long AV124Postulacioneswwds_19_tfpostulacionesid ,
                                              long AV125Postulacioneswwds_20_tfpostulacionesid_to ,
                                              long AV126Postulacioneswwds_21_tfserviciosid ,
                                              long AV127Postulacioneswwds_22_tfserviciosid_to ,
                                              string AV129Postulacioneswwds_24_tfserviciosnombre_sel ,
                                              string AV128Postulacioneswwds_23_tfserviciosnombre ,
                                              long AV130Postulacioneswwds_25_tfpostulacionesproveedorid ,
                                              long AV131Postulacioneswwds_26_tfpostulacionesproveedorid_to ,
                                              string AV133Postulacioneswwds_28_tfpostulacionesproveedornombre_sel ,
                                              string AV132Postulacioneswwds_27_tfpostulacionesproveedornombre ,
                                              decimal AV134Postulacioneswwds_29_tfpostulacionesprecio ,
                                              decimal AV135Postulacioneswwds_30_tfpostulacionesprecio_to ,
                                              short AV136Postulacioneswwds_31_tfpostulacionesmultimediaserial ,
                                              short AV137Postulacioneswwds_32_tfpostulacionesmultimediaserial_to ,
                                              string AV141Postulacioneswwds_36_tfpostulacionesdescripcion_sel ,
                                              string AV140Postulacioneswwds_35_tfpostulacionesdescripcion ,
                                              short AV142Postulacioneswwds_37_tfpostulacionesreqsuministros_sel ,
                                              string AV144Postulacioneswwds_39_tfpostulacionessuministrosdescripcion_sel ,
                                              string AV143Postulacioneswwds_38_tfpostulacionessuministrosdescripcion ,
                                              DateTime AV145Postulacioneswwds_40_tfpostulacionesfechatrabajo ,
                                              DateTime AV146Postulacioneswwds_41_tfpostulacionesfechatrabajo_to ,
                                              DateTime AV147Postulacioneswwds_42_tfpostulacionesfechacierre ,
                                              DateTime AV148Postulacioneswwds_43_tfpostulacionesfechacierre_to ,
                                              string AV150Postulacioneswwds_45_tfpostulacioneshoracierre_sel ,
                                              string AV149Postulacioneswwds_44_tfpostulacioneshoracierre ,
                                              string AV152Postulacioneswwds_47_tfpostulacionestipofecha_sel ,
                                              string AV151Postulacioneswwds_46_tfpostulacionestipofecha ,
                                              string AV154Postulacioneswwds_49_tfpostulacionesrgohoraservicio_sel ,
                                              string AV153Postulacioneswwds_48_tfpostulacionesrgohoraservicio ,
                                              string AV156Postulacioneswwds_51_tfpostulacionesapellidonombre_sel ,
                                              string AV155Postulacioneswwds_50_tfpostulacionesapellidonombre ,
                                              string AV158Postulacioneswwds_53_tfpostulacionesmail_sel ,
                                              string AV157Postulacioneswwds_52_tfpostulacionesmail ,
                                              string AV160Postulacioneswwds_55_tfpostulacionestelefono_sel ,
                                              string AV159Postulacioneswwds_54_tfpostulacionestelefono ,
                                              DateTime AV161Postulacioneswwds_56_tfpostulacionesfechaalta ,
                                              DateTime AV162Postulacioneswwds_57_tfpostulacionesfechaalta_to ,
                                              int AV163Postulacioneswwds_58_tfpostulacionesestado_sels_Count ,
                                              long AV164Postulacioneswwds_59_tfpostulacionessecuserid ,
                                              long AV165Postulacioneswwds_60_tfpostulacionessecuserid_to ,
                                              string A969PostulacionesProveedorNombre ,
                                              long A945PostulacionesProveedorId ,
                                              string A943ServiciosNombre ,
                                              long A422PostulacionesId ,
                                              long A942ServiciosId ,
                                              decimal A946PostulacionesPrecio ,
                                              short A961PostulacionesMultimediaSerial ,
                                              string A936PostulacionesDescripcion ,
                                              bool A937PostulacionesReqSuministros ,
                                              string A938PostulacionesSuministrosDescri ,
                                              DateTime A947PostulacionesFechaTrabajo ,
                                              DateTime A939PostulacionesFechaCierre ,
                                              string A940PostulacionesHoraCierre ,
                                              string A941PostulacionesTipoFecha ,
                                              string A949PostulacionesRgoHoraservicio ,
                                              string A950PostulacionesApellidoNombre ,
                                              string A951PostulacionesMail ,
                                              string A952PostulacionesTelefono ,
                                              DateTime A425PostulacionesFechaAlta ,
                                              long A948PostulacionesSecUserId ,
                                              string AV106Postulacioneswwds_1_filterfulltext ,
                                              long A970PostulacionesSolicitudesId ,
                                              long AV138Postulacioneswwds_33_tfpostulacionessolicitudesid ,
                                              long AV139Postulacioneswwds_34_tfpostulacionessolicitudesid_to )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int10 = new short[64];
         Object[] GXv_Object11 = new Object[2];
         scmdbuf = "SELECT T1.[PostulacionesHoraCierre], T1.[PostulacionesSecUserId], T1.[PostulacionesFechaAlta], T1.[PostulacionesTelefono], T1.[PostulacionesMail], T1.[PostulacionesApellidoNombre], T1.[PostulacionesRgoHoraservicio], T1.[PostulacionesTipoFecha], T1.[PostulacionesFechaCierre], T1.[PostulacionesFechaTrabajo], T1.[PostulacionesSuministrosDescri], T1.[PostulacionesReqSuministros], T1.[PostulacionesDescripcion], T1.[PostulacionesMultimediaSerial], T1.[PostulacionesPrecio], T3.[ProveedorNombre] AS PostulacionesProveedorNombre, T2.[ServiciosNombre], T1.[ServiciosId], T1.[PostulacionesId], T1.[PostulacionesProveedorId] AS PostulacionesProveedorId, T1.[PostulacionesEstado], COALESCE( T4.[PostulacionesSolicitudesId], 0) AS PostulacionesSolicitudesId FROM (([Postulaciones] T1 LEFT JOIN [Servicios] T2 ON T2.[ServiciosId] = T1.[ServiciosId]) INNER JOIN [Proveedor] T3 ON T3.[ProveedorID] = T1.[PostulacionesProveedorId]),  (SELECT MIN([SolicitudesID]) AS PostulacionesSolicitudesId FROM [Solicitudes] WHERE [PostulacionesId] = @PostulacionesId ) T4";
         AddWhere(sWhereString, "((@AV138Postulacioneswwds_33_tfpostulacionessolicitudesid = convert(int, 0)) or ( COALESCE( T4.[PostulacionesSolicitudesId], 0) >= @AV138Postulacioneswwds_33_tfpostulacionessolicitudesid))");
         AddWhere(sWhereString, "((@AV139Postulacioneswwds_34_tfpostulacionessolicitudesid_to = convert(int, 0)) or ( COALESCE( T4.[PostulacionesSolicitudesId], 0) <= @AV139Postulacioneswwds_34_tfpostulacionessolicitudesid_to))");
         if ( ( StringUtil.StrCmp(AV107Postulacioneswwds_2_dynamicfiltersselector1, "POSTULACIONESPROVEEDORNOMBRE") == 0 ) && ( AV108Postulacioneswwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV109Postulacioneswwds_4_postulacionesproveedornombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T3.[ProveedorNombre]) like UPPER(@lV109Postulacioneswwds_4_postulacionesproveedornombre1))");
         }
         else
         {
            GXv_int10[5] = 1;
         }
         if ( ( StringUtil.StrCmp(AV107Postulacioneswwds_2_dynamicfiltersselector1, "POSTULACIONESPROVEEDORNOMBRE") == 0 ) && ( AV108Postulacioneswwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV109Postulacioneswwds_4_postulacionesproveedornombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T3.[ProveedorNombre]) like '%' + UPPER(@lV109Postulacioneswwds_4_postulacionesproveedornombre1))");
         }
         else
         {
            GXv_int10[6] = 1;
         }
         if ( ( StringUtil.StrCmp(AV107Postulacioneswwds_2_dynamicfiltersselector1, "POSTULACIONESPROVEEDORID") == 0 ) && ( AV108Postulacioneswwds_3_dynamicfiltersoperator1 == 0 ) && ( ! (0==AV110Postulacioneswwds_5_postulacionesproveedorid1) ) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesProveedorId] < @AV110Postulacioneswwds_5_postulacionesproveedorid1)");
         }
         else
         {
            GXv_int10[7] = 1;
         }
         if ( ( StringUtil.StrCmp(AV107Postulacioneswwds_2_dynamicfiltersselector1, "POSTULACIONESPROVEEDORID") == 0 ) && ( AV108Postulacioneswwds_3_dynamicfiltersoperator1 == 1 ) && ( ! (0==AV110Postulacioneswwds_5_postulacionesproveedorid1) ) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesProveedorId] = @AV110Postulacioneswwds_5_postulacionesproveedorid1)");
         }
         else
         {
            GXv_int10[8] = 1;
         }
         if ( ( StringUtil.StrCmp(AV107Postulacioneswwds_2_dynamicfiltersselector1, "POSTULACIONESPROVEEDORID") == 0 ) && ( AV108Postulacioneswwds_3_dynamicfiltersoperator1 == 2 ) && ( ! (0==AV110Postulacioneswwds_5_postulacionesproveedorid1) ) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesProveedorId] > @AV110Postulacioneswwds_5_postulacionesproveedorid1)");
         }
         else
         {
            GXv_int10[9] = 1;
         }
         if ( ( StringUtil.StrCmp(AV107Postulacioneswwds_2_dynamicfiltersselector1, "SERVICIOSNOMBRE") == 0 ) && ( AV108Postulacioneswwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV111Postulacioneswwds_6_serviciosnombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ServiciosNombre]) like UPPER(@lV111Postulacioneswwds_6_serviciosnombre1))");
         }
         else
         {
            GXv_int10[10] = 1;
         }
         if ( ( StringUtil.StrCmp(AV107Postulacioneswwds_2_dynamicfiltersselector1, "SERVICIOSNOMBRE") == 0 ) && ( AV108Postulacioneswwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV111Postulacioneswwds_6_serviciosnombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ServiciosNombre]) like '%' + UPPER(@lV111Postulacioneswwds_6_serviciosnombre1))");
         }
         else
         {
            GXv_int10[11] = 1;
         }
         if ( AV112Postulacioneswwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV113Postulacioneswwds_8_dynamicfiltersselector2, "POSTULACIONESPROVEEDORNOMBRE") == 0 ) && ( AV114Postulacioneswwds_9_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV115Postulacioneswwds_10_postulacionesproveedornombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T3.[ProveedorNombre]) like UPPER(@lV115Postulacioneswwds_10_postulacionesproveedornombre2))");
         }
         else
         {
            GXv_int10[12] = 1;
         }
         if ( AV112Postulacioneswwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV113Postulacioneswwds_8_dynamicfiltersselector2, "POSTULACIONESPROVEEDORNOMBRE") == 0 ) && ( AV114Postulacioneswwds_9_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV115Postulacioneswwds_10_postulacionesproveedornombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T3.[ProveedorNombre]) like '%' + UPPER(@lV115Postulacioneswwds_10_postulacionesproveedornombre2))");
         }
         else
         {
            GXv_int10[13] = 1;
         }
         if ( AV112Postulacioneswwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV113Postulacioneswwds_8_dynamicfiltersselector2, "POSTULACIONESPROVEEDORID") == 0 ) && ( AV114Postulacioneswwds_9_dynamicfiltersoperator2 == 0 ) && ( ! (0==AV116Postulacioneswwds_11_postulacionesproveedorid2) ) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesProveedorId] < @AV116Postulacioneswwds_11_postulacionesproveedorid2)");
         }
         else
         {
            GXv_int10[14] = 1;
         }
         if ( AV112Postulacioneswwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV113Postulacioneswwds_8_dynamicfiltersselector2, "POSTULACIONESPROVEEDORID") == 0 ) && ( AV114Postulacioneswwds_9_dynamicfiltersoperator2 == 1 ) && ( ! (0==AV116Postulacioneswwds_11_postulacionesproveedorid2) ) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesProveedorId] = @AV116Postulacioneswwds_11_postulacionesproveedorid2)");
         }
         else
         {
            GXv_int10[15] = 1;
         }
         if ( AV112Postulacioneswwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV113Postulacioneswwds_8_dynamicfiltersselector2, "POSTULACIONESPROVEEDORID") == 0 ) && ( AV114Postulacioneswwds_9_dynamicfiltersoperator2 == 2 ) && ( ! (0==AV116Postulacioneswwds_11_postulacionesproveedorid2) ) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesProveedorId] > @AV116Postulacioneswwds_11_postulacionesproveedorid2)");
         }
         else
         {
            GXv_int10[16] = 1;
         }
         if ( AV112Postulacioneswwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV113Postulacioneswwds_8_dynamicfiltersselector2, "SERVICIOSNOMBRE") == 0 ) && ( AV114Postulacioneswwds_9_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV117Postulacioneswwds_12_serviciosnombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ServiciosNombre]) like UPPER(@lV117Postulacioneswwds_12_serviciosnombre2))");
         }
         else
         {
            GXv_int10[17] = 1;
         }
         if ( AV112Postulacioneswwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV113Postulacioneswwds_8_dynamicfiltersselector2, "SERVICIOSNOMBRE") == 0 ) && ( AV114Postulacioneswwds_9_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV117Postulacioneswwds_12_serviciosnombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ServiciosNombre]) like '%' + UPPER(@lV117Postulacioneswwds_12_serviciosnombre2))");
         }
         else
         {
            GXv_int10[18] = 1;
         }
         if ( AV118Postulacioneswwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV119Postulacioneswwds_14_dynamicfiltersselector3, "POSTULACIONESPROVEEDORNOMBRE") == 0 ) && ( AV120Postulacioneswwds_15_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV121Postulacioneswwds_16_postulacionesproveedornombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T3.[ProveedorNombre]) like UPPER(@lV121Postulacioneswwds_16_postulacionesproveedornombre3))");
         }
         else
         {
            GXv_int10[19] = 1;
         }
         if ( AV118Postulacioneswwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV119Postulacioneswwds_14_dynamicfiltersselector3, "POSTULACIONESPROVEEDORNOMBRE") == 0 ) && ( AV120Postulacioneswwds_15_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV121Postulacioneswwds_16_postulacionesproveedornombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T3.[ProveedorNombre]) like '%' + UPPER(@lV121Postulacioneswwds_16_postulacionesproveedornombre3))");
         }
         else
         {
            GXv_int10[20] = 1;
         }
         if ( AV118Postulacioneswwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV119Postulacioneswwds_14_dynamicfiltersselector3, "POSTULACIONESPROVEEDORID") == 0 ) && ( AV120Postulacioneswwds_15_dynamicfiltersoperator3 == 0 ) && ( ! (0==AV122Postulacioneswwds_17_postulacionesproveedorid3) ) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesProveedorId] < @AV122Postulacioneswwds_17_postulacionesproveedorid3)");
         }
         else
         {
            GXv_int10[21] = 1;
         }
         if ( AV118Postulacioneswwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV119Postulacioneswwds_14_dynamicfiltersselector3, "POSTULACIONESPROVEEDORID") == 0 ) && ( AV120Postulacioneswwds_15_dynamicfiltersoperator3 == 1 ) && ( ! (0==AV122Postulacioneswwds_17_postulacionesproveedorid3) ) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesProveedorId] = @AV122Postulacioneswwds_17_postulacionesproveedorid3)");
         }
         else
         {
            GXv_int10[22] = 1;
         }
         if ( AV118Postulacioneswwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV119Postulacioneswwds_14_dynamicfiltersselector3, "POSTULACIONESPROVEEDORID") == 0 ) && ( AV120Postulacioneswwds_15_dynamicfiltersoperator3 == 2 ) && ( ! (0==AV122Postulacioneswwds_17_postulacionesproveedorid3) ) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesProveedorId] > @AV122Postulacioneswwds_17_postulacionesproveedorid3)");
         }
         else
         {
            GXv_int10[23] = 1;
         }
         if ( AV118Postulacioneswwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV119Postulacioneswwds_14_dynamicfiltersselector3, "SERVICIOSNOMBRE") == 0 ) && ( AV120Postulacioneswwds_15_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV123Postulacioneswwds_18_serviciosnombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ServiciosNombre]) like UPPER(@lV123Postulacioneswwds_18_serviciosnombre3))");
         }
         else
         {
            GXv_int10[24] = 1;
         }
         if ( AV118Postulacioneswwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV119Postulacioneswwds_14_dynamicfiltersselector3, "SERVICIOSNOMBRE") == 0 ) && ( AV120Postulacioneswwds_15_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV123Postulacioneswwds_18_serviciosnombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ServiciosNombre]) like '%' + UPPER(@lV123Postulacioneswwds_18_serviciosnombre3))");
         }
         else
         {
            GXv_int10[25] = 1;
         }
         if ( ! (0==AV124Postulacioneswwds_19_tfpostulacionesid) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesId] >= @AV124Postulacioneswwds_19_tfpostulacionesid)");
         }
         else
         {
            GXv_int10[26] = 1;
         }
         if ( ! (0==AV125Postulacioneswwds_20_tfpostulacionesid_to) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesId] <= @AV125Postulacioneswwds_20_tfpostulacionesid_to)");
         }
         else
         {
            GXv_int10[27] = 1;
         }
         if ( ! (0==AV126Postulacioneswwds_21_tfserviciosid) )
         {
            AddWhere(sWhereString, "(T1.[ServiciosId] >= @AV126Postulacioneswwds_21_tfserviciosid)");
         }
         else
         {
            GXv_int10[28] = 1;
         }
         if ( ! (0==AV127Postulacioneswwds_22_tfserviciosid_to) )
         {
            AddWhere(sWhereString, "(T1.[ServiciosId] <= @AV127Postulacioneswwds_22_tfserviciosid_to)");
         }
         else
         {
            GXv_int10[29] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV129Postulacioneswwds_24_tfserviciosnombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV128Postulacioneswwds_23_tfserviciosnombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ServiciosNombre]) like UPPER(@lV128Postulacioneswwds_23_tfserviciosnombre))");
         }
         else
         {
            GXv_int10[30] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV129Postulacioneswwds_24_tfserviciosnombre_sel)) && ! ( StringUtil.StrCmp(AV129Postulacioneswwds_24_tfserviciosnombre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.[ServiciosNombre] = @AV129Postulacioneswwds_24_tfserviciosnombre_sel)");
         }
         else
         {
            GXv_int10[31] = 1;
         }
         if ( StringUtil.StrCmp(AV129Postulacioneswwds_24_tfserviciosnombre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T2.[ServiciosNombre] IS NULL or (T2.[ServiciosNombre] = ''))");
         }
         if ( ! (0==AV130Postulacioneswwds_25_tfpostulacionesproveedorid) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesProveedorId] >= @AV130Postulacioneswwds_25_tfpostulacionesproveedorid)");
         }
         else
         {
            GXv_int10[32] = 1;
         }
         if ( ! (0==AV131Postulacioneswwds_26_tfpostulacionesproveedorid_to) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesProveedorId] <= @AV131Postulacioneswwds_26_tfpostulacionesproveedorid_to)");
         }
         else
         {
            GXv_int10[33] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV133Postulacioneswwds_28_tfpostulacionesproveedornombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV132Postulacioneswwds_27_tfpostulacionesproveedornombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T3.[ProveedorNombre]) like UPPER(@lV132Postulacioneswwds_27_tfpostulacionesproveedornombre))");
         }
         else
         {
            GXv_int10[34] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV133Postulacioneswwds_28_tfpostulacionesproveedornombre_sel)) && ! ( StringUtil.StrCmp(AV133Postulacioneswwds_28_tfpostulacionesproveedornombre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T3.[ProveedorNombre] = @AV133Postulacioneswwds_28_tfpostulacionesproveedornombre_sel)");
         }
         else
         {
            GXv_int10[35] = 1;
         }
         if ( StringUtil.StrCmp(AV133Postulacioneswwds_28_tfpostulacionesproveedornombre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T3.[ProveedorNombre] = ''))");
         }
         if ( ! (Convert.ToDecimal(0)==AV134Postulacioneswwds_29_tfpostulacionesprecio) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesPrecio] >= @AV134Postulacioneswwds_29_tfpostulacionesprecio)");
         }
         else
         {
            GXv_int10[36] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV135Postulacioneswwds_30_tfpostulacionesprecio_to) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesPrecio] <= @AV135Postulacioneswwds_30_tfpostulacionesprecio_to)");
         }
         else
         {
            GXv_int10[37] = 1;
         }
         if ( ! (0==AV136Postulacioneswwds_31_tfpostulacionesmultimediaserial) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesMultimediaSerial] >= @AV136Postulacioneswwds_31_tfpostulacionesmultimediaserial)");
         }
         else
         {
            GXv_int10[38] = 1;
         }
         if ( ! (0==AV137Postulacioneswwds_32_tfpostulacionesmultimediaserial_to) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesMultimediaSerial] <= @AV137Postulacioneswwds_32_tfpostulacionesmultimediaserial_to)");
         }
         else
         {
            GXv_int10[39] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV141Postulacioneswwds_36_tfpostulacionesdescripcion_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV140Postulacioneswwds_35_tfpostulacionesdescripcion)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[PostulacionesDescripcion]) like UPPER(@lV140Postulacioneswwds_35_tfpostulacionesdescripcion))");
         }
         else
         {
            GXv_int10[40] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV141Postulacioneswwds_36_tfpostulacionesdescripcion_sel)) && ! ( StringUtil.StrCmp(AV141Postulacioneswwds_36_tfpostulacionesdescripcion_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesDescripcion] = @AV141Postulacioneswwds_36_tfpostulacionesdescripcion_sel)");
         }
         else
         {
            GXv_int10[41] = 1;
         }
         if ( StringUtil.StrCmp(AV141Postulacioneswwds_36_tfpostulacionesdescripcion_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[PostulacionesDescripcion] = ''))");
         }
         if ( AV142Postulacioneswwds_37_tfpostulacionesreqsuministros_sel == 1 )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesReqSuministros] = 1)");
         }
         if ( AV142Postulacioneswwds_37_tfpostulacionesreqsuministros_sel == 2 )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesReqSuministros] = 0)");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV144Postulacioneswwds_39_tfpostulacionessuministrosdescripcion_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV143Postulacioneswwds_38_tfpostulacionessuministrosdescripcion)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[PostulacionesSuministrosDescri]) like UPPER(@lV143Postulacioneswwds_38_tfpostulacionessuministrosdescripcion))");
         }
         else
         {
            GXv_int10[42] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV144Postulacioneswwds_39_tfpostulacionessuministrosdescripcion_sel)) && ! ( StringUtil.StrCmp(AV144Postulacioneswwds_39_tfpostulacionessuministrosdescripcion_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesSuministrosDescri] = @AV144Postulacioneswwds_39_tfpostulacionessuministrosdescripcion_sel)");
         }
         else
         {
            GXv_int10[43] = 1;
         }
         if ( StringUtil.StrCmp(AV144Postulacioneswwds_39_tfpostulacionessuministrosdescripcion_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[PostulacionesSuministrosDescri] = ''))");
         }
         if ( ! (DateTime.MinValue==AV145Postulacioneswwds_40_tfpostulacionesfechatrabajo) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesFechaTrabajo] >= @AV145Postulacioneswwds_40_tfpostulacionesfechatrabajo)");
         }
         else
         {
            GXv_int10[44] = 1;
         }
         if ( ! (DateTime.MinValue==AV146Postulacioneswwds_41_tfpostulacionesfechatrabajo_to) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesFechaTrabajo] <= @AV146Postulacioneswwds_41_tfpostulacionesfechatrabajo_to)");
         }
         else
         {
            GXv_int10[45] = 1;
         }
         if ( ! (DateTime.MinValue==AV147Postulacioneswwds_42_tfpostulacionesfechacierre) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesFechaCierre] >= @AV147Postulacioneswwds_42_tfpostulacionesfechacierre)");
         }
         else
         {
            GXv_int10[46] = 1;
         }
         if ( ! (DateTime.MinValue==AV148Postulacioneswwds_43_tfpostulacionesfechacierre_to) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesFechaCierre] <= @AV148Postulacioneswwds_43_tfpostulacionesfechacierre_to)");
         }
         else
         {
            GXv_int10[47] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV150Postulacioneswwds_45_tfpostulacioneshoracierre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV149Postulacioneswwds_44_tfpostulacioneshoracierre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[PostulacionesHoraCierre]) like UPPER(@lV149Postulacioneswwds_44_tfpostulacioneshoracierre))");
         }
         else
         {
            GXv_int10[48] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV150Postulacioneswwds_45_tfpostulacioneshoracierre_sel)) && ! ( StringUtil.StrCmp(AV150Postulacioneswwds_45_tfpostulacioneshoracierre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesHoraCierre] = @AV150Postulacioneswwds_45_tfpostulacioneshoracierre_sel)");
         }
         else
         {
            GXv_int10[49] = 1;
         }
         if ( StringUtil.StrCmp(AV150Postulacioneswwds_45_tfpostulacioneshoracierre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[PostulacionesHoraCierre] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV152Postulacioneswwds_47_tfpostulacionestipofecha_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV151Postulacioneswwds_46_tfpostulacionestipofecha)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[PostulacionesTipoFecha]) like UPPER(@lV151Postulacioneswwds_46_tfpostulacionestipofecha))");
         }
         else
         {
            GXv_int10[50] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV152Postulacioneswwds_47_tfpostulacionestipofecha_sel)) && ! ( StringUtil.StrCmp(AV152Postulacioneswwds_47_tfpostulacionestipofecha_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesTipoFecha] = @AV152Postulacioneswwds_47_tfpostulacionestipofecha_sel)");
         }
         else
         {
            GXv_int10[51] = 1;
         }
         if ( StringUtil.StrCmp(AV152Postulacioneswwds_47_tfpostulacionestipofecha_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[PostulacionesTipoFecha] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV154Postulacioneswwds_49_tfpostulacionesrgohoraservicio_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV153Postulacioneswwds_48_tfpostulacionesrgohoraservicio)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[PostulacionesRgoHoraservicio]) like UPPER(@lV153Postulacioneswwds_48_tfpostulacionesrgohoraservicio))");
         }
         else
         {
            GXv_int10[52] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV154Postulacioneswwds_49_tfpostulacionesrgohoraservicio_sel)) && ! ( StringUtil.StrCmp(AV154Postulacioneswwds_49_tfpostulacionesrgohoraservicio_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesRgoHoraservicio] = @AV154Postulacioneswwds_49_tfpostulacionesrgohoraservicio_sel)");
         }
         else
         {
            GXv_int10[53] = 1;
         }
         if ( StringUtil.StrCmp(AV154Postulacioneswwds_49_tfpostulacionesrgohoraservicio_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[PostulacionesRgoHoraservicio] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV156Postulacioneswwds_51_tfpostulacionesapellidonombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV155Postulacioneswwds_50_tfpostulacionesapellidonombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[PostulacionesApellidoNombre]) like UPPER(@lV155Postulacioneswwds_50_tfpostulacionesapellidonombre))");
         }
         else
         {
            GXv_int10[54] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV156Postulacioneswwds_51_tfpostulacionesapellidonombre_sel)) && ! ( StringUtil.StrCmp(AV156Postulacioneswwds_51_tfpostulacionesapellidonombre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesApellidoNombre] = @AV156Postulacioneswwds_51_tfpostulacionesapellidonombre_sel)");
         }
         else
         {
            GXv_int10[55] = 1;
         }
         if ( StringUtil.StrCmp(AV156Postulacioneswwds_51_tfpostulacionesapellidonombre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[PostulacionesApellidoNombre] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV158Postulacioneswwds_53_tfpostulacionesmail_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV157Postulacioneswwds_52_tfpostulacionesmail)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[PostulacionesMail]) like UPPER(@lV157Postulacioneswwds_52_tfpostulacionesmail))");
         }
         else
         {
            GXv_int10[56] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV158Postulacioneswwds_53_tfpostulacionesmail_sel)) && ! ( StringUtil.StrCmp(AV158Postulacioneswwds_53_tfpostulacionesmail_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesMail] = @AV158Postulacioneswwds_53_tfpostulacionesmail_sel)");
         }
         else
         {
            GXv_int10[57] = 1;
         }
         if ( StringUtil.StrCmp(AV158Postulacioneswwds_53_tfpostulacionesmail_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[PostulacionesMail] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV160Postulacioneswwds_55_tfpostulacionestelefono_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV159Postulacioneswwds_54_tfpostulacionestelefono)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[PostulacionesTelefono]) like UPPER(@lV159Postulacioneswwds_54_tfpostulacionestelefono))");
         }
         else
         {
            GXv_int10[58] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV160Postulacioneswwds_55_tfpostulacionestelefono_sel)) && ! ( StringUtil.StrCmp(AV160Postulacioneswwds_55_tfpostulacionestelefono_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesTelefono] = @AV160Postulacioneswwds_55_tfpostulacionestelefono_sel)");
         }
         else
         {
            GXv_int10[59] = 1;
         }
         if ( StringUtil.StrCmp(AV160Postulacioneswwds_55_tfpostulacionestelefono_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[PostulacionesTelefono] = ''))");
         }
         if ( ! (DateTime.MinValue==AV161Postulacioneswwds_56_tfpostulacionesfechaalta) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesFechaAlta] >= @AV161Postulacioneswwds_56_tfpostulacionesfechaalta)");
         }
         else
         {
            GXv_int10[60] = 1;
         }
         if ( ! (DateTime.MinValue==AV162Postulacioneswwds_57_tfpostulacionesfechaalta_to) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesFechaAlta] <= @AV162Postulacioneswwds_57_tfpostulacionesfechaalta_to)");
         }
         else
         {
            GXv_int10[61] = 1;
         }
         if ( AV163Postulacioneswwds_58_tfpostulacionesestado_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV163Postulacioneswwds_58_tfpostulacionesestado_sels, "T1.[PostulacionesEstado] IN (", ")")+")");
         }
         if ( ! (0==AV164Postulacioneswwds_59_tfpostulacionessecuserid) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesSecUserId] >= @AV164Postulacioneswwds_59_tfpostulacionessecuserid)");
         }
         else
         {
            GXv_int10[62] = 1;
         }
         if ( ! (0==AV165Postulacioneswwds_60_tfpostulacionessecuserid_to) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesSecUserId] <= @AV165Postulacioneswwds_60_tfpostulacionessecuserid_to)");
         }
         else
         {
            GXv_int10[63] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[PostulacionesHoraCierre]";
         GXv_Object11[0] = scmdbuf;
         GXv_Object11[1] = GXv_int10;
         return GXv_Object11 ;
      }

      protected Object[] conditional_P00LA13( IGxContext context ,
                                              string A424PostulacionesEstado ,
                                              GxSimpleCollection<string> AV163Postulacioneswwds_58_tfpostulacionesestado_sels ,
                                              string AV107Postulacioneswwds_2_dynamicfiltersselector1 ,
                                              short AV108Postulacioneswwds_3_dynamicfiltersoperator1 ,
                                              string AV109Postulacioneswwds_4_postulacionesproveedornombre1 ,
                                              long AV110Postulacioneswwds_5_postulacionesproveedorid1 ,
                                              string AV111Postulacioneswwds_6_serviciosnombre1 ,
                                              bool AV112Postulacioneswwds_7_dynamicfiltersenabled2 ,
                                              string AV113Postulacioneswwds_8_dynamicfiltersselector2 ,
                                              short AV114Postulacioneswwds_9_dynamicfiltersoperator2 ,
                                              string AV115Postulacioneswwds_10_postulacionesproveedornombre2 ,
                                              long AV116Postulacioneswwds_11_postulacionesproveedorid2 ,
                                              string AV117Postulacioneswwds_12_serviciosnombre2 ,
                                              bool AV118Postulacioneswwds_13_dynamicfiltersenabled3 ,
                                              string AV119Postulacioneswwds_14_dynamicfiltersselector3 ,
                                              short AV120Postulacioneswwds_15_dynamicfiltersoperator3 ,
                                              string AV121Postulacioneswwds_16_postulacionesproveedornombre3 ,
                                              long AV122Postulacioneswwds_17_postulacionesproveedorid3 ,
                                              string AV123Postulacioneswwds_18_serviciosnombre3 ,
                                              long AV124Postulacioneswwds_19_tfpostulacionesid ,
                                              long AV125Postulacioneswwds_20_tfpostulacionesid_to ,
                                              long AV126Postulacioneswwds_21_tfserviciosid ,
                                              long AV127Postulacioneswwds_22_tfserviciosid_to ,
                                              string AV129Postulacioneswwds_24_tfserviciosnombre_sel ,
                                              string AV128Postulacioneswwds_23_tfserviciosnombre ,
                                              long AV130Postulacioneswwds_25_tfpostulacionesproveedorid ,
                                              long AV131Postulacioneswwds_26_tfpostulacionesproveedorid_to ,
                                              string AV133Postulacioneswwds_28_tfpostulacionesproveedornombre_sel ,
                                              string AV132Postulacioneswwds_27_tfpostulacionesproveedornombre ,
                                              decimal AV134Postulacioneswwds_29_tfpostulacionesprecio ,
                                              decimal AV135Postulacioneswwds_30_tfpostulacionesprecio_to ,
                                              short AV136Postulacioneswwds_31_tfpostulacionesmultimediaserial ,
                                              short AV137Postulacioneswwds_32_tfpostulacionesmultimediaserial_to ,
                                              string AV141Postulacioneswwds_36_tfpostulacionesdescripcion_sel ,
                                              string AV140Postulacioneswwds_35_tfpostulacionesdescripcion ,
                                              short AV142Postulacioneswwds_37_tfpostulacionesreqsuministros_sel ,
                                              string AV144Postulacioneswwds_39_tfpostulacionessuministrosdescripcion_sel ,
                                              string AV143Postulacioneswwds_38_tfpostulacionessuministrosdescripcion ,
                                              DateTime AV145Postulacioneswwds_40_tfpostulacionesfechatrabajo ,
                                              DateTime AV146Postulacioneswwds_41_tfpostulacionesfechatrabajo_to ,
                                              DateTime AV147Postulacioneswwds_42_tfpostulacionesfechacierre ,
                                              DateTime AV148Postulacioneswwds_43_tfpostulacionesfechacierre_to ,
                                              string AV150Postulacioneswwds_45_tfpostulacioneshoracierre_sel ,
                                              string AV149Postulacioneswwds_44_tfpostulacioneshoracierre ,
                                              string AV152Postulacioneswwds_47_tfpostulacionestipofecha_sel ,
                                              string AV151Postulacioneswwds_46_tfpostulacionestipofecha ,
                                              string AV154Postulacioneswwds_49_tfpostulacionesrgohoraservicio_sel ,
                                              string AV153Postulacioneswwds_48_tfpostulacionesrgohoraservicio ,
                                              string AV156Postulacioneswwds_51_tfpostulacionesapellidonombre_sel ,
                                              string AV155Postulacioneswwds_50_tfpostulacionesapellidonombre ,
                                              string AV158Postulacioneswwds_53_tfpostulacionesmail_sel ,
                                              string AV157Postulacioneswwds_52_tfpostulacionesmail ,
                                              string AV160Postulacioneswwds_55_tfpostulacionestelefono_sel ,
                                              string AV159Postulacioneswwds_54_tfpostulacionestelefono ,
                                              DateTime AV161Postulacioneswwds_56_tfpostulacionesfechaalta ,
                                              DateTime AV162Postulacioneswwds_57_tfpostulacionesfechaalta_to ,
                                              int AV163Postulacioneswwds_58_tfpostulacionesestado_sels_Count ,
                                              long AV164Postulacioneswwds_59_tfpostulacionessecuserid ,
                                              long AV165Postulacioneswwds_60_tfpostulacionessecuserid_to ,
                                              string A969PostulacionesProveedorNombre ,
                                              long A945PostulacionesProveedorId ,
                                              string A943ServiciosNombre ,
                                              long A422PostulacionesId ,
                                              long A942ServiciosId ,
                                              decimal A946PostulacionesPrecio ,
                                              short A961PostulacionesMultimediaSerial ,
                                              string A936PostulacionesDescripcion ,
                                              bool A937PostulacionesReqSuministros ,
                                              string A938PostulacionesSuministrosDescri ,
                                              DateTime A947PostulacionesFechaTrabajo ,
                                              DateTime A939PostulacionesFechaCierre ,
                                              string A940PostulacionesHoraCierre ,
                                              string A941PostulacionesTipoFecha ,
                                              string A949PostulacionesRgoHoraservicio ,
                                              string A950PostulacionesApellidoNombre ,
                                              string A951PostulacionesMail ,
                                              string A952PostulacionesTelefono ,
                                              DateTime A425PostulacionesFechaAlta ,
                                              long A948PostulacionesSecUserId ,
                                              string AV106Postulacioneswwds_1_filterfulltext ,
                                              long A970PostulacionesSolicitudesId ,
                                              long AV138Postulacioneswwds_33_tfpostulacionessolicitudesid ,
                                              long AV139Postulacioneswwds_34_tfpostulacionessolicitudesid_to )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int12 = new short[64];
         Object[] GXv_Object13 = new Object[2];
         scmdbuf = "SELECT T1.[PostulacionesTipoFecha], T1.[PostulacionesSecUserId], T1.[PostulacionesFechaAlta], T1.[PostulacionesTelefono], T1.[PostulacionesMail], T1.[PostulacionesApellidoNombre], T1.[PostulacionesRgoHoraservicio], T1.[PostulacionesHoraCierre], T1.[PostulacionesFechaCierre], T1.[PostulacionesFechaTrabajo], T1.[PostulacionesSuministrosDescri], T1.[PostulacionesReqSuministros], T1.[PostulacionesDescripcion], T1.[PostulacionesMultimediaSerial], T1.[PostulacionesPrecio], T3.[ProveedorNombre] AS PostulacionesProveedorNombre, T2.[ServiciosNombre], T1.[ServiciosId], T1.[PostulacionesId], T1.[PostulacionesProveedorId] AS PostulacionesProveedorId, T1.[PostulacionesEstado], COALESCE( T4.[PostulacionesSolicitudesId], 0) AS PostulacionesSolicitudesId FROM (([Postulaciones] T1 LEFT JOIN [Servicios] T2 ON T2.[ServiciosId] = T1.[ServiciosId]) INNER JOIN [Proveedor] T3 ON T3.[ProveedorID] = T1.[PostulacionesProveedorId]),  (SELECT MIN([SolicitudesID]) AS PostulacionesSolicitudesId FROM [Solicitudes] WHERE [PostulacionesId] = @PostulacionesId ) T4";
         AddWhere(sWhereString, "((@AV138Postulacioneswwds_33_tfpostulacionessolicitudesid = convert(int, 0)) or ( COALESCE( T4.[PostulacionesSolicitudesId], 0) >= @AV138Postulacioneswwds_33_tfpostulacionessolicitudesid))");
         AddWhere(sWhereString, "((@AV139Postulacioneswwds_34_tfpostulacionessolicitudesid_to = convert(int, 0)) or ( COALESCE( T4.[PostulacionesSolicitudesId], 0) <= @AV139Postulacioneswwds_34_tfpostulacionessolicitudesid_to))");
         if ( ( StringUtil.StrCmp(AV107Postulacioneswwds_2_dynamicfiltersselector1, "POSTULACIONESPROVEEDORNOMBRE") == 0 ) && ( AV108Postulacioneswwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV109Postulacioneswwds_4_postulacionesproveedornombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T3.[ProveedorNombre]) like UPPER(@lV109Postulacioneswwds_4_postulacionesproveedornombre1))");
         }
         else
         {
            GXv_int12[5] = 1;
         }
         if ( ( StringUtil.StrCmp(AV107Postulacioneswwds_2_dynamicfiltersselector1, "POSTULACIONESPROVEEDORNOMBRE") == 0 ) && ( AV108Postulacioneswwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV109Postulacioneswwds_4_postulacionesproveedornombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T3.[ProveedorNombre]) like '%' + UPPER(@lV109Postulacioneswwds_4_postulacionesproveedornombre1))");
         }
         else
         {
            GXv_int12[6] = 1;
         }
         if ( ( StringUtil.StrCmp(AV107Postulacioneswwds_2_dynamicfiltersselector1, "POSTULACIONESPROVEEDORID") == 0 ) && ( AV108Postulacioneswwds_3_dynamicfiltersoperator1 == 0 ) && ( ! (0==AV110Postulacioneswwds_5_postulacionesproveedorid1) ) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesProveedorId] < @AV110Postulacioneswwds_5_postulacionesproveedorid1)");
         }
         else
         {
            GXv_int12[7] = 1;
         }
         if ( ( StringUtil.StrCmp(AV107Postulacioneswwds_2_dynamicfiltersselector1, "POSTULACIONESPROVEEDORID") == 0 ) && ( AV108Postulacioneswwds_3_dynamicfiltersoperator1 == 1 ) && ( ! (0==AV110Postulacioneswwds_5_postulacionesproveedorid1) ) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesProveedorId] = @AV110Postulacioneswwds_5_postulacionesproveedorid1)");
         }
         else
         {
            GXv_int12[8] = 1;
         }
         if ( ( StringUtil.StrCmp(AV107Postulacioneswwds_2_dynamicfiltersselector1, "POSTULACIONESPROVEEDORID") == 0 ) && ( AV108Postulacioneswwds_3_dynamicfiltersoperator1 == 2 ) && ( ! (0==AV110Postulacioneswwds_5_postulacionesproveedorid1) ) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesProveedorId] > @AV110Postulacioneswwds_5_postulacionesproveedorid1)");
         }
         else
         {
            GXv_int12[9] = 1;
         }
         if ( ( StringUtil.StrCmp(AV107Postulacioneswwds_2_dynamicfiltersselector1, "SERVICIOSNOMBRE") == 0 ) && ( AV108Postulacioneswwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV111Postulacioneswwds_6_serviciosnombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ServiciosNombre]) like UPPER(@lV111Postulacioneswwds_6_serviciosnombre1))");
         }
         else
         {
            GXv_int12[10] = 1;
         }
         if ( ( StringUtil.StrCmp(AV107Postulacioneswwds_2_dynamicfiltersselector1, "SERVICIOSNOMBRE") == 0 ) && ( AV108Postulacioneswwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV111Postulacioneswwds_6_serviciosnombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ServiciosNombre]) like '%' + UPPER(@lV111Postulacioneswwds_6_serviciosnombre1))");
         }
         else
         {
            GXv_int12[11] = 1;
         }
         if ( AV112Postulacioneswwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV113Postulacioneswwds_8_dynamicfiltersselector2, "POSTULACIONESPROVEEDORNOMBRE") == 0 ) && ( AV114Postulacioneswwds_9_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV115Postulacioneswwds_10_postulacionesproveedornombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T3.[ProveedorNombre]) like UPPER(@lV115Postulacioneswwds_10_postulacionesproveedornombre2))");
         }
         else
         {
            GXv_int12[12] = 1;
         }
         if ( AV112Postulacioneswwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV113Postulacioneswwds_8_dynamicfiltersselector2, "POSTULACIONESPROVEEDORNOMBRE") == 0 ) && ( AV114Postulacioneswwds_9_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV115Postulacioneswwds_10_postulacionesproveedornombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T3.[ProveedorNombre]) like '%' + UPPER(@lV115Postulacioneswwds_10_postulacionesproveedornombre2))");
         }
         else
         {
            GXv_int12[13] = 1;
         }
         if ( AV112Postulacioneswwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV113Postulacioneswwds_8_dynamicfiltersselector2, "POSTULACIONESPROVEEDORID") == 0 ) && ( AV114Postulacioneswwds_9_dynamicfiltersoperator2 == 0 ) && ( ! (0==AV116Postulacioneswwds_11_postulacionesproveedorid2) ) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesProveedorId] < @AV116Postulacioneswwds_11_postulacionesproveedorid2)");
         }
         else
         {
            GXv_int12[14] = 1;
         }
         if ( AV112Postulacioneswwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV113Postulacioneswwds_8_dynamicfiltersselector2, "POSTULACIONESPROVEEDORID") == 0 ) && ( AV114Postulacioneswwds_9_dynamicfiltersoperator2 == 1 ) && ( ! (0==AV116Postulacioneswwds_11_postulacionesproveedorid2) ) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesProveedorId] = @AV116Postulacioneswwds_11_postulacionesproveedorid2)");
         }
         else
         {
            GXv_int12[15] = 1;
         }
         if ( AV112Postulacioneswwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV113Postulacioneswwds_8_dynamicfiltersselector2, "POSTULACIONESPROVEEDORID") == 0 ) && ( AV114Postulacioneswwds_9_dynamicfiltersoperator2 == 2 ) && ( ! (0==AV116Postulacioneswwds_11_postulacionesproveedorid2) ) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesProveedorId] > @AV116Postulacioneswwds_11_postulacionesproveedorid2)");
         }
         else
         {
            GXv_int12[16] = 1;
         }
         if ( AV112Postulacioneswwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV113Postulacioneswwds_8_dynamicfiltersselector2, "SERVICIOSNOMBRE") == 0 ) && ( AV114Postulacioneswwds_9_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV117Postulacioneswwds_12_serviciosnombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ServiciosNombre]) like UPPER(@lV117Postulacioneswwds_12_serviciosnombre2))");
         }
         else
         {
            GXv_int12[17] = 1;
         }
         if ( AV112Postulacioneswwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV113Postulacioneswwds_8_dynamicfiltersselector2, "SERVICIOSNOMBRE") == 0 ) && ( AV114Postulacioneswwds_9_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV117Postulacioneswwds_12_serviciosnombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ServiciosNombre]) like '%' + UPPER(@lV117Postulacioneswwds_12_serviciosnombre2))");
         }
         else
         {
            GXv_int12[18] = 1;
         }
         if ( AV118Postulacioneswwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV119Postulacioneswwds_14_dynamicfiltersselector3, "POSTULACIONESPROVEEDORNOMBRE") == 0 ) && ( AV120Postulacioneswwds_15_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV121Postulacioneswwds_16_postulacionesproveedornombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T3.[ProveedorNombre]) like UPPER(@lV121Postulacioneswwds_16_postulacionesproveedornombre3))");
         }
         else
         {
            GXv_int12[19] = 1;
         }
         if ( AV118Postulacioneswwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV119Postulacioneswwds_14_dynamicfiltersselector3, "POSTULACIONESPROVEEDORNOMBRE") == 0 ) && ( AV120Postulacioneswwds_15_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV121Postulacioneswwds_16_postulacionesproveedornombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T3.[ProveedorNombre]) like '%' + UPPER(@lV121Postulacioneswwds_16_postulacionesproveedornombre3))");
         }
         else
         {
            GXv_int12[20] = 1;
         }
         if ( AV118Postulacioneswwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV119Postulacioneswwds_14_dynamicfiltersselector3, "POSTULACIONESPROVEEDORID") == 0 ) && ( AV120Postulacioneswwds_15_dynamicfiltersoperator3 == 0 ) && ( ! (0==AV122Postulacioneswwds_17_postulacionesproveedorid3) ) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesProveedorId] < @AV122Postulacioneswwds_17_postulacionesproveedorid3)");
         }
         else
         {
            GXv_int12[21] = 1;
         }
         if ( AV118Postulacioneswwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV119Postulacioneswwds_14_dynamicfiltersselector3, "POSTULACIONESPROVEEDORID") == 0 ) && ( AV120Postulacioneswwds_15_dynamicfiltersoperator3 == 1 ) && ( ! (0==AV122Postulacioneswwds_17_postulacionesproveedorid3) ) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesProveedorId] = @AV122Postulacioneswwds_17_postulacionesproveedorid3)");
         }
         else
         {
            GXv_int12[22] = 1;
         }
         if ( AV118Postulacioneswwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV119Postulacioneswwds_14_dynamicfiltersselector3, "POSTULACIONESPROVEEDORID") == 0 ) && ( AV120Postulacioneswwds_15_dynamicfiltersoperator3 == 2 ) && ( ! (0==AV122Postulacioneswwds_17_postulacionesproveedorid3) ) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesProveedorId] > @AV122Postulacioneswwds_17_postulacionesproveedorid3)");
         }
         else
         {
            GXv_int12[23] = 1;
         }
         if ( AV118Postulacioneswwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV119Postulacioneswwds_14_dynamicfiltersselector3, "SERVICIOSNOMBRE") == 0 ) && ( AV120Postulacioneswwds_15_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV123Postulacioneswwds_18_serviciosnombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ServiciosNombre]) like UPPER(@lV123Postulacioneswwds_18_serviciosnombre3))");
         }
         else
         {
            GXv_int12[24] = 1;
         }
         if ( AV118Postulacioneswwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV119Postulacioneswwds_14_dynamicfiltersselector3, "SERVICIOSNOMBRE") == 0 ) && ( AV120Postulacioneswwds_15_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV123Postulacioneswwds_18_serviciosnombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ServiciosNombre]) like '%' + UPPER(@lV123Postulacioneswwds_18_serviciosnombre3))");
         }
         else
         {
            GXv_int12[25] = 1;
         }
         if ( ! (0==AV124Postulacioneswwds_19_tfpostulacionesid) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesId] >= @AV124Postulacioneswwds_19_tfpostulacionesid)");
         }
         else
         {
            GXv_int12[26] = 1;
         }
         if ( ! (0==AV125Postulacioneswwds_20_tfpostulacionesid_to) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesId] <= @AV125Postulacioneswwds_20_tfpostulacionesid_to)");
         }
         else
         {
            GXv_int12[27] = 1;
         }
         if ( ! (0==AV126Postulacioneswwds_21_tfserviciosid) )
         {
            AddWhere(sWhereString, "(T1.[ServiciosId] >= @AV126Postulacioneswwds_21_tfserviciosid)");
         }
         else
         {
            GXv_int12[28] = 1;
         }
         if ( ! (0==AV127Postulacioneswwds_22_tfserviciosid_to) )
         {
            AddWhere(sWhereString, "(T1.[ServiciosId] <= @AV127Postulacioneswwds_22_tfserviciosid_to)");
         }
         else
         {
            GXv_int12[29] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV129Postulacioneswwds_24_tfserviciosnombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV128Postulacioneswwds_23_tfserviciosnombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ServiciosNombre]) like UPPER(@lV128Postulacioneswwds_23_tfserviciosnombre))");
         }
         else
         {
            GXv_int12[30] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV129Postulacioneswwds_24_tfserviciosnombre_sel)) && ! ( StringUtil.StrCmp(AV129Postulacioneswwds_24_tfserviciosnombre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.[ServiciosNombre] = @AV129Postulacioneswwds_24_tfserviciosnombre_sel)");
         }
         else
         {
            GXv_int12[31] = 1;
         }
         if ( StringUtil.StrCmp(AV129Postulacioneswwds_24_tfserviciosnombre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T2.[ServiciosNombre] IS NULL or (T2.[ServiciosNombre] = ''))");
         }
         if ( ! (0==AV130Postulacioneswwds_25_tfpostulacionesproveedorid) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesProveedorId] >= @AV130Postulacioneswwds_25_tfpostulacionesproveedorid)");
         }
         else
         {
            GXv_int12[32] = 1;
         }
         if ( ! (0==AV131Postulacioneswwds_26_tfpostulacionesproveedorid_to) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesProveedorId] <= @AV131Postulacioneswwds_26_tfpostulacionesproveedorid_to)");
         }
         else
         {
            GXv_int12[33] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV133Postulacioneswwds_28_tfpostulacionesproveedornombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV132Postulacioneswwds_27_tfpostulacionesproveedornombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T3.[ProveedorNombre]) like UPPER(@lV132Postulacioneswwds_27_tfpostulacionesproveedornombre))");
         }
         else
         {
            GXv_int12[34] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV133Postulacioneswwds_28_tfpostulacionesproveedornombre_sel)) && ! ( StringUtil.StrCmp(AV133Postulacioneswwds_28_tfpostulacionesproveedornombre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T3.[ProveedorNombre] = @AV133Postulacioneswwds_28_tfpostulacionesproveedornombre_sel)");
         }
         else
         {
            GXv_int12[35] = 1;
         }
         if ( StringUtil.StrCmp(AV133Postulacioneswwds_28_tfpostulacionesproveedornombre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T3.[ProveedorNombre] = ''))");
         }
         if ( ! (Convert.ToDecimal(0)==AV134Postulacioneswwds_29_tfpostulacionesprecio) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesPrecio] >= @AV134Postulacioneswwds_29_tfpostulacionesprecio)");
         }
         else
         {
            GXv_int12[36] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV135Postulacioneswwds_30_tfpostulacionesprecio_to) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesPrecio] <= @AV135Postulacioneswwds_30_tfpostulacionesprecio_to)");
         }
         else
         {
            GXv_int12[37] = 1;
         }
         if ( ! (0==AV136Postulacioneswwds_31_tfpostulacionesmultimediaserial) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesMultimediaSerial] >= @AV136Postulacioneswwds_31_tfpostulacionesmultimediaserial)");
         }
         else
         {
            GXv_int12[38] = 1;
         }
         if ( ! (0==AV137Postulacioneswwds_32_tfpostulacionesmultimediaserial_to) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesMultimediaSerial] <= @AV137Postulacioneswwds_32_tfpostulacionesmultimediaserial_to)");
         }
         else
         {
            GXv_int12[39] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV141Postulacioneswwds_36_tfpostulacionesdescripcion_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV140Postulacioneswwds_35_tfpostulacionesdescripcion)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[PostulacionesDescripcion]) like UPPER(@lV140Postulacioneswwds_35_tfpostulacionesdescripcion))");
         }
         else
         {
            GXv_int12[40] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV141Postulacioneswwds_36_tfpostulacionesdescripcion_sel)) && ! ( StringUtil.StrCmp(AV141Postulacioneswwds_36_tfpostulacionesdescripcion_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesDescripcion] = @AV141Postulacioneswwds_36_tfpostulacionesdescripcion_sel)");
         }
         else
         {
            GXv_int12[41] = 1;
         }
         if ( StringUtil.StrCmp(AV141Postulacioneswwds_36_tfpostulacionesdescripcion_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[PostulacionesDescripcion] = ''))");
         }
         if ( AV142Postulacioneswwds_37_tfpostulacionesreqsuministros_sel == 1 )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesReqSuministros] = 1)");
         }
         if ( AV142Postulacioneswwds_37_tfpostulacionesreqsuministros_sel == 2 )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesReqSuministros] = 0)");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV144Postulacioneswwds_39_tfpostulacionessuministrosdescripcion_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV143Postulacioneswwds_38_tfpostulacionessuministrosdescripcion)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[PostulacionesSuministrosDescri]) like UPPER(@lV143Postulacioneswwds_38_tfpostulacionessuministrosdescripcion))");
         }
         else
         {
            GXv_int12[42] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV144Postulacioneswwds_39_tfpostulacionessuministrosdescripcion_sel)) && ! ( StringUtil.StrCmp(AV144Postulacioneswwds_39_tfpostulacionessuministrosdescripcion_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesSuministrosDescri] = @AV144Postulacioneswwds_39_tfpostulacionessuministrosdescripcion_sel)");
         }
         else
         {
            GXv_int12[43] = 1;
         }
         if ( StringUtil.StrCmp(AV144Postulacioneswwds_39_tfpostulacionessuministrosdescripcion_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[PostulacionesSuministrosDescri] = ''))");
         }
         if ( ! (DateTime.MinValue==AV145Postulacioneswwds_40_tfpostulacionesfechatrabajo) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesFechaTrabajo] >= @AV145Postulacioneswwds_40_tfpostulacionesfechatrabajo)");
         }
         else
         {
            GXv_int12[44] = 1;
         }
         if ( ! (DateTime.MinValue==AV146Postulacioneswwds_41_tfpostulacionesfechatrabajo_to) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesFechaTrabajo] <= @AV146Postulacioneswwds_41_tfpostulacionesfechatrabajo_to)");
         }
         else
         {
            GXv_int12[45] = 1;
         }
         if ( ! (DateTime.MinValue==AV147Postulacioneswwds_42_tfpostulacionesfechacierre) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesFechaCierre] >= @AV147Postulacioneswwds_42_tfpostulacionesfechacierre)");
         }
         else
         {
            GXv_int12[46] = 1;
         }
         if ( ! (DateTime.MinValue==AV148Postulacioneswwds_43_tfpostulacionesfechacierre_to) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesFechaCierre] <= @AV148Postulacioneswwds_43_tfpostulacionesfechacierre_to)");
         }
         else
         {
            GXv_int12[47] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV150Postulacioneswwds_45_tfpostulacioneshoracierre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV149Postulacioneswwds_44_tfpostulacioneshoracierre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[PostulacionesHoraCierre]) like UPPER(@lV149Postulacioneswwds_44_tfpostulacioneshoracierre))");
         }
         else
         {
            GXv_int12[48] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV150Postulacioneswwds_45_tfpostulacioneshoracierre_sel)) && ! ( StringUtil.StrCmp(AV150Postulacioneswwds_45_tfpostulacioneshoracierre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesHoraCierre] = @AV150Postulacioneswwds_45_tfpostulacioneshoracierre_sel)");
         }
         else
         {
            GXv_int12[49] = 1;
         }
         if ( StringUtil.StrCmp(AV150Postulacioneswwds_45_tfpostulacioneshoracierre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[PostulacionesHoraCierre] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV152Postulacioneswwds_47_tfpostulacionestipofecha_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV151Postulacioneswwds_46_tfpostulacionestipofecha)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[PostulacionesTipoFecha]) like UPPER(@lV151Postulacioneswwds_46_tfpostulacionestipofecha))");
         }
         else
         {
            GXv_int12[50] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV152Postulacioneswwds_47_tfpostulacionestipofecha_sel)) && ! ( StringUtil.StrCmp(AV152Postulacioneswwds_47_tfpostulacionestipofecha_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesTipoFecha] = @AV152Postulacioneswwds_47_tfpostulacionestipofecha_sel)");
         }
         else
         {
            GXv_int12[51] = 1;
         }
         if ( StringUtil.StrCmp(AV152Postulacioneswwds_47_tfpostulacionestipofecha_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[PostulacionesTipoFecha] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV154Postulacioneswwds_49_tfpostulacionesrgohoraservicio_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV153Postulacioneswwds_48_tfpostulacionesrgohoraservicio)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[PostulacionesRgoHoraservicio]) like UPPER(@lV153Postulacioneswwds_48_tfpostulacionesrgohoraservicio))");
         }
         else
         {
            GXv_int12[52] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV154Postulacioneswwds_49_tfpostulacionesrgohoraservicio_sel)) && ! ( StringUtil.StrCmp(AV154Postulacioneswwds_49_tfpostulacionesrgohoraservicio_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesRgoHoraservicio] = @AV154Postulacioneswwds_49_tfpostulacionesrgohoraservicio_sel)");
         }
         else
         {
            GXv_int12[53] = 1;
         }
         if ( StringUtil.StrCmp(AV154Postulacioneswwds_49_tfpostulacionesrgohoraservicio_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[PostulacionesRgoHoraservicio] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV156Postulacioneswwds_51_tfpostulacionesapellidonombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV155Postulacioneswwds_50_tfpostulacionesapellidonombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[PostulacionesApellidoNombre]) like UPPER(@lV155Postulacioneswwds_50_tfpostulacionesapellidonombre))");
         }
         else
         {
            GXv_int12[54] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV156Postulacioneswwds_51_tfpostulacionesapellidonombre_sel)) && ! ( StringUtil.StrCmp(AV156Postulacioneswwds_51_tfpostulacionesapellidonombre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesApellidoNombre] = @AV156Postulacioneswwds_51_tfpostulacionesapellidonombre_sel)");
         }
         else
         {
            GXv_int12[55] = 1;
         }
         if ( StringUtil.StrCmp(AV156Postulacioneswwds_51_tfpostulacionesapellidonombre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[PostulacionesApellidoNombre] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV158Postulacioneswwds_53_tfpostulacionesmail_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV157Postulacioneswwds_52_tfpostulacionesmail)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[PostulacionesMail]) like UPPER(@lV157Postulacioneswwds_52_tfpostulacionesmail))");
         }
         else
         {
            GXv_int12[56] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV158Postulacioneswwds_53_tfpostulacionesmail_sel)) && ! ( StringUtil.StrCmp(AV158Postulacioneswwds_53_tfpostulacionesmail_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesMail] = @AV158Postulacioneswwds_53_tfpostulacionesmail_sel)");
         }
         else
         {
            GXv_int12[57] = 1;
         }
         if ( StringUtil.StrCmp(AV158Postulacioneswwds_53_tfpostulacionesmail_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[PostulacionesMail] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV160Postulacioneswwds_55_tfpostulacionestelefono_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV159Postulacioneswwds_54_tfpostulacionestelefono)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[PostulacionesTelefono]) like UPPER(@lV159Postulacioneswwds_54_tfpostulacionestelefono))");
         }
         else
         {
            GXv_int12[58] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV160Postulacioneswwds_55_tfpostulacionestelefono_sel)) && ! ( StringUtil.StrCmp(AV160Postulacioneswwds_55_tfpostulacionestelefono_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesTelefono] = @AV160Postulacioneswwds_55_tfpostulacionestelefono_sel)");
         }
         else
         {
            GXv_int12[59] = 1;
         }
         if ( StringUtil.StrCmp(AV160Postulacioneswwds_55_tfpostulacionestelefono_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[PostulacionesTelefono] = ''))");
         }
         if ( ! (DateTime.MinValue==AV161Postulacioneswwds_56_tfpostulacionesfechaalta) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesFechaAlta] >= @AV161Postulacioneswwds_56_tfpostulacionesfechaalta)");
         }
         else
         {
            GXv_int12[60] = 1;
         }
         if ( ! (DateTime.MinValue==AV162Postulacioneswwds_57_tfpostulacionesfechaalta_to) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesFechaAlta] <= @AV162Postulacioneswwds_57_tfpostulacionesfechaalta_to)");
         }
         else
         {
            GXv_int12[61] = 1;
         }
         if ( AV163Postulacioneswwds_58_tfpostulacionesestado_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV163Postulacioneswwds_58_tfpostulacionesestado_sels, "T1.[PostulacionesEstado] IN (", ")")+")");
         }
         if ( ! (0==AV164Postulacioneswwds_59_tfpostulacionessecuserid) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesSecUserId] >= @AV164Postulacioneswwds_59_tfpostulacionessecuserid)");
         }
         else
         {
            GXv_int12[62] = 1;
         }
         if ( ! (0==AV165Postulacioneswwds_60_tfpostulacionessecuserid_to) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesSecUserId] <= @AV165Postulacioneswwds_60_tfpostulacionessecuserid_to)");
         }
         else
         {
            GXv_int12[63] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[PostulacionesTipoFecha]";
         GXv_Object13[0] = scmdbuf;
         GXv_Object13[1] = GXv_int12;
         return GXv_Object13 ;
      }

      protected Object[] conditional_P00LA15( IGxContext context ,
                                              string A424PostulacionesEstado ,
                                              GxSimpleCollection<string> AV163Postulacioneswwds_58_tfpostulacionesestado_sels ,
                                              string AV107Postulacioneswwds_2_dynamicfiltersselector1 ,
                                              short AV108Postulacioneswwds_3_dynamicfiltersoperator1 ,
                                              string AV109Postulacioneswwds_4_postulacionesproveedornombre1 ,
                                              long AV110Postulacioneswwds_5_postulacionesproveedorid1 ,
                                              string AV111Postulacioneswwds_6_serviciosnombre1 ,
                                              bool AV112Postulacioneswwds_7_dynamicfiltersenabled2 ,
                                              string AV113Postulacioneswwds_8_dynamicfiltersselector2 ,
                                              short AV114Postulacioneswwds_9_dynamicfiltersoperator2 ,
                                              string AV115Postulacioneswwds_10_postulacionesproveedornombre2 ,
                                              long AV116Postulacioneswwds_11_postulacionesproveedorid2 ,
                                              string AV117Postulacioneswwds_12_serviciosnombre2 ,
                                              bool AV118Postulacioneswwds_13_dynamicfiltersenabled3 ,
                                              string AV119Postulacioneswwds_14_dynamicfiltersselector3 ,
                                              short AV120Postulacioneswwds_15_dynamicfiltersoperator3 ,
                                              string AV121Postulacioneswwds_16_postulacionesproveedornombre3 ,
                                              long AV122Postulacioneswwds_17_postulacionesproveedorid3 ,
                                              string AV123Postulacioneswwds_18_serviciosnombre3 ,
                                              long AV124Postulacioneswwds_19_tfpostulacionesid ,
                                              long AV125Postulacioneswwds_20_tfpostulacionesid_to ,
                                              long AV126Postulacioneswwds_21_tfserviciosid ,
                                              long AV127Postulacioneswwds_22_tfserviciosid_to ,
                                              string AV129Postulacioneswwds_24_tfserviciosnombre_sel ,
                                              string AV128Postulacioneswwds_23_tfserviciosnombre ,
                                              long AV130Postulacioneswwds_25_tfpostulacionesproveedorid ,
                                              long AV131Postulacioneswwds_26_tfpostulacionesproveedorid_to ,
                                              string AV133Postulacioneswwds_28_tfpostulacionesproveedornombre_sel ,
                                              string AV132Postulacioneswwds_27_tfpostulacionesproveedornombre ,
                                              decimal AV134Postulacioneswwds_29_tfpostulacionesprecio ,
                                              decimal AV135Postulacioneswwds_30_tfpostulacionesprecio_to ,
                                              short AV136Postulacioneswwds_31_tfpostulacionesmultimediaserial ,
                                              short AV137Postulacioneswwds_32_tfpostulacionesmultimediaserial_to ,
                                              string AV141Postulacioneswwds_36_tfpostulacionesdescripcion_sel ,
                                              string AV140Postulacioneswwds_35_tfpostulacionesdescripcion ,
                                              short AV142Postulacioneswwds_37_tfpostulacionesreqsuministros_sel ,
                                              string AV144Postulacioneswwds_39_tfpostulacionessuministrosdescripcion_sel ,
                                              string AV143Postulacioneswwds_38_tfpostulacionessuministrosdescripcion ,
                                              DateTime AV145Postulacioneswwds_40_tfpostulacionesfechatrabajo ,
                                              DateTime AV146Postulacioneswwds_41_tfpostulacionesfechatrabajo_to ,
                                              DateTime AV147Postulacioneswwds_42_tfpostulacionesfechacierre ,
                                              DateTime AV148Postulacioneswwds_43_tfpostulacionesfechacierre_to ,
                                              string AV150Postulacioneswwds_45_tfpostulacioneshoracierre_sel ,
                                              string AV149Postulacioneswwds_44_tfpostulacioneshoracierre ,
                                              string AV152Postulacioneswwds_47_tfpostulacionestipofecha_sel ,
                                              string AV151Postulacioneswwds_46_tfpostulacionestipofecha ,
                                              string AV154Postulacioneswwds_49_tfpostulacionesrgohoraservicio_sel ,
                                              string AV153Postulacioneswwds_48_tfpostulacionesrgohoraservicio ,
                                              string AV156Postulacioneswwds_51_tfpostulacionesapellidonombre_sel ,
                                              string AV155Postulacioneswwds_50_tfpostulacionesapellidonombre ,
                                              string AV158Postulacioneswwds_53_tfpostulacionesmail_sel ,
                                              string AV157Postulacioneswwds_52_tfpostulacionesmail ,
                                              string AV160Postulacioneswwds_55_tfpostulacionestelefono_sel ,
                                              string AV159Postulacioneswwds_54_tfpostulacionestelefono ,
                                              DateTime AV161Postulacioneswwds_56_tfpostulacionesfechaalta ,
                                              DateTime AV162Postulacioneswwds_57_tfpostulacionesfechaalta_to ,
                                              int AV163Postulacioneswwds_58_tfpostulacionesestado_sels_Count ,
                                              long AV164Postulacioneswwds_59_tfpostulacionessecuserid ,
                                              long AV165Postulacioneswwds_60_tfpostulacionessecuserid_to ,
                                              string A969PostulacionesProveedorNombre ,
                                              long A945PostulacionesProveedorId ,
                                              string A943ServiciosNombre ,
                                              long A422PostulacionesId ,
                                              long A942ServiciosId ,
                                              decimal A946PostulacionesPrecio ,
                                              short A961PostulacionesMultimediaSerial ,
                                              string A936PostulacionesDescripcion ,
                                              bool A937PostulacionesReqSuministros ,
                                              string A938PostulacionesSuministrosDescri ,
                                              DateTime A947PostulacionesFechaTrabajo ,
                                              DateTime A939PostulacionesFechaCierre ,
                                              string A940PostulacionesHoraCierre ,
                                              string A941PostulacionesTipoFecha ,
                                              string A949PostulacionesRgoHoraservicio ,
                                              string A950PostulacionesApellidoNombre ,
                                              string A951PostulacionesMail ,
                                              string A952PostulacionesTelefono ,
                                              DateTime A425PostulacionesFechaAlta ,
                                              long A948PostulacionesSecUserId ,
                                              string AV106Postulacioneswwds_1_filterfulltext ,
                                              long A970PostulacionesSolicitudesId ,
                                              long AV138Postulacioneswwds_33_tfpostulacionessolicitudesid ,
                                              long AV139Postulacioneswwds_34_tfpostulacionessolicitudesid_to )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int14 = new short[64];
         Object[] GXv_Object15 = new Object[2];
         scmdbuf = "SELECT T1.[PostulacionesRgoHoraservicio], T1.[PostulacionesSecUserId], T1.[PostulacionesFechaAlta], T1.[PostulacionesTelefono], T1.[PostulacionesMail], T1.[PostulacionesApellidoNombre], T1.[PostulacionesTipoFecha], T1.[PostulacionesHoraCierre], T1.[PostulacionesFechaCierre], T1.[PostulacionesFechaTrabajo], T1.[PostulacionesSuministrosDescri], T1.[PostulacionesReqSuministros], T1.[PostulacionesDescripcion], T1.[PostulacionesMultimediaSerial], T1.[PostulacionesPrecio], T3.[ProveedorNombre] AS PostulacionesProveedorNombre, T2.[ServiciosNombre], T1.[ServiciosId], T1.[PostulacionesId], T1.[PostulacionesProveedorId] AS PostulacionesProveedorId, T1.[PostulacionesEstado], COALESCE( T4.[PostulacionesSolicitudesId], 0) AS PostulacionesSolicitudesId FROM (([Postulaciones] T1 LEFT JOIN [Servicios] T2 ON T2.[ServiciosId] = T1.[ServiciosId]) INNER JOIN [Proveedor] T3 ON T3.[ProveedorID] = T1.[PostulacionesProveedorId]),  (SELECT MIN([SolicitudesID]) AS PostulacionesSolicitudesId FROM [Solicitudes] WHERE [PostulacionesId] = @PostulacionesId ) T4";
         AddWhere(sWhereString, "((@AV138Postulacioneswwds_33_tfpostulacionessolicitudesid = convert(int, 0)) or ( COALESCE( T4.[PostulacionesSolicitudesId], 0) >= @AV138Postulacioneswwds_33_tfpostulacionessolicitudesid))");
         AddWhere(sWhereString, "((@AV139Postulacioneswwds_34_tfpostulacionessolicitudesid_to = convert(int, 0)) or ( COALESCE( T4.[PostulacionesSolicitudesId], 0) <= @AV139Postulacioneswwds_34_tfpostulacionessolicitudesid_to))");
         if ( ( StringUtil.StrCmp(AV107Postulacioneswwds_2_dynamicfiltersselector1, "POSTULACIONESPROVEEDORNOMBRE") == 0 ) && ( AV108Postulacioneswwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV109Postulacioneswwds_4_postulacionesproveedornombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T3.[ProveedorNombre]) like UPPER(@lV109Postulacioneswwds_4_postulacionesproveedornombre1))");
         }
         else
         {
            GXv_int14[5] = 1;
         }
         if ( ( StringUtil.StrCmp(AV107Postulacioneswwds_2_dynamicfiltersselector1, "POSTULACIONESPROVEEDORNOMBRE") == 0 ) && ( AV108Postulacioneswwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV109Postulacioneswwds_4_postulacionesproveedornombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T3.[ProveedorNombre]) like '%' + UPPER(@lV109Postulacioneswwds_4_postulacionesproveedornombre1))");
         }
         else
         {
            GXv_int14[6] = 1;
         }
         if ( ( StringUtil.StrCmp(AV107Postulacioneswwds_2_dynamicfiltersselector1, "POSTULACIONESPROVEEDORID") == 0 ) && ( AV108Postulacioneswwds_3_dynamicfiltersoperator1 == 0 ) && ( ! (0==AV110Postulacioneswwds_5_postulacionesproveedorid1) ) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesProveedorId] < @AV110Postulacioneswwds_5_postulacionesproveedorid1)");
         }
         else
         {
            GXv_int14[7] = 1;
         }
         if ( ( StringUtil.StrCmp(AV107Postulacioneswwds_2_dynamicfiltersselector1, "POSTULACIONESPROVEEDORID") == 0 ) && ( AV108Postulacioneswwds_3_dynamicfiltersoperator1 == 1 ) && ( ! (0==AV110Postulacioneswwds_5_postulacionesproveedorid1) ) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesProveedorId] = @AV110Postulacioneswwds_5_postulacionesproveedorid1)");
         }
         else
         {
            GXv_int14[8] = 1;
         }
         if ( ( StringUtil.StrCmp(AV107Postulacioneswwds_2_dynamicfiltersselector1, "POSTULACIONESPROVEEDORID") == 0 ) && ( AV108Postulacioneswwds_3_dynamicfiltersoperator1 == 2 ) && ( ! (0==AV110Postulacioneswwds_5_postulacionesproveedorid1) ) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesProveedorId] > @AV110Postulacioneswwds_5_postulacionesproveedorid1)");
         }
         else
         {
            GXv_int14[9] = 1;
         }
         if ( ( StringUtil.StrCmp(AV107Postulacioneswwds_2_dynamicfiltersselector1, "SERVICIOSNOMBRE") == 0 ) && ( AV108Postulacioneswwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV111Postulacioneswwds_6_serviciosnombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ServiciosNombre]) like UPPER(@lV111Postulacioneswwds_6_serviciosnombre1))");
         }
         else
         {
            GXv_int14[10] = 1;
         }
         if ( ( StringUtil.StrCmp(AV107Postulacioneswwds_2_dynamicfiltersselector1, "SERVICIOSNOMBRE") == 0 ) && ( AV108Postulacioneswwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV111Postulacioneswwds_6_serviciosnombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ServiciosNombre]) like '%' + UPPER(@lV111Postulacioneswwds_6_serviciosnombre1))");
         }
         else
         {
            GXv_int14[11] = 1;
         }
         if ( AV112Postulacioneswwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV113Postulacioneswwds_8_dynamicfiltersselector2, "POSTULACIONESPROVEEDORNOMBRE") == 0 ) && ( AV114Postulacioneswwds_9_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV115Postulacioneswwds_10_postulacionesproveedornombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T3.[ProveedorNombre]) like UPPER(@lV115Postulacioneswwds_10_postulacionesproveedornombre2))");
         }
         else
         {
            GXv_int14[12] = 1;
         }
         if ( AV112Postulacioneswwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV113Postulacioneswwds_8_dynamicfiltersselector2, "POSTULACIONESPROVEEDORNOMBRE") == 0 ) && ( AV114Postulacioneswwds_9_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV115Postulacioneswwds_10_postulacionesproveedornombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T3.[ProveedorNombre]) like '%' + UPPER(@lV115Postulacioneswwds_10_postulacionesproveedornombre2))");
         }
         else
         {
            GXv_int14[13] = 1;
         }
         if ( AV112Postulacioneswwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV113Postulacioneswwds_8_dynamicfiltersselector2, "POSTULACIONESPROVEEDORID") == 0 ) && ( AV114Postulacioneswwds_9_dynamicfiltersoperator2 == 0 ) && ( ! (0==AV116Postulacioneswwds_11_postulacionesproveedorid2) ) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesProveedorId] < @AV116Postulacioneswwds_11_postulacionesproveedorid2)");
         }
         else
         {
            GXv_int14[14] = 1;
         }
         if ( AV112Postulacioneswwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV113Postulacioneswwds_8_dynamicfiltersselector2, "POSTULACIONESPROVEEDORID") == 0 ) && ( AV114Postulacioneswwds_9_dynamicfiltersoperator2 == 1 ) && ( ! (0==AV116Postulacioneswwds_11_postulacionesproveedorid2) ) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesProveedorId] = @AV116Postulacioneswwds_11_postulacionesproveedorid2)");
         }
         else
         {
            GXv_int14[15] = 1;
         }
         if ( AV112Postulacioneswwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV113Postulacioneswwds_8_dynamicfiltersselector2, "POSTULACIONESPROVEEDORID") == 0 ) && ( AV114Postulacioneswwds_9_dynamicfiltersoperator2 == 2 ) && ( ! (0==AV116Postulacioneswwds_11_postulacionesproveedorid2) ) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesProveedorId] > @AV116Postulacioneswwds_11_postulacionesproveedorid2)");
         }
         else
         {
            GXv_int14[16] = 1;
         }
         if ( AV112Postulacioneswwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV113Postulacioneswwds_8_dynamicfiltersselector2, "SERVICIOSNOMBRE") == 0 ) && ( AV114Postulacioneswwds_9_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV117Postulacioneswwds_12_serviciosnombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ServiciosNombre]) like UPPER(@lV117Postulacioneswwds_12_serviciosnombre2))");
         }
         else
         {
            GXv_int14[17] = 1;
         }
         if ( AV112Postulacioneswwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV113Postulacioneswwds_8_dynamicfiltersselector2, "SERVICIOSNOMBRE") == 0 ) && ( AV114Postulacioneswwds_9_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV117Postulacioneswwds_12_serviciosnombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ServiciosNombre]) like '%' + UPPER(@lV117Postulacioneswwds_12_serviciosnombre2))");
         }
         else
         {
            GXv_int14[18] = 1;
         }
         if ( AV118Postulacioneswwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV119Postulacioneswwds_14_dynamicfiltersselector3, "POSTULACIONESPROVEEDORNOMBRE") == 0 ) && ( AV120Postulacioneswwds_15_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV121Postulacioneswwds_16_postulacionesproveedornombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T3.[ProveedorNombre]) like UPPER(@lV121Postulacioneswwds_16_postulacionesproveedornombre3))");
         }
         else
         {
            GXv_int14[19] = 1;
         }
         if ( AV118Postulacioneswwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV119Postulacioneswwds_14_dynamicfiltersselector3, "POSTULACIONESPROVEEDORNOMBRE") == 0 ) && ( AV120Postulacioneswwds_15_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV121Postulacioneswwds_16_postulacionesproveedornombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T3.[ProveedorNombre]) like '%' + UPPER(@lV121Postulacioneswwds_16_postulacionesproveedornombre3))");
         }
         else
         {
            GXv_int14[20] = 1;
         }
         if ( AV118Postulacioneswwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV119Postulacioneswwds_14_dynamicfiltersselector3, "POSTULACIONESPROVEEDORID") == 0 ) && ( AV120Postulacioneswwds_15_dynamicfiltersoperator3 == 0 ) && ( ! (0==AV122Postulacioneswwds_17_postulacionesproveedorid3) ) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesProveedorId] < @AV122Postulacioneswwds_17_postulacionesproveedorid3)");
         }
         else
         {
            GXv_int14[21] = 1;
         }
         if ( AV118Postulacioneswwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV119Postulacioneswwds_14_dynamicfiltersselector3, "POSTULACIONESPROVEEDORID") == 0 ) && ( AV120Postulacioneswwds_15_dynamicfiltersoperator3 == 1 ) && ( ! (0==AV122Postulacioneswwds_17_postulacionesproveedorid3) ) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesProveedorId] = @AV122Postulacioneswwds_17_postulacionesproveedorid3)");
         }
         else
         {
            GXv_int14[22] = 1;
         }
         if ( AV118Postulacioneswwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV119Postulacioneswwds_14_dynamicfiltersselector3, "POSTULACIONESPROVEEDORID") == 0 ) && ( AV120Postulacioneswwds_15_dynamicfiltersoperator3 == 2 ) && ( ! (0==AV122Postulacioneswwds_17_postulacionesproveedorid3) ) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesProveedorId] > @AV122Postulacioneswwds_17_postulacionesproveedorid3)");
         }
         else
         {
            GXv_int14[23] = 1;
         }
         if ( AV118Postulacioneswwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV119Postulacioneswwds_14_dynamicfiltersselector3, "SERVICIOSNOMBRE") == 0 ) && ( AV120Postulacioneswwds_15_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV123Postulacioneswwds_18_serviciosnombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ServiciosNombre]) like UPPER(@lV123Postulacioneswwds_18_serviciosnombre3))");
         }
         else
         {
            GXv_int14[24] = 1;
         }
         if ( AV118Postulacioneswwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV119Postulacioneswwds_14_dynamicfiltersselector3, "SERVICIOSNOMBRE") == 0 ) && ( AV120Postulacioneswwds_15_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV123Postulacioneswwds_18_serviciosnombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ServiciosNombre]) like '%' + UPPER(@lV123Postulacioneswwds_18_serviciosnombre3))");
         }
         else
         {
            GXv_int14[25] = 1;
         }
         if ( ! (0==AV124Postulacioneswwds_19_tfpostulacionesid) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesId] >= @AV124Postulacioneswwds_19_tfpostulacionesid)");
         }
         else
         {
            GXv_int14[26] = 1;
         }
         if ( ! (0==AV125Postulacioneswwds_20_tfpostulacionesid_to) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesId] <= @AV125Postulacioneswwds_20_tfpostulacionesid_to)");
         }
         else
         {
            GXv_int14[27] = 1;
         }
         if ( ! (0==AV126Postulacioneswwds_21_tfserviciosid) )
         {
            AddWhere(sWhereString, "(T1.[ServiciosId] >= @AV126Postulacioneswwds_21_tfserviciosid)");
         }
         else
         {
            GXv_int14[28] = 1;
         }
         if ( ! (0==AV127Postulacioneswwds_22_tfserviciosid_to) )
         {
            AddWhere(sWhereString, "(T1.[ServiciosId] <= @AV127Postulacioneswwds_22_tfserviciosid_to)");
         }
         else
         {
            GXv_int14[29] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV129Postulacioneswwds_24_tfserviciosnombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV128Postulacioneswwds_23_tfserviciosnombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ServiciosNombre]) like UPPER(@lV128Postulacioneswwds_23_tfserviciosnombre))");
         }
         else
         {
            GXv_int14[30] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV129Postulacioneswwds_24_tfserviciosnombre_sel)) && ! ( StringUtil.StrCmp(AV129Postulacioneswwds_24_tfserviciosnombre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.[ServiciosNombre] = @AV129Postulacioneswwds_24_tfserviciosnombre_sel)");
         }
         else
         {
            GXv_int14[31] = 1;
         }
         if ( StringUtil.StrCmp(AV129Postulacioneswwds_24_tfserviciosnombre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T2.[ServiciosNombre] IS NULL or (T2.[ServiciosNombre] = ''))");
         }
         if ( ! (0==AV130Postulacioneswwds_25_tfpostulacionesproveedorid) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesProveedorId] >= @AV130Postulacioneswwds_25_tfpostulacionesproveedorid)");
         }
         else
         {
            GXv_int14[32] = 1;
         }
         if ( ! (0==AV131Postulacioneswwds_26_tfpostulacionesproveedorid_to) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesProveedorId] <= @AV131Postulacioneswwds_26_tfpostulacionesproveedorid_to)");
         }
         else
         {
            GXv_int14[33] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV133Postulacioneswwds_28_tfpostulacionesproveedornombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV132Postulacioneswwds_27_tfpostulacionesproveedornombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T3.[ProveedorNombre]) like UPPER(@lV132Postulacioneswwds_27_tfpostulacionesproveedornombre))");
         }
         else
         {
            GXv_int14[34] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV133Postulacioneswwds_28_tfpostulacionesproveedornombre_sel)) && ! ( StringUtil.StrCmp(AV133Postulacioneswwds_28_tfpostulacionesproveedornombre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T3.[ProveedorNombre] = @AV133Postulacioneswwds_28_tfpostulacionesproveedornombre_sel)");
         }
         else
         {
            GXv_int14[35] = 1;
         }
         if ( StringUtil.StrCmp(AV133Postulacioneswwds_28_tfpostulacionesproveedornombre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T3.[ProveedorNombre] = ''))");
         }
         if ( ! (Convert.ToDecimal(0)==AV134Postulacioneswwds_29_tfpostulacionesprecio) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesPrecio] >= @AV134Postulacioneswwds_29_tfpostulacionesprecio)");
         }
         else
         {
            GXv_int14[36] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV135Postulacioneswwds_30_tfpostulacionesprecio_to) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesPrecio] <= @AV135Postulacioneswwds_30_tfpostulacionesprecio_to)");
         }
         else
         {
            GXv_int14[37] = 1;
         }
         if ( ! (0==AV136Postulacioneswwds_31_tfpostulacionesmultimediaserial) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesMultimediaSerial] >= @AV136Postulacioneswwds_31_tfpostulacionesmultimediaserial)");
         }
         else
         {
            GXv_int14[38] = 1;
         }
         if ( ! (0==AV137Postulacioneswwds_32_tfpostulacionesmultimediaserial_to) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesMultimediaSerial] <= @AV137Postulacioneswwds_32_tfpostulacionesmultimediaserial_to)");
         }
         else
         {
            GXv_int14[39] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV141Postulacioneswwds_36_tfpostulacionesdescripcion_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV140Postulacioneswwds_35_tfpostulacionesdescripcion)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[PostulacionesDescripcion]) like UPPER(@lV140Postulacioneswwds_35_tfpostulacionesdescripcion))");
         }
         else
         {
            GXv_int14[40] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV141Postulacioneswwds_36_tfpostulacionesdescripcion_sel)) && ! ( StringUtil.StrCmp(AV141Postulacioneswwds_36_tfpostulacionesdescripcion_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesDescripcion] = @AV141Postulacioneswwds_36_tfpostulacionesdescripcion_sel)");
         }
         else
         {
            GXv_int14[41] = 1;
         }
         if ( StringUtil.StrCmp(AV141Postulacioneswwds_36_tfpostulacionesdescripcion_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[PostulacionesDescripcion] = ''))");
         }
         if ( AV142Postulacioneswwds_37_tfpostulacionesreqsuministros_sel == 1 )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesReqSuministros] = 1)");
         }
         if ( AV142Postulacioneswwds_37_tfpostulacionesreqsuministros_sel == 2 )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesReqSuministros] = 0)");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV144Postulacioneswwds_39_tfpostulacionessuministrosdescripcion_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV143Postulacioneswwds_38_tfpostulacionessuministrosdescripcion)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[PostulacionesSuministrosDescri]) like UPPER(@lV143Postulacioneswwds_38_tfpostulacionessuministrosdescripcion))");
         }
         else
         {
            GXv_int14[42] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV144Postulacioneswwds_39_tfpostulacionessuministrosdescripcion_sel)) && ! ( StringUtil.StrCmp(AV144Postulacioneswwds_39_tfpostulacionessuministrosdescripcion_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesSuministrosDescri] = @AV144Postulacioneswwds_39_tfpostulacionessuministrosdescripcion_sel)");
         }
         else
         {
            GXv_int14[43] = 1;
         }
         if ( StringUtil.StrCmp(AV144Postulacioneswwds_39_tfpostulacionessuministrosdescripcion_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[PostulacionesSuministrosDescri] = ''))");
         }
         if ( ! (DateTime.MinValue==AV145Postulacioneswwds_40_tfpostulacionesfechatrabajo) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesFechaTrabajo] >= @AV145Postulacioneswwds_40_tfpostulacionesfechatrabajo)");
         }
         else
         {
            GXv_int14[44] = 1;
         }
         if ( ! (DateTime.MinValue==AV146Postulacioneswwds_41_tfpostulacionesfechatrabajo_to) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesFechaTrabajo] <= @AV146Postulacioneswwds_41_tfpostulacionesfechatrabajo_to)");
         }
         else
         {
            GXv_int14[45] = 1;
         }
         if ( ! (DateTime.MinValue==AV147Postulacioneswwds_42_tfpostulacionesfechacierre) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesFechaCierre] >= @AV147Postulacioneswwds_42_tfpostulacionesfechacierre)");
         }
         else
         {
            GXv_int14[46] = 1;
         }
         if ( ! (DateTime.MinValue==AV148Postulacioneswwds_43_tfpostulacionesfechacierre_to) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesFechaCierre] <= @AV148Postulacioneswwds_43_tfpostulacionesfechacierre_to)");
         }
         else
         {
            GXv_int14[47] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV150Postulacioneswwds_45_tfpostulacioneshoracierre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV149Postulacioneswwds_44_tfpostulacioneshoracierre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[PostulacionesHoraCierre]) like UPPER(@lV149Postulacioneswwds_44_tfpostulacioneshoracierre))");
         }
         else
         {
            GXv_int14[48] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV150Postulacioneswwds_45_tfpostulacioneshoracierre_sel)) && ! ( StringUtil.StrCmp(AV150Postulacioneswwds_45_tfpostulacioneshoracierre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesHoraCierre] = @AV150Postulacioneswwds_45_tfpostulacioneshoracierre_sel)");
         }
         else
         {
            GXv_int14[49] = 1;
         }
         if ( StringUtil.StrCmp(AV150Postulacioneswwds_45_tfpostulacioneshoracierre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[PostulacionesHoraCierre] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV152Postulacioneswwds_47_tfpostulacionestipofecha_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV151Postulacioneswwds_46_tfpostulacionestipofecha)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[PostulacionesTipoFecha]) like UPPER(@lV151Postulacioneswwds_46_tfpostulacionestipofecha))");
         }
         else
         {
            GXv_int14[50] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV152Postulacioneswwds_47_tfpostulacionestipofecha_sel)) && ! ( StringUtil.StrCmp(AV152Postulacioneswwds_47_tfpostulacionestipofecha_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesTipoFecha] = @AV152Postulacioneswwds_47_tfpostulacionestipofecha_sel)");
         }
         else
         {
            GXv_int14[51] = 1;
         }
         if ( StringUtil.StrCmp(AV152Postulacioneswwds_47_tfpostulacionestipofecha_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[PostulacionesTipoFecha] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV154Postulacioneswwds_49_tfpostulacionesrgohoraservicio_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV153Postulacioneswwds_48_tfpostulacionesrgohoraservicio)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[PostulacionesRgoHoraservicio]) like UPPER(@lV153Postulacioneswwds_48_tfpostulacionesrgohoraservicio))");
         }
         else
         {
            GXv_int14[52] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV154Postulacioneswwds_49_tfpostulacionesrgohoraservicio_sel)) && ! ( StringUtil.StrCmp(AV154Postulacioneswwds_49_tfpostulacionesrgohoraservicio_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesRgoHoraservicio] = @AV154Postulacioneswwds_49_tfpostulacionesrgohoraservicio_sel)");
         }
         else
         {
            GXv_int14[53] = 1;
         }
         if ( StringUtil.StrCmp(AV154Postulacioneswwds_49_tfpostulacionesrgohoraservicio_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[PostulacionesRgoHoraservicio] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV156Postulacioneswwds_51_tfpostulacionesapellidonombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV155Postulacioneswwds_50_tfpostulacionesapellidonombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[PostulacionesApellidoNombre]) like UPPER(@lV155Postulacioneswwds_50_tfpostulacionesapellidonombre))");
         }
         else
         {
            GXv_int14[54] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV156Postulacioneswwds_51_tfpostulacionesapellidonombre_sel)) && ! ( StringUtil.StrCmp(AV156Postulacioneswwds_51_tfpostulacionesapellidonombre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesApellidoNombre] = @AV156Postulacioneswwds_51_tfpostulacionesapellidonombre_sel)");
         }
         else
         {
            GXv_int14[55] = 1;
         }
         if ( StringUtil.StrCmp(AV156Postulacioneswwds_51_tfpostulacionesapellidonombre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[PostulacionesApellidoNombre] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV158Postulacioneswwds_53_tfpostulacionesmail_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV157Postulacioneswwds_52_tfpostulacionesmail)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[PostulacionesMail]) like UPPER(@lV157Postulacioneswwds_52_tfpostulacionesmail))");
         }
         else
         {
            GXv_int14[56] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV158Postulacioneswwds_53_tfpostulacionesmail_sel)) && ! ( StringUtil.StrCmp(AV158Postulacioneswwds_53_tfpostulacionesmail_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesMail] = @AV158Postulacioneswwds_53_tfpostulacionesmail_sel)");
         }
         else
         {
            GXv_int14[57] = 1;
         }
         if ( StringUtil.StrCmp(AV158Postulacioneswwds_53_tfpostulacionesmail_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[PostulacionesMail] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV160Postulacioneswwds_55_tfpostulacionestelefono_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV159Postulacioneswwds_54_tfpostulacionestelefono)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[PostulacionesTelefono]) like UPPER(@lV159Postulacioneswwds_54_tfpostulacionestelefono))");
         }
         else
         {
            GXv_int14[58] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV160Postulacioneswwds_55_tfpostulacionestelefono_sel)) && ! ( StringUtil.StrCmp(AV160Postulacioneswwds_55_tfpostulacionestelefono_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesTelefono] = @AV160Postulacioneswwds_55_tfpostulacionestelefono_sel)");
         }
         else
         {
            GXv_int14[59] = 1;
         }
         if ( StringUtil.StrCmp(AV160Postulacioneswwds_55_tfpostulacionestelefono_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[PostulacionesTelefono] = ''))");
         }
         if ( ! (DateTime.MinValue==AV161Postulacioneswwds_56_tfpostulacionesfechaalta) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesFechaAlta] >= @AV161Postulacioneswwds_56_tfpostulacionesfechaalta)");
         }
         else
         {
            GXv_int14[60] = 1;
         }
         if ( ! (DateTime.MinValue==AV162Postulacioneswwds_57_tfpostulacionesfechaalta_to) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesFechaAlta] <= @AV162Postulacioneswwds_57_tfpostulacionesfechaalta_to)");
         }
         else
         {
            GXv_int14[61] = 1;
         }
         if ( AV163Postulacioneswwds_58_tfpostulacionesestado_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV163Postulacioneswwds_58_tfpostulacionesestado_sels, "T1.[PostulacionesEstado] IN (", ")")+")");
         }
         if ( ! (0==AV164Postulacioneswwds_59_tfpostulacionessecuserid) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesSecUserId] >= @AV164Postulacioneswwds_59_tfpostulacionessecuserid)");
         }
         else
         {
            GXv_int14[62] = 1;
         }
         if ( ! (0==AV165Postulacioneswwds_60_tfpostulacionessecuserid_to) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesSecUserId] <= @AV165Postulacioneswwds_60_tfpostulacionessecuserid_to)");
         }
         else
         {
            GXv_int14[63] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[PostulacionesRgoHoraservicio]";
         GXv_Object15[0] = scmdbuf;
         GXv_Object15[1] = GXv_int14;
         return GXv_Object15 ;
      }

      protected Object[] conditional_P00LA17( IGxContext context ,
                                              string A424PostulacionesEstado ,
                                              GxSimpleCollection<string> AV163Postulacioneswwds_58_tfpostulacionesestado_sels ,
                                              string AV107Postulacioneswwds_2_dynamicfiltersselector1 ,
                                              short AV108Postulacioneswwds_3_dynamicfiltersoperator1 ,
                                              string AV109Postulacioneswwds_4_postulacionesproveedornombre1 ,
                                              long AV110Postulacioneswwds_5_postulacionesproveedorid1 ,
                                              string AV111Postulacioneswwds_6_serviciosnombre1 ,
                                              bool AV112Postulacioneswwds_7_dynamicfiltersenabled2 ,
                                              string AV113Postulacioneswwds_8_dynamicfiltersselector2 ,
                                              short AV114Postulacioneswwds_9_dynamicfiltersoperator2 ,
                                              string AV115Postulacioneswwds_10_postulacionesproveedornombre2 ,
                                              long AV116Postulacioneswwds_11_postulacionesproveedorid2 ,
                                              string AV117Postulacioneswwds_12_serviciosnombre2 ,
                                              bool AV118Postulacioneswwds_13_dynamicfiltersenabled3 ,
                                              string AV119Postulacioneswwds_14_dynamicfiltersselector3 ,
                                              short AV120Postulacioneswwds_15_dynamicfiltersoperator3 ,
                                              string AV121Postulacioneswwds_16_postulacionesproveedornombre3 ,
                                              long AV122Postulacioneswwds_17_postulacionesproveedorid3 ,
                                              string AV123Postulacioneswwds_18_serviciosnombre3 ,
                                              long AV124Postulacioneswwds_19_tfpostulacionesid ,
                                              long AV125Postulacioneswwds_20_tfpostulacionesid_to ,
                                              long AV126Postulacioneswwds_21_tfserviciosid ,
                                              long AV127Postulacioneswwds_22_tfserviciosid_to ,
                                              string AV129Postulacioneswwds_24_tfserviciosnombre_sel ,
                                              string AV128Postulacioneswwds_23_tfserviciosnombre ,
                                              long AV130Postulacioneswwds_25_tfpostulacionesproveedorid ,
                                              long AV131Postulacioneswwds_26_tfpostulacionesproveedorid_to ,
                                              string AV133Postulacioneswwds_28_tfpostulacionesproveedornombre_sel ,
                                              string AV132Postulacioneswwds_27_tfpostulacionesproveedornombre ,
                                              decimal AV134Postulacioneswwds_29_tfpostulacionesprecio ,
                                              decimal AV135Postulacioneswwds_30_tfpostulacionesprecio_to ,
                                              short AV136Postulacioneswwds_31_tfpostulacionesmultimediaserial ,
                                              short AV137Postulacioneswwds_32_tfpostulacionesmultimediaserial_to ,
                                              string AV141Postulacioneswwds_36_tfpostulacionesdescripcion_sel ,
                                              string AV140Postulacioneswwds_35_tfpostulacionesdescripcion ,
                                              short AV142Postulacioneswwds_37_tfpostulacionesreqsuministros_sel ,
                                              string AV144Postulacioneswwds_39_tfpostulacionessuministrosdescripcion_sel ,
                                              string AV143Postulacioneswwds_38_tfpostulacionessuministrosdescripcion ,
                                              DateTime AV145Postulacioneswwds_40_tfpostulacionesfechatrabajo ,
                                              DateTime AV146Postulacioneswwds_41_tfpostulacionesfechatrabajo_to ,
                                              DateTime AV147Postulacioneswwds_42_tfpostulacionesfechacierre ,
                                              DateTime AV148Postulacioneswwds_43_tfpostulacionesfechacierre_to ,
                                              string AV150Postulacioneswwds_45_tfpostulacioneshoracierre_sel ,
                                              string AV149Postulacioneswwds_44_tfpostulacioneshoracierre ,
                                              string AV152Postulacioneswwds_47_tfpostulacionestipofecha_sel ,
                                              string AV151Postulacioneswwds_46_tfpostulacionestipofecha ,
                                              string AV154Postulacioneswwds_49_tfpostulacionesrgohoraservicio_sel ,
                                              string AV153Postulacioneswwds_48_tfpostulacionesrgohoraservicio ,
                                              string AV156Postulacioneswwds_51_tfpostulacionesapellidonombre_sel ,
                                              string AV155Postulacioneswwds_50_tfpostulacionesapellidonombre ,
                                              string AV158Postulacioneswwds_53_tfpostulacionesmail_sel ,
                                              string AV157Postulacioneswwds_52_tfpostulacionesmail ,
                                              string AV160Postulacioneswwds_55_tfpostulacionestelefono_sel ,
                                              string AV159Postulacioneswwds_54_tfpostulacionestelefono ,
                                              DateTime AV161Postulacioneswwds_56_tfpostulacionesfechaalta ,
                                              DateTime AV162Postulacioneswwds_57_tfpostulacionesfechaalta_to ,
                                              int AV163Postulacioneswwds_58_tfpostulacionesestado_sels_Count ,
                                              long AV164Postulacioneswwds_59_tfpostulacionessecuserid ,
                                              long AV165Postulacioneswwds_60_tfpostulacionessecuserid_to ,
                                              string A969PostulacionesProveedorNombre ,
                                              long A945PostulacionesProveedorId ,
                                              string A943ServiciosNombre ,
                                              long A422PostulacionesId ,
                                              long A942ServiciosId ,
                                              decimal A946PostulacionesPrecio ,
                                              short A961PostulacionesMultimediaSerial ,
                                              string A936PostulacionesDescripcion ,
                                              bool A937PostulacionesReqSuministros ,
                                              string A938PostulacionesSuministrosDescri ,
                                              DateTime A947PostulacionesFechaTrabajo ,
                                              DateTime A939PostulacionesFechaCierre ,
                                              string A940PostulacionesHoraCierre ,
                                              string A941PostulacionesTipoFecha ,
                                              string A949PostulacionesRgoHoraservicio ,
                                              string A950PostulacionesApellidoNombre ,
                                              string A951PostulacionesMail ,
                                              string A952PostulacionesTelefono ,
                                              DateTime A425PostulacionesFechaAlta ,
                                              long A948PostulacionesSecUserId ,
                                              string AV106Postulacioneswwds_1_filterfulltext ,
                                              long A970PostulacionesSolicitudesId ,
                                              long AV138Postulacioneswwds_33_tfpostulacionessolicitudesid ,
                                              long AV139Postulacioneswwds_34_tfpostulacionessolicitudesid_to )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int16 = new short[64];
         Object[] GXv_Object17 = new Object[2];
         scmdbuf = "SELECT T1.[PostulacionesApellidoNombre], T1.[PostulacionesSecUserId], T1.[PostulacionesFechaAlta], T1.[PostulacionesTelefono], T1.[PostulacionesMail], T1.[PostulacionesRgoHoraservicio], T1.[PostulacionesTipoFecha], T1.[PostulacionesHoraCierre], T1.[PostulacionesFechaCierre], T1.[PostulacionesFechaTrabajo], T1.[PostulacionesSuministrosDescri], T1.[PostulacionesReqSuministros], T1.[PostulacionesDescripcion], T1.[PostulacionesMultimediaSerial], T1.[PostulacionesPrecio], T3.[ProveedorNombre] AS PostulacionesProveedorNombre, T2.[ServiciosNombre], T1.[ServiciosId], T1.[PostulacionesId], T1.[PostulacionesProveedorId] AS PostulacionesProveedorId, T1.[PostulacionesEstado], COALESCE( T4.[PostulacionesSolicitudesId], 0) AS PostulacionesSolicitudesId FROM (([Postulaciones] T1 LEFT JOIN [Servicios] T2 ON T2.[ServiciosId] = T1.[ServiciosId]) INNER JOIN [Proveedor] T3 ON T3.[ProveedorID] = T1.[PostulacionesProveedorId]),  (SELECT MIN([SolicitudesID]) AS PostulacionesSolicitudesId FROM [Solicitudes] WHERE [PostulacionesId] = @PostulacionesId ) T4";
         AddWhere(sWhereString, "((@AV138Postulacioneswwds_33_tfpostulacionessolicitudesid = convert(int, 0)) or ( COALESCE( T4.[PostulacionesSolicitudesId], 0) >= @AV138Postulacioneswwds_33_tfpostulacionessolicitudesid))");
         AddWhere(sWhereString, "((@AV139Postulacioneswwds_34_tfpostulacionessolicitudesid_to = convert(int, 0)) or ( COALESCE( T4.[PostulacionesSolicitudesId], 0) <= @AV139Postulacioneswwds_34_tfpostulacionessolicitudesid_to))");
         if ( ( StringUtil.StrCmp(AV107Postulacioneswwds_2_dynamicfiltersselector1, "POSTULACIONESPROVEEDORNOMBRE") == 0 ) && ( AV108Postulacioneswwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV109Postulacioneswwds_4_postulacionesproveedornombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T3.[ProveedorNombre]) like UPPER(@lV109Postulacioneswwds_4_postulacionesproveedornombre1))");
         }
         else
         {
            GXv_int16[5] = 1;
         }
         if ( ( StringUtil.StrCmp(AV107Postulacioneswwds_2_dynamicfiltersselector1, "POSTULACIONESPROVEEDORNOMBRE") == 0 ) && ( AV108Postulacioneswwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV109Postulacioneswwds_4_postulacionesproveedornombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T3.[ProveedorNombre]) like '%' + UPPER(@lV109Postulacioneswwds_4_postulacionesproveedornombre1))");
         }
         else
         {
            GXv_int16[6] = 1;
         }
         if ( ( StringUtil.StrCmp(AV107Postulacioneswwds_2_dynamicfiltersselector1, "POSTULACIONESPROVEEDORID") == 0 ) && ( AV108Postulacioneswwds_3_dynamicfiltersoperator1 == 0 ) && ( ! (0==AV110Postulacioneswwds_5_postulacionesproveedorid1) ) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesProveedorId] < @AV110Postulacioneswwds_5_postulacionesproveedorid1)");
         }
         else
         {
            GXv_int16[7] = 1;
         }
         if ( ( StringUtil.StrCmp(AV107Postulacioneswwds_2_dynamicfiltersselector1, "POSTULACIONESPROVEEDORID") == 0 ) && ( AV108Postulacioneswwds_3_dynamicfiltersoperator1 == 1 ) && ( ! (0==AV110Postulacioneswwds_5_postulacionesproveedorid1) ) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesProveedorId] = @AV110Postulacioneswwds_5_postulacionesproveedorid1)");
         }
         else
         {
            GXv_int16[8] = 1;
         }
         if ( ( StringUtil.StrCmp(AV107Postulacioneswwds_2_dynamicfiltersselector1, "POSTULACIONESPROVEEDORID") == 0 ) && ( AV108Postulacioneswwds_3_dynamicfiltersoperator1 == 2 ) && ( ! (0==AV110Postulacioneswwds_5_postulacionesproveedorid1) ) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesProveedorId] > @AV110Postulacioneswwds_5_postulacionesproveedorid1)");
         }
         else
         {
            GXv_int16[9] = 1;
         }
         if ( ( StringUtil.StrCmp(AV107Postulacioneswwds_2_dynamicfiltersselector1, "SERVICIOSNOMBRE") == 0 ) && ( AV108Postulacioneswwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV111Postulacioneswwds_6_serviciosnombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ServiciosNombre]) like UPPER(@lV111Postulacioneswwds_6_serviciosnombre1))");
         }
         else
         {
            GXv_int16[10] = 1;
         }
         if ( ( StringUtil.StrCmp(AV107Postulacioneswwds_2_dynamicfiltersselector1, "SERVICIOSNOMBRE") == 0 ) && ( AV108Postulacioneswwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV111Postulacioneswwds_6_serviciosnombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ServiciosNombre]) like '%' + UPPER(@lV111Postulacioneswwds_6_serviciosnombre1))");
         }
         else
         {
            GXv_int16[11] = 1;
         }
         if ( AV112Postulacioneswwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV113Postulacioneswwds_8_dynamicfiltersselector2, "POSTULACIONESPROVEEDORNOMBRE") == 0 ) && ( AV114Postulacioneswwds_9_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV115Postulacioneswwds_10_postulacionesproveedornombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T3.[ProveedorNombre]) like UPPER(@lV115Postulacioneswwds_10_postulacionesproveedornombre2))");
         }
         else
         {
            GXv_int16[12] = 1;
         }
         if ( AV112Postulacioneswwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV113Postulacioneswwds_8_dynamicfiltersselector2, "POSTULACIONESPROVEEDORNOMBRE") == 0 ) && ( AV114Postulacioneswwds_9_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV115Postulacioneswwds_10_postulacionesproveedornombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T3.[ProveedorNombre]) like '%' + UPPER(@lV115Postulacioneswwds_10_postulacionesproveedornombre2))");
         }
         else
         {
            GXv_int16[13] = 1;
         }
         if ( AV112Postulacioneswwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV113Postulacioneswwds_8_dynamicfiltersselector2, "POSTULACIONESPROVEEDORID") == 0 ) && ( AV114Postulacioneswwds_9_dynamicfiltersoperator2 == 0 ) && ( ! (0==AV116Postulacioneswwds_11_postulacionesproveedorid2) ) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesProveedorId] < @AV116Postulacioneswwds_11_postulacionesproveedorid2)");
         }
         else
         {
            GXv_int16[14] = 1;
         }
         if ( AV112Postulacioneswwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV113Postulacioneswwds_8_dynamicfiltersselector2, "POSTULACIONESPROVEEDORID") == 0 ) && ( AV114Postulacioneswwds_9_dynamicfiltersoperator2 == 1 ) && ( ! (0==AV116Postulacioneswwds_11_postulacionesproveedorid2) ) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesProveedorId] = @AV116Postulacioneswwds_11_postulacionesproveedorid2)");
         }
         else
         {
            GXv_int16[15] = 1;
         }
         if ( AV112Postulacioneswwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV113Postulacioneswwds_8_dynamicfiltersselector2, "POSTULACIONESPROVEEDORID") == 0 ) && ( AV114Postulacioneswwds_9_dynamicfiltersoperator2 == 2 ) && ( ! (0==AV116Postulacioneswwds_11_postulacionesproveedorid2) ) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesProveedorId] > @AV116Postulacioneswwds_11_postulacionesproveedorid2)");
         }
         else
         {
            GXv_int16[16] = 1;
         }
         if ( AV112Postulacioneswwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV113Postulacioneswwds_8_dynamicfiltersselector2, "SERVICIOSNOMBRE") == 0 ) && ( AV114Postulacioneswwds_9_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV117Postulacioneswwds_12_serviciosnombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ServiciosNombre]) like UPPER(@lV117Postulacioneswwds_12_serviciosnombre2))");
         }
         else
         {
            GXv_int16[17] = 1;
         }
         if ( AV112Postulacioneswwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV113Postulacioneswwds_8_dynamicfiltersselector2, "SERVICIOSNOMBRE") == 0 ) && ( AV114Postulacioneswwds_9_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV117Postulacioneswwds_12_serviciosnombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ServiciosNombre]) like '%' + UPPER(@lV117Postulacioneswwds_12_serviciosnombre2))");
         }
         else
         {
            GXv_int16[18] = 1;
         }
         if ( AV118Postulacioneswwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV119Postulacioneswwds_14_dynamicfiltersselector3, "POSTULACIONESPROVEEDORNOMBRE") == 0 ) && ( AV120Postulacioneswwds_15_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV121Postulacioneswwds_16_postulacionesproveedornombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T3.[ProveedorNombre]) like UPPER(@lV121Postulacioneswwds_16_postulacionesproveedornombre3))");
         }
         else
         {
            GXv_int16[19] = 1;
         }
         if ( AV118Postulacioneswwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV119Postulacioneswwds_14_dynamicfiltersselector3, "POSTULACIONESPROVEEDORNOMBRE") == 0 ) && ( AV120Postulacioneswwds_15_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV121Postulacioneswwds_16_postulacionesproveedornombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T3.[ProveedorNombre]) like '%' + UPPER(@lV121Postulacioneswwds_16_postulacionesproveedornombre3))");
         }
         else
         {
            GXv_int16[20] = 1;
         }
         if ( AV118Postulacioneswwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV119Postulacioneswwds_14_dynamicfiltersselector3, "POSTULACIONESPROVEEDORID") == 0 ) && ( AV120Postulacioneswwds_15_dynamicfiltersoperator3 == 0 ) && ( ! (0==AV122Postulacioneswwds_17_postulacionesproveedorid3) ) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesProveedorId] < @AV122Postulacioneswwds_17_postulacionesproveedorid3)");
         }
         else
         {
            GXv_int16[21] = 1;
         }
         if ( AV118Postulacioneswwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV119Postulacioneswwds_14_dynamicfiltersselector3, "POSTULACIONESPROVEEDORID") == 0 ) && ( AV120Postulacioneswwds_15_dynamicfiltersoperator3 == 1 ) && ( ! (0==AV122Postulacioneswwds_17_postulacionesproveedorid3) ) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesProveedorId] = @AV122Postulacioneswwds_17_postulacionesproveedorid3)");
         }
         else
         {
            GXv_int16[22] = 1;
         }
         if ( AV118Postulacioneswwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV119Postulacioneswwds_14_dynamicfiltersselector3, "POSTULACIONESPROVEEDORID") == 0 ) && ( AV120Postulacioneswwds_15_dynamicfiltersoperator3 == 2 ) && ( ! (0==AV122Postulacioneswwds_17_postulacionesproveedorid3) ) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesProveedorId] > @AV122Postulacioneswwds_17_postulacionesproveedorid3)");
         }
         else
         {
            GXv_int16[23] = 1;
         }
         if ( AV118Postulacioneswwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV119Postulacioneswwds_14_dynamicfiltersselector3, "SERVICIOSNOMBRE") == 0 ) && ( AV120Postulacioneswwds_15_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV123Postulacioneswwds_18_serviciosnombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ServiciosNombre]) like UPPER(@lV123Postulacioneswwds_18_serviciosnombre3))");
         }
         else
         {
            GXv_int16[24] = 1;
         }
         if ( AV118Postulacioneswwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV119Postulacioneswwds_14_dynamicfiltersselector3, "SERVICIOSNOMBRE") == 0 ) && ( AV120Postulacioneswwds_15_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV123Postulacioneswwds_18_serviciosnombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ServiciosNombre]) like '%' + UPPER(@lV123Postulacioneswwds_18_serviciosnombre3))");
         }
         else
         {
            GXv_int16[25] = 1;
         }
         if ( ! (0==AV124Postulacioneswwds_19_tfpostulacionesid) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesId] >= @AV124Postulacioneswwds_19_tfpostulacionesid)");
         }
         else
         {
            GXv_int16[26] = 1;
         }
         if ( ! (0==AV125Postulacioneswwds_20_tfpostulacionesid_to) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesId] <= @AV125Postulacioneswwds_20_tfpostulacionesid_to)");
         }
         else
         {
            GXv_int16[27] = 1;
         }
         if ( ! (0==AV126Postulacioneswwds_21_tfserviciosid) )
         {
            AddWhere(sWhereString, "(T1.[ServiciosId] >= @AV126Postulacioneswwds_21_tfserviciosid)");
         }
         else
         {
            GXv_int16[28] = 1;
         }
         if ( ! (0==AV127Postulacioneswwds_22_tfserviciosid_to) )
         {
            AddWhere(sWhereString, "(T1.[ServiciosId] <= @AV127Postulacioneswwds_22_tfserviciosid_to)");
         }
         else
         {
            GXv_int16[29] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV129Postulacioneswwds_24_tfserviciosnombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV128Postulacioneswwds_23_tfserviciosnombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ServiciosNombre]) like UPPER(@lV128Postulacioneswwds_23_tfserviciosnombre))");
         }
         else
         {
            GXv_int16[30] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV129Postulacioneswwds_24_tfserviciosnombre_sel)) && ! ( StringUtil.StrCmp(AV129Postulacioneswwds_24_tfserviciosnombre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.[ServiciosNombre] = @AV129Postulacioneswwds_24_tfserviciosnombre_sel)");
         }
         else
         {
            GXv_int16[31] = 1;
         }
         if ( StringUtil.StrCmp(AV129Postulacioneswwds_24_tfserviciosnombre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T2.[ServiciosNombre] IS NULL or (T2.[ServiciosNombre] = ''))");
         }
         if ( ! (0==AV130Postulacioneswwds_25_tfpostulacionesproveedorid) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesProveedorId] >= @AV130Postulacioneswwds_25_tfpostulacionesproveedorid)");
         }
         else
         {
            GXv_int16[32] = 1;
         }
         if ( ! (0==AV131Postulacioneswwds_26_tfpostulacionesproveedorid_to) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesProveedorId] <= @AV131Postulacioneswwds_26_tfpostulacionesproveedorid_to)");
         }
         else
         {
            GXv_int16[33] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV133Postulacioneswwds_28_tfpostulacionesproveedornombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV132Postulacioneswwds_27_tfpostulacionesproveedornombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T3.[ProveedorNombre]) like UPPER(@lV132Postulacioneswwds_27_tfpostulacionesproveedornombre))");
         }
         else
         {
            GXv_int16[34] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV133Postulacioneswwds_28_tfpostulacionesproveedornombre_sel)) && ! ( StringUtil.StrCmp(AV133Postulacioneswwds_28_tfpostulacionesproveedornombre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T3.[ProveedorNombre] = @AV133Postulacioneswwds_28_tfpostulacionesproveedornombre_sel)");
         }
         else
         {
            GXv_int16[35] = 1;
         }
         if ( StringUtil.StrCmp(AV133Postulacioneswwds_28_tfpostulacionesproveedornombre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T3.[ProveedorNombre] = ''))");
         }
         if ( ! (Convert.ToDecimal(0)==AV134Postulacioneswwds_29_tfpostulacionesprecio) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesPrecio] >= @AV134Postulacioneswwds_29_tfpostulacionesprecio)");
         }
         else
         {
            GXv_int16[36] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV135Postulacioneswwds_30_tfpostulacionesprecio_to) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesPrecio] <= @AV135Postulacioneswwds_30_tfpostulacionesprecio_to)");
         }
         else
         {
            GXv_int16[37] = 1;
         }
         if ( ! (0==AV136Postulacioneswwds_31_tfpostulacionesmultimediaserial) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesMultimediaSerial] >= @AV136Postulacioneswwds_31_tfpostulacionesmultimediaserial)");
         }
         else
         {
            GXv_int16[38] = 1;
         }
         if ( ! (0==AV137Postulacioneswwds_32_tfpostulacionesmultimediaserial_to) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesMultimediaSerial] <= @AV137Postulacioneswwds_32_tfpostulacionesmultimediaserial_to)");
         }
         else
         {
            GXv_int16[39] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV141Postulacioneswwds_36_tfpostulacionesdescripcion_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV140Postulacioneswwds_35_tfpostulacionesdescripcion)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[PostulacionesDescripcion]) like UPPER(@lV140Postulacioneswwds_35_tfpostulacionesdescripcion))");
         }
         else
         {
            GXv_int16[40] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV141Postulacioneswwds_36_tfpostulacionesdescripcion_sel)) && ! ( StringUtil.StrCmp(AV141Postulacioneswwds_36_tfpostulacionesdescripcion_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesDescripcion] = @AV141Postulacioneswwds_36_tfpostulacionesdescripcion_sel)");
         }
         else
         {
            GXv_int16[41] = 1;
         }
         if ( StringUtil.StrCmp(AV141Postulacioneswwds_36_tfpostulacionesdescripcion_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[PostulacionesDescripcion] = ''))");
         }
         if ( AV142Postulacioneswwds_37_tfpostulacionesreqsuministros_sel == 1 )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesReqSuministros] = 1)");
         }
         if ( AV142Postulacioneswwds_37_tfpostulacionesreqsuministros_sel == 2 )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesReqSuministros] = 0)");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV144Postulacioneswwds_39_tfpostulacionessuministrosdescripcion_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV143Postulacioneswwds_38_tfpostulacionessuministrosdescripcion)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[PostulacionesSuministrosDescri]) like UPPER(@lV143Postulacioneswwds_38_tfpostulacionessuministrosdescripcion))");
         }
         else
         {
            GXv_int16[42] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV144Postulacioneswwds_39_tfpostulacionessuministrosdescripcion_sel)) && ! ( StringUtil.StrCmp(AV144Postulacioneswwds_39_tfpostulacionessuministrosdescripcion_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesSuministrosDescri] = @AV144Postulacioneswwds_39_tfpostulacionessuministrosdescripcion_sel)");
         }
         else
         {
            GXv_int16[43] = 1;
         }
         if ( StringUtil.StrCmp(AV144Postulacioneswwds_39_tfpostulacionessuministrosdescripcion_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[PostulacionesSuministrosDescri] = ''))");
         }
         if ( ! (DateTime.MinValue==AV145Postulacioneswwds_40_tfpostulacionesfechatrabajo) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesFechaTrabajo] >= @AV145Postulacioneswwds_40_tfpostulacionesfechatrabajo)");
         }
         else
         {
            GXv_int16[44] = 1;
         }
         if ( ! (DateTime.MinValue==AV146Postulacioneswwds_41_tfpostulacionesfechatrabajo_to) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesFechaTrabajo] <= @AV146Postulacioneswwds_41_tfpostulacionesfechatrabajo_to)");
         }
         else
         {
            GXv_int16[45] = 1;
         }
         if ( ! (DateTime.MinValue==AV147Postulacioneswwds_42_tfpostulacionesfechacierre) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesFechaCierre] >= @AV147Postulacioneswwds_42_tfpostulacionesfechacierre)");
         }
         else
         {
            GXv_int16[46] = 1;
         }
         if ( ! (DateTime.MinValue==AV148Postulacioneswwds_43_tfpostulacionesfechacierre_to) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesFechaCierre] <= @AV148Postulacioneswwds_43_tfpostulacionesfechacierre_to)");
         }
         else
         {
            GXv_int16[47] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV150Postulacioneswwds_45_tfpostulacioneshoracierre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV149Postulacioneswwds_44_tfpostulacioneshoracierre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[PostulacionesHoraCierre]) like UPPER(@lV149Postulacioneswwds_44_tfpostulacioneshoracierre))");
         }
         else
         {
            GXv_int16[48] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV150Postulacioneswwds_45_tfpostulacioneshoracierre_sel)) && ! ( StringUtil.StrCmp(AV150Postulacioneswwds_45_tfpostulacioneshoracierre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesHoraCierre] = @AV150Postulacioneswwds_45_tfpostulacioneshoracierre_sel)");
         }
         else
         {
            GXv_int16[49] = 1;
         }
         if ( StringUtil.StrCmp(AV150Postulacioneswwds_45_tfpostulacioneshoracierre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[PostulacionesHoraCierre] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV152Postulacioneswwds_47_tfpostulacionestipofecha_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV151Postulacioneswwds_46_tfpostulacionestipofecha)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[PostulacionesTipoFecha]) like UPPER(@lV151Postulacioneswwds_46_tfpostulacionestipofecha))");
         }
         else
         {
            GXv_int16[50] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV152Postulacioneswwds_47_tfpostulacionestipofecha_sel)) && ! ( StringUtil.StrCmp(AV152Postulacioneswwds_47_tfpostulacionestipofecha_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesTipoFecha] = @AV152Postulacioneswwds_47_tfpostulacionestipofecha_sel)");
         }
         else
         {
            GXv_int16[51] = 1;
         }
         if ( StringUtil.StrCmp(AV152Postulacioneswwds_47_tfpostulacionestipofecha_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[PostulacionesTipoFecha] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV154Postulacioneswwds_49_tfpostulacionesrgohoraservicio_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV153Postulacioneswwds_48_tfpostulacionesrgohoraservicio)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[PostulacionesRgoHoraservicio]) like UPPER(@lV153Postulacioneswwds_48_tfpostulacionesrgohoraservicio))");
         }
         else
         {
            GXv_int16[52] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV154Postulacioneswwds_49_tfpostulacionesrgohoraservicio_sel)) && ! ( StringUtil.StrCmp(AV154Postulacioneswwds_49_tfpostulacionesrgohoraservicio_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesRgoHoraservicio] = @AV154Postulacioneswwds_49_tfpostulacionesrgohoraservicio_sel)");
         }
         else
         {
            GXv_int16[53] = 1;
         }
         if ( StringUtil.StrCmp(AV154Postulacioneswwds_49_tfpostulacionesrgohoraservicio_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[PostulacionesRgoHoraservicio] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV156Postulacioneswwds_51_tfpostulacionesapellidonombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV155Postulacioneswwds_50_tfpostulacionesapellidonombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[PostulacionesApellidoNombre]) like UPPER(@lV155Postulacioneswwds_50_tfpostulacionesapellidonombre))");
         }
         else
         {
            GXv_int16[54] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV156Postulacioneswwds_51_tfpostulacionesapellidonombre_sel)) && ! ( StringUtil.StrCmp(AV156Postulacioneswwds_51_tfpostulacionesapellidonombre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesApellidoNombre] = @AV156Postulacioneswwds_51_tfpostulacionesapellidonombre_sel)");
         }
         else
         {
            GXv_int16[55] = 1;
         }
         if ( StringUtil.StrCmp(AV156Postulacioneswwds_51_tfpostulacionesapellidonombre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[PostulacionesApellidoNombre] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV158Postulacioneswwds_53_tfpostulacionesmail_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV157Postulacioneswwds_52_tfpostulacionesmail)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[PostulacionesMail]) like UPPER(@lV157Postulacioneswwds_52_tfpostulacionesmail))");
         }
         else
         {
            GXv_int16[56] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV158Postulacioneswwds_53_tfpostulacionesmail_sel)) && ! ( StringUtil.StrCmp(AV158Postulacioneswwds_53_tfpostulacionesmail_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesMail] = @AV158Postulacioneswwds_53_tfpostulacionesmail_sel)");
         }
         else
         {
            GXv_int16[57] = 1;
         }
         if ( StringUtil.StrCmp(AV158Postulacioneswwds_53_tfpostulacionesmail_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[PostulacionesMail] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV160Postulacioneswwds_55_tfpostulacionestelefono_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV159Postulacioneswwds_54_tfpostulacionestelefono)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[PostulacionesTelefono]) like UPPER(@lV159Postulacioneswwds_54_tfpostulacionestelefono))");
         }
         else
         {
            GXv_int16[58] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV160Postulacioneswwds_55_tfpostulacionestelefono_sel)) && ! ( StringUtil.StrCmp(AV160Postulacioneswwds_55_tfpostulacionestelefono_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesTelefono] = @AV160Postulacioneswwds_55_tfpostulacionestelefono_sel)");
         }
         else
         {
            GXv_int16[59] = 1;
         }
         if ( StringUtil.StrCmp(AV160Postulacioneswwds_55_tfpostulacionestelefono_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[PostulacionesTelefono] = ''))");
         }
         if ( ! (DateTime.MinValue==AV161Postulacioneswwds_56_tfpostulacionesfechaalta) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesFechaAlta] >= @AV161Postulacioneswwds_56_tfpostulacionesfechaalta)");
         }
         else
         {
            GXv_int16[60] = 1;
         }
         if ( ! (DateTime.MinValue==AV162Postulacioneswwds_57_tfpostulacionesfechaalta_to) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesFechaAlta] <= @AV162Postulacioneswwds_57_tfpostulacionesfechaalta_to)");
         }
         else
         {
            GXv_int16[61] = 1;
         }
         if ( AV163Postulacioneswwds_58_tfpostulacionesestado_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV163Postulacioneswwds_58_tfpostulacionesestado_sels, "T1.[PostulacionesEstado] IN (", ")")+")");
         }
         if ( ! (0==AV164Postulacioneswwds_59_tfpostulacionessecuserid) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesSecUserId] >= @AV164Postulacioneswwds_59_tfpostulacionessecuserid)");
         }
         else
         {
            GXv_int16[62] = 1;
         }
         if ( ! (0==AV165Postulacioneswwds_60_tfpostulacionessecuserid_to) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesSecUserId] <= @AV165Postulacioneswwds_60_tfpostulacionessecuserid_to)");
         }
         else
         {
            GXv_int16[63] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[PostulacionesApellidoNombre]";
         GXv_Object17[0] = scmdbuf;
         GXv_Object17[1] = GXv_int16;
         return GXv_Object17 ;
      }

      protected Object[] conditional_P00LA19( IGxContext context ,
                                              string A424PostulacionesEstado ,
                                              GxSimpleCollection<string> AV163Postulacioneswwds_58_tfpostulacionesestado_sels ,
                                              string AV107Postulacioneswwds_2_dynamicfiltersselector1 ,
                                              short AV108Postulacioneswwds_3_dynamicfiltersoperator1 ,
                                              string AV109Postulacioneswwds_4_postulacionesproveedornombre1 ,
                                              long AV110Postulacioneswwds_5_postulacionesproveedorid1 ,
                                              string AV111Postulacioneswwds_6_serviciosnombre1 ,
                                              bool AV112Postulacioneswwds_7_dynamicfiltersenabled2 ,
                                              string AV113Postulacioneswwds_8_dynamicfiltersselector2 ,
                                              short AV114Postulacioneswwds_9_dynamicfiltersoperator2 ,
                                              string AV115Postulacioneswwds_10_postulacionesproveedornombre2 ,
                                              long AV116Postulacioneswwds_11_postulacionesproveedorid2 ,
                                              string AV117Postulacioneswwds_12_serviciosnombre2 ,
                                              bool AV118Postulacioneswwds_13_dynamicfiltersenabled3 ,
                                              string AV119Postulacioneswwds_14_dynamicfiltersselector3 ,
                                              short AV120Postulacioneswwds_15_dynamicfiltersoperator3 ,
                                              string AV121Postulacioneswwds_16_postulacionesproveedornombre3 ,
                                              long AV122Postulacioneswwds_17_postulacionesproveedorid3 ,
                                              string AV123Postulacioneswwds_18_serviciosnombre3 ,
                                              long AV124Postulacioneswwds_19_tfpostulacionesid ,
                                              long AV125Postulacioneswwds_20_tfpostulacionesid_to ,
                                              long AV126Postulacioneswwds_21_tfserviciosid ,
                                              long AV127Postulacioneswwds_22_tfserviciosid_to ,
                                              string AV129Postulacioneswwds_24_tfserviciosnombre_sel ,
                                              string AV128Postulacioneswwds_23_tfserviciosnombre ,
                                              long AV130Postulacioneswwds_25_tfpostulacionesproveedorid ,
                                              long AV131Postulacioneswwds_26_tfpostulacionesproveedorid_to ,
                                              string AV133Postulacioneswwds_28_tfpostulacionesproveedornombre_sel ,
                                              string AV132Postulacioneswwds_27_tfpostulacionesproveedornombre ,
                                              decimal AV134Postulacioneswwds_29_tfpostulacionesprecio ,
                                              decimal AV135Postulacioneswwds_30_tfpostulacionesprecio_to ,
                                              short AV136Postulacioneswwds_31_tfpostulacionesmultimediaserial ,
                                              short AV137Postulacioneswwds_32_tfpostulacionesmultimediaserial_to ,
                                              string AV141Postulacioneswwds_36_tfpostulacionesdescripcion_sel ,
                                              string AV140Postulacioneswwds_35_tfpostulacionesdescripcion ,
                                              short AV142Postulacioneswwds_37_tfpostulacionesreqsuministros_sel ,
                                              string AV144Postulacioneswwds_39_tfpostulacionessuministrosdescripcion_sel ,
                                              string AV143Postulacioneswwds_38_tfpostulacionessuministrosdescripcion ,
                                              DateTime AV145Postulacioneswwds_40_tfpostulacionesfechatrabajo ,
                                              DateTime AV146Postulacioneswwds_41_tfpostulacionesfechatrabajo_to ,
                                              DateTime AV147Postulacioneswwds_42_tfpostulacionesfechacierre ,
                                              DateTime AV148Postulacioneswwds_43_tfpostulacionesfechacierre_to ,
                                              string AV150Postulacioneswwds_45_tfpostulacioneshoracierre_sel ,
                                              string AV149Postulacioneswwds_44_tfpostulacioneshoracierre ,
                                              string AV152Postulacioneswwds_47_tfpostulacionestipofecha_sel ,
                                              string AV151Postulacioneswwds_46_tfpostulacionestipofecha ,
                                              string AV154Postulacioneswwds_49_tfpostulacionesrgohoraservicio_sel ,
                                              string AV153Postulacioneswwds_48_tfpostulacionesrgohoraservicio ,
                                              string AV156Postulacioneswwds_51_tfpostulacionesapellidonombre_sel ,
                                              string AV155Postulacioneswwds_50_tfpostulacionesapellidonombre ,
                                              string AV158Postulacioneswwds_53_tfpostulacionesmail_sel ,
                                              string AV157Postulacioneswwds_52_tfpostulacionesmail ,
                                              string AV160Postulacioneswwds_55_tfpostulacionestelefono_sel ,
                                              string AV159Postulacioneswwds_54_tfpostulacionestelefono ,
                                              DateTime AV161Postulacioneswwds_56_tfpostulacionesfechaalta ,
                                              DateTime AV162Postulacioneswwds_57_tfpostulacionesfechaalta_to ,
                                              int AV163Postulacioneswwds_58_tfpostulacionesestado_sels_Count ,
                                              long AV164Postulacioneswwds_59_tfpostulacionessecuserid ,
                                              long AV165Postulacioneswwds_60_tfpostulacionessecuserid_to ,
                                              string A969PostulacionesProveedorNombre ,
                                              long A945PostulacionesProveedorId ,
                                              string A943ServiciosNombre ,
                                              long A422PostulacionesId ,
                                              long A942ServiciosId ,
                                              decimal A946PostulacionesPrecio ,
                                              short A961PostulacionesMultimediaSerial ,
                                              string A936PostulacionesDescripcion ,
                                              bool A937PostulacionesReqSuministros ,
                                              string A938PostulacionesSuministrosDescri ,
                                              DateTime A947PostulacionesFechaTrabajo ,
                                              DateTime A939PostulacionesFechaCierre ,
                                              string A940PostulacionesHoraCierre ,
                                              string A941PostulacionesTipoFecha ,
                                              string A949PostulacionesRgoHoraservicio ,
                                              string A950PostulacionesApellidoNombre ,
                                              string A951PostulacionesMail ,
                                              string A952PostulacionesTelefono ,
                                              DateTime A425PostulacionesFechaAlta ,
                                              long A948PostulacionesSecUserId ,
                                              string AV106Postulacioneswwds_1_filterfulltext ,
                                              long A970PostulacionesSolicitudesId ,
                                              long AV138Postulacioneswwds_33_tfpostulacionessolicitudesid ,
                                              long AV139Postulacioneswwds_34_tfpostulacionessolicitudesid_to )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int18 = new short[64];
         Object[] GXv_Object19 = new Object[2];
         scmdbuf = "SELECT T1.[PostulacionesMail], T1.[PostulacionesSecUserId], T1.[PostulacionesFechaAlta], T1.[PostulacionesTelefono], T1.[PostulacionesApellidoNombre], T1.[PostulacionesRgoHoraservicio], T1.[PostulacionesTipoFecha], T1.[PostulacionesHoraCierre], T1.[PostulacionesFechaCierre], T1.[PostulacionesFechaTrabajo], T1.[PostulacionesSuministrosDescri], T1.[PostulacionesReqSuministros], T1.[PostulacionesDescripcion], T1.[PostulacionesMultimediaSerial], T1.[PostulacionesPrecio], T3.[ProveedorNombre] AS PostulacionesProveedorNombre, T2.[ServiciosNombre], T1.[ServiciosId], T1.[PostulacionesId], T1.[PostulacionesProveedorId] AS PostulacionesProveedorId, T1.[PostulacionesEstado], COALESCE( T4.[PostulacionesSolicitudesId], 0) AS PostulacionesSolicitudesId FROM (([Postulaciones] T1 LEFT JOIN [Servicios] T2 ON T2.[ServiciosId] = T1.[ServiciosId]) INNER JOIN [Proveedor] T3 ON T3.[ProveedorID] = T1.[PostulacionesProveedorId]),  (SELECT MIN([SolicitudesID]) AS PostulacionesSolicitudesId FROM [Solicitudes] WHERE [PostulacionesId] = @PostulacionesId ) T4";
         AddWhere(sWhereString, "((@AV138Postulacioneswwds_33_tfpostulacionessolicitudesid = convert(int, 0)) or ( COALESCE( T4.[PostulacionesSolicitudesId], 0) >= @AV138Postulacioneswwds_33_tfpostulacionessolicitudesid))");
         AddWhere(sWhereString, "((@AV139Postulacioneswwds_34_tfpostulacionessolicitudesid_to = convert(int, 0)) or ( COALESCE( T4.[PostulacionesSolicitudesId], 0) <= @AV139Postulacioneswwds_34_tfpostulacionessolicitudesid_to))");
         if ( ( StringUtil.StrCmp(AV107Postulacioneswwds_2_dynamicfiltersselector1, "POSTULACIONESPROVEEDORNOMBRE") == 0 ) && ( AV108Postulacioneswwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV109Postulacioneswwds_4_postulacionesproveedornombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T3.[ProveedorNombre]) like UPPER(@lV109Postulacioneswwds_4_postulacionesproveedornombre1))");
         }
         else
         {
            GXv_int18[5] = 1;
         }
         if ( ( StringUtil.StrCmp(AV107Postulacioneswwds_2_dynamicfiltersselector1, "POSTULACIONESPROVEEDORNOMBRE") == 0 ) && ( AV108Postulacioneswwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV109Postulacioneswwds_4_postulacionesproveedornombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T3.[ProveedorNombre]) like '%' + UPPER(@lV109Postulacioneswwds_4_postulacionesproveedornombre1))");
         }
         else
         {
            GXv_int18[6] = 1;
         }
         if ( ( StringUtil.StrCmp(AV107Postulacioneswwds_2_dynamicfiltersselector1, "POSTULACIONESPROVEEDORID") == 0 ) && ( AV108Postulacioneswwds_3_dynamicfiltersoperator1 == 0 ) && ( ! (0==AV110Postulacioneswwds_5_postulacionesproveedorid1) ) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesProveedorId] < @AV110Postulacioneswwds_5_postulacionesproveedorid1)");
         }
         else
         {
            GXv_int18[7] = 1;
         }
         if ( ( StringUtil.StrCmp(AV107Postulacioneswwds_2_dynamicfiltersselector1, "POSTULACIONESPROVEEDORID") == 0 ) && ( AV108Postulacioneswwds_3_dynamicfiltersoperator1 == 1 ) && ( ! (0==AV110Postulacioneswwds_5_postulacionesproveedorid1) ) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesProveedorId] = @AV110Postulacioneswwds_5_postulacionesproveedorid1)");
         }
         else
         {
            GXv_int18[8] = 1;
         }
         if ( ( StringUtil.StrCmp(AV107Postulacioneswwds_2_dynamicfiltersselector1, "POSTULACIONESPROVEEDORID") == 0 ) && ( AV108Postulacioneswwds_3_dynamicfiltersoperator1 == 2 ) && ( ! (0==AV110Postulacioneswwds_5_postulacionesproveedorid1) ) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesProveedorId] > @AV110Postulacioneswwds_5_postulacionesproveedorid1)");
         }
         else
         {
            GXv_int18[9] = 1;
         }
         if ( ( StringUtil.StrCmp(AV107Postulacioneswwds_2_dynamicfiltersselector1, "SERVICIOSNOMBRE") == 0 ) && ( AV108Postulacioneswwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV111Postulacioneswwds_6_serviciosnombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ServiciosNombre]) like UPPER(@lV111Postulacioneswwds_6_serviciosnombre1))");
         }
         else
         {
            GXv_int18[10] = 1;
         }
         if ( ( StringUtil.StrCmp(AV107Postulacioneswwds_2_dynamicfiltersselector1, "SERVICIOSNOMBRE") == 0 ) && ( AV108Postulacioneswwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV111Postulacioneswwds_6_serviciosnombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ServiciosNombre]) like '%' + UPPER(@lV111Postulacioneswwds_6_serviciosnombre1))");
         }
         else
         {
            GXv_int18[11] = 1;
         }
         if ( AV112Postulacioneswwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV113Postulacioneswwds_8_dynamicfiltersselector2, "POSTULACIONESPROVEEDORNOMBRE") == 0 ) && ( AV114Postulacioneswwds_9_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV115Postulacioneswwds_10_postulacionesproveedornombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T3.[ProveedorNombre]) like UPPER(@lV115Postulacioneswwds_10_postulacionesproveedornombre2))");
         }
         else
         {
            GXv_int18[12] = 1;
         }
         if ( AV112Postulacioneswwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV113Postulacioneswwds_8_dynamicfiltersselector2, "POSTULACIONESPROVEEDORNOMBRE") == 0 ) && ( AV114Postulacioneswwds_9_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV115Postulacioneswwds_10_postulacionesproveedornombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T3.[ProveedorNombre]) like '%' + UPPER(@lV115Postulacioneswwds_10_postulacionesproveedornombre2))");
         }
         else
         {
            GXv_int18[13] = 1;
         }
         if ( AV112Postulacioneswwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV113Postulacioneswwds_8_dynamicfiltersselector2, "POSTULACIONESPROVEEDORID") == 0 ) && ( AV114Postulacioneswwds_9_dynamicfiltersoperator2 == 0 ) && ( ! (0==AV116Postulacioneswwds_11_postulacionesproveedorid2) ) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesProveedorId] < @AV116Postulacioneswwds_11_postulacionesproveedorid2)");
         }
         else
         {
            GXv_int18[14] = 1;
         }
         if ( AV112Postulacioneswwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV113Postulacioneswwds_8_dynamicfiltersselector2, "POSTULACIONESPROVEEDORID") == 0 ) && ( AV114Postulacioneswwds_9_dynamicfiltersoperator2 == 1 ) && ( ! (0==AV116Postulacioneswwds_11_postulacionesproveedorid2) ) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesProveedorId] = @AV116Postulacioneswwds_11_postulacionesproveedorid2)");
         }
         else
         {
            GXv_int18[15] = 1;
         }
         if ( AV112Postulacioneswwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV113Postulacioneswwds_8_dynamicfiltersselector2, "POSTULACIONESPROVEEDORID") == 0 ) && ( AV114Postulacioneswwds_9_dynamicfiltersoperator2 == 2 ) && ( ! (0==AV116Postulacioneswwds_11_postulacionesproveedorid2) ) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesProveedorId] > @AV116Postulacioneswwds_11_postulacionesproveedorid2)");
         }
         else
         {
            GXv_int18[16] = 1;
         }
         if ( AV112Postulacioneswwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV113Postulacioneswwds_8_dynamicfiltersselector2, "SERVICIOSNOMBRE") == 0 ) && ( AV114Postulacioneswwds_9_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV117Postulacioneswwds_12_serviciosnombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ServiciosNombre]) like UPPER(@lV117Postulacioneswwds_12_serviciosnombre2))");
         }
         else
         {
            GXv_int18[17] = 1;
         }
         if ( AV112Postulacioneswwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV113Postulacioneswwds_8_dynamicfiltersselector2, "SERVICIOSNOMBRE") == 0 ) && ( AV114Postulacioneswwds_9_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV117Postulacioneswwds_12_serviciosnombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ServiciosNombre]) like '%' + UPPER(@lV117Postulacioneswwds_12_serviciosnombre2))");
         }
         else
         {
            GXv_int18[18] = 1;
         }
         if ( AV118Postulacioneswwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV119Postulacioneswwds_14_dynamicfiltersselector3, "POSTULACIONESPROVEEDORNOMBRE") == 0 ) && ( AV120Postulacioneswwds_15_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV121Postulacioneswwds_16_postulacionesproveedornombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T3.[ProveedorNombre]) like UPPER(@lV121Postulacioneswwds_16_postulacionesproveedornombre3))");
         }
         else
         {
            GXv_int18[19] = 1;
         }
         if ( AV118Postulacioneswwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV119Postulacioneswwds_14_dynamicfiltersselector3, "POSTULACIONESPROVEEDORNOMBRE") == 0 ) && ( AV120Postulacioneswwds_15_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV121Postulacioneswwds_16_postulacionesproveedornombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T3.[ProveedorNombre]) like '%' + UPPER(@lV121Postulacioneswwds_16_postulacionesproveedornombre3))");
         }
         else
         {
            GXv_int18[20] = 1;
         }
         if ( AV118Postulacioneswwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV119Postulacioneswwds_14_dynamicfiltersselector3, "POSTULACIONESPROVEEDORID") == 0 ) && ( AV120Postulacioneswwds_15_dynamicfiltersoperator3 == 0 ) && ( ! (0==AV122Postulacioneswwds_17_postulacionesproveedorid3) ) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesProveedorId] < @AV122Postulacioneswwds_17_postulacionesproveedorid3)");
         }
         else
         {
            GXv_int18[21] = 1;
         }
         if ( AV118Postulacioneswwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV119Postulacioneswwds_14_dynamicfiltersselector3, "POSTULACIONESPROVEEDORID") == 0 ) && ( AV120Postulacioneswwds_15_dynamicfiltersoperator3 == 1 ) && ( ! (0==AV122Postulacioneswwds_17_postulacionesproveedorid3) ) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesProveedorId] = @AV122Postulacioneswwds_17_postulacionesproveedorid3)");
         }
         else
         {
            GXv_int18[22] = 1;
         }
         if ( AV118Postulacioneswwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV119Postulacioneswwds_14_dynamicfiltersselector3, "POSTULACIONESPROVEEDORID") == 0 ) && ( AV120Postulacioneswwds_15_dynamicfiltersoperator3 == 2 ) && ( ! (0==AV122Postulacioneswwds_17_postulacionesproveedorid3) ) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesProveedorId] > @AV122Postulacioneswwds_17_postulacionesproveedorid3)");
         }
         else
         {
            GXv_int18[23] = 1;
         }
         if ( AV118Postulacioneswwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV119Postulacioneswwds_14_dynamicfiltersselector3, "SERVICIOSNOMBRE") == 0 ) && ( AV120Postulacioneswwds_15_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV123Postulacioneswwds_18_serviciosnombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ServiciosNombre]) like UPPER(@lV123Postulacioneswwds_18_serviciosnombre3))");
         }
         else
         {
            GXv_int18[24] = 1;
         }
         if ( AV118Postulacioneswwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV119Postulacioneswwds_14_dynamicfiltersselector3, "SERVICIOSNOMBRE") == 0 ) && ( AV120Postulacioneswwds_15_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV123Postulacioneswwds_18_serviciosnombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ServiciosNombre]) like '%' + UPPER(@lV123Postulacioneswwds_18_serviciosnombre3))");
         }
         else
         {
            GXv_int18[25] = 1;
         }
         if ( ! (0==AV124Postulacioneswwds_19_tfpostulacionesid) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesId] >= @AV124Postulacioneswwds_19_tfpostulacionesid)");
         }
         else
         {
            GXv_int18[26] = 1;
         }
         if ( ! (0==AV125Postulacioneswwds_20_tfpostulacionesid_to) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesId] <= @AV125Postulacioneswwds_20_tfpostulacionesid_to)");
         }
         else
         {
            GXv_int18[27] = 1;
         }
         if ( ! (0==AV126Postulacioneswwds_21_tfserviciosid) )
         {
            AddWhere(sWhereString, "(T1.[ServiciosId] >= @AV126Postulacioneswwds_21_tfserviciosid)");
         }
         else
         {
            GXv_int18[28] = 1;
         }
         if ( ! (0==AV127Postulacioneswwds_22_tfserviciosid_to) )
         {
            AddWhere(sWhereString, "(T1.[ServiciosId] <= @AV127Postulacioneswwds_22_tfserviciosid_to)");
         }
         else
         {
            GXv_int18[29] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV129Postulacioneswwds_24_tfserviciosnombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV128Postulacioneswwds_23_tfserviciosnombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ServiciosNombre]) like UPPER(@lV128Postulacioneswwds_23_tfserviciosnombre))");
         }
         else
         {
            GXv_int18[30] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV129Postulacioneswwds_24_tfserviciosnombre_sel)) && ! ( StringUtil.StrCmp(AV129Postulacioneswwds_24_tfserviciosnombre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.[ServiciosNombre] = @AV129Postulacioneswwds_24_tfserviciosnombre_sel)");
         }
         else
         {
            GXv_int18[31] = 1;
         }
         if ( StringUtil.StrCmp(AV129Postulacioneswwds_24_tfserviciosnombre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T2.[ServiciosNombre] IS NULL or (T2.[ServiciosNombre] = ''))");
         }
         if ( ! (0==AV130Postulacioneswwds_25_tfpostulacionesproveedorid) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesProveedorId] >= @AV130Postulacioneswwds_25_tfpostulacionesproveedorid)");
         }
         else
         {
            GXv_int18[32] = 1;
         }
         if ( ! (0==AV131Postulacioneswwds_26_tfpostulacionesproveedorid_to) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesProveedorId] <= @AV131Postulacioneswwds_26_tfpostulacionesproveedorid_to)");
         }
         else
         {
            GXv_int18[33] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV133Postulacioneswwds_28_tfpostulacionesproveedornombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV132Postulacioneswwds_27_tfpostulacionesproveedornombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T3.[ProveedorNombre]) like UPPER(@lV132Postulacioneswwds_27_tfpostulacionesproveedornombre))");
         }
         else
         {
            GXv_int18[34] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV133Postulacioneswwds_28_tfpostulacionesproveedornombre_sel)) && ! ( StringUtil.StrCmp(AV133Postulacioneswwds_28_tfpostulacionesproveedornombre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T3.[ProveedorNombre] = @AV133Postulacioneswwds_28_tfpostulacionesproveedornombre_sel)");
         }
         else
         {
            GXv_int18[35] = 1;
         }
         if ( StringUtil.StrCmp(AV133Postulacioneswwds_28_tfpostulacionesproveedornombre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T3.[ProveedorNombre] = ''))");
         }
         if ( ! (Convert.ToDecimal(0)==AV134Postulacioneswwds_29_tfpostulacionesprecio) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesPrecio] >= @AV134Postulacioneswwds_29_tfpostulacionesprecio)");
         }
         else
         {
            GXv_int18[36] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV135Postulacioneswwds_30_tfpostulacionesprecio_to) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesPrecio] <= @AV135Postulacioneswwds_30_tfpostulacionesprecio_to)");
         }
         else
         {
            GXv_int18[37] = 1;
         }
         if ( ! (0==AV136Postulacioneswwds_31_tfpostulacionesmultimediaserial) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesMultimediaSerial] >= @AV136Postulacioneswwds_31_tfpostulacionesmultimediaserial)");
         }
         else
         {
            GXv_int18[38] = 1;
         }
         if ( ! (0==AV137Postulacioneswwds_32_tfpostulacionesmultimediaserial_to) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesMultimediaSerial] <= @AV137Postulacioneswwds_32_tfpostulacionesmultimediaserial_to)");
         }
         else
         {
            GXv_int18[39] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV141Postulacioneswwds_36_tfpostulacionesdescripcion_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV140Postulacioneswwds_35_tfpostulacionesdescripcion)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[PostulacionesDescripcion]) like UPPER(@lV140Postulacioneswwds_35_tfpostulacionesdescripcion))");
         }
         else
         {
            GXv_int18[40] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV141Postulacioneswwds_36_tfpostulacionesdescripcion_sel)) && ! ( StringUtil.StrCmp(AV141Postulacioneswwds_36_tfpostulacionesdescripcion_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesDescripcion] = @AV141Postulacioneswwds_36_tfpostulacionesdescripcion_sel)");
         }
         else
         {
            GXv_int18[41] = 1;
         }
         if ( StringUtil.StrCmp(AV141Postulacioneswwds_36_tfpostulacionesdescripcion_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[PostulacionesDescripcion] = ''))");
         }
         if ( AV142Postulacioneswwds_37_tfpostulacionesreqsuministros_sel == 1 )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesReqSuministros] = 1)");
         }
         if ( AV142Postulacioneswwds_37_tfpostulacionesreqsuministros_sel == 2 )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesReqSuministros] = 0)");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV144Postulacioneswwds_39_tfpostulacionessuministrosdescripcion_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV143Postulacioneswwds_38_tfpostulacionessuministrosdescripcion)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[PostulacionesSuministrosDescri]) like UPPER(@lV143Postulacioneswwds_38_tfpostulacionessuministrosdescripcion))");
         }
         else
         {
            GXv_int18[42] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV144Postulacioneswwds_39_tfpostulacionessuministrosdescripcion_sel)) && ! ( StringUtil.StrCmp(AV144Postulacioneswwds_39_tfpostulacionessuministrosdescripcion_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesSuministrosDescri] = @AV144Postulacioneswwds_39_tfpostulacionessuministrosdescripcion_sel)");
         }
         else
         {
            GXv_int18[43] = 1;
         }
         if ( StringUtil.StrCmp(AV144Postulacioneswwds_39_tfpostulacionessuministrosdescripcion_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[PostulacionesSuministrosDescri] = ''))");
         }
         if ( ! (DateTime.MinValue==AV145Postulacioneswwds_40_tfpostulacionesfechatrabajo) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesFechaTrabajo] >= @AV145Postulacioneswwds_40_tfpostulacionesfechatrabajo)");
         }
         else
         {
            GXv_int18[44] = 1;
         }
         if ( ! (DateTime.MinValue==AV146Postulacioneswwds_41_tfpostulacionesfechatrabajo_to) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesFechaTrabajo] <= @AV146Postulacioneswwds_41_tfpostulacionesfechatrabajo_to)");
         }
         else
         {
            GXv_int18[45] = 1;
         }
         if ( ! (DateTime.MinValue==AV147Postulacioneswwds_42_tfpostulacionesfechacierre) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesFechaCierre] >= @AV147Postulacioneswwds_42_tfpostulacionesfechacierre)");
         }
         else
         {
            GXv_int18[46] = 1;
         }
         if ( ! (DateTime.MinValue==AV148Postulacioneswwds_43_tfpostulacionesfechacierre_to) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesFechaCierre] <= @AV148Postulacioneswwds_43_tfpostulacionesfechacierre_to)");
         }
         else
         {
            GXv_int18[47] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV150Postulacioneswwds_45_tfpostulacioneshoracierre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV149Postulacioneswwds_44_tfpostulacioneshoracierre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[PostulacionesHoraCierre]) like UPPER(@lV149Postulacioneswwds_44_tfpostulacioneshoracierre))");
         }
         else
         {
            GXv_int18[48] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV150Postulacioneswwds_45_tfpostulacioneshoracierre_sel)) && ! ( StringUtil.StrCmp(AV150Postulacioneswwds_45_tfpostulacioneshoracierre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesHoraCierre] = @AV150Postulacioneswwds_45_tfpostulacioneshoracierre_sel)");
         }
         else
         {
            GXv_int18[49] = 1;
         }
         if ( StringUtil.StrCmp(AV150Postulacioneswwds_45_tfpostulacioneshoracierre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[PostulacionesHoraCierre] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV152Postulacioneswwds_47_tfpostulacionestipofecha_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV151Postulacioneswwds_46_tfpostulacionestipofecha)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[PostulacionesTipoFecha]) like UPPER(@lV151Postulacioneswwds_46_tfpostulacionestipofecha))");
         }
         else
         {
            GXv_int18[50] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV152Postulacioneswwds_47_tfpostulacionestipofecha_sel)) && ! ( StringUtil.StrCmp(AV152Postulacioneswwds_47_tfpostulacionestipofecha_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesTipoFecha] = @AV152Postulacioneswwds_47_tfpostulacionestipofecha_sel)");
         }
         else
         {
            GXv_int18[51] = 1;
         }
         if ( StringUtil.StrCmp(AV152Postulacioneswwds_47_tfpostulacionestipofecha_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[PostulacionesTipoFecha] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV154Postulacioneswwds_49_tfpostulacionesrgohoraservicio_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV153Postulacioneswwds_48_tfpostulacionesrgohoraservicio)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[PostulacionesRgoHoraservicio]) like UPPER(@lV153Postulacioneswwds_48_tfpostulacionesrgohoraservicio))");
         }
         else
         {
            GXv_int18[52] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV154Postulacioneswwds_49_tfpostulacionesrgohoraservicio_sel)) && ! ( StringUtil.StrCmp(AV154Postulacioneswwds_49_tfpostulacionesrgohoraservicio_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesRgoHoraservicio] = @AV154Postulacioneswwds_49_tfpostulacionesrgohoraservicio_sel)");
         }
         else
         {
            GXv_int18[53] = 1;
         }
         if ( StringUtil.StrCmp(AV154Postulacioneswwds_49_tfpostulacionesrgohoraservicio_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[PostulacionesRgoHoraservicio] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV156Postulacioneswwds_51_tfpostulacionesapellidonombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV155Postulacioneswwds_50_tfpostulacionesapellidonombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[PostulacionesApellidoNombre]) like UPPER(@lV155Postulacioneswwds_50_tfpostulacionesapellidonombre))");
         }
         else
         {
            GXv_int18[54] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV156Postulacioneswwds_51_tfpostulacionesapellidonombre_sel)) && ! ( StringUtil.StrCmp(AV156Postulacioneswwds_51_tfpostulacionesapellidonombre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesApellidoNombre] = @AV156Postulacioneswwds_51_tfpostulacionesapellidonombre_sel)");
         }
         else
         {
            GXv_int18[55] = 1;
         }
         if ( StringUtil.StrCmp(AV156Postulacioneswwds_51_tfpostulacionesapellidonombre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[PostulacionesApellidoNombre] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV158Postulacioneswwds_53_tfpostulacionesmail_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV157Postulacioneswwds_52_tfpostulacionesmail)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[PostulacionesMail]) like UPPER(@lV157Postulacioneswwds_52_tfpostulacionesmail))");
         }
         else
         {
            GXv_int18[56] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV158Postulacioneswwds_53_tfpostulacionesmail_sel)) && ! ( StringUtil.StrCmp(AV158Postulacioneswwds_53_tfpostulacionesmail_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesMail] = @AV158Postulacioneswwds_53_tfpostulacionesmail_sel)");
         }
         else
         {
            GXv_int18[57] = 1;
         }
         if ( StringUtil.StrCmp(AV158Postulacioneswwds_53_tfpostulacionesmail_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[PostulacionesMail] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV160Postulacioneswwds_55_tfpostulacionestelefono_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV159Postulacioneswwds_54_tfpostulacionestelefono)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[PostulacionesTelefono]) like UPPER(@lV159Postulacioneswwds_54_tfpostulacionestelefono))");
         }
         else
         {
            GXv_int18[58] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV160Postulacioneswwds_55_tfpostulacionestelefono_sel)) && ! ( StringUtil.StrCmp(AV160Postulacioneswwds_55_tfpostulacionestelefono_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesTelefono] = @AV160Postulacioneswwds_55_tfpostulacionestelefono_sel)");
         }
         else
         {
            GXv_int18[59] = 1;
         }
         if ( StringUtil.StrCmp(AV160Postulacioneswwds_55_tfpostulacionestelefono_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[PostulacionesTelefono] = ''))");
         }
         if ( ! (DateTime.MinValue==AV161Postulacioneswwds_56_tfpostulacionesfechaalta) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesFechaAlta] >= @AV161Postulacioneswwds_56_tfpostulacionesfechaalta)");
         }
         else
         {
            GXv_int18[60] = 1;
         }
         if ( ! (DateTime.MinValue==AV162Postulacioneswwds_57_tfpostulacionesfechaalta_to) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesFechaAlta] <= @AV162Postulacioneswwds_57_tfpostulacionesfechaalta_to)");
         }
         else
         {
            GXv_int18[61] = 1;
         }
         if ( AV163Postulacioneswwds_58_tfpostulacionesestado_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV163Postulacioneswwds_58_tfpostulacionesestado_sels, "T1.[PostulacionesEstado] IN (", ")")+")");
         }
         if ( ! (0==AV164Postulacioneswwds_59_tfpostulacionessecuserid) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesSecUserId] >= @AV164Postulacioneswwds_59_tfpostulacionessecuserid)");
         }
         else
         {
            GXv_int18[62] = 1;
         }
         if ( ! (0==AV165Postulacioneswwds_60_tfpostulacionessecuserid_to) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesSecUserId] <= @AV165Postulacioneswwds_60_tfpostulacionessecuserid_to)");
         }
         else
         {
            GXv_int18[63] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[PostulacionesMail]";
         GXv_Object19[0] = scmdbuf;
         GXv_Object19[1] = GXv_int18;
         return GXv_Object19 ;
      }

      protected Object[] conditional_P00LA21( IGxContext context ,
                                              string A424PostulacionesEstado ,
                                              GxSimpleCollection<string> AV163Postulacioneswwds_58_tfpostulacionesestado_sels ,
                                              string AV107Postulacioneswwds_2_dynamicfiltersselector1 ,
                                              short AV108Postulacioneswwds_3_dynamicfiltersoperator1 ,
                                              string AV109Postulacioneswwds_4_postulacionesproveedornombre1 ,
                                              long AV110Postulacioneswwds_5_postulacionesproveedorid1 ,
                                              string AV111Postulacioneswwds_6_serviciosnombre1 ,
                                              bool AV112Postulacioneswwds_7_dynamicfiltersenabled2 ,
                                              string AV113Postulacioneswwds_8_dynamicfiltersselector2 ,
                                              short AV114Postulacioneswwds_9_dynamicfiltersoperator2 ,
                                              string AV115Postulacioneswwds_10_postulacionesproveedornombre2 ,
                                              long AV116Postulacioneswwds_11_postulacionesproveedorid2 ,
                                              string AV117Postulacioneswwds_12_serviciosnombre2 ,
                                              bool AV118Postulacioneswwds_13_dynamicfiltersenabled3 ,
                                              string AV119Postulacioneswwds_14_dynamicfiltersselector3 ,
                                              short AV120Postulacioneswwds_15_dynamicfiltersoperator3 ,
                                              string AV121Postulacioneswwds_16_postulacionesproveedornombre3 ,
                                              long AV122Postulacioneswwds_17_postulacionesproveedorid3 ,
                                              string AV123Postulacioneswwds_18_serviciosnombre3 ,
                                              long AV124Postulacioneswwds_19_tfpostulacionesid ,
                                              long AV125Postulacioneswwds_20_tfpostulacionesid_to ,
                                              long AV126Postulacioneswwds_21_tfserviciosid ,
                                              long AV127Postulacioneswwds_22_tfserviciosid_to ,
                                              string AV129Postulacioneswwds_24_tfserviciosnombre_sel ,
                                              string AV128Postulacioneswwds_23_tfserviciosnombre ,
                                              long AV130Postulacioneswwds_25_tfpostulacionesproveedorid ,
                                              long AV131Postulacioneswwds_26_tfpostulacionesproveedorid_to ,
                                              string AV133Postulacioneswwds_28_tfpostulacionesproveedornombre_sel ,
                                              string AV132Postulacioneswwds_27_tfpostulacionesproveedornombre ,
                                              decimal AV134Postulacioneswwds_29_tfpostulacionesprecio ,
                                              decimal AV135Postulacioneswwds_30_tfpostulacionesprecio_to ,
                                              short AV136Postulacioneswwds_31_tfpostulacionesmultimediaserial ,
                                              short AV137Postulacioneswwds_32_tfpostulacionesmultimediaserial_to ,
                                              string AV141Postulacioneswwds_36_tfpostulacionesdescripcion_sel ,
                                              string AV140Postulacioneswwds_35_tfpostulacionesdescripcion ,
                                              short AV142Postulacioneswwds_37_tfpostulacionesreqsuministros_sel ,
                                              string AV144Postulacioneswwds_39_tfpostulacionessuministrosdescripcion_sel ,
                                              string AV143Postulacioneswwds_38_tfpostulacionessuministrosdescripcion ,
                                              DateTime AV145Postulacioneswwds_40_tfpostulacionesfechatrabajo ,
                                              DateTime AV146Postulacioneswwds_41_tfpostulacionesfechatrabajo_to ,
                                              DateTime AV147Postulacioneswwds_42_tfpostulacionesfechacierre ,
                                              DateTime AV148Postulacioneswwds_43_tfpostulacionesfechacierre_to ,
                                              string AV150Postulacioneswwds_45_tfpostulacioneshoracierre_sel ,
                                              string AV149Postulacioneswwds_44_tfpostulacioneshoracierre ,
                                              string AV152Postulacioneswwds_47_tfpostulacionestipofecha_sel ,
                                              string AV151Postulacioneswwds_46_tfpostulacionestipofecha ,
                                              string AV154Postulacioneswwds_49_tfpostulacionesrgohoraservicio_sel ,
                                              string AV153Postulacioneswwds_48_tfpostulacionesrgohoraservicio ,
                                              string AV156Postulacioneswwds_51_tfpostulacionesapellidonombre_sel ,
                                              string AV155Postulacioneswwds_50_tfpostulacionesapellidonombre ,
                                              string AV158Postulacioneswwds_53_tfpostulacionesmail_sel ,
                                              string AV157Postulacioneswwds_52_tfpostulacionesmail ,
                                              string AV160Postulacioneswwds_55_tfpostulacionestelefono_sel ,
                                              string AV159Postulacioneswwds_54_tfpostulacionestelefono ,
                                              DateTime AV161Postulacioneswwds_56_tfpostulacionesfechaalta ,
                                              DateTime AV162Postulacioneswwds_57_tfpostulacionesfechaalta_to ,
                                              int AV163Postulacioneswwds_58_tfpostulacionesestado_sels_Count ,
                                              long AV164Postulacioneswwds_59_tfpostulacionessecuserid ,
                                              long AV165Postulacioneswwds_60_tfpostulacionessecuserid_to ,
                                              string A969PostulacionesProveedorNombre ,
                                              long A945PostulacionesProveedorId ,
                                              string A943ServiciosNombre ,
                                              long A422PostulacionesId ,
                                              long A942ServiciosId ,
                                              decimal A946PostulacionesPrecio ,
                                              short A961PostulacionesMultimediaSerial ,
                                              string A936PostulacionesDescripcion ,
                                              bool A937PostulacionesReqSuministros ,
                                              string A938PostulacionesSuministrosDescri ,
                                              DateTime A947PostulacionesFechaTrabajo ,
                                              DateTime A939PostulacionesFechaCierre ,
                                              string A940PostulacionesHoraCierre ,
                                              string A941PostulacionesTipoFecha ,
                                              string A949PostulacionesRgoHoraservicio ,
                                              string A950PostulacionesApellidoNombre ,
                                              string A951PostulacionesMail ,
                                              string A952PostulacionesTelefono ,
                                              DateTime A425PostulacionesFechaAlta ,
                                              long A948PostulacionesSecUserId ,
                                              string AV106Postulacioneswwds_1_filterfulltext ,
                                              long A970PostulacionesSolicitudesId ,
                                              long AV138Postulacioneswwds_33_tfpostulacionessolicitudesid ,
                                              long AV139Postulacioneswwds_34_tfpostulacionessolicitudesid_to )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int20 = new short[64];
         Object[] GXv_Object21 = new Object[2];
         scmdbuf = "SELECT T1.[PostulacionesTelefono], T1.[PostulacionesSecUserId], T1.[PostulacionesFechaAlta], T1.[PostulacionesMail], T1.[PostulacionesApellidoNombre], T1.[PostulacionesRgoHoraservicio], T1.[PostulacionesTipoFecha], T1.[PostulacionesHoraCierre], T1.[PostulacionesFechaCierre], T1.[PostulacionesFechaTrabajo], T1.[PostulacionesSuministrosDescri], T1.[PostulacionesReqSuministros], T1.[PostulacionesDescripcion], T1.[PostulacionesMultimediaSerial], T1.[PostulacionesPrecio], T3.[ProveedorNombre] AS PostulacionesProveedorNombre, T2.[ServiciosNombre], T1.[ServiciosId], T1.[PostulacionesId], T1.[PostulacionesProveedorId] AS PostulacionesProveedorId, T1.[PostulacionesEstado], COALESCE( T4.[PostulacionesSolicitudesId], 0) AS PostulacionesSolicitudesId FROM (([Postulaciones] T1 LEFT JOIN [Servicios] T2 ON T2.[ServiciosId] = T1.[ServiciosId]) INNER JOIN [Proveedor] T3 ON T3.[ProveedorID] = T1.[PostulacionesProveedorId]),  (SELECT MIN([SolicitudesID]) AS PostulacionesSolicitudesId FROM [Solicitudes] WHERE [PostulacionesId] = @PostulacionesId ) T4";
         AddWhere(sWhereString, "((@AV138Postulacioneswwds_33_tfpostulacionessolicitudesid = convert(int, 0)) or ( COALESCE( T4.[PostulacionesSolicitudesId], 0) >= @AV138Postulacioneswwds_33_tfpostulacionessolicitudesid))");
         AddWhere(sWhereString, "((@AV139Postulacioneswwds_34_tfpostulacionessolicitudesid_to = convert(int, 0)) or ( COALESCE( T4.[PostulacionesSolicitudesId], 0) <= @AV139Postulacioneswwds_34_tfpostulacionessolicitudesid_to))");
         if ( ( StringUtil.StrCmp(AV107Postulacioneswwds_2_dynamicfiltersselector1, "POSTULACIONESPROVEEDORNOMBRE") == 0 ) && ( AV108Postulacioneswwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV109Postulacioneswwds_4_postulacionesproveedornombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T3.[ProveedorNombre]) like UPPER(@lV109Postulacioneswwds_4_postulacionesproveedornombre1))");
         }
         else
         {
            GXv_int20[5] = 1;
         }
         if ( ( StringUtil.StrCmp(AV107Postulacioneswwds_2_dynamicfiltersselector1, "POSTULACIONESPROVEEDORNOMBRE") == 0 ) && ( AV108Postulacioneswwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV109Postulacioneswwds_4_postulacionesproveedornombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T3.[ProveedorNombre]) like '%' + UPPER(@lV109Postulacioneswwds_4_postulacionesproveedornombre1))");
         }
         else
         {
            GXv_int20[6] = 1;
         }
         if ( ( StringUtil.StrCmp(AV107Postulacioneswwds_2_dynamicfiltersselector1, "POSTULACIONESPROVEEDORID") == 0 ) && ( AV108Postulacioneswwds_3_dynamicfiltersoperator1 == 0 ) && ( ! (0==AV110Postulacioneswwds_5_postulacionesproveedorid1) ) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesProveedorId] < @AV110Postulacioneswwds_5_postulacionesproveedorid1)");
         }
         else
         {
            GXv_int20[7] = 1;
         }
         if ( ( StringUtil.StrCmp(AV107Postulacioneswwds_2_dynamicfiltersselector1, "POSTULACIONESPROVEEDORID") == 0 ) && ( AV108Postulacioneswwds_3_dynamicfiltersoperator1 == 1 ) && ( ! (0==AV110Postulacioneswwds_5_postulacionesproveedorid1) ) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesProveedorId] = @AV110Postulacioneswwds_5_postulacionesproveedorid1)");
         }
         else
         {
            GXv_int20[8] = 1;
         }
         if ( ( StringUtil.StrCmp(AV107Postulacioneswwds_2_dynamicfiltersselector1, "POSTULACIONESPROVEEDORID") == 0 ) && ( AV108Postulacioneswwds_3_dynamicfiltersoperator1 == 2 ) && ( ! (0==AV110Postulacioneswwds_5_postulacionesproveedorid1) ) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesProveedorId] > @AV110Postulacioneswwds_5_postulacionesproveedorid1)");
         }
         else
         {
            GXv_int20[9] = 1;
         }
         if ( ( StringUtil.StrCmp(AV107Postulacioneswwds_2_dynamicfiltersselector1, "SERVICIOSNOMBRE") == 0 ) && ( AV108Postulacioneswwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV111Postulacioneswwds_6_serviciosnombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ServiciosNombre]) like UPPER(@lV111Postulacioneswwds_6_serviciosnombre1))");
         }
         else
         {
            GXv_int20[10] = 1;
         }
         if ( ( StringUtil.StrCmp(AV107Postulacioneswwds_2_dynamicfiltersselector1, "SERVICIOSNOMBRE") == 0 ) && ( AV108Postulacioneswwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV111Postulacioneswwds_6_serviciosnombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ServiciosNombre]) like '%' + UPPER(@lV111Postulacioneswwds_6_serviciosnombre1))");
         }
         else
         {
            GXv_int20[11] = 1;
         }
         if ( AV112Postulacioneswwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV113Postulacioneswwds_8_dynamicfiltersselector2, "POSTULACIONESPROVEEDORNOMBRE") == 0 ) && ( AV114Postulacioneswwds_9_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV115Postulacioneswwds_10_postulacionesproveedornombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T3.[ProveedorNombre]) like UPPER(@lV115Postulacioneswwds_10_postulacionesproveedornombre2))");
         }
         else
         {
            GXv_int20[12] = 1;
         }
         if ( AV112Postulacioneswwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV113Postulacioneswwds_8_dynamicfiltersselector2, "POSTULACIONESPROVEEDORNOMBRE") == 0 ) && ( AV114Postulacioneswwds_9_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV115Postulacioneswwds_10_postulacionesproveedornombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T3.[ProveedorNombre]) like '%' + UPPER(@lV115Postulacioneswwds_10_postulacionesproveedornombre2))");
         }
         else
         {
            GXv_int20[13] = 1;
         }
         if ( AV112Postulacioneswwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV113Postulacioneswwds_8_dynamicfiltersselector2, "POSTULACIONESPROVEEDORID") == 0 ) && ( AV114Postulacioneswwds_9_dynamicfiltersoperator2 == 0 ) && ( ! (0==AV116Postulacioneswwds_11_postulacionesproveedorid2) ) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesProveedorId] < @AV116Postulacioneswwds_11_postulacionesproveedorid2)");
         }
         else
         {
            GXv_int20[14] = 1;
         }
         if ( AV112Postulacioneswwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV113Postulacioneswwds_8_dynamicfiltersselector2, "POSTULACIONESPROVEEDORID") == 0 ) && ( AV114Postulacioneswwds_9_dynamicfiltersoperator2 == 1 ) && ( ! (0==AV116Postulacioneswwds_11_postulacionesproveedorid2) ) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesProveedorId] = @AV116Postulacioneswwds_11_postulacionesproveedorid2)");
         }
         else
         {
            GXv_int20[15] = 1;
         }
         if ( AV112Postulacioneswwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV113Postulacioneswwds_8_dynamicfiltersselector2, "POSTULACIONESPROVEEDORID") == 0 ) && ( AV114Postulacioneswwds_9_dynamicfiltersoperator2 == 2 ) && ( ! (0==AV116Postulacioneswwds_11_postulacionesproveedorid2) ) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesProveedorId] > @AV116Postulacioneswwds_11_postulacionesproveedorid2)");
         }
         else
         {
            GXv_int20[16] = 1;
         }
         if ( AV112Postulacioneswwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV113Postulacioneswwds_8_dynamicfiltersselector2, "SERVICIOSNOMBRE") == 0 ) && ( AV114Postulacioneswwds_9_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV117Postulacioneswwds_12_serviciosnombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ServiciosNombre]) like UPPER(@lV117Postulacioneswwds_12_serviciosnombre2))");
         }
         else
         {
            GXv_int20[17] = 1;
         }
         if ( AV112Postulacioneswwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV113Postulacioneswwds_8_dynamicfiltersselector2, "SERVICIOSNOMBRE") == 0 ) && ( AV114Postulacioneswwds_9_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV117Postulacioneswwds_12_serviciosnombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ServiciosNombre]) like '%' + UPPER(@lV117Postulacioneswwds_12_serviciosnombre2))");
         }
         else
         {
            GXv_int20[18] = 1;
         }
         if ( AV118Postulacioneswwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV119Postulacioneswwds_14_dynamicfiltersselector3, "POSTULACIONESPROVEEDORNOMBRE") == 0 ) && ( AV120Postulacioneswwds_15_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV121Postulacioneswwds_16_postulacionesproveedornombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T3.[ProveedorNombre]) like UPPER(@lV121Postulacioneswwds_16_postulacionesproveedornombre3))");
         }
         else
         {
            GXv_int20[19] = 1;
         }
         if ( AV118Postulacioneswwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV119Postulacioneswwds_14_dynamicfiltersselector3, "POSTULACIONESPROVEEDORNOMBRE") == 0 ) && ( AV120Postulacioneswwds_15_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV121Postulacioneswwds_16_postulacionesproveedornombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T3.[ProveedorNombre]) like '%' + UPPER(@lV121Postulacioneswwds_16_postulacionesproveedornombre3))");
         }
         else
         {
            GXv_int20[20] = 1;
         }
         if ( AV118Postulacioneswwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV119Postulacioneswwds_14_dynamicfiltersselector3, "POSTULACIONESPROVEEDORID") == 0 ) && ( AV120Postulacioneswwds_15_dynamicfiltersoperator3 == 0 ) && ( ! (0==AV122Postulacioneswwds_17_postulacionesproveedorid3) ) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesProveedorId] < @AV122Postulacioneswwds_17_postulacionesproveedorid3)");
         }
         else
         {
            GXv_int20[21] = 1;
         }
         if ( AV118Postulacioneswwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV119Postulacioneswwds_14_dynamicfiltersselector3, "POSTULACIONESPROVEEDORID") == 0 ) && ( AV120Postulacioneswwds_15_dynamicfiltersoperator3 == 1 ) && ( ! (0==AV122Postulacioneswwds_17_postulacionesproveedorid3) ) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesProveedorId] = @AV122Postulacioneswwds_17_postulacionesproveedorid3)");
         }
         else
         {
            GXv_int20[22] = 1;
         }
         if ( AV118Postulacioneswwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV119Postulacioneswwds_14_dynamicfiltersselector3, "POSTULACIONESPROVEEDORID") == 0 ) && ( AV120Postulacioneswwds_15_dynamicfiltersoperator3 == 2 ) && ( ! (0==AV122Postulacioneswwds_17_postulacionesproveedorid3) ) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesProveedorId] > @AV122Postulacioneswwds_17_postulacionesproveedorid3)");
         }
         else
         {
            GXv_int20[23] = 1;
         }
         if ( AV118Postulacioneswwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV119Postulacioneswwds_14_dynamicfiltersselector3, "SERVICIOSNOMBRE") == 0 ) && ( AV120Postulacioneswwds_15_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV123Postulacioneswwds_18_serviciosnombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ServiciosNombre]) like UPPER(@lV123Postulacioneswwds_18_serviciosnombre3))");
         }
         else
         {
            GXv_int20[24] = 1;
         }
         if ( AV118Postulacioneswwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV119Postulacioneswwds_14_dynamicfiltersselector3, "SERVICIOSNOMBRE") == 0 ) && ( AV120Postulacioneswwds_15_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV123Postulacioneswwds_18_serviciosnombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ServiciosNombre]) like '%' + UPPER(@lV123Postulacioneswwds_18_serviciosnombre3))");
         }
         else
         {
            GXv_int20[25] = 1;
         }
         if ( ! (0==AV124Postulacioneswwds_19_tfpostulacionesid) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesId] >= @AV124Postulacioneswwds_19_tfpostulacionesid)");
         }
         else
         {
            GXv_int20[26] = 1;
         }
         if ( ! (0==AV125Postulacioneswwds_20_tfpostulacionesid_to) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesId] <= @AV125Postulacioneswwds_20_tfpostulacionesid_to)");
         }
         else
         {
            GXv_int20[27] = 1;
         }
         if ( ! (0==AV126Postulacioneswwds_21_tfserviciosid) )
         {
            AddWhere(sWhereString, "(T1.[ServiciosId] >= @AV126Postulacioneswwds_21_tfserviciosid)");
         }
         else
         {
            GXv_int20[28] = 1;
         }
         if ( ! (0==AV127Postulacioneswwds_22_tfserviciosid_to) )
         {
            AddWhere(sWhereString, "(T1.[ServiciosId] <= @AV127Postulacioneswwds_22_tfserviciosid_to)");
         }
         else
         {
            GXv_int20[29] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV129Postulacioneswwds_24_tfserviciosnombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV128Postulacioneswwds_23_tfserviciosnombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ServiciosNombre]) like UPPER(@lV128Postulacioneswwds_23_tfserviciosnombre))");
         }
         else
         {
            GXv_int20[30] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV129Postulacioneswwds_24_tfserviciosnombre_sel)) && ! ( StringUtil.StrCmp(AV129Postulacioneswwds_24_tfserviciosnombre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.[ServiciosNombre] = @AV129Postulacioneswwds_24_tfserviciosnombre_sel)");
         }
         else
         {
            GXv_int20[31] = 1;
         }
         if ( StringUtil.StrCmp(AV129Postulacioneswwds_24_tfserviciosnombre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T2.[ServiciosNombre] IS NULL or (T2.[ServiciosNombre] = ''))");
         }
         if ( ! (0==AV130Postulacioneswwds_25_tfpostulacionesproveedorid) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesProveedorId] >= @AV130Postulacioneswwds_25_tfpostulacionesproveedorid)");
         }
         else
         {
            GXv_int20[32] = 1;
         }
         if ( ! (0==AV131Postulacioneswwds_26_tfpostulacionesproveedorid_to) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesProveedorId] <= @AV131Postulacioneswwds_26_tfpostulacionesproveedorid_to)");
         }
         else
         {
            GXv_int20[33] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV133Postulacioneswwds_28_tfpostulacionesproveedornombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV132Postulacioneswwds_27_tfpostulacionesproveedornombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T3.[ProveedorNombre]) like UPPER(@lV132Postulacioneswwds_27_tfpostulacionesproveedornombre))");
         }
         else
         {
            GXv_int20[34] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV133Postulacioneswwds_28_tfpostulacionesproveedornombre_sel)) && ! ( StringUtil.StrCmp(AV133Postulacioneswwds_28_tfpostulacionesproveedornombre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T3.[ProveedorNombre] = @AV133Postulacioneswwds_28_tfpostulacionesproveedornombre_sel)");
         }
         else
         {
            GXv_int20[35] = 1;
         }
         if ( StringUtil.StrCmp(AV133Postulacioneswwds_28_tfpostulacionesproveedornombre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T3.[ProveedorNombre] = ''))");
         }
         if ( ! (Convert.ToDecimal(0)==AV134Postulacioneswwds_29_tfpostulacionesprecio) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesPrecio] >= @AV134Postulacioneswwds_29_tfpostulacionesprecio)");
         }
         else
         {
            GXv_int20[36] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV135Postulacioneswwds_30_tfpostulacionesprecio_to) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesPrecio] <= @AV135Postulacioneswwds_30_tfpostulacionesprecio_to)");
         }
         else
         {
            GXv_int20[37] = 1;
         }
         if ( ! (0==AV136Postulacioneswwds_31_tfpostulacionesmultimediaserial) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesMultimediaSerial] >= @AV136Postulacioneswwds_31_tfpostulacionesmultimediaserial)");
         }
         else
         {
            GXv_int20[38] = 1;
         }
         if ( ! (0==AV137Postulacioneswwds_32_tfpostulacionesmultimediaserial_to) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesMultimediaSerial] <= @AV137Postulacioneswwds_32_tfpostulacionesmultimediaserial_to)");
         }
         else
         {
            GXv_int20[39] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV141Postulacioneswwds_36_tfpostulacionesdescripcion_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV140Postulacioneswwds_35_tfpostulacionesdescripcion)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[PostulacionesDescripcion]) like UPPER(@lV140Postulacioneswwds_35_tfpostulacionesdescripcion))");
         }
         else
         {
            GXv_int20[40] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV141Postulacioneswwds_36_tfpostulacionesdescripcion_sel)) && ! ( StringUtil.StrCmp(AV141Postulacioneswwds_36_tfpostulacionesdescripcion_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesDescripcion] = @AV141Postulacioneswwds_36_tfpostulacionesdescripcion_sel)");
         }
         else
         {
            GXv_int20[41] = 1;
         }
         if ( StringUtil.StrCmp(AV141Postulacioneswwds_36_tfpostulacionesdescripcion_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[PostulacionesDescripcion] = ''))");
         }
         if ( AV142Postulacioneswwds_37_tfpostulacionesreqsuministros_sel == 1 )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesReqSuministros] = 1)");
         }
         if ( AV142Postulacioneswwds_37_tfpostulacionesreqsuministros_sel == 2 )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesReqSuministros] = 0)");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV144Postulacioneswwds_39_tfpostulacionessuministrosdescripcion_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV143Postulacioneswwds_38_tfpostulacionessuministrosdescripcion)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[PostulacionesSuministrosDescri]) like UPPER(@lV143Postulacioneswwds_38_tfpostulacionessuministrosdescripcion))");
         }
         else
         {
            GXv_int20[42] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV144Postulacioneswwds_39_tfpostulacionessuministrosdescripcion_sel)) && ! ( StringUtil.StrCmp(AV144Postulacioneswwds_39_tfpostulacionessuministrosdescripcion_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesSuministrosDescri] = @AV144Postulacioneswwds_39_tfpostulacionessuministrosdescripcion_sel)");
         }
         else
         {
            GXv_int20[43] = 1;
         }
         if ( StringUtil.StrCmp(AV144Postulacioneswwds_39_tfpostulacionessuministrosdescripcion_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[PostulacionesSuministrosDescri] = ''))");
         }
         if ( ! (DateTime.MinValue==AV145Postulacioneswwds_40_tfpostulacionesfechatrabajo) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesFechaTrabajo] >= @AV145Postulacioneswwds_40_tfpostulacionesfechatrabajo)");
         }
         else
         {
            GXv_int20[44] = 1;
         }
         if ( ! (DateTime.MinValue==AV146Postulacioneswwds_41_tfpostulacionesfechatrabajo_to) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesFechaTrabajo] <= @AV146Postulacioneswwds_41_tfpostulacionesfechatrabajo_to)");
         }
         else
         {
            GXv_int20[45] = 1;
         }
         if ( ! (DateTime.MinValue==AV147Postulacioneswwds_42_tfpostulacionesfechacierre) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesFechaCierre] >= @AV147Postulacioneswwds_42_tfpostulacionesfechacierre)");
         }
         else
         {
            GXv_int20[46] = 1;
         }
         if ( ! (DateTime.MinValue==AV148Postulacioneswwds_43_tfpostulacionesfechacierre_to) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesFechaCierre] <= @AV148Postulacioneswwds_43_tfpostulacionesfechacierre_to)");
         }
         else
         {
            GXv_int20[47] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV150Postulacioneswwds_45_tfpostulacioneshoracierre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV149Postulacioneswwds_44_tfpostulacioneshoracierre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[PostulacionesHoraCierre]) like UPPER(@lV149Postulacioneswwds_44_tfpostulacioneshoracierre))");
         }
         else
         {
            GXv_int20[48] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV150Postulacioneswwds_45_tfpostulacioneshoracierre_sel)) && ! ( StringUtil.StrCmp(AV150Postulacioneswwds_45_tfpostulacioneshoracierre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesHoraCierre] = @AV150Postulacioneswwds_45_tfpostulacioneshoracierre_sel)");
         }
         else
         {
            GXv_int20[49] = 1;
         }
         if ( StringUtil.StrCmp(AV150Postulacioneswwds_45_tfpostulacioneshoracierre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[PostulacionesHoraCierre] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV152Postulacioneswwds_47_tfpostulacionestipofecha_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV151Postulacioneswwds_46_tfpostulacionestipofecha)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[PostulacionesTipoFecha]) like UPPER(@lV151Postulacioneswwds_46_tfpostulacionestipofecha))");
         }
         else
         {
            GXv_int20[50] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV152Postulacioneswwds_47_tfpostulacionestipofecha_sel)) && ! ( StringUtil.StrCmp(AV152Postulacioneswwds_47_tfpostulacionestipofecha_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesTipoFecha] = @AV152Postulacioneswwds_47_tfpostulacionestipofecha_sel)");
         }
         else
         {
            GXv_int20[51] = 1;
         }
         if ( StringUtil.StrCmp(AV152Postulacioneswwds_47_tfpostulacionestipofecha_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[PostulacionesTipoFecha] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV154Postulacioneswwds_49_tfpostulacionesrgohoraservicio_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV153Postulacioneswwds_48_tfpostulacionesrgohoraservicio)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[PostulacionesRgoHoraservicio]) like UPPER(@lV153Postulacioneswwds_48_tfpostulacionesrgohoraservicio))");
         }
         else
         {
            GXv_int20[52] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV154Postulacioneswwds_49_tfpostulacionesrgohoraservicio_sel)) && ! ( StringUtil.StrCmp(AV154Postulacioneswwds_49_tfpostulacionesrgohoraservicio_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesRgoHoraservicio] = @AV154Postulacioneswwds_49_tfpostulacionesrgohoraservicio_sel)");
         }
         else
         {
            GXv_int20[53] = 1;
         }
         if ( StringUtil.StrCmp(AV154Postulacioneswwds_49_tfpostulacionesrgohoraservicio_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[PostulacionesRgoHoraservicio] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV156Postulacioneswwds_51_tfpostulacionesapellidonombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV155Postulacioneswwds_50_tfpostulacionesapellidonombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[PostulacionesApellidoNombre]) like UPPER(@lV155Postulacioneswwds_50_tfpostulacionesapellidonombre))");
         }
         else
         {
            GXv_int20[54] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV156Postulacioneswwds_51_tfpostulacionesapellidonombre_sel)) && ! ( StringUtil.StrCmp(AV156Postulacioneswwds_51_tfpostulacionesapellidonombre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesApellidoNombre] = @AV156Postulacioneswwds_51_tfpostulacionesapellidonombre_sel)");
         }
         else
         {
            GXv_int20[55] = 1;
         }
         if ( StringUtil.StrCmp(AV156Postulacioneswwds_51_tfpostulacionesapellidonombre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[PostulacionesApellidoNombre] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV158Postulacioneswwds_53_tfpostulacionesmail_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV157Postulacioneswwds_52_tfpostulacionesmail)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[PostulacionesMail]) like UPPER(@lV157Postulacioneswwds_52_tfpostulacionesmail))");
         }
         else
         {
            GXv_int20[56] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV158Postulacioneswwds_53_tfpostulacionesmail_sel)) && ! ( StringUtil.StrCmp(AV158Postulacioneswwds_53_tfpostulacionesmail_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesMail] = @AV158Postulacioneswwds_53_tfpostulacionesmail_sel)");
         }
         else
         {
            GXv_int20[57] = 1;
         }
         if ( StringUtil.StrCmp(AV158Postulacioneswwds_53_tfpostulacionesmail_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[PostulacionesMail] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV160Postulacioneswwds_55_tfpostulacionestelefono_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV159Postulacioneswwds_54_tfpostulacionestelefono)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[PostulacionesTelefono]) like UPPER(@lV159Postulacioneswwds_54_tfpostulacionestelefono))");
         }
         else
         {
            GXv_int20[58] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV160Postulacioneswwds_55_tfpostulacionestelefono_sel)) && ! ( StringUtil.StrCmp(AV160Postulacioneswwds_55_tfpostulacionestelefono_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesTelefono] = @AV160Postulacioneswwds_55_tfpostulacionestelefono_sel)");
         }
         else
         {
            GXv_int20[59] = 1;
         }
         if ( StringUtil.StrCmp(AV160Postulacioneswwds_55_tfpostulacionestelefono_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[PostulacionesTelefono] = ''))");
         }
         if ( ! (DateTime.MinValue==AV161Postulacioneswwds_56_tfpostulacionesfechaalta) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesFechaAlta] >= @AV161Postulacioneswwds_56_tfpostulacionesfechaalta)");
         }
         else
         {
            GXv_int20[60] = 1;
         }
         if ( ! (DateTime.MinValue==AV162Postulacioneswwds_57_tfpostulacionesfechaalta_to) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesFechaAlta] <= @AV162Postulacioneswwds_57_tfpostulacionesfechaalta_to)");
         }
         else
         {
            GXv_int20[61] = 1;
         }
         if ( AV163Postulacioneswwds_58_tfpostulacionesestado_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV163Postulacioneswwds_58_tfpostulacionesestado_sels, "T1.[PostulacionesEstado] IN (", ")")+")");
         }
         if ( ! (0==AV164Postulacioneswwds_59_tfpostulacionessecuserid) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesSecUserId] >= @AV164Postulacioneswwds_59_tfpostulacionessecuserid)");
         }
         else
         {
            GXv_int20[62] = 1;
         }
         if ( ! (0==AV165Postulacioneswwds_60_tfpostulacionessecuserid_to) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesSecUserId] <= @AV165Postulacioneswwds_60_tfpostulacionessecuserid_to)");
         }
         else
         {
            GXv_int20[63] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[PostulacionesTelefono]";
         GXv_Object21[0] = scmdbuf;
         GXv_Object21[1] = GXv_int20;
         return GXv_Object21 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_P00LA3(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (long)dynConstraints[5] , (string)dynConstraints[6] , (bool)dynConstraints[7] , (string)dynConstraints[8] , (short)dynConstraints[9] , (string)dynConstraints[10] , (long)dynConstraints[11] , (string)dynConstraints[12] , (bool)dynConstraints[13] , (string)dynConstraints[14] , (short)dynConstraints[15] , (string)dynConstraints[16] , (long)dynConstraints[17] , (string)dynConstraints[18] , (long)dynConstraints[19] , (long)dynConstraints[20] , (long)dynConstraints[21] , (long)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (long)dynConstraints[25] , (long)dynConstraints[26] , (string)dynConstraints[27] , (string)dynConstraints[28] , (decimal)dynConstraints[29] , (decimal)dynConstraints[30] , (short)dynConstraints[31] , (short)dynConstraints[32] , (string)dynConstraints[33] , (string)dynConstraints[34] , (short)dynConstraints[35] , (string)dynConstraints[36] , (string)dynConstraints[37] , (DateTime)dynConstraints[38] , (DateTime)dynConstraints[39] , (DateTime)dynConstraints[40] , (DateTime)dynConstraints[41] , (string)dynConstraints[42] , (string)dynConstraints[43] , (string)dynConstraints[44] , (string)dynConstraints[45] , (string)dynConstraints[46] , (string)dynConstraints[47] , (string)dynConstraints[48] , (string)dynConstraints[49] , (string)dynConstraints[50] , (string)dynConstraints[51] , (string)dynConstraints[52] , (string)dynConstraints[53] , (DateTime)dynConstraints[54] , (DateTime)dynConstraints[55] , (int)dynConstraints[56] , (long)dynConstraints[57] , (long)dynConstraints[58] , (string)dynConstraints[59] , (long)dynConstraints[60] , (string)dynConstraints[61] , (long)dynConstraints[62] , (long)dynConstraints[63] , (decimal)dynConstraints[64] , (short)dynConstraints[65] , (string)dynConstraints[66] , (bool)dynConstraints[67] , (string)dynConstraints[68] , (DateTime)dynConstraints[69] , (DateTime)dynConstraints[70] , (string)dynConstraints[71] , (string)dynConstraints[72] , (string)dynConstraints[73] , (string)dynConstraints[74] , (string)dynConstraints[75] , (string)dynConstraints[76] , (DateTime)dynConstraints[77] , (long)dynConstraints[78] , (string)dynConstraints[79] , (long)dynConstraints[80] , (long)dynConstraints[81] , (long)dynConstraints[82] );
               case 1 :
                     return conditional_P00LA5(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (long)dynConstraints[5] , (string)dynConstraints[6] , (bool)dynConstraints[7] , (string)dynConstraints[8] , (short)dynConstraints[9] , (string)dynConstraints[10] , (long)dynConstraints[11] , (string)dynConstraints[12] , (bool)dynConstraints[13] , (string)dynConstraints[14] , (short)dynConstraints[15] , (string)dynConstraints[16] , (long)dynConstraints[17] , (string)dynConstraints[18] , (long)dynConstraints[19] , (long)dynConstraints[20] , (long)dynConstraints[21] , (long)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (long)dynConstraints[25] , (long)dynConstraints[26] , (string)dynConstraints[27] , (string)dynConstraints[28] , (decimal)dynConstraints[29] , (decimal)dynConstraints[30] , (short)dynConstraints[31] , (short)dynConstraints[32] , (string)dynConstraints[33] , (string)dynConstraints[34] , (short)dynConstraints[35] , (string)dynConstraints[36] , (string)dynConstraints[37] , (DateTime)dynConstraints[38] , (DateTime)dynConstraints[39] , (DateTime)dynConstraints[40] , (DateTime)dynConstraints[41] , (string)dynConstraints[42] , (string)dynConstraints[43] , (string)dynConstraints[44] , (string)dynConstraints[45] , (string)dynConstraints[46] , (string)dynConstraints[47] , (string)dynConstraints[48] , (string)dynConstraints[49] , (string)dynConstraints[50] , (string)dynConstraints[51] , (string)dynConstraints[52] , (string)dynConstraints[53] , (DateTime)dynConstraints[54] , (DateTime)dynConstraints[55] , (int)dynConstraints[56] , (long)dynConstraints[57] , (long)dynConstraints[58] , (string)dynConstraints[59] , (long)dynConstraints[60] , (string)dynConstraints[61] , (long)dynConstraints[62] , (long)dynConstraints[63] , (decimal)dynConstraints[64] , (short)dynConstraints[65] , (string)dynConstraints[66] , (bool)dynConstraints[67] , (string)dynConstraints[68] , (DateTime)dynConstraints[69] , (DateTime)dynConstraints[70] , (string)dynConstraints[71] , (string)dynConstraints[72] , (string)dynConstraints[73] , (string)dynConstraints[74] , (string)dynConstraints[75] , (string)dynConstraints[76] , (DateTime)dynConstraints[77] , (long)dynConstraints[78] , (string)dynConstraints[79] , (long)dynConstraints[80] , (long)dynConstraints[81] , (long)dynConstraints[82] );
               case 2 :
                     return conditional_P00LA7(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (long)dynConstraints[5] , (string)dynConstraints[6] , (bool)dynConstraints[7] , (string)dynConstraints[8] , (short)dynConstraints[9] , (string)dynConstraints[10] , (long)dynConstraints[11] , (string)dynConstraints[12] , (bool)dynConstraints[13] , (string)dynConstraints[14] , (short)dynConstraints[15] , (string)dynConstraints[16] , (long)dynConstraints[17] , (string)dynConstraints[18] , (long)dynConstraints[19] , (long)dynConstraints[20] , (long)dynConstraints[21] , (long)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (long)dynConstraints[25] , (long)dynConstraints[26] , (string)dynConstraints[27] , (string)dynConstraints[28] , (decimal)dynConstraints[29] , (decimal)dynConstraints[30] , (short)dynConstraints[31] , (short)dynConstraints[32] , (string)dynConstraints[33] , (string)dynConstraints[34] , (short)dynConstraints[35] , (string)dynConstraints[36] , (string)dynConstraints[37] , (DateTime)dynConstraints[38] , (DateTime)dynConstraints[39] , (DateTime)dynConstraints[40] , (DateTime)dynConstraints[41] , (string)dynConstraints[42] , (string)dynConstraints[43] , (string)dynConstraints[44] , (string)dynConstraints[45] , (string)dynConstraints[46] , (string)dynConstraints[47] , (string)dynConstraints[48] , (string)dynConstraints[49] , (string)dynConstraints[50] , (string)dynConstraints[51] , (string)dynConstraints[52] , (string)dynConstraints[53] , (DateTime)dynConstraints[54] , (DateTime)dynConstraints[55] , (int)dynConstraints[56] , (long)dynConstraints[57] , (long)dynConstraints[58] , (string)dynConstraints[59] , (long)dynConstraints[60] , (string)dynConstraints[61] , (long)dynConstraints[62] , (long)dynConstraints[63] , (decimal)dynConstraints[64] , (short)dynConstraints[65] , (string)dynConstraints[66] , (bool)dynConstraints[67] , (string)dynConstraints[68] , (DateTime)dynConstraints[69] , (DateTime)dynConstraints[70] , (string)dynConstraints[71] , (string)dynConstraints[72] , (string)dynConstraints[73] , (string)dynConstraints[74] , (string)dynConstraints[75] , (string)dynConstraints[76] , (DateTime)dynConstraints[77] , (long)dynConstraints[78] , (string)dynConstraints[79] , (long)dynConstraints[80] , (long)dynConstraints[81] , (long)dynConstraints[82] );
               case 3 :
                     return conditional_P00LA9(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (long)dynConstraints[5] , (string)dynConstraints[6] , (bool)dynConstraints[7] , (string)dynConstraints[8] , (short)dynConstraints[9] , (string)dynConstraints[10] , (long)dynConstraints[11] , (string)dynConstraints[12] , (bool)dynConstraints[13] , (string)dynConstraints[14] , (short)dynConstraints[15] , (string)dynConstraints[16] , (long)dynConstraints[17] , (string)dynConstraints[18] , (long)dynConstraints[19] , (long)dynConstraints[20] , (long)dynConstraints[21] , (long)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (long)dynConstraints[25] , (long)dynConstraints[26] , (string)dynConstraints[27] , (string)dynConstraints[28] , (decimal)dynConstraints[29] , (decimal)dynConstraints[30] , (short)dynConstraints[31] , (short)dynConstraints[32] , (string)dynConstraints[33] , (string)dynConstraints[34] , (short)dynConstraints[35] , (string)dynConstraints[36] , (string)dynConstraints[37] , (DateTime)dynConstraints[38] , (DateTime)dynConstraints[39] , (DateTime)dynConstraints[40] , (DateTime)dynConstraints[41] , (string)dynConstraints[42] , (string)dynConstraints[43] , (string)dynConstraints[44] , (string)dynConstraints[45] , (string)dynConstraints[46] , (string)dynConstraints[47] , (string)dynConstraints[48] , (string)dynConstraints[49] , (string)dynConstraints[50] , (string)dynConstraints[51] , (string)dynConstraints[52] , (string)dynConstraints[53] , (DateTime)dynConstraints[54] , (DateTime)dynConstraints[55] , (int)dynConstraints[56] , (long)dynConstraints[57] , (long)dynConstraints[58] , (string)dynConstraints[59] , (long)dynConstraints[60] , (string)dynConstraints[61] , (long)dynConstraints[62] , (long)dynConstraints[63] , (decimal)dynConstraints[64] , (short)dynConstraints[65] , (string)dynConstraints[66] , (bool)dynConstraints[67] , (string)dynConstraints[68] , (DateTime)dynConstraints[69] , (DateTime)dynConstraints[70] , (string)dynConstraints[71] , (string)dynConstraints[72] , (string)dynConstraints[73] , (string)dynConstraints[74] , (string)dynConstraints[75] , (string)dynConstraints[76] , (DateTime)dynConstraints[77] , (long)dynConstraints[78] , (string)dynConstraints[79] , (long)dynConstraints[80] , (long)dynConstraints[81] , (long)dynConstraints[82] );
               case 4 :
                     return conditional_P00LA11(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (long)dynConstraints[5] , (string)dynConstraints[6] , (bool)dynConstraints[7] , (string)dynConstraints[8] , (short)dynConstraints[9] , (string)dynConstraints[10] , (long)dynConstraints[11] , (string)dynConstraints[12] , (bool)dynConstraints[13] , (string)dynConstraints[14] , (short)dynConstraints[15] , (string)dynConstraints[16] , (long)dynConstraints[17] , (string)dynConstraints[18] , (long)dynConstraints[19] , (long)dynConstraints[20] , (long)dynConstraints[21] , (long)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (long)dynConstraints[25] , (long)dynConstraints[26] , (string)dynConstraints[27] , (string)dynConstraints[28] , (decimal)dynConstraints[29] , (decimal)dynConstraints[30] , (short)dynConstraints[31] , (short)dynConstraints[32] , (string)dynConstraints[33] , (string)dynConstraints[34] , (short)dynConstraints[35] , (string)dynConstraints[36] , (string)dynConstraints[37] , (DateTime)dynConstraints[38] , (DateTime)dynConstraints[39] , (DateTime)dynConstraints[40] , (DateTime)dynConstraints[41] , (string)dynConstraints[42] , (string)dynConstraints[43] , (string)dynConstraints[44] , (string)dynConstraints[45] , (string)dynConstraints[46] , (string)dynConstraints[47] , (string)dynConstraints[48] , (string)dynConstraints[49] , (string)dynConstraints[50] , (string)dynConstraints[51] , (string)dynConstraints[52] , (string)dynConstraints[53] , (DateTime)dynConstraints[54] , (DateTime)dynConstraints[55] , (int)dynConstraints[56] , (long)dynConstraints[57] , (long)dynConstraints[58] , (string)dynConstraints[59] , (long)dynConstraints[60] , (string)dynConstraints[61] , (long)dynConstraints[62] , (long)dynConstraints[63] , (decimal)dynConstraints[64] , (short)dynConstraints[65] , (string)dynConstraints[66] , (bool)dynConstraints[67] , (string)dynConstraints[68] , (DateTime)dynConstraints[69] , (DateTime)dynConstraints[70] , (string)dynConstraints[71] , (string)dynConstraints[72] , (string)dynConstraints[73] , (string)dynConstraints[74] , (string)dynConstraints[75] , (string)dynConstraints[76] , (DateTime)dynConstraints[77] , (long)dynConstraints[78] , (string)dynConstraints[79] , (long)dynConstraints[80] , (long)dynConstraints[81] , (long)dynConstraints[82] );
               case 5 :
                     return conditional_P00LA13(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (long)dynConstraints[5] , (string)dynConstraints[6] , (bool)dynConstraints[7] , (string)dynConstraints[8] , (short)dynConstraints[9] , (string)dynConstraints[10] , (long)dynConstraints[11] , (string)dynConstraints[12] , (bool)dynConstraints[13] , (string)dynConstraints[14] , (short)dynConstraints[15] , (string)dynConstraints[16] , (long)dynConstraints[17] , (string)dynConstraints[18] , (long)dynConstraints[19] , (long)dynConstraints[20] , (long)dynConstraints[21] , (long)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (long)dynConstraints[25] , (long)dynConstraints[26] , (string)dynConstraints[27] , (string)dynConstraints[28] , (decimal)dynConstraints[29] , (decimal)dynConstraints[30] , (short)dynConstraints[31] , (short)dynConstraints[32] , (string)dynConstraints[33] , (string)dynConstraints[34] , (short)dynConstraints[35] , (string)dynConstraints[36] , (string)dynConstraints[37] , (DateTime)dynConstraints[38] , (DateTime)dynConstraints[39] , (DateTime)dynConstraints[40] , (DateTime)dynConstraints[41] , (string)dynConstraints[42] , (string)dynConstraints[43] , (string)dynConstraints[44] , (string)dynConstraints[45] , (string)dynConstraints[46] , (string)dynConstraints[47] , (string)dynConstraints[48] , (string)dynConstraints[49] , (string)dynConstraints[50] , (string)dynConstraints[51] , (string)dynConstraints[52] , (string)dynConstraints[53] , (DateTime)dynConstraints[54] , (DateTime)dynConstraints[55] , (int)dynConstraints[56] , (long)dynConstraints[57] , (long)dynConstraints[58] , (string)dynConstraints[59] , (long)dynConstraints[60] , (string)dynConstraints[61] , (long)dynConstraints[62] , (long)dynConstraints[63] , (decimal)dynConstraints[64] , (short)dynConstraints[65] , (string)dynConstraints[66] , (bool)dynConstraints[67] , (string)dynConstraints[68] , (DateTime)dynConstraints[69] , (DateTime)dynConstraints[70] , (string)dynConstraints[71] , (string)dynConstraints[72] , (string)dynConstraints[73] , (string)dynConstraints[74] , (string)dynConstraints[75] , (string)dynConstraints[76] , (DateTime)dynConstraints[77] , (long)dynConstraints[78] , (string)dynConstraints[79] , (long)dynConstraints[80] , (long)dynConstraints[81] , (long)dynConstraints[82] );
               case 6 :
                     return conditional_P00LA15(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (long)dynConstraints[5] , (string)dynConstraints[6] , (bool)dynConstraints[7] , (string)dynConstraints[8] , (short)dynConstraints[9] , (string)dynConstraints[10] , (long)dynConstraints[11] , (string)dynConstraints[12] , (bool)dynConstraints[13] , (string)dynConstraints[14] , (short)dynConstraints[15] , (string)dynConstraints[16] , (long)dynConstraints[17] , (string)dynConstraints[18] , (long)dynConstraints[19] , (long)dynConstraints[20] , (long)dynConstraints[21] , (long)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (long)dynConstraints[25] , (long)dynConstraints[26] , (string)dynConstraints[27] , (string)dynConstraints[28] , (decimal)dynConstraints[29] , (decimal)dynConstraints[30] , (short)dynConstraints[31] , (short)dynConstraints[32] , (string)dynConstraints[33] , (string)dynConstraints[34] , (short)dynConstraints[35] , (string)dynConstraints[36] , (string)dynConstraints[37] , (DateTime)dynConstraints[38] , (DateTime)dynConstraints[39] , (DateTime)dynConstraints[40] , (DateTime)dynConstraints[41] , (string)dynConstraints[42] , (string)dynConstraints[43] , (string)dynConstraints[44] , (string)dynConstraints[45] , (string)dynConstraints[46] , (string)dynConstraints[47] , (string)dynConstraints[48] , (string)dynConstraints[49] , (string)dynConstraints[50] , (string)dynConstraints[51] , (string)dynConstraints[52] , (string)dynConstraints[53] , (DateTime)dynConstraints[54] , (DateTime)dynConstraints[55] , (int)dynConstraints[56] , (long)dynConstraints[57] , (long)dynConstraints[58] , (string)dynConstraints[59] , (long)dynConstraints[60] , (string)dynConstraints[61] , (long)dynConstraints[62] , (long)dynConstraints[63] , (decimal)dynConstraints[64] , (short)dynConstraints[65] , (string)dynConstraints[66] , (bool)dynConstraints[67] , (string)dynConstraints[68] , (DateTime)dynConstraints[69] , (DateTime)dynConstraints[70] , (string)dynConstraints[71] , (string)dynConstraints[72] , (string)dynConstraints[73] , (string)dynConstraints[74] , (string)dynConstraints[75] , (string)dynConstraints[76] , (DateTime)dynConstraints[77] , (long)dynConstraints[78] , (string)dynConstraints[79] , (long)dynConstraints[80] , (long)dynConstraints[81] , (long)dynConstraints[82] );
               case 7 :
                     return conditional_P00LA17(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (long)dynConstraints[5] , (string)dynConstraints[6] , (bool)dynConstraints[7] , (string)dynConstraints[8] , (short)dynConstraints[9] , (string)dynConstraints[10] , (long)dynConstraints[11] , (string)dynConstraints[12] , (bool)dynConstraints[13] , (string)dynConstraints[14] , (short)dynConstraints[15] , (string)dynConstraints[16] , (long)dynConstraints[17] , (string)dynConstraints[18] , (long)dynConstraints[19] , (long)dynConstraints[20] , (long)dynConstraints[21] , (long)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (long)dynConstraints[25] , (long)dynConstraints[26] , (string)dynConstraints[27] , (string)dynConstraints[28] , (decimal)dynConstraints[29] , (decimal)dynConstraints[30] , (short)dynConstraints[31] , (short)dynConstraints[32] , (string)dynConstraints[33] , (string)dynConstraints[34] , (short)dynConstraints[35] , (string)dynConstraints[36] , (string)dynConstraints[37] , (DateTime)dynConstraints[38] , (DateTime)dynConstraints[39] , (DateTime)dynConstraints[40] , (DateTime)dynConstraints[41] , (string)dynConstraints[42] , (string)dynConstraints[43] , (string)dynConstraints[44] , (string)dynConstraints[45] , (string)dynConstraints[46] , (string)dynConstraints[47] , (string)dynConstraints[48] , (string)dynConstraints[49] , (string)dynConstraints[50] , (string)dynConstraints[51] , (string)dynConstraints[52] , (string)dynConstraints[53] , (DateTime)dynConstraints[54] , (DateTime)dynConstraints[55] , (int)dynConstraints[56] , (long)dynConstraints[57] , (long)dynConstraints[58] , (string)dynConstraints[59] , (long)dynConstraints[60] , (string)dynConstraints[61] , (long)dynConstraints[62] , (long)dynConstraints[63] , (decimal)dynConstraints[64] , (short)dynConstraints[65] , (string)dynConstraints[66] , (bool)dynConstraints[67] , (string)dynConstraints[68] , (DateTime)dynConstraints[69] , (DateTime)dynConstraints[70] , (string)dynConstraints[71] , (string)dynConstraints[72] , (string)dynConstraints[73] , (string)dynConstraints[74] , (string)dynConstraints[75] , (string)dynConstraints[76] , (DateTime)dynConstraints[77] , (long)dynConstraints[78] , (string)dynConstraints[79] , (long)dynConstraints[80] , (long)dynConstraints[81] , (long)dynConstraints[82] );
               case 8 :
                     return conditional_P00LA19(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (long)dynConstraints[5] , (string)dynConstraints[6] , (bool)dynConstraints[7] , (string)dynConstraints[8] , (short)dynConstraints[9] , (string)dynConstraints[10] , (long)dynConstraints[11] , (string)dynConstraints[12] , (bool)dynConstraints[13] , (string)dynConstraints[14] , (short)dynConstraints[15] , (string)dynConstraints[16] , (long)dynConstraints[17] , (string)dynConstraints[18] , (long)dynConstraints[19] , (long)dynConstraints[20] , (long)dynConstraints[21] , (long)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (long)dynConstraints[25] , (long)dynConstraints[26] , (string)dynConstraints[27] , (string)dynConstraints[28] , (decimal)dynConstraints[29] , (decimal)dynConstraints[30] , (short)dynConstraints[31] , (short)dynConstraints[32] , (string)dynConstraints[33] , (string)dynConstraints[34] , (short)dynConstraints[35] , (string)dynConstraints[36] , (string)dynConstraints[37] , (DateTime)dynConstraints[38] , (DateTime)dynConstraints[39] , (DateTime)dynConstraints[40] , (DateTime)dynConstraints[41] , (string)dynConstraints[42] , (string)dynConstraints[43] , (string)dynConstraints[44] , (string)dynConstraints[45] , (string)dynConstraints[46] , (string)dynConstraints[47] , (string)dynConstraints[48] , (string)dynConstraints[49] , (string)dynConstraints[50] , (string)dynConstraints[51] , (string)dynConstraints[52] , (string)dynConstraints[53] , (DateTime)dynConstraints[54] , (DateTime)dynConstraints[55] , (int)dynConstraints[56] , (long)dynConstraints[57] , (long)dynConstraints[58] , (string)dynConstraints[59] , (long)dynConstraints[60] , (string)dynConstraints[61] , (long)dynConstraints[62] , (long)dynConstraints[63] , (decimal)dynConstraints[64] , (short)dynConstraints[65] , (string)dynConstraints[66] , (bool)dynConstraints[67] , (string)dynConstraints[68] , (DateTime)dynConstraints[69] , (DateTime)dynConstraints[70] , (string)dynConstraints[71] , (string)dynConstraints[72] , (string)dynConstraints[73] , (string)dynConstraints[74] , (string)dynConstraints[75] , (string)dynConstraints[76] , (DateTime)dynConstraints[77] , (long)dynConstraints[78] , (string)dynConstraints[79] , (long)dynConstraints[80] , (long)dynConstraints[81] , (long)dynConstraints[82] );
               case 9 :
                     return conditional_P00LA21(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (long)dynConstraints[5] , (string)dynConstraints[6] , (bool)dynConstraints[7] , (string)dynConstraints[8] , (short)dynConstraints[9] , (string)dynConstraints[10] , (long)dynConstraints[11] , (string)dynConstraints[12] , (bool)dynConstraints[13] , (string)dynConstraints[14] , (short)dynConstraints[15] , (string)dynConstraints[16] , (long)dynConstraints[17] , (string)dynConstraints[18] , (long)dynConstraints[19] , (long)dynConstraints[20] , (long)dynConstraints[21] , (long)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (long)dynConstraints[25] , (long)dynConstraints[26] , (string)dynConstraints[27] , (string)dynConstraints[28] , (decimal)dynConstraints[29] , (decimal)dynConstraints[30] , (short)dynConstraints[31] , (short)dynConstraints[32] , (string)dynConstraints[33] , (string)dynConstraints[34] , (short)dynConstraints[35] , (string)dynConstraints[36] , (string)dynConstraints[37] , (DateTime)dynConstraints[38] , (DateTime)dynConstraints[39] , (DateTime)dynConstraints[40] , (DateTime)dynConstraints[41] , (string)dynConstraints[42] , (string)dynConstraints[43] , (string)dynConstraints[44] , (string)dynConstraints[45] , (string)dynConstraints[46] , (string)dynConstraints[47] , (string)dynConstraints[48] , (string)dynConstraints[49] , (string)dynConstraints[50] , (string)dynConstraints[51] , (string)dynConstraints[52] , (string)dynConstraints[53] , (DateTime)dynConstraints[54] , (DateTime)dynConstraints[55] , (int)dynConstraints[56] , (long)dynConstraints[57] , (long)dynConstraints[58] , (string)dynConstraints[59] , (long)dynConstraints[60] , (string)dynConstraints[61] , (long)dynConstraints[62] , (long)dynConstraints[63] , (decimal)dynConstraints[64] , (short)dynConstraints[65] , (string)dynConstraints[66] , (bool)dynConstraints[67] , (string)dynConstraints[68] , (DateTime)dynConstraints[69] , (DateTime)dynConstraints[70] , (string)dynConstraints[71] , (string)dynConstraints[72] , (string)dynConstraints[73] , (string)dynConstraints[74] , (string)dynConstraints[75] , (string)dynConstraints[76] , (DateTime)dynConstraints[77] , (long)dynConstraints[78] , (string)dynConstraints[79] , (long)dynConstraints[80] , (long)dynConstraints[81] , (long)dynConstraints[82] );
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
         ,new ForEachCursor(def[8])
         ,new ForEachCursor(def[9])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP00LA3;
          prmP00LA3 = new Object[] {
          new ParDef("@PostulacionesId",GXType.Decimal,18,0){Nullable=true} ,
          new ParDef("@AV138Postulacioneswwds_33_tfpostulacionessolicitudesid",GXType.Decimal,18,0) ,
          new ParDef("@AV138Postulacioneswwds_33_tfpostulacionessolicitudesid",GXType.Decimal,18,0) ,
          new ParDef("@AV139Postulacioneswwds_34_tfpostulacionessolicitudesid_to",GXType.Decimal,18,0) ,
          new ParDef("@AV139Postulacioneswwds_34_tfpostulacionessolicitudesid_to",GXType.Decimal,18,0) ,
          new ParDef("@lV109Postulacioneswwds_4_postulacionesproveedornombre1",GXType.Char,80,0) ,
          new ParDef("@lV109Postulacioneswwds_4_postulacionesproveedornombre1",GXType.Char,80,0) ,
          new ParDef("@AV110Postulacioneswwds_5_postulacionesproveedorid1",GXType.Decimal,18,0) ,
          new ParDef("@AV110Postulacioneswwds_5_postulacionesproveedorid1",GXType.Decimal,18,0) ,
          new ParDef("@AV110Postulacioneswwds_5_postulacionesproveedorid1",GXType.Decimal,18,0) ,
          new ParDef("@lV111Postulacioneswwds_6_serviciosnombre1",GXType.Char,80,0) ,
          new ParDef("@lV111Postulacioneswwds_6_serviciosnombre1",GXType.Char,80,0) ,
          new ParDef("@lV115Postulacioneswwds_10_postulacionesproveedornombre2",GXType.Char,80,0) ,
          new ParDef("@lV115Postulacioneswwds_10_postulacionesproveedornombre2",GXType.Char,80,0) ,
          new ParDef("@AV116Postulacioneswwds_11_postulacionesproveedorid2",GXType.Decimal,18,0) ,
          new ParDef("@AV116Postulacioneswwds_11_postulacionesproveedorid2",GXType.Decimal,18,0) ,
          new ParDef("@AV116Postulacioneswwds_11_postulacionesproveedorid2",GXType.Decimal,18,0) ,
          new ParDef("@lV117Postulacioneswwds_12_serviciosnombre2",GXType.Char,80,0) ,
          new ParDef("@lV117Postulacioneswwds_12_serviciosnombre2",GXType.Char,80,0) ,
          new ParDef("@lV121Postulacioneswwds_16_postulacionesproveedornombre3",GXType.Char,80,0) ,
          new ParDef("@lV121Postulacioneswwds_16_postulacionesproveedornombre3",GXType.Char,80,0) ,
          new ParDef("@AV122Postulacioneswwds_17_postulacionesproveedorid3",GXType.Decimal,18,0) ,
          new ParDef("@AV122Postulacioneswwds_17_postulacionesproveedorid3",GXType.Decimal,18,0) ,
          new ParDef("@AV122Postulacioneswwds_17_postulacionesproveedorid3",GXType.Decimal,18,0) ,
          new ParDef("@lV123Postulacioneswwds_18_serviciosnombre3",GXType.Char,80,0) ,
          new ParDef("@lV123Postulacioneswwds_18_serviciosnombre3",GXType.Char,80,0) ,
          new ParDef("@AV124Postulacioneswwds_19_tfpostulacionesid",GXType.Decimal,18,0) ,
          new ParDef("@AV125Postulacioneswwds_20_tfpostulacionesid_to",GXType.Decimal,18,0) ,
          new ParDef("@AV126Postulacioneswwds_21_tfserviciosid",GXType.Decimal,18,0) ,
          new ParDef("@AV127Postulacioneswwds_22_tfserviciosid_to",GXType.Decimal,18,0) ,
          new ParDef("@lV128Postulacioneswwds_23_tfserviciosnombre",GXType.Char,80,0) ,
          new ParDef("@AV129Postulacioneswwds_24_tfserviciosnombre_sel",GXType.NChar,80,0) ,
          new ParDef("@AV130Postulacioneswwds_25_tfpostulacionesproveedorid",GXType.Decimal,18,0) ,
          new ParDef("@AV131Postulacioneswwds_26_tfpostulacionesproveedorid_to",GXType.Decimal,18,0) ,
          new ParDef("@lV132Postulacioneswwds_27_tfpostulacionesproveedornombre",GXType.Char,80,0) ,
          new ParDef("@AV133Postulacioneswwds_28_tfpostulacionesproveedornombre_sel",GXType.NChar,80,0) ,
          new ParDef("@AV134Postulacioneswwds_29_tfpostulacionesprecio",GXType.Decimal,18,2) ,
          new ParDef("@AV135Postulacioneswwds_30_tfpostulacionesprecio_to",GXType.Decimal,18,2) ,
          new ParDef("@AV136Postulacioneswwds_31_tfpostulacionesmultimediaserial",GXType.Int16,4,0) ,
          new ParDef("@AV137Postulacioneswwds_32_tfpostulacionesmultimediaserial_to",GXType.Int16,4,0) ,
          new ParDef("@lV140Postulacioneswwds_35_tfpostulacionesdescripcion",GXType.Char,2000,0) ,
          new ParDef("@AV141Postulacioneswwds_36_tfpostulacionesdescripcion_sel",GXType.NChar,2000,0) ,
          new ParDef("@lV143Postulacioneswwds_38_tfpostulacionessuministrosdescripcion",GXType.Char,250,0) ,
          new ParDef("@AV144Postulacioneswwds_39_tfpostulacionessuministrosdescripcion_sel",GXType.NChar,250,0) ,
          new ParDef("@AV145Postulacioneswwds_40_tfpostulacionesfechatrabajo",GXType.Date,8,0) ,
          new ParDef("@AV146Postulacioneswwds_41_tfpostulacionesfechatrabajo_to",GXType.Date,8,0) ,
          new ParDef("@AV147Postulacioneswwds_42_tfpostulacionesfechacierre",GXType.Date,8,0) ,
          new ParDef("@AV148Postulacioneswwds_43_tfpostulacionesfechacierre_to",GXType.Date,8,0) ,
          new ParDef("@lV149Postulacioneswwds_44_tfpostulacioneshoracierre",GXType.VarChar,8,5) ,
          new ParDef("@AV150Postulacioneswwds_45_tfpostulacioneshoracierre_sel",GXType.NVarChar,8,5) ,
          new ParDef("@lV151Postulacioneswwds_46_tfpostulacionestipofecha",GXType.VarChar,10,0) ,
          new ParDef("@AV152Postulacioneswwds_47_tfpostulacionestipofecha_sel",GXType.NVarChar,10,0) ,
          new ParDef("@lV153Postulacioneswwds_48_tfpostulacionesrgohoraservicio",GXType.Char,5,0) ,
          new ParDef("@AV154Postulacioneswwds_49_tfpostulacionesrgohoraservicio_sel",GXType.NChar,5,0) ,
          new ParDef("@lV155Postulacioneswwds_50_tfpostulacionesapellidonombre",GXType.Char,80,0) ,
          new ParDef("@AV156Postulacioneswwds_51_tfpostulacionesapellidonombre_sel",GXType.NChar,80,0) ,
          new ParDef("@lV157Postulacioneswwds_52_tfpostulacionesmail",GXType.VarChar,100,0) ,
          new ParDef("@AV158Postulacioneswwds_53_tfpostulacionesmail_sel",GXType.NVarChar,100,0) ,
          new ParDef("@lV159Postulacioneswwds_54_tfpostulacionestelefono",GXType.Char,20,0) ,
          new ParDef("@AV160Postulacioneswwds_55_tfpostulacionestelefono_sel",GXType.NChar,20,0) ,
          new ParDef("@AV161Postulacioneswwds_56_tfpostulacionesfechaalta",GXType.DateTime,8,5) ,
          new ParDef("@AV162Postulacioneswwds_57_tfpostulacionesfechaalta_to",GXType.DateTime,8,5) ,
          new ParDef("@AV164Postulacioneswwds_59_tfpostulacionessecuserid",GXType.Decimal,18,0) ,
          new ParDef("@AV165Postulacioneswwds_60_tfpostulacionessecuserid_to",GXType.Decimal,18,0)
          };
          Object[] prmP00LA5;
          prmP00LA5 = new Object[] {
          new ParDef("@PostulacionesId",GXType.Decimal,18,0){Nullable=true} ,
          new ParDef("@AV138Postulacioneswwds_33_tfpostulacionessolicitudesid",GXType.Decimal,18,0) ,
          new ParDef("@AV138Postulacioneswwds_33_tfpostulacionessolicitudesid",GXType.Decimal,18,0) ,
          new ParDef("@AV139Postulacioneswwds_34_tfpostulacionessolicitudesid_to",GXType.Decimal,18,0) ,
          new ParDef("@AV139Postulacioneswwds_34_tfpostulacionessolicitudesid_to",GXType.Decimal,18,0) ,
          new ParDef("@lV109Postulacioneswwds_4_postulacionesproveedornombre1",GXType.Char,80,0) ,
          new ParDef("@lV109Postulacioneswwds_4_postulacionesproveedornombre1",GXType.Char,80,0) ,
          new ParDef("@AV110Postulacioneswwds_5_postulacionesproveedorid1",GXType.Decimal,18,0) ,
          new ParDef("@AV110Postulacioneswwds_5_postulacionesproveedorid1",GXType.Decimal,18,0) ,
          new ParDef("@AV110Postulacioneswwds_5_postulacionesproveedorid1",GXType.Decimal,18,0) ,
          new ParDef("@lV111Postulacioneswwds_6_serviciosnombre1",GXType.Char,80,0) ,
          new ParDef("@lV111Postulacioneswwds_6_serviciosnombre1",GXType.Char,80,0) ,
          new ParDef("@lV115Postulacioneswwds_10_postulacionesproveedornombre2",GXType.Char,80,0) ,
          new ParDef("@lV115Postulacioneswwds_10_postulacionesproveedornombre2",GXType.Char,80,0) ,
          new ParDef("@AV116Postulacioneswwds_11_postulacionesproveedorid2",GXType.Decimal,18,0) ,
          new ParDef("@AV116Postulacioneswwds_11_postulacionesproveedorid2",GXType.Decimal,18,0) ,
          new ParDef("@AV116Postulacioneswwds_11_postulacionesproveedorid2",GXType.Decimal,18,0) ,
          new ParDef("@lV117Postulacioneswwds_12_serviciosnombre2",GXType.Char,80,0) ,
          new ParDef("@lV117Postulacioneswwds_12_serviciosnombre2",GXType.Char,80,0) ,
          new ParDef("@lV121Postulacioneswwds_16_postulacionesproveedornombre3",GXType.Char,80,0) ,
          new ParDef("@lV121Postulacioneswwds_16_postulacionesproveedornombre3",GXType.Char,80,0) ,
          new ParDef("@AV122Postulacioneswwds_17_postulacionesproveedorid3",GXType.Decimal,18,0) ,
          new ParDef("@AV122Postulacioneswwds_17_postulacionesproveedorid3",GXType.Decimal,18,0) ,
          new ParDef("@AV122Postulacioneswwds_17_postulacionesproveedorid3",GXType.Decimal,18,0) ,
          new ParDef("@lV123Postulacioneswwds_18_serviciosnombre3",GXType.Char,80,0) ,
          new ParDef("@lV123Postulacioneswwds_18_serviciosnombre3",GXType.Char,80,0) ,
          new ParDef("@AV124Postulacioneswwds_19_tfpostulacionesid",GXType.Decimal,18,0) ,
          new ParDef("@AV125Postulacioneswwds_20_tfpostulacionesid_to",GXType.Decimal,18,0) ,
          new ParDef("@AV126Postulacioneswwds_21_tfserviciosid",GXType.Decimal,18,0) ,
          new ParDef("@AV127Postulacioneswwds_22_tfserviciosid_to",GXType.Decimal,18,0) ,
          new ParDef("@lV128Postulacioneswwds_23_tfserviciosnombre",GXType.Char,80,0) ,
          new ParDef("@AV129Postulacioneswwds_24_tfserviciosnombre_sel",GXType.NChar,80,0) ,
          new ParDef("@AV130Postulacioneswwds_25_tfpostulacionesproveedorid",GXType.Decimal,18,0) ,
          new ParDef("@AV131Postulacioneswwds_26_tfpostulacionesproveedorid_to",GXType.Decimal,18,0) ,
          new ParDef("@lV132Postulacioneswwds_27_tfpostulacionesproveedornombre",GXType.Char,80,0) ,
          new ParDef("@AV133Postulacioneswwds_28_tfpostulacionesproveedornombre_sel",GXType.NChar,80,0) ,
          new ParDef("@AV134Postulacioneswwds_29_tfpostulacionesprecio",GXType.Decimal,18,2) ,
          new ParDef("@AV135Postulacioneswwds_30_tfpostulacionesprecio_to",GXType.Decimal,18,2) ,
          new ParDef("@AV136Postulacioneswwds_31_tfpostulacionesmultimediaserial",GXType.Int16,4,0) ,
          new ParDef("@AV137Postulacioneswwds_32_tfpostulacionesmultimediaserial_to",GXType.Int16,4,0) ,
          new ParDef("@lV140Postulacioneswwds_35_tfpostulacionesdescripcion",GXType.Char,2000,0) ,
          new ParDef("@AV141Postulacioneswwds_36_tfpostulacionesdescripcion_sel",GXType.NChar,2000,0) ,
          new ParDef("@lV143Postulacioneswwds_38_tfpostulacionessuministrosdescripcion",GXType.Char,250,0) ,
          new ParDef("@AV144Postulacioneswwds_39_tfpostulacionessuministrosdescripcion_sel",GXType.NChar,250,0) ,
          new ParDef("@AV145Postulacioneswwds_40_tfpostulacionesfechatrabajo",GXType.Date,8,0) ,
          new ParDef("@AV146Postulacioneswwds_41_tfpostulacionesfechatrabajo_to",GXType.Date,8,0) ,
          new ParDef("@AV147Postulacioneswwds_42_tfpostulacionesfechacierre",GXType.Date,8,0) ,
          new ParDef("@AV148Postulacioneswwds_43_tfpostulacionesfechacierre_to",GXType.Date,8,0) ,
          new ParDef("@lV149Postulacioneswwds_44_tfpostulacioneshoracierre",GXType.VarChar,8,5) ,
          new ParDef("@AV150Postulacioneswwds_45_tfpostulacioneshoracierre_sel",GXType.NVarChar,8,5) ,
          new ParDef("@lV151Postulacioneswwds_46_tfpostulacionestipofecha",GXType.VarChar,10,0) ,
          new ParDef("@AV152Postulacioneswwds_47_tfpostulacionestipofecha_sel",GXType.NVarChar,10,0) ,
          new ParDef("@lV153Postulacioneswwds_48_tfpostulacionesrgohoraservicio",GXType.Char,5,0) ,
          new ParDef("@AV154Postulacioneswwds_49_tfpostulacionesrgohoraservicio_sel",GXType.NChar,5,0) ,
          new ParDef("@lV155Postulacioneswwds_50_tfpostulacionesapellidonombre",GXType.Char,80,0) ,
          new ParDef("@AV156Postulacioneswwds_51_tfpostulacionesapellidonombre_sel",GXType.NChar,80,0) ,
          new ParDef("@lV157Postulacioneswwds_52_tfpostulacionesmail",GXType.VarChar,100,0) ,
          new ParDef("@AV158Postulacioneswwds_53_tfpostulacionesmail_sel",GXType.NVarChar,100,0) ,
          new ParDef("@lV159Postulacioneswwds_54_tfpostulacionestelefono",GXType.Char,20,0) ,
          new ParDef("@AV160Postulacioneswwds_55_tfpostulacionestelefono_sel",GXType.NChar,20,0) ,
          new ParDef("@AV161Postulacioneswwds_56_tfpostulacionesfechaalta",GXType.DateTime,8,5) ,
          new ParDef("@AV162Postulacioneswwds_57_tfpostulacionesfechaalta_to",GXType.DateTime,8,5) ,
          new ParDef("@AV164Postulacioneswwds_59_tfpostulacionessecuserid",GXType.Decimal,18,0) ,
          new ParDef("@AV165Postulacioneswwds_60_tfpostulacionessecuserid_to",GXType.Decimal,18,0)
          };
          Object[] prmP00LA7;
          prmP00LA7 = new Object[] {
          new ParDef("@PostulacionesId",GXType.Decimal,18,0){Nullable=true} ,
          new ParDef("@AV138Postulacioneswwds_33_tfpostulacionessolicitudesid",GXType.Decimal,18,0) ,
          new ParDef("@AV138Postulacioneswwds_33_tfpostulacionessolicitudesid",GXType.Decimal,18,0) ,
          new ParDef("@AV139Postulacioneswwds_34_tfpostulacionessolicitudesid_to",GXType.Decimal,18,0) ,
          new ParDef("@AV139Postulacioneswwds_34_tfpostulacionessolicitudesid_to",GXType.Decimal,18,0) ,
          new ParDef("@lV109Postulacioneswwds_4_postulacionesproveedornombre1",GXType.Char,80,0) ,
          new ParDef("@lV109Postulacioneswwds_4_postulacionesproveedornombre1",GXType.Char,80,0) ,
          new ParDef("@AV110Postulacioneswwds_5_postulacionesproveedorid1",GXType.Decimal,18,0) ,
          new ParDef("@AV110Postulacioneswwds_5_postulacionesproveedorid1",GXType.Decimal,18,0) ,
          new ParDef("@AV110Postulacioneswwds_5_postulacionesproveedorid1",GXType.Decimal,18,0) ,
          new ParDef("@lV111Postulacioneswwds_6_serviciosnombre1",GXType.Char,80,0) ,
          new ParDef("@lV111Postulacioneswwds_6_serviciosnombre1",GXType.Char,80,0) ,
          new ParDef("@lV115Postulacioneswwds_10_postulacionesproveedornombre2",GXType.Char,80,0) ,
          new ParDef("@lV115Postulacioneswwds_10_postulacionesproveedornombre2",GXType.Char,80,0) ,
          new ParDef("@AV116Postulacioneswwds_11_postulacionesproveedorid2",GXType.Decimal,18,0) ,
          new ParDef("@AV116Postulacioneswwds_11_postulacionesproveedorid2",GXType.Decimal,18,0) ,
          new ParDef("@AV116Postulacioneswwds_11_postulacionesproveedorid2",GXType.Decimal,18,0) ,
          new ParDef("@lV117Postulacioneswwds_12_serviciosnombre2",GXType.Char,80,0) ,
          new ParDef("@lV117Postulacioneswwds_12_serviciosnombre2",GXType.Char,80,0) ,
          new ParDef("@lV121Postulacioneswwds_16_postulacionesproveedornombre3",GXType.Char,80,0) ,
          new ParDef("@lV121Postulacioneswwds_16_postulacionesproveedornombre3",GXType.Char,80,0) ,
          new ParDef("@AV122Postulacioneswwds_17_postulacionesproveedorid3",GXType.Decimal,18,0) ,
          new ParDef("@AV122Postulacioneswwds_17_postulacionesproveedorid3",GXType.Decimal,18,0) ,
          new ParDef("@AV122Postulacioneswwds_17_postulacionesproveedorid3",GXType.Decimal,18,0) ,
          new ParDef("@lV123Postulacioneswwds_18_serviciosnombre3",GXType.Char,80,0) ,
          new ParDef("@lV123Postulacioneswwds_18_serviciosnombre3",GXType.Char,80,0) ,
          new ParDef("@AV124Postulacioneswwds_19_tfpostulacionesid",GXType.Decimal,18,0) ,
          new ParDef("@AV125Postulacioneswwds_20_tfpostulacionesid_to",GXType.Decimal,18,0) ,
          new ParDef("@AV126Postulacioneswwds_21_tfserviciosid",GXType.Decimal,18,0) ,
          new ParDef("@AV127Postulacioneswwds_22_tfserviciosid_to",GXType.Decimal,18,0) ,
          new ParDef("@lV128Postulacioneswwds_23_tfserviciosnombre",GXType.Char,80,0) ,
          new ParDef("@AV129Postulacioneswwds_24_tfserviciosnombre_sel",GXType.NChar,80,0) ,
          new ParDef("@AV130Postulacioneswwds_25_tfpostulacionesproveedorid",GXType.Decimal,18,0) ,
          new ParDef("@AV131Postulacioneswwds_26_tfpostulacionesproveedorid_to",GXType.Decimal,18,0) ,
          new ParDef("@lV132Postulacioneswwds_27_tfpostulacionesproveedornombre",GXType.Char,80,0) ,
          new ParDef("@AV133Postulacioneswwds_28_tfpostulacionesproveedornombre_sel",GXType.NChar,80,0) ,
          new ParDef("@AV134Postulacioneswwds_29_tfpostulacionesprecio",GXType.Decimal,18,2) ,
          new ParDef("@AV135Postulacioneswwds_30_tfpostulacionesprecio_to",GXType.Decimal,18,2) ,
          new ParDef("@AV136Postulacioneswwds_31_tfpostulacionesmultimediaserial",GXType.Int16,4,0) ,
          new ParDef("@AV137Postulacioneswwds_32_tfpostulacionesmultimediaserial_to",GXType.Int16,4,0) ,
          new ParDef("@lV140Postulacioneswwds_35_tfpostulacionesdescripcion",GXType.Char,2000,0) ,
          new ParDef("@AV141Postulacioneswwds_36_tfpostulacionesdescripcion_sel",GXType.NChar,2000,0) ,
          new ParDef("@lV143Postulacioneswwds_38_tfpostulacionessuministrosdescripcion",GXType.Char,250,0) ,
          new ParDef("@AV144Postulacioneswwds_39_tfpostulacionessuministrosdescripcion_sel",GXType.NChar,250,0) ,
          new ParDef("@AV145Postulacioneswwds_40_tfpostulacionesfechatrabajo",GXType.Date,8,0) ,
          new ParDef("@AV146Postulacioneswwds_41_tfpostulacionesfechatrabajo_to",GXType.Date,8,0) ,
          new ParDef("@AV147Postulacioneswwds_42_tfpostulacionesfechacierre",GXType.Date,8,0) ,
          new ParDef("@AV148Postulacioneswwds_43_tfpostulacionesfechacierre_to",GXType.Date,8,0) ,
          new ParDef("@lV149Postulacioneswwds_44_tfpostulacioneshoracierre",GXType.VarChar,8,5) ,
          new ParDef("@AV150Postulacioneswwds_45_tfpostulacioneshoracierre_sel",GXType.NVarChar,8,5) ,
          new ParDef("@lV151Postulacioneswwds_46_tfpostulacionestipofecha",GXType.VarChar,10,0) ,
          new ParDef("@AV152Postulacioneswwds_47_tfpostulacionestipofecha_sel",GXType.NVarChar,10,0) ,
          new ParDef("@lV153Postulacioneswwds_48_tfpostulacionesrgohoraservicio",GXType.Char,5,0) ,
          new ParDef("@AV154Postulacioneswwds_49_tfpostulacionesrgohoraservicio_sel",GXType.NChar,5,0) ,
          new ParDef("@lV155Postulacioneswwds_50_tfpostulacionesapellidonombre",GXType.Char,80,0) ,
          new ParDef("@AV156Postulacioneswwds_51_tfpostulacionesapellidonombre_sel",GXType.NChar,80,0) ,
          new ParDef("@lV157Postulacioneswwds_52_tfpostulacionesmail",GXType.VarChar,100,0) ,
          new ParDef("@AV158Postulacioneswwds_53_tfpostulacionesmail_sel",GXType.NVarChar,100,0) ,
          new ParDef("@lV159Postulacioneswwds_54_tfpostulacionestelefono",GXType.Char,20,0) ,
          new ParDef("@AV160Postulacioneswwds_55_tfpostulacionestelefono_sel",GXType.NChar,20,0) ,
          new ParDef("@AV161Postulacioneswwds_56_tfpostulacionesfechaalta",GXType.DateTime,8,5) ,
          new ParDef("@AV162Postulacioneswwds_57_tfpostulacionesfechaalta_to",GXType.DateTime,8,5) ,
          new ParDef("@AV164Postulacioneswwds_59_tfpostulacionessecuserid",GXType.Decimal,18,0) ,
          new ParDef("@AV165Postulacioneswwds_60_tfpostulacionessecuserid_to",GXType.Decimal,18,0)
          };
          Object[] prmP00LA9;
          prmP00LA9 = new Object[] {
          new ParDef("@PostulacionesId",GXType.Decimal,18,0){Nullable=true} ,
          new ParDef("@AV138Postulacioneswwds_33_tfpostulacionessolicitudesid",GXType.Decimal,18,0) ,
          new ParDef("@AV138Postulacioneswwds_33_tfpostulacionessolicitudesid",GXType.Decimal,18,0) ,
          new ParDef("@AV139Postulacioneswwds_34_tfpostulacionessolicitudesid_to",GXType.Decimal,18,0) ,
          new ParDef("@AV139Postulacioneswwds_34_tfpostulacionessolicitudesid_to",GXType.Decimal,18,0) ,
          new ParDef("@lV109Postulacioneswwds_4_postulacionesproveedornombre1",GXType.Char,80,0) ,
          new ParDef("@lV109Postulacioneswwds_4_postulacionesproveedornombre1",GXType.Char,80,0) ,
          new ParDef("@AV110Postulacioneswwds_5_postulacionesproveedorid1",GXType.Decimal,18,0) ,
          new ParDef("@AV110Postulacioneswwds_5_postulacionesproveedorid1",GXType.Decimal,18,0) ,
          new ParDef("@AV110Postulacioneswwds_5_postulacionesproveedorid1",GXType.Decimal,18,0) ,
          new ParDef("@lV111Postulacioneswwds_6_serviciosnombre1",GXType.Char,80,0) ,
          new ParDef("@lV111Postulacioneswwds_6_serviciosnombre1",GXType.Char,80,0) ,
          new ParDef("@lV115Postulacioneswwds_10_postulacionesproveedornombre2",GXType.Char,80,0) ,
          new ParDef("@lV115Postulacioneswwds_10_postulacionesproveedornombre2",GXType.Char,80,0) ,
          new ParDef("@AV116Postulacioneswwds_11_postulacionesproveedorid2",GXType.Decimal,18,0) ,
          new ParDef("@AV116Postulacioneswwds_11_postulacionesproveedorid2",GXType.Decimal,18,0) ,
          new ParDef("@AV116Postulacioneswwds_11_postulacionesproveedorid2",GXType.Decimal,18,0) ,
          new ParDef("@lV117Postulacioneswwds_12_serviciosnombre2",GXType.Char,80,0) ,
          new ParDef("@lV117Postulacioneswwds_12_serviciosnombre2",GXType.Char,80,0) ,
          new ParDef("@lV121Postulacioneswwds_16_postulacionesproveedornombre3",GXType.Char,80,0) ,
          new ParDef("@lV121Postulacioneswwds_16_postulacionesproveedornombre3",GXType.Char,80,0) ,
          new ParDef("@AV122Postulacioneswwds_17_postulacionesproveedorid3",GXType.Decimal,18,0) ,
          new ParDef("@AV122Postulacioneswwds_17_postulacionesproveedorid3",GXType.Decimal,18,0) ,
          new ParDef("@AV122Postulacioneswwds_17_postulacionesproveedorid3",GXType.Decimal,18,0) ,
          new ParDef("@lV123Postulacioneswwds_18_serviciosnombre3",GXType.Char,80,0) ,
          new ParDef("@lV123Postulacioneswwds_18_serviciosnombre3",GXType.Char,80,0) ,
          new ParDef("@AV124Postulacioneswwds_19_tfpostulacionesid",GXType.Decimal,18,0) ,
          new ParDef("@AV125Postulacioneswwds_20_tfpostulacionesid_to",GXType.Decimal,18,0) ,
          new ParDef("@AV126Postulacioneswwds_21_tfserviciosid",GXType.Decimal,18,0) ,
          new ParDef("@AV127Postulacioneswwds_22_tfserviciosid_to",GXType.Decimal,18,0) ,
          new ParDef("@lV128Postulacioneswwds_23_tfserviciosnombre",GXType.Char,80,0) ,
          new ParDef("@AV129Postulacioneswwds_24_tfserviciosnombre_sel",GXType.NChar,80,0) ,
          new ParDef("@AV130Postulacioneswwds_25_tfpostulacionesproveedorid",GXType.Decimal,18,0) ,
          new ParDef("@AV131Postulacioneswwds_26_tfpostulacionesproveedorid_to",GXType.Decimal,18,0) ,
          new ParDef("@lV132Postulacioneswwds_27_tfpostulacionesproveedornombre",GXType.Char,80,0) ,
          new ParDef("@AV133Postulacioneswwds_28_tfpostulacionesproveedornombre_sel",GXType.NChar,80,0) ,
          new ParDef("@AV134Postulacioneswwds_29_tfpostulacionesprecio",GXType.Decimal,18,2) ,
          new ParDef("@AV135Postulacioneswwds_30_tfpostulacionesprecio_to",GXType.Decimal,18,2) ,
          new ParDef("@AV136Postulacioneswwds_31_tfpostulacionesmultimediaserial",GXType.Int16,4,0) ,
          new ParDef("@AV137Postulacioneswwds_32_tfpostulacionesmultimediaserial_to",GXType.Int16,4,0) ,
          new ParDef("@lV140Postulacioneswwds_35_tfpostulacionesdescripcion",GXType.Char,2000,0) ,
          new ParDef("@AV141Postulacioneswwds_36_tfpostulacionesdescripcion_sel",GXType.NChar,2000,0) ,
          new ParDef("@lV143Postulacioneswwds_38_tfpostulacionessuministrosdescripcion",GXType.Char,250,0) ,
          new ParDef("@AV144Postulacioneswwds_39_tfpostulacionessuministrosdescripcion_sel",GXType.NChar,250,0) ,
          new ParDef("@AV145Postulacioneswwds_40_tfpostulacionesfechatrabajo",GXType.Date,8,0) ,
          new ParDef("@AV146Postulacioneswwds_41_tfpostulacionesfechatrabajo_to",GXType.Date,8,0) ,
          new ParDef("@AV147Postulacioneswwds_42_tfpostulacionesfechacierre",GXType.Date,8,0) ,
          new ParDef("@AV148Postulacioneswwds_43_tfpostulacionesfechacierre_to",GXType.Date,8,0) ,
          new ParDef("@lV149Postulacioneswwds_44_tfpostulacioneshoracierre",GXType.VarChar,8,5) ,
          new ParDef("@AV150Postulacioneswwds_45_tfpostulacioneshoracierre_sel",GXType.NVarChar,8,5) ,
          new ParDef("@lV151Postulacioneswwds_46_tfpostulacionestipofecha",GXType.VarChar,10,0) ,
          new ParDef("@AV152Postulacioneswwds_47_tfpostulacionestipofecha_sel",GXType.NVarChar,10,0) ,
          new ParDef("@lV153Postulacioneswwds_48_tfpostulacionesrgohoraservicio",GXType.Char,5,0) ,
          new ParDef("@AV154Postulacioneswwds_49_tfpostulacionesrgohoraservicio_sel",GXType.NChar,5,0) ,
          new ParDef("@lV155Postulacioneswwds_50_tfpostulacionesapellidonombre",GXType.Char,80,0) ,
          new ParDef("@AV156Postulacioneswwds_51_tfpostulacionesapellidonombre_sel",GXType.NChar,80,0) ,
          new ParDef("@lV157Postulacioneswwds_52_tfpostulacionesmail",GXType.VarChar,100,0) ,
          new ParDef("@AV158Postulacioneswwds_53_tfpostulacionesmail_sel",GXType.NVarChar,100,0) ,
          new ParDef("@lV159Postulacioneswwds_54_tfpostulacionestelefono",GXType.Char,20,0) ,
          new ParDef("@AV160Postulacioneswwds_55_tfpostulacionestelefono_sel",GXType.NChar,20,0) ,
          new ParDef("@AV161Postulacioneswwds_56_tfpostulacionesfechaalta",GXType.DateTime,8,5) ,
          new ParDef("@AV162Postulacioneswwds_57_tfpostulacionesfechaalta_to",GXType.DateTime,8,5) ,
          new ParDef("@AV164Postulacioneswwds_59_tfpostulacionessecuserid",GXType.Decimal,18,0) ,
          new ParDef("@AV165Postulacioneswwds_60_tfpostulacionessecuserid_to",GXType.Decimal,18,0)
          };
          Object[] prmP00LA11;
          prmP00LA11 = new Object[] {
          new ParDef("@PostulacionesId",GXType.Decimal,18,0){Nullable=true} ,
          new ParDef("@AV138Postulacioneswwds_33_tfpostulacionessolicitudesid",GXType.Decimal,18,0) ,
          new ParDef("@AV138Postulacioneswwds_33_tfpostulacionessolicitudesid",GXType.Decimal,18,0) ,
          new ParDef("@AV139Postulacioneswwds_34_tfpostulacionessolicitudesid_to",GXType.Decimal,18,0) ,
          new ParDef("@AV139Postulacioneswwds_34_tfpostulacionessolicitudesid_to",GXType.Decimal,18,0) ,
          new ParDef("@lV109Postulacioneswwds_4_postulacionesproveedornombre1",GXType.Char,80,0) ,
          new ParDef("@lV109Postulacioneswwds_4_postulacionesproveedornombre1",GXType.Char,80,0) ,
          new ParDef("@AV110Postulacioneswwds_5_postulacionesproveedorid1",GXType.Decimal,18,0) ,
          new ParDef("@AV110Postulacioneswwds_5_postulacionesproveedorid1",GXType.Decimal,18,0) ,
          new ParDef("@AV110Postulacioneswwds_5_postulacionesproveedorid1",GXType.Decimal,18,0) ,
          new ParDef("@lV111Postulacioneswwds_6_serviciosnombre1",GXType.Char,80,0) ,
          new ParDef("@lV111Postulacioneswwds_6_serviciosnombre1",GXType.Char,80,0) ,
          new ParDef("@lV115Postulacioneswwds_10_postulacionesproveedornombre2",GXType.Char,80,0) ,
          new ParDef("@lV115Postulacioneswwds_10_postulacionesproveedornombre2",GXType.Char,80,0) ,
          new ParDef("@AV116Postulacioneswwds_11_postulacionesproveedorid2",GXType.Decimal,18,0) ,
          new ParDef("@AV116Postulacioneswwds_11_postulacionesproveedorid2",GXType.Decimal,18,0) ,
          new ParDef("@AV116Postulacioneswwds_11_postulacionesproveedorid2",GXType.Decimal,18,0) ,
          new ParDef("@lV117Postulacioneswwds_12_serviciosnombre2",GXType.Char,80,0) ,
          new ParDef("@lV117Postulacioneswwds_12_serviciosnombre2",GXType.Char,80,0) ,
          new ParDef("@lV121Postulacioneswwds_16_postulacionesproveedornombre3",GXType.Char,80,0) ,
          new ParDef("@lV121Postulacioneswwds_16_postulacionesproveedornombre3",GXType.Char,80,0) ,
          new ParDef("@AV122Postulacioneswwds_17_postulacionesproveedorid3",GXType.Decimal,18,0) ,
          new ParDef("@AV122Postulacioneswwds_17_postulacionesproveedorid3",GXType.Decimal,18,0) ,
          new ParDef("@AV122Postulacioneswwds_17_postulacionesproveedorid3",GXType.Decimal,18,0) ,
          new ParDef("@lV123Postulacioneswwds_18_serviciosnombre3",GXType.Char,80,0) ,
          new ParDef("@lV123Postulacioneswwds_18_serviciosnombre3",GXType.Char,80,0) ,
          new ParDef("@AV124Postulacioneswwds_19_tfpostulacionesid",GXType.Decimal,18,0) ,
          new ParDef("@AV125Postulacioneswwds_20_tfpostulacionesid_to",GXType.Decimal,18,0) ,
          new ParDef("@AV126Postulacioneswwds_21_tfserviciosid",GXType.Decimal,18,0) ,
          new ParDef("@AV127Postulacioneswwds_22_tfserviciosid_to",GXType.Decimal,18,0) ,
          new ParDef("@lV128Postulacioneswwds_23_tfserviciosnombre",GXType.Char,80,0) ,
          new ParDef("@AV129Postulacioneswwds_24_tfserviciosnombre_sel",GXType.NChar,80,0) ,
          new ParDef("@AV130Postulacioneswwds_25_tfpostulacionesproveedorid",GXType.Decimal,18,0) ,
          new ParDef("@AV131Postulacioneswwds_26_tfpostulacionesproveedorid_to",GXType.Decimal,18,0) ,
          new ParDef("@lV132Postulacioneswwds_27_tfpostulacionesproveedornombre",GXType.Char,80,0) ,
          new ParDef("@AV133Postulacioneswwds_28_tfpostulacionesproveedornombre_sel",GXType.NChar,80,0) ,
          new ParDef("@AV134Postulacioneswwds_29_tfpostulacionesprecio",GXType.Decimal,18,2) ,
          new ParDef("@AV135Postulacioneswwds_30_tfpostulacionesprecio_to",GXType.Decimal,18,2) ,
          new ParDef("@AV136Postulacioneswwds_31_tfpostulacionesmultimediaserial",GXType.Int16,4,0) ,
          new ParDef("@AV137Postulacioneswwds_32_tfpostulacionesmultimediaserial_to",GXType.Int16,4,0) ,
          new ParDef("@lV140Postulacioneswwds_35_tfpostulacionesdescripcion",GXType.Char,2000,0) ,
          new ParDef("@AV141Postulacioneswwds_36_tfpostulacionesdescripcion_sel",GXType.NChar,2000,0) ,
          new ParDef("@lV143Postulacioneswwds_38_tfpostulacionessuministrosdescripcion",GXType.Char,250,0) ,
          new ParDef("@AV144Postulacioneswwds_39_tfpostulacionessuministrosdescripcion_sel",GXType.NChar,250,0) ,
          new ParDef("@AV145Postulacioneswwds_40_tfpostulacionesfechatrabajo",GXType.Date,8,0) ,
          new ParDef("@AV146Postulacioneswwds_41_tfpostulacionesfechatrabajo_to",GXType.Date,8,0) ,
          new ParDef("@AV147Postulacioneswwds_42_tfpostulacionesfechacierre",GXType.Date,8,0) ,
          new ParDef("@AV148Postulacioneswwds_43_tfpostulacionesfechacierre_to",GXType.Date,8,0) ,
          new ParDef("@lV149Postulacioneswwds_44_tfpostulacioneshoracierre",GXType.VarChar,8,5) ,
          new ParDef("@AV150Postulacioneswwds_45_tfpostulacioneshoracierre_sel",GXType.NVarChar,8,5) ,
          new ParDef("@lV151Postulacioneswwds_46_tfpostulacionestipofecha",GXType.VarChar,10,0) ,
          new ParDef("@AV152Postulacioneswwds_47_tfpostulacionestipofecha_sel",GXType.NVarChar,10,0) ,
          new ParDef("@lV153Postulacioneswwds_48_tfpostulacionesrgohoraservicio",GXType.Char,5,0) ,
          new ParDef("@AV154Postulacioneswwds_49_tfpostulacionesrgohoraservicio_sel",GXType.NChar,5,0) ,
          new ParDef("@lV155Postulacioneswwds_50_tfpostulacionesapellidonombre",GXType.Char,80,0) ,
          new ParDef("@AV156Postulacioneswwds_51_tfpostulacionesapellidonombre_sel",GXType.NChar,80,0) ,
          new ParDef("@lV157Postulacioneswwds_52_tfpostulacionesmail",GXType.VarChar,100,0) ,
          new ParDef("@AV158Postulacioneswwds_53_tfpostulacionesmail_sel",GXType.NVarChar,100,0) ,
          new ParDef("@lV159Postulacioneswwds_54_tfpostulacionestelefono",GXType.Char,20,0) ,
          new ParDef("@AV160Postulacioneswwds_55_tfpostulacionestelefono_sel",GXType.NChar,20,0) ,
          new ParDef("@AV161Postulacioneswwds_56_tfpostulacionesfechaalta",GXType.DateTime,8,5) ,
          new ParDef("@AV162Postulacioneswwds_57_tfpostulacionesfechaalta_to",GXType.DateTime,8,5) ,
          new ParDef("@AV164Postulacioneswwds_59_tfpostulacionessecuserid",GXType.Decimal,18,0) ,
          new ParDef("@AV165Postulacioneswwds_60_tfpostulacionessecuserid_to",GXType.Decimal,18,0)
          };
          Object[] prmP00LA13;
          prmP00LA13 = new Object[] {
          new ParDef("@PostulacionesId",GXType.Decimal,18,0){Nullable=true} ,
          new ParDef("@AV138Postulacioneswwds_33_tfpostulacionessolicitudesid",GXType.Decimal,18,0) ,
          new ParDef("@AV138Postulacioneswwds_33_tfpostulacionessolicitudesid",GXType.Decimal,18,0) ,
          new ParDef("@AV139Postulacioneswwds_34_tfpostulacionessolicitudesid_to",GXType.Decimal,18,0) ,
          new ParDef("@AV139Postulacioneswwds_34_tfpostulacionessolicitudesid_to",GXType.Decimal,18,0) ,
          new ParDef("@lV109Postulacioneswwds_4_postulacionesproveedornombre1",GXType.Char,80,0) ,
          new ParDef("@lV109Postulacioneswwds_4_postulacionesproveedornombre1",GXType.Char,80,0) ,
          new ParDef("@AV110Postulacioneswwds_5_postulacionesproveedorid1",GXType.Decimal,18,0) ,
          new ParDef("@AV110Postulacioneswwds_5_postulacionesproveedorid1",GXType.Decimal,18,0) ,
          new ParDef("@AV110Postulacioneswwds_5_postulacionesproveedorid1",GXType.Decimal,18,0) ,
          new ParDef("@lV111Postulacioneswwds_6_serviciosnombre1",GXType.Char,80,0) ,
          new ParDef("@lV111Postulacioneswwds_6_serviciosnombre1",GXType.Char,80,0) ,
          new ParDef("@lV115Postulacioneswwds_10_postulacionesproveedornombre2",GXType.Char,80,0) ,
          new ParDef("@lV115Postulacioneswwds_10_postulacionesproveedornombre2",GXType.Char,80,0) ,
          new ParDef("@AV116Postulacioneswwds_11_postulacionesproveedorid2",GXType.Decimal,18,0) ,
          new ParDef("@AV116Postulacioneswwds_11_postulacionesproveedorid2",GXType.Decimal,18,0) ,
          new ParDef("@AV116Postulacioneswwds_11_postulacionesproveedorid2",GXType.Decimal,18,0) ,
          new ParDef("@lV117Postulacioneswwds_12_serviciosnombre2",GXType.Char,80,0) ,
          new ParDef("@lV117Postulacioneswwds_12_serviciosnombre2",GXType.Char,80,0) ,
          new ParDef("@lV121Postulacioneswwds_16_postulacionesproveedornombre3",GXType.Char,80,0) ,
          new ParDef("@lV121Postulacioneswwds_16_postulacionesproveedornombre3",GXType.Char,80,0) ,
          new ParDef("@AV122Postulacioneswwds_17_postulacionesproveedorid3",GXType.Decimal,18,0) ,
          new ParDef("@AV122Postulacioneswwds_17_postulacionesproveedorid3",GXType.Decimal,18,0) ,
          new ParDef("@AV122Postulacioneswwds_17_postulacionesproveedorid3",GXType.Decimal,18,0) ,
          new ParDef("@lV123Postulacioneswwds_18_serviciosnombre3",GXType.Char,80,0) ,
          new ParDef("@lV123Postulacioneswwds_18_serviciosnombre3",GXType.Char,80,0) ,
          new ParDef("@AV124Postulacioneswwds_19_tfpostulacionesid",GXType.Decimal,18,0) ,
          new ParDef("@AV125Postulacioneswwds_20_tfpostulacionesid_to",GXType.Decimal,18,0) ,
          new ParDef("@AV126Postulacioneswwds_21_tfserviciosid",GXType.Decimal,18,0) ,
          new ParDef("@AV127Postulacioneswwds_22_tfserviciosid_to",GXType.Decimal,18,0) ,
          new ParDef("@lV128Postulacioneswwds_23_tfserviciosnombre",GXType.Char,80,0) ,
          new ParDef("@AV129Postulacioneswwds_24_tfserviciosnombre_sel",GXType.NChar,80,0) ,
          new ParDef("@AV130Postulacioneswwds_25_tfpostulacionesproveedorid",GXType.Decimal,18,0) ,
          new ParDef("@AV131Postulacioneswwds_26_tfpostulacionesproveedorid_to",GXType.Decimal,18,0) ,
          new ParDef("@lV132Postulacioneswwds_27_tfpostulacionesproveedornombre",GXType.Char,80,0) ,
          new ParDef("@AV133Postulacioneswwds_28_tfpostulacionesproveedornombre_sel",GXType.NChar,80,0) ,
          new ParDef("@AV134Postulacioneswwds_29_tfpostulacionesprecio",GXType.Decimal,18,2) ,
          new ParDef("@AV135Postulacioneswwds_30_tfpostulacionesprecio_to",GXType.Decimal,18,2) ,
          new ParDef("@AV136Postulacioneswwds_31_tfpostulacionesmultimediaserial",GXType.Int16,4,0) ,
          new ParDef("@AV137Postulacioneswwds_32_tfpostulacionesmultimediaserial_to",GXType.Int16,4,0) ,
          new ParDef("@lV140Postulacioneswwds_35_tfpostulacionesdescripcion",GXType.Char,2000,0) ,
          new ParDef("@AV141Postulacioneswwds_36_tfpostulacionesdescripcion_sel",GXType.NChar,2000,0) ,
          new ParDef("@lV143Postulacioneswwds_38_tfpostulacionessuministrosdescripcion",GXType.Char,250,0) ,
          new ParDef("@AV144Postulacioneswwds_39_tfpostulacionessuministrosdescripcion_sel",GXType.NChar,250,0) ,
          new ParDef("@AV145Postulacioneswwds_40_tfpostulacionesfechatrabajo",GXType.Date,8,0) ,
          new ParDef("@AV146Postulacioneswwds_41_tfpostulacionesfechatrabajo_to",GXType.Date,8,0) ,
          new ParDef("@AV147Postulacioneswwds_42_tfpostulacionesfechacierre",GXType.Date,8,0) ,
          new ParDef("@AV148Postulacioneswwds_43_tfpostulacionesfechacierre_to",GXType.Date,8,0) ,
          new ParDef("@lV149Postulacioneswwds_44_tfpostulacioneshoracierre",GXType.VarChar,8,5) ,
          new ParDef("@AV150Postulacioneswwds_45_tfpostulacioneshoracierre_sel",GXType.NVarChar,8,5) ,
          new ParDef("@lV151Postulacioneswwds_46_tfpostulacionestipofecha",GXType.VarChar,10,0) ,
          new ParDef("@AV152Postulacioneswwds_47_tfpostulacionestipofecha_sel",GXType.NVarChar,10,0) ,
          new ParDef("@lV153Postulacioneswwds_48_tfpostulacionesrgohoraservicio",GXType.Char,5,0) ,
          new ParDef("@AV154Postulacioneswwds_49_tfpostulacionesrgohoraservicio_sel",GXType.NChar,5,0) ,
          new ParDef("@lV155Postulacioneswwds_50_tfpostulacionesapellidonombre",GXType.Char,80,0) ,
          new ParDef("@AV156Postulacioneswwds_51_tfpostulacionesapellidonombre_sel",GXType.NChar,80,0) ,
          new ParDef("@lV157Postulacioneswwds_52_tfpostulacionesmail",GXType.VarChar,100,0) ,
          new ParDef("@AV158Postulacioneswwds_53_tfpostulacionesmail_sel",GXType.NVarChar,100,0) ,
          new ParDef("@lV159Postulacioneswwds_54_tfpostulacionestelefono",GXType.Char,20,0) ,
          new ParDef("@AV160Postulacioneswwds_55_tfpostulacionestelefono_sel",GXType.NChar,20,0) ,
          new ParDef("@AV161Postulacioneswwds_56_tfpostulacionesfechaalta",GXType.DateTime,8,5) ,
          new ParDef("@AV162Postulacioneswwds_57_tfpostulacionesfechaalta_to",GXType.DateTime,8,5) ,
          new ParDef("@AV164Postulacioneswwds_59_tfpostulacionessecuserid",GXType.Decimal,18,0) ,
          new ParDef("@AV165Postulacioneswwds_60_tfpostulacionessecuserid_to",GXType.Decimal,18,0)
          };
          Object[] prmP00LA15;
          prmP00LA15 = new Object[] {
          new ParDef("@PostulacionesId",GXType.Decimal,18,0){Nullable=true} ,
          new ParDef("@AV138Postulacioneswwds_33_tfpostulacionessolicitudesid",GXType.Decimal,18,0) ,
          new ParDef("@AV138Postulacioneswwds_33_tfpostulacionessolicitudesid",GXType.Decimal,18,0) ,
          new ParDef("@AV139Postulacioneswwds_34_tfpostulacionessolicitudesid_to",GXType.Decimal,18,0) ,
          new ParDef("@AV139Postulacioneswwds_34_tfpostulacionessolicitudesid_to",GXType.Decimal,18,0) ,
          new ParDef("@lV109Postulacioneswwds_4_postulacionesproveedornombre1",GXType.Char,80,0) ,
          new ParDef("@lV109Postulacioneswwds_4_postulacionesproveedornombre1",GXType.Char,80,0) ,
          new ParDef("@AV110Postulacioneswwds_5_postulacionesproveedorid1",GXType.Decimal,18,0) ,
          new ParDef("@AV110Postulacioneswwds_5_postulacionesproveedorid1",GXType.Decimal,18,0) ,
          new ParDef("@AV110Postulacioneswwds_5_postulacionesproveedorid1",GXType.Decimal,18,0) ,
          new ParDef("@lV111Postulacioneswwds_6_serviciosnombre1",GXType.Char,80,0) ,
          new ParDef("@lV111Postulacioneswwds_6_serviciosnombre1",GXType.Char,80,0) ,
          new ParDef("@lV115Postulacioneswwds_10_postulacionesproveedornombre2",GXType.Char,80,0) ,
          new ParDef("@lV115Postulacioneswwds_10_postulacionesproveedornombre2",GXType.Char,80,0) ,
          new ParDef("@AV116Postulacioneswwds_11_postulacionesproveedorid2",GXType.Decimal,18,0) ,
          new ParDef("@AV116Postulacioneswwds_11_postulacionesproveedorid2",GXType.Decimal,18,0) ,
          new ParDef("@AV116Postulacioneswwds_11_postulacionesproveedorid2",GXType.Decimal,18,0) ,
          new ParDef("@lV117Postulacioneswwds_12_serviciosnombre2",GXType.Char,80,0) ,
          new ParDef("@lV117Postulacioneswwds_12_serviciosnombre2",GXType.Char,80,0) ,
          new ParDef("@lV121Postulacioneswwds_16_postulacionesproveedornombre3",GXType.Char,80,0) ,
          new ParDef("@lV121Postulacioneswwds_16_postulacionesproveedornombre3",GXType.Char,80,0) ,
          new ParDef("@AV122Postulacioneswwds_17_postulacionesproveedorid3",GXType.Decimal,18,0) ,
          new ParDef("@AV122Postulacioneswwds_17_postulacionesproveedorid3",GXType.Decimal,18,0) ,
          new ParDef("@AV122Postulacioneswwds_17_postulacionesproveedorid3",GXType.Decimal,18,0) ,
          new ParDef("@lV123Postulacioneswwds_18_serviciosnombre3",GXType.Char,80,0) ,
          new ParDef("@lV123Postulacioneswwds_18_serviciosnombre3",GXType.Char,80,0) ,
          new ParDef("@AV124Postulacioneswwds_19_tfpostulacionesid",GXType.Decimal,18,0) ,
          new ParDef("@AV125Postulacioneswwds_20_tfpostulacionesid_to",GXType.Decimal,18,0) ,
          new ParDef("@AV126Postulacioneswwds_21_tfserviciosid",GXType.Decimal,18,0) ,
          new ParDef("@AV127Postulacioneswwds_22_tfserviciosid_to",GXType.Decimal,18,0) ,
          new ParDef("@lV128Postulacioneswwds_23_tfserviciosnombre",GXType.Char,80,0) ,
          new ParDef("@AV129Postulacioneswwds_24_tfserviciosnombre_sel",GXType.NChar,80,0) ,
          new ParDef("@AV130Postulacioneswwds_25_tfpostulacionesproveedorid",GXType.Decimal,18,0) ,
          new ParDef("@AV131Postulacioneswwds_26_tfpostulacionesproveedorid_to",GXType.Decimal,18,0) ,
          new ParDef("@lV132Postulacioneswwds_27_tfpostulacionesproveedornombre",GXType.Char,80,0) ,
          new ParDef("@AV133Postulacioneswwds_28_tfpostulacionesproveedornombre_sel",GXType.NChar,80,0) ,
          new ParDef("@AV134Postulacioneswwds_29_tfpostulacionesprecio",GXType.Decimal,18,2) ,
          new ParDef("@AV135Postulacioneswwds_30_tfpostulacionesprecio_to",GXType.Decimal,18,2) ,
          new ParDef("@AV136Postulacioneswwds_31_tfpostulacionesmultimediaserial",GXType.Int16,4,0) ,
          new ParDef("@AV137Postulacioneswwds_32_tfpostulacionesmultimediaserial_to",GXType.Int16,4,0) ,
          new ParDef("@lV140Postulacioneswwds_35_tfpostulacionesdescripcion",GXType.Char,2000,0) ,
          new ParDef("@AV141Postulacioneswwds_36_tfpostulacionesdescripcion_sel",GXType.NChar,2000,0) ,
          new ParDef("@lV143Postulacioneswwds_38_tfpostulacionessuministrosdescripcion",GXType.Char,250,0) ,
          new ParDef("@AV144Postulacioneswwds_39_tfpostulacionessuministrosdescripcion_sel",GXType.NChar,250,0) ,
          new ParDef("@AV145Postulacioneswwds_40_tfpostulacionesfechatrabajo",GXType.Date,8,0) ,
          new ParDef("@AV146Postulacioneswwds_41_tfpostulacionesfechatrabajo_to",GXType.Date,8,0) ,
          new ParDef("@AV147Postulacioneswwds_42_tfpostulacionesfechacierre",GXType.Date,8,0) ,
          new ParDef("@AV148Postulacioneswwds_43_tfpostulacionesfechacierre_to",GXType.Date,8,0) ,
          new ParDef("@lV149Postulacioneswwds_44_tfpostulacioneshoracierre",GXType.VarChar,8,5) ,
          new ParDef("@AV150Postulacioneswwds_45_tfpostulacioneshoracierre_sel",GXType.NVarChar,8,5) ,
          new ParDef("@lV151Postulacioneswwds_46_tfpostulacionestipofecha",GXType.VarChar,10,0) ,
          new ParDef("@AV152Postulacioneswwds_47_tfpostulacionestipofecha_sel",GXType.NVarChar,10,0) ,
          new ParDef("@lV153Postulacioneswwds_48_tfpostulacionesrgohoraservicio",GXType.Char,5,0) ,
          new ParDef("@AV154Postulacioneswwds_49_tfpostulacionesrgohoraservicio_sel",GXType.NChar,5,0) ,
          new ParDef("@lV155Postulacioneswwds_50_tfpostulacionesapellidonombre",GXType.Char,80,0) ,
          new ParDef("@AV156Postulacioneswwds_51_tfpostulacionesapellidonombre_sel",GXType.NChar,80,0) ,
          new ParDef("@lV157Postulacioneswwds_52_tfpostulacionesmail",GXType.VarChar,100,0) ,
          new ParDef("@AV158Postulacioneswwds_53_tfpostulacionesmail_sel",GXType.NVarChar,100,0) ,
          new ParDef("@lV159Postulacioneswwds_54_tfpostulacionestelefono",GXType.Char,20,0) ,
          new ParDef("@AV160Postulacioneswwds_55_tfpostulacionestelefono_sel",GXType.NChar,20,0) ,
          new ParDef("@AV161Postulacioneswwds_56_tfpostulacionesfechaalta",GXType.DateTime,8,5) ,
          new ParDef("@AV162Postulacioneswwds_57_tfpostulacionesfechaalta_to",GXType.DateTime,8,5) ,
          new ParDef("@AV164Postulacioneswwds_59_tfpostulacionessecuserid",GXType.Decimal,18,0) ,
          new ParDef("@AV165Postulacioneswwds_60_tfpostulacionessecuserid_to",GXType.Decimal,18,0)
          };
          Object[] prmP00LA17;
          prmP00LA17 = new Object[] {
          new ParDef("@PostulacionesId",GXType.Decimal,18,0){Nullable=true} ,
          new ParDef("@AV138Postulacioneswwds_33_tfpostulacionessolicitudesid",GXType.Decimal,18,0) ,
          new ParDef("@AV138Postulacioneswwds_33_tfpostulacionessolicitudesid",GXType.Decimal,18,0) ,
          new ParDef("@AV139Postulacioneswwds_34_tfpostulacionessolicitudesid_to",GXType.Decimal,18,0) ,
          new ParDef("@AV139Postulacioneswwds_34_tfpostulacionessolicitudesid_to",GXType.Decimal,18,0) ,
          new ParDef("@lV109Postulacioneswwds_4_postulacionesproveedornombre1",GXType.Char,80,0) ,
          new ParDef("@lV109Postulacioneswwds_4_postulacionesproveedornombre1",GXType.Char,80,0) ,
          new ParDef("@AV110Postulacioneswwds_5_postulacionesproveedorid1",GXType.Decimal,18,0) ,
          new ParDef("@AV110Postulacioneswwds_5_postulacionesproveedorid1",GXType.Decimal,18,0) ,
          new ParDef("@AV110Postulacioneswwds_5_postulacionesproveedorid1",GXType.Decimal,18,0) ,
          new ParDef("@lV111Postulacioneswwds_6_serviciosnombre1",GXType.Char,80,0) ,
          new ParDef("@lV111Postulacioneswwds_6_serviciosnombre1",GXType.Char,80,0) ,
          new ParDef("@lV115Postulacioneswwds_10_postulacionesproveedornombre2",GXType.Char,80,0) ,
          new ParDef("@lV115Postulacioneswwds_10_postulacionesproveedornombre2",GXType.Char,80,0) ,
          new ParDef("@AV116Postulacioneswwds_11_postulacionesproveedorid2",GXType.Decimal,18,0) ,
          new ParDef("@AV116Postulacioneswwds_11_postulacionesproveedorid2",GXType.Decimal,18,0) ,
          new ParDef("@AV116Postulacioneswwds_11_postulacionesproveedorid2",GXType.Decimal,18,0) ,
          new ParDef("@lV117Postulacioneswwds_12_serviciosnombre2",GXType.Char,80,0) ,
          new ParDef("@lV117Postulacioneswwds_12_serviciosnombre2",GXType.Char,80,0) ,
          new ParDef("@lV121Postulacioneswwds_16_postulacionesproveedornombre3",GXType.Char,80,0) ,
          new ParDef("@lV121Postulacioneswwds_16_postulacionesproveedornombre3",GXType.Char,80,0) ,
          new ParDef("@AV122Postulacioneswwds_17_postulacionesproveedorid3",GXType.Decimal,18,0) ,
          new ParDef("@AV122Postulacioneswwds_17_postulacionesproveedorid3",GXType.Decimal,18,0) ,
          new ParDef("@AV122Postulacioneswwds_17_postulacionesproveedorid3",GXType.Decimal,18,0) ,
          new ParDef("@lV123Postulacioneswwds_18_serviciosnombre3",GXType.Char,80,0) ,
          new ParDef("@lV123Postulacioneswwds_18_serviciosnombre3",GXType.Char,80,0) ,
          new ParDef("@AV124Postulacioneswwds_19_tfpostulacionesid",GXType.Decimal,18,0) ,
          new ParDef("@AV125Postulacioneswwds_20_tfpostulacionesid_to",GXType.Decimal,18,0) ,
          new ParDef("@AV126Postulacioneswwds_21_tfserviciosid",GXType.Decimal,18,0) ,
          new ParDef("@AV127Postulacioneswwds_22_tfserviciosid_to",GXType.Decimal,18,0) ,
          new ParDef("@lV128Postulacioneswwds_23_tfserviciosnombre",GXType.Char,80,0) ,
          new ParDef("@AV129Postulacioneswwds_24_tfserviciosnombre_sel",GXType.NChar,80,0) ,
          new ParDef("@AV130Postulacioneswwds_25_tfpostulacionesproveedorid",GXType.Decimal,18,0) ,
          new ParDef("@AV131Postulacioneswwds_26_tfpostulacionesproveedorid_to",GXType.Decimal,18,0) ,
          new ParDef("@lV132Postulacioneswwds_27_tfpostulacionesproveedornombre",GXType.Char,80,0) ,
          new ParDef("@AV133Postulacioneswwds_28_tfpostulacionesproveedornombre_sel",GXType.NChar,80,0) ,
          new ParDef("@AV134Postulacioneswwds_29_tfpostulacionesprecio",GXType.Decimal,18,2) ,
          new ParDef("@AV135Postulacioneswwds_30_tfpostulacionesprecio_to",GXType.Decimal,18,2) ,
          new ParDef("@AV136Postulacioneswwds_31_tfpostulacionesmultimediaserial",GXType.Int16,4,0) ,
          new ParDef("@AV137Postulacioneswwds_32_tfpostulacionesmultimediaserial_to",GXType.Int16,4,0) ,
          new ParDef("@lV140Postulacioneswwds_35_tfpostulacionesdescripcion",GXType.Char,2000,0) ,
          new ParDef("@AV141Postulacioneswwds_36_tfpostulacionesdescripcion_sel",GXType.NChar,2000,0) ,
          new ParDef("@lV143Postulacioneswwds_38_tfpostulacionessuministrosdescripcion",GXType.Char,250,0) ,
          new ParDef("@AV144Postulacioneswwds_39_tfpostulacionessuministrosdescripcion_sel",GXType.NChar,250,0) ,
          new ParDef("@AV145Postulacioneswwds_40_tfpostulacionesfechatrabajo",GXType.Date,8,0) ,
          new ParDef("@AV146Postulacioneswwds_41_tfpostulacionesfechatrabajo_to",GXType.Date,8,0) ,
          new ParDef("@AV147Postulacioneswwds_42_tfpostulacionesfechacierre",GXType.Date,8,0) ,
          new ParDef("@AV148Postulacioneswwds_43_tfpostulacionesfechacierre_to",GXType.Date,8,0) ,
          new ParDef("@lV149Postulacioneswwds_44_tfpostulacioneshoracierre",GXType.VarChar,8,5) ,
          new ParDef("@AV150Postulacioneswwds_45_tfpostulacioneshoracierre_sel",GXType.NVarChar,8,5) ,
          new ParDef("@lV151Postulacioneswwds_46_tfpostulacionestipofecha",GXType.VarChar,10,0) ,
          new ParDef("@AV152Postulacioneswwds_47_tfpostulacionestipofecha_sel",GXType.NVarChar,10,0) ,
          new ParDef("@lV153Postulacioneswwds_48_tfpostulacionesrgohoraservicio",GXType.Char,5,0) ,
          new ParDef("@AV154Postulacioneswwds_49_tfpostulacionesrgohoraservicio_sel",GXType.NChar,5,0) ,
          new ParDef("@lV155Postulacioneswwds_50_tfpostulacionesapellidonombre",GXType.Char,80,0) ,
          new ParDef("@AV156Postulacioneswwds_51_tfpostulacionesapellidonombre_sel",GXType.NChar,80,0) ,
          new ParDef("@lV157Postulacioneswwds_52_tfpostulacionesmail",GXType.VarChar,100,0) ,
          new ParDef("@AV158Postulacioneswwds_53_tfpostulacionesmail_sel",GXType.NVarChar,100,0) ,
          new ParDef("@lV159Postulacioneswwds_54_tfpostulacionestelefono",GXType.Char,20,0) ,
          new ParDef("@AV160Postulacioneswwds_55_tfpostulacionestelefono_sel",GXType.NChar,20,0) ,
          new ParDef("@AV161Postulacioneswwds_56_tfpostulacionesfechaalta",GXType.DateTime,8,5) ,
          new ParDef("@AV162Postulacioneswwds_57_tfpostulacionesfechaalta_to",GXType.DateTime,8,5) ,
          new ParDef("@AV164Postulacioneswwds_59_tfpostulacionessecuserid",GXType.Decimal,18,0) ,
          new ParDef("@AV165Postulacioneswwds_60_tfpostulacionessecuserid_to",GXType.Decimal,18,0)
          };
          Object[] prmP00LA19;
          prmP00LA19 = new Object[] {
          new ParDef("@PostulacionesId",GXType.Decimal,18,0){Nullable=true} ,
          new ParDef("@AV138Postulacioneswwds_33_tfpostulacionessolicitudesid",GXType.Decimal,18,0) ,
          new ParDef("@AV138Postulacioneswwds_33_tfpostulacionessolicitudesid",GXType.Decimal,18,0) ,
          new ParDef("@AV139Postulacioneswwds_34_tfpostulacionessolicitudesid_to",GXType.Decimal,18,0) ,
          new ParDef("@AV139Postulacioneswwds_34_tfpostulacionessolicitudesid_to",GXType.Decimal,18,0) ,
          new ParDef("@lV109Postulacioneswwds_4_postulacionesproveedornombre1",GXType.Char,80,0) ,
          new ParDef("@lV109Postulacioneswwds_4_postulacionesproveedornombre1",GXType.Char,80,0) ,
          new ParDef("@AV110Postulacioneswwds_5_postulacionesproveedorid1",GXType.Decimal,18,0) ,
          new ParDef("@AV110Postulacioneswwds_5_postulacionesproveedorid1",GXType.Decimal,18,0) ,
          new ParDef("@AV110Postulacioneswwds_5_postulacionesproveedorid1",GXType.Decimal,18,0) ,
          new ParDef("@lV111Postulacioneswwds_6_serviciosnombre1",GXType.Char,80,0) ,
          new ParDef("@lV111Postulacioneswwds_6_serviciosnombre1",GXType.Char,80,0) ,
          new ParDef("@lV115Postulacioneswwds_10_postulacionesproveedornombre2",GXType.Char,80,0) ,
          new ParDef("@lV115Postulacioneswwds_10_postulacionesproveedornombre2",GXType.Char,80,0) ,
          new ParDef("@AV116Postulacioneswwds_11_postulacionesproveedorid2",GXType.Decimal,18,0) ,
          new ParDef("@AV116Postulacioneswwds_11_postulacionesproveedorid2",GXType.Decimal,18,0) ,
          new ParDef("@AV116Postulacioneswwds_11_postulacionesproveedorid2",GXType.Decimal,18,0) ,
          new ParDef("@lV117Postulacioneswwds_12_serviciosnombre2",GXType.Char,80,0) ,
          new ParDef("@lV117Postulacioneswwds_12_serviciosnombre2",GXType.Char,80,0) ,
          new ParDef("@lV121Postulacioneswwds_16_postulacionesproveedornombre3",GXType.Char,80,0) ,
          new ParDef("@lV121Postulacioneswwds_16_postulacionesproveedornombre3",GXType.Char,80,0) ,
          new ParDef("@AV122Postulacioneswwds_17_postulacionesproveedorid3",GXType.Decimal,18,0) ,
          new ParDef("@AV122Postulacioneswwds_17_postulacionesproveedorid3",GXType.Decimal,18,0) ,
          new ParDef("@AV122Postulacioneswwds_17_postulacionesproveedorid3",GXType.Decimal,18,0) ,
          new ParDef("@lV123Postulacioneswwds_18_serviciosnombre3",GXType.Char,80,0) ,
          new ParDef("@lV123Postulacioneswwds_18_serviciosnombre3",GXType.Char,80,0) ,
          new ParDef("@AV124Postulacioneswwds_19_tfpostulacionesid",GXType.Decimal,18,0) ,
          new ParDef("@AV125Postulacioneswwds_20_tfpostulacionesid_to",GXType.Decimal,18,0) ,
          new ParDef("@AV126Postulacioneswwds_21_tfserviciosid",GXType.Decimal,18,0) ,
          new ParDef("@AV127Postulacioneswwds_22_tfserviciosid_to",GXType.Decimal,18,0) ,
          new ParDef("@lV128Postulacioneswwds_23_tfserviciosnombre",GXType.Char,80,0) ,
          new ParDef("@AV129Postulacioneswwds_24_tfserviciosnombre_sel",GXType.NChar,80,0) ,
          new ParDef("@AV130Postulacioneswwds_25_tfpostulacionesproveedorid",GXType.Decimal,18,0) ,
          new ParDef("@AV131Postulacioneswwds_26_tfpostulacionesproveedorid_to",GXType.Decimal,18,0) ,
          new ParDef("@lV132Postulacioneswwds_27_tfpostulacionesproveedornombre",GXType.Char,80,0) ,
          new ParDef("@AV133Postulacioneswwds_28_tfpostulacionesproveedornombre_sel",GXType.NChar,80,0) ,
          new ParDef("@AV134Postulacioneswwds_29_tfpostulacionesprecio",GXType.Decimal,18,2) ,
          new ParDef("@AV135Postulacioneswwds_30_tfpostulacionesprecio_to",GXType.Decimal,18,2) ,
          new ParDef("@AV136Postulacioneswwds_31_tfpostulacionesmultimediaserial",GXType.Int16,4,0) ,
          new ParDef("@AV137Postulacioneswwds_32_tfpostulacionesmultimediaserial_to",GXType.Int16,4,0) ,
          new ParDef("@lV140Postulacioneswwds_35_tfpostulacionesdescripcion",GXType.Char,2000,0) ,
          new ParDef("@AV141Postulacioneswwds_36_tfpostulacionesdescripcion_sel",GXType.NChar,2000,0) ,
          new ParDef("@lV143Postulacioneswwds_38_tfpostulacionessuministrosdescripcion",GXType.Char,250,0) ,
          new ParDef("@AV144Postulacioneswwds_39_tfpostulacionessuministrosdescripcion_sel",GXType.NChar,250,0) ,
          new ParDef("@AV145Postulacioneswwds_40_tfpostulacionesfechatrabajo",GXType.Date,8,0) ,
          new ParDef("@AV146Postulacioneswwds_41_tfpostulacionesfechatrabajo_to",GXType.Date,8,0) ,
          new ParDef("@AV147Postulacioneswwds_42_tfpostulacionesfechacierre",GXType.Date,8,0) ,
          new ParDef("@AV148Postulacioneswwds_43_tfpostulacionesfechacierre_to",GXType.Date,8,0) ,
          new ParDef("@lV149Postulacioneswwds_44_tfpostulacioneshoracierre",GXType.VarChar,8,5) ,
          new ParDef("@AV150Postulacioneswwds_45_tfpostulacioneshoracierre_sel",GXType.NVarChar,8,5) ,
          new ParDef("@lV151Postulacioneswwds_46_tfpostulacionestipofecha",GXType.VarChar,10,0) ,
          new ParDef("@AV152Postulacioneswwds_47_tfpostulacionestipofecha_sel",GXType.NVarChar,10,0) ,
          new ParDef("@lV153Postulacioneswwds_48_tfpostulacionesrgohoraservicio",GXType.Char,5,0) ,
          new ParDef("@AV154Postulacioneswwds_49_tfpostulacionesrgohoraservicio_sel",GXType.NChar,5,0) ,
          new ParDef("@lV155Postulacioneswwds_50_tfpostulacionesapellidonombre",GXType.Char,80,0) ,
          new ParDef("@AV156Postulacioneswwds_51_tfpostulacionesapellidonombre_sel",GXType.NChar,80,0) ,
          new ParDef("@lV157Postulacioneswwds_52_tfpostulacionesmail",GXType.VarChar,100,0) ,
          new ParDef("@AV158Postulacioneswwds_53_tfpostulacionesmail_sel",GXType.NVarChar,100,0) ,
          new ParDef("@lV159Postulacioneswwds_54_tfpostulacionestelefono",GXType.Char,20,0) ,
          new ParDef("@AV160Postulacioneswwds_55_tfpostulacionestelefono_sel",GXType.NChar,20,0) ,
          new ParDef("@AV161Postulacioneswwds_56_tfpostulacionesfechaalta",GXType.DateTime,8,5) ,
          new ParDef("@AV162Postulacioneswwds_57_tfpostulacionesfechaalta_to",GXType.DateTime,8,5) ,
          new ParDef("@AV164Postulacioneswwds_59_tfpostulacionessecuserid",GXType.Decimal,18,0) ,
          new ParDef("@AV165Postulacioneswwds_60_tfpostulacionessecuserid_to",GXType.Decimal,18,0)
          };
          Object[] prmP00LA21;
          prmP00LA21 = new Object[] {
          new ParDef("@PostulacionesId",GXType.Decimal,18,0){Nullable=true} ,
          new ParDef("@AV138Postulacioneswwds_33_tfpostulacionessolicitudesid",GXType.Decimal,18,0) ,
          new ParDef("@AV138Postulacioneswwds_33_tfpostulacionessolicitudesid",GXType.Decimal,18,0) ,
          new ParDef("@AV139Postulacioneswwds_34_tfpostulacionessolicitudesid_to",GXType.Decimal,18,0) ,
          new ParDef("@AV139Postulacioneswwds_34_tfpostulacionessolicitudesid_to",GXType.Decimal,18,0) ,
          new ParDef("@lV109Postulacioneswwds_4_postulacionesproveedornombre1",GXType.Char,80,0) ,
          new ParDef("@lV109Postulacioneswwds_4_postulacionesproveedornombre1",GXType.Char,80,0) ,
          new ParDef("@AV110Postulacioneswwds_5_postulacionesproveedorid1",GXType.Decimal,18,0) ,
          new ParDef("@AV110Postulacioneswwds_5_postulacionesproveedorid1",GXType.Decimal,18,0) ,
          new ParDef("@AV110Postulacioneswwds_5_postulacionesproveedorid1",GXType.Decimal,18,0) ,
          new ParDef("@lV111Postulacioneswwds_6_serviciosnombre1",GXType.Char,80,0) ,
          new ParDef("@lV111Postulacioneswwds_6_serviciosnombre1",GXType.Char,80,0) ,
          new ParDef("@lV115Postulacioneswwds_10_postulacionesproveedornombre2",GXType.Char,80,0) ,
          new ParDef("@lV115Postulacioneswwds_10_postulacionesproveedornombre2",GXType.Char,80,0) ,
          new ParDef("@AV116Postulacioneswwds_11_postulacionesproveedorid2",GXType.Decimal,18,0) ,
          new ParDef("@AV116Postulacioneswwds_11_postulacionesproveedorid2",GXType.Decimal,18,0) ,
          new ParDef("@AV116Postulacioneswwds_11_postulacionesproveedorid2",GXType.Decimal,18,0) ,
          new ParDef("@lV117Postulacioneswwds_12_serviciosnombre2",GXType.Char,80,0) ,
          new ParDef("@lV117Postulacioneswwds_12_serviciosnombre2",GXType.Char,80,0) ,
          new ParDef("@lV121Postulacioneswwds_16_postulacionesproveedornombre3",GXType.Char,80,0) ,
          new ParDef("@lV121Postulacioneswwds_16_postulacionesproveedornombre3",GXType.Char,80,0) ,
          new ParDef("@AV122Postulacioneswwds_17_postulacionesproveedorid3",GXType.Decimal,18,0) ,
          new ParDef("@AV122Postulacioneswwds_17_postulacionesproveedorid3",GXType.Decimal,18,0) ,
          new ParDef("@AV122Postulacioneswwds_17_postulacionesproveedorid3",GXType.Decimal,18,0) ,
          new ParDef("@lV123Postulacioneswwds_18_serviciosnombre3",GXType.Char,80,0) ,
          new ParDef("@lV123Postulacioneswwds_18_serviciosnombre3",GXType.Char,80,0) ,
          new ParDef("@AV124Postulacioneswwds_19_tfpostulacionesid",GXType.Decimal,18,0) ,
          new ParDef("@AV125Postulacioneswwds_20_tfpostulacionesid_to",GXType.Decimal,18,0) ,
          new ParDef("@AV126Postulacioneswwds_21_tfserviciosid",GXType.Decimal,18,0) ,
          new ParDef("@AV127Postulacioneswwds_22_tfserviciosid_to",GXType.Decimal,18,0) ,
          new ParDef("@lV128Postulacioneswwds_23_tfserviciosnombre",GXType.Char,80,0) ,
          new ParDef("@AV129Postulacioneswwds_24_tfserviciosnombre_sel",GXType.NChar,80,0) ,
          new ParDef("@AV130Postulacioneswwds_25_tfpostulacionesproveedorid",GXType.Decimal,18,0) ,
          new ParDef("@AV131Postulacioneswwds_26_tfpostulacionesproveedorid_to",GXType.Decimal,18,0) ,
          new ParDef("@lV132Postulacioneswwds_27_tfpostulacionesproveedornombre",GXType.Char,80,0) ,
          new ParDef("@AV133Postulacioneswwds_28_tfpostulacionesproveedornombre_sel",GXType.NChar,80,0) ,
          new ParDef("@AV134Postulacioneswwds_29_tfpostulacionesprecio",GXType.Decimal,18,2) ,
          new ParDef("@AV135Postulacioneswwds_30_tfpostulacionesprecio_to",GXType.Decimal,18,2) ,
          new ParDef("@AV136Postulacioneswwds_31_tfpostulacionesmultimediaserial",GXType.Int16,4,0) ,
          new ParDef("@AV137Postulacioneswwds_32_tfpostulacionesmultimediaserial_to",GXType.Int16,4,0) ,
          new ParDef("@lV140Postulacioneswwds_35_tfpostulacionesdescripcion",GXType.Char,2000,0) ,
          new ParDef("@AV141Postulacioneswwds_36_tfpostulacionesdescripcion_sel",GXType.NChar,2000,0) ,
          new ParDef("@lV143Postulacioneswwds_38_tfpostulacionessuministrosdescripcion",GXType.Char,250,0) ,
          new ParDef("@AV144Postulacioneswwds_39_tfpostulacionessuministrosdescripcion_sel",GXType.NChar,250,0) ,
          new ParDef("@AV145Postulacioneswwds_40_tfpostulacionesfechatrabajo",GXType.Date,8,0) ,
          new ParDef("@AV146Postulacioneswwds_41_tfpostulacionesfechatrabajo_to",GXType.Date,8,0) ,
          new ParDef("@AV147Postulacioneswwds_42_tfpostulacionesfechacierre",GXType.Date,8,0) ,
          new ParDef("@AV148Postulacioneswwds_43_tfpostulacionesfechacierre_to",GXType.Date,8,0) ,
          new ParDef("@lV149Postulacioneswwds_44_tfpostulacioneshoracierre",GXType.VarChar,8,5) ,
          new ParDef("@AV150Postulacioneswwds_45_tfpostulacioneshoracierre_sel",GXType.NVarChar,8,5) ,
          new ParDef("@lV151Postulacioneswwds_46_tfpostulacionestipofecha",GXType.VarChar,10,0) ,
          new ParDef("@AV152Postulacioneswwds_47_tfpostulacionestipofecha_sel",GXType.NVarChar,10,0) ,
          new ParDef("@lV153Postulacioneswwds_48_tfpostulacionesrgohoraservicio",GXType.Char,5,0) ,
          new ParDef("@AV154Postulacioneswwds_49_tfpostulacionesrgohoraservicio_sel",GXType.NChar,5,0) ,
          new ParDef("@lV155Postulacioneswwds_50_tfpostulacionesapellidonombre",GXType.Char,80,0) ,
          new ParDef("@AV156Postulacioneswwds_51_tfpostulacionesapellidonombre_sel",GXType.NChar,80,0) ,
          new ParDef("@lV157Postulacioneswwds_52_tfpostulacionesmail",GXType.VarChar,100,0) ,
          new ParDef("@AV158Postulacioneswwds_53_tfpostulacionesmail_sel",GXType.NVarChar,100,0) ,
          new ParDef("@lV159Postulacioneswwds_54_tfpostulacionestelefono",GXType.Char,20,0) ,
          new ParDef("@AV160Postulacioneswwds_55_tfpostulacionestelefono_sel",GXType.NChar,20,0) ,
          new ParDef("@AV161Postulacioneswwds_56_tfpostulacionesfechaalta",GXType.DateTime,8,5) ,
          new ParDef("@AV162Postulacioneswwds_57_tfpostulacionesfechaalta_to",GXType.DateTime,8,5) ,
          new ParDef("@AV164Postulacioneswwds_59_tfpostulacionessecuserid",GXType.Decimal,18,0) ,
          new ParDef("@AV165Postulacioneswwds_60_tfpostulacionessecuserid_to",GXType.Decimal,18,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00LA3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00LA3,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00LA5", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00LA5,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00LA7", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00LA7,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00LA9", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00LA9,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00LA11", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00LA11,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00LA13", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00LA13,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00LA15", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00LA15,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00LA17", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00LA17,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00LA19", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00LA19,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00LA21", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00LA21,100, GxCacheFrequency.OFF ,true,false )
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
                ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(3);
                ((string[]) buf[4])[0] = rslt.getString(4, 20);
                ((string[]) buf[5])[0] = rslt.getVarchar(5);
                ((string[]) buf[6])[0] = rslt.getString(6, 80);
                ((string[]) buf[7])[0] = rslt.getString(7, 5);
                ((string[]) buf[8])[0] = rslt.getVarchar(8);
                ((string[]) buf[9])[0] = rslt.getVarchar(9);
                ((DateTime[]) buf[10])[0] = rslt.getGXDate(10);
                ((DateTime[]) buf[11])[0] = rslt.getGXDate(11);
                ((string[]) buf[12])[0] = rslt.getString(12, 250);
                ((bool[]) buf[13])[0] = rslt.getBool(13);
                ((string[]) buf[14])[0] = rslt.getString(14, 2000);
                ((short[]) buf[15])[0] = rslt.getShort(15);
                ((decimal[]) buf[16])[0] = rslt.getDecimal(16);
                ((string[]) buf[17])[0] = rslt.getString(17, 80);
                ((string[]) buf[18])[0] = rslt.getString(18, 80);
                ((long[]) buf[19])[0] = rslt.getLong(19);
                ((long[]) buf[20])[0] = rslt.getLong(20);
                ((string[]) buf[21])[0] = rslt.getString(21, 3);
                ((long[]) buf[22])[0] = rslt.getLong(22);
                ((bool[]) buf[23])[0] = rslt.wasNull(22);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((long[]) buf[1])[0] = rslt.getLong(2);
                ((DateTime[]) buf[2])[0] = rslt.getGXDateTime(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 20);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((string[]) buf[5])[0] = rslt.getString(6, 80);
                ((string[]) buf[6])[0] = rslt.getString(7, 5);
                ((string[]) buf[7])[0] = rslt.getVarchar(8);
                ((string[]) buf[8])[0] = rslt.getVarchar(9);
                ((DateTime[]) buf[9])[0] = rslt.getGXDate(10);
                ((DateTime[]) buf[10])[0] = rslt.getGXDate(11);
                ((string[]) buf[11])[0] = rslt.getString(12, 250);
                ((bool[]) buf[12])[0] = rslt.getBool(13);
                ((string[]) buf[13])[0] = rslt.getString(14, 2000);
                ((short[]) buf[14])[0] = rslt.getShort(15);
                ((decimal[]) buf[15])[0] = rslt.getDecimal(16);
                ((string[]) buf[16])[0] = rslt.getString(17, 80);
                ((string[]) buf[17])[0] = rslt.getString(18, 80);
                ((long[]) buf[18])[0] = rslt.getLong(19);
                ((bool[]) buf[19])[0] = rslt.wasNull(19);
                ((long[]) buf[20])[0] = rslt.getLong(20);
                ((string[]) buf[21])[0] = rslt.getString(21, 3);
                ((long[]) buf[22])[0] = rslt.getLong(22);
                ((bool[]) buf[23])[0] = rslt.wasNull(22);
                return;
             case 2 :
                ((string[]) buf[0])[0] = rslt.getString(1, 2000);
                ((long[]) buf[1])[0] = rslt.getLong(2);
                ((DateTime[]) buf[2])[0] = rslt.getGXDateTime(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 20);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((string[]) buf[5])[0] = rslt.getString(6, 80);
                ((string[]) buf[6])[0] = rslt.getString(7, 5);
                ((string[]) buf[7])[0] = rslt.getVarchar(8);
                ((string[]) buf[8])[0] = rslt.getVarchar(9);
                ((DateTime[]) buf[9])[0] = rslt.getGXDate(10);
                ((DateTime[]) buf[10])[0] = rslt.getGXDate(11);
                ((string[]) buf[11])[0] = rslt.getString(12, 250);
                ((bool[]) buf[12])[0] = rslt.getBool(13);
                ((short[]) buf[13])[0] = rslt.getShort(14);
                ((decimal[]) buf[14])[0] = rslt.getDecimal(15);
                ((string[]) buf[15])[0] = rslt.getString(16, 80);
                ((string[]) buf[16])[0] = rslt.getString(17, 80);
                ((long[]) buf[17])[0] = rslt.getLong(18);
                ((bool[]) buf[18])[0] = rslt.wasNull(18);
                ((long[]) buf[19])[0] = rslt.getLong(19);
                ((long[]) buf[20])[0] = rslt.getLong(20);
                ((string[]) buf[21])[0] = rslt.getString(21, 3);
                ((long[]) buf[22])[0] = rslt.getLong(22);
                ((bool[]) buf[23])[0] = rslt.wasNull(22);
                return;
             case 3 :
                ((string[]) buf[0])[0] = rslt.getString(1, 250);
                ((long[]) buf[1])[0] = rslt.getLong(2);
                ((DateTime[]) buf[2])[0] = rslt.getGXDateTime(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 20);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((string[]) buf[5])[0] = rslt.getString(6, 80);
                ((string[]) buf[6])[0] = rslt.getString(7, 5);
                ((string[]) buf[7])[0] = rslt.getVarchar(8);
                ((string[]) buf[8])[0] = rslt.getVarchar(9);
                ((DateTime[]) buf[9])[0] = rslt.getGXDate(10);
                ((DateTime[]) buf[10])[0] = rslt.getGXDate(11);
                ((bool[]) buf[11])[0] = rslt.getBool(12);
                ((string[]) buf[12])[0] = rslt.getString(13, 2000);
                ((short[]) buf[13])[0] = rslt.getShort(14);
                ((decimal[]) buf[14])[0] = rslt.getDecimal(15);
                ((string[]) buf[15])[0] = rslt.getString(16, 80);
                ((string[]) buf[16])[0] = rslt.getString(17, 80);
                ((long[]) buf[17])[0] = rslt.getLong(18);
                ((bool[]) buf[18])[0] = rslt.wasNull(18);
                ((long[]) buf[19])[0] = rslt.getLong(19);
                ((long[]) buf[20])[0] = rslt.getLong(20);
                ((string[]) buf[21])[0] = rslt.getString(21, 3);
                ((long[]) buf[22])[0] = rslt.getLong(22);
                ((bool[]) buf[23])[0] = rslt.wasNull(22);
                return;
             case 4 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((long[]) buf[1])[0] = rslt.getLong(2);
                ((DateTime[]) buf[2])[0] = rslt.getGXDateTime(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 20);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((string[]) buf[5])[0] = rslt.getString(6, 80);
                ((string[]) buf[6])[0] = rslt.getString(7, 5);
                ((string[]) buf[7])[0] = rslt.getVarchar(8);
                ((DateTime[]) buf[8])[0] = rslt.getGXDate(9);
                ((DateTime[]) buf[9])[0] = rslt.getGXDate(10);
                ((string[]) buf[10])[0] = rslt.getString(11, 250);
                ((bool[]) buf[11])[0] = rslt.getBool(12);
                ((string[]) buf[12])[0] = rslt.getString(13, 2000);
                ((short[]) buf[13])[0] = rslt.getShort(14);
                ((decimal[]) buf[14])[0] = rslt.getDecimal(15);
                ((string[]) buf[15])[0] = rslt.getString(16, 80);
                ((string[]) buf[16])[0] = rslt.getString(17, 80);
                ((long[]) buf[17])[0] = rslt.getLong(18);
                ((bool[]) buf[18])[0] = rslt.wasNull(18);
                ((long[]) buf[19])[0] = rslt.getLong(19);
                ((long[]) buf[20])[0] = rslt.getLong(20);
                ((string[]) buf[21])[0] = rslt.getString(21, 3);
                ((long[]) buf[22])[0] = rslt.getLong(22);
                ((bool[]) buf[23])[0] = rslt.wasNull(22);
                return;
             case 5 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((long[]) buf[1])[0] = rslt.getLong(2);
                ((DateTime[]) buf[2])[0] = rslt.getGXDateTime(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 20);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((string[]) buf[5])[0] = rslt.getString(6, 80);
                ((string[]) buf[6])[0] = rslt.getString(7, 5);
                ((string[]) buf[7])[0] = rslt.getVarchar(8);
                ((DateTime[]) buf[8])[0] = rslt.getGXDate(9);
                ((DateTime[]) buf[9])[0] = rslt.getGXDate(10);
                ((string[]) buf[10])[0] = rslt.getString(11, 250);
                ((bool[]) buf[11])[0] = rslt.getBool(12);
                ((string[]) buf[12])[0] = rslt.getString(13, 2000);
                ((short[]) buf[13])[0] = rslt.getShort(14);
                ((decimal[]) buf[14])[0] = rslt.getDecimal(15);
                ((string[]) buf[15])[0] = rslt.getString(16, 80);
                ((string[]) buf[16])[0] = rslt.getString(17, 80);
                ((long[]) buf[17])[0] = rslt.getLong(18);
                ((bool[]) buf[18])[0] = rslt.wasNull(18);
                ((long[]) buf[19])[0] = rslt.getLong(19);
                ((long[]) buf[20])[0] = rslt.getLong(20);
                ((string[]) buf[21])[0] = rslt.getString(21, 3);
                ((long[]) buf[22])[0] = rslt.getLong(22);
                ((bool[]) buf[23])[0] = rslt.wasNull(22);
                return;
             case 6 :
                ((string[]) buf[0])[0] = rslt.getString(1, 5);
                ((long[]) buf[1])[0] = rslt.getLong(2);
                ((DateTime[]) buf[2])[0] = rslt.getGXDateTime(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 20);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((string[]) buf[5])[0] = rslt.getString(6, 80);
                ((string[]) buf[6])[0] = rslt.getVarchar(7);
                ((string[]) buf[7])[0] = rslt.getVarchar(8);
                ((DateTime[]) buf[8])[0] = rslt.getGXDate(9);
                ((DateTime[]) buf[9])[0] = rslt.getGXDate(10);
                ((string[]) buf[10])[0] = rslt.getString(11, 250);
                ((bool[]) buf[11])[0] = rslt.getBool(12);
                ((string[]) buf[12])[0] = rslt.getString(13, 2000);
                ((short[]) buf[13])[0] = rslt.getShort(14);
                ((decimal[]) buf[14])[0] = rslt.getDecimal(15);
                ((string[]) buf[15])[0] = rslt.getString(16, 80);
                ((string[]) buf[16])[0] = rslt.getString(17, 80);
                ((long[]) buf[17])[0] = rslt.getLong(18);
                ((bool[]) buf[18])[0] = rslt.wasNull(18);
                ((long[]) buf[19])[0] = rslt.getLong(19);
                ((long[]) buf[20])[0] = rslt.getLong(20);
                ((string[]) buf[21])[0] = rslt.getString(21, 3);
                ((long[]) buf[22])[0] = rslt.getLong(22);
                ((bool[]) buf[23])[0] = rslt.wasNull(22);
                return;
             case 7 :
                ((string[]) buf[0])[0] = rslt.getString(1, 80);
                ((long[]) buf[1])[0] = rslt.getLong(2);
                ((DateTime[]) buf[2])[0] = rslt.getGXDateTime(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 20);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((string[]) buf[5])[0] = rslt.getString(6, 5);
                ((string[]) buf[6])[0] = rslt.getVarchar(7);
                ((string[]) buf[7])[0] = rslt.getVarchar(8);
                ((DateTime[]) buf[8])[0] = rslt.getGXDate(9);
                ((DateTime[]) buf[9])[0] = rslt.getGXDate(10);
                ((string[]) buf[10])[0] = rslt.getString(11, 250);
                ((bool[]) buf[11])[0] = rslt.getBool(12);
                ((string[]) buf[12])[0] = rslt.getString(13, 2000);
                ((short[]) buf[13])[0] = rslt.getShort(14);
                ((decimal[]) buf[14])[0] = rslt.getDecimal(15);
                ((string[]) buf[15])[0] = rslt.getString(16, 80);
                ((string[]) buf[16])[0] = rslt.getString(17, 80);
                ((long[]) buf[17])[0] = rslt.getLong(18);
                ((bool[]) buf[18])[0] = rslt.wasNull(18);
                ((long[]) buf[19])[0] = rslt.getLong(19);
                ((long[]) buf[20])[0] = rslt.getLong(20);
                ((string[]) buf[21])[0] = rslt.getString(21, 3);
                ((long[]) buf[22])[0] = rslt.getLong(22);
                ((bool[]) buf[23])[0] = rslt.wasNull(22);
                return;
             case 8 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((long[]) buf[1])[0] = rslt.getLong(2);
                ((DateTime[]) buf[2])[0] = rslt.getGXDateTime(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 20);
                ((string[]) buf[4])[0] = rslt.getString(5, 80);
                ((string[]) buf[5])[0] = rslt.getString(6, 5);
                ((string[]) buf[6])[0] = rslt.getVarchar(7);
                ((string[]) buf[7])[0] = rslt.getVarchar(8);
                ((DateTime[]) buf[8])[0] = rslt.getGXDate(9);
                ((DateTime[]) buf[9])[0] = rslt.getGXDate(10);
                ((string[]) buf[10])[0] = rslt.getString(11, 250);
                ((bool[]) buf[11])[0] = rslt.getBool(12);
                ((string[]) buf[12])[0] = rslt.getString(13, 2000);
                ((short[]) buf[13])[0] = rslt.getShort(14);
                ((decimal[]) buf[14])[0] = rslt.getDecimal(15);
                ((string[]) buf[15])[0] = rslt.getString(16, 80);
                ((string[]) buf[16])[0] = rslt.getString(17, 80);
                ((long[]) buf[17])[0] = rslt.getLong(18);
                ((bool[]) buf[18])[0] = rslt.wasNull(18);
                ((long[]) buf[19])[0] = rslt.getLong(19);
                ((long[]) buf[20])[0] = rslt.getLong(20);
                ((string[]) buf[21])[0] = rslt.getString(21, 3);
                ((long[]) buf[22])[0] = rslt.getLong(22);
                ((bool[]) buf[23])[0] = rslt.wasNull(22);
                return;
             case 9 :
                ((string[]) buf[0])[0] = rslt.getString(1, 20);
                ((long[]) buf[1])[0] = rslt.getLong(2);
                ((DateTime[]) buf[2])[0] = rslt.getGXDateTime(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((string[]) buf[4])[0] = rslt.getString(5, 80);
                ((string[]) buf[5])[0] = rslt.getString(6, 5);
                ((string[]) buf[6])[0] = rslt.getVarchar(7);
                ((string[]) buf[7])[0] = rslt.getVarchar(8);
                ((DateTime[]) buf[8])[0] = rslt.getGXDate(9);
                ((DateTime[]) buf[9])[0] = rslt.getGXDate(10);
                ((string[]) buf[10])[0] = rslt.getString(11, 250);
                ((bool[]) buf[11])[0] = rslt.getBool(12);
                ((string[]) buf[12])[0] = rslt.getString(13, 2000);
                ((short[]) buf[13])[0] = rslt.getShort(14);
                ((decimal[]) buf[14])[0] = rslt.getDecimal(15);
                ((string[]) buf[15])[0] = rslt.getString(16, 80);
                ((string[]) buf[16])[0] = rslt.getString(17, 80);
                ((long[]) buf[17])[0] = rslt.getLong(18);
                ((bool[]) buf[18])[0] = rslt.wasNull(18);
                ((long[]) buf[19])[0] = rslt.getLong(19);
                ((long[]) buf[20])[0] = rslt.getLong(20);
                ((string[]) buf[21])[0] = rslt.getString(21, 3);
                ((long[]) buf[22])[0] = rslt.getLong(22);
                ((bool[]) buf[23])[0] = rslt.wasNull(22);
                return;
       }
    }

 }

 [ServiceContract(Namespace = "GeneXus.Programs.postulacioneswwgetfilterdata_services")]
 [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple)]
 [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
 public class postulacioneswwgetfilterdata_services : GxRestService
 {
    [OperationContract(Name = "PostulacionesWWGetFilterData" )]
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
          if ( ! ProcessHeaders("postulacioneswwgetfilterdata") )
          {
             return  ;
          }
          postulacioneswwgetfilterdata worker = new postulacioneswwgetfilterdata(context);
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

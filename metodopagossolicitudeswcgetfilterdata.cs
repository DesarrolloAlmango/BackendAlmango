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
   public class metodopagossolicitudeswcgetfilterdata : GXProcedure
   {
      public metodopagossolicitudeswcgetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public metodopagossolicitudeswcgetfilterdata( IGxContext context )
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
         this.AV48DDOName = aP0_DDOName;
         this.AV49SearchTxtParms = aP1_SearchTxtParms;
         this.AV50SearchTxtTo = aP2_SearchTxtTo;
         this.AV51OptionsJson = "" ;
         this.AV52OptionsDescJson = "" ;
         this.AV53OptionIndexesJson = "" ;
         initialize();
         ExecutePrivate();
         aP3_OptionsJson=this.AV51OptionsJson;
         aP4_OptionsDescJson=this.AV52OptionsDescJson;
         aP5_OptionIndexesJson=this.AV53OptionIndexesJson;
      }

      public string executeUdp( string aP0_DDOName ,
                                string aP1_SearchTxtParms ,
                                string aP2_SearchTxtTo ,
                                out string aP3_OptionsJson ,
                                out string aP4_OptionsDescJson )
      {
         execute(aP0_DDOName, aP1_SearchTxtParms, aP2_SearchTxtTo, out aP3_OptionsJson, out aP4_OptionsDescJson, out aP5_OptionIndexesJson);
         return AV53OptionIndexesJson ;
      }

      public void executeSubmit( string aP0_DDOName ,
                                 string aP1_SearchTxtParms ,
                                 string aP2_SearchTxtTo ,
                                 out string aP3_OptionsJson ,
                                 out string aP4_OptionsDescJson ,
                                 out string aP5_OptionIndexesJson )
      {
         this.AV48DDOName = aP0_DDOName;
         this.AV49SearchTxtParms = aP1_SearchTxtParms;
         this.AV50SearchTxtTo = aP2_SearchTxtTo;
         this.AV51OptionsJson = "" ;
         this.AV52OptionsDescJson = "" ;
         this.AV53OptionIndexesJson = "" ;
         SubmitImpl();
         aP3_OptionsJson=this.AV51OptionsJson;
         aP4_OptionsDescJson=this.AV52OptionsDescJson;
         aP5_OptionIndexesJson=this.AV53OptionIndexesJson;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV38Options = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV40OptionsDesc = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV41OptionIndexes = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         GXt_boolean1 = AV8IsAuthorized;
         new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWSolicitudes", out  GXt_boolean1) ;
         AV8IsAuthorized = GXt_boolean1;
         if ( AV8IsAuthorized )
         {
            AV35MaxItems = 10;
            AV34PageIndex = (short)((String.IsNullOrEmpty(StringUtil.RTrim( AV49SearchTxtParms)) ? 0 : (long)(Math.Round(NumberUtil.Val( StringUtil.Substring( AV49SearchTxtParms, 1, 2), "."), 18, MidpointRounding.ToEven))));
            AV32SearchTxt = (String.IsNullOrEmpty(StringUtil.RTrim( AV49SearchTxtParms)) ? "" : StringUtil.Substring( AV49SearchTxtParms, 3, -1));
            AV33SkipItems = (short)(AV34PageIndex*AV35MaxItems);
            new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV9WWPContext) ;
            /* Execute user subroutine: 'LOADGRIDSTATE' */
            S111 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
            if ( StringUtil.StrCmp(StringUtil.Upper( AV48DDOName), "DDO_SOLICITUDESNOMBRE") == 0 )
            {
               /* Execute user subroutine: 'LOADSOLICITUDESNOMBREOPTIONS' */
               S121 ();
               if ( returnInSub )
               {
                  cleanup();
                  if (true) return;
               }
            }
            else if ( StringUtil.StrCmp(StringUtil.Upper( AV48DDOName), "DDO_SOLICITUDESTELEFONO") == 0 )
            {
               /* Execute user subroutine: 'LOADSOLICITUDESTELEFONOOPTIONS' */
               S131 ();
               if ( returnInSub )
               {
                  cleanup();
                  if (true) return;
               }
            }
            else if ( StringUtil.StrCmp(StringUtil.Upper( AV48DDOName), "DDO_SOLICITUDESMAIL") == 0 )
            {
               /* Execute user subroutine: 'LOADSOLICITUDESMAILOPTIONS' */
               S141 ();
               if ( returnInSub )
               {
                  cleanup();
                  if (true) return;
               }
            }
            else if ( StringUtil.StrCmp(StringUtil.Upper( AV48DDOName), "DDO_SOLICITUDESDIRECCION") == 0 )
            {
               /* Execute user subroutine: 'LOADSOLICITUDESDIRECCIONOPTIONS' */
               S151 ();
               if ( returnInSub )
               {
                  cleanup();
                  if (true) return;
               }
            }
         }
         AV51OptionsJson = AV38Options.ToJSonString(false);
         AV52OptionsDescJson = AV40OptionsDesc.ToJSonString(false);
         AV53OptionIndexesJson = AV41OptionIndexes.ToJSonString(false);
         cleanup();
      }

      protected void S111( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV43Session.Get("MetodoPagosSolicitudesWCGridState"), "") == 0 )
         {
            AV45GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "MetodoPagosSolicitudesWCGridState"), null, "", "");
         }
         else
         {
            AV45GridState.FromXml(AV43Session.Get("MetodoPagosSolicitudesWCGridState"), null, "", "");
         }
         AV56GXV1 = 1;
         while ( AV56GXV1 <= AV45GridState.gxTpr_Filtervalues.Count )
         {
            AV46GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV45GridState.gxTpr_Filtervalues.Item(AV56GXV1));
            if ( StringUtil.StrCmp(AV46GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV54FilterFullText = AV46GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV46GridStateFilterValue.gxTpr_Name, "TFSOLICITUDESID") == 0 )
            {
               AV11TFSolicitudesID = (long)(Math.Round(NumberUtil.Val( AV46GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV12TFSolicitudesID_To = (long)(Math.Round(NumberUtil.Val( AV46GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV46GridStateFilterValue.gxTpr_Name, "TFSOLICITUDESNOMBRE") == 0 )
            {
               AV13TFSolicitudesNombre = AV46GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV46GridStateFilterValue.gxTpr_Name, "TFSOLICITUDESNOMBRE_SEL") == 0 )
            {
               AV14TFSolicitudesNombre_Sel = AV46GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV46GridStateFilterValue.gxTpr_Name, "TFSOLICITUDESTELEFONO") == 0 )
            {
               AV15TFSolicitudesTelefono = AV46GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV46GridStateFilterValue.gxTpr_Name, "TFSOLICITUDESTELEFONO_SEL") == 0 )
            {
               AV16TFSolicitudesTelefono_Sel = AV46GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV46GridStateFilterValue.gxTpr_Name, "TFSOLICITUDESMAIL") == 0 )
            {
               AV17TFSolicitudesMail = AV46GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV46GridStateFilterValue.gxTpr_Name, "TFSOLICITUDESMAIL_SEL") == 0 )
            {
               AV18TFSolicitudesMail_Sel = AV46GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV46GridStateFilterValue.gxTpr_Name, "TFDEPARTAMENTOID") == 0 )
            {
               AV19TFDepartamentoId = (long)(Math.Round(NumberUtil.Val( AV46GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV20TFDepartamentoId_To = (long)(Math.Round(NumberUtil.Val( AV46GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV46GridStateFilterValue.gxTpr_Name, "TFDEPARTAMENTOMUNICIPIOID") == 0 )
            {
               AV21TFDepartamentoMunicipioId = (long)(Math.Round(NumberUtil.Val( AV46GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV22TFDepartamentoMunicipioId_To = (long)(Math.Round(NumberUtil.Val( AV46GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV46GridStateFilterValue.gxTpr_Name, "TFZONASID") == 0 )
            {
               AV23TFZonasID = (long)(Math.Round(NumberUtil.Val( AV46GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV24TFZonasID_To = (long)(Math.Round(NumberUtil.Val( AV46GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV46GridStateFilterValue.gxTpr_Name, "TFSOLICITUDESDIRECCION") == 0 )
            {
               AV25TFSolicitudesDireccion = AV46GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV46GridStateFilterValue.gxTpr_Name, "TFSOLICITUDESDIRECCION_SEL") == 0 )
            {
               AV26TFSolicitudesDireccion_Sel = AV46GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV46GridStateFilterValue.gxTpr_Name, "TFSOLICITUDESTOTAL") == 0 )
            {
               AV27TFSolicitudesTotal = NumberUtil.Val( AV46GridStateFilterValue.gxTpr_Value, ".");
               AV28TFSolicitudesTotal_To = NumberUtil.Val( AV46GridStateFilterValue.gxTpr_Valueto, ".");
            }
            else if ( StringUtil.StrCmp(AV46GridStateFilterValue.gxTpr_Name, "TFSOLICITUDSERVICIOSOLCOTI_SEL") == 0 )
            {
               AV29TFSolicitudServicioSolCoti_Sel = AV46GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV46GridStateFilterValue.gxTpr_Name, "TFSOLICITUDSERVICIOPFINAL") == 0 )
            {
               AV30TFSolicitudServicioPFinal = NumberUtil.Val( AV46GridStateFilterValue.gxTpr_Value, ".");
               AV31TFSolicitudServicioPFinal_To = NumberUtil.Val( AV46GridStateFilterValue.gxTpr_Valueto, ".");
            }
            else if ( StringUtil.StrCmp(AV46GridStateFilterValue.gxTpr_Name, "PARM_&METODOPAGOSID") == 0 )
            {
               AV55MetodoPagosID = (long)(Math.Round(NumberUtil.Val( AV46GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
            }
            AV56GXV1 = (int)(AV56GXV1+1);
         }
      }

      protected void S121( )
      {
         /* 'LOADSOLICITUDESNOMBREOPTIONS' Routine */
         returnInSub = false;
         AV13TFSolicitudesNombre = AV32SearchTxt;
         AV14TFSolicitudesNombre_Sel = "";
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV11TFSolicitudesID ,
                                              AV12TFSolicitudesID_To ,
                                              AV14TFSolicitudesNombre_Sel ,
                                              AV13TFSolicitudesNombre ,
                                              AV16TFSolicitudesTelefono_Sel ,
                                              AV15TFSolicitudesTelefono ,
                                              AV18TFSolicitudesMail_Sel ,
                                              AV17TFSolicitudesMail ,
                                              AV19TFDepartamentoId ,
                                              AV20TFDepartamentoId_To ,
                                              AV21TFDepartamentoMunicipioId ,
                                              AV22TFDepartamentoMunicipioId_To ,
                                              AV23TFZonasID ,
                                              AV24TFZonasID_To ,
                                              AV26TFSolicitudesDireccion_Sel ,
                                              AV25TFSolicitudesDireccion ,
                                              AV27TFSolicitudesTotal ,
                                              AV28TFSolicitudesTotal_To ,
                                              AV29TFSolicitudServicioSolCoti_Sel ,
                                              A127SolicitudesID ,
                                              A171SolicitudesNombre ,
                                              A172SolicitudesTelefono ,
                                              A206SolicitudesMail ,
                                              A112DepartamentoId ,
                                              A114DepartamentoMunicipioId ,
                                              A110ZonasID ,
                                              A173SolicitudesDireccion ,
                                              A174SolicitudesTotal ,
                                              A210SolicitudServicioSolCoti ,
                                              AV54FilterFullText ,
                                              A211SolicitudServicioPFinal ,
                                              AV30TFSolicitudServicioPFinal ,
                                              AV31TFSolicitudServicioPFinal_To ,
                                              AV55MetodoPagosID ,
                                              A128MetodoPagosID } ,
                                              new int[]{
                                              TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.DECIMAL, TypeConstants.DECIMAL,
                                              TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.DECIMAL,
                                              TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.LONG, TypeConstants.LONG
                                              }
         });
         lV13TFSolicitudesNombre = StringUtil.PadR( StringUtil.RTrim( AV13TFSolicitudesNombre), 100, "%");
         lV15TFSolicitudesTelefono = StringUtil.PadR( StringUtil.RTrim( AV15TFSolicitudesTelefono), 20, "%");
         lV17TFSolicitudesMail = StringUtil.Concat( StringUtil.RTrim( AV17TFSolicitudesMail), "%", "");
         lV25TFSolicitudesDireccion = StringUtil.Concat( StringUtil.RTrim( AV25TFSolicitudesDireccion), "%", "");
         /* Using cursor P004J2 */
         pr_default.execute(0, new Object[] {AV55MetodoPagosID, AV11TFSolicitudesID, AV12TFSolicitudesID_To, lV13TFSolicitudesNombre, AV14TFSolicitudesNombre_Sel, lV15TFSolicitudesTelefono, AV16TFSolicitudesTelefono_Sel, lV17TFSolicitudesMail, AV18TFSolicitudesMail_Sel, AV19TFDepartamentoId, AV20TFDepartamentoId_To, AV21TFDepartamentoMunicipioId, AV22TFDepartamentoMunicipioId_To, AV23TFZonasID, AV24TFZonasID_To, lV25TFSolicitudesDireccion, AV26TFSolicitudesDireccion_Sel, AV29TFSolicitudServicioSolCoti_Sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRK4J2 = false;
            A128MetodoPagosID = P004J2_A128MetodoPagosID[0];
            A171SolicitudesNombre = P004J2_A171SolicitudesNombre[0];
            A210SolicitudServicioSolCoti = P004J2_A210SolicitudServicioSolCoti[0];
            A173SolicitudesDireccion = P004J2_A173SolicitudesDireccion[0];
            A110ZonasID = P004J2_A110ZonasID[0];
            n110ZonasID = P004J2_n110ZonasID[0];
            A114DepartamentoMunicipioId = P004J2_A114DepartamentoMunicipioId[0];
            n114DepartamentoMunicipioId = P004J2_n114DepartamentoMunicipioId[0];
            A112DepartamentoId = P004J2_A112DepartamentoId[0];
            n112DepartamentoId = P004J2_n112DepartamentoId[0];
            A206SolicitudesMail = P004J2_A206SolicitudesMail[0];
            n206SolicitudesMail = P004J2_n206SolicitudesMail[0];
            A172SolicitudesTelefono = P004J2_A172SolicitudesTelefono[0];
            A127SolicitudesID = P004J2_A127SolicitudesID[0];
            A796SolicitudesComisionMetodoPago = P004J2_A796SolicitudesComisionMetodoPago[0];
            A212SolicitudesCotizacion = P004J2_A212SolicitudesCotizacion[0];
            A1016SolicitudesDescuentoCupon = P004J2_A1016SolicitudesDescuentoCupon[0];
            A897SolicitudesDescuento = P004J2_A897SolicitudesDescuento[0];
            n897SolicitudesDescuento = P004J2_n897SolicitudesDescuento[0];
            A864SolicitudesCostoXZona = P004J2_A864SolicitudesCostoXZona[0];
            GetSolicitudesTotal( A127SolicitudesID) ;
            if ( ( A212SolicitudesCotizacion == Convert.ToDecimal( 0 )) && ( A796SolicitudesComisionMetodoPago <= Convert.ToDecimal( 0 )) )
            {
               A211SolicitudServicioPFinal = (decimal)(A174SolicitudesTotal+A864SolicitudesCostoXZona-A897SolicitudesDescuento-A1016SolicitudesDescuentoCupon);
            }
            else
            {
               if ( ( A212SolicitudesCotizacion > Convert.ToDecimal( 0 )) && ( A796SolicitudesComisionMetodoPago <= Convert.ToDecimal( 0 )) )
               {
                  A211SolicitudServicioPFinal = (decimal)(A212SolicitudesCotizacion+A864SolicitudesCostoXZona-A897SolicitudesDescuento-A1016SolicitudesDescuentoCupon);
               }
               else
               {
                  if ( ( A212SolicitudesCotizacion == Convert.ToDecimal( 0 )) && ( A796SolicitudesComisionMetodoPago > Convert.ToDecimal( 0 )) )
                  {
                     A211SolicitudServicioPFinal = (decimal)(A174SolicitudesTotal+A864SolicitudesCostoXZona-A897SolicitudesDescuento-A1016SolicitudesDescuentoCupon-A796SolicitudesComisionMetodoPago);
                  }
                  else
                  {
                     if ( ( A212SolicitudesCotizacion > Convert.ToDecimal( 0 )) && ( A796SolicitudesComisionMetodoPago > Convert.ToDecimal( 0 )) )
                     {
                        A211SolicitudServicioPFinal = (decimal)(A212SolicitudesCotizacion+A864SolicitudesCostoXZona-A796SolicitudesComisionMetodoPago-A897SolicitudesDescuento-A1016SolicitudesDescuentoCupon);
                     }
                     else
                     {
                        A211SolicitudServicioPFinal = 0;
                     }
                  }
               }
            }
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV54FilterFullText)) || ( ( StringUtil.Like( StringUtil.Str( (decimal)(A127SolicitudesID), 18, 0) , StringUtil.PadR( "%" + AV54FilterFullText , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A171SolicitudesNombre) , StringUtil.PadR( "%" + StringUtil.Upper( AV54FilterFullText) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A172SolicitudesTelefono) , StringUtil.PadR( "%" + StringUtil.Upper( AV54FilterFullText) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A206SolicitudesMail) , StringUtil.PadR( "%" + StringUtil.Upper( AV54FilterFullText) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Str( (decimal)(A112DepartamentoId), 18, 0) , StringUtil.PadR( "%" + AV54FilterFullText , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Str( (decimal)(A114DepartamentoMunicipioId), 18, 0) , StringUtil.PadR( "%" + AV54FilterFullText , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Str( (decimal)(A110ZonasID), 18, 0) , StringUtil.PadR( "%" + AV54FilterFullText , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A173SolicitudesDireccion) , StringUtil.PadR( "%" + StringUtil.Upper( AV54FilterFullText) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Str( A174SolicitudesTotal, 18, 2) , StringUtil.PadR( "%" + AV54FilterFullText , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Str( A211SolicitudServicioPFinal, 18, 2) , StringUtil.PadR( "%" + AV54FilterFullText , 254 , "%"),  ' ' ) ) ) )
            {
               if ( (Convert.ToDecimal(0)==AV30TFSolicitudServicioPFinal) || ( ( A211SolicitudServicioPFinal >= AV30TFSolicitudServicioPFinal ) ) )
               {
                  if ( (Convert.ToDecimal(0)==AV31TFSolicitudServicioPFinal_To) || ( ( A211SolicitudServicioPFinal <= AV31TFSolicitudServicioPFinal_To ) ) )
                  {
                     AV42count = 0;
                     while ( (pr_default.getStatus(0) != 101) && ( P004J2_A128MetodoPagosID[0] == A128MetodoPagosID ) && ( StringUtil.StrCmp(P004J2_A171SolicitudesNombre[0], A171SolicitudesNombre) == 0 ) )
                     {
                        BRK4J2 = false;
                        A127SolicitudesID = P004J2_A127SolicitudesID[0];
                        AV42count = (long)(AV42count+1);
                        BRK4J2 = true;
                        pr_default.readNext(0);
                     }
                     if ( (0==AV33SkipItems) )
                     {
                        AV37Option = (String.IsNullOrEmpty(StringUtil.RTrim( A171SolicitudesNombre)) ? "<#Empty#>" : A171SolicitudesNombre);
                        AV38Options.Add(AV37Option, 0);
                        AV41OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV42count), "Z,ZZZ,ZZZ,ZZ9")), 0);
                        if ( AV38Options.Count == 10 )
                        {
                           /* Exit For each command. Update data (if necessary), close cursors & exit. */
                           if (true) break;
                        }
                     }
                     else
                     {
                        AV33SkipItems = (short)(AV33SkipItems-1);
                     }
                  }
               }
            }
            if ( ! BRK4J2 )
            {
               BRK4J2 = true;
               pr_default.readNext(0);
            }
         }
         pr_default.close(0);
      }

      protected void S131( )
      {
         /* 'LOADSOLICITUDESTELEFONOOPTIONS' Routine */
         returnInSub = false;
         AV15TFSolicitudesTelefono = AV32SearchTxt;
         AV16TFSolicitudesTelefono_Sel = "";
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              AV11TFSolicitudesID ,
                                              AV12TFSolicitudesID_To ,
                                              AV14TFSolicitudesNombre_Sel ,
                                              AV13TFSolicitudesNombre ,
                                              AV16TFSolicitudesTelefono_Sel ,
                                              AV15TFSolicitudesTelefono ,
                                              AV18TFSolicitudesMail_Sel ,
                                              AV17TFSolicitudesMail ,
                                              AV19TFDepartamentoId ,
                                              AV20TFDepartamentoId_To ,
                                              AV21TFDepartamentoMunicipioId ,
                                              AV22TFDepartamentoMunicipioId_To ,
                                              AV23TFZonasID ,
                                              AV24TFZonasID_To ,
                                              AV26TFSolicitudesDireccion_Sel ,
                                              AV25TFSolicitudesDireccion ,
                                              AV27TFSolicitudesTotal ,
                                              AV28TFSolicitudesTotal_To ,
                                              AV29TFSolicitudServicioSolCoti_Sel ,
                                              A127SolicitudesID ,
                                              A171SolicitudesNombre ,
                                              A172SolicitudesTelefono ,
                                              A206SolicitudesMail ,
                                              A112DepartamentoId ,
                                              A114DepartamentoMunicipioId ,
                                              A110ZonasID ,
                                              A173SolicitudesDireccion ,
                                              A174SolicitudesTotal ,
                                              A210SolicitudServicioSolCoti ,
                                              AV54FilterFullText ,
                                              A211SolicitudServicioPFinal ,
                                              AV30TFSolicitudServicioPFinal ,
                                              AV31TFSolicitudServicioPFinal_To ,
                                              AV55MetodoPagosID ,
                                              A128MetodoPagosID } ,
                                              new int[]{
                                              TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.DECIMAL, TypeConstants.DECIMAL,
                                              TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.DECIMAL,
                                              TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.LONG, TypeConstants.LONG
                                              }
         });
         lV13TFSolicitudesNombre = StringUtil.PadR( StringUtil.RTrim( AV13TFSolicitudesNombre), 100, "%");
         lV15TFSolicitudesTelefono = StringUtil.PadR( StringUtil.RTrim( AV15TFSolicitudesTelefono), 20, "%");
         lV17TFSolicitudesMail = StringUtil.Concat( StringUtil.RTrim( AV17TFSolicitudesMail), "%", "");
         lV25TFSolicitudesDireccion = StringUtil.Concat( StringUtil.RTrim( AV25TFSolicitudesDireccion), "%", "");
         /* Using cursor P004J3 */
         pr_default.execute(1, new Object[] {AV55MetodoPagosID, AV11TFSolicitudesID, AV12TFSolicitudesID_To, lV13TFSolicitudesNombre, AV14TFSolicitudesNombre_Sel, lV15TFSolicitudesTelefono, AV16TFSolicitudesTelefono_Sel, lV17TFSolicitudesMail, AV18TFSolicitudesMail_Sel, AV19TFDepartamentoId, AV20TFDepartamentoId_To, AV21TFDepartamentoMunicipioId, AV22TFDepartamentoMunicipioId_To, AV23TFZonasID, AV24TFZonasID_To, lV25TFSolicitudesDireccion, AV26TFSolicitudesDireccion_Sel, AV29TFSolicitudServicioSolCoti_Sel});
         while ( (pr_default.getStatus(1) != 101) )
         {
            BRK4J4 = false;
            A128MetodoPagosID = P004J3_A128MetodoPagosID[0];
            A172SolicitudesTelefono = P004J3_A172SolicitudesTelefono[0];
            A210SolicitudServicioSolCoti = P004J3_A210SolicitudServicioSolCoti[0];
            A173SolicitudesDireccion = P004J3_A173SolicitudesDireccion[0];
            A110ZonasID = P004J3_A110ZonasID[0];
            n110ZonasID = P004J3_n110ZonasID[0];
            A114DepartamentoMunicipioId = P004J3_A114DepartamentoMunicipioId[0];
            n114DepartamentoMunicipioId = P004J3_n114DepartamentoMunicipioId[0];
            A112DepartamentoId = P004J3_A112DepartamentoId[0];
            n112DepartamentoId = P004J3_n112DepartamentoId[0];
            A206SolicitudesMail = P004J3_A206SolicitudesMail[0];
            n206SolicitudesMail = P004J3_n206SolicitudesMail[0];
            A171SolicitudesNombre = P004J3_A171SolicitudesNombre[0];
            A127SolicitudesID = P004J3_A127SolicitudesID[0];
            A796SolicitudesComisionMetodoPago = P004J3_A796SolicitudesComisionMetodoPago[0];
            A212SolicitudesCotizacion = P004J3_A212SolicitudesCotizacion[0];
            A1016SolicitudesDescuentoCupon = P004J3_A1016SolicitudesDescuentoCupon[0];
            A897SolicitudesDescuento = P004J3_A897SolicitudesDescuento[0];
            n897SolicitudesDescuento = P004J3_n897SolicitudesDescuento[0];
            A864SolicitudesCostoXZona = P004J3_A864SolicitudesCostoXZona[0];
            GetSolicitudesTotal( A127SolicitudesID) ;
            if ( ( A212SolicitudesCotizacion == Convert.ToDecimal( 0 )) && ( A796SolicitudesComisionMetodoPago <= Convert.ToDecimal( 0 )) )
            {
               A211SolicitudServicioPFinal = (decimal)(A174SolicitudesTotal+A864SolicitudesCostoXZona-A897SolicitudesDescuento-A1016SolicitudesDescuentoCupon);
            }
            else
            {
               if ( ( A212SolicitudesCotizacion > Convert.ToDecimal( 0 )) && ( A796SolicitudesComisionMetodoPago <= Convert.ToDecimal( 0 )) )
               {
                  A211SolicitudServicioPFinal = (decimal)(A212SolicitudesCotizacion+A864SolicitudesCostoXZona-A897SolicitudesDescuento-A1016SolicitudesDescuentoCupon);
               }
               else
               {
                  if ( ( A212SolicitudesCotizacion == Convert.ToDecimal( 0 )) && ( A796SolicitudesComisionMetodoPago > Convert.ToDecimal( 0 )) )
                  {
                     A211SolicitudServicioPFinal = (decimal)(A174SolicitudesTotal+A864SolicitudesCostoXZona-A897SolicitudesDescuento-A1016SolicitudesDescuentoCupon-A796SolicitudesComisionMetodoPago);
                  }
                  else
                  {
                     if ( ( A212SolicitudesCotizacion > Convert.ToDecimal( 0 )) && ( A796SolicitudesComisionMetodoPago > Convert.ToDecimal( 0 )) )
                     {
                        A211SolicitudServicioPFinal = (decimal)(A212SolicitudesCotizacion+A864SolicitudesCostoXZona-A796SolicitudesComisionMetodoPago-A897SolicitudesDescuento-A1016SolicitudesDescuentoCupon);
                     }
                     else
                     {
                        A211SolicitudServicioPFinal = 0;
                     }
                  }
               }
            }
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV54FilterFullText)) || ( ( StringUtil.Like( StringUtil.Str( (decimal)(A127SolicitudesID), 18, 0) , StringUtil.PadR( "%" + AV54FilterFullText , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A171SolicitudesNombre) , StringUtil.PadR( "%" + StringUtil.Upper( AV54FilterFullText) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A172SolicitudesTelefono) , StringUtil.PadR( "%" + StringUtil.Upper( AV54FilterFullText) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A206SolicitudesMail) , StringUtil.PadR( "%" + StringUtil.Upper( AV54FilterFullText) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Str( (decimal)(A112DepartamentoId), 18, 0) , StringUtil.PadR( "%" + AV54FilterFullText , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Str( (decimal)(A114DepartamentoMunicipioId), 18, 0) , StringUtil.PadR( "%" + AV54FilterFullText , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Str( (decimal)(A110ZonasID), 18, 0) , StringUtil.PadR( "%" + AV54FilterFullText , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A173SolicitudesDireccion) , StringUtil.PadR( "%" + StringUtil.Upper( AV54FilterFullText) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Str( A174SolicitudesTotal, 18, 2) , StringUtil.PadR( "%" + AV54FilterFullText , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Str( A211SolicitudServicioPFinal, 18, 2) , StringUtil.PadR( "%" + AV54FilterFullText , 254 , "%"),  ' ' ) ) ) )
            {
               if ( (Convert.ToDecimal(0)==AV30TFSolicitudServicioPFinal) || ( ( A211SolicitudServicioPFinal >= AV30TFSolicitudServicioPFinal ) ) )
               {
                  if ( (Convert.ToDecimal(0)==AV31TFSolicitudServicioPFinal_To) || ( ( A211SolicitudServicioPFinal <= AV31TFSolicitudServicioPFinal_To ) ) )
                  {
                     AV42count = 0;
                     while ( (pr_default.getStatus(1) != 101) && ( P004J3_A128MetodoPagosID[0] == A128MetodoPagosID ) && ( StringUtil.StrCmp(P004J3_A172SolicitudesTelefono[0], A172SolicitudesTelefono) == 0 ) )
                     {
                        BRK4J4 = false;
                        A127SolicitudesID = P004J3_A127SolicitudesID[0];
                        AV42count = (long)(AV42count+1);
                        BRK4J4 = true;
                        pr_default.readNext(1);
                     }
                     if ( (0==AV33SkipItems) )
                     {
                        AV37Option = (String.IsNullOrEmpty(StringUtil.RTrim( A172SolicitudesTelefono)) ? "<#Empty#>" : A172SolicitudesTelefono);
                        AV38Options.Add(AV37Option, 0);
                        AV41OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV42count), "Z,ZZZ,ZZZ,ZZ9")), 0);
                        if ( AV38Options.Count == 10 )
                        {
                           /* Exit For each command. Update data (if necessary), close cursors & exit. */
                           if (true) break;
                        }
                     }
                     else
                     {
                        AV33SkipItems = (short)(AV33SkipItems-1);
                     }
                  }
               }
            }
            if ( ! BRK4J4 )
            {
               BRK4J4 = true;
               pr_default.readNext(1);
            }
         }
         pr_default.close(1);
      }

      protected void S141( )
      {
         /* 'LOADSOLICITUDESMAILOPTIONS' Routine */
         returnInSub = false;
         AV17TFSolicitudesMail = AV32SearchTxt;
         AV18TFSolicitudesMail_Sel = "";
         pr_default.dynParam(2, new Object[]{ new Object[]{
                                              AV11TFSolicitudesID ,
                                              AV12TFSolicitudesID_To ,
                                              AV14TFSolicitudesNombre_Sel ,
                                              AV13TFSolicitudesNombre ,
                                              AV16TFSolicitudesTelefono_Sel ,
                                              AV15TFSolicitudesTelefono ,
                                              AV18TFSolicitudesMail_Sel ,
                                              AV17TFSolicitudesMail ,
                                              AV19TFDepartamentoId ,
                                              AV20TFDepartamentoId_To ,
                                              AV21TFDepartamentoMunicipioId ,
                                              AV22TFDepartamentoMunicipioId_To ,
                                              AV23TFZonasID ,
                                              AV24TFZonasID_To ,
                                              AV26TFSolicitudesDireccion_Sel ,
                                              AV25TFSolicitudesDireccion ,
                                              AV27TFSolicitudesTotal ,
                                              AV28TFSolicitudesTotal_To ,
                                              AV29TFSolicitudServicioSolCoti_Sel ,
                                              A127SolicitudesID ,
                                              A171SolicitudesNombre ,
                                              A172SolicitudesTelefono ,
                                              A206SolicitudesMail ,
                                              A112DepartamentoId ,
                                              A114DepartamentoMunicipioId ,
                                              A110ZonasID ,
                                              A173SolicitudesDireccion ,
                                              A174SolicitudesTotal ,
                                              A210SolicitudServicioSolCoti ,
                                              AV54FilterFullText ,
                                              A211SolicitudServicioPFinal ,
                                              AV30TFSolicitudServicioPFinal ,
                                              AV31TFSolicitudServicioPFinal_To ,
                                              AV55MetodoPagosID ,
                                              A128MetodoPagosID } ,
                                              new int[]{
                                              TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.DECIMAL, TypeConstants.DECIMAL,
                                              TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.DECIMAL,
                                              TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.LONG, TypeConstants.LONG
                                              }
         });
         lV13TFSolicitudesNombre = StringUtil.PadR( StringUtil.RTrim( AV13TFSolicitudesNombre), 100, "%");
         lV15TFSolicitudesTelefono = StringUtil.PadR( StringUtil.RTrim( AV15TFSolicitudesTelefono), 20, "%");
         lV17TFSolicitudesMail = StringUtil.Concat( StringUtil.RTrim( AV17TFSolicitudesMail), "%", "");
         lV25TFSolicitudesDireccion = StringUtil.Concat( StringUtil.RTrim( AV25TFSolicitudesDireccion), "%", "");
         /* Using cursor P004J4 */
         pr_default.execute(2, new Object[] {AV55MetodoPagosID, AV11TFSolicitudesID, AV12TFSolicitudesID_To, lV13TFSolicitudesNombre, AV14TFSolicitudesNombre_Sel, lV15TFSolicitudesTelefono, AV16TFSolicitudesTelefono_Sel, lV17TFSolicitudesMail, AV18TFSolicitudesMail_Sel, AV19TFDepartamentoId, AV20TFDepartamentoId_To, AV21TFDepartamentoMunicipioId, AV22TFDepartamentoMunicipioId_To, AV23TFZonasID, AV24TFZonasID_To, lV25TFSolicitudesDireccion, AV26TFSolicitudesDireccion_Sel, AV29TFSolicitudServicioSolCoti_Sel});
         while ( (pr_default.getStatus(2) != 101) )
         {
            BRK4J6 = false;
            A128MetodoPagosID = P004J4_A128MetodoPagosID[0];
            A206SolicitudesMail = P004J4_A206SolicitudesMail[0];
            n206SolicitudesMail = P004J4_n206SolicitudesMail[0];
            A210SolicitudServicioSolCoti = P004J4_A210SolicitudServicioSolCoti[0];
            A173SolicitudesDireccion = P004J4_A173SolicitudesDireccion[0];
            A110ZonasID = P004J4_A110ZonasID[0];
            n110ZonasID = P004J4_n110ZonasID[0];
            A114DepartamentoMunicipioId = P004J4_A114DepartamentoMunicipioId[0];
            n114DepartamentoMunicipioId = P004J4_n114DepartamentoMunicipioId[0];
            A112DepartamentoId = P004J4_A112DepartamentoId[0];
            n112DepartamentoId = P004J4_n112DepartamentoId[0];
            A172SolicitudesTelefono = P004J4_A172SolicitudesTelefono[0];
            A171SolicitudesNombre = P004J4_A171SolicitudesNombre[0];
            A127SolicitudesID = P004J4_A127SolicitudesID[0];
            A796SolicitudesComisionMetodoPago = P004J4_A796SolicitudesComisionMetodoPago[0];
            A212SolicitudesCotizacion = P004J4_A212SolicitudesCotizacion[0];
            A1016SolicitudesDescuentoCupon = P004J4_A1016SolicitudesDescuentoCupon[0];
            A897SolicitudesDescuento = P004J4_A897SolicitudesDescuento[0];
            n897SolicitudesDescuento = P004J4_n897SolicitudesDescuento[0];
            A864SolicitudesCostoXZona = P004J4_A864SolicitudesCostoXZona[0];
            GetSolicitudesTotal( A127SolicitudesID) ;
            if ( ( A212SolicitudesCotizacion == Convert.ToDecimal( 0 )) && ( A796SolicitudesComisionMetodoPago <= Convert.ToDecimal( 0 )) )
            {
               A211SolicitudServicioPFinal = (decimal)(A174SolicitudesTotal+A864SolicitudesCostoXZona-A897SolicitudesDescuento-A1016SolicitudesDescuentoCupon);
            }
            else
            {
               if ( ( A212SolicitudesCotizacion > Convert.ToDecimal( 0 )) && ( A796SolicitudesComisionMetodoPago <= Convert.ToDecimal( 0 )) )
               {
                  A211SolicitudServicioPFinal = (decimal)(A212SolicitudesCotizacion+A864SolicitudesCostoXZona-A897SolicitudesDescuento-A1016SolicitudesDescuentoCupon);
               }
               else
               {
                  if ( ( A212SolicitudesCotizacion == Convert.ToDecimal( 0 )) && ( A796SolicitudesComisionMetodoPago > Convert.ToDecimal( 0 )) )
                  {
                     A211SolicitudServicioPFinal = (decimal)(A174SolicitudesTotal+A864SolicitudesCostoXZona-A897SolicitudesDescuento-A1016SolicitudesDescuentoCupon-A796SolicitudesComisionMetodoPago);
                  }
                  else
                  {
                     if ( ( A212SolicitudesCotizacion > Convert.ToDecimal( 0 )) && ( A796SolicitudesComisionMetodoPago > Convert.ToDecimal( 0 )) )
                     {
                        A211SolicitudServicioPFinal = (decimal)(A212SolicitudesCotizacion+A864SolicitudesCostoXZona-A796SolicitudesComisionMetodoPago-A897SolicitudesDescuento-A1016SolicitudesDescuentoCupon);
                     }
                     else
                     {
                        A211SolicitudServicioPFinal = 0;
                     }
                  }
               }
            }
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV54FilterFullText)) || ( ( StringUtil.Like( StringUtil.Str( (decimal)(A127SolicitudesID), 18, 0) , StringUtil.PadR( "%" + AV54FilterFullText , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A171SolicitudesNombre) , StringUtil.PadR( "%" + StringUtil.Upper( AV54FilterFullText) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A172SolicitudesTelefono) , StringUtil.PadR( "%" + StringUtil.Upper( AV54FilterFullText) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A206SolicitudesMail) , StringUtil.PadR( "%" + StringUtil.Upper( AV54FilterFullText) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Str( (decimal)(A112DepartamentoId), 18, 0) , StringUtil.PadR( "%" + AV54FilterFullText , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Str( (decimal)(A114DepartamentoMunicipioId), 18, 0) , StringUtil.PadR( "%" + AV54FilterFullText , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Str( (decimal)(A110ZonasID), 18, 0) , StringUtil.PadR( "%" + AV54FilterFullText , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A173SolicitudesDireccion) , StringUtil.PadR( "%" + StringUtil.Upper( AV54FilterFullText) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Str( A174SolicitudesTotal, 18, 2) , StringUtil.PadR( "%" + AV54FilterFullText , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Str( A211SolicitudServicioPFinal, 18, 2) , StringUtil.PadR( "%" + AV54FilterFullText , 254 , "%"),  ' ' ) ) ) )
            {
               if ( (Convert.ToDecimal(0)==AV30TFSolicitudServicioPFinal) || ( ( A211SolicitudServicioPFinal >= AV30TFSolicitudServicioPFinal ) ) )
               {
                  if ( (Convert.ToDecimal(0)==AV31TFSolicitudServicioPFinal_To) || ( ( A211SolicitudServicioPFinal <= AV31TFSolicitudServicioPFinal_To ) ) )
                  {
                     AV42count = 0;
                     while ( (pr_default.getStatus(2) != 101) && ( P004J4_A128MetodoPagosID[0] == A128MetodoPagosID ) && ( StringUtil.StrCmp(P004J4_A206SolicitudesMail[0], A206SolicitudesMail) == 0 ) )
                     {
                        BRK4J6 = false;
                        A127SolicitudesID = P004J4_A127SolicitudesID[0];
                        AV42count = (long)(AV42count+1);
                        BRK4J6 = true;
                        pr_default.readNext(2);
                     }
                     if ( (0==AV33SkipItems) )
                     {
                        AV37Option = (String.IsNullOrEmpty(StringUtil.RTrim( A206SolicitudesMail)) ? "<#Empty#>" : A206SolicitudesMail);
                        AV38Options.Add(AV37Option, 0);
                        AV41OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV42count), "Z,ZZZ,ZZZ,ZZ9")), 0);
                        if ( AV38Options.Count == 10 )
                        {
                           /* Exit For each command. Update data (if necessary), close cursors & exit. */
                           if (true) break;
                        }
                     }
                     else
                     {
                        AV33SkipItems = (short)(AV33SkipItems-1);
                     }
                  }
               }
            }
            if ( ! BRK4J6 )
            {
               BRK4J6 = true;
               pr_default.readNext(2);
            }
         }
         pr_default.close(2);
      }

      protected void S151( )
      {
         /* 'LOADSOLICITUDESDIRECCIONOPTIONS' Routine */
         returnInSub = false;
         AV25TFSolicitudesDireccion = AV32SearchTxt;
         AV26TFSolicitudesDireccion_Sel = "";
         pr_default.dynParam(3, new Object[]{ new Object[]{
                                              AV11TFSolicitudesID ,
                                              AV12TFSolicitudesID_To ,
                                              AV14TFSolicitudesNombre_Sel ,
                                              AV13TFSolicitudesNombre ,
                                              AV16TFSolicitudesTelefono_Sel ,
                                              AV15TFSolicitudesTelefono ,
                                              AV18TFSolicitudesMail_Sel ,
                                              AV17TFSolicitudesMail ,
                                              AV19TFDepartamentoId ,
                                              AV20TFDepartamentoId_To ,
                                              AV21TFDepartamentoMunicipioId ,
                                              AV22TFDepartamentoMunicipioId_To ,
                                              AV23TFZonasID ,
                                              AV24TFZonasID_To ,
                                              AV26TFSolicitudesDireccion_Sel ,
                                              AV25TFSolicitudesDireccion ,
                                              AV27TFSolicitudesTotal ,
                                              AV28TFSolicitudesTotal_To ,
                                              AV29TFSolicitudServicioSolCoti_Sel ,
                                              A127SolicitudesID ,
                                              A171SolicitudesNombre ,
                                              A172SolicitudesTelefono ,
                                              A206SolicitudesMail ,
                                              A112DepartamentoId ,
                                              A114DepartamentoMunicipioId ,
                                              A110ZonasID ,
                                              A173SolicitudesDireccion ,
                                              A174SolicitudesTotal ,
                                              A210SolicitudServicioSolCoti ,
                                              AV54FilterFullText ,
                                              A211SolicitudServicioPFinal ,
                                              AV30TFSolicitudServicioPFinal ,
                                              AV31TFSolicitudServicioPFinal_To ,
                                              AV55MetodoPagosID ,
                                              A128MetodoPagosID } ,
                                              new int[]{
                                              TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.DECIMAL, TypeConstants.DECIMAL,
                                              TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.DECIMAL,
                                              TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.LONG, TypeConstants.LONG
                                              }
         });
         lV13TFSolicitudesNombre = StringUtil.PadR( StringUtil.RTrim( AV13TFSolicitudesNombre), 100, "%");
         lV15TFSolicitudesTelefono = StringUtil.PadR( StringUtil.RTrim( AV15TFSolicitudesTelefono), 20, "%");
         lV17TFSolicitudesMail = StringUtil.Concat( StringUtil.RTrim( AV17TFSolicitudesMail), "%", "");
         lV25TFSolicitudesDireccion = StringUtil.Concat( StringUtil.RTrim( AV25TFSolicitudesDireccion), "%", "");
         /* Using cursor P004J5 */
         pr_default.execute(3, new Object[] {AV55MetodoPagosID, AV11TFSolicitudesID, AV12TFSolicitudesID_To, lV13TFSolicitudesNombre, AV14TFSolicitudesNombre_Sel, lV15TFSolicitudesTelefono, AV16TFSolicitudesTelefono_Sel, lV17TFSolicitudesMail, AV18TFSolicitudesMail_Sel, AV19TFDepartamentoId, AV20TFDepartamentoId_To, AV21TFDepartamentoMunicipioId, AV22TFDepartamentoMunicipioId_To, AV23TFZonasID, AV24TFZonasID_To, lV25TFSolicitudesDireccion, AV26TFSolicitudesDireccion_Sel, AV29TFSolicitudServicioSolCoti_Sel});
         while ( (pr_default.getStatus(3) != 101) )
         {
            BRK4J8 = false;
            A128MetodoPagosID = P004J5_A128MetodoPagosID[0];
            A173SolicitudesDireccion = P004J5_A173SolicitudesDireccion[0];
            A210SolicitudServicioSolCoti = P004J5_A210SolicitudServicioSolCoti[0];
            A110ZonasID = P004J5_A110ZonasID[0];
            n110ZonasID = P004J5_n110ZonasID[0];
            A114DepartamentoMunicipioId = P004J5_A114DepartamentoMunicipioId[0];
            n114DepartamentoMunicipioId = P004J5_n114DepartamentoMunicipioId[0];
            A112DepartamentoId = P004J5_A112DepartamentoId[0];
            n112DepartamentoId = P004J5_n112DepartamentoId[0];
            A206SolicitudesMail = P004J5_A206SolicitudesMail[0];
            n206SolicitudesMail = P004J5_n206SolicitudesMail[0];
            A172SolicitudesTelefono = P004J5_A172SolicitudesTelefono[0];
            A171SolicitudesNombre = P004J5_A171SolicitudesNombre[0];
            A127SolicitudesID = P004J5_A127SolicitudesID[0];
            A796SolicitudesComisionMetodoPago = P004J5_A796SolicitudesComisionMetodoPago[0];
            A212SolicitudesCotizacion = P004J5_A212SolicitudesCotizacion[0];
            A1016SolicitudesDescuentoCupon = P004J5_A1016SolicitudesDescuentoCupon[0];
            A897SolicitudesDescuento = P004J5_A897SolicitudesDescuento[0];
            n897SolicitudesDescuento = P004J5_n897SolicitudesDescuento[0];
            A864SolicitudesCostoXZona = P004J5_A864SolicitudesCostoXZona[0];
            GetSolicitudesTotal( A127SolicitudesID) ;
            if ( ( A212SolicitudesCotizacion == Convert.ToDecimal( 0 )) && ( A796SolicitudesComisionMetodoPago <= Convert.ToDecimal( 0 )) )
            {
               A211SolicitudServicioPFinal = (decimal)(A174SolicitudesTotal+A864SolicitudesCostoXZona-A897SolicitudesDescuento-A1016SolicitudesDescuentoCupon);
            }
            else
            {
               if ( ( A212SolicitudesCotizacion > Convert.ToDecimal( 0 )) && ( A796SolicitudesComisionMetodoPago <= Convert.ToDecimal( 0 )) )
               {
                  A211SolicitudServicioPFinal = (decimal)(A212SolicitudesCotizacion+A864SolicitudesCostoXZona-A897SolicitudesDescuento-A1016SolicitudesDescuentoCupon);
               }
               else
               {
                  if ( ( A212SolicitudesCotizacion == Convert.ToDecimal( 0 )) && ( A796SolicitudesComisionMetodoPago > Convert.ToDecimal( 0 )) )
                  {
                     A211SolicitudServicioPFinal = (decimal)(A174SolicitudesTotal+A864SolicitudesCostoXZona-A897SolicitudesDescuento-A1016SolicitudesDescuentoCupon-A796SolicitudesComisionMetodoPago);
                  }
                  else
                  {
                     if ( ( A212SolicitudesCotizacion > Convert.ToDecimal( 0 )) && ( A796SolicitudesComisionMetodoPago > Convert.ToDecimal( 0 )) )
                     {
                        A211SolicitudServicioPFinal = (decimal)(A212SolicitudesCotizacion+A864SolicitudesCostoXZona-A796SolicitudesComisionMetodoPago-A897SolicitudesDescuento-A1016SolicitudesDescuentoCupon);
                     }
                     else
                     {
                        A211SolicitudServicioPFinal = 0;
                     }
                  }
               }
            }
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV54FilterFullText)) || ( ( StringUtil.Like( StringUtil.Str( (decimal)(A127SolicitudesID), 18, 0) , StringUtil.PadR( "%" + AV54FilterFullText , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A171SolicitudesNombre) , StringUtil.PadR( "%" + StringUtil.Upper( AV54FilterFullText) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A172SolicitudesTelefono) , StringUtil.PadR( "%" + StringUtil.Upper( AV54FilterFullText) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A206SolicitudesMail) , StringUtil.PadR( "%" + StringUtil.Upper( AV54FilterFullText) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Str( (decimal)(A112DepartamentoId), 18, 0) , StringUtil.PadR( "%" + AV54FilterFullText , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Str( (decimal)(A114DepartamentoMunicipioId), 18, 0) , StringUtil.PadR( "%" + AV54FilterFullText , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Str( (decimal)(A110ZonasID), 18, 0) , StringUtil.PadR( "%" + AV54FilterFullText , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A173SolicitudesDireccion) , StringUtil.PadR( "%" + StringUtil.Upper( AV54FilterFullText) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Str( A174SolicitudesTotal, 18, 2) , StringUtil.PadR( "%" + AV54FilterFullText , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Str( A211SolicitudServicioPFinal, 18, 2) , StringUtil.PadR( "%" + AV54FilterFullText , 254 , "%"),  ' ' ) ) ) )
            {
               if ( (Convert.ToDecimal(0)==AV30TFSolicitudServicioPFinal) || ( ( A211SolicitudServicioPFinal >= AV30TFSolicitudServicioPFinal ) ) )
               {
                  if ( (Convert.ToDecimal(0)==AV31TFSolicitudServicioPFinal_To) || ( ( A211SolicitudServicioPFinal <= AV31TFSolicitudServicioPFinal_To ) ) )
                  {
                     AV42count = 0;
                     while ( (pr_default.getStatus(3) != 101) && ( P004J5_A128MetodoPagosID[0] == A128MetodoPagosID ) && ( StringUtil.StrCmp(P004J5_A173SolicitudesDireccion[0], A173SolicitudesDireccion) == 0 ) )
                     {
                        BRK4J8 = false;
                        A127SolicitudesID = P004J5_A127SolicitudesID[0];
                        AV42count = (long)(AV42count+1);
                        BRK4J8 = true;
                        pr_default.readNext(3);
                     }
                     if ( (0==AV33SkipItems) )
                     {
                        AV37Option = (String.IsNullOrEmpty(StringUtil.RTrim( A173SolicitudesDireccion)) ? "<#Empty#>" : A173SolicitudesDireccion);
                        AV38Options.Add(AV37Option, 0);
                        AV41OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV42count), "Z,ZZZ,ZZZ,ZZ9")), 0);
                        if ( AV38Options.Count == 10 )
                        {
                           /* Exit For each command. Update data (if necessary), close cursors & exit. */
                           if (true) break;
                        }
                     }
                     else
                     {
                        AV33SkipItems = (short)(AV33SkipItems-1);
                     }
                  }
               }
            }
            if ( ! BRK4J8 )
            {
               BRK4J8 = true;
               pr_default.readNext(3);
            }
         }
         pr_default.close(3);
      }

      protected void GetSolicitudesTotal( long A127SolicitudesID )
      {
         /* Create private dbobjects */
         /* Navigation */
         A174SolicitudesTotal = 0;
         /* Using cursor P004J6 */
         pr_default.execute(4, new Object[] {A127SolicitudesID});
         while ( (pr_default.getStatus(4) != 101) && ( P004J6_A127SolicitudesID[0] == A127SolicitudesID ) )
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( P004J6_A178SolicitudItemsSR[0])) || ( StringUtil.StrCmp(P004J6_A179SolicitudItemsComisionTipo[0], "N") == 0 ) )
            {
               A175SolicitudesItemsPrecioInstalac = (decimal)((P004J6_A176SolicitudesItemsPrecioFinal[0]*P004J6_A177SolicitudesItemsCantidad[0]));
            }
            else
            {
               if ( ( StringUtil.StrCmp(P004J6_A179SolicitudItemsComisionTipo[0], "F") == 0 ) && ( StringUtil.StrCmp(P004J6_A178SolicitudItemsSR[0], "R") == 0 ) )
               {
                  A175SolicitudesItemsPrecioInstalac = (decimal)((P004J6_A176SolicitudesItemsPrecioFinal[0]*P004J6_A177SolicitudesItemsCantidad[0])-(P004J6_A180SolicitudItemsComision[0]*P004J6_A177SolicitudesItemsCantidad[0]));
               }
               else
               {
                  if ( ( StringUtil.StrCmp(P004J6_A179SolicitudItemsComisionTipo[0], "F") == 0 ) && ( StringUtil.StrCmp(P004J6_A178SolicitudItemsSR[0], "S") == 0 ) )
                  {
                     A175SolicitudesItemsPrecioInstalac = (decimal)((P004J6_A176SolicitudesItemsPrecioFinal[0]*P004J6_A177SolicitudesItemsCantidad[0])+(P004J6_A180SolicitudItemsComision[0]*P004J6_A177SolicitudesItemsCantidad[0]));
                  }
                  else
                  {
                     if ( ( StringUtil.StrCmp(P004J6_A179SolicitudItemsComisionTipo[0], "P") == 0 ) && ( StringUtil.StrCmp(P004J6_A178SolicitudItemsSR[0], "R") == 0 ) )
                     {
                        A175SolicitudesItemsPrecioInstalac = (decimal)((P004J6_A176SolicitudesItemsPrecioFinal[0]*P004J6_A177SolicitudesItemsCantidad[0])-((P004J6_A176SolicitudesItemsPrecioFinal[0]*P004J6_A177SolicitudesItemsCantidad[0])*(P004J6_A180SolicitudItemsComision[0]/ (decimal)(100))));
                     }
                     else
                     {
                        if ( ( StringUtil.StrCmp(P004J6_A179SolicitudItemsComisionTipo[0], "P") == 0 ) && ( StringUtil.StrCmp(P004J6_A178SolicitudItemsSR[0], "S") == 0 ) )
                        {
                           A175SolicitudesItemsPrecioInstalac = (decimal)((P004J6_A176SolicitudesItemsPrecioFinal[0]*P004J6_A177SolicitudesItemsCantidad[0])+((P004J6_A176SolicitudesItemsPrecioFinal[0]*P004J6_A177SolicitudesItemsCantidad[0])*(P004J6_A180SolicitudItemsComision[0]/ (decimal)(100))));
                        }
                        else
                        {
                           A175SolicitudesItemsPrecioInstalac = 0;
                        }
                     }
                  }
               }
            }
            A174SolicitudesTotal = (decimal)(A174SolicitudesTotal+A175SolicitudesItemsPrecioInstalac);
            pr_default.readNext(4);
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
         AV51OptionsJson = "";
         AV52OptionsDescJson = "";
         AV53OptionIndexesJson = "";
         AV38Options = new GxSimpleCollection<string>();
         AV40OptionsDesc = new GxSimpleCollection<string>();
         AV41OptionIndexes = new GxSimpleCollection<string>();
         AV32SearchTxt = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV43Session = context.GetSession();
         AV45GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV46GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV54FilterFullText = "";
         AV13TFSolicitudesNombre = "";
         AV14TFSolicitudesNombre_Sel = "";
         AV15TFSolicitudesTelefono = "";
         AV16TFSolicitudesTelefono_Sel = "";
         AV17TFSolicitudesMail = "";
         AV18TFSolicitudesMail_Sel = "";
         AV25TFSolicitudesDireccion = "";
         AV26TFSolicitudesDireccion_Sel = "";
         AV29TFSolicitudServicioSolCoti_Sel = "";
         lV13TFSolicitudesNombre = "";
         lV15TFSolicitudesTelefono = "";
         lV17TFSolicitudesMail = "";
         lV25TFSolicitudesDireccion = "";
         A171SolicitudesNombre = "";
         A172SolicitudesTelefono = "";
         A206SolicitudesMail = "";
         A173SolicitudesDireccion = "";
         A210SolicitudServicioSolCoti = "";
         P004J2_A128MetodoPagosID = new long[1] ;
         P004J2_A171SolicitudesNombre = new string[] {""} ;
         P004J2_A210SolicitudServicioSolCoti = new string[] {""} ;
         P004J2_A173SolicitudesDireccion = new string[] {""} ;
         P004J2_A110ZonasID = new long[1] ;
         P004J2_n110ZonasID = new bool[] {false} ;
         P004J2_A114DepartamentoMunicipioId = new long[1] ;
         P004J2_n114DepartamentoMunicipioId = new bool[] {false} ;
         P004J2_A112DepartamentoId = new long[1] ;
         P004J2_n112DepartamentoId = new bool[] {false} ;
         P004J2_A206SolicitudesMail = new string[] {""} ;
         P004J2_n206SolicitudesMail = new bool[] {false} ;
         P004J2_A172SolicitudesTelefono = new string[] {""} ;
         P004J2_A127SolicitudesID = new long[1] ;
         P004J2_A796SolicitudesComisionMetodoPago = new decimal[1] ;
         P004J2_A212SolicitudesCotizacion = new decimal[1] ;
         P004J2_A1016SolicitudesDescuentoCupon = new decimal[1] ;
         P004J2_A897SolicitudesDescuento = new decimal[1] ;
         P004J2_n897SolicitudesDescuento = new bool[] {false} ;
         P004J2_A864SolicitudesCostoXZona = new decimal[1] ;
         AV37Option = "";
         P004J3_A128MetodoPagosID = new long[1] ;
         P004J3_A172SolicitudesTelefono = new string[] {""} ;
         P004J3_A210SolicitudServicioSolCoti = new string[] {""} ;
         P004J3_A173SolicitudesDireccion = new string[] {""} ;
         P004J3_A110ZonasID = new long[1] ;
         P004J3_n110ZonasID = new bool[] {false} ;
         P004J3_A114DepartamentoMunicipioId = new long[1] ;
         P004J3_n114DepartamentoMunicipioId = new bool[] {false} ;
         P004J3_A112DepartamentoId = new long[1] ;
         P004J3_n112DepartamentoId = new bool[] {false} ;
         P004J3_A206SolicitudesMail = new string[] {""} ;
         P004J3_n206SolicitudesMail = new bool[] {false} ;
         P004J3_A171SolicitudesNombre = new string[] {""} ;
         P004J3_A127SolicitudesID = new long[1] ;
         P004J3_A796SolicitudesComisionMetodoPago = new decimal[1] ;
         P004J3_A212SolicitudesCotizacion = new decimal[1] ;
         P004J3_A1016SolicitudesDescuentoCupon = new decimal[1] ;
         P004J3_A897SolicitudesDescuento = new decimal[1] ;
         P004J3_n897SolicitudesDescuento = new bool[] {false} ;
         P004J3_A864SolicitudesCostoXZona = new decimal[1] ;
         P004J4_A128MetodoPagosID = new long[1] ;
         P004J4_A206SolicitudesMail = new string[] {""} ;
         P004J4_n206SolicitudesMail = new bool[] {false} ;
         P004J4_A210SolicitudServicioSolCoti = new string[] {""} ;
         P004J4_A173SolicitudesDireccion = new string[] {""} ;
         P004J4_A110ZonasID = new long[1] ;
         P004J4_n110ZonasID = new bool[] {false} ;
         P004J4_A114DepartamentoMunicipioId = new long[1] ;
         P004J4_n114DepartamentoMunicipioId = new bool[] {false} ;
         P004J4_A112DepartamentoId = new long[1] ;
         P004J4_n112DepartamentoId = new bool[] {false} ;
         P004J4_A172SolicitudesTelefono = new string[] {""} ;
         P004J4_A171SolicitudesNombre = new string[] {""} ;
         P004J4_A127SolicitudesID = new long[1] ;
         P004J4_A796SolicitudesComisionMetodoPago = new decimal[1] ;
         P004J4_A212SolicitudesCotizacion = new decimal[1] ;
         P004J4_A1016SolicitudesDescuentoCupon = new decimal[1] ;
         P004J4_A897SolicitudesDescuento = new decimal[1] ;
         P004J4_n897SolicitudesDescuento = new bool[] {false} ;
         P004J4_A864SolicitudesCostoXZona = new decimal[1] ;
         P004J5_A128MetodoPagosID = new long[1] ;
         P004J5_A173SolicitudesDireccion = new string[] {""} ;
         P004J5_A210SolicitudServicioSolCoti = new string[] {""} ;
         P004J5_A110ZonasID = new long[1] ;
         P004J5_n110ZonasID = new bool[] {false} ;
         P004J5_A114DepartamentoMunicipioId = new long[1] ;
         P004J5_n114DepartamentoMunicipioId = new bool[] {false} ;
         P004J5_A112DepartamentoId = new long[1] ;
         P004J5_n112DepartamentoId = new bool[] {false} ;
         P004J5_A206SolicitudesMail = new string[] {""} ;
         P004J5_n206SolicitudesMail = new bool[] {false} ;
         P004J5_A172SolicitudesTelefono = new string[] {""} ;
         P004J5_A171SolicitudesNombre = new string[] {""} ;
         P004J5_A127SolicitudesID = new long[1] ;
         P004J5_A796SolicitudesComisionMetodoPago = new decimal[1] ;
         P004J5_A212SolicitudesCotizacion = new decimal[1] ;
         P004J5_A1016SolicitudesDescuentoCupon = new decimal[1] ;
         P004J5_A897SolicitudesDescuento = new decimal[1] ;
         P004J5_n897SolicitudesDescuento = new bool[] {false} ;
         P004J5_A864SolicitudesCostoXZona = new decimal[1] ;
         P004J6_A127SolicitudesID = new long[1] ;
         P004J6_A134SolicitudesItemsID = new short[1] ;
         P004J6_A180SolicitudItemsComision = new decimal[1] ;
         P004J6_A179SolicitudItemsComisionTipo = new string[] {""} ;
         P004J6_A178SolicitudItemsSR = new string[] {""} ;
         P004J6_A177SolicitudesItemsCantidad = new short[1] ;
         P004J6_A176SolicitudesItemsPrecioFinal = new decimal[1] ;
         P004J6_n176SolicitudesItemsPrecioFinal = new bool[] {false} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.metodopagossolicitudeswcgetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P004J2_A128MetodoPagosID, P004J2_A171SolicitudesNombre, P004J2_A210SolicitudServicioSolCoti, P004J2_A173SolicitudesDireccion, P004J2_A110ZonasID, P004J2_n110ZonasID, P004J2_A114DepartamentoMunicipioId, P004J2_n114DepartamentoMunicipioId, P004J2_A112DepartamentoId, P004J2_n112DepartamentoId,
               P004J2_A206SolicitudesMail, P004J2_n206SolicitudesMail, P004J2_A172SolicitudesTelefono, P004J2_A127SolicitudesID, P004J2_A796SolicitudesComisionMetodoPago, P004J2_A212SolicitudesCotizacion, P004J2_A1016SolicitudesDescuentoCupon, P004J2_A897SolicitudesDescuento, P004J2_n897SolicitudesDescuento, P004J2_A864SolicitudesCostoXZona
               }
               , new Object[] {
               P004J3_A128MetodoPagosID, P004J3_A172SolicitudesTelefono, P004J3_A210SolicitudServicioSolCoti, P004J3_A173SolicitudesDireccion, P004J3_A110ZonasID, P004J3_n110ZonasID, P004J3_A114DepartamentoMunicipioId, P004J3_n114DepartamentoMunicipioId, P004J3_A112DepartamentoId, P004J3_n112DepartamentoId,
               P004J3_A206SolicitudesMail, P004J3_n206SolicitudesMail, P004J3_A171SolicitudesNombre, P004J3_A127SolicitudesID, P004J3_A796SolicitudesComisionMetodoPago, P004J3_A212SolicitudesCotizacion, P004J3_A1016SolicitudesDescuentoCupon, P004J3_A897SolicitudesDescuento, P004J3_n897SolicitudesDescuento, P004J3_A864SolicitudesCostoXZona
               }
               , new Object[] {
               P004J4_A128MetodoPagosID, P004J4_A206SolicitudesMail, P004J4_n206SolicitudesMail, P004J4_A210SolicitudServicioSolCoti, P004J4_A173SolicitudesDireccion, P004J4_A110ZonasID, P004J4_n110ZonasID, P004J4_A114DepartamentoMunicipioId, P004J4_n114DepartamentoMunicipioId, P004J4_A112DepartamentoId,
               P004J4_n112DepartamentoId, P004J4_A172SolicitudesTelefono, P004J4_A171SolicitudesNombre, P004J4_A127SolicitudesID, P004J4_A796SolicitudesComisionMetodoPago, P004J4_A212SolicitudesCotizacion, P004J4_A1016SolicitudesDescuentoCupon, P004J4_A897SolicitudesDescuento, P004J4_n897SolicitudesDescuento, P004J4_A864SolicitudesCostoXZona
               }
               , new Object[] {
               P004J5_A128MetodoPagosID, P004J5_A173SolicitudesDireccion, P004J5_A210SolicitudServicioSolCoti, P004J5_A110ZonasID, P004J5_n110ZonasID, P004J5_A114DepartamentoMunicipioId, P004J5_n114DepartamentoMunicipioId, P004J5_A112DepartamentoId, P004J5_n112DepartamentoId, P004J5_A206SolicitudesMail,
               P004J5_n206SolicitudesMail, P004J5_A172SolicitudesTelefono, P004J5_A171SolicitudesNombre, P004J5_A127SolicitudesID, P004J5_A796SolicitudesComisionMetodoPago, P004J5_A212SolicitudesCotizacion, P004J5_A1016SolicitudesDescuentoCupon, P004J5_A897SolicitudesDescuento, P004J5_n897SolicitudesDescuento, P004J5_A864SolicitudesCostoXZona
               }
               , new Object[] {
               P004J6_A127SolicitudesID, P004J6_A134SolicitudesItemsID, P004J6_A180SolicitudItemsComision, P004J6_A179SolicitudItemsComisionTipo, P004J6_A178SolicitudItemsSR, P004J6_A177SolicitudesItemsCantidad, P004J6_A176SolicitudesItemsPrecioFinal, P004J6_n176SolicitudesItemsPrecioFinal
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV35MaxItems ;
      private short AV34PageIndex ;
      private short AV33SkipItems ;
      private int AV56GXV1 ;
      private long AV11TFSolicitudesID ;
      private long AV12TFSolicitudesID_To ;
      private long AV19TFDepartamentoId ;
      private long AV20TFDepartamentoId_To ;
      private long AV21TFDepartamentoMunicipioId ;
      private long AV22TFDepartamentoMunicipioId_To ;
      private long AV23TFZonasID ;
      private long AV24TFZonasID_To ;
      private long AV55MetodoPagosID ;
      private long A127SolicitudesID ;
      private long A112DepartamentoId ;
      private long A114DepartamentoMunicipioId ;
      private long A110ZonasID ;
      private long A128MetodoPagosID ;
      private long AV42count ;
      private decimal AV27TFSolicitudesTotal ;
      private decimal AV28TFSolicitudesTotal_To ;
      private decimal AV30TFSolicitudServicioPFinal ;
      private decimal AV31TFSolicitudServicioPFinal_To ;
      private decimal A174SolicitudesTotal ;
      private decimal A211SolicitudServicioPFinal ;
      private decimal A796SolicitudesComisionMetodoPago ;
      private decimal A212SolicitudesCotizacion ;
      private decimal A1016SolicitudesDescuentoCupon ;
      private decimal A897SolicitudesDescuento ;
      private decimal A864SolicitudesCostoXZona ;
      private decimal A175SolicitudesItemsPrecioInstalac ;
      private string AV13TFSolicitudesNombre ;
      private string AV14TFSolicitudesNombre_Sel ;
      private string AV15TFSolicitudesTelefono ;
      private string AV16TFSolicitudesTelefono_Sel ;
      private string AV29TFSolicitudServicioSolCoti_Sel ;
      private string lV13TFSolicitudesNombre ;
      private string lV15TFSolicitudesTelefono ;
      private string A171SolicitudesNombre ;
      private string A172SolicitudesTelefono ;
      private string A210SolicitudServicioSolCoti ;
      private bool AV8IsAuthorized ;
      private bool GXt_boolean1 ;
      private bool returnInSub ;
      private bool BRK4J2 ;
      private bool n110ZonasID ;
      private bool n114DepartamentoMunicipioId ;
      private bool n112DepartamentoId ;
      private bool n206SolicitudesMail ;
      private bool n897SolicitudesDescuento ;
      private bool BRK4J4 ;
      private bool BRK4J6 ;
      private bool BRK4J8 ;
      private string AV51OptionsJson ;
      private string AV52OptionsDescJson ;
      private string AV53OptionIndexesJson ;
      private string AV48DDOName ;
      private string AV49SearchTxtParms ;
      private string AV50SearchTxtTo ;
      private string AV32SearchTxt ;
      private string AV54FilterFullText ;
      private string AV17TFSolicitudesMail ;
      private string AV18TFSolicitudesMail_Sel ;
      private string AV25TFSolicitudesDireccion ;
      private string AV26TFSolicitudesDireccion_Sel ;
      private string lV17TFSolicitudesMail ;
      private string lV25TFSolicitudesDireccion ;
      private string A206SolicitudesMail ;
      private string A173SolicitudesDireccion ;
      private string AV37Option ;
      private IGxSession AV43Session ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GxSimpleCollection<string> AV38Options ;
      private GxSimpleCollection<string> AV40OptionsDesc ;
      private GxSimpleCollection<string> AV41OptionIndexes ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV45GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV46GridStateFilterValue ;
      private IDataStoreProvider pr_default ;
      private long[] P004J2_A128MetodoPagosID ;
      private string[] P004J2_A171SolicitudesNombre ;
      private string[] P004J2_A210SolicitudServicioSolCoti ;
      private string[] P004J2_A173SolicitudesDireccion ;
      private long[] P004J2_A110ZonasID ;
      private bool[] P004J2_n110ZonasID ;
      private long[] P004J2_A114DepartamentoMunicipioId ;
      private bool[] P004J2_n114DepartamentoMunicipioId ;
      private long[] P004J2_A112DepartamentoId ;
      private bool[] P004J2_n112DepartamentoId ;
      private string[] P004J2_A206SolicitudesMail ;
      private bool[] P004J2_n206SolicitudesMail ;
      private string[] P004J2_A172SolicitudesTelefono ;
      private long[] P004J2_A127SolicitudesID ;
      private decimal[] P004J2_A796SolicitudesComisionMetodoPago ;
      private decimal[] P004J2_A212SolicitudesCotizacion ;
      private decimal[] P004J2_A1016SolicitudesDescuentoCupon ;
      private decimal[] P004J2_A897SolicitudesDescuento ;
      private bool[] P004J2_n897SolicitudesDescuento ;
      private decimal[] P004J2_A864SolicitudesCostoXZona ;
      private long[] P004J3_A128MetodoPagosID ;
      private string[] P004J3_A172SolicitudesTelefono ;
      private string[] P004J3_A210SolicitudServicioSolCoti ;
      private string[] P004J3_A173SolicitudesDireccion ;
      private long[] P004J3_A110ZonasID ;
      private bool[] P004J3_n110ZonasID ;
      private long[] P004J3_A114DepartamentoMunicipioId ;
      private bool[] P004J3_n114DepartamentoMunicipioId ;
      private long[] P004J3_A112DepartamentoId ;
      private bool[] P004J3_n112DepartamentoId ;
      private string[] P004J3_A206SolicitudesMail ;
      private bool[] P004J3_n206SolicitudesMail ;
      private string[] P004J3_A171SolicitudesNombre ;
      private long[] P004J3_A127SolicitudesID ;
      private decimal[] P004J3_A796SolicitudesComisionMetodoPago ;
      private decimal[] P004J3_A212SolicitudesCotizacion ;
      private decimal[] P004J3_A1016SolicitudesDescuentoCupon ;
      private decimal[] P004J3_A897SolicitudesDescuento ;
      private bool[] P004J3_n897SolicitudesDescuento ;
      private decimal[] P004J3_A864SolicitudesCostoXZona ;
      private long[] P004J4_A128MetodoPagosID ;
      private string[] P004J4_A206SolicitudesMail ;
      private bool[] P004J4_n206SolicitudesMail ;
      private string[] P004J4_A210SolicitudServicioSolCoti ;
      private string[] P004J4_A173SolicitudesDireccion ;
      private long[] P004J4_A110ZonasID ;
      private bool[] P004J4_n110ZonasID ;
      private long[] P004J4_A114DepartamentoMunicipioId ;
      private bool[] P004J4_n114DepartamentoMunicipioId ;
      private long[] P004J4_A112DepartamentoId ;
      private bool[] P004J4_n112DepartamentoId ;
      private string[] P004J4_A172SolicitudesTelefono ;
      private string[] P004J4_A171SolicitudesNombre ;
      private long[] P004J4_A127SolicitudesID ;
      private decimal[] P004J4_A796SolicitudesComisionMetodoPago ;
      private decimal[] P004J4_A212SolicitudesCotizacion ;
      private decimal[] P004J4_A1016SolicitudesDescuentoCupon ;
      private decimal[] P004J4_A897SolicitudesDescuento ;
      private bool[] P004J4_n897SolicitudesDescuento ;
      private decimal[] P004J4_A864SolicitudesCostoXZona ;
      private long[] P004J5_A128MetodoPagosID ;
      private string[] P004J5_A173SolicitudesDireccion ;
      private string[] P004J5_A210SolicitudServicioSolCoti ;
      private long[] P004J5_A110ZonasID ;
      private bool[] P004J5_n110ZonasID ;
      private long[] P004J5_A114DepartamentoMunicipioId ;
      private bool[] P004J5_n114DepartamentoMunicipioId ;
      private long[] P004J5_A112DepartamentoId ;
      private bool[] P004J5_n112DepartamentoId ;
      private string[] P004J5_A206SolicitudesMail ;
      private bool[] P004J5_n206SolicitudesMail ;
      private string[] P004J5_A172SolicitudesTelefono ;
      private string[] P004J5_A171SolicitudesNombre ;
      private long[] P004J5_A127SolicitudesID ;
      private decimal[] P004J5_A796SolicitudesComisionMetodoPago ;
      private decimal[] P004J5_A212SolicitudesCotizacion ;
      private decimal[] P004J5_A1016SolicitudesDescuentoCupon ;
      private decimal[] P004J5_A897SolicitudesDescuento ;
      private bool[] P004J5_n897SolicitudesDescuento ;
      private decimal[] P004J5_A864SolicitudesCostoXZona ;
      private long[] P004J6_A127SolicitudesID ;
      private short[] P004J6_A134SolicitudesItemsID ;
      private decimal[] P004J6_A180SolicitudItemsComision ;
      private string[] P004J6_A179SolicitudItemsComisionTipo ;
      private string[] P004J6_A178SolicitudItemsSR ;
      private short[] P004J6_A177SolicitudesItemsCantidad ;
      private decimal[] P004J6_A176SolicitudesItemsPrecioFinal ;
      private bool[] P004J6_n176SolicitudesItemsPrecioFinal ;
      private string aP3_OptionsJson ;
      private string aP4_OptionsDescJson ;
      private string aP5_OptionIndexesJson ;
   }

   public class metodopagossolicitudeswcgetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P004J2( IGxContext context ,
                                             long AV11TFSolicitudesID ,
                                             long AV12TFSolicitudesID_To ,
                                             string AV14TFSolicitudesNombre_Sel ,
                                             string AV13TFSolicitudesNombre ,
                                             string AV16TFSolicitudesTelefono_Sel ,
                                             string AV15TFSolicitudesTelefono ,
                                             string AV18TFSolicitudesMail_Sel ,
                                             string AV17TFSolicitudesMail ,
                                             long AV19TFDepartamentoId ,
                                             long AV20TFDepartamentoId_To ,
                                             long AV21TFDepartamentoMunicipioId ,
                                             long AV22TFDepartamentoMunicipioId_To ,
                                             long AV23TFZonasID ,
                                             long AV24TFZonasID_To ,
                                             string AV26TFSolicitudesDireccion_Sel ,
                                             string AV25TFSolicitudesDireccion ,
                                             decimal AV27TFSolicitudesTotal ,
                                             decimal AV28TFSolicitudesTotal_To ,
                                             string AV29TFSolicitudServicioSolCoti_Sel ,
                                             long A127SolicitudesID ,
                                             string A171SolicitudesNombre ,
                                             string A172SolicitudesTelefono ,
                                             string A206SolicitudesMail ,
                                             long A112DepartamentoId ,
                                             long A114DepartamentoMunicipioId ,
                                             long A110ZonasID ,
                                             string A173SolicitudesDireccion ,
                                             decimal A174SolicitudesTotal ,
                                             string A210SolicitudServicioSolCoti ,
                                             string AV54FilterFullText ,
                                             decimal A211SolicitudServicioPFinal ,
                                             decimal AV30TFSolicitudServicioPFinal ,
                                             decimal AV31TFSolicitudServicioPFinal_To ,
                                             long AV55MetodoPagosID ,
                                             long A128MetodoPagosID )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int2 = new short[18];
         Object[] GXv_Object3 = new Object[2];
         scmdbuf = "SELECT [MetodoPagosID], [SolicitudesNombre], [SolicitudServicioSolCoti], [SolicitudesDireccion], [ZonasID], [DepartamentoMunicipioId], [DepartamentoId], [SolicitudesMail], [SolicitudesTelefono], [SolicitudesID], [SolicitudesComisionMetodoPago], [SolicitudesCotizacion], [SolicitudesDescuentoCupon], [SolicitudesDescuento], [SolicitudesCostoXZona] FROM [Solicitudes]";
         AddWhere(sWhereString, "([MetodoPagosID] = @AV55MetodoPagosID)");
         if ( ! (0==AV11TFSolicitudesID) )
         {
            AddWhere(sWhereString, "([SolicitudesID] >= @AV11TFSolicitudesID)");
         }
         else
         {
            GXv_int2[1] = 1;
         }
         if ( ! (0==AV12TFSolicitudesID_To) )
         {
            AddWhere(sWhereString, "([SolicitudesID] <= @AV12TFSolicitudesID_To)");
         }
         else
         {
            GXv_int2[2] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV14TFSolicitudesNombre_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV13TFSolicitudesNombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER([SolicitudesNombre]) like UPPER(@lV13TFSolicitudesNombre))");
         }
         else
         {
            GXv_int2[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV14TFSolicitudesNombre_Sel)) && ! ( StringUtil.StrCmp(AV14TFSolicitudesNombre_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([SolicitudesNombre] = @AV14TFSolicitudesNombre_Sel)");
         }
         else
         {
            GXv_int2[4] = 1;
         }
         if ( StringUtil.StrCmp(AV14TFSolicitudesNombre_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([SolicitudesNombre] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV16TFSolicitudesTelefono_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV15TFSolicitudesTelefono)) ) )
         {
            AddWhere(sWhereString, "(UPPER([SolicitudesTelefono]) like UPPER(@lV15TFSolicitudesTelefono))");
         }
         else
         {
            GXv_int2[5] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV16TFSolicitudesTelefono_Sel)) && ! ( StringUtil.StrCmp(AV16TFSolicitudesTelefono_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([SolicitudesTelefono] = @AV16TFSolicitudesTelefono_Sel)");
         }
         else
         {
            GXv_int2[6] = 1;
         }
         if ( StringUtil.StrCmp(AV16TFSolicitudesTelefono_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([SolicitudesTelefono] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV18TFSolicitudesMail_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV17TFSolicitudesMail)) ) )
         {
            AddWhere(sWhereString, "(UPPER([SolicitudesMail]) like UPPER(@lV17TFSolicitudesMail))");
         }
         else
         {
            GXv_int2[7] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV18TFSolicitudesMail_Sel)) && ! ( StringUtil.StrCmp(AV18TFSolicitudesMail_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([SolicitudesMail] = @AV18TFSolicitudesMail_Sel)");
         }
         else
         {
            GXv_int2[8] = 1;
         }
         if ( StringUtil.StrCmp(AV18TFSolicitudesMail_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "([SolicitudesMail] IS NULL or ([SolicitudesMail] = ''))");
         }
         if ( ! (0==AV19TFDepartamentoId) )
         {
            AddWhere(sWhereString, "([DepartamentoId] >= @AV19TFDepartamentoId)");
         }
         else
         {
            GXv_int2[9] = 1;
         }
         if ( ! (0==AV20TFDepartamentoId_To) )
         {
            AddWhere(sWhereString, "([DepartamentoId] <= @AV20TFDepartamentoId_To)");
         }
         else
         {
            GXv_int2[10] = 1;
         }
         if ( ! (0==AV21TFDepartamentoMunicipioId) )
         {
            AddWhere(sWhereString, "([DepartamentoMunicipioId] >= @AV21TFDepartamentoMunicipioId)");
         }
         else
         {
            GXv_int2[11] = 1;
         }
         if ( ! (0==AV22TFDepartamentoMunicipioId_To) )
         {
            AddWhere(sWhereString, "([DepartamentoMunicipioId] <= @AV22TFDepartamentoMunicipioId_To)");
         }
         else
         {
            GXv_int2[12] = 1;
         }
         if ( ! (0==AV23TFZonasID) )
         {
            AddWhere(sWhereString, "([ZonasID] >= @AV23TFZonasID)");
         }
         else
         {
            GXv_int2[13] = 1;
         }
         if ( ! (0==AV24TFZonasID_To) )
         {
            AddWhere(sWhereString, "([ZonasID] <= @AV24TFZonasID_To)");
         }
         else
         {
            GXv_int2[14] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV26TFSolicitudesDireccion_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV25TFSolicitudesDireccion)) ) )
         {
            AddWhere(sWhereString, "(UPPER([SolicitudesDireccion]) like UPPER(@lV25TFSolicitudesDireccion))");
         }
         else
         {
            GXv_int2[15] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV26TFSolicitudesDireccion_Sel)) && ! ( StringUtil.StrCmp(AV26TFSolicitudesDireccion_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([SolicitudesDireccion] = @AV26TFSolicitudesDireccion_Sel)");
         }
         else
         {
            GXv_int2[16] = 1;
         }
         if ( StringUtil.StrCmp(AV26TFSolicitudesDireccion_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([SolicitudesDireccion] = ''))");
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV29TFSolicitudServicioSolCoti_Sel)) )
         {
            AddWhere(sWhereString, "([SolicitudServicioSolCoti] = @AV29TFSolicitudServicioSolCoti_Sel)");
         }
         else
         {
            GXv_int2[17] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY [MetodoPagosID], [SolicitudesNombre]";
         GXv_Object3[0] = scmdbuf;
         GXv_Object3[1] = GXv_int2;
         return GXv_Object3 ;
      }

      protected Object[] conditional_P004J3( IGxContext context ,
                                             long AV11TFSolicitudesID ,
                                             long AV12TFSolicitudesID_To ,
                                             string AV14TFSolicitudesNombre_Sel ,
                                             string AV13TFSolicitudesNombre ,
                                             string AV16TFSolicitudesTelefono_Sel ,
                                             string AV15TFSolicitudesTelefono ,
                                             string AV18TFSolicitudesMail_Sel ,
                                             string AV17TFSolicitudesMail ,
                                             long AV19TFDepartamentoId ,
                                             long AV20TFDepartamentoId_To ,
                                             long AV21TFDepartamentoMunicipioId ,
                                             long AV22TFDepartamentoMunicipioId_To ,
                                             long AV23TFZonasID ,
                                             long AV24TFZonasID_To ,
                                             string AV26TFSolicitudesDireccion_Sel ,
                                             string AV25TFSolicitudesDireccion ,
                                             decimal AV27TFSolicitudesTotal ,
                                             decimal AV28TFSolicitudesTotal_To ,
                                             string AV29TFSolicitudServicioSolCoti_Sel ,
                                             long A127SolicitudesID ,
                                             string A171SolicitudesNombre ,
                                             string A172SolicitudesTelefono ,
                                             string A206SolicitudesMail ,
                                             long A112DepartamentoId ,
                                             long A114DepartamentoMunicipioId ,
                                             long A110ZonasID ,
                                             string A173SolicitudesDireccion ,
                                             decimal A174SolicitudesTotal ,
                                             string A210SolicitudServicioSolCoti ,
                                             string AV54FilterFullText ,
                                             decimal A211SolicitudServicioPFinal ,
                                             decimal AV30TFSolicitudServicioPFinal ,
                                             decimal AV31TFSolicitudServicioPFinal_To ,
                                             long AV55MetodoPagosID ,
                                             long A128MetodoPagosID )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int4 = new short[18];
         Object[] GXv_Object5 = new Object[2];
         scmdbuf = "SELECT [MetodoPagosID], [SolicitudesTelefono], [SolicitudServicioSolCoti], [SolicitudesDireccion], [ZonasID], [DepartamentoMunicipioId], [DepartamentoId], [SolicitudesMail], [SolicitudesNombre], [SolicitudesID], [SolicitudesComisionMetodoPago], [SolicitudesCotizacion], [SolicitudesDescuentoCupon], [SolicitudesDescuento], [SolicitudesCostoXZona] FROM [Solicitudes]";
         AddWhere(sWhereString, "([MetodoPagosID] = @AV55MetodoPagosID)");
         if ( ! (0==AV11TFSolicitudesID) )
         {
            AddWhere(sWhereString, "([SolicitudesID] >= @AV11TFSolicitudesID)");
         }
         else
         {
            GXv_int4[1] = 1;
         }
         if ( ! (0==AV12TFSolicitudesID_To) )
         {
            AddWhere(sWhereString, "([SolicitudesID] <= @AV12TFSolicitudesID_To)");
         }
         else
         {
            GXv_int4[2] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV14TFSolicitudesNombre_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV13TFSolicitudesNombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER([SolicitudesNombre]) like UPPER(@lV13TFSolicitudesNombre))");
         }
         else
         {
            GXv_int4[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV14TFSolicitudesNombre_Sel)) && ! ( StringUtil.StrCmp(AV14TFSolicitudesNombre_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([SolicitudesNombre] = @AV14TFSolicitudesNombre_Sel)");
         }
         else
         {
            GXv_int4[4] = 1;
         }
         if ( StringUtil.StrCmp(AV14TFSolicitudesNombre_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([SolicitudesNombre] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV16TFSolicitudesTelefono_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV15TFSolicitudesTelefono)) ) )
         {
            AddWhere(sWhereString, "(UPPER([SolicitudesTelefono]) like UPPER(@lV15TFSolicitudesTelefono))");
         }
         else
         {
            GXv_int4[5] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV16TFSolicitudesTelefono_Sel)) && ! ( StringUtil.StrCmp(AV16TFSolicitudesTelefono_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([SolicitudesTelefono] = @AV16TFSolicitudesTelefono_Sel)");
         }
         else
         {
            GXv_int4[6] = 1;
         }
         if ( StringUtil.StrCmp(AV16TFSolicitudesTelefono_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([SolicitudesTelefono] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV18TFSolicitudesMail_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV17TFSolicitudesMail)) ) )
         {
            AddWhere(sWhereString, "(UPPER([SolicitudesMail]) like UPPER(@lV17TFSolicitudesMail))");
         }
         else
         {
            GXv_int4[7] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV18TFSolicitudesMail_Sel)) && ! ( StringUtil.StrCmp(AV18TFSolicitudesMail_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([SolicitudesMail] = @AV18TFSolicitudesMail_Sel)");
         }
         else
         {
            GXv_int4[8] = 1;
         }
         if ( StringUtil.StrCmp(AV18TFSolicitudesMail_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "([SolicitudesMail] IS NULL or ([SolicitudesMail] = ''))");
         }
         if ( ! (0==AV19TFDepartamentoId) )
         {
            AddWhere(sWhereString, "([DepartamentoId] >= @AV19TFDepartamentoId)");
         }
         else
         {
            GXv_int4[9] = 1;
         }
         if ( ! (0==AV20TFDepartamentoId_To) )
         {
            AddWhere(sWhereString, "([DepartamentoId] <= @AV20TFDepartamentoId_To)");
         }
         else
         {
            GXv_int4[10] = 1;
         }
         if ( ! (0==AV21TFDepartamentoMunicipioId) )
         {
            AddWhere(sWhereString, "([DepartamentoMunicipioId] >= @AV21TFDepartamentoMunicipioId)");
         }
         else
         {
            GXv_int4[11] = 1;
         }
         if ( ! (0==AV22TFDepartamentoMunicipioId_To) )
         {
            AddWhere(sWhereString, "([DepartamentoMunicipioId] <= @AV22TFDepartamentoMunicipioId_To)");
         }
         else
         {
            GXv_int4[12] = 1;
         }
         if ( ! (0==AV23TFZonasID) )
         {
            AddWhere(sWhereString, "([ZonasID] >= @AV23TFZonasID)");
         }
         else
         {
            GXv_int4[13] = 1;
         }
         if ( ! (0==AV24TFZonasID_To) )
         {
            AddWhere(sWhereString, "([ZonasID] <= @AV24TFZonasID_To)");
         }
         else
         {
            GXv_int4[14] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV26TFSolicitudesDireccion_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV25TFSolicitudesDireccion)) ) )
         {
            AddWhere(sWhereString, "(UPPER([SolicitudesDireccion]) like UPPER(@lV25TFSolicitudesDireccion))");
         }
         else
         {
            GXv_int4[15] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV26TFSolicitudesDireccion_Sel)) && ! ( StringUtil.StrCmp(AV26TFSolicitudesDireccion_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([SolicitudesDireccion] = @AV26TFSolicitudesDireccion_Sel)");
         }
         else
         {
            GXv_int4[16] = 1;
         }
         if ( StringUtil.StrCmp(AV26TFSolicitudesDireccion_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([SolicitudesDireccion] = ''))");
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV29TFSolicitudServicioSolCoti_Sel)) )
         {
            AddWhere(sWhereString, "([SolicitudServicioSolCoti] = @AV29TFSolicitudServicioSolCoti_Sel)");
         }
         else
         {
            GXv_int4[17] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY [MetodoPagosID], [SolicitudesTelefono]";
         GXv_Object5[0] = scmdbuf;
         GXv_Object5[1] = GXv_int4;
         return GXv_Object5 ;
      }

      protected Object[] conditional_P004J4( IGxContext context ,
                                             long AV11TFSolicitudesID ,
                                             long AV12TFSolicitudesID_To ,
                                             string AV14TFSolicitudesNombre_Sel ,
                                             string AV13TFSolicitudesNombre ,
                                             string AV16TFSolicitudesTelefono_Sel ,
                                             string AV15TFSolicitudesTelefono ,
                                             string AV18TFSolicitudesMail_Sel ,
                                             string AV17TFSolicitudesMail ,
                                             long AV19TFDepartamentoId ,
                                             long AV20TFDepartamentoId_To ,
                                             long AV21TFDepartamentoMunicipioId ,
                                             long AV22TFDepartamentoMunicipioId_To ,
                                             long AV23TFZonasID ,
                                             long AV24TFZonasID_To ,
                                             string AV26TFSolicitudesDireccion_Sel ,
                                             string AV25TFSolicitudesDireccion ,
                                             decimal AV27TFSolicitudesTotal ,
                                             decimal AV28TFSolicitudesTotal_To ,
                                             string AV29TFSolicitudServicioSolCoti_Sel ,
                                             long A127SolicitudesID ,
                                             string A171SolicitudesNombre ,
                                             string A172SolicitudesTelefono ,
                                             string A206SolicitudesMail ,
                                             long A112DepartamentoId ,
                                             long A114DepartamentoMunicipioId ,
                                             long A110ZonasID ,
                                             string A173SolicitudesDireccion ,
                                             decimal A174SolicitudesTotal ,
                                             string A210SolicitudServicioSolCoti ,
                                             string AV54FilterFullText ,
                                             decimal A211SolicitudServicioPFinal ,
                                             decimal AV30TFSolicitudServicioPFinal ,
                                             decimal AV31TFSolicitudServicioPFinal_To ,
                                             long AV55MetodoPagosID ,
                                             long A128MetodoPagosID )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int6 = new short[18];
         Object[] GXv_Object7 = new Object[2];
         scmdbuf = "SELECT [MetodoPagosID], [SolicitudesMail], [SolicitudServicioSolCoti], [SolicitudesDireccion], [ZonasID], [DepartamentoMunicipioId], [DepartamentoId], [SolicitudesTelefono], [SolicitudesNombre], [SolicitudesID], [SolicitudesComisionMetodoPago], [SolicitudesCotizacion], [SolicitudesDescuentoCupon], [SolicitudesDescuento], [SolicitudesCostoXZona] FROM [Solicitudes]";
         AddWhere(sWhereString, "([MetodoPagosID] = @AV55MetodoPagosID)");
         if ( ! (0==AV11TFSolicitudesID) )
         {
            AddWhere(sWhereString, "([SolicitudesID] >= @AV11TFSolicitudesID)");
         }
         else
         {
            GXv_int6[1] = 1;
         }
         if ( ! (0==AV12TFSolicitudesID_To) )
         {
            AddWhere(sWhereString, "([SolicitudesID] <= @AV12TFSolicitudesID_To)");
         }
         else
         {
            GXv_int6[2] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV14TFSolicitudesNombre_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV13TFSolicitudesNombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER([SolicitudesNombre]) like UPPER(@lV13TFSolicitudesNombre))");
         }
         else
         {
            GXv_int6[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV14TFSolicitudesNombre_Sel)) && ! ( StringUtil.StrCmp(AV14TFSolicitudesNombre_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([SolicitudesNombre] = @AV14TFSolicitudesNombre_Sel)");
         }
         else
         {
            GXv_int6[4] = 1;
         }
         if ( StringUtil.StrCmp(AV14TFSolicitudesNombre_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([SolicitudesNombre] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV16TFSolicitudesTelefono_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV15TFSolicitudesTelefono)) ) )
         {
            AddWhere(sWhereString, "(UPPER([SolicitudesTelefono]) like UPPER(@lV15TFSolicitudesTelefono))");
         }
         else
         {
            GXv_int6[5] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV16TFSolicitudesTelefono_Sel)) && ! ( StringUtil.StrCmp(AV16TFSolicitudesTelefono_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([SolicitudesTelefono] = @AV16TFSolicitudesTelefono_Sel)");
         }
         else
         {
            GXv_int6[6] = 1;
         }
         if ( StringUtil.StrCmp(AV16TFSolicitudesTelefono_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([SolicitudesTelefono] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV18TFSolicitudesMail_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV17TFSolicitudesMail)) ) )
         {
            AddWhere(sWhereString, "(UPPER([SolicitudesMail]) like UPPER(@lV17TFSolicitudesMail))");
         }
         else
         {
            GXv_int6[7] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV18TFSolicitudesMail_Sel)) && ! ( StringUtil.StrCmp(AV18TFSolicitudesMail_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([SolicitudesMail] = @AV18TFSolicitudesMail_Sel)");
         }
         else
         {
            GXv_int6[8] = 1;
         }
         if ( StringUtil.StrCmp(AV18TFSolicitudesMail_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "([SolicitudesMail] IS NULL or ([SolicitudesMail] = ''))");
         }
         if ( ! (0==AV19TFDepartamentoId) )
         {
            AddWhere(sWhereString, "([DepartamentoId] >= @AV19TFDepartamentoId)");
         }
         else
         {
            GXv_int6[9] = 1;
         }
         if ( ! (0==AV20TFDepartamentoId_To) )
         {
            AddWhere(sWhereString, "([DepartamentoId] <= @AV20TFDepartamentoId_To)");
         }
         else
         {
            GXv_int6[10] = 1;
         }
         if ( ! (0==AV21TFDepartamentoMunicipioId) )
         {
            AddWhere(sWhereString, "([DepartamentoMunicipioId] >= @AV21TFDepartamentoMunicipioId)");
         }
         else
         {
            GXv_int6[11] = 1;
         }
         if ( ! (0==AV22TFDepartamentoMunicipioId_To) )
         {
            AddWhere(sWhereString, "([DepartamentoMunicipioId] <= @AV22TFDepartamentoMunicipioId_To)");
         }
         else
         {
            GXv_int6[12] = 1;
         }
         if ( ! (0==AV23TFZonasID) )
         {
            AddWhere(sWhereString, "([ZonasID] >= @AV23TFZonasID)");
         }
         else
         {
            GXv_int6[13] = 1;
         }
         if ( ! (0==AV24TFZonasID_To) )
         {
            AddWhere(sWhereString, "([ZonasID] <= @AV24TFZonasID_To)");
         }
         else
         {
            GXv_int6[14] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV26TFSolicitudesDireccion_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV25TFSolicitudesDireccion)) ) )
         {
            AddWhere(sWhereString, "(UPPER([SolicitudesDireccion]) like UPPER(@lV25TFSolicitudesDireccion))");
         }
         else
         {
            GXv_int6[15] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV26TFSolicitudesDireccion_Sel)) && ! ( StringUtil.StrCmp(AV26TFSolicitudesDireccion_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([SolicitudesDireccion] = @AV26TFSolicitudesDireccion_Sel)");
         }
         else
         {
            GXv_int6[16] = 1;
         }
         if ( StringUtil.StrCmp(AV26TFSolicitudesDireccion_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([SolicitudesDireccion] = ''))");
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV29TFSolicitudServicioSolCoti_Sel)) )
         {
            AddWhere(sWhereString, "([SolicitudServicioSolCoti] = @AV29TFSolicitudServicioSolCoti_Sel)");
         }
         else
         {
            GXv_int6[17] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY [MetodoPagosID], [SolicitudesMail]";
         GXv_Object7[0] = scmdbuf;
         GXv_Object7[1] = GXv_int6;
         return GXv_Object7 ;
      }

      protected Object[] conditional_P004J5( IGxContext context ,
                                             long AV11TFSolicitudesID ,
                                             long AV12TFSolicitudesID_To ,
                                             string AV14TFSolicitudesNombre_Sel ,
                                             string AV13TFSolicitudesNombre ,
                                             string AV16TFSolicitudesTelefono_Sel ,
                                             string AV15TFSolicitudesTelefono ,
                                             string AV18TFSolicitudesMail_Sel ,
                                             string AV17TFSolicitudesMail ,
                                             long AV19TFDepartamentoId ,
                                             long AV20TFDepartamentoId_To ,
                                             long AV21TFDepartamentoMunicipioId ,
                                             long AV22TFDepartamentoMunicipioId_To ,
                                             long AV23TFZonasID ,
                                             long AV24TFZonasID_To ,
                                             string AV26TFSolicitudesDireccion_Sel ,
                                             string AV25TFSolicitudesDireccion ,
                                             decimal AV27TFSolicitudesTotal ,
                                             decimal AV28TFSolicitudesTotal_To ,
                                             string AV29TFSolicitudServicioSolCoti_Sel ,
                                             long A127SolicitudesID ,
                                             string A171SolicitudesNombre ,
                                             string A172SolicitudesTelefono ,
                                             string A206SolicitudesMail ,
                                             long A112DepartamentoId ,
                                             long A114DepartamentoMunicipioId ,
                                             long A110ZonasID ,
                                             string A173SolicitudesDireccion ,
                                             decimal A174SolicitudesTotal ,
                                             string A210SolicitudServicioSolCoti ,
                                             string AV54FilterFullText ,
                                             decimal A211SolicitudServicioPFinal ,
                                             decimal AV30TFSolicitudServicioPFinal ,
                                             decimal AV31TFSolicitudServicioPFinal_To ,
                                             long AV55MetodoPagosID ,
                                             long A128MetodoPagosID )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int8 = new short[18];
         Object[] GXv_Object9 = new Object[2];
         scmdbuf = "SELECT [MetodoPagosID], [SolicitudesDireccion], [SolicitudServicioSolCoti], [ZonasID], [DepartamentoMunicipioId], [DepartamentoId], [SolicitudesMail], [SolicitudesTelefono], [SolicitudesNombre], [SolicitudesID], [SolicitudesComisionMetodoPago], [SolicitudesCotizacion], [SolicitudesDescuentoCupon], [SolicitudesDescuento], [SolicitudesCostoXZona] FROM [Solicitudes]";
         AddWhere(sWhereString, "([MetodoPagosID] = @AV55MetodoPagosID)");
         if ( ! (0==AV11TFSolicitudesID) )
         {
            AddWhere(sWhereString, "([SolicitudesID] >= @AV11TFSolicitudesID)");
         }
         else
         {
            GXv_int8[1] = 1;
         }
         if ( ! (0==AV12TFSolicitudesID_To) )
         {
            AddWhere(sWhereString, "([SolicitudesID] <= @AV12TFSolicitudesID_To)");
         }
         else
         {
            GXv_int8[2] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV14TFSolicitudesNombre_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV13TFSolicitudesNombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER([SolicitudesNombre]) like UPPER(@lV13TFSolicitudesNombre))");
         }
         else
         {
            GXv_int8[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV14TFSolicitudesNombre_Sel)) && ! ( StringUtil.StrCmp(AV14TFSolicitudesNombre_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([SolicitudesNombre] = @AV14TFSolicitudesNombre_Sel)");
         }
         else
         {
            GXv_int8[4] = 1;
         }
         if ( StringUtil.StrCmp(AV14TFSolicitudesNombre_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([SolicitudesNombre] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV16TFSolicitudesTelefono_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV15TFSolicitudesTelefono)) ) )
         {
            AddWhere(sWhereString, "(UPPER([SolicitudesTelefono]) like UPPER(@lV15TFSolicitudesTelefono))");
         }
         else
         {
            GXv_int8[5] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV16TFSolicitudesTelefono_Sel)) && ! ( StringUtil.StrCmp(AV16TFSolicitudesTelefono_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([SolicitudesTelefono] = @AV16TFSolicitudesTelefono_Sel)");
         }
         else
         {
            GXv_int8[6] = 1;
         }
         if ( StringUtil.StrCmp(AV16TFSolicitudesTelefono_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([SolicitudesTelefono] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV18TFSolicitudesMail_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV17TFSolicitudesMail)) ) )
         {
            AddWhere(sWhereString, "(UPPER([SolicitudesMail]) like UPPER(@lV17TFSolicitudesMail))");
         }
         else
         {
            GXv_int8[7] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV18TFSolicitudesMail_Sel)) && ! ( StringUtil.StrCmp(AV18TFSolicitudesMail_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([SolicitudesMail] = @AV18TFSolicitudesMail_Sel)");
         }
         else
         {
            GXv_int8[8] = 1;
         }
         if ( StringUtil.StrCmp(AV18TFSolicitudesMail_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "([SolicitudesMail] IS NULL or ([SolicitudesMail] = ''))");
         }
         if ( ! (0==AV19TFDepartamentoId) )
         {
            AddWhere(sWhereString, "([DepartamentoId] >= @AV19TFDepartamentoId)");
         }
         else
         {
            GXv_int8[9] = 1;
         }
         if ( ! (0==AV20TFDepartamentoId_To) )
         {
            AddWhere(sWhereString, "([DepartamentoId] <= @AV20TFDepartamentoId_To)");
         }
         else
         {
            GXv_int8[10] = 1;
         }
         if ( ! (0==AV21TFDepartamentoMunicipioId) )
         {
            AddWhere(sWhereString, "([DepartamentoMunicipioId] >= @AV21TFDepartamentoMunicipioId)");
         }
         else
         {
            GXv_int8[11] = 1;
         }
         if ( ! (0==AV22TFDepartamentoMunicipioId_To) )
         {
            AddWhere(sWhereString, "([DepartamentoMunicipioId] <= @AV22TFDepartamentoMunicipioId_To)");
         }
         else
         {
            GXv_int8[12] = 1;
         }
         if ( ! (0==AV23TFZonasID) )
         {
            AddWhere(sWhereString, "([ZonasID] >= @AV23TFZonasID)");
         }
         else
         {
            GXv_int8[13] = 1;
         }
         if ( ! (0==AV24TFZonasID_To) )
         {
            AddWhere(sWhereString, "([ZonasID] <= @AV24TFZonasID_To)");
         }
         else
         {
            GXv_int8[14] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV26TFSolicitudesDireccion_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV25TFSolicitudesDireccion)) ) )
         {
            AddWhere(sWhereString, "(UPPER([SolicitudesDireccion]) like UPPER(@lV25TFSolicitudesDireccion))");
         }
         else
         {
            GXv_int8[15] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV26TFSolicitudesDireccion_Sel)) && ! ( StringUtil.StrCmp(AV26TFSolicitudesDireccion_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([SolicitudesDireccion] = @AV26TFSolicitudesDireccion_Sel)");
         }
         else
         {
            GXv_int8[16] = 1;
         }
         if ( StringUtil.StrCmp(AV26TFSolicitudesDireccion_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([SolicitudesDireccion] = ''))");
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV29TFSolicitudServicioSolCoti_Sel)) )
         {
            AddWhere(sWhereString, "([SolicitudServicioSolCoti] = @AV29TFSolicitudServicioSolCoti_Sel)");
         }
         else
         {
            GXv_int8[17] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY [MetodoPagosID], [SolicitudesDireccion]";
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
                     return conditional_P004J2(context, (long)dynConstraints[0] , (long)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (long)dynConstraints[8] , (long)dynConstraints[9] , (long)dynConstraints[10] , (long)dynConstraints[11] , (long)dynConstraints[12] , (long)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (decimal)dynConstraints[16] , (decimal)dynConstraints[17] , (string)dynConstraints[18] , (long)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (long)dynConstraints[23] , (long)dynConstraints[24] , (long)dynConstraints[25] , (string)dynConstraints[26] , (decimal)dynConstraints[27] , (string)dynConstraints[28] , (string)dynConstraints[29] , (decimal)dynConstraints[30] , (decimal)dynConstraints[31] , (decimal)dynConstraints[32] , (long)dynConstraints[33] , (long)dynConstraints[34] );
               case 1 :
                     return conditional_P004J3(context, (long)dynConstraints[0] , (long)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (long)dynConstraints[8] , (long)dynConstraints[9] , (long)dynConstraints[10] , (long)dynConstraints[11] , (long)dynConstraints[12] , (long)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (decimal)dynConstraints[16] , (decimal)dynConstraints[17] , (string)dynConstraints[18] , (long)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (long)dynConstraints[23] , (long)dynConstraints[24] , (long)dynConstraints[25] , (string)dynConstraints[26] , (decimal)dynConstraints[27] , (string)dynConstraints[28] , (string)dynConstraints[29] , (decimal)dynConstraints[30] , (decimal)dynConstraints[31] , (decimal)dynConstraints[32] , (long)dynConstraints[33] , (long)dynConstraints[34] );
               case 2 :
                     return conditional_P004J4(context, (long)dynConstraints[0] , (long)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (long)dynConstraints[8] , (long)dynConstraints[9] , (long)dynConstraints[10] , (long)dynConstraints[11] , (long)dynConstraints[12] , (long)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (decimal)dynConstraints[16] , (decimal)dynConstraints[17] , (string)dynConstraints[18] , (long)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (long)dynConstraints[23] , (long)dynConstraints[24] , (long)dynConstraints[25] , (string)dynConstraints[26] , (decimal)dynConstraints[27] , (string)dynConstraints[28] , (string)dynConstraints[29] , (decimal)dynConstraints[30] , (decimal)dynConstraints[31] , (decimal)dynConstraints[32] , (long)dynConstraints[33] , (long)dynConstraints[34] );
               case 3 :
                     return conditional_P004J5(context, (long)dynConstraints[0] , (long)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (long)dynConstraints[8] , (long)dynConstraints[9] , (long)dynConstraints[10] , (long)dynConstraints[11] , (long)dynConstraints[12] , (long)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (decimal)dynConstraints[16] , (decimal)dynConstraints[17] , (string)dynConstraints[18] , (long)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (long)dynConstraints[23] , (long)dynConstraints[24] , (long)dynConstraints[25] , (string)dynConstraints[26] , (decimal)dynConstraints[27] , (string)dynConstraints[28] , (string)dynConstraints[29] , (decimal)dynConstraints[30] , (decimal)dynConstraints[31] , (decimal)dynConstraints[32] , (long)dynConstraints[33] , (long)dynConstraints[34] );
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
          Object[] prmP004J6;
          prmP004J6 = new Object[] {
          new ParDef("@SolicitudesID",GXType.Decimal,18,0)
          };
          Object[] prmP004J2;
          prmP004J2 = new Object[] {
          new ParDef("@AV55MetodoPagosID",GXType.Decimal,18,0) ,
          new ParDef("@AV11TFSolicitudesID",GXType.Decimal,18,0) ,
          new ParDef("@AV12TFSolicitudesID_To",GXType.Decimal,18,0) ,
          new ParDef("@lV13TFSolicitudesNombre",GXType.Char,100,0) ,
          new ParDef("@AV14TFSolicitudesNombre_Sel",GXType.NChar,100,0) ,
          new ParDef("@lV15TFSolicitudesTelefono",GXType.Char,20,0) ,
          new ParDef("@AV16TFSolicitudesTelefono_Sel",GXType.NChar,20,0) ,
          new ParDef("@lV17TFSolicitudesMail",GXType.VarChar,100,0) ,
          new ParDef("@AV18TFSolicitudesMail_Sel",GXType.NVarChar,100,0) ,
          new ParDef("@AV19TFDepartamentoId",GXType.Decimal,18,0) ,
          new ParDef("@AV20TFDepartamentoId_To",GXType.Decimal,18,0) ,
          new ParDef("@AV21TFDepartamentoMunicipioId",GXType.Decimal,18,0) ,
          new ParDef("@AV22TFDepartamentoMunicipioId_To",GXType.Decimal,18,0) ,
          new ParDef("@AV23TFZonasID",GXType.Decimal,18,0) ,
          new ParDef("@AV24TFZonasID_To",GXType.Decimal,18,0) ,
          new ParDef("@lV25TFSolicitudesDireccion",GXType.VarChar,1024,0) ,
          new ParDef("@AV26TFSolicitudesDireccion_Sel",GXType.NVarChar,1024,0) ,
          new ParDef("@AV29TFSolicitudServicioSolCoti_Sel",GXType.NChar,1,0)
          };
          Object[] prmP004J3;
          prmP004J3 = new Object[] {
          new ParDef("@AV55MetodoPagosID",GXType.Decimal,18,0) ,
          new ParDef("@AV11TFSolicitudesID",GXType.Decimal,18,0) ,
          new ParDef("@AV12TFSolicitudesID_To",GXType.Decimal,18,0) ,
          new ParDef("@lV13TFSolicitudesNombre",GXType.Char,100,0) ,
          new ParDef("@AV14TFSolicitudesNombre_Sel",GXType.NChar,100,0) ,
          new ParDef("@lV15TFSolicitudesTelefono",GXType.Char,20,0) ,
          new ParDef("@AV16TFSolicitudesTelefono_Sel",GXType.NChar,20,0) ,
          new ParDef("@lV17TFSolicitudesMail",GXType.VarChar,100,0) ,
          new ParDef("@AV18TFSolicitudesMail_Sel",GXType.NVarChar,100,0) ,
          new ParDef("@AV19TFDepartamentoId",GXType.Decimal,18,0) ,
          new ParDef("@AV20TFDepartamentoId_To",GXType.Decimal,18,0) ,
          new ParDef("@AV21TFDepartamentoMunicipioId",GXType.Decimal,18,0) ,
          new ParDef("@AV22TFDepartamentoMunicipioId_To",GXType.Decimal,18,0) ,
          new ParDef("@AV23TFZonasID",GXType.Decimal,18,0) ,
          new ParDef("@AV24TFZonasID_To",GXType.Decimal,18,0) ,
          new ParDef("@lV25TFSolicitudesDireccion",GXType.VarChar,1024,0) ,
          new ParDef("@AV26TFSolicitudesDireccion_Sel",GXType.NVarChar,1024,0) ,
          new ParDef("@AV29TFSolicitudServicioSolCoti_Sel",GXType.NChar,1,0)
          };
          Object[] prmP004J4;
          prmP004J4 = new Object[] {
          new ParDef("@AV55MetodoPagosID",GXType.Decimal,18,0) ,
          new ParDef("@AV11TFSolicitudesID",GXType.Decimal,18,0) ,
          new ParDef("@AV12TFSolicitudesID_To",GXType.Decimal,18,0) ,
          new ParDef("@lV13TFSolicitudesNombre",GXType.Char,100,0) ,
          new ParDef("@AV14TFSolicitudesNombre_Sel",GXType.NChar,100,0) ,
          new ParDef("@lV15TFSolicitudesTelefono",GXType.Char,20,0) ,
          new ParDef("@AV16TFSolicitudesTelefono_Sel",GXType.NChar,20,0) ,
          new ParDef("@lV17TFSolicitudesMail",GXType.VarChar,100,0) ,
          new ParDef("@AV18TFSolicitudesMail_Sel",GXType.NVarChar,100,0) ,
          new ParDef("@AV19TFDepartamentoId",GXType.Decimal,18,0) ,
          new ParDef("@AV20TFDepartamentoId_To",GXType.Decimal,18,0) ,
          new ParDef("@AV21TFDepartamentoMunicipioId",GXType.Decimal,18,0) ,
          new ParDef("@AV22TFDepartamentoMunicipioId_To",GXType.Decimal,18,0) ,
          new ParDef("@AV23TFZonasID",GXType.Decimal,18,0) ,
          new ParDef("@AV24TFZonasID_To",GXType.Decimal,18,0) ,
          new ParDef("@lV25TFSolicitudesDireccion",GXType.VarChar,1024,0) ,
          new ParDef("@AV26TFSolicitudesDireccion_Sel",GXType.NVarChar,1024,0) ,
          new ParDef("@AV29TFSolicitudServicioSolCoti_Sel",GXType.NChar,1,0)
          };
          Object[] prmP004J5;
          prmP004J5 = new Object[] {
          new ParDef("@AV55MetodoPagosID",GXType.Decimal,18,0) ,
          new ParDef("@AV11TFSolicitudesID",GXType.Decimal,18,0) ,
          new ParDef("@AV12TFSolicitudesID_To",GXType.Decimal,18,0) ,
          new ParDef("@lV13TFSolicitudesNombre",GXType.Char,100,0) ,
          new ParDef("@AV14TFSolicitudesNombre_Sel",GXType.NChar,100,0) ,
          new ParDef("@lV15TFSolicitudesTelefono",GXType.Char,20,0) ,
          new ParDef("@AV16TFSolicitudesTelefono_Sel",GXType.NChar,20,0) ,
          new ParDef("@lV17TFSolicitudesMail",GXType.VarChar,100,0) ,
          new ParDef("@AV18TFSolicitudesMail_Sel",GXType.NVarChar,100,0) ,
          new ParDef("@AV19TFDepartamentoId",GXType.Decimal,18,0) ,
          new ParDef("@AV20TFDepartamentoId_To",GXType.Decimal,18,0) ,
          new ParDef("@AV21TFDepartamentoMunicipioId",GXType.Decimal,18,0) ,
          new ParDef("@AV22TFDepartamentoMunicipioId_To",GXType.Decimal,18,0) ,
          new ParDef("@AV23TFZonasID",GXType.Decimal,18,0) ,
          new ParDef("@AV24TFZonasID_To",GXType.Decimal,18,0) ,
          new ParDef("@lV25TFSolicitudesDireccion",GXType.VarChar,1024,0) ,
          new ParDef("@AV26TFSolicitudesDireccion_Sel",GXType.NVarChar,1024,0) ,
          new ParDef("@AV29TFSolicitudServicioSolCoti_Sel",GXType.NChar,1,0)
          };
          def= new CursorDef[] {
              new CursorDef("P004J2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP004J2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P004J3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP004J3,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P004J4", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP004J4,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P004J5", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP004J5,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P004J6", "SELECT [SolicitudesID], [SolicitudesItemsID], [SolicitudItemsComision], [SolicitudItemsComisionTipo], [SolicitudItemsSR], [SolicitudesItemsCantidad], [SolicitudesItemsPrecioFinal] FROM [SolicitudesItems] WHERE [SolicitudesID] = @SolicitudesID ORDER BY [SolicitudesID] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP004J6,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[2])[0] = rslt.getString(3, 1);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((long[]) buf[4])[0] = rslt.getLong(5);
                ((bool[]) buf[5])[0] = rslt.wasNull(5);
                ((long[]) buf[6])[0] = rslt.getLong(6);
                ((bool[]) buf[7])[0] = rslt.wasNull(6);
                ((long[]) buf[8])[0] = rslt.getLong(7);
                ((bool[]) buf[9])[0] = rslt.wasNull(7);
                ((string[]) buf[10])[0] = rslt.getVarchar(8);
                ((bool[]) buf[11])[0] = rslt.wasNull(8);
                ((string[]) buf[12])[0] = rslt.getString(9, 20);
                ((long[]) buf[13])[0] = rslt.getLong(10);
                ((decimal[]) buf[14])[0] = rslt.getDecimal(11);
                ((decimal[]) buf[15])[0] = rslt.getDecimal(12);
                ((decimal[]) buf[16])[0] = rslt.getDecimal(13);
                ((decimal[]) buf[17])[0] = rslt.getDecimal(14);
                ((bool[]) buf[18])[0] = rslt.wasNull(14);
                ((decimal[]) buf[19])[0] = rslt.getDecimal(15);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 20);
                ((string[]) buf[2])[0] = rslt.getString(3, 1);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((long[]) buf[4])[0] = rslt.getLong(5);
                ((bool[]) buf[5])[0] = rslt.wasNull(5);
                ((long[]) buf[6])[0] = rslt.getLong(6);
                ((bool[]) buf[7])[0] = rslt.wasNull(6);
                ((long[]) buf[8])[0] = rslt.getLong(7);
                ((bool[]) buf[9])[0] = rslt.wasNull(7);
                ((string[]) buf[10])[0] = rslt.getVarchar(8);
                ((bool[]) buf[11])[0] = rslt.wasNull(8);
                ((string[]) buf[12])[0] = rslt.getString(9, 100);
                ((long[]) buf[13])[0] = rslt.getLong(10);
                ((decimal[]) buf[14])[0] = rslt.getDecimal(11);
                ((decimal[]) buf[15])[0] = rslt.getDecimal(12);
                ((decimal[]) buf[16])[0] = rslt.getDecimal(13);
                ((decimal[]) buf[17])[0] = rslt.getDecimal(14);
                ((bool[]) buf[18])[0] = rslt.wasNull(14);
                ((decimal[]) buf[19])[0] = rslt.getDecimal(15);
                return;
             case 2 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getString(3, 1);
                ((string[]) buf[4])[0] = rslt.getVarchar(4);
                ((long[]) buf[5])[0] = rslt.getLong(5);
                ((bool[]) buf[6])[0] = rslt.wasNull(5);
                ((long[]) buf[7])[0] = rslt.getLong(6);
                ((bool[]) buf[8])[0] = rslt.wasNull(6);
                ((long[]) buf[9])[0] = rslt.getLong(7);
                ((bool[]) buf[10])[0] = rslt.wasNull(7);
                ((string[]) buf[11])[0] = rslt.getString(8, 20);
                ((string[]) buf[12])[0] = rslt.getString(9, 100);
                ((long[]) buf[13])[0] = rslt.getLong(10);
                ((decimal[]) buf[14])[0] = rslt.getDecimal(11);
                ((decimal[]) buf[15])[0] = rslt.getDecimal(12);
                ((decimal[]) buf[16])[0] = rslt.getDecimal(13);
                ((decimal[]) buf[17])[0] = rslt.getDecimal(14);
                ((bool[]) buf[18])[0] = rslt.wasNull(14);
                ((decimal[]) buf[19])[0] = rslt.getDecimal(15);
                return;
             case 3 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 1);
                ((long[]) buf[3])[0] = rslt.getLong(4);
                ((bool[]) buf[4])[0] = rslt.wasNull(4);
                ((long[]) buf[5])[0] = rslt.getLong(5);
                ((bool[]) buf[6])[0] = rslt.wasNull(5);
                ((long[]) buf[7])[0] = rslt.getLong(6);
                ((bool[]) buf[8])[0] = rslt.wasNull(6);
                ((string[]) buf[9])[0] = rslt.getVarchar(7);
                ((bool[]) buf[10])[0] = rslt.wasNull(7);
                ((string[]) buf[11])[0] = rslt.getString(8, 20);
                ((string[]) buf[12])[0] = rslt.getString(9, 100);
                ((long[]) buf[13])[0] = rslt.getLong(10);
                ((decimal[]) buf[14])[0] = rslt.getDecimal(11);
                ((decimal[]) buf[15])[0] = rslt.getDecimal(12);
                ((decimal[]) buf[16])[0] = rslt.getDecimal(13);
                ((decimal[]) buf[17])[0] = rslt.getDecimal(14);
                ((bool[]) buf[18])[0] = rslt.wasNull(14);
                ((decimal[]) buf[19])[0] = rslt.getDecimal(15);
                return;
             case 4 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((decimal[]) buf[2])[0] = rslt.getDecimal(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 1);
                ((string[]) buf[4])[0] = rslt.getString(5, 1);
                ((short[]) buf[5])[0] = rslt.getShort(6);
                ((decimal[]) buf[6])[0] = rslt.getDecimal(7);
                ((bool[]) buf[7])[0] = rslt.wasNull(7);
                return;
       }
    }

 }

 [ServiceContract(Namespace = "GeneXus.Programs.metodopagossolicitudeswcgetfilterdata_services")]
 [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple)]
 [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
 public class metodopagossolicitudeswcgetfilterdata_services : GxRestService
 {
    [OperationContract(Name = "MetodoPagosSolicitudesWCGetFilterData" )]
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
          if ( ! ProcessHeaders("metodopagossolicitudeswcgetfilterdata") )
          {
             return  ;
          }
          metodopagossolicitudeswcgetfilterdata worker = new metodopagossolicitudeswcgetfilterdata(context);
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

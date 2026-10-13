using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using System.Web.Services.Protocols;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Reflection;
using System.Xml.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   [XmlSerializerFormat]
   [XmlRoot(ElementName = "Wallet.Balances" )]
   [XmlType(TypeName =  "Wallet.Balances" , Namespace = "AlmangoX" )]
   [Serializable]
   public class SdtWallet_Balances : GxSilentTrnSdt, IGxSilentTrnGridItem
   {
      public SdtWallet_Balances( )
      {
      }

      public SdtWallet_Balances( IGxContext context )
      {
         this.context = context;
         constructorCallingAssembly = Assembly.GetCallingAssembly();
         initialize();
      }

      private static Hashtable mapper;
      public override string JsonMap( string value )
      {
         if ( mapper == null )
         {
            mapper = new Hashtable();
         }
         return (string)mapper[value]; ;
      }

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"WalletBalancesId", typeof(long)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "Balances");
         metadata.Set("BT", "WalletBalances");
         metadata.Set("PK", "[ \"WalletBalancesId\" ]");
         metadata.Set("FKList", "[ { \"FK\":[ \"WalletId\" ],\"FKMap\":[  ] } ]");
         metadata.Set("AllowInsert", "True");
         metadata.Set("AllowUpdate", "True");
         metadata.Set("AllowDelete", "True");
         return metadata ;
      }

      public override GeneXus.Utils.GxStringCollection StateAttributes( )
      {
         GeneXus.Utils.GxStringCollection state = new GeneXus.Utils.GxStringCollection();
         state.Add("gxTpr_Mode");
         state.Add("gxTpr_Modified");
         state.Add("gxTpr_Initialized");
         state.Add("gxTpr_Walletbalancesid_Z");
         state.Add("gxTpr_Walletbalancesfechaalta_Z_Nullable");
         state.Add("gxTpr_Walletbalancesusralta_Z");
         state.Add("gxTpr_Walletbalancestipomov_Z");
         state.Add("gxTpr_Walletbalancesimporte_Z");
         state.Add("gxTpr_Walletbalancesobs_Z");
         state.Add("gxTpr_Walletbalancesconcepto_Z");
         state.Add("gxTpr_Walletbalancesurl_Z");
         state.Add("gxTpr_Walletbalancesestadoope_Z");
         state.Add("gxTpr_Walletbalanceliquidacion_Z");
         state.Add("gxTpr_Walletbalancesobs_N");
         state.Add("gxTpr_Walletbalancesconcepto_N");
         state.Add("gxTpr_Walletbalancesurl_N");
         state.Add("gxTpr_Walletbalanceliquidacion_N");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         SdtWallet_Balances sdt;
         sdt = (SdtWallet_Balances)(source);
         gxTv_SdtWallet_Balances_Walletbalancesid = sdt.gxTv_SdtWallet_Balances_Walletbalancesid ;
         gxTv_SdtWallet_Balances_Walletbalancesfechaalta = sdt.gxTv_SdtWallet_Balances_Walletbalancesfechaalta ;
         gxTv_SdtWallet_Balances_Walletbalancesusralta = sdt.gxTv_SdtWallet_Balances_Walletbalancesusralta ;
         gxTv_SdtWallet_Balances_Walletbalancestipomov = sdt.gxTv_SdtWallet_Balances_Walletbalancestipomov ;
         gxTv_SdtWallet_Balances_Walletbalancesimporte = sdt.gxTv_SdtWallet_Balances_Walletbalancesimporte ;
         gxTv_SdtWallet_Balances_Walletbalancesobs = sdt.gxTv_SdtWallet_Balances_Walletbalancesobs ;
         gxTv_SdtWallet_Balances_Walletbalancesconcepto = sdt.gxTv_SdtWallet_Balances_Walletbalancesconcepto ;
         gxTv_SdtWallet_Balances_Walletbalancesurl = sdt.gxTv_SdtWallet_Balances_Walletbalancesurl ;
         gxTv_SdtWallet_Balances_Walletbalancesestadoope = sdt.gxTv_SdtWallet_Balances_Walletbalancesestadoope ;
         gxTv_SdtWallet_Balances_Walletbalanceliquidacion = sdt.gxTv_SdtWallet_Balances_Walletbalanceliquidacion ;
         gxTv_SdtWallet_Balances_Mode = sdt.gxTv_SdtWallet_Balances_Mode ;
         gxTv_SdtWallet_Balances_Modified = sdt.gxTv_SdtWallet_Balances_Modified ;
         gxTv_SdtWallet_Balances_Initialized = sdt.gxTv_SdtWallet_Balances_Initialized ;
         gxTv_SdtWallet_Balances_Walletbalancesid_Z = sdt.gxTv_SdtWallet_Balances_Walletbalancesid_Z ;
         gxTv_SdtWallet_Balances_Walletbalancesfechaalta_Z = sdt.gxTv_SdtWallet_Balances_Walletbalancesfechaalta_Z ;
         gxTv_SdtWallet_Balances_Walletbalancesusralta_Z = sdt.gxTv_SdtWallet_Balances_Walletbalancesusralta_Z ;
         gxTv_SdtWallet_Balances_Walletbalancestipomov_Z = sdt.gxTv_SdtWallet_Balances_Walletbalancestipomov_Z ;
         gxTv_SdtWallet_Balances_Walletbalancesimporte_Z = sdt.gxTv_SdtWallet_Balances_Walletbalancesimporte_Z ;
         gxTv_SdtWallet_Balances_Walletbalancesobs_Z = sdt.gxTv_SdtWallet_Balances_Walletbalancesobs_Z ;
         gxTv_SdtWallet_Balances_Walletbalancesconcepto_Z = sdt.gxTv_SdtWallet_Balances_Walletbalancesconcepto_Z ;
         gxTv_SdtWallet_Balances_Walletbalancesurl_Z = sdt.gxTv_SdtWallet_Balances_Walletbalancesurl_Z ;
         gxTv_SdtWallet_Balances_Walletbalancesestadoope_Z = sdt.gxTv_SdtWallet_Balances_Walletbalancesestadoope_Z ;
         gxTv_SdtWallet_Balances_Walletbalanceliquidacion_Z = sdt.gxTv_SdtWallet_Balances_Walletbalanceliquidacion_Z ;
         gxTv_SdtWallet_Balances_Walletbalancesobs_N = sdt.gxTv_SdtWallet_Balances_Walletbalancesobs_N ;
         gxTv_SdtWallet_Balances_Walletbalancesconcepto_N = sdt.gxTv_SdtWallet_Balances_Walletbalancesconcepto_N ;
         gxTv_SdtWallet_Balances_Walletbalancesurl_N = sdt.gxTv_SdtWallet_Balances_Walletbalancesurl_N ;
         gxTv_SdtWallet_Balances_Walletbalanceliquidacion_N = sdt.gxTv_SdtWallet_Balances_Walletbalanceliquidacion_N ;
         return  ;
      }

      public override void ToJSON( )
      {
         ToJSON( true) ;
         return  ;
      }

      public override void ToJSON( bool includeState )
      {
         ToJSON( includeState, true) ;
         return  ;
      }

      public override void ToJSON( bool includeState ,
                                   bool includeNonInitialized )
      {
         AddObjectProperty("WalletBalancesId", StringUtil.LTrim( StringUtil.Str( (decimal)(gxTv_SdtWallet_Balances_Walletbalancesid), 18, 0)), false, includeNonInitialized);
         datetime_STZ = gxTv_SdtWallet_Balances_Walletbalancesfechaalta;
         sDateCnv = "";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( datetime_STZ)), 10, 0));
         sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( datetime_STZ)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( datetime_STZ)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "T";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Hour( datetime_STZ)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += ":";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Minute( datetime_STZ)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += ":";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Second( datetime_STZ)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         AddObjectProperty("WalletBalancesFechaAlta", sDateCnv, false, includeNonInitialized);
         AddObjectProperty("WalletBalancesUsrAlta", gxTv_SdtWallet_Balances_Walletbalancesusralta, false, includeNonInitialized);
         AddObjectProperty("WalletBalancesTipoMov", gxTv_SdtWallet_Balances_Walletbalancestipomov, false, includeNonInitialized);
         AddObjectProperty("WalletBalancesImporte", StringUtil.LTrim( StringUtil.Str( gxTv_SdtWallet_Balances_Walletbalancesimporte, 18, 2)), false, includeNonInitialized);
         AddObjectProperty("WalletBalancesObs", gxTv_SdtWallet_Balances_Walletbalancesobs, false, includeNonInitialized);
         AddObjectProperty("WalletBalancesObs_N", gxTv_SdtWallet_Balances_Walletbalancesobs_N, false, includeNonInitialized);
         AddObjectProperty("WalletBalancesConcepto", gxTv_SdtWallet_Balances_Walletbalancesconcepto, false, includeNonInitialized);
         AddObjectProperty("WalletBalancesConcepto_N", gxTv_SdtWallet_Balances_Walletbalancesconcepto_N, false, includeNonInitialized);
         AddObjectProperty("WalletBalancesUrl", gxTv_SdtWallet_Balances_Walletbalancesurl, false, includeNonInitialized);
         AddObjectProperty("WalletBalancesUrl_N", gxTv_SdtWallet_Balances_Walletbalancesurl_N, false, includeNonInitialized);
         AddObjectProperty("WalletBalancesEstadoOPE", gxTv_SdtWallet_Balances_Walletbalancesestadoope, false, includeNonInitialized);
         AddObjectProperty("WalletBalanceLiquidacion", StringUtil.LTrim( StringUtil.Str( (decimal)(gxTv_SdtWallet_Balances_Walletbalanceliquidacion), 18, 0)), false, includeNonInitialized);
         AddObjectProperty("WalletBalanceLiquidacion_N", gxTv_SdtWallet_Balances_Walletbalanceliquidacion_N, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_SdtWallet_Balances_Mode, false, includeNonInitialized);
            AddObjectProperty("Modified", gxTv_SdtWallet_Balances_Modified, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtWallet_Balances_Initialized, false, includeNonInitialized);
            AddObjectProperty("WalletBalancesId_Z", StringUtil.LTrim( StringUtil.Str( (decimal)(gxTv_SdtWallet_Balances_Walletbalancesid_Z), 18, 0)), false, includeNonInitialized);
            datetime_STZ = gxTv_SdtWallet_Balances_Walletbalancesfechaalta_Z;
            sDateCnv = "";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( datetime_STZ)), 10, 0));
            sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( datetime_STZ)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( datetime_STZ)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "T";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Hour( datetime_STZ)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += ":";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Minute( datetime_STZ)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += ":";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Second( datetime_STZ)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            AddObjectProperty("WalletBalancesFechaAlta_Z", sDateCnv, false, includeNonInitialized);
            AddObjectProperty("WalletBalancesUsrAlta_Z", gxTv_SdtWallet_Balances_Walletbalancesusralta_Z, false, includeNonInitialized);
            AddObjectProperty("WalletBalancesTipoMov_Z", gxTv_SdtWallet_Balances_Walletbalancestipomov_Z, false, includeNonInitialized);
            AddObjectProperty("WalletBalancesImporte_Z", StringUtil.LTrim( StringUtil.Str( gxTv_SdtWallet_Balances_Walletbalancesimporte_Z, 18, 2)), false, includeNonInitialized);
            AddObjectProperty("WalletBalancesObs_Z", gxTv_SdtWallet_Balances_Walletbalancesobs_Z, false, includeNonInitialized);
            AddObjectProperty("WalletBalancesConcepto_Z", gxTv_SdtWallet_Balances_Walletbalancesconcepto_Z, false, includeNonInitialized);
            AddObjectProperty("WalletBalancesUrl_Z", gxTv_SdtWallet_Balances_Walletbalancesurl_Z, false, includeNonInitialized);
            AddObjectProperty("WalletBalancesEstadoOPE_Z", gxTv_SdtWallet_Balances_Walletbalancesestadoope_Z, false, includeNonInitialized);
            AddObjectProperty("WalletBalanceLiquidacion_Z", StringUtil.LTrim( StringUtil.Str( (decimal)(gxTv_SdtWallet_Balances_Walletbalanceliquidacion_Z), 18, 0)), false, includeNonInitialized);
            AddObjectProperty("WalletBalancesObs_N", gxTv_SdtWallet_Balances_Walletbalancesobs_N, false, includeNonInitialized);
            AddObjectProperty("WalletBalancesConcepto_N", gxTv_SdtWallet_Balances_Walletbalancesconcepto_N, false, includeNonInitialized);
            AddObjectProperty("WalletBalancesUrl_N", gxTv_SdtWallet_Balances_Walletbalancesurl_N, false, includeNonInitialized);
            AddObjectProperty("WalletBalanceLiquidacion_N", gxTv_SdtWallet_Balances_Walletbalanceliquidacion_N, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( SdtWallet_Balances sdt )
      {
         if ( sdt.IsDirty("WalletBalancesId") )
         {
            sdtIsNull = 0;
            gxTv_SdtWallet_Balances_Walletbalancesid = sdt.gxTv_SdtWallet_Balances_Walletbalancesid ;
         }
         if ( sdt.IsDirty("WalletBalancesFechaAlta") )
         {
            sdtIsNull = 0;
            gxTv_SdtWallet_Balances_Walletbalancesfechaalta = sdt.gxTv_SdtWallet_Balances_Walletbalancesfechaalta ;
         }
         if ( sdt.IsDirty("WalletBalancesUsrAlta") )
         {
            sdtIsNull = 0;
            gxTv_SdtWallet_Balances_Walletbalancesusralta = sdt.gxTv_SdtWallet_Balances_Walletbalancesusralta ;
         }
         if ( sdt.IsDirty("WalletBalancesTipoMov") )
         {
            sdtIsNull = 0;
            gxTv_SdtWallet_Balances_Walletbalancestipomov = sdt.gxTv_SdtWallet_Balances_Walletbalancestipomov ;
         }
         if ( sdt.IsDirty("WalletBalancesImporte") )
         {
            sdtIsNull = 0;
            gxTv_SdtWallet_Balances_Walletbalancesimporte = sdt.gxTv_SdtWallet_Balances_Walletbalancesimporte ;
         }
         if ( sdt.IsDirty("WalletBalancesObs") )
         {
            gxTv_SdtWallet_Balances_Walletbalancesobs_N = (short)(sdt.gxTv_SdtWallet_Balances_Walletbalancesobs_N);
            sdtIsNull = 0;
            gxTv_SdtWallet_Balances_Walletbalancesobs = sdt.gxTv_SdtWallet_Balances_Walletbalancesobs ;
         }
         if ( sdt.IsDirty("WalletBalancesConcepto") )
         {
            gxTv_SdtWallet_Balances_Walletbalancesconcepto_N = (short)(sdt.gxTv_SdtWallet_Balances_Walletbalancesconcepto_N);
            sdtIsNull = 0;
            gxTv_SdtWallet_Balances_Walletbalancesconcepto = sdt.gxTv_SdtWallet_Balances_Walletbalancesconcepto ;
         }
         if ( sdt.IsDirty("WalletBalancesUrl") )
         {
            gxTv_SdtWallet_Balances_Walletbalancesurl_N = (short)(sdt.gxTv_SdtWallet_Balances_Walletbalancesurl_N);
            sdtIsNull = 0;
            gxTv_SdtWallet_Balances_Walletbalancesurl = sdt.gxTv_SdtWallet_Balances_Walletbalancesurl ;
         }
         if ( sdt.IsDirty("WalletBalancesEstadoOPE") )
         {
            sdtIsNull = 0;
            gxTv_SdtWallet_Balances_Walletbalancesestadoope = sdt.gxTv_SdtWallet_Balances_Walletbalancesestadoope ;
         }
         if ( sdt.IsDirty("WalletBalanceLiquidacion") )
         {
            gxTv_SdtWallet_Balances_Walletbalanceliquidacion_N = (short)(sdt.gxTv_SdtWallet_Balances_Walletbalanceliquidacion_N);
            sdtIsNull = 0;
            gxTv_SdtWallet_Balances_Walletbalanceliquidacion = sdt.gxTv_SdtWallet_Balances_Walletbalanceliquidacion ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "WalletBalancesId" )]
      [  XmlElement( ElementName = "WalletBalancesId"   )]
      public long gxTpr_Walletbalancesid
      {
         get {
            return gxTv_SdtWallet_Balances_Walletbalancesid ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtWallet_Balances_Walletbalancesid = value;
            gxTv_SdtWallet_Balances_Modified = 1;
            SetDirty("Walletbalancesid");
         }

      }

      [  SoapElement( ElementName = "WalletBalancesFechaAlta" )]
      [  XmlElement( ElementName = "WalletBalancesFechaAlta"  , IsNullable=true )]
      public string gxTpr_Walletbalancesfechaalta_Nullable
      {
         get {
            if ( gxTv_SdtWallet_Balances_Walletbalancesfechaalta == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtWallet_Balances_Walletbalancesfechaalta).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtWallet_Balances_Walletbalancesfechaalta = DateTime.MinValue;
            else
               gxTv_SdtWallet_Balances_Walletbalancesfechaalta = DateTime.Parse( value);
            gxTv_SdtWallet_Balances_Modified = 1;
         }

      }

      [SoapIgnore]
      [XmlIgnore]
      public DateTime gxTpr_Walletbalancesfechaalta
      {
         get {
            return gxTv_SdtWallet_Balances_Walletbalancesfechaalta ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtWallet_Balances_Walletbalancesfechaalta = value;
            gxTv_SdtWallet_Balances_Modified = 1;
            SetDirty("Walletbalancesfechaalta");
         }

      }

      [  SoapElement( ElementName = "WalletBalancesUsrAlta" )]
      [  XmlElement( ElementName = "WalletBalancesUsrAlta"   )]
      public long gxTpr_Walletbalancesusralta
      {
         get {
            return gxTv_SdtWallet_Balances_Walletbalancesusralta ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtWallet_Balances_Walletbalancesusralta = value;
            gxTv_SdtWallet_Balances_Modified = 1;
            SetDirty("Walletbalancesusralta");
         }

      }

      [  SoapElement( ElementName = "WalletBalancesTipoMov" )]
      [  XmlElement( ElementName = "WalletBalancesTipoMov"   )]
      public string gxTpr_Walletbalancestipomov
      {
         get {
            return gxTv_SdtWallet_Balances_Walletbalancestipomov ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtWallet_Balances_Walletbalancestipomov = value;
            gxTv_SdtWallet_Balances_Modified = 1;
            SetDirty("Walletbalancestipomov");
         }

      }

      [  SoapElement( ElementName = "WalletBalancesImporte" )]
      [  XmlElement( ElementName = "WalletBalancesImporte"   )]
      public decimal gxTpr_Walletbalancesimporte
      {
         get {
            return gxTv_SdtWallet_Balances_Walletbalancesimporte ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtWallet_Balances_Walletbalancesimporte = value;
            gxTv_SdtWallet_Balances_Modified = 1;
            SetDirty("Walletbalancesimporte");
         }

      }

      [  SoapElement( ElementName = "WalletBalancesObs" )]
      [  XmlElement( ElementName = "WalletBalancesObs"   )]
      public string gxTpr_Walletbalancesobs
      {
         get {
            return gxTv_SdtWallet_Balances_Walletbalancesobs ;
         }

         set {
            gxTv_SdtWallet_Balances_Walletbalancesobs_N = 0;
            sdtIsNull = 0;
            gxTv_SdtWallet_Balances_Walletbalancesobs = value;
            gxTv_SdtWallet_Balances_Modified = 1;
            SetDirty("Walletbalancesobs");
         }

      }

      public void gxTv_SdtWallet_Balances_Walletbalancesobs_SetNull( )
      {
         gxTv_SdtWallet_Balances_Walletbalancesobs_N = 1;
         gxTv_SdtWallet_Balances_Walletbalancesobs = "";
         SetDirty("Walletbalancesobs");
         return  ;
      }

      public bool gxTv_SdtWallet_Balances_Walletbalancesobs_IsNull( )
      {
         return (gxTv_SdtWallet_Balances_Walletbalancesobs_N==1) ;
      }

      [  SoapElement( ElementName = "WalletBalancesConcepto" )]
      [  XmlElement( ElementName = "WalletBalancesConcepto"   )]
      public short gxTpr_Walletbalancesconcepto
      {
         get {
            return gxTv_SdtWallet_Balances_Walletbalancesconcepto ;
         }

         set {
            gxTv_SdtWallet_Balances_Walletbalancesconcepto_N = 0;
            sdtIsNull = 0;
            gxTv_SdtWallet_Balances_Walletbalancesconcepto = value;
            gxTv_SdtWallet_Balances_Modified = 1;
            SetDirty("Walletbalancesconcepto");
         }

      }

      public void gxTv_SdtWallet_Balances_Walletbalancesconcepto_SetNull( )
      {
         gxTv_SdtWallet_Balances_Walletbalancesconcepto_N = 1;
         gxTv_SdtWallet_Balances_Walletbalancesconcepto = 0;
         SetDirty("Walletbalancesconcepto");
         return  ;
      }

      public bool gxTv_SdtWallet_Balances_Walletbalancesconcepto_IsNull( )
      {
         return (gxTv_SdtWallet_Balances_Walletbalancesconcepto_N==1) ;
      }

      [  SoapElement( ElementName = "WalletBalancesUrl" )]
      [  XmlElement( ElementName = "WalletBalancesUrl"   )]
      public string gxTpr_Walletbalancesurl
      {
         get {
            return gxTv_SdtWallet_Balances_Walletbalancesurl ;
         }

         set {
            gxTv_SdtWallet_Balances_Walletbalancesurl_N = 0;
            sdtIsNull = 0;
            gxTv_SdtWallet_Balances_Walletbalancesurl = value;
            gxTv_SdtWallet_Balances_Modified = 1;
            SetDirty("Walletbalancesurl");
         }

      }

      public void gxTv_SdtWallet_Balances_Walletbalancesurl_SetNull( )
      {
         gxTv_SdtWallet_Balances_Walletbalancesurl_N = 1;
         gxTv_SdtWallet_Balances_Walletbalancesurl = "";
         SetDirty("Walletbalancesurl");
         return  ;
      }

      public bool gxTv_SdtWallet_Balances_Walletbalancesurl_IsNull( )
      {
         return (gxTv_SdtWallet_Balances_Walletbalancesurl_N==1) ;
      }

      [  SoapElement( ElementName = "WalletBalancesEstadoOPE" )]
      [  XmlElement( ElementName = "WalletBalancesEstadoOPE"   )]
      public string gxTpr_Walletbalancesestadoope
      {
         get {
            return gxTv_SdtWallet_Balances_Walletbalancesestadoope ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtWallet_Balances_Walletbalancesestadoope = value;
            gxTv_SdtWallet_Balances_Modified = 1;
            SetDirty("Walletbalancesestadoope");
         }

      }

      [  SoapElement( ElementName = "WalletBalanceLiquidacion" )]
      [  XmlElement( ElementName = "WalletBalanceLiquidacion"   )]
      public long gxTpr_Walletbalanceliquidacion
      {
         get {
            return gxTv_SdtWallet_Balances_Walletbalanceliquidacion ;
         }

         set {
            gxTv_SdtWallet_Balances_Walletbalanceliquidacion_N = 0;
            sdtIsNull = 0;
            gxTv_SdtWallet_Balances_Walletbalanceliquidacion = value;
            gxTv_SdtWallet_Balances_Modified = 1;
            SetDirty("Walletbalanceliquidacion");
         }

      }

      public void gxTv_SdtWallet_Balances_Walletbalanceliquidacion_SetNull( )
      {
         gxTv_SdtWallet_Balances_Walletbalanceliquidacion_N = 1;
         gxTv_SdtWallet_Balances_Walletbalanceliquidacion = 0;
         SetDirty("Walletbalanceliquidacion");
         return  ;
      }

      public bool gxTv_SdtWallet_Balances_Walletbalanceliquidacion_IsNull( )
      {
         return (gxTv_SdtWallet_Balances_Walletbalanceliquidacion_N==1) ;
      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtWallet_Balances_Mode ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtWallet_Balances_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtWallet_Balances_Mode_SetNull( )
      {
         gxTv_SdtWallet_Balances_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtWallet_Balances_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Modified" )]
      [  XmlElement( ElementName = "Modified"   )]
      public short gxTpr_Modified
      {
         get {
            return gxTv_SdtWallet_Balances_Modified ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtWallet_Balances_Modified = value;
            SetDirty("Modified");
         }

      }

      public void gxTv_SdtWallet_Balances_Modified_SetNull( )
      {
         gxTv_SdtWallet_Balances_Modified = 0;
         SetDirty("Modified");
         return  ;
      }

      public bool gxTv_SdtWallet_Balances_Modified_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtWallet_Balances_Initialized ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtWallet_Balances_Initialized = value;
            gxTv_SdtWallet_Balances_Modified = 1;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtWallet_Balances_Initialized_SetNull( )
      {
         gxTv_SdtWallet_Balances_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtWallet_Balances_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "WalletBalancesId_Z" )]
      [  XmlElement( ElementName = "WalletBalancesId_Z"   )]
      public long gxTpr_Walletbalancesid_Z
      {
         get {
            return gxTv_SdtWallet_Balances_Walletbalancesid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtWallet_Balances_Walletbalancesid_Z = value;
            gxTv_SdtWallet_Balances_Modified = 1;
            SetDirty("Walletbalancesid_Z");
         }

      }

      public void gxTv_SdtWallet_Balances_Walletbalancesid_Z_SetNull( )
      {
         gxTv_SdtWallet_Balances_Walletbalancesid_Z = 0;
         SetDirty("Walletbalancesid_Z");
         return  ;
      }

      public bool gxTv_SdtWallet_Balances_Walletbalancesid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "WalletBalancesFechaAlta_Z" )]
      [  XmlElement( ElementName = "WalletBalancesFechaAlta_Z"  , IsNullable=true )]
      public string gxTpr_Walletbalancesfechaalta_Z_Nullable
      {
         get {
            if ( gxTv_SdtWallet_Balances_Walletbalancesfechaalta_Z == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtWallet_Balances_Walletbalancesfechaalta_Z).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtWallet_Balances_Walletbalancesfechaalta_Z = DateTime.MinValue;
            else
               gxTv_SdtWallet_Balances_Walletbalancesfechaalta_Z = DateTime.Parse( value);
            gxTv_SdtWallet_Balances_Modified = 1;
         }

      }

      [SoapIgnore]
      [XmlIgnore]
      public DateTime gxTpr_Walletbalancesfechaalta_Z
      {
         get {
            return gxTv_SdtWallet_Balances_Walletbalancesfechaalta_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtWallet_Balances_Walletbalancesfechaalta_Z = value;
            gxTv_SdtWallet_Balances_Modified = 1;
            SetDirty("Walletbalancesfechaalta_Z");
         }

      }

      public void gxTv_SdtWallet_Balances_Walletbalancesfechaalta_Z_SetNull( )
      {
         gxTv_SdtWallet_Balances_Walletbalancesfechaalta_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Walletbalancesfechaalta_Z");
         return  ;
      }

      public bool gxTv_SdtWallet_Balances_Walletbalancesfechaalta_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "WalletBalancesUsrAlta_Z" )]
      [  XmlElement( ElementName = "WalletBalancesUsrAlta_Z"   )]
      public long gxTpr_Walletbalancesusralta_Z
      {
         get {
            return gxTv_SdtWallet_Balances_Walletbalancesusralta_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtWallet_Balances_Walletbalancesusralta_Z = value;
            gxTv_SdtWallet_Balances_Modified = 1;
            SetDirty("Walletbalancesusralta_Z");
         }

      }

      public void gxTv_SdtWallet_Balances_Walletbalancesusralta_Z_SetNull( )
      {
         gxTv_SdtWallet_Balances_Walletbalancesusralta_Z = 0;
         SetDirty("Walletbalancesusralta_Z");
         return  ;
      }

      public bool gxTv_SdtWallet_Balances_Walletbalancesusralta_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "WalletBalancesTipoMov_Z" )]
      [  XmlElement( ElementName = "WalletBalancesTipoMov_Z"   )]
      public string gxTpr_Walletbalancestipomov_Z
      {
         get {
            return gxTv_SdtWallet_Balances_Walletbalancestipomov_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtWallet_Balances_Walletbalancestipomov_Z = value;
            gxTv_SdtWallet_Balances_Modified = 1;
            SetDirty("Walletbalancestipomov_Z");
         }

      }

      public void gxTv_SdtWallet_Balances_Walletbalancestipomov_Z_SetNull( )
      {
         gxTv_SdtWallet_Balances_Walletbalancestipomov_Z = "";
         SetDirty("Walletbalancestipomov_Z");
         return  ;
      }

      public bool gxTv_SdtWallet_Balances_Walletbalancestipomov_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "WalletBalancesImporte_Z" )]
      [  XmlElement( ElementName = "WalletBalancesImporte_Z"   )]
      public decimal gxTpr_Walletbalancesimporte_Z
      {
         get {
            return gxTv_SdtWallet_Balances_Walletbalancesimporte_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtWallet_Balances_Walletbalancesimporte_Z = value;
            gxTv_SdtWallet_Balances_Modified = 1;
            SetDirty("Walletbalancesimporte_Z");
         }

      }

      public void gxTv_SdtWallet_Balances_Walletbalancesimporte_Z_SetNull( )
      {
         gxTv_SdtWallet_Balances_Walletbalancesimporte_Z = 0;
         SetDirty("Walletbalancesimporte_Z");
         return  ;
      }

      public bool gxTv_SdtWallet_Balances_Walletbalancesimporte_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "WalletBalancesObs_Z" )]
      [  XmlElement( ElementName = "WalletBalancesObs_Z"   )]
      public string gxTpr_Walletbalancesobs_Z
      {
         get {
            return gxTv_SdtWallet_Balances_Walletbalancesobs_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtWallet_Balances_Walletbalancesobs_Z = value;
            gxTv_SdtWallet_Balances_Modified = 1;
            SetDirty("Walletbalancesobs_Z");
         }

      }

      public void gxTv_SdtWallet_Balances_Walletbalancesobs_Z_SetNull( )
      {
         gxTv_SdtWallet_Balances_Walletbalancesobs_Z = "";
         SetDirty("Walletbalancesobs_Z");
         return  ;
      }

      public bool gxTv_SdtWallet_Balances_Walletbalancesobs_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "WalletBalancesConcepto_Z" )]
      [  XmlElement( ElementName = "WalletBalancesConcepto_Z"   )]
      public short gxTpr_Walletbalancesconcepto_Z
      {
         get {
            return gxTv_SdtWallet_Balances_Walletbalancesconcepto_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtWallet_Balances_Walletbalancesconcepto_Z = value;
            gxTv_SdtWallet_Balances_Modified = 1;
            SetDirty("Walletbalancesconcepto_Z");
         }

      }

      public void gxTv_SdtWallet_Balances_Walletbalancesconcepto_Z_SetNull( )
      {
         gxTv_SdtWallet_Balances_Walletbalancesconcepto_Z = 0;
         SetDirty("Walletbalancesconcepto_Z");
         return  ;
      }

      public bool gxTv_SdtWallet_Balances_Walletbalancesconcepto_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "WalletBalancesUrl_Z" )]
      [  XmlElement( ElementName = "WalletBalancesUrl_Z"   )]
      public string gxTpr_Walletbalancesurl_Z
      {
         get {
            return gxTv_SdtWallet_Balances_Walletbalancesurl_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtWallet_Balances_Walletbalancesurl_Z = value;
            gxTv_SdtWallet_Balances_Modified = 1;
            SetDirty("Walletbalancesurl_Z");
         }

      }

      public void gxTv_SdtWallet_Balances_Walletbalancesurl_Z_SetNull( )
      {
         gxTv_SdtWallet_Balances_Walletbalancesurl_Z = "";
         SetDirty("Walletbalancesurl_Z");
         return  ;
      }

      public bool gxTv_SdtWallet_Balances_Walletbalancesurl_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "WalletBalancesEstadoOPE_Z" )]
      [  XmlElement( ElementName = "WalletBalancesEstadoOPE_Z"   )]
      public string gxTpr_Walletbalancesestadoope_Z
      {
         get {
            return gxTv_SdtWallet_Balances_Walletbalancesestadoope_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtWallet_Balances_Walletbalancesestadoope_Z = value;
            gxTv_SdtWallet_Balances_Modified = 1;
            SetDirty("Walletbalancesestadoope_Z");
         }

      }

      public void gxTv_SdtWallet_Balances_Walletbalancesestadoope_Z_SetNull( )
      {
         gxTv_SdtWallet_Balances_Walletbalancesestadoope_Z = "";
         SetDirty("Walletbalancesestadoope_Z");
         return  ;
      }

      public bool gxTv_SdtWallet_Balances_Walletbalancesestadoope_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "WalletBalanceLiquidacion_Z" )]
      [  XmlElement( ElementName = "WalletBalanceLiquidacion_Z"   )]
      public long gxTpr_Walletbalanceliquidacion_Z
      {
         get {
            return gxTv_SdtWallet_Balances_Walletbalanceliquidacion_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtWallet_Balances_Walletbalanceliquidacion_Z = value;
            gxTv_SdtWallet_Balances_Modified = 1;
            SetDirty("Walletbalanceliquidacion_Z");
         }

      }

      public void gxTv_SdtWallet_Balances_Walletbalanceliquidacion_Z_SetNull( )
      {
         gxTv_SdtWallet_Balances_Walletbalanceliquidacion_Z = 0;
         SetDirty("Walletbalanceliquidacion_Z");
         return  ;
      }

      public bool gxTv_SdtWallet_Balances_Walletbalanceliquidacion_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "WalletBalancesObs_N" )]
      [  XmlElement( ElementName = "WalletBalancesObs_N"   )]
      public short gxTpr_Walletbalancesobs_N
      {
         get {
            return gxTv_SdtWallet_Balances_Walletbalancesobs_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtWallet_Balances_Walletbalancesobs_N = value;
            gxTv_SdtWallet_Balances_Modified = 1;
            SetDirty("Walletbalancesobs_N");
         }

      }

      public void gxTv_SdtWallet_Balances_Walletbalancesobs_N_SetNull( )
      {
         gxTv_SdtWallet_Balances_Walletbalancesobs_N = 0;
         SetDirty("Walletbalancesobs_N");
         return  ;
      }

      public bool gxTv_SdtWallet_Balances_Walletbalancesobs_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "WalletBalancesConcepto_N" )]
      [  XmlElement( ElementName = "WalletBalancesConcepto_N"   )]
      public short gxTpr_Walletbalancesconcepto_N
      {
         get {
            return gxTv_SdtWallet_Balances_Walletbalancesconcepto_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtWallet_Balances_Walletbalancesconcepto_N = value;
            gxTv_SdtWallet_Balances_Modified = 1;
            SetDirty("Walletbalancesconcepto_N");
         }

      }

      public void gxTv_SdtWallet_Balances_Walletbalancesconcepto_N_SetNull( )
      {
         gxTv_SdtWallet_Balances_Walletbalancesconcepto_N = 0;
         SetDirty("Walletbalancesconcepto_N");
         return  ;
      }

      public bool gxTv_SdtWallet_Balances_Walletbalancesconcepto_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "WalletBalancesUrl_N" )]
      [  XmlElement( ElementName = "WalletBalancesUrl_N"   )]
      public short gxTpr_Walletbalancesurl_N
      {
         get {
            return gxTv_SdtWallet_Balances_Walletbalancesurl_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtWallet_Balances_Walletbalancesurl_N = value;
            gxTv_SdtWallet_Balances_Modified = 1;
            SetDirty("Walletbalancesurl_N");
         }

      }

      public void gxTv_SdtWallet_Balances_Walletbalancesurl_N_SetNull( )
      {
         gxTv_SdtWallet_Balances_Walletbalancesurl_N = 0;
         SetDirty("Walletbalancesurl_N");
         return  ;
      }

      public bool gxTv_SdtWallet_Balances_Walletbalancesurl_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "WalletBalanceLiquidacion_N" )]
      [  XmlElement( ElementName = "WalletBalanceLiquidacion_N"   )]
      public short gxTpr_Walletbalanceliquidacion_N
      {
         get {
            return gxTv_SdtWallet_Balances_Walletbalanceliquidacion_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtWallet_Balances_Walletbalanceliquidacion_N = value;
            gxTv_SdtWallet_Balances_Modified = 1;
            SetDirty("Walletbalanceliquidacion_N");
         }

      }

      public void gxTv_SdtWallet_Balances_Walletbalanceliquidacion_N_SetNull( )
      {
         gxTv_SdtWallet_Balances_Walletbalanceliquidacion_N = 0;
         SetDirty("Walletbalanceliquidacion_N");
         return  ;
      }

      public bool gxTv_SdtWallet_Balances_Walletbalanceliquidacion_N_IsNull( )
      {
         return false ;
      }

      [SoapIgnore]
      [XmlIgnore]
      private static GXTypeInfo _typeProps;
      protected override GXTypeInfo TypeInfo
      {
         get {
            return _typeProps ;
         }

         set {
            _typeProps = value ;
         }

      }

      public void initialize( )
      {
         sdtIsNull = 1;
         gxTv_SdtWallet_Balances_Walletbalancesfechaalta = (DateTime)(DateTime.MinValue);
         gxTv_SdtWallet_Balances_Walletbalancestipomov = "";
         gxTv_SdtWallet_Balances_Walletbalancesobs = "";
         gxTv_SdtWallet_Balances_Walletbalancesurl = "";
         gxTv_SdtWallet_Balances_Walletbalancesestadoope = "";
         gxTv_SdtWallet_Balances_Mode = "";
         gxTv_SdtWallet_Balances_Walletbalancesfechaalta_Z = (DateTime)(DateTime.MinValue);
         gxTv_SdtWallet_Balances_Walletbalancestipomov_Z = "";
         gxTv_SdtWallet_Balances_Walletbalancesobs_Z = "";
         gxTv_SdtWallet_Balances_Walletbalancesurl_Z = "";
         gxTv_SdtWallet_Balances_Walletbalancesestadoope_Z = "";
         datetime_STZ = (DateTime)(DateTime.MinValue);
         sDateCnv = "";
         sNumToPad = "";
         return  ;
      }

      public short isNull( )
      {
         return sdtIsNull ;
      }

      private short sdtIsNull ;
      private short gxTv_SdtWallet_Balances_Walletbalancesconcepto ;
      private short gxTv_SdtWallet_Balances_Modified ;
      private short gxTv_SdtWallet_Balances_Initialized ;
      private short gxTv_SdtWallet_Balances_Walletbalancesconcepto_Z ;
      private short gxTv_SdtWallet_Balances_Walletbalancesobs_N ;
      private short gxTv_SdtWallet_Balances_Walletbalancesconcepto_N ;
      private short gxTv_SdtWallet_Balances_Walletbalancesurl_N ;
      private short gxTv_SdtWallet_Balances_Walletbalanceliquidacion_N ;
      private long gxTv_SdtWallet_Balances_Walletbalancesid ;
      private long gxTv_SdtWallet_Balances_Walletbalancesusralta ;
      private long gxTv_SdtWallet_Balances_Walletbalanceliquidacion ;
      private long gxTv_SdtWallet_Balances_Walletbalancesid_Z ;
      private long gxTv_SdtWallet_Balances_Walletbalancesusralta_Z ;
      private long gxTv_SdtWallet_Balances_Walletbalanceliquidacion_Z ;
      private decimal gxTv_SdtWallet_Balances_Walletbalancesimporte ;
      private decimal gxTv_SdtWallet_Balances_Walletbalancesimporte_Z ;
      private string gxTv_SdtWallet_Balances_Walletbalancestipomov ;
      private string gxTv_SdtWallet_Balances_Walletbalancesestadoope ;
      private string gxTv_SdtWallet_Balances_Mode ;
      private string gxTv_SdtWallet_Balances_Walletbalancestipomov_Z ;
      private string gxTv_SdtWallet_Balances_Walletbalancesestadoope_Z ;
      private string sDateCnv ;
      private string sNumToPad ;
      private DateTime gxTv_SdtWallet_Balances_Walletbalancesfechaalta ;
      private DateTime gxTv_SdtWallet_Balances_Walletbalancesfechaalta_Z ;
      private DateTime datetime_STZ ;
      private string gxTv_SdtWallet_Balances_Walletbalancesobs ;
      private string gxTv_SdtWallet_Balances_Walletbalancesurl ;
      private string gxTv_SdtWallet_Balances_Walletbalancesobs_Z ;
      private string gxTv_SdtWallet_Balances_Walletbalancesurl_Z ;
   }

   [DataContract(Name = @"Wallet.Balances", Namespace = "AlmangoX")]
   [GxJsonSerialization("default")]
   public class SdtWallet_Balances_RESTInterface : GxGenericCollectionItem<SdtWallet_Balances>, System.Web.SessionState.IRequiresSessionState
   {
      public SdtWallet_Balances_RESTInterface( ) : base()
      {
      }

      public SdtWallet_Balances_RESTInterface( SdtWallet_Balances psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "WalletBalancesId" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Walletbalancesid
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Walletbalancesid), 18, 0)) ;
         }

         set {
            sdt.gxTpr_Walletbalancesid = (long)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
         }

      }

      [DataMember( Name = "WalletBalancesFechaAlta" , Order = 1 )]
      [GxSeudo()]
      public string gxTpr_Walletbalancesfechaalta
      {
         get {
            return DateTimeUtil.TToC2( sdt.gxTpr_Walletbalancesfechaalta, (IGxContext)(context)) ;
         }

         set {
            sdt.gxTpr_Walletbalancesfechaalta = DateTimeUtil.CToT2( value, (IGxContext)(context));
         }

      }

      [DataMember( Name = "WalletBalancesUsrAlta" , Order = 2 )]
      [GxSeudo()]
      public string gxTpr_Walletbalancesusralta
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Walletbalancesusralta), 10, 0)) ;
         }

         set {
            sdt.gxTpr_Walletbalancesusralta = (long)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
         }

      }

      [DataMember( Name = "WalletBalancesTipoMov" , Order = 3 )]
      [GxSeudo()]
      public string gxTpr_Walletbalancestipomov
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Walletbalancestipomov) ;
         }

         set {
            sdt.gxTpr_Walletbalancestipomov = value;
         }

      }

      [DataMember( Name = "WalletBalancesImporte" , Order = 4 )]
      [GxSeudo()]
      public string gxTpr_Walletbalancesimporte
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( sdt.gxTpr_Walletbalancesimporte, 18, 2)) ;
         }

         set {
            sdt.gxTpr_Walletbalancesimporte = NumberUtil.Val( value, ".");
         }

      }

      [DataMember( Name = "WalletBalancesObs" , Order = 5 )]
      [GxSeudo()]
      public string gxTpr_Walletbalancesobs
      {
         get {
            return sdt.gxTpr_Walletbalancesobs ;
         }

         set {
            sdt.gxTpr_Walletbalancesobs = value;
         }

      }

      [DataMember( Name = "WalletBalancesConcepto" , Order = 6 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Walletbalancesconcepto
      {
         get {
            return sdt.gxTpr_Walletbalancesconcepto ;
         }

         set {
            sdt.gxTpr_Walletbalancesconcepto = (short)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "WalletBalancesUrl" , Order = 7 )]
      [GxSeudo()]
      public string gxTpr_Walletbalancesurl
      {
         get {
            return sdt.gxTpr_Walletbalancesurl ;
         }

         set {
            sdt.gxTpr_Walletbalancesurl = value;
         }

      }

      [DataMember( Name = "WalletBalancesEstadoOPE" , Order = 8 )]
      [GxSeudo()]
      public string gxTpr_Walletbalancesestadoope
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Walletbalancesestadoope) ;
         }

         set {
            sdt.gxTpr_Walletbalancesestadoope = value;
         }

      }

      [DataMember( Name = "WalletBalanceLiquidacion" , Order = 9 )]
      [GxSeudo()]
      public string gxTpr_Walletbalanceliquidacion
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Walletbalanceliquidacion), 18, 0)) ;
         }

         set {
            sdt.gxTpr_Walletbalanceliquidacion = (long)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
         }

      }

      public SdtWallet_Balances sdt
      {
         get {
            return (SdtWallet_Balances)Sdt ;
         }

         set {
            Sdt = value ;
         }

      }

      [OnDeserializing]
      void checkSdt( StreamingContext ctx )
      {
         if ( sdt == null )
         {
            sdt = new SdtWallet_Balances() ;
         }
      }

   }

   [DataContract(Name = @"Wallet.Balances", Namespace = "AlmangoX")]
   [GxJsonSerialization("default")]
   public class SdtWallet_Balances_RESTLInterface : GxGenericCollectionItem<SdtWallet_Balances>, System.Web.SessionState.IRequiresSessionState
   {
      public SdtWallet_Balances_RESTLInterface( ) : base()
      {
      }

      public SdtWallet_Balances_RESTLInterface( SdtWallet_Balances psdt ) : base(psdt)
      {
      }

      public SdtWallet_Balances sdt
      {
         get {
            return (SdtWallet_Balances)Sdt ;
         }

         set {
            Sdt = value ;
         }

      }

      [OnDeserializing]
      void checkSdt( StreamingContext ctx )
      {
         if ( sdt == null )
         {
            sdt = new SdtWallet_Balances() ;
         }
      }

   }

}

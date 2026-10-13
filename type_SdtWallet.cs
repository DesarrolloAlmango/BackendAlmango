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
   [XmlRoot(ElementName = "Wallet" )]
   [XmlType(TypeName =  "Wallet" , Namespace = "AlmangoX" )]
   [Serializable]
   public class SdtWallet : GxSilentTrnSdt, System.Web.SessionState.IRequiresSessionState
   {
      public SdtWallet( )
      {
      }

      public SdtWallet( IGxContext context )
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

      public void Load( long AV637WalletId )
      {
         IGxSilentTrn obj;
         obj = getTransaction();
         obj.LoadKey(new Object[] {(long)AV637WalletId});
         return  ;
      }

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"WalletId", typeof(long)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "Wallet");
         metadata.Set("BT", "Wallet");
         metadata.Set("PK", "[ \"WalletId\" ]");
         metadata.Set("PKAssigned", "[ \"WalletId\" ]");
         metadata.Set("Levels", "[ \"Balances\" ]");
         metadata.Set("FKList", "[ { \"FK\":[ \"MonedaId\" ],\"FKMap\":[  ] },{ \"FK\":[ \"TipoCuentaId\" ],\"FKMap\":[  ] } ]");
         metadata.Set("AllowInsert", "True");
         metadata.Set("AllowUpdate", "True");
         metadata.Set("AllowDelete", "True");
         return metadata ;
      }

      public override GeneXus.Utils.GxStringCollection StateAttributes( )
      {
         GeneXus.Utils.GxStringCollection state = new GeneXus.Utils.GxStringCollection();
         state.Add("gxTpr_Mode");
         state.Add("gxTpr_Initialized");
         state.Add("gxTpr_Walletid_Z");
         state.Add("gxTpr_Tipocuentaid_Z");
         state.Add("gxTpr_Tipocuentaconcepto_Z");
         state.Add("gxTpr_Tipocuentanombre_Z");
         state.Add("gxTpr_Wallettipoentidad_Z");
         state.Add("gxTpr_Walletcodrefencia_Z");
         state.Add("gxTpr_Walletnombre_Z");
         state.Add("gxTpr_Monedaid_Z");
         state.Add("gxTpr_Monedaisosimbolo_Z");
         state.Add("gxTpr_Wallettotaldebito_Z");
         state.Add("gxTpr_Wallettotalcredito_Z");
         state.Add("gxTpr_Walletsaldo_Z");
         state.Add("gxTpr_Walletsolicitudespendientes_Z");
         state.Add("gxTpr_Walletsaldoaldia_Z");
         state.Add("gxTpr_Walletestado_Z");
         state.Add("gxTpr_Monedaid_N");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         SdtWallet sdt;
         sdt = (SdtWallet)(source);
         gxTv_SdtWallet_Walletid = sdt.gxTv_SdtWallet_Walletid ;
         gxTv_SdtWallet_Tipocuentaid = sdt.gxTv_SdtWallet_Tipocuentaid ;
         gxTv_SdtWallet_Tipocuentaconcepto = sdt.gxTv_SdtWallet_Tipocuentaconcepto ;
         gxTv_SdtWallet_Tipocuentanombre = sdt.gxTv_SdtWallet_Tipocuentanombre ;
         gxTv_SdtWallet_Wallettipoentidad = sdt.gxTv_SdtWallet_Wallettipoentidad ;
         gxTv_SdtWallet_Walletcodrefencia = sdt.gxTv_SdtWallet_Walletcodrefencia ;
         gxTv_SdtWallet_Walletnombre = sdt.gxTv_SdtWallet_Walletnombre ;
         gxTv_SdtWallet_Monedaid = sdt.gxTv_SdtWallet_Monedaid ;
         gxTv_SdtWallet_Monedaisosimbolo = sdt.gxTv_SdtWallet_Monedaisosimbolo ;
         gxTv_SdtWallet_Balances = sdt.gxTv_SdtWallet_Balances ;
         gxTv_SdtWallet_Wallettotaldebito = sdt.gxTv_SdtWallet_Wallettotaldebito ;
         gxTv_SdtWallet_Wallettotalcredito = sdt.gxTv_SdtWallet_Wallettotalcredito ;
         gxTv_SdtWallet_Walletsaldo = sdt.gxTv_SdtWallet_Walletsaldo ;
         gxTv_SdtWallet_Walletsolicitudespendientes = sdt.gxTv_SdtWallet_Walletsolicitudespendientes ;
         gxTv_SdtWallet_Walletsaldoaldia = sdt.gxTv_SdtWallet_Walletsaldoaldia ;
         gxTv_SdtWallet_Walletestado = sdt.gxTv_SdtWallet_Walletestado ;
         gxTv_SdtWallet_Mode = sdt.gxTv_SdtWallet_Mode ;
         gxTv_SdtWallet_Initialized = sdt.gxTv_SdtWallet_Initialized ;
         gxTv_SdtWallet_Walletid_Z = sdt.gxTv_SdtWallet_Walletid_Z ;
         gxTv_SdtWallet_Tipocuentaid_Z = sdt.gxTv_SdtWallet_Tipocuentaid_Z ;
         gxTv_SdtWallet_Tipocuentaconcepto_Z = sdt.gxTv_SdtWallet_Tipocuentaconcepto_Z ;
         gxTv_SdtWallet_Tipocuentanombre_Z = sdt.gxTv_SdtWallet_Tipocuentanombre_Z ;
         gxTv_SdtWallet_Wallettipoentidad_Z = sdt.gxTv_SdtWallet_Wallettipoentidad_Z ;
         gxTv_SdtWallet_Walletcodrefencia_Z = sdt.gxTv_SdtWallet_Walletcodrefencia_Z ;
         gxTv_SdtWallet_Walletnombre_Z = sdt.gxTv_SdtWallet_Walletnombre_Z ;
         gxTv_SdtWallet_Monedaid_Z = sdt.gxTv_SdtWallet_Monedaid_Z ;
         gxTv_SdtWallet_Monedaisosimbolo_Z = sdt.gxTv_SdtWallet_Monedaisosimbolo_Z ;
         gxTv_SdtWallet_Wallettotaldebito_Z = sdt.gxTv_SdtWallet_Wallettotaldebito_Z ;
         gxTv_SdtWallet_Wallettotalcredito_Z = sdt.gxTv_SdtWallet_Wallettotalcredito_Z ;
         gxTv_SdtWallet_Walletsaldo_Z = sdt.gxTv_SdtWallet_Walletsaldo_Z ;
         gxTv_SdtWallet_Walletsolicitudespendientes_Z = sdt.gxTv_SdtWallet_Walletsolicitudespendientes_Z ;
         gxTv_SdtWallet_Walletsaldoaldia_Z = sdt.gxTv_SdtWallet_Walletsaldoaldia_Z ;
         gxTv_SdtWallet_Walletestado_Z = sdt.gxTv_SdtWallet_Walletestado_Z ;
         gxTv_SdtWallet_Monedaid_N = sdt.gxTv_SdtWallet_Monedaid_N ;
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
         AddObjectProperty("WalletId", StringUtil.LTrim( StringUtil.Str( (decimal)(gxTv_SdtWallet_Walletid), 18, 0)), false, includeNonInitialized);
         AddObjectProperty("TipoCuentaId", StringUtil.LTrim( StringUtil.Str( (decimal)(gxTv_SdtWallet_Tipocuentaid), 18, 0)), false, includeNonInitialized);
         AddObjectProperty("TipoCuentaConcepto", gxTv_SdtWallet_Tipocuentaconcepto, false, includeNonInitialized);
         AddObjectProperty("TipoCuentaNombre", gxTv_SdtWallet_Tipocuentanombre, false, includeNonInitialized);
         AddObjectProperty("WalletTipoEntidad", gxTv_SdtWallet_Wallettipoentidad, false, includeNonInitialized);
         AddObjectProperty("WalletCodRefencia", gxTv_SdtWallet_Walletcodrefencia, false, includeNonInitialized);
         AddObjectProperty("WalletNombre", gxTv_SdtWallet_Walletnombre, false, includeNonInitialized);
         AddObjectProperty("MonedaId", gxTv_SdtWallet_Monedaid, false, includeNonInitialized);
         AddObjectProperty("MonedaId_N", gxTv_SdtWallet_Monedaid_N, false, includeNonInitialized);
         AddObjectProperty("MonedaISOSimbolo", gxTv_SdtWallet_Monedaisosimbolo, false, includeNonInitialized);
         if ( gxTv_SdtWallet_Balances != null )
         {
            AddObjectProperty("Balances", gxTv_SdtWallet_Balances, includeState, includeNonInitialized);
         }
         AddObjectProperty("WalletTotalDebito", StringUtil.LTrim( StringUtil.Str( gxTv_SdtWallet_Wallettotaldebito, 18, 2)), false, includeNonInitialized);
         AddObjectProperty("WalletTotalCredito", StringUtil.LTrim( StringUtil.Str( gxTv_SdtWallet_Wallettotalcredito, 18, 2)), false, includeNonInitialized);
         AddObjectProperty("WalletSaldo", StringUtil.LTrim( StringUtil.Str( gxTv_SdtWallet_Walletsaldo, 18, 2)), false, includeNonInitialized);
         AddObjectProperty("WalletSolicitudesPendientes", StringUtil.LTrim( StringUtil.Str( gxTv_SdtWallet_Walletsolicitudespendientes, 18, 2)), false, includeNonInitialized);
         AddObjectProperty("WalletSaldoAlDia", StringUtil.LTrim( StringUtil.Str( gxTv_SdtWallet_Walletsaldoaldia, 18, 2)), false, includeNonInitialized);
         AddObjectProperty("WalletEstado", gxTv_SdtWallet_Walletestado, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_SdtWallet_Mode, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtWallet_Initialized, false, includeNonInitialized);
            AddObjectProperty("WalletId_Z", StringUtil.LTrim( StringUtil.Str( (decimal)(gxTv_SdtWallet_Walletid_Z), 18, 0)), false, includeNonInitialized);
            AddObjectProperty("TipoCuentaId_Z", StringUtil.LTrim( StringUtil.Str( (decimal)(gxTv_SdtWallet_Tipocuentaid_Z), 18, 0)), false, includeNonInitialized);
            AddObjectProperty("TipoCuentaConcepto_Z", gxTv_SdtWallet_Tipocuentaconcepto_Z, false, includeNonInitialized);
            AddObjectProperty("TipoCuentaNombre_Z", gxTv_SdtWallet_Tipocuentanombre_Z, false, includeNonInitialized);
            AddObjectProperty("WalletTipoEntidad_Z", gxTv_SdtWallet_Wallettipoentidad_Z, false, includeNonInitialized);
            AddObjectProperty("WalletCodRefencia_Z", gxTv_SdtWallet_Walletcodrefencia_Z, false, includeNonInitialized);
            AddObjectProperty("WalletNombre_Z", gxTv_SdtWallet_Walletnombre_Z, false, includeNonInitialized);
            AddObjectProperty("MonedaId_Z", gxTv_SdtWallet_Monedaid_Z, false, includeNonInitialized);
            AddObjectProperty("MonedaISOSimbolo_Z", gxTv_SdtWallet_Monedaisosimbolo_Z, false, includeNonInitialized);
            AddObjectProperty("WalletTotalDebito_Z", StringUtil.LTrim( StringUtil.Str( gxTv_SdtWallet_Wallettotaldebito_Z, 18, 2)), false, includeNonInitialized);
            AddObjectProperty("WalletTotalCredito_Z", StringUtil.LTrim( StringUtil.Str( gxTv_SdtWallet_Wallettotalcredito_Z, 18, 2)), false, includeNonInitialized);
            AddObjectProperty("WalletSaldo_Z", StringUtil.LTrim( StringUtil.Str( gxTv_SdtWallet_Walletsaldo_Z, 18, 2)), false, includeNonInitialized);
            AddObjectProperty("WalletSolicitudesPendientes_Z", StringUtil.LTrim( StringUtil.Str( gxTv_SdtWallet_Walletsolicitudespendientes_Z, 18, 2)), false, includeNonInitialized);
            AddObjectProperty("WalletSaldoAlDia_Z", StringUtil.LTrim( StringUtil.Str( gxTv_SdtWallet_Walletsaldoaldia_Z, 18, 2)), false, includeNonInitialized);
            AddObjectProperty("WalletEstado_Z", gxTv_SdtWallet_Walletestado_Z, false, includeNonInitialized);
            AddObjectProperty("MonedaId_N", gxTv_SdtWallet_Monedaid_N, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( SdtWallet sdt )
      {
         if ( sdt.IsDirty("WalletId") )
         {
            sdtIsNull = 0;
            gxTv_SdtWallet_Walletid = sdt.gxTv_SdtWallet_Walletid ;
         }
         if ( sdt.IsDirty("TipoCuentaId") )
         {
            sdtIsNull = 0;
            gxTv_SdtWallet_Tipocuentaid = sdt.gxTv_SdtWallet_Tipocuentaid ;
         }
         if ( sdt.IsDirty("TipoCuentaConcepto") )
         {
            sdtIsNull = 0;
            gxTv_SdtWallet_Tipocuentaconcepto = sdt.gxTv_SdtWallet_Tipocuentaconcepto ;
         }
         if ( sdt.IsDirty("TipoCuentaNombre") )
         {
            sdtIsNull = 0;
            gxTv_SdtWallet_Tipocuentanombre = sdt.gxTv_SdtWallet_Tipocuentanombre ;
         }
         if ( sdt.IsDirty("WalletTipoEntidad") )
         {
            sdtIsNull = 0;
            gxTv_SdtWallet_Wallettipoentidad = sdt.gxTv_SdtWallet_Wallettipoentidad ;
         }
         if ( sdt.IsDirty("WalletCodRefencia") )
         {
            sdtIsNull = 0;
            gxTv_SdtWallet_Walletcodrefencia = sdt.gxTv_SdtWallet_Walletcodrefencia ;
         }
         if ( sdt.IsDirty("WalletNombre") )
         {
            sdtIsNull = 0;
            gxTv_SdtWallet_Walletnombre = sdt.gxTv_SdtWallet_Walletnombre ;
         }
         if ( sdt.IsDirty("MonedaId") )
         {
            gxTv_SdtWallet_Monedaid_N = (short)(sdt.gxTv_SdtWallet_Monedaid_N);
            sdtIsNull = 0;
            gxTv_SdtWallet_Monedaid = sdt.gxTv_SdtWallet_Monedaid ;
         }
         if ( sdt.IsDirty("MonedaISOSimbolo") )
         {
            sdtIsNull = 0;
            gxTv_SdtWallet_Monedaisosimbolo = sdt.gxTv_SdtWallet_Monedaisosimbolo ;
         }
         if ( gxTv_SdtWallet_Balances != null )
         {
            GXBCLevelCollection<SdtWallet_Balances> newCollectionBalances = sdt.gxTpr_Balances;
            SdtWallet_Balances currItemBalances;
            SdtWallet_Balances newItemBalances;
            short idx = 1;
            while ( idx <= newCollectionBalances.Count )
            {
               newItemBalances = ((SdtWallet_Balances)newCollectionBalances.Item(idx));
               currItemBalances = gxTv_SdtWallet_Balances.GetByKey(newItemBalances.gxTpr_Walletbalancesid);
               if ( StringUtil.StrCmp(currItemBalances.gxTpr_Mode, "UPD") == 0 )
               {
                  currItemBalances.UpdateDirties(newItemBalances);
                  if ( StringUtil.StrCmp(newItemBalances.gxTpr_Mode, "DLT") == 0 )
                  {
                     currItemBalances.gxTpr_Mode = "DLT";
                  }
                  currItemBalances.gxTpr_Modified = 1;
               }
               else
               {
                  gxTv_SdtWallet_Balances.Add(newItemBalances, 0);
               }
               idx = (short)(idx+1);
            }
         }
         if ( sdt.IsDirty("WalletTotalDebito") )
         {
            sdtIsNull = 0;
            gxTv_SdtWallet_Wallettotaldebito = sdt.gxTv_SdtWallet_Wallettotaldebito ;
         }
         if ( sdt.IsDirty("WalletTotalCredito") )
         {
            sdtIsNull = 0;
            gxTv_SdtWallet_Wallettotalcredito = sdt.gxTv_SdtWallet_Wallettotalcredito ;
         }
         if ( sdt.IsDirty("WalletSaldo") )
         {
            sdtIsNull = 0;
            gxTv_SdtWallet_Walletsaldo = sdt.gxTv_SdtWallet_Walletsaldo ;
         }
         if ( sdt.IsDirty("WalletSolicitudesPendientes") )
         {
            sdtIsNull = 0;
            gxTv_SdtWallet_Walletsolicitudespendientes = sdt.gxTv_SdtWallet_Walletsolicitudespendientes ;
         }
         if ( sdt.IsDirty("WalletSaldoAlDia") )
         {
            sdtIsNull = 0;
            gxTv_SdtWallet_Walletsaldoaldia = sdt.gxTv_SdtWallet_Walletsaldoaldia ;
         }
         if ( sdt.IsDirty("WalletEstado") )
         {
            sdtIsNull = 0;
            gxTv_SdtWallet_Walletestado = sdt.gxTv_SdtWallet_Walletestado ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "WalletId" )]
      [  XmlElement( ElementName = "WalletId"   )]
      public long gxTpr_Walletid
      {
         get {
            return gxTv_SdtWallet_Walletid ;
         }

         set {
            sdtIsNull = 0;
            if ( gxTv_SdtWallet_Walletid != value )
            {
               gxTv_SdtWallet_Mode = "INS";
               this.gxTv_SdtWallet_Walletid_Z_SetNull( );
               this.gxTv_SdtWallet_Tipocuentaid_Z_SetNull( );
               this.gxTv_SdtWallet_Tipocuentaconcepto_Z_SetNull( );
               this.gxTv_SdtWallet_Tipocuentanombre_Z_SetNull( );
               this.gxTv_SdtWallet_Wallettipoentidad_Z_SetNull( );
               this.gxTv_SdtWallet_Walletcodrefencia_Z_SetNull( );
               this.gxTv_SdtWallet_Walletnombre_Z_SetNull( );
               this.gxTv_SdtWallet_Monedaid_Z_SetNull( );
               this.gxTv_SdtWallet_Monedaisosimbolo_Z_SetNull( );
               this.gxTv_SdtWallet_Wallettotaldebito_Z_SetNull( );
               this.gxTv_SdtWallet_Wallettotalcredito_Z_SetNull( );
               this.gxTv_SdtWallet_Walletsaldo_Z_SetNull( );
               this.gxTv_SdtWallet_Walletsolicitudespendientes_Z_SetNull( );
               this.gxTv_SdtWallet_Walletsaldoaldia_Z_SetNull( );
               this.gxTv_SdtWallet_Walletestado_Z_SetNull( );
               if ( gxTv_SdtWallet_Balances != null )
               {
                  GXBCLevelCollection<SdtWallet_Balances> collectionBalances = gxTv_SdtWallet_Balances;
                  SdtWallet_Balances currItemBalances;
                  short idx = 1;
                  while ( idx <= collectionBalances.Count )
                  {
                     currItemBalances = ((SdtWallet_Balances)collectionBalances.Item(idx));
                     currItemBalances.gxTpr_Mode = "INS";
                     currItemBalances.gxTpr_Modified = 1;
                     idx = (short)(idx+1);
                  }
               }
            }
            gxTv_SdtWallet_Walletid = value;
            SetDirty("Walletid");
         }

      }

      [  SoapElement( ElementName = "TipoCuentaId" )]
      [  XmlElement( ElementName = "TipoCuentaId"   )]
      public long gxTpr_Tipocuentaid
      {
         get {
            return gxTv_SdtWallet_Tipocuentaid ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtWallet_Tipocuentaid = value;
            SetDirty("Tipocuentaid");
         }

      }

      [  SoapElement( ElementName = "TipoCuentaConcepto" )]
      [  XmlElement( ElementName = "TipoCuentaConcepto"   )]
      public string gxTpr_Tipocuentaconcepto
      {
         get {
            return gxTv_SdtWallet_Tipocuentaconcepto ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtWallet_Tipocuentaconcepto = value;
            SetDirty("Tipocuentaconcepto");
         }

      }

      [  SoapElement( ElementName = "TipoCuentaNombre" )]
      [  XmlElement( ElementName = "TipoCuentaNombre"   )]
      public string gxTpr_Tipocuentanombre
      {
         get {
            return gxTv_SdtWallet_Tipocuentanombre ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtWallet_Tipocuentanombre = value;
            SetDirty("Tipocuentanombre");
         }

      }

      [  SoapElement( ElementName = "WalletTipoEntidad" )]
      [  XmlElement( ElementName = "WalletTipoEntidad"   )]
      public string gxTpr_Wallettipoentidad
      {
         get {
            return gxTv_SdtWallet_Wallettipoentidad ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtWallet_Wallettipoentidad = value;
            SetDirty("Wallettipoentidad");
         }

      }

      [  SoapElement( ElementName = "WalletCodRefencia" )]
      [  XmlElement( ElementName = "WalletCodRefencia"   )]
      public string gxTpr_Walletcodrefencia
      {
         get {
            return gxTv_SdtWallet_Walletcodrefencia ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtWallet_Walletcodrefencia = value;
            SetDirty("Walletcodrefencia");
         }

      }

      [  SoapElement( ElementName = "WalletNombre" )]
      [  XmlElement( ElementName = "WalletNombre"   )]
      public string gxTpr_Walletnombre
      {
         get {
            return gxTv_SdtWallet_Walletnombre ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtWallet_Walletnombre = value;
            SetDirty("Walletnombre");
         }

      }

      public void gxTv_SdtWallet_Walletnombre_SetNull( )
      {
         gxTv_SdtWallet_Walletnombre = "";
         SetDirty("Walletnombre");
         return  ;
      }

      public bool gxTv_SdtWallet_Walletnombre_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "MonedaId" )]
      [  XmlElement( ElementName = "MonedaId"   )]
      public short gxTpr_Monedaid
      {
         get {
            return gxTv_SdtWallet_Monedaid ;
         }

         set {
            gxTv_SdtWallet_Monedaid_N = 0;
            sdtIsNull = 0;
            gxTv_SdtWallet_Monedaid = value;
            SetDirty("Monedaid");
         }

      }

      public void gxTv_SdtWallet_Monedaid_SetNull( )
      {
         gxTv_SdtWallet_Monedaid_N = 1;
         gxTv_SdtWallet_Monedaid = 0;
         SetDirty("Monedaid");
         return  ;
      }

      public bool gxTv_SdtWallet_Monedaid_IsNull( )
      {
         return (gxTv_SdtWallet_Monedaid_N==1) ;
      }

      [  SoapElement( ElementName = "MonedaISOSimbolo" )]
      [  XmlElement( ElementName = "MonedaISOSimbolo"   )]
      public string gxTpr_Monedaisosimbolo
      {
         get {
            return gxTv_SdtWallet_Monedaisosimbolo ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtWallet_Monedaisosimbolo = value;
            SetDirty("Monedaisosimbolo");
         }

      }

      [  SoapElement( ElementName = "Balances" )]
      [  XmlArray( ElementName = "Balances"  )]
      [  XmlArrayItemAttribute( ElementName= "Wallet.Balances"  , IsNullable=false)]
      public GXBCLevelCollection<SdtWallet_Balances> gxTpr_Balances_GXBCLevelCollection
      {
         get {
            if ( gxTv_SdtWallet_Balances == null )
            {
               gxTv_SdtWallet_Balances = new GXBCLevelCollection<SdtWallet_Balances>( context, "Wallet.Balances", "AlmangoX");
            }
            return gxTv_SdtWallet_Balances ;
         }

         set {
            if ( gxTv_SdtWallet_Balances == null )
            {
               gxTv_SdtWallet_Balances = new GXBCLevelCollection<SdtWallet_Balances>( context, "Wallet.Balances", "AlmangoX");
            }
            sdtIsNull = 0;
            gxTv_SdtWallet_Balances = value;
         }

      }

      [SoapIgnore]
      [XmlIgnore]
      public GXBCLevelCollection<SdtWallet_Balances> gxTpr_Balances
      {
         get {
            if ( gxTv_SdtWallet_Balances == null )
            {
               gxTv_SdtWallet_Balances = new GXBCLevelCollection<SdtWallet_Balances>( context, "Wallet.Balances", "AlmangoX");
            }
            sdtIsNull = 0;
            return gxTv_SdtWallet_Balances ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtWallet_Balances = value;
            SetDirty("Balances");
         }

      }

      public void gxTv_SdtWallet_Balances_SetNull( )
      {
         gxTv_SdtWallet_Balances = null;
         SetDirty("Balances");
         return  ;
      }

      public bool gxTv_SdtWallet_Balances_IsNull( )
      {
         if ( gxTv_SdtWallet_Balances == null )
         {
            return true ;
         }
         return false ;
      }

      [  SoapElement( ElementName = "WalletTotalDebito" )]
      [  XmlElement( ElementName = "WalletTotalDebito"   )]
      public decimal gxTpr_Wallettotaldebito
      {
         get {
            return gxTv_SdtWallet_Wallettotaldebito ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtWallet_Wallettotaldebito = value;
            SetDirty("Wallettotaldebito");
         }

      }

      public void gxTv_SdtWallet_Wallettotaldebito_SetNull( )
      {
         gxTv_SdtWallet_Wallettotaldebito = 0;
         SetDirty("Wallettotaldebito");
         return  ;
      }

      public bool gxTv_SdtWallet_Wallettotaldebito_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "WalletTotalCredito" )]
      [  XmlElement( ElementName = "WalletTotalCredito"   )]
      public decimal gxTpr_Wallettotalcredito
      {
         get {
            return gxTv_SdtWallet_Wallettotalcredito ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtWallet_Wallettotalcredito = value;
            SetDirty("Wallettotalcredito");
         }

      }

      public void gxTv_SdtWallet_Wallettotalcredito_SetNull( )
      {
         gxTv_SdtWallet_Wallettotalcredito = 0;
         SetDirty("Wallettotalcredito");
         return  ;
      }

      public bool gxTv_SdtWallet_Wallettotalcredito_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "WalletSaldo" )]
      [  XmlElement( ElementName = "WalletSaldo"   )]
      public decimal gxTpr_Walletsaldo
      {
         get {
            return gxTv_SdtWallet_Walletsaldo ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtWallet_Walletsaldo = value;
            SetDirty("Walletsaldo");
         }

      }

      public void gxTv_SdtWallet_Walletsaldo_SetNull( )
      {
         gxTv_SdtWallet_Walletsaldo = 0;
         SetDirty("Walletsaldo");
         return  ;
      }

      public bool gxTv_SdtWallet_Walletsaldo_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "WalletSolicitudesPendientes" )]
      [  XmlElement( ElementName = "WalletSolicitudesPendientes"   )]
      public decimal gxTpr_Walletsolicitudespendientes
      {
         get {
            return gxTv_SdtWallet_Walletsolicitudespendientes ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtWallet_Walletsolicitudespendientes = value;
            SetDirty("Walletsolicitudespendientes");
         }

      }

      public void gxTv_SdtWallet_Walletsolicitudespendientes_SetNull( )
      {
         gxTv_SdtWallet_Walletsolicitudespendientes = 0;
         SetDirty("Walletsolicitudespendientes");
         return  ;
      }

      public bool gxTv_SdtWallet_Walletsolicitudespendientes_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "WalletSaldoAlDia" )]
      [  XmlElement( ElementName = "WalletSaldoAlDia"   )]
      public decimal gxTpr_Walletsaldoaldia
      {
         get {
            return gxTv_SdtWallet_Walletsaldoaldia ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtWallet_Walletsaldoaldia = value;
            SetDirty("Walletsaldoaldia");
         }

      }

      public void gxTv_SdtWallet_Walletsaldoaldia_SetNull( )
      {
         gxTv_SdtWallet_Walletsaldoaldia = 0;
         SetDirty("Walletsaldoaldia");
         return  ;
      }

      public bool gxTv_SdtWallet_Walletsaldoaldia_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "WalletEstado" )]
      [  XmlElement( ElementName = "WalletEstado"   )]
      public string gxTpr_Walletestado
      {
         get {
            return gxTv_SdtWallet_Walletestado ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtWallet_Walletestado = value;
            SetDirty("Walletestado");
         }

      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtWallet_Mode ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtWallet_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtWallet_Mode_SetNull( )
      {
         gxTv_SdtWallet_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtWallet_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtWallet_Initialized ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtWallet_Initialized = value;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtWallet_Initialized_SetNull( )
      {
         gxTv_SdtWallet_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtWallet_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "WalletId_Z" )]
      [  XmlElement( ElementName = "WalletId_Z"   )]
      public long gxTpr_Walletid_Z
      {
         get {
            return gxTv_SdtWallet_Walletid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtWallet_Walletid_Z = value;
            SetDirty("Walletid_Z");
         }

      }

      public void gxTv_SdtWallet_Walletid_Z_SetNull( )
      {
         gxTv_SdtWallet_Walletid_Z = 0;
         SetDirty("Walletid_Z");
         return  ;
      }

      public bool gxTv_SdtWallet_Walletid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TipoCuentaId_Z" )]
      [  XmlElement( ElementName = "TipoCuentaId_Z"   )]
      public long gxTpr_Tipocuentaid_Z
      {
         get {
            return gxTv_SdtWallet_Tipocuentaid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtWallet_Tipocuentaid_Z = value;
            SetDirty("Tipocuentaid_Z");
         }

      }

      public void gxTv_SdtWallet_Tipocuentaid_Z_SetNull( )
      {
         gxTv_SdtWallet_Tipocuentaid_Z = 0;
         SetDirty("Tipocuentaid_Z");
         return  ;
      }

      public bool gxTv_SdtWallet_Tipocuentaid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TipoCuentaConcepto_Z" )]
      [  XmlElement( ElementName = "TipoCuentaConcepto_Z"   )]
      public string gxTpr_Tipocuentaconcepto_Z
      {
         get {
            return gxTv_SdtWallet_Tipocuentaconcepto_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtWallet_Tipocuentaconcepto_Z = value;
            SetDirty("Tipocuentaconcepto_Z");
         }

      }

      public void gxTv_SdtWallet_Tipocuentaconcepto_Z_SetNull( )
      {
         gxTv_SdtWallet_Tipocuentaconcepto_Z = "";
         SetDirty("Tipocuentaconcepto_Z");
         return  ;
      }

      public bool gxTv_SdtWallet_Tipocuentaconcepto_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TipoCuentaNombre_Z" )]
      [  XmlElement( ElementName = "TipoCuentaNombre_Z"   )]
      public string gxTpr_Tipocuentanombre_Z
      {
         get {
            return gxTv_SdtWallet_Tipocuentanombre_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtWallet_Tipocuentanombre_Z = value;
            SetDirty("Tipocuentanombre_Z");
         }

      }

      public void gxTv_SdtWallet_Tipocuentanombre_Z_SetNull( )
      {
         gxTv_SdtWallet_Tipocuentanombre_Z = "";
         SetDirty("Tipocuentanombre_Z");
         return  ;
      }

      public bool gxTv_SdtWallet_Tipocuentanombre_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "WalletTipoEntidad_Z" )]
      [  XmlElement( ElementName = "WalletTipoEntidad_Z"   )]
      public string gxTpr_Wallettipoentidad_Z
      {
         get {
            return gxTv_SdtWallet_Wallettipoentidad_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtWallet_Wallettipoentidad_Z = value;
            SetDirty("Wallettipoentidad_Z");
         }

      }

      public void gxTv_SdtWallet_Wallettipoentidad_Z_SetNull( )
      {
         gxTv_SdtWallet_Wallettipoentidad_Z = "";
         SetDirty("Wallettipoentidad_Z");
         return  ;
      }

      public bool gxTv_SdtWallet_Wallettipoentidad_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "WalletCodRefencia_Z" )]
      [  XmlElement( ElementName = "WalletCodRefencia_Z"   )]
      public string gxTpr_Walletcodrefencia_Z
      {
         get {
            return gxTv_SdtWallet_Walletcodrefencia_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtWallet_Walletcodrefencia_Z = value;
            SetDirty("Walletcodrefencia_Z");
         }

      }

      public void gxTv_SdtWallet_Walletcodrefencia_Z_SetNull( )
      {
         gxTv_SdtWallet_Walletcodrefencia_Z = "";
         SetDirty("Walletcodrefencia_Z");
         return  ;
      }

      public bool gxTv_SdtWallet_Walletcodrefencia_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "WalletNombre_Z" )]
      [  XmlElement( ElementName = "WalletNombre_Z"   )]
      public string gxTpr_Walletnombre_Z
      {
         get {
            return gxTv_SdtWallet_Walletnombre_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtWallet_Walletnombre_Z = value;
            SetDirty("Walletnombre_Z");
         }

      }

      public void gxTv_SdtWallet_Walletnombre_Z_SetNull( )
      {
         gxTv_SdtWallet_Walletnombre_Z = "";
         SetDirty("Walletnombre_Z");
         return  ;
      }

      public bool gxTv_SdtWallet_Walletnombre_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "MonedaId_Z" )]
      [  XmlElement( ElementName = "MonedaId_Z"   )]
      public short gxTpr_Monedaid_Z
      {
         get {
            return gxTv_SdtWallet_Monedaid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtWallet_Monedaid_Z = value;
            SetDirty("Monedaid_Z");
         }

      }

      public void gxTv_SdtWallet_Monedaid_Z_SetNull( )
      {
         gxTv_SdtWallet_Monedaid_Z = 0;
         SetDirty("Monedaid_Z");
         return  ;
      }

      public bool gxTv_SdtWallet_Monedaid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "MonedaISOSimbolo_Z" )]
      [  XmlElement( ElementName = "MonedaISOSimbolo_Z"   )]
      public string gxTpr_Monedaisosimbolo_Z
      {
         get {
            return gxTv_SdtWallet_Monedaisosimbolo_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtWallet_Monedaisosimbolo_Z = value;
            SetDirty("Monedaisosimbolo_Z");
         }

      }

      public void gxTv_SdtWallet_Monedaisosimbolo_Z_SetNull( )
      {
         gxTv_SdtWallet_Monedaisosimbolo_Z = "";
         SetDirty("Monedaisosimbolo_Z");
         return  ;
      }

      public bool gxTv_SdtWallet_Monedaisosimbolo_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "WalletTotalDebito_Z" )]
      [  XmlElement( ElementName = "WalletTotalDebito_Z"   )]
      public decimal gxTpr_Wallettotaldebito_Z
      {
         get {
            return gxTv_SdtWallet_Wallettotaldebito_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtWallet_Wallettotaldebito_Z = value;
            SetDirty("Wallettotaldebito_Z");
         }

      }

      public void gxTv_SdtWallet_Wallettotaldebito_Z_SetNull( )
      {
         gxTv_SdtWallet_Wallettotaldebito_Z = 0;
         SetDirty("Wallettotaldebito_Z");
         return  ;
      }

      public bool gxTv_SdtWallet_Wallettotaldebito_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "WalletTotalCredito_Z" )]
      [  XmlElement( ElementName = "WalletTotalCredito_Z"   )]
      public decimal gxTpr_Wallettotalcredito_Z
      {
         get {
            return gxTv_SdtWallet_Wallettotalcredito_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtWallet_Wallettotalcredito_Z = value;
            SetDirty("Wallettotalcredito_Z");
         }

      }

      public void gxTv_SdtWallet_Wallettotalcredito_Z_SetNull( )
      {
         gxTv_SdtWallet_Wallettotalcredito_Z = 0;
         SetDirty("Wallettotalcredito_Z");
         return  ;
      }

      public bool gxTv_SdtWallet_Wallettotalcredito_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "WalletSaldo_Z" )]
      [  XmlElement( ElementName = "WalletSaldo_Z"   )]
      public decimal gxTpr_Walletsaldo_Z
      {
         get {
            return gxTv_SdtWallet_Walletsaldo_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtWallet_Walletsaldo_Z = value;
            SetDirty("Walletsaldo_Z");
         }

      }

      public void gxTv_SdtWallet_Walletsaldo_Z_SetNull( )
      {
         gxTv_SdtWallet_Walletsaldo_Z = 0;
         SetDirty("Walletsaldo_Z");
         return  ;
      }

      public bool gxTv_SdtWallet_Walletsaldo_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "WalletSolicitudesPendientes_Z" )]
      [  XmlElement( ElementName = "WalletSolicitudesPendientes_Z"   )]
      public decimal gxTpr_Walletsolicitudespendientes_Z
      {
         get {
            return gxTv_SdtWallet_Walletsolicitudespendientes_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtWallet_Walletsolicitudespendientes_Z = value;
            SetDirty("Walletsolicitudespendientes_Z");
         }

      }

      public void gxTv_SdtWallet_Walletsolicitudespendientes_Z_SetNull( )
      {
         gxTv_SdtWallet_Walletsolicitudespendientes_Z = 0;
         SetDirty("Walletsolicitudespendientes_Z");
         return  ;
      }

      public bool gxTv_SdtWallet_Walletsolicitudespendientes_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "WalletSaldoAlDia_Z" )]
      [  XmlElement( ElementName = "WalletSaldoAlDia_Z"   )]
      public decimal gxTpr_Walletsaldoaldia_Z
      {
         get {
            return gxTv_SdtWallet_Walletsaldoaldia_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtWallet_Walletsaldoaldia_Z = value;
            SetDirty("Walletsaldoaldia_Z");
         }

      }

      public void gxTv_SdtWallet_Walletsaldoaldia_Z_SetNull( )
      {
         gxTv_SdtWallet_Walletsaldoaldia_Z = 0;
         SetDirty("Walletsaldoaldia_Z");
         return  ;
      }

      public bool gxTv_SdtWallet_Walletsaldoaldia_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "WalletEstado_Z" )]
      [  XmlElement( ElementName = "WalletEstado_Z"   )]
      public string gxTpr_Walletestado_Z
      {
         get {
            return gxTv_SdtWallet_Walletestado_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtWallet_Walletestado_Z = value;
            SetDirty("Walletestado_Z");
         }

      }

      public void gxTv_SdtWallet_Walletestado_Z_SetNull( )
      {
         gxTv_SdtWallet_Walletestado_Z = "";
         SetDirty("Walletestado_Z");
         return  ;
      }

      public bool gxTv_SdtWallet_Walletestado_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "MonedaId_N" )]
      [  XmlElement( ElementName = "MonedaId_N"   )]
      public short gxTpr_Monedaid_N
      {
         get {
            return gxTv_SdtWallet_Monedaid_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtWallet_Monedaid_N = value;
            SetDirty("Monedaid_N");
         }

      }

      public void gxTv_SdtWallet_Monedaid_N_SetNull( )
      {
         gxTv_SdtWallet_Monedaid_N = 0;
         SetDirty("Monedaid_N");
         return  ;
      }

      public bool gxTv_SdtWallet_Monedaid_N_IsNull( )
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
         gxTv_SdtWallet_Tipocuentaconcepto = "";
         gxTv_SdtWallet_Tipocuentanombre = "";
         gxTv_SdtWallet_Wallettipoentidad = "";
         gxTv_SdtWallet_Walletcodrefencia = "";
         gxTv_SdtWallet_Walletnombre = "";
         gxTv_SdtWallet_Monedaisosimbolo = "";
         gxTv_SdtWallet_Walletestado = "";
         gxTv_SdtWallet_Mode = "";
         gxTv_SdtWallet_Tipocuentaconcepto_Z = "";
         gxTv_SdtWallet_Tipocuentanombre_Z = "";
         gxTv_SdtWallet_Wallettipoentidad_Z = "";
         gxTv_SdtWallet_Walletcodrefencia_Z = "";
         gxTv_SdtWallet_Walletnombre_Z = "";
         gxTv_SdtWallet_Monedaisosimbolo_Z = "";
         gxTv_SdtWallet_Walletestado_Z = "";
         IGxSilentTrn obj;
         obj = (IGxSilentTrn)ClassLoader.FindInstance( "wallet", "GeneXus.Programs.wallet_bc", new Object[] {context}, constructorCallingAssembly);;
         obj.initialize();
         obj.SetSDT(this, 1);
         setTransaction( obj) ;
         obj.SetMode("INS");
         return  ;
      }

      public short isNull( )
      {
         return sdtIsNull ;
      }

      private short sdtIsNull ;
      private short gxTv_SdtWallet_Monedaid ;
      private short gxTv_SdtWallet_Initialized ;
      private short gxTv_SdtWallet_Monedaid_Z ;
      private short gxTv_SdtWallet_Monedaid_N ;
      private long gxTv_SdtWallet_Walletid ;
      private long gxTv_SdtWallet_Tipocuentaid ;
      private long gxTv_SdtWallet_Walletid_Z ;
      private long gxTv_SdtWallet_Tipocuentaid_Z ;
      private decimal gxTv_SdtWallet_Wallettotaldebito ;
      private decimal gxTv_SdtWallet_Wallettotalcredito ;
      private decimal gxTv_SdtWallet_Walletsaldo ;
      private decimal gxTv_SdtWallet_Walletsolicitudespendientes ;
      private decimal gxTv_SdtWallet_Walletsaldoaldia ;
      private decimal gxTv_SdtWallet_Wallettotaldebito_Z ;
      private decimal gxTv_SdtWallet_Wallettotalcredito_Z ;
      private decimal gxTv_SdtWallet_Walletsaldo_Z ;
      private decimal gxTv_SdtWallet_Walletsolicitudespendientes_Z ;
      private decimal gxTv_SdtWallet_Walletsaldoaldia_Z ;
      private string gxTv_SdtWallet_Tipocuentaconcepto ;
      private string gxTv_SdtWallet_Tipocuentanombre ;
      private string gxTv_SdtWallet_Wallettipoentidad ;
      private string gxTv_SdtWallet_Walletcodrefencia ;
      private string gxTv_SdtWallet_Walletnombre ;
      private string gxTv_SdtWallet_Monedaisosimbolo ;
      private string gxTv_SdtWallet_Walletestado ;
      private string gxTv_SdtWallet_Mode ;
      private string gxTv_SdtWallet_Tipocuentaconcepto_Z ;
      private string gxTv_SdtWallet_Tipocuentanombre_Z ;
      private string gxTv_SdtWallet_Wallettipoentidad_Z ;
      private string gxTv_SdtWallet_Walletcodrefencia_Z ;
      private string gxTv_SdtWallet_Walletnombre_Z ;
      private string gxTv_SdtWallet_Monedaisosimbolo_Z ;
      private string gxTv_SdtWallet_Walletestado_Z ;
      private GXBCLevelCollection<SdtWallet_Balances> gxTv_SdtWallet_Balances=null ;
   }

   [DataContract(Name = @"Wallet", Namespace = "AlmangoX")]
   [GxJsonSerialization("default")]
   public class SdtWallet_RESTInterface : GxGenericCollectionItem<SdtWallet>, System.Web.SessionState.IRequiresSessionState
   {
      public SdtWallet_RESTInterface( ) : base()
      {
      }

      public SdtWallet_RESTInterface( SdtWallet psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "WalletId" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Walletid
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Walletid), 18, 0)) ;
         }

         set {
            sdt.gxTpr_Walletid = (long)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
         }

      }

      [DataMember( Name = "TipoCuentaId" , Order = 1 )]
      [GxSeudo()]
      public string gxTpr_Tipocuentaid
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Tipocuentaid), 18, 0)) ;
         }

         set {
            sdt.gxTpr_Tipocuentaid = (long)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
         }

      }

      [DataMember( Name = "TipoCuentaConcepto" , Order = 2 )]
      [GxSeudo()]
      public string gxTpr_Tipocuentaconcepto
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Tipocuentaconcepto) ;
         }

         set {
            sdt.gxTpr_Tipocuentaconcepto = value;
         }

      }

      [DataMember( Name = "TipoCuentaNombre" , Order = 3 )]
      [GxSeudo()]
      public string gxTpr_Tipocuentanombre
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Tipocuentanombre) ;
         }

         set {
            sdt.gxTpr_Tipocuentanombre = value;
         }

      }

      [DataMember( Name = "WalletTipoEntidad" , Order = 4 )]
      [GxSeudo()]
      public string gxTpr_Wallettipoentidad
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Wallettipoentidad) ;
         }

         set {
            sdt.gxTpr_Wallettipoentidad = value;
         }

      }

      [DataMember( Name = "WalletCodRefencia" , Order = 5 )]
      [GxSeudo()]
      public string gxTpr_Walletcodrefencia
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Walletcodrefencia) ;
         }

         set {
            sdt.gxTpr_Walletcodrefencia = value;
         }

      }

      [DataMember( Name = "WalletNombre" , Order = 6 )]
      [GxSeudo()]
      public string gxTpr_Walletnombre
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Walletnombre) ;
         }

         set {
            sdt.gxTpr_Walletnombre = value;
         }

      }

      [DataMember( Name = "MonedaId" , Order = 7 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Monedaid
      {
         get {
            return sdt.gxTpr_Monedaid ;
         }

         set {
            sdt.gxTpr_Monedaid = (short)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "MonedaISOSimbolo" , Order = 8 )]
      [GxSeudo()]
      public string gxTpr_Monedaisosimbolo
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Monedaisosimbolo) ;
         }

         set {
            sdt.gxTpr_Monedaisosimbolo = value;
         }

      }

      [DataMember( Name = "Balances" , Order = 9 )]
      public GxGenericCollection<SdtWallet_Balances_RESTInterface> gxTpr_Balances
      {
         get {
            return new GxGenericCollection<SdtWallet_Balances_RESTInterface>(sdt.gxTpr_Balances) ;
         }

         set {
            value.LoadCollection(sdt.gxTpr_Balances);
         }

      }

      [DataMember( Name = "WalletTotalDebito" , Order = 10 )]
      [GxSeudo()]
      public string gxTpr_Wallettotaldebito
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( sdt.gxTpr_Wallettotaldebito, 18, 2)) ;
         }

         set {
            sdt.gxTpr_Wallettotaldebito = NumberUtil.Val( value, ".");
         }

      }

      [DataMember( Name = "WalletTotalCredito" , Order = 11 )]
      [GxSeudo()]
      public string gxTpr_Wallettotalcredito
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( sdt.gxTpr_Wallettotalcredito, 18, 2)) ;
         }

         set {
            sdt.gxTpr_Wallettotalcredito = NumberUtil.Val( value, ".");
         }

      }

      [DataMember( Name = "WalletSaldo" , Order = 12 )]
      [GxSeudo()]
      public string gxTpr_Walletsaldo
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( sdt.gxTpr_Walletsaldo, 18, 2)) ;
         }

         set {
            sdt.gxTpr_Walletsaldo = NumberUtil.Val( value, ".");
         }

      }

      [DataMember( Name = "WalletSolicitudesPendientes" , Order = 13 )]
      [GxSeudo()]
      public string gxTpr_Walletsolicitudespendientes
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( sdt.gxTpr_Walletsolicitudespendientes, 18, 2)) ;
         }

         set {
            sdt.gxTpr_Walletsolicitudespendientes = NumberUtil.Val( value, ".");
         }

      }

      [DataMember( Name = "WalletSaldoAlDia" , Order = 14 )]
      [GxSeudo()]
      public string gxTpr_Walletsaldoaldia
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( sdt.gxTpr_Walletsaldoaldia, 18, 2)) ;
         }

         set {
            sdt.gxTpr_Walletsaldoaldia = NumberUtil.Val( value, ".");
         }

      }

      [DataMember( Name = "WalletEstado" , Order = 15 )]
      [GxSeudo()]
      public string gxTpr_Walletestado
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Walletestado) ;
         }

         set {
            sdt.gxTpr_Walletestado = value;
         }

      }

      public SdtWallet sdt
      {
         get {
            return (SdtWallet)Sdt ;
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
            sdt = new SdtWallet() ;
         }
      }

      [DataMember( Name = "gx_md5_hash" , Order = 16 )]
      public string Hash
      {
         get {
            if ( StringUtil.StrCmp(md5Hash, null) == 0 )
            {
               md5Hash = (string)(getHash());
            }
            return md5Hash ;
         }

         set {
            md5Hash = value ;
         }

      }

      private string md5Hash ;
   }

   [DataContract(Name = @"Wallet", Namespace = "AlmangoX")]
   [GxJsonSerialization("default")]
   public class SdtWallet_RESTLInterface : GxGenericCollectionItem<SdtWallet>, System.Web.SessionState.IRequiresSessionState
   {
      public SdtWallet_RESTLInterface( ) : base()
      {
      }

      public SdtWallet_RESTLInterface( SdtWallet psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "WalletTipoEntidad" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Wallettipoentidad
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Wallettipoentidad) ;
         }

         set {
            sdt.gxTpr_Wallettipoentidad = value;
         }

      }

      [DataMember( Name = "uri" , Order = 1 )]
      public string Uri
      {
         get {
            return "" ;
         }

         set {
         }

      }

      public SdtWallet sdt
      {
         get {
            return (SdtWallet)Sdt ;
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
            sdt = new SdtWallet() ;
         }
      }

   }

}

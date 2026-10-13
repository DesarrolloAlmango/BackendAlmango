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
   [XmlRoot(ElementName = "FeedBack" )]
   [XmlType(TypeName =  "FeedBack" , Namespace = "AlmangoX" )]
   [Serializable]
   public class SdtFeedBack : GxSilentTrnSdt, System.Web.SessionState.IRequiresSessionState
   {
      public SdtFeedBack( )
      {
      }

      public SdtFeedBack( IGxContext context )
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

      public void Load( long AV117FeedBackId )
      {
         IGxSilentTrn obj;
         obj = getTransaction();
         obj.LoadKey(new Object[] {(long)AV117FeedBackId});
         return  ;
      }

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"FeedBackId", typeof(long)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "FeedBack");
         metadata.Set("BT", "FeedBack");
         metadata.Set("PK", "[ \"FeedBackId\" ]");
         metadata.Set("PKAssigned", "[ \"FeedBackId\" ]");
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
         state.Add("gxTpr_Feedbackid_Z");
         state.Add("gxTpr_Feedbacksolicitudid_Z");
         state.Add("gxTpr_Feedbackprofesionalid_Z");
         state.Add("gxTpr_Feedbackclienteid_Z");
         state.Add("gxTpr_Feedbacknum_Z");
         state.Add("gxTpr_Feedbackfechaalta_Z_Nullable");
         state.Add("gxTpr_Feedbackfechamodif_Z_Nullable");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         SdtFeedBack sdt;
         sdt = (SdtFeedBack)(source);
         gxTv_SdtFeedBack_Feedbackid = sdt.gxTv_SdtFeedBack_Feedbackid ;
         gxTv_SdtFeedBack_Feedbacksolicitudid = sdt.gxTv_SdtFeedBack_Feedbacksolicitudid ;
         gxTv_SdtFeedBack_Feedbackprofesionalid = sdt.gxTv_SdtFeedBack_Feedbackprofesionalid ;
         gxTv_SdtFeedBack_Feedbackclienteid = sdt.gxTv_SdtFeedBack_Feedbackclienteid ;
         gxTv_SdtFeedBack_Feedbacknum = sdt.gxTv_SdtFeedBack_Feedbacknum ;
         gxTv_SdtFeedBack_Feedbackcomentario = sdt.gxTv_SdtFeedBack_Feedbackcomentario ;
         gxTv_SdtFeedBack_Feedbackfechaalta = sdt.gxTv_SdtFeedBack_Feedbackfechaalta ;
         gxTv_SdtFeedBack_Feedbackfechamodif = sdt.gxTv_SdtFeedBack_Feedbackfechamodif ;
         gxTv_SdtFeedBack_Mode = sdt.gxTv_SdtFeedBack_Mode ;
         gxTv_SdtFeedBack_Initialized = sdt.gxTv_SdtFeedBack_Initialized ;
         gxTv_SdtFeedBack_Feedbackid_Z = sdt.gxTv_SdtFeedBack_Feedbackid_Z ;
         gxTv_SdtFeedBack_Feedbacksolicitudid_Z = sdt.gxTv_SdtFeedBack_Feedbacksolicitudid_Z ;
         gxTv_SdtFeedBack_Feedbackprofesionalid_Z = sdt.gxTv_SdtFeedBack_Feedbackprofesionalid_Z ;
         gxTv_SdtFeedBack_Feedbackclienteid_Z = sdt.gxTv_SdtFeedBack_Feedbackclienteid_Z ;
         gxTv_SdtFeedBack_Feedbacknum_Z = sdt.gxTv_SdtFeedBack_Feedbacknum_Z ;
         gxTv_SdtFeedBack_Feedbackfechaalta_Z = sdt.gxTv_SdtFeedBack_Feedbackfechaalta_Z ;
         gxTv_SdtFeedBack_Feedbackfechamodif_Z = sdt.gxTv_SdtFeedBack_Feedbackfechamodif_Z ;
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
         AddObjectProperty("FeedBackId", StringUtil.LTrim( StringUtil.Str( (decimal)(gxTv_SdtFeedBack_Feedbackid), 18, 0)), false, includeNonInitialized);
         AddObjectProperty("FeedBackSolicitudId", StringUtil.LTrim( StringUtil.Str( (decimal)(gxTv_SdtFeedBack_Feedbacksolicitudid), 18, 0)), false, includeNonInitialized);
         AddObjectProperty("FeedBackProfesionalId", gxTv_SdtFeedBack_Feedbackprofesionalid, false, includeNonInitialized);
         AddObjectProperty("FeedBackClienteId", StringUtil.LTrim( StringUtil.Str( (decimal)(gxTv_SdtFeedBack_Feedbackclienteid), 18, 0)), false, includeNonInitialized);
         AddObjectProperty("FeedBackNum", gxTv_SdtFeedBack_Feedbacknum, false, includeNonInitialized);
         AddObjectProperty("FeedBackComentario", gxTv_SdtFeedBack_Feedbackcomentario, false, includeNonInitialized);
         sDateCnv = "";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( gxTv_SdtFeedBack_Feedbackfechaalta)), 10, 0));
         sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( gxTv_SdtFeedBack_Feedbackfechaalta)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( gxTv_SdtFeedBack_Feedbackfechaalta)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         AddObjectProperty("FeedBackFechaAlta", sDateCnv, false, includeNonInitialized);
         sDateCnv = "";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( gxTv_SdtFeedBack_Feedbackfechamodif)), 10, 0));
         sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( gxTv_SdtFeedBack_Feedbackfechamodif)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( gxTv_SdtFeedBack_Feedbackfechamodif)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         AddObjectProperty("FeedBackFechaModif", sDateCnv, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_SdtFeedBack_Mode, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtFeedBack_Initialized, false, includeNonInitialized);
            AddObjectProperty("FeedBackId_Z", StringUtil.LTrim( StringUtil.Str( (decimal)(gxTv_SdtFeedBack_Feedbackid_Z), 18, 0)), false, includeNonInitialized);
            AddObjectProperty("FeedBackSolicitudId_Z", StringUtil.LTrim( StringUtil.Str( (decimal)(gxTv_SdtFeedBack_Feedbacksolicitudid_Z), 18, 0)), false, includeNonInitialized);
            AddObjectProperty("FeedBackProfesionalId_Z", gxTv_SdtFeedBack_Feedbackprofesionalid_Z, false, includeNonInitialized);
            AddObjectProperty("FeedBackClienteId_Z", StringUtil.LTrim( StringUtil.Str( (decimal)(gxTv_SdtFeedBack_Feedbackclienteid_Z), 18, 0)), false, includeNonInitialized);
            AddObjectProperty("FeedBackNum_Z", gxTv_SdtFeedBack_Feedbacknum_Z, false, includeNonInitialized);
            sDateCnv = "";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( gxTv_SdtFeedBack_Feedbackfechaalta_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( gxTv_SdtFeedBack_Feedbackfechaalta_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( gxTv_SdtFeedBack_Feedbackfechaalta_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            AddObjectProperty("FeedBackFechaAlta_Z", sDateCnv, false, includeNonInitialized);
            sDateCnv = "";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( gxTv_SdtFeedBack_Feedbackfechamodif_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( gxTv_SdtFeedBack_Feedbackfechamodif_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( gxTv_SdtFeedBack_Feedbackfechamodif_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            AddObjectProperty("FeedBackFechaModif_Z", sDateCnv, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( SdtFeedBack sdt )
      {
         if ( sdt.IsDirty("FeedBackId") )
         {
            sdtIsNull = 0;
            gxTv_SdtFeedBack_Feedbackid = sdt.gxTv_SdtFeedBack_Feedbackid ;
         }
         if ( sdt.IsDirty("FeedBackSolicitudId") )
         {
            sdtIsNull = 0;
            gxTv_SdtFeedBack_Feedbacksolicitudid = sdt.gxTv_SdtFeedBack_Feedbacksolicitudid ;
         }
         if ( sdt.IsDirty("FeedBackProfesionalId") )
         {
            sdtIsNull = 0;
            gxTv_SdtFeedBack_Feedbackprofesionalid = sdt.gxTv_SdtFeedBack_Feedbackprofesionalid ;
         }
         if ( sdt.IsDirty("FeedBackClienteId") )
         {
            sdtIsNull = 0;
            gxTv_SdtFeedBack_Feedbackclienteid = sdt.gxTv_SdtFeedBack_Feedbackclienteid ;
         }
         if ( sdt.IsDirty("FeedBackNum") )
         {
            sdtIsNull = 0;
            gxTv_SdtFeedBack_Feedbacknum = sdt.gxTv_SdtFeedBack_Feedbacknum ;
         }
         if ( sdt.IsDirty("FeedBackComentario") )
         {
            sdtIsNull = 0;
            gxTv_SdtFeedBack_Feedbackcomentario = sdt.gxTv_SdtFeedBack_Feedbackcomentario ;
         }
         if ( sdt.IsDirty("FeedBackFechaAlta") )
         {
            sdtIsNull = 0;
            gxTv_SdtFeedBack_Feedbackfechaalta = sdt.gxTv_SdtFeedBack_Feedbackfechaalta ;
         }
         if ( sdt.IsDirty("FeedBackFechaModif") )
         {
            sdtIsNull = 0;
            gxTv_SdtFeedBack_Feedbackfechamodif = sdt.gxTv_SdtFeedBack_Feedbackfechamodif ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "FeedBackId" )]
      [  XmlElement( ElementName = "FeedBackId"   )]
      public long gxTpr_Feedbackid
      {
         get {
            return gxTv_SdtFeedBack_Feedbackid ;
         }

         set {
            sdtIsNull = 0;
            if ( gxTv_SdtFeedBack_Feedbackid != value )
            {
               gxTv_SdtFeedBack_Mode = "INS";
               this.gxTv_SdtFeedBack_Feedbackid_Z_SetNull( );
               this.gxTv_SdtFeedBack_Feedbacksolicitudid_Z_SetNull( );
               this.gxTv_SdtFeedBack_Feedbackprofesionalid_Z_SetNull( );
               this.gxTv_SdtFeedBack_Feedbackclienteid_Z_SetNull( );
               this.gxTv_SdtFeedBack_Feedbacknum_Z_SetNull( );
               this.gxTv_SdtFeedBack_Feedbackfechaalta_Z_SetNull( );
               this.gxTv_SdtFeedBack_Feedbackfechamodif_Z_SetNull( );
            }
            gxTv_SdtFeedBack_Feedbackid = value;
            SetDirty("Feedbackid");
         }

      }

      [  SoapElement( ElementName = "FeedBackSolicitudId" )]
      [  XmlElement( ElementName = "FeedBackSolicitudId"   )]
      public long gxTpr_Feedbacksolicitudid
      {
         get {
            return gxTv_SdtFeedBack_Feedbacksolicitudid ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtFeedBack_Feedbacksolicitudid = value;
            SetDirty("Feedbacksolicitudid");
         }

      }

      [  SoapElement( ElementName = "FeedBackProfesionalId" )]
      [  XmlElement( ElementName = "FeedBackProfesionalId"   )]
      public string gxTpr_Feedbackprofesionalid
      {
         get {
            return gxTv_SdtFeedBack_Feedbackprofesionalid ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtFeedBack_Feedbackprofesionalid = value;
            SetDirty("Feedbackprofesionalid");
         }

      }

      [  SoapElement( ElementName = "FeedBackClienteId" )]
      [  XmlElement( ElementName = "FeedBackClienteId"   )]
      public long gxTpr_Feedbackclienteid
      {
         get {
            return gxTv_SdtFeedBack_Feedbackclienteid ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtFeedBack_Feedbackclienteid = value;
            SetDirty("Feedbackclienteid");
         }

      }

      [  SoapElement( ElementName = "FeedBackNum" )]
      [  XmlElement( ElementName = "FeedBackNum"   )]
      public long gxTpr_Feedbacknum
      {
         get {
            return gxTv_SdtFeedBack_Feedbacknum ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtFeedBack_Feedbacknum = value;
            SetDirty("Feedbacknum");
         }

      }

      [  SoapElement( ElementName = "FeedBackComentario" )]
      [  XmlElement( ElementName = "FeedBackComentario"   )]
      public string gxTpr_Feedbackcomentario
      {
         get {
            return gxTv_SdtFeedBack_Feedbackcomentario ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtFeedBack_Feedbackcomentario = value;
            SetDirty("Feedbackcomentario");
         }

      }

      [  SoapElement( ElementName = "FeedBackFechaAlta" )]
      [  XmlElement( ElementName = "FeedBackFechaAlta"  , IsNullable=true )]
      public string gxTpr_Feedbackfechaalta_Nullable
      {
         get {
            if ( gxTv_SdtFeedBack_Feedbackfechaalta == DateTime.MinValue)
               return null;
            return new GxDateString(gxTv_SdtFeedBack_Feedbackfechaalta).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDateString.NullValue )
               gxTv_SdtFeedBack_Feedbackfechaalta = DateTime.MinValue;
            else
               gxTv_SdtFeedBack_Feedbackfechaalta = DateTime.Parse( value);
         }

      }

      [SoapIgnore]
      [XmlIgnore]
      public DateTime gxTpr_Feedbackfechaalta
      {
         get {
            return gxTv_SdtFeedBack_Feedbackfechaalta ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtFeedBack_Feedbackfechaalta = DateTimeUtil.ResetTime(value);
            SetDirty("Feedbackfechaalta");
         }

      }

      [  SoapElement( ElementName = "FeedBackFechaModif" )]
      [  XmlElement( ElementName = "FeedBackFechaModif"  , IsNullable=true )]
      public string gxTpr_Feedbackfechamodif_Nullable
      {
         get {
            if ( gxTv_SdtFeedBack_Feedbackfechamodif == DateTime.MinValue)
               return null;
            return new GxDateString(gxTv_SdtFeedBack_Feedbackfechamodif).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDateString.NullValue )
               gxTv_SdtFeedBack_Feedbackfechamodif = DateTime.MinValue;
            else
               gxTv_SdtFeedBack_Feedbackfechamodif = DateTime.Parse( value);
         }

      }

      [SoapIgnore]
      [XmlIgnore]
      public DateTime gxTpr_Feedbackfechamodif
      {
         get {
            return gxTv_SdtFeedBack_Feedbackfechamodif ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtFeedBack_Feedbackfechamodif = DateTimeUtil.ResetTime(value);
            SetDirty("Feedbackfechamodif");
         }

      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtFeedBack_Mode ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtFeedBack_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtFeedBack_Mode_SetNull( )
      {
         gxTv_SdtFeedBack_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtFeedBack_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtFeedBack_Initialized ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtFeedBack_Initialized = value;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtFeedBack_Initialized_SetNull( )
      {
         gxTv_SdtFeedBack_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtFeedBack_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "FeedBackId_Z" )]
      [  XmlElement( ElementName = "FeedBackId_Z"   )]
      public long gxTpr_Feedbackid_Z
      {
         get {
            return gxTv_SdtFeedBack_Feedbackid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtFeedBack_Feedbackid_Z = value;
            SetDirty("Feedbackid_Z");
         }

      }

      public void gxTv_SdtFeedBack_Feedbackid_Z_SetNull( )
      {
         gxTv_SdtFeedBack_Feedbackid_Z = 0;
         SetDirty("Feedbackid_Z");
         return  ;
      }

      public bool gxTv_SdtFeedBack_Feedbackid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "FeedBackSolicitudId_Z" )]
      [  XmlElement( ElementName = "FeedBackSolicitudId_Z"   )]
      public long gxTpr_Feedbacksolicitudid_Z
      {
         get {
            return gxTv_SdtFeedBack_Feedbacksolicitudid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtFeedBack_Feedbacksolicitudid_Z = value;
            SetDirty("Feedbacksolicitudid_Z");
         }

      }

      public void gxTv_SdtFeedBack_Feedbacksolicitudid_Z_SetNull( )
      {
         gxTv_SdtFeedBack_Feedbacksolicitudid_Z = 0;
         SetDirty("Feedbacksolicitudid_Z");
         return  ;
      }

      public bool gxTv_SdtFeedBack_Feedbacksolicitudid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "FeedBackProfesionalId_Z" )]
      [  XmlElement( ElementName = "FeedBackProfesionalId_Z"   )]
      public string gxTpr_Feedbackprofesionalid_Z
      {
         get {
            return gxTv_SdtFeedBack_Feedbackprofesionalid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtFeedBack_Feedbackprofesionalid_Z = value;
            SetDirty("Feedbackprofesionalid_Z");
         }

      }

      public void gxTv_SdtFeedBack_Feedbackprofesionalid_Z_SetNull( )
      {
         gxTv_SdtFeedBack_Feedbackprofesionalid_Z = "";
         SetDirty("Feedbackprofesionalid_Z");
         return  ;
      }

      public bool gxTv_SdtFeedBack_Feedbackprofesionalid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "FeedBackClienteId_Z" )]
      [  XmlElement( ElementName = "FeedBackClienteId_Z"   )]
      public long gxTpr_Feedbackclienteid_Z
      {
         get {
            return gxTv_SdtFeedBack_Feedbackclienteid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtFeedBack_Feedbackclienteid_Z = value;
            SetDirty("Feedbackclienteid_Z");
         }

      }

      public void gxTv_SdtFeedBack_Feedbackclienteid_Z_SetNull( )
      {
         gxTv_SdtFeedBack_Feedbackclienteid_Z = 0;
         SetDirty("Feedbackclienteid_Z");
         return  ;
      }

      public bool gxTv_SdtFeedBack_Feedbackclienteid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "FeedBackNum_Z" )]
      [  XmlElement( ElementName = "FeedBackNum_Z"   )]
      public long gxTpr_Feedbacknum_Z
      {
         get {
            return gxTv_SdtFeedBack_Feedbacknum_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtFeedBack_Feedbacknum_Z = value;
            SetDirty("Feedbacknum_Z");
         }

      }

      public void gxTv_SdtFeedBack_Feedbacknum_Z_SetNull( )
      {
         gxTv_SdtFeedBack_Feedbacknum_Z = 0;
         SetDirty("Feedbacknum_Z");
         return  ;
      }

      public bool gxTv_SdtFeedBack_Feedbacknum_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "FeedBackFechaAlta_Z" )]
      [  XmlElement( ElementName = "FeedBackFechaAlta_Z"  , IsNullable=true )]
      public string gxTpr_Feedbackfechaalta_Z_Nullable
      {
         get {
            if ( gxTv_SdtFeedBack_Feedbackfechaalta_Z == DateTime.MinValue)
               return null;
            return new GxDateString(gxTv_SdtFeedBack_Feedbackfechaalta_Z).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDateString.NullValue )
               gxTv_SdtFeedBack_Feedbackfechaalta_Z = DateTime.MinValue;
            else
               gxTv_SdtFeedBack_Feedbackfechaalta_Z = DateTime.Parse( value);
         }

      }

      [SoapIgnore]
      [XmlIgnore]
      public DateTime gxTpr_Feedbackfechaalta_Z
      {
         get {
            return gxTv_SdtFeedBack_Feedbackfechaalta_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtFeedBack_Feedbackfechaalta_Z = DateTimeUtil.ResetTime(value);
            SetDirty("Feedbackfechaalta_Z");
         }

      }

      public void gxTv_SdtFeedBack_Feedbackfechaalta_Z_SetNull( )
      {
         gxTv_SdtFeedBack_Feedbackfechaalta_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Feedbackfechaalta_Z");
         return  ;
      }

      public bool gxTv_SdtFeedBack_Feedbackfechaalta_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "FeedBackFechaModif_Z" )]
      [  XmlElement( ElementName = "FeedBackFechaModif_Z"  , IsNullable=true )]
      public string gxTpr_Feedbackfechamodif_Z_Nullable
      {
         get {
            if ( gxTv_SdtFeedBack_Feedbackfechamodif_Z == DateTime.MinValue)
               return null;
            return new GxDateString(gxTv_SdtFeedBack_Feedbackfechamodif_Z).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDateString.NullValue )
               gxTv_SdtFeedBack_Feedbackfechamodif_Z = DateTime.MinValue;
            else
               gxTv_SdtFeedBack_Feedbackfechamodif_Z = DateTime.Parse( value);
         }

      }

      [SoapIgnore]
      [XmlIgnore]
      public DateTime gxTpr_Feedbackfechamodif_Z
      {
         get {
            return gxTv_SdtFeedBack_Feedbackfechamodif_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtFeedBack_Feedbackfechamodif_Z = DateTimeUtil.ResetTime(value);
            SetDirty("Feedbackfechamodif_Z");
         }

      }

      public void gxTv_SdtFeedBack_Feedbackfechamodif_Z_SetNull( )
      {
         gxTv_SdtFeedBack_Feedbackfechamodif_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Feedbackfechamodif_Z");
         return  ;
      }

      public bool gxTv_SdtFeedBack_Feedbackfechamodif_Z_IsNull( )
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
         gxTv_SdtFeedBack_Feedbackprofesionalid = "";
         gxTv_SdtFeedBack_Feedbackcomentario = "";
         gxTv_SdtFeedBack_Feedbackfechaalta = DateTime.MinValue;
         gxTv_SdtFeedBack_Feedbackfechamodif = DateTime.MinValue;
         gxTv_SdtFeedBack_Mode = "";
         gxTv_SdtFeedBack_Feedbackprofesionalid_Z = "";
         gxTv_SdtFeedBack_Feedbackfechaalta_Z = DateTime.MinValue;
         gxTv_SdtFeedBack_Feedbackfechamodif_Z = DateTime.MinValue;
         sDateCnv = "";
         sNumToPad = "";
         IGxSilentTrn obj;
         obj = (IGxSilentTrn)ClassLoader.FindInstance( "feedback", "GeneXus.Programs.feedback_bc", new Object[] {context}, constructorCallingAssembly);;
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
      private short gxTv_SdtFeedBack_Initialized ;
      private long gxTv_SdtFeedBack_Feedbackid ;
      private long gxTv_SdtFeedBack_Feedbacksolicitudid ;
      private long gxTv_SdtFeedBack_Feedbackclienteid ;
      private long gxTv_SdtFeedBack_Feedbacknum ;
      private long gxTv_SdtFeedBack_Feedbackid_Z ;
      private long gxTv_SdtFeedBack_Feedbacksolicitudid_Z ;
      private long gxTv_SdtFeedBack_Feedbackclienteid_Z ;
      private long gxTv_SdtFeedBack_Feedbacknum_Z ;
      private string gxTv_SdtFeedBack_Feedbackprofesionalid ;
      private string gxTv_SdtFeedBack_Mode ;
      private string gxTv_SdtFeedBack_Feedbackprofesionalid_Z ;
      private string sDateCnv ;
      private string sNumToPad ;
      private DateTime gxTv_SdtFeedBack_Feedbackfechaalta ;
      private DateTime gxTv_SdtFeedBack_Feedbackfechamodif ;
      private DateTime gxTv_SdtFeedBack_Feedbackfechaalta_Z ;
      private DateTime gxTv_SdtFeedBack_Feedbackfechamodif_Z ;
      private string gxTv_SdtFeedBack_Feedbackcomentario ;
   }

   [DataContract(Name = @"FeedBack", Namespace = "AlmangoX")]
   [GxJsonSerialization("default")]
   public class SdtFeedBack_RESTInterface : GxGenericCollectionItem<SdtFeedBack>, System.Web.SessionState.IRequiresSessionState
   {
      public SdtFeedBack_RESTInterface( ) : base()
      {
      }

      public SdtFeedBack_RESTInterface( SdtFeedBack psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "FeedBackId" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Feedbackid
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Feedbackid), 18, 0)) ;
         }

         set {
            sdt.gxTpr_Feedbackid = (long)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
         }

      }

      [DataMember( Name = "FeedBackSolicitudId" , Order = 1 )]
      [GxSeudo()]
      public string gxTpr_Feedbacksolicitudid
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Feedbacksolicitudid), 18, 0)) ;
         }

         set {
            sdt.gxTpr_Feedbacksolicitudid = (long)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
         }

      }

      [DataMember( Name = "FeedBackProfesionalId" , Order = 2 )]
      [GxSeudo()]
      public string gxTpr_Feedbackprofesionalid
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Feedbackprofesionalid) ;
         }

         set {
            sdt.gxTpr_Feedbackprofesionalid = value;
         }

      }

      [DataMember( Name = "FeedBackClienteId" , Order = 3 )]
      [GxSeudo()]
      public string gxTpr_Feedbackclienteid
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Feedbackclienteid), 18, 0)) ;
         }

         set {
            sdt.gxTpr_Feedbackclienteid = (long)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
         }

      }

      [DataMember( Name = "FeedBackNum" , Order = 4 )]
      [GxSeudo()]
      public string gxTpr_Feedbacknum
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Feedbacknum), 10, 0)) ;
         }

         set {
            sdt.gxTpr_Feedbacknum = (long)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
         }

      }

      [DataMember( Name = "FeedBackComentario" , Order = 5 )]
      public string gxTpr_Feedbackcomentario
      {
         get {
            return sdt.gxTpr_Feedbackcomentario ;
         }

         set {
            sdt.gxTpr_Feedbackcomentario = value;
         }

      }

      [DataMember( Name = "FeedBackFechaAlta" , Order = 6 )]
      [GxSeudo()]
      public string gxTpr_Feedbackfechaalta
      {
         get {
            return DateTimeUtil.DToC2( sdt.gxTpr_Feedbackfechaalta) ;
         }

         set {
            sdt.gxTpr_Feedbackfechaalta = DateTimeUtil.CToD2( value);
         }

      }

      [DataMember( Name = "FeedBackFechaModif" , Order = 7 )]
      [GxSeudo()]
      public string gxTpr_Feedbackfechamodif
      {
         get {
            return DateTimeUtil.DToC2( sdt.gxTpr_Feedbackfechamodif) ;
         }

         set {
            sdt.gxTpr_Feedbackfechamodif = DateTimeUtil.CToD2( value);
         }

      }

      public SdtFeedBack sdt
      {
         get {
            return (SdtFeedBack)Sdt ;
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
            sdt = new SdtFeedBack() ;
         }
      }

      [DataMember( Name = "gx_md5_hash" , Order = 8 )]
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

   [DataContract(Name = @"FeedBack", Namespace = "AlmangoX")]
   [GxJsonSerialization("default")]
   public class SdtFeedBack_RESTLInterface : GxGenericCollectionItem<SdtFeedBack>, System.Web.SessionState.IRequiresSessionState
   {
      public SdtFeedBack_RESTLInterface( ) : base()
      {
      }

      public SdtFeedBack_RESTLInterface( SdtFeedBack psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "FeedBackSolicitudId" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Feedbacksolicitudid
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Feedbacksolicitudid), 18, 0)) ;
         }

         set {
            sdt.gxTpr_Feedbacksolicitudid = (long)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
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

      public SdtFeedBack sdt
      {
         get {
            return (SdtFeedBack)Sdt ;
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
            sdt = new SdtFeedBack() ;
         }
      }

   }

}

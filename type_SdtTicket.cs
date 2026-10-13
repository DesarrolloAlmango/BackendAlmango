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
   [XmlRoot(ElementName = "Ticket" )]
   [XmlType(TypeName =  "Ticket" , Namespace = "AlmangoX" )]
   [Serializable]
   public class SdtTicket : GxSilentTrnSdt, System.Web.SessionState.IRequiresSessionState
   {
      public SdtTicket( )
      {
      }

      public SdtTicket( IGxContext context )
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

      public void Load( long AV1020TicketId )
      {
         IGxSilentTrn obj;
         obj = getTransaction();
         obj.LoadKey(new Object[] {(long)AV1020TicketId});
         return  ;
      }

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"TicketId", typeof(long)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "Ticket");
         metadata.Set("BT", "Ticket");
         metadata.Set("PK", "[ \"TicketId\" ]");
         metadata.Set("PKAssigned", "[ \"TicketId\" ]");
         metadata.Set("FKList", "[ { \"FK\":[ \"TicketMotivoId\" ],\"FKMap\":[  ] } ]");
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
         state.Add("gxTpr_Ticketid_Z");
         state.Add("gxTpr_Ticketsolicitudid_Z");
         state.Add("gxTpr_Ticketmotivoid_Z");
         state.Add("gxTpr_Ticketmotivodescripcion_Z");
         state.Add("gxTpr_Ticketestado_Z");
         state.Add("gxTpr_Ticketcomentario_Z");
         state.Add("gxTpr_Ticketadjunto_Z");
         state.Add("gxTpr_Ticketid_N");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         SdtTicket sdt;
         sdt = (SdtTicket)(source);
         gxTv_SdtTicket_Ticketid = sdt.gxTv_SdtTicket_Ticketid ;
         gxTv_SdtTicket_Ticketsolicitudid = sdt.gxTv_SdtTicket_Ticketsolicitudid ;
         gxTv_SdtTicket_Ticketmotivoid = sdt.gxTv_SdtTicket_Ticketmotivoid ;
         gxTv_SdtTicket_Ticketmotivodescripcion = sdt.gxTv_SdtTicket_Ticketmotivodescripcion ;
         gxTv_SdtTicket_Ticketestado = sdt.gxTv_SdtTicket_Ticketestado ;
         gxTv_SdtTicket_Ticketcomentario = sdt.gxTv_SdtTicket_Ticketcomentario ;
         gxTv_SdtTicket_Ticketadjunto = sdt.gxTv_SdtTicket_Ticketadjunto ;
         gxTv_SdtTicket_Mode = sdt.gxTv_SdtTicket_Mode ;
         gxTv_SdtTicket_Initialized = sdt.gxTv_SdtTicket_Initialized ;
         gxTv_SdtTicket_Ticketid_Z = sdt.gxTv_SdtTicket_Ticketid_Z ;
         gxTv_SdtTicket_Ticketsolicitudid_Z = sdt.gxTv_SdtTicket_Ticketsolicitudid_Z ;
         gxTv_SdtTicket_Ticketmotivoid_Z = sdt.gxTv_SdtTicket_Ticketmotivoid_Z ;
         gxTv_SdtTicket_Ticketmotivodescripcion_Z = sdt.gxTv_SdtTicket_Ticketmotivodescripcion_Z ;
         gxTv_SdtTicket_Ticketestado_Z = sdt.gxTv_SdtTicket_Ticketestado_Z ;
         gxTv_SdtTicket_Ticketcomentario_Z = sdt.gxTv_SdtTicket_Ticketcomentario_Z ;
         gxTv_SdtTicket_Ticketadjunto_Z = sdt.gxTv_SdtTicket_Ticketadjunto_Z ;
         gxTv_SdtTicket_Ticketid_N = sdt.gxTv_SdtTicket_Ticketid_N ;
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
         AddObjectProperty("TicketId", StringUtil.LTrim( StringUtil.Str( (decimal)(gxTv_SdtTicket_Ticketid), 18, 0)), false, includeNonInitialized);
         AddObjectProperty("TicketId_N", gxTv_SdtTicket_Ticketid_N, false, includeNonInitialized);
         AddObjectProperty("TicketSolicitudId", StringUtil.LTrim( StringUtil.Str( (decimal)(gxTv_SdtTicket_Ticketsolicitudid), 18, 0)), false, includeNonInitialized);
         AddObjectProperty("TicketMotivoId", StringUtil.LTrim( StringUtil.Str( (decimal)(gxTv_SdtTicket_Ticketmotivoid), 18, 0)), false, includeNonInitialized);
         AddObjectProperty("TicketMotivoDescripcion", gxTv_SdtTicket_Ticketmotivodescripcion, false, includeNonInitialized);
         AddObjectProperty("TicketEstado", gxTv_SdtTicket_Ticketestado, false, includeNonInitialized);
         AddObjectProperty("TicketComentario", gxTv_SdtTicket_Ticketcomentario, false, includeNonInitialized);
         AddObjectProperty("TicketAdjunto", gxTv_SdtTicket_Ticketadjunto, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_SdtTicket_Mode, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtTicket_Initialized, false, includeNonInitialized);
            AddObjectProperty("TicketId_Z", StringUtil.LTrim( StringUtil.Str( (decimal)(gxTv_SdtTicket_Ticketid_Z), 18, 0)), false, includeNonInitialized);
            AddObjectProperty("TicketSolicitudId_Z", StringUtil.LTrim( StringUtil.Str( (decimal)(gxTv_SdtTicket_Ticketsolicitudid_Z), 18, 0)), false, includeNonInitialized);
            AddObjectProperty("TicketMotivoId_Z", StringUtil.LTrim( StringUtil.Str( (decimal)(gxTv_SdtTicket_Ticketmotivoid_Z), 18, 0)), false, includeNonInitialized);
            AddObjectProperty("TicketMotivoDescripcion_Z", gxTv_SdtTicket_Ticketmotivodescripcion_Z, false, includeNonInitialized);
            AddObjectProperty("TicketEstado_Z", gxTv_SdtTicket_Ticketestado_Z, false, includeNonInitialized);
            AddObjectProperty("TicketComentario_Z", gxTv_SdtTicket_Ticketcomentario_Z, false, includeNonInitialized);
            AddObjectProperty("TicketAdjunto_Z", gxTv_SdtTicket_Ticketadjunto_Z, false, includeNonInitialized);
            AddObjectProperty("TicketId_N", gxTv_SdtTicket_Ticketid_N, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( SdtTicket sdt )
      {
         if ( sdt.IsDirty("TicketId") )
         {
            sdtIsNull = 0;
            gxTv_SdtTicket_Ticketid = sdt.gxTv_SdtTicket_Ticketid ;
         }
         if ( sdt.IsDirty("TicketSolicitudId") )
         {
            sdtIsNull = 0;
            gxTv_SdtTicket_Ticketsolicitudid = sdt.gxTv_SdtTicket_Ticketsolicitudid ;
         }
         if ( sdt.IsDirty("TicketMotivoId") )
         {
            sdtIsNull = 0;
            gxTv_SdtTicket_Ticketmotivoid = sdt.gxTv_SdtTicket_Ticketmotivoid ;
         }
         if ( sdt.IsDirty("TicketMotivoDescripcion") )
         {
            sdtIsNull = 0;
            gxTv_SdtTicket_Ticketmotivodescripcion = sdt.gxTv_SdtTicket_Ticketmotivodescripcion ;
         }
         if ( sdt.IsDirty("TicketEstado") )
         {
            sdtIsNull = 0;
            gxTv_SdtTicket_Ticketestado = sdt.gxTv_SdtTicket_Ticketestado ;
         }
         if ( sdt.IsDirty("TicketComentario") )
         {
            sdtIsNull = 0;
            gxTv_SdtTicket_Ticketcomentario = sdt.gxTv_SdtTicket_Ticketcomentario ;
         }
         if ( sdt.IsDirty("TicketAdjunto") )
         {
            sdtIsNull = 0;
            gxTv_SdtTicket_Ticketadjunto = sdt.gxTv_SdtTicket_Ticketadjunto ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "TicketId" )]
      [  XmlElement( ElementName = "TicketId"   )]
      public long gxTpr_Ticketid
      {
         get {
            return gxTv_SdtTicket_Ticketid ;
         }

         set {
            sdtIsNull = 0;
            if ( gxTv_SdtTicket_Ticketid != value )
            {
               gxTv_SdtTicket_Mode = "INS";
               this.gxTv_SdtTicket_Ticketid_Z_SetNull( );
               this.gxTv_SdtTicket_Ticketsolicitudid_Z_SetNull( );
               this.gxTv_SdtTicket_Ticketmotivoid_Z_SetNull( );
               this.gxTv_SdtTicket_Ticketmotivodescripcion_Z_SetNull( );
               this.gxTv_SdtTicket_Ticketestado_Z_SetNull( );
               this.gxTv_SdtTicket_Ticketcomentario_Z_SetNull( );
               this.gxTv_SdtTicket_Ticketadjunto_Z_SetNull( );
            }
            gxTv_SdtTicket_Ticketid = value;
            SetDirty("Ticketid");
         }

      }

      [  SoapElement( ElementName = "TicketSolicitudId" )]
      [  XmlElement( ElementName = "TicketSolicitudId"   )]
      public long gxTpr_Ticketsolicitudid
      {
         get {
            return gxTv_SdtTicket_Ticketsolicitudid ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTicket_Ticketsolicitudid = value;
            SetDirty("Ticketsolicitudid");
         }

      }

      [  SoapElement( ElementName = "TicketMotivoId" )]
      [  XmlElement( ElementName = "TicketMotivoId"   )]
      public long gxTpr_Ticketmotivoid
      {
         get {
            return gxTv_SdtTicket_Ticketmotivoid ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTicket_Ticketmotivoid = value;
            SetDirty("Ticketmotivoid");
         }

      }

      [  SoapElement( ElementName = "TicketMotivoDescripcion" )]
      [  XmlElement( ElementName = "TicketMotivoDescripcion"   )]
      public string gxTpr_Ticketmotivodescripcion
      {
         get {
            return gxTv_SdtTicket_Ticketmotivodescripcion ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTicket_Ticketmotivodescripcion = value;
            SetDirty("Ticketmotivodescripcion");
         }

      }

      [  SoapElement( ElementName = "TicketEstado" )]
      [  XmlElement( ElementName = "TicketEstado"   )]
      public bool gxTpr_Ticketestado
      {
         get {
            return gxTv_SdtTicket_Ticketestado ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTicket_Ticketestado = value;
            SetDirty("Ticketestado");
         }

      }

      [  SoapElement( ElementName = "TicketComentario" )]
      [  XmlElement( ElementName = "TicketComentario"   )]
      public string gxTpr_Ticketcomentario
      {
         get {
            return gxTv_SdtTicket_Ticketcomentario ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTicket_Ticketcomentario = value;
            SetDirty("Ticketcomentario");
         }

      }

      [  SoapElement( ElementName = "TicketAdjunto" )]
      [  XmlElement( ElementName = "TicketAdjunto"   )]
      public string gxTpr_Ticketadjunto
      {
         get {
            return gxTv_SdtTicket_Ticketadjunto ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTicket_Ticketadjunto = value;
            SetDirty("Ticketadjunto");
         }

      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtTicket_Mode ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTicket_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtTicket_Mode_SetNull( )
      {
         gxTv_SdtTicket_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtTicket_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtTicket_Initialized ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTicket_Initialized = value;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtTicket_Initialized_SetNull( )
      {
         gxTv_SdtTicket_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtTicket_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TicketId_Z" )]
      [  XmlElement( ElementName = "TicketId_Z"   )]
      public long gxTpr_Ticketid_Z
      {
         get {
            return gxTv_SdtTicket_Ticketid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTicket_Ticketid_Z = value;
            SetDirty("Ticketid_Z");
         }

      }

      public void gxTv_SdtTicket_Ticketid_Z_SetNull( )
      {
         gxTv_SdtTicket_Ticketid_Z = 0;
         SetDirty("Ticketid_Z");
         return  ;
      }

      public bool gxTv_SdtTicket_Ticketid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TicketSolicitudId_Z" )]
      [  XmlElement( ElementName = "TicketSolicitudId_Z"   )]
      public long gxTpr_Ticketsolicitudid_Z
      {
         get {
            return gxTv_SdtTicket_Ticketsolicitudid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTicket_Ticketsolicitudid_Z = value;
            SetDirty("Ticketsolicitudid_Z");
         }

      }

      public void gxTv_SdtTicket_Ticketsolicitudid_Z_SetNull( )
      {
         gxTv_SdtTicket_Ticketsolicitudid_Z = 0;
         SetDirty("Ticketsolicitudid_Z");
         return  ;
      }

      public bool gxTv_SdtTicket_Ticketsolicitudid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TicketMotivoId_Z" )]
      [  XmlElement( ElementName = "TicketMotivoId_Z"   )]
      public long gxTpr_Ticketmotivoid_Z
      {
         get {
            return gxTv_SdtTicket_Ticketmotivoid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTicket_Ticketmotivoid_Z = value;
            SetDirty("Ticketmotivoid_Z");
         }

      }

      public void gxTv_SdtTicket_Ticketmotivoid_Z_SetNull( )
      {
         gxTv_SdtTicket_Ticketmotivoid_Z = 0;
         SetDirty("Ticketmotivoid_Z");
         return  ;
      }

      public bool gxTv_SdtTicket_Ticketmotivoid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TicketMotivoDescripcion_Z" )]
      [  XmlElement( ElementName = "TicketMotivoDescripcion_Z"   )]
      public string gxTpr_Ticketmotivodescripcion_Z
      {
         get {
            return gxTv_SdtTicket_Ticketmotivodescripcion_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTicket_Ticketmotivodescripcion_Z = value;
            SetDirty("Ticketmotivodescripcion_Z");
         }

      }

      public void gxTv_SdtTicket_Ticketmotivodescripcion_Z_SetNull( )
      {
         gxTv_SdtTicket_Ticketmotivodescripcion_Z = "";
         SetDirty("Ticketmotivodescripcion_Z");
         return  ;
      }

      public bool gxTv_SdtTicket_Ticketmotivodescripcion_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TicketEstado_Z" )]
      [  XmlElement( ElementName = "TicketEstado_Z"   )]
      public bool gxTpr_Ticketestado_Z
      {
         get {
            return gxTv_SdtTicket_Ticketestado_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTicket_Ticketestado_Z = value;
            SetDirty("Ticketestado_Z");
         }

      }

      public void gxTv_SdtTicket_Ticketestado_Z_SetNull( )
      {
         gxTv_SdtTicket_Ticketestado_Z = false;
         SetDirty("Ticketestado_Z");
         return  ;
      }

      public bool gxTv_SdtTicket_Ticketestado_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TicketComentario_Z" )]
      [  XmlElement( ElementName = "TicketComentario_Z"   )]
      public string gxTpr_Ticketcomentario_Z
      {
         get {
            return gxTv_SdtTicket_Ticketcomentario_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTicket_Ticketcomentario_Z = value;
            SetDirty("Ticketcomentario_Z");
         }

      }

      public void gxTv_SdtTicket_Ticketcomentario_Z_SetNull( )
      {
         gxTv_SdtTicket_Ticketcomentario_Z = "";
         SetDirty("Ticketcomentario_Z");
         return  ;
      }

      public bool gxTv_SdtTicket_Ticketcomentario_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TicketAdjunto_Z" )]
      [  XmlElement( ElementName = "TicketAdjunto_Z"   )]
      public string gxTpr_Ticketadjunto_Z
      {
         get {
            return gxTv_SdtTicket_Ticketadjunto_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTicket_Ticketadjunto_Z = value;
            SetDirty("Ticketadjunto_Z");
         }

      }

      public void gxTv_SdtTicket_Ticketadjunto_Z_SetNull( )
      {
         gxTv_SdtTicket_Ticketadjunto_Z = "";
         SetDirty("Ticketadjunto_Z");
         return  ;
      }

      public bool gxTv_SdtTicket_Ticketadjunto_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TicketId_N" )]
      [  XmlElement( ElementName = "TicketId_N"   )]
      public short gxTpr_Ticketid_N
      {
         get {
            return gxTv_SdtTicket_Ticketid_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTicket_Ticketid_N = value;
            SetDirty("Ticketid_N");
         }

      }

      public void gxTv_SdtTicket_Ticketid_N_SetNull( )
      {
         gxTv_SdtTicket_Ticketid_N = 0;
         SetDirty("Ticketid_N");
         return  ;
      }

      public bool gxTv_SdtTicket_Ticketid_N_IsNull( )
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
         gxTv_SdtTicket_Ticketmotivodescripcion = "";
         gxTv_SdtTicket_Ticketcomentario = "";
         gxTv_SdtTicket_Ticketadjunto = "";
         gxTv_SdtTicket_Mode = "";
         gxTv_SdtTicket_Ticketmotivodescripcion_Z = "";
         gxTv_SdtTicket_Ticketcomentario_Z = "";
         gxTv_SdtTicket_Ticketadjunto_Z = "";
         IGxSilentTrn obj;
         obj = (IGxSilentTrn)ClassLoader.FindInstance( "ticket", "GeneXus.Programs.ticket_bc", new Object[] {context}, constructorCallingAssembly);;
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
      private short gxTv_SdtTicket_Initialized ;
      private short gxTv_SdtTicket_Ticketid_N ;
      private long gxTv_SdtTicket_Ticketid ;
      private long gxTv_SdtTicket_Ticketsolicitudid ;
      private long gxTv_SdtTicket_Ticketmotivoid ;
      private long gxTv_SdtTicket_Ticketid_Z ;
      private long gxTv_SdtTicket_Ticketsolicitudid_Z ;
      private long gxTv_SdtTicket_Ticketmotivoid_Z ;
      private string gxTv_SdtTicket_Ticketmotivodescripcion ;
      private string gxTv_SdtTicket_Ticketcomentario ;
      private string gxTv_SdtTicket_Ticketadjunto ;
      private string gxTv_SdtTicket_Mode ;
      private string gxTv_SdtTicket_Ticketmotivodescripcion_Z ;
      private string gxTv_SdtTicket_Ticketcomentario_Z ;
      private string gxTv_SdtTicket_Ticketadjunto_Z ;
      private bool gxTv_SdtTicket_Ticketestado ;
      private bool gxTv_SdtTicket_Ticketestado_Z ;
   }

   [DataContract(Name = @"Ticket", Namespace = "AlmangoX")]
   [GxJsonSerialization("default")]
   public class SdtTicket_RESTInterface : GxGenericCollectionItem<SdtTicket>, System.Web.SessionState.IRequiresSessionState
   {
      public SdtTicket_RESTInterface( ) : base()
      {
      }

      public SdtTicket_RESTInterface( SdtTicket psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "TicketId" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Ticketid
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Ticketid), 18, 0)) ;
         }

         set {
            sdt.gxTpr_Ticketid = (long)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
         }

      }

      [DataMember( Name = "TicketSolicitudId" , Order = 1 )]
      [GxSeudo()]
      public string gxTpr_Ticketsolicitudid
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Ticketsolicitudid), 18, 0)) ;
         }

         set {
            sdt.gxTpr_Ticketsolicitudid = (long)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
         }

      }

      [DataMember( Name = "TicketMotivoId" , Order = 2 )]
      [GxSeudo()]
      public string gxTpr_Ticketmotivoid
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Ticketmotivoid), 18, 0)) ;
         }

         set {
            sdt.gxTpr_Ticketmotivoid = (long)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
         }

      }

      [DataMember( Name = "TicketMotivoDescripcion" , Order = 3 )]
      [GxSeudo()]
      public string gxTpr_Ticketmotivodescripcion
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Ticketmotivodescripcion) ;
         }

         set {
            sdt.gxTpr_Ticketmotivodescripcion = value;
         }

      }

      [DataMember( Name = "TicketEstado" , Order = 4 )]
      [GxSeudo()]
      public bool gxTpr_Ticketestado
      {
         get {
            return sdt.gxTpr_Ticketestado ;
         }

         set {
            sdt.gxTpr_Ticketestado = value;
         }

      }

      [DataMember( Name = "TicketComentario" , Order = 5 )]
      [GxSeudo()]
      public string gxTpr_Ticketcomentario
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Ticketcomentario) ;
         }

         set {
            sdt.gxTpr_Ticketcomentario = value;
         }

      }

      [DataMember( Name = "TicketAdjunto" , Order = 6 )]
      [GxSeudo()]
      public string gxTpr_Ticketadjunto
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Ticketadjunto) ;
         }

         set {
            sdt.gxTpr_Ticketadjunto = value;
         }

      }

      public SdtTicket sdt
      {
         get {
            return (SdtTicket)Sdt ;
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
            sdt = new SdtTicket() ;
         }
      }

      [DataMember( Name = "gx_md5_hash" , Order = 7 )]
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

   [DataContract(Name = @"Ticket", Namespace = "AlmangoX")]
   [GxJsonSerialization("default")]
   public class SdtTicket_RESTLInterface : GxGenericCollectionItem<SdtTicket>, System.Web.SessionState.IRequiresSessionState
   {
      public SdtTicket_RESTLInterface( ) : base()
      {
      }

      public SdtTicket_RESTLInterface( SdtTicket psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "TicketSolicitudId" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Ticketsolicitudid
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Ticketsolicitudid), 18, 0)) ;
         }

         set {
            sdt.gxTpr_Ticketsolicitudid = (long)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
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

      public SdtTicket sdt
      {
         get {
            return (SdtTicket)Sdt ;
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
            sdt = new SdtTicket() ;
         }
      }

   }

}

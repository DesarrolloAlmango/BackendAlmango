/*
				   File: type_SdtSDTMasDatos_ItemTurno
			Description: TurnosInstalacion
				 Author: Nemo 🐠 for C# version 18.0.15.188745
		   Program type: Callable routine
			  Main DBMS: 
*/
using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using GeneXus.Http.Server;
using System.Reflection;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Web.Services.Protocols;


namespace GeneXus.Programs
{
	[XmlSerializerFormat]
	[XmlRoot(ElementName="SDTMasDatos.ItemTurno")]
	[XmlType(TypeName="SDTMasDatos.ItemTurno" , Namespace="AlmangoX" )]
	[Serializable]
	public class SdtSDTMasDatos_ItemTurno : GxUserType
	{
		public SdtSDTMasDatos_ItemTurno( )
		{
			/* Constructor for serialization */
			gxTv_SdtSDTMasDatos_ItemTurno_Turnosinstalaciondetalle = "";

		}

		public SdtSDTMasDatos_ItemTurno(IGxContext context)
		{
			this.context = context;	
			initialize();
		}

		#region Json
		private static Hashtable mapper;
		public override string JsonMap(string value)
		{
			if (mapper == null)
			{
				mapper = new Hashtable();
			}
			return (string)mapper[value]; ;
		}

		public override void ToJSON()
		{
			ToJSON(true) ;
			return;
		}

		public override void ToJSON(bool includeState)
		{
			AddObjectProperty("TurnosInstalacionId", StringUtil.LTrim( StringUtil.Str( (decimal)gxTpr_Turnosinstalacionid, 18, 0)), false);


			AddObjectProperty("TurnosInstalacionDetalle", gxTpr_Turnosinstalaciondetalle, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="TurnosInstalacionId")]
		[XmlElement(ElementName="TurnosInstalacionId")]
		public long gxTpr_Turnosinstalacionid
		{
			get {
				return gxTv_SdtSDTMasDatos_ItemTurno_Turnosinstalacionid; 
			}
			set {
				gxTv_SdtSDTMasDatos_ItemTurno_Turnosinstalacionid = value;
				SetDirty("Turnosinstalacionid");
			}
		}




		[SoapElement(ElementName="TurnosInstalacionDetalle")]
		[XmlElement(ElementName="TurnosInstalacionDetalle")]
		public string gxTpr_Turnosinstalaciondetalle
		{
			get {
				return gxTv_SdtSDTMasDatos_ItemTurno_Turnosinstalaciondetalle; 
			}
			set {
				gxTv_SdtSDTMasDatos_ItemTurno_Turnosinstalaciondetalle = value;
				SetDirty("Turnosinstalaciondetalle");
			}
		}



		public override bool ShouldSerializeSdtJson()
		{
			return true;
		}



		#endregion

		#region Static Type Properties

		[SoapIgnore]
		[XmlIgnore]
		private static GXTypeInfo _typeProps;
		protected override GXTypeInfo TypeInfo { get { return _typeProps; } set { _typeProps = value; } }

		#endregion

		#region Initialization

		public void initialize( )
		{
			gxTv_SdtSDTMasDatos_ItemTurno_Turnosinstalaciondetalle = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected long gxTv_SdtSDTMasDatos_ItemTurno_Turnosinstalacionid;
		 

		protected string gxTv_SdtSDTMasDatos_ItemTurno_Turnosinstalaciondetalle;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("wrapped")]
	[DataContract(Name=@"SDTMasDatos.ItemTurno", Namespace="AlmangoX")]
	public class SdtSDTMasDatos_ItemTurno_RESTInterface : GxGenericCollectionItem<SdtSDTMasDatos_ItemTurno>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSDTMasDatos_ItemTurno_RESTInterface( ) : base()
		{	
		}

		public SdtSDTMasDatos_ItemTurno_RESTInterface( SdtSDTMasDatos_ItemTurno psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="TurnosInstalacionId", Order=0)]
		public  string gxTpr_Turnosinstalacionid
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Turnosinstalacionid, 18, 0));

			}
			set { 
				sdt.gxTpr_Turnosinstalacionid = (long) NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="TurnosInstalacionDetalle", Order=1)]
		public  string gxTpr_Turnosinstalaciondetalle
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Turnosinstalaciondetalle);

			}
			set { 
				 sdt.gxTpr_Turnosinstalaciondetalle = value;
			}
		}


		#endregion
		public SdtSDTMasDatos_ItemTurno sdt
		{
			get { 
				return (SdtSDTMasDatos_ItemTurno)Sdt;
			}
			set {
				Sdt = value;
			}
		}

		[OnDeserializing]
		void checkSdt( StreamingContext ctx )
		{
			if ( sdt == null )
			{
				sdt = new SdtSDTMasDatos_ItemTurno() ;
			}
		}
	}
	#endregion
}
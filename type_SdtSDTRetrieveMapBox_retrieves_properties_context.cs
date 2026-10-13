/*
				   File: type_SdtSDTRetrieveMapBox_retrieves_properties_context
			Description: context
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
	[XmlRoot(ElementName="SDTRetrieveMapBox.retrieves.properties.context")]
	[XmlType(TypeName="SDTRetrieveMapBox.retrieves.properties.context" , Namespace="AlmangoX" )]
	[Serializable]
	public class SdtSDTRetrieveMapBox_retrieves_properties_context : GxUserType
	{
		public SdtSDTRetrieveMapBox_retrieves_properties_context( )
		{
			/* Constructor for serialization */
		}

		public SdtSDTRetrieveMapBox_retrieves_properties_context(IGxContext context)
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
			if (gxTv_SdtSDTRetrieveMapBox_retrieves_properties_context_Address != null)
			{
				AddObjectProperty("address", gxTv_SdtSDTRetrieveMapBox_retrieves_properties_context_Address, false);
			}
			if (gxTv_SdtSDTRetrieveMapBox_retrieves_properties_context_Place != null)
			{
				AddObjectProperty("place", gxTv_SdtSDTRetrieveMapBox_retrieves_properties_context_Place, false);
			}
			if (gxTv_SdtSDTRetrieveMapBox_retrieves_properties_context_District != null)
			{
				AddObjectProperty("district", gxTv_SdtSDTRetrieveMapBox_retrieves_properties_context_District, false);
			}
			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="address" )]
		[XmlElement(ElementName="address" )]
		public SdtSDTRetrieveMapBox_retrieves_properties_context_address gxTpr_Address
		{
			get {
				if ( gxTv_SdtSDTRetrieveMapBox_retrieves_properties_context_Address == null )
				{
					gxTv_SdtSDTRetrieveMapBox_retrieves_properties_context_Address = new SdtSDTRetrieveMapBox_retrieves_properties_context_address(context);
				}
				gxTv_SdtSDTRetrieveMapBox_retrieves_properties_context_Address_N = false;
				SetDirty("Address");
				return gxTv_SdtSDTRetrieveMapBox_retrieves_properties_context_Address;
			}
			set {
				gxTv_SdtSDTRetrieveMapBox_retrieves_properties_context_Address_N = false;
				gxTv_SdtSDTRetrieveMapBox_retrieves_properties_context_Address = value;
				SetDirty("Address");
			}

		}

		public void gxTv_SdtSDTRetrieveMapBox_retrieves_properties_context_Address_SetNull()
		{
			gxTv_SdtSDTRetrieveMapBox_retrieves_properties_context_Address_N = true;
			gxTv_SdtSDTRetrieveMapBox_retrieves_properties_context_Address = null;
		}

		public bool gxTv_SdtSDTRetrieveMapBox_retrieves_properties_context_Address_IsNull()
		{
			return gxTv_SdtSDTRetrieveMapBox_retrieves_properties_context_Address == null;
		}
		public bool ShouldSerializegxTpr_Address_Json()
		{
				return (gxTv_SdtSDTRetrieveMapBox_retrieves_properties_context_Address != null && gxTv_SdtSDTRetrieveMapBox_retrieves_properties_context_Address.ShouldSerializeSdtJson());

		}


		[SoapElement(ElementName="place" )]
		[XmlElement(ElementName="place" )]
		public SdtSDTRetrieveMapBox_retrieves_properties_context_place gxTpr_Place
		{
			get {
				if ( gxTv_SdtSDTRetrieveMapBox_retrieves_properties_context_Place == null )
				{
					gxTv_SdtSDTRetrieveMapBox_retrieves_properties_context_Place = new SdtSDTRetrieveMapBox_retrieves_properties_context_place(context);
				}
				gxTv_SdtSDTRetrieveMapBox_retrieves_properties_context_Place_N = false;
				SetDirty("Place");
				return gxTv_SdtSDTRetrieveMapBox_retrieves_properties_context_Place;
			}
			set {
				gxTv_SdtSDTRetrieveMapBox_retrieves_properties_context_Place_N = false;
				gxTv_SdtSDTRetrieveMapBox_retrieves_properties_context_Place = value;
				SetDirty("Place");
			}

		}

		public void gxTv_SdtSDTRetrieveMapBox_retrieves_properties_context_Place_SetNull()
		{
			gxTv_SdtSDTRetrieveMapBox_retrieves_properties_context_Place_N = true;
			gxTv_SdtSDTRetrieveMapBox_retrieves_properties_context_Place = null;
		}

		public bool gxTv_SdtSDTRetrieveMapBox_retrieves_properties_context_Place_IsNull()
		{
			return gxTv_SdtSDTRetrieveMapBox_retrieves_properties_context_Place == null;
		}
		public bool ShouldSerializegxTpr_Place_Json()
		{
				return (gxTv_SdtSDTRetrieveMapBox_retrieves_properties_context_Place != null && gxTv_SdtSDTRetrieveMapBox_retrieves_properties_context_Place.ShouldSerializeSdtJson());

		}


		[SoapElement(ElementName="district" )]
		[XmlElement(ElementName="district" )]
		public SdtSDTRetrieveMapBox_retrieves_properties_context_district gxTpr_District
		{
			get {
				if ( gxTv_SdtSDTRetrieveMapBox_retrieves_properties_context_District == null )
				{
					gxTv_SdtSDTRetrieveMapBox_retrieves_properties_context_District = new SdtSDTRetrieveMapBox_retrieves_properties_context_district(context);
				}
				gxTv_SdtSDTRetrieveMapBox_retrieves_properties_context_District_N = false;
				SetDirty("District");
				return gxTv_SdtSDTRetrieveMapBox_retrieves_properties_context_District;
			}
			set {
				gxTv_SdtSDTRetrieveMapBox_retrieves_properties_context_District_N = false;
				gxTv_SdtSDTRetrieveMapBox_retrieves_properties_context_District = value;
				SetDirty("District");
			}

		}

		public void gxTv_SdtSDTRetrieveMapBox_retrieves_properties_context_District_SetNull()
		{
			gxTv_SdtSDTRetrieveMapBox_retrieves_properties_context_District_N = true;
			gxTv_SdtSDTRetrieveMapBox_retrieves_properties_context_District = null;
		}

		public bool gxTv_SdtSDTRetrieveMapBox_retrieves_properties_context_District_IsNull()
		{
			return gxTv_SdtSDTRetrieveMapBox_retrieves_properties_context_District == null;
		}
		public bool ShouldSerializegxTpr_District_Json()
		{
				return (gxTv_SdtSDTRetrieveMapBox_retrieves_properties_context_District != null && gxTv_SdtSDTRetrieveMapBox_retrieves_properties_context_District.ShouldSerializeSdtJson());

		}


		public override bool ShouldSerializeSdtJson()
		{
			return (
				ShouldSerializegxTpr_Address_Json() ||
				ShouldSerializegxTpr_Place_Json() ||
				ShouldSerializegxTpr_District_Json() || 
				false);
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
			gxTv_SdtSDTRetrieveMapBox_retrieves_properties_context_Address_N = true;


			gxTv_SdtSDTRetrieveMapBox_retrieves_properties_context_Place_N = true;


			gxTv_SdtSDTRetrieveMapBox_retrieves_properties_context_District_N = true;

			return  ;
		}



		#endregion

		#region Declaration

		protected bool gxTv_SdtSDTRetrieveMapBox_retrieves_properties_context_Address_N;
		protected SdtSDTRetrieveMapBox_retrieves_properties_context_address gxTv_SdtSDTRetrieveMapBox_retrieves_properties_context_Address = null; 

		protected bool gxTv_SdtSDTRetrieveMapBox_retrieves_properties_context_Place_N;
		protected SdtSDTRetrieveMapBox_retrieves_properties_context_place gxTv_SdtSDTRetrieveMapBox_retrieves_properties_context_Place = null; 

		protected bool gxTv_SdtSDTRetrieveMapBox_retrieves_properties_context_District_N;
		protected SdtSDTRetrieveMapBox_retrieves_properties_context_district gxTv_SdtSDTRetrieveMapBox_retrieves_properties_context_District = null; 



		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"SDTRetrieveMapBox.retrieves.properties.context", Namespace="AlmangoX")]
	public class SdtSDTRetrieveMapBox_retrieves_properties_context_RESTInterface : GxGenericCollectionItem<SdtSDTRetrieveMapBox_retrieves_properties_context>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSDTRetrieveMapBox_retrieves_properties_context_RESTInterface( ) : base()
		{	
		}

		public SdtSDTRetrieveMapBox_retrieves_properties_context_RESTInterface( SdtSDTRetrieveMapBox_retrieves_properties_context psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="address", Order=0, EmitDefaultValue=false)]
		public SdtSDTRetrieveMapBox_retrieves_properties_context_address_RESTInterface gxTpr_Address
		{
			get {
				if (sdt.ShouldSerializegxTpr_Address_Json())
					return new SdtSDTRetrieveMapBox_retrieves_properties_context_address_RESTInterface(sdt.gxTpr_Address);
				else
					return null;

			}

			set {
				sdt.gxTpr_Address = value.sdt;
			}

		}

		[DataMember(Name="place", Order=1, EmitDefaultValue=false)]
		public SdtSDTRetrieveMapBox_retrieves_properties_context_place_RESTInterface gxTpr_Place
		{
			get {
				if (sdt.ShouldSerializegxTpr_Place_Json())
					return new SdtSDTRetrieveMapBox_retrieves_properties_context_place_RESTInterface(sdt.gxTpr_Place);
				else
					return null;

			}

			set {
				sdt.gxTpr_Place = value.sdt;
			}

		}

		[DataMember(Name="district", Order=2, EmitDefaultValue=false)]
		public SdtSDTRetrieveMapBox_retrieves_properties_context_district_RESTInterface gxTpr_District
		{
			get {
				if (sdt.ShouldSerializegxTpr_District_Json())
					return new SdtSDTRetrieveMapBox_retrieves_properties_context_district_RESTInterface(sdt.gxTpr_District);
				else
					return null;

			}

			set {
				sdt.gxTpr_District = value.sdt;
			}

		}


		#endregion
		public SdtSDTRetrieveMapBox_retrieves_properties_context sdt
		{
			get { 
				return (SdtSDTRetrieveMapBox_retrieves_properties_context)Sdt;
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
				sdt = new SdtSDTRetrieveMapBox_retrieves_properties_context() ;
			}
		}
	}
	#endregion
}
/*
				   File: type_SdtSDTSuggestMapBox_suggestions_context
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
	[XmlRoot(ElementName="SDTSuggestMapBox.suggestions.context")]
	[XmlType(TypeName="SDTSuggestMapBox.suggestions.context" , Namespace="AlmangoX" )]
	[Serializable]
	public class SdtSDTSuggestMapBox_suggestions_context : GxUserType
	{
		public SdtSDTSuggestMapBox_suggestions_context( )
		{
			/* Constructor for serialization */
		}

		public SdtSDTSuggestMapBox_suggestions_context(IGxContext context)
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
			if (gxTv_SdtSDTSuggestMapBox_suggestions_context_Country != null)
			{
				AddObjectProperty("country", gxTv_SdtSDTSuggestMapBox_suggestions_context_Country, false);
			}
			if (gxTv_SdtSDTSuggestMapBox_suggestions_context_Region != null)
			{
				AddObjectProperty("region", gxTv_SdtSDTSuggestMapBox_suggestions_context_Region, false);
			}
			if (gxTv_SdtSDTSuggestMapBox_suggestions_context_Postcode != null)
			{
				AddObjectProperty("postcode", gxTv_SdtSDTSuggestMapBox_suggestions_context_Postcode, false);
			}
			if (gxTv_SdtSDTSuggestMapBox_suggestions_context_Place != null)
			{
				AddObjectProperty("place", gxTv_SdtSDTSuggestMapBox_suggestions_context_Place, false);
			}
			if (gxTv_SdtSDTSuggestMapBox_suggestions_context_Address != null)
			{
				AddObjectProperty("address", gxTv_SdtSDTSuggestMapBox_suggestions_context_Address, false);
			}
			if (gxTv_SdtSDTSuggestMapBox_suggestions_context_Street != null)
			{
				AddObjectProperty("street", gxTv_SdtSDTSuggestMapBox_suggestions_context_Street, false);
			}
			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="country" )]
		[XmlElement(ElementName="country" )]
		public SdtSDTSuggestMapBox_suggestions_context_country gxTpr_Country
		{
			get {
				if ( gxTv_SdtSDTSuggestMapBox_suggestions_context_Country == null )
				{
					gxTv_SdtSDTSuggestMapBox_suggestions_context_Country = new SdtSDTSuggestMapBox_suggestions_context_country(context);
				}
				gxTv_SdtSDTSuggestMapBox_suggestions_context_Country_N = false;
				SetDirty("Country");
				return gxTv_SdtSDTSuggestMapBox_suggestions_context_Country;
			}
			set {
				gxTv_SdtSDTSuggestMapBox_suggestions_context_Country_N = false;
				gxTv_SdtSDTSuggestMapBox_suggestions_context_Country = value;
				SetDirty("Country");
			}

		}

		public void gxTv_SdtSDTSuggestMapBox_suggestions_context_Country_SetNull()
		{
			gxTv_SdtSDTSuggestMapBox_suggestions_context_Country_N = true;
			gxTv_SdtSDTSuggestMapBox_suggestions_context_Country = null;
		}

		public bool gxTv_SdtSDTSuggestMapBox_suggestions_context_Country_IsNull()
		{
			return gxTv_SdtSDTSuggestMapBox_suggestions_context_Country == null;
		}
		public bool ShouldSerializegxTpr_Country_Json()
		{
				return (gxTv_SdtSDTSuggestMapBox_suggestions_context_Country != null && gxTv_SdtSDTSuggestMapBox_suggestions_context_Country.ShouldSerializeSdtJson());

		}


		[SoapElement(ElementName="region" )]
		[XmlElement(ElementName="region" )]
		public SdtSDTSuggestMapBox_suggestions_context_region gxTpr_Region
		{
			get {
				if ( gxTv_SdtSDTSuggestMapBox_suggestions_context_Region == null )
				{
					gxTv_SdtSDTSuggestMapBox_suggestions_context_Region = new SdtSDTSuggestMapBox_suggestions_context_region(context);
				}
				gxTv_SdtSDTSuggestMapBox_suggestions_context_Region_N = false;
				SetDirty("Region");
				return gxTv_SdtSDTSuggestMapBox_suggestions_context_Region;
			}
			set {
				gxTv_SdtSDTSuggestMapBox_suggestions_context_Region_N = false;
				gxTv_SdtSDTSuggestMapBox_suggestions_context_Region = value;
				SetDirty("Region");
			}

		}

		public void gxTv_SdtSDTSuggestMapBox_suggestions_context_Region_SetNull()
		{
			gxTv_SdtSDTSuggestMapBox_suggestions_context_Region_N = true;
			gxTv_SdtSDTSuggestMapBox_suggestions_context_Region = null;
		}

		public bool gxTv_SdtSDTSuggestMapBox_suggestions_context_Region_IsNull()
		{
			return gxTv_SdtSDTSuggestMapBox_suggestions_context_Region == null;
		}
		public bool ShouldSerializegxTpr_Region_Json()
		{
				return (gxTv_SdtSDTSuggestMapBox_suggestions_context_Region != null && gxTv_SdtSDTSuggestMapBox_suggestions_context_Region.ShouldSerializeSdtJson());

		}


		[SoapElement(ElementName="postcode" )]
		[XmlElement(ElementName="postcode" )]
		public SdtSDTSuggestMapBox_suggestions_context_postcode gxTpr_Postcode
		{
			get {
				if ( gxTv_SdtSDTSuggestMapBox_suggestions_context_Postcode == null )
				{
					gxTv_SdtSDTSuggestMapBox_suggestions_context_Postcode = new SdtSDTSuggestMapBox_suggestions_context_postcode(context);
				}
				gxTv_SdtSDTSuggestMapBox_suggestions_context_Postcode_N = false;
				SetDirty("Postcode");
				return gxTv_SdtSDTSuggestMapBox_suggestions_context_Postcode;
			}
			set {
				gxTv_SdtSDTSuggestMapBox_suggestions_context_Postcode_N = false;
				gxTv_SdtSDTSuggestMapBox_suggestions_context_Postcode = value;
				SetDirty("Postcode");
			}

		}

		public void gxTv_SdtSDTSuggestMapBox_suggestions_context_Postcode_SetNull()
		{
			gxTv_SdtSDTSuggestMapBox_suggestions_context_Postcode_N = true;
			gxTv_SdtSDTSuggestMapBox_suggestions_context_Postcode = null;
		}

		public bool gxTv_SdtSDTSuggestMapBox_suggestions_context_Postcode_IsNull()
		{
			return gxTv_SdtSDTSuggestMapBox_suggestions_context_Postcode == null;
		}
		public bool ShouldSerializegxTpr_Postcode_Json()
		{
				return (gxTv_SdtSDTSuggestMapBox_suggestions_context_Postcode != null && gxTv_SdtSDTSuggestMapBox_suggestions_context_Postcode.ShouldSerializeSdtJson());

		}


		[SoapElement(ElementName="place" )]
		[XmlElement(ElementName="place" )]
		public SdtSDTSuggestMapBox_suggestions_context_place gxTpr_Place
		{
			get {
				if ( gxTv_SdtSDTSuggestMapBox_suggestions_context_Place == null )
				{
					gxTv_SdtSDTSuggestMapBox_suggestions_context_Place = new SdtSDTSuggestMapBox_suggestions_context_place(context);
				}
				gxTv_SdtSDTSuggestMapBox_suggestions_context_Place_N = false;
				SetDirty("Place");
				return gxTv_SdtSDTSuggestMapBox_suggestions_context_Place;
			}
			set {
				gxTv_SdtSDTSuggestMapBox_suggestions_context_Place_N = false;
				gxTv_SdtSDTSuggestMapBox_suggestions_context_Place = value;
				SetDirty("Place");
			}

		}

		public void gxTv_SdtSDTSuggestMapBox_suggestions_context_Place_SetNull()
		{
			gxTv_SdtSDTSuggestMapBox_suggestions_context_Place_N = true;
			gxTv_SdtSDTSuggestMapBox_suggestions_context_Place = null;
		}

		public bool gxTv_SdtSDTSuggestMapBox_suggestions_context_Place_IsNull()
		{
			return gxTv_SdtSDTSuggestMapBox_suggestions_context_Place == null;
		}
		public bool ShouldSerializegxTpr_Place_Json()
		{
				return (gxTv_SdtSDTSuggestMapBox_suggestions_context_Place != null && gxTv_SdtSDTSuggestMapBox_suggestions_context_Place.ShouldSerializeSdtJson());

		}


		[SoapElement(ElementName="address" )]
		[XmlElement(ElementName="address" )]
		public SdtSDTSuggestMapBox_suggestions_context_address gxTpr_Address
		{
			get {
				if ( gxTv_SdtSDTSuggestMapBox_suggestions_context_Address == null )
				{
					gxTv_SdtSDTSuggestMapBox_suggestions_context_Address = new SdtSDTSuggestMapBox_suggestions_context_address(context);
				}
				gxTv_SdtSDTSuggestMapBox_suggestions_context_Address_N = false;
				SetDirty("Address");
				return gxTv_SdtSDTSuggestMapBox_suggestions_context_Address;
			}
			set {
				gxTv_SdtSDTSuggestMapBox_suggestions_context_Address_N = false;
				gxTv_SdtSDTSuggestMapBox_suggestions_context_Address = value;
				SetDirty("Address");
			}

		}

		public void gxTv_SdtSDTSuggestMapBox_suggestions_context_Address_SetNull()
		{
			gxTv_SdtSDTSuggestMapBox_suggestions_context_Address_N = true;
			gxTv_SdtSDTSuggestMapBox_suggestions_context_Address = null;
		}

		public bool gxTv_SdtSDTSuggestMapBox_suggestions_context_Address_IsNull()
		{
			return gxTv_SdtSDTSuggestMapBox_suggestions_context_Address == null;
		}
		public bool ShouldSerializegxTpr_Address_Json()
		{
				return (gxTv_SdtSDTSuggestMapBox_suggestions_context_Address != null && gxTv_SdtSDTSuggestMapBox_suggestions_context_Address.ShouldSerializeSdtJson());

		}


		[SoapElement(ElementName="street" )]
		[XmlElement(ElementName="street" )]
		public SdtSDTSuggestMapBox_suggestions_context_street gxTpr_Street
		{
			get {
				if ( gxTv_SdtSDTSuggestMapBox_suggestions_context_Street == null )
				{
					gxTv_SdtSDTSuggestMapBox_suggestions_context_Street = new SdtSDTSuggestMapBox_suggestions_context_street(context);
				}
				gxTv_SdtSDTSuggestMapBox_suggestions_context_Street_N = false;
				SetDirty("Street");
				return gxTv_SdtSDTSuggestMapBox_suggestions_context_Street;
			}
			set {
				gxTv_SdtSDTSuggestMapBox_suggestions_context_Street_N = false;
				gxTv_SdtSDTSuggestMapBox_suggestions_context_Street = value;
				SetDirty("Street");
			}

		}

		public void gxTv_SdtSDTSuggestMapBox_suggestions_context_Street_SetNull()
		{
			gxTv_SdtSDTSuggestMapBox_suggestions_context_Street_N = true;
			gxTv_SdtSDTSuggestMapBox_suggestions_context_Street = null;
		}

		public bool gxTv_SdtSDTSuggestMapBox_suggestions_context_Street_IsNull()
		{
			return gxTv_SdtSDTSuggestMapBox_suggestions_context_Street == null;
		}
		public bool ShouldSerializegxTpr_Street_Json()
		{
				return (gxTv_SdtSDTSuggestMapBox_suggestions_context_Street != null && gxTv_SdtSDTSuggestMapBox_suggestions_context_Street.ShouldSerializeSdtJson());

		}


		public override bool ShouldSerializeSdtJson()
		{
			return (
				ShouldSerializegxTpr_Country_Json() ||
				ShouldSerializegxTpr_Region_Json() ||
				ShouldSerializegxTpr_Postcode_Json() ||
				ShouldSerializegxTpr_Place_Json() ||
				ShouldSerializegxTpr_Address_Json() ||
				ShouldSerializegxTpr_Street_Json() || 
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
			gxTv_SdtSDTSuggestMapBox_suggestions_context_Country_N = true;


			gxTv_SdtSDTSuggestMapBox_suggestions_context_Region_N = true;


			gxTv_SdtSDTSuggestMapBox_suggestions_context_Postcode_N = true;


			gxTv_SdtSDTSuggestMapBox_suggestions_context_Place_N = true;


			gxTv_SdtSDTSuggestMapBox_suggestions_context_Address_N = true;


			gxTv_SdtSDTSuggestMapBox_suggestions_context_Street_N = true;

			return  ;
		}



		#endregion

		#region Declaration

		protected bool gxTv_SdtSDTSuggestMapBox_suggestions_context_Country_N;
		protected SdtSDTSuggestMapBox_suggestions_context_country gxTv_SdtSDTSuggestMapBox_suggestions_context_Country = null; 

		protected bool gxTv_SdtSDTSuggestMapBox_suggestions_context_Region_N;
		protected SdtSDTSuggestMapBox_suggestions_context_region gxTv_SdtSDTSuggestMapBox_suggestions_context_Region = null; 

		protected bool gxTv_SdtSDTSuggestMapBox_suggestions_context_Postcode_N;
		protected SdtSDTSuggestMapBox_suggestions_context_postcode gxTv_SdtSDTSuggestMapBox_suggestions_context_Postcode = null; 

		protected bool gxTv_SdtSDTSuggestMapBox_suggestions_context_Place_N;
		protected SdtSDTSuggestMapBox_suggestions_context_place gxTv_SdtSDTSuggestMapBox_suggestions_context_Place = null; 

		protected bool gxTv_SdtSDTSuggestMapBox_suggestions_context_Address_N;
		protected SdtSDTSuggestMapBox_suggestions_context_address gxTv_SdtSDTSuggestMapBox_suggestions_context_Address = null; 

		protected bool gxTv_SdtSDTSuggestMapBox_suggestions_context_Street_N;
		protected SdtSDTSuggestMapBox_suggestions_context_street gxTv_SdtSDTSuggestMapBox_suggestions_context_Street = null; 



		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"SDTSuggestMapBox.suggestions.context", Namespace="AlmangoX")]
	public class SdtSDTSuggestMapBox_suggestions_context_RESTInterface : GxGenericCollectionItem<SdtSDTSuggestMapBox_suggestions_context>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSDTSuggestMapBox_suggestions_context_RESTInterface( ) : base()
		{	
		}

		public SdtSDTSuggestMapBox_suggestions_context_RESTInterface( SdtSDTSuggestMapBox_suggestions_context psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="country", Order=0, EmitDefaultValue=false)]
		public SdtSDTSuggestMapBox_suggestions_context_country_RESTInterface gxTpr_Country
		{
			get {
				if (sdt.ShouldSerializegxTpr_Country_Json())
					return new SdtSDTSuggestMapBox_suggestions_context_country_RESTInterface(sdt.gxTpr_Country);
				else
					return null;

			}

			set {
				sdt.gxTpr_Country = value.sdt;
			}

		}

		[DataMember(Name="region", Order=1, EmitDefaultValue=false)]
		public SdtSDTSuggestMapBox_suggestions_context_region_RESTInterface gxTpr_Region
		{
			get {
				if (sdt.ShouldSerializegxTpr_Region_Json())
					return new SdtSDTSuggestMapBox_suggestions_context_region_RESTInterface(sdt.gxTpr_Region);
				else
					return null;

			}

			set {
				sdt.gxTpr_Region = value.sdt;
			}

		}

		[DataMember(Name="postcode", Order=2, EmitDefaultValue=false)]
		public SdtSDTSuggestMapBox_suggestions_context_postcode_RESTInterface gxTpr_Postcode
		{
			get {
				if (sdt.ShouldSerializegxTpr_Postcode_Json())
					return new SdtSDTSuggestMapBox_suggestions_context_postcode_RESTInterface(sdt.gxTpr_Postcode);
				else
					return null;

			}

			set {
				sdt.gxTpr_Postcode = value.sdt;
			}

		}

		[DataMember(Name="place", Order=3, EmitDefaultValue=false)]
		public SdtSDTSuggestMapBox_suggestions_context_place_RESTInterface gxTpr_Place
		{
			get {
				if (sdt.ShouldSerializegxTpr_Place_Json())
					return new SdtSDTSuggestMapBox_suggestions_context_place_RESTInterface(sdt.gxTpr_Place);
				else
					return null;

			}

			set {
				sdt.gxTpr_Place = value.sdt;
			}

		}

		[DataMember(Name="address", Order=4, EmitDefaultValue=false)]
		public SdtSDTSuggestMapBox_suggestions_context_address_RESTInterface gxTpr_Address
		{
			get {
				if (sdt.ShouldSerializegxTpr_Address_Json())
					return new SdtSDTSuggestMapBox_suggestions_context_address_RESTInterface(sdt.gxTpr_Address);
				else
					return null;

			}

			set {
				sdt.gxTpr_Address = value.sdt;
			}

		}

		[DataMember(Name="street", Order=5, EmitDefaultValue=false)]
		public SdtSDTSuggestMapBox_suggestions_context_street_RESTInterface gxTpr_Street
		{
			get {
				if (sdt.ShouldSerializegxTpr_Street_Json())
					return new SdtSDTSuggestMapBox_suggestions_context_street_RESTInterface(sdt.gxTpr_Street);
				else
					return null;

			}

			set {
				sdt.gxTpr_Street = value.sdt;
			}

		}


		#endregion
		public SdtSDTSuggestMapBox_suggestions_context sdt
		{
			get { 
				return (SdtSDTSuggestMapBox_suggestions_context)Sdt;
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
				sdt = new SdtSDTSuggestMapBox_suggestions_context() ;
			}
		}
	}
	#endregion
}
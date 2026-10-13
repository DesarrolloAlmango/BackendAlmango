/*
				   File: type_SdtNivel1SDTCollection
			Description: Nivel1SDTCollection
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
	[XmlRoot(ElementName="Nivel1SDTCollection")]
	[XmlType(TypeName="Nivel1SDTCollection" , Namespace="AlmangoX" )]
	[Serializable]
	public class SdtNivel1SDTCollection : GxUserType
	{
		public SdtNivel1SDTCollection( )
		{
			/* Constructor for serialization */
			gxTv_SdtNivel1SDTCollection_Name = "";

			gxTv_SdtNivel1SDTCollection_Image = "";


		}

		public SdtNivel1SDTCollection(IGxContext context)
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
			AddObjectProperty("id", StringUtil.LTrim( StringUtil.Str( (decimal)gxTpr_Id, 18, 0)), false);


			AddObjectProperty("name", gxTpr_Name, false);


			AddObjectProperty("monedaid", gxTpr_Monedaid, false);


			AddObjectProperty("price", StringUtil.LTrim( StringUtil.Str( (decimal)gxTpr_Price, 18, 2)), false);


			AddObjectProperty("image", gxTpr_Image, false);


			AddObjectProperty("TextosId", StringUtil.LTrim( StringUtil.Str( (decimal)gxTpr_Textosid, 18, 0)), false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="id")]
		[XmlElement(ElementName="id")]
		public long gxTpr_Id
		{
			get {
				return gxTv_SdtNivel1SDTCollection_Id; 
			}
			set {
				gxTv_SdtNivel1SDTCollection_Id = value;
				SetDirty("Id");
			}
		}




		[SoapElement(ElementName="name")]
		[XmlElement(ElementName="name")]
		public string gxTpr_Name
		{
			get {
				return gxTv_SdtNivel1SDTCollection_Name; 
			}
			set {
				gxTv_SdtNivel1SDTCollection_Name = value;
				SetDirty("Name");
			}
		}




		[SoapElement(ElementName="monedaid")]
		[XmlElement(ElementName="monedaid")]
		public short gxTpr_Monedaid
		{
			get {
				return gxTv_SdtNivel1SDTCollection_Monedaid; 
			}
			set {
				gxTv_SdtNivel1SDTCollection_Monedaid = value;
				SetDirty("Monedaid");
			}
		}



		[SoapElement(ElementName="price")]
		[XmlElement(ElementName="price")]
		public string gxTpr_Price_double
		{
			get {
				return Convert.ToString(gxTv_SdtNivel1SDTCollection_Price, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtNivel1SDTCollection_Price = NumberUtil.Val(value);
			}
		}
		[SoapIgnore]
		[XmlIgnore]
		public decimal gxTpr_Price
		{
			get {
				return gxTv_SdtNivel1SDTCollection_Price; 
			}
			set {
				gxTv_SdtNivel1SDTCollection_Price = value;
				SetDirty("Price");
			}
		}




		[SoapElement(ElementName="image")]
		[XmlElement(ElementName="image")]
		public string gxTpr_Image
		{
			get {
				return gxTv_SdtNivel1SDTCollection_Image; 
			}
			set {
				gxTv_SdtNivel1SDTCollection_Image = value;
				SetDirty("Image");
			}
		}




		[SoapElement(ElementName="TextosId")]
		[XmlElement(ElementName="TextosId")]
		public long gxTpr_Textosid
		{
			get {
				return gxTv_SdtNivel1SDTCollection_Textosid; 
			}
			set {
				gxTv_SdtNivel1SDTCollection_Textosid = value;
				SetDirty("Textosid");
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
			gxTv_SdtNivel1SDTCollection_Name = "";


			gxTv_SdtNivel1SDTCollection_Image = "";

			return  ;
		}



		#endregion

		#region Declaration

		protected long gxTv_SdtNivel1SDTCollection_Id;
		 

		protected string gxTv_SdtNivel1SDTCollection_Name;
		 

		protected short gxTv_SdtNivel1SDTCollection_Monedaid;
		 

		protected decimal gxTv_SdtNivel1SDTCollection_Price;
		 

		protected string gxTv_SdtNivel1SDTCollection_Image;
		 

		protected long gxTv_SdtNivel1SDTCollection_Textosid;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"Nivel1SDTCollection", Namespace="AlmangoX")]
	public class SdtNivel1SDTCollection_RESTInterface : GxGenericCollectionItem<SdtNivel1SDTCollection>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtNivel1SDTCollection_RESTInterface( ) : base()
		{	
		}

		public SdtNivel1SDTCollection_RESTInterface( SdtNivel1SDTCollection psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="id", Order=0)]
		public  string gxTpr_Id
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Id, 18, 0));

			}
			set { 
				sdt.gxTpr_Id = (long) NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="name", Order=1)]
		public  string gxTpr_Name
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Name);

			}
			set { 
				 sdt.gxTpr_Name = value;
			}
		}

		[DataMember(Name="monedaid", Order=2)]
		public short gxTpr_Monedaid
		{
			get { 
				return sdt.gxTpr_Monedaid;

			}
			set { 
				sdt.gxTpr_Monedaid = value;
			}
		}

		[DataMember(Name="price", Order=3)]
		public  string gxTpr_Price
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str(  sdt.gxTpr_Price, 18, 2));

			}
			set { 
				sdt.gxTpr_Price =  NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="image", Order=4)]
		public  string gxTpr_Image
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Image);

			}
			set { 
				 sdt.gxTpr_Image = value;
			}
		}

		[DataMember(Name="TextosId", Order=5)]
		public  string gxTpr_Textosid
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Textosid, 18, 0));

			}
			set { 
				sdt.gxTpr_Textosid = (long) NumberUtil.Val( value, ".");
			}
		}


		#endregion
		public SdtNivel1SDTCollection sdt
		{
			get { 
				return (SdtNivel1SDTCollection)Sdt;
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
				sdt = new SdtNivel1SDTCollection() ;
			}
		}
	}
	#endregion
}
/*
				   File: type_SdtSDTRetrieveMapBox_retrieves_geometry
			Description: geometry
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
	[XmlRoot(ElementName="SDTRetrieveMapBox.retrieves.geometry")]
	[XmlType(TypeName="SDTRetrieveMapBox.retrieves.geometry" , Namespace="AlmangoX" )]
	[Serializable]
	public class SdtSDTRetrieveMapBox_retrieves_geometry : GxUserType
	{
		public SdtSDTRetrieveMapBox_retrieves_geometry( )
		{
			/* Constructor for serialization */
			gxTv_SdtSDTRetrieveMapBox_retrieves_geometry_Coordinates = "";

			gxTv_SdtSDTRetrieveMapBox_retrieves_geometry_Type = "";

		}

		public SdtSDTRetrieveMapBox_retrieves_geometry(IGxContext context)
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
			AddObjectProperty("coordinates", gxTpr_Coordinates, false);


			AddObjectProperty("type", gxTpr_Type, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="coordinates")]
		[XmlElement(ElementName="coordinates")]
		public string gxTpr_Coordinates
		{
			get {
				return gxTv_SdtSDTRetrieveMapBox_retrieves_geometry_Coordinates; 
			}
			set {
				gxTv_SdtSDTRetrieveMapBox_retrieves_geometry_Coordinates = value;
				SetDirty("Coordinates");
			}
		}




		[SoapElement(ElementName="type")]
		[XmlElement(ElementName="type")]
		public string gxTpr_Type
		{
			get {
				return gxTv_SdtSDTRetrieveMapBox_retrieves_geometry_Type; 
			}
			set {
				gxTv_SdtSDTRetrieveMapBox_retrieves_geometry_Type = value;
				SetDirty("Type");
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
			gxTv_SdtSDTRetrieveMapBox_retrieves_geometry_Coordinates = "";
			gxTv_SdtSDTRetrieveMapBox_retrieves_geometry_Type = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected string gxTv_SdtSDTRetrieveMapBox_retrieves_geometry_Coordinates;
		 

		protected string gxTv_SdtSDTRetrieveMapBox_retrieves_geometry_Type;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"SDTRetrieveMapBox.retrieves.geometry", Namespace="AlmangoX")]
	public class SdtSDTRetrieveMapBox_retrieves_geometry_RESTInterface : GxGenericCollectionItem<SdtSDTRetrieveMapBox_retrieves_geometry>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSDTRetrieveMapBox_retrieves_geometry_RESTInterface( ) : base()
		{	
		}

		public SdtSDTRetrieveMapBox_retrieves_geometry_RESTInterface( SdtSDTRetrieveMapBox_retrieves_geometry psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="coordinates", Order=0)]
		public  string gxTpr_Coordinates
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Coordinates);

			}
			set { 
				 sdt.gxTpr_Coordinates = value;
			}
		}

		[DataMember(Name="type", Order=1)]
		public  string gxTpr_Type
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Type);

			}
			set { 
				 sdt.gxTpr_Type = value;
			}
		}


		#endregion
		public SdtSDTRetrieveMapBox_retrieves_geometry sdt
		{
			get { 
				return (SdtSDTRetrieveMapBox_retrieves_geometry)Sdt;
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
				sdt = new SdtSDTRetrieveMapBox_retrieves_geometry() ;
			}
		}
	}
	#endregion
}
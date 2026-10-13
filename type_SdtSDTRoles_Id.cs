/*
				   File: type_SdtSDTRoles_Id
			Description: Roles
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
	[XmlRoot(ElementName="SDTRoles.Id")]
	[XmlType(TypeName="SDTRoles.Id" , Namespace="AlmangoX" )]
	[Serializable]
	public class SdtSDTRoles_Id : GxUserType
	{
		public SdtSDTRoles_Id( )
		{
			/* Constructor for serialization */
			gxTv_SdtSDTRoles_Id_Secrolename = "";

		}

		public SdtSDTRoles_Id(IGxContext context)
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
			AddObjectProperty("SecRoleId", gxTpr_Secroleid, false);


			AddObjectProperty("SecRoleName", gxTpr_Secrolename, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="SecRoleId")]
		[XmlElement(ElementName="SecRoleId")]
		public short gxTpr_Secroleid
		{
			get {
				return gxTv_SdtSDTRoles_Id_Secroleid; 
			}
			set {
				gxTv_SdtSDTRoles_Id_Secroleid = value;
				SetDirty("Secroleid");
			}
		}




		[SoapElement(ElementName="SecRoleName")]
		[XmlElement(ElementName="SecRoleName")]
		public string gxTpr_Secrolename
		{
			get {
				return gxTv_SdtSDTRoles_Id_Secrolename; 
			}
			set {
				gxTv_SdtSDTRoles_Id_Secrolename = value;
				SetDirty("Secrolename");
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
			gxTv_SdtSDTRoles_Id_Secrolename = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected short gxTv_SdtSDTRoles_Id_Secroleid;
		 

		protected string gxTv_SdtSDTRoles_Id_Secrolename;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("wrapped")]
	[DataContract(Name=@"SDTRoles.Id", Namespace="AlmangoX")]
	public class SdtSDTRoles_Id_RESTInterface : GxGenericCollectionItem<SdtSDTRoles_Id>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSDTRoles_Id_RESTInterface( ) : base()
		{	
		}

		public SdtSDTRoles_Id_RESTInterface( SdtSDTRoles_Id psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="SecRoleId", Order=0)]
		public short gxTpr_Secroleid
		{
			get { 
				return sdt.gxTpr_Secroleid;

			}
			set { 
				sdt.gxTpr_Secroleid = value;
			}
		}

		[DataMember(Name="SecRoleName", Order=1)]
		public  string gxTpr_Secrolename
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Secrolename);

			}
			set { 
				 sdt.gxTpr_Secrolename = value;
			}
		}


		#endregion
		public SdtSDTRoles_Id sdt
		{
			get { 
				return (SdtSDTRoles_Id)Sdt;
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
				sdt = new SdtSDTRoles_Id() ;
			}
		}
	}
	#endregion
}
/*
				   File: type_SdtSDTPostulaciones_ProfesionalesItem
			Description: Profesionales
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
	[XmlRoot(ElementName="SDTPostulaciones.ProfesionalesItem")]
	[XmlType(TypeName="SDTPostulaciones.ProfesionalesItem" , Namespace="AlmangoX" )]
	[Serializable]
	public class SdtSDTPostulaciones_ProfesionalesItem : GxUserType
	{
		public SdtSDTPostulaciones_ProfesionalesItem( )
		{
			/* Constructor for serialization */
			gxTv_SdtSDTPostulaciones_ProfesionalesItem_Profesionalesid = "";

		}

		public SdtSDTPostulaciones_ProfesionalesItem(IGxContext context)
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
			AddObjectProperty("ProfesionalesId", gxTpr_Profesionalesid, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="ProfesionalesId")]
		[XmlElement(ElementName="ProfesionalesId")]
		public string gxTpr_Profesionalesid
		{
			get {
				return gxTv_SdtSDTPostulaciones_ProfesionalesItem_Profesionalesid; 
			}
			set {
				gxTv_SdtSDTPostulaciones_ProfesionalesItem_Profesionalesid = value;
				SetDirty("Profesionalesid");
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
			gxTv_SdtSDTPostulaciones_ProfesionalesItem_Profesionalesid = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected string gxTv_SdtSDTPostulaciones_ProfesionalesItem_Profesionalesid;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("wrapped")]
	[DataContract(Name=@"SDTPostulaciones.ProfesionalesItem", Namespace="AlmangoX")]
	public class SdtSDTPostulaciones_ProfesionalesItem_RESTInterface : GxGenericCollectionItem<SdtSDTPostulaciones_ProfesionalesItem>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSDTPostulaciones_ProfesionalesItem_RESTInterface( ) : base()
		{	
		}

		public SdtSDTPostulaciones_ProfesionalesItem_RESTInterface( SdtSDTPostulaciones_ProfesionalesItem psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="ProfesionalesId", Order=0)]
		public  string gxTpr_Profesionalesid
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Profesionalesid);

			}
			set { 
				 sdt.gxTpr_Profesionalesid = value;
			}
		}


		#endregion
		public SdtSDTPostulaciones_ProfesionalesItem sdt
		{
			get { 
				return (SdtSDTPostulaciones_ProfesionalesItem)Sdt;
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
				sdt = new SdtSDTPostulaciones_ProfesionalesItem() ;
			}
		}
	}
	#endregion
}
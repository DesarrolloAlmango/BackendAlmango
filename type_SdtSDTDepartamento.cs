/*
				   File: type_SdtSDTDepartamento
			Description: SDTDepartamento
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
	[XmlRoot(ElementName="SDTDepartamento")]
	[XmlType(TypeName="SDTDepartamento" , Namespace="AlmangoX" )]
	[Serializable]
	public class SdtSDTDepartamento : GxUserType
	{
		public SdtSDTDepartamento( )
		{
			/* Constructor for serialization */
			gxTv_SdtSDTDepartamento_Paisid = "";

			gxTv_SdtSDTDepartamento_Departamentodepartamento = "";


		}

		public SdtSDTDepartamento(IGxContext context)
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
			AddObjectProperty("DepartamentoId", StringUtil.LTrim( StringUtil.Str( (decimal)gxTpr_Departamentoid, 18, 0)), false);


			AddObjectProperty("PaisID", gxTpr_Paisid, false);


			AddObjectProperty("DepartamentoDepartamento", gxTpr_Departamentodepartamento, false);


			AddObjectProperty("DepartamentoAutEnuMuni", gxTpr_Departamentoautenumuni, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="DepartamentoId")]
		[XmlElement(ElementName="DepartamentoId")]
		public long gxTpr_Departamentoid
		{
			get {
				return gxTv_SdtSDTDepartamento_Departamentoid; 
			}
			set {
				gxTv_SdtSDTDepartamento_Departamentoid = value;
				SetDirty("Departamentoid");
			}
		}




		[SoapElement(ElementName="PaisID")]
		[XmlElement(ElementName="PaisID")]
		public string gxTpr_Paisid
		{
			get {
				return gxTv_SdtSDTDepartamento_Paisid; 
			}
			set {
				gxTv_SdtSDTDepartamento_Paisid = value;
				SetDirty("Paisid");
			}
		}




		[SoapElement(ElementName="DepartamentoDepartamento")]
		[XmlElement(ElementName="DepartamentoDepartamento")]
		public string gxTpr_Departamentodepartamento
		{
			get {
				return gxTv_SdtSDTDepartamento_Departamentodepartamento; 
			}
			set {
				gxTv_SdtSDTDepartamento_Departamentodepartamento = value;
				SetDirty("Departamentodepartamento");
			}
		}




		[SoapElement(ElementName="DepartamentoAutEnuMuni")]
		[XmlElement(ElementName="DepartamentoAutEnuMuni")]
		public short gxTpr_Departamentoautenumuni
		{
			get {
				return gxTv_SdtSDTDepartamento_Departamentoautenumuni; 
			}
			set {
				gxTv_SdtSDTDepartamento_Departamentoautenumuni = value;
				SetDirty("Departamentoautenumuni");
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
			gxTv_SdtSDTDepartamento_Paisid = "";
			gxTv_SdtSDTDepartamento_Departamentodepartamento = "";

			return  ;
		}



		#endregion

		#region Declaration

		protected long gxTv_SdtSDTDepartamento_Departamentoid;
		 

		protected string gxTv_SdtSDTDepartamento_Paisid;
		 

		protected string gxTv_SdtSDTDepartamento_Departamentodepartamento;
		 

		protected short gxTv_SdtSDTDepartamento_Departamentoautenumuni;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"SDTDepartamento", Namespace="AlmangoX")]
	public class SdtSDTDepartamento_RESTInterface : GxGenericCollectionItem<SdtSDTDepartamento>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSDTDepartamento_RESTInterface( ) : base()
		{	
		}

		public SdtSDTDepartamento_RESTInterface( SdtSDTDepartamento psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="DepartamentoId", Order=0)]
		public  string gxTpr_Departamentoid
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Departamentoid, 18, 0));

			}
			set { 
				sdt.gxTpr_Departamentoid = (long) NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="PaisID", Order=1)]
		public  string gxTpr_Paisid
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Paisid);

			}
			set { 
				 sdt.gxTpr_Paisid = value;
			}
		}

		[DataMember(Name="DepartamentoDepartamento", Order=2)]
		public  string gxTpr_Departamentodepartamento
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Departamentodepartamento);

			}
			set { 
				 sdt.gxTpr_Departamentodepartamento = value;
			}
		}

		[DataMember(Name="DepartamentoAutEnuMuni", Order=3)]
		public short gxTpr_Departamentoautenumuni
		{
			get { 
				return sdt.gxTpr_Departamentoautenumuni;

			}
			set { 
				sdt.gxTpr_Departamentoautenumuni = value;
			}
		}


		#endregion
		public SdtSDTDepartamento sdt
		{
			get { 
				return (SdtSDTDepartamento)Sdt;
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
				sdt = new SdtSDTDepartamento() ;
			}
		}
	}
	#endregion
}
/*
				   File: type_SdtSDTMunicipio
			Description: SDTMunicipio
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
	[XmlRoot(ElementName="SDTMunicipio")]
	[XmlType(TypeName="SDTMunicipio" , Namespace="AlmangoX" )]
	[Serializable]
	public class SdtSDTMunicipio : GxUserType
	{
		public SdtSDTMunicipio( )
		{
			/* Constructor for serialization */
			gxTv_SdtSDTMunicipio_Departamentomunicipionombre = "";


		}

		public SdtSDTMunicipio(IGxContext context)
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
			AddObjectProperty("DepartamentoMunicipioId", StringUtil.LTrim( StringUtil.Str( (decimal)gxTpr_Departamentomunicipioid, 18, 0)), false);


			AddObjectProperty("DepartamentoMunicipioNombre", gxTpr_Departamentomunicipionombre, false);


			AddObjectProperty("ZonaCostoAdicional", StringUtil.LTrim( StringUtil.Str( (decimal)gxTpr_Zonacostoadicional, 18, 2)), false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="DepartamentoMunicipioId")]
		[XmlElement(ElementName="DepartamentoMunicipioId")]
		public long gxTpr_Departamentomunicipioid
		{
			get {
				return gxTv_SdtSDTMunicipio_Departamentomunicipioid; 
			}
			set {
				gxTv_SdtSDTMunicipio_Departamentomunicipioid = value;
				SetDirty("Departamentomunicipioid");
			}
		}




		[SoapElement(ElementName="DepartamentoMunicipioNombre")]
		[XmlElement(ElementName="DepartamentoMunicipioNombre")]
		public string gxTpr_Departamentomunicipionombre
		{
			get {
				return gxTv_SdtSDTMunicipio_Departamentomunicipionombre; 
			}
			set {
				gxTv_SdtSDTMunicipio_Departamentomunicipionombre = value;
				SetDirty("Departamentomunicipionombre");
			}
		}



		[SoapElement(ElementName="ZonaCostoAdicional")]
		[XmlElement(ElementName="ZonaCostoAdicional")]
		public string gxTpr_Zonacostoadicional_double
		{
			get {
				return Convert.ToString(gxTv_SdtSDTMunicipio_Zonacostoadicional, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtSDTMunicipio_Zonacostoadicional = NumberUtil.Val(value);
			}
		}
		[SoapIgnore]
		[XmlIgnore]
		public decimal gxTpr_Zonacostoadicional
		{
			get {
				return gxTv_SdtSDTMunicipio_Zonacostoadicional; 
			}
			set {
				gxTv_SdtSDTMunicipio_Zonacostoadicional = value;
				SetDirty("Zonacostoadicional");
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
			gxTv_SdtSDTMunicipio_Departamentomunicipionombre = "";

			return  ;
		}



		#endregion

		#region Declaration

		protected long gxTv_SdtSDTMunicipio_Departamentomunicipioid;
		 

		protected string gxTv_SdtSDTMunicipio_Departamentomunicipionombre;
		 

		protected decimal gxTv_SdtSDTMunicipio_Zonacostoadicional;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"SDTMunicipio", Namespace="AlmangoX")]
	public class SdtSDTMunicipio_RESTInterface : GxGenericCollectionItem<SdtSDTMunicipio>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSDTMunicipio_RESTInterface( ) : base()
		{	
		}

		public SdtSDTMunicipio_RESTInterface( SdtSDTMunicipio psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="DepartamentoMunicipioId", Order=0)]
		public  string gxTpr_Departamentomunicipioid
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Departamentomunicipioid, 18, 0));

			}
			set { 
				sdt.gxTpr_Departamentomunicipioid = (long) NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="DepartamentoMunicipioNombre", Order=1)]
		public  string gxTpr_Departamentomunicipionombre
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Departamentomunicipionombre);

			}
			set { 
				 sdt.gxTpr_Departamentomunicipionombre = value;
			}
		}

		[DataMember(Name="ZonaCostoAdicional", Order=2)]
		public  string gxTpr_Zonacostoadicional
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str(  sdt.gxTpr_Zonacostoadicional, 18, 2));

			}
			set { 
				sdt.gxTpr_Zonacostoadicional =  NumberUtil.Val( value, ".");
			}
		}


		#endregion
		public SdtSDTMunicipio sdt
		{
			get { 
				return (SdtSDTMunicipio)Sdt;
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
				sdt = new SdtSDTMunicipio() ;
			}
		}
	}
	#endregion
}
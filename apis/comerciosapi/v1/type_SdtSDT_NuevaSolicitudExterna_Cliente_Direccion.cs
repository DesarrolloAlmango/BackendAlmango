/*
				   File: type_SdtSDT_NuevaSolicitudExterna_Cliente_Direccion
			Description: Direccion
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

using GeneXus.Programs;
using GeneXus.Programs.apis;
using GeneXus.Programs.apis.comerciosapi;

namespace GeneXus.Programs.apis.comerciosapi.v1
{
	[XmlSerializerFormat]
	[XmlRoot(ElementName="SDT_NuevaSolicitudExterna.Cliente.Direccion")]
	[XmlType(TypeName="SDT_NuevaSolicitudExterna.Cliente.Direccion" , Namespace="AlmangoX" )]
	[Serializable]
	public class SdtSDT_NuevaSolicitudExterna_Cliente_Direccion : GxUserType
	{
		public SdtSDT_NuevaSolicitudExterna_Cliente_Direccion( )
		{
			/* Constructor for serialization */
			gxTv_SdtSDT_NuevaSolicitudExterna_Cliente_Direccion_Calleynumero = "";

			gxTv_SdtSDT_NuevaSolicitudExterna_Cliente_Direccion_Codigopais = "";

			gxTv_SdtSDT_NuevaSolicitudExterna_Cliente_Direccion_Departamento = "";

			gxTv_SdtSDT_NuevaSolicitudExterna_Cliente_Direccion_Municipio = "";

		}

		public SdtSDT_NuevaSolicitudExterna_Cliente_Direccion(IGxContext context)
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
			AddObjectProperty("CalleYNumero", gxTpr_Calleynumero, false);


			AddObjectProperty("CodigoPais", gxTpr_Codigopais, false);


			AddObjectProperty("Departamento", gxTpr_Departamento, false);


			AddObjectProperty("Municipio", gxTpr_Municipio, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="CalleYNumero")]
		[XmlElement(ElementName="CalleYNumero")]
		public string gxTpr_Calleynumero
		{
			get {
				return gxTv_SdtSDT_NuevaSolicitudExterna_Cliente_Direccion_Calleynumero; 
			}
			set {
				gxTv_SdtSDT_NuevaSolicitudExterna_Cliente_Direccion_Calleynumero = value;
				SetDirty("Calleynumero");
			}
		}




		[SoapElement(ElementName="CodigoPais")]
		[XmlElement(ElementName="CodigoPais")]
		public string gxTpr_Codigopais
		{
			get {
				return gxTv_SdtSDT_NuevaSolicitudExterna_Cliente_Direccion_Codigopais; 
			}
			set {
				gxTv_SdtSDT_NuevaSolicitudExterna_Cliente_Direccion_Codigopais = value;
				SetDirty("Codigopais");
			}
		}




		[SoapElement(ElementName="Departamento")]
		[XmlElement(ElementName="Departamento")]
		public string gxTpr_Departamento
		{
			get {
				return gxTv_SdtSDT_NuevaSolicitudExterna_Cliente_Direccion_Departamento; 
			}
			set {
				gxTv_SdtSDT_NuevaSolicitudExterna_Cliente_Direccion_Departamento = value;
				SetDirty("Departamento");
			}
		}




		[SoapElement(ElementName="Municipio")]
		[XmlElement(ElementName="Municipio")]
		public string gxTpr_Municipio
		{
			get {
				return gxTv_SdtSDT_NuevaSolicitudExterna_Cliente_Direccion_Municipio; 
			}
			set {
				gxTv_SdtSDT_NuevaSolicitudExterna_Cliente_Direccion_Municipio = value;
				SetDirty("Municipio");
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
			gxTv_SdtSDT_NuevaSolicitudExterna_Cliente_Direccion_Calleynumero = "";
			gxTv_SdtSDT_NuevaSolicitudExterna_Cliente_Direccion_Codigopais = "";
			gxTv_SdtSDT_NuevaSolicitudExterna_Cliente_Direccion_Departamento = "";
			gxTv_SdtSDT_NuevaSolicitudExterna_Cliente_Direccion_Municipio = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected string gxTv_SdtSDT_NuevaSolicitudExterna_Cliente_Direccion_Calleynumero;
		 

		protected string gxTv_SdtSDT_NuevaSolicitudExterna_Cliente_Direccion_Codigopais;
		 

		protected string gxTv_SdtSDT_NuevaSolicitudExterna_Cliente_Direccion_Departamento;
		 

		protected string gxTv_SdtSDT_NuevaSolicitudExterna_Cliente_Direccion_Municipio;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"SDT_NuevaSolicitudExterna.Cliente.Direccion", Namespace="AlmangoX")]
	public class SdtSDT_NuevaSolicitudExterna_Cliente_Direccion_RESTInterface : GxGenericCollectionItem<SdtSDT_NuevaSolicitudExterna_Cliente_Direccion>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSDT_NuevaSolicitudExterna_Cliente_Direccion_RESTInterface( ) : base()
		{	
		}

		public SdtSDT_NuevaSolicitudExterna_Cliente_Direccion_RESTInterface( SdtSDT_NuevaSolicitudExterna_Cliente_Direccion psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="CalleYNumero", Order=0)]
		public  string gxTpr_Calleynumero
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Calleynumero);

			}
			set { 
				 sdt.gxTpr_Calleynumero = value;
			}
		}

		[DataMember(Name="CodigoPais", Order=1)]
		public  string gxTpr_Codigopais
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Codigopais);

			}
			set { 
				 sdt.gxTpr_Codigopais = value;
			}
		}

		[DataMember(Name="Departamento", Order=2)]
		public  string gxTpr_Departamento
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Departamento);

			}
			set { 
				 sdt.gxTpr_Departamento = value;
			}
		}

		[DataMember(Name="Municipio", Order=3)]
		public  string gxTpr_Municipio
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Municipio);

			}
			set { 
				 sdt.gxTpr_Municipio = value;
			}
		}


		#endregion
		public SdtSDT_NuevaSolicitudExterna_Cliente_Direccion sdt
		{
			get { 
				return (SdtSDT_NuevaSolicitudExterna_Cliente_Direccion)Sdt;
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
				sdt = new SdtSDT_NuevaSolicitudExterna_Cliente_Direccion() ;
			}
		}
	}
	#endregion
}
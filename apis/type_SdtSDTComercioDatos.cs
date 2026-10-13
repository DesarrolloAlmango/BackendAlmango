/*
				   File: type_SdtSDTComercioDatos
			Description: SDTComercioDatos
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

namespace GeneXus.Programs.apis
{
	[XmlSerializerFormat]
	[XmlRoot(ElementName="SDTComercioDatos")]
	[XmlType(TypeName="SDTComercioDatos" , Namespace="AlmangoX" )]
	[Serializable]
	public class SdtSDTComercioDatos : GxUserType
	{
		public SdtSDTComercioDatos( )
		{
			/* Constructor for serialization */
			gxTv_SdtSDTComercioDatos_Proveedorestiponombre = "";

			gxTv_SdtSDTComercioDatos_Proveedornombre = "";

			gxTv_SdtSDTComercioDatos_Proveedorrazonsocial = "";

			gxTv_SdtSDTComercioDatos_Proveedorcontacto = "";

			gxTv_SdtSDTComercioDatos_Proveedorcontactocell = "";

			gxTv_SdtSDTComercioDatos_Proveedorimagen = "";
			gxTv_SdtSDTComercioDatos_Proveedorimagen_gxi = "";

			gxTv_SdtSDTComercioDatos_Proveedordocidentidad = "";

			gxTv_SdtSDTComercioDatos_Proveedortelefono = "";

			gxTv_SdtSDTComercioDatos_Proveedordireccion = "";

			gxTv_SdtSDTComercioDatos_Proveedoremail = "";

			gxTv_SdtSDTComercioDatos_Proveedorsitioweb = "";

			gxTv_SdtSDTComercioDatos_Proveedoraceptoterminos = (DateTime)(DateTime.MinValue);

			gxTv_SdtSDTComercioDatos_Proveedorperaltshop = "";

			gxTv_SdtSDTComercioDatos_Proveedorestado = "";

			gxTv_SdtSDTComercioDatos_Proveedorpagodefault = "";

			gxTv_SdtSDTComercioDatos_Proveedorpidedoc = "";

			gxTv_SdtSDTComercioDatos_Documentacionicono = "";
			gxTv_SdtSDTComercioDatos_Documentacionicono_gxi = "";

			gxTv_SdtSDTComercioDatos_Proveedorfechaalta = (DateTime)(DateTime.MinValue);

			gxTv_SdtSDTComercioDatos_Proveedorfechaactualizacion = (DateTime)(DateTime.MinValue);

			gxTv_SdtSDTComercioDatos_Proveedorusointerno = "";

			gxTv_SdtSDTComercioDatos_Proveedorcuentabancaria = "";

			gxTv_SdtSDTComercioDatos_Banconombre = "";

		}

		public SdtSDTComercioDatos(IGxContext context)
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
			AddObjectProperty("ProveedorID", StringUtil.LTrim( StringUtil.Str( (decimal)gxTpr_Proveedorid, 18, 0)), false);


			AddObjectProperty("ProveedoresTipoId", StringUtil.LTrim( StringUtil.Str( (decimal)gxTpr_Proveedorestipoid, 18, 0)), false);


			AddObjectProperty("ProveedoresTipoNombre", gxTpr_Proveedorestiponombre, false);


			AddObjectProperty("ProveedorNombre", gxTpr_Proveedornombre, false);


			AddObjectProperty("ProveedorRazonSocial", gxTpr_Proveedorrazonsocial, false);


			AddObjectProperty("ProveedorContacto", gxTpr_Proveedorcontacto, false);


			AddObjectProperty("ProveedorContactoCell", gxTpr_Proveedorcontactocell, false);


			AddObjectProperty("ProveedorImagen", gxTpr_Proveedorimagen, false);
			AddObjectProperty("ProveedorImagen_GXI", gxTpr_Proveedorimagen_gxi, false);



			AddObjectProperty("ProveedorDocIdentidad", gxTpr_Proveedordocidentidad, false);


			AddObjectProperty("ProveedorSerialComi", gxTpr_Proveedorserialcomi, false);


			AddObjectProperty("ProveedorTelefono", gxTpr_Proveedortelefono, false);


			AddObjectProperty("ProveedorDireccion", gxTpr_Proveedordireccion, false);


			AddObjectProperty("ProveedorEmail", gxTpr_Proveedoremail, false);


			AddObjectProperty("ProveedorSitioWeb", gxTpr_Proveedorsitioweb, false);


			datetime_STZ = gxTpr_Proveedoraceptoterminos;
			sDateCnv = "";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Year(datetime_STZ)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + "-";
			sNumToPad = StringUtil.Trim( StringUtil.Str((decimal)(DateTimeUtil.Month(datetime_STZ)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + "-";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Day(datetime_STZ)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + "T";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Hour(datetime_STZ)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + ":";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Minute(datetime_STZ)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + ":";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Second(datetime_STZ)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			AddObjectProperty("ProveedorAceptoTerminos", sDateCnv, false);



			AddObjectProperty("ProveedorPerAltShop", gxTpr_Proveedorperaltshop, false);


			AddObjectProperty("ProveedorEstado", gxTpr_Proveedorestado, false);


			AddObjectProperty("ProveedorPagoDefault", gxTpr_Proveedorpagodefault, false);


			AddObjectProperty("ProveedorPideDoc", gxTpr_Proveedorpidedoc, false);


			AddObjectProperty("DocumentacionId", StringUtil.LTrim( StringUtil.Str( (decimal)gxTpr_Documentacionid, 18, 0)), false);


			AddObjectProperty("DocumentacionIcono", gxTpr_Documentacionicono, false);
			AddObjectProperty("DocumentacionIcono_GXI", gxTpr_Documentacionicono_gxi, false);



			AddObjectProperty("ProveedorUsrAlta", gxTpr_Proveedorusralta, false);


			AddObjectProperty("ProveedorUsrActualizacion", gxTpr_Proveedorusractualizacion, false);


			datetime_STZ = gxTpr_Proveedorfechaalta;
			sDateCnv = "";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Year(datetime_STZ)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + "-";
			sNumToPad = StringUtil.Trim( StringUtil.Str((decimal)(DateTimeUtil.Month(datetime_STZ)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + "-";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Day(datetime_STZ)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + "T";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Hour(datetime_STZ)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + ":";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Minute(datetime_STZ)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + ":";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Second(datetime_STZ)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			AddObjectProperty("ProveedorFechaAlta", sDateCnv, false);



			datetime_STZ = gxTpr_Proveedorfechaactualizacion;
			sDateCnv = "";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Year(datetime_STZ)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + "-";
			sNumToPad = StringUtil.Trim( StringUtil.Str((decimal)(DateTimeUtil.Month(datetime_STZ)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + "-";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Day(datetime_STZ)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + "T";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Hour(datetime_STZ)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + ":";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Minute(datetime_STZ)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + ":";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Second(datetime_STZ)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			AddObjectProperty("ProveedorFechaActualizacion", sDateCnv, false);



			AddObjectProperty("ProveedorUsoInterno", gxTpr_Proveedorusointerno, false);


			AddObjectProperty("ProveedorCuentaBancaria", gxTpr_Proveedorcuentabancaria, false);


			AddObjectProperty("BancoId", StringUtil.LTrim( StringUtil.Str( (decimal)gxTpr_Bancoid, 18, 0)), false);


			AddObjectProperty("BancoNombre", gxTpr_Banconombre, false);

			if (gxTv_SdtSDTComercioDatos_Comision != null)
			{
				AddObjectProperty("Comision", gxTv_SdtSDTComercioDatos_Comision, false);
			}
			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="ProveedorID")]
		[XmlElement(ElementName="ProveedorID")]
		public long gxTpr_Proveedorid
		{
			get {
				return gxTv_SdtSDTComercioDatos_Proveedorid; 
			}
			set {
				gxTv_SdtSDTComercioDatos_Proveedorid = value;
				SetDirty("Proveedorid");
			}
		}




		[SoapElement(ElementName="ProveedoresTipoId")]
		[XmlElement(ElementName="ProveedoresTipoId")]
		public long gxTpr_Proveedorestipoid
		{
			get {
				return gxTv_SdtSDTComercioDatos_Proveedorestipoid; 
			}
			set {
				gxTv_SdtSDTComercioDatos_Proveedorestipoid = value;
				SetDirty("Proveedorestipoid");
			}
		}




		[SoapElement(ElementName="ProveedoresTipoNombre")]
		[XmlElement(ElementName="ProveedoresTipoNombre")]
		public string gxTpr_Proveedorestiponombre
		{
			get {
				return gxTv_SdtSDTComercioDatos_Proveedorestiponombre; 
			}
			set {
				gxTv_SdtSDTComercioDatos_Proveedorestiponombre = value;
				SetDirty("Proveedorestiponombre");
			}
		}




		[SoapElement(ElementName="ProveedorNombre")]
		[XmlElement(ElementName="ProveedorNombre")]
		public string gxTpr_Proveedornombre
		{
			get {
				return gxTv_SdtSDTComercioDatos_Proveedornombre; 
			}
			set {
				gxTv_SdtSDTComercioDatos_Proveedornombre = value;
				SetDirty("Proveedornombre");
			}
		}




		[SoapElement(ElementName="ProveedorRazonSocial")]
		[XmlElement(ElementName="ProveedorRazonSocial")]
		public string gxTpr_Proveedorrazonsocial
		{
			get {
				return gxTv_SdtSDTComercioDatos_Proveedorrazonsocial; 
			}
			set {
				gxTv_SdtSDTComercioDatos_Proveedorrazonsocial = value;
				SetDirty("Proveedorrazonsocial");
			}
		}




		[SoapElement(ElementName="ProveedorContacto")]
		[XmlElement(ElementName="ProveedorContacto")]
		public string gxTpr_Proveedorcontacto
		{
			get {
				return gxTv_SdtSDTComercioDatos_Proveedorcontacto; 
			}
			set {
				gxTv_SdtSDTComercioDatos_Proveedorcontacto = value;
				SetDirty("Proveedorcontacto");
			}
		}




		[SoapElement(ElementName="ProveedorContactoCell")]
		[XmlElement(ElementName="ProveedorContactoCell")]
		public string gxTpr_Proveedorcontactocell
		{
			get {
				return gxTv_SdtSDTComercioDatos_Proveedorcontactocell; 
			}
			set {
				gxTv_SdtSDTComercioDatos_Proveedorcontactocell = value;
				SetDirty("Proveedorcontactocell");
			}
		}




		[SoapElement(ElementName="ProveedorImagen")]
		[XmlElement(ElementName="ProveedorImagen")]
		[GxUpload()]

		public string gxTpr_Proveedorimagen
		{
			get {
				return gxTv_SdtSDTComercioDatos_Proveedorimagen; 
			}
			set {
				gxTv_SdtSDTComercioDatos_Proveedorimagen = value;
				SetDirty("Proveedorimagen");
			}
		}


		[SoapElement(ElementName="ProveedorImagen_GXI" )]
		[XmlElement(ElementName="ProveedorImagen_GXI" )]
		public string gxTpr_Proveedorimagen_gxi
		{
			get {
				return gxTv_SdtSDTComercioDatos_Proveedorimagen_gxi ;
			}
			set {
				gxTv_SdtSDTComercioDatos_Proveedorimagen_gxi = value;
				SetDirty("Proveedorimagen_gxi");
			}
		}

		[SoapElement(ElementName="ProveedorDocIdentidad")]
		[XmlElement(ElementName="ProveedorDocIdentidad")]
		public string gxTpr_Proveedordocidentidad
		{
			get {
				return gxTv_SdtSDTComercioDatos_Proveedordocidentidad; 
			}
			set {
				gxTv_SdtSDTComercioDatos_Proveedordocidentidad = value;
				SetDirty("Proveedordocidentidad");
			}
		}




		[SoapElement(ElementName="ProveedorSerialComi")]
		[XmlElement(ElementName="ProveedorSerialComi")]
		public short gxTpr_Proveedorserialcomi
		{
			get {
				return gxTv_SdtSDTComercioDatos_Proveedorserialcomi; 
			}
			set {
				gxTv_SdtSDTComercioDatos_Proveedorserialcomi = value;
				SetDirty("Proveedorserialcomi");
			}
		}




		[SoapElement(ElementName="ProveedorTelefono")]
		[XmlElement(ElementName="ProveedorTelefono")]
		public string gxTpr_Proveedortelefono
		{
			get {
				return gxTv_SdtSDTComercioDatos_Proveedortelefono; 
			}
			set {
				gxTv_SdtSDTComercioDatos_Proveedortelefono = value;
				SetDirty("Proveedortelefono");
			}
		}




		[SoapElement(ElementName="ProveedorDireccion")]
		[XmlElement(ElementName="ProveedorDireccion")]
		public string gxTpr_Proveedordireccion
		{
			get {
				return gxTv_SdtSDTComercioDatos_Proveedordireccion; 
			}
			set {
				gxTv_SdtSDTComercioDatos_Proveedordireccion = value;
				SetDirty("Proveedordireccion");
			}
		}




		[SoapElement(ElementName="ProveedorEmail")]
		[XmlElement(ElementName="ProveedorEmail")]
		public string gxTpr_Proveedoremail
		{
			get {
				return gxTv_SdtSDTComercioDatos_Proveedoremail; 
			}
			set {
				gxTv_SdtSDTComercioDatos_Proveedoremail = value;
				SetDirty("Proveedoremail");
			}
		}




		[SoapElement(ElementName="ProveedorSitioWeb")]
		[XmlElement(ElementName="ProveedorSitioWeb")]
		public string gxTpr_Proveedorsitioweb
		{
			get {
				return gxTv_SdtSDTComercioDatos_Proveedorsitioweb; 
			}
			set {
				gxTv_SdtSDTComercioDatos_Proveedorsitioweb = value;
				SetDirty("Proveedorsitioweb");
			}
		}



		[SoapElement(ElementName="ProveedorAceptoTerminos")]
		[XmlElement(ElementName="ProveedorAceptoTerminos" , IsNullable=true)]
		public string gxTpr_Proveedoraceptoterminos_Nullable
		{
			get {
				if ( gxTv_SdtSDTComercioDatos_Proveedoraceptoterminos == DateTime.MinValue)
					return null;
				return new GxDatetimeString(gxTv_SdtSDTComercioDatos_Proveedoraceptoterminos).value ;
			}
			set {
				gxTv_SdtSDTComercioDatos_Proveedoraceptoterminos = DateTimeUtil.CToD2(value);
			}
		}

		[SoapIgnore]
		[XmlIgnore]
		public DateTime gxTpr_Proveedoraceptoterminos
		{
			get {
				return gxTv_SdtSDTComercioDatos_Proveedoraceptoterminos; 
			}
			set {
				gxTv_SdtSDTComercioDatos_Proveedoraceptoterminos = value;
				SetDirty("Proveedoraceptoterminos");
			}
		}



		[SoapElement(ElementName="ProveedorPerAltShop")]
		[XmlElement(ElementName="ProveedorPerAltShop")]
		public string gxTpr_Proveedorperaltshop
		{
			get {
				return gxTv_SdtSDTComercioDatos_Proveedorperaltshop; 
			}
			set {
				gxTv_SdtSDTComercioDatos_Proveedorperaltshop = value;
				SetDirty("Proveedorperaltshop");
			}
		}




		[SoapElement(ElementName="ProveedorEstado")]
		[XmlElement(ElementName="ProveedorEstado")]
		public string gxTpr_Proveedorestado
		{
			get {
				return gxTv_SdtSDTComercioDatos_Proveedorestado; 
			}
			set {
				gxTv_SdtSDTComercioDatos_Proveedorestado = value;
				SetDirty("Proveedorestado");
			}
		}




		[SoapElement(ElementName="ProveedorPagoDefault")]
		[XmlElement(ElementName="ProveedorPagoDefault")]
		public string gxTpr_Proveedorpagodefault
		{
			get {
				return gxTv_SdtSDTComercioDatos_Proveedorpagodefault; 
			}
			set {
				gxTv_SdtSDTComercioDatos_Proveedorpagodefault = value;
				SetDirty("Proveedorpagodefault");
			}
		}




		[SoapElement(ElementName="ProveedorPideDoc")]
		[XmlElement(ElementName="ProveedorPideDoc")]
		public string gxTpr_Proveedorpidedoc
		{
			get {
				return gxTv_SdtSDTComercioDatos_Proveedorpidedoc; 
			}
			set {
				gxTv_SdtSDTComercioDatos_Proveedorpidedoc = value;
				SetDirty("Proveedorpidedoc");
			}
		}




		[SoapElement(ElementName="DocumentacionId")]
		[XmlElement(ElementName="DocumentacionId")]
		public long gxTpr_Documentacionid
		{
			get {
				return gxTv_SdtSDTComercioDatos_Documentacionid; 
			}
			set {
				gxTv_SdtSDTComercioDatos_Documentacionid = value;
				SetDirty("Documentacionid");
			}
		}




		[SoapElement(ElementName="DocumentacionIcono")]
		[XmlElement(ElementName="DocumentacionIcono")]
		[GxUpload()]

		public string gxTpr_Documentacionicono
		{
			get {
				return gxTv_SdtSDTComercioDatos_Documentacionicono; 
			}
			set {
				gxTv_SdtSDTComercioDatos_Documentacionicono = value;
				SetDirty("Documentacionicono");
			}
		}


		[SoapElement(ElementName="DocumentacionIcono_GXI" )]
		[XmlElement(ElementName="DocumentacionIcono_GXI" )]
		public string gxTpr_Documentacionicono_gxi
		{
			get {
				return gxTv_SdtSDTComercioDatos_Documentacionicono_gxi ;
			}
			set {
				gxTv_SdtSDTComercioDatos_Documentacionicono_gxi = value;
				SetDirty("Documentacionicono_gxi");
			}
		}

		[SoapElement(ElementName="ProveedorUsrAlta")]
		[XmlElement(ElementName="ProveedorUsrAlta")]
		public long gxTpr_Proveedorusralta
		{
			get {
				return gxTv_SdtSDTComercioDatos_Proveedorusralta; 
			}
			set {
				gxTv_SdtSDTComercioDatos_Proveedorusralta = value;
				SetDirty("Proveedorusralta");
			}
		}




		[SoapElement(ElementName="ProveedorUsrActualizacion")]
		[XmlElement(ElementName="ProveedorUsrActualizacion")]
		public long gxTpr_Proveedorusractualizacion
		{
			get {
				return gxTv_SdtSDTComercioDatos_Proveedorusractualizacion; 
			}
			set {
				gxTv_SdtSDTComercioDatos_Proveedorusractualizacion = value;
				SetDirty("Proveedorusractualizacion");
			}
		}



		[SoapElement(ElementName="ProveedorFechaAlta")]
		[XmlElement(ElementName="ProveedorFechaAlta" , IsNullable=true)]
		public string gxTpr_Proveedorfechaalta_Nullable
		{
			get {
				if ( gxTv_SdtSDTComercioDatos_Proveedorfechaalta == DateTime.MinValue)
					return null;
				return new GxDatetimeString(gxTv_SdtSDTComercioDatos_Proveedorfechaalta).value ;
			}
			set {
				gxTv_SdtSDTComercioDatos_Proveedorfechaalta = DateTimeUtil.CToD2(value);
			}
		}

		[SoapIgnore]
		[XmlIgnore]
		public DateTime gxTpr_Proveedorfechaalta
		{
			get {
				return gxTv_SdtSDTComercioDatos_Proveedorfechaalta; 
			}
			set {
				gxTv_SdtSDTComercioDatos_Proveedorfechaalta = value;
				SetDirty("Proveedorfechaalta");
			}
		}


		[SoapElement(ElementName="ProveedorFechaActualizacion")]
		[XmlElement(ElementName="ProveedorFechaActualizacion" , IsNullable=true)]
		public string gxTpr_Proveedorfechaactualizacion_Nullable
		{
			get {
				if ( gxTv_SdtSDTComercioDatos_Proveedorfechaactualizacion == DateTime.MinValue)
					return null;
				return new GxDatetimeString(gxTv_SdtSDTComercioDatos_Proveedorfechaactualizacion).value ;
			}
			set {
				gxTv_SdtSDTComercioDatos_Proveedorfechaactualizacion = DateTimeUtil.CToD2(value);
			}
		}

		[SoapIgnore]
		[XmlIgnore]
		public DateTime gxTpr_Proveedorfechaactualizacion
		{
			get {
				return gxTv_SdtSDTComercioDatos_Proveedorfechaactualizacion; 
			}
			set {
				gxTv_SdtSDTComercioDatos_Proveedorfechaactualizacion = value;
				SetDirty("Proveedorfechaactualizacion");
			}
		}



		[SoapElement(ElementName="ProveedorUsoInterno")]
		[XmlElement(ElementName="ProveedorUsoInterno")]
		public string gxTpr_Proveedorusointerno
		{
			get {
				return gxTv_SdtSDTComercioDatos_Proveedorusointerno; 
			}
			set {
				gxTv_SdtSDTComercioDatos_Proveedorusointerno = value;
				SetDirty("Proveedorusointerno");
			}
		}




		[SoapElement(ElementName="ProveedorCuentaBancaria")]
		[XmlElement(ElementName="ProveedorCuentaBancaria")]
		public string gxTpr_Proveedorcuentabancaria
		{
			get {
				return gxTv_SdtSDTComercioDatos_Proveedorcuentabancaria; 
			}
			set {
				gxTv_SdtSDTComercioDatos_Proveedorcuentabancaria = value;
				SetDirty("Proveedorcuentabancaria");
			}
		}




		[SoapElement(ElementName="BancoId")]
		[XmlElement(ElementName="BancoId")]
		public long gxTpr_Bancoid
		{
			get {
				return gxTv_SdtSDTComercioDatos_Bancoid; 
			}
			set {
				gxTv_SdtSDTComercioDatos_Bancoid = value;
				SetDirty("Bancoid");
			}
		}




		[SoapElement(ElementName="BancoNombre")]
		[XmlElement(ElementName="BancoNombre")]
		public string gxTpr_Banconombre
		{
			get {
				return gxTv_SdtSDTComercioDatos_Banconombre; 
			}
			set {
				gxTv_SdtSDTComercioDatos_Banconombre = value;
				SetDirty("Banconombre");
			}
		}




		[SoapElement(ElementName="Comision" )]
		[XmlArray(ElementName="Comision"  )]
		[XmlArrayItemAttribute(ElementName="ComisionItem" , IsNullable=false )]
		public GXBaseCollection<SdtSDTComercioDatos_ComisionItem> gxTpr_Comision
		{
			get {
				if ( gxTv_SdtSDTComercioDatos_Comision == null )
				{
					gxTv_SdtSDTComercioDatos_Comision = new GXBaseCollection<SdtSDTComercioDatos_ComisionItem>( context, "SDTComercioDatos.ComisionItem", "");
				}
				SetDirty("Comision");
				return gxTv_SdtSDTComercioDatos_Comision;
			}
			set {
				gxTv_SdtSDTComercioDatos_Comision_N = false;
				gxTv_SdtSDTComercioDatos_Comision = value;
				SetDirty("Comision");
			}
		}

		public void gxTv_SdtSDTComercioDatos_Comision_SetNull()
		{
			gxTv_SdtSDTComercioDatos_Comision_N = true;
			gxTv_SdtSDTComercioDatos_Comision = null;
		}

		public bool gxTv_SdtSDTComercioDatos_Comision_IsNull()
		{
			return gxTv_SdtSDTComercioDatos_Comision == null;
		}
		public bool ShouldSerializegxTpr_Comision_GxSimpleCollection_Json()
		{
			return gxTv_SdtSDTComercioDatos_Comision != null && gxTv_SdtSDTComercioDatos_Comision.Count > 0;

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
			gxTv_SdtSDTComercioDatos_Proveedorestiponombre = "";
			gxTv_SdtSDTComercioDatos_Proveedornombre = "";
			gxTv_SdtSDTComercioDatos_Proveedorrazonsocial = "";
			gxTv_SdtSDTComercioDatos_Proveedorcontacto = "";
			gxTv_SdtSDTComercioDatos_Proveedorcontactocell = "";
			gxTv_SdtSDTComercioDatos_Proveedorimagen = "";gxTv_SdtSDTComercioDatos_Proveedorimagen_gxi = "";
			gxTv_SdtSDTComercioDatos_Proveedordocidentidad = "";

			gxTv_SdtSDTComercioDatos_Proveedortelefono = "";
			gxTv_SdtSDTComercioDatos_Proveedordireccion = "";
			gxTv_SdtSDTComercioDatos_Proveedoremail = "";
			gxTv_SdtSDTComercioDatos_Proveedorsitioweb = "";
			gxTv_SdtSDTComercioDatos_Proveedoraceptoterminos = (DateTime)(DateTime.MinValue);
			gxTv_SdtSDTComercioDatos_Proveedorperaltshop = "";
			gxTv_SdtSDTComercioDatos_Proveedorestado = "";
			gxTv_SdtSDTComercioDatos_Proveedorpagodefault = "";
			gxTv_SdtSDTComercioDatos_Proveedorpidedoc = "";

			gxTv_SdtSDTComercioDatos_Documentacionicono = "";gxTv_SdtSDTComercioDatos_Documentacionicono_gxi = "";


			gxTv_SdtSDTComercioDatos_Proveedorfechaalta = (DateTime)(DateTime.MinValue);
			gxTv_SdtSDTComercioDatos_Proveedorfechaactualizacion = (DateTime)(DateTime.MinValue);
			gxTv_SdtSDTComercioDatos_Proveedorusointerno = "";
			gxTv_SdtSDTComercioDatos_Proveedorcuentabancaria = "";

			gxTv_SdtSDTComercioDatos_Banconombre = "";

			gxTv_SdtSDTComercioDatos_Comision_N = true;

			datetime_STZ = (DateTime)(DateTime.MinValue);
			sDateCnv = "";
			sNumToPad = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected string sDateCnv ;
		protected string sNumToPad ;
		protected DateTime datetime_STZ ;

		protected long gxTv_SdtSDTComercioDatos_Proveedorid;
		 

		protected long gxTv_SdtSDTComercioDatos_Proveedorestipoid;
		 

		protected string gxTv_SdtSDTComercioDatos_Proveedorestiponombre;
		 

		protected string gxTv_SdtSDTComercioDatos_Proveedornombre;
		 

		protected string gxTv_SdtSDTComercioDatos_Proveedorrazonsocial;
		 

		protected string gxTv_SdtSDTComercioDatos_Proveedorcontacto;
		 

		protected string gxTv_SdtSDTComercioDatos_Proveedorcontactocell;
		 
		protected string gxTv_SdtSDTComercioDatos_Proveedorimagen_gxi;
		protected string gxTv_SdtSDTComercioDatos_Proveedorimagen;
		 

		protected string gxTv_SdtSDTComercioDatos_Proveedordocidentidad;
		 

		protected short gxTv_SdtSDTComercioDatos_Proveedorserialcomi;
		 

		protected string gxTv_SdtSDTComercioDatos_Proveedortelefono;
		 

		protected string gxTv_SdtSDTComercioDatos_Proveedordireccion;
		 

		protected string gxTv_SdtSDTComercioDatos_Proveedoremail;
		 

		protected string gxTv_SdtSDTComercioDatos_Proveedorsitioweb;
		 

		protected DateTime gxTv_SdtSDTComercioDatos_Proveedoraceptoterminos;
		 

		protected string gxTv_SdtSDTComercioDatos_Proveedorperaltshop;
		 

		protected string gxTv_SdtSDTComercioDatos_Proveedorestado;
		 

		protected string gxTv_SdtSDTComercioDatos_Proveedorpagodefault;
		 

		protected string gxTv_SdtSDTComercioDatos_Proveedorpidedoc;
		 

		protected long gxTv_SdtSDTComercioDatos_Documentacionid;
		 
		protected string gxTv_SdtSDTComercioDatos_Documentacionicono_gxi;
		protected string gxTv_SdtSDTComercioDatos_Documentacionicono;
		 

		protected long gxTv_SdtSDTComercioDatos_Proveedorusralta;
		 

		protected long gxTv_SdtSDTComercioDatos_Proveedorusractualizacion;
		 

		protected DateTime gxTv_SdtSDTComercioDatos_Proveedorfechaalta;
		 

		protected DateTime gxTv_SdtSDTComercioDatos_Proveedorfechaactualizacion;
		 

		protected string gxTv_SdtSDTComercioDatos_Proveedorusointerno;
		 

		protected string gxTv_SdtSDTComercioDatos_Proveedorcuentabancaria;
		 

		protected long gxTv_SdtSDTComercioDatos_Bancoid;
		 

		protected string gxTv_SdtSDTComercioDatos_Banconombre;
		 
		protected bool gxTv_SdtSDTComercioDatos_Comision_N;
		protected GXBaseCollection<SdtSDTComercioDatos_ComisionItem> gxTv_SdtSDTComercioDatos_Comision = null; 



		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"SDTComercioDatos", Namespace="AlmangoX")]
	public class SdtSDTComercioDatos_RESTInterface : GxGenericCollectionItem<SdtSDTComercioDatos>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSDTComercioDatos_RESTInterface( ) : base()
		{	
		}

		public SdtSDTComercioDatos_RESTInterface( SdtSDTComercioDatos psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="ProveedorID", Order=0)]
		public  string gxTpr_Proveedorid
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Proveedorid, 18, 0));

			}
			set { 
				sdt.gxTpr_Proveedorid = (long) NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="ProveedoresTipoId", Order=1)]
		public  string gxTpr_Proveedorestipoid
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Proveedorestipoid, 18, 0));

			}
			set { 
				sdt.gxTpr_Proveedorestipoid = (long) NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="ProveedoresTipoNombre", Order=2)]
		public  string gxTpr_Proveedorestiponombre
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Proveedorestiponombre);

			}
			set { 
				 sdt.gxTpr_Proveedorestiponombre = value;
			}
		}

		[DataMember(Name="ProveedorNombre", Order=3)]
		public  string gxTpr_Proveedornombre
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Proveedornombre);

			}
			set { 
				 sdt.gxTpr_Proveedornombre = value;
			}
		}

		[DataMember(Name="ProveedorRazonSocial", Order=4)]
		public  string gxTpr_Proveedorrazonsocial
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Proveedorrazonsocial);

			}
			set { 
				 sdt.gxTpr_Proveedorrazonsocial = value;
			}
		}

		[DataMember(Name="ProveedorContacto", Order=5)]
		public  string gxTpr_Proveedorcontacto
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Proveedorcontacto);

			}
			set { 
				 sdt.gxTpr_Proveedorcontacto = value;
			}
		}

		[DataMember(Name="ProveedorContactoCell", Order=6)]
		public  string gxTpr_Proveedorcontactocell
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Proveedorcontactocell);

			}
			set { 
				 sdt.gxTpr_Proveedorcontactocell = value;
			}
		}

		[DataMember(Name="ProveedorImagen", Order=7)]
		[GxUpload()]
		public  string gxTpr_Proveedorimagen
		{
			get { 
				return (!String.IsNullOrEmpty(StringUtil.RTrim( sdt.gxTpr_Proveedorimagen)) ? PathUtil.RelativePath( sdt.gxTpr_Proveedorimagen) : StringUtil.RTrim( sdt.gxTpr_Proveedorimagen_gxi));

			}
			set { 
				 sdt.gxTpr_Proveedorimagen = value;
			}
		}

		[DataMember(Name="ProveedorDocIdentidad", Order=8)]
		public  string gxTpr_Proveedordocidentidad
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Proveedordocidentidad);

			}
			set { 
				 sdt.gxTpr_Proveedordocidentidad = value;
			}
		}

		[DataMember(Name="ProveedorSerialComi", Order=9)]
		public short gxTpr_Proveedorserialcomi
		{
			get { 
				return sdt.gxTpr_Proveedorserialcomi;

			}
			set { 
				sdt.gxTpr_Proveedorserialcomi = value;
			}
		}

		[DataMember(Name="ProveedorTelefono", Order=10)]
		public  string gxTpr_Proveedortelefono
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Proveedortelefono);

			}
			set { 
				 sdt.gxTpr_Proveedortelefono = value;
			}
		}

		[DataMember(Name="ProveedorDireccion", Order=11)]
		public  string gxTpr_Proveedordireccion
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Proveedordireccion);

			}
			set { 
				 sdt.gxTpr_Proveedordireccion = value;
			}
		}

		[DataMember(Name="ProveedorEmail", Order=12)]
		public  string gxTpr_Proveedoremail
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Proveedoremail);

			}
			set { 
				 sdt.gxTpr_Proveedoremail = value;
			}
		}

		[DataMember(Name="ProveedorSitioWeb", Order=13)]
		public  string gxTpr_Proveedorsitioweb
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Proveedorsitioweb);

			}
			set { 
				 sdt.gxTpr_Proveedorsitioweb = value;
			}
		}

		[DataMember(Name="ProveedorAceptoTerminos", Order=14)]
		public  string gxTpr_Proveedoraceptoterminos
		{
			get { 
				return DateTimeUtil.TToC2( sdt.gxTpr_Proveedoraceptoterminos,context);

			}
			set { 
				sdt.gxTpr_Proveedoraceptoterminos = DateTimeUtil.CToT2(value,context);
			}
		}

		[DataMember(Name="ProveedorPerAltShop", Order=15)]
		public  string gxTpr_Proveedorperaltshop
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Proveedorperaltshop);

			}
			set { 
				 sdt.gxTpr_Proveedorperaltshop = value;
			}
		}

		[DataMember(Name="ProveedorEstado", Order=16)]
		public  string gxTpr_Proveedorestado
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Proveedorestado);

			}
			set { 
				 sdt.gxTpr_Proveedorestado = value;
			}
		}

		[DataMember(Name="ProveedorPagoDefault", Order=17)]
		public  string gxTpr_Proveedorpagodefault
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Proveedorpagodefault);

			}
			set { 
				 sdt.gxTpr_Proveedorpagodefault = value;
			}
		}

		[DataMember(Name="ProveedorPideDoc", Order=18)]
		public  string gxTpr_Proveedorpidedoc
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Proveedorpidedoc);

			}
			set { 
				 sdt.gxTpr_Proveedorpidedoc = value;
			}
		}

		[DataMember(Name="DocumentacionId", Order=19)]
		public  string gxTpr_Documentacionid
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Documentacionid, 18, 0));

			}
			set { 
				sdt.gxTpr_Documentacionid = (long) NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="DocumentacionIcono", Order=20)]
		[GxUpload()]
		public  string gxTpr_Documentacionicono
		{
			get { 
				return (!String.IsNullOrEmpty(StringUtil.RTrim( sdt.gxTpr_Documentacionicono)) ? PathUtil.RelativePath( sdt.gxTpr_Documentacionicono) : StringUtil.RTrim( sdt.gxTpr_Documentacionicono_gxi));

			}
			set { 
				 sdt.gxTpr_Documentacionicono = value;
			}
		}

		[DataMember(Name="ProveedorUsrAlta", Order=21)]
		public  string gxTpr_Proveedorusralta
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Proveedorusralta, 10, 0));

			}
			set { 
				sdt.gxTpr_Proveedorusralta = (long) NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="ProveedorUsrActualizacion", Order=22)]
		public  string gxTpr_Proveedorusractualizacion
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Proveedorusractualizacion, 10, 0));

			}
			set { 
				sdt.gxTpr_Proveedorusractualizacion = (long) NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="ProveedorFechaAlta", Order=23)]
		public  string gxTpr_Proveedorfechaalta
		{
			get { 
				return DateTimeUtil.TToC2( sdt.gxTpr_Proveedorfechaalta,context);

			}
			set { 
				sdt.gxTpr_Proveedorfechaalta = DateTimeUtil.CToT2(value,context);
			}
		}

		[DataMember(Name="ProveedorFechaActualizacion", Order=24)]
		public  string gxTpr_Proveedorfechaactualizacion
		{
			get { 
				return DateTimeUtil.TToC2( sdt.gxTpr_Proveedorfechaactualizacion,context);

			}
			set { 
				sdt.gxTpr_Proveedorfechaactualizacion = DateTimeUtil.CToT2(value,context);
			}
		}

		[DataMember(Name="ProveedorUsoInterno", Order=25)]
		public  string gxTpr_Proveedorusointerno
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Proveedorusointerno);

			}
			set { 
				 sdt.gxTpr_Proveedorusointerno = value;
			}
		}

		[DataMember(Name="ProveedorCuentaBancaria", Order=26)]
		public  string gxTpr_Proveedorcuentabancaria
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Proveedorcuentabancaria);

			}
			set { 
				 sdt.gxTpr_Proveedorcuentabancaria = value;
			}
		}

		[DataMember(Name="BancoId", Order=27)]
		public  string gxTpr_Bancoid
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Bancoid, 18, 0));

			}
			set { 
				sdt.gxTpr_Bancoid = (long) NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="BancoNombre", Order=28)]
		public  string gxTpr_Banconombre
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Banconombre);

			}
			set { 
				 sdt.gxTpr_Banconombre = value;
			}
		}

		[DataMember(Name="Comision", Order=29, EmitDefaultValue=false)]
		public GxGenericCollection<SdtSDTComercioDatos_ComisionItem_RESTInterface> gxTpr_Comision
		{
			get {
				if (sdt.ShouldSerializegxTpr_Comision_GxSimpleCollection_Json())
					return new GxGenericCollection<SdtSDTComercioDatos_ComisionItem_RESTInterface>(sdt.gxTpr_Comision);
				else
					return null;

			}
			set {
				value.LoadCollection(sdt.gxTpr_Comision);
			}
		}


		#endregion
		public SdtSDTComercioDatos sdt
		{
			get { 
				return (SdtSDTComercioDatos)Sdt;
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
				sdt = new SdtSDTComercioDatos() ;
			}
		}
	}
	#endregion
}
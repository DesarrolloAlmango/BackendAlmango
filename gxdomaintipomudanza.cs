using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using GeneXus.Reorg;
using System.Threading;
using GeneXus.Programs;
using System.Web.Services;
using System.Data;
using GeneXus.Data;
using GeneXus.Data.ADO;
using GeneXus.Data.NTier;
using GeneXus.Data.NTier.ADO;
using GeneXus.XML;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Xml.Serialization;
namespace GeneXus.Programs {
   public class gxdomaintipomudanza
   {
      private static Hashtable domain = new Hashtable();
      private static Hashtable domainMap;
      static gxdomaintipomudanza ()
      {
         domain["TipoInmuebleCasa"] = "Tipo Inmueble Casa";
         domain["TipoEstacionamiento"] = "Tipo Estacionamiento";
         domain["TipoVehiculo"] = "Tipo Vehiculo";
         domain["ItemCargaHogar"] = "Electro Hogar";
         domain["ItemAdicional"] = "Item Adicional";
         domain["Peaje"] = "Peaje";
         domain["TipoInmuebleApto"] = "Tipo Inmueble Apto";
         domain["ItemCargaMobiliario"] = "Mobiliario";
         domain["ItemCargaExterior"] = "Exterior y Jardín";
         domain["ItemCargaDecoracion"] = "Decoración";
         domain["ItemCargaOtros"] = "Otros";
         domain["Escalera"] = "Escalera";
         domain["Ascensor"] = "Ascensor";
         domain["EscaAsce"] = "Esca+Asce";
         domain["PrecioEmbalaje"] = "Precio Embalaje";
         domain["PrecioElevacion"] = "Precio Elevacion";
         domain["PrecioBase"] = "Precio Base";
         domain["TiempoxKm"] = "Tiempox Km";
         domain["TiempoxM3"] = "Tiempox M3";
      }

      public static string getDescription( IGxContext context ,
                                           string key )
      {
         string rtkey;
         string value;
         rtkey = ((key==null) ? "" : StringUtil.Trim( (string)(key)));
         value = (string)(domain[rtkey]==null?"":domain[rtkey]);
         return context.GetMessage( value, "") ;
      }

      public static GxSimpleCollection<string> getValues( )
      {
         GxSimpleCollection<string> value = new GxSimpleCollection<string>();
         ArrayList aKeys = new ArrayList(domain.Keys);
         aKeys.Sort();
         foreach (string key in aKeys)
         {
            value.Add(key);
         }
         return value;
      }

      [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.Synchronized)]
      public static string getValue( string key )
      {
         if(domainMap == null)
         {
            domainMap = new Hashtable();
            domainMap["TipoInmuebleCasa"] = "TipoInmuebleCasa";
            domainMap["TipoEstacionamiento"] = "TipoEstacionamiento";
            domainMap["TipoVehiculo"] = "TipoVehiculo";
            domainMap["ItemCargaHogar"] = "ItemCargaHogar";
            domainMap["ItemAdicional"] = "ItemAdicional";
            domainMap["Peaje"] = "Peaje";
            domainMap["TipoInmuebleApto"] = "TipoInmuebleApto";
            domainMap["ItemCargaMobiliario"] = "ItemCargaMobiliario";
            domainMap["ItemCargaExterior"] = "ItemCargaExterior";
            domainMap["ItemCargaDecoracion"] = "ItemCargaDecoracion";
            domainMap["ItemCargaOtros"] = "ItemCargaOtros";
            domainMap["Escalera"] = "Escalera";
            domainMap["Ascensor"] = "Ascensor";
            domainMap["EscaAsce"] = "EscaAsce";
            domainMap["PrecioEmbalaje"] = "PrecioEmbalaje";
            domainMap["PrecioElevacion"] = "PrecioElevacion";
            domainMap["PrecioBase"] = "PrecioBase";
            domainMap["TiempoxKm"] = "TiempoxKm";
            domainMap["TiempoxM3"] = "TiempoxM3";
         }
         return (string)domainMap[key] ;
      }

   }

}

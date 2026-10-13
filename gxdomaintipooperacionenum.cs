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
   public class gxdomaintipooperacionenum
   {
      private static Hashtable domain = new Hashtable();
      private static Hashtable domainMap;
      static gxdomaintipooperacionenum ()
      {
         domain["LSF"] = "Liquidación de Solicitudes del Profesional";
         domain["LSC"] = "Liquidación de  Solicitudes Comercio";
         domain["COL"] = "Cobro de Saldo Pendiente";
         domain["POL"] = "Pago de Saldo";
         domain["CSO"] = "Cobro de Solicitud";
         domain["NCR"] = "Nota de Credito";
         domain["NDE"] = "Nota de Debito";
         domain["OTR"] = "Otros";
         domain["FEN"] = "Solicitudes ingresadas desde Fenicio";
         domain["FGO"] = "Respuesta de api fenicio";
         domain["CEX"] = "COMERCIO_EXTERNO";
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
            domainMap["LiquidaSolicitudesPF"] = "LSF";
            domainMap["LiquidaSolicitudesCOM"] = "LSC";
            domainMap["CobroLiquidacion"] = "COL";
            domainMap["PagoLiquidacion"] = "POL";
            domainMap["CobroSolicitud"] = "CSO";
            domainMap["NotaCredito"] = "NCR";
            domainMap["NotaDebito"] = "NDE";
            domainMap["Otros"] = "OTR";
            domainMap["FENICIO"] = "FEN";
            domainMap["FENICIO_GET_ORDERS"] = "FGO";
            domainMap["COMERCIO_EXTERNO"] = "CEX";
         }
         return (string)domainMap[key] ;
      }

   }

}

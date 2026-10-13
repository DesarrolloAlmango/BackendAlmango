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
   public class gxdomainsolicitudsubtipo
   {
      private static Hashtable domain = new Hashtable();
      private static Hashtable domainMap;
      static gxdomainsolicitudsubtipo ()
      {
         domain["T"] = "Trabajo Registrado";
         domain["E"] = "Ecommerce";
         domain["G"] = "Garantia";
         domain["M"] = "Mudanza";
         domain["A"] = "Obra";
         domain["O"] = "Otros";
         domain["Z"] = "Postulacion";
         domain["S"] = "Subasta Web";
         domain["P"] = "Postulacion Web";
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
            domainMap["TrabajoRegistrado"] = "T";
            domainMap["Ecommerce"] = "E";
            domainMap["Garantia"] = "G";
            domainMap["Mudanza"] = "M";
            domainMap["Obra"] = "A";
            domainMap["Otros"] = "O";
            domainMap["Postulacion"] = "Z";
            domainMap["SubastaWeb"] = "S";
            domainMap["PostulacionWeb"] = "P";
         }
         return (string)domainMap[key] ;
      }

   }

}

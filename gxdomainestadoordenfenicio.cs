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
   public class gxdomainestadoordenfenicio
   {
      private static Hashtable domain = new Hashtable();
      private static Hashtable domainMap;
      static gxdomainestadoordenfenicio ()
      {
         domain["1"] = "EN_CURSO";
         domain["2"] = "ABANDONADA";
         domain["3"] = "PAGO_PENDIENTE";
         domain["4"] = "REQUIERE_APROBACION";
         domain["5"] = "APROBADA";
         domain["6"] = "CANCELADA";
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
            domainMap["EN_CURSO"] = "1";
            domainMap["ABANDONADA"] = "2";
            domainMap["PAGO_PENDIENTE"] = "3";
            domainMap["REQUIERE_APROBACION"] = "4";
            domainMap["APROBADA"] = "5";
            domainMap["CANCELADA"] = "6";
         }
         return (string)domainMap[key] ;
      }

   }

}

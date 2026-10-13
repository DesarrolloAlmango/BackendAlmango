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
namespace GeneXus.Programs.apis {
   public class gxdomaintipoempresaprofesional
   {
      private static Hashtable domain = new Hashtable();
      private static Hashtable domainMap;
      static gxdomaintipoempresaprofesional ()
      {
         domain[(short)1] = "Monotributo";
         domain[(short)2] = "Monotributo Mides";
         domain[(short)3] = "Pequeña Empresa (Literal E)";
         domain[(short)4] = "Régimen General";
      }

      public static string getDescription( IGxContext context ,
                                           short key )
      {
         string value;
         value = (string)(domain[key]==null?"":domain[key]);
         return ((context!=null) ? context.GetMessage( value, "") : value) ;
      }

      public static GxSimpleCollection<short> getValues( )
      {
         GxSimpleCollection<short> value = new GxSimpleCollection<short>();
         ArrayList aKeys = new ArrayList(domain.Keys);
         aKeys.Sort();
         foreach (short key in aKeys)
         {
            value.Add(key);
         }
         return value;
      }

      [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.Synchronized)]
      public static short getValue( string key )
      {
         if(domainMap == null)
         {
            domainMap = new Hashtable();
            domainMap["Monotributo"] = (short)1;
            domainMap["MonotributoMides"] = (short)2;
            domainMap["LiteralE"] = (short)3;
            domainMap["RegimenGeneral"] = (short)4;
         }
         return (short)domainMap[key] ;
      }

   }

}

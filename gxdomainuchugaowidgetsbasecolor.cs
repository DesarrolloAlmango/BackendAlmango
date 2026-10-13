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
   public class gxdomainuchugaowidgetsbasecolor
   {
      private static Hashtable domain = new Hashtable();
      private static Hashtable domainMap;
      static gxdomainuchugaowidgetsbasecolor ()
      {
         domain["hugao-bg-red"] = "Red";
         domain["hugao-bg-yellow"] = "Yellow";
         domain["hugao-bg-aqua"] = "Aqua";
         domain["hugao-bg-blue"] = "Blue";
         domain["hugao-bg-light-blue"] = "Light Blue";
         domain["hugao-bg-green"] = "Green";
         domain["hugao-bg-navy"] = "Navy";
         domain["hugao-bg-teal"] = "Teal";
         domain["hugao-bg-olive"] = "Olive";
         domain["hugao-bg-lime"] = "Lime";
         domain["hugao-bg-orange"] = "Orange";
         domain["hugao-bg-fuchsia"] = "Fuchsia";
         domain["hugao-bg-purple"] = "Purple";
         domain["hugao-bg-marron"] = "Marron";
         domain["hugao-bg-black"] = "Black";
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
            domainMap["Red"] = "hugao-bg-red";
            domainMap["Yellow"] = "hugao-bg-yellow";
            domainMap["Aqua"] = "hugao-bg-aqua";
            domainMap["Blue"] = "hugao-bg-blue";
            domainMap["LightBlue"] = "hugao-bg-light-blue";
            domainMap["Green"] = "hugao-bg-green";
            domainMap["Navy"] = "hugao-bg-navy";
            domainMap["Teal"] = "hugao-bg-teal";
            domainMap["Olive"] = "hugao-bg-olive";
            domainMap["Lime"] = "hugao-bg-lime";
            domainMap["Orange"] = "hugao-bg-orange";
            domainMap["Fuchsia"] = "hugao-bg-fuchsia";
            domainMap["Purple"] = "hugao-bg-purple";
            domainMap["Marron"] = "hugao-bg-marron";
            domainMap["Black"] = "hugao-bg-black";
         }
         return (string)domainMap[key] ;
      }

   }

}

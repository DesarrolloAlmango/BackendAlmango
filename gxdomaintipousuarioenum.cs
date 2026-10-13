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
   public class gxdomaintipousuarioenum
   {
      private static Hashtable domain = new Hashtable();
      private static Hashtable domainMap;
      static gxdomaintipousuarioenum ()
      {
         domain["A"] = "Administrador del Sistema";
         domain["P"] = "Proveedor Servicio";
         domain["G"] = "Administrador Agencia";
         domain["S"] = "Agente de Servicio";
         domain["C"] = "Cliente";
         domain["R"] = "Usuario Registrado";
         domain["U"] = "Usuario sin Registrar";
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
            domainMap["AdministradorSistema"] = "A";
            domainMap["ProveedorServicio"] = "P";
            domainMap["AdministradorAgencia"] = "G";
            domainMap["AgenteServicio"] = "S";
            domainMap["Cliente"] = "C";
            domainMap["UsuarioRegistrado"] = "R";
            domainMap["UsuarioSinRegistro"] = "U";
         }
         return (string)domainMap[key] ;
      }

   }

}

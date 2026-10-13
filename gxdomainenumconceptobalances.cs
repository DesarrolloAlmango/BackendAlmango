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
   public class gxdomainenumconceptobalances
   {
      private static Hashtable domain = new Hashtable();
      private static Hashtable domainMap;
      static gxdomainenumconceptobalances ()
      {
         domain[(short)1] = "Pago Enviado";
         domain[(short)2] = "Pago Recibido";
         domain[(short)3] = "Deuda";
         domain[(short)4] = "Crédito";
         domain[(short)5] = "Liquidación";
         domain[(short)6] = "Saldo Inicial";
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
            domainMap["PagoEnviado"] = (short)1;
            domainMap["PagoRecibido"] = (short)2;
            domainMap["Deuda"] = (short)3;
            domainMap["Credito"] = (short)4;
            domainMap["Liquidacion"] = (short)5;
            domainMap["SaldoInicial"] = (short)6;
         }
         return (short)domainMap[key] ;
      }

   }

}

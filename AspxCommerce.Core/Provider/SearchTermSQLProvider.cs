﻿/*
AspxCommerce® - http://www.aspxcommerce.com
Copyright (c) 20011-2012 by AspxCommerce
Permission is hereby granted, free of charge, to any person obtaining
a copy of this software and associated documentation files (the
"Software"), to deal in the Software without restriction, including
without limitation the rights to use, copy, modify, merge, publish,
distribute, sublicense, and/or sell copies of the Software, and to
permit persons to whom the Software is furnished to do so, subject to
the following conditions:

The above copyright notice and this permission notice shall be
included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE
LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION
OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION
WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
*/
using System.Collections.Generic;
using SageFrame.Web.Utilities;

namespace AspxCommerce.Core
{
  public  class SearchTermSQLProvider
    {
      public List<SearchTermInfo> ManageSearchTerm(int offset, int limit, int storeID, int portalID, string cultureName,string searchTerm)
      {
          List<KeyValuePair<string, object>> parameter = new List<KeyValuePair<string, object>>();
          parameter.Add(new KeyValuePair<string, object>("@Offset", offset));
          parameter.Add(new KeyValuePair<string, object>("@Limit", limit));
          parameter.Add(new KeyValuePair<string, object>("@StoreID", storeID));
          parameter.Add(new KeyValuePair<string, object>("@PortalID", portalID));
          parameter.Add(new KeyValuePair<string, object>("@CultureName", cultureName));
          parameter.Add(new KeyValuePair<string, object>("@SearchTerm", searchTerm));
          SQLHandler sqlH = new SQLHandler();
          return sqlH.ExecuteAsList<SearchTermInfo>("usp_Aspx_GetSearchTermDetails", parameter);
      }
      public void DeleteSearchTerm(string Ids, int storeID, int portalID,string userName, string cultureName)
      {
          List<KeyValuePair<string, object>> parameter = new List<KeyValuePair<string, object>>();
          parameter.Add(new KeyValuePair<string, object>("@SearchTermID", Ids));
          parameter.Add(new KeyValuePair<string, object>("@StoreID", storeID));
          parameter.Add(new KeyValuePair<string, object>("@PortalID", portalID));
          parameter.Add(new KeyValuePair<string, object>("@UserName", userName));
          parameter.Add(new KeyValuePair<string, object>("@CultureName", cultureName));
          SQLHandler sqlH = new SQLHandler();
          sqlH.ExecuteNonQuery("usp_Aspx_DeleteSearchTerm", parameter);
      }
      public List<SearchTermInfo> GetSearchStatistics(int count, string commandName, int storeID, int portalID, string cultureName)
      {
          List<KeyValuePair<string, object>> parameter = new List<KeyValuePair<string, object>>();
          parameter.Add(new KeyValuePair<string, object>("@Count", count));
          parameter.Add(new KeyValuePair<string, object>("@CommandName", commandName));
          parameter.Add(new KeyValuePair<string, object>("@StoreID", storeID));
          parameter.Add(new KeyValuePair<string, object>("@PortalID", portalID));
          parameter.Add(new KeyValuePair<string, object>("@CultureName", cultureName));
          SQLHandler sqlH = new SQLHandler();
          return sqlH.ExecuteAsList<SearchTermInfo>("usp_Aspx_GetSearchTermStatistics", parameter);
      }
      public void AddUpdateSearchTerm(string searchTerm, int storeID, int portalID, string userName, string cultureName)
      {
          List<KeyValuePair<string, object>> parameter = new List<KeyValuePair<string, object>>();
          parameter.Add(new KeyValuePair<string, object>("@SearchTerm", searchTerm));
          parameter.Add(new KeyValuePair<string, object>("@StoreID", storeID));
          parameter.Add(new KeyValuePair<string, object>("@PortalID", portalID));
          parameter.Add(new KeyValuePair<string, object>("@UserName", userName));
          parameter.Add(new KeyValuePair<string, object>("@CultureName", cultureName));
          SQLHandler sqlh = new SQLHandler();
          sqlh.ExecuteNonQuery("usp_Aspx_AddUpdateSearchTerm", parameter);
      }
    }
   
}

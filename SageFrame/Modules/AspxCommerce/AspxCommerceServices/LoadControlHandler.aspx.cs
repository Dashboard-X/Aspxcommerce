﻿/*
AspxCommerce® - http://www.AspxCommerce.com
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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using SageFrame.Framework;
using SageFrame.Web;
using System.IO;

public partial class Modules_AspxCommerce_AspxCommerceServices_LoadControlHandler : PageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    #region Loading Control Region
    [WebMethod]
    public static string Result(string controlName)
    {
        return Results(controlName);
    }

    public static string Results(string controlName)
    {
        try
        {
            Page page = new Page();
            SageUserControl userControl = (SageUserControl)page.LoadControl(controlName);
            page.Controls.Add(userControl);

            StringWriter textWriter = new StringWriter();
            HttpContext.Current.Server.Execute(page, textWriter, false);
            return textWriter.ToString();
        }
        catch (Exception ex)
        {
            return ex.ToString();
        }
    }
    #endregion
}

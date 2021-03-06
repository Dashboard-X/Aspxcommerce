﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Security;
using SageFrame.ErrorLog;
using SageFrame.Web;
using System.Web.UI;
using SageFrame.Core;

namespace SageFrame.FileManager
{
    public class FileManagerBase : System.Web.UI.Page
    {
        int PortalID = 1;

        public void ProcessException(Exception exc)
        {
            ErrorLogDataContext db = new ErrorLogDataContext(SystemSetting.SageFrameConnectionString);
            System.Nullable<int> inID = 0;
            db.sp_LogInsert(ref inID, (int)SageFrame.Web.SageFrameEnums.ErrorType.AdministrationArea, 11, exc.Message, exc.ToString(),
                HttpContext.Current.Request.UserHostAddress, HttpContext.Current.Request.RawUrl, true, GetPortalID, GetUsername);
           
        }
        
        public int GetPortalID
        {
            get
            {
                try
                {
                    if (Session["SageFrame.PortalID"] != null && Session["SageFrame.PortalID"].ToString() != "")
                    {
                        return int.Parse(Session["SageFrame.PortalID"].ToString());
                    }
                    else
                    {
                        return 1;
                    }
                }
                catch
                {
                    return 1;
                }
            }
        }

        public void SetPortalID(int portalID)
        {
            PortalID = portalID;
        }

        public string GetUsername
        {
            get
            {
                try
                {
                    if (Session["UserName"] == null)
                    {
                        MembershipUser user = Membership.GetUser();
                        if (user != null)
                        {
                            Session["UserName"] = user.UserName;
                            return user.UserName;
                        }
                        else
                        {
                            return "anonymoususer";
                        }

                    }
                    else
                    {
                        return Session["UserName"].ToString();
                    }

                }
                catch
                {
                    return "anonymoususer";
                }
            }
        }
    }
}

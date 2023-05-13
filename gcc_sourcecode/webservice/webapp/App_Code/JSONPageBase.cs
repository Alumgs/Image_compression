using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

/// <summary>
/// JSONPageBase 的摘要说明
/// </summary>
public abstract class JSONPageBase : System.Web.UI.Page
{
    protected bool isCheck = true;
    public JSONPageBase()
    {

    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (isCheck && (!User.Identity.IsAuthenticated || Session["userid"] == null))
        {
            HttpContext.Current.ApplicationInstance.CompleteRequest();
            return;
        }
        JavaScriptSerializer serializer = new JavaScriptSerializer();
        Response.Write(serializer.Serialize(GetResponseObj()));
        HttpContext.Current.ApplicationInstance.CompleteRequest();
    }
    public abstract Object GetResponseObj();

    protected int GetIntPara(String paramName)
    {
        int paramValue = 0;
        if (Request[paramName] != null && Request[paramName].ToString().Length > 0 && Request[paramName].ToString() != "undefined")
        {
            try
            {
                paramValue = Convert.ToInt32(Request[paramName]);
            }
            catch
            {
            }
        }
        return paramValue;
    }

    private static string GetIP()
    {
        string userHostAddress = "";
        string forvalue = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
        if (forvalue != null)
        {
            userHostAddress = forvalue.ToString().Split(',')[0].Trim();
        }
        if (string.IsNullOrEmpty(userHostAddress))
        {
            userHostAddress = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
        }
        if (string.IsNullOrEmpty(userHostAddress))
        {
            userHostAddress = HttpContext.Current.Request.UserHostAddress;
        }
        if (!string.IsNullOrEmpty(userHostAddress) && IsIP(userHostAddress))
        {
            return userHostAddress;
        }
        return "127.0.0.1";
    }

    private static bool IsIP(string ip)
    {
        return System.Text.RegularExpressions.Regex.IsMatch(ip, @"^((2[0-4]\d|25[0-5]|[01]?\d\d?)\.){3}(2[0-4]\d|25[0-5]|[01]?\d\d?)$");
    }

    protected Int32? GetIntNullPara(String paramName)
    {
        Int32? paramValue = null;
        if (Request[paramName] != null && Request[paramName].ToString().Length > 0)
        {
            try
            {
                paramValue = Convert.ToInt32(Request[paramName]);
            }
            catch
            {
            }
        }
        return paramValue;
    }
    protected double GetDoublePara(String paramName)
    {
        double paramValue = 0;
        if (Request[paramName] != null && Request[paramName].ToString().Length > 0)
        {
            try
            {
                paramValue = Convert.ToDouble(Request[paramName]);
            }
            catch
            {
            }
        }
        return paramValue;
    }
    protected string GetStringPara(String paramName)
    {
        string paramValue = "";
        if (Request[paramName] != null && Request[paramName].ToString() != "undefined")
        {
            paramValue = Request[paramName].ToString();
        }
        return paramValue;
    }
}
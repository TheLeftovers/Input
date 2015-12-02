﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
/// <summary>
/// Summary description for Class1
/// </summary>
public static class MessageBox
{
    public static void Show(this Page Page, string Message)
    {
        Page.ClientScript.RegisterStartupScript(
        Page.GetType(),
        "MessageBox",
        "<script language='javascript'>alert ('" + Message + "');</script>");
    }
}
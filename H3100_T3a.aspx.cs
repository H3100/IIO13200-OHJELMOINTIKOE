using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

public partial class H3100_T3a : System.Web.UI.Page
{
    private string MappedApplicationPath
    {
        get
        {
            string APP_PATH = System.Web.HttpContext.Current.Request.ApplicationPath.ToLower();
            if (APP_PATH == "/")      //a site
                APP_PATH = "/";
            else if (!APP_PATH.EndsWith(@"/")) //a virtual
                APP_PATH += @"/";

            string it = System.Web.HttpContext.Current.Server.MapPath(APP_PATH);
            if (!it.EndsWith(@"\"))
                it += @"\";
            return it;
        }
    }
    private string GetMD5Hash(string input)
    {
        System.Security.Cryptography.MD5CryptoServiceProvider x =
            new System.Security.Cryptography.MD5CryptoServiceProvider();
        byte[] bs = System.Text.Encoding.UTF8.GetBytes(input);
        bs = x.ComputeHash(bs);
        System.Text.StringBuilder s = new System.Text.StringBuilder();
        foreach (byte b in bs)
        {
            s.Append(b.ToString("x2").ToLower());
        }
        string password = s.ToString();
        return password;
    }

    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnKirjaudu_Click(object sender, EventArgs e)
    {
        string user2 = txtKT.Text;
        string passwd2 = txtSalasana.Text;

        string fromWebConfig = WebConfigurationManager.AppSettings["XMLKayttajaSalasana"].ToString();
        string path = MappedApplicationPath + fromWebConfig;
        XmlDocument doc = new XmlDocument();
        doc.Load(path);
        XmlNodeList nodes = doc.SelectNodes("kayttajat/kayttaja");
        //lblIlmoitus.Text = nodes.Item(0).SelectNodes("/kayttaja").Count.ToString();
        //lblMessage.Text += nodes.Count.ToString();
        for (int i = 0; i < nodes.Count; i++)
        {
            lblMessage.Text += "K ";  
            //lblIlmoitus.Text += " " + i.ToString();
            if (nodes[i].InnerText.Length > 0)
            {
                XmlNode node = nodes[i];

                lblMessage.Text += node["kayttajatunnus"].InnerText + " " +node["salasana"].InnerText;

                if (node["kayttajatunnus"].InnerText.Equals(user2) 
                    && node["salasana"].InnerText.Equals(GetMD5Hash(passwd2+user2)))
                    {
                        string toBeRedirected = "~/H3100_T3aSivusto.aspx?kayttajatunnus="
                                                    + user2;
                        Response.Redirect(toBeRedirected);
                    }                    
            }
             
        }
        lblMessage.Text += "Salasaja tai käyttäjätunnus väärin";
    }
}
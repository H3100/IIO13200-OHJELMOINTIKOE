using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

public partial class H3100_T3a_KayttajaSalasanaLisays : System.Web.UI.Page
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
    protected void Button1_Click(object sender, EventArgs e)
    {
        string fromWebConfig = WebConfigurationManager.AppSettings["XMLKayttajaSalasana"].ToString();
        string path = MappedApplicationPath + fromWebConfig;
        XmlDocument doc = new XmlDocument();
        doc.Load(path);
        // XmlNode root = doc.SelectSingleNode("/");
        XmlNode root = doc.DocumentElement.FirstChild;

        XmlNode kayttaja = doc.CreateElement("kayttaja");

        XmlNode kayttajatunnus = doc.CreateElement("kayttajatunnus");
        XmlNode salasana = doc.CreateElement("salasana");

        try
        {
            kayttajatunnus.InnerText = txtKT.Text;
            // txtTK.Text as a salt.
            salasana.InnerText = GetMD5Hash(txtSalasana.Text + txtKT.Text);
        }
        catch (Exception)
        {
            lblTesti.Text = "Syötä käyttäjätunnus ja salasana";
            throw;
        }


        kayttaja.AppendChild(kayttajatunnus);
        kayttaja.AppendChild(salasana);

        root.AppendChild(kayttaja);

        lblTesti.Text = root.InnerText;

        doc.Save(path);
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.Xml.Linq;

public partial class H3100_T3aSivusto : System.Web.UI.Page
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

    protected void Page_Load(object sender, EventArgs e)
    {
        txtNimi.Text = Request["kayttajatunnus"];
    }
    protected void btnTallenna_Click(object sender, EventArgs e)
    {
        string fromWebConfig = WebConfigurationManager.AppSettings["Hiihto"].ToString();
        string path = MappedApplicationPath + fromWebConfig;
        XmlDocument doc = new XmlDocument();
        doc.Load(path);
         //XmlNode root = doc.SelectSingleNode("/");
        XmlNode root = doc.DocumentElement; //.FirstChild;

        XmlNode hiihto = doc.CreateElement("hiihto");
        /*
         * <hiihtaja>Teppo</hiihtaja>
    <PVM>12.12.2012</PVM>
    <tunnit>1</tunnit>
    <minuutit>12</minuutit>
    <kilometrit>15</kilometrit>
         * */
        XmlNode hiihtaja = doc.CreateElement("hiihtaja");
        XmlNode PVM = doc.CreateElement("PVM");
        XmlNode tunnit = doc.CreateElement("tunnit");
        XmlNode minuutit = doc.CreateElement("minuutit");
        XmlNode kilometrit = doc.CreateElement("kilometrit");

        try
        {
            hiihtaja.InnerText = txtNimi.Text;
            PVM.InnerText = txtPvm.Text;
            tunnit.InnerText = txtTunnit.Text;
            minuutit.InnerText = txtMinuutit.Text;
            kilometrit.InnerText = txtKilometrit.Text;

        }
        catch (Exception)
        {
            //lblTesti.Text = "Syötä käyttäjätunnus ja salasana";
            throw;
        }


        hiihto.AppendChild(hiihtaja);
        hiihto.AppendChild(PVM);
        hiihto.AppendChild(tunnit);
        hiihto.AppendChild(minuutit);
        hiihto.AppendChild(kilometrit);
        

        root.AppendChild(hiihto);

        //lblTesti.Text = root.InnerText;

        doc.Save(path);
        lblMessage.Text = "Tiedot tallennettu.";
    }
    private void muutaXMLJarjestusLaskevaksi()
    {
        string fromWebConfig = WebConfigurationManager.AppSettings["Hiihto"].ToString();
        string path = MappedApplicationPath + fromWebConfig;

        XElement xDoc = XElement.Load(path);
        var xmlJarjestyksessa = xDoc.Elements("Hiihto").OrderByDescending(xtab => (int)xtab.Element("PVM")).ToArray();

        xDoc.RemoveAll();
        foreach (XElement item in xmlJarjestyksessa)
        {
            xDoc.Add(item);
        }
        xDoc.Save(path);
    }
    protected void btnListaa_Click(object sender, EventArgs e)
    {
        muutaXMLJarjestusLaskevaksi();

        string fromWebConfig = WebConfigurationManager.AppSettings["Hiihto"].ToString();
        string path = MappedApplicationPath + fromWebConfig;

        XmlDocument doc = new XmlDocument();
        doc.Load(path);

        TableCell cell1 = new TableCell();
        TableCell cell2 = new TableCell();
        TableCell cell3 = new TableCell();
        TableCell cell4 = new TableCell();
        TableCell cell5 = new TableCell();

        XmlNodeList nodes = doc.SelectNodes("/hiihdot/hiihto");

        for (int i = 0; i < nodes.Count; i++)
        {

            if (nodes[i].InnerText.Length > 0)
            {
                /*
                 *     <hiihtaja>Teppo</hiihtaja>
    <PVM>12.12.2012</PVM>
    <tunnit>1</tunnit>
    <minuutit>12</minuutit>
    <kilometrit>15</kilometrit>
                 */
                XmlNode node = nodes[i];

                if (node["hiihtaja"].InnerText.Equals(txtNimi.Text))
                {
                    TableRow row = new TableRow();

                    cell1 = new TableCell();
                    cell1.Text = node["hiihtaja"].InnerText;

                    cell2 = new TableCell();
                    cell2.Text = node["PVM"].InnerText;

                    cell3 = new TableCell();
                    cell3.Text = node["tunnit"].InnerText;

                    cell4 = new TableCell();
                    cell4.Text = node["minuutit"].InnerText;

                    cell5 = new TableCell();
                    cell5.Text = node["kilometrit"].InnerText;

                    row.Cells.Add(cell1);
                    row.Cells.Add(cell2);
                    row.Cells.Add(cell3);
                    row.Cells.Add(cell4);
                    row.Cells.Add(cell5);

                    tblHiihdot.Rows.Add(row);

                }
            }
        }

    }
}
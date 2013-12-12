using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

public partial class H3100_T2 : System.Web.UI.Page
{
    public string MappedApplicationPath
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

    }
    protected void btnHae_Click(object sender, EventArgs e)
    {
        string fromWebConfig = WebConfigurationManager.AppSettings["XMLTiedostonNimi"].ToString();
        string path = MappedApplicationPath + fromWebConfig;
        XmlDocument doc = new XmlDocument();
        doc.Load(path);

        TableCell cell1 = new TableCell();
        TableCell cell2 = new TableCell();
        TableCell cell3 = new TableCell();
        TableCell cell4 = new TableCell();
        TableCell cell5 = new TableCell();

        XmlNodeList nodes = doc.SelectNodes("/tyontekijat/tyontekija");
        int k = 0;
        int palkat = 0;
        for (int i = 0; i < nodes.Count; i++)
        {
            
            if (nodes[i].InnerText.Length > 0)
            {
                /*
                 * <etunimi>Eppu</etunimi>
    <sukunimi>Normaali</sukunimi>
    <numero>11</numero>
    <tyosuhde>määräaikainen</tyosuhde>
    <palkka>10000</palkka>
                 */
                XmlNode node = nodes[i];
                TableRow row = new TableRow();

                cell1 = new TableCell();
                cell1.Text = node["etunimi"].InnerText;

                cell2 = new TableCell();
                cell2.Text = node["sukunimi"].InnerText;

                cell3 = new TableCell();
                cell3.Text = node["numero"].InnerText;

                cell4 = new TableCell();
                cell4.Text = node["tyosuhde"].InnerText;

                cell5 = new TableCell();
                cell5.Text = node["palkka"].InnerText;

                if (node["tyosuhde"].InnerText.Equals("vakituinen"))
                {
                    palkat = palkat + Convert.ToInt32(node["palkka"].InnerText);
                    k++;
                }

                row.Cells.Add(cell1);
                row.Cells.Add(cell2);
                row.Cells.Add(cell3);
                row.Cells.Add(cell4);
                row.Cells.Add(cell5);

                TableMyTable.Rows.Add(row);

            }
        }
        lblTyontekijat.Text += k.ToString();
        lblPalkat.Text += palkat.ToString();
    }
}
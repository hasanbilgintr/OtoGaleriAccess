using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OtoGaleri
{
    public class Baglanti
    {
        OleDbConnection bgl;

        public OleDbConnection baglanti()
        {
             bgl = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Application.StartupPath + @"\OtoGaleri.accdb");
            if (bgl.State == ConnectionState.Closed)
            {
                bgl.Open();
            }
            return bgl;
        }
    }
}

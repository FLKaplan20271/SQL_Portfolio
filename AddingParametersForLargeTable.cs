using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConsoleC
{
    public partial class Form1 : Form
    {
        string cn = @"Data Source=franksdesktop; Initial Catalog=Exampledb; Integrated Security=True;";



        public Form1()
        {
            InitializeComponent();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            using (SqlConnection sqlCon = new SqlConnection(cn))
            {
                sqlCon.Open();
                SqlDataAdapter sqlDa = new SqlDataAdapter("SELECT * FROM testDealer", sqlCon);
                DataTable dtbl = new DataTable();
                sqlDa.Fill(dtbl);
                dgvDealer.DataSource = dtbl;

            }
        }

        private void dgvDealer_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvDealer.CurrentRow != null)
            {
                using (SqlConnection sqlCon = new SqlConnection(cn))
                {
                    if (dgvDealer.CurrentRow != null)
                    {
                        if (sqlCon.State == ConnectionState.Closed)
                        {
                            sqlCon.Open();
                            DataGridViewRow dgvRow = dgvDealer.CurrentRow;
                            SqlCommand sqlCmd = new SqlCommand("DealerUpdate", sqlCon);
                            sqlCmd.CommandType = CommandType.StoredProcedure;
                            sqlCmd.Parameters.AddWithValue("@DealerID", dgvRow.Cells["Dealer.dealerid"].Value == DBNull.Value ? "0" : dgvRow.Cells["Dealer.dealerid"].Value);
                            sqlCmd.Parameters.AddWithValue("@DealerNumber", dgvRow.Cells["Dealer.dealernumber"].Value == DBNull.Value ? "0" : dgvRow.Cells["Dealer.dealernumber"].Value);
                            sqlCmd.Parameters.AddWithValue("@Brand", dgvRow.Cells["Dealer.brand"].Value == DBNull.Value ? "0" : dgvRow.Cells["Dealer.brand"].Value);
                            sqlCmd.Parameters.AddWithValue("@ModelYear", Convert.ToInt32(dgvRow.Cells["Dealer.modelyear"].Value == DBNull.Value ? "0" : dgvRow.Cells["Dealer.modelyear"].Value));
                            sqlCmd.Parameters.AddWithValue("@Name", dgvRow.Cells["Dealer.name"].Value == DBNull.Value ? "0" : dgvRow.Cells["Dealer.name"].Value);
                            sqlCmd.Parameters.AddWithValue("@Address", dgvRow.Cells["Dealer.address"].Value == DBNull.Value ? "0" : dgvRow.Cells["Dealer.address"].Value);
                            sqlCmd.Parameters.AddWithValue("@City", dgvRow.Cells["Dealer.city"].Value == DBNull.Value ? "0" : dgvRow.Cells["Dealer.city"].Value);
                            sqlCmd.Parameters.AddWithValue("@State", dgvRow.Cells["Dealer.state"].Value == DBNull.Value ? "0" : dgvRow.Cells["Dealer.state"].Value);
                            sqlCmd.Parameters.AddWithValue("@Zip", dgvRow.Cells["Dealer.zip"].Value == DBNull.Value ? "0" : dgvRow.Cells["Dealer.zip"].Value);
                            sqlCmd.Parameters.AddWithValue("@Telephone", dgvRow.Cells["Dealer.telephone"].Value == DBNull.Value ? "0" : dgvRow.Cells["Dealer.telephone"].Value);
                            sqlCmd.Parameters.AddWithValue("@Shipping", dgvRow.Cells["Dealer.shipping"].Value == DBNull.Value ? "0" : dgvRow.Cells["Dealer.shipping"].Value);
                            sqlCmd.Parameters.AddWithValue("@ShipBy", dgvRow.Cells["Dealer.shipby"].Value == DBNull.Value ? "0" : dgvRow.Cells["Dealer.shipby"].Value);
                            sqlCmd.Parameters.AddWithValue("@VIN", dgvRow.Cells["Dealer.VIN"].Value == DBNull.Value ? "0" : dgvRow.Cells["Dealer.VIN"].Value);
                            sqlCmd.Parameters.AddWithValue("@Comments", dgvRow.Cells["Dealer.comments"].Value == DBNull.Value ? "0" : dgvRow.Cells["Dealer.comments"].Value);
                            sqlCmd.Parameters.AddWithValue("@Model", dgvRow.Cells["Dealer.model"].Value == DBNull.Value ? "0" : dgvRow.Cells["Dealer.model"].Value);
                            sqlCmd.Parameters.AddWithValue("@Shelby", dgvRow.Cells["Dealer.shelby"].Value == DBNull.Value ? "0" : dgvRow.Cells["Dealer.shelby"].Value);
                            sqlCmd.Parameters.AddWithValue("@ProdDate", Convert.ToDateTime(dgvRow.Cells["Dealer.proddate"].Value == DBNull.Value ? "0" : dgvRow.Cells["Dealer.proddate"].Value));
                            sqlCmd.Parameters.AddWithValue("@StartDate", Convert.ToDateTime(dgvRow.Cells["Dealer.startdate"].Value == DBNull.Value ? "0" : dgvRow.Cells["Dealer.startdate"].Value));
                            sqlCmd.Parameters.AddWithValue("@EndDate", Convert.ToDateTime(dgvRow.Cells["Dealer.enddate"].Value == DBNull.Value ? "0" : dgvRow.Cells["Dealer.enddate"].Value));
                            sqlCmd.Parameters.AddWithValue("@Years", dgvRow.Cells["Dealer.years"].Value == DBNull.Value ? "0" : dgvRow.Cells["Dealer.years"].Value);
                            sqlCmd.Parameters.AddWithValue("@Year", dgvRow.Cells["Dealer.year"].Value == DBNull.Value ? "0" : dgvRow.Cells["Dealer.year"].Value);
                            sqlCmd.Parameters.AddWithValue("@FMCStatus", dgvRow.Cells["Dealer.fmcstatus"].Value == DBNull.Value ? "0" : dgvRow.Cells["Dealer.fmcstatus"].Value);
                            sqlCmd.Parameters.AddWithValue("@FMCFranchise", dgvRow.Cells["Dealer.fmcfranchise"].Value == DBNull.Value ? "0" : dgvRow.Cells["Dealer.fmcfranchise"].Value);
                            sqlCmd.Parameters.AddWithValue("@FMCSalesCode", dgvRow.Cells["Dealer.fmcsalescode"].Value == DBNull.Value ? "0" : dgvRow.Cells["Dealer.fmcsalescode"].Value);
                            sqlCmd.Parameters.AddWithValue("@FMCStartDate", dgvRow.Cells["Dealer.fmcstartdate"].Value == DBNull.Value ? "0" : dgvRow.Cells["Dealer.fmcstartdate"].Value);
                            sqlCmd.Parameters.AddWithValue("@FMCEndDate", dgvRow.Cells["Dealer.fmcenddate"].Value == DBNull.Value ? "0" : dgvRow.Cells["Dealer.fmcenddate"].Value);
                            sqlCmd.Parameters.AddWithValue("@FMCCode", dgvRow.Cells["Dealer.fmccode"].Value == DBNull.Value ? "0" : dgvRow.Cells["Dealer.fmccode"].Value);
                            sqlCmd.Parameters.AddWithValue("@Status", dgvRow.Cells["Dealer.status"].Value == DBNull.Value ? "0" : dgvRow.Cells["Dealer.status"].Value);
                            sqlCmd.Parameters.AddWithValue("@Code", dgvRow.Cells["Dealer.code"].Value == DBNull.Value ? "0" : dgvRow.Cells["Dealer.code"].Value);
                            sqlCmd.Parameters.AddWithValue("@AltAddress", dgvRow.Cells["Dealer.altaddress"].Value == DBNull.Value ? "0" : dgvRow.Cells["Dealer.altaddress"].Value);
                            sqlCmd.Parameters.AddWithValue("@GeoAddress", dgvRow.Cells["Dealer.geoaddress"].Value == DBNull.Value ? "0" : dgvRow.Cells["Dealer.geoaddress"].Value);
                            sqlCmd.Parameters.AddWithValue("@GeoCity", dgvRow.Cells["Dealer.geocity"].Value == DBNull.Value ? "0" : dgvRow.Cells["Dealer.geocity"].Value);
                            sqlCmd.Parameters.AddWithValue("@GeoState", dgvRow.Cells["Dealer.geostate"].Value == DBNull.Value ? "0" : dgvRow.Cells["Dealer.geostate"].Value);
                            sqlCmd.Parameters.AddWithValue("@GeoZip", dgvRow.Cells["Dealer.geozip"].Value == DBNull.Value ? "0" : dgvRow.Cells["Dealer.geozip"].Value);
                            sqlCmd.Parameters.AddWithValue("@GeoCounty", dgvRow.Cells["Dealer.geocounty"].Value == DBNull.Value ? "0" : dgvRow.Cells["Dealer.geocounty"].Value);
                            sqlCmd.Parameters.AddWithValue("@GeoLat", dgvRow.Cells["Dealer.geolat"].Value == DBNull.Value ? "0" : dgvRow.Cells["Dealer.geolat"].Value);
                            sqlCmd.Parameters.AddWithValue("@GeoLon", dgvRow.Cells["Dealer.geolon"].Value == DBNull.Value ? "0" : dgvRow.Cells["Dealer.geolon"].Value);
                            sqlCmd.Parameters.AddWithValue("@GeocodingCheckComplete", dgvRow.Cells["Dealer.geocodingcheckcomplete"].Value == DBNull.Value ? "0" : dgvRow.Cells["Dealer.geocodingcheckcomplete"].Value);
                            sqlCmd.Parameters.AddWithValue("@RecordType", dgvRow.Cells["Dealer.recordtype"].Value == DBNull.Value ? "0" : dgvRow.Cells["Dealer.recordtype"].Value);
                            sqlCmd.ExecuteNonQuery();
                            sqlCon.Close();

                        }
                    }
                }
            }
        }
        //private void PopulatedgvDealer()
        //{
        //    using (SqlConnection sqlCon = new SqlConnection(cn))
        //    {
        //        sqlCon.Open();
        //        SqlDataAdapter sqlDa = new SqlDataAdapter("SELECT * FROM DEALER", sqlCon);
        //        DataTable dtbl = new DataTable();
        //        sqlDa.Fill(dtbl);
        //        dgvDealer.DataSource = dtbl;

        //    }
        
        //}
       
    }
};

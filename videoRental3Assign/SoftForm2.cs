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

namespace videoRental3Assign
{
    public partial class SoftForm2 : Form
    {
        private int bookId = 0,select=0;

        SqlConnection sqlconn;

        //write the connection sstring to assthe data form one for to the database 
        String conStr = "Data Source=DESKTOP-L9UGPMH\\SQLEXPRESS;Initial Catalog=Videoassign;Integrated Security=True";

        //command are use to excute the command of isnert , delete , update
        SqlCommand sqlcmd;

        //data reader is used to read thedata from the database table 
        SqlDataReader DReader;


        public SoftForm2()
        {
            InitializeComponent();
        }

        // adding customer details to the database

        private void add_cutomer_Click(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {

            }
            sqlconn = new SqlConnection(conStr);
            sqlconn.Open();
            sqlcmd = new SqlCommand("insert into Client(Name,Email,Mobile,Address)values('"+customer_name.Text+"','"+customer_email.Text+"','"+customer_mobile.Text+"','"+customer_address.Text+"')", sqlconn);
            sqlcmd.ExecuteNonQuery();
            sqlconn.Close();
            MessageBox.Show("Client record Stored ");
            customer_name.Text = "";
            customer_email.Text = "";
            customer_address.Text = "";
            customer_mobile.Text = "";
        }

        // delete customer record from database

        private void delete_customer_Click(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {

            }
            sqlconn = new SqlConnection(conStr);
            sqlconn.Open();
            sqlcmd = new SqlCommand("delete from Client where ClientID="+Convert.ToInt32(customer_ID.Text.ToString())+"", sqlconn);
            sqlcmd.ExecuteNonQuery();
            sqlconn.Close();
            MessageBox.Show("Client record is Removed  ");
            customer_name.Text = "";
            customer_email.Text = "";
            customer_address.Text = "";
            customer_mobile.Text = "";
            customer_ID.Text = "";
        }

        // updating cutomer record form database

        private void update_customer_Click(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {

            }
            sqlconn = new SqlConnection(conStr);
            sqlconn.Open();
            sqlcmd = new SqlCommand("update Client set Name='" + customer_name.Text + "',Email='" + customer_email.Text + "',Mobile='" + customer_mobile.Text + "',Address='" + customer_address.Text + "' where  ClientID=" + Convert.ToInt32(customer_ID.Text.ToString()) + ")", sqlconn);
            sqlcmd.ExecuteNonQuery();
            sqlconn.Close();
            MessageBox.Show("Client record is Updated ");

            customer_name.Text = "";
            customer_email.Text = "";
            customer_address.Text = "";
            customer_mobile.Text = "";
            customer_ID.Text = "";
        }

        // adding video to the database

        private void Video_add_btn_Click(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {

            }
            sqlconn = new SqlConnection(conStr);
            sqlconn.Open();
            sqlcmd = new SqlCommand("insert into video(Name,Ratting,Year,Cost,Copies) values('"+Video_name.Text+"','"+Video_ratting.Text+"','"+Video_year.Text+"','"+Video_cost.Text+"','"+Video_copies.Text+"')", sqlconn);
            sqlcmd.ExecuteNonQuery();
            sqlconn.Close();
            MessageBox.Show("Video record is Stored ");

            Video_copies.Text = "";
            Video_cost.Text = "";
            Video_name.Text = "";
            Video_ratting.Text = "";
            Video_year.Text = "";
            MovieId.Text = "";


        }

        // deleting video from database

        private void delete_video_btn_Click(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {

            }

            sqlconn = new SqlConnection(conStr);
            sqlconn.Open();
            sqlcmd = new SqlCommand("delete from  video where VideoID="+Convert.ToInt32(MovieId.Text)+"", sqlconn);
            sqlcmd.ExecuteNonQuery();
            sqlconn.Close();
            MessageBox.Show("Video record is Removed  ");

            Video_copies.Text = "";
            Video_cost.Text = "";
            Video_name.Text = "";
            Video_ratting.Text = "";
            Video_year.Text = "";
            MovieId.Text = "";

        }

        // updating video from database

        private void video_update_btn_Click(object sender, EventArgs e)
        {
            try {

            }
            catch (Exception ex) { 
            
            }
            sqlconn = new SqlConnection(conStr);
            sqlconn.Open();
            sqlcmd = new SqlCommand("Update  video set Name='" + Video_name.Text + "',Ratting='" + Video_ratting.Text + "',Year='" + Video_year.Text + "',Cost='" + Video_cost.Text + "',Copies='" + Video_copies.Text + "' where VideoID=" + Convert.ToInt32(MovieId.Text) + " )", sqlconn);
            sqlcmd.ExecuteNonQuery();
            sqlconn.Close();
            MessageBox.Show("Video record is Updated ");

            Video_copies.Text = "";
            Video_cost.Text = "";
            Video_name.Text = "";
            Video_ratting.Text = "";
            Video_year.Text = "";
            MovieId.Text = "";

        }

        // fetch cost is function that work according to the year entered in realeased year 

        public int fetchcost(int videoID)
        {

            DataTable tbl = new DataTable();

            sqlconn = new SqlConnection(conStr);

            sqlconn.Open();

            sqlcmd = new SqlCommand("select * from video where VideoID=" + videoID + "", sqlconn);

            DReader = sqlcmd.ExecuteReader();

            tbl.Load(DReader);

            sqlconn.Close();
        
            return Convert.ToInt32(tbl.Rows[0]["Cost"].ToString());

        }

        // issue a movie

            public int chkBooking(int videoID) {
            
            DataTable tbl = new DataTable();

            sqlconn = new SqlConnection(conStr);

            sqlconn.Open();

            sqlcmd = new SqlCommand("select * from rental where VideoID="+videoID+ " and IssuesDt='issues'", sqlconn);

            DReader = sqlcmd.ExecuteReader();

            tbl.Load(DReader);

            sqlconn.Close();

            // next 
            DataTable tblNew = new DataTable();

            sqlconn = new SqlConnection(conStr);

            sqlconn.Open();

            sqlcmd = new SqlCommand("select * from Video where VideoID=" + videoID + "", sqlconn);

            DReader = sqlcmd.ExecuteReader();

            tblNew.Load(DReader);

            sqlconn.Close();

            if (Convert.ToInt32(tblNew.Rows[0]["Copies"].ToString()) > tbl.Rows.Count)
            {
                return 0;
            }
            else {
                return 1;
            }
        }


        public int chkClint(int clientID)
        {

            DataTable tbl = new DataTable();

            sqlconn = new SqlConnection(conStr);

            sqlconn.Open();

            sqlcmd = new SqlCommand("select * from rental where CustomerID=" + clientID + " and IssuesDt='issues'", sqlconn);

            DReader = sqlcmd.ExecuteReader();

            tbl.Load(DReader);

            sqlconn.Close();

            if(tbl.Rows.Count<2)
            {
                return 0;
            }
            else
            {
                return 1;
            }
        }


        private void movie_issue_Click(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {

            }

            if (chkClint(Convert.ToInt32(customer_ID.Text.ToString())) == 0)
            {
                if (chkBooking(Convert.ToInt32(MovieId.Text.ToString())) == 0) {

                    sqlconn = new SqlConnection(conStr);
                    sqlconn.Open();

                    sqlcmd = new SqlCommand("insert into rental(VideoID,CustomerID,IssuesDt,ReturnDt) values(" + Convert.ToInt32(MovieId.Text) + "," + Convert.ToInt32(customer_ID.Text) + ",'" + issueDt.Text + "','issues' )", sqlconn);
                    sqlcmd.ExecuteNonQuery();
                    sqlconn.Close();
                    MessageBox.Show("Video is Booked by the client ");

                    Video_copies.Text = "";
                    Video_cost.Text = "";
                    Video_name.Text = "";
                    Video_ratting.Text = "";
                    Video_year.Text = "";
                    MovieId.Text = "";

                    customer_address.Text = "";
                    customer_email.Text = "";
                    customer_email.Text = "";
                    customer_ID.Text = "";
                    customer_mobile.Text = "";
                    customer_name.Text = "";


                }
                else {
                    MessageBox.Show("No more smples ");
                }

            }
            else {
                MessageBox.Show("You hve reach the limit ");
            }
            

        }

        private void delete_movie_Click(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {

            }

            sqlconn = new SqlConnection(conStr);
            sqlconn.Open();
            sqlcmd = new SqlCommand("delete from rental where  rentID="+bookId+"", sqlconn);
            sqlcmd.ExecuteNonQuery();
            sqlconn.Close();
            MessageBox.Show("issued video Record is Removed ");

            Video_copies.Text = "";
            Video_cost.Text = "";
            Video_name.Text = "";
            Video_ratting.Text = "";
            Video_year.Text = "";
            MovieId.Text = "";

            customer_address.Text = "";
            customer_email.Text = "";
            customer_email.Text = "";
            customer_ID.Text = "";
            customer_mobile.Text = "";
            customer_name.Text = "";


        }

        private void return_movie_Click(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {

            }



            DateTime current_date = DateTime.Now;

            //convert the old date from string to Date fromat
            DateTime prev_date = Convert.ToDateTime(issueDt.Text);


            //get the difference in the days fromat
            String Daysdiff = (current_date - prev_date).TotalDays.ToString();


            // calculate the round off value 
            Double DaysInterval = Math.Round(Convert.ToDouble(Daysdiff));


            int total = fetchcost(Convert.ToInt32(MovieId.Text)) * Convert.ToInt32(DaysInterval);




            sqlconn = new SqlConnection(conStr);
            sqlconn.Open();
            sqlcmd = new SqlCommand("update rental set VideoID=" + Convert.ToInt32(MovieId.Text) + ",CustomerID=" + Convert.ToInt32(customer_ID.Text) + ",IssuesDt='" + issueDt.Text + "',ReturnDt='"+returnDt.Text+ "' where  rentID=" + bookId + "", sqlconn);
            sqlcmd.ExecuteNonQuery();
            sqlconn.Close();
            MessageBox.Show("issued video Record is Returned and BIll is =$"+total);

            Video_copies.Text = "";
            Video_cost.Text = "";
            Video_name.Text = "";
            Video_ratting.Text = "";
            Video_year.Text = "";
            MovieId.Text = "";

            customer_address.Text = "";
            customer_email.Text = "";
            customer_email.Text = "";
            customer_ID.Text = "";
            customer_mobile.Text = "";
            customer_name.Text = "";


        }

        private void Video_year_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DateTime Now = DateTime.Now;

                int presntyear =Now.Year;

                int diffYear = presntyear - Convert.ToInt32(Video_year.Text);
                int cost = 0;
                // MessageBox.Show(diff.ToString());
                if (diffYear >= 5)
                {
                    cost = 2;
                }
                if (diffYear >= 0 && diffYear < 5)
                {
                    cost = 5;
                }

                Video_cost.Text = cost.ToString();
            }
            catch (Exception ex) { 
            
            }
        }

        private void video_data_Click(object sender, EventArgs e)
        {
            select = 1;

            DataTable tbl = new DataTable();

            sqlconn = new SqlConnection(conStr);

            sqlconn.Open();

            sqlcmd = new SqlCommand("select * from Video ", sqlconn);

            DReader = sqlcmd.ExecuteReader();

            tbl.Load(DReader);

            sqlconn.Close();
            data_grid.DataSource = tbl;

        }

        private void custmer_data_Click(object sender, EventArgs e)
        {
            select = 2;
            DataTable tbl = new DataTable();

            sqlconn = new SqlConnection(conStr);

            sqlconn.Open();

            sqlcmd = new SqlCommand("select * from client", sqlconn);

            DReader = sqlcmd.ExecuteReader();

            tbl.Load(DReader);

            sqlconn.Close();
            data_grid.DataSource = tbl;

        }

        private void data_grid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (select == 1) {
                //video
                MovieId.Text = data_grid.CurrentRow.Cells[0].Value.ToString();
                Video_name.Text = data_grid.CurrentRow.Cells[1].Value.ToString();
                Video_ratting.Text = data_grid.CurrentRow.Cells[2].Value.ToString();
                Video_year.Text = data_grid.CurrentRow.Cells[3].Value.ToString();
                Video_cost.Text = data_grid.CurrentRow.Cells[4].Value.ToString();
                Video_copies.Text = data_grid.CurrentRow.Cells[5].Value.ToString();
            }
            if (select==2) { 
            //customer
            customer_ID.Text = data_grid.CurrentRow.Cells[0].Value.ToString();
            customer_name.Text = data_grid.CurrentRow.Cells[1].Value.ToString();
                customer_email.Text = data_grid.CurrentRow.Cells[2].Value.ToString();
                customer_mobile.Text = data_grid.CurrentRow.Cells[3].Value.ToString();
                customer_address.Text = data_grid.CurrentRow.Cells[4].Value.ToString();

            }

            if (select == 3)
            {
                //rentl
                bookId= Convert.ToInt32(data_grid.CurrentRow.Cells[0].Value.ToString());
                MovieId.Text = data_grid.CurrentRow.Cells[1].Value.ToString();
                customer_ID.Text = data_grid.CurrentRow.Cells[2].Value.ToString();
                issueDt.Text = data_grid.CurrentRow.Cells[3].Value.ToString();

            }
            select = 0;

        }

        private void best_movie_Click(object sender, EventArgs e)
        {
        

            int x = 0, y = 0, cunt = 0;
            String Title = "";
            
            DataTable tblvideo = new DataTable();

            sqlconn = new SqlConnection(conStr);

            sqlconn.Open();

            sqlcmd = new SqlCommand("select * from Video", sqlconn);

            DReader = sqlcmd.ExecuteReader();

            tblvideo.Load(DReader);

            sqlconn.Close();


            for (x = 0; x < tblvideo.Rows.Count; x++)
            {
                DataTable tblrentl = new DataTable();

                sqlconn = new SqlConnection(conStr);

                sqlconn.Open();

                sqlcmd = new SqlCommand("select * from Rental where VideoID="+Convert.ToInt32(tblvideo.Rows[x]["VideoID"])+"", sqlconn);

                DReader = sqlcmd.ExecuteReader();

                tblrentl.Load(DReader);

                sqlconn.Close();
                if (tblrentl.Rows.Count>cunt) {

                    Title = tblvideo.Rows[x]["Name"].ToString();
                    cunt = tblrentl.Rows.Count;

                }

            }


            MessageBox.Show("Best Video is ==" + Title);



        }

        private void best_customer_Click(object sender, EventArgs e)
        {


            int x = 0, y = 0, cunt = 0;
            String Title = "";

            DataTable tblvideo = new DataTable();

            sqlconn = new SqlConnection(conStr);

            sqlconn.Open();

            sqlcmd = new SqlCommand("select * from Client", sqlconn);

            DReader = sqlcmd.ExecuteReader();

            tblvideo.Load(DReader);

            sqlconn.Close();


            for (x = 0; x < tblvideo.Rows.Count; x++)
            {
                DataTable tblrentl = new DataTable();

                sqlconn = new SqlConnection(conStr);

                sqlconn.Open();

                sqlcmd = new SqlCommand("select * from Rental where CustomerID=" + Convert.ToInt32(tblvideo.Rows[x]["ClientID"]) + "", sqlconn);

                DReader = sqlcmd.ExecuteReader();

                tblrentl.Load(DReader);

                sqlconn.Close();
                if (tblrentl.Rows.Count > cunt)
                {

                    Title = tblvideo.Rows[x]["Name"].ToString();
                    cunt = tblrentl.Rows.Count;

                }

            }


            MessageBox.Show("Best Client  is ==" + Title);

        }

        private void data_grid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (select == 1)
            {
                //video
                MovieId.Text = data_grid.CurrentRow.Cells[0].Value.ToString();
                Video_name.Text = data_grid.CurrentRow.Cells[1].Value.ToString();
                Video_ratting.Text = data_grid.CurrentRow.Cells[2].Value.ToString();
                Video_year.Text = data_grid.CurrentRow.Cells[3].Value.ToString();
                Video_cost.Text = data_grid.CurrentRow.Cells[4].Value.ToString();
                Video_copies.Text = data_grid.CurrentRow.Cells[5].Value.ToString();
            }
            if (select == 2)
            {
                //customer
                customer_ID.Text = data_grid.CurrentRow.Cells[0].Value.ToString();
                customer_name.Text = data_grid.CurrentRow.Cells[1].Value.ToString();
                customer_email.Text = data_grid.CurrentRow.Cells[2].Value.ToString();
                customer_mobile.Text = data_grid.CurrentRow.Cells[3].Value.ToString();
                customer_address.Text = data_grid.CurrentRow.Cells[4].Value.ToString();

            }

            if (select == 3)
            {
                //rentl
                bookId = Convert.ToInt32(data_grid.CurrentRow.Cells[0].Value.ToString());
                MovieId.Text = data_grid.CurrentRow.Cells[1].Value.ToString();
                customer_ID.Text = data_grid.CurrentRow.Cells[2].Value.ToString();
                issueDt.Text = data_grid.CurrentRow.Cells[3].Value.ToString();

            }
            select = 0;


        }

        private void rental_data_Click(object sender, EventArgs e)
        {
            select = 3;
            DataTable tbl = new DataTable();

            sqlconn = new SqlConnection(conStr);

            sqlconn.Open();

            sqlcmd = new SqlCommand("select * from Rental ", sqlconn);

            DReader = sqlcmd.ExecuteReader();

            tbl.Load(DReader);

            sqlconn.Close();
            data_grid.DataSource = tbl;

        }
    }
}

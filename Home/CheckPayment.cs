using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home
{
    class CheckPayment
    {
        SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Asus\OneDrive\Forcus\FO-GYM-Managment-System\Database\Gym.mdf;Integrated Security=True;Connect Timeout=30");

        public int Check(string Cid)
        {
            int res = 0;
            int month = DateTime.Now.Month;



            string R1month = Switch(month + 1);
            string R2month = Switch(month + 2);



            conn.Open();

            string payqry = "UPDATE Payments SET "+ R1month + " = '', "+ R2month + " = ''  where CardID = '" + Cid + "' OR EMPID = '" + Cid + "'";
            SqlCommand cmdpay = new SqlCommand(payqry, conn);
            cmdpay.ExecuteNonQuery();


            string payqry2 = "UPDATE PaymentFee SET " + R1month + " = '0.00', " + R2month + " = '0.00'  where CardID = '" + Cid + "' OR EMPID = '" + Cid + "'";
            SqlCommand cmdpay2 = new SqlCommand(payqry2, conn);
            cmdpay2.ExecuteNonQuery();






            string Cmonth = Switch(month);   

            string Checkqry = "SELECT "+Cmonth+" FROM Payments where CardID = '" + Cid + "' OR EMPID = '" + Cid + "'";
            SqlCommand Checkcmd = new SqlCommand(Checkqry, conn);
            SqlDataReader reader = Checkcmd.ExecuteReader();
            reader.Read();

            DateTime CheckNull = Convert.ToDateTime(reader[Cmonth]);

            if (CheckNull >= DateTime.Now.AddMonths(-1))
            {

                res = 1;
                Form_Alert fa = new Form_Alert();
                fa.Show();


                reader.Close();
                return res;
            }
            else
            {

                reader.Close();
               // int month = DateTime.Now.Month;

                
                string CPmonth = Switch(month - 1);


                string CheckPMqry = "SELECT " + CPmonth + " FROM Payments where CardID = '" + Cid + "' OR EMPID = '" + Cid + "'";
                SqlCommand CheckPMcmd = new SqlCommand(CheckPMqry, conn);
                SqlDataReader ABreader = CheckPMcmd.ExecuteReader();
                if (ABreader.Read())
                {

                    DateTime paidDate = Convert.ToDateTime(ABreader[CPmonth]);

                    

                    //var date = DateTime.Now.Date - paidDate;
                    DateTime expdate = paidDate.AddMonths(1).AddDays(7);




                    if (expdate >= DateTime.Now)
                    {
                        res = 2;
                        Warning wa = new Warning();
                        wa.Show();
                        return res;
                    }
                    else
                    {
                        res = 3;
                        Danger da = new Danger();
                        da.Show();
                        return res;
                    }

                    //MessageBox.Show(" "+date);


                }
                else
                {

                    string CP2month = Switch(month - 2);


                    string CheckPM2qry = "SELECT " + CP2month + " FROM Payments where CardID = '" + Cid + "' OR EMPID = '" + Cid + "'";
                    SqlCommand CheckPM2cmd = new SqlCommand(CheckPM2qry, conn);
                    SqlDataReader AB2reader = CheckPM2cmd.ExecuteReader();
                    if (AB2reader.Read())
                    {
                        res = 3;
                        Danger da = new Danger();
                        da.Show();
                        return res;

                    }


                }

                res = 0;
                return res;


            }

         

            conn.Close();




        }












       //Switch Function

        string Rmonth;
        public string Switch(int month)
        {
            Rmonth = null;


            switch (month)
            {
                case 1:
                    Rmonth = "January";
                    break;
                case 2:
                    Rmonth = "February";
                    break;
                case 3:
                    Rmonth = "March";
                    break;
                case 4:
                    Rmonth = "April";
                    break;
                case 5:
                    Rmonth = "May";
                    break;
                case 6:
                    Rmonth = "June";
                    break;
                case 7:
                    Rmonth = "July";
                    break;
                case 8:
                    Rmonth = "August";
                    break;
                case 9:
                    Rmonth = "September";
                    break;
                case 10:
                    Rmonth = "October";
                    break;
                case 11:
                    Rmonth = "November";
                    break;
                case 12:
                    Rmonth = "December";
                    break;
                default:
                    Rmonth = "dec";
                    break;


            }


            return Rmonth;
        }





    }
}

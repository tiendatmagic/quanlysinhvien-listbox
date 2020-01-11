using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.SqlClient;
using System.Configuration;
using System.Data.Sql;
using System.Data;

namespace Quanlysinhvien
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>                                                                               2
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Btnketnoi_Click(object sender, RoutedEventArgs e)
        {
            try

            {

                List<Khoa> khoa = new List<Khoa>();

                List<SinhVien> sinhvien = new List<SinhVien>();

                string connectionString =

                       ConfigurationManager.ConnectionStrings["QLSV"].ConnectionString;

                using (SqlConnection connection = new SqlConnection(connectionString))

                using (SqlCommand command = new SqlCommand("SELECT MaKhoa, TenKhoa FROM Khoa;" +

                               "SELECT MaSV, TenSV, Email, MaKhoa FROM SinhVien;",

                                connection))

                {

                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())

                    {

                        //xử lý tập dữ liệu từ bảng Khoa

                        while (reader.Read())

                        {

                            var kh = new Khoa();

                            kh.MaKhoa = reader.GetString(0);

                            kh.TenKhoa = reader.GetString(1);

                            khoa.Add(kh);

                        }

                        //di chuyển đến tập dữ liệu từ bảng SinhVien

                        reader.NextResult();

                        // xử lý tập dữ liệu từ bảng SinhVien

                        while (reader.Read())

                        {

                            var sv = new SinhVien();

                            sv.MaSV = reader.GetString(0);

                            sv.TenSV = reader.GetString(1);

                            sv.Email = reader.GetString(2);

                            sv.MaKhoa = reader.GetString(3);

                            sinhvien.Add(sv);

                        }

                    }

                }

                MessageBox.Show("Mo va dong co so du lieu thanh cong.");

                MessageBox.Show("Du lieu tu bang Khoa:");

                foreach (Khoa kh in khoa)
                {

                    string sFormat = String.Format("Ma Khoa:{0} Ten Khoa: {1}",

                                   kh.MaKhoa, kh.TenKhoa);
                    KhoaList.Items.Add(sFormat);
                    KhoaListt.ItemsSource = khoa;


                }

                MessageBox.Show("Du lieu tu bang SinhVien:");

                foreach (SinhVien sv in sinhvien)

                {

                    string sFormat = String.Format("Ma Sinh Vien:{0} Ten Sinh Vien: {1}  Email: {2} Ma Khoa: {3} ",

                                sv.MaSV, sv.TenSV, sv.Email, sv.MaKhoa);

                    KhoaList.Items.Add(sFormat);
                    KhoaListt.ItemsSource = sinhvien;

                }

            }

            catch (Exception ex)

            {

                MessageBox.Show("Loi khi mo  ket noi:" + ex.Message);

            }

        }

















        /**/
        public string GetPersonName(int MaSV)

        {

            string connectionString = ConfigurationManager.ConnectionStrings["QLSV"]?.ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))

            using (SqlCommand command = new SqlCommand(

              "SELECT TenSV FROM SinhVien WHERE MaSV = @MaSV", connection))

            {

                command.Parameters.Add("MaSV", SqlDbType.NChar, 10).Value = MaSV;

                connection.Open();

                object result = command.ExecuteScalar();

                string TenSV = null;

                if (result != DBNull.Value)

                {

                    TenSV = (string)result;

                }

                return TenSV;

            }

        }

        public static int InsertData(Khoa khoa)

        {

            try

            {

                string connectionString =

                       ConfigurationManager.ConnectionStrings["QLSV"].ConnectionString;

                using (SqlConnection connection = new SqlConnection(connectionString))

                using (SqlCommand command = new SqlCommand("INSERT INTO Khoa(MaKhoa,TenKhoa)" +

                           "VALUES(@MaKhoa,@TenKhoa)", connection))

                {

                    command.Parameters.Add("MaKhoa", SqlDbType.NChar, 10).Value = khoa.MaKhoa;

                    object dbTenKhoa = khoa.TenKhoa;

                    if (dbTenKhoa == null)

                    {

                        dbTenKhoa = DBNull.Value;

                    }

                    command.Parameters.Add("TenKhoa", SqlDbType.NVarChar, 50).Value = dbTenKhoa;

                    connection.Open();

                    return command.ExecuteNonQuery();

                }

            }

            catch (Exception ex)

            {

                MessageBox.Show("Loi khi mo  ket noi:" + ex.Message);

                return -1;

            }

        }

        public static int UpdateData(Khoa khoa)

        {

            try

            {

                string connectionString =

                     ConfigurationManager.ConnectionStrings["QLSV"].ConnectionString;

                using (SqlConnection connection = new SqlConnection(connectionString))

                using (SqlCommand command = new SqlCommand("UPDATE Khoa " +

                              "SET TenKhoa = @TenKhoa " +

                              "WHERE MaKhoa = @MaKhoa",

                              connection))

                {

                    command.Parameters.Add("MaKhoa", SqlDbType.NChar, 10).Value = khoa.MaKhoa;

                    command.Parameters.Add("TenKhoa", SqlDbType.NVarChar, 50).Value = khoa.TenKhoa;

                    connection.Open();

                    return command.ExecuteNonQuery();

                }
            }

            catch (Exception ex)

            {

                MessageBox.Show("Loi khi mo  ket noi:" + ex.Message);

                return -1;

            }

        }

        public static int DeleteData(Khoa khoa)

        {

            try

            {
                string connectionString =

                      ConfigurationManager.ConnectionStrings["QLSV"].ConnectionString;

                using (SqlConnection connection = new SqlConnection(connectionString))

                using (SqlCommand command = new SqlCommand("DELETE FROM Khoa" +

                       "WHERE MaKhoa = @MaKhoa",

                      connection))

                {

                    command.Parameters.Add("MaKhoa", SqlDbType.NChar, 10).Value = khoa.MaKhoa;

                    connection.Open();

                    return command.ExecuteNonQuery();

                }
            }

            catch (Exception ex)

            {

                MessageBox.Show("Loi khi mo  ket noi:" + ex.Message);

                return -1;

            }

        }




    }
}

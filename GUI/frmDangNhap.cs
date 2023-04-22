using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO;
using BLL;
namespace GUI
{
    public partial class frmDangNhap : Form
    {
        TaiKhoan taiKhoan = new TaiKhoan();
        TaiKhoanBLL taiKhoanBLL = new TaiKhoanBLL();
        public frmDangNhap()
        {
            InitializeComponent();
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            taiKhoan.sTaiKhoan = txtTaiKhoan.Text;
            taiKhoan.sMatKhau = txtMatKhau.Text;

            string getUser = taiKhoanBLL.CheckLogin(taiKhoan);
            switch(getUser)
            {
                case "required_taikhoan":
                    {
                        MessageBox.Show("Tài khoản ko đc để trống!");
                        return;
                    }
                case "required_matkhau":
                    {
                        MessageBox.Show("Mật khẩu ko đc để trống!");
                        return;
                    }
                case "Tài khoản và mật khẩu không chính xác!":
                    {
                        MessageBox.Show("Tài khoản và mật khẩu không chính xác!");
                        return;
                    }
            }
            MessageBox.Show("Đăng nhập thành công!");

        }
    }
}

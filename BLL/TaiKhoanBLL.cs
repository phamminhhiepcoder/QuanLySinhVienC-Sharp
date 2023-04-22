using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;
namespace BLL
{
    public class TaiKhoanBLL
    {
        TaiKhoanAccess taiKhoanAccess = new TaiKhoanAccess();
        public string CheckLogin(TaiKhoan taikhoan)
        {
            if(taikhoan.sTaiKhoan == "")
            {
                return "required_taikhoan";
            } 
            if(taikhoan.sMatKhau == "")
            {
                return "required_password";
            }
            string info = taiKhoanAccess.CheckLogin(taikhoan);
            return info;
        }

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using MySql.Data.MySqlClient;

namespace supply_management.Controller
{
    class userAccount : Model.Users
    {
        Controller.ErrorHandler error = new Controller.ErrorHandler();
        public void userCred(String username, String password, Form1 suspend)
        {
            this.userLogin(username, password, suspend);     
        }

        public void employeeCredentials(String Id, TextBox[] cred, ComboBox[] options)
        {

                bool isNumber = error.checkNum(cred[6].Text);

                if(isNumber == true)
                {
                    foreach (TextBox txt in cred)
                    {
                        if (string.IsNullOrEmpty(txt.Text))
                        {
                            MessageBox.Show("please fill all empty fields");
                            break;
                        }
                        else
                        {
                            this.EmpCredential(Id, cred, options);
                            break;
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Age will be a number", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
        }
        
        public BindingSource loadDataView()
        {
            return this.loadData();
        }
        
        public String getPass(String username)
        {
            return this.getPassword(username);
        }

        public void changePass(String username, String password)
        {
            this.ChangePassword(username, password);
        }

        public void DelCashier(String id, frmEmployeeReg clear)
        {
            this.DeleteCashier(id, clear);
        }
        public MySqlDataReader getuserData(String username)
        {
            return this.returnData(username);
        }

        public String duplicated(TextBox[] cred)
        {
            return this.ifExist(cred);
        }

        public void isDelete(String id, Form1 frm, Main main)
        {
            this.Delete(id, frm, main);
        }
       
    }
}

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
        
        public void update(String id, TextBox[] text, ComboBox[] combo, EmployeeReg suspend)
        {
            bool isNumber = error.checkNum(text[6].Text);

            if(isNumber == true)
            {
                this.UpdateData(id, text, combo, suspend);            
            }
            else
            {
                MessageBox.Show("Age will be a number", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public DataTable search(String query)
        {
            return this.searchData(query);
        }

        public String duplicated(TextBox[] cred)
        {
            return this.ifExist(cred);
        }

        public void isDelete(String id, EmployeeReg suspend)
        {
            this.Delete(id, suspend);
        }
        
        public object countRegistered()
        {
            return this.countUsers();
        }

    }
}

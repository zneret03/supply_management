using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace supply_management.Controller
{
    class BrandController : Model.Brand
    {
        public BindingSource getData()
        {
            return this.loadData();
        }

        public void setData(TextBox text)
        {
            if(string.IsNullOrEmpty(text.Text))
            {
                MessageBox.Show("Please fill empty field", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {

                if (text.Text == this.isExist(text))
                {
                    MessageBox.Show("Brand name already exist please try another one", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    this.insert(text);
                }
            
            }

        }

        public void updateData(TextBox text, Label Id, addBrand suspend)
        {
            this.update(text, Id, suspend);
        }

        public void isDelete(Label Id, addBrand suspend)
        {
            this.Delete(Id, suspend);
        }

        public DataTable getDataSearch(String text)
        {
            return this.search(text);
        }
    }
}

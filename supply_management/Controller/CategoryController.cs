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
    class CategoryController : Model.Category
    {
        public BindingSource loadCategory()
        {
            return this.fetchCategory();
        }

        public void getData(TextBox category)
        {

            if(string.IsNullOrEmpty(category.Text))
            {
                MessageBox.Show("Please fill empty field","Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
               if(category.Text ==  this.isDuplicate(category))
               {
                   MessageBox.Show("Category is already existed try another one", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
               }
               else
               {
                   this.setData(category);
               }
            }
            
        }

        public void update(Label Id, TextBox category, addCategory suspend)
        {
            this.updateCategory(Id, category, suspend);
        }

        public void isDelete(Label Id, addCategory suspend)
        {
            this.DeleteCategory(Id, suspend);
        }


        public DataTable search(String search)
        {
            return this.searchData(search);
        }
    }
}

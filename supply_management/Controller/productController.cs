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
    class productController : Model.product
    {
        Controller.ErrorHandler error = new Controller.ErrorHandler();
      
        public BindingSource loadDataGrid()
        {
            return this.loadTable();
        }

        public DataTable searchData(String text)
        {
            return this.search(text);
        }

        public void loadCombo(ComboBox category)
        {
             this.loadCategory(category);
        }

        public void loadBra(ComboBox brand)
        {
            this.loadBrand(brand);
        }

        public String seletedId(String selected)
        {
           return this.getSelectedId(selected);
        }

        public String seletedIdBrand(String selected)
        {
            return this.getSelectedIdBrand(selected);
        }

        public String isDuplicate(TextBox[] duplicate)
        {
            return this.isExist(duplicate);
        }


        public void insertProduct(String category_id, String brand_id, TextBox[] productCred, int textGain, addProducts suspend)
        {
            bool isNumeric = error.checkNum(productCred[3].Text);
            bool isDecimal = error.isDecimal(productCred[4].Text);

                if (isDecimal == true)
                {
                    if (isNumeric == true)
                    {
                        foreach (TextBox txt in productCred)
                        {
                            if (string.IsNullOrEmpty(txt.Text))
                            {
                                MessageBox.Show("Please fill all blank fields try again", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                break;
                            }
                            else
                            {

                                this.insert(category_id, brand_id, productCred, textGain, suspend);
                                break;
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Quantity should be numeric please try again", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Price must be Numeric please try again", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            
              
        }

        public void isDelete(String id, addProducts suspend)
        {
            this.Delete(id, suspend);
        }

        public void isUpdate(String category_id, String brand_id, TextBox[] productCred, String id, int txtGain, addProducts suspend)
        {
            this.Update(category_id, brand_id, productCred, id, txtGain, suspend);
        }

        public object count()
        {
            return this.countProducts();
        }
          
    }
}

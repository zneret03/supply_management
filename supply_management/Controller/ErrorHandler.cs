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
    class ErrorHandler
    {
        //Check if number or not for age
        public bool checkNum(String cred)
        {
            
            bool isNumber = Regex.IsMatch(cred, @"(?:100|[1-9]?[0-9])$");
            if (isNumber == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool isDecimal(String num)
        {
            bool isDouble = Regex.IsMatch(num, @"-?\d+(?:\.\d+)?");
            if(isDouble == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public String GenerateNumber(int length)
        {
            String random = string.Empty;
            Random rand = new Random();
            for (int i = 0; i < length; i++)
            {
                random = String.Concat(random, rand.Next(10).ToString());
            }

            return random;
        }
    }
}

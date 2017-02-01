using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CodeTest
{
    class InputValidator
    {
        private List<String[]> records;

        public InputValidator(List<String[]> records)
        {
            this.records = records;
        }

        public Boolean validateIndex(int index, int size)
        {
            if (index >= 0)
            {
                if (index < size)
                {
                    return true;
                }
            }
            MessageBox.Show("Invalid index in database");
            return false;
        }

        public Boolean IDisFree(int id)
        {
            //Take in an employee ID and search the ID column in the database 
            //If the ID is not found return true, else return false
            Boolean id_free = true;
            String idString = id.ToString();
            foreach (String[] record in records)
            {
                String idToTest = record[0];
                if (idString.Equals(idToTest, StringComparison.OrdinalIgnoreCase))
                {
                    MessageBox.Show("Employee Not Registered: Id already exists");
                    id_free = false;
                    break;
                }
            }
            return id_free;
        }

        public Boolean validateID(String input)
        {
            //check to see if salary is really a number
            try
            {
                int num = int.Parse(input);
            }
            catch (FormatException)
            {
                MessageBox.Show("Invalid ID input, whole numbers only");
                return false;
            }
            return true;
        }

        public Boolean maritialstateIsValid(String maritialstate)
        {
            switch (maritialstate)
            {
                case "divorced":
                case "widowed":
                case "single":
                case "married":
                    return true;
                default:
                    MessageBox.Show("Invalid Marriage status input");
                    return false;
            }
        }

        public Boolean validateSalary(String input)
        {
            //check to see if salary is really a number
            try
            {
                float num = float.Parse(input);
            }
            catch (FormatException)
            {
                MessageBox.Show("Invalid salary input, numbers only");
                return false;
            }
            return true;
        }

        public List<String[]> Records
        {
            get
            {
                return records;
            }
            set
            {
                records = value;
            }
        }
    }
}

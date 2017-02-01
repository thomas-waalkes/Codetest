using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CodeTest
{
    class newEmployeeTab
    {
        private List<String[]> records;
        private InputValidator v;
        public newEmployeeTab(List<String[]> records, InputValidator v)
        {
            this.records = records;
            this.v = v;
        }
        public List<String[]> resgisterEmployee(int id, string name, string dateofbirth, string maritialstate, float salary, string address)
        {
            //run through and validate the input info before making the employee 
            if (v.IDisFree(id))
            {
                if (nameIsFree(name))
                {
                    if (v.maritialstateIsValid(maritialstate))
                    {
                        MessageBox.Show("Employee Registered Successfully");
                        Employee e = new Employee(id, name, dateofbirth, maritialstate, salary, address);
                        String eInfo = e.ToString();
                        records.Add(eInfo.Split(','));
                        return records;
                    }
                }
            }
            return records;
        }

        //Same idea as IDisFree but with the name column
        private Boolean nameIsFree(String name)
        {
            Boolean name_free = true;
            foreach(String[] record in records)
            {
                if(name.Equals(record[1], StringComparison.OrdinalIgnoreCase))
                {
                    MessageBox.Show("Employee Not Registered: Name already exists");
                    name_free = false;
                    break;
                }
            }
            return name_free;
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

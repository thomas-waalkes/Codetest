using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeTest
{
    class TabManager
    {
        newEmployeeTab e;
        RecordManager s;
        InputValidator v; 
        Boolean loginSuccess;
        private List<String[]> records;
        public TabManager(Boolean loginSuccess)
        {
            this.loginSuccess = loginSuccess;
            if (loginSuccess)
            {
                records = GetRecords();
                this.v = new InputValidator(records);
            }
        }

        public void makeTabs()
        {
            if (loginSuccess)
            {
                e = new newEmployeeTab(records, v);
                s = new RecordManager(records, v);
            }
        }

        public void registerEmployee(int id, string name, string dateofbirth, string maritialstate, float salary, string address)
        {
            //Delegate the method call and get back an updated version of records
            //Then pass it onto the other tab
            List<String[]> r = e.resgisterEmployee(id, name, dateofbirth,  maritialstate, salary, address);
            if (r != null)
            {
                updateRecords(r);
            }
        }

        public void deleteRecord(int id)
        {
            List<String[]> r =   s.deleteRecord(id);
            if (r != null)
            {
                updateRecords(r);
            }

        }

        public void changeRecord(int index, String column, String input)
        {
            List<String[]> r = s.changeRecord(index, column, input);
        }

        public void printAllRecords()
        {
            s.printRecords();
        }
        //Search all name columns and print any matches ignoring case 
        public string[] searchName(String name)
        {
            //Returns all matched IDs
            return s.searchName(name);
        }

        public string[] searchMarriedState(String state)
        {
            //Returns all matched IDs 
            return s.searchMarriedState(state);
        }

        //Put updates to records all in one place to make no one gets missed
        //And they're all synced 
        private void updateRecords(List<String[]> r)
        {
            records = r;
            e.Records = r;
            s.Records = r;
            v.Records = r;
        }

        public void exportRecordsToCSV()
        {
            s.exportRecordsToCSV();
        }

        public List<string[]> GetRecords()
        {
            try { 
                    StreamReader rd = new StreamReader("../../DataFile.txt");
                    //This line cause the File reader to jump to EoF and not read in anything 
                    //So I commented it out and my other code started working! 
                    // Console.WriteLine(rd.ReadToEnd());
                    string[] records = rd.ReadToEnd().Split('\n');
                    List<string[]> EmployeeList = new List<string[]>();
                    Console.WriteLine(rd.ReadToEnd());

                    foreach (string record in records)
                    {
                        EmployeeList.Add(record.Split(','));
                    }
                System.Windows.Forms.MessageBox.Show("Employee Database loaded Successfully");
                return EmployeeList;
            }
            catch(FileNotFoundException f)
            {
                System.Windows.Forms.MessageBox.Show("Error: Employee Data File not found");
                return null;
            }

        }
    }
}


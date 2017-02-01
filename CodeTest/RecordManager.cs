using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CodeTest
{
    class RecordManager
    {
        private List<String[]> records;
        private InputValidator v;
        public RecordManager(List<String[]> records, InputValidator v)
        {
            this.records = records;
            this.v = v;
        }

        public void printRecords()
        {
            foreach(String[] record in records)
            {
                String output = String.Join(", ", record);
                Console.Write(output);
                Console.WriteLine();
            }
            MessageBox.Show("Records Printed");
        }

        public void exportRecordsToCSV()
        {
            String filePath = @"C:\records.csv";
            StringBuilder sb = new StringBuilder();
            String delimiter = ", ";
            foreach (string[] row in records)
            {
                for (int i = 0; i < row.Length; i++) {
                    //check to see if its the last index, if yes then don't add the delimiter
                    if (i == row.Length-1)
                    {
                        //end of the line
                        sb.Append(row[i]);
                    }
                    else
                    {
                        sb.Append(row[i] + delimiter);
                    }
                }
                sb.Append('\n');
            }
            File.WriteAllText(filePath, sb.ToString());
            MessageBox.Show("Records Successfully exported to " + filePath);
        }

        public List<String[]> deleteRecord(int id)
        { int index = 0;
           foreach(String[] record in records)
            {
                int idFound = int.Parse(record[0]);
                if (id == idFound)
                {
                    //Break because Ids are unique
                    records.RemoveAt(index);
                    break;
                }
                index++;
            }

            return records;
        }

        public List<String[]> changeRecord(int index, String column, String input )
        {
            if (v.validateIndex(index, records.Count))
            {
                String[] entryToChange = records[index];
                switch (column)
                {
                    case "ID":
                        if (v.validateID(input))
                        {
                            if (v.IDisFree(int.Parse(input)))
                            {
                                entryToChange = updateID(entryToChange, input);
                            }
                        }
                        displaySuccess(column, index, input);
                        return records;
                    case "name":
                        entryToChange = updateName(entryToChange, input);
                        displaySuccess(column, index, input);
                        return records;
                    case "birthdate":
                        entryToChange = updateMaritalState(entryToChange, input);
                        displaySuccess(column, index, input);
                        return records; 
                    case "maritalState":
                        if (v.maritialstateIsValid(input))
                        {
                            entryToChange = updateMaritalState(entryToChange, input);
                            displaySuccess(column, index, input);
                        }
                        return records;
                    case "salary":
                        if (v.validateSalary(input))
                        {
                            entryToChange = updateSalary(entryToChange, input);
                            displaySuccess(column, index, input);
                        }
                        return records;
                    case "address":
                        entryToChange = updateAddress(entryToChange, input);
                        records.RemoveAt(index);
                        records.Insert(index, entryToChange);
                        displaySuccess(column, index, input);
                        return records;
                    default:
                        MessageBox.Show("Invalid column flag");
                        return records;
                }
            }
            return records;
        }
        public string[] updateID(String[] row, String input)
        {
            row[0] = input;
            return row;
        }

        public string[] updateName(String[] row, String input)
        {
            row[1] = input;
            return row;
        }

        public String[] updateBirthDay(String[] row, String input)
        {
            row[2] = input;
            return row;
        }

        public String[] updateMaritalState(String[] row, String input)
        {
            row[3] = input;
            return row;
        }

        public String[] updateSalary(String[] row, String input)
        {
            row[4] = input.ToString();
            return row;
        }

        public String[] updateAddress(String[] row, string input)
        {
            row[5] = input;
            return row;
        }

        public void displaySuccess(String column, int index, String input)
        {
            index++;
            MessageBox.Show("Updated "+column+ " to "+input+" at ID: " + index.ToString());
        }

        public String[] searchName(String name)
        {
            //Take a name and foreach match print the whole row
            String[] ids = new String[10];
            int index = 0;
            foreach (String[] record in records)
            {
                String entry = record[1];
                if (name.Equals(entry, StringComparison.OrdinalIgnoreCase))
                {
                    String output = String.Join(", ", record);
                    Console.Write(output);
                    //Grab the matched entry's ID
                    ids[index] = record[0];
                    index++;
                    Console.WriteLine();
                    MessageBox.Show("Entry Found");
                }
            }
            //Return the found ids so you can use them
            return ids;
        }

        public String[] searchMarriedState(String state)
        {
            String[] ids = new String[10];
            int index = 0;
            //first validate the input, then pull up all matches 
            if (v.maritialstateIsValid(state))
            {
                foreach (String[] record in records)
                {
                    String entry = record[3];
                    if (state.Equals(entry, StringComparison.OrdinalIgnoreCase))
                    {
                        //Grab the matched entry's ID
                        ids[index] = record[0];
                        index++;
                        String output = String.Join(", ", record);
                        Console.Write(output);
                        Console.WriteLine();
                        MessageBox.Show("Entry Found");
                    }
                }
            }
            return ids;
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

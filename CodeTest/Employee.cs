using System;

namespace CodeTest

{

    public class Employee

    {
        private int id;
        private string name;
        private string dateofbirth;
        private string maritialstate;
        private float salary;
        private string address;

        public Employee(int id, string name, string dateofbirth, string maritialstate, float salary, string address)
        {

            this.id = id;

            this.name = name;

            this.dateofbirth = dateofbirth;
            this.maritialstate = maritialstate;

            this.salary = salary;

            this.address = address;

        }
        //Put in a toString method to make transfering to list form easier
        public override String ToString()
        {
            String e = id + ", " + name + ", " + dateofbirth + ", " + maritialstate + ", " + salary + ", " + address + '\n';
            return e;
        }

        public int Id
        {

            get

            {

                return id;

            }

            set

            {

                id = value;

            }

        }

        public string Name

        {

            get

            {

                return name;

            }

            set

            {

                name = value;

            }

        }

        public string Dateofbirth

        {

            get

            {

                return dateofbirth;

            }

            set

            {

                dateofbirth = value;

            }

        }

        public string Maritialstate

        {

            get

            {

                return maritialstate;

            }

            set

            {

                maritialstate = value;

            }

        }

        public float Salary

        {

            get

            {

                return salary;

            }

            set

            {

                salary = value;

            }

        }

        public string Address

        {

            get

            {

                return address;

            }

            set

            {

                address = value;

            }

        }

    }

}
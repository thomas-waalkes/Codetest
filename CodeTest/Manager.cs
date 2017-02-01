using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace CodeTest
{
    class Manager
    {

        public static void Main()
        {
            //Ideally I'd use unit tests, but since I'm working on limited/that seems to be outside the scope of the test
            //In place of them, I have created several tests 
            //That will throw up message boxes based on wheter the code is running properly 
            //In the style of TDD/agile, I'll write a test and code to get the test working 
            //This keeps me focused on building to spec and not worry about  
            //superfluous features /and or other parts of the project 

            //Test 1 Make sure multiple wrong logins kick you out of the program
            //NB this throws up three message windows 
            int testNumber = 1;
            printTestNum(testNumber++);
            Login l = new Login();
            l.logOn("Billy", "cat");
            l.logOn("tommy", "cat");
            Boolean success = l.logOn("Billy", "meow");

            //Test 2 Upon failure the program will not go any farther 
            printTestNum(testNumber++);
            TabManager t = new TabManager(success);
            t.makeTabs();
            //Test 3 the correct Login gets you into the rest of the program 
            //The valid user name is set to tommy and the password is set to meow
            printTestNum(testNumber++);
            l = new Login();
            success = l.logOn("tommy", "meow");

            //Test 4 upon a successful login build new tabs
            printTestNum(testNumber++);
            t = new TabManager(success);
            t.makeTabs();

            //Test 5 This should cause a failure since there's already an ID of 1 in the record
            printTestNum(testNumber++);
            t.registerEmployee(1, "sandy", "4 - 11 - 90", "single", 40000, "111 avenue ave");
            //Test 6 This should cause a failure since there's already a name of billy in the record
            printTestNum(testNumber++);
            t.registerEmployee(4, "billy", "4 - 11 - 90", "single", 40000, "111 avenue ave");
            //Test 7 This employee should register no problem 
            printTestNum(testNumber++);
            t.registerEmployee(4, "Joey", "4 - 10 - 95", "married", 45000, "120 avenue ave");
            //Test 8 This employee should not register since duck is not a valid marriage status
            printTestNum(testNumber++);
            t.registerEmployee(5, "Phil", "2 - 15 - 83", "duck", 95000, "120 cool st");

            //Test 9 This tests the print records method 
            printTestNum(testNumber++);
            t.printAllRecords();

            //Test 10 update the entry of billy and print all the records to see if its changed 
            printTestNum(testNumber++);
            t.changeRecord(0,"ID","10");
            t.changeRecord(0, "birthdate","2-1-2017");
            t.changeRecord(0, "maritalState", "married");
            t.changeRecord(0,"salary","1000");
            t.changeRecord(0, "address", "100 forest of feelings");
            
            t.printAllRecords();

            //Test 11 unfortunately we had to let Joey go, so let's remove him from the database
            printTestNum(testNumber++);
            t.deleteRecord(4);
            t.printAllRecords();

            //Test 12 Let's search for all billys in the database, there should be two printed
            printTestNum(testNumber++);
            t.searchName("billy");
            //Test 13 let's search for all Married people in the database it should be Billy, Jill and Jimmy
            printTestNum(testNumber++);
            t.searchMarriedState("married");
            
            //Test 14 see if we can export to CSV 
            //into the C:\ directory 
            printTestNum(testNumber++);
            t.exportRecordsToCSV();

            //That's it for my tests, in an ideal world, I might have seperated out the recordManager into smaller classes 
            //One for searching and one updating employees, but they share enough functionality/data that it still makes
            //sense keeping them togehter, the class is a little big for my taste though 
        }

        public static void printTestNum(int testNum)
        {
            Console.WriteLine("Test "+ testNum.ToString());
        }

    }
}
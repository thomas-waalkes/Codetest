using System;
using System.Windows.Forms;

namespace CodeTest
{
    public class Login
    {
        int attempts = 0;
        String password = "meow";
        String name = "tommy";
        String input_name = "";
        String input_password = "";
        public Login()
        {
            
        }

        public Boolean logOn(String name, String password)
        {
           inputName(name);
           inputPassword(password);
           Boolean success = validate();
           return success;
        } 

        private Boolean validate()
        {
            if (name.Equals(input_name, StringComparison.OrdinalIgnoreCase))
                {
                    if (password.Equals(input_password, StringComparison.OrdinalIgnoreCase))
                    {
                        MessageBox.Show("Login Successful!");
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("Incorrect Password");
                        attempts++;
                    }
                }
                else
                {
                    MessageBox.Show("Incorrect User Name");
                    attempts++;
                }
            if (attempts >= 3)
            {
                    MessageBox.Show("Too Many Login Attempts");
                    
            }
            return false;
       }
            
       private void inputPassword(String pw)
        {
            input_password = pw;
        }

        private void inputName(String n)
        {
            input_name = n;
        }
    }
}
        

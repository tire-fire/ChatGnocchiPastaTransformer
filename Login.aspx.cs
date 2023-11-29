using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.DirectoryServices.AccountManagement;

namespace ChatGnocchiPastaTransformer
{
    public partial class Login : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            // If the user is already logged in, redirect to the chat page
            if (Session["username"] != null)
            {
                Response.Redirect("Default.aspx");
            } else {
                // If the user is not logged in, display the login form
                LoginPanel.Visible = true;
            }
        }

        protected void LoginButton_Click(object sender, EventArgs e)
        {
            // Check if the username is valid
            if (UsernameTextBox.Text.Length > 0)
            {
                // Active Directory authentication form
                // Connect to the Active Directory server
                // Check if the username and password are valid
                using (PrincipalContext pc = new PrincipalContext(ContextType.Domain, "WINDOMAIN"))
                {
                    bool isValid = pc.ValidateCredentials(UsernameTextBox.Text, PasswordTextBox.Text);
                    if (!isValid)
                    {
                        // If the username and password are not valid, display an error message
                        LoginErrorLabel.Text = "Invalid username or password.";
                        return;
                    }
                }
                // If the username and password are valid, set the Session["username"] variable
                Session["username"] = UsernameTextBox.Text;

                // Redirect to the chat page
                Response.Redirect("Default.aspx");
            }
        }
    }
}
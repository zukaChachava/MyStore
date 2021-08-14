using System;
using System.Windows.Forms;
using MyStore.Domain.Models;
using MyStore.Repository;
using MyStore.Repository.Context;
using MyStore.WinApp.Interfaces;
using MyStore.WinApp.Tools;
using MyStore.WinApp.LocalData;
using MyStore.Repository.Exceptions;

namespace MyStore.WinApp
{
	public partial class LogInForm : Form
	{
		private readonly UserRepository _userRepository;

		public LogInForm(AppDbContext context)
		{
			InitializeComponent();
			_userRepository = new UserRepository(context);
			Valid = false;
			txtPassword.PasswordChar = '*';

#if DEBUG
			txtUsername.Text = "Admin";
			txtPassword.Text = "Admin1234";
#endif
		}

		public bool Valid { get; private set; }

		private void checkBox_CheckedChanged(object sender, EventArgs e)
		{
			if (checkBox.Checked == true)
				txtPassword.PasswordChar = '\0';
			else
				txtPassword.PasswordChar = '*';
		}

		private void logBtn_Click(object sender, EventArgs e)
		{
			(string username, string password) = ReadInput();
			try
			{
				LocalStorage.User = _userRepository.LogIn(username, password);
				LocalStorage.Permissions = _userRepository.GetPermissions(LocalStorage.User);
                foreach (var item in LocalStorage.Permissions)
                {
					var t = item;
                }
				Valid = true;
				Close();
			}
			catch(UserDoesNotExist ex)
			{
				FormTools.ShowInfo("Log In Problems", ex.Message);
			}
            catch(Exception ex)
            {
				FormTools.ShowInfo("Ops", ex.Message);
			}
		}

		private (string, string) ReadInput()
		{
			return (txtUsername.Text, txtPassword.Text);
		}

		private void LogInForm_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
				logBtn_Click(sender, e);
		}
	}
}

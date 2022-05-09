using ExamManageSystem.DoMain.AppEngine;
using ExamManageSystem.Models;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Models;
using Models.BussinessProvider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ExamManageSystem.ViewModel
{
    public class LoginViewModel : ViewModelBase
    {
        public Member Member { get; set; } = AppData.Instance.CurrentUser;

        public string SystemName { get; set; } = AppData.Instance.SystemName;

        public MemberProvider _memberProvider
        {
            get; private set; 
        }

        public LoginViewModel()
        {
            Member.Name = "admin";
            Member.Password = "123456";
        }

        /// <summary>
        /// Login cmd without param
        /// </summary>
        public RelayCommand LoginCommand
        {
            get
            {
                return new RelayCommand(() =>
                {
                    _memberProvider = new MemberProvider();
                    var memlist = _memberProvider.GetList();
                    var userinfo = _memberProvider.Select(x => x.Name.Equals(Member.Name) && x.Password.Equals(Member.Password));
                    if (userinfo is null)
                        MessageBox.Show("Current user not found!");
                    else
                    {
                        MainWindow mainWindow = new MainWindow();
                        mainWindow.Show();
                    }
                });
            }
        }

        /// <summary>
        /// Login cmd
        /// </summary>
        public RelayCommand<Window> LoginCommandT
        {
            get
            {
                return new RelayCommand<Window>((login) =>
                {
                    _memberProvider = new MemberProvider();
                    var userinfo = _memberProvider.Select(x => x.Name.Equals(Member.Name) && x.Password.Equals(Member.Password));
                    if (userinfo is null)
                    {
                        MessageBox.Show("Current user not found!");
                    }
                    else
                    {
                        MainWindow mainWindow = new MainWindow();   
                        mainWindow.Show();
                        login.Close();
                    }
                });
            }
        }

        /// <summary>
        /// logout cmd
        /// </summary>
        public RelayCommand CancelCommand
        {
            get
            {
                return new RelayCommand(() =>
                {
                    App.Current.Shutdown();
                });
            }
        }

        /// <summary>
        /// register cmd
        /// </summary>
        public RelayCommand RegisterCommand
        {
            get
            {
                return new RelayCommand(() =>
                {
                    App.Current.Shutdown();
                });
            }
        }

        /// <summary>
        /// resetpwd cmd
        /// </summary>
        public RelayCommand ResetCommand
        {
            get
            {
                return new RelayCommand(() =>
                {
                    App.Current.Shutdown();
                });
            }
        }

    }
}

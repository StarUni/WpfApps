using ExamManageSystem.DoMain.AppEngine;
using ExamManageSystem.DoMain.Helper;
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
using System.Windows.Controls;

namespace ExamManageSystem.ViewModel
{
    public class LoginViewModel : ViewModelBase
    {
        //public Member Member { get; set; } = AppData.Instance.CurrentUser;
        public UserInfo UserInfo { get; set; } = AppData.Instance.UserInfo;

        public string SystemName { get; set; } = AppData.Instance.SystemName;

        public UserInfoProvider UserInfoProvider { get; set; }

        //public MemberProvider _memberProvider
        //{
        //    get; private set; 
        //}

        public LoginViewModel()
        {
            UserInfo.UserName = "admin";
            UserInfo.Password = "123456";
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
                    UserInfoProvider = new UserInfoProvider();
                    var memlist = UserInfoProvider.GetList();
                    var userinfo = UserInfoProvider.Select(x => x.UserName.Equals(UserInfo.UserName) && x.Password.Equals(UserInfo.Password));
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
                    if(UserInfoProvider == null)
                        UserInfoProvider = new UserInfoProvider();
                    var passwordBox = login.FindName("inputpwd") as PasswordBox;
                    var userinfo = UserInfoProvider.Select(x => x.UserName.Equals(UserInfo.UserName));
                    if (userinfo is null)
                    {
                        if(MessageBox.Show("Current user not found! Register?", "Notice!", MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
                        {
                            var salt = PasswordHelper.GenerateSalt(7);
                            var pwd = PasswordHelper.MD5Encoding(passwordBox.Password, salt);
                            var i = UserInfoProvider.Insert(new UserInfo() { UserName = UserInfo.UserName, Password = pwd, Salt = salt});
                            if(i < 0)
                            {
                                MessageBox.Show($"insert failed.{i}");
                            }
                            else
                            {
                                MessageBox.Show("Add Account succeed.please click login.");
                            }
                        }
                    }
                    else
                    {
                        var pwd = PasswordHelper.MD5Encoding(passwordBox.Password, userinfo.Salt);
                        if (pwd is null)
                        {
                            userinfo.Salt = PasswordHelper.GenerateSalt(7);
                            pwd = PasswordHelper.MD5Encoding(passwordBox.Password, userinfo.Salt);
                        }
                        if (userinfo.Password.Equals(pwd))
                        {
                            MainWindow mainWindow = new MainWindow();
                            mainWindow.Show();
                            login.Close();
                        }
                        else
                        {
                            if (MessageBox.Show("Password is incorrect! Reset Password?", "Error!", MessageBoxButton.YesNo, MessageBoxImage.Error) == MessageBoxResult.Yes)
                            {
                                userinfo.Password = pwd;
                                var i = UserInfoProvider.Update(userinfo);
                                if (i < 0)
                                {
                                    MessageBox.Show($"reset password failed.{i}");
                                }
                                else
                                {
                                    MessageBox.Show("update succeed.please click login.");
                                }
                            }
                        }
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

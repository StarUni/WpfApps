using ExamManageSystem.DoMain.AppEngine;
using ExamManageSystem.DoMain.Helper;
using ExamManageSystem.Models;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using Models;
using Models.BussinessProvider;
using System;
using System.Windows;
using System.Windows.Controls;

namespace ExamManageSystem.ViewModel
{
    public class LoginViewModel : ObservableObject
    {
        public UserInfo _userInfo { get; set; } = AppData.Instance.UserInfo;
        public string SystemName { get; set; } = AppData.Instance.SystemName;
        private UserInfoProvider _userInfoProvider = null;
        private readonly ServiceProvider _serviceProvider;

        public LoginViewModel(EMSDBContext context)
        {
            _userInfoProvider = new UserInfoProvider(context);
            _userInfo.UserName = "admin";
            _serviceProvider = new ViewModelLocator()._serviceProvider;
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
                    var memlist = _userInfoProvider.GetList();
                    var userinfo = _userInfoProvider.Select(x => x.UserName.Equals(_userInfo.UserName) && x.Password.Equals(_userInfo.Password));
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
                    var passwordBox = login.FindName("inputpwd") as PasswordBox;
                    var userinfo = _userInfoProvider.Select(x => x.UserName.Equals(_userInfo.UserName));
                    if (userinfo is null)
                    {
                        if(MessageBox.Show("Current user not found! Register?", "Notice!", MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
                        {
                            var salt = PasswordHelper.GenerateSalt(7);
                            var pwd = PasswordHelper.MD5Encoding(passwordBox.Password, salt);
                            var i = _userInfoProvider.Insert(new UserInfo()
                            {
                                UserName = _userInfo.UserName,
                                Password = pwd,
                                Salt = salt,
                                CreateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.ffffff")
                            });
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
                            AppData.Instance.UserInfo = userinfo;
                            var mainWindow = _serviceProvider.GetService<MainWindow>();
                            mainWindow.Show();
                            login.Close();
                        }
                        else
                        {
                            if (MessageBox.Show("Password is incorrect! Reset Password?", "Error!", MessageBoxButton.YesNo, MessageBoxImage.Error) == MessageBoxResult.Yes)
                            {
                                userinfo.Password = pwd;
                                var i = _userInfoProvider.Update(userinfo);
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
    }
}

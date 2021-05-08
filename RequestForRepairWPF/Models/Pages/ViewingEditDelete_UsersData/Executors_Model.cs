using Microsoft.EntityFrameworkCore;
using Prism.Mvvm;
using RequestForRepairWPF.Data;
using RequestForRepairWPF.Data.User;
using RequestForRepairWPF.ViewModels.DialogWindows;
using RequestForRepairWPF.Views.DialogWindows;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
//using System.Data.Linq.SqlClient.SqlMethods.Like;

namespace RequestForRepairWPF.Models.Pages.ViewingEditDelete_UsersData
{
    public class Executors_Model
    {
        Entities.DB_RequestForRepairEntities3 context = new Entities.DB_RequestForRepairEntities3();

        #region Поиск

        //#region Очищение данных
        //public List<int> ClearIdUsers()
        //{
        //    //get
        //    //{
        //        User_DataModel.AllUsersID.Clear();
        //    //}
        //}
        //#endregion

        #region Получение id всех исполнителей (КРИТЕРИЙ ID)
        public List<int> AllIdUsers_ID(string searchData)
        {
            //var query = context.Users
            //    .Where(p => EF.Functions.Like(Convert.ToString(p.id_user), "%" + searchData + "%")
            //    && p.id_type == 3);

            var query = from u in context.Users
                        where EF.Functions.Like(u.id_user.ToString(), "%" + searchData + "%")
                        && u.id_type == 3
                        select u.id_user;
            var test = context.Users
                .Where(b => b.last_name.Contains(searchData))
                .Select(b => b.id_user);
            //var query = from u in context.Users
            //            where u.id_user.Contains(searchData);
            //            select u.id_user;
            
            //var query = from u in context.Users
            //            where u.id_type == 3 && u.id_user == "%"+searchData+"%"
            //            select u.id_user;
            try
            {
                foreach (var i in test)
                    User_DataModel.AllUsersID.Add(Convert.ToInt32(i));
            }
            catch(Exception e)
            {
                OpenDialogWindow("Ошибка!!!\n" + e.ToString());
            }
            

            return User_DataModel.AllUsersID;
        }
        #endregion

        #endregion

        #region Отображение данных

        #region Получение id всех исполнителей
        public List<int> AllIdUsers
        {
            get
            {
                var query = from u in context.Users
                                where u.id_type == 3
                                select u.id_user;
                foreach (var i in query)
                    User_DataModel.AllUsersID.Add(i);

                return User_DataModel.AllUsersID;
            }
        }
        #endregion

        #region Получение списка всех исполнителей
        public List<User_DataModel> GetPeople(List<int> AllIdUsers)
        {
            List<User_DataModel> output = new List<User_DataModel>();

            foreach (var i in AllIdUsers)
                output.Add(GetPerson(i));

            return output;
        }
        #endregion

        #region Получeние одного исполнителя
        private User_DataModel GetPerson(int id)
        {
            User_DataModel output = new User_DataModel();

            output.idUser = id;
            output.userLogin = UserLogin(id);
            output.userPassword = UserPass(id);
            output.categoryExecutors = UserCategoryExecutors(id);
            output.lastName = UserLastName(id);
            output.name = UserName(id);
            output.middleName = UserMiddleName(id);
            output.position = UserPosition(id);
            output.phone = UserPhone(id);

            return output;
        }
        #endregion

        #endregion

        #region Получение данных

        #region Логин пользователя
        private string UserLogin(int id)
        {
            string _login = context.Users
                .Where(c => c.id_user == id)
                .Select(c => c.user_login)
                .FirstOrDefault();

            return _login;
        }
        #endregion

        #region Пароль
        private string UserPass(int id)
        {
            string _password = context.Users
                .Where(c => c.id_user == id)
                .Select(c => c.user_password)
                .FirstOrDefault();

            return _password;
        }
        #endregion

        #region Категория исполнителя
        private string UserCategoryExecutors(int id)
        {
            string _categoryExecutors = context.Users
                .Where(c => c.id_user == id)
                .Select(c => c.category_executors)
                .FirstOrDefault();

            return _categoryExecutors;
        }
        #endregion

        #region Фамилия
        private string UserLastName(int id)
        {
            string _lastName = context.Users
                .Where(c => c.id_user == id)
                .Select(c => c.last_name)
                .FirstOrDefault();

            return _lastName;
        }
        #endregion

        #region Имя
        private string UserName(int id)
        {
            string _name = context.Users
                .Where(c => c.id_user == id)
                .Select(c => c.name)
                .FirstOrDefault();

            return _name;
        }
        #endregion

        #region Отчество 
        private string UserMiddleName(int id)
        {
            string _middleName = context.Users
                .Where(c => c.id_user == id)
                .Select(c => c.middle_name)
                .FirstOrDefault();

            return _middleName;
        }
        #endregion

        #region Должность
        private string UserPosition(int id)
        {
            string _position = context.Users
                .Where(c => c.id_user == id)
                .Select(c => c.position)
                .FirstOrDefault();

            return _position;
        }
        #endregion

        #region Телефон
        private string UserPhone(int id)
        {
            string _phone = context.Users
                .Where(c => c.id_user == id)
                .Select(c => c.phone)
                .FirstOrDefault();

            return _phone;
        }
        #endregion

        #endregion

        #region Открытие диалогового окна
        private void OpenDialogWindow(string textMessage)
        {
            Dialog_ViewModel messageBox_ViewModel = new Dialog_ViewModel(textMessage);
            MessageBox_View messageBox_View = new MessageBox_View();
            messageBox_View.Show();
        }
        #endregion
    }
}

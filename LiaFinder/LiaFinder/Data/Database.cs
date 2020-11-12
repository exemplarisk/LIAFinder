﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using LiaFinder.Models;
using SQLite;

namespace LiaFinder
{
    public static class Database
    {
        #region Private Fields
        private static SQLiteConnection _db = null;
        private static string _dbPath = null;

        private static SQLiteConnection Db
        {
            get
            {
                if (_db == null)
                {
                    _db = new SQLiteConnection(DbPath);
                    CreateDefaultTables();
                }

                return _db;
            }
        }
        #endregion

        #region Private Methods
        private static string DbPath
        {
            get
            {
                if(string.IsNullOrEmpty(_dbPath))
                {
                    _dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "student.db3");
                }

                return _dbPath;
            }
        }

        private static void CreateDefaultTables()
        {
            _db.CreateTable<User>();
            _db.CreateTable<Ad>();
            _db.CreateTable<Application>();
        }
        #endregion


        #region Public Methods
        public static void UpdateUser(User user)
        {
            Db.Update(user);
        }

        public static User GetLoggedInCompany(Guid id)
        {
            return Db.Table<User>().Where(u => u.isCompany.Equals(true) && u.isLoggedIn.Equals(true) && u.UserId.Equals(id)).FirstOrDefault();
        }

        public static User ValidateUserLogin(string username, string password)
        {
            var user = Db.Table<User>().Where(u => u.UserName.Equals(username) && u.Password.Equals(password)).FirstOrDefault();

            if(user == null)
            {
                return null;
            }

            return user;

        }
        //TODO: Add function to insert Application to DB

        public static void InsertAd(Ad ad)
        {
            Db.Insert(ad);
        }

        public static void InsertApplicationAsync(Application application)
        {
                Db.Insert(application);
        }

        public static Task<List<Application>> GetApplicationAsync()
        {
            var applications = Db.Table<Application>().ToList();

            return Task.FromResult(applications);
        }

        public static Task<List<Ad>> GetAds()
        {
            var ads = Db.Table<Ad>().ToList();
            return Task.FromResult(ads);
        }
        #endregion
        //public Task<List<User>> GetUserAsync()
        //{
        //    return _db.Table<User>().ToListAsync();
        //}
    }
}

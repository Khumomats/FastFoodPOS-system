﻿using System;
using System.Collections.Generic;
using System.Windows.Forms;
using FastFoodPOS.Models;

namespace FastFoodPOS.Forms.AdminForms
{
    public partial class FormTransactions : UserControl
    {
        Dictionary<int, User> Users;
        public FormTransactions()
        {
            InitializeComponent();
            Users = new Dictionary<int, User>();
            User.GetAll(true).ForEach((User user) => Users.Add(user.Id, user));
            DateTimeSpecifier.MaxDate = DateTime.Now;
            DateTimeSpecifier.Value = DateTimeSpecifier.MaxDate;
        }

        void RefreshTransactions(DateTime date)
        {
            var Transactions = Transaction.GetTransactions(date);
            DataGridViewTransaction.Rows.Clear();
            Transactions.ForEach((Transaction transaction) =>
            {
                DataGridViewTransaction.Rows.Add(
                    "#" + transaction.Id,
                    transaction.Date.ToShortTimeString(),
                    Users[transaction.CashierId].Fullname,
                 "R"+   transaction.Total 
                );
            });
            if (Transactions.Count == 0)
            {
                DataGridViewTransaction.Rows.Add("There is no transaction on the selected date");
            }
        }

        private void DateTimeSpecifier_ValueChanged(object sender, EventArgs e)
        {
            RefreshTransactions(DateTimeSpecifier.Value);
        }
    }
}

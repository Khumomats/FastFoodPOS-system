﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FastFoodPOS.Properties {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "17.1.0.0")]
    internal sealed partial class Settings : global::System.Configuration.ApplicationSettingsBase {
        
        private static Settings defaultInstance = ((Settings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new Settings())));
        
        public static Settings Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.SpecialSettingAttribute(global::System.Configuration.SpecialSetting.ConnectionString)]
        [global::System.Configuration.DefaultSettingValueAttribute("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\\FastFoodDatabase.ac" +
            "cdb;Persist Security Info=True")]
        public string FastFoodDatabaseConnectionString {
            get {
                return ((string)(this["FastFoodDatabaseConnectionString"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("\nCREATE TABLE IF NOT EXISTS `orders` (\n  `id` int(11) NOT NULL AUTO_INCREMENT,\n  " +
            "`product_id` int(11) NOT NULL,\n  `transaction_id` varchar(256) NOT NULL,\n  `quan" +
            "tity` int(11) NOT NULL,\n  `price` decimal(10,2) NOT NULL,\n  PRIMARY KEY(id)\n) EN" +
            "GINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;\n\n\nCREATE TABLE I" +
            "F NOT EXISTS `products` (\n  `id` int(11) NOT NULL AUTO_INCREMENT,\n  `name` varch" +
            "ar(256) NOT NULL,\n  `category` varchar(256) NOT NULL,\n  `price` decimal(10,2) NO" +
            "T NULL,\n  `is_available` tinyint(1) NOT NULL,\n  `image` varchar(256) NOT NULL,\n " +
            " `is_deleted` tinyint(1) NOT NULL DEFAULT \'0\',\n  PRIMARY KEY(id)\n) ENGINE=InnoDB" +
            " DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;\n\n\nCREATE TABLE IF NOT EXIST" +
            "S `transactions` (\n  `id` varchar(256) NOT NULL,\n  `user_id` int(11) NOT NULL,\n " +
            " `date_created` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,\n  `cash` decimal(10" +
            ",2) NOT NULL,\n  PRIMARY KEY(id)\n) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=" +
            "utf8mb4_0900_ai_ci;\n\n\nCREATE TABLE IF NOT EXISTS `users` (\n  `id` int(11) NOT NU" +
            "LL AUTO_INCREMENT,\n  `fullname` varchar(256) NOT NULL,\n  `email` varchar(256) NO" +
            "T NULL,\n  `role` varchar(256) NOT NULL,\n  `password` varchar(256) NOT NULL,\n  `i" +
            "mage` varchar(256) NOT NULL,\n  `is_deleted` tinyint(1) NOT NULL DEFAULT \'0\',\n  P" +
            "RIMARY KEY(id)\n) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_c" +
            "i;\n\n\nCREATE OR REPLACE VIEW `OrderTotal` AS\nSELECT transaction_id, SUM(price*qua" +
            "ntity) AS total, Sum(quantity) AS orders\nFROM orders\nGROUP BY transaction_id;\n\n\n" +
            "CREATE OR REPLACE VIEW `TransactionsView` AS\nSELECT transactions.*, OrderTotal.t" +
            "otal, OrderTotal.orders\nFROM transactions INNER JOIN OrderTotal ON transactions." +
            "id=OrderTotal.transaction_id;\n\n\nCREATE OR REPLACE VIEW `SalesView` AS\nSELECT Sum" +
            "(TransactionsView.total) AS Sale, date_created AS day, Sum(TransactionsView.orde" +
            "rs) AS total_order, Count(TransactionsView.id) AS total_customer\nFROM Transactio" +
            "nsView\nGROUP BY day\nORDER BY day;\n\n")]
        public string MySQLTables {
            get {
                return ((string)(this["MySQLTables"]));
            }
        }
    }
}

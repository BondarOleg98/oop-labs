﻿using System;
using Trade.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;

namespace Trade.Data
{
    public class Organization : Base
    {
        static public Dictionary<Guid, Organization> Organizations = new Dictionary<Guid, Organization>();
        static public List<Organization> Departments = new List<Organization>();
        
        private int data_creation;

        private static int last_year = 2200;

        public string Name { get; private set; }
        public string Bank_account { get; private set; }
        public string Head { get; private set; }
        public int Data_creation
        {
            
            set
            {
                if ((value < 0)||(value>last_year))
                {
                    data_creation = 0;
                }
                else
                {
                    data_creation = value;
                }
            }
            get
            {
                return data_creation;
            }
        }

        private Guid _accountingID;

        public Organization(string name_org, int data_creation, string bank_account, string head)
        {
            Name = name_org; 
            Data_creation = data_creation;
            Bank_account = bank_account;
            Head = head;

        }

        public Organization() { }

        public static string Exist_organization(int data_creation)
        {
            int year = DateTime.Now.Year - data_creation;
            if((year<=0)||(year>last_year))
            {
                year = 0;
                return " Existed for " + year;
            }
            else 
            {
                return " Existed for " + year;
            }
            
        }

        public List<СommodityInOrganization> CommodityInOrganization
        {
            get
            {
                List<СommodityInOrganization> result = new List<СommodityInOrganization>();
                foreach (СommodityInOrganization cio in СommodityInOrganization.CommodityInOrganizations)
                    if (cio.Organization == this)
                        result.Add(cio);
                return result;
            }
        }

        public List<Commodity> Commodities
        {
            get
            {
                List<Commodity> result = new List<Commodity>();
                foreach (СommodityInOrganization cio in СommodityInOrganization.CommodityInOrganizations)
                    if (cio.Organization == this)
                        result.Add(cio.Commodity);
                return result;
            }
        }

        public Accounting Accounting
        {
            get
            {
                return Accounting.Accountings[_accountingID];
            }
            set
            {
                _accountingID = value.ID;
            }
        }

        static public List<Organization> _Organizations = new List<Organization>();
        static public List<Organization> __Organizations = new List<Organization>();

        public Accounting Accountings { get; }

        public override string ToString()
        {
            
            return "Name: " + Name + "/" +
                   "Head: " + Head + "/" +
                   "Year(creat): " + Data_creation + "/" +
                   "Bank account: " + Bank_account + "/" + Exist_organization(Data_creation) +" years";
        }
        




    }
}

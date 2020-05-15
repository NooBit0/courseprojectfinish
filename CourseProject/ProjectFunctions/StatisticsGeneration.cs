using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CourseProject.Models;

namespace CourseProject.ProjectFunctions
{
    public class StatisticsGeneration
    {
        public static string GetRentalAccounting()
        {
            using (var courceProjectItems = new CourceProjectDbContext())
            {
                var premisesList = courceProjectItems.RentalPremises.ToList();
                var adress = courceProjectItems.RentalPremises.Select(a => a.Building.Adress).ToList();
                var userFullName = courceProjectItems.TenantRentalPremises.Select(a => a.FullName).ToList();
                StringBuilder sb = new StringBuilder();
                foreach (var item in premisesList)
                {
                    if (item.RentalCheck == true)
                    {
                        sb.Append("Arended status: " + item.RentalCheck + "\nTenant: " +
                            courceProjectItems.TenantRentalPremises.Where(a => a.RentalPremisesId == item.RentalPremisesId).Select(a => a.FullName).FirstOrDefault() + "\nAdress: " +
                                courceProjectItems.Buildings.Where(a => a.BuildingID == item.BuildingID).Select(a => a.Adress).FirstOrDefault() + item.ToString());
                        sb.Append("------------------------------------------------------------\n");
                    }
                    else
                    {
                        sb.Append("Arended status: " + item.RentalCheck + "\nAdress: " +
                                courceProjectItems.Buildings.Where(a => a.BuildingID == item.BuildingID).Select(a => a.Adress).FirstOrDefault() + item.ToString());
                        sb.Append("------------------------------------------------------------\n");
                    }
                }

                return sb.ToString();
            }
        }

        public static string GetTenants()
        {
            using (var courceProjectItems = new CourceProjectDbContext())
            {
                var tenantsRental = courceProjectItems.TenantRentalPremises.ToList();
                StringBuilder sb = new StringBuilder();
                foreach (var item in tenantsRental)
                {
                    sb.Append("Tenant: " + item.FullName + "\nAdress: " + item.Adress + "\nRental Number: " + item.RentalNumber + "\nRental Begin Date: " +
                        courceProjectItems.RentalPremises.Where(a => a.RentalPremisesId == item.RentalPremisesId).Select(a => a.RentalBeginDate).FirstOrDefault() +
                        "\nRental End Date: " + courceProjectItems.RentalPremises.Where(a => a.RentalPremisesId == item.RentalPremisesId).Select(a => a.RentalEndDate).FirstOrDefault() + "\n");
                    sb.Append("------------------------------------------------------------\n");
                }

                return sb.ToString();
            }
        }

        public static string GetRentalContract()
        {
            using (var courceProjectItems = new CourceProjectDbContext())
            {
                var tenantsRental = courceProjectItems.TenantRentalPremises.ToList();
                StringBuilder sb = new StringBuilder();
                float cost;
                float totalCost = 0;
                foreach (var item in tenantsRental)
                {
                    cost = ArendetPremisesPageGeneration.TotalRentalCost(item.RentalPremisesId);
                    totalCost += cost;
                    sb.Append("Tenant: " + item.FullName + "\nAdress: " + item.Adress + "\nRental Number: " + item.RentalNumber +
                        "\nArea: " + courceProjectItems.RentalPremises.Where(a => a.RentalPremisesId == item.RentalPremisesId).Select(a => a.Area).FirstOrDefault() +
                        "\nPrice: " + courceProjectItems.RentalPremises.Where(a => a.RentalPremisesId == item.RentalPremisesId).Select(a => a.Price).FirstOrDefault() + "\nRental Begin Date: " +
                        courceProjectItems.RentalPremises.Where(a => a.RentalPremisesId == item.RentalPremisesId).Select(a => a.RentalBeginDate).FirstOrDefault() +
                        "\nRental End Date: " + courceProjectItems.RentalPremises.Where(a => a.RentalPremisesId == item.RentalPremisesId).Select(a => a.RentalEndDate).FirstOrDefault() +
                        "\nProfit: " + cost);
                    sb.Append("\n------------------------------------------------------------\n");
                }

                sb.Append("\n Total profit: " + totalCost);
                return sb.ToString();
            }
        }

        public static string GetPriceList()
        {
            using (var buildingsItems = new CourceProjectDbContext())
            {
                var premisesList = buildingsItems.RentalPremises.ToList();

                StringBuilder sb = new StringBuilder();

                foreach (var item in premisesList)
                {
                    sb.Append("Adress: " + buildingsItems.Buildings.Where(a => a.BuildingID == item.BuildingID).Select(a => a.Adress).FirstOrDefault() + "\nArea: " + item.Area + "\nPrice: " + item.Price + "\nRental Number: " + item.RentalNumber + "\n");
                    sb.Append("------------------------------------------------------------\n");
                }

                return sb.ToString();
            }
        }

        public static float TotalRentalCost(string rentalBeginDate, string rentalEndDate, float price)
            {
                float temp = (((DateTime.Parse(rentalEndDate).Year - DateTime.Parse(rentalBeginDate).Year) * 12) + DateTime.Parse(rentalEndDate).Month - DateTime.Parse(rentalBeginDate).Month) * price;
                return temp == 0 ? price : temp;
        }

        public static string GetStatistic()
        {
            using (var courceProjectItems = new CourceProjectDbContext())
            {
                float profit;
                float totalProfit = 0;
                var premisesList = courceProjectItems.RentalPremises.ToList();
                var adress = courceProjectItems.RentalPremises.Select(a => a.Building.Adress).ToList();
                var userFullName = courceProjectItems.TenantRentalPremises.Select(a => a.FullName).ToList();
                StringBuilder sb = new StringBuilder();
                foreach (var item in premisesList)
                {
                    if (item.RentalCheck == true)
                    {
                        profit = TotalRentalCost(item.RentalBeginDate, item.RentalEndDate, item.Price);
                        totalProfit += profit;
                        sb.Append("Arended status: " + item.RentalCheck + "\nTenant: " +
                            courceProjectItems.TenantRentalPremises.Where(a => a.RentalPremisesId == item.RentalPremisesId).Select(a => a.FullName).FirstOrDefault() + "\nAdress: " +
                                courceProjectItems.Buildings.Where(a => a.BuildingID == item.BuildingID).Select(a => a.Adress).FirstOrDefault() + item.ToString() + "Profit: " + profit + "\n");
                        sb.Append("------------------------------------------------------------\n");
                    }
                    else
                    {
                        sb.Append("Arended status: " + item.RentalCheck + "\nAdress: " +
                                courceProjectItems.Buildings.Where(a => a.BuildingID == item.BuildingID).Select(a => a.Adress).FirstOrDefault() + item.ToString() + "Profit: 0\n");
                        sb.Append("------------------------------------------------------------\n");
                    }
                }

                sb.Append("Total profit: " + totalProfit + "\n");
                return sb.ToString();
            }
        }

        public static void SaveToFile(string report)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Text file (*.txt)|*.txt|All files (*.*)|*.*";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                StreamWriter streamWriter = new StreamWriter(saveFileDialog.FileName);
                streamWriter.WriteLine(report);
                streamWriter.Close();
            }
        }
    }
}
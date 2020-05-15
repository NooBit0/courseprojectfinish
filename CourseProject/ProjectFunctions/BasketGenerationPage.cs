using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using CourseProject.Models;

namespace CourseProject.ProjectFunctions
{
    public class BasketGenerationPage
    {
        public static string GetRentalPramses(string login)
        {
            using (var userItems = new CourceProjectDbContext())
            {
                var buildingsItems = new CourceProjectDbContext();
                var premisesList = buildingsItems.RentalPremises.Where(a => a.RentalBeginDate != null && a.RentalCheck == false).ToList();
                var adress = buildingsItems.RentalPremises.Where(a => a.RentalBeginDate != null && a.RentalCheck == false).Select(a => a.Building.Adress).ToList();
                float cost;
                float totalCost = 0;
                StringBuilder sb = new StringBuilder();

                for (int i = 0; i < adress.Count; i++)
                {
                    cost = ArendetPremisesPageGeneration.TotalRentalCost(premisesList[i].RentalPremisesId);
                    totalCost += cost;
                    sb.Append("Adress: " + adress[i] + premisesList[i].ToString() + "Cost: " + cost + "\n");
                    sb.Append("------------------------------------------------------------\n");
                }

                sb.Append("Total Cost: " + totalCost);
                return sb.ToString();
            }
        }

        public static void СancelButton()
        {
            var buildingsItems = new CourceProjectDbContext();
            var usersItems = new CourceProjectDbContext();
            var premisesList = buildingsItems.RentalPremises.Where(a => a.RentalBeginDate != null && a.RentalCheck == false).ToList();
            for (int i = 0; i < premisesList.Count; i++)
            {
                int temp = premisesList[i].RentalPremisesId;
                usersItems.TenantRentalPremises.Remove(usersItems.TenantRentalPremises.Where(a => a.RentalPremisesId == temp).Select(a => a).First());
                premisesList[i].RentalBeginDate = null;
                premisesList[i].RentalEndDate = null;
            }

            usersItems.SaveChanges();
            buildingsItems.SaveChanges();
        }

        public static void AcceptRentalPramses()
        {
            var buildingsItems = new CourceProjectDbContext();
            var premisesList = buildingsItems.RentalPremises.Where(a => a.RentalBeginDate != null && a.RentalCheck == false).ToList();
            foreach (var item in premisesList)
            {
                item.RentalCheck = true;
            }

            buildingsItems.SaveChanges();
        }
    }
}

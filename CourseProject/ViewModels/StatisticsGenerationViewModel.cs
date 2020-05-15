using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CourseProject.ProjectFunctions;

namespace CourseProject.ViewModels
{
    public class StatisticsGenerationViewModel
    {
        public static string GetRentalPramses() => StatisticsGeneration.GetPriceList();

        public static string GetRentalAccounting() => StatisticsGeneration.GetRentalAccounting();

        public static string GetTenants() => StatisticsGeneration.GetTenants();

        public static string GetRentalContract() => StatisticsGeneration.GetRentalContract();

        public static string GetStatistic() => StatisticsGeneration.GetStatistic();
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class TaxPayer
{
    public string LastName { get; set; }
    public string FirstName { get; set; }
    public double AnnualIncome { get; set; }

    private const double LowIncomeLimit = 20000;   // граница низкого дохода
    private const double MediumIncomeLimit = 40000;   // граница среднего дохода

    private const double LowTaxRate = 0.12;  // 12% — до 20 000
    private const double MediumTaxRate = 0.20;  // 20% — 20 000–40 000
    private const double HighTaxRate = 0.35;  // 35% — свыше 40 000

    // Прогрессивная шкала налога
    public double CalculateTax()
    {
        if (AnnualIncome <= LowIncomeLimit)
        {
            return AnnualIncome * LowTaxRate;
        }
        else if (AnnualIncome <= MediumIncomeLimit)
        {
            return AnnualIncome * MediumTaxRate;
        }
        else
        {
            return AnnualIncome * HighTaxRate;
        }
    }
}

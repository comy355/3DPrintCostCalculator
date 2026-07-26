namespace PrintPricePro;

public class CalculationResult
{
    public double MaterialCost { get; set; }
    public double MachineCost { get; set; }
    public double ProductionCost { get; set; }
    public double SellingPrice { get; set; }
}

public static class PriceCalculator
{
    public static CalculationResult Calculate(
        double filamentUsed,
        double spoolWeight,
        double spoolPrice,
        double hours,
        double minutes,
        double machineRate,
        double designFee,
        double profitPercent)
    {
        double materialCost = spoolWeight > 0
            ? filamentUsed / spoolWeight * spoolPrice
            : 0;

        double machineCost = (hours + minutes / 60.0) * machineRate;

        double productionCost = materialCost + machineCost + designFee;

        double sellingPrice = productionCost * (1 + profitPercent / 100.0);

        return new CalculationResult
        {
            MaterialCost = materialCost,
            MachineCost = machineCost,
            ProductionCost = productionCost,
            SellingPrice = sellingPrice
        };
    }
}

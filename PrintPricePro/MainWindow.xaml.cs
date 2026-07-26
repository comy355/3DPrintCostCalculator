using System;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;

namespace PrintPricePro;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        Recalculate();
    }

    private double N(TextBox box)
    {
        return double.TryParse(
            box.Text,
            NumberStyles.Any,
            CultureInfo.InvariantCulture,
            out var value)
            ? value
            : 0;
    }

    private void InputChanged(object sender, TextChangedEventArgs e)
    {
        Recalculate();
    }

    private void Recalculate()
    {
        double used = N(FilamentUsedBox);
        double weight = N(SpoolWeightBox);
        double price = N(SpoolPriceBox);
        double hrs = N(HoursBox);
        double mins = N(MinutesBox);
        double rate = N(MachineRateBox);
        double design = N(DesignFeeBox);
        double profit = N(ProfitBox);

        var result = PriceCalculator.Calculate(
            used,
            weight,
            price,
            hrs,
            mins,
            rate,
            design,
            profit);

        MaterialCostText.Text =
            $"Material Cost: {result.MaterialCost:C2}";

        MachineCostText.Text =
            $"Machine Cost: {result.MachineCost:C2}";

        ProductionCostText.Text =
            $"Production Cost: {result.ProductionCost:C2}";

        SellingPriceText.Text =
            $"Selling Price: {result.SellingPrice:C2}";
    }
}

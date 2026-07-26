using System;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
namespace PrintPricePro;
public partial class MainWindow:Window{public MainWindow(){InitializeComponent();Recalculate();}double N(TextBox b){return double.TryParse(b.Text,NumberStyles.Any,CultureInfo.InvariantCulture,out var v)?v:0;}void InputChanged(object s,TextChangedEventArgs e)=>Recalculate();void Recalculate(){double used=N(FilamentUsedBox),weight=N(SpoolWeightBox),price=N(SpoolPriceBox),hrs=N(HoursBox),mins=N(MinutesBox),rate=N(MachineRateBox),design=N(DesignFeeBox),profit=N(ProfitBox);double material=weight>0?used/weight*price:0;double machine=(hrs+mins/60.0)*rate;double production=material+machine+design;double sell=production*(1+profit/100.0);MaterialCostText.Text=$"Material Cost: {material:C2}";MachineCostText.Text=$"Machine Cost: {machine:C2}";ProductionCostText.Text=$"Production Cost: {production:C2}";SellingPriceText.Text=$"Selling Price: {sell:C2}";}}
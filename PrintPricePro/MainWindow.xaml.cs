using System;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
namespace PrintPricePro;
public partial class MainWindow:Window{public MainWindow(){InitializeComponent();CurrencyBox.SelectedIndex=0;Recalculate();}double N(TextBox b){return double.TryParse(b.Text,NumberStyles.Any,CultureInfo.InvariantCulture,out var v)?v:0;}void InputChanged(object s,TextChangedEventArgs e)=>Recalculate();
void CurrencyChanged(object s,SelectionChangedEventArgs e)=>Recalculate();void Recalculate(){double used=N(FilamentUsedBox),weight=N(SpoolWeightBox),price=N(SpoolPriceBox),hrs=N(HoursBox),mins=N(MinutesBox),rate=N(MachineRateBox),design=N(DesignFeeBox),profit=N(ProfitBox);double material=weight>0?used/weight*price:0;double machine=(hrs+mins/60.0)*rate;double production=material+machine+design;double sell=production*(1+profit/100.0);string sym=((System.Windows.Controls.ComboBoxItem)CurrencyBox.SelectedItem).Content.ToString();
MaterialCostText.Text=$"Material Cost: {sym}{material:F2}";MachineCostText.Text=$"Machine Cost: {sym}{machine:F2}";ProductionCostText.Text=$"Production Cost: {sym}{production:F2}";SellingPriceText.Text=$"{sym}{sell:F2}";}}
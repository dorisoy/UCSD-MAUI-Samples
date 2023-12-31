namespace MauiSensors.Views;

public partial class BarometerPage : ContentPage
{
	public BarometerPage()
	{
		InitializeComponent();
        ToggleBarometer();
	}
    public void ToggleBarometer()
    {
        if (Barometer.Default.IsSupported)
        {
            if (!Barometer.Default.IsMonitoring)
            {
                // Turn on accelerometer
                Barometer.Default.ReadingChanged += Barometer_ReadingChanged;
                Barometer.Default.Start(SensorSpeed.Game);
            }
            else
            {
                // Turn off accelerometer
                Barometer.Default.Stop();
                Barometer.Default.ReadingChanged -= Barometer_ReadingChanged;
            }
        }
    }

    private void Barometer_ReadingChanged(object sender, BarometerChangedEventArgs e)
    {
        // Update UI Label with barometer state
        BarometerLabel.TextColor = Colors.Green;
        BarometerLabel.Text = $"Barometer: {e.Reading}";
    }
    protected override void OnDisappearing()
    {
        base.OnDisappearing();
        ToggleBarometer();

    }
}
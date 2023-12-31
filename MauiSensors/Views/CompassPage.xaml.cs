namespace MauiSensors.Views;

public partial class CompassPage : ContentPage
{
	public CompassPage()
	{
		InitializeComponent();
        ToggleCompass();
	}
    private void ToggleCompass()
    {
        if (Compass.Default.IsSupported)
        {
            if (!Compass.Default.IsMonitoring)
            {
                // Turn on compass
                Compass.Default.ReadingChanged += Compass_ReadingChanged;
                Compass.Default.Start(SensorSpeed.UI);
            }
            else
            {
                // Turn off compass
                Compass.Default.Stop();
                Compass.Default.ReadingChanged -= Compass_ReadingChanged;
            }
        }
    }

    private void Compass_ReadingChanged(object sender, CompassChangedEventArgs e)
    {
        // Update UI Label with compass state
        CompassLabel.TextColor = Colors.Green;
        CompassLabel.Text = $"Compass: {e.Reading}";
        ((CompassFace)myCompassView.Drawable).SetNorth(360-e.Reading.HeadingMagneticNorth);
        myCompassView.Invalidate();
    }
    protected override void OnDisappearing()
    {
        base.OnDisappearing();
        ToggleCompass();

    }
}
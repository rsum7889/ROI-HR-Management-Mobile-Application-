//using Plugin.Maui.ScreenBrightness;

namespace Employee.Maui
{
    public partial class MainPage : ContentPage
    {
       
        public MainPage()
        {
            InitializeComponent();
            //sliderBrightness.Value = ScreenBrightness.Default.Brightness;
        }

        //private void sliderBrightness_ValueChanged(object sender, ValueChangedEventArgs e)
        //{
        //    ScreenBrightness.Default.Brightness = (float) e.NewValue;
        //    labelBrightness.Text = ScreenBrightness.Default.Brightness.ToString();
        //}
    }

}

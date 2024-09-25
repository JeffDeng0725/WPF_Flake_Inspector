using System.Windows.Media;
using MaterialDesignColors;
using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MaterialDesignColors.ColorManipulation;


namespace MyToDo1.ViewModels
{
    public class SkinViewModel:BindableBase
    {
        public IEnumerable<ISwatch> Swatches { get; } = SwatchHelper.Swatches;
        public DelegateCommand<Object> ChangeHueCommand { get; private set; }
        private readonly PaletteHelper paletteHelper = new();

        public SkinViewModel()
        {
            ChangeHueCommand = new DelegateCommand<Object>  (ChangeHue);
        }

        private void ChangeHue(object? obj)
        {
            var hue = (Color)obj!;

            Theme theme = paletteHelper.GetTheme();

            theme.PrimaryLight = new ColorPair(hue.Lighten());
            theme.PrimaryMid = new ColorPair(hue);
            theme.PrimaryDark = new ColorPair(hue.Darken());

            paletteHelper.SetTheme(theme);
        }

        private bool _isDarkTheme = true;
        public bool IsDarkTheme
        {
            get => _isDarkTheme;
            set
            {
                if (SetProperty(ref _isDarkTheme, value))
                {
                    ModifyTheme(theme => theme.SetBaseTheme(value ? BaseTheme.Dark : BaseTheme.Light));
                }
            }
        }
        private static void ModifyTheme(Action<Theme> modificationAction)
        {
            var paletteHelper = new PaletteHelper();
            Theme theme = paletteHelper.GetTheme();

            modificationAction?.Invoke(theme);

            paletteHelper.SetTheme(theme);
        }
    }
}

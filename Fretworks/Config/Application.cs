using MudBlazor;

namespace Fretworks.Config;

public enum ThemeMode
{
    Light,
    Dark
}

public class Application
{
    private ThemeMode _themeMode = ThemeMode.Light;

    public string Title => "Fret-works";

    public MudTheme Theme { get; } = new()
    {
        PaletteLight = LightPalette(),
        PaletteDark = DarkPalette(),
        LayoutProperties = new LayoutProperties()
        {
            DrawerWidthLeft = "450px",
            // DrawerWidthRight = "300px"
        }
    };

    public string DarkLightModeButtonIcon
    {
        get
        {
            return IsDarkTheme switch
            {
                true => Icons.Material.Rounded.AutoMode,
                false => Icons.Material.Outlined.DarkMode,
            };
        }
    }

    public bool IsDarkTheme => _themeMode == ThemeMode.Dark;
    public bool IsLightTheme => _themeMode == ThemeMode.Light;

    public ThemeMode ToggleThemeMode()
    {
        return _themeMode switch
        {
            ThemeMode.Light => _themeMode = ThemeMode.Dark,
            ThemeMode.Dark => _themeMode = ThemeMode.Light,
            _ => throw new ArgumentOutOfRangeException()
        };
    }
    private static PaletteLight LightPalette()
    {
        return new()
        {
            AppbarText = "#ffffff",
            AppbarBackground = "#303440",
            Black = "rgba(39,44,52,1)", //"#110e2d",
            DrawerBackground = "#ffffff",
            GrayLight = "#e8e8e8",
            GrayLighter = "#f9f9f9",
            TextPrimary = "#000000",
            TextSecondary = "#92929f",
            DrawerText = "#000000",
            Primary = "#0C1436"
        };
    }

    private static PaletteDark DarkPalette()
    {
        return new()
        {
            AppbarText = "#ffffff",
            AppbarBackground = "#303440", //rgba(26,26,39,0.8)
            Primary = "rgba(173,173,177,1)",
            Surface = "#1e1e2d",
            Background = "#1a1a27",
            BackgroundGray = "#151521",
            DrawerBackground = "#1a1a27",
            ActionDefault = "#74718e",
            ActionDisabled = "#9999994d",
            ActionDisabledBackground = "#605f6d4d",
            TextPrimary = "#ffffff",
            TextSecondary = "#92929f",
            TextDisabled = "#ffffff33",
            DrawerIcon = "#92929f",
            DrawerText = "#ffffff",
            GrayLight = "#2a2833",
            GrayLighter = "#1e1e2d",
            Info = "#4a86ff",
            Success = "#3dcb6c",
            Warning = "#ffb545",
            Error = "#ff3f5f",
            LinesDefault = "#33323e",
            TableLines = "#33323e",
            Divider = "#292838",
            OverlayLight = "#1e1e2d80"
        };
    }
}
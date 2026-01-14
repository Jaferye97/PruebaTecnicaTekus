namespace CountriesApiClient.Model;

internal class NameModel
{
    public string Common { get; set; }
    public string Official { get; set; }
    public Dictionary<string, NativeNameDetail> NativeName { get; set; }
}

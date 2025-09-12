public class HotkeyBinding
{
    public Button Button { get; set; }
    public Label Label { get; set; }
    public bool IsCapturing { get; set; }
    public Action<int> SetKeycode { get; set; }
    public string ButtonDefaultText { get; set; }
    public string LabelPrefix { get; set; }
}
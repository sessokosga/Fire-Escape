namespace WebGLxna;
public class Prompt{
    public Prompt(string input, string result)
    {
        this.input = input;
        this.result = result;
    }

    public string input { get; set; }
    public string result { get; set; }
}
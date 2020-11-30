using System;
using System.Text;

namespace convert_variable_name
{
    class Program
    {
        static void Main(string[] args)
        {
            var cVariable = "sample_var_name"; // output : sampleVarName
            var javaVariable = "sampleVarName"; // output : sample_var_name
            Console.WriteLine($"Input - {cVariable} and output - {convert(cVariable)}");
            Console.WriteLine($"Input - {javaVariable} and output - {convert(javaVariable)}");
        }

        static string convert(string input)
        {
            string output = string.Empty;
            if (string.IsNullOrEmpty(input)) return input;
            if (input.Contains("_"))
            {
                var arr = input.Split("_");
                for (int i = 1; i <= arr.Length - 1; i++)
                {
                    if (!string.IsNullOrWhiteSpace(arr[i]))
                    {
                        StringBuilder sb = new StringBuilder(arr[i]);
                        sb[0] = char.ToUpper(sb[0]);
                        arr[i] = sb.ToString();
                    }
                }
                output = string.Join("", arr);
            }
            else
            {
                var charArr = input.ToCharArray();
                StringBuilder sb = new StringBuilder();
                if (charArr.Length > 0) sb.Append(charArr[0]);
                for(int i = 1; i < charArr.Length; i++)
                {
                    char c = charArr[i];
                    if (char.IsUpper(c))
                    {
                        sb.Append("_");
                        sb.Append(char.ToLower(c));
                    }
                    else
                    {
                        sb.Append(charArr[i]);
                    }
                }
                output = sb.ToString();
            }

            return output;
        }
    }
}

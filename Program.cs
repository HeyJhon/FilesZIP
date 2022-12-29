using Aspose.Zip;
using System.Text;

Console.WriteLine("Leyendo archivos ZIP");

string extractPath = Directory.GetCurrentDirectory().ToString();
string[] files = Directory.GetFiles(extractPath);

foreach (var item in files)
{
    if(item.Contains(".zip")){

        System.Console.WriteLine(item.ToString());

        using (FileStream zipFile = File.Open(item, FileMode.Open))
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            using (var archive = new Archive(zipFile, new ArchiveLoadOptions() 
            { DecryptionPassword = "12345" }))
            {
                archive.ExtractToDirectory(extractPath);
            }
        }

    }
}
string todoElTexto = "";
foreach (var item in files)
{
    if(item.Contains(".txt")){
        string text = File.ReadAllText(item);  
        todoElTexto += text+"\n";
    }
}
System.Console.WriteLine(todoElTexto);
File.WriteAllText("todoElTexto.txt", todoElTexto);




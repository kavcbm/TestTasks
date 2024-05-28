
using  Newtonsoft.Json;
using Newtonsoft.Json.Linq;


namespace Task3;

class Program
{
    static void Main(string[] args)
    {    
    string TemplateFileName, ValuesFileName, ReportFileName;
    
    if (args.Length == 3){
     TemplateFileName = args[0];
     ValuesFileName = args[1];
     ReportFileName = args[2];
    }
    else{// для отладки параметры:
      TemplateFileName = "tests.json";
      ValuesFileName = "values.json";
      ReportFileName = "report.json";      
    }
        
    JObject jsonObject = JObject.Parse(System.IO.File.ReadAllText(TemplateFileName));
    JObject jsonValues = JObject.Parse(System.IO.File.ReadAllText(ValuesFileName));  
    JToken NodeToWrite;

    foreach (JToken node in jsonValues.SelectTokens("$.values[*]")){ 
      NodeToWrite = jsonObject.SelectToken($"$.tests..[?(@.id == {node["id"]})]");
      NodeToWrite["value"] = node["value"];
    }

    //Записать результат в Файл
    string jsonStr = JsonConvert.SerializeObject(jsonObject,Newtonsoft.Json.Formatting.Indented);
    File.WriteAllText(ReportFileName, jsonStr);      
    }
    
}

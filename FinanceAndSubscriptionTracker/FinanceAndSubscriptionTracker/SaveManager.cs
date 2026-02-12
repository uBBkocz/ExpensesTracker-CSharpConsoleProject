using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FinanceAndSubscriptionTracker
{
    
    public class SaveManager
    {
        public static List<Subscription> Data = new List<Subscription>();
        public static string filePath = "DATA.json";
        private static JsonSerializerOptions options = new JsonSerializerOptions
        {
            WriteIndented = true,
            Converters = { new JsonStringEnumConverter() }
        };

        public static void LoadData()
        {
            try
            {
                string stringText = File.ReadAllText(filePath);
                Data = JsonSerializer.Deserialize<List<Subscription>>(stringText, options);
                Logger.Green("Data Succesfully loaded!");
            }
            catch (FileNotFoundException)
            {
                Logger.Yellow("Data file not found! Creating one!");
                File.WriteAllText(filePath, "");
                Data = [];
            }
            catch (Exception ex) 
            {
                string text = File.ReadAllText(filePath);
                if (text.Length == 0)
                {
                    Logger.Yellow("The file doesnt contain anything!");
                }
                else
                {
                    Logger.Red($"Something went wrong! {ex.Message}");
                    Data = [];
                }
            }
        }

        public static void SaveData()
        {
            try
            {
                
                string stringText = JsonSerializer.Serialize(Data, options);
                File.WriteAllText(filePath, stringText);
                Logger.Green("Data Succesfully saved!");
            }
            catch (Exception ex)
            {
                    Logger.Red($"Something went wrong! {ex.Message}");
            }
        }
    }
}

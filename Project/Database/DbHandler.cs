using Project.DatabaseInterface;
using Project.Views;

namespace Project.Database
{
    
    public abstract class DbHandler<T> : IDbHandler<T> where T : class
    {
        public bool AddEntry(T obj,List<T> list, string path)
        {         
            list.Add(obj);
            if(UpdateEntry(path,list)) 
                return true;
            return false;
        }
        public bool UpdateEntry(string path, List<T> list)
        {
            try
            {
                var jsonFormattedContent = Newtonsoft.Json.JsonConvert.SerializeObject(list);
                File.WriteAllText(path, jsonFormattedContent);
            }
            catch(Exception ex)
            {
                HelperClass.LogException(ex, "An error occurred while updating the json.");
                return false;
            }
            return true;
        }
              
    }
}

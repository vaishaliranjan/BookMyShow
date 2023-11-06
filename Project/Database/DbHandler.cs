
namespace Project.Database
{
    internal abstract class DbHandler<T> where T : class
    {
        public bool AddEntry(T obj,List<T> list, string path)
        {
           // list.Sort();
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
            catch
            {
                return false;
            }
            return true;
        }
        
    }
}

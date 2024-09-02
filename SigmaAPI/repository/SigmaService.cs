using SigmaAPI.Models;
using System.Reflection.Metadata.Ecma335;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Xml.Linq;


namespace SigmaAPI.repository
{
    public class SigmaService
    {
        private static string _filePath;
        private string [] _header;
        static StringBuilder sb;
        static List<SegmaData> SegmaList;
        public SigmaService(string filePath, string[] headers)
        {
            _filePath = filePath;
            _header = headers;
            SegmaList = GetCacheRecords();
            sb = new StringBuilder();
        }
        public async Task<bool> CreateHeader() {
            try
            {
                using (var reader = new StreamReader(_filePath))
                {
                    // Create New Header
                    foreach (var field in _header)
                    {
                        sb.Append(field).Append(",");
                    }
                    sb.AppendLine();   
                    return true;
                }
            }
            catch { return false; }
        }
        private static List<SegmaData> GetCacheRecords() {
            using (var reader = new StreamReader(_filePath))
            {
                SegmaList = new List<SegmaData>();
                var lst = reader.ReadToEnd().TrimEnd().Split('\n').Skip(1);
                
                string[] DataRecordData = null;
                if (lst.Count()>0)
                {
                    foreach (var record in lst)
                    {
                        var obj = new SegmaData();
                        DataRecordData = record.Split(',');
                        obj.Firstname = DataRecordData[0].TrimEnd(); 
                        obj.Lastname = DataRecordData[1].TrimEnd(); 
                        obj.Phonenumber = DataRecordData[2].TrimEnd(); 
                        obj.Email = DataRecordData[3].TrimEnd();
                        obj.Timeinterval = DataRecordData[4].TrimEnd();
                        obj.LinkedInprofileURL = DataRecordData[5].TrimEnd();
                        obj.GitHubprofileURL = DataRecordData[6].TrimEnd();
                        obj.Freetextcomment = DataRecordData[7].TrimEnd();
                        SegmaList.Add(obj);
                    }
                    return SegmaList;
                }
                else
                {
                    SegmaList = new List<SegmaData>();
                    return SegmaList;
                }              
            }
        }
        public List<SegmaData >checkIfExistRecordOrNew(SegmaData obj) {
            var ItemForUpdate =  SegmaList.FirstOrDefault(a => a.Email == obj.Email);
            if (ItemForUpdate == null) {
                SegmaList.Add(obj);
                return SegmaList;
            }
            
            var myList =  SegmaList
            .Where(w => w.Email == ItemForUpdate.Email)
            .ToList();
            foreach (var item in myList)
            {
                item.Firstname = obj.Firstname;
                item.Lastname = obj.Lastname;
                item.Phonenumber = obj.Phonenumber;
                item.Timeinterval = obj.Timeinterval;
                item.LinkedInprofileURL = obj.LinkedInprofileURL;
                item.GitHubprofileURL = obj.GitHubprofileURL;
                item.Freetextcomment = obj.Freetextcomment;
            }
            return SegmaList;            
        }
        public bool UpdateOrSave(List<SegmaData> lst) {
            try
            {
                foreach (var obj in lst)
                {
                    string line = obj.Firstname + "," + obj.Lastname + "," + obj.Phonenumber + "," + obj.Email + "," + obj.Timeinterval + "," + obj.LinkedInprofileURL + "," + obj.GitHubprofileURL + "," + obj.Freetextcomment;
                    sb.AppendLine(line);
                }
                File.WriteAllText(_filePath, sb.ToString());
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}

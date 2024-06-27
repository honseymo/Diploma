using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doc_Builder.ClassesForGenerate
{
    class RequestWord
    {


        public RequestWord()
        {
        }
        internal bool Process(string _tmname, string path, string _fullName)
        {
            try
            {   
                User10_Sgr1Entities conn = new User10_Sgr1Entities();
                Mil_ReadyDocuments document = new Mil_ReadyDocuments();
                Mil_Templates template = conn.Mil_Templates.Where(C => C.Header == _tmname).FirstOrDefault();
                document.Path = path;
                document.Date = DateTime.Now;
                document.DocumentID = template.ID;
                if(_fullName!="")
                {
                    MIL_Employees employer = conn.MIL_Employees.Where(C => C.FullName == _fullName).FirstOrDefault();
                    document.EmployerID = employer.ID;
                }
                conn.Mil_ReadyDocuments.Add(document);
                conn.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
           
        }
    }
}

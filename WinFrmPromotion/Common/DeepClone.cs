using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace WinFrmPromotion
{

    [Serializable]
    class Teacher : People
    {

       public  Student student = new Student();
        
        //public Teacher DeepClone()
        //{
        //    Teacher teacher = (Teacher)this.MemberwiseClone();
        //    teacher.student = new Student() 
        //    {
        //        ID = this.student.ID,
        //        Name = this.student.Name
        //    };
        //    return teacher;
        //}
        public Teacher DeepClone()
        {
     
            using (MemoryStream ms = new MemoryStream())
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(ms, this);
                ms.Seek(0, SeekOrigin.Begin);

                Teacher teache= (Teacher)formatter.Deserialize(ms);

                ms.Close();
                return teache;
            }
            
        }
    }
    [Serializable]
    class Student : People
    {
    }
    [Serializable]
    class People
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }
}

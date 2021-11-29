using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace lab2
{
    class LINQ : IStrategy
    {
        public List<Material> Algorithm(Material m, string path)
        {
            List<Material> result = new List<Material>();
            var doc = XDocument.Load(path);
            var res = from obj in doc.Descendants("material")
                      where (
                      (obj.Attribute("author").Value == m.author || m.author == String.Empty) &&
                      (obj.Attribute("name").Value == m.name || m.name == String.Empty) &&
                      (obj.Attribute("faculty").Value == m.faculty || m.faculty == String.Empty) &&
                      (obj.Attribute("cathedra").Value == m.cathedra || m.cathedra == String.Empty) &&
                      (obj.Attribute("size").Value == m.size || m.size == String.Empty) &&
                      (obj.Attribute("dateofCreating").Value == m.dateOfCreating || m.dateOfCreating == String.Empty))
                      select new
                      {
                          author = (string)obj.Attribute("author"),
                          name = (string)obj.Attribute("name"),
                          faculty = (string)obj.Attribute("faculty"),
                          cathedra = (string)obj.Attribute("cathedra"),
                          size = (string)obj.Attribute("size"),
                          dateofCreating = (string)obj.Attribute("dateofCreating")
                      };
            foreach (var r in res)
            {
                Material material = new Material();
                material.author = r.author;
                material.name = r.name;
                material.faculty = r.faculty;
                material.cathedra = r.cathedra;
                material.size = r.size;
                material.dateOfCreating = r.dateofCreating;
                result.Add(material);
            }
            return result;
        }
    }
}

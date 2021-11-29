using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace lab2
{
    class DOM : IStrategy
    {
        public List<Material> Algorithm(Material m, string path)
        {
            List<Material> result = new List<Material>();
            string[] material = new string[6];
            XmlDocument doc = new XmlDocument();
            doc.Load(path);

            XmlNode node = doc.DocumentElement;
            foreach (XmlNode n in node.ChildNodes)
            {
                for (int i = 0; i < 6; i++)
                {
                    material[i] = "";
                }
                foreach (XmlAttribute attribute in n.Attributes)
                {
                    if (attribute.Name == "author" && (attribute.Value == m.author || m.author == String.Empty))
                    {
                        material[0] = attribute.Value;
                    }
                    if (attribute.Name == "name" && (attribute.Value == m.name || m.name == String.Empty))
                    {
                        material[1] = attribute.Value;
                    }
                    if (attribute.Name == "faculty" && (attribute.Value == m.faculty || m.faculty == String.Empty))
                    {
                        material[2] = attribute.Value;
                    }
                    if (attribute.Name == "cathedra" && (attribute.Value == m.cathedra || m.cathedra == String.Empty))
                    {
                        material[3] = attribute.Value;
                    }
                    if (attribute.Name == "size" && (attribute.Value == m.size || m.size == String.Empty))
                    {
                        material[4] = attribute.Value;
                    }
                    if (attribute.Name == "dateofCreating" && (attribute.Value == m.dateOfCreating || m.dateOfCreating == String.Empty))
                    {
                        material[5] = attribute.Value;
                    }
                }
                if (material[0] != "" && material[1] != "" && material[2] != "" && material[3] != "" && material[4] != "" && material[5] != "")
                {
                    Material mater = new Material();
                    mater.author = material[0];
                    mater.name = material[1];
                    mater.faculty = material[2];
                    mater.cathedra = material[3];
                    mater.size = material[4];
                    mater.dateOfCreating = material[5];
                    result.Add(mater);
                }
            }
            return result;
        }
    }
}

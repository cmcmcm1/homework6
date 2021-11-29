using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Windows.Forms;

namespace lab2
{
    class SAX : IStrategy
    {
        public List<Material> Algorithm(Material m, string path)
        {
            List<Material> result = new List<Material>();
            var xmlReader = new XmlTextReader(path);
            string[] material = new string[6];
            while (xmlReader.Read())
            {
                if (xmlReader.HasAttributes)
                {
                    while (xmlReader.MoveToNextAttribute())
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            material[i] = "";
                        }
                        if (xmlReader.Name == "author" && (xmlReader.Value == m.author || m.author == String.Empty))
                        {
                            material[0] = xmlReader.Value;
                            xmlReader.MoveToNextAttribute();
                            if (xmlReader.Name == "name" && (xmlReader.Value == m.name || m.name == String.Empty))
                            {
                                material[1] = xmlReader.Value;
                                xmlReader.MoveToNextAttribute();
                                if (xmlReader.Name == "faculty" && (xmlReader.Value == m.faculty || m.faculty == String.Empty))
                                {
                                    material[2] = xmlReader.Value;
                                    xmlReader.MoveToNextAttribute();
                                    if (xmlReader.Name == "cathedra" && (xmlReader.Value == m.cathedra || m.cathedra == String.Empty))
                                    {
                                        material[3] = xmlReader.Value;
                                        xmlReader.MoveToNextAttribute();
                                        if (xmlReader.Name == "size" && (xmlReader.Value == m.size || m.size == String.Empty))
                                        {
                                            material[4] = xmlReader.Value;
                                            xmlReader.MoveToNextAttribute();
                                            if (xmlReader.Name == "dateofCreating" && (xmlReader.Value == m.dateOfCreating || m.dateOfCreating == String.Empty))
                                            {
                                                material[5] = xmlReader.Value;
                                            }
                                        }
                                    }
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
                    }
                }
            }
            xmlReader.Close();
            return result;
        }
    }
}

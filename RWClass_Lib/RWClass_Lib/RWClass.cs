using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Linq;
using Interface_Lib;

namespace RWClass_Lib
{
    public class RWClass : IMethods 
    {
        List<Instruments> instrumentsList;
        string path = "D:\\SW\\InstrumentDB.xml";
        string catchPath = @"D:\SW\InstrumentDB.xml";
        public RWClass()
        {
        }

        public List<Instruments> getInstruments()
        {
            try
            {
                XDocument doc = XDocument.Load(path);
                instrumentsList = (from instrument in doc.Descendants("Instrument")
                                   select new Instruments
                                   {
                                       Name = instrument.Element("Name").Value,
                                       User = instrument.Element("User").Value,
                                       Project = instrument.Element("Project").Value
                                   }).ToList();

                return instrumentsList;
            }
            catch
            {
                return null;
            }
        }

        public void addInstrument(Instruments newIns)
        {
            string _name = newIns.Name;
            string _user = newIns.User;
            string _project = newIns.Project;

            try
            {
                FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(fs);
                fs.Close();

                if(_name != "" && _user!="" && _project != "")
                {
                    XmlElement newInstrument = xmlDoc.CreateElement("Instrument");

                    XmlElement name = xmlDoc.CreateElement("Name");
                    name.InnerText = _name;
                    newInstrument.AppendChild(name);

                    XmlElement user = xmlDoc.CreateElement("User");
                    user.InnerText = _user;
                    newInstrument.AppendChild(user);

                    XmlElement project = xmlDoc.CreateElement("Project");
                    project.InnerText = _project;
                    newInstrument.AppendChild(project);

                    xmlDoc.DocumentElement.InsertAfter(newInstrument, xmlDoc.DocumentElement.LastChild);

                    FileStream fsxml = new FileStream(path, FileMode.Truncate, FileAccess.Write, FileShare.ReadWrite);

                    xmlDoc.Save(fsxml);
                    fsxml.Close();
                }
            }
            catch
            {
                File.Create(catchPath).Close();
                FileStream fs = new FileStream(catchPath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                XmlDocument xmlDoc = new XmlDocument(); 
                string rootNode = "<Instruments>  </Instruments>";
                File.WriteAllText(catchPath, rootNode);

                xmlDoc.Load(fs);
                fs.Close();

                if (_name != "" && _user != "" && _project != "")
                {
                    XmlElement newInstrument = xmlDoc.CreateElement("Instrument");

                    XmlElement name = xmlDoc.CreateElement("Name");
                    name.InnerText = _name;
                    newInstrument.AppendChild(name);

                    XmlElement user = xmlDoc.CreateElement("User");
                    user.InnerText = _user;
                    newInstrument.AppendChild(user);

                    XmlElement project = xmlDoc.CreateElement("Project");
                    project.InnerText = _project;
                    newInstrument.AppendChild(project);

                    xmlDoc.DocumentElement.InsertAfter(newInstrument, xmlDoc.DocumentElement.LastChild);

                    FileStream fsxml = new FileStream(catchPath, FileMode.Truncate, FileAccess.Write, FileShare.ReadWrite);

                    xmlDoc.Save(fsxml);
                    fsxml.Close();
                }   
            }
        }

        public void deleteInstrument(string _instrumentDelete)
        {
            if (File.Exists(path))
            {
                XDocument doc = XDocument.Load(path);

                foreach (var item in doc.Descendants("Instrument"))
                {
                    if (item.Element("Name").Value == _instrumentDelete)
                    {
                        ((XElement)item.Element("Name")).Parent.Remove();
                        doc.Save(path);
                        break;
                    }
                }
            }
        }

        public void updateInstrument(string _instrName, Instruments instruments)
        {
            if (File.Exists(path))
            {
                XDocument doc = XDocument.Load(path);

                foreach (var item in doc.Descendants("Instrument"))
                {
                    if (item.Element("Name").Value == _instrName)
                    {
                        item.Element("Name").SetValue(instruments.Name);
                        item.Element("User").SetValue(instruments.User);
                        item.Element("Project").SetValue(instruments.Project);

                        doc.Save(path);
                        break;
                    }
                }
            }
        }
    }
}

using ETL.Utility;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ETL.Core
{
    class DSpaceHelper
    {
        public static List<DSpaceMetadataField> dSpaceMetadataFields = new List<DSpaceMetadataField>();

        public static DataTable ConvertCSVtoDataTable(string strFilePath)
        {
            StreamReader sr = new StreamReader(strFilePath);
            string[] headers = sr.ReadLine().Split(',');
            DataTable dt = new DataTable();
            foreach (string header in headers)
            {
                dt.Columns.Add(header);
            }
            while (!sr.EndOfStream)
            {
                string[] row = sr.ReadLine().Split(',');
                DataRow dr = dt.NewRow();
                for (int i = 0; i < row.Count(); i++)
                {
                    dr[headers[i]] = row[i];
                }
                dt.Rows.Add(dr);
            }
            return dt;
        }

        public static void CreateMetadataFieldsList(DataTable dataTable)
        {
            DSpaceMetadataField dSpaceMetadataField;
            foreach (DataRow row in dataTable.Rows)
            {
                string element = row.Field<string>("element");
                string qualifier = "";
                try
                {
                    qualifier = row.Field<string>("qualifier");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Helper.Log(e.Message);
                }
                dSpaceMetadataField = new DSpaceMetadataField(element, qualifier);
                dSpaceMetadataFields.Add(dSpaceMetadataField);
            }
        }

        public static void SetMetadaFieldList()
        {
            string path = "../../DSpaceMetadatafield.csv";
            DataTable dt = ConvertCSVtoDataTable(path);
            CreateMetadataFieldsList(dt);
        }

        public static List<string> GetMetadataFieldsNames()
        {
            List<string> fieldNames = new List<string>();
            foreach (DSpaceMetadataField dSpaceMetadataField in dSpaceMetadataFields)
            {
                fieldNames.Add(dSpaceMetadataField.name);
            }
            return fieldNames;
        }

        public void CreateXml(List<KeyValuePair<DSpaceMetadataField, string>> metadatasWithValues, string path)
        {
            XmlDocument xmlDoc = new XmlDocument();
            XmlNode rootNode = xmlDoc.CreateElement("dublin_core");
            xmlDoc.AppendChild(rootNode);

            foreach (KeyValuePair<DSpaceMetadataField, string> metadataWithValue in metadatasWithValues)
            {
                XmlNode node = xmlDoc.CreateElement("dcvalue");

                DSpaceMetadataField field = metadataWithValue.Key;
                string value = metadataWithValue.Value;
                this.AddAttributeToNode("schema", node, xmlDoc, "dc");
                this.AddAttributeToNode("element", node, xmlDoc, field.element);
                if (field.qualifier != null && field.qualifier != "")
                {
                    this.AddAttributeToNode("qualifier", node, xmlDoc, field.qualifier);
                }

                node.InnerText = value;
                rootNode.AppendChild(node);
            }

            xmlDoc.Save(path + "\\dublin_core.xml");
        }

        private void AddAttributeToNode(string attributeName, XmlNode node, XmlDocument document, string value)
        {
            XmlAttribute attribute = document.CreateAttribute(attributeName);
            attribute.Value = value;
            node.Attributes.Append(attribute);
        }

        public void CreateItemsRepository(DataTable dspaceData, string repositoryPath)
        {
            Directory.CreateDirectory(repositoryPath);
            int itemNumber = 0;

            foreach (DataRow dataRow in dspaceData.Rows)
            {
                List<KeyValuePair<DSpaceMetadataField, string>> metadataWithValues = new List<KeyValuePair<DSpaceMetadataField, string>>();
                string itemRepository = "item" + itemNumber.ToString();
                itemNumber++;
                DSpaceMetadataField metadataField;
                string itemCompletePath = repositoryPath + "\\" + itemRepository;
                Directory.CreateDirectory(itemCompletePath);

                for (int i = 0; i < dspaceData.Columns.Count; i++)
                {
                    string column = dspaceData.Columns[i].ColumnName;
                    string value = dataRow.Field<string>(column);

                    if (column == "path")
                    {
                        this.DownloadResource(value, itemCompletePath);
                    }
                    else
                    {
                        string[] metadatafields = column.Split('.');
                        string element = metadatafields[0];
                        string qualifier = "";
                        if (metadatafields.Count() == 2)
                        {
                            qualifier = metadatafields[1];
                        }
                        metadataField = new DSpaceMetadataField(element, qualifier);
                        metadataWithValues.Add(new KeyValuePair<DSpaceMetadataField, string>(metadataField, value));
                    }
                }
                this.CreateXml(metadataWithValues, itemCompletePath);
            }
        }

        // TODO: Implement download feature
        public void DownloadResource(string resourcePath, string downloadPath)
        {
            //download link and save it in downloadpath
            string resourceName = "";
            this.CreateContentsFile(downloadPath, resourceName);
        }

        private void CreateContentsFile(string path, string resourceName)
        {
            using (StreamWriter sw = File.CreateText(path + "\\contents."))
            {
                sw.WriteLine(resourceName);
            }
        }
    }
}

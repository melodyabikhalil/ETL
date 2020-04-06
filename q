[1mdiff --git a/ETL/Core/DSpaceDatabase.cs b/ETL/Core/DSpaceDatabase.cs[m
[1mindex 1de7ee0..6545a7c 100644[m
[1m--- a/ETL/Core/DSpaceDatabase.cs[m
[1m+++ b/ETL/Core/DSpaceDatabase.cs[m
[36m@@ -24,17 +24,19 @@[m [mnamespace ETL.Core[m
 [m
         public void SetColumns()[m
         {[m
[31m-            DSpaceMetadataField metadataField = new DSpaceMetadataField("contributor", "author");[m
[32m+[m[32m            DSpaceMetadataField metadataField = new DSpaceMetadataField("author", "contributor");[m
             columns.Add(metadataField.name);[m
             metadataField = new DSpaceMetadataField("title");[m
             columns.Add(metadataField.name);[m
             metadataField = new DSpaceMetadataField("publisher");[m
             columns.Add(metadataField.name);[m
[31m-            metadataField = new DSpaceMetadataField("date", "issued");[m
[32m+[m[32m            metadataField = new DSpaceMetadataField("issued", "date");[m
             columns.Add(metadataField.name);[m
[31m-            metadataField = new DSpaceMetadataField("identifier", "issn");[m
[32m+[m[32m            metadataField = new DSpaceMetadataField("issn", "identifier");[m
             columns.Add(metadataField.name);[m
[31m-            metadataField = new DSpaceMetadataField("identifier", "isbn");[m
[32m+[m[32m            metadataField = new DSpaceMetadataField("isbn", "identifier");[m
[32m+[m[32m            columns.Add(metadataField.name);[m
[32m+[m[32m            metadataField = new DSpaceMetadataField("language");[m
             columns.Add(metadataField.name);[m
             columns.Add("path");[m
 [m
[1mdiff --git a/ETL/Core/DSpaceHelper.cs b/ETL/Core/DSpaceHelper.cs[m
[1mindex 0df1e65..f5b69c5 100644[m
[1m--- a/ETL/Core/DSpaceHelper.cs[m
[1m+++ b/ETL/Core/DSpaceHelper.cs[m
[36m@@ -118,7 +118,6 @@[m [mnamespace ETL.Core[m
                 List<KeyValuePair<DSpaceMetadataField, string>> metadataWithValues = new List<KeyValuePair<DSpaceMetadataField, string>>();[m
                 string itemRepository = "item" + itemNumber.ToString();[m
                 itemNumber++;[m
[31m-                Global.progressForm.UpdateForm(ProgressForm.PROGRESSBAR_VALUE, itemNumber.ToString());[m
                 DSpaceMetadataField metadataField;[m
                 string itemCompletePath = repositoryPath + "\\" + itemRepository;[m
                 Directory.CreateDirectory(itemCompletePath);[m
[36m@@ -146,11 +145,20 @@[m [mnamespace ETL.Core[m
                     }[m
                 }[m
                 CreateXml(metadataWithValues, itemCompletePath);[m
[32m+[m[32m                Global.progressForm.UpdateForm(ProgressForm.PROGRESSBAR_VALUE, itemNumber.ToString());[m
             }[m
         }[m
 [m
         public static void DownloadResource(string resourcePath, string downloadPath)[m
         {[m
[32m+[m
[32m+[m[32m            if (resourcePath.IndexOf("berytos-csh.usj.edu.lb") >= 0)[m
[32m+[m[32m            {[m
[32m+[m[32m                resourcePath = resourcePath.Replace("berytos-csh.usj.edu.lb", "192.168.102.17");[m
[32m+[m[32m            }[m
[32m+[m
[32m+[m
[32m+[m
             Path.GetFullPath(resourcePath).Replace(@"\", @"\\");[m
             Path.GetFullPath(downloadPath).Replace(@"\", @"\\");[m
             string resourceName = Path.GetFileName(resourcePath).Trim();[m

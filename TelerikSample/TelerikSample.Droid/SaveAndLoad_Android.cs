using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Java.IO;
using Microsoft.Practices.Unity;
using TelerikSample.Droid;
using Xamarin.Forms;

[assembly:Xamarin.Forms.Dependency(typeof(SaveAndLoad_Android))]
namespace TelerikSample.Droid
{
    public class SaveAndLoad_Android : ISaveAndLoad
    {
        public void Save(string filename, MemoryStream stream)
        {
            var root = Android.OS.Environment.DirectoryDownloads;
            var file = new Java.IO.File(root, filename);
            if (file.Exists()) file.Delete();
            try
            {
                var outs = new FileOutputStream(file);
                outs.Write(stream.ToArray());
                outs.Flush();
                outs.Close();
            }
            catch (Exception e)
            {
                var f = e;
            }
            //if (file.Exists())
            //{
            //    var path = Android.Net.Uri.FromFile(file);
            //    var extension =
            //        Android.Webkit.MimeTypeMap.GetFileExtensionFromUrl(Android.Net.Uri.FromFile(file).ToString());
            //    var mimeType = Android.Webkit.MimeTypeMap.Singleton.GetMimeTypeFromExtension(extension);
            //    var intent = new Intent(Intent.ActionOpenDocument);
            //    intent.SetDataAndType(path, mimeType);

            //    Forms.Context.StartActivity(Intent.CreateChooser(intent, "Choose App"));
            //}
        }
    }
}